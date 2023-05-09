Imports System
Imports System.Text
Imports System.Data
Imports System.Collections.Generic
Imports CT1 = RAE.RAESolutions.DataAccess.Projects.Tables.ContactsTable
Imports PCT = Rae.RaeSolutions.DataAccess.Projects.Tables.ProjectContactsTable
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.Data.Sql
Imports Rae.RaeSolutions.DataAccess


Namespace Rae.RaeSolutions.DataAccess.Projects

    ''' <summary>
    ''' Contains data access to contacts info.
    ''' </summary>
    ''' <history by="Casey Joyce">
    ''' Created
    ''' </history>
    Public Class ContactsDataAccess

        ''' <summary>
        ''' Creates/updates contacts.
        ''' </summary>
        ''' <param name="contacts">
        ''' Contacts to save
        ''' </param>
        Public Shared Sub Save(ByRef contacts As ContactList)
            For Each contact As Contact In contacts
                If Not contact.Id.value > 0 Then
                    Create(contact)
                Else
                    Update(contact)
                End If

            Next
        End Sub


        ''' <summary>
        ''' Creates a contact. Doesn't create company, just company ID. Assigns contact ID.
        ''' </summary>
        ''' <param name="contact">
        ''' Contact to create
        ''' </param>
        Public Shared Sub Create(ByRef contact As Contact)
            Dim transaction As IDbTransaction
            Dim connection As IDbConnection
            Dim command As IDbCommand
            Dim sql As String

            connection = Common.CreateConnection(Common.ProjectsDbPath)

            Try
                connection.Open()
                transaction = connection.BeginTransaction

                ' creates contact
                sql = SqlFactory.GetContactInsertSql(contact)
                command = connection.CreateCommand
                command.CommandText = sql
                command.Transaction = transaction
                command.ExecuteNonQuery()

                ' gets assigned ID
                sql = SqlFactory.GetLastContactSql()
                command = connection.CreateCommand
                command.CommandText = sql
                command.Transaction = transaction
                contact.Id.value = CInt(command.ExecuteScalar)

                transaction.Commit()
            Catch ex As Exception
                If transaction IsNot Nothing Then transaction.Rollback()
                Throw ex
            Finally
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try
        End Sub


        ''' <summary>
        ''' Retrieves contact with ID.
        ''' </summary>
        ''' <param name="id">
        ''' Contact ID of contact to retrieve.
        ''' </param>
        ''' <returns>
        ''' Contact with contact ID.
        ''' </returns>
        Public Shared Function Retrieve(ByVal id As Integer) As Contact
            Dim connection As IDbConnection
            Dim command As IDbCommand
            Dim reader As IDataReader
            Dim sql As New StringBuilder
            Dim contact As Contact

            connection = Common.CreateConnection(Common.ProjectsDbPath)

            sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}] = {2}",
               CT1.TableName, CT1.Id, id.ToString)
            command = connection.CreateCommand
            command.CommandText = sql.ToString

            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read
                    contact = read(reader)
                End While
            Catch ex As DataException
                Throw ex
            Finally
                If reader IsNot Nothing Then reader.Close()
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try

            Return contact
        End Function


        ''' <summary>
        ''' Retrieves contacts in company.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function RetrieveByCompanyId(ByVal id As Integer) As ContactList
            Dim connection As IDbConnection
            Dim command As IDbCommand
            Dim reader As IDataReader
            Dim sql As New StringBuilder
            Dim contact As Contact, contacts As New ContactList

            connection = Common.CreateConnection(Common.ProjectsDbPath)

            sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}] = {2}",
               CT1.TableName, CT1.CompanyId, id.ToString)
            command = connection.CreateCommand
            command.CommandText = sql.ToString

            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read
                    contact = read(reader)
                    contacts.Add(contact)
                End While
            Catch ex As DataException
                Throw ex
            Finally
                If reader IsNot Nothing Then reader.Close()
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try

            Return contacts
        End Function


        ''' <summary>
        ''' Retrieves contacts in a project
        ''' </summary>
        ''' <param name="projectId">
        ''' ID of project to get contacts for
        ''' </param>
        Public Shared Function RetrieveByProjectId(ByVal projectId As String) As ContactList
            Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
            Dim sql As New StringBuilder()
            sql.AppendFormat("SELECT {0}.* FROM {0} INNER JOIN {1} ON {0}.{2}={1}.{3} WHERE {1}.{4}='{5}'",
            CT1.TableName, PCT.TableName, CT1.Id, PCT.ContactId, PCT.ProjectId, projectId)
            'sql.AppendFormat("SELECT [{0}].* FROM [{0}] inner join [{3}] on [{3}].[{4}] = [{0}].[{2}] and [{3}].[{5}] = '[{6}]'", _
            '      CT.TableName, CT.Description, CT.Id, PCT.TableName, PCT.ContactId, PCT.ProjectId, projectId)
            Dim command = connection.CreateCommand
            command.CommandText = sql.ToString
            Dim reader As IDataReader
            Dim contact As Contact
            Dim contacts = New ContactList()

            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read
                    contact = read(reader)
                    contact.Company.Load()
                    contacts.Add(contact)
                End While
            Catch ex As DataException
                Throw ex
            Finally
                If reader IsNot Nothing Then reader.Close()
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try

            Return contacts
        End Function


        ''' <summary>
        ''' Retrieves contacts by customer number.
        ''' </summary>
        ''' <param name="customerNum">
        ''' Customer number to search for.
        ''' </param>
        ''' <returns>
        ''' List of contacts with customer number.
        ''' </returns>
        Public Shared Function RetrieveByCustomerNum(ByVal customerNum As Integer) As ContactList
            Dim connection As IDbConnection
            Dim command As IDbCommand
            Dim reader As IDataReader
            Dim sql As New StringBuilder
            Dim contacts As New ContactList
            Dim contact As Contact

            connection = Common.CreateConnection(Common.ProjectsDbPath)

            sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}] = {2}",
               CT1.TableName, CT1.CustomerNum, customerNum)
            command = connection.CreateCommand
            command.CommandText = sql.ToString

            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read
                    contact = read(reader)
                    contacts.Add(contact)
                End While
            Catch ex As DataException
                Throw ex
            Finally
                If reader IsNot Nothing Then reader.Close()
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try

            Return contacts
        End Function


        ''' <summary>
        ''' Updates contact.
        ''' </summary>
        ''' <param name="contact">
        ''' Contact to update.
        ''' </param>
        Public Shared Sub Update(ByVal contact As Contact)
            Dim connection As IDbConnection
            Dim command As IDbCommand
            Dim sql As String

            connection = Common.CreateConnection(Common.ProjectsDbPath)

            sql = SqlFactory.GetContactUpdateSql(contact)
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
        ''' Deletes contact permantly (from contact list and projects)
        ''' </summary>
        ''' <param name="id">
        ''' Contact ID
        ''' </param>
        Public Shared Sub DeleteContact(ByVal id As Integer)
            Dim connection As IDbConnection
            Dim command As IDbCommand
            Dim sql As New StringBuilder

            connection = Common.CreateConnection(Common.ProjectsDbPath)

            Dim sqlPCT As New StringBuilder
            sqlPCT.AppendFormat("delete FROM [{0}] where [{1}] = {2}", _
                           PCT.TableName, PCT.ContactId, id.ToString())

            sql.AppendFormat("delete FROM [{0}] where [{1}] = {2}",
               CT1.TableName, CT1.Id, id.ToString())
            command = connection.CreateCommand
            command.CommandText = sql.ToString

            Try
                connection.Open()
                Dim cmd As IDbCommand = connection.CreateCommand
                cmd.CommandText = sqlPCT.ToString
                cmd.ExecuteNonQuery()

                command.ExecuteNonQuery()

            Catch ex As DataException 'OleDbExceptions
                Throw ex
            Finally
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try

        End Sub


        ''' <summary>
        ''' Determines whether contact exists in data source.
        ''' </summary>
        ''' <param name="id">
        ''' Contact ID to look for.
        ''' </param>
        ''' <returns>True if contact exists in data source; else false.
        ''' </returns>
        Public Shared Function Exists(ByVal id As Integer) As Boolean
            Dim connection As IDbConnection
            Dim command As IDbCommand
            Dim reader As IDataReader
            Dim sql As New StringBuilder
            Dim found As Boolean = False

            connection = Common.CreateConnection(Common.ProjectsDbPath)

            sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}] = {2}",
               CT1.TableName, CT1.Id, id.ToString)
            command = connection.CreateCommand
            command.CommandText = sql.ToString

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


        Private Shared Function read(ByVal reader As IDataReader) As Contact
            Dim contact As New Contact
            contact.Address.City = reader(CT1.City).ToString
            contact.Address.Line1 = reader(CT1.Line1).ToString
            contact.Address.Line2 = reader(CT1.Line2).ToString
            contact.Address.State = reader(CT1.State).ToString
            contact.Address.Zip4.set_to(reader(CT1.ZipCode4))
            contact.Address.Zip5.set_to(reader(CT1.ZipCode5))

            contact.Id.value = CInt(reader(CT1.Id))
            contact.RepNum.set_to(reader(CT1.RepNum))
            contact.CustomerNum.set_to(reader(CT1.CustomerNum))
            contact.Company.Id.set_to(reader(CT1.CompanyId))

            contact.Role = reader(CT1.Description).ToString
            contact.Email.Address = reader(CT1.Email).ToString

            contact.FaxNum.AreaCode.set_to(reader(CT1.FaxNumAreaCode))
            contact.FaxNum.Number.set_to(reader(CT1.FaxNum))

            contact.Name.FirstName = reader(CT1.FirstName).ToString
            contact.Name.LastName = reader(CT1.LastName).ToString

            contact.PhoneNum.AreaCode.set_to(reader(CT1.PhoneNumAreaCode))
            contact.PhoneNum.Number.set_to(reader(CT1.PhoneNum))
            contact.PhoneNum.Extension.set_to(reader(CT1.PhoneNumExtension))
            Return contact
        End Function


        Private Class SqlFactory

            ''' <summary>
            ''' Gets SQL to insert conact.
            ''' </summary>
            Public Shared Function GetContactInsertSql(ByVal contact As Contact) As String
                Dim affectedCols As List(Of SqlColumn) = GetContactColumns(contact)
                Dim builder As New SqlBuilder(affectedCols, CT1.TableName)
                Return builder.GenerateInsertCommand()
            End Function


            ''' <summary>
            ''' Builds SQL to update a contact
            ''' </summary>
            ''' <returns>
            ''' SQL update string
            ''' </returns>
            Public Shared Function GetContactUpdateSql(ByVal contact As Contact) As String
                Dim affectedCols As List(Of SqlColumn) = GetContactColumns(contact)
                Dim criteriaCols As New List(Of SqlColumn)
                criteriaCols.Add(New SqlColumn(CT1.Id, SqlDataType.Number, contact.Id.ToString))
                Dim builder As New SqlBuilder(affectedCols, CT1.TableName, criteriaCols)

                Return builder.GenerateUpdateCommand()
            End Function


            Public Shared Function GetLastContactSql() As String
                Return "SELECT MAX([" & CT1.Id & "]) FROM " & CT1.TableName
            End Function


            Private Shared Function GetContactColumns(ByVal contact As Contact) As List(Of SqlColumn)
                Dim cols As New List(Of SqlColumn)

                cols.Add(New SqlColumn(CT1.CompanyId, SqlDataType.Number, contact.Company.Id.value_or_default(-1).ToString()))
                cols.Add(New SqlColumn(CT1.CustomerNum, SqlDataType.Number, contact.CustomerNum.to_string_or_null))
                cols.Add(New SqlColumn(CT1.RepNum, SqlDataType.Number, contact.RepNum.to_string_or_null))
                cols.Add(New SqlColumn(CT1.Description, SqlDataType.String, contact.Role))
                cols.Add(New SqlColumn(CT1.Email, SqlDataType.String, contact.Email.Address))
                cols.Add(New SqlColumn(CT1.FirstName, SqlDataType.String, contact.Name.FirstName))
                cols.Add(New SqlColumn(CT1.LastName, SqlDataType.String, contact.Name.LastName))

                cols.Add(New SqlColumn(CT1.Line1, SqlDataType.String, contact.Address.Line1))
                cols.Add(New SqlColumn(CT1.Line2, SqlDataType.String, contact.Address.Line2))
                cols.Add(New SqlColumn(CT1.City, SqlDataType.String, contact.Address.City))
                cols.Add(New SqlColumn(CT1.State, SqlDataType.String, contact.Address.State))
                cols.Add(New SqlColumn(CT1.ZipCode4, SqlDataType.Number, contact.Address.Zip4.to_string_or_null))
                cols.Add(New SqlColumn(CT1.ZipCode5, SqlDataType.Number, contact.Address.Zip5.to_string_or_null))

                cols.Add(New SqlColumn(CT1.PhoneNum, SqlDataType.Number, contact.PhoneNum.Number.to_string_or_null))
                cols.Add(New SqlColumn(CT1.PhoneNumAreaCode, SqlDataType.Number, contact.PhoneNum.AreaCode.to_string_or_null))
                cols.Add(New SqlColumn(CT1.PhoneNumExtension, SqlDataType.Number, contact.PhoneNum.Extension.to_string_or_null))

                cols.Add(New SqlColumn(CT1.FaxNum, SqlDataType.Number, contact.FaxNum.Number.to_string_or_null))
                cols.Add(New SqlColumn(CT1.FaxNumAreaCode, SqlDataType.Number, contact.FaxNum.AreaCode.to_string_or_null))

                Return cols
            End Function

        End Class


    End Class

End Namespace
