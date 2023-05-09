Namespace rae.solutions.drawings

    Public Structure unit_cooler_electrical_data
        Public motor_amps_115v_1ph, motor_amps_208v_3ph, motor_amps_230v_1ph, motor_amps_230v_3ph, motor_amps_460v_1ph, motor_amps_460v_3ph, motor_amps_575v_1ph, motor_amps_575v_3ph As Double
        Public heater_amps_230v_1ph, heater_amps_230v_3ph, _
               heater_amps_460v_1ph, heater_amps_460v_3ph, heater_amps_575v_1ph, heater_amps_575v_3ph As Double
        Public heater_watts, fan_quantity As Double
        Public model_is_in_database As Boolean

        Public One_ph_115volt_mtr_part_number As String
        Public One_ph_230volt_mtr_part_number As String
        Public Three_ph_mtr_part_number As String
        Public Three_ph_575_mtr_part_number As String


    End Structure

End Namespace