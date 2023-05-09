Imports System.Data
Imports System.Collections.Generic
Imports Rae.RaeSolutions.Business.Entities
Imports EQ1 = RAE.RAESolutions.DataAccess.Projects.Tables.EquipmentTable
Imports System.Text

Namespace Rae.RaeSolutions.DataAccess.Projects
   Public Class ProcessEquipDA

      Public Shared Sub Create(ByVal ProcessID As String, ByVal EquipmentID As String)
         Dim sql As String
         Dim connection As IDbConnection
         Dim connectionString As String

         connection = Common.CreateConnection(Common.ProjectsDbPath)

         sql = "INSERT INTO ProcessEquip (ProcessID, EquipmentID ) VALUES ("

         'sql = sql + "'" + id + "', "
         '
         sql = sql + "'" + ProcessID + "', "
         '
         sql = sql + "'" + EquipmentID + "'"

         sql = sql + ")"

         Try
            connection.Open()
            Dim command As IDbCommand = connection.CreateCommand
            command.CommandText = sql
            command.ExecuteNonQuery()
         Catch ex As DataException
            Throw
         Finally
            If Not (connection.State = ConnectionState.Closed) Then connection.Close()
         End Try
      End Sub

      'Is it possible to update if ID and ProjectID are the only items?
      Public Shared Sub Update(ByVal processID As String, ByVal equipmentID As String, ByVal ID As Integer)
         'Dim sql As String = SqlFactory.GetUpdateEquipmentSql(process).
         Dim sql As String
         Dim connection As IDbConnection
         Dim connectionString As String

         connection = Common.CreateConnection(Common.ProjectsDbPath)

         sql = "UPDATE ProcessEquip SET "
         sql = sql + "ProcessID = '" + processID + "', "
         sql = sql + "EquipmentID = '" + equipmentID + "' "
         sql = sql + "WHERE ID = '" + ID.ToString + "'"

         Dim command As IDbCommand = connection.CreateCommand
         command.CommandText = sql
         command.ExecuteNonQuery()
      End Sub

      Public Shared Function Exists(ByVal id As String) As Boolean
         Dim connection As IDbConnection
         Dim command As IDbCommand
         Dim reader As IDataReader
         Dim connectionString As String, sql As String
         Dim found As Boolean = False

         connection = Common.CreateConnection(Common.ProjectsDbPath)

         sql = "SELECT * FROM ProcessEquip WHERE ID = '" + id + "'"
         command = connection.CreateCommand
         command.CommandText = sql

         Try
            connection.Open()
            reader = command.ExecuteReader()
            ' checks if project exists
            Dim i As Integer = 0
            While reader.Read
               i += 1
            End While
            If i > 0 Then
               found = True
            End If
            'found = reader.HasRows()
         Catch ex As DataException
            Throw ex
         Finally
            If reader IsNot Nothing Then reader.Close()
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try

         Return found
      End Function


   End Class
End Namespace
