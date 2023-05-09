Imports Rae.RaeSolutions.Business.Entities
Imports System.Text
Imports System.Data
Imports Rae.Data.Sql
Imports System.Collections.Generic
Imports T1 = RAE.RAESolutions.DataAccess.Projects.Tables.SpecialOptionsTable

Namespace Rae.RaeSolutions.DataAccess.Projects

   ''' <summary>
   ''' Provides data access for special options.
   ''' </summary>
   Public Class SpecialOptionsDa

      ''' <summary>
      ''' Retrieves special option by auto-number ID generated by database.
      ''' </summary>
      ''' <param name="id">
      ''' Special option ID, auto-number generated by database
      ''' </param>
      Public Shared Function Retrieve(ByVal id As Integer) As SpecialOption
         Dim op As SpecialOption
         Dim connection As IDbConnection
         Dim command As IDbCommand
         Dim reader As IDataReader
            Dim sql As String

         connection = Common.CreateConnection(Common.ProjectsDbPath)

         sql = SqlFactory.GetRetrieveSql(id)
         command = connection.CreateCommand
         command.CommandText = sql

         Try
            connection.Open()
            reader = command.ExecuteReader()
            While reader.Read
                    op = New SpecialOption(CInt(reader(T1.Id)), CInt(reader(T1.Revision)))
                    op.Code = reader(T1.Code).ToString
                    op.Price.set_to(reader(T1.Price))
                    op.AuthorizedBy = reader(T1.AuthorizedBy).ToString
                    op.AuthorizedFor = reader(T1.AuthorizedFor).ToString
                    op.Description = reader(T1.Description).ToString
                    op.Quantity.set_to(reader(T1.Quantity))
                    op.EquipmentId = New item_id(reader(T1.EquipmentId).ToString)
                End While
         Catch ex As DataException
            Throw ex
         Finally
            If reader IsNot Nothing Then reader.Close()
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try

         Return op
      End Function


      ''' <summary>
      ''' Retrieves list of special options in equipment.
      ''' </summary>
      ''' <param name="id">
      ''' Equipment ID.
      ''' </param>
      ''' <param name="revision">
      ''' Revision number
      ''' </param>
      Public Shared Function RetrieveByEquipmentIdAndRevision(ByVal id As String, ByVal revision As Single) As SpecialOptionList
         Dim op As SpecialOption
         Dim connection As IDbConnection
         Dim command As IDbCommand
         Dim reader As IDataReader
            Dim sql As String
         Dim ops As New SpecialOptionList

         sql = SqlFactory.GetRetrieveByEquipmentIdAndRevisionSql(id, revision)
         connection = Common.CreateConnection(Common.ProjectsDbPath)

         command = connection.CreateCommand
         command.CommandText = sql

         Try
            connection.Open()
            reader = command.ExecuteReader()
            While reader.Read
                    op = New SpecialOption(CInt(reader(T1.Id)), CInt(reader(T1.Revision)))
                    op.Code = reader(T1.Code).ToString
                    op.Price.set_to(reader(T1.Price))
                    op.AuthorizedBy = reader(T1.AuthorizedBy).ToString
                    op.AuthorizedFor = reader(T1.AuthorizedFor).ToString
                    op.Description = reader(T1.Description).ToString
                    op.Quantity.set_to(reader(T1.Quantity))
                    op.EquipmentId = New item_id(reader(T1.EquipmentId).ToString)

                    ops.Add(op)
            End While
         Catch ex As DataException
            Throw ex
         Finally
            If reader IsNot Nothing Then reader.Close()
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try

         Return ops
      End Function


      ''' <summary>
      ''' Updates special option.
      ''' </summary>
      Public Shared Sub Update(ByVal op As SpecialOption)
         Dim connection As IDbConnection
         Dim command As IDbCommand
            Dim sql As String

         connection = Common.CreateConnection(Common.ProjectsDbPath)

         sql = SqlFactory.GetUpdateSql(op)
         command = connection.CreateCommand
         command.CommandText = sql

         Try
            connection.Open()
            command.ExecuteNonQuery()
         Catch ex As DataException
            Throw ex
         Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try
      End Sub

      ''' <summary>
      ''' Updates special option using existing connection and transaction.
      ''' </summary>
      Friend Shared Sub Update(ByVal op As SpecialOption, _
      ByVal connection As IDbConnection, ByVal transaction As IDbTransaction)
         Dim command As IDbCommand
         Dim sql As String
         Dim numRows As Integer

         sql = SqlFactory.GetUpdateSql(op)
         command = connection.CreateCommand
         command.CommandText = sql
         command.Transaction = transaction

         numRows = command.ExecuteNonQuery()
      End Sub


      ''' <summary>
      ''' Saves special options.
      ''' </summary>
      ''' <param name="options">
      ''' Special options to save.</param>
        Public Shared Sub Save(ByVal options As SpecialOptionList, _
        ByVal connection As IDbConnection, ByVal transaction As IDbTransaction, ByVal equipmentID As String, ByVal revision As String)

            Delete(equipmentID, connection, transaction, revision)

            For Each op As SpecialOption In options

                'If Exists(op.Id, connection, transaction) Then
                '    Update(op, connection, transaction)
                'Else
                Create(op, connection, transaction)
                'End If
            Next
        End Sub


      ''' <summary>
      ''' Creates a special option.
      ''' </summary>
      Public Shared Sub Create(ByRef op As SpecialOption)
         Dim connection As IDbConnection
         Dim command As IDbCommand
         Dim connectionString, sql As String

         connectionString = Common.GetConnectionString(Common.ProjectsDbPath)
         connection = Common.CreateConnection(Common.ProjectsDbPath)

         Try
            connection.Open()

            sql = SqlFactory.GetCreateSql(op)
            command = connection.CreateCommand
            command.CommandText = sql
            command.ExecuteNonQuery()

            ' retrieves id of
            sql = SqlFactory.GetLastId()
            command = connection.CreateCommand
            command.CommandText = sql
            op.Id = CInt(command.ExecuteScalar())

         Catch ex As DataException
            Throw ex
         Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try
      End Sub

      ''' <summary>
      ''' Creates a special option.
      ''' </summary>
      Friend Shared Sub Create(ByVal op As SpecialOption, ByVal connection As IDbConnection, ByVal transaction As IDbTransaction)
         Dim command As IDbCommand
         Dim sql As String

         sql = SqlFactory.GetCreateSql(op)
         command = connection.CreateCommand
         command.CommandText = sql
         command.Transaction = transaction
         command.ExecuteNonQuery()

         ' retrieves id of created option
         sql = SqlFactory.GetLastId()
         command = connection.CreateCommand
         command.CommandText = sql
         command.Transaction = transaction
         op.Id = CInt(command.ExecuteScalar())
      End Sub

      ''' <summary>
      ''' Creates special options.
      ''' </summary>
      Friend Shared Sub Create(ByVal ops As SpecialOptionList, ByVal connection As IDbConnection, ByVal transaction As IDbTransaction)
         For Each op As SpecialOption In ops
            Create(op, connection, transaction)
         Next
      End Sub


      ''' <summary>
      ''' Checks if special option exists with auto number ID parameter. 
      ''' Returns true if exists; else false.
      ''' </summary>
      Public Shared Function Exists(ByVal id As Integer) As Boolean
         Dim found As Boolean = False
         Dim connection As IDbConnection
         Dim command As IDbCommand
         Dim reader As IDataReader
            '    Dim connectionString As String

         connection = Common.CreateConnection(Common.ProjectsDbPath)

         command = connection.CreateCommand
         command.CommandText = SqlFactory.GetRetrieveSql(id)

         Try
            connection.Open()
            reader = command.ExecuteReader()
            Dim i As Integer = 0
            While reader.Read
               i += 1
            End While
            If i > 0 Then
               found = True
            End If
            'found = reader.HasRows()
         Catch ex As DataException
            Throw ex
         Finally
            If reader IsNot Nothing Then reader.Close()
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try

         Return found
      End Function

      ''' <summary>
      ''' Checks if special option exists with auto number ID generated by database. 
      ''' Returns true if exists; else false.
      ''' </summary>
      ''' <param name="id">
      ''' Special option ID, auto number ID generated by database.
      ''' </param>
      Friend Shared Function Exists(ByVal id As Integer, _
      ByVal connection As IDbConnection, ByVal transaction As IDbTransaction) As Boolean
         Dim found As Boolean = False
         Dim command As IDbCommand
         Dim reader As IDataReader

         Try
            command = connection.CreateCommand
            command.CommandText = SqlFactory.GetRetrieveSql(id)
            command.Transaction = transaction
            reader = command.ExecuteReader()
            Dim i As Integer = 0
            While reader.Read
               i += 1
            End While
            If i > 0 Then
               found = True
            End If
            'found = reader.HasRows()
         Catch ex As DataException
            Throw ex
         Finally
            If reader IsNot Nothing Then reader.Close()
         End Try

         Return found
      End Function


      ''' <summary>
      ''' Deletes special option with auto number ID generated by database.
      ''' </summary>
      ''' <param name="id">
      ''' Auto number ID generated by database of special option to delete.
      ''' </param>
      Public Shared Sub Delete(ByVal id As Integer)
         Dim connection As IDbConnection
         Dim command As IDbCommand
            Dim sql As String
         Dim numRows As Integer

         connection = Common.CreateConnection(Common.ProjectsDbPath)

            sql = SqlFactory.GetDeleteSql(id)
         command = connection.CreateCommand
         command.CommandText = sql

         Try
            connection.Open()
            numRows = command.ExecuteNonQuery()
         Catch ex As DataException
            Throw ex
         Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try
      End Sub


      ''' <summary>
      ''' Deletes special options with the specified equipment ID; deletes all revisions.
      ''' </summary>
      ''' <param name="equipmentId">
      ''' Equipment ID of special option to delete
      ''' </param>
      ''' <param name="connection">
      ''' Database connection that should be open
      ''' </param>
      ''' <param name="transaction">
      ''' Transaction to run delete command in
      ''' </param>
        Friend Shared Function Delete(ByVal equipmentId As String, ByVal connection As IDbConnection, ByVal transaction As IDbTransaction) As Integer
            Dim sql As String = SqlFactory.GetDeleteSql(equipmentId)
            Dim command As IDbCommand = connection.CreateCommand
            command.CommandText = sql
            command.Transaction = transaction
            Dim numSpecialOptionsDeleted As Integer = command.ExecuteNonQuery()
            Return numSpecialOptionsDeleted
        End Function


        Friend Shared Function Delete(ByVal equipmentId As String, ByVal connection As IDbConnection, ByVal transaction As IDbTransaction, ByVal revision As String) As Integer
            Dim sql As String = SqlFactory.GetDeleteSql(equipmentId, revision)
            Dim command As IDbCommand = connection.CreateCommand
            command.CommandText = sql
            command.Transaction = transaction
            Dim numSpecialOptionsDeleted As Integer = command.ExecuteNonQuery()
            Return numSpecialOptionsDeleted
        End Function



      ''' <summary>
      ''' Generates SQL statements for data access.
      ''' </summary>
      Public Class SqlFactory

         ''' <summary>
         ''' Gets last auto number ID.
         ''' </summary>
         Public Shared Function GetLastId() As String
            Dim sql As New StringBuilder
                sql.AppendFormat("SELECT MAX([{0}]) FROM [{1}]", T1.Id, T1.TableName)
                Return sql.ToString
            End Function


            ''' <summary>
            ''' Retrieves special option based on equipment ID and revision parameters.
            ''' </summary>
            Public Shared Function GetRetrieveByEquipmentIdAndRevisionSql(ByVal equipmentId As String, ByVal revision As Single) As String
                Dim sql As New StringBuilder
                sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}]='{2}' AND [{3}]={4}", T1.TableName, T1.EquipmentId, equipmentId, T1.Revision, revision.ToString)
                '                sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}]='{2}' AND [{3}]={4}", "SpecialOptionsRename", T.EquipmentId, equipmentId, T.Revision, revision.ToString)
                Return sql.ToString
         End Function


         ''' <summary>
         ''' Retrieves special option by auto number ID.
         ''' </summary>
         ''' <param name="id">Unique auto number ID generated by database.</param>
         Public Shared Function GetRetrieveSql(ByVal id As Integer) As String
            Dim sql As New StringBuilder
                sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}]={2}",
               T1.TableName, T1.Id, id.ToString)
                Return sql.ToString
         End Function


         ''' <summary>
         ''' Deletes special option with auto number parameter.
         ''' </summary>
         ''' <param name="id">
         ''' Auto number parameter.
         ''' </param>
         Public Shared Function GetDeleteSql(ByVal id As Integer) As String
            Dim sql As New StringBuilder()
                sql.AppendFormat("DELETE FROM [{0}] WHERE [{1}]={2}",
               T1.TableName, T1.Id, id.ToString)
                Return sql.ToString
         End Function


         ''' <summary>
         ''' Deletes special options with the specified equipment ID
         ''' </summary>
         ''' <param name="equipmentId">
         ''' Equipment ID of special options to delete
         ''' </param>
         Public Shared Function GetDeleteSql(ByVal equipmentId As String) As String
            Dim criteriaColumns As New List(Of SqlColumn)
                criteriaColumns.Add(New SqlColumn(T1.EquipmentId, SqlDataType.String, equipmentId))
                Dim builder As New SqlBuilder(T1.TableName, criteriaColumns)
                Dim sql As String = builder.GenerateDeleteCommand()
                Return sql
            End Function



            Public Shared Function GetDeleteSql(ByVal equipmentId As String, ByVal revision As String) As String
                Dim criteriaColumns As New List(Of SqlColumn)
                criteriaColumns.Add(New SqlColumn(T1.EquipmentId, SqlDataType.String, equipmentId))
                criteriaColumns.Add(New SqlColumn(T1.Revision, SqlDataType.Number, revision))
                Dim builder As New SqlBuilder(T1.TableName, criteriaColumns)
                Dim sql As String = builder.GenerateDeleteCommand()
                Return sql
            End Function

         ''' <summary>
         ''' Updates special option based on auto number ID.
         ''' </summary>
         ''' <param name="op">
         ''' Option to update.
         ''' </param>
         Public Shared Function GetUpdateSql(ByVal op As SpecialOption) As String
            Dim cols As List(Of SqlColumn) = GetColumns(op)
            Dim criteriaCols As New List(Of SqlColumn)
                criteriaCols.Add(New SqlColumn(T1.Id, SqlDataType.Number, op.Id.ToString))
                Dim builder As New SqlBuilder(cols, T1.TableName, criteriaCols)
                Return builder.GenerateUpdateCommand()
            End Function


            Public Shared Function GetCreateSql(ByVal op As SpecialOption) As String
                Dim cols As List(Of SqlColumn) = GetColumns(op)
                Dim builder As New SqlBuilder(cols, T1.TableName)
                Return builder.GenerateInsertCommand()
            End Function


            Private Shared Function GetColumns(ByVal op As SpecialOption) As List(Of SqlColumn)
                Dim cols As New List(Of SqlColumn)

                cols.Add(New SqlColumn(T1.AuthorizedBy, SqlDataType.String, op.AuthorizedBy))
                cols.Add(New SqlColumn(T1.AuthorizedFor, SqlDataType.String, op.AuthorizedFor))
                cols.Add(New SqlColumn(T1.Code, SqlDataType.String, op.Code.ToString))
                cols.Add(New SqlColumn(T1.Description, SqlDataType.String, op.Description))
                cols.Add(New SqlColumn(T1.Price, SqlDataType.Number, op.Price.to_string_or_null))
                cols.Add(New SqlColumn(T1.Quantity, SqlDataType.Number, op.Quantity.to_string_or_null))
                cols.Add(New SqlColumn(T1.EquipmentId, SqlDataType.String, op.EquipmentId.Id))
                cols.Add(New SqlColumn(T1.Revision, SqlDataType.Number, op.Revision.ToString))

                Return cols
         End Function

      End Class

   End Class



End Namespace