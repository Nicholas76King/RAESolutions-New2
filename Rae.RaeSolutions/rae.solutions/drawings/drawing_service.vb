Option Strict Off

Imports System.Math
Imports rae.math.Calculate
Imports rae.math.comparisons
Imports rae.Io.Text
Imports rae.utilities
Imports rae.validation
Imports rae.RaeSolutions.Business
Imports rae.RaeSolutions.Business.Entities

Namespace rae.solutions.drawings

    Class drawing_service : Implements i_drawing_service
        Private repo As i_drawing_repository

        Sub New()
            repo = New drawing_repository()
        End Sub

        Function get_condenser(ByVal model As String) As condensers.condenser _
        Implements i_drawing_service.get_condenser
            model = format_condenser_model_with_dash(model)
            Return condensers.condenser_repository.RetrieveCondenser(model)
        End Function

        Function get_unit_cooler_electrical_info(ByVal unit As unit_cooler) As unit_cooler_electrical_info _
        Implements i_drawing_service.get_unit_cooler_electrical_info
            ' todo: merge common specs type into equipment type (too long)

            Dim model = New rae.solutions.unit_coolers.database_formatter().format_model(unit.model, unit.refrigerant)
            Dim data = repo.get_unit_cooler_electrical_data(model)

            Dim model_is_in_database = New unit_cooler_model_is_in_database(data.model_is_in_database, model).validate()
            If model_is_in_database.is_invalid Then
                'electrical info when model is not in database
                Dim e = New unit_cooler_electrical_info()
                e.validators.add(model_is_in_database)
                e.model_is_in_database = False
                Return e
            End If

            Dim fan_amps = select_fan_amps(unit.fan_voltage.voltage.value, unit.fan_voltage.phase.value, data)

            Dim heater_amps = calculate_defrost_heater_amps(unit, data)
            Dim electrical_info = smoosh_electrical_info_into_an_object(unit, data, fan_amps, heater_amps:=heater_amps)
            electrical_info.validators.add(New unit_cooler_fan_amps_are_available(fan_amps, electrical_info.fan_voltage, model))

            Return electrical_info
        End Function

