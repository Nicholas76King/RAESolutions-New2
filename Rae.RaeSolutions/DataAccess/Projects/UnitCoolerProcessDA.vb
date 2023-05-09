Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

Imports Rae.Data.Sql
Imports Rae.Io.Text
Imports Rae.RaeSolutions.DataAccess.Projects
Imports Rae.RaeSolutions.Business.Entities

Imports ET2 = RAE.RAESolutions.DataAccess.Projects.Tables.EquipmentTable
Imports COT = Rae.RaeSolutions.DataAccess.Projects.Tables.CondensingUnitTable
Imports CNull = Rae.ConvertNull
Imports OtherCostsDA = Rae.RaeSolutions.DataAccess.Projects.OtherEquipmentCostsDA
Imports CO2 = RAE.RAESolutions.DataAccess.Projects.Tables.CondensingUnitTable
Imports ECP = Rae.RaeSolutions.DataAccess.Projects.Tables.UnitCoolerProcessTable
Imports CT2 = RAE.RAESolutions.DataAccess.Projects.Tables.UnitCoolerProcessTable

Namespace Rae.RaeSolutions.DataAccess.Projects

    Public Class UnitCoolerProcessDA

        Shared Sub Update(process As cu_uc_balance_screen_model)
            Dim numRowsAffected As Integer

            Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
            Dim command = connection.CreateCommand
            command.CommandText = SqlFactory.GetUpdateUnitCoolerSql(process)

            Try
                connection.Open()
                numRowsAffected = command.ExecuteNonQuery()
            Finally
                If Not connection.State.Equals(System.Data.ConnectionState.Closed) Then connection.Close()
            End Try
        End Sub

        Shared Function Retrieve(id As item_id) As cu_uc_balance_screen_model
            Return RetrieveUnitCooler(id)
        End Function

        Shared Function Retrieve(id As item_id, RevNumber As Single) As cu_uc_balance_screen_model
            Return RetrieveUnitCooler(id, RevNumber)
        End Function


        Private Shared Function FixModel(x As String, Optional suction As Decimal = 99999) As String
            Dim oldModel As String = x  ' performance

            x = x.Replace(" ", "")  ' Old models had spaces

            If Not isUCModelValid(x) Then


                If Not x.EndsWith("M") OrElse x.EndsWith("L") Then

                    Dim tempIndicator As String

                    Dim message As String = "The Unit Cooler model saved in this project is no longer available." & vbCrLf & "We recommend a low temperature model for evaporator" & vbCrLf & " for temperatures below zero and a medium temperature model" & vbCrLf & "for temperatures above 0." & vbCrLf & "Please contact your sales manager if you have any questions. "
                    message &= vbCrLf & vbCrLf
                    If suction <> 99999 Then
                        message &= "Current Evaporator Temperature: " & suction

                    End If

                    message &= vbCrLf & vbCrLf & oldModel

                    message &= vbCrLf & vbCrLf
                    message &= "Please choose below"


                    Dim myDialog As New UCTADialog
                    myDialog.setText(message)
                    myDialog.ShowDialog()

                    If myDialog.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        tempIndicator = "L"
                    ElseIf myDialog.DialogResult = System.Windows.Forms.DialogResult.Cancel Then
                        tempIndicator = "M"
                    End If

                    x &= tempIndicator

                    'If x.StartsWith("A") AndAlso Not x.StartsWith("AWSM") Then
                    '    x = "AWSM" & x.Substring(1)
                    'End If

                    If x.StartsWith("FH") Then
                        x = "U" & x
                    End If

                End If

            End If

            Dim isModelValid As Boolean = isUCModelValid(x)

            If isModelValid Then
            Else
                MsgBox("The Unit Cooler model you previously selected " & oldModel & " no longer exists in RAE Solutions.  Project cannot be loaded.")
                Return ""
            End If

            Return x
        End Function


        Private Shared Function isUCModelValid(model As String) As Boolean
            isUCModelValid = False


            Dim connection = Common.CreateConnection(Common.UnitCoolerDbPath) 'New OleDbConnection(connectionString)
            Dim command = connection.CreateCommand

            command.CommandText = "select model from unit_coolers where model = '" & model & "'"

            Dim reader As IDataReader
            Try
                connection.Open()

                reader = command.ExecuteReader
                If reader.Read Then
                    isUCModelValid = True
                End If
            Catch e As Exception
            Finally
                If reader IsNot Nothing Then _
                   reader.Close()
                If connection.State <> ConnectionState.Closed Then _
                   connection.Close()
            End Try


        End Function









        Private Shared Function RetrieveUnitCooler(id As item_id, Optional ByVal RevNumber As Single = -1, Optional ByVal ProjRevision As Single = -1) As cu_uc_balance_screen_model
            Dim reader As IDataReader
            Dim sql As String

            Dim UnitCooler As cu_uc_balance_screen_model

            ' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            ' Added by JOSHH on 8/7/2006
            ' Determin which revision to get..
            ' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            If RevNumber > -1 Then
                ' If a revision number is specified then
                ' get it...
                sql = "SELECT * FROM UnitCoolerProcesses " & _
                      "WHERE ProcessID='" & id.Id & "' " & _
                      "AND Revision = " & RevNumber '& _
                '" AND ProjectRevision = " & ProjRevision
            Else
                ' Revision number not specified - we'll get
                ' the last revision...
                sql = "SELECT * FROM UnitCoolerProcesses " & _
                      "WHERE ProcessID='" & id.Id & "' " & _
                      "ORDER BY [Revision] DESC"
            End If
            ' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            Dim connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)
            Dim command = connection.CreateCommand
            command.CommandText = sql

            Try
                connection.Open()
                reader = command.ExecuteReader()
                If reader.Read Then
                    ' retrieves values required to construct a fluid cooler equipment item
                    'equipmentId = New ItemId(reader(ET22.TableName & "." & ET2.EquipmentId).ToString)
                    'projectId = New ItemId(reader(ET2.ProjectId).ToString)
                    'name = reader(ET2.Name).ToString
                    'GetEnumValue(reader(ET2.Division).ToString, division)

                    ' constructs
                    UnitCooler = New cu_uc_balance_screen_model(id)

                    ' retrieves the rest of the properties
                    With UnitCooler
                        .id = id
                        .Model = reader(CT2.CondensingUnitModel).ToString
                        .name = reader(CT2.Name).ToString
                        .Revision = CSng(reader(CT2.Revision))
                        .RevisionDate = CDate(reader(CT2.RevisionDate))
                        .Notes = reader(CT2.Notes).ToString
                        .Version = reader(CT2.Version).ToString
                        GetEnumValue(reader(ECP.Division).ToString, .Division)
                        ' TEST: DateGenerated is set by ID?
                        '.MetaData.Author = reader(ET2.Author).ToString
                        '.ProjectRevision = cint(reader("ProjectRevision"))
                        '.ProcessRevisionDescription = reader(ECP.ProcessRevisionDescription).ToString
                        .condensing_unit_series = reader(CT2.CondensingUnitSeries).ToString
                        .capacity_is_adjusted_for_runtime = CBool(reader(CT2.ShouldAdjustCapacityForRunTime))
                        .altitude = CDbl(reader(CT2.Altitude).ToString)
                        .ambient = CDbl(reader(CT2.AmbientTemperature).ToString)
                        .ambient_increment = CDbl(reader(CT2.AmbientTemperatureIncrement))
                        .max_ambient = CDbl(reader(CT2.AmbientMaxTemperature))
                        .min_ambient = CDbl(reader(CT2.AmbientMinTemperature))
                        .balance = CDbl(reader(CT2.Balance))
                        .capacity_required = CDbl(reader(CT2.CapacityRequired))
                        .compressor_quantity_per_unit = CInt(reader(CT2.NumCompressorsPerUnit))
                        .refrigerant_circuits_per_unit = CInt(reader(CT2.NumCircuitsPerUnit))
                        .compressor_type = reader(CT2.CompressorType).ToString
                        .condenser_capacity_per_degree = CDbl(reader(CT2.CondenserCapacityPerDegree))
                        .condensing_unit_quantity = CInt(reader(CT2.NumCondensingUnitsRequired))
                        .CreatedBy = reader(CT2.CreatedBy).ToString
                        .CustomCondensingUnit = reader(CT2.CustomCondensingUnit).ToString
                        .custom_unit_cooler_is_selected = CBool(reader(CT2.IsThereACustomUnitCooler))
                        .CustomUnitCooler.capacity = CDbl(reader(CT2.CustomUnitCoolerCapacity))
                        .CustomUnitCooler.model = reader(CT2.CustomUnitCoolerModel).ToString
                        .CustomUnitCooler.capacity_per_degree = ConvertNull.ToDouble(reader(CT2.CustomUnitCoolerCapacityPerDegree))
                        .CustomUnitCooler.quantity = ConvertNull.ToInteger(reader(CT2.CustomUnitCoolerQuantity))

                        ' Try to set project manager...
                        If ProcessItemDA.GetProjectID(id.Id) IsNot Nothing Then
                            .ProjectManager = New project_manager(ProcessItemDA.GetProjectID(id.Id))
                        End If

                        .refrigerant = reader(CT2.Refrigerant).ToString
                        .rooms = CDbl(reader(CT2.NumRooms))
                        .room_temperature = CDbl(reader(CT2.RoomTemperature))
                        .room_temperature_increment = CDbl(reader(CT2.RoomTemperatureIncrement))
                        .max_room_temperature = CDbl(reader(CT2.RoomMaxTemperature))
                        .min_room_temperature = CDbl(reader(CT2.RoomMinTemperature))
                        .run_time_hours_per_day = CDbl(reader(CT2.NumRunTimeHours))
                        '.unit_cooler_series = reader(CT2.Series).ToString


                        .DOEModel = reader(CT2.DOEModel).ToString

                        If String.IsNullOrEmpty(.DOEModel) Then

                            Dim ucr = New rae.solutions.unit_coolers.repository
                            Dim doeFlag As Boolean = ucr.CheckDOE(.Model.Replace("-E", "").Replace("-A", "").Replace("-HG", ""))

                            If doeFlag Then
                                .DOEModel = "Yes"
                            Else
                                .DOEModel = "No"
                            End If
                            '

                        End If


                        Dim series As String = reader(CT2.Series).ToString
                        '    If series = "A" Then series = "AWSM"
                        If series = "FH" Then series = "UFH"
                        .unit_cooler_series = series

                        .suction_line_loss = CDbl(reader(CT2.SuctionLineLoss))
                        .suction = CDbl(reader(CT2.SuctionTemperature))
                        .selected_unit_cooler_index = CNull.ToInteger(reader(CT2.SelectedUnitCoolerIndex))

                        .selected_unit_coolers.Clear()
                        If CBool(reader(CT2.IsThereAUnitCooler1)) Then
                            Dim unitCooler1 As cu_uc_balance_screen_model.UnitCooler
                            Dim model As String = reader(CT2.UnitCooler1Model).ToString
                            model = FixModel(model)
                            If String.IsNullOrWhiteSpace(model) Then Return Nothing
                            unitCooler1.model = model
                            unitCooler1.capacity = CDbl(reader(CT2.UnitCooler1Capacity))
                            unitCooler1.quantity = CInt(reader(CT2.UnitCooler1Quantity))
                            unitCooler1.capacity_per_degree = CDbl(reader(CT2.Evaporator1CapacityPerDegree))
                            unitCooler1.static_pressure = ConvertNull.ToDouble(reader(CT2.static_pressure_1))
                            .selected_unit_coolers.Add(unitCooler1)
                        End If

                        Dim is_unit_cooler_2 = ConvertNull.ToBoolean(reader(CT2.IsThereAUnitCooler2))
                        If is_unit_cooler_2 Then
                            Dim unit_cooler_2 As cu_uc_balance_screen_model.UnitCooler
                            Dim model As String = reader(CT2.UnitCooler2Model).ToString
                            model = FixModel(model)
                            If String.IsNullOrWhiteSpace(model) Then Return Nothing
                            unit_cooler_2.model = model
                            unit_cooler_2.capacity = ConvertNull.ToDouble(reader(CT2.UnitCooler2Capacity))
                            unit_cooler_2.quantity = ConvertNull.ToInteger(reader(CT2.UnitCooler2Quantity))
                            unit_cooler_2.capacity_per_degree = ConvertNull.ToDouble(reader(CT2.Evaporator2CapacityPerDegree))
                            unit_cooler_2.static_pressure = ConvertNull.ToDouble(reader(CT2.static_pressure_2))
                            .selected_unit_coolers.Add(unit_cooler_2)
                        End If

                        Dim is_unit_cooler_3 = ConvertNull.ToBoolean(reader(CT2.IsThereAUnitCooler3))
                        If is_unit_cooler_3 Then
                            Dim unit_cooler_3 As cu_uc_balance_screen_model.UnitCooler
                            Dim model As String = reader(CT2.UnitCooler3Model).ToString
                            model = FixModel(model)
                            If String.IsNullOrWhiteSpace(model) Then Return Nothing
                            unit_cooler_3.model = model
                            unit_cooler_3.capacity = ConvertNull.ToDouble(reader(CT2.UnitCooler3Capacity))
                            unit_cooler_3.quantity = ConvertNull.ToInteger(reader(CT2.UnitCooler2Quantity))
                            unit_cooler_3.capacity_per_degree = ConvertNull.ToDouble(reader(CT2.CondenserCapacityPerDegree))
                            unit_cooler_3.static_pressure = ConvertNull.ToDouble(reader(CT2.static_pressure_3))
                            .selected_unit_coolers.Add(unit_cooler_3)
                        End If

                        .do_not_filter_unit_coolers_based_on_capacity = CBool(reader(CT2.ShouldOverrideUnitCoolerCapacityCriteria))


                        .condensing_unit_model = reader(CT2.CondensingUnitModel).ToString

                        .ObjectLinkType = reader(ECP.ObjectLinkType).ToString
                        .ObjectLinkXML = reader(ECP.ObjectLinkXML).ToString

                    End With
                End If
            Finally
                If reader IsNot Nothing Then reader.Close()
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try

            Return UnitCooler
        End Function




        Shared Function Exists(id As String, Optional ProjRevision As Single = -1) As Boolean
            Dim reader As iDataReader
            Dim found As Boolean = False

            Dim sql = "SELECT * FROM Processes WHERE ID = '" + id + "'"
            Dim connection = Common.CreateConnection(Common.ProjectsDbPath)

            Dim command = connection.CreateCommand
            command.CommandText = sql

            Try
                connection.Open()
                reader = command.ExecuteReader()
                ' checks if project exists
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

        Shared Function Exists(connection As IDbConnection, transaction As IDbTransaction, id As String, Optional ProjRevision As Single = -1) As Boolean
            Dim reader As IDataReader
            Dim found As Boolean = False

            Dim sql = "SELECT * FROM Processes WHERE ProcessId = '" + id + "'"
            'sql += " AND ProjectRevision = " + ProjRevision.ToString
            Dim command = connection.CreateCommand
            command.CommandText = sql
            command.Transaction = transaction

            Try
                reader = command.ExecuteReader()
                ' checks if project exists
                Dim i As Integer = 0
                While reader.Read
                    i += 1
                End While
                If i > 0 Then
                    found = True
                End If
                'found = reader.HasRows()
            Finally
                'If reader IsNot Nothing Then reader.Close()
                'If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try

            Return found
        End Function


        Overloads Shared Function Create(unitCooler As cu_uc_balance_screen_model) As Integer
            Dim transaction As IDbTransaction
            Dim numRowsAffected As Integer

            Dim found = Exists(unitCooler.id.ToString)

            Dim connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)

            Try
                connection.Open()
                transaction = connection.BeginTransaction()

                If found = False Then
                    ' inserts only general process data into Processes Table
                    ProcessItemDA.Create(connection, transaction, unitCooler, ECP.TableName)
                End If
                ' inserts values into UnitCoolerProcessesTable
                CreateItem(connection, transaction, unitCooler)
                transaction.Commit()
            Catch ex As Exception
                If Not transaction Is Nothing Then transaction.Rollback()
                Throw New ApplicationException("Attempt to create unit cooler process item failed. Transaction was rolled back.", ex)
            Finally
                If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
            End Try

            Return numRowsAffected
        End Function


        Shared Sub CreateItem(connection As IDbConnection, transaction As IDbTransaction, process As cu_uc_balance_screen_model)
            Dim sqlCommand = SqlFactory.GetInsertUnitCoolerSql(process)
            Dim command = connection.CreateCommand
            command.CommandText = sqlCommand
            command.Transaction = transaction
            command.ExecuteNonQuery()
        End Sub


        Private Class SqlFactory

            Shared Function GetInsertUnitCoolerSql(unitCooler As cu_uc_balance_screen_model) As String
                Dim affectedColumns As List(Of SqlColumn) = UnitCoolerColumns(unitCooler)
                Dim builder As New SqlBuilder(affectedColumns, CT2.TableName)

                Return builder.GenerateInsertCommand()
            End Function


            Shared Function GetUpdateUnitCoolerSql(unitcooler As cu_uc_balance_screen_model) As String
                Dim affectedCols As List(Of SqlColumn) = UnitCoolerColumns(unitcooler)
                Dim criteriaCols As New List(Of SqlColumn)
                criteriaCols.Add(New SqlColumn(CT2.ProcessId, SqlDataType.String, unitcooler.id.Id))
                criteriaCols.Add(New SqlColumn(CT2.Revision, SqlDataType.Number, unitcooler.Revision.ToString))
                Dim builder As New SqlBuilder(affectedCols, CT2.TableName, criteriaCols)

                Return builder.GenerateUpdateCommand()
            End Function


            Private Shared Function UnitCoolerColumns(unitCooler As cu_uc_balance_screen_model) As List(Of SqlColumn)
                Dim columns As New List(Of SqlColumn)

                With columns
                    ' general columns
                    .Add(New SqlColumn(CT2.ProcessId, SqlDataType.String, unitCooler.id.ToString))
                    .Add(New SqlColumn(CT2.Name, SqlDataType.String, unitCooler.name))
                    .Add(New SqlColumn(CT2.Revision, SqlDataType.Number, unitCooler.Revision.ToString))
                    ' BUG: revision date is not set
                    .Add(New SqlColumn(CT2.RevisionDate, SqlDataType.Date, CStr(unitCooler.RevisionDate)))
                    .Add(New SqlColumn(CT2.CreatedBy, SqlDataType.String, unitCooler.CreatedBy))
                    .Add(New SqlColumn(CT2.Version, SqlDataType.String, unitCooler.Version))
                    .Add(New SqlColumn(CT2.Division, SqlDataType.String, unitCooler.Division.ToString))
                    ' condensing unit columns
                    .Add(New SqlColumn(CT2.CondensingUnitSeries, SqlDataType.String, unitCooler.condensing_unit_series))
                    .Add(New SqlColumn(CT2.ShouldAdjustCapacityForRunTime, SqlDataType.Boolean, System.Math.Abs(CInt(unitCooler.capacity_is_adjusted_for_runtime)).ToString))
                    .Add(New SqlColumn(CT2.NumRunTimeHours, SqlDataType.Number, unitCooler.run_time_hours_per_day.ToString))
                    .Add(New SqlColumn(CT2.CompressorType, SqlDataType.String, unitCooler.compressor_type))
                    .Add(New SqlColumn(CT2.Refrigerant, SqlDataType.String, unitCooler.refrigerant))
                    .Add(New SqlColumn(CT2.NumCompressorsPerUnit, SqlDataType.Number, unitCooler.compressor_quantity_per_unit.ToString))
                    .Add(New SqlColumn(CT2.NumCircuitsPerUnit, SqlDataType.Number, unitCooler.refrigerant_circuits_per_unit.ToString))
                    .Add(New SqlColumn(CT2.CapacityRequired, SqlDataType.Number, unitCooler.capacity_required.ToString))
                    .Add(New SqlColumn(CT2.Altitude, SqlDataType.Number, unitCooler.altitude.ToString))
                    .Add(New SqlColumn(CT2.NumCondensingUnitsRequired, SqlDataType.Number, unitCooler.condensing_unit_quantity.ToString))
                    .Add(New SqlColumn(CT2.SuctionTemperature, SqlDataType.Number, unitCooler.suction.ToString))
                    .Add(New SqlColumn(CT2.NumRooms, SqlDataType.Number, unitCooler.rooms.ToString))
                    .Add(New SqlColumn(CT2.AmbientTemperature, SqlDataType.Number, unitCooler.ambient.ToString))
                    .Add(New SqlColumn(CT2.AmbientMinTemperature, SqlDataType.Number, unitCooler.min_ambient.ToString))
                    .Add(New SqlColumn(CT2.AmbientMaxTemperature, SqlDataType.Number, unitCooler.max_ambient.ToString))
                    .Add(New SqlColumn(CT2.AmbientTemperatureIncrement, SqlDataType.Number, unitCooler.ambient_increment.ToString))
                    .Add(New SqlColumn(CT2.RoomTemperature, SqlDataType.Number, unitCooler.room_temperature.ToString))
                    .Add(New SqlColumn(CT2.RoomMinTemperature, SqlDataType.Number, unitCooler.min_room_temperature.ToString))
                    .Add(New SqlColumn(CT2.RoomMaxTemperature, SqlDataType.Number, unitCooler.max_room_temperature.ToString))
                    .Add(New SqlColumn(CT2.RoomTemperatureIncrement, SqlDataType.Number, unitCooler.room_temperature_increment.ToString))
                    .Add(New SqlColumn(CT2.CondenserCapacityPerDegree, SqlDataType.Number, unitCooler.condenser_capacity_per_degree.ToString))
                    .Add(New SqlColumn(CT2.CondensingUnitModel, SqlDataType.String, unitCooler.condensing_unit_model))

                    .Add(New SqlColumn(CT2.IsThereACustomUnitCooler, SqlDataType.Boolean, System.Math.Abs(CInt(unitCooler.custom_unit_cooler_is_selected)).ToString)) 'bool
                    .Add(New SqlColumn(CT2.CustomCondensingUnit, SqlDataType.String, unitCooler.CustomCondensingUnit))
                    .Add(New SqlColumn(CT2.CustomUnitCoolerCapacity, SqlDataType.Number, unitCooler.CustomUnitCooler.capacity.ToString))
                    .Add(New SqlColumn(CT2.CustomUnitCoolerModel, SqlDataType.String, unitCooler.CustomUnitCooler.model))
                    .Add(New SqlColumn(CT2.CustomUnitCoolerCapacityPerDegree, SqlDataType.Number, unitCooler.CustomUnitCooler.capacity_per_degree.ToString()))
                    .Add(New SqlColumn(CT2.CustomUnitCoolerQuantity, SqlDataType.Number, unitCooler.CustomUnitCooler.quantity.ToString()))
                    .Add(New SqlColumn(CT2.Notes, SqlDataType.String, unitCooler.Notes))
                    .Add(New SqlColumn(CT2.SuctionLineLoss, SqlDataType.Number, unitCooler.suction_line_loss.ToString))

                    If unitCooler.selected_unit_coolers.Count > 0 Then
                        .Add(New SqlColumn(CT2.IsThereAUnitCooler1, SqlDataType.Boolean, "1"))
                        .Add(New SqlColumn(CT2.UnitCooler1Model, SqlDataType.String, unitCooler.selected_unit_coolers(0).model.ToString))
                        .Add(New SqlColumn(CT2.Evaporator1CapacityPerDegree, SqlDataType.Number, unitCooler.selected_unit_coolers(0).capacity_per_degree.ToString))
                        .Add(New SqlColumn(CT2.UnitCooler1Quantity, SqlDataType.Number, unitCooler.selected_unit_coolers(0).quantity.ToString))
                        .Add(New SqlColumn(CT2.UnitCooler1Capacity, SqlDataType.Number, unitCooler.selected_unit_coolers(0).capacity.ToString))
                        .Add(New SqlColumn(CT2.static_pressure_1, SqlDataType.Number, unitCooler.selected_unit_coolers(0).static_pressure.ToString))
                    Else
                        .Add(New SqlColumn(CT2.IsThereAUnitCooler1, SqlDataType.Boolean, "0"))
                    End If
                    If unitCooler.selected_unit_coolers.Count > 1 Then
                        .Add(New SqlColumn(CT2.IsThereAUnitCooler2, SqlDataType.Boolean, "1"))
                        .Add(New SqlColumn(CT2.UnitCooler2Model, SqlDataType.String, unitCooler.selected_unit_coolers(1).model.ToString))
                        .Add(New SqlColumn(CT2.Evaporator2CapacityPerDegree, SqlDataType.Number, unitCooler.selected_unit_coolers(1).capacity_per_degree.ToString))
                        .Add(New SqlColumn(CT2.UnitCooler2Quantity, SqlDataType.Number, unitCooler.selected_unit_coolers(1).quantity.ToString))
                        .Add(New SqlColumn(CT2.UnitCooler2Capacity, SqlDataType.Number, unitCooler.selected_unit_coolers(1).capacity.ToString))
                        .Add(New SqlColumn(CT2.static_pressure_2, SqlDataType.Number, unitCooler.selected_unit_coolers(1).static_pressure.ToString))
                    Else
                        .Add(New SqlColumn(CT2.IsThereAUnitCooler2, SqlDataType.Boolean, "0"))
                    End If
                    If unitCooler.selected_unit_coolers.Count > 2 Then
                        .Add(New SqlColumn(CT2.IsThereAUnitCooler3, SqlDataType.Boolean, "1"))
                        .Add(New SqlColumn(CT2.UnitCooler3Model, SqlDataType.String, unitCooler.selected_unit_coolers(2).model.ToString))
                        .Add(New SqlColumn(CT2.Evaporator3CapacityPerDegree, SqlDataType.Number, unitCooler.selected_unit_coolers(2).capacity_per_degree.ToString))
                        .Add(New SqlColumn(CT2.UnitCooler3Quantity, SqlDataType.Number, unitCooler.selected_unit_coolers(2).quantity.ToString))
                        .Add(New SqlColumn(CT2.UnitCooler3Capacity, SqlDataType.Number, unitCooler.selected_unit_coolers(2).capacity.ToString))
                        .Add(New SqlColumn(CT2.static_pressure_3, SqlDataType.Number, unitCooler.selected_unit_coolers(2).static_pressure.ToString))
                    Else
                        .Add(New SqlColumn(CT2.IsThereAUnitCooler3, SqlDataType.Boolean, "0"))
                    End If

                    .Add(New SqlColumn(CT2.ShouldOverrideUnitCoolerCapacityCriteria, SqlDataType.Boolean, System.Math.Abs(CInt(unitCooler.do_not_filter_unit_coolers_based_on_capacity)).ToString)) 'bool
                    .Add(New SqlColumn(CT2.Series, SqlDataType.String, unitCooler.unit_cooler_series))
                    .Add(New SqlColumn(CT2.Balance, SqlDataType.Number, unitCooler.balance.ToString))

                    .Add(New SqlColumn(CT2.ObjectLinkXML, SqlDataType.String, CNull.ToString(unitCooler.ObjectLinkXML)))
                    .Add(New SqlColumn(CT2.ObjectLinkType, SqlDataType.String, CNull.ToString(unitCooler.ObjectLinkType)))

                    .Add(New SqlColumn(CT2.DOEModel, SqlDataType.String, CNull.ToString(unitCooler.DOEModel)))

                End With

                Return columns
            End Function

        End Class

    End Class
End Namespace
