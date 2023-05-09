Imports System.Linq
Imports System.Data
Imports System.Data.ConnectionState

Namespace rae.solutions.compressors

    Class CompressorLimits


        Private Property LPoints As New List(Of LimitPoint)

        Public Sub New(ByVal LimitID As String, ByVal PullFromMasterID As Boolean, ByRef SuccessFlag As Boolean)

            SuccessFlag = False

            If PullFromMasterID Then
                LimitID = GetLimitIDFromMasterID(LimitID)
            End If

            Dim con = create_connection()
            Dim cmd = con.CreateCommand()

            Dim sql As String = "select  xValue, yValue from Limits where CompressorLimitID = '" & LimitID & "' order by iOrder"

            cmd.CommandText = sql
            Dim rdr As IDataReader
            Try
                con.Open()
                rdr = cmd.ExecuteReader()

                While rdr.Read()
                    Dim l As New LimitPoint(CSng(rdr("xValue")), CSng(rdr("yValue")))
                    LPoints.Add(l)

                End While

                If LPoints(0).x <> LPoints(LPoints.Count - 1).x OrElse LPoints(0).y <> LPoints(LPoints.Count - 1).y Then
                    Dim l As New LimitPoint(LPoints(0).x, LPoints(0).y)
                    LPoints.Add(l)

                End If

                SuccessFlag = True

            Catch e As Exception
                Beep()
            Finally
                If rdr IsNot Nothing Then rdr.Close()
                If con.State <> ConnectionState.Closed Then con.Close()
            End Try




        End Sub




        Public Function GetLimitIDFromMasterID(ByVal MasterID As String) As String
            Dim con = create_connection()
            Dim cmd = con.CreateCommand()

            Dim sql As String = "select LimitID from Master where MasterID = '" & MasterID & "' "

            cmd.CommandText = sql
            Dim rdr As IDataReader
            Try
                con.Open()
                rdr = cmd.ExecuteReader()

                If rdr.Read() Then
                    GetLimitIDFromMasterID = rdr("LimitID").ToString

                End If
            Catch e As Exception

            Finally
                If rdr IsNot Nothing Then rdr.Close()
                If con.State <> ConnectionState.Closed Then con.Close()
            End Try


        End Function



        Public Function Valid(ByVal suctionTemp As Single, ByVal condensingTemp As Single) As Boolean
            Return CheckAmbientAndCondTempAgainstCompSafetyLimits(suctionTemp, condensingTemp, LPoints)
        End Function

        Public Function Valid(ByVal suctionTemp As Single) As Boolean
            Return CheckSuctionAgainstCompSafetyLimits(suctionTemp, LPoints)
        End Function




        Private Function create_connection() As IDbConnection
            Return Rae.RaeSolutions.DataAccess.Common.CreateConnection(Rae.RaeSolutions.DataAccess.Common.CompressorDbPath)
        End Function

        '  Private Const DONT_CHECK_COND_TEMP As Single = Single.MinValue


        Private Function pnpoly(ByVal nvert As Integer, ByVal vertx As List(Of Single), ByVal verty As List(Of Single), ByVal testx As Single, ByVal testy As Single) As Integer
            Dim i As Integer, j As Integer, c As Integer = 0
            i = 0
            j = nvert - 1
            While i < nvert
                If ((verty(i) > testy) <> (verty(j) > testy)) AndAlso (testx < (vertx(j) - vertx(i)) * (testy - verty(i)) / (verty(j) - verty(i)) + vertx(i)) Then
                    c = Not c
                End If
                j = System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
            End While
            Return c
        End Function


        Private Function pointInPolygon(ByVal polyCorners As Integer, ByVal polyX As List(Of Single), ByVal polyY As List(Of Single), ByVal x As Single, ByVal y As Single) As Boolean

            Dim i As Integer, j As Integer = polyCorners - 1
            Dim oddNodes As Boolean = False

            For i = 0 To polyCorners - 1
                If (polyY(i) < y AndAlso polyY(j) >= y OrElse polyY(j) < y AndAlso polyY(i) >= y) AndAlso (polyX(i) <= x OrElse polyX(j) <= x) Then
                    oddNodes = oddNodes Xor (polyX(i) + (y - polyY(i)) / (polyY(j) - polyY(i)) * (polyX(j) - polyX(i)) < x)
                End If
                j = i
            Next



            Return oddNodes OrElse PointOnPolygon(polycorners, polyx, polyy, x, y)
        End Function



        Private Function PointOnPolygon(ByVal polyCorners As Integer, ByVal polyX As List(Of Single), ByVal polyY As List(Of Single), ByVal x As Single, ByVal y As Single) As Boolean

            If x = 45 Then
                'Beep()
            End If
            For i = 0 To polyCorners - 1
                If x = polyx(i) AndAlso y = polyy(i) Then Return True
            Next


            For i = 0 To polyCorners - 2
                Dim d1 As Double = Distance(polyX(i), polyY(i), x, y)
                Dim d2 As Double = Distance(polyX(i + 1), polyY(i + 1), x, y)

                Dim d3 As Double = Distance(polyX(i), polyY(i), polyX(i + 1), polyY(i + 1))

                If System.Math.Abs(d3 - (d1 + d2)) < 0.1 Then Return True

            Next


            Return False


        End Function



        Public Function Distance(ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single) As Double
            Return System.Math.Sqrt((System.Math.Abs(x2 - x1) ^ 2) + (System.Math.Abs(y2 - y1) ^ 2))
        End Function



        Private Function CheckAmbientAndCondTempAgainstCompSafetyLimits(ByVal suctionTemp As Single, ByVal condensingTemp As Single, ByVal p As List(Of LimitPoint)) As Boolean


            Dim xs As New List(Of Single)
            Dim ys As New List(Of Single)

            For Each p1 As LimitPoint In p
                xs.Add(p1.x)
                ys.Add(p1.y)
            Next


            Return CBool(pointInPolygon(p.Count, xs, ys, suctionTemp, condensingTemp))


            'Dim i As Integer = pnpoly(p.Count, xs, ys, suctionTemp, condensingTemp)
            'Select Case i
            '    Case -1
            '        Return False
            '    Case 0
            '        Return True
            '    Case 1
            '        Return True
            'End Select



            'Dim vLinesGT = From l1 In l Where l1._isVertical = True And l1._GreaterOrLessThan = LimitLine.GtLt.GT
            'Dim hLinesGT = From l1 In l Where l1._isVertical = False And l1._slope = 0 And l1._GreaterOrLessThan = LimitLine.GtLt.GT
            'Dim sLinesGT = From l1 In l Where l1._isVertical = False And l1._slope <> 0 And l1._GreaterOrLessThan = LimitLine.GtLt.GT
            'Dim vLinesLT = From l1 In l Where l1._isVertical = True And l1._GreaterOrLessThan = LimitLine.GtLt.LT
            'Dim hLinesLT = From l1 In l Where l1._isVertical = False And l1._slope = 0 And l1._GreaterOrLessThan = LimitLine.GtLt.LT
            'Dim sLinesLT = From l1 In l Where l1._isVertical = False And l1._slope <> 0 And l1._GreaterOrLessThan = LimitLine.GtLt.LT


            'Dim result As Boolean = True

            '' calc minX  (check vertical lines and lines with slope != 0 with GT)

            'For Each line1 In vLinesGT
            '    If suctionTemp < line1.CalcSuctionTemp(condensingTemp) Then
            '        Return False
            '    End If
            'Next

            'For Each line1 In sLinesLT
            '    If line1.PositiveSlope Then
            '        If suctionTemp < line1.CalcSuctionTemp(condensingTemp) Then
            '            Return False
            '        End If
            '    Else
            '        If suctionTemp > line1.CalcSuctionTemp(condensingTemp) Then
            '            Return False
            '        End If
            '    End If
            'Next

            '' calc maxX  (check vertical lines and lines with slope != 0 with LT)

            'For Each line1 In vLinesLT
            '    If suctionTemp > line1.CalcSuctionTemp(condensingTemp) Then
            '        Return False
            '    End If
            'Next

            'For Each line1 In sLinesGT
            '    If line1.PositiveSlope Then
            '        If suctionTemp > line1.CalcSuctionTemp(condensingTemp) Then
            '            Return False
            '        End If
            '    Else
            '        If suctionTemp < line1.CalcSuctionTemp(condensingTemp) Then
            '            Return False
            '        End If
            '    End If
            'Next



            ''  If condensingTemp <> DONT_CHECK_COND_TEMP Then
            '' calc minY  (check non vertical lines with GT)
            'For Each line1 In hLinesGT
            '    If condensingTemp < line1.CalcCondTemp(suctionTemp) Then
            '        Return False
            '    End If
            'Next

            'For Each line1 In sLinesGT
            '    If condensingTemp < line1.CalcCondTemp(suctionTemp) Then
            '        Return False
            '    End If
            'Next


            '' calc maxY  (check non vertical lines with LT)
            'For Each line1 In hLinesLT
            '    If condensingTemp > line1.CalcCondTemp(suctionTemp) Then
            '        Return False
            '    End If
            'Next

            'For Each line1 In sLinesLT
            '    If condensingTemp > line1.CalcCondTemp(suctionTemp) Then
            '        Return False
            '    End If
            'Next

            ''   End If

            'Return True

        End Function


        Public Sub GetMinMaxSuction(ByRef suctionMin As Double, ByRef suctionMax As Double)


            suctionMin = 1000 : suctionMax = -1000


            For Each p As LimitPoint In LPoints
                If p.x < suctionMin Then suctionMin = p.x
                If p.x > suctionMax Then suctionMax = p.x

            Next


            'Dim vLinesGT = From l1 In LLines Where l1._isVertical = True And l1._GreaterOrLessThan = LimitLine.GtLt.GT
            'Dim vLinesLT = From l1 In LLines Where l1._isVertical = True And l1._GreaterOrLessThan = LimitLine.GtLt.LT

            'If vLinesGT.Count > 0 Then
            '    suctionMin = vLinesGT(0)._intercept
            'End If

            'If vLinesLT.Count > 0 Then
            '    suctionMax = vLinesLT(0)._intercept
            'End If



        End Sub



        Public Sub GetMaxSuctionAndCondensing(ByRef suctionMax As Double, ByRef condensingMax As Double)


            condensingMax = -1000 : suctionMax = -1000


            'For Each p As LimitPoint In LPoints
            '    If p.y >= condensingMax Then
            '        If p.x >= suctionMax Then
            '            suctionMax = p.x
            '            condensingMax = p.y
            '        End If
            '    End If

            'Next


            For Each p As LimitPoint In LPoints
                If p.x >= suctionMax Then
                    suctionMax = p.x
                End If
            Next


            For Each P As LimitPoint In LPoints
                If P.x = suctionMax Then
                    If P.y > condensingMax Then
                        condensingMax = P.y
                    End If
                End If
            Next


            'Dim vLinesGT = From l1 In LLines Where l1._isVertical = True And l1._GreaterOrLessThan = LimitLine.GtLt.GT
            'Dim vLinesLT = From l1 In LLines Where l1._isVertical = True And l1._GreaterOrLessThan = LimitLine.GtLt.LT

            'If vLinesGT.Count > 0 Then
            '    suctionMin = vLinesGT(0)._intercept
            'End If

            'If vLinesLT.Count > 0 Then
            '    suctionMax = vLinesLT(0)._intercept
            'End If



        End Sub



        Public Function GetMaxCondensingAtSuction(ByVal suction As Double) As Double


            Dim condensingMax As Double = -1000


            For i As Integer = 0 To LPoints.Count - 1
                Dim p1 = LPoints(i)
                Dim p2 = LPoints((i + 1) Mod LPoints.Count)

                If suction >= p1.x AndAlso suction <= p2.x AndAlso p1.x <> p2.x Then

                    Dim c As Double = ((p2.y - p1.y) / (p2.x - p1.x)) * (suction - p1.x) + p1.y
                    If c > condensingMax Then condensingMax = c

                End If


            Next


            'For Each p As LimitPoint In LPoints
            '    If p.y >= condensingMax Then
            '        If p.x >= suctionMax Then
            '            suctionMax = p.x
            '            condensingMax = p.y
            '        End If
            '    End If

            'Next

            Return condensingMax


        End Function




        Private Function CheckSuctionAgainstCompSafetyLimits(ByVal suctionTemp As Single, ByVal l As List(Of LimitPoint)) As Boolean

            Dim minSuction, maxSuction As Double

            GetMinMaxSuction(minSuction, maxSuction)

            If suctionTemp >= minSuction AndAlso suctionTemp <= maxSuction Then Return True
            Return False

            'Dim vLinesGT = From l1 In l Where l1._isVertical = True And l1._GreaterOrLessThan = LimitLine.GtLt.GT
            'Dim vLinesLT = From l1 In l Where l1._isVertical = True And l1._GreaterOrLessThan = LimitLine.GtLt.LT


            'Dim result As Boolean = True

            '' calc minX  (check vertical lines and lines with slope != 0 with GT)

            'For Each line1 In vLinesGT
            '    If suctionTemp < line1.CalcSuctionTemp() Then
            '        Return False
            '    End If
            'Next



            '' calc maxX  (check vertical lines and lines with slope != 0 with LT)

            'For Each line1 In vLinesLT
            '    If suctionTemp > line1.CalcSuctionTemp() Then
            '        Return False
            '    End If
            'Next







            ''   End If

            'Return True

        End Function

    End Class






    Public Class LimitPoint

        Property x As Single
        Property y As Single



        Public Sub New(ByVal iX As Single, ByVal iY As Single)
            x = iX
            y = iY
        End Sub


    End Class



End Namespace