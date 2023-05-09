Imports System
Imports System.Data
Imports System.Text
Imports Rae.RaeSolutions.Business.Entities

Namespace Rae.RaeSolutions.DataAccess.Projects

   Public Class CommonEquipmentDa

      ''' <summary>
      ''' True if equipment exists in database.
      ''' </summary>
      ''' <param name="id">
      ''' Equipment ID.
      ''' </param>
      ''' <returns>
      ''' True if equipment exists; else false.
      ''' </returns>
      Public Overloads Shared Function Exists(ByVal id As item_id, ByVal tableName As String) As Boolean
         Dim connection As IDbConnection, command As IDbCommand, reader As IDataReader
         Dim sql As New StringBuilder, connectionString As String
         Dim isFound As Boolean = False

         sql.AppendFormat("SELECT [{0}] FROM [{1}] WHERE [{0}]='{2}'", _
            "EquipmentId", Tables.EquipmentTable.TableName, id.ToString)
         connectionString = Common.GetConnectionString(Common.ProjectsDbPath)

         connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)

         command = connection.CreateCommand 'New OleDbCommand(sql, connection)
         command.CommandText = sql.ToString

         Try
            connection.Open()
            reader = command.ExecuteReader()
            Dim i As Integer = 0
            While reader.Read
               i += 1
            End While
            If i > 0 Then
               isFound = True
            End If
            'isFound = reader.HasRows
         Catch ex As Exception
            Throw ex
         Finally
            If reader IsNot Nothing Then reader.Close()
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try

         Return isFound
      End Function


      ''' <summary>
      ''' True if equipment exists in database.
      ''' </summary>
      ''' <returns>
      ''' True if equipment exists; else false.
      ''' </returns>
      Public Overloads Shared Function Exists(ByVal equipment As EquipmentItem, ByVal tableName As String) As Boolean
         Return Exists(equipment.id, tableName)
      End Function

   End Class

End Namespace