Option Strict On
Option Explicit On

Imports C1.Win.C1TrueDBGrid
Imports C1.Win.C1TrueDBGrid.RowTypeEnum
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.Shared
Imports Rae.RaeSolutions.Business
Imports Rae.RaeSolutions.Business.Division
Imports Rae.RaeSolutions.Business.Entities
imports rae.solutions
Imports rae.solutions.drawings
imports rae.solutions.group
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

Imports OCol = Rae.RaeSolutions.DataAccess.Projects.Tables.OptionsObjectTable
Imports DCol = Rae.RaeSolutions.DataAccess.DependentCommonOptions.DependentCommmonOptionsColumnNames
Imports CommonEquipmentDa = Rae.RaeSolutions.DataAccess.Projects.CommonEquipmentDa
Imports EquipmentDataAccess = Rae.RaeSolutions.DataAccess.Projects.EquipmentDataAccess
Imports CNull = Rae.ConvertNull
Imports Intelligence = Rae.RaeSolutions.Business.Intelligence
Imports Forms = System.Windows.Forms

''' <summary>Form for selecting and entering equipment information</summary>
Partial Class EquipmentForm
   Inherits System.Windows.Forms.Form

   Protected presenter As equipment_pricing_presenter_base
   
   Protected Overridable Function create_presenter() As equipment_pricing_presenter_base
      throw new exception("Presenter not implemented.")
   End Function

#Region " Windows Form Designer generated code "
   
   Public Sub New()
      MyBase.New()
      
      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call
      loadEngineeringData = AddressOf loadEngineeringDataFor
      convertToProcess    = AddressOf convertToProcessItem
      AddHandler Me.FormClosing, AddressOf onFormClosing
      
      presenter = create_presenter()
   End Sub

   'Form overrides dispose to clean up the component list.
   Protected Overloads Overrides Sub Dispose(disposing As Boolean)
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
   Friend WithEvents multiplierCodeAppliedPicture As Rae.Ui.Controls.TransparentPictureBox
   Friend WithEvents optionToolbarPanel As System.Windows.Forms.Panel
   Friend WithEvents infoReviewLabel As System.Windows.Forms.Label
   Friend WithEvents groupLink As Rae.Ui.Controls.ToggleLink
   Friend WithEvents unselectLink As Rae.Ui.Controls.Link
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
Me.multiplierCodeAppliedPicture = New Rae.Ui.Controls.TransparentPictureBox()
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
Me.selectedOpGrid = New Rae.RaeSolutions.SelectedOptionGrid()
Me.selectedAvailableOptionsPriceLabel = New System.Windows.Forms.Label()
Me.Splitter2 = New System.Windows.Forms.Splitter()
Me.panSpecialOptionsSummary = New System.Windows.Forms.Panel()
Me.specialOpGrid = New Rae.RaeSolutions.SpecialOptionGrid()
Me.lblSpecialOptionsSummaryTotalPriceLabel = New System.Windows.Forms.Label()
Me.lblSpecialOptionsSummaryTotalPrice = New System.Windows.Forms.Label()
Me.Splitter1 = New System.Windows.Forms.Splitter()
Me.panSelectedOptions = New System.Windows.Forms.Panel()
Me.infoReviewLabel = New System.Windows.Forms.Label()
Me.standardOpGrid = New Rae.RaeSolutions.StandardOptionGrid()
Me.tabAvailableOptions = New System.Windows.Forms.TabPage()
Me.availableOptionsPanel = New System.Windows.Forms.Panel()
Me.lblNoOptions = New System.Windows.Forms.Label()
Me.optionToolbarPanel = New System.Windows.Forms.Panel()
Me.unselectLink = New Rae.Ui.Controls.Link()
Me.groupLink = New Rae.Ui.Controls.ToggleLink()
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
Me.barRefrigerantPiping = New System.Windows.Forms.ToolStripMenuItem()
Me.barFluidPiping = New System.Windows.Forms.ToolStripMenuItem()
Me.barConvert = New System.Windows.Forms.ToolStripButton()
Me.SaveToolStripPanel1 = New Rae.RaeSolutions.SaveToolStripPanel()
CType(Me.selectedOpsDs, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.orderReportErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.submittalReportErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
Me.tabPricing.SuspendLayout()
CType(Me.multiplierCodeAppliedPicture, System.ComponentModel.ISupportInitialize).BeginInit()
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
Me.tabPricing.Controls.Add(Me.multiplierCodeAppliedPicture)
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
Me.tabPricing.Size = New System.Drawing.Size(543, 504)
Me.tabPricing.TabIndex = 2
Me.tabPricing.Text = "Pricing"
Me.tabPricing.UseVisualStyleBackColor = True
'
'multiplierCodeAppliedPicture
'
Me.multiplierCodeAppliedPicture.BackColor = System.Drawing.Color.Transparent
Me.multiplierCodeAppliedPicture.Image = CType(resources.GetObject("multiplierCodeAppliedPicture.Image"), System.Drawing.Image)
Me.multiplierCodeAppliedPicture.ImageList = Nothing
Me.multiplierCodeAppliedPicture.ImageListIndex = 3
Me.multiplierCodeAppliedPicture.Location = New System.Drawing.Point(202, 190)
Me.multiplierCodeAppliedPicture.Name = "multiplierCodeAppliedPicture"
Me.multiplierCodeAppliedPicture.Size = New System.Drawing.Size(21, 21)
Me.multiplierCodeAppliedPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
Me.multiplierCodeAppliedPicture.TabIndex = 59
Me.multiplierCodeAppliedPicture.TabStop = False
Me.multiplierCodeAppliedPicture.TransparentColor = System.Drawing.Color.Fuchsia
Me.multiplierCodeAppliedPicture.Visible = False
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
Me.overrideBaseListText.Location = New System.Drawing.Point(367, 66)
Me.overrideBaseListText.Name = "overrideBaseListText"
Me.overrideBaseListText.ReadOnly = True
Me.overrideBaseListText.Size = New System.Drawing.Size(100, 21)
Me.overrideBaseListText.TabIndex = 47
Me.overrideBaseListText.Text = "$0"
'
'overrideBaseListLabel
'
Me.overrideBaseListLabel.BackColor = System.Drawing.Color.Transparent
Me.overrideBaseListLabel.Location = New System.Drawing.Point(243, 66)
Me.overrideBaseListLabel.Name = "overrideBaseListLabel"
Me.overrideBaseListLabel.Size = New System.Drawing.Size(133, 21)
Me.overrideBaseListLabel.TabIndex = 49
Me.overrideBaseListLabel.Text = "Override total base list"
Me.overrideBaseListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'overrideBaseListCheck
'
Me.overrideBaseListCheck.Location = New System.Drawing.Point(223, 67)
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
Me.tabOptionsSummary.Size = New System.Drawing.Size(543, 504)
Me.tabOptionsSummary.TabIndex = 3
Me.tabOptionsSummary.Text = "Option Summary"
Me.tabOptionsSummary.UseVisualStyleBackColor = True
'
'panOptionsSummary
'
Me.panOptionsSummary.Controls.Add(Me.selectedCommonOptionsPriceLabel)
Me.panOptionsSummary.Controls.Add(Me.selectedCommonOptionsLabel)
Me.panOptionsSummary.Controls.Add(Me.selectedAvailableOptionsLabel)
Me.panOptionsSummary.Controls.Add(Me.selectedOpGrid)
Me.panOptionsSummary.Controls.Add(Me.selectedAvailableOptionsPriceLabel)
Me.panOptionsSummary.Dock = System.Windows.Forms.DockStyle.Fill
Me.panOptionsSummary.Location = New System.Drawing.Point(0, 298)
Me.panOptionsSummary.Name = "panOptionsSummary"
Me.panOptionsSummary.Size = New System.Drawing.Size(543, 206)
Me.panOptionsSummary.TabIndex = 54
'
'selectedCommonOptionsPriceLabel
'
Me.selectedCommonOptionsPriceLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.selectedCommonOptionsPriceLabel.BackColor = System.Drawing.Color.Transparent
Me.selectedCommonOptionsPriceLabel.ForeColor = System.Drawing.Color.Blue
Me.selectedCommonOptionsPriceLabel.Location = New System.Drawing.Point(447, 157)
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
Me.selectedCommonOptionsLabel.Location = New System.Drawing.Point(261, 157)
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
Me.selectedAvailableOptionsLabel.Location = New System.Drawing.Point(220, 180)
Me.selectedAvailableOptionsLabel.Name = "selectedAvailableOptionsLabel"
Me.selectedAvailableOptionsLabel.Size = New System.Drawing.Size(221, 23)
Me.selectedAvailableOptionsLabel.TabIndex = 52
Me.selectedAvailableOptionsLabel.Text = "Selected available options total (per unit)"
Me.selectedAvailableOptionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'selectedOpGrid
'
Me.selectedOpGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.selectedOpGrid.Caption = "Selected Available Options Summary"
Me.selectedOpGrid.CaptionHeight = 24
Me.selectedOpGrid.GroupByCaption = "Drag a column header here to group by that column"
Me.selectedOpGrid.Images.Add(CType(resources.GetObject("selectedOpGrid.Images"), System.Drawing.Image))
Me.selectedOpGrid.IsPriceVisible = False
Me.selectedOpGrid.Location = New System.Drawing.Point(12, 6)
Me.selectedOpGrid.Name = "selectedOpGrid"
Me.selectedOpGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
Me.selectedOpGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
Me.selectedOpGrid.PreviewInfo.ZoomFactor = 75.0R
Me.selectedOpGrid.PrintInfo.PageSettings = CType(resources.GetObject("selectedOpGrid.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
Me.selectedOpGrid.RowHeight = 15
Me.selectedOpGrid.Size = New System.Drawing.Size(519, 150)
Me.selectedOpGrid.TabIndex = 50
Me.selectedOpGrid.Text = "C1TrueDBGrid1"
Me.selectedOpGrid.PropBag = resources.GetString("selectedOpGrid.PropBag")
'
'selectedAvailableOptionsPriceLabel
'
Me.selectedAvailableOptionsPriceLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.selectedAvailableOptionsPriceLabel.BackColor = System.Drawing.Color.Transparent
Me.selectedAvailableOptionsPriceLabel.ForeColor = System.Drawing.Color.Blue
Me.selectedAvailableOptionsPriceLabel.Location = New System.Drawing.Point(447, 180)
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
Me.Splitter2.Size = New System.Drawing.Size(543, 8)
Me.Splitter2.TabIndex = 56
Me.Splitter2.TabStop = False
'
'panSpecialOptionsSummary
'
Me.panSpecialOptionsSummary.Controls.Add(Me.specialOpGrid)
Me.panSpecialOptionsSummary.Controls.Add(Me.lblSpecialOptionsSummaryTotalPriceLabel)
Me.panSpecialOptionsSummary.Controls.Add(Me.lblSpecialOptionsSummaryTotalPrice)
Me.panSpecialOptionsSummary.Dock = System.Windows.Forms.DockStyle.Top
Me.panSpecialOptionsSummary.Location = New System.Drawing.Point(0, 165)
Me.panSpecialOptionsSummary.Name = "panSpecialOptionsSummary"
Me.panSpecialOptionsSummary.Size = New System.Drawing.Size(543, 125)
Me.panSpecialOptionsSummary.TabIndex = 55
'
'specialOpGrid
'
Me.specialOpGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.specialOpGrid.Caption = "Special Options Summary"
Me.specialOpGrid.CaptionHeight = 21
Me.specialOpGrid.GroupByCaption = "Drag a column header here to group by that column"
Me.specialOpGrid.Images.Add(CType(resources.GetObject("specialOpGrid.Images"), System.Drawing.Image))
Me.specialOpGrid.Location = New System.Drawing.Point(12, 6)
Me.specialOpGrid.Name = "specialOpGrid"
Me.specialOpGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
Me.specialOpGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
Me.specialOpGrid.PreviewInfo.ZoomFactor = 75.0R
Me.specialOpGrid.PrintInfo.PageSettings = CType(resources.GetObject("specialOpGrid.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
Me.specialOpGrid.RecordSelectors = False
Me.specialOpGrid.RowHeight = 15
Me.specialOpGrid.Size = New System.Drawing.Size(519, 95)
Me.specialOpGrid.TabIndex = 56
Me.specialOpGrid.Text = "Special Options Summary"
Me.specialOpGrid.PropBag = resources.GetString("specialOpGrid.PropBag")
'
'lblSpecialOptionsSummaryTotalPriceLabel
'
Me.lblSpecialOptionsSummaryTotalPriceLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.lblSpecialOptionsSummaryTotalPriceLabel.BackColor = System.Drawing.Color.Transparent
Me.lblSpecialOptionsSummaryTotalPriceLabel.Location = New System.Drawing.Point(314, 101)
Me.lblSpecialOptionsSummaryTotalPriceLabel.Name = "lblSpecialOptionsSummaryTotalPriceLabel"
Me.lblSpecialOptionsSummaryTotalPriceLabel.Size = New System.Drawing.Size(124, 23)
Me.lblSpecialOptionsSummaryTotalPriceLabel.TabIndex = 54
Me.lblSpecialOptionsSummaryTotalPriceLabel.Text = "Special options total"
Me.lblSpecialOptionsSummaryTotalPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'lblSpecialOptionsSummaryTotalPrice
'
Me.lblSpecialOptionsSummaryTotalPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.lblSpecialOptionsSummaryTotalPrice.BackColor = System.Drawing.Color.Transparent
Me.lblSpecialOptionsSummaryTotalPrice.ForeColor = System.Drawing.Color.Blue
Me.lblSpecialOptionsSummaryTotalPrice.Location = New System.Drawing.Point(444, 101)
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
Me.Splitter1.Size = New System.Drawing.Size(543, 8)
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
Me.panSelectedOptions.Size = New System.Drawing.Size(543, 157)
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
Me.infoReviewLabel.Size = New System.Drawing.Size(515, 21)
Me.infoReviewLabel.TabIndex = 50
Me.infoReviewLabel.Text = "       Review option summary"
Me.infoReviewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'standardOpGrid
'
Me.standardOpGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.standardOpGrid.CaptionHeight = 17
Me.standardOpGrid.GroupByCaption = "Drag a column header here to group by that column"
Me.standardOpGrid.Images.Add(CType(resources.GetObject("standardOpGrid.Images"), System.Drawing.Image))
Me.standardOpGrid.Location = New System.Drawing.Point(12, 40)
Me.standardOpGrid.Name = "standardOpGrid"
Me.standardOpGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
Me.standardOpGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
Me.standardOpGrid.PreviewInfo.ZoomFactor = 75.0R
Me.standardOpGrid.PrintInfo.PageSettings = CType(resources.GetObject("standardOpGrid.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
Me.standardOpGrid.RowHeight = 15
Me.standardOpGrid.Size = New System.Drawing.Size(519, 110)
Me.standardOpGrid.TabIndex = 0
Me.standardOpGrid.Text = "C1TrueDBGrid1"
Me.standardOpGrid.PropBag = resources.GetString("standardOpGrid.PropBag")
'
'tabAvailableOptions
'
Me.tabAvailableOptions.BackColor = System.Drawing.Color.White
Me.tabAvailableOptions.Controls.Add(Me.availableOptionsPanel)
Me.tabAvailableOptions.Location = New System.Drawing.Point(4, 22)
Me.tabAvailableOptions.Name = "tabAvailableOptions"
Me.tabAvailableOptions.Size = New System.Drawing.Size(543, 504)
Me.tabAvailableOptions.TabIndex = 1
Me.tabAvailableOptions.Text = "Available Options"
Me.tabAvailableOptions.UseVisualStyleBackColor = True
'
'availableOptionsPanel
'
Me.availableOptionsPanel.Controls.Add(Me.lblNoOptions)
Me.availableOptionsPanel.Controls.Add(Me.optionToolbarPanel)
Me.availableOptionsPanel.Controls.Add(Me.availableOpGrid)
Me.availableOptionsPanel.Controls.Add(Me.infoAvailableOpLabel)
Me.availableOptionsPanel.Dock = System.Windows.Forms.DockStyle.Fill
Me.availableOptionsPanel.Location = New System.Drawing.Point(0, 0)
Me.availableOptionsPanel.Name = "availableOptionsPanel"
Me.availableOptionsPanel.Size = New System.Drawing.Size(543, 504)
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
Me.lblNoOptions.Size = New System.Drawing.Size(517, 144)
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
Me.optionToolbarPanel.Controls.Add(Me.unselectLink)
Me.optionToolbarPanel.Controls.Add(Me.groupLink)
Me.optionToolbarPanel.Location = New System.Drawing.Point(13, 65)
Me.optionToolbarPanel.Name = "optionToolbarPanel"
Me.optionToolbarPanel.Size = New System.Drawing.Size(517, 23)
Me.optionToolbarPanel.TabIndex = 51
'
'unselectLink
'
Me.unselectLink.BackColor = System.Drawing.Color.Transparent
Me.unselectLink.Cursor = System.Windows.Forms.Cursors.Hand
Me.unselectLink.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Unchecked
Me.unselectLink.Location = New System.Drawing.Point(132, 0)
Me.unselectLink.Name = "unselectLink"
Me.unselectLink.Size = New System.Drawing.Size(96, 23)
Me.unselectLink.TabIndex = 54
Me.unselectLink.Text = "Unselect All"
'
'groupLink
'
Me.groupLink.BackColor = System.Drawing.Color.Transparent
Me.groupLink.Cursor = System.Windows.Forms.Cursors.Hand
Me.groupLink.Image = Global.Rae.RaeSolutions.My.Resources.Resources.ListFlat
Me.groupLink.ImageToggled = Global.Rae.RaeSolutions.My.Resources.Resources.ListGrouped
Me.groupLink.Location = New System.Drawing.Point(5, 0)
Me.groupLink.Name = "groupLink"
Me.groupLink.Size = New System.Drawing.Size(122, 23)
Me.groupLink.TabIndex = 53
Me.groupLink.Text = "Ungroup"
Me.groupLink.TextToggled = "Group by Category"
'
'availableOpGrid
'
Me.availableOpGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.availableOpGrid.Caption = "Available Options"
Me.availableOpGrid.CaptionHeight = 47
Me.availableOpGrid.GroupByAreaVisible = False
Me.availableOpGrid.GroupByCaption = "Drag a column header here to group by that column"
Me.availableOpGrid.Images.Add(CType(resources.GetObject("availableOpGrid.Images"), System.Drawing.Image))
Me.availableOpGrid.IsPriceVisible = False
Me.availableOpGrid.Location = New System.Drawing.Point(12, 40)
Me.availableOpGrid.Name = "availableOpGrid"
Me.availableOpGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
Me.availableOpGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
Me.availableOpGrid.PreviewInfo.ZoomFactor = 75.0R
Me.availableOpGrid.PrintInfo.PageSettings = CType(resources.GetObject("availableOpGrid.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
Me.availableOpGrid.RowHeight = 15
Me.availableOpGrid.Size = New System.Drawing.Size(519, 455)
Me.availableOpGrid.TabIndex = 40
Me.availableOpGrid.Text = "Options"
Me.availableOpGrid.PropBag = resources.GetString("availableOpGrid.PropBag")
'
'infoAvailableOpLabel
'
Me.infoAvailableOpLabel.BackColor = System.Drawing.Color.Transparent
Me.infoAvailableOpLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.infoAvailableOpLabel.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Info
Me.infoAvailableOpLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.infoAvailableOpLabel.Location = New System.Drawing.Point(13, 13)
Me.infoAvailableOpLabel.Name = "infoAvailableOpLabel"
Me.infoAvailableOpLabel.Size = New System.Drawing.Size(240, 23)
Me.infoAvailableOpLabel.TabIndex = 41
Me.infoAvailableOpLabel.Text = "       Select available options"
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
Me.tabModel.Size = New System.Drawing.Size(543, 504)
Me.tabModel.TabIndex = 0
Me.tabModel.Text = "Specs"
'
'specsHeaderPanel
'
Me.specsHeaderPanel.Controls.Add(Me.lblSpecs)
Me.specsHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top
Me.specsHeaderPanel.Location = New System.Drawing.Point(0, 139)
Me.specsHeaderPanel.Name = "specsHeaderPanel"
Me.specsHeaderPanel.Size = New System.Drawing.Size(543, 30)
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
Me.lblSpecs.Size = New System.Drawing.Size(543, 23)
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
Me.pricingPanel.Size = New System.Drawing.Size(543, 28)
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
Me.modelPanel.Size = New System.Drawing.Size(543, 111)
Me.modelPanel.TabIndex = 145
'
'infoModelParenLabel
'
Me.infoModelParenLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.infoModelParenLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.infoModelParenLabel.ForeColor = System.Drawing.Color.DimGray
Me.infoModelParenLabel.Location = New System.Drawing.Point(202, 13)
Me.infoModelParenLabel.Name = "infoModelParenLabel"
Me.infoModelParenLabel.Size = New System.Drawing.Size(283, 23)
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
Me.infoModelLabel.Size = New System.Drawing.Size(195, 23)
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
Me.EquipmentSelector1.Division = Rae.RaeSolutions.Business.Division.NotSet
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
Me.tabEquipment.Size = New System.Drawing.Size(551, 530)
Me.tabEquipment.TabIndex = 45
'
'tabSpecialOptions
'
Me.tabSpecialOptions.Controls.Add(Me.infoSpecialOpParenLabel)
Me.tabSpecialOptions.Controls.Add(Me.infoSpecialOpLabel)
Me.tabSpecialOptions.Controls.Add(Me.SpecialOptionsControl1)
Me.tabSpecialOptions.Location = New System.Drawing.Point(4, 22)
Me.tabSpecialOptions.Name = "tabSpecialOptions"
Me.tabSpecialOptions.Size = New System.Drawing.Size(543, 504)
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
Me.ToolStrip1.Size = New System.Drawing.Size(575, 25)
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
Me.barUnitDrawings.Name = "barUnitDrawings"
Me.barUnitDrawings.Size = New System.Drawing.Size(170, 22)
Me.barUnitDrawings.Text = "Unit"
'
'barRefrigerantPiping
'
Me.barRefrigerantPiping.Name = "barRefrigerantPiping"
Me.barRefrigerantPiping.Size = New System.Drawing.Size(170, 22)
Me.barRefrigerantPiping.Text = "Refrigerant Piping"
'
'barFluidPiping
'
Me.barFluidPiping.Name = "barFluidPiping"
Me.barFluidPiping.Size = New System.Drawing.Size(170, 22)
Me.barFluidPiping.Text = "Fluid Piping"
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
Me.SaveToolStripPanel1.Size = New System.Drawing.Size(575, 0)
'
'EquipmentForm
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
Me.AutoScroll = True
Me.BackColor = System.Drawing.Color.White
Me.ClientSize = New System.Drawing.Size(575, 570)
Me.Controls.Add(Me.ToolStrip1)
Me.Controls.Add(Me.tabEquipment)
Me.Controls.Add(Me.SaveToolStripPanel1)
Me.Controls.Add(Me.equipmentMenuStrip)
Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.MainMenuStrip = Me.equipmentMenuStrip
Me.MinimumSize = New System.Drawing.Size(560, 524)
Me.Name = "EquipmentForm"
Me.Text = "Pricing"
CType(Me.selectedOpsDs, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.orderReportErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.submittalReportErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
Me.tabPricing.ResumeLayout(False)
Me.tabPricing.PerformLayout()
CType(Me.multiplierCodeAppliedPicture, System.ComponentModel.ISupportInitialize).EndInit()
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
   Protected isOpening As Boolean
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
   
   Delegate Sub LoadEngineeringDataSignature(unit As EquipmentItem)
   Protected loadEngineeringData As LoadEngineeringDataSignature

#End Region


#Region " Properties"
   
   ''' <summary>Gets the specs control for the equipment type.</summary>
   ''' <param name="equipType">Equipment type</param>
   Private Function buildSpecsControl(equipType As EquipmentType) As UserControl
      Dim specs = createSpecsControl()
      specs.Name = "SpecsControl"

      Return specs
   End Function
   
   Protected Overridable Function createSpecsControl() As UserControl
      Dim specs As UserControl

      Select Case Equipment.Type
         Case Business.EquipmentType.CondensingUnit
            specs = New CondensingUnitSpecsControl
         Case Business.EquipmentType.FluidCooler
            specs = New FluidCoolerSpecsControl
         Case Business.EquipmentType.ProductCooler
            specs = New ProductCoolerSpecsControl
         Case Else
            Throw New ArgumentException("There is no specifications control associated with the equipment type, " & Equipment.Type.ToString & ".")
      End Select

      Return specs
   End Function
   
   Protected Overridable Sub onOpSelected(code As String, description As String)
   End Sub

   Private _equipment As EquipmentItem
   Property Equipment As EquipmentItem
      Get
         Return _equipment
      End Get
      Set(value As EquipmentItem)
         _equipment = value
      End Set
   End Property

   ''' <summary>The last saved state of equipment</summary>
   ''' <remarks>Save and open automatically set the current equipment to the last saved state</remarks>
   Property LastSavedState As EquipmentItem
      Get
         Return _savedState
      End Get
      Set(value As EquipmentItem)
         _savedState = value
      End Set
   End Property

#End Region


#Region " Public methods"

   public mnu_order_write_up as ToolStripItem
   
   ''' <summary>Opens equipment</summary>
   Sub Open(equipment As EquipmentItem)
      isOpening = True
      
      If opening IsNot Nothing Then _
         opening.Invoke
      
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
      alertUserAbout(Me.Equipment.ObsoleteOptions)
      ' clears obsolete options so that user can save and no longer receive this message
      Me.Equipment.ObsoleteOptions.Clear

      isOpening = False
      
      opened()
   End Sub
   
   Protected Overridable Sub opened()

   End Sub

