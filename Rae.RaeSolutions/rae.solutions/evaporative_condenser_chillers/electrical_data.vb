Imports rae.RaeSolutions.Business
Imports rae.RaeSolutions.Business.Entities

Namespace rae.solutions.evaporative_condenser_chillers

    Public Class electrical_data

        Structure electrical_circuit
            Public rla, mca, max_fuse_size, sccr As Double
        End Structure





        Sub New(ByVal chiller As chiller_equipment)
            Dim input As electrical_input

            If chiller.has_balance Then
                input.electrical_data = chiller.balance_data
            Else
                Dim voltage = chiller.common_specs.unitVoltage.voltage.value
                Dim phase = chiller.common_specs.unitVoltage.phase.value
                Dim hertz = chiller.common_specs.unitVoltage.hertz.value
                input.electrical_data = get_electrical_data_for_standard_unit(chiller.model, voltage, phase, hertz)
            End If

            input.et02 = chiller.options.contains("ET02")
            input.voltage = chiller.common_specs.unitVoltage.voltage.value
            input.division = chiller.division

            calculate(input)
        End Sub


        Function circuit_1() As electrical_circuit
            Return circuits(0)
        End Function

        Public ReadOnly circuits As New list(Of electrical_circuit)


        Private Function get_electrical_data_for_standard_unit(ByVal model As String, ByVal voltage As Integer, ByVal phase As Integer, ByVal hertz As Integer) As balance_data
            Dim repository = New repository()
            Dim compressor_repository = New rae.solutions.compressors.compressor_repository()
            Dim service = New service(compressor_repository, repository)
            Dim standard = service.get(model, voltage)
            Dim unit_type = "EvaporativeCondenserChiller"

            Dim e As balance_data
            e.compressor_amps_1 = compressor_repository.get_compressor_amps(standard.circuits(0).compressor.MasterID, unit_type, voltage, phase, hertz, "TSI")
            e.compressor_quantity_1 = standard.circuits(0).compressor_qty
            e.condenser_quantity = standard.condenser_quantity

            Dim motor_repository = New rae.solutions.motors.repository()
            e.spray_pump_amps = motor_repository.get_amps(standard.condenser.pump_hp, voltage)
            e.blower_amps = motor_repository.get_amps(standard.condenser.fan_hp, voltage)
            If standard.num_circuits > 1 Then
                e.compressor_amps_2 = compressor_repository.get_compressor_amps(standard.circuits(1).compressor.MasterID, unit_type, voltage, phase, hertz, "TSI")
                e.compressor_quantity_2 = standard.circuits(1).compressor_qty
            End If

            Return e
        End Function

        Private Sub calculate(ByVal input As electrical_input)
            Dim e = input.electrical_data

            Dim calc = New rae.solutions.evaporative_condenser_chillers.electrical_calculator()
            Dim rla = calc.rla(e.compressor_amps_1, e.compressor_quantity_1, _
                               e.compressor_amps_2, e.compressor_quantity_2, _
                               e.blower_amps, e.spray_pump_amps, e.condenser_quantity, _
                               input.voltage, input.et02, input.division)
            Dim largest_compressor_amps = If(e.compressor_amps_1 > e.compressor_amps_2, e.compressor_amps_1, e.compressor_amps_2)
            Dim mca = calc.mca(largest_compressor_amps, rla)
            Dim mop = calc.mop(largest_compressor_amps, rla)
            Dim max_fuse_size = calc.fuse(mop)

            Dim circuit_1 As electrical_circuit
            circuit_1.rla = rla
            circuit_1.mca = mca
            circuit_1.max_fuse_size = max_fuse_size
            circuit_1.sccr = 5

            If mca > 380 And e.compressor_amps_2 > 0 Then
                Dim rla_1 = calc.rla_1(e.compressor_amps_1, e.compressor_quantity_1, _
                                       e.compressor_amps_2, e.compressor_quantity_2, _
                                       e.blower_amps, e.spray_pump_amps, e.condenser_quantity, _
                                       input.voltage, input.et02, input.division)

                Dim mop_1 = calc.mop(largest_compressor_amps, rla_1)

                circuit_1.max_fuse_size = calc.fuse(mop_1)
                circuit_1.rla = rla_1
                circuit_1.mca = calc.mca(largest_compressor_amps, rla_1)
                circuit_1.sccr = 5
                Me.circuits.add(circuit_1)

                Dim circuit_2 As electrical_circuit
                Dim rla_2 = calc.rla_2(e.compressor_amps_1, e.compressor_quantity_1, _
                                       e.compressor_amps_2, e.compressor_quantity_2, _
                                       e.blower_amps, e.spray_pump_amps, e.condenser_quantity)
                Dim mop_2 = calc.mop(largest_compressor_amps, rla_2)
                circuit_2.rla = rla_2
                circuit_2.mca = calc.mca(largest_compressor_amps, rla_2)
                circuit_2.max_fuse_size = calc.fuse(mop_2)
                circuit_2.sccr = 5

                Me.circuits.add(circuit_2)
            Else
                Me.circuits.add(circuit_1)
            End If
        End Sub

        Private Structure electrical_input
            Public voltage As Integer
            Public et02 As Boolean
            Public division As Rae.RaeSolutions.Business.Division
            Public electrical_data As balance_data
        End Structure

    End Class

End Namespace