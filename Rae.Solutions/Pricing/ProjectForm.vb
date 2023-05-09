Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Environment
Imports System.Linq
Imports Validation = Rae.validation
Imports CNull = Rae.ConvertNull
Imports Rae.RaeSolutions.Business
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.DataAccess
Imports CrystalDecisions.CrystalReports.Engine
Imports Rae.reporting
Imports Rae.reporting.CrystalReports
Imports System.Collections.Generic
Imports Rae.Ui.quickies
Imports System.IO
Imports ClosedXML.Excel


Public Class ProjectForm : Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        MainForm.project = Me

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents panMain As System.Windows.Forms.Panel
    Friend WithEvents tip As System.Windows.Forms.ToolTip
    Friend WithEvents img As System.Windows.Forms.ImageList
    Friend WithEvents err As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Private WithEvents purchaseOrderNumLabel As System.Windows.Forms.Label
    Friend WithEvents purchaseOrderNumTextBox As System.Windows.Forms.TextBox
    Friend WithEvents lblJobNotes As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents TextBox26 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox27 As System.Windows.Forms.TextBox
    Friend WithEvents radTaxExemptNumber As System.Windows.Forms.RadioButton
    Friend WithEvents radTaxable As System.Windows.Forms.RadioButton
    Friend WithEvents radResale As System.Windows.Forms.RadioButton
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TextBox30 As System.Windows.Forms.TextBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents chkInvoiceToContractor As System.Windows.Forms.CheckBox
    Friend WithEvents gboShipTo As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox13 As System.Windows.Forms.PictureBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboShipTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents TextBox29 As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox14 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox15 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblNotesHeader As System.Windows.Forms.Label
    Friend WithEvents gboPricing As System.Windows.Forms.GroupBox
    Friend WithEvents gboNotes As System.Windows.Forms.GroupBox
    Friend WithEvents gboInvoiceTo As System.Windows.Forms.GroupBox
    Friend WithEvents releaseStatusComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents releaseNumTextBox As System.Windows.Forms.TextBox
    Friend WithEvents assignReleaseNumLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents gboFooter As System.Windows.Forms.GroupBox
    Friend WithEvents lblFooter As System.Windows.Forms.Label
    Friend WithEvents lblFreight As System.Windows.Forms.Label
    Friend WithEvents lblTaxes As System.Windows.Forms.Label
    Friend WithEvents lblHeightController As System.Windows.Forms.Label
    Friend WithEvents projectIdTextBox As System.Windows.Forms.TextBox
    Friend WithEvents releaseStatusLabel As System.Windows.Forms.Label
    Friend WithEvents projectInfoMenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents fileMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents saveMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents closeMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents reportsMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents coverLetterReview As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents coverPageMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripPanel1 As Rae.RaeSolutions.SaveToolStripPanel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnBoxLoad As System.Windows.Forms.Button
    Friend WithEvents gradientChanges As Rae.Ui.Controls.GradientPanel
    Friend WithEvents listChanges As System.Windows.Forms.ListBox
    Friend WithEvents lblChanges As System.Windows.Forms.Label
    Friend WithEvents copyExistingItemButton As System.Windows.Forms.Button
    Friend WithEvents btnProcessOrder As System.Windows.Forms.Button
    Friend WithEvents CoverLetterApproval As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCopyToCloud As System.Windows.Forms.Button
    Friend WithEvents btnGenerateProposal As System.Windows.Forms.Button
    Friend WithEvents btnOrderEntry As System.Windows.Forms.Button
    Friend WithEvents btnSalesOrderEntry As System.Windows.Forms.Button
    Friend WithEvents ContactManagerControl1 As Rae.RaeSolutions.ContactManagerControl
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProjectForm))
        Me.panMain = New System.Windows.Forms.Panel()
        Me.lblNotesHeader = New System.Windows.Forms.Label()
        Me.chkInvoiceToContractor = New System.Windows.Forms.CheckBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnSalesOrderEntry = New System.Windows.Forms.Button()
        Me.btnOrderEntry = New System.Windows.Forms.Button()
        Me.btnGenerateProposal = New System.Windows.Forms.Button()
        Me.btnCopyToCloud = New System.Windows.Forms.Button()
        Me.copyExistingItemButton = New System.Windows.Forms.Button()
        Me.btnProcessOrder = New System.Windows.Forms.Button()
        Me.btnBoxLoad = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.releaseStatusLabel = New System.Windows.Forms.Label()
        Me.projectIdTextBox = New System.Windows.Forms.TextBox()
        Me.releaseStatusComboBox = New System.Windows.Forms.ComboBox()
        Me.releaseNumTextBox = New System.Windows.Forms.TextBox()
        Me.purchaseOrderNumLabel = New System.Windows.Forms.Label()
        Me.assignReleaseNumLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.purchaseOrderNumTextBox = New System.Windows.Forms.TextBox()
        Me.gboFooter = New System.Windows.Forms.GroupBox()
        Me.lblFooter = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.gboPricing = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TextBox27 = New System.Windows.Forms.TextBox()
        Me.radTaxExemptNumber = New System.Windows.Forms.RadioButton()
        Me.radTaxable = New System.Windows.Forms.RadioButton()
        Me.radResale = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBox30 = New System.Windows.Forms.TextBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.lblFreight = New System.Windows.Forms.Label()
        Me.lblTaxes = New System.Windows.Forms.Label()
        Me.gboNotes = New System.Windows.Forms.GroupBox()
        Me.lblJobNotes = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.TextBox26 = New System.Windows.Forms.TextBox()
        Me.lblHeightController = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.gboInvoiceTo = New System.Windows.Forms.GroupBox()
        Me.PictureBox14 = New System.Windows.Forms.PictureBox()
        Me.PictureBox15 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.gboShipTo = New System.Windows.Forms.GroupBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.PictureBox13 = New System.Windows.Forms.PictureBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboShipTo = New System.Windows.Forms.ComboBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.TextBox29 = New System.Windows.Forms.TextBox()
        Me.listChanges = New System.Windows.Forms.ListBox()
        Me.lblChanges = New System.Windows.Forms.Label()
        Me.tip = New System.Windows.Forms.ToolTip(Me.components)
        Me.img = New System.Windows.Forms.ImageList(Me.components)
        Me.err = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.projectInfoMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.fileMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.saveMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.closeMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.reportsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CoverLetterApproval = New System.Windows.Forms.ToolStripMenuItem()
        Me.coverLetterReview = New System.Windows.Forms.ToolStripMenuItem()
        Me.coverPageMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContactManagerControl1 = New Rae.RaeSolutions.ContactManagerControl()
        Me.SaveToolStripPanel1 = New Rae.RaeSolutions.SaveToolStripPanel()
        Me.panMain.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.gboFooter.SuspendLayout()
        Me.gboPricing.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gboNotes.SuspendLayout()
        Me.gboInvoiceTo.SuspendLayout()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboShipTo.SuspendLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.err, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.projectInfoMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'panMain
        '
        Me.panMain.AutoScroll = True
        Me.panMain.BackColor = System.Drawing.Color.White
        Me.panMain.Controls.Add(Me.lblNotesHeader)
        Me.panMain.Controls.Add(Me.chkInvoiceToContractor)
        Me.panMain.Controls.Add(Me.Panel3)
        Me.panMain.Controls.Add(Me.gboFooter)
        Me.panMain.Controls.Add(Me.Label57)
        Me.panMain.Controls.Add(Me.gboPricing)
        Me.panMain.Controls.Add(Me.gboNotes)
        Me.panMain.Controls.Add(Me.lblHeightController)
        Me.panMain.Controls.Add(Me.Label44)
        Me.panMain.Controls.Add(Me.gboInvoiceTo)
        Me.panMain.Controls.Add(Me.Label43)
        Me.panMain.Controls.Add(Me.gboShipTo)
        Me.panMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panMain.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panMain.Location = New System.Drawing.Point(0, 0)
        Me.panMain.Name = "panMain"
        Me.panMain.Size = New System.Drawing.Size(755, 369)
        Me.panMain.TabIndex = 3
        '
        'lblNotesHeader
        '
        Me.lblNotesHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotesHeader.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblNotesHeader.Location = New System.Drawing.Point(336, 326)
        Me.lblNotesHeader.Name = "lblNotesHeader"
        Me.lblNotesHeader.Size = New System.Drawing.Size(112, 23)
        Me.lblNotesHeader.TabIndex = 148
        Me.lblNotesHeader.Text = "Notes"
        Me.lblNotesHeader.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.lblNotesHeader.Visible = False
        '
        'chkInvoiceToContractor
        '
        Me.chkInvoiceToContractor.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkInvoiceToContractor.Location = New System.Drawing.Point(92, 349)
        Me.chkInvoiceToContractor.Name = "chkInvoiceToContractor"
        Me.chkInvoiceToContractor.Size = New System.Drawing.Size(156, 16)
        Me.chkInvoiceToContractor.TabIndex = 108
        Me.chkInvoiceToContractor.Text = "Ship to contractor"
        Me.chkInvoiceToContractor.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Panel3.Controls.Add(Me.btnSalesOrderEntry)
        Me.Panel3.Controls.Add(Me.btnOrderEntry)
        Me.Panel3.Controls.Add(Me.btnGenerateProposal)
        Me.Panel3.Controls.Add(Me.btnCopyToCloud)
        Me.Panel3.Controls.Add(Me.copyExistingItemButton)
        Me.Panel3.Controls.Add(Me.btnProcessOrder)
        Me.Panel3.Controls.Add(Me.btnBoxLoad)
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.releaseStatusLabel)
        Me.Panel3.Controls.Add(Me.projectIdTextBox)
        Me.Panel3.Controls.Add(Me.releaseStatusComboBox)
        Me.Panel3.Controls.Add(Me.releaseNumTextBox)
        Me.Panel3.Controls.Add(Me.purchaseOrderNumLabel)
        Me.Panel3.Controls.Add(Me.assignReleaseNumLinkLabel)
        Me.Panel3.Controls.Add(Me.purchaseOrderNumTextBox)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(738, 66)
        Me.Panel3.TabIndex = 103
        '
        'btnSalesOrderEntry
        '
        Me.btnSalesOrderEntry.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalesOrderEntry.AutoEllipsis = True
        Me.btnSalesOrderEntry.Location = New System.Drawing.Point(563, 37)
        Me.btnSalesOrderEntry.Name = "btnSalesOrderEntry"
        Me.btnSalesOrderEntry.Size = New System.Drawing.Size(135, 23)
        Me.btnSalesOrderEntry.TabIndex = 121
        Me.btnSalesOrderEntry.Text = "Sales Order Entry"
        Me.btnSalesOrderEntry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalesOrderEntry.UseVisualStyleBackColor = True
        Me.btnSalesOrderEntry.Visible = False
        '
        'btnOrderEntry
        '
        Me.btnOrderEntry.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOrderEntry.Location = New System.Drawing.Point(563, 36)
        Me.btnOrderEntry.Name = "btnOrderEntry"
        Me.btnOrderEntry.Size = New System.Drawing.Size(135, 23)
        Me.btnOrderEntry.TabIndex = 120
        Me.btnOrderEntry.Text = "Order Entry Form"
        Me.btnOrderEntry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOrderEntry.UseVisualStyleBackColor = True
        '
        'btnGenerateProposal
        '
        Me.btnGenerateProposal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateProposal.Location = New System.Drawing.Point(495, 7)
        Me.btnGenerateProposal.Name = "btnGenerateProposal"
        Me.btnGenerateProposal.Size = New System.Drawing.Size(203, 23)
        Me.btnGenerateProposal.TabIndex = 117
        Me.btnGenerateProposal.Text = "Generate Project Reports"
        Me.btnGenerateProposal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnGenerateProposal.UseVisualStyleBackColor = True
        '
        'btnCopyToCloud
        '
        Me.btnCopyToCloud.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopyToCloud.Location = New System.Drawing.Point(563, 36)
        Me.btnCopyToCloud.Name = "btnCopyToCloud"
        Me.btnCopyToCloud.Size = New System.Drawing.Size(135, 23)
        Me.btnCopyToCloud.TabIndex = 116
        Me.btnCopyToCloud.Text = "Save to Cloud"
        Me.btnCopyToCloud.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCopyToCloud.UseVisualStyleBackColor = True
        Me.btnCopyToCloud.Visible = False
        '
        'copyExistingItemButton
        '
        Me.copyExistingItemButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.copyExistingItemButton.Location = New System.Drawing.Point(422, 36)
        Me.copyExistingItemButton.Name = "copyExistingItemButton"
        Me.copyExistingItemButton.Size = New System.Drawing.Size(135, 23)
        Me.copyExistingItemButton.TabIndex = 115
        Me.copyExistingItemButton.Text = "Copy Existing Item..."
        Me.copyExistingItemButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.copyExistingItemButton.UseVisualStyleBackColor = True
        '
        'btnProcessOrder
        '
        Me.btnProcessOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnProcessOrder.Location = New System.Drawing.Point(315, 7)
        Me.btnProcessOrder.Name = "btnProcessOrder"
        Me.btnProcessOrder.Size = New System.Drawing.Size(174, 23)
        Me.btnProcessOrder.TabIndex = 118
        Me.btnProcessOrder.Text = "Place Order to Cloud"
        Me.btnProcessOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnProcessOrder.UseVisualStyleBackColor = True
        '
        'btnBoxLoad
        '
        Me.btnBoxLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBoxLoad.Location = New System.Drawing.Point(24, 36)
        Me.btnBoxLoad.Name = "btnBoxLoad"
        Me.btnBoxLoad.Size = New System.Drawing.Size(99, 23)
        Me.btnBoxLoad.TabIndex = 114
        Me.btnBoxLoad.Text = "New Box Load..."
        Me.btnBoxLoad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBoxLoad.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(272, 36)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(144, 23)
        Me.Button2.TabIndex = 113
        Me.Button2.Text = "New selection / rating..."
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(125, 36)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 23)
        Me.Button1.TabIndex = 112
        Me.Button1.Text = "New equipment pricing..."
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'releaseStatusLabel
        '
        Me.releaseStatusLabel.Location = New System.Drawing.Point(2, 9)
        Me.releaseStatusLabel.Name = "releaseStatusLabel"
        Me.releaseStatusLabel.Size = New System.Drawing.Size(49, 21)
        Me.releaseStatusLabel.TabIndex = 111
        Me.releaseStatusLabel.Text = "Status"
        Me.releaseStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'projectIdTextBox
        '
        Me.projectIdTextBox.Location = New System.Drawing.Point(143, 10)
        Me.projectIdTextBox.Name = "projectIdTextBox"
        Me.projectIdTextBox.ReadOnly = True
        Me.projectIdTextBox.Size = New System.Drawing.Size(144, 21)
        Me.projectIdTextBox.TabIndex = 110
        Me.tip.SetToolTip(Me.projectIdTextBox, "Auto-assigned project ID")
        Me.projectIdTextBox.Visible = False
        '
        'releaseStatusComboBox
        '
        Me.releaseStatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.releaseStatusComboBox.Items.AddRange(New Object() {"Project", "HR", "PR"})
        Me.releaseStatusComboBox.Location = New System.Drawing.Point(59, 10)
        Me.releaseStatusComboBox.Name = "releaseStatusComboBox"
        Me.releaseStatusComboBox.Size = New System.Drawing.Size(78, 21)
        Me.releaseStatusComboBox.TabIndex = 1
        '
        'releaseNumTextBox
        '
        Me.releaseNumTextBox.Location = New System.Drawing.Point(143, 11)
        Me.releaseNumTextBox.Name = "releaseNumTextBox"
        Me.releaseNumTextBox.Size = New System.Drawing.Size(144, 21)
        Me.releaseNumTextBox.TabIndex = 2
        Me.tip.SetToolTip(Me.releaseNumTextBox, "HR/PR number")
        '
        'purchaseOrderNumLabel
        '
        Me.purchaseOrderNumLabel.Location = New System.Drawing.Point(184, 36)
        Me.purchaseOrderNumLabel.Name = "purchaseOrderNumLabel"
        Me.purchaseOrderNumLabel.Size = New System.Drawing.Size(92, 23)
        Me.purchaseOrderNumLabel.TabIndex = 96
        Me.purchaseOrderNumLabel.Text = "Purchase order #"
        Me.purchaseOrderNumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.purchaseOrderNumLabel.Visible = False
        '
        'assignReleaseNumLinkLabel
        '
        Me.assignReleaseNumLinkLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.assignReleaseNumLinkLabel.Image = CType(resources.GetObject("assignReleaseNumLinkLabel.Image"), System.Drawing.Image)
        Me.assignReleaseNumLinkLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.assignReleaseNumLinkLabel.LinkColor = System.Drawing.Color.RoyalBlue
        Me.assignReleaseNumLinkLabel.Location = New System.Drawing.Point(261, 34)
        Me.assignReleaseNumLinkLabel.Name = "assignReleaseNumLinkLabel"
        Me.assignReleaseNumLinkLabel.Size = New System.Drawing.Size(84, 26)
        Me.assignReleaseNumLinkLabel.TabIndex = 109
        Me.assignReleaseNumLinkLabel.TabStop = True
        Me.assignReleaseNumLinkLabel.Text = "Assign HR#"
        Me.assignReleaseNumLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.assignReleaseNumLinkLabel.Visible = False
        '
        'purchaseOrderNumTextBox
        '
        Me.purchaseOrderNumTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.purchaseOrderNumTextBox.Location = New System.Drawing.Point(164, 36)
        Me.purchaseOrderNumTextBox.Name = "purchaseOrderNumTextBox"
        Me.purchaseOrderNumTextBox.Size = New System.Drawing.Size(151, 21)
        Me.purchaseOrderNumTextBox.TabIndex = 97
        Me.purchaseOrderNumTextBox.Visible = False
        '
        'gboFooter
        '
        Me.gboFooter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gboFooter.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.gboFooter.Controls.Add(Me.lblFooter)
        Me.gboFooter.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.gboFooter.Location = New System.Drawing.Point(12, 293)
        Me.gboFooter.Name = "gboFooter"
        Me.gboFooter.Size = New System.Drawing.Size(955, 28)
        Me.gboFooter.TabIndex = 91
        Me.gboFooter.TabStop = False
        Me.gboFooter.Visible = False
        '
        'lblFooter
        '
        Me.lblFooter.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFooter.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblFooter.Location = New System.Drawing.Point(7, 12)
        Me.lblFooter.Name = "lblFooter"
        Me.lblFooter.Size = New System.Drawing.Size(125, 14)
        Me.lblFooter.TabIndex = 91
        Me.lblFooter.Text = "R - Required field"
        Me.tip.SetToolTip(Me.lblFooter, "Required field")
        '
        'Label57
        '
        Me.Label57.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label57.Location = New System.Drawing.Point(336, 342)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(112, 23)
        Me.Label57.TabIndex = 102
        Me.Label57.Text = "Pricing"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Label57.Visible = False
        '
        'gboPricing
        '
        Me.gboPricing.Controls.Add(Me.Panel2)
        Me.gboPricing.Controls.Add(Me.Panel1)
        Me.gboPricing.Controls.Add(Me.lblFreight)
        Me.gboPricing.Controls.Add(Me.lblTaxes)
        Me.gboPricing.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.gboPricing.Location = New System.Drawing.Point(332, 303)
        Me.gboPricing.Name = "gboPricing"
        Me.gboPricing.Size = New System.Drawing.Size(316, 216)
        Me.gboPricing.TabIndex = 101
        Me.gboPricing.TabStop = False
        Me.gboPricing.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TextBox27)
        Me.Panel2.Controls.Add(Me.radTaxExemptNumber)
        Me.Panel2.Controls.Add(Me.radTaxable)
        Me.Panel2.Controls.Add(Me.radResale)
        Me.Panel2.Location = New System.Drawing.Point(60, 10)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(232, 88)
        Me.Panel2.TabIndex = 12
        '
        'TextBox27
        '
        Me.TextBox27.Location = New System.Drawing.Point(104, 56)
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.Size = New System.Drawing.Size(112, 21)
        Me.TextBox27.TabIndex = 8
        '
        'radTaxExemptNumber
        '
        Me.radTaxExemptNumber.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.radTaxExemptNumber.Location = New System.Drawing.Point(8, 56)
        Me.radTaxExemptNumber.Name = "radTaxExemptNumber"
        Me.radTaxExemptNumber.Size = New System.Drawing.Size(100, 24)
        Me.radTaxExemptNumber.TabIndex = 7
        Me.radTaxExemptNumber.Text = "Tax exempt #"
        '
        'radTaxable
        '
        Me.radTaxable.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.radTaxable.Location = New System.Drawing.Point(8, 32)
        Me.radTaxable.Name = "radTaxable"
        Me.radTaxable.Size = New System.Drawing.Size(128, 24)
        Me.radTaxable.TabIndex = 6
        Me.radTaxable.Text = "Taxable"
        '
        'radResale
        '
        Me.radResale.Checked = True
        Me.radResale.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.radResale.Location = New System.Drawing.Point(8, 8)
        Me.radResale.Name = "radResale"
        Me.radResale.Size = New System.Drawing.Size(128, 24)
        Me.radResale.TabIndex = 5
        Me.radResale.TabStop = True
        Me.radResale.Text = "Resale"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TextBox30)
        Me.Panel1.Controls.Add(Me.RadioButton1)
        Me.Panel1.Controls.Add(Me.RadioButton2)
        Me.Panel1.Controls.Add(Me.RadioButton3)
        Me.Panel1.Controls.Add(Me.RadioButton4)
        Me.Panel1.Location = New System.Drawing.Point(60, 102)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(232, 104)
        Me.Panel1.TabIndex = 11
        '
        'TextBox30
        '
        Me.TextBox30.Location = New System.Drawing.Point(68, 80)
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.Size = New System.Drawing.Size(148, 21)
        Me.TextBox30.TabIndex = 12
        '
        'RadioButton1
        '
        Me.RadioButton1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RadioButton1.Location = New System.Drawing.Point(8, 80)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(56, 24)
        Me.RadioButton1.TabIndex = 11
        Me.RadioButton1.Text = "Other"
        '
        'RadioButton2
        '
        Me.RadioButton2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RadioButton2.Location = New System.Drawing.Point(8, 32)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(128, 24)
        Me.RadioButton2.TabIndex = 10
        Me.RadioButton2.Text = "Collect"
        '
        'RadioButton3
        '
        Me.RadioButton3.Checked = True
        Me.RadioButton3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RadioButton3.Location = New System.Drawing.Point(8, 8)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(128, 24)
        Me.RadioButton3.TabIndex = 9
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Allowed"
        '
        'RadioButton4
        '
        Me.RadioButton4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RadioButton4.Location = New System.Drawing.Point(8, 56)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(128, 24)
        Me.RadioButton4.TabIndex = 13
        Me.RadioButton4.Text = "Prepay and add"
        '
        'lblFreight
        '
        Me.lblFreight.Location = New System.Drawing.Point(4, 108)
        Me.lblFreight.Name = "lblFreight"
        Me.lblFreight.Size = New System.Drawing.Size(48, 24)
        Me.lblFreight.TabIndex = 10
        Me.lblFreight.Text = "Freight"
        Me.lblFreight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTaxes
        '
        Me.lblTaxes.Location = New System.Drawing.Point(4, 16)
        Me.lblTaxes.Name = "lblTaxes"
        Me.lblTaxes.Size = New System.Drawing.Size(48, 24)
        Me.lblTaxes.TabIndex = 9
        Me.lblTaxes.Text = "Taxes"
        Me.lblTaxes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gboNotes
        '
        Me.gboNotes.Controls.Add(Me.lblJobNotes)
        Me.gboNotes.Controls.Add(Me.txtNotes)
        Me.gboNotes.Controls.Add(Me.Label54)
        Me.gboNotes.Controls.Add(Me.TextBox26)
        Me.gboNotes.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.gboNotes.Location = New System.Drawing.Point(332, 147)
        Me.gboNotes.Name = "gboNotes"
        Me.gboNotes.Size = New System.Drawing.Size(316, 124)
        Me.gboNotes.TabIndex = 99
        Me.gboNotes.TabStop = False
        Me.gboNotes.Visible = False
        '
        'lblJobNotes
        '
        Me.lblJobNotes.BackColor = System.Drawing.Color.Transparent
        Me.lblJobNotes.Location = New System.Drawing.Point(8, 20)
        Me.lblJobNotes.Name = "lblJobNotes"
        Me.lblJobNotes.Size = New System.Drawing.Size(60, 23)
        Me.lblJobNotes.TabIndex = 20
        Me.lblJobNotes.Text = "Job notes"
        Me.lblJobNotes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNotes
        '
        Me.txtNotes.Location = New System.Drawing.Point(80, 20)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(216, 60)
        Me.txtNotes.TabIndex = 21
        '
        'Label54
        '
        Me.Label54.BackColor = System.Drawing.Color.Transparent
        Me.Label54.Location = New System.Drawing.Point(4, 88)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(64, 24)
        Me.Label54.TabIndex = 22
        Me.Label54.Text = "Crate tag"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox26
        '
        Me.TextBox26.Location = New System.Drawing.Point(80, 88)
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Size = New System.Drawing.Size(216, 21)
        Me.TextBox26.TabIndex = 23
        '
        'lblHeightController
        '
        Me.lblHeightController.BackColor = System.Drawing.Color.Red
        Me.lblHeightController.Location = New System.Drawing.Point(484, 275)
        Me.lblHeightController.Name = "lblHeightController"
        Me.lblHeightController.Size = New System.Drawing.Size(100, 23)
        Me.lblHeightController.TabIndex = 98
        Me.lblHeightController.Visible = False
        '
        'Label44
        '
        Me.Label44.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label44.Location = New System.Drawing.Point(16, 323)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(112, 23)
        Me.Label44.TabIndex = 95
        Me.Label44.Text = "Invoice To"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Label44.Visible = False
        '
        'gboInvoiceTo
        '
        Me.gboInvoiceTo.Controls.Add(Me.PictureBox14)
        Me.gboInvoiceTo.Controls.Add(Me.PictureBox15)
        Me.gboInvoiceTo.Controls.Add(Me.Label4)
        Me.gboInvoiceTo.Controls.Add(Me.ComboBox1)
        Me.gboInvoiceTo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.gboInvoiceTo.Location = New System.Drawing.Point(12, 343)
        Me.gboInvoiceTo.Name = "gboInvoiceTo"
        Me.gboInvoiceTo.Size = New System.Drawing.Size(316, 56)
        Me.gboInvoiceTo.TabIndex = 94
        Me.gboInvoiceTo.TabStop = False
        Me.gboInvoiceTo.Visible = False
        '
        'PictureBox14
        '
        Me.PictureBox14.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox14.Image = CType(resources.GetObject("PictureBox14.Image"), System.Drawing.Image)
        Me.PictureBox14.Location = New System.Drawing.Point(290, 20)
        Me.PictureBox14.Name = "PictureBox14"
        Me.PictureBox14.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox14.TabIndex = 152
        Me.PictureBox14.TabStop = False
        Me.tip.SetToolTip(Me.PictureBox14, "Edit rep company info")
        '
        'PictureBox15
        '
        Me.PictureBox15.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox15.Image = CType(resources.GetObject("PictureBox15.Image"), System.Drawing.Image)
        Me.PictureBox15.Location = New System.Drawing.Point(270, 20)
        Me.PictureBox15.Name = "PictureBox15"
        Me.PictureBox15.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox15.TabIndex = 151
        Me.PictureBox15.TabStop = False
        Me.tip.SetToolTip(Me.PictureBox15, "Add new rep company")
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(6, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 23)
        Me.Label4.TabIndex = 150
        Me.Label4.Text = "Invoice to"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Items.AddRange(New Object() {"New", "Somewhere", "No Where"})
        Me.ComboBox1.Location = New System.Drawing.Point(78, 20)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(188, 21)
        Me.ComboBox1.TabIndex = 149
        '
        'Label43
        '
        Me.Label43.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label43.Location = New System.Drawing.Point(16, 171)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(112, 23)
        Me.Label43.TabIndex = 93
        Me.Label43.Text = "Ship To"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Label43.Visible = False
        '
        'gboShipTo
        '
        Me.gboShipTo.Controls.Add(Me.DateTimePicker1)
        Me.gboShipTo.Controls.Add(Me.Label5)
        Me.gboShipTo.Controls.Add(Me.PictureBox9)
        Me.gboShipTo.Controls.Add(Me.PictureBox13)
        Me.gboShipTo.Controls.Add(Me.Label15)
        Me.gboShipTo.Controls.Add(Me.cboShipTo)
        Me.gboShipTo.Controls.Add(Me.Label56)
        Me.gboShipTo.Controls.Add(Me.Label58)
        Me.gboShipTo.Controls.Add(Me.TextBox29)
        Me.gboShipTo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.gboShipTo.Location = New System.Drawing.Point(12, 191)
        Me.gboShipTo.Name = "gboShipTo"
        Me.gboShipTo.Size = New System.Drawing.Size(316, 120)
        Me.gboShipTo.TabIndex = 92
        Me.gboShipTo.TabStop = False
        Me.gboShipTo.Visible = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "ddd, MMM dd, yyyy"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(80, 84)
        Me.DateTimePicker1.MaxDate = New Date(2015, 12, 31, 0, 0, 0, 0)
        Me.DateTimePicker1.MinDate = New Date(2005, 11, 1, 0, 0, 0, 0)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(184, 21)
        Me.DateTimePicker1.TabIndex = 150
        Me.DateTimePicker1.Value = New Date(2005, 11, 4, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(4, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 28)
        Me.Label5.TabIndex = 149
        Me.Label5.Text = "Requested ship date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox9
        '
        Me.PictureBox9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(288, 20)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox9.TabIndex = 148
        Me.PictureBox9.TabStop = False
        Me.tip.SetToolTip(Me.PictureBox9, "Edit rep company info")
        '
        'PictureBox13
        '
        Me.PictureBox13.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox13.Image = CType(resources.GetObject("PictureBox13.Image"), System.Drawing.Image)
        Me.PictureBox13.Location = New System.Drawing.Point(268, 20)
        Me.PictureBox13.Name = "PictureBox13"
        Me.PictureBox13.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox13.TabIndex = 147
        Me.PictureBox13.TabStop = False
        Me.tip.SetToolTip(Me.PictureBox13, "Add new rep company")
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(8, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 23)
        Me.Label15.TabIndex = 146
        Me.Label15.Text = "Ship to"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboShipTo
        '
        Me.cboShipTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboShipTo.Items.AddRange(New Object() {"New", "Somewhere", "No Where"})
        Me.cboShipTo.Location = New System.Drawing.Point(80, 20)
        Me.cboShipTo.Name = "cboShipTo"
        Me.cboShipTo.Size = New System.Drawing.Size(184, 21)
        Me.cboShipTo.TabIndex = 145
        '
        'Label56
        '
        Me.Label56.BackColor = System.Drawing.Color.Transparent
        Me.Label56.Location = New System.Drawing.Point(40, 52)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(28, 24)
        Me.Label56.TabIndex = 142
        Me.Label56.Text = "Call"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.Color.Transparent
        Me.Label58.Location = New System.Drawing.Point(112, 52)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(128, 24)
        Me.Label58.TabIndex = 144
        Me.Label58.Text = "hours before delivery"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox29
        '
        Me.TextBox29.Location = New System.Drawing.Point(80, 52)
        Me.TextBox29.MaxLength = 2
        Me.TextBox29.Name = "TextBox29"
        Me.TextBox29.Size = New System.Drawing.Size(28, 21)
        Me.TextBox29.TabIndex = 143
        Me.TextBox29.Text = "24"
        Me.TextBox29.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'listChanges
        '
        Me.listChanges.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listChanges.ForeColor = System.Drawing.SystemColors.ControlText
        Me.listChanges.FormattingEnabled = True
        Me.listChanges.ItemHeight = 16
        Me.listChanges.Items.AddRange(New Object() {"Test", "Test"})
        Me.listChanges.Location = New System.Drawing.Point(131, 11)
        Me.listChanges.Name = "listChanges"
        Me.listChanges.Size = New System.Drawing.Size(542, 20)
        Me.listChanges.TabIndex = 153
        '
        'lblChanges
        '
        Me.lblChanges.BackColor = System.Drawing.Color.Transparent
        Me.lblChanges.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChanges.Location = New System.Drawing.Point(1, 1)
        Me.lblChanges.Name = "lblChanges"
        Me.lblChanges.Size = New System.Drawing.Size(131, 39)
        Me.lblChanges.TabIndex = 152
        Me.lblChanges.Text = " Project Revisions"
        Me.lblChanges.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tip
        '
        Me.tip.AutoPopDelay = 10000
        Me.tip.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tip.InitialDelay = 500
        Me.tip.IsBalloon = True
        Me.tip.ReshowDelay = 200
        Me.tip.ShowAlways = True
        '
        'img
        '
        Me.img.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.img.ImageSize = New System.Drawing.Size(16, 16)
        Me.img.TransparentColor = System.Drawing.Color.Transparent
        '
        'err
        '
        Me.err.ContainerControl = Me
        Me.err.Icon = CType(resources.GetObject("err.Icon"), System.Drawing.Icon)
        '
        'projectInfoMenuStrip
        '
        Me.projectInfoMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileMenuItem, Me.reportsMenuItem})
        Me.projectInfoMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.projectInfoMenuStrip.Name = "projectInfoMenuStrip"
        Me.projectInfoMenuStrip.Size = New System.Drawing.Size(711, 24)
        Me.projectInfoMenuStrip.TabIndex = 4
        Me.projectInfoMenuStrip.Text = "MenuStrip1"
        Me.projectInfoMenuStrip.Visible = False
        '
        'fileMenuItem
        '
        Me.fileMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.saveMenuItem, Me.closeMenuItem})
        Me.fileMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly
        Me.fileMenuItem.Name = "fileMenuItem"
        Me.fileMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.fileMenuItem.Text = "&File"
        '
        'saveMenuItem
        '
        Me.saveMenuItem.MergeIndex = 1
        Me.saveMenuItem.Name = "saveMenuItem"
        Me.saveMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.saveMenuItem.Text = "Save"
        '
        'closeMenuItem
        '
        Me.closeMenuItem.MergeIndex = 2
        Me.closeMenuItem.Name = "closeMenuItem"
        Me.closeMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.closeMenuItem.Text = "Close"
        '
        'reportsMenuItem
        '
        Me.reportsMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CoverLetterApproval, Me.coverLetterReview, Me.coverPageMenuItem})
        Me.reportsMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly
        Me.reportsMenuItem.Name = "reportsMenuItem"
        Me.reportsMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.reportsMenuItem.Text = "&Reports"
        '
        'CoverLetterApproval
        '
        Me.CoverLetterApproval.Name = "CoverLetterApproval"
        Me.CoverLetterApproval.Size = New System.Drawing.Size(217, 22)
        Me.CoverLetterApproval.Text = "Cover Letter - For Approval"
        '
        'coverLetterReview
        '
        Me.coverLetterReview.Name = "coverLetterReview"
        Me.coverLetterReview.Size = New System.Drawing.Size(217, 22)
        Me.coverLetterReview.Text = "Cover Letter - For Review"
        '
        'coverPageMenuItem
        '
        Me.coverPageMenuItem.Name = "coverPageMenuItem"
        Me.coverPageMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.coverPageMenuItem.Text = "Cover Page"
        '
        'ContactManagerControl1
        '
        Me.ContactManagerControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ContactManagerControl1.BackColor = System.Drawing.Color.White
        Me.ContactManagerControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContactManagerControl1.CanEdit = True
        Me.ContactManagerControl1.ContactLimit = 999
        Me.ContactManagerControl1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContactManagerControl1.Location = New System.Drawing.Point(12, 77)
        Me.ContactManagerControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ContactManagerControl1.Name = "ContactManagerControl1"
        Me.ContactManagerControl1.SelectedContactControl = Nothing
        Me.ContactManagerControl1.Size = New System.Drawing.Size(728, 279)
        Me.ContactManagerControl1.TabIndex = 149
        '
        'SaveToolStripPanel1
        '
        Me.SaveToolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SaveToolStripPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SaveToolStripPanel1.Name = "SaveToolStripPanel1"
        Me.SaveToolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.SaveToolStripPanel1.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.SaveToolStripPanel1.Size = New System.Drawing.Size(755, 0)
        '
        'ProjectForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(755, 369)
        Me.Controls.Add(Me.ContactManagerControl1)
        Me.Controls.Add(Me.panMain)
        Me.Controls.Add(Me.SaveToolStripPanel1)
        Me.Controls.Add(Me.projectInfoMenuStrip)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuStrip = Me.projectInfoMenuStrip
        Me.Name = "ProjectForm"
        Me.Text = "Project Information"
        Me.panMain.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.gboFooter.ResumeLayout(False)
        Me.gboPricing.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gboNotes.ResumeLayout(False)
        Me.gboNotes.PerformLayout()
        Me.gboInvoiceTo.ResumeLayout(False)
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboShipTo.ResumeLayout(False)
        Me.gboShipTo.PerformLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.err, System.ComponentModel.ISupportInitialize).EndInit()
        Me.projectInfoMenuStrip.ResumeLayout(False)
        Me.projectInfoMenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private currentState As ProjectItem ' set on open, stores grabbed ui state, new on load?
    Private loaded As Boolean
    Private _lastSavedState As ProjectItem
    Private _projectOwner As String