#Region " unit cooler electrical info"

        Private Function calculate_defrost_heater_amps(ByVal unit_cooler As unit_cooler, ByVal data As unit_cooler_electrical_data) As Double
            Dim heater_amps As Double

            Dim voltage = unit_cooler.defrost_voltage.voltage.value_or_default()
            Dim phase = unit_cooler.defrost_voltage.phase.value_or_default

            Select Case voltage
                Case 230
                    If phase = 1 Then
                        heater_amps = data.heater_amps_230v_1ph
                    ElseIf phase = 3 Then
                        heater_amps = data.heater_amps_230v_3ph
                    End If
                Case 460
                    If phase = 1 Then
                        heater_amps = data.heater_amps_460v_1ph
                    ElseIf phase = 3 Then
                        heater_amps = data.heater_amps_460v_3ph
                    End If
                Case 575
                    If phase = 1 Then
                        heater_amps = data.heater_amps_575v_1ph
                    ElseIf phase = 3 Then
                        heater_amps = data.heater_amps_575v_3ph
                    End If
            End Select

            Return heater_amps
        End Function

        Private Function select_fan_amps(ByVal fan_voltage As Double, ByVal fan_phase As Double, ByVal electrical_data As unit_cooler_electrical_data) As Double 'unit_cooler as UnitCoolerEquipmentItem, data as UnitCoolerElectricalData) as double
            Dim fan_amps As Double

            Select Case fan_voltage
                Case 115
                    If fan_phase = 1 Then fan_amps = electrical_data.motor_amps_115v_1ph
                Case 208, 230
                    If fan_phase = 1 Then
                        fan_amps = electrical_data.motor_amps_230v_1ph
                    ElseIf fan_phase = 3 Then
                        If fan_voltage = 208 Then
                            fan_amps = electrical_data.motor_amps_208v_3ph
                        Else
                            fan_amps = electrical_data.motor_amps_230v_3ph
                        End If
                    End If
                Case 460
                    If fan_phase = 1 Then
                        fan_amps = electrical_data.motor_amps_460v_1ph
                    ElseIf fan_phase = 3 Then
                        fan_amps = electrical_data.motor_amps_460v_3ph
                    End If
                Case 575
                    If fan_phase = 1 Then
                        fan_amps = electrical_data.motor_amps_575v_1ph
                    ElseIf fan_phase = 3 Then
                        fan_amps = electrical_data.motor_amps_575v_3ph
                    End If
            End Select


            If fan_amps = 0 Then  ' get fan amps from motors database.  This is the prefered method once the data is cleaned up.



                Select Case fan_voltage
                    Case 115
                        If fan_phase = 1 Then fan_amps = repo.GetFanAmps(electrical_data.One_ph_115volt_mtr_part_number, fan_voltage)
                    Case 208, 230
                        If fan_phase = 1 Then
                            fan_amps = repo.GetFanAmps(electrical_data.One_ph_230volt_mtr_part_number, fan_voltage)
                        ElseIf fan_phase = 3 Then
                            fan_amps = fan_amps = repo.GetFanAmps(electrical_data.One_ph_230volt_mtr_part_number, fan_voltage)
                        End If
                    Case 460
                        If fan_phase = 1 Then
                            fan_amps = repo.GetFanAmps(electrical_data.One_ph_230volt_mtr_part_number, 230)
                            fan_amps = fan_amps * (230 / 460)
                        ElseIf fan_phase = 3 Then
                            fan_amps = repo.GetFanAmps(electrical_data.Three_ph_mtr_part_number, 230)
                            fan_amps = fan_amps * (230 / 460)
                        End If
                    Case 575
                        If fan_phase = 1 Then
                            fan_amps = repo.GetFanAmps(electrical_data.Three_ph_mtr_part_number, 230)
                            fan_amps = fan_amps * (230 / 570)
                        ElseIf fan_phase = 3 Then
                            fan_amps = repo.GetFanAmps(electrical_data.Three_ph_mtr_part_number, 230)
                            fan_amps = fan_amps * (230 / 575)
                        End If
                End Select



            End If


            Return fan_amps
        End Function


        Private Function smoosh_electrical_info_into_an_object(ByVal unit_cooler As unit_cooler, ByVal data As unit_cooler_electrical_data,
                                                               ByVal fan_amps As Double, ByVal heater_amps As Double) As unit_cooler_electrical_info
            Dim info = New unit_cooler_electrical_info()
            info.model_is_in_database = True
            info.fan_quantity = data.fan_quantity
            info.fan_blocks = 1
            info.fan_voltage = unit_cooler.fan_voltage.voltage.value

            Dim fan_amps_each As Double
            If data.fan_quantity > 0 Then
                info.fan_quantity = data.fan_quantity
                If fan_amps > 0 AndAlso info.fan_quantity > 0 Then
                    fan_amps_each = Round(fan_amps / info.fan_quantity, 2)
                End If
            End If

            info.fan_motor_amps = fan_amps_each

            If unit_cooler.model.EndsWith("E") Then
                info.defrost_voltage = unit_cooler.defrost_voltage.voltage.value
                info.defrost_heater_watts = data.heater_watts

                If heater_amps > 48 Then
                    info.defrost_blocks = ceiling(heater_amps / 48)
                    info.defrost_heater_amps = round(heater_amps / Val(info.defrost_blocks), 2)
                ElseIf heater_amps > 0 Then
                    info.defrost_blocks = 1
                    info.defrost_heater_amps = round(heater_amps, 2)
                End If
            End If

            info.sccr_1 = 10
            info.sccr_2 = 10
            info.sccr_3 = 10

            Return info
        End Function

