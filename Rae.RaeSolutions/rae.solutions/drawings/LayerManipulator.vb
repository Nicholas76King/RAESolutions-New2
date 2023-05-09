Imports System.IO
Imports System.Collections

Public Class LayerManipulator

    Shared Function ManipulateDXF(ByVal inputFileName As String, ByVal outputFileName As String, ByVal onLayers() As String, ByVal offLayers() As String, ByVal dims As Hashtable) As Boolean



        For h As Integer = 0 To onLayers.Length - 1
            onLayers(h) = onLayers(h).ToUpper
        Next

        Dim objReader As New StreamReader(inputFileName)

        Dim lines As New ArrayList



        Dim line As String
        line = objReader.ReadLine


        Do Until line Is Nothing
            lines.Add(line)
            line = objReader.ReadLine
        Loop

        objReader.Close()



        For i As Integer = 0 To lines.Count - 1

            If lines(i).ToString = "  0" AndAlso (lines(i + 1).ToString.ToUpper.Trim = "TEXT" OrElse lines(i + 1).ToString.ToUpper.Trim = "MTEXT") Then
                Dim k As Integer = 0
                Dim tempS As String

                k += 1
                tempS = lines(i + k + 1).ToString

                Do Until tempS = "  1"
                    k += 1
                    tempS = lines(i + k + 1).ToString
                Loop
                lines(i + k + 2) = replaceText(lines(i + k + 2).ToString, dims)
            End If


            If lines(i).ToString = "  0" AndAlso (lines(i + 1).ToString.ToUpper.Trim = "TEXT" OrElse lines(i + 1).ToString.ToUpper.Trim = "MTEXT") Then
                Dim k As Integer = 0
                Dim tempS As String

                k += 1
                tempS = lines(i + k + 1).ToString

                Do Until tempS = " 62"
                    k += 1
                    tempS = lines(i + k + 1).ToString
                Loop
                If lines(i + k + 2).ToString = "     1" Then lines(i + k + 2) = "     7"
            End If




            If lines(i).ToString = "  0" AndAlso lines(i + 1).ToString.ToUpper.Trim = "LAYER" Then
                Dim k As Integer = 0
                Dim tempS As String
                Dim layerName As String

                k += 1
                tempS = lines(i + k + 1).ToString



                Do Until tempS = "  2"
                    k += 1
                    tempS = lines(i + k + 1).ToString
                Loop
                layerName = lines(i + k + 2).ToString



                Do Until tempS = " 62"
                    k += 1
                    tempS = lines(i + k + 1).ToString
                Loop

                For Each l As String In onLayers
                    If l.ToUpper = layerName.ToUpper Then
                        lines(i + k + 2) = "     7"
                    End If
                Next

                For Each l As String In offLayers
                    If l.ToUpper = layerName.ToUpper Then
                        lines(i + k + 2) = "    -1"
                    End If
                Next



                If lines(i + k + 2).ToString = "     1" Then lines(i + k + 2) = "     7"

            End If


        Next



        Dim objWriter As New StreamWriter(outputFileName)
        For Each line In lines
            objWriter.WriteLine(line)
        Next

        objWriter.Close()




        'If lastLine.Trim = "1" Then
        '    line = replaceText(line)
        'End If


        'If line.ToLower.Trim = "layer" AndAlso lastLine.Trim.ToLower = "0" Then
        '    objWriter.WriteLine(line)


        'End If




    End Function




    Shared Function ExtractDXFLayerList(ByVal inputFileName As String) As String()

        Dim returnLayers As New List(Of String)


        Dim objReader As New StreamReader(inputFileName)

        Dim lines As New ArrayList


        Dim line As String
        line = objReader.ReadLine


        Do Until line Is Nothing
            lines.Add(line)
            line = objReader.ReadLine
        Loop

        objReader.Close()



        For i As Integer = 0 To lines.Count - 1


            If lines(i).ToString = "  0" AndAlso lines(i + 1).ToString.ToUpper.Trim = "LAYER" Then
                Dim k As Integer = 0
                Dim tempS As String
                Dim layerName As String

                k += 1
                tempS = lines(i + k + 1).ToString

                Do Until tempS = "  2"
                    k += 1
                    tempS = lines(i + k + 1).ToString
                Loop
                layerName = lines(i + k + 2).ToString

                returnLayers.Add(layerName)

            End If

        Next


        Return returnLayers.ToArray


    End Function


    Structure HandleList
        Dim handle As String
        Dim text As String
    End Structure

    Shared Function ExtractDXFTextHandles(ByVal inputFileName As String) As HandleList()

        Dim returnLayers As New List(Of HandleList)


        Dim objReader As New StreamReader(inputFileName)

        Dim lines As New ArrayList


        Dim line As String
        line = objReader.ReadLine


        Do Until line Is Nothing
            lines.Add(line)
            line = objReader.ReadLine
        Loop

        objReader.Close()



        For i As Integer = 0 To lines.Count - 1


            If lines(i).ToString = "  0" AndAlso (lines(i + 1).ToString.ToUpper.Trim = "TEXT" OrElse lines(i + 1).ToString.ToUpper.Trim = "MTEXT") Then
                Dim k As Integer = 0
                Dim tempS As String
                Dim handleName As String, text1 As String

                k += 1
                tempS = lines(i + k + 1).ToString

                Do Until tempS = "  5"
                    k += 1
                    tempS = lines(i + k + 1).ToString
                Loop

                handleName = lines(i + k + 2).ToString



                k = 1
                tempS = lines(i + k + 1).ToString

                Do Until tempS = "  1"
                    k += 1
                    tempS = lines(i + k + 1).ToString
                Loop
                text1 = lines(i + k + 2).ToString

                text1 = text1.Replace("i_", "")
                text1 = text1.Replace("I_", "")

                Dim handleList1 As New HandleList

                handleList1.handle = handleName
                handleList1.text = text1

                returnLayers.Add(handleList1)
            End If


        Next


        Return returnLayers.ToArray


    End Function


    Private Shared Function replaceText(ByVal x As String, ByVal dims As Hashtable) As String

        If dims.ContainsKey(x) Then
            Return dims(x).ToString
        Else
            Return x
        End If


    End Function



End Class
