Imports System.Data
Imports System.Text
Imports Pct = Rae.RaeSolutions.DataAccess.Projects.Tables.ProjectContactsTable

Namespace Rae.RaeSolutions.DataAccess.Projects

   ''' <summary>
   ''' Provides data access to project and contact relationships
   ''' </summary>
   Public Class ProjectContactsDataAccess

#Region " ProjectContacts"

      ''' <summary>
      ''' Deletes the contact from the project
      ''' </summary>
      ''' <param name="projectId">
      ''' Project ID
      ''' </param>
      ''' <param name="contactId">
      ''' Contact ID
      ''' </param>
      Public Shared Sub Delete(ByVal projectId As String, ByVal contactId As Integer)
         Dim connection As iDbConnection
         Dim command As iDbCommand
         Dim connectionString As String, sql As New StringBuilder

         connection = Common.CreateConnection(Common.ProjectsDbPath) 

         sql.AppendFormat("delete FROM [{0}] where [{1}] = {4} and [{2}] = '{3}'", _
            Pct.TableName, Pct.ContactId, Pct.ProjectId, projectId, contactId.ToString())
         command = connection.CreateCommand
         command.CommandText = sql.ToString

         Try
            connection.Open()
            Dim numAffectedRows As Integer = command.ExecuteNonQuery()
         Catch ex As dataException '
            Throw ex
         Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try

      End Sub


      ''' <summary>
      ''' Deletes all the contacts from the project
      ''' </summary>
      ''' <param name="projectId">
      ''' ID of project to delete contacts from
      ''' </param>
      Public Shared Sub Delete(ByVal projectId As String)
         Dim connection As iDbConnection
         Dim command As iDbCommand
         Dim connectionString As String, sql As New StringBuilder

         connection = Common.CreateConnection(Common.ProjectsDbPath) 

         sql.AppendFormat("delete FROM [{0}] where [{1}] = '{2}'", _
            Pct.TableName, Pct.ProjectId, projectId)
         command = connection.CreateCommand
         command.CommandText = sql.ToString

         Try
            connection.Open()
            command.ExecuteNonQuery()
         Catch ex As dataException
            Throw ex
         Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try

      End Sub


      ''' <summary>
      ''' Indicates whether a contact is in a project
      ''' </summary>
      ''' <param name="projectId">
      ''' Project ID
      ''' </param>
      ''' <param name="contactId">
      ''' Contact ID
      ''' </param>
      Public Shared Function Exists(ByVal projectId As String, ByVal contactId As Integer) As Boolean
         Dim connectionString As String = Common.GetConnectionString(Common.ProjectsDbPath)
         Dim connection As IDbConnection = Common.CreateConnection(Common.ProjectsDbPath)
         Dim sql As New StringBuilder()
         sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}] = '{3}' and [{2}] = {4}", _
            Pct.TableName, Pct.ProjectId, Pct.ContactId, projectId, contactId.ToString)
         Dim command As IDbCommand = connection.CreateCommand
         command.CommandText = sql.ToString

         Dim reader As iDataReader
         Dim found As Boolean = False
         Try
            connection.Open()
            reader = command.ExecuteReader()
            Dim i As Integer = 0
            While reader.Read
               i += 1
            End While
            If i > 0 Then
               found = True
            End If
            'found = reader.HasRows()
         Catch ex As dataException
            Throw ex
         Finally
            If reader IsNot Nothing Then reader.Close()
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try

         Return found
      End Function


      ''' <summary>
      ''' Adds a contact to a project
      ''' </summary>
      ''' <param name="projectId">
      ''' ID of project to add contact to
      ''' </param>
      ''' <param name="contactId">
      ''' ID of contact to add to project
      ''' </param>
      Public Shared Sub Create(ByVal projectId As String, ByVal contactId As Integer)
         Dim connection As iDbConnection
         Dim command As iDbCommand
         Dim connectionString As String, sql As New StringBuilder

         connection = Common.CreateConnection(Common.ProjectsDbPath) 

         sql.AppendFormat("INSERT INTO [{0}] ([{1}], [{2}]) VALUES ({3}, '{4}')", _
            Pct.TableName, Pct.ContactId, Pct.ProjectId, contactId.ToString(), projectId)
         command = connection.CreateCommand
         command.CommandText = sql.ToString

         Try
            connection.Open()
            Dim numRowsAffected As Integer = command.ExecuteNonQuery()
         Catch ex As dataException '
            Throw ex
         Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try

      End Sub

#End Region

   End Class

End Namespace