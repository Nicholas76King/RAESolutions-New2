Imports Rae.Data.Sql
Imports Rae.Data.Access.ConnectionName
Imports System.Collections.Generic
Imports System.Data
Imports System.Text
Imports Table = Rae.Data.Access.BoxLoadProjectsTable

Namespace Rae.Data.Access

Public Structure OverrideData
   Public Id As Integer
   Public LoadTot As Integer
   Public RunTime As String
   Public Ambient As String
   Public RmTemp As String
   Public UserCapacity As String
   Public UserCapacityChecked As Boolean
   Public BlName As String
End Structure


''' <summary>
''' Box load data access
''' </summary>
Public Class BoxLoadProjects
   Inherits Item(Of BoxLoadDto)

   
#Region " Links"


   ''' <summary>
   ''' Returns true if box load is linked
   ''' </summary>
   ''' <param name="dbId">
   ''' Box load database ID
   ''' </param>
   Function IsLinked(dbId As Integer) As Boolean
      Dim sql As New StringBuilder()
      sql.AppendFormat("SELECT {0} FROM {1} WHERE {2}={3}", _
         Table.LinkedItemId, Table.TableName, Table.Id, dbId.ToString)
         
      Dim linkedItemId As String
      linkedItemId = ExecuteScalar(sql.ToString).ToString
      
      Return (Not String.IsNullOrEmpty(linkedItemId))
   End Function
   
   
   ''' <summary>
   ''' Retrieves database ID for box load with linked item.
   ''' </summary>
   Function RetrieveDbId(linkedItemId As String, linkedItemRevision As Single) As nullable_value(Of Integer)
      Dim sql As New StringBuilder()
      ' workaround for item revision not getting set on first save in  balance form
      If linkedItemRevision = 0.001! Then
         linkedItemRevision = 0
      End If
      sql.AppendFormat("SELECT {0} FROM {1} WHERE {2}='{3}' AND {4}={5}", _
         Table.Id, Table.TableName, Table.LinkedItemId, linkedItemId, _
         Table.LinkedItemRevision, linkedItemRevision)
         
      Dim dbId As New nullable_value(Of Integer)
      dbId = ExecuteNullableScalar(Of Integer)(sql.ToString)
      Return dbId
   End Function
   
   Sub UpdateLink(boxLoadId As Integer, linkedItemId As String, linkedItemRevision As Integer)
      Dim connection As IDbConnection = connectionFactory.Create()
      Dim command As IDbCommand = connection.CreateCommand()
      Dim sql As New StringBuilder()
      sql.AppendFormat("UPDATE {0} SET {1}='{2}', {3}={4} WHERE {5}={6}", _
         Table.TableName, Table.LinkedItemId, linkedItemId, _
         Table.LinkedItemRevision, linkedItemRevision.ToString, _
         Table.Id, boxLoadId.ToString)
      command.CommandText = sql.ToString
      
      Try
         connection.Open()
         command.ExecuteNonQuery()
      Finally
         If connection.State <> ConnectionState.Closed Then _
            connection.Close()
      End Try
   End Sub
   
   
   Sub DeleteLink(boxLoadId As Integer)
      UpdateLink(boxLoadId, "", 0)
   End Sub
   
   
   Function RetrieveLinkData(linkedItemId As String, linkedItemRevision As Single) As OverrideData
      Dim connection As IDbConnection = connectionFactory.Create()
      Dim command As IDbCommand = connection.CreateCommand()
      Dim sql As New StringBuilder()
      sql.AppendFormat("SELECT * FROM {0} WHERE {1}='{2}' AND {3}={4}", _
         Table.TableName, Table.LinkedItemId, linkedItemId, _
         Table.LinkedItemRevision, linkedItemRevision.ToString)
      command.CommandText = sql.ToString
      
      Dim reader As IDataReader
      Dim b As OverrideData
      Try
         connection.Open()
         reader = command.ExecuteReader()
         If reader.RecordsAffected = 0 AndAlso linkedItemRevision = 0.001! Then
            reader.Close()
            connection.Close()
            Return RetrieveLinkData(linkedItemId, 0)
         End If
         While reader.Read()
            b.Id = CInt(reader(Table.Id))
            b.LoadTot = CInt(reader(Table.LoadTot))
            b.UserCapacity = reader(Table.UserCapacity).ToString
            b.UserCapacityChecked = CBool(reader(Table.UserCapacityChecked))
            b.RunTime = reader(Table.RunVar).ToString
            b.Ambient = reader(Table.Ambient).ToString
            b.RmTemp = reader(Table.RmTemp).ToString
            b.BlName = reader(Table.BlName).ToString
         End While
      Finally
         If reader IsNot Nothing Then _
            reader.Close()
         If connection.State <> ConnectionState.Closed Then _
            connection.Close()
      End Try
      
      Return b
   End Function

