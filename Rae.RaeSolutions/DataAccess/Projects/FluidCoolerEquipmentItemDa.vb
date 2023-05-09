Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic
Imports Rae.Data.Sql
Imports Rae.Io.Text
Imports Rae.RaeSolutions.Business
Imports Rae.RaeSolutions.Business.Entities
Imports CNull = Rae.ConvertNull
Imports CT1 = RAE.RAESolutions.DataAccess.Projects.Tables.FluidCoolerTable
Imports ET1 = RAE.RAESolutions.DataAccess.Projects.Tables.EquipmentTable
Imports OtherCostsDa = Rae.RaeSolutions.DataAccess.Projects.OtherEquipmentCostsDA

Namespace Rae.RaeSolutions.DataAccess.Projects

''' <summary>Provides data access for fluid cooler equipment.</summary>
Public Class FluidCoolerEquipmentItemDa

   ''' <summary>
   ''' Creates fluid cooler equipment.
   ''' </summary>
   ''' <param name="fluidCooler">
   ''' fluid cooler to create.
   ''' </param>
   ''' <returns>Number of rows affected.
   ''' </returns>
   ''' <history by="Casey Joyce" finish="2006/04/26">
   ''' Created
   ''' </history>
   Shared Function Create(fluidCooler As FluidCoolerEquipmentItem) As Integer
      Dim transaction As IDbTransaction
      Dim numRowsAffected As Integer

      Dim connection = Common.CreateConnection(Common.ProjectsDbPath)

      Try
         connection.Open()

         ' begins transaction (everything can be rolled back from the beginning of the transaction until it is committed)
         transaction = connection.BeginTransaction()

         ' inserts only general equipment data into EquipmentItemTable
         EquipmentDa.Create(connection, transaction, fluidCooler)

         ' inserts values into CondensingUnitEquipmentItemTable
         numRowsAffected = FluidCoolerEquipmentItemDa.createFluidCooler(connection, transaction, fluidCooler)

         ' inserts other costs
         OtherCostsDa.Create(connection, transaction, fluidCooler)

         ' saves options
         EquipmentOptionsDa.Create(fluidCooler.options, connection, transaction)

         SpecialOptionsDa.Create(fluidCooler.special_options, connection, transaction)

         ' commits transaction
         transaction.Commit()
      Catch ex As Exception
         ' rolls back transaction
         If Not transaction Is Nothing Then transaction.Rollback()
         Throw New ApplicationException("Attempt to create fluid cooler equipment item failed. Transaction was rolled back.", ex)
      Finally
         If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
      End Try

      Return numRowsAffected
   End Function


   ''' <summary>
   ''' Retrieves fluid cooler equipment.
   ''' </summary>
   ''' <param name="id">
   ''' fluid cooler ID.
   ''' </param>
   ''' <param name="revision">
   ''' Revision number
   ''' </param>
   ''' <returns>
   ''' fluid cooler equipment.
   ''' </returns>
   Shared Function Retrieve(id As String, revision As Single) As FluidCoolerEquipmentItem
      Dim fluidCooler = RetrieveFluidCooler(id, revision)

      fluidCooler.pricing.others = OtherCostsDa.Retrieve(id, revision)

      Dim cmd = New GetAvailableOptionsCommand(fluidCooler) : cmd.Execute

      fluidCooler.special_options = SpecialOptionsDa.RetrieveByEquipmentIdAndRevision(id, revision)
      
      FluidCoolerEquipmentItemDa.GetRatingEquipment(fluidCooler)

      Return fluidCooler
   End Function


   ''' <summary>Updates fluid cooler equipment.</summary>
   ''' <param name="fluidCooler">Fluid cooler equipment to update.</param>
   Shared Sub Update(fluidCooler As FluidCoolerEquipmentItem)
      Dim transaction As IDbTransaction
      Dim command As IDbCommand
      Dim sql As String

      Dim connection = Common.CreateConnection(Common.ProjectsDbPath)

      Try
         connection.Open()
         transaction = connection.BeginTransaction()

         ' updates equipment table
         EquipmentDa.Update(connection, transaction, fluidCooler)

         ' updates fluidCooler table
         sql = SqlFactory.GetUpdateFluidCoolerSql(fluidCooler)
         command = connection.CreateCommand
         command.CommandText = sql
         command.Transaction = transaction
         Dim numRows As Integer = command.ExecuteNonQuery()

         ' updates options
         EquipmentOptionsDa.Save(fluidCooler.options, fluidCooler.id.Id, fluidCooler.revision, connection, transaction)

                SpecialOptionsDa.Save(fluidCooler.special_options, connection, transaction, fluidCooler.id.Id, fluidCooler.revision.ToString)
         SaveRatingEquipment(fluidCooler, connection, transaction)
         transaction.Commit()
      Catch ex As DataException
         If transaction IsNot Nothing Then transaction.Rollback()
         Throw ex
      Finally
         If connection.State <> ConnectionState.Closed Then connection.Close()
      End Try
   End Sub
   

   Shared Sub SaveRatingEquipment(ByRef fluidCooler As FluidCoolerEquipmentItem, conn As IDbConnection, trans As IDbTransaction)
      If Not fluidCooler.RatingEquipment Is Nothing AndAlso Not CheckRatingEquipment(fluidCooler, conn, trans) Then
         Dim cmd As IDbCommand = conn.CreateCommand
         cmd.Transaction = trans
         Dim sql As String = "Insert into RatingEquipment (ProjectID,ProjectRevision,EquipmentID,Revision,RatingEquipmentXML) values"
         sql += " ('" & fluidCooler.ProjectManager.Project.id.Id & "'," & fluidCooler.ProjectManager.Project.Revision.ToString() & ",'" & fluidCooler.id.Id & "'"
         sql += "," & fluidCooler.revision.ToString() & ",'" & Utility.Serialize(fluidCooler.RatingEquipment) & "')"
         cmd.CommandText = sql
         cmd.ExecuteNonQuery()
      ElseIf Not fluidCooler.RatingEquipment Is Nothing Then
         Dim cmd As IDbCommand = conn.CreateCommand
         cmd.Transaction = trans
         Dim sql As String = "Update RatingEquipment set RatingEquipmentXML = '" & Utility.Serialize(fluidCooler.RatingEquipment) & "' where "
         sql += "ProjectID = '" & fluidCooler.ProjectManager.Project.id.Id & "' and ProjectRevision = " & fluidCooler.ProjectManager.Project.Revision.ToString()
         sql += " and EquipmentID = '" & fluidCooler.id.Id & "' and Revision = " & fluidCooler.revision.ToString()
         cmd.CommandText = sql
         cmd.ExecuteNonQuery()
      End If
   End Sub

   Shared Sub GetRatingEquipment(ByRef fluidCooler As FluidCoolerEquipmentItem)
      Dim conn As IDbConnection = Common.CreateConnection(Common.ProjectsDbPath)
      Dim cmd As IDbCommand = conn.CreateCommand
      Dim sql As String = "Select RatingEquipmentXML from RatingEquipment where "
      sql += "ProjectID = '" & fluidCooler.ProjectManager.Project.id.Id & "' and ProjectRevision = " & fluidCooler.ProjectManager.Project.Revision.ToString()
      sql += " and EquipmentID = '" & fluidCooler.id.Id & "' and Revision = " & fluidCooler.revision.ToString()
      cmd.CommandText = sql
      Dim da As IDbDataAdapter = Common.CreateAdapter(cmd)
      Dim ds As New DataSet
      da.Fill(ds)
      If ds.Tables(0).Rows.Count > 0 Then
         fluidCooler.RatingEquipment = Utility.Deserialize(ds.Tables(0).Rows(0)("RatingEquipmentXML").ToString(), Type.GetType("FluidCooler"))
      End If
   End Sub

   Shared Function CheckRatingEquipment(ByRef fluidCooler As FluidCoolerEquipmentItem, conn As IDbConnection, trans As IDbTransaction) As Boolean
      Dim cmd As IDbCommand = conn.CreateCommand
      cmd.Transaction = trans
      Dim sql As String = "Select * from RatingEquipment where ProjectID = '" & fluidCooler.ProjectManager.Project.id.Id & "' and ProjectRevision = " & fluidCooler.ProjectManager.Project.Revision.ToString()
      sql += " and EquipmentID = '" & fluidCooler.id.Id & "' and Revision = " & fluidCooler.revision.ToString()
      Dim ds As New DataSet
      cmd.CommandText = sql
      Dim da As IDbDataAdapter = Common.CreateAdapter(cmd)
      da.Fill(ds)
      If ds.Tables(0).Rows.Count > 0 Then
         Return True
      End If
      Return False
   End Function


