Imports System.IO
Imports Rae.RaeSolutions.DataAccess
Imports System.Data
Imports System.Data.OleDb

Public Class AdvancedProgramOptions

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub btnSaveProjectsPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveProjectsPath.Click

        If Not String.IsNullOrEmpty(txtProjectsPath.Text) AndAlso Not txtProjectsPath.Text.EndsWith("\") Then
            txtProjectsPath.Text &= "\"
        End If

        If Not String.IsNullOrEmpty(txtProjectsPath.Text) AndAlso Not Directory.Exists(txtProjectsPath.Text) Then
            MsgBox("Not a Valid Folder Path")
        Else
            My.Settings.CustomDataFilePath = txtProjectsPath.Text
            My.Settings.Save()

            MsgBox("Please restart RAE Solutions before continuing.")
        End If

    End Sub

    Private Function checkVersionHistoryFor34() As Boolean
        Dim sql = "SELECT Version FROM VersionHistory WHERE Version = '1.34.0.0'"
        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader
        Dim result As Boolean = False

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            If rdr.Read() Then
                result = True
            Else
                result = False
            End If
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try

        Return result
    End Function

    Private Sub btnProposalInfoFix_Click(sender As System.Object, e As System.EventArgs) Handles btnProposalInfoFix.Click
        Dim connection1 = Common.CreateConnection(Common.ProjectsDbPath)
        ' create proposal info table
        Try
            Dim create As String = "CREATE TABLE ProposalInfo (Id AUTOINCREMENT, Company VARCHAR(100), " &
                "MyName VARCHAR(100), MyPhone VARCHAR(100), MyEmail VARCHAR(100), MyTitle VARCHAR(100), Username VARCHAR(100));"

            Dim createTable As New OleDbCommand
            createTable.CommandText = create
            createTable.Connection = connection1

            connection1.Open()
            createTable.ExecuteNonQuery()
            MessageBox.Show("ProposalInfo Table Created.")
            connection1.Dispose()
        Catch ex As Exception
            MessageBox.Show("ProposalInfo Table Failed to create. " & Environment.NewLine & "Exception: " & ex.Message)
        Finally
            If connection1.State <> ConnectionState.Closed Then _
               connection1.Dispose()
        End Try

        Dim versionHistoryExists As Boolean = checkVersionHistoryFor34()

        If versionHistoryExists = False Then
            Dim connection2 = Common.CreateConnection(Common.ProjectsDbPath)
            ' create version history record
            Try
                Dim insert As String = "INSERT INTO VersionHistory (Description, ExecutionDate, Version) VALUES " &
                    "('Add ProposalInfo Table and VersionHistory record from Advanced Program Controls.', @now, '1.34.0.0');"
                Dim cmd As New OleDbCommand
                cmd.CommandText = insert
                cmd.Connection = connection2

                Dim now = New OleDbParameter("@now", OleDbType.Date)
                now.Value = DateTime.Now
                cmd.Parameters.Add(now)

                connection2.Open()
                cmd.ExecuteNonQuery()
                MessageBox.Show("VersionHistory record created.")
                connection2.Dispose()
            Catch ex As Exception
                MessageBox.Show("VersionHistory record failed to insert. " & Environment.NewLine & "Exception: " & ex.Message)
            Finally
                If connection2.State <> ConnectionState.Closed Then _
                    connection2.Dispose()
            End Try
        End If
    End Sub
End Class