Option Strict On
Option Explicit On

Imports C1.Win.C1TrueDBGrid
Imports C1.Win.C1TrueDBGrid.RowTypeEnum
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.Shared
Imports Rae.RaeSolutions.Business
Imports Rae.RaeSolutions.Business.Division
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.solutions
Imports Rae.solutions.drawings
Imports Rae.solutions.group
Imports Rae.RaeSolutions.DataAccess
Imports Rae.Reflection.MethodInvoker
Imports Rae.Ui
Imports Rae.Ui.Validation
Imports System.Data
Imports System.Environment
Imports System.Text
Imports System.Math
Imports System.Reflection
Imports System.Collections.Generic
Imports System.Linq
Imports System.ComponentModel

Imports OCol = Rae.RaeSolutions.DataAccess.Projects.Tables.OptionsObjectTable
Imports DCol = Rae.RaeSolutions.DataAccess.DependentCommonOptions.DependentCommmonOptionsColumnNames
Imports CommonEquipmentDa = Rae.RaeSolutions.DataAccess.Projects.CommonEquipmentDa
Imports EquipmentDataAccess = Rae.RaeSolutions.DataAccess.Projects.EquipmentDataAccess
Imports CNull = Rae.ConvertNull
Imports Intelligence = Rae.RaeSolutions.Business.Intelligence
Imports Forms = System.Windows.Forms
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports Rae.Security.IntegratedSecurity

