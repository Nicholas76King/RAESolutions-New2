Imports Rae.Data.Sql
Imports Rae.Io.Text
Imports Rae.RaeSolutions.Business.Entities
Imports System.Collections.Generic
Imports System.Data
Imports Names = Rae.RaeSolutions.DataAccess.Projects.Tables.PumpTable
Imports ET1 = RAE.RAESolutions.DataAccess.Projects.Tables.EquipmentTable
Imports System.Text
Imports CNull = Rae.ConvertNull

Namespace Rae.RaeSolutions.DataAccess.Projects

Public Class PumpEquipmentDa
   
   Shared Function Create(pump As PumpEquipment) As Integer
      Dim transaction As IDbTransaction
      Dim numRowsAffected As Integer

      Dim connection = Common.CreateConnection(Common.ProjectsDbPath)

      Try
         connection.Open()

         transaction = connection.BeginTransaction()

         ' inserts only general equipment data into EquipmentItemTable
         EquipmentDa.Create(connection, transaction, pump)

         ' inserts values into PumpEquipmentItemTable
         numRowsAffected = PumpEquipmentDa.createPump(connection, transaction, pump)

         ' TODO: Other costs revision
         ' inserts other costs
         OtherEquipmentCostsDA.Create(connection, transaction, pump)

         ' saves options
         EquipmentOptionsDa.Create(pump.options, connection, transaction)

         ' creates special options
         SpecialOptionsDa.Create(pump.special_options, connection, transaction)

         ' commits transaction
         transaction.Commit()
      Catch ex As Exception
         If transaction IsNot Nothing Then _
            transaction.Rollback()
         Throw New ApplicationException("Attempt to create pump equipment failed. Transaction was rolled back.", ex)
      Finally
         If connection.State <> ConnectionState.Closed Then _
            connection.Close()
      End Try
   End Function
   
   Shared Function Retrieve(id As String, revision As Single) As PumpEquipment
      Dim pump = retrievePump(id, revision)

      pump.pricing.others = OtherEquipmentCostsDA.Retrieve(id, revision)

      Dim cmd = New GetAvailableOptionsCommand(pump) : cmd.Execute

      pump.special_options = SpecialOptionsDa.RetrieveByEquipmentIdAndRevision(id, revision)

      Return pump
   End Function
   
   Shared Function RetrieveIntegratedPump(chillerId As String) As PumpEquipment
      Dim pumpId = retrievePumpIdFor( New item_id(chillerId) )
      If pumpId Is Nothing Then Return Nothing
      
      ' TODO: retrieve correct revision
      Dim p = Retrieve( pumpId, 0 )
      p.pricing.list_price = Rae.DataAccess.EquipmentOptions.OptionsDataAccess.RetrieveBaseListPrice(p.series, p.model_without_series)
      
      Return p
   End Function
   
   Shared Sub Update(pump As PumpEquipment)
      Dim transaction As IDbTransaction
      Dim command As IDbCommand
      Dim sql As String

      Dim connection = Common.CreateConnection(Common.ProjectsDbPath)

      Try
         connection.Open()
         transaction = connection.BeginTransaction()

         ' updates equipment table
         EquipmentDa.Update(connection, transaction, pump)

         ' updates condenser equipment table
         sql = SqlFactory.GetUpdateSqlFor(pump)
         command = connection.CreateCommand
         command.CommandText = sql
         command.Transaction = transaction
         Dim numRows As Integer = command.ExecuteNonQuery()

         ' updates options
         EquipmentOptionsDa.Save(pump.options, pump.id.Id, pump.revision, connection, transaction)

         ' saves special options
                SpecialOptionsDa.Save(pump.special_options, connection, transaction, pump.id.Id, pump.revision.ToString)

         transaction.Commit()
      Catch ex As DataException
         If transaction IsNot Nothing Then transaction.Rollback()
         Throw ex
      Finally
         If connection.State <> ConnectionState.Closed Then connection.Close()
      End Try
   End Sub
   
   Shared Sub DeletePumpIntegratedWith(chillerId As item_id)
      Dim pumpId = retrievePumpIdFor(chillerId)
      If Not pumpId Is Nothing Then _
         EquipmentDa.Delete(pumpId, Business.EquipmentType.PumpPackage)
   End Sub
   
   
   
   Private Shared Function retrievePumpIdFor(chillerId As item_id) As String
      Dim con = Common.CreateConnection(Common.ProjectsDbPath)
      Dim com = con.CreateCommand()
      Dim sql = New StringBuilder().AppendFormat("SELECT [{0}] FROM {1} WHERE [{2}]='{3}'", _
         Names.EquipmentId, Names.TableName, Names.ChillerId, chillerId.ToString).ToString
      com.CommandText = sql
      Dim pumpId As String
      
      Try
         con.Open()
         pumpId = CNull.ToString( com.ExecuteScalar() )
      Finally
         If con.State <> ConnectionState.Closed Then _
            con.Close()
      End Try
      
      If pumpId = "" Then _
         pumpId = Nothing
      
      Return pumpId
   End Function

   Private Shared Function createPump( _
      connection As IDbConnection, _
      transaction As IDbTransaction, _
      pump As PumpEquipment _
   ) As Integer
      Dim sql = SqlFactory.GetInsertSqlFor(pump)
      Dim command = connection.CreateCommand
      command.CommandText = sql
      command.Transaction = transaction
      Dim numRowsAffected = command.ExecuteNonQuery()

      Return numRowsAffected
   End Function
   
   Private Shared Function retrievePump(id As String, revision As Single) As PumpEquipment
      Dim sql As New StringBuilder
            sql.AppendFormat("SELECT * FROM {0} INNER JOIN {1} ON ({0}.{2}={1}.{7} AND {0}.{6}={1}.{4}) WHERE ({0}.{2}='{3}') AND ({0}.{4}={5})",
         ET1.TableName, Names.TableName, ET1.EquipmentId, id, Names.Revision, revision.ToString, ET1.Revision, Names.EquipmentId)

            Return retrievePump(sql.ToString)
        End Function

        Private Shared Function retrievePump(sql As String) As PumpEquipment
            Dim reader As IDataReader
            Dim equipmentId, projectId As item_id
            Dim name As String
            Dim division As Business.Division
            Dim pump As PumpEquipment

            Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
            Dim command = connection.CreateCommand
            command.CommandText = sql

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
                    pump = New PumpEquipment(name, division, equipmentId, New project_manager(projectId))
                    ' retrieves the rest of the properties
                    With pump
                        ' DBNull.Value.ToString = "", no exception is raised
                        ' TEST: DateGenerated is set by ID?
                        .metadata.Author = reader(ET1.Author).ToString
                        If Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
                            .revision = CSng(reader("Revision"))
                        Else
                            .revision = CSng(reader(Names.TableName & "." & Names.Revision))
                        End If

                        .model_without_series = reader(ET1.Model).ToString
                        .series = reader(ET1.Series).ToString
                        .custom_model = reader(ET1.CustomModel).ToString

                        ' specs
                        .Manufacturer = reader(Names.Manufacturer).ToString
                        .Flow.set_to(reader(Names.Flow))
                        .Head.set_to(reader(Names.Head))
                        GetEnumValue(Of PumpSystem)(reader(Names.System).ToString, .System)

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
                    End With
         End While
      Finally
         If reader IsNot Nothing Then reader.Close()
         If connection.State <> ConnectionState.Closed Then connection.Close()
      End Try

      Return pump
   End Function
   
   Private Class SqlFactory
   
      Shared Function GetInsertSqlFor(pump As PumpEquipment) As String
         Dim affectedColumns = getColumns(pump)
         Dim builder As New SqlBuilder(affectedColumns, Names.TableName)

         Return builder.GenerateInsertCommand()
      End Function
      
      Shared Function GetUpdateSqlFor(pump As PumpEquipment) As String
         Dim affectedCols = getColumns(pump)
         Dim criteriaCols = New List(Of SqlColumn)
         criteriaCols.Add( New SqlColumn(Names.EquipmentId, SqlDataType.String, pump.id.Id) )
         criteriaCols.Add( New SqlColumn(Names.Revision, SqlDataType.Number, pump.revision.ToString) )
         Dim builder = New SqlBuilder(affectedCols, Names.TableName, criteriaCols)
         
         Return builder.GenerateUpdateCommand
      End Function
      
      Private Shared Function getColumns(pump As PumpEquipment) As List(Of SqlColumn)
         Dim columns As New List(Of SqlColumn)
         columns.Add( New SqlColumn(Names.EquipmentId, SqlDataType.String, pump.id.ToString) )
         columns.Add( New SqlColumn(Names.Revision, SqlDataType.Number, pump.revision.ToString) )
         columns.Add( New SqlColumn(Names.Manufacturer, SqlDataType.String, pump.Manufacturer) )
         columns.Add( New SqlColumn(Names.Flow, SqlDataType.Number, pump.Flow.ToString) )
         columns.Add( New SqlColumn(Names.Head, SqlDataType.Number, pump.Head.ToString) )
         columns.Add( New SqlColumn(Names.System, SqlDataType.String, pump.System.ToString) )
         columns.Add( New SqlColumn(Names.ChillerId, SqlDataType.String, CNull.ToString(pump.ChillerId)) )
         Return columns
      End Function
      
   End Class
   
End Class

End Namespace