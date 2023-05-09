Imports Rae.Data.Sql
Imports Rae.DataAccess.EquipmentOptions
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.DataAccess
Imports OT = Rae.RaeSolutions.DataAccess.Projects.Tables.EquipmentOptionsTable
Imports System.Text
Imports System.Data
Imports System.Collections.Generic

Namespace Rae.RaeSolutions.DataAccess.Projects

''' <summary>Provides data access to equipment options.</summary>
Public Class EquipmentOptionsDa

#Region " Public methods"

   Shared Function Get_options_selected_for(unit As EquipmentItem) As EquipmentOptionList
      'Dim options = from_users_project.get_id_and_quantity_for(unit)
      Dim incomplete_options = get_id_and_quantity_from_users_project_for(unit)
      Dim selected_options = complete_options_with_current_pricing(incomplete_options, unit)
      Return selected_options
   End Function
   
   ' todo: does this include standard options, if not when are obsolete standard options handled
   Shared Function Get_options_marked_obsolete_for(unit As EquipmentItem) As EquipmentOptionList
      Dim incomplete_options = get_id_and_quantity_from_users_project_for(unit)
      Dim obsolete_options = from_last_available_pricing_get_and_complete_any_obsolete_options_in(incomplete_options, unit)
      Return obsolete_options
   End Function
   
   Shared Function Get_options_missing_from(unit As EquipmentItem) As EquipmentOptionList
      Dim ops = get_id_and_quantity_from_users_project_for(unit)
      Dim missingOps = findMissingPricingOps(ops, unit)
      Return missingOps
   End Function

        Shared Function Get_replacement_for(ByVal legacyOp As EquipmentOption, ByVal unit As EquipmentItem) As EquipmentOption

            If legacyOp Is Nothing Then
                Return Nothing
            Else
                Dim numFans As Integer
                If TypeOf unit Is unit_cooler Then _
                   numFans = CType(unit, unit_cooler).fan_quantity

                Dim replacementOp = OptionsDataAccess.RetrieveOption( _
                   unit.series, unit.model_without_series, _
                   legacyOp.Code, legacyOp.Voltage, numFans, 0)

                Dim op As EquipmentOption
                If replacementOp IsNot Nothing Then
                    op = New EquipmentOption
                    op.Import(replacementOp)
                End If

                Return op
            End If




        End Function
   
        Shared Function Get_option(ByVal series As String, ByVal model_number As String, ByVal voltage As Integer, ByVal code As String, ByVal fanMotorPhase As Integer) As EquipmentOption
            Dim da_option = OptionsDataAccess.RetrieveOption(series, model_number, code, voltage, 0, fanMotorPhase)

            Dim [option] As EquipmentOption
            If da_option IsNot Nothing Then
                [option] = New EquipmentOption()
                [option].Import(da_option)
            End If

            Return [option]
        End Function

#End Region


#Region " Non public methods"

   ' easier to delete all and then recreate all than to track which options have been deselected on every save.
   Friend Overloads Shared Sub Save( _
      options As EquipmentOptionList, _
      equipmentId As String, _
      revision As Single, _
      connection As IDbConnection, _
      transaction As IDbTransaction _
   )
      delete(equipmentId, revision, connection, transaction)
      Create(options, connection, transaction)
   End Sub


   ''' <summary>Creates options in equipment's option list. Runs in transaction.</summary>
   ''' <param name="options">Equipment containing options. Options Equipment.Id property must be set.</param>
   Friend Shared Sub Create(options As EquipmentOptionList, _
   connection As IDbConnection, transaction As IDbTransaction)
      Dim command As IDbCommand
      Dim sql As String

      For Each op In options
         ' creates option
         ' BUG: options.Equipment.Id.Id is not update op.Equipment.Id.Id is updated
         sql = SqlFactory.GetInsertEquipmentOptionSql(op, options.Equipment.id.Id)
         command = connection.CreateCommand
         command.CommandText = sql
         command.Transaction = transaction
         Dim numRowsAffected As Integer = command.ExecuteNonQuery()

         ' gets created ID for option
         sql = "SELECT MAX([" & OT.Id & "]) FROM [" & OT.TableName & "]"
         command = connection.CreateCommand 'New OleDbCommand(sql, connection)
         command.CommandText = sql
         command.Transaction = transaction
         op.Id = CInt(command.ExecuteScalar())
      Next
   End Sub

   ''' <summary>Deletes options from _one revision_ of equipment.</summary>
   Private Shared Sub delete(equipmentId As String, revision As Single, _
   connection As IDbConnection, transaction As IDbTransaction)
      Dim sql As New StringBuilder
      sql.AppendFormat("DELETE FROM [{0}] WHERE [{1}]='{2}' AND [{3}]={4}", _
         OT.TableName, OT.EquipmentId, equipmentId, OT.Revision, revision.ToString)
      Dim command = connection.CreateCommand()
      command.CommandText = sql.ToString
      command.Transaction = transaction
      Dim numOptionsCleared = command.ExecuteNonQuery()
   End Sub


   ''' <summary>Deletes options from _all revisions_ of equipment</summary>
   Friend Shared Function Delete(equipmentId As String, _
   connection As IDbConnection, transaction As IDbTransaction) As Integer
      Dim sql = SqlFactory.GetDeleteSql(equipmentId)
      Dim command = connection.CreateCommand()
      command.CommandText = sql
      command.Transaction = transaction
      Dim numOptionsDeleted As Integer = command.ExecuteNonQuery()
      Return numOptionsDeleted
   End Function


   ''' <summary>Determines whether option exists.</summary>
   ''' <param name="optionId">Option ID.</param>
   ''' <param name="connection">Connection</param>
   ''' <param name="transaction">Transaction</param>
   ''' <returns>True if option exists; else false.</returns>
   Friend Shared Function Exists(optionId As Integer, revision As Single, _
   connection As IDbConnection, transaction As IDbTransaction) As Boolean
      Dim sql = SqlFactory.GetExistsSql(optionId, revision)
      Dim command = connection.CreateCommand 
      command.CommandText = sql
      command.Transaction = transaction
      Dim reader = command.ExecuteReader()
      Dim found As Boolean = False
      Dim i As Integer = 0
      While reader.Read
         i += 1
      End While
      If i > 0 Then _
         found = True
      If reader IsNot Nothing Then _
         reader.Close

      Return found
   End Function



   ''' <summary>Retrieves list of options with PricingIds and Quantity, 
   ''' but the rest of the info still needs to be retrieved.</summary>
   Private Shared Function get_id_and_quantity_from_users_project_for(unit As EquipmentItem) As EquipmentOptionList
      Dim reader As IDataReader
      Dim sql As New StringBuilder
      Dim options As New EquipmentOptionList(unit)
      Dim op As EquipmentOption

      Dim connection = Common.CreateConnection(Common.ProjectsDbPath)

      sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}]='{2}' AND [{3}]={4}", _
         OT.TableName, OT.EquipmentId, unit.id.Id, OT.Revision, unit.revision.ToString)
      Dim command = connection.CreateCommand
      command.CommandText = sql.ToString

      Try
         connection.Open()
         reader = command.ExecuteReader
         While reader.Read
            op = New EquipmentOption

            ' Id in for option in Projects database, Options table
            op.Id = CInt(reader(OT.Id))
            ' could delete all and then insert all on update
            ' -or -
            ' could check for changes and update only those changed
            op.PricingId = CInt(reader(OT.PricingId))
            ' equipment is null at this point and would throw exception
            ' equipment property will be set when option is added to list
            'op.Equipment.Id = New ItemId(CStr(reader(OT.EquipmentId)))
            op.Quantity = CInt(reader(OT.Quantity))

            options.Add(op)
         End While
      Finally
         If reader IsNot Nothing Then reader.Close()
         If connection.State <> ConnectionState.Closed Then connection.Close()
      End Try

      Return options
   End Function


   ''' <summary>Retrieves option info from EquipmentOptions database, while preserving saved quantity and ID properites.</summary>
   ''' <param name="incomplete_options">Options with PricingIds to get the remaining info for.</param>
   ''' <param name="unit">Equipment item the options apply to.</param>
   Private Shared Function complete_options_with_current_pricing( _
   incomplete_options As EquipmentOptionList, unit As EquipmentItem) As EquipmentOptionList
      Dim complete_options As New EquipmentOptionList(unit)

      For Each incomplete_option In incomplete_options
         Dim complete_option = EquipmentOptionsAgent.OptionsDA.RetrieveOption(incomplete_option.PricingId)
         Dim obsolete_option = EquipmentOptionsAgent.OptionsDA.GetObsoleteOption(incomplete_option.PricingId)
         If complete_option IsNot Nothing AndAlso obsolete_option Is Nothing Then
            complete_option.Quantity = incomplete_option.Quantity
            complete_option.Id = incomplete_option.Id
            complete_options.Add(complete_option)
         End If
      Next

      Return complete_options
   End Function
   
   Private Shared Function from_last_available_pricing_get_and_complete_any_obsolete_options_in( _
                           incomplete_options As EquipmentOptionList, unit As EquipmentItem _
   ) As EquipmentOptionList
      Dim obsolete_options = New EquipmentOptionList(unit)
      
      For Each incomplete_option In incomplete_options
         Dim obsolete_option = EquipmentOptionsAgent.OptionsDA.GetObsoleteOption(incomplete_option.PricingId)
         If obsolete_option IsNot Nothing Then
            obsolete_option.Quantity = incomplete_option.Quantity
            obsolete_option.Id       = incomplete_option.Id
            obsolete_options.Add(obsolete_option)
         End If
      Next
      
      Return obsolete_options
   End Function
   
   Private Shared Function findMissingPricingOps( _
   ops As EquipmentOptionList, equip As EquipmentItem) As EquipmentOptionList
      Dim obsoleteOps = New EquipmentOptionList(equip)
      For Each op In ops
         If idIsMissing(op.PricingId)
            obsoleteOps.Add(op)
         End If
      Next
      
      Return obsoleteOps
   End Function
   
   Private Shared Function isObsolete(pricingId As Integer) As Boolean
      Return EquipmentOptionsAgent.OptionsDA.IsObsolete(pricingId)
   End Function
   
   Private Shared Function idIsMissing(pricingId As Integer) As Boolean
      Return (EquipmentOptionsAgent.OptionsDA.RetrieveOption(pricingId) Is Nothing)
   End Function

#End Region

   ''' <summary>SQL factory for equipment options.</summary>
   Public Class SqlFactory

      Shared Function GetInsertEquipmentOptionSql(op As EquipmentOption, equipmentId As String) As String
         Dim affectedColumns As List(Of SqlColumn) = OptionColumns(op, equipmentId)
         Dim builder As New SqlBuilder(affectedColumns, OT.TableName)

         Return builder.GenerateInsertCommand()
      End Function

      Shared Function GetUpdateEquipmentOptionSql(op As EquipmentOption, equipmentId As String) As String
         Dim affectedColumns As List(Of SqlColumn) = OptionColumns(op, equipmentId)
         Dim criteriaCols As New List(Of SqlColumn)
         criteriaCols.Add(New SqlColumn(OT.Id, SqlDataType.Number, op.Id.ToString))
         criteriaCols.Add(New SqlColumn(OT.Revision, SqlDataType.Number, op.Revision.ToString))
         Dim builder As New SqlBuilder(affectedColumns, OT.TableName, criteriaCols)

         Return builder.GenerateUpdateCommand()
      End Function

      Shared Function GetExistsSql(id As Integer, revision As Single) As String
         Dim sql As New StringBuilder()

         sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}]={2} AND [{3}]={4}", _
         OT.TableName, OT.Id, id.ToString, OT.Revision, revision.ToString)

         Return sql.ToString
      End Function

      Shared Function GetDeleteSql(id As String) As String
         Dim criteriaColumns As New List(Of SqlColumn)
         criteriaColumns.Add(New SqlColumn(OT.EquipmentId, SqlDataType.String, id))
         Dim builder As New SqlBuilder(OT.TableName, criteriaColumns)
         Dim sql As String = builder.GenerateDeleteCommand()
         Return sql
      End Function

      Private Shared Function OptionColumns(op As EquipmentOption, equipmentId As String) As List(Of SqlColumn)
         Dim columns As New List(Of SqlColumn)

         With columns
            .Add(New SqlColumn(OT.EquipmentId, SqlDataType.String, equipmentId))
            .Add(New SqlColumn(OT.Revision, SqlDataType.Number, op.Equipment.revision.ToString))
            .Add(New SqlColumn(OT.PricingId, SqlDataType.Number, op.PricingId.ToString))
            .Add(New SqlColumn(OT.Quantity, SqlDataType.Number, op.Quantity.ToString))
         End With

         Return columns
      End Function

   End Class

End Class

End Namespace