#Region " Properties"

    ReadOnly Property RepContact As Contact
        Get
            Return ContactManagerControl1.Contacts.Representative
        End Get
    End Property

    ReadOnly Property RepCompany As Company
        Get
            If ContactManagerControl1.Contacts.Representative IsNot Nothing Then
                Return ContactManagerControl1.Contacts.Representative.Company
            Else
                Return Nothing
            End If
        End Get
    End Property


    Property LastSavedState As ProjectItem
        Get
            Return _lastSavedState
        End Get
        Set(ByVal value As ProjectItem)
            _lastSavedState = value
        End Set
    End Property

    Property ProjectOwner As String
        Get
            Return _projectOwner
        End Get
        Set(ByVal value As String)
            _projectOwner = value
        End Set
    End Property

#End Region


#Region " Public methods"

    Public Sub Open(ByVal project As ProjectItem)
        releaseStatusComboBox.SelectedIndex = Me.releaseStatusComboBox.Items.IndexOf(project.ReleaseStatus.ToString)
        releaseNumTextBox.Text = project.ReleaseNum.ToString
        ContactManagerControl1.Initialize(project.id, project.Contacts)

        currentState = project
        _lastSavedState = currentState.Clone()
    End Sub

#End Region


#Region " Private methods"


#Region " Event handlers"

    Private Sub form_Activated() Handles Me.Activated
        initializeSaveToolStripPanel()
        Me.SaveToolStripPanel1.Merge()
    End Sub


    Private Sub form_Deactivate() Handles Me.Deactivate
        SaveToolStripPanel1.Unmerge()
    End Sub


    Private Sub form_Load() Handles MyBase.Load
        loaded = False

        initializeSaveToolStripPanel()

        currentState = New ProjectItem(New item_id(Me.Tag.ToString))
        projectIdTextBox.Text = currentState.id.SafeId

        initializeControls()

        loaded = True

        If AppInfo.User.is_rep Or AppInfo.Division = Division.TSI Then
            btnBoxLoad.Visible = False
        End If
    End Sub


    Private Sub form_FormClosing(ByVal s As Object, ByVal e As FormClosingEventArgs) _
    Handles Me.FormClosing
        Dim currentState = grabProject()

        If currentState.Equals(LastSavedState) Then
            ' no changes have been made allow closing to finish
        Else
            ' asks to save
            Dim result = MessageBox.Show("Do you want to save changes before closing?", My.Application.Info.Title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                saveToOpenedProject(currentState)
            ElseIf result = DialogResult.No Then
                ' allow to close
            ElseIf result = DialogResult.Cancel Then
                e.Cancel = True
            End If
        End If
    End Sub


    Private Sub saveMenuItem_Click(ByVal s As Object, ByVal e As EventArgs) Handles saveMenuItem.Click
        save()
    End Sub

    Private Sub closeMenuItem_Click() Handles closeMenuItem.Click
        Me.Close()
    End Sub


    'Private Sub coverLetterMenuItem_Click() Handles coverLetterMenuItem.Click
    '    Try
    '        Dim junk As String
    '        show_cover_letter(False, junk)
    '    Catch ex As Exception
    '        Rae.Ui.alert("Cover letter cannot be opened. " & ex.Message)
    '    End Try
    'End Sub

    Private Sub coverPageMenuItem_Click() Handles coverPageMenuItem.Click
        Dim filePath As String = ""
        show_cover_page(False, filePath)
    End Sub


    ''' <summary>
    ''' Handles release number text box key press event.
    ''' Allows only numbers to be entered as the release number.
    ''' </summary>
    Private Sub releaseNumTextBox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) _
    Handles releaseNumTextBox.KeyPress
        ' handles backspace
        Dim isBackSpace As Boolean = e.KeyChar.IsControl(e.KeyChar)
        If isBackSpace Then
            e.Handled = False
            Exit Sub
        End If

        ' allows only numbers
        Select Case e.KeyChar
            Case "0"c, "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c
                e.Handled = False
            Case Else
                warn("This text box is for the project's HR or PR number. It only allows numeric values.")
                e.Handled = True
        End Select
    End Sub

