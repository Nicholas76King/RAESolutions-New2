Imports System.IO

Public Class BackupForm

    Private folderPath As String = String.Empty

    Private Sub cmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
        saveBackup.FileName = "Projects.mdb"
        If saveBackup.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtLocation.Text = saveBackup.FileName
            cmdSave.Enabled = True
        End If
    End Sub


    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim dir As New DirectoryInfo(folderPath)
        If txtLocation.Text.Length > 0 And Dir.Exists Then
            My.Settings.BackupLocation = saveBackup.FileName
            My.Settings.BackupDate = Date.Now
            Dim f As New FileInfo(Rae.RaeSolutions.DataAccess.Common.ProjectsDbPath)
            If f.Exists Then
                Dim newFile As FileInfo = New FileInfo(saveBackup.FileName)
                If newFile.Exists Then
                    newFile.IsReadOnly = False
                End If
                f.CopyTo(saveBackup.FileName, True)
            End If
            My.Settings.Save()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("The directory selected does not exist.  Please try again.")
        End If
    End Sub

    Private Sub txtLocation_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLocation.TextChanged
        folderPath = saveBackup.FileName.Substring(0, saveBackup.FileName.LastIndexOf("\"))
        Dim dir As New DirectoryInfo(folderPath)
        If txtLocation.Text.Length > 0 And dir.Exists Then
            cmdSave.Enabled = True
            cmdSave.ImageIndex = 1
        Else
            cmdSave.Enabled = False
            cmdSave.ImageIndex = 0
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        My.Settings.BackupDate = Nothing
        My.Settings.BackupLocation = String.Empty
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class