#Region " Private methods"

   ''' <summary>Creates only fluid cooler specific data (only in fluid coolerEquipmentItem table). Returns number of rows affected.</summary>
   Private Shared Function createFluidCooler(connection As IDbConnection, transaction As IDbTransaction, _
   fluidCooler As FluidCoolerEquipmentItem) As Integer
      Dim sql = SqlFactory.GetInsertFluidCoolerSql(fluidCooler)
      Dim command = connection.CreateCommand
      command.CommandText = sql
      command.Transaction = transaction
      Dim numRowsAffected = command.ExecuteNonQuery()
      SaveRatingEquipment(fluidCooler, connection, transaction)
      Return numRowsAffected
   End Function


   ''' <summary>Retrieves fluid cooler info in EquipmentItems and CondensingUnitEquipmentItems tables.</summary>
   ''' <param name="id">Equipment ID.</param>
   ''' <param name="revision">Revision number</param>
   ''' <returns>
   ''' fluid cooler equipment item info from EquipmentItems and CondensingUnitEquipmentItems tables, 
   ''' but not OtherEquipmentPricing or Options.
   ''' </returns>
   Private Shared Function RetrieveFluidCooler(id As String, revision As Single) As FluidCoolerEquipmentItem
      Dim connection As IDbConnection
      Dim command As IDbCommand
      Dim reader As IDataReader
      Dim connectionString As String
      Dim sql As New StringBuilder
      Dim equipmentId, projectId As item_id
      Dim name As String
      Dim division As Business.Division

      Dim fluidCoolerEqItem As FluidCoolerEquipmentItem

      connectionString = Common.GetConnectionString(Common.ProjectsDbPath)

            sql.AppendFormat("SELECT * FROM ({0} INNER JOIN {1} ON {0}.{2}={1}.{7} AND {0}.{4}={1}.{6}) WHERE ({0}.{2}='{3}') AND ({0}.{4}={5})",
         ET1.TableName, CT1.TableName, ET1.EquipmentId, id, ET1.Revision, revision.ToString, CT1.Revision, CT1.EquipmentId)

            connection = Common.CreateConnection(Common.ProjectsDbPath)
      command = connection.CreateCommand
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
                    fluidCoolerEqItem = New FluidCoolerEquipmentItem(name, division, equipmentId, New project_manager(projectId))
            ' retrieves the rest of the properties
            With fluidCoolerEqItem
                        ' DBNull.Value.ToString = "", no exception is raised
                        ' TEST: DateGenerated is set by ID?
                        .metadata.Author = reader(ET1.Author).ToString

                        If Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
                  .revision = CSng(reader("Revision").ToString)
               Else
                            .revision = CSng(reader(ET1.TableName & "." & ET1.Revision))
                        End If

                        .model_without_series = reader(ET1.Model).ToString
                        .series = reader(ET1.Series).ToString
                        .custom_model = reader(ET1.CustomModel).ToString

                        ' specs
                        With .Specs
                            .AmbientTemp.set_to(reader(CT1.AmbientTemp))
                            .Capacity.set_to(reader(CT1.Capacity))
                            .EnteringFluidTemp.set_to(reader(CT1.EnteringFluidTemp))
                            .Flow.set_to(reader(CT1.Flow))
                            .Fluid = reader(CT1.Fluid).ToString
                            .GlycolPercent.set_to(reader(CT1.GlycolPercent))
                            .LeavingFluidTemp.set_to(reader(CT1.LeavingFluidTemp))
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

      Return fluidCoolerEqItem
   End Function

