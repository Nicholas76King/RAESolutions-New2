Imports System.Collections.Generic
Imports System.Data
Imports System.Text
Imports T1 = IdentitiesTable

Namespace Rae.Data.Access

''' <summary>
''' Provides data access to database containing identities.
''' </summary>
Public Class Identities
   Implements IConnectToDatabase
   
   Sub New(connectionFactory As IConnectionFactory)
      _connectionFactory = connectionFactory
   End Sub
   
   ReadOnly Property ConnectionFactory As IConnectionFactory _
   Implements IConnectToDatabase.ConnectionFactory
      Get
         Return _connectionFactory
      End Get
   End Property
   
   Function RetrieveEmployeeUsernames() As List(Of String)
      Dim sql As New StringBuilder()
            sql.AppendFormat("SELECT [{0}] FROM [{1}] WHERE {0} NOT LIKE '% %'",
         T1.Username, T1.Table_Name)

            Dim usernames As List(Of String) = retrieveUsernames(sql.ToString)

      Return usernames
   End Function
   
   Function RetrieveRepUsernames() As List(Of String)
      Dim sql As New StringBuilder()
            sql.AppendFormat("SELECT [{0}] FROM [{1}] WHERE [{0}] LIKE '% %'",
         T1.Username, T1.Table_Name)

            Dim usernames As List(Of String) = retrieveUsernames(sql.ToString)

      Return usernames
   End Function
   
#Region " Internal"
   
   Protected _connectionFactory As IConnectionFactory
   
   Private Function retrieveUsernames(sql As String) As List(Of String)
      Dim usernames As New List(Of String)

      Using connection As IDbConnection = connectionFactory.Create()
      Using command As IDbCommand = connection.CreateCommand()
         connection.Open()
         command.CommandText = sql
         Using reader As IDataReader = command.ExecuteReader()
            While reader.Read()
               usernames.Add(reader(0).ToString)
            End While
         End Using
      End Using
      End Using
      
      Return usernames
   End Function
   
#End Region

End Class

End Namespace