#End Region


#Region " Private methods"


#Region " Event handling"

   Private Sub form_Activated(sender As Object, e As EventArgs) _
   Handles Me.Activated
      Me.initializeSaveToolStripPanel()
      Me.SaveToolStripPanel1.Merge()
   End Sub

   Private Sub form_Deactivate(sender As Object, e As EventArgs) _
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
      EquipmentSelector1.EquipmentType = Me.Equipment.Type.ToString()
      
      addAndFormatSpecsControl()

      addCenturyCondensingUnitRefrigerant()
      
      Me.SpecialOptionsControl1.Initialize(Equipment.Id, user.username)
      
      AddHandler AppInfo.Main.RevisionView1.RevisionChanged, _
         AddressOf RevisionView_RevisionChanged
         
      Me.isLoaded = True
   End Sub
   
   Private Sub form_Paint(sender As Object, e As PaintEventArgs) _
   Handles Me.Paint
      If Not Me.Equipment Is Nothing _
      AndAlso Me.Equipment.Type = EquipmentType.FluidCooler _
      AndAlso Me.Equipment.RatingEquipment IsNot Nothing Then
         Dim fc As FluidCooler = CType(Me.Equipment.RatingEquipment, FluidCooler)
         Me.LoadFluidCoolerData(fc.FluidCoolerSeries.ModelSeries, fc.ModelNumber.ToString)
      End If
   End Sub
   
   Friend Sub onFormClosing(s As Object, e As FormClosingEventArgs)
      ' gets values from controls
      Dim currentEquipment As EquipmentItem = Me.grabEquipment

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
               Me.save()
            Case SaveOnCloseForm.UserSelection.SaveAsRevision
               Me.saveAsRevision()
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
      Me.removeHandlerForEquipmentNameChanged()
      RemoveHandler AppInfo.Main.RevisionView1.RevisionChanged, AddressOf RevisionView_RevisionChanged
   End Sub


   ''' <summary>
   ''' Handles equipment name changed event. Updates form's title.
   ''' </summary>
   ''' <history by="Casey Joyce" finish="2006/08/04">
   ''' Added
   ''' </history>
   Private Sub Equipment_NameChanged(sender As ItemBase, e As EventArgs)
      ' updates the form's title
      Me.Text = sender.Name
      ' prevents the name being incorrectly overriden by the previous name of the equipment
      Me.Equipment.Name = sender.Name
      ' prevents asking the user to save even if no changes were made (except the name change)
      Me.LastSavedState.Name = sender.Name
   End Sub


   ''' <summary>
   ''' Adds handler for equipment name changed event.
   ''' </summary>
   Private Sub addHandlerForEquipmentNameChanged()
      For Each equip As EquipmentItem In OpenedProject.Manager.Equipment
         If equip.Id.Id = Me.Equipment.Id.Id Then
            AddHandler equip.NameChanged, AddressOf Equipment_NameChanged
            Exit For
         End If
      Next
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
         If equip.Id.Id = Me.Equipment.Id.Id Then
            RemoveHandler equip.NameChanged, AddressOf Equipment_NameChanged
         End If
      Next
   End Sub


   ''' <summary>
   ''' Handles revision view control's revision changed event.
   ''' If user has unsaved changes, asks user to save before navigating revisions.
   ''' </summary>
   Private Sub RevisionView_RevisionChanged(sender As RevisionView, e As ValueChangedEventArgs(Of Single))
      If sender.ActiveProcessForm Is Me Then
         Me.promptUserToSaveBeforeNavigation(e.BeforeValue, e.AfterValue)
      End If
   End Sub


#Region " Combobox events"

   Protected Overridable Sub onModelChanged(unit As EquipmentItem)
      Dim ctrl = EquipmentSelector1
      If Not ctrl.IsCompleted Then Exit Sub
      
      onModelChanged_price(unit)
      loadEngineeringData.Invoke(unit)
      onModelChanged_updateOps
   End Sub
   
   Private Sub loadEngineeringDataFor(unit As EquipmentItem)
      Dim series = unit.series
      Dim model  = unit.model_without_series
      
      Select Case unit.Type
         Case EquipmentType.CondensingUnit
            loadCondensingUnitData(Me.EquipmentSelector1.Equipment)
         Case EquipmentType.FluidCooler
            LoadFluidCoolerData(series, model)
      End Select
   End Sub
   
   Protected Sub onModelChanged_price(unit As EquipmentItem)
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
      If validateOptionRetrievalInputs Then
         reselectOpsAfterModelOrVoltageChange()
         ' resets options total price since the options change when the model changes
         displayTotalOptionsPrice(0, 0)
      Else
         availableOpGrid.RemoveAll()
      End If

      Cursor = Cursors.Default
   End Sub
   
   Private Sub EquipmentSelector1_BeforeModelChanged(sender As EquipmentSelector, ByRef e As System.ComponentModel.CancelEventArgs) _
   Handles EquipmentSelector1.BeforeModelChanged
      If EquipmentSelector1.Series Like "35E2*" _
      And Not EquipmentSelector1.Model = String.Empty _
      And Not EquipmentSelector1.Model = "Choose"
         dim chiller = ctype(grabEquipment(), chiller_equipment)
         dim cancel = notify_user_that_balance_data_will_be_cleared(chiller)
         e.Cancel = cancel
      End If
   End Sub
   
   private function notify_user_that_balance_data_will_be_cleared(chiller as chiller_equipment) as boolean
      dim cancel = false
      
      if chiller.has_balance
         dim pop_up as i_confirm = new pop_up()
         dim confirmed = pop_up.confirm("Changing the chiller model or voltage invalidates electrical data from the associated balance (such as amps from non-standard compressor selection). If this change is made then standard components will be used to determine electrical data regardless of previous selections in balance." & _
                                        NewLine & NewLine & _
                                        "Do you want to change the model and discard electrical data?", _
                                        confirm_text:="Change Model", cancel_text:="Do Not Change Model")
         if confirmed
            chiller.has_balance = false
            chiller.balance_data.clear()
            chiller.CommonSpecs.Rla.SetToNull()
            chiller.CommonSpecs.Mca.SetToNull()
         else ' cancel
            cancel = true
         end if
      end if
      
      return cancel
   end function
   
   class pop_up : implements i_confirm
      function confirm(message as string, confirm_text as string, decline_text as string) as boolean _
      implements i_confirm.confirm
         Dim result = system.Windows.Forms.MessageBox.Show(message, "RAESolutions", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
         if result = Forms.DialogResult.Yes
            return true
         else
            return false
         end if
      end function
   end class
   
   interface i_confirm
      function confirm(message as string, confirm_text as string, cancel_text as string) as boolean
   end interface
   
   

   Private Sub model_Changed(s As EquipmentSelector, selectedModel As String) _
   Handles EquipmentSelector1.ModelChanged
      Equipment.series = s.Series
      Equipment.model_without_series = s.Model
      
      onModelChanged(Equipment)      
   End Sub

   ''' <summary>Handles equipment series before change</summary>
   Private Sub EquipmentSelector1_SeriesChanged(sender As EquipmentSelector, ByRef e As System.ComponentModel.CancelEventArgs) Handles EquipmentSelector1.BeforeSeriesChanged
   
      If EquipmentSelector1.previous_series Like "35E2*" _
      And Not EquipmentSelector1.Model = String.Empty _
      And Not EquipmentSelector1.Model = "Choose"
         dim chiller = ctype(grabEquipment(), chiller_equipment)
         dim cancel = notify_user_that_balance_data_will_be_cleared(chiller)
         e.Cancel = cancel
         if cancel then exit sub
      end if

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
         availableOpGrid.RemoveAll
      Else
         e.Cancel = True
         Exit Sub
      End If
      
      If EquipmentSelector1.Series Like "35E2*" _
      And Not EquipmentSelector1.Model = String.Empty _
      And Not EquipmentSelector1.Model = "Choose"
         dim chiller = ctype(grabEquipment(), chiller_equipment)
         dim cancel = notify_user_that_balance_data_will_be_cleared(chiller)
         e.Cancel = cancel
      End If
   End Sub
   
   Private Sub availableOpGrid_Grouped() Handles availableOpGrid.GroupedByCategory
      If groupLink.IsToggled Then _
         groupLink.Toggle()
   End Sub
   
   Private Sub availableOpGrid_Ungrouped() Handles availableOpGrid.Ungrouped
      If Not groupLink.IsToggled Then _
         groupLink.Toggle()
   End Sub

   ''' <summary>Handles PAR multiplier change</summary>
   Private Sub cboParMultiplier_SelectedIndexChanged(sender As Object, e As EventArgs) _
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

   Friend isAlreadySyncing As Boolean
   private voltage_change_canceled as boolean = false
   ''' <summary>Handles unit voltage changed</summary>
   Private Sub cboUnitVoltage_SelectedIndexChanged(sender As Object, e As EventArgs) _
   Handles cboUnitVoltage.SelectedIndexChanged
      Static voltage As Integer
   
      If Not isAlreadySyncing Then
         if Equipment.Type = EquipmentType.Chiller _
         AndAlso EquipmentSelector1.IsCompleted _
         AndAlso Equipment.series Like "35E2*" _
         AndAlso voltage <> 0
            if voltage_change_canceled then
               voltage_change_canceled = false
               exit sub
            end if
            
            dim chiller = CType(Equipment, chiller_equipment)
            dim cancel = notify_user_that_balance_data_will_be_cleared(chiller)
            if cancel then
               for i as integer = 0 to cboUnitVoltage.items.count - 1
                  if cboUnitVoltage.items(i).ToString Like voltage & "*" then
                     voltage_change_canceled = true
                     cboUnitVoltage.selectedIndex = i
                     exit for
                  end if
               next
               exit sub
            end if
         end if
         syncUnitVoltage
      End if

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
   
   protected sub set_rla_and_mca_for_evaporative_condenser_chiller()
      dim unit = Equipment
      
      with unit
      
      if .model like "35*"
         dim chiller = ctype(unit, chiller_equipment)
         dim electrical = new rae.solutions.evaporative_condenser_chillers.electrical_data(chiller)
         .CommonSpecs.Rla.SetValue(electrical.circuit_1.rla)
         .CommonSpecs.Mca.SetValue(electrical.circuit_1.mca)
         if electrical.circuits.count > 1
            dim chiller_specs_control = ctype(me.specsControl, chiller_specs_control)
            dim common_specs_control = chiller_specs_control.panCommonSpecs
            dim txt_rla_2 = common_specs_control.controls("txt_rla_2")
            txt_rla_2.text = electrical.circuits(1).rla.toString()
            dim txt_mca_2 = common_specs_control.controls("txt_mca_2")
            txt_mca_2.text = electrical.circuits(1).mca.toString()
         else
            dim chiller_specs_control = ctype(me.specsControl, chiller_specs_control)
            dim common_specs_control = chiller_specs_control.panCommonSpecs
            dim txt_rla_2 = common_specs_control.controls("txt_rla_2")
            txt_rla_2.text = ""
            dim txt_mca_2 = common_specs_control.controls("txt_mca_2")
            txt_mca_2.text = ""
         end if
         ctype(specsControl, chiller_specs_control).SetControlValues(chiller)
      end if
      
      end with
   end sub


   Private Sub txtUnitQuantity_TextChanged(sender As Object, e As EventArgs) _
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


   Private Sub overrideBaseListCheckBox_CheckedChanged(sender As Object, e As EventArgs) _
   Handles overrideBaseListCheck.CheckedChanged
      Me.overrideBaseListText.ReadOnly = Not Me.overrideBaseListCheck.Checked
      calculateAndDisplayPrices()
   End Sub


   Private Sub overrideBaseListText_Leave(sender As Object, e As EventArgs) _
   Handles overrideBaseListText.Leave
      Try
         displayPrice(overrideBaseListText, grabBaseList())
         calculateAndDisplayPrices()
      Catch ex As Exception
         Ui.MessageBox.Show("Invalid format for price", MessageBoxIcon.Warning)
      End Try
   End Sub