#End Region


   ''' <summary>SQL factory for fluidCooler equipment item.</summary>
   Private Class SqlFactory

      Shared Function GetInsertFluidCoolerSql(fluidCooler As FluidCoolerEquipmentItem) As String
         Dim affectedColumns As List(Of SqlColumn) = fluidCoolerColumns(fluidCooler)
                Dim builder As New SqlBuilder(affectedColumns, CT1.TableName)

                Return builder.GenerateInsertCommand()
            End Function

            Shared Function GetUpdateFluidCoolerSql(fluidCooler As FluidCoolerEquipmentItem) As String
                Dim affectedCols As List(Of SqlColumn) = fluidCoolerColumns(fluidCooler)
                Dim criteriaCols As New List(Of SqlColumn)
                criteriaCols.Add(New SqlColumn(CT1.EquipmentId, SqlDataType.String, fluidCooler.id.Id))
                criteriaCols.Add(New SqlColumn(CT1.Revision, SqlDataType.Number, fluidCooler.revision.ToString))
                Dim builder As New SqlBuilder(affectedCols, CT1.TableName, criteriaCols)

                Return builder.GenerateUpdateCommand()
      End Function


      Private Shared Function fluidCoolerColumns(fluidCooler As FluidCoolerEquipmentItem) As List(Of SqlColumn)
         Dim columns As New List(Of SqlColumn)

         With columns
                    .Add(New SqlColumn(CT1.EquipmentId, SqlDataType.String, fluidCooler.id.ToString))
                    .Add(New SqlColumn(CT1.Revision, SqlDataType.Number, fluidCooler.revision.ToString))
                    .Add(New SqlColumn(CT1.AmbientTemp, SqlDataType.Number, fluidCooler.Specs.AmbientTemp.to_string_or_null))
                    .Add(New SqlColumn(CT1.Capacity, SqlDataType.Number, fluidCooler.Specs.Capacity.to_string_or_null))
                    .Add(New SqlColumn(CT1.EnteringFluidTemp, SqlDataType.Number, fluidCooler.Specs.EnteringFluidTemp.to_string_or_null))
                    .Add(New SqlColumn(CT1.Flow, SqlDataType.Number, fluidCooler.Specs.Flow.to_string_or_null))
                    .Add(New SqlColumn(CT1.Fluid, SqlDataType.String, fluidCooler.Specs.Fluid))
                    .Add(New SqlColumn(CT1.GlycolPercent, SqlDataType.Number, fluidCooler.Specs.GlycolPercent.to_string_or_null))
                    .Add(New SqlColumn(CT1.LeavingFluidTemp, SqlDataType.Number, fluidCooler.Specs.LeavingFluidTemp.to_string_or_null))
                End With

         Return columns
      End Function


   End Class

End Class

End Namespace