#End Region

    Private Sub initializeControls()
        Me.releaseStatusComboBox.SelectedIndex = 0
    End Sub


    ''' <summary>Initializes save tool strip panel. Sets event handlers and tool strip.</summary>
    Private Sub initializeSaveToolStripPanel()
        Me.SaveToolStripPanel1.Visible = True
        Me.SaveToolStripPanel1.SaveClick = AddressOf saveMenuItem_Click
        'Me.SaveToolStripPanel1.SaveAsRevisionClick = AddressOf SaveAsRevisionToolStripMenuItem_Click
        Me.SaveToolStripPanel1.SaveAsRevisionToolStripButton.Visible = False
        Me.SaveToolStripPanel1.TargetToolStrip = CType(Me.ParentForm, MainForm).mainToolStrip
        Me.SaveToolStripPanel1.Merge()
    End Sub


    ''' <summary>Opens submittal cover page report</summary>
    Private Sub show_cover_page(ByVal generateOnly As Boolean, ByRef filePath As String)
        ' validates inputs
        If Me.ContactManagerControl1.Contacts.Count = 0 Then
            warn("A contact must be selected before viewing cover page.")
            Exit Sub
        ElseIf Me.releaseStatusComboBox.SelectedItem Is Nothing Then
            warn("The release status must be selected before viewing cover page")
            Exit Sub
        End If

        ' lets user select who report is to
        Dim form As New SelectContactForReportForm()
        Try
            form.StartPosition = FormStartPosition.CenterScreen
            form.Height -= 100
            form.SplitContainer1.Panel2Collapsed = True
            form.Load(Me.ContactManagerControl1.Contacts)
        Catch ex As ArgumentException
            warn(ex.Message)
            Exit Sub
        End Try
        Dim result As DialogResult = form.ShowDialog()
        Dim [to], from As Contact
        If result = Windows.Forms.DialogResult.OK Then
            [to] = form.SelectedTo
        Else
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        ' builds parameters
        Dim projectName = Me.Text
        Dim projectInfo = "Project: " & projectName
        If Not Me.releaseStatusComboBox.SelectedItem.ToString() = "Project" Then
            projectInfo &= NewLine & Me.releaseStatusComboBox.SelectedItem.ToString() & ": " & Me.releaseNumTextBox.Text
        End If

        Dim raeDivision As String
        If AppInfo.Division = Business.Division.CRI Then
            raeDivision = "Century Refrigeration"
        ElseIf AppInfo.Division = Business.Division.TSI Then
            raeDivision = "Technical Systems"
        End If


        Dim report = New Rae.reporting.beta.report(reports.file_paths.cover_page_file_path)
        Dim text = New Dictionary(Of String, String)
        text.Add("representative_company", [to].Company.Name)
        text.Add("project_name", "Project: " & projectName)
        text.Add("representative", [to].Name.FirstThenLastName)
        text.Add("print_date", DateTime.Now.ToString("M/d/yyyy"))

        Dim release_status = ""
        If Not releaseStatusComboBox.SelectedItem.ToString = "Project" Then
            '            release_status = NewLine & releaseStatusComboBox.SelectedItem.ToString & ": " & releaseNumTextBox.Text
            release_status = releaseStatusComboBox.SelectedItem.ToString & ": " & releaseNumTextBox.Text
        End If
        text.Add("release_status", release_status)

        Dim logo_command = New get_logo_file_path_command(AppInfo.User, AppInfo.Division.ToString)
        Dim logo_file_path = logo_command.execute

        report.set_image("logo", logo_file_path)
        report.set_list("representative_address", [to].Address.ToString.Split(Rae.Io.Text.new_line).ToList)
        report.set_text(text)




        If generateOnly Then
            filePath = report.generate()
        Else
            report.show(MainForm.currentLogo)
        End If


        Me.Cursor = Cursors.Default
    End Sub


    Private Sub show_cover_letter(ByVal generateOnly As Boolean, ByRef filePath As String, ByVal recordOrApproval As String)
        'If Me.ContactManagerControl1.Contacts.Count = 0 Then
        '    warn("A contact must be selected before viewing cover letter.")
        '    Exit Sub
        'ElseIf Me.releaseStatusComboBox.SelectedItem Is Nothing Then
        '    warn("The release status must be selected before viewing cover letter")
        '    Exit Sub
        'End If

        'Dim form = New SelectContactForReportForm()
        'Try
        '    form.StartPosition = FormStartPosition.CenterScreen
        '    form.Height -= 100
        '    form.Load(ContactManagerControl1.Contacts)
        'Catch ex As ArgumentException
        '    warn(ex.Message)
        '    Exit Sub
        'End Try
        'Dim result = form.ShowDialog()

        'Dim [to], from As Contact
        'If result = Windows.Forms.DialogResult.OK Then
        '    [to] = form.SelectedTo
        '    from = form.SelectedFrom
        'Else
        '    Exit Sub
        'End If

        'Dim projectName = Me.Text

        'Dim report = New Rae.reporting.beta.report(reports.file_paths.cover_letter_file_path)

        'Dim text = New Dictionary(Of String, String)
        'text.Add("print_date", DateTime.Now.ToString("M/d/yyyy"))
        'text.Add("representative_first_name", [to].Name.FirstName)
        'text.Add("representative_last_name", [to].Name.LastName)
        'text.Add("representative_company", [to].Company.Name)
        'text.Add("creator", from.Name.FirstThenLastName)
        'text.Add("release_status", projectName)

        'text.Add("projectName", projectName)


        'text.Add("Ext", " ")

        'Dim prNumber = ""

        'Select Case releaseStatusComboBox.SelectedItem.ToString.ToUpper
        '    Case "PROJECT"
        '        text.Add("recordOrApproval", "project")
        '    Case "HR"
        '        text.Add("recordOrApproval", "approval")
        '    Case "PR"
        '        text.Add("recordOrApproval", "record")
        'End Select



        'prNumber = releaseStatusComboBox.SelectedItem.ToString & ": " & releaseNumTextBox.Text
        ''End If
        'text.Add("PR", prNumber)




        'Dim logo_command = New get_logo_file_path_command(AppInfo.User, AppInfo.Division.ToString)
        'Dim logo_file_path = logo_command.execute
        'Dim address = [to].Company.Address.ToString.Split(rae.Io.Text.new_line)
        'report.set_list("representative_address", address.ToList)
        'report.set_image("logo", logo_file_path)
        'report.set_text(text)


        'If generateOnly Then
        '    filePath = report.generate()
        'Else
        '    report.show()
        'End If


        If Me.ContactManagerControl1.Contacts.Count = 0 Then
            warn("A contact must be selected before viewing cover letter.")
            Exit Sub
        ElseIf Me.releaseStatusComboBox.SelectedItem Is Nothing Then
            warn("The release status must be selected before viewing cover letter")
            Exit Sub
        End If


        Dim form As New SelectContactForReportForm
        Try
            form.StartPosition = FormStartPosition.CenterScreen
            Dim form2 As SelectContactForReportForm = form
            form2.Height = (form2.Height - 100)
            form.Load(Me.ContactManagerControl1.Contacts)
        Catch EX As ArgumentException
            warn(EX.Message)
            Exit Sub
        End Try

        If (form.ShowDialog = DialogResult.OK) Then
            Dim str As String
            Dim phoneInfo As String
            Dim str6 As String
            Dim selectedTo As Contact = form.SelectedTo
            Dim selectedFrom As Contact = form.SelectedFrom
            Dim projectName As String = Me.Text
            Dim report As New Rae.reporting.beta.report(reports.file_paths.cover_letter_file_path)
            Dim text As New Dictionary(Of String, String)
            text.Add("print_date", DateTime.Now.ToString("M/d/yyyy"))
            text.Add("representative_first_name", selectedTo.Name.FirstName)
            text.Add("representative_last_name", selectedTo.Name.LastName)
            text.Add("representative_company", selectedTo.Company.Name)
            text.Add("creator", (selectedFrom.Name.FirstThenLastName & " "))
            text.Add("release_status", projectName)
            text.Add("projectName", projectName)
            text.Add("engineer", form.txtEngineer.Text)
            text.Add("salesperson", form.txtSalesperson.Text)
            If Not String.IsNullOrEmpty(selectedFrom.PhoneNum.ToString) Then
                phoneInfo = (" at " & selectedFrom.PhoneNum.ToString)
            Else
                phoneInfo = ""
            End If
            text.Add("ext", phoneInfo)
            Dim releaseMessage As String = Me.releaseNumTextBox.Text
            If String.IsNullOrEmpty(releaseMessage) Then
                releaseMessage = ""
            ElseIf (recordOrApproval.ToUpper = "APPROVAL") Then
                releaseMessage = ("HR# " & releaseMessage)
            Else
                releaseMessage = ("PR# " & releaseMessage)
            End If
            text.Add("PR", releaseMessage)
            text.Add("RecordOrApproval", recordOrApproval)
            If ((AppInfo.User.username.ToUpper = "BROOKEI") OrElse (AppInfo.User.username.ToUpper = "CASEYJ") OrElse (AppInfo.User.username.ToUpper = "DAKOTAL")) Then
                str = "Brooke Ivie"
                str6 = "Sales Support"
            Else
                str = " "
                str6 = " "
            End If
            text.Add("AdminAssist", str)
            text.Add("Title", str6)
            Dim str3 As String = New get_logo_file_path_command(AppInfo.User, AppInfo.Division.ToString).execute
            Dim address = selectedTo.Company.Address.ToString.Split(Rae.Io.Text.new_line)
            report.set_list("representative_address", address.ToList)
            report.set_image("logo", str3)
            report.set_text(text)
            If generateOnly Then
                filePath = report.generate
            Else
                report.show(MainForm.currentLogo)
            End If
        End If



    End Sub


    Private Sub save()
        Dim currentState = grabProject()

        saveToOpenedProject(currentState)

        _lastSavedState = currentState.Clone()
    End Sub


    Private Sub saveToOpenedProject(ByVal project As ProjectItem)
        ' copies data to opened project, so on load the opened project will have the latest data
        OpenedProject.Manager.Project.Copy(project)
        OpenedProject.Manager.Project.Save() ' saves to data store
        If OpenedProject.Manager.Project.ProjectOwner <> AppInfo.User.username Then
            ProjectInfo.RevisionProject(OpenedProject.Manager.Project.id.Id, "NOTE:  You are not the project owner.  (Owner: " & OpenedProject.Manager.Project.ProjectOwner & ")")
        End If
    End Sub


    Private Function grabProject() As ProjectItem
        Dim name = Me.Text
        Dim notes = txtNotes.Text
        If OpenedProject.IsOpened Then
            Me.ProjectOwner = Rae.RaeSolutions.DataAccess.Projects.ProjectsDataAccess.GetProjectOwner(OpenedProject.Manager.Project.id)
        End If

        With Me.currentState
            .Tag = Me.Tag.ToString()
            .name = name
            .Notes = notes
            .ProjectOwner = Me.ProjectOwner

            If String.IsNullOrEmpty(.ProjectOwner) Then
                If OpenedProject.IsOpened Then
                    .ProjectOwner = ProjectInfo.GetProjectOwner(OpenedProject.Manager.Project.id)
                    If .ProjectOwner.Trim < " " Then .ProjectOwner = AppInfo.User.username
                    Me.ProjectOwner = .ProjectOwner
                Else
                    .ProjectOwner = AppInfo.User.username
                    Me.ProjectOwner = AppInfo.User.username
                End If
            End If

            .ReleaseStatus = grabReleaseStatus()
            If Not releaseNumTextBox.Text = "<not assigned>" Then
                .ReleaseNum.set_to(releaseNumTextBox.Text)
            End If

            .Contacts = Me.ContactManagerControl1.Contacts
        End With

        Return Me.currentState
    End Function


    Private Function grabReleaseStatus() As Business.ReleaseStatus
        Dim status As Business.ReleaseStatus

        If Me.releaseStatusComboBox.SelectedItem Is Nothing Then
            status = Business.ReleaseStatus.NotSet
        ElseIf Me.releaseStatusComboBox.SelectedItem.ToString = "HR" Then
            status = Business.ReleaseStatus.HR
        ElseIf Me.releaseStatusComboBox.SelectedItem.ToString = "PR" Then
            status = Business.ReleaseStatus.PR
        ElseIf Me.releaseStatusComboBox.SelectedItem.ToString = "Project" Then
            status = Business.ReleaseStatus.Project
        Else
            status = Business.ReleaseStatus.NotSet
        End If

        Return status
    End Function

