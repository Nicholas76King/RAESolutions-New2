Imports System.Math

Namespace rae.solutions.unit_coolers

    Public Class unit_cooler
        Class info_at_static_pressure
            '  Private model As String

            Sub New(iRefrigerant As String, iCFM As Decimal, iFaceVelocity As Decimal, iCap_Neg40 As Decimal, iCap_Neg30 As Decimal, iCap_Neg20 As Decimal, iCap_Neg10 As Decimal, iCap_0 As Decimal, iCap_10 As Decimal, iCap_20 As Decimal, iCap_25 As Decimal, iCap_35 As Decimal, iCap_45 As Decimal)
                '                Me.model = model
                Me.Refrigerant = iRefrigerant
                Me.cfm = iCFM
                Me.face_velocity = iFaceVelocity

                Me.Cap_Neg40 = iCap_Neg40
                Me.Cap_Neg30 = iCap_Neg30
                Me.Cap_Neg20 = iCap_Neg20
                Me.Cap_Neg10 = iCap_Neg10
                Me.Cap_0 = iCap_0
                Me.Cap_10 = iCap_10
                Me.Cap_20 = iCap_20
                Me.Cap_25 = iCap_25
                Me.Cap_35 = iCap_35
                Me.Cap_45 = iCap_45

            End Sub

            Public Refrigerant As String
            Public cfm, face_velocity As Double
            Public Cap_Neg40, Cap_Neg30, Cap_Neg20, Cap_Neg10, Cap_0, Cap_10, Cap_20, Cap_25, Cap_35, Cap_45 As Decimal


            Function capacity_at(ByVal suction_temp As Double, model As String) As Double
                Dim minCapPoint_Temp As Double
                Dim minCapPoint_Capacity As Double = 0
                Dim maxCapPoint_Temp As Double
                Dim maxCapPoint_Capacity As Double = 0

                If suction_temp = -40 AndAlso Cap_Neg40 <> 0 Then Return Cap_Neg40
                If suction_temp = -30 AndAlso Cap_Neg30 <> 0 Then Return Cap_Neg30
                If suction_temp = -20 AndAlso Cap_Neg20 <> 0 Then Return Cap_Neg20
                If suction_temp = -10 AndAlso Cap_Neg10 <> 0 Then Return Cap_Neg10
                If suction_temp = 0 AndAlso Cap_0 <> 0 Then Return Cap_0
                If suction_temp = 10 AndAlso Cap_10 <> 0 Then Return Cap_10
                If suction_temp = 20 AndAlso Cap_20 <> 0 Then Return Cap_20
                If suction_temp = 25 AndAlso Cap_25 <> 0 Then Return Cap_25
                If suction_temp = 35 AndAlso Cap_35 <> 0 Then Return Cap_35
                If suction_temp = 45 AndAlso Cap_45 <> 0 Then Return Cap_45



                If (suction_temp >= -40 OrElse minCapPoint_Capacity = 0) AndAlso Cap_Neg40 <> 0 Then minCapPoint_Temp = -40 : minCapPoint_Capacity = Cap_Neg40
                If (suction_temp >= -30 OrElse minCapPoint_Capacity = 0) AndAlso Cap_Neg30 <> 0 Then minCapPoint_Temp = -30 : minCapPoint_Capacity = Cap_Neg30
                If (suction_temp >= -20 OrElse minCapPoint_Capacity = 0) AndAlso Cap_Neg20 <> 0 Then minCapPoint_Temp = -20 : minCapPoint_Capacity = Cap_Neg20
                If (suction_temp >= -10 OrElse minCapPoint_Capacity = 0) AndAlso Cap_Neg10 <> 0 Then minCapPoint_Temp = -10 : minCapPoint_Capacity = Cap_Neg10
                If (suction_temp >= 0 OrElse minCapPoint_Capacity = 0) AndAlso Cap_0 <> 0 Then minCapPoint_Temp = 0 : minCapPoint_Capacity = Cap_0
                If (suction_temp >= 10 OrElse minCapPoint_Capacity = 0) AndAlso Cap_10 <> 0 Then minCapPoint_Temp = 10 : minCapPoint_Capacity = Cap_10
                If (suction_temp >= 20 OrElse minCapPoint_Capacity = 0) AndAlso Cap_20 <> 0 Then minCapPoint_Temp = 20 : minCapPoint_Capacity = Cap_20
                If (suction_temp >= 25 OrElse minCapPoint_Capacity = 0) AndAlso Cap_25 <> 0 Then minCapPoint_Temp = 25 : minCapPoint_Capacity = Cap_25
                If (suction_temp >= 35 OrElse minCapPoint_Capacity = 0) AndAlso Cap_35 <> 0 Then minCapPoint_Temp = 35 : minCapPoint_Capacity = Cap_35



                If (suction_temp <= 45 OrElse maxCapPoint_Capacity = 0) AndAlso Cap_45 <> 0 AndAlso minCapPoint_Temp <> 45 Then maxCapPoint_Temp = 45 : maxCapPoint_Capacity = Cap_45
                If (suction_temp <= 35 OrElse maxCapPoint_Capacity = 0) AndAlso Cap_35 <> 0 AndAlso minCapPoint_Temp <> 35 Then maxCapPoint_Temp = 35 : maxCapPoint_Capacity = Cap_35
                If (suction_temp <= 25 OrElse maxCapPoint_Capacity = 0) AndAlso Cap_25 <> 0 AndAlso minCapPoint_Temp <> 25 Then maxCapPoint_Temp = 25 : maxCapPoint_Capacity = Cap_25
                If (suction_temp <= 20 OrElse maxCapPoint_Capacity = 0) AndAlso Cap_20 <> 0 AndAlso minCapPoint_Temp <> 20 Then maxCapPoint_Temp = 20 : maxCapPoint_Capacity = Cap_20
                If (suction_temp <= 10 OrElse maxCapPoint_Capacity = 0) AndAlso Cap_10 <> 0 AndAlso minCapPoint_Temp <> 10 Then maxCapPoint_Temp = 10 : maxCapPoint_Capacity = Cap_10
                If (suction_temp <= 0 OrElse maxCapPoint_Capacity = 0) AndAlso Cap_0 <> 0 AndAlso minCapPoint_Temp <> 0 Then maxCapPoint_Temp = 0 : maxCapPoint_Capacity = Cap_0
                If (suction_temp <= -10 OrElse maxCapPoint_Capacity = 0) AndAlso Cap_Neg10 <> 0 AndAlso minCapPoint_Temp <> -10 Then maxCapPoint_Temp = -10 : maxCapPoint_Capacity = Cap_Neg10
                If (suction_temp <= -20 OrElse maxCapPoint_Capacity = 0) AndAlso Cap_Neg20 <> 0 AndAlso minCapPoint_Temp <> -20 Then maxCapPoint_Temp = -20 : maxCapPoint_Capacity = Cap_Neg20
                If (suction_temp <= -30 OrElse maxCapPoint_Capacity = 0) AndAlso Cap_Neg30 <> 0 AndAlso minCapPoint_Temp <> -30 Then maxCapPoint_Temp = -30 : maxCapPoint_Capacity = Cap_Neg30



                If maxCapPoint_Capacity = 0 AndAlso minCapPoint_Capacity = 0 Then Return 0

                If maxCapPoint_Capacity = 0 Then ' use old correlations
                    Dim multiplier = New unit_cooler_multiplier_for_25_suction(model, suction_temp).multiplier
                    Return minCapPoint_Capacity * multiplier

                End If
                If minCapPoint_Capacity = 0 Then ' use old correlations
                    Dim multiplier = New unit_cooler_multiplier_for_25_suction(model, suction_temp).multiplier
                    Return maxCapPoint_Capacity * multiplier

                End If

                If maxCapPoint_Temp = minCapPoint_Temp Then  ' Suction is equal to one of database points
                    If maxCapPoint_Temp = suction_temp Then
                        Return maxCapPoint_Capacity
                    Else
                        Return 0
                    End If
                End If



                Dim rCapacity As Double
                rCapacity = (((maxCapPoint_Capacity - minCapPoint_Capacity) / (maxCapPoint_Temp - minCapPoint_Temp)) * (suction_temp - minCapPoint_Temp)) + minCapPoint_Capacity


                Return rCapacity

            End Function
        End Class


        Public Enum FanMotorType
            Standard = 1
            ECM = 2
        End Enum

        Sub New()
            at = New dictionary(Of Double, info_at_static_pressure)
        End Sub

        Public model, series As String
        Public refrigerant As refrigerant
        Public refrigerant_charge As Double
        Public quantity, hertz As Integer
        Public cfm, coil_height, coil_length, fpi, rows, model_capacity As Double
        Public fan_motor_hp, rpm, fan_quantity As Double
        Public fan_motor_part_number_115v_1ph, fan_motor_part_number_230v_1ph, fan_motor_part_number_460v_3ph, fan_motor_part_number_575v_3ph As String
        Public fan_motor_amps_at_115v_1ph, fan_motor_amps_at_230v_1ph As Double
        Public fan_motor_amps_at_208v_3ph, fan_motor_amps_at_230v_3ph, fan_motor_amps_at_460v_3ph, fan_motor_amps_at_575v_3ph As Double
        Public defrost_heater_watts As Double
        Public total_defrost_heater_amps_at_230v_1ph As Double
        Public total_defrost_heater_amps_at_230v_3ph, total_defrost_heater_amps_at_460v_3ph, total_defrost_heater_amps_at_575v_3ph As Double
        Public liquid_line_connection_size, suction_line_connection_size, hot_gas_connection_size As Double
        Public liquid_line_connection_quantity, suction_line_connection_quantity As Double
        Public min_suction, max_suction As Double
        Public unit_length, unit_width, unit_height As Double
        Public shipping_weight, operating_weight As Double
        ' Friend capacity_at_25_suction As Double

        Public fan_motor_type As FanMotorType
        Public WarningMessage As String

        Public DOECompliant As Boolean
        Public Sound As Decimal, AirThrow As Decimal

        Public at As dictionary(Of Double, info_at_static_pressure)

        Function suction_is_in_range(ByVal suction As Double) As Boolean
            Return suction >= min_suction And suction <= max_suction
        End Function

        Function face_velocity() As Double
            Return cfm / (convert.inchesToFeet(coil_height) * convert.InchesToFeet(coil_length))
        End Function

        Function face_velocity_is_suitable_for_air_defrost() As Boolean
            Return face_velocity() < 625
        End Function

        Function capacity_at(ByVal suction As Double, ByVal td As Double, static_pressure As Double) As Double
            Return capacity_per_degree_at(suction, static_pressure) * td
        End Function

        Function capacity_per_degree_at(ByVal suction As Double, static_pressure As Double) As Double
            Return capacity_at_10_td(suction, static_pressure) / 10
        End Function

        Function capacity_at_10_td(ByVal suction As Double, static_pressure As Double) As Double
            Dim capacity As Double
            capacity = at(static_pressure).capacity_at(suction, model)

            Return capacity
        End Function

        Function DefrostPhase() As Integer

            ' 11/17/2010 Eric C
            ' Calculating PHASE off of defrost heater amps as per Cliff Mines
            ' Adding ONLY for FH series as I am not sure if this logic holds try for other series.
            If Me.series.ToUpper = "UFH" OrElse Me.series.ToUpper = "FV" Then

                If Me.total_defrost_heater_amps_at_230v_1ph < 0.1 Then
                    Return 1
                Else
                    Return 3
                End If
            Else
                Return 0
            End If

        End Function


        Function min_capacity(ByVal td As Double, sp As Double) As Double
            Return capacity_at(min_suction, td, sp)
        End Function

        Function max_capacity(ByVal td As Double, sp As Double) As Double
            'the +10 was requested per jim w., unit coolers may operate at higher evap. temperature than catalog lists
            Return capacity_at(max_suction + 10, td, sp)
        End Function

        Function actual_td(ByVal design_capacity As Double, ByVal design_room_temp As Double, ByVal design_suction As Double, sp As Double) As Double
            Dim steps() As Double = {1, 0.1}
            Dim td = design_room_temp - design_suction
            Dim calculated_capacity As Double = capacity_at(design_suction, td, SP)

            For Each [step] In steps
                If calculated_capacity < design_capacity Then
                    Do
                        td += [step]
                        calculated_capacity = capacity_at(design_room_temp - td, td, SP)
                    Loop While (calculated_capacity < design_capacity)
                Else
                    Do
                        td -= [step]
                        calculated_capacity = capacity_at(design_room_temp - td, td, SP)
                    Loop While (calculated_capacity > design_capacity)
                End If
            Next

            Return td
        End Function

    End Class

End Namespace