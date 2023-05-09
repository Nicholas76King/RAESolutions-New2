Public Class ShareMyProjects
    Dim gridLoaded As Boolean = False
    Private Sub ShareMyProjects_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadUsers()
    End Sub


    Private Sub LoadUsers()
        gridLoaded = False
        Dim CloudSaveWS As New CloudSaveService.CloudSave

        Dim UserShareList1() As CloudSaveService.UserShareList
        UserShareList1 = CloudSaveWS.GetUsersToShareWith(AppInfo.User.username, AppInfo.User.Company_Code, True)

        For Each c As CloudSaveService.UserShareList In UserShareList1
            Dim i As Integer = DataGridView1.Rows.Add()
            DataGridView1.Rows(i).Cells("UserName").Value = c.UserName
            DataGridView1.Rows(i).Cells("FullName").Value = c.FullName
            DataGridView1.Rows(i).Cells("CompanyNumber").Value = c.CompanyNumber
            DataGridView1.Rows(i).Cells("CompanyName").Value = c.CompanyName
            DataGridView1.Rows(i).Cells("UserCanSeeProjects").Value = c.UserCanSeeProjects
        Next
        gridLoaded = True
    End Sub



    Private Sub DataGridView1_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.ColumnHeaderMouseClick
        Static SortDirection As System.ComponentModel.ListSortDirection = System.ComponentModel.ListSortDirection.Descending

        If SortDirection = System.ComponentModel.ListSortDirection.Descending Then
            SortDirection = System.ComponentModel.ListSortDirection.Ascending
        Else
            SortDirection = System.ComponentModel.ListSortDirection.Descending
        End If

        DataGridView1.Sort(DataGridView1.Columns(e.ColumnIndex), SortDirection)

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)

    End Sub

    Private Sub DataGridView1_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If e.ColumnIndex = 4 AndAlso gridLoaded Then


            Dim isChecked As Boolean = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            Dim employeeName As String = DataGridView1.Rows(e.RowIndex).Cells(0).Value
            Dim currentUser As String = AppInfo.User.username


            Dim CloudSaveWS As New CloudSaveService.CloudSave
            CloudSaveWS.ShareOrUnshareProjectsAsync(currentUser, employeeName, isChecked)


        End If
    End Sub
End Class