#End Region


#Region " Grid events"

   ''' <summary>Handles available options selections and deselections. Performs additional logic for options
   ''' that have dependents or are dependents.</summary>
   Private Sub availableOpTable_ColumnChanging(s As Object, e As DataColumnChangeEventArgs) _
   Handles availableOpTable.ColumnChanging
      Me.Cursor = Cursors.WaitCursor

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

   Private Sub availableOpTable_Cleared(s As Object, e As DataTableClearEventArgs) _
   Handles availableOpTable.TableCleared
      ' notifies user that model and voltage are required to populate options
      lblNoOptions.Visible = True
   End Sub


   ''' <summary>Handles availableOptionsTable's ColumnChanged event. 
   ''' Adds selected option to selected options grid, or removes deselected option from selected options grid.</summary>
   Private Sub availableOpTable_ColumnChanged(s As Object, e As DataColumnChangeEventArgs) _
   Handles availableOpTable.ColumnChanged
      ' checks if Selected column changed
      If e.Column.ColumnName = OCol.Selected Then
         ' checks if an option was selected
         If CBool(e.Row(OCol.Selected)) Then
            ' option was selected
            askUserForOptionQuantity(e.Row)
            ' copies option from available options grid to selected options grid
            selectedOpGrid.Add(e.Row)
         Else
            ' option was deselected
            selectedOpGrid.Remove(e.Row)
         End If
      ElseIf e.Column.ColumnName = OCol.Quantity Then
         ' update selected options grid
         Dim quantity  = CInt(e.Row(OCol.Quantity))
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


   Private Sub selectedOpTable_RowChanged(s As Object, e As DataRowChangeEventArgs) _
   Handles selectedOpTable.RowChanged
      Dim prices As OptionBreakDown = calculateTotalOptionsPrice()
      Me.displayTotalOptionsPrice(prices.AvailableOptionsPricePerUnit, prices.CommonOptionsPrice)
   End Sub


   Private Sub selectedOpTable_ColumnChanged(s As Object, e As DataColumnChangeEventArgs) _
   Handles selectedOpTable.ColumnChanged
      Dim prices As OptionBreakDown = calculateTotalOptionsPrice()
      Me.displayTotalOptionsPrice(prices.AvailableOptionsPricePerUnit, prices.CommonOptionsPrice)
      syncOptionQuantities(e)
   End Sub


   Private Sub syncOptionQuantities(e As DataColumnChangeEventArgs)
      For Each op As DataRow In availableOpTable.Rows
         If      CInt(op(OCol.ID)) = CInt(e.Row(OCol.ID)) _
         AndAlso CInt(op(OCol.Quantity)) <> CInt(e.Row(OCol.Quantity)) Then
            op(OCol.Quantity) = e.Row(OCol.Quantity)
            Exit For
         End If
      Next
   End Sub

