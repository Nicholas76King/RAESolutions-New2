Option Strict Off

Imports Rae.Solutions.Chillers
Imports System.Data
Imports System.Collections.Generic
Imports GlycolNames = Rae.RaeSolutions.DataAccess.Chillers.GlycolColumnNames
Imports ET1 = RAE.Solutions.chiller_evaporators.evaporator_table
Imports rae.solutions.chiller_evaporators

Namespace Rae.RaeSolutions.DataAccess.Chillers

''' <summary>The variables contain the column names that are in the glycol tables in the chiller database.</summary>
''' <remarks>This class can shorten the amount of code you have to write if it is imported into classes. Also helps
''' prevent mispelling of column names and having to look up what columns are available.</remarks>
Public Class GlycolColumnNames
   Public Shared ReadOnly LeavingFluidTemperature As String = "LeavingFluidTemperature"
   Public Shared ReadOnly RecommendedGlycolPercentage As String = "RecommendedGlycolPercentage"
   Public Shared ReadOnly FreezingPoint As String = "FreezingPoint"
   Public Shared ReadOnly RecommendedMinSuctionTemperature As String = "RecommendedMinSuctionTemperature"
End Class


Public Class ChillerDataAccess

   ''' <summary>Gets condenser list</summary>
   ''' <remarks>
   ''' Display Member:	Condenser description
   ''' Value Member:		Condenser coil file name
   ''' </remarks>   
   Shared Function GetCondensers() As System.Collections.ArrayList
      Dim condensers As New System.Collections.ArrayList

      With condensers
         ' TODO: add inch mark "
         .Add(New Condenser1("1/2 Diameter 2 Row", "2RCOND"))
         .Add(New Condenser1("1/2 Diameter 3 Row", "3RCOND"))
         .Add(New Condenser1("1/2 Diameter 4 Row", "4RCOND"))
         .Add(New Condenser1("1/2 Diameter 5 Row", "5RCOND"))
         .Add(New Condenser1("1/2 Diameter 6 Row", "6RCOND"))


                .Add(New Condenser1("5/8 Diameter 2 Row", "2RCOND.58"))
                .Add(New Condenser1("5/8 Diameter 3 Row", "3RCOND.58"))
                .Add(New Condenser1("5/8 Diameter 4 Row", "4RCOND.58"))
                .Add(New Condenser1("5/8 Diameter 5 Row", "5RCOND.58"))
                .Add(New Condenser1("5/8 Diameter 6 Row", "6RCOND.58"))

                .Add(New Condenser1("3/8 Diameter 2 Row", "2COND.38W"))
                .Add(New Condenser1("3/8 Diameter 3 Row", "3COND.38W"))
                .Add(New Condenser1("3/8 Diameter 4 Row", "4COND.38W"))
                .Add(New Condenser1("3/8 Diameter 5 Row", "5COND.38W"))
                .Add(New Condenser1("3/8 Diameter 6 Row", "6COND.38W"))

                '2COND.38W
                '3COND.38W
                '4COND.38W
                '5COND.38W
                '6COND.38W
                '2COND.38W
                '3COND.38W
                '4COND.38W
                '5COND.38W
                '6COND.38W




            End With

      Return condensers
   End Function


   ''' <summary>34, 24, RECH, 35</summary>
   Shared Function RetrieveChiller(model As String) As DataTable
      Dim connectionString As String
      Dim sqlCommand As String
      Dim connection As IDbConnection
      Dim adapter As IDbDataAdapter
      Dim chillerTable As DataTable
      Dim ds As New DataSet

      If model.IndexOf("34") = 0 Then
         sqlCommand = _
                        "SELECT * FROM [WCC_Master] " & _
                        "WHERE [34W0MODEL] = '" & model & "'"
         connectionString = Common.GetConnectionString(Common.WCCondenserDbPath)
      ElseIf model.IndexOf("24") = 0 Then
         sqlCommand = _
                        "SELECT * FROM [WCC_Master] " & _
                        "WHERE [24W0MODEL] = '" & model & "'"
         connectionString = Common.GetConnectionString(Common.WCCondenserDbPath)
      ElseIf Mid(model, 1, 4) = "RECH" Then
         sqlCommand = _
            "SELECT * FROM [RECH_Master] " & _
            "WHERE [MODEL] = '" & model & "'"
         connectionString = Common.GetConnectionString(Common.ChillerDbPath)
      ElseIf model.StartsWith("35") Then
         sqlCommand = _
            "SELECT * FROM [RECH_Master] " & _
            "WHERE [TSI MODEL] = '" & model & "'"
         connectionString = Common.GetConnectionString(Common.ChillerDbPath)
      Else
         sqlCommand = "SELECT * FROM [" & Common.CommonTableName(Common.ChillerDbPath, "Table5") & "] " & _
                     "WHERE [MODEL] = '" & model & "'"
         connectionString = Common.GetConnectionString(Common.ChillerDbPath)
      End If

      connection = Common.CreateConnection
      connection.ConnectionString = connectionString
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sqlCommand
      adapter = Common.CreateAdapter(cmd)
      chillerTable = New DataTable("Chiller")
      Try
         connection.Open()
         adapter.Fill(ds)
      Finally
         If connection.State <> ConnectionState.Closed Then _
            connection.Close()
      End Try

      Return ds.Tables(0)
   End Function

   'water-cooled
   Shared Function RetrieveChiller(ByVal model As String, ByVal path As String) As DataTable
      Dim connectionString As String
      Dim sqlCommand As String
      Dim connection As IDbConnection
      Dim adapter As IDbDataAdapter
      Dim chillerTable As DataTable
      Dim ds As New DataSet
      connectionString = Common.GetConnectionString(path)
      If model.IndexOf("34") = 0 Then
         sqlCommand = _
                        "SELECT * FROM WCC_Master " & _
                        "WHERE [34W0MODEL] = '" & model & "'"
      Else
         sqlCommand = _
                                        "SELECT * FROM WCC_Master " & _
                                        "WHERE [24W0MODEL] = '" & model & "'"
      End If


      connection = Common.CreateConnection(path) 'New OleDbConnection(path)
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sqlCommand
      adapter = Common.CreateAdapter(cmd) ' IDbDataAdapter(sqlCommand, connection)
      chillerTable = New DataTable("Chiller")
      Try
         connection.Open()
         adapter.Fill(ds)
      Catch dbEx As DataException
         If Not (connection.State.Equals(ConnectionState.Closed)) Then connection.Close()
      End Try

      Return ds.Tables(0) 'chillerTable
   End Function


   ''' <summary>Retrieves chiller evaporator based on evaporator part number</summary>
   Shared Function RetrieveChillerEvaporator(evaporatorModel As String) As DataTable
      Dim reader As IDataReader
      Dim row As DataRow

      Dim sql = _
         "SELECT * " & _
         "FROM Chiller_Data " & _
         "WHERE [Evap_Part_No] = '" & evaporatorModel & "'"

      Dim connection = Common.CreateConnection(Common.ChillerDbPath)
      Dim command = connection.CreateCommand
      command.CommandText = sql
      Dim chillerTable = New DataTable("Chiller")
      With chillerTable
         .Columns.Add(New DataColumn("RaePartNum", GetType(String)))
         .Columns.Add(New DataColumn("StandardModelNum", GetType(String)))
         .Columns.Add(New DataColumn("EvaporatorPartNum", GetType(String)))
         .Columns.Add(New DataColumn("NominalTons", GetType(Double)))
         .Columns.Add(New DataColumn("Length", GetType(Double)))
         .Columns.Add(New DataColumn("Width", GetType(Double)))
         .Columns.Add(New DataColumn("Height", GetType(Double)))
         .Columns.Add(New DataColumn("ConnectionSize", GetType(String)))
      End With
      Try
         connection.Open()
         reader = command.ExecuteReader(CommandBehavior.SingleRow)
         While reader.Read
            row = chillerTable.NewRow()
            row("RaePartNum") = reader("RAE_Part_Number").ToString
            row("StandardModelNum") = reader("Standard_Model_Number").ToString
            row("EvaporatorPartNum") = reader("Evap_Part_No").ToString
            row("NominalTons") = CDbl(reader("Nom_Tons"))
            row("Length") = CDbl(reader("L"))
            row("Width") = CDbl(reader("W"))
            row("Height") = CDbl(reader("H"))
            row("ConnectionSize") = reader("Conn_Size_Water").ToString
            chillerTable.Rows.Add(row)
         End While
      Finally
         If reader IsNot Nothing Then _
            reader.Close()
         If connection.State <> ConnectionState.Closed Then _
            connection.Close()
      End Try

      Return chillerTable
   End Function


   'todo: isolate from other chiller forms (so can change independently)
   Shared Function RetrieveChillerModels(seriesEnum As Integer) As DataTable
      Dim sql As String
      Dim connectionstring As String
      Dim ds As New DataSet

      If seriesEnum = 4 Then
         sql = _
            "SELECT [Model], [Coil_1] as Coil " & _
            "FROM [RECH_Master] " & _
            "ORDER BY [Model_Ordering] ASC"
         connectionstring = Common.ChillerDbPath
         '"ORDER BY [Model] DESC"
      ElseIf seriesEnum = 5 Then
         sql = _
            "SELECT [24W0Model] as Model, [Coil_1] as Coil " & _
            "FROM [WCC_Master] "
         connectionstring = Common.WCCondenserDbPath
      ElseIf seriesEnum = 6 Then
         sql = _
            "SELECT [34W0Model] as Model, [Coil_1] as Coil " & _
            "FROM [WCC_Master] "
         connectionstring = Common.WCCondenserDbPath
      Else
         sql = _
            "SELECT [TSI Model] as Model, [Coil_1] as Coil " & _
            "FROM [RECH_Master] " & _
             "ORDER BY [TSIModel_Ordering] ASC"
         connectionstring = Common.ChillerDbPath
      End If

      Dim connection As IDbConnection = Common.CreateConnection(connectionstring)
      'connection.ConnectionString = connectionstring
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      Dim adapter As IDbDataAdapter = Common.CreateAdapter(cmd) 'sqlCommand, connection)
      Dim chillerTable As New DataTable("Chiller")
      Try
         connection.Open()
         adapter.Fill(ds)
      Catch dbEx As DataException
         If Not (connection.State.Equals(ConnectionState.Closed)) Then connection.Close()
      End Try

      Return ds.Tables(0)
   End Function

   ''' <summary>Retrieves chiller models that the rep can view.</summary>
   ''' <param name="series">Chiller series (ex. 30A0)</param>
   Shared Function RetrieveRepChillerModels(series As String) As List(Of String)
      Dim sql = _
         "SELECT [Model] " & _
         "FROM [" & Common.CommonTableName(Common.ChillerDbPath, "Table5") & "] " & _
         "WHERE [Unit_Series] = '" & series & "' " & _
         "AND [Rev_Level]=3 " & _
         "ORDER BY [Model]"

      Dim models = retrieveChillerModelsBasedOnSqlCommand(sql)

      Return models
   End Function

   ' TODO: use evaporatorrepo instead
   Shared Function RetrieveEvaporator( standardModel As String, _
                                       numCircuits As Integer, _
                                       length As Single, _
                                       authorizationLevel As Integer) As String
      Dim evaporatorModel As String
      Dim reader As IDataReader
      
      Dim query = New query()
      Dim sql As String
      
      If authorizationLevel > 2 Then ' if rep
         sql = query.Evaporators.Where.ModelIs(standardModel) _
                    .And.NumCircuitsIs(numCircuits) _
                    .And.LengthIsLessThanEqualTo(length) _
                    .And.HasRaePartNum.ToSql()
      Else
         sql = query.Evaporators.Where.ModelIs(standardModel) _
                    .And.NumCircuitsIs(numCircuits).ToSql()
      End If

      Dim con = Common.CreateConnection(Common.ChillerDbPath)
      Dim cmd = con.CreateCommand()
      cmd.CommandText = sql
      Try
         con.Open()
         reader = cmd.ExecuteReader()
         While reader.Read()
                    evaporatorModel = reader(ET1.evaporator_part_number).ToString.ToUpper
                End While
      Finally
         If reader IsNot Nothing Then _
            reader.Close()
         If con.State <> ConnectionState.Closed Then _
            con.Close()
      End Try

      Return evaporatorModel
   End Function


   ''' <summary>Retrieves entire ethylene table containing recommendations, freezing point and leaving fluid temperature</summary>
   Shared Function RetrieveEthylene() As DataTable
      Dim reader As IDataReader
      Dim ethyleneTable As DataTable
      Dim row As DataRow

      Dim sql = "SELECT * FROM Ethylene_Glycol"

      Dim connection = Common.CreateConnection(Common.ChillerDbPath)
      Dim command = connection.CreateCommand
      command.CommandText = sql

      ethyleneTable = New DataTable("Ethylene")
      ethyleneTable.Columns.Add(GlycolNames.LeavingFluidTemperature, GetType(Double))
      ethyleneTable.Columns.Add(GlycolNames.RecommendedGlycolPercentage, GetType(Double))
      ethyleneTable.Columns.Add(GlycolNames.FreezingPoint, GetType(Double))
      ethyleneTable.Columns.Add(GlycolNames.RecommendedMinSuctionTemperature, GetType(Double))

      Try
         connection.Open()
         reader = command.ExecuteReader()
         While reader.Read()
            row = ethyleneTable.NewRow
            row(GlycolNames.LeavingFluidTemperature) = reader("Lvg_Fluid_Temp")
            row(GlycolNames.RecommendedGlycolPercentage) = reader("Recommended_Per_Gly")
            row(GlycolNames.FreezingPoint) = reader("Freeze_point")
            row(GlycolNames.RecommendedMinSuctionTemperature) = reader("Recommended_min_Suction_Temp")
            ethyleneTable.Rows.Add(row)
         End While
      Catch ex As DataException
         Throw New System.ApplicationException("An exception occurred while attempting to retrieve ethylene data.", ex)
      Finally
         If reader IsNot Nothing Then _
            reader.Close()
         If connection.State <> ConnectionState.Closed Then _
            connection.Close()
      End Try

      Return ethyleneTable
   End Function

   ''' <summary>Retrieves entire propylene table containing recommendations, freezing point and leaving fluid temperature</summary>
   Shared Function RetrievePropylene() As DataTable
      Dim reader As IDataReader
      Dim row As DataRow

      Dim sql = "SELECT * FROM Propylene_Glycol"

      Dim connection = Common.CreateConnection(Common.ChillerDbPath)
      Dim command = connection.CreateCommand
      command.CommandText = sql

      Dim propyleneTable = New DataTable("Propylene")
      propyleneTable.Columns.Add(GlycolNames.LeavingFluidTemperature, GetType(Double))
      propyleneTable.Columns.Add(GlycolNames.RecommendedGlycolPercentage, GetType(Double))
      propyleneTable.Columns.Add(GlycolNames.FreezingPoint.ToString, GetType(Double))
      propyleneTable.Columns.Add(GlycolNames.RecommendedMinSuctionTemperature.ToString, GetType(Double))

      Try
         connection.Open()
         reader = command.ExecuteReader()

         While reader.Read()
            row = propyleneTable.NewRow
            row(GlycolNames.LeavingFluidTemperature) = reader("Lvg_Fluid_Temp")
            row(GlycolNames.RecommendedGlycolPercentage) = reader("Recommended_Per_Gly")
            row(GlycolNames.FreezingPoint) = reader("Freeze_point")
            row(GlycolNames.RecommendedMinSuctionTemperature) = reader("Recommended_min_Suction_Temp")
            propyleneTable.Rows.Add(row)
         End While
      Catch ex As DataException
         Throw New System.ApplicationException("An exception occurred while attempting to retrieve propylene data.", ex)
      Finally
         If reader IsNot Nothing Then _
            reader.Close()
         If connection.State <> ConnectionState.Closed Then _
            connection.Close()
      End Try

      Return propyleneTable
   End Function

   ''' <summary>Retrieves all chiller models</summary>
   Private Shared Function retrieveChillerModelsBasedOnSqlCommand(sql As String) As List(Of String)
      Dim reader As IDataReader
      Dim chillerModels As New List(Of String)

      Dim connection = Common.CreateConnection(Common.ChillerDbPath)
      Dim command = connection.CreateCommand
      command.CommandText = sql
      Try
         connection.Open()
         reader = command.ExecuteReader()
         While reader.Read()
            chillerModels.Add(reader.GetString(0))
         End While
      Catch dbEx As DataException
         Throw dbEx
      Finally
         If reader IsNot Nothing Then reader.Close()
         If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
      End Try

      Return chillerModels
   End Function

End Class

End Namespace
