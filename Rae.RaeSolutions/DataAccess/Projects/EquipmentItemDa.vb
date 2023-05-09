Imports System.Data
Imports System.Collections.Generic
Imports Rae.Data.Sql
Imports Rae.Io.Text
Imports Rae.RaeSolutions.Business.Entities
Imports EQ1 = RAE.RAESolutions.DataAccess.Projects.Tables.EquipmentTable
Imports CNull = Rae.ConvertNull
Imports System.Text

Namespace Rae.RaeSolutions.DataAccess.Projects

    ''' <summary>Provides data access to Equipment table.</summary>
    Public Class EquipmentDa

        ''' <summary>Creates new general info for equipment (not any specific info such as for a condensing unit).</summary>
        Friend Shared Function Create(ByVal connection As IDbConnection, ByVal transaction As IDbTransaction, _
        ByVal equipment As EquipmentItem) As Integer
            Dim sql = SqlFactory.GetInsertEquipmentSql(equipment)
            Dim command = connection.CreateCommand()
            command.CommandText = sql
            command.Transaction = transaction
            Dim numRowsAffected = command.ExecuteNonQuery()

            Return numRowsAffected
        End Function


        ''' <summary>Updates columns in Equipment table.</summary>
        ''' <param name="equipment">Equipment item to update.</param>
        Friend Shared Sub Update(ByVal connection As IDbConnection, ByVal transaction As IDbTransaction, _
        ByVal equipment As EquipmentItem)
            Dim sql As String = SqlFactory.GetUpdateEquipmentSql(equipment)
            Dim command As IDbCommand = connection.CreateCommand
            command.CommandText = sql
            command.Transaction = transaction
            Dim numRowsAffected As Integer = command.ExecuteNonQuery()
        End Sub


        ''' <summary>Retrieves all info for equipment, including info specific to equipment type.</summary>
        ''' <param name="id">ID of equipment to retrieve.</param>
        ''' <param name="revision">Revision number</param>
        ''' <returns>Equipment item.</returns>
        Overloads Shared Function Retrieve(ByVal id As item_id, ByVal revision As Single) As EquipmentItem
            ' gets type, retrieves only general equipment info, just from Equipment table
            Dim equip = RetrieveOnlyInfoInEquipmentTable(id, revision)

            ' creates equipment as a specific type
            equip = EquipmentFactory.CreateEquipment(equip.name, equip.id.Id, _
               equip.type, equip.division, equip.ProjectManager)

            ' sets revision
            equip.revision = revision

            ' retrieves all info for equipment type
            equip.Load()

            Return equip
        End Function


        ''' <summary>Retrieves all info for equipment, including info specific to equipment type.
        ''' Retrieves latest revision.</summary>
        ''' <param name="id">ID of equipment to retrieve.</param>
        ''' <returns>Equipment item.</returns>
        Overloads Shared Function Retrieve(ByVal id As String) As EquipmentItem
            Dim latestRevision = RetrieveLatestRevision(id)
            Return Retrieve(New item_id(id), latestRevision)
        End Function


        ''' <summary>Deletes equipment with the specified ID; deletes all revisions.</summary>
        ''' <param name="id">ID of the equipment to delete.</param>
        Shared Sub Delete(ByVal id As String, ByVal typeOfEquipment As Business.EquipmentType)
            ' TODO: Can this method be simplified to Delete(id, type, con, tra)
            Dim con = Common.CreateConnection(Common.ProjectsDbPath)
            Dim transaction As IDbTransaction

            ' set equipment type if necessary
            ' TODO: is this necessary
            If typeOfEquipment = Business.EquipmentType.NotSet Then
                Dim temporary = EquipmentDa.Retrieve(id)
                typeOfEquipment = temporary.type
            End If

            Try
                con.Open()
                transaction = con.BeginTransaction

                ' deletes items in equipment table
                Dim sql = SqlFactory.GetDeleteEquipmentSql(id)
                Dim command = con.CreateCommand
                command.CommandText = sql
                command.Transaction = transaction
                Dim numEquipmentDeleted = command.ExecuteNonQuery()

                ' deletes items in specific equipment type (eg Condenser) table
                sql = SqlFactory.GetDeleteSpecificEquipmentSql(typeOfEquipment.ToString, id)
                command = con.CreateCommand
                command.CommandText = sql
                command.Transaction = transaction
                Dim numSpecificEquipmentDeleted = command.ExecuteNonQuery()

                ' deletes items in options table
                Dim numOptionsDeleted = EquipmentOptionsDa.delete(id, con, transaction)

                ' deletes items in special options table
                Dim numSpecialOptionsDeleted = SpecialOptionsDa.Delete(id, con, transaction)

                ' deletes equipment / process relation
                command.CommandText = "DELETE FROM [ProcessEquip] WHERE [EquipmentID] = '" & id & "'"
                command.Transaction = transaction
                command.ExecuteNonQuery()

                transaction.Commit()

            Catch ex As DataException
                If transaction IsNot Nothing Then _
                   transaction.Rollback()
                Throw
            Finally
                If con.State <> ConnectionState.Closed Then _
                   con.Close()
            End Try
        End Sub


        ''' <summary>Deletes equipment with the specified ID; deletes all revisions.
        ''' Uses existing connection and transaction.</summary>
        ''' <param name="id">ID of the equipment to delete.</param>
        Shared Sub Delete(ByVal id As String, ByVal typeOfEquipment As Business.EquipmentType, _
        ByVal connection As IDbConnection, ByVal transaction As IDbTransaction)

            ' TODO: is this necessary, set equipment type if necessary
            If typeOfEquipment = Business.EquipmentType.NotSet Then
                Dim tmpEq = EquipmentDa.Retrieve(id)
                typeOfEquipment = tmpEq.type
            End If

            Try
                ' deletes items in equipment table
                Dim sql = SqlFactory.GetDeleteEquipmentSql(id)
                Dim command = connection.CreateCommand
                command.CommandText = sql
                command.Transaction = transaction
                Dim numEquipmentDeleted = command.ExecuteNonQuery()

                ' deletes items in specific equipment type (eg Condenser) table
                sql = SqlFactory.GetDeleteSpecificEquipmentSql(typeOfEquipment.ToString, id)
                command = connection.CreateCommand
                command.CommandText = sql
                command.Transaction = transaction
                Dim numSpecificEquipmentDeleted = command.ExecuteNonQuery()

                ' deletes items in options table
                Dim numOptionsDeleted = EquipmentOptionsDa.delete(id, connection, transaction)

                ' deletes items in special options table
                Dim numSpecialOptionsDeleted = SpecialOptionsDa.Delete(id, connection, transaction)

                ' deletes equipment / process relation
                command = connection.CreateCommand
                command.Transaction = transaction
                command.CommandText = "DELETE FROM [ProcessEquip] WHERE [EquipmentID] = '" & id & "'"

                command.ExecuteNonQuery()
            Finally
            End Try

        End Sub


        ''' <summary>Deletes all equipment in a project</summary>
        Shared Sub DeleteAllEquipment(ByVal projectId As String, _
        ByVal connection As IDbConnection, ByVal transaction As IDbTransaction)
            Dim command = connection.CreateCommand
            Dim sql As String
            Dim reader As IDataReader
            Dim tmpSQL As String = String.Empty

            ' delete any matching process records
            Try
                sql = "SELECT * FROM [" & EQ1.TableName & "] " &
                      "WHERE [" & EQ1.ProjectId & "] = '" & projectId & "'"
                command.Transaction = transaction
                command.CommandText = sql
                reader = command.ExecuteReader()

                While reader.Read()
                    If Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
                        tmpSQL += SqlFactory.GetDeleteEquipmentSql(reader("EquipmentID").ToString) & ";"
                        tmpSQL += SqlFactory.GetDeleteSpecificEquipmentSql(reader("TypeTableName").ToString, reader("EquipmentID").ToString) & ";"
                        tmpSQL += EquipmentOptionsDa.SqlFactory.GetDeleteSql(reader("EquipmentID").ToString) & ";"
                        tmpSQL += SpecialOptionsDa.SqlFactory.GetDeleteSql(reader("EquipmentID").ToString) & ";"
                        tmpSQL += "DELETE FROM [ProcessEquip] WHERE [EquipmentID] = '" & reader("EquipmentID").ToString & "';"
                    Else
                        ' TODO: can the typetablename column be converted to equipmenttype enum 
                        ' instead of passing in notset and retrieve entire equipment to get just the type
                        Delete(reader(EQ1.EquipmentId).ToString, Business.EquipmentType.NotSet, connection, transaction)
                    End If
                End While
                If Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
                    reader.Close()
                    If tmpSQL > " " Then
                        Dim cmd As New SqlClient.SqlCommand(tmpSQL, CType(connection, SqlClient.SqlConnection))
                        cmd.Transaction = CType(transaction, SqlClient.SqlTransaction)
                        cmd.ExecuteNonQuery()
                    End If
                End If
            Finally
                If reader IsNot Nothing Then _
                   reader.Close()
            End Try
        End Sub


        ''' <summary>Retrieves equipment in project.</summary>
        ''' <param name="projectId">ID of project containing equipment.</param>
        ''' <returns>Equipment items</returns>
        Shared Function RetrieveByProject(ByVal projectId As String) As DataTable
            Dim reader As IDataReader
            Dim sql As New StringBuilder
            Dim row As DataRow
            Dim table As New DataTable

            ' creates columns in table
            table.Columns.Add(EQ1.EquipmentId, GetType(String))
            table.Columns.Add(EQ1.Name, GetType(String))

            Dim connection = Common.CreateConnection(Common.ProjectsDbPath)

            sql.AppendFormat("SELECT DISTINCT [{0}], [{1}] FROM [{2}] WHERE [{3}]='{4}'",
               EQ1.EquipmentId, EQ1.Name, EQ1.TableName, EQ1.ProjectId, projectId.ToString)
            Dim command = connection.CreateCommand
            command.CommandText = sql.ToString

            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read
                    row = table.NewRow
                    row(EQ1.EquipmentId) = reader(EQ1.EquipmentId).ToString
                    row(EQ1.Name) = reader(EQ1.Name).ToString
                    'row(EQ1.ProjectId) = reader(EQ1.ProjectId).ToString
                    table.Rows.Add(row)
                End While
            Catch ex As DataException
                Throw ex
            Finally
                If reader IsNot Nothing Then reader.Close()
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try

            Return table
        End Function


        ''' <summary>Renames equipment.</summary>
        ''' <param name="id">ID of equipment to rename.</param>
        ''' <param name="name">New name of equipment.</param>
        Shared Sub Rename(ByVal id As String, ByVal name As String)
            Dim sql As New StringBuilder
            Dim numAffectedRows As Integer

            Dim con = Common.CreateConnection(Common.ProjectsDbPath)

            sql.AppendFormat("UPDATE [{0}] SET [{1}]='{2}' WHERE [{3}]='{4}'",
               EQ1.TableName, EQ1.Name, name, EQ1.EquipmentId, id)
            Dim com = con.CreateCommand
            com.CommandText = sql.ToString

            Try
                con.Open()
                numAffectedRows = com.ExecuteNonQuery()
            Finally
                If con.State <> ConnectionState.Closed Then _
                   con.Close()
            End Try
        End Sub


        ''' <summary>Sets inclusion status.</summary>
        ''' <param name="id">ID of equipment to rename.</param>
        ''' <param name="isIncluded">True to include equipment in project; else false to exclude.</param>
        Shared Sub UpdateIsIncluded(ByVal id As String, ByVal isIncluded As Boolean)
            Dim numAffectedRows As Integer

            Dim con = Common.CreateConnection(Common.ProjectsDbPath)

            Dim sql = New StringBuilder
            sql.AppendFormat("UPDATE [{0}] SET [{1}]={2} WHERE [{3}]='{4}'",
               EQ1.TableName, EQ1.Included, Utility.ConvertDB(isIncluded.GetType(), isIncluded.ToString), EQ1.EquipmentId, id)
            Dim com = con.CreateCommand
            com.CommandText = sql.ToString

            Try
                con.Open()
                numAffectedRows = com.ExecuteNonQuery()
            Finally
                If con.State <> ConnectionState.Closed Then con.Close()
            End Try
        End Sub


        ''' <summary>Retrieves latest revision number of equipment with the specified ID.</summary>
        ''' <param name="id">Equipment ID to retrieve latest revision for</param>
        Shared Function RetrieveLatestRevision(ByVal id As String) As Single
            Dim revision As Single

            Dim sql = SqlFactory.GetRetrieveLatestRevisionSql(id)
            Dim con = Common.CreateConnection(Common.ProjectsDbPath)
            Dim com = con.CreateCommand
            com.CommandText = sql

            Try
                con.Open()
                Dim revisionObj As Object = com.ExecuteScalar()
                If revisionObj Is Nothing Then
                    ' throws if equipment id does not exist
                    'Throw New System.ApplicationException("Latest revision cannot be retrieved. The equipment ID, " & CNull.ToString(id.ToString) & ", does not exist.")
                    revision = 0.0
                Else
                    revision = CSng(revisionObj)
                End If
            Finally
                If Not con.State.Equals(ConnectionState.Closed) Then con.Close()
            End Try

            Return revision
        End Function


        ''' <summary>Retrieves all revisions for the specified equipment ID</summary>
        Shared Function RetrieveAllRevisions(ByVal equipmentId As String) As List(Of Single)
            Dim revisions = New List(Of Single)

            Dim sql = SqlFactory.GetAllRevisions(equipmentId)
            Dim con = Common.CreateConnection(Common.ProjectsDbPath)
            Dim com = con.CreateCommand
            com.CommandText = sql
            Dim rdr As IDataReader

            Try
                con.Open()
                rdr = com.ExecuteReader()
                While rdr.Read
                    revisions.Add(CSng(rdr(Tables.EquipmentTable.Revision)))
                End While
            Finally
                If rdr IsNot Nothing Then rdr.Close()
                If con.State <> ConnectionState.Closed Then con.Close()
            End Try

            Return revisions
        End Function


        ''' <summary>True if is equipment is the latest revision; else false.</summary>
        ''' <param name="id">Equipment ID</param>
        ''' <param name="revision">Revision number to check if is latest revision</param>
        Shared Function IsLatestRevision(ByVal id As String, ByVal revision As Single) As Boolean
            Dim latestRevision = RetrieveLatestRevision(id)
            Dim isLatest = (latestRevision = revision)

            Return isLatest
        End Function


        ''' <summary>Returns whether equipment at specified revision exists.</summary>
        ''' <param name="id">Equipment ID</param>
        ''' <param name="revision">Revision number</param>
        Shared Function Exists(ByVal id As String, ByVal revision As Single) As ExistenceStatus
            Dim existence As ExistenceStatus
            Dim rdr As IDataReader

            Dim sql = SqlFactory.GetRetrieveOnlyInfoInEquipmentTableSql(id, revision)
            Dim con = Common.CreateConnection(Common.ProjectsDbPath)
            Dim com = con.CreateCommand()
            com.CommandText = sql

            Try
                con.Open()
                rdr = com.ExecuteReader()
                Dim i As Integer = 0
                While rdr.Read
                    i += 1
                End While
                If i > 0 Then
                    existence = ExistenceStatus.Existent
                Else
                    existence = ExistenceStatus.Nonexistent
                End If
            Finally
                If rdr IsNot Nothing Then rdr.Close()
                If con.State <> ConnectionState.Closed Then con.Close()
            End Try

            Return existence
        End Function


        ''' <summary>
        ''' Retrieves only information in equipment table.
        ''' Does not contain information that is specific to an equipment type.
        ''' </summary>
        Friend Shared Function RetrieveOnlyInfoInEquipmentTable(ByVal id As item_id, ByVal revision As Single) As EquipmentItem
            Dim reader As IDataReader
            Dim equipment As EquipmentItem

            Dim connection = Common.CreateConnection(Common.ProjectsDbPath)

            Dim command = connection.CreateCommand()
            Dim sql = SqlFactory.GetRetrieveOnlyInfoInEquipmentTableSql(id.Id, revision)
            command.CommandText = sql

            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read
                    Dim equipType As Business.EquipmentType
                    Dim div As Business.Division
                    Dim name, projectId As String
                    GetEnumValue(Of Business.EquipmentType)(reader(EQ1.TypeTableName).ToString, equipType)
                    GetEnumValue(Of Business.Division)(reader(EQ1.Division).ToString, div)
                    name = reader(EQ1.Name).ToString
                    projectId = reader(EQ1.ProjectId).ToString

                    ' may not actually be a condensing unit, just need data
                    equipment = New CondensingUnitEquipmentItem(name, div, id, New project_manager(New item_id(projectId)))
                    equipment.revision = revision

                    equipment.model_without_series = reader(EQ1.Model).ToString
                    equipment.series = reader(EQ1.Series).ToString
                    With equipment
                        .type = equipType
                        .custom_model = reader(EQ1.CustomModel).ToString
                    End With

                    ' common specs
                    With equipment.common_specs
                        .Altitude.set_to(reader(EQ1.Altitude))
                        .ControlVoltage.Parse(CNull.ToString(reader(EQ1.ControlVoltage)))
                        .Height.set_to(reader(EQ1.Height))
                        .Length.set_to(reader(EQ1.Length))
                        .Mca.set_to(reader(EQ1.Mca))
                        .OperatingWeight.set_to(reader(EQ1.OperatingWeight))
                        .Rla.set_to(reader(EQ1.Rla))
                        .ShippingWeight.set_to(reader(EQ1.ShippingWeight))
                        .UnitVoltage.Parse(CNull.ToString(reader(EQ1.UnitVoltage)))
                        .Width.set_to(reader(EQ1.Width))
                    End With

                    ' pricing
                    With equipment.pricing
                        ' there is no list price db field
                        ' others list is handled in seperate method
                        .other_description = reader(EQ1.OtherDescription).ToString
                        .other_price = CNull.ToDouble(reader(EQ1.OtherPrice))
                        .quantity = CNull.ToInteger(reader(EQ1.Quantity))
                        .commission_rate = CNull.ToDouble(reader(EQ1.CommissionRate))
                        .par_multiplier = CNull.ToDouble(reader(EQ1.ParMultiplier))
                        Dim code As String = CNull.ToString(reader(EQ1.MultiplierCode))
                        If Not String.IsNullOrEmpty(code) Then _
                           .multiplier_code = New MultiplierCode(code)
                        .freight = CNull.ToDouble(reader(EQ1.FreightPrice))
                        .start_up = CNull.ToDouble(reader(EQ1.StartUpPrice))
                        .warranty = CNull.ToDouble(reader(EQ1.WarrantyPrice))
                        .base_list_price_is_overridden = CNull.ToBoolean(reader(EQ1.ShouldOverrideBaseListPrice))
                        .overridden_base_list_price = CNull.ToDouble(reader(EQ1.OverriddenBaseListPrice))
                        .multiplier_type = CNull.ToString(reader(EQ1.MultiplierType))
                    End With

                    equipment.tag = CNull.ToString(reader(EQ1.Tag))
                    equipment.special_instructions = CNull.ToString(reader(EQ1.Notes))
                    equipment.is_included = CNull.ToBoolean(reader(EQ1.Included))
                End While
            Catch ex As DataException
                Throw ex
            Finally
                If reader IsNot Nothing Then reader.Close()
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try

            Return equipment
        End Function


        ''' <summary>SQL factory for equipment items.</summary>
        Private Class SqlFactory

            Shared Function GetRetrieveOnlyInfoInEquipmentTableSql( _
            ByVal id As String, ByVal revision As Single) As String
                Return Str("SELECT * FROM [{0}] WHERE [{1}]='{2}' AND [{3}]={4}",
                           EQ1.TableName, EQ1.EquipmentId, id, EQ1.Revision, revision)
            End Function

            Shared Function GetInsertEquipmentSql(ByVal equipment As EquipmentItem) As String
                Dim affectedColumns As List(Of SqlColumn) = equipmentItemColumns(equipment)
                Dim builder As New SqlBuilder(affectedColumns, EQ1.TableName)

                Return builder.GenerateInsertCommand()
            End Function

            Shared Function GetUpdateEquipmentSql(ByVal equipment As EquipmentItem) As String
                Dim affectedCols As List(Of SqlColumn) = equipmentItemColumns(equipment)
                Dim criteriaCols As New List(Of SqlColumn)
                criteriaCols.Add(New SqlColumn(EQ1.EquipmentId, SqlDataType.String, equipment.id.Id))
                criteriaCols.Add(New SqlColumn(EQ1.Revision, SqlDataType.Number, equipment.revision.ToString))
                Dim builder As New SqlBuilder(affectedCols, EQ1.TableName, criteriaCols)

                Return builder.GenerateUpdateCommand()
            End Function

            Shared Function GetRetrieveLatestRevisionSql(ByVal id As String) As String
                Return Str("SELECT [{0}] FROM [{1}] WHERE [{2}]='{3}' ORDER BY [{0}] DESC",
                           EQ1.Revision, EQ1.TableName, EQ1.EquipmentId, id)
            End Function

            Shared Function GetAllRevisions(ByVal id As String) As String
                Return Str("SELECT [{0}] FROM [{1}] WHERE [{2}]='{3}' ORDER BY [{0}]",
                           EQ1.Revision, EQ1.TableName, EQ1.EquipmentId, id)
            End Function

            Shared Function GetDeleteEquipmentSql(ByVal id As String) As String
                Dim criteriaColumns As New List(Of SqlColumn)
                criteriaColumns.Add(New SqlColumn(EQ1.EquipmentId, SqlDataType.String, id))
                Dim deleteEquipmentBuilder As New SqlBuilder(EQ1.TableName, criteriaColumns)
                Dim sql As String = deleteEquipmentBuilder.GenerateDeleteCommand()
                Return sql
            End Function

            Shared Function GetDeleteSpecificEquipmentSql(ByVal tableName As String, ByVal id As String) As String
                Dim criteriaColumns As New List(Of SqlColumn)
                criteriaColumns.Add(New SqlColumn(EQ1.EquipmentId, SqlDataType.String, id))
                Dim deleteSpecificEquipmentBuilder As New SqlBuilder(tableName, criteriaColumns)
                Dim sql As String = deleteSpecificEquipmentBuilder.GenerateDeleteCommand()
                Return sql
            End Function

            Private Shared Function equipmentItemColumns(ByVal equipment As EquipmentItem) As List(Of SqlColumn)
                Dim columns As New List(Of SqlColumn)

                With columns
                    .Add(New SqlColumn(EQ1.EquipmentId, SqlDataType.String, equipment.id.ToString))
                    .Add(New SqlColumn(EQ1.Name, SqlDataType.String, equipment.name))
                    .Add(New SqlColumn(EQ1.ProjectId, SqlDataType.String, equipment.ProjectManager.Project.id.ToString))
                    .Add(New SqlColumn(EQ1.Revision, SqlDataType.Number, equipment.revision.ToString))
                    ' TODO: Is the best way to have table names match business entity types?
                    .Add(New SqlColumn(EQ1.TypeTableName, SqlDataType.String, equipment.type.ToString)) 'equipment.GetType.Name))
                    .Add(New SqlColumn(EQ1.Division, SqlDataType.String, equipment.division.ToString))
                    .Add(New SqlColumn(EQ1.Author, SqlDataType.String, equipment.metadata.Author))

                    .Add(New SqlColumn(EQ1.Series, SqlDataType.String, equipment.series))
                    .Add(New SqlColumn(EQ1.Model, SqlDataType.String, equipment.model_without_series))
                    .Add(New SqlColumn(EQ1.CustomModel, SqlDataType.String, equipment.custom_model))
                    .Add(New SqlColumn(EQ1.Altitude, SqlDataType.Number, equipment.common_specs.Altitude.to_string_or_null))
                    .Add(New SqlColumn(EQ1.UnitVoltage, SqlDataType.String, equipment.common_specs.UnitVoltage.ToString))
                    .Add(New SqlColumn(EQ1.ControlVoltage, SqlDataType.String, equipment.common_specs.ControlVoltage.ToString))
                    .Add(New SqlColumn(EQ1.Mca, SqlDataType.Number, equipment.common_specs.Mca.to_string_or_null))
                    .Add(New SqlColumn(EQ1.Rla, SqlDataType.Number, equipment.common_specs.Rla.to_string_or_null))
                    .Add(New SqlColumn(EQ1.OperatingWeight, SqlDataType.Number, equipment.common_specs.OperatingWeight.to_string_or_null))
                    .Add(New SqlColumn(EQ1.ShippingWeight, SqlDataType.Number, equipment.common_specs.ShippingWeight.to_string_or_null))
                    .Add(New SqlColumn(EQ1.Length, SqlDataType.Number, equipment.common_specs.Length.to_string_or_null))
                    .Add(New SqlColumn(EQ1.Width, SqlDataType.Number, equipment.common_specs.Width.to_string_or_null))
                    .Add(New SqlColumn(EQ1.Height, SqlDataType.Number, equipment.common_specs.Height.to_string_or_null))
                    .Add(New SqlColumn(EQ1.Tag, SqlDataType.String, equipment.tag))
                    .Add(New SqlColumn(EQ1.Notes, SqlDataType.String, equipment.special_instructions))

                    .Add(New SqlColumn(EQ1.Quantity, SqlDataType.Number, equipment.pricing.quantity.ToString))
                    .Add(New SqlColumn(EQ1.OverriddenBaseListPrice, SqlDataType.Number, equipment.pricing.overridden_base_list_price.ToString()))
                    .Add(New SqlColumn(EQ1.ShouldOverrideBaseListPrice, SqlDataType.Boolean, System.Math.Abs(CInt(equipment.pricing.base_list_price_is_overridden)).ToString))
                    .Add(New SqlColumn(EQ1.ParMultiplier, SqlDataType.Number, equipment.pricing.par_multiplier.ToString))
                    .Add(New SqlColumn(EQ1.WarrantyPrice, SqlDataType.Number, equipment.pricing.warranty.ToString))
                    .Add(New SqlColumn(EQ1.FreightPrice, SqlDataType.Number, equipment.pricing.freight.ToString))
                    .Add(New SqlColumn(EQ1.StartUpPrice, SqlDataType.Number, equipment.pricing.start_up.ToString))
                    .Add(New SqlColumn(EQ1.OtherPrice, SqlDataType.Number, equipment.pricing.other_price.ToString))
                    .Add(New SqlColumn(EQ1.OtherDescription, SqlDataType.String, equipment.pricing.other_description))
                    .Add(New SqlColumn(EQ1.CommissionRate, SqlDataType.Number, equipment.pricing.commission_rate.ToString))
                    .Add(New SqlColumn(EQ1.MultiplierCode, SqlDataType.String, CNull.ToString(equipment.pricing.multiplier_code)))
                    .Add(New SqlColumn(EQ1.MultiplierType, SqlDataType.String, CNull.ToString(equipment.pricing.multiplier_type)))
                End With

                Return columns
            End Function

        End Class

    End Class

End Namespace