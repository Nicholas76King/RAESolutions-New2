Option Strict On
Option Explicit On 

Imports System.Data
Imports System.Collections.Generic
Imports Common = Rae.RaeSolutions.DataAccess.Common


Namespace Rae.RaeSolutions.DataAccess

   ''' <summary>Air handler in Data Access Layer</summary>
   Public Class AirHandlers


      ''' <summary>Retrieves list of distinct, housed forward curved fan sizes.
      ''' </summary>
      Public Shared Function RetrieveForwardCurvedFanSizes() As System.Collections.Specialized.StringCollection
         Dim connectionString, sqlCommand As String
         Dim connection As IDbConnection
         Dim command As IDbCommand
         Dim reader As IDataReader
         Dim fanSizes As System.Collections.Specialized.StringCollection

         sqlCommand = "SELECT DISTINCT [Size] FROM ForwardCurvedFans"
         connectionString = Common.GetConnectionString(Common.AirHandlerDbPath)

         connection = Common.CreateConnection(Common.AirHandlerDbPath) 'New OleDbConnection(connectionString)
         command = connection.CreateCommand 'New OleDbCommand(sqlCommand, connection)
         command.CommandText = sqlCommand
         fanSizes = New System.Collections.Specialized.StringCollection

         Try
            connection.Open()
            reader = command.ExecuteReader()

            While reader.Read
               fanSizes.Add(reader.GetString(0))
            End While
         Catch ex As DataException
            Throw
         Finally
            If Not reader Is Nothing Then reader.Close()
            If Not connection.State.Equals(System.Data.ConnectionState.Closed) Then connection.Close()
         End Try

         Return fanSizes
      End Function


      ''' <summary>Retrieves table of hours required for an air handler model to be manufactured.
      ''' </summary>
      Public Shared Function RetrieveHours(ByVal model As String) As DataTable
         Dim connectionString, sqlCommand As String
         Dim connection As IDbConnection
         Dim adapter As IDbDataAdapter
         Dim hoursTable As DataTable
         Dim ds As New DataSet

         connectionString = Common.GetConnectionString(Common.AirHandlerDbPath)
         sqlCommand = "SELECT * FROM Hours WHERE [Model] = '" & model & "'"

         connection = Common.CreateConnection(Common.AirHandlerDbPath) 'New OleDbConnection(connectionString)
         Dim cmd As IDbCommand = connection.CreateCommand
         cmd.CommandText = sqlCommand
         adapter = Common.CreateAdapter(cmd) 'New OleDbDataAdapter(sqlCommand, connection)
         hoursTable = New DataTable("Hours")

         Try
            connection.Open()
            adapter.Fill(ds)
         Catch ex As DataException
            Throw
         Finally
            If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try

         Return ds.Tables(0)
      End Function


      ''' <summary>Retrieves motor based on parameters</summary>
      Public Shared Function RetrieveMotor(ByVal efficiency As String, ByVal enclosure As String, _
      ByVal horsepower As String, ByVal RPM As Integer) As DataTable
         Dim connectionString, sqlCommand As String
         Dim connection As IDbConnection
         Dim adapter As IDbDataAdapter
         Dim motorTable As DataTable
         Dim ds As New DataSet

         sqlCommand = _
            "SELECT * FROM Motors " & _
            "WHERE [Efficiency] = '" & efficiency & "' AND " & _
                  "[Enclosure] = '" & enclosure & "' AND " & _
                  "[HP] = '" & horsepower & "' AND " & _
                  "[RPM] = " & RPM
         connectionString = Common.GetConnectionString(Common.AirHandlerDbPath)

         connection = Common.CreateConnection(Common.AirHandlerDbPath) 'New OleDbConnection(connectionString)
         Dim cmd As IDbCommand = connection.CreateCommand
         cmd.CommandText = sqlCommand
         adapter = Common.CreateAdapter(cmd) 'New OleDbDataAdapter(sqlCommand, connection)
         motorTable = New DataTable("Motors")

         Try
            connection.Open()
            adapter.Fill(ds)
         Catch ex As DataException
            Throw
         Finally
            If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try

         Return ds.Tables(0)
      End Function


      ''' <summary>Retrieves motor based on parameters</summary>
      Public Shared Function RetrieveMotors(ByVal efficiency As String, ByVal enclosure As String, _
      ByVal horsepower As String) As DataTable
         Dim connectionString, sqlCommand As String
         Dim connection As IDbConnection
         Dim adapter As IDbDataAdapter
         Dim motorTable As DataTable
         Dim ds As New DataSet

         sqlCommand = _
            "SELECT * FROM Motors " & _
            "WHERE [Efficiency] = '" & efficiency & "' AND " & _
                  "[Enclosure] = '" & enclosure & "' AND " & _
                  "[HP] = '" & horsepower & "'"
         connectionString = Common.GetConnectionString(Common.AirHandlerDbPath)

         connection = Common.CreateConnection(Common.AirHandlerDbPath) 'New OleDbConnection(connectionString)
         Dim cmd As IDbCommand = connection.CreateCommand
         cmd.CommandText = sqlCommand
         adapter = Common.CreateAdapter(cmd) 'New OleDbDataAdapter(sqlCommand, connection)
         motorTable = New DataTable("Motors")

         Try
            connection.Open()
            adapter.Fill(ds)
         Catch ex As DataException
            Throw
         Finally
            If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try

         Return ds.Tables(0)
      End Function


      ''' <summary>Retrieves housed BIDI fan based on size parameter
      ''' </summary>
      Public Shared Function RetrieveBidiFan(ByVal size As Double) As DataTable
         Dim connectionString, sqlCommand As String
         Dim connection As IDbConnection
         Dim adapter As IDbDataAdapter
         Dim fanTable As DataTable
         Dim ds As New DataSet

         connectionString = Common.GetConnectionString(Common.AirHandlerDbPath)
         sqlCommand = _
            "SELECT * FROM BidiFans " & _
            "WHERE [Size] = " & size.ToString

         connection = Common.CreateConnection(Common.AirHandlerDbPath) 'New OleDbConnection(connectionString)
         Dim cmd As IDbCommand = connection.CreateCommand
         cmd.CommandText = sqlCommand
         adapter = Common.CreateAdapter(cmd) 'New OleDbDataAdapter(sqlCommand, connection)
         fanTable = New DataTable("Fans")

         Try
            connection.Open()
            adapter.Fill(ds)
         Catch ex As DataException
            Throw
         Finally
            If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try

         Return ds.Tables(0)
      End Function


      ''' <summary>Retrieves housed forward curved fan based on size
      ''' </summary>
      Public Shared Function RetrieveForwardCurvedFans(ByVal size As String) As DataTable
         Dim connectionString, sqlCommand As String
         Dim connection As IDbConnection
         Dim adapter As IDbDataAdapter
         Dim fanTable As DataTable
         Dim ds As New DataSet

         connectionString = Common.GetConnectionString(Common.AirHandlerDbPath)
         sqlCommand = _
            "SELECT * FROM ForwardCurvedFans " & _
            "WHERE [Size] = '" & size.ToString & "'"

         connection = Common.CreateConnection(Common.AirHandlerDbPath) 'New OleDbConnection(connectionString)
         Dim cmd As IDbCommand = connection.CreateCommand
         cmd.CommandText = sqlCommand
         adapter = Common.CreateAdapter(cmd) 'New OleDbDataAdapter(sqlCommand, connection)
         fanTable = New DataTable("Fans")

         Try
            connection.Open()
            adapter.Fill(ds)
         Catch ex As DataException
            Throw
         Finally
            If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try

         Return ds.Tables(0)
      End Function


      ''' <summary>Retrieves price of plenum fan</summary>
      Public Shared Sub RetrievePlenumFanPrice(ByVal fanClass As String, ByVal fanSize As Double, _
      ByRef cost As Double, ByRef laborHours As Integer)
         Dim connectionString, sqlCommand As String
         Dim connection As IDbConnection
         Dim command As IDbCommand

         sqlCommand = _
            "SELECT Cost, LaborHours FROM PlenumFans " & _
            "WHERE " & _
               "[Class] = '" & fanClass & "' AND " & _
               "[Size] = " & fanSize
         connectionString = Common.GetConnectionString(Common.AirHandlerDbPath)

         connection = Common.CreateConnection(Common.AirHandlerDbPath) 'New OleDbConnection(connectionString)
         command = connection.CreateCommand 'New OleDbCommand(sqlCommand, connection)
         command.CommandText = sqlCommand
         Try
            connection.Open()
            Dim reader As IDataReader = command.ExecuteReader()
            While reader.Read()
               cost = CDbl(reader("Cost"))
               laborHours = CInt(reader("LaborHours"))
            End While
         Catch ex As DataException
            Throw
         Finally
            If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try
      End Sub


      ''' <summary>Retrieves duct heaters matching parameters</summary>
      Public Shared Function RetrieveDuctHeaters( _
      ByVal volts As Integer, ByVal kw As Double) As DataTable
         Dim connectionString, sqlCommand As String
         Dim connection As IDbConnection
         Dim adapter As IDbDataAdapter
         Dim heatersTable As DataTable

         ' rounds so that value matches database
         kw = System.Math.Round(kw, 1)

         connectionString = Common.GetConnectionString(Common.AirHandlerDbPath)
         sqlCommand = _
            "SELECT * FROM DuctHeaters " & _
            "WHERE [Volts] =" & volts.ToString & " AND " & _
                  "[KwMin] <= " & kw.ToString & " AND " & _
                  "[KwMax] >= " & kw.ToString

         connection = Common.CreateConnection(Common.AirHandlerDbPath) 'New OleDbConnection(connectionString)
         Dim cmd As IDbCommand = connection.CreateCommand
         cmd.CommandText = sqlCommand
         adapter = Common.CreateAdapter(cmd) 'New OleDbDataAdapter(sqlCommand, connection)
         heatersTable = New DataTable("Heaters")
         Dim ds As New DataSet
         Try
            connection.Open()
            adapter.Fill(ds)
         Catch ex As DataException
            Throw
         Finally
            If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try

         Return ds.Tables(0)
      End Function


      ''' <summary>Retrieves coil prices</summary>
      Public Shared Function RetrieveCoilPrices(ByVal model As String, ByVal numRows As Integer) As DataTable
         Dim sqlCommand, connectionString As String
         Dim connection As IDbConnection
         Dim adapter As IDbDataAdapter
         Dim coilsTable As DataTable

         sqlCommand = _
            "SELECT * FROM CoilPrices " & _
            "WHERE " & _
               "[Model] = '" & model & "' AND " & _
               "[NumRows] = " & numRows.ToString
         connectionString = Common.GetConnectionString(Common.AirHandlerDbPath)

         connection = Common.CreateConnection(Common.AirHandlerDbPath) 'New OleDbConnection(connectionString)
         Dim cmd As IDbCommand = connection.CreateCommand
         cmd.CommandText = sqlCommand
         adapter = Common.CreateAdapter(cmd) 'New OleDbDataAdapter(sqlCommand, connection)
         coilsTable = New DataTable("Coils")
         Dim ds As New DataSet
         Try
            connection.Open()
            adapter.Fill(ds)
         Catch ex As DataException
            Throw
         Finally
            If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try

         Return ds.Tables(0)
      End Function


      ''' <summary>Retrieves entire filter table</summary>
      Public Shared Function RetrieveFilters() As DataTable
         Dim connectionString, sqlCommand As String
         Dim connection As IDbConnection
         Dim adapter As IDbDataAdapter
         Dim filtersTable As DataTable

         connectionString = Common.GetConnectionString(Common.AirHandlerDbPath)
         sqlCommand = "SELECT * FROM Filters"

         connection = Common.CreateConnection(Common.AirHandlerDbPath) 'New OleDbConnection(connectionString)
         Dim cmd As IDbCommand = connection.CreateCommand
         cmd.CommandText = sqlCommand
         adapter = Common.CreateAdapter(cmd) 'New OleDbDataAdapter(sqlCommand, connection)
         filtersTable = New DataTable("Filters")
         Dim ds As New DataSet
         Try
            connection.Open()
            adapter.Fill(ds)
         Catch ex As DataException
            Throw
         Finally
            If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try

         Return ds.Tables(0)
      End Function


      ''' <summary>Retrieves damper</summary>
      Public Shared Function RetrieveDamper(ByVal model As String, _
      ByVal type As String, ByVal metal As String) As DataTable
         Dim connectionString, sqlCommand As String
         Dim connection As IDbConnection
         Dim adapter As IDbDataAdapter
         Dim damperTable As DataTable

         connectionString = Common.GetConnectionString(Common.AirHandlerDbPath)
         sqlCommand = "SELECT * FROM Dampers WHERE " & _
            "[Model] = '" & model & "' AND " & _
            "[Type] = '" & type & "' AND " & _
            "[Metal] = '" & metal & "'"

         connection = Common.CreateConnection(Common.AirHandlerDbPath) 'New OleDbConnection(connectionString)
         Dim cmd As IDbCommand = connection.CreateCommand
         cmd.CommandText = sqlCommand
         adapter = Common.CreateAdapter(cmd) 'New OleDbDataAdapter(sqlCommand, connection)
         damperTable = New DataTable("Dampers")
         Dim ds As New DataSet
         Try
            connection.Open()
            adapter.Fill(ds)
         Catch ex As DataException
            Throw
         Finally
            If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try

         Return ds.Tables(0)
      End Function


      ''' <summary>Retrieves section dimensions</summary>
      Public Shared Function RetrieveSectionDimensions(ByVal airHandlerModel As String) As DataTable
         Dim connectionString, sqlCommand As String
         Dim connection As IDbConnection
         Dim adapter As IDbDataAdapter
         Dim dimensionsTable As DataTable

         connectionString = Common.GetConnectionString(Common.AirHandlerDbPath)
         sqlCommand = "SELECT * FROM SectionDimensions WHERE [Model] = '" & airHandlerModel & "'"

         connection = Common.CreateConnection(Common.AirHandlerDbPath) 'New OleDbConnection(connectionString)
         Dim cmd As IDbCommand = connection.CreateCommand
         cmd.CommandText = sqlCommand
         adapter = Common.CreateAdapter(cmd) 'New OleDbDataAdapter(sqlCommand, connection)
         dimensionsTable = New DataTable("Dimensions")
         Dim ds As New DataSet
         Try
            connection.Open()
            adapter.Fill(ds)
         Catch ex As DataException
            Throw
         Finally
            If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try

         Return ds.Tables(0)
      End Function


      ''' <summary>Retrieves appropriate air handlers based on the air flow parameter
      ''' </summary>
      ''' <param name="airflow">Air flow [cfm]
      ''' </param>
      ''' <returns>Dataset containing air handler information
      ''' </returns>
      ''' <remarks>Air handlers must be within air flow and face velocity ranges
      ''' </remarks>
      ''' <history>[CASEYJ]	7/1/2005	Created
      ''' </history>
      Public Shared Function RetrieveAirHandlers(ByVal airflow As Double) As DataTable
         Dim MIN_FACE_VELOCITY As Single = 400
         Dim MAX_FACE_VELOCITY As Single = 550

         Dim connection As IDbConnection
         Dim adapter As IDbDataAdapter
         Dim connectionString, sqlSelect As String
         Dim coilSizes As New DataTable("Coils")

         connectionString = Common.GetConnectionString(Common.AirHandlerDbPath)
         sqlSelect = _
            "SELECT * FROM Coils " & _
            "WHERE [AirflowMax] >= " & airflow & _
            " AND [AirflowMin] <= " & airflow & _
            " AND " & airflow & " / [ActualCoilArea] >= " & MIN_FACE_VELOCITY & _
            " AND " & airflow & " / [ActualCoilArea] <= " & MAX_FACE_VELOCITY
         Dim ds As New DataSet
         connection = Common.CreateConnection(Common.AirHandlerDbPath) 'New OleDbConnection(connectionString)
         Dim cmd As IDbCommand = connection.CreateCommand
         cmd.CommandText = sqlSelect
         adapter = Common.CreateAdapter(cmd) 'New OleDbDataAdapter(sqlCommand, connection)
         Try
            connection.Open()
            adapter.Fill(ds)
         Catch dbEx As DataException
            Throw dbEx
         Finally
            If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try

         Return ds.Tables(0)
      End Function


      Public Shared Function RetrieveNaturalGasHeaterInfo(ByVal power As Integer) As NaturalGasHeaterInfo
         Dim connection As IDbConnection = Common.CreateConnection(Common.AirHandlerDbPath) 'New OleDbConnection(Common.GetConnectionString(Common.AirHandlerDbPath))
         Dim sql As String = "SELECT * FROM GasHeaters WHERE [Power]=" & power.ToString
         Dim command As IDbCommand = connection.CreateCommand 'New OleDbCommand(sql, connection)
         command.CommandText = sql
         Dim reader As IDataReader
         Dim info As NaturalGasHeaterInfo

         Try
            connection.Open()
            reader = command.ExecuteReader()

            info.Power = power
            While reader.Read()
               info.TwoStageHeaterCost = CDbl(reader("TwoStageHeaterCost"))
               info.ModulatingHeaterCost = CDbl(reader("ModulatingHeaterCost"))
               info.LaborHours = CDbl(reader("LaborHours"))
            End While

         Catch ex As Exception
            Throw
         Finally
            If reader IsNot Nothing Then reader.Close()
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try

         ' adjusts cost for database multiplier per Faisal B.
         Dim databaseMultiplier As Double = 2.8
         info.TwoStageHeaterCost /= databaseMultiplier
         info.ModulatingHeaterCost /= databaseMultiplier

         Return info
      End Function

      Public Structure NaturalGasHeaterInfo
         Public Power As Integer
         Public TwoStageHeaterCost As Double
         Public ModulatingHeaterCost As Double
         Public LaborHours As Double
      End Structure


      Public Shared Function RetrieveNaturalGasHeaterPowerOptions() As List(Of Integer)
         Dim connection As IDbConnection = Common.CreateConnection(Common.AirHandlerDbPath) 'New OleDbConnection(Common.GetConnectionString(Common.AirHandlerDbPath))
         Dim sql As String = "SELECT [Power] FROM [GasHeaters]"
         Dim command As IDbCommand = connection.CreateCommand 'New OleDbCommand(sql, connection)
         command.CommandText = sql
         Dim reader As IDataReader
         Dim powers As New List(Of Integer)()

         Try
            connection.Open()
            reader = command.ExecuteReader()
            While reader.Read()
               powers.Add(CInt(reader("Power")))
            End While
         Catch ex As Exception
            Throw
         Finally
            If reader IsNot Nothing Then reader.Close()
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try

         Return powers
      End Function


      Public Shared Function RetrieveSectionLength(ByVal airHandlerModel As String, ByVal sectionAbbreviation As String) As Integer
         Dim connection As IDbConnection = Common.CreateConnection(Common.AirHandlerDbPath) 'New OleDbConnection(Common.GetConnectionString(Common.AirHandlerDbPath))
         Dim sql As String = "SELECT [" & sectionAbbreviation & "] FROM SectionDimensions WHERE [Model]='" & airHandlerModel & "'"
         Dim command As IDbCommand = connection.CreateCommand 'New OleDbCommand(sql, connection)
         command.CommandText = sql
         Dim length As Integer

         Try
            connection.Open()
            length = CInt(command.ExecuteScalar())
         Catch ex As Exception
            Throw
         Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try

         Return length
      End Function


      Public Shared Function RetrieveNumCoils(ByVal airHandlerModel As String) As Integer
         Dim connection As IDbConnection = Common.CreateConnection(Common.AirHandlerDbPath) 'New OleDbConnection(Common.GetConnectionString(Common.AirHandlerDbPath))
         Dim sql As String = "SELECT [NumCoils] FROM Coils WHERE [Model]='" & airHandlerModel & "'"
         Dim command As IDbCommand = connection.CreateCommand 'New OleDbCommand(sql, connection)
         command.CommandText = sql
         Dim numCoils As Integer

         Try
            connection.Open()
            numCoils = CInt(command.ExecuteScalar())
         Catch ex As Exception
            Throw
         Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try

         Return numCoils
      End Function


      Public Shared Function RetrieveCoil(ByVal airHandlerModel As String) As DataTable
         Dim coilTable As New DataTable("Coil")
         Dim connection As IDbConnection = Common.CreateConnection(Common.AirHandlerDbPath) 'New OleDbConnection(Common.GetConnectionString(Common.AirHandlerDbPath))
         Dim sql As String = "SELECT * FROM [Coils] WHERE [Model]='" & airHandlerModel & "'"
         Dim cmd As IDbCommand = connection.CreateCommand
         cmd.CommandText = sql
         Dim adapter As IDbDataAdapter = Common.CreateAdapter(cmd) ' OleDbDataAdapter(sql, connection)
         Dim ds As New DataSet
         Try
            connection.Open()
            adapter.Fill(ds)
         Catch ex As Exception
            Throw
         Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try

         Return ds.Tables(0)
      End Function

   End Class

End Namespace
