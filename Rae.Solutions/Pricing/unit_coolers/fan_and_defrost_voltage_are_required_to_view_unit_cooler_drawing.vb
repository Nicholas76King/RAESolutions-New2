Imports Rae.validation

Class fan_and_defrost_voltage_are_required_for_unit_cooler_drawing : Inherits validator_base

    Private fan_voltage_is_selected, has_electric_defrost As Boolean, defrost_voltage_is_selected As Boolean
    Private refrigerant_chosen As Boolean


    Sub New(ByVal fan_voltage_is_selected As Boolean, ByVal has_electric_defrost As Boolean, ByVal defrost_voltage_is_selected As Boolean, ByVal refrigerant_chosen1 As Boolean)
        Me.fan_voltage_is_selected = fan_voltage_is_selected
        Me.has_electric_defrost = has_electric_defrost
        Me.defrost_voltage_is_selected = defrost_voltage_is_selected
        Me.refrigerant_chosen = refrigerant_chosen1
    End Sub

    Overrides Function validate() As i_validate
        messages.clear()
        valid = fan_voltage_is_selected And Not (has_electric_defrost And Not defrost_voltage_is_selected) And refrigerant_chosen
        If Not fan_voltage_is_selected Then _
           messages.add(New message(validation_status.warning,
                                    "Fan voltage is required to view unit cooler drawing."))
        If has_electric_defrost And Not defrost_voltage_is_selected Then _
           messages.add(New message(validation_status.warning,
                                    "Defrost voltage is required to view electric defrost, unit cooler drawing"))



        If Not refrigerant_chosen Then _
        messages.add(New message(validation_status.warning,
                            "Refrigerant is required to view unit cooler drawing."))


        Return Me
    End Function

End Class
