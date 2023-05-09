Option Strict Off

Imports Rae.Data
Imports Rae.RaeSolutions.DataAccess
Imports System.Data
Imports ET1 = RAE.Solutions.chiller_evaporators.evaporator_table

Namespace rae.solutions.chiller_evaporators

public class evaporator_repository : Implements i_evaporator_repository
   
   function get_evaporator_by_model(model As String) As evaporator_dto _
   implements i_evaporator_repository.get_evaporator_by_model
            Dim sql = txt("SELECT * FROM {0} WHERE [{1}]='{2}'",
                    ET1.table_name, ET1.dll_model, model)

            Return get_evaporator(sql, model, "evaporator model")
        End Function

        Function get_evaporator_by_part_number(part_number As String) As evaporator_dto _
   Implements i_evaporator_repository.get_evaporator_by_part_number
            Dim sql = txt("SELECT * FROM {0} WHERE [{1}]='{2}'",
                    ET1.table_name, ET1.evaporator_part_number, part_number)

            Return get_evaporator(sql, part_number, "evaporator part number")
        End Function

        Function get_nominal_capacities(rating_type As String, number_of_circuits As Integer) As IList(Of Double) _
   Implements i_evaporator_repository.get_nominal_capacities
            Dim nominalCapacities = New List(Of Double)

            Dim con = createConnection()
            Dim cmd = con.CreateCommand()
            Dim sql = txt("SELECT [{0}] FROM {1} WHERE [{2}]='{3}' AND [{4}]={5}",
                    ET1.nominal_capacity, ET1.table_name, ET1.rating_type, rating_type, ET1.number_of_circuits, number_of_circuits)
            cmd.CommandText = sql
            Dim rdr As IDataReader

            Try
                con.Open()
                rdr = cmd.ExecuteReader()
                While rdr.Read()
                    nominalCapacities.Add(rdr(ET1.nominal_capacity))
                End While
            Finally
                If rdr IsNot Nothing Then _
            rdr.Close()
                If con.State <> ConnectionState.Closed Then _
            con.Close()
            End Try

            Return nominalCapacities
        End Function


        Function get_evaporator(sql As String, model As String, text As String) As evaporator_dto
            If String.IsNullOrEmpty(model) Then _
         throwNull("The chiller evaporator data cannot be retrieved. The " & text & " is not set.")

            Dim con = createConnection()
            Dim cmd = con.CreateCommand()
            cmd.CommandText = sql
            Dim rdr As IDataReader
            Dim evap As evaporator_dto

            Try
                con.Open()
                rdr = cmd.ExecuteReader()
                Dim count As Integer
                While rdr.Read
                    count += 1
                    evap.dll_model = rdr(ET1.dll_model)
                    evap.old_dll_model = rdr(ET1.old_dll_model)
                    evap.rae_part_number = rdr(ET1.rae_part_number)
                    evap.evaporator_part_number = rdr(ET1.evaporator_part_number)
                    evap.catalog_model = rdr(ET1.catalog_model)
                    evap.length = rdr(ET1.length)
                    evap.width = rdr(ET1.width)
                    evap.height = rdr(ET1.height)
                    evap.nominal_tons = rdr(ET1.nominal_capacity)
                    evap.connection_size = rdr(ET1.connection_size)
                    evap.number_of_circuits = rdr(ET1.number_of_circuits)
                    evap.rating_type = rdr(ET1.rating_type)
                    evap.rae_index = rdr(ET1.rae_index)
                End While
         
         If count = 0 Then
            throwNotFound("The chiller evaporator data cannot be retrieved. The evaporator does not exist. " & text & ": " & model)
         ElseIf count > 1 Then
            throwDuplicate("The chiller evaporator data cannot be retrieved. There are multiple evaporators with the same model. " & text & ": " & model)
         End If
      Finally
         If rdr IsNot Nothing Then _
            rdr.Close()
         If con.State <> ConnectionState.Closed Then _
            con.Close()
      End Try
      
      Return evap
   End Function
   
   
   Private Function createConnection() As IDbConnection
      Return Common.CreateConnection(Common.ChillerDbPath)
   End Function
   
   Private Function txt(format As String, ParamArray values() As Object) As String
      Return New System.Text.StringBuilder().AppendFormat(format, values).ToString
   End Function
   
   Private Sub throwNull(msg As String)
      Throw New NullParamEx(msg)
   End Sub
   
   Private Sub throwNotFound(msg As String)
      Throw New NotFoundEx(msg)
   End Sub
   
   Private Sub throwDuplicate(msg As String)
      Throw New DuplicateEx(msg)
   End Sub
End Class

End Namespace