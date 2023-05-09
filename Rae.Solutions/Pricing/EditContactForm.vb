Option Strict On
Option Explicit On 

Imports Forms = System.Windows.Forms
Imports Rae.RaeSolutions.DataAccess
Imports Rae.RaeSolutions.Business.Entities


Public Class EditContactForm
   Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

   Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call
      ' initializes members
      Me.initializeMembers()
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
   Friend WithEvents lblLastNameRequired As System.Windows.Forms.Label
   Friend WithEvents lblFirstNameRequired As System.Windows.Forms.Label
   Friend WithEvents txtLastName As System.Windows.Forms.TextBox
   Friend WithEvents lblLastName As System.Windows.Forms.Label
   Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
   Friend WithEvents lblFirstName As System.Windows.Forms.Label
   Friend WithEvents lblProfile As System.Windows.Forms.Label
   Friend WithEvents lblCompany As System.Windows.Forms.Label
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents btnOk As System.Windows.Forms.Button
   Friend WithEvents gboRep As System.Windows.Forms.GroupBox
   Friend WithEvents cboCompany As System.Windows.Forms.ComboBox
   Friend WithEvents tip As System.Windows.Forms.ToolTip
   Friend WithEvents picRep As System.Windows.Forms.PictureBox
   Friend WithEvents lblEmail As System.Windows.Forms.Label
   Friend WithEvents txtEmail As System.Windows.Forms.TextBox
   Friend WithEvents txtFaxNumAreaCode As System.Windows.Forms.TextBox
   Friend WithEvents lblFaxNum As System.Windows.Forms.Label
   Friend WithEvents lblLeftParenthesis As System.Windows.Forms.Label
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents repAddress As AddressControl
   Friend WithEvents repPhoneNum As PhoneControl
   Friend WithEvents txtFaxNum As System.Windows.Forms.MaskedTextBox
   Friend WithEvents addCompanyPictureBox As System.Windows.Forms.PictureBox
   Friend WithEvents lblRepId As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditContactForm))
      Me.lblProfile = New System.Windows.Forms.Label
      Me.lblLastNameRequired = New System.Windows.Forms.Label
      Me.lblFirstNameRequired = New System.Windows.Forms.Label
      Me.txtLastName = New System.Windows.Forms.TextBox
      Me.lblLastName = New System.Windows.Forms.Label
      Me.txtFirstName = New System.Windows.Forms.TextBox
      Me.lblFirstName = New System.Windows.Forms.Label
      Me.lblCompany = New System.Windows.Forms.Label
      Me.cboCompany = New System.Windows.Forms.ComboBox
      Me.btnCancel = New System.Windows.Forms.Button
      Me.btnOk = New System.Windows.Forms.Button
      Me.gboRep = New System.Windows.Forms.GroupBox
      Me.addCompanyPictureBox = New System.Windows.Forms.PictureBox
      Me.txtFaxNum = New System.Windows.Forms.MaskedTextBox
      Me.repPhoneNum = New Rae.RaeSolutions.PhoneControl
      Me.repAddress = New Rae.RaeSolutions.AddressControl
      Me.Label1 = New System.Windows.Forms.Label
      Me.lblLeftParenthesis = New System.Windows.Forms.Label
      Me.lblFaxNum = New System.Windows.Forms.Label
      Me.txtFaxNumAreaCode = New System.Windows.Forms.TextBox
      Me.txtEmail = New System.Windows.Forms.TextBox
      Me.lblEmail = New System.Windows.Forms.Label
      Me.picRep = New System.Windows.Forms.PictureBox
      Me.tip = New System.Windows.Forms.ToolTip(Me.components)
      Me.lblRepId = New System.Windows.Forms.Label
      Me.gboRep.SuspendLayout()
      CType(Me.addCompanyPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.picRep, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'lblProfile
      '
      Me.lblProfile.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblProfile.ForeColor = System.Drawing.Color.RoyalBlue
      Me.lblProfile.Location = New System.Drawing.Point(60, 16)
      Me.lblProfile.Name = "lblProfile"
      Me.lblProfile.Size = New System.Drawing.Size(142, 24)
      Me.lblProfile.TabIndex = 2
      Me.lblProfile.Text = "Contact Profile"
      Me.lblProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblLastNameRequired
      '
      Me.lblLastNameRequired.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblLastNameRequired.ForeColor = System.Drawing.Color.SteelBlue
      Me.lblLastNameRequired.Location = New System.Drawing.Point(304, 56)
      Me.lblLastNameRequired.Name = "lblLastNameRequired"
      Me.lblLastNameRequired.Size = New System.Drawing.Size(16, 16)
      Me.lblLastNameRequired.TabIndex = 130
      Me.lblLastNameRequired.Text = "R"
      '
      'lblFirstNameRequired
      '
      Me.lblFirstNameRequired.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblFirstNameRequired.ForeColor = System.Drawing.Color.SteelBlue
      Me.lblFirstNameRequired.Location = New System.Drawing.Point(152, 56)
      Me.lblFirstNameRequired.Name = "lblFirstNameRequired"
      Me.lblFirstNameRequired.Size = New System.Drawing.Size(16, 16)
      Me.lblFirstNameRequired.TabIndex = 129
      Me.lblFirstNameRequired.Text = "R"
      '
      'txtLastName
      '
      Me.txtLastName.Location = New System.Drawing.Point(232, 56)
      Me.txtLastName.Name = "txtLastName"
      Me.txtLastName.Size = New System.Drawing.Size(72, 21)
      Me.txtLastName.TabIndex = 5
      '
      'lblLastName
      '
      Me.lblLastName.Location = New System.Drawing.Point(188, 56)
      Me.lblLastName.Name = "lblLastName"
      Me.lblLastName.Size = New System.Drawing.Size(32, 23)
      Me.lblLastName.TabIndex = 128
      Me.lblLastName.Text = "Last"
      Me.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtFirstName
      '
      Me.txtFirstName.Location = New System.Drawing.Point(80, 56)
      Me.txtFirstName.Name = "txtFirstName"
      Me.txtFirstName.Size = New System.Drawing.Size(72, 21)
      Me.txtFirstName.TabIndex = 3
      '
      'lblFirstName
      '
      Me.lblFirstName.Location = New System.Drawing.Point(8, 56)
      Me.lblFirstName.Name = "lblFirstName"
      Me.lblFirstName.Size = New System.Drawing.Size(60, 23)
      Me.lblFirstName.TabIndex = 125
      Me.lblFirstName.Text = "First name"
      Me.lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCompany
      '
      Me.lblCompany.Location = New System.Drawing.Point(8, 24)
      Me.lblCompany.Name = "lblCompany"
      Me.lblCompany.Size = New System.Drawing.Size(60, 23)
      Me.lblCompany.TabIndex = 131
      Me.lblCompany.Text = "Company"
      Me.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cboCompany
      '
      Me.cboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboCompany.Location = New System.Drawing.Point(80, 24)
      Me.cboCompany.Name = "cboCompany"
      Me.cboCompany.Size = New System.Drawing.Size(224, 21)
      Me.cboCompany.TabIndex = 1
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCancel.Location = New System.Drawing.Point(292, 390)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(72, 23)
      Me.btnCancel.TabIndex = 17
      Me.btnCancel.Text = "Cancel"
      '
      'btnOk
      '
      Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
      Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnOk.Location = New System.Drawing.Point(208, 390)
      Me.btnOk.Name = "btnOk"
      Me.btnOk.Size = New System.Drawing.Size(72, 23)
      Me.btnOk.TabIndex = 16
      Me.btnOk.Text = "OK"
      '
      'gboRep
      '
      Me.gboRep.Controls.Add(Me.addCompanyPictureBox)
      Me.gboRep.Controls.Add(Me.txtFaxNum)
      Me.gboRep.Controls.Add(Me.repPhoneNum)
      Me.gboRep.Controls.Add(Me.repAddress)
      Me.gboRep.Controls.Add(Me.Label1)
      Me.gboRep.Controls.Add(Me.lblLeftParenthesis)
      Me.gboRep.Controls.Add(Me.lblFaxNum)
      Me.gboRep.Controls.Add(Me.txtFaxNumAreaCode)
      Me.gboRep.Controls.Add(Me.txtEmail)
      Me.gboRep.Controls.Add(Me.lblEmail)
      Me.gboRep.Controls.Add(Me.lblCompany)
      Me.gboRep.Controls.Add(Me.cboCompany)
      Me.gboRep.Controls.Add(Me.lblLastNameRequired)
      Me.gboRep.Controls.Add(Me.lblFirstNameRequired)
      Me.gboRep.Controls.Add(Me.txtLastName)
      Me.gboRep.Controls.Add(Me.lblLastName)
      Me.gboRep.Controls.Add(Me.txtFirstName)
      Me.gboRep.Controls.Add(Me.lblFirstName)
      Me.gboRep.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.gboRep.Location = New System.Drawing.Point(16, 36)
      Me.gboRep.Name = "gboRep"
      Me.gboRep.Size = New System.Drawing.Size(344, 340)
      Me.gboRep.TabIndex = 135
      Me.gboRep.TabStop = False
      '
      'addCompanyPictureBox
      '
      Me.addCompanyPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
      Me.addCompanyPictureBox.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Add
      Me.addCompanyPictureBox.Location = New System.Drawing.Point(306, 24)
      Me.addCompanyPictureBox.Name = "addCompanyPictureBox"
      Me.addCompanyPictureBox.Size = New System.Drawing.Size(21, 21)
      Me.addCompanyPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
      Me.addCompanyPictureBox.TabIndex = 142
      Me.addCompanyPictureBox.TabStop = False
      Me.tip.SetToolTip(Me.addCompanyPictureBox, "Click to add a company")
      '
      'txtFaxNum
      '
      Me.txtFaxNum.Location = New System.Drawing.Point(124, 272)
      Me.txtFaxNum.Mask = "000-0000"
      Me.txtFaxNum.Name = "txtFaxNum"
      Me.txtFaxNum.Size = New System.Drawing.Size(62, 21)
      Me.txtFaxNum.TabIndex = 14
      '
      'repPhoneNum
      '
      Me.repPhoneNum.BackColor = System.Drawing.Color.White
      Me.repPhoneNum.ExtensionVisible = True
      Me.repPhoneNum.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.repPhoneNum.Location = New System.Drawing.Point(24, 224)
      Me.repPhoneNum.Name = "repPhoneNum"
      Me.repPhoneNum.PhoneNum = Nothing
      Me.repPhoneNum.Size = New System.Drawing.Size(248, 40)
      Me.repPhoneNum.TabIndex = 9
      '
      'repAddress
      '
      Me.repAddress.BackColor = System.Drawing.Color.White
      Me.repAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.repAddress.Location = New System.Drawing.Point(20, 84)
      Me.repAddress.Name = "repAddress"
      Me.repAddress.Size = New System.Drawing.Size(300, 136)
      Me.repAddress.TabIndex = 7
      '
      'Label1
      '
      Me.Label1.Location = New System.Drawing.Point(108, 272)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(12, 23)
      Me.Label1.TabIndex = 141
      Me.Label1.Text = ")"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblLeftParenthesis
      '
      Me.lblLeftParenthesis.Location = New System.Drawing.Point(68, 272)
      Me.lblLeftParenthesis.Name = "lblLeftParenthesis"
      Me.lblLeftParenthesis.Size = New System.Drawing.Size(12, 23)
      Me.lblLeftParenthesis.TabIndex = 140
      Me.lblLeftParenthesis.Text = "("
      Me.lblLeftParenthesis.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblFaxNum
      '
      Me.lblFaxNum.Location = New System.Drawing.Point(4, 272)
      Me.lblFaxNum.Name = "lblFaxNum"
      Me.lblFaxNum.Size = New System.Drawing.Size(64, 23)
      Me.lblFaxNum.TabIndex = 139
      Me.lblFaxNum.Text = "Fax"
      Me.lblFaxNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtFaxNumAreaCode
      '
      Me.txtFaxNumAreaCode.Location = New System.Drawing.Point(80, 272)
      Me.txtFaxNumAreaCode.Name = "txtFaxNumAreaCode"
      Me.txtFaxNumAreaCode.Size = New System.Drawing.Size(28, 21)
      Me.txtFaxNumAreaCode.TabIndex = 11
      '
      'txtEmail
      '
      Me.txtEmail.Location = New System.Drawing.Point(80, 304)
      Me.txtEmail.Name = "txtEmail"
      Me.txtEmail.Size = New System.Drawing.Size(224, 21)
      Me.txtEmail.TabIndex = 15
      '
      'lblEmail
      '
      Me.lblEmail.Location = New System.Drawing.Point(8, 304)
      Me.lblEmail.Name = "lblEmail"
      Me.lblEmail.Size = New System.Drawing.Size(64, 23)
      Me.lblEmail.TabIndex = 135
      Me.lblEmail.Text = "Email"
      Me.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'picRep
      '
      Me.picRep.BackColor = System.Drawing.Color.Transparent
      Me.picRep.Image = CType(resources.GetObject("picRep.Image"), System.Drawing.Image)
      Me.picRep.Location = New System.Drawing.Point(22, 12)
      Me.picRep.Name = "picRep"
      Me.picRep.Size = New System.Drawing.Size(28, 28)
      Me.picRep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.picRep.TabIndex = 136
      Me.picRep.TabStop = False
      '
      'lblRepId
      '
      Me.lblRepId.Location = New System.Drawing.Point(172, 16)
      Me.lblRepId.Name = "lblRepId"
      Me.lblRepId.Size = New System.Drawing.Size(188, 23)
      Me.lblRepId.TabIndex = 137
      Me.lblRepId.Text = "Rep Id:"
      Me.lblRepId.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'EditContactForm
      '
      Me.AcceptButton = Me.btnOk
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
      Me.BackColor = System.Drawing.Color.White
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(376, 424)
      Me.ControlBox = False
      Me.Controls.Add(Me.lblRepId)
      Me.Controls.Add(Me.picRep)
      Me.Controls.Add(Me.gboRep)
      Me.Controls.Add(Me.lblProfile)
      Me.Controls.Add(Me.btnOk)
      Me.Controls.Add(Me.btnCancel)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "EditContactForm"
      Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
      Me.Text = "Contact Profile"
      Me.gboRep.ResumeLayout(False)
      Me.gboRep.PerformLayout()
      CType(Me.addCompanyPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.picRep, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region


#Region " Properties"

   Private contact_ As Contact
   ''' <summary>
   ''' Contact whose details are displayed in controls
   ''' </summary>
   Public Property Contact() As Contact
      Get
         Return Me.contact_
      End Get
      Set(ByVal Value As Contact)
         Me.contact_ = Value
      End Set
   End Property

   ''' <summary>
   ''' Company of contact
   ''' </summary>
   Private Property selectedCompany() As Company
      Get
         If Me.DesignMode Then Exit Property
         If Me.cboCompany.SelectedIndex = -1 Then
            Return Nothing
         Else
            Return DirectCast(Me.cboCompany.SelectedItem, Company)
         End If
      End Get
      Set(ByVal value As Company)
         If Me.DesignMode = True Then Exit Property
         If value IsNot Nothing Then
            If selectCompanyBasedOn(value.Id) = Outcome.Failed _
            AndAlso selectCompanyBasedOn(value.Name) = Outcome.Failed Then
               Me.cboCompany.SelectedIndex = -1
            End If
         End If
      End Set
   End Property

#End Region


#Region " Public methods"

   ''' <summary>
   ''' Gets contact values from control values; refreshes contact property.
   ''' </summary> 
   Public Sub RefreshData()
      If Me.DesignMode Then Exit Sub
      With Me.contact_
         If Not Me.cboCompany.SelectedItem Is Nothing Then
            .Company = DirectCast(Me.cboCompany.SelectedItem, Company) : End If
         .Name.FirstName = Me.txtFirstName.Text.Trim
         .Name.LastName = Me.txtLastName.Text.Trim
         Me.repAddress.RefreshData() : .Address = Me.repAddress.Address
         Me.contact_.PhoneNum = Me.repPhoneNum.PhoneNum
         .FaxNum.AreaCode.set_to(Me.txtFaxNumAreaCode.Text.Trim)
         .FaxNum.Number.set_to(Me.txtFaxNum.Text.Replace("-", "").Replace(" ", "").Trim)
         .Email.Address = Me.txtEmail.Text.Trim
      End With
   End Sub


   ''' <summary>
   ''' Sets controls based on contact property
   ''' </summary>
   Public Sub UpdateControls()
      If Me.DesignMode Then Exit Sub
      With Me.contact_
         If .RepNum.has_value Then
            Me.setRepId(.RepNum.value)
         End If
         Me.txtFirstName.Text = .Name.FirstName
         Me.txtLastName.Text = .Name.LastName
         Me.repAddress.Address = .Address : Me.repAddress.UpdateControls()
         Me.repPhoneNum.PhoneNum = .PhoneNum
         Me.txtFaxNumAreaCode.Text = .FaxNum.AreaCode.ToString
         Me.txtFaxNum.Text = .FaxNum.Number.ToString

         Me.selectedCompany = .Company

         Me.txtEmail.Text = .Email.Address
      End With
   End Sub

#End Region


#Region " Event handlers"

   ''' <summary>Handles load event</summary>
   Private Sub Me_Load(ByVal sender As Object, ByVal e As EventArgs) _
   Handles MyBase.Load

      Me.initializeControls()

      ' updates controls in case rep was already set
      If Me.contact_ IsNot Nothing Then Me.UpdateControls()

   End Sub


   ''' <summary>Handles OK button being clicked</summary>
   Private Sub btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles btnOk.Click
      If Me.selectedCompany Is Nothing Then
         Ui.MessageBox.Show("A company selection is required to add a rep contact.", MessageBoxIcon.Warning)
         Exit Sub
      End If
      Me.DialogResult = Forms.DialogResult.OK
      Me.Hide()
   End Sub


   ''' <summary>Handles Cancel button being clicked</summary>
   Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles btnCancel.Click
      Me.DialogResult = Forms.DialogResult.Cancel
      Me.Hide()
   End Sub


   Private Sub addCompanyPictureBox_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles addCompanyPictureBox.Click
      addCompany()
   End Sub

#End Region


#Region " Private methods"

   ''' <summary>
   ''' Adds company to combobox.
   ''' </summary>
   Private Sub addCompany()
      Dim form As New CompanyForm()

      ' sets company role (company property has to be set)
      form.Company.Role = Contact.Company.Role
      form.Company = form.Company

      form.ShowDialog(Me.MdiParent)

      If form.DialogResult = DialogResult.OK Then
         form.RefreshData()

         Dim repCompany As New Company()
         repCompany.Copy(form.Company)
         repCompany.Role = Contact.Company.Role
         repCompany.Save()

         Dim repCompanyIndex As Integer = Me.cboCompany.Items.Add(repCompany)
         Me.cboCompany.SelectedIndex = repCompanyIndex
      End If

      ' closes form (may have only been hidden before)
      If Not form Is Nothing Then form.Close()
   End Sub


   ''' <summary>Initializes members
   ''' </summary>
   ''' <remarks>If properties that need initialization are set before the Load event is raised, 
   ''' they need to be initialized here.
   ''' </remarks>
   Private Sub initializeMembers()
      Me.contact_ = New Contact()
   End Sub


   Private Sub initializeControls()
      fillCompanies(Me.Contact.Company.Role)

      ' sets colors
      Me.lblRepId.ForeColor = ColorManager.HeaderBlue
   End Sub


   ''' <summary>
   ''' Fills company combobox.
   ''' </summary>
   Private Sub fillCompanies(ByVal category As String)
      ' retrieves companies
      Dim repCompanies As CompanyList = Projects.CompaniesDa.RetrieveByDescription(category)
      ' clears existing companies
      Me.cboCompany.Items.Clear()

      For i As Integer = 0 To repCompanies.Count - 1
         ' adds rep companies to combobox, if you set DataSource you can't use Items.Add(...) method
         Me.cboCompany.Items.Add(repCompanies.Item(i))
      Next
   End Sub


   ''' <summary>Sets rep id control</summary>
   Private Sub setRepId(ByVal id As Integer)
      If id > 0 Then
         Me.lblRepId.Text = "Id: " & id.ToString
      Else
         Me.lblRepId.Text = ""
      End If
   End Sub

   Private Function selectCompanyBasedOn(ByVal id As nullable_value(Of Integer)) As Outcome
      If id.has_value Then
         For i As Integer = 0 To Me.cboCompany.Items.Count - 1
            If id.equals(DirectCast(Me.cboCompany.Items(i), Company).Id) Then
               Me.cboCompany.SelectedIndex = i : Return Outcome.Succeeded
            End If
         Next
         Return Outcome.Failed
      Else
         Return Outcome.Failed
      End If
   End Function

   Private Function selectCompanyBasedOn(ByVal name As String) As Outcome
      If Not String.IsNullOrEmpty(name) Then
         For i As Integer = 0 To Me.cboCompany.Items.Count - 1
            If name = DirectCast(Me.cboCompany.Items(i), Company).Name Then
               Me.cboCompany.SelectedIndex = i : Return Outcome.Succeeded
            End If
         Next
         Return Outcome.Failed
      Else
         Return Outcome.Failed
      End If
   End Function

#End Region

End Class