#End Region


#Region " Validation events"

   Private Sub equipmentSelector1_SeriesChanged(sender As EquipmentSelector, selectedSeries As String) Handles EquipmentSelector1.SeriesChanged

      If Me.isLoaded Then
         ' validates series validation control
         Me.seriesVCtrl.Validate()
         With Me.Equipment.CommonSpecs
            .Length.SetToNull()
            .Width.SetToNull()
            .Height.SetToNull()
            .ShippingWeight.SetToNull()
            .OperatingWeight.SetToNull()
         End With
         ' sets control values
         InvokeMethod(Me.specsControl, Me.methodName_SetControlValues, grabEquipment)
      End If
   End Sub

   Private Sub equipmentSelector1_ModelChanged(sender As EquipmentSelector, selectedLine As String)
      If Me.isLoaded Then _
         Me.modelVCtrl.Validate()
   End Sub

   Private Sub seriesVCtrl_Validating(sender As ValidationControl) Handles seriesVCtrl.Validating
      ' checks whether series combobox has an item selected
      If Not Me.IsItemSelected(CType(sender.ControlToValidate, ComboBox)) _
      OrElse CType(sender.ControlToValidate, ComboBox).SelectedItem.ToString = Me.EquipmentSelector1.choose Then
         sender.ErrorMessages.Add("Series combobox must have a selection.") : End If
   End Sub

   Private Sub modelVCtrl_Validating(sender As ValidationControl) Handles modelVCtrl.Validating
      ' checks whether series combobox has an item selected
      If Not Me.IsItemSelected(CType(sender.ControlToValidate, ComboBox)) _
      OrElse CType(sender.ControlToValidate, ComboBox).SelectedItem.ToString = Me.EquipmentSelector1.choose Then
         sender.ErrorMessages.Add("Model combobox must have a selection.") : End If
   End Sub

   Private Sub txtUnitQuantity_Leave(sender As Object, e As EventArgs)
      Me.unitQuantityVCtrl.Validate()
   End Sub

#End Region


