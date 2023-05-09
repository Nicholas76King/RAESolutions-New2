Imports rae.Io.Text
Imports rae.solutions.refrigerant
Imports rae.validation

Namespace rae.solutions.condensing_units

    Public Class refrigerant_head_pressure_will_not_trip_sensor : Inherits validator_base
        Private refrigerant As refrigerant
        Private condensing_temp As Double

        Sub New(ByVal refrigerant As refrigerant, ByVal condensing_temp As Double)
            Me.refrigerant = refrigerant
            Me.condensing_temp = condensing_temp
        End Sub

        Overrides Function validate() As i_validate
            _messages.clear()

            Dim head_pressure_limit, condensing_temp_max As Double  ' if you change any of these, be sure to change them on condensing_unit_rating_screen as well (search for eric9898)
            If refrigerant = R404a Then
                head_pressure_limit = 370
                condensing_temp_max = 130    '133   '
            ElseIf refrigerant = R507 Then
                head_pressure_limit = 370
                condensing_temp_max = 130    '131
            ElseIf refrigerant = R407c Then
                head_pressure_limit = 370
                condensing_temp_max = 130    '146
            ElseIf refrigerant = R410a Then
                head_pressure_limit = 550
                condensing_temp_max = 141
            ElseIf refrigerant = R407a Then
                head_pressure_limit = 370
                condensing_temp_max = 130    '132
            ElseIf refrigerant = R407f Then
                head_pressure_limit = 370
                condensing_temp_max = 130    '129
            ElseIf refrigerant = R134a Then
                head_pressure_limit = 370
                condensing_temp_max = 150    '
            ElseIf refrigerant = R448a Then
                head_pressure_limit = 370
                condensing_temp_max = 130    '132
            ElseIf refrigerant = R449a Then
                head_pressure_limit = 370
                condensing_temp_max = 130    '133
            ElseIf refrigerant = R22 Then
                head_pressure_limit = 370
                condensing_temp_max = 130    '147

            Else
                Throw New Exception(Str("the refrigerant head pressure limit is unspecified for this refrigerant, {0}", refrigerant.value))
            End If

            If condensing_temp > condensing_temp_max Then
                valid = False
                Dim msg = str("The refrigerant head pressure is too close to the limit. {0}:{1}psig.",
                              refrigerant.value, condensing_temp)
                _messages.add(New message(validation_status.failure, msg))
            Else
                valid = True
            End If

            Return Me
        End Function
    End Class

End Namespace