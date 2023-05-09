<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrderEntryForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.txtSalesperson = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPR = New System.Windows.Forms.TextBox()
        Me.txtRepName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPO = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPODate = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.rbResale = New System.Windows.Forms.RadioButton()
        Me.rbTaxable = New System.Windows.Forms.RadioButton()
        Me.rbTaxExempt = New System.Windows.Forms.RadioButton()
        Me.txtTaxNumber = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.txtHours = New System.Windows.Forms.TextBox()
        Me.cboMarket = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtReqShip = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.gb1 = New System.Windows.Forms.GroupBox()
        Me.txtInvoiceName = New System.Windows.Forms.TextBox()
        Me.txtInvoiceAddress = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtInvoicePhone = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtInvoiceState = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtInvoiceZip = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtInvoiceCity = New System.Windows.Forms.TextBox()
        Me.txtShipZip = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtShipState = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtShipCity = New System.Windows.Forms.TextBox()
        Me.txtShipPhone = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtShipAddress = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtShipName = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtOrderNumber = New System.Windows.Forms.TextBox()
        Me.txtRepOrderNum = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtShipAddress2 = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtInvoiceAddress2 = New System.Windows.Forms.TextBox()
        Me.txtRepAccount = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtCallName = New System.Windows.Forms.TextBox()
        Me.txtCallNumber = New System.Windows.Forms.TextBox()
        Me.chkCopyInfo = New System.Windows.Forms.CheckBox()
        Me.lblSaveAs = New System.Windows.Forms.Label()
        Me.txtSaveAs = New System.Windows.Forms.TextBox()
        Me.gb1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(13, 485)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(501, 43)
        Me.btnSubmit.TabIndex = 33
        Me.btnSubmit.Text = "Generate"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'txtSalesperson
        '
        Me.txtSalesperson.Location = New System.Drawing.Point(99, 10)
        Me.txtSalesperson.Name = "txtSalesperson"
        Me.txtSalesperson.Size = New System.Drawing.Size(163, 20)
        Me.txtSalesperson.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Salesperson:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(55, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Name:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(58, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "PR #:"
        '
        'txtPR
        '
        Me.txtPR.Location = New System.Drawing.Point(99, 36)
        Me.txtPR.Name = "txtPR"
        Me.txtPR.Size = New System.Drawing.Size(163, 20)
        Me.txtPR.TabIndex = 3
        '
        'txtRepName
        '
        Me.txtRepName.Location = New System.Drawing.Point(361, 36)
        Me.txtRepName.Name = "txtRepName"
        Me.txtRepName.Size = New System.Drawing.Size(152, 20)
        Me.txtRepName.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(294, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Rep Name:"
        '
        'txtPO
        '
        Me.txtPO.Location = New System.Drawing.Point(99, 64)
        Me.txtPO.Name = "txtPO"
        Me.txtPO.Size = New System.Drawing.Size(163, 20)
        Me.txtPO.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(58, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "PO #:"
        '
        'txtPODate
        '
        Me.txtPODate.Location = New System.Drawing.Point(99, 90)
        Me.txtPODate.Name = "txtPODate"
        Me.txtPODate.Size = New System.Drawing.Size(163, 20)
        Me.txtPODate.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(42, 93)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "PO Date:"
        '
        'rbResale
        '
        Me.rbResale.AutoSize = True
        Me.rbResale.Location = New System.Drawing.Point(6, 16)
        Me.rbResale.Name = "rbResale"
        Me.rbResale.Size = New System.Drawing.Size(58, 17)
        Me.rbResale.TabIndex = 0
        Me.rbResale.TabStop = True
        Me.rbResale.Text = "Resale"
        Me.rbResale.UseVisualStyleBackColor = True
        '
        'rbTaxable
        '
        Me.rbTaxable.AutoSize = True
        Me.rbTaxable.Location = New System.Drawing.Point(6, 39)
        Me.rbTaxable.Name = "rbTaxable"
        Me.rbTaxable.Size = New System.Drawing.Size(63, 17)
        Me.rbTaxable.TabIndex = 1
        Me.rbTaxable.TabStop = True
        Me.rbTaxable.Text = "Taxable"
        Me.rbTaxable.UseVisualStyleBackColor = True
        '
        'rbTaxExempt
        '
        Me.rbTaxExempt.AutoSize = True
        Me.rbTaxExempt.Location = New System.Drawing.Point(6, 62)
        Me.rbTaxExempt.Name = "rbTaxExempt"
        Me.rbTaxExempt.Size = New System.Drawing.Size(94, 17)
        Me.rbTaxExempt.TabIndex = 2
        Me.rbTaxExempt.TabStop = True
        Me.rbTaxExempt.Text = "Tax Exempt #:"
        Me.rbTaxExempt.UseVisualStyleBackColor = True
        '
        'txtTaxNumber
        '
        Me.txtTaxNumber.Location = New System.Drawing.Point(106, 61)
        Me.txtTaxNumber.Name = "txtTaxNumber"
        Me.txtTaxNumber.Size = New System.Drawing.Size(95, 20)
        Me.txtTaxNumber.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(304, 190)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(191, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Job Notes / Crate Tagging Information:"
        '
        'txtNotes
        '
        Me.txtNotes.Location = New System.Drawing.Point(306, 206)
        Me.txtNotes.MaxLength = 182
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(208, 88)
        Me.txtNotes.TabIndex = 21
        '
        'txtHours
        '
        Me.txtHours.Location = New System.Drawing.Point(354, 326)
        Me.txtHours.Name = "txtHours"
        Me.txtHours.Size = New System.Drawing.Size(23, 20)
        Me.txtHours.TabIndex = 25
        '
        'cboMarket
        '
        Me.cboMarket.FormattingEnabled = True
        Me.cboMarket.Location = New System.Drawing.Point(58, 458)
        Me.cboMarket.Name = "cboMarket"
        Me.cboMarket.Size = New System.Drawing.Size(455, 21)
        Me.cboMarket.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 461)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Market:"
        '
        'txtReqShip
        '
        Me.txtReqShip.Location = New System.Drawing.Point(374, 300)
        Me.txtReqShip.Name = "txtReqShip"
        Me.txtReqShip.Size = New System.Drawing.Size(139, 20)
        Me.txtReqShip.TabIndex = 23
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(287, 303)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Req. Ship Date:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(324, 329)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Call"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(383, 329)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(108, 13)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "hours before delivery."
        '
        'gb1
        '
        Me.gb1.Controls.Add(Me.rbResale)
        Me.gb1.Controls.Add(Me.rbTaxable)
        Me.gb1.Controls.Add(Me.rbTaxExempt)
        Me.gb1.Controls.Add(Me.txtTaxNumber)
        Me.gb1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.gb1.Location = New System.Drawing.Point(306, 90)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(207, 91)
        Me.gb1.TabIndex = 19
        Me.gb1.TabStop = False
        '
        'txtInvoiceName
        '
        Me.txtInvoiceName.Location = New System.Drawing.Point(99, 19)
        Me.txtInvoiceName.Name = "txtInvoiceName"
        Me.txtInvoiceName.Size = New System.Drawing.Size(151, 20)
        Me.txtInvoiceName.TabIndex = 1
        '
        'txtInvoiceAddress
        '
        Me.txtInvoiceAddress.Location = New System.Drawing.Point(99, 45)
        Me.txtInvoiceAddress.Name = "txtInvoiceAddress"
        Me.txtInvoiceAddress.Size = New System.Drawing.Size(151, 20)
        Me.txtInvoiceAddress.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(45, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(48, 13)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Address:"
        '
        'txtInvoicePhone
        '
        Me.txtInvoicePhone.Location = New System.Drawing.Point(99, 126)
        Me.txtInvoicePhone.Name = "txtInvoicePhone"
        Me.txtInvoicePhone.Size = New System.Drawing.Size(151, 20)
        Me.txtInvoicePhone.TabIndex = 13
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(52, 129)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 13)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Phone:"
        '
        'txtInvoiceState
        '
        Me.txtInvoiceState.Location = New System.Drawing.Point(134, 97)
        Me.txtInvoiceState.MaxLength = 2
        Me.txtInvoiceState.Name = "txtInvoiceState"
        Me.txtInvoiceState.Size = New System.Drawing.Size(29, 20)
        Me.txtInvoiceState.TabIndex = 9
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(93, 100)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(35, 13)
        Me.Label15.TabIndex = 8
        Me.Label15.Text = "State:"
        '
        'txtInvoiceZip
        '
        Me.txtInvoiceZip.Location = New System.Drawing.Point(200, 97)
        Me.txtInvoiceZip.MaxLength = 10
        Me.txtInvoiceZip.Name = "txtInvoiceZip"
        Me.txtInvoiceZip.Size = New System.Drawing.Size(50, 20)
        Me.txtInvoiceZip.TabIndex = 11
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(169, 100)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(25, 13)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "Zip:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "City:"
        '
        'txtInvoiceCity
        '
        Me.txtInvoiceCity.Location = New System.Drawing.Point(37, 97)
        Me.txtInvoiceCity.Name = "txtInvoiceCity"
        Me.txtInvoiceCity.Size = New System.Drawing.Size(50, 20)
        Me.txtInvoiceCity.TabIndex = 7
        '
        'txtShipZip
        '
        Me.txtShipZip.Location = New System.Drawing.Point(201, 97)
        Me.txtShipZip.MaxLength = 10
        Me.txtShipZip.Name = "txtShipZip"
        Me.txtShipZip.Size = New System.Drawing.Size(52, 20)
        Me.txtShipZip.TabIndex = 11
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(170, 100)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(25, 13)
        Me.Label17.TabIndex = 10
        Me.Label17.Text = "Zip:"
        '
        'txtShipState
        '
        Me.txtShipState.Location = New System.Drawing.Point(135, 97)
        Me.txtShipState.MaxLength = 2
        Me.txtShipState.Name = "txtShipState"
        Me.txtShipState.Size = New System.Drawing.Size(31, 20)
        Me.txtShipState.TabIndex = 9
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(94, 100)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(35, 13)
        Me.Label18.TabIndex = 8
        Me.Label18.Text = "State:"
        '
        'txtShipCity
        '
        Me.txtShipCity.Location = New System.Drawing.Point(38, 97)
        Me.txtShipCity.Name = "txtShipCity"
        Me.txtShipCity.Size = New System.Drawing.Size(50, 20)
        Me.txtShipCity.TabIndex = 7
        '
        'txtShipPhone
        '
        Me.txtShipPhone.Location = New System.Drawing.Point(100, 126)
        Me.txtShipPhone.Name = "txtShipPhone"
        Me.txtShipPhone.Size = New System.Drawing.Size(153, 20)
        Me.txtShipPhone.TabIndex = 13
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(53, 129)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(41, 13)
        Me.Label19.TabIndex = 12
        Me.Label19.Text = "Phone:"
        '
        'txtShipAddress
        '
        Me.txtShipAddress.Location = New System.Drawing.Point(99, 45)
        Me.txtShipAddress.Name = "txtShipAddress"
        Me.txtShipAddress.Size = New System.Drawing.Size(153, 20)
        Me.txtShipAddress.TabIndex = 3
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(45, 48)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(48, 13)
        Me.Label20.TabIndex = 2
        Me.Label20.Text = "Address:"
        '
        'txtShipName
        '
        Me.txtShipName.Location = New System.Drawing.Point(99, 19)
        Me.txtShipName.Name = "txtShipName"
        Me.txtShipName.Size = New System.Drawing.Size(153, 20)
        Me.txtShipName.TabIndex = 1
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(55, 22)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(38, 13)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Name:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(5, 100)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(27, 13)
        Me.Label22.TabIndex = 6
        Me.Label22.Text = "City:"
        '
        'txtOrderNumber
        '
        Me.txtOrderNumber.Location = New System.Drawing.Point(361, 10)
        Me.txtOrderNumber.Name = "txtOrderNumber"
        Me.txtOrderNumber.Size = New System.Drawing.Size(152, 20)
        Me.txtOrderNumber.TabIndex = 14
        '
        'txtRepOrderNum
        '
        Me.txtRepOrderNum.AutoSize = True
        Me.txtRepOrderNum.Location = New System.Drawing.Point(286, 13)
        Me.txtRepOrderNum.Name = "txtRepOrderNum"
        Me.txtRepOrderNum.Size = New System.Drawing.Size(69, 13)
        Me.txtRepOrderNum.TabIndex = 13
        Me.txtRepOrderNum.Text = "Rep Order #:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.txtShipAddress2)
        Me.GroupBox1.Controls.Add(Me.txtShipName)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.txtShipAddress)
        Me.GroupBox1.Controls.Add(Me.txtShipZip)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtShipPhone)
        Me.GroupBox1.Controls.Add(Me.txtShipState)
        Me.GroupBox1.Controls.Add(Me.txtShipCity)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 300)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(256, 152)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Shipping Information"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(13, 74)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(80, 13)
        Me.Label26.TabIndex = 4
        Me.Label26.Text = "Address Line 2:"
        '
        'txtShipAddress2
        '
        Me.txtShipAddress2.Location = New System.Drawing.Point(99, 71)
        Me.txtShipAddress2.Name = "txtShipAddress2"
        Me.txtShipAddress2.Size = New System.Drawing.Size(153, 20)
        Me.txtShipAddress2.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.txtInvoiceAddress2)
        Me.GroupBox2.Controls.Add(Me.txtInvoiceName)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtInvoiceAddress)
        Me.GroupBox2.Controls.Add(Me.txtInvoiceZip)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtInvoicePhone)
        Me.GroupBox2.Controls.Add(Me.txtInvoiceState)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txtInvoiceCity)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 116)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(256, 155)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Invoice Information"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(13, 74)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(80, 13)
        Me.Label27.TabIndex = 4
        Me.Label27.Text = "Address Line 2:"
        '
        'txtInvoiceAddress2
        '
        Me.txtInvoiceAddress2.Location = New System.Drawing.Point(99, 71)
        Me.txtInvoiceAddress2.Name = "txtInvoiceAddress2"
        Me.txtInvoiceAddress2.Size = New System.Drawing.Size(151, 20)
        Me.txtInvoiceAddress2.TabIndex = 5
        '
        'txtRepAccount
        '
        Me.txtRepAccount.Location = New System.Drawing.Point(361, 64)
        Me.txtRepAccount.Name = "txtRepAccount"
        Me.txtRepAccount.Size = New System.Drawing.Size(152, 20)
        Me.txtRepAccount.TabIndex = 18
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(272, 67)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(83, 13)
        Me.Label23.TabIndex = 17
        Me.Label23.Text = "Rep Account #:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(293, 355)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(78, 13)
        Me.Label24.TabIndex = 27
        Me.Label24.Text = "Contact Name:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(311, 381)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(57, 13)
        Me.Label25.TabIndex = 29
        Me.Label25.Text = "Contact #:"
        '
        'txtCallName
        '
        Me.txtCallName.Location = New System.Drawing.Point(374, 352)
        Me.txtCallName.Name = "txtCallName"
        Me.txtCallName.Size = New System.Drawing.Size(139, 20)
        Me.txtCallName.TabIndex = 28
        '
        'txtCallNumber
        '
        Me.txtCallNumber.Location = New System.Drawing.Point(374, 378)
        Me.txtCallNumber.Name = "txtCallNumber"
        Me.txtCallNumber.Size = New System.Drawing.Size(139, 20)
        Me.txtCallNumber.TabIndex = 30
        '
        'chkCopyInfo
        '
        Me.chkCopyInfo.AutoSize = True
        Me.chkCopyInfo.Location = New System.Drawing.Point(12, 277)
        Me.chkCopyInfo.Name = "chkCopyInfo"
        Me.chkCopyInfo.Size = New System.Drawing.Size(160, 17)
        Me.chkCopyInfo.TabIndex = 9
        Me.chkCopyInfo.Text = "Same as Invoice Information"
        Me.chkCopyInfo.UseVisualStyleBackColor = True
        '
        'lblSaveAs
        '
        Me.lblSaveAs.AutoSize = True
        Me.lblSaveAs.Location = New System.Drawing.Point(294, 410)
        Me.lblSaveAs.Name = "lblSaveAs"
        Me.lblSaveAs.Size = New System.Drawing.Size(125, 13)
        Me.lblSaveAs.TabIndex = 31
        Me.lblSaveAs.Text = "Save Order Entry File As:"
        '
        'txtSaveAs
        '
        Me.txtSaveAs.Location = New System.Drawing.Point(294, 426)
        Me.txtSaveAs.Name = "txtSaveAs"
        Me.txtSaveAs.Size = New System.Drawing.Size(219, 20)
        Me.txtSaveAs.TabIndex = 32
        '
        'OrderEntryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(524, 537)
        Me.Controls.Add(Me.txtSaveAs)
        Me.Controls.Add(Me.lblSaveAs)
        Me.Controls.Add(Me.chkCopyInfo)
        Me.Controls.Add(Me.txtCallNumber)
        Me.Controls.Add(Me.txtCallName)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txtRepAccount)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtOrderNumber)
        Me.Controls.Add(Me.txtRepOrderNum)
        Me.Controls.Add(Me.gb1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtReqShip)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cboMarket)
        Me.Controls.Add(Me.txtHours)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPODate)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtPO)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtRepName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPR)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSalesperson)
        Me.Controls.Add(Me.btnSubmit)
        Me.Name = "OrderEntryForm"
        Me.Text = "OrderEntryForm"
        Me.gb1.ResumeLayout(False)
        Me.gb1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents txtSalesperson As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPR As System.Windows.Forms.TextBox
    Friend WithEvents txtRepName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPO As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPODate As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents rbResale As System.Windows.Forms.RadioButton
    Friend WithEvents rbTaxable As System.Windows.Forms.RadioButton
    Friend WithEvents rbTaxExempt As System.Windows.Forms.RadioButton
    Friend WithEvents txtTaxNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents txtHours As System.Windows.Forms.TextBox
    Friend WithEvents cboMarket As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtReqShip As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents gb1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtInvoiceName As System.Windows.Forms.TextBox
    Friend WithEvents txtInvoiceAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtInvoicePhone As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceState As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceZip As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceCity As System.Windows.Forms.TextBox
    Friend WithEvents txtShipZip As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtShipState As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtShipCity As System.Windows.Forms.TextBox
    Friend WithEvents txtShipPhone As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtShipAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtShipName As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtOrderNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtRepOrderNum As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRepAccount As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtCallName As System.Windows.Forms.TextBox
    Friend WithEvents txtCallNumber As System.Windows.Forms.TextBox
    Friend WithEvents chkCopyInfo As System.Windows.Forms.CheckBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtShipAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents lblSaveAs As System.Windows.Forms.Label
    Friend WithEvents txtSaveAs As System.Windows.Forms.TextBox
End Class
