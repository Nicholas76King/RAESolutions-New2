Imports System
Imports System.Data
Imports System.Collections.Generic
Imports Rae.Data
Imports Rae.RaeSolutions.Business.Entities
Imports ProcessTable = Rae.RaeSolutions.DataAccess.Projects.Tables.ProcessesTable
Imports CNull = Rae.ConvertNull
Imports System.Text

Namespace Rae.RaeSolutions.DataAccess.Projects

Public Class ProcessItemDA

   Friend Shared Function Create(connection As iDbConnection, transaction As iDbTransaction, _
   process As ProcessItem, processTableName As String) As Integer

      Dim sql As String
      Dim numRowsAffected As Integer = 0

      sql = "INSERT INTO Processes (ID, ProjectID, ProcessTableName ) VALUES ("
      sql = sql + "'" + process.id.ToString + "', "

      If process.ProjectManager Is Nothing Then
         ' PROJECT MUST BE CREATED
         Throw New System.InvalidOperationException("Process item cannot be created.  ProjectManager is null.")
      Else
         sql = sql & "'" & process.ProjectManager.Project.id.ToString & "'"
      End If

      sql = sql + ", '" + processTableName + "')"

      Dim command As IDbCommand = connection.CreateCommand
      command.CommandText = sql
      command.Transaction = transaction
      numRowsAffected = command.ExecuteNonQuery()

      Return numRowsAffected
   End Function

   'Is it possible to update if ID and ProjectID are the only items?
   Friend Shared Sub Update(connection As iDbConnection, transaction As iDbTransaction, _
 process As CondenserProcessItem)

      Dim sql As String

      sql = "UPDATE Processes SET "
      'sql = sql + "ID = '" + process.Id.ToString + "', "
      'sql = sql + "Model = '" + process.Model + "', "
      'revision
      'sql = sql + "'', "
      'created by
      'sql = sql + "'', "
      'created date
      'sql = sql + "'', "
      'XML
      'sql = sql + "'', "

      sql = sql + "WHERE ID = '" + process.id.ToString + "'"

      Dim command As IDbCommand = connection.CreateCommand
      command.CommandText = sql
      command.ExecuteNonQuery()
   End Sub

   Shared Function Exists(id As String) As Boolean
      Dim connection As iDbConnection
      Dim command As iDbCommand
      Dim reader As iDataReader
      Dim connectionString As String, sql As String
      Dim found As Boolean = False

      connectionString = Common.GetConnectionString(Common.ProjectsDbPath)
      connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)


      'sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}] = '{2}'", _
      '   PT.TableName, PT.ProjectId, id.ToString)
      sql = "SELECT * FROM Processes WHERE Id = '" + id + "'"
      command = connection.CreateCommand 'New OleDbCommand(sql, connection)
      command.CommandText = sql

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
         'found = reader.HasRows()
      Catch ex As dataException
         Throw ex
      Finally
         If reader IsNot Nothing Then reader.Close()
         If connection.State <> ConnectionState.Closed Then connection.Close()
      End Try

      Return found
   End Function

   Shared Function RevisionExists(connection As IDbConnection, transaction As IDbTransaction, id As String, revision As String, TableName As String) As Boolean

      Dim command As IDbCommand
      Dim reader As IDataReader
      Dim sql As String
      Dim found As Boolean = False

      sql = "SELECT * FROM " + TableName + " WHERE ProcessId = '" + id + "' AND Revision > -1 "
      command = connection.CreateCommand 'New OleDbCommand(sql, connection)
      command.CommandText = sql
      command.Transaction = transaction

      Try
         'connection.Open()
         reader = command.ExecuteReader()
         ' checks if project exists
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
         'If reader IsNot Nothing Then reader.Close()
         'If connection.State <> ConnectionState.Closed Then connection.Close()
      End Try

      Return found
   End Function

   Shared Function RevisionExists(id As String, revision As String, TableName As String) As Boolean
      Dim reader As iDataReader
      Dim found As Boolean = False

      Dim connection = Common.CreateConnection(Common.ProjectsDbPath)

      Dim sql = "SELECT * FROM " + TableName + " WHERE [ProcessID]='" + id + "' AND [Revision]=" & revision
      Dim command = connection.CreateCommand()
      command.CommandText = sql

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
         'found = reader.HasRows()
      Catch ex As dataException
         Throw ex
      Finally
         If reader IsNot Nothing Then reader.Close()
         If connection.State <> ConnectionState.Closed Then connection.Close()
      End Try

      Return found
   End Function

   Shared Function RetrieveByProject(projectId As String) As DataTable
      Dim sql As String
      Dim reader As IDataReader

      Dim dr As DataRow
      Dim dt As New DataTable

      ' creates columns in table
      dt.Columns.Add("ProjectId", GetType(String))
      dt.Columns.Add("ProcessId", GetType(String))
      dt.Columns.Add("DataTableName", GetType(String))

      Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
      Dim command = connection.CreateCommand()
      sql = "SELECT * FROM [Processes] WHERE [ProjectID]='" + projectId + "'"
      command.CommandText = sql

      Try
         connection.Open()
         reader = command.ExecuteReader()
         While reader.Read()
            dr = dt.NewRow
            dr("ProjectId") = reader("ProjectID").ToString
            dr("ProcessId") = reader("ID").ToString
            dr("DataTableName") = reader("ProcessTableName").ToString
            dt.Rows.Add(dr)
         End While
      Catch ex As dataException
         Throw ex
      Finally
         If reader IsNot Nothing Then reader.Close()
         If Not (connection.State.Equals(ConnectionState.Closed)) Then connection.Close()
      End Try

      Return dt
   End Function

   ''' <summary>
   ''' Get's the latest revision of process based on ID
   ''' </summary>
   ''' <param name="processid"></param>
   ''' <returns>Single - Latest Revision</returns>
   ''' <remarks></remarks>
   Shared Function LastestRevision(processid As String) As Single
      Dim Lastrevision As Single = 0
      If GetTableName(processid) = "" Then Return Lastrevision
      Dim connectionString As String
      Dim sql As String
      Dim connection As IDbConnection
      Dim command As IDbCommand
      Dim reader As IDataReader
      connectionString = Common.GetConnectionString(Common.ProjectsDbPath)
      sql = "SELECT [Revision] " & _
            "FROM " & GetTableName(processid) & " " & _
            "WHERE [ProcessID] = '" & processid & "' " & _
            "ORDER BY [REVISION] DESC"
      connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)

      command = connection.CreateCommand 'New OleDbCommand(sql, connection)
      command.CommandText = sql
      Dim TableName As String = ""
      Try
         connection.Open()
         reader = command.ExecuteReader()
         If reader.Read() Then
            Lastrevision = CSng(reader("Revision"))
         End If
      Catch ex As DataException
         Throw
      Finally
         If reader IsNot Nothing Then reader.Close()
         If Not (connection.State.Equals(ConnectionState.Closed)) Then connection.Close()
      End Try
      Return Lastrevision
   End Function

   ''' <summary>
   ''' Get's the latest revision of process based on ID
   ''' and increments the item revision level as required.
   ''' </summary>
   ''' <param name="processid"></param>
   ''' <returns>Single - Item Revision Number</returns>
   ''' <remarks></remarks>
   Shared Function IncrementItemRevision(processid As String) As Single
      Dim NewRevision As Single = 0
      If GetTableName(processid) = "" Then Return NewRevision
      Dim connectionString As String
      Dim sql As String
      Dim connection As IDbConnection
      Dim command As IDbCommand
      Dim reader As IDataReader
      connectionString = Common.GetConnectionString(Common.ProjectsDbPath)
      sql = "SELECT [Revision] " & _
            "FROM " & GetTableName(processid) & " " & _
            "WHERE [ProcessID] = '" & processid & "' " & _
            "ORDER BY [REVISION] DESC"
      connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)

      command = connection.CreateCommand 'New OleDbCommand(sql, connection)
      command.CommandText = sql
      Dim TableName As String = ""
      Try
         connection.Open()
         reader = command.ExecuteReader()
         If reader.Read() Then
            NewRevision = CSng(reader("Revision"))
            NewRevision += CSng(0.001)
            'Dim tmpstr As String = NewRevision.ToString
            'If tmpstr.IndexOf(CChar(".")) < 0 Then
            '   tmpstr = tmpstr & ".0"
            'End If
            'NewRevision += CSng(1 / 10 ^ (tmpstr.Length - 1 - tmpstr.IndexOf(CChar("."))))
         End If
      Catch ex As DataException
         Throw
      Finally
         If reader IsNot Nothing Then reader.Close()
         If Not (connection.State.Equals(ConnectionState.Closed)) Then connection.Close()
      End Try
      Return CSng(System.Math.Round(NewRevision, 3))
   End Function

   ''' <summary>
   ''' Get's all revisions as List(of Integer)
   ''' </summary>
   ''' <param name="processid"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Shared Function GetAllRevisions(processid As String) As List(Of Single)
      Dim RevisionList As New List(Of Single)
      If GetTableName(processid) = "" Then Return RevisionList
      Dim connectionString As String
      Dim sql As String
      Dim connection As IDbConnection
      Dim command As IDbCommand
      Dim reader As IDataReader
      connectionString = Common.GetConnectionString(Common.ProjectsDbPath)
      sql = "SELECT [Revision] " & _
            "FROM " & GetTableName(processid) & " " & _
            "WHERE [ProcessID] = '" & processid & "' " & _
            "ORDER BY [REVISION]"
      connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)

      command = connection.CreateCommand 'New OleDbCommand(sql, connection)
      command.CommandText = sql
      Try
         connection.Open()
         reader = command.ExecuteReader()
         While reader.Read()
            RevisionList.Add(CSng(reader("Revision")))
         End While
      Catch ex As DataException
         'Throw
      Finally
         If reader IsNot Nothing Then reader.Close()
         If Not (connection.State.Equals(ConnectionState.Closed)) Then connection.Close()
      End Try
      Return RevisionList
   End Function

   ''' <summary>
   ''' Returns table name based on process ID
   ''' </summary>
   ''' <param name="processID"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Shared Function GetTableName(processID As String) As String
      Dim TableName As String = ""
      Dim connectionString As String
      Dim sql As String
      Dim connection As iDbConnection
      Dim command As iDbCommand
      Dim reader As iDataReader
      connectionString = Common.GetConnectionString(Common.ProjectsDbPath)
      sql = "SELECT [ProcessTableName] FROM [Processes] WHERE [ID]='" + processID + "'"
      connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)

      command = connection.CreateCommand 'New OleDbCommand(sql, connection)
      command.CommandText = sql
      Try
         connection.Open()
         reader = command.ExecuteReader()
         If reader.Read() Then
            TableName = reader("ProcessTableName").ToString
         End If
      Catch ex As dataException
         Throw ex
      Finally
         If reader IsNot Nothing Then reader.Close()
         If Not (connection.State.Equals(ConnectionState.Closed)) Then connection.Close()
      End Try
      Return TableName
   End Function

   ''' <summary>
   ''' Returns project ID based on process ID
   ''' </summary>
   ''' <param name="processID"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Shared Function GetProjectID(processID As String) As item_id
      Dim ProjectID As item_id = Nothing
      Dim connectionString As String
      Dim sql As String
      Dim connection As iDbConnection
      Dim command As iDbCommand
      Dim reader As iDataReader
      connectionString = Common.GetConnectionString(Common.ProjectsDbPath)
      sql = "SELECT [ProjectID] FROM [Processes] WHERE [ID]='" + processID + "'"
      connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)

      command = connection.CreateCommand 'New OleDbCommand(sql, connection)
      command.CommandText = sql
      Try
         connection.Open()
         reader = command.ExecuteReader()
         If reader.Read() Then
            ProjectID = New item_id(reader("ProjectID").ToString)
         End If
      Catch ex As dataException
         Throw ex
      Finally
         If reader IsNot Nothing Then reader.Close()
         If Not (connection.State.Equals(ConnectionState.Closed)) Then connection.Close()
      End Try
      Return ProjectID
   End Function

   Shared Function Retrieve(processId As String, Optional ByVal Table As String = "") As ProcessItem
      Dim process As ProcessItem
      Dim id As item_id

      'item id
      id = New item_id(processId)

      If Table = "" Then
         Select Case GetTableName(processId)
            Case "CondenserProcesses"
               process = CondenserProcessDA.Retrieve(id)
            Case "ACChillerProcesses"
               process = ACChillerProcessDA.Retrieve(id)
            Case "CondensingUnitProcesses"
               process = CondensingUnitProcessDA.Retrieve(id)
            Case "EvapChillerProcesses"
               process = EvaporativeCondenerChillerBalanceDa.Retrieve(id)
            Case "UnitCoolerProcesses"
               process = UnitCoolerProcessDA.Retrieve(id)
            Case "WCChillerProcesses"
               process = WCChillerProcessDA.Retrieve(id)
            Case "FluidCoolerProcesses"
               process = FluidCoolerProcessItem.PopulateLatest(id.ToString)
            Case Else
               Throw New System.ApplicationException("The process can not be retrieved. " & _
                  "The process type, " & Table & ", is invalid.")
         End Select

      Else

         Select Case Table
            Case "CondenserProcesses"
               process = CondenserProcessDA.Retrieve(id, -1)
            Case "ACChillerProcesses"
               process = ACChillerProcessDA.Retrieve(id, -1)
            Case "CondensingUnitProcesses"
               process = CondensingUnitProcessDA.Retrieve(id, -1)
            Case "EvapChillerProcesses"
               process = EvaporativeCondenerChillerBalanceDa.Retrieve(id, -1)
            Case "UnitCoolerProcesses"
               process = UnitCoolerProcessDA.Retrieve(id, -1)
            Case "WCChillerProcesses"
               process = WCChillerProcessDA.Retrieve(id, -1)
            Case "FluidCoolerProcesses"
               process = FluidCoolerProcessItem.PopulateLatest(id.ToString) 'FluidCoolerProcessItem.Populate(id.ToString)(0) 'WCChillerProcessDA.Retrieve(id, -1)
            Case Else
               Throw New System.ApplicationException("The process can not be retrieved. " & _
                  "The process type, " & Table & ", is invalid.")
         End Select

      End If

      Return process

   End Function


   ''' <summary>
   ''' Creates or updates process item.
   ''' </summary>
   ''' <param name="process">
   ''' Process item to create or update.
   ''' </param>
   Shared Sub Save(process As ProcessItem)
      ' throws exception if argument is null
      If process Is Nothing Then
         Throw New ArgumentNullException("The process cannot be saved. The process is null.")
      End If

      process.RevisionDate = Date.Today

      ' updates process if the revision already exists; creates process if it does not exist
      '
      If TypeOf process Is CondenserProcessItem Then
         If RevisionExists(process.id.Id, process.Revision.ToString, Tables.CondenserProcessesTable.TableName) Then
            CondenserProcessDA.Update(CType(process, CondenserProcessItem))
         Else
            CondenserProcessDA.Create(CType(process, CondenserProcessItem))
         End If
      ElseIf TypeOf process Is CondensingUnitProcessItem Then
         If RevisionExists(process.id.Id, process.Revision.ToString, Tables.CondensingUnitProcessTable.TableName) Then
            CondensingUnitProcessDA.Update(CType(process, CondensingUnitProcessItem))
         Else
                    CondensingUnitProcessDA.Create(CType(process, CondensingUnitProcessItem))
         End If
      ElseIf TypeOf process Is WCChillerProcessItem Then
         If RevisionExists(process.id.Id, process.Revision.ToString, Tables.WCChillerProcessTable.TableName) Then
            WCChillerProcessDA.Update(CType(process, WCChillerProcessItem))
         Else
            WCChillerProcessDA.Create(CType(process, WCChillerProcessItem))
         End If
      ElseIf TypeOf process Is ACChillerProcessItem Then
         If RevisionExists(process.id.Id, process.Revision.ToString, Tables.ACChillerProcessTable.TableName) Then
            ACChillerProcessDA.Update(CType(process, ACChillerProcessItem))
         Else
            ACChillerProcessDA.Create(CType(process, ACChillerProcessItem))
         End If
      ElseIf TypeOf process Is EvaporativeCondenserChillerBalance Then
         If RevisionExists(process.id.Id, process.Revision.ToString, Tables.EvapChillerProcessTable.TableName) Then
            EvaporativeCondenerChillerBalanceDa.Update(CType(process, EvaporativeCondenserChillerBalance))
         Else
            EvaporativeCondenerChillerBalanceDa.Create(CType(process, EvaporativeCondenserChillerBalance))
         End If
      ElseIf TypeOf process Is cu_uc_balance_screen_model Then
         If RevisionExists(process.id.Id, process.Revision.ToString, Tables.UnitCoolerProcessTable.TableName) Then
            UnitCoolerProcessDA.Update(CType(process, cu_uc_balance_screen_model))
         Else
            UnitCoolerProcessDA.Create(CType(process, cu_uc_balance_screen_model))
         End If
      ElseIf TypeOf process Is FluidCoolerProcessItem Then
         If RevisionExists(process.id.Id, process.Revision.ToString, "FluidCoolerProcesses") Then
            FluidCoolerProcessItemDA.Update(CType(process, FluidCoolerProcessItem))
         Else
            FluidCoolerProcessItemDA.Create(CType(process, FluidCoolerProcessItem))
         End If
      Else
         Throw New ArgumentException("The process cannot be saved. The process type is not supported.")
      End If

   End Sub


   ''' <summary>
   ''' Saves process item as new process item.
   ''' </summary>
   ''' <param name="process">
   ''' Process item to save as new.
   ''' </param>
   Shared Sub SaveAs(process As ProcessItem, NewProjectManager As project_manager)

   End Sub


   Shared Function DeleteProcess(ProcessID As String) As Integer
      Dim tableName As String = GetTableName(ProcessID)
      Return DeleteProcess(ProcessID, tableName)
   End Function


   Shared Function DeleteProcess(ProcessItem As ProcessItem) As Integer
      If ProcessItem Is Nothing Then Exit Function
      Dim TableName As String = GetTableName(ProcessItem.id.Id)
      Return DeleteProcess(ProcessItem.id.Id, TableName)
   End Function


   ''' <summary>Delete a process based on process id string and table name</summary>
   Shared Function DeleteProcess(ProcessID As String, ProcessTableName As String) As Integer
      Dim sql As String
      Dim NumRowsDeleted As Integer = 0

      dim connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)
      dim command = connection.CreateCommand

      connection.Open()

      ' delete any matching process records
      Try
         sql = "DELETE FROM [" & ProcessTableName & "] " & _
               "WHERE [ProcessID]='" & ProcessID & "'"
         'command.Connection = connection
         command.CommandText = sql
         NumRowsDeleted = command.ExecuteNonQuery()
      Catch ex As Exception
         Throw New ArgumentException("TABLE " & ProcessTableName & " was not found.")
      End Try

      ' delete from Processes table & ProcessEquip table(process/equipment relations)
      Try
         If NumRowsDeleted > 0 Then

            sql = "DELETE FROM [Processes] " & _
                  "WHERE [ID] = '" & ProcessID & "'"
            command.CommandText = sql
            command.ExecuteNonQuery()

            sql = "DELETE FROM [ProcessEquip] " & _
                  "WHERE [ProcessID] = '" & ProcessID & "'"
            command.CommandText = sql
            command.ExecuteNonQuery()

         End If

      Catch ex As Exception
         ' no process equipment relationships were found
      End Try

      connection.Close()

      Return NumRowsDeleted
   End Function


   ''' <summary>
   ''' deletes process based on id, processtable and existing connection, transaction
   ''' </summary>
   Shared Function DeleteProcess(ProcessID As String, ProcessTableName As String, connection As IDbConnection, transaction As IDbTransaction) As Integer
      Dim command As IDbCommand
      Dim sql As String
      Dim NumRowsDeleted As Integer = 0

      ' delete any matching process records
      sql = "DELETE FROM [" & ProcessTableName & "] " & _
            "WHERE [ProcessID]='" & ProcessID & "'"
      command = connection.CreateCommand 'New OleDbCommand(sql, connection)
      command.CommandText = sql
      command.Transaction = transaction
      NumRowsDeleted = command.ExecuteNonQuery()

      ' delete from Processes table & ProcessEquip table(process/equipment relations)
      Try
         If NumRowsDeleted > 0 Then
            sql = "DELETE FROM [Processes] " & _
                  "WHERE [ID] = '" & ProcessID & "'"
            command.Connection = connection
            command.CommandText = sql
            command.Transaction = transaction
            command.ExecuteNonQuery()

            sql = "DELETE FROM [ProcessEquip] " & _
                  "WHERE [ProcessID] = '" & ProcessID & "'"
            command.Connection = connection
            command.CommandText = sql
            command.Transaction = transaction
            command.ExecuteNonQuery()
         End If
      Catch ex As Exception
         ' no process equipment relationships were found
      End Try

      Return NumRowsDeleted
   End Function


   ''' <summary>
   ''' deletes all processes in a project
   ''' </summary>
   Shared Sub DeleteALLProcesses(ProjectID As String, connection As IDbConnection, transaction As IDbTransaction)

      Dim command As IDbCommand
      Dim sql As String
      Dim reader As IDataReader

      Dim tmpSQL As String = String.Empty
      ' delete any matching process records
      Try

         sql = "SELECT * FROM [" & ProcessTable.TableName & "] " & _
               "WHERE [" & ProcessTable.ProjectId & "] = '" & ProjectID & "'"
         command = connection.CreateCommand 'New OleDbCommand(sql, connection)
         command.CommandText = sql
         command.Transaction = transaction
         reader = command.ExecuteReader()
         If Common.DataAccessType = DataObjects.DataAccessTypes.SQL Then
            If reader IsNot Nothing Then
               tmpSQL += "DELETE FROM [Processes] WHERE [ProjectId] = '" & ProjectID & "';"
            End If
         End If
         While reader.Read()
            If Common.DataAccessType = DataObjects.DataAccessTypes.SQL Then
               tmpSQL += "DELETE FROM [" & reader("ProcessTableName").ToString & "] WHERE [ProcessID]='" & reader("ID").ToString & "';"
            Else
               DeleteProcess(reader("ID").ToString, reader("ProcessTableName").ToString, connection, transaction)
            End If
            'DeleteProcess(reader("ID").ToString, reader("ProcessTableName").ToString, connection, transaction)
         End While
         If Common.DataAccessType = DataObjects.DataAccessTypes.SQL Then
            reader.Close()
            If tmpSQL.Trim > " " Then
               Dim cmd As New SqlClient.SqlCommand(tmpSQL, CType(connection, SqlClient.SqlConnection))
               cmd.Transaction = CType(transaction, SqlClient.SqlTransaction)
               cmd.ExecuteNonQuery()
            End If
         End If
      Catch ex As DataException
         Throw ex
      Finally
         If reader IsNot Nothing Then If Not reader.IsClosed Then reader.Close()

      End Try

   End Sub


   ''' <summary>Renames process.</summary>
   ''' <param name="id">ID of process to rename.</param>
   ''' <param name="name">New name of process.</param>
   Shared Sub Rename(id As String, name As String)
      Dim tableName = GetTableName(id)
      Dim numAffectedRows As Integer

      Dim connection = Common.CreateConnection(Common.ProjectsDbPath)

      Dim sql As New StringBuilder
      sql.AppendFormat("UPDATE [{0}] SET [{1}]='{2}' WHERE [{3}]='{4}'", _
         tableName, "Name", name, "ProcessID", id)
         
      Dim command = connection.CreateCommand
      command.CommandText = sql.ToString

      Try
         connection.Open()
         numAffectedRows = command.ExecuteNonQuery()
      Finally
         If connection.State <> ConnectionState.Closed Then connection.Close()
      End Try
   End Sub

End Class

End Namespace