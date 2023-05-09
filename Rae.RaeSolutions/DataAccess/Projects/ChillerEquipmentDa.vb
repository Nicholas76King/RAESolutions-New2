Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic
Imports Rae.Data.Sql
Imports Rae.Io.Text
Imports Rae.RaeSolutions.Business
Imports Rae.RaeSolutions.Business.Entities
Imports CNull = Rae.ConvertNull
Imports CT1 = RAE.RAESolutions.DataAccess.Projects.Tables.ChillerTable
Imports ET1 = RAE.RAESolutions.DataAccess.Projects.Tables.EquipmentTable
Imports OtherCostsDa = Rae.RaeSolutions.DataAccess.Projects.OtherEquipmentCostsDA

Namespace Rae.RaeSolutions.DataAccess.Projects

Public Class ChillerEquipmentDa

   ''' <summary>Creates chiller equipment.</summary>
   ''' <param name="chiller">chiller to create.</param>
   ''' <returns>Num of rows affected.</returns>
   Shared Function Create(chiller As chiller_equipment) As Integer
      Dim transaction As IDbTransaction
      Dim numRowsAffected As Integer

      Dim connection = Common.CreateConnection(Common.ProjectsDbPath)

      Try
         connection.Open()

         transaction = connection.BeginTransaction()

         ' inserts only general equipment data into EquipmentItemTable
         EquipmentDa.Create(connection, transaction, chiller)

         numRowsAffected = ChillerEquipmentDa.createChiller(connection, transaction, chiller)

         OtherCostsDa.Create(connection, transaction, chiller)

         EquipmentOptionsDa.Create(chiller.options, connection, transaction)

         SpecialOptionsDa.Create(chiller.special_options, connection, transaction)
         
         transaction.Commit()
      Catch ex As Exception
         If transaction IsNot Nothing Then _
            transaction.Rollback
         Throw New ApplicationException("Attempt to create chiller equipment item failed. Transaction was rolled back.", ex)
      Finally
         If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
      End Try
      
      If chiller.has_pump_package Then
         chiller.pump_package.SaveIntegrated()
      Else
         PumpEquipmentDa.DeletePumpIntegratedWith(chiller.id)
      End If

      Return numRowsAffected
   End Function


   ''' <summary>Retrieves chiller equipment with equipment ID and revision.</summary>
   ''' <param name="id">Equipment ID</param>
   ''' <param name="revision">Revision number</param>
   Shared Function Retrieve(id As String, revision As Single) As chiller_equipment
      Dim chiller = retrieveChiller(id, revision)

      chiller.pricing.others = OtherCostsDa.Retrieve(id, revision)

      Dim cmd = New GetAvailableOptionsCommand(chiller) : cmd.Execute
      
      chiller.special_options = SpecialOptionsDa.RetrieveByEquipmentIdAndRevision(id, revision)
      
      Dim pump = PumpEquipmentDa.RetrieveIntegratedPump(id)
      If pump IsNot Nothing Then _
         chiller.Add(pump)

      Return chiller
   End Function
   
   ''' <summary>Updates condensing unit equipment.</summary>
   ''' <param name="chiller">Condensing unit equipment to update.</param>
   Shared Sub Update(chiller As chiller_equipment)
      Dim transaction As IDbTransaction
      Dim command As iDbCommand
      Dim sql As String

      Dim connection = Common.CreateConnection(Common.ProjectsDbPath)

      Try
         connection.Open()
         transaction = connection.BeginTransaction()

         ' updates equipment table
         EquipmentDa.Update(connection, transaction, chiller)

         ' updates chiller table
         sql = SqlFactory.GetUpdateChillerSql(chiller)
         command = connection.CreateCommand
         command.CommandText = sql
         command.Transaction = transaction
         Dim numRows As Integer = command.ExecuteNonQuery()

         ' updates options
         EquipmentOptionsDa.Save(chiller.options, chiller.id.Id, chiller.revision, connection, transaction)

         ' updates special options
                SpecialOptionsDa.Save(chiller.special_options, connection, transaction, chiller.id.Id, chiller.revision.ToString)

         transaction.Commit()
      Catch ex As System.Exception   'InvalidOperationException or DataException
         If transaction IsNot Nothing Then transaction.Rollback()
         Throw ex
      Finally
         If connection.State <> ConnectionState.Closed Then connection.Close()
      End Try
      
      If chiller.has_pump_package Then
         chiller.pump_package.SaveIntegrated()
      Else
         PumpEquipmentDa.DeletePumpIntegratedWith(chiller.id)
      End If
      
   End Sub


