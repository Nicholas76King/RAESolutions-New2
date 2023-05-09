Imports rae.Io.Text
Imports rae.Math.Calculate

Namespace rae.solutions.unit_coolers

    Class query
        Function unit_coolers() As query
            _sql = "SELECT * FROM [" & table.table_name & "]"
            Return Me
        End Function

        Function static_pressure_is(static_pressure As String) As query
            If static_pressure = "0.25" Then
                _sql &= "[Has025SP]>0"
            ElseIf static_pressure = "0.5" Then
                _sql &= "[Has050SP]>0"
            Else
                _sql &= "TRUE"
            End If
            Return Me
        End Function

        Function refrigerant_is(ByVal refrigerant As String) As query
            _sql &= "[" & table.refrigerant & "]='" & refrigerant & "'"
            Return Me
        End Function

        Function series_like(series As String) As query
            _sql &= "[" & table.series & "] LIKE '" & series & "'"
            Return Me
        End Function

        Function defrost_type_is_available(defrost_type As String) As query
            If defrost_type = "A" Then
                _sql &= "[" & table.air_defrost_is_available & "]=-1"
            Else
                _sql &= "TRUE"
            End If
            Return Me
        End Function

        Function fan_quantity_is(fan_quantity As String) As query
            If fan_quantity = "Any" Then
                _sql &= "TRUE"
            Else
                _sql &= "[" & table.fan_quantity & "]=" & fan_quantity
            End If
            Return Me
        End Function

        Function DOECompliant_is(DOEModels As String) As query
            If DOEModels.ToUpper = "YES" Then
                _sql &= "[" & table.DOECompliant & "]=True"
            Else
                _sql &= "TRUE"
            End If
            Return Me
        End Function


        Function suction_is_within_limits(suction As Double) As query
            _sql &= str("[{0}]<={1} AND [{2}]>={1}", table.min_suction, suction, table.max_suction)
            Return Me
        End Function

        Function where() As query
            _sql &= " WHERE "
            Return Me
        End Function

        Function [and]() As query
            _sql &= " AND "
            Return Me
        End Function

        Function sql() As String
            Return _sql
        End Function

        Private _sql As String
    End Class

End Namespace