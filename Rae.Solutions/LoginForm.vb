Imports System
Imports System.Environment
Imports System.Windows.Forms
Imports Rae.Security
Imports Rae.Ui.Validation
Imports Rae.RaeSolutions.Business
Imports Rae.solutions
Imports Rae.RaeSolutions.DataAccess


''' <summary>Form used to authenticate (login) user.</summary>
Public Class LoginForm

#Region " Event handlers"

    Private Sub form_Load(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.Load

        If Not AppInfo.IsLoggedIn Then
            AppInfo.Initialize()

        End If
        'If AppInfo.IsLoggedIn Then
        '    GroupBox1.Visible = True
        'End If
        IntegratedSecurity.ConnectionString.Initialize(AppInfo.DbFolderPath)
        

        Me.initializeValidation()

        Me.initializeControls()

        ' puts cursor in username text box
        Me.usernameTextBox.Focus()
    End Sub

    Private Sub okButton_Click() Handles loginButton.Click
        Me.Login()
    End Sub

    Private Sub closeButton_Click() Handles closeButton.Click
        Me.Close()
    End Sub



    Private Sub control_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
    Handles usernameTextBox.KeyDown, passwordTextBox.KeyDown, rememberCheckBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.Login()
            e.Handled = True
        End If
    End Sub

#End Region


    ''' <summary>Logs user into application. Validates and authenticates user credentials before opening application.</summary>
    Private Sub Login()
        ' validates user inputs
        If Not Me.loginValidationManager.Validate() Then
            Ui.MessageBox.Show(Me.loginValidationManager.ErrorMessagesSummary, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim username = Me.usernameTextBox.Text.Trim.ToUpper
        Dim password = Me.passwordTextBox.Text.Trim


        ' web authentication code

        Dim webAuthentication1 As New Security.IntegratedSecurity.WebAuthenticate(username, password)
        Dim webAuthenticationResult As Boolean = webAuthentication1.WebAuthenticate()







        Dim user = IdentityFactory.CreateIdentity(username, password)
        user.Authenticate()



        Select Case user.ExpirationWarningFlag
            Case WebAuthenticationExpirationStatus.SOON_TO_EXPIRE
                MsgBox("RAE Solutions has not been able to access the RAE Corporation network for over 45 days.  Your RAE Solutions account will expire soon.  Please contact RAE Corporation for technical support.", MsgBoxStyle.OkOnly, "Login Expiration")
            Case WebAuthenticationExpirationStatus.EXPIRED
                MsgBox("RAE Solutions has not been able to access the RAE Corporation network for over 60 days.  Your RAE Solutions account has expired.  Please contact RAE Corporation for technical support.", MsgBoxStyle.OkOnly, "Login Expiration")
                Exit Sub
        End Select


        If user.IsAuthenticated Then
            ' sets global authentication properties
            AppInfo.User.username = user.Username
            AppInfo.User.password = user.Password

            ' sets global authorization (division, role, and access)
            If Not Me.setDivisionAccessLevelFirstLastNameAndRole() Then
                Exit Sub
            End If

            ' checks if logged in already (if main form is already open)
            If Not AppInfo.IsLoggedIn Then
                ' shows main app
                Dim f As New MainForm() : f.Show()
                AppInfo.IsLoggedIn = True
                AppInfo.Main = f
                f.SetLoginDependentControls()

            Else
                CType(My.Application.ApplicationContext.MainForm, MainForm).SetLoginDependentControls()
            End If
            rememberOrForgetLoginSettingsBasedOnUserSelection()

            AppInfo.User.access_level = authorizePricing(AppInfo.User.access_level, Me.suppressPricingCheckBox.Checked)

            Me.Close()
        Else
            MessageBox.Show("The username or password is not valid.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
    End Sub


    Private Function authorizePricing( _
    ByVal currentAccess As access_level, ByVal pricingIsSuppressedForTesting As Boolean) As access_level
        Dim modifiedAccess As access_level

        If pricingIsSuppressedForTesting Then
            Select Case currentAccess
                Case access_level.CRI_P
                    modifiedAccess = access_level.CRI
                Case access_level.ALL_P
                    modifiedAccess = access_level.ALL
                Case access_level.TSI_P
                    modifiedAccess = access_level.TSI
                Case Else
                    modifiedAccess = currentAccess
            End Select
        Else
            modifiedAccess = currentAccess
        End If

        Return modifiedAccess
    End Function


#Region " Validation"

    Private loginValidationManager As ValidationManager
    Private usernameValidationControl, passwordValidationControl As ValidationControl


    ''' <summary>
    ''' Initializes validation (validation controls and validators).
    ''' </summary>
    Private Sub initializeValidation()
        Dim vrqUsername, vrqPassword As RequiredValidator

        Me.loginValidationManager = New ValidationManager(Me.loginErrorProvider)

        ' username
        Me.usernameValidationControl = New ValidationControl(Me.usernameTextBox)
        vrqUsername = New RequiredValidator("Username is required.")
        Me.usernameValidationControl.Validators.Add(vrqUsername)

        ' password
        Me.passwordValidationControl = New ValidationControl(Me.passwordTextBox)
        vrqPassword = New RequiredValidator("Password is required.")
        Me.passwordValidationControl.Validators.Add(vrqPassword)

        ' adds validation controls to validation manager
        Me.loginValidationManager.ValidationControls.Add(Me.usernameValidationControl)
        Me.loginValidationManager.ValidationControls.Add(Me.passwordValidationControl)
    End Sub


    Private Sub txtUsername_Leave(ByVal sender As Object, ByVal e As EventArgs) _
    Handles usernameTextBox.Leave
        Me.usernameValidationControl.Validate()
    End Sub

    Private Sub txtPassword_Leave(ByVal sender As Object, ByVal e As EventArgs) _
    Handles passwordTextBox.Leave
        Me.passwordValidationControl.Validate()
    End Sub

#End Region


#Region " Settings"

    ''' <summary>
    ''' Loads saved settings. If an upgrade (version increase) occurred, the previous version's settings are loaded.
    ''' </summary>
    Private Sub loadSettings()
        My.Settings.Reload()
        If My.Settings.IsSettingsUpgradeRequired Then
            My.Settings.Upgrade()
            My.Settings.IsSettingsUpgradeRequired = False
            My.Settings.Save()
        End If
    End Sub


    Private Sub autoCompleteBasedOnStoredLoginSettings()
        Me.usernameTextBox.Text = My.Settings.Username
        Me.passwordTextBox.Text = My.Settings.Password
        Select Case My.Settings.Division.ToUpper
            Case "TSI" : Me.technicalSystemsRadioButton.Checked = True
            Case "CRI" : Me.centuryRadioButton.Checked = True
        End Select
        Me.rememberCheckBox.Checked = My.Settings.RememberLogin
    End Sub

    Private Sub rememberLogin()
        My.Settings.RememberLogin = True
        My.Settings.Username = Me.usernameTextBox.Text
        My.Settings.Password = Me.passwordTextBox.Text
        If Me.technicalSystemsRadioButton.Checked Then
            My.Settings.Division = "TSI"
        ElseIf Me.centuryRadioButton.Checked Then
            My.Settings.Division = "CRI"
        End If

        My.Settings.Save()
    End Sub

    Private Sub forgetLogin()
        My.Settings.RememberLogin = False
        My.Settings.Username = ""
        My.Settings.Password = ""
        My.Settings.Division = ""

        My.Settings.Save()
    End Sub

    Private Sub rememberOrForgetLoginSettingsBasedOnUserSelection()
        If Me.rememberCheckBox.Checked Then
            Me.rememberLogin()
        Else
            Me.forgetLogin()
        End If
    End Sub

#End Region


    Private Sub initializeControls()
        'shows/ hides role section
        Me.determineRoleSectionVisibility()
        ' collapses credentials section
        '    Me.credentialsHeader.Toggle()
        'loads settings if they haven't been loaded yet
        If Not AppInfo.IsLoggedIn Then
            Me.loadSettings()
        End If
        If My.Settings.RememberLogin Then
            ' fills out login controls
            Me.autoCompleteBasedOnStoredLoginSettings()
        End If
    End Sub


    '' <summary>Shows/hides role (authorization) section.</summary>
    Private Sub determineRoleSectionVisibility()
        If AppInfo.User.authority_group = user_group.employee Then
            GroupBox1.Visible = True
            GroupBox1.Visible = True
        ElseIf AppInfo.User.authority_group = user_group.rep Then
            GroupBox1.Visible = False
            GroupBox1.Visible = False
        End If
    End Sub


    Private Function setDivisionAccessLevelFirstLastNameAndRole() As Boolean
        ' sets division
        If Me.centuryRadioButton.Checked Then
            AppInfo.Division = Business.Division.CRI
        ElseIf Me.technicalSystemsRadioButton.Checked Then
            AppInfo.Division = Business.Division.TSI
        End If

        ' sets access level
        Dim userData As New IntegratedSecurity.IdentityData(AppInfo.User.username)
        AppInfo.User.access_level = userData.Access
        AppInfo.User.authority_group = userData.AuthorityGroup

        ' allows employees to impersonate reps
        If AppInfo.User.authority_group = user_group.employee Then
            If Me.repRadioButton.Checked Then
                AppInfo.User.authority_group = user_group.rep
            End If
        End If

        ' sets user's first and last name
        '
        Dim firstNameLength As Integer = userData.Name.IndexOf(" ")
        Dim lastNameLength As Integer = userData.Name.Length - firstNameLength - 1
        ' parses user's first name (assumes first and last name are seperated by a space)
        AppInfo.User.first_name = userData.Name.Substring(0, firstNameLength)
        ' parses user's last name
        AppInfo.User.last_name = userData.Name.Substring(firstNameLength + 1, lastNameLength)

        Return Me.ensureValidDivisionIsSelected()
    End Function

    Private Sub technicalSystemsRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles technicalSystemsRadioButton.CheckedChanged

    End Sub

    Private Sub authenticationPanel_Paint(sender As Object, e As PaintEventArgs) Handles authenticationPanel.Paint

    End Sub

    ''' <summary>
    ''' Ensures that the user logging in has permissions for the selected division.
    ''' Changes division selection if necessary.
    ''' </summary>
    Private Function ensureValidDivisionIsSelected() As Boolean
        ' checks which company was selected and sets division
        If Me.technicalSystemsRadioButton.Checked Then
            'checks if user has authorization for selected company access
            If AppInfo.User.access_level = access_level.ALL Or AppInfo.User.access_level = access_level.ALL_P Or AppInfo.User.access_level = access_level.TSI Or AppInfo.User.access_level = access_level.TSI_P Then
                ' sets division to selected division
                AppInfo.Division = Division.TSI
                Return True
                ' if does NOT access to TSI then does have access to CRI
            Else
                Ui.MessageBox.Show("The username entered does not have authorization to select Technical Systems. ", MessageBoxIcon.Warning)
                Return False
            End If
            ' checks if user selected Century
        ElseIf Me.centuryRadioButton.Checked Then
            ' checks if user has company access to century
            If AppInfo.User.access_level = access_level.ALL Or AppInfo.User.access_level = access_level.ALL_P Or AppInfo.User.access_level = access_level.CRI Or AppInfo.User.access_level = access_level.CRI_P Then
                AppInfo.Division = Division.CRI
                Return True
            Else
                Ui.MessageBox.Show("The username entered does not have authorization to select Century. ", MessageBoxIcon.Warning)
                Return False
            End If
        Else
            If AppInfo.User.access_level = access_level.ALL Or _
            AppInfo.User.access_level = access_level.ALL_P Then
                AppInfo.Division = Division.RSI
                Return True
            Else
                Ui.MessageBox.Show("The username entered does not have authorization to select RSI. ", MessageBoxIcon.Warning)
                Return False

            End If

        End If

        Return False

    End Function


    ' ''' <summary>Downloads latest credentials and notifies user of progress.</summary>
    'Private Function downloadCredentials() As Outcome
    '    Const dbName As String = "UserNamePassword_Encrypted.mdb"
    '    Dim networkPath, localPath As String
    '    Dim ftpAddress As String

    '    ' changes cursor to hourglass
    '    Me.Cursor = Cursors.WaitCursor
    '    ' sets appropriate ftp address depending on computer location
    '    ftpAddress = AppInfo.FileserverFTPAddress
    '    ' sets the path that the file will be copied to
    '    '        localPath = AppInfo.AppFolderPath & "Databases\" & dbName


    '    localPath = AppInfo.DbFolderPath & dbName



    '    ' gets download path of new database
    '    ' Q: user isn't logged in yet, how do you know if they're rep or employee
    '    ' A: user type (rep or rae) is determined at design time during compilation 
    '    If Constants.TARGET_USER_GROUP = user_group.rep Then
    '        ' notifies user download started
    '        Dim downloadForm As New DownloadProgressForm()
    '        downloadForm.Show()
    '        ' if usertype is rep, gets password database from ftp site and notifies user if exception occurs
    '        If mFTP.FTPCopy(localPath, dbName, ftpAddress) = Outcome.Failed Then
    '            Me.Cursor = Cursors.Arrow : Return Outcome.Failed
    '        End If
    '    ElseIf Constants.TARGET_USER_GROUP = user_group.employee Then
    '        ' if usertype is rae, get password database from RAE's network location
    '        networkPath = "\\" & Constants.FILESERVER1_INTERNAL_IP & "\FileSer1_E\RAESolutions\Databases\" & dbName
    '        ' checks if file exists
    '        If Not System.IO.File.Exists(networkPath) Then
    '            Ui.MessageBox.Show("User information at " & networkPath & " cannot be found.")
    '            Me.Cursor = Cursors.Arrow : Return Outcome.Failed
    '        End If
    '        ' copies updated file to local machine
    '        Try
    '            System.IO.File.Copy(networkPath, localPath, True)
    '            'UnauthorizedAccessException, if file is ReadOnly
    '        Catch ex As Exception
    '            Ui.MessageBox.Show("Attempt to update user info failed during copy procedure. " & _
    '               NewLine & NewLine & ex.Message)
    '            Me.Cursor = Cursors.Arrow : Return Outcome.Failed
    '        End Try
    '    End If

    '    Me.Cursor = Cursors.Arrow
    '    ' notifies user download is complete
    '    Ui.MessageBox.Show("Credentials update succeeded.", MessageBoxIcon.Information)

    '    Return Outcome.Succeeded
    'End Function


End Class
