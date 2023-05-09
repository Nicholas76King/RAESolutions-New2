Imports System
Imports System.Math
Imports System.Environment
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Forms = System.Windows.Forms
Imports Rae.Math.Calculate
Imports Rae.RaeSolutions.Business
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.Business.Intelligence
Imports Rae.solutions.condensing_units
Imports Rae.solutions.group
Imports Rae.RaeSolutions.DataAccess
Imports Rae.solutions
Imports Rae.solutions.compressors
Imports Rae.Ui
Imports Rae.Io.Text
Imports Intelligence = Rae.RaeSolutions.Business.Intelligence
Imports System.Collections.Generic
Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports Rae.RaeSolutions.DataAccess.CompressorDataAccess



Public Class condensing_unit_rating_screen
    Inherits System.Windows.Forms.Form

    Friend WithEvents OpenCondensingUnitRatingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents RevisionCondensingUnitRatingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveAsNewMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Private WithEvents notesTextBox As System.Windows.Forms.TextBox
    Private WithEvents notesLabel As System.Windows.Forms.Label
    Friend WithEvents btnNewEquipmentPricing As System.Windows.Forms.Button
    ''Friend WithEvents inputsHeader As Rae.Ui.Controls.CollapsableHeader
    ''Friend WithEvents outputsHeader As Rae.Ui.Controls.Header
    ''Friend WithEvents ratingModelHeader As Rae.Ui.Controls.Header
    ''Friend WithEvents ratingHeader As Rae.Ui.Controls.Header
    Friend WithEvents timerHighlightReturn As System.Windows.Forms.Timer
    Friend WithEvents btnReturn As System.Windows.Forms.Button
    Public WithEvents btnCoolStuffInvoke As System.Windows.Forms.Button
    Public WithEvents txtCoolStuffID As System.Windows.Forms.TextBox
    Friend WithEvents txtCoolStuffBLName As System.Windows.Forms.TextBox
    Friend WithEvents lblBoxLoadLinkedTo As System.Windows.Forms.Label
    Public WithEvents btnRemoveBoxLoadLink As System.Windows.Forms.Button
    Friend WithEvents grpBoxLoad As System.Windows.Forms.GroupBox
    Friend WithEvents grpRunTime As System.Windows.Forms.GroupBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents compressorIsUsing10CoefficientsPanel As System.Windows.Forms.Panel
    Friend WithEvents voltageComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents voltageLabel As System.Windows.Forms.Label
    Friend WithEvents numCompressorCoefficientsLabel As System.Windows.Forms.Label
    Friend WithEvents numCompressorCoefficientsComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents voltageRatingComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents voltageRatingLabel As System.Windows.Forms.Label
    Friend WithEvents lbl20A4 As System.Windows.Forms.Label
    Friend WithEvents cbo20A4 As System.Windows.Forms.ComboBox
    Friend WithEvents lblNSC As System.Windows.Forms.Label
    Friend WithEvents lblNDB As System.Windows.Forms.Label
    Friend WithEvents lblNSB As System.Windows.Forms.Label
    Friend WithEvents lblBLU_L As System.Windows.Forms.Label
    Friend WithEvents cboNSC As System.Windows.Forms.ComboBox
    Friend WithEvents cboNDB As System.Windows.Forms.ComboBox
    Friend WithEvents cboNSB As System.Windows.Forms.ComboBox
    Friend WithEvents cboBLU_L As System.Windows.Forms.ComboBox
    Friend WithEvents lblNDC As System.Windows.Forms.Label
    Friend WithEvents cboNDC As System.Windows.Forms.ComboBox
    Friend WithEvents txtCustomCFM1 As System.Windows.Forms.TextBox
    Friend WithEvents lblCustomCFM1 As System.Windows.Forms.Label
    Friend WithEvents txtCustomCFM2 As System.Windows.Forms.TextBox
    Friend WithEvents lblCustomCFM2 As System.Windows.Forms.Label
    Friend WithEvents cboCTLimit As System.Windows.Forms.ComboBox
    Friend WithEvents lblCTLimit As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents coilComboBox_1 As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_fpi_1 As System.Windows.Forms.ComboBox
    Friend WithEvents lblCoilFinHeight1 As System.Windows.Forms.Label
    Friend WithEvents lblCoilFinWidth1 As System.Windows.Forms.Label
    Friend WithEvents lblFinsPerInch1 As System.Windows.Forms.Label
    Friend WithEvents txt_fin_length_1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_fin_height_1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents coilComboBox_2 As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_fpi_2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblCoilsRequiredValue2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_fin_length_2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_fin_height_2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCoilSubCoolingPercentage2 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCapMult1 As System.Windows.Forms.TextBox
    Friend WithEvents lblCapMult1 As System.Windows.Forms.Label
    Friend WithEvents txtCapMult2 As System.Windows.Forms.TextBox
    Friend WithEvents lblCapMult2 As System.Windows.Forms.Label
    Friend WithEvents cboUSTLimit As System.Windows.Forms.ComboBox
    Friend WithEvents lblUSTLimit As System.Windows.Forms.Label
    Friend WithEvents lblDemandCoolingNote As System.Windows.Forms.Label
    Friend WithEvents lblNMC As System.Windows.Forms.Label
    Friend WithEvents cboNMC As System.Windows.Forms.ComboBox
    Friend WithEvents lblNMB As System.Windows.Forms.Label
    Friend WithEvents cboNMB As System.Windows.Forms.ComboBox
    Friend WithEvents txtFanRPM1 As System.Windows.Forms.TextBox
    Friend WithEvents lblFanRPM1 As System.Windows.Forms.Label
    Friend WithEvents txtFanRPM2 As System.Windows.Forms.TextBox
    Friend WithEvents lblFanRPM2 As System.Windows.Forms.Label
    Friend WithEvents lblBLU_B As System.Windows.Forms.Label
    Friend WithEvents cboBLU_B As System.Windows.Forms.ComboBox
    Friend WithEvents lblCustomPower1 As System.Windows.Forms.Label
    Friend WithEvents txtCustomPower1 As System.Windows.Forms.TextBox
    Friend WithEvents lblCustomPower2 As System.Windows.Forms.Label
    Friend WithEvents txtCustomPower2 As System.Windows.Forms.TextBox
    Friend WithEvents txtDOECompliant As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ddlDOEModels As System.Windows.Forms.ComboBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Grid1 As Grid
    Friend WithEvents BestSelectionsGrid1 As BestSelectionsGrid
    Friend WithEvents btnCreateReport As Button
    Dim DemandCoolingNote As Boolean = False

#Region " Windows Form Designer generated code "

    Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        compressor_repo = New compressor_repository()
        repository = New condensing_units.Repository()
        service = New CondensingUnitRatingService(compressor_repo)
    End Sub

    Private compressor_repo As i_compressor_repository
    ' todo: don't expose repository if not necessary, hide behind service
    Private repository As I_Repository
    Private service As CondensingUnitRatingService


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Private WithEvents lblCondensingUnitSeries As System.Windows.Forms.Label
    Private WithEvents lblCapacityRequired As System.Windows.Forms.Label

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblRunTime As System.Windows.Forms.Label
    Friend WithEvents cboCondensingUnitSeries As System.Windows.Forms.ComboBox
    Friend WithEvents txtCapacity As System.Windows.Forms.TextBox
    Friend WithEvents txtRunTime As System.Windows.Forms.TextBox
    Private WithEvents lblRunTimeAdjust As System.Windows.Forms.Label
    Friend WithEvents radRunTimeAdjustYes As System.Windows.Forms.RadioButton
    Friend WithEvents panRunTimeAdjust As System.Windows.Forms.Panel
    Friend WithEvents radRunTimeAdjustNo As System.Windows.Forms.RadioButton
    Private WithEvents lblAmbientTemperature As System.Windows.Forms.Label
    Friend WithEvents txtSelectionTabAmbient As System.Windows.Forms.TextBox
    Private WithEvents lblSuctionTemperature As System.Windows.Forms.Label
    Friend WithEvents txtSelectionTabSuction As System.Windows.Forms.TextBox
    Private WithEvents refrigerantLabel As System.Windows.Forms.Label
    Friend WithEvents cboSelectionTabRefrigerant As System.Windows.Forms.ComboBox
    Private WithEvents lblCompressor As System.Windows.Forms.Label
    Friend WithEvents cboCompressor As System.Windows.Forms.ComboBox
    Friend WithEvents lblCompressorPerUnit As System.Windows.Forms.Label
    Private WithEvents lblCircuitsPerUnit As System.Windows.Forms.Label
    Private WithEvents lblAltitude As System.Windows.Forms.Label
    Friend WithEvents txtSelectionTabAltitude As System.Windows.Forms.TextBox
    Friend WithEvents cboCompressorPerUnit As System.Windows.Forms.ComboBox
    Friend WithEvents cboCircuitsPerUnit As System.Windows.Forms.ComboBox
    Friend WithEvents lblCondensingUnitsRequired As System.Windows.Forms.Label
    Friend WithEvents txtCondensingUnitsRequired As System.Windows.Forms.TextBox
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents panRun As System.Windows.Forms.Panel
    Friend WithEvents rbo_unit_selection As System.Windows.Forms.RadioButton
    Friend WithEvents radUnitRating As System.Windows.Forms.RadioButton
    Friend WithEvents panInputsBody As System.Windows.Forms.Panel
    Friend WithEvents panOutputsBody As System.Windows.Forms.Panel
    Friend WithEvents rbo_condensing_unit_1 As System.Windows.Forms.RadioButton
    Friend WithEvents panCondensingUnit As System.Windows.Forms.Panel
    Friend WithEvents rbo_condensing_unit_2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbo_condensing_unit_3 As System.Windows.Forms.RadioButton
    Friend WithEvents btnRating As System.Windows.Forms.Button
    Friend WithEvents panMain As System.Windows.Forms.Panel
    Friend WithEvents panSelectCondensingUnit As System.Windows.Forms.Panel
    Friend WithEvents cboLUI As System.Windows.Forms.ComboBox
    Friend WithEvents cboLUO As System.Windows.Forms.ComboBox
    Friend WithEvents cboDD As System.Windows.Forms.ComboBox
    Friend WithEvents panRatingBody As System.Windows.Forms.Panel
    Friend WithEvents cboDM As System.Windows.Forms.ComboBox
    Friend WithEvents cboDS As System.Windows.Forms.ComboBox
    Friend WithEvents lblLUI As System.Windows.Forms.Label
    Friend WithEvents lblLUO As System.Windows.Forms.Label
    Friend WithEvents lblDD As System.Windows.Forms.Label
    Friend WithEvents lblDM As System.Windows.Forms.Label
    Friend WithEvents lblDS As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnRating2 As System.Windows.Forms.Button
    Friend WithEvents tabCondensingUnit As System.Windows.Forms.TabControl
    Friend WithEvents tabSelection As System.Windows.Forms.TabPage
    Friend WithEvents tabRating As System.Windows.Forms.TabPage
    Friend WithEvents panRatingDataBody As System.Windows.Forms.Panel
    Friend WithEvents lblRatingCondensingUnitModel As System.Windows.Forms.Label
    Friend WithEvents lblRatingCondensingUnitModelValue As System.Windows.Forms.Label
    Friend WithEvents lblRatingCapacity As System.Windows.Forms.Label
    Friend WithEvents lblRatingCapacityValue As System.Windows.Forms.Label
    Friend WithEvents lblRatingAmbientTemperature As System.Windows.Forms.Label
    Friend WithEvents txtRatingTabAmbient As System.Windows.Forms.TextBox
    Friend WithEvents lblRatingAmbientInterval As System.Windows.Forms.Label
    Friend WithEvents cboRatingAmbientInterval As System.Windows.Forms.ComboBox
    Friend WithEvents lblRatingAmbientSteps As System.Windows.Forms.Label
    Friend WithEvents cboRatingAmbientSteps As System.Windows.Forms.ComboBox
    Friend WithEvents lblRatingSuction As System.Windows.Forms.Label
    Friend WithEvents txt_rating_tab_suction As System.Windows.Forms.TextBox
    Friend WithEvents lblRatingSuctionInterval As System.Windows.Forms.Label
    Friend WithEvents cboRatingSuctionInterval As System.Windows.Forms.ComboBox
    Friend WithEvents lblRatingSuctionSteps As System.Windows.Forms.Label
    Friend WithEvents cboRatingSuctionSteps As System.Windows.Forms.ComboBox
    Friend WithEvents lblRatingRefrigerant As System.Windows.Forms.Label
    Friend WithEvents cbo_rating_tab_refrigerant As System.Windows.Forms.ComboBox
    Friend WithEvents lblRatingAltitude As System.Windows.Forms.Label
    Friend WithEvents txtRatingTabAltitude As System.Windows.Forms.TextBox
    Friend WithEvents lblRatingSubCooling As System.Windows.Forms.Label
    Friend WithEvents cboRatingSubCooling As System.Windows.Forms.ComboBox
    Friend WithEvents lblRatingLiquidCooling As System.Windows.Forms.Label
    Friend WithEvents txt_subcooling_temperature As System.Windows.Forms.TextBox
    Friend WithEvents lblRatingCatalog As System.Windows.Forms.Label
    Friend WithEvents cboRatingCatalog As System.Windows.Forms.ComboBox
    Friend WithEvents lblRatingHertz As System.Windows.Forms.Label
    Friend WithEvents cboRatingHertz As System.Windows.Forms.ComboBox
    Friend WithEvents lblRatingSafety As System.Windows.Forms.Label
    Friend WithEvents cboRatingSafety As System.Windows.Forms.ComboBox
    Friend WithEvents panRatingMain As System.Windows.Forms.Panel
    Friend WithEvents panRatingCircuitBody As System.Windows.Forms.Panel
    Friend WithEvents lblCompressorQuantity1 As System.Windows.Forms.Label
    Friend WithEvents cbo_compressor_1 As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_compressor_quantity_1 As System.Windows.Forms.ComboBox
    Friend WithEvents lblCoilsRequiredValue1 As System.Windows.Forms.Label
    Friend WithEvents lblFanQuantity1 As System.Windows.Forms.Label
    Friend WithEvents cbo_fan_quantity_1 As System.Windows.Forms.ComboBox
    Friend WithEvents cboFan1 As System.Windows.Forms.ComboBox
    Friend WithEvents lblCoilSubCoolingPercentage1 As System.Windows.Forms.Label
    Friend WithEvents txtCoilSubCoolingPercentage1 As System.Windows.Forms.TextBox
    Friend WithEvents panCircuit1 As System.Windows.Forms.Panel
    Friend WithEvents tabCircuits As System.Windows.Forms.TabControl
    Friend WithEvents tabCircuit1 As System.Windows.Forms.TabPage
    Friend WithEvents tabCircuit2 As System.Windows.Forms.TabPage
    Friend WithEvents tabCircuit3 As System.Windows.Forms.TabPage
    Friend WithEvents tabCircuit4 As System.Windows.Forms.TabPage
    Friend WithEvents panCircuit2 As System.Windows.Forms.Panel
    Friend WithEvents cbo_compressor_2 As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_compressor_quantity_2 As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_fan_quantity_2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboFan2 As System.Windows.Forms.ComboBox
    Friend WithEvents panCircuit3 As System.Windows.Forms.Panel
    Friend WithEvents cboCompressor3 As System.Windows.Forms.ComboBox
    Friend WithEvents txtCoilFinWidth3 As System.Windows.Forms.TextBox
    Friend WithEvents cboCompressorQuantity3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboFanQuantity3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboFanDiameter3 As System.Windows.Forms.ComboBox
    Friend WithEvents txtCoilFinHeight3 As System.Windows.Forms.TextBox
    Friend WithEvents txtCoilSubCoolingPercentage3 As System.Windows.Forms.TextBox
    Friend WithEvents cboFinsPerInch3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboCompressor4 As System.Windows.Forms.ComboBox
    Friend WithEvents txtCoilFinWidth4 As System.Windows.Forms.TextBox
    Friend WithEvents cboCompressorQuantity4 As System.Windows.Forms.ComboBox
    Friend WithEvents cboFanQuantity4 As System.Windows.Forms.ComboBox
    Friend WithEvents cboFanDiameter4 As System.Windows.Forms.ComboBox
    Friend WithEvents txtCoilFinHeight4 As System.Windows.Forms.TextBox
    Friend WithEvents txtCoilSubCoolingPercentage4 As System.Windows.Forms.TextBox
    Friend WithEvents cboCoilRows4 As System.Windows.Forms.ComboBox
    Friend WithEvents cboFinsPerInch4 As System.Windows.Forms.ComboBox
    Friend WithEvents btnRateUnit As System.Windows.Forms.Button
    Friend WithEvents panCircuit4 As System.Windows.Forms.Panel
    Friend WithEvents lblCoilsRequiredValue3 As System.Windows.Forms.Label
    Friend WithEvents lblAmbientTemperatureRange As System.Windows.Forms.Label
    Friend WithEvents lblSuctionTemperatureRange As System.Windows.Forms.Label
    Friend WithEvents lblCoilsRequiredValue4 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents tabResults As System.Windows.Forms.TabPage
    Friend WithEvents lblResultsCondenserCapacity As System.Windows.Forms.Label
    Friend WithEvents lblResultsCondenserCapacityValue As System.Windows.Forms.Label
    Friend WithEvents lblResultsNumberOfCompressors As System.Windows.Forms.Label
    Friend WithEvents lblResultsNumberOfCompressorsValue As System.Windows.Forms.Label
    Friend WithEvents lblResultsNumberOfFans As System.Windows.Forms.Label
    Friend WithEvents lblResultsNumberOfFansValue As System.Windows.Forms.Label
    Friend WithEvents lblResultsAltitude As System.Windows.Forms.Label
    Friend WithEvents lblResultsAltitudeValue As System.Windows.Forms.Label
    Friend WithEvents lblSelectionTabCapacityUnits As System.Windows.Forms.Label
    Friend WithEvents lblFeet As System.Windows.Forms.Label
    Friend WithEvents lblRunTimeUnits As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents lblResultsOmit As System.Windows.Forms.Label
    Friend WithEvents gboCompressor1 As System.Windows.Forms.GroupBox
    Friend WithEvents gboCoil1 As System.Windows.Forms.GroupBox
    Friend WithEvents gboFan1 As System.Windows.Forms.GroupBox
    Friend WithEvents gboCompressor2 As System.Windows.Forms.GroupBox
    Friend WithEvents gboFan2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo20A0 As System.Windows.Forms.ComboBox
    Friend WithEvents panRatingBodyTSI As System.Windows.Forms.Panel
    Friend WithEvents lbl20a0 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnRating3 As System.Windows.Forms.Button
    Friend WithEvents panRatingHideFromRep As System.Windows.Forms.Panel
    Friend WithEvents panRateUnit As System.Windows.Forms.Panel
    Friend WithEvents txt_custom_model As System.Windows.Forms.TextBox
    Friend WithEvents panCreateReport As System.Windows.Forms.Panel
    Friend WithEvents lblNoCondensingUnits As System.Windows.Forms.Label
    Friend WithEvents lblRatingTabCapacityUnits As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFilePrintCondensingUnits As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveCondToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConvertToEquipmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label37 As System.Windows.Forms.Label

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(condensing_unit_rating_screen))
        Me.lblCondensingUnitSeries = New System.Windows.Forms.Label()
        Me.lblCapacityRequired = New System.Windows.Forms.Label()
        Me.cboCondensingUnitSeries = New System.Windows.Forms.ComboBox()
        Me.txtCapacity = New System.Windows.Forms.TextBox()
        Me.txtRunTime = New System.Windows.Forms.TextBox()
        Me.lblRunTimeAdjust = New System.Windows.Forms.Label()
        Me.radRunTimeAdjustYes = New System.Windows.Forms.RadioButton()
        Me.panRunTimeAdjust = New System.Windows.Forms.Panel()
        Me.radRunTimeAdjustNo = New System.Windows.Forms.RadioButton()
        Me.lblAmbientTemperature = New System.Windows.Forms.Label()
        Me.txtSelectionTabAmbient = New System.Windows.Forms.TextBox()
        Me.lblSuctionTemperature = New System.Windows.Forms.Label()
        Me.txtSelectionTabSuction = New System.Windows.Forms.TextBox()
        Me.refrigerantLabel = New System.Windows.Forms.Label()
        Me.cboSelectionTabRefrigerant = New System.Windows.Forms.ComboBox()
        Me.lblCompressor = New System.Windows.Forms.Label()
        Me.cboCompressor = New System.Windows.Forms.ComboBox()
        Me.lblCompressorPerUnit = New System.Windows.Forms.Label()
        Me.lblCircuitsPerUnit = New System.Windows.Forms.Label()
        Me.lblAltitude = New System.Windows.Forms.Label()
        Me.txtSelectionTabAltitude = New System.Windows.Forms.TextBox()
        Me.cboCompressorPerUnit = New System.Windows.Forms.ComboBox()
        Me.cboCircuitsPerUnit = New System.Windows.Forms.ComboBox()
        Me.lblCondensingUnitsRequired = New System.Windows.Forms.Label()
        Me.txtCondensingUnitsRequired = New System.Windows.Forms.TextBox()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.panRun = New System.Windows.Forms.Panel()
        Me.radUnitRating = New System.Windows.Forms.RadioButton()
        Me.rbo_unit_selection = New System.Windows.Forms.RadioButton()
        Me.panInputsBody = New System.Windows.Forms.Panel()
        Me.ddlDOEModels = New System.Windows.Forms.ComboBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.grpRunTime = New System.Windows.Forms.GroupBox()
        Me.lblRunTimeUnits = New System.Windows.Forms.Label()
        Me.grpBoxLoad = New System.Windows.Forms.GroupBox()
        Me.btnRemoveBoxLoadLink = New System.Windows.Forms.Button()
        Me.lblBoxLoadLinkedTo = New System.Windows.Forms.Label()
        Me.btnCoolStuffInvoke = New System.Windows.Forms.Button()
        Me.txtCoolStuffBLName = New System.Windows.Forms.TextBox()
        Me.txtCoolStuffID = New System.Windows.Forms.TextBox()
        Me.voltageComboBox = New System.Windows.Forms.ComboBox()
        Me.voltageLabel = New System.Windows.Forms.Label()
        Me.notesTextBox = New System.Windows.Forms.TextBox()
        Me.notesLabel = New System.Windows.Forms.Label()
        Me.lblFeet = New System.Windows.Forms.Label()
        Me.lblSelectionTabCapacityUnits = New System.Windows.Forms.Label()
        Me.lblSuctionTemperatureRange = New System.Windows.Forms.Label()
        Me.lblAmbientTemperatureRange = New System.Windows.Forms.Label()
        Me.compressorIsUsing10CoefficientsPanel = New System.Windows.Forms.Panel()
        Me.numCompressorCoefficientsLabel = New System.Windows.Forms.Label()
        Me.numCompressorCoefficientsComboBox = New System.Windows.Forms.ComboBox()
        Me.panOutputsBody = New System.Windows.Forms.Panel()
        Me.BestSelectionsGrid1 = New Rae.RaeSolutions.BestSelectionsGrid()
        Me.rbo_condensing_unit_1 = New System.Windows.Forms.RadioButton()
        Me.panCondensingUnit = New System.Windows.Forms.Panel()
        Me.rbo_condensing_unit_3 = New System.Windows.Forms.RadioButton()
        Me.rbo_condensing_unit_2 = New System.Windows.Forms.RadioButton()
        Me.btnRating = New System.Windows.Forms.Button()
        Me.panMain = New System.Windows.Forms.Panel()
        Me.panRatingBodyTSI = New System.Windows.Forms.Panel()
        Me.lbl20A4 = New System.Windows.Forms.Label()
        Me.cbo20A4 = New System.Windows.Forms.ComboBox()
        Me.btnRating3 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbl20a0 = New System.Windows.Forms.Label()
        Me.cbo20A0 = New System.Windows.Forms.ComboBox()
        Me.panRatingBody = New System.Windows.Forms.Panel()
        Me.lblBLU_B = New System.Windows.Forms.Label()
        Me.cboBLU_B = New System.Windows.Forms.ComboBox()
        Me.lblNMC = New System.Windows.Forms.Label()
        Me.cboNMC = New System.Windows.Forms.ComboBox()
        Me.lblNMB = New System.Windows.Forms.Label()
        Me.cboNMB = New System.Windows.Forms.ComboBox()
        Me.lblNDC = New System.Windows.Forms.Label()
        Me.cboNDC = New System.Windows.Forms.ComboBox()
        Me.lblNSC = New System.Windows.Forms.Label()
        Me.lblNDB = New System.Windows.Forms.Label()
        Me.lblNSB = New System.Windows.Forms.Label()
        Me.lblBLU_L = New System.Windows.Forms.Label()
        Me.cboNSC = New System.Windows.Forms.ComboBox()
        Me.cboNDB = New System.Windows.Forms.ComboBox()
        Me.cboNSB = New System.Windows.Forms.ComboBox()
        Me.cboBLU_L = New System.Windows.Forms.ComboBox()
        Me.btnRating2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDS = New System.Windows.Forms.Label()
        Me.lblDM = New System.Windows.Forms.Label()
        Me.lblDD = New System.Windows.Forms.Label()
        Me.lblLUO = New System.Windows.Forms.Label()
        Me.lblLUI = New System.Windows.Forms.Label()
        Me.cboDS = New System.Windows.Forms.ComboBox()
        Me.cboDM = New System.Windows.Forms.ComboBox()
        Me.cboDD = New System.Windows.Forms.ComboBox()
        Me.cboLUO = New System.Windows.Forms.ComboBox()
        Me.cboLUI = New System.Windows.Forms.ComboBox()
        Me.panSelectCondensingUnit = New System.Windows.Forms.Panel()
        Me.lblNoCondensingUnits = New System.Windows.Forms.Label()
        Me.tabCondensingUnit = New System.Windows.Forms.TabControl()
        Me.tabSelection = New System.Windows.Forms.TabPage()
        Me.tabRating = New System.Windows.Forms.TabPage()
        Me.panRatingMain = New System.Windows.Forms.Panel()
        Me.panRateUnit = New System.Windows.Forms.Panel()
        Me.btnRateUnit = New System.Windows.Forms.Button()
        Me.panRatingCircuitBody = New System.Windows.Forms.Panel()
        Me.tabCircuits = New System.Windows.Forms.TabControl()
        Me.tabCircuit1 = New System.Windows.Forms.TabPage()
        Me.panCircuit1 = New System.Windows.Forms.Panel()
        Me.gboFan1 = New System.Windows.Forms.GroupBox()
        Me.lblCustomPower1 = New System.Windows.Forms.Label()
        Me.txtCustomPower1 = New System.Windows.Forms.TextBox()
        Me.txtFanRPM1 = New System.Windows.Forms.TextBox()
        Me.lblFanRPM1 = New System.Windows.Forms.Label()
        Me.txtCustomCFM1 = New System.Windows.Forms.TextBox()
        Me.lblCustomCFM1 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.lblFanQuantity1 = New System.Windows.Forms.Label()
        Me.cbo_fan_quantity_1 = New System.Windows.Forms.ComboBox()
        Me.cboFan1 = New System.Windows.Forms.ComboBox()
        Me.gboCompressor1 = New System.Windows.Forms.GroupBox()
        Me.txtCapMult1 = New System.Windows.Forms.TextBox()
        Me.lblCapMult1 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.lblCompressorQuantity1 = New System.Windows.Forms.Label()
        Me.cbo_compressor_quantity_1 = New System.Windows.Forms.ComboBox()
        Me.cbo_compressor_1 = New System.Windows.Forms.ComboBox()
        Me.gboCoil1 = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.coilComboBox_1 = New System.Windows.Forms.ComboBox()
        Me.cbo_fpi_1 = New System.Windows.Forms.ComboBox()
        Me.lblCoilFinHeight1 = New System.Windows.Forms.Label()
        Me.lblCoilFinWidth1 = New System.Windows.Forms.Label()
        Me.lblCoilsRequiredValue1 = New System.Windows.Forms.Label()
        Me.lblFinsPerInch1 = New System.Windows.Forms.Label()
        Me.txt_fin_length_1 = New System.Windows.Forms.TextBox()
        Me.txt_fin_height_1 = New System.Windows.Forms.TextBox()
        Me.txtCoilSubCoolingPercentage1 = New System.Windows.Forms.TextBox()
        Me.lblCoilSubCoolingPercentage1 = New System.Windows.Forms.Label()
        Me.tabCircuit2 = New System.Windows.Forms.TabPage()
        Me.panCircuit2 = New System.Windows.Forms.Panel()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.coilComboBox_2 = New System.Windows.Forms.ComboBox()
        Me.cbo_fpi_2 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblCoilsRequiredValue2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_fin_length_2 = New System.Windows.Forms.TextBox()
        Me.txt_fin_height_2 = New System.Windows.Forms.TextBox()
        Me.txtCoilSubCoolingPercentage2 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.gboFan2 = New System.Windows.Forms.GroupBox()
        Me.lblCustomPower2 = New System.Windows.Forms.Label()
        Me.txtCustomPower2 = New System.Windows.Forms.TextBox()
        Me.txtFanRPM2 = New System.Windows.Forms.TextBox()
        Me.lblFanRPM2 = New System.Windows.Forms.Label()
        Me.txtCustomCFM2 = New System.Windows.Forms.TextBox()
        Me.lblCustomCFM2 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.cbo_fan_quantity_2 = New System.Windows.Forms.ComboBox()
        Me.cboFan2 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gboCompressor2 = New System.Windows.Forms.GroupBox()
        Me.txtCapMult2 = New System.Windows.Forms.TextBox()
        Me.lblCapMult2 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbo_compressor_2 = New System.Windows.Forms.ComboBox()
        Me.cbo_compressor_quantity_2 = New System.Windows.Forms.ComboBox()
        Me.tabCircuit3 = New System.Windows.Forms.TabPage()
        Me.panCircuit3 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboFanQuantity3 = New System.Windows.Forms.ComboBox()
        Me.cboFanDiameter3 = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblCoilsRequiredValue3 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtCoilFinWidth3 = New System.Windows.Forms.TextBox()
        Me.txtCoilFinHeight3 = New System.Windows.Forms.TextBox()
        Me.cboFinsPerInch3 = New System.Windows.Forms.ComboBox()
        Me.txtCoilSubCoolingPercentage3 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cboCompressor3 = New System.Windows.Forms.ComboBox()
        Me.cboCompressorQuantity3 = New System.Windows.Forms.ComboBox()
        Me.tabCircuit4 = New System.Windows.Forms.TabPage()
        Me.panCircuit4 = New System.Windows.Forms.Panel()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cboFanQuantity4 = New System.Windows.Forms.ComboBox()
        Me.cboFanDiameter4 = New System.Windows.Forms.ComboBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cboFinsPerInch4 = New System.Windows.Forms.ComboBox()
        Me.txtCoilFinWidth4 = New System.Windows.Forms.TextBox()
        Me.txtCoilFinHeight4 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cboCoilRows4 = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.lblCoilsRequiredValue4 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtCoilSubCoolingPercentage4 = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboCompressorQuantity4 = New System.Windows.Forms.ComboBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.cboCompressor4 = New System.Windows.Forms.ComboBox()
        Me.panRatingHideFromRep = New System.Windows.Forms.Panel()
        Me.txtDOECompliant = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboUSTLimit = New System.Windows.Forms.ComboBox()
        Me.lblUSTLimit = New System.Windows.Forms.Label()
        Me.cboCTLimit = New System.Windows.Forms.ComboBox()
        Me.lblCTLimit = New System.Windows.Forms.Label()
        Me.cboRatingSubCooling = New System.Windows.Forms.ComboBox()
        Me.lblRatingSubCooling = New System.Windows.Forms.Label()
        Me.cboRatingSafety = New System.Windows.Forms.ComboBox()
        Me.lblRatingSafety = New System.Windows.Forms.Label()
        Me.cboRatingHertz = New System.Windows.Forms.ComboBox()
        Me.lblRatingHertz = New System.Windows.Forms.Label()
        Me.cboRatingCatalog = New System.Windows.Forms.ComboBox()
        Me.lblRatingCatalog = New System.Windows.Forms.Label()
        Me.txt_subcooling_temperature = New System.Windows.Forms.TextBox()
        Me.lblRatingLiquidCooling = New System.Windows.Forms.Label()
        Me.panRatingDataBody = New System.Windows.Forms.Panel()
        Me.voltageRatingComboBox = New System.Windows.Forms.ComboBox()
        Me.voltageRatingLabel = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblRatingTabCapacityUnits = New System.Windows.Forms.Label()
        Me.txt_custom_model = New System.Windows.Forms.TextBox()
        Me.txtRatingTabAltitude = New System.Windows.Forms.TextBox()
        Me.lblRatingAltitude = New System.Windows.Forms.Label()
        Me.cbo_rating_tab_refrigerant = New System.Windows.Forms.ComboBox()
        Me.lblRatingRefrigerant = New System.Windows.Forms.Label()
        Me.cboRatingSuctionSteps = New System.Windows.Forms.ComboBox()
        Me.lblRatingSuctionSteps = New System.Windows.Forms.Label()
        Me.cboRatingSuctionInterval = New System.Windows.Forms.ComboBox()
        Me.lblRatingSuctionInterval = New System.Windows.Forms.Label()
        Me.txt_rating_tab_suction = New System.Windows.Forms.TextBox()
        Me.lblRatingSuction = New System.Windows.Forms.Label()
        Me.cboRatingAmbientSteps = New System.Windows.Forms.ComboBox()
        Me.lblRatingAmbientSteps = New System.Windows.Forms.Label()
        Me.cboRatingAmbientInterval = New System.Windows.Forms.ComboBox()
        Me.lblRatingAmbientInterval = New System.Windows.Forms.Label()
        Me.txtRatingTabAmbient = New System.Windows.Forms.TextBox()
        Me.lblRatingAmbientTemperature = New System.Windows.Forms.Label()
        Me.lblRatingCapacityValue = New System.Windows.Forms.Label()
        Me.lblRatingCapacity = New System.Windows.Forms.Label()
        Me.lblRatingCondensingUnitModelValue = New System.Windows.Forms.Label()
        Me.lblRatingCondensingUnitModel = New System.Windows.Forms.Label()
        Me.tabResults = New System.Windows.Forms.TabPage()
        Me.Grid1 = New Rae.RaeSolutions.Grid()
        Me.lblDemandCoolingNote = New System.Windows.Forms.Label()
        Me.lblResultsOmit = New System.Windows.Forms.Label()
        Me.lblResultsNumberOfFansValue = New System.Windows.Forms.Label()
        Me.lblResultsNumberOfFans = New System.Windows.Forms.Label()
        Me.lblResultsNumberOfCompressorsValue = New System.Windows.Forms.Label()
        Me.lblResultsNumberOfCompressors = New System.Windows.Forms.Label()
        Me.lblResultsCondenserCapacityValue = New System.Windows.Forms.Label()
        Me.lblResultsCondenserCapacity = New System.Windows.Forms.Label()
        Me.panCreateReport = New System.Windows.Forms.Panel()
        Me.btnCreateReport = New System.Windows.Forms.Button()
        Me.btnNewEquipmentPricing = New System.Windows.Forms.Button()
        Me.btnReturn = New System.Windows.Forms.Button()
        Me.lblResultsAltitudeValue = New System.Windows.Forms.Label()
        Me.lblResultsAltitude = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenCondensingUnitRatingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveCondToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RevisionCondensingUnitRatingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsNewMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ConvertToEquipmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFilePrintCondensingUnits = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.timerHighlightReturn = New System.Windows.Forms.Timer(Me.components)
        Me.SaveToolStripPanel1 = New Rae.RaeSolutions.SaveToolStripPanel()
        Me.panRunTimeAdjust.SuspendLayout()
        Me.panRun.SuspendLayout()
        Me.panInputsBody.SuspendLayout()
        Me.grpRunTime.SuspendLayout()
        Me.grpBoxLoad.SuspendLayout()
        Me.compressorIsUsing10CoefficientsPanel.SuspendLayout()
        Me.panOutputsBody.SuspendLayout()
        Me.panCondensingUnit.SuspendLayout()
        Me.panMain.SuspendLayout()
        Me.panRatingBodyTSI.SuspendLayout()
        Me.panRatingBody.SuspendLayout()
        Me.panSelectCondensingUnit.SuspendLayout()
        Me.tabCondensingUnit.SuspendLayout()
        Me.tabSelection.SuspendLayout()
        Me.tabRating.SuspendLayout()
        Me.panRatingMain.SuspendLayout()
        Me.panRateUnit.SuspendLayout()
        Me.panRatingCircuitBody.SuspendLayout()
        Me.tabCircuits.SuspendLayout()
        Me.tabCircuit1.SuspendLayout()
        Me.panCircuit1.SuspendLayout()
        Me.gboFan1.SuspendLayout()
        Me.gboCompressor1.SuspendLayout()
        Me.gboCoil1.SuspendLayout()
        Me.tabCircuit2.SuspendLayout()
        Me.panCircuit2.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.gboFan2.SuspendLayout()
        Me.gboCompressor2.SuspendLayout()
        Me.tabCircuit3.SuspendLayout()
        Me.panCircuit3.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabCircuit4.SuspendLayout()
        Me.panCircuit4.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.panRatingHideFromRep.SuspendLayout()
        Me.panRatingDataBody.SuspendLayout()
        Me.tabResults.SuspendLayout()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panCreateReport.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCondensingUnitSeries
        '
        Me.lblCondensingUnitSeries.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCondensingUnitSeries.Location = New System.Drawing.Point(0, 8)
        Me.lblCondensingUnitSeries.Name = "lblCondensingUnitSeries"
        Me.lblCondensingUnitSeries.Size = New System.Drawing.Size(152, 23)
        Me.lblCondensingUnitSeries.TabIndex = 0
        Me.lblCondensingUnitSeries.Text = "Condensing unit series"
        Me.lblCondensingUnitSeries.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCapacityRequired
        '
        Me.lblCapacityRequired.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapacityRequired.Location = New System.Drawing.Point(0, 36)
        Me.lblCapacityRequired.Name = "lblCapacityRequired"
        Me.lblCapacityRequired.Size = New System.Drawing.Size(152, 23)
        Me.lblCapacityRequired.TabIndex = 1
        Me.lblCapacityRequired.Text = "Total capacity required"
        Me.lblCapacityRequired.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCondensingUnitSeries
        '
        Me.cboCondensingUnitSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCondensingUnitSeries.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCondensingUnitSeries.ItemHeight = 13
        Me.cboCondensingUnitSeries.Location = New System.Drawing.Point(160, 8)
        Me.cboCondensingUnitSeries.MaxDropDownItems = 9
        Me.cboCondensingUnitSeries.Name = "cboCondensingUnitSeries"
        Me.cboCondensingUnitSeries.Size = New System.Drawing.Size(72, 21)
        Me.cboCondensingUnitSeries.TabIndex = 3
        Me.cboCondensingUnitSeries.Tag = "Condensing Unit Series"
        '
        'txtCapacity
        '
        Me.txtCapacity.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCapacity.Location = New System.Drawing.Point(160, 36)
        Me.txtCapacity.Name = "txtCapacity"
        Me.txtCapacity.Size = New System.Drawing.Size(72, 21)
        Me.txtCapacity.TabIndex = 4
        Me.txtCapacity.Tag = "Total Est. Capacity Required"
        Me.txtCapacity.Text = "0"
        '
        'txtRunTime
        '
        Me.txtRunTime.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRunTime.Location = New System.Drawing.Point(6, 20)
        Me.txtRunTime.Name = "txtRunTime"
        Me.txtRunTime.Size = New System.Drawing.Size(40, 21)
        Me.txtRunTime.TabIndex = 5
        Me.txtRunTime.Tag = "Run Time"
        Me.txtRunTime.Text = "16"
        '
        'lblRunTimeAdjust
        '
        Me.lblRunTimeAdjust.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRunTimeAdjust.Location = New System.Drawing.Point(0, 64)
        Me.lblRunTimeAdjust.Name = "lblRunTimeAdjust"
        Me.lblRunTimeAdjust.Size = New System.Drawing.Size(152, 23)
        Me.lblRunTimeAdjust.TabIndex = 6
        Me.lblRunTimeAdjust.Text = "Adjust capacity for run time"
        Me.lblRunTimeAdjust.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'radRunTimeAdjustYes
        '
        Me.radRunTimeAdjustYes.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.radRunTimeAdjustYes.Location = New System.Drawing.Point(8, 8)
        Me.radRunTimeAdjustYes.Name = "radRunTimeAdjustYes"
        Me.radRunTimeAdjustYes.Size = New System.Drawing.Size(56, 24)
        Me.radRunTimeAdjustYes.TabIndex = 7
        Me.radRunTimeAdjustYes.Text = "Yes"
        '
        'panRunTimeAdjust
        '
        Me.panRunTimeAdjust.Controls.Add(Me.radRunTimeAdjustYes)
        Me.panRunTimeAdjust.Controls.Add(Me.radRunTimeAdjustNo)
        Me.panRunTimeAdjust.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panRunTimeAdjust.Location = New System.Drawing.Point(154, 56)
        Me.panRunTimeAdjust.Name = "panRunTimeAdjust"
        Me.panRunTimeAdjust.Size = New System.Drawing.Size(122, 40)
        Me.panRunTimeAdjust.TabIndex = 8
        '
        'radRunTimeAdjustNo
        '
        Me.radRunTimeAdjustNo.Checked = True
        Me.radRunTimeAdjustNo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.radRunTimeAdjustNo.Location = New System.Drawing.Point(64, 8)
        Me.radRunTimeAdjustNo.Name = "radRunTimeAdjustNo"
        Me.radRunTimeAdjustNo.Size = New System.Drawing.Size(56, 24)
        Me.radRunTimeAdjustNo.TabIndex = 9
        Me.radRunTimeAdjustNo.TabStop = True
        Me.radRunTimeAdjustNo.Text = "No"
        '
        'lblAmbientTemperature
        '
        Me.lblAmbientTemperature.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmbientTemperature.Location = New System.Drawing.Point(0, 92)
        Me.lblAmbientTemperature.Name = "lblAmbientTemperature"
        Me.lblAmbientTemperature.Size = New System.Drawing.Size(152, 23)
        Me.lblAmbientTemperature.TabIndex = 9
        Me.lblAmbientTemperature.Text = "Design ambient temp."
        Me.lblAmbientTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSelectionTabAmbient
        '
        Me.txtSelectionTabAmbient.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSelectionTabAmbient.Location = New System.Drawing.Point(160, 92)
        Me.txtSelectionTabAmbient.Name = "txtSelectionTabAmbient"
        Me.txtSelectionTabAmbient.Size = New System.Drawing.Size(72, 21)
        Me.txtSelectionTabAmbient.TabIndex = 10
        Me.txtSelectionTabAmbient.Tag = "Ambient Temperature"
        Me.txtSelectionTabAmbient.Text = "95"
        '
        'lblSuctionTemperature
        '
        Me.lblSuctionTemperature.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuctionTemperature.Location = New System.Drawing.Point(0, 120)
        Me.lblSuctionTemperature.Name = "lblSuctionTemperature"
        Me.lblSuctionTemperature.Size = New System.Drawing.Size(152, 23)
        Me.lblSuctionTemperature.TabIndex = 11
        Me.lblSuctionTemperature.Text = "Saturated suction temp."
        Me.lblSuctionTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSelectionTabSuction
        '
        Me.txtSelectionTabSuction.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSelectionTabSuction.Location = New System.Drawing.Point(160, 120)
        Me.txtSelectionTabSuction.Name = "txtSelectionTabSuction"
        Me.txtSelectionTabSuction.Size = New System.Drawing.Size(72, 21)
        Me.txtSelectionTabSuction.TabIndex = 12
        Me.txtSelectionTabSuction.Tag = "Saturated Suction Temperature"
        Me.txtSelectionTabSuction.Text = "40"
        '
        'refrigerantLabel
        '
        Me.refrigerantLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.refrigerantLabel.Location = New System.Drawing.Point(0, 148)
        Me.refrigerantLabel.Name = "refrigerantLabel"
        Me.refrigerantLabel.Size = New System.Drawing.Size(152, 23)
        Me.refrigerantLabel.TabIndex = 13
        Me.refrigerantLabel.Text = "Refrigerant"
        Me.refrigerantLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboSelectionTabRefrigerant
        '
        Me.cboSelectionTabRefrigerant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSelectionTabRefrigerant.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSelectionTabRefrigerant.Location = New System.Drawing.Point(160, 148)
        Me.cboSelectionTabRefrigerant.MaxDropDownItems = 9
        Me.cboSelectionTabRefrigerant.Name = "cboSelectionTabRefrigerant"
        Me.cboSelectionTabRefrigerant.Size = New System.Drawing.Size(72, 21)
        Me.cboSelectionTabRefrigerant.TabIndex = 14
        Me.cboSelectionTabRefrigerant.Tag = "Refrigerant Type"
        '
        'lblCompressor
        '
        Me.lblCompressor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompressor.Location = New System.Drawing.Point(16, 176)
        Me.lblCompressor.Name = "lblCompressor"
        Me.lblCompressor.Size = New System.Drawing.Size(136, 23)
        Me.lblCompressor.TabIndex = 15
        Me.lblCompressor.Text = "Compressor"
        Me.lblCompressor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCompressor
        '
        Me.cboCompressor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompressor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCompressor.Items.AddRange(New Object() {"Best-optimized", "Scroll", "Semi-Hermetic Discus", "Semi-Hermetic Reed"})
        Me.cboCompressor.Location = New System.Drawing.Point(160, 176)
        Me.cboCompressor.Name = "cboCompressor"
        Me.cboCompressor.Size = New System.Drawing.Size(128, 21)
        Me.cboCompressor.TabIndex = 16
        Me.cboCompressor.Tag = "Compressor Type"
        '
        'lblCompressorPerUnit
        '
        Me.lblCompressorPerUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompressorPerUnit.Location = New System.Drawing.Point(308, 176)
        Me.lblCompressorPerUnit.Name = "lblCompressorPerUnit"
        Me.lblCompressorPerUnit.Size = New System.Drawing.Size(152, 23)
        Me.lblCompressorPerUnit.TabIndex = 18
        Me.lblCompressorPerUnit.Text = "Compressors per unit (total)"
        Me.lblCompressorPerUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCircuitsPerUnit
        '
        Me.lblCircuitsPerUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCircuitsPerUnit.Location = New System.Drawing.Point(16, 204)
        Me.lblCircuitsPerUnit.Name = "lblCircuitsPerUnit"
        Me.lblCircuitsPerUnit.Size = New System.Drawing.Size(136, 23)
        Me.lblCircuitsPerUnit.TabIndex = 19
        Me.lblCircuitsPerUnit.Text = "Circuits per unit (total)"
        Me.lblCircuitsPerUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAltitude
        '
        Me.lblAltitude.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAltitude.Location = New System.Drawing.Point(0, 232)
        Me.lblAltitude.Name = "lblAltitude"
        Me.lblAltitude.Size = New System.Drawing.Size(152, 23)
        Me.lblAltitude.TabIndex = 20
        Me.lblAltitude.Text = "Altitude"
        Me.lblAltitude.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSelectionTabAltitude
        '
        Me.txtSelectionTabAltitude.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSelectionTabAltitude.Location = New System.Drawing.Point(160, 232)
        Me.txtSelectionTabAltitude.Name = "txtSelectionTabAltitude"
        Me.txtSelectionTabAltitude.Size = New System.Drawing.Size(72, 21)
        Me.txtSelectionTabAltitude.TabIndex = 21
        Me.txtSelectionTabAltitude.Tag = "Altitude"
        Me.txtSelectionTabAltitude.Text = "0"
        '
        'cboCompressorPerUnit
        '
        Me.cboCompressorPerUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompressorPerUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCompressorPerUnit.Items.AddRange(New Object() {"ALL", "1", "2", "3", "4"})
        Me.cboCompressorPerUnit.Location = New System.Drawing.Point(468, 176)
        Me.cboCompressorPerUnit.Name = "cboCompressorPerUnit"
        Me.cboCompressorPerUnit.Size = New System.Drawing.Size(72, 21)
        Me.cboCompressorPerUnit.TabIndex = 22
        Me.cboCompressorPerUnit.Tag = "Compressor Per Unit"
        '
        'cboCircuitsPerUnit
        '
        Me.cboCircuitsPerUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCircuitsPerUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCircuitsPerUnit.Items.AddRange(New Object() {"ALL", "1", "2", "3", "4"})
        Me.cboCircuitsPerUnit.Location = New System.Drawing.Point(160, 204)
        Me.cboCircuitsPerUnit.Name = "cboCircuitsPerUnit"
        Me.cboCircuitsPerUnit.Size = New System.Drawing.Size(72, 21)
        Me.cboCircuitsPerUnit.TabIndex = 23
        Me.cboCircuitsPerUnit.Tag = "Circuits Per Unit"
        '
        'lblCondensingUnitsRequired
        '
        Me.lblCondensingUnitsRequired.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCondensingUnitsRequired.Location = New System.Drawing.Point(407, 8)
        Me.lblCondensingUnitsRequired.Name = "lblCondensingUnitsRequired"
        Me.lblCondensingUnitsRequired.Size = New System.Drawing.Size(96, 23)
        Me.lblCondensingUnitsRequired.TabIndex = 24
        Me.lblCondensingUnitsRequired.Text = "Units required"
        Me.lblCondensingUnitsRequired.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCondensingUnitsRequired
        '
        Me.txtCondensingUnitsRequired.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCondensingUnitsRequired.Location = New System.Drawing.Point(511, 8)
        Me.txtCondensingUnitsRequired.Name = "txtCondensingUnitsRequired"
        Me.txtCondensingUnitsRequired.Size = New System.Drawing.Size(33, 21)
        Me.txtCondensingUnitsRequired.TabIndex = 25
        Me.txtCondensingUnitsRequired.Tag = "Units Required"
        Me.txtCondensingUnitsRequired.Text = "1"
        '
        'btnRun
        '
        Me.btnRun.BackColor = System.Drawing.Color.White
        Me.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRun.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRun.ForeColor = System.Drawing.Color.Navy
        Me.btnRun.Location = New System.Drawing.Point(16, 260)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(120, 32)
        Me.btnRun.TabIndex = 26
        Me.btnRun.Text = "Step 1 - Run"
        Me.btnRun.UseVisualStyleBackColor = False
        '
        'panRun
        '
        Me.panRun.BackColor = System.Drawing.Color.White
        Me.panRun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panRun.Controls.Add(Me.radUnitRating)
        Me.panRun.Controls.Add(Me.rbo_unit_selection)
        Me.panRun.ForeColor = System.Drawing.Color.Navy
        Me.panRun.Location = New System.Drawing.Point(144, 260)
        Me.panRun.Name = "panRun"
        Me.panRun.Size = New System.Drawing.Size(217, 32)
        Me.panRun.TabIndex = 27
        '
        'radUnitRating
        '
        Me.radUnitRating.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.radUnitRating.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radUnitRating.ForeColor = System.Drawing.Color.Navy
        Me.radUnitRating.Location = New System.Drawing.Point(120, 4)
        Me.radUnitRating.Name = "radUnitRating"
        Me.radUnitRating.Size = New System.Drawing.Size(96, 24)
        Me.radUnitRating.TabIndex = 1
        Me.radUnitRating.Text = "Unit Rating"
        '
        'rbo_unit_selection
        '
        Me.rbo_unit_selection.BackColor = System.Drawing.Color.White
        Me.rbo_unit_selection.Checked = True
        Me.rbo_unit_selection.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbo_unit_selection.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbo_unit_selection.ForeColor = System.Drawing.Color.Navy
        Me.rbo_unit_selection.Location = New System.Drawing.Point(9, 4)
        Me.rbo_unit_selection.Name = "rbo_unit_selection"
        Me.rbo_unit_selection.Size = New System.Drawing.Size(104, 24)
        Me.rbo_unit_selection.TabIndex = 0
        Me.rbo_unit_selection.TabStop = True
        Me.rbo_unit_selection.Text = "Unit Selection"
        Me.rbo_unit_selection.UseVisualStyleBackColor = False
        '
        'panInputsBody
        '
        Me.panInputsBody.Controls.Add(Me.ddlDOEModels)
        Me.panInputsBody.Controls.Add(Me.Label38)
        Me.panInputsBody.Controls.Add(Me.grpRunTime)
        Me.panInputsBody.Controls.Add(Me.grpBoxLoad)
        Me.panInputsBody.Controls.Add(Me.txtCoolStuffID)
        Me.panInputsBody.Controls.Add(Me.voltageComboBox)
        Me.panInputsBody.Controls.Add(Me.voltageLabel)
        Me.panInputsBody.Controls.Add(Me.notesTextBox)
        Me.panInputsBody.Controls.Add(Me.notesLabel)
        Me.panInputsBody.Controls.Add(Me.lblFeet)
        Me.panInputsBody.Controls.Add(Me.lblSelectionTabCapacityUnits)
        Me.panInputsBody.Controls.Add(Me.lblSuctionTemperatureRange)
        Me.panInputsBody.Controls.Add(Me.lblAmbientTemperatureRange)
        Me.panInputsBody.Controls.Add(Me.txtCondensingUnitsRequired)
        Me.panInputsBody.Controls.Add(Me.lblCondensingUnitsRequired)
        Me.panInputsBody.Controls.Add(Me.cboCircuitsPerUnit)
        Me.panInputsBody.Controls.Add(Me.cboCompressorPerUnit)
        Me.panInputsBody.Controls.Add(Me.txtSelectionTabAltitude)
        Me.panInputsBody.Controls.Add(Me.lblAltitude)
        Me.panInputsBody.Controls.Add(Me.lblCircuitsPerUnit)
        Me.panInputsBody.Controls.Add(Me.lblCompressorPerUnit)
        Me.panInputsBody.Controls.Add(Me.cboCompressor)
        Me.panInputsBody.Controls.Add(Me.lblCompressor)
        Me.panInputsBody.Controls.Add(Me.cboSelectionTabRefrigerant)
        Me.panInputsBody.Controls.Add(Me.refrigerantLabel)
        Me.panInputsBody.Controls.Add(Me.txtSelectionTabSuction)
        Me.panInputsBody.Controls.Add(Me.lblSuctionTemperature)
        Me.panInputsBody.Controls.Add(Me.txtSelectionTabAmbient)
        Me.panInputsBody.Controls.Add(Me.lblAmbientTemperature)
        Me.panInputsBody.Controls.Add(Me.lblRunTimeAdjust)
        Me.panInputsBody.Controls.Add(Me.txtCapacity)
        Me.panInputsBody.Controls.Add(Me.cboCondensingUnitSeries)
        Me.panInputsBody.Controls.Add(Me.lblCapacityRequired)
        Me.panInputsBody.Controls.Add(Me.lblCondensingUnitSeries)
        Me.panInputsBody.Controls.Add(Me.panRun)
        Me.panInputsBody.Controls.Add(Me.btnRun)
        Me.panInputsBody.Controls.Add(Me.panRunTimeAdjust)
        Me.panInputsBody.Dock = System.Windows.Forms.DockStyle.Top
        Me.panInputsBody.Location = New System.Drawing.Point(0, 37)
        Me.panInputsBody.Name = "panInputsBody"
        Me.panInputsBody.Size = New System.Drawing.Size(940, 304)
        Me.panInputsBody.TabIndex = 33
        '
        'ddlDOEModels
        '
        Me.ddlDOEModels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlDOEModels.FormattingEnabled = True
        Me.ddlDOEModels.Items.AddRange(New Object() {"Yes", "No"})
        Me.ddlDOEModels.Location = New System.Drawing.Point(354, 8)
        Me.ddlDOEModels.Name = "ddlDOEModels"
        Me.ddlDOEModels.Size = New System.Drawing.Size(54, 21)
        Me.ddlDOEModels.TabIndex = 55
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(250, 13)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(94, 13)
        Me.Label38.TabIndex = 54
        Me.Label38.Text = "DOE Models Only?"
        '
        'grpRunTime
        '
        Me.grpRunTime.Controls.Add(Me.txtRunTime)
        Me.grpRunTime.Controls.Add(Me.lblRunTimeUnits)
        Me.grpRunTime.Location = New System.Drawing.Point(282, 46)
        Me.grpRunTime.Name = "grpRunTime"
        Me.grpRunTime.Size = New System.Drawing.Size(79, 49)
        Me.grpRunTime.TabIndex = 50
        Me.grpRunTime.TabStop = False
        Me.grpRunTime.Text = "Run Time"
        '
        'lblRunTimeUnits
        '
        Me.lblRunTimeUnits.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRunTimeUnits.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblRunTimeUnits.Location = New System.Drawing.Point(52, 20)
        Me.lblRunTimeUnits.Name = "lblRunTimeUnits"
        Me.lblRunTimeUnits.Size = New System.Drawing.Size(26, 23)
        Me.lblRunTimeUnits.TabIndex = 32
        Me.lblRunTimeUnits.Text = "Hr"
        Me.lblRunTimeUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpBoxLoad
        '
        Me.grpBoxLoad.Controls.Add(Me.btnRemoveBoxLoadLink)
        Me.grpBoxLoad.Controls.Add(Me.lblBoxLoadLinkedTo)
        Me.grpBoxLoad.Controls.Add(Me.btnCoolStuffInvoke)
        Me.grpBoxLoad.Controls.Add(Me.txtCoolStuffBLName)
        Me.grpBoxLoad.Location = New System.Drawing.Point(373, 39)
        Me.grpBoxLoad.Name = "grpBoxLoad"
        Me.grpBoxLoad.Size = New System.Drawing.Size(171, 93)
        Me.grpBoxLoad.TabIndex = 49
        Me.grpBoxLoad.TabStop = False
        Me.grpBoxLoad.Text = "Box Load "
        '
        'btnRemoveBoxLoadLink
        '
        Me.btnRemoveBoxLoadLink.Location = New System.Drawing.Point(33, 24)
        Me.btnRemoveBoxLoadLink.Name = "btnRemoveBoxLoadLink"
        Me.btnRemoveBoxLoadLink.Size = New System.Drawing.Size(107, 21)
        Me.btnRemoveBoxLoadLink.TabIndex = 47
        Me.btnRemoveBoxLoadLink.Text = "Remove  BL Link"
        Me.btnRemoveBoxLoadLink.UseVisualStyleBackColor = True
        Me.btnRemoveBoxLoadLink.Visible = False
        '
        'lblBoxLoadLinkedTo
        '
        Me.lblBoxLoadLinkedTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBoxLoadLinkedTo.Location = New System.Drawing.Point(10, 48)
        Me.lblBoxLoadLinkedTo.Name = "lblBoxLoadLinkedTo"
        Me.lblBoxLoadLinkedTo.Size = New System.Drawing.Size(57, 14)
        Me.lblBoxLoadLinkedTo.TabIndex = 48
        Me.lblBoxLoadLinkedTo.Text = "Linked To:"
        Me.lblBoxLoadLinkedTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCoolStuffInvoke
        '
        Me.btnCoolStuffInvoke.Location = New System.Drawing.Point(33, 17)
        Me.btnCoolStuffInvoke.Name = "btnCoolStuffInvoke"
        Me.btnCoolStuffInvoke.Size = New System.Drawing.Size(107, 21)
        Me.btnCoolStuffInvoke.TabIndex = 44
        Me.btnCoolStuffInvoke.Text = "Link to BoxLoad"
        Me.btnCoolStuffInvoke.UseVisualStyleBackColor = True
        '
        'txtCoolStuffBLName
        '
        Me.txtCoolStuffBLName.Enabled = False
        Me.txtCoolStuffBLName.Location = New System.Drawing.Point(6, 65)
        Me.txtCoolStuffBLName.Name = "txtCoolStuffBLName"
        Me.txtCoolStuffBLName.Size = New System.Drawing.Size(159, 21)
        Me.txtCoolStuffBLName.TabIndex = 46
        '
        'txtCoolStuffID
        '
        Me.txtCoolStuffID.Location = New System.Drawing.Point(540, 90)
        Me.txtCoolStuffID.Name = "txtCoolStuffID"
        Me.txtCoolStuffID.Size = New System.Drawing.Size(60, 21)
        Me.txtCoolStuffID.TabIndex = 45
        Me.txtCoolStuffID.Text = "0"
        Me.txtCoolStuffID.Visible = False
        '
        'voltageComboBox
        '
        Me.voltageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.voltageComboBox.FormattingEnabled = True
        Me.voltageComboBox.Location = New System.Drawing.Point(468, 148)
        Me.voltageComboBox.Name = "voltageComboBox"
        Me.voltageComboBox.Size = New System.Drawing.Size(72, 21)
        Me.voltageComboBox.TabIndex = 53
        '
        'voltageLabel
        '
        Me.voltageLabel.AutoSize = True
        Me.voltageLabel.Location = New System.Drawing.Point(416, 151)
        Me.voltageLabel.Name = "voltageLabel"
        Me.voltageLabel.Size = New System.Drawing.Size(43, 13)
        Me.voltageLabel.TabIndex = 52
        Me.voltageLabel.Text = "Voltage"
        '
        'notesTextBox
        '
        Me.notesTextBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.notesTextBox.Location = New System.Drawing.Point(373, 234)
        Me.notesTextBox.Multiline = True
        Me.notesTextBox.Name = "notesTextBox"
        Me.notesTextBox.Size = New System.Drawing.Size(199, 60)
        Me.notesTextBox.TabIndex = 42
        '
        'notesLabel
        '
        Me.notesLabel.BackColor = System.Drawing.Color.Transparent
        Me.notesLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.notesLabel.Location = New System.Drawing.Point(373, 217)
        Me.notesLabel.Name = "notesLabel"
        Me.notesLabel.Size = New System.Drawing.Size(81, 18)
        Me.notesLabel.TabIndex = 43
        Me.notesLabel.Text = "Notes"
        Me.notesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFeet
        '
        Me.lblFeet.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFeet.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblFeet.Location = New System.Drawing.Point(240, 232)
        Me.lblFeet.Name = "lblFeet"
        Me.lblFeet.Size = New System.Drawing.Size(112, 23)
        Me.lblFeet.TabIndex = 31
        Me.lblFeet.Text = "feet above sea level"
        Me.lblFeet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSelectionTabCapacityUnits
        '
        Me.lblSelectionTabCapacityUnits.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectionTabCapacityUnits.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblSelectionTabCapacityUnits.Location = New System.Drawing.Point(240, 36)
        Me.lblSelectionTabCapacityUnits.Name = "lblSelectionTabCapacityUnits"
        Me.lblSelectionTabCapacityUnits.Size = New System.Drawing.Size(48, 23)
        Me.lblSelectionTabCapacityUnits.TabIndex = 30
        Me.lblSelectionTabCapacityUnits.Text = "[BTUH]"
        Me.lblSelectionTabCapacityUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSuctionTemperatureRange
        '
        Me.lblSuctionTemperatureRange.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuctionTemperatureRange.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblSuctionTemperatureRange.Location = New System.Drawing.Point(240, 120)
        Me.lblSuctionTemperatureRange.Name = "lblSuctionTemperatureRange"
        Me.lblSuctionTemperatureRange.Size = New System.Drawing.Size(120, 23)
        Me.lblSuctionTemperatureRange.TabIndex = 29
        Me.lblSuctionTemperatureRange.Text = "Limits -40 to 55 ºF"
        Me.lblSuctionTemperatureRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAmbientTemperatureRange
        '
        Me.lblAmbientTemperatureRange.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmbientTemperatureRange.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblAmbientTemperatureRange.Location = New System.Drawing.Point(240, 92)
        Me.lblAmbientTemperatureRange.Name = "lblAmbientTemperatureRange"
        Me.lblAmbientTemperatureRange.Size = New System.Drawing.Size(120, 23)
        Me.lblAmbientTemperatureRange.TabIndex = 28
        Me.lblAmbientTemperatureRange.Text = "Limits 40 to 115 ºF"
        Me.lblAmbientTemperatureRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'compressorIsUsing10CoefficientsPanel
        '
        Me.compressorIsUsing10CoefficientsPanel.BackColor = System.Drawing.Color.Red
        Me.compressorIsUsing10CoefficientsPanel.Controls.Add(Me.numCompressorCoefficientsLabel)
        Me.compressorIsUsing10CoefficientsPanel.Controls.Add(Me.numCompressorCoefficientsComboBox)
        Me.compressorIsUsing10CoefficientsPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.compressorIsUsing10CoefficientsPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.compressorIsUsing10CoefficientsPanel.Location = New System.Drawing.Point(0, 0)
        Me.compressorIsUsing10CoefficientsPanel.Name = "compressorIsUsing10CoefficientsPanel"
        Me.compressorIsUsing10CoefficientsPanel.Size = New System.Drawing.Size(940, 37)
        Me.compressorIsUsing10CoefficientsPanel.TabIndex = 52
        Me.compressorIsUsing10CoefficientsPanel.Visible = False
        '
        'numCompressorCoefficientsLabel
        '
        Me.numCompressorCoefficientsLabel.AutoSize = True
        Me.numCompressorCoefficientsLabel.Location = New System.Drawing.Point(13, 11)
        Me.numCompressorCoefficientsLabel.Name = "numCompressorCoefficientsLabel"
        Me.numCompressorCoefficientsLabel.Size = New System.Drawing.Size(215, 16)
        Me.numCompressorCoefficientsLabel.TabIndex = 55
        Me.numCompressorCoefficientsLabel.Text = "Number of compressor coefficients"
        '
        'numCompressorCoefficientsComboBox
        '
        Me.numCompressorCoefficientsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.numCompressorCoefficientsComboBox.FormattingEnabled = True
        Me.numCompressorCoefficientsComboBox.Items.AddRange(New Object() {"5", "10"})
        Me.numCompressorCoefficientsComboBox.Location = New System.Drawing.Point(231, 6)
        Me.numCompressorCoefficientsComboBox.Name = "numCompressorCoefficientsComboBox"
        Me.numCompressorCoefficientsComboBox.Size = New System.Drawing.Size(86, 24)
        Me.numCompressorCoefficientsComboBox.TabIndex = 54
        '
        'panOutputsBody
        '
        Me.panOutputsBody.Controls.Add(Me.BestSelectionsGrid1)
        Me.panOutputsBody.Dock = System.Windows.Forms.DockStyle.Top
        Me.panOutputsBody.Location = New System.Drawing.Point(0, 341)
        Me.panOutputsBody.Name = "panOutputsBody"
        Me.panOutputsBody.Size = New System.Drawing.Size(940, 292)
        Me.panOutputsBody.TabIndex = 36
        Me.panOutputsBody.Visible = False
        '
        'BestSelectionsGrid1
        '
        Me.BestSelectionsGrid1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BestSelectionsGrid1.BackColor = System.Drawing.Color.White
        Me.BestSelectionsGrid1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BestSelectionsGrid1.Location = New System.Drawing.Point(21, 6)
        Me.BestSelectionsGrid1.Name = "BestSelectionsGrid1"
        Me.BestSelectionsGrid1.Size = New System.Drawing.Size(899, 280)
        Me.BestSelectionsGrid1.TabIndex = 34
        '
        'rbo_condensing_unit_1
        '
        Me.rbo_condensing_unit_1.Checked = True
        Me.rbo_condensing_unit_1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbo_condensing_unit_1.ForeColor = System.Drawing.Color.Navy
        Me.rbo_condensing_unit_1.Location = New System.Drawing.Point(8, 8)
        Me.rbo_condensing_unit_1.Name = "rbo_condensing_unit_1"
        Me.rbo_condensing_unit_1.Size = New System.Drawing.Size(416, 24)
        Me.rbo_condensing_unit_1.TabIndex = 34
        Me.rbo_condensing_unit_1.TabStop = True
        '
        'panCondensingUnit
        '
        Me.panCondensingUnit.Controls.Add(Me.rbo_condensing_unit_3)
        Me.panCondensingUnit.Controls.Add(Me.rbo_condensing_unit_2)
        Me.panCondensingUnit.Controls.Add(Me.rbo_condensing_unit_1)
        Me.panCondensingUnit.Location = New System.Drawing.Point(16, 6)
        Me.panCondensingUnit.Name = "panCondensingUnit"
        Me.panCondensingUnit.Size = New System.Drawing.Size(432, 80)
        Me.panCondensingUnit.TabIndex = 35
        '
        'rbo_condensing_unit_3
        '
        Me.rbo_condensing_unit_3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbo_condensing_unit_3.ForeColor = System.Drawing.Color.Navy
        Me.rbo_condensing_unit_3.Location = New System.Drawing.Point(8, 56)
        Me.rbo_condensing_unit_3.Name = "rbo_condensing_unit_3"
        Me.rbo_condensing_unit_3.Size = New System.Drawing.Size(416, 24)
        Me.rbo_condensing_unit_3.TabIndex = 36
        '
        'rbo_condensing_unit_2
        '
        Me.rbo_condensing_unit_2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbo_condensing_unit_2.ForeColor = System.Drawing.Color.Navy
        Me.rbo_condensing_unit_2.Location = New System.Drawing.Point(8, 32)
        Me.rbo_condensing_unit_2.Name = "rbo_condensing_unit_2"
        Me.rbo_condensing_unit_2.Size = New System.Drawing.Size(416, 24)
        Me.rbo_condensing_unit_2.TabIndex = 35
        '
        'btnRating
        '
        Me.btnRating.BackColor = System.Drawing.Color.White
        Me.btnRating.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRating.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRating.ForeColor = System.Drawing.Color.Navy
        Me.btnRating.Location = New System.Drawing.Point(16, 90)
        Me.btnRating.Name = "btnRating"
        Me.btnRating.Size = New System.Drawing.Size(216, 32)
        Me.btnRating.TabIndex = 36
        Me.btnRating.Text = "Step 2 - Go To Rating Tab"
        Me.btnRating.UseVisualStyleBackColor = False
        '
        'panMain
        '
        Me.panMain.AutoScroll = True
        Me.panMain.Controls.Add(Me.panRatingBodyTSI)
        Me.panMain.Controls.Add(Me.panRatingBody)
        Me.panMain.Controls.Add(Me.panSelectCondensingUnit)
        Me.panMain.Controls.Add(Me.panOutputsBody)
        Me.panMain.Controls.Add(Me.panInputsBody)
        Me.panMain.Controls.Add(Me.compressorIsUsing10CoefficientsPanel)
        Me.panMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panMain.Location = New System.Drawing.Point(0, 0)
        Me.panMain.Name = "panMain"
        Me.panMain.Size = New System.Drawing.Size(957, 610)
        Me.panMain.TabIndex = 37
        '
        'panRatingBodyTSI
        '
        Me.panRatingBodyTSI.BackColor = System.Drawing.SystemColors.Control
        Me.panRatingBodyTSI.Controls.Add(Me.lbl20A4)
        Me.panRatingBodyTSI.Controls.Add(Me.cbo20A4)
        Me.panRatingBodyTSI.Controls.Add(Me.btnRating3)
        Me.panRatingBodyTSI.Controls.Add(Me.Label11)
        Me.panRatingBodyTSI.Controls.Add(Me.lbl20a0)
        Me.panRatingBodyTSI.Controls.Add(Me.cbo20A0)
        Me.panRatingBodyTSI.Dock = System.Windows.Forms.DockStyle.Top
        Me.panRatingBodyTSI.Location = New System.Drawing.Point(0, 1041)
        Me.panRatingBodyTSI.Name = "panRatingBodyTSI"
        Me.panRatingBodyTSI.Size = New System.Drawing.Size(940, 126)
        Me.panRatingBodyTSI.TabIndex = 39
        Me.panRatingBodyTSI.Visible = False
        '
        'lbl20A4
        '
        Me.lbl20A4.Location = New System.Drawing.Point(60, 55)
        Me.lbl20A4.Name = "lbl20A4"
        Me.lbl20A4.Size = New System.Drawing.Size(100, 23)
        Me.lbl20A4.TabIndex = 19
        Me.lbl20A4.Text = "20A4"
        Me.lbl20A4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbo20A4
        '
        Me.cbo20A4.Items.AddRange(New Object() {"Choose"})
        Me.cbo20A4.Location = New System.Drawing.Point(172, 55)
        Me.cbo20A4.Name = "cbo20A4"
        Me.cbo20A4.Size = New System.Drawing.Size(121, 21)
        Me.cbo20A4.TabIndex = 18
        Me.cbo20A4.Text = "Choose"
        '
        'btnRating3
        '
        Me.btnRating3.BackColor = System.Drawing.Color.White
        Me.btnRating3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRating3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRating3.ForeColor = System.Drawing.Color.Navy
        Me.btnRating3.Location = New System.Drawing.Point(16, 85)
        Me.btnRating3.Name = "btnRating3"
        Me.btnRating3.Size = New System.Drawing.Size(216, 32)
        Me.btnRating3.TabIndex = 17
        Me.btnRating3.Text = "Step 2 - Go To Rating Tab"
        Me.btnRating3.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(172, 4)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(280, 20)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Choose one condensing unit model"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl20a0
        '
        Me.lbl20a0.Location = New System.Drawing.Point(60, 28)
        Me.lbl20a0.Name = "lbl20a0"
        Me.lbl20a0.Size = New System.Drawing.Size(100, 23)
        Me.lbl20a0.TabIndex = 15
        Me.lbl20a0.Text = "20A0"
        Me.lbl20a0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbo20A0
        '
        Me.cbo20A0.Items.AddRange(New Object() {"Choose"})
        Me.cbo20A0.Location = New System.Drawing.Point(172, 28)
        Me.cbo20A0.Name = "cbo20A0"
        Me.cbo20A0.Size = New System.Drawing.Size(121, 21)
        Me.cbo20A0.TabIndex = 14
        Me.cbo20A0.Text = "Choose"
        '
        'panRatingBody
        '
        Me.panRatingBody.Controls.Add(Me.lblBLU_B)
        Me.panRatingBody.Controls.Add(Me.cboBLU_B)
        Me.panRatingBody.Controls.Add(Me.lblNMC)
        Me.panRatingBody.Controls.Add(Me.cboNMC)
        Me.panRatingBody.Controls.Add(Me.lblNMB)
        Me.panRatingBody.Controls.Add(Me.cboNMB)
        Me.panRatingBody.Controls.Add(Me.lblNDC)
        Me.panRatingBody.Controls.Add(Me.cboNDC)
        Me.panRatingBody.Controls.Add(Me.lblNSC)
        Me.panRatingBody.Controls.Add(Me.lblNDB)
        Me.panRatingBody.Controls.Add(Me.lblNSB)
        Me.panRatingBody.Controls.Add(Me.lblBLU_L)
        Me.panRatingBody.Controls.Add(Me.cboNSC)
        Me.panRatingBody.Controls.Add(Me.cboNDB)
        Me.panRatingBody.Controls.Add(Me.cboNSB)
        Me.panRatingBody.Controls.Add(Me.cboBLU_L)
        Me.panRatingBody.Controls.Add(Me.btnRating2)
        Me.panRatingBody.Controls.Add(Me.Label1)
        Me.panRatingBody.Controls.Add(Me.lblDS)
        Me.panRatingBody.Controls.Add(Me.lblDM)
        Me.panRatingBody.Controls.Add(Me.lblDD)
        Me.panRatingBody.Controls.Add(Me.lblLUO)
        Me.panRatingBody.Controls.Add(Me.lblLUI)
        Me.panRatingBody.Controls.Add(Me.cboDS)
        Me.panRatingBody.Controls.Add(Me.cboDM)
        Me.panRatingBody.Controls.Add(Me.cboDD)
        Me.panRatingBody.Controls.Add(Me.cboLUO)
        Me.panRatingBody.Controls.Add(Me.cboLUI)
        Me.panRatingBody.Dock = System.Windows.Forms.DockStyle.Top
        Me.panRatingBody.Location = New System.Drawing.Point(0, 763)
        Me.panRatingBody.Name = "panRatingBody"
        Me.panRatingBody.Size = New System.Drawing.Size(940, 278)
        Me.panRatingBody.TabIndex = 37
        Me.panRatingBody.Visible = False
        '
        'lblBLU_B
        '
        Me.lblBLU_B.Location = New System.Drawing.Point(225, 167)
        Me.lblBLU_B.Name = "lblBLU_B"
        Me.lblBLU_B.Size = New System.Drawing.Size(80, 23)
        Me.lblBLU_B.TabIndex = 29
        Me.lblBLU_B.Text = "BLU-B"
        Me.lblBLU_B.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboBLU_B
        '
        Me.cboBLU_B.Items.AddRange(New Object() {"Choose"})
        Me.cboBLU_B.Location = New System.Drawing.Point(311, 167)
        Me.cboBLU_B.Name = "cboBLU_B"
        Me.cboBLU_B.Size = New System.Drawing.Size(121, 21)
        Me.cboBLU_B.TabIndex = 28
        Me.cboBLU_B.Text = "Choose"
        '
        'lblNMC
        '
        Me.lblNMC.Location = New System.Drawing.Point(442, 56)
        Me.lblNMC.Name = "lblNMC"
        Me.lblNMC.Size = New System.Drawing.Size(80, 23)
        Me.lblNMC.TabIndex = 27
        Me.lblNMC.Text = "NMC"
        Me.lblNMC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboNMC
        '
        Me.cboNMC.Items.AddRange(New Object() {"Choose"})
        Me.cboNMC.Location = New System.Drawing.Point(528, 54)
        Me.cboNMC.Name = "cboNMC"
        Me.cboNMC.Size = New System.Drawing.Size(121, 21)
        Me.cboNMC.TabIndex = 26
        Me.cboNMC.Text = "Choose"
        '
        'lblNMB
        '
        Me.lblNMB.Location = New System.Drawing.Point(442, 28)
        Me.lblNMB.Name = "lblNMB"
        Me.lblNMB.Size = New System.Drawing.Size(80, 23)
        Me.lblNMB.TabIndex = 25
        Me.lblNMB.Text = "NMB"
        Me.lblNMB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboNMB
        '
        Me.cboNMB.Items.AddRange(New Object() {"Choose"})
        Me.cboNMB.Location = New System.Drawing.Point(528, 26)
        Me.cboNMB.Name = "cboNMB"
        Me.cboNMB.Size = New System.Drawing.Size(121, 21)
        Me.cboNMB.TabIndex = 24
        Me.cboNMB.Text = "Choose"
        '
        'lblNDC
        '
        Me.lblNDC.Location = New System.Drawing.Point(225, 112)
        Me.lblNDC.Name = "lblNDC"
        Me.lblNDC.Size = New System.Drawing.Size(80, 23)
        Me.lblNDC.TabIndex = 23
        Me.lblNDC.Text = "NDC"
        Me.lblNDC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboNDC
        '
        Me.cboNDC.Items.AddRange(New Object() {"Choose"})
        Me.cboNDC.Location = New System.Drawing.Point(311, 110)
        Me.cboNDC.Name = "cboNDC"
        Me.cboNDC.Size = New System.Drawing.Size(121, 21)
        Me.cboNDC.TabIndex = 22
        Me.cboNDC.Text = "Choose"
        '
        'lblNSC
        '
        Me.lblNSC.Location = New System.Drawing.Point(225, 84)
        Me.lblNSC.Name = "lblNSC"
        Me.lblNSC.Size = New System.Drawing.Size(80, 23)
        Me.lblNSC.TabIndex = 21
        Me.lblNSC.Text = "NSC"
        Me.lblNSC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNDB
        '
        Me.lblNDB.Location = New System.Drawing.Point(225, 56)
        Me.lblNDB.Name = "lblNDB"
        Me.lblNDB.Size = New System.Drawing.Size(80, 23)
        Me.lblNDB.TabIndex = 20
        Me.lblNDB.Text = "NDB"
        Me.lblNDB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNSB
        '
        Me.lblNSB.Location = New System.Drawing.Point(225, 28)
        Me.lblNSB.Name = "lblNSB"
        Me.lblNSB.Size = New System.Drawing.Size(80, 23)
        Me.lblNSB.TabIndex = 19
        Me.lblNSB.Text = "NSB"
        Me.lblNSB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBLU_L
        '
        Me.lblBLU_L.Location = New System.Drawing.Point(225, 140)
        Me.lblBLU_L.Name = "lblBLU_L"
        Me.lblBLU_L.Size = New System.Drawing.Size(80, 23)
        Me.lblBLU_L.TabIndex = 19
        Me.lblBLU_L.Text = "BLU-L"
        Me.lblBLU_L.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboNSC
        '
        Me.cboNSC.Items.AddRange(New Object() {"Choose"})
        Me.cboNSC.Location = New System.Drawing.Point(311, 82)
        Me.cboNSC.Name = "cboNSC"
        Me.cboNSC.Size = New System.Drawing.Size(121, 21)
        Me.cboNSC.TabIndex = 18
        Me.cboNSC.Text = "Choose"
        '
        'cboNDB
        '
        Me.cboNDB.Items.AddRange(New Object() {"Choose"})
        Me.cboNDB.Location = New System.Drawing.Point(311, 54)
        Me.cboNDB.Name = "cboNDB"
        Me.cboNDB.Size = New System.Drawing.Size(121, 21)
        Me.cboNDB.TabIndex = 17
        Me.cboNDB.Text = "Choose"
        '
        'cboNSB
        '
        Me.cboNSB.Items.AddRange(New Object() {"Choose"})
        Me.cboNSB.Location = New System.Drawing.Point(311, 26)
        Me.cboNSB.Name = "cboNSB"
        Me.cboNSB.Size = New System.Drawing.Size(121, 21)
        Me.cboNSB.TabIndex = 16
        Me.cboNSB.Text = "Choose"
        '
        'cboBLU_L
        '
        Me.cboBLU_L.Items.AddRange(New Object() {"Choose"})
        Me.cboBLU_L.Location = New System.Drawing.Point(311, 140)
        Me.cboBLU_L.Name = "cboBLU_L"
        Me.cboBLU_L.Size = New System.Drawing.Size(121, 21)
        Me.cboBLU_L.TabIndex = 16
        Me.cboBLU_L.Text = "Choose"
        '
        'btnRating2
        '
        Me.btnRating2.BackColor = System.Drawing.Color.White
        Me.btnRating2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRating2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRating2.ForeColor = System.Drawing.Color.Navy
        Me.btnRating2.Location = New System.Drawing.Point(16, 240)
        Me.btnRating2.Name = "btnRating2"
        Me.btnRating2.Size = New System.Drawing.Size(216, 32)
        Me.btnRating2.TabIndex = 13
        Me.btnRating2.Text = "Step 2 - Go To Rating Tab"
        Me.btnRating2.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(128, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(280, 20)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Choose one condensing unit model"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDS
        '
        Me.lblDS.Location = New System.Drawing.Point(4, 140)
        Me.lblDS.Name = "lblDS"
        Me.lblDS.Size = New System.Drawing.Size(80, 23)
        Me.lblDS.TabIndex = 10
        Me.lblDS.Text = "DS"
        Me.lblDS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDM
        '
        Me.lblDM.Location = New System.Drawing.Point(4, 112)
        Me.lblDM.Name = "lblDM"
        Me.lblDM.Size = New System.Drawing.Size(80, 23)
        Me.lblDM.TabIndex = 9
        Me.lblDM.Text = "DM"
        Me.lblDM.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDD
        '
        Me.lblDD.Location = New System.Drawing.Point(4, 84)
        Me.lblDD.Name = "lblDD"
        Me.lblDD.Size = New System.Drawing.Size(80, 23)
        Me.lblDD.TabIndex = 8
        Me.lblDD.Text = "DD"
        Me.lblDD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLUO
        '
        Me.lblLUO.Location = New System.Drawing.Point(4, 56)
        Me.lblLUO.Name = "lblLUO"
        Me.lblLUO.Size = New System.Drawing.Size(80, 23)
        Me.lblLUO.TabIndex = 7
        Me.lblLUO.Text = "LUO"
        Me.lblLUO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLUI
        '
        Me.lblLUI.Location = New System.Drawing.Point(4, 28)
        Me.lblLUI.Name = "lblLUI"
        Me.lblLUI.Size = New System.Drawing.Size(80, 23)
        Me.lblLUI.TabIndex = 6
        Me.lblLUI.Text = "LUI"
        Me.lblLUI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboDS
        '
        Me.cboDS.Items.AddRange(New Object() {"Choose"})
        Me.cboDS.Location = New System.Drawing.Point(90, 140)
        Me.cboDS.Name = "cboDS"
        Me.cboDS.Size = New System.Drawing.Size(121, 21)
        Me.cboDS.TabIndex = 4
        Me.cboDS.Text = "Choose"
        '
        'cboDM
        '
        Me.cboDM.Items.AddRange(New Object() {"Choose"})
        Me.cboDM.Location = New System.Drawing.Point(90, 112)
        Me.cboDM.Name = "cboDM"
        Me.cboDM.Size = New System.Drawing.Size(121, 21)
        Me.cboDM.TabIndex = 3
        Me.cboDM.Text = "Choose"
        '
        'cboDD
        '
        Me.cboDD.Items.AddRange(New Object() {"Choose"})
        Me.cboDD.Location = New System.Drawing.Point(90, 84)
        Me.cboDD.Name = "cboDD"
        Me.cboDD.Size = New System.Drawing.Size(121, 21)
        Me.cboDD.TabIndex = 2
        Me.cboDD.Text = "Choose"
        '
        'cboLUO
        '
        Me.cboLUO.Items.AddRange(New Object() {"Choose"})
        Me.cboLUO.Location = New System.Drawing.Point(90, 56)
        Me.cboLUO.Name = "cboLUO"
        Me.cboLUO.Size = New System.Drawing.Size(121, 21)
        Me.cboLUO.TabIndex = 1
        Me.cboLUO.Text = "Choose"
        '
        'cboLUI
        '
        Me.cboLUI.Items.AddRange(New Object() {"Choose"})
        Me.cboLUI.Location = New System.Drawing.Point(90, 28)
        Me.cboLUI.Name = "cboLUI"
        Me.cboLUI.Size = New System.Drawing.Size(121, 21)
        Me.cboLUI.TabIndex = 0
        Me.cboLUI.Text = "Choose"
        '
        'panSelectCondensingUnit
        '
        Me.panSelectCondensingUnit.Controls.Add(Me.lblNoCondensingUnits)
        Me.panSelectCondensingUnit.Controls.Add(Me.panCondensingUnit)
        Me.panSelectCondensingUnit.Controls.Add(Me.btnRating)
        Me.panSelectCondensingUnit.Dock = System.Windows.Forms.DockStyle.Top
        Me.panSelectCondensingUnit.Location = New System.Drawing.Point(0, 633)
        Me.panSelectCondensingUnit.Name = "panSelectCondensingUnit"
        Me.panSelectCondensingUnit.Size = New System.Drawing.Size(940, 130)
        Me.panSelectCondensingUnit.TabIndex = 36
        Me.panSelectCondensingUnit.Visible = False
        '
        'lblNoCondensingUnits
        '
        Me.lblNoCondensingUnits.ForeColor = System.Drawing.Color.Red
        Me.lblNoCondensingUnits.Location = New System.Drawing.Point(56, 18)
        Me.lblNoCondensingUnits.Name = "lblNoCondensingUnits"
        Me.lblNoCondensingUnits.Size = New System.Drawing.Size(296, 23)
        Me.lblNoCondensingUnits.TabIndex = 37
        Me.lblNoCondensingUnits.Text = "No condensing units match the selection criteria"
        Me.lblNoCondensingUnits.Visible = False
        '
        'tabCondensingUnit
        '
        Me.tabCondensingUnit.Controls.Add(Me.tabSelection)
        Me.tabCondensingUnit.Controls.Add(Me.tabRating)
        Me.tabCondensingUnit.Controls.Add(Me.tabResults)
        Me.tabCondensingUnit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabCondensingUnit.Location = New System.Drawing.Point(0, 0)
        Me.tabCondensingUnit.Name = "tabCondensingUnit"
        Me.tabCondensingUnit.SelectedIndex = 0
        Me.tabCondensingUnit.Size = New System.Drawing.Size(965, 636)
        Me.tabCondensingUnit.TabIndex = 39
        '
        'tabSelection
        '
        Me.tabSelection.Controls.Add(Me.panMain)
        Me.tabSelection.Location = New System.Drawing.Point(4, 22)
        Me.tabSelection.Name = "tabSelection"
        Me.tabSelection.Size = New System.Drawing.Size(957, 610)
        Me.tabSelection.TabIndex = 0
        Me.tabSelection.Text = "Selection"
        '
        'tabRating
        '
        Me.tabRating.Controls.Add(Me.panRatingMain)
        Me.tabRating.Location = New System.Drawing.Point(4, 22)
        Me.tabRating.Name = "tabRating"
        Me.tabRating.Size = New System.Drawing.Size(957, 610)
        Me.tabRating.TabIndex = 1
        Me.tabRating.Text = "Rating"
        '
        'panRatingMain
        '
        Me.panRatingMain.AutoScroll = True
        Me.panRatingMain.Controls.Add(Me.panRateUnit)
        Me.panRatingMain.Controls.Add(Me.panRatingCircuitBody)
        Me.panRatingMain.Controls.Add(Me.panRatingHideFromRep)
        Me.panRatingMain.Controls.Add(Me.panRatingDataBody)
        Me.panRatingMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panRatingMain.Location = New System.Drawing.Point(0, 0)
        Me.panRatingMain.Name = "panRatingMain"
        Me.panRatingMain.Size = New System.Drawing.Size(957, 610)
        Me.panRatingMain.TabIndex = 4
        '
        'panRateUnit
        '
        Me.panRateUnit.Controls.Add(Me.btnRateUnit)
        Me.panRateUnit.Dock = System.Windows.Forms.DockStyle.Top
        Me.panRateUnit.Location = New System.Drawing.Point(0, 536)
        Me.panRateUnit.Name = "panRateUnit"
        Me.panRateUnit.Size = New System.Drawing.Size(957, 48)
        Me.panRateUnit.TabIndex = 6
        '
        'btnRateUnit
        '
        Me.btnRateUnit.BackColor = System.Drawing.Color.White
        Me.btnRateUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRateUnit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRateUnit.ForeColor = System.Drawing.Color.Navy
        Me.btnRateUnit.Location = New System.Drawing.Point(16, 8)
        Me.btnRateUnit.Name = "btnRateUnit"
        Me.btnRateUnit.Size = New System.Drawing.Size(208, 32)
        Me.btnRateUnit.TabIndex = 3
        Me.btnRateUnit.Text = "Step 3 - Go To Results Tab"
        Me.btnRateUnit.UseVisualStyleBackColor = False
        '
        'panRatingCircuitBody
        '
        Me.panRatingCircuitBody.Controls.Add(Me.tabCircuits)
        Me.panRatingCircuitBody.Dock = System.Windows.Forms.DockStyle.Top
        Me.panRatingCircuitBody.Location = New System.Drawing.Point(0, 288)
        Me.panRatingCircuitBody.Name = "panRatingCircuitBody"
        Me.panRatingCircuitBody.Size = New System.Drawing.Size(957, 248)
        Me.panRatingCircuitBody.TabIndex = 4
        '
        'tabCircuits
        '
        Me.tabCircuits.Controls.Add(Me.tabCircuit1)
        Me.tabCircuits.Controls.Add(Me.tabCircuit2)
        Me.tabCircuits.Controls.Add(Me.tabCircuit3)
        Me.tabCircuits.Controls.Add(Me.tabCircuit4)
        Me.tabCircuits.HotTrack = True
        Me.tabCircuits.Location = New System.Drawing.Point(16, 2)
        Me.tabCircuits.Name = "tabCircuits"
        Me.tabCircuits.SelectedIndex = 0
        Me.tabCircuits.Size = New System.Drawing.Size(786, 243)
        Me.tabCircuits.TabIndex = 2
        '
        'tabCircuit1
        '
        Me.tabCircuit1.Controls.Add(Me.panCircuit1)
        Me.tabCircuit1.Location = New System.Drawing.Point(4, 22)
        Me.tabCircuit1.Name = "tabCircuit1"
        Me.tabCircuit1.Size = New System.Drawing.Size(778, 217)
        Me.tabCircuit1.TabIndex = 0
        Me.tabCircuit1.Text = "Circuit 1"
        '
        'panCircuit1
        '
        Me.panCircuit1.Controls.Add(Me.gboFan1)
        Me.panCircuit1.Controls.Add(Me.gboCompressor1)
        Me.panCircuit1.Controls.Add(Me.gboCoil1)
        Me.panCircuit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panCircuit1.Location = New System.Drawing.Point(0, 0)
        Me.panCircuit1.Name = "panCircuit1"
        Me.panCircuit1.Size = New System.Drawing.Size(778, 217)
        Me.panCircuit1.TabIndex = 1
        '
        'gboFan1
        '
        Me.gboFan1.Controls.Add(Me.lblCustomPower1)
        Me.gboFan1.Controls.Add(Me.txtCustomPower1)
        Me.gboFan1.Controls.Add(Me.txtFanRPM1)
        Me.gboFan1.Controls.Add(Me.lblFanRPM1)
        Me.gboFan1.Controls.Add(Me.txtCustomCFM1)
        Me.gboFan1.Controls.Add(Me.lblCustomCFM1)
        Me.gboFan1.Controls.Add(Me.Label35)
        Me.gboFan1.Controls.Add(Me.lblFanQuantity1)
        Me.gboFan1.Controls.Add(Me.cbo_fan_quantity_1)
        Me.gboFan1.Controls.Add(Me.cboFan1)
        Me.gboFan1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboFan1.ForeColor = System.Drawing.Color.Navy
        Me.gboFan1.Location = New System.Drawing.Point(8, 172)
        Me.gboFan1.Name = "gboFan1"
        Me.gboFan1.Size = New System.Drawing.Size(767, 42)
        Me.gboFan1.TabIndex = 33
        Me.gboFan1.TabStop = False
        Me.gboFan1.Text = "Fan Info"
        '
        'lblCustomPower1
        '
        Me.lblCustomPower1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomPower1.ForeColor = System.Drawing.Color.Black
        Me.lblCustomPower1.Location = New System.Drawing.Point(542, 13)
        Me.lblCustomPower1.Name = "lblCustomPower1"
        Me.lblCustomPower1.Size = New System.Drawing.Size(37, 23)
        Me.lblCustomPower1.TabIndex = 25
        Me.lblCustomPower1.Text = "Pwr"
        Me.lblCustomPower1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCustomPower1.Visible = False
        '
        'txtCustomPower1
        '
        Me.txtCustomPower1.Location = New System.Drawing.Point(581, 15)
        Me.txtCustomPower1.Name = "txtCustomPower1"
        Me.txtCustomPower1.Size = New System.Drawing.Size(39, 21)
        Me.txtCustomPower1.TabIndex = 24
        Me.txtCustomPower1.Text = "0"
        Me.txtCustomPower1.Visible = False
        '
        'txtFanRPM1
        '
        Me.txtFanRPM1.Location = New System.Drawing.Point(409, 17)
        Me.txtFanRPM1.Name = "txtFanRPM1"
        Me.txtFanRPM1.Size = New System.Drawing.Size(43, 21)
        Me.txtFanRPM1.TabIndex = 23
        Me.txtFanRPM1.Visible = False
        '
        'lblFanRPM1
        '
        Me.lblFanRPM1.AutoSize = True
        Me.lblFanRPM1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFanRPM1.ForeColor = System.Drawing.Color.Black
        Me.lblFanRPM1.Location = New System.Drawing.Point(317, 20)
        Me.lblFanRPM1.Name = "lblFanRPM1"
        Me.lblFanRPM1.Size = New System.Drawing.Size(86, 13)
        Me.lblFanRPM1.TabIndex = 22
        Me.lblFanRPM1.Text = "RPM (XXXX Max)"
        Me.lblFanRPM1.Visible = False
        '
        'txtCustomCFM1
        '
        Me.txtCustomCFM1.Location = New System.Drawing.Point(490, 16)
        Me.txtCustomCFM1.Name = "txtCustomCFM1"
        Me.txtCustomCFM1.Size = New System.Drawing.Size(49, 21)
        Me.txtCustomCFM1.TabIndex = 21
        Me.txtCustomCFM1.Text = "0"
        Me.txtCustomCFM1.Visible = False
        '
        'lblCustomCFM1
        '
        Me.lblCustomCFM1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomCFM1.ForeColor = System.Drawing.Color.Black
        Me.lblCustomCFM1.Location = New System.Drawing.Point(449, 14)
        Me.lblCustomCFM1.Name = "lblCustomCFM1"
        Me.lblCustomCFM1.Size = New System.Drawing.Size(37, 23)
        Me.lblCustomCFM1.TabIndex = 20
        Me.lblCustomCFM1.Text = "CFM"
        Me.lblCustomCFM1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCustomCFM1.Visible = False
        '
        'Label35
        '
        Me.Label35.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.Black
        Me.Label35.Location = New System.Drawing.Point(-13, 17)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(39, 23)
        Me.Label35.TabIndex = 18
        Me.Label35.Text = "Fan"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFanQuantity1
        '
        Me.lblFanQuantity1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFanQuantity1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFanQuantity1.Location = New System.Drawing.Point(598, 14)
        Me.lblFanQuantity1.Name = "lblFanQuantity1"
        Me.lblFanQuantity1.Size = New System.Drawing.Size(68, 21)
        Me.lblFanQuantity1.TabIndex = 14
        Me.lblFanQuantity1.Text = "Quantity"
        Me.lblFanQuantity1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbo_fan_quantity_1
        '
        Me.cbo_fan_quantity_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_fan_quantity_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_fan_quantity_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbo_fan_quantity_1.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "20", "22", "24"})
        Me.cbo_fan_quantity_1.Location = New System.Drawing.Point(668, 15)
        Me.cbo_fan_quantity_1.Name = "cbo_fan_quantity_1"
        Me.cbo_fan_quantity_1.Size = New System.Drawing.Size(72, 21)
        Me.cbo_fan_quantity_1.TabIndex = 15
        '
        'cboFan1
        '
        Me.cboFan1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFan1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFan1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboFan1.Location = New System.Drawing.Point(32, 17)
        Me.cboFan1.MaxDropDownItems = 9
        Me.cboFan1.Name = "cboFan1"
        Me.cboFan1.Size = New System.Drawing.Size(276, 21)
        Me.cboFan1.TabIndex = 17
        '
        'gboCompressor1
        '
        Me.gboCompressor1.Controls.Add(Me.txtCapMult1)
        Me.gboCompressor1.Controls.Add(Me.lblCapMult1)
        Me.gboCompressor1.Controls.Add(Me.Label34)
        Me.gboCompressor1.Controls.Add(Me.lblCompressorQuantity1)
        Me.gboCompressor1.Controls.Add(Me.cbo_compressor_quantity_1)
        Me.gboCompressor1.Controls.Add(Me.cbo_compressor_1)
        Me.gboCompressor1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboCompressor1.ForeColor = System.Drawing.Color.Navy
        Me.gboCompressor1.Location = New System.Drawing.Point(8, 4)
        Me.gboCompressor1.Name = "gboCompressor1"
        Me.gboCompressor1.Size = New System.Drawing.Size(630, 42)
        Me.gboCompressor1.TabIndex = 32
        Me.gboCompressor1.TabStop = False
        Me.gboCompressor1.Text = "Compressor Info"
        '
        'txtCapMult1
        '
        Me.txtCapMult1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCapMult1.Location = New System.Drawing.Point(581, 15)
        Me.txtCapMult1.Name = "txtCapMult1"
        Me.txtCapMult1.Size = New System.Drawing.Size(43, 21)
        Me.txtCapMult1.TabIndex = 19
        Me.txtCapMult1.Text = "1"
        Me.txtCapMult1.Visible = False
        '
        'lblCapMult1
        '
        Me.lblCapMult1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapMult1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCapMult1.Location = New System.Drawing.Point(511, 15)
        Me.lblCapMult1.Name = "lblCapMult1"
        Me.lblCapMult1.Size = New System.Drawing.Size(64, 21)
        Me.lblCapMult1.TabIndex = 5
        Me.lblCapMult1.Text = "Cap. Mult."
        Me.lblCapMult1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCapMult1.Visible = False
        '
        'Label34
        '
        Me.Label34.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(8, 16)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(68, 23)
        Me.Label34.TabIndex = 4
        Me.Label34.Text = "Compressor"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCompressorQuantity1
        '
        Me.lblCompressorQuantity1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompressorQuantity1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCompressorQuantity1.Location = New System.Drawing.Point(359, 16)
        Me.lblCompressorQuantity1.Name = "lblCompressorQuantity1"
        Me.lblCompressorQuantity1.Size = New System.Drawing.Size(64, 21)
        Me.lblCompressorQuantity1.TabIndex = 0
        Me.lblCompressorQuantity1.Text = "Quantity"
        Me.lblCompressorQuantity1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbo_compressor_quantity_1
        '
        Me.cbo_compressor_quantity_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_compressor_quantity_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_compressor_quantity_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbo_compressor_quantity_1.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.cbo_compressor_quantity_1.Location = New System.Drawing.Point(431, 16)
        Me.cbo_compressor_quantity_1.Name = "cbo_compressor_quantity_1"
        Me.cbo_compressor_quantity_1.Size = New System.Drawing.Size(61, 21)
        Me.cbo_compressor_quantity_1.TabIndex = 1
        '
        'cbo_compressor_1
        '
        Me.cbo_compressor_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_compressor_1.Font = New System.Drawing.Font("Lucida Console", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_compressor_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbo_compressor_1.Location = New System.Drawing.Point(84, 16)
        Me.cbo_compressor_1.MaxDropDownItems = 22
        Me.cbo_compressor_1.Name = "cbo_compressor_1"
        Me.cbo_compressor_1.Size = New System.Drawing.Size(268, 20)
        Me.cbo_compressor_1.TabIndex = 3
        '
        'gboCoil1
        '
        Me.gboCoil1.Controls.Add(Me.Label18)
        Me.gboCoil1.Controls.Add(Me.Label2)
        Me.gboCoil1.Controls.Add(Me.coilComboBox_1)
        Me.gboCoil1.Controls.Add(Me.cbo_fpi_1)
        Me.gboCoil1.Controls.Add(Me.lblCoilFinHeight1)
        Me.gboCoil1.Controls.Add(Me.lblCoilFinWidth1)
        Me.gboCoil1.Controls.Add(Me.lblCoilsRequiredValue1)
        Me.gboCoil1.Controls.Add(Me.lblFinsPerInch1)
        Me.gboCoil1.Controls.Add(Me.txt_fin_length_1)
        Me.gboCoil1.Controls.Add(Me.txt_fin_height_1)
        Me.gboCoil1.Controls.Add(Me.txtCoilSubCoolingPercentage1)
        Me.gboCoil1.Controls.Add(Me.lblCoilSubCoolingPercentage1)
        Me.gboCoil1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboCoil1.ForeColor = System.Drawing.Color.Navy
        Me.gboCoil1.Location = New System.Drawing.Point(8, 52)
        Me.gboCoil1.Name = "gboCoil1"
        Me.gboCoil1.Size = New System.Drawing.Size(532, 114)
        Me.gboCoil1.TabIndex = 32
        Me.gboCoil1.TabStop = False
        Me.gboCoil1.Text = "Coil Info"
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(6, 17)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(59, 23)
        Me.Label18.TabIndex = 28
        Me.Label18.Text = "Qty Req."
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Location = New System.Drawing.Point(116, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 23)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Coil"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'coilComboBox_1
        '
        Me.coilComboBox_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.coilComboBox_1.Location = New System.Drawing.Point(179, 15)
        Me.coilComboBox_1.MaxDropDownItems = 12
        Me.coilComboBox_1.Name = "coilComboBox_1"
        Me.coilComboBox_1.Size = New System.Drawing.Size(335, 21)
        Me.coilComboBox_1.TabIndex = 25
        '
        'cbo_fpi_1
        '
        Me.cbo_fpi_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_fpi_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_fpi_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbo_fpi_1.Items.AddRange(New Object() {"8", "9", "10", "11", "12", "13", "14"})
        Me.cbo_fpi_1.Location = New System.Drawing.Point(275, 54)
        Me.cbo_fpi_1.Name = "cbo_fpi_1"
        Me.cbo_fpi_1.Size = New System.Drawing.Size(72, 21)
        Me.cbo_fpi_1.TabIndex = 6
        '
        'lblCoilFinHeight1
        '
        Me.lblCoilFinHeight1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCoilFinHeight1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCoilFinHeight1.Location = New System.Drawing.Point(12, 53)
        Me.lblCoilFinHeight1.Name = "lblCoilFinHeight1"
        Me.lblCoilFinHeight1.Size = New System.Drawing.Size(56, 21)
        Me.lblCoilFinHeight1.TabIndex = 10
        Me.lblCoilFinHeight1.Text = "Fin height"
        Me.lblCoilFinHeight1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCoilFinWidth1
        '
        Me.lblCoilFinWidth1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCoilFinWidth1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCoilFinWidth1.Location = New System.Drawing.Point(0, 79)
        Me.lblCoilFinWidth1.Name = "lblCoilFinWidth1"
        Me.lblCoilFinWidth1.Size = New System.Drawing.Size(68, 21)
        Me.lblCoilFinWidth1.TabIndex = 11
        Me.lblCoilFinWidth1.Text = "Fin length"
        Me.lblCoilFinWidth1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCoilsRequiredValue1
        '
        Me.lblCoilsRequiredValue1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCoilsRequiredValue1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCoilsRequiredValue1.Location = New System.Drawing.Point(64, 16)
        Me.lblCoilsRequiredValue1.Name = "lblCoilsRequiredValue1"
        Me.lblCoilsRequiredValue1.Size = New System.Drawing.Size(40, 23)
        Me.lblCoilsRequiredValue1.TabIndex = 4
        Me.lblCoilsRequiredValue1.Text = "0"
        Me.lblCoilsRequiredValue1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFinsPerInch1
        '
        Me.lblFinsPerInch1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinsPerInch1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFinsPerInch1.Location = New System.Drawing.Point(183, 54)
        Me.lblFinsPerInch1.Name = "lblFinsPerInch1"
        Me.lblFinsPerInch1.Size = New System.Drawing.Size(84, 21)
        Me.lblFinsPerInch1.TabIndex = 7
        Me.lblFinsPerInch1.Text = "Fins per inch"
        Me.lblFinsPerInch1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_fin_length_1
        '
        Me.txt_fin_length_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_fin_length_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_fin_length_1.Location = New System.Drawing.Point(76, 80)
        Me.txt_fin_length_1.Name = "txt_fin_length_1"
        Me.txt_fin_length_1.Size = New System.Drawing.Size(55, 21)
        Me.txt_fin_length_1.TabIndex = 13
        '
        'txt_fin_height_1
        '
        Me.txt_fin_height_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_fin_height_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_fin_height_1.Location = New System.Drawing.Point(76, 53)
        Me.txt_fin_height_1.Name = "txt_fin_height_1"
        Me.txt_fin_height_1.Size = New System.Drawing.Size(55, 21)
        Me.txt_fin_height_1.TabIndex = 12
        '
        'txtCoilSubCoolingPercentage1
        '
        Me.txtCoilSubCoolingPercentage1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoilSubCoolingPercentage1.Location = New System.Drawing.Point(473, 53)
        Me.txtCoilSubCoolingPercentage1.Name = "txtCoilSubCoolingPercentage1"
        Me.txtCoilSubCoolingPercentage1.Size = New System.Drawing.Size(43, 21)
        Me.txtCoilSubCoolingPercentage1.TabIndex = 18
        Me.txtCoilSubCoolingPercentage1.Text = "0"
        '
        'lblCoilSubCoolingPercentage1
        '
        Me.lblCoilSubCoolingPercentage1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCoilSubCoolingPercentage1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCoilSubCoolingPercentage1.Location = New System.Drawing.Point(380, 53)
        Me.lblCoilSubCoolingPercentage1.Name = "lblCoilSubCoolingPercentage1"
        Me.lblCoilSubCoolingPercentage1.Size = New System.Drawing.Size(84, 21)
        Me.lblCoilSubCoolingPercentage1.TabIndex = 19
        Me.lblCoilSubCoolingPercentage1.Text = "Sub cooling %"
        Me.lblCoilSubCoolingPercentage1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabCircuit2
        '
        Me.tabCircuit2.Controls.Add(Me.panCircuit2)
        Me.tabCircuit2.Location = New System.Drawing.Point(4, 22)
        Me.tabCircuit2.Name = "tabCircuit2"
        Me.tabCircuit2.Size = New System.Drawing.Size(778, 217)
        Me.tabCircuit2.TabIndex = 1
        Me.tabCircuit2.Text = "Circuit 2"
        '
        'panCircuit2
        '
        Me.panCircuit2.Controls.Add(Me.GroupBox7)
        Me.panCircuit2.Controls.Add(Me.gboFan2)
        Me.panCircuit2.Controls.Add(Me.gboCompressor2)
        Me.panCircuit2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panCircuit2.Location = New System.Drawing.Point(0, 0)
        Me.panCircuit2.Name = "panCircuit2"
        Me.panCircuit2.Size = New System.Drawing.Size(778, 217)
        Me.panCircuit2.TabIndex = 2
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label9)
        Me.GroupBox7.Controls.Add(Me.Label3)
        Me.GroupBox7.Controls.Add(Me.coilComboBox_2)
        Me.GroupBox7.Controls.Add(Me.cbo_fpi_2)
        Me.GroupBox7.Controls.Add(Me.Label4)
        Me.GroupBox7.Controls.Add(Me.Label7)
        Me.GroupBox7.Controls.Add(Me.Label8)
        Me.GroupBox7.Controls.Add(Me.lblCoilsRequiredValue2)
        Me.GroupBox7.Controls.Add(Me.Label12)
        Me.GroupBox7.Controls.Add(Me.txt_fin_length_2)
        Me.GroupBox7.Controls.Add(Me.txt_fin_height_2)
        Me.GroupBox7.Controls.Add(Me.txtCoilSubCoolingPercentage2)
        Me.GroupBox7.Controls.Add(Me.Label16)
        Me.GroupBox7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox7.Location = New System.Drawing.Point(8, 52)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(532, 114)
        Me.GroupBox7.TabIndex = 33
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Coil Info"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(6, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 23)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Qty Req."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label3.Location = New System.Drawing.Point(116, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 23)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Coil"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'coilComboBox_2
        '
        Me.coilComboBox_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.coilComboBox_2.Location = New System.Drawing.Point(179, 15)
        Me.coilComboBox_2.MaxDropDownItems = 12
        Me.coilComboBox_2.Name = "coilComboBox_2"
        Me.coilComboBox_2.Size = New System.Drawing.Size(335, 21)
        Me.coilComboBox_2.TabIndex = 25
        '
        'cbo_fpi_2
        '
        Me.cbo_fpi_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_fpi_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_fpi_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbo_fpi_2.Items.AddRange(New Object() {"8", "9", "10", "11", "12", "13", "14"})
        Me.cbo_fpi_2.Location = New System.Drawing.Point(275, 54)
        Me.cbo_fpi_2.Name = "cbo_fpi_2"
        Me.cbo_fpi_2.Size = New System.Drawing.Size(72, 21)
        Me.cbo_fpi_2.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label4.Location = New System.Drawing.Point(112, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 23)
        Me.Label4.TabIndex = 5
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label7.Location = New System.Drawing.Point(12, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 21)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Fin height"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label8.Location = New System.Drawing.Point(0, 79)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 21)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Fin length"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCoilsRequiredValue2
        '
        Me.lblCoilsRequiredValue2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCoilsRequiredValue2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCoilsRequiredValue2.Location = New System.Drawing.Point(68, 16)
        Me.lblCoilsRequiredValue2.Name = "lblCoilsRequiredValue2"
        Me.lblCoilsRequiredValue2.Size = New System.Drawing.Size(36, 23)
        Me.lblCoilsRequiredValue2.TabIndex = 4
        Me.lblCoilsRequiredValue2.Text = "0"
        Me.lblCoilsRequiredValue2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label12.Location = New System.Drawing.Point(183, 54)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 21)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Fins per inch"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_fin_length_2
        '
        Me.txt_fin_length_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_fin_length_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_fin_length_2.Location = New System.Drawing.Point(76, 80)
        Me.txt_fin_length_2.Name = "txt_fin_length_2"
        Me.txt_fin_length_2.Size = New System.Drawing.Size(55, 21)
        Me.txt_fin_length_2.TabIndex = 13
        '
        'txt_fin_height_2
        '
        Me.txt_fin_height_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_fin_height_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_fin_height_2.Location = New System.Drawing.Point(76, 53)
        Me.txt_fin_height_2.Name = "txt_fin_height_2"
        Me.txt_fin_height_2.Size = New System.Drawing.Size(55, 21)
        Me.txt_fin_height_2.TabIndex = 12
        '
        'txtCoilSubCoolingPercentage2
        '
        Me.txtCoilSubCoolingPercentage2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoilSubCoolingPercentage2.Location = New System.Drawing.Point(473, 53)
        Me.txtCoilSubCoolingPercentage2.Name = "txtCoilSubCoolingPercentage2"
        Me.txtCoilSubCoolingPercentage2.Size = New System.Drawing.Size(43, 21)
        Me.txtCoilSubCoolingPercentage2.TabIndex = 18
        Me.txtCoilSubCoolingPercentage2.Text = "0"
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(380, 53)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(84, 21)
        Me.Label16.TabIndex = 19
        Me.Label16.Text = "Sub cooling %"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gboFan2
        '
        Me.gboFan2.Controls.Add(Me.lblCustomPower2)
        Me.gboFan2.Controls.Add(Me.txtCustomPower2)
        Me.gboFan2.Controls.Add(Me.txtFanRPM2)
        Me.gboFan2.Controls.Add(Me.lblFanRPM2)
        Me.gboFan2.Controls.Add(Me.txtCustomCFM2)
        Me.gboFan2.Controls.Add(Me.lblCustomCFM2)
        Me.gboFan2.Controls.Add(Me.Label37)
        Me.gboFan2.Controls.Add(Me.cbo_fan_quantity_2)
        Me.gboFan2.Controls.Add(Me.cboFan2)
        Me.gboFan2.Controls.Add(Me.Label5)
        Me.gboFan2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboFan2.ForeColor = System.Drawing.Color.Navy
        Me.gboFan2.Location = New System.Drawing.Point(8, 172)
        Me.gboFan2.Name = "gboFan2"
        Me.gboFan2.Size = New System.Drawing.Size(767, 42)
        Me.gboFan2.TabIndex = 32
        Me.gboFan2.TabStop = False
        Me.gboFan2.Text = "Fan Info"
        '
        'lblCustomPower2
        '
        Me.lblCustomPower2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomPower2.ForeColor = System.Drawing.Color.Black
        Me.lblCustomPower2.Location = New System.Drawing.Point(542, 13)
        Me.lblCustomPower2.Name = "lblCustomPower2"
        Me.lblCustomPower2.Size = New System.Drawing.Size(37, 23)
        Me.lblCustomPower2.TabIndex = 34
        Me.lblCustomPower2.Text = "Pwr"
        Me.lblCustomPower2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCustomPower2.Visible = False
        '
        'txtCustomPower2
        '
        Me.txtCustomPower2.Location = New System.Drawing.Point(581, 15)
        Me.txtCustomPower2.Name = "txtCustomPower2"
        Me.txtCustomPower2.Size = New System.Drawing.Size(39, 21)
        Me.txtCustomPower2.TabIndex = 33
        Me.txtCustomPower2.Text = "0"
        Me.txtCustomPower2.Visible = False
        '
        'txtFanRPM2
        '
        Me.txtFanRPM2.Location = New System.Drawing.Point(409, 17)
        Me.txtFanRPM2.Name = "txtFanRPM2"
        Me.txtFanRPM2.Size = New System.Drawing.Size(43, 21)
        Me.txtFanRPM2.TabIndex = 32
        Me.txtFanRPM2.Visible = False
        '
        'lblFanRPM2
        '
        Me.lblFanRPM2.AutoSize = True
        Me.lblFanRPM2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFanRPM2.ForeColor = System.Drawing.Color.Black
        Me.lblFanRPM2.Location = New System.Drawing.Point(364, 20)
        Me.lblFanRPM2.Name = "lblFanRPM2"
        Me.lblFanRPM2.Size = New System.Drawing.Size(28, 13)
        Me.lblFanRPM2.TabIndex = 31
        Me.lblFanRPM2.Text = "RPM"
        Me.lblFanRPM2.Visible = False
        '
        'txtCustomCFM2
        '
        Me.txtCustomCFM2.Location = New System.Drawing.Point(490, 16)
        Me.txtCustomCFM2.Name = "txtCustomCFM2"
        Me.txtCustomCFM2.Size = New System.Drawing.Size(49, 21)
        Me.txtCustomCFM2.TabIndex = 30
        Me.txtCustomCFM2.Text = "0"
        Me.txtCustomCFM2.Visible = False
        '
        'lblCustomCFM2
        '
        Me.lblCustomCFM2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomCFM2.ForeColor = System.Drawing.Color.Black
        Me.lblCustomCFM2.Location = New System.Drawing.Point(449, 14)
        Me.lblCustomCFM2.Name = "lblCustomCFM2"
        Me.lblCustomCFM2.Size = New System.Drawing.Size(37, 23)
        Me.lblCustomCFM2.TabIndex = 29
        Me.lblCustomCFM2.Text = "CFM"
        Me.lblCustomCFM2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCustomCFM2.Visible = False
        '
        'Label37
        '
        Me.Label37.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.Black
        Me.Label37.Location = New System.Drawing.Point(-13, 17)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(39, 23)
        Me.Label37.TabIndex = 28
        Me.Label37.Text = "Fan"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbo_fan_quantity_2
        '
        Me.cbo_fan_quantity_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_fan_quantity_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_fan_quantity_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbo_fan_quantity_2.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "20", "22", "24"})
        Me.cbo_fan_quantity_2.Location = New System.Drawing.Point(668, 15)
        Me.cbo_fan_quantity_2.Name = "cbo_fan_quantity_2"
        Me.cbo_fan_quantity_2.Size = New System.Drawing.Size(72, 21)
        Me.cbo_fan_quantity_2.TabIndex = 15
        '
        'cboFan2
        '
        Me.cboFan2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFan2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFan2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboFan2.Location = New System.Drawing.Point(32, 17)
        Me.cboFan2.MaxDropDownItems = 9
        Me.cboFan2.Name = "cboFan2"
        Me.cboFan2.Size = New System.Drawing.Size(288, 21)
        Me.cboFan2.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label5.Location = New System.Drawing.Point(598, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 21)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Quantity"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gboCompressor2
        '
        Me.gboCompressor2.Controls.Add(Me.txtCapMult2)
        Me.gboCompressor2.Controls.Add(Me.lblCapMult2)
        Me.gboCompressor2.Controls.Add(Me.Label36)
        Me.gboCompressor2.Controls.Add(Me.Label10)
        Me.gboCompressor2.Controls.Add(Me.cbo_compressor_2)
        Me.gboCompressor2.Controls.Add(Me.cbo_compressor_quantity_2)
        Me.gboCompressor2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboCompressor2.ForeColor = System.Drawing.Color.Navy
        Me.gboCompressor2.Location = New System.Drawing.Point(8, 4)
        Me.gboCompressor2.Name = "gboCompressor2"
        Me.gboCompressor2.Size = New System.Drawing.Size(630, 42)
        Me.gboCompressor2.TabIndex = 30
        Me.gboCompressor2.TabStop = False
        Me.gboCompressor2.Text = "Compressor Info"
        '
        'txtCapMult2
        '
        Me.txtCapMult2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCapMult2.Location = New System.Drawing.Point(581, 15)
        Me.txtCapMult2.Name = "txtCapMult2"
        Me.txtCapMult2.Size = New System.Drawing.Size(43, 21)
        Me.txtCapMult2.TabIndex = 23
        Me.txtCapMult2.Text = "1"
        Me.txtCapMult2.Visible = False
        '
        'lblCapMult2
        '
        Me.lblCapMult2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapMult2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCapMult2.Location = New System.Drawing.Point(511, 15)
        Me.lblCapMult2.Name = "lblCapMult2"
        Me.lblCapMult2.Size = New System.Drawing.Size(64, 21)
        Me.lblCapMult2.TabIndex = 22
        Me.lblCapMult2.Text = "Cap. Mult."
        Me.lblCapMult2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCapMult2.Visible = False
        '
        'Label36
        '
        Me.Label36.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Black
        Me.Label36.Location = New System.Drawing.Point(8, 16)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(68, 23)
        Me.Label36.TabIndex = 21
        Me.Label36.Text = "Compressor"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(359, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 21)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Quantity"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbo_compressor_2
        '
        Me.cbo_compressor_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_compressor_2.Font = New System.Drawing.Font("Lucida Console", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_compressor_2.Items.AddRange(New Object() {"Ref R22H", "HP: 3----06DM808", "HP: 5----06DM313", "HP: 5----06DM316", "HP: 6.5--06DA818", "HP: 6.5--06DR820", "HP: 7.5--06DA824", "HP: 7.5--06DR228", "HP: 10---06DA328", "HP: 10---06DM337", "HP: 15---06DA537", "HP: 15---06EM150", "HP: 20---06EA250", "HP: 25---06EA265", "HP: 25---06EM175", "HP: 25---06EA275", "HP: 35---06EM199", "HP: 40---06EA299", "HP: 5----2DD3-0500", "HP: 8----2DA3-0750", "HP: 9----3DA3-0750", "HP: 10---3DB3-1000", "HP: 12---3DF3-1200", "HP: 15---3DS3-1500", "HP: 20---4DA3-2000", "HP: 25---4DH3-2500", "HP: 30---4DJ3-3000", "HP: 55---4D254D30", "HP: 60---4D256D35", "HP: 65---4D306D35", "HP: 35---6DG3-3500", "HP: 35---6DH3-3500", "HP: 40---6DJ3-4000", "HP: 50---8DP3-5000", "HP: 75---6D356D40", "HP: 90---6D408D50", "HP: 60---8DS3-6000", "HP: 40---4005-SC", "HP: 50---5005-SC", "HP: 60---6005-SC", "HP: 50---SCH2SHL1-5000", "HP: 60---SCH2SHL1-6000", "HP: 70---SCH2SHL1-7000", "HP: 80---SCH2-8000", "HP: 90---SCH2-9000", "HP: 110--SCH2-11HO", "HP: 120--SCH2-12HO", "HP: 140--SCH2-14HO", "HP: 40---SRC-S-113", "HP: 50---SRC-S-133", "HP: 60---SRC-S-163", "HP: 70---SRC-S-183", "HP: 80---SRC-S-213", "HP: 100--SRC-S-253", "HP: 120--SRC-S-303", "HP: 140--SRC-S-353", "HP: 160--SRC-S-413", "HP: 180--SRC-S-453", "HP: 2----ZB15KA", "HP: 2----ZR24K3", "HP: 2.5--ZB19KA", "HP: 2.5--ZR30K3", "HP: 3----ZB21KA", "HP: 3----ZR34K3", "HP: 3----ZR36K3", "HP: 3.5--ZB26KA", "HP: 3.5--ZR42K3", "HP: 4----ZB30KA", "HP: 4----ZR49K3", "HP: 4.5--ZR54K3", "HP: 5----ZB38KA", "HP: 5----ZR61K3", "HP: 6----ZB45KA", "HP: 6----ZR72KC", "HP: 7.5--ZB56KA", "HP: 7.5--ZR90K3", "HP: 9----ZB68KA", "HP: 9----ZR11M3", "HP: 10---ZB75KA", "HP: 10---ZR12M3", "HP: 13---ZB92KA", "HP: 13---ZR16M3", "HP: 15---ZB11MA", "HP: 15---ZR19M3", "Ref R22M", "HP: 30---SHM1-3000", "HP: 35---SHM1-3500", "HP: 40---SHM1-4000", "HP: 50---SHM1-5000", "HP: 60---SHM1-6000", "HP: 70---SHM1-7000", "HP: 80---SHM1-8000", "HP: 90---SHM1-9000", "Ref R22L", "HP: 3----2DF3-0300", "HP: 3----2DF3-0300", "HP: 4----2DL3-0400", "HP: 6----2DA3-0600", "HP: 6----2DAB-0600", "HP: 7----3DA3-0600", "HP: 8----3DB3-0750", "HP: 9----3DF3-0900", "HP: 10---3DS3-1000", "HP: 10---4DA3-1000", "HP: 15---4DL3-1500", "HP: 22---4DT3-2200", "HP: 27---6DL3-2700", "HP: 30---6DT3-3000", "HP: 5----06DR718", "HP: 6.5--06DR724", "HP: 7.5--06DR228", "HP: 10---06DR337", "Ref R404aH", "HP: 5----2DD3-0500", "HP: 8----2DA3-0750", "HP: 8----2DL3-0750", "HP: 10---3DB3-1000", "HP: 12---3DF3-1200", "HP: 15---3DS3-1500", "HP: 20---4DA3-2000", "HP: 25---4DH3-2500", "HP: 25---4DH3-2500", "HP: 30---4DJ3-3000", "HP: 35---6DH3-3500", "HP: 40---6DJ3-4000", "HP: 30---SHM1-3000", "HP: 35---SHM1-3500", "HP: 40---SHM1-4000", "HP: 50---SHM1-5000", "HP: 60---SHM1-6000", "HP: 70---SHM1-7000", "HP: 80---SHM1-8000", "HP: 90---SHM1-9000", "Ref R404aM", "HP: 2----ERA1-0200", "HP: 3----ERF1-0310", "Ref R404aL", "HP: 3----2DF3-0300", "HP: 4----2DL3-0400", "HP: 6----2DA3-0600", "HP: 7----3DA3-0600", "HP: 8----3DB3-0750", "HP: 9----3DF3-0900", "HP: 10---3DS3-1000", "HP: 10---4DA3-1010", "HP: 15---4DL3-1500", "HP: 22---4DT3-2200", "HP: 27---6DL3-2700", "HP: 30---6DT3-3000", "HP: 1----KAJ1-0100", "HP: 1.5--KALA-0150", "HP: 2----EAV1-0200", "HP: 3----LAC1-0310", "HP: 20---SHL1-2000", "HP: 25---SHL1-2500", "HP: 30---SHL1-3000", "HP: 40---SHL1-4000", "HP: 75---SHL1-7500", "HP: 50---SCH2SHL1-5000", "HP: 60---SCH2SHL1-6000", "HP: 70---SCH2SHL1-7000", "HP: 2----ZF06K4E", "HP: 2.5--ZF08K4E", "HP: 3----ZF09K4E", "HP: 3.5--ZF11K4E", "HP: 4----ZF13K4E", "HP: 5----ZF15K4", "HP: 5----ZF15K4E", "HP: 6----ZF18K4E", "HP: 7.5--ZF24K4", "HP: 7.5--ZF24K4E", "HP: 10---ZF33K4E", "HP: 13---ZF40K4E", "HP: 15---ZF48K4E", "Ref R507cH", "HP: 8----2DA3-0750", "HP: 10---3DB3-1000", "HP: 12---3DF3-1200", "HP: 15---3DS3-1500", "HP: 20---4DA3-2000", "HP: 30---4DJ3-3000", "HP: 35---6DH3-3500", "HP: 40---6DJ3-4000", "Ref R507cM", "HP: 2----ERA1-0200", "HP: 3----ERF1-0310", "Ref R507cL", "HP: 3----2DF3-0300", "HP: 6----2DA3-0600", "HP: 8----3DB3-0750", "HP: 10---3DS3-1000", "HP: 10---4DA3-1010", "HP: 22---4DT3-2200", "HP: 27---6DL3-2700", "HP: 30---6DT3-3000", "HP: 1----KAJ1-0100", "HP: 1.5--KALA-0150", "HP: 2----EAV1-0200", "HP: 3----LAC1-0310", "HP: 2----ZF06K4E", "HP: 2.5--ZF08K4E", "HP: 3----ZF09K4E", "HP: 3.5--ZF11K4E", "HP: 4----ZF13K4E", "HP: 6----ZF18K4E", "HP: 10---ZF33K4E", "HP: 13---ZF40K4E", "HP: 15---ZF48K4E"})
        Me.cbo_compressor_2.Location = New System.Drawing.Point(84, 16)
        Me.cbo_compressor_2.MaxDropDownItems = 22
        Me.cbo_compressor_2.Name = "cbo_compressor_2"
        Me.cbo_compressor_2.Size = New System.Drawing.Size(268, 20)
        Me.cbo_compressor_2.TabIndex = 3
        '
        'cbo_compressor_quantity_2
        '
        Me.cbo_compressor_quantity_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_compressor_quantity_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_compressor_quantity_2.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.cbo_compressor_quantity_2.Location = New System.Drawing.Point(431, 16)
        Me.cbo_compressor_quantity_2.Name = "cbo_compressor_quantity_2"
        Me.cbo_compressor_quantity_2.Size = New System.Drawing.Size(61, 21)
        Me.cbo_compressor_quantity_2.TabIndex = 1
        '
        'tabCircuit3
        '
        Me.tabCircuit3.Controls.Add(Me.panCircuit3)
        Me.tabCircuit3.Location = New System.Drawing.Point(4, 22)
        Me.tabCircuit3.Name = "tabCircuit3"
        Me.tabCircuit3.Size = New System.Drawing.Size(778, 217)
        Me.tabCircuit3.TabIndex = 2
        Me.tabCircuit3.Text = "Circuit 3"
        '
        'panCircuit3
        '
        Me.panCircuit3.Controls.Add(Me.GroupBox3)
        Me.panCircuit3.Controls.Add(Me.GroupBox2)
        Me.panCircuit3.Controls.Add(Me.GroupBox1)
        Me.panCircuit3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panCircuit3.Location = New System.Drawing.Point(0, 0)
        Me.panCircuit3.Name = "panCircuit3"
        Me.panCircuit3.Size = New System.Drawing.Size(778, 217)
        Me.panCircuit3.TabIndex = 2
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.cboFanQuantity3)
        Me.GroupBox3.Controls.Add(Me.cboFanDiameter3)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox3.Location = New System.Drawing.Point(8, 120)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(348, 42)
        Me.GroupBox3.TabIndex = 41
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Fan Info"
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label15.Location = New System.Drawing.Point(212, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 21)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "Quantity"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFanQuantity3
        '
        Me.cboFanQuantity3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFanQuantity3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFanQuantity3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboFanQuantity3.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "20", "22", "24"})
        Me.cboFanQuantity3.Location = New System.Drawing.Point(284, 16)
        Me.cboFanQuantity3.Name = "cboFanQuantity3"
        Me.cboFanQuantity3.Size = New System.Drawing.Size(56, 22)
        Me.cboFanQuantity3.TabIndex = 15
        '
        'cboFanDiameter3
        '
        Me.cboFanDiameter3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFanDiameter3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFanDiameter3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboFanDiameter3.Location = New System.Drawing.Point(12, 16)
        Me.cboFanDiameter3.MaxDropDownItems = 9
        Me.cboFanDiameter3.Name = "cboFanDiameter3"
        Me.cboFanDiameter3.Size = New System.Drawing.Size(180, 22)
        Me.cboFanDiameter3.TabIndex = 17
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblCoilsRequiredValue3)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.txtCoilFinWidth3)
        Me.GroupBox2.Controls.Add(Me.txtCoilFinHeight3)
        Me.GroupBox2.Controls.Add(Me.cboFinsPerInch3)
        Me.GroupBox2.Controls.Add(Me.txtCoilSubCoolingPercentage3)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox2.Location = New System.Drawing.Point(8, 52)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(456, 62)
        Me.GroupBox2.TabIndex = 40
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Coil Info"
        '
        'lblCoilsRequiredValue3
        '
        Me.lblCoilsRequiredValue3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCoilsRequiredValue3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCoilsRequiredValue3.Location = New System.Drawing.Point(112, 12)
        Me.lblCoilsRequiredValue3.Name = "lblCoilsRequiredValue3"
        Me.lblCoilsRequiredValue3.Size = New System.Drawing.Size(36, 23)
        Me.lblCoilsRequiredValue3.TabIndex = 5
        Me.lblCoilsRequiredValue3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label13.Location = New System.Drawing.Point(4, 36)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 21)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "Fin Height"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label14.Location = New System.Drawing.Point(140, 36)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 21)
        Me.Label14.TabIndex = 36
        Me.Label14.Text = "Fin Length"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label17.Location = New System.Drawing.Point(4, 12)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(100, 23)
        Me.Label17.TabIndex = 32
        Me.Label17.Text = "Quantity Required"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label19.Location = New System.Drawing.Point(296, 36)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(88, 21)
        Me.Label19.TabIndex = 33
        Me.Label19.Text = "Fins Per Inch"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCoilFinWidth3
        '
        Me.txtCoilFinWidth3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoilFinWidth3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCoilFinWidth3.Location = New System.Drawing.Point(220, 36)
        Me.txtCoilFinWidth3.Name = "txtCoilFinWidth3"
        Me.txtCoilFinWidth3.Size = New System.Drawing.Size(56, 20)
        Me.txtCoilFinWidth3.TabIndex = 13
        '
        'txtCoilFinHeight3
        '
        Me.txtCoilFinHeight3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoilFinHeight3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCoilFinHeight3.Location = New System.Drawing.Point(72, 36)
        Me.txtCoilFinHeight3.Name = "txtCoilFinHeight3"
        Me.txtCoilFinHeight3.Size = New System.Drawing.Size(56, 20)
        Me.txtCoilFinHeight3.TabIndex = 12
        '
        'cboFinsPerInch3
        '
        Me.cboFinsPerInch3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFinsPerInch3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFinsPerInch3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboFinsPerInch3.Items.AddRange(New Object() {"8", "9", "10", "11", "12", "13", "14"})
        Me.cboFinsPerInch3.Location = New System.Drawing.Point(388, 34)
        Me.cboFinsPerInch3.Name = "cboFinsPerInch3"
        Me.cboFinsPerInch3.Size = New System.Drawing.Size(56, 22)
        Me.cboFinsPerInch3.TabIndex = 6
        '
        'txtCoilSubCoolingPercentage3
        '
        Me.txtCoilSubCoolingPercentage3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoilSubCoolingPercentage3.Location = New System.Drawing.Point(388, 12)
        Me.txtCoilSubCoolingPercentage3.Name = "txtCoilSubCoolingPercentage3"
        Me.txtCoilSubCoolingPercentage3.Size = New System.Drawing.Size(56, 20)
        Me.txtCoilSubCoolingPercentage3.TabIndex = 18
        Me.txtCoilSubCoolingPercentage3.Text = "0"
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(296, 12)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(88, 21)
        Me.Label22.TabIndex = 39
        Me.Label22.Text = "Sub Cooling %"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.cboCompressor3)
        Me.GroupBox1.Controls.Add(Me.cboCompressorQuantity3)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(8, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(348, 42)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Compressor Info"
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label20.Location = New System.Drawing.Point(212, 16)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(64, 21)
        Me.Label20.TabIndex = 30
        Me.Label20.Text = "Quantity"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCompressor3
        '
        Me.cboCompressor3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompressor3.Font = New System.Drawing.Font("Lucida Console", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCompressor3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCompressor3.Items.AddRange(New Object() {"Ref R22H", "HP: 3----06DM808", "HP: 5----06DM313", "HP: 5----06DM316", "HP: 6.5--06DA818", "HP: 6.5--06DR820", "HP: 7.5--06DA824", "HP: 7.5--06DR228", "HP: 10---06DA328", "HP: 10---06DM337", "HP: 15---06DA537", "HP: 15---06EM150", "HP: 20---06EA250", "HP: 25---06EA265", "HP: 25---06EM175", "HP: 25---06EA275", "HP: 35---06EM199", "HP: 40---06EA299", "HP: 5----2DD3-0500", "HP: 8----2DA3-0750", "HP: 9----3DA3-0750", "HP: 10---3DB3-1000", "HP: 12---3DF3-1200", "HP: 15---3DS3-1500", "HP: 20---4DA3-2000", "HP: 25---4DH3-2500", "HP: 30---4DJ3-3000", "HP: 55---4D254D30", "HP: 60---4D256D35", "HP: 65---4D306D35", "HP: 35---6DG3-3500", "HP: 35---6DH3-3500", "HP: 40---6DJ3-4000", "HP: 50---8DP3-5000", "HP: 75---6D356D40", "HP: 90---6D408D50", "HP: 60---8DS3-6000", "HP: 40---4005-SC", "HP: 50---5005-SC", "HP: 60---6005-SC", "HP: 50---SCH2SHL1-5000", "HP: 60---SCH2SHL1-6000", "HP: 70---SCH2SHL1-7000", "HP: 80---SCH2-8000", "HP: 90---SCH2-9000", "HP: 110--SCH2-11HO", "HP: 120--SCH2-12HO", "HP: 140--SCH2-14HO", "HP: 40---SRC-S-113", "HP: 50---SRC-S-133", "HP: 60---SRC-S-163", "HP: 70---SRC-S-183", "HP: 80---SRC-S-213", "HP: 100--SRC-S-253", "HP: 120--SRC-S-303", "HP: 140--SRC-S-353", "HP: 160--SRC-S-413", "HP: 180--SRC-S-453", "HP: 2----ZB15KA", "HP: 2----ZR24K3", "HP: 2.5--ZB19KA", "HP: 2.5--ZR30K3", "HP: 3----ZB21KA", "HP: 3----ZR34K3", "HP: 3----ZR36K3", "HP: 3.5--ZB26KA", "HP: 3.5--ZR42K3", "HP: 4----ZB30KA", "HP: 4----ZR49K3", "HP: 4.5--ZR54K3", "HP: 5----ZB38KA", "HP: 5----ZR61K3", "HP: 6----ZB45KA", "HP: 6----ZR72KC", "HP: 7.5--ZB56KA", "HP: 7.5--ZR90K3", "HP: 9----ZB68KA", "HP: 9----ZR11M3", "HP: 10---ZB75KA", "HP: 10---ZR12M3", "HP: 13---ZB92KA", "HP: 13---ZR16M3", "HP: 15---ZB11MA", "HP: 15---ZR19M3", "Ref R22M", "HP: 30---SHM1-3000", "HP: 35---SHM1-3500", "HP: 40---SHM1-4000", "HP: 50---SHM1-5000", "HP: 60---SHM1-6000", "HP: 70---SHM1-7000", "HP: 80---SHM1-8000", "HP: 90---SHM1-9000", "Ref R22L", "HP: 3----2DF3-0300", "HP: 3----2DF3-0300", "HP: 4----2DL3-0400", "HP: 6----2DA3-0600", "HP: 6----2DAB-0600", "HP: 7----3DA3-0600", "HP: 8----3DB3-0750", "HP: 9----3DF3-0900", "HP: 10---3DS3-1000", "HP: 10---4DA3-1000", "HP: 15---4DL3-1500", "HP: 22---4DT3-2200", "HP: 27---6DL3-2700", "HP: 30---6DT3-3000", "HP: 5----06DR718", "HP: 6.5--06DR724", "HP: 7.5--06DR228", "HP: 10---06DR337", "Ref R404aH", "HP: 5----2DD3-0500", "HP: 8----2DA3-0750", "HP: 8----2DL3-0750", "HP: 10---3DB3-1000", "HP: 12---3DF3-1200", "HP: 15---3DS3-1500", "HP: 20---4DA3-2000", "HP: 25---4DH3-2500", "HP: 25---4DH3-2500", "HP: 30---4DJ3-3000", "HP: 35---6DH3-3500", "HP: 40---6DJ3-4000", "HP: 30---SHM1-3000", "HP: 35---SHM1-3500", "HP: 40---SHM1-4000", "HP: 50---SHM1-5000", "HP: 60---SHM1-6000", "HP: 70---SHM1-7000", "HP: 80---SHM1-8000", "HP: 90---SHM1-9000", "Ref R404aM", "HP: 2----ERA1-0200", "HP: 3----ERF1-0310", "Ref R404aL", "HP: 3----2DF3-0300", "HP: 4----2DL3-0400", "HP: 6----2DA3-0600", "HP: 7----3DA3-0600", "HP: 8----3DB3-0750", "HP: 9----3DF3-0900", "HP: 10---3DS3-1000", "HP: 10---4DA3-1010", "HP: 15---4DL3-1500", "HP: 22---4DT3-2200", "HP: 27---6DL3-2700", "HP: 30---6DT3-3000", "HP: 1----KAJ1-0100", "HP: 1.5--KALA-0150", "HP: 2----EAV1-0200", "HP: 3----LAC1-0310", "HP: 20---SHL1-2000", "HP: 25---SHL1-2500", "HP: 30---SHL1-3000", "HP: 40---SHL1-4000", "HP: 75---SHL1-7500", "HP: 50---SCH2SHL1-5000", "HP: 60---SCH2SHL1-6000", "HP: 70---SCH2SHL1-7000", "HP: 2----ZF06K4E", "HP: 2.5--ZF08K4E", "HP: 3----ZF09K4E", "HP: 3.5--ZF11K4E", "HP: 4----ZF13K4E", "HP: 5----ZF15K4", "HP: 5----ZF15K4E", "HP: 6----ZF18K4E", "HP: 7.5--ZF24K4", "HP: 7.5--ZF24K4E", "HP: 10---ZF33K4E", "HP: 13---ZF40K4E", "HP: 15---ZF48K4E", "Ref R507cH", "HP: 8----2DA3-0750", "HP: 10---3DB3-1000", "HP: 12---3DF3-1200", "HP: 15---3DS3-1500", "HP: 20---4DA3-2000", "HP: 30---4DJ3-3000", "HP: 35---6DH3-3500", "HP: 40---6DJ3-4000", "Ref R507cM", "HP: 2----ERA1-0200", "HP: 3----ERF1-0310", "Ref R507cL", "HP: 3----2DF3-0300", "HP: 6----2DA3-0600", "HP: 8----3DB3-0750", "HP: 10---3DS3-1000", "HP: 10---4DA3-1010", "HP: 22---4DT3-2200", "HP: 27---6DL3-2700", "HP: 30---6DT3-3000", "HP: 1----KAJ1-0100", "HP: 1.5--KALA-0150", "HP: 2----EAV1-0200", "HP: 3----LAC1-0310", "HP: 2----ZF06K4E", "HP: 2.5--ZF08K4E", "HP: 3----ZF09K4E", "HP: 3.5--ZF11K4E", "HP: 4----ZF13K4E", "HP: 6----ZF18K4E", "HP: 10---ZF33K4E", "HP: 13---ZF40K4E", "HP: 15---ZF48K4E"})
        Me.cboCompressor3.Location = New System.Drawing.Point(12, 16)
        Me.cboCompressor3.MaxDropDownItems = 22
        Me.cboCompressor3.Name = "cboCompressor3"
        Me.cboCompressor3.Size = New System.Drawing.Size(180, 20)
        Me.cboCompressor3.TabIndex = 3
        '
        'cboCompressorQuantity3
        '
        Me.cboCompressorQuantity3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompressorQuantity3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCompressorQuantity3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCompressorQuantity3.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.cboCompressorQuantity3.Location = New System.Drawing.Point(284, 16)
        Me.cboCompressorQuantity3.Name = "cboCompressorQuantity3"
        Me.cboCompressorQuantity3.Size = New System.Drawing.Size(56, 22)
        Me.cboCompressorQuantity3.TabIndex = 1
        '
        'tabCircuit4
        '
        Me.tabCircuit4.Controls.Add(Me.panCircuit4)
        Me.tabCircuit4.Location = New System.Drawing.Point(4, 22)
        Me.tabCircuit4.Name = "tabCircuit4"
        Me.tabCircuit4.Size = New System.Drawing.Size(778, 217)
        Me.tabCircuit4.TabIndex = 3
        Me.tabCircuit4.Text = "Circuit 4"
        '
        'panCircuit4
        '
        Me.panCircuit4.Controls.Add(Me.GroupBox6)
        Me.panCircuit4.Controls.Add(Me.GroupBox5)
        Me.panCircuit4.Controls.Add(Me.GroupBox4)
        Me.panCircuit4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panCircuit4.Location = New System.Drawing.Point(0, 0)
        Me.panCircuit4.Name = "panCircuit4"
        Me.panCircuit4.Size = New System.Drawing.Size(778, 217)
        Me.panCircuit4.TabIndex = 2
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label25)
        Me.GroupBox6.Controls.Add(Me.cboFanQuantity4)
        Me.GroupBox6.Controls.Add(Me.cboFanDiameter4)
        Me.GroupBox6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox6.Location = New System.Drawing.Point(8, 120)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(348, 42)
        Me.GroupBox6.TabIndex = 42
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Fan Info"
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label25.Location = New System.Drawing.Point(208, 16)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(68, 21)
        Me.Label25.TabIndex = 37
        Me.Label25.Text = "Quantity"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFanQuantity4
        '
        Me.cboFanQuantity4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFanQuantity4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFanQuantity4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboFanQuantity4.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "20", "22", "24"})
        Me.cboFanQuantity4.Location = New System.Drawing.Point(284, 16)
        Me.cboFanQuantity4.Name = "cboFanQuantity4"
        Me.cboFanQuantity4.Size = New System.Drawing.Size(56, 22)
        Me.cboFanQuantity4.TabIndex = 15
        '
        'cboFanDiameter4
        '
        Me.cboFanDiameter4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFanDiameter4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFanDiameter4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboFanDiameter4.Location = New System.Drawing.Point(12, 16)
        Me.cboFanDiameter4.MaxDropDownItems = 9
        Me.cboFanDiameter4.Name = "cboFanDiameter4"
        Me.cboFanDiameter4.Size = New System.Drawing.Size(180, 22)
        Me.cboFanDiameter4.TabIndex = 17
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cboFinsPerInch4)
        Me.GroupBox5.Controls.Add(Me.txtCoilFinWidth4)
        Me.GroupBox5.Controls.Add(Me.txtCoilFinHeight4)
        Me.GroupBox5.Controls.Add(Me.Label23)
        Me.GroupBox5.Controls.Add(Me.Label24)
        Me.GroupBox5.Controls.Add(Me.cboCoilRows4)
        Me.GroupBox5.Controls.Add(Me.Label27)
        Me.GroupBox5.Controls.Add(Me.lblCoilsRequiredValue4)
        Me.GroupBox5.Controls.Add(Me.Label28)
        Me.GroupBox5.Controls.Add(Me.Label29)
        Me.GroupBox5.Controls.Add(Me.Label32)
        Me.GroupBox5.Controls.Add(Me.txtCoilSubCoolingPercentage4)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox5.Location = New System.Drawing.Point(8, 52)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(456, 62)
        Me.GroupBox5.TabIndex = 41
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Coil Info"
        '
        'cboFinsPerInch4
        '
        Me.cboFinsPerInch4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFinsPerInch4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFinsPerInch4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboFinsPerInch4.Items.AddRange(New Object() {"8", "9", "10", "11", "12", "13", "14"})
        Me.cboFinsPerInch4.Location = New System.Drawing.Point(388, 34)
        Me.cboFinsPerInch4.Name = "cboFinsPerInch4"
        Me.cboFinsPerInch4.Size = New System.Drawing.Size(56, 22)
        Me.cboFinsPerInch4.TabIndex = 6
        '
        'txtCoilFinWidth4
        '
        Me.txtCoilFinWidth4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoilFinWidth4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCoilFinWidth4.Location = New System.Drawing.Point(220, 36)
        Me.txtCoilFinWidth4.Name = "txtCoilFinWidth4"
        Me.txtCoilFinWidth4.Size = New System.Drawing.Size(56, 20)
        Me.txtCoilFinWidth4.TabIndex = 13
        '
        'txtCoilFinHeight4
        '
        Me.txtCoilFinHeight4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoilFinHeight4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCoilFinHeight4.Location = New System.Drawing.Point(72, 36)
        Me.txtCoilFinHeight4.Name = "txtCoilFinHeight4"
        Me.txtCoilFinHeight4.Size = New System.Drawing.Size(56, 20)
        Me.txtCoilFinHeight4.TabIndex = 12
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label23.Location = New System.Drawing.Point(4, 36)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(60, 21)
        Me.Label23.TabIndex = 35
        Me.Label23.Text = "Fin Height"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label24.Location = New System.Drawing.Point(132, 36)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(80, 21)
        Me.Label24.TabIndex = 36
        Me.Label24.Text = "Fin Length"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCoilRows4
        '
        Me.cboCoilRows4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoilRows4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCoilRows4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCoilRows4.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6"})
        Me.cboCoilRows4.Location = New System.Drawing.Point(220, 12)
        Me.cboCoilRows4.Name = "cboCoilRows4"
        Me.cboCoilRows4.Size = New System.Drawing.Size(56, 22)
        Me.cboCoilRows4.TabIndex = 9
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label27.Location = New System.Drawing.Point(8, 12)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(96, 23)
        Me.Label27.TabIndex = 32
        Me.Label27.Text = "Quantity Required"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCoilsRequiredValue4
        '
        Me.lblCoilsRequiredValue4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCoilsRequiredValue4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCoilsRequiredValue4.Location = New System.Drawing.Point(112, 12)
        Me.lblCoilsRequiredValue4.Name = "lblCoilsRequiredValue4"
        Me.lblCoilsRequiredValue4.Size = New System.Drawing.Size(40, 22)
        Me.lblCoilsRequiredValue4.TabIndex = 5
        Me.lblCoilsRequiredValue4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label28.Location = New System.Drawing.Point(168, 12)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(44, 23)
        Me.Label28.TabIndex = 34
        Me.Label28.Text = "Rows"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label29.Location = New System.Drawing.Point(296, 36)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(88, 21)
        Me.Label29.TabIndex = 33
        Me.Label29.Text = "Fins Per Inch"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label32
        '
        Me.Label32.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(296, 12)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(88, 21)
        Me.Label32.TabIndex = 39
        Me.Label32.Text = "Sub Cooling %"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCoilSubCoolingPercentage4
        '
        Me.txtCoilSubCoolingPercentage4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoilSubCoolingPercentage4.Location = New System.Drawing.Point(388, 12)
        Me.txtCoilSubCoolingPercentage4.Name = "txtCoilSubCoolingPercentage4"
        Me.txtCoilSubCoolingPercentage4.Size = New System.Drawing.Size(56, 20)
        Me.txtCoilSubCoolingPercentage4.TabIndex = 18
        Me.txtCoilSubCoolingPercentage4.Text = "0"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboCompressorQuantity4)
        Me.GroupBox4.Controls.Add(Me.Label30)
        Me.GroupBox4.Controls.Add(Me.cboCompressor4)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox4.Location = New System.Drawing.Point(8, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(348, 42)
        Me.GroupBox4.TabIndex = 40
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Compressor Info"
        '
        'cboCompressorQuantity4
        '
        Me.cboCompressorQuantity4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompressorQuantity4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCompressorQuantity4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCompressorQuantity4.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.cboCompressorQuantity4.Location = New System.Drawing.Point(284, 16)
        Me.cboCompressorQuantity4.Name = "cboCompressorQuantity4"
        Me.cboCompressorQuantity4.Size = New System.Drawing.Size(56, 22)
        Me.cboCompressorQuantity4.TabIndex = 1
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label30.Location = New System.Drawing.Point(212, 16)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(64, 21)
        Me.Label30.TabIndex = 30
        Me.Label30.Text = "Quantity"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCompressor4
        '
        Me.cboCompressor4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompressor4.Font = New System.Drawing.Font("Lucida Console", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCompressor4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCompressor4.Location = New System.Drawing.Point(12, 16)
        Me.cboCompressor4.MaxDropDownItems = 22
        Me.cboCompressor4.Name = "cboCompressor4"
        Me.cboCompressor4.Size = New System.Drawing.Size(180, 20)
        Me.cboCompressor4.TabIndex = 3
        '
        'panRatingHideFromRep
        '
        Me.panRatingHideFromRep.Controls.Add(Me.txtDOECompliant)
        Me.panRatingHideFromRep.Controls.Add(Me.Label6)
        Me.panRatingHideFromRep.Controls.Add(Me.cboUSTLimit)
        Me.panRatingHideFromRep.Controls.Add(Me.lblUSTLimit)
        Me.panRatingHideFromRep.Controls.Add(Me.cboCTLimit)
        Me.panRatingHideFromRep.Controls.Add(Me.lblCTLimit)
        Me.panRatingHideFromRep.Controls.Add(Me.cboRatingSubCooling)
        Me.panRatingHideFromRep.Controls.Add(Me.lblRatingSubCooling)
        Me.panRatingHideFromRep.Controls.Add(Me.cboRatingSafety)
        Me.panRatingHideFromRep.Controls.Add(Me.lblRatingSafety)
        Me.panRatingHideFromRep.Controls.Add(Me.cboRatingHertz)
        Me.panRatingHideFromRep.Controls.Add(Me.lblRatingHertz)
        Me.panRatingHideFromRep.Controls.Add(Me.cboRatingCatalog)
        Me.panRatingHideFromRep.Controls.Add(Me.lblRatingCatalog)
        Me.panRatingHideFromRep.Controls.Add(Me.txt_subcooling_temperature)
        Me.panRatingHideFromRep.Controls.Add(Me.lblRatingLiquidCooling)
        Me.panRatingHideFromRep.Dock = System.Windows.Forms.DockStyle.Top
        Me.panRatingHideFromRep.Location = New System.Drawing.Point(0, 168)
        Me.panRatingHideFromRep.Name = "panRatingHideFromRep"
        Me.panRatingHideFromRep.Size = New System.Drawing.Size(957, 120)
        Me.panRatingHideFromRep.TabIndex = 5
        '
        'txtDOECompliant
        '
        Me.txtDOECompliant.Location = New System.Drawing.Point(593, 3)
        Me.txtDOECompliant.Name = "txtDOECompliant"
        Me.txtDOECompliant.ReadOnly = True
        Me.txtDOECompliant.Size = New System.Drawing.Size(72, 21)
        Me.txtDOECompliant.TabIndex = 37
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(457, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 23)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "DOE Compliant"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboUSTLimit
        '
        Me.cboUSTLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUSTLimit.Items.AddRange(New Object() {"N", "Y"})
        Me.cboUSTLimit.Location = New System.Drawing.Point(593, 88)
        Me.cboUSTLimit.Name = "cboUSTLimit"
        Me.cboUSTLimit.Size = New System.Drawing.Size(72, 21)
        Me.cboUSTLimit.TabIndex = 35
        '
        'lblUSTLimit
        '
        Me.lblUSTLimit.Location = New System.Drawing.Point(457, 84)
        Me.lblUSTLimit.Name = "lblUSTLimit"
        Me.lblUSTLimit.Size = New System.Drawing.Size(128, 32)
        Me.lblUSTLimit.TabIndex = 34
        Me.lblUSTLimit.Text = "Unit Suction Limit Override"
        Me.lblUSTLimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCTLimit
        '
        Me.cboCTLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCTLimit.Items.AddRange(New Object() {"N", "Y"})
        Me.cboCTLimit.Location = New System.Drawing.Point(383, 88)
        Me.cboCTLimit.Name = "cboCTLimit"
        Me.cboCTLimit.Size = New System.Drawing.Size(72, 21)
        Me.cboCTLimit.TabIndex = 33
        '
        'lblCTLimit
        '
        Me.lblCTLimit.Location = New System.Drawing.Point(247, 84)
        Me.lblCTLimit.Name = "lblCTLimit"
        Me.lblCTLimit.Size = New System.Drawing.Size(128, 32)
        Me.lblCTLimit.TabIndex = 32
        Me.lblCTLimit.Text = "Condensing temperature limit override"
        Me.lblCTLimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboRatingSubCooling
        '
        Me.cboRatingSubCooling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRatingSubCooling.Items.AddRange(New Object() {"N", "Y"})
        Me.cboRatingSubCooling.Location = New System.Drawing.Point(144, 4)
        Me.cboRatingSubCooling.Name = "cboRatingSubCooling"
        Me.cboRatingSubCooling.Size = New System.Drawing.Size(72, 21)
        Me.cboRatingSubCooling.TabIndex = 21
        '
        'lblRatingSubCooling
        '
        Me.lblRatingSubCooling.Location = New System.Drawing.Point(8, 4)
        Me.lblRatingSubCooling.Name = "lblRatingSubCooling"
        Me.lblRatingSubCooling.Size = New System.Drawing.Size(128, 23)
        Me.lblRatingSubCooling.TabIndex = 20
        Me.lblRatingSubCooling.Text = "Sub cooling"
        Me.lblRatingSubCooling.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboRatingSafety
        '
        Me.cboRatingSafety.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRatingSafety.Items.AddRange(New Object() {"N", "Y"})
        Me.cboRatingSafety.Location = New System.Drawing.Point(144, 88)
        Me.cboRatingSafety.Name = "cboRatingSafety"
        Me.cboRatingSafety.Size = New System.Drawing.Size(72, 21)
        Me.cboRatingSafety.TabIndex = 31
        '
        'lblRatingSafety
        '
        Me.lblRatingSafety.Location = New System.Drawing.Point(8, 84)
        Me.lblRatingSafety.Name = "lblRatingSafety"
        Me.lblRatingSafety.Size = New System.Drawing.Size(128, 32)
        Me.lblRatingSafety.TabIndex = 30
        Me.lblRatingSafety.Text = "Compressor safety override"
        Me.lblRatingSafety.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboRatingHertz
        '
        Me.cboRatingHertz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRatingHertz.Items.AddRange(New Object() {"60 HZ", "50 HZ"})
        Me.cboRatingHertz.Location = New System.Drawing.Point(144, 60)
        Me.cboRatingHertz.Name = "cboRatingHertz"
        Me.cboRatingHertz.Size = New System.Drawing.Size(72, 21)
        Me.cboRatingHertz.TabIndex = 29
        '
        'lblRatingHertz
        '
        Me.lblRatingHertz.Location = New System.Drawing.Point(8, 60)
        Me.lblRatingHertz.Name = "lblRatingHertz"
        Me.lblRatingHertz.Size = New System.Drawing.Size(128, 23)
        Me.lblRatingHertz.TabIndex = 28
        Me.lblRatingHertz.Text = "Hertz rating"
        Me.lblRatingHertz.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboRatingCatalog
        '
        Me.cboRatingCatalog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRatingCatalog.Items.AddRange(New Object() {"Catalog", "Standard"})
        Me.cboRatingCatalog.Location = New System.Drawing.Point(144, 32)
        Me.cboRatingCatalog.Name = "cboRatingCatalog"
        Me.cboRatingCatalog.Size = New System.Drawing.Size(72, 21)
        Me.cboRatingCatalog.TabIndex = 27
        '
        'lblRatingCatalog
        '
        Me.lblRatingCatalog.Location = New System.Drawing.Point(8, 32)
        Me.lblRatingCatalog.Name = "lblRatingCatalog"
        Me.lblRatingCatalog.Size = New System.Drawing.Size(128, 23)
        Me.lblRatingCatalog.TabIndex = 26
        Me.lblRatingCatalog.Text = "Catalog or standard"
        Me.lblRatingCatalog.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_subcooling_temperature
        '
        Me.txt_subcooling_temperature.Location = New System.Drawing.Point(220, 4)
        Me.txt_subcooling_temperature.Name = "txt_subcooling_temperature"
        Me.txt_subcooling_temperature.ReadOnly = True
        Me.txt_subcooling_temperature.Size = New System.Drawing.Size(72, 21)
        Me.txt_subcooling_temperature.TabIndex = 25
        Me.txt_subcooling_temperature.Text = "10"
        '
        'lblRatingLiquidCooling
        '
        Me.lblRatingLiquidCooling.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblRatingLiquidCooling.Location = New System.Drawing.Point(296, 4)
        Me.lblRatingLiquidCooling.Name = "lblRatingLiquidCooling"
        Me.lblRatingLiquidCooling.Size = New System.Drawing.Size(40, 23)
        Me.lblRatingLiquidCooling.TabIndex = 22
        Me.lblRatingLiquidCooling.Text = "ºF"
        Me.lblRatingLiquidCooling.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'panRatingDataBody
        '
        Me.panRatingDataBody.Controls.Add(Me.voltageRatingComboBox)
        Me.panRatingDataBody.Controls.Add(Me.voltageRatingLabel)
        Me.panRatingDataBody.Controls.Add(Me.Label33)
        Me.panRatingDataBody.Controls.Add(Me.Label31)
        Me.panRatingDataBody.Controls.Add(Me.Label26)
        Me.panRatingDataBody.Controls.Add(Me.Label21)
        Me.panRatingDataBody.Controls.Add(Me.lblRatingTabCapacityUnits)
        Me.panRatingDataBody.Controls.Add(Me.txt_custom_model)
        Me.panRatingDataBody.Controls.Add(Me.txtRatingTabAltitude)
        Me.panRatingDataBody.Controls.Add(Me.lblRatingAltitude)
        Me.panRatingDataBody.Controls.Add(Me.cbo_rating_tab_refrigerant)
        Me.panRatingDataBody.Controls.Add(Me.lblRatingRefrigerant)
        Me.panRatingDataBody.Controls.Add(Me.cboRatingSuctionSteps)
        Me.panRatingDataBody.Controls.Add(Me.lblRatingSuctionSteps)
        Me.panRatingDataBody.Controls.Add(Me.cboRatingSuctionInterval)
        Me.panRatingDataBody.Controls.Add(Me.lblRatingSuctionInterval)
        Me.panRatingDataBody.Controls.Add(Me.txt_rating_tab_suction)
        Me.panRatingDataBody.Controls.Add(Me.lblRatingSuction)
        Me.panRatingDataBody.Controls.Add(Me.cboRatingAmbientSteps)
        Me.panRatingDataBody.Controls.Add(Me.lblRatingAmbientSteps)
        Me.panRatingDataBody.Controls.Add(Me.cboRatingAmbientInterval)
        Me.panRatingDataBody.Controls.Add(Me.lblRatingAmbientInterval)
        Me.panRatingDataBody.Controls.Add(Me.txtRatingTabAmbient)
        Me.panRatingDataBody.Controls.Add(Me.lblRatingAmbientTemperature)
        Me.panRatingDataBody.Controls.Add(Me.lblRatingCapacityValue)
        Me.panRatingDataBody.Controls.Add(Me.lblRatingCapacity)
        Me.panRatingDataBody.Controls.Add(Me.lblRatingCondensingUnitModelValue)
        Me.panRatingDataBody.Controls.Add(Me.lblRatingCondensingUnitModel)
        Me.panRatingDataBody.Dock = System.Windows.Forms.DockStyle.Top
        Me.panRatingDataBody.Location = New System.Drawing.Point(0, 0)
        Me.panRatingDataBody.Name = "panRatingDataBody"
        Me.panRatingDataBody.Size = New System.Drawing.Size(957, 168)
        Me.panRatingDataBody.TabIndex = 2
        '
        'voltageRatingComboBox
        '
        Me.voltageRatingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.voltageRatingComboBox.FormattingEnabled = True
        Me.voltageRatingComboBox.Location = New System.Drawing.Point(308, 114)
        Me.voltageRatingComboBox.Name = "voltageRatingComboBox"
        Me.voltageRatingComboBox.Size = New System.Drawing.Size(72, 21)
        Me.voltageRatingComboBox.TabIndex = 55
        '
        'voltageRatingLabel
        '
        Me.voltageRatingLabel.AutoSize = True
        Me.voltageRatingLabel.Location = New System.Drawing.Point(256, 119)
        Me.voltageRatingLabel.Name = "voltageRatingLabel"
        Me.voltageRatingLabel.Size = New System.Drawing.Size(43, 13)
        Me.voltageRatingLabel.TabIndex = 54
        Me.voltageRatingLabel.Text = "Voltage"
        '
        'Label33
        '
        Me.Label33.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label33.Location = New System.Drawing.Point(384, 88)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(20, 23)
        Me.Label33.TabIndex = 26
        Me.Label33.Text = "ºF"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label31
        '
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label31.Location = New System.Drawing.Point(384, 60)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(20, 23)
        Me.Label31.TabIndex = 25
        Me.Label31.Text = "ºF"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label26.Location = New System.Drawing.Point(220, 88)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(28, 23)
        Me.Label26.TabIndex = 24
        Me.Label26.Text = "ºF"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label21.Location = New System.Drawing.Point(220, 60)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(28, 23)
        Me.Label21.TabIndex = 23
        Me.Label21.Text = "ºF"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRatingTabCapacityUnits
        '
        Me.lblRatingTabCapacityUnits.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblRatingTabCapacityUnits.Location = New System.Drawing.Point(248, 32)
        Me.lblRatingTabCapacityUnits.Name = "lblRatingTabCapacityUnits"
        Me.lblRatingTabCapacityUnits.Size = New System.Drawing.Size(40, 23)
        Me.lblRatingTabCapacityUnits.TabIndex = 21
        Me.lblRatingTabCapacityUnits.Text = "BTUH"
        Me.lblRatingTabCapacityUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_custom_model
        '
        Me.txt_custom_model.Location = New System.Drawing.Point(248, 4)
        Me.txt_custom_model.Name = "txt_custom_model"
        Me.txt_custom_model.Size = New System.Drawing.Size(100, 21)
        Me.txt_custom_model.TabIndex = 20
        '
        'txtRatingTabAltitude
        '
        Me.txtRatingTabAltitude.Location = New System.Drawing.Point(144, 144)
        Me.txtRatingTabAltitude.Name = "txtRatingTabAltitude"
        Me.txtRatingTabAltitude.Size = New System.Drawing.Size(72, 21)
        Me.txtRatingTabAltitude.TabIndex = 19
        Me.txtRatingTabAltitude.Text = "0"
        '
        'lblRatingAltitude
        '
        Me.lblRatingAltitude.Location = New System.Drawing.Point(8, 144)
        Me.lblRatingAltitude.Name = "lblRatingAltitude"
        Me.lblRatingAltitude.Size = New System.Drawing.Size(128, 23)
        Me.lblRatingAltitude.TabIndex = 18
        Me.lblRatingAltitude.Text = "Altitude"
        Me.lblRatingAltitude.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbo_rating_tab_refrigerant
        '
        Me.cbo_rating_tab_refrigerant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_rating_tab_refrigerant.Location = New System.Drawing.Point(144, 116)
        Me.cbo_rating_tab_refrigerant.MaxDropDownItems = 10
        Me.cbo_rating_tab_refrigerant.Name = "cbo_rating_tab_refrigerant"
        Me.cbo_rating_tab_refrigerant.Size = New System.Drawing.Size(72, 21)
        Me.cbo_rating_tab_refrigerant.TabIndex = 17
        '
        'lblRatingRefrigerant
        '
        Me.lblRatingRefrigerant.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRatingRefrigerant.Location = New System.Drawing.Point(8, 116)
        Me.lblRatingRefrigerant.Name = "lblRatingRefrigerant"
        Me.lblRatingRefrigerant.Size = New System.Drawing.Size(128, 23)
        Me.lblRatingRefrigerant.TabIndex = 16
        Me.lblRatingRefrigerant.Text = "Refrigerant"
        Me.lblRatingRefrigerant.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboRatingSuctionSteps
        '
        Me.cboRatingSuctionSteps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRatingSuctionSteps.Items.AddRange(New Object() {"4"})
        Me.cboRatingSuctionSteps.Location = New System.Drawing.Point(488, 88)
        Me.cboRatingSuctionSteps.Name = "cboRatingSuctionSteps"
        Me.cboRatingSuctionSteps.Size = New System.Drawing.Size(72, 21)
        Me.cboRatingSuctionSteps.TabIndex = 15
        '
        'lblRatingSuctionSteps
        '
        Me.lblRatingSuctionSteps.Location = New System.Drawing.Point(408, 88)
        Me.lblRatingSuctionSteps.Name = "lblRatingSuctionSteps"
        Me.lblRatingSuctionSteps.Size = New System.Drawing.Size(72, 23)
        Me.lblRatingSuctionSteps.TabIndex = 14
        Me.lblRatingSuctionSteps.Text = "Output steps"
        Me.lblRatingSuctionSteps.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboRatingSuctionInterval
        '
        Me.cboRatingSuctionInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRatingSuctionInterval.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cboRatingSuctionInterval.Location = New System.Drawing.Point(308, 88)
        Me.cboRatingSuctionInterval.Name = "cboRatingSuctionInterval"
        Me.cboRatingSuctionInterval.Size = New System.Drawing.Size(72, 21)
        Me.cboRatingSuctionInterval.TabIndex = 13
        '
        'lblRatingSuctionInterval
        '
        Me.lblRatingSuctionInterval.Location = New System.Drawing.Point(248, 88)
        Me.lblRatingSuctionInterval.Name = "lblRatingSuctionInterval"
        Me.lblRatingSuctionInterval.Size = New System.Drawing.Size(52, 23)
        Me.lblRatingSuctionInterval.TabIndex = 12
        Me.lblRatingSuctionInterval.Text = "Interval"
        Me.lblRatingSuctionInterval.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_rating_tab_suction
        '
        Me.txt_rating_tab_suction.Location = New System.Drawing.Point(144, 88)
        Me.txt_rating_tab_suction.Name = "txt_rating_tab_suction"
        Me.txt_rating_tab_suction.Size = New System.Drawing.Size(72, 21)
        Me.txt_rating_tab_suction.TabIndex = 11
        '
        'lblRatingSuction
        '
        Me.lblRatingSuction.Location = New System.Drawing.Point(8, 88)
        Me.lblRatingSuction.Name = "lblRatingSuction"
        Me.lblRatingSuction.Size = New System.Drawing.Size(128, 23)
        Me.lblRatingSuction.TabIndex = 10
        Me.lblRatingSuction.Text = "Saturated suction"
        Me.lblRatingSuction.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboRatingAmbientSteps
        '
        Me.cboRatingAmbientSteps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRatingAmbientSteps.Items.AddRange(New Object() {"3", "4", "5"})
        Me.cboRatingAmbientSteps.Location = New System.Drawing.Point(488, 60)
        Me.cboRatingAmbientSteps.Name = "cboRatingAmbientSteps"
        Me.cboRatingAmbientSteps.Size = New System.Drawing.Size(72, 21)
        Me.cboRatingAmbientSteps.TabIndex = 9
        '
        'lblRatingAmbientSteps
        '
        Me.lblRatingAmbientSteps.Location = New System.Drawing.Point(408, 60)
        Me.lblRatingAmbientSteps.Name = "lblRatingAmbientSteps"
        Me.lblRatingAmbientSteps.Size = New System.Drawing.Size(72, 23)
        Me.lblRatingAmbientSteps.TabIndex = 8
        Me.lblRatingAmbientSteps.Text = "Output steps"
        Me.lblRatingAmbientSteps.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboRatingAmbientInterval
        '
        Me.cboRatingAmbientInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRatingAmbientInterval.Items.AddRange(New Object() {"5", "10", "15", "20"})
        Me.cboRatingAmbientInterval.Location = New System.Drawing.Point(308, 60)
        Me.cboRatingAmbientInterval.Name = "cboRatingAmbientInterval"
        Me.cboRatingAmbientInterval.Size = New System.Drawing.Size(72, 21)
        Me.cboRatingAmbientInterval.TabIndex = 7
        '
        'lblRatingAmbientInterval
        '
        Me.lblRatingAmbientInterval.Location = New System.Drawing.Point(248, 60)
        Me.lblRatingAmbientInterval.Name = "lblRatingAmbientInterval"
        Me.lblRatingAmbientInterval.Size = New System.Drawing.Size(52, 23)
        Me.lblRatingAmbientInterval.TabIndex = 6
        Me.lblRatingAmbientInterval.Text = "Interval"
        Me.lblRatingAmbientInterval.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRatingTabAmbient
        '
        Me.txtRatingTabAmbient.Location = New System.Drawing.Point(144, 60)
        Me.txtRatingTabAmbient.Name = "txtRatingTabAmbient"
        Me.txtRatingTabAmbient.Size = New System.Drawing.Size(72, 21)
        Me.txtRatingTabAmbient.TabIndex = 5
        '
        'lblRatingAmbientTemperature
        '
        Me.lblRatingAmbientTemperature.Location = New System.Drawing.Point(8, 60)
        Me.lblRatingAmbientTemperature.Name = "lblRatingAmbientTemperature"
        Me.lblRatingAmbientTemperature.Size = New System.Drawing.Size(128, 23)
        Me.lblRatingAmbientTemperature.TabIndex = 4
        Me.lblRatingAmbientTemperature.Text = "Design ambient"
        Me.lblRatingAmbientTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRatingCapacityValue
        '
        Me.lblRatingCapacityValue.ForeColor = System.Drawing.Color.Navy
        Me.lblRatingCapacityValue.Location = New System.Drawing.Point(144, 32)
        Me.lblRatingCapacityValue.Name = "lblRatingCapacityValue"
        Me.lblRatingCapacityValue.Size = New System.Drawing.Size(104, 23)
        Me.lblRatingCapacityValue.TabIndex = 3
        Me.lblRatingCapacityValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRatingCapacity
        '
        Me.lblRatingCapacity.Location = New System.Drawing.Point(8, 32)
        Me.lblRatingCapacity.Name = "lblRatingCapacity"
        Me.lblRatingCapacity.Size = New System.Drawing.Size(128, 23)
        Me.lblRatingCapacity.TabIndex = 2
        Me.lblRatingCapacity.Text = "Total Est. Capacity"
        Me.lblRatingCapacity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRatingCondensingUnitModelValue
        '
        Me.lblRatingCondensingUnitModelValue.ForeColor = System.Drawing.Color.Navy
        Me.lblRatingCondensingUnitModelValue.Location = New System.Drawing.Point(144, 4)
        Me.lblRatingCondensingUnitModelValue.Name = "lblRatingCondensingUnitModelValue"
        Me.lblRatingCondensingUnitModelValue.Size = New System.Drawing.Size(104, 23)
        Me.lblRatingCondensingUnitModelValue.TabIndex = 1
        Me.lblRatingCondensingUnitModelValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRatingCondensingUnitModel
        '
        Me.lblRatingCondensingUnitModel.Location = New System.Drawing.Point(8, 4)
        Me.lblRatingCondensingUnitModel.Name = "lblRatingCondensingUnitModel"
        Me.lblRatingCondensingUnitModel.Size = New System.Drawing.Size(128, 23)
        Me.lblRatingCondensingUnitModel.TabIndex = 0
        Me.lblRatingCondensingUnitModel.Text = "Unit model number"
        Me.lblRatingCondensingUnitModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabResults
        '
        Me.tabResults.Controls.Add(Me.Grid1)
        Me.tabResults.Controls.Add(Me.lblDemandCoolingNote)
        Me.tabResults.Controls.Add(Me.lblResultsOmit)
        Me.tabResults.Controls.Add(Me.lblResultsNumberOfFansValue)
        Me.tabResults.Controls.Add(Me.lblResultsNumberOfFans)
        Me.tabResults.Controls.Add(Me.lblResultsNumberOfCompressorsValue)
        Me.tabResults.Controls.Add(Me.lblResultsNumberOfCompressors)
        Me.tabResults.Controls.Add(Me.lblResultsCondenserCapacityValue)
        Me.tabResults.Controls.Add(Me.lblResultsCondenserCapacity)
        Me.tabResults.Controls.Add(Me.panCreateReport)
        Me.tabResults.Controls.Add(Me.lblResultsAltitudeValue)
        Me.tabResults.Controls.Add(Me.lblResultsAltitude)
        Me.tabResults.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabResults.Location = New System.Drawing.Point(4, 22)
        Me.tabResults.Name = "tabResults"
        Me.tabResults.Size = New System.Drawing.Size(957, 610)
        Me.tabResults.TabIndex = 2
        Me.tabResults.Text = "Results"
        '
        'Grid1
        '
        Me.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid1.Location = New System.Drawing.Point(16, 80)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Size = New System.Drawing.Size(933, 373)
        Me.Grid1.TabIndex = 15
        Me.Grid1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray

        Me.Grid1.EnableHeadersVisualStyles = False
        Me.Grid1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue
        '
        'lblDemandCoolingNote
        '
        Me.lblDemandCoolingNote.AutoSize = True
        Me.lblDemandCoolingNote.Location = New System.Drawing.Point(240, 60)
        Me.lblDemandCoolingNote.Name = "lblDemandCoolingNote"
        Me.lblDemandCoolingNote.Size = New System.Drawing.Size(344, 13)
        Me.lblDemandCoolingNote.TabIndex = 14
        Me.lblDemandCoolingNote.Text = "* When Operating at this Temperature, Unit Requires Demand Cooling"
        Me.lblDemandCoolingNote.Visible = False
        '
        'lblResultsOmit
        '
        Me.lblResultsOmit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblResultsOmit.Location = New System.Drawing.Point(16, 56)
        Me.lblResultsOmit.Name = "lblResultsOmit"
        Me.lblResultsOmit.Size = New System.Drawing.Size(829, 21)
        Me.lblResultsOmit.TabIndex = 11
        Me.lblResultsOmit.Text = "Points outside operating limits omitted."
        Me.lblResultsOmit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblResultsOmit.Visible = False
        '
        'lblResultsNumberOfFansValue
        '
        Me.lblResultsNumberOfFansValue.ForeColor = System.Drawing.Color.Navy
        Me.lblResultsNumberOfFansValue.Location = New System.Drawing.Point(544, 456)
        Me.lblResultsNumberOfFansValue.Name = "lblResultsNumberOfFansValue"
        Me.lblResultsNumberOfFansValue.Size = New System.Drawing.Size(64, 23)
        Me.lblResultsNumberOfFansValue.TabIndex = 7
        Me.lblResultsNumberOfFansValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblResultsNumberOfFansValue.Visible = False
        '
        'lblResultsNumberOfFans
        '
        Me.lblResultsNumberOfFans.Location = New System.Drawing.Point(448, 456)
        Me.lblResultsNumberOfFans.Name = "lblResultsNumberOfFans"
        Me.lblResultsNumberOfFans.Size = New System.Drawing.Size(88, 23)
        Me.lblResultsNumberOfFans.TabIndex = 6
        Me.lblResultsNumberOfFans.Text = "# of Fans/Size"
        Me.lblResultsNumberOfFans.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblResultsNumberOfFans.Visible = False
        '
        'lblResultsNumberOfCompressorsValue
        '
        Me.lblResultsNumberOfCompressorsValue.ForeColor = System.Drawing.Color.Navy
        Me.lblResultsNumberOfCompressorsValue.Location = New System.Drawing.Point(544, 472)
        Me.lblResultsNumberOfCompressorsValue.Name = "lblResultsNumberOfCompressorsValue"
        Me.lblResultsNumberOfCompressorsValue.Size = New System.Drawing.Size(48, 23)
        Me.lblResultsNumberOfCompressorsValue.TabIndex = 5
        Me.lblResultsNumberOfCompressorsValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblResultsNumberOfCompressorsValue.Visible = False
        '
        'lblResultsNumberOfCompressors
        '
        Me.lblResultsNumberOfCompressors.Location = New System.Drawing.Point(432, 472)
        Me.lblResultsNumberOfCompressors.Name = "lblResultsNumberOfCompressors"
        Me.lblResultsNumberOfCompressors.Size = New System.Drawing.Size(104, 23)
        Me.lblResultsNumberOfCompressors.TabIndex = 4
        Me.lblResultsNumberOfCompressors.Text = "# of Compressors"
        Me.lblResultsNumberOfCompressors.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblResultsNumberOfCompressors.Visible = False
        '
        'lblResultsCondenserCapacityValue
        '
        Me.lblResultsCondenserCapacityValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblResultsCondenserCapacityValue.ForeColor = System.Drawing.Color.Black
        Me.lblResultsCondenserCapacityValue.Location = New System.Drawing.Point(400, 480)
        Me.lblResultsCondenserCapacityValue.Name = "lblResultsCondenserCapacityValue"
        Me.lblResultsCondenserCapacityValue.Size = New System.Drawing.Size(88, 23)
        Me.lblResultsCondenserCapacityValue.TabIndex = 3
        Me.lblResultsCondenserCapacityValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblResultsCondenserCapacityValue.Visible = False
        '
        'lblResultsCondenserCapacity
        '
        Me.lblResultsCondenserCapacity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblResultsCondenserCapacity.Location = New System.Drawing.Point(192, 480)
        Me.lblResultsCondenserCapacity.Name = "lblResultsCondenserCapacity"
        Me.lblResultsCondenserCapacity.Size = New System.Drawing.Size(192, 23)
        Me.lblResultsCondenserCapacity.TabIndex = 2
        Me.lblResultsCondenserCapacity.Text = "Condenser Est. Capacity at 1ºF T.D.:"
        Me.lblResultsCondenserCapacity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblResultsCondenserCapacity.Visible = False
        '
        'panCreateReport
        '
        Me.panCreateReport.Controls.Add(Me.btnCreateReport)
        Me.panCreateReport.Controls.Add(Me.btnNewEquipmentPricing)
        Me.panCreateReport.Controls.Add(Me.btnReturn)
        Me.panCreateReport.Dock = System.Windows.Forms.DockStyle.Top
        Me.panCreateReport.Location = New System.Drawing.Point(0, 0)
        Me.panCreateReport.Name = "panCreateReport"
        Me.panCreateReport.Size = New System.Drawing.Size(957, 48)
        Me.panCreateReport.TabIndex = 13
        '
        'btnCreateReport
        '
        Me.btnCreateReport.BackColor = System.Drawing.Color.White
        Me.btnCreateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreateReport.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateReport.ForeColor = System.Drawing.Color.Navy
        Me.btnCreateReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateReport.Location = New System.Drawing.Point(26, 16)
        Me.btnCreateReport.Name = "btnCreateReport"
        Me.btnCreateReport.Size = New System.Drawing.Size(168, 32)
        Me.btnCreateReport.TabIndex = 12
        Me.btnCreateReport.Text = "Create Report"
        Me.btnCreateReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreateReport.UseVisualStyleBackColor = False
        '
        'btnNewEquipmentPricing
        '
        Me.btnNewEquipmentPricing.BackColor = System.Drawing.Color.White
        Me.btnNewEquipmentPricing.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewEquipmentPricing.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewEquipmentPricing.ForeColor = System.Drawing.Color.Navy
        Me.btnNewEquipmentPricing.Image = CType(resources.GetObject("btnNewEquipmentPricing.Image"), System.Drawing.Image)
        Me.btnNewEquipmentPricing.Location = New System.Drawing.Point(376, 16)
        Me.btnNewEquipmentPricing.Name = "btnNewEquipmentPricing"
        Me.btnNewEquipmentPricing.Size = New System.Drawing.Size(208, 32)
        Me.btnNewEquipmentPricing.TabIndex = 15
        Me.btnNewEquipmentPricing.Text = "New Equipment Pricing"
        Me.btnNewEquipmentPricing.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNewEquipmentPricing.UseVisualStyleBackColor = False
        '
        'btnReturn
        '
        Me.btnReturn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnReturn.Location = New System.Drawing.Point(200, 16)
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Size = New System.Drawing.Size(160, 32)
        Me.btnReturn.TabIndex = 14
        Me.btnReturn.Text = "Return to Balance Program"
        Me.btnReturn.Visible = False
        '
        'lblResultsAltitudeValue
        '
        Me.lblResultsAltitudeValue.ForeColor = System.Drawing.Color.Navy
        Me.lblResultsAltitudeValue.Location = New System.Drawing.Point(344, 488)
        Me.lblResultsAltitudeValue.Name = "lblResultsAltitudeValue"
        Me.lblResultsAltitudeValue.Size = New System.Drawing.Size(88, 23)
        Me.lblResultsAltitudeValue.TabIndex = 9
        Me.lblResultsAltitudeValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblResultsAltitudeValue.Visible = False
        '
        'lblResultsAltitude
        '
        Me.lblResultsAltitude.Location = New System.Drawing.Point(266, 503)
        Me.lblResultsAltitude.Name = "lblResultsAltitude"
        Me.lblResultsAltitude.Size = New System.Drawing.Size(72, 23)
        Me.lblResultsAltitude.TabIndex = 8
        Me.lblResultsAltitude.Text = "Altitude"
        Me.lblResultsAltitude.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblResultsAltitude.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(616, 24)
        Me.MenuStrip1.TabIndex = 40
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenCondensingUnitRatingToolStripMenuItem, Me.ToolStripSeparator3, Me.SaveCondToolStripMenuItem, Me.RevisionCondensingUnitRatingToolStripMenuItem, Me.SaveAsNewMenuItem, Me.ToolStripSeparator2, Me.ConvertToEquipmentToolStripMenuItem, Me.ToolStripSeparator1, Me.mnuFilePrintCondensingUnits})
        Me.mnuFile.MergeAction = System.Windows.Forms.MergeAction.MatchOnly
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(37, 20)
        Me.mnuFile.Text = "&File"
        '
        'OpenCondensingUnitRatingToolStripMenuItem
        '
        Me.OpenCondensingUnitRatingToolStripMenuItem.Enabled = False
        Me.OpenCondensingUnitRatingToolStripMenuItem.Image = CType(resources.GetObject("OpenCondensingUnitRatingToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenCondensingUnitRatingToolStripMenuItem.Name = "OpenCondensingUnitRatingToolStripMenuItem"
        Me.OpenCondensingUnitRatingToolStripMenuItem.Size = New System.Drawing.Size(314, 22)
        Me.OpenCondensingUnitRatingToolStripMenuItem.Text = "Open Condensing Unit Rating..."
        Me.OpenCondensingUnitRatingToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(311, 6)
        '
        'SaveCondToolStripMenuItem
        '
        Me.SaveCondToolStripMenuItem.Image = CType(resources.GetObject("SaveCondToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveCondToolStripMenuItem.Name = "SaveCondToolStripMenuItem"
        Me.SaveCondToolStripMenuItem.Size = New System.Drawing.Size(314, 22)
        Me.SaveCondToolStripMenuItem.Text = "Save Condensing Unit Rating..."
        '
        'RevisionCondensingUnitRatingToolStripMenuItem
        '
        Me.RevisionCondensingUnitRatingToolStripMenuItem.Image = CType(resources.GetObject("RevisionCondensingUnitRatingToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RevisionCondensingUnitRatingToolStripMenuItem.Name = "RevisionCondensingUnitRatingToolStripMenuItem"
        Me.RevisionCondensingUnitRatingToolStripMenuItem.Size = New System.Drawing.Size(314, 22)
        Me.RevisionCondensingUnitRatingToolStripMenuItem.Text = "Revision Condensing Unit Rating..."
        '
        'SaveAsNewMenuItem
        '
        Me.SaveAsNewMenuItem.Name = "SaveAsNewMenuItem"
        Me.SaveAsNewMenuItem.Size = New System.Drawing.Size(314, 22)
        Me.SaveAsNewMenuItem.Text = "Save As New Condensing Unit Rating..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(311, 6)
        '
        'ConvertToEquipmentToolStripMenuItem
        '
        Me.ConvertToEquipmentToolStripMenuItem.Image = CType(resources.GetObject("ConvertToEquipmentToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ConvertToEquipmentToolStripMenuItem.Name = "ConvertToEquipmentToolStripMenuItem"
        Me.ConvertToEquipmentToolStripMenuItem.Size = New System.Drawing.Size(314, 22)
        Me.ConvertToEquipmentToolStripMenuItem.Text = "Convert Condenser Unit Rating To Equipment"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(311, 6)
        Me.ToolStripSeparator1.Visible = False
        '
        'mnuFilePrintCondensingUnits
        '
        Me.mnuFilePrintCondensingUnits.Image = CType(resources.GetObject("mnuFilePrintCondensingUnits.Image"), System.Drawing.Image)
        Me.mnuFilePrintCondensingUnits.Name = "mnuFilePrintCondensingUnits"
        Me.mnuFilePrintCondensingUnits.Size = New System.Drawing.Size(314, 22)
        Me.mnuFilePrintCondensingUnits.Text = "Print Condensing Unit Rating..."
        '
        'timerHighlightReturn
        '
        '
        'SaveToolStripPanel1
        '
        Me.SaveToolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SaveToolStripPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SaveToolStripPanel1.Name = "SaveToolStripPanel1"
        Me.SaveToolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.SaveToolStripPanel1.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.SaveToolStripPanel1.Size = New System.Drawing.Size(965, 0)
        '
        'condensing_unit_rating_screen
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(965, 636)
        Me.Controls.Add(Me.tabCondensingUnit)
        Me.Controls.Add(Me.SaveToolStripPanel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(450, 450)
        Me.Name = "condensing_unit_rating_screen"
        Me.Text = "Air Cooled Condensing Units"
        Me.panRunTimeAdjust.ResumeLayout(False)
        Me.panRun.ResumeLayout(False)
        Me.panInputsBody.ResumeLayout(False)
        Me.panInputsBody.PerformLayout()
        Me.grpRunTime.ResumeLayout(False)
        Me.grpRunTime.PerformLayout()
        Me.grpBoxLoad.ResumeLayout(False)
        Me.grpBoxLoad.PerformLayout()
        Me.compressorIsUsing10CoefficientsPanel.ResumeLayout(False)
        Me.compressorIsUsing10CoefficientsPanel.PerformLayout()
        Me.panOutputsBody.ResumeLayout(False)
        Me.panCondensingUnit.ResumeLayout(False)
        Me.panMain.ResumeLayout(False)
        Me.panRatingBodyTSI.ResumeLayout(False)
        Me.panRatingBody.ResumeLayout(False)
        Me.panSelectCondensingUnit.ResumeLayout(False)
        Me.tabCondensingUnit.ResumeLayout(False)
        Me.tabSelection.ResumeLayout(False)
        Me.tabRating.ResumeLayout(False)
        Me.panRatingMain.ResumeLayout(False)
        Me.panRateUnit.ResumeLayout(False)
        Me.panRatingCircuitBody.ResumeLayout(False)
        Me.tabCircuits.ResumeLayout(False)
        Me.tabCircuit1.ResumeLayout(False)
        Me.panCircuit1.ResumeLayout(False)
        Me.gboFan1.ResumeLayout(False)
        Me.gboFan1.PerformLayout()
        Me.gboCompressor1.ResumeLayout(False)
        Me.gboCompressor1.PerformLayout()
        Me.gboCoil1.ResumeLayout(False)
        Me.gboCoil1.PerformLayout()
        Me.tabCircuit2.ResumeLayout(False)
        Me.panCircuit2.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.gboFan2.ResumeLayout(False)
        Me.gboFan2.PerformLayout()
        Me.gboCompressor2.ResumeLayout(False)
        Me.gboCompressor2.PerformLayout()
        Me.tabCircuit3.ResumeLayout(False)
        Me.panCircuit3.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.tabCircuit4.ResumeLayout(False)
        Me.panCircuit4.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.panRatingHideFromRep.ResumeLayout(False)
        Me.panRatingHideFromRep.PerformLayout()
        Me.panRatingDataBody.ResumeLayout(False)
        Me.panRatingDataBody.PerformLayout()
        Me.tabResults.ResumeLayout(False)
        Me.tabResults.PerformLayout()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panCreateReport.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


#Region " Revision Control / Saving Variables..."

    Public ProcessDeleted As Boolean

    Public LastSavedProcess As CondensingUnitProcessItem
    Public CurrentStateProcess As CondensingUnitProcessItem
    Friend WithEvents SaveToolStripPanel1 As Rae.RaeSolutions.SaveToolStripPanel
    'todo: is this used through reflection anywhere???
    Private LastStateProcess As CondensingUnitProcessItem

    Private _currentRevision As Single = -1
    Property CurrentRevision As Single
        Get
            Return _currentRevision
        End Get
        Set(ByVal value As Single)
            _currentRevision = value
        End Set
    End Property

    Private _latestRevision As Single = -1
    Property LatestRevision As Single
        Get
            Return _latestRevision
        End Get
        Set(ByVal value As Single)
            _latestRevision = value
        End Set
    End Property

#End Region


#Region " Public declarations"
    Public IsParentBalanceProgram As Boolean = False
    Public IsCanceled As Boolean
    Public IsBalance As Boolean
    Public ReturnToBalance As Boolean
#End Region


#Region " Initializations"

    'allows to determine previously selected tab
    Dim selectedTab As Integer = 0
    Dim previousTab As Integer = 0
    'indicates second tab has been calculated so the final results tab is calculated
    Dim IsUnitRated As Boolean = False
    Dim usageLogger As Diagnostics.UsageLog.FormUsageLogger

#End Region


#Region " Event handlers"

#Region " Form event handlers"

    Private Sub form_Activated(ByVal sender As Object, ByVal e As EventArgs) _
    Handles Me.Activated
        If Not IsBalance Then
            initializeSaveToolStripPanel()
            Me.SaveToolStripPanel1.Merge()
        End If
    End Sub


    Private Sub form_Deactivate(ByVal sender As Object, ByVal e As EventArgs) _
    Handles Me.Deactivate
        If Not IsBalance Then
            Me.SaveToolStripPanel1.Unmerge()
        End If
    End Sub

    'mybase.closing happens before me.formclosing
    Private Sub form_Closing(ByVal sender As Object, ByVal e As CancelEventArgs) _
    Handles MyBase.Closing
        logFormEnd()
    End Sub

    Private Sub form_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) _
    Handles Me.FormClosing
        ' Do not allow user to close form if it was called from balance
        ' Force user to use btnReturn to go back...
        If IsBalance AndAlso Not ReturnToBalance Then
            Me.timerHighlightReturn.Enabled = True
            e.Cancel = True
        ElseIf closeWithoutSaving Then
            ' running through saving logic causes exception if the form had an exception during loading
        Else
            If Not Me.ProcessDeleted Then
                If SaveControls(False, False, True) = False Then
                    e.Cancel = True
                Else
                    RemoveHandler AppInfo.Main.RevisionView1.RevisionChanged, AddressOf RevisionView_RevisionChanged
                End If
            End If
        End If
    End Sub

    Private user As user
    Private capacityDigits As Integer


    Private Sub form_Load() _
    Handles MyBase.Load
        Try
            user = AppInfo.User
            capacityDigits = getCapacityDigits(AppInfo.Division)

            '  logFormStart()
            initializeControls()

            'maximizes height; sets height of child form to the height of its mdiparent's client area height
            Me.Size = New Size(Me.Size.Width, Ui.FormEditor.MaximizeHeight(Me))

            'aligns top of form to the top of the mdiparent's client area
            Me.Location = New Point(Me.Location.X, 0)

            Me.btnReturn.Visible = Me.IsBalance

            'add handler to revision view . revision changed event on main form...
            AddHandler AppInfo.Main.RevisionView1.RevisionChanged, AddressOf RevisionView_RevisionChanged


            fillCoilCombobox()

            authorizeForCoolstuff()


            If user.is_in(Rae.solutions.group.capacity_multiplier) Then
                lblCapMult1.Visible = True
                txtCapMult1.Visible = True
                lblCapMult2.Visible = True
                txtCapMult2.Visible = True
            End If

            ' blargg - hide NMB and NMC
            'lblNMB.Visible = False
            'lblNMC.Visible = False
            'cboNMB.Visible = False
            'cboNMC.Visible = False

        Catch ex As Exception
            alert("The window cannot be properly loaded. Please close the window. " & ex.Message)
            closeWithoutSaving = True
        End Try
    End Sub
    Private closeWithoutSaving As Boolean

#End Region


#Region " Button event handlers"



    '1. navigates to next tab, 'Rating'
    Private Sub btnRating_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles btnRating.Click, btnRating2.Click, btnRating3.Click
        'view rating tab, wait to change tabs til here in case of invalid inputs
        Me.tabCondensingUnit.SelectedTab = Me.tabRating
    End Sub


    '1. navigates to next tab, 'Results'
    'calculations occur on TabIndexChanged event
    Private Sub btnRateUnit_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles btnRateUnit.Click
        Me.tabCondensingUnit.SelectedTab = tabResults
    End Sub


    Private Sub btnCreateReport_Click() _
    Handles btnCreateReport.Click

        If Me.cboRatingSafety.SelectedItem = "Y" And Not user.is_in(Rae.Solutions.group.application_engineering) Then
            MsgBox("You have chosen to override the compressor safety limit.  Report printing has been disabled.")
            Exit Sub
        End If

        Dim isRAE As Boolean = AppInfo.User.is_employee


        If Me.cboUSTLimit.SelectedItem = "Y" And Not isRAE Then
            MsgBox("You have chosen to override the unit specific suction temperature limits.  Report printing has been disabled.")
            Exit Sub
        End If



        Cursor = Cursors.WaitCursor
        Try
            show_report()
        Catch ex As Exception
            alert(ex.Message)
        Finally
            Cursor = Cursors.Arrow
        End Try
    End Sub


    Private Sub btnReturnToBalance_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles btnReturn.Click
        'canceled is initialized to true, so only way result returns is by button
        Me.IsCanceled = False
        Me.SaveControls()
        Me.Hide()
    End Sub


#End Region


    'runs subroutines when tab index changes by either clicking
    'on another tab or clicking navigation buttons
    Private Sub tabCondensingUnit_SelectedIndexChanged() _
    Handles tabCondensingUnit.SelectedIndexChanged

        previousTab = selectedTab
        selectedTab = tabCondensingUnit.SelectedIndex
        'runs routines on first tab if second tab is clicked after first tab
        If selectedTab = 1 AndAlso _
           previousTab <> 2 Then

            If modelIsSelected() Then

                Dim selections = showBestUnits()
                selectUnit(selections)


            End If

            'runs routine on second tab if third tab is clicked and
            'the second tab's calculations have been ran
        ElseIf selectedTab = 2 And _
               previousTab = 1 Then
            rate()

        ElseIf selectedTab = 2 AndAlso _
               previousTab = 0 Then
            inform("Please review the rating criteria.")
            Me.tabCondensingUnit.SelectedIndex = 0
            Me.tabCondensingUnit.SelectedIndex = 1
        End If
    End Sub

    Private Sub tabCondensingUnit_Selecting(ByVal sender As Object, ByVal e As TabControlCancelEventArgs) _
    Handles tabCondensingUnit.Selecting
        If e.TabPageIndex = 1 Then
            If Not modelIsSelected() Then
                e.Cancel = True
                Ui.MessageBox.Show("A model is not selected. Please select a model.", MessageBoxIcon.Warning)
            End If
        End If
    End Sub


    'sets century units to 'choose' except for the last chosen unit
    '(technical systems only has one combobox)
    Private Sub cboLUI_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles cboLUI.SelectionChangeCommitted, cboLUO.SelectionChangeCommitted, cboDS.SelectionChangeCommitted, cboDD.SelectionChangeCommitted, cboDM.SelectionChangeCommitted, cboNSB.SelectionChangeCommitted, cboBLU_L.SelectionChangeCommitted, cboNDB.SelectionChangeCommitted, cboNSC.SelectionChangeCommitted, cboNDC.SelectionChangeCommitted, cboNMC.SelectionChangeCommitted, cboNMB.SelectionChangeCommitted, cboBLU_L.SelectionChangeCommitted, cboBLU_B.SelectionChangeCommitted
        If Me.panRatingBody.Visible Then
            Dim combo = New ArrayList

            With combo
                'adds comboboxes to array list
                .Add(Me.cboLUO)
                .Add(Me.cboLUI)
                .Add(Me.cboDS)
                .Add(Me.cboDD)
                .Add(Me.cboDM)
                '   .Add(Me.cboRS)
                '  .Add(bSeriesComboBox)
                .Add(Me.cboNSB)
                .Add(Me.cboBLU_L)
                .Add(Me.cboBLU_B)
                .Add(Me.cboNDB)
                .Add(Me.cboNSC)
                .Add(Me.cboNDC)
                .Add(Me.cboNMC)
                .Add(Me.cboNMB)




                'sets all related comboboxes back to 'Choose'
                For i = 0 To .Count - 1
                    If combo(i).Name <> CType(sender, ComboBox).Name Then
                        combo(i).SelectedIndex = 0
                    End If
                Next
            End With

            Dim model As String = sender.SelectedItem.ToString

            If model.ToLower = "choose" Then Exit Sub
            Dim condensing_unit = repository.get_unit(model)
            ' If Not model Like "20A0*" And condensing_unit.temperature_range = "Low" Then
            Dim compressor = compressor_repo.get_compressor(condensing_unit.circuits(0).compressorMasterID, condensing_unit.refrigerant, grab_unit_voltage, "Condenser", condensing_unit.constantReturnGasTemp)


            'If grab_selection_suction() > compressor.suction_max Then _
            '   txtSelectionTabSuction.Text = Average(compressor.suction_max, compressor.suction_min)

            If compressor Is Nothing Then
                MsgBox("Data not found for the default compressor on that model.")
                Exit Sub


            End If

            Dim tSuction As Double = grab_selection_suction()

            If tSuction > compressor.suctionMax OrElse tSuction < compressor.suctionMin Then
                Select Case condensing_unit.temperature_range.ToLower
                    Case "low"
                        txtSelectionTabSuction.Text = "-20"
                    Case "medium"
                        txtSelectionTabSuction.Text = "20"
                    Case "high"
                        txtSelectionTabSuction.Text = "40"
                End Select
            End If

            ' IF OUTSIDE RANGE, USE
            ' -20 FOR LOW
            '20 FOR MEDIUM
            '40 FOR HIGH

            'End If


            Dim series As String = CType(sender, ComboBox).Name.ToUpper.Replace("CBO", "")  ' kind of a wierd way to do it.  sorry.

            fillVoltages(voltages(series))


            Dim li1 As Integer = cboCondensingUnitSeries.FindString(series)
            If li1 >= 0 Then
                cboCondensingUnitSeries.SelectedIndex = li1
            End If


        End If
    End Sub

    Private Sub cbo20s_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles cbo20A0.SelectionChangeCommitted, cbo20A4.SelectionChangeCommitted
        Dim changedCombobox = CType(sender, ComboBox)

        If panRatingBody.Visible Then
            Dim tsiComboboxes = New List(Of ComboBox)
            tsiComboboxes.Add(cbo20A0) : tsiComboboxes.Add(cbo20A4)

            For Each tsiCombobox In tsiComboboxes
                If tsiCombobox.Name <> changedCombobox.Name Then _
                   tsiCombobox.SelectedIndex = 0
            Next
        End If
    End Sub


    Private Function grab_compressor(ByVal compressorComboBox As ComboBox) As CompressorDescription
        If compressorComboBox.SelectedItem Is Nothing Then
            Return Nothing
        Else
            Return CType(compressorComboBox.SelectedItem, CompressorDescription)
        End If
    End Function

    Private Sub fillCompressors(ByVal compressors As List(Of CompressorDescription), ByVal compressorComboBox As ComboBox)
        compressorComboBox.Items.Clear()
        For Each compressor As CompressorDescription In compressors
            compressorComboBox.Items.Add(compressor)
        Next
    End Sub


    Private compressorComboBoxes(3) As ComboBox
    Private chooseCompressor As New CompressorDescription(CHOOSE, CHOOSE, 0)
    Private Const CHOOSE As String = "Choose"



    Private Sub selectDefaultCompressor(ByVal compressorComboBox As ComboBox)
        Dim index As Integer = compressorComboBox.Items.IndexOf(chooseCompressor)
        If index > -1 Then
            compressorComboBox.SelectedIndex = index
        Else
            'Throw New Exception("Compressor cannot be selected. The compressor does not exist, and the choose instruction is missing.")
            compressorComboBox.Items.Insert(0, chooseCompressor)
            selectCompressor(chooseCompressor, compressorComboBox)
        End If
    End Sub

    Private Sub selectCompressor(ByVal compressor As CompressorDescription, ByVal compressor_combobox As ComboBox)
        If compressor Is Nothing Then _
           compressor = chooseCompressor

        For i As Integer = 0 To compressor_combobox.Items.Count - 1
            Dim iterating_compressor = CType(compressor_combobox.Items(i), CompressorDescription)
            If iterating_compressor.Model = compressor.Model Then
                compressor_combobox.SelectedIndex = i
                Exit For
            End If
        Next

        Dim found = (compressor_combobox.SelectedIndex > -1)
        If Not found Then _
           selectDefaultCompressor(compressor_combobox)
    End Sub

    'todo: does compressor selection need to be more specific (voltage for 10 coefficient)
    Private Sub selectCompressorByFile(ByVal file As String, ByVal cbo As ComboBox)
        Dim desc As CompressorDescription
        For i As Integer = 0 To cbo.Items.Count - 1
            desc = CType(cbo.Items(i), CompressorDescription)
            If file.ToUpper = desc.MasterID.ToUpper Then
                cbo.SelectedIndex = i
                Exit For
            ElseIf i = cbo.Items.Count - 1 Then
                selectCompressor(chooseCompressor, cbo)
            End If
        Next
    End Sub

    Private Sub txt_rating_tab_suction_leave() Handles txt_rating_tab_suction.Leave
        updateCompressorListAndTryToReselectPrevious()
    End Sub

    'when refrigerant changes, the list of available compressors changes and if
    'the previous compressor is available in the new list it is re-selected
    Private Sub cboRatingRefrigerant_SelectedIndexChanged() Handles cbo_rating_tab_refrigerant.SelectedIndexChanged
        '        fillModelComboboxes()
        updateCompressorListAndTryToReselectPrevious()
    End Sub

    Private Sub cboVoltage_SelectedIndexChanged() Handles voltageComboBox.SelectedIndexChanged
        updateCompressorListAndTryToReselectPrevious()
    End Sub

    Private Function grab_rating_suction() As Double
        Return ConvertNull.ToDouble(Me.txt_rating_tab_suction.Text)
    End Function

    Private Sub updateCompressorListAndTryToReselectPrevious()

        Dim tempRef As String
        tempRef = cbo_rating_tab_refrigerant.Text
        If String.IsNullOrEmpty(tempRef) AndAlso cbo_rating_tab_refrigerant.SelectedItem IsNot Nothing Then
            tempRef = cbo_rating_tab_refrigerant.SelectedItem.ToString
        End If


        If grab_unit_voltage() <> 0 Then


            Dim descriptions = get_compressors(refrigerant.parse(tempRef), grab_unit_voltage, grab_rating_suction, 0)
            '            Dim descriptions = get_compressors(refrigerant.parse(tempRef), grab_unit_voltage, grab_rating_suction, cu.constantReturnGasTemp)

            Dim previousCompressorSelection As CompressorDescription

            For Each comboBox As ComboBox In compressorComboBoxes
                previousCompressorSelection = grab_compressor(comboBox)
                fillCompressors(descriptions, comboBox)
                selectCompressor(previousCompressorSelection, comboBox)
            Next


        End If


    End Sub

    Private Function get_compressors(ByVal refrigerant As refrigerant, ByVal voltage As Integer, ByVal suction As Double, ByVal constantReturnGasTemp As String) As List(Of CompressorDescription)
        Dim compressors = service.get_compressors(refrigerant, voltage, suction, Me.cboCTLimit.SelectedItem = "Y", constantReturnGasTemp)
        Return transform_compressors_to_descriptions(compressors)
    End Function

    Private Function transform_compressors_to_descriptions(ByVal compressors As List(Of compressor)) As List(Of CompressorDescription)
        Dim descriptions = New List(Of CompressorDescription)

        For Each comp In compressors
            Dim description = New CompressorDescription(comp.model, comp.MasterID, comp.hp)
            descriptions.Add(description)
        Next

        Return descriptions
    End Function

#End Region


#Region " Private Methods"

    Private Function getCapacityDigits(ByVal div As Division) As Integer
        Return If(div = Division.CRI, 0, 1)
    End Function


    Private Function ParseCompressorDescriptionForName(ByVal unparsedCompressorDescription As String) As String
        Return unparsedCompressorDescription.Substring(0, unparsedCompressorDescription.IndexOf(" "))
    End Function


    Private Sub initializeControls()
        compressorComboBoxes(0) = cbo_compressor_1
        compressorComboBoxes(1) = cbo_compressor_2
        compressorComboBoxes(2) = cboCompressor3
        compressorComboBoxes(3) = cboCompressor4

        initializeSaveToolStripPanel()
        fillModelComboboxes()

        Me.cboSelectionTabRefrigerant.DataSource = Me.getRefrigerants(AppInfo.Division)
        Me.cbo_rating_tab_refrigerant.DataSource = Me.getRefrigerants(AppInfo.Division)
        Me.fillFanCombobox(Me.cboFan1) : Me.fillFanCombobox(Me.cboFan2)
        Me.fillFanCombobox(Me.cboFanDiameter3) : Me.fillFanCombobox(Me.cboFanDiameter4)
        fillVoltages(voltages)

        ' prevents dropdownlist control selections from defaulting to Nothing
        numCompressorCoefficientsComboBox.SelectedIndex = 0
        Me.cboRatingAmbientInterval.SelectedIndex = 1
        Me.cboRatingSuctionInterval.SelectedIndex = 4
        Me.cboRatingAmbientSteps.SelectedIndex = 1
        Me.cboRatingSuctionSteps.SelectedIndex = 0
        Me.cboCompressorPerUnit.SelectedIndex = 0
        Me.cboCompressor.SelectedIndex = 0
        Me.cboCircuitsPerUnit.SelectedIndex = 0
        Me.cboRatingSafety.SelectedIndex = 0
        Me.cboRatingHertz.SelectedIndex = 0
        Me.ddlDOEModels.SelectedIndex = 1

        Me.cboCTLimit.SelectedIndex = 0
        Me.cboUSTLimit.SelectedIndex = 0


        If AppInfo.Division = Division.CRI Then
            cbo_rating_tab_refrigerant.SelectedIndex = 0
            cboSelectionTabRefrigerant.SelectedIndex = cboSelectionTabRefrigerant.FindString("R448a")
            Me.cboRatingCatalog.SelectedIndex = 1
        ElseIf AppInfo.Division = Division.TSI Then
            cbo_rating_tab_refrigerant.SelectedIndex = 0
            cboSelectionTabRefrigerant.SelectedIndex = cboSelectionTabRefrigerant.FindString("R410a")
            Me.cboRatingCatalog.SelectedIndex = 0
        Else
            cbo_rating_tab_refrigerant.SelectedIndex = 0
            cboSelectionTabRefrigerant.SelectedIndex = 0
            Me.cboRatingCatalog.SelectedIndex = 0
        End If


        If cbo_rating_tab_refrigerant.SelectedItem IsNot Nothing Then cbo_rating_tab_refrigerant.Text = cbo_rating_tab_refrigerant.SelectedItem.ToString
        If cboSelectionTabRefrigerant.SelectedItem IsNot Nothing Then cboSelectionTabRefrigerant.Text = cboSelectionTabRefrigerant.SelectedItem.ToString


        ' sets division specific controls
        Me.setDivisionSpecificControls()

        If Trim(Me.cboCondensingUnitSeries.Text) < " " Then Me.cboCondensingUnitSeries.SelectedIndex = 0

        If Me.IsParentBalanceProgram Then
            Me.initializeForBalanceProgram()
        End If
    End Sub


    Private Sub fillVoltages(ByVal voltages As List(Of Integer))

        Dim currentVoltage As String = voltageComboBox.Text


        voltageComboBox.Items.Clear()
        voltageRatingComboBox.Items.Clear()


        For Each voltage As Integer In voltages
            voltageComboBox.Items.Add(voltage)
            voltageRatingComboBox.Items.Add(voltage)
        Next


        If Not String.IsNullOrEmpty(currentVoltage) AndAlso voltageComboBox.FindString(currentVoltage) >= 0 Then
            voltageComboBox.Text = currentVoltage
            voltageRatingComboBox.Text = currentVoltage
        Else
            If AppInfo.Division = Division.TSI Then
                voltageComboBox.SelectedIndex = 1
                voltageRatingComboBox.SelectedIndex = 1
            Else
                voltageComboBox.SelectedIndex = 1
                voltageRatingComboBox.SelectedIndex = 1
            End If
        End If





    End Sub


    Private Sub fillModelComboboxes()

        Dim refrigerant As String

        Dim DOEFlag As String = ddlDOEModels.Text


        If cboSelectionTabRefrigerant.SelectedIndex >= 0 Then
            refrigerant = cboSelectionTabRefrigerant.Items(cboSelectionTabRefrigerant.SelectedIndex).ToString
        Else
            refrigerant = ""
        End If


        If Not user.is_rep Then
            LoadModelDropdown("LUO", refrigerant, cboLUO, lblLUO, True, DOEFlag)
            LoadModelDropdown("LUI", refrigerant, cboLUI, lblLUI, True, DOEFlag)
            LoadModelDropdown("DS", refrigerant, cboDS, lblDS, True, DOEFlag)
            LoadModelDropdown("DD", refrigerant, cboDD, lblDD, True, DOEFlag)
        Else
            cboDS.Visible = False
            cboDM.Visible = False
            cboLUI.Visible = False
            cboLUO.Visible = False
            lblDS.Visible = False
            lblDM.Visible = False
            lblLUI.Visible = False
            lblLUO.Visible = False
        End If



        LoadModelDropdown("DM", refrigerant, cboDM, lblDM, True, DOEFlag)


        If user.is_rep Then
            LoadModelDropdown("20A0LS", refrigerant, cbo20A0, lbl20a0, True, DOEFlag)
            LoadModelDropdown("20A0LD", refrigerant, cbo20A0, lbl20a0, False, DOEFlag)
        Else
            LoadModelDropdown("20A0", refrigerant, cbo20A0, lbl20a0, True, DOEFlag)

        End If


        LoadModelDropdown("20A4", refrigerant, cbo20A4, lbl20A4, True, DOEFlag)
        LoadModelDropdown("NSB", refrigerant, cboNSB, lblNSB, True, DOEFlag)
        LoadModelDropdown("NDB", refrigerant, cboNDB, lblNDB, True, DOEFlag)
        LoadModelDropdown("NSC", refrigerant, cboNSC, lblNSC, True, DOEFlag)
        LoadModelDropdown("NDC", refrigerant, cboNDC, lblNDC, True, DOEFlag)
        LoadModelDropdown("BLU-L", refrigerant, cboBLU_L, lblBLU_L, True, DOEFlag)
        LoadModelDropdown("BLU-B", refrigerant, cboBLU_B, lblBLU_B, True, DOEFlag)


        '  LoadModelDropdown("C-RL1C", refrigerant, cboRAPTOR, lblRAPTOR)   ' raptor


        ' blargg - hide nmb and nmc
        LoadModelDropdown("NMC", refrigerant, cboNMC, lblNMC, True, DOEFlag)
        LoadModelDropdown("NMB", refrigerant, cboNMB, lblNMB, True, DOEFlag)





    End Sub


    Private Sub LoadModelDropdown(ByVal model As String, ByVal refrigerant As String, ByVal cboX As ComboBox, ByVal lblX As Label, ByVal clearList As Boolean, DOEFlag As String)
        If clearList Then
            cboX.Items.Clear()
            cboX.Items.Add("Choose")
            cboX.SelectedIndex = 0
        End If

        Dim models = repository.get_models(model, refrigerant, DOEFlag)
        cboX.Items.AddRange(models.ToArray())


        If cboX.Items.Count <= 1 Then
            lblX.Font = New Font(cboX.Font, FontStyle.Strikeout)
        Else
            lblX.Font = New Font(cboX.Font, FontStyle.Regular)
        End If

    End Sub


    Private Sub initializeForBalanceProgram()
        Me.btnReturn.Visible = True
        Me.IsCanceled = True
    End Sub


#Region " Run"

    Private Function showBestUnits() As Best_Matches
        showPanelForRatingOrSelection()

        Dim spec = grabSpec()




        Dim conditions = grabBestConditions()
        Dim units = New Best_Matches()


        ' possibly pass this on election

        If rbo_unit_selection.Checked Then

            units.given(spec, at:=conditions, CondTempOverride:=False)
        End If

        Dim input = grabInput()
        BestSelectionsGrid1.SetSource(units, input)

        setSelectionRadioButtons(units)

        ' spec.series

        Return units
    End Function

    Private Sub showPanelForRatingOrSelection()

        If Me.rbo_unit_selection.Checked = True Then
            'shows selection section
            Me.panSelectCondensingUnit.Visible = True
            Me.panOutputsBody.Visible = True
            ''Me.outputsHeader.Visible = True
            'sometimes panels get out of order, so force order
            ''Me.outputsHeader.BringToFront()
            Me.panOutputsBody.BringToFront()
            Me.panSelectCondensingUnit.BringToFront()
            'hides irrelevant controls (rating section)
            ''Me.ratingModelHeader.Visible = False
            Me.panRatingBody.Visible = False
            Me.panRatingBodyTSI.Visible = False
            'shows controls for Rating (not selection) and CRI
        ElseIf Me.radUnitRating.Checked = True And AppInfo.Division = Division.CRI Then
            'hides irrelevant controls
            Me.panOutputsBody.Visible = False
            ''Me.outputsHeader.Visible = False
            Me.panSelectCondensingUnit.Visible = False
            Me.panRatingBodyTSI.Visible = False
            'shows rating section for CRI
            Me.panRatingBody.Visible = True
            ''Me.ratingModelHeader.Visible = True
            'shows controls for Rating and TSI
        ElseIf Me.radUnitRating.Checked = True And AppInfo.Division = Division.TSI Then
            'hides irrelevant controls
            Me.panRatingBody.Visible = False
            Me.panOutputsBody.Visible = False
            ''Me.outputsHeader.Visible = False
            Me.panSelectCondensingUnit.Visible = False
            'shows rating section for TSI
            Me.panRatingBodyTSI.Visible = True
            ''Me.ratingModelHeader.Visible = True
        End If
    End Sub


#Region " 10 Coefficients"

    Private Function voltages(Optional ByVal series As String = "") As List(Of Integer)
        Dim voltages_ As New List(Of Integer)
        ' TODO: Dim voltages = CompressorDataAccess.RetrieveUniqueVoltagesFor10Coefficients()
        With voltages_
            .Add(230)
            .Add(460)

            If series.ToUpper = "NSB" OrElse series.ToUpper = "NSC" OrElse series.ToUpper = "NDB" OrElse series.ToUpper = "NDC" OrElse series.ToUpper = "DM" OrElse series.ToUpper = "NSF" OrElse series.ToUpper = "NDF" Then

                .Add(575)
            End If


        End With

        Return voltages_
    End Function

#End Region


    Private Sub authorizeForCoolstuff()
        If user.authority_group = user_group.rep Then
            grpBoxLoad.Visible = False
        Else

            Try
                If OpenedProject.Manager.Project.id.Id > "" Then
                    grpBoxLoad.Visible = True
                End If
            Catch ex As Exception
                grpBoxLoad.Visible = False
            End Try
        End If
    End Sub

    Private Sub setSelectionRadioButtons(ByVal units As Best_Matches)
        Dim condensingUnitCapacity(2) As Single

        'sets capacity units (BTUH or Tons)
        Dim capacityUnits = lblSelectionTabCapacityUnits.Text

        'sets condensing unit capacities
        ' using global variable instead of dll b/c it's set to 0 if compressor isn't safe
        If units.closest IsNot Nothing Then _
           condensingUnitCapacity(0) = units.closest.balance_point.capacity
        If units.above IsNot Nothing Then _
           condensingUnitCapacity(1) = units.above.balance_point.capacity
        If units.below IsNot Nothing Then _
           condensingUnitCapacity(2) = units.below.balance_point.capacity ' Me.gCondensingUnitCapacity(2)   'Round(.RAE_Out_TXT_Q3, 2)

        Dim shown1, shown2, shown3 As Boolean
        'radio button 1
        If units.closest IsNot Nothing Then
            rbo_condensing_unit_1.Visible = True
            rbo_condensing_unit_1.Text = _
               "Custom rate " & units.closest.unit.model & _
               " unit est. capacity = " & Round(units.closest.balance_point.capacity, 1) & " " & capacityUnits
            shown1 = True
        Else
            Me.rbo_condensing_unit_1.Visible = False
        End If

        'radio button 2
        If units.above IsNot Nothing Then
            rbo_condensing_unit_2.Visible = True
            rbo_condensing_unit_2.Text = _
               "Custom rate " & units.above.unit.model & _
               " unit est. capacity = " & Round(units.above.balance_point.capacity, 1) & " " & capacityUnits
            shown2 = True
        Else
            rbo_condensing_unit_2.Visible = False
        End If

        'radio button 3
        If units.below IsNot Nothing Then
            rbo_condensing_unit_3.Visible = True
            rbo_condensing_unit_3.Text = _
               "Custom rate " & units.below.unit.model & _
               " unit est. capacity = " & Round(units.below.balance_point.capacity, 1) & " " & capacityUnits
            shown3 = True
        Else
            Me.rbo_condensing_unit_3.Visible = False
        End If

        If Not shown1 And Not shown2 And Not shown3 Then
            Me.lblNoCondensingUnits.Visible = True
        Else
            Me.lblNoCondensingUnits.Visible = False
        End If



        If (Not shown1) AndAlso shown2 Then rbo_condensing_unit_2.Checked = True
        If (Not shown1) AndAlso shown3 Then rbo_condensing_unit_3.Checked = True
        If shown1 AndAlso (Not shown2 AndAlso Not shown3) Then rbo_condensing_unit_1.Checked = True ' only closest
        If shown2 AndAlso (Not shown1 AndAlso Not shown3) Then rbo_condensing_unit_2.Checked = True ' only above
        If shown3 AndAlso (Not shown1 AndAlso Not shown2) Then rbo_condensing_unit_3.Checked = True ' only below



    End Sub

#End Region


#Region " Select"

    Private Sub initControlsForSelection()
        If user.is_rep Then
            panRatingHideFromRep.Visible = False
            panRatingCircuitBody.Visible = False
        End If








        If AppInfo.Division = Division.TSI Then _
           lblRatingCapacity.Text = "Total Est. Capacity [Tons]"

        'hides capacity if rating, shows if selection
        lblRatingCapacity.Visible = rbo_unit_selection.Checked
        lblRatingCapacityValue.Visible = rbo_unit_selection.Checked
    End Sub

    Private Sub selectUnit(ByVal selections As Best_Matches)
        Dim model = grab_condensing_unit_model()
        'todo: should this check be before this method is called
        If model = "" Then
            tabCondensingUnit.SelectedIndex = 0
            warn("Please select a condensing unit.")
            Exit Sub
        End If
        ' todo: shouldn't have to get condensing unit from db twice before navigating to second tab
        Dim cu = repository.get_unit(model)


        If model.ToUpper.StartsWith("LU") Then
            cboRatingSubCooling.Enabled = False
        Else
            cboRatingSubCooling.Enabled = True
        End If


        initControlsForSelection()

        copySelectionTabValuesToRatingTab(selections)

        ControlAssistant.SelectComboboxItem(cboSelectionTabRefrigerant, cu.refrigerant.value)
        ControlAssistant.SelectComboboxItem(cbo_rating_tab_refrigerant, cu.refrigerant.value)

        If cboSelectionTabRefrigerant.SelectedItem IsNot Nothing Then cboSelectionTabRefrigerant.Text = cboSelectionTabRefrigerant.SelectedItem.ToString
        If cbo_rating_tab_refrigerant.SelectedItem IsNot Nothing Then cbo_rating_tab_refrigerant.Text = cbo_rating_tab_refrigerant.SelectedItem.ToString


        lblRatingCondensingUnitModelValue.Text = model
        txt_custom_model.Text = model






        ' TODO: only checks subcooling on circuit 1, is sub cooling ever on circuit 1 but not circuit 2
        If cu.circuits(0).subcooling Then
            cboRatingSubCooling.SelectedIndex = 1
        Else
            cboRatingSubCooling.SelectedIndex = 0
        End If

        If rbo_unit_selection.Checked Then
            Dim selected_point As Balance.Balance_Point
            If rbo_condensing_unit_1.Checked Then
                selected_point = selections.closest.balance_point
            ElseIf rbo_condensing_unit_2.Checked Then
                selected_point = selections.above.balance_point
            ElseIf rbo_condensing_unit_3.Checked Then
                selected_point = selections.below.balance_point
            End If

            Dim subcooling_temperature = cu.subcooling_temperature(selected_point.td, AppInfo.Division)
            txt_subcooling_temperature.Text = Round(subcooling_temperature)
        Else
            Dim is_low_temp = (cu.temperature_range = "Low")
            Dim subcooling = choose_subcooling(AppInfo.Division, is_low_temp)


            txt_subcooling_temperature.Text = subcooling

        End If

        setCircuits(cu)
        Me.cu = cu


        CheckForVariSpeedFan()

        'allows final tab to be selected

        Dim doeFlag As Boolean = New condensing_units.Repository().CheckDOE(model)

        If doeFlag Then
            txtDOECompliant.Text = "Yes"
        Else
            txtDOECompliant.Text = "No"
        End If

        Me.IsUnitRated = True
    End Sub

    Private cu As Condensing_Unit

    Private Function choose_subcooling(ByVal div As Division, ByVal isLowTemp As Boolean) As Double
        Dim subCooling As Double

        If div = Division.TSI Then
            subCooling = 15
        ElseIf div = Division.CRI Then
            If isLowTemp Then
                subCooling = 5
            Else
                subCooling = 10
            End If
        End If

        Return subCooling
    End Function

    'todo: move out of ui layer, duplicated in balance
    'Private Function calcSubCooling(condensingTemp As Double, ambientTemp As Double) As Double
    '   Return 0.6187 * (condensingTemp - ambientTemp) + 0.5753
    'End Function

    Private Function grab_condensing_unit_model() As String
        Dim model = String.Empty
        Dim warning = "Please select a condensing unit model before continuing to the 'Rating' tab."

        If rbo_unit_selection.Checked Then ' selection
            If BestSelectionsGrid1.dataGridView.DataSource Is Nothing Then
                model = ""
            ElseIf rbo_condensing_unit_1.Checked Then
                ''model = BestSelectionsGrid1.dataGridView.Columns("Closest").CellText(0)
                model = BestSelectionsGrid1.dataGridView.Rows(0).Cells(1).Value.ToString()
                'model = BestSelectionsGrid1.grid.Columns(1).CellText(0)
            ElseIf rbo_condensing_unit_2.Checked Then
                ''model = BestSelectionsGrid1.dataGridView.Columns("Above").CellText(0)
                model = BestSelectionsGrid1.dataGridView.Rows(0).Cells(2).Value.ToString()
                'model = BestSelectionsGrid1.grid.Columns(2).CellText(0)
            ElseIf rbo_condensing_unit_3.Checked Then
                ''model = BestSelectionsGrid1.dataGridView.Columns("Below").CellText(0)
                model = BestSelectionsGrid1.dataGridView.Rows(0).Cells(3).Value.ToString()
                ' model = BestSelectionsGrid1.grid.Columns(3).CellText(0)
            End If
        ElseIf radUnitRating.Checked _
        And AppInfo.Division = Division.CRI Then ' century rating
            If cboLUI.SelectedItem <> "Choose" Then
                model = cboLUI.SelectedItem
            ElseIf cboLUO.SelectedItem <> "Choose" Then
                model = cboLUO.SelectedItem
            ElseIf cboDD.SelectedItem <> "Choose" Then
                model = cboDD.SelectedItem
            ElseIf cboDS.SelectedItem <> "Choose" Then
                model = cboDS.SelectedItem
            ElseIf cboDM.SelectedItem <> "Choose" Then
                model = cboDM.SelectedItem
                'ElseIf cboRS.SelectedItem <> "Choose" Then
                '    model = cboRS.SelectedItem
                'ElseIf bSeriesComboBox.SelectedItem <> "Choose" Then
                '    model = bSeriesComboBox.SelectedItem
            ElseIf cboNSB.SelectedItem <> "Choose" Then
                model = cboNSB.SelectedItem
            ElseIf cboNDB.SelectedItem <> "Choose" Then
                model = cboNDB.SelectedItem
            ElseIf cboNSC.SelectedItem <> "Choose" Then
                model = cboNSC.SelectedItem
            ElseIf cboNDC.SelectedItem <> "Choose" Then
                model = cboNDC.SelectedItem
            ElseIf cboBLU_L.SelectedItem <> "Choose" Then
                model = cboBLU_L.SelectedItem
            ElseIf cboBLU_B.SelectedItem <> "Choose" Then
                model = cboBLU_B.SelectedItem
                'ElseIf cboRAPTOR.SelectedItem <> "Choose" Then
                '    model = cboRAPTOR.SelectedItem
                ' blargg - hide NMB and NMC
            ElseIf cboNMC.SelectedItem <> "Choose" Then
                model = cboNMC.SelectedItem
            ElseIf cboNMB.SelectedItem <> "Choose" Then
                model = cboNMB.SelectedItem
            End If

        ElseIf radUnitRating.Checked _
        And AppInfo.Division = Division.TSI Then  ' technical system rating
            If cbo20A0.SelectedItem <> "Choose" Then
                model = cbo20A0.SelectedItem
            ElseIf cbo20A4.SelectedItem <> "Choose" Then
                model = cbo20A4.SelectedItem
            End If
        End If

        Return model
    End Function

    Private Function openBoxLoad()
        'Read the current CoolStuff Data if it exists and override the appropriate user inputs
        'Excluded for release purposes
        Dim linkedItemId As String = Me.Tag
        Dim linkedItemRevision As Single = 0.0!  ' as it was
        Dim da As New Rae.Data.Access.BoxLoadProjects()
        Dim dbId As nullable_value(Of Integer)
        dbId = da.RetrieveDbId(linkedItemId, linkedItemRevision)
        btnCoolStuffInvoke.Tag = dbId.value_or_default(0)
        'btnCoolStuffInvoke.Tag = CoolStuff.cl_connection.GetProjectRecordNumber(Me.Tag, 0, "UI")
        If Me.Tag IsNot Nothing And Me.btnCoolStuffInvoke.Tag IsNot Nothing _
        AndAlso Me.btnCoolStuffInvoke.Tag > 0 Then
            Dim d As Rae.Data.Access.OverrideData
            d = da.RetrieveLinkData(linkedItemId, linkedItemRevision)

            'Dim c As New CoolStuff.CoolStuffCommon, 
            'c.CallingForm = Me
            'c.GetOverridesFromDb()
            Dim capacity As Single

            capacity = d.LoadTot
            If d.UserCapacityChecked Then
                capacity = d.UserCapacity
            ElseIf AppInfo.Division = Division.TSI Then
                capacity = Round(Rae.Convert.BtuhToTons(capacity), 2)
            End If
            setControlsForBoxLoad(capacity, d.RunTime, d.Ambient, d.BlName)
            btnCoolStuffInvoke.Visible = False
            btnRemoveBoxLoadLink.Visible = True
        End If
    End Function

    Private Sub copySelectionTabValuesToRatingTab(ByVal selections As Best_Matches)
        txtRatingTabAmbient.Text = txtSelectionTabAmbient.Text
        txt_rating_tab_suction.Text = txtSelectionTabSuction.Text
        txtRatingTabAltitude.Text = txtSelectionTabAltitude.Text

        If rbo_unit_selection.Checked Then
            Dim capacity As Double
            If rbo_condensing_unit_1.Checked Then
                capacity = selections.closest.balance_point.capacity
            ElseIf rbo_condensing_unit_2.Checked Then
                capacity = selections.above.balance_point.capacity
            ElseIf rbo_condensing_unit_3.Checked Then
                capacity = selections.below.balance_point.capacity
            End If
            lblRatingCapacityValue.Text = Round(capacity, capacityDigits)
        End If
    End Sub

    Private Function grab_selection_suction() As Double
        Dim suction As String = ""
        If IsNullOrEmpty(txt_rating_tab_suction.Text) Then
            suction = txtSelectionTabSuction.Text
        Else
            suction = txt_rating_tab_suction.Text
        End If

        Return ConvertNull.ToDouble(suction)
    End Function

    Private Sub setCircuits(ByVal cu As Condensing_Unit)
        Dim altitude = grab_altitude()

        Dim compressors = get_compressors(cu.refrigerant, grab_unit_voltage, grab_selection_suction, cu.constantReturnGasTemp)
        compressors.Insert(0, chooseCompressor)

        'todo: encapsulate circuit controls into user control
        'For j As Integer = 0 To cu.Circuits.Count - 1
        '   ctrl.Circuits(j).Source = cu.Circuits(j)
        'Next

        With cu.circuits(0)

            cbo_compressor_quantity_1.SelectedIndex = cbo_compressor_quantity_1.Items.IndexOf(.compressor_quantity.ToString)
            fillCompressors(compressors, cbo_compressor_1)

            selectCompressorByFile(.compressorMasterID, cbo_compressor_1)
            lblCoilsRequiredValue1.Text = .coil.Quantity
            cbo_fpi_1.SelectedIndex = cbo_fpi_1.Items.IndexOf(.coil.FPI.ToString)


            loadCondenserCoilDropdown(coilComboBox_1, .coil.RowsDeep.ToString, .coil.TubeDiameter)
            '            loadCondenserCoilDropdown(coilComboBox_1, .coil.RowsDeep.ToString, .coil.TubeSurface, .coil.TubeDiameter, .coil.FinSurface)

            'cbo_rows_1.SelectedIndex = cbo_rows_1.Items.IndexOf(.coil.rows.ToString)  'eccond




            txt_fin_height_1.Text = .coil.FinHeight
            txt_fin_length_1.Text = .coil.FinLength
            cbo_fan_quantity_1.SelectedIndex = cbo_fan_quantity_1.Items.IndexOf(.fan_quantity.ToString)
            fillFanCombobox(cboFan1)

            selectFanForCombobox(1, .fanID, .hp, altitude)
            txtCoilSubCoolingPercentage1.Text = .subcooling
        End With

        If cu.circuits.Count > 1 Then
            With cu.circuits(1)
                'adds Circuit 2 tab page if it's not already apart of the tab control
                If tabCircuits.TabPages.Contains(tabCircuit2) = False Then
                    tabCircuits.Controls.Add(tabCircuit2)
                    tabCircuit1.Focus()
                End If

                cbo_compressor_quantity_2.SelectedIndex = cbo_compressor_quantity_2.Items.IndexOf(.compressor_quantity.ToString)
                fillCompressors(compressors, cbo_compressor_2)
                selectCompressorByFile(.compressorMasterID, cbo_compressor_2)

                lblCoilsRequiredValue2.Text = .coil.Quantity
                cbo_fpi_2.SelectedIndex = cbo_fpi_1.Items.IndexOf(.coil.FPI.ToString)

                ' loadCondenserCoilDropdown(coilComboBox_2, .coil.RowsDeep.ToString, .coil.TubeSurface, .coil.TubeDiameter, .coil.FinSurface)
                loadCondenserCoilDropdown(coilComboBox_2, .coil.RowsDeep.ToString, .coil.TubeDiameter)
                '  coilComboBox_2.SelectedIndex = coilComboBox_1.Items.IndexOf(coilComboBox_1.SelectedItem.ToString)  'eccond





                txt_fin_height_2.Text = .coil.FinHeight
                txt_fin_length_2.Text = .coil.FinLength
                cbo_fan_quantity_2.SelectedIndex = cbo_fan_quantity_2.Items.IndexOf(.fan_quantity.ToString)
                fillFanCombobox(cboFan2)

                selectFanForCombobox(2, .fanID, .hp, altitude)
                txtCoilSubCoolingPercentage2.Text = .subcooling
            End With
        Else
            'removes Circuit 2 tab page if it is already apart of the tab control
            If tabCircuits.TabPages.Contains(tabCircuit2) Then _
               tabCircuits.Controls.Remove(tabCircuit2)
        End If

        If tabCircuits.TabPages.Contains(tabCircuit3) Then _
           tabCircuits.Controls.Remove(tabCircuit3)

        If tabCircuits.TabPages.Contains(tabCircuit4) Then _
           tabCircuits.Controls.Remove(tabCircuit4)

        tabCircuits.SelectedIndex = 0
    End Sub

#End Region


#Region " Rate Unit"

    Private Function rate() As CondensingUnitRatingDataSet.ResultsDataTable
        Dim cu = grabCondensingUnit(Me.cu)
        '     blarg()
        Dim astep = Val(cboRatingAmbientInterval.SelectedItem)
        Dim asteps = cboRatingAmbientSteps.SelectedItem
        Dim sstep = cboRatingSuctionInterval.SelectedItem

        Dim conditions = grabBalanceConditions(astep, cu.number_of_circuits)

        Dim results As Balance.Results
        Try
            Dim balance = New Balance(compressor_repo)
            results = balance.this(cu, conditions, astep, asteps, sstep, True, cu.constantReturnGasTemp)
        Catch ex As Exception
            ' todo: handle exception more specifically
            warn("The balance is unable to complete. " & ex.Message)
            Dim tbl = New CondensingUnitRatingDataSet.ResultsDataTable()
            ''dgrC1Results.DataSource = tbl
            Grid1.DataSource = tbl
            With Grid1
                .Columns("AmbientTemperature").HeaderCell.Value = "Ambient Temp."
                .Columns("EvaporatorTemperature").HeaderCell.Value = "Suction Temp."
                .Columns("CondenserTemperature").HeaderCell.Value = "Condenser Temp."
                .Columns("Capacity").HeaderCell.Value = "Est. Capacity"
                .Columns("UnitPower").HeaderCell.Value = "Unit KW"
                .Columns("UnitEfficiency").HeaderCell.Value = "Unit EER"
                .Columns("UnitCurrent").HeaderCell.Value = "Unit Amps"
                .Columns("CondenserCapacity").HeaderCell.Value = "Condenser Est. Capacity"
                .Columns("CondenserTemperatureDifference").HeaderCell.Value = "Condenser T.D."
                .RowHeadersVisible = False
                .Columns("CondenserCapacity").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            Return tbl
        End Try
        'todo: get when condensing unit is got
        Dim compressor = compressor_repo.get_compressor(cu.circuits(0).compressorMasterID, cu.refrigerant, conditions.voltage, "Condenser", cu.constantReturnGasTemp)
        Dim validResults = New Balance.Results()







        For Each result In results
            Dim head_pressure_will_not_trip_sensor = New refrigerant_head_pressure_will_not_trip_sensor(cu.refrigerant, result.point.condensing_temp)


            If (compressor.is_within_safety_limits(result.conditions.suction, result.point.condensing_temp) OrElse Me.cboRatingSafety.SelectedItem = "Y") AndAlso (head_pressure_will_not_trip_sensor.validate().is_valid OrElse Me.cboCTLimit.SelectedItem = "Y") AndAlso (cu.SuctionIsInUnitLimits(result.conditions.suction) OrElse Me.cboUSTLimit.SelectedItem = "Y") Then
                validResults.add(result)
            End If





        Next

        Dim ambient = grab_ambient()
        Dim suction As Double = txt_rating_tab_suction.Text
        Dim condensing_temperature = findCondensingTempAtConditionsOfService(results, ambient, suction)
        Dim td = condensing_temperature - ambient


        'If AppInfo.Division = Division.CRI Then

        Dim subcooling_temperature = cu.subcooling_temperature(td, AppInfo.Division)  ' ERICC
        txt_subcooling_temperature.Text = Round(subcooling_temperature)

        ' End If


        Dim safetyOverrideIsNotOn = (cboRatingSafety.SelectedItem = "N")
        Dim someResultsAreOutOfRange = validResults.Count < results.Count

        Dim showSomeResultsOmittedNote = (someResultsAreOutOfRange And safetyOverrideIsNotOn)
        lblResultsOmit.Visible = showSomeResultsOmittedNote

        Dim table = format(validResults)

        ''dgrC1Results.DataSource = table
        Grid1.DataSource = table
        With Grid1
            .Columns("AmbientTemperature").HeaderCell.Value = "Ambient Temp."
            .Columns("EvaporatorTemperature").HeaderCell.Value = "Suction Temp."
            .Columns("CondenserTemperature").HeaderCell.Value = "Condenser Temp."
            .Columns("Capacity").HeaderCell.Value = "Est. Capacity"
            .Columns("UnitPower").HeaderCell.Value = "Unit KW"
            .Columns("UnitEfficiency").HeaderCell.Value = "Unit EER"
            .Columns("UnitCurrent").HeaderCell.Value = "Unit Amps"
            .Columns("CondenserCapacity").HeaderCell.Value = "Condenser Est. Capacity"
            .Columns("CondenserTemperatureDifference").HeaderCell.Value = "Condenser T.D."
            .RowHeadersVisible = False

            ''    .Item("EvaporatorTemperature").Caption = "Suction Temp."
            ''    .Item("AmbientTemperature").Caption = "Ambient Temp."
            ''    .Item("CondenserTemperature").Caption = "Condenser Temp."
            ''    .Item("Capacity").Caption = "Est. Capacity"
            ''    .Item("UnitPower").Caption = "Unit KW"
            ''    .Item("CondenserCapacity").Caption = "Condenser Est. Capacity"
            ''    .Item("CondenserTemperatureDifference").Caption = "Condenser T.D."
            ''    .Item("UnitCurrent").Caption = "Unit Amps"
            ''    .Item("UnitEfficiency").Caption = "Unit EER"
        End With

        formatResultsDatagrid()

        If validResults.Count > 0 Then _
           setControlsOnResultsTab(validResults(0).point.coil_capacity)

        Return table
    End Function

    Private Function findCondensingTempAtConditionsOfService( _
       ByVal results As Balance.Results, ByVal ambient As Double, ByVal suction As Double _
    ) As Double
        Dim condensingTemp As Double = Nothing

        For Each result In results
            If Round(result.conditions.ambient, 0) = Round(ambient, 0) And Round(result.conditions.suction, 0) = Round(suction, 0) Then _
               condensingTemp = result.point.condensing_temp
        Next




        'For Each result In results
        '    If Round(result.conditions.ambient, 0) = Round(ambient, 0) And Round(result.conditions.suction, 0) = Round(suction, 0) Then _
        '       condensingTemp = result.point.condensing_temp
        'Next

        If condensingTemp = Nothing Then
            MsgBox("An error has occurred while calculating subcooling.")

        End If


        Return condensingTemp
    End Function


    Private Function getCoils() As List(Of Rae.RaeSolutions.Business.Entities.Coil)
        ' retrieves coil data

        Dim coilsData As List(Of condensers.condenser_repository.CoilTransferData)

        If AppInfo.User.authority_group = user_group.rep Then
            coilsData = condensers.condenser_repository.RetrieveRepCoils(True)
        ElseIf AppInfo.User.authority_group = user_group.employee Then
            coilsData = condensers.condenser_repository.RetrieveEmployeeCoils(True)
        Else
            Throw New ApplicationException("Condenser coil authorization is not valid.")
        End If

        ' populates coil object
        '
        Dim coil As Rae.RaeSolutions.Business.Entities.Coil
        Dim coils As New List(Of Rae.RaeSolutions.Business.Entities.Coil)()
        For Each coilData As condensers.condenser_repository.CoilTransferData In coilsData
            Dim application As Rae.RaeSolutions.Business.Entities.Coil.CoilType : GetEnumValue(Of Rae.RaeSolutions.Business.Entities.Coil.CoilType)(coilData.CoilType, application)
            Dim finDesign As Rae.RaeSolutions.Business.Entities.Coil.FinType : GetEnumValue(Of Rae.RaeSolutions.Business.Entities.Coil.FinType)(coilData.FinType, finDesign)
            coil = New Rae.RaeSolutions.Business.Entities.Coil(coilData.Diameter, coilData.NumRows, coilData.FileName, application, finDesign, coilData.TubeSurface)
            coils.Add(coil)
        Next

        Return coils
    End Function



    Private Sub fillCoilCombobox()
        Dim coils1 As List(Of Rae.RaeSolutions.Business.Entities.Coil) = getCoils()

        Me.coilComboBox_1.DataSource = coils1


        Dim coils2 As List(Of Rae.RaeSolutions.Business.Entities.Coil) = getCoils()

        Me.coilComboBox_2.DataSource = coils2

    End Sub


    Private Function format(ByVal results As Balance.Results) As CondensingUnitRatingDataSet.ResultsDataTable
        Dim table = New CondensingUnitRatingDataSet.ResultsDataTable
        Dim digits = If(AppInfo.Division = Division.TSI, 1, 0)

        DemandCoolingNote = False

        For Each result In results
            Dim row = table.NewResultsRow
            row.AmbientTemperature = result.conditions.ambient
            row.EvaporatorTemperature = result.conditions.suction

            If result.RequiresDemandCooling Then
                row.CondenserTemperature = Round(result.point.condensing_temp, 1) & "*"
                DemandCoolingNote = True
            Else
                row.CondenserTemperature = Round(result.point.condensing_temp, 1)
            End If



            row.CondenserTemperatureDifference = Round(result.point.td, 1)
            row.Capacity = Round(result.point.capacity, digits)
            row.CondenserCapacity = Round(result.point.condenser_capacity, digits)
            row.UnitCurrent = Round(result.point.unit_amps)
            row.UnitEfficiency = Round(result.point.unit_eer, 1)
            row.UnitPower = Round(result.point.unit_kw, 1)
            table.Rows.Add(row)
        Next

        Return table
    End Function

    Private Function grabBalanceConditions(ByVal astep As Double, ByVal numberOfCircuits As Integer) As Balance.Conditions
        Dim a As Double
        If IsNullOrEmpty(txtRatingTabAmbient.Text) Then
            If IsNullOrEmpty(txtSelectionTabAmbient.Text) Then
                a = 0
                txtRatingTabAmbient.Text = "0"
                txtSelectionTabAmbient.Text = "0"
            Else
                a = CDbl(txtSelectionTabAmbient.Text)
                txtRatingTabAmbient.Text = txtSelectionTabAmbient.Text
            End If
        Else
            a = CDbl(txtRatingTabAmbient.Text)
        End If

        Dim suction As String = txt_rating_tab_suction.Text
        If IsNullOrEmpty(suction) Then
            If IsNullOrEmpty(txtSelectionTabSuction.Text) Then
                suction = 0
                txt_rating_tab_suction.Text = "0"
                txtSelectionTabSuction.Text = "0"
            Else
                suction = txtSelectionTabSuction.Text
                txt_rating_tab_suction.Text = txtSelectionTabSuction.Text
            End If
        End If

        Dim altitude As String = txtRatingTabAltitude.Text
        If IsNullOrEmpty(altitude) Then
            altitude = txtSelectionTabAltitude.Text
            If IsNullOrEmpty(altitude) Then
                altitude = 0
                txtSelectionTabAltitude.Text = 0
                txtRatingTabAltitude.Text = 0
            End If
        End If


        Dim conditions As Balance.Conditions
        conditions.altitude = CDbl(altitude)
        ' todo: should this be in balance
        conditions.ambient = If(a >= 115 - astep, a, a + astep)
        conditions.suction = suction
        conditions.catalog_rating = If(cboRatingCatalog.SelectedItem = "Catalog", True, False)
        conditions.hertz = If(cboRatingHertz.SelectedItem = "50 HZ", 50, 60)
        conditions.voltage = grab_unit_voltage()
        ' conditions.fanOperatingRPM = fanOperatingRPM

        If CType(cboFan1.SelectedItem, Fan).FileName.ToUpper = "CUSTOM" Then
            conditions.fan_file_name_1 = "OVERRIDE" & txtCustomCFM1.Text
            conditions.hp_1 = txtCustomPower1.Text
        Else
            conditions.fan_file_name_1 = CType(cboFan1.SelectedItem, Fan).FileName
            conditions.hp_1 = CType(cboFan1.SelectedItem, Fan).Hp
        End If




        If numberOfCircuits > 1 Then




            If CType(cboFan1.SelectedItem, Fan).FileName.ToUpper = "CUSTOM" Then
                conditions.fan_file_name_2 = "OVERRIDE" & txtCustomCFM2.Text
                conditions.hp_2 = txtCustomPower2.Text
            Else
                conditions.fan_file_name_2 = CType(cboFan2.SelectedItem, Fan).FileName
                conditions.hp_2 = CType(cboFan2.SelectedItem, Fan).Hp
            End If




        End If

        Return conditions
    End Function

    'todo: use condensing unit object for calculations instead of grabs
    Private Sub setControlsOnResultsTab(ByVal coilCapacity As Double)
        Dim numFansTotal, numCompressorsTotal As Integer
        Dim altitude, fanDiameter As String
        Dim condenserCapacity As Double
        Dim fanQuantity(3) As Integer
        Dim i As Integer

        For i = 0 To fanQuantity.Length - 1
            fanQuantity(i) = 0
        Next

        '?these controls are not visible

        If user.authority_group < 3 Then
            'sets condenser capacity on results page, which is used by report
            lblResultsCondenserCapacityValue.Text = Round(coilCapacity)
        ElseIf user.authority_group = 3 Then
            'calculates number of compressors
            numCompressorsTotal = _
               CType(Me.cbo_compressor_quantity_1.SelectedItem, Integer) + _
               CType(Me.cbo_compressor_quantity_2.SelectedItem, Integer)

            'sets fan quantity values
            fanQuantity(0) = CInt(Me.cbo_fan_quantity_1.Text)
            If Me.tabCondensingUnit.Contains(Me.tabCircuit2) Then
                fanQuantity(1) = CInt(Me.cbo_fan_quantity_2.Text)
            End If
            If Me.tabCondensingUnit.Contains(Me.tabCircuit3) Then
                fanQuantity(2) = CInt(Me.cboFanQuantity3.Text)
            End If
            If Me.tabCondensingUnit.Contains(Me.tabCircuit4) Then
                fanQuantity(3) = CInt(Me.cboFanQuantity4.Text)
            End If
            'calculates number of fans
            numFansTotal = fanQuantity(0) + fanQuantity(1) + fanQuantity(2) + fanQuantity(3)

            'sets fan diameter
            fanDiameter = Me.grab_fan_1.Diameter 'Me.cboFanDia1.SelectedItem.DisplayName.ToString.Substring(7, 2)
            'sets altitude text
            If CDbl(Me.txtRatingTabAltitude.Text) >= Business.Intelligence.FanIntel.HighAltitude Then
                altitude = "High altitude fan recommended. " & "(Altitude = " & Me.txtRatingTabAltitude.Text & " [ft])"
            ElseIf CType(Me.txtRatingTabAltitude.Text, Double) >= 0 _
            And CType(Me.txtRatingTabAltitude.Text, Double) < Business.Intelligence.FanIntel.HighAltitude Then
                altitude = Me.txtRatingTabAltitude.Text
            End If

            lblResultsNumberOfCompressorsValue.Text = numCompressorsTotal.ToString
            lblResultsNumberOfFansValue.Text = numFansTotal.ToString & "/" & fanDiameter
            lblResultsAltitudeValue.Text = altitude
        End If
    End Sub


    Private Sub formatResultsDatagrid()
        ' formats datagrid to look like other datagrids in RAESolutions
        ''mVisualStyles.FormatC1Datagrid(Me.dgrC1Results)

        ' sets column widths
        ''With Me.dgrC1Results.Splits(0)
        ''    .DisplayColumns("EvaporatorTemperature").Width = 65  'evaporator temp.
        ''    .DisplayColumns("AmbientTemperature").Width = 60   'ambient temp.
        ''    .DisplayColumns("CondenserTemperature").Width = 65   'condenser temp.
        ''    .DisplayColumns("Capacity").Width = 56   'capacity
        ''    .DisplayColumns("UnitPower").Width = 40   'unit kw
        ''    .DisplayColumns("CondenserCapacity").Width = 90   'condenser capacity
        ''    .DisplayColumns("CondenserTemperatureDifference").Width = 65   'condenser t.d.
        ''    .DisplayColumns("UnitCurrent").Width = 65   'unit amps
        ''    .DisplayColumns("UnitEfficiency").Width = 45   'unit eer
        ''End With

        ' sets column captions
        ''With Me.dgrC1Results.Columns
        ''    .Item("EvaporatorTemperature").Caption = "Suction Temp."
        ''    .Item("AmbientTemperature").Caption = "Ambient Temp."
        ''    .Item("CondenserTemperature").Caption = "Condenser Temp."
        ''    .Item("Capacity").Caption = "Est. Capacity"
        ''    .Item("UnitPower").Caption = "Unit KW"
        ''    .Item("CondenserCapacity").Caption = "Condenser Est. Capacity"
        ''    .Item("CondenserTemperatureDifference").Caption = "Condenser T.D."
        ''    .Item("UnitCurrent").Caption = "Unit Amps"
        ''    .Item("UnitEfficiency").Caption = "Unit EER"
        ''End With

        ' hides 'Condenser Capacity' and 'Condenser T.D.' from cri reps
        ''If user.authority_group = user_group.rep And
        ''AppInfo.Division = Division.CRI Then
        ''    Me.dgrC1Results.Splits(0).DisplayColumns("CondenserCapacity").Visible = False   'condenser capacity
        ''    Me.dgrC1Results.Splits(0).DisplayColumns("CondenserTemperatureDifference").Visible = False   'condenser t.d.
        ''End If

        ' hides 'Amps 230/460' from tsi reps
        'If user.AuthorityGroup = UserGroup.Rep And _
        'AppInfo.Division = Division.TSI Then
        ''Me.dgrC1Results.Splits(0).DisplayColumns("UnitCurrent").Visible = False
        'End If

        ' column header height
        ''Me.dgrC1Results.Splits(0).ColumnCaptionHeight = 30
        ' hide record selector
        ''Me.dgrC1Results.Splits(0).RecordSelectors = False


        If Me.DemandCoolingNote Then
            lblDemandCoolingNote.Visible = True
        Else
            lblDemandCoolingNote.Visible = False
        End If

    End Sub


    Private Function grabCondensingUnit(ByVal cu As Condensing_Unit) As Condensing_Unit
        Dim circuit = cu.circuits(0)

        circuit.refrigerant = refrigerant.parse(cbo_rating_tab_refrigerant.SelectedItem)
        circuit.subcooling = txtCoilSubCoolingPercentage1.Text
        circuit.has_subcooling = If(cboRatingSubCooling.SelectedItem = "Y", True, False)
        circuit.compressorMasterID = grab_compressor(cbo_compressor_1).MasterID
        'circuit.compressor_model = grab_compressor(cbo_compressor_1).Model
        circuit.compressor_quantity = cbo_compressor_quantity_1.SelectedItem
        circuit.fanID = grab_fan_1.FileName
        circuit.fan_quantity = cbo_fan_quantity_1.SelectedItem

        ' circuit.fanOperatingRPM = grab_fan_1.fanOperatingRPM

        circuit.hp = grab_fan_1.Hp
        ' circuit.coil.rows = cbo_rows_1.SelectedItem   'eccond

        Dim c1 As Rae.RaeSolutions.Business.Entities.Coil
        c1 = CType(coilComboBox_1.SelectedItem, Rae.RaeSolutions.Business.Entities.Coil)
        circuit.coil.RowsDeep = c1.NumRows
        circuit.coil.TubeDiameter = c1.Diameter


        Select Case c1.FinDesign
            Case Entities.Coil.FinType.Flat
                circuit.coil.FinSurface = "Flat"
            Case Entities.Coil.FinType.Waffle
                circuit.coil.FinSurface = "Waffle"
        End Select

        circuit.coil.TubeSurface = c1.TubeSurface



        circuit.coil.FPI = cbo_fpi_1.SelectedItem
        circuit.coil.FinHeight = txt_fin_height_1.Text
        circuit.coil.FinLength = txt_fin_length_1.Text

        circuit.CompressorCapacityMultiplier = txtCapMult1.Text

        If grab_fan_1.isVariableSpeed Then
            circuit.fanOperatingRPM = txtFanRPM1.Text
        End If

        If cu.number_of_circuits > 1 Then
            Dim circuit2 = cu.circuits(1)
            circuit2.refrigerant = circuit.refrigerant
            circuit2.subcooling = txtCoilSubCoolingPercentage2.Text
            circuit2.has_subcooling = If(cboRatingSubCooling.SelectedItem = "Y", True, False)
            circuit2.compressorMasterID = grab_compressor(cbo_compressor_2).MasterID
            'circuit2.compressor_model = grab_compressor(cbo_compressor_2).Model
            circuit2.compressor_quantity = cbo_compressor_quantity_2.SelectedItem
            circuit2.fanID = grab_fan_2.FileName
            circuit2.fan_quantity = cbo_fan_quantity_2.SelectedItem
            circuit2.hp = grab_fan_2.Hp





            '            circuit2.coil.rows = cbo_rows_2.SelectedItem  'eccond
            Dim c2 As Rae.RaeSolutions.Business.Entities.Coil
            c2 = CType(coilComboBox_2.SelectedItem, Rae.RaeSolutions.Business.Entities.Coil)

            If Not c2 Is Nothing Then

                circuit2.coil.RowsDeep = c2.NumRows


                circuit2.coil.TubeDiameter = c2.Diameter



                Select Case c2.FinDesign
                    Case Entities.Coil.FinType.Flat
                        circuit2.coil.FinThickness = "Flat"
                    Case Entities.Coil.FinType.Waffle
                        circuit2.coil.FinSurface = "Waffle"
                End Select

                circuit2.coil.TubeSurface = c2.TubeSurface



            End If

            circuit2.coil.FPI = cbo_fpi_2.SelectedItem
            circuit2.coil.FinHeight = txt_fin_height_2.Text
            circuit2.coil.FinLength = txt_fin_length_2.Text

            circuit2.CompressorCapacityMultiplier = txtCapMult2.Text

            If grab_fan_2.isVariableSpeed Then
                circuit2.fanOperatingRPM = txtFanRPM2.Text
            End If


        End If

        Return cu
    End Function

#End Region


    Private Sub setDivisionSpecificControls()
        'handles differences between tsi and century
        '(default settings are for century)
        If AppInfo.Division = Division.TSI Then
            'hides condensing units required controls
            Me.lblCondensingUnitsRequired.Visible = False
            Me.txtCondensingUnitsRequired.Visible = False
            'hides run time controls
            Me.grpRunTime.Visible = False

            txtRunTime.Visible = False
            lblRunTimeAdjust.Visible = False
            radRunTimeAdjustNo.Visible = False
            radRunTimeAdjustYes.Visible = False
            lblRunTimeUnits.Visible = False

            radRunTimeAdjustNo.Checked = True

            lblAmbientTemperatureRange.Text = "Limits 50 to 115 [ºF]"
            lblSuctionTemperatureRange.Text = "Limits 35 to 50 [ºF]"

            'sets condenser capacity default value in tons
            Me.txtCapacity.Text = "0"

            cboCondensingUnitSeries.Items.Clear()
            cboCondensingUnitSeries.Text = ""
            cboCondensingUnitSeries.Items.Add("20A0")
            ' If user.can(rate_20A4) Then
            cboCondensingUnitSeries.Items.Add("20A4")
            'Else
            '    cbo20A4.Visible = False
            '    lbl20A4.Visible = False
            'End If
            cboCondensingUnitSeries.SelectedIndex = 0

            txt_subcooling_temperature.Text = "15"
        ElseIf AppInfo.Division = Division.CRI Then
            With cboCondensingUnitSeries
                .Items.Clear()
                .Text = ""

                '.Items.AddRange(New Object() {"LUO", "LUI", "DD", "DM", "DS", "NSB", "NDB"})
                ' blargg - hide NMB and NMC
                '.Items.AddRange(New Object() {"LUO", "LUI", "DD", "DM", "DS", "NSB", "NDB", "NSC", "NDC", "NMB", "NMC"})


                If user.is_rep Then
                    .Items.AddRange(New Object() {"DM", "NSB", "NDB", "NSC", "NDC", "NSF", "NDF", "BLU-L", "BLU-B"})
                Else
                    .Items.AddRange(New Object() {"LUO", "LUI", "DD", "DM", "DS", "NSB", "NDB", "NSC", "NDC", "NSF", "NDF", "NMB", "NMC", "BLU-L", "BLU-B"})
                End If

                .SelectedIndex = 0
            End With
            If cboSelectionTabRefrigerant.SelectedItem Like "*L*" Then
                txt_subcooling_temperature.Text = "5"
            Else
                txt_subcooling_temperature.Text = "10"
            End If
        End If

        lblSelectionTabCapacityUnits.Text = getCapacityUnits(AppInfo.Division)
        lblRatingTabCapacityUnits.Text = getCapacityUnits(AppInfo.Division)
    End Sub



    Private Function create_table(ByVal data_table As CondensingUnitRatingDataSet.ResultsDataTable, ByVal capacity_units As String) As DataTable
        Dim table = New DataTable

        table.Columns.Add("Suction")
        table.Columns.Add("Ambient")
        table.Columns.Add("condensing_temperature") : table.Columns("condensing_temperature").ColumnName = "Cond. Temp."
        table.Columns.Add("Est. Capacity [" & capacity_units & "]")
        table.Columns.Add("Unit [kw]")
        table.Columns.Add("Unit EER")


        'For i As Integer = 0 To table.Columns.Count - 1
        '    If (i Mod 2) = 1 Then
        '        table.Columns(i).
        '    End If
        'Next



        Dim capacity_format = If(AppInfo.Division = Division.TSI, "#,#.0", "#,#")

        If user.is_employee Then
            table.Columns.Add("Condenser Est. Capacity [" & capacity_units & "]")
            table.Columns.Add("TD")
            For Each row As CondensingUnitRatingDataSet.ResultsRow In data_table.Rows
                table.Rows.Add(row.EvaporatorTemperature.F,
                               row.AmbientTemperature.F,
                               row.CondenserTemperature.F,
                               row.Capacity.format_number(capacity_format),
                               row.UnitPower,
                               row.UnitEfficiency, row.CondenserCapacity.format_number(capacity_format), row.CondenserTemperatureDifference.F)
            Next
        Else
            For Each row As CondensingUnitRatingDataSet.ResultsRow In data_table.Rows
                table.Rows.Add(row.EvaporatorTemperature.F,
                               row.AmbientTemperature.F,
                               row.CondenserTemperature.F,
                               row.Capacity.format_number(capacity_format),
                               row.UnitPower,
                               row.UnitEfficiency)
            Next
        End If

        Return table
    End Function

    Private Sub show_report()
        Dim report = New Rae.reporting.beta.report(reports.file_paths.condensing_unit_rating_file_path)

        Dim capacity_units = getCapacityUnits(AppInfo.Division)

        Dim data_table = rate()
        Dim table = create_table(data_table, capacity_units)

        Dim voltage = grab_unit_voltage.ToString
        Dim design_ambient = grab_ambient()
        Dim design_suction = txt_rating_tab_suction.Text
        Dim fan_1 = grab_fan_1()

        Dim text = New Dictionary(Of String, String)
        text.Add("application_version", My.Application.Info.Version.ToString)
        text.Add("user", user.username)
        text.Add("date_created", DateTime.Now.ToString("M/d/yyyy"))
        text.Add("year", DateTime.Now.Year)

        text.Add("model", txt_custom_model.Text)
        text.Add("refrigerant", cbo_rating_tab_refrigerant.SelectedItem.ToString)
        ' condenser capacity at 1F
        text.Add("condenser_capacity", lblResultsCondenserCapacityValue.Text)

        Dim altitude = grab_altitude()
        Dim altitude_note As String
        Dim altitude_is_high = Business.Intelligence.FanIntel.IsAltitudeHigh(altitude)
        ' there is no high altitude fan w/ 20" diameter
        If altitude_is_high And fan_1.Diameter > 20 Then
            altitude_note = altitude & " ft.   Note: High altitude fan recommended"
        Else
            altitude_note = altitude & " ft."
        End If

        text.Add("altitude", altitude_note)

        'Circuit 1 Info
        '----------------------------------------------
        Dim compressor_1 = grab_compressor(cbo_compressor_1)
        text.Add("compressor_quantity_1", cbo_compressor_quantity_1.SelectedItem.ToString)
        text.Add("compressor_type_1", compressor_1.Model)
        text.Add("fpi_1", cbo_fpi_1.SelectedItem)
        text.Add("fin_height_1", txt_fin_height_1.Text)
        text.Add("fin_length_1", txt_fin_length_1.Text)
        text.Add("fan_quantity_1", cbo_fan_quantity_1.SelectedItem)


        Dim fDesc1 As String = fan_1.Description
        If fan_1.isVariableSpeed Then
            '           fDesc1 &= " @ " & cu.circuits(0).fanOperatingRPM & " RPM"
            fDesc1 &= " @ " & txtFanRPM1.Text & " RPM"
        End If

        text.Add("fan_description_1", fDesc1)


        If Not txtDOECompliant.Text.ToUpper = "YES" Then
            text.Add("doecompliant", "")
        End If

        text.Add("rows_1", coilComboBox_1.SelectedItem.ToString)  'eccond

        If tabCircuits.TabPages.Contains(Me.tabCircuit2) Then
            'Circuit 2 Info
            '----------------------------------------------
            Dim compressor_2 = grab_compressor(cbo_compressor_2)
            Dim fan_2 = grab_fan_2()
            text.Add("compressor_quantity_2", "Quantity: " & cbo_compressor_quantity_2.SelectedItem.ToString)
            text.Add("compressor_type_2", "Type: " & compressor_2.Model)
            text.Add("fpi_2", "FPI: " & cbo_fpi_2.SelectedItem)
            text.Add("fin_height_2", "Fin Height: " & txt_fin_height_2.Text)
            text.Add("fin_length_2", "Fin Length: " & txt_fin_length_2.Text)
            text.Add("fan_quantity_2", "Quantity: " & cbo_fan_quantity_2.SelectedItem)

            '            text.Add("fan_description_2", "Description: " & fan_2.Description)
            Dim fDesc2 As String = fan_2.Description
            If fan_2.isVariableSpeed Then
                '  fDesc2 &= " @ " & cu.circuits(1).fanOperatingRPM & " RPM"
                fDesc2 &= " @ " & txtFanRPM2.Text & " RPM"
            End If

            text.Add("fan_description_2", fDesc2)

            text.Add("rows_2", "" & coilComboBox_2.SelectedItem.ToString)  'eccond
        Else
            report.remove("compressor_quantity_2")
            report.remove("compressor_type_2")
            report.remove("fpi_2")
            report.remove("fin_height_2")
            report.remove("fin_length_2")
            report.remove("fan_quantity_2")
            report.remove("fan_description_2")
            report.remove("rows_2")
            report.remove("Circuit 2")

            report.remove("Compressor2")
            report.remove("Coil2")
            report.remove("Fan2")

        End If

        Dim notes As String
        If lblResultsOmit.Visible Then
            notes = lblResultsOmit.Text & NewLine
        End If
        notes &= Me.cboRatingHertz.SelectedItem & " Rating" & NewLine
        'catalog or standard rating
        notes &= Me.cboRatingCatalog.SelectedItem & " Rating" & NewLine
        If Me.cboRatingSafety.SelectedItem = "Y" Then
            notes &= "Compressor safety override is ON" & NewLine
        Else
            notes &= "Compressor safety override is OFF" & NewLine
        End If


        If Me.cboCTLimit.SelectedItem = "Y" Then

            Dim cMax As Integer

            Select Case Me.cboSelectionTabRefrigerant.SelectedItem.ToString.ToUpper
                Case "R404A"
                    cMax = 130
                Case "R507"
                    cMax = 130
                Case "R407C"
                    cMax = 130
                Case "R410A"
                    cMax = 141
                Case "R407A"
                    cMax = 130
                Case "R407F"
                    cMax = 130
                Case "R134A"
                    cMax = 150
                Case "R448A"
                    cMax = 130
                Case "R449A"
                    cMax = 130
                Case "R22"
                    cMax = 130
                Case Else
                    cMax = -1

            End Select
            ' eric9898

            notes &= "High Pressure Construction Required for Condensing Temperatures over " & cMax & "°F" & NewLine



        End If


        If Me.cboRatingSubCooling.SelectedItem = "Y" Then
            notes &= "Note: Est. Capacity based on " & txt_subcooling_temperature.Text & _
               " degrees sub cooling"
        End If


        Dim total_fan_quantity = ConvertNull.ToInteger(cbo_fan_quantity_1.SelectedItem)
        If Me.tabCircuits.TabCount > 1 Then _
           total_fan_quantity += ConvertNull.ToInteger(Me.cbo_fan_quantity_2.SelectedItem)
        text.Add("total_fan_quantity", total_fan_quantity)

        Dim total_compressor_quantity = ConvertNull.ToInteger(cbo_compressor_quantity_1.SelectedItem)
        If Me.tabCircuits.TabCount > 1 Then _
           total_compressor_quantity += ConvertNull.ToInteger(cbo_compressor_quantity_2.SelectedItem)
        text.Add("total_compressor_quantity", total_compressor_quantity)

        Dim division = AppInfo.Division.ToString.ToUpper
        Dim command = New get_logo_file_path_command(user, division)
        Dim logo_file_path = command.execute

        report.set_text(text)
        report.set_list("notes", notes.Split(Rae.Io.Text.new_line).ToList)


        '        report.set_table("table", table)

        report.set_table("table", table, New Rae.reporting.beta.condensing_unit_report_table_factory, design_suction, design_ambient)




        report.set_image("logo", logo_file_path)
        report.mark_as_final()
        report.show()
    End Sub


    Private Sub fillFanCombobox(ByRef cboSent As ComboBox)
        cboSent.Items.Clear()
        Dim fans = service.GetFans().ToArray()
        cboSent.Items.AddRange(fans)


        If user.can(enter_custom_cfm_cond_unit) Then
            Dim customFan As New Fan("Custom", 0, 0, 0, False, 0, False)
            cboSent.Items.Add(customFan)
        End If


    End Sub


    Private Function getRefrigerants(ByVal div As Division) As List(Of String)
        Dim refrigerants = New List(Of String)

        With refrigerants
            'If (div = Division.CRI And user.is_employee) Or (div = Division.TSI And user.is_employee) Then
            '    .Add("R507")
            '    .Add("R22")
            '    .Add("R404a")
            '    .Add("R134a")
            '    .Add("R407a")
            '    .Add("R407c")
            '    .Add("R407f")
            'End If



            Select Case user.is_employee
                Case True
                    Select Case div
                        Case Division.CRI
                            .Add("R507")
                            .Add("R22")
                            .Add("R404a")
                            .Add("R134a")
                            .Add("R407a")
                            .Add("R407c")
                            .Add("R407f")
                            .Add("R448a")
                            .Add("R449a")

                        Case Division.TSI
                            .Add("R507")
                            .Add("R22")
                            .Add("R404a")
                            .Add("R134a")
                            .Add("R407a")
                            .Add("R407c")
                            .Add("R407f")
                            .Add("R410a")
                            .Add("R448a")
                            .Add("R449a")
                    End Select
                Case False
                    Select Case div
                        Case Division.CRI
                            .Add("R507")
                            .Add("R22")
                            .Add("R404a")
                            .Add("R134a")
                            .Add("R407a")
                            .Add("R407c")
                            .Add("R407f")
                            .Add("R448a")
                            .Add("R449a")
                        Case Division.TSI
                            .Add("R410a")
                    End Select

            End Select


            'If div = Division.TSI And user.is_employee Then
            '    '    .Add("R134a")
            '    '  .Add("R407c")
            'End If

            'If div = Division.TSI Then
            '    .Add("R410a")
            'End If


            '  If div = Division.CRI And user.is_in(century_R134a) Then .Add("R134a")
            ' If user.can(rate_20A4) Then .Add("R410a")


        End With

        Return refrigerants
    End Function

    Private Sub logFormStart()
        Try
            'logs form usage statistics
            usageLogger = New Diagnostics.UsageLog.FormUsageLogger( _
               Diagnostics.UsageLog.ApplicationUsageLogger.ApplicationID, _
               Diagnostics.UsageLog.ApplicationUsageLogger.LogFile.FullName)
            usageLogger.LogFormStart(Me.Text)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub logFormEnd()
        Dim model, refrigerant As String
        Dim ambientTemperature, suctionTemperature As Single

        Try
            ambientTemperature = Me.txtSelectionTabAmbient.Text
            suctionTemperature = Me.txtSelectionTabSuction.Text
            model = Me.lblRatingCondensingUnitModelValue.Text
            refrigerant = Me.cboSelectionTabRefrigerant.SelectedItem
            'logs form usage statistics
            usageLogger.LogFormEnd(model, refrigerant, suctionTemperature, ambientTemperature)
        Catch ex As Exception

        End Try
    End Sub

#Region " UI"


    Private Function grabSpec() As Best_Matches.Spec
        Dim totalCapacity = Val(txtCapacity.Text)
        Dim qty = Val(txtCondensingUnitsRequired.Text)
        Dim runTime = Val(txtRunTime.Text)
        Dim shouldAdjustForRunTime = radRunTimeAdjustYes.Checked

        Dim capacityPerUnit = totalCapacity / qty

        If shouldAdjustForRunTime Then _
           capacityPerUnit = capacityPerUnit * 24 / runTime

        Dim refg = cboSelectionTabRefrigerant.SelectedItem.ToString
        Dim compressorType = cboCompressor.SelectedItem.ToString

        Dim compressorQty As Double
        If cboCompressorPerUnit.SelectedItem.ToString.ToUpper = "ALL" Then
            compressorQty = 0
        Else
            compressorQty = cboCompressorPerUnit.SelectedItem
        End If

        Dim numCircuits As Double
        If cboCircuitsPerUnit.SelectedItem.ToString.ToUpper = "ALL" Then
            numCircuits = 0
        Else
            numCircuits = cboCircuitsPerUnit.SelectedItem
        End If

        Dim series = cboCondensingUnitSeries.SelectedItem.ToString

        Dim spec As Best_Matches.Spec
        spec.capacity = capacityPerUnit
        spec.compressor_quantity = compressorQty
        spec.compressor_type = compressorType
        spec.division = AppInfo.Division
        spec.num_circuits = numCircuits
        spec.refrigerant = refrigerant.parse(refg)
        spec.series = series


        spec.DOEModels = ddlDOEModels.Text

        Return spec
    End Function

    Private Function grabBestConditions() As Best_Matches.Conditions
        Dim ambient = ConvertNull.ToDouble(txtSelectionTabAmbient.Text)
        Dim suction = ConvertNull.ToDouble(txtSelectionTabSuction.Text)
        Dim altitude = ConvertNull.ToDouble(txtSelectionTabAltitude.Text)
        Dim voltage = grab_unit_voltage()

        Dim conditions As Best_Matches.Conditions
        conditions.altitude = altitude
        conditions.ambient = ambient
        conditions.suction = suction
        conditions.voltage = voltage
        conditions.hertz = 60
        conditions.catalog_rating = False

        Return conditions
    End Function

    Private Function grabInput() As BestSelectionsGrid.Input
        Dim input As BestSelectionsGrid.Input
        input.CondensingUnitQuantity = txtCondensingUnitsRequired.Text
        input.RunTime = txtRunTime.Text
        input.User = user
        input.Division = AppInfo.Division

        Return input
    End Function

    Private Function grab_unit_voltage() As Integer
        Return CInt(voltageComboBox.SelectedItem)
    End Function

    Private Function grab_ambient() As Double
        Return ConvertNull.ToDouble(txtRatingTabAmbient.Text)
    End Function

    Private Function grab_altitude() As Double
        Return ConvertNull.ToDouble(Me.txtRatingTabAltitude.Text.Trim)
    End Function

    Private Function grab_fan_1() As Fan
        Return DirectCast(Me.cboFan1.SelectedItem, Fan)
    End Function

    Private Function grab_fan_2() As Fan
        Return DirectCast(Me.cboFan2.SelectedItem, Fan)
    End Function

    Private Function GrabFan3() As Fan
        Return DirectCast(Me.cboFanDiameter3.SelectedItem, Fan)
    End Function

    Private Function GrabFan4() As Fan
        Return DirectCast(Me.cboFanDiameter4.SelectedItem, Fan)
    End Function

#End Region


    Private Function modelIsSelected() As Boolean
        Dim modelSelected As Boolean

        ' is rating selected
        If Me.radUnitRating.Checked Then
            ' is logged in under century
            If AppInfo.Division = Division.CRI Then
                If Me.cboDD.SelectedIndex > 0 _
                OrElse Me.cboDM.SelectedIndex > 0 _
                OrElse Me.cboDS.SelectedIndex > 0 _
                OrElse Me.cboLUI.SelectedIndex > 0 _
                OrElse Me.cboLUO.SelectedIndex > 0 _
                OrElse Me.cboNSB.SelectedIndex > 0 _
                OrElse Me.cboBLU_L.SelectedIndex > 0 _
                OrElse Me.cboBLU_B.SelectedIndex > 0 _
                OrElse Me.cboNDB.SelectedIndex > 0 _
                OrElse Me.cboNSC.SelectedIndex > 0 _
                OrElse Me.cboNDC.SelectedIndex > 0 _
                OrElse Me.cboNMC.SelectedIndex > 0 _
                OrElse Me.cboNMB.SelectedIndex > 0 Then
                    modelSelected = True
                End If
                ' is logged in under technical systems
            ElseIf AppInfo.Division = Division.TSI Then
                If Me.cbo20A0.SelectedIndex > 0 OrElse cbo20A4.SelectedIndex > 0 Then
                    modelSelected = True
                End If
            Else
                Throw New ApplicationException("A valid division of RAE Corporation is not selected.")
            End If
        Else
            Return True
        End If

        Return modelSelected
    End Function

#End Region

    Private Sub cboFan_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles cboFan1.SelectedIndexChanged, cboFan2.SelectedIndexChanged
        txtDOECompliant.Text = "No"

        Try

            If CType(cboFan1.SelectedItem, Fan).FileName.ToUpper = "CUSTOM" Then
                lblCustomCFM1.Visible = True
                txtCustomCFM1.Visible = True
                lblCustomPower1.Visible = True
                txtCustomPower1.Visible = True
            Else
                lblCustomCFM1.Visible = False
                txtCustomCFM1.Visible = False
                lblCustomPower1.Visible = False
                txtCustomPower1.Visible = False
            End If

            If cu.circuits.Count > 1 Then
                If CType(cboFan2.SelectedItem, Fan).FileName.ToUpper = "CUSTOM" Then
                    lblCustomCFM2.Visible = True
                    txtCustomCFM2.Visible = True
                    lblCustomPower2.Visible = True
                    txtCustomPower2.Visible = True
                Else
                    lblCustomCFM2.Visible = False
                    txtCustomCFM2.Visible = False
                    lblCustomPower2.Visible = False
                    txtCustomPower2.Visible = False
                End If
            End If


            CheckForVariSpeedFan()


        Catch ex As Exception

        End Try

    End Sub


    Private Sub CheckForVariSpeedFan()
        Try
            If Not cu Is Nothing Then
                If CType(cboFan1.SelectedItem, Fan).isVariableSpeed Then
                    lblFanRPM1.Visible = True
                    txtFanRPM1.Visible = True
                    txtFanRPM1.Text = cu.circuits(0).fanOperatingRPM
                    lblFanRPM1.Text = "RPM (" & CType(cboFan1.SelectedItem, Fan).CurveRPM & " Max)"
                Else
                    lblFanRPM1.Visible = False
                    txtFanRPM1.Visible = False
                End If


                If cu.circuits.Count > 1 Then
                    If CType(cboFan2.SelectedItem, Fan).isVariableSpeed Then
                        lblFanRPM2.Visible = True
                        txtFanRPM2.Visible = True
                        txtFanRPM2.Text = cu.circuits(1).fanOperatingRPM
                        lblFanRPM2.Text = "RPM (" & CType(cboFan2.SelectedItem, Fan).CurveRPM & " Max)"

                    Else
                        lblFanRPM2.Visible = False
                        txtFanRPM2.Visible = False
                    End If
                End If
            End If
        Catch ex As Exception

        End Try


    End Sub



    Private Sub altitude_Leave() Handles txtRatingTabAltitude.Leave
        Dim fans = grabStandardFanSelections()
        Dim altitude = grab_altitude()

        If user.is_rep Then
            selectDefault(fans, altitude)
            'ElseIf user.IsEmployee
            '   recommend(fans, altitude)
        End If
    End Sub

    Private Function grabStandardFanSelections() As List(Of Fan)
        Dim fans = New List(Of Fan)
        Dim cu = repository.get_unit(grab_condensing_unit_model)
        Dim fanID = cu.circuits(0).fanID
        Dim hp = cu.circuits(0).hp

        Dim standardFan1 = service.SelectDefaultFan(fanID, hp, 0, 1)
        fans.Add(standardFan1)
        If cu.number_of_circuits > 1 Then
            fanID = cu.circuits(1).fanID
            hp = cu.circuits(1).hp
            Dim standardFan2 = service.SelectDefaultFan(fanID, hp, 0, 1)
            fans.Add(standardFan2)
        End If
        Return fans
    End Function

    Private Sub selectDefault(ByVal fans As List(Of Fan), ByVal altitude As Double)
        Dim circuit = 1
        For Each fan In fans
            selectFanForCombobox(circuit, fan.FileName, fan.Hp, altitude)
            circuit += 1
        Next
    End Sub

    Private Sub selectFanForCombobox(ByVal circuit As Integer, ByVal fanID As String, ByVal hp As Double, ByVal altitude As Double)
        Dim fan = service.SelectDefaultFan(fanID, hp, altitude, 1)
        selectFanForCombobox(circuit, fan.FileName, hp)
    End Sub


    Private Sub selectFanForCombobox(ByVal circuit As Integer, ByVal fanID As String, ByVal hp As Double)
        Dim combobox = If(circuit = 1, cboFan1, cboFan2)

        For Each item In combobox.Items
            Dim fan = CType(item, Fan)

            If fanID = fan.FileName And hp = fan.Hp Then
                combobox.SelectedItem = item
                Exit For
            End If
        Next

        CheckForVariSpeedFan()

    End Sub

    Private Sub recommend(ByVal fans As List(Of Fan), ByVal altitude As Double)
        Dim recommendation = ""

        For Each fan In fans
            recommendation &= getFanRecommendation(fan, altitude)
        Next

        If Not String.IsNullOrEmpty(recommendation) Then _
           warn(recommendation)
    End Sub

    Private Function getFanRecommendation(ByVal fan As Fan, ByVal altitude As Double) As String
        Dim recommendation = ""
        If FanIntel.IsAltitudeHigh(altitude) And Not FanIntel.IsHighAltitudeFan(fan.FileName) Then
            recommendation &= "High altitude fans are recommended at altitudes over " & FanIntel.HighAltitude & " feet."
        ElseIf Not FanIntel.IsAltitudeHigh(altitude) And FanIntel.IsHighAltitudeFan(fan.FileName) Then
            recommendation &= "High altitude fans are not recommended at altitudes under " & FanIntel.HighAltitude & " feet."
        End If
        Return recommendation
    End Function


    Private Function getCapacityUnits(ByVal div As Division) As String
        Dim units As String

        If div = Division.CRI Then
            units = "BTUH"
        ElseIf div = Division.TSI Then
            units = "Tons"
        End If

        Return units
    End Function


    Private Sub txtRatingAltitude_TextChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles txtRatingTabAltitude.TextChanged
        Me.txtSelectionTabAltitude.Text = Me.txtRatingTabAltitude.Text
    End Sub

    Sub Open(ByVal chiller As ProcessItem)
        Try
            Me.LoadControls(chiller)
        Catch ex As Exception
            Ui.MessageBox.Show("An error occurred while opening condensing unit. " & ex.Message)
        End Try
    End Sub

    ' reset control text before populating with object values...
    Sub resetControls()

        ' view selection tab...
        tabCondensingUnit.SelectedTab = Me.tabSelection

        cboCondensingUnitSeries.Text = ""
        txtCondensingUnitsRequired.Text = 1
        txtCapacity.Text = 24000
        radRunTimeAdjustNo.Checked = True
        txtRunTime.Text = 16
        txtSelectionTabAmbient.Text = 95
        txtSelectionTabSuction.Text = 40
        cboSelectionTabRefrigerant.Text = ""
        cboCompressor.Text = ""
        cboCompressorPerUnit.Text = ""
        cboCircuitsPerUnit.Text = ""
        txtSelectionTabAltitude.Text = 0

        ' Selection or rating?
        rbo_unit_selection.Checked = True

        ' model cbo boxes & radio button
        cboLUI.Text = "Choose"
        cboLUO.Text = "Choose"
        cboDD.Text = "Choose"
        cboDM.Text = "Choose"
        cboDS.Text = "Choose"
        '        cboRS.Text = "Choose"
        cbo20A0.Text = "Choose"
        cbo20A4.Text = "Choose"
        cboNSB.Text = "Choose"
        cboNDB.Text = "Choose"
        cboNDC.Text = "Choose"
        cboNSC.Text = "Choose"
        cboBLU_L.Text = "Choose"
        cboBLU_B.Text = "Choose"

        rbo_condensing_unit_1.Checked = True


        ' RATING TAB

        lblRatingCondensingUnitModelValue.Text = ""
        txt_custom_model.Text = ""
        txtRatingTabAmbient.Text = ""
        cboRatingAmbientInterval.Text = ""
        cboRatingAmbientSteps.Text = ""
        txt_rating_tab_suction.Text = ""
        cboRatingSuctionInterval.Text = ""
        cboRatingSuctionSteps.Text = ""
        cbo_rating_tab_refrigerant.Text = ""
        txtRatingTabAltitude.Text = 0
        cboRatingSubCooling.Text = ""
        cboRatingCatalog.Text = ""
        cboRatingHertz.Text = ""
        cboRatingSafety.Text = ""

        ' circuit 1 
        cbo_compressor_1.Text = ""
        cbo_compressor_quantity_1.Text = ""
        '        cbo_rows_1.Text = ""  'eccond
        coilComboBox_1.SelectedIndex = -1

        txtCoilSubCoolingPercentage1.Text = 0
        txt_fin_height_1.Text = ""
        txt_fin_length_1.Text = ""
        cbo_fpi_1.Text = ""
        cboFan1.Text = ""
        cbo_fan_quantity_1.Text = ""
        txtFanRPM1.Text = ""


        ' circuit 2 
        cbo_compressor_2.Text = ""
        cbo_compressor_quantity_2.Text = ""
        '        cbo_rows_2.Text = ""   'eccond
        coilComboBox_2.SelectedIndex = -1


        txtCoilSubCoolingPercentage2.Text = 0
        txt_fin_height_2.Text = ""
        txt_fin_length_2.Text = ""
        cbo_fpi_2.Text = ""
        cboFan2.Text = ""
        cbo_fan_quantity_2.Text = ""
        txtFanRPM2.Text = ""


        ' circuit 3 
        cboCompressor3.Text = ""
        cboCompressorQuantity3.Text = ""
        '  cboCoilRows3.Text = ""
        txtCoilSubCoolingPercentage3.Text = 0
        txtCoilFinHeight3.Text = ""
        txtCoilFinWidth3.Text = ""
        cboFinsPerInch3.Text = ""
        cboFanDiameter3.Text = ""
        cboFanQuantity3.Text = ""
        'txtFanRPM3.Text = ""

        ' circuit 4 
        cboCompressor4.Text = ""
        cboCompressorQuantity4.Text = ""
        cboCoilRows4.Text = ""
        txtCoilSubCoolingPercentage4.Text = 0
        txtCoilFinHeight4.Text = ""
        txtCoilFinWidth4.Text = ""
        cboFinsPerInch4.Text = ""
        cboFanDiameter4.Text = ""
        cboFanQuantity4.Text = ""

    End Sub

    Sub LoadControls(ByVal item As CondensingUnitProcessItem)
        resetControls()

        ' If latest revision has not been set then
        ' we need to set it now  based on the ID...
        If Me._latestRevision = -1 Then
            Me._latestRevision = Rae.RaeSolutions.DataAccess.Projects.ProcessItemDA.LastestRevision(Me.Tag)
        End If

        ' Increment the current process revision
        ' displayed on this form...
        Me._currentRevision = item.Revision

        ' Clone last saved process to passing process item
        LastSavedProcess = item.Clone()

        ' Load condensing unit series
        Me.cboCondensingUnitSeries.Text = LastSavedProcess.Series

        ' if number of condensing units required is zero
        '  the adjusted condenser capacity calculation has an overflow error from divide by zero
        If LastSavedProcess.CondensingUnitsRequired > 0 Then
            ' Condensing units required
            Me.txtCondensingUnitsRequired.Text = LastSavedProcess.CondensingUnitsRequired
        End If
        ' Load capacity
        Me.txtCapacity.Text = LastSavedProcess.Capacity

        ' Runtime adjust?
        If LastSavedProcess.RuntimeAdjust = True Then
            Me.radRunTimeAdjustYes.Checked = True
        Else
            Me.radRunTimeAdjustNo.Checked = True
        End If

        ' Run Time
        Me.txtRunTime.Text = LastSavedProcess.Runtime

        ' Ambient temp
        Me.txtSelectionTabAmbient.Text = LastSavedProcess.AmbientTemperature

        ' Suction temp
        Me.txtSelectionTabSuction.Text = LastSavedProcess.SuctionTemperature

        ' Load refrigerant
        Me.cboSelectionTabRefrigerant.Text = LastSavedProcess.Refrigerant

        ' Compressor
        If LastSavedProcess.Compressor Is Nothing Then
            cboCompressor.SelectedIndex = 0
        Else
            cboCompressor.Text = LastSavedProcess.Compressor
        End If

        ' Compressors / Unit
        If LastSavedProcess.CompressorPerUnit = 0 Then
            Me.cboCompressorPerUnit.Text = "ALL"
        Else
            Me.cboCompressorPerUnit.Text = LastSavedProcess.CompressorPerUnit
        End If

        ' Circuits / Unit
        If LastSavedProcess.CircuitsPerUnit = 0 Then
            Me.cboCircuitsPerUnit.Text = "ALL"
        Else
            Me.cboCircuitsPerUnit.Text = LastSavedProcess.CircuitsPerUnit
        End If

        ' Altitude
        Me.txtSelectionTabAltitude.Text = LastSavedProcess.Altitude

        ' Selection or rating?
        If LastSavedProcess.RunType = CondensingUnitProcessItem.eRunType.UnitRating Then
            radUnitRating.Checked = True
        ElseIf LastSavedProcess.RunType = CondensingUnitProcessItem.eRunType.UnitSelection Then
            rbo_unit_selection.Checked = True
        End If

        ' Notes
        notesTextBox.Text = LastSavedProcess.Notes

        ' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        ' RUN...
        ' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        txtCoolStuffID.Text = "-1"
        'txtCoolStuffRevision.Tag = -1

        showBestUnits()


        If radUnitRating.Checked Then

            Me.ddlDOEModels.Text = LastSavedProcess.DOEModel

            If AppInfo.Division = Division.CRI Then
                If LastSavedProcess.Model Like "LUI*" Then
                    cboLUI.Text = LastSavedProcess.Model
                ElseIf LastSavedProcess.Model Like "LUO*" Then
                    cboLUO.Text = LastSavedProcess.Model
                ElseIf LastSavedProcess.Model Like "DD*" Then
                    cboDD.Text = LastSavedProcess.Model
                ElseIf LastSavedProcess.Model Like "DM*" Then
                    cboDM.Text = LastSavedProcess.Model
                ElseIf LastSavedProcess.Model Like "DS*" Then
                    cboDS.Text = LastSavedProcess.Model
                    'ElseIf LastSavedProcess.Model Like "RS*" Then
                    '    cboRS.Text = LastSavedProcess.Model
                    'ElseIf LastSavedProcess.Model Like "B*" Then
                    '    bSeriesComboBox.Text = LastSavedProcess.Model
                ElseIf LastSavedProcess.Model Like "NSB*" Then
                    cboNSB.Text = LastSavedProcess.Model
                ElseIf LastSavedProcess.Model Like "BLU-L*" Then
                    cboBLU_L.Text = LastSavedProcess.Model
                ElseIf LastSavedProcess.Model Like "BLU-B*" Then
                    cboBLU_B.Text = LastSavedProcess.Model
                ElseIf LastSavedProcess.Model Like "NDB*" Then
                    cboNDB.Text = LastSavedProcess.Model
                ElseIf LastSavedProcess.Model Like "NSC*" Then
                    cboNSC.Text = LastSavedProcess.Model
                ElseIf LastSavedProcess.Model Like "NDC*" Then
                    cboNDC.Text = LastSavedProcess.Model
                    'ElseIf LastSavedProcess.Model Like "BLU*" Then
                    '    cboBLU.Text = LastSavedProcess.Model

                    ' blargg - hide NMB and NMC
                ElseIf LastSavedProcess.Model Like "NMC*" Then
                    cboNMC.Text = LastSavedProcess.Model
                ElseIf LastSavedProcess.Model Like "NMB*" Then
                    cboNMB.Text = LastSavedProcess.Model
                Else
                    Throw New ArgumentException("The model is invalid: " & ConvertNull.ToString(LastSavedProcess.Model))
                End If
            ElseIf AppInfo.Division = Division.TSI Then
                If LastSavedProcess.Model Like "20A0*" Then
                    cbo20A0.Text = LastSavedProcess.Model
                ElseIf LastSavedProcess.Model Like "20A4*" Then
                    cbo20A4.Text = LastSavedProcess.Model
                End If
            End If

        ElseIf rbo_unit_selection.Checked Then

            If AppInfo.Division = Division.CRI Then
                If rbo_condensing_unit_1.Text Like "*" & LastSavedProcess.Model & "*" Then
                    rbo_condensing_unit_1.Checked = True
                ElseIf rbo_condensing_unit_2.Text Like "*" & LastSavedProcess.Model & "*" Then
                    rbo_condensing_unit_2.Checked = True
                ElseIf rbo_condensing_unit_3.Text Like "*" & LastSavedProcess.Model & "*" Then
                    rbo_condensing_unit_3.Checked = True
                End If
            ElseIf AppInfo.Division = Division.TSI Then
                If rbo_condensing_unit_1.Text Like "*" & LastSavedProcess.Model & "*" Then
                    rbo_condensing_unit_1.Checked = True
                ElseIf rbo_condensing_unit_2.Text Like "*" & LastSavedProcess.Model & "*" Then
                    rbo_condensing_unit_2.Checked = True
                ElseIf rbo_condensing_unit_3.Text Like "*" & LastSavedProcess.Model & "*" Then
                    rbo_condensing_unit_3.Checked = True
                End If
            End If

        End If

        ' now view rating tab...
        Me.tabCondensingUnit.SelectedTab = Me.tabRating

        Me.lblRatingCondensingUnitModelValue.Text = LastSavedProcess.Model
        Me.txt_custom_model.Text = LastSavedProcess.CustomCondensingUnitModel


        If Me.txt_custom_model.Text = "" Then ' 
            Me.txt_custom_model.Text = LastSavedProcess.Model
        End If



        Me.txtRatingTabAmbient.Text = LastSavedProcess.RatingAmbient
        Me.cboRatingAmbientInterval.Text = LastSavedProcess.RatingAmbientInterval
        Me.cboRatingAmbientSteps.Text = LastSavedProcess.RatingAmbientStep
        Me.txt_rating_tab_suction.Text = LastSavedProcess.RatingSuction
        Me.cboRatingSuctionInterval.Text = LastSavedProcess.RatingSuctionInterval
        Me.cboRatingSuctionSteps.Text = LastSavedProcess.RatingSuctionStep
        If LastSavedProcess.RatingRefrigerant IsNot Nothing Then



            ControlAssistant.SelectComboboxItem(cbo_rating_tab_refrigerant, LastSavedProcess.RatingRefrigerant)
            Me.cbo_rating_tab_refrigerant.Text = LastSavedProcess.RatingRefrigerant
        End If
        Me.txtRatingTabAltitude.Text = LastSavedProcess.RatingAltitude

        ' subcooling?  >0=Y  /  0=N
        If LastSavedProcess.RatingSubCooling > 0 Then
            Me.cboRatingSubCooling.Text = "Y"
        ElseIf LastSavedProcess.RatingSubCooling = 0 Then
            Me.cboRatingSubCooling.Text = "N"
        End If

        If LastSavedProcess.RatingCatalog = False Then
            Me.cboRatingCatalog.Text = "Standard"
        Else
            Me.cboRatingCatalog.Text = "Rating"
        End If

        Me.cboRatingHertz.Text = LastSavedProcess.RatingHertz & " HZ"
        voltageComboBox.Text = LastSavedProcess.Voltage

        If LastSavedProcess.RatingSafety = False Then
            Me.cboRatingSafety.Text = "N"
        Else
            Me.cboRatingSafety.Text = "Y"
        End If




        ' circuit 1
        ' for now if compressor 1 is nothing then (assume a conversion) leave standard compressor selected
        ' an error was occuring because of a null compressor before this change
        If LastSavedProcess.Compressor1 IsNot Nothing Then
            Me.cbo_compressor_1.Text = LastSavedProcess.Compressor1
            Me.cbo_compressor_quantity_1.Text = LastSavedProcess.CompressorQuantity1
            '            Me.cbo_rows_1.Text = LastSavedProcess.CoilRows1  'eccond


            '  If String.IsNullOrEmpty(LastSavedProcess.TubeSurface1) Then
            loadCondenserCoilDropdown(coilComboBox_1, LastSavedProcess.CoilRows1, LastSavedProcess.TubeDiameter1)
            '  Else
            'loadCondenserCoilDropdown(coilComboBox_1, LastSavedProcess.CoilRows1, LastSavedProcess.TubeSurface1, LastSavedProcess.TubeDiameter1, LastSavedProcess.FinType1)
            '   End If



            Me.txtCoilSubCoolingPercentage1.Text = LastSavedProcess.CoilSubCoolingPercentage1
            Me.txt_fin_height_1.Text = LastSavedProcess.FinHeight1
            Me.txt_fin_length_1.Text = LastSavedProcess.CoilFinWidth1
            Me.cbo_fpi_1.Text = LastSavedProcess.FinsPerInch1
            If LastSavedProcess.FanDia1 IsNot Nothing Then
                Me.cboFan1.Text = LastSavedProcess.FanDia1
            End If
            Me.cbo_fan_quantity_1.Text = LastSavedProcess.FanQuantity1

            Me.txtFanRPM1.Text = LastSavedProcess.FanRPM1

        End If

        ' circuit 2
        If LastSavedProcess.Compressor2 IsNot Nothing Then
            Me.cbo_compressor_2.Text = LastSavedProcess.Compressor2
            Me.cbo_compressor_quantity_2.Text = LastSavedProcess.CompressorQuantity2


            ' Me.cbo_rows_2.Text = LastSavedProcess.CoilRows2  'eccond

            '  If String.IsNullOrEmpty(LastSavedProcess.TubeSurface2) Then
            loadCondenserCoilDropdown(coilComboBox_2, LastSavedProcess.CoilRows2, LastSavedProcess.TubeDiameter2)
            ' Else
            'loadCondenserCoilDropdown(coilComboBox_2, LastSavedProcess.CoilRows2, LastSavedProcess.TubeSurface2, LastSavedProcess.TubeDiameter2, LastSavedProcess.FinType2)
            ' End If


            Me.txtCoilSubCoolingPercentage2.Text = LastSavedProcess.CoilSubCoolingPercentage2
            Me.txt_fin_height_2.Text = LastSavedProcess.FinHeight2
            Me.txt_fin_length_2.Text = LastSavedProcess.CoilFinWidth2
            Me.cbo_fpi_2.Text = LastSavedProcess.FinsPerInch2
            If LastSavedProcess.FanDia2 IsNot Nothing Then
                Me.cboFan2.Text = LastSavedProcess.FanDia2
            End If
            Me.cbo_fan_quantity_2.Text = LastSavedProcess.FanQuantity2

            Me.txtFanRPM2.Text = LastSavedProcess.FanRPM2

        End If

        ' circuit 3
        Me.cboCompressor3.Text = LastSavedProcess.Compressor3
        Me.cboCompressorQuantity3.Text = LastSavedProcess.CompressorQuantity3
        ' Me.cboCoilRows3.Text = LastSavedProcess.CoilRows3
        Me.txtCoilSubCoolingPercentage3.Text = LastSavedProcess.CoilSubCoolingPercentage3
        Me.txtCoilFinHeight3.Text = LastSavedProcess.FinHeight3
        Me.txtCoilFinWidth3.Text = LastSavedProcess.CoilFinWidth3
        Me.cboFinsPerInch3.Text = LastSavedProcess.FinsPerInch3
        If LastSavedProcess.FanDia3 IsNot Nothing Then
            Me.cboFanDiameter3.Text = LastSavedProcess.FanDia3
        End If
        Me.cboFanQuantity3.Text = LastSavedProcess.FanQuantity3

        ' circuit 4
        Me.cboCompressor4.Text = LastSavedProcess.Compressor4
        Me.cboCompressorQuantity4.Text = LastSavedProcess.CompressorQuantity4
        Me.cboCoilRows4.Text = LastSavedProcess.CoilRows4
        Me.txtCoilSubCoolingPercentage4.Text = LastSavedProcess.CoilSubCoolingPercentage4
        Me.txtCoilFinHeight4.Text = LastSavedProcess.FinHeight4
        Me.txtCoilFinWidth4.Text = LastSavedProcess.CoilFinWidth4
        Me.cboFinsPerInch4.Text = LastSavedProcess.FinsPerInch4
        If LastSavedProcess.FanDia4 IsNot Nothing Then
            Me.cboFanDiameter4.Text = LastSavedProcess.FanDia4
        End If
        Me.cboFanQuantity4.Text = LastSavedProcess.FanQuantity4

        Me.numCompressorCoefficientsComboBox.SelectedIndex = 0
        If LastSavedProcess.Use10Coefficients = True Then Me.numCompressorCoefficientsComboBox.SelectedIndex = 1

        ' results
        Me.tabCondensingUnit.SelectedIndex = 2

        ' do not allow creation of equipment if this is a custom CU for balance program
        If IsBalance Then btnNewEquipmentPricing.Visible = False

        'LastSavedProcess.RateMe(CondensingUnitProcessItem.CondensingUnitRatingReturnType.condperDegreeBTUH)

    End Sub


    Sub loadCondenserCoilDropdown(ByVal ddl1 As ComboBox, ByVal rows As Integer, ByVal tubeDiameter As Decimal)

        If tubeDiameter = 0.5 Then
            loadCondenserCoilDropdown(ddl1, rows, "Smooth", tubeDiameter, "Waffle")
        Else
            loadCondenserCoilDropdown(ddl1, rows, "Rifled", tubeDiameter, "Waffle")
        End If

    End Sub


    Sub loadCondenserCoilDropdown(ByVal ddl1 As ComboBox, ByVal rows As Integer, ByVal tubeSurface As String, ByVal tubeDiameter As Double, ByVal finType As String)

        Dim ft1 As Rae.RaeSolutions.Business.Entities.Coil.FinType

        If finType Is Nothing Then finType = "FLAT"

        If finType.ToUpper = "FLAT" Then
            ft1 = Entities.Coil.FinType.Flat
        Else
            ft1 = Entities.Coil.FinType.Waffle
        End If


        Dim t As New Rae.RaeSolutions.Business.Entities.Coil(tubeDiameter, rows, "", Entities.Coil.CoilType.Condenser, ft1, tubeSurface)

        Dim j As Integer = ddl1.FindString(t.ToString)

        If j > -1 Then
            ddl1.SelectedIndex = j
        Else
            ddl1.SelectedIndex = 0
        End If

    End Sub



    'Sub loadCondenserCoilDropdown(ByVal ddl1 As ComboBox, ByVal rows As Integer, ByVal tubeSurface As String, ByVal tubeDiameter As Double, ByVal finType As String)

    '    Dim ft1 As Rae.RaeSolutions.Business.Entities.Coil.FinType

    '    If finType Is Nothing Then finType = "FLAT"

    '    If finType.ToUpper = "FLAT" Then
    '        ft1 = Entities.Coil.FinType.Flat
    '    Else
    '        ft1 = Entities.Coil.FinType.Waffle
    '    End If


    '    Dim t As New Rae.RaeSolutions.Business.Entities.Coil(tubeDiameter, rows, "", Entities.Coil.CoilType.Condenser, ft1, tubeSurface)

    '    Dim j As Integer = ddl1.FindString(t.ToString)

    '    If j > -1 Then
    '        ddl1.SelectedIndex = j
    '    Else
    '        ddl1.SelectedIndex = 0
    '    End If

    'End Sub





    Function SaveControls(Optional ByVal SaveAsRevision As Boolean = False, Optional ByVal SaveAsNew As Boolean = False, Optional ByVal FormClosing As Boolean = False, Optional ByVal GenerateEquipment As Boolean = False, Optional ByVal RevChanged As Boolean = False) As Boolean

        If CurrentStateProcess Is Nothing Then
            If LastSavedProcess Is Nothing Then
                CurrentStateProcess = New CondensingUnitProcessItem(New item_id(user.username, user.password))
            Else
                CurrentStateProcess = LastSavedProcess.Clone
            End If
        Else
            If LastSavedProcess IsNot Nothing Then CurrentStateProcess = LastSavedProcess.Clone
        End If

        With CurrentStateProcess

            ' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            ' SELECTION TAB...
            ' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            .Series = Me.cboCondensingUnitSeries.Text
            .CondensingUnitSeries = Me.cboCondensingUnitSeries.Text
            .CondensingUnitsRequired = Val(Me.txtCondensingUnitsRequired.Text)
            .Capacity = CDbl(Me.txtCapacity.Text)
            .RuntimeAdjust = Me.radRunTimeAdjustYes.Checked
            .Runtime = Val(Me.txtRunTime.Text)

            Dim ambientTemp As String = Me.txtRatingTabAmbient.Text
            Dim suctionTemp As String = Me.txt_rating_tab_suction.Text

            If IsNullOrEmpty(ambientTemp) Then
                ambientTemp = Me.txtSelectionTabAmbient.Text
            End If

            If IsNullOrEmpty(suctionTemp) Then
                suctionTemp = Me.txtSelectionTabSuction.Text
            End If

            .AmbientTemperature = Val(ambientTemp)
            .SuctionTemperature = Val(suctionTemp)
            .Refrigerant = Me.cboSelectionTabRefrigerant.Text
            .Compressor = Me.cboCompressor.Text
            .CompressorPerUnit = Val(Me.cboCompressorPerUnit.Text)
            .CircuitsPerUnit = Val(Me.cboCircuitsPerUnit.Text)
            .Altitude = Val(Me.txtSelectionTabAltitude.Text)

            ' Selection or rating?
            If radUnitRating.Checked = True Then
                .RunType = CondensingUnitProcessItem.eRunType.UnitRating
            ElseIf rbo_unit_selection.Checked = True Then
                .RunType = CondensingUnitProcessItem.eRunType.UnitSelection
            End If

            ' Notes
            .Notes = notesTextBox.Text

            ' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            ' RATING TAB...
            ' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            .Model = Me.lblRatingCondensingUnitModelValue.Text
            .CustomCondensingUnitModel = Me.txt_custom_model.Text
            .RatingAmbient = Val(ambientTemp)
            .RatingAmbientInterval = Val(Me.cboRatingAmbientInterval.Text)
            .RatingAmbientStep = Val(Me.cboRatingAmbientSteps.Text)
            .RatingSuction = Val(suctionTemp)
            .RatingSuctionInterval = Val(Me.cboRatingSuctionInterval.Text)
            .RatingSuctionStep = Val(Me.cboRatingSuctionSteps.Text)
            .RatingRefrigerant = Me.cbo_rating_tab_refrigerant.Text
            .RatingAltitude = Val(Me.txtRatingTabAltitude.Text)

            ' Sub cooling?  >0=Y  /  0=N
            If Me.cboRatingSubCooling.Text = "Y" Then
                .RatingSubCooling = Me.txt_subcooling_temperature.Text
            Else
                .RatingSubCooling = 0
            End If

            ' Catalog Standard or Rating...
            If Me.cboRatingCatalog.Text = "Catalog" Then
                .RatingCatalog = True
            Else
                .RatingCatalog = False
            End If

            .RatingHertz = Val(Me.cboRatingHertz.Text)

            ' Safety Rating...
            If Me.cboRatingSafety.Text = "N" Then
                .RatingSafety = False
            ElseIf Me.cboRatingSafety.Text = "Y" Then
                .RatingSafety = True
            End If

            ' circuit 1
            .Compressor1 = cbo_compressor_1.Text ' grabCompressor(cboCompressor1).File
            .CompressorQuantity1 = Val(Me.cbo_compressor_quantity_1.Text)


            Dim c1 As Rae.RaeSolutions.Business.Entities.Coil
            c1 = CType(coilComboBox_1.SelectedItem, Rae.RaeSolutions.Business.Entities.Coil)
            .CoilRows1 = c1.NumRows  ' 6/16/2016 ericc
            .TubeDiameter1 = c1.Diameter
            .TubeSurface1 = c1.TubeSurface
            .FinType1 = c1.FinDesign



            .CoilSubCoolingPercentage1 = Val(Me.txtCoilSubCoolingPercentage1.Text)
            .FinHeight1 = Val(Me.txt_fin_height_1.Text)
            .CoilFinWidth1 = Val(Me.txt_fin_length_1.Text)
            .FinsPerInch1 = Val(Me.cbo_fpi_1.Text)
            .FanDia1 = Me.cboFan1.Text
            .FanQuantity1 = Val(Me.cbo_fan_quantity_1.Text)

            .FanRPM1 = Val(Me.txtFanRPM1.Text)

            .DOEModel = Me.ddlDOEModels.Text


            ' circuit 2
            If Me.cbo_compressor_2.SelectedIndex < 0 Then
                Me.cbo_compressor_2.SelectedIndex = 0
            End If
            .Compressor2 = cbo_compressor_2.Text ' grabCompressor(cboCompressor2).File
            .CompressorQuantity2 = Val(Me.cbo_compressor_quantity_2.Text)
            '  .CoilRows2 = Val(Me.coilComboBox_2.SelectedItemt)  'eccond


            Dim c2 As Rae.RaeSolutions.Business.Entities.Coil
            c2 = CType(coilComboBox_2.SelectedItem, Rae.RaeSolutions.Business.Entities.Coil)

            If Not c2 Is Nothing Then

                .CoilRows2 = c2.NumRows
                .TubeDiameter2 = c2.Diameter
                .TubeSurface2 = c2.TubeSurface
                .FinType4 = c2.FinDesign

            End If

            .CoilSubCoolingPercentage2 = Val(Me.txtCoilSubCoolingPercentage2.Text)
            .FinHeight2 = Val(Me.txt_fin_height_2.Text)
            .CoilFinWidth2 = Val(Me.txt_fin_length_2.Text)
            .FinsPerInch2 = Val(Me.cbo_fpi_2.Text)
            .FanDia2 = Me.cboFan2.Text
            .FanQuantity2 = Val(Me.cbo_fan_quantity_2.Text)

            .FanRPM2 = Val(Me.lblFanRPM2.Text)

            ' circuit 3
            If Me.cboCompressor3.SelectedIndex < 0 Then
                Me.cboCompressor3.SelectedIndex = 0
            End If
            .Compressor3 = grab_compressor(cboCompressor3).MasterID
            .CompressorQuantity3 = Val(Me.cboCompressorQuantity3.Text)
            ' .CoilRows3 = Val(Me.cboCoilRows3.Text)
            .CoilSubCoolingPercentage3 = Val(Me.txtCoilSubCoolingPercentage3.Text)
            .FinHeight3 = Val(Me.txtCoilFinHeight3.Text)
            .CoilFinWidth3 = Val(Me.txtCoilFinWidth3.Text)
            .FinsPerInch3 = Val(Me.cboFinsPerInch3.Text)
            .FanDia3 = Me.cboFanDiameter3.Text
            .FanQuantity3 = Val(Me.cboFanQuantity3.Text)

            ' circuit 4
            If Me.cboCompressor4.SelectedIndex < 0 Then
                Me.cboCompressor4.SelectedIndex = 0
            End If
            .Compressor4 = grab_compressor(cboCompressor4).MasterID
            .CompressorQuantity4 = Val(Me.cboCompressorQuantity4.Text)
            .CoilRows4 = Val(Me.cboCoilRows4.Text)
            .CoilSubCoolingPercentage4 = Val(Me.txtCoilSubCoolingPercentage4.Text)
            .FinHeight4 = Val(Me.txtCoilFinHeight4.Text)
            .CoilFinWidth4 = Val(Me.txtCoilFinWidth4.Text)
            .FinsPerInch4 = Val(Me.cboFinsPerInch4.Text)
            .FanDia4 = Me.cboFanDiameter4.Text
            .FanQuantity4 = Val(Me.cboFanQuantity4.Text)

            .Use10Coefficients = False ' todo: set appropriately, used in balance program
            .Voltage = Me.grab_unit_voltage()
            .DOEModel = Me.ddlDOEModels.Text

        End With

        ' if this is associated with unit cooler balance
        ' we need to return the new CU process item now!

        If IsBalance Then
            Return True
        End If


        ' Set save process...
        Dim RevSave As New RevisionSave
        CurrentStateProcess = RevSave.SetSaveProcess(Me, Business.ProcessType.CondensingUnit, CurrentStateProcess, LastSavedProcess, SaveAsNew, SaveAsRevision, FormClosing, GenerateEquipment, RevChanged)
        If RevSave.CancelSave = True Then
            If CurrentStateProcess Is Nothing Then
                ' canceled
                RevSave = Nothing
                Return False
            Else
                ' do not save and continue to close
                RevSave = Nothing
                Return True
            End If
        End If

        ' Set last saved process...
        LastSavedProcess = RevSave.RevisionSaved(CurrentStateProcess)
        If RevSave.CancelSave = False Then
            ' only save if user chooses...
            'this is save? 

            CoolStuff.cl_connection.ExecuteSql("update CoolStuffProjects set processid = '" & Me.Tag & "' where id = " & btnCoolStuffInvoke.Tag, "UI")



            CurrentStateProcess = LastSavedProcess.Clone
            RevSave = Nothing
            'did the save
            Return True
        Else
            ' User cancelled form close...
            RevSave = Nothing
            Return False
        End If

    End Function

    ''' <summary>
    ''' Handles revision view control's revision changed event.
    ''' If user has unsaved changes, asks user to save before navigating revisions.
    ''' </summary>
    Private Sub RevisionView_RevisionChanged(ByVal sender As RevisionView, ByVal e As ValueChangedEventArgs(Of Single))
        If sender.ActiveProcessForm Is Me Then
            SaveControls(False, False, False, False, True)
        End If
    End Sub

    ''Private Sub mnuFilePrintCondensingUnits_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFilePrintCondensingUnits.Click
    ''    Me.Cursor = Cursors.WaitCursor

    ''    Dim doc As C1.C1PrintDocument.C1PrintDocument
    ''    Dim printStyle As C1.C1PrintDocument.C1DocStyle
    ''    Dim originalTab As TabPage

    ''    'constructs objects
    ''    doc = New C1.C1PrintDocument.C1PrintDocument
    ''    printStyle = New C1.C1PrintDocument.C1DocStyle(doc)
    ''    originalTab = New TabPage

    ''    printStyle.Font = New Font("Arial", 10, FontStyle.Regular)
    ''    'the page settings from frmC1PrintPreview.vb are not applied
    ''    'page settings must be set in code in order to be applied
    ''    doc.PageSettings.Margins.Top = 50 'in hundredths of an inch
    ''    doc.PageSettings.Margins.Bottom = 50

    ''    doc.DefaultUnit = C1.C1PrintDocument.UnitTypeEnum.Mm
    ''    'header
    ''    doc.PageHeader.Height = 8
    ''    doc.PageHeader.RenderText.Style = printStyle
    ''    doc.PageHeader.RenderText.Style.TextAlignHorz = C1.C1PrintDocument.AlignHorzEnum.Center
    ''    doc.PageHeader.RenderText.Style.TextAlignVert = C1.C1PrintDocument.AlignVertEnum.Top
    ''    doc.PageHeader.RenderText.Text = Me.Text
    ''    'footer
    ''    doc.PageFooter.Height = 8
    ''    doc.PageFooter.RenderText.Style = printStyle
    ''    doc.PageFooter.RenderText.Style.TextAlignHorz = C1.C1PrintDocument.AlignHorzEnum.Right
    ''    doc.PageFooter.RenderText.Style.TextAlignVert = C1.C1PrintDocument.AlignVertEnum.Bottom
    ''    doc.PageFooter.RenderText.Text = "Page [@@PageNo@@] of [@@PageCount@@]"

    ''    doc.StartDoc() 'start rendering
    ''    'remembers the tab page that was selected when print was clicked
    ''    'unless the tab being printed is selected, it won't render correctly
    ''    originalTab = Me.tabCondensingUnit.SelectedTab

    ''    'removes handler so routines won't run during tab navigation
    ''    RemoveHandler tabCondensingUnit.SelectedIndexChanged, _
    ''       AddressOf tabCondensingUnit_SelectedIndexChanged

    ''    'SELECTION TAB
    ''    Me.tabCondensingUnit.SelectedTab = Me.tabSelection
    ''    doc.RenderBlockText("Selection Tab")
    ''    'inputs
    ''    ''doc.RenderBlockControlImage(Me.inputsHeader)
    ''    doc.RenderBlockControlImage(Me.panInputsBody)
    ''    'outputs
    ''    If Me.rbo_unit_selection.Checked = True Then
    ''        ''doc.RenderBlockControlImage(Me.outputsHeader)
    ''        doc.RenderBlockControlSmart(Me.BestSelectionsGrid1)
    ''        doc.RenderBlockControlImage(Me.panSelectCondensingUnit)
    ''    ElseIf Me.radUnitRating.Checked = True Then
    ''        ''doc.RenderBlockControlImage(Me.ratingModelHeader)
    ''        doc.RenderBlockControlImage(Me.panRatingBody)
    ''    End If

    'page return
    ''Dim whiteImage As Image  'image is used to fill unused space at the end of a page
    ''    'in effect it is a page return
    ''    whiteImage = Image.FromFile(AppInfo.AppFolderPath & "Images\whitebox.gif")
    ''    doc.RenderBlockImage(whiteImage, 3, doc.AvailableBlockFlowHeight, printStyle)
    ''    'RATING TAB
    ''    Me.tabCondensingUnit.SelectedTab = Me.tabRating
    ''    doc.RenderBlockText("Rating Tab")
    ''    ''doc.RenderBlockControlImage(Me.ratingHeader)
    ''    doc.RenderBlockControlImage(Me.panRatingDataBody)
    ''    doc.RenderBlockControlImage(Me.panRatingHideFromRep)
    ''    doc.RenderBlockControlImage(Me.panRatingCircuitBody)

    ''    'page return
    ''    doc.RenderBlockImage(whiteImage, 3, doc.AvailableBlockFlowHeight, printStyle)
    ''    'RESULTS TAB
    ''    Me.tabCondensingUnit.SelectedTab = Me.tabResults
    ''    doc.RenderBlockText("Results Tab")
    ''    ''doc.RenderBlockControlSmart(Me.dgrC1Results)

    ''    'set back to original tab
    ''    Me.tabCondensingUnit.SelectedTab = originalTab

    ''    'adds event handler back to handle tab navigation again
    ''    AddHandler tabCondensingUnit.SelectedIndexChanged, _
    ''       AddressOf tabCondensingUnit_SelectedIndexChanged
    ''    doc.EndDoc() 'stop rendering

    ''    Dim formPreview As New C1PrintPreviewForm 'create instance form to preview before printing
    ''    formPreview.C1PrintPreview1.Document = doc 'set the form's document to the document just created
    ''    formPreview.ShowDialog() 'can't have mdiparent otherwise error occurs
    ''    formPreview.Dispose()

    ''    Me.Cursor = Cursors.Arrow
    ''End Sub

    Private Sub SaveMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles SaveCondToolStripMenuItem.Click
        SaveControls()
    End Sub

    Private Sub ConvertToEquipmentToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ConvertToEquipmentToolStripMenuItem.Click
        ' Force user to save before creating equipment...
        SaveControls(False, False, False, True)
    End Sub

    Private Sub SaveAsRevisionMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles RevisionCondensingUnitRatingToolStripMenuItem.Click
        SaveControls(True)
    End Sub

    Private Sub SaveAsNewMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsNewMenuItem.Click
        SaveControls(False, True)
    End Sub

    ''' <summary>
    ''' Initializes save tool strip panel. Sets event handlers and tool strip.
    ''' </summary>
    Private Sub initializeSaveToolStripPanel()
        If Not IsBalance Then
            Me.SaveToolStripPanel1.SetUp(CType(Me.ParentForm, MainForm).mainToolStrip, _
               AddressOf SaveMenuItem_Click, AddressOf SaveAsRevisionMenuItem_Click)
        End If
    End Sub

    Private Sub btnNewEquipmentPricing_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNewEquipmentPricing.Click
        ' Force user to save before creating equipment...
        SaveControls(False, False, False, True)
    End Sub

    Private Sub timerHighlightReturn_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timerHighlightReturn.Tick

        If Me.tabCondensingUnit.TabIndex <> 2 Then
            timerHighlightReturn.Enabled = False
            warn("You must first rate this condensing unit before you return to the balance program.")
        Else
            Static i As Integer
            If i = 4 Then
                i = 0
                timerHighlightReturn.Enabled = False
            End If
            Dim ProtoFont As System.Drawing.Font = btnReturn.Font
            If btnReturn.Font.Bold Then
                btnReturn.Font = New System.Drawing.Font(ProtoFont, FontStyle.Regular)
                btnReturn.BackColor = Color.White
            Else
                btnReturn.Font = New System.Drawing.Font(ProtoFont, FontStyle.Bold)
                btnReturn.BackColor = Color.Khaki
            End If
            i += i
        End If
    End Sub


    Private Function setControlsForBoxLoad( _
    ByVal capacity As Single, ByVal runVar As String, _
    ByVal ambient As String, ByVal boxLoadName As String) As Boolean
        txtCapacity.Text = capacity
        txtRunTime.Text = runVar
        txtSelectionTabAmbient.Text = ambient
        txtCoolStuffBLName.Text = boxLoadName

        txtCapacity.Enabled = False
        txtRunTime.Enabled = False
        txtSelectionTabAmbient.Enabled = False
    End Function

    Private Function askUserToSaveBeforeLinkingToBoxLoad() As Boolean
        Dim prompt As Persistence.IAskUserToSave = New Persistence.AskUserToSave( _
           "Please save before linking to a box load?", _
           New String() {}, _
           New Persistence.StringDictionary() _
              .Add("Save", "Save and view available box loads") _
              .Add("Cancel", "Do not save and do not link to box load."))

        Dim canceled As Boolean
        Dim response = prompt.Ask()
        Select Case response.SelectedCommand
            Case "Save"
                Me.SaveControls()
            Case Else
                canceled = True
        End Select

        Return canceled
    End Function

    Private Sub btnCoolStuffInvoke_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles btnCoolStuffInvoke.Click
        Dim isSaved As Boolean = (LastSavedProcess IsNot Nothing)

        If Not isSaved Then
            If askUserToSaveBeforeLinkingToBoxLoad() Then _
               Exit Sub
        End If

        Dim prompt As ISelectBoxLoad = New BoxLoadLinksForm()
        Dim response As ISelectBoxLoadResponse
        Dim fromProject As String = OpenedProject.ProjectId.ToString
        response = prompt.AskUserToSelectBoxLoad(fromProject)

        Dim dbId As Integer
        If response.Result = SelectBoxLoadResult.Canceled Then
            Exit Sub
        End If

        dbId = response.SelectedBoxLoadDbId
        Dim b As New BoxLoad()
        b.Load(dbId)

        setControlsForBoxLoad(b.LoadTotal, b.RunVar, b.Ambient, b.name)
        txtCoolStuffID.Text = dbId
        txtCoolStuffBLName.Text = b.name
        Me.btnCoolStuffInvoke.Tag = dbId

        ' CoolStuffInvoke()
        btnRemoveBoxLoadLink.Visible = True
        btnCoolStuffInvoke.Visible = False

        Dim da As New Rae.Data.Access.BoxLoadProjects()
        da.UpdateLink(dbId, Me.Tag, 0)

        AppInfo.Main.BoxLoadListView1.Link(b.id.ToString)
    End Sub

    Private Sub btnRemoveBoxLoadLink_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles btnRemoveBoxLoadLink.Click
        Dim boxLoadId As Integer = btnCoolStuffInvoke.Tag
        Dim da As New Rae.Data.Access.BoxLoadProjects()
        da.DeleteLink(boxLoadId)

        'CoolStuff.cl_connection.ExecuteSql("update coolstuffprojects set processid = CreatedWhen where id = " & btnCoolStuffInvoke.Tag, "UI")
        btnCoolStuffInvoke.Tag = 0
        txtRunTime.Enabled = True
        txtSelectionTabAmbient.Enabled = True
        txtCoolStuffBLName.Text = ""
        btnCoolStuffInvoke.Visible = True
        btnRemoveBoxLoadLink.Visible = False
        txtCapacity.Enabled = True

        Dim b As New BoxLoad()
        b.Load(boxLoadId)
        AppInfo.Main.BoxLoadListView1.Unlink(b.id.ToString)

    End Sub

    ' Doesn't cause infinite loop, because once the values are synced the index doesn't change.
    Private Sub voltageComboBox_SelectedIndexChanged(ByVal s As Object, ByVal e As EventArgs) _
    Handles voltageComboBox.SelectedIndexChanged, voltageRatingComboBox.SelectedIndexChanged
        Dim other As ComboBox = IIf(s Is voltageComboBox, voltageRatingComboBox, voltageComboBox)
        syncVoltages(s, other)
    End Sub

    Private Sub syncVoltages(ByVal changedCombobox As ComboBox, ByVal comboboxToSync As ComboBox)
        If changedCombobox.SelectedItem Is Nothing Then _
           Exit Sub

        Dim voltage = CInt(changedCombobox.SelectedItem)
        comboboxToSync.SelectedIndex = comboboxToSync.Items.IndexOf(voltage)
    End Sub

    Private Sub cboCondensingUnitSeries_SelectedIndexChanged() Handles cboCondensingUnitSeries.SelectedIndexChanged
        If cboCondensingUnitSeries.SelectedItem = "20A4" Then
            ControlAssistant.SelectComboboxItem(cboSelectionTabRefrigerant, "R410a")
        End If


        fillVoltages(voltages(cboCondensingUnitSeries.SelectedItem))


    End Sub



    Private Sub cboSelectionTabRefrigerant_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSelectionTabRefrigerant.SelectedIndexChanged
        fillModelComboboxes()

    End Sub


    Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click
        Try
            showBestUnits()
        Catch ex As Exception
            alert(ex.Message)
        End Try
    End Sub

    Private Sub txtFanRPM1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFanRPM1.Leave
        Try

            If (Not String.IsNullOrWhiteSpace(txtFanRPM1.Text)) AndAlso (Not IsNumeric(txtFanRPM1.Text)) Then
                txtFanRPM1.Text = cu.circuits(0).fanOperatingRPM
            End If

            Dim maxRPM As Decimal = CType(cboFan1.SelectedItem, Fan).CurveRPM
            If CDec(txtFanRPM1.Text) > maxRPM Then
                txtFanRPM1.Text = maxRPM
                MsgBox("The RPM You Entered Exceeds Max! Setting RPM to " & maxRPM)
            End If

        Catch ex As Exception

        End Try





    End Sub

    Private Sub txtFanRPM2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFanRPM2.Leave
        Try

            If (Not String.IsNullOrWhiteSpace(txtFanRPM2.Text)) AndAlso (Not IsNumeric(txtFanRPM2.Text)) Then
                txtFanRPM2.Text = cu.circuits(1).fanOperatingRPM
            End If

            Dim maxRPM As Decimal = CType(cboFan2.SelectedItem, Fan).CurveRPM
            If CDec(txtFanRPM2.Text) > maxRPM Then
                txtFanRPM2.Text = maxRPM
                MsgBox("The RPM You Entered Exceeds Max! Setting RPM to " & maxRPM)
            End If

        Catch ex As Exception

        End Try



    End Sub

    Private Sub doe_affectors_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbo_compressor_1.SelectedIndexChanged, cbo_compressor_quantity_1.SelectedIndexChanged, coilComboBox_1.SelectedIndexChanged, txt_fin_height_1.TextChanged, txt_fin_length_1.TextChanged, cbo_fpi_1.SelectedIndexChanged, cbo_fan_quantity_1.SelectedIndexChanged, cbo_compressor_2.SelectedIndexChanged, cbo_compressor_quantity_2.SelectedIndexChanged, coilComboBox_2.SelectedIndexChanged, txt_fin_height_2.TextChanged, txt_fin_length_2.TextChanged, cbo_fpi_2.SelectedIndexChanged, cbo_fan_quantity_2.SelectedIndexChanged
        If Not Me.IsUnitRated = True Then Exit Sub
        txtDOECompliant.Text = "No"




        'Dim circuitCount As Decimal = 1

        'If Me.tabCondensingUnit.Contains(Me.tabCircuit2) Then
        '    circuitCount = 2
        'End If

        'Dim compressorMasterID1 As String = ""
        'If cbo_compressor_1.Text.Contains(")") Then
        '    compressorMasterID1 = cbo_compressor_1.Text.Substring(cbo_compressor_1.Text.IndexOf("("))
        '    compressorMasterID1 = compressorMasterID1.Substring(1, compressorMasterID1.IndexOf(")") - 1)
        'End If

        'Dim compressorMasterID2 As String = ""
        'If circuitCount > 1 AndAlso cbo_compressor_2.Text.Contains(")") Then
        '    compressorMasterID2 = cbo_compressor_2.Text.Substring(cbo_compressor_2.Text.IndexOf("("))
        '    compressorMasterID2 = compressorMasterID2.Substring(1, compressorMasterID2.IndexOf(")") - 1)
        'End If


        'Dim compressorQty1 As Decimal, CoilID1 As String, FinHeight1 As Decimal, FinLength1 As Decimal, FPI1 As Decimal, Subcooling1 As Decimal, FanID1 As String, FanQty1 As Decimal
        'Dim compressorQty2 As Decimal, CoilID2 As String, FinHeight2 As Decimal, FinLength2 As Decimal, FPI2 As Decimal, Subcooling2 As Decimal, FanID2 As String, FanQty2 As Decimal


        'Dim isDOE As Boolean = New condensing_units.Repository().CheckDOE(lblRatingCondensingUnitModelValue.Text, circuitCount, compressorMasterID1, compressorQty1, CoilID1, FinHeight1, FinLength1, FPI1, Subcooling1, FanID1, FanQty1, compressorMasterID2, compressorQty2, CoilID2, FinHeight2, FinLength2, FPI2, Subcooling2, FanID2, FanQty2)

        'If isDOE Then
        '    txtDOECompliant.Text = "True"
        'Else
        '    txtDOECompliant.Text = "False"
        'End If

    End Sub

    Private Sub cboVoltage_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles voltageComboBox.SelectedIndexChanged

    End Sub

    Private Sub ddlDOEModels_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddlDOEModels.SelectedIndexChanged
        fillModelComboboxes()
    End Sub
End Class
'73636