#Region " Menu events"

   ''' <summary>Handles close menu item click</summary>
   Private Sub closeMenuItem_Click(sender As Object, e As EventArgs) _
   Handles mnuClose.Click
      Me.Close()
   End Sub


   ''' <summary>Handles save menu item click</summary>
   Private Sub saveMenuItem_Click(sender As Object, e As EventArgs) _
   Handles mnuSave.Click
      Me.save()
   End Sub


   ''' <summary>
   ''' Handles save as menu item click event.
   ''' Copies equipment and saves using name chosen by user.
   ''' </summary>
   Private Sub saveAsMenuItem_Click(sender As Object, e As EventArgs) _
   Handles mnuSaveAs.Click
      Me.saveAs()
   End Sub


   ''' <summary>
   ''' Handles save as revision menu item click event.
   ''' Saves equipment and sets its revision level as the latest.
   ''' </summary>
   Private Sub saveAsRevisionMenuItem_Click(sender As Object, e As EventArgs) _
   Handles mnuSaveAsRevision.Click

      If OpenedProject.IsOpened Then
         saveAsRevision(user.Is(owner))
      Else
         saveAsRevision()
      End If

   End Sub


   ''' <summary>Handles order entry order write up report menu clicked</summary>
   Private Sub orderWriteUpMenuItem_Click() _
   
      onViewOrderWriteUp()
   End Sub


   ''' <summary>Handles submittal accessories report menu clicked</summary>
   Private Sub submittalMenuItem_Click(sender As Object, e As EventArgs) _
   Handles mnuSubmittal.Click, barSubmittal.Click
      onViewSubmittal()
   End Sub

   Private Sub convertToProcessMenuItem_Click(sender As Object, e As EventArgs) _
   Handles mnuConvert.Click, barConvert.Click, mnuConvert.Click
      If Not OpenedProject.IsOpened Then
         Ui.MessageBox.Show("A project is not open. A project must be opened before performing a conversion.", MessageBoxIcon.Warning)
         Exit Sub
      End If

      Dim proc = convertToProcess.Invoke

      If proc IsNot Nothing Then
         OpenedProject.Manager.Processes.Add(proc)
         OpenedProject.Manager.Processes.Items(proc.Id).Save()
         ProjectInfo.Viewer.ViewProcess(proc)
      Else
         Ui.MessageBox.Show("No process exists for this equipment. ")
      End If

   End Sub
   
   Private Function convertToProcessItem() As ProcessItem
      Dim proc As ProcessItem
      Dim unit = grabEquipment()

      Select Case Equipment.Type           
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
               fcproc.ID = New item_id(ProjectInfo.NewItemID(Me.Equipment.Id.Id))
               fcproc.FluidCooler = FluidCooler.Populate(Me.Equipment.series, Me.Equipment.model_without_series)
               proc = fcproc
            End If
      End Select
      
      Return proc
   End Function

   private function controls_are_not_valid_to_show_unit_drawing as boolean
      if equipment.Type = EquipmentType.UnitCooler then
         dim specs = ctype(specsControl, UnitCoolerSpecsControl)
         dim fan_voltage_is_selected = specs.fanVoltageCombo.SelectedItem IsNot nothing
         dim defrost_voltage_is_selected = specs.defrostVoltageCombo.SelectedItem IsNot nothing
         dim has_electric_defrost = equipment.model.endsWith("E")
         
         dim validator = new fan_and_defrost_voltage_are_required_for_unit_cooler_drawing(fan_voltage_is_selected, has_electric_defrost, defrost_voltage_is_selected)
         if validator.validate().is_invalid then
            warn(validator.messages.toString())
            tabEquipment.SelectTab(tabModel)
            specs.fanVoltageCombo.focus()
            return true
         end if
      end if
      return false
   end function

   Private Sub unitDrawingMenuItem_Click() _
   Handles mnuUnitDrawing.Click, barUnitDrawings.Click
      if controls_are_not_valid_to_show_unit_drawing then exit sub
      
      Dim time = Stopwatch.StartNew

      Common.IsCountingConnections = True

      Try
         'Dim previewForm As New PreviewDrawingForm()
         dim unit_drawing = new UnitDrawing(grabEquipment(True), Constants.TARGET_USER_GROUP)
         
         if unit_drawing.validators.validate().is_invalid then
            warn(unit_drawing.validators.messages.toString)
         end if

         if user.can(choose_report_logo) then _
            unit_drawing.DivisionName = "RAE"
         If Not unit_drawing.Show() Then
            inform("Unit drawings are currently unavailable for selected model (" & Me.Equipment.ToString() & ").")
         End If
      Catch ex As Exception
         warn("The drawing cannot be created. " & ex.Message)
      End Try
      
      log("Number of database connections to open drawing: " & Common.NumConnections.ToString)
      Common.IsCountingConnections = False
      Common.NumConnections = 0

      log("Time to open unit drawing: " & time.Elapsed.TotalSeconds.ToString)
   End Sub

   Private Sub pipingDrawingMenu_Click() _
   Handles mnuRefrigerantPiping.Click, barRefrigerantPiping.Click
      If Not controls_are_valid_for_piping_drawing Then
         tabEquipment.SelectTab(tabModel)
         Me.specsControl.Controls("txtSuctionTemp").Focus
         Ui.MessageBox.Show("The suction temperature is required to generate condensing unit drawings.")
         Exit Sub
      End If

      Dim timer = Stopwatch.StartNew

      Dim pipingDrawing = New RefrigerantPipingDrawing(Me.grabEquipment(includePumpOpsForChiller:=True), Constants.TARGET_USER_GROUP)

      If Not pipingDrawing.Show() Then
         warn("Piping drawings are currently unavailable for selected model, " & _
               Me.Equipment.ToString & ".")
      End If
      
      log("Time to open piping drawing: " & timer.Elapsed.TotalSeconds.ToString)
   End Sub
   
   Private Sub mnuFluidPiping_Click() Handles barFluidPiping.Click, mnuFluidPiping.Click
      Dim unit = grabEquipment(includePumpOpsForChiller:=True)
      Dim drawing = New FluidPipingDrawing(unit, Constants.TARGET_USER_GROUP)
      Try
         If Not drawing.Show()
            warn("Fluid piping drawings are not available for selected model, " & unit.ToString() & ".")
         End If
      Catch ex As Exception
         alert(ex.Message)
      End Try
   End Sub
   
   Private Function controls_are_valid_for_piping_drawing As Boolean
      Dim isValid = True
      
      ' if condensing unit require suction temp to be entered
      If TypeOf Me.Equipment Is CondensingUnitEquipmentItem Then
         isValid = Not String.IsNullOrEmpty(Me.specsControl.Controls("txtSuctionTemp").Text)
      End If
      
      Return isValid
   End Function

   Private Sub log(message As String)
      My.Application.Log.WriteEntry(message)
   End Sub
   
   Private Sub reportsToolStripSplitButton_ButtonClick(sender As Object, e As EventArgs) _
   Handles barReports.ButtonClick, barDrawings.ButtonClick
      DirectCast(sender, ToolStripSplitButton).ShowDropDown()
   End Sub

