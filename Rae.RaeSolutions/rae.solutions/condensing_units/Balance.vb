Option Strict Off

Imports rae.RaeSolutions.Business.Entities.Cofans
Imports rae.RaeSolutions.Business.Intelligence
Imports rae.solutions
Imports rae.solutions.compressors
Imports rae.solutions.refrigerant
Imports System.Math
Imports rae.BuzzDllInterface

'Imports rae.solutions.group
'Imports rae.RaeSolutions.Business
'Imports rae.RaeSolutions.Business.Entities











Namespace rae.solutions.condensing_units

    'Dim result = balance.This(condensingUnit, at:=conditions)
    'result.Point : result.Points
    'Dim results = balance.This(condensingUnit, at:=conditions, ambientStep, ambientNumSteps, suctionStep)
    'results(0).Point : results(1).Points : results(2).Conditions
    Public Class Balance

        Structure Conditions
            Public ambient, suction, altitude As Double
            Public catalog_rating As Boolean
            Public hertz, voltage As Integer
            Public fan_file_name_1, fan_file_name_2 As String
            Public hp_1, hp_2 As Double
            'Public fanOperatingRPM As Decimal
        End Structure

        Structure Standard_Conditions
            Public ambient, suction, altitude As Double
            Public voltage As Integer
        End Structure

        Structure Balance_Point
            Public condensing_temp, td As Double
            Public capacity, condenser_capacity, coil_capacity As Double
            Public unit_kw, unit_amps, unit_eer As Double
            Public degreesSubcooling As Double
            Public SingleCompressorAmps As Double
            ' Public RequiresDemandCooling As Boolean
        End Structure

        Class Result
            Sub New()
                points = New List(Of Balance_Point)
            End Sub
            Public conditions As Conditions
            Public point As Balance_Point
            Public points As IList(Of Balance_Point)
            Public RequiresDemandCooling As Boolean

            '            Public TempCap As Decimal
        End Class

        Class Results : Inherits List(Of Result)
            Sub add(ByVal result As Balance.Result)
                MyBase.Add(result)
            End Sub
            Sub add(ByVal conditions As Conditions, ByVal point As Balance_Point, ByVal reqDemandCool As Boolean)
                For Each one In Me
                    If one.conditions.ambient = conditions.ambient _
                    AndAlso one.conditions.suction = conditions.suction Then
                        one.points.Add(point)
                        one.point = aggregate(one.points)
                        Exit Sub
                    End If
                Next

                Dim result = New Result()
                result.conditions = conditions
                result.RequiresDemandCooling = reqDemandCool
                result.point = point
                result.points.Add(point)
                ' result.TempCap = tempcap1
                MyBase.Add(result)
            End Sub

            Private Function aggregate(ByVal circuit_points As IList(Of Balance_Point)) As Balance_Point
                Dim unit_point As Balance_Point
                For Each circuit_point In circuit_points
                    unit_point.capacity += circuit_point.capacity
                    unit_point.condenser_capacity += circuit_point.condenser_capacity
                    unit_point.condensing_temp += circuit_point.condensing_temp
                    unit_point.td += circuit_point.td
                    unit_point.unit_amps += circuit_point.unit_amps
                    unit_point.unit_eer += circuit_point.unit_eer
                    unit_point.unit_kw += circuit_point.unit_kw
                    unit_point.coil_capacity += circuit_point.coil_capacity
                Next

                ' average
                unit_point.condensing_temp /= circuit_points.Count
                unit_point.td /= circuit_points.Count
                unit_point.unit_eer /= circuit_points.Count

                Return unit_point
            End Function
        End Class



        Sub New(ByVal compressor_repo As i_compressor_repository)
            repo = compressor_repo
        End Sub

        Function this(ByVal cu As Condensing_Unit, ByVal at As Standard_Conditions) As Result
            Dim conditions = map(at)
            conditions.hertz = 60
            ' ERICC
            conditions.catalog_rating = False
            '            conditions.catalog_rating = True
            conditions.fan_file_name_1 = FanIntel.SelectStandardFile(cu.circuits(0).fanID, at.altitude, cu.circuits(0).hp, 1)
            conditions.hp_1 = cu.circuits(0).hp
            If cu.number_of_circuits > 1 Then
                conditions.fan_file_name_2 = FanIntel.SelectStandardFile(cu.circuits(1).fanID, at.altitude, cu.circuits(1).hp, 1)
                conditions.hp_2 = cu.circuits(1).hp
            End If

            Dim r As Result = this(cu, conditions)

            Return r

        End Function

        Function this(ByVal model As String, ByVal at As Standard_Conditions) As Result
            Dim cu = New Repository().get_unit(model)

            Return this(cu, at)
        End Function

        Private Function map(ByVal standard_conditions As Standard_Conditions) As Conditions
            Dim conditions As Conditions
            conditions.altitude = standard_conditions.altitude
            conditions.ambient = standard_conditions.ambient
            conditions.suction = standard_conditions.suction
            conditions.voltage = standard_conditions.voltage
            Return conditions
        End Function

        Function this(ByVal cu As Condensing_Unit, ByVal at As Conditions) As Result
            Dim r As Results = this(cu, at, ambient_step:=0, ambient_num_steps:=0, suction_step:=0, skipMissingCOmpressorError:=True, constantReturnGasTemp:=cu.constantReturnGasTemp)
            If r.Count > 0 Then
                Return r(0)
            Else
                Return Nothing
            End If


        End Function

        Function this(ByVal cu As Condensing_Unit, ByVal at As Conditions, ByVal ambient_step As Integer, _
        ByVal ambient_num_steps As Integer, ByVal suction_step As Integer, ByVal skipMissingCOmpressorError As Boolean, ByVal constantReturnGasTemp As String) As Results
            Dim results = New Results()

            For i = 0 To cu.number_of_circuits - 1
                Dim conditions = at
                Dim circuit = cu.circuits(i)

                Dim compressor = repo.get_compressor(circuit.compressorMasterID, circuit.refrigerant, conditions.voltage, "Condenser", constantReturnGasTemp)
                If compressor Is Nothing OrElse compressor.MasterID Is Nothing Then
                    If Not String.IsNullOrEmpty(circuit.compressorMasterID) AndAlso circuit.compressorMasterID.ToLower = "choose" Then



                        ' If circuit.compressorMasterID = "ss" Then
                        Throw New rae.Data.NotFoundEx("Compressor for circuit " & i + 1 & ", " & circuit.refrigerant.value & " will not operate under the conditions specified.")
                        'Else
                        '    Throw New rae.Data.NotFoundEx("Please choose a compressor for circuit " & i + 1 & ", " & circuit.refrigerant.value)
                        '  End If



                    Else
                        If skipMissingCOmpressorError Then

                            Return results
                        Else
                            Throw New rae.Data.NotFoundEx("The compressor does not exist: " & circuit.compressorMasterID & ", " & circuit.refrigerant.value)
                        End If
                    End If
                End If
                Dim m_hz = If(conditions.hertz = 50, 0.83, 1)
                Dim m_catalog = If(conditions.catalog_rating, 0.05, 0)



                Dim fan_file_name = If(i = 0, conditions.fan_file_name_1, conditions.fan_file_name_2)
                Dim hp = If(i = 0, conditions.hp_1, conditions.hp_2)

                Dim fanCurveRPM As Decimal = New Repository().SelectFanCurveRPM(fan_file_name, hp)

                Dim spec = map(conditions, circuit, If(i = 0, conditions.fan_file_name_1, conditions.fan_file_name_2), fanCurveRPM)




                Dim ccClass As New Coil_Capacity

                Dim cc = ccClass.calculate(spec)


                'h1 = coil capacity; h2 = condenser capacity
                Dim pe, q, w, a, h1, h2, eer, td, tc As Double

                Dim singleCompressorAms As Double

                Dim nc = circuit.compressor_quantity
                Dim r = circuit.refrigerant
                Dim conditionRange = New condition_range()

                Dim range = If(ambient_step = 0, _
                                get_range_for_single_condition(conditions.suction, conditions.ambient), _
                                conditionRange.adjust_range_over_multiple_conditions(conditions.suction, suction_step, compressor.suctionMin, compressor.suctionMax, conditions.ambient, ambient_step, ambient_num_steps))

                Dim fanwatts = FanIntel.SelectWatts(fan_file_name, hp, conditions.hertz, If(i = 0, conditions.hp_1, conditions.hp_2))


                Dim isFanVariableSpeed As Boolean = New Repository().IsFanVariableSpeed(fan_file_name)

                Dim fanRPM As Decimal = circuit.fanOperatingRPM


                Dim df1 As New cofan


                Dim subcooling As Double

                'range.suction_high = 40
                'range.suction_low = 40
                'range.ambient_high = 95
                'range.ambient_low = 95


                Dim te = conditions.suction
                For te = range.suction_low To range.suction_high Step range.suction_step
                    For ta = range.ambient_low To range.ambient_high Step range.ambient_step




                        BalanceSystem(ta, tc, cc, ccClass, spec, h1, h2, te, w, nc, m_hz, singleCompressorAms, r, i, td, compressor, cu, q, a, fanRPM)
                        'BalanceSystemNewton(ta, tc, cc, ccClass, spec, h1, h2, te, w, nc, m_hz, singleCompressorAms, r, i, td, compressor, cu, q, a)


                        If isFanVariableSpeed Then
                            Dim sp As Decimal = ccClass.get_sp_from_cofan_based_on_fpi(ccClass.results, spec.fpi)
                            fanwatts = df1.GetFanPower(fan_file_name, 1, spec.fanOperatingRPM, fanCurveRPM)
                        End If





                        If circuit.has_subcooling Then

                            If cu.division = "CRI" Then
                                subcooling = cu.subcooling_temperature(td, RaeSolutions.Business.Division.CRI)
                            Else
                                subcooling = cu.subcooling_temperature(td, RaeSolutions.Business.Division.TSI)
                            End If




                        Else
                            subcooling = 0
                        End If

                        ' EricC
                        ' JAY asked me to use 1.333... for subcooling capacity factor on Bitzer units (404a, 507)
                        Dim m_subcool As Double


                        ' ericc 3/23/2016

                        ' If compressor.manufacturer.ToLower = "bitzer" AndAlso (r.value.ToLower = "r404a" Or r.value.ToLower = "r507") Then
                        'If (r.value.ToLower = "r404a" OrElse r.value.ToLower = "r507") Then
                        '    m_subcool = (subcooling - compressor.coef.SubCooling) / 1.3333333333 / 100
                        ' Else
                        m_subcool = (subcooling - compressor.coef.SubCooling) / r.sc / 100
                        '                            m_subcool = subcooling / r.sc / 100
                        'End If


                        'If compressor.manufacturer.ToLower = "bitzer" AndAlso (r.value.ToLower = "r404a" Or r.value.ToLower = "r507") Then
                        '    m_subcool = (subcooling) / 1.3333333333 / 100
                        'Else
                        '    m_subcool = (subcooling) / r.sc / 100
                        '    '                            m_subcool = subcooling / r.sc / 100
                        'End If


                        q = q + q * (m_subcool + m_catalog)



                        w = w + (circuit.fan_quantity * fanwatts * m_hz)
                        a = a + ((circuit.fan_quantity * fanwatts * m_hz) / conditions.voltage)

                        eer = q / w


                        ' 5/28/2015

                        If cu.division = "TSI" Then
                            q = Convert.BtuhToTons(q)
                            h2 = Convert.BtuhToTons(h2)
                        End If




                        conditions.ambient = ta
                        conditions.suction = te
                        Dim point As Balance_Point
                        point.condenser_capacity = h2
                        point.condensing_temp = tc
                        point.capacity = q
                        point.td = td

                        If (Not conditions.fan_file_name_1 Is Nothing AndAlso conditions.fan_file_name_1.ToUpper.Contains("OVERRIDE")) OrElse (Not conditions.fan_file_name_2 Is Nothing AndAlso conditions.fan_file_name_2.ToUpper.Contains("OVERRIDE")) Then

                            If Not String.IsNullOrWhiteSpace(conditions.hp_1) Then
                                point.unit_amps = a
                                point.unit_eer = eer
                                point.unit_kw = w / 1000

                            Else
                                point.unit_amps = 0
                                point.unit_eer = 0
                                point.unit_kw = 0
                            End If



                        Else
                            point.unit_amps = a
                            point.unit_eer = eer
                            point.unit_kw = w / 1000


                        End If




                        point.coil_capacity = cc
                        point.degreesSubcooling = subcooling

                        point.SingleCompressorAmps = singleCompressorAms

                        Dim requiredDemandCooling As Boolean = compressor.RequiresDemandCooling(conditions.suction, point.condensing_temp)
                        results.add(conditions, point, requiredDemandCooling)
                    Next
                Next
            Next

            Return results
        End Function


        Private Sub BalanceSystem(ByRef ta As Double, ByRef tc As Double, ByRef cc As Double, ByRef CCClass As Coil_Capacity, ByRef spec As Coil_Capacity.Spec, ByRef h1 As Double, ByRef h2 As Double, ByRef te As Double, ByRef w As Double, ByRef nc As Double, ByRef m_hz As Double, ByRef singleCompressorAms As Double, ByRef r As rae.solutions.refrigerant, ByRef i As Double, ByRef td As Double, ByRef compressor As compressor, ByRef cu As Condensing_Unit, ByRef q As Double, ByRef a As Double, ByRef fanOperatingRPM As Decimal)
            tc = ta + 1
            'blarg

            Dim polynomial = New compressor_polynomial()
            Dim TEMPCAP As Decimal



            Do
                If tc > 180 Then ' not converging
                    Exit Do
                End If
                tc = tc + 0.1




                cc = CCClass.RecalculateCapacityWithTD(spec, (tc - ta))  '  move to here
                h1 = (tc - ta) * cc




                Dim result = polynomial.calculate(r, compressor.coef, te, tc)
                q = result.q * nc * m_hz
                w = result.w * nc * m_hz
                a = result.a * nc

                q *= cu.circuits(i).CompressorCapacityMultiplier  ' Added 7/14/2016 per Jay and Jim.
                w *= cu.circuits(i).CompressorCapacityMultiplier  ' Added 7/14/2016 per Jay and Jim.
                a *= cu.circuits(i).CompressorCapacityMultiplier  ' Added 7/14/2016 per Jay and Jim.

                singleCompressorAms = result.a

                h2 = q + (3.415 * w)
                ' todo: user balance object used for chiller, balance.at(te,tc)
                ' todo: can everything below this be moved out of the loop? yes (ericc)
                ' todo: put subcooling in balance point so don't need to duplicate in ui


            Loop While (h1 < h2)
            td = tc - ta





            ' ''''' new code ericc
            'Dim vaporTemp As Decimal = System.Math.Min(tc + 65, 210)
            'Dim airflow As Decimal = CCClass.results(0).cfm_standard
            'Dim dllResult As CoilDLL.BasicCondenserCoilResult
            'dllResult = CoilDLL.BasicCondenserCoilRating(spec.TubeDiameter, spec.FinLength, spec.FinHeight, spec.RowsDeep, spec.fpi, airflow, tc, ta, vaporTemp, spec.CondFeeds, spec.CondPasses, spec.SubCoolerFeeds, spec.SubCoolerPasses, spec.refrigerant.toString, spec.altitude, rae.RaeSolutions.Business.Entities.Cofans.settings.buzz_file_path)
            'TEMPCAP = dllResult.Capacity

            ' '''''




            'MsgBox(TEMPCAP & " " & h1 & " " & h2)

        End Sub



        Private Sub BalanceSystemNewton2(ByRef ta As Double, ByRef tc As Double, ByRef cc As Double, ByRef CCClass As Coil_Capacity, ByRef spec As Coil_Capacity.Spec, ByRef h1 As Double, ByRef h2 As Double, ByRef te As Double, ByRef w As Double, ByRef nc As Double, ByRef m_hz As Double, ByRef singleCompressorAms As Double, ByRef r As rae.solutions.refrigerant, ByRef i As Double, ByRef td As Double, ByRef compressor As compressor, ByRef cu As Condensing_Unit, ByRef q As Double, ByRef a As Double)
            ' tc = ta + 1
            'blarg

            Dim TEMPCAP As Decimal


            Dim tryCount As Integer = 0

            Dim tc1 As Double ' = (180 + ta) / 2
            Dim tc2 As Double ' = tc1 + 0.1

            Dim v1 As Double, v2 As Double

            tc = (180 + ta) / 2

            Do
                tryCount += 1

                tc1 = tc - 0.05
                tc2 = tc + 0.05

                If tryCount > 100 Then ' not converging
                    Exit Do
                End If

                v1 = doB(ta, tc1, cc, CCClass, spec, h1, h2, te, w, nc, m_hz, singleCompressorAms, r, i, td, compressor, cu, q, a)
                v2 = doB(ta, tc2, cc, CCClass, spec, h1, h2, te, w, nc, m_hz, singleCompressorAms, r, i, td, compressor, cu, q, a)

                Dim slope As Double = (v2 - v1) / 0.1

                tc = tc - (v1 / slope)

            Loop While (v1 > 0.01)
            td = tc - ta





            ''''' new code ericc
            Dim vaporTemp As Decimal = System.Math.Min(tc + 65, 210)
            Dim airflow As Decimal = CCClass.results(0).cfm_standard
            Dim dllResult As CoilDLL.BasicCondenserCoilResult
            dllResult = CoilDLL.BasicCondenserCoilRating(spec.TubeDiameter, spec.FinLength, spec.FinHeight, spec.RowsDeep, spec.fpi, airflow, tc, ta, vaporTemp, spec.CondFeeds, spec.CondPasses, spec.SubCoolerFeeds, spec.SubCoolerPasses, spec.refrigerant.toString, spec.altitude, rae.RaeSolutions.Business.Entities.Cofans.settings.buzz_file_path)
            TEMPCAP = dllResult.Capacity

            '''''




            MsgBox(TEMPCAP & " " & h1 & " " & h2)




        End Sub

        Private Function doB(ByRef ta As Double, ByRef tc As Double, ByRef cc As Double, ByRef CCClass As Coil_Capacity, ByRef spec As Coil_Capacity.Spec, ByRef h1 As Double, ByRef h2 As Double, ByRef te As Double, ByRef w As Double, ByRef nc As Double, ByRef m_hz As Double, ByRef singleCompressorAms As Double, ByRef r As rae.solutions.refrigerant, ByRef i As Double, ByRef td As Double, ByRef compressor As compressor, ByRef cu As Condensing_Unit, ByRef q As Double, ByRef a As Double) As Double
            Dim polynomial = New compressor_polynomial()
            '    tc = tc + 0.1


            cc = CCClass.RecalculateCapacityWithTD(spec, (tc - ta))  '  move to here
            h1 = (tc - ta) * cc
            Dim result = polynomial.calculate(r, compressor.coef, te, tc)
            q = result.q * nc * m_hz
            w = result.w * nc * m_hz
            a = result.a * nc

            q *= cu.circuits(i).CompressorCapacityMultiplier  ' Added 7/14/2016 per Jay and Jim.
            w *= cu.circuits(i).CompressorCapacityMultiplier  ' Added 7/14/2016 per Jay and Jim.
            a *= cu.circuits(i).CompressorCapacityMultiplier  ' Added 7/14/2016 per Jay and Jim.

            singleCompressorAms = result.a

            h2 = q + (3.415 * w)

            Return System.Math.Abs(h2 - h1)

        End Function




        Private Function renameMeReturnDelta(ByRef singleCompressorAms As Single, ByRef cc As Single, ByRef ccClass As Coil_Capacity, ByRef ta As Single, ByRef te As Single, ByRef h1 As Single, ByRef h2 As Single, ByRef q As Single, ByRef tdguess As Single, ByRef nc As Single, ByRef m_hz As Single, ByRef spec As Coil_Capacity.Spec, ByRef polynomial As compressor_polynomial, ByRef compressor As compressors.compressor, ByRef w As Single, ByRef a As Single, ByRef r As refrigerant) As Single



            cc = ccClass.RecalculateCapacityWithTD(spec, (tdguess - ta))  '  move to here

            h1 = (tdguess - ta) * cc
            Dim result = polynomial.calculate(r, compressor.coef, te, tdguess)
            q = result.q * nc * m_hz
            w = result.w * nc * m_hz
            a = result.a * nc

            singleCompressorAms = result.a

            h2 = q + (3.415 * w)

            renameMeReturnDelta = h2 - h1


        End Function


        Private repo As i_compressor_repository

        Private Function get_range_for_single_condition(ByVal suction, ByVal ambient) As condition_range.range
            Dim range As condition_range.range
            range.suction_low = suction
            range.suction_high = suction
            range.suction_step = 1
            range.ambient_low = ambient
            range.ambient_high = ambient
            range.ambient_step = 1
            Return range
        End Function

        Private Function map(ByVal conditions As Conditions, ByVal circuit As Circuit, ByVal fan_file_name As String, ByVal fanCurveRPM As Decimal) As Coil_Capacity.Spec
            Dim spec As Coil_Capacity.Spec

            spec.fan_file_name = fan_file_name
            spec.altitude = conditions.altitude
            ' spec.coil_file_name = circuit.coil.rows & "RCOND"


            spec.fanOperatingRPM = circuit.fanOperatingRPM
            spec.fanCurveRPM = fanCurveRPM


            Dim cf As New cofan_repository

            If circuit.coil.FinSurface Is Nothing OrElse circuit.coil.TubeSurface Is Nothing Then
                spec.coil_file_name = cf.getCoilFilename(circuit.coil.TubeDiameter, circuit.coil.RowsDeep, "Waffle", "Smooth")
            Else
                spec.coil_file_name = cf.getCoilFilename(circuit.coil.TubeDiameter, circuit.coil.RowsDeep, circuit.coil.FinSurface, circuit.coil.TubeSurface)
            End If






            spec.FinLength = circuit.coil.FinLength
            spec.FinHeight = circuit.coil.FinHeight
            spec.fpi = circuit.coil.FPI
            spec.fan_qty = circuit.fan_quantity
            spec.refrigerant = circuit.refrigerant
            spec.subcooling_is_required = circuit.has_subcooling
            spec.subcooling_percentage = circuit.subcooling


            spec.tubeSurface = circuit.coil.TubeSurface


            If circuit.coil.UseDLLForPerformance Then
                spec.UseDLLForPerformance = circuit.coil.UseDLLForPerformance
                spec.CondFeeds = circuit.coil.CondFeeds
                spec.CondPasses = circuit.coil.CondPasses
                spec.SubCoolerFeeds = circuit.coil.SubCoolerFeeds
                spec.SubCoolerPasses = circuit.coil.SubCoolerPasses
                spec.FinSurface = circuit.coil.FinSurface
                spec.FinMaterial = circuit.coil.FinMaterial
                spec.FinThickness = circuit.coil.FinThickness
                spec.tubeSurface = circuit.coil.TubeSurface
                spec.TubeMaterial = circuit.coil.TubeMaterial
                spec.TubeThickness = circuit.coil.TubeThickness
                spec.TubeDiameter = circuit.coil.TubeDiameter
                spec.RowsDeep = circuit.coil.RowsDeep
            Else
            End If





            Return spec
        End Function

    End Class

    Class condition_range
        Structure range
            Public ambient_high, ambient_low, ambient_step As Double
            Public suction_high, suction_low, suction_step As Double
        End Structure

        Function adjust_range_over_multiple_conditions( _
           ByVal suction, ByVal suction_step, ByVal suction_min, ByVal suction_max, _
           ByVal ambient, ByVal ambient_step, ByVal ambientnum_steps _
        ) As range

            ' suction
            Dim sl = suction - suction_step
            Dim sh = suction + (2 * suction_step)
            Dim sstep = suction_step
            Dim smin = suction_min
            Dim smax = suction_max

            'If sl < smin And sh > smax Then
            '    sstep = CInt((smax - smin) / 3) 'override
            '    sl = smin
            '    sh = smin + (3 * sstep)
            'Else
            '    If sl < smin Then
            '        sl = smin
            '        sh = smin + (3 * sstep)
            '    ElseIf sh > smax Then
            '        sl = smax - (3 * sstep)
            '        sh = smax
            '    End If
            'End If

            If sl < smin And sh > smax Then
                sstep -= 1
                If sstep < 0 Then
                    ' this should never happen since with a step of 1 and a fixed interval of 4, the compressor would need to have a range of like 4.
                    Throw New Exception("Could not find sunction interval within the operation range of the compressor")
                End If
                sl = suction - sstep
                sh = suction + (2 * sstep)
            End If

            If sl < smin Then
                While sl < smin
                    sl += sstep
                End While
                sh = sl + (3 * sstep)
            ElseIf sh > smax Then
                While sh > smax
                    sh -= sstep
                End While
                sl = sh - (3 * sstep)
            End If






            ' ambient
            Dim a = ambient
            Dim astep = ambient_step
            Dim anum = ambientnum_steps
            Dim al, ah As Double

            If anum = 5 Then
                al = a - (2 * astep)
                ah = a + (astep * 2)
            End If

            If anum = 4 Then
                al = a - (2 * astep)
                ah = a + astep
            End If

            If anum = 3 Then
                al = a - astep
                ah = a + astep
            End If

            Dim range As range
            range.ambient_high = ah
            range.ambient_low = al
            range.ambient_step = astep
            range.suction_high = sh
            range.suction_low = sl
            range.suction_step = sstep

            Return range
        End Function
    End Class

End Namespace