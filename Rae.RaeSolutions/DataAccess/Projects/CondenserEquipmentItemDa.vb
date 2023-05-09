Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic
Imports Rae.Data.Sql
Imports Rae.Io.Text
Imports Rae.RaeSolutions.Business
Imports Rae.RaeSolutions.Business.Entities
Imports CNull = Rae.ConvertNull
Imports CT1 = RAE.RAESolutions.DataAccess.Projects.Tables.CondenserTable
Imports ET1 = RAE.RAESolutions.DataAccess.Projects.Tables.EquipmentTable
Imports OtherCostsDa = Rae.RaeSolutions.DataAccess.Projects.OtherEquipmentCostsDA

Namespace Rae.RaeSolutions.DataAccess.Projects

''' <summary>Condenser equipment data access.</summary>
Public Class CondenserEquipmentItemDa

   ''' <summary>Creates condenser equipment.</summary>
   ''' <param name="condenser">Condenser to create.</param>
   ''' <returns>Num of rows affected.</returns>
   Shared Function Create(condenser As CondenserEquipmentItem) As Integer
      Dim transaction As IDbTransaction
      Dim numRowsAffected As Integer

      Dim connection = Common.CreateConnection(Common.ProjectsDbPath)

      Try
         connection.Open()

         ' begins transaction (everything can be rolled back from the beginning of the transaction until it is committed)
         transaction = connection.BeginTransaction()

         ' inserts only general equipment data into EquipmentItemTable
         EquipmentDa.Create(connection, transaction, condenser)

         ' inserts values into CondensingUnitEquipmentItemTable
         numRowsAffected = CondenserEquipmentItemDa.createCondenser(connection, transaction, condenser)

         ' TODO: Other costs revision
         ' inserts other costs
         OtherCostsDa.Create(connection, transaction, condenser)

         ' saves options
         EquipmentOptionsDa.Create(condenser.options, connection, transaction)

         ' creates special options
         SpecialOptionsDa.Create(condenser.special_options, connection, transaction)

         ' commits transaction
         transaction.Commit()
      Catch ex As Exception
         ' rolls back transaction
         If Not transaction Is Nothing Then transaction.Rollback()
         Throw New ApplicationException("Attempt to create condenser equipment item failed. Transaction was rolled back.", ex)
      Finally
         If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
      End Try

      Return numRowsAffected
   End Function
   

   ''' <summary>
   ''' Retrieves condenser equipment with specified equipment ID and revision.
   ''' </summary>
   ''' <param name="id">
   ''' Equipment ID.
   ''' </param>
   ''' <param name="revision">
   ''' Revision number.
   ''' </param>
   Shared Function Retrieve(id As String, revision As Single) As CondenserEquipmentItem
      Dim condenser = retrieveCondenser(id, revision)

      condenser.pricing.others = OtherCostsDa.Retrieve(id, revision)

      Dim cmd = New GetAvailableOptionsCommand(condenser) : cmd.Execute

      condenser.special_options = SpecialOptionsDa.RetrieveByEquipmentIdAndRevision(id, revision)

      Return condenser
   End Function


   ''' <summary>
   ''' Updates condenser equipment.
   ''' </summary>
   ''' <param name="condenser">
   ''' Condenser equipment to update.
   ''' </param>
   Shared Sub Update(condenser As CondenserEquipmentItem)
      Dim transaction As IDbTransaction
      Dim command As IDbCommand
      Dim sql As String

      Dim connection = Common.CreateConnection(Common.ProjectsDbPath)

      Try
         connection.Open()
         transaction = connection.BeginTransaction()

         ' updates equipment table
         EquipmentDa.Update(connection, transaction, condenser)

         ' updates condenser equipment table
         sql = SqlFactory.GetUpdateCondenserSql(condenser)
         command = connection.CreateCommand
         command.CommandText = sql
         command.Transaction = transaction
         Dim numRows As Integer = command.ExecuteNonQuery()

         ' updates options
         EquipmentOptionsDa.Save(condenser.options, condenser.id.Id, condenser.revision, connection, transaction)

         ' saves special options
                SpecialOptionsDa.Save(condenser.special_options, connection, transaction, condenser.id.Id, condenser.revision.ToString)

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
   ''' Creates only condenser specific data (only in  CondenserEquipmentItem table). Returns number of rows affected.
   ''' </summary>
   Private Shared Function createCondenser(connection As IDbConnection, transaction As IDbTransaction, _
   condenser As CondenserEquipmentItem) As Integer
      Dim sql= SqlFactory.GetInsertCondenserSql(condenser)
      Dim command = connection.CreateCommand
      command.CommandText = sql
      command.Transaction = transaction
      Dim numRowsAffected = command.ExecuteNonQuery()

      Return numRowsAffected
   End Function


   ''' <summary>
   ''' Retrieves condenser info in EquipmentItems and CondenserEquipmentItems tables.
   ''' Retrieves latest revision.
   ''' </summary>
   ''' <param name="id">
   ''' Equipment ID.
   ''' </param>
   ''' <returns>
   ''' Condenser equipment item info from EquipmentItems and CondenserEquipmentItems tables, 
   ''' but not OtherEquipmentPricing or Options.
   ''' </returns>
   Private Shared Function retrieveCondenser(id As String, revision As Single) As CondenserEquipmentItem
      Dim reader As IDataReader
      Dim sql As New StringBuilder
      Dim equipmentId, projectId As item_id
      Dim name As String
      Dim division As Business.Division

      Dim condenser As CondenserEquipmentItem

            sql.AppendFormat("SELECT * FROM {0} INNER JOIN {1} ON ({0}.{2}={1}.{7} AND {0}.{6}={1}.{4}) WHERE ({0}.{2}='{3}') AND ({0}.{4}={5})",
         ET1.TableName, CT1.TableName, ET1.EquipmentId, id, CT1.Revision, revision.ToString, ET1.Revision, CT1.EquipmentId)

            Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
      Dim command = connection.CreateCommand
      command.CommandText = sql.ToString

      Try
         connection.Open()
         reader = command.ExecuteReader()
         While reader.Read
            ' retrieves values required to construct a fluid cooler equipment item
            If Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
               equipmentId = New item_id(reader("EquipmentId").ToString)
            Else
                        equipmentId = New item_id(reader(ET1.TableName & "." & ET1.EquipmentId).ToString)
                    End If

                    projectId = New item_id(reader(ET1.ProjectId).ToString)
                    name = reader(ET1.Name).ToString
                    GetEnumValue(reader(ET1.Division).ToString, division)
                    ' constructs
                    condenser = New CondenserEquipmentItem(name, division, equipmentId, New project_manager(projectId))
            ' retrieves the rest of the properties
            With condenser
                        ' DBNull.Value.ToString = "", no exception is raised
                        ' TEST: DateGenerated is set by ID?
                        .metadata.Author = reader(ET1.Author).ToString
                        If Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
                  .revision = CSng(reader("Revision"))
               Else
                            .revision = CSng(reader(CT1.TableName & "." & CT1.Revision))
                        End If

                        .model_without_series = reader(ET1.Model).ToString
                        .series = reader(ET1.Series).ToString
                        .custom_model = reader(ET1.CustomModel).ToString

                        ' specs
                        With .Specs
                            .AmbientTemp.set_to(reader(CT1.AmbientTemp))
                            .Fpi.set_to(reader(CT1.Fpi))
                            .Refrigerant = reader(CT1.Refrigerant).ToString
                            .SubCooling = CBool(reader(CT1.SubCooling).ToString)
                            .TempDifference.set_to(reader(CT1.TempDifference))
                            .TotalHeatRejection1.set_to(reader(CT1.ThrCircuit1))
                            .TotalHeatRejection2.set_to(reader(CT1.ThrCircuit2))
                            .TotalHeatRejection3.set_to(reader(CT1.ThrCircuit3))
                            .TotalHeatRejection4.set_to(reader(CT1.ThrCircuit4))
                        End With

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

      Return condenser
   End Function

