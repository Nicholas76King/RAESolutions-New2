Imports System.Collections.Generic
Imports System
Imports System.Text
Imports System.Data
Imports Rae.RaeSolutions.Business.Entities
Imports COT = Rae.RaeSolutions.DataAccess.Projects.Tables.CompaniesTable
Imports Rae.Data.Sql

Namespace Rae.RaeSolutions.DataAccess.Projects


    Public Class CompaniesDa

        ''' <summary>
        ''' Creates a company. Assigns company ID.
        ''' </summary>
        ''' <param name="company">
        ''' Company to create.
        ''' </param>
        Public Shared Sub Create(ByRef company As Company)
            Dim connection As IDbConnection
            Dim command As IDbCommand
            Dim reader As IDataReader
            Dim connectionString, sql As String

            connectionString = Common.GetConnectionString(Common.ProjectsDbPath)
            connection = Common.CreateConnection(Common.ProjectsDbPath)

            Try
                connection.Open()

                ' creates company
                sql = SqlFactory.GetCreateCompanySql(company)
                command = connection.CreateCommand
                command.CommandText = sql
                command.ExecuteNonQuery()

                ' sets company id
                sql = SqlFactory.GetLastCompanySql()
                command = connection.CreateCommand
                command.CommandText = sql
                reader = command.ExecuteReader
                While reader.Read
                    company.Id.value = CInt(reader(0))
                End While

            Catch ex As DataException
                Throw ex
            Finally
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try
        End Sub


        ''' <summary>
        ''' Retrieves company with ID.
        ''' </summary>
        ''' <param name="id">
        ''' Company ID.
        ''' </param>
        ''' <returns>
        ''' Company with ID.
        ''' </returns>
        Public Shared Function Retrieve(ByVal id As Integer) As Company
            Dim connection As IDbConnection
            Dim command As IDbCommand
            Dim reader As IDataReader
            Dim connectionString As String, sql As New StringBuilder
            Dim co As Company

            connectionString = Common.GetConnectionString(Common.ProjectsDbPath)
            connection = Common.CreateConnection(Common.ProjectsDbPath)

            Try
                connection.Open()

                sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}] = {2}", _
                   COT.TableName, COT.Id, id.ToString)
                command = connection.CreateCommand
                command.CommandText = sql.ToString
                reader = command.ExecuteReader()
                While reader.Read
                    co = Read(reader)
                End While

            Catch ex As DataException
                Throw ex
            Finally
                If reader IsNot Nothing Then reader.Close()
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try

            Return co
        End Function


        ''' <summary>
        ''' Updates company.
        ''' </summary>
        ''' <param name="company">
        ''' Company to update.
        ''' </param>
        Public Shared Sub Update(ByVal company As Company)
            Dim connection As IDbConnection
            Dim command As IDbCommand
            Dim connectionString, sql As String

            connectionString = Common.GetConnectionString(Common.ProjectsDbPath)
            connection = Common.CreateConnection(Common.ProjectsDbPath)

            sql = SqlFactory.GetUpdateCompanySql(company)
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
        ''' Determines whether company exists in data source.
        ''' </summary>
        ''' <param name="id">
        ''' Company ID to look for.
        ''' </param>
        ''' <returns>
        ''' True if company exists in data source; else false.
        ''' </returns>
        Public Shared Function Exists(ByVal id As Integer) As Boolean
            Dim connection As IDbConnection
            Dim command As IDbCommand
            Dim reader As IDataReader
            Dim connectionString As String, sql As New StringBuilder
            Dim found As Boolean = False

            connectionString = Common.GetConnectionString(Common.ProjectsDbPath)
            connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)


            sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}] = {2}", _
               COT.TableName, COT.Id, id.ToString)
            command = connection.CreateCommand 'New OleDbCommand(sql, connection)
            command.CommandText = sql.ToString

            Try
                connection.Open()
                reader = command.ExecuteReader()
                ' checks if company exists
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
        ''' Retrieves all companies with the same description (ex. Reps).
        ''' </summary>
        ''' <param name="description">
        ''' Description of company (ex. Rep).</param>
        ''' <returns>
        ''' List of companies with the description.
        ''' </returns>
        Public Shared Function RetrieveByDescription(ByVal description As String) As CompanyList
            If description Is Nothing Then description = "" ' prevents exception
            Dim connectionString As String = Common.GetConnectionString(Common.ProjectsDbPath)
            Dim connection As IDbConnection = Common.CreateConnection(Common.ProjectsDbPath)
            Dim sql As New StringBuilder
            sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}] LIKE '{2}' ORDER BY [{3}] ASC", _
               COT.TableName, COT.Description, description, COT.Name)
            'sql.AppendFormat("SELECT * FROM [{0}] ORDER BY [{1}] ASC", _
            '    COT.TableName, COT.Name)
            Dim command As IDbCommand = connection.CreateCommand
            command.CommandText = sql.ToString
            Dim reader As IDataReader
            Dim co As Company, companies As New CompanyList()

            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read
                    co = Read(reader)
                    companies.Add(co)
                End While
            Catch ex As DataException
                Throw ex
            Finally
                If reader IsNot Nothing Then reader.Close()
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try

            Return companies
        End Function





        ''' <summary>
        ''' Reads company info
        ''' </summary>
        ''' <returns>
        ''' Company
        ''' </returns>
        Private Shared Function Read(ByVal reader As IDataReader) As Company
            Dim co As New Company

            co.Id.value = CInt(reader(COT.Id))
            co.CustomerNum.set_to(reader(COT.CustomerNum))
            co.RepNum.set_to(reader(COT.RepNum))

            co.Address.Line1 = reader(COT.Line1).ToString
            co.Address.Line2 = reader(COT.Line2).ToString
            co.Address.State = reader(COT.State).ToString
            co.Address.City = reader(COT.City).ToString
            co.Address.Zip4.set_to(reader(COT.ZipCode4).ToString)
            co.Address.Zip5.set_to(reader(COT.ZipCode5).ToString)

            co.Role = reader(COT.Description).ToString
            co.Email.Address = reader(COT.Email).ToString
            co.Name = reader(COT.Name).ToString
            co.Website = reader(COT.Website).ToString

            co.PhoneNum.AreaCode.set_to(reader(COT.PhoneNumAreaCode))
            co.PhoneNum.Number.set_to(reader(COT.PhoneNum))
            co.PhoneNum.Extension.set_to(reader(COT.PhoneNumExtension))
            co.FaxNum.AreaCode.set_to(reader(COT.FaxNumAreaCode))
            co.FaxNum.Number.set_to(reader(COT.FaxNum))

            Return co
        End Function



        Private Class SqlFactory

            ''' <summary>
            ''' Gets SQL to create
            ''' </summary>
            ''' <returns>
            ''' SQL string
            ''' </returns>
            Public Shared Function GetCreateCompanySql(ByVal company As Company) As String
                Dim affectedCols As List(Of SqlColumn) = GetCompanyColumns(company)
                Dim builder As New SqlBuilder(affectedCols, COT.TableName)
                Return builder.GenerateInsertCommand()
            End Function


            ''' <summary>
            ''' Builds SQL to update an entity
            ''' </summary>
            ''' <returns>
            ''' SQL insert string
            ''' </returns>
            Public Shared Function GetUpdateCompanySql(ByVal company As Company) As String
                Dim affectedCols As List(Of SqlColumn) = GetCompanyColumns(company)
                Dim criteriaCols As New List(Of SqlColumn)
                criteriaCols.Add(New SqlColumn(COT.Id, SqlDataType.Number, company.Id.ToString))
                Dim builder As New SqlBuilder(affectedCols, COT.TableName, criteriaCols)

                Return builder.GenerateUpdateCommand()
            End Function


            ''' <summary>
            ''' Gets SQL that retrieves last company id inserted.
            ''' </summary>
            Public Shared Function GetLastCompanySql() As String
                Dim sql As New StringBuilder
                sql.AppendFormat("SELECT MAX([{0}]) FROM [{1}]", _
                   COT.Id, COT.TableName)
                Return sql.ToString
            End Function


            ''' <summary>
            ''' Company columns.
            ''' </summary>
            Private Shared Function GetCompanyColumns(ByVal company As Company) As List(Of SqlColumn)
                Dim cols As New List(Of SqlColumn)

                cols.Add(New SqlColumn(COT.RepNum, SqlDataType.Number, company.RepNum.to_string_or_null))
                cols.Add(New SqlColumn(COT.CustomerNum, SqlDataType.Number, company.CustomerNum.to_string_or_null))
                cols.Add(New SqlColumn(COT.Description, SqlDataType.String, company.Role))
                cols.Add(New SqlColumn(COT.Email, SqlDataType.String, company.Email.Address))
                cols.Add(New SqlColumn(COT.Name, SqlDataType.String, company.Name))
                cols.Add(New SqlColumn(COT.Website, SqlDataType.String, company.Website))

                cols.Add(New SqlColumn(COT.Line1, SqlDataType.String, company.Address.Line1))
                cols.Add(New SqlColumn(COT.Line2, SqlDataType.String, company.Address.Line2))
                cols.Add(New SqlColumn(COT.City, SqlDataType.String, company.Address.City))
                cols.Add(New SqlColumn(COT.State, SqlDataType.String, company.Address.State))
                cols.Add(New SqlColumn(COT.ZipCode4, SqlDataType.Number, company.Address.Zip4.to_string_or_null))
                cols.Add(New SqlColumn(COT.ZipCode5, SqlDataType.Number, company.Address.Zip5.to_string_or_null))

                cols.Add(New SqlColumn(COT.PhoneNumAreaCode, SqlDataType.Number, company.PhoneNum.AreaCode.to_string_or_null))
                cols.Add(New SqlColumn(COT.PhoneNum, SqlDataType.Number, company.PhoneNum.Number.to_string_or_null))
                cols.Add(New SqlColumn(COT.PhoneNumExtension, SqlDataType.Number, company.PhoneNum.Extension.to_string_or_null))
                cols.Add(New SqlColumn(COT.FaxNumAreaCode, SqlDataType.Number, company.FaxNum.AreaCode.to_string_or_null))
                cols.Add(New SqlColumn(COT.FaxNum, SqlDataType.Number, company.FaxNum.Number.to_string_or_null))

                Return cols
            End Function

        End Class

    End Class

End Namespace