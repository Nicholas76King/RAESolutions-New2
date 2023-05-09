Imports Cols = Rae.RaeSolutions.ProcessGridColumns
Imports Rae.RaeSolutions.Business.Entities
Imports ProcessItemDA = Rae.RaeSolutions.DataAccess.Projects.ProcessItemDA
Imports Rae.Collections
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class ProcessListView

    Public Class ColumnNames
        Public Const Id As String = "IdColumn"
        Public Const Model As String = "ModelColumn"
        Public Const Name As String = "NameColumn"
    End Class

    Private WithEvents m_processes As ProcessItemList

    Public Property Processes() As ProcessItemList
        Get
            Return Me.m_processes
        End Get
        Set(ByVal value As ProcessItemList)
            Me.m_processes = value
            Me.processGrid.Rows.Clear()
            If value IsNot Nothing Then
                Me.AddToGrid(value)
            End If
        End Set
    End Property


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ' Me.m_processes = New ProcessItemList()

    End Sub

#Region " Event handlers"

    ''' <summary>
    ''' Handles process saved event. Updates values in the row corresponding to the saved process.
    ''' </summary>
    Private Sub Process_Saved(ByVal sender As ProcessItem, ByVal e As EventArgs)
        ' gets row corresponding to sender's process ID
        Dim rowIndex As Integer = Me.GetRowIndex(sender.id.Id)
        ' updates model for the saved process
        Me.processGrid.Rows(rowIndex).Cells(ColumnNames.Model).Value = sender.Model
        ' updates name for the saved process
        Me.processGrid.Rows(rowIndex).Cells(ColumnNames.Name).Value = sender.name
    End Sub


    ''' <summary>
    ''' Event handler for process added event.
    ''' Adds process to grid.
    ''' </summary>
    Private Sub Process_ItemAdded(ByVal sender As EventfulList(Of ProcessItem), ByVal e As ListItemAddedEventArgs) _
    Handles m_processes.ItemAdded
        ' adds process to grid
        Me.AddToGrid(sender(e.Index))
    End Sub


    ''' <summary>
    ''' Event handler for process deleted event.
    ''' removes process from grid.
    ''' </summary>
    Private Sub Process_Removed(ByVal processitem As ProcessItem, ByVal e As EventArgs) _
    Handles m_SelectedProcess.Removed
        ' removes process from grid
        Me.RemoveFromGrid(processitem.id.Id)
    End Sub

    ''' <summary>
    ''' Event handler for process list view load event.
    ''' </summary>
    Private Sub ProcessListView_Load(ByVal sender As Object, ByVal e As EventArgs) _
    Handles Me.Load
        ' sets open menu's image
        Me.mnuOpen.Image = Me.ImageList1.Images(1)
    End Sub

    ''' <summary>
    ''' Event handler for context menu opened event.
    ''' Displays selected process name so that the user will no which process the options apply to.
    ''' </summary>
    Private Sub mnuItemOptions_Opened(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mnuItemOptions.Opened
        If Me.processGrid.SelectedRows.Count = 0 Then
            '' closes menu if there is no process is selected
            'Me.mnuItemOptions.Close()
            Me.mnuDelete.Visible = False
            Me.mnuOpen.Visible = False
            Me.mnuName.Visible = False
            Me.mnuRename.Visible = False
            Me.mnuNew.Visible = True
        Else
            Me.mnuOpen.Visible = True
            Me.mnuDelete.Visible = True
            Me.mnuName.Visible = True
            Me.mnuRename.Visible = True
            Me.mnuNew.Visible = True
            ' displays name of selected equipment
            Me.mnuName.Text = "Name: " & Me.processGrid.SelectedRows(0).Cells(Cols.Name).Value.ToString
        End If
    End Sub

    ''' <summary>
    ''' Handles context menu opening event.
    ''' Cancels opening context menu if process is not selected.
    ''' </summary>
    Private Sub mnuItemOptions_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles mnuItemOptions.Opening
        ' menu context doesn't apply if a row is not selected; context is row-specific
        If Me.processGrid.SelectedRows.Count = 0 Then
            'e.Cancel = True
        End If
    End Sub

    ''' <summary>
    ''' Handles rename menu item clicked event.
    ''' Allows user to rename selected process.
    ''' </summary>
    Private Sub mnuRename_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mnuRename.Click
        Me.PopupRename()
    End Sub

    ''' <summary>
    ''' Handles context menu open clicked event. Opens equipment.
    ''' </summary>
    Private Sub mnuOpen_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mnuOpen.Click
        ' gets id of selected row
        Dim id As String = Me.processGrid.SelectedRows(0).Cells(Cols.Id).Value.ToString

        ' views equipment in selected row
        ProjectInfo.Viewer.ViewProcess(Me.Processes.Items(id)) 'DataAccess.Projects.EquipmentItemDA.Retrieve(id))
    End Sub

    ''' <summary>
    ''' Handles context menu new clicked event. Begins process for user to create process.
    ''' </summary>
    Private Sub mnuNew_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mnuNew.Click

        CType(My.Application.ApplicationContext.MainForm, MainForm).StartNewProcess()

    End Sub

    ''' <summary>
    ''' Event handler for process item name changed event.
    ''' Renames name in grid's corresponding cell.
    ''' </summary>
    Private Sub Process_ItemNameChanged(ByVal sender As ProcessItem, ByVal e As EventArgs) _
    Handles m_processes.ItemNameChanged
        Dim rowIndex As Integer

        rowIndex = Me.GetRowIndex(sender.id.Id)

        If rowIndex = -1 Then
            ' row does not exist
            ' TEST:
            MessageBox.Show("Name changed failed. Row does not exist.")
        Else
            Me.processGrid.Rows(rowIndex).Cells(Cols.Name).Value = sender.name
        End If
    End Sub

#End Region

#Region " Other Private Methods"

    Private Sub AddToGrid(ByVal process As ProcessItem)
        Dim rowIndex As Integer

        rowIndex = Me.processGrid.Rows.Add()

        Me.processGrid.Rows(rowIndex).Cells(ColumnNames.Id).Value = process.id.ToString
        Me.processGrid.Rows(rowIndex).Cells(ColumnNames.Model).Value = process.Model
        Me.processGrid.Rows(rowIndex).Cells(ColumnNames.Name).Value = process.name

        AddHandler process.Saved, AddressOf Process_Saved
    End Sub

    Private Sub AddToGrid(ByVal list As ProcessItemList)
        For Each item As ProcessItem In list
            Me.AddToGrid(item)
        Next
    End Sub

    Private Sub RemoveFromGrid(ByVal id As String)

        ' close form if it is up
        ProjectInfo.Viewer.CloseForm(id)

        ' remove process from grid
        Me.processGrid.Rows.Remove(Me.processGrid.Rows(GetRowIndex(id)))

    End Sub

    ''' <summary>
    ''' Gets index of row containing the ID. Returns -1 if row does not exist.
    ''' </summary>
    ''' <param name="id">
    ''' ID to look for.
    ''' </param>
    Private Function GetRowIndex(ByVal id As String) As Integer
        For Each row As DataGridViewRow In Me.processGrid.Rows
            If row.Cells(ColumnNames.Id).Value = id Then
                Return row.Index
            End If
        Next
        Return -1
    End Function

    ''' <summary>
    ''' Pops up form to rename selected equipment, and renames equipment.
    ''' </summary>
    Private Sub PopupRename()
        Dim frmRename As New RenameForm
        frmRename.Text = "Rename Selection"
        Dim selectedRow As DataGridViewRow

        ' references selected row
        selectedRow = Me.processGrid.SelectedRows(0)

        ' sets rename form's location
        frmRename.StartPosition = FormStartPosition.Manual
        frmRename.Location = Me.GetLocationNearRow(selectedRow, frmRename.Size)

        ' sets name to current name initially
        Dim previousName As String = selectedRow.Cells(Cols.Name).Value.ToString
        frmRename.txtNewName.Text = previousName

        ' shows rename pop-up
        frmRename.ShowDialog()

        ' applies rename change
        If frmRename.DialogResult = DialogResult.OK Then
            ' gets selected equipment's ID
            Dim id As String = selectedRow.Cells(Cols.Id).Value.ToString
            ' gets the user's renamed equipment name
            Dim nameEntered As String = frmRename.txtNewName.Text.Trim
            ' checks if name actually changed
            If Not nameEntered = Me.Processes.Items(id).name Then
                ' sets equipment object's name based on user's rename; object's event will update grid
                Me.Processes.Items(id).name = nameEntered
                ' updates data source with new name
                ProcessItemDA.Rename(id, nameEntered)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Gets location to display pop-up below row or above row w/out exceeeding screen boundaries.
    ''' </summary>
    ''' <param name="row">
    ''' Row that return location is related to.
    ''' </param>
    ''' <param name="popupSize">
    ''' Size of pop-up to display.
    ''' </param>
    Private Function GetLocationNearRow(ByVal row As DataGridViewRow, ByVal popupSize As Size) As Point
        Dim formLocation As Point

        '
        ' gets location BELOW row
        '
        Dim formRectangleBelow As New Rectangle(Me.GetLocationBelowRow(row), popupSize)

        If Me.IsContainedByScreen(formRectangleBelow) Then
            formLocation = Me.GetLocationBelowRow(row) : Return formLocation
        End If

        '
        ' gets location ABOVE row, if location below exceed screen boundaries
        '
        Dim formRectangleAbove As Rectangle
        Dim formLocationAbove As Point

        formLocationAbove = Me.GetLocationAboveRow(row)
        formLocationAbove.Y -= popupSize.Height

        formRectangleAbove = New Rectangle(formLocationAbove, popupSize)

        If Me.IsContainedByScreen(formRectangleAbove) Then
            formLocation = formRectangleAbove.Location : Return formLocation
        End If

        '
        ' gets DEFAULT location, if location above and below row both exceed screen boundaries
        ' default setting shouldn't occur (causes: large pop-up or small screen)
        '
        formLocation = New Point(0, 0) : Return formLocation

    End Function

    ''' <summary>
    ''' Gets location below and to the left of row.
    ''' </summary>
    ''' <param name="row">
    ''' Row the returned location is related to.
    ''' </param>
    ''' <returns>
    ''' Location below and to the left of row.
    ''' </returns>
    Private Function GetLocationBelowRow(ByVal row As DataGridViewRow) As Point
        Dim location As Point
        Dim x, y As Integer

        ' gets location below row aligned w/ left of grid
        x = Me.processGrid.Left
        y = Me.processGrid.GetRowDisplayRectangle(row.Index, True).Y + row.Height

        location = Me.processGrid.PointToScreen(New Point(x, y))

        Return location
    End Function

    ''' <summary>
    ''' Gets location above and to the left of row.
    ''' </summary>
    ''' <param name="row">
    ''' Row that returned location is related to.
    ''' </param>
    ''' <returns>
    ''' Location above and to the left of row.
    ''' </returns>
    Private Function GetLocationAboveRow(ByVal row As DataGridViewRow) As Point
        Dim location As Point
        Dim x, y As Integer

        ' gets location above row aligned w/ left of grid
        x = Me.processGrid.Left
        y = Me.processGrid.GetRowDisplayRectangle(row.Index, True).Y

        location = Me.processGrid.PointToScreen(New Point(x, y))

        Return location
    End Function

    ''' <summary>
    ''' True if rectangle is completely contained by screen; else false.
    ''' </summary>
    ''' <param name="rectangle">
    ''' Rectangle to check if it is completely contained by screen.
    ''' </param>
    ''' <returns>
    ''' True if rectangle is completely contained by screen; else false.
    ''' </returns>
    Private Function IsContainedByScreen(ByVal rectangle As Rectangle) As Boolean
        Dim screen As Rectangle
        Dim contained As Boolean

        ' gets screen size
        screen = My.Computer.Screen.WorkingArea

        ' checks if rectangle is completely contained in screen
        contained = screen.Contains(rectangle)

        Return contained
    End Function

#End Region

    Private WithEvents m_SelectedProcess As ProcessItem
    ''' <summary>
    ''' Selected process item in grid - null if no process is selected
    ''' </summary>
    Public ReadOnly Property SelectedProcess() As ProcessItem
        Get
            Dim id As String
            Dim process_item As ProcessItem
            ' checks if a row is selected
            If Me.processGrid.SelectedRows.Count > 0 Then
                ' gets ID in selected row
                id = Me.processGrid.SelectedRows(0).Cells(0).Value.ToString
                ' returns process associated with row
                process_item = Me.Processes.Items(id)
                m_SelectedProcess = Me.Processes.Items(id)
            End If
            Return process_item
        End Get
    End Property

    Private Sub processGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles processGrid.DoubleClick
        ' If a process is selected, show it...
        If Me.SelectedProcess IsNot Nothing Then
            ProjectInfo.Viewer.ViewProcess(Me.SelectedProcess)
        End If
    End Sub

    Private Sub ProcessListView_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        'If e.Button = Windows.Forms.MouseButtons.Right Then
        '   Me.mnuItemOptions.Show()
        'End If
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click

        ' make sure user really wants to delete process
        Dim shoulddel As New DoYouWantToDeleteForm
        shoulddel.DeleteWhat = DoYouWantToDeleteForm.deletetype.ProcessItem
        shoulddel.ShowDialog()
        If Not shoulddel.DeleteConfirmed Then Exit Sub
        shoulddel = Nothing

        If Me.SelectedProcess IsNot Nothing Then
            Me.SelectedProcess.Remove()
        End If

    End Sub

End Class
