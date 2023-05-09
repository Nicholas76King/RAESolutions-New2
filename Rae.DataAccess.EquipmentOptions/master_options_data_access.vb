Imports System.Data
Imports System.Text
Imports System.Collections.Generic
Imports mt = Rae.DataAccess.EquipmentOptions.Tables.master_options_table
Imports System

Namespace Rae.DataAccess.EquipmentOptions

public class master_options_data_access

   shared function retrieve_options(code as string) as list(of master_option)
      dim sql as new StringBuilder

      sql.AppendFormat("SELECT * FROM {0} WHERE {1}='{2}'", _
         mt.table_name, mt.Code, code)

      return retrieve_master_options_based_on_sql(sql)
   end function

   ''' <summary>Retrieves master option info, but it's returned as an option (different data type).</summary>
   ''' <returns>Returned options still do not contain any more information than the list of master options.
   ''' They do have more properties, but they're not set.</returns>
   shared function retrieve_as_options(code as string) as list(of [option])
      dim ops as new list(of [option])

      dim master_ops = retrieve_options(code)
      for i as integer = 0 to master_ops.count - 1
         ' adds empty option to end of list in order to import master option into it
         ops.add(new [option])
         ' imports master option info into option
         ops(ops.count - 1).import(master_ops(i))
      next

      return ops
   end function



   ''' <summary>Retrieves list of master options based on SQL query parameter</summary>
   private shared function retrieve_master_options_based_on_sql(sql As StringBuilder) As List(Of master_option)
      Dim reader As IDataReader
      Dim ops As List(Of master_option)
      Dim i As Integer

      dim connection = Rae.Data.DataObjects.CreateConnection(ConnectionString.DataAccessType, ConnectionString.Text) '
      dim command = connection.CreateCommand()
      command.CommandText = sql.ToString()
      Try
         connection.Open()
         reader = command.ExecuteReader()
         ops = New List(Of master_option)
         While reader.Read
            ' adds a new empty option to the end of the list
            ops.Add(New master_option)
            i = ops.Count - 1
            ' sets new option's properties
            ops(i).Id = CInt(reader(mt.Id))
            ops(i).Code = reader(mt.Code).ToString
            ops(i).Description = reader(mt.Description).ToString
            ops(i).long_description = rae.convertNull.ToString(reader(mt.long_description))
            ops(i).Category = reader(mt.Category).ToString
            ops(i).Voltage = CInt(reader(mt.Voltage))
         End While
      Finally
         If reader IsNot Nothing Then reader.Close()
         If connection.State <> ConnectionState.Closed Then connection.Close()
      End Try

      return ops
   end function

end class

end namespace