Option Strict On
Option Explicit On

Imports System.Math

Namespace Rae.RaeSolutions.Business.Entities

    Public Class Fan

        ''' <summary>Constructs new fan - assigns fan file name based on string passed.</summary>
        ''' <param name="fanString">hp:0.25, dia:20", rpm:1140, high alt</param>
        'Sub New(fanString As String)
        '   Try
        '      parseFanData(fanString.ToLower)                          ' This scares me.  I don't think it is needed.
        '      buildDescription
        '   Catch ex As Exception

        '   End Try
        'End Sub

        ' ''' <summary>Constructs new fan and builds description (description will not show hertz)</summary>
        'Sub New(ByVal fileName As String, ByVal hp As Double, ByVal diameter As Double, ByVal curveRPM As Double, ByVal highAltitude As Boolean, ByVal isVariableSpeed As Boolean)
        '    Me.FileName = fileName
        '    Me.Hp = hp
        '    Me.Diameter = diameter
        '    Me.CurveRPM = curveRPM
        '    Me.IsHighAltitudeFan = highAltitude
        '    Me.isVariableSpeed = isVariableSpeed

        '    buildDescription()
        'End Sub

        ''' <summary>Constructs new fan and builds description (description will show hertz)</summary>
        Sub New(ByVal fileName As String, ByVal horsepower As Double, ByVal diameter As Double, ByVal curveRPM As Double, ByVal highAltitude As Boolean, ByVal hertz As Integer, ByVal isVariableSpeed As Boolean)

            Me.FileName = fileName
            Me.Hp = horsepower
            Me.Diameter = diameter
            Me.CurveRPM = curveRPM
            Me.IsHighAltitudeFan = highAltitude
            Me.isVariableSpeed = isVariableSpeed
            Me.Hertz = hertz
            buildDescription()
        End Sub

        Public Description, FileName As String
        Public Diameter, Hp As Double
        Public Hertz As Integer
        Public IsHighAltitudeFan As Boolean
        Public CurveRPM As Double
        Public isVariableSpeed As Boolean
        'Public OperatingRPM As Double


        ''' <summary>Returns description of fan</summary>
        Overrides Function ToString() As String
            Return Description
        End Function



        Private Sub buildDescription()
            ' creates description "hp:0.25, dia:20", rpm:1140, hz:60, high alt"

            If FileName.ToUpper = "CUSTOM" Then
                Description = "CUSTOM"
                Exit Sub
            End If


            Description = Round(Hp, 2).ToString & " hp, " & Round(Diameter, 0).ToString & """ dia, "

            If isVariableSpeed Then
                Description &= " var. speed"
            Else
                Description &= CurveRPM.ToString & " rpm"
            End If

            If Not Hertz = 0 Then _
               Description &= ", " & Hertz.ToString & " hz"
            If IsHighAltitudeFan Then _
               Description &= ", high alt"
            If FileName = "BR28IN.HE" Then _
               Description &= ", high eff"
        End Sub

        ' hp:0.25, dia:20", rpm:1140, high alt
        'Private Sub parseFanData(description As String)
        '   If InStr(description, "high") > 0 Then
        '      IsHighAltitudeFan = True
        '      description = removeHighAltitudeFrom(description)
        '   Else
        '      IsHighAltitudeFan = False
        '   End If

        '   Diameter   = Val(description.Substring(InStr(description, ","), description.Length - (description.Length - InStrRev(description, ",")) - InStr(description, ",")))
        '   Hp = Val(description.Substring(0, InStr(description, ",")))
        '   Rpm        = CInt(Val(description.Substring(InStrRev(description, ","))))

        '   setFanFileName()
        'End Sub

        ' assumes high altitude is everything after last comma
        Private Function removeHighAltitudeFrom(ByVal description As String) As String
            Dim lastIndex = description.Length - 1
            Dim altitudeStartIndex = InStrRev(description, ",")
            Dim altitudeLength = lastIndex - altitudeStartIndex
            Dim lengthWithoutAltitude = description.Length - altitudeLength

            Dim descriptionWithoutAltitude = description.Substring(0, lengthWithoutAltitude)

            Return descriptionWithoutAltitude
        End Function

        'Private Sub setFanFileName()
        '   If IsHighAltitudeFan = False AndAlso Hp = 0.25 AndAlso Diameter = 20 AndAlso Rpm = 1140 Then
        '      FileName = "F1082029.11"
        '   ElseIf IsHighAltitudeFan = False AndAlso Hp = 0.5 AndAlso Diameter = 20 AndAlso Rpm = 1140 Then
        '      FileName = "F1082029.11"
        '   ElseIf IsHighAltitudeFan = False AndAlso Hp = 0.5 AndAlso Diameter = 24 AndAlso Rpm = 1140 Then
        '      FileName = "LAU2429"
        '   ElseIf IsHighAltitudeFan = False AndAlso Hp = 0.5 AndAlso Diameter = 24 AndAlso Rpm = 950 Then
        '      FileName = "LAU2429.950"
        '   ElseIf IsHighAltitudeFan = False AndAlso Hp = 1 AndAlso Diameter = 28 AndAlso Rpm = 1140 Then
        '      FileName = "BR28IN"
        '   ElseIf IsHighAltitudeFan = False AndAlso Hp = 1 AndAlso Diameter = 28 AndAlso Rpm = 850 Then
        '      FileName = "LAU2840.850"
        '   ElseIf IsHighAltitudeFan = True AndAlso Hp = 1 AndAlso Diameter = 28 AndAlso Rpm = 1140 Then
        '      FileName = "BR28IN.HA"
        '   ElseIf IsHighAltitudeFan = False AndAlso Hp = 1 AndAlso Diameter = 28 AndAlso Rpm = 950 Then
        '      FileName = "BR28IN.950"
        '   ElseIf IsHighAltitudeFan = True AndAlso Hp = 1 AndAlso Diameter = 28 AndAlso Rpm = 950 Then
        '      FileName = "BR28INHA.950"
        '   ElseIf IsHighAltitudeFan = False AndAlso Hp = 2 AndAlso Diameter = 28 AndAlso Rpm = 1140 Then
        '      FileName = "S42832"
        '   ElseIf IsHighAltitudeFan = False AndAlso Hp = 2 AndAlso Diameter = 28 AndAlso Rpm = 850 Then
        '      FileName = "S42832.850"
        '   ElseIf IsHighAltitudeFan = False AndAlso Hp = 2 AndAlso Diameter = 28 AndAlso Rpm = 950 Then
        '      FileName = "S42832.950"
        '   Else
        '      Throw New Exception("Invalid fan string.  Procedure:SetFanFileName in Class:Fan")
        '   End If
        'End Sub


    End Class

End Namespace