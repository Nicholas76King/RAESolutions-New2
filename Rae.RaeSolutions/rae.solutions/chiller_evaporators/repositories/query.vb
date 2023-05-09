Option Strict Off

Imports ET1 = RAE.Solutions.chiller_evaporators.evaporator_table

Namespace rae.solutions.chiller_evaporators

Class query
   Function Evaporators As query
            sql = "SELECT * FROM " & ET1.table_name
            Return Me
        End Function

        Function Where() As query
            sql &= " WHERE "
            Return Me
        End Function

        Function [And]() As query
            sql &= " AND "
            Return Me
        End Function

        Function ModelIs(model As String) As query
            sql &= str("[{0}]='{1}'", ET1.old_dll_model, model)
            Return Me
        End Function

        Function NumCircuitsIs(numCircuits As Integer) As query
            sql &= str("[{0}] = {1}", ET1.number_of_circuits, numCircuits)
            Return Me
        End Function

        Function LengthIsLessThanEqualTo(length As Double) As query
            sql &= str("CInt([{0}]) <= {1}", ET1.length, length)
            Return Me
        End Function

        Function HasRaePartNum() As query
            sql &= str("[{0}] LIKE 'C%'", ET1.rae_part_number)
            Return Me
   End Function
   
   Function ToSql() As String
      Return sql
   End Function
   
   Private sql As String
   
   Private Function str(sql As String, ParamArray params() As String) As String
      Return New System.Text.StringBuilder().AppendFormat(sql, params).ToString
   End Function

End Class

End Namespace