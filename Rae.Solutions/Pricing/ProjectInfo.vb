Imports System.Data
Imports System.Data.Common
Imports Common = Rae.RaeSolutions.DataAccess.Common
Imports CoolStuff = Rae.CoolStuff.CoolStuffCommon
Imports System.Collections.Generic

''' <summary>
''' Project info. Must call Initialize(mdiParent) method before using shared members.
''' </summary>
Class ProjectInfo

   Private Shared m_viewer As ItemViewer
   Private Shared m_creator As ItemCreator
   Private Shared m_newProjectID As String
   Private Shared colStr As String = ""
   Private Shared valStr As String = ""
   Private Shared latestProjectRevision As Integer = 0

   ''' <summary>
   ''' Viewer can view/open project items.
   ''' </summary>
   Public Shared ReadOnly Property Viewer() As ItemViewer
      Get
         Return m_viewer
      End Get
   End Property

   ''' <summary>
   ''' Creator can create new project items.
   ''' </summary>
   Public Shared ReadOnly Property Creator() As ItemCreator
      Get
         Return m_creator
      End Get
   End Property

   ''' <summary>
   ''' Initializes objects. Must be called before using shared members.
   ''' </summary>
   ''' <param name="mdiParent">
   ''' Mdi parent form to view items in.
   ''' </param>
   Public Shared Sub Initialize(ByVal mdiParent As Form)
      m_viewer = New ItemViewer(mdiParent)
      m_creator = New ItemCreator()
   End Sub

   ''' <summary>
   ''' creates new item id based on existing item id - increments time one second without pause
   ''' </summary>
   ''' <param name="FromItemID"></param>
   ''' <returns>new ItemID incremented one second from the original FromItemID parameter</returns>
   ''' <remarks></remarks>
   Public Shared Function NewItemID(ByVal fromItemID As String, Optional ByVal stampCurrentTime As Boolean = False) As String

      ' stamp current time on previous ID?
      If stampCurrentTime Then
         Return fromItemID.Substring(0, fromItemID.Length - 14) & Now.Year.ToString.PadLeft(4, "0") & Now.Month.ToString.PadLeft(2, "0") & Now.Day.ToString.PadLeft(2, "0") & Now.Hour.ToString.PadLeft(2, "0") & Now.Minute.ToString.PadLeft(2, "0") & Now.Second.ToString.PadLeft(2, "0")
      End If

      ' time of day
      Dim tmpHr As Integer = CInt(fromItemID.Substring(fromItemID.Length - 6, 2))
      Dim tmpMin As Integer = CInt(fromItemID.Substring(fromItemID.Length - 4, 2))
      Dim tmpSec As Integer = CInt(fromItemID.Substring(fromItemID.Length - 2))

      ' date
      Dim tmpDay As Integer = CInt(fromItemID.Substring(fromItemID.Length - 8, 2))
      Dim tmpMonth As Integer = CInt(fromItemID.Substring(fromItemID.Length - 10, 2))
      Dim tmpYear As Integer = CInt(fromItemID.Substring(fromItemID.Length - 14, 4))
      Dim tmpdate As Date = tmpMonth & "-" & tmpDay & "-" & tmpYear

      If tmpSec + 1 = 60 Then
         If tmpMin + 1 = 60 Then
            If tmpHr + 1 = 24 Then
               tmpdate = tmpdate.AddDays(1)
               tmpDay = tmpdate.Day.ToString
               tmpMonth = tmpdate.Month.ToString
               tmpYear = tmpdate.Year.ToString
               tmpHr = 0
               tmpMin = 0
               tmpSec = 0
            Else
               tmpHr += 1
               tmpMin = 0
               tmpSec = 0
            End If
         Else
            tmpMin += 1
            tmpSec = 0
         End If
      Else
         tmpSec += 1
      End If

      Return fromItemID.Substring(0, fromItemID.Length - 14) & tmpYear.ToString.PadLeft(4, "0") & tmpMonth.ToString.PadLeft(2, "0") & tmpDay.ToString.PadLeft(2, "0") & tmpHr.ToString.PadLeft(2, "0") & tmpMin.ToString.PadLeft(2, "0") & tmpSec.ToString.PadLeft(2, "0")

   End Function

   Private Shared Sub setColumnValue(ByRef dr As DataRow, ByRef colToSet As DataColumn, ByVal colValue As Object)

      dr(colToSet) = colValue

      If colStr = "" Then
         colStr = "[" & colToSet.ColumnName & "]"
      Else
         colStr = colStr & ", [" & colToSet.ColumnName & "]"
      End If

      Select Case colToSet.DataType.Name
         Case "String", "Char"
            If valStr = "" Then
               valStr = "'" & colValue & "'"
            Else
               valStr = valStr & ", '" & colValue & "'"
            End If
         Case "DateTime"
            If valStr = "" Then
               valStr = "#" & colValue & "#"
            Else
               valStr = valStr & ", #" & colValue & "#"
            End If
         Case "Boolean", "Single", "Byte", "Decimal", "Double", "Int16", "Int32", "Int64", "SByte", "Single", "UInt16", "UInt32", "UInt64"
            If valStr = "" Then
               valStr = colValue
            Else
               valStr = valStr & ", " & colValue
            End If
      End Select

   End Sub

   Public Shared Function GetProjectOwner(ByVal projectid As Rae.RaeSolutions.Business.Entities.item_id) As String

      Return Rae.RaeSolutions.DataAccess.Projects.ProjectsDataAccess.GetProjectOwner(projectid)

   End Function

   Public Shared Function GetProjectRevisions(ByVal projectID As String) As List(Of String)

      Dim sql As String
      Dim connection As IDbConnection
      Dim rdr As IDataReader
      Dim projectRevList As New List(Of String)

      sql = "SELECT ProjectRevision, Description, OpenedBy " & _
            "FROM [Projects] " & _
            "WHERE [ProjectID] = '" & projectID & "' " & _
            "AND ProjectRevision > 0 " & _
            "ORDER BY ProjectRevision DESC"

      If Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
         If Common.IsConnected Then
            connection = Rae.Data.DataObjects.CreateConnection(Data.DataObjects.DataAccessTypes.SQL, Common.ConnectionString(True, False))
         Else
            connection = Rae.Data.DataObjects.CreateConnection(Data.DataObjects.DataAccessTypes.SQL, Common.ConnectionString(True, True))
         End If
      Else
         connection = New OleDb.OleDbConnection("Provider=" & Common.DbProvider & ";Data Source=" & Common.ProjectsDbPath & ";")
      End If

      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      Try
         connection.Open()
         rdr = cmd.ExecuteReader
         While rdr.Read
            projectRevList.Add("Rev#" & rdr("ProjectRevision") & " (" & rdr("OpenedBy") & ") - " & rdr("Description"))
         End While
      Catch ex As Exception
         MessageBox.Show(ex.Message)
      Finally
         If rdr IsNot Nothing Then If Not rdr.IsClosed Then rdr.Close()
         If connection IsNot Nothing Then If Not connection.State.Closed Then connection.Close()
      End Try

      Return projectRevList

   End Function

#Region "Copy Project"

   ''' <summary>
   ''' Copies all project processes & equipment to new project id.
   ''' </summary>
   ''' <param name="ProjectID"></param>
   ''' <returns>Returns new project ID</returns>
   ''' <remarks></remarks>
   Shared Function CopyProject(ProjectID As String) As String

      m_newProjectID = ""

      Dim getNameFrm As New NewItemForm2
      Dim newProjectName As String
      getNameFrm.NewItem(NewItemForm2.NewItemType.ProjectOnly)
      getNameFrm.ShowDialog()
      If getNameFrm.ProjectName > " " And getNameFrm.DialogResult <> Windows.Forms.DialogResult.Cancel Then
         newProjectName = getNameFrm.ProjectName
      Else
         Exit Function
      End If

      Dim lastItemId As String
      Dim connstr As String = Common.GetConnectionString(Common.ProjectsDbPath)
      Dim sql As String
      Dim connection As IDbConnection
      'Dim ds As New System.Data.DataSet("CopyProject")
      Dim da As IDbDataAdapter
      Dim dt As DataTable
      Dim ds As New DataSet
      Dim cb As DbCommandBuilder

      sql = "SELECT TOP 1 * " & _
            "FROM [Projects] " & _
            "WHERE [ProjectID] = '" & ProjectID & "' " & _
            "ORDER BY [ProjectRevision] DESC"

      connection = Common.CreateConnection(Common.ProjectsDbPath) ' OleDbConnection(connstr)
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd) 'New OleDbDataAdapter(sql, connection)

      Try
         connection.Open()
         'dt = New System.Data.DataTable("Project")
         da.Fill(ds)
         dt = ds.Tables(0)
         dt.TableName = "Projects"

         da.TableMappings.Add("Table", "Projects")
         If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
            cb = New OleDb.OleDbCommandBuilder(da)
         ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
            cb = New SqlClient.SqlCommandBuilder(da)
         End If
         'cb = New DbCommandBuilder '(da)

         Dim tbl As System.Data.DataTable = dt.Copy

         If dt.Rows.Count > 0 Then

            ' create new project ID with current time stamp
            m_newProjectID = NewItemID(ProjectID, True)
            lastItemId = m_newProjectID

            For Each row As System.Data.DataRow In tbl.Rows
               Dim r As System.Data.DataRow = dt.NewRow
               For Each col As System.Data.DataColumn In dt.Columns
                  If col.ColumnName.ToLower = "name" Then
                     r(col.ColumnName) = newProjectName

                  ElseIf col.ColumnName.ToLower = "projectid" Then

                     r(col.ColumnName) = m_newProjectID

                     ' copy equipment, options, special options
                     lastItemId = CopyEquipment(ProjectID, m_newProjectID)

                     ' copy processes
                     CopyProcesses(ProjectID, m_newProjectID, lastItemId)

                  ElseIf col.ColumnName.ToLower = "projectrevision" Then
                     r(col.ColumnName) = 0

                  ElseIf col.ColumnName.ToLower = "tag" Then
                     r(col.ColumnName) = m_newProjectID

                  Else
                     r(col.ColumnName) = row(col.ColumnName)
                  End If
               Next
               dt.Rows.Add(r)
            Next

            da.InsertCommand = cb.GetInsertCommand()
            da.Update(ds)

            'ds.Tables.Add(dt)

         End If
         CopyCoolStuff(ProjectID, lastItemId, 0)

      Catch ex As DataException
         Throw ex
      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then _
            connection.Close()
      End Try

      Return m_newProjectID

   End Function

   Private Shared Function CopyEquipment(ByVal projectID As String, ByVal newProjectID As String) As String

      Dim lastItemId As String = newProjectID
      Dim connstr As String = Common.GetConnectionString(Common.ProjectsDbPath)
      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim dt As DataTable
      Dim ds As New DataSet
      Dim cb As DbCommandBuilder

      sql = "select e.* from equipment e inner join (select equipmentid, max(revision) as rev  from equipment where projectid = '" & projectID & "' group by equipmentid)t on t.equipmentid = e.equipmentid and t.rev = e.revision"

      connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connstr)
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd) 'New OleDbDataAdapter(sql, connection)

      da.TableMappings.Add("Table", "Equipment")
      If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
         cb = New OleDb.OleDbCommandBuilder(da)
      ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
         cb = New SqlClient.SqlCommandBuilder(da)
      End If
      'cb = New OleDbCommandBuilder(da)
      'dt = New System.Data.DataTable("Equipment")
      da.Fill(ds)
      dt = ds.Tables(0)
      dt.TableName = "Equipment"

      Try

         Dim tbl As System.Data.DataTable = dt.Copy

         For Each row As System.Data.DataRow In tbl.Rows
            lastItemId = NewItemID(lastItemId)
            Dim r As System.Data.DataRow = dt.NewRow
            For Each col As System.Data.DataColumn In dt.Columns
               If col.ColumnName.ToLower = "projectid" Then
                  r(col.ColumnName) = newProjectID
               ElseIf col.ColumnName.ToLower = "equipmentid" Then
                  r(col.ColumnName) = lastItemId
                  lastItemId = CopyIndividualEquipment(row(col.ColumnName), row("TypeTableName"), lastItemId)
                  lastItemId = CopyEquipmentOptions(row(col.ColumnName), row("Revision"), r(col.ColumnName))
                  lastItemId = CopyEquipmentSpecialOptions(row(col.ColumnName), row("Revision"), r(col.ColumnName))
               ElseIf col.ColumnName.ToLower = "revision" Then
                  r(col.ColumnName) = 0
               ElseIf col.ColumnName.ToLower = "revisiondate" Then
                  r(col.ColumnName) = Now.Date.ToString
               ElseIf col.ColumnName.ToLower = "projectrevision" Then
                  r(col.ColumnName) = 0
               ElseIf col.ColumnName.ToLower = "version" Then
                  r(col.ColumnName) = My.Application.Info.Version
               Else
                  r(col.ColumnName) = row(col.ColumnName)
               End If
            Next
            dt.Rows.Add(r)
         Next

         da.InsertCommand = cb.GetInsertCommand()
         da.Update(ds)

      Catch ex As DataException
         Throw ex

      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()

      End Try

      Return lastItemId

   End Function

   Private Shared Function CopyIndividualEquipment(ByVal equipmentID As String, ByVal equipmentTable As String, ByVal newEquipmentID As String) As String

      Dim lastItemID As String = newEquipmentID
      Dim connstr As String = Common.GetConnectionString(Common.ProjectsDbPath)
      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim dt As DataTable
      Dim ds As New DataSet
      Dim tblFound As Boolean = False
      Dim cb As DbCommandBuilder
      Dim insertText As String = ""
      Dim collist As String = ""
      Dim vallist As String = ""

      sql = "SELECT TOP 1 * " & _
            "FROM [" & equipmentTable & "] " & _
            "WHERE [EquipmentID] = '" & equipmentID & "' " & _
            "ORDER BY [Revision] DESC"

      connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connstr)
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd) 'New OleDbDataAdapter(sql, connection)

      da.TableMappings.Add("Table", equipmentTable)
      If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
         cb = New OleDb.OleDbCommandBuilder(da)
      ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
         cb = New SqlClient.SqlCommandBuilder(da)
      End If

      Try
         connection.Open()

         'dt = New System.Data.DataTable(equipmentTable)
         da.Fill(ds)
         dt = ds.Tables(0)
         dt.TableName = equipmentTable

         'cb = New OleDbCommandBuilder(da)

         Dim tbl As System.Data.DataTable = dt.Copy()

         If dt.Rows.Count > 0 Then

            'clear column & value lists
            colStr = ""
            valStr = ""

            For Each row As System.Data.DataRow In tbl.Rows
               Dim r As System.Data.DataRow = dt.NewRow
               For Each col As System.Data.DataColumn In dt.Columns

                  If col.ColumnName.ToLower = "equipmentid" Then
                     'setColumnValue(r, col, newEquipmentID)
                     r(col.ColumnName) = newEquipmentID

                  ElseIf col.ColumnName.ToLower = "revision" Then
                     'setColumnValue(r, col, 0)
                     r(col.ColumnName) = 0

                  ElseIf col.ColumnName.ToLower = "revisiondate" Then
                     'setColumnValue(r, col, Now.Date.ToString)
                     r(col.ColumnName) = Now.Date.ToString

                  ElseIf col.ColumnName.ToLower = "projectrevision" Then
                     'setColumnValue(r, col, 0)
                     r(col.ColumnName) = 0

                  ElseIf col.ColumnName.ToLower = "version" Then
                     'setColumnValue(r, col, My.Application.Info.Version.ToString)
                     r(col.ColumnName) = My.Application.Info.Version

                  Else
                     'setColumnValue(r, col, row(col.ColumnName))
                     r(col.ColumnName) = row(col.ColumnName)
                  End If
               Next
               dt.Rows.Add(r)
            Next

            da.InsertCommand = cb.GetInsertCommand()
            'da.InsertCommand.CommandText = "INSERT INTO " & equipmentTable & " (" & colStr & ") VALUES (" & valStr & ")"
            da.Update(ds)

         End If

      Catch ex As DataException
         Throw ex

      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()

      End Try

      Return lastItemID

   End Function

   Private Shared Function CopyEquipmentOptions(ByVal equipmentID As String, ByVal equipmentRevision As Single, ByVal NewEquipmentID As String) As String

      Dim lastItemId As String = NewEquipmentID
      Dim connstr As String = Common.GetConnectionString(Common.ProjectsDbPath)
      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim dt As System.Data.DataTable
      Dim ds As New DataSet
      Dim tblFound As Boolean = False
      Dim cb As DbCommandBuilder

      sql = "SELECT * " & _
            "FROM [EquipmentOptions] " & _
            "WHERE [EquipmentID] = '" & equipmentID & "' " & _
            "AND [Revision] = " & equipmentRevision

      connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connstr)
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd) 'New OleDbDataAdapter(sql, connection)

      da.TableMappings.Add("Table", "EquipmentOptions")

      Try
         connection.Open()

         'dt = New System.Data.DataTable("EquipmentOptions")
         da.Fill(ds)
         dt = ds.Tables(0)
         dt.TableName = "EquipmentOptions"
         If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
            cb = New OleDb.OleDbCommandBuilder(da)
         ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
            cb = New SqlClient.SqlCommandBuilder(da)
         End If
         'cb = New OleDbCommandBuilder(da)

         Dim tbl As System.Data.DataTable = dt.Copy

         If dt.Rows.Count > 0 Then

            For Each row As System.Data.DataRow In tbl.Rows
               Dim r As System.Data.DataRow = dt.NewRow
               For Each col As System.Data.DataColumn In dt.Columns
                  If col.ColumnName.ToLower <> "id" Then
                     If col.ColumnName.ToLower = "equipmentid" Then
                        r(col.ColumnName) = NewEquipmentID
                     ElseIf col.ColumnName.ToLower = "revision" Then
                        r(col.ColumnName) = 0
                     Else
                        r(col.ColumnName) = row(col.ColumnName)
                     End If
                  End If
               Next
               dt.Rows.Add(r)
            Next

            da.InsertCommand = cb.GetInsertCommand()
            da.Update(ds)

            'If Not tblFound Then
            '   ds.Tables.Add(dt)
            'End If

         End If

      Catch ex As DataException
         Throw ex

      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()

      End Try

      Return lastItemId

   End Function

   Private Shared Function CopyEquipmentSpecialOptions(ByVal equipmentID As String, ByVal equipmentRevision As Single, ByVal newEquipmentID As String) As String

      Dim lastItemId As String = newEquipmentID
      Dim connstr As String = Common.GetConnectionString(Common.ProjectsDbPath)
      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim dt As System.Data.DataTable
      Dim ds As New DataSet
      Dim tblFound As Boolean = False
      Dim cb As DbCommandBuilder

      sql = "SELECT * " & _
            "FROM [SpecialOptions] " & _
            "WHERE [EquipmentID] = '" & equipmentID & "' " & _
            "AND [Revision] = " & equipmentRevision

      connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connstr)
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd) 'New OleDbDataAdapter(sql, connection)

      da.TableMappings.Add("Table", "SpecialOptions")

      Try

         connection.Open()

         'dt = New System.Data.DataTable("SpecialOptions")
         da.Fill(ds)
         dt = ds.Tables(0)
         dt.TableName = "SpecialOptions"
         If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
            cb = New OleDb.OleDbCommandBuilder(da)
         ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
            cb = New SqlClient.SqlCommandBuilder(da)
         End If
         'cb = New OleDbCommandBuilder(da)

         Dim tbl As System.Data.DataTable = dt.Copy

         If dt.Rows.Count > 0 Then

            For Each row As System.Data.DataRow In tbl.Rows
               Dim r As System.Data.DataRow = dt.NewRow
               For Each col As System.Data.DataColumn In dt.Columns
                  If col.ColumnName.ToLower <> "id" Then
                     If col.ColumnName.ToLower = "equipmentid" Then
                        r(col.ColumnName) = newEquipmentID
                     ElseIf col.ColumnName.ToLower = "revision" Then
                        r(col.ColumnName) = 0
                     Else
                        r(col.ColumnName) = row(col.ColumnName)
                     End If
                  End If
               Next
               dt.Rows.Add(r)
            Next

            da.InsertCommand = cb.GetInsertCommand()
            da.Update(ds)

            'If Not tblFound Then
            '   ds.Tables.Add(dt)
            'End If
         End If

      Catch ex As DataException
         Throw ex

      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()

      End Try

      Return lastItemId

   End Function

   Private Shared Sub CopyProcesses(ByVal projectID As String, ByVal newProjectID As String, ByVal lastItemID As String)

      Dim connstr As String = Common.GetConnectionString(Common.ProjectsDbPath)
      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim dt As System.Data.DataTable
      Dim ds As New DataSet
      Dim cb As DbCommandBuilder
      Dim tmpID As String = lastItemID

      sql = "SELECT * " & _
            "FROM [Processes] " & _
            "WHERE [ProjectID] = '" & projectID & "'"

      connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connstr)
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd) 'New OleDbDataAdapter(sql, connection)

      da.TableMappings.Add("Table", "Processes")

      Try
         connection.Open()
         'dt = New System.Data.DataTable("Processes")
         da.Fill(ds)
         dt = ds.Tables(0)
         dt.TableName = "Processes"
         If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
            cb = New OleDb.OleDbCommandBuilder(da)
         ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
            cb = New SqlClient.SqlCommandBuilder(da)
         End If
         'cb = New OleDbCommandBuilder(da)

         Dim tbl As System.Data.DataTable = dt.Copy

         If dt.Rows.Count > 0 Then

            For Each row As System.Data.DataRow In tbl.Rows
               lastItemID = NewItemID(lastItemID)
               Dim r As System.Data.DataRow = dt.NewRow
               For Each col As System.Data.DataColumn In dt.Columns
                  If col.ColumnName.ToLower = "projectid" Then
                     r(col.ColumnName) = newProjectID
                  ElseIf col.ColumnName.ToLower = "id" Then
                     r(col.ColumnName) = lastItemID
                     lastItemID = CopyIndividualProcess(row(col.ColumnName), row("ProcessTableName"), r(col.ColumnName))
                  Else
                     r(col.ColumnName) = row(col.ColumnName)
                  End If
               Next
               dt.Rows.Add(r)
            Next

            da.InsertCommand = cb.GetInsertCommand()
            da.Update(ds)

         End If

      Catch ex As DataException
         Throw ex

      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()

      End Try

   End Sub

   Private Shared Function CopyIndividualProcess(ByVal processID As String, ByVal processTable As String, ByVal newProcessID As String) As String

      Dim CSoldRevision As Single
      Dim lastItemID As String = newProcessID
      Dim connstr As String = Common.GetConnectionString(Common.ProjectsDbPath)
      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim dt As System.Data.DataTable
      Dim ds As New DataSet
      Dim tblFound As Boolean = False
      Dim cb As DbCommandBuilder

      sql = "SELECT TOP 1 * " & _
            "FROM [" & processTable & "] " & _
            "WHERE [ProcessID] = '" & processID & "' " & _
            "ORDER BY [Revision] DESC"

      connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connstr)
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd) 'New OleDbDataAdapter(sql, connection)

      da.TableMappings.Add("Table", processTable)

      Try
         connection.Open()

         'dt = New System.Data.DataTable(processTable)
         da.Fill(ds)
         dt = ds.Tables(0)
         dt.TableName = processTable
         If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
            cb = New OleDb.OleDbCommandBuilder(da)
         ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
            cb = New SqlClient.SqlCommandBuilder(da)
         End If
         'cb = New OleDbCommandBuilder(da)

         Dim tbl As System.Data.DataTable = dt.Copy()

         If dt.Rows.Count > 0 Then

            For Each row As System.Data.DataRow In tbl.Rows
               CSoldRevision = row("revision")

               Dim r As System.Data.DataRow = dt.NewRow
               For Each col As System.Data.DataColumn In dt.Columns
                  If col.ColumnName.ToLower = "processid" Then
                     r(col.ColumnName) = newProcessID
                  ElseIf col.ColumnName.ToLower = "revision" Then
                     r(col.ColumnName) = 0
                  ElseIf col.ColumnName.ToLower = "revisiondate" Then
                     r(col.ColumnName) = Now.Date.ToString
                  ElseIf col.ColumnName.ToLower = "projectrevision" Then
                     r(col.ColumnName) = 0
                  ElseIf col.ColumnName.ToLower = "version" Then
                     r(col.ColumnName) = My.Application.Info.Version
                  Else
                     r(col.ColumnName) = row(col.ColumnName)
                  End If
               Next
               dt.Rows.Add(r)
            Next

            da.InsertCommand = cb.GetInsertCommand()
            da.Update(ds)

            'If Not tblFound Then
            '   ds.Tables.Add(dt)
            'End If

         End If

      Catch ex As DataException
         Throw ex

      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()

      End Try

      Return lastItemID

   End Function

   Private Shared Function CopyCoolStuff(ByVal projectid As String, ByVal newprojectid As String, ByVal CSoldRevision As Single) As Integer
      Dim x As CoolStuff.CoolStuffCommon = New CoolStuff.CoolStuffCommon

      x.CoolStuffCopyProjectBoxLoad(projectid, newprojectid)
   End Function

#End Region


#Region "Revision Project"

   ''' <summary>
   ''' Revisions project (latest rev on all processes & equipment)
   ''' </summary>
   ''' <param name="ProjectID"></param>
   Public Shared Sub RevisionProject(ByVal ProjectID As String, Optional ByVal Reason As String = "")

      ' get project revision description
      Dim prd As New ProjectRevisionForm
      prd.Reason = Reason
      prd.ShowDialog()
      Dim projectRevisionDescription As String = prd.txtReason.Text
      prd.Close()

      ' set latest project revision
      latestProjectRevision = Rae.RaeSolutions.DataAccess.Projects.ProjectsDataAccess.RetrieveLatestRevision(ProjectID)

      Dim lastItemId As String
      Dim connstr As String = Common.GetConnectionString(Common.ProjectsDbPath)
      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim dt As DataTable
      Dim ds As New DataSet
      Dim cb As DbCommandBuilder

      sql = "SELECT TOP 1 * " & _
            "FROM [Projects] " & _
            "WHERE [ProjectID] = '" & ProjectID & "' " & _
            "ORDER BY [ProjectRevision] DESC"

      connection = Common.CreateConnection(Common.ProjectsDbPath)
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd)

      da.TableMappings.Add("Table", "Projects")

      Try
         connection.Open()
         da.Fill(ds)
         dt = ds.Tables(0)
         dt.TableName = "Projects"
         If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
            cb = New OleDb.OleDbCommandBuilder(da)
         ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
            cb = New SqlClient.SqlCommandBuilder(da)
         End If

         Dim tbl As System.Data.DataTable = dt.Copy

         If dt.Rows.Count > 0 Then

            For Each row As System.Data.DataRow In tbl.Rows
               Dim r As System.Data.DataRow = dt.NewRow
               For Each col As System.Data.DataColumn In dt.Columns
                  If col.ColumnName.ToLower = "projectid" Then

                     r(col.ColumnName) = row(col.ColumnName)

                     ' revision equipment, options, special options
                     RevisionEquipment(ProjectID)

                     ' revision processes
                     RevisionProcesses(ProjectID)

                  ElseIf col.ColumnName.ToLower = "projectrevision" Then
                     r(col.ColumnName) = latestProjectRevision + 1

                  ElseIf col.ColumnName.ToLower = "description" Then
                     r(col.ColumnName) = projectRevisionDescription

                  ElseIf col.ColumnName.ToLower = "revisiondate" Then
                     r(col.ColumnName) = Date.UtcNow

                  ElseIf col.ColumnName.ToLower = "openedby" Then
                     r(col.ColumnName) = Rae.RaeSolutions.AppInfo.User.username

                  Else
                     r(col.ColumnName) = row(col.ColumnName)

                  End If
               Next
               dt.Rows.Add(r)
            Next

            da.InsertCommand = cb.GetInsertCommand()
            da.Update(ds)

            'ds.Tables.Add(dt)

         End If
         CopyCoolStuff(ProjectID, lastItemId, 0)

      Catch ex As DataException
         Throw ex

      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()

      End Try

   End Sub

   Private Shared Sub RevisionEquipment(ByVal projectID As String)

      Dim connstr As String = Common.GetConnectionString(Common.ProjectsDbPath)
      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim dt As DataTable
      Dim ds As New DataSet
      Dim cb As DbCommandBuilder

      sql = "select e.* from equipment e inner join (select equipmentid, max(revision) as rev from equipment where projectid = '" & projectID & "' group by equipmentid)t on t.equipmentid = e.equipmentid and t.rev = e.revision"

      connection = Common.CreateConnection(Common.ProjectsDbPath)
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd)

      da.TableMappings.Add("Table", "Equipment")
      If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
         cb = New OleDb.OleDbCommandBuilder(da)
      ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
         cb = New SqlClient.SqlCommandBuilder(da)
      End If

      da.Fill(ds)
      dt = ds.Tables(0)
      dt.TableName = "Equipment"

      Try

         Dim tbl As System.Data.DataTable = dt.Copy

         For Each row As System.Data.DataRow In tbl.Rows
            Dim r As System.Data.DataRow = dt.NewRow
            For Each col As System.Data.DataColumn In dt.Columns
               If col.ColumnName.ToLower = "equipmentid" Then
                  r(col.ColumnName) = row(col.ColumnName)
                  RevisionIndividualEquipment(row(col.ColumnName), row("TypeTableName"))
                  RevisionEquipmentOptions(row(col.ColumnName), row("Revision"))
                  RevisionEquipmentSpecialOptions(row(col.ColumnName), row("Revision"))
               ElseIf col.ColumnName.ToLower = "revision" Then
                  r(col.ColumnName) = latestProjectRevision + 1.001
               ElseIf col.ColumnName.ToLower = "revisiondate" Then
                  r(col.ColumnName) = Now.Date.ToString
               ElseIf col.ColumnName.ToLower = "projectrevision" Then
                  r(col.ColumnName) = latestProjectRevision + 1
               ElseIf col.ColumnName.ToLower = "version" Then
                  r(col.ColumnName) = My.Application.Info.Version
               Else
                  r(col.ColumnName) = row(col.ColumnName)
               End If
            Next
            dt.Rows.Add(r)
         Next

         da.InsertCommand = cb.GetInsertCommand()
         da.Update(ds)

      Catch ex As DataException
         Throw ex

      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()

      End Try

   End Sub

   Private Shared Sub RevisionIndividualEquipment(ByVal equipmentID As String, ByVal equipmentTable As String)

      Dim connstr As String = Common.GetConnectionString(Common.ProjectsDbPath)
      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim dt As DataTable
      Dim ds As New DataSet
      Dim tblFound As Boolean = False
      Dim cb As DbCommandBuilder

      sql = "SELECT TOP 1 * " & _
            "FROM [" & equipmentTable & "] " & _
            "WHERE [EquipmentID] = '" & equipmentID & "' " & _
            "ORDER BY [Revision] DESC"

      connection = Common.CreateConnection(Common.ProjectsDbPath)
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd)

      da.TableMappings.Add("Table", equipmentTable)

      Try
         connection.Open()

         da.Fill(ds)
         dt = ds.Tables(0)
         dt.TableName = equipmentTable
         If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
            cb = New OleDb.OleDbCommandBuilder(da)
         ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
            cb = New SqlClient.SqlCommandBuilder(da)
         End If

         Dim tbl As System.Data.DataTable = dt.Copy()

         If dt.Rows.Count > 0 Then

            For Each row As System.Data.DataRow In tbl.Rows
               Dim r As System.Data.DataRow = dt.NewRow
               For Each col As System.Data.DataColumn In dt.Columns
                  If col.ColumnName.ToLower = "revision" Then
                     r(col.ColumnName) = latestProjectRevision + 1.001
                  ElseIf col.ColumnName.ToLower = "revisiondate" Then
                     r(col.ColumnName) = Now.Date.ToString
                  ElseIf col.ColumnName.ToLower = "projectrevision" Then
                     r(col.ColumnName) = latestProjectRevision + 1
                  ElseIf col.ColumnName.ToLower = "version" Then
                     r(col.ColumnName) = My.Application.Info.Version
                  Else
                     r(col.ColumnName) = row(col.ColumnName)
                  End If
               Next
               dt.Rows.Add(r)
            Next

            da.InsertCommand = cb.GetInsertCommand()
            da.Update(ds)

         End If

      Catch ex As DataException
         Throw ex

      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()

      End Try

   End Sub

   Private Shared Sub RevisionEquipmentOptions(ByVal equipmentID As String, ByVal equipmentRevision As Single)

      Dim connstr As String = Common.GetConnectionString(Common.ProjectsDbPath)
      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim dt As System.Data.DataTable
      Dim ds As New DataSet
      Dim tblFound As Boolean = False
      Dim cb As DbCommandBuilder

      sql = "SELECT * " & _
            "FROM [EquipmentOptions] " & _
            "WHERE [EquipmentID] = '" & equipmentID & "' " & _
            "AND [Revision] = " & equipmentRevision

      connection = Common.CreateConnection(Common.ProjectsDbPath)
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd)

      da.TableMappings.Add("Table", "EquipmentOptions")

      Try
         connection.Open()

         da.Fill(ds)
         dt = ds.Tables(0)
         dt.TableName = "EquipmentOptions"
         If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
            cb = New OleDb.OleDbCommandBuilder(da)
         ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
            cb = New SqlClient.SqlCommandBuilder(da)
         End If

         Dim tbl As System.Data.DataTable = dt.Copy

         If dt.Rows.Count > 0 Then

            For Each row As System.Data.DataRow In tbl.Rows
               Dim r As System.Data.DataRow = dt.NewRow
               For Each col As System.Data.DataColumn In dt.Columns
                  If col.ColumnName.ToLower <> "id" Then
                     If col.ColumnName.ToLower = "revision" Then
                        r(col.ColumnName) = latestProjectRevision + 1.001
                     Else
                        r(col.ColumnName) = row(col.ColumnName)
                     End If
                  End If
               Next
               dt.Rows.Add(r)
            Next

            da.InsertCommand = cb.GetInsertCommand()
            da.Update(ds)

         End If

      Catch ex As DataException
         Throw ex

      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()

      End Try

   End Sub

   Private Shared Function RevisionEquipmentSpecialOptions(ByVal equipmentID As String, ByVal equipmentRevision As Single)

      Dim connstr As String = Common.GetConnectionString(Common.ProjectsDbPath)
      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim dt As System.Data.DataTable
      Dim ds As New DataSet
      Dim tblFound As Boolean = False
      Dim cb As DbCommandBuilder

      sql = "SELECT * " & _
            "FROM [SpecialOptions] " & _
            "WHERE [EquipmentID] = '" & equipmentID & "' " & _
            "AND [Revision] = " & equipmentRevision

      connection = Common.CreateConnection(Common.ProjectsDbPath)
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd)

      da.TableMappings.Add("Table", "SpecialOptions")

      Try

         connection.Open()

         da.Fill(ds)
         dt = ds.Tables(0)
         dt.TableName = "SpecialOptions"
         If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
            cb = New OleDb.OleDbCommandBuilder(da)
         ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
            cb = New SqlClient.SqlCommandBuilder(da)
         End If

         Dim tbl As System.Data.DataTable = dt.Copy

         If dt.Rows.Count > 0 Then

            For Each row As System.Data.DataRow In tbl.Rows
               Dim r As System.Data.DataRow = dt.NewRow
               For Each col As System.Data.DataColumn In dt.Columns
                  If col.ColumnName.ToLower <> "id" Then
                     If col.ColumnName.ToLower = "revision" Then
                        r(col.ColumnName) = latestProjectRevision + 1.001
                     Else
                        r(col.ColumnName) = row(col.ColumnName)
                     End If
                  End If
               Next
               dt.Rows.Add(r)
            Next

            da.InsertCommand = cb.GetInsertCommand()
            da.Update(ds)

         End If

      Catch ex As DataException
         Throw ex

      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()

      End Try

   End Function

   Private Shared Sub RevisionProcesses(ByVal projectID As String)

      Dim connstr As String = Common.GetConnectionString(Common.ProjectsDbPath)
      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim dt As System.Data.DataTable
      Dim ds As New DataSet
      Dim cb As DbCommandBuilder

      sql = "SELECT * " & _
            "FROM [Processes] " & _
            "WHERE [ProjectID] = '" & projectID & "'"

      connection = Common.CreateConnection(Common.ProjectsDbPath)
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd)

      da.TableMappings.Add("Table", "Processes")

      Try
         connection.Open()
         da.Fill(ds)
         dt = ds.Tables(0)
         dt.TableName = "Processes"
         If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
            cb = New OleDb.OleDbCommandBuilder(da)
         ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
            cb = New SqlClient.SqlCommandBuilder(da)
         End If

         Dim tbl As System.Data.DataTable = dt.Copy

         If dt.Rows.Count > 0 Then

            For Each row As System.Data.DataRow In tbl.Rows
               Dim r As System.Data.DataRow = dt.NewRow
               For Each col As System.Data.DataColumn In dt.Columns
                  If col.ColumnName.ToLower = "id" Then
                     'r(col.ColumnName) = row(col.ColumnName)
                     RevisionIndividualProcess(row(col.ColumnName), row("ProcessTableName"))
                  Else
                     'r(col.ColumnName) = row(col.ColumnName)
                  End If
               Next
               'dt.Rows.Add(r)
            Next

            ' don't add the top level process record!  only need one instance tying
            ' process to project & appropriate table...

            'da.InsertCommand = cb.GetInsertCommand()
            'da.Update(ds)

         End If

      Catch ex As DataException
         Throw ex

      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()

      End Try

   End Sub

   Private Shared Sub RevisionIndividualProcess(ByVal processID As String, ByVal processTable As String)

      Dim CSoldRevision As Single
      Dim connstr As String = Common.GetConnectionString(Common.ProjectsDbPath)
      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim dt As System.Data.DataTable
      Dim ds As New DataSet
      Dim tblFound As Boolean = False
      Dim cb As DbCommandBuilder

      sql = "SELECT TOP 1 * " & _
            "FROM [" & processTable & "] " & _
            "WHERE [ProcessID] = '" & processID & "' " & _
            "ORDER BY [Revision] DESC"

      connection = Common.CreateConnection(Common.ProjectsDbPath)
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd)

      da.TableMappings.Add("Table", processTable)

      Try
         connection.Open()

         da.Fill(ds)
         dt = ds.Tables(0)
         dt.TableName = processTable
         If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
            cb = New OleDb.OleDbCommandBuilder(da)
         ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
            cb = New SqlClient.SqlCommandBuilder(da)
         End If

         Dim tbl As System.Data.DataTable = dt.Copy()

         If dt.Rows.Count > 0 Then

            For Each row As System.Data.DataRow In tbl.Rows
               CSoldRevision = row("revision")

               Dim r As System.Data.DataRow = dt.NewRow
               For Each col As System.Data.DataColumn In dt.Columns
                  If col.ColumnName.ToLower = "revision" Then
                     r(col.ColumnName) = latestProjectRevision + 1.001
                  ElseIf col.ColumnName.ToLower = "revisiondate" Then
                     r(col.ColumnName) = Now.Date.ToString
                  ElseIf col.ColumnName.ToLower = "projectrevision" Then
                     r(col.ColumnName) = latestProjectRevision + 1
                  ElseIf col.ColumnName.ToLower = "version" Then
                     r(col.ColumnName) = My.Application.Info.Version
                  Else
                     r(col.ColumnName) = row(col.ColumnName)
                  End If
               Next
               dt.Rows.Add(r)
            Next

            da.InsertCommand = cb.GetInsertCommand()
            da.Update(ds)

         End If

      Catch ex As DataException
         Throw ex

      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()

      End Try

   End Sub

#End Region


#Region "Check Out Project"

   Public Shared Sub CheckoutProjects()

      Dim frmOpenProject As New OpenProjectForm()
      frmOpenProject.isCheckout = True

      Dim result As DialogResult
      result = frmOpenProject.ShowDialog()
      If result = DialogResult.OK Then
         If frmOpenProject.CheckList.Count > 0 Then
            For Each s As String In frmOpenProject.CheckList
               CheckoutProject(s)
            Next
         End If
      End If

   End Sub

   Public Shared Function CheckoutProject(ByVal projectID As String) As Boolean

      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim ds As New DataSet

      Dim connection1 As IDbConnection
      Dim da1 As IDbDataAdapter
      Dim dt1 As DataTable
      Dim ds1 As New DataSet
      Dim cb1 As DbCommandBuilder

      ' set latest project revision
      latestProjectRevision = Rae.RaeSolutions.DataAccess.Projects.ProjectsDataAccess.RetrieveLatestRevision(projectID)

      ' make sure project is not already checked out
      sql = "SELECT TOP 1 * FROM [Projects] " & _
            "WHERE [ProjectID] = '" & projectID & "'"
      connection = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd)
      da.Fill(ds)
      If ds.Tables(0).Rows.Count > 0 Then
         MessageBox.Show("You already have this project checked out.", "Project Already Checked Out", MessageBoxButtons.OK)
         Exit Function
      End If
      ds.Tables.Clear()
      ds.Clear()

      ' copy project info over to ProjectsCheckedOut.mdb
      sql = "SELECT TOP 1 * " & _
            "FROM [Projects] " & _
            "WHERE [ProjectID] = '" & projectID & "' " & _
            "ORDER BY [ProjectRevision] DESC"

      If Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
         connection = Rae.Data.DataObjects.CreateConnection(Data.DataObjects.DataAccessTypes.SQL, Common.ConnectionString(True, False))
      Else
         connection = Common.CreateConnection(Common.ProjectsDbPath)
      End If
      cmd = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd)

      da.TableMappings.Add("Table", "Projects")

      Try

         da.Fill(ds)

         If ds.Tables(0).Rows.Count > 0 Then

            ' copy to projectscheckedout table
            sql = "SELECT * FROM [Projects]"
            connection1 = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
            Dim cmd1 As IDbCommand = connection1.CreateCommand
            cmd1.CommandText = sql
            da1 = Common.CreateAdapter(cmd1)
            da1.TableMappings.Add("Table", "Projects")

            ds1 = ds.Copy
            dt1 = ds1.Tables(0)
            dt1.TableName = "Projects"
            If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
               cb1 = New OleDb.OleDbCommandBuilder(da1)
            ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
               cb1 = New SqlClient.SqlCommandBuilder(da1)
            End If

            Dim tbl As System.Data.DataTable = dt1.Copy
            If dt1.Rows.Count > 0 Then
               For Each row As System.Data.DataRow In tbl.Rows
                  Dim r As System.Data.DataRow = dt1.NewRow
                  For Each col As System.Data.DataColumn In dt1.Columns
                     If col.ColumnName.ToLower = "projectid" Then

                        r(col.ColumnName) = row(col.ColumnName)

                        ' revision equipment, options, special options
                        CheckoutEquipment(projectID)

                        ' revision processes
                        CheckoutProcesses(projectID)

                     Else
                        r(col.ColumnName) = row(col.ColumnName)

                     End If
                  Next
                  dt1.Rows.Add(r)

                  ' log checkout rev level
                  writeCheckoutItemRevLevel(projectID, projectID, "Projects", r("ProjectRevision"))
               Next
            End If

            da1.InsertCommand = cb1.GetInsertCommand()
            da1.Update(ds1)

         End If

         CheckoutCoolStuff(projectID)
      Catch ex As DataException
         Throw ex

      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()
         If connection1 IsNot Nothing AndAlso connection1.State <> System.Data.ConnectionState.Closed Then connection1.Close()
      End Try

   End Function

   Private Shared Sub CheckoutEquipment(ByVal projectID As String)

      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim ds As New DataSet

      Dim connection1 As IDbConnection
      Dim da1 As IDbDataAdapter
      Dim dt1 As DataTable
      Dim ds1 As New DataSet
      Dim cb1 As DbCommandBuilder

      sql = "select e.* from equipment e inner join (select equipmentid, max(revision) as rev from equipment where projectid = '" & projectID & "' group by equipmentid)t on t.equipmentid = e.equipmentid and t.rev = e.revision"

      If Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
         connection = Rae.Data.DataObjects.CreateConnection(Data.DataObjects.DataAccessTypes.SQL, Common.ConnectionString(True, False))
      Else
         connection = Common.CreateConnection(Common.ProjectsDbPath)
      End If

      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd)

      da.TableMappings.Add("Table", "Equipment")

      Try

         da.Fill(ds)

         If ds.Tables(0).Rows.Count > 0 Then

            ' copy to equipment table
            sql = "SELECT * FROM [Equipment]"
            connection1 = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
            Dim cmd1 As IDbCommand = connection1.CreateCommand
            cmd1.CommandText = sql
            da1 = Common.CreateAdapter(cmd1)
            da1.TableMappings.Add("Table", "Equipment")

            ds1 = ds.Copy
            If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
               cb1 = New OleDb.OleDbCommandBuilder(da1)
            ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
               cb1 = New SqlClient.SqlCommandBuilder(da1)
            End If
            dt1 = ds1.Tables(0)
            dt1.TableName = "Equipment"

            Dim tbl As System.Data.DataTable = dt1.Copy
            For Each row As System.Data.DataRow In tbl.Rows
               Dim r As System.Data.DataRow = dt1.NewRow
               For Each col As System.Data.DataColumn In dt1.Columns
                  If col.ColumnName.ToLower = "equipmentid" Then
                     r(col.ColumnName) = row(col.ColumnName)
                     CheckoutIndividualEquipment(row(col.ColumnName), row("TypeTableName"))
                     CheckoutEquipmentOptions(row(col.ColumnName), row("Revision"))
                     CheckoutEquipmentSpecialOptions(row(col.ColumnName), row("Revision"))
                  Else
                     r(col.ColumnName) = row(col.ColumnName)
                  End If
               Next
               dt1.Rows.Add(r)

               ' log checkout rev level
               writeCheckoutItemRevLevel(r("ProjectId"), r("EquipmentId"), "Equipment", r("Revision"))
               writeCheckoutItemRevLevel(r("ProjectId"), r("EquipmentId"), r("TypeTableName"), r("Revision"))
            Next

            da1.InsertCommand = cb1.GetInsertCommand()
            da1.Update(ds1)

         End If

      Catch ex As DataException
         Throw ex

      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()
         If connection1 IsNot Nothing AndAlso connection1.State <> System.Data.ConnectionState.Closed Then connection1.Close()
      End Try

   End Sub

   Private Shared Sub CheckoutIndividualEquipment(ByVal equipmentID As String, ByVal equipmentTable As String)

      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim ds As New DataSet

      Dim connection1 As IDbConnection
      Dim da1 As IDbDataAdapter
      Dim dt1 As DataTable
      Dim ds1 As New DataSet
      Dim cb1 As DbCommandBuilder

      sql = "SELECT TOP 1 * " & _
            "FROM [" & equipmentTable & "] " & _
            "WHERE [EquipmentID] = '" & equipmentID & "' " & _
            "ORDER BY [Revision] DESC"


      If Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
         connection = Rae.Data.DataObjects.CreateConnection(Data.DataObjects.DataAccessTypes.SQL, Common.ConnectionString(True, False))
      Else
         connection = Common.CreateConnection(Common.ProjectsDbPath)
      End If

      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd)

      da.TableMappings.Add("Table", equipmentTable)

      Try

         da.Fill(ds)
         If ds.Tables(0).Rows.Count > 0 Then

            ' copy to individual equipment table
            sql = "SELECT * FROM [" & equipmentTable & "]"
            connection1 = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
            Dim cmd1 As IDbCommand = connection1.CreateCommand
            cmd1.CommandText = sql
            da1 = Common.CreateAdapter(cmd1)
            da1.TableMappings.Add("Table", equipmentTable)

            ds1 = ds.Copy
            dt1 = ds1.Tables(0)
            dt1.TableName = equipmentTable
            If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
               cb1 = New OleDb.OleDbCommandBuilder(da1)
            ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
               cb1 = New SqlClient.SqlCommandBuilder(da1)
            End If

            Dim tbl As System.Data.DataTable = dt1.Copy()
            For Each row As System.Data.DataRow In tbl.Rows
               Dim r As System.Data.DataRow = dt1.NewRow
               For Each col As System.Data.DataColumn In dt1.Columns
                  r(col.ColumnName) = row(col.ColumnName)
               Next
               dt1.Rows.Add(r)
            Next

            da1.InsertCommand = cb1.GetInsertCommand()
            da1.Update(ds1)

         End If


      Catch ex As DataException
         Throw ex

      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()
         If connection1 IsNot Nothing AndAlso connection1.State <> System.Data.ConnectionState.Closed Then connection1.Close()
      End Try

   End Sub

   Private Shared Sub CheckoutEquipmentOptions(ByVal equipmentID As String, ByVal equipmentRevision As Single)

      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim ds As New DataSet

      Dim connection1 As IDbConnection
      Dim da1 As IDbDataAdapter
      Dim dt1 As DataTable
      Dim ds1 As New DataSet
      Dim cb1 As DbCommandBuilder

      sql = "SELECT * " & _
            "FROM [EquipmentOptions] " & _
            "WHERE [EquipmentID] = '" & equipmentID & "' " & _
            "AND [Revision] = " & equipmentRevision

      If Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
         connection = Rae.Data.DataObjects.CreateConnection(Data.DataObjects.DataAccessTypes.SQL, Common.ConnectionString(True, False))
      Else
         connection = Common.CreateConnection(Common.ProjectsDbPath)
      End If

      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd)

      da.TableMappings.Add("Table", "EquipmentOptions")

      Try

         da.Fill(ds)
         If ds.Tables(0).Rows.Count > 0 Then

            ' copy to equipmentoptions table
            sql = "SELECT * FROM [EquipmentOptions]"
            connection1 = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
            Dim cmd1 As IDbCommand = connection1.CreateCommand
            cmd1.CommandText = sql
            da1 = Common.CreateAdapter(cmd1)
            da1.TableMappings.Add("Table", "EquipmentOptions")

            ds1 = ds.Copy
            dt1 = ds1.Tables(0)
            dt1.TableName = "EquipmentOptions"
            If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
               cb1 = New OleDb.OleDbCommandBuilder(da1)
            ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
               cb1 = New SqlClient.SqlCommandBuilder(da1)
            End If

            Dim tbl As System.Data.DataTable = dt1.Copy
            For Each row As System.Data.DataRow In tbl.Rows
               Dim r As System.Data.DataRow = dt1.NewRow
               For Each col As System.Data.DataColumn In dt1.Columns
                  If col.ColumnName.ToLower <> "id" Then
                     r(col.ColumnName) = row(col.ColumnName)
                  End If
               Next
               dt1.Rows.Add(r)

               ' log checkout rev level
               writeCheckoutItemRevLevel(equipmentID, r("PricingId").ToString, "EquipmentOptions", equipmentRevision)

            Next

            da1.InsertCommand = cb1.GetInsertCommand()
            da1.Update(ds1)

         End If


      Catch ex As DataException
         Throw ex

      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()
         If connection1 IsNot Nothing AndAlso connection1.State <> System.Data.ConnectionState.Closed Then connection1.Close()
      End Try

   End Sub

   Private Shared Function CheckoutEquipmentSpecialOptions(ByVal equipmentID As String, ByVal equipmentRevision As Single)

      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim ds As New DataSet

      Dim connection1 As IDbConnection
      Dim da1 As IDbDataAdapter
      Dim dt1 As DataTable
      Dim ds1 As New DataSet
      Dim cb1 As DbCommandBuilder

      sql = "SELECT * " & _
            "FROM [SpecialOptions] " & _
            "WHERE [EquipmentID] = '" & equipmentID & "' " & _
            "AND [Revision] = " & equipmentRevision

      If Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
         connection = Rae.Data.DataObjects.CreateConnection(Data.DataObjects.DataAccessTypes.SQL, Common.ConnectionString(True, False))
      Else
         connection = Common.CreateConnection(Common.ProjectsDbPath)
      End If

      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd)

      da.TableMappings.Add("Table", "SpecialOptions")

      Try

         da.Fill(ds)
         If ds.Tables(0).Rows.Count > 0 Then

            ' copy to specialoptions table
            sql = "SELECT * FROM [SpecialOptions]"
            connection1 = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
            Dim cmd1 As IDbCommand = connection1.CreateCommand
            cmd1.CommandText = sql
            da1 = Common.CreateAdapter(cmd1)
            da1.TableMappings.Add("Table", "SpecialOptions")

            ds1 = ds.Copy
            dt1 = ds1.Tables(0)
            dt1.TableName = "SpecialOptions"
            If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
               cb1 = New OleDb.OleDbCommandBuilder(da1)
            ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
               cb1 = New SqlClient.SqlCommandBuilder(da1)
            End If

            Dim tbl As System.Data.DataTable = dt1.Copy
            For Each row As System.Data.DataRow In tbl.Rows
               Dim r As System.Data.DataRow = dt1.NewRow
               For Each col As System.Data.DataColumn In dt1.Columns
                  If col.ColumnName.ToLower <> "id" Then
                     r(col.ColumnName) = row(col.ColumnName)
                  End If
               Next
               dt1.Rows.Add(r)

               ' log checkout rev level
               writeCheckoutItemRevLevel(equipmentID, r("Code"), "SpecialOptions", equipmentRevision)

            Next

            da1.InsertCommand = cb1.GetInsertCommand()
            da1.Update(ds1)

         End If

      Catch ex As DataException
         Throw ex

      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()
         If connection1 IsNot Nothing AndAlso connection1.State <> System.Data.ConnectionState.Closed Then connection1.Close()
      End Try

   End Function

   Private Shared Sub CheckoutProcesses(ByVal projectID As String)

      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim ds As New DataSet

      Dim connection1 As IDbConnection
      Dim da1 As IDbDataAdapter
      Dim dt1 As DataTable
      Dim ds1 As New DataSet
      Dim cb1 As DbCommandBuilder

      sql = "SELECT * " & _
            "FROM [Processes] " & _
            "WHERE [ProjectID] = '" & projectID & "'"

      If Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
         connection = Rae.Data.DataObjects.CreateConnection(Data.DataObjects.DataAccessTypes.SQL, Common.ConnectionString(True, False))
      Else
         connection = Common.CreateConnection(Common.ProjectsDbPath)
      End If

      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd)

      da.TableMappings.Add("Table", "Processes")

      Try

         da.Fill(ds)
         If ds.Tables(0).Rows.Count > 0 Then

            ' copy to processes table
            sql = "SELECT * FROM [Processes]"
            connection1 = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
            Dim cmd1 As IDbCommand = connection1.CreateCommand
            cmd1.CommandText = sql
            da1 = Common.CreateAdapter(cmd1)
            da1.TableMappings.Add("Table", "Processes")

            ds1 = ds.Copy
            dt1 = ds1.Tables(0)
            dt1.TableName = "Processes"
            If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
               cb1 = New OleDb.OleDbCommandBuilder(da1)
            ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
               cb1 = New SqlClient.SqlCommandBuilder(da1)
            End If

            Dim tbl As System.Data.DataTable = dt1.Copy
            For Each row As System.Data.DataRow In tbl.Rows
               Dim r As System.Data.DataRow = dt1.NewRow
               For Each col As System.Data.DataColumn In dt1.Columns
                  If col.ColumnName.ToLower = "id" Then
                     r(col.ColumnName) = row(col.ColumnName)
                     CheckoutIndividualProcess(row("ProjectID"), row(col.ColumnName), row("ProcessTableName"))
                  Else
                     r(col.ColumnName) = row(col.ColumnName)
                  End If
               Next
               dt1.Rows.Add(r)
            Next

            da1.InsertCommand = cb1.GetInsertCommand()
            da1.Update(ds1)

         End If

      Catch ex As DataException
         Throw ex

      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()
         If connection1 IsNot Nothing AndAlso connection1.State <> System.Data.ConnectionState.Closed Then connection1.Close()
      End Try

   End Sub

   Private Shared Sub CheckoutIndividualProcess(ByVal projectID As String, ByVal processID As String, ByVal processTable As String)

      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim ds As New DataSet

      Dim connection1 As IDbConnection
      Dim da1 As IDbDataAdapter
      Dim dt1 As DataTable
      Dim ds1 As New DataSet
      Dim cb1 As DbCommandBuilder

      sql = "SELECT TOP 1 * " & _
            "FROM [" & processTable & "] " & _
            "WHERE [ProcessID] = '" & processID & "' " & _
            "ORDER BY [Revision] DESC"

      If Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
         connection = Rae.Data.DataObjects.CreateConnection(Data.DataObjects.DataAccessTypes.SQL, Common.ConnectionString(True, False))
      Else
         connection = Common.CreateConnection(Common.ProjectsDbPath)
      End If

      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd)

      da.TableMappings.Add("Table", processTable)

      Try

         da.Fill(ds)
         If ds.Tables(0).Rows.Count > 0 Then

            ' copy to individual process table
            sql = "SELECT * FROM [" & processTable & "]"
            connection1 = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
            Dim cmd1 As IDbCommand = connection1.CreateCommand
            cmd1.CommandText = sql
            da1 = Common.CreateAdapter(cmd1)
            da1.TableMappings.Add("Table", processTable)

            ds1 = ds.Copy
            dt1 = ds1.Tables(0)
            dt1.TableName = processTable
            If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
               cb1 = New OleDb.OleDbCommandBuilder(da1)
            ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
               cb1 = New SqlClient.SqlCommandBuilder(da1)
            End If

            Dim tbl As System.Data.DataTable = dt1.Copy()
            For Each row As System.Data.DataRow In tbl.Rows
               Dim r As System.Data.DataRow = dt1.NewRow
               For Each col As System.Data.DataColumn In dt1.Columns
                  r(col.ColumnName) = row(col.ColumnName)
               Next
               dt1.Rows.Add(r)

               ' log checkout rev level
               writeCheckoutItemRevLevel(projectID, r("ProcessId"), processTable, r("Revision"))
            Next

            da1.InsertCommand = cb1.GetInsertCommand()
            da1.Update(ds1)

         End If

      Catch ex As DataException
         Throw ex

      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()
         If connection1 IsNot Nothing AndAlso connection1.State <> System.Data.ConnectionState.Closed Then connection1.Close()

      End Try

   End Sub

   Private Shared Function CheckoutCoolStuff(ByVal projectid As String) As Integer

      'Dim x As CoolStuff.CoolStuffCommon = New CoolStuff.CoolStuffCommon
      'x.CoolStuffCopyProjectBoxLoad(projectid, newprojectid)

   End Function

#End Region


#Region "Check In Project"

   Public Shared Sub CheckinProjects(Optional ByVal pid As String = "")

      Dim serverChanges As DataTable

      If pid.Trim > " " Then

         Dim sql As String
         Dim connection As IDbConnection
         Dim cmd As IDbCommand
         Dim da As IDataAdapter
         Dim ds As New DataSet
         ' make sure project is already checked out
         sql = "SELECT TOP 1 * FROM [Projects] " & _
               "WHERE [ProjectID] = '" & pid & "'"
         connection = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
         cmd = connection.CreateCommand
         cmd.CommandText = sql
         da = Common.CreateAdapter(cmd)
         da.Fill(ds)
         If ds.Tables(0).Rows.Count = 0 Then
            MessageBox.Show("You do not have this project checked out.", "Project Not Checked Out", MessageBoxButtons.OK)
            Exit Sub
         End If
         ds.Tables.Clear()
         ds.Clear()

         serverChanges = GetServerChanges(pid)
         If serverChanges.Rows.Count > 0 Then
            Dim whichVersion As New CheckInChangesForm
            whichVersion.serverChanges = serverChanges
            whichVersion.projectName = serverChanges.Rows(0).Item(0).ToString
            whichVersion.ShowDialog()
            If whichVersion.DialogResult = DialogResult.OK Then
               If whichVersion.userServer = True Then
                  ' make local version item level revisions a revision
                  ' on the checkout project revision level and leave
                  ' the server as is...
                  Dim checkoutDA As DataSet = buildProjectDataset(pid, False, True)
                  For Each tbl As DataTable In checkoutDA.Tables
                     RevisionServerTable(pid, tbl)
                  Next
               Else
                  ' make local version the latest revision on
                  ' the server and increment the project level
                  Dim checkoutDA As DataSet = buildProjectDataset(pid, False, True)
                  For Each tbl As DataTable In checkoutDA.Tables
                     UpdateServerTable(pid, tbl)
                  Next
               End If
               ' delete check out revision level items associated
               ' with this project
               DeleteCheckoutRevisionLevels(pid)
               ' now delete project from check out database
               Rae.RaeSolutions.DataAccess.Projects.ProjectsDataAccess.Delete(pid, True)
            Else
               ' user does not want to checkin this project
               MessageBox.Show("Project: " & serverChanges.Rows(0).Item(0).ToString & " was not checked in.", "Project Not Checked In", MessageBoxButtons.OK)
            End If
         Else
            ' There were not any changes on the server so we
            ' can simply checkin the project with any changes
            ' that were made.
            Dim checkoutDA As DataSet = buildProjectDataset(pid, False, True)
            For Each tbl As DataTable In checkoutDA.Tables
               RevisionServerTable(pid, tbl)
            Next
            ' delete check out revision level items associated
            ' with this project
            DeleteCheckoutRevisionLevels(pid)
            ' now delete project from check out database
            Rae.RaeSolutions.DataAccess.Projects.ProjectsDataAccess.Delete(pid, True)
         End If

      Else


         Dim frmOpenProject As New OpenProjectForm()
         frmOpenProject.isCheckin = True

         Dim result As DialogResult
         result = frmOpenProject.ShowDialog()
         If result = DialogResult.OK Then
            If frmOpenProject.CheckList.Count > 0 Then
               For Each s As String In frmOpenProject.CheckList
                  serverChanges = GetServerChanges(s)
                  If serverChanges.Rows.Count > 0 Then
                     Dim whichVersion As New CheckInChangesForm
                     whichVersion.serverChanges = serverChanges
                     whichVersion.projectName = serverChanges.Rows(0).Item(0).ToString
                     whichVersion.ShowDialog()
                     If whichVersion.DialogResult = DialogResult.OK Then
                        If whichVersion.userServer = True Then
                           ' make local version item level revisions a revision
                           ' on the checkout project revision level and leave
                           ' the server as is...
                           Dim checkoutDA As DataSet = buildProjectDataset(s, False, True)
                           For Each tbl As DataTable In checkoutDA.Tables
                              RevisionServerTable(s, tbl)
                           Next
                        Else
                           ' make local version the latest revision on
                           ' the server and increment the project level
                           Dim checkoutDA As DataSet = buildProjectDataset(s, False, True)
                           For Each tbl As DataTable In checkoutDA.Tables
                              UpdateServerTable(s, tbl)
                           Next
                        End If
                        ' delete check out revision level items associated
                        ' with this project
                        DeleteCheckoutRevisionLevels(s)
                        ' now delete project from check out database
                        Rae.RaeSolutions.DataAccess.Projects.ProjectsDataAccess.Delete(s, True)
                     Else
                        ' user does not want to checkin this project
                        MessageBox.Show("Project: " & serverChanges.Rows(0).Item(0).ToString & " was not checked in.", "Project Not Checked In", MessageBoxButtons.OK)
                     End If
                  Else
                     ' There were not any changes on the server so we
                     ' can simply checkin the project with any changes
                     ' that were made.
                     Dim checkoutDA As DataSet = buildProjectDataset(s, False, True)
                     For Each tbl As DataTable In checkoutDA.Tables
                        RevisionServerTable(s, tbl)
                     Next
                     ' delete check out revision level items associated
                     ' with this project
                     DeleteCheckoutRevisionLevels(s)
                     ' now delete project from check out database
                     Rae.RaeSolutions.DataAccess.Projects.ProjectsDataAccess.Delete(s, True)
                  End If
               Next
            End If
         End If

      End If

   End Sub

   ''' <summary>
   ''' Used when checking in project... this will check in the offline copy
   ''' by inserting all revisions made to the offline version into the project
   ''' level at which it was orginally checked out
   ''' </summary>
   ''' <param name="projectid"></param>
   ''' <param name="tbl"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Private Shared Function RevisionServerTable(ByVal projectid As String, ByVal tbl As DataTable) As Boolean

      Dim filterStr As String
      Dim updateRow As Boolean

      updateRow = True
      For Each row As DataRow In tbl.Rows
         If tbl.TableName = "Processes" Then
            filterStr = "ProjectId = '" & row("ProjectId") & "' AND [ID] = '" & row("Id") & "'"
            updateRow = False
         ElseIf tbl.TableName = "Projects" Then
            filterStr = "ProjectId = '" & row("ProjectId") & "' AND ProjectRevision = " & row("ProjectRevision")
         ElseIf tbl.TableName = "SpecialOptions" Then
            filterStr = "EquipmentId = '" & row("EquipmentId") & "' AND Code = '" & row("Code") & "' AND Revision = " & row("Revision")
         ElseIf tbl.TableName = "EquipmentOptions" Then
            filterStr = "EquipmentId = '" & row("EquipmentId") & "' AND PricingId = " & row("PricingId") & " AND Revision = " & row("Revision")
         ElseIf tbl.Columns("ProcessId") IsNot Nothing Then
            filterStr = "ProcessId = '" & row("ProcessId") & "' AND Revision = " & row("Revision")
         ElseIf tbl.Columns("EquipmentId") IsNot Nothing Then
            filterStr = "EquipmentId = '" & row("EquipmentId") & "' AND Revision = " & row("Revision")
         End If
         If Not ServerRowExists(tbl.TableName, filterStr) Then
            AddServerRow(tbl, row)
         Else
            If updateRow Then
               UpdateServerRow(tbl, row, filterStr)
            End If
         End If
      Next

   End Function

   ''' <summary>
   ''' Used when checking in project... this will check in the offline copy
   ''' by inserting all revisions made to the offline version into the project
   ''' level at which it was orginally checked out
   ''' </summary>
   ''' <param name="projectid"></param>
   ''' <param name="tbl"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Private Shared Function UpdateServerTable(ByVal projectid As String, ByVal tbl As DataTable) As Boolean

      Dim filterStr As String
      Dim updateRow As Boolean
      Dim itemRev As Single = 0

      Static newProjectRevision As Integer = Rae.RaeSolutions.DataAccess.Projects.ProjectsDataAccess.RetrieveLatestRevision(projectid) + 1

      updateRow = True
      For Each row As DataRow In tbl.Rows
         If tbl.TableName = "Processes" Then
            filterStr = "ProjectId = '" & row("ProjectId") & "' AND [ID] = '" & row("Id") & "'"
            updateRow = False
         ElseIf tbl.TableName = "Projects" Then
            row("ProjectRevision") = newProjectRevision
            row("Description") = "CHECK IN"
            row("RevisionDate") = Date.Now
            row("OpenedBy") = AppInfo.User.username
         ElseIf tbl.TableName = "SpecialOptions" Then
            row("Revision") = newProjectRevision + SplitRevision(row("Revision"))
         ElseIf tbl.TableName = "EquipmentOptions" Then
            row("Revision") = newProjectRevision + SplitRevision(row("Revision"))
         ElseIf tbl.Columns("ProcessId") IsNot Nothing Then
            row("Revision") = newProjectRevision + SplitRevision(row("Revision"))
            row("RevisionDate") = Date.Now
         ElseIf tbl.Columns("EquipmentId") IsNot Nothing Then
            row("Revision") = newProjectRevision + SplitRevision(row("Revision"))
         End If

         If updateRow = True Then
            AddServerRow(tbl, row)
         Else
            If Not ServerRowExists(tbl.TableName, filterStr) Then
               AddServerRow(tbl, row)
            End If
         End If

      Next

   End Function

   Private Shared Function SplitRevision(ByVal revision As Single, Optional ByVal wholeNumber As Boolean = False) As Single

      Dim s() As String
      s = revision.ToString.Split(".")

      If wholeNumber = True Then
         Return CSng(s(0))
      Else
         If s(1) IsNot Nothing Then
            Return CSng("." & s(1))
         Else
            Return 0
         End If
      End If

   End Function

   Private Shared Function ServerRowExists(ByVal tableName As String, ByVal filterStr As String) As Boolean

      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim dt As DataTable
      Dim ds As New DataSet

      connection = Rae.Data.DataObjects.CreateConnection(Data.DataObjects.DataAccessTypes.SQL, Common.ConnectionString(True, False))
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = "SELECT * FROM [" & tableName & "] " & _
                        "WHERE " & filterStr
      da = Common.CreateAdapter(cmd)
      da.Fill(ds)
      If ds.Tables(0) IsNot Nothing Then
         If ds.Tables(0).Rows.Count > 0 Then
            Return True
         Else
            Return False
         End If
      Else
         Return False
      End If

   End Function

   Private Shared Sub AddServerRow(ByVal tbl As DataTable, ByVal row As DataRow)

      Dim connection As IDbConnection
      Dim colList As String = ""
      Dim valList As String = ""

      For Each col As DataColumn In tbl.Columns

         If tbl.TableName = "EquipmentOptions" Or tbl.TableName = "SpecialOptions" Then
            If Not col.ColumnName.ToLower = "id" Then
               If colList.Trim < " " Then
                  colList = col.ColumnName
               Else
                  colList += ", " & col.ColumnName
               End If
               If valList.Trim < " " Then
                  valList = SetColumnValueString(col, row(col.ColumnName))
               Else
                  valList += ", " & SetColumnValueString(col, row(col.ColumnName).ToString)
               End If
            End If
         Else
            If colList.Trim < " " Then
               colList = col.ColumnName
            Else
               colList += ", " & col.ColumnName
            End If
            If valList.Trim < " " Then
               valList = SetColumnValueString(col, row(col.ColumnName))
            Else
               valList += ", " & SetColumnValueString(col, row(col.ColumnName).ToString)
            End If
         End If
      Next

      connection = Rae.Data.DataObjects.CreateConnection(Data.DataObjects.DataAccessTypes.SQL, Common.ConnectionString(True, False))

      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = "INSERT INTO [" & tbl.TableName & "] " & _
                        "(" & colList & ") VALUES(" & valList & ")"
      Try
         connection.Open()
         cmd.ExecuteNonQuery()
      Catch ex As Exception
         Throw ex
      Finally
         If connection IsNot Nothing Then If connection.State <> ConnectionState.Closed Then connection.Close()
      End Try

   End Sub

   Private Shared Function UpdateServerRow(ByVal tbl As DataTable, ByVal row As DataRow, ByVal filterStr As String) As Boolean

      Dim connection As IDbConnection
      Dim colVals As String = ""

      For Each col As DataColumn In tbl.Columns
         If tbl.TableName = "EquipmentOptions" Or tbl.TableName = "SpecialOptions" Then
            If Not col.ColumnName.ToLower = "id" Then
               If colVals.Trim < " " Then
                  colVals = col.ColumnName & " = " & SetColumnValueString(col, row(col.ColumnName))
               Else
                  colVals += ", " & col.ColumnName & " = " & SetColumnValueString(col, row(col.ColumnName).ToString)
               End If
            End If
         Else
            If colVals.Trim < " " Then
               colVals = col.ColumnName & " = " & SetColumnValueString(col, row(col.ColumnName))
            Else
               colVals += ", " & col.ColumnName & " = " & SetColumnValueString(col, row(col.ColumnName).ToString)
            End If
         End If
      Next

      connection = Rae.Data.DataObjects.CreateConnection(Data.DataObjects.DataAccessTypes.SQL, Common.ConnectionString(True, False))

      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = "UPDATE [" & tbl.TableName & "] " & _
                        "SET " & colVals & " " & _
                        "WHERE " & filterStr
      Try
         connection.Open()
         cmd.ExecuteNonQuery()
      Catch ex As Exception
         Throw ex
      Finally
         If connection IsNot Nothing Then If connection.State <> ConnectionState.Closed Then connection.Close()
      End Try

   End Function

   Private Shared Function SetColumnValueString(ByVal col As DataColumn, ByVal colValue As String) As String

      Dim valStr As String = ""
      Select Case col.DataType.Name
         Case "String", "Char"
            valStr += "'" & colValue.Replace("'", "''") & "'"
         Case "DateTime"
            If colValue = "" Then
               valStr = "NULL"
            Else
               valStr += "'" & colValue & "'"
            End If
         Case "Boolean"
            If colValue = "" Then
               valStr = 0
            ElseIf colValue.ToLower = "false" Then
               valStr = 0
            ElseIf colValue.ToLower = "true" Then
               valStr = 1
            Else
               valStr = colValue
            End If
         Case "Single", "Byte", "Decimal", "Double", "Int16", "Int32", "Int64", "SByte", "Single", "UInt16", "UInt32", "UInt64"
            If colValue = "" Then
               valStr = "NULL"
            Else
               valStr += colValue
            End If
      End Select
      Return valStr

   End Function

   Private Shared Sub DeleteCheckoutRevisionLevels(ByVal projectId As String)

      Dim connection As IDbConnection
      connection = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
      connection.Open()

      Dim filterStr As String = "projectid = '" & projectId & "'"
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = "SELECT itemid FROM CheckoutRevisionLevels " & _
                        "WHERE itemtable = 'Equipment' AND projectid = '" & projectId & "'"

      Dim rdr As IDataReader
      Try
         rdr = cmd.ExecuteReader
         While rdr.Read
            filterStr += " OR projectid = '" & rdr("itemid") & "'"
         End While
      Catch ex As Exception
         ' no equipment items...
      Finally
         If rdr IsNot Nothing Then If Not rdr.IsClosed Then rdr.Close()
      End Try

      cmd.CommandText = "DELETE FROM [CheckoutRevisionLevels] " & _
                        "WHERE " & filterStr
      Try
         cmd.ExecuteNonQuery()
      Catch ex As Exception
         Throw ex
      Finally
         If connection IsNot Nothing Then If connection.State <> ConnectionState.Closed Then connection.Close()
      End Try

   End Sub

   Private Shared Function GetServerChanges(ByVal projectID As String) As DataTable

      Dim revCheckedOut As Single = 0
      Dim filterStr As String = ""
      Dim sortStr As String = ""
      Dim curRev As Single = 0
      ' Compare project to server version
      Dim changedDS As New DataSet
      changedDS.Tables.Add("Changes")
      changedDS.Tables(0).Columns.Add(New System.Data.DataColumn("Action", GetType(System.String)))
      changedDS.Tables(0).Columns.Add(New System.Data.DataColumn("Item", GetType(System.String)))
      changedDS.Tables(0).Columns.Add(New System.Data.DataColumn("Item Type", GetType(System.String)))
      changedDS.Tables(0).Columns.Add(New System.Data.DataColumn("Change List", GetType(System.String)))
      Dim serverchangedDS As New DataSet
      Dim serverDA As DataSet = buildProjectDataset(projectID, True, True)

      Dim changeLog As New DataTable("ServerChanges")
      changeLog.Columns.Add("Project Name", GetType(System.String))
      changeLog.Columns.Add("Revision", GetType(System.Int32))
      changeLog.Columns.Add("Revision Description", GetType(System.String))
      changeLog.Columns.Add("Revision Date", GetType(System.DateTime))
      changeLog.Columns.Add("Revision By", GetType(System.String))

      revCheckedOut = getRevCheckedOut(projectID, projectID, "Projects")
      If revCheckedOut > -1 Then
         filterStr = "ProjectId = '" & projectID & "'"
         sortStr = "ProjectRevision DESC"
         Dim rs() As DataRow = serverDA.Tables("Projects").Select(filterStr, sortStr)
         For Each r As DataRow In rs
            If r("ProjectRevision") > revCheckedOut Then
               Dim cr As System.Data.DataRow = changeLog.NewRow()
               cr("Project Name") = r("Name")
               cr("Revision") = r("ProjectRevision")
               cr("Revision Description") = r("Description")
               cr("Revision Date") = r("RevisionDate")
               cr("Revision By") = r("OpenedBy")
               changeLog.Rows.Add(cr)
            End If
         Next
      End If

      Return changeLog

   End Function

   Private Shared Function GetCheckOutChanges(ByVal projectID As String) As DataTable

      Dim revCheckedOut As Single = 0
      Dim filterStr As String = ""
      Dim sortStr As String = ""
      Dim curRev As Single = 0
      ' Compare project to server version
      Dim changedDS As New DataSet
      changedDS.Tables.Add("Changes")
      changedDS.Tables(0).Columns.Add(New System.Data.DataColumn("Action", GetType(System.String)))
      changedDS.Tables(0).Columns.Add(New System.Data.DataColumn("Item", GetType(System.String)))
      changedDS.Tables(0).Columns.Add(New System.Data.DataColumn("Item Type", GetType(System.String)))
      changedDS.Tables(0).Columns.Add(New System.Data.DataColumn("Change List", GetType(System.String)))
      Dim checkoutchangedDS As New DataSet
      Dim checkoutDA As DataSet = buildProjectDataset(projectID, False, True)
      revCheckedOut = getRevCheckedOut(projectID, projectID, "Projects")
      If revCheckedOut > -1 Then
         filterStr = "ProjectId = '" & projectID & "'"
         sortStr = "ProjectRevision DESC"
         Dim rs() As DataRow = checkoutchangedDS.Tables("Projects").Select(filterStr, sortStr)
         For Each r As DataRow In rs
            If r("ProjectRevision") > revCheckedOut Then

            End If
         Next
      End If

   End Function

   Public Shared Function CheckinProject(ByVal projectID As String) As DataTable

      Dim revCheckedOut As Single = 0
      Dim filterStr As String = ""
      Dim sortStr As String = ""
      Dim curRev As Single = 0
      ' Compare project to server version
      Dim changedDS As New DataSet
      Dim serverchangedDS As New DataSet
      Dim checkoutchangedDS As New DataSet
      Dim checkoutDA As DataSet = buildProjectDataset(projectID, False, True)
      Dim serverDA As DataSet = buildProjectDataset(projectID, True, True)

      For Each tbl As DataTable In checkoutDA.Tables
         For Each row As DataRow In tbl.Rows
            filterStr = ""
            ' check individual equipment, process, option item records
            If tbl.TableName = "Processes" Then
               curRev = -2
            ElseIf tbl.TableName = "SpecialOptions" Then
               curRev = row("revision")
               revCheckedOut = getRevCheckedOut(row("EquipmentId"), row("Code"), tbl.TableName)
               filterStr = "EquipmentId = '" & row("EquipmentId") & "' AND Code = '" & row("Code") & "' AND Revision = " & row("Revision")
            ElseIf tbl.TableName = "EquipmentOptions" Then
               curRev = row("revision")
               revCheckedOut = getRevCheckedOut(row("EquipmentId"), row("PricingId"), tbl.TableName)
               filterStr = "EquipmentId = '" & row("EquipmentId") & "' AND PricingId = " & row("PricingId") & " AND Revision = " & row("Revision")
            ElseIf tbl.TableName = "Projects" Then
               curRev = row("ProjectRevision")
               revCheckedOut = getRevCheckedOut(row("ProjectId"), row("ProjectId"), tbl.TableName)
               filterStr = "ProjectId = '" & row("ProjectId") & "' AND ProjectRevision = " & row("ProjectRevision")
            ElseIf tbl.Columns("ProcessId") IsNot Nothing Then
               curRev = row("revision")
               revCheckedOut = getRevCheckedOut(projectID, row("ProcessId"), tbl.TableName)
               filterStr = "ProcessId = '" & row("ProcessId") & "' AND Revision = " & row("Revision") '"ProjectId = '" & row("ProjectId") & "' AND 
            ElseIf tbl.Columns("EquipmentId") IsNot Nothing Then
               curRev = row("revision")
               revCheckedOut = getRevCheckedOut(projectID, row("EquipmentId"), tbl.TableName)
               filterStr = "EquipmentId = '" & row("EquipmentId") & "' AND Revision = " & row("Revision") '"ProjectId = '" & projectID & "' AND 
            End If

            If curRev > -2 Then
               If revCheckedOut = -1 Then
                  ' this is a new item added to server table after
                  ' the project was checked out
                  If changedDS.Tables(tbl.TableName) Is Nothing Then changedDS.Tables.Add(tbl.TableName)
                  changedDS.Tables(tbl.TableName).Rows.Add(row)

               ElseIf revCheckedOut > curRev Then
                  ' this is revision previous to one checked out
                  ' do nothing

               ElseIf curRev > revCheckedOut Then
                  ' this s a new revision added to server table after
                  ' the project was checked out - compare to previous
                  ' revision and log changes

                  ' this is the same revision in both tables - compare
                  ' to see if anything has changed
                  For Each col As DataColumn In tbl.Columns

                     If tbl.TableName = "EquipmentOptions" AndAlso col.ColumnName = "Id" Or tbl.TableName = "SpecialOptions" AndAlso col.ColumnName = "Id" Then
                        ' do not compare id columns in option tables

                     Else

                        Dim ub As Integer = -1
                        filterStr = filterStr.Replace("evision = ", "evision < ")
                        Dim rs() As DataRow = serverDA.Tables(tbl.TableName).Select(filterStr)
                        For Each r As DataRow In rs

                           ub += 1
                           If ub = rs.GetUpperBound(0) Then

                              'Dim newrow As System.Data.DataRow = changedDS.Tables(0).NewRow
                              'newrow("Action") = "Changed"
                              'newrow("Item") = col.ColumnName
                              'newrow("Item Type") = col.Table.TableName

                              If IsDBNull(r(col.ColumnName)) Then
                                 If IsDBNull(row(col.ColumnName)) Then
                                    ' not changed
                                 Else
                                    ' changed to dbnull from...
                                    MessageBox.Show(col.ColumnName & vbCrLf & "---------------------------------------------" & vbCrLf & "Was: " & r(col.ColumnName) & vbCrLf & "Is: " & row(col.ColumnName))
                                 End If

                              ElseIf IsDBNull(row(col.ColumnName)) Then
                                 ' changed from dbnull to...
                                 MessageBox.Show(col.ColumnName & vbCrLf & "---------------------------------------------" & vbCrLf & "Was: " & r(col.ColumnName) & vbCrLf & "Is: " & row(col.ColumnName))

                              ElseIf r(col.ColumnName) = row(col.ColumnName) Then
                                 ' not changed

                              Else
                                 ' changed from...
                                 MessageBox.Show(col.ColumnName & vbCrLf & "---------------------------------------------" & vbCrLf & "Was: " & r(col.ColumnName) & vbCrLf & "Is: " & row(col.ColumnName))

                              End If

                           End If

                        Next

                     End If

                  Next

                  ' just adding new row entry for now
                  'If changedDS.Tables(tbl.TableName) Is Nothing Then changedDS.Tables.Add(tbl.TableName)
                  'changedDS.Tables(tbl.TableName).Rows.Add(row)

               Else
                  ' this is the same revision in both tables - compare
                  ' to see if anything has changed
                  For Each col As DataColumn In tbl.Columns

                     If tbl.TableName = "EquipmentOptions" AndAlso col.ColumnName = "Id" Or tbl.TableName = "SpecialOptions" AndAlso col.ColumnName = "Id" Then
                        ' do not compare id columns in option tables

                     Else

                        For Each r As DataRow In checkoutDA.Tables(tbl.TableName).Select(filterStr)

                           'Dim newrow As System.Data.DataRow = changedDS.Tables(0).NewRow
                           'newrow("Action") = "Changed"
                           'newrow("Item") = col.ColumnName
                           'newrow("Item Type") = col.Table.TableName

                           If IsDBNull(r(col.ColumnName)) Then
                              If IsDBNull(row(col.ColumnName)) Then
                                 ' not changed
                              Else
                                 ' changed to dbnull from...
                                 MessageBox.Show(col.ColumnName & vbCrLf & "---------------------------------------------" & vbCrLf & "Was: " & row(col.ColumnName) & vbCrLf & "Is: " & r(col.ColumnName))
                              End If

                           ElseIf IsDBNull(row(col.ColumnName)) Then
                              ' changed from dbnull to...
                              MessageBox.Show(col.ColumnName & vbCrLf & "---------------------------------------------" & vbCrLf & "Was: " & row(col.ColumnName) & vbCrLf & "Is: " & r(col.ColumnName))

                           ElseIf r(col.ColumnName) = row(col.ColumnName) Then
                              ' not changed

                           Else
                              ' changed from...
                              MessageBox.Show(col.ColumnName & vbCrLf & "---------------------------------------------" & vbCrLf & "Was: " & row(col.ColumnName) & vbCrLf & "Is: " & r(col.ColumnName))

                           End If

                        Next

                     End If

                  Next
               End If
            End If
         Next

         ' see if this table was originally checked out
         ' to determine whether it was deleted in the 
         ' checked out table or added since the check out
         ' in the server table
         If wasTableCheckedOut(projectID, tbl.TableName) Then
            ' this was originally checked out and now has
            ' been removed from the checked out data
            If changedDS.Tables(tbl.TableName) Is Nothing Then changedDS.Tables.Add(tbl.Copy)
         Else
            ' this was not checked out - it was added to
            ' the server after the project was checked out
            If changedDS.Tables(tbl.TableName) Is Nothing Then changedDS.Tables.Add(tbl.Copy)
         End If

      Next
      Exit Function
      ' List changes

      ' Let user decide which version to keep

      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim ds As New DataSet

      Dim connection1 As IDbConnection
      Dim da1 As IDbDataAdapter
      Dim dt1 As DataTable
      Dim ds1 As New DataSet
      Dim cb1 As DbCommandBuilder

      sql = "SELECT TOP 1 * " & _
            "FROM [Projects] " & _
            "WHERE [ProjectID] = '" & projectID & "' " & _
            "ORDER BY [ProjectRevision] DESC"

      connection = Common.CreateConnection(Common.ProjectsDbPath)
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd)

      da.TableMappings.Add("Table", "Projects")

      Try

         da.Fill(ds)
         ds.Tables(0).TableName = "Projects"

         If ds.Tables(0).Rows.Count > 0 Then

            ' copy to projectscheckedout table
            sql = "SELECT * FROM [Projects]"
            connection1 = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
            Dim cmd1 As IDbCommand = connection1.CreateCommand
            cmd1.CommandText = sql
            da1 = Common.CreateAdapter(cmd1)
            da1.TableMappings.Add("Table", "Projects")

            ds1 = ds.Copy
            dt1 = ds1.Tables(0)
            dt1.TableName = "Projects"
            If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
               cb1 = New OleDb.OleDbCommandBuilder(da1)
            ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
               cb1 = New SqlClient.SqlCommandBuilder(da1)
            End If

            Dim tbl As System.Data.DataTable = dt1.Copy
            If dt1.Rows.Count > 0 Then
               For Each row As System.Data.DataRow In tbl.Rows
                  Dim r As System.Data.DataRow = dt1.NewRow
                  For Each col As System.Data.DataColumn In dt1.Columns
                     If col.ColumnName.ToLower = "projectid" Then

                        r(col.ColumnName) = row(col.ColumnName)

                        ' revision equipment, options, special options
                        CheckoutEquipment(projectID)

                        ' revision processes
                        CheckoutProcesses(projectID)

                     Else
                        r(col.ColumnName) = row(col.ColumnName)

                     End If
                  Next
                  dt1.Rows.Add(r)
               Next
            End If

            da1.InsertCommand = cb1.GetInsertCommand()
            da1.Update(ds1)

         End If

         CheckoutCoolStuff(projectID)

      Catch ex As DataException
         Throw ex

      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()
         If connection1 IsNot Nothing AndAlso connection1.State <> System.Data.ConnectionState.Closed Then connection1.Close()
      End Try

   End Function

   Private Shared Sub CheckinEquipment(ByVal projectID As String)

      Dim connstr As String = Common.GetConnectionString(Common.ProjectsDbPath)
      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim ds As New DataSet

      Dim connection1 As IDbConnection
      Dim da1 As IDbDataAdapter
      Dim dt1 As DataTable
      Dim ds1 As New DataSet
      Dim cb1 As DbCommandBuilder

      sql = "select e.* from equipment e inner join (select equipmentid, max(revision) as rev from equipment where projectid = '" & projectID & "' group by equipmentid)t on t.equipmentid = e.equipmentid and t.rev = e.revision"

      connection = Common.CreateConnection(Common.ProjectsDbPath)
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd)

      da.TableMappings.Add("Table", "Equipment")

      Try

         da.Fill(ds)

         If ds.Tables(0).Rows.Count > 0 Then

            ' copy to equipment table
            sql = "SELECT * FROM [Equipment]"
            connection1 = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
            Dim cmd1 As IDbCommand = connection1.CreateCommand
            cmd1.CommandText = sql
            da1 = Common.CreateAdapter(cmd1)
            da1.TableMappings.Add("Table", "Equipment")

            ds1 = ds.Copy
            If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
               cb1 = New OleDb.OleDbCommandBuilder(da1)
            ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
               cb1 = New SqlClient.SqlCommandBuilder(da1)
            End If
            dt1 = ds1.Tables(0)
            dt1.TableName = "Equipment"

            Dim tbl As System.Data.DataTable = dt1.Copy
            For Each row As System.Data.DataRow In tbl.Rows
               Dim r As System.Data.DataRow = dt1.NewRow
               For Each col As System.Data.DataColumn In dt1.Columns
                  If col.ColumnName.ToLower = "equipmentid" Then
                     r(col.ColumnName) = row(col.ColumnName)
                     CheckoutIndividualEquipment(row(col.ColumnName), row("TypeTableName"))
                     CheckoutEquipmentOptions(row(col.ColumnName), row("Revision"))
                     CheckoutEquipmentSpecialOptions(row(col.ColumnName), row("Revision"))
                  Else
                     r(col.ColumnName) = row(col.ColumnName)
                  End If
               Next
               dt1.Rows.Add(r)
            Next

            da1.InsertCommand = cb1.GetInsertCommand()
            da1.Update(ds1)

         End If

      Catch ex As DataException
         Throw ex

      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()
         If connection1 IsNot Nothing AndAlso connection1.State <> System.Data.ConnectionState.Closed Then connection1.Close()
      End Try

   End Sub

   Private Shared Sub CheckinIndividualEquipment(ByVal equipmentID As String, ByVal equipmentTable As String)

      Dim connstr As String = Common.GetConnectionString(Common.ProjectsDbPath)
      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim ds As New DataSet

      Dim connection1 As IDbConnection
      Dim da1 As IDbDataAdapter
      Dim dt1 As DataTable
      Dim ds1 As New DataSet
      Dim cb1 As DbCommandBuilder

      sql = "SELECT TOP 1 * " & _
            "FROM [" & equipmentTable & "] " & _
            "WHERE [EquipmentID] = '" & equipmentID & "' " & _
            "ORDER BY [Revision] DESC"

      connection = Common.CreateConnection(Common.ProjectsDbPath)
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd)

      da.TableMappings.Add("Table", equipmentTable)

      Try

         da.Fill(ds)
         If ds.Tables(0).Rows.Count > 0 Then

            ' copy to individual equipment table
            sql = "SELECT * FROM [" & equipmentTable & "]"
            connection1 = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
            Dim cmd1 As IDbCommand = connection1.CreateCommand
            cmd1.CommandText = sql
            da1 = Common.CreateAdapter(cmd1)
            da1.TableMappings.Add("Table", equipmentTable)

            ds1 = ds.Copy
            dt1 = ds1.Tables(0)
            dt1.TableName = equipmentTable
            If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
               cb1 = New OleDb.OleDbCommandBuilder(da1)
            ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
               cb1 = New SqlClient.SqlCommandBuilder(da1)
            End If

            Dim tbl As System.Data.DataTable = dt1.Copy()
            For Each row As System.Data.DataRow In tbl.Rows
               Dim r As System.Data.DataRow = dt1.NewRow
               For Each col As System.Data.DataColumn In dt1.Columns
                  r(col.ColumnName) = row(col.ColumnName)
               Next
               dt1.Rows.Add(r)
            Next

            da1.InsertCommand = cb1.GetInsertCommand()
            da1.Update(ds1)

         End If


      Catch ex As DataException
         Throw ex

      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()
         If connection1 IsNot Nothing AndAlso connection1.State <> System.Data.ConnectionState.Closed Then connection1.Close()
      End Try

   End Sub

   Private Shared Sub CheckinEquipmentOptions(ByVal equipmentID As String, ByVal equipmentRevision As Single)

      Dim connstr As String = Common.GetConnectionString(Common.ProjectsDbPath)
      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim ds As New DataSet

      Dim connection1 As IDbConnection
      Dim da1 As IDbDataAdapter
      Dim dt1 As DataTable
      Dim ds1 As New DataSet
      Dim cb1 As DbCommandBuilder

      sql = "SELECT * " & _
            "FROM [EquipmentOptions] " & _
            "WHERE [EquipmentID] = '" & equipmentID & "' " & _
            "AND [Revision] = " & equipmentRevision

      connection = Common.CreateConnection(Common.ProjectsDbPath)
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd)

      da.TableMappings.Add("Table", "EquipmentOptions")

      Try

         da.Fill(ds)
         If ds.Tables(0).Rows.Count > 0 Then

            ' copy to equipmentoptions table
            sql = "SELECT * FROM [EquipmentOptions]"
            connection1 = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
            Dim cmd1 As IDbCommand = connection1.CreateCommand
            cmd1.CommandText = sql
            da1 = Common.CreateAdapter(cmd1)
            da1.TableMappings.Add("Table", "EquipmentOptions")

            ds1 = ds.Copy
            dt1 = ds1.Tables(0)
            dt1.TableName = "EquipmentOptions"
            If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
               cb1 = New OleDb.OleDbCommandBuilder(da1)
            ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
               cb1 = New SqlClient.SqlCommandBuilder(da1)
            End If

            Dim tbl As System.Data.DataTable = dt1.Copy
            For Each row As System.Data.DataRow In tbl.Rows
               Dim r As System.Data.DataRow = dt1.NewRow
               For Each col As System.Data.DataColumn In dt1.Columns
                  If col.ColumnName.ToLower <> "id" Then
                     r(col.ColumnName) = row(col.ColumnName)
                  End If
               Next
               dt1.Rows.Add(r)
            Next

            da1.InsertCommand = cb1.GetInsertCommand()
            da1.Update(ds1)

         End If


      Catch ex As DataException
         Throw ex

      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()
         If connection1 IsNot Nothing AndAlso connection1.State <> System.Data.ConnectionState.Closed Then connection1.Close()
      End Try

   End Sub

   Private Shared Function CheckinEquipmentSpecialOptions(ByVal equipmentID As String, ByVal equipmentRevision As Single)

      Dim connstr As String = Common.GetConnectionString(Common.ProjectsDbPath)
      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim ds As New DataSet

      Dim connection1 As IDbConnection
      Dim da1 As IDbDataAdapter
      Dim dt1 As DataTable
      Dim ds1 As New DataSet
      Dim cb1 As DbCommandBuilder

      sql = "SELECT * " & _
            "FROM [SpecialOptions] " & _
            "WHERE [EquipmentID] = '" & equipmentID & "' " & _
            "AND [Revision] = " & equipmentRevision

      connection = Common.CreateConnection(Common.ProjectsDbPath)
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd)

      da.TableMappings.Add("Table", "SpecialOptions")

      Try

         da.Fill(ds)
         If ds.Tables(0).Rows.Count > 0 Then

            ' copy to specialoptions table
            sql = "SELECT * FROM [SpecialOptions]"
            connection1 = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
            Dim cmd1 As IDbCommand = connection1.CreateCommand
            cmd1.CommandText = sql
            da1 = Common.CreateAdapter(cmd1)
            da1.TableMappings.Add("Table", "SpecialOptions")

            ds1 = ds.Copy
            dt1 = ds1.Tables(0)
            dt1.TableName = "SpecialOptions"
            If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
               cb1 = New OleDb.OleDbCommandBuilder(da1)
            ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
               cb1 = New SqlClient.SqlCommandBuilder(da1)
            End If

            Dim tbl As System.Data.DataTable = dt1.Copy
            For Each row As System.Data.DataRow In tbl.Rows
               Dim r As System.Data.DataRow = dt1.NewRow
               For Each col As System.Data.DataColumn In dt1.Columns
                  If col.ColumnName.ToLower <> "id" Then
                     r(col.ColumnName) = row(col.ColumnName)
                  End If
               Next
               dt1.Rows.Add(r)
            Next

            da1.InsertCommand = cb1.GetInsertCommand()
            da1.Update(ds1)

         End If

      Catch ex As DataException
         Throw ex

      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()
         If connection1 IsNot Nothing AndAlso connection1.State <> System.Data.ConnectionState.Closed Then connection1.Close()
      End Try

   End Function

   Private Shared Sub CheckinProcesses(ByVal projectID As String)

      Dim connstr As String = Common.GetConnectionString(Common.ProjectsDbPath)
      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim ds As New DataSet

      Dim connection1 As IDbConnection
      Dim da1 As IDbDataAdapter
      Dim dt1 As DataTable
      Dim ds1 As New DataSet
      Dim cb1 As DbCommandBuilder

      sql = "SELECT * " & _
            "FROM [Processes] " & _
            "WHERE [ProjectID] = '" & projectID & "'"

      connection = Common.CreateConnection(Common.ProjectsDbPath)
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd)

      da.TableMappings.Add("Table", "Processes")

      Try

         da.Fill(ds)
         If ds.Tables(0).Rows.Count > 0 Then

            ' copy to processes table
            sql = "SELECT * FROM [Processes]"
            connection1 = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
            Dim cmd1 As IDbCommand = connection1.CreateCommand
            cmd1.CommandText = sql
            da1 = Common.CreateAdapter(cmd1)
            da1.TableMappings.Add("Table", "Processes")

            ds1 = ds.Copy
            dt1 = ds1.Tables(0)
            dt1.TableName = "Processes"
            If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
               cb1 = New OleDb.OleDbCommandBuilder(da1)
            ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
               cb1 = New SqlClient.SqlCommandBuilder(da1)
            End If

            Dim tbl As System.Data.DataTable = dt1.Copy
            For Each row As System.Data.DataRow In tbl.Rows
               Dim r As System.Data.DataRow = dt1.NewRow
               For Each col As System.Data.DataColumn In dt1.Columns
                  If col.ColumnName.ToLower = "id" Then
                     r(col.ColumnName) = row(col.ColumnName)
                     CheckoutIndividualProcess(row("ProjectID"), row(col.ColumnName), row("ProcessTableName"))
                  Else
                     r(col.ColumnName) = row(col.ColumnName)
                  End If
               Next
               dt1.Rows.Add(r)
            Next

            da1.InsertCommand = cb1.GetInsertCommand()
            da1.Update(ds1)

         End If

      Catch ex As DataException
         Throw ex

      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()
         If connection1 IsNot Nothing AndAlso connection1.State <> System.Data.ConnectionState.Closed Then connection1.Close()
      End Try

   End Sub

   Private Shared Sub CheckinIndividualProcess(ByVal processID As String, ByVal processTable As String)

      Dim connstr As String = Common.GetConnectionString(Common.ProjectsDbPath)
      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim ds As New DataSet

      Dim connection1 As IDbConnection
      Dim da1 As IDbDataAdapter
      Dim dt1 As DataTable
      Dim ds1 As New DataSet
      Dim cb1 As DbCommandBuilder

      sql = "SELECT TOP 1 * " & _
            "FROM [" & processTable & "] " & _
            "WHERE [ProcessID] = '" & processID & "' " & _
            "ORDER BY [Revision] DESC"

      connection = Common.CreateConnection(Common.ProjectsDbPath)
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd)

      da.TableMappings.Add("Table", processTable)

      Try

         da.Fill(ds)
         If ds.Tables(0).Rows.Count > 0 Then

            ' copy to individual process table
            sql = "SELECT * FROM [" & processTable & "]"
            connection1 = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
            Dim cmd1 As IDbCommand = connection1.CreateCommand
            cmd1.CommandText = sql
            da1 = Common.CreateAdapter(cmd1)
            da1.TableMappings.Add("Table", processTable)

            ds1 = ds.Copy
            dt1 = ds1.Tables(0)
            dt1.TableName = processTable
            If Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
               cb1 = New OleDb.OleDbCommandBuilder(da1)
            ElseIf Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
               cb1 = New SqlClient.SqlCommandBuilder(da1)
            End If

            Dim tbl As System.Data.DataTable = dt1.Copy()
            For Each row As System.Data.DataRow In tbl.Rows
               Dim r As System.Data.DataRow = dt1.NewRow
               For Each col As System.Data.DataColumn In dt1.Columns
                  r(col.ColumnName) = row(col.ColumnName)
               Next
               dt1.Rows.Add(r)
            Next

            da1.InsertCommand = cb1.GetInsertCommand()
            da1.Update(ds1)

         End If

      Catch ex As DataException
         Throw ex

      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()
         If connection1 IsNot Nothing AndAlso connection1.State <> System.Data.ConnectionState.Closed Then connection1.Close()

      End Try

   End Sub

   Private Shared Function CheckinCoolStuff(ByVal projectid As String) As Integer

      'Dim x As CoolStuff.CoolStuffCommon = New CoolStuff.CoolStuffCommon
      'x.CoolStuffCopyProjectBoxLoad(projectid, newprojectid)

   End Function

   Private Shared Function CompareData(ByVal checkedOutData As DataSet, ByVal serverData As DataSet) As DataTable

      For Each tbl As DataTable In checkedOutData.Tables
         ' make sure table exists in server dataset
         If serverData.Tables(tbl.TableName) IsNot Nothing Then
            For Each row As DataRow In tbl.Rows

            Next
         Else
            ' table exists in checked out dataset but not
            ' in server dataset

         End If
      Next

   End Function

#End Region


#Region "Build Project Dataset"

   Private Shared Function buildProjectDataset(ByVal projectID As String, ByVal serverData As Boolean, Optional ByVal allRevisions As Boolean = False, Optional ByVal isImport As Boolean = False) As DataSet

      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim ds As New DataSet

      If Not allRevisions Then
         sql = "SELECT TOP 1 * " & _
               "FROM [Projects] " & _
               "WHERE [ProjectID] = '" & projectID & "' " & _
               "ORDER BY [ProjectRevision] DESC"
      Else
         sql = "SELECT * " & _
               "FROM [Projects] " & _
               "WHERE [ProjectID] = '" & projectID & "'"
      End If

      If isImport Then
         connection = New OleDb.OleDbConnection("Provider=" & Common.DbProvider & ";Data Source=" & Common.ProjectsDbPath & ";")
      ElseIf serverData Then
         connection = Rae.Data.DataObjects.CreateConnection(Data.DataObjects.DataAccessTypes.SQL, Common.ConnectionString(True, False))
      Else
         connection = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
      End If
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd, isImport)
      da.Fill(ds)
      ds.Tables(0).TableName = "Projects"
      Try

         ' add equipment to dataset
         ds = addEquipment(projectID, ds, serverData, allRevisions, isImport)

         ' add processes
         ds = addProcesses(projectID, ds, serverData, allRevisions, isImport)

         'addCoolStuff(projectID, ds, allRevisions)

      Catch ex As DataException
         Throw ex

      End Try

      Return ds

   End Function

   Private Shared Function addEquipment(ByVal projectID As String, ByVal ds As DataSet, ByVal serverData As Boolean, Optional ByVal allRevisions As Boolean = False, Optional ByVal isImport As Boolean = False) As DataSet

      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim ds1 As New DataSet

      If Not allRevisions Then
         sql = "select e.* from equipment e inner join (select equipmentid, max(revision) as rev from equipment where projectid = '" & projectID & "' group by equipmentid)t on t.equipmentid = e.equipmentid and t.rev = e.revision"
      Else
         sql = "SELECT * " & _
               "FROM [Equipment] " & _
               "WHERE [ProjectID] = '" & projectID & "'"
      End If
      If isImport Then
         connection = New OleDb.OleDbConnection("Provider=" & Common.DbProvider & ";Data Source=" & Common.ProjectsDbPath & ";")
      ElseIf serverData Then
         connection = Rae.Data.DataObjects.CreateConnection(Data.DataObjects.DataAccessTypes.SQL, Common.ConnectionString(True, False))
      Else
         connection = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
      End If
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd, isImport)
      da.Fill(ds1)
      ds1.Tables(0).TableName = "Equipment"
      ds.Tables.Add(ds1.Tables(0).Copy)
      Try

         If ds1.Tables(0).Rows.Count > 0 Then
            For Each r As DataRow In ds1.Tables(0).Rows
               ds = addIndividualEquipment(r("EquipmentId"), r("TypeTableName"), ds, serverData, allRevisions, isImport)
            Next
         End If

      Catch ex As DataException
         Throw ex

      End Try

      Return ds

   End Function

   Private Shared Function addIndividualEquipment(ByVal equipmentID As String, ByVal equipmentTable As String, ByVal ds As DataSet, ByVal serverData As Boolean, Optional ByVal allRevisions As Boolean = False, Optional ByVal isImport As Boolean = False) As DataSet

      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim ds1 As New DataSet

      If Not allRevisions Then
         sql = "SELECT TOP 1 * " & _
         "FROM [" & equipmentTable & "] " & _
         "WHERE [EquipmentID] = '" & equipmentID & "' " & _
         "ORDER BY [Revision] DESC"
      Else
         sql = "SELECT * " & _
                  "FROM [" & equipmentTable & "] " & _
                  "WHERE [EquipmentID] = '" & equipmentID & "'"
      End If

      If isImport Then
         connection = New OleDb.OleDbConnection("Provider=" & Common.DbProvider & ";Data Source=" & Common.ProjectsDbPath & ";")
      ElseIf serverData Then
         connection = Rae.Data.DataObjects.CreateConnection(Data.DataObjects.DataAccessTypes.SQL, Common.ConnectionString(True, False))
      Else
         connection = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
      End If
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd, isImport)
      da.Fill(ds1)
      ds1.Tables(0).TableName = equipmentTable

      Try

         If ds1.Tables(0).Rows.Count > 0 Then
            If ds.Tables(equipmentTable) Is Nothing Then
               ds.Tables.Add(ds1.Tables(0).Copy)
            Else
               ' update existing table with new rows...
               Dim tbl As System.Data.DataTable = ds1.Tables(equipmentTable).Copy
               For Each row As System.Data.DataRow In tbl.Rows
                  Dim r As System.Data.DataRow = ds.Tables(equipmentTable).NewRow
                  For Each col As System.Data.DataColumn In ds.Tables(equipmentTable).Columns
                     r(col.ColumnName) = row(col.ColumnName)
                  Next
                  ds.Tables(equipmentTable).Rows.Add(r)
               Next
            End If
         Else
            Return ds
         End If

         For Each r As DataRow In ds1.Tables(equipmentTable).Rows

            ' add options to dataset
            ds = addEquipmentOptions(r("EquipmentId"), r("Revision"), ds, serverData, isImport)

            ' add special options to dataset
            ds = addEquipmentSpecialOptions(r("EquipmentId"), r("Revision"), ds, serverData, isImport)

         Next

      Catch ex As DataException
         Throw ex

      End Try

      Return ds

   End Function

   Private Shared Function addEquipmentOptions(ByVal equipmentID As String, ByVal equipmentRevision As Single, ByVal ds As DataSet, ByVal serverData As Boolean, Optional ByVal isImport As Boolean = False) As DataSet

      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim ds1 As New DataSet

      sql = "SELECT * " & _
            "FROM [EquipmentOptions] " & _
            "WHERE [EquipmentID] = '" & equipmentID & "' " & _
            "AND [Revision] = " & equipmentRevision

      If isImport Then
         connection = New OleDb.OleDbConnection("Provider=" & Common.DbProvider & ";Data Source=" & Common.ProjectsDbPath & ";")
      ElseIf serverData Then
         connection = Rae.Data.DataObjects.CreateConnection(Data.DataObjects.DataAccessTypes.SQL, Common.ConnectionString(True, False))
      Else
         connection = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
      End If
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd, isImport)
      da.Fill(ds1)
      ds1.Tables(0).TableName = "EquipmentOptions"

      Try

         If ds1.Tables(0).Rows.Count > 0 Then
            If ds.Tables("EquipmentOptions") Is Nothing Then
               ds.Tables.Add(ds1.Tables(0).Copy)
            Else
               ' update existing table with new rows...
               Dim tbl As System.Data.DataTable = ds1.Tables("EquipmentOptions").Copy
               For Each row As System.Data.DataRow In tbl.Rows
                  Dim r As System.Data.DataRow = ds.Tables("EquipmentOptions").NewRow
                  For Each col As System.Data.DataColumn In ds.Tables("EquipmentOptions").Columns
                     r(col.ColumnName) = row(col.ColumnName)
                  Next
                  ds.Tables("EquipmentOptions").Rows.Add(r)
               Next
            End If
         Else
            Return ds
         End If

      Catch ex As DataException
         Throw ex

      End Try

      Return ds

   End Function

   Private Shared Function addEquipmentSpecialOptions(ByVal equipmentID As String, ByVal equipmentRevision As Single, ByVal ds As DataSet, ByVal serverData As Boolean, Optional ByVal isImport As Boolean = False) As DataSet

      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim ds1 As New DataSet

      sql = "SELECT * " & _
            "FROM [SpecialOptions] " & _
            "WHERE [EquipmentID] = '" & equipmentID & "' " & _
            "AND [Revision] = " & equipmentRevision

      If isImport Then
         connection = New OleDb.OleDbConnection("Provider=" & Common.DbProvider & ";Data Source=" & Common.ProjectsDbPath & ";")
      ElseIf serverData Then
         connection = Rae.Data.DataObjects.CreateConnection(Data.DataObjects.DataAccessTypes.SQL, Common.ConnectionString(True, False))
      Else
         connection = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
      End If
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd, isImport)
      da.Fill(ds1)
      ds1.Tables(0).TableName = "SpecialOptions"

      Try

         If ds1.Tables(0).Rows.Count > 0 Then
            If ds.Tables("SpecialOptions") Is Nothing Then
               ds.Tables.Add(ds1.Tables(0).Copy)
            Else
               ' update existing table with new rows...
               Dim tbl As System.Data.DataTable = ds1.Tables("SpecialOptions").Copy
               For Each row As System.Data.DataRow In tbl.Rows
                  Dim r As System.Data.DataRow = ds.Tables("SpecialOptions").NewRow
                  For Each col As System.Data.DataColumn In ds.Tables("SpecialOptions").Columns
                     r(col.ColumnName) = row(col.ColumnName)
                  Next
                  ds.Tables("SpecialOptions").Rows.Add(r)
               Next
            End If
         Else
            Return ds
         End If

      Catch ex As DataException
         Throw ex

      End Try

      Return ds

   End Function

   Private Shared Function addProcesses(ByVal projectID As String, ByVal ds As DataSet, ByVal serverData As Boolean, Optional ByVal allRevisions As Boolean = False, Optional ByVal isImport As Boolean = False) As DataSet

      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim ds1 As New DataSet

      sql = "SELECT * " & _
            "FROM [Processes] " & _
            "WHERE [ProjectID] = '" & projectID & "'"

      If isImport Then
         connection = New OleDb.OleDbConnection("Provider=" & Common.DbProvider & ";Data Source=" & Common.ProjectsDbPath & ";")
      ElseIf serverData Then
         connection = Rae.Data.DataObjects.CreateConnection(Data.DataObjects.DataAccessTypes.SQL, Common.ConnectionString(True, False))
      Else
         connection = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
      End If

      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd, isImport)
      da.Fill(ds1)
      ds1.Tables(0).TableName = "Processes"
      ds.Tables.Add(ds1.Tables(0).Copy)
      Try

         For Each r As DataRow In ds1.Tables(0).Rows

            ' add processes to dataset
            ds = addIndividualProcess(r("ID"), r("ProcessTableName"), ds, serverData, allRevisions, isImport)

         Next

      Catch ex As DataException
         Throw ex

      End Try

      Return ds

   End Function

   Private Shared Function addIndividualProcess(ByVal processID As String, ByVal processTable As String, ByVal ds As DataSet, ByVal serverData As Boolean, Optional ByVal allRevisions As Boolean = False, Optional ByVal isImport As Boolean = False) As DataSet

      Dim sql As String
      Dim connection As IDbConnection
      Dim da As IDbDataAdapter
      Dim ds1 As New DataSet

      If Not allRevisions Then
         sql = "SELECT TOP 1 * " & _
         "FROM [" & processTable & "] " & _
         "WHERE [ProcessID] = '" & processID & "' " & _
         "ORDER BY [Revision] DESC"
      Else
         sql = "SELECT * " & _
                  "FROM [" & processTable & "] " & _
                  "WHERE [ProcessID] = '" & processID & "'"
      End If
      If isImport Then
         connection = New OleDb.OleDbConnection("Provider=" & Common.DbProvider & ";Data Source=" & Common.ProjectsDbPath & ";")
      ElseIf serverData Then
         connection = Rae.Data.DataObjects.CreateConnection(Data.DataObjects.DataAccessTypes.SQL, Common.ConnectionString(True, False))
      Else
         connection = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
      End If
      Dim cmd As IDbCommand = connection.CreateCommand
      cmd.CommandText = sql
      da = Common.CreateAdapter(cmd, isImport)
      da.Fill(ds1)
      ds1.Tables(0).TableName = processTable

      Try

         If ds1.Tables(0).Rows.Count > 0 Then
            If ds.Tables(processTable) Is Nothing Then
               ds.Tables.Add(ds1.Tables(0).Copy)
            Else
               ' update existing table with new rows...
               Dim tbl As System.Data.DataTable = ds1.Tables(processTable).Copy
               For Each row As System.Data.DataRow In tbl.Rows
                  Dim r As System.Data.DataRow = ds.Tables(processTable).NewRow
                  For Each col As System.Data.DataColumn In ds.Tables(processTable).Columns
                     r(col.ColumnName) = row(col.ColumnName)
                  Next
                  ds.Tables(processTable).Rows.Add(r)
               Next
            End If
         Else
            Return ds
         End If

      Catch ex As DataException
         Throw ex

      End Try

      Return ds

   End Function

#End Region


#Region "Project Checkout State"

   Private Shared Sub writeCheckoutItemRevLevel(ByVal projID As String, ByVal itemId As String, ByVal tableName As String, ByVal itemRev As Single)

      'CheckoutRevisionLevels (TABLE)
      'projectid, itemid, itemtable, revision (FIELDS)
      Dim con As IDbConnection = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
      Try
         con.Open()
         Dim cmd As IDbCommand = con.CreateCommand
         cmd.CommandText = "INSERT INTO CheckoutRevisionLevels VALUES ('" & projID & "', '" & itemId & "', '" & tableName & "', " & itemRev & ")"
         cmd.ExecuteNonQuery()
      Catch ex As Exception
         Throw ex
      Finally
         If con IsNot Nothing AndAlso con.State <> ConnectionState.Closed Then con.Close()
      End Try

   End Sub

   Public Shared Function wasTableCheckedOut(ByVal projID As String, ByVal tableName As String) As Boolean

      'CheckoutRevisionLevels (TABLE)
      'projectid, itemid, itemtable, revision (FIELDS)
      Dim found As Boolean = False

      Dim con As IDbConnection = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
      Dim rdr As IDataReader
      Try
         con.Open()
         Dim cmd As IDbCommand = con.CreateCommand
         cmd.CommandText = "SELECT [itemid] from CheckoutRevisionLevels " & _
                           "WHERE projectid = '" & projID & "'" & _
                           "AND itemtable = '" & tableName & "'"
         rdr = cmd.ExecuteReader
         If rdr.Read Then found = True

      Catch ex As Exception
         Throw ex
      Finally
         If con IsNot Nothing AndAlso con.State <> ConnectionState.Closed Then con.Close()
         If rdr IsNot Nothing And Not rdr.IsClosed Then rdr.Close()
      End Try

      Return found
   End Function

   Private Shared Function wasItemCheckedOut(ByVal projID As String, ByVal itemid As String, ByVal tableName As String) As Boolean

      'CheckoutRevisionLevels (TABLE)
      'projectid, itemid, itemtable, revision (FIELDS)
      Dim found As Boolean = False

      Dim con As IDbConnection = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
      Dim rdr As IDataReader
      Try
         con.Open()
         Dim cmd As IDbCommand = con.CreateCommand
         cmd.CommandText = "SELECT [itemid] from CheckoutRevisionLevels " & _
                           "WHERE projectid = '" & projID & "'" & _
                           "AND itemid = '" & itemid & "'" & _
                           "AND tableName = '" & tableName & "'"
         rdr = cmd.ExecuteReader
         If rdr.Read Then found = True

      Catch ex As Exception
         Throw ex
      Finally
         If con IsNot Nothing AndAlso con.State <> ConnectionState.Closed Then con.Close()
         If rdr IsNot Nothing And Not rdr.IsClosed Then rdr.Close()
      End Try

      Return found
   End Function

   Private Shared Function getRevCheckedOut(ByVal projID As String, ByVal itemid As String, ByVal tableName As String) As Single
      Dim rev As Single = -1
      Dim con As IDbConnection = Common.CreateConnection(Common.ProjectsCheckedOutDbPath)
      Try
         con.Open()
         Dim cmd As IDbCommand = con.CreateCommand
         cmd.CommandText = "SELECT [revision] from CheckoutRevisionLevels " & _
                           "WHERE projectid = '" & projID & "'" & _
                           "AND itemid = '" & itemid & "'" & _
                           "AND itemtable = '" & tableName & "'"
         rev = cmd.ExecuteScalar
      Catch ex As Exception
         ' row now found
      Finally
         If con IsNot Nothing AndAlso con.State <> ConnectionState.Closed Then con.Close()
      End Try
      Return rev
   End Function

#End Region


#Region "Import Project"

   Public Shared Sub ImportAllProjects()

      Dim con As System.Data.OleDb.OleDbConnection
      Dim rdr As System.Data.OleDb.OleDbDataReader
      Dim cmd As System.Data.OleDb.OleDbCommand
      Dim ds As System.Data.DataSet
      con = New System.Data.OleDb.OleDbConnection("Provider=" & Rae.RaeSolutions.DataAccess.Common.DbProvider & ";Data Source=" & Rae.RaeSolutions.DataAccess.Common.ProjectsDbPath & ";")
      cmd = New System.Data.OleDb.OleDbCommand("SELECT t.ProjectID, t.Name, t.ProjectRevision " & _
                                               "FROM Projects as t " & _
                                               "INNER JOIN(" & _
                                               "Select ProjectID, max(ProjectRevision) as maxRev " & _
                                               "FROM Projects " & _
                                               "GROUP BY ProjectID" & _
                                               ") as m " & _
                                               "ON m.ProjectID = t.ProjectID " & _
                                               "AND m.maxRev = t.ProjectRevision", con)
      Try
         con.Open()
         rdr = cmd.ExecuteReader
         While rdr.Read
            ds = ProjectInfo.buildProjectDataset(rdr("ProjectId"), False, True, True)
            For Each tbl As DataTable In ds.Tables
               For Each r As DataRow In tbl.Rows
                  RevisionServerTable(rdr("ProjectId"), tbl)
               Next
            Next
         End While
         'Catch ex As Exception
         '   MessageBox.Show("Unable to import all projects:" & vbCrLf & ex.Message, "IMPORT FAILED", MessageBoxButtons.OK)
      Finally
         If rdr IsNot Nothing Then If Not rdr.IsClosed Then rdr.Close()
         If con IsNot Nothing Then If Not con.State.Closed Then con.Close()
      End Try

   End Sub

#End Region


End Class