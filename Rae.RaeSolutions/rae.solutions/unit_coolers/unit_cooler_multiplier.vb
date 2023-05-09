Namespace rae.solutions.unit_coolers

    ''todo: verify using evaporating temperature instead of suction temperature
    Class unit_cooler_multiplier_for_25_suction
        Sub New(ByVal model As String, ByVal evaporating_temp As Double)
            multiplier = determine_multiplier(model, evaporating_temp)
        End Sub

        Public ReadOnly multiplier As Double

        Private Function determine_multiplier( _
        ByVal model As String, ByVal evaporating_temp As Double) As Double
            Dim m As Double ' evaporator capacity multiplier
            Dim te = evaporating_temp

            If model = "" Then
                Return 0 ' handle model null elsewhere
            End If

            If model Like "A*" OrElse model Like "BOC*" OrElse model Like "XBOC*" OrElse model Like "PFE*" OrElse model Like "*IBR*" OrElse model Like "E*" Then  ' jay
                'm = -0.000000000834 * te ^ 4 + 0.00000099517 * te ^ 3 - 0.00000386934 * te ^ 2 + 0.00398194905 * te + 0.88764540124
                m = -0.000000000825 * te ^ 4 + 0.000000985428 * te ^ 3 - 0.000003831465 * te ^ 2 + 0.003942970905 * te + 0.878956496733
            ElseIf model Like "FH*" Or model Like "FV*" Then
                m = 0.0023 * te + 0.9456
            ElseIf model Like "BALV*" Then
                m = -0.000000161663388 * te ^ 4 + 0.00001634036474 * te ^ 3 - 0.000487493717924 * te ^ 2 + 0.008535078971596 * te + 0.896196993006856
                'ElseIf model Like "*IBR*" Then
                '    m = 0.0023 * te + 0.9456
            Else
                m = 1 'determine_custom_multiplier(te)
            End If

            Return m
        End Function

    End Class

End Namespace