''' <summary>Form for selecting and entering equipment information</summary>
Partial Class EquipmentForm
    Inherits System.Windows.Forms.Form

    Protected presenter As equipment_pricing_presenter_base

    Protected Overridable Function create_presenter() As equipment_pricing_presenter_base
        '  Throw New Exception("Presenter not implemented.")
    End Function

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        MyBase.Width = 1000
        'Add any initialization after the InitializeComponent() call
        loadEngineeringData = AddressOf loadEngineeringDataFor
        convertToProcess = AddressOf convertToProcessItem
        AddHandler Me.FormClosing, AddressOf onFormClosing

        presenter = create_presenter()
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
    Friend WithEvents tip As System.Windows.Forms.ToolTip
    Friend WithEvents orderReportErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents submittalReportErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents tabEquipment As System.Windows.Forms.TabControl
    Friend WithEvents tabModel As System.Windows.Forms.TabPage
    Friend WithEvents lblUnitVoltage As System.Windows.Forms.Label
    Friend WithEvents cboUnitVoltage As System.Windows.Forms.ComboBox
    Friend WithEvents lblSpecs As System.Windows.Forms.Label
    Friend WithEvents EquipmentSelector1 As Rae.RaeSolutions.EquipmentSelector
    Friend WithEvents tabAvailableOptions As System.Windows.Forms.TabPage
    Friend WithEvents availableOptionsPanel As System.Windows.Forms.Panel
    Friend WithEvents lblNoOptions As System.Windows.Forms.Label
    Friend WithEvents availableOpGrid As Rae.RaeSolutions.AvailableOptionGrid
    Friend WithEvents infoAvailableOpLabel As System.Windows.Forms.Label
    Friend WithEvents tabOptionsSummary As System.Windows.Forms.TabPage
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents panOptionsSummary As System.Windows.Forms.Panel
    Friend WithEvents selectedAvailableOptionsLabel As System.Windows.Forms.Label
    Friend WithEvents selectedAvailableLabel As System.Windows.Forms.Label
    Friend WithEvents selectedOpGrid As SelectedOptionGrid
    Friend WithEvents selectedAvailableOptionsPriceLabel As System.Windows.Forms.Label
    Friend WithEvents panSelectedOptions As System.Windows.Forms.Panel
    Friend WithEvents standardOpGrid As StandardOptionGrid
    Friend WithEvents tabPricing As System.Windows.Forms.TabPage
    Friend WithEvents txtOtherDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblOtherDescription As System.Windows.Forms.Label
    Friend WithEvents lblNfsp As System.Windows.Forms.Label
    Friend WithEvents lblCommissionPrice As System.Windows.Forms.Label
    Friend WithEvents lblParPrice As System.Windows.Forms.Label
    Friend WithEvents lblCommissionRate As System.Windows.Forms.Label
    Friend WithEvents cboParMultiplier As System.Windows.Forms.ComboBox
    Friend WithEvents totalInvoiceLabel As System.Windows.Forms.Label
    Friend WithEvents lblCommissionPriceLabel As System.Windows.Forms.Label
    Friend WithEvents lblCommissionRateLabel As System.Windows.Forms.Label
    Friend WithEvents lblPricingParPrice As System.Windows.Forms.Label
    Friend WithEvents lblPricingParMultiplier As System.Windows.Forms.Label
    Friend WithEvents txtOther As System.Windows.Forms.TextBox
    Friend WithEvents lblOther As System.Windows.Forms.Label
    Friend WithEvents txtFreight As System.Windows.Forms.TextBox
    Friend WithEvents lblFreight As System.Windows.Forms.Label
    Friend WithEvents txtStartUp As System.Windows.Forms.TextBox
    Friend WithEvents lblStartUp As System.Windows.Forms.Label
    Friend WithEvents txtFourYearCompressorWarranty As System.Windows.Forms.TextBox
    Friend WithEvents lblSummaryTotalListPrice As System.Windows.Forms.Label
    Friend WithEvents totalAvailableOptionsPriceLabel As System.Windows.Forms.Label
    Friend WithEvents lblSummaryBaseListPrice As System.Windows.Forms.Label
    Friend WithEvents lblPricingTotalList As System.Windows.Forms.Label
    Friend WithEvents totalAvailableOptionsLabel As System.Windows.Forms.Label
    Friend WithEvents lblPricingBaseList As System.Windows.Forms.Label
    Friend WithEvents pricingPanel As System.Windows.Forms.Panel
    Friend WithEvents lblTotalBaseListPrice As System.Windows.Forms.Label
    Friend WithEvents lblTotalBaseListPriceLabel As System.Windows.Forms.Label
    Friend WithEvents txtUnitQuantity As System.Windows.Forms.TextBox
    Friend WithEvents lblUnitQuantity As System.Windows.Forms.Label
    Friend WithEvents lblBaseListPrice As System.Windows.Forms.Label
    Friend WithEvents lblBaseListPriceLabel As System.Windows.Forms.Label
    Friend WithEvents tabSpecialOptions As System.Windows.Forms.TabPage
    Friend WithEvents SpecialOptionsControl1 As Rae.RaeSolutions.SpecialOptionsControl
    Friend WithEvents infoSpecialOpLabel As System.Windows.Forms.Label
    Friend WithEvents totalSpecialOptionsPriceLabel As System.Windows.Forms.Label
    Friend WithEvents totalSpecialOptionsLabel As System.Windows.Forms.Label
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents panSpecialOptionsSummary As System.Windows.Forms.Panel
    Friend WithEvents lblSpecialOptionsSummaryTotalPriceLabel As System.Windows.Forms.Label
    Friend WithEvents lblSpecialOptionsSummaryLabel As System.Windows.Forms.Label
    Friend WithEvents lblSpecialOptionsSummaryTotalPrice As System.Windows.Forms.Label
    Friend WithEvents specialOpGrid As SpecialOptionGrid
    Friend WithEvents specsHeaderPanel As System.Windows.Forms.Panel
    Friend WithEvents equipmentMenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuReports As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSubmittal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents equipmentErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents mnuConvert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSaveAs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSaveAsRevision As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents aboveSaveSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents belowSaveSeparator As System.Windows.Forms.ToolStripSeparator
    Private WithEvents totalSelectedOptionsQuantityLabel As System.Windows.Forms.Label
    Private WithEvents totalSpecialOptionsQuantityLabel As System.Windows.Forms.Label
    Private WithEvents totalBaseListPriceQuantityLabel As System.Windows.Forms.Label
    Friend WithEvents SaveToolStripPanel1 As Rae.RaeSolutions.SaveToolStripPanel
    Friend WithEvents mnuDrawings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUnitDrawing As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRefrigerantPiping As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkFourYearCompressorWarranty As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents barReports As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents barSubmittal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents barDrawings As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents barUnitDrawings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents barConvert As System.Windows.Forms.ToolStripButton
    Friend WithEvents overrideBaseListText As System.Windows.Forms.TextBox
    Friend WithEvents overrideBaseListCheck As System.Windows.Forms.CheckBox
    Friend WithEvents overrideBaseListLabel As System.Windows.Forms.Label
    Friend WithEvents totalCommonOptionsLabel As System.Windows.Forms.Label
    Friend WithEvents totalCommonOptionsPriceLabel As System.Windows.Forms.Label
    Friend WithEvents selectedCommonOptionsLabel As System.Windows.Forms.Label
    Friend WithEvents selectedCommonOptionsPriceLabel As System.Windows.Forms.Label
    Friend WithEvents pnlCoil As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblNumCoils As System.Windows.Forms.Label
    Friend WithEvents lblCoilListPrice As System.Windows.Forms.Label
    Friend WithEvents lblCoilPriceEach As System.Windows.Forms.Label
    Friend WithEvents multiplierCodeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents multiplierCodeLabel As System.Windows.Forms.Label
    Friend WithEvents applyMultiplierCodeButton As System.Windows.Forms.Button
    Friend WithEvents discontinueMultiplierCodeButton As System.Windows.Forms.Button
    Friend WithEvents barRefrigerantPiping As System.Windows.Forms.ToolStripMenuItem
    ''Friend WithEvents multiplierCodeAppliedPicture As Rae.Ui.Controls.TransparentPictureBox
    Friend WithEvents optionToolbarPanel As System.Windows.Forms.Panel
    Friend WithEvents infoReviewLabel As System.Windows.Forms.Label
    ''Friend WithEvents groupLink As Rae.Ui.Controls.ToggleLink
    ''Friend WithEvents unselectLink As Rae.Ui.Controls.Link
    Friend WithEvents infoSpecialOpParenLabel As System.Windows.Forms.Label
    Friend WithEvents modelPanel As System.Windows.Forms.Panel
    Friend WithEvents txtCustomModel As System.Windows.Forms.TextBox
    Friend WithEvents lblModelNumber As System.Windows.Forms.Label
    Friend WithEvents infoModelParenLabel As System.Windows.Forms.Label
    Friend WithEvents infoModelLabel As System.Windows.Forms.Label
    Friend WithEvents barFluidPiping As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFluidPiping As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_equipment_proposal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bar_equipment_proposal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblAvailableGrid As System.Windows.Forms.Label
    Friend WithEvents txtOverrideBaseListPerUnit As System.Windows.Forms.TextBox
    Friend WithEvents barUnitDrawingsOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents barUnitDrawingsSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents barRefrigerantPipingOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents barRefrigerantPipingSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents barFluidPipingOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents barFluidPipingSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents ddCentury As System.Windows.Forms.ComboBox
    Friend WithEvents selectedOpsDs As Rae.RaeSolutions.SelectedOptionsDataSet
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EquipmentForm))
        Me.tip = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblUnitVoltage = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkFourYearCompressorWarranty = New System.Windows.Forms.CheckBox()
        Me.txtFourYearCompressorWarranty = New System.Windows.Forms.TextBox()
        Me.selectedOpsDs = New Rae.RaeSolutions.SelectedOptionsDataSet()
        Me.orderReportErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.submittalReportErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tabPricing = New System.Windows.Forms.TabPage()
        Me.ddCentury = New System.Windows.Forms.ComboBox()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblAvailableGrid = New System.Windows.Forms.Label()
        Me.txtOverrideBaseListPerUnit = New System.Windows.Forms.TextBox()
        ''Me.multiplierCodeAppliedPicture = New Rae.Ui.Controls.TransparentPictureBox()
        Me.discontinueMultiplierCodeButton = New System.Windows.Forms.Button()
        Me.applyMultiplierCodeButton = New System.Windows.Forms.Button()
        Me.multiplierCodeTextBox = New System.Windows.Forms.TextBox()
        Me.multiplierCodeLabel = New System.Windows.Forms.Label()
        Me.pnlCoil = New System.Windows.Forms.Panel()
        Me.lblCoilPriceEach = New System.Windows.Forms.Label()
        Me.lblCoilListPrice = New System.Windows.Forms.Label()
        Me.lblNumCoils = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.totalCommonOptionsPriceLabel = New System.Windows.Forms.Label()
        Me.totalCommonOptionsLabel = New System.Windows.Forms.Label()
        Me.overrideBaseListText = New System.Windows.Forms.TextBox()
        Me.overrideBaseListLabel = New System.Windows.Forms.Label()
        Me.overrideBaseListCheck = New System.Windows.Forms.CheckBox()
        Me.totalSelectedOptionsQuantityLabel = New System.Windows.Forms.Label()
        Me.totalSpecialOptionsQuantityLabel = New System.Windows.Forms.Label()
        Me.totalBaseListPriceQuantityLabel = New System.Windows.Forms.Label()
        Me.totalSpecialOptionsPriceLabel = New System.Windows.Forms.Label()
        Me.totalSpecialOptionsLabel = New System.Windows.Forms.Label()
        Me.txtOtherDescription = New System.Windows.Forms.TextBox()
        Me.lblOtherDescription = New System.Windows.Forms.Label()
        Me.lblNfsp = New System.Windows.Forms.Label()
        Me.lblCommissionPrice = New System.Windows.Forms.Label()
        Me.lblParPrice = New System.Windows.Forms.Label()
        Me.lblCommissionRate = New System.Windows.Forms.Label()
        Me.cboParMultiplier = New System.Windows.Forms.ComboBox()
        Me.totalInvoiceLabel = New System.Windows.Forms.Label()
        Me.lblCommissionPriceLabel = New System.Windows.Forms.Label()
        Me.lblCommissionRateLabel = New System.Windows.Forms.Label()
        Me.lblPricingParPrice = New System.Windows.Forms.Label()
        Me.lblPricingParMultiplier = New System.Windows.Forms.Label()
        Me.txtOther = New System.Windows.Forms.TextBox()
        Me.lblOther = New System.Windows.Forms.Label()
        Me.txtFreight = New System.Windows.Forms.TextBox()
        Me.lblFreight = New System.Windows.Forms.Label()
        Me.txtStartUp = New System.Windows.Forms.TextBox()
        Me.lblStartUp = New System.Windows.Forms.Label()
        Me.lblSummaryTotalListPrice = New System.Windows.Forms.Label()
        Me.totalAvailableOptionsPriceLabel = New System.Windows.Forms.Label()
        Me.lblSummaryBaseListPrice = New System.Windows.Forms.Label()
        Me.lblPricingTotalList = New System.Windows.Forms.Label()
        Me.totalAvailableOptionsLabel = New System.Windows.Forms.Label()
        Me.lblPricingBaseList = New System.Windows.Forms.Label()
        Me.tabOptionsSummary = New System.Windows.Forms.TabPage()
        Me.panOptionsSummary = New System.Windows.Forms.Panel()
        Me.selectedCommonOptionsPriceLabel = New System.Windows.Forms.Label()
        Me.selectedCommonOptionsLabel = New System.Windows.Forms.Label()
        Me.selectedAvailableOptionsLabel = New System.Windows.Forms.Label()
        Me.selectedAvailableLabel = New System.Windows.Forms.Label()
        Me.selectedOpGrid = New Rae.RaeSolutions.SelectedOptionGrid()
        Me.selectedAvailableOptionsPriceLabel = New System.Windows.Forms.Label()
        Me.Splitter2 = New System.Windows.Forms.Splitter()
        Me.panSpecialOptionsSummary = New System.Windows.Forms.Panel()
        ''Me.specialOpGrid = New Rae.RaeSolutions.SpecialOptionGrid()
        Me.specialOpGrid = New Rae.RaeSolutions.SpecialOptionGrid()
        Me.lblSpecialOptionsSummaryTotalPriceLabel = New System.Windows.Forms.Label()
        Me.lblSpecialOptionsSummaryLabel = New System.Windows.Forms.Label()
        Me.lblSpecialOptionsSummaryTotalPrice = New System.Windows.Forms.Label()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.panSelectedOptions = New System.Windows.Forms.Panel()
        Me.infoReviewLabel = New System.Windows.Forms.Label()
        Me.standardOpGrid = New Rae.RaeSolutions.StandardOptionGrid()
        Me.tabAvailableOptions = New System.Windows.Forms.TabPage()
        Me.availableOptionsPanel = New System.Windows.Forms.Panel()
        Me.lblNoOptions = New System.Windows.Forms.Label()
        Me.optionToolbarPanel = New System.Windows.Forms.Panel()
        ''Me.unselectLink = New Rae.Ui.Controls.Link()
        ''Me.groupLink = New Rae.Ui.Controls.ToggleLink()
        Me.availableOpGrid = New Rae.RaeSolutions.AvailableOptionGrid()
        Me.infoAvailableOpLabel = New System.Windows.Forms.Label()
        Me.tabModel = New System.Windows.Forms.TabPage()
        Me.specsHeaderPanel = New System.Windows.Forms.Panel()
        Me.lblSpecs = New System.Windows.Forms.Label()
        Me.pricingPanel = New System.Windows.Forms.Panel()
        Me.lblTotalBaseListPrice = New System.Windows.Forms.Label()
        Me.lblTotalBaseListPriceLabel = New System.Windows.Forms.Label()
        Me.txtUnitQuantity = New System.Windows.Forms.TextBox()
        Me.lblUnitQuantity = New System.Windows.Forms.Label()
        Me.lblBaseListPrice = New System.Windows.Forms.Label()
        Me.lblBaseListPriceLabel = New System.Windows.Forms.Label()
        Me.modelPanel = New System.Windows.Forms.Panel()
        Me.infoModelParenLabel = New System.Windows.Forms.Label()
        Me.infoModelLabel = New System.Windows.Forms.Label()
        Me.txtCustomModel = New System.Windows.Forms.TextBox()
        Me.lblModelNumber = New System.Windows.Forms.Label()
        Me.cboUnitVoltage = New System.Windows.Forms.ComboBox()
        Me.EquipmentSelector1 = New Rae.RaeSolutions.EquipmentSelector()
        Me.tabEquipment = New System.Windows.Forms.TabControl()
        Me.tabSpecialOptions = New System.Windows.Forms.TabPage()
        Me.infoSpecialOpParenLabel = New System.Windows.Forms.Label()
        Me.infoSpecialOpLabel = New System.Windows.Forms.Label()
        Me.SpecialOptionsControl1 = New Rae.RaeSolutions.SpecialOptionsControl()
        Me.equipmentMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.aboveSaveSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSaveAsRevision = New System.Windows.Forms.ToolStripMenuItem()
        Me.belowSaveSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuConvert = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuReports = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSubmittal = New System.Windows.Forms.ToolStripMenuItem()
        Me.bar_equipment_proposal = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDrawings = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUnitDrawing = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRefrigerantPiping = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFluidPiping = New System.Windows.Forms.ToolStripMenuItem()
        Me.equipmentErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.barReports = New System.Windows.Forms.ToolStripSplitButton()
        Me.barSubmittal = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_equipment_proposal = New System.Windows.Forms.ToolStripMenuItem()
        Me.barDrawings = New System.Windows.Forms.ToolStripSplitButton()
        Me.barUnitDrawings = New System.Windows.Forms.ToolStripMenuItem()
        Me.barUnitDrawingsOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.barUnitDrawingsSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.barRefrigerantPiping = New System.Windows.Forms.ToolStripMenuItem()
        Me.barRefrigerantPipingOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.barRefrigerantPipingSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.barFluidPiping = New System.Windows.Forms.ToolStripMenuItem()
        Me.barFluidPipingOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.barFluidPipingSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.barConvert = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripPanel1 = New Rae.RaeSolutions.SaveToolStripPanel()
        CType(Me.selectedOpsDs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.orderReportErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.submittalReportErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPricing.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        ''CType(Me.multiplierCodeAppliedPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCoil.SuspendLayout()
        Me.tabOptionsSummary.SuspendLayout()
        Me.panOptionsSummary.SuspendLayout()
        CType(Me.selectedOpGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panSpecialOptionsSummary.SuspendLayout()
        CType(Me.specialOpGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panSelectedOptions.SuspendLayout()
        CType(Me.standardOpGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAvailableOptions.SuspendLayout()
        Me.availableOptionsPanel.SuspendLayout()
        Me.optionToolbarPanel.SuspendLayout()
        CType(Me.availableOpGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabModel.SuspendLayout()
        Me.specsHeaderPanel.SuspendLayout()
        Me.pricingPanel.SuspendLayout()
        Me.modelPanel.SuspendLayout()
        Me.tabEquipment.SuspendLayout()
        Me.tabSpecialOptions.SuspendLayout()
        Me.equipmentMenuStrip.SuspendLayout()
        CType(Me.equipmentErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblUnitVoltage
        '
        Me.lblUnitVoltage.BackColor = System.Drawing.Color.Transparent
        Me.lblUnitVoltage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.lblUnitVoltage.Location = New System.Drawing.Point(332, 55)
        Me.lblUnitVoltage.Name = "lblUnitVoltage"
        Me.lblUnitVoltage.Size = New System.Drawing.Size(72, 24)
        Me.lblUnitVoltage.TabIndex = 27
        Me.lblUnitVoltage.Text = "Unit voltage"
        Me.lblUnitVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tip.SetToolTip(Me.lblUnitVoltage, "Unit voltage")
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Info
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.Location = New System.Drawing.Point(329, 264)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(207, 27)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "(Total 5 year compressor warranty.)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tip.SetToolTip(Me.Label1, resources.GetString("Label1.ToolTip"))
        '
        'chkFourYearCompressorWarranty
        '
        Me.chkFourYearCompressorWarranty.BackColor = System.Drawing.Color.Transparent
        Me.chkFourYearCompressorWarranty.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFourYearCompressorWarranty.Location = New System.Drawing.Point(19, 271)
        Me.chkFourYearCompressorWarranty.Name = "chkFourYearCompressorWarranty"
        Me.chkFourYearCompressorWarranty.Size = New System.Drawing.Size(218, 18)
        Me.chkFourYearCompressorWarranty.TabIndex = 45
        Me.chkFourYearCompressorWarranty.Text = "Add 4 year compressor warranty (net)"
        Me.tip.SetToolTip(Me.chkFourYearCompressorWarranty, resources.GetString("chkFourYearCompressorWarranty.ToolTip"))
        Me.chkFourYearCompressorWarranty.UseVisualStyleBackColor = False
        '
        'txtFourYearCompressorWarranty
        '
        Me.txtFourYearCompressorWarranty.Enabled = False
        Me.txtFourYearCompressorWarranty.Location = New System.Drawing.Point(243, 268)
        Me.txtFourYearCompressorWarranty.Name = "txtFourYearCompressorWarranty"
        Me.txtFourYearCompressorWarranty.Size = New System.Drawing.Size(80, 21)
        Me.txtFourYearCompressorWarranty.TabIndex = 10
        Me.txtFourYearCompressorWarranty.Text = "$0"
        Me.tip.SetToolTip(Me.txtFourYearCompressorWarranty, resources.GetString("txtFourYearCompressorWarranty.ToolTip"))
        '
        'selectedOpsDs
        '
        Me.selectedOpsDs.DataSetName = "SelectedOptionsDataSet"
        Me.selectedOpsDs.Locale = New System.Globalization.CultureInfo("en-US")
        Me.selectedOpsDs.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'orderReportErrorProvider
        '
        Me.orderReportErrorProvider.ContainerControl = Me
        Me.orderReportErrorProvider.Icon = CType(resources.GetObject("orderReportErrorProvider.Icon"), System.Drawing.Icon)
        '
        'submittalReportErrorProvider
        '
        Me.submittalReportErrorProvider.ContainerControl = Me
        Me.submittalReportErrorProvider.Icon = CType(resources.GetObject("submittalReportErrorProvider.Icon"), System.Drawing.Icon)
        '
        'tabPricing
        '
        Me.tabPricing.BackColor = System.Drawing.Color.White
        Me.tabPricing.Controls.Add(Me.ddCentury)
        Me.tabPricing.Controls.Add(Me.NumericUpDown1)
        Me.tabPricing.Controls.Add(Me.Label6)
        Me.tabPricing.Controls.Add(Me.Label3)
        Me.tabPricing.Controls.Add(Me.Label2)
        Me.tabPricing.Controls.Add(Me.txtOverrideBaseListPerUnit)
        ''Me.tabPricing.Controls.Add(Me.multiplierCodeAppliedPicture)
        Me.tabPricing.Controls.Add(Me.discontinueMultiplierCodeButton)
        Me.tabPricing.Controls.Add(Me.applyMultiplierCodeButton)
        Me.tabPricing.Controls.Add(Me.multiplierCodeTextBox)
        Me.tabPricing.Controls.Add(Me.multiplierCodeLabel)
        Me.tabPricing.Controls.Add(Me.pnlCoil)
        Me.tabPricing.Controls.Add(Me.totalCommonOptionsPriceLabel)
        Me.tabPricing.Controls.Add(Me.totalCommonOptionsLabel)
        Me.tabPricing.Controls.Add(Me.overrideBaseListText)
        Me.tabPricing.Controls.Add(Me.overrideBaseListLabel)
        Me.tabPricing.Controls.Add(Me.overrideBaseListCheck)
        Me.tabPricing.Controls.Add(Me.Label1)
        Me.tabPricing.Controls.Add(Me.chkFourYearCompressorWarranty)
        Me.tabPricing.Controls.Add(Me.totalSelectedOptionsQuantityLabel)
        Me.tabPricing.Controls.Add(Me.totalSpecialOptionsQuantityLabel)
        Me.tabPricing.Controls.Add(Me.totalBaseListPriceQuantityLabel)
        Me.tabPricing.Controls.Add(Me.totalSpecialOptionsPriceLabel)
        Me.tabPricing.Controls.Add(Me.totalSpecialOptionsLabel)
        Me.tabPricing.Controls.Add(Me.txtOtherDescription)
        Me.tabPricing.Controls.Add(Me.lblOtherDescription)
        Me.tabPricing.Controls.Add(Me.lblNfsp)
        Me.tabPricing.Controls.Add(Me.lblCommissionPrice)
        Me.tabPricing.Controls.Add(Me.lblParPrice)
        Me.tabPricing.Controls.Add(Me.lblCommissionRate)
        Me.tabPricing.Controls.Add(Me.cboParMultiplier)
        Me.tabPricing.Controls.Add(Me.totalInvoiceLabel)
        Me.tabPricing.Controls.Add(Me.lblCommissionPriceLabel)
        Me.tabPricing.Controls.Add(Me.lblCommissionRateLabel)
        Me.tabPricing.Controls.Add(Me.lblPricingParPrice)
        Me.tabPricing.Controls.Add(Me.lblPricingParMultiplier)
        Me.tabPricing.Controls.Add(Me.txtOther)
        Me.tabPricing.Controls.Add(Me.lblOther)
        Me.tabPricing.Controls.Add(Me.txtFreight)
        Me.tabPricing.Controls.Add(Me.lblFreight)
        Me.tabPricing.Controls.Add(Me.txtStartUp)
        Me.tabPricing.Controls.Add(Me.lblStartUp)
        Me.tabPricing.Controls.Add(Me.txtFourYearCompressorWarranty)
        Me.tabPricing.Controls.Add(Me.lblSummaryTotalListPrice)
        Me.tabPricing.Controls.Add(Me.totalAvailableOptionsPriceLabel)
        Me.tabPricing.Controls.Add(Me.lblSummaryBaseListPrice)
        Me.tabPricing.Controls.Add(Me.lblPricingTotalList)
        Me.tabPricing.Controls.Add(Me.totalAvailableOptionsLabel)
        Me.tabPricing.Controls.Add(Me.lblPricingBaseList)
        Me.tabPricing.Location = New System.Drawing.Point(4, 22)
        Me.tabPricing.Name = "tabPricing"
        Me.tabPricing.Size = New System.Drawing.Size(663, 504)
        Me.tabPricing.TabIndex = 2
        Me.tabPricing.Text = "Pricing"
        Me.tabPricing.UseVisualStyleBackColor = True
        '
        'ddCentury
        '
        Me.ddCentury.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddCentury.Items.AddRange(New Object() {"Century", "Resco"})
        Me.ddCentury.Location = New System.Drawing.Point(349, 216)
        Me.ddCentury.Name = "ddCentury"
        Me.ddCentury.Size = New System.Drawing.Size(92, 21)
        Me.ddCentury.TabIndex = 65
        Me.ddCentury.Visible = False
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.DecimalPlaces = 4
        Me.NumericUpDown1.Increment = New Decimal(New Integer() {1, 0, 0, 262144})
        Me.NumericUpDown1.Location = New System.Drawing.Point(223, 217)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {10, 0, 0, 65536})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {2810, 0, 0, 262144})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(120, 21)
        Me.NumericUpDown1.TabIndex = 64
        Me.NumericUpDown1.Value = New Decimal(New Integer() {290, 0, 0, 196608})
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(19, 459)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(511, 36)
        Me.Label6.TabIndex = 63
        Me.Label6.Text = "** Note: All pricing is in U.S. dollars.  Pricing does not include any applicable" & _
            " taxes, import / export fees, or tariffs."
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(324, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 21)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "Total (incl Qty):"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(151, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 21)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Per Unit:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAvailableGrid
        '
        Me.lblAvailableGrid.BackColor = System.Drawing.Color.Transparent
        Me.lblAvailableGrid.Location = New System.Drawing.Point(400, 14)
        Me.lblAvailableGrid.Name = "lblAvailableGrid"
        Me.lblAvailableGrid.Size = New System.Drawing.Size(90, 21)
        Me.lblAvailableGrid.TabIndex = 61
        Me.lblAvailableGrid.Text = "Available Options"
        Me.lblAvailableGrid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOverrideBaseListPerUnit
        '
        Me.txtOverrideBaseListPerUnit.Location = New System.Drawing.Point(202, 69)
        Me.txtOverrideBaseListPerUnit.Name = "txtOverrideBaseListPerUnit"
        Me.txtOverrideBaseListPerUnit.ReadOnly = True
        Me.txtOverrideBaseListPerUnit.Size = New System.Drawing.Size(83, 21)
        Me.txtOverrideBaseListPerUnit.TabIndex = 60
        Me.txtOverrideBaseListPerUnit.Text = "$0"
        '''
        '''multiplierCodeAppliedPicture
        '''
        ''Me.multiplierCodeAppliedPicture.BackColor = System.Drawing.Color.Transparent
        ''Me.multiplierCodeAppliedPicture.Image = CType(resources.GetObject("multiplierCodeAppliedPicture.Image"), System.Drawing.Image)
        ''Me.multiplierCodeAppliedPicture.ImageList = Nothing
        ''Me.multiplierCodeAppliedPicture.ImageListIndex = 3
        ''Me.multiplierCodeAppliedPicture.Location = New System.Drawing.Point(202, 190)
        ''Me.multiplierCodeAppliedPicture.Name = "multiplierCodeAppliedPicture"
        ''Me.multiplierCodeAppliedPicture.Size = New System.Drawing.Size(21, 21)
        ''Me.multiplierCodeAppliedPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        ''Me.multiplierCodeAppliedPicture.TabIndex = 59
        ''Me.multiplierCodeAppliedPicture.TabStop = False
        ''Me.multiplierCodeAppliedPicture.TransparentColor = System.Drawing.Color.Fuchsia
        ''Me.multiplierCodeAppliedPicture.Visible = False
        '
        'discontinueMultiplierCodeButton
        '
        Me.discontinueMultiplierCodeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.discontinueMultiplierCodeButton.Location = New System.Drawing.Point(448, 188)
        Me.discontinueMultiplierCodeButton.Name = "discontinueMultiplierCodeButton"
        Me.discontinueMultiplierCodeButton.Size = New System.Drawing.Size(82, 23)
        Me.discontinueMultiplierCodeButton.TabIndex = 58
        Me.discontinueMultiplierCodeButton.Text = "Discontinue"
        Me.discontinueMultiplierCodeButton.UseVisualStyleBackColor = True
        Me.discontinueMultiplierCodeButton.Visible = False
        '
        'applyMultiplierCodeButton
        '
        Me.applyMultiplierCodeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.applyMultiplierCodeButton.Location = New System.Drawing.Point(448, 188)
        Me.applyMultiplierCodeButton.Name = "applyMultiplierCodeButton"
        Me.applyMultiplierCodeButton.Size = New System.Drawing.Size(82, 23)
        Me.applyMultiplierCodeButton.TabIndex = 56
        Me.applyMultiplierCodeButton.Text = "Apply"
        Me.applyMultiplierCodeButton.UseVisualStyleBackColor = True
        '
        'multiplierCodeTextBox
        '
        Me.multiplierCodeTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.multiplierCodeTextBox.Location = New System.Drawing.Point(223, 190)
        Me.multiplierCodeTextBox.Name = "multiplierCodeTextBox"
        Me.multiplierCodeTextBox.Size = New System.Drawing.Size(219, 21)
        Me.multiplierCodeTextBox.TabIndex = 54
        '
        'multiplierCodeLabel
        '
        Me.multiplierCodeLabel.BackColor = System.Drawing.Color.Transparent
        Me.multiplierCodeLabel.Location = New System.Drawing.Point(19, 190)
        Me.multiplierCodeLabel.Name = "multiplierCodeLabel"
        Me.multiplierCodeLabel.Size = New System.Drawing.Size(168, 23)
        Me.multiplierCodeLabel.TabIndex = 55
        Me.multiplierCodeLabel.Text = "Custom multiplier code"
        Me.multiplierCodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlCoil
        '
        Me.pnlCoil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCoil.Controls.Add(Me.lblCoilPriceEach)
        Me.pnlCoil.Controls.Add(Me.lblCoilListPrice)
        Me.pnlCoil.Controls.Add(Me.lblNumCoils)
        Me.pnlCoil.Controls.Add(Me.Label5)
        Me.pnlCoil.Controls.Add(Me.Label4)
        Me.pnlCoil.Location = New System.Drawing.Point(20, 37)
        Me.pnlCoil.Name = "pnlCoil"
        Me.pnlCoil.Size = New System.Drawing.Size(451, 28)
        Me.pnlCoil.TabIndex = 53
        Me.pnlCoil.Visible = False
        '
        'lblCoilPriceEach
        '
        Me.lblCoilPriceEach.BackColor = System.Drawing.Color.Transparent
        Me.lblCoilPriceEach.ForeColor = System.Drawing.Color.Blue
        Me.lblCoilPriceEach.Location = New System.Drawing.Point(303, 1)
        Me.lblCoilPriceEach.Name = "lblCoilPriceEach"
        Me.lblCoilPriceEach.Size = New System.Drawing.Size(136, 23)
        Me.lblCoilPriceEach.TabIndex = 13
        Me.lblCoilPriceEach.Text = "($0 each)"
        Me.lblCoilPriceEach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCoilPriceEach.Visible = False
        '
        'lblCoilListPrice
        '
        Me.lblCoilListPrice.BackColor = System.Drawing.Color.Transparent
        Me.lblCoilListPrice.ForeColor = System.Drawing.Color.Blue
        Me.lblCoilListPrice.Location = New System.Drawing.Point(199, 1)
        Me.lblCoilListPrice.Name = "lblCoilListPrice"
        Me.lblCoilListPrice.Size = New System.Drawing.Size(97, 23)
        Me.lblCoilListPrice.TabIndex = 12
        Me.lblCoilListPrice.Text = "$0"
        Me.lblCoilListPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNumCoils
        '
        Me.lblNumCoils.Location = New System.Drawing.Point(130, 6)
        Me.lblNumCoils.Margin = New System.Windows.Forms.Padding(0)
        Me.lblNumCoils.Name = "lblNumCoils"
        Me.lblNumCoils.Size = New System.Drawing.Size(10, 13)
        Me.lblNumCoils.TabIndex = 2
        Me.lblNumCoils.Text = "2"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(124, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "(    per unit )"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(40, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Coil Price"
        '
        'totalCommonOptionsPriceLabel
        '
        Me.totalCommonOptionsPriceLabel.BackColor = System.Drawing.Color.Transparent
        Me.totalCommonOptionsPriceLabel.ForeColor = System.Drawing.Color.Blue
        Me.totalCommonOptionsPriceLabel.Location = New System.Drawing.Point(220, 141)
        Me.totalCommonOptionsPriceLabel.Name = "totalCommonOptionsPriceLabel"
        Me.totalCommonOptionsPriceLabel.Size = New System.Drawing.Size(100, 23)
        Me.totalCommonOptionsPriceLabel.TabIndex = 52
        Me.totalCommonOptionsPriceLabel.Text = "$0"
        Me.totalCommonOptionsPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'totalCommonOptionsLabel
        '
        Me.totalCommonOptionsLabel.BackColor = System.Drawing.Color.Transparent
        Me.totalCommonOptionsLabel.Location = New System.Drawing.Point(19, 140)
        Me.totalCommonOptionsLabel.Name = "totalCommonOptionsLabel"
        Me.totalCommonOptionsLabel.Size = New System.Drawing.Size(168, 24)
        Me.totalCommonOptionsLabel.TabIndex = 50
        Me.totalCommonOptionsLabel.Text = "Total common options"
        Me.totalCommonOptionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'overrideBaseListText
        '
        Me.overrideBaseListText.Location = New System.Drawing.Point(415, 68)
        Me.overrideBaseListText.Name = "overrideBaseListText"
        Me.overrideBaseListText.ReadOnly = True
        Me.overrideBaseListText.Size = New System.Drawing.Size(100, 21)
        Me.overrideBaseListText.TabIndex = 47
        Me.overrideBaseListText.Text = "$0"
        '
        'overrideBaseListLabel
        '
        Me.overrideBaseListLabel.BackColor = System.Drawing.Color.Transparent
        Me.overrideBaseListLabel.Location = New System.Drawing.Point(48, 68)
        Me.overrideBaseListLabel.Name = "overrideBaseListLabel"
        Me.overrideBaseListLabel.Size = New System.Drawing.Size(95, 21)
        Me.overrideBaseListLabel.TabIndex = 49
        Me.overrideBaseListLabel.Text = "Override base list"
        Me.overrideBaseListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'overrideBaseListCheck
        '
        Me.overrideBaseListCheck.Location = New System.Drawing.Point(28, 69)
        Me.overrideBaseListCheck.Name = "overrideBaseListCheck"
        Me.overrideBaseListCheck.Size = New System.Drawing.Size(18, 21)
        Me.overrideBaseListCheck.TabIndex = 48
        Me.overrideBaseListCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.overrideBaseListCheck.UseVisualStyleBackColor = True
        '
        'totalSelectedOptionsQuantityLabel
        '
        Me.totalSelectedOptionsQuantityLabel.BackColor = System.Drawing.Color.Transparent
        Me.totalSelectedOptionsQuantityLabel.Location = New System.Drawing.Point(139, 116)
        Me.totalSelectedOptionsQuantityLabel.Name = "totalSelectedOptionsQuantityLabel"
        Me.totalSelectedOptionsQuantityLabel.Size = New System.Drawing.Size(48, 24)
        Me.totalSelectedOptionsQuantityLabel.TabIndex = 44
        Me.totalSelectedOptionsQuantityLabel.Text = "(Qty 1)"
        Me.totalSelectedOptionsQuantityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'totalSpecialOptionsQuantityLabel
        '
        Me.totalSpecialOptionsQuantityLabel.BackColor = System.Drawing.Color.Transparent
        Me.totalSpecialOptionsQuantityLabel.Location = New System.Drawing.Point(139, 91)
        Me.totalSpecialOptionsQuantityLabel.Name = "totalSpecialOptionsQuantityLabel"
        Me.totalSpecialOptionsQuantityLabel.Size = New System.Drawing.Size(48, 24)
        Me.totalSpecialOptionsQuantityLabel.TabIndex = 43
        Me.totalSpecialOptionsQuantityLabel.Text = "(Qty 1)"
        Me.totalSpecialOptionsQuantityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'totalBaseListPriceQuantityLabel
        '
        Me.totalBaseListPriceQuantityLabel.BackColor = System.Drawing.Color.Transparent
        Me.totalBaseListPriceQuantityLabel.Location = New System.Drawing.Point(139, 15)
        Me.totalBaseListPriceQuantityLabel.Name = "totalBaseListPriceQuantityLabel"
        Me.totalBaseListPriceQuantityLabel.Size = New System.Drawing.Size(48, 24)
        Me.totalBaseListPriceQuantityLabel.TabIndex = 42
        Me.totalBaseListPriceQuantityLabel.Text = "(Qty 1)"
        Me.totalBaseListPriceQuantityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'totalSpecialOptionsPriceLabel
        '
        Me.totalSpecialOptionsPriceLabel.BackColor = System.Drawing.Color.Transparent
        Me.totalSpecialOptionsPriceLabel.ForeColor = System.Drawing.Color.Blue
        Me.totalSpecialOptionsPriceLabel.Location = New System.Drawing.Point(220, 92)
        Me.totalSpecialOptionsPriceLabel.Name = "totalSpecialOptionsPriceLabel"
        Me.totalSpecialOptionsPriceLabel.Size = New System.Drawing.Size(100, 23)
        Me.totalSpecialOptionsPriceLabel.TabIndex = 41
        Me.totalSpecialOptionsPriceLabel.Text = "$0"
        Me.totalSpecialOptionsPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'totalSpecialOptionsLabel
        '
        Me.totalSpecialOptionsLabel.BackColor = System.Drawing.Color.Transparent
        Me.totalSpecialOptionsLabel.Location = New System.Drawing.Point(19, 92)
        Me.totalSpecialOptionsLabel.Name = "totalSpecialOptionsLabel"
        Me.totalSpecialOptionsLabel.Size = New System.Drawing.Size(168, 24)
        Me.totalSpecialOptionsLabel.TabIndex = 40
        Me.totalSpecialOptionsLabel.Text = "Total special options"
        Me.totalSpecialOptionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOtherDescription
        '
        Me.txtOtherDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOtherDescription.Location = New System.Drawing.Point(415, 348)
        Me.txtOtherDescription.Name = "txtOtherDescription"
        Me.txtOtherDescription.Size = New System.Drawing.Size(115, 21)
        Me.txtOtherDescription.TabIndex = 24
        Me.txtOtherDescription.Text = "<other description>"
        '
        'lblOtherDescription
        '
        Me.lblOtherDescription.BackColor = System.Drawing.Color.Transparent
        Me.lblOtherDescription.Location = New System.Drawing.Point(327, 348)
        Me.lblOtherDescription.Name = "lblOtherDescription"
        Me.lblOtherDescription.Size = New System.Drawing.Size(72, 23)
        Me.lblOtherDescription.TabIndex = 39
        Me.lblOtherDescription.Text = "Description"
        Me.lblOtherDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNfsp
        '
        Me.lblNfsp.BackColor = System.Drawing.Color.Transparent
        Me.lblNfsp.ForeColor = System.Drawing.Color.Blue
        Me.lblNfsp.Location = New System.Drawing.Point(220, 418)
        Me.lblNfsp.Name = "lblNfsp"
        Me.lblNfsp.Size = New System.Drawing.Size(96, 23)
        Me.lblNfsp.TabIndex = 38
        Me.lblNfsp.Text = "$0"
        Me.lblNfsp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCommissionPrice
        '
        Me.lblCommissionPrice.BackColor = System.Drawing.Color.Transparent
        Me.lblCommissionPrice.ForeColor = System.Drawing.Color.Blue
        Me.lblCommissionPrice.Location = New System.Drawing.Point(220, 395)
        Me.lblCommissionPrice.Name = "lblCommissionPrice"
        Me.lblCommissionPrice.Size = New System.Drawing.Size(96, 23)
        Me.lblCommissionPrice.TabIndex = 37
        Me.lblCommissionPrice.Text = "$0"
        Me.lblCommissionPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblParPrice
        '
        Me.lblParPrice.BackColor = System.Drawing.Color.Transparent
        Me.lblParPrice.ForeColor = System.Drawing.Color.Blue
        Me.lblParPrice.Location = New System.Drawing.Point(220, 241)
        Me.lblParPrice.Name = "lblParPrice"
        Me.lblParPrice.Size = New System.Drawing.Size(100, 23)
        Me.lblParPrice.TabIndex = 36
        Me.lblParPrice.Text = "$0"
        Me.lblParPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCommissionRate
        '
        Me.lblCommissionRate.BackColor = System.Drawing.Color.Transparent
        Me.lblCommissionRate.ForeColor = System.Drawing.Color.Blue
        Me.lblCommissionRate.Location = New System.Drawing.Point(220, 372)
        Me.lblCommissionRate.Name = "lblCommissionRate"
        Me.lblCommissionRate.Size = New System.Drawing.Size(96, 23)
        Me.lblCommissionRate.TabIndex = 35
        Me.lblCommissionRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboParMultiplier
        '
        Me.cboParMultiplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboParMultiplier.Location = New System.Drawing.Point(223, 217)
        Me.cboParMultiplier.MaxDropDownItems = 9
        Me.cboParMultiplier.Name = "cboParMultiplier"
        Me.cboParMultiplier.Size = New System.Drawing.Size(100, 21)
        Me.cboParMultiplier.TabIndex = 5
        Me.cboParMultiplier.Visible = False
        '
        'totalInvoiceLabel
        '
        Me.totalInvoiceLabel.BackColor = System.Drawing.Color.Transparent
        Me.totalInvoiceLabel.Location = New System.Drawing.Point(19, 418)
        Me.totalInvoiceLabel.Name = "totalInvoiceLabel"
        Me.totalInvoiceLabel.Size = New System.Drawing.Size(168, 23)
        Me.totalInvoiceLabel.TabIndex = 32
        Me.totalInvoiceLabel.Text = "Total invoice"
        Me.totalInvoiceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCommissionPriceLabel
        '
        Me.lblCommissionPriceLabel.BackColor = System.Drawing.Color.Transparent
        Me.lblCommissionPriceLabel.Location = New System.Drawing.Point(19, 395)
        Me.lblCommissionPriceLabel.Name = "lblCommissionPriceLabel"
        Me.lblCommissionPriceLabel.Size = New System.Drawing.Size(168, 23)
        Me.lblCommissionPriceLabel.TabIndex = 30
        Me.lblCommissionPriceLabel.Text = "Commission price"
        Me.lblCommissionPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCommissionRateLabel
        '
        Me.lblCommissionRateLabel.BackColor = System.Drawing.Color.Transparent
        Me.lblCommissionRateLabel.Location = New System.Drawing.Point(19, 372)
        Me.lblCommissionRateLabel.Name = "lblCommissionRateLabel"
        Me.lblCommissionRateLabel.Size = New System.Drawing.Size(168, 23)
        Me.lblCommissionRateLabel.TabIndex = 28
        Me.lblCommissionRateLabel.Text = "Commission rate"
        Me.lblCommissionRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPricingParPrice
        '
        Me.lblPricingParPrice.BackColor = System.Drawing.Color.Transparent
        Me.lblPricingParPrice.Location = New System.Drawing.Point(19, 241)
        Me.lblPricingParPrice.Name = "lblPricingParPrice"
        Me.lblPricingParPrice.Size = New System.Drawing.Size(168, 23)
        Me.lblPricingParPrice.TabIndex = 26
        Me.lblPricingParPrice.Text = "Par price"
        Me.lblPricingParPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPricingParMultiplier
        '
        Me.lblPricingParMultiplier.BackColor = System.Drawing.Color.Transparent
        Me.lblPricingParMultiplier.Location = New System.Drawing.Point(19, 217)
        Me.lblPricingParMultiplier.Name = "lblPricingParMultiplier"
        Me.lblPricingParMultiplier.Size = New System.Drawing.Size(168, 23)
        Me.lblPricingParMultiplier.TabIndex = 24
        Me.lblPricingParMultiplier.Text = "Par multiplier"
        Me.lblPricingParMultiplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOther
        '
        Me.txtOther.Location = New System.Drawing.Point(223, 348)
        Me.txtOther.Name = "txtOther"
        Me.txtOther.Size = New System.Drawing.Size(100, 21)
        Me.txtOther.TabIndex = 23
        Me.txtOther.Text = "$0"
        '
        'lblOther
        '
        Me.lblOther.BackColor = System.Drawing.Color.Transparent
        Me.lblOther.Location = New System.Drawing.Point(19, 348)
        Me.lblOther.Name = "lblOther"
        Me.lblOther.Size = New System.Drawing.Size(168, 23)
        Me.lblOther.TabIndex = 22
        Me.lblOther.Text = "Other"
        Me.lblOther.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFreight
        '
        Me.txtFreight.Location = New System.Drawing.Point(223, 294)
        Me.txtFreight.Name = "txtFreight"
        Me.txtFreight.Size = New System.Drawing.Size(100, 21)
        Me.txtFreight.TabIndex = 15
        Me.txtFreight.Text = "$0"
        '
        'lblFreight
        '
        Me.lblFreight.BackColor = System.Drawing.Color.Transparent
        Me.lblFreight.Location = New System.Drawing.Point(19, 294)
        Me.lblFreight.Name = "lblFreight"
        Me.lblFreight.Size = New System.Drawing.Size(168, 23)
        Me.lblFreight.TabIndex = 20
        Me.lblFreight.Text = "Freight"
        Me.lblFreight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtStartUp
        '
        Me.txtStartUp.Location = New System.Drawing.Point(223, 321)
        Me.txtStartUp.Name = "txtStartUp"
        Me.txtStartUp.Size = New System.Drawing.Size(100, 21)
        Me.txtStartUp.TabIndex = 19
        Me.txtStartUp.Text = "$0"
        '
        'lblStartUp
        '
        Me.lblStartUp.BackColor = System.Drawing.Color.Transparent
        Me.lblStartUp.Location = New System.Drawing.Point(19, 321)
        Me.lblStartUp.Name = "lblStartUp"
        Me.lblStartUp.Size = New System.Drawing.Size(168, 23)
        Me.lblStartUp.TabIndex = 18
        Me.lblStartUp.Text = "Start up"
        Me.lblStartUp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSummaryTotalListPrice
        '
        Me.lblSummaryTotalListPrice.BackColor = System.Drawing.Color.Transparent
        Me.lblSummaryTotalListPrice.ForeColor = System.Drawing.Color.Blue
        Me.lblSummaryTotalListPrice.Location = New System.Drawing.Point(220, 164)
        Me.lblSummaryTotalListPrice.Name = "lblSummaryTotalListPrice"
        Me.lblSummaryTotalListPrice.Size = New System.Drawing.Size(100, 23)
        Me.lblSummaryTotalListPrice.TabIndex = 13
        Me.lblSummaryTotalListPrice.Text = "$0"
        Me.lblSummaryTotalListPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'totalAvailableOptionsPriceLabel
        '
        Me.totalAvailableOptionsPriceLabel.BackColor = System.Drawing.Color.Transparent
        Me.totalAvailableOptionsPriceLabel.ForeColor = System.Drawing.Color.Blue
        Me.totalAvailableOptionsPriceLabel.Location = New System.Drawing.Point(220, 116)
        Me.totalAvailableOptionsPriceLabel.Name = "totalAvailableOptionsPriceLabel"
        Me.totalAvailableOptionsPriceLabel.Size = New System.Drawing.Size(100, 23)
        Me.totalAvailableOptionsPriceLabel.TabIndex = 12
        Me.totalAvailableOptionsPriceLabel.Text = "$0"
        Me.totalAvailableOptionsPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSummaryBaseListPrice
        '
        Me.lblSummaryBaseListPrice.BackColor = System.Drawing.Color.Transparent
        Me.lblSummaryBaseListPrice.ForeColor = System.Drawing.Color.Blue
        Me.lblSummaryBaseListPrice.Location = New System.Drawing.Point(220, 15)
        Me.lblSummaryBaseListPrice.Name = "lblSummaryBaseListPrice"
        Me.lblSummaryBaseListPrice.Size = New System.Drawing.Size(100, 23)
        Me.lblSummaryBaseListPrice.TabIndex = 11
        Me.lblSummaryBaseListPrice.Text = "$0"
        Me.lblSummaryBaseListPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPricingTotalList
        '
        Me.lblPricingTotalList.BackColor = System.Drawing.Color.Transparent
        Me.lblPricingTotalList.Location = New System.Drawing.Point(19, 164)
        Me.lblPricingTotalList.Name = "lblPricingTotalList"
        Me.lblPricingTotalList.Size = New System.Drawing.Size(168, 24)
        Me.lblPricingTotalList.TabIndex = 8
        Me.lblPricingTotalList.Text = "Total list"
        Me.lblPricingTotalList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'totalAvailableOptionsLabel
        '
        Me.totalAvailableOptionsLabel.BackColor = System.Drawing.Color.Transparent
        Me.totalAvailableOptionsLabel.Location = New System.Drawing.Point(19, 116)
        Me.totalAvailableOptionsLabel.Name = "totalAvailableOptionsLabel"
        Me.totalAvailableOptionsLabel.Size = New System.Drawing.Size(168, 24)
        Me.totalAvailableOptionsLabel.TabIndex = 6
        Me.totalAvailableOptionsLabel.Text = "Total available options"
        Me.totalAvailableOptionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPricingBaseList
        '
        Me.lblPricingBaseList.BackColor = System.Drawing.Color.Transparent
        Me.lblPricingBaseList.Location = New System.Drawing.Point(19, 15)
        Me.lblPricingBaseList.Name = "lblPricingBaseList"
        Me.lblPricingBaseList.Size = New System.Drawing.Size(168, 24)
        Me.lblPricingBaseList.TabIndex = 4
        Me.lblPricingBaseList.Text = "Total base list"
        Me.lblPricingBaseList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabOptionsSummary
        '
        Me.tabOptionsSummary.BackColor = System.Drawing.Color.White
        Me.tabOptionsSummary.Controls.Add(Me.panOptionsSummary)
        Me.tabOptionsSummary.Controls.Add(Me.Splitter2)
        Me.tabOptionsSummary.Controls.Add(Me.panSpecialOptionsSummary)
        Me.tabOptionsSummary.Controls.Add(Me.Splitter1)
        Me.tabOptionsSummary.Controls.Add(Me.panSelectedOptions)
        Me.tabOptionsSummary.Location = New System.Drawing.Point(4, 22)
        Me.tabOptionsSummary.Name = "tabOptionsSummary"
        Me.tabOptionsSummary.Size = New System.Drawing.Size(663, 504)
        Me.tabOptionsSummary.TabIndex = 3
        Me.tabOptionsSummary.Text = "Option Summary"
        Me.tabOptionsSummary.UseVisualStyleBackColor = True
        '
        'panOptionsSummary
        '
        Me.panOptionsSummary.Controls.Add(Me.selectedAvailableLabel)
        Me.panOptionsSummary.Controls.Add(Me.selectedCommonOptionsPriceLabel)
        Me.panOptionsSummary.Controls.Add(Me.selectedCommonOptionsLabel)
        Me.panOptionsSummary.Controls.Add(Me.selectedAvailableOptionsLabel)
        Me.panOptionsSummary.Controls.Add(Me.selectedOpGrid)
        Me.panOptionsSummary.Controls.Add(Me.selectedAvailableOptionsPriceLabel)
        Me.panOptionsSummary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panOptionsSummary.Location = New System.Drawing.Point(0, 298)
        Me.panOptionsSummary.Name = "panOptionsSummary"
        Me.panOptionsSummary.Size = New System.Drawing.Size(663, 206)
        Me.panOptionsSummary.TabIndex = 54
        '
        'selectedCommonOptionsPriceLabel
        '
        Me.selectedCommonOptionsPriceLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.selectedCommonOptionsPriceLabel.BackColor = System.Drawing.Color.Transparent
        Me.selectedCommonOptionsPriceLabel.ForeColor = System.Drawing.Color.Blue
        Me.selectedCommonOptionsPriceLabel.Location = New System.Drawing.Point(567, 157)
        Me.selectedCommonOptionsPriceLabel.Name = "selectedCommonOptionsPriceLabel"
        Me.selectedCommonOptionsPriceLabel.Size = New System.Drawing.Size(96, 23)
        Me.selectedCommonOptionsPriceLabel.TabIndex = 56
        Me.selectedCommonOptionsPriceLabel.Text = "$0"
        Me.selectedCommonOptionsPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'selectedCommonOptionsLabel
        '
        Me.selectedCommonOptionsLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.selectedCommonOptionsLabel.BackColor = System.Drawing.Color.Transparent
        Me.selectedCommonOptionsLabel.Location = New System.Drawing.Point(381, 157)
        Me.selectedCommonOptionsLabel.Name = "selectedCommonOptionsLabel"
        Me.selectedCommonOptionsLabel.Size = New System.Drawing.Size(180, 23)
        Me.selectedCommonOptionsLabel.TabIndex = 55
        Me.selectedCommonOptionsLabel.Text = "Selected common options total"
        Me.selectedCommonOptionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'selectedAvailableOptionsLabel
        '
        Me.selectedAvailableOptionsLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.selectedAvailableOptionsLabel.BackColor = System.Drawing.Color.Transparent
        Me.selectedAvailableOptionsLabel.Location = New System.Drawing.Point(340, 180)
        Me.selectedAvailableOptionsLabel.Name = "selectedAvailableOptionsLabel"
        Me.selectedAvailableOptionsLabel.Size = New System.Drawing.Size(221, 23)
        Me.selectedAvailableOptionsLabel.TabIndex = 52
        Me.selectedAvailableOptionsLabel.Text = "Selected available options total (per unit)"
        Me.selectedAvailableOptionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'selectedAvailableLabel
        '
        Me.selectedAvailableLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.selectedAvailableLabel.BackColor = System.Drawing.Color.LightGray
        Me.selectedAvailableLabel.Location = New System.Drawing.Point(12, 0)
        Me.selectedAvailableLabel.Name = "selectedAvailableOptionsLabel"
        Me.selectedAvailableLabel.Size = New System.Drawing.Size(639, 15)
        Me.selectedAvailableLabel.TabIndex = 52
        Me.selectedAvailableLabel.Text = "Selected Available Options Summary"
        Me.selectedAvailableLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'selectedOpGrid
        '
        Me.selectedOpGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.selectedOpGrid.IsPriceVisible = False
        Me.selectedOpGrid.Location = New System.Drawing.Point(12, 15)
        Me.selectedOpGrid.Name = "selectedOpGrid"
        Me.selectedOpGrid.Size = New System.Drawing.Size(639, 135)
        Me.selectedOpGrid.TabIndex = 50
        Me.selectedOpGrid.ReadOnly = True
        Me.selectedOpGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.selectedOpGrid.MultiSelect = False
        '
        'selectedAvailableOptionsPriceLabel
        '
        Me.selectedAvailableOptionsPriceLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.selectedAvailableOptionsPriceLabel.BackColor = System.Drawing.Color.Transparent
        Me.selectedAvailableOptionsPriceLabel.ForeColor = System.Drawing.Color.Blue
        Me.selectedAvailableOptionsPriceLabel.Location = New System.Drawing.Point(567, 180)
        Me.selectedAvailableOptionsPriceLabel.Name = "selectedAvailableOptionsPriceLabel"
        Me.selectedAvailableOptionsPriceLabel.Size = New System.Drawing.Size(96, 23)
        Me.selectedAvailableOptionsPriceLabel.TabIndex = 51
        Me.selectedAvailableOptionsPriceLabel.Text = "$0"
        Me.selectedAvailableOptionsPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Splitter2
        '
        Me.Splitter2.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Splitter2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter2.Location = New System.Drawing.Point(0, 290)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(663, 8)
        Me.Splitter2.TabIndex = 56
        Me.Splitter2.TabStop = False
        '
        'panSpecialOptionsSummary
        '
        Me.panSpecialOptionsSummary.Controls.Add(Me.lblSpecialOptionsSummaryLabel)
        Me.panSpecialOptionsSummary.Controls.Add(Me.specialOpGrid)
        Me.panSpecialOptionsSummary.Controls.Add(Me.lblSpecialOptionsSummaryTotalPriceLabel)

        Me.panSpecialOptionsSummary.Controls.Add(Me.lblSpecialOptionsSummaryTotalPrice)
        Me.panSpecialOptionsSummary.Dock = System.Windows.Forms.DockStyle.Top
        Me.panSpecialOptionsSummary.Location = New System.Drawing.Point(0, 165)
        Me.panSpecialOptionsSummary.Name = "panSpecialOptionsSummary"
        Me.panSpecialOptionsSummary.Size = New System.Drawing.Size(663, 125)
        Me.panSpecialOptionsSummary.TabIndex = 55
        '''
        '''specialOpGrid
        '''
        ''Me.specialOpGrid.AllowUpdate = False
        ''Me.specialOpGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
        ''            Or System.Windows.Forms.AnchorStyles.Left) _
        ''            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ''Me.specialOpGrid.Caption = "Special Options Summary"
        ''Me.specialOpGrid.CaptionHeight = 19
        ''Me.specialOpGrid.GroupByCaption = "Drag a column header here to group by that column"
        ''Me.specialOpGrid.Images.Add(CType(resources.GetObject("specialOpGrid.Images"), System.Drawing.Image))
        ''Me.specialOpGrid.Location = New System.Drawing.Point(12, 6)
        ''Me.specialOpGrid.Name = "specialOpGrid"
        ''Me.specialOpGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        ''Me.specialOpGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        ''Me.specialOpGrid.PreviewInfo.ZoomFactor = 75.0R
        ''Me.specialOpGrid.PrintInfo.PageSettings = CType(resources.GetObject("specialOpGrid.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        ''Me.specialOpGrid.RecordSelectors = False
        ''Me.specialOpGrid.RowHeight = 15
        ''Me.specialOpGrid.Size = New System.Drawing.Size(639, 95)
        ''Me.specialOpGrid.TabIndex = 56
        ''Me.specialOpGrid.Text = "Special Options Summary"
        ''Me.specialOpGrid.PropBag = resources.GetString("specialOpGrid.PropBag")
        '''
        '''specialOpGrid
        '''
        Me.specialOpGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.specialOpGrid.Location = New System.Drawing.Point(12, 15)
        Me.specialOpGrid.Name = "specialOpGrid"
        Me.specialOpGrid.Size = New System.Drawing.Size(639, 89)
        Me.specialOpGrid.TabIndex = 56
        Me.specialOpGrid.Text = "Special Options Summary"
        Me.specialOpGrid.RowHeadersVisible = False
        Me.specialOpGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray

        Me.specialOpGrid.EnableHeadersVisualStyles = False
        Me.specialOpGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue
        Me.specialOpGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.specialOpGrid.MultiSelect = False
        '
        'lblSpecialOptionsSummaryTotalPriceLabel
        '
        Me.lblSpecialOptionsSummaryTotalPriceLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSpecialOptionsSummaryTotalPriceLabel.BackColor = System.Drawing.Color.Transparent
        Me.lblSpecialOptionsSummaryTotalPriceLabel.Location = New System.Drawing.Point(434, 101)
        Me.lblSpecialOptionsSummaryTotalPriceLabel.Name = "lblSpecialOptionsSummaryTotalPriceLabel"
        Me.lblSpecialOptionsSummaryTotalPriceLabel.Size = New System.Drawing.Size(124, 23)
        Me.lblSpecialOptionsSummaryTotalPriceLabel.TabIndex = 54
        Me.lblSpecialOptionsSummaryTotalPriceLabel.Text = "Special options total"
        Me.lblSpecialOptionsSummaryTotalPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSpecialOptionsSummaryTotalPriceLabel
        '
        Me.lblSpecialOptionsSummaryLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSpecialOptionsSummaryLabel.BackColor = System.Drawing.Color.LightGray
        Me.lblSpecialOptionsSummaryLabel.Location = New System.Drawing.Point(12, 0)
        Me.lblSpecialOptionsSummaryLabel.Name = "lblSpecialOptionsSummaryLabel"
        Me.lblSpecialOptionsSummaryLabel.Size = New System.Drawing.Size(639, 15)
        Me.lblSpecialOptionsSummaryLabel.TabIndex = 54
        Me.lblSpecialOptionsSummaryLabel.Text = "Special options Summary"
        Me.lblSpecialOptionsSummaryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSpecialOptionsSummaryTotalPrice
        '
        Me.lblSpecialOptionsSummaryTotalPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSpecialOptionsSummaryTotalPrice.BackColor = System.Drawing.Color.Transparent
        Me.lblSpecialOptionsSummaryTotalPrice.ForeColor = System.Drawing.Color.Blue
        Me.lblSpecialOptionsSummaryTotalPrice.Location = New System.Drawing.Point(564, 101)
        Me.lblSpecialOptionsSummaryTotalPrice.Name = "lblSpecialOptionsSummaryTotalPrice"
        Me.lblSpecialOptionsSummaryTotalPrice.Size = New System.Drawing.Size(96, 23)
        Me.lblSpecialOptionsSummaryTotalPrice.TabIndex = 53
        Me.lblSpecialOptionsSummaryTotalPrice.Text = "$0.00"
        Me.lblSpecialOptionsSummaryTotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter1.Location = New System.Drawing.Point(0, 157)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(663, 8)
        Me.Splitter1.TabIndex = 55
        Me.Splitter1.TabStop = False
        '
        'panSelectedOptions
        '
        Me.panSelectedOptions.Controls.Add(Me.infoReviewLabel)
        Me.panSelectedOptions.Controls.Add(Me.standardOpGrid)
        Me.panSelectedOptions.Dock = System.Windows.Forms.DockStyle.Top
        Me.panSelectedOptions.Location = New System.Drawing.Point(0, 0)
        Me.panSelectedOptions.Name = "panSelectedOptions"
        Me.panSelectedOptions.Size = New System.Drawing.Size(663, 157)
        Me.panSelectedOptions.TabIndex = 53
        '
        'infoReviewLabel
        '
        Me.infoReviewLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.infoReviewLabel.BackColor = System.Drawing.Color.Transparent
        Me.infoReviewLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.infoReviewLabel.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Info
        Me.infoReviewLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.infoReviewLabel.Location = New System.Drawing.Point(13, 14)
        Me.infoReviewLabel.Name = "infoReviewLabel"
        Me.infoReviewLabel.Size = New System.Drawing.Size(635, 21)
        Me.infoReviewLabel.TabIndex = 50
        Me.infoReviewLabel.Text = "       Review option summary                  Standard Options"
        Me.infoReviewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'infoReviewLabel
        '
        ''Me.infoReviewLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
        ''            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ''Me.infoReviewLabel.BackColor = System.Drawing.Color.Transparent
        ''Me.infoReviewLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ''Me.infoReviewLabel.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Info
        ''Me.infoReviewLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        ''Me.infoReviewLabel.Location = New System.Drawing.Point(13, 14)
        ''Me.infoReviewLabel.Name = "infoReviewLabel"
        ''Me.infoReviewLabel.Size = New System.Drawing.Size(635, 21)
        ''Me.infoReviewLabel.TabIndex = 50
        ''Me.infoReviewLabel.Text = "       Review option summary"
        ''Me.infoReviewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'standardOpGrid
        '
        Me.standardOpGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.standardOpGrid.Location = New System.Drawing.Point(12, 40)
        Me.standardOpGrid.Name = "standardOpGrid"
        Me.standardOpGrid.Size = New System.Drawing.Size(639, 110)
        Me.standardOpGrid.TabIndex = 0
        Me.standardOpGrid.Text = "C1TrueDBGrid1"
        Me.standardOpGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.standardOpGrid.MultiSelect = False
        '
        'tabAvailableOptions
        '
        Me.tabAvailableOptions.BackColor = System.Drawing.Color.White
        Me.tabAvailableOptions.Controls.Add(Me.availableOptionsPanel)
        Me.tabAvailableOptions.Location = New System.Drawing.Point(4, 22)
        Me.tabAvailableOptions.Name = "tabAvailableOptions"
        Me.tabAvailableOptions.Size = New System.Drawing.Size(663, 504)
        Me.tabAvailableOptions.TabIndex = 1
        Me.tabAvailableOptions.Text = "Available Options"
        Me.tabAvailableOptions.UseVisualStyleBackColor = True
        '
        'availableOptionsPanel
        '
        Me.availableOptionsPanel.Controls.Add(Me.lblNoOptions)
        ''Me.availableOptionsPanel.Controls.Add(Me.optionToolbarPanel)
        Me.availableOptionsPanel.Controls.Add(Me.availableOpGrid)
        Me.availableOptionsPanel.Controls.Add(Me.lblAvailableGrid)
        Me.availableOptionsPanel.Controls.Add(Me.infoAvailableOpLabel)
        Me.availableOptionsPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.availableOptionsPanel.Location = New System.Drawing.Point(0, 0)
        Me.availableOptionsPanel.Name = "availableOptionsPanel"
        Me.availableOptionsPanel.Size = New System.Drawing.Size(663, 504)
        Me.availableOptionsPanel.TabIndex = 49
        '
        'lblNoOptions
        '
        Me.lblNoOptions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNoOptions.ForeColor = System.Drawing.Color.DimGray
        Me.lblNoOptions.Location = New System.Drawing.Point(13, 89)
        Me.lblNoOptions.Name = "lblNoOptions"
        Me.lblNoOptions.Size = New System.Drawing.Size(637, 144)
        Me.lblNoOptions.TabIndex = 48
        Me.lblNoOptions.Text = "The model and unit voltage must be selected before the available options can be d" & _
            "etermined."
        Me.lblNoOptions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblNoOptions.Visible = False
        '
        'optionToolbarPanel
        '
        Me.optionToolbarPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ''Me.optionToolbarPanel.Controls.Add(Me.unselectLink)
        ''Me.optionToolbarPanel.Controls.Add(Me.groupLink)
        Me.optionToolbarPanel.Location = New System.Drawing.Point(13, 65)
        Me.optionToolbarPanel.Name = "optionToolbarPanel"
        Me.optionToolbarPanel.Size = New System.Drawing.Size(637, 23)
        Me.optionToolbarPanel.TabIndex = 51
        '''
        '''unselectLink
        '''
        ''Me.unselectLink.BackColor = System.Drawing.Color.Transparent
        ''Me.unselectLink.Cursor = System.Windows.Forms.Cursors.Hand
        ''Me.unselectLink.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Unchecked
        ''Me.unselectLink.Location = New System.Drawing.Point(132, 0)
        ''Me.unselectLink.Margin = New System.Windows.Forms.Padding(4)
        ''Me.unselectLink.Name = "unselectLink"
        ''Me.unselectLink.Size = New System.Drawing.Size(96, 23)
        ''Me.unselectLink.TabIndex = 54
        ''Me.unselectLink.Text = "Unselect All"
        '''
        '''groupLink
        '''
        ''Me.groupLink.BackColor = System.Drawing.Color.Transparent
        ''Me.groupLink.Cursor = System.Windows.Forms.Cursors.Hand
        ''Me.groupLink.Image = Global.Rae.RaeSolutions.My.Resources.Resources.ListFlat
        ''Me.groupLink.ImageToggled = Global.Rae.RaeSolutions.My.Resources.Resources.ListGrouped
        ''Me.groupLink.Location = New System.Drawing.Point(5, 0)
        ''Me.groupLink.Margin = New System.Windows.Forms.Padding(4)
        ''Me.groupLink.Name = "groupLink"
        ''Me.groupLink.Size = New System.Drawing.Size(122, 23)
        ''Me.groupLink.TabIndex = 53
        ''Me.groupLink.Text = "Ungroup"
        ''Me.groupLink.TextToggled = "Group by Category"
        '''
        '''availableOpGrid
        '''
        ''Me.availableOpGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
        ''            Or System.Windows.Forms.AnchorStyles.Left) _
        ''            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ''Me.availableOpGrid.IsPriceVisible = False
        ''Me.availableOpGrid.Location = New System.Drawing.Point(12, 40)
        ''Me.availableOpGrid.Name = "availableOpGrid"
        ''Me.availableOpGrid.Size = New System.Drawing.Size(639, 455)
        ''Me.availableOpGrid.TabIndex = 40
        ''Me.availableOpGrid.Text = "Options"
        '
        'availableOpGrid
        '
        Me.availableOpGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.availableOpGrid.IsPriceVisible = False
        Me.availableOpGrid.Location = New System.Drawing.Point(12, 40)
        Me.availableOpGrid.Name = "availableOpGrid"
        Me.availableOpGrid.Size = New System.Drawing.Size(639, 455)
        Me.availableOpGrid.TabIndex = 40
        Me.availableOpGrid.Text = "Options"
        Me.availableOpGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.availableOpGrid.MultiSelect = False
        '
        'infoAvailableOpLabel
        '
        Me.infoAvailableOpLabel.BackColor = System.Drawing.Color.Yellow
        Me.infoAvailableOpLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.infoAvailableOpLabel.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Info
        Me.infoAvailableOpLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.infoAvailableOpLabel.Location = New System.Drawing.Point(13, 13)
        Me.infoAvailableOpLabel.Name = "infoAvailableOpLabel"
        Me.infoAvailableOpLabel.Size = New System.Drawing.Size(375, 23)
        Me.infoAvailableOpLabel.TabIndex = 41
        Me.infoAvailableOpLabel.Text = "       Select available options.  Note: Please hit enter after check/uncheck a box"
        Me.infoAvailableOpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabModel
        '
        Me.tabModel.BackColor = System.Drawing.Color.White
        Me.tabModel.Controls.Add(Me.specsHeaderPanel)
        Me.tabModel.Controls.Add(Me.pricingPanel)
        Me.tabModel.Controls.Add(Me.modelPanel)
        Me.tabModel.Location = New System.Drawing.Point(4, 22)
        Me.tabModel.Name = "tabModel"
        Me.tabModel.Size = New System.Drawing.Size(663, 504)
        Me.tabModel.TabIndex = 0
        Me.tabModel.Text = "Specs"
        '
        'specsHeaderPanel
        '
        Me.specsHeaderPanel.Controls.Add(Me.lblSpecs)
        Me.specsHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.specsHeaderPanel.Location = New System.Drawing.Point(0, 139)
        Me.specsHeaderPanel.Name = "specsHeaderPanel"
        Me.specsHeaderPanel.Size = New System.Drawing.Size(663, 30)
        Me.specsHeaderPanel.TabIndex = 141
        '
        'lblSpecs
        '
        Me.lblSpecs.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblSpecs.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSpecs.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSpecs.ForeColor = System.Drawing.Color.White
        Me.lblSpecs.Location = New System.Drawing.Point(0, 0)
        Me.lblSpecs.Margin = New System.Windows.Forms.Padding(3, 0, 3, 6)
        Me.lblSpecs.Name = "lblSpecs"
        Me.lblSpecs.Size = New System.Drawing.Size(663, 23)
        Me.lblSpecs.TabIndex = 137
        Me.lblSpecs.Text = " Specifications"
        Me.lblSpecs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pricingPanel
        '
        Me.pricingPanel.Controls.Add(Me.lblTotalBaseListPrice)
        Me.pricingPanel.Controls.Add(Me.lblTotalBaseListPriceLabel)
        Me.pricingPanel.Controls.Add(Me.txtUnitQuantity)
        Me.pricingPanel.Controls.Add(Me.lblUnitQuantity)
        Me.pricingPanel.Controls.Add(Me.lblBaseListPrice)
        Me.pricingPanel.Controls.Add(Me.lblBaseListPriceLabel)
        Me.pricingPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.pricingPanel.Location = New System.Drawing.Point(0, 111)
        Me.pricingPanel.Name = "pricingPanel"
        Me.pricingPanel.Size = New System.Drawing.Size(663, 28)
        Me.pricingPanel.TabIndex = 140
        '
        'lblTotalBaseListPrice
        '
        Me.lblTotalBaseListPrice.ForeColor = System.Drawing.Color.Blue
        Me.lblTotalBaseListPrice.Location = New System.Drawing.Point(398, 27)
        Me.lblTotalBaseListPrice.Name = "lblTotalBaseListPrice"
        Me.lblTotalBaseListPrice.Size = New System.Drawing.Size(84, 23)
        Me.lblTotalBaseListPrice.TabIndex = 126
        Me.lblTotalBaseListPrice.Text = "$0.00"
        Me.lblTotalBaseListPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTotalBaseListPrice.Visible = False
        '
        'lblTotalBaseListPriceLabel
        '
        Me.lblTotalBaseListPriceLabel.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalBaseListPriceLabel.Location = New System.Drawing.Point(272, 27)
        Me.lblTotalBaseListPriceLabel.Name = "lblTotalBaseListPriceLabel"
        Me.lblTotalBaseListPriceLabel.Size = New System.Drawing.Size(120, 23)
        Me.lblTotalBaseListPriceLabel.TabIndex = 125
        Me.lblTotalBaseListPriceLabel.Text = "Total base list price"
        Me.lblTotalBaseListPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTotalBaseListPriceLabel.Visible = False
        '
        'txtUnitQuantity
        '
        Me.txtUnitQuantity.Location = New System.Drawing.Point(119, 3)
        Me.txtUnitQuantity.Name = "txtUnitQuantity"
        Me.txtUnitQuantity.Size = New System.Drawing.Size(72, 21)
        Me.txtUnitQuantity.TabIndex = 124
        Me.txtUnitQuantity.Text = "1"
        '
        'lblUnitQuantity
        '
        Me.lblUnitQuantity.BackColor = System.Drawing.Color.Transparent
        Me.lblUnitQuantity.Location = New System.Drawing.Point(27, 3)
        Me.lblUnitQuantity.Name = "lblUnitQuantity"
        Me.lblUnitQuantity.Size = New System.Drawing.Size(86, 23)
        Me.lblUnitQuantity.TabIndex = 123
        Me.lblUnitQuantity.Text = "Quantity"
        Me.lblUnitQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBaseListPrice
        '
        Me.lblBaseListPrice.ForeColor = System.Drawing.Color.Blue
        Me.lblBaseListPrice.Location = New System.Drawing.Point(398, 3)
        Me.lblBaseListPrice.Name = "lblBaseListPrice"
        Me.lblBaseListPrice.Size = New System.Drawing.Size(84, 23)
        Me.lblBaseListPrice.TabIndex = 122
        Me.lblBaseListPrice.Text = "$0.00"
        Me.lblBaseListPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBaseListPriceLabel
        '
        Me.lblBaseListPriceLabel.BackColor = System.Drawing.Color.Transparent
        Me.lblBaseListPriceLabel.Location = New System.Drawing.Point(272, 3)
        Me.lblBaseListPriceLabel.Name = "lblBaseListPriceLabel"
        Me.lblBaseListPriceLabel.Size = New System.Drawing.Size(120, 23)
        Me.lblBaseListPriceLabel.TabIndex = 121
        Me.lblBaseListPriceLabel.Text = "Base list price"
        Me.lblBaseListPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'modelPanel
        '
        Me.modelPanel.Controls.Add(Me.infoModelParenLabel)
        Me.modelPanel.Controls.Add(Me.infoModelLabel)
        Me.modelPanel.Controls.Add(Me.txtCustomModel)
        Me.modelPanel.Controls.Add(Me.lblModelNumber)
        Me.modelPanel.Controls.Add(Me.lblUnitVoltage)
        Me.modelPanel.Controls.Add(Me.cboUnitVoltage)
        Me.modelPanel.Controls.Add(Me.EquipmentSelector1)
        Me.modelPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.modelPanel.Location = New System.Drawing.Point(0, 0)
        Me.modelPanel.Name = "modelPanel"
        Me.modelPanel.Size = New System.Drawing.Size(663, 111)
        Me.modelPanel.TabIndex = 145
        '
        'infoModelParenLabel
        '
        Me.infoModelParenLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.infoModelParenLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.infoModelParenLabel.ForeColor = System.Drawing.Color.DimGray
        Me.infoModelParenLabel.Location = New System.Drawing.Point(246, 13)
        Me.infoModelParenLabel.Name = "infoModelParenLabel"
        Me.infoModelParenLabel.Size = New System.Drawing.Size(403, 23)
        Me.infoModelParenLabel.TabIndex = 145
        Me.infoModelParenLabel.Text = "(necessary to determine available options)"
        Me.infoModelParenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'infoModelLabel
        '
        Me.infoModelLabel.BackColor = System.Drawing.Color.Transparent
        Me.infoModelLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.infoModelLabel.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Info
        Me.infoModelLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.infoModelLabel.Location = New System.Drawing.Point(13, 13)
        Me.infoModelLabel.Name = "infoModelLabel"
        Me.infoModelLabel.Size = New System.Drawing.Size(206, 23)
        Me.infoModelLabel.TabIndex = 144
        Me.infoModelLabel.Text = "       Select a model and voltage"
        Me.infoModelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCustomModel
        '
        Me.txtCustomModel.Location = New System.Drawing.Point(89, 84)
        Me.txtCustomModel.Name = "txtCustomModel"
        Me.txtCustomModel.Size = New System.Drawing.Size(175, 21)
        Me.txtCustomModel.TabIndex = 140
        '
        'lblModelNumber
        '
        Me.lblModelNumber.Location = New System.Drawing.Point(-3, 84)
        Me.lblModelNumber.Name = "lblModelNumber"
        Me.lblModelNumber.Size = New System.Drawing.Size(85, 21)
        Me.lblModelNumber.TabIndex = 141
        Me.lblModelNumber.Text = "Custom model"
        Me.lblModelNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboUnitVoltage
        '
        Me.cboUnitVoltage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnitVoltage.Items.AddRange(New Object() {"460/3/60", "230/3/60", "208/3/60", "460/1/60", "230/1/60", "208/1/60", "115/1/60"})
        Me.cboUnitVoltage.Location = New System.Drawing.Point(410, 56)
        Me.cboUnitVoltage.Name = "cboUnitVoltage"
        Me.cboUnitVoltage.Size = New System.Drawing.Size(72, 21)
        Me.cboUnitVoltage.TabIndex = 31
        '
        'EquipmentSelector1
        '
        Me.EquipmentSelector1.BackColor = System.Drawing.Color.Transparent
        ''Me.EquipmentSelector1.Division = Rae.RaeSolutions.Business.Division.NotSet
        Me.EquipmentSelector1.EquipmentType = Nothing
        Me.EquipmentSelector1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EquipmentSelector1.Location = New System.Drawing.Point(17, 34)
        Me.EquipmentSelector1.Model = ""
        Me.EquipmentSelector1.Name = "EquipmentSelector1"
        Me.EquipmentSelector1.Series = Nothing
        Me.EquipmentSelector1.ShowBorder = False
        Me.EquipmentSelector1.Size = New System.Drawing.Size(280, 52)
        Me.EquipmentSelector1.TabIndex = 136
        Me.EquipmentSelector1.User = Nothing
        '
        'tabEquipment
        '
        Me.tabEquipment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabEquipment.Controls.Add(Me.tabModel)
        Me.tabEquipment.Controls.Add(Me.tabAvailableOptions)
        Me.tabEquipment.Controls.Add(Me.tabSpecialOptions)
        Me.tabEquipment.Controls.Add(Me.tabOptionsSummary)
        Me.tabEquipment.Controls.Add(Me.tabPricing)
        Me.tabEquipment.Location = New System.Drawing.Point(12, 28)
        Me.tabEquipment.Name = "tabEquipment"
        Me.tabEquipment.SelectedIndex = 0
        Me.tabEquipment.Size = New System.Drawing.Size(671, 530)
        Me.tabEquipment.TabIndex = 45
        '
        'tabSpecialOptions
        '
        Me.tabSpecialOptions.Controls.Add(Me.infoSpecialOpParenLabel)
        Me.tabSpecialOptions.Controls.Add(Me.infoSpecialOpLabel)
        Me.tabSpecialOptions.Controls.Add(Me.SpecialOptionsControl1)
        Me.tabSpecialOptions.Location = New System.Drawing.Point(4, 22)
        Me.tabSpecialOptions.Name = "tabSpecialOptions"
        Me.tabSpecialOptions.Size = New System.Drawing.Size(663, 504)
        Me.tabSpecialOptions.TabIndex = 4
        Me.tabSpecialOptions.Text = "Special Options"
        Me.tabSpecialOptions.UseVisualStyleBackColor = True
        '
        'infoSpecialOpParenLabel
        '
        Me.infoSpecialOpParenLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.infoSpecialOpParenLabel.ForeColor = System.Drawing.Color.DimGray
        Me.infoSpecialOpParenLabel.Location = New System.Drawing.Point(213, 14)
        Me.infoSpecialOpParenLabel.Name = "infoSpecialOpParenLabel"
        Me.infoSpecialOpParenLabel.Size = New System.Drawing.Size(268, 21)
        Me.infoSpecialOpParenLabel.TabIndex = 2
        Me.infoSpecialOpParenLabel.Text = "(that are not in the available options grid)"
        Me.infoSpecialOpParenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'infoSpecialOpLabel
        '
        Me.infoSpecialOpLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.infoSpecialOpLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.infoSpecialOpLabel.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Info
        Me.infoSpecialOpLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.infoSpecialOpLabel.Location = New System.Drawing.Point(13, 14)
        Me.infoSpecialOpLabel.Name = "infoSpecialOpLabel"
        Me.infoSpecialOpLabel.Size = New System.Drawing.Size(206, 21)
        Me.infoSpecialOpLabel.TabIndex = 1
        Me.infoSpecialOpLabel.Text = "       Add authorized special options"
        Me.infoSpecialOpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SpecialOptionsControl1
        '
        Me.SpecialOptionsControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SpecialOptionsControl1.BackColor = System.Drawing.Color.White
        Me.SpecialOptionsControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpecialOptionsControl1.Location = New System.Drawing.Point(11, 38)
        Me.SpecialOptionsControl1.Name = "SpecialOptionsControl1"
        Me.SpecialOptionsControl1.Size = New System.Drawing.Size(521, 447)
        Me.SpecialOptionsControl1.TabIndex = 0
        '
        'equipmentMenuStrip
        '
        Me.equipmentMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuReports, Me.mnuDrawings})
        Me.equipmentMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.equipmentMenuStrip.Name = "equipmentMenuStrip"
        Me.equipmentMenuStrip.Size = New System.Drawing.Size(575, 24)
        Me.equipmentMenuStrip.TabIndex = 46
        Me.equipmentMenuStrip.Text = "MenuStrip1"
        Me.equipmentMenuStrip.Visible = False
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.aboveSaveSeparator, Me.mnuSave, Me.mnuSaveAs, Me.mnuSaveAsRevision, Me.belowSaveSeparator, Me.mnuConvert, Me.mnuClose})
        Me.mnuFile.MergeAction = System.Windows.Forms.MergeAction.MatchOnly
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(37, 20)
        Me.mnuFile.Text = "&File"
        '
        'aboveSaveSeparator
        '
        Me.aboveSaveSeparator.Name = "aboveSaveSeparator"
        Me.aboveSaveSeparator.Size = New System.Drawing.Size(164, 6)
        '
        'mnuSave
        '
        Me.mnuSave.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Save
        Me.mnuSave.MergeIndex = 3
        Me.mnuSave.Name = "mnuSave"
        Me.mnuSave.Size = New System.Drawing.Size(167, 22)
        Me.mnuSave.Text = "Save"
        '
        'mnuSaveAs
        '
        Me.mnuSaveAs.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Save
        Me.mnuSaveAs.Name = "mnuSaveAs"
        Me.mnuSaveAs.Size = New System.Drawing.Size(167, 22)
        Me.mnuSaveAs.Text = "Save As..."
        '
        'mnuSaveAsRevision
        '
        Me.mnuSaveAsRevision.Image = Global.Rae.RaeSolutions.My.Resources.Resources.SaveAsRevision
        Me.mnuSaveAsRevision.Name = "mnuSaveAsRevision"
        Me.mnuSaveAsRevision.Size = New System.Drawing.Size(167, 22)
        Me.mnuSaveAsRevision.Text = "Save as Revision"
        '
        'belowSaveSeparator
        '
        Me.belowSaveSeparator.Name = "belowSaveSeparator"
        Me.belowSaveSeparator.Size = New System.Drawing.Size(164, 6)
        '
        'mnuConvert
        '
        Me.mnuConvert.Image = Global.Rae.RaeSolutions.My.Resources.Resources.ConvertToEquipment
        Me.mnuConvert.MergeIndex = 8
        Me.mnuConvert.Name = "mnuConvert"
        Me.mnuConvert.Size = New System.Drawing.Size(167, 22)
        Me.mnuConvert.Text = "Convert to Rating"
        '
        'mnuClose
        '
        Me.mnuClose.MergeIndex = 30
        Me.mnuClose.Name = "mnuClose"
        Me.mnuClose.Size = New System.Drawing.Size(167, 22)
        Me.mnuClose.Text = "Close"
        '
        'mnuReports
        '
        Me.mnuReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSubmittal, Me.bar_equipment_proposal})
        Me.mnuReports.MergeAction = System.Windows.Forms.MergeAction.MatchOnly
        Me.mnuReports.Name = "mnuReports"
        Me.mnuReports.Size = New System.Drawing.Size(59, 20)
        Me.mnuReports.Text = "&Reports"
        '
        'mnuSubmittal
        '
        Me.mnuSubmittal.Name = "mnuSubmittal"
        Me.mnuSubmittal.Size = New System.Drawing.Size(181, 22)
        Me.mnuSubmittal.Text = "Submittal"
        '
        'bar_equipment_proposal
        '
        Me.bar_equipment_proposal.Name = "bar_equipment_proposal"
        Me.bar_equipment_proposal.Size = New System.Drawing.Size(181, 22)
        Me.bar_equipment_proposal.Text = "Equipment Proposal"
        Me.bar_equipment_proposal.Visible = False
        '
        'mnuDrawings
        '
        Me.mnuDrawings.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuUnitDrawing, Me.mnuRefrigerantPiping, Me.mnuFluidPiping})
        Me.mnuDrawings.Name = "mnuDrawings"
        Me.mnuDrawings.Size = New System.Drawing.Size(68, 20)
        Me.mnuDrawings.Text = "Drawings"
        '
        'mnuUnitDrawing
        '
        Me.mnuUnitDrawing.Name = "mnuUnitDrawing"
        Me.mnuUnitDrawing.Size = New System.Drawing.Size(244, 22)
        Me.mnuUnitDrawing.Text = "View Unit Drawing"
        '
        'mnuRefrigerantPiping
        '
        Me.mnuRefrigerantPiping.Name = "mnuRefrigerantPiping"
        Me.mnuRefrigerantPiping.Size = New System.Drawing.Size(244, 22)
        Me.mnuRefrigerantPiping.Text = "View Refrigerant Piping Drawing"
        Me.mnuRefrigerantPiping.Visible = False
        '
        'mnuFluidPiping
        '
        Me.mnuFluidPiping.Name = "mnuFluidPiping"
        Me.mnuFluidPiping.Size = New System.Drawing.Size(244, 22)
        Me.mnuFluidPiping.Text = "View Fluid Piping Drawing"
        Me.mnuFluidPiping.Visible = False
        '
        'equipmentErrorProvider
        '
        Me.equipmentErrorProvider.ContainerControl = Me
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barReports, Me.barDrawings, Me.barConvert})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(695, 25)
        Me.ToolStrip1.TabIndex = 47
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'barReports
        '
        Me.barReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barSubmittal, Me.mnu_equipment_proposal})
        Me.barReports.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Report
        Me.barReports.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barReports.Name = "barReports"
        Me.barReports.Size = New System.Drawing.Size(81, 22)
        Me.barReports.Text = "Reports"
        '
        'barSubmittal
        '
        Me.barSubmittal.Name = "barSubmittal"
        Me.barSubmittal.Size = New System.Drawing.Size(182, 22)
        Me.barSubmittal.Text = "Submittal"
        '
        'mnu_equipment_proposal
        '
        Me.mnu_equipment_proposal.Name = "mnu_equipment_proposal"
        Me.mnu_equipment_proposal.Size = New System.Drawing.Size(182, 22)
        Me.mnu_equipment_proposal.Text = "Equipment Proposal"
        Me.mnu_equipment_proposal.Visible = False
        '
        'barDrawings
        '
        Me.barDrawings.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barUnitDrawings, Me.barRefrigerantPiping, Me.barFluidPiping})
        Me.barDrawings.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Drawing
        Me.barDrawings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barDrawings.Name = "barDrawings"
        Me.barDrawings.Size = New System.Drawing.Size(88, 22)
        Me.barDrawings.Text = "Drawings"
        '
        'barUnitDrawings
        '
        Me.barUnitDrawings.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barUnitDrawingsOpen, Me.barUnitDrawingsSave})
        Me.barUnitDrawings.Name = "barUnitDrawings"
        Me.barUnitDrawings.Size = New System.Drawing.Size(170, 22)
        Me.barUnitDrawings.Text = "Unit"
        '
        'barUnitDrawingsOpen
        '
        Me.barUnitDrawingsOpen.Name = "barUnitDrawingsOpen"
        Me.barUnitDrawingsOpen.Size = New System.Drawing.Size(152, 22)
        Me.barUnitDrawingsOpen.Text = "Open Drawing"
        '
        'barUnitDrawingsSave
        '
        Me.barUnitDrawingsSave.Name = "barUnitDrawingsSave"
        Me.barUnitDrawingsSave.Size = New System.Drawing.Size(152, 22)
        Me.barUnitDrawingsSave.Text = "Save Drawing"
        '
        'barRefrigerantPiping
        '
        Me.barRefrigerantPiping.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barRefrigerantPipingOpen, Me.barRefrigerantPipingSave})
        Me.barRefrigerantPiping.Name = "barRefrigerantPiping"
        Me.barRefrigerantPiping.Size = New System.Drawing.Size(170, 22)
        Me.barRefrigerantPiping.Text = "Refrigerant Piping"
        '
        'barRefrigerantPipingOpen
        '
        Me.barRefrigerantPipingOpen.Name = "barRefrigerantPipingOpen"
        Me.barRefrigerantPipingOpen.Size = New System.Drawing.Size(152, 22)
        Me.barRefrigerantPipingOpen.Text = "Open Drawing"
        '
        'barRefrigerantPipingSave
        '
        Me.barRefrigerantPipingSave.Name = "barRefrigerantPipingSave"
        Me.barRefrigerantPipingSave.Size = New System.Drawing.Size(152, 22)
        Me.barRefrigerantPipingSave.Text = "Save Drawing"
        '
        'barFluidPiping
        '
        Me.barFluidPiping.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barFluidPipingOpen, Me.barFluidPipingSave})
        Me.barFluidPiping.Name = "barFluidPiping"
        Me.barFluidPiping.Size = New System.Drawing.Size(170, 22)
        Me.barFluidPiping.Text = "Fluid Piping"
        '
        'barFluidPipingOpen
        '
        Me.barFluidPipingOpen.Name = "barFluidPipingOpen"
        Me.barFluidPipingOpen.Size = New System.Drawing.Size(152, 22)
        Me.barFluidPipingOpen.Text = "Open Drawing"
        '
        'barFluidPipingSave
        '
        Me.barFluidPipingSave.Name = "barFluidPipingSave"
        Me.barFluidPipingSave.Size = New System.Drawing.Size(152, 22)
        Me.barFluidPipingSave.Text = "Save Drawing"
        '
        'barConvert
        '
        Me.barConvert.Image = Global.Rae.RaeSolutions.My.Resources.Resources.ConvertToEquipment
        Me.barConvert.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barConvert.Name = "barConvert"
        Me.barConvert.Size = New System.Drawing.Size(124, 22)
        Me.barConvert.Text = "Convert to Rating"
        '
        'SaveToolStripPanel1
        '
        Me.SaveToolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SaveToolStripPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SaveToolStripPanel1.Name = "SaveToolStripPanel1"
        Me.SaveToolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.SaveToolStripPanel1.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.SaveToolStripPanel1.Size = New System.Drawing.Size(695, 0)
        '
        'EquipmentForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(695, 570)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.tabEquipment)
        Me.Controls.Add(Me.SaveToolStripPanel1)
        Me.Controls.Add(Me.equipmentMenuStrip)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuStrip = Me.equipmentMenuStrip
        Me.MinimumSize = New System.Drawing.Size(560, 523)
        Me.Name = "EquipmentForm"
        Me.Text = "Pricing"
        CType(Me.selectedOpsDs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.orderReportErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.submittalReportErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPricing.ResumeLayout(False)
        Me.tabPricing.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        ''CType(Me.multiplierCodeAppliedPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCoil.ResumeLayout(False)
        Me.pnlCoil.PerformLayout()
        Me.tabOptionsSummary.ResumeLayout(False)
        Me.panOptionsSummary.ResumeLayout(False)
        CType(Me.selectedOpGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panSpecialOptionsSummary.ResumeLayout(False)
        CType(Me.specialOpGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panSelectedOptions.ResumeLayout(False)
        CType(Me.standardOpGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAvailableOptions.ResumeLayout(False)
        Me.availableOptionsPanel.ResumeLayout(False)
        Me.optionToolbarPanel.ResumeLayout(False)
        CType(Me.availableOpGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabModel.ResumeLayout(False)
        Me.specsHeaderPanel.ResumeLayout(False)
        Me.pricingPanel.ResumeLayout(False)
        Me.pricingPanel.PerformLayout()
        Me.modelPanel.ResumeLayout(False)
        Me.modelPanel.PerformLayout()
        Me.tabEquipment.ResumeLayout(False)
        Me.tabSpecialOptions.ResumeLayout(False)
        Me.equipmentMenuStrip.ResumeLayout(False)
        Me.equipmentMenuStrip.PerformLayout()
        CType(Me.equipmentErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


#Region " Constants"
    Protected Const methodName_SetControlValues As String = "SetControlValues"
    Protected Const methodName_GetControlValues As String = "GetControlValues"

    Protected Const price_format As String = "$#0"
#End Region





#Region " Declarations"

    Private isLoaded As Boolean
    Protected is_opening As Boolean
    Private _savedState As EquipmentItem
    Friend specsControl As Control

    ' can't use typed datatable outside of datset, DA.OptionsDS.EquipmentOptionDataTable
    Friend WithEvents availableOpTable As New DataTable("AvailableOptions")
    Private WithEvents selectedOpTable As New DataTable("SelectedOptions")
    Protected pricingAuthorized As Boolean

    ' condensing unit order write up validation manager
    Friend orderReportValidationManager As ValidationManager
    Friend submittalValidationMgr As ValidationManager
    Private equipmentValidationManager As ValidationManager
    Private WithEvents seriesVCtrl As ValidationControl
    Private WithEvents modelVCtrl As ValidationControl

    Private unitQuantityVCtrl As ValidationControl

    Private _refreshProject As Boolean = True
    Private m_project As ProjectItem
    Private _equipmentType As EquipmentType
    Private m_division As Division
    Private fourYearCompressorWarrantyPromptHasBeenShownAlready As Boolean
    Private fourYearCompressorWarrantySuggestionEnabled As Boolean = True


    Protected opening As command
    Protected convertToProcess As command(Of ProcessItem)

    Delegate Sub LoadEngineeringDataSignature(ByVal unit As EquipmentItem)
    Protected loadEngineeringData As LoadEngineeringDataSignature

#End Region


#Region " Properties"

    ''' <summary>Gets the specs control for the equipment type.</summary>
    ''' <param name="equipType">Equipment type</param>
    Private Function buildSpecsControl(ByVal equipType As EquipmentType) As UserControl
        Dim specs = createSpecsControl()
        specs.Name = "SpecsControl"

        Return specs
    End Function

    Protected Overridable Function createSpecsControl() As UserControl
        Dim specs As UserControl

        Select Case Equipment.type
            Case Business.EquipmentType.CondensingUnit
                specs = New CondensingUnitSpecsControl
            Case Business.EquipmentType.FluidCooler
                specs = New FluidCoolerSpecsControl
            Case Business.EquipmentType.ProductCooler
                specs = New ProductCoolerSpecsControl
            Case Else
                Throw New ArgumentException("There is no specifications control associated with the equipment type, " & Equipment.type.ToString & ".")
        End Select

        Return specs
    End Function

    Protected Overridable Sub onOpSelected(ByVal code As String, ByVal description As String)
    End Sub

    Private _equipment As EquipmentItem
    Property Equipment As EquipmentItem
        Get
            Return _equipment
        End Get
        Set(ByVal value As EquipmentItem)
            _equipment = value
        End Set
    End Property

    ''' <summary>The last saved state of equipment</summary>
    ''' <remarks>Save and open automatically set the current equipment to the last saved state</remarks>
    Property LastSavedState As EquipmentItem
        Get
            Return _savedState
        End Get
        Set(ByVal value As EquipmentItem)
            '  _savedState = value
            _savedState = InvokeMethod(Of EquipmentItem)(Equipment, "Clone")
        End Set
    End Property

#End Region


#Region " Public methods"

    Public mnu_order_write_up As ToolStripItem

    Sub Open(ByVal equipment As EquipmentItem)






        is_opening = True

        If opening IsNot Nothing Then _
           opening.Invoke()

        ' displays values in controls (display first so dependent common options will price)
        Me.displayEquipment(equipment)

        ' sets saved state (used to determine if changes have been made)
        Me.LastSavedState = InvokeMethod(Of EquipmentItem)(Me.grabEquipment(), "Clone")
        ' If a project is not open, name changed handler can't be added.
        If OpenedProject.IsOpened Then
            ' adds event handler for equipment name changed
            Me.addHandlerForEquipmentNameChanged()
        Else
            ' waits until equipment is saved to add handler
        End If
        alertUserAbout(Me.Equipment.obsolete_options)
        ' clears obsolete options so that user can save and no longer receive this message
        Me.Equipment.obsolete_options.Clear()

        If equipment.type = EquipmentType.CondensingUnit AndAlso AppInfo.Division = TSI Then
            txtStartUp.Text = "Not Inc."
            If user.is_rep Then
                txtStartUp.ReadOnly = True
            Else
                txtStartUp.ReadOnly = False
            End If
        End If

        HandleStartup()

        'blargg
        Dim contractor As String = "Yes"

        If AppInfo.User.works_at_resco Then
            contractor = "No"
        Else
            Dim connection = New OleDbConnection(ConnectionString.Text)
            Dim command = connection.CreateCommand
            Dim rdr As IDataReader

            Try
                Dim strSQL As String = "SELECT [Contractor] FROM [Table1] WHERE User_Name = '" & AppInfo.User.username.ToString & "'"

                command.CommandText = strSQL
                command.Connection = connection
                connection.Open()

                rdr = command.ExecuteReader()

                If rdr.Read Then
                    If rdr("Contractor").ToString() = "False" Then
                        contractor = "No"
                    Else
                        contractor = "Yes"
                    End If
                End If

            Catch ex As Exception
                contractor = "Yes"
            Finally
                If Not rdr Is Nothing Then rdr.Close()
                command.Dispose()
                connection.Dispose()
            End Try
        End If

        If contractor = "Yes" Then
            lblCommissionRateLabel.Visible = False
            lblCommissionPriceLabel.Visible = False
            lblPricingParMultiplier.Visible = False
            lblParPrice.Visible = False
            lblCommissionPrice.Visible = False
            lblCommissionRate.Visible = False
            cboParMultiplier.Visible = False
            NumericUpDown1.Visible = False
            lblPricingParMultiplier.Visible = False
            lblPricingParPrice.Visible = False

            Label2.Visible = False
            Label3.Visible = False

            overrideBaseListText.Visible = False
            overrideBaseListLabel.Visible = False
            overrideBaseListCheck.Visible = False
            txtOverrideBaseListPerUnit.Visible = False

            applyMultiplierCodeButton.Visible = False
            multiplierCodeTextBox.Visible = False
            multiplierCodeLabel.Visible = False
        End If

        is_opening = False

        opened()
    End Sub


    Private Sub HandleStartup()

        If Equipment.type = EquipmentType.Chiller AndAlso AppInfo.Division = TSI Then

            If Not String.IsNullOrEmpty(Equipment.series) AndAlso Equipment.series.StartsWith("35E2") Then
                txtStartUp.Text = "$5,500"
            Else
                txtStartUp.Text = "$4,500"
            End If

            If user.is_rep Then
                txtStartUp.ReadOnly = True
            Else
                txtStartUp.ReadOnly = False
            End If
        End If

    End Sub


    Protected Overridable Sub opened()

    End Sub

#End Region


#Region " Private methods"


#Region " Event handling"

    Private Sub form_Activated(ByVal sender As Object, ByVal e As EventArgs) _
    Handles Me.Activated
        Me.initializeSaveToolStripPanel()
        Me.SaveToolStripPanel1.Merge()
    End Sub

    Private Sub form_Deactivate(ByVal sender As Object, ByVal e As EventArgs) _
    Handles Me.Deactivate
        Me.SaveToolStripPanel1.Unmerge()
    End Sub

    Private Sub form_Load() Handles MyBase.Load
        If DesignMode Then Exit Sub
        Me.isLoaded = False

        Me.initializeSaveToolStripPanel()

        ' sets form height to fit height of container
        Me.Size = New Size(Me.Size.Width, Ui.FormEditor.MaximizeHeight(Me))
        Me.Top = 0

        ' populates multipliers and commission rates combobox
        populateMultipliersAndCommissionRates()

        setColors()
        Me.initializeValidation()

        authorize()

        EquipmentSelector1.User = user
        EquipmentSelector1.EquipmentType = Me.Equipment.type.ToString()

        addAndFormatSpecsControl()

        addAdditionalefrigerants()

        Me.SpecialOptionsControl1.Initialize(Equipment.id, user.username)

        AddHandler AppInfo.Main.RevisionView1.RevisionChanged, _
           AddressOf RevisionView_RevisionChanged

        CustomizeFormForTSI()

        ModifyVoltageOptions()



        Me.isLoaded = True

    End Sub

    <DebuggerStepThrough()> _
    Private Sub form_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) _
    Handles Me.Paint
        If Not Me.Equipment Is Nothing _
        AndAlso Me.Equipment.type = EquipmentType.FluidCooler _
        AndAlso Me.Equipment.RatingEquipment IsNot Nothing Then
            Dim fc As FluidCooler = CType(Me.Equipment.RatingEquipment, FluidCooler)
            Me.LoadFluidCoolerData(fc.FluidCoolerSeries.ModelSeries, fc.ModelNumber.ToString)
        End If
    End Sub

    Friend Sub onFormClosing(ByVal s As Object, ByVal e As FormClosingEventArgs)
        ' gets values from controls
        Dim currentEquipment As EquipmentItem = Me.grabEquipment

        Dim saveSuccess As Boolean = True

        ' checks if needs to be saved
        If Me.isSaved(currentEquipment) Then
            ' no changes have been made allow closing to finish
        Else
            Dim result As DialogResult
            Dim saveForm As New SaveOnCloseForm()

            ' gets user's save selection
            saveForm.ShowDialog()

            Select Case saveForm.SaveSelection
                Case SaveOnCloseForm.UserSelection.Save
                    saveSuccess = Me.save()
                Case SaveOnCloseForm.UserSelection.SaveAsRevision
                    saveSuccess = Me.saveAsRevision()
                Case SaveOnCloseForm.UserSelection.DoNotSave
                    ' closes without saving
                Case SaveOnCloseForm.UserSelection.Cancel
                    ' cancels close and exits method
                    e.Cancel = True : Exit Sub
                Case Else
                    Throw New ApplicationException("Invalid save option.")
            End Select
            saveForm.Close()
        End If

        If saveSuccess = True Then
            Me.Equipment.ForceSave = False
            Me.removeHandlerForEquipmentNameChanged()
            RemoveHandler AppInfo.Main.RevisionView1.RevisionChanged, AddressOf RevisionView_RevisionChanged
        Else
            e.Cancel = True
        End If

    End Sub


    ''' <summary>
    ''' Handles equipment name changed event. Updates form's title.
    ''' </summary>
    ''' <history by="Casey Joyce" finish="2006/08/04">
    ''' Added
    ''' </history>
    Private Sub Equipment_NameChanged(ByVal sender As ItemBase, ByVal e As EventArgs)
        ' updates the form's title
        Me.Text = sender.name
        ' prevents the name being incorrectly overriden by the previous name of the equipment
        Me.Equipment.name = sender.name
        ' prevents asking the user to save even if no changes were made (except the name change)
        Me.LastSavedState.name = sender.name
    End Sub


    ''' <summary>
    ''' Adds handler for equipment name changed event.
    ''' </summary>
    Private Sub addHandlerForEquipmentNameChanged()
        For Each equip As EquipmentItem In OpenedProject.Manager.Equipment
            If equip.id.Id = Me.Equipment.id.Id Then
                AddHandler equip.NameChanged, AddressOf Equipment_NameChanged
                Exit For
            End If
        Next
    End Sub

    Private Sub CustomizeFormForTSI()
        If AppInfo.Division = TSI Then
            barSubmittal.Visible = False
            mnuSubmittal.Visible = False
        End If




    End Sub


    Private Sub ModifyVoltageOptions()

        '  6/27/14
        Dim currentItem As String = ""

        If Not cboUnitVoltage.SelectedItem Is Nothing Then
            currentItem = cboUnitVoltage.SelectedItem.ToString
        End If


        If Equipment.type = Nothing Then
            cboUnitVoltage.Items.Clear()
            Exit Sub
        End If

        If Equipment.type = EquipmentType.Condenser Then
            cboUnitVoltage.Items.Clear()
            cboUnitVoltage.Items.Add("460/3/60")
            cboUnitVoltage.Items.Add("230/3/60")
        ElseIf Equipment.type = EquipmentType.PumpPackage Then  ' proabably not needed as this control is not used for PPs.  Must modify cboUnitVoltage in spec control.
            cboUnitVoltage.Items.Clear()
            cboUnitVoltage.Items.Add("460/3/60")
            cboUnitVoltage.Items.Add("230/3/60")
            cboUnitVoltage.Items.Add("208/3/60")
            cboUnitVoltage.Items.Add("230/1/60")
            cboUnitVoltage.Items.Add("208/1/60")
            cboUnitVoltage.Items.Add("115/1/60")
        ElseIf Equipment.type = EquipmentType.Chiller Then
            cboUnitVoltage.Items.Clear()
            cboUnitVoltage.Items.Add("460/3/60")
            cboUnitVoltage.Items.Add("230/3/60")
            cboUnitVoltage.Items.Add("208/3/60")
            cboUnitVoltage.Items.Add("460/1/60")
            cboUnitVoltage.Items.Add("230/1/60")
            cboUnitVoltage.Items.Add("208/1/60")
            cboUnitVoltage.Items.Add("115/1/60")
        ElseIf Equipment.type = EquipmentType.ProductCooler Then
            cboUnitVoltage.Items.Clear()
            cboUnitVoltage.Items.Add("460/3/60")
            cboUnitVoltage.Items.Add("230/3/60")
            cboUnitVoltage.Items.Add("208/3/60")
            ' cboUnitVoltage.Items.Add("460/1/60")
            ' cboUnitVoltage.Items.Add("230/1/60")
            ' cboUnitVoltage.Items.Add("208/1/60")
            ' cboUnitVoltage.Items.Add("115/1/60")
        ElseIf Equipment.type = EquipmentType.CondensingUnit Then
            If AppInfo.Division = CRI Then

                ' add base, remove later
                cboUnitVoltage.Items.Clear()


                If Equipment.model Is Nothing OrElse String.IsNullOrEmpty(Equipment.model) Then
                    cboUnitVoltage.Items.Clear()

                    cboUnitVoltage.Items.Add("460/3/60")
                    cboUnitVoltage.Items.Add("230/3/60")
                    cboUnitVoltage.Items.Add("208/3/60")
                    cboUnitVoltage.Items.Add("575/3/60")
                    cboUnitVoltage.Items.Add("460/1/60")
                    cboUnitVoltage.Items.Add("230/1/60")
                    cboUnitVoltage.Items.Add("208/1/60")

                Else
                    ' read base voltages from databases for each model.  Remove some later based on hard coded rules
                    cboUnitVoltage.Items.Clear()

                    Dim voltageOptions As List(Of String) = getVoltageOptionsByModel(Equipment.model)


                    'Put 575 last.  Right now, 575 should be first in the last.  If this changes, you'll need to modify the below.
                    If voltageOptions.Count > 1 Then
                        For l As Integer = 1 To voltageOptions.Count - 1
                            cboUnitVoltage.Items.Add(voltageOptions(l))
                        Next
                    End If

                    If voltageOptions.Count > 0 Then
                        cboUnitVoltage.Items.Add(voltageOptions(0))
                    End If

                End If

                If Equipment.series = Nothing OrElse String.IsNullOrEmpty(Equipment.series) OrElse Not (Equipment.series.ToUpper.StartsWith("N") OrElse Equipment.series.ToUpper = "DM") Then
                    For i As Integer = 0 To cboUnitVoltage.Items.Count - 1
                        If CType(cboUnitVoltage.Items(i), String) = "575/3/60" Then cboUnitVoltage.Items.RemoveAt(i) : Exit For
                    Next
                End If

                If cboUnitVoltage.SelectedText = "575/3/60" Then
                    'lock option ev01
                End If

                If Not Equipment.series = Nothing AndAlso (Equipment.series.ToUpper = "LUO" OrElse Equipment.series.ToUpper = "LUI") Then

                    For i As Integer = 0 To cboUnitVoltage.Items.Count - 1
                        If CType(cboUnitVoltage.Items(i), String) = "460/1/60" Then cboUnitVoltage.Items.RemoveAt(i) : Exit For
                    Next

                    If Not Equipment.model Is Nothing Then
                        Dim h1 As String = Equipment.model.Substring(3, Equipment.model.IndexOf(".") - 3)

                        If h1 = "6" OrElse h1 = "7" OrElse h1 = "7" OrElse h1 = "9" Then
                            For i As Integer = 0 To cboUnitVoltage.Items.Count - 1
                                If CType(cboUnitVoltage.Items(i), String) = "230/1/60" Then cboUnitVoltage.Items.RemoveAt(i) : Exit For
                            Next
                            For i As Integer = 0 To cboUnitVoltage.Items.Count - 1
                                If CType(cboUnitVoltage.Items(i), String) = "208/1/60" Then cboUnitVoltage.Items.RemoveAt(i) : Exit For
                            Next
                        End If
                    End If
                End If


                If Not Equipment.series = Nothing AndAlso (Equipment.series.ToUpper = "DD" OrElse Equipment.series.ToUpper = "DS" OrElse Equipment.series.ToUpper = "DM" OrElse Equipment.series.ToUpper = "NSB" OrElse Equipment.series.ToUpper = "NDB" OrElse Equipment.series.ToUpper = "NSC" OrElse Equipment.series.ToUpper = "NDC" OrElse Equipment.series.ToUpper = "NMC" OrElse Equipment.series.ToUpper = "NMB" OrElse Equipment.series.ToUpper = "NSF" OrElse Equipment.series.ToUpper = "NDF") Then
                    For i As Integer = 0 To cboUnitVoltage.Items.Count - 1
                        If CType(cboUnitVoltage.Items(i), String) = "208/1/60" Then cboUnitVoltage.Items.RemoveAt(i) : Exit For
                    Next
                    For i As Integer = 0 To cboUnitVoltage.Items.Count - 1
                        If CType(cboUnitVoltage.Items(i), String) = "230/1/60" Then cboUnitVoltage.Items.RemoveAt(i) : Exit For
                    Next
                    For i As Integer = 0 To cboUnitVoltage.Items.Count - 1
                        If CType(cboUnitVoltage.Items(i), String) = "460/1/60" Then cboUnitVoltage.Items.RemoveAt(i) : Exit For
                    Next
                End If






            ElseIf AppInfo.Division = TSI Then

                cboUnitVoltage.Items.Add("460/3/60")
                cboUnitVoltage.Items.Add("230/3/60")
                cboUnitVoltage.Items.Add("208/3/60")

            End If

        Else
            cboUnitVoltage.Items.Clear()    ' unit coolers will go here, even though they do not have a nit voltage.
            cboUnitVoltage.Items.Add("460/3/60")
            cboUnitVoltage.Items.Add("230/3/60")
            cboUnitVoltage.Items.Add("208/3/60")
            cboUnitVoltage.Items.Add("575/3/60")
            cboUnitVoltage.Items.Add("460/1/60")
            cboUnitVoltage.Items.Add("230/1/60")
            cboUnitVoltage.Items.Add("208/1/60")
            cboUnitVoltage.Items.Add("115/1/60")
        End If













        ' reselect if possible

        If Not String.IsNullOrEmpty(currentItem) Then
            Dim it As Integer = cboUnitVoltage.Items.IndexOf(currentItem)
            If it >= 0 Then cboUnitVoltage.SelectedIndex = it
        End If


    End Sub



    ''' <summary>Removes handler for equipment name changed event.</summary>
    ''' <remarks>
    ''' Handler must be removed otherwise when form opens again, the handler will be registered again,
    ''' and the event handler method will be called multiple times.
    ''' </remarks>
    Private Sub removeHandlerForEquipmentNameChanged()
        ' if there is not an open project then the equipment was never saved, so it can't be renamed
        If Not OpenedProject.IsOpened Then Exit Sub

        For Each equip As EquipmentItem In OpenedProject.Manager.Equipment
            If equip.id.Id = Me.Equipment.id.Id Then
                RemoveHandler equip.NameChanged, AddressOf Equipment_NameChanged
            End If
        Next
    End Sub


    ''' <summary>
    ''' Handles revision view control's revision changed event.
    ''' If user has unsaved changes, asks user to save before navigating revisions.
    ''' </summary>
    Private Sub RevisionView_RevisionChanged(ByVal sender As RevisionView, ByVal e As ValueChangedEventArgs(Of Single))
        If sender.ActiveProcessForm Is Me Then
            Me.promptUserToSaveBeforeNavigation(e.BeforeValue, e.AfterValue)
        End If
    End Sub


#Region " Combobox events"

    Protected Overridable Sub onModelChanged(ByVal unit As EquipmentItem)
        Dim ctrl = EquipmentSelector1
        If Not ctrl.IsCompleted Then Exit Sub

        onModelChanged_price(unit)
        loadEngineeringData.Invoke(unit)
        onModelChanged_updateOps()


        set_rla_and_mca_for_evaporative_condenser_chiller()


        HandleStartup()

        ModifyVoltageOptions()

        If unit.type = EquipmentType.UnitCooler Then
            FaceVelocityInRange()
        End If
    End Sub

    Private Sub loadEngineeringDataFor(ByVal unit As EquipmentItem)
        Dim series = unit.series
        Dim model = unit.model_without_series

        Select Case unit.type
            Case EquipmentType.CondensingUnit
                loadCondensingUnitData(Me.EquipmentSelector1.Equipment)
            Case EquipmentType.FluidCooler
                LoadFluidCoolerData(series, model)
        End Select
    End Sub

    Protected Sub onModelChanged_price(ByVal unit As EquipmentItem)
        Me.Cursor = Cursors.WaitCursor

        Dim ctrl = EquipmentSelector1
        Dim price, totalPrice As Double

        Try
            price = EquipmentOptionsAgent.OptionsDA.RetrieveBaseListPrice(ctrl.Series, ctrl.Model)
            totalPrice = Intelligence.PriceCalculator.CalculateTotalBaseListPrice(price, grabUnitQuantity)
        Catch ex As System.ApplicationException
            ' price not found
            Ui.MessageBox.Show(ex.Message)
            ' TODO: encapsulate reset logic
            ' ensures Choose is an option
            If Not Me.EquipmentSelector1.cbo_model.Items.Contains(Me.EquipmentSelector1.choose) Then
                Me.EquipmentSelector1.cbo_model.Items.Insert(0, Me.EquipmentSelector1.choose)
            End If
            ' sets equipment price to zero
            Me.displayPrice(Me.lblBaseListPrice, 0)
            Me.displayTotalBaseListPrice(0)

            availableOpGrid.RemoveAll()
            ' selects Choose
            Me.EquipmentSelector1.cbo_model.SelectedIndex = _
               Me.EquipmentSelector1.cbo_model.Items.IndexOf(Me.EquipmentSelector1.choose)
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try

        'Equipment.Series = ctrl.Series
        'Equipment.Model = ctrl.Model

        ' displays results
        Me.displayPrice(lblBaseListPrice, price)
        Me.displayTotalBaseListPrice(totalPrice)
    End Sub

    Protected Sub onModelChanged_updateOps()
        If validateOptionRetrievalInputs() Then
            reselectOpsAfterModelOrVoltageChange()
            ' resets options total price since the options change when the model changes
            displayTotalOptionsPrice(0, 0)
        Else
            availableOpGrid.RemoveAll()
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub EquipmentSelector1_BeforeModelChanged(ByVal sender As EquipmentSelector, ByRef e As System.ComponentModel.CancelEventArgs) _
    Handles EquipmentSelector1.BeforeModelChanged
        If EquipmentSelector1.Series Like "35E2*" _
        And Not EquipmentSelector1.Model = String.Empty _
        And Not EquipmentSelector1.Model = "Choose" Then
            Dim chiller = CType(grabEquipment(), chiller_equipment)
            Dim cancel = notify_user_that_balance_data_will_be_cleared(chiller)
            e.Cancel = cancel
        End If
    End Sub

    Private Function notify_user_that_balance_data_will_be_cleared(ByVal chiller As chiller_equipment) As Boolean
        Dim cancel = False

        If chiller.has_balance Then
            Dim pop_up As i_confirm = New pop_up()
            Dim confirmed = pop_up.confirm("Changing the chiller model or voltage invalidates electrical data from the associated balance (such as amps from non-standard compressor selection). If this change is made then standard components will be used to determine electrical data regardless of previous selections in balance." & _
                                           NewLine & NewLine & _
                                           "Do you want to change the model and discard electrical data?", _
                                           confirm_text:="Change Model", cancel_text:="Do Not Change Model")
            If confirmed Then
                chiller.has_balance = False
                chiller.balance_data.clear()
                chiller.common_specs.Rla.set_to_null()
                chiller.common_specs.Mca.set_to_null()
            Else ' cancel
                cancel = True
            End If
        End If

        Return cancel
    End Function

    Class pop_up : Implements i_confirm
        Function confirm(ByVal message As String, ByVal confirm_text As String, ByVal decline_text As String) As Boolean _
        Implements i_confirm.confirm
            Dim result = System.Windows.Forms.MessageBox.Show(message, "RAESolutions", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = Forms.DialogResult.Yes Then
                Return True
            Else
                Return False
            End If
        End Function
    End Class

    Interface i_confirm
        Function confirm(ByVal message As String, ByVal confirm_text As String, ByVal cancel_text As String) As Boolean
    End Interface



    Private Sub model_Changed(ByVal s As EquipmentSelector, ByVal selectedModel As String) _
    Handles EquipmentSelector1.ModelChanged
        Equipment.series = s.Series
        Equipment.model_without_series = s.Model

        onModelChanged(Equipment)
    End Sub

    ''' <summary>Handles equipment series before change</summary>
    Private Sub EquipmentSelector1_SeriesChanged(ByVal sender As EquipmentSelector, ByRef e As System.ComponentModel.CancelEventArgs) Handles EquipmentSelector1.BeforeSeriesChanged

        If EquipmentSelector1.previous_series Like "35E2*" _
        And Not EquipmentSelector1.Model = String.Empty _
        And Not EquipmentSelector1.Model = "Choose" Then
            Dim chiller = CType(grabEquipment(), chiller_equipment)
            Dim cancel = notify_user_that_balance_data_will_be_cleared(chiller)
            e.Cancel = cancel
            If cancel Then Exit Sub
        End If



        If EquipmentSelector1.Series.ToUpper = "HPC" OrElse EquipmentSelector1.Series.ToUpper = "VPC" Then
            If Me.GetType.Name = "product_cooler_pricing_screen" Then
                CType(Me.specsControl, ProductCoolerSpecsControl).SetBlowerDischarge(EquipmentSelector1.Series.ToUpper)
            End If
        End If

        ' checks if a model is selected before changing series. if a model is selected, 
        '  then the user needs to be alerted that if the series change continues their options will be removed
        '  but if a model is not selected, then there can be no options already selected so don't alert user
        If Me.EquipmentSelector1.Model = String.Empty _
        OrElse selectedOpGrid.RowCount = 0 Then
            Exit Sub
        End If

        ' messages user that options will be lost
        Dim result = Forms.MessageBox.Show("Due to the option list's dependency on the selected series, changes to the series require the option list to be cleared." & _
           System.Environment.NewLine & "Do you want to change series?", "RAESolutions", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            availableOpGrid.RemoveAll()
        Else
            e.Cancel = True
            Exit Sub
        End If




        If EquipmentSelector1.Series Like "35E2*" _
        And Not EquipmentSelector1.Model = String.Empty _
        And Not EquipmentSelector1.Model = "Choose" Then
            Dim chiller = CType(grabEquipment(), chiller_equipment)
            Dim cancel = notify_user_that_balance_data_will_be_cleared(chiller)
            e.Cancel = cancel
        End If
    End Sub



    ''Private Sub availableOpGrid_Grouped() Handles availableOpGrid.GroupedByCategory
    ''    If groupLink.IsToggled Then _
    ''       groupLink.Toggle()
    ''End Sub

    ''Private Sub availableOpGrid_Ungrouped() Handles availableOpGrid.Ungrouped
    ''    If Not groupLink.IsToggled Then _
    ''       groupLink.Toggle()
    ''End Sub

    ''' <summary>Handles PAR multiplier change</summary>
    Private Sub cboParMultiplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles cboParMultiplier.SelectedIndexChanged

        If Me.isLoaded Then
            Dim parPrice, commissionPrice, othersPrice, nfspPrice As Double

            ' calculates par price
            parPrice = Intelligence.PriceCalculator.CalculateParPrice(Me.grabPrice(Me.lblSummaryTotalListPrice), Me.GrabParMultiplier())
            ' calculates commission price (grabs commission rate from par combobox selected value)
            commissionPrice = Intelligence.PriceCalculator.CalculateCommissionPrice(Me.GrabCommissionRate(), parPrice)

            ' calculates others (freight, warranty, startup, other) price
            othersPrice = Intelligence.PriceCalculator.CalculateTotalOtherPrice(Me.grabPrice(Me.txtFourYearCompressorWarranty), Me.grabPrice(Me.txtFreight), Me.grabPrice(Me.txtStartUp), Me.grabPrice(Me.txtOther))
            ' calculates nfsp
            nfspPrice = Intelligence.PriceCalculator.CalculateNfspPrice(parPrice, othersPrice)


            ' displays PAR price
            Me.displayPrice(Me.lblParPrice, parPrice)
            ' displays commission rate
            Me.displayPercent(Me.lblCommissionRate, Me.GrabCommissionRate())
            ' displays commission price
            Me.displayPrice(Me.lblCommissionPrice, commissionPrice)
            ' displays nfsp price
            Me.displayPrice(Me.lblNfsp, nfspPrice)
        End If
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        If Me.isLoaded Then
            Dim parPrice, commissionPrice, othersPrice, nfspPrice As Double

            ' calculates par price
            parPrice = Intelligence.PriceCalculator.CalculateParPrice(Me.grabPrice(Me.lblSummaryTotalListPrice), CDbl(NumericUpDown1.Value))

            Dim commissionRate As Double = 0.0
            If Not ddCentury.SelectedItem Is Nothing Then
                If ddCentury.SelectedItem.ToString() = "Resco" Then
                    Dim multiplier As Double = CDbl(NumericUpDown1.Value)
                    Dim baseListPrice As Double = CDbl(lblSummaryTotalListPrice.Text)
                    If multiplier <= 0.281 Then
                        commissionRate = 0.0
                    ElseIf multiplier > 0.281 And multiplier < 0.3194 Then
                        commissionRate = 3.13316 * multiplier - 0.880418
                    ElseIf multiplier > 0.3193 Then
                        Dim num As Double = (((baseListPrice * multiplier) - (baseListPrice * 0.3193)) / 2) + (0.12 * (baseListPrice * 0.3193))
                        Dim den As Double = (baseListPrice * multiplier)
                        commissionRate = num / den
                    End If
                Else
                    Dim multiplier As Double = CDbl(NumericUpDown1.Value)
                    Dim baseListPrice As Double = CDbl(lblSummaryTotalListPrice.Text)
                    If multiplier <= 0.29 Then
                        commissionRate = 0.0
                    ElseIf multiplier > 0.29 And multiplier < 0.3296 Then
                        commissionRate = 2.85714286 * multiplier - 0.8214
                    ElseIf multiplier > 0.3295 Then
                        Dim num1 As Double = (((baseListPrice * multiplier) - (baseListPrice * 0.3295)) / 2) + (0.12 * (baseListPrice * 0.3295))
                        Dim den1 As Double = (baseListPrice * multiplier)
                        commissionRate = num1 / den1
                    End If
                End If
            Else
                Return
            End If

            ' calculates commission price (grabs commission rate from par combobox selected value)
            commissionPrice = Intelligence.PriceCalculator.CalculateCommissionPrice(commissionRate, parPrice)

            ' calculates others (freight, warranty, startup, other) price
            othersPrice = Intelligence.PriceCalculator.CalculateTotalOtherPrice(Me.grabPrice(Me.txtFourYearCompressorWarranty), Me.grabPrice(Me.txtFreight), Me.grabPrice(Me.txtStartUp), Me.grabPrice(Me.txtOther))
            ' calculates nfsp
            nfspPrice = Intelligence.PriceCalculator.CalculateNfspPrice(parPrice, othersPrice)


            ' displays PAR price
            Me.displayPrice(Me.lblParPrice, parPrice)
            ' displays commission rate
            Me.displayPercent(Me.lblCommissionRate, commissionRate)
            ' displays commission price
            Me.displayPrice(Me.lblCommissionPrice, commissionPrice)
            ' displays nfsp price
            Me.displayPrice(Me.lblNfsp, nfspPrice)
        End If
    End Sub

    Friend isAlreadySyncing As Boolean
    Private voltage_change_canceled As Boolean = False
    ''' <summary>Handles unit voltage changed</summary>
    Private Sub cboUnitVoltage_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles cboUnitVoltage.SelectedIndexChanged
        Static voltage As Integer

        If Not isAlreadySyncing Then
            If Equipment.type = EquipmentType.Chiller _
            AndAlso EquipmentSelector1.IsCompleted _
            AndAlso Equipment.series Like "35E2*" _
            AndAlso voltage <> 0 Then
                If voltage_change_canceled Then
                    voltage_change_canceled = False
                    Exit Sub
                End If

                Dim chiller = CType(Equipment, chiller_equipment)
                Dim cancel = notify_user_that_balance_data_will_be_cleared(chiller)
                If cancel Then
                    For i As Integer = 0 To cboUnitVoltage.Items.Count - 1
                        If cboUnitVoltage.Items(i).ToString Like voltage & "*" Then
                            voltage_change_canceled = True
                            cboUnitVoltage.SelectedIndex = i
                            Exit For
                        End If
                    Next
                    Exit Sub
                End If
            End If
            syncUnitVoltage()
        End If

        Dim newVoltage As Integer

        ' parses voltage
        newVoltage = CInt(Me.parseVoltage(Me.GrabUnitVoltage))
        ' determines whether voltage changed, if voltage didn't change then don't update options
        If voltage = newVoltage Then Exit Sub
        ' sets voltage to new voltage
        voltage = newVoltage

        If Not Me.validateOptionRetrievalInputs() Then Exit Sub
        ' populates available options so that only correct voltages are listed
        ' re-selects voltage dependent option codes, but with new voltage
        Me.reselectOpsAfterModelOrVoltageChange()

        set_rla_and_mca_for_evaporative_condenser_chiller()
    End Sub

    Protected Sub set_rla_and_mca_for_evaporative_condenser_chiller()
        Dim unit = Equipment

        With unit

            If .model Like "35*" Then
                Dim chiller = CType(unit, chiller_equipment)
                Dim electrical = New Rae.solutions.evaporative_condenser_chillers.electrical_data(chiller)
                .common_specs.Rla.set_to(electrical.circuit_1.rla)
                .common_specs.Mca.set_to(electrical.circuit_1.mca)
                If electrical.circuits.Count > 1 Then
                    Dim chiller_specs_control = CType(Me.specsControl, chiller_specs_control)
                    Dim common_specs_control = chiller_specs_control.panCommonSpecs
                    Dim txt_rla_2 = common_specs_control.Controls("txt_rla_2")
                    txt_rla_2.Text = electrical.circuits(1).rla.ToString()
                    Dim txt_mca_2 = common_specs_control.Controls("txt_mca_2")
                    txt_mca_2.Text = electrical.circuits(1).mca.ToString()
                Else
                    Dim chiller_specs_control = CType(Me.specsControl, chiller_specs_control)
                    Dim common_specs_control = chiller_specs_control.panCommonSpecs
                    Dim txt_rla_2 = common_specs_control.Controls("txt_rla_2")
                    txt_rla_2.Text = ""
                    Dim txt_mca_2 = common_specs_control.Controls("txt_mca_2")
                    txt_mca_2.Text = ""
                End If
                CType(specsControl, chiller_specs_control).SetControlValues(chiller)

            ElseIf .model Like "20*" Then
                Dim cUnit = CType(unit, CondensingUnitEquipmentItem)

                Dim specsControl As CondensingUnitSpecsControl = CType(Me.specsControl, CondensingUnitSpecsControl)

                Dim voltage As String
                If specsControl.cboUnitVoltage.SelectedItem Is Nothing Then
                    voltage = ""
                Else
                    voltage = specsControl.cboUnitVoltage.SelectedItem.ToString
                End If



                If Not String.IsNullOrEmpty(voltage) AndAlso voltage.Contains("/") Then
                    voltage = voltage.Substring(0, voltage.IndexOf("/"))
                    Dim model As String = cUnit.model

                    Dim tMCA, tRLA, tMOP, powerFeeds As String

                    getElectricalForConUnit(model, voltage, tMCA, tRLA, tMOP, powerFeeds)

                    If String.IsNullOrEmpty(tMCA) Then
                        cUnit.specs.mca.set_to_null()
                    Else
                        cUnit.specs.mca.set_to(tMCA)
                    End If

                    If String.IsNullOrEmpty(tRLA) Then
                        cUnit.specs.rla.set_to_null()
                    Else
                        cUnit.specs.rla.set_to(tRLA)
                    End If


                    If String.IsNullOrEmpty(tMOP) Then
                        cUnit.specs.mop.set_to_null()
                        .common_specs.MOP.set_to_null()
                    Else
                        cUnit.specs.mop.set_to(tMOP)
                        .common_specs.MOP.set_to(tMOP)
                    End If


                    If String.IsNullOrEmpty(powerFeeds) Then
                        .common_specs.powerFeeds.set_to_null()
                    Else
                        .common_specs.powerFeeds.set_to(powerFeeds)
                    End If



                Else
                    cUnit.specs.mca.set_to_null()
                    cUnit.specs.rla.set_to_null()
                    cUnit.specs.mop.set_to_null()
                    .common_specs.powerFeeds.set_to_null()
                    .common_specs.MOP.set_to_null()

                End If






                CType(specsControl, CondensingUnitSpecsControl).SetControlValues(cUnit)
                '  cUnit()
            End If

        End With
    End Sub



    Private Function getVoltageOptionsByModel(ByVal model As String) As List(Of String)

        getVoltageOptionsByModel = New List(Of String)

        Dim comprModel As String = getCompressor1ByModel(model)

        If String.IsNullOrEmpty(comprModel) Then Exit Function

        Dim connection = Common.CreateConnection(Common.CompressorDbPath)
        Dim command = connection.CreateCommand()
        Dim sql As String

        Dim compModel As String

        '        sql = "select distinct voltage, phase, frequency from Electrical where MasterID = '" & comprModel & "' and model_type = 'Condenser' order by phase desc, voltage desc"
        sql = "select distinct voltage, phase, frequency from Electrical where MasterID = '" & comprModel & "' AND FREQUENCY = 60 and VOLTAGE In ('208','230','460','575') order by phase desc, voltage desc"
        command.CommandText = sql
        Dim reader As IDataReader
        Try
            connection.Open()
            reader = command.ExecuteReader()

            While reader.Read



                '   compModel = reader("comprfile_1").ToString
                getVoltageOptionsByModel.Add(reader("voltage").ToString & "/" & reader("phase").ToString & "/" & reader("frequency").ToString)
            End While

        Catch EX As Exception
            MsgBox(EX.Message)
        Finally
            If reader IsNot Nothing Then _
               reader.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try





    End Function


    Private Function getNumberOfFansForCondUnit(ByVal model As String) As Integer
        Dim connection = Common.CreateConnection(Common.CondensingUnitDbPath)
        Dim command = connection.CreateCommand()
        Dim sql As String

        Dim FanQTY1 As Integer
        Dim FanQTY2 As Integer

        sql = "select fanqty_1,  fanqty_2  from table5 where model = '" & model & "'"
        command.CommandText = sql
        Dim reader As IDataReader
        Try
            connection.Open()
            reader = command.ExecuteReader()

            If reader.Read Then
                If Not Integer.TryParse(reader("FanQTY_1").ToString, FanQTY1) Then FanQTY1 = 0
                If Not Integer.TryParse(reader("FanQTY_2").ToString, FanQTY2) Then FanQTY2 = 0
                '                FanQTY = reader("FanQTY")
            Else
                FanQTY1 = 0
                FanQTY2 = 0
            End If

        Catch
            FanQTY1 = 0
            FanQTY2 = 0
        Finally
            If reader IsNot Nothing Then _
               reader.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try

        Return FanQTY1 + FanQTY2

    End Function




    Private Function getCompressor1ByModel(ByVal model As String) As String
        Dim connection = Common.CreateConnection(Common.CondensingUnitDbPath)
        Dim command = connection.CreateCommand()
        Dim sql As String

        Dim compModel As String

        sql = "select CompressorMasterID1 from table5 where model = '" & model & "'"
        command.CommandText = sql
        Dim reader As IDataReader
        Try
            connection.Open()
            reader = command.ExecuteReader()

            If reader.Read Then
                compModel = reader("CompressorMasterID1").ToString
            Else
                compModel = ""
            End If

        Catch
            compModel = ""
        Finally
            If reader IsNot Nothing Then _
               reader.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try

        If String.IsNullOrEmpty(compModel) Then
            Return ""
        Else
            Return compModel
        End If

    End Function


    Private Sub getElectricalForConUnit(ByVal model As String, ByVal voltage As String, ByRef MCA As String, ByRef RLA As String, ByRef MOP As String, ByRef powerFeeds As String)
        Dim connection = Common.CreateConnection(Common.CondensingUnitDbPath)
        Dim command = connection.CreateCommand()
        Dim sql As String

        If voltage = "230" Then voltage = "208"

        sql = "select MCA_" & voltage & ", RLA_" & voltage & ", MOP_" & voltage & ", [" & voltage & "V Power Feeds] from table5 where model = '" & model & "'"
        command.CommandText = sql
        Dim reader As IDataReader
        Try
            connection.Open()
            reader = command.ExecuteReader()

            If reader.Read Then
                MCA = reader("MCA_" & voltage).ToString
                RLA = reader("RLA_" & voltage).ToString
                MOP = reader("MOP_" & voltage).ToString
                powerFeeds = reader(voltage & "V Power Feeds").ToString
            Else
                MCA = ""
                RLA = ""
                MOP = ""
                powerFeeds = ""
            End If

        Catch
            MCA = ""
            RLA = ""
            MOP = ""
            powerFeeds = ""
        Finally
            If reader IsNot Nothing Then _
               reader.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try

    End Sub


    Private Sub txtUnitQuantity_TextChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles txtUnitQuantity.TextChanged
        ' gets and displays quantity
        Dim unitQuantity As Integer
        unitQuantity = Me.grabUnitQuantity()
        Me.displayQuantity(unitQuantity)

        ' gets base list price from control
        Dim baseListPrice As Double
        baseListPrice = Me.grabPrice(Me.lblBaseListPrice)

        ' calculates and displays total base list price
        Dim totalBaseListPrice As Double
        totalBaseListPrice = Intelligence.PriceCalculator.CalculateTotalBaseListPrice(baseListPrice, unitQuantity)
        Me.displayTotalBaseListPrice(totalBaseListPrice)
    End Sub


    Private Sub overrideBaseListCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles overrideBaseListCheck.CheckedChanged

        If overrideBaseListCheck.Checked AndAlso (String.IsNullOrEmpty(txtOverrideBaseListPerUnit.Text) Or txtOverrideBaseListPerUnit.Text = "$0") Then
            txtOverrideBaseListPerUnit.Text = CStr(Me.grabPrice(Me.lblBaseListPrice))
            overrideBaseListText.Text = lblSummaryBaseListPrice.Text
        End If

        If overrideBaseListCheck.Checked = False Then
            txtOverrideBaseListPerUnit.Text = ""
            overrideBaseListText.Text = "$0"
        End If


        Me.txtOverrideBaseListPerUnit.ReadOnly = Not Me.overrideBaseListCheck.Checked
        calculateAndDisplayPrices()
    End Sub


    'Private Sub overrideBaseListText_Leave(ByVal sender As Object, ByVal e As EventArgs) _
    'Handles overrideBaseListText.Leave
    '    Try
    '        displayPrice(overrideBaseListText, grabBaseList())
    '        calculateAndDisplayPrices()
    '    Catch ex As Exception
    '        Ui.MessageBox.Show("Invalid format for price", MessageBoxIcon.Warning)
    '    End Try
    'End Sub

#End Region


#Region " Grid events"

    ''' <summary>Handles available options selections and deselections. Performs additional logic for options
    ''' that have dependents or are dependents.</summary>
    Private Sub availableOpTable_ColumnChanging(ByVal s As Object, ByVal e As DataColumnChangeEventArgs) _
    Handles availableOpTable.ColumnChanging
        Me.Cursor = Cursors.WaitCursor  'hits on auto select

        ' checks if column changing is the Selected column
        If e.Column.ColumnName = OCol.Selected Then
            ' checks if option is being selected
            If CBool(e.ProposedValue) = True Then
                ' is being selected
                handleSelectAvailableOp(e)
            Else
                ' is not being selected
                handleDeselectAvailableOp(e)
            End If
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub availableOpTable_Cleared(ByVal s As Object, ByVal e As DataTableClearEventArgs) _
    Handles availableOpTable.TableCleared
        ' notifies user that model and voltage are required to populate options
        lblNoOptions.Visible = True
    End Sub

    ''' <summary>Handles availableOptionsTable's ColumnChanged event. 
    ''' Adds selected option to selected options grid, or removes deselected option from selected options grid.</summary>
    Private Sub availableOpTable_ColumnChanged(ByVal s As Object, ByVal e As DataColumnChangeEventArgs) _
    Handles availableOpTable.ColumnChanged
        ' checks if Selected column changed
        If e.Column.ColumnName = OCol.Selected Then  ' hits on auto select
            ' checks if an option was selected
            If CBool(e.Row(OCol.Selected)) Then
                ' check for suction accumulator
                If e.Row(OCol.Code).ToString() = "MA01" Or e.Row(OCol.Code).ToString() = "MA02" Or e.Row(OCol.Code).ToString() = "MA17" Or
                    e.Row(OCol.Code).ToString() = "MF04" Or e.Row(OCol.Code).ToString() = "MF05" Then
                    For Each row As DataRow In availableOpTable.Rows
                        If row(OCol.Code).ToString() = "MV06" Then
                            row(OCol.Selected) = True
                        End If
                    Next
                End If

                ' option was selected
                askUserForOptionQuantity(e.Row)
                ' copies option from available options grid to selected options grid
                selectedOpGrid.Add(e.Row)
            Else
                ' deselect suction accumulator
                If e.Row(OCol.Code).ToString() = "MV06" Then
                    For Each row As DataRow In availableOpTable.Rows
                        If CBool(row(OCol.Selected)) Then
                            If row(OCol.Code).ToString() = "MA01" Or row(OCol.Code).ToString() = "MA02" Or row(OCol.Code).ToString() = "MA17" Or
                                row(OCol.Code).ToString() = "MF04" Or row(OCol.Code).ToString() = "MF05" Then
                                MessageBox.Show("'MV06 - Suction Vibrasorber - Mounted' option is required when any suction accumulator or suction filter options are selected.")
                                row(OCol.Selected) = True
                                Return
                            End If
                        End If
                    Next
                End If

                ' lock option codes --- dakotal
                If e.Row(OCol.Code).ToString() = "EM09" And getFanMotorPhase() = 1 Then
                    MessageBox.Show("'EM09 - ECM Fan Motor(s)' option is required when a single phase fan voltage is selected.")
                    e.Row(OCol.Selected) = True
                    Return
                End If

                If e.Row(OCol.Code).ToString() = "EV01" And cboUnitVoltage.SelectedItem.ToString() = "575/3/60" Then
                    MessageBox.Show("'EV01 - 575/60/30 Voltage Unit w/Control Circuit Transformer' option is required when a 575/3/60 unit voltage is selected.")
                    e.Row(OCol.Selected) = True
                    Return
                End If

                If e.Row(OCol.Code).ToString() = "MA01" Or e.Row(OCol.Code).ToString() = "MA02" Or e.Row(OCol.Code).ToString() = "MA17" Or
                    e.Row(OCol.Code).ToString() = "MF04" Or e.Row(OCol.Code).ToString() = "MF05" Then
                    For Each row As DataRow In availableOpTable.Rows
                        If row(OCol.Code).ToString() = "MV06" Then
                            row(OCol.Selected) = False
                        End If
                    Next
                End If
                ' option was deselected
                selectedOpGrid.Remove(e.Row)
            End If
        ElseIf e.Column.ColumnName = OCol.Quantity Then
            ' update selected options grid
            Dim quantity = CInt(e.Row(OCol.Quantity))
            Dim pricingId = CInt(e.Row(OCol.ID))

            'selectedOptions.WithId(pricingId).Quantity = quantity
            For i As Integer = 0 To selectedOpTable.Rows.Count - 1
                If CInt(selectedOpTable.Rows(i)(OCol.ID)) = pricingId Then
                    selectedOpTable.Rows(i)(OCol.Quantity) = quantity
                    Exit For
                End If
            Next
        End If
    End Sub


    Private Sub selectedOpTable_RowChanged(ByVal s As Object, ByVal e As DataRowChangeEventArgs) _
    Handles selectedOpTable.RowChanged
        Dim prices As OptionBreakDown = calculateTotalOptionsPrice()
        Me.displayTotalOptionsPrice(prices.AvailableOptionsPricePerUnit, prices.CommonOptionsPrice)
    End Sub


    Private Sub selectedOpTable_ColumnChanged(ByVal s As Object, ByVal e As DataColumnChangeEventArgs) _
    Handles selectedOpTable.ColumnChanged
        Dim prices As OptionBreakDown = calculateTotalOptionsPrice()
        Me.displayTotalOptionsPrice(prices.AvailableOptionsPricePerUnit, prices.CommonOptionsPrice)
        syncOptionQuantities(e)
    End Sub


    Private Sub syncOptionQuantities(ByVal e As DataColumnChangeEventArgs)
        For Each op As DataRow In availableOpTable.Rows
            If CInt(op(OCol.ID)) = CInt(e.Row(OCol.ID)) _
            AndAlso CInt(op(OCol.Quantity)) <> CInt(e.Row(OCol.Quantity)) Then
                op(OCol.Quantity) = e.Row(OCol.Quantity)
                Exit For
            End If
        Next
    End Sub

#End Region


#Region " Validation events"

    Private Sub equipmentSelector1_SeriesChanged(ByVal sender As EquipmentSelector, ByVal selectedSeries As String) Handles EquipmentSelector1.SeriesChanged

        If Me.isLoaded Then
            ' validates series validation control
            Me.seriesVCtrl.Validate()
            With Me.Equipment.common_specs
                .Length.set_to_null()
                .Width.set_to_null()
                .Height.set_to_null()
                .ShippingWeight.set_to_null()
                .OperatingWeight.set_to_null()
            End With
            ' sets control values
            Dim equip = If(is_opening, Me.Equipment, grabEquipment)
            InvokeMethod(Me.specsControl, Me.methodName_SetControlValues, equip)
        End If
    End Sub

    Private Sub equipmentSelector1_ModelChanged(ByVal sender As EquipmentSelector, ByVal selectedLine As String)
        If Me.isLoaded Then _
           Me.modelVCtrl.Validate()
    End Sub

    Private Sub seriesVCtrl_Validating(ByVal sender As ValidationControl) Handles seriesVCtrl.Validating
        ' checks whether series combobox has an item selected
        If Not Me.IsItemSelected(CType(sender.ControlToValidate, ComboBox)) _
        OrElse CType(sender.ControlToValidate, ComboBox).SelectedItem.ToString = Me.EquipmentSelector1.choose Then
            sender.ErrorMessages.Add("Series combobox must have a selection.") : End If
    End Sub

    Private Sub modelVCtrl_Validating(ByVal sender As ValidationControl) Handles modelVCtrl.Validating
        ' checks whether series combobox has an item selected
        If Not Me.IsItemSelected(CType(sender.ControlToValidate, ComboBox)) _
        OrElse CType(sender.ControlToValidate, ComboBox).SelectedItem.ToString = Me.EquipmentSelector1.choose Then
            sender.ErrorMessages.Add("Model combobox must have a selection.") : End If
    End Sub

    Private Sub txtUnitQuantity_Leave(ByVal sender As Object, ByVal e As EventArgs)
        Me.unitQuantityVCtrl.Validate()
    End Sub

#End Region


#Region " Menu events"

    ''' <summary>Handles close menu item click</summary>
    Private Sub closeMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mnuClose.Click
        Me.Close()
    End Sub


    ''' <summary>Handles save menu item click</summary>
    Private Sub saveMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mnuSave.Click
        Me.save()
    End Sub


    ''' <summary>
    ''' Handles save as menu item click event.
    ''' Copies equipment and saves using name chosen by user.
    ''' </summary>
    Private Sub saveAsMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mnuSaveAs.Click
        Me.saveAs()
    End Sub


    ''' <summary>
    ''' Handles save as revision menu item click event.
    ''' Saves equipment and sets its revision level as the latest.
    ''' </summary>
    Private Sub saveAsRevisionMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mnuSaveAsRevision.Click

        If OpenedProject.IsOpened Then
            saveAsRevision(user.is(owner))
        Else
            saveAsRevision()
        End If

    End Sub


    ''' <summary>Handles order entry order write up report menu clicked</summary>
    Private Sub orderWriteUpMenuItem_Click()
        Dim junk As String = ""

        onViewOrderWriteUp(False, junk)
    End Sub


    ''' <summary>Handles submittal accessories report menu clicked</summary>
    Private Sub submittalMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mnuSubmittal.Click, barSubmittal.Click


        If Me.EquipmentSelector1.Series = "AWSM" AndAlso Not FaceVelocityInRange() Then
            Me.tabEquipment.SelectedIndex = 0
            Exit Sub
        End If

        If Me.EquipmentSelector1.Series = "A" AndAlso Not FaceVelocityInRange() Then
            Me.tabEquipment.SelectedIndex = 0
            Exit Sub
        End If

        Dim returnTab As Integer
        If Not CheckObligatoryOptionsAndSpecs(returnTab) Then
            Me.tabEquipment.SelectedIndex = returnTab
            Exit Sub
        End If




        Dim junk As String = ""
        onViewSubmittal(False, junk)
    End Sub

    Private Sub convertToProcessMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mnuConvert.Click, barConvert.Click, mnuConvert.Click
        If Not OpenedProject.IsOpened Then
            Ui.MessageBox.Show("A project is not open. A project must be opened before performing a conversion.", MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim proc = convertToProcess.Invoke

        If proc IsNot Nothing Then
            OpenedProject.Manager.Processes.Add(proc)
            OpenedProject.Manager.Processes.Items(proc.id).Save()
            ProjectInfo.Viewer.ViewProcess(proc)
        Else
            Ui.MessageBox.Show("No process exists for this equipment. ")
        End If

    End Sub

    Private Function convertToProcessItem() As ProcessItem
        Dim proc As ProcessItem
        Dim unit = grabEquipment()

        Select Case Equipment.type
            Case EquipmentType.CondensingUnit
                proc = New CondensingUnitProcessItem(CType(unit, CondensingUnitEquipmentItem))




            Case EquipmentType.FluidCooler
                Dim fcEQ As FluidCoolerEquipmentItem = CType(Me.Equipment, FluidCoolerEquipmentItem)
                If Not fcEQ.Process Is Nothing Then
                    If fcEQ.Process.FluidCooler Is Nothing Then
                        If Not Me.Equipment.RatingEquipment Is Nothing Then
                            fcEQ.Process.FluidCooler = CType(Me.Equipment.RatingEquipment, FluidCooler)
                        Else
                            fcEQ.Process.FluidCooler = FluidCooler.Populate(Me.Equipment.model_without_series)
                        End If
                    End If
                    proc = fcEQ.Process

                Else
                    Dim fcproc As New FluidCoolerProcessItem
                    fcproc.Series = Me.Equipment.series
                    fcproc.Model = Me.Equipment.model_without_series
                    fcproc.ProjectManager = OpenedProject.Manager
                    fcproc.id = New item_id(ProjectInfo.NewItemID(Me.Equipment.id.Id))
                    fcproc.FluidCooler = FluidCooler.Populate(Me.Equipment.series, Me.Equipment.model_without_series)
                    proc = fcproc
                End If
        End Select

        Return proc
    End Function

    Private Function controls_are_not_valid_to_show_unit_drawing() As Boolean
        If Equipment.type = EquipmentType.UnitCooler Then
            Dim specs = CType(specsControl, UnitCoolerSpecsControl)
            Dim fan_voltage_is_selected = specs.fanVoltageCombo.SelectedItem IsNot Nothing
            Dim defrost_voltage_is_selected = specs.defrostVoltageCombo.SelectedItem IsNot Nothing
            Dim has_electric_defrost = Equipment.model.EndsWith("E")


            Dim refrigerant_chosen As Boolean = Not specs.cboRefrigerant.SelectedItem Is Nothing

            Dim validator = New fan_and_defrost_voltage_are_required_for_unit_cooler_drawing(fan_voltage_is_selected, has_electric_defrost, defrost_voltage_is_selected, refrigerant_chosen)
            If validator.validate().is_invalid Then
                warn(validator.messages.toString())
                tabEquipment.SelectTab(tabModel)
                specs.fanVoltageCombo.Focus()
                Return True
            End If
        End If
        Return False
    End Function



    Private Sub DoSaveAsDrawing(ByVal file1 As String)
        Dim dlg As New SaveFileDialog

        Dim desktop = GetFolderPath(SpecialFolder.Desktop)


        dlg.InitialDirectory = desktop
        dlg.FileName = Path.GetFileName(file1)
        dlg.DefaultExt = ".dxf" ' Default file extension
        dlg.Filter = "DXF Files (.dxf)|*.dxf" ' Filter files by extension

        ' Show open file dialog box
        Dim result As Boolean = CBool(dlg.ShowDialog())

        ' Process open file dialog box results
        If result = True Then
            ' Open document
            Dim newFilename As String = dlg.FileName


            If file1.ToLower <> newFilename.ToLower Then File.Copy(file1, newFilename)


            'My.Settings("DefaultPath") = Path.GetDirectoryName(newFilename) & "\"
            'My.Settings.Save()


        End If
    End Sub

    Private Sub unitDrawingMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles mnuUnitDrawing.Click, barUnitDrawingsOpen.Click, barUnitDrawingsSave.Click
        If controls_are_not_valid_to_show_unit_drawing() Then Exit Sub

        Dim time = Stopwatch.StartNew

        Common.IsCountingConnections = True

        Try
            'Dim previewForm As New PreviewDrawingForm()
            Dim unit_drawing = New UnitDrawing(grabEquipment(True), Constants.TARGET_USER_GROUP)

            If unit_drawing.validators.validate().is_invalid Then
                warn(unit_drawing.validators.messages.toString)
            End If

            If MainForm.currentLogo = "" Then
                If user.can(choose_report_logo) Then

                    Dim logo As String = New which_division().ask({"TSI", "Century", "RSI", "RAE"})
                    unit_drawing.DivisionName = logo

                    '                unit_drawing.DivisionName = "RAE"
                End If
            End If


            Dim drawingFileName As String = ""



            Dim senderObj As ToolStripMenuItem = CType(sender, ToolStripMenuItem)


            Dim openDrawing As Boolean

            If senderObj.Name = "barUnitDrawingsSave" Then
                openDrawing = False
            Else
                openDrawing = True
            End If

            Dim returnDrawingNames As New List(Of String)

            If MainForm.openReport = False Then
                'If Not unit_drawing.Show(returnDrawingNames, openDrawing, MainForm.openReport, True) Then ' - commented this out because of a report generation issue
                If Not unit_drawing.Show(returnDrawingNames, openDrawing, MainForm.openReport, False) Then
                    inform("Unit drawings are currently unavailable for selected model (" & Me.Equipment.ToString() & ").")
                End If
            Else
                If Not unit_drawing.Show(returnDrawingNames, openDrawing) Then
                    inform("Unit drawings are currently unavailable for selected model (" & Me.Equipment.ToString() & ").")
                End If
            End If

            If senderObj.Name = "barUnitDrawingsSave" Then
                Try
                    For Each file1 As String In returnDrawingNames
                        DoSaveAsDrawing(file1)
                    Next
                Catch ex As Exception
                    MsgBox("An error occurred while saving drawing.")
                End Try

            End If





        Catch ex As Exception
            warn("The drawing cannot be created. " & ex.Message)
        End Try

        log("Number of database connections to open drawing: " & Common.NumConnections.ToString)
        Common.IsCountingConnections = False
        Common.NumConnections = 0

        log("Time to open unit drawing: " & time.Elapsed.TotalSeconds.ToString)
    End Sub

    Private Sub pipingDrawingMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles mnuRefrigerantPiping.Click, barRefrigerantPipingOpen.Click, barRefrigerantPipingSave.Click
        If Not controls_are_valid_for_piping_drawing() Then
            tabEquipment.SelectTab(tabModel)
            Me.specsControl.Controls("txtSuctionTemp").Focus()
            Ui.MessageBox.Show("The suction temperature is required to generate condensing unit drawings.")
            Exit Sub
        End If

        Dim timer = Stopwatch.StartNew

        Dim pipingDrawing = New RefrigerantPipingDrawing(Me.grabEquipment(includePumpOpsForChiller:=True), Constants.TARGET_USER_GROUP)


        Dim openDrawing As Boolean

        Dim senderObj As ToolStripMenuItem = CType(sender, ToolStripMenuItem)


        If senderObj.Name = "barRefrigerantPipingSave" Then
            openDrawing = False
        Else
            openDrawing = True
        End If


        If MainForm.currentLogo = "" Then
            If user.can(choose_report_logo) Then

                Dim logo As String = New which_division().ask({"TSI", "Century", "RSI", "RAE"})
                pipingDrawing.DivisionName = logo

                '                unit_drawing.DivisionName = "RAE"
            End If
        End If


        Dim returnDrawingNames As New List(Of String)


        If Not pipingDrawing.Show(returnDrawingNames, openDrawing) Then
            warn("Piping drawings are currently unavailable for selected model, " & _
                  Me.Equipment.ToString & ".")
        End If


        If senderObj.Name = "barRefrigerantPipingSave" Then
            Try
                For Each file1 As String In returnDrawingNames
                    DoSaveAsDrawing(file1)
                Next
            Catch ex As Exception
                MsgBox("An error occurred while saving drawing.")
            End Try

        End If



        log("Time to open piping drawing: " & timer.Elapsed.TotalSeconds.ToString)
    End Sub

    Private Sub mnuFluidPiping_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFluidPiping.Click, barFluidPipingOpen.Click, barFluidPipingSave.Click
        Dim unit = grabEquipment(includePumpOpsForChiller:=True)
        Dim drawing = New FluidPipingDrawing(unit, Constants.TARGET_USER_GROUP)
        Try

            Dim senderObj As ToolStripMenuItem = CType(sender, ToolStripMenuItem)


            Dim openDrawing As Boolean

            If senderObj.Name = "barFluidPipingSave" Then
                openDrawing = False
            Else
                openDrawing = True
            End If


            Dim returnDrawingNames As New List(Of String)


            If Not drawing.Show(returnDrawingNames, openDrawing) Then
                warn("Fluid piping drawings are not available for selected model, " & unit.ToString() & ".")
            End If



            If senderObj.Name = "barFluidPipingSave" Then
                Try
                    For Each file1 As String In returnDrawingNames
                        DoSaveAsDrawing(file1)
                    Next
                Catch ex As Exception
                    MsgBox("An error occurred while saving drawing.")
                End Try

            End If



        Catch ex As Exception
            alert(ex.Message)
        End Try
    End Sub

    Private Function controls_are_valid_for_piping_drawing() As Boolean
        Dim isValid = True

        ' if condensing unit require suction temp to be entered
        If TypeOf Me.Equipment Is CondensingUnitEquipmentItem Then
            isValid = Not String.IsNullOrEmpty(Me.specsControl.Controls("txtSuctionTemp").Text)
        End If

        Return isValid
    End Function

    Private Sub log(ByVal message As String)
        My.Application.Log.WriteEntry(message)
    End Sub

    Private Sub reportsToolStripSplitButton_ButtonClick(ByVal sender As Object, ByVal e As EventArgs) _
    Handles barReports.ButtonClick, barDrawings.ButtonClick
        DirectCast(sender, ToolStripSplitButton).ShowDropDown()
    End Sub

#End Region


    ''' <summary>
    ''' Handles event raised when special options total price changed.
    ''' </summary>
    ''' <history by="Casey Joyce" finish="2006/06/05">
    ''' Added</history>
    Private Sub specialOptionsTotalPrice_Changed(ByVal sender As SpecialOptionsControl, ByVal totalPrice As Double)

        ' sets special options total price on pricing tab
        Me.displayPrice(Me.totalSpecialOptionsPriceLabel, totalPrice * Me.grabUnitQuantity())
        ' sets special options total price per unit on option summary tab
        Me.displayPrice(Me.lblSpecialOptionsSummaryTotalPrice, totalPrice)
    End Sub


    ''' <summary>
    ''' Handles special options grid data source changed event.
    ''' Synchronizes special options grids on summary and special options tabs.
    ''' </summary>
    Private Sub SpecialOptionsControl_DataSourceChanged(ByVal s As SpecialOptionsControl, ByVal e As EventArgs)

        specialOpGrid.DataSource = s.opGrid.DataSource
        specialOpGrid.ApplyStyle()
    End Sub

    Private Sub tabEquipment_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles tabEquipment.SelectedIndexChanged

        Static previousTab As String = "tabModel"

        If cboUnitVoltage.Text.Trim > " " Then
            If Me.Equipment.series = "DD" Or Me.Equipment.series = "DM" Or Me.Equipment.series = "DS" Or Me.Equipment.series Like "2*" Or Me.Equipment.series Like "3*" Or Me.Equipment.series Like "4*" Or Me.Equipment.series = "LUI" Or Me.Equipment.series = "LUO" Or Me.Equipment.series = "RS" Or Me.Equipment.series Like "N*" Or Me.Equipment.series Like "BLU*" Then
                chkFourYearCompressorWarranty.Enabled = True
                Label1.Enabled = True
            Else
                chkFourYearCompressorWarranty.Enabled = False
                Label1.Enabled = False
                txtFourYearCompressorWarranty.Text = "Unavailable"
            End If
        Else
            chkFourYearCompressorWarranty.Enabled = False
            Label1.Enabled = False
            txtFourYearCompressorWarranty.Text = "Unavailable"
        End If

        If fourYearCompressorWarrantySuggestionEnabled And Not fourYearCompressorWarrantyPromptHasBeenShownAlready And previousTab = "tabAvailableOptions" _
        And chkFourYearCompressorWarranty.Enabled = True And chkFourYearCompressorWarranty.Checked = False Then
            SuggestFourYearCompressorWarranty()
        End If

        If Me.tabEquipment.SelectedTab.Name = "tabModel" Then

            previousTab = "tabModel"

            ' available options
        ElseIf Me.tabEquipment.SelectedTab.Name = "tabAvailableOptions" Then

            Dim returnTab As Integer
            If Not CheckObligatoryOptionsAndSpecs(returnTab) Then
                Me.tabEquipment.SelectedIndex = returnTab
                Exit Sub

            End If

            ' displays/hides options are unavailable note
            Me.lblNoOptions.Visible = Not Me.validateOptionRetrievalInputs()

            availableOpGrid.SetColumnWidths()

            previousTab = "tabAvailableOptions"

            ' special options
        ElseIf Me.tabEquipment.SelectedTab.Name = "tabSpecialOptions" Then
            previousTab = "tabSpecialOptions"

            ' options summary
        ElseIf Me.tabEquipment.SelectedTab.Name = "tabOptionsSummary" Then
            selectedOpGrid.ApplyStyle()

            ' displays total price of selected options
            Dim prices As OptionBreakDown = Me.calculateTotalOptionsPrice()
            Me.displayTotalOptionsPrice(prices.AvailableOptionsPricePerUnit, prices.CommonOptionsPrice)

            previousTab = "tabOptionsSummary"

            ' pricing
        ElseIf Me.tabEquipment.SelectedTab.Name = "tabPricing" Then

            'If Me.EquipmentSelector1.Series = "AWSM" AndAlso Not FaceVelocityInRange() Then
            '    Me.tabEquipment.SelectedIndex = 0
            '    dsfgsdfg()
            '    Exit Sub
            'End If
            'If Me.EquipmentSelector1.Series = "A" AndAlso Not FaceVelocityInRange() Then
            '    Me.tabEquipment.SelectedIndex = 0
            '    sdfgsdfg()
            '    Exit Sub
            'End If


            Dim returnTab As Integer
            If Not CheckObligatoryOptionsAndSpecs(returnTab) Then
                Me.tabEquipment.SelectedIndex = returnTab
                Exit Sub

            End If

            ' selects a different column to raise the column changed event in the data table to commit changes
            ' effectively, when quantity is being edited and the tab index changes, the pricing updates (before it didn't)
            ''Me.selectedOpGrid.Columns = 1

            'calculates and displays prices on pricing tab
            Me.calculateAndDisplayPrices()

            previousTab = "tabPricing"

        End If

    End Sub

    Public Function FaceVelocityInRange() As Boolean
        Dim faceVelocity As Double = CType(Equipment, unit_cooler).FaceVelocity


        'ERICC2021

        Dim evaporatorTemp As String
        Dim evaporatorTempValue As Double
        Dim specs = CType(specsControl, UnitCoolerSpecsControl)

        If specs.txtEvaporatorTemp.Text = "" Then Return True
        If specs.txtUnitCapacity.Text = "" Then Return True

        'If Not Me.EquipmentSelector1.Series.ToUpper.StartsWith("A") Then Return True


        evaporatorTemp = specs.txtEvaporatorTemp.Text

        If String.IsNullOrEmpty(evaporatorTemp) OrElse Not IsNumeric(evaporatorTemp) Then
            evaporatorTempValue = 0
        Else
            evaporatorTempValue = Double.Parse(evaporatorTemp)
        End If




        Dim faceVelocityFlag As Boolean = False
        Dim faceVelocityMessage As String = ""

        'ERICC2021
        If (Me.EquipmentSelector1.Model.EndsWith("A") AndAlso faceVelocity > 625) OrElse (evaporatorTempValue >= 25 AndAlso faceVelocity > 625) Then
            If AppInfo.User.authority_group = user_group.employee Then
                faceVelocityFlag = False  ' Employees can select
                MsgBox("Face Velocity is Out of Range.")
            Else
                ' reps can select certain unit coolers up to 700 as long as suction >= 25
                If (EquipmentSelector1.Series.ToUpper.StartsWith("AWSM") OrElse EquipmentSelector1.Series.ToUpper.StartsWith("E") OrElse EquipmentSelector1.Series.ToUpper.StartsWith("A") OrElse EquipmentSelector1.Series.ToUpper = "BOC") AndAlso (faceVelocity <= 700) Then
                    faceVelocityFlag = False
                    MsgBox("Face Velocity is Out of Range.")
                Else
                    faceVelocityFlag = True
                    MsgBox("Face Velocity is Out of Range. You cannot proceed with pricing.")
                End If
            End If
        End If

        Return Not faceVelocityFlag



    End Function


    Public Function CheckObligatoryOptionsAndSpecs(ByRef returnTab As Integer) As Boolean


        If Not Me.EquipmentSelector1.Series Is Nothing AndAlso Me.EquipmentSelector1.Series.ToUpper.StartsWith("AWSM") Then
            If getFanMotorPhase() = 0 Then
                MsgBox("Please Select a fan voltage")
                returnTab = 0
                Return False
            End If
        End If

        If Not Me.EquipmentSelector1.Series Is Nothing AndAlso Me.EquipmentSelector1.Series.ToUpper.StartsWith("A") Then
            If getFanMotorPhase() = 0 Then
                MsgBox("Please Select a fan voltage")
                returnTab = 0
                Return False
            End If
        End If


        returnTab = 1


        ' Special Code for Chiller Kit
        Dim selectedOptions As New List(Of String)
        For Each r As DataRow In Me.selectedOpTable.Rows
            selectedOptions.Add(r("Code").ToString.ToUpper)
        Next

        If (selectedOptions.Contains("CK01") AndAlso selectedOptions.Contains("MF01") AndAlso Not selectedOptions.Contains("CK02")) _
            OrElse _
            (selectedOptions.Contains("CK01") AndAlso selectedOptions.Contains("MF02") AndAlso Not selectedOptions.Contains("CK02")) Then




            For Each r As DataRow In availableOpTable.Rows
                If r("Code").ToString.ToUpper = "CK02" Then
                    r("Selected") = True
                    MsgBox("Option code CK02 is required when both a CHILLER KIT and FLOOD CONTROL are selected.  This option will be automatically selected")

                    ' selectedOpTable.ImportRow(r)
                    Exit For
                End If
            Next



        End If


        Dim fanMotorPhase As Integer = getFanMotorPhase()
        Dim series As String = Me.EquipmentSelector1.Series
        If series = "BALV" Or series = "WIBR" Or series = "AWSM" Or series = "A" Then
            If fanMotorPhase = 1 Then
                For Each r As DataRow In availableOpTable.Rows
                    If r("Code").ToString.ToUpper = "EM09" Then
                        r("Selected") = True
                        Exit For
                    End If
                Next
            End If
        End If


        If series = "BLU-L" OrElse series = "BLU-B" Then
            If (selectedOptions.Contains("MA02") OrElse selectedOptions.Contains("MA17") OrElse selectedOptions.Contains("MA01") OrElse selectedOptions.Contains("MF04") OrElse selectedOptions.Contains("MF05")) AndAlso Not selectedOptions.Contains("MV06") Then




                For Each r As DataRow In availableOpTable.Rows
                    If r("Code").ToString.ToUpper = "MV06" Then
                        r("Selected") = True
                        MsgBox("Option code MV06 (Suction Vibrasorber) is required when any suction filter or accumulator option is selected.  This option will be automatically selected")
                        ' selectedOpTable.ImportRow(r)
                        Exit For
                    End If
                Next


            End If

        End If


        ' return true if all obligatory options selected

        Dim obligatoryOptions As List(Of String) = EquipmentOptionsAgent.OptionsDA.GetObligatoryOptionsBySeries(Me.EquipmentSelector1.Series)


        If obligatoryOptions.Count < 1 Then Return True


        ' first check to see if the obligatory options even exist for the model.

        Dim obligatoryOptionIsChoosble As Boolean = False




        For Each row As DataRow In Me.availableOpTable.Rows
            If obligatoryOptions.Contains(row("Category").ToString.ToLower) Then
                obligatoryOptionIsChoosble = True
            End If
        Next

        If Not obligatoryOptionIsChoosble Then Return True

        For Each row As DataRow In Me.selectedOpTable.Rows
            If obligatoryOptions.Contains(row("Category").ToString.ToLower) Then
                Return True
            End If

        Next


        MsgBox("Please Select an option from the group: " & obligatoryOptions(0))
        Return False

    End Function



    ''' <summary>
    ''' Handles cost textbox leave events.
    ''' Calculates prices.
    ''' </summary>
    Private Sub txtOthers_Leave(ByVal sender As Object, ByVal e As EventArgs) _
    Handles txtFreight.Leave, txtFourYearCompressorWarranty.Leave, txtStartUp.Leave, txtOther.Leave

        Dim nfsp As Double
        Dim othersTotalPrice As Double
        Try
            ' calculates total others price
            othersTotalPrice = Intelligence.PriceCalculator.CalculateTotalOtherPrice(Me.grabPrice(Me.txtFourYearCompressorWarranty), Me.grabPrice(Me.txtFreight), Me.grabPrice(Me.txtStartUp), Me.grabPrice(Me.txtOther))
            ' calculates nfsp
            nfsp = Intelligence.PriceCalculator.CalculateNfspPrice(Me.grabPrice(Me.lblParPrice), othersTotalPrice)
            ' displays nfsp
            Me.displayPrice(Me.lblNfsp, nfsp)

            ' formats entered
            Dim textB As TextBox = CType(sender, TextBox)
            Me.displayPrice(textB, Me.grabPrice(textB))
        Catch ex As Exception
            Ui.MessageBox.Show("Invalid format of price.", MessageBoxIcon.Warning)
        End Try
    End Sub


    Public Sub onViewOrderWriteUp(ByVal generateOnly As Boolean, ByRef fileName As String, Optional ByVal showReport As Boolean = False, Optional ByVal logo As String = "")
        ParentForm.Cursor = Cursors.WaitCursor
        Try
            calculateAndDisplayPrices()

            If showReport Then
                presenter.ViewOrderWriteUp(generateOnly, fileName, True)
            Else
                presenter.ViewOrderWriteUp(generateOnly, fileName)
            End If

        Catch ex As Exception
            alert("Attempt to view order write up report failed. " & ex.Message)
        Finally
            ParentForm.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub onViewSubmittal(ByVal generateOnly As Boolean, ByRef fileName As String, Optional ByVal showReport As Boolean = False, Optional ByVal logo As String = "")
        'ParentForm.Cursor = Cursors.WaitCursor

        Try
            presenter.ViewSubmittal(generateOnly, fileName)
        Catch ex As Exception
            alert("Attempt to view submittal report failed. " & ex.Message)
        Finally
            'ParentForm.Cursor = Cursors.Default
        End Try
    End Sub

#End Region


#Region " Grid methods"

    ''' <summary>Handles available options being selected, namely receivers and their dependent options</summary>
    Private Sub handleSelectAvailableOp(ByRef e As DataColumnChangeEventArgs)
        Dim op As EquipmentOption
        Dim relOption As RelatedCommonOption

        ' converts row to an option
        op = Me.rowToOption(e.Row)
        ' sets series and model b/c its not in row
        op.Equipment = Me.Equipment
        ' constructs a related option
        relOption = New RelatedCommonOption(op)

        ' four year comppresor warranty
        If op.Code = "FYCW" Then
            If chkFourYearCompressorWarranty.Checked = False Then _
               chkFourYearCompressorWarranty.Checked = True
        End If

        onOpSelected(op.Code, op.Description)

        ' checks if option being selected is dependent upon another option
        If relOption.IsDependent Then
            ' is dependent

            ' checks if dependent has a parent selected
            Dim parentOptionRow = availableOpGrid.GetFirstSelectedFrom(relOption.ParentOptions)
            If parentOptionRow Is Nothing Then
                ' dependent does NOT have a parent selected
                ' messages user that a parent option must be selected first
                Dim message As New StringBuilder
                message.AppendFormat("You must select one of the following options before this option, {0}, can be selected.", _
                   e.Row(OCol.Description).ToString)
                For i As Integer = 0 To relOption.ParentOptions.Count - 1
                    message.AppendFormat("{0}     {1} - {2}", _
                       System.Environment.NewLine, relOption.ParentOptions.Item(i).Code, relOption.ParentOptions.Item(i).Description)
                Next
                Ui.MessageBox.Show(message.ToString, MessageBoxIcon.Warning)

                ' deselects option being selected
                e.ProposedValue = False

            Else
                ' dependent already has a parent selected
                ' sets dependent's quantity to that of its parent
                e.Row(OCol.Quantity) = parentOptionRow(OCol.Quantity)
                e.Row.AcceptChanges()
            End If

            ' checks if option being selected is parent
        ElseIf relOption.IsParent Then
            ' checks if another parent is already selected
            Dim relDependentOption As New RelatedCommonOption(relOption.DependentOptions.Item(0))
            Dim otherParentOptions As List(Of EquipmentOption) = relDependentOption.ParentOptions
            For i As Integer = 0 To otherParentOptions.Count - 1
                If relOption.Option.Code = otherParentOptions.Item(i).Code Then
                    otherParentOptions.RemoveAt(i) : Exit For
                End If
            Next
            Dim otherParentOptionRow = availableOpGrid.GetFirstSelectedFrom(otherParentOptions)
            If otherParentOptionRow Is Nothing Then
                ' there is no currently selected parent
                Dim row As DataRow
                ' sets dependent option prices in available options grid
                For i As Integer = 0 To relOption.DependentOptions.Count - 1
                    ' looks up and sets dependent option's price
                    '
                    ' gets row in available options grid containing dependent option
                    row = availableOpGrid.GetRow(relOption.DependentOptions.Item(i).Code)
                    ' sets dependent's price if price is zero
                    If CDbl(row(OCol.Price)) = 0 Then
                        row(OCol.Price) = relOption.DependentOptions.Item(i).Price
                    End If

                Next

            Else
                ' another parent is already selected
                Ui.MessageBox.Show("The option, " & relOption.Option.Description & ", can not be selected when option, " & otherParentOptionRow(OCol.Description).ToString & ", is already selected.", MessageBoxIcon.Information)
                ' deselects option being selected
                e.ProposedValue = False
            End If

        End If
    End Sub

    ''' <summary>Handles available options being deselected, namely receivers</summary>
    Private Sub handleDeselectAvailableOp(ByRef e As DataColumnChangeEventArgs)
        Dim op As EquipmentOption
        Dim relatedOption As RelatedCommonOption

        ' converts data row to option object
        op = Me.rowToOption(e.Row)
        ' sets equipment series and model b/c they're not in row
        op.Equipment.series = Me.EquipmentSelector1.Series
        op.Equipment.model_without_series = Me.EquipmentSelector1.Model
        ' constructs a related common option
        relatedOption = New RelatedCommonOption(op)

        ' four year comppresor warranty
        If op.Code = "FYCW" Then
            If chkFourYearCompressorWarranty.Checked Then chkFourYearCompressorWarranty.Checked = False
        End If

        If Equipment.type = EquipmentType.Chiller _
        AndAlso pump_package_code.matches(op.Code) Then
            CType(presenter, chiller_presenter).unselect_pump_package_option(e.Row)
        End If

        ' checks if option being deselected is parent
        If relatedOption.IsParent Then
            ' is parent

            ' checks if any dependent options are selected
            If availableOpGrid.GetFirstSelectedFrom(relatedOption.DependentOptions) Is Nothing Then
                ' NO dependents are selected
                ' allow to continue
            Else
                ' dependents are selected
                ' message user
                Dim message As String = "There are other selected options dependent upon this option, " & relatedOption.Option.Description & ". "
                message &= "If this option is deselected, all of its dependent options will be deselected too." & Environment.NewLine & Environment.NewLine
                message &= "Do you want to continue to deselect this option and its dependents?"
                Dim result As DialogResult = Forms.MessageBox.Show(message, "RAESolutions", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                ' if yes, deselect
                If result = DialogResult.Yes Then
                    ' deselects dependent options
                    For i As Integer = 0 To relatedOption.DependentOptions.Count - 1
                        Dim dependentRow As DataRow = availableOpGrid.GetRow(relatedOption.DependentOptions.Item(i).Code)

                        If Not dependentRow Is Nothing Then
                            ' deselects selected dependent options
                            If CBool(dependentRow(OCol.Selected)) = True Then
                                dependentRow(OCol.Selected) = False
                            End If
                            ' resets all dependent prices
                            dependentRow(OCol.Price) = 0
                            ' updates changes
                            dependentRow.AcceptChanges()
                        End If
                    Next

                ElseIf result = DialogResult.No Then
                    ' if no, reselect parent option, this may cause problem trying to re-add existing option
                    'Me.GetAvailableOptionRow(relatedOption.Option.Code).Item(OCol.Selected) = True
                    e.ProposedValue = True
                End If
            End If

        Else
            ' is NOT parent
            ' allow to continue
        End If
    End Sub


    Public Sub reselectOpsAfterModelOrVoltageChange(ByVal sender As Object, ByVal e As EventArgs)
        reselectOpsAfterModelOrVoltageChange()
    End Sub


    ''' <summary>
    ''' Populates all (available, standard and selected) option grids based on selected model and voltage
    ''' </summary>
    Private Sub reselectOpsAfterModelOrVoltageChange()
        ' determines whether inputs required to retrieve options are valid
        If Not Me.validateOptionRetrievalInputs() Then Exit Sub
        ' populates available options
        Me.populateAvailableOptionsGrid()
        ' populates standard options
        Me.populateStandardOptionsGrid()
        ' selects options based on selectedOptionsTable
        Me.selectOptions()


    End Sub


    ''' <summary>Returns table structure for options</summary>
    Private Function getOptionsTableStructure() As DataTable
        Dim optionsTable = availableOpTable.Copy
        optionsTable.Clear()

        Return optionsTable
    End Function

    Private Function getNumFans() As Integer
        If TypeOf Equipment Is unit_cooler Then
            Return CType(Equipment, unit_cooler).fan_quantity


        ElseIf TypeOf Equipment Is CondensingUnitEquipmentItem Then

            Return getNumberOfFansForCondUnit(Equipment.model)

        Else
            Return 0
        End If
    End Function

    ' parameters: series, model, code, voltage
    ''' <summary>
    ''' Converts selected voltage dependent options to correct voltage
    ''' </summary>
    Private Sub convertSelectedVoltageDependentOptions()
        Dim optionTable, optionsToAddTable, optionsToRemoveTable As DataTable
        Dim voltage As Integer
        Dim message As String

        optionsToAddTable = Me.getOptionsTableStructure()
        optionsToRemoveTable = Me.getOptionsTableStructure()

        ' determines whether a voltage is selected
        If Me.GrabUnitVoltage Is Nothing Then Exit Sub

        ' grabs and parses selected unit voltage from control
        voltage = CInt(Me.parseVoltage(Me.GrabUnitVoltage))

        ' finds selected voltage dependent options
        For Each row As DataRow In Me.selectedOpTable.Rows

            If voltage <> 575 AndAlso row(OCol.Code).ToString = "EV01" Then
                ' don't add EV01 back in for non 575
            Else
                ' determines whether option is voltage dependent
                If CBool(row(OCol.IsVoltageDependent)) Then
                    ' retrieves option with same option code but new voltage
                    optionTable = EquipmentOptionsAgent.OptionsDA.RetrieveOption( _
                       EquipmentSelector1.Series, EquipmentSelector1.Model, row(OCol.Code).ToString, voltage, getNumFans, getFanMotorPhase)
                    If optionTable.Rows.Count > 0 Then


                        ' sets quantity on option to add
                        optionTable.Rows(0)(OCol.Quantity) = row(OCol.Quantity)
                        ' imports option with correct voltage
                        optionsToAddTable.ImportRow(optionTable.Rows(0))
                        ' removes old option (with incorrect voltage)
                        optionsToRemoveTable.ImportRow(row)
                    Else

                        message &= NewLine & "Code: " & row(OCol.Code).ToString & ", Voltage: " & row(OCol.Voltage).ToString

                    End If
                End If

            End If
        Next

        For i As Integer = 0 To optionsToAddTable.Rows.Count - 1
            ' adds option to selected options
            Me.selectedOpTable.ImportRow(optionsToAddTable.Rows(i))
            ' removes option from selected options
            For Each row As DataRow In Me.selectedOpTable.Rows
                If CInt(row(OCol.ID)) = CInt(optionsToRemoveTable.Rows(i)(OCol.ID)) Then
                    Me.selectedOpTable.Rows.Remove(row) : Exit For
                End If
            Next
        Next

        If Not message = "" Then
            message = "The attempt to select the following options failed. There are no options with these option code and voltage pairs." & message
            Ui.MessageBox.Show(message, MessageBoxIcon.Warning)
        End If
    End Sub



    ''' <summary>Selects options in grid</summary>
    Private Sub selectOptions()
        ' sets grid structure if no options are selected
        If selectedOpTable.Columns.Count = 0 Then
            selectedOpTable = getOptionsTableStructure()
            selectedOpGrid.DataSource = selectedOpTable
            selectedOpGrid.RowHeadersVisible = False
            Me.selectedOpGrid.Columns(OCol.Selected).HeaderText = "Select"
            Me.selectedOpGrid.Columns(OCol.Code).HeaderText = "Code"
            Me.selectedOpGrid.Columns(OCol.Description).HeaderText = "Description"
            Me.selectedOpGrid.Columns(OCol.Category).HeaderText = "Category"
            Me.selectedOpGrid.Columns(OCol.Price).HeaderText = "Price"
            Me.selectedOpGrid.Columns(OCol.Per).HeaderText = "Per"
            Me.selectedOpGrid.Columns(OCol.Quantity).HeaderText = "Quantity"
            Me.selectedOpGrid.Columns(OCol.Selected).Width = 55
            Me.selectedOpGrid.Columns(OCol.Code).Width = 45
            Me.selectedOpGrid.Columns(OCol.Description).Width = 185
            Me.selectedOpGrid.Columns(OCol.Category).Width = 115
            Me.selectedOpGrid.Columns(OCol.Price).Width = 65
            Me.selectedOpGrid.Columns(OCol.Per).Width = 50
            Me.selectedOpGrid.Columns(OCol.Quantity).Width = 55
            Me.selectedOpGrid.Columns(OCol.ID).Visible = False
            Me.selectedOpGrid.Columns(OCol.Code).Visible = True
            Me.selectedOpGrid.Columns(OCol.Quantity).Visible = True
            Me.selectedOpGrid.Columns(OCol.IsSelectedReadOnly).Visible = False
            Me.selectedOpGrid.Columns(OCol.IsQuantityReadOnly).Visible = False
            Me.selectedOpGrid.Columns(OCol.IsVoltageDependent).Visible = False
            Me.selectedOpGrid.Columns(OCol.Voltage).Visible = False
            Me.selectedOpGrid.Columns(OCol.ContactFactory).Visible = False
            Me.selectedOpGrid.Columns(OCol.IsDependent).Visible = False
            Me.selectedOpGrid.Columns(OCol.Price).Visible = True
            Me.selectedOpGrid.Columns(OCol.MasterId).Visible = False
            Me.selectedOpGrid.Columns(OCol.Details).Visible = False
            Me.selectedOpGrid.Columns(OCol.Selected).Visible = False
            Me.selectedOpGrid.Columns(OCol.Description).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Me.selectedOpGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray

            Me.selectedOpGrid.EnableHeadersVisualStyles = False
            Me.selectedOpGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue

        End If

        convertSelectedVoltageDependentOptions()

        Dim selectedOpCopyTable = selectedOpTable.Copy
        selectedOpTable.Clear()
        availableOpGrid.Select(selectedOpCopyTable)
    End Sub


    ''' <summary>Populates and formats available options grid</summary>
    Private Sub populateAvailableOptionsGrid()
        If Not Me.validateOptionRetrievalInputs Then _
           Exit Sub

        Dim series = Me.EquipmentSelector1.Series
        Dim model = Me.EquipmentSelector1.Model
        Dim voltage = CInt(Me.parseVoltage(Me.GrabUnitVoltage))
        Dim fanMotorPhase As Integer = getFanMotorPhase()

        'If series = "BALV" Or series = "WIBR" Then
        '    If fanMotorPhase = 1 Then
        '        optionsToAddTable = 
        '    End If
        'End If

        ' retrieves
        availableOpTable = EquipmentOptionsAgent.OptionsDA.RetrieveAvailableOptions(series, model, voltage, getNumFans, user, fanMotorPhase)
        ' sets
        availableOpGrid.DataSource = availableOpTable


        ' selectedOpTable.ImportRow(availableOpTable.Rows(2))

        For Each row As DataRow In availableOpTable.Rows
            If CType(row("selected"), Boolean) = True AndAlso CType(row("isselectedreadonly"), Boolean) = False Then


                ''selectedOpTable.ImportRow(row)
                ''If CType(row("isquantityreadonly"), Boolean) = True Then
                ''    availableOpGrid.Columns(OCol.Quantity).ReadOnly = True

                ''Else
                ''    availableOpGrid.Columns(OCol.Quantity).ReadOnly = False

                ''End If


            End If
            If CType(row("isquantityreadonly"), Boolean) = True Then
                availableOpGrid.Columns(OCol.Quantity).ReadOnly = True

            Else
                availableOpGrid.Columns(OCol.Quantity).ReadOnly = False

            End If
            ' lock option codes --- dakotal
            If row(1).ToString().Trim() = "EM09" And getFanMotorPhase() = 3 Then
                'CType(row("selected"), CheckBox).Checked = False
                row(OCol.Selected) = False
                'Return
            End If
        Next

        availableOpGrid.Columns(OCol.Selected).ReadOnly = False
        availableOpGrid.Columns(OCol.Code).ReadOnly = True
        availableOpGrid.Columns(OCol.Description).ReadOnly = True
        availableOpGrid.Columns(OCol.Category).ReadOnly = True
        availableOpGrid.Columns(OCol.Price).ReadOnly = True
        availableOpGrid.Columns(OCol.Per).ReadOnly = True
        availableOpGrid.RowHeadersVisible = False
        availableOpGrid.Columns(OCol.Selected).HeaderText = "Select"
        availableOpGrid.Columns(OCol.Code).HeaderText = "Code"
        availableOpGrid.Columns(OCol.Description).HeaderText = "Description"
        availableOpGrid.Columns(OCol.Description).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        availableOpGrid.Columns(OCol.Category).HeaderText = "Category"
        availableOpGrid.Columns(OCol.Price).HeaderText = "Price"
        availableOpGrid.Columns(OCol.Per).HeaderText = "Per"
        availableOpGrid.Columns(OCol.Quantity).HeaderText = "Quantity"

        availableOpGrid.Columns(OCol.ID).Visible = False
        availableOpGrid.Columns(OCol.Code).Visible = True
        availableOpGrid.Columns(OCol.Quantity).Visible = True
        availableOpGrid.Columns(OCol.IsSelectedReadOnly).Visible = False
        availableOpGrid.Columns(OCol.IsQuantityReadOnly).Visible = False
        availableOpGrid.Columns(OCol.IsVoltageDependent).Visible = False
        availableOpGrid.Columns(OCol.Voltage).Visible = False
        availableOpGrid.Columns(OCol.ContactFactory).Visible = False
        availableOpGrid.Columns(OCol.IsDependent).Visible = False
        availableOpGrid.Columns(OCol.Price).Visible = True
        availableOpGrid.Columns(OCol.MasterId).Visible = False
        availableOpGrid.Columns(OCol.Details).Visible = False

        availableOpGrid.Columns(OCol.Selected).Width = 45
        availableOpGrid.Columns(OCol.Code).Width = 45
        availableOpGrid.Columns(OCol.Description).Width = 260
        availableOpGrid.Columns(OCol.Category).Width = 165
        availableOpGrid.Columns(OCol.Price).Width = 40
        availableOpGrid.Columns(OCol.Per).Width = 40
        availableOpGrid.Columns(OCol.Quantity).Width = 50
        availableOpGrid.Columns(OCol.Description).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        availableOpGrid.Columns(OCol.Category).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        availableOpGrid.Columns(OCol.Quantity).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        availableOpGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray

        availableOpGrid.EnableHeadersVisualStyles = False
        availableOpGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue

        availableOpGrid.Columns(OCol.Selected).DisplayIndex = 0

        availableOpGrid.Sort(availableOpGrid.Columns(OCol.Category), ListSortDirection.Ascending)

        ' formats
        ''availableOpGrid.GroupByCategory()
    End Sub


    Public Function getFanMotorPhase() As Integer
        If Equipment.type <> EquipmentType.UnitCooler Then
            Return 0
        Else
            Dim specControl1 As UnitCoolerSpecsControl = CType(Me.specsControl, UnitCoolerSpecsControl)


            If specControl1.fanVoltageCombo.SelectedItem Is Nothing Then
                Return 0
            Else
                Dim voltageString As String = specControl1.fanVoltageCombo.SelectedItem.ToString
                Dim phaseString As String = voltageString.Substring(voltageString.IndexOf("/") + 1, 1)
                Return Integer.Parse(phaseString)
            End If

        End If

    End Function






    ''' <summary>Populates and formats standard options grid</summary>
    Private Sub populateStandardOptionsGrid()
        If Not Me.validateOptionRetrievalInputs() Then _
           Exit Sub

        Dim series = Me.EquipmentSelector1.Series
        Dim model = Me.EquipmentSelector1.Model
        Dim voltage = CInt(parseVoltage(Me.GrabUnitVoltage()))

        ' retrieves typed table of standard options
        lblNoOptions.Visible = False



        Dim standardOptionsTable = EquipmentOptionsAgent.OptionsDA.RetrieveStandardOptions(series, model, voltage, getNumFans, getFanMotorPhase)
        standardOpGrid.DataSource = standardOptionsTable
        standardOpGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        standardOpGrid.DefaultCellStyle.Font = New Font("Times New Roman", 8)
        standardOpGrid.RowHeadersVisible = False
        ''standardOpGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
        Me.standardOpGrid.Columns(OCol.ID).Visible = False
        Me.standardOpGrid.Columns(OCol.IsQuantityReadOnly).Visible = False
        Me.standardOpGrid.Columns(OCol.Per).Visible = False
        Me.standardOpGrid.Columns(OCol.IsSelectedReadOnly).Visible = False
        Me.standardOpGrid.Columns(OCol.Selected).Visible = False
        Me.standardOpGrid.Columns(OCol.Price).Visible = False
        Me.standardOpGrid.Columns(OCol.IsVoltageDependent).Visible = False
        Me.standardOpGrid.Columns(OCol.Voltage).Visible = False
        Me.standardOpGrid.Columns(OCol.ContactFactory).Visible = False
        Me.standardOpGrid.Columns(OCol.IsDependent).Visible = False
        Me.standardOpGrid.Columns(OCol.MasterId).Visible = False
        Me.standardOpGrid.Columns(OCol.Details).Visible = False
        Me.standardOpGrid.Columns(OCol.Quantity).HeaderText = "Quantity"
        Me.standardOpGrid.Columns(OCol.Code).HeaderText = "Code"
        Me.standardOpGrid.Columns(OCol.Description).HeaderText = "Description"
        Me.standardOpGrid.Columns(OCol.Category).HeaderText = "Category"
        Me.standardOpGrid.Columns(OCol.Price).HeaderText = "Price"
        Me.standardOpGrid.Columns(OCol.Quantity).Width = 55
        Me.standardOpGrid.Columns(OCol.Code).Width = 45
        Me.standardOpGrid.Columns(OCol.Description).Width = 250
        Me.standardOpGrid.Columns(OCol.Category).Width = 115
        Me.standardOpGrid.Columns(OCol.Price).Width = 65
        Me.standardOpGrid.Columns(OCol.Description).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Me.standardOpGrid.Columns(OCol.Category).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Me.standardOpGrid.Columns(OCol.Code).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.standardOpGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray

        Me.standardOpGrid.EnableHeadersVisualStyles = False
        Me.standardOpGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue

        standardOpGrid.ApplyStyle()
    End Sub

#End Region


#Region " UI methods"


#Region " Grab and display methods"

    Private Function grabPrice(ByVal control As Control) As Double
        Dim price As Double = 0
        If control.Text <> "Contact Factory" AndAlso control.Text <> "Unavailable" AndAlso control.Text <> "Not Inc." Then
            If control.Text.Length > 0 Then
                price = Double.Parse(control.Text, Globalization.NumberStyles.Currency)
            End If
        End If
        Return price
    End Function

    ''' <summary>
    ''' Grabs value shown as a percent and returns value as a decimal.
    ''' </summary>
    ''' <param name="control">Control to grab percent from.</param>
    ''' <returns>Decimal representation of percent.</returns>
    Private Function GrabPercent(ByVal control As Control) As Double
        Dim decimalValue As Double
        If control.Text.Length > 0 Then
            ' converts percent to decimal
            decimalValue = CDbl(control.Text.Replace("%", "")) / 100
        Else
            decimalValue = 0
        End If
        Return decimalValue
    End Function


    Private Function grabUnitQuantity() As Integer
        Return CNull.ToInteger(Me.txtUnitQuantity.Text)
    End Function


    Private Function GrabParMultiplier() As Double
        Dim multiplier As Double = 0.0

        If AppInfo.Division = CRI Then
            multiplier = CDbl(Me.NumericUpDown1.Value)
        Else
            multiplier = CDbl(Me.cboParMultiplier.Text)
        End If

        Return multiplier
    End Function

    ''' <summary>Grabs commission rate from PAR multiplier combobox value, not commission rate label text
    ''' </summary>
    Friend Function GrabCommissionRate() As Double
        Dim commision As Double = 0.0
        If AppInfo.Division = CRI Then
            'Dim parPrice, commissionPrice, othersPrice, nfspPrice As Double

            ' calculates par price
            'parPrice = Intelligence.PriceCalculator.CalculateParPrice(Me.grabPrice(Me.lblSummaryTotalListPrice), CDbl(NumericUpDown1.Value))

            Dim commissionRate As Double = 0.0
            If Not ddCentury.SelectedItem Is Nothing Then
                If Me.ddCentury.SelectedItem.ToString() = "Resco" Then
                    Dim multiplier As Double = CDbl(NumericUpDown1.Value)
                    Dim baseListPrice As Double = CDbl(lblSummaryTotalListPrice.Text)
                    If multiplier < 0.281 Then
                        commissionRate = 0.0
                    ElseIf multiplier > 0.28 And multiplier < 0.3159 Then
                        commissionRate = 3.36538 * multiplier - 0.94279
                    ElseIf multiplier > 0.3158 Then
                        Dim num As Double = (((baseListPrice * multiplier) - (baseListPrice * 0.3158)) / 2) + (0.12 * (baseListPrice * 0.3158))
                        Dim den As Double = (baseListPrice * multiplier)
                        commissionRate = num / den
                    End If
                Else
                    Dim multiplier As Double = CDbl(NumericUpDown1.Value)
                    Dim baseListPrice As Double = CDbl(lblSummaryTotalListPrice.Text)
                    If multiplier < 0.29 Then
                        commissionRate = 0.0
                    ElseIf multiplier > 0.289 And multiplier < 0.3296 Then
                        commissionRate = 2.85714286 * multiplier - 0.8214
                    ElseIf multiplier > 0.3295 Then
                        Dim num1 As Double = (((baseListPrice * multiplier) - (baseListPrice * 0.3295)) / 2) + (0.12 * (baseListPrice * 0.3295))
                        Dim den1 As Double = (baseListPrice * multiplier)
                        commissionRate = num1 / den1
                    End If
                End If
            End If

            ' calculates commission price (grabs commission rate from par combobox selected value)
            'commissionPrice = Intelligence.PriceCalculator.CalculateCommissionPrice(commissionRate, parPrice)

            commision = commissionRate
        Else
            commision = CDbl(Me.cboParMultiplier.SelectedValue)
        End If

        Return CDbl(commision)
    End Function

    Private Function GrabUnitVoltage() As String
        If Me.cboUnitVoltage.SelectedItem Is Nothing Then
            Return ""
        Else
            Return CNull.ToString(Me.cboUnitVoltage.SelectedItem.ToString)

        End If
    End Function



    ''' <summary>
    ''' Calculates pricing (particularly commission needs to be calculated if not already)
    ''' </summary>
    Sub calculateAndDisplayPrices()
        ' calculates base list price
        Dim totalBaseListPrice As Double
        Dim unitQuantity As Integer
        unitQuantity = Me.grabUnitQuantity()
        totalBaseListPrice = Me.grabBaseList() ' this has already been multiplied by unit quantity

        ' calculates options price
        Dim totalSelectedOptionsPricePerUnit, totalOptionsPrice, totalSpecialOptionsPricePerUnit As Double
        'totalSelectedOptionsPricePerUnit = Me.calculateTotalOptionsPrice()
        totalSpecialOptionsPricePerUnit = Me.SpecialOptionsControl1.TotalPrice
        'totalOptionsPricePerUnit = totalSelectedOptionsPricePerUnit + totalSpecialOptionsPricePerUnit
        'totalOptionsPrice = totalOptionsPricePerUnit * unitQuantity

        Dim breakDown As OptionBreakDown = Me.calculateTotalOptionsPrice()
        totalSelectedOptionsPricePerUnit = breakDown.AvailableOptionsPricePerUnit
        totalOptionsPrice = breakDown.Total + totalSpecialOptionsPricePerUnit * unitQuantity

        Dim totalListPrice As Double
        totalListPrice = totalBaseListPrice + totalOptionsPrice    'Intelligence.PriceCalculator.CalculateTotalListPrice(Me.grabPrice(Me.lblBaseListPrice), totalOptionsPrice, Me.GrabUnitQuantity())
        If Me.Equipment.type = EquipmentType.FluidCooler AndAlso Me.pnlCoil.Visible Then
            totalListPrice = totalBaseListPrice + totalOptionsPrice + Val(Me.lblCoilListPrice.Text.Replace("$", ""))
        End If
        Dim parPrice As Double
        parPrice = Intelligence.PriceCalculator.CalculateParPrice(totalListPrice, Me.GrabParMultiplier())

        Dim commissionPrice As Double
        commissionPrice = Intelligence.PriceCalculator.CalculateCommissionPrice(Me.GrabCommissionRate(), parPrice)

        ' calculates others (warranty, freight, etc.) price
        Dim othersPrice As Double
        othersPrice = Intelligence.PriceCalculator.CalculateTotalOtherPrice(Me.grabPrice(Me.txtFourYearCompressorWarranty), Me.grabPrice(Me.txtFreight), Me.grabPrice(Me.txtStartUp), Me.grabPrice(Me.txtOther))

        Dim warranty As Double = Me.grabPrice(Me.txtFourYearCompressorWarranty)
        Dim warrantyDB As Double = 0

        Dim nfspPrice As Double
        nfspPrice = Intelligence.PriceCalculator.CalculateNfspPrice(parPrice, othersPrice)

        ' displays total options price
        Me.displayTotalOptionsPrice(totalSelectedOptionsPricePerUnit, breakDown.CommonOptionsPrice)
        ' displays total special options price
        Me.displayPrice(Me.totalSpecialOptionsPriceLabel, totalSpecialOptionsPricePerUnit * Me.grabUnitQuantity())
        ' displays total special options price per unit in option summary
        Me.displayPrice(Me.lblSpecialOptionsSummaryTotalPrice, totalSpecialOptionsPricePerUnit)
        ' displays total list price
        Me.displayPrice(Me.lblSummaryTotalListPrice, totalListPrice)
        ' displays PAR price
        Me.displayPrice(Me.lblParPrice, parPrice)
        ' displays commission rate
        Me.displayPercent(Me.lblCommissionRate, Me.GrabCommissionRate())
        ' displays commission price
        Me.displayPrice(Me.lblCommissionPrice, commissionPrice)
        ' displays nfsp price
        Me.displayPrice(Me.lblNfsp, nfspPrice)

        If AppInfo.Division = CRI Then
            Dim equipmentID As String = Me.Equipment.id.ToString()

            Dim sql = "select MultiplierType, WarrantyPrice from Equipment where EquipmentID = '" & equipmentID & "' ORDER BY Revision"
            Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
            Dim command = connection.CreateCommand
            command.CommandText = sql
            Dim rdr As IDataReader

            Dim multiplierType As String = ""

            Try
                connection.Open()
                rdr = command.ExecuteReader()
                While rdr.Read
                    multiplierType = rdr("MultiplierType").ToString().Trim()
                    warrantyDB = CDbl(rdr("WarrantyPrice").ToString().Trim())
                End While
            Finally
                If rdr IsNot Nothing Then _
                   rdr.Close()
                If connection.State <> ConnectionState.Closed Then _
                   connection.Close()
            End Try

            If warranty <> warrantyDB Then updateWarrantyPrice(equipmentID, warranty)

            If multiplierType = "" Then multiplierType = "Century"
            If AppInfo.User.works_at_resco Then multiplierType = "Resco"


            'If ddCentury.SelectedIndex = -1 And AppInfo.User.is_in(century_sales) Then
            '    multiplierType = "Century"
            'End If

            If multiplierType <> ddCentury.Text And ddCentury.SelectedIndex <> -1 Then
                multiplierType = ddCentury.Text
            End If

            Me.ddCentury.SelectedItem = multiplierType


            Me.NumericUpDown1.UpButton()
            Me.NumericUpDown1.DownButton()
        End If
    End Sub

    Private Sub updateWarrantyPrice(ByVal equipmentID As String, ByVal warranty As Double)
        Dim sql = "UPDATE Equipment SET WarrantyPrice = @warranty WHERE EquipmentID = @id"
        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand

        Dim warrantyP = New OleDbParameter("@warranty", OleDbType.VarChar)
        warrantyP.Value = warranty
        command.Parameters.Add(warrantyP)
        Dim id = New OleDbParameter("@id", OleDbType.VarChar)
        id.Value = equipmentID
        command.Parameters.Add(id)

        command.CommandText = sql        

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Catch ex As Exception
            Console.Write(ex.Message)
        Finally
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try
    End Sub

    ''' <summary>Displays formatted price</summary>
    Private Sub displayPrice(ByVal control As Control, ByVal price As Double)
        control.Text = price.ToString(Me.price_format)  '("#0.00")
    End Sub

    ''' <summary>
    ''' Displays percent in control's text property.
    ''' </summary>
    ''' <param name="control">Control to display percent.</param>
    ''' <param name="percent">Decimal value to display as a percent.</param>
    Private Sub displayPercent(ByVal control As Control, ByVal decimalValue As Double)
        control.Text = (decimalValue).ToString("#0.####%")
    End Sub


    Private Sub displayTotalBaseListPrice(ByVal totalBaseListPrice As Double)
        Me.lblTotalBaseListPrice.Text = totalBaseListPrice.ToString(Me.price_format)
        Me.lblSummaryBaseListPrice.Text = totalBaseListPrice.ToString(Me.price_format)
        Me.txtOverrideBaseListPerUnit.Text = ""
        Me.overrideBaseListText.Text = "$0"
        Me.overrideBaseListCheck.Checked = False
    End Sub


    Private Sub displayTotalOptionsPrice(ByVal availableOptionsPricePerUnit As Double, ByVal commonOptionsPrice As Double)
        Dim totalOptionsPriceForAllUnits As Double

        ' calculates total options price for all units
        totalOptionsPriceForAllUnits = Me.grabUnitQuantity() * availableOptionsPricePerUnit

        ' displays total options price for a single unit
        Me.selectedAvailableOptionsPriceLabel.Text = availableOptionsPricePerUnit.ToString(Me.price_format)

        ' displays total options price for all units
        Me.totalAvailableOptionsPriceLabel.Text = totalOptionsPriceForAllUnits.ToString(Me.price_format)

        Me.selectedCommonOptionsPriceLabel.Text = commonOptionsPrice.ToString(price_format)
        Me.totalCommonOptionsPriceLabel.Text = commonOptionsPrice.ToString(price_format)
    End Sub


#End Region


    Private Sub alertUserAbout(ByVal obsoleteOps As EquipmentOptionList)
        If obsoleteOps.Count = 0 Then _
           Exit Sub

        Dim frm = New Form
        Dim lbl = New Label
        lbl.Dock = DockStyle.Fill
        lbl.TextAlign = ContentAlignment.MiddleCenter
        frm.Controls.Add(lbl)

        Dim message As String = "The following options are now obsolete. Please select replacements if appropriate."
        For Each op In obsoleteOps
            message &= NewLine & "(" & op.Quantity & ") " & op.Code & " - " & op.Description
        Next

        lbl.Text = message
        frm.Show(ParentForm)
    End Sub


    Private Sub askUserForOptionQuantity(ByVal optionRow As DataRow)
        Dim quantity As Integer
        ' if equipment is not being opened (don't want to prompt everytime an option is added during opening)
        ' and quantity is not readonly and quantity = 0
        If Not is_opening _
        AndAlso Not CBool(optionRow(OCol.IsQuantityReadOnly)) _
        AndAlso CInt(optionRow(OCol.Quantity)) = 0 Then
            Dim code = optionRow(OCol.Code).ToString
            Dim description = optionRow(OCol.Description).ToString

            Dim popup = New OptionQuantityForm(code, description)
            popup.CenterIn(availableOpGrid).ShowDialog()
            optionRow(OCol.Quantity) = popup.Quantity
            ' accept changes so the new quantity is imported later
            optionRow.AcceptChanges()

        ElseIf Not is_opening AndAlso Not CBool(optionRow(OCol.IsQuantityReadOnly)) Then
        Dim code = optionRow(OCol.Code).ToString
            Dim description = optionRow(OCol.Description).ToString

            Dim popup = New OptionQuantityForm(code, description)
            popup.CenterIn(availableOpGrid).ShowDialog()
            optionRow(OCol.Quantity) = popup.Quantity
            ' accept changes so the new quantity is imported later
            optionRow.AcceptChanges()
        End If
    End Sub

    ''' <summary>Initializes save tool strip panel. Sets event handlers and tool strip.</summary>
    Private Sub initializeSaveToolStripPanel()
        Me.SaveToolStripPanel1.SetUp(CType(Me.ParentForm, MainForm).mainToolStrip, _
           AddressOf saveMenuItem_Click, AddressOf saveAsRevisionMenuItem_Click)
    End Sub


    ''' <summary>Sets control values that are static for a specific condensing unit model.</summary>
    Private Sub loadCondensingUnitData(ByVal equipment As String)
        Try
            Dim cuInfo = New Rae.solutions.condensing_units.Condensing_Unit_Info(equipment)

            ' updates equipment with specs info
            InvokeMethod(Me.specsControl, methodName_GetControlValues, Me.Equipment)

            ' updates dimensions and refrigerant based on selected model
            Me.Equipment.common_specs.Length.set_to(Round(cuInfo.length, 2))
            Me.Equipment.common_specs.Width.set_to(Round(cuInfo.width, 2))
            Me.Equipment.common_specs.Height.set_to(Round(cuInfo.height, 2))
            'Me.Equipment.common_specs.OperatingWeight.set_to(Round(cuInfo.operating_weight, 2))
            'Me.Equipment.common_specs.ShippingWeight.set_to(Round(cuInfo.shipping_weight, 2))



            Me.Equipment.common_specs.OperatingWeight.value = (Round(cuInfo.operating_weight, 2))    '1
            Me.Equipment.common_specs.ShippingWeight.value = (Round(cuInfo.shipping_weight, 2))


            Dim formattedRefrigerant As String
            formattedRefrigerant = cuInfo.refrigerant.Trim(New Char() {"H"c, "M"c, "L"c})
            CType(Me.Equipment, CondensingUnitEquipmentItem).specs.refrigerant = formattedRefrigerant

            If Not Me.Equipment.common_specs.ControlVoltage.Voltage.has_value Then _
                Me.Equipment.common_specs.ControlVoltage.Voltage.set_to(115)



            If cuInfo.model.StartsWith("20") Then
                Dim ii As Integer = 1
            End If




        Catch ex As ApplicationException
            Ui.MessageBox.Show(ex.Message, MessageBoxIcon.Warning)
            With Me.Equipment.common_specs
                .Length.set_to_null()
                .Width.set_to_null()
                .Height.set_to_null()
                .ShippingWeight.set_to_null()
                .OperatingWeight.set_to_null()
            End With
        Finally
            ' sets spec controls' values with updated dimensions and refrigerant
            InvokeMethod(Me.specsControl, Me.methodName_SetControlValues, Me.Equipment)
        End Try
    End Sub

    Private Sub FluidCoolerPricing(ByVal fc As FluidCooler)
        'Dim price, totalPrice As Double
        'Try
        '    ' retrieves base list price from database
        '    price = EquipmentOptionsAgent.OptionsDA.RetrieveBaseListPrice(fc.FluidCoolerSeries.ModelSeries, fc.ModelNumber.ToString())
        '    ' calculates total base list price
        '    totalPrice = Intelligence.PriceCalculator.CalculateTotalBaseListPrice(price, Me.grabUnitQuantity())
        'Catch ex As System.ApplicationException
        '    ' price not found
        '    Ui.MessageBox.Show(ex.Message)
        '    ' TODO: encapsulate reset logic
        '    ' ensures Choose is an option
        '    If Not Me.EquipmentSelector1.cbo_model.Items.Contains(Me.EquipmentSelector1.choose) Then
        '        Me.EquipmentSelector1.cbo_model.Items.Insert(0, Me.EquipmentSelector1.choose)
        '    End If
        '    ' sets equipment price to zero
        '    Me.displayPrice(Me.lblBaseListPrice, 0)
        '    Me.displayTotalBaseListPrice(0)
        '    ' removes options
        '    availableOpGrid.RemoveAll()
        '    ' selects Choose
        '    Me.EquipmentSelector1.cbo_model.SelectedIndex = _
        '       Me.EquipmentSelector1.cbo_model.Items.IndexOf(Me.EquipmentSelector1.choose)
        '    Me.Cursor = Cursors.Default
        '    Exit Sub
        'End Try
        'Dim stdFC As FluidCooler = FluidCooler.Populate(fc.FluidCoolerID)
        ''   Dim stdCPW As New CoilPricingWrapper(stdFC.Coils(0).Convert, stdFC.CoilQuantity)
        '' Dim stdCoilPrice As Integer = CInt(System.Math.Ceiling(stdCPW.Price))
        ''   Dim fcCPW As New CoilPricingWrapper(fc.Coils(0).Convert, fc.CoilQuantity)
        '' Dim fcCoilPrice As Integer = CInt(System.Math.Ceiling(fcCPW.Price))
        ''    price = price - stdCoilPrice
        ''    totalPrice = CInt(System.Math.Ceiling(Intelligence.PriceCalculator.CalculateTotalBaseListPrice(price + fcCoilPrice, Me.grabUnitQuantity())))
        'Me.lblSummaryTotalListPrice.Text = totalPrice.ToString(Me.price_format)
        'Me.lblTotalBaseListPrice.Text = totalPrice.ToString(Me.price_format)
        'Me.lblSummaryBaseListPrice.Text = price.ToString(Me.price_format)
        ''Me.displayTotalBaseListPrice(totalPrice)
        'Me.pnlCoil.Visible = True
        'Me.lblCoilListPrice.Text = "$" & fcCoilPrice.ToString
        'If fc.CoilQuantity > 1 Then
        '    Me.lblCoilPriceEach.Visible = True
        '    Me.lblCoilPriceEach.Text = "($" & CInt(System.Math.Ceiling(fcCoilPrice / fc.CoilQuantity)).ToString & " each)"
        'End If
    End Sub


    ''' <summary>loads fluid cooler data.</summary>
    ''' <param name="FluidCoolerModel"></param>
    Private Sub LoadFluidCoolerData(ByVal FluidCoolerSeries As String, ByVal FluidCoolerModel As String) '(FluidCoolerModel As String)
        Dim fc As FluidCooler
        If Not Me.Equipment.RatingEquipment Is Nothing Then
            fc = CType(Me.Equipment.RatingEquipment, FluidCooler)

        Else
            fc = FluidCooler.Populate(FluidCoolerSeries, FluidCoolerModel)
        End If

        ' Dim fc As FluidCooler = FluidCooler.Populate(FluidCoolerSeries, FluidCoolerModel)
        Dim dims As String = fc.Dimensions
        dims = dims.Replace("""", "")
        ' parses length, width and height from dimensions
        Try
            Dim dimensionsParser As New Rae.Math.Dimensions(dims)
            Me.Equipment.common_specs.Length.set_to(dimensionsParser.Length)
            Me.Equipment.common_specs.Width.set_to(dimensionsParser.Width)
            Me.Equipment.common_specs.Height.set_to(dimensionsParser.Height)
            If fc IsNot Nothing Then
                Me.Equipment.common_specs.OperatingWeight.set_to(fc.Operating_Weight)
                Me.Equipment.common_specs.ShippingWeight.set_to(fc.Shipping_Weight)
                Me.EquipmentSelector1.Series = fc.FluidCoolerSeries.ModelSeries
                Me.EquipmentSelector1.Model = fc.ModelNumber.ToString
                Me.lblNumCoils.Text = fc.CoilQuantity.ToString
                FluidCoolerPricing(fc)
            Else
                Me.pnlCoil.Visible = False
            End If
        Catch
            Me.Equipment.common_specs.Length.set_to_null()
            Me.Equipment.common_specs.Width.set_to_null()
            Me.Equipment.common_specs.Height.set_to_null()
            Me.Equipment.common_specs.OperatingWeight.set_to_null()
            Me.Equipment.common_specs.ShippingWeight.set_to_null()
        End Try

        ' sets control values
        InvokeMethod(Me.specsControl, Me.methodName_SetControlValues, Me.Equipment)

    End Sub

    Private Function IndexOfDisplayMember(ByVal display As Double) As Integer
        Dim index As Integer = -1
        Dim valueAtIndex As Double
        Dim cbox As ComboBox = Me.cboParMultiplier

        For i As Integer = 0 To cbox.Items.Count - 1
            ' gets the value of the displaymember at the index
            valueAtIndex = CDbl(DirectCast(cbox.Items.Item(i), DataRowView).Item(cbox.DisplayMember))
            ' checks if the value at this index is equal to the display value that is being searched for
            If valueAtIndex = display Then
                index = i : Exit For
            End If
        Next

        If index = -1 Then
            If user.works_at_resco Then
                cbox.Text = "0.3193"
                index = cbox.SelectedIndex
            Else
                index = 0
            End If
        End If

        Return index
    End Function


    ''' <summary>Checks whether an item is selected in combobox's items collection</summary>
    Private Function IsItemSelected(ByVal combobox As ComboBox) As Boolean
        Return (Not combobox.SelectedItem Is Nothing)
    End Function


    Private Sub setColors()
        ' colors headings
        Me.lblBaseListPrice.ForeColor = ColorManager.HeaderBlue
        Me.standardOpGrid.ForeColor = ColorManager.HeaderBlue

        Me.lblTotalBaseListPrice.ForeColor = ColorManager.DarkBlue
        Me.lblUnitVoltage.ForeColor = MyColors.DarkBlue
    End Sub


    Private Sub initializeValidation()
        ' constructs validation managers
        Me.orderReportValidationManager = New ValidationManager(Me.orderReportErrorProvider)
        Me.submittalValidationMgr = New ValidationManager(Me.submittalReportErrorProvider)
        Me.equipmentValidationManager = New ValidationManager(Me.equipmentErrorProvider)

        ' constructs validation control and validators
        '
        ' series
        Me.seriesVCtrl = New ValidationControl(Me.EquipmentSelector1.cbo_series)
        ' model
        Me.modelVCtrl = New ValidationControl(Me.EquipmentSelector1.cbo_model)

        ' unit quantity
        Dim unitQuantityV As New RegularExpressionValidator(ErrorMessages.PositiveInteger("Unit quantity"), Rae.validation.regular_expressions.positive_integer)
        Me.unitQuantityVCtrl = New ValidationControl(Me.txtUnitQuantity)
        Me.unitQuantityVCtrl.Validators.Add(unitQuantityV)

        ' adds validation controls to order write up validation manager
        With Me.orderReportValidationManager.ValidationControls
            .Add(Me.seriesVCtrl)
            .Add(Me.modelVCtrl)
        End With

        ' adds validation controls to accessories report validation manager
        With Me.submittalValidationMgr.ValidationControls
            .Add(Me.seriesVCtrl)
            .Add(Me.modelVCtrl)
            .Add(Me.unitQuantityVCtrl)
        End With

        ' adds validation control to equipment validation manager
        With Me.equipmentValidationManager.ValidationControls
            .Add(Me.seriesVCtrl)
            .Add(Me.modelVCtrl)
            .Add(Me.unitQuantityVCtrl)
        End With

    End Sub

    ''' <summary>Validates inputs required to retrieve options</summary>
    ''' <returns>Boolean that is true if the inputs necessary to retrieve options are valid</returns>
    Private Function validateOptionRetrievalInputs() As Boolean
        ' determines whether model and voltage are selected
        If Me.EquipmentSelector1.Model = Nothing _
        OrElse Me.EquipmentSelector1.Model = Me.EquipmentSelector1.choose _
        OrElse Me.cboUnitVoltage.SelectedItem Is Nothing Then
            Return False
        Else
            Return True
        End If
    End Function

    Friend Sub showAllTabs() ' refresh values in controls
        Dim originalTabIndex = tabEquipment.SelectedIndex

        fourYearCompressorWarrantySuggestionEnabled = False
        For i As Integer = 0 To tabEquipment.TabCount - 1
            tabEquipment.SelectedTab = tabEquipment.TabPages(i)
        Next
        fourYearCompressorWarrantySuggestionEnabled = True

        ' resets selected tab to originally selected tab
        tabEquipment.SelectedTab = tabEquipment.TabPages(originalTabIndex)
    End Sub

    Private Sub populateMultipliersAndCommissionRates()

        'blargg
        Dim contractor As String = "Yes"

        If AppInfo.User.works_at_resco Then
            contractor = "No"
        Else
            Dim connection = New OleDbConnection(ConnectionString.Text)
            Dim command = connection.CreateCommand
            Dim rdr As IDataReader

            Try
                Dim strSQL As String = "SELECT [Contractor] FROM [Table1] WHERE User_Name = '" & AppInfo.User.username.ToString & "'"

                command.CommandText = strSQL
                command.Connection = connection
                connection.Open()

                rdr = command.ExecuteReader()

                If rdr.Read Then
                    If rdr("Contractor").ToString() = "False" Then
                        contractor = "No"
                    Else
                        contractor = "Yes"
                    End If
                End If

            Catch ex As Exception
                contractor = "Yes"
            Finally
                If Not rdr Is Nothing Then rdr.Close()
                command.Dispose()
                connection.Dispose()
            End Try
        End If

        If contractor = "Yes" Then
            Me.cboParMultiplier.DataSource = OrderAssistanceDA.RetrieveContractorMultipliersCommissions()
        ElseIf user.works_at_resco Then
            Me.cboParMultiplier.DataSource = OrderAssistanceDA.RetrieveRescoMultipliersCommissions()
            Me.cboParMultiplier.Visible = False
            Me.NumericUpDown1.Visible = True
            Me.ddCentury.Visible = True
            Me.ddCentury.Items.Remove("Century")
            Me.ddCentury.SelectedItem = "Resco"
            'Me.ddCentury.Enabled = False
            Me.NumericUpDown1.Minimum = CDec(0.281)
            Me.NumericUpDown1.Value = CDec(0.3193)
            Me.cboParMultiplier.Visible = False
        ElseIf AppInfo.Division = TSI Then
            Me.NumericUpDown1.Visible = False
            Me.cboParMultiplier.Visible = True
            Me.cboParMultiplier.DataSource = OrderAssistanceDA.RetrieveTsiMultipliersCommissions()
        ElseIf AppInfo.Division = CRI Then
            Me.NumericUpDown1.Visible = True
            Me.cboParMultiplier.Visible = False
            Me.NumericUpDown1.Value = CDec(0.29)
            Me.NumericUpDown1.Minimum = CDec(0.29)
            Me.ddCentury.SelectedValue = "Century"
            If user.is_in(century_sales) Then
                Me.ddCentury.Visible = True                
            End If
            Dim mc = OrderAssistanceDA.RetrieveCriMultipliersCommissions
            ' gary uses both century and resco multipliers
            If user.is("GaryB") Then
                Dim resco = OrderAssistanceDA.RetrieveRescoMultipliersCommissions
                mc.Merge(resco)
            End If
            cboParMultiplier.DataSource = mc
        End If
        Me.cboParMultiplier.DisplayMember = "Multiplier"
        Me.cboParMultiplier.ValueMember = "Commission"
    End Sub


    ' Adds specs control for the selected equipment type. Arranges and formats control.
    Private Sub addAndFormatSpecsControl()
        Dim specsControl = buildSpecsControl(Equipment.type)
        ' adds specs control to first tab
        Me.tabEquipment.TabPages(0).Controls.Add(specsControl)
        specsControl.Dock = DockStyle.Top

        ' organizes vertical layout
        pricingPanel.SendToBack()
        specsControl.SendToBack()
        specsHeaderPanel.SendToBack()
        modelPanel.SendToBack()

        'reselectOpsAfterModelOrVoltageChange

        ' sets reference to specs control
        Me.specsControl = Me.tabEquipment.TabPages(0).Controls("SpecsControl")




        If Me.GetType.Name = "unit_cooler_pricing_screen" Then
            Dim specControl1 As UnitCoolerSpecsControl = CType(Me.specsControl, UnitCoolerSpecsControl)
            AddHandler specControl1.fanVoltageCombo.SelectedIndexChanged, AddressOf Me.reselectOpsAfterModelOrVoltageChange
        End If

    End Sub


    ''' <summary>Adds refrigerant, R507a, for Century condensing units.</summary>
    Private Sub addAdditionalefrigerants()
        If Me.Equipment.type = EquipmentType.CondensingUnit _
        AndAlso ((AppInfo.Division = Division.CRI) OrElse (AppInfo.Division = TSI AndAlso user.is_employee)) Then
            CType(Me.specsControl, CondensingUnitSpecsControl).cboRefrigerant.Items.Add("R507")
        End If

        If Me.Equipment.type = EquipmentType.CondensingUnit AndAlso AppInfo.Division = TSI Then
            If user.is_rep Then
                CType(Me.specsControl, CondensingUnitSpecsControl).cboRefrigerant.Items.Clear()
            End If
            CType(Me.specsControl, CondensingUnitSpecsControl).cboRefrigerant.Items.Add("R410a")

        End If

    End Sub

#End Region


#Region " Business logic methods"

    Private Sub authorize()
        authorizePricing()
        authorizeOverrideBaseList()
        authorizeDrawings()
    End Sub

    Private Sub authorizeDrawings()
        Dim path As System.IO.Path
        Dim pipingFolderPath = path.Combine(AppInfo.AppFolderPath, "Drawings\Drawings\Piping")
        Dim pipingFolder = New System.IO.DirectoryInfo(pipingFolderPath)

        ' hides piping drawings from reps (need to create piping folder first)
        If Not pipingFolder.Exists Then _
           pipingFolder.Create()

        Dim hasFluidPipingDrawing = (Equipment.type = EquipmentType.Chiller Or Equipment.type = EquipmentType.PumpPackage)
        mnuFluidPiping.Visible = hasFluidPipingDrawing
        barFluidPiping.Visible = hasFluidPipingDrawing

        Dim hasRefrigerantPipingDrawing = (Equipment.type = EquipmentType.Chiller Or Equipment.type = EquipmentType.CondensingUnit)
        mnuRefrigerantPiping.Visible = hasRefrigerantPipingDrawing
        barRefrigerantPiping.Visible = hasRefrigerantPipingDrawing
    End Sub

    Private Sub authorizeOverrideBaseList()
        Dim canOverrideBaseList As Boolean = (user.authority_group = user_group.employee)
        overrideBaseListText.Visible = canOverrideBaseList
        overrideBaseListCheck.Visible = canOverrideBaseList
        overrideBaseListLabel.Visible = canOverrideBaseList
    End Sub

    Private Sub authorizePricing()
        If user.can_view_pricing Then
            pricingAuthorized = True
            availableOpGrid.IsPriceVisible = pricingAuthorized
            selectedOpGrid.IsPriceVisible = pricingAuthorized
        Else
            pricingAuthorized = False
            ' removes pricing tab
            If Me.tabEquipment.TabPages.Contains(Me.tabPricing) Then
                Me.tabEquipment.TabPages.Remove(Me.tabPricing)
                Me.tabEquipment.SelectedTab = Me.tabModel
            End If
        End If

        ' shows/hides pricing labels
        Me.lblBaseListPrice.Visible = Me.pricingAuthorized
        Me.lblBaseListPriceLabel.Visible = Me.pricingAuthorized
        Me.lblTotalBaseListPrice.Visible = Me.pricingAuthorized
        Me.lblTotalBaseListPriceLabel.Visible = Me.pricingAuthorized
        Me.selectedAvailableOptionsLabel.Visible = Me.pricingAuthorized
        Me.selectedAvailableOptionsPriceLabel.Visible = Me.pricingAuthorized
    End Sub


    Private Function calculateTotalOptionsPrice() As OptionBreakDown
        Dim breakDown As OptionBreakDown

        ' checks if datasource is set yet
        If Me.selectedOpGrid.DataSource Is Nothing Then Return breakDown

        Dim quantity As Integer
        Dim commonOption, commonOptions, availableOptions, price As Double

        ' sums all options
        For Each row As DataRow In Me.selectedOpTable.Rows
            quantity = CNull.ToInteger(row(OCol.Quantity))
            price = CNull.ToDouble(row(OCol.Price))

            If quantity > 0 Then
                ' Do not include price for 4 year compressor warranty n the option pricing.
                If CNull.ToString(row(OCol.Code)) = "FYCW" Then
                    If price = 0 Then
                        txtFourYearCompressorWarranty.Text = "Contact Factory"
                        txtFourYearCompressorWarranty.ReadOnly = False
                    Else
                        Me.displayPrice(txtFourYearCompressorWarranty, Round(price * grabUnitQuantity(), 0))
                        txtFourYearCompressorWarranty.ReadOnly = True
                    End If
                Else
                    If CNull.ToString(row(OCol.Per)).ToLower = "system" Then
                        commonOption = price * quantity
                        commonOptions += commonOption
                    Else
                        availableOptions = availableOptions + quantity * price
                    End If
                End If
            End If
        Next

        breakDown.AvailableOptionsPricePerUnit = availableOptions
        breakDown.CommonOptionsPrice = commonOptions
        breakDown.Total = availableOptions * grabUnitQuantity() + commonOptions

        Return breakDown
    End Function


    Friend ReadOnly Property totalOptionsPrice As Double
        Get
            Dim availableOps = Me.grabPrice(totalAvailableOptionsPriceLabel)
            Dim specialOps = grabPrice(totalSpecialOptionsPriceLabel)
            Dim commonOps = grabPrice(totalCommonOptionsPriceLabel)

            Dim totalOps = availableOps + specialOps + commonOps
            Return totalOps
        End Get
    End Property


    Friend Structure OptionBreakDown
        Public AvailableOptionsPricePerUnit As Double
        Public CommonOptionsPrice As Double
        Public Total As Double
    End Structure


    ''' <summary>Parse voltage from voltage description (Voltage/Phase/Hertz)</summary>
    ''' <param name="voltageDescription">Voltage description formatted as Voltage/Phase/Hertz</param> 
    Private Function parseVoltage(ByVal voltageDescription As String) As String
        Dim voltage As String

        ' parses voltage
        voltage = voltageDescription.Substring(0, voltageDescription.IndexOf("/"))

        Return voltage
    End Function

#End Region


#Region " Saving and revisioning"

    ''' <summary>True if equipment is saved (ie is equal to last saved state).</summary>
    ''' <param name="equipment">Equipment item to check if it is saved.</param>
    Private Function isSaved(ByVal equipment As EquipmentItem) As Boolean
        Dim method As MethodInfo
        Dim saved As Boolean

        ' gets equals method for equipment item even though the derived type is not known
        method = equipment.GetType.GetMethod("Equals", New Type() {equipment.GetType()})
        ' invokes equals to check if equipment is equal to the last saved state
        saved = CType(method.Invoke(equipment, New Object() {Me.LastSavedState}), Boolean)



        Return saved
    End Function


    ''' <summary>Saves equipment in project and updates last saved state.</summary>
    ''' <param name="equipment">Equipment to save.</param>
    Private Sub saveInProject(ByVal equipment As EquipmentItem)
        ' saves equipment
        Me.save(equipment)
        ' remembers equipment state after save
        Me.LastSavedState = InvokeMethod(Of EquipmentItem)(equipment, "Clone")
    End Sub


    ''' <summary>Asks user to choose equipment name.</summary>
    Private Function askUserToNameEquipment(ByRef equipmentName As String) As DialogResult
        Dim newPricingForm As New NewPricingForm()
        Dim result As DialogResult

        ' requests equipment name from user
        result = newPricingForm.ShowDialog()

        ' gets equipment name user chose
        equipmentName = newPricingForm.EquipmentName

        ' closes form used to get equipment name
        newPricingForm.Close()

        Return result
    End Function


    ''' <summary>Asks user to choose a project and equipment name.</summary>
    Private Function askUserToNameProjectAndEquipment(ByRef projectName As String, ByRef equipmentName As String) As DialogResult
        Dim newProjectAndEquipmentForm As New NewProjectAndEquipmentForm()
        Dim result As DialogResult

        ' requests project and equipment name from user
        result = newProjectAndEquipmentForm.ShowDialog()

        ' gets names user chose
        projectName = newProjectAndEquipmentForm.ProjectName
        equipmentName = newProjectAndEquipmentForm.EquipmentName

        ' closes form
        newProjectAndEquipmentForm.Close()

        Return result
    End Function


    ''' <summary>Creates equipment in new project and inserts in data source.</summary>
    ''' <param name="equipment">Equipment to insert in data source.</param>
    Private Function createNewProjectAndEquipment(ByVal equipment As EquipmentItem) As Boolean
        Dim result As DialogResult
        Dim projectName, equipmentName As String

        ' asks user for project and equipment name
        result = Me.askUserToNameProjectAndEquipment(projectName, equipmentName)

        ' does the user want to continue to create a project and save equipment in it
        If result = Forms.DialogResult.OK Then
            ' state - user named project and equipment and wants to continue to save
            ' sets project name to name user entered
            equipment.ProjectManager.Project.name = projectName
            ' sets equipment's name to name user entered
            equipment.name = equipmentName
            ' sets form title, since name changed handler hasn't been added yet
            Me.Text = equipmentName
            ' sets opened project to the equipment's project manager
            OpenedProject.Manager = equipment.ProjectManager
            ' saves (inserts) project
            OpenedProject.Manager.Project.Save()
            ' saves (inserts) equipment
            Me.saveInProject(equipment)
            ' adds handler for equipment name changed event
            Me.addHandlerForEquipmentNameChanged()

            Return True
        Else
            ' state - user cancelled save
            ' cancels save; ends without saving equipment or creating project  
            ' CORRECTED 1/12/12 Eric C.  No longer closes pricing screen when cancelled.
            Return False
        End If
    End Function


    ''' <summary>Creates new equipment in project and inserts in data source.</summary>
    ''' <param name="equipment">Equipment to create</param>
    Private Sub createNewEquipment(ByVal equipment As EquipmentItem)
        Dim equipmentName As String

        Dim result = Me.askUserToNameEquipment(equipmentName)

        ' did the user want to continue to save
        If result = Forms.DialogResult.OK Then
            ' state - user named equipment
            ' names equipment
            equipment.name = equipmentName
            ' sets equipment form's title
            Me.Text = equipmentName
            ' set equipment revision...
            equipment.revision = CSng(Round(Rae.RaeSolutions.DataAccess.Projects.ProjectsDataAccess.RetrieveLatestRevision(OpenedProject.Manager.Project.id.Id) + 0.001, 3))
            ' adds equipment to opened project, writes over default project manager
            equipment.ProjectManager = OpenedProject.Manager
            ' add equipment to project manager
            OpenedProject.Manager.Equipment.Add(equipment)
            ' saves equipment and updates dependents in project
            Me.saveInProject(equipment)
            ' adds handler for equipment name changed event
            Me.addHandlerForEquipmentNameChanged()
        Else
            ' state - user cancelled save
            ' cancels save; ends without saving equipment
        End If
    End Sub


    ''' <summary>
    ''' Creates equipment from an old revision (revision that is not the latest) and inserts in data source.
    ''' </summary>
    ''' <param name="equipment">Equipment at old revision to set as latest revision.</param>
    ''' <param name="shouldAsk">
    ''' True to ask user before making latest revision; false to revision without saving.
    ''' </param>
    Private Sub createEquipmentFromOldRevision(ByVal equipment As EquipmentItem, ByVal shouldAsk As Boolean)
        Dim revisionForm As New SaveOldRevisionAsRevisionForm()

        If shouldAsk Then
            ' state - ask before saving as revision
            ' asks user if they want to revision old equipment
            Dim result As DialogResult = revisionForm.ShowDialog()
            If result = DialogResult.OK Then
                ' state - user chose to save and revision previous revision
                ' increments revision
                equipment.revision = equipment.latest_revision + 1
                ' inserts equipment into data source and copies local data to shared project
                Me.saveInProject(equipment)
                ' closes revision form
                revisionForm.Close()
            Else
                ' state - user cancelled revisioning old revision
                ' cancels save and revision
                ' closes revision form
                revisionForm.Close()
            End If
        Else
            ' state - revision w/out asking
            ' increments revision
            equipment.revision = equipment.latest_revision + 1
            ' inserts equipment into data source and copies local data to shared project
            Me.saveInProject(equipment)
        End If
    End Sub


    ''' <summary>Creates new equipment with a new name from the specified equipment.</summary>
    ''' <param name="equipment">Equipment to create new equipment from.</param>
    Private Sub createAsNewEquipment(ByVal equipment As EquipmentItem)
        Dim newPricingForm As New NewPricingForm()
        ' requests equipment name from user
        Dim result As DialogResult = newPricingForm.ShowDialog()

        ' does the user want to continue to save
        If result = Forms.DialogResult.OK Then
            ' state - user named equipment
            ' creates copy (save as) of current equipment
            Dim equipmentCopy As EquipmentItem
            ' clones equipment at current state
            equipmentCopy = InvokeMethod(Of EquipmentItem)(equipment, "Clone")
            ' generates a new ID for equipment (so it will be inserted not updated)
            equipmentCopy.id = New item_id(user.username, user.password)
            ' sets equipment's name
            equipmentCopy.name = newPricingForm.EquipmentName
            ' updates id and name changed event handler
            Me.Open(equipmentCopy)
            ' adds equipment to open project manager
            OpenedProject.Manager.Equipment.Add(equipmentCopy)
            ' inserts equipment to data source
            equipmentCopy.Save()
            ' adds name changed event handler
            Me.addHandlerForEquipmentNameChanged()
        Else
            ' state - user cancelled save
            ' cancels save; ends without saving equipment
        End If
        ' closes form used to get equipment name
        newPricingForm.Close()
    End Sub


    ''' <summary>Saves equipment.</summary>
    Private Function save() As Boolean

        save = True

        If OpenedProject.IsOpened Then
            If Not user.is(owner) Then
                saveAsRevision(False)
                Exit Function
            End If
        End If

        Try
            Me.ParentForm.Cursor = Cursors.WaitCursor

            ' gets equipment values from controls on form
            Dim currentEquipment = Me.grabEquipment()

            ' is a project opened
            If OpenedProject.IsOpened Then
                ' state - a project is opened
                ' does equipment exist in data source
                If currentEquipment.exists_in_data_source() = ExistenceStatus.Existent Then
                    ' state - equipment exists in data source
                    ' have changes been made to equipment
                    If Me.isSaved(currentEquipment) Then
                        ' state - NO changes have been made
                        ' ignores save
                    Else
                        ' state - changes have been made
                        ' is equipment the latest revision
                        If currentEquipment.is_latest_revision Then
                            ' state - is the latest revision
                            ' updates equipment to data source and copies local data to shared project
                            Me.saveInProject(currentEquipment)
                        Else
                            ' state - is not the latest revision
                            Me.createEquipmentFromOldRevision(currentEquipment, True)
                            ' updates revision view control
                            Me.updateRevisionView()
                        End If
                    End If
                Else
                    ' state - equipment does NOT exist in data source, but project does
                    currentEquipment.revision = Rae.RaeSolutions.DataAccess.Projects.ProjectsDataAccess.RetrieveLatestRevision(OpenedProject.Manager.Project.id.Id) + CSng(0.001)
                    Me.createNewEquipment(currentEquipment)
                End If
            Else
                ' state - a project is not opened
                currentEquipment.revision = 0.001
                save = Me.createNewProjectAndEquipment(currentEquipment)
            End If
        Catch ex As Exception
            Ui.MessageBox.Show("Attempt to save equipment failed. " & ex.Message)
            save = False
        Finally
            Me.ParentForm.Cursor = Cursors.Default
        End Try
    End Function


    ''' <summary>Saves changes on this form to the shared project.</summary>
    ''' <param name="localEquipment">The current equipment being editted on this form.</param>
    ''' <remarks>Other objects subscribe to the events of the shared, not local object.</remarks>
    Private Sub save(ByVal localEquipment As EquipmentItem)
        ' gets reference to the shared object of the equipment being displayed in the form
        Dim sharedEquipment = OpenedProject.Manager.Equipment.Items(localEquipment.id)
        If sharedEquipment Is Nothing Then
            Throw New ArgumentException("The equipment cannot be saved. The equipment ID is not in the project.")
        End If
        ' copies the current local state of the equipment on this form to the corresponding shared equipment 
        InvokeMethod(sharedEquipment, "Copy", localEquipment)
        ' saves shared equipment
        sharedEquipment.Save()
    End Sub


    ''' <summary>Saves equipment state as a new item.</summary>
    Private Sub saveAs()
        Try
            Me.ParentForm.Cursor = Cursors.WaitCursor

            Dim currentEquipment = Me.grabEquipment()

            ' is a project opened
            If OpenedProject.IsOpened Then
                ' state - a project is opened
                ' does equipment exist in data source
                If currentEquipment.exists_in_data_source = ExistenceStatus.Existent Then
                    ' state - equipment does exist in data source
                    Me.createAsNewEquipment(currentEquipment)
                Else
                    ' state - equipment does not exist
                    Me.createNewEquipment(currentEquipment)
                End If
            Else
                ' state - a project is not opened
                Me.createNewProjectAndEquipment(currentEquipment)
            End If
        Catch ex As System.Exception
            Ui.MessageBox.Show("Attempt to 'Save As' failed. " & ex.Message)
        Finally
            Me.ParentForm.Cursor = Cursors.Default
        End Try
    End Sub


    ''' <summary>Saves and sets revision as latest revision.</summary>
    Private Function saveAsRevision(Optional ByVal isOwner As Boolean = True) As Boolean
        saveAsRevision = True
        Try
            Me.ParentForm.Cursor = Cursors.WaitCursor

            Dim currentEquipment = Me.grabEquipment()

            ' is a project opened
            If OpenedProject.IsOpened Then
                ' state - a project is opened
                ' does equipment exist in data source
                If currentEquipment.exists_in_data_source = ExistenceStatus.Existent Then
                    ' state - equipment exists in data source
                    ' increments revision
                    currentEquipment.revision = CSng(System.Math.Round(currentEquipment.latest_revision + CSng(0.001), 3))
                    ' saves equipment and updates project
                    Me.saveInProject(currentEquipment)

                    ' if this is not the owner then we need to revision the project
                    'If Not isOwner Then
                    '   ProjectInfo.RevisionProject(currentEquipment.ProjectManager.Project.Id.Id, _
                    '      "NOTE: You are not the project owner.  (Owner: " & owner & ")")
                    '   ' state - equipment exists in data source
                    '   ' increments revision
                    '   currentEquipment.Revision = currentEquipment.LatestRevision
                    '   ' saves equipment and updates project
                    '   Me.SaveInProject(currentEquipment)
                    'End If

                    ' update RevisionView control
                    Me.updateRevisionView()
                Else
                    ' state - equipment does NOT exist in data source, but project does
                    Me.createNewEquipment(currentEquipment)

                    ' if this is not the owner then we need to revision the project
                    'If Not isOwner Then
                    '   ProjectInfo.RevisionProject(currentEquipment.ProjectManager.Project.Id.Id, _
                    '      "NOTE: You are not the project owner.  (Owner: " & owner & ")")
                    '   ' state - equipment exists in data source
                    '   ' increments revision
                    '   currentEquipment.Revision = currentEquipment.LatestRevision
                    '   ' saves equipment and updates project
                    '   Me.SaveInProject(currentEquipment)
                    'End If

                End If
            Else
                ' state - a project is NOT opened
                saveAsRevision = Me.createNewProjectAndEquipment(currentEquipment)
            End If

        Catch ex As Exception
            Ui.MessageBox.Show("Attempt to save and revision equipment failed. " & ex.Message)
            saveAsRevision = False
        Finally
            Me.ParentForm.Cursor = Cursors.Default
        End Try

    End Function


    ''' <summary>
    ''' Asks user to save unsaved changes to the latest revision before navigating revisions.
    ''' </summary>
    ''' <param name="equipmentToSave">Equipment with unsaved changes that user may want to save.</param>
    Private Sub saveBeforeNavigatingRevisions(ByVal equipmentToSave As EquipmentItem)
        ' asks user if they want to save
        Dim saveForm As New SaveBeforeNavigatingRevisionsForm()
        Dim result = saveForm.ShowDialog()

        If result = Forms.DialogResult.OK Then
            ' user chose to save
            Me.saveInProject(equipmentToSave)
        Else
            ' user chose not to save
        End If
        saveForm.Close()
    End Sub


    ''' <summary>
    ''' Asks user to save old revision with changes before navigating revisions.
    ''' </summary>
    ''' <param name="equipmentToSave">
    ''' Equipment that has changed and user may want to save as latest revision.
    ''' </param>
    Private Sub saveOldBeforeNavigatingRevisions(ByVal equipmentToSave As EquipmentItem)
        Dim saveForm As New SaveOldRevisionBeforeNavigatingRevisionsForm()
        Dim result As DialogResult = saveForm.ShowDialog()

        If result = Forms.DialogResult.OK Then
            ' user chose to save as revision
            ' sets revision to a new latest revision
            equipmentToSave.revision = equipmentToSave.latest_revision + 1
            ' saves and updates project
            Me.saveInProject(equipmentToSave)
            '' updates revision view control
            'Me.UpdateRevisionView()
        Else
            ' user chose not to save
        End If
        saveForm.Close()
    End Sub


    ''' <summary>Prompts user to save before navigating revisions.</summary>
    ''' <param name="currentRevision">Current revision being shown.</param>
    ''' <param name="changedRevision">Revision that is being navigated to.</param>
    Private Sub promptUserToSaveBeforeNavigation(ByVal previousRevision As Single, ByVal newRevision As Single)
        Dim currentEquipment = Me.grabEquipment()

        If isSaved(currentEquipment) Then Exit Sub

        ' checks if this revision is editable (only latest revision is editable)
        If previousRevision = currentEquipment.latest_revision() Then
            ' LATEST revision is being navigated away from
            Me.saveBeforeNavigatingRevisions(currentEquipment)
        Else
            ' OLD revision is being navigated away from
            ' saves old revision as the latest revision
            Me.saveOldBeforeNavigatingRevisions(currentEquipment)
            ' navigates to the revision the user selected
            ProjectInfo.Viewer.ViewEquipmentRevision(currentEquipment, newRevision)
            ' updates revision control
            Me.updateRevisionView()
        End If
    End Sub


    ''' <summary>Updates revision view control in main form.</summary>
    Private Sub updateRevisionView()
        AppInfo.Main.RevisionView1.UpdateRevisionView(Me, Nothing)
    End Sub

#End Region


    ''' <summary>Populates selected options dataset from the selected options and standard options grids</summary>
    Friend Sub populateSelectedOptionsDataSet(ByVal authorizedByIsShownInDescription As Boolean)
        ' clears dataset before filling
        Me.selectedOpsDs.Clear()

        For Each row As DataRow In Me.selectedOpTable.Rows
            If CBool(row(OCol.IsQuantityReadOnly)) And AppInfo.Division = Business.Division.CRI Then
                Me.selectedOpsDs.SelectedOptions.AddSelectedOptionsRow(CInt(row(OCol.ID)), "", _
                   row(OCol.Code).ToString, row(OCol.Category).ToString, row(OCol.Description).ToString, CDbl(row(OCol.Price)), _
                   "Included", CBool(row(OCol.IsVoltageDependent)), CInt(row(OCol.Voltage)), _
                   CBool(row(OCol.ContactFactory)), row(OCol.Details).ToString())
            Else
                Me.selectedOpsDs.SelectedOptions.AddSelectedOptionsRow(CInt(row(OCol.ID)), "", _
                   row(OCol.Code).ToString, row(OCol.Category).ToString, row(OCol.Description).ToString, CDbl(row(OCol.Price)), _
                   (row(OCol.Quantity).ToString), CBool(row(OCol.IsVoltageDependent)), CInt(row(OCol.Voltage)), _
                   CBool(row(OCol.ContactFactory)), row(OCol.Details).ToString())
            End If

            ' copies selected options
            'Me.selectedOpsDs.SelectedOptions.AddSelectedOptionsRow(CInt(row(OCol.ID)), "", _
            '   row(OCol.Code).ToString, row(OCol.Category).ToString, row(OCol.Description).ToString, CDbl(row(OCol.Price)), _
            '   (row(OCol.Quantity).ToString), CBool(row(OCol.IsVoltageDependent)), CInt(row(OCol.Voltage)), _
            '   CBool(row(OCol.ContactFactory)), row(OCol.Details).ToString())
        Next

        If Me.Equipment.series.ToUpper.StartsWith("35E2") Then

            Me.selectedOpsDs.SelectedOptions.AddSelectedOptionsRow(0, "", "  ", "", "Semi-hermetic rotary screw compressors with internal oil separators, service valves, and crankcase heaters", 999999, "", False, 0, False, "")
            Me.selectedOpsDs.SelectedOptions.AddSelectedOptionsRow(0, "", "  ", "", "(1) Shell and tube evaporator with heat tape tracing and 3/4"" closed cell insulation", 999999, "", False, 0, False, "")
            Me.selectedOpsDs.SelectedOptions.AddSelectedOptionsRow(0, "", "  ", "", "1/2"" Closed cell insulation on refrigerant suction and chilled fluid piping", 999999, "", False, 0, False, "")
            Me.selectedOpsDs.SelectedOptions.AddSelectedOptionsRow(0, "", "  ", "", "Electronic expansion valve with superheat controller on each circuit", 999999, "", False, 0, False, "")
        End If



        If Not Me.standardOpGrid.DataSource Is Nothing Then
            For Each row As DataRow In DirectCast(Me.standardOpGrid.DataSource, DataTable).Rows
                ' copies standard options

                If CBool(row(OCol.IsQuantityReadOnly)) And AppInfo.Division = Business.Division.CRI Then
                    Me.selectedOpsDs.SelectedOptions.AddSelectedOptionsRow(CInt(row(OCol.ID)), "",
                       row(OCol.Code).ToString, "", row(OCol.Description).ToString, CDbl(row(OCol.Price)),
                       "Included", CBool(row(OCol.IsVoltageDependent)), CInt(row(OCol.Voltage)),
                       CBool(row(OCol.ContactFactory)), row(OCol.Details).ToString())
                Else
                    Me.selectedOpsDs.SelectedOptions.AddSelectedOptionsRow(CInt(row(OCol.ID)), "",
                        row(OCol.Code).ToString, "", row(OCol.Description).ToString, CDbl(row(OCol.Price)),
                        row(OCol.Quantity).ToString, CBool(row(OCol.IsVoltageDependent)), CInt(row(OCol.Voltage)),
                        CBool(row(OCol.ContactFactory)), row(OCol.Details).ToString())
                End If

                'Me.selectedOpsDs.SelectedOptions.AddSelectedOptionsRow(CInt(row(OCol.ID)), "", _
                '   row(OCol.Code).ToString, "", row(OCol.Description).ToString, CDbl(row(OCol.Price)), _
                '   row(OCol.Quantity).ToString, CBool(row(OCol.IsVoltageDependent)), CInt(row(OCol.Voltage)), _
                '   CBool(row(OCol.ContactFactory)), row(OCol.Details).ToString())
            Next
        End If


        If Me.SpecialOptionsControl1.opGrid.RowCount > 0 Then
            Dim description As String
            For Each op As SpecialOption In Me.SpecialOptionsControl1.SpecialOptions
                If authorizedByIsShownInDescription Then
                    description = op.AuthorizedBy & " - " & op.Description
                Else
                    description = op.Description
                End If
                ' copies special options
                Me.selectedOpsDs.SelectedOptions.AddSelectedOptionsRow(0, "",
                   op.ToString, op.AuthorizedBy, description, op.Price.value, op.Quantity.value.ToString,
                   False, 0, False, "")
            Next
        End If
    End Sub

#End Region

    Friend Sub syncUnitVoltage()
        isAlreadySyncing = True

        ' sets the other unit voltage control in spec control
        InvokeMethod(Me.specsControl, methodName_GetControlValues, Me.Equipment)
        Me.Equipment.common_specs.UnitVoltage.Parse(Me.cboUnitVoltage.SelectedItem.ToString())
        InvokeMethod(Me.specsControl, methodName_SetControlValues, Me.Equipment)

        isAlreadySyncing = False
    End Sub

#Region " Abstract"

    ''' <summary>Grabs equipment info from the form</summary>
    Friend Function grabEquipment(Optional ByVal includePumpOpsForChiller As Boolean = False) As EquipmentItem

        Me.Equipment.series = Me.EquipmentSelector1.Series
        If Not Me.EquipmentSelector1.Model Is Nothing Then
            Me.Equipment.model_without_series = Me.EquipmentSelector1.Model
        Else
            Me.Equipment.model_without_series = ""
        End If

        Me.Equipment.custom_model = Me.txtCustomModel.Text.Trim

        Me.Equipment.pricing.quantity = CNull.ToInteger(Me.txtUnitQuantity.Text.Trim)

        With Me.Equipment.pricing
            .base_list_price_is_overridden = overrideBaseListCheck.Checked
            .overridden_base_list_price = grabPrice(Me.overrideBaseListText)
            .warranty = Me.grabPrice(Me.txtFourYearCompressorWarranty)
            .freight = Me.grabPrice(Me.txtFreight)
            .start_up = Me.grabPrice(Me.txtStartUp)
            ' TODO: re-implement other costs
            .other_description = Me.txtOtherDescription.Text.Trim
            .other_price = Me.grabPrice(Me.txtOther)
            '.Others = Me.GrabPrice(Me.txtOther)
            '.OtherDescription = Me.txtOtherDescription.Text
            .par_multiplier = Me.GrabParMultiplier()
            ' if multiplierCodeIsApplied Then
            If multiplierCodeTextBox.ReadOnly Then
                .multiplier_code = New MultiplierCode(multiplierCodeTextBox.Text)
            Else
                .multiplier_code = Nothing
            End If
            .list_price = grabBaseList()
            If Not ddCentury.SelectedItem Is Nothing Then
                .multiplier_type = Me.ddCentury.SelectedItem.ToString()
            Else
                .multiplier_type = ""
            End If
        End With

        ' adds options
        Equipment.options.Clear()
        For Each row As DataRow In Me.selectedOpTable.Rows
            Dim code = row(OCol.Code).ToString
            ' if not four year compressor warranty
            ' and ( not (integrated pump option)
            '       or should include pump option)
            If code <> "FYCW" _
            AndAlso (Not (Equipment.type = EquipmentType.Chiller _
                            AndAlso (pump_package_code.matches(code) _
                                      OrElse CType(presenter, chiller_presenter).is_pump_option(code))) _
                      OrElse includePumpOpsForChiller) Then
                Dim op = rowToOption(row)
                Equipment.options.Add(op)
            End If
        Next

        ' grabs special options
        Me.Equipment.special_options = Me.SpecialOptionsControl1.SpecialOptions

        ' updates options revision
        Me.Equipment.revision = Me.Equipment.revision

        ' updates equipment with info from spec control
        InvokeMethod(Me.specsControl, Me.methodName_GetControlValues, Me.Equipment)


        If Me.Equipment.division = NotSet Then
            Me.Equipment.division = AppInfo.Division
        End If


        ' blargg - hide NMB and NMC
        '        Me.EquipmentSelector1.cbo_series.Items.Remove("NMB")
        '        Me.EquipmentSelector1.cbo_series.Items.Remove("NMC")
        Return Me.Equipment
    End Function


    ''' <summary>Displays values from equipment in controls</summary>
    Private Sub displayEquipment(ByVal equip As EquipmentItem)
        ' clones equipment b/c on model changed could modify equipment and the saved data could get written over
        Me.Equipment = InvokeMethod(Of EquipmentItem)(equip, "Clone")

        Select Case equip.type
            Case EquipmentType.ProductCooler, EquipmentType.FluidCooler, EquipmentType.UnitCooler, EquipmentType.NotSet
                ' disables convert to rating menu item
                Me.mnuConvert.Enabled = False
                Me.mnuConvert.ToolTipText = "There is not a rating for this equipment type."
            Case Else
                Me.mnuConvert.Enabled = True
                Me.mnuConvert.ToolTipText = ""
        End Select

        With equip
            Me.Tag = .id.ToString
            Me.Text = .name

            Dim series As String = .series
            Dim model As String = .model_without_series
            ' sets specs required to determine available options
            EquipmentSelector1.User = user
            EquipmentSelector1.EquipmentType = .type.ToString
            EquipmentSelector1.Series = series
            EquipmentSelector1.Model = model

            'workaround: until i find out a better way
            If EquipmentSelector1.Series Like "35*" Then
                equip.common_specs.Mca.set_to(Equipment.common_specs.Mca.value)
                equip.common_specs.Rla.set_to(Equipment.common_specs.Rla.value)
            End If
            ' Note: invoke SetControlValues before setting the voltage; otherwise values are written over when the form first opens
            ' sets controls in spec control
            InvokeMethod(specsControl, methodName_SetControlValues, equip)   ' This is wiping weight
            Me.cboUnitVoltage.SelectedIndex = Me.cboUnitVoltage.Items.IndexOf(.common_specs.UnitVoltage.ToString)  ' RAE.UI.ListHelper.IndexOfComboBoxItem(Me.cboUnitVoltage, .CommonSpecs.UnitVoltage.ToString)

            Me.txtCustomModel.Text = CNull.ToString(.custom_model)

            Me.txtUnitQuantity.Text = .pricing.quantity.ToString

            ' sets pricing
            Me.displayPrice(Me.txtFourYearCompressorWarranty, .pricing.warranty)
            Me.displayPrice(Me.txtFreight, .pricing.freight)
            Me.displayPrice(Me.txtStartUp, .pricing.start_up)
            Me.displayPrice(Me.txtOther, .pricing.other_price)
            displayPrice(overrideBaseListText, .pricing.overridden_base_list_price)
            overrideBaseListCheck.Checked = .pricing.base_list_price_is_overridden

            If .pricing.base_list_price_is_overridden Then

                Dim unitQuantity As Integer
                unitQuantity = Me.grabUnitQuantity()

                txtOverrideBaseListPerUnit.Text = CStr(.pricing.overridden_base_list_price / unitQuantity)


                If Not String.IsNullOrEmpty(txtOverrideBaseListPerUnit.Text) AndAlso IsNumeric(txtOverrideBaseListPerUnit.Text) Then

                    overrideBaseListText.Text = CStr(CDbl(txtOverrideBaseListPerUnit.Text) * unitQuantity)

                Else
                    overrideBaseListText.Text = "0"
                End If



            End If

            Me.txtOtherDescription.Text = .pricing.other_description

            ' TODO: re-implement other costs
            'Me.DisplayPrice(Me.txtOther, .OtherPrice)
            'Me.txtOtherDescription.Text = .OtherDescription
            If .pricing.multiplier_code IsNot Nothing Then
                Me.multiplierCodeTextBox.Text = .pricing.multiplier_code.Code
                setCustomMultiplier(.pricing.multiplier_code.Multiplier, _
                                    .pricing.multiplier_code.Commission)
                formatAfterCustomMultiplierApplied()
            Else
                Me.cboParMultiplier.SelectedIndex = Me.IndexOfDisplayMember(.pricing.par_multiplier)

                If .pricing.par_multiplier <> 0 Then
                    If .pricing.par_multiplier < 0.29 Then
                        Me.NumericUpDown1.Minimum = CDec(0.281)
                        Me.NumericUpDown1.Value = CDec(.pricing.par_multiplier)
                    Else
                        Me.NumericUpDown1.Value = CDec(.pricing.par_multiplier)
                    End If
                End If
            End If

            ' resets options total price since the options change when the model changes
            Me.displayTotalOptionsPrice(0, 0)

            availableOpGrid.RemoveAll()
            ' checks if values that are necessary to retrieve options have been set yet
            If validateOptionRetrievalInputs() Then
                lblNoOptions.Visible = False
                populateAvailableOptionsGrid()
                populateStandardOptionsGrid()
                ' sets selected options grid structure
                ' TEST: Is table structure set anywhere else, if it is not set here
                selectedOpTable = getOptionsTableStructure()
                selectedOpGrid.DataSource = selectedOpTable
                Me.selectedOpGrid.Columns(OCol.Selected).HeaderText = "Select"
                Me.selectedOpGrid.Columns(OCol.Code).HeaderText = "Code"
                Me.selectedOpGrid.Columns(OCol.Description).HeaderText = "Description"
                Me.selectedOpGrid.Columns(OCol.Category).HeaderText = "Category"
                Me.selectedOpGrid.Columns(OCol.Price).HeaderText = "Price"
                Me.selectedOpGrid.Columns(OCol.Per).HeaderText = "Per"
                Me.selectedOpGrid.Columns(OCol.Quantity).HeaderText = "Quantity"
                Me.selectedOpGrid.Columns(OCol.Selected).Width = 55
                Me.selectedOpGrid.Columns(OCol.Code).Width = 45
                Me.selectedOpGrid.Columns(OCol.Description).Width = 185
                Me.selectedOpGrid.Columns(OCol.Category).Width = 115
                Me.selectedOpGrid.Columns(OCol.Price).Width = 65
                Me.selectedOpGrid.Columns(OCol.Per).Width = 50
                Me.selectedOpGrid.Columns(OCol.Quantity).Width = 55


                Me.selectedOpGrid.Columns(OCol.Code).Visible = True
                Me.selectedOpGrid.Columns(OCol.Quantity).Visible = True
                Me.selectedOpGrid.Columns(OCol.IsSelectedReadOnly).Visible = False
                Me.selectedOpGrid.Columns(OCol.IsQuantityReadOnly).Visible = False
                Me.selectedOpGrid.Columns(OCol.IsVoltageDependent).Visible = False
                Me.selectedOpGrid.Columns(OCol.Voltage).Visible = False
                Me.selectedOpGrid.Columns(OCol.ContactFactory).Visible = False
                Me.selectedOpGrid.Columns(OCol.IsDependent).Visible = False
                Me.selectedOpGrid.Columns(OCol.Price).Visible = True
                Me.selectedOpGrid.Columns(OCol.Details).Visible = False
                Me.selectedOpGrid.Columns(OCol.MasterId).Visible = False
                Me.selectedOpGrid.Columns(OCol.ID).Visible = False
                Me.selectedOpGrid.Columns(OCol.Description).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.selectedOpGrid.Columns(OCol.Category).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.selectedOpGrid.Columns(OCol.Price).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Me.selectedOpGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray

                Me.selectedOpGrid.EnableHeadersVisualStyles = False
                Me.selectedOpGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue
                availableOpGrid.Select(.options)
            End If

            Me.SpecialOptionsControl1.SpecialOptions = .special_options

            If Equipment.type = EquipmentType.Chiller _
            AndAlso CType(equip, chiller_equipment).has_pump_package Then
                CType(presenter, chiller_presenter).select_pump_package_option()
            End If

            'calculates and displays prices on pricing tab
            calculateAndDisplayPrices()

            ' four year compressor warranty
            If .pricing.warranty > 0 Then
                chkFourYearCompressorWarranty.Checked = True
            End If

        End With

        setDefaults()
    End Sub

#End Region


#Region " Compressor Warranty"

    Private Sub chkFourYearCompressorWarranty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFourYearCompressorWarranty.CheckedChanged
        txtFourYearCompressorWarranty.Enabled = chkFourYearCompressorWarranty.Checked
        If chkFourYearCompressorWarranty.Checked = False Then txtFourYearCompressorWarranty.Text = ""
        For Each r As DataRow In Me.availableOpTable.Rows
            If CNull.ToString(r(OCol.Code)) = "FYCW" Then
                r(OCol.Selected) = chkFourYearCompressorWarranty.Checked
            End If
        Next

        Dim nfsp As Double
        Dim othersTotalPrice As Double
        Try
            ' calculates total others price
            othersTotalPrice = Intelligence.PriceCalculator.CalculateTotalOtherPrice(Me.grabPrice(Me.txtFourYearCompressorWarranty), Me.grabPrice(Me.txtFreight), Me.grabPrice(Me.txtStartUp), Me.grabPrice(Me.txtOther))
            ' calculates nfsp
            nfsp = Intelligence.PriceCalculator.CalculateNfspPrice(Me.grabPrice(Me.lblParPrice), othersTotalPrice)
            ' displays nfsp
            Me.displayPrice(Me.lblNfsp, nfsp)

            ' formats entered
            'Dim textB As TextBox = CType(sender, TextBox)
            'Me.displayPrice(textB, Me.grabPrice(textB))
        Catch ex As Exception
            Ui.MessageBox.Show("Invalid format of price.", MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub label1mouseenter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.MouseEnter
        Label1.Image = My.Resources.Message
    End Sub

    Private Sub label1mouseleave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.MouseLeave
        Label1.Image = My.Resources.Info
    End Sub

    Private Sub label1click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Dim msgstr As String = "Warranties extending an additional 4 years to the standard compressor warranty are available." & vbCrLf & _
                               "The warranty simply extends the warranty period an additional 4 years and is valid for that " & vbCrLf & _
                               "compressor, utilized in the original equipment for the 5-year period. Extended warranties may" & vbCrLf & _
                               "be purchased prior to the start up date, but not after the unit is initially started. The " & vbCrLf & _
                               "warranty is not transferable to customers other than the initial purchaser."
        Forms.MessageBox.Show(msgstr, "Four Year Compressor Warranty", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    ''' <summary>
    ''' ask user if they would like to add four year compressor warranty
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SuggestFourYearCompressorWarranty()
        Dim infomessage As String = "Warranties extending an additional 4 years to the standard compressor warranty are available." & vbCrLf & _
                         "The warranty simply extends the warranty period an additional 4 years and is valid for that " & vbCrLf & _
                         "compressor, utilized in the original equipment for the 5-year period. Extended warranties may" & vbCrLf & _
                         "be purchased prior to the start up date, but not after the unit is initially started. The " & vbCrLf & _
                         "warranty is not transferable to customers other than the initial purchaser."
        Dim infocaption As String = "Four Year Compressor Warranty"
        Dim frm As New SuggestedOptionsForm("Would you like an additional four years on your compressor warranty?", "This will make a total 5 year compressor warranty.", "Compressor Warranty", infomessage, infocaption)
        frm.ShowDialog()
        If frm.AddOption = True Then
            chkFourYearCompressorWarranty.Checked = True
        End If
        fourYearCompressorWarrantyPromptHasBeenShownAlready = True
        frm = Nothing
    End Sub

#End Region


    Private Sub setDefaults()
        ensureSelectionIn(cboUnitVoltage)
    End Sub

    Private Sub ensureSelectionIn(ByVal comboBox As ComboBox)
        If comboBox.SelectedIndex = -1 AndAlso comboBox.Items.Count > 0 Then
            comboBox.SelectedIndex = 0
        End If
    End Sub

    Private Sub displayQuantity(ByVal quantity As Integer)
        Dim quantityText As String
        quantityText = "(Qty " & quantity.ToString() & ")"

        Me.totalBaseListPriceQuantityLabel.Text = quantityText
        Me.totalSelectedOptionsQuantityLabel.Text = quantityText
        Me.totalSpecialOptionsQuantityLabel.Text = quantityText
    End Sub


    Friend Function grabBaseList() As Double
        Dim baseList As Double

        If overrideBaseListCheck.Checked Then
            baseList = grabPrice(overrideBaseListText)
        Else
            baseList = grabPrice(lblSummaryBaseListPrice)
        End If

        Return baseList
    End Function


    Protected ReadOnly Property user As user
        Get
            Return AppInfo.User
        End Get
    End Property


    Private ReadOnly Property owner As String
        Get
            Dim projectId As item_id = OpenedProject.Manager.Project.id

            Return ProjectInfo.GetProjectOwner(projectId)
        End Get
    End Property

    Private Sub applyMultiplierCode(ByVal customMultiplierCode As String)
        Dim c As MultiplierCode

        Try
            c = New MultiplierCode(customMultiplierCode.Trim)
        Catch ex As Exception
            Ui.MessageBox.Show("The multiplier code cannot be applied. It is invalid.", _
               MessageBoxIcon.Warning)
            Exit Sub
        End Try

        If c.IsExpired(Date.Now) Then
            Ui.MessageBox.Show("The multiplier code cannot be applied. It is expired.", _
               MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' set values and format for controls
        setCustomMultiplier(c.Multiplier, c.Commission)
        formatAfterCustomMultiplierApplied()
    End Sub

    Private Sub formatAfterCustomMultiplierApplied()
        multiplierCodeTextBox.ReadOnly = True
        cboParMultiplier.Enabled = False
        NumericUpDown1.Enabled = False
        ''multiplierCodeAppliedPicture.Visible = True
        discontinueMultiplierCodeButton.Visible = True
        applyMultiplierCodeButton.Visible = False
    End Sub

    Private Sub setCustomMultiplier(ByVal multiplier As Double, ByVal commission As Double)
        Dim table As New DataTable("Custom")
        table.Columns.Add(New DataColumn("Multiplier", GetType(Double)))
        table.Columns.Add(New DataColumn("Commission", GetType(Double)))
        table.Rows.Add(New Object() {multiplier, commission})

        If AppInfo.Division = CRI Then
            NumericUpDown1.Value = CDec(multiplier)
        Else
            cboParMultiplier.DataSource = table
            cboParMultiplier.SelectedIndex = 0
        End If

        displayPercent(lblCommissionRate, commission)
    End Sub

    Private Sub applyMultiplierCodeButton_Click(ByVal s As Object, ByVal e As EventArgs) _
    Handles applyMultiplierCodeButton.Click
        applyMultiplierCode(multiplierCodeTextBox.Text)
    End Sub

    Private Sub discontinueMultiplierCodeButton_Click(ByVal s As Object, ByVal e As EventArgs) _
    Handles discontinueMultiplierCodeButton.Click
        populateMultipliersAndCommissionRates()

        multiplierCodeTextBox.ReadOnly = False
        cboParMultiplier.Enabled = True
        NumericUpDown1.Enabled = True
        ''multiplierCodeAppliedPicture.Visible = False
        applyMultiplierCodeButton.Visible = True
        discontinueMultiplierCodeButton.Visible = False
    End Sub

    ''Private Sub groupLink_Toggled(ByVal s As Object, ByVal e As Rae.Ui.Controls.ToggledEventArgs) _
    ''Handles groupLink.Toggled
    ''    If e.IsToggled Then _
    ''       availableOpGrid.Ungroup() _
    ''    Else _
    ''    ''availableOpGrid.GroupByCategory()
    ''End Sub

    ''Private Sub unselectLink_Click(ByVal s As Object, ByVal e As EventArgs) _
    ''Handles unselectLink.Click
    ''    availableOpGrid.UnselectAll()
    ''End Sub

    ''' <summary>Converts an option row to an option object</summary>
    ''' <param name="optionRow">DataRow to convert to Option object.</param>
    ''' <exception cref="System.ArgumentException">Thrown when optionRow can not be converted to option object 
    ''' because of table structure
    ''' </exception>
    Protected Function rowToOption(ByVal optionRow As DataRow) As EquipmentOption
        Return RowTo.Option(optionRow, Equipment)
    End Function

    Private Sub txtOverrideBaseListPerUnit_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOverrideBaseListPerUnit.Leave


        If Not String.IsNullOrEmpty(txtOverrideBaseListPerUnit.Text) AndAlso IsNumeric(txtOverrideBaseListPerUnit.Text) Then
            Dim unitQuantity As Integer
            unitQuantity = Me.grabUnitQuantity()

            overrideBaseListText.Text = CStr(CDbl(txtOverrideBaseListPerUnit.Text) * unitQuantity)

        Else
            overrideBaseListText.Text = "0"
        End If



        Try
            displayPrice(overrideBaseListText, grabBaseList())
            calculateAndDisplayPrices()
        Catch ex As Exception
            Ui.MessageBox.Show("Invalid format for price", MessageBoxIcon.Warning)
        End Try


    End Sub
    Private Sub availableOpGrid_Ungrouped(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles availableOpGrid.Ungrouped

    End Sub
    Private Sub availableOpGrid_Grouped(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles availableOpGrid.GroupedByCategory

    End Sub

    Private Sub overrideBaseListText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles overrideBaseListText.TextChanged

    End Sub


    ''Private Sub groupLink_Toggled(ByVal sender As Rae.Ui.Controls.ToggleLink, ByVal e As Rae.Ui.Controls.ToggledEventArgs) Handles groupLink.Toggled

    ''End Sub


    Private Sub tabPricing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabPricing.Click

    End Sub


    Private Sub mnu_equipment_proposal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_equipment_proposal.Click
        Dim x As String = ""
    End Sub

    Private Sub SpecialOptionsControl1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ddCentury_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddCentury.SelectedIndexChanged
        If Not ddCentury.SelectedItem Is Nothing Then
            If ddCentury.SelectedItem.ToString() = "Resco" Then
                NumericUpDown1.Minimum = CDec(0.281)

                If CDec(NumericUpDown1.Value) = 0.29 Then
                    NumericUpDown1.Value = CDec(0.3193)
                End If

                NumericUpDown1.UpButton()
                NumericUpDown1.DownButton()
            Else
                NumericUpDown1.Minimum = CDec(0.29)
                NumericUpDown1.UpButton()
                NumericUpDown1.DownButton()
            End If
        End If
    End Sub
End Class

Module RowTo

    ''' <summary>Converts an option row to an option object</summary>
    ''' <param name="optionRow">DataRow to convert to Option object.</param>
    ''' <exception cref="System.ArgumentException">Thrown when optionRow can not be converted to option object 
    ''' because of table structure
    ''' </exception>
    Function [Option](ByVal optionRow As DataRow, ByVal equipment As EquipmentItem) As EquipmentOption
        Dim op As New EquipmentOption

        With optionRow.Table.Columns
            ' performs reasonable test on table to ensure the rows can be converted to an option object
            If Not (.Contains(OCol.ID) AndAlso .Contains(OCol.Code) _
                    AndAlso CInt(optionRow(OCol.ID)) > 0) Then
                Throw New ArgumentException("The row can not be converted to an option object. The optionRow parameter's table structure is not supported")
            End If
        End With

        ' sets option properties
        op.PricingId = CInt(optionRow(OCol.ID))
        op.Code = optionRow(OCol.Code).ToString
        op.Description = optionRow(OCol.Description).ToString
        op.Category = optionRow(OCol.Category).ToString
        ' TEST: set when voltage is set
        'op.IsVoltageDependent = CNull.ToBoolean(optionRow(OCol.IsVoltageDependent))
        op.Voltage = CNull.ToInteger(optionRow(OCol.Voltage))
        op.Price = CNull.ToDouble(optionRow(OCol.Price))
        op.Quantity = CNull.ToInteger(optionRow(OCol.Quantity))
        op.MasterId = CNull.ToInteger(optionRow(OCol.MasterId))
        op.Per = CNull.ToString(optionRow(OCol.Per))
        op.Equipment = equipment

        Return op
    End Function

End Module

'Convert(op).In(table).ToRow

Public Class Converter

    Private row As DataRow
    Private op As EquipmentOption

    Private Sub New(ByVal op As EquipmentOption)
        Me.op = op
    End Sub

    Shared Function Convert(ByVal op As EquipmentOption) As Converter
        Return New Converter(op)
    End Function

    Function [In](ByVal table As DataTable) As Converter
        row = Convert(op, table)
        Return Me
    End Function

    Function ToRow() As DataRow
        Return row
    End Function

    Private Function convert(ByVal op As EquipmentOption, ByVal table As DataTable) As DataRow
        Dim r As DataRow = table.NewRow

        r(OCol.ID) = op.Id
        r(OCol.Code) = op.Code
        r(OCol.ContactFactory) = op.ContactFactory
        r(OCol.Description) = op.Description
        r(OCol.Category) = op.Category
        r(OCol.Voltage) = op.Voltage
        r(OCol.Price) = op.Price
        r(OCol.Quantity) = op.Quantity
        r(OCol.MasterId) = op.MasterId

        r(OCol.IsQuantityReadOnly) = op.IsQuantityReadOnly
        r(OCol.IsVoltageDependent) = op.IsVoltageDependent
        r(OCol.IsDependent) = op.IsDependentCommonOption
        r(OCol.IsSelectedReadOnly) = op.IsSelectedReadOnly
        r(OCol.Per) = op.Per

        Return r
    End Function

End Class

' 4232 on 2006/1/10
' 6310 on 2018/8/7