#Region " Private methods"

   ''' <summary>Creates only chiller specific data (only in ChillerEquipmentItem table). Returns number of rows affected.</summary>
   Private Overloads Shared Function createChiller(connection As IDbConnection, transaction As IDbTransaction, _
   chiller As chiller_equipment) As Integer
      Dim sql = SqlFactory.GetInsertChillerSql(chiller)
      Dim command = connection.CreateCommand
      command.CommandText = sql
      command.Transaction = transaction
      Dim numRowsAffected = command.ExecuteNonQuery()

      Return numRowsAffected
   End Function


   ''' <summary>Retrieves chiller info in EquipmentItems and CondensingUnitEquipmentItems tables.</summary>
   ''' <param name="id">Equipment ID.</param>
   ''' <returns>
   ''' chiller equipment item info from EquipmentItems and CondensingUnitEquipmentItems tables, 
   ''' but not OtherEquipmentPricing or Options.
   ''' </returns>
   Private Shared Function retrieveChiller(id As String, revision As Single) As chiller_equipment
      Dim reader As IDataReader
      Dim sql As New StringBuilder
      Dim equipmentId, projectId As item_id
      Dim name As String
      Dim division As Business.Division

      Dim chiller As chiller_equipment

            sql.AppendFormat("SELECT * FROM ({0} INNER JOIN {1} ON {0}.{2}={1}.{7} AND {0}.{4}={1}.{6}) WHERE ({0}.{2}='{3}') AND ({0}.{4}={5})",
         ET1.TableName, CT1.TableName, ET1.EquipmentId, id, ET1.Revision, revision.ToString, CT1.Revision, CT1.EquipmentId)

            Dim connection = Common.CreateConnection(Common.ProjectsDbPath)

      Dim command = connection.CreateCommand
      command.CommandText = sql.ToString

      Try
         connection.Open()
         reader = command.ExecuteReader()
         While reader.Read
            ' retrieves values required to construct a chiller equipment item
            If Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
               equipmentId = New item_id(reader("EquipmentId").ToString)
            Else
                        equipmentId = New item_id(reader(ET1.TableName & "." & ET1.EquipmentId).ToString)
                    End If
                    'equipmentId = New ItemId(reader(ET1.TableName & "." & ET1.EquipmentId).ToString)
                    projectId = New item_id(reader(ET1.ProjectId).ToString)
                    name = reader(ET1.Name).ToString
                    GetEnumValue(reader(ET1.Division).ToString, division)
                    ' constructs
                    chiller = New chiller_equipment(name, division, equipmentId, New project_manager(projectId))
            ' retrieves the rest of the properties
            With chiller
                        ' DBNull.Value.ToString = "", no exception is raised
                        ' TEST: DateGenerated is set by ID?
                        .metadata.Author = reader(ET1.Author).ToString
                        If Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
                  .revision = CSng(reader("Revision"))
               Else
                            .revision = CSng(reader(ET1.TableName & "." & ET1.Revision))
                        End If
                        '.Revision = CSng(reader(ET1.TableName & "." & ET1.Revision))
                        .model_without_series = reader(ET1.Model).ToString
                        .series = reader(ET1.Series).ToString
                        .custom_model = reader(ET1.CustomModel).ToString

                        ' specs
                        With .Specs
                            .AmbientTemp.set_to(reader(CT1.AmbientTemp))
                            .Capacity.set_to(reader(CT1.Capacity))
                            .EnteringFluidTemp.set_to(reader(CT1.EnteringFluidTemp))
                            .EvaporatorPressureDrop.set_to(reader(CT1.EvaporatorPressureDrop))
                            .Flow.set_to(reader(CT1.Flow))
                            .Fluid = reader(CT1.Fluid).ToString
                            .GlycolPercent.set_to(reader(CT1.GlycolPercent))
                            .LeavingFluidTemp.set_to(reader(CT1.LeavingFluidTemp))
                            .Refrigerant = reader(CT1.Refrigerant).ToString
                            .unit_kw_per_ton = reader(CT1.UnitKwPerTon).ToString()
                        End With

                        .has_balance = ConvertNull.ToBoolean(reader(CT1.has_balance))
                        With .balance_data
                            .blower_amps = ConvertNull.ToDouble(reader(CT1.blower_amps))
                            .compressor_amps_1 = ConvertNull.ToDouble(reader(CT1.compressor_amps_1))
                            .compressor_amps_2 = ConvertNull.ToDouble(reader(CT1.compressor_amps_2))
                            .compressor_quantity_1 = ConvertNull.ToDouble(reader(CT1.compressor_quantity_1))
                            .compressor_quantity_2 = ConvertNull.ToDouble(reader(CT1.compressor_quantity_2))
                            .condenser_quantity = ConvertNull.ToDouble(reader(CT1.condenser_quantity))
                            .spray_pump_amps = ConvertNull.ToDouble(reader(CT1.spray_pump_amps))
                        End with

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
      Finally
         If reader IsNot Nothing Then reader.Close()
         If connection.State <> ConnectionState.Closed Then connection.Close()
      End Try

      Return chiller
   End Function

#End Region

   ''' <summary>SQL factory for chiller equipment item.</summary>
   Private Class SqlFactory

      Shared Function GetInsertChillerSql(chiller As chiller_equipment) As String
         Dim affectedColumns As List(Of SqlColumn) = chillerColumns(chiller)
                Dim builder As New SqlBuilder(affectedColumns, CT1.TableName)

                Return builder.GenerateInsertCommand()
      End Function


      Shared Function GetUpdateChillerSql(chiller As chiller_equipment) As String
         Dim affectedCols As List(Of SqlColumn) = chillerColumns(chiller)
         Dim criteriaCols As New List(Of SqlColumn)
                criteriaCols.Add(New SqlColumn(CT1.EquipmentId, SqlDataType.String, chiller.id.Id))
                criteriaCols.Add(New SqlColumn(CT1.Revision, SqlDataType.Number, chiller.revision.ToString))
                Dim builder As New SqlBuilder(affectedCols, CT1.TableName, criteriaCols)

                Return builder.GenerateUpdateCommand()
      End Function


      Private Shared Function chillerColumns(chiller As chiller_equipment) As List(Of SqlColumn)
         Dim columns As New List(Of SqlColumn)

         With columns
                    .Add(New SqlColumn(CT1.EquipmentId, SqlDataType.String, chiller.id.ToString))
                    .Add(New SqlColumn(CT1.Revision, SqlDataType.Number, chiller.revision.ToString))
                    .Add(New SqlColumn(CT1.AmbientTemp, SqlDataType.Number, chiller.Specs.AmbientTemp.to_string_or_null))
                    .Add(New SqlColumn(CT1.Capacity, SqlDataType.Number, chiller.Specs.Capacity.to_string_or_null))
                    .Add(New SqlColumn(CT1.EnteringFluidTemp, SqlDataType.Number, chiller.Specs.EnteringFluidTemp.to_string_or_null))
                    .Add(New SqlColumn(CT1.EvaporatorPressureDrop, SqlDataType.Number, chiller.Specs.EvaporatorPressureDrop.to_string_or_null))
                    .Add(New SqlColumn(CT1.Flow, SqlDataType.Number, chiller.Specs.Flow.to_string_or_null))
                    .Add(New SqlColumn(CT1.Fluid, SqlDataType.String, chiller.Specs.Fluid))
                    .Add(New SqlColumn(CT1.GlycolPercent, SqlDataType.Number, chiller.Specs.GlycolPercent.to_string_or_null))
                    .Add(New SqlColumn(CT1.LeavingFluidTemp, SqlDataType.Number, chiller.Specs.LeavingFluidTemp.to_string_or_null))
                    .Add(New SqlColumn(CT1.Refrigerant, SqlDataType.String, chiller.Specs.Refrigerant))
                    .Add(New SqlColumn(CT1.UnitKwPerTon, SqlDataType.String, chiller.Specs.unit_kw_per_ton))
                    .Add(New SqlColumn(CT1.compressor_amps_1, SqlDataType.Number, chiller.balance_data.compressor_amps_1.ToString))
                    .Add(New SqlColumn(CT1.compressor_amps_2, SqlDataType.Number, chiller.balance_data.compressor_amps_2.ToString))
                    .Add(New SqlColumn(CT1.compressor_quantity_1, SqlDataType.Number, chiller.balance_data.compressor_quantity_1.ToString))
                    .Add(New SqlColumn(CT1.compressor_quantity_2, SqlDataType.Number, chiller.balance_data.compressor_quantity_2.ToString))
                    .Add(New SqlColumn(CT1.condenser_quantity, SqlDataType.Number, chiller.balance_data.condenser_quantity.ToString))
                    .Add(New SqlColumn(CT1.spray_pump_amps, SqlDataType.Number, chiller.balance_data.spray_pump_amps.ToString))
                    .Add(New SqlColumn(CT1.blower_amps, SqlDataType.Number, chiller.balance_data.blower_amps.ToString))
                    .Add(New SqlColumn(CT1.has_balance, SqlDataType.Boolean, System.Math.Abs(CInt(chiller.has_balance)).ToString))
                End With

         Return columns
      End Function

   End Class

End Class

End Namespace