Option Strict On
Option Explicit On

Imports Common = Rae.RaeSolutions.DataAccess.Common
Imports B11 = RAE.RAESolutions.Business
Imports Rae.RaeSolutions.Business.Entities
Imports PT = Rae.RaeSolutions.DataAccess.Projects.Tables.ProjectsTable
Imports PCT = Rae.RaeSolutions.DataAccess.Projects.Tables.ProjectContactsTable
Imports CNull = Rae.ConvertNull
Imports System.Data
Imports System.Data.OleDb
Imports Rae.Io.Text
Imports System.Text
Imports Rae.Data.Sql
Imports System.Collections.Generic
Imports Rae.Data.Sql.SqlParameterComplianceEnforcer
Imports System.Data.SqlClient


Namespace Rae.RaeSolutions.DataAccess.Projects

   ''' <summary>
   ''' Provides data access for projects database table
   ''' </summary>
   Public Class ProjectsDataAccess

      ''' <summary>
      ''' Creates a new project
      ''' </summary>
      Public Shared Sub Create(ByVal project As ProjectItem)
         Dim connectionString As String = Common.GetConnectionString(Common.ProjectsDbPath)
         Dim connection As IDbConnection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)
         Dim sqlCommand As String = SqlFactory.GetInsertProjectSqlCommand(project)
         Dim command As IDbCommand = connection.CreateCommand() 'New OleDbCommand(sqlCommand, connection)
         command.CommandText = sqlCommand

         Try
            connection.Open()

            ContactsDataAccess.Save(project.Contacts) 'creates contact if necesary


            command.ExecuteNonQuery()

            For Each contact As Contact In project.Contacts
               'create project contact
               If Not ProjectContactsDataAccess.Exists(project.id.Id, contact.Id.value) Then
                  ProjectContactsDataAccess.Create(project.id.Id, contact.Id.value)
               End If
            Next

         Catch dbEx As DataException
            Throw
         Finally
            If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try
      End Sub


      ''' <summary>
      ''' Deletes Project with the specified ID; deletes all associated
      ''' equipment, processes, relationships and revisions.
      ''' </summary>
      ''' <param name="projectId">
      ''' ID of the equipment to delete.
      ''' </param>
      Public Shared Sub Delete(ByVal projectId As String, Optional ByVal DeleteCheckOut As Boolean = False)
         Dim command As IDbCommand
         Dim transaction As IDbTransaction

         Dim connectionString As String
         If DeleteCheckOut Then
            connectionString = Common.GetConnectionString(Common.ProjectsCheckedOutDbPath)
         Else
            connectionString = Common.GetConnectionString(Common.ProjectsDbPath)
         End If

         Dim sqlPCT As New StringBuilder
         sqlPCT.AppendFormat("DELETE FROM [{0}] WHERE [{1}] = '{2}'", _
         PCT.TableName, PCT.ProjectId, projectId)

         Dim sql As New StringBuilder()
         sql.AppendFormat("DELETE FROM [{0}] WHERE [{1}] = '{2}'", _
         PT.TableName, PT.ProjectId, projectId)

         Dim connection As IDbConnection
         If DeleteCheckOut Then
            connection = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
         Else
            connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)
         End If

         Try
            connection.Open()
            transaction = connection.BeginTransaction

            'delete all project contacts from projectcontacts table first
            Dim cmd As IDbCommand = connection.CreateCommand 'New OleDbCommand(sqlPCT.ToString(), connection)
            cmd.CommandText = sqlPCT.ToString
            cmd.Transaction = transaction
            cmd.ExecuteNonQuery()

            command = connection.CreateCommand 'New OleDbCommand(sql.ToString, connection)
            command.CommandText = sql.ToString
            command.Transaction = transaction
            command.ExecuteNonQuery()

            'delete the CoolStuff product selections
            Dim CSsql1 As String = "delete  FROM coolstuffproductselections where coolstuffproductselections.projectid in  (select coolstuffprojects.id from coolstuffprojects,processes where Processes.ID = CoolStuffProjects.PROJECTID and Processes.ProjectID='" & projectId & "')"
            Dim cs1 As IDbCommand = connection.CreateCommand 'New OleDbCommand(CSsql1, connection)
            cs1.CommandText = CSsql1
            cs1.Transaction = transaction
            cs1.ExecuteNonQuery()

            'delete the coolstuff project
            Dim CSsql2 As String = "delete FROM coolstuffprojects where projectid in (select Processes.ID from processes where Processes.ProjectID='" & projectId & "')"
            Dim cs2 As IDbCommand = connection.CreateCommand 'New OleDbCommand(CSsql2, connection)
            cs2.CommandText = CSsql2
            cs2.Transaction = transaction
            cs2.ExecuteNonQuery()



            ' delete all processes
            ProcessItemDA.DeleteALLProcesses(projectId, connection, transaction)

            ' delete all equipment
            EquipmentDa.DeleteAllEquipment(projectId, connection, transaction)

            transaction.Commit()

         Catch ex As OleDbException
            If transaction IsNot Nothing Then transaction.Rollback()
            Throw ex
         Finally
            If Not (connection.State.Equals(ConnectionState.Closed)) Then connection.Close()
         End Try
      End Sub

      Public Shared Function GetProjectOwner(ByVal projectid As Rae.RaeSolutions.Business.Entities.item_id) As String

         Dim sql As String
         Dim connection As IDbConnection
         Dim da As IDbDataAdapter
         Dim ds As New DataSet
         Dim projowner As String = ""
         Try
            sql = "SELECT TOP 1 * " & _
                  "FROM [Projects] " & _
                  "WHERE [ProjectID] = '" & projectid.Id & "' " & _
                  "ORDER BY [ProjectRevision] DESC"
            connection = Common.CreateConnection(Common.ProjectsDbPath)
            Dim cmd As IDbCommand = connection.CreateCommand
            cmd.CommandText = sql
            da = Common.CreateAdapter(cmd)
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
               If ds.Tables(0).Rows(0)("ProjectOwner") Is Nothing Or ds.Tables(0).Rows(0)("ProjectOwner").ToString.Trim = "" Then
                  projowner = projectid.Username
               Else
                  projowner = CStr(ds.Tables(0).Rows(0)("ProjectOwner"))
               End If
            End If
         Catch ex As Exception
            Throw ex
         End Try
         Return projowner

      End Function


      ''' <summary>
      ''' Updates project.
      ''' </summary>
      Public Shared Sub Update(ByVal project As ProjectItem)
         Dim connectionString As String = Common.GetConnectionString(Common.ProjectsDbPath)
         Dim connection As IDbConnection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)
         Dim sqlCommand As String = SqlFactory.GetUpdateProjectSqlCommand(project)
         Dim command As IDbCommand = connection.CreateCommand 'New OleDbCommand(sqlCommand, connection)
         command.CommandText = sqlCommand

         Dim numRowsAffected As Integer
         Try
            connection.Open()
            ContactsDataAccess.Save(project.Contacts)
            numRowsAffected = command.ExecuteNonQuery()

            ProjectContactsDataAccess.Delete(project.id.Id)
            For Each contact As Contact In project.Contacts
               ProjectContactsDataAccess.Create(project.id.Id, contact.Id.value)
            Next
         Catch ex As OleDbException
            Throw
         Finally
            If Not connection.State.Equals(System.Data.ConnectionState.Closed) Then connection.Close()
         End Try

      End Sub


      ''' <summary>
      ''' Retrieves project with the project ID.
      ''' </summary>
      Public Shared Function Retrieve(ByVal projectId As String, Optional ByVal revision As Single = 0) As ProjectItem
         Dim sql As New StringBuilder
         Dim connection As IDbConnection
         Dim command As IDbCommand
         Dim reader As IDataReader
         Dim project As ProjectItem

         If Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
            If Common.isCheckedOut Then
               sql.AppendFormat("SELECT TOP 1 * FROM [{0}] WHERE [{1}] = '{2}'", _
                  PT.TableName, PT.ProjectId, projectId)
            Else
               sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}] = '{2}' AND [{3}] = {4}", _
                  PT.TableName, PT.ProjectId, projectId, PT.ProjectRevision, revision)
            End If
         Else
            sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}] = '{2}' AND [{3}] = {4}", _
               PT.TableName, PT.ProjectId, projectId, PT.ProjectRevision, revision)
         End If

         connection = Common.CreateConnection(Common.ProjectsDbPath)
         command = connection.CreateCommand
         command.CommandText = sql.ToString

         project = New ProjectItem(New item_id(projectId))

         Try
            connection.Open()
            reader = command.ExecuteReader()
            While reader.Read()
               With project
                  .Revision = CInt(reader(PT.ProjectRevision))
                  .name = reader(PT.Name).ToString
                  .Notes = reader(PT.Notes).ToString
                        GetEnumValue(Of B11.ReleaseStatus)(reader(PT.ReleaseStatus).ToString, .ReleaseStatus)
                        .ReleaseNum.set_to(reader(PT.ReleaseNum))
                  .HoursBeforeDeliveryToCall.set_to(reader(PT.HoursBeforeDeliveryToCall))
                  .PurchaseOrderNum.set_to(reader(PT.PoNum))
                  .PurchaseOrderDate.set_to(reader(PT.PoDate))
                  .RequestedShipDate.set_to(reader(PT.RequestedShipDate))
                  .SalesClass = reader(PT.SalesClass).ToString
                  .Tag = reader(PT.Tag).ToString

                  ' TODO: Contact Retrieve
                  '.Architect.ContactName = reader(PT.ArchitectName).ToString
                  '.Architect.CompanyName = reader(PT.ArchitectCompanyName).ToString
                  '.Contractor.ContactName = reader(PT.ContractorName).ToString
                  '.Contractor.CompanyName = reader(PT.ContractorCompanyName).ToString
                  '.Engineer.ContactName = reader(PT.EngineerName).ToString
                  '.Engineer.CompanyName = reader(PT.EngineerCompanyName).ToString

                  '.Rep.Id.SetValue(reader(PT.RepId))
                  '.Rep.Company.Id.SetValue(reader(PT.RepCompanyId))

                  .ProjectOwner = reader(PT.ProjectOwner).ToString
                  .OpenedBy = reader(PT.OpenedBy).ToString
                  .CheckedOutBy = reader(PT.CheckedOutBy).ToString
                  .RevisionDate.set_to(reader(PT.RevisionDate))

               End With
            End While
         Catch ex As DataException
            Throw ex
         Finally
            If reader IsNot Nothing Then reader.Close()
            If Not (connection.State.Equals(ConnectionState.Closed)) Then connection.Close()
         End Try

         project.Contacts = ContactsDataAccess.RetrieveByProjectId(projectId)

         Return project
      End Function


      ''' <summary>
      ''' Retrieves latest project revision with the project ID.
      ''' </summary>
      Public Shared Function RetrieveLatestRevision(ByVal projectId As String) As Integer
         Dim connectionstring As String
         Dim connection As IDbConnection
         If Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
            If Common.IsConnected Then
               connectionstring = Common.ConnectionString(True, False)
            Else
               connectionstring = Common.ConnectionString(True, True)
            End If
            connection = Rae.Data.DataObjects.CreateConnection(Data.DataObjects.DataAccessTypes.SQL, connectionstring)
         Else
            connectionstring = Common.GetConnectionString(Common.ProjectsDbPath)
            connection = Common.CreateConnection(Common.ProjectsDbPath)
         End If
            Dim sql As New StringBuilder()
            sql.AppendFormat("SELECT [{3}] FROM [{0}] WHERE [{1}]='{2}' ORDER BY [{3}] DESC", _
               PT.TableName, PT.ProjectId, projectId, PT.ProjectRevision)
            Dim command As IDbCommand = connection.CreateCommand
            command.CommandText = sql.ToString
            Dim lastProjRev As Integer = 0
            Try
               connection.Open()
               lastProjRev = CInt(command.ExecuteScalar())
            Finally
               If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try
            Return lastProjRev
      End Function

      Public Shared Function RetrieveContactDataStructure(ByVal projectId As String) As String
         Dim connectionString As String = DataAccess.Common.GetConnectionString(Common.ProjectsDbPath)
         Dim connection As IDbConnection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)
         Dim sql As New StringBuilder()
         sql.AppendFormat("SELECT [{0}] FROM {1} WHERE [{2}]='{3}'", _
            "ContactDataStructure", PT.TableName, PT.ProjectId, projectId)
         Dim command As IDbCommand = connection.CreateCommand 'New OleDbCommand(sql.ToString(), connection)
         command.CommandText = sql.ToString

         Dim contactStructure As String
         Try
            connection.Open()
            ' TODO: Test null return
            contactStructure = command.ExecuteScalar().ToString()
         Finally
            If connection.State = ConnectionState.Closed Then connection.Close()
         End Try

         Return contactStructure
      End Function


      ''' <summary>
      ''' Determines whether project with ID exists in data source.
      ''' </summary>
      ''' <param name="id">
      ''' Project ID to find.
      ''' </param>
      ''' <returns>
      ''' True if project exists in data source; else false.
      ''' </returns>
      Public Shared Function Exists(ByVal id As String, ByVal revision As Single) As Boolean
         Dim connection As IDbConnection
         Dim command As IDbCommand
         Dim reader As IDataReader
         Dim connectionString As String, sql As New StringBuilder
         Dim found As Boolean = False

         connectionString = Common.GetConnectionString(Common.ProjectsDbPath)
         connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)

         sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}] = '{2}' AND [{3}]={4}", _
            PT.TableName, PT.ProjectId, id.ToString, PT.ProjectRevision, revision)
         command = connection.CreateCommand 'New OleDbCommand(sql.ToString, connection)
         command.CommandText = sql.ToString

         Try
            connection.Open()
            reader = command.ExecuteReader()
            ' checks if project exists
            Dim i As Integer = 0
            While reader.Read
               i += 1
            End While
            If i > 0 Then
               found = True
            End If
            'found = reader.HasRows
         Catch ex As DataException
            Throw ex
         Finally
            If reader IsNot Nothing Then reader.Close()
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try

         Return found
      End Function


      ''' <summary>Retrieves a list of submittals
      ''' </summary>
      ''' <exception cref="System.Data.OleDb.OleDbException">Thrown when data exception occurs
      ''' </exception>
      Public Shared Function RetrieveAll(Optional ByVal isCheckOut As Boolean = False, Optional ByVal userName As String = "") As DataTable
         Dim connectionString As String
         Dim sql As New StringBuilder
         Dim connection As IDbConnection
         Dim command As IDbCommand
         Dim reader As IDataReader
         Dim projectsTable As DataTable
         Dim row As DataRow

         If Not isCheckOut Then
            Dim tmpdt As DataTable = GetCheckedOutProjects()
            If tmpdt IsNot Nothing Then
               If tmpdt.Rows.Count > 0 Then
                  Return tmpdt
                  Exit Function
               End If
            End If
         End If

         Dim tmpsql As String = "SELECT t.ProjectID, t.Name, t.ProjectRevision " & _
                                 "FROM Projects as t " & _
                                 "INNER JOIN(" & _
                                 "Select ProjectID, max(ProjectRevision) as maxRev " & _
                                 "FROM Projects " & _
                                 "GROUP BY ProjectID" & _
                                 ") as m " & _
                                 "ON m.ProjectID = t.ProjectID " & _
                                 "AND m.maxRev = t.ProjectRevision"

         If userName.Trim > " " Then
            If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
               tmpsql += " WHERE t.ProjectOwner = '" & userName & "' OR t.ProjectOwner IS NULL AND t.ProjectID Like '" & userName & "+*' OR t.ProjectOwner = '' AND t.ProjectID Like '" & userName & "+*'"
            ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
               tmpsql += " WHERE t.ProjectOwner = '" & userName & "' OR (t.ProjectOwner IS NULL AND t.ProjectID Like '" & userName & "+%')  OR (t.ProjectOwner = '' AND t.ProjectID Like '" & userName & "+%')"
            End If
         End If

         If Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL And Not isCheckOut Then
            connection = Rae.Data.DataObjects.CreateConnection(Data.DataObjects.DataAccessTypes.SQL, Common.ConnectionString(True, False))
         Else
            connection = Common.CreateConnection(Common.ProjectsDbPath)
         End If
         command = connection.CreateCommand 'New OleDbCommand(sql.ToString, connection)
         command.CommandText = tmpsql 'distinctIdsQuery.ToString

         projectsTable = New DataTable("Projects")
         With projectsTable.Columns

            ' if this is checkout then add checkout column
            If isCheckOut Then .Add("Checkout", GetType(System.Boolean))

            .Add(PT.ProjectId, GetType(String))
            .Add(PT.Name, GetType(String))
            .Add("CreatedBy", GetType(String))
            .Add("DateCreated", GetType(System.DateTime))

         End With

         Try
            connection.Open()
            reader = command.ExecuteReader
            While reader.Read
               row = projectsTable.NewRow

               ' if this is checkout then set checkout column to false
               If isCheckOut Then row("Checkout") = False

               Dim id As New item_id(reader(PT.ProjectId).ToString)
               row(PT.ProjectId) = id.ToString
               row(PT.Name) = reader("Name")
               row("CreatedBy") = id.Username
               row("DateCreated") = id.DateGenerated
               projectsTable.Rows.Add(row)
            End While
         Catch dbEx As DataException
            Throw
         Finally
            If Not (reader Is Nothing) Then reader.Close()
            If Not (connection.State.Equals(ConnectionState.Closed)) Then _
               connection.Close()
         End Try

         Return projectsTable

      End Function

      Private Shared Function GetCheckedOutProjects() As DataTable

         Dim connectionString As String
         Dim sql As New StringBuilder
         Dim connection As IDbConnection
         Dim command As IDbCommand
         Dim reader As IDataReader
         Dim projectsTable As DataTable
         Dim row As DataRow

         Dim tmpsql As String = "SELECT t.ProjectID, t.Name, t.ProjectRevision " & _
                                 "FROM Projects as t " & _
                                 "INNER JOIN(" & _
                                 "Select ProjectID, max(ProjectRevision) as maxRev " & _
                                 "FROM Projects " & _
                                 "GROUP BY ProjectID" & _
                                 ") as m " & _
                                 "ON m.ProjectID = t.ProjectID " & _
                                 "AND m.maxRev = t.ProjectRevision"

         connection = Common.CreateConnection(Common.ProjectsCheckedOutDbPath) 'New OleDbConnection(connectionString)
         Command = connection.CreateCommand 'New OleDbCommand(sql.ToString, connection)
         Command.CommandText = tmpsql 'distinctIdsQuery.ToString

         projectsTable = New DataTable("Projects")
         With projectsTable.Columns

            .Add(PT.ProjectId, GetType(String))
            .Add(PT.Name, GetType(String))
            .Add("CreatedBy", GetType(String))
            .Add("DateCreated", GetType(System.DateTime))

         End With

         Try
            connection.Open()
            reader = Command.ExecuteReader
            While reader.Read
               row = projectsTable.NewRow

               Dim id As New item_id(reader(PT.ProjectId).ToString)
               row(PT.ProjectId) = id.ToString
               row(PT.Name) = reader("Name")
               row("CreatedBy") = id.Username
               row("DateCreated") = id.DateGenerated
               projectsTable.Rows.Add(row)
            End While
         Catch dbEx As DataException
            Throw
         Finally
            If Not (reader Is Nothing) Then reader.Close()
            If Not (connection.State.Equals(ConnectionState.Closed)) Then _
               connection.Close()
         End Try

         Return projectsTable

      End Function


      Shared Function RetrieveNumCheckedOutProjects() As Integer
         Dim connectionString As String = Common.GetLocalSqlConnectionString("RAEProjects")
         Dim connection As IDbConnection = New SqlConnection(connectionString)

         Dim sql As String = "SELECT COUNT(*) FROM CheckOutRevisionLevels"
         Dim command As IDbCommand = connection.CreateCommand()
         command.CommandText = sql

         Dim numCheckedOutProjects As Integer

         Try
            connection.Open()
            numCheckedOutProjects = CInt(command.ExecuteScalar())
         Catch ex As Exception
            numCheckedOutProjects = 0
         Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try

         Return numCheckedOutProjects
      End Function


      ''' <summary>Retrieves list of checked out submittals
      ''' </summary>
      ''' <exception cref="System.Data.OleDb.OleDbException">Thrown when data exception occurs
      ''' </exception>
      Public Shared Function RetrieveAllCheckin() As DataTable
         Dim connectionString As String
         Dim sql As New StringBuilder
         Dim connection As IDbConnection
         Dim command As IDbCommand
         Dim reader As IDataReader
         Dim projectsTable As DataTable
         Dim row As DataRow

         Dim tmpsql As String = "SELECT t.ProjectID, t.Name, t.ProjectRevision " & _
                                 "FROM Projects as t " & _
                                 "INNER JOIN(" & _
                                 "Select ProjectID, max(ProjectRevision) as maxRev " & _
                                 "FROM Projects " & _
                                 "GROUP BY ProjectID" & _
                                 ") as m " & _
                                 "ON m.ProjectID = t.ProjectID " & _
                                 "AND m.maxRev = t.ProjectRevision"

         connection = Common.CreateConnection(Common.ProjectsCheckedOutDbPath) 'New OleDbConnection(connectionString)
         command = connection.CreateCommand 'New OleDbCommand(sql.ToString, connection)
         command.CommandText = tmpsql 'distinctIdsQuery.ToString

         projectsTable = New DataTable("Projects")
         With projectsTable.Columns
            .Add("CheckIn", GetType(System.Boolean))
            .Add(PT.ProjectId, GetType(String))
            .Add(PT.Name, GetType(String))
            .Add("CreatedBy", GetType(String))
            .Add("DateCreated", GetType(System.DateTime))
         End With

         Try
            connection.Open()
            reader = command.ExecuteReader
            While reader.Read
               row = projectsTable.NewRow
               row("CheckIn") = False
               Dim id As New item_id(reader(PT.ProjectId).ToString)
               row(PT.ProjectId) = id.ToString
               row(PT.Name) = reader("Name")
               row("CreatedBy") = id.Username
               row("DateCreated") = id.DateGenerated
               projectsTable.Rows.Add(row)
            End While
         Catch dbEx As DataException
            Throw
         Finally
            If Not (reader Is Nothing) Then reader.Close()
            If Not (connection.State.Equals(ConnectionState.Closed)) Then _
               connection.Close()
         End Try

         Return projectsTable

      End Function

      ''' <summary>Retrieves a list of checked out submittals based on name pattern
      ''' </summary>
      ''' <exception cref="System.Data.OleDb.OleDbException">Thrown when data exception occurs
      ''' </exception>
      Public Shared Function RetrieveCheckInQry(ByVal qryString As String) As DataTable
         Dim connectionString As String
         Dim sql As New StringBuilder
         Dim connection As IDbConnection
         Dim command As IDbCommand
         Dim reader As IDataReader
         Dim projectsTable As DataTable
         Dim row As DataRow

         Dim tmpsql As String = "SELECT t.ProjectID, t.Name, t.ProjectRevision " & _
                                 "FROM Projects as t " & _
                                 "INNER JOIN(" & _
                                 "Select ProjectID, max(ProjectRevision) as maxRev " & _
                                 "FROM Projects " & _
                                 "GROUP BY ProjectID" & _
                                 ") as m " & _
                                 "ON m.ProjectID = t.ProjectID " & _
                                 "AND m.maxRev = t.ProjectRevision " & _
                                 "WHERE t.Name like '" & qryString & "%'"

         connection = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
         command = connection.CreateCommand
         command.CommandText = tmpsql

         projectsTable = New DataTable("Projects")
         With projectsTable.Columns
            .Add("CheckIn", GetType(System.Boolean))
            .Add(PT.ProjectId, GetType(String))
            .Add(PT.Name, GetType(String))
            .Add("CreatedBy", GetType(String))
            .Add("DateCreated", GetType(System.DateTime))
         End With

         Try
            connection.Open()
            reader = command.ExecuteReader
            While reader.Read
               row = projectsTable.NewRow
               Dim id As New item_id(reader(PT.ProjectId).ToString)
               row("CheckIn") = False
               row(PT.ProjectId) = id.ToString
               row(PT.Name) = reader(PT.Name)
               row("CreatedBy") = id.Username
               row("DateCreated") = id.DateGenerated
               projectsTable.Rows.Add(row)
            End While
         Catch dbEx As DataException
            Throw
         Finally
            If Not (reader Is Nothing) Then reader.Close()
            If Not (connection.State.Equals(ConnectionState.Closed)) Then _
               connection.Close()
         End Try

         Return projectsTable

      End Function

      ''' <summary>Retrieves a list of submittals based on name pattern
      ''' </summary>
      ''' <exception cref="System.Data.OleDb.OleDbException">Thrown when data exception occurs
      ''' </exception>
      Public Shared Function RetrieveQry(ByVal qryString As String, Optional ByVal isCheckout As Boolean = False) As DataTable
         Dim connectionString As String
         Dim sql As New StringBuilder
         Dim connection As IDbConnection
         Dim command As IDbCommand
         Dim reader As IDataReader
         Dim projectsTable As DataTable
         Dim row As DataRow

         Dim tmpsql As String = "SELECT t.ProjectID, t.Name, t.ProjectRevision " & _
                                 "FROM Projects as t " & _
                                 "INNER JOIN(" & _
                                 "Select ProjectID, max(ProjectRevision) as maxRev " & _
                                 "FROM Projects " & _
                                 "GROUP BY ProjectID" & _
                                 ") as m " & _
                                 "ON m.ProjectID = t.ProjectID " & _
                                 "AND m.maxRev = t.ProjectRevision " & _
                                 "WHERE t.Name like '" & qryString & "%'"

         connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)
         command = connection.CreateCommand 'New OleDbCommand(sql.ToString, connection)
         command.CommandText = tmpsql 'distinctIdsQuery.ToString

         projectsTable = New DataTable("Projects")
         With projectsTable.Columns

            ' if this is checkout then add checkout column
            If isCheckout Then .Add("Checkout", GetType(System.Boolean))

            .Add(PT.ProjectId, GetType(String))
            .Add(PT.Name, GetType(String))
            .Add("CreatedBy", GetType(String))
            .Add("DateCreated", GetType(System.DateTime))
         End With

         'connectionString = Common.GetConnectionString(Common.ProjectsDbPath)
         'sql.AppendFormat("SELECT {0}, {1} FROM [{2}]", _
         '   PT.ProjectId, PT.Name, PT.TableName)

         'sql.AppendFormat(" WHERE [{0}] like {1}", _
         '   PT.Name, "'" & qryString & "%'")
         'connection = Common.CreateConnection(Common.ProjectsDbPath) ' New OleDbConnection(connectionString)
         'command = connection.CreateCommand 'New OleDbCommand(sql.ToString, connection)
         'command.CommandText = sql.ToString

         Try
            connection.Open()
            reader = command.ExecuteReader
            While reader.Read
               row = projectsTable.NewRow
               Dim id As New item_id(reader(PT.ProjectId).ToString)

               ' if this is checkout then set checkout column to false
               If isCheckout Then row("Checkout") = False

               row(PT.ProjectId) = id.ToString
               row(PT.Name) = reader(PT.Name)
               row("CreatedBy") = id.Username
               row("DateCreated") = id.DateGenerated
               projectsTable.Rows.Add(row)
            End While
         Catch dbEx As DataException
            Throw
         Finally
            If Not (reader Is Nothing) Then reader.Close()
            If Not (connection.State.Equals(ConnectionState.Closed)) Then _
               connection.Close()
         End Try

         Return projectsTable

      End Function


      ''' <summary>
      ''' Renames project.
      ''' </summary>
      ''' <param name="id">
      ''' ID of project to rename.
      ''' </param>
      ''' <param name="name">
      ''' New project name.
      ''' </param>
      Public Shared Sub Rename(ByVal id As String, ByVal name As String)
         Dim connection As IDbConnection
         Dim command As IDbCommand
         Dim connectionString As String
         Dim sql As New StringBuilder

         connectionString = Common.GetConnectionString(Common.ProjectsDbPath)
         connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)

         sql.AppendFormat("UPDATE [{0}] SET [{1}]='{2}' WHERE [{3}]='{4}'", _
            PT.TableName, PT.Name, EnforceCompliance(name), PT.ProjectId, id)
         command = connection.CreateCommand 'New OleDbCommand(sql.ToString, connection)
         command.CommandText = sql.ToString

         Try
            connection.Open()
            command.ExecuteNonQuery()
         Catch ex As DataException
            Throw ex
         Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try
      End Sub

      Public Shared Sub UpdateContactDataStructure(ByVal contactStructure As String, ByVal projectId As String)
         Dim connectionString As String = Common.GetConnectionString(Common.ProjectsDbPath)
         Dim connection As IDbConnection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)
         Dim sql As New StringBuilder()
         sql.AppendFormat("UPDATE {0} SET {1}='{2}' WHERE {3}='{4}'", _
            PT.TableName, PT.ContactDataStructure, contactStructure, PT.ProjectId, projectId)
         Dim command As IDbCommand = connection.CreateCommand ' OleDbCommand(sql.ToString(), connection)
         command.CommandText = sql.ToString

         Try
            connection.Open()
            Dim numRowsAffected As Integer = command.ExecuteNonQuery()
         Finally
            If Not connection.State = ConnectionState.Closed Then connection.Close()
         End Try
      End Sub

      Public Shared Function RetrieveDeficientContacts(ByVal projectId As String) As ContactList
         Dim connectionString As String = Common.GetConnectionString(Common.ProjectsDbPath)
         Dim connection As IDbConnection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)
         Dim sql As New StringBuilder()
         sql.AppendFormat("SELECT {0}, {1}, {2}, {3}, {4}, {5} FROM {6} WHERE {7}='{8}'", _
            PT.ArchitectCompanyName, PT.ArchitectName, PT.ContractorCompanyName, PT.ContractorName, _
            PT.EngineerCompanyName, PT.EngineerName, PT.TableName, PT.ProjectId, projectId)
         Dim command As IDbCommand = connection.CreateCommand 'New OleDbCommand(sql.ToString(), connection)
         command.CommandText = sql.ToString
         Dim reader As IDataReader
         Dim table As New DataTable()
         Try
            connection.Open()
            reader = command.ExecuteReader()
            If Not reader.Read Then
               Throw New ApplicationException("The unconverted contacts cannot be retrieved. The project ID cannot be found.")
            End If
            table.Load(reader)
         Finally
            If reader IsNot Nothing Then reader.Close()
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try

         Dim contacts As ContactList = convertDeficientContactsTable(table)

         Return contacts
      End Function

      Public Shared Function RetrieveRepId(ByVal projectId As String) As nullable_value(Of Integer)
         Dim connectionString As String = Common.GetConnectionString(Common.ProjectsDbPath)
         Dim connection As IDbConnection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)
         Dim sql As New StringBuilder()
         sql.AppendFormat("SELECT {0} FROM {1} WHERE {2}='{3}'", _
            PT.RepId, PT.TableName, PT.ProjectId, projectId)
         Dim command As IDbCommand = connection.CreateCommand 'New OleDbCommand(sql.ToString(), connection)
         command.CommandText = sql.ToString

         Dim repId As New nullable_value(Of Integer)()
         Try
            connection.Open()
            repId.set_to(command.ExecuteScalar())
         Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try

         Return repId
      End Function

      Private Shared Function convertDeficientContactsTable(ByVal table As DataTable) As ContactList
         Dim contacts As New ContactList()
         If table.Rows.Count = 0 Then
            Return contacts
         End If
         With table.Rows(0)
            Dim architect As String = .Item(PT.ArchitectName).ToString()
            Dim architectCompany As String = .Item(PT.ArchitectCompanyName).ToString()
            Dim contractor As String = .Item(PT.ContractorName).ToString()
            Dim contractorCompany As String = .Item(PT.ContractorCompanyName).ToString()
            Dim engineer As String = .Item(PT.EngineerName).ToString()
            Dim engineerCompany As String = .Item(PT.EngineerCompanyName).ToString()

            Dim contact As Contact

            If IsNullOrEmpty(architect) AndAlso IsNullOrEmpty(architectCompany) Then
               ' don't add to list
            Else
               contact = createContact(architect, architectCompany)
               contact.Company.Role = contact.Roles.Architect
               contacts.Add(contact)
            End If

            If IsNullOrEmpty(contractor) AndAlso IsNullOrEmpty(contractorCompany) Then
            Else
               contact = createContact(contractor, contractorCompany)
               contact.Company.Role = contact.Roles.Contractor
               contacts.Add(contact)
            End If

            If IsNullOrEmpty(engineer) AndAlso IsNullOrEmpty(engineerCompany) Then
            Else
               contact = createContact(engineer, engineerCompany)
               contact.Company.Role = contact.Roles.Engineer
               contacts.Add(contact)
            End If
         End With

         Return contacts
      End Function

      Private Shared Function createContact(ByVal name As String, ByVal company As String) As Contact
         Dim contact As New Contact()
         contact.Name.FullName = name
         contact.Company.Name = company

         Return contact
      End Function

      Private Class SqlFactory


         ''' <summary>Sql command to update submittal</summary>
         Public Shared Function GetUpdateProjectSqlCommand(ByVal project As ProjectItem) As String
            Dim updateSqlCommand As String
            Dim builder As SqlBuilder
            Dim affectedSqlColumns, criteriaSqlColumns As List(Of SqlColumn)

            criteriaSqlColumns = New List(Of SqlColumn)

            ' gets affected columns
            affectedSqlColumns = ProjectColumns(project)

            ' gets criteria columns
            criteriaSqlColumns.Add(New SqlColumn(PT.ProjectId, SqlDataType.String, project.id.Id))
            criteriaSqlColumns.Add(New SqlColumn(PT.ProjectRevision, SqlDataType.Number, CStr(project.Revision)))

            ' builds update sql command
            builder = New SqlBuilder(affectedSqlColumns, PT.TableName, criteriaSqlColumns)

            ' generates update sql command
            updateSqlCommand = builder.GenerateUpdateCommand()

            Return updateSqlCommand
         End Function


         ''' <summary>
         ''' Sql command to insert submittal
         ''' </summary>
         Public Shared Function GetInsertProjectSqlCommand(ByVal project As ProjectItem) As String
            Dim affectedColumns As List(Of SqlColumn) = ProjectColumns(project)
            affectedColumns.Add(New SqlColumn(PT.ProjectId, SqlDataType.String, project.id.Id))
            Dim builder As New SqlBuilder(affectedColumns, PT.TableName)
            Dim sqlInsertCommand As String = builder.GenerateInsertCommand()

            Return sqlInsertCommand
         End Function


         ''' <summary>Gets sql column list with all columns in submittal table except submittalId</summary>
         Private Shared Function ProjectColumns(ByVal project As ProjectItem) As List(Of SqlColumn)
            Dim columns As New List(Of SqlColumn)

            With columns

               .Add(New SqlColumn(PT.ProjectRevision, SqlDataType.Number, project.Revision.ToString))

               .Add(New SqlColumn(PT.Name, SqlDataType.String, project.name))
               .Add(New SqlColumn(PT.HoursBeforeDeliveryToCall, SqlDataType.Number, project.HoursBeforeDeliveryToCall.to_string_or_null))
               .Add(New SqlColumn(PT.Notes, SqlDataType.String, project.Notes))
               .Add(New SqlColumn(PT.PoDate, SqlDataType.Date, project.PurchaseOrderDate.to_string_or_null))
               .Add(New SqlColumn(PT.PoNum, SqlDataType.Number, project.PurchaseOrderNum.to_string_or_null))
               .Add(New SqlColumn(PT.ReleaseNum, SqlDataType.Number, project.ReleaseNum.to_string_or_null))
               .Add(New SqlColumn(PT.ReleaseStatus, SqlDataType.String, project.ReleaseStatus.ToString))
               .Add(New SqlColumn(PT.RequestedShipDate, SqlDataType.Date, project.RequestedShipDate.to_string_or_null))
               .Add(New SqlColumn(PT.SalesClass, SqlDataType.String, project.SalesClass))
               .Add(New SqlColumn(PT.Tag, SqlDataType.String, project.Tag))

               ' TODO: Project Columns
               '.Add(New SqlColumn(PT.RepId, SqlDataType.Number, project.Rep.Id.ToStringOrNull))
               '.Add(New SqlColumn(PT.ArchitectName, SqlDataType.String, project.Architect.ContactName))
               '.Add(New SqlColumn(PT.ContractorName, SqlDataType.String, project.Contractor.ContactName))
               '.Add(New SqlColumn(PT.EngineerName, SqlDataType.String, project.Engineer.ContactName))

               '.Add(New SqlColumn(PT.RepCompanyId, SqlDataType.Number, project.Rep.Company.Id.ToStringOrNull))
               '.Add(New SqlColumn(PT.ArchitectCompanyName, SqlDataType.String, project.Architect.CompanyName))
               '.Add(New SqlColumn(PT.EngineerCompanyName, SqlDataType.String, project.Engineer.CompanyName))
               '.Add(New SqlColumn(PT.ContractorCompanyName, SqlDataType.String, project.Contractor.CompanyName))

               .Add(New SqlColumn(PT.ProjectOwner, SqlDataType.String, project.ProjectOwner))
               .Add(New SqlColumn(PT.CheckedOutBy, SqlDataType.String, project.CheckedOutBy))
               .Add(New SqlColumn(PT.OpenedBy, SqlDataType.String, project.OpenedBy))
               .Add(New SqlColumn(PT.RevisionDate, SqlDataType.Date, project.RevisionDate.to_string_or_null))

            End With

            Return columns
         End Function



      End Class

   End Class

End Namespace