#End Region


   ''' <summary>
   ''' Handles event raised when special options total price changed.
   ''' </summary>
   ''' <history by="Casey Joyce" finish="2006/06/05">
   ''' Added</history>
   Private Sub specialOptionsTotalPrice_Changed(sender As SpecialOptionsControl, totalPrice As Double) _
   Handles SpecialOptionsControl1.TotalPriceChanged
      ' sets special options total price on pricing tab
      Me.displayPrice(Me.totalSpecialOptionsPriceLabel, totalPrice * Me.grabUnitQuantity())
      ' sets special options total price per unit on option summary tab
      Me.displayPrice(Me.lblSpecialOptionsSummaryTotalPrice, totalPrice)
   End Sub


   ''' <summary>
   ''' Handles special options grid data source changed event.
   ''' Synchronizes special options grids on summary and special options tabs.
   ''' </summary>
   Private Sub SpecialOptionsControl_DataSourceChanged(s As SpecialOptionsControl, e As EventArgs) _
   Handles SpecialOptionsControl1.DataSourceChanged
      specialOpGrid.DataSource = s.opGrid.DataSource
      specialOpGrid.ApplyStyle
   End Sub
   
   Private Sub tabEquipment_SelectedIndexChanged(sender As Object, e As EventArgs) _
   Handles tabEquipment.SelectedIndexChanged

      Static previousTab As String = "tabModel"

      If cboUnitVoltage.Text.Trim > " " Then
         If Me.Equipment.series = "DD" Or Me.Equipment.series = "DM" Or Me.Equipment.series = "DS" Or Me.Equipment.series Like "2*" Or Me.Equipment.series Like "3*" Or Me.Equipment.series Like "4*" Or Me.Equipment.series = "LUI" Or Me.Equipment.series = "LUO" Or Me.Equipment.series = "RS" Then
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

         ' displays/hides options are unavailable note
         Me.lblNoOptions.Visible = Not Me.validateOptionRetrievalInputs()

         availableOpGrid.SetColumnWidths()

         previousTab = "tabAvailableOptions"

         ' special options
      ElseIf Me.tabEquipment.SelectedTab.Name = "tabSpecialOptions" Then
         previousTab = "tabSpecialOptions"

         ' options summary
      ElseIf Me.tabEquipment.SelectedTab.Name = "tabOptionsSummary" Then
         selectedOpGrid.ApplyStyle

         ' displays total price of selected options
         Dim prices As OptionBreakDown = Me.calculateTotalOptionsPrice()
         Me.displayTotalOptionsPrice(prices.AvailableOptionsPricePerUnit, prices.CommonOptionsPrice)

         previousTab = "tabOptionsSummary"

         ' pricing
      ElseIf Me.tabEquipment.SelectedTab.Name = "tabPricing" Then

         ' selects a different column to raise the column changed event in the data table to commit changes
         ' effectively, when quantity is being edited and the tab index changes, the pricing updates (before it didn't)
         Me.selectedOpGrid.Col = 1

         'calculates and displays prices on pricing tab
         Me.calculateAndDisplayPrices()

         previousTab = "tabPricing"

      End If

   End Sub


   ''' <summary>
   ''' Handles cost textbox leave events.
   ''' Calculates prices.
   ''' </summary>
   Private Sub txtOthers_Leave(sender As Object, e As EventArgs) _
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


   Private Sub onViewOrderWriteUp()
      ParentForm.Cursor = Cursors.WaitCursor
      Try
         calculateAndDisplayPrices()
         presenter.ViewOrderWriteUp()
      Catch ex As Exception
         alert("Attempt to view order write up report failed. " & ex.Message)
      Finally
         ParentForm.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub onViewSubmittal()
      ParentForm.Cursor = Cursors.WaitCursor
      Try
         presenter.ViewSubmittal()
      Catch ex As Exception
         alert("Attempt to view submittal report failed. " & ex.Message)
      Finally
         ParentForm.Cursor = Cursors.Default
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
               ' sets dependent's price
               row(OCol.Price) = relOption.DependentOptions.Item(i).Price
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
      
      If Equipment.Type = EquipmentType.Chiller _
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
      optionsTable.Clear

      Return optionsTable
   End Function

   Private Function getNumFans() As Integer
      If TypeOf Equipment Is unit_cooler Then
         Return CType(Equipment, unit_cooler).fan_quantity
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
         ' determines whether option is voltage dependent
         If CBool(row(OCol.IsVoltageDependent)) Then
            ' retrieves option with same option code but new voltage
            optionTable = EquipmentOptionsAgent.OptionsDA.RetrieveOption( _
               EquipmentSelector1.Series, EquipmentSelector1.Model, row(OCol.Code).ToString, voltage, getNumFans)
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
         selectedOpTable = getOptionsTableStructure
         selectedOpGrid.DataSource = selectedOpTable
      End If

      convertSelectedVoltageDependentOptions

      Dim selectedOpCopyTable = selectedOpTable.Copy
      selectedOpTable.Clear
      availableOpGrid.Select(selectedOpCopyTable)
   End Sub


   ''' <summary>Populates and formats available options grid</summary>
   Private Sub populateAvailableOptionsGrid()
      If Not Me.validateOptionRetrievalInputs Then _
         Exit Sub

      Dim series  = Me.EquipmentSelector1.Series
      Dim model   = Me.EquipmentSelector1.Model
      Dim voltage = CInt(Me.parseVoltage(Me.GrabUnitVoltage))

      ' retrieves
      availableOpTable = EquipmentOptionsAgent.OptionsDA.RetrieveAvailableOptions(series, model, voltage, getNumFans, user)
      ' sets
      availableOpGrid.DataSource = availableOpTable
      ' formats
      availableOpGrid.GroupByCategory()
   End Sub


   ''' <summary>Populates and formats standard options grid</summary>
   Private Sub populateStandardOptionsGrid()
      If Not Me.validateOptionRetrievalInputs() Then _
         Exit Sub

      Dim series  = Me.EquipmentSelector1.Series
      Dim model   = Me.EquipmentSelector1.Model
      Dim voltage = CInt(parseVoltage(Me.GrabUnitVoltage()))

      ' retrieves typed table of standard options
      Dim standardOptionsTable = EquipmentOptionsAgent.OptionsDA.RetrieveStandardOptions(series, model, voltage, getNumFans)
      standardOpGrid.DataSource = standardOptionsTable
      standardOpGrid.ApplyStyle
   End Sub

#End Region


#Region " UI methods"


#Region " Grab and display methods"

   Private Function grabPrice(control As Control) As Double
      Dim price As Double = 0
      If control.Text <> "Contact Factory" And control.Text <> "Unavailable" Then
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
   Private Function GrabPercent(control As Control) As Double
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
      Return CDbl(Me.cboParMultiplier.Text)
   End Function

   ''' <summary>Grabs commission rate from PAR multiplier combobox value, not commission rate label text
   ''' </summary>
   Friend Function GrabCommissionRate() As Double
      Return CDbl(Me.cboParMultiplier.SelectedValue)
   End Function

   Private Function GrabUnitVoltage() As String
      If Me.cboUnitVoltage.SelectedItem Is Nothing Then
         Return ""
      Else
         Return CNull.ToString(Me.cboUnitVoltage.SelectedItem.ToString) : End If
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
      If Me.Equipment.Type = EquipmentType.FluidCooler AndAlso Me.pnlCoil.Visible Then
         totalListPrice = totalBaseListPrice + totalOptionsPrice + Val(Me.lblCoilListPrice.Text.Replace("$", ""))
      End If
      Dim parPrice As Double
      parPrice = Intelligence.PriceCalculator.CalculateParPrice(totalListPrice, Me.GrabParMultiplier())

      Dim commissionPrice As Double
      commissionPrice = Intelligence.PriceCalculator.CalculateCommissionPrice(Me.GrabCommissionRate(), parPrice)

      ' calculates others (warranty, freight, etc.) price
      Dim othersPrice As Double
      othersPrice = Intelligence.PriceCalculator.CalculateTotalOtherPrice(Me.grabPrice(Me.txtFourYearCompressorWarranty), Me.grabPrice(Me.txtFreight), Me.grabPrice(Me.txtStartUp), Me.grabPrice(Me.txtOther))

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
   End Sub



   ''' <summary>Displays formatted price</summary>
   Private Sub displayPrice(control As Control, price As Double)
      control.Text = price.ToString(Me.price_format)  '("#0.00")
   End Sub

   ''' <summary>
   ''' Displays percent in control's text property.
   ''' </summary>
   ''' <param name="control">Control to display percent.</param>
   ''' <param name="percent">Decimal value to display as a percent.</param>
   Private Sub displayPercent(control As Control, decimalValue As Double)
      control.Text = (decimalValue).ToString("#0.####%")
   End Sub


   Private Sub displayTotalBaseListPrice(totalBaseListPrice As Double)
      Me.lblTotalBaseListPrice.Text = totalBaseListPrice.ToString(Me.price_format)
      Me.lblSummaryBaseListPrice.Text = totalBaseListPrice.ToString(Me.price_format)
   End Sub


   Private Sub displayTotalOptionsPrice(availableOptionsPricePerUnit As Double, commonOptionsPrice As Double)
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

   
   Private Sub alertUserAbout(obsoleteOps As EquipmentOptionList)
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
   

   Private Sub askUserForOptionQuantity(optionRow As DataRow)
      Dim quantity As Integer
      ' if equipment is not being opened (don't want to prompt everytime an option is added during opening)
      ' and quantity is not readonly and quantity = 0
      If      Not isOpening _
      AndAlso Not CBool(optionRow(OCol.IsQuantityReadOnly)) _
      AndAlso CInt(optionRow(OCol.Quantity)) = 0 Then
         Dim code        = optionRow(OCol.Code).ToString
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
   Private Sub loadCondensingUnitData(equipment As String)
      Try
         Dim cuInfo = New rae.solutions.condensing_units.Condensing_Unit_Info(equipment)

         ' updates equipment with specs info
         InvokeMethod(Me.specsControl, methodName_GetControlValues, Me.Equipment)

         ' updates dimensions and refrigerant based on selected model
         Me.Equipment.CommonSpecs.Length.SetValue(Round(cuInfo.Length, 2))
         Me.Equipment.CommonSpecs.Width.SetValue(Round(cuInfo.Width, 2))
         Me.Equipment.CommonSpecs.Height.SetValue(Round(cuInfo.Height, 2))
         Me.Equipment.CommonSpecs.OperatingWeight.SetValue(Round(cuInfo.operating_weight, 2))
         Me.Equipment.CommonSpecs.ShippingWeight.SetValue(Round(cuInfo.shipping_weight, 2))

         Dim formattedRefrigerant As String
         formattedRefrigerant = cuInfo.Refrigerant.Trim(New Char() {"H"c, "M"c, "L"c})
         CType(Me.Equipment, CondensingUnitEquipmentItem).Specs.Refrigerant = formattedRefrigerant

      Catch ex As ApplicationException
         Ui.MessageBox.Show(ex.Message, MessageBoxIcon.Warning)
         With Me.Equipment.CommonSpecs
            .Length.SetToNull()
            .Width.SetToNull()
            .Height.SetToNull()
            .ShippingWeight.SetToNull()
            .OperatingWeight.SetToNull()
         End With
      Finally
         ' sets spec controls' values with updated dimensions and refrigerant
         InvokeMethod(Me.specsControl, Me.methodName_SetControlValues, Me.Equipment)
      End Try
   End Sub

   Private Sub FluidCoolerPricing(fc As FluidCooler)
      Dim price, totalPrice As Double
      Try
         ' retrieves base list price from database
         price = EquipmentOptionsAgent.OptionsDA.RetrieveBaseListPrice(fc.FluidCoolerSeries.ModelSeries, fc.ModelNumber.ToString())
         ' calculates total base list price
         totalPrice = Intelligence.PriceCalculator.CalculateTotalBaseListPrice(price, Me.grabUnitQuantity())
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
         ' removes options
         availableOpGrid.RemoveAll
         ' selects Choose
         Me.EquipmentSelector1.cbo_model.SelectedIndex = _
            Me.EquipmentSelector1.cbo_model.Items.IndexOf(Me.EquipmentSelector1.choose)
         Me.Cursor = Cursors.Default
         Exit Sub
      End Try
      Dim stdFC As FluidCooler = FluidCooler.Populate(fc.FluidCoolerID)
      Dim stdCPW As New CoilPricingWrapper(stdFC.Coils(0).Convert, stdFC.CoilQuantity)
      Dim stdCoilPrice As Integer = CInt(System.Math.Ceiling(stdCPW.Price))
      Dim fcCPW As New CoilPricingWrapper(fc.Coils(0).Convert, fc.CoilQuantity)
      Dim fcCoilPrice As Integer = CInt(System.Math.Ceiling(fcCPW.Price))
      price = price - stdCoilPrice
      totalPrice = CInt(System.Math.Ceiling(Intelligence.PriceCalculator.CalculateTotalBaseListPrice(price + fcCoilPrice, Me.grabUnitQuantity())))
      Me.lblSummaryTotalListPrice.Text = totalPrice.ToString(Me.price_format)
      Me.lblTotalBaseListPrice.Text = totalPrice.ToString(Me.price_format)
      Me.lblSummaryBaseListPrice.Text = price.ToString(Me.price_format)
      'Me.displayTotalBaseListPrice(totalPrice)
      Me.pnlCoil.Visible = True
      Me.lblCoilListPrice.Text = "$" & fcCoilPrice.ToString
      If fc.CoilQuantity > 1 Then
         Me.lblCoilPriceEach.Visible = True
         Me.lblCoilPriceEach.Text = "($" & CInt(System.Math.Ceiling(fcCoilPrice / fc.CoilQuantity)).ToString & " each)"
      End If
   End Sub


   ''' <summary>loads fluid cooler data.</summary>
   ''' <param name="FluidCoolerModel"></param>
   Private Sub LoadFluidCoolerData(FluidCoolerSeries As String, FluidCoolerModel As String) '(FluidCoolerModel As String)
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
         Me.Equipment.CommonSpecs.Length.SetValue(dimensionsParser.Length)
         Me.Equipment.CommonSpecs.Width.SetValue(dimensionsParser.Width)
         Me.Equipment.CommonSpecs.Height.SetValue(dimensionsParser.Height)
         If fc IsNot Nothing Then
            Me.Equipment.CommonSpecs.OperatingWeight.SetValue(fc.Operating_Weight)
            Me.Equipment.CommonSpecs.ShippingWeight.SetValue(fc.Shipping_Weight)
            Me.EquipmentSelector1.Series = fc.FluidCoolerSeries.ModelSeries
            Me.EquipmentSelector1.Model = fc.ModelNumber.ToString
            Me.lblNumCoils.Text = fc.CoilQuantity.ToString
            FluidCoolerPricing(fc)
         Else
            Me.pnlCoil.Visible = False
         End If
      Catch
         Me.Equipment.CommonSpecs.Length.SetToNull()
         Me.Equipment.CommonSpecs.Width.SetToNull()
         Me.Equipment.CommonSpecs.Height.SetToNull()
         Me.Equipment.CommonSpecs.OperatingWeight.SetToNull()
         Me.Equipment.CommonSpecs.ShippingWeight.SetToNull()
      End Try

      ' sets control values
      InvokeMethod(Me.specsControl, Me.methodName_SetControlValues, Me.Equipment)

   End Sub

   Private Function IndexOfDisplayMember(display As Double) As Integer
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
   Private Function IsItemSelected(combobox As ComboBox) As Boolean
      Return (Not combobox.SelectedItem Is Nothing)
   End Function


   Private Sub setColors()
      ' colors headings
      Me.lblBaseListPrice.ForeColor = ColorManager.HeaderBlue
      Me.standardOpGrid.CaptionStyle.ForeColor = ColorManager.HeaderBlue

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
      Dim unitQuantityV As New RegularExpressionValidator(ErrorMessages.PositiveInteger("Unit quantity"), rae.validation.regular_expressions.positive_integer)
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
      If user.works_at_resco Then
         Me.cboParMultiplier.DataSource = OrderAssistanceDA.RetrieveRescoMultipliersCommissions()
      ElseIf AppInfo.Division = TSI Then
         Me.cboParMultiplier.DataSource = OrderAssistanceDA.RetrieveTsiMultipliersCommissions()
      ElseIf AppInfo.Division = CRI Then
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
      Dim specsControl = buildSpecsControl(Equipment.Type)
      ' adds specs control to first tab
      Me.tabEquipment.TabPages(0).Controls.Add(specsControl)
      specsControl.Dock = DockStyle.Top

      ' organizes vertical layout
      pricingPanel.SendToBack
      specsControl.SendToBack
      specsHeaderPanel.SendToBack
      modelPanel.SendToBack

      ' sets reference to specs control
      Me.specsControl = Me.tabEquipment.TabPages(0).Controls("SpecsControl")
   End Sub


   ''' <summary>Adds refrigerant, R507a, for Century condensing units.</summary>
   Private Sub addCenturyCondensingUnitRefrigerant()
      If Me.Equipment.Type = EquipmentType.CondensingUnit _
      AndAlso ((AppInfo.Division = Division.CRI) OrElse (AppInfo.Division = TSI AndAlso user.is_employee)) Then
         CType(Me.specsControl, CondensingUnitSpecsControl).cboRefrigerant.Items.Add("R507")
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
         pipingFolder.Create
      
      Dim hasFluidPipingDrawing = (Equipment.Type = EquipmentType.Chiller Or Equipment.Type = EquipmentType.PumpPackage)
      mnuFluidPiping.Visible = hasFluidPipingDrawing
      barFluidPiping.Visible = hasFluidPipingDrawing
      
      Dim hasRefrigerantPipingDrawing = (Equipment.Type = EquipmentType.Chiller Or Equipment.Type = EquipmentType.CondensingUnit)
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
   Private Function parseVoltage(voltageDescription As String) As String
      Dim voltage As String

      ' parses voltage
      voltage = voltageDescription.Substring(0, voltageDescription.IndexOf("/"))

      Return voltage
   End Function

