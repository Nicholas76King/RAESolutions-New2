<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalesOrderEntryForm
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSaveAs = New System.Windows.Forms.TextBox()
        Me.lblSaveAs = New System.Windows.Forms.Label()
        Me.txtCallNumber = New System.Windows.Forms.TextBox()
        Me.txtCallName = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtRepAccount = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtReqShip = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboMarket = New System.Windows.Forms.ComboBox()
        Me.txtHours = New System.Windows.Forms.TextBox()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPODate = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPO = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRepName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPR = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtSalesperson = New System.Windows.Forms.TextBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.gb1 = New System.Windows.Forms.GroupBox()
        Me.rbResale = New System.Windows.Forms.RadioButton()
        Me.rbTaxable = New System.Windows.Forms.RadioButton()
        Me.rbTaxExempt = New System.Windows.Forms.RadioButton()
        Me.txtTaxNumber = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSaveInvoice = New System.Windows.Forms.Button()
        Me.ddInvoiceName = New System.Windows.Forms.ComboBox()
        Me.chkCopyInfo = New System.Windows.Forms.CheckBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtInvoiceAddress2 = New System.Windows.Forms.TextBox()
        Me.txtInvoiceName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtInvoiceAddress = New System.Windows.Forms.TextBox()
        Me.txtInvoiceZip = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtInvoiceState = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtInvoiceCity = New System.Windows.Forms.TextBox()
        Me.txtInvoiceID = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSaveShipping = New System.Windows.Forms.Button()
        Me.ddShipName = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtShipAddress2 = New System.Windows.Forms.TextBox()
        Me.txtShipName = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtShipAddress = New System.Windows.Forms.TextBox()
        Me.txtShipZip = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtShipState = New System.Windows.Forms.TextBox()
        Me.txtShipCity = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtShipID = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.gb1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(66, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(421, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Information Needed to Generate Order Entry Spreadsheet"
        '
        'txtSaveAs
        '
        Me.txtSaveAs.Location = New System.Drawing.Point(299, 262)
        Me.txtSaveAs.Name = "txtSaveAs"
        Me.txtSaveAs.Size = New System.Drawing.Size(223, 20)
        Me.txtSaveAs.TabIndex = 51
        '
        'lblSaveAs
        '
        Me.lblSaveAs.AutoSize = True
        Me.lblSaveAs.Location = New System.Drawing.Point(296, 246)
        Me.lblSaveAs.Name = "lblSaveAs"
        Me.lblSaveAs.Size = New System.Drawing.Size(125, 13)
        Me.lblSaveAs.TabIndex = 65
        Me.lblSaveAs.Text = "Save Order Entry File As:"
        '
        'txtCallNumber
        '
        Me.txtCallNumber.Location = New System.Drawing.Point(359, 116)
        Me.txtCallNumber.Name = "txtCallNumber"
        Me.txtCallNumber.Size = New System.Drawing.Size(163, 20)
        Me.txtCallNumber.TabIndex = 49
        '
        'txtCallName
        '
        Me.txtCallName.Location = New System.Drawing.Point(359, 90)
        Me.txtCallName.Name = "txtCallName"
        Me.txtCallName.Size = New System.Drawing.Size(163, 20)
        Me.txtCallName.TabIndex = 48
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(296, 119)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(57, 13)
        Me.Label25.TabIndex = 63
        Me.Label25.Text = "Contact #:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(278, 93)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(78, 13)
        Me.Label24.TabIndex = 61
        Me.Label24.Text = "Contact Name:"
        '
        'txtRepAccount
        '
        Me.txtRepAccount.Location = New System.Drawing.Point(100, 118)
        Me.txtRepAccount.Name = "txtRepAccount"
        Me.txtRepAccount.Size = New System.Drawing.Size(164, 20)
        Me.txtRepAccount.TabIndex = 39
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(11, 121)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(83, 13)
        Me.Label23.TabIndex = 51
        Me.Label23.Text = "Rep Account #:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(368, 67)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(108, 13)
        Me.Label12.TabIndex = 60
        Me.Label12.Text = "hours before delivery."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(309, 67)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 13)
        Me.Label9.TabIndex = 58
        Me.Label9.Text = "Call"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(270, 41)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 13)
        Me.Label11.TabIndex = 56
        Me.Label11.Text = "Req. Ship Date:"
        '
        'txtReqShip
        '
        Me.txtReqShip.Location = New System.Drawing.Point(359, 38)
        Me.txtReqShip.Name = "txtReqShip"
        Me.txtReqShip.Size = New System.Drawing.Size(163, 20)
        Me.txtReqShip.TabIndex = 46
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 300)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "Market:"
        '
        'cboMarket
        '
        Me.cboMarket.FormattingEnabled = True
        Me.cboMarket.Location = New System.Drawing.Point(67, 297)
        Me.cboMarket.Name = "cboMarket"
        Me.cboMarket.Size = New System.Drawing.Size(455, 21)
        Me.cboMarket.TabIndex = 52
        '
        'txtHours
        '
        Me.txtHours.Location = New System.Drawing.Point(339, 64)
        Me.txtHours.Name = "txtHours"
        Me.txtHours.Size = New System.Drawing.Size(23, 20)
        Me.txtHours.TabIndex = 47
        '
        'txtNotes
        '
        Me.txtNotes.Location = New System.Drawing.Point(299, 162)
        Me.txtNotes.MaxLength = 182
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(223, 81)
        Me.txtNotes.TabIndex = 50
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(296, 146)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(191, 13)
        Me.Label8.TabIndex = 54
        Me.Label8.Text = "Job Notes / Crate Tagging Information:"
        '
        'txtPODate
        '
        Me.txtPODate.Location = New System.Drawing.Point(101, 171)
        Me.txtPODate.Name = "txtPODate"
        Me.txtPODate.Size = New System.Drawing.Size(163, 20)
        Me.txtPODate.TabIndex = 41
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(44, 174)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "PO Date:"
        '
        'txtPO
        '
        Me.txtPO.Location = New System.Drawing.Point(101, 145)
        Me.txtPO.Name = "txtPO"
        Me.txtPO.Size = New System.Drawing.Size(163, 20)
        Me.txtPO.TabIndex = 40
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(60, 148)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "PO #:"
        '
        'txtRepName
        '
        Me.txtRepName.Location = New System.Drawing.Point(100, 90)
        Me.txtRepName.Name = "txtRepName"
        Me.txtRepName.Size = New System.Drawing.Size(164, 20)
        Me.txtRepName.TabIndex = 38
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(33, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Rep Name:"
        '
        'txtPR
        '
        Me.txtPR.Location = New System.Drawing.Point(101, 64)
        Me.txtPR.Name = "txtPR"
        Me.txtPR.Size = New System.Drawing.Size(163, 20)
        Me.txtPR.TabIndex = 37
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(60, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "PR #:"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(27, 41)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(68, 13)
        Me.Label28.TabIndex = 34
        Me.Label28.Text = "Salesperson:"
        '
        'txtSalesperson
        '
        Me.txtSalesperson.Location = New System.Drawing.Point(101, 38)
        Me.txtSalesperson.Name = "txtSalesperson"
        Me.txtSalesperson.Size = New System.Drawing.Size(163, 20)
        Me.txtSalesperson.TabIndex = 35
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(8, 513)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(529, 36)
        Me.btnSubmit.TabIndex = 89
        Me.btnSubmit.Text = "Generate"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'gb1
        '
        Me.gb1.Controls.Add(Me.rbResale)
        Me.gb1.Controls.Add(Me.rbTaxable)
        Me.gb1.Controls.Add(Me.rbTaxExempt)
        Me.gb1.Controls.Add(Me.txtTaxNumber)
        Me.gb1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.gb1.Location = New System.Drawing.Point(21, 197)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(243, 91)
        Me.gb1.TabIndex = 42
        Me.gb1.TabStop = False
        '
        'rbResale
        '
        Me.rbResale.AutoSize = True
        Me.rbResale.Location = New System.Drawing.Point(6, 16)
        Me.rbResale.Name = "rbResale"
        Me.rbResale.Size = New System.Drawing.Size(58, 17)
        Me.rbResale.TabIndex = 42
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
        Me.rbTaxable.TabIndex = 43
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
        Me.rbTaxExempt.TabIndex = 44
        Me.rbTaxExempt.TabStop = True
        Me.rbTaxExempt.Text = "Tax Exempt #:"
        Me.rbTaxExempt.UseVisualStyleBackColor = True
        '
        'txtTaxNumber
        '
        Me.txtTaxNumber.Location = New System.Drawing.Point(106, 61)
        Me.txtTaxNumber.Name = "txtTaxNumber"
        Me.txtTaxNumber.Size = New System.Drawing.Size(131, 20)
        Me.txtTaxNumber.TabIndex = 45
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSaveInvoice)
        Me.GroupBox2.Controls.Add(Me.ddInvoiceName)
        Me.GroupBox2.Controls.Add(Me.chkCopyInfo)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.txtInvoiceAddress2)
        Me.GroupBox2.Controls.Add(Me.txtInvoiceName)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtInvoiceAddress)
        Me.GroupBox2.Controls.Add(Me.txtInvoiceZip)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtInvoiceState)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txtInvoiceCity)
        Me.GroupBox2.Controls.Add(Me.txtInvoiceID)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 326)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(256, 181)
        Me.GroupBox2.TabIndex = 66
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Invoice Information"
        '
        'btnSaveInvoice
        '
        Me.btnSaveInvoice.Location = New System.Drawing.Point(7, 152)
        Me.btnSaveInvoice.Name = "btnSaveInvoice"
        Me.btnSaveInvoice.Size = New System.Drawing.Size(46, 23)
        Me.btnSaveInvoice.TabIndex = 72
        Me.btnSaveInvoice.Text = "Save"
        Me.ToolTip1.SetToolTip(Me.btnSaveInvoice, "Saves contact to project and saves contact to drop down for later use.")
        Me.btnSaveInvoice.UseVisualStyleBackColor = True
        '
        'ddInvoiceName
        '
        Me.ddInvoiceName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddInvoiceName.FormattingEnabled = True
        Me.ddInvoiceName.Location = New System.Drawing.Point(7, 18)
        Me.ddInvoiceName.Name = "ddInvoiceName"
        Me.ddInvoiceName.Size = New System.Drawing.Size(243, 21)
        Me.ddInvoiceName.TabIndex = 71
        '
        'chkCopyInfo
        '
        Me.chkCopyInfo.AutoSize = True
        Me.chkCopyInfo.Location = New System.Drawing.Point(89, 156)
        Me.chkCopyInfo.Name = "chkCopyInfo"
        Me.chkCopyInfo.Size = New System.Drawing.Size(161, 17)
        Me.chkCopyInfo.TabIndex = 68
        Me.chkCopyInfo.Text = "Copy to Shipping Information"
        Me.chkCopyInfo.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(13, 103)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(80, 13)
        Me.Label27.TabIndex = 4
        Me.Label27.Text = "Address Line 2:"
        '
        'txtInvoiceAddress2
        '
        Me.txtInvoiceAddress2.Location = New System.Drawing.Point(99, 100)
        Me.txtInvoiceAddress2.Name = "txtInvoiceAddress2"
        Me.txtInvoiceAddress2.Size = New System.Drawing.Size(151, 20)
        Me.txtInvoiceAddress2.TabIndex = 5
        '
        'txtInvoiceName
        '
        Me.txtInvoiceName.Location = New System.Drawing.Point(99, 48)
        Me.txtInvoiceName.Name = "txtInvoiceName"
        Me.txtInvoiceName.Size = New System.Drawing.Size(151, 20)
        Me.txtInvoiceName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(55, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Name:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(45, 77)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(48, 13)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Address:"
        '
        'txtInvoiceAddress
        '
        Me.txtInvoiceAddress.Location = New System.Drawing.Point(99, 74)
        Me.txtInvoiceAddress.Name = "txtInvoiceAddress"
        Me.txtInvoiceAddress.Size = New System.Drawing.Size(151, 20)
        Me.txtInvoiceAddress.TabIndex = 3
        '
        'txtInvoiceZip
        '
        Me.txtInvoiceZip.Location = New System.Drawing.Point(200, 126)
        Me.txtInvoiceZip.MaxLength = 10
        Me.txtInvoiceZip.Name = "txtInvoiceZip"
        Me.txtInvoiceZip.Size = New System.Drawing.Size(50, 20)
        Me.txtInvoiceZip.TabIndex = 11
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(169, 129)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(25, 13)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "Zip:"
        '
        'txtInvoiceState
        '
        Me.txtInvoiceState.Location = New System.Drawing.Point(134, 126)
        Me.txtInvoiceState.MaxLength = 2
        Me.txtInvoiceState.Name = "txtInvoiceState"
        Me.txtInvoiceState.Size = New System.Drawing.Size(29, 20)
        Me.txtInvoiceState.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 129)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "City:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(93, 129)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(35, 13)
        Me.Label15.TabIndex = 8
        Me.Label15.Text = "State:"
        '
        'txtInvoiceCity
        '
        Me.txtInvoiceCity.Location = New System.Drawing.Point(37, 126)
        Me.txtInvoiceCity.Name = "txtInvoiceCity"
        Me.txtInvoiceCity.Size = New System.Drawing.Size(50, 20)
        Me.txtInvoiceCity.TabIndex = 7
        '
        'txtInvoiceID
        '
        Me.txtInvoiceID.Location = New System.Drawing.Point(134, 48)
        Me.txtInvoiceID.Margin = New System.Windows.Forms.Padding(0)
        Me.txtInvoiceID.Name = "txtInvoiceID"
        Me.txtInvoiceID.Size = New System.Drawing.Size(100, 20)
        Me.txtInvoiceID.TabIndex = 73
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSaveShipping)
        Me.GroupBox1.Controls.Add(Me.ddShipName)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.txtShipAddress2)
        Me.GroupBox1.Controls.Add(Me.txtShipName)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.txtShipAddress)
        Me.GroupBox1.Controls.Add(Me.txtShipZip)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtShipState)
        Me.GroupBox1.Controls.Add(Me.txtShipCity)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtShipID)
        Me.GroupBox1.Location = New System.Drawing.Point(281, 326)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(256, 181)
        Me.GroupBox1.TabIndex = 68
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Shipping Information"
        '
        'btnSaveShipping
        '
        Me.btnSaveShipping.Location = New System.Drawing.Point(6, 152)
        Me.btnSaveShipping.Name = "btnSaveShipping"
        Me.btnSaveShipping.Size = New System.Drawing.Size(46, 23)
        Me.btnSaveShipping.TabIndex = 73
        Me.btnSaveShipping.Text = "Save"
        Me.ToolTip1.SetToolTip(Me.btnSaveShipping, "Saves contact to project and saves contact to drop down for later use.")
        Me.btnSaveShipping.UseVisualStyleBackColor = True
        '
        'ddShipName
        '
        Me.ddShipName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddShipName.FormattingEnabled = True
        Me.ddShipName.Location = New System.Drawing.Point(9, 18)
        Me.ddShipName.Name = "ddShipName"
        Me.ddShipName.Size = New System.Drawing.Size(243, 21)
        Me.ddShipName.TabIndex = 70
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(13, 103)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(80, 13)
        Me.Label26.TabIndex = 4
        Me.Label26.Text = "Address Line 2:"
        '
        'txtShipAddress2
        '
        Me.txtShipAddress2.Location = New System.Drawing.Point(99, 100)
        Me.txtShipAddress2.Name = "txtShipAddress2"
        Me.txtShipAddress2.Size = New System.Drawing.Size(153, 20)
        Me.txtShipAddress2.TabIndex = 5
        '
        'txtShipName
        '
        Me.txtShipName.Location = New System.Drawing.Point(99, 48)
        Me.txtShipName.Name = "txtShipName"
        Me.txtShipName.Size = New System.Drawing.Size(153, 20)
        Me.txtShipName.TabIndex = 1
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(55, 51)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(38, 13)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Name:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(45, 77)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(48, 13)
        Me.Label20.TabIndex = 2
        Me.Label20.Text = "Address:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 129)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(27, 13)
        Me.Label22.TabIndex = 6
        Me.Label22.Text = "City:"
        '
        'txtShipAddress
        '
        Me.txtShipAddress.Location = New System.Drawing.Point(99, 74)
        Me.txtShipAddress.Name = "txtShipAddress"
        Me.txtShipAddress.Size = New System.Drawing.Size(153, 20)
        Me.txtShipAddress.TabIndex = 3
        '
        'txtShipZip
        '
        Me.txtShipZip.Location = New System.Drawing.Point(201, 126)
        Me.txtShipZip.MaxLength = 10
        Me.txtShipZip.Name = "txtShipZip"
        Me.txtShipZip.Size = New System.Drawing.Size(52, 20)
        Me.txtShipZip.TabIndex = 11
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(170, 129)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(25, 13)
        Me.Label17.TabIndex = 10
        Me.Label17.Text = "Zip:"
        '
        'txtShipState
        '
        Me.txtShipState.Location = New System.Drawing.Point(135, 126)
        Me.txtShipState.MaxLength = 2
        Me.txtShipState.Name = "txtShipState"
        Me.txtShipState.Size = New System.Drawing.Size(31, 20)
        Me.txtShipState.TabIndex = 9
        '
        'txtShipCity
        '
        Me.txtShipCity.Location = New System.Drawing.Point(38, 126)
        Me.txtShipCity.Name = "txtShipCity"
        Me.txtShipCity.Size = New System.Drawing.Size(50, 20)
        Me.txtShipCity.TabIndex = 7
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(94, 129)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(35, 13)
        Me.Label18.TabIndex = 8
        Me.Label18.Text = "State:"
        '
        'txtShipID
        '
        Me.txtShipID.Location = New System.Drawing.Point(135, 48)
        Me.txtShipID.Margin = New System.Windows.Forms.Padding(0)
        Me.txtShipID.Name = "txtShipID"
        Me.txtShipID.Size = New System.Drawing.Size(100, 20)
        Me.txtShipID.TabIndex = 74
        '
        'SalesOrderEntryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 555)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gb1)
        Me.Controls.Add(Me.txtSaveAs)
        Me.Controls.Add(Me.lblSaveAs)
        Me.Controls.Add(Me.txtCallNumber)
        Me.Controls.Add(Me.txtCallName)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txtRepAccount)
        Me.Controls.Add(Me.Label23)
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
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.txtSalesperson)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.Label1)
        Me.Name = "SalesOrderEntryForm"
        Me.Text = "SalesOrderEntryForm"
        Me.gb1.ResumeLayout(False)
        Me.gb1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSaveAs As System.Windows.Forms.TextBox
    Friend WithEvents lblSaveAs As System.Windows.Forms.Label
    Friend WithEvents txtCallNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtCallName As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtRepAccount As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtReqShip As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboMarket As System.Windows.Forms.ComboBox
    Friend WithEvents txtHours As System.Windows.Forms.TextBox
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPODate As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPO As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRepName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPR As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtSalesperson As System.Windows.Forms.TextBox
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents gb1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbResale As System.Windows.Forms.RadioButton
    Friend WithEvents rbTaxable As System.Windows.Forms.RadioButton
    Friend WithEvents rbTaxExempt As System.Windows.Forms.RadioButton
    Friend WithEvents txtTaxNumber As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtInvoiceZip As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceState As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceCity As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtShipAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtShipName As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtShipAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtShipZip As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtShipState As System.Windows.Forms.TextBox
    Friend WithEvents txtShipCity As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ddShipName As System.Windows.Forms.ComboBox
    Friend WithEvents chkCopyInfo As System.Windows.Forms.CheckBox
    Friend WithEvents ddInvoiceName As System.Windows.Forms.ComboBox
    Friend WithEvents txtInvoiceName As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveInvoice As System.Windows.Forms.Button
    Friend WithEvents btnSaveShipping As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtInvoiceID As System.Windows.Forms.TextBox
    Friend WithEvents txtShipID As System.Windows.Forms.TextBox
End Class
