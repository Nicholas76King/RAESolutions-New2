

Public Class CoilDLL


    Public Class BasicCondenserCoilResult
        Public Property Capacity As Decimal
    End Class

    Public Shared Function BasicCondenserCoilRating(ByVal TubeDiameter As Decimal, ByVal FL As Decimal, ByVal FH As Decimal, ByVal RowsDeep As Integer, ByVal FPI As Integer, ByVal CFM As Decimal, ByVal CondensingTemp As Decimal, ByVal eATDb As Decimal, ByVal VaporTemp As Decimal, ByVal cCircuits As Integer, ByVal cTubes As Integer, ByVal scCircuits As Decimal, ByVal scTubes As Decimal, ByVal Refrigerant As String, ByVal altitude As Decimal, ByVal DataPath As String) As BasicCondenserCoilResult
        BasicCondenserCoilRating = New BasicCondenserCoilResult

        Dim condenserCoilClass As New RAE_Coil.clsCondenser

        condenserCoilClass.DataFilePath = DataPath
        condenserCoilClass.DataFilePathNIST = DataPath




        Select Case TubeDiameter
            Case 0.375
                condenserCoilClass.TubeOD = 3
            Case 0.5
                condenserCoilClass.TubeOD = 4
            Case 0.625
                condenserCoilClass.TubeOD = 5
        End Select

        condenserCoilClass.FIN_TYPE = "W"
        condenserCoilClass.FPI = FPI
        condenserCoilClass.Rows = RowsDeep
        condenserCoilClass.FinHeight = FH
        condenserCoilClass.FinLength = FL

        If (RowsDeep Mod 2) = 0 Then
            condenserCoilClass.SameEnd = True
        Else
            condenserCoilClass.SameEnd = False
        End If

        condenserCoilClass.TubeThickness = 0.016
        condenserCoilClass.FinMatl = "AL"
        condenserCoilClass.FinThickness = 0.0075
        condenserCoilClass.TubeMatl = "CU"

        condenserCoilClass.RefFileName = GetRefFile(Refrigerant)

        condenserCoilClass.Conn_Tube = "K"


        condenserCoilClass.ExecutionMode = "R"
        condenserCoilClass.Circuits = cCircuits  ' set to zero to reset dll
        condenserCoilClass.Tubes = cTubes
        condenserCoilClass.ScTubes = scTubes  ' sub cooler tubes per circuit  'jay425
        condenserCoilClass.ScCircuits = scCircuits
        condenserCoilClass.TargetLRT = CondensingTemp - ((CondensingTemp - eATDb) * 0.4)


        If RowsDeep > 3 Then
            condenserCoilClass.CondFlow = 1
        Else
            condenserCoilClass.CondFlow = 0
        End If



        condenserCoilClass.CFM = CFM
        condenserCoilClass.ALTD = altitude
        condenserCoilClass.EDB = eATDb


        'End If
        condenserCoilClass.VaporTemp = VaporTemp
        condenserCoilClass.CondTemp = CondensingTemp
        '.SCTUBES = pf.txtSubCoolerCircuit


        ' .RAE_Wr = 0
        condenserCoilClass.CFMT = "S"

        Dim t2 As Long = Now.Ticks

        condenserCoilClass.Execute()

        If condenserCoilClass.OutCount >= 1 AndAlso condenserCoilClass.OutQcoil(condenserCoilClass.OutCount) > 0 Then
            BasicCondenserCoilRating.Capacity = condenserCoilClass.OutQcoil(condenserCoilClass.OutCount)
            'CondenserCoilCapacity.CapacityWithoutSubcooling = coil1.OutQcds(coil1.OutCount)
            'CondenserCoilCapacity.SubcoolerCapacity = coil1.OutQcoil(coil1.OutCount) - coil1.OutQcds(coil1.OutCount)


        Else
            BasicCondenserCoilRating.Capacity = -1
            For i As Integer = 1 To condenserCoilClass.OutErrors_Count
                '        MsgBox(condenserCoilClass.OutErrors(i))
            Next
        End If

    End Function

    Private Shared Function GetRefFile(ByVal refrigerant As String) As String
        If refrigerant.ToLower = "r410a" Then
            Return "R410A.MIX"
            'condenserCoilClass.Ref = 410
        ElseIf refrigerant.ToLower = "r407a" Then
            Return "R407A.MIX"
        ElseIf refrigerant.ToLower = "r407c" Then
            Return "R407C.MIX"
        ElseIf refrigerant.ToLower = "r407f" Then
            Return "R407F.MIX"
        ElseIf refrigerant.ToLower = "r22" Then
            Return "R22.FLD"
        ElseIf refrigerant.ToLower = "r134a" Then
            Return "R134A.FLD"
        ElseIf refrigerant.ToLower = "r404a" Then
            Return "R404A.MIX"
        ElseIf refrigerant.ToLower = "r507" Then
            Return "R507A.MIX"
        ElseIf refrigerant.ToLower = "r502" Then
            Return "R502.MIX"
        ElseIf refrigerant.ToLower = "r448a" Then
            Return "R448A.MIX"
        ElseIf refrigerant.ToLower = "r449a" Then
            Return "R449A.MIX"
        Else
            Return "ERROR"
        End If

    End Function

End Class