#End Region


#Region " Saving and revisioning"

   ''' <summary>True if equipment is saved (ie is equal to last saved state).</summary>
   ''' <param name="equipment">Equipment item to check if it is saved.</param>
   Private Function isSaved(equipment As EquipmentItem) As Boolean
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
   Private Sub saveInProject(equipment As EquipmentItem)
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
   Private Sub createNewProjectAndEquipment(equipment As EquipmentItem)
      Dim result As DialogResult
      Dim projectName, equipmentName As String

      ' asks user for project and equipment name
      result = Me.askUserToNameProjectAndEquipment(projectName, equipmentName)

      ' does the user want to continue to create a project and save equipment in it
      If result = Forms.DialogResult.OK Then
         ' state - user named project and equipment and wants to continue to save
         ' sets project name to name user entered
         equipment.ProjectManager.Project.Name = projectName
         ' sets equipment's name to name user entered
         equipment.Name = equipmentName
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
      Else
         ' state - user cancelled save
         ' cancels save; ends without saving equipment or creating project
      End If
   End Sub


   ''' <summary>Creates new equipment in project and inserts in data source.</summary>
   ''' <param name="equipment">Equipment to create</param>
   Private Sub createNewEquipment(equipment As EquipmentItem)
      Dim equipmentName As String

      Dim result = Me.askUserToNameEquipment(equipmentName)

      ' did the user want to continue to save
      If result = Forms.DialogResult.OK Then
         ' state - user named equipment
         ' names equipment
         equipment.Name = equipmentName
         ' sets equipment form's title
         Me.Text = equipmentName
         ' set equipment revision...
         equipment.Revision = CSng(Round(Rae.RaeSolutions.DataAccess.Projects.ProjectsDataAccess.RetrieveLatestRevision(OpenedProject.Manager.Project.Id.Id) + 0.001, 3))
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
   Private Sub createEquipmentFromOldRevision(equipment As EquipmentItem, shouldAsk As Boolean)
      Dim revisionForm As New SaveOldRevisionAsRevisionForm()

      If shouldAsk Then
         ' state - ask before saving as revision
         ' asks user if they want to revision old equipment
         Dim result As DialogResult = revisionForm.ShowDialog()
         If result = DialogResult.OK Then
            ' state - user chose to save and revision previous revision
            ' increments revision
            equipment.Revision = equipment.LatestRevision + 1
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
         equipment.Revision = equipment.LatestRevision + 1
         ' inserts equipment into data source and copies local data to shared project
         Me.saveInProject(equipment)
      End If
   End Sub


   ''' <summary>Creates new equipment with a new name from the specified equipment.</summary>
   ''' <param name="equipment">Equipment to create new equipment from.</param>
   Private Sub createAsNewEquipment(equipment As EquipmentItem)
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
         equipmentCopy.Id = New item_id(user.username, user.password)
         ' sets equipment's name
         equipmentCopy.Name = newPricingForm.EquipmentName
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
   Private Sub save()

      If OpenedProject.IsOpened Then
         If Not user.Is(owner) Then
            saveAsRevision(False)
            Exit Sub
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
            If currentEquipment.ExistsInDataSource() = ExistenceStatus.Existent Then
               ' state - equipment exists in data source
               ' have changes been made to equipment
               If Me.isSaved(currentEquipment) Then
                  ' state - NO changes have been made
                  ' ignores save
               Else
                  ' state - changes have been made
                  ' is equipment the latest revision
                  If currentEquipment.IsLatestRevision Then
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
               currentEquipment.Revision = Rae.RaeSolutions.DataAccess.Projects.ProjectsDataAccess.RetrieveLatestRevision(OpenedProject.Manager.Project.Id.Id) + CSng(0.001)
               Me.createNewEquipment(currentEquipment)
            End If
         Else
            ' state - a project is not opened
            currentEquipment.Revision = 0.001
            Me.createNewProjectAndEquipment(currentEquipment)
         End If
      Catch ex As Exception
         Ui.MessageBox.Show("Attempt to save equipment failed. " & ex.Message)
      Finally
         Me.ParentForm.Cursor = Cursors.Default
      End Try
   End Sub
   
   
   ''' <summary>Saves changes on this form to the shared project.</summary>
   ''' <param name="localEquipment">The current equipment being editted on this form.</param>
   ''' <remarks>Other objects subscribe to the events of the shared, not local object.</remarks>
   Private Sub save(localEquipment As EquipmentItem)
      ' gets reference to the shared object of the equipment being displayed in the form
      Dim sharedEquipment = OpenedProject.Manager.Equipment.Items(localEquipment.Id)
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
            If currentEquipment.ExistsInDataSource = ExistenceStatus.Existent Then
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
   Private Sub saveAsRevision(Optional isOwner As Boolean = True)
      Try
         Me.ParentForm.Cursor = Cursors.WaitCursor

         Dim currentEquipment = Me.grabEquipment()

         ' is a project opened
         If OpenedProject.IsOpened Then
            ' state - a project is opened
            ' does equipment exist in data source
            If currentEquipment.ExistsInDataSource = ExistenceStatus.Existent Then
               ' state - equipment exists in data source
               ' increments revision
               currentEquipment.Revision = CSng(System.Math.Round(currentEquipment.LatestRevision + CSng(0.001), 3))
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
            Me.createNewProjectAndEquipment(currentEquipment)
         End If

      Catch ex As Exception
         Ui.MessageBox.Show("Attempt to save and revision equipment failed. " & ex.Message)
      Finally
         Me.ParentForm.Cursor = Cursors.Default
      End Try

   End Sub


   ''' <summary>
   ''' Asks user to save unsaved changes to the latest revision before navigating revisions.
   ''' </summary>
   ''' <param name="equipmentToSave">Equipment with unsaved changes that user may want to save.</param>
   Private Sub saveBeforeNavigatingRevisions(equipmentToSave As EquipmentItem)
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
   Private Sub saveOldBeforeNavigatingRevisions(equipmentToSave As EquipmentItem)
      Dim saveForm As New SaveOldRevisionBeforeNavigatingRevisionsForm()
      Dim result As DialogResult = saveForm.ShowDialog()

      If result = Forms.DialogResult.OK Then
         ' user chose to save as revision
         ' sets revision to a new latest revision
         equipmentToSave.Revision = equipmentToSave.LatestRevision + 1
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
   Private Sub promptUserToSaveBeforeNavigation(previousRevision As Single, newRevision As Single)
      Dim currentEquipment = Me.grabEquipment()

      If isSaved(currentEquipment) Then Exit Sub

      ' checks if this revision is editable (only latest revision is editable)
      If previousRevision = currentEquipment.LatestRevision() Then
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
   Friend Sub populateSelectedOptionsDataSet(authorizedByIsShownInDescription As Boolean)
      ' clears dataset before filling
      Me.selectedOpsDs.Clear()

      For Each row As DataRow In Me.selectedOpTable.Rows
         ' copies selected options
         Me.selectedOpsDs.SelectedOptions.AddSelectedOptionsRow(CInt(row(OCol.ID)), "", _
            row(OCol.Code).ToString, row(OCol.Category).ToString, row(OCol.Description).ToString, CDbl(row(OCol.Price)), _
            CInt(row(OCol.Quantity)), CBool(row(OCol.IsVoltageDependent)), CInt(row(OCol.Voltage)), _
            CBool(row(OCol.ContactFactory)), row(OCol.Details).ToString())
      Next

      If Not Me.standardOpGrid.DataSource Is Nothing Then
         For Each row As DataRow In DirectCast(Me.standardOpGrid.DataSource, DataTable).Rows
            ' copies standard options
            Me.selectedOpsDs.SelectedOptions.AddSelectedOptionsRow(CInt(row(OCol.ID)), "", _
               row(OCol.Code).ToString, "", row(OCol.Description).ToString, CDbl(row(OCol.Price)), _
               CInt(row(OCol.Quantity)), CBool(row(OCol.IsVoltageDependent)), CInt(row(OCol.Voltage)), _
               CBool(row(OCol.ContactFactory)), row(OCol.Details).ToString())
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
            Me.selectedOpsDs.SelectedOptions.AddSelectedOptionsRow(0, "", _
               op.ToString, op.AuthorizedBy, description, op.Price.Value, op.Quantity.Value, _
               False, 0, False, "")
         Next
      End If
   End Sub

#End Region

   Friend Sub syncUnitVoltage()
      isAlreadySyncing = True
      
      ' sets the other unit voltage control in spec control
      InvokeMethod(Me.specsControl, methodName_GetControlValues, Me.Equipment)
      Me.Equipment.CommonSpecs.UnitVoltage.Parse(Me.cboUnitVoltage.SelectedItem.ToString())
      InvokeMethod(Me.specsControl, methodName_SetControlValues, Me.Equipment)
      
      isAlreadySyncing = False
   End Sub

#Region " Abstract"

   ''' <summary>Grabs equipment info from the form</summary>
   Friend Function grabEquipment(Optional includePumpOpsForChiller As Boolean = False) As EquipmentItem

      Me.Equipment.series = Me.EquipmentSelector1.Series
      If Not Me.EquipmentSelector1.Model Is Nothing Then
         Me.Equipment.model_without_series = Me.EquipmentSelector1.Model
      Else
         Me.Equipment.model_without_series = ""
      End If

      Me.Equipment.CustomModel = Me.txtCustomModel.Text.Trim

      Me.Equipment.Pricing.Quantity = CNull.ToInteger(Me.txtUnitQuantity.Text.Trim)

      With Me.Equipment.Pricing
         .ShouldOverrideBaseListPrice = overrideBaseListCheck.Checked
         .OverriddenBaseListPrice = grabPrice(Me.overrideBaseListText)
         .Warranty = Me.grabPrice(Me.txtFourYearCompressorWarranty)
         .Freight = Me.grabPrice(Me.txtFreight)
         .StartUp = Me.grabPrice(Me.txtStartUp)
         ' TODO: re-implement other costs
         .OtherDescription = Me.txtOtherDescription.Text.Trim
         .OtherPrice = Me.grabPrice(Me.txtOther)
         '.Others = Me.GrabPrice(Me.txtOther)
         '.OtherDescription = Me.txtOtherDescription.Text
         .ParMultiplier = Me.GrabParMultiplier()
         ' if multiplierCodeIsApplied Then
         If multiplierCodeTextBox.ReadOnly Then
            .MultiplierCode = New MultiplierCode(multiplierCodeTextBox.Text)
         Else
            .MultiplierCode = Nothing
         End If
         .ListPrice = grabBaseList
      End With

      ' adds options
      Equipment.Options.Clear()
      For Each row As DataRow In Me.selectedOpTable.Rows
      	Dim code = row(OCol.Code).ToString
         ' if not four year compressor warranty
         ' and ( not (integrated pump option)
         '       or should include pump option)
         If code <> "FYCW" _
         AndAlso ( Not ( Equipment.Type = EquipmentType.Chiller _
                         AndAlso ( pump_package_code.matches(code) _
                                   OrElse CType(presenter, chiller_presenter).is_pump_option(code))) _
                   OrElse includePumpOpsForChiller ) Then
            Dim op = rowToOption(row)
            Equipment.Options.Add(op)
         End If
      Next

      ' grabs special options
      Me.Equipment.SpecialOptions = Me.SpecialOptionsControl1.SpecialOptions

      ' updates options revision
      Me.Equipment.Revision = Me.Equipment.Revision

      ' updates equipment with info from spec control
      InvokeMethod(Me.specsControl, Me.methodName_GetControlValues, Me.Equipment)

      Return Me.Equipment
   End Function


   ''' <summary>Displays values from equipment in controls</summary>
   Private Sub displayEquipment(equip As EquipmentItem)
      ' clones equipment b/c on model changed could modify equipment and the saved data could get written over
      Me.Equipment = InvokeMethod(Of EquipmentItem)(equip, "Clone")

      Select Case equip.Type
         Case EquipmentType.ProductCooler, EquipmentType.FluidCooler, EquipmentType.UnitCooler, EquipmentType.NotSet
            ' disables convert to rating menu item
            Me.mnuConvert.Enabled = False
            Me.mnuConvert.ToolTipText = "There is not a rating for this equipment type."
         Case Else
            Me.mnuConvert.Enabled = True
            Me.mnuConvert.ToolTipText = ""
      End Select

      With equip
         Me.Tag = .Id.ToString
         Me.Text = .Name

         Dim series As String = .series
         Dim model As String = .model_without_series
         ' sets specs required to determine available options
         EquipmentSelector1.User = user
         EquipmentSelector1.EquipmentType = .Type.ToString
         EquipmentSelector1.Series = series
         EquipmentSelector1.Model = model

         'workaround: until i find out a better way
         if EquipmentSelector1.Series like "35*"
            equip.CommonSpecs.Mca.SetValue(Equipment.CommonSpecs.Mca.Value)
            equip.CommonSpecs.Rla.SetValue(Equipment.CommonSpecs.Rla.Value)
         end if
         ' Note: invoke SetControlValues before setting the voltage; otherwise values are written over when the form first opens
         ' sets controls in spec control
         InvokeMethod(specsControl, methodName_SetControlValues, equip)
         Me.cboUnitVoltage.SelectedIndex = Me.cboUnitVoltage.Items.IndexOf(.CommonSpecs.UnitVoltage.ToString)  ' RAE.UI.ListHelper.IndexOfComboBoxItem(Me.cboUnitVoltage, .CommonSpecs.UnitVoltage.ToString)

         Me.txtCustomModel.Text = CNull.ToString(.CustomModel)

         Me.txtUnitQuantity.Text = .Pricing.Quantity.ToString

         ' sets pricing
         Me.displayPrice(Me.txtFourYearCompressorWarranty, .Pricing.Warranty)
         Me.displayPrice(Me.txtFreight, .Pricing.Freight)
         Me.displayPrice(Me.txtStartUp, .Pricing.StartUp)
         Me.displayPrice(Me.txtOther, .Pricing.OtherPrice)
         displayPrice(overrideBaseListText, .Pricing.OverriddenBaseListPrice)
         overrideBaseListCheck.Checked = .Pricing.ShouldOverrideBaseListPrice
         Me.txtOtherDescription.Text = .Pricing.OtherDescription

         ' TODO: re-implement other costs
         'Me.DisplayPrice(Me.txtOther, .OtherPrice)
         'Me.txtOtherDescription.Text = .OtherDescription
         If .Pricing.MultiplierCode IsNot Nothing Then
            Me.multiplierCodeTextBox.Text = .Pricing.MultiplierCode.Code
            setCustomMultiplier(.Pricing.MultiplierCode.Multiplier, _
                                .Pricing.MultiplierCode.Commission)
            formatAfterCustomMultiplierApplied()
         Else
            Me.cboParMultiplier.SelectedIndex = Me.IndexOfDisplayMember(.Pricing.ParMultiplier)
         End If
         
         ' resets options total price since the options change when the model changes
         Me.displayTotalOptionsPrice(0, 0)

         availableOpGrid.RemoveAll
         ' checks if values that are necessary to retrieve options have been set yet
         If validateOptionRetrievalInputs Then
            lblNoOptions.Visible = False
            populateAvailableOptionsGrid
            populateStandardOptionsGrid
            ' sets selected options grid structure
            ' TEST: Is table structure set anywhere else, if it is not set here
            selectedOpTable = getOptionsTableStructure
            selectedOpGrid.DataSource = selectedOpTable
            availableOpGrid.Select(.Options)
         End If

         Me.SpecialOptionsControl1.SpecialOptions = .SpecialOptions

         If Equipment.Type = EquipmentType.Chiller _
         AndAlso CType(equip, chiller_equipment).has_pump_package Then
            CType(presenter, chiller_presenter).select_pump_package_option
         End If

         'calculates and displays prices on pricing tab
         calculateAndDisplayPrices

         ' four year compressor warranty
         If .Pricing.Warranty > 0 Then
            chkFourYearCompressorWarranty.Checked = True
         End If

      End With

      setDefaults()
   End Sub

#End Region


#Region " Compressor Warranty"

   Private Sub chkFourYearCompressorWarranty_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkFourYearCompressorWarranty.CheckedChanged
      txtFourYearCompressorWarranty.Enabled = chkFourYearCompressorWarranty.Checked
      If chkFourYearCompressorWarranty.Checked = False Then txtFourYearCompressorWarranty.Text = ""
      For Each r As DataRow In Me.availableOpTable.Rows
         If CNull.ToString(r(OCol.Code)) = "FYCW" Then
            r(OCol.Selected) = chkFourYearCompressorWarranty.Checked
         End If
      Next
   End Sub

   Private Sub label1mouseenter(sender As System.Object, e As System.EventArgs) Handles Label1.MouseEnter
      Label1.Image = My.Resources.Message
   End Sub

   Private Sub label1mouseleave(sender As System.Object, e As System.EventArgs) Handles Label1.MouseLeave
      Label1.Image = My.Resources.Info
   End Sub

   Private Sub label1click(sender As System.Object, e As System.EventArgs) Handles Label1.Click
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

   Private Sub ensureSelectionIn(comboBox As ComboBox)
      If comboBox.SelectedIndex = -1 Then
         comboBox.SelectedIndex = 0
      End If
   End Sub

   Private Sub displayQuantity(quantity As Integer)
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


   protected readOnly property user as user
      get
         return AppInfo.User
      end get
   end property


   Private ReadOnly Property owner As String
      Get
         Dim projectId As item_id = OpenedProject.Manager.Project.Id

         Return ProjectInfo.GetProjectOwner(projectId)
      End Get
   End Property
   
   Private Sub applyMultiplierCode(customMultiplierCode As String)
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
      multiplierCodeAppliedPicture.Visible = True
      discontinueMultiplierCodeButton.Visible = True
      applyMultiplierCodeButton.Visible = False
   End Sub
   
   Private Sub setCustomMultiplier(multiplier As Double, commission As Double)
      Dim table As New DataTable("Custom")
      table.Columns.Add(New DataColumn("Multiplier", GetType(Double)))
      table.Columns.Add(New DataColumn("Commission", GetType(Double)))
      table.Rows.Add(New Object() {multiplier, commission})
      
      cboParMultiplier.DataSource = table
      cboParMultiplier.SelectedIndex = 0
      
      displayPercent(lblCommissionRate, commission)
   End Sub

   Private Sub applyMultiplierCodeButton_Click(s As Object, e As EventArgs) _
   Handles applyMultiplierCodeButton.Click
      applyMultiplierCode(multiplierCodeTextBox.Text)
   End Sub
   
   Private Sub discontinueMultiplierCodeButton_Click(s As Object, e As EventArgs) _
   Handles discontinueMultiplierCodeButton.Click
      populateMultipliersAndCommissionRates()
      
      multiplierCodeTextBox.ReadOnly = False
      cboParMultiplier.Enabled = True
      multiplierCodeAppliedPicture.Visible = False
      applyMultiplierCodeButton.Visible = True
      discontinueMultiplierCodeButton.Visible = False
   End Sub

   Private Sub groupLink_Toggled(s As Object, e As Rae.Ui.Controls.ToggledEventArgs) _
   Handles groupLink.Toggled
      If e.IsToggled Then _
         availableOpGrid.Ungroup _
      Else _
         availableOpGrid.GroupByCategory
   End Sub

   Private Sub unselectLink_Click(s As Object, e As EventArgs) _
   Handles unselectLink.Click
      availableOpGrid.UnselectAll
   End Sub
   
   ''' <summary>Converts an option row to an option object</summary>
   ''' <param name="optionRow">DataRow to convert to Option object.</param>
   ''' <exception cref="System.ArgumentException">Thrown when optionRow can not be converted to option object 
   ''' because of table structure
   ''' </exception>
   Protected Function rowToOption(optionRow As DataRow) As EquipmentOption
      Return RowTo.Option(optionRow, Equipment)
   End Function
   
