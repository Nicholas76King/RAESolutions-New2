Option Strict On
Option Explicit On 

Imports CNull = Rae.ConvertNull
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.Business

Public Class CompanyForm
   Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

   Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call
      Me.company_ = New Company()
   End Sub

   'Form overrides dispose to clean up the component list.
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If Not (components Is Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents ok As System.Windows.Forms.Button
   Friend WithEvents cancel As System.Windows.Forms.Button
   Friend WithEvents headerLabel As System.Windows.Forms.Label
   Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
   Friend WithEvents accountNumberTextBox As System.Windows.Forms.TextBox
   Friend WithEvents accountNumberLabel As System.Windows.Forms.Label
   Friend WithEvents nameText As System.Windows.Forms.TextBox
   Friend WithEvents lblName As System.Windows.Forms.Label
   Friend WithEvents lblRightParenthesis As System.Windows.Forms.Label
   Friend WithEvents lblLeftParenthesis As System.Windows.Forms.Label
   Friend WithEvents lblFaxNum As System.Windows.Forms.Label
   Friend WithEvents faxNumAreaCodeText As System.Windows.Forms.TextBox
   Friend WithEvents emailText As System.Windows.Forms.TextBox
   Friend WithEvents lblEmail As System.Windows.Forms.Label
   Friend WithEvents websiteText As System.Windows.Forms.TextBox
   Friend WithEvents lblWebsite As System.Windows.Forms.Label
   Friend WithEvents repCompanyAddressControl As AddressControl
   Friend WithEvents faxNumText As System.Windows.Forms.MaskedTextBox
   Friend WithEvents repCompanyPhoneControl As PhoneControl
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CompanyForm))
      Me.accountNumberTextBox = New System.Windows.Forms.TextBox
      Me.accountNumberLabel = New System.Windows.Forms.Label
      Me.GroupBox1 = New System.Windows.Forms.GroupBox
      Me.faxNumText = New System.Windows.Forms.MaskedTextBox
      Me.websiteText = New System.Windows.Forms.TextBox
      Me.lblWebsite = New System.Windows.Forms.Label
      Me.lblRightParenthesis = New System.Windows.Forms.Label
      Me.lblLeftParenthesis = New System.Windows.Forms.Label
      Me.lblFaxNum = New System.Windows.Forms.Label
      Me.faxNumAreaCodeText = New System.Windows.Forms.TextBox
      Me.emailText = New System.Windows.Forms.TextBox
      Me.lblEmail = New System.Windows.Forms.Label
      Me.repCompanyPhoneControl = New Rae.RaeSolutions.PhoneControl
      Me.repCompanyAddressControl = New Rae.RaeSolutions.AddressControl
      Me.nameText = New System.Windows.Forms.TextBox
      Me.lblName = New System.Windows.Forms.Label
      Me.ok = New System.Windows.Forms.Button
      Me.cancel = New System.Windows.Forms.Button
      Me.headerLabel = New System.Windows.Forms.Label
      Me.PictureBox1 = New System.Windows.Forms.PictureBox
      Me.GroupBox1.SuspendLayout()
      CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'accountNumberTextBox
      '
      Me.accountNumberTextBox.Location = New System.Drawing.Point(84, 24)
      Me.accountNumberTextBox.Name = "accountNumberTextBox"
      Me.accountNumberTextBox.Size = New System.Drawing.Size(100, 21)
      Me.accountNumberTextBox.TabIndex = 0
      '
      'accountNumberLabel
      '
      Me.accountNumberLabel.Location = New System.Drawing.Point(8, 24)
      Me.accountNumberLabel.Name = "accountNumberLabel"
      Me.accountNumberLabel.Size = New System.Drawing.Size(64, 23)
      Me.accountNumberLabel.TabIndex = 1
      Me.accountNumberLabel.Text = "Account #"
      Me.accountNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'GroupBox1
      '
      Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.GroupBox1.Controls.Add(Me.faxNumText)
      Me.GroupBox1.Controls.Add(Me.websiteText)
      Me.GroupBox1.Controls.Add(Me.lblWebsite)
      Me.GroupBox1.Controls.Add(Me.lblRightParenthesis)
      Me.GroupBox1.Controls.Add(Me.lblLeftParenthesis)
      Me.GroupBox1.Controls.Add(Me.lblFaxNum)
      Me.GroupBox1.Controls.Add(Me.faxNumAreaCodeText)
      Me.GroupBox1.Controls.Add(Me.emailText)
      Me.GroupBox1.Controls.Add(Me.lblEmail)
      Me.GroupBox1.Controls.Add(Me.repCompanyPhoneControl)
      Me.GroupBox1.Controls.Add(Me.repCompanyAddressControl)
      Me.GroupBox1.Controls.Add(Me.nameText)
      Me.GroupBox1.Controls.Add(Me.lblName)
      Me.GroupBox1.Controls.Add(Me.accountNumberTextBox)
      Me.GroupBox1.Controls.Add(Me.accountNumberLabel)
      Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.GroupBox1.Location = New System.Drawing.Point(16, 40)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(336, 376)
      Me.GroupBox1.TabIndex = 2
      Me.GroupBox1.TabStop = False
      '
      'txtFaxNum
      '
      Me.faxNumText.Location = New System.Drawing.Point(127, 272)
      Me.faxNumText.Mask = "000-0000"
      Me.faxNumText.Name = "txtFaxNum"
      Me.faxNumText.Size = New System.Drawing.Size(63, 21)
      Me.faxNumText.TabIndex = 8
      '
      'txtWebsite
      '
      Me.websiteText.Location = New System.Drawing.Point(84, 336)
      Me.websiteText.Name = "txtWebsite"
      Me.websiteText.Size = New System.Drawing.Size(224, 21)
      Me.websiteText.TabIndex = 12
      '
      'lblWebsite
      '
      Me.lblWebsite.Location = New System.Drawing.Point(8, 336)
      Me.lblWebsite.Name = "lblWebsite"
      Me.lblWebsite.Size = New System.Drawing.Size(64, 23)
      Me.lblWebsite.TabIndex = 149
      Me.lblWebsite.Text = "Website"
      Me.lblWebsite.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblRightParenthesis
      '
      Me.lblRightParenthesis.Location = New System.Drawing.Point(112, 272)
      Me.lblRightParenthesis.Name = "lblRightParenthesis"
      Me.lblRightParenthesis.Size = New System.Drawing.Size(12, 23)
      Me.lblRightParenthesis.TabIndex = 148
      Me.lblRightParenthesis.Text = ")"
      Me.lblRightParenthesis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblLeftParenthesis
      '
      Me.lblLeftParenthesis.Location = New System.Drawing.Point(72, 272)
      Me.lblLeftParenthesis.Name = "lblLeftParenthesis"
      Me.lblLeftParenthesis.Size = New System.Drawing.Size(12, 23)
      Me.lblLeftParenthesis.TabIndex = 147
      Me.lblLeftParenthesis.Text = "("
      Me.lblLeftParenthesis.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblFaxNum
      '
      Me.lblFaxNum.Location = New System.Drawing.Point(8, 272)
      Me.lblFaxNum.Name = "lblFaxNum"
      Me.lblFaxNum.Size = New System.Drawing.Size(64, 23)
      Me.lblFaxNum.TabIndex = 146
      Me.lblFaxNum.Text = "Fax"
      Me.lblFaxNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtFaxNumAreaCode
      '
      Me.faxNumAreaCodeText.Location = New System.Drawing.Point(84, 272)
      Me.faxNumAreaCodeText.Name = "txtFaxNumAreaCode"
      Me.faxNumAreaCodeText.Size = New System.Drawing.Size(28, 21)
      Me.faxNumAreaCodeText.TabIndex = 7
      '
      'txtEmail
      '
      Me.emailText.Location = New System.Drawing.Point(84, 304)
      Me.emailText.Name = "txtEmail"
      Me.emailText.Size = New System.Drawing.Size(224, 21)
      Me.emailText.TabIndex = 10
      '
      'lblEmail
      '
      Me.lblEmail.Location = New System.Drawing.Point(8, 304)
      Me.lblEmail.Name = "lblEmail"
      Me.lblEmail.Size = New System.Drawing.Size(64, 23)
      Me.lblEmail.TabIndex = 142
      Me.lblEmail.Text = "Email"
      Me.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'repCompanyPhoneControl
      '
      Me.repCompanyPhoneControl.BackColor = System.Drawing.Color.White
      Me.repCompanyPhoneControl.ExtensionVisible = True
      Me.repCompanyPhoneControl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.repCompanyPhoneControl.Location = New System.Drawing.Point(28, 224)
      Me.repCompanyPhoneControl.Name = "repCompanyPhoneControl"
      Me.repCompanyPhoneControl.PhoneNum = Nothing
      Me.repCompanyPhoneControl.Size = New System.Drawing.Size(248, 40)
      Me.repCompanyPhoneControl.TabIndex = 5
      '
      'repCompanyAddressControl
      '
      Me.repCompanyAddressControl.BackColor = System.Drawing.Color.White
      Me.repCompanyAddressControl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.repCompanyAddressControl.Location = New System.Drawing.Point(24, 84)
      Me.repCompanyAddressControl.Name = "repCompanyAddressControl"
      Me.repCompanyAddressControl.Size = New System.Drawing.Size(296, 136)
      Me.repCompanyAddressControl.TabIndex = 4
      '
      'txtName
      '
      Me.nameText.Location = New System.Drawing.Point(84, 56)
      Me.nameText.Name = "txtName"
      Me.nameText.Size = New System.Drawing.Size(220, 21)
      Me.nameText.TabIndex = 2
      '
      'lblName
      '
      Me.lblName.Location = New System.Drawing.Point(8, 56)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(64, 23)
      Me.lblName.TabIndex = 3
      Me.lblName.Text = "Name"
      Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ok
      '
      Me.ok.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ok.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ok.Location = New System.Drawing.Point(196, 432)
      Me.ok.Name = "ok"
      Me.ok.Size = New System.Drawing.Size(75, 23)
      Me.ok.TabIndex = 14
      Me.ok.Text = "OK"
      '
      'cancel
      '
      Me.cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cancel.Location = New System.Drawing.Point(280, 432)
      Me.cancel.Name = "cancel"
      Me.cancel.Size = New System.Drawing.Size(75, 23)
      Me.cancel.TabIndex = 15
      Me.cancel.Text = "Cancel"
      '
      'headerLabel
      '
      Me.headerLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.headerLabel.ForeColor = System.Drawing.Color.RoyalBlue
      Me.headerLabel.Location = New System.Drawing.Point(60, 20)
      Me.headerLabel.Name = "headerLabel"
      Me.headerLabel.Size = New System.Drawing.Size(192, 24)
      Me.headerLabel.TabIndex = 5
      Me.headerLabel.Text = "Company Profile"
      Me.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'PictureBox1
      '
      Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
      Me.PictureBox1.Location = New System.Drawing.Point(20, 12)
      Me.PictureBox1.Name = "PictureBox1"
      Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
      Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.PictureBox1.TabIndex = 6
      Me.PictureBox1.TabStop = False
      '
      'CompanyForm
      '
      Me.AcceptButton = Me.ok
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
      Me.BackColor = System.Drawing.Color.White
      Me.ClientSize = New System.Drawing.Size(368, 466)
      Me.ControlBox = False
      Me.Controls.Add(Me.PictureBox1)
      Me.Controls.Add(Me.headerLabel)
      Me.Controls.Add(Me.cancel)
      Me.Controls.Add(Me.ok)
      Me.Controls.Add(Me.GroupBox1)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Name = "CompanyForm"
      Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
      Me.Text = "Company Profile"
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region


   Protected company_ As Company
   ''' <summary>Rep company object representing control values</summary>
   Public Property Company() As Company
      Get
         Return Me.company_
      End Get
      Set(ByVal value As Company)
         Me.company_ = value
         onlyShowAccountNumToRepresentatives(value.Role)
      End Set
   End Property



#Region " Methods"

   ''' <summary>Refreshes rep company object based on control values</summary>
   Public Sub RefreshData()
      If Me.DesignMode Then Exit Sub

      With Me.company_
         .CustomerNum.set_to(Me.accountNumberTextBox.Text.Trim)

         .Name = Me.nameText.Text.Trim
         Me.repCompanyAddressControl.RefreshData()

         .Address = Me.repCompanyAddressControl.Address.Clone()

         .PhoneNum = Me.repCompanyPhoneControl.PhoneNum.Clone()
         .FaxNum.AreaCode.set_to(Me.faxNumAreaCodeText.Text.Trim)
         .FaxNum.Number.set_to(Me.faxNumText.Text.Replace(" ", "").Replace("-", "").Trim)

         .Email.Address = Me.emailText.Text.Trim
         .Website = Me.websiteText.Text.Trim
      End With
   End Sub


   ''' <summary>Updates control values based on rep company object</summary>
   Public Sub UpdateControls()
      If Me.DesignMode = True Then Exit Sub
      If Me.company_ Is Nothing Then Exit Sub

      Me.accountNumberTextBox.Text = Me.company_.CustomerNum.ToString
      Me.nameText.Text = Me.company_.Name

      ' updates address
      Me.repCompanyAddressControl.Address = Me.company_.Address
      Me.repCompanyAddressControl.UpdateControls()

      ' updates contact numbers
      Me.repCompanyPhoneControl.PhoneNum = Me.company_.PhoneNum
      Me.faxNumAreaCodeText.Text = Me.company_.FaxNum.AreaCode.ToString
      Me.faxNumText.Text = Me.company_.FaxNum.Number.ToString

      Me.emailText.Text = Me.company_.Email.Address
      Me.websiteText.Text = Me.company_.Website
   End Sub




   Private Sub companyForm_Load(ByVal sender As Object, ByVal e As EventArgs) _
   Handles MyBase.Load
      If Me.DesignMode = True Then Exit Sub
      ' updates controls in rep company form
      If Not Me.Company Is Nothing Then Me.UpdateControls()
   End Sub


   Private Sub ok_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles ok.Click
      Me.DialogResult = DialogResult.OK
      Me.Hide()
   End Sub


   Private Sub cancel_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles cancel.Click
      Me.DialogResult = DialogResult.Cancel
      Me.Hide()
   End Sub


   Private Sub onlyShowAccountNumToRepresentatives(ByVal role As String)
      If role IsNot Nothing _
      AndAlso role = Contact.Roles.Representative Then
         Me.accountNumberTextBox.Visible = True
         Me.accountNumberLabel.Visible = True
      Else
         Me.accountNumberTextBox.Visible = False
         Me.accountNumberLabel.Visible = False
      End If

   End Sub

#End Region

End Class
