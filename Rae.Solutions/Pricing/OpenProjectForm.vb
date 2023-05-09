Imports System
Imports System.Data
Imports Rae.RaeSolutions.DataAccess
Imports System.Windows.Forms
'aliases
Imports PT = Rae.RaeSolutions.DataAccess.Projects.Tables.ProjectsTable
Imports ProjectsDataAccess = Rae.RaeSolutions.DataAccess.Projects.ProjectsDataAccess
Imports System.Collections.generic


Public Class OpenProjectForm
   Inherits Form

#Region " Windows Form Designer generated code "

   Private formLoad As Boolean = True
    Public Custom Event SelectedIndexChanged As EventHandler
        AddHandler(value As EventHandler)

        End AddHandler
        RemoveHandler(value As EventHandler)

        End RemoveHandler
        RaiseEvent(sender As Object, e As EventArgs)

        End RaiseEvent
    End Event
    ' project checkout
    Public isCheckout As Boolean = False
   Private checkList_ As New List(Of String)
   Public ReadOnly Property CheckList() As List(Of String)
      Get
         Return checkList_
      End Get
   End Property

   ' project checkin
   Public isCheckin As Boolean = False
   Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents dataGrid As DataGridView
    Private checkinList_ As New List(Of String)
    Public ReadOnly Property CheckinList() As List(Of String)
        Get
            Return checkinList_
        End Get
    End Property

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents cancel As System.Windows.Forms.Button
    Friend WithEvents ok As System.Windows.Forms.Button
    Friend WithEvents instructions As System.Windows.Forms.Label
    Friend WithEvents projectLabel As System.Windows.Forms.Label
    Friend WithEvents searchLabel As System.Windows.Forms.Label
    Friend WithEvents search As System.Windows.Forms.TextBox
    Friend WithEvents projectContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents openMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents deleteMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents copyMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents projectName As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cancel = New System.Windows.Forms.Button()
        Me.ok = New System.Windows.Forms.Button()
        Me.instructions = New System.Windows.Forms.Label()
        Me.projectLabel = New System.Windows.Forms.Label()
        Me.projectName = New System.Windows.Forms.TextBox()
        Me.searchLabel = New System.Windows.Forms.Label()
        Me.search = New System.Windows.Forms.TextBox()
        Me.projectContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.openMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.copyMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.deleteMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.dataGrid = New System.Windows.Forms.DataGridView()
        Me.projectContextMenu.SuspendLayout()
        CType(Me.dataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cancel
        '
        Me.cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cancel.Location = New System.Drawing.Point(588, 389)
        Me.cancel.Name = "cancel"
        Me.cancel.Size = New System.Drawing.Size(75, 23)
        Me.cancel.TabIndex = 4
        Me.cancel.Text = "Cancel"
        '
        'ok
        '
        Me.ok.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ok.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ok.Location = New System.Drawing.Point(504, 389)
        Me.ok.Name = "ok"
        Me.ok.Size = New System.Drawing.Size(75, 23)
        Me.ok.TabIndex = 3
        Me.ok.Text = "Open"
        '
        'instructions
        '
        Me.instructions.Location = New System.Drawing.Point(16, 8)
        Me.instructions.Name = "instructions"
        Me.instructions.Size = New System.Drawing.Size(327, 23)
        Me.instructions.TabIndex = 11
        Me.instructions.Text = "Select the project to open"
        Me.instructions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'projectLabel
        '
        Me.projectLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.projectLabel.Location = New System.Drawing.Point(199, 359)
        Me.projectLabel.Name = "projectLabel"
        Me.projectLabel.Size = New System.Drawing.Size(87, 23)
        Me.projectLabel.TabIndex = 4
        Me.projectLabel.Text = "Project to open"
        Me.projectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'projectName
        '
        Me.projectName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.projectName.Location = New System.Drawing.Point(283, 359)
        Me.projectName.Name = "projectName"
        Me.projectName.Size = New System.Drawing.Size(381, 21)
        Me.projectName.TabIndex = 10
        Me.projectName.TabStop = False
        '
        'searchLabel
        '
        Me.searchLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.searchLabel.Location = New System.Drawing.Point(16, 359)
        Me.searchLabel.Name = "searchLabel"
        Me.searchLabel.Size = New System.Drawing.Size(47, 23)
        Me.searchLabel.TabIndex = 6
        Me.searchLabel.Text = "Search"
        Me.searchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'search
        '
        Me.search.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.search.Location = New System.Drawing.Point(60, 359)
        Me.search.Name = "search"
        Me.search.Size = New System.Drawing.Size(133, 21)
        Me.search.TabIndex = 2
        '
        'projectContextMenu
        '
        Me.projectContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.openMenu, Me.copyMenu, Me.deleteMenu})
        Me.projectContextMenu.Name = "ContextMenuStrip1"
        Me.projectContextMenu.Size = New System.Drawing.Size(148, 70)
        '
        'openMenu
        '
        Me.openMenu.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Open
        Me.openMenu.Name = "openMenu"
        Me.openMenu.Size = New System.Drawing.Size(147, 22)
        Me.openMenu.Text = "Open"
        '
        'copyMenu
        '
        Me.copyMenu.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Copy
        Me.copyMenu.Name = "copyMenu"
        Me.copyMenu.Size = New System.Drawing.Size(147, 22)
        Me.copyMenu.Text = "Copy Project"
        '
        'deleteMenu
        '
        Me.deleteMenu.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Delete
        Me.deleteMenu.Name = "deleteMenu"
        Me.deleteMenu.Size = New System.Drawing.Size(147, 22)
        Me.deleteMenu.Text = "Delete Project"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(532, 8)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(136, 17)
        Me.CheckBox1.TabIndex = 12
        Me.CheckBox1.Text = "Only Show My Projects"
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'dataGrid
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        Me.dataGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGrid.Location = New System.Drawing.Point(19, 34)
        Me.dataGrid.Name = "dataGrid"
        Me.dataGrid.ReadOnly = True
        Me.dataGrid.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dataGrid.Size = New System.Drawing.Size(644, 287)
        Me.dataGrid.TabIndex = 13
        Me.dataGrid.EnableHeadersVisualStyles = False
        Me.dataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue
        Me.dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dataGrid.MultiSelect = False
        '
        'OpenProjectForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(682, 423)
        Me.ContextMenuStrip = Me.projectContextMenu
        Me.Controls.Add(Me.dataGrid)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.search)
        Me.Controls.Add(Me.searchLabel)
        Me.Controls.Add(Me.projectName)
        Me.Controls.Add(Me.projectLabel)
        Me.Controls.Add(Me.instructions)
        Me.Controls.Add(Me.ok)
        Me.Controls.Add(Me.cancel)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(600, 0)
        Me.Name = "OpenProjectForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Open Project"
        Me.projectContextMenu.ResumeLayout(False)
        CType(Me.dataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


#Region " Event handlers"

    Private Sub Form_Load(ByVal sender As Object, ByVal e As EventArgs) _
   Handles MyBase.Load

        'If isCheckout Then
        '   Me.Text = "Checkout Project(s)"
        '   Me.instructions.Text = "Choose the projects you would like to checkout"
        '   Me.projectLabel.Visible = False
        '   Me.projectName.Visible = False
        '   Me.ok.Text = "Checkout"
        'ElseIf isCheckin Then
        '   Me.Text = "Checkin Project(s)"
        '   Me.instructions.Text = "Choose the projects you would like to checkin"
        '   Me.projectLabel.Visible = False
        '   Me.projectName.Visible = False
        '   Me.ok.Text = "Checkin"
        'Else
        'Me.CheckBox1.Visible = True ' only show my projects
        'Me.instructions.Text = "Select the project to open"
        'If Rae.RaeSolutions.DataAccess.Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
        '   If Common.isCheckedOut Then
        '      Me.instructions.Text = "Select the project to open (OFF-LINE)"
        '      Me.CheckBox1.Enabled = False
        '      If Common.IsConnected Then
        '         MessageBox.Show("You currently have at least one project checked out.  If you want to open a project from the server, all projects must be checked in.", "You Have Projects Checked Out", MessageBoxButtons.OK)
        '      End If
        '   End If
        'End If
        'End If

        Me.CheckBox1.Visible = True ' only show my projects
        Me.instructions.Text = "Select the project to open"

        populateProjects()
        chooseProject(0)

        formLoad = False

    End Sub


    Private Sub ok_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles ok.Click
        If isCheckout Then
            onCheckout()
        ElseIf isCheckin Then
            onCheckin()
        Else
            onOpen()
        End If
    End Sub


    Private Sub cancel_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles cancel.Click
        Close()
    End Sub

    ' Private Sub projects_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
    'Handles projects.KeyDown
    '     If e.KeyCode = Keys.Enter Then
    '         If Not isCheckout AndAlso Not isCheckin Then onOpen()
    '     End If
    ' End Sub

    ' Private Sub dataGrid_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) _
    'Handles dataGrid.MouseDown
    '      handles double click
    '     If e.Clicks = 2 Then
    '         If Not isCheckout AndAlso Not isCheckin Then onProjectsDoubleClick(e)
    '     End If

    '     gets row that cursor is over
    '     Dim selectedRow As Integer = Me.dataGrid.SelectedRows(e)

    '     If selectedRow > -1 Then
    '         selectProject(selectedRow)

    '         Dim project As String = dataGrid.Columns(PT.Name).CellText(selectedRow)
    '         initializeMenu(project)

    '         setProject(selectedRow)
    '     End If
    ' End Sub


    'Private Sub projects_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles projects.MouseUp

    '    If Not isCheckout AndAlso Not isCheckin Then Exit Sub

    '    'gets row that cursor is over
    '    Dim selectedRow As Integer = Me.projects.RowContaining(e.Y)
    '    If selectedRow > -1 Then
    '        selectProject(selectedRow)
    '        If projects.Columns(0).CellValue(selectedRow) Then
    '            If checkList_.IndexOf(projects.Columns(PT.ProjectId).CellText(selectedRow)) = -1 Then
    '                checkList_.Add(projects.Columns(PT.ProjectId).CellText(selectedRow))
    '            End If
    '        Else
    '            checkList_.Remove(projects.Columns(PT.ProjectId).CellText(selectedRow))
    '        End If
    '    End If

    'End Sub

    ' Private Sub projects_Resize(ByVal sender As Object, ByVal e As EventArgs) _
    'Handles projects.Resize
    '     Me.setColumnWidths()
    ' End Sub


    Private Sub search_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
   Handles search.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not isCheckout AndAlso Not isCheckin Then onOpen()
        ElseIf e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Up Then
            'projects.Focus()
        End If
    End Sub


    Private Sub search_TextChanged(ByVal sender As Object, ByVal e As EventArgs) _
   Handles search.TextChanged
        setTableView()
    End Sub


    Private Sub openMenu_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles openMenu.Click
        onOpen()
    End Sub


    Private Sub deleteMenu_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles deleteMenu.Click

        If Trim(Me.projectName.Tag) > " " Then

            ' make sure user really wants to delete project
            Dim shoulddel As New DoYouWantToDeleteForm
            shoulddel.DeleteWhat = DoYouWantToDeleteForm.deletetype.ProjectItem
            shoulddel.ShowDialog()
            If Not shoulddel.DeleteConfirmed Then Exit Sub
            shoulddel = Nothing

            ' delete project
            ProjectsDataAccess.Delete(Me.projectName.Tag)

            ' remove row from grid
            'For Each row As DataRow In Me.projects.DataSource.Rows
            '    If row(PT.ProjectId) = projectName.Tag Then
            '        Me.projects.DataSource.Rows.Remove(row)
            '        Exit For
            '    End If
            'Next
            'Me.projects.Refresh()

            ' reset project name text box
            Me.projectName.Text = ""
            Me.projectName.Tag = ""

        End If

    End Sub


    Private Sub copyMenu_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles copyMenu.Click
        ProjectInfo.CopyProject(Me.projectName.Tag)
        ' reset project name text box
        Me.projectName.Text = ""
        Me.projectName.Tag = ""

        populateProjects()
    End Sub

#End Region


    Private Sub initializeMenu(ByVal project As String)
        openMenu.Text = "Open Project: " & project
        deleteMenu.Text = "Delete Project: " & project
        copyMenu.Text = "Copy Project: " & project
    End Sub


    'Private Sub onProjectsDoubleClick(ByVal e As MouseEventArgs)
    '    Dim captionHeight As Integer = projects.CaptionHeight
    '    Dim columnHeight As Integer = projects.Splits(0).DisplayColumns(0).Height
    '    Dim totalHeaderHeight As Integer = captionHeight + columnHeight

    '    If e.Y > totalHeaderHeight Then
    '        If Not isCheckout AndAlso Not isCheckin Then onOpen()
    '    End If
    'End Sub

    Private Sub onOpen()
        ' validates selected project name
        If Me.projectName.Text.Trim.Length > 0 Then

            Me.Cursor = Cursors.WaitCursor

            openSelectedProject()

            Me.Cursor = Cursors.Default
        Else
            Ui.MessageBox.Show("A project must be selected before opening.",
            MessageBoxIcon.Warning)
        End If
    End Sub


    Private Sub populateProjects()
        Dim serverNotAvailableAndNothingCheckedOut As Boolean
        Dim table As DataTable
        If isCheckin Then
            table = ProjectsDataAccess.RetrieveAllCheckin()
        Else
            If isCheckout Then
                table = ProjectsDataAccess.RetrieveAll(isCheckout, AppInfo.User.username)
            Else
                If Constants.DATAACCESS_CONFIG = Data.DataObjects.DataAccessTypes.SQL _
            AndAlso Common.IsConnected Then
                    table = ProjectsDataAccess.RetrieveAll(isCheckout)
                ElseIf Constants.DATAACCESS_CONFIG = Data.DataObjects.DataAccessTypes.OleDb Then
                    table = ProjectsDataAccess.RetrieveAll(True)
                Else
                    serverNotAvailableAndNothingCheckedOut = True
                    'projects.DataSource = Nothing
                    Exit Sub
                End If
            End If
        End If
        table.DefaultView.Sort = "DateCreated DESC"
        If Me.CheckBox1.Checked Then
            table.DefaultView.RowFilter = "ProjectId like '" & AppInfo.User.username & "+*'"
        End If

        dataGrid.DataSource = table
        dataGrid.RowHeadersVisible = False
        dataGrid.Columns(PT.ProjectId).Visible = False
        dataGrid.Columns(0).Visible = False
        dataGrid.Columns(1).Width = 200
        dataGrid.Columns(2).Width = 200
        dataGrid.Columns(3).Width = 200
        dataGrid.Columns("Name").HeaderText = "Project Name"
        dataGrid.Columns("CreatedBy").HeaderText = "Created By"
        dataGrid.Columns("DateCreated").HeaderText = "Date Created"
        dataGrid.Columns(PT.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dataGrid.Columns("DateCreated").DefaultCellStyle.Format = "d"
        'projects.DataSource = table


        'formatProjects()



    End Sub


    Private Sub chooseProject(ByVal row As Integer)
        If dataGrid.RowCount > 0 Then
            selectProject(row)
            If dataGrid.RowCount >= row Then
                setProject(row)
            End If
        End If
    End Sub


    ''' <summary>
    ''' Sets text box text and tag. This info is used after the form is closed.
    ''' </summary>
    ''' <param name="row">
    ''' Index of row to use for project info
    ''' </param>
    Private Sub setProject(ByVal row As Integer)
        'projectName.Text = dataGrid.Columns(PT.Name).HeaderText
        'projectName.Tag = dataGrid.Columns(PT.ProjectId).HeaderText

        projectName.Text = dataGrid.Rows(row).Cells(2).Value
        projectName.Tag = dataGrid.Rows(row).Cells(1).Value
    End Sub


    ''' <summary>
    ''' Opens the selected project
    ''' </summary>
    ''' <remarks>
    ''' The parent of this form is expected to use the selected information to open the project
    ''' </remarks>
    Private Sub openSelectedProject()
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub


    Private Sub selectProject(ByVal row As Integer)
        'dataGrid.Rows.Clear()
        'dataGrid.Rows.Add(row)
    End Sub



    Private Sub formatProjects()
        'Rae.Ui.C1GridStyles.BasicGridStyle(dataGrid)

        With Me.dataGrid
            ' sets heights
            .Height = 24
            '.CaptionHeight = 24
            '.Splits(0).ColumnCaptionHeight = 22


            ' sets column headers text
            '.Splits(0).DisplayColumns("Checkout").Visible = False
            '.Splits(0).DisplayColumns(PT.Name).DataColumn.Caption = "Project Name"
            '.Splits(0).DisplayColumns("CreatedBy").DataColumn.Caption = "Created By"
            '.Splits(0).DisplayColumns("DateCreated").DataColumn.Caption = "Date Created"


            '' sets column width
            '.Splits(0).DisplayColumns(PT.Name).Width = 150
            '.Splits(0).DisplayColumns("CreatedBy").Width = 120
            '.Splits(0).DisplayColumns("DateCreated").Width = DATE_CREATED_COLUMN_WIDTH

            ' hides id column
            '.Splits(0).DisplayColumns(PT.ProjectId).Visible = False

            ' sets row selection style
            '.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
        End With

        'setColumnWidths()

        'If isCheckout Or isCheckin Then
        '    checkList_.Clear()
        '    dataGrid.AllowUpdate = True
        '    For i As Integer = 1 To Projects.Columns.Count - 1
        '        Projects.Splits(0).DisplayColumns(i).Locked = True
        '    Next
        'End If

    End Sub


    'Private Sub setColumnWidths()
    '    ' checks if the datasource has been set yet
    '    If dataGrid.DataSource Is Nothing Then Exit Sub

    '    Dim isCheckColWidth As Integer = 0
    '    If isCheckout Or isCheckin Then isCheckColWidth = 65

    '    Const DATE_CREATED_COLUMN_WIDTH As Integer = 120

    '    ' gets total width available for columns in datagrid
    '    Dim totalWidth As Integer = dataGrid.Width
    '    totalWidth -= 6   ' borders
    '    totalWidth -= dataGrid.Width

    '    ' adjusts columns width according to datagrid's width
    '    Me.dataGrid.DisplayColumns(PT.Name).Width = totalWidth * 0.75 - DATE_CREATED_COLUMN_WIDTH - isCheckColWidth
    '    Me.projects.Splits(0).DisplayColumns("CreatedBy").Width = totalWidth * 0.25
    '    Me.projects.Splits(0).DisplayColumns("DateCreated").Width = DATE_CREATED_COLUMN_WIDTH
    '    If isCheckout Then Me.projects.Splits(0).DisplayColumns("Checkout").Width = isCheckColWidth
    '    If isCheckin Then Me.projects.Splits(0).DisplayColumns("CheckIn").Width = isCheckColWidth

    'End Sub


    ' Private Sub projects_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) _
    'Handles projects.RowColChange
    '     chooseProject(projects.Row)
    ' End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        setTableView()
    End Sub

    Private Sub setTableView()

        If Not formLoad Then

            If Me.CheckBox1.Checked Then
                Me.dataGrid.DataSource.defaultview.RowFilter = "ProjectId Like '" & AppInfo.User.username & "+*'"
            Else
                Me.dataGrid.DataSource.defaultview.RowFilter = ""
            End If

            If Trim(search.Text) > " " Then
                If Me.dataGrid.DataSource.defaultview.RowFilter.trim > " " Then
                    Me.dataGrid.DataSource.defaultview.rowfilter += " AND Name like '" & Trim(search.Text) & "*'"
                Else
                    Me.dataGrid.DataSource.defaultview.rowfilter += "Name like '" & Trim(search.Text) & "*'"
                End If
            End If

            Me.dataGrid.DataSource.defaultview.rowfilter.trim()

            'Dim table As DataTable
            'If isCheckin Then
            'table = ProjectsDataAccess.RetrieveCheckInQry(Trim(search.Text))
            'Else
            '   table = ProjectsDataAccess.RetrieveQry(Trim(search.Text), isCheckout)
            'End If
            'table.DefaultView.Sort = "DateCreated DESC"
            'projects.DataSource = table
            'formatProjects()
            Me.dataGrid.Refresh()

            'chooseProject(0)

        End If

    End Sub


#Region " Check-in/out"

    Private Sub onCheckout()
        Dim str As String = ""
        If checkList_.Count > 0 Then
            For i As Integer = 0 To checkList_.Count - 1
                If str = "" Then
                    str += checkList_(i)
                Else
                    str += vbCrLf & checkList_(i)
                End If
            Next
        End If
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub onCheckin()
        Dim str As String = ""
        If checkList_.Count > 0 Then
            For i As Integer = 0 To checkList_.Count - 1
                If str = "" Then
                    str += checkList_(i)
                Else
                    str += vbCrLf & checkList_(i)
                End If
            Next
        End If
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub dataGrid_SelectedIndexChanging(sender As Object, e As String)
        projectName.Text = dataGrid.Rows(e).Cells(1).ToString()
    End Sub

    Sub dataGrid_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
    End Sub


    Private Sub dataGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGrid.CellClick
        setProject(e.RowIndex)
    End Sub

    Private Sub dataGrid_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGrid.CellContentDoubleClick
        setProject(e.RowIndex)
        If isCheckout Then
            onCheckout()
        ElseIf isCheckin Then
            onCheckin()
        Else
            onOpen()
        End If
    End Sub

    Private Sub dataGrid_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dataGrid.CellMouseDoubleClick
        setProject(e.RowIndex)
        If isCheckout Then
            onCheckout()
        ElseIf isCheckin Then
            onCheckin()
        Else
            onOpen()
        End If
    End Sub

    Private Sub dataGrid_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGrid.CellDoubleClick
        setProject(e.RowIndex)
        If isCheckout Then
            onCheckout()
        ElseIf isCheckin Then
            onCheckin()
        Else
            onOpen()
        End If
    End Sub



#End Region

End Class
