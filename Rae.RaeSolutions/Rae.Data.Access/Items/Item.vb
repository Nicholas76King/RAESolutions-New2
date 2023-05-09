Imports System.Collections.Generic
Imports System.Data

Namespace Rae.Data.Access

''' <summary>
''' Item data access
''' </summary>
Public Class Item(Of DtoT As IItemDto)
   Inherits DataAccessBase
   Implements IItemDataAccess(Of DtoT)


   ''' <summary>
   ''' Initializes a new instance of item data access
   ''' </summary>
   ''' <param name="connectionFactory">
   ''' Connection factory to create connection
   ''' </param>
   ''' <param name="tableName">
   ''' Table name
   ''' </param>
   Sub New(connectionFactory As ConnectionFactory, tableName As String)
      MyBase.New(connectionFactory)
      Me.tableName = tableName
   End Sub


   ''' <summary>
   ''' Returns true if item exists
   ''' </summary>
   ''' <param name="itemId">
   ''' Item ID
   ''' </param>
   ''' <param name="itemRevision">
   ''' Item revision
   ''' </param>
   Function Exists(itemId As String, itemRevision As Integer) As Boolean _
   Implements IItemDataAccess(Of DtoT).Exists
      Dim connection As IDbConnection = connectionFactory.Create()
      Dim command As IDbCommand = connection.CreateCommand()
      command.CommandText = New ItemSql(tableName).Count(itemId, itemRevision)

      Dim count As Integer
      Try
         connection.Open()
         count = CInt(command.ExecuteScalar)
      Finally
         If connection.State <> ConnectionState.Closed Then _
            connection.Close()
      End Try

      Return (count = 1)
   End Function


   ''' <summary>
   ''' Deletes an item including all its revisions
   ''' </summary>
   ''' <param name="itemId">
   ''' ID of item to delete
   ''' </param>
   Sub Delete(itemId As String) _
   Implements IItemDataAccess(Of DtoT).Delete
      Dim connection As IDbConnection = connectionFactory.Create()
      Dim command As IDbCommand = connection.CreateCommand()
      command.CommandText = New ItemSql(tableName).Delete(itemId)

      Try
         connection.Open()
         command.ExecuteNonQuery()
      Finally
         If connection.State <> ConnectionState.Closed Then _
            connection.Close()
      End Try
   End Sub


   ''' <summary>
   ''' Saves the item. Inserts if item does NOT exists. Updates if item does exist.
   ''' </summary>
   ''' <param name="dto">
   ''' Data transfer object
   ''' </param>
   ''' <returns>
   ''' Database ID
   ''' </returns>   
   Function Save(dto As DtoT) As Integer _
   Implements IItemDataAccess(Of DtoT).Save
      Dim id As Integer

      If Exists(dto.ItemId, dto.ItemRevision) Then
         Update(dto)
         id = dto.Id
      Else
         id = Insert(dto)
      End If

      Return id
   End Function


   ''' <summary>
   ''' Retrieves revisions for an item
   ''' </summary>
   ''' <param name="itemId">
   ''' Item ID
   ''' </param>
   Function Revisions(itemId As String) As List(Of Integer)
      Dim connection As IDbConnection = connectionFactory.Create()
      Dim command As IDbCommand = connection.CreateCommand()
      command.CommandText = New ItemSql(tableName).Revisions(itemId)
      Dim reader As IDataReader

      Dim revisions_ As New List(Of Integer)()
      Dim revision As Integer
      Try
         connection.Open()
         reader = command.ExecuteReader()
         While reader.Read()
            revision = CInt(reader(ItemTable.ItemRevision))
            revisions_.Add(revision)
         End While
      Finally
         If reader Is Nothing Then _
        reader.Close()
         If connection.State = ConnectionState.Closed Then _
        connection.Close()
      End Try

      Return revisions_
   End Function


   ''' <summary>
   ''' True if revision is the latest revision
   ''' </summary>
   ''' <param name="itemId">
   ''' ID of the item to compare
   ''' </param>
   ''' <param name="revision">
   ''' Revision to compare
   ''' </param>
   Function IsLatest(itemId As String, revision As Integer) As Boolean
      Return Latest(itemId) = revision
   End Function


   ''' <summary>
   ''' Retrieves the latest revision of the item
   ''' </summary>
   ''' <param name="itemId">
   ''' ID of the item whose latest revision will be retrieved
   ''' </param>
   Function Latest(itemId As String) As Integer
      Dim connection As IDbConnection = connectionFactory.Create()
      Dim command As IDbCommand = connection.CreateCommand()
      command.CommandText = New ItemSql(tableName).Latest(itemId)

      Dim latestRevision As Integer
      Try
         connection.Open()
         latestRevision = CInt(command.ExecuteScalar())
      Finally
         If connection.State <> ConnectionState.Closed Then _
        connection.Close()
      End Try

      Return latestRevision
   End Function
   
   Function ItemIds(projectId As String) As List(Of String)
      Dim connection As IDbConnection = connectionFactory.Create()
      Dim command As IDbCommand = connection.CreateCommand()
      command.CommandText = New ItemSql(tableName).ItemIds(projectId)
      Dim reader As IDataReader
      
      Dim ids As New List(Of String)()
      Dim id As String
      Try
         connection.Open()
         reader = command.ExecuteReader()
         While reader.Read()
            id = reader(ItemTable.ItemId).ToString()
            ids.Add(id)
         End While
      Finally
         If reader IsNot Nothing Then _
            reader.Close()
         If connection.State <> ConnectionState.Closed Then _
            connection.Close()
      End Try
      
      Return ids
   End Function



   Protected tableName As String


   Overridable Function Insert(dto As DtoT) As Integer _
   Implements IItemDataAccess(Of DtoT).Insert
      Throw New NotImplementedException()
   End Function

   Overridable Function Retrieve(itemId As String) As DtoT _
   Implements IItemDataAccess(Of DtoT).Retrieve
      Throw New NotImplementedException()
   End Function

   Overridable Function Retrieve(itemId As String, itemRevision As Integer) As DtoT _
   Implements IItemDataAccess(Of DtoT).Retrieve
      Throw New NotImplementedException()
   End Function

   Overridable Sub Update(dto As DtoT) _
   Implements IItemDataAccess(Of DtoT).Update
      Throw New NotImplementedException()
   End Sub

End Class

End Namespace