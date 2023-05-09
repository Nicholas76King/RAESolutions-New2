Imports System.Data

Namespace Rae.Data.Access

''' <summary>
''' Basic data access for retrieving a table, a scalar or executing a command.
''' </summary>
Public Class DataAccessBase
   Implements IConnectToDatabase

   ''' <summary>Initializes a new data access base</summary>
   ''' <param name="connectionFactory">Connection factory</param>
   Sub New(connectionFactory As IConnectionFactory)
      _connectionFactory = connectionFactory
   End Sub
   
   
   ReadOnly Property ConnectionFactory As IConnectionFactory _
   Implements IConnectToDatabase.ConnectionFactory
      Get
         Return _connectionFactory
      End Get
   End Property


   ''' <summary>Retrieves an untyped table based on the SQL query</summary>
   ''' <param name="sqlQuery">SQL query that specifies what data to return in the table</param>
   Function RetrieveTable(sqlQuery As String) As DataTable
      Dim connection As IDbConnection = _connectionFactory.Create()
      Dim command As IDbCommand = connection.CreateCommand()
      command.CommandText = sqlQuery

      Dim table As New DataTable()
      Try
         connection.Open()
         table.Load(command.ExecuteReader())
      Finally
         If connection.State <> ConnectionState.Closed Then _
            connection.Close()
      End Try

      Return table
   End Function


   ''' <summary>Executes a non-query</summary>
   ''' <param name="sqlStatement">SQL statement to execute</param>
   Sub ExecuteNonQuery(sqlStatement As String)
      Dim connection As IDbConnection = _connectionFactory.Create()
      Dim command As IDbCommand = connection.CreateCommand()
      command.CommandText = sqlStatement

      Try
         connection.Open()
         command.ExecuteNonQuery()
      Finally
         If connection.State <> ConnectionState.Closed Then _
            connection.Close()
      End Try
   End Sub


   ''' <summary>Retrieves scalar value</summary>
   ''' <typeparam name="T">Type of value being returned from database</typeparam>
   ''' <param name="sqlQuery">SQL query that returns scalar value</param>
   Function ExecuteScalar(Of T)(sqlQuery As String) As T
      Dim connection As IDbConnection = _connectionFactory.Create()
      Dim command As IDbCommand = connection.CreateCommand()
      command.CommandText = sqlQuery

      Dim result As T
      Try
         connection.Open()
         result = CType(command.ExecuteScalar(), T)
      Finally
         If connection.State <> ConnectionState.Closed Then _
            connection.Close()
      End Try

      Return result
   End Function
   
   ''' <summary>Retrieves a scalar value as an object. Value can be DBNull.</summary>
   ''' <remarks>DBNull.ToString() is equal to empty string</remarks>
   Function ExecuteScalar(sqlQuery As String) As Object
      Dim connection As IDbConnection = _connectionFactory.Create()
      Dim command As IDbCommand = connection.CreateCommand()
      command.CommandText = sqlQuery

      Dim result As Object
      Try
         connection.Open()
         result = command.ExecuteScalar()
      Finally
         If connection.State <> ConnectionState.Closed Then _
            connection.Close()
      End Try

      Return result
   End Function
   
   
   ''' <summary>Retrieves a scalar that could be null.</summary>
   ''' <typeparam name="T">Type of scalar</typeparam>
   ''' <param name="sqlQuery">SQL query to retrieve scalar</param>
   Function ExecuteNullableScalar(Of T As Structure)(sqlQuery As String) As Rae.nullable_value(Of T)
      Dim connection As IDbConnection = _connectionFactory.Create()
      Dim command As IDbCommand = connection.CreateCommand()
      command.CommandText = sqlQuery
      
      Dim result As New nullable_value(Of T)
      Try
         connection.Open()
         result.set_to(command.ExecuteScalar())
      Finally
         If connection.State <> ConnectionState.Closed Then _
            connection.Close()
      End Try
      
      Return result
   End Function


   Protected _connectionFactory As IConnectionFactory

End Class

End Namespace
