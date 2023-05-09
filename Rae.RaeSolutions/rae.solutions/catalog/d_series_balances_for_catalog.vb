Imports rae.Data.Access
Imports rae.solutions.compressors
Imports rae.solutions.condensing_units
Imports System.Environment
Imports System.IO
Imports System.Text
Imports appinfo


Namespace rae.solutions.catalogs

    Public Class d_series_balance_for_catalog
        '  Friend user As user

        Private condensing_unit_repository As I_Repository
        Private compressor_repository As i_compressor_repository

        Sub New(ByVal condensing_unit_repository As I_Repository, _
                ByVal compressor_repository As i_compressor_repository)
            Me.condensing_unit_repository = condensing_unit_repository
            Me.compressor_repository = compressor_repository
        End Sub

        Sub save(ByVal folder_path As String, ByVal letter As String)
            Dim results = get_balance_results(letter)
            generate_csv(results, folder_path)


            'detour
            '            Dim results = getAmpAnalysisDataResults(letter)
            '           generate_csv(results, folder_path)
            '          Beep()


        End Sub

        Private Function get_balance_results(ByVal ModelStartsWithString As String) As List(Of catalog_data)


            Dim constantReturnGasTemp As String = ""
            '            MsgBox("FIXXX")

            Dim units = condensing_unit_repository.get_units_where_model_starts_with(ModelStartsWithString)
            'Dim units = condensing_unit_repository.get_units_where_model_starts_with("BDS")


            Dim conditions As Balance.Standard_Conditions
            conditions.altitude = 0
            '            conditions.ambient = 85
            '           conditions.suction = 20
            conditions.voltage = 460



            'Dim ambients = New List(Of Double)(New Double() {95, 59, 35})
            'Dim high_temp_suctions = New List(Of Double)(New Double() {25, -20})
            'Dim low_temp_suctions = New List(Of Double)(New Double() {25, -20})


            'Dim ambients = New List(Of Double)(New Double() {104})
            'Dim high_temp_suctions = New List(Of Double)(New Double() {45})
            'Dim low_temp_suctions = New List(Of Double)(New Double() {0})



            'Dim ambients = New List(Of Double)(New Double() {104})
            'Dim high_temp_suctions = New List(Of Double)(New Double() {45})
            'Dim low_temp_suctions = New List(Of Double)(New Double() {0})

            'KYLEB

            'Dim tsi_temp_suctions = New List(Of Double)(New Double() {35, 40, 45, 50, 55})


            Dim ambients = New List(Of Double)(New Double() {85, 95, 105, 115})
            'Dim ambients = New List(Of Double)(New Double() {95})


            Dim high_temp_suctions = New List(Of Double)(New Double() {-10, 0, 10, 20, 25, 30, 45})
            '            Dim low_temp_suctions = New List(Of Double)(New Double() {-40, -30, -20, -10, 0})
            Dim low_temp_suctions = New List(Of Double)(New Double() {-40, -30, -25, -20, -10, 0})  ' Extra @-25 for BLU


            'Dim high_temp_suctions = New List(Of Double)(New Double() {20})
            'Dim low_temp_suctions = New List(Of Double)(New Double() {-20})


            Dim tsi_temp_suctions = New List(Of Double)(New Double() {35, 40, 45, 50, 55})
            'Dim tsi_temp_suctions = New List(Of Double)(New Double() {25, -20})

            'For k As Integer = -10 To 45
            '    high_temp_suctions.Add(k)
            'Next

            'For k As Integer = -40 To 0
            '    low_temp_suctions.Add(k)
            'Next

            'For k As Integer = -35 To 55
            '    tsi_temp_suctions.Add(k)
            'Next

            'For k As Integer = 85 To 115
            '    ambients.Add(k)
            'Next




            Dim suctions As List(Of Double)
            Dim data = New List(Of catalog_data)

            Dim percentage = 100 / units.Count

            Dim i = 0
            For Each unit In units
                '   Try

                If unit.model.StartsWith("20") Then
                    suctions = tsi_temp_suctions
                ElseIf unit.model.StartsWith("BLU") Then
                    If unit.model.Split(CChar("-"))(1).EndsWith("L") Then
                        suctions = low_temp_suctions
                    Else
                        suctions = high_temp_suctions
                    End If
                ElseIf unit.model.Substring(2) Like "*L*" Then
                    suctions = low_temp_suctions
                Else
                    suctions = high_temp_suctions
                End If
                For Each ambient In ambients
                    conditions.ambient = ambient
                    For Each suction In suctions

                        'If ambient = 105 AndAlso suction = -30 Then
                        '    Beep()
                        'End If

                        conditions.suction = suction
                        Dim balance = New Balance(compressor_repository)
                        Dim result = balance.this(unit, conditions)

                        Dim compressor = New compressor_repository().get_compressor(unit.circuits(0).compressorMasterID, unit.refrigerant, conditions.voltage, "Condenser", constantReturnGasTemp)
                        If compressor.coef Is Nothing Then GoTo outofhere
                        Dim head_pressure_will_not_trip_sensor = New refrigerant_head_pressure_will_not_trip_sensor(
                           unit.refrigerant, result.point.condensing_temp)

                        If Not compressor.is_within_safety_limits(conditions.suction, result.point.condensing_temp) _
                        Or head_pressure_will_not_trip_sensor.validate().is_invalid Then
                            result.point.capacity = -1
                            result.point.unit_kw = -1
                        End If
                        data.Add(New catalog_data(unit.model, result, compressor.mcc, compressor.rla))
                    Next
                Next

                '    Catch ex As Exception
                '      MsgBox("Error " & ex.Message)
                '    End Try