#End Region
   

   ''' <summary>
   ''' Initializes new data access for box load project
   ''' </summary>
   Sub New()
      MyBase.New(New ConnectionFactory( _
         New Connection().Choose(ConnectionName.Projects).ConnectionString), _
         table_Name)
   End Sub


   ''' <summary>
   ''' Retrieves latest revision.
   ''' </summary>
   ''' <param name="itemId">
   ''' Item ID
   ''' </param>
   Overrides Function Retrieve(itemId As String) As BoxLoadDto
      Dim latestRevision As Integer
      latestRevision = Latest(itemId)

      Dim dto As BoxLoadDto
      dto = Retrieve(itemId, latestRevision)

      Return dto
   End Function

   ''' <summary>
   ''' Retrieves item at specific revision
   ''' </summary>
   ''' <param name="itemId">
   ''' ID of item to retrieve
   ''' </param>
   ''' <param name="itemRevision">
   ''' Revision of item to retrieve
   ''' </param>
   Overrides Function Retrieve(itemId As String, itemRevision As Integer) As BoxLoadDto
      Dim connection As IDbConnection = connectionFactory.Create()
      Dim command As IDbCommand = connection.CreateCommand
      Dim reader As IDataReader

      Dim dto As New BoxLoadDto()
      Try
         connection.Open()
         command.CommandText = New ItemSql(tableName).Retrieve(itemId, itemRevision)
         reader = command.ExecuteReader()
         While reader.Read
            dto.GetValuesFrom(reader)
         End While
      Catch ex As Exception
         Throw New DataException("Attempt to retrieve box load failed. " & ex.Message, ex)
      Finally
         If reader IsNot Nothing Then reader.Close()
         If connection.State <> ConnectionState.Closed Then connection.Close()
      End Try
      
      Return dto
   End Function
   
   
   Overloads Function RetrieveTable(dbId As Integer) As DataTable
      Dim sql As String = BoxLoadProjectsSql.Retrieve(dbId)
         
      Return RetrieveTable(sql.ToString)
   End Function
   
   Overloads Function Retrieve(dbId As Integer) As BoxLoadDto
      Dim connection As IDbConnection = connectionFactory.Create()
      Dim command As IDbCommand = connection.CreateCommand
      Dim reader As IDataReader

      Dim dto As New BoxLoadDto()
      Try
         connection.Open()
         command.CommandText = BoxloadProjectsSql.Retrieve(dbId)
         reader = command.ExecuteReader()
         While reader.Read
            dto.GetValuesFrom(reader)
         End While
      Catch ex As Exception
         Throw New DataException("Attempt to retrieve box load failed. " & ex.Message, ex)
      Finally
         If reader IsNot Nothing Then _
            reader.Close()
         If connection.State <> ConnectionState.Closed Then _
            connection.Close()
      End Try
      
      Return dto
   End Function


   ''' <summary>
   ''' Inserts a new box load
   ''' </summary>
   ''' <param name="dto">
   ''' Box load data transfer object
   ''' </param>
   Overrides Function Insert(dto As BoxLoadDto) As Integer
      Dim con As IDbConnection = New Connection().Choose(Projects)
      Dim com As IDbCommand
      Dim tra As IDbTransaction
      Dim id As Integer

      Try
         con.Open()
         tra = con.BeginTransaction

         com = con.CreateCommand
         com.Transaction = tra
         com.CommandText = BoxLoadProjectsSql.Insert(dto)
         com.ExecuteNonQuery()

         com.CommandText = New ItemSql(tableName).Id()
         id = CInt(com.ExecuteScalar)

         tra.Commit()
      Catch ex As Exception
         tra.Rollback()
         Throw New DataException("Attempt to insert box load failed. " & ex.Message, ex)
      Finally
         If con.State <> ConnectionState.Closed Then con.Close()
      End Try

      Return id
   End Function


   ''' <summary>
   ''' Updates existing box load
   ''' </summary>
   ''' <param name="dto">
   ''' Box laod data transer object
   ''' </param>
   Overrides Sub Update(dto As BoxLoadDto)
      Dim connection As IDbConnection = connectionFactory.Create()
      Dim command As IDbCommand = connection.CreateCommand
      command.CommandText = BoxLoadProjectsSql.Update(dto)
      Try
         connection.Open()
         command.ExecuteNonQuery()
      Catch ex As Exception
         Throw New DataException("The attempt to update the box load failed. " & ex.Message, ex)
      Finally
         If connection.State <> ConnectionState.Closed Then connection.Close()
      End Try
   End Sub


   Function RetrieveBoxLoadInfo(openProjectId As String) As DataTable
      Dim sql As New StringBuilder()
      
      sql.AppendFormat("SELECT {0} As 'Box Load Name', {1}, {2}, {3} FROM {4} WHERE {3}='{5}' AND ({6} IS NULL OR {6}='') ORDER BY {0}", _
         Table.BlName, Table.Description, Table.Id, Table.ProjectId, Table.TableName, openProjectId, Table.LinkedItemId)
      
      Return Me.RetrieveTable(sql.ToString())
   End Function
   

   ''' <summary>
   ''' Deletes a specified item based on its unique database ID.
   ''' </summary>
   ''' <param name="id">
   ''' Unique database ID
   ''' </param>
   Overloads Sub Delete(id As Integer)
      Dim sql As New StringBuilder()
      
      sql.AppendFormat("DELETE * FROM {0} WHERE {1}={2}", _
         Table.TableName, Table.Id, id.ToString)
         
      ExecuteNonQuery(sql.ToString)
   End Sub


   Private Const table_Name As String = "CoolStuffProjects"

End Class

End Namespace