#End Region


    ''' <summary>
    ''' Handles release status combobox selected index changed event.
    ''' Shows project id if status is 'Project' or shows release number if status is 'HR' or 'PR'
    ''' </summary>
    Private Sub cboReleaseStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles releaseStatusComboBox.SelectedIndexChanged
        If Me.releaseStatusComboBox.SelectedItem Is Nothing Then
            ' should not occur
            Me.projectIdTextBox.Visible = True
        ElseIf Me.releaseStatusComboBox.SelectedItem.ToString = Business.ReleaseStatus.Project.ToString Then
            ' shows project ID textbox
            Me.projectIdTextBox.Visible = True
        Else
            ' hides project ID textbox
            Me.projectIdTextBox.Visible = False
            ' shows tool tip
            Me.tip.Show("HR/PR number", Me.releaseNumTextBox, 2000)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' creates equipment
        ProjectInfo.Creator.CreateEquipment()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CType(My.Application.ApplicationContext.MainForm, MainForm).StartNewProcess()
    End Sub


#Region " Not used yet"

    '''' <summary>
    '''' Fills combobox with list of abbreviations
    '''' </summary>
    'Private Sub FillStateCombobox(ByVal stateCombobox As Windows.Forms.ComboBox)
    '   ' retrieves table with 'Abbreviation's and 'FullName's for ea. US state
    '   Dim states As DataTable = OrderAssistanceDA.RetrieveUnitedStates()
    '   ' sorts by state abbreviations
    '   states.DefaultView.Sort = "Abbreviation ASC"
    '   ' sets datasource to table of states
    '   stateCombobox.DataSource = states
    '   ' displays the state abbreviation
    '   stateCombobox.DisplayMember = "Abbreviation"
    '   stateCombobox.ValueMember = "FullName"
    'End Sub


    'Private Sub lllAssignHrPr_LinkClicked(ByVal sender As Object, ByVal e As EventArgs) _
    'Handles assignReleaseNumLinkLabel.Click
    '   Dim hr As New DataAccess.ReleaseManager

    '   ' retrieves next unassigned hr number
    '   Me.releaseNumTextBox.Text = hr.ReleaseNumToString(hr.RetrieveNextUnassignedReleaseNum())
    'End Sub

#End Region

    Private Sub btnBoxLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoxLoad.Click
        ProjectInfo.Viewer.ViewBoxLoad()
    End Sub

    Private Sub copyExistingItemButton_Click(ByVal s As Object, ByVal e As EventArgs) _
    Handles copyExistingItemButton.Click
        Dim wf As New CopyExistingItemWorkFlow(OpenedProject.IsOpened)
        wf.Start()
    End Sub

    Private Sub btnProcessOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcessOrder.Click
        Dim orderEntryForm As New OrderEntry
        orderEntryForm.MdiParent = Me.MdiParent
        orderEntryForm.Show()
    End Sub

    Private Sub btnPlaceOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)





        'Dim coverPage As String = ""
        'show_cover_page(True, coverPage)
        'Dim file1 As New FileInfo(coverPage)
        'SendFile(file1.DirectoryName, file1.Name)



        'Dim coverLetter As String = ""
        'show_cover_letter(True, coverLetter)
        'Dim file2 As New FileInfo(coverLetter)
        'SendFile(file2.DirectoryName, file2.Name)


        'Dim sendEmailWS1 As New OrderPlacementWS.TransferFile
        'Dim orderNumber As String = OpenedProject.Manager.Project.ReleaseNum.ToString
        'Dim customerUserName As String = AppInfo.User.username
        'sendEmailWS1.SendNewOrderEmail(orderNumber, customerUserName, "e6dcf5cb-b8dc-48c1-bb8b-0a5912fddc3b")


        'For i As Integer = 0 To OpenedProject.Manager.Equipment.Count - 1

        '    Dim submittalFile As String = ""
        '    Dim projectForm = ProjectInfo.Viewer.ViewEquipment(OpenedProject.Manager.Equipment(i), True, True, submittalFile)
        '    Dim file3 As New FileInfo(submittalFile)
        '    SendFile(file3.DirectoryName, file3.Name)

        '    projectForm.Close()

        'Next i

        ' OpenedProject.Manager.Equipment(0).

        'Dim tempPath = My.Computer.FileSystem.SpecialDirectories.Temp
        'If Not tempPath.EndsWith("\") Then tempPath &= "\"


        '  '        SendFile(tempPath, "Unit64.dxf")
        '  SendFile(tempPath, "air_cooled_chiller_balance_20110609_153520.docx")
        '  SendFile(tempPath, "condensing_unit_accessories_20110531_155215.docx")
        '  SendFile(tempPath, "cu_uc_balance_20110504_144246.docx")
        '  '       SendFile(tempPath, "Unit60.dxf")
        '  '      SendFile(tempPath, "Unit61.dxf")
        '  '     SendFile(tempPath, "Unit62.dxf")
        '  '    SendFile(tempPath, "Unit63.dxf")
        '  '   SendFile(tempPath, "Unit64.dxf")
        ''  SendFile(tempPath, "Unit65.dxf")

        '



    End Sub


    'Private Sub SendFile(ByVal tempPath As String, ByVal fileName As String)
    '    Dim OrderPlacementWS1 As New OrderPlacementWS.TransferFile
    '    If Not tempPath.EndsWith("\") Then tempPath &= "\"
    '    Dim orderNumber As String = OpenedProject.Manager.Project.ReleaseNum.ToString   'OpenedProject.ProjectId.SafeId.ToString
    '    Dim customerUserName As String = AppInfo.User.username

    '    Dim input As New FileStream(tempPath & fileName, FileMode.Open)
    '    Dim reader As New BinaryReader(input)
    '    Dim bytes() As Byte
    '    bytes = reader.ReadBytes(CInt(input.Length))

    '    reader.Close()
    '    reader.Dispose()
    '    input.Close()
    '    input.Dispose()

    '    OrderPlacementWS1.SendFile(bytes, fileName, orderNumber, customerUserName)


    'End Sub


    Private Sub form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Private Sub CoverLetterApproval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CoverLetterApproval.Click
        Try
            Dim str As String
            Me.show_cover_letter(False, str, "approval")
        Catch ex As Exception
            Rae.Ui.alert("Cover letter cannot be opened. " & ex.Message)
        End Try

    End Sub

    Private Sub coverLetterReview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles coverLetterReview.Click
        Try
            Dim str As String
            Me.show_cover_letter(False, str, "record")
        Catch ex As Exception
            Rae.Ui.alert("Cover letter cannot be opened. " & ex.Message)
        End Try

    End Sub

    Private Sub btnCopyToCloud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyToCloud.Click
        Beep()
    End Sub

    Private Sub btnGenerateProposal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateProposal.Click


        Dim currentState = grabProject()

        If currentState.Equals(LastSavedState) Then
            MessageBox.Show("Be sure all pricing changes have been saved before generating proposal.")
            Dim ProposalPage As New ProposalGenerator
            ProposalPage.ShowDialog()

        Else
            ' asks to save
            Dim result = MessageBox.Show("You have unsaved changes that must be saved before generating a proposal.  Would you like to save these changes?", My.Application.Info.Title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                saveToOpenedProject(currentState)
                _lastSavedState = currentState.Clone()

                Dim ProposalPage As New ProposalGenerator
                ProposalPage.ShowDialog()


            ElseIf result = DialogResult.No Then
                ' allow to close
            ElseIf result = DialogResult.Cancel Then
                '  e.Cancel = True
            End If
        End If


    End Sub

    Private Sub btnOrderEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOrderEntry.Click


        Dim currentState = grabProject()

        If currentState.Equals(LastSavedState) Then
            'Dim ProposalPage As New ProposalGenerator
            'ProposalPage.ShowDialog()
            OrderEntryForm.Show()

        Else
            ' asks to save
            Dim result = MessageBox.Show("You have unsaved changes that must be saved before generating order entry form. Would you like to save these changes?", My.Application.Info.Title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                saveMenuItem.PerformClick()
                OrderEntryForm.Show()
            ElseIf result = DialogResult.No Then
                ' allow to close
                OrderEntryForm.Show()
            ElseIf result = DialogResult.Cancel Then
                '  e.Cancel = True
            End If
        End If


    End Sub

    Private Sub btnSalesOrderEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalesOrderEntry.Click
        btnSalesOrderEntryClick()
    End Sub


    Public Sub btnSalesOrderEntryClick()


        Dim currentState = grabProject()

        If currentState.Equals(LastSavedState) Then
            'Dim ProposalPage As New ProposalGenerator
            'ProposalPage.ShowDialog()
            SalesOrderEntryForm.Show()

        Else
            ' asks to save
            Dim result = MessageBox.Show("You have unsaved changes that must be saved before generating order entry form. Would you like to save these changes?", My.Application.Info.Title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                saveMenuItem.PerformClick()
                'generateDocument()
                SalesOrderEntryForm.Show()
            ElseIf result = DialogResult.No Then
                ' allow to close
                'generateDocument()
                SalesOrderEntryForm.Show()
            ElseIf result = DialogResult.Cancel Then
                'e.Cancel = True
            End If
        End If


    End Sub


    'Private Sub generateDocument()
    '    Dim projectID As String = OpenedProject.ProjectId.ToString()

    '    Dim sql = "select top 1 ProjectRevision, Name, ReleaseNum, HoursBeforeDeliveryToCall, PoNum, PoDate, RequestedShipDate, RepId, RepCompanyId, ProjectOwner from Projects where ProjectID = '" & projectID & "' ORDER BY ProjectRevision DESC"
    '    Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
    '    Dim command = connection.CreateCommand
    '    command.CommandText = sql
    '    Dim rdr As IDataReader

    '    Dim items As Integer = 0
    '    Dim releaseNum As String = ""
    '    Dim name As String = ""
    '    Dim repID As String = ""
    '    Dim repCompanyID As String = ""
    '    Dim poNumber As String = ""
    '    Dim requestedShipDate As String = ""
    '    Dim hoursBefore As String = ""
    '    Dim poDate As String = ""
    '    Dim salesman As String = ""
    '    Dim revisionNum As Integer = 0

    '    Try
    '        connection.Open()
    '        rdr = command.ExecuteReader()
    '        While rdr.Read
    '            releaseNum = rdr("ReleaseNum").ToString()
    '            name = rdr("Name").ToString()
    '            repID = rdr("RepID").ToString()
    '            repCompanyID = rdr("RepCompanyId").ToString()
    '            poNumber = rdr("PoNum").ToString()
    '            requestedShipDate = rdr("RequestedShipDate").ToString()
    '            If Not String.IsNullOrWhiteSpace(rdr("PoDate").ToString()) Then
    '                poDate = CDate(rdr("PoDate")).ToShortDateString()
    '            End If
    '            hoursBefore = rdr("HoursBeforeDeliveryToCall").ToString()
    '            salesman = rdr("ProjectOwner").ToString()
    '            revisionNum = rdr("ProjectRevision")
    '        End While
    '    Finally
    '        If rdr IsNot Nothing Then _
    '           rdr.Close()
    '        If connection.State <> ConnectionState.Closed Then connection.Close()
    '    End Try

    '    ', Series, Model, Quantity, ParMultiplier, WarrantyPrice, FreightPrice, Commission, CustomMod
    '    Dim sql1 = "select EquipmentID from Equipment where ProjectID = '" & projectID & "' AND ProjectRevision = " & revisionNum
    '    command.Parameters.Clear()
    '    command = connection.CreateCommand
    '    command.CommandText = sql1

    '    Dim equipIDList As New List(Of String)
    '    'Dim items As Integer = 0

    '    Try
    '        items = 0
    '        connection.Open()
    '        rdr = command.ExecuteReader()
    '        While rdr.Read
    '            items += 1
    '            equipIDList.Add(rdr("EquipmentID"))
    '        End While
    '    Finally
    '        If rdr IsNot Nothing Then _
    '           rdr.Close()
    '        If connection.State <> ConnectionState.Closed Then _
    '           connection.Close()
    '    End Try


    '    Dim sql2 = "select ContactID from ProjectContacts where ProjectID = '" & projectID & "'"
    '    command.Parameters.Clear()
    '    command = connection.CreateCommand
    '    command.CommandText = sql2

    '    Dim contactList As New List(Of String)
    '    'Dim items As Integer = 0

    '    Try
    '        connection.Open()
    '        rdr = command.ExecuteReader()
    '        While rdr.Read
    '            contactList.Add(rdr("ContactID").ToString())
    '        End While
    '    Finally
    '        If rdr IsNot Nothing Then _
    '           rdr.Close()
    '        If connection.State <> ConnectionState.Closed Then _
    '           connection.Close()
    '    End Try


    '    Dim sql3 = "select Description, FirstName, LastName, Line1, Line2, City, State, ZipCode5, ZipCode4, PhoneNumAreaCode, PhoneNum, " &
    '               "PhoneNumExtension from Contacts where (Description = 'Ship To' OR Description = 'Invoice To')"

    '    Dim firstPass As Boolean = True

    '    For Each contactID In contactList
    '        If firstPass = True Then
    '            sql3 &= " AND (Id = " & contactID
    '            firstPass = False
    '        Else
    '            sql3 &= " OR Id = " & contactID
    '        End If
    '    Next

    '    If contactList.Count > 0 Then
    '        sql3 &= ")"
    '    End If

    '    command.Parameters.Clear()
    '    command = connection.CreateCommand
    '    command.CommandText = sql3

    '    Dim shipName As String = ""
    '    Dim shipLine1 As String = ""
    '    Dim shipLine2 As String = ""
    '    Dim shipCity As String = ""
    '    Dim shipState As String = ""
    '    Dim shipZip As String = ""
    '    Dim shipPhone As String = ""

    '    Dim invoiceName As String = ""
    '    Dim invoiceLine1 As String = ""
    '    Dim invoiceLine2 As String = ""
    '    Dim invoiceCity As String = ""
    '    Dim invoiceState As String = ""
    '    Dim invoiceZip As String = ""
    '    Dim invoicePhone As String = ""

    '    Try
    '        connection.Open()
    '        rdr = command.ExecuteReader()
    '        While rdr.Read
    '            If rdr("Description").ToString().ToLower() = "ship to" Then
    '                shipName = rdr("FirstName").ToString().Trim() & " " & rdr("LastName").ToString().Trim()
    '                shipLine1 = rdr("Line1").ToString().Trim()
    '                shipLine2 = rdr("Line2").ToString().Trim()
    '                shipCity = rdr("City").ToString().Trim()
    '                shipState = rdr("State").ToString().Trim()

    '                If String.IsNullOrEmpty(rdr("ZipCode4")) Then
    '                    shipZip = rdr("ZipCode5").ToString().Trim()
    '                Else
    '                    shipZip = rdr("ZipCode5").ToString().Trim() & "-" & rdr("ZipCode4").ToString().Trim()
    '                End If

    '                If String.IsNullOrEmpty(rdr("PhoneNumExtension")) Then
    '                    shipPhone = rdr("PhoneNumAreaCode").ToString().Trim() & "-" & rdr("PhoneNum").ToString().Trim()
    '                Else
    '                    shipPhone = rdr("PhoneNumAreaCode").ToString().Trim() & "-" & rdr("PhoneNum").ToString().Trim()
    '                End If
    '            ElseIf rdr("Description").ToString().ToLower() = "invoice to" Then
    '                invoiceName = rdr("FirstName").ToString().Trim() & " " & rdr("LastName").ToString().Trim()
    '                invoiceLine1 = rdr("Line1").ToString().Trim()
    '                invoiceLine2 = rdr("Line2").ToString().Trim()
    '                invoiceCity = rdr("City").ToString().Trim()
    '                invoiceState = rdr("State").ToString().Trim()

    '                If String.IsNullOrEmpty(rdr("ZipCode4")) Then
    '                    invoiceZip = rdr("ZipCode5").ToString().Trim()
    '                Else
    '                    invoiceZip = rdr("ZipCode5").ToString().Trim() & "-" & rdr("ZipCode4").ToString().Trim()
    '                End If

    '                If String.IsNullOrEmpty(rdr("PhoneNumExtension")) Then
    '                    invoicePhone = rdr("PhoneNumAreaCode").ToString().Trim() & "-" & rdr("PhoneNum").ToString().Trim()
    '                Else
    '                    invoicePhone = rdr("PhoneNumAreaCode").ToString().Trim() & "-" & rdr("PhoneNum").ToString().Trim()
    '                End If
    '            End If
    '        End While
    '    Finally
    '        If rdr IsNot Nothing Then _
    '           rdr.Close()
    '        If connection.State <> ConnectionState.Closed Then _
    '           connection.Close()
    '    End Try

    '    Dim pages As Integer = System.Math.Floor((items / 5) + 1)
    '    Dim workbook As New XLWorkbook(AppDomain.CurrentDomain.BaseDirectory.Replace("\bin\Debug", "") & "reports\EquipmentTemplate.xlsx")
    '    Dim worksheet As IXLWorksheet
    '    Dim template As IXLWorksheet = workbook.Worksheet("Sheet1")

    '    worksheet.Cell("K2").Value = pages.ToString()

    '    Dim i As Integer = 1
    '    For x As Integer = 1 To pages
    '        If x <> 1 Then

    '            template.CopyTo(workbook, "Sheet" & x)
    '            worksheet = workbook.Worksheet("Sheet" & x)
    '            worksheet.Cell("I2").Value = x.ToString()
    '        Else
    '            worksheet = workbook.Worksheet("Sheet1")
    '            worksheet.Cell("I2").Value = x.ToString()
    '            worksheet.Cell("D2").Value = Now.ToShortDateString()

    '            'If rbResale.Checked Then worksheet.Cell("L7").Value = "X"
    '            'If rbTaxable.Checked Then worksheet.Cell("L8").Value = "X"
    '            'If rbTaxExempt.Checked Then worksheet.Cell("L9").Value = "X"

    '            worksheet.Cell("F3").Value = releaseNum.ToString()
    '            worksheet.Cell("F4").Value = name 'repName
    '            worksheet.Cell("F5").Value = repCompanyID 'txtTaxNumber.Text
    '            worksheet.Cell("F6").Value = poNumber
    '            worksheet.Cell("F7").Value = poDate
    '            worksheet.Cell("B4").Value = invoiceLine1
    '            worksheet.Cell("B5").Value = invoiceLine2
    '            worksheet.Cell("B6").Value = invoiceCity & ", " & invoiceState
    '            worksheet.Cell("B7").Value = invoiceZip
    '            worksheet.Cell("B42").Value = shipLine1
    '            worksheet.Cell("B43").Value = shipLine2
    '            worksheet.Cell("B44").Value = shipCity & ", " & shipState
    '            worksheet.Cell("B45").Value = shipZip
    '            worksheet.Cell("E48").Value = AppInfo.User.username.ToString()

    '        End If

    '        If i + 5 > items Then
    '            Dim difference As Integer = items - (i - 1)

    '            If difference = 0 Then
    '                worksheet.Cell("D12").Value = "-"
    '                worksheet.Cell("E12").Value = "-"
    '                worksheet.Cell("F12").Value = "-"
    '                worksheet.Cell("G12").Value = "-"
    '                worksheet.Cell("H12").Value = "-"
    '                worksheet.Cell("J12").Value = "TOTAL"
    '                Exit For
    '            End If

    '            If difference = 1 Then
    '                worksheet.Cell("D12").Value = i.ToString()
    '                i += 1
    '                worksheet.Cell("E12").Value = "-"
    '                i += 1
    '                worksheet.Cell("F12").Value = "-"
    '                i += 1
    '                worksheet.Cell("G12").Value = "-"
    '                i += 1
    '                worksheet.Cell("H12").Value = "-"
    '                worksheet.Cell("J12").Value = "TOTAL"
    '            End If

    '            If difference = 2 Then
    '                worksheet.Cell("D12").Value = i.ToString()
    '                i += 1
    '                worksheet.Cell("E12").Value = i.ToString()
    '                i += 1
    '                worksheet.Cell("F12").Value = "-"
    '                i += 1
    '                worksheet.Cell("G12").Value = "-"
    '                i += 1
    '                worksheet.Cell("H12").Value = "-"
    '                worksheet.Cell("J12").Value = "TOTAL"
    '            End If

    '            If difference = 3 Then
    '                worksheet.Cell("D12").Value = i.ToString()
    '                i += 1
    '                worksheet.Cell("E12").Value = i.ToString()
    '                i += 1
    '                worksheet.Cell("F12").Value = i.ToString()
    '                i += 1
    '                worksheet.Cell("G12").Value = "-"
    '                i += 1
    '                worksheet.Cell("H12").Value = "-"
    '                worksheet.Cell("J12").Value = "TOTAL"
    '            End If

    '            If difference = 4 Then
    '                worksheet.Cell("D12").Value = i.ToString()
    '                i += 1
    '                worksheet.Cell("E12").Value = i.ToString()
    '                i += 1
    '                worksheet.Cell("F12").Value = i.ToString()
    '                i += 1
    '                worksheet.Cell("G12").Value = i.ToString()
    '                i += 1
    '                worksheet.Cell("H12").Value = "-"
    '                worksheet.Cell("J12").Value = "TOTAL"
    '            End If

    '            If difference = 5 Then
    '                worksheet.Cell("D12").Value = i.ToString()
    '                i += 1
    '                worksheet.Cell("E12").Value = i.ToString()
    '                i += 1
    '                worksheet.Cell("F12").Value = i.ToString()
    '                i += 1
    '                worksheet.Cell("G12").Value = i.ToString()
    '                i += 1
    '                worksheet.Cell("H12").Value = i.ToString()
    '                worksheet.Cell("J12").Value = "TOTAL"
    '            End If
    '        Else
    '            worksheet.Cell("D12").Value = i.ToString()
    '            i += 1
    '            worksheet.Cell("E12").Value = i.ToString()
    '            i += 1
    '            worksheet.Cell("F12").Value = i.ToString()
    '            i += 1
    '            worksheet.Cell("G12").Value = i.ToString()
    '            i += 1
    '            worksheet.Cell("H12").Value = i.ToString()
    '            worksheet.Cell("J12").Value = "TOTAL"
    '        End If
    '    Next

    '    Dim saveAs As String = ""

    '    If String.IsNullOrEmpty(releaseNum) Then
    '        Dim rnd As New Random
    '        saveAs = "OrderEntry_" & Date.Today.ToString("MM-dd-yyyy") & "_" & rnd.Next(0, Integer.MaxValue).ToString()
    '    Else
    '        saveAs = "OrderEntry_" & releaseNum.ToString().Replace("\", "-").Replace("/", "-").Replace(Chr(34), "").Replace(":", "").Replace("&", "and").Trim()
    '    End If


    '    Dim filepath As String = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents") & "\Order Entry Forms\" & saveAs & ".xlsx"

    '    workbook.SaveAs(filepath)
    '    Dim p As Process = New Process()
    '    Dim psi As ProcessStartInfo = New ProcessStartInfo()
    '    psi.CreateNoWindow = True
    '    psi.Verb = "Open"
    '    psi.FileName = filepath
    '    p.StartInfo = psi
    '    p.Start()

    'End Sub

End Class
