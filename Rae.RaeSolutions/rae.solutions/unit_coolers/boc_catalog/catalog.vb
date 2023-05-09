Imports rae.solutions.cu_uc_balances
Imports System.Collections
Imports System.Data
Imports System.Reflection.BindingFlags
Imports t1 = RAE.Solutions.unit_coolers.boc_catalog.unit_cooler_display_table

Namespace rae.solutions.unit_coolers.boc_catalog

    Public Class catalog
        Sub New(ByVal repository As repository, ByVal series As String)
            Dim bocs = repository.get_by_series(series)
            bocs.sort()

            Dim converter = New unit_coolers_to_table()
            table = converter.convert(bocs)
        End Sub

        Public table As data_table
    End Class


    Interface i_convert(Of t, u)
        Function convert(ByVal item As t) As u
    End Interface

    Public Class unit_cooler_display_table
        Public Const model As String = "Model"
        Public Const series As String = "Series"
        Public Const fpi As String = "FPI"
        Public Const fan_quantity As String = "Fan Qty"
        Public Const refrigerant As String = "Refrigerant"
        Public Const refrigerant_charge As String = "Refrigerant Charge lbs"
        Public Const cfm As String = "CFM"
        Public Const capacity_at_minus_40 As String = "-40"
        Public Const capacity_at_minus_35 As String = "-35"
        Public Const capacity_at_minus_30 As String = "-30"
        Public Const capacity_at_minus_25 As String = "-25"
        Public Const capacity_at_minus_20 As String = "-20"
        Public Const capacity_at_minus_15 As String = "-15"
        Public Const capacity_at_minus_10 As String = "-10"
        Public Const capacity_at_minus_5 As String = "-5"
        Public Const capacity_at_0 As String = "0"
        Public Const capacity_at_5 As String = "5"
        Public Const capacity_at_10 As String = "10"
        Public Const capacity_at_15 As String = "15"
        Public Const capacity_at_20 As String = "20"
        Public Const capacity_at_25 As String = "25"
        Public Const capacity_at_30 As String = "30"
        Public Const capacity_at_35 As String = "35"
        Public Const capacity_at_40 As String = "40"
        Public Const capacity_at_45 As String = "45"
        Public Const capacity_at_50 As String = "50"

        Public Const capacity_at_0_static_pressure As String = "Capacity @ 0 sp"
        Public Const cfm_at_0_static_pressure As String = "CFM @ 0 sp"
        Public Const face_velocity_at_0_static_pressure As String = "Face Velocity @ 0 sp"

        Public Const capacity_at_025_static_pressure As String = "Capacity @ 0.25 sp"
        Public Const cfm_at_025_static_pressure As String = "CFM @ 0.25 sp"
        Public Const face_velocity_at_025_static_pressure As String = "Face Velocity @ 0.25 sp"

        Public Const capacity_at_05_static_pressure As String = "Capacity @ 0.5 sp"
        Public Const cfm_at_05_static_pressure As String = "CFM @ 0.5 sp"
        Public Const face_velocity_at_05_static_pressure As String = "Face Velocity @ 0.5 sp"

        Shared Function capacity_at_025_static_pressure_at(ByVal suction As Double) As String
            Return rae.io.text.str("{0}_at_{1}", capacity_at_025_static_pressure, suction)
        End Function

        Shared Function capacity_at_05_static_pressure_at(ByVal suction As Double) As String
            Return rae.io.text.str("{0}_at_{1}", capacity_at_05_static_pressure, suction)
        End Function

        Public Const rows As String = "Rows"
        Public Const fan_motor_rpm As String = "Fan Motor RPM"
        Public Const fan_motor_part_number_115v_1ph As String = "Fan Motor Part # for 115/1"
        Public Const fan_motor_part_number_230v_1ph As String = "Fan Motor Part # for 230/1"
        Public Const fan_motor_part_number_460v_3ph As String = "Fan Motor Part # for 460/3"
        Public Const fan_motor_part_number_575v_3ph As String = "Fan Motor Part # for 575/3"
        Public Const fan_hp As String = "Fan HP"
        Public Const fan_amps_at_115v_1ph As String = "Fan Amps @ 115/1"
        Public Const fan_amps_at_230v_1ph As String = "Fan Amps @ 230/1"
        Public Const fan_amps_at_208v_3ph As String = "Fan Amps @ 208/3"
        Public Const fan_amps_at_230v_3ph As String = "Fan Amps @ 230/3"
        Public Const fan_amps_at_460v_3ph As String = "Fan Amps @ 460/3"
        Public Const fan_amps_at_575v_3ph As String = "Fan Amps @ 575/3"
        Public Const defrost_heater_watts As String = "Defrost Heater Watts"
        Public Const defrost_heater_amps_at_230v_1ph As String = "Defrost Heater Amps at 230/1"
        Public Const defrost_heater_amps_at_230v_3ph As String = "Defrost Heater Amps at 230/3"
        Public Const defrost_heater_amps_at_460v_3ph As String = "Defrost Heater Amps at 460/3"
        Public Const defrost_heater_amps_at_575v_3ph As String = "Defrost Heater Amps at 575/3"
        Public Const liquid_connection_size As String = "Liquid Connection Size"
        Public Const suction_connection_size As String = "Suction Connection Size"
        Public Const hot_gas_connection_size As String = "Hot Gas Connection Size"
        Public Const coil_height As String = "Coil Height"
        Public Const coil_length As String = "Coil Length"
        Public Const unit_length As String = "Unit Length"
        Public Const unit_width As String = "Unit Width"
        Public Const unit_height As String = "Unit Height"
        Public Const shipping_weight As String = "Shipping Weight"
        Public Const operating_weight As String = "Operating Weight"

        Public Const face_velocity As String = "Face Velocity fpm"
        Public Const liquid_line_connection_quantity As String = "Liquid Connection Quantity"
        Public Const suction_line_connection_quantity As String = "Suction Connection Quantity"
        Public Const DEFROST_PHASE As String = "Defrost Phase"
        Public Const Sound As String = "Sound"
        Public Const AirThrow As String = "Throw"

    End Class

    Class unit_coolers_to_table : Implements i_convert(Of unit_cooler_list, data_table)

        Function convert(ByVal unit_coolers As unit_cooler_list) As data_table _
        Implements i_convert(Of unit_cooler_list, data_table).convert
            Dim table = New data_table()
            With table.Columns
                .Add(t1.model)
                .Add(t1.series)
                .Add(t1.fpi)
                .Add(t1.fan_quantity)
                .Add(t1.refrigerant)
                .Add(t1.refrigerant_charge)
                .Add(t1.cfm)
                .Add(t1.face_velocity)
                .Add(t1.coil_height)
                .Add(t1.coil_length)
                .Add(t1.unit_length)
                .Add(t1.unit_width)
                .Add(t1.unit_height)
                .Add(t1.capacity_at_minus_40)
                .Add(t1.capacity_at_minus_35)
                .Add(t1.capacity_at_minus_30)
                .Add(t1.capacity_at_minus_25)
                .Add(t1.capacity_at_minus_20)
                .Add(t1.capacity_at_minus_15)
                .Add(t1.capacity_at_minus_10)
                .Add(t1.capacity_at_minus_5)
                .Add(t1.capacity_at_0)
                .Add(t1.capacity_at_5)
                .Add(t1.capacity_at_10)
                .Add(t1.capacity_at_15)
                .Add(t1.capacity_at_20)
                .Add(t1.capacity_at_25)
                .Add(t1.capacity_at_30)
                .Add(t1.capacity_at_35)
                .Add(t1.capacity_at_40)
                .Add(t1.capacity_at_45)
                .Add(t1.capacity_at_50)
                .Add(t1.capacity_at_0_static_pressure)
                .Add(t1.cfm_at_0_static_pressure)
                .Add(t1.face_velocity_at_0_static_pressure)
                .Add(t1.capacity_at_025_static_pressure)
                .Add(t1.cfm_at_025_static_pressure)
                .Add(t1.face_velocity_at_025_static_pressure)
                .Add(t1.capacity_at_05_static_pressure)
                .Add(t1.cfm_at_05_static_pressure)
                .Add(t1.face_velocity_at_05_static_pressure)

                .Add(t1.capacity_at_025_static_pressure_at(-40))
                .Add(t1.capacity_at_025_static_pressure_at(-35))
                .Add(t1.capacity_at_025_static_pressure_at(-30))
                .Add(t1.capacity_at_025_static_pressure_at(-25))
                .Add(t1.capacity_at_025_static_pressure_at(-20))
                .Add(t1.capacity_at_025_static_pressure_at(-15))
                .Add(t1.capacity_at_025_static_pressure_at(-10))
                .Add(t1.capacity_at_025_static_pressure_at(-5))
                .Add(t1.capacity_at_025_static_pressure_at(0))
                .Add(t1.capacity_at_025_static_pressure_at(5))
                .Add(t1.capacity_at_025_static_pressure_at(10))
                .Add(t1.capacity_at_025_static_pressure_at(15))
                .Add(t1.capacity_at_025_static_pressure_at(20))
                .Add(t1.capacity_at_025_static_pressure_at(25))
                .Add(t1.capacity_at_025_static_pressure_at(30))
                .Add(t1.capacity_at_025_static_pressure_at(35))
                .Add(t1.capacity_at_025_static_pressure_at(40))
                .Add(t1.capacity_at_025_static_pressure_at(45))
                .Add(t1.capacity_at_025_static_pressure_at(50))

                .Add(t1.capacity_at_05_static_pressure_at(-40))
                .Add(t1.capacity_at_05_static_pressure_at(-35))
                .Add(t1.capacity_at_05_static_pressure_at(-30))
                .Add(t1.capacity_at_05_static_pressure_at(-25))
                .Add(t1.capacity_at_05_static_pressure_at(-20))
                .Add(t1.capacity_at_05_static_pressure_at(-15))
                .Add(t1.capacity_at_05_static_pressure_at(-10))
                .Add(t1.capacity_at_05_static_pressure_at(-5))
                .Add(t1.capacity_at_05_static_pressure_at(0))
                .Add(t1.capacity_at_05_static_pressure_at(5))
                .Add(t1.capacity_at_05_static_pressure_at(10))
                .Add(t1.capacity_at_05_static_pressure_at(15))
                .Add(t1.capacity_at_05_static_pressure_at(20))
                .Add(t1.capacity_at_05_static_pressure_at(25))
                .Add(t1.capacity_at_05_static_pressure_at(30))
                .Add(t1.capacity_at_05_static_pressure_at(35))
                .Add(t1.capacity_at_05_static_pressure_at(40))
                .Add(t1.capacity_at_05_static_pressure_at(45))
                .Add(t1.capacity_at_05_static_pressure_at(50))


                '.Add(t1.capacity_at_025_static_pressure_at(-40))
                '.Add(t1.capacity_at_025_static_pressure_at(-30))
                '.Add(t1.capacity_at_05_static_pressure_at(-40))
                '.Add(t1.capacity_at_05_static_pressure_at(-30))

                .Add(t1.rows)
                .Add(t1.fan_motor_rpm)
                .Add(t1.fan_motor_part_number_115v_1ph)
                .Add(t1.fan_motor_part_number_230v_1ph)
                .Add(t1.fan_motor_part_number_460v_3ph)
                .Add(t1.fan_motor_part_number_575v_3ph)
                .Add(t1.fan_hp)
                .Add(t1.fan_amps_at_115v_1ph)
                .Add(t1.fan_amps_at_230v_1ph)
                .Add(t1.fan_amps_at_208v_3ph)
                .Add(t1.fan_amps_at_230v_3ph)
                .Add(t1.fan_amps_at_460v_3ph)
                .Add(t1.fan_amps_at_575v_3ph)
                .Add(t1.defrost_heater_watts)
                .Add(t1.defrost_heater_amps_at_230v_1ph)
                .Add(t1.defrost_heater_amps_at_230v_3ph)
                .Add(t1.defrost_heater_amps_at_460v_3ph)
                .Add(t1.defrost_heater_amps_at_575v_3ph)
                .Add(t1.liquid_connection_size)
                .Add(t1.suction_connection_size)
                .Add(t1.hot_gas_connection_size)
                .Add(t1.shipping_weight)
                .Add(t1.operating_weight)
                .Add(t1.liquid_line_connection_quantity)
                .Add(t1.suction_line_connection_quantity)
                .Add(t1.DEFROST_PHASE)
                .Add(t1.Sound)
                .Add(t1.AirThrow)

            End With
            Dim capacity_format = "#"   'ericc 5/22/2015
            '-35, -25, -15, -5, 5, 15, 30, 40, 50
            For Each unit_cooler In unit_coolers
                table.Rows.Add(New Object() {
                   unit_cooler.model,
                   unit_cooler.series,
                   unit_cooler.fpi,
                   unit_cooler.fan_quantity,
                   unit_cooler.refrigerant,
                   unit_cooler.refrigerant_charge,
                   unit_cooler.cfm,
                   unit_cooler.face_velocity,
                   unit_cooler.coil_height,
                   unit_cooler.coil_length,
                   unit_cooler.unit_length,
                   unit_cooler.unit_width,
                   unit_cooler.unit_height,
                   If(unit_cooler.suction_is_in_range(-40), unit_cooler.capacity_at_10_td(-40, 0).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(-35), unit_cooler.capacity_at_10_td(-35, 0).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(-30), unit_cooler.capacity_at_10_td(-30, 0).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(-25), unit_cooler.capacity_at_10_td(-25, 0).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(-20), unit_cooler.capacity_at_10_td(-20, 0).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(-15), unit_cooler.capacity_at_10_td(-15, 0).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(-10), unit_cooler.capacity_at_10_td(-10, 0).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(-5), unit_cooler.capacity_at_10_td(-5, 0).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(0), unit_cooler.capacity_at_10_td(0, 0).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(5), unit_cooler.capacity_at_10_td(5, 0).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(10), unit_cooler.capacity_at_10_td(10, 0).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(15), unit_cooler.capacity_at_10_td(15, 0).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(20), unit_cooler.capacity_at_10_td(20, 0).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(25), unit_cooler.capacity_at_10_td(25, 0).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(30), unit_cooler.capacity_at_10_td(30, 0).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(35), unit_cooler.capacity_at_10_td(35, 0).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(40), unit_cooler.capacity_at_10_td(40, 0).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(45), unit_cooler.capacity_at_10_td(45, 0).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(50), unit_cooler.capacity_at_10_td(50, 0).ToString(capacity_format), "-"),
                   If(unit_cooler.at.ContainsKey(0), unit_cooler.at(0).capacity_at(25, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.at.ContainsKey(0), unit_cooler.at(0).cfm.ToString, "-"),
                   If(unit_cooler.at.ContainsKey(0), unit_cooler.at(0).face_velocity.ToString, "-"),
                   If(unit_cooler.at.ContainsKey(0.25), unit_cooler.at(0.25).capacity_at(25, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.at.ContainsKey(0.25), unit_cooler.at(0.25).cfm.ToString, "-"),
                   If(unit_cooler.at.ContainsKey(0.25), unit_cooler.at(0.25).face_velocity.ToString, "-"),
                   If(unit_cooler.at.ContainsKey(0.5), unit_cooler.at(0.5).capacity_at(25, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.at.ContainsKey(0.5), unit_cooler.at(0.5).cfm.ToString, "-"),
                   If(unit_cooler.at.ContainsKey(0.5), unit_cooler.at(0.5).face_velocity.ToString, "-"),
                   If(unit_cooler.suction_is_in_range(-40) And unit_cooler.at.ContainsKey(0.25), unit_cooler.at(0.25).capacity_at(-40, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(-35) And unit_cooler.at.ContainsKey(0.25), unit_cooler.at(0.25).capacity_at(-35, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(-30) And unit_cooler.at.ContainsKey(0.25), unit_cooler.at(0.25).capacity_at(-30, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(-25) And unit_cooler.at.ContainsKey(0.25), unit_cooler.at(0.25).capacity_at(-25, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(-20) And unit_cooler.at.ContainsKey(0.25), unit_cooler.at(0.25).capacity_at(-20, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(-15) And unit_cooler.at.ContainsKey(0.25), unit_cooler.at(0.25).capacity_at(-15, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(-10) And unit_cooler.at.ContainsKey(0.25), unit_cooler.at(0.25).capacity_at(-10, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(-5) And unit_cooler.at.ContainsKey(0.25), unit_cooler.at(0.25).capacity_at(-5, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(0) And unit_cooler.at.ContainsKey(0.25), unit_cooler.at(0.25).capacity_at(0, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(5) And unit_cooler.at.ContainsKey(0.25), unit_cooler.at(0.25).capacity_at(5, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(10) And unit_cooler.at.ContainsKey(0.25), unit_cooler.at(0.25).capacity_at(10, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(15) And unit_cooler.at.ContainsKey(0.25), unit_cooler.at(0.25).capacity_at(15, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(20) And unit_cooler.at.ContainsKey(0.25), unit_cooler.at(0.25).capacity_at(20, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(25) And unit_cooler.at.ContainsKey(0.25), unit_cooler.at(0.25).capacity_at(25, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(30) And unit_cooler.at.ContainsKey(0.25), unit_cooler.at(0.25).capacity_at(30, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(35) And unit_cooler.at.ContainsKey(0.25), unit_cooler.at(0.25).capacity_at(35, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(40) And unit_cooler.at.ContainsKey(0.25), unit_cooler.at(0.25).capacity_at(40, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(45) And unit_cooler.at.ContainsKey(0.25), unit_cooler.at(0.25).capacity_at(45, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(50) And unit_cooler.at.ContainsKey(0.25), unit_cooler.at(0.25).capacity_at(50, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(-40) And unit_cooler.at.ContainsKey(0.5), unit_cooler.at(0.5).capacity_at(-40, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(-35) And unit_cooler.at.ContainsKey(0.5), unit_cooler.at(0.5).capacity_at(-35, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(-30) And unit_cooler.at.ContainsKey(0.5), unit_cooler.at(0.5).capacity_at(-30, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(-25) And unit_cooler.at.ContainsKey(0.5), unit_cooler.at(0.5).capacity_at(-25, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(-20) And unit_cooler.at.ContainsKey(0.5), unit_cooler.at(0.5).capacity_at(-20, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(-15) And unit_cooler.at.ContainsKey(0.5), unit_cooler.at(0.5).capacity_at(-15, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(-10) And unit_cooler.at.ContainsKey(0.5), unit_cooler.at(0.5).capacity_at(-10, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(-5) And unit_cooler.at.ContainsKey(0.5), unit_cooler.at(0.5).capacity_at(-5, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(0) And unit_cooler.at.ContainsKey(0.5), unit_cooler.at(0.5).capacity_at(0, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(5) And unit_cooler.at.ContainsKey(0.5), unit_cooler.at(0.5).capacity_at(5, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(10) And unit_cooler.at.ContainsKey(0.5), unit_cooler.at(0.5).capacity_at(10, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(15) And unit_cooler.at.ContainsKey(0.5), unit_cooler.at(0.5).capacity_at(15, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(20) And unit_cooler.at.ContainsKey(0.5), unit_cooler.at(0.5).capacity_at(20, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(25) And unit_cooler.at.ContainsKey(0.5), unit_cooler.at(0.5).capacity_at(25, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(30) And unit_cooler.at.ContainsKey(0.5), unit_cooler.at(0.5).capacity_at(30, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(35) And unit_cooler.at.ContainsKey(0.5), unit_cooler.at(0.5).capacity_at(35, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(40) And unit_cooler.at.ContainsKey(0.5), unit_cooler.at(0.5).capacity_at(40, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(45) And unit_cooler.at.ContainsKey(0.5), unit_cooler.at(0.5).capacity_at(45, unit_cooler.model).ToString(capacity_format), "-"),
                   If(unit_cooler.suction_is_in_range(50) And unit_cooler.at.ContainsKey(0.5), unit_cooler.at(0.5).capacity_at(50, unit_cooler.model).ToString(capacity_format), "-"),
                                                                                                                                                        unit_cooler.rows,
                                                                                                                                                        unit_cooler.rpm,
                                                                                                                                                        unit_cooler.fan_motor_part_number_115v_1ph,
                                                                                                                                                        unit_cooler.fan_motor_part_number_230v_1ph,
                                                                                                                                                        unit_cooler.fan_motor_part_number_460v_3ph,
                                                                                                                                                        unit_cooler.fan_motor_part_number_575v_3ph,
                                                                                                                                                        unit_cooler.fan_motor_hp,
                                                                                                                                                        unit_cooler.fan_motor_amps_at_115v_1ph,
                                                                                                                                                        unit_cooler.fan_motor_amps_at_230v_1ph,
                                                                                                                                                        unit_cooler.fan_motor_amps_at_208v_3ph,
                                                                                                                                                        unit_cooler.fan_motor_amps_at_230v_3ph,
                                                                                                                                                        unit_cooler.fan_motor_amps_at_460v_3ph,
                                                                                                                                                        unit_cooler.fan_motor_amps_at_575v_3ph,
                                                                                                                                                        unit_cooler.defrost_heater_watts,
                                                                                                                                                        unit_cooler.total_defrost_heater_amps_at_230v_1ph,
                                                                                                                                                        unit_cooler.total_defrost_heater_amps_at_230v_3ph,
                                                                                                                                                        unit_cooler.total_defrost_heater_amps_at_460v_3ph,
                                                                                                                                                        unit_cooler.total_defrost_heater_amps_at_575v_3ph,
                                                                                                                                                        unit_cooler.liquid_line_connection_size,
                                                                                                                                                        unit_cooler.suction_line_connection_size,
                                                                                                                                                        unit_cooler.hot_gas_connection_size,
                                                                                                                                                        unit_cooler.shipping_weight,
                                                                                                                                                        unit_cooler.operating_weight,
                                                                                                                                                        unit_cooler.liquid_line_connection_quantity,
                                                                                                                                                        unit_cooler.suction_line_connection_quantity,
                                                                                                                                                        If(unit_cooler.DefrostPhase = 0, "-", unit_cooler.DefrostPhase.ToString), unit_cooler.Sound, unit_cooler.AirThrow
                   })
            Next

            Return table
        End Function

    End Class

    Public Class data_table : Inherits DataTable
    End Class

    Interface i_format_as_table(Of t As IEnumerable)
        Function format_as_table(ByVal list As t) As DataTable
    End Interface

    Class table_format : Implements i_format_as_table(Of IEnumerable)
        Function format_as_table(ByVal list As IEnumerable) As DataTable _
        Implements i_format_as_table(Of IEnumerable).format_as_table
            Dim table = New DataTable()

            For Each item In list
                Dim public_fields = item.GetType.GetFields([public] Or instance)
                Dim values = New list(Of Object)
                For Each field In public_fields
                    If Not table.columns.contains(field.name) Then _
                       table.columns.add(field.name, field.GetValue(item).GetType())
                    values.add(field.GetValue(item))
                Next
                table.rows.add(values.ToArray)
            Next

            Return table
        End Function
    End Class

End Namespace