#End Region

   Private Class SqlFactory

      Shared Function GetInsertCondenserSql(condenser As CondenserEquipmentItem) As String
         Dim affectedColumns As List(Of SqlColumn) = CondenserColumns(condenser)
                Dim builder As New SqlBuilder(affectedColumns, CT1.TableName)

                Return builder.GenerateInsertCommand()
      End Function


      Shared Function GetUpdateCondenserSql(condenser As CondenserEquipmentItem) As String
         Dim affectedCols As List(Of SqlColumn) = CondenserColumns(condenser)
         Dim criteriaCols As New List(Of SqlColumn)
                criteriaCols.Add(New SqlColumn(CT1.EquipmentId, SqlDataType.String, condenser.id.Id))
                criteriaCols.Add(New SqlColumn(CT1.Revision, SqlDataType.Number, condenser.revision.ToString))
                Dim builder As New SqlBuilder(affectedCols, CT1.TableName, criteriaCols)

                Return builder.GenerateUpdateCommand()
      End Function


      Private Shared Function CondenserColumns(condenser As CondenserEquipmentItem) As List(Of SqlColumn)
         Dim columns As New List(Of SqlColumn)

         With columns
                    .Add(New SqlColumn(CT1.EquipmentId, SqlDataType.String, condenser.id.ToString))
                    .Add(New SqlColumn(CT1.Revision, SqlDataType.Number, condenser.revision.ToString))
                    .Add(New SqlColumn(CT1.AmbientTemp, SqlDataType.Number, condenser.Specs.AmbientTemp.to_string_or_null))
                    .Add(New SqlColumn(CT1.Fpi, SqlDataType.Number, condenser.Specs.Fpi.to_string_or_null))
                    .Add(New SqlColumn(CT1.Refrigerant, SqlDataType.String, condenser.Specs.Refrigerant))
                    .Add(New SqlColumn(CT1.SubCooling, SqlDataType.Boolean, System.Math.Abs(CInt(condenser.Specs.SubCooling)).ToString))
                    .Add(New SqlColumn(CT1.TempDifference, SqlDataType.Number, condenser.Specs.TempDifference.to_string_or_null))
                    .Add(New SqlColumn(CT1.ThrCircuit1, SqlDataType.Number, condenser.Specs.TotalHeatRejection1.to_string_or_null))
                    .Add(New SqlColumn(CT1.ThrCircuit2, SqlDataType.Number, condenser.Specs.TotalHeatRejection2.to_string_or_null))
                    .Add(New SqlColumn(CT1.ThrCircuit3, SqlDataType.Number, condenser.Specs.TotalHeatRejection3.to_string_or_null))
                    .Add(New SqlColumn(CT1.ThrCircuit4, SqlDataType.Number, condenser.Specs.TotalHeatRejection4.to_string_or_null))
                End With

         Return columns
      End Function

   End Class

End Class

End Namespace