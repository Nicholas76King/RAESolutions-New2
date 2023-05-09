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
Imports UT = Rae.RaeSolutions.DataAccess.Projects.Tables.ProductCoolerTable

Namespace Rae.RaeSolutions.DataAccess.Projects

''' <summary>Provides data access for product coolers</summary>
Public Class ProductCoolerEquipmentItemDa

   ''' <summary>Creates product cooler equipment.</summary>
   ''' <param name="productCooler">product cooler to create.</param>
   ''' <returns>Num of rows affected.</returns>
   Shared Function Create(productCooler As ProductCoolerEquipmentItem) As Integer
      Dim transaction As IDbTransaction
      Dim numRowsAffected As Integer

      Dim connection = Common.CreateConnection(Common.ProjectsDbPath)

      Try
         connection.Open()

         ' begins transaction (everything can be rolled back from the beginning of the transaction until it is committed)
         transaction = connection.BeginTransaction()

         ' inserts only general equipment data into EquipmentItemTable
         EquipmentDa.Create(connection, transaction, productCooler)

         ' inserts values into ProductCoolerEquipmentItemTable
         numRowsAffected = ProductCoolerEquipmentItemDa.createProductCooler(connection, transaction, productCooler)

         ' inserts other costs
         OtherCostsDA.Create(connection, transaction, productCooler)

         ' inserts options
         EquipmentOptionsDa.Create(productCooler.options, connection, transaction)

         SpecialOptionsDa.Create(productCooler.special_options, connection, transaction)

         ' commits transaction
         transaction.Commit()
      Catch ex As Exception
         ' rolls back transaction
         If Not transaction Is Nothing Then transaction.Rollback()
         Throw New ApplicationException("Attempt to create product cooler equipment item failed. Transaction was rolled back.", ex)
      Finally
         If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
      End Try

      Return numRowsAffected
   End Function


   ''' <summary>Retrieves product cooler equipment with equipment ID and revision.</summary>
   ''' <param name="id">product cooler ID.</param>
   ''' <returns>product cooler equipment.</returns>
   Shared Function Retrieve(id As String, revision As Single) As ProductCoolerEquipmentItem
      Dim productCooler = retrieveProductCooler(id, revision)

      productCooler.pricing.others = OtherCostsDA.Retrieve(id, revision)

      Dim cmd = New GetAvailableOptionsCommand(productCooler) : cmd.Execute

      productCooler.special_options = SpecialOptionsDa.RetrieveByEquipmentIdAndRevision(id, revision)

      Return productCooler
   End Function


   ''' <summary>Updates product cooler equipment.</summary>
   ''' <param name="productCooler">product cooler equipment to update.</param>
   Shared Sub Update(productCooler As ProductCoolerEquipmentItem)
      Dim transaction As IDbTransaction
      Dim command As IDbCommand
      Dim connectionString, sql As String

      Dim connection = Common.CreateConnection(Common.ProjectsDbPath)

      Try
         connection.Open()
         transaction = connection.BeginTransaction()

         ' updates equipment table
         EquipmentDa.Update(connection, transaction, productCooler)

         ' updates product cooler table
         sql = SqlFactory.GetUpdateProductCoolerSql(productCooler)
         command = connection.CreateCommand
         command.CommandText = sql
         command.Transaction = transaction
         command.ExecuteNonQuery()

         ' updates equipment options
         EquipmentOptionsDa.Save(productCooler.options, productCooler.id.Id, productCooler.revision, connection, transaction)

                SpecialOptionsDa.Save(productCooler.special_options, connection, transaction, productCooler.id.Id, productCooler.revision.ToString)

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
   ''' Creates only product cooler specific data (only in ProductCoolerEquipmentItem table). Returns number of rows affected.
   ''' </summary>
   Private Shared Function createProductCooler(connection As IDbConnection, transaction As IDbTransaction, _
   productCooler As ProductCoolerEquipmentItem) As Integer
      Dim sql As String = SqlFactory.GetInsertProductCoolerSql(productCooler)
      Dim command As IDbCommand = connection.CreateCommand
      command.CommandText = sql
      command.Transaction = transaction
      Dim numRowsAffected As Integer = command.ExecuteNonQuery()

      Return numRowsAffected
   End Function


   ''' <summary>Retrieves product cooler info in EquipmentItems and ProductCoolerEquipmentItems tables.</summary>
   ''' <param name="equipId">Equipment ID.</param>
   ''' <returns>
   ''' product cooler equipment item info from EquipmentItems and ProductCoolerEquipmentItems tables, 
   ''' but not OtherEquipmentPricing or Options.
   ''' </returns>
   Private Shared Function retrieveProductCooler(equipId As String, revision As Single) As ProductCoolerEquipmentItem
      Dim reader As IDataReader
      Dim sql As New StringBuilder
      Dim equipmentId, projectId As item_id
      Dim name As String
      Dim division As Business.Division

      Dim productCooler As ProductCoolerEquipmentItem

            sql.AppendFormat("SELECT * FROM ({0} INNER JOIN {1} ON {0}.{2}={1}.{7} AND {0}.{4}={1}.{6}) WHERE ({0}.{2}='{3}') AND ({0}.{4}={5})",
         ET1.TableName, UT.TableName, ET1.EquipmentId, equipId.ToString, ET1.Revision, revision.ToString, UT.Revision, UT.EquipmentId)

            Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
            Dim command = connection.CreateCommand
            command.CommandText = sql.ToString

            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read
                    ' retrieves values required to construct a product cooler equipment item
                    If Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
                        equipmentId = New item_id(reader("EquipmentId").ToString)
                    Else
                        equipmentId = New item_id(reader(ET1.TableName & "." & ET1.EquipmentId).ToString)
                    End If

                    projectId = New item_id(reader(ET1.ProjectId).ToString)
                    name = reader(ET1.Name).ToString
                    GetEnumValue(reader(ET1.Division).ToString, division)
                    ' constructs
                    productCooler = New ProductCoolerEquipmentItem(name, division, equipmentId, New project_manager(projectId))
                    ' retrieves the rest of the properties
                    With productCooler
                        ' DBNull.Value.ToString = "", no exception is raised
                        ' TEST: DateGenerated is set by ID?
                        '.MetaData.Author = reader(ET1.Author).ToString
                        If Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
                            .revision = CSng(reader("Revision"))
                        Else
                            .revision = CSng(reader(ET1.TableName & "." & ET1.Revision))
                        End If

                        .model_without_series = reader(ET1.Model).ToString
                        .series = reader(ET1.Series).ToString
                        .custom_model = reader(ET1.CustomModel).ToString

                        ' specs
                        With .Specs
                            .BoxTemp.set_to(reader(UT.BoxTemp))
                            .Capacity.set_to(reader(UT.Capacity))
                            .CondensingTemp.set_to(reader(UT.CondensingTemp))
                            .EvaporatorTemp.set_to(reader(UT.EvaporatorTemp))
                            .LiquidTemp.set_to(reader(UT.LiquidTemp))
                            .TempDifference.set_to(reader(UT.TempDifference))

                            .Refrigerant = reader(UT.Refrigerant).ToString
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
      Catch ex As DataException
         Throw ex
      Finally
         If reader IsNot Nothing Then reader.Close()
         If connection.State <> ConnectionState.Closed Then connection.Close()
      End Try

      Return productCooler
   End Function

#End Region


   Private Class SqlFactory

      Shared Function GetInsertProductCoolerSql(productCooler As ProductCoolerEquipmentItem) As String
         Dim affectedColumns As List(Of SqlColumn) = productCoolerColumns(productCooler)
         Dim builder As New SqlBuilder(affectedColumns, UT.TableName)

         Return builder.GenerateInsertCommand()
      End Function

      Shared Function GetUpdateProductCoolerSql(productCooler As ProductCoolerEquipmentItem) As String
         Dim affectedCols As List(Of SqlColumn) = productCoolerColumns(productCooler)
         Dim criteriaCols As New List(Of SqlColumn)
         criteriaCols.Add(New SqlColumn(UT.EquipmentId, SqlDataType.String, productCooler.id.Id))
         criteriaCols.Add(New SqlColumn(UT.Revision, SqlDataType.Number, productCooler.revision.ToString))
         Dim builder As New SqlBuilder(affectedCols, UT.TableName, criteriaCols)

         Return builder.GenerateUpdateCommand()
      End Function

      Private Shared Function productCoolerColumns(productCooler As ProductCoolerEquipmentItem) As List(Of SqlColumn)
         Dim columns As New List(Of SqlColumn)

         With columns
            .Add(New SqlColumn(UT.EquipmentId, SqlDataType.String, productCooler.id.ToString))
            .Add(New SqlColumn(UT.Revision, SqlDataType.Number, productCooler.revision.ToString))
            .Add(New SqlColumn(UT.BoxTemp, SqlDataType.Number, productCooler.Specs.BoxTemp.to_string_or_null))
            .Add(New SqlColumn(UT.Capacity, SqlDataType.Number, productCooler.Specs.Capacity.to_string_or_null))
            .Add(New SqlColumn(UT.CondensingTemp, SqlDataType.Number, productCooler.Specs.CondensingTemp.to_string_or_null))
            .Add(New SqlColumn(UT.EvaporatorTemp, SqlDataType.Number, productCooler.Specs.EvaporatorTemp.to_string_or_null))
            .Add(New SqlColumn(UT.LiquidTemp, SqlDataType.Number, productCooler.Specs.LiquidTemp.to_string_or_null))
            .Add(New SqlColumn(UT.TempDifference, SqlDataType.Number, productCooler.Specs.TempDifference.to_string_or_null))
            .Add(New SqlColumn(UT.Refrigerant, SqlDataType.String, productCooler.Specs.Refrigerant))
         End With

         Return columns
      End Function

   End Class

End Class

End Namespace