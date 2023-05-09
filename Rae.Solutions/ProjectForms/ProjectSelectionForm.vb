Imports System.Data
Imports ProjectsDa = Rae.RaeSolutions.DataAccess.Projects.ProjectsDataAccess

Public Class ProjectSelectionForm

    Private Sub form_Load(ByVal s As Object, ByVal e As EventArgs) _
    Handles Me.Load

        'If AppInfo.User.HasCloudAccess Then
        '    filteredByUsername.Checked = False
        'End If

        Dim projects As DataTable = ProjectsDa.RetrieveAll(True)
        projects.DefaultView.Sort = "DateCreated DESC"
        Populate(projects)
        chooseProject(0)
    End Sub
   
End Class
