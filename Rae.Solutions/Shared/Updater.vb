Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Updater

    ''' <summary>Updates application if a newer version is available and returns true if appication must exit.
    ''' </summary>
    ''' <param name="txtFileName">Name of the file containing the list of update files
    ''' </param>
    ''' <param name="UpdateRightNow">Indicates whether or not to update right now
    ''' </param>
    ''' <returns>Boolean indicating whether or not to close application
    ''' </returns>
    ''' <history>[CASEYJ]	8/24/2005	Created
    ''' </history>
    '    Public Shared Function CheckForNewVersion( _
    '    ByVal txtFileName As String, ByVal updateRightNow As Boolean) As Boolean

    '        '//Dimension Variables to Allocate Memory
    '        On Error GoTo err_CHECK_FOR_NEWER_VERSION1

    '        Dim closeApplication As Boolean = False
    '        Dim currentVersion As String
    '        Dim latestVersion As Double
    '        Dim minor, revision As String
    '        '[Major][Minor][Revision]
    '        Dim appVersion As String
    '        '[Major].[Minor].[Revision].[Build]
    '        Dim versionWithDots As String
    '        Dim networkFolderPath, localFolderPath, fileName, localFilePath, networkFilePath, updateExeFilePath As String

    '        ' sets file name, contains list of updates
    '        fileName = txtFileName  '"RAE_SOLUTIONS.txt"
    '        ' sets folder paths
    '        networkFolderPath = "\\" & Constants.FILESERVER1_INTERNAL_IP & "\fileser1_e\UpDate Control\"
    '        localFolderPath = "C:\Program Files\Rae_Auto_Update\"
    '        ' sets file paths
    '        localFilePath = System.IO.Path.Combine(localFolderPath, fileName)
    '        networkFilePath = System.IO.Path.Combine(networkFolderPath, fileName)
    '        ' sets rae update exe file path
    '        updateExeFilePath = "C:\Program Files\Rae_Auto_Update\Rae_Auto_Update.exe"

    '        'original format
    '        '[Major].[Minor].[Revision].[Build]
    '        'YYYY.M{i}.R{e}.{..XX..} ex. 2004.10.1.10257

    '        'converts by removing dots and Build and 
    '        'forcing 2 characters for minor and revision sections
    '        'YYYYReMi ex. 20041001


    '        'Gets current file version
    '        appVersion = String.Format("{0}", My.Application.Info.Version.ToString)
    '        versionWithDots = appVersion

    '        'YYYY.M{i}.R{e},  strips the digits following the last "."
    '        appVersion = Left(appVersion, appVersion.LastIndexOf("."))
    '        'M{i}.Re          gets characters after first "."
    '        minor = appVersion.Substring(appVersion.IndexOf(".") + 1)
    '        'R{e}             gets characters after first "."
    '        revision = minor.Substring(minor.IndexOf(".") + 1)
    '        'M{i}             gets everything left of "."
    '        minor = Trim(Left(minor, minor.LastIndexOf(".")))
    '        'Mi               adds "0" to minor if it's only one character
    '        If minor.Length < 2 Then minor = "0" & minor
    '        'Re               adds "0" to revision if it's only one character
    '        If revision.Length < 2 Then revision = "0" & revision
    '        'YYYYMiRe         creates app version with no dots
    '        appVersion = Left(appVersion, appVersion.IndexOf(".")) & minor & revision
    '        currentVersion = appVersion

    '        'COPY FILESERVEF TXT FILE TO LOCAL MACHINES - READ FILE ON LOCAL MACHINE - NOT FILESERVER
    '        'so the fileserver file is not read by multiple users
    '        FileCopy(networkFilePath, localFilePath)

    '        'OPEN TXT FILE & GET REVISION NUMBER FOR COMPARISON
    '        FileOpen(1, localFilePath, OpenMode.Input)
    '        Input(1, latestVersion)
    '        FileClose(1)

    '        'CHECK - IF NEWER VERSION IS AVAILABLE NOTIFY USER & ASK TO UPDATE
    '        If latestVersion > Val(currentVersion) Then

    '            'If this is automatic update, do not give user a choice...
    '            If updateRightNow = True Then

    'UPDATE_PROGRAM_NOW:

    '                'COPY FILE TO WORKING DIRECTORY(UPDATE_PROGRAM) FOR AUT UPDATE
    '                FileCopy(localFilePath, localFolderPath & "UPDATE_PROGRAM\" & fileName)

    '                'KILL FILE THAT WAS READ
    '                Kill(localFilePath)

    '                'OPEN AUTO UPDATE PROGRAM - FILES HAVE ALREADY BEEN COPIED TO AUTO UPDATE FOLDER
    '                Shell(updateExeFilePath, AppWinStyle.NormalNoFocus)
    '                'mCommon.OpenFileInAssociatedApplication(mGlobal.ApplicationPath & "WaitAndOpen.exe")

    '                'MUST END PROGRAM BEFORE IT IS UPDATED - IT WILL BE STARTED BACK UP FROM UPDATE PROGRAM
    '                closeApplication = True
    '                Return closeApplication
    '            Else
    '                'Not automatic update - give user option to update or not...
    '                Dim response As DialogResult
    '                response = MessageBox.Show( _
    '                   "A newer version of this program is available." & Chr(10) & Chr(10) & "Do you want to update now?", _
    '                   "RAESolutions", _
    '                   MessageBoxButtons.YesNo, _
    '                   MessageBoxIcon.Information)
    '                If response = DialogResult.Yes Then
    '                    GoTo UPDATE_PROGRAM_NOW
    '                Else
    '                    'KILL FILE THAT WAS READ
    '                    Kill(localFilePath)
    '                End If
    '            End If
    '            'new version not available
    '        Else
    '            'KILL FILE THAT WAS READ
    '            Kill(localFilePath)

    '            'if user initiates update then indicate that no update is available
    '            If updateRightNow = False Then
    '                MessageBox.Show("The latest version, " & versionWithDots & ", of this program is already installed. There are no new updates available at this time.", _
    '                   "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            End If
    '        End If

    '        Return closeApplication
    '        Exit Function

    'err_CHECK_FOR_NEWER_VERSION1:
    '        MessageBox.Show("An error has occured." & vbCrLf & vbTab & _
    '            "Procedure: CHECK_FOR_NEWER_VERSION" & vbCrLf & vbTab & _
    '            "Error Number: " & Err.Number & vbCrLf & vbTab & _
    '            "Error Description: " & Err.Description, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Function




    Public Shared Function CheckForUpdate() As Boolean
        Try

            '//Dimension Variables to Allocate Memory

            Dim currentVersion As String
            Dim latestVersion As Double
            Dim minor, revision As String
            Dim appVersion As String
            Dim versionWithDots As String
            Dim networkFolderPath, localFolderPath, fileName, localFilePath, networkFilePath, updateExeFilePath As String


            'Gets current file version
            appVersion = String.Format("{0}", My.Application.Info.Version.ToString)
            versionWithDots = appVersion
            appVersion = Left(appVersion, appVersion.LastIndexOf("."))
            minor = appVersion.Substring(appVersion.IndexOf(".") + 1)
            revision = minor.Substring(minor.IndexOf(".") + 1)
            minor = Trim(Left(minor, minor.LastIndexOf(".")))
            If minor.Length < 2 Then minor = "0" & minor
            If revision.Length < 2 Then revision = "0" & revision
            appVersion = Left(appVersion, appVersion.IndexOf(".")) & minor & revision
            currentVersion = appVersion


            Dim pcName As String = Environment.MachineName
            'If String.IsNullOrEmpty(pcName) Then LogError("Your PC could not be identified.", True)
            If pcName.Contains(".") Then pcName = pcName.Substring(0, pcName.IndexOf("."))

            Dim userName As String = Environment.UserName
            'If String.IsNullOrEmpty(userName) Then LogError("Your User Name could not be identified.", True)
            If userName.Contains("\") Then userName = userName.Substring(0, userName.IndexOf("\"))

            Dim appPath As String = Environment.CurrentDirectory()




            Dim updateNeeded As Boolean = CheckSQLForUpdate(3, userName, pcName, appPath, currentVersion)

            If updateNeeded Then  'AndAlso 1 = 2 Then

                Dim choice As MsgBoxResult
                choice = MsgBox("A new update for RAE Solutions is available.  This program will close at this time and your system will be updated.  Once the update is complete please reopen RAE Solutions." & vbCrLf & vbCrLf & "You can click 'Cancel' to temporarily skip this update.  However, this program gets updated for a reason.  So please only click 'Cancel' if you really need to.", MsgBoxStyle.OkCancel)

                If choice = MsgBoxResult.Cancel Then Return False


                'OPEN AUTO UPDATE PROGRAM - FILES HAVE ALREADY BEEN COPIED TO AUTO UPDATE FOLDER
                '        Shell("\\fileserver1a\FileSer1_E\UpdateControl\UpdateControl.exe", AppWinStyle.NormalNoFocus)
                'mCommon.OpenFileInAssociatedApplication(mGlobal.ApplicationPath & "WaitAndOpen.exe")

                If AppInfo.AppFolderPath.ToLower.Contains("x86") Then
                    Dim proc As New System.Diagnostics.Process()
                    proc.StartInfo.FileName = "\\fileserver1a\FileSer1_E\UpdateControl\UpdateControl.exe"
                    proc.StartInfo.Verb = "runas"
                    proc.Start()

                    Return True
                Else

                    Dim proc As New System.Diagnostics.Process()
                    proc.StartInfo.FileName = "\\fileserver1a\FileSer1_E\UpdateControl\UpdateControl.exe"
                    'proc.StartInfo.Verb = "runas"
                    proc.Start()

                    Return True
                End If



            Else
                Return False

            End If

        Catch ex As Exception

            Return False
        End Try

    End Function


    Public Shared Function CheckSQLForUpdate(ByVal applicationID As Integer, ByVal userName As String, ByVal PCName As String, ByVal applicationPath As String, ByVal currentVersion As String) As Boolean

        Dim rdr As SqlDataReader
        Dim oSQLConn As SqlConnection
        Dim command As SqlCommand

        Try

            oSQLConn = New SqlConnection("Data Source=raepoint;Initial Catalog=UpdateControl;Persist Security Info=True;User ID=UpdateControl;Password=expo1126A;Connect Timeout=120;Connection Timeout=120")
            oSQLConn.Open()

            Dim strSQL As String = "exec CheckAndOrTriggerUpdate '" & userName & "', '" & PCName & "', " & applicationID & ", '" & currentVersion & "' , '" & applicationPath & "'"

            command = New SqlCommand(strSQL, oSQLConn)
            command.CommandTimeout = 120
            command.CommandType = System.Data.CommandType.Text


            rdr = command.ExecuteReader

            If rdr.Read Then
                If rdr("UpdateNeeded") = 0 Then
                    CheckSQLForUpdate = False
                Else
                    CheckSQLForUpdate = True
                End If
            End If

        Catch ex As Exception
            CheckSQLForUpdate = False
        Finally
            If Not rdr Is Nothing Then rdr.Close()
            command.Dispose()
            oSQLConn.Dispose()
        End Try

    End Function




    ''' <summary>Updates files if a newer files are available and returns true if appication must exit.
    ''' </summary>
    ''' <param name="txtFileName">Name of the file containing the list of update files
    ''' </param>
    ''' <param name="UpdateRightNow">Indicates whether or not to update right now
    ''' </param>
    ''' <returns>Boolean indicating whether or not to close application
    ''' </returns>
    ''' <history>[JOSHH]	4/16/2007	Created
    ''' </history>
    '   Public Shared Function CheckForNewFiles( _
    '   ByVal txtFileName As String, ByVal updateRightNow As Boolean) As Boolean

    '      '//Dimension Variables to Allocate Memory
    '      On Error GoTo err_CHECK_FOR_NEWER_VERSION2

    '      Dim closeApplication As Boolean = False
    '      Dim currentVersion As String
    '      Dim latestVersion As String
    '      Dim minor, revision As String
    '      '[Major][Minor][Revision]
    '      Dim appVersion As String
    '      '[Major].[Minor].[Revision].[Build]
    '      Dim versionWithDots As String
    '      Dim networkFolderPath, localFolderPath, fileName, localFilePath1, localFilePath2, networkFilePath, updateExeFilePath As String

    '      ' sets file name, contains list of updates
    '      fileName = txtFileName  '"RAE_SOLUTIONS.FO"
    '      ' sets folder paths
    '      networkFolderPath = "\\" & Constants.FILESERVER1_INTERNAL_IP & "\fileser1_e\UpDate Control\"
    '      localFolderPath = "C:\Program Files\Rae_Auto_Update\"
    '      ' sets file paths
    '      localFilePath1 = System.IO.Path.Combine(AppInfo.AppFolderPath, fileName)
    '      localFilePath2 = System.IO.Path.Combine(localFolderPath, fileName)
    '      networkFilePath = System.IO.Path.Combine(networkFolderPath, fileName)
    '      ' sets rae update exe file path
    '      updateExeFilePath = "C:\Program Files\Rae_Auto_Update\Rae_Auto_Update.exe"

    '      'COPY FILESERVEF TXT FILE TO LOCAL MACHINES - READ FILE ON LOCAL MACHINE - NOT FILESERVER
    '      'so the fileserver file is not read by multiple users
    '      FileCopy(networkFilePath, localFilePath2)

    '      'OPEN .FO & .TXT FILES & GET REVISION NUMBERS FOR COMPARISON
    '      Dim ForceUpdate As Boolean = False
    '      If System.IO.File.Exists(localFilePath1) Then
    '         FileOpen(1, localFilePath1, OpenMode.Input)
    '         Input(1, currentVersion)
    '         FileClose(1)
    '         currentVersion = currentVersion.Replace(".", "")

    '         FileOpen(2, localFilePath2, OpenMode.Input)
    '         Input(2, latestVersion)
    '         FileClose(2)
    '         latestVersion = latestVersion.Replace(".", "")
    '      Else
    '         ' file does not exist - force update
    '         ForceUpdate = True
    '         updateRightNow = True
    '      End If

    '      'CHECK - IF NEWER VERSION IS AVAILABLE NOTIFY USER & ASK TO UPDATE
    '      If Val(latestVersion) > Val(currentVersion) Or ForceUpdate = True Then

    '         'If this is automatic update, do not give user a choice...
    '         If updateRightNow = True Then

    'UPDATE_PROGRAM_NOW2:

    '            'COPY FILE TO WORKING DIRECTORY(UPDATE_PROGRAM) FOR AUT UPDATE
    '            FileCopy(localFilePath2, localFolderPath & "UPDATE_PROGRAM\" & fileName)

    '            'KILL FILE THAT WAS READ
    '            Kill(localFilePath2)

    '            'OPEN AUTO UPDATE PROGRAM - FILES HAVE ALREADY BEEN COPIED TO AUTO UPDATE FOLDER
    '            Shell(updateExeFilePath, AppWinStyle.NormalNoFocus)
    '            'mCommon.OpenFileInAssociatedApplication(mGlobal.ApplicationPath & "WaitAndOpen.exe")

    '            'MUST END PROGRAM BEFORE IT IS UPDATED - IT WILL BE STARTED BACK UP FROM UPDATE PROGRAM
    '            closeApplication = True
    '            Return closeApplication
    '         Else
    '            'Not automatic update - give user option to update or not...
    '            Dim response As DialogResult
    '            response = MessageBox.Show( _
    '               "A newer version of this program is available." & Chr(10) & Chr(10) & "Do you want to update now?", _
    '               "RAESolutions", _
    '               MessageBoxButtons.YesNo, _
    '               MessageBoxIcon.Information)
    '            If response = DialogResult.Yes Then
    '               GoTo UPDATE_PROGRAM_NOW2
    '            Else
    '               'KILL FILE THAT WAS READ
    '               Kill(localFilePath2)
    '            End If
    '         End If
    '         'new version not available
    '      Else
    '         'KILL FILE THAT WAS READ
    '         Kill(localFilePath2)

    '         'if user initiates update then indicate that no update is available
    '         If updateRightNow = False Then
    '            MessageBox.Show("The latest version, " & versionWithDots & ", of this program is already installed. There are no new updates available at this time.", _
    '               "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '         End If
    '      End If

    '      Return closeApplication
    '      Exit Function

    'err_CHECK_FOR_NEWER_VERSION2:
    '      MessageBox.Show("An error has occured." & vbCrLf & vbTab & _
    '          "Procedure: CHECK_FOR_NEWER_VERSION" & vbCrLf & vbTab & _
    '          "Error Number: " & Err.Number & vbCrLf & vbTab & _
    '          "Error Description: " & Err.Description, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '   End Function

End Class
