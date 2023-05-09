namespace rae.solutions.drawings

    Public Structure chiller_electrical_data
        Public compressor_quantity_1, compressor_quantity_2, fan_quantity_1, fan_quantity_2 As Double
        Public compressor_file_1, compressor_file_2, motor_part_number_1_phase, motor_part_number_3_phase As String
        Public number_of_circuits As Integer
        Public Number_ref_circuits_1 As Double
        Public Number_ref_circuits_2 As Double

        Public coil_qty1 As Double
        Public coil_qty2 As Double
    End Structure

end namespace