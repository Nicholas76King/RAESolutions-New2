Imports Rae.Collections
Imports Rae.RaeSolutions.DataAccess.Common
Imports System.Data

Namespace Rae.Data.Access

''' <summary>
''' Connection factory creates a connection to a database.
''' </summary>
''' <remarks>
''' <para>
''' SQL Server Connection String
''' Server:
''' Data Source=[ServerPath]; Initial Catalog=[DataBase]; User Id=[Username]; Password=[Password];
''' Data Source=Fileserver1; Initial Catalog=RAESolutions; User Id=admin; Password=pass;
''' Local:
''' Data Source=[ComputerName\InstanceName]; Initial Catalog=[Database];
''' Data Source=RAE690\SQLExpress; Initial Catalog=RAESolutions;
''' </para>
''' <para>
''' Microsoft Access Connection String
''' Data Source=[FilePath]; Provider=[Provider];
''' Data Source=C:\Program Files\RAESolutions\Databases\Projects.mdb; Provider=Microsoft.Jet.OLEDB.4.0;
''' </para>
''' </remarks>
Public Class ConnectionFactory
   Implements IConnectionFactory
   
   ''' <summary>Initializes connection factory with connection string.</summary>
   ''' <param name="connectionString">Connection string</param>
   Sub New(connectionString As String)
      Me.connectionString = connectionString
   End Sub
   
   ''' <summary>
   ''' Creates a connection based on the connection string provided in the constructor.
   ''' </summary>
   Function Create() As IDbConnection _
   Implements IConnectionFactory.Create
      Return create(Me.connectionString)
   End Function
   
   
   
   
   Private connectionString As String
   
   Private Function create(connectionString As String) As IDbConnection
      Dim connection As IDbConnection
      
      'determine if for SQL Server or Access
      If isAccess(connectionString) Then
         connection = New OleDb.OleDbConnection(connectionString)
      Else ' assume SQL
         connection = New SqlClient.SqlConnection(connectionString)
      End If
      
      Return connection
   End Function
   
   Private Function isAccess(connectionString As String) As Boolean
      Return connectionString.ToUpper.Contains("PROVIDER")
   End Function

End Class

End Namespace