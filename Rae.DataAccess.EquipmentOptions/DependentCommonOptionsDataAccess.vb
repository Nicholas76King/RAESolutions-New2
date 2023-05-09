Option Strict On
Option Explicit On 

Imports System.Data
Imports System.Text
Imports System.Collections.Generic
' Dependent common options Table
Imports DT = Rae.DataAccess.EquipmentOptions.Tables.DependentCommonOptionsTable


Namespace Rae.DataAccess.EquipmentOptions

   ''' <summary>
   ''' Contains data access methods for the dependent common options table.
   ''' The table contains relationships between dependent options and their parents.
   ''' </summary>
   Public Class DependentCommonOptionsDataAccess


      ''' <summary>
      ''' Retrieves list of possible parent options for the dependent option code
      ''' </summary>
      Public Shared Function RetrieveParentOptions( _
      ByVal dependentCode As String, ByVal series As String) As List(Of [Option])
         Dim parentCode As String
         Dim parentsTable As DataTable
         Dim parentOptions As New List(Of [Option])
         Dim parentOption As [Option]

         ' retrieves parent option relationships
         parentsTable = RetrieveParentOptionRelationships(dependentCode, series)

         For i As Integer = 0 To parentsTable.Rows.Count - 1
            ' gets parameters from table
            parentCode = parentsTable.Rows(i)(DT.ParentCode).ToString
            ' retrieves parent (master) option
            parentOption = master_options_data_access.retrieve_as_options(parentCode)(0)
            ' sets option's equipment series
            parentOption.Equipment.Series = series
            ' adds parent option to list
            parentOptions.Add(parentOption)
         Next

         Return parentOptions
      End Function


      ''' <summary>
      ''' Retrieves list of dependent options for the parent option code parameter
      ''' </summary>
      ''' <remarks>The dependent price is included. Currently does not include quantities</remarks>
      Public Shared Function RetrieveDependentOptions( _
      ByVal parentCode As String, ByVal series As String) As List(Of [Option])
         Dim dependentOptions As New List(Of [Option])
         Dim dependentOption As [Option]
         Dim dependentCode As String
         Dim dependentPrice As Double
         Dim dependentsTable As DataTable

         ' retrieves parent option's dependent option relationships
         dependentsTable = RetrieveDependentOptionRelationship(parentCode, series)

         ' iterates through each row in dependents table
         For i As Integer = 0 To dependentsTable.Rows.Count - 1
            dependentOption = New [Option]

            ' gets option properties from table
            '
            ' gets dependent option code from table
            dependentCode = dependentsTable.Rows(i)(DT.DependentCode).ToString
            ' gets dependent option price from table
            dependentPrice = CDbl(dependentsTable.Rows(i)(DT.DependentPrice))

            ' sets option properties
            '
            ' sets option's equipment series
            dependentOption.Equipment.Series = series
            ' uses the retrieved relationships to retrieve dependent option's general info (not pricing)
            dependentOption.Import(master_options_data_access.retrieve_options(dependentCode)(0))
            ' adds dependent option's price (based upon dependent common option table)
            dependentOption.Price = dependentPrice
            ' adds dependent option to list
            dependentOptions.Add(dependentOption)
         Next

         Return dependentOptions
      End Function


      ''' <summary>
      ''' Not used - Retrieves dependent option
      ''' </summary>
      Public Shared Function RetrieveDependentOption( _
      ByVal dependentCode As String, ByVal parentCode As String, ByVal series As String) As DataRow
         Dim dependentOptionRow As DataRow
         Dim sql As New StringBuilder
         Dim connection As IDbConnection
         Dim adapter As IDbDataAdapter
         Dim ds As New DataSet
         Dim dependentsTable As New DataTable("DependentCommonOptions")

         connection = Data.DataObjects.CreateConnection(ConnectionString.DataAccessType, ConnectionString.Text.Replace("####", My.Computer.Name))
         'connection = Rae.Data.DataObjects.CreateConnection(ConnectionString.DataAccessType, ConnectionString.Text) 'New OleDbConnection(ConnectionString.Text)

         sql.AppendFormat("SELECT * FROM {0} WHERE {1}='{2}' AND {3}='{4}' AND {5}='{6}'", _
            DT.TableName, DT.DependentCode, dependentCode, DT.ParentCode, parentCode, DT.Series, series)
         adapter = Rae.Data.DataObjects.CreateAdapter(ConnectionString.DataAccessType) 'New OleDbDataAdapter(sql.ToString, connection)
         adapter.SelectCommand = connection.CreateCommand()
         adapter.SelectCommand.CommandText = sql.ToString
         Try
            connection.Open()
            ' fills table with all possible pairs of the dependent option and parent options
            adapter.Fill(ds)
         Catch ex As DataException
            Throw ex
         Finally
            If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try
         dependentsTable = ds.Tables(0)
         If dependentsTable.Rows.Count > 0 Then
            ' sets dependent option
            dependentOptionRow = dependentsTable.Rows(0) : End If

         Return dependentOptionRow
      End Function




      ''' <summary>
      ''' There is no need for a constructor; all methods are shared.
      ''' </summary>
      Private Sub New()
      End Sub


      ''' <summary>Retrieves the parent option's dependent option relationships</summary>
      Private Shared Function RetrieveDependentOptionRelationship( _
      ByVal parentCode As String, ByVal series As String) As DataTable
         Dim sql As New StringBuilder
         Dim connection As IDbConnection
         Dim adapter As IDbDataAdapter
         Dim ds As New DataSet
         Dim dependentsTable As New DataTable("DependentCommonOptions")

         connection = Data.DataObjects.CreateConnection(ConnectionString.DataAccessType, ConnectionString.Text.Replace("####", My.Computer.Name))
         'connection = Rae.Data.DataObjects.CreateConnection(ConnectionString.DataAccessType, ConnectionString.Text) 'New OleDbConnection(ConnectionString.Text)

         sql.AppendFormat("SELECT * FROM {0} WHERE {1}='{2}' AND {3}='{4}'", _
            DT.TableName, DT.ParentCode, parentCode, DT.Series, series)
         'adapter = New OleDbDataAdapter(sql.ToString, connection)
         adapter = Rae.Data.DataObjects.CreateAdapter(ConnectionString.DataAccessType) 'New OleDbDataAdapter(sql.ToString, connection)
         adapter.SelectCommand = connection.CreateCommand()
         adapter.SelectCommand.CommandText = sql.ToString
         Try
            connection.Open()
            ' fills table with all possible pairs of the dependent option and parent options
            adapter.Fill(ds)
         Catch ex As DataException
            Throw ex
         Finally
            If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try

         Return ds.Tables(0) 'dependentsTable
      End Function


      ''' <summary>Retrieves the dependent option's parent option relationships</summary>
      ''' <remarks>Retrieves information for parent options</remarks>
      ''' <param name="dependentCode">Option code of the option that is dependent upon another option.</param>
      ''' <param name="series">Series of the equipment that the option is for</param>
      Private Shared Function RetrieveParentOptionRelationships( _
      ByVal dependentCode As String, ByVal series As String) As DataTable
         Dim sql As New StringBuilder
         Dim connection As IDbConnection
         Dim adapter As IDbDataAdapter
         Dim ds As New DataSet
         Dim table As New DataTable("DependentCommonOptions")

            connection = Data.DataObjects.CreateConnection(ConnectionString.DataAccessType, ConnectionString.Text.Replace("####", My.Computer.Name))
         'connection = Rae.Data.DataObjects.CreateConnection(ConnectionString.DataAccessType, ConnectionString.Text) ' OleDbConnection(ConnectionString.Text)

         sql.AppendFormat("SELECT * FROM {0} WHERE {1}='{2}' AND {3}='{4}'", _
            DT.TableName, DT.DependentCode, dependentCode, DT.Series, series)
         'adapter = New OleDbDataAdapter(sql.ToString, connection)
         adapter = Rae.Data.DataObjects.CreateAdapter(ConnectionString.DataAccessType) 'New OleDbDataAdapter(sql.ToString, connection)
         adapter.SelectCommand = connection.CreateCommand()
         adapter.SelectCommand.CommandText = sql.ToString
         Try
            connection.Open()
            ' fills table with all possible pairs of the dependent option and parent options
            adapter.Fill(ds)
         Catch ex As DataException
            Throw ex
         Finally
            If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try

         Return ds.Tables(0) 'table
      End Function


   End Class


End Namespace