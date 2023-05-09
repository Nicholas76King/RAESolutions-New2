<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        Me.loginButton = New System.Windows.Forms.Button()
        Me.closeButton = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.authenticationPanel = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.usernameTextBox = New System.Windows.Forms.TextBox()
        Me.rememberCheckBox = New System.Windows.Forms.CheckBox()
        Me.usernameLabel = New System.Windows.Forms.Label()
        Me.passwordTextBox = New System.Windows.Forms.TextBox()
        Me.passwordLabel = New System.Windows.Forms.Label()
        Me.helpPictureBox = New System.Windows.Forms.PictureBox()
        Me.loginErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.divisionPanel = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.centuryRadioButton = New System.Windows.Forms.RadioButton()
        Me.rsiRadioButton = New System.Windows.Forms.RadioButton()
        Me.technicalSystemsRadioButton = New System.Windows.Forms.RadioButton()
        Me.authorizationPanel = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.employeeRadioButton = New System.Windows.Forms.RadioButton()
        Me.suppressPricingCheckBox = New System.Windows.Forms.CheckBox()
        Me.repRadioButton = New System.Windows.Forms.RadioButton()
        Me.authenticationPanel.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.helpPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.loginErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.divisionPanel.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.authorizationPanel.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'loginButton
        '
        Me.loginButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.loginButton.Location = New System.Drawing.Point(119, 371)
        Me.loginButton.Margin = New System.Windows.Forms.Padding(3, 6, 3, 4)
        Me.loginButton.Name = "loginButton"
        Me.loginButton.Size = New System.Drawing.Size(75, 25)
        Me.loginButton.TabIndex = 5
        Me.loginButton.Text = "Login"
        Me.loginButton.UseVisualStyleBackColor = True
        '
        'closeButton
        '
        Me.closeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.closeButton.Location = New System.Drawing.Point(200, 371)
        Me.closeButton.Margin = New System.Windows.Forms.Padding(3, 6, 12, 4)
        Me.closeButton.Name = "closeButton"
        Me.closeButton.Size = New System.Drawing.Size(75, 25)
        Me.closeButton.TabIndex = 6
        Me.closeButton.Text = "Cancel"
        Me.closeButton.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Fuchsia
        Me.ImageList1.Images.SetKeyName(0, "userAccounts.bmp")
        Me.ImageList1.Images.SetKeyName(1, "keys.bmp")
        Me.ImageList1.Images.SetKeyName(2, "user.bmp")
        '
        'authenticationPanel
        '
        Me.authenticationPanel.Controls.Add(Me.GroupBox3)
        Me.authenticationPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.authenticationPanel.Location = New System.Drawing.Point(0, 0)
        Me.authenticationPanel.Name = "authenticationPanel"
        Me.authenticationPanel.Size = New System.Drawing.Size(296, 117)
        Me.authenticationPanel.TabIndex = 2
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.usernameTextBox)
        Me.GroupBox3.Controls.Add(Me.rememberCheckBox)
        Me.GroupBox3.Controls.Add(Me.usernameLabel)
        Me.GroupBox3.Controls.Add(Me.passwordTextBox)
        Me.GroupBox3.Controls.Add(Me.passwordLabel)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(279, 108)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Authentication"
        '
        'usernameTextBox
        '
        Me.usernameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.usernameTextBox.Location = New System.Drawing.Point(73, 14)
        Me.usernameTextBox.Margin = New System.Windows.Forms.Padding(3, 6, 12, 3)
        Me.usernameTextBox.Name = "usernameTextBox"
        Me.usernameTextBox.Size = New System.Drawing.Size(186, 21)
        Me.usernameTextBox.TabIndex = 1
        '
        'rememberCheckBox
        '
        Me.rememberCheckBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rememberCheckBox.Location = New System.Drawing.Point(25, 68)
        Me.rememberCheckBox.Name = "rememberCheckBox"
        Me.rememberCheckBox.Size = New System.Drawing.Size(235, 21)
        Me.rememberCheckBox.TabIndex = 3
        Me.rememberCheckBox.Text = "Remember login info"
        Me.rememberCheckBox.UseVisualStyleBackColor = True
        '
        'usernameLabel
        '
        Me.usernameLabel.Location = New System.Drawing.Point(5, 14)
        Me.usernameLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.usernameLabel.Name = "usernameLabel"
        Me.usernameLabel.Size = New System.Drawing.Size(61, 21)
        Me.usernameLabel.TabIndex = 6
        Me.usernameLabel.Text = "Username"
        Me.usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'passwordTextBox
        '
        Me.passwordTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.passwordTextBox.Location = New System.Drawing.Point(73, 41)
        Me.passwordTextBox.Margin = New System.Windows.Forms.Padding(3, 3, 12, 3)
        Me.passwordTextBox.Name = "passwordTextBox"
        Me.passwordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.passwordTextBox.Size = New System.Drawing.Size(186, 21)
        Me.passwordTextBox.TabIndex = 2
        '
        'passwordLabel
        '
        Me.passwordLabel.Location = New System.Drawing.Point(8, 41)
        Me.passwordLabel.Name = "passwordLabel"
        Me.passwordLabel.Size = New System.Drawing.Size(58, 21)
        Me.passwordLabel.TabIndex = 8
        Me.passwordLabel.Text = "Password"
        Me.passwordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'helpPictureBox
        '
        Me.helpPictureBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.helpPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.helpPictureBox.Image = CType(resources.GetObject("helpPictureBox.Image"), System.Drawing.Image)
        Me.helpPictureBox.Location = New System.Drawing.Point(7, 371)
        Me.helpPictureBox.Name = "helpPictureBox"
        Me.helpPictureBox.Size = New System.Drawing.Size(24, 25)
        Me.helpPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.helpPictureBox.TabIndex = 12
        Me.helpPictureBox.TabStop = False
        Me.helpPictureBox.Visible = False
        '
        'loginErrorProvider
        '
        Me.loginErrorProvider.ContainerControl = Me
        Me.loginErrorProvider.Icon = CType(resources.GetObject("loginErrorProvider.Icon"), System.Drawing.Icon)
        '
        'divisionPanel
        '
        Me.divisionPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.divisionPanel.Controls.Add(Me.GroupBox2)
        Me.divisionPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.divisionPanel.Location = New System.Drawing.Point(0, 117)
        Me.divisionPanel.Name = "divisionPanel"
        Me.divisionPanel.Size = New System.Drawing.Size(296, 125)
        Me.divisionPanel.TabIndex = 15
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.centuryRadioButton)
        Me.GroupBox2.Controls.Add(Me.rsiRadioButton)
        Me.GroupBox2.Controls.Add(Me.technicalSystemsRadioButton)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(279, 99)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Division"
        '
        'centuryRadioButton
        '
        Me.centuryRadioButton.Checked = True
        Me.centuryRadioButton.Location = New System.Drawing.Point(6, 20)
        Me.centuryRadioButton.Name = "centuryRadioButton"
        Me.centuryRadioButton.Size = New System.Drawing.Size(228, 21)
        Me.centuryRadioButton.TabIndex = 0
        Me.centuryRadioButton.TabStop = True
        Me.centuryRadioButton.Text = "Century Refrigeration"
        Me.centuryRadioButton.UseVisualStyleBackColor = True
        '
        'rsiRadioButton
        '
        Me.rsiRadioButton.Location = New System.Drawing.Point(6, 69)
        Me.rsiRadioButton.Name = "rsiRadioButton"
        Me.rsiRadioButton.Size = New System.Drawing.Size(228, 21)
        Me.rsiRadioButton.TabIndex = 2
        Me.rsiRadioButton.Text = "Refrigeration Systems"
        Me.rsiRadioButton.UseVisualStyleBackColor = True
        Me.rsiRadioButton.Visible = False
        '
        'technicalSystemsRadioButton
        '
        Me.technicalSystemsRadioButton.Location = New System.Drawing.Point(6, 47)
        Me.technicalSystemsRadioButton.Name = "technicalSystemsRadioButton"
        Me.technicalSystemsRadioButton.Size = New System.Drawing.Size(228, 21)
        Me.technicalSystemsRadioButton.TabIndex = 1
        Me.technicalSystemsRadioButton.Text = "Technical Systems"
        Me.technicalSystemsRadioButton.UseVisualStyleBackColor = True
        '
        'authorizationPanel
        '
        Me.authorizationPanel.Controls.Add(Me.GroupBox1)
        Me.authorizationPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.authorizationPanel.Location = New System.Drawing.Point(0, 242)
        Me.authorizationPanel.Name = "authorizationPanel"
        Me.authorizationPanel.Size = New System.Drawing.Size(296, 116)
        Me.authorizationPanel.TabIndex = 17
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.employeeRadioButton)
        Me.GroupBox1.Controls.Add(Me.suppressPricingCheckBox)
        Me.GroupBox1.Controls.Add(Me.repRadioButton)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(279, 107)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Roles"
        Me.GroupBox1.Visible = False
        '
        'employeeRadioButton
        '
        Me.employeeRadioButton.Checked = True
        Me.employeeRadioButton.Location = New System.Drawing.Point(6, 20)
        Me.employeeRadioButton.Name = "employeeRadioButton"
        Me.employeeRadioButton.Size = New System.Drawing.Size(228, 21)
        Me.employeeRadioButton.TabIndex = 2
        Me.employeeRadioButton.TabStop = True
        Me.employeeRadioButton.Text = "Employee"
        Me.employeeRadioButton.UseVisualStyleBackColor = True
        '
        'suppressPricingCheckBox
        '
        Me.suppressPricingCheckBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.suppressPricingCheckBox.Location = New System.Drawing.Point(6, 74)
        Me.suppressPricingCheckBox.Name = "suppressPricingCheckBox"
        Me.suppressPricingCheckBox.Size = New System.Drawing.Size(287, 21)
        Me.suppressPricingCheckBox.TabIndex = 4
        Me.suppressPricingCheckBox.Text = "Suppress pricing"
        Me.suppressPricingCheckBox.UseVisualStyleBackColor = True
        '
        'repRadioButton
        '
        Me.repRadioButton.Location = New System.Drawing.Point(6, 47)
        Me.repRadioButton.Name = "repRadioButton"
        Me.repRadioButton.Size = New System.Drawing.Size(228, 21)
        Me.repRadioButton.TabIndex = 3
        Me.repRadioButton.Text = "Rep"
        Me.repRadioButton.UseVisualStyleBackColor = True
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(296, 409)
        Me.Controls.Add(Me.helpPictureBox)
        Me.Controls.Add(Me.authorizationPanel)
        Me.Controls.Add(Me.divisionPanel)
        Me.Controls.Add(Me.closeButton)
        Me.Controls.Add(Me.loginButton)
        Me.Controls.Add(Me.authenticationPanel)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LoginForm"
        Me.Text = "Login"
        Me.authenticationPanel.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.helpPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.loginErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.divisionPanel.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.authorizationPanel.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents loginButton As System.Windows.Forms.Button
   Friend WithEvents closeButton As System.Windows.Forms.Button
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents authenticationPanel As System.Windows.Forms.Panel
    'Friend WithEvents gradientBar As RAE.UI.Controls.GradientPanel
    Friend WithEvents helpPictureBox As System.Windows.Forms.PictureBox
   Friend WithEvents rememberCheckBox As System.Windows.Forms.CheckBox
   Friend WithEvents passwordTextBox As System.Windows.Forms.TextBox
   Friend WithEvents passwordLabel As System.Windows.Forms.Label
   Friend WithEvents usernameTextBox As System.Windows.Forms.TextBox
   Friend WithEvents usernameLabel As System.Windows.Forms.Label
   Friend WithEvents loginErrorProvider As System.Windows.Forms.ErrorProvider
    'Friend WithEvents authenticationHeader As RAE.UI.Controls.CollapsableHeader
    Friend WithEvents divisionPanel As System.Windows.Forms.Panel
    'Friend WithEvents divisionHeader As RAE.UI.Controls.CollapsableHeader
    Friend WithEvents technicalSystemsRadioButton As System.Windows.Forms.RadioButton
   Friend WithEvents centuryRadioButton As System.Windows.Forms.RadioButton
   Friend WithEvents authorizationPanel As System.Windows.Forms.Panel
   Friend WithEvents repRadioButton As System.Windows.Forms.RadioButton
   Friend WithEvents employeeRadioButton As System.Windows.Forms.RadioButton
    'Friend WithEvents authorizationHeader As RAE.UI.Controls.CollapsableHeader
    Friend WithEvents suppressPricingCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents rsiRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
End Class
