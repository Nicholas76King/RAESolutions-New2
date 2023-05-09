Imports System
Imports System.Text
Imports System.Data
Imports System.Collections.Generic
Imports Rae.Data.Sql
Imports Rae.Io.Text
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.DataAccess.Projects
Imports ET1 = RAE.RAESolutions.DataAccess.Projects.Tables.EquipmentTable
Imports CNull = Rae.ConvertNull
Imports OtherCostsDA = Rae.RaeSolutions.DataAccess.Projects.OtherEquipmentCostsDA
Imports UT = Rae.RaeSolutions.DataAccess.Projects.Tables.UnitCoolerTable

Namespace Rae.RaeSolutions.DataAccess.Projects

    ''' <summary>Provides data access for unit cooler equipment.</summary>
    Public Class UnitCoolerEquipmentItemDa

        ''' <summary>Creates unit cooler equipment.</summary>
        ''' <param name="unitCooler">unit cooler to create.</param>
        ''' <returns>Num of rows affected.</returns>
        Overloads Shared Function Create(ByVal unitCooler As unit_cooler) As Integer
            Dim transaction As IDbTransaction
            Dim numRowsAffected As Integer

            Dim connection = Common.CreateConnection(Common.ProjectsDbPath)

            Try
                connection.Open()

                ' begins transaction (everything can be rolled back from the beginning of the transaction until it is committed)
                transaction = connection.BeginTransaction()

                ' inserts only general equipment data into EquipmentItemTable
                EquipmentDa.Create(connection, transaction, unitCooler)

                ' inserts values into unitCoolerEquipmentItemTable
                numRowsAffected = UnitCoolerEquipmentItemDa.Create(connection, transaction, unitCooler)

                ' inserts other costs
                OtherCostsDA.Create(connection, transaction, unitCooler)

                ' inserts options
                EquipmentOptionsDa.Create(unitCooler.options, connection, transaction)

                SpecialOptionsDa.Create(unitCooler.special_options, connection, transaction)

                ' commits transaction
                transaction.Commit()
            Catch ex As Exception
                ' rolls back transaction
                If Not transaction Is Nothing Then transaction.Rollback()
                Throw New ApplicationException("Attempt to create unit cooler equipment item failed. Transaction was rolled back.", ex)
            Finally
                If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
            End Try

            Return numRowsAffected
        End Function


        ''' <summary>Retrieves unit cooler equipment.</summary>
        ''' <param name="id">Unit cooler ID.</param>
        ''' <returns>Unit cooler equipment.</returns>
        Shared Function Retrieve(ByVal id As String, ByVal revision As Single) As unit_cooler
            Dim unitCooler = RetrieveUnitCooler(id, revision)

            unitCooler.pricing.others = OtherCostsDA.Retrieve(id, revision)

            ' need number of fans to retrieve options priced by number of fans
            Dim numFans = parseNumFansFrom(unitCooler.model_without_series)
            unitCooler.fan_quantity = numFans

            Dim c = New GetAvailableOptionsCommand(unitCooler) : c.Execute()

            unitCooler.special_options = SpecialOptionsDa.RetrieveByEquipmentIdAndRevision(id, revision)

            Return unitCooler
        End Function

        Private Shared Function parseNumFansFrom(ByVal model As String) As Integer
            Dim numFans As Integer

            If Not String.IsNullOrWhiteSpace(model) AndAlso IsNumeric(model) Then
                numFans = CInt(model(1).ToString)

            Else
                numFans = 0
            End If


            Return numFans
        End Function

        ''' <summary>
        ''' Retrieves unit cooler equipment.
        ''' </summary>
        ''' <param name="id">
        ''' unit cooler ID.
        ''' </param>
        ''' <returns>
        ''' unit cooler equipment.
        ''' </returns>
        Shared Function Retrieve(ByVal id As item_id) As unit_cooler
            Dim unitCooler As unit_cooler
            Dim latestRevision As Single

            ' gets latest revision
            latestRevision = EquipmentDa.RetrieveLatestRevision(id.Id)
            ' gets unit cooler equipment
            unitCooler = Retrieve(id.Id, latestRevision)

            Return unitCooler
        End Function

        ''' <summary>
        ''' Retrieves unit cooler equipment
        ''' </summary>
        ''' <param name="id">
        ''' ID of unit cooler equipment to retrieve.
        ''' </param>
        Shared Function Retrieve(ByVal id As String) As unit_cooler
            Return Retrieve(New item_id(id))
        End Function


        ''' <summary>
        ''' Updates unit cooler equipment.
        ''' </summary>
        ''' <param name="unitCooler">
        ''' unit cooler equipment to update.
        ''' </param>
        Shared Sub Update(ByVal unitCooler As unit_cooler)
            Dim connection As IDbConnection
            Dim transaction As IDbTransaction
            Dim command As IDbCommand
            Dim connectionString, sql As String

            connectionString = Common.GetConnectionString(Common.ProjectsDbPath)
            connection = Common.CreateConnection(Common.ProjectsDbPath)

            Try
                connection.Open()
                transaction = connection.BeginTransaction()

                ' updates equipment table
                EquipmentDa.Update(connection, transaction, unitCooler)

                ' updates unit cooler table
                sql = SqlFactory.GetUpdateUnitCoolerSql(unitCooler)
                command = connection.CreateCommand
                command.CommandText = sql
                command.Transaction = transaction
                Dim numRows As Integer = command.ExecuteNonQuery()

                ' updates equipment options
                EquipmentOptionsDa.Save(unitCooler.options, unitCooler.id.Id, unitCooler.revision, connection, transaction)

                SpecialOptionsDa.Save(unitCooler.special_options, connection, transaction, unitCooler.id.Id, unitCooler.revision.ToString)

                transaction.Commit()
            Catch ex As DataException
                If transaction IsNot Nothing Then transaction.Rollback()
                Throw ex
            Finally
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try
        End Sub


