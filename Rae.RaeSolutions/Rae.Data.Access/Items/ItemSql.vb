Imports Rae.Data.Sql
Imports System.Text

Namespace Rae.Data.Access

''' <summary>
''' Builds SQL statements for items
''' </summary>
Public Class ItemSql

   ''' <summary>
   ''' Initializes a new item SQL
   ''' </summary>
   ''' <param name="tableName"></param>
   ''' <remarks></remarks>
   Sub New(tableName As String)
      tableName_ = tableName
   End Sub


   ''' <summary>
   ''' Name of the table containing the items
   ''' </summary>
   ReadOnly Property TableName() As String
      Get
         Return tableName_
      End Get
   End Property


   ''' <summary>
   ''' SQL statement that retrieves the number of items with the item ID and revision.
   ''' Shouldn't be more than one.   
   ''' </summary>
   ''' <param name="itemId">
   ''' Item ID
   ''' </param>
   ''' <param name="itemRevision">
   ''' Item revision
   ''' </param>
   Function Count(itemId As String, itemRevision As Integer) As String
      Dim sql As New StringBuilder()

      sql.AppendFormat("SELECT COUNT({0}) FROM {1} WHERE {0}='{2}' AND {3}={4}", _
         ItemTable.ItemId, tableName_, itemId, _
         ItemTable.ItemRevision, itemRevision)

      Return sql.ToString
   End Function


   ''' <summary>
   ''' SQL statement that retrieves item revisions based on the item ID.
   ''' </summary>
   ''' <param name="itemId">
   ''' Item ID
   ''' </param>
   Function Revisions(itemId As String) As String
      Dim sql As New StringBuilder()

      sql.AppendFormat("SELECT [{0}] FROM [{1}] WHERE [{2}]='{3}'", _
         ItemTable.ItemRevision, TableName, ItemTable.ItemId, itemId)

      Return sql.ToString
   End Function


   ''' <summary>
   ''' Retrieves latest revision
   ''' </summary>
   ''' <param name="itemId">
   ''' Item ID
   ''' </param>
   Function Latest(itemId As String) As String
      Dim sql As New StringBuilder()

      sql.AppendFormat("SELECT MAX({0}) FROM [{1}] WHERE [{2}]='{3}'", _
         ItemTable.ItemRevision, TableName, ItemTable.ItemId, itemId)

      Return sql.ToString()
   End Function


   ''' <summary>
   ''' SQL statement that deletes an item including all its revisions.
   ''' </summary>
   ''' <param name="itemId">
   ''' ID of item to delete
   ''' </param>
   Function Delete(itemId As String) As String
      Dim sql As New StringBuilder()

      sql.AppendFormat("DELETE * FROM [{0}] WHERE [{1}]='{2}'", _
         TableName, ItemTable.ItemId, itemId)

      Return sql.ToString()
   End Function


   ''' <summary>
   ''' SQL statement that retrieves an item
   ''' </summary>
   ''' <param name="itemId">
   ''' ID of item to retrieve
   ''' </param>
   ''' <param name="itemRevision">
   ''' Revision of item to retrieve
   ''' </param>
   Function Retrieve(itemId As String, itemRevision As Integer) As String
      Dim sql As New StringBuilder()
      sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}]='{2}' AND [{3}]={4}", _
         TableName, ItemTable.ItemId, itemId, ItemTable.ItemRevision, itemRevision.ToString)
      Return sql.ToString()
   End Function


   ''' <summary>
   ''' SQL statement to retrieve the ID that was just inserted.
   ''' </summary>
   ''' <param name="columnName">
   ''' ID column
   ''' </param>
   Function Id(columnName As String) As String
      Dim sql As New StringBuilder
      sql.AppendFormat("SELECT MAX({0}) FROM {1}", _
         columnName, TableName)
      Return sql.ToString
   End Function

   ''' <summary>
   ''' SQL statement that retrieves the ID that was just inserted.
   ''' Assumes column name is ID.
   ''' </summary>
   Function Id() As String
      Return Id("Id")
   End Function
   
   
   Function ItemIds(projectId As String) As String
      Dim sql As New StringBuilder()
      sql.AppendFormat("SELECT DISTINCT {0} FROM {1} WHERE {2}='{3}'", _
         ItemTable.ItemId, TableName, ItemTable.ProjectId, projectId)
      Return sql.ToString()
   End Function


   Protected tableName_ As String

End Class

End Namespace