Private Sub availableOpGrid_Ungrouped( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles availableOpGrid.Ungrouped

End Sub
Private Sub availableOpGrid_Grouped( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles availableOpGrid.GroupedByCategory

End Sub
End Class

Module RowTo

   ''' <summary>Converts an option row to an option object</summary>
   ''' <param name="optionRow">DataRow to convert to Option object.</param>
   ''' <exception cref="System.ArgumentException">Thrown when optionRow can not be converted to option object 
   ''' because of table structure
   ''' </exception>
   Function [Option](optionRow As DataRow, equipment As EquipmentItem) As EquipmentOption
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
      op.Per = CNull.ToString( optionRow(OCol.Per) )
      op.Equipment = equipment 

      Return op
   End Function
   
End Module

'Convert(op).In(table).ToRow

Public Class Converter

   Private row As DataRow
   Private op As EquipmentOption
   
   Private Sub New(op As EquipmentOption)
      Me.op = op
   End Sub
   
   Shared Function Convert(op As EquipmentOption) As Converter
      Return New Converter(op)
   End Function
   
   Function [In](table As DataTable) As Converter
      row = convert(op, table)
      Return Me
   End Function
   
   Function ToRow() As DataRow
      Return row
   End Function
   
   Private Function convert(op As EquipmentOption, table As DataTable) As DataRow
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