#Region " Private methods"

        ''' <summary>
        ''' Creates only unit cooler specific data (only in unitCoolerEquipmentItem table). Returns number of rows affected.
        ''' </summary>
        Private Overloads Shared Function Create(ByVal connection As IDbConnection, ByVal transaction As IDbTransaction, _
        ByVal unitCooler As unit_cooler) As Integer
            Dim sql As String = SqlFactory.GetInsertUnitCoolerSql(unitCooler)
            Dim command As IDbCommand = connection.CreateCommand
            command.CommandText = sql
            command.Transaction = transaction
            Dim numRowsAffected As Integer = command.ExecuteNonQuery()

            Return numRowsAffected
        End Function


        ''' <summary>
        ''' Retrieves unit cooler info in EquipmentItems and unitCoolerEquipmentItems tables.
        ''' </summary>
        ''' <param name="id">
        ''' Equipment ID.
        ''' </param>
        ''' <returns>
        ''' unit cooler equipment item info from EquipmentItems and unitCoolerEquipmentItems tables, 
        ''' but not OtherEquipmentPricing or Options.
        ''' </returns>
        Private Shared Function RetrieveUnitCooler(ByVal id As String, ByVal revision As Single) As unit_cooler
            Dim command As IDbCommand
            Dim reader As IDataReader
            Dim sql As New StringBuilder
            Dim equipmentId, projectId As item_id
            Dim name As String
            Dim division As Business.Division

            Dim unitCooler As unit_cooler

            Dim connectionString = Common.GetConnectionString(Common.ProjectsDbPath)

            sql.AppendFormat("SELECT * FROM ({0} INNER JOIN {1} ON {0}.{2}={1}.{7} AND {0}.{4}={1}.{6}) WHERE ({0}.{2}='{3}') AND ({0}.{4}={5})",
               ET1.TableName, UT.TableName, ET1.EquipmentId, id.ToString, ET1.Revision, revision.ToString, UT.Revision, UT.EquipmentId)

            Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
            command = connection.CreateCommand
            command.CommandText = sql.ToString

            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read
                    ' retrieves values required to construct a unit cooler equipment item
                    If Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
                        equipmentId = New item_id(reader("EquipmentId").ToString)
                    Else
                        equipmentId = New item_id(reader(ET1.TableName & "." & ET1.EquipmentId).ToString)
                    End If
                    projectId = New item_id(reader(ET1.ProjectId).ToString)
                    name = reader(ET1.Name).ToString
                    GetEnumValue(reader(ET1.Division).ToString, division)
                    ' constructs
                    unitCooler = New unit_cooler(name, division, equipmentId, New project_manager(projectId))
                    ' retrieves the rest of the properties
                    With unitCooler
                        ' TEST: DateGenerated is set by ID?
                        '.MetaData.Author = reader(ET1.Author).ToString
                        ' retrieves values required to construct a chiller equipment item
                        If Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
                            .revision = CSng(reader("Revision").ToString)
                        Else
                            .revision = CSng(reader(ET1.TableName & "." & ET1.Revision))
                        End If

                        .model_without_series = reader(ET1.Model).ToString
                        .series = reader(ET1.Series).ToString
                        .custom_model = reader(ET1.CustomModel).ToString

                        ' specs
                        .box_temperature.set_to(reader(UT.BoxTemp))
                        .capacity.set_to(reader(UT.Capacity))
                        .condensing_temperature.set_to(reader(UT.CondensingTemp))
                        .evaporator_temperature.set_to(reader(UT.EvaporatorTemp))
                        .liquid_temperature.set_to(reader(UT.LiquidTemp))
                        .temperature_difference.set_to(reader(UT.TempDifference))
                        .refrigerant = reader(UT.Refrigerant).ToString
                        .fan_voltage.Parse(reader(UT.FanVoltage).ToString)
                        .defrost_voltage.Parse(reader(UT.DefrostVoltage).ToString)
                        .unit_cooler_type = reader(UT.UnitCoolerType).ToString()

                        ' common specs
                        With .common_specs
                            .Altitude.set_to(reader(ET1.Altitude))
                            .ControlVoltage.Parse(CNull.ToString(reader(ET1.ControlVoltage)))
                            .Height.set_to(reader(ET1.Height))
                            .Length.set_to(reader(ET1.Length))
                            .Mca.set_to(reader(ET1.Mca))
                            .OperatingWeight.set_to(reader(ET1.OperatingWeight))
                            .Rla.set_to(reader(ET1.Rla))
                            .ShippingWeight.set_to(reader(ET1.ShippingWeight))
                            .UnitVoltage.Parse(CNull.ToString(reader(ET1.UnitVoltage)))
                            .Width.set_to(reader(ET1.Width))
                        End With

                        ' pricing
                        With .pricing
                            ' there is no list price db field
                            ' others list is handled in seperate method
                            .other_price = CNull.ToDouble(reader(ET1.OtherPrice))
                            .other_description = reader(ET1.OtherDescription).ToString
                            .quantity = CNull.ToInteger(reader(ET1.Quantity))
                            .commission_rate = CNull.ToDouble(reader(ET1.CommissionRate))
                            .par_multiplier = CNull.ToDouble(reader(ET1.ParMultiplier))
                            .freight = CNull.ToDouble(reader(ET1.FreightPrice))
                            .start_up = CNull.ToDouble(reader(ET1.StartUpPrice))
                            .warranty = CNull.ToDouble(reader(ET1.WarrantyPrice))
                            .base_list_price_is_overridden = CNull.ToBoolean(reader(ET1.ShouldOverrideBaseListPrice))
                            .overridden_base_list_price = CNull.ToDouble(reader(ET1.OverriddenBaseListPrice))
                            Dim code As String = CNull.ToString(reader(ET1.MultiplierCode))
                            If Not String.IsNullOrEmpty(code) Then _
                               .multiplier_code = New MultiplierCode(code)
                        End With

                        .tag = CNull.ToString(reader(ET1.Tag))
                        .special_instructions = CNull.ToString(reader(ET1.Notes))
                        .is_included = CNull.ToBoolean(reader(ET1.Included))

                        '.Parent
                        '.Project

                    End With
                End While
            Catch ex As DataException
                Throw ex
            Finally
                If reader IsNot Nothing Then reader.Close()
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try

            Return unitCooler
        End Function

#End Region




        ''' <summary>
        ''' SQL factory for unit cooler equipment item.
        ''' </summary>
        Private Class SqlFactory


            ''' <summary>
            ''' Gets SQL to insert unit cooler equipment item.
            ''' </summary>
            Shared Function GetInsertUnitCoolerSql(ByVal unitCooler As unit_cooler) As String
                Dim affectedColumns As List(Of SqlColumn) = UnitCoolerColumns(unitCooler)
                Dim builder As New SqlBuilder(affectedColumns, UT.TableName)

                Return builder.GenerateInsertCommand()
            End Function


            ''' <summary>Gets SQL to update unit cooler equipment item.</summary>
            Shared Function GetUpdateUnitCoolerSql(ByVal unitCooler As unit_cooler) As String
                Dim affectedCols As List(Of SqlColumn) = UnitCoolerColumns(unitCooler)
                Dim criteriaCols As New List(Of SqlColumn)
                criteriaCols.Add(New SqlColumn(UT.EquipmentId, SqlDataType.String, unitCooler.id.Id))
                criteriaCols.Add(New SqlColumn(UT.Revision, SqlDataType.Number, unitCooler.revision.ToString))
                Dim builder As New SqlBuilder(affectedCols, UT.TableName, criteriaCols)

                Return builder.GenerateUpdateCommand()
            End Function


            Private Shared Function UnitCoolerColumns(ByVal unitCooler As unit_cooler) As List(Of SqlColumn)
                Dim columns As New List(Of SqlColumn)

                With columns
                    .Add(New SqlColumn(UT.EquipmentId, SqlDataType.String, unitCooler.id.ToString))
                    .Add(New SqlColumn(UT.Revision, SqlDataType.Number, unitCooler.revision.ToString))
                    .Add(New SqlColumn(UT.BoxTemp, SqlDataType.Number, unitCooler.box_temperature.to_string_or_null))
                    .Add(New SqlColumn(UT.Capacity, SqlDataType.Number, unitCooler.capacity.to_string_or_null))
                    .Add(New SqlColumn(UT.CondensingTemp, SqlDataType.Number, unitCooler.condensing_temperature.to_string_or_null))
                    .Add(New SqlColumn(UT.EvaporatorTemp, SqlDataType.Number, unitCooler.evaporator_temperature.to_string_or_null))
                    .Add(New SqlColumn(UT.LiquidTemp, SqlDataType.Number, unitCooler.liquid_temperature.to_string_or_null))
                    .Add(New SqlColumn(UT.TempDifference, SqlDataType.Number, unitCooler.temperature_difference.to_string_or_null))
                    .Add(New SqlColumn(UT.Refrigerant, SqlDataType.String, unitCooler.refrigerant))
                    .Add(New SqlColumn(UT.FanVoltage, SqlDataType.String, unitCooler.fan_voltage.ToString))
                    .Add(New SqlColumn(UT.DefrostVoltage, SqlDataType.String, unitCooler.defrost_voltage.ToString))
                    .Add(New SqlColumn(UT.UnitCoolerType, SqlDataType.String, unitCooler.unit_cooler_type))
                End With

                Return columns
            End Function


        End Class

    End Class

End Namespace