#End Region

        'function get_evaporative_condenser_chiller_electrical_info(spec as rae.solutions.evaporative_condenser_chillers.electrical_data) as ChillerElectricalInfo _
        'implements IDrawingService.get_evaporative_condenser_chiller_electrical_info
        '   ''dim chiller = new rae.solutions.evaporative_condenser_chillers.repository().get(spec.model, spec.voltage)
        '   'dim electrical_info = repo.get_evaporative_condenser_chiller(spec.model, spec.voltage)
        '   'dim compressor_amps_1 = repo.GetCompressorAmps(spec.compressor_file_name_1, spec.unit_type, spec.voltage, spec.phase, spec.hertz)
        '   'dim compressor_amps_2 = repo.GetCompressorAmps(spec.compressor_file_name_2, spec.unit_type, spec.voltage, spec.phase, spec.hertz)

        '   'if compressor_amps_1 = 0
        '   '   dim info_na as ChillerElectricalInfo
        '   '   info_na.Rla1 = 0
        '   '   info_na.Mca1 = 0
        '   '   info_na.MaxFuseSize1 = 0
        '   '   info_na.Sccr1 = 0
        '   '   return info_na
        '   'end if

        '   'dim c1 = compressor_amps_1
        '   'dim cq1 = spec.compressor_quantity_1
        '   'dim c2 = compressor_amps_2
        '   'dim cq2 = spec.compressor_quantity_2

        '   'dim calc = new rae.solutions.evaporative_condenser_chillers.electrical_calculator()
        '   'dim rla = calc.rla(c1, cq1, c2, cq2, b,p, condq)
        '   'dim mca = calc.mca(c, rla)

        '   'dim info as ChillerElectricalInfo
        '   'if mca > 380
        '   '   info.Rla1
        '   'else
        '   '   info.Rla1 = rla
        '   '   info.Mca1 = mca
        '   '   info.MaxFuseSize1 = calc.fuse(mop)
        '   '   info.Sccr1 = 5
        '   'end if

        'end function

        Function GetChillerElectricalInfo(ByVal spec As chiller_electrical_spec, ByVal model_type As String) As chiller_electrical_info _
   Implements i_drawing_service.GetChillerElectricalInfo
            ' assumption: calculations are for 30A2s
            ' assumption: same compressor and quantity on each circuit
            Dim chiller = repo.GetChiller(spec.model)

            Dim c = getCompressorAmps(chiller.compressor_file_1, spec, "TSI")

            If c = 0 Then
                Dim e_na As chiller_electrical_info
                e_na.rla_1 = 0
                e_na.mca_1 = 0
                e_na.max_fuse_size_1 = 0
                e_na.sccr_1 = 0
                e_na.number_of_circuits = chiller.number_of_circuits
                Return e_na
            End If

            Dim motorPartNum = selectMotorPartNum(spec.phase, chiller)

            Dim v = spec.voltage
            Dim f = repo.GetFanAmps(motorPartNum, v)
            Dim fq = chiller.fan_quantity_1 * chiller.coil_qty1
            Dim cq = chiller.compressor_quantity_1


            Dim Number_ref_circuits_1 As Double = chiller.Number_ref_circuits_1
            Dim Number_ref_circuits_2 As Double = chiller.Number_ref_circuits_2

            If Not IsNumeric(Number_ref_circuits_1) Then Number_ref_circuits_1 = 1
            If Not IsNumeric(Number_ref_circuits_2) Then Number_ref_circuits_2 = 1


            Dim c2, cq2, fq2 As Double
            If chiller.number_of_circuits > 1 Then
                c2 = c
                cq2 = cq
                fq2 = fq
            End If

            Dim calc = New chiller_ecalc()

            Dim p As Double
            Dim pp = spec.pump_package
            If pp IsNot Nothing Then
                Dim hp = repo.GetPumpPackageHp(pp.Manufacturer, pp.Flow.value, pp.Head.value, pp.System)
                p = repo.GetPumpPackageMotorAmps(hp, v)
            End If

            Dim et02 = spec.et02 : Dim division = spec.division
            Dim rla = calc.rla(c, cq, f, fq, c2, cq2, f, fq2, p, v, et02, division)
            '            Dim rla = calc.rla(c, cq, f, fq * Number_ref_circuits_1, c2, cq2, f, fq2 * Number_ref_circuits_2, p, v, et02, division)
            Dim mca = calc.mca(c, rla)

            Dim e As chiller_electrical_info
            If mca > 380 Then ' split circuit
                'Dim rla1 = calc.rla1(c, cq, c2, cq2, f, fq * Number_ref_circuits_1, f * Number_ref_circuits_2, fq2, p, v, et02, division)
                'Dim rla2 = calc.rla2(c, cq, c2, cq2, f, fq * Number_ref_circuits_1, f * Number_ref_circuits_2, fq2) 'c/2 + f/2

                Dim rla1 = calc.rla1(c, cq, c2, cq2, f, fq, f, fq2, p, v, et02, division)
                Dim rla2 = calc.rla2(c, cq, c2, cq2, f, fq, f, fq2) 'c/2 + f/2


                e.rla_1 = rla1
                e.rla_2 = rla2
                e.mca_1 = calc.mca(c, rla1)
                e.mca_2 = calc.mca(c, rla2)
                Dim mop1 = calc.mop(c, rla1)
                Dim mop2 = calc.mop(c, rla2)
                e.sccr_1 = 5
                e.sccr_2 = 5
                e.max_fuse_size_1 = calc.fuse(mop1)
                e.max_fuse_size_2 = calc.fuse(mop2)
                e.number_of_circuits = chiller.number_of_circuits
            Else
                Dim mop = calc.mop(c, rla)
                e.rla_1 = rla
                e.mca_1 = mca
                e.max_fuse_size_1 = calc.fuse(mop)
                e.sccr_1 = 5
            End If

            Return e
        End Function

        Function GetCondenserElectricalInfo(ByVal model As String, ByVal voltage As Integer) As condenser_electrical_info _
        Implements i_drawing_service.GetCondenserElectricalInfo
            Dim dbModel = format_condenser_model_with_dash(model)
            Dim condenser = repo.GetCondenser(dbModel)
            Dim f As Double
            '  we()
            Select Case voltage
                Case 575
                    f = repo.GetFanAmps(condenser.motor_part_number575, voltage)
                Case Else
                    f = repo.GetFanAmps(condenser.motor_part_number230460, voltage)
            End Select


            Dim fq = condenser.fan_quantity

            Dim calc = New cond_ecalc()
            Dim e As condenser_electrical_info

            e.rla = calc.rla(f, fq, voltage)
            e.mca = calc.mca(f, e.rla)
            Dim mop = calc.mop(f, e.rla)
            e.fuse = calc.fuse(mop)
            e.sccr = 5

            Return e
        End Function

        'function get_condenser_connection_sizes(model as string) as rae.solutions.condensers.condenser

        'end function

        Function GetCondensingUnitElectricalInfo( _
           ByVal model As String, ByVal voltage As Integer, ByVal phase As Integer, ByVal hertz As Integer, _
           ByVal et10 As Boolean, ByVal mc20 As Boolean, ByVal division As Division) _
        As condensing_unit_electrical_info Implements i_drawing_service.GetCondensingUnitElectricalInfo
            Dim cu = repo.GetCondensingUnit(model, phase, voltage)

            Dim sDivision As String
            If division = RaeSolutions.Business.Division.CRI Then
                sDivision = "CENTURY"
            Else
                sDIVISION = "TSI"
            End If

            Dim unitType = "CondensingUnit"
            Dim c1 = repo.GetCompressorAmps(cu.compressorMasterID1, unitType, voltage, phase, hertz, sDivision)
            Dim c2 = repo.GetCompressorAmps(cu.compressorMasterID2, unitType, voltage, phase, hertz, sDivision)
            Dim f1 = repo.GetFanAmps(cu.motor_part_number, voltage)
            Dim f2 = f1
            Dim v = voltage

            Dim cq1 = cu.compressor_quantity_1
            Dim cq2 = cu.compressor_quantity_2
            Dim fq1 = cu.fan_quantity_1
            Dim fq2 = cu.fan_quantity_2

            Dim calc = New cu_ecalc()
            Dim e As condensing_unit_electrical_info
            e.circuits = cu.circuits

            If mc20 Then
                e.rla1 = calc.rla(c1, cq1, f1, fq1, _
                                   c2, cq2, f2, fq2, et10, v, division)
                Dim lc = If(c1 > c2, c1, c2)
                e.mca1 = calc.mca(lc, e.rla1)
                Dim mop = calc.mop(lc, e.rla1)
                e.fuse1 = calc.fuse(mop)
            Else
                e.rla1 = calc.rla(c1, cq1, f1, fq1, et10, v, division)
                e.mca1 = calc.mca(c1, e.rla1)
                Dim mop = calc.mop(c1, e.rla1)
                e.fuse1 = calc.fuse(mop)

                'e.rla1 = System.Math.Ceiling(e.rla1)
                'e.mca1 = System.Math.Ceiling(e.mca1)

                e.rla1 = System.Math.Round(e.rla1, 1)
                e.mca1 = System.Math.Round(e.mca1, 1)


            End If

            If e.circuits > 1 And Not mc20 Then
                e.rla2 = calc.rla(c2, cq2, f2, fq2, et10, v, division)
                e.mca2 = calc.mca(c2, e.rla2)
                Dim mop = calc.mop(c2, e.rla2)
                e.fuse2 = calc.fuse(mop)

                'e.rla2 = System.Math.Ceiling(e.rla2)
                'e.mca2 = System.Math.Ceiling(e.mca2)

                e.rla2 = System.Math.Round(e.rla2, 1)
                e.mca2 = System.Math.Round(e.mca2, 1)


            End If
            e.sccr1 = 5
            e.sccr2 = 5

            e.compAmps1 = System.Math.Round(c1, 1)
            e.compAmps2 = System.Math.Round(c2, 1)

            Return e
        End Function

        Function GetPumpPackageElectricalInfo(ByVal pp As PumpEquipment) As pump_package_electrical_info _
        Implements i_drawing_service.GetPumpPackageElectricalInfo
            Dim voltage = pp.common_specs.UnitVoltage.Voltage.value
            Dim hp = repo.GetPumpPackageHp(pp.Manufacturer, pp.Flow.value, pp.Head.value, pp.System)
            Dim p = repo.GetPumpPackageMotorAmps(hp, voltage)
            Dim pq = 1 ' second pump would be stand-by, only one pump runs at a time

            Dim e As pump_package_electrical_info
            Dim calc = New pp_ecalc()
            Dim rla = calc.rla(p, pq)
            Dim mop = calc.mop(p, rla)
            e.rla = rla
            e.mca = calc.mca(p, rla)
            e.sccr = 5
            e.max_fuse_size = calc.fuse(mop)

            Return e
        End Function

        Function GetPumpPackageConnectionSize(ByVal manufacturer As String, ByVal flow As Double, ByVal head As Double, ByVal system As PumpSystem) As String _
        Implements i_drawing_service.GetPumpPackageConnectionSize
            Return repo.GetPumpPackageConnectionSize(manufacturer, flow, head, system)
        End Function

        Function GetChillerConnectionSizes(ByVal chiller As chiller_equipment) As ConnectionSize _
        Implements i_drawing_service.GetChillerConnectionSizes
            Dim connectionSize = repo.GetChillerConnectionSizes(chiller.model)

            If chiller.model Like "30A2*" And chiller.has_pump_package Then
                Dim flow = chiller.pump_package.Flow.value
                Dim head = chiller.pump_package.Head.value
                Dim manufacturer = chiller.pump_package.Manufacturer
                Dim system = chiller.pump_package.System
                Dim size = GetPumpPackageConnectionSize(manufacturer, flow, head, system)
                connectionSize.Inlet = size
                connectionSize.Outlet = size
            End If

            Return connectionSize
        End Function

        Function GetCondensingUnitConnectionSizes(ByVal model As String, ByVal mc20 As Boolean) As List(Of ConnectionSize) _
        Implements i_drawing_service.GetCondensingUnitConnectionSizes
            Dim sizes = New List(Of ConnectionSize)
            Dim connectionSizes = repo.GetCondensingUnitConnectionSizes(model)
            If mc20 Then
                Dim size As ConnectionSize
                size.Inlet = connectionSizes.Suction
                size.Outlet = connectionSizes.Liquid
                sizes.Add(size)
            Else
                Dim size1 As ConnectionSize
                size1.Inlet = connectionSizes.Suction1
                size1.Outlet = connectionSizes.Liquid1
                sizes.Add(size1)
                Dim size2 As ConnectionSize
                size2.Inlet = connectionSizes.Suction2
                size2.Outlet = connectionSizes.Liquid2
                sizes.Add(size2)

                Dim size3 As ConnectionSize
                size3.Inlet = connectionSizes.suction3
                size3.Outlet = connectionSizes.liquid3
                sizes.Add(size3)
                Dim size4 As ConnectionSize
                size4.Inlet = connectionSizes.suction4
                size4.Outlet = connectionSizes.liquid4
                sizes.Add(size4)

            End If

            Return sizes
        End Function

        Private Function format_condenser_model_with_dash(ByVal model As String) As String
            If model.StartsWith("10A0") Then _
               model = model.Insert(4, "-")

            Return model
        End Function

        Private Function selectMotorPartNum(ByVal phase As Integer, ByVal chiller As chiller_electrical_data) As String
            Dim motorPartNum As String
            If phase = 1 Then
                motorPartNum = chiller.motor_part_number_1_phase
            ElseIf phase = 3 Then
                motorPartNum = chiller.motor_part_number_3_phase
            Else
                Throw New ArgumentException("Phase is invalid. Phase = " & phase)
            End If
            Return motorPartNum
        End Function

        Private Function getCompressorAmps(ByVal compressorFile As String, ByVal spec As chiller_electrical_spec, ByVal division As String) As Double
            Return repo.GetCompressorAmps(compressorFile, spec.unit_type, spec.voltage, spec.phase, spec.hertz, division)
        End Function

    End Class

End Namespace