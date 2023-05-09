Namespace rae.solutions.unit_coolers.selections

    Public Structure unit_cooler_input
        Public total_capacity As Double
        Public unit_cooler_quantity As Integer
        Function capacity_per_unit() As Double
            Return total_capacity / unit_cooler_quantity
        End Function
        Public room_temperature, td As Double
        Function suction() As Double
            Return room_temperature - td
        End Function
        Public series, refrigerant, defrost_type, static_pressure As String
        Public fan_quantity As String
        Public DOEModels As String
    End Structure

End Namespace