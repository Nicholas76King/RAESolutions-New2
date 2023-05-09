Imports System
Imports System.Text
Imports System.Data
Imports System.Collections.Generic
Imports Rae.Data.Sql
Imports Rae.Io.Text
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.DataAccess.Projects

Imports ET5 = RAE.RAESolutions.DataAccess.Projects.Tables.EquipmentTable
Imports COT = Rae.RaeSolutions.DataAccess.Projects.Tables.CondensingUnitTable
Imports CNull = Rae.ConvertNull
Imports OtherCostsDA = Rae.RaeSolutions.DataAccess.Projects.OtherEquipmentCostsDA
Imports CO5 = RAE.RAESolutions.DataAccess.Projects.Tables.CondensingUnitTable


Namespace Rae.RaeSolutions.DataAccess.Projects

''' <summary>Provides data access to CondensingUnitEquipment table in Projects database.</summary>
Public Class CondensingUnitEquipmentItemDA

   ''' <summary>Creates condensing</summary>
   ''' <param name="condensingUnit">Condensing unit to create.</param>
   ''' <returns>Num of rows affected.</returns>
   Shared Function Create(condensingUnit As CondensingUnitEquipmentItem) As Integer
      Dim transaction As IDbTransaction
      Dim numRowsAffected As Integer

      Dim connection = Common.CreateConnection(Common.ProjectsDbPath)

      Try
         connection.Open()
         transaction = connection.BeginTransaction()

         ' inserts only general equipment data into EquipmentItemTable
         EquipmentDa.Create(connection, transaction, condensingUnit)

         ' inserts values into CondensingUnitEquipmentItemTable
         numRowsAffected = CondensingUnitEquipmentItemDA.createCondUnit(connection, transaction, condensingUnit)

         OtherCostsDA.Create(connection, transaction, condensingUnit)

         EquipmentOptionsDa.Create(condensingUnit.options, connection, transaction)

         SpecialOptionsDa.Create(condensingUnit.special_options, connection, transaction)

         transaction.Commit()
      Catch ex As Exception
         If transaction IsNot Nothing Then _
            transaction.Rollback
         Throw New ApplicationException("Attempt to create condensing unit equipment item failed. Transaction was rolled back.", ex)
      Finally
         If connection.State <> ConnectionState.Closed Then _
            connection.Close
      End Try

      Return numRowsAffected
   End Function


   ''' <summary>Retrieves condensing unit with equipment ID and revision.</summary>
   ''' <param name="equipmentId">Condensing unit ID.</param>
   ''' <param name="revision">Revision number</param>
   Shared Function Retrieve(equipmentId As String, revision As Single) As CondensingUnitEquipmentItem
      Dim condUnit = retrieveCondUnit(equipmentId, revision)

      condUnit.pricing.others = OtherCostsDA.Retrieve(equipmentId, revision)

            Dim cmd = New GetAvailableOptionsCommand(condUnit) : cmd.Execute()           'this!!!

      condUnit.special_options = SpecialOptionsDa.RetrieveByEquipmentIdAndRevision(equipmentId, revision)

      Return condUnit
   End Function


   ''' <summary>Updates condensing unit equipment.</summary>
   ''' <param name="condensingUnit">Condensing unit equipment to update.</param>
   Shared Sub Update(condensingUnit As CondensingUnitEquipmentItem)
      Dim transaction As IDbTransaction
      Dim connection = Common.CreateConnection(Common.ProjectsDbPath)

      Try
         connection.Open()
         transaction = connection.BeginTransaction()

         ' updates equipment table
         EquipmentDa.Update(connection, transaction, condensingUnit)

         ' updates condensing unit table
         updateCondUnit(connection, transaction, condensingUnit)

         EquipmentOptionsDa.Save(condensingUnit.options, condensingUnit.id.Id, condensingUnit.revision, connection, transaction)

                SpecialOptionsDa.Save(condensingUnit.special_options, connection, transaction, condensingUnit.id.Id, condensingUnit.revision.ToString)

         transaction.Commit()
      Catch ex As dataException
         If transaction IsNot Nothing Then _
            transaction.Rollback
         Throw ex
      Finally
         If connection.State <> ConnectionState.Closed Then _
            connection.Close
      End Try
   End Sub

#Region " Private methods"

   ''' <summary>Creates only data in CondensingUnitEquipmentItem table.
   ''' Returns number of rows affected.</summary>
   Private Shared Function createCondUnit(connection As IDbConnection, _
                                          transaction As IDbTransaction, _
                                          condUnit As CondensingUnitEquipmentItem) As Integer
      Dim sql = SqlFactory.GetInsertCondensingUnitSqlCommand(condUnit)
      Dim command = connection.CreateCommand
      command.CommandText = sql
      command.Transaction = transaction
      Dim numRowsAffected = command.ExecuteNonQuery()

      Return numRowsAffected
   End Function


   ''' <summary>Retrieves condensing unit info in EquipmentItems and CondensingUnitEquipmentItems tables.
   ''' </summary>
   ''' <param name="id">Equipment ID.</param>
   ''' <param name="revision">Revision number</param>
   ''' <returns>
   ''' Condensing unit equipment item info from EquipmentItems and CondensingUnitEquipmentItems tables, 
   ''' but not OtherEquipmentPricing or Options.
   ''' </returns>
   Private Shared Function retrieveCondUnit(id As String, revision As Single) As CondensingUnitEquipmentItem
      Dim sql As New StringBuilder
            sql.AppendFormat("SELECT * FROM ({0} INNER JOIN {1} ON {0}.{2}={1}.{7} AND {0}.{4}={1}.{6}) WHERE ({0}.{2}='{3}') AND ({0}.{4}={5})",
         ET5.TableName, COT.TableName, ET5.EquipmentId, id, ET5.Revision, revision.ToString, COT.Revision, COT.EquipmentId)

            Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
      Dim command = connection.CreateCommand
      command.CommandText = sql.ToString

      Dim reader As IDataReader
      Dim condUnit As CondensingUnitEquipmentItem
      
      Try
         connection.Open()
         reader = command.ExecuteReader()
         While reader.Read
            ' retrieves values required to construct a condensing unit equipment item
            Dim equipmentId As item_id
            If Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
               equipmentId = New item_id(reader("EquipmentId").ToString)
            Else
                        equipmentId = New item_id(reader(ET5.TableName & "." & ET5.EquipmentId).ToString)
                    End If
                    Dim projectId = New item_id(reader(ET5.ProjectId).ToString)
                    Dim name = reader(ET5.Name).ToString
                    Dim division As Business.Division
                    GetEnumValue(reader(ET5.Division).ToString, division)

                    ' constructs
                    condUnit = New CondensingUnitEquipmentItem(name, division, equipmentId, New project_manager(projectId))
            ' retrieves the rest of the properties
            With condUnit
                        ' DBNull.Value.ToString = "", no exception is raised
                        ' TEST: DateGenerated is set by ID?
                        '.MetaData.Author = reader(ET5.Author).ToString
                        If Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
                  .revision = CSng(reader("Revision"))
               Else
                            .revision = CSng(reader(ET5.TableName & "." & ET5.Revision))
                        End If

                        .model_without_series = reader(ET5.Model).ToString
                        .series = reader(ET5.Series).ToString
                        .custom_model = reader(ET5.CustomModel).ToString

                        With .specs
                  .ambient.set_to(reader(COT.AmbientTemp))
                            '    system.diagnostics.debug.writeLine(.ambient.value & ":" & .ambient.has_value)
                  .suction.set_to(reader(COT.SuctionTemp))
                  .evaporating_temperature.set_to(reader(COT.EvapTemp))
                  .capacity_1.set_to(reader(COT.Circuit1Capacity))
                  .capacity_2.set_to(reader(COT.Circuit2Capacity))
                  .capacity_3.set_to(reader(COT.Circuit3Capacity))
                  .capacity_4.set_to(reader(COT.Circuit4Capacity))
                  .refrigerant = reader(COT.Refrigerant).ToString
               End With

               With .common_specs
                            .Altitude.set_to(reader(ET5.Altitude))
                            .ControlVoltage.Parse(CNull.ToString(reader(ET5.ControlVoltage)))
                            .Height.set_to(reader(ET5.Height))
                            .Length.set_to(reader(ET5.Length))
                            .Mca.set_to(reader(ET5.Mca))
                            .OperatingWeight.set_to(reader(ET5.OperatingWeight))
                            .Rla.set_to(reader(ET5.Rla))
                            .ShippingWeight.set_to(reader(ET5.ShippingWeight))
                            .UnitVoltage.Parse(CNull.ToString(reader(ET5.UnitVoltage)))
                            .Width.set_to(reader(ET5.Width))
                        End With

               With .pricing
                            ' there is no list price db field
                            ' others list is handled in seperate method
                            .other_price = CNull.ToDouble(reader(ET5.OtherPrice))
                            .other_description = reader(ET5.OtherDescription).ToString
                            .quantity = CNull.ToInteger(reader(ET5.Quantity))
                            .commission_rate = CNull.ToDouble(reader(ET5.CommissionRate))
                            .par_multiplier = CNull.ToDouble(reader(ET5.ParMultiplier))
                            .freight = CNull.ToDouble(reader(ET5.FreightPrice))
                            .start_up = CNull.ToDouble(reader(ET5.StartUpPrice))
                            .warranty = CNull.ToDouble(reader(ET5.WarrantyPrice))
                            .base_list_price_is_overridden = CNull.ToBoolean(reader(ET5.ShouldOverrideBaseListPrice))
                            .overridden_base_list_price = CNull.ToDouble(reader(ET5.OverriddenBaseListPrice))
                            Dim code As String = CNull.ToString(reader(ET5.MultiplierCode))
                            If Not String.IsNullOrEmpty(code) Then _
                     .multiplier_code = New MultiplierCode(code)
               End With

                        .tag = CNull.ToString(reader(ET5.Tag))
                        .special_instructions = CNull.ToString(reader(ET5.Notes))
                        .is_included = CNull.ToBoolean(reader(ET5.Included))
                    End With
         End While
      Finally
         If reader IsNot Nothing Then _
            reader.Close
         If connection.State <> ConnectionState.Closed Then _
            connection.Close
      End Try

      Return condUnit
   End Function
   
   
   Private Shared Sub updateCondUnit(connection As IDbConnection, _
   transaction As IDbTransaction, condensingUnit As CondensingUnitEquipmentItem)
      Dim sql = SqlFactory.GetUpdateCondensingUnitSql(condensingUnit)
      Dim command = connection.CreateCommand
      command.CommandText = sql
      command.Transaction = transaction
      command.ExecuteNonQuery()
   End Sub

#End Region


   ''' <summary>SQL factory for condensing unit equipment item.</summary>
   Private Class SqlFactory

      Shared Function GetInsertCondensingUnitSqlCommand(condensingUnit As CondensingUnitEquipmentItem) As String
         Dim affectedColumns As List(Of SqlColumn) = CondensingUnitColumns(condensingUnit)
                Dim builder As New SqlBuilder(affectedColumns, CO5.TableName)

                Return builder.GenerateInsertCommand()
      End Function

      Shared Function GetUpdateCondensingUnitSql(condUnit As CondensingUnitEquipmentItem) As String
         Dim affectedCols = CondensingUnitColumns(condUnit)
         Dim criteriaCols = New List(Of SqlColumn)
         criteriaCols.Add(New SqlColumn(COT.EquipmentId, SqlDataType.String, condUnit.id.Id))
         criteriaCols.Add(New SqlColumn(COT.Revision, SqlDataType.Number, condUnit.revision.ToString))
         Dim builder = New SqlBuilder(affectedCols, COT.TableName, criteriaCols)

         Return builder.GenerateUpdateCommand()
      End Function


      Private Shared Function CondensingUnitColumns(condUnit As CondensingUnitEquipmentItem) As List(Of SqlColumn)
         Dim columns As New List(Of SqlColumn)

         With columns
                    .Add(New SqlColumn(CO5.EquipmentId, SqlDataType.String, condUnit.id.ToString))
                    .Add(New SqlColumn(CO5.Revision, SqlDataType.Number, condUnit.revision.ToString))
                    .Add(New SqlColumn(CO5.AmbientTemp, SqlDataType.Number, condUnit.specs.ambient.to_string_or_null))
                    .Add(New SqlColumn(CO5.SuctionTemp, SqlDataType.Number, condUnit.specs.suction.to_string_or_null))
                    .Add(New SqlColumn(CO5.EvapTemp, SqlDataType.Number, condUnit.specs.evaporating_temperature.to_string_or_null))
                    .Add(New SqlColumn(CO5.Refrigerant, SqlDataType.String, condUnit.specs.refrigerant))
                    .Add(New SqlColumn(CO5.Circuit1Capacity, SqlDataType.Number, condUnit.specs.capacity_1.to_string_or_null))
                    .Add(New SqlColumn(CO5.Circuit2Capacity, SqlDataType.Number, condUnit.specs.capacity_2.to_string_or_null))
                    .Add(New SqlColumn(CO5.Circuit3Capacity, SqlDataType.Number, condUnit.specs.capacity_3.to_string_or_null))
                    .Add(New SqlColumn(CO5.Circuit4Capacity, SqlDataType.Number, condUnit.specs.capacity_4.to_string_or_null))
                End With

         Return columns
      End Function

   End Class

End Class

End Namespace
'486