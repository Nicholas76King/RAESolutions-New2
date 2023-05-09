Imports rae.Solutions
Imports t1 = RAE.Solutions.condensing_units.Table

Namespace rae.solutions.condensing_units

    Class Query

        Function condensing_units() As Query
            _sql &= "SELECT * FROM " & t1.table_name
            Return Me
        End Function

        Function where() As Query
            _sql &= " WHERE "
            Return Me
        End Function

        Function [and]() As Query
            _sql &= " AND "
            Return Me
        End Function

        Function append(ByVal sql As String) As Query
            _sql &= sql
            Return Me
        End Function

        Function model_starts_with(ByVal start_of_model As String) As Query
            _sql &= t1.model & " LIKE '" & start_of_model & "%'"
            Return Me
        End Function

        Function refrigerant_is_not(ByVal refrigerant As refrigerant) As Query
            _sql &= t1.refrigerant & " <> '" & refrigerant.value & "'"
            Return Me
        End Function

        Function refrigerant_is(ByVal refrigerant As refrigerant) As Query
            _sql &= t1.refrigerant & "='" & refrigerant.for_db & "'"
            Return Me
        End Function

        Function division_is(ByVal division As rae.RaeSolutions.Business.Division) As Query
            _sql &= t1.division & "='" & division.ToString & "'"
            Return Me
        End Function

        Function series_is(ByVal series As String) As Query
            _sql &= t1.series & "='" & series & "'"
            Return Me
        End Function


        Function DOECompliant(ByVal DOEFlag As String) As Query

            If String.IsNullOrEmpty(DOEFlag) Then Return Me

            If DOEFlag.ToUpper = "YES" Then
                _sql &= "DOECOmpliant" & "= True "
            ElseIf DOEFlag.ToUpper = "NO" Then
                '    _sql &= "DOECOmpliant" & "= False "
                _sql &= " TRUE "
            End If

            Return Me
        End Function



        'Function suction_is_in_range(ByVal suction As Double) As Query
        '    _sql &= t.minSuctionfromenvelope & "<=" & suction & " AND " & t.maxSuctionFromEnvelope ">=" & suction
        '    Return Me
        'End Function

        Function compressor_quantity_description_is(ByVal quantity_description As String) As Query
            _sql &= t1.compressor_quantity_description & "='" & quantity_description & "'"
            Return Me
        End Function

        Function compressor_type_is(ByVal compressor_type As String) As Query
            _sql &= t1.compressor_type_1 & "='" & compressor_type & "'"
            Return Me
        End Function

        Function model_is(ByVal model As String) As Query
            _sql &= t1.model & "='" & model & "'"
            Return Me
        End Function

        Function order_by_model() As Query
            _sql &= "ORDER BY " & t1.model
            Return Me
        End Function

        Function sql() As String
            Return _sql
        End Function

        Protected _sql As String
    End Class

End Namespace