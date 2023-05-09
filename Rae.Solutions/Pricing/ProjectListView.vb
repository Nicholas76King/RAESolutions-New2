Imports Rae.RaeSolutions.Business.Entities
Imports System.ComponentModel
Imports Rae.RaeSolutions.DataAccess
Imports System.Data
Imports System.Data.OleDb

''' <summary>
''' View of project information.
''' </summary>
''' <history by="Casey Joyce" start="2006/08/06" finish="2006/08/08">
''' Created, only displays name
''' </history>
Public Class ProjectListView

    Private WithEvents m_manager As project_manager

    ''' <summary>
    ''' Project manager bound to project list view.
    ''' </summary>
    Public Property Manager() As project_manager
        Get
            Return Me.m_manager
        End Get
        Set(ByVal value As project_manager)
            Me.m_manager = value
            Me.grdProject.Rows.Clear()
            If value IsNot Nothing Then
                Me.AddProjectToGrid()
            End If
        End Set
    End Property

    ''' <summary>
    ''' Handles project list view's load event.
    ''' </summary>
    Private Sub ProjectListView_Load(ByVal sender As Object, ByVal e As EventArgs) _
    Handles Me.Load
        Me.DisplayNoOpenProject()

        ' sets context menu's open image
        Me.mnuOpen.Image = Me.ImageList1.Images(0)
    End Sub


    ''' <summary>
    ''' Handles grid's double click event. Views project info.
    ''' </summary>
    Private Sub grdProject_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) _
    Handles grdProject.DoubleClick
        If OpenedProject.IsOpened Then
            ProjectInfo.Viewer.ViewProject(Me.Manager.Project)
        End If
    End Sub


    ''' <summary>
    ''' Handles menu's open click event.
    ''' </summary>
    Private Sub mnuOpen_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mnuOpen.Click
        If Me.Manager IsNot Nothing Then
            ProjectInfo.Viewer.ViewProject(Me.Manager.Project)
        End If
    End Sub


    ''' <summary>
    ''' Handles menu opening event. Cancels if project is not open.
    ''' </summary>
    Private Sub mnuProject_Opening(ByVal sender As Object, ByVal e As CancelEventArgs) _
    Handles ContextMenuStrip1.Opening
        If Me.Manager Is Nothing Then
            e.Cancel = True
        End If
    End Sub


    ''' <summary>
    ''' Adds project to grid.
    ''' </summary>
    Private Sub AddProjectToGrid()
        Dim rowIndex As Integer
        ' adds project row
        rowIndex = Me.grdProject.Rows.Add()
        ' sets name of project
        Me.grdProject.Rows(rowIndex).Cells("ProjectName").Value = Me.m_manager.Project.name
    End Sub


    ''' <summary>
    ''' Gets index of row containing the ID. Returns -1 if row does not exist.
    ''' </summary>
    ''' <param name="id">
    ''' ID to look for.
    ''' </param>
    Private Function GetRowIndex(ByVal id As String) As Integer
        For Each row As DataGridViewRow In Me.grdProject.Rows
            If row.Cells("ProjectName").Value = id Then
                Return row.Index
            End If
        Next
        Return -1
    End Function


    Private Sub RemoveFromGrid(ByVal id As String)

        ' close form if it is up
        ProjectInfo.Viewer.CloseForm(id)

        ' remove process from grid
        Me.grdProject.Rows.Remove(Me.grdProject.Rows(GetRowIndex(id)))

    End Sub


    ''' <summary>
    ''' Displays no open project for project name.
    ''' </summary>
    Private Sub DisplayNoOpenProject()
        Me.grdProject.Rows.Add()
        Me.grdProject.Rows(0).Cells(0).Value = "There is not an open project."
    End Sub

    ''' <summary>
    ''' deletes open project and all of it's dependencies (equipment, processes, relationships, etc)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DeleteProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteProjectToolStripMenuItem.Click

        ' make sure user really wants to delete project
        Dim shoulddel As New DoYouWantToDeleteForm
        shoulddel.DeleteWhat = DoYouWantToDeleteForm.deletetype.ProjectItem
        shoulddel.ShowDialog()
        If Not shoulddel.DeleteConfirmed Then Exit Sub
        shoulddel = Nothing

        If Me.Manager IsNot Nothing Then
            Rae.RaeSolutions.DataAccess.Projects.ProjectsDataAccess.Delete(Me.Manager.Project.id.Id)
            ' close form if it is up
            ProjectInfo.Viewer.CloseAllForms()
            ' set project manager to nothing
            OpenedProject.Manager = Nothing
        End If
    End Sub

    Private Sub CopyProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyProjectToolStripMenuItem.Click
        If OpenedProject.IsOpened Then ProjectInfo.CopyProject(OpenedProject.Manager.Project.id.Id)
    End Sub

    Private Sub RenameProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenameProjectToolStripMenuItem.Click

        Dim newProjectName As String = InputBox("Rename Project:", "Rename Project Dialog", " ")

        If newProjectName = "" Then
            Exit Sub
        ElseIf newProjectName = " " Then
            MessageBox.Show("You must enter a new project name.")
            Exit Sub
        End If

        Dim user As String = AppInfo.User.username
        Dim project As String = OpenedProject.Manager.Project.id.Id.ToString()

        Dim update As String = "UPDATE Projects SET [Name] = @projectName WHERE [ProjectID] = '" & project & "'"
        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command As New OleDbCommand
        command.Connection = connection
        command.CommandType = CommandType.Text
        command.Parameters.Add("@projectName", OleDbType.VarChar)
        command.Parameters("@projectName").Value = newProjectName
        command.CommandText = update

        Try
            connection.Open()
            command.ExecuteNonQuery()
            MessageBox.Show("Your project name has been updated.")
        Finally
            If connection.State <> ConnectionState.Closed Then _
                   connection.Close()
        End Try

        Try
            Me.grdProject.Rows(0).Cells(0).Value = newProjectName
            Dim projectForm = DirectCast(ProjectInfo.Viewer.GetView(OpenedProject.Manager.Project.id.Id), ProjectForm)
            projectForm.Text = newProjectName
        Catch ex As Exception
            MessageBox.Show("Project will reflect new name when the project is re-opened.")
        End Try

    End Sub

End Class
