Imports System
Imports System.Data
Imports PT = Rae.RaeSolutions.DataAccess.Projects.Tables.ProjectsTable

Public Class ProjectListForm

   ReadOnly Property ProjectId As String
      Get
         Return _projectId
      End Get
   End Property

   Sub Populate(table As DataTable)
        DataGridView1.DataSource = table
        ''format()
        DataGridView1.DataSource = table
        DataGridView1.Refresh()
    End Sub
   

   Protected _projectId As String

#Region " Overridable"

   Protected Overridable Sub onOk()
      Me.DialogResult = Windows.Forms.DialogResult.OK
      Me.Close()
   End Sub
   
   Protected Overridable Sub onCancel()
      Me.DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

    ''Protected Overridable Sub format()
    ''   Rae.Ui.C1GridStyles.BasicGridStyle(projects)

    ''   With Me.projects
    ''      ' sets heights
    ''      .CaptionHeight = 24
    ''      .Splits(0).ColumnCaptionHeight = 22

    ''      ' sets column headers text
    ''      .Splits(0).DisplayColumns(PT.Name).DataColumn.Caption = "Project Name"
    ''      .Splits(0).DisplayColumns("CreatedBy").DataColumn.Caption = "Created By"
    ''      .Splits(0).DisplayColumns("DateCreated").DataColumn.Caption = "Date Created"

    ''      ' hides columns
    ''      .Splits(0).DisplayColumns(PT.ProjectId).Visible = False
    ''      .Splits(0).DisplayColumns("Checkout").Visible = False

    ''      ' sets row selection style
    ''      .MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
    ''   End With

    ''   setColumnWidths()
    ''End Sub

    '' Protected Overridable Sub setColumnWidths()
    ''   ' checks if the datasource has been set yet
    ''   If projects.DataSource Is Nothing Then Exit Sub

    ''   Const DATE_CREATED_COLUMN_WIDTH As Integer = 120

    ''   ' gets total width available for columns in datagrid
    ''   Dim totalWidth As Integer = projects.Width
    ''   totalWidth -= 6   ' borders
    ''   totalWidth -= projects.VScrollBar.Width

    ''   ' adjusts columns width according to datagrid's width
    ''   Me.projects.Splits(0).DisplayColumns(PT.Name).Width = totalWidth * 0.75 - DATE_CREATED_COLUMN_WIDTH
    ''   Me.projects.Splits(0).DisplayColumns("CreatedBy").Width = totalWidth * 0.25
    ''   Me.projects.Splits(0).DisplayColumns("DateCreated").Width = DATE_CREATED_COLUMN_WIDTH
    ''End Sub

    '' Protected Overloads Overridable Sub setTableView()
    ''   setTableView(search.Text.Trim, filteredByUsername.Checked)
    ''End Sub

    ''Protected Overloads Overridable Sub setTableView(searchFor As String, filteredByUsername As Boolean)
    ''   If projects.DataSource Is Nothing Then _
    ''      Exit Sub

    ''   Dim ds As DataTable = CType(projects.DataSource, DataTable)
    ''   Dim rowFilter As String

    ''   If filteredByUsername Then _
    ''      rowFilter = PT.ProjectId & " Like '" & AppInfo.User.username & "+*'"

    ''   If Not String.IsNullOrEmpty(searchFor) Then
    ''      If Not String.IsNullOrEmpty(rowFilter) Then _
    ''         rowFilter &= " AND "
    ''      rowfilter += "Name like '" & searchFor.Trim & "*'"
    ''   End If

    ''   ds.DefaultView.RowFilter = rowFilter

    ''   projects.Refresh()
    ''     chooseProject(0)




    '' End Sub

#End Region

#Region " Event handlers"

    Private Sub cancel_Click(s As Object, e As EventArgs) _
   Handles cancel.Click
      onCancel()
   End Sub
   
   Private Sub ok_Click(s As Object, e As EventArgs) _
   Handles ok.Click
      onOk()
   End Sub

    Private Sub DataGridView1_KeyDown(s As Object, e As KeyEventArgs) _
    Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Enter Then _
           onOk()
    End Sub

    '' Private Sub DataGridView1_MouseDown(s As Object, e As MouseEventArgs) _
    ''Handles DataGridView1.MouseDown
    ''     ' handles double click
    ''     If e.Clicks = 2 Then
    ''         If Not clickedHeader(e) Then _
    ''         onOk()
    ''     End If

    ''     ' selects row on mouse up
    '' End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ' gets row that cursor is over
        Dim selectedRow As Integer = e.RowIndex
        If selectedRow > -1 Then _
         chooseProject(selectedRow)
    End Sub

    '' Private Sub projects_Resize(s As Object, e As EventArgs) _
    ''Handles projects.Resize
    ''   setColumnWidths()
    ''End Sub

    Private Sub search_KeyDown(s As Object, e As KeyEventArgs) _
   Handles search.KeyDown
      If e.KeyCode = Keys.Enter Then
         onOk()
      ElseIf e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Up Then
            DataGridView1.Focus()
        End If
   End Sub
   
   Private Sub search_TextChanged(s As Object, e As EventArgs) _
   Handles search.TextChanged, filteredByUsername.CheckedChanged
        ''setTableView()
    End Sub

#End Region


#Region " Helpers"

    ''Protected Function clickedHeader(e As MouseEventArgs) As Boolean
    ''   Dim captionHeight As Integer = projects.CaptionHeight
    ''   Dim columnHeight As Integer = projects.Splits(0).DisplayColumns(0).Height
    ''   Dim totalHeaderHeight As Integer = captionHeight + columnHeight

    ''   Return e.Y <= totalHeaderHeight
    ''End Function


    Private Sub selectProject(row As Integer)
        DataGridView1.SelectedRows.Clear()

    End Sub
   
   ''' <summary>
   ''' Sets text box text and project ID property. This info is used after the form is closed.
   ''' </summary>
   ''' <param name="row">
   ''' Index of row to use for project info
   ''' </param>
   Private Sub setProject(row As Integer)
        projectName.Text = DataGridView1.Rows(row).Cells(2).Value
        _projectId = DataGridView1.Rows(row).Cells(1).Value
    End Sub
   
   
   Protected Sub chooseProject(row As Integer)
        If DataGridView1.RowCount > 0 Then
            selectProject(row)
            ' TODO: is this check necessary; will row ever be less than number of rows
            If DataGridView1.RowCount >= row Then
                setProject(row)
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

#End Region



End Class