outofhere:

                i += 1
                set_progress(i * percentage)
            Next

            Return data
        End Function


        Private Function getAmpAnalysisDataResults(ByVal ModelStartsWithString As String) As List(Of ampAnalysisData)
            Dim units = condensing_unit_repository.get_units_where_model_starts_with(ModelStartsWithString)


            Dim constantReturnGasTemp As String = ""
            MsgBox("Here")



            getAmpAnalysisDataResults = New List(Of ampAnalysisData)

            Dim conditions As Balance.Standard_Conditions
            conditions.altitude = 0
            conditions.voltage = 460

            Dim ambients = New List(Of Double)(New Double() {95, 59, 35})


            Dim suctions = New List(Of Double)(New Double() {25})



            Dim CR As New compressors.compressor_repository

            Dim data = New List(Of catalog_data)

            Dim percentage = 100 / units.Count

            Dim i = 0
            For Each unit In units
                '   Try

                ' add max suction

                Dim maxCondensing, maxSuction As Double

                Dim SuccessFlag As Boolean = False
                Dim cLSI As New CompressorLimits(CR.getCompressorLimitID(unit.circuits(0).compressorMasterID), False, successFlag)
                cLSI.GetMaxSuctionAndCondensing(maxSuction, maxCondensing)


                Dim MaxCondAtZeroSuct As Double = cLSI.GetMaxCondensingAtSuction(0)
                Dim MaxCondAtFourtyFiveSuct As Double = cLSI.GetMaxCondensingAtSuction(45)

                'If unit.model.Substring(1) Like "*L*" Then
                '    suctions = low_temp_suctions
                'Else
                '    suctions = high_temp_suctions
                'End If

                For Each ambient In ambients
                    conditions.ambient = ambient
                    For Each suction In suctions

                        If (unit.model.Substring(1) Like "*L*" AndAlso suction = 0 AndAlso (unit.model.Substring(1) Like "*L4*" OrElse unit.model.Substring(1) Like "*L7" OrElse unit.model.Substring(1) Like "*L7F*" OrElse unit.model.Substring(1) Like "*L7C*" OrElse unit.model.Substring(1) Like "*L7A*" OrElse unit.model.Substring(1) Like "*L8A*" OrElse unit.model.Substring(1) Like "*L9A*")) _
                            OrElse (unit.model.Substring(1) Like "*M*" AndAlso suction = 45 AndAlso (unit.model.Substring(1) Like "*M4*" OrElse unit.model.Substring(1) Like "*M7")) _
                            OrElse (unit.model.Substring(1) Like "*M*" AndAlso suction = 55 AndAlso (unit.model.Substring(1) Like "*M7F*" OrElse unit.model.Substring(1) Like "*M7C*" OrElse unit.model.Substring(1) Like "*M7A*" OrElse unit.model.Substring(1) Like "*M9A*" OrElse unit.model.Substring(1) Like "*M8A*")) _
                            Then




                            conditions.suction = suction
                            Dim balance = New Balance(compressor_repository)
                            Dim result = balance.this(unit, conditions)

                            Dim compressor = New compressor_repository().get_compressor(unit.circuits(0).compressorMasterID, unit.refrigerant, conditions.voltage, "Condenser", constantReturnGasTemp)

                            Dim head_pressure_will_not_trip_sensor = New refrigerant_head_pressure_will_not_trip_sensor(
                               unit.refrigerant, result.point.condensing_temp)

                            If Not compressor.is_within_safety_limits(conditions.suction, result.point.condensing_temp) _
                            Or head_pressure_will_not_trip_sensor.validate().is_invalid Then
                                result.point.capacity = -1
                                result.point.unit_kw = -1
                            End If
                            data.Add(New catalog_data(unit.model, result, compressor.mcc, compressor.rla))


                            Dim r As New ampAnalysisData
                            Dim d As catalog_data = data(data.Count - 1)



                            Dim tModel As String = d.model
                            If tModel.Substring(1).Contains("L") Then
                                tModel = tModel.Substring(0, tModel.IndexOf("L"))

                            Else
                                tModel = tModel.Substring(0, tModel.IndexOf("M"))
                            End If

                            r.model = tModel
                            '                            r.model = d.model ' tModel

                            If d.model.Substring(2).Contains("L") Then
                                r.temperature = "LowTemp"
                            ElseIf d.model.Substring(2).Contains("M") Then
                                r.temperature = "MedTemp"
                            End If

                            r.compressorModel = compressor.model
                            r.compressorMasterID = compressor.MasterID
                            r.Ambient = CStr(System.Math.Round(d.result.conditions.ambient, 1))


                            '''''''
                            r.CompressorMCC = CStr(System.Math.Round(d.CompressorMCC, 1))
                            r.CompressorMCC_1_4 = CStr(System.Math.Round(d.CompressorMCC / 1.4, 1))
                            r.CompressorMCC_1_56 = CStr(System.Math.Round(d.CompressorMCC / 1.56, 1))

                            Dim ps As New compressor_polynomial
                            Dim result2 = ps.calculate(r, compressor.coef, maxSuction, maxCondensing)



                            ' FOR LOW TEMP UNITS, 5 ADDITIOANAL COLUMSN FOR EACH REFRIGERANT AT 0 SUCTION AND MAX CONDENSING @ ZERO SUCTION PER ENVELOPE
                            Dim CompAmpsAtZeroSuctionMaxCond As Double = -1000
                            If MaxCondAtZeroSuct > -1000 Then
                                Dim psL As New compressor_polynomial
                                Dim resultL = psL.calculate(r, compressor.coef, 0, MaxCondAtZeroSuct)
                                CompAmpsAtZeroSuctionMaxCond = CDbl(resultL.a)
                            End If



                            ' FOR MED TEMP UNITS, 5 ADDITIOANAL COLUMSN FOR EACH REFRIGERANT AT 45 SUCTION AND MAX CONDENSING @ ZERO SUCTION PER ENVELOPE
                            Dim CompAmpsAt45SuctionMaxCond As Double = -1000
                            If MaxCondAtFourtyFiveSuct > -1000 Then
                                Dim psH As New compressor_polynomial
                                Dim resultH = psH.calculate(r, compressor.coef, 45, MaxCondAtFourtyFiveSuct)
                                CompAmpsAt45SuctionMaxCond = CDbl(resultH.a)
                            End If





                            '''''''




                            Select Case compressor.refrigerant.ToUpper.Substring(0, 4)
                                Case "R404"
                                    r.Suction_404_507 = CStr(System.Math.Round(d.result.conditions.suction, 1))
                                    r.CondTemp_404 = CStr(System.Math.Round(d.result.point.condensing_temp, 1))
                                    r.CompressorRLA_404 = CStr(System.Math.Round(d.result.point.SingleCompressorAmps, 1))
                                    r.CompressorAmps_Max_Suc_404 = CStr(System.Math.Round(CSng(result2.a), 1))
                                    r.CompressorAmps_Max_Suc_At_0_404 = CStr(System.Math.Round(CompAmpsAtZeroSuctionMaxCond, 1))
                                    r.CompressorAmps_Max_Suc_At_45_404 = CStr(System.Math.Round(CompAmpsAt45SuctionMaxCond, 1))

                                Case "R507"
                                    r.Suction_404_507 = CStr(System.Math.Round(d.result.conditions.suction, 1))
                                    r.CondTemp_507 = CStr(System.Math.Round(d.result.point.condensing_temp, 1))
                                    r.CompressorRLA_507 = CStr(System.Math.Round(d.result.point.SingleCompressorAmps, 1))
                                    r.CompressorAmps_Max_Suc_507 = CStr(System.Math.Round(CSng(result2.a), 1))
                                    r.CompressorAmps_Max_Suc_At_0_507 = CStr(System.Math.Round(CompAmpsAtZeroSuctionMaxCond, 1))
                                    r.CompressorAmps_Max_Suc_At_45_507 = CStr(System.Math.Round(CompAmpsAt45SuctionMaxCond, 1))
                                Case "R407"
                                    Select Case compressor.refrigerant.ToUpper.Substring(0, 5)
                                        Case "R407A"
                                            r.Suction_407 = CStr(System.Math.Round(d.result.conditions.suction, 1))
                                            r.CondTemp_407a = CStr(System.Math.Round(d.result.point.condensing_temp, 1))
                                            r.CompressorRLA_407A = CStr(System.Math.Round(d.result.point.SingleCompressorAmps, 1))
                                            r.CompressorAmps_Max_Suc_407A = CStr(System.Math.Round(CSng(result2.a), 1))
                                            r.CompressorAmps_Max_Suc_At_0_407A = CStr(System.Math.Round(CompAmpsAtZeroSuctionMaxCond, 1))
                                            r.CompressorAmps_Max_Suc_At_45_407A = CStr(System.Math.Round(CompAmpsAt45SuctionMaxCond, 1))
                                        Case "R407C"
                                            r.Suction_407 = CStr(System.Math.Round(d.result.conditions.suction, 1))
                                            r.CondTemp_407c = CStr(System.Math.Round(d.result.point.condensing_temp, 1))
                                            r.CompressorRLA_407C = CStr(System.Math.Round(d.result.point.SingleCompressorAmps, 1))
                                            r.CompressorAmps_Max_Suc_407C = CStr(System.Math.Round(CSng(result2.a), 1))
                                            r.CompressorAmps_Max_Suc_At_0_407C = CStr(System.Math.Round(CompAmpsAtZeroSuctionMaxCond, 1))
                                            r.CompressorAmps_Max_Suc_At_45_407C = CStr(System.Math.Round(CompAmpsAt45SuctionMaxCond, 1))
                                        Case "R407F"
                                            r.Suction_407 = CStr(System.Math.Round(d.result.conditions.suction, 1))
                                            r.CondTemp_407f = CStr(System.Math.Round(d.result.point.condensing_temp, 1))
                                            r.CompressorRLA_407F = CStr(System.Math.Round(d.result.point.SingleCompressorAmps, 1))
                                            r.CompressorAmps_Max_Suc_407F = CStr(System.Math.Round(CSng(result2.a), 1))
                                            r.CompressorAmps_Max_Suc_At_0_407F = CStr(System.Math.Round(CompAmpsAtZeroSuctionMaxCond, 1))
                                            r.CompressorAmps_Max_Suc_At_45_407F = CStr(System.Math.Round(CompAmpsAt45SuctionMaxCond, 1))
                                    End Select

                                Case "R448"
                                    r.Suction_448A = CStr(System.Math.Round(d.result.conditions.suction, 1))
                                    r.CondTemp_448A = CStr(System.Math.Round(d.result.point.condensing_temp, 1))
                                    r.CompressorRLA_448A = CStr(System.Math.Round(d.result.point.SingleCompressorAmps, 1))
                                    r.CompressorAmps_Max_Suc_448A = CStr(System.Math.Round(CSng(result2.a), 1))
                                    r.CompressorAmps_Max_Suc_At_0_448A = CStr(System.Math.Round(CompAmpsAtZeroSuctionMaxCond, 1))
                                    r.CompressorAmps_Max_Suc_At_45_448A = CStr(System.Math.Round(CompAmpsAt45SuctionMaxCond, 1))

                                Case "R449"
                                    r.Suction_449A = CStr(System.Math.Round(d.result.conditions.suction, 1))
                                    r.CondTemp_449A = CStr(System.Math.Round(d.result.point.condensing_temp, 1))
                                    r.CompressorRLA_449A = CStr(System.Math.Round(d.result.point.SingleCompressorAmps, 1))
                                    r.CompressorAmps_Max_Suc_449A = CStr(System.Math.Round(CSng(result2.a), 1))
                                    r.CompressorAmps_Max_Suc_At_0_449A = CStr(System.Math.Round(CompAmpsAtZeroSuctionMaxCond, 1))
                                    r.CompressorAmps_Max_Suc_At_45_449A = CStr(System.Math.Round(CompAmpsAt45SuctionMaxCond, 1))


                            End Select

                            '  r.CompressorMCC=result.point.




                            getAmpAnalysisDataResults.Add(r)

                        End If

                    Next
                Next


                i += 1
                set_progress(i * percentage)
            Next





            getAmpAnalysisDataResults.Sort(Function(x, y) x.sortme.CompareTo(y.sortme))

            '            Dim previousModelString As String = getAmpAnalysisDataResults.Item(0).sortme

            For j As Integer = 0 To getAmpAnalysisDataResults.Count - 1
                Dim currentModelString As String = getAmpAnalysisDataResults.Item(j).sortme


                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorMCC) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            If p.CompressorMCC < getAmpAnalysisDataResults.Item(j).CompressorMCC Then
                                p.CompressorMCC = getAmpAnalysisDataResults.Item(j).CompressorMCC
                                p.CompressorMCC_1_4 = getAmpAnalysisDataResults.Item(j).CompressorMCC_1_4
                                p.CompressorMCC_1_56 = getAmpAnalysisDataResults.Item(j).CompressorMCC_1_56
                            Else
                                getAmpAnalysisDataResults.Item(j).CompressorMCC = p.CompressorMCC
                                getAmpAnalysisDataResults.Item(j).CompressorMCC_1_4 = p.CompressorMCC_1_4
                                getAmpAnalysisDataResults.Item(j).CompressorMCC_1_56 = p.CompressorMCC_1_56
                            End If
                        End If
                    Next
                End If



                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorRLA_404) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CompressorRLA_404 = getAmpAnalysisDataResults.Item(j).CompressorRLA_404
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorRLA_507) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CompressorRLA_507 = getAmpAnalysisDataResults.Item(j).CompressorRLA_507
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorRLA_407A) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CompressorRLA_407A = getAmpAnalysisDataResults.Item(j).CompressorRLA_407A
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorRLA_407C) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CompressorRLA_407C = getAmpAnalysisDataResults.Item(j).CompressorRLA_407C
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorRLA_407F) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CompressorRLA_407F = getAmpAnalysisDataResults.Item(j).CompressorRLA_407F
                        End If
                    Next
                End If

                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorRLA_448A) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CompressorRLA_448A = getAmpAnalysisDataResults.Item(j).CompressorRLA_448A
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorRLA_449A) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CompressorRLA_449A = getAmpAnalysisDataResults.Item(j).CompressorRLA_449A
                        End If
                    Next
                End If


                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_404) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CompressorAmps_Max_Suc_404 = getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_404
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_507) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CompressorAmps_Max_Suc_507 = getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_507
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_407A) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CompressorAmps_Max_Suc_407A = getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_407A
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_407C) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CompressorAmps_Max_Suc_407C = getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_407C
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_407F) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CompressorAmps_Max_Suc_407F = getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_407F
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_448A) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CompressorAmps_Max_Suc_448A = getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_448A
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_449A) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CompressorAmps_Max_Suc_449A = getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_449A
                        End If
                    Next
                End If


                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).Suction_404_507) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.Suction_404_507 = getAmpAnalysisDataResults.Item(j).Suction_404_507
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).Suction_407) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.Suction_407 = getAmpAnalysisDataResults.Item(j).Suction_407
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).Suction_448A) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.Suction_448A = getAmpAnalysisDataResults.Item(j).Suction_448A
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).Suction_449A) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.Suction_449A = getAmpAnalysisDataResults.Item(j).Suction_449A
                        End If
                    Next
                End If

                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CondTemp_404) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CondTemp_404 = getAmpAnalysisDataResults.Item(j).CondTemp_404
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CondTemp_507) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CondTemp_507 = getAmpAnalysisDataResults.Item(j).CondTemp_507
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CondTemp_407a) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CondTemp_407a = getAmpAnalysisDataResults.Item(j).CondTemp_407a
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CondTemp_407c) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CondTemp_407c = getAmpAnalysisDataResults.Item(j).CondTemp_407c
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CondTemp_407f) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CondTemp_407f = getAmpAnalysisDataResults.Item(j).CondTemp_407f
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CondTemp_448A) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CondTemp_448A = getAmpAnalysisDataResults.Item(j).CondTemp_448A
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CondTemp_449A) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CondTemp_449A = getAmpAnalysisDataResults.Item(j).CondTemp_449A
                        End If
                    Next
                End If


                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_At_0_404) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CompressorAmps_Max_Suc_At_0_404 = getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_At_0_404
                            If p.CompressorAmps_Max_Suc_At_0_404 = "-1000" Then p.CompressorAmps_Max_Suc_At_0_404 = ""
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_At_0_507) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CompressorAmps_Max_Suc_At_0_507 = getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_At_0_507
                            If p.CompressorAmps_Max_Suc_At_0_507 = "-1000" Then p.CompressorAmps_Max_Suc_At_0_507 = ""
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_At_0_407A) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CompressorAmps_Max_Suc_At_0_407A = getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_At_0_407A
                            If p.CompressorAmps_Max_Suc_At_0_407A = "-1000" Then p.CompressorAmps_Max_Suc_At_0_407A = ""
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_At_0_407C) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CompressorAmps_Max_Suc_At_0_407C = getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_At_0_407C
                            If p.CompressorAmps_Max_Suc_At_0_407C = "-1000" Then p.CompressorAmps_Max_Suc_At_0_407C = ""
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_At_0_448A) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CompressorAmps_Max_Suc_At_0_448A = getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_At_0_448A
                            If p.CompressorAmps_Max_Suc_At_0_448A = "-1000" Then p.CompressorAmps_Max_Suc_At_0_448A = ""
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_At_0_449A) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CompressorAmps_Max_Suc_At_0_449A = getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_At_0_449A
                            If p.CompressorAmps_Max_Suc_At_0_449A = "-1000" Then p.CompressorAmps_Max_Suc_At_0_449A = ""
                        End If
                    Next
                End If




                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_At_45_404) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CompressorAmps_Max_Suc_At_45_404 = getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_At_45_404
                            If p.CompressorAmps_Max_Suc_At_45_404 = "-1000" Then p.CompressorAmps_Max_Suc_At_45_404 = ""
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_At_45_507) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CompressorAmps_Max_Suc_At_45_507 = getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_At_45_507
                            If p.CompressorAmps_Max_Suc_At_45_507 = "-1000" Then p.CompressorAmps_Max_Suc_At_45_507 = ""
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_At_45_407A) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CompressorAmps_Max_Suc_At_45_407A = getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_At_45_407A
                            If p.CompressorAmps_Max_Suc_At_45_407A = "-1000" Then p.CompressorAmps_Max_Suc_At_45_407A = ""
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_At_45_407C) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CompressorAmps_Max_Suc_At_45_407C = getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_At_45_407C
                            If p.CompressorAmps_Max_Suc_At_45_407C = "-1000" Then p.CompressorAmps_Max_Suc_At_45_407C = ""
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_At_45_407F) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CompressorAmps_Max_Suc_At_45_407F = getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_At_45_407F
                            If p.CompressorAmps_Max_Suc_At_45_407F = "-1000" Then p.CompressorAmps_Max_Suc_At_45_407F = ""
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_At_45_448A) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CompressorAmps_Max_Suc_At_45_448A = getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_At_45_448A
                            If p.CompressorAmps_Max_Suc_At_45_448A = "-1000" Then p.CompressorAmps_Max_Suc_At_45_448A = ""
                        End If
                    Next
                End If
                If Not String.IsNullOrWhiteSpace(getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_At_45_449A) Then
                    For Each p In getAmpAnalysisDataResults
                        If p.sortme = getAmpAnalysisDataResults.Item(j).sortme Then
                            p.CompressorAmps_Max_Suc_At_45_449A = getAmpAnalysisDataResults.Item(j).CompressorAmps_Max_Suc_At_45_449A
                            If p.CompressorAmps_Max_Suc_At_45_449A = "-1000" Then p.CompressorAmps_Max_Suc_At_45_449A = ""
                        End If
                    Next
                End If


            Next


            For ij As Integer = getAmpAnalysisDataResults.Count - 1 To 1 Step -1
                If getAmpAnalysisDataResults.Item(ij).sortme = getAmpAnalysisDataResults.Item(ij - 1).sortme Then
                    getAmpAnalysisDataResults.RemoveAt(ij)
                End If
            Next

            '  Return data
        End Function
        '


        Public Event progress_changed(ByVal percentage As Double)

        Private Sub set_progress(ByVal percentage As Double)
            RaiseEvent progress_changed(percentage)
        End Sub

        Private Sub generate_csv(ByVal data As list(Of catalog_data), ByVal folder_path As String)
            Dim text = New stringbuilder()
            text.AppendLine("Model, Ambient, Suction, Capacity, KW, Cond Temp,Sing Comp Amps, CompMCC, CompRLA")
            For Each d In data
                Dim capacity = If(d.result.point.capacity = -1, "-", d.result.point.capacity.toString)
                Dim unit_kw = If(d.result.point.unit_kw = -1, "-", d.result.point.unit_kw.ToString)

                Dim cond_temp = If(d.result.point.condensing_temp = -1, "-", d.result.point.condensing_temp.ToString)
                Dim singleCompressorAmps As Double = d.result.points(0).SingleCompressorAmps
                text.AppendFormat("{0}, {1}, {2}, {3}, {4}, {5},{6},{8},{9}{7}", _
            d.model, d.result.conditions.ambient, d.result.conditions.suction, capacity, unit_kw, cond_temp, singleCompressorAmps, NewLine, d.CompressorMCC, d.CompressorRLA)
            Next

            Dim file_name = "balance " & Now.ToString.Replace(":", "").Replace("/", "") & ".csv"
            Dim file_path = path.combine(folder_path, file_name)
            Dim stream = file.CreateText(file_path)
            stream.writeLine(file_name & ", " & Date.now.ToString("M/d/yyyy hh:mm:ss"))
            stream.write(text.toString)
            stream.flush()
            stream.close()
        End Sub



        Private Sub generate_csv(ByVal data As List(Of ampAnalysisData), ByVal folder_path As String)
            Dim text = New stringbuilder()
            text.AppendLine("model, temperature, compressorModel, masterID, Ambient, Suction_404_507, Suction_407, Suction_448a, Suction_449a, CondTemp_404, CondTemp_507, CondTemp_407a, CondTemp_407a, CondTemp_407f, CondTemp_448a, CondTemp_449a, CompressorMCC, CompressorMCC_1_4, CompressorMCC_1_56, CompressorRLA_404, CompressorRLA_507, CompressorRLA_407A, CompressorRLA_407C, CompressorRLA_407F, CompressorRLA_448a, CompressorRLA_449a, CompressorAmps_Max_Suc_404, CompressorAmps_Max_Suc_507, CompressorAmps_Max_Suc_407A, CompressorAmps_Max_Suc_407C, CompressorAmps_Max_Suc_407F, CompressorAmps_Max_Suc_448a, CompressorAmps_Max_Suc_449a, CompressorAmps_Max_Suc_at_0_404, CompressorAmps_Max_Suc_at_0_507, CompressorAmps_Max_Suc_at_0_407A, CompressorAmps_Max_Suc_at_0_407C, CompressorAmps_Max_Suc_at_0_407F, CompressorAmps_Max_Suc_at_0_448a, CompressorAmps_Max_Suc_at_0_449a, CompressorAmps_Max_Suc_at_45_404, CompressorAmps_Max_Suc_at_45_507, CompressorAmps_Max_Suc_at_45_407A, CompressorAmps_Max_Suc_at_45_407C, CompressorAmps_Max_Suc_at_45_407F, CompressorAmps_Max_Suc_at_45_448a, CompressorAmps_Max_Suc_at_45_449a")
            For Each d In data
                Dim cond_temp_404 = If(d.CondTemp_404 = "-1", "-", d.CondTemp_404)
                Dim cond_temp_507 = If(d.CondTemp_507 = "-1", "-", d.CondTemp_507)
                Dim cond_temp_407a = If(d.CondTemp_407a = "-1", "-", d.CondTemp_407a)
                Dim cond_temp_407c = If(d.CondTemp_407c = "-1", "-", d.CondTemp_407c)
                Dim cond_temp_407f = If(d.CondTemp_407f = "-1", "-", d.CondTemp_407f)
                Dim cond_temp_448a = If(d.CondTemp_448A = "-1", "-", d.CondTemp_448A)
                Dim cond_temp_449a = If(d.CondTemp_449A = "-1", "-", d.CondTemp_449A)



                text.AppendFormat("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40}, {41}, {42}, {43}, {44}, {45}, {46}, {47}", _
                d.model, d.temperature, d.compressorModel, d.compressorMasterID, d.Ambient, d.Suction_404_507, d.Suction_407, d.Suction_448A, d.Suction_449A, cond_temp_404, cond_temp_507, cond_temp_407a, cond_temp_407c, cond_temp_407f, cond_temp_448a, cond_temp_449a, d.CompressorMCC, d.CompressorMCC_1_4, _
                d.CompressorMCC_1_56, d.CompressorRLA_404, d.CompressorRLA_507, d.CompressorRLA_407A, d.CompressorRLA_407C, d.CompressorRLA_407F, d.CompressorRLA_448A, d.CompressorRLA_449A, d.CompressorAmps_Max_Suc_404, d.CompressorAmps_Max_Suc_507, d.CompressorAmps_Max_Suc_407A, d.CompressorAmps_Max_Suc_407C, d.CompressorAmps_Max_Suc_407F, d.CompressorAmps_Max_Suc_448A, d.CompressorAmps_Max_Suc_449A, _
                d.CompressorAmps_Max_Suc_At_0_404, d.CompressorAmps_Max_Suc_At_0_507, d.CompressorAmps_Max_Suc_At_0_407A, d.CompressorAmps_Max_Suc_At_0_407C, d.CompressorAmps_Max_Suc_At_0_407F, d.CompressorAmps_Max_Suc_At_0_448A, d.CompressorAmps_Max_Suc_At_0_449A, _
                d.CompressorAmps_Max_Suc_At_45_404, d.CompressorAmps_Max_Suc_At_45_507, d.CompressorAmps_Max_Suc_At_45_407A, d.CompressorAmps_Max_Suc_At_45_407C, d.CompressorAmps_Max_Suc_At_45_407F, d.CompressorAmps_Max_Suc_At_45_448A, d.CompressorAmps_Max_Suc_At_45_449A, _
                vbCrLf _
                )
            Next

            Dim file_name = "ampAnalysisData " & Now.ToString.Replace(":", "").Replace("/", "") & ".csv"
            Dim file_path = path.combine(folder_path, file_name)
            Dim stream = file.CreateText(file_path)
            stream.writeLine(file_name & ", " & Date.now.ToString("M/d/yyyy hh:mm:ss"))
            stream.write(text.toString)
            stream.flush()
            stream.close()
        End Sub

    End Class



    Class catalog_data
        Sub New(ByVal model As String, ByVal result As Balance.Result, ByVal compressorMCC As Single, ByVal compressorRLA As Single)
            Me.model = model
            Me.result = result
            Me.CompressorMCC = compressorMCC
            Me.CompressorRLA = compressorRLA
        End Sub
        Public model As String
        Public result As Balance.Result
        Public CompressorMCC As Single
        Public CompressorRLA As Single
    End Class



    Class ampAnalysisData
        Sub New()

        End Sub


        Public Function sortme() As String
            Return model.PadRight(20) & temperature
        End Function

        Sub New(ByVal model As String, ByVal temperature As String, ByVal compressorModel As String, ByVal Ambient As String, ByVal Suction_404_507 As String, ByVal Suction_407 As String, ByVal CondTemp_404 As String, ByVal CondTemp_507 As String, ByVal CondTemp_407a As String, ByVal CondTemp_407c As String, ByVal CondTemp_407f As String, ByVal CondTemp_448a As String, ByVal CondTemp_449a As String, ByVal CompressorMCC As String, ByVal CompressorMCC_1_4 As String, ByVal CompressorMCC_1_56 As String, ByVal CompressorRLA_404 As String, ByVal CompressorRLA_507 As String, ByVal CompressorRLA_407A As String, ByVal CompressorRLA_407C As String, ByVal CompressorRLA_407F As String, ByVal CompressorRLA_448a As String, ByVal CompressorRLA_449a As String, ByVal CompressorAmps_Max_Suc_404 As String, ByVal CompressorAmps_Max_Suc_507 As String, ByVal CompressorAmps_Max_Suc_407A As String, ByVal CompressorAmps_Max_Suc_407C As String, ByVal CompressorAmps_Max_Suc_407F As String, ByVal CompressorAmps_Max_Suc_448a As String, ByVal CompressorAmps_Max_Suc_449a As String, ByVal CompressorAmps_Max_Suc_at_0_404 As String, ByVal CompressorAmps_Max_Suc_at_0_507 As String, ByVal CompressorAmps_Max_Suc_at_0_407A As String, ByVal CompressorAmps_Max_Suc_at_0_407C As String, ByVal CompressorAmps_Max_Suc_at_0_407F As String, ByVal CompressorAmps_Max_Suc_at_0_448a As String, ByVal CompressorAmps_Max_Suc_at_0_449a As String, ByVal CompressorAmps_Max_Suc_at_45_404 As String, ByVal CompressorAmps_Max_Suc_at_45_507 As String, ByVal CompressorAmps_Max_Suc_at_45_407A As String, ByVal CompressorAmps_Max_Suc_at_45_407C As String, ByVal CompressorAmps_Max_Suc_at_45c_407F As String, ByVal CompressorAmps_Max_Suc_at_45c_448a As String, ByVal CompressorAmps_Max_Suc_at_45c_449a As String, ByVal compressorMasterID As String)
            Me.model = model
            Me.temperature = temperature
            Me.compressorModel = compressorModel
            Me.Ambient = Ambient
            Me.Suction_404_507 = Suction_404_507
            Me.Suction_407 = Suction_407


            Me.CondTemp_404 = CondTemp_404
            Me.CondTemp_507 = CondTemp_507
            Me.CondTemp_407a = CondTemp_407a
            Me.CondTemp_407c = CondTemp_407c
            Me.CondTemp_407f = CondTemp_407f
            Me.CondTemp_448A = CondTemp_448a
            Me.CondTemp_449A = CondTemp_449a



            Me.CompressorMCC = CompressorMCC
            Me.CompressorMCC_1_4 = CompressorMCC_1_4
            Me.CompressorMCC_1_56 = CompressorMCC_1_56

            Me.CompressorRLA_404 = CompressorRLA_404
            Me.CompressorRLA_507 = CompressorRLA_507
            Me.CompressorRLA_407A = CompressorRLA_407A
            Me.CompressorRLA_407C = CompressorRLA_407C
            Me.CompressorRLA_407F = CompressorRLA_407F
            Me.CompressorRLA_448A = CompressorRLA_448a
            Me.CompressorRLA_449A = CompressorRLA_449a


            Me.CompressorAmps_Max_Suc_404 = CompressorAmps_Max_Suc_404
            Me.CompressorAmps_Max_Suc_507 = CompressorAmps_Max_Suc_507
            Me.CompressorAmps_Max_Suc_407A = CompressorAmps_Max_Suc_407A
            Me.CompressorAmps_Max_Suc_407C = CompressorAmps_Max_Suc_407C
            Me.CompressorAmps_Max_Suc_407F = CompressorAmps_Max_Suc_407F
            Me.CompressorAmps_Max_Suc_448A = CompressorAmps_Max_Suc_448a
            Me.CompressorAmps_Max_Suc_449A = CompressorAmps_Max_Suc_449a


            Me.CompressorAmps_Max_Suc_At_0_404 = CompressorAmps_Max_Suc_at_0_404
            Me.CompressorAmps_Max_Suc_At_0_507 = CompressorAmps_Max_Suc_at_0_507
            Me.CompressorAmps_Max_Suc_At_0_407A = CompressorAmps_Max_Suc_at_0_407A
            Me.CompressorAmps_Max_Suc_At_0_407C = CompressorAmps_Max_Suc_at_0_407C
            Me.CompressorAmps_Max_Suc_At_0_407F = CompressorAmps_Max_Suc_at_0_407F
            Me.CompressorAmps_Max_Suc_At_0_448A = CompressorAmps_Max_Suc_at_0_448a
            Me.CompressorAmps_Max_Suc_At_0_449A = CompressorAmps_Max_Suc_at_0_449a

            Me.CompressorAmps_Max_Suc_At_45_404 = CompressorAmps_Max_Suc_at_45_404
            Me.CompressorAmps_Max_Suc_At_45_507 = CompressorAmps_Max_Suc_at_45_507
            Me.CompressorAmps_Max_Suc_At_45_407A = CompressorAmps_Max_Suc_at_45_407A
            Me.CompressorAmps_Max_Suc_At_45_407C = CompressorAmps_Max_Suc_at_45_407C
            Me.CompressorAmps_Max_Suc_At_45_407F = CompressorAmps_Max_Suc_At_45_407F
            Me.CompressorAmps_Max_Suc_At_45_448A = CompressorAmps_Max_Suc_At_45_448A
            Me.CompressorAmps_Max_Suc_At_45_449A = CompressorAmps_Max_Suc_At_45_449A

            Me.compressorMasterID = compressorMasterID

        End Sub
        Public model As String
        Public temperature As String
        Public compressorModel As String
        Public compressorMasterID As String
        Public Ambient As String
        Public Suction_404_507 As String
        Public Suction_407 As String
        Public Suction_448A As String
        Public Suction_449A As String

        Public CondTemp_404 As String
        Public CondTemp_507 As String
        Public CondTemp_407a As String
        Public CondTemp_407c As String
        Public CondTemp_407f As String
        Public CondTemp_448A As String
        Public CondTemp_449A As String

        Public CompressorMCC As String
        Public CompressorMCC_1_4 As String
        Public CompressorMCC_1_56 As String

        Public CompressorRLA_404 As String
        Public CompressorRLA_507 As String
        Public CompressorRLA_407A As String
        Public CompressorRLA_407C As String
        Public CompressorRLA_407F As String
        Public CompressorRLA_448A As String
        Public CompressorRLA_449A As String

        Public CompressorAmps_Max_Suc_404 As String
        Public CompressorAmps_Max_Suc_507 As String
        Public CompressorAmps_Max_Suc_407A As String
        Public CompressorAmps_Max_Suc_407C As String
        Public CompressorAmps_Max_Suc_407F As String
        Public CompressorAmps_Max_Suc_448A As String
        Public CompressorAmps_Max_Suc_449A As String

        Public CompressorAmps_Max_Suc_At_0_404 As String
        Public CompressorAmps_Max_Suc_At_0_507 As String
        Public CompressorAmps_Max_Suc_At_0_407A As String
        Public CompressorAmps_Max_Suc_At_0_407C As String
        Public CompressorAmps_Max_Suc_At_0_407F As String
        Public CompressorAmps_Max_Suc_At_0_448A As String
        Public CompressorAmps_Max_Suc_At_0_449A As String

        Public CompressorAmps_Max_Suc_At_45_404 As String
        Public CompressorAmps_Max_Suc_At_45_507 As String
        Public CompressorAmps_Max_Suc_At_45_407A As String
        Public CompressorAmps_Max_Suc_At_45_407C As String
        Public CompressorAmps_Max_Suc_At_45_407F As String
        Public CompressorAmps_Max_Suc_At_45_448A As String
        Public CompressorAmps_Max_Suc_At_45_449A As String





    End Class



End Namespace