Option Strict Off

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.OleDb
Imports System.Math
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Imports Rae.Collections
Imports Rae.math.Calculate
Imports Rae.math.comparisons
Imports Rae.solutions
Imports Rae.solutions.air_cooled_chillers
Imports Rae.solutions.air_cooled_chillers.chiller
Imports Rae.solutions.Chillers
Imports Rae.solutions.compressors
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.solutions.group
Imports Rae.RaeSolutions.DataAccess
Imports Rae.Ui.quickies
Imports Rae.utilities
Imports Rae.Ui.Validation

Imports VB = Microsoft.VisualBasic
Imports GlycolNames = Rae.RaeSolutions.DataAccess.Chillers.GlycolColumnNames
Imports BCI = Rae.RaeSolutions.Business.Intelligence.Chillers
Imports BCA = Rae.RaeSolutions.Business.Agents.ChillerAgent
Imports BCE = Rae.solutions.Chillers
Imports Logic = Rae.RaeSolutions.Business.Intelligence
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert

Public Class air_cooled_chiller_balance_window : Inherits BaseChillerForm
    Implements fluid_properties.i_view_part
    ' Friend userClass As user

    Public ProcessDeleted As Boolean
    Friend WithEvents saveAsRevisionMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents saveAsMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents convertToEquipmentMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    ' Revision Control / Saving Variables...
    ' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    ' Last saved state...
    Public LastSavedProcess As Rae.RaeSolutions.Business.Entities.ACChillerProcessItem
    ' Current state before save...
    Public CurrentStateProcess As Rae.RaeSolutions.Business.Entities.ACChillerProcessItem
    ' Current displayed state revision
    ' number reference...
    Private _currentrevision As Single = -1
    Friend WithEvents SaveToolStripPanel1 As Rae.RaeSolutions.SaveToolStripPanel
    Friend WithEvents capacityFactorLabel As System.Windows.Forms.Label
    Friend WithEvents capacityFactorTextBox As System.Windows.Forms.TextBox
    Private WithEvents btn_go_to_pricing As System.Windows.Forms.Button
    Friend WithEvents controlFactorsPanel As System.Windows.Forms.Panel
    Friend WithEvents compressorAmpFactorTextBox As System.Windows.Forms.TextBox
    Friend WithEvents compressorKwFactorTextBox As System.Windows.Forms.TextBox
    Friend WithEvents compressorCapacityFactorTextBox As System.Windows.Forms.TextBox
    Friend WithEvents compressorAmpFactorLabel As System.Windows.Forms.Label
    Friend WithEvents compressorKwFactorLabel As System.Windows.Forms.Label
    Friend WithEvents compressorCapacityFactorLabel As System.Windows.Forms.Label
    Friend WithEvents condenserCapacityFactorLabel As System.Windows.Forms.Label
    Friend WithEvents condenserCapacityFactorTextBox As System.Windows.Forms.TextBox
    Friend WithEvents optionsHeaderLabel As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EvaporatorGrid1 As Rae.RaeSolutions.EvaporatorGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCompressorMasterID2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCompressorMasterID1 As System.Windows.Forms.TextBox
    Friend WithEvents Grid1 As Grid
    ''Friend WithEvents EvaporateGrid As Grid

    ''' <summary>The current revision # of process being displayed on this form.</summary>
    Property CurrentRevision As Single
        Get
            Return _currentrevision
        End Get
        Set(ByVal value As Single)
            _currentrevision = value
        End Set
    End Property


    Private _latestRevision As Single = -1
    ''' <summary>The latest revision # of process being displayed on this form.</summary>
    Property LatestRevision As Single
        Get
            Return _latestRevision
        End Get
        Set(ByVal value As Single)
            _latestRevision = value
        End Set
    End Property
    ' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

#Region " Windows Form Designer generated code "

    Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call

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
    Friend WithEvents panCirc As System.Windows.Forms.Panel
    Friend WithEvents panMain As System.Windows.Forms.Panel
    Friend WithEvents panRatiCritHide As System.Windows.Forms.Panel
    Friend WithEvents panCompDataHide As System.Windows.Forms.Panel
    Friend WithEvents panCondHide As System.Windows.Forms.Panel
    Friend WithEvents lblErro As System.Windows.Forms.Label
    Friend WithEvents DropDownList1 As System.Windows.Forms.ComboBox
    Friend WithEvents DropDownList2 As System.Windows.Forms.ComboBox
    Friend WithEvents DropDownList3 As System.Windows.Forms.ComboBox
    Friend WithEvents txtNumCircuits As System.Windows.Forms.TextBox
    Friend WithEvents txtCondenser_1 As System.Windows.Forms.TextBox
    Friend WithEvents txtCondenser_2 As System.Windows.Forms.TextBox
    Friend WithEvents panEvapHide As System.Windows.Forms.Panel
    Friend WithEvents panGrid As System.Windows.Forms.Panel
    Friend WithEvents lblOperLimi As System.Windows.Forms.Label
    Friend WithEvents cboVolts As System.Windows.Forms.ComboBox
    Friend WithEvents txtEvapLength As System.Windows.Forms.TextBox
    Friend WithEvents lblRatiVolt As System.Windows.Forms.Label
    Friend WithEvents lblRatiVolt1 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents panFooter As System.Windows.Forms.Panel
    Friend WithEvents picError As System.Windows.Forms.PictureBox
    Friend WithEvents btn_calculate_page As System.Windows.Forms.Button
    Friend WithEvents btn_create_report As System.Windows.Forms.Button
    Friend WithEvents lblCFM As System.Windows.Forms.Label
    Friend WithEvents modelLabel As System.Windows.Forms.Label
    Friend WithEvents cbo_series As System.Windows.Forms.ComboBox
    Friend WithEvents btnGlycolChart As System.Windows.Forms.Button
    Friend WithEvents lblRatingCriteria As System.Windows.Forms.Label
    Friend WithEvents lblCondenser As System.Windows.Forms.Label
    Friend WithEvents lblCompressor As System.Windows.Forms.Label
    Friend WithEvents lineRatingCriteria As System.Windows.Forms.Button
    Friend WithEvents lineCompressor As System.Windows.Forms.Button
    Friend WithEvents lineCondenser As System.Windows.Forms.Button
    Friend WithEvents lineEvaporator As System.Windows.Forms.Button
    Friend WithEvents panButtons As System.Windows.Forms.Panel
    Friend WithEvents panEvaporatorHeader As System.Windows.Forms.Panel
    Friend WithEvents panCondenser As System.Windows.Forms.Panel
    Friend WithEvents panCondenserHeader As System.Windows.Forms.Panel
    Friend WithEvents panCompressor As System.Windows.Forms.Panel
    Friend WithEvents panCompressorHeader As System.Windows.Forms.Panel
    Friend WithEvents panRatingCriteria As System.Windows.Forms.Panel
    Friend WithEvents panRatingCriteriaHeader As System.Windows.Forms.Panel
    Friend WithEvents lblEvaporator As System.Windows.Forms.Label
    Friend WithEvents lblRangeF As System.Windows.Forms.Label
    Friend WithEvents lblAmbientF As System.Windows.Forms.Label
    Friend WithEvents lblLeavingFluidF As System.Windows.Forms.Label
    Friend WithEvents lblSubCoolingF As System.Windows.Forms.Label
    Friend WithEvents lblFreezePointF As System.Windows.Forms.Label
    Friend WithEvents lblMinSuctionF As System.Windows.Forms.Label
    Friend WithEvents lblCondenserTD2F As System.Windows.Forms.Label
    Friend WithEvents lblAltitudeFt As System.Windows.Forms.Label
    Friend WithEvents lblDischargeLineLossF As System.Windows.Forms.Label
    Friend WithEvents lblCondenserTD1F As System.Windows.Forms.Label
    Friend WithEvents lblCondenserCapacityBtuh As System.Windows.Forms.Label
    Friend WithEvents lblApplies3 As System.Windows.Forms.Label
    Friend WithEvents lblApplies2 As System.Windows.Forms.Label
    Friend WithEvents lblApplies1 As System.Windows.Forms.Label
    Friend WithEvents lblApplies4 As System.Windows.Forms.Label
    Friend WithEvents lblCondenserCapacityF As System.Windows.Forms.Label
    Friend WithEvents lblSuctionLineLossF As System.Windows.Forms.Label
    Friend WithEvents lblCondSubCoolingPercent2 As System.Windows.Forms.Label
    Friend WithEvents lblCondSubCoolingPercent1 As System.Windows.Forms.Label
    Friend WithEvents btn_alternate_evaporators As System.Windows.Forms.Button
    Friend WithEvents btnEvaporatorPlus As System.Windows.Forms.Button
    Friend WithEvents btnCondenserPlus As System.Windows.Forms.Button
    Friend WithEvents btnCompressorPlus As System.Windows.Forms.Button
    Friend WithEvents btnCriteriaPlus As System.Windows.Forms.Button
    Friend WithEvents cbo_models As System.Windows.Forms.ComboBox
    Friend WithEvents lblSeries As System.Windows.Forms.Label
    Friend WithEvents txt_model As System.Windows.Forms.TextBox
    Friend WithEvents lblApproach As System.Windows.Forms.Label
    Friend WithEvents lblHertz As System.Windows.Forms.Label
    Friend WithEvents lblSystem As System.Windows.Forms.Label
    Friend WithEvents lblFreezingPoint As System.Windows.Forms.Label
    Friend WithEvents lblSpecificGravity As System.Windows.Forms.Label
    Friend WithEvents lblSpecificHeat As System.Windows.Forms.Label
    Friend WithEvents lblGlycolPercentage As System.Windows.Forms.Label
    Friend WithEvents lblFluid As System.Windows.Forms.Label
    Friend WithEvents lblCoolingMedia As System.Windows.Forms.Label
    Friend WithEvents lblMinSuctionTemp As System.Windows.Forms.Label
    Friend WithEvents lblSubCooling As System.Windows.Forms.Label
    Friend WithEvents lblLeavingFluidTemp As System.Windows.Forms.Label
    Friend WithEvents lblAmbientTemp As System.Windows.Forms.Label
    Friend WithEvents lblTempRange As System.Windows.Forms.Label
    Friend WithEvents lblRefrigerant As System.Windows.Forms.Label
    Friend WithEvents lblFoulingFactor As System.Windows.Forms.Label
    Friend WithEvents lblEvaporatorModel As System.Windows.Forms.Label
    Friend WithEvents lblFan As System.Windows.Forms.Label
    Friend WithEvents lblCondenserCapacity2 As System.Windows.Forms.Label
    Friend WithEvents lblAltitude As System.Windows.Forms.Label
    Friend WithEvents lblSuctionLineLoss As System.Windows.Forms.Label
    Friend WithEvents lblDischargeLineLoss As System.Windows.Forms.Label
    Friend WithEvents lblFanWatts As System.Windows.Forms.Label
    Friend WithEvents lblCondenserCapacity1 As System.Windows.Forms.Label
    Friend WithEvents lblNumFans2 As System.Windows.Forms.Label
    Friend WithEvents lblNumFans1 As System.Windows.Forms.Label
    Friend WithEvents lblFinLength2 As System.Windows.Forms.Label
    Friend WithEvents lblFinLength1 As System.Windows.Forms.Label
    Friend WithEvents lblFinHeight2 As System.Windows.Forms.Label
    Friend WithEvents lblFinHeight1 As System.Windows.Forms.Label
    Friend WithEvents lblCondenserTD2 As System.Windows.Forms.Label
    Friend WithEvents lblCondenserTD1 As System.Windows.Forms.Label
    Friend WithEvents lblSubCooling2 As System.Windows.Forms.Label
    Friend WithEvents lblSubCooling1 As System.Windows.Forms.Label
    Friend WithEvents lblFinsPerInch2 As System.Windows.Forms.Label
    Friend WithEvents lblFinsPerInch1 As System.Windows.Forms.Label
    Friend WithEvents lblCondenser2 As System.Windows.Forms.Label
    Friend WithEvents lblCondenser1 As System.Windows.Forms.Label
    Friend WithEvents lblNumCoils2 As System.Windows.Forms.Label
    Friend WithEvents lblNumCoils1 As System.Windows.Forms.Label
    Friend WithEvents lblNumCompressors2 As System.Windows.Forms.Label
    Friend WithEvents lblCompressor2 As System.Windows.Forms.Label
    Friend WithEvents lblNumCompressors1 As System.Windows.Forms.Label
    Friend WithEvents lblCompressor1 As System.Windows.Forms.Label
    Friend WithEvents modelPanel As System.Windows.Forms.Panel
    Friend WithEvents txtFreezingPoint As System.Windows.Forms.TextBox
    Friend WithEvents txtSpecificGravity As System.Windows.Forms.TextBox
    Friend WithEvents txtSpecificHeat As System.Windows.Forms.TextBox
    Friend WithEvents txtGlycolPercentage As System.Windows.Forms.TextBox
    Friend WithEvents cboFluid As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_cooling_media As System.Windows.Forms.ComboBox
    Friend WithEvents txtSuctionTemp As System.Windows.Forms.TextBox
    Friend WithEvents txtSubCooling As System.Windows.Forms.TextBox
    Friend WithEvents txtApproach As System.Windows.Forms.TextBox
    Friend WithEvents cboHertz As System.Windows.Forms.ComboBox
    Friend WithEvents cboSystem As System.Windows.Forms.ComboBox
    Friend WithEvents txtLeavingFluidTemp As System.Windows.Forms.TextBox
    Friend WithEvents txtAmbientTemp As System.Windows.Forms.TextBox
    Friend WithEvents txtTempRange As System.Windows.Forms.TextBox
    Friend WithEvents cboRefrigerant As System.Windows.Forms.ComboBox
    Friend WithEvents chkSafetyOverride As System.Windows.Forms.CheckBox
    Friend WithEvents txtNumCompressors2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCompressor2 As System.Windows.Forms.TextBox
    Friend WithEvents txtNumCompressors1 As System.Windows.Forms.TextBox
    Friend WithEvents txtCompressor1 As System.Windows.Forms.TextBox
    Friend WithEvents lboCompressors2 As System.Windows.Forms.ListBox
    Friend WithEvents lboCompressors1 As System.Windows.Forms.ListBox
    Friend WithEvents radCircuit2 As System.Windows.Forms.RadioButton
    Friend WithEvents radCircuit1 As System.Windows.Forms.RadioButton
    Friend WithEvents txtAltitude As System.Windows.Forms.TextBox
    Friend WithEvents cboSuctionLineLoss As System.Windows.Forms.ComboBox
    Friend WithEvents cboDischargeLineLoss As System.Windows.Forms.ComboBox
    Friend WithEvents txtFanWatts As System.Windows.Forms.TextBox
    Friend WithEvents cboFan As System.Windows.Forms.ComboBox
    Friend WithEvents txtNumFans2 As System.Windows.Forms.TextBox
    Friend WithEvents txtNumFans1 As System.Windows.Forms.TextBox
    Friend WithEvents txtFinLength2 As System.Windows.Forms.TextBox
    Friend WithEvents txtFinLength1 As System.Windows.Forms.TextBox
    Friend WithEvents txtFinHeight2 As System.Windows.Forms.TextBox
    Friend WithEvents txtFinHeight1 As System.Windows.Forms.TextBox
    Friend WithEvents txtCondenserTD2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCondenserTD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtSubCooling2 As System.Windows.Forms.TextBox
    Friend WithEvents txtSubCooling1 As System.Windows.Forms.TextBox
    Friend WithEvents cboSubCooling2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSubCooling1 As System.Windows.Forms.ComboBox
    Friend WithEvents cboFinsPerInch1 As System.Windows.Forms.ComboBox
    Friend WithEvents cboFinsPerInch2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboCondenser2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboCondenser1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtNumCoils1 As System.Windows.Forms.TextBox
    Friend WithEvents txtNumCoils2 As System.Windows.Forms.TextBox
    Friend WithEvents lblCircuit2 As System.Windows.Forms.Label
    Friend WithEvents lblCircuit1 As System.Windows.Forms.Label
    Friend WithEvents txtCfmOverride As System.Windows.Forms.TextBox
    Friend WithEvents txtCondenserCapacity2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCondenserCapacity1 As System.Windows.Forms.TextBox
    Friend WithEvents chkCatalogRating As System.Windows.Forms.CheckBox
    Friend WithEvents cboFoulingFactor As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_evaporator_model As System.Windows.Forms.ComboBox
    Friend WithEvents txt_evaporator_model As System.Windows.Forms.TextBox
    Friend WithEvents txtEvaporatorCapacity As System.Windows.Forms.TextBox
    Friend WithEvents radGpm As System.Windows.Forms.RadioButton
    Friend WithEvents radTons As System.Windows.Forms.RadioButton
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents fileMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents printMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents saveMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents err As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(air_cooled_chiller_balance_window))
        Me.modelLabel = New System.Windows.Forms.Label()
        Me.panMain = New System.Windows.Forms.Panel()
        Me.panGrid = New System.Windows.Forms.Panel()
        Me.Grid1 = New Rae.RaeSolutions.Grid()
        Me.lblOperLimi = New System.Windows.Forms.Label()
        Me.panEvapHide = New System.Windows.Forms.Panel()
        Me.radGpm = New System.Windows.Forms.RadioButton()
        Me.EvaporatorGrid1 = New Rae.RaeSolutions.EvaporatorGrid()
        Me.txtEvapLength = New System.Windows.Forms.TextBox()
        Me.chkCatalogRating = New System.Windows.Forms.CheckBox()
        Me.cboFoulingFactor = New System.Windows.Forms.ComboBox()
        Me.btn_alternate_evaporators = New System.Windows.Forms.Button()
        Me.lblFoulingFactor = New System.Windows.Forms.Label()
        Me.txtEvaporatorCapacity = New System.Windows.Forms.TextBox()
        Me.radTons = New System.Windows.Forms.RadioButton()
        Me.cbo_evaporator_model = New System.Windows.Forms.ComboBox()
        Me.lblEvaporatorModel = New System.Windows.Forms.Label()
        Me.txt_evaporator_model = New System.Windows.Forms.TextBox()
        Me.panEvaporatorHeader = New System.Windows.Forms.Panel()
        Me.lineEvaporator = New System.Windows.Forms.Button()
        Me.btnEvaporatorPlus = New System.Windows.Forms.Button()
        Me.lblEvaporator = New System.Windows.Forms.Label()
        Me.panCondHide = New System.Windows.Forms.Panel()
        Me.txtCondenser_2 = New System.Windows.Forms.TextBox()
        Me.txtCondenser_1 = New System.Windows.Forms.TextBox()
        Me.txtNumCircuits = New System.Windows.Forms.TextBox()
        Me.DropDownList3 = New System.Windows.Forms.ComboBox()
        Me.DropDownList2 = New System.Windows.Forms.ComboBox()
        Me.DropDownList1 = New System.Windows.Forms.ComboBox()
        Me.panCondenser = New System.Windows.Forms.Panel()
        Me.lblCondenserTD2F = New System.Windows.Forms.Label()
        Me.lblAltitudeFt = New System.Windows.Forms.Label()
        Me.lblSuctionLineLossF = New System.Windows.Forms.Label()
        Me.lblDischargeLineLossF = New System.Windows.Forms.Label()
        Me.lblCondenserTD1F = New System.Windows.Forms.Label()
        Me.lblFan = New System.Windows.Forms.Label()
        Me.lblCondenserCapacityF = New System.Windows.Forms.Label()
        Me.lblCondenserCapacity2 = New System.Windows.Forms.Label()
        Me.lblCondenserCapacityBtuh = New System.Windows.Forms.Label()
        Me.lblApplies3 = New System.Windows.Forms.Label()
        Me.lblAltitude = New System.Windows.Forms.Label()
        Me.txtAltitude = New System.Windows.Forms.TextBox()
        Me.lblApplies2 = New System.Windows.Forms.Label()
        Me.cboSuctionLineLoss = New System.Windows.Forms.ComboBox()
        Me.lblSuctionLineLoss = New System.Windows.Forms.Label()
        Me.lblApplies1 = New System.Windows.Forms.Label()
        Me.lblDischargeLineLoss = New System.Windows.Forms.Label()
        Me.cboDischargeLineLoss = New System.Windows.Forms.ComboBox()
        Me.lblApplies4 = New System.Windows.Forms.Label()
        Me.lblFanWatts = New System.Windows.Forms.Label()
        Me.txtFanWatts = New System.Windows.Forms.TextBox()
        Me.cboFan = New System.Windows.Forms.ComboBox()
        Me.txtCondenserCapacity2 = New System.Windows.Forms.TextBox()
        Me.txtCondenserCapacity1 = New System.Windows.Forms.TextBox()
        Me.lblCondenserCapacity1 = New System.Windows.Forms.Label()
        Me.txtNumFans2 = New System.Windows.Forms.TextBox()
        Me.txtNumFans1 = New System.Windows.Forms.TextBox()
        Me.lblNumFans2 = New System.Windows.Forms.Label()
        Me.lblNumFans1 = New System.Windows.Forms.Label()
        Me.txtFinLength2 = New System.Windows.Forms.TextBox()
        Me.txtFinLength1 = New System.Windows.Forms.TextBox()
        Me.lblFinLength2 = New System.Windows.Forms.Label()
        Me.lblFinLength1 = New System.Windows.Forms.Label()
        Me.txtFinHeight2 = New System.Windows.Forms.TextBox()
        Me.txtFinHeight1 = New System.Windows.Forms.TextBox()
        Me.lblFinHeight2 = New System.Windows.Forms.Label()
        Me.lblFinHeight1 = New System.Windows.Forms.Label()
        Me.txtCondenserTD2 = New System.Windows.Forms.TextBox()
        Me.lblCondenserTD2 = New System.Windows.Forms.Label()
        Me.txtCondenserTD1 = New System.Windows.Forms.TextBox()
        Me.lblCondenserTD1 = New System.Windows.Forms.Label()
        Me.lblCondSubCoolingPercent2 = New System.Windows.Forms.Label()
        Me.lblCondSubCoolingPercent1 = New System.Windows.Forms.Label()
        Me.txtSubCooling2 = New System.Windows.Forms.TextBox()
        Me.txtSubCooling1 = New System.Windows.Forms.TextBox()
        Me.cboSubCooling2 = New System.Windows.Forms.ComboBox()
        Me.lblSubCooling2 = New System.Windows.Forms.Label()
        Me.cboSubCooling1 = New System.Windows.Forms.ComboBox()
        Me.lblSubCooling1 = New System.Windows.Forms.Label()
        Me.cboFinsPerInch1 = New System.Windows.Forms.ComboBox()
        Me.cboFinsPerInch2 = New System.Windows.Forms.ComboBox()
        Me.lblFinsPerInch2 = New System.Windows.Forms.Label()
        Me.lblFinsPerInch1 = New System.Windows.Forms.Label()
        Me.cboCondenser2 = New System.Windows.Forms.ComboBox()
        Me.lblCondenser2 = New System.Windows.Forms.Label()
        Me.cboCondenser1 = New System.Windows.Forms.ComboBox()
        Me.lblCondenser1 = New System.Windows.Forms.Label()
        Me.txtNumCoils1 = New System.Windows.Forms.TextBox()
        Me.txtNumCoils2 = New System.Windows.Forms.TextBox()
        Me.lblNumCoils2 = New System.Windows.Forms.Label()
        Me.lblNumCoils1 = New System.Windows.Forms.Label()
        Me.lblCircuit2 = New System.Windows.Forms.Label()
        Me.lblCircuit1 = New System.Windows.Forms.Label()
        Me.txtCfmOverride = New System.Windows.Forms.TextBox()
        Me.lblCFM = New System.Windows.Forms.Label()
        Me.panCondenserHeader = New System.Windows.Forms.Panel()
        Me.lineCondenser = New System.Windows.Forms.Button()
        Me.btnCondenserPlus = New System.Windows.Forms.Button()
        Me.lblCondenser = New System.Windows.Forms.Label()
        Me.panCompDataHide = New System.Windows.Forms.Panel()
        Me.panCompressor = New System.Windows.Forms.Panel()
        Me.txtCompressorMasterID2 = New System.Windows.Forms.TextBox()
        Me.txtCompressorMasterID1 = New System.Windows.Forms.TextBox()
        Me.chkSafetyOverride = New System.Windows.Forms.CheckBox()
        Me.lblNumCompressors2 = New System.Windows.Forms.Label()
        Me.lblCompressor2 = New System.Windows.Forms.Label()
        Me.txtNumCompressors2 = New System.Windows.Forms.TextBox()
        Me.txtCompressor2 = New System.Windows.Forms.TextBox()
        Me.lblNumCompressors1 = New System.Windows.Forms.Label()
        Me.txtNumCompressors1 = New System.Windows.Forms.TextBox()
        Me.txtCompressor1 = New System.Windows.Forms.TextBox()
        Me.lblCompressor1 = New System.Windows.Forms.Label()
        Me.lboCompressors2 = New System.Windows.Forms.ListBox()
        Me.lboCompressors1 = New System.Windows.Forms.ListBox()
        Me.panCirc = New System.Windows.Forms.Panel()
        Me.radCircuit2 = New System.Windows.Forms.RadioButton()
        Me.radCircuit1 = New System.Windows.Forms.RadioButton()
        Me.panCompressorHeader = New System.Windows.Forms.Panel()
        Me.lineCompressor = New System.Windows.Forms.Button()
        Me.btnCompressorPlus = New System.Windows.Forms.Button()
        Me.lblCompressor = New System.Windows.Forms.Label()
        Me.panRatiCritHide = New System.Windows.Forms.Panel()
        Me.panRatingCriteria = New System.Windows.Forms.Panel()
        Me.cboVolts = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblRangeF = New System.Windows.Forms.Label()
        Me.lblAmbientF = New System.Windows.Forms.Label()
        Me.lblLeavingFluidF = New System.Windows.Forms.Label()
        Me.lblSubCoolingF = New System.Windows.Forms.Label()
        Me.lblFreezePointF = New System.Windows.Forms.Label()
        Me.lblMinSuctionF = New System.Windows.Forms.Label()
        Me.lblRatiVolt = New System.Windows.Forms.Label()
        Me.btnGlycolChart = New System.Windows.Forms.Button()
        Me.txtApproach = New System.Windows.Forms.TextBox()
        Me.lblApproach = New System.Windows.Forms.Label()
        Me.lblRatiVolt1 = New System.Windows.Forms.Label()
        Me.cboHertz = New System.Windows.Forms.ComboBox()
        Me.lblHertz = New System.Windows.Forms.Label()
        Me.cboSystem = New System.Windows.Forms.ComboBox()
        Me.lblSystem = New System.Windows.Forms.Label()
        Me.txtFreezingPoint = New System.Windows.Forms.TextBox()
        Me.lblFreezingPoint = New System.Windows.Forms.Label()
        Me.lblSpecificGravity = New System.Windows.Forms.Label()
        Me.lblSpecificHeat = New System.Windows.Forms.Label()
        Me.txtSpecificGravity = New System.Windows.Forms.TextBox()
        Me.txtSpecificHeat = New System.Windows.Forms.TextBox()
        Me.txtGlycolPercentage = New System.Windows.Forms.TextBox()
        Me.lblGlycolPercentage = New System.Windows.Forms.Label()
        Me.cboFluid = New System.Windows.Forms.ComboBox()
        Me.lblFluid = New System.Windows.Forms.Label()
        Me.cbo_cooling_media = New System.Windows.Forms.ComboBox()
        Me.lblCoolingMedia = New System.Windows.Forms.Label()
        Me.txtSuctionTemp = New System.Windows.Forms.TextBox()
        Me.lblMinSuctionTemp = New System.Windows.Forms.Label()
        Me.txtSubCooling = New System.Windows.Forms.TextBox()
        Me.lblSubCooling = New System.Windows.Forms.Label()
        Me.txtLeavingFluidTemp = New System.Windows.Forms.TextBox()
        Me.lblLeavingFluidTemp = New System.Windows.Forms.Label()
        Me.lblAmbientTemp = New System.Windows.Forms.Label()
        Me.txtAmbientTemp = New System.Windows.Forms.TextBox()
        Me.lblTempRange = New System.Windows.Forms.Label()
        Me.txtTempRange = New System.Windows.Forms.TextBox()
        Me.lblRefrigerant = New System.Windows.Forms.Label()
        Me.cboRefrigerant = New System.Windows.Forms.ComboBox()
        Me.panRatingCriteriaHeader = New System.Windows.Forms.Panel()
        Me.lineRatingCriteria = New System.Windows.Forms.Button()
        Me.btnCriteriaPlus = New System.Windows.Forms.Button()
        Me.lblRatingCriteria = New System.Windows.Forms.Label()
        Me.controlFactorsPanel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.optionsHeaderLabel = New System.Windows.Forms.Label()
        Me.condenserCapacityFactorTextBox = New System.Windows.Forms.TextBox()
        Me.compressorAmpFactorTextBox = New System.Windows.Forms.TextBox()
        Me.compressorKwFactorTextBox = New System.Windows.Forms.TextBox()
        Me.compressorCapacityFactorTextBox = New System.Windows.Forms.TextBox()
        Me.compressorAmpFactorLabel = New System.Windows.Forms.Label()
        Me.capacityFactorTextBox = New System.Windows.Forms.TextBox()
        Me.compressorKwFactorLabel = New System.Windows.Forms.Label()
        Me.compressorCapacityFactorLabel = New System.Windows.Forms.Label()
        Me.condenserCapacityFactorLabel = New System.Windows.Forms.Label()
        Me.capacityFactorLabel = New System.Windows.Forms.Label()
        Me.modelPanel = New System.Windows.Forms.Panel()
        Me.cbo_models = New System.Windows.Forms.ComboBox()
        Me.cbo_series = New System.Windows.Forms.ComboBox()
        Me.lblSeries = New System.Windows.Forms.Label()
        Me.txt_model = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.fileMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.saveMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.saveAsRevisionMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.saveAsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.convertToEquipmentMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.printMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_go_to_pricing = New System.Windows.Forms.Button()
        Me.btn_create_report = New System.Windows.Forms.Button()
        Me.lblErro = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.panFooter = New System.Windows.Forms.Panel()
        Me.panButtons = New System.Windows.Forms.Panel()
        Me.btn_calculate_page = New System.Windows.Forms.Button()
        Me.picError = New System.Windows.Forms.PictureBox()
        Me.err = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.SaveToolStripPanel1 = New Rae.RaeSolutions.SaveToolStripPanel()
        CType(Me.results, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panMain.SuspendLayout()
        Me.panGrid.SuspendLayout()
        ''CType(Me.EvaporateGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panEvapHide.SuspendLayout()
        Me.panEvaporatorHeader.SuspendLayout()
        Me.panCondHide.SuspendLayout()
        Me.panCondenser.SuspendLayout()
        Me.panCondenserHeader.SuspendLayout()
        Me.panCompDataHide.SuspendLayout()
        Me.panCompressor.SuspendLayout()
        Me.panCirc.SuspendLayout()
        Me.panCompressorHeader.SuspendLayout()
        Me.panRatiCritHide.SuspendLayout()
        Me.panRatingCriteria.SuspendLayout()
        Me.panRatingCriteriaHeader.SuspendLayout()
        Me.controlFactorsPanel.SuspendLayout()
        Me.modelPanel.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.panFooter.SuspendLayout()
        Me.panButtons.SuspendLayout()
        CType(Me.picError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.err, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'modelLabel
        '
        Me.modelLabel.Location = New System.Drawing.Point(4, 36)
        Me.modelLabel.Name = "modelLabel"
        Me.modelLabel.Size = New System.Drawing.Size(64, 21)
        Me.modelLabel.TabIndex = 0
        Me.modelLabel.Text = "Model #"
        Me.modelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panMain
        '
        Me.panMain.AutoScroll = True
        Me.panMain.BackColor = System.Drawing.Color.White
        Me.panMain.Controls.Add(Me.panGrid)
        Me.panMain.Controls.Add(Me.panEvapHide)
        Me.panMain.Controls.Add(Me.panEvaporatorHeader)
        Me.panMain.Controls.Add(Me.panCondHide)
        Me.panMain.Controls.Add(Me.panCondenserHeader)
        Me.panMain.Controls.Add(Me.panCompDataHide)
        Me.panMain.Controls.Add(Me.panCompressorHeader)
        Me.panMain.Controls.Add(Me.panRatiCritHide)
        Me.panMain.Controls.Add(Me.panRatingCriteriaHeader)
        Me.panMain.Controls.Add(Me.controlFactorsPanel)
        Me.panMain.Controls.Add(Me.modelPanel)
        Me.panMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panMain.Location = New System.Drawing.Point(0, 0)
        Me.panMain.Name = "panMain"
        Me.panMain.Size = New System.Drawing.Size(688, 521)
        Me.panMain.TabIndex = 3
        '
        'panGrid
        '
        Me.panGrid.BackColor = System.Drawing.Color.White
        Me.panGrid.Controls.Add(Me.Grid1)
        Me.panGrid.Controls.Add(Me.lblOperLimi)
        Me.panGrid.Dock = System.Windows.Forms.DockStyle.Top
        Me.panGrid.Location = New System.Drawing.Point(0, 1655)
        Me.panGrid.Name = "panGrid"
        Me.panGrid.Size = New System.Drawing.Size(671, 300)
        Me.panGrid.TabIndex = 20
        '
        'Grid1
        '
        Me.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid1.Location = New System.Drawing.Point(12, 24)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Size = New System.Drawing.Size(644, 270)
        Me.Grid1.TabIndex = 4
        Me.Grid1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray
        Me.Grid1.EnableHeadersVisualStyles = False
        Me.Grid1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue
        Me.Grid1.RowHeadersVisible = False
        Me.Grid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.Grid1.MultiSelect = False
        '''
        '''EvaporateGrid
        '''
        ''Me.EvaporateGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        ''Me.EvaporateGrid.Location = New System.Drawing.Point(12, 24)
        ''Me.EvaporateGrid.Name = "Grid1"
        ''Me.EvaporateGrid.Size = New System.Drawing.Size(644, 270)
        ''Me.EvaporateGrid.TabIndex = 4
        '
        'lblOperLimi
        '
        Me.lblOperLimi.BackColor = System.Drawing.Color.Transparent
        Me.lblOperLimi.ForeColor = System.Drawing.Color.Red
        Me.lblOperLimi.Location = New System.Drawing.Point(12, 4)
        Me.lblOperLimi.Name = "lblOperLimi"
        Me.lblOperLimi.Size = New System.Drawing.Size(640, 17)
        Me.lblOperLimi.TabIndex = 0
        Me.lblOperLimi.Text = "Points outside operating range omitted."
        Me.lblOperLimi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'panEvapHide
        '
        Me.panEvapHide.BackColor = System.Drawing.Color.White
        Me.panEvapHide.Controls.Add(Me.radGpm)
        Me.panEvapHide.Controls.Add(Me.EvaporatorGrid1)
        ''Me.panEvapHide.Controls.Add(Me.EvaporateGrid)
        Me.panEvapHide.Controls.Add(Me.txtEvapLength)
        Me.panEvapHide.Controls.Add(Me.chkCatalogRating)
        Me.panEvapHide.Controls.Add(Me.cboFoulingFactor)
        Me.panEvapHide.Controls.Add(Me.btn_alternate_evaporators)
        Me.panEvapHide.Controls.Add(Me.lblFoulingFactor)
        Me.panEvapHide.Controls.Add(Me.txtEvaporatorCapacity)
        Me.panEvapHide.Controls.Add(Me.radTons)
        Me.panEvapHide.Controls.Add(Me.cbo_evaporator_model)
        Me.panEvapHide.Controls.Add(Me.lblEvaporatorModel)
        Me.panEvapHide.Controls.Add(Me.txt_evaporator_model)
        Me.panEvapHide.Dock = System.Windows.Forms.DockStyle.Top
        Me.panEvapHide.Location = New System.Drawing.Point(0, 1175)
        Me.panEvapHide.Name = "panEvapHide"
        Me.panEvapHide.Padding = New System.Windows.Forms.Padding(10)
        Me.panEvapHide.Size = New System.Drawing.Size(671, 480)
        Me.panEvapHide.TabIndex = 9
        '
        'radGpm
        '
        Me.radGpm.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.radGpm.Location = New System.Drawing.Point(425, 34)
        Me.radGpm.Name = "radGpm"
        Me.radGpm.Size = New System.Drawing.Size(53, 24)
        Me.radGpm.TabIndex = 7
        Me.radGpm.Text = "GPM"
        '
        'EvaporatorGrid1
        '
        Me.EvaporatorGrid1.BackColor = System.Drawing.Color.White
        Me.EvaporatorGrid1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.EvaporatorGrid1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EvaporatorGrid1.ForeColor = System.Drawing.Color.Black
        Me.EvaporatorGrid1.Location = New System.Drawing.Point(10, 89)
        Me.EvaporatorGrid1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.EvaporatorGrid1.Name = "EvaporatorGrid1"
        Me.EvaporatorGrid1.Size = New System.Drawing.Size(651, 381)
        Me.EvaporatorGrid1.TabIndex = 50
        '
        'txtEvapLength
        '
        Me.txtEvapLength.Location = New System.Drawing.Point(653, 37)
        Me.txtEvapLength.Name = "txtEvapLength"
        Me.txtEvapLength.Size = New System.Drawing.Size(100, 21)
        Me.txtEvapLength.TabIndex = 3
        Me.txtEvapLength.Visible = False
        '
        'chkCatalogRating
        '
        Me.chkCatalogRating.AutoSize = True
        Me.chkCatalogRating.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkCatalogRating.Location = New System.Drawing.Point(481, 64)
        Me.chkCatalogRating.Name = "chkCatalogRating"
        Me.chkCatalogRating.Size = New System.Drawing.Size(100, 18)
        Me.chkCatalogRating.TabIndex = 8
        Me.chkCatalogRating.Text = "Catalog rating"
        '
        'cboFoulingFactor
        '
        Me.cboFoulingFactor.Items.AddRange(New Object() {".0001", ".00025", ".0005", ".00075", ".001"})
        Me.cboFoulingFactor.Location = New System.Drawing.Point(481, 6)
        Me.cboFoulingFactor.Name = "cboFoulingFactor"
        Me.cboFoulingFactor.Size = New System.Drawing.Size(72, 21)
        Me.cboFoulingFactor.TabIndex = 4
        Me.cboFoulingFactor.Text = ".0001"
        '
        'btn_alternate_evaporators
        '
        Me.btn_alternate_evaporators.BackColor = System.Drawing.SystemColors.Control
        Me.btn_alternate_evaporators.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_alternate_evaporators.Location = New System.Drawing.Point(7, 6)
        Me.btn_alternate_evaporators.Name = "btn_alternate_evaporators"
        Me.btn_alternate_evaporators.Size = New System.Drawing.Size(156, 23)
        Me.btn_alternate_evaporators.TabIndex = 1
        Me.btn_alternate_evaporators.Text = "Select Alternate Evaporators"
        Me.btn_alternate_evaporators.UseVisualStyleBackColor = False
        '
        'lblFoulingFactor
        '
        Me.lblFoulingFactor.Location = New System.Drawing.Point(373, 6)
        Me.lblFoulingFactor.Name = "lblFoulingFactor"
        Me.lblFoulingFactor.Size = New System.Drawing.Size(100, 23)
        Me.lblFoulingFactor.TabIndex = 37
        Me.lblFoulingFactor.Text = "Fouling factor"
        Me.lblFoulingFactor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEvaporatorCapacity
        '
        Me.txtEvaporatorCapacity.Location = New System.Drawing.Point(481, 34)
        Me.txtEvaporatorCapacity.Name = "txtEvaporatorCapacity"
        Me.txtEvaporatorCapacity.Size = New System.Drawing.Size(72, 21)
        Me.txtEvaporatorCapacity.TabIndex = 5
        Me.txtEvaporatorCapacity.Text = "0"
        '
        'radTons
        '
        Me.radTons.Checked = True
        Me.radTons.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.radTons.Location = New System.Drawing.Point(361, 34)
        Me.radTons.Name = "radTons"
        Me.radTons.Size = New System.Drawing.Size(68, 24)
        Me.radTons.TabIndex = 6
        Me.radTons.TabStop = True
        Me.radTons.Text = "Tons or"
        '
        'cbo_evaporator_model
        '
        Me.cbo_evaporator_model.Location = New System.Drawing.Point(171, 7)
        Me.cbo_evaporator_model.Name = "cbo_evaporator_model"
        Me.cbo_evaporator_model.Size = New System.Drawing.Size(144, 21)
        Me.cbo_evaporator_model.TabIndex = 2
        Me.cbo_evaporator_model.Visible = False
        '
        'lblEvaporatorModel
        '
        Me.lblEvaporatorModel.Location = New System.Drawing.Point(51, 35)
        Me.lblEvaporatorModel.Name = "lblEvaporatorModel"
        Me.lblEvaporatorModel.Size = New System.Drawing.Size(110, 23)
        Me.lblEvaporatorModel.TabIndex = 33
        Me.lblEvaporatorModel.Text = "Evaporator model #"
        Me.lblEvaporatorModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_evaporator_model
        '
        Me.txt_evaporator_model.Location = New System.Drawing.Point(171, 35)
        Me.txt_evaporator_model.Name = "txt_evaporator_model"
        Me.txt_evaporator_model.Size = New System.Drawing.Size(144, 21)
        Me.txt_evaporator_model.TabIndex = 3
        '
        'panEvaporatorHeader
        '
        Me.panEvaporatorHeader.BackColor = System.Drawing.Color.White
        Me.panEvaporatorHeader.Controls.Add(Me.lineEvaporator)
        Me.panEvaporatorHeader.Controls.Add(Me.btnEvaporatorPlus)
        Me.panEvaporatorHeader.Controls.Add(Me.lblEvaporator)
        Me.panEvaporatorHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panEvaporatorHeader.Location = New System.Drawing.Point(0, 1131)
        Me.panEvaporatorHeader.Name = "panEvaporatorHeader"
        Me.panEvaporatorHeader.Size = New System.Drawing.Size(671, 44)
        Me.panEvaporatorHeader.TabIndex = 8
        '
        'lineEvaporator
        '
        Me.lineEvaporator.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lineEvaporator.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.lineEvaporator.Location = New System.Drawing.Point(12, 40)
        Me.lineEvaporator.Name = "lineEvaporator"
        Me.lineEvaporator.Size = New System.Drawing.Size(500, 2)
        Me.lineEvaporator.TabIndex = 7
        Me.lineEvaporator.Text = "Button4"
        '
        'btnEvaporatorPlus
        '
        Me.btnEvaporatorPlus.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnEvaporatorPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEvaporatorPlus.Font = New System.Drawing.Font("Garamond", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEvaporatorPlus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnEvaporatorPlus.Location = New System.Drawing.Point(16, 19)
        Me.btnEvaporatorPlus.Name = "btnEvaporatorPlus"
        Me.btnEvaporatorPlus.Size = New System.Drawing.Size(20, 18)
        Me.btnEvaporatorPlus.TabIndex = 1
        Me.btnEvaporatorPlus.Text = "-"
        Me.btnEvaporatorPlus.UseVisualStyleBackColor = False
        '
        'lblEvaporator
        '
        Me.lblEvaporator.BackColor = System.Drawing.Color.White
        Me.lblEvaporator.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEvaporator.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.lblEvaporator.Location = New System.Drawing.Point(44, 16)
        Me.lblEvaporator.Name = "lblEvaporator"
        Me.lblEvaporator.Size = New System.Drawing.Size(464, 23)
        Me.lblEvaporator.TabIndex = 0
        Me.lblEvaporator.Text = "Evaporator"
        Me.lblEvaporator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'panCondHide
        '
        Me.panCondHide.BackColor = System.Drawing.Color.White
        Me.panCondHide.Controls.Add(Me.txtCondenser_2)
        Me.panCondHide.Controls.Add(Me.txtCondenser_1)
        Me.panCondHide.Controls.Add(Me.txtNumCircuits)
        Me.panCondHide.Controls.Add(Me.DropDownList3)
        Me.panCondHide.Controls.Add(Me.DropDownList2)
        Me.panCondHide.Controls.Add(Me.DropDownList1)
        Me.panCondHide.Controls.Add(Me.panCondenser)
        Me.panCondHide.Dock = System.Windows.Forms.DockStyle.Top
        Me.panCondHide.Location = New System.Drawing.Point(0, 711)
        Me.panCondHide.Name = "panCondHide"
        Me.panCondHide.Size = New System.Drawing.Size(671, 420)
        Me.panCondHide.TabIndex = 7
        '
        'txtCondenser_2
        '
        Me.txtCondenser_2.Location = New System.Drawing.Point(653, 41)
        Me.txtCondenser_2.Name = "txtCondenser_2"
        Me.txtCondenser_2.Size = New System.Drawing.Size(100, 21)
        Me.txtCondenser_2.TabIndex = 7
        Me.txtCondenser_2.Visible = False
        '
        'txtCondenser_1
        '
        Me.txtCondenser_1.Location = New System.Drawing.Point(653, 20)
        Me.txtCondenser_1.Name = "txtCondenser_1"
        Me.txtCondenser_1.Size = New System.Drawing.Size(100, 21)
        Me.txtCondenser_1.TabIndex = 6
        Me.txtCondenser_1.Visible = False
        '
        'txtNumCircuits
        '
        Me.txtNumCircuits.BackColor = System.Drawing.SystemColors.Info
        Me.txtNumCircuits.Location = New System.Drawing.Point(653, 194)
        Me.txtNumCircuits.Name = "txtNumCircuits"
        Me.txtNumCircuits.Size = New System.Drawing.Size(100, 21)
        Me.txtNumCircuits.TabIndex = 4
        Me.txtNumCircuits.Visible = False
        '
        'DropDownList3
        '
        Me.DropDownList3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DropDownList3.Location = New System.Drawing.Point(653, 139)
        Me.DropDownList3.Name = "DropDownList3"
        Me.DropDownList3.Size = New System.Drawing.Size(121, 21)
        Me.DropDownList3.TabIndex = 3
        Me.DropDownList3.Visible = False
        '
        'DropDownList2
        '
        Me.DropDownList2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DropDownList2.Location = New System.Drawing.Point(653, 116)
        Me.DropDownList2.Name = "DropDownList2"
        Me.DropDownList2.Size = New System.Drawing.Size(121, 21)
        Me.DropDownList2.TabIndex = 2
        Me.DropDownList2.Visible = False
        '
        'DropDownList1
        '
        Me.DropDownList1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DropDownList1.Location = New System.Drawing.Point(653, 93)
        Me.DropDownList1.Name = "DropDownList1"
        Me.DropDownList1.Size = New System.Drawing.Size(121, 21)
        Me.DropDownList1.TabIndex = 1
        Me.DropDownList1.Visible = False
        '
        'panCondenser
        '
        Me.panCondenser.BackColor = System.Drawing.Color.White
        Me.panCondenser.Controls.Add(Me.lblCondenserTD2F)
        Me.panCondenser.Controls.Add(Me.lblAltitudeFt)
        Me.panCondenser.Controls.Add(Me.lblSuctionLineLossF)
        Me.panCondenser.Controls.Add(Me.lblDischargeLineLossF)
        Me.panCondenser.Controls.Add(Me.lblCondenserTD1F)
        Me.panCondenser.Controls.Add(Me.lblFan)
        Me.panCondenser.Controls.Add(Me.lblCondenserCapacityF)
        Me.panCondenser.Controls.Add(Me.lblCondenserCapacity2)
        Me.panCondenser.Controls.Add(Me.lblCondenserCapacityBtuh)
        Me.panCondenser.Controls.Add(Me.lblApplies3)
        Me.panCondenser.Controls.Add(Me.lblAltitude)
        Me.panCondenser.Controls.Add(Me.txtAltitude)
        Me.panCondenser.Controls.Add(Me.lblApplies2)
        Me.panCondenser.Controls.Add(Me.cboSuctionLineLoss)
        Me.panCondenser.Controls.Add(Me.lblSuctionLineLoss)
        Me.panCondenser.Controls.Add(Me.lblApplies1)
        Me.panCondenser.Controls.Add(Me.lblDischargeLineLoss)
        Me.panCondenser.Controls.Add(Me.cboDischargeLineLoss)
        Me.panCondenser.Controls.Add(Me.lblApplies4)
        Me.panCondenser.Controls.Add(Me.lblFanWatts)
        Me.panCondenser.Controls.Add(Me.txtFanWatts)
        Me.panCondenser.Controls.Add(Me.cboFan)
        Me.panCondenser.Controls.Add(Me.txtCondenserCapacity2)
        Me.panCondenser.Controls.Add(Me.txtCondenserCapacity1)
        Me.panCondenser.Controls.Add(Me.lblCondenserCapacity1)
        Me.panCondenser.Controls.Add(Me.txtNumFans2)
        Me.panCondenser.Controls.Add(Me.txtNumFans1)
        Me.panCondenser.Controls.Add(Me.lblNumFans2)
        Me.panCondenser.Controls.Add(Me.lblNumFans1)
        Me.panCondenser.Controls.Add(Me.txtFinLength2)
        Me.panCondenser.Controls.Add(Me.txtFinLength1)
        Me.panCondenser.Controls.Add(Me.lblFinLength2)
        Me.panCondenser.Controls.Add(Me.lblFinLength1)
        Me.panCondenser.Controls.Add(Me.txtFinHeight2)
        Me.panCondenser.Controls.Add(Me.txtFinHeight1)
        Me.panCondenser.Controls.Add(Me.lblFinHeight2)
        Me.panCondenser.Controls.Add(Me.lblFinHeight1)
        Me.panCondenser.Controls.Add(Me.txtCondenserTD2)
        Me.panCondenser.Controls.Add(Me.lblCondenserTD2)
        Me.panCondenser.Controls.Add(Me.txtCondenserTD1)
        Me.panCondenser.Controls.Add(Me.lblCondenserTD1)
        Me.panCondenser.Controls.Add(Me.lblCondSubCoolingPercent2)
        Me.panCondenser.Controls.Add(Me.lblCondSubCoolingPercent1)
        Me.panCondenser.Controls.Add(Me.txtSubCooling2)
        Me.panCondenser.Controls.Add(Me.txtSubCooling1)
        Me.panCondenser.Controls.Add(Me.cboSubCooling2)
        Me.panCondenser.Controls.Add(Me.lblSubCooling2)
        Me.panCondenser.Controls.Add(Me.cboSubCooling1)
        Me.panCondenser.Controls.Add(Me.lblSubCooling1)
        Me.panCondenser.Controls.Add(Me.cboFinsPerInch1)
        Me.panCondenser.Controls.Add(Me.cboFinsPerInch2)
        Me.panCondenser.Controls.Add(Me.lblFinsPerInch2)
        Me.panCondenser.Controls.Add(Me.lblFinsPerInch1)
        Me.panCondenser.Controls.Add(Me.cboCondenser2)
        Me.panCondenser.Controls.Add(Me.lblCondenser2)
        Me.panCondenser.Controls.Add(Me.cboCondenser1)
        Me.panCondenser.Controls.Add(Me.lblCondenser1)
        Me.panCondenser.Controls.Add(Me.txtNumCoils1)
        Me.panCondenser.Controls.Add(Me.txtNumCoils2)
        Me.panCondenser.Controls.Add(Me.lblNumCoils2)
        Me.panCondenser.Controls.Add(Me.lblNumCoils1)
        Me.panCondenser.Controls.Add(Me.lblCircuit2)
        Me.panCondenser.Controls.Add(Me.lblCircuit1)
        Me.panCondenser.Controls.Add(Me.txtCfmOverride)
        Me.panCondenser.Controls.Add(Me.lblCFM)
        Me.panCondenser.Location = New System.Drawing.Point(12, 0)
        Me.panCondenser.Name = "panCondenser"
        Me.panCondenser.Size = New System.Drawing.Size(635, 420)
        Me.panCondenser.TabIndex = 1
        '
        'lblCondenserTD2F
        '
        Me.lblCondenserTD2F.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblCondenserTD2F.Location = New System.Drawing.Point(499, 144)
        Me.lblCondenserTD2F.Name = "lblCondenserTD2F"
        Me.lblCondenserTD2F.Size = New System.Drawing.Size(28, 21)
        Me.lblCondenserTD2F.TabIndex = 64
        Me.lblCondenserTD2F.Text = "°F"
        Me.lblCondenserTD2F.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAltitudeFt
        '
        Me.lblAltitudeFt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblAltitudeFt.Location = New System.Drawing.Point(192, 284)
        Me.lblAltitudeFt.Name = "lblAltitudeFt"
        Me.lblAltitudeFt.Size = New System.Drawing.Size(28, 21)
        Me.lblAltitudeFt.TabIndex = 63
        Me.lblAltitudeFt.Text = "ft."
        Me.lblAltitudeFt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSuctionLineLossF
        '
        Me.lblSuctionLineLossF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblSuctionLineLossF.Location = New System.Drawing.Point(192, 256)
        Me.lblSuctionLineLossF.Name = "lblSuctionLineLossF"
        Me.lblSuctionLineLossF.Size = New System.Drawing.Size(28, 21)
        Me.lblSuctionLineLossF.TabIndex = 62
        Me.lblSuctionLineLossF.Text = "°F"
        Me.lblSuctionLineLossF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDischargeLineLossF
        '
        Me.lblDischargeLineLossF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblDischargeLineLossF.Location = New System.Drawing.Point(192, 228)
        Me.lblDischargeLineLossF.Name = "lblDischargeLineLossF"
        Me.lblDischargeLineLossF.Size = New System.Drawing.Size(28, 21)
        Me.lblDischargeLineLossF.TabIndex = 61
        Me.lblDischargeLineLossF.Text = "°F"
        Me.lblDischargeLineLossF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCondenserTD1F
        '
        Me.lblCondenserTD1F.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblCondenserTD1F.Location = New System.Drawing.Point(192, 144)
        Me.lblCondenserTD1F.Name = "lblCondenserTD1F"
        Me.lblCondenserTD1F.Size = New System.Drawing.Size(28, 21)
        Me.lblCondenserTD1F.TabIndex = 60
        Me.lblCondenserTD1F.Text = "°F"
        Me.lblCondenserTD1F.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFan
        '
        Me.lblFan.Location = New System.Drawing.Point(4, 312)
        Me.lblFan.Name = "lblFan"
        Me.lblFan.Size = New System.Drawing.Size(104, 23)
        Me.lblFan.TabIndex = 58
        Me.lblFan.Text = "Fan"
        Me.lblFan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCondenserCapacityF
        '
        Me.lblCondenserCapacityF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblCondenserCapacityF.Location = New System.Drawing.Point(495, 396)
        Me.lblCondenserCapacityF.Name = "lblCondenserCapacityF"
        Me.lblCondenserCapacityF.Size = New System.Drawing.Size(64, 23)
        Me.lblCondenserCapacityF.TabIndex = 57
        Me.lblCondenserCapacityF.Text = "at 25°F TD"
        Me.lblCondenserCapacityF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCondenserCapacity2
        '
        Me.lblCondenserCapacity2.Location = New System.Drawing.Point(307, 392)
        Me.lblCondenserCapacity2.Name = "lblCondenserCapacity2"
        Me.lblCondenserCapacity2.Size = New System.Drawing.Size(108, 28)
        Me.lblCondenserCapacity2.TabIndex = 56
        Me.lblCondenserCapacity2.Text = "Condenser est. capacity"
        Me.lblCondenserCapacity2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCondenserCapacityBtuh
        '
        Me.lblCondenserCapacityBtuh.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblCondenserCapacityBtuh.Location = New System.Drawing.Point(192, 396)
        Me.lblCondenserCapacityBtuh.Name = "lblCondenserCapacityBtuh"
        Me.lblCondenserCapacityBtuh.Size = New System.Drawing.Size(48, 23)
        Me.lblCondenserCapacityBtuh.TabIndex = 55
        Me.lblCondenserCapacityBtuh.Text = "BTUH (est.)"
        Me.lblCondenserCapacityBtuh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblApplies3
        '
        Me.lblApplies3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblApplies3.Location = New System.Drawing.Point(363, 284)
        Me.lblApplies3.Name = "lblApplies3"
        Me.lblApplies3.Size = New System.Drawing.Size(180, 23)
        Me.lblApplies3.TabIndex = 54
        Me.lblApplies3.Text = "Circuit 1 applies for both circuits"
        Me.lblApplies3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAltitude
        '
        Me.lblAltitude.Location = New System.Drawing.Point(4, 284)
        Me.lblAltitude.Name = "lblAltitude"
        Me.lblAltitude.Size = New System.Drawing.Size(104, 23)
        Me.lblAltitude.TabIndex = 53
        Me.lblAltitude.Text = "Altitude"
        Me.lblAltitude.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAltitude
        '
        Me.txtAltitude.Location = New System.Drawing.Point(116, 284)
        Me.txtAltitude.Name = "txtAltitude"
        Me.txtAltitude.Size = New System.Drawing.Size(72, 21)
        Me.txtAltitude.TabIndex = 11
        Me.txtAltitude.Text = "0"
        '
        'lblApplies2
        '
        Me.lblApplies2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblApplies2.Location = New System.Drawing.Point(363, 256)
        Me.lblApplies2.Name = "lblApplies2"
        Me.lblApplies2.Size = New System.Drawing.Size(180, 23)
        Me.lblApplies2.TabIndex = 51
        Me.lblApplies2.Text = "Circuit 1 applies for both circuits"
        Me.lblApplies2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSuctionLineLoss
        '
        Me.cboSuctionLineLoss.Items.AddRange(New Object() {"0", "0.5", "1", "1.5", "2"})
        Me.cboSuctionLineLoss.Location = New System.Drawing.Point(116, 256)
        Me.cboSuctionLineLoss.Name = "cboSuctionLineLoss"
        Me.cboSuctionLineLoss.Size = New System.Drawing.Size(72, 21)
        Me.cboSuctionLineLoss.TabIndex = 10
        Me.cboSuctionLineLoss.Text = "1"
        '
        'lblSuctionLineLoss
        '
        Me.lblSuctionLineLoss.Location = New System.Drawing.Point(4, 256)
        Me.lblSuctionLineLoss.Name = "lblSuctionLineLoss"
        Me.lblSuctionLineLoss.Size = New System.Drawing.Size(104, 23)
        Me.lblSuctionLineLoss.TabIndex = 49
        Me.lblSuctionLineLoss.Text = "Suction line loss"
        Me.lblSuctionLineLoss.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblApplies1
        '
        Me.lblApplies1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblApplies1.Location = New System.Drawing.Point(363, 228)
        Me.lblApplies1.Name = "lblApplies1"
        Me.lblApplies1.Size = New System.Drawing.Size(180, 23)
        Me.lblApplies1.TabIndex = 48
        Me.lblApplies1.Text = "Circuit 1 applies for both circuits"
        Me.lblApplies1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDischargeLineLoss
        '
        Me.lblDischargeLineLoss.Location = New System.Drawing.Point(0, 228)
        Me.lblDischargeLineLoss.Name = "lblDischargeLineLoss"
        Me.lblDischargeLineLoss.Size = New System.Drawing.Size(108, 23)
        Me.lblDischargeLineLoss.TabIndex = 47
        Me.lblDischargeLineLoss.Text = "Discharge line loss"
        Me.lblDischargeLineLoss.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboDischargeLineLoss
        '
        Me.cboDischargeLineLoss.Items.AddRange(New Object() {"0", "0.5", "1", "1.5", "2"})
        Me.cboDischargeLineLoss.Location = New System.Drawing.Point(116, 228)
        Me.cboDischargeLineLoss.Name = "cboDischargeLineLoss"
        Me.cboDischargeLineLoss.Size = New System.Drawing.Size(72, 21)
        Me.cboDischargeLineLoss.TabIndex = 9
        Me.cboDischargeLineLoss.Text = "1"
        '
        'lblApplies4
        '
        Me.lblApplies4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblApplies4.Location = New System.Drawing.Point(363, 368)
        Me.lblApplies4.Name = "lblApplies4"
        Me.lblApplies4.Size = New System.Drawing.Size(176, 23)
        Me.lblApplies4.TabIndex = 45
        Me.lblApplies4.Text = "Circuit 1 applies for both circuits"
        Me.lblApplies4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFanWatts
        '
        Me.lblFanWatts.Location = New System.Drawing.Point(4, 368)
        Me.lblFanWatts.Name = "lblFanWatts"
        Me.lblFanWatts.Size = New System.Drawing.Size(104, 23)
        Me.lblFanWatts.TabIndex = 44
        Me.lblFanWatts.Text = "Fan watts"
        Me.lblFanWatts.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFanWatts
        '
        Me.txtFanWatts.Location = New System.Drawing.Point(116, 368)
        Me.txtFanWatts.Name = "txtFanWatts"
        Me.txtFanWatts.ReadOnly = True
        Me.txtFanWatts.Size = New System.Drawing.Size(72, 21)
        Me.txtFanWatts.TabIndex = 43
        Me.txtFanWatts.TabStop = False
        '
        'cboFan
        '
        Me.cboFan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFan.Location = New System.Drawing.Point(116, 312)
        Me.cboFan.MaxDropDownItems = 11
        Me.cboFan.Name = "cboFan"
        Me.cboFan.Size = New System.Drawing.Size(232, 21)
        Me.cboFan.TabIndex = 12
        '
        'txtCondenserCapacity2
        '
        Me.txtCondenserCapacity2.Location = New System.Drawing.Point(423, 396)
        Me.txtCondenserCapacity2.Name = "txtCondenserCapacity2"
        Me.txtCondenserCapacity2.Size = New System.Drawing.Size(66, 21)
        Me.txtCondenserCapacity2.TabIndex = 24
        '
        'txtCondenserCapacity1
        '
        Me.txtCondenserCapacity1.Location = New System.Drawing.Point(116, 396)
        Me.txtCondenserCapacity1.Name = "txtCondenserCapacity1"
        Me.txtCondenserCapacity1.Size = New System.Drawing.Size(72, 21)
        Me.txtCondenserCapacity1.TabIndex = 14
        '
        'lblCondenserCapacity1
        '
        Me.lblCondenserCapacity1.Location = New System.Drawing.Point(0, 392)
        Me.lblCondenserCapacity1.Name = "lblCondenserCapacity1"
        Me.lblCondenserCapacity1.Size = New System.Drawing.Size(108, 28)
        Me.lblCondenserCapacity1.TabIndex = 38
        Me.lblCondenserCapacity1.Text = "Condenser est. capacity"
        Me.lblCondenserCapacity1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNumFans2
        '
        Me.txtNumFans2.Location = New System.Drawing.Point(423, 340)
        Me.txtNumFans2.Name = "txtNumFans2"
        Me.txtNumFans2.Size = New System.Drawing.Size(72, 21)
        Me.txtNumFans2.TabIndex = 23
        Me.txtNumFans2.Text = "1"
        '
        'txtNumFans1
        '
        Me.txtNumFans1.Location = New System.Drawing.Point(116, 340)
        Me.txtNumFans1.Name = "txtNumFans1"
        Me.txtNumFans1.Size = New System.Drawing.Size(72, 21)
        Me.txtNumFans1.TabIndex = 13
        Me.txtNumFans1.Text = "1"
        '
        'lblNumFans2
        '
        Me.lblNumFans2.Location = New System.Drawing.Point(347, 340)
        Me.lblNumFans2.Name = "lblNumFans2"
        Me.lblNumFans2.Size = New System.Drawing.Size(69, 23)
        Me.lblNumFans2.TabIndex = 35
        Me.lblNumFans2.Text = "Fan quantity"
        Me.lblNumFans2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNumFans1
        '
        Me.lblNumFans1.Location = New System.Drawing.Point(4, 340)
        Me.lblNumFans1.Name = "lblNumFans1"
        Me.lblNumFans1.Size = New System.Drawing.Size(104, 23)
        Me.lblNumFans1.TabIndex = 34
        Me.lblNumFans1.Text = "Fan quantity"
        Me.lblNumFans1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFinLength2
        '
        Me.txtFinLength2.Location = New System.Drawing.Point(423, 200)
        Me.txtFinLength2.Name = "txtFinLength2"
        Me.txtFinLength2.Size = New System.Drawing.Size(72, 21)
        Me.txtFinLength2.TabIndex = 22
        '
        'txtFinLength1
        '
        Me.txtFinLength1.Location = New System.Drawing.Point(116, 200)
        Me.txtFinLength1.Name = "txtFinLength1"
        Me.txtFinLength1.Size = New System.Drawing.Size(72, 21)
        Me.txtFinLength1.TabIndex = 8
        '
        'lblFinLength2
        '
        Me.lblFinLength2.Location = New System.Drawing.Point(335, 200)
        Me.lblFinLength2.Name = "lblFinLength2"
        Me.lblFinLength2.Size = New System.Drawing.Size(80, 23)
        Me.lblFinLength2.TabIndex = 31
        Me.lblFinLength2.Text = "Fin length"
        Me.lblFinLength2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFinLength1
        '
        Me.lblFinLength1.Location = New System.Drawing.Point(4, 200)
        Me.lblFinLength1.Name = "lblFinLength1"
        Me.lblFinLength1.Size = New System.Drawing.Size(104, 23)
        Me.lblFinLength1.TabIndex = 30
        Me.lblFinLength1.Text = "Fin length"
        Me.lblFinLength1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFinHeight2
        '
        Me.txtFinHeight2.Location = New System.Drawing.Point(423, 172)
        Me.txtFinHeight2.Name = "txtFinHeight2"
        Me.txtFinHeight2.Size = New System.Drawing.Size(72, 21)
        Me.txtFinHeight2.TabIndex = 21
        '
        'txtFinHeight1
        '
        Me.txtFinHeight1.Location = New System.Drawing.Point(116, 172)
        Me.txtFinHeight1.Name = "txtFinHeight1"
        Me.txtFinHeight1.Size = New System.Drawing.Size(72, 21)
        Me.txtFinHeight1.TabIndex = 7
        '
        'lblFinHeight2
        '
        Me.lblFinHeight2.Location = New System.Drawing.Point(335, 172)
        Me.lblFinHeight2.Name = "lblFinHeight2"
        Me.lblFinHeight2.Size = New System.Drawing.Size(80, 23)
        Me.lblFinHeight2.TabIndex = 27
        Me.lblFinHeight2.Text = "Fin height"
        Me.lblFinHeight2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFinHeight1
        '
        Me.lblFinHeight1.Location = New System.Drawing.Point(4, 172)
        Me.lblFinHeight1.Name = "lblFinHeight1"
        Me.lblFinHeight1.Size = New System.Drawing.Size(104, 23)
        Me.lblFinHeight1.TabIndex = 26
        Me.lblFinHeight1.Text = "Fin height"
        Me.lblFinHeight1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCondenserTD2
        '
        Me.txtCondenserTD2.Enabled = False
        Me.txtCondenserTD2.Location = New System.Drawing.Point(423, 144)
        Me.txtCondenserTD2.Name = "txtCondenserTD2"
        Me.txtCondenserTD2.Size = New System.Drawing.Size(72, 21)
        Me.txtCondenserTD2.TabIndex = 20
        Me.txtCondenserTD2.Text = "25"
        '
        'lblCondenserTD2
        '
        Me.lblCondenserTD2.Location = New System.Drawing.Point(335, 144)
        Me.lblCondenserTD2.Name = "lblCondenserTD2"
        Me.lblCondenserTD2.Size = New System.Drawing.Size(80, 23)
        Me.lblCondenserTD2.TabIndex = 24
        Me.lblCondenserTD2.Text = "Condenser TD"
        Me.lblCondenserTD2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCondenserTD1
        '
        Me.txtCondenserTD1.Enabled = False
        Me.txtCondenserTD1.Location = New System.Drawing.Point(116, 144)
        Me.txtCondenserTD1.Name = "txtCondenserTD1"
        Me.txtCondenserTD1.Size = New System.Drawing.Size(72, 21)
        Me.txtCondenserTD1.TabIndex = 6
        Me.txtCondenserTD1.Text = "25"
        '
        'lblCondenserTD1
        '
        Me.lblCondenserTD1.Location = New System.Drawing.Point(4, 144)
        Me.lblCondenserTD1.Name = "lblCondenserTD1"
        Me.lblCondenserTD1.Size = New System.Drawing.Size(104, 23)
        Me.lblCondenserTD1.TabIndex = 22
        Me.lblCondenserTD1.Text = "Condenser TD"
        Me.lblCondenserTD1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCondSubCoolingPercent2
        '
        Me.lblCondSubCoolingPercent2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblCondSubCoolingPercent2.Location = New System.Drawing.Point(547, 116)
        Me.lblCondSubCoolingPercent2.Name = "lblCondSubCoolingPercent2"
        Me.lblCondSubCoolingPercent2.Size = New System.Drawing.Size(22, 23)
        Me.lblCondSubCoolingPercent2.TabIndex = 21
        Me.lblCondSubCoolingPercent2.Text = "%"
        Me.lblCondSubCoolingPercent2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCondSubCoolingPercent1
        '
        Me.lblCondSubCoolingPercent1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblCondSubCoolingPercent1.Location = New System.Drawing.Point(240, 116)
        Me.lblCondSubCoolingPercent1.Name = "lblCondSubCoolingPercent1"
        Me.lblCondSubCoolingPercent1.Size = New System.Drawing.Size(19, 23)
        Me.lblCondSubCoolingPercent1.TabIndex = 20
        Me.lblCondSubCoolingPercent1.Text = "%"
        Me.lblCondSubCoolingPercent1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSubCooling2
        '
        Me.txtSubCooling2.Location = New System.Drawing.Point(495, 116)
        Me.txtSubCooling2.Name = "txtSubCooling2"
        Me.txtSubCooling2.Size = New System.Drawing.Size(48, 21)
        Me.txtSubCooling2.TabIndex = 19
        '
        'txtSubCooling1
        '
        Me.txtSubCooling1.Location = New System.Drawing.Point(188, 116)
        Me.txtSubCooling1.Name = "txtSubCooling1"
        Me.txtSubCooling1.Size = New System.Drawing.Size(48, 21)
        Me.txtSubCooling1.TabIndex = 5
        '
        'cboSubCooling2
        '
        Me.cboSubCooling2.Items.AddRange(New Object() {"Yes", "No"})
        Me.cboSubCooling2.Location = New System.Drawing.Point(423, 116)
        Me.cboSubCooling2.Name = "cboSubCooling2"
        Me.cboSubCooling2.Size = New System.Drawing.Size(72, 21)
        Me.cboSubCooling2.TabIndex = 18
        Me.cboSubCooling2.Text = "Yes"
        '
        'lblSubCooling2
        '
        Me.lblSubCooling2.Location = New System.Drawing.Point(335, 116)
        Me.lblSubCooling2.Name = "lblSubCooling2"
        Me.lblSubCooling2.Size = New System.Drawing.Size(80, 23)
        Me.lblSubCooling2.TabIndex = 16
        Me.lblSubCooling2.Text = "Sub cooling"
        Me.lblSubCooling2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboSubCooling1
        '
        Me.cboSubCooling1.Items.AddRange(New Object() {"Yes", "No"})
        Me.cboSubCooling1.Location = New System.Drawing.Point(116, 116)
        Me.cboSubCooling1.Name = "cboSubCooling1"
        Me.cboSubCooling1.Size = New System.Drawing.Size(72, 21)
        Me.cboSubCooling1.TabIndex = 4
        Me.cboSubCooling1.Text = "Yes"
        '
        'lblSubCooling1
        '
        Me.lblSubCooling1.Location = New System.Drawing.Point(4, 116)
        Me.lblSubCooling1.Name = "lblSubCooling1"
        Me.lblSubCooling1.Size = New System.Drawing.Size(104, 23)
        Me.lblSubCooling1.TabIndex = 14
        Me.lblSubCooling1.Text = "Sub cooling"
        Me.lblSubCooling1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFinsPerInch1
        '
        Me.cboFinsPerInch1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFinsPerInch1.Location = New System.Drawing.Point(116, 88)
        Me.cboFinsPerInch1.Name = "cboFinsPerInch1"
        Me.cboFinsPerInch1.Size = New System.Drawing.Size(72, 21)
        Me.cboFinsPerInch1.TabIndex = 3
        '
        'cboFinsPerInch2
        '
        Me.cboFinsPerInch2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFinsPerInch2.Location = New System.Drawing.Point(423, 88)
        Me.cboFinsPerInch2.Name = "cboFinsPerInch2"
        Me.cboFinsPerInch2.Size = New System.Drawing.Size(72, 21)
        Me.cboFinsPerInch2.TabIndex = 17
        '
        'lblFinsPerInch2
        '
        Me.lblFinsPerInch2.Location = New System.Drawing.Point(335, 88)
        Me.lblFinsPerInch2.Name = "lblFinsPerInch2"
        Me.lblFinsPerInch2.Size = New System.Drawing.Size(80, 23)
        Me.lblFinsPerInch2.TabIndex = 11
        Me.lblFinsPerInch2.Text = "Fins per inch"
        Me.lblFinsPerInch2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFinsPerInch1
        '
        Me.lblFinsPerInch1.Location = New System.Drawing.Point(4, 88)
        Me.lblFinsPerInch1.Name = "lblFinsPerInch1"
        Me.lblFinsPerInch1.Size = New System.Drawing.Size(104, 23)
        Me.lblFinsPerInch1.TabIndex = 10
        Me.lblFinsPerInch1.Text = "Fins per inch"
        Me.lblFinsPerInch1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCondenser2
        '
        Me.cboCondenser2.Location = New System.Drawing.Point(423, 60)
        Me.cboCondenser2.Name = "cboCondenser2"
        Me.cboCondenser2.Size = New System.Drawing.Size(120, 21)
        Me.cboCondenser2.TabIndex = 16
        '
        'lblCondenser2
        '
        Me.lblCondenser2.Location = New System.Drawing.Point(335, 60)
        Me.lblCondenser2.Name = "lblCondenser2"
        Me.lblCondenser2.Size = New System.Drawing.Size(80, 23)
        Me.lblCondenser2.TabIndex = 8
        Me.lblCondenser2.Text = "Condenser"
        Me.lblCondenser2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCondenser1
        '
        Me.cboCondenser1.Location = New System.Drawing.Point(116, 60)
        Me.cboCondenser1.Name = "cboCondenser1"
        Me.cboCondenser1.Size = New System.Drawing.Size(120, 21)
        Me.cboCondenser1.TabIndex = 2
        '
        'lblCondenser1
        '
        Me.lblCondenser1.Location = New System.Drawing.Point(4, 60)
        Me.lblCondenser1.Name = "lblCondenser1"
        Me.lblCondenser1.Size = New System.Drawing.Size(104, 23)
        Me.lblCondenser1.TabIndex = 6
        Me.lblCondenser1.Text = "Condenser"
        Me.lblCondenser1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNumCoils1
        '
        Me.txtNumCoils1.Location = New System.Drawing.Point(116, 32)
        Me.txtNumCoils1.Name = "txtNumCoils1"
        Me.txtNumCoils1.Size = New System.Drawing.Size(72, 21)
        Me.txtNumCoils1.TabIndex = 1
        '
        'txtNumCoils2
        '
        Me.txtNumCoils2.Location = New System.Drawing.Point(423, 32)
        Me.txtNumCoils2.Name = "txtNumCoils2"
        Me.txtNumCoils2.Size = New System.Drawing.Size(72, 21)
        Me.txtNumCoils2.TabIndex = 15
        '
        'lblNumCoils2
        '
        Me.lblNumCoils2.Location = New System.Drawing.Point(335, 32)
        Me.lblNumCoils2.Name = "lblNumCoils2"
        Me.lblNumCoils2.Size = New System.Drawing.Size(80, 23)
        Me.lblNumCoils2.TabIndex = 3
        Me.lblNumCoils2.Text = "Coil quantity"
        Me.lblNumCoils2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNumCoils1
        '
        Me.lblNumCoils1.Location = New System.Drawing.Point(4, 32)
        Me.lblNumCoils1.Name = "lblNumCoils1"
        Me.lblNumCoils1.Size = New System.Drawing.Size(104, 23)
        Me.lblNumCoils1.TabIndex = 2
        Me.lblNumCoils1.Text = "Coil quantity"
        Me.lblNumCoils1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCircuit2
        '
        Me.lblCircuit2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCircuit2.Location = New System.Drawing.Point(339, 4)
        Me.lblCircuit2.Name = "lblCircuit2"
        Me.lblCircuit2.Size = New System.Drawing.Size(216, 23)
        Me.lblCircuit2.TabIndex = 1
        Me.lblCircuit2.Text = "Circuit 2"
        Me.lblCircuit2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCircuit1
        '
        Me.lblCircuit1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCircuit1.Location = New System.Drawing.Point(44, 4)
        Me.lblCircuit1.Name = "lblCircuit1"
        Me.lblCircuit1.Size = New System.Drawing.Size(192, 23)
        Me.lblCircuit1.TabIndex = 0
        Me.lblCircuit1.Text = "Circuit 1"
        Me.lblCircuit1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCfmOverride
        '
        Me.txtCfmOverride.Location = New System.Drawing.Point(356, 312)
        Me.txtCfmOverride.Name = "txtCfmOverride"
        Me.txtCfmOverride.Size = New System.Drawing.Size(72, 21)
        Me.txtCfmOverride.TabIndex = 12
        Me.txtCfmOverride.Visible = False
        '
        'lblCFM
        '
        Me.lblCFM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblCFM.Location = New System.Drawing.Point(432, 312)
        Me.lblCFM.Name = "lblCFM"
        Me.lblCFM.Size = New System.Drawing.Size(31, 23)
        Me.lblCFM.TabIndex = 59
        Me.lblCFM.Text = "CFM"
        Me.lblCFM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCFM.Visible = False
        '
        'panCondenserHeader
        '
        Me.panCondenserHeader.BackColor = System.Drawing.Color.White
        Me.panCondenserHeader.Controls.Add(Me.lineCondenser)
        Me.panCondenserHeader.Controls.Add(Me.btnCondenserPlus)
        Me.panCondenserHeader.Controls.Add(Me.lblCondenser)
        Me.panCondenserHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panCondenserHeader.Location = New System.Drawing.Point(0, 667)
        Me.panCondenserHeader.Name = "panCondenserHeader"
        Me.panCondenserHeader.Size = New System.Drawing.Size(671, 44)
        Me.panCondenserHeader.TabIndex = 6
        '
        'lineCondenser
        '
        Me.lineCondenser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lineCondenser.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.lineCondenser.Location = New System.Drawing.Point(12, 40)
        Me.lineCondenser.Name = "lineCondenser"
        Me.lineCondenser.Size = New System.Drawing.Size(500, 2)
        Me.lineCondenser.TabIndex = 7
        Me.lineCondenser.Text = "Button3"
        '
        'btnCondenserPlus
        '
        Me.btnCondenserPlus.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnCondenserPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCondenserPlus.Font = New System.Drawing.Font("Garamond", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCondenserPlus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnCondenserPlus.Location = New System.Drawing.Point(16, 19)
        Me.btnCondenserPlus.Name = "btnCondenserPlus"
        Me.btnCondenserPlus.Size = New System.Drawing.Size(20, 18)
        Me.btnCondenserPlus.TabIndex = 1
        Me.btnCondenserPlus.Text = "-"
        Me.btnCondenserPlus.UseVisualStyleBackColor = False
        '
        'lblCondenser
        '
        Me.lblCondenser.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCondenser.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.lblCondenser.Location = New System.Drawing.Point(44, 16)
        Me.lblCondenser.Name = "lblCondenser"
        Me.lblCondenser.Size = New System.Drawing.Size(452, 24)
        Me.lblCondenser.TabIndex = 0
        Me.lblCondenser.Text = "Condenser"
        Me.lblCondenser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'panCompDataHide
        '
        Me.panCompDataHide.BackColor = System.Drawing.Color.White
        Me.panCompDataHide.Controls.Add(Me.panCompressor)
        Me.panCompDataHide.Dock = System.Windows.Forms.DockStyle.Top
        Me.panCompDataHide.Location = New System.Drawing.Point(0, 463)
        Me.panCompDataHide.Name = "panCompDataHide"
        Me.panCompDataHide.Size = New System.Drawing.Size(671, 204)
        Me.panCompDataHide.TabIndex = 5
        '
        'panCompressorevaporatorgrid1
        '
        Me.panCompressor.BackColor = System.Drawing.Color.White
        Me.panCompressor.Controls.Add(Me.txtCompressorMasterID2)
        Me.panCompressor.Controls.Add(Me.txtCompressorMasterID1)
        Me.panCompressor.Controls.Add(Me.chkSafetyOverride)
        Me.panCompressor.Controls.Add(Me.lblNumCompressors2)
        Me.panCompressor.Controls.Add(Me.lblCompressor2)
        Me.panCompressor.Controls.Add(Me.txtNumCompressors2)
        Me.panCompressor.Controls.Add(Me.txtCompressor2)
        Me.panCompressor.Controls.Add(Me.lblNumCompressors1)
        Me.panCompressor.Controls.Add(Me.txtNumCompressors1)
        Me.panCompressor.Controls.Add(Me.txtCompressor1)
        Me.panCompressor.Controls.Add(Me.lblCompressor1)
        Me.panCompressor.Controls.Add(Me.lboCompressors2)
        Me.panCompressor.Controls.Add(Me.lboCompressors1)
        Me.panCompressor.Controls.Add(Me.panCirc)
        Me.panCompressor.Location = New System.Drawing.Point(12, -1)
        Me.panCompressor.Name = "panCompressor"
        Me.panCompressor.Size = New System.Drawing.Size(649, 205)
        Me.panCompressor.TabIndex = 8
        '
        'txtCompressorMasterID2
        '
        Me.txtCompressorMasterID2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompressorMasterID2.Location = New System.Drawing.Point(496, 87)
        Me.txtCompressorMasterID2.Name = "txtCompressorMasterID2"
        Me.txtCompressorMasterID2.ReadOnly = True
        Me.txtCompressorMasterID2.Size = New System.Drawing.Size(49, 21)
        Me.txtCompressorMasterID2.TabIndex = 12
        Me.txtCompressorMasterID2.Visible = False
        '
        'txtCompressorMasterID1
        '
        Me.txtCompressorMasterID1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompressorMasterID1.Location = New System.Drawing.Point(188, 87)
        Me.txtCompressorMasterID1.Name = "txtCompressorMasterID1"
        Me.txtCompressorMasterID1.ReadOnly = True
        Me.txtCompressorMasterID1.Size = New System.Drawing.Size(36, 21)
        Me.txtCompressorMasterID1.TabIndex = 11
        Me.txtCompressorMasterID1.TabStop = False
        Me.txtCompressorMasterID1.Visible = False
        '
        'chkSafetyOverride
        '
        Me.chkSafetyOverride.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkSafetyOverride.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSafetyOverride.Location = New System.Drawing.Point(12, 4)
        Me.chkSafetyOverride.Name = "chkSafetyOverride"
        Me.chkSafetyOverride.Size = New System.Drawing.Size(118, 24)
        Me.chkSafetyOverride.TabIndex = 1
        Me.chkSafetyOverride.Text = "Safety override"
        '
        'lblNumCompressors2
        '
        Me.lblNumCompressors2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumCompressors2.Location = New System.Drawing.Point(333, 88)
        Me.lblNumCompressors2.Name = "lblNumCompressors2"
        Me.lblNumCompressors2.Size = New System.Drawing.Size(76, 23)
        Me.lblNumCompressors2.TabIndex = 10
        Me.lblNumCompressors2.Text = "Quantity"
        Me.lblNumCompressors2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCompressor2
        '
        Me.lblCompressor2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompressor2.Location = New System.Drawing.Point(333, 60)
        Me.lblCompressor2.Name = "lblCompressor2"
        Me.lblCompressor2.Size = New System.Drawing.Size(76, 23)
        Me.lblCompressor2.TabIndex = 9
        Me.lblCompressor2.Text = "Compressor"
        Me.lblCompressor2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNumCompressors2
        '
        Me.txtNumCompressors2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumCompressors2.Location = New System.Drawing.Point(417, 88)
        Me.txtNumCompressors2.Name = "txtNumCompressors2"
        Me.txtNumCompressors2.Size = New System.Drawing.Size(72, 21)
        Me.txtNumCompressors2.TabIndex = 5
        Me.txtNumCompressors2.Text = "1"
        '
        'txtCompressor2
        '
        Me.txtCompressor2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompressor2.Location = New System.Drawing.Point(417, 60)
        Me.txtCompressor2.Name = "txtCompressor2"
        Me.txtCompressor2.ReadOnly = True
        Me.txtCompressor2.Size = New System.Drawing.Size(128, 21)
        Me.txtCompressor2.TabIndex = 7
        '
        'lblNumCompressors1
        '
        Me.lblNumCompressors1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumCompressors1.Location = New System.Drawing.Point(12, 88)
        Me.lblNumCompressors1.Name = "lblNumCompressors1"
        Me.lblNumCompressors1.Size = New System.Drawing.Size(76, 23)
        Me.lblNumCompressors1.TabIndex = 6
        Me.lblNumCompressors1.Text = "Quantity"
        Me.lblNumCompressors1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNumCompressors1
        '
        Me.txtNumCompressors1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumCompressors1.Location = New System.Drawing.Point(96, 88)
        Me.txtNumCompressors1.Name = "txtNumCompressors1"
        Me.txtNumCompressors1.Size = New System.Drawing.Size(72, 21)
        Me.txtNumCompressors1.TabIndex = 3
        Me.txtNumCompressors1.Text = "1"
        '
        'txtCompressor1
        '
        Me.txtCompressor1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompressor1.Location = New System.Drawing.Point(96, 60)
        Me.txtCompressor1.Name = "txtCompressor1"
        Me.txtCompressor1.ReadOnly = True
        Me.txtCompressor1.Size = New System.Drawing.Size(128, 21)
        Me.txtCompressor1.TabIndex = 3
        Me.txtCompressor1.TabStop = False
        '
        'lblCompressor1
        '
        Me.lblCompressor1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompressor1.Location = New System.Drawing.Point(12, 60)
        Me.lblCompressor1.Name = "lblCompressor1"
        Me.lblCompressor1.Size = New System.Drawing.Size(78, 23)
        Me.lblCompressor1.TabIndex = 3
        Me.lblCompressor1.Text = "Compressor"
        Me.lblCompressor1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lboCompressors2
        '
        Me.lboCompressors2.Enabled = False
        Me.lboCompressors2.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lboCompressors2.ItemHeight = 14
        Me.lboCompressors2.Location = New System.Drawing.Point(332, 116)
        Me.lboCompressors2.Name = "lboCompressors2"
        Me.lboCompressors2.Size = New System.Drawing.Size(300, 88)
        Me.lboCompressors2.TabIndex = 6
        '
        'lboCompressors1
        '
        Me.lboCompressors1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lboCompressors1.ItemHeight = 14
        Me.lboCompressors1.Location = New System.Drawing.Point(28, 116)
        Me.lboCompressors1.Name = "lboCompressors1"
        Me.lboCompressors1.Size = New System.Drawing.Size(300, 88)
        Me.lboCompressors1.TabIndex = 4
        Me.lboCompressors1.Tag = ""
        '
        'panCirc
        '
        Me.panCirc.Controls.Add(Me.radCircuit2)
        Me.panCirc.Controls.Add(Me.radCircuit1)
        Me.panCirc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panCirc.Location = New System.Drawing.Point(4, 26)
        Me.panCirc.Name = "panCirc"
        Me.panCirc.Size = New System.Drawing.Size(618, 30)
        Me.panCirc.TabIndex = 2
        '
        'radCircuit2
        '
        Me.radCircuit2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.radCircuit2.Location = New System.Drawing.Point(338, 4)
        Me.radCircuit2.Name = "radCircuit2"
        Me.radCircuit2.Size = New System.Drawing.Size(190, 24)
        Me.radCircuit2.TabIndex = 2
        Me.radCircuit2.Text = "Circuit 2"
        '
        'radCircuit1
        '
        Me.radCircuit1.Checked = True
        Me.radCircuit1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.radCircuit1.Location = New System.Drawing.Point(8, 4)
        Me.radCircuit1.Name = "radCircuit1"
        Me.radCircuit1.Size = New System.Drawing.Size(201, 24)
        Me.radCircuit1.TabIndex = 1
        Me.radCircuit1.TabStop = True
        Me.radCircuit1.Text = "Circuit 1"
        '
        'panCompressorHeader
        '
        Me.panCompressorHeader.BackColor = System.Drawing.Color.White
        Me.panCompressorHeader.Controls.Add(Me.lineCompressor)
        Me.panCompressorHeader.Controls.Add(Me.btnCompressorPlus)
        Me.panCompressorHeader.Controls.Add(Me.lblCompressor)
        Me.panCompressorHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panCompressorHeader.Location = New System.Drawing.Point(0, 419)
        Me.panCompressorHeader.Name = "panCompressorHeader"
        Me.panCompressorHeader.Size = New System.Drawing.Size(671, 44)
        Me.panCompressorHeader.TabIndex = 4
        '
        'lineCompressor
        '
        Me.lineCompressor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lineCompressor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.lineCompressor.Location = New System.Drawing.Point(12, 40)
        Me.lineCompressor.Name = "lineCompressor"
        Me.lineCompressor.Size = New System.Drawing.Size(500, 2)
        Me.lineCompressor.TabIndex = 10
        Me.lineCompressor.Text = "Button2"
        '
        'btnCompressorPlus
        '
        Me.btnCompressorPlus.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnCompressorPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCompressorPlus.Font = New System.Drawing.Font("Garamond", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCompressorPlus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnCompressorPlus.Location = New System.Drawing.Point(16, 19)
        Me.btnCompressorPlus.Name = "btnCompressorPlus"
        Me.btnCompressorPlus.Size = New System.Drawing.Size(20, 18)
        Me.btnCompressorPlus.TabIndex = 5
        Me.btnCompressorPlus.Text = "-"
        Me.btnCompressorPlus.UseVisualStyleBackColor = False
        '
        'lblCompressor
        '
        Me.lblCompressor.BackColor = System.Drawing.Color.White
        Me.lblCompressor.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompressor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.lblCompressor.Location = New System.Drawing.Point(44, 16)
        Me.lblCompressor.Name = "lblCompressor"
        Me.lblCompressor.Size = New System.Drawing.Size(416, 24)
        Me.lblCompressor.TabIndex = 9
        Me.lblCompressor.Text = "Compressor"
        Me.lblCompressor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'panRatiCritHide
        '
        Me.panRatiCritHide.BackColor = System.Drawing.Color.White
        Me.panRatiCritHide.Controls.Add(Me.panRatingCriteria)
        Me.panRatiCritHide.Dock = System.Windows.Forms.DockStyle.Top
        Me.panRatiCritHide.Location = New System.Drawing.Point(0, 191)
        Me.panRatiCritHide.Name = "panRatiCritHide"
        Me.panRatiCritHide.Size = New System.Drawing.Size(671, 228)
        Me.panRatiCritHide.TabIndex = 3
        '
        'panRatingCriteria
        '
        Me.panRatingCriteria.BackColor = System.Drawing.Color.White
        Me.panRatingCriteria.Controls.Add(Me.cboVolts)
        Me.panRatingCriteria.Controls.Add(Me.Label2)
        Me.panRatingCriteria.Controls.Add(Me.lblRangeF)
        Me.panRatingCriteria.Controls.Add(Me.lblAmbientF)
        Me.panRatingCriteria.Controls.Add(Me.lblLeavingFluidF)
        Me.panRatingCriteria.Controls.Add(Me.lblSubCoolingF)
        Me.panRatingCriteria.Controls.Add(Me.lblFreezePointF)
        Me.panRatingCriteria.Controls.Add(Me.lblMinSuctionF)
        Me.panRatingCriteria.Controls.Add(Me.lblRatiVolt)
        Me.panRatingCriteria.Controls.Add(Me.btnGlycolChart)
        Me.panRatingCriteria.Controls.Add(Me.txtApproach)
        Me.panRatingCriteria.Controls.Add(Me.lblApproach)
        Me.panRatingCriteria.Controls.Add(Me.lblRatiVolt1)
        Me.panRatingCriteria.Controls.Add(Me.cboHertz)
        Me.panRatingCriteria.Controls.Add(Me.lblHertz)
        Me.panRatingCriteria.Controls.Add(Me.cboSystem)
        Me.panRatingCriteria.Controls.Add(Me.lblSystem)
        Me.panRatingCriteria.Controls.Add(Me.txtFreezingPoint)
        Me.panRatingCriteria.Controls.Add(Me.lblFreezingPoint)
        Me.panRatingCriteria.Controls.Add(Me.lblSpecificGravity)
        Me.panRatingCriteria.Controls.Add(Me.lblSpecificHeat)
        Me.panRatingCriteria.Controls.Add(Me.txtSpecificGravity)
        Me.panRatingCriteria.Controls.Add(Me.txtSpecificHeat)
        Me.panRatingCriteria.Controls.Add(Me.txtGlycolPercentage)
        Me.panRatingCriteria.Controls.Add(Me.lblGlycolPercentage)
        Me.panRatingCriteria.Controls.Add(Me.cboFluid)
        Me.panRatingCriteria.Controls.Add(Me.lblFluid)
        Me.panRatingCriteria.Controls.Add(Me.cbo_cooling_media)
        Me.panRatingCriteria.Controls.Add(Me.lblCoolingMedia)
        Me.panRatingCriteria.Controls.Add(Me.txtSuctionTemp)
        Me.panRatingCriteria.Controls.Add(Me.lblMinSuctionTemp)
        Me.panRatingCriteria.Controls.Add(Me.txtSubCooling)
        Me.panRatingCriteria.Controls.Add(Me.lblSubCooling)
        Me.panRatingCriteria.Controls.Add(Me.txtLeavingFluidTemp)
        Me.panRatingCriteria.Controls.Add(Me.lblLeavingFluidTemp)
        Me.panRatingCriteria.Controls.Add(Me.lblAmbientTemp)
        Me.panRatingCriteria.Controls.Add(Me.txtAmbientTemp)
        Me.panRatingCriteria.Controls.Add(Me.lblTempRange)
        Me.panRatingCriteria.Controls.Add(Me.txtTempRange)
        Me.panRatingCriteria.Controls.Add(Me.lblRefrigerant)
        Me.panRatingCriteria.Controls.Add(Me.cboRefrigerant)
        Me.panRatingCriteria.Location = New System.Drawing.Point(12, -1)
        Me.panRatingCriteria.Name = "panRatingCriteria"
        Me.panRatingCriteria.Size = New System.Drawing.Size(640, 229)
        Me.panRatingCriteria.TabIndex = 1
        '
        'cboVolts
        '
        Me.cboVolts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVolts.Items.AddRange(New Object() {"230", "460", "575"})
        Me.cboVolts.Location = New System.Drawing.Point(368, 148)
        Me.cboVolts.Name = "cboVolts"
        Me.cboVolts.Size = New System.Drawing.Size(72, 21)
        Me.cboVolts.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(290, 148)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 21)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Voltage"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRangeF
        '
        Me.lblRangeF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblRangeF.Location = New System.Drawing.Point(444, 36)
        Me.lblRangeF.Name = "lblRangeF"
        Me.lblRangeF.Size = New System.Drawing.Size(64, 21)
        Me.lblRangeF.TabIndex = 40
        Me.lblRangeF.Text = "5 to 20°F"
        Me.lblRangeF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAmbientF
        '
        Me.lblAmbientF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblAmbientF.Location = New System.Drawing.Point(444, 64)
        Me.lblAmbientF.Name = "lblAmbientF"
        Me.lblAmbientF.Size = New System.Drawing.Size(28, 21)
        Me.lblAmbientF.TabIndex = 39
        Me.lblAmbientF.Text = "°F"
        Me.lblAmbientF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLeavingFluidF
        '
        Me.lblLeavingFluidF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblLeavingFluidF.Location = New System.Drawing.Point(444, 92)
        Me.lblLeavingFluidF.Name = "lblLeavingFluidF"
        Me.lblLeavingFluidF.Size = New System.Drawing.Size(64, 21)
        Me.lblLeavingFluidF.TabIndex = 38
        Me.lblLeavingFluidF.Text = "-40 to 85°F"
        Me.lblLeavingFluidF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSubCoolingF
        '
        Me.lblSubCoolingF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblSubCoolingF.Location = New System.Drawing.Point(180, 176)
        Me.lblSubCoolingF.Name = "lblSubCoolingF"
        Me.lblSubCoolingF.Size = New System.Drawing.Size(28, 21)
        Me.lblSubCoolingF.TabIndex = 37
        Me.lblSubCoolingF.Text = "°F"
        Me.lblSubCoolingF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFreezePointF
        '
        Me.lblFreezePointF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblFreezePointF.Location = New System.Drawing.Point(180, 120)
        Me.lblFreezePointF.Name = "lblFreezePointF"
        Me.lblFreezePointF.Size = New System.Drawing.Size(28, 21)
        Me.lblFreezePointF.TabIndex = 36
        Me.lblFreezePointF.Text = "°F"
        Me.lblFreezePointF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMinSuctionF
        '
        Me.lblMinSuctionF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblMinSuctionF.Location = New System.Drawing.Point(180, 148)
        Me.lblMinSuctionF.Name = "lblMinSuctionF"
        Me.lblMinSuctionF.Size = New System.Drawing.Size(28, 21)
        Me.lblMinSuctionF.TabIndex = 35
        Me.lblMinSuctionF.Text = "°F"
        Me.lblMinSuctionF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRatiVolt
        '
        Me.lblRatiVolt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblRatiVolt.Location = New System.Drawing.Point(444, 111)
        Me.lblRatiVolt.Name = "lblRatiVolt"
        Me.lblRatiVolt.Size = New System.Drawing.Size(53, 21)
        Me.lblRatiVolt.TabIndex = 29
        Me.lblRatiVolt.Text = "380 Volts"
        Me.lblRatiVolt.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.lblRatiVolt.Visible = False
        '
        'btnGlycolChart
        '
        Me.btnGlycolChart.BackColor = System.Drawing.SystemColors.Control
        Me.btnGlycolChart.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnGlycolChart.Location = New System.Drawing.Point(180, 35)
        Me.btnGlycolChart.Name = "btnGlycolChart"
        Me.btnGlycolChart.Size = New System.Drawing.Size(74, 23)
        Me.btnGlycolChart.TabIndex = 4
        Me.btnGlycolChart.Text = "Glycol Chart"
        Me.btnGlycolChart.UseVisualStyleBackColor = False
        Me.btnGlycolChart.Visible = False
        '
        'txtApproach
        '
        Me.txtApproach.Location = New System.Drawing.Point(104, 203)
        Me.txtApproach.Name = "txtApproach"
        Me.txtApproach.ReadOnly = True
        Me.txtApproach.Size = New System.Drawing.Size(72, 21)
        Me.txtApproach.TabIndex = 32
        Me.txtApproach.TabStop = False
        '
        'lblApproach
        '
        Me.lblApproach.Location = New System.Drawing.Point(16, 203)
        Me.lblApproach.Name = "lblApproach"
        Me.lblApproach.Size = New System.Drawing.Size(80, 21)
        Me.lblApproach.TabIndex = 31
        Me.lblApproach.Text = "Approach"
        Me.lblApproach.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRatiVolt1
        '
        Me.lblRatiVolt1.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblRatiVolt1.Location = New System.Drawing.Point(444, 131)
        Me.lblRatiVolt1.Name = "lblRatiVolt1"
        Me.lblRatiVolt1.Size = New System.Drawing.Size(36, 21)
        Me.lblRatiVolt1.TabIndex = 30
        Me.lblRatiVolt1.Text = "only"
        Me.lblRatiVolt1.Visible = False
        '
        'cboHertz
        '
        Me.cboHertz.Items.AddRange(New Object() {"60", "50"})
        Me.cboHertz.Location = New System.Drawing.Point(368, 120)
        Me.cboHertz.Name = "cboHertz"
        Me.cboHertz.Size = New System.Drawing.Size(72, 21)
        Me.cboHertz.TabIndex = 12
        Me.cboHertz.Text = "60"
        '
        'lblHertz
        '
        Me.lblHertz.Location = New System.Drawing.Point(289, 120)
        Me.lblHertz.Name = "lblHertz"
        Me.lblHertz.Size = New System.Drawing.Size(76, 21)
        Me.lblHertz.TabIndex = 27
        Me.lblHertz.Text = "Hertz"
        Me.lblHertz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSystem
        '
        Me.cboSystem.Items.AddRange(New Object() {"FULL", "HALF"})
        Me.cboSystem.Location = New System.Drawing.Point(368, 176)
        Me.cboSystem.Name = "cboSystem"
        Me.cboSystem.Size = New System.Drawing.Size(72, 21)
        Me.cboSystem.TabIndex = 11
        Me.cboSystem.Text = "FULL"
        '
        'lblSystem
        '
        Me.lblSystem.Location = New System.Drawing.Point(289, 176)
        Me.lblSystem.Name = "lblSystem"
        Me.lblSystem.Size = New System.Drawing.Size(76, 21)
        Me.lblSystem.TabIndex = 25
        Me.lblSystem.Text = "System"
        Me.lblSystem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFreezingPoint
        '
        Me.txtFreezingPoint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFreezingPoint.Location = New System.Drawing.Point(104, 120)
        Me.txtFreezingPoint.Name = "txtFreezingPoint"
        Me.txtFreezingPoint.ReadOnly = True
        Me.txtFreezingPoint.Size = New System.Drawing.Size(72, 21)
        Me.txtFreezingPoint.TabIndex = 23
        Me.txtFreezingPoint.TabStop = False
        Me.txtFreezingPoint.Text = "32"
        '
        'lblFreezingPoint
        '
        Me.lblFreezingPoint.Location = New System.Drawing.Point(4, 120)
        Me.lblFreezingPoint.Name = "lblFreezingPoint"
        Me.lblFreezingPoint.Size = New System.Drawing.Size(92, 21)
        Me.lblFreezingPoint.TabIndex = 22
        Me.lblFreezingPoint.Text = "Freeze point"
        Me.lblFreezingPoint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSpecificGravity
        '
        Me.lblSpecificGravity.Location = New System.Drawing.Point(4, 92)
        Me.lblSpecificGravity.Name = "lblSpecificGravity"
        Me.lblSpecificGravity.Size = New System.Drawing.Size(92, 21)
        Me.lblSpecificGravity.TabIndex = 21
        Me.lblSpecificGravity.Text = "Specific gravity"
        Me.lblSpecificGravity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSpecificHeat
        '
        Me.lblSpecificHeat.Location = New System.Drawing.Point(4, 64)
        Me.lblSpecificHeat.Name = "lblSpecificHeat"
        Me.lblSpecificHeat.Size = New System.Drawing.Size(92, 21)
        Me.lblSpecificHeat.TabIndex = 20
        Me.lblSpecificHeat.Text = "Specific heat"
        Me.lblSpecificHeat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSpecificGravity
        '
        Me.txtSpecificGravity.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpecificGravity.Location = New System.Drawing.Point(104, 92)
        Me.txtSpecificGravity.Name = "txtSpecificGravity"
        Me.txtSpecificGravity.Size = New System.Drawing.Size(72, 21)
        Me.txtSpecificGravity.TabIndex = 6
        Me.txtSpecificGravity.Text = "0"
        '
        'txtSpecificHeat
        '
        Me.txtSpecificHeat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpecificHeat.Location = New System.Drawing.Point(104, 64)
        Me.txtSpecificHeat.Name = "txtSpecificHeat"
        Me.txtSpecificHeat.Size = New System.Drawing.Size(72, 21)
        Me.txtSpecificHeat.TabIndex = 5
        Me.txtSpecificHeat.Text = "0"
        '
        'txtGlycolPercentage
        '
        Me.txtGlycolPercentage.Enabled = False
        Me.txtGlycolPercentage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGlycolPercentage.Location = New System.Drawing.Point(180, 8)
        Me.txtGlycolPercentage.Name = "txtGlycolPercentage"
        Me.txtGlycolPercentage.Size = New System.Drawing.Size(36, 21)
        Me.txtGlycolPercentage.TabIndex = 2
        Me.txtGlycolPercentage.Text = "0"
        Me.ToolTip1.SetToolTip(Me.txtGlycolPercentage, "Range 0-60")
        '
        'lblGlycolPercentage
        '
        Me.lblGlycolPercentage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblGlycolPercentage.Location = New System.Drawing.Point(220, 8)
        Me.lblGlycolPercentage.Name = "lblGlycolPercentage"
        Me.lblGlycolPercentage.Size = New System.Drawing.Size(52, 21)
        Me.lblGlycolPercentage.TabIndex = 16
        Me.lblGlycolPercentage.Text = "% Glycol"
        Me.lblGlycolPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboFluid
        '
        Me.cboFluid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFluid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFluid.Items.AddRange(New Object() {"Water", "Glycol"})
        Me.cboFluid.Location = New System.Drawing.Point(104, 8)
        Me.cboFluid.Name = "cboFluid"
        Me.cboFluid.Size = New System.Drawing.Size(72, 21)
        Me.cboFluid.TabIndex = 1
        '
        'lblFluid
        '
        Me.lblFluid.Location = New System.Drawing.Point(4, 8)
        Me.lblFluid.Name = "lblFluid"
        Me.lblFluid.Size = New System.Drawing.Size(92, 21)
        Me.lblFluid.TabIndex = 14
        Me.lblFluid.Text = "Fluid"
        Me.lblFluid.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbo_cooling_media
        '
        Me.cbo_cooling_media.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_cooling_media.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_cooling_media.Items.AddRange(New Object() {"Propylene", "Ethylene"})
        Me.cbo_cooling_media.Location = New System.Drawing.Point(104, 36)
        Me.cbo_cooling_media.Name = "cbo_cooling_media"
        Me.cbo_cooling_media.Size = New System.Drawing.Size(72, 21)
        Me.cbo_cooling_media.TabIndex = 3
        '
        'lblCoolingMedia
        '
        Me.lblCoolingMedia.Location = New System.Drawing.Point(4, 36)
        Me.lblCoolingMedia.Name = "lblCoolingMedia"
        Me.lblCoolingMedia.Size = New System.Drawing.Size(92, 21)
        Me.lblCoolingMedia.TabIndex = 12
        Me.lblCoolingMedia.Text = "Cooling media"
        Me.lblCoolingMedia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSuctionTemp
        '
        Me.txtSuctionTemp.Location = New System.Drawing.Point(104, 148)
        Me.txtSuctionTemp.Name = "txtSuctionTemp"
        Me.txtSuctionTemp.ReadOnly = True
        Me.txtSuctionTemp.Size = New System.Drawing.Size(72, 21)
        Me.txtSuctionTemp.TabIndex = 11
        Me.txtSuctionTemp.TabStop = False
        Me.txtSuctionTemp.Text = "33"
        '
        'lblMinSuctionTemp
        '
        Me.lblMinSuctionTemp.Location = New System.Drawing.Point(4, 148)
        Me.lblMinSuctionTemp.Name = "lblMinSuctionTemp"
        Me.lblMinSuctionTemp.Size = New System.Drawing.Size(92, 21)
        Me.lblMinSuctionTemp.TabIndex = 10
        Me.lblMinSuctionTemp.Text = "Minimum suction"
        Me.lblMinSuctionTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSubCooling
        '
        Me.txtSubCooling.Location = New System.Drawing.Point(104, 176)
        Me.txtSubCooling.Name = "txtSubCooling"
        Me.txtSubCooling.ReadOnly = True
        Me.txtSubCooling.Size = New System.Drawing.Size(72, 21)
        Me.txtSubCooling.TabIndex = 9
        Me.txtSubCooling.TabStop = False
        Me.txtSubCooling.Text = "15"
        '
        'lblSubCooling
        '
        Me.lblSubCooling.Location = New System.Drawing.Point(16, 176)
        Me.lblSubCooling.Name = "lblSubCooling"
        Me.lblSubCooling.Size = New System.Drawing.Size(80, 21)
        Me.lblSubCooling.TabIndex = 8
        Me.lblSubCooling.Text = "Sub cooling"
        Me.lblSubCooling.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLeavingFluidTemp
        '
        Me.txtLeavingFluidTemp.Location = New System.Drawing.Point(368, 92)
        Me.txtLeavingFluidTemp.Name = "txtLeavingFluidTemp"
        Me.txtLeavingFluidTemp.Size = New System.Drawing.Size(72, 21)
        Me.txtLeavingFluidTemp.TabIndex = 10
        Me.txtLeavingFluidTemp.Text = "44"
        Me.ToolTip1.SetToolTip(Me.txtLeavingFluidTemp, "Leaving fluid temperature, range -40°F to 75°F")
        '
        'lblLeavingFluidTemp
        '
        Me.lblLeavingFluidTemp.Location = New System.Drawing.Point(289, 92)
        Me.lblLeavingFluidTemp.Name = "lblLeavingFluidTemp"
        Me.lblLeavingFluidTemp.Size = New System.Drawing.Size(76, 21)
        Me.lblLeavingFluidTemp.TabIndex = 6
        Me.lblLeavingFluidTemp.Text = "Leaving fluid"
        Me.lblLeavingFluidTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAmbientTemp
        '
        Me.lblAmbientTemp.Location = New System.Drawing.Point(289, 64)
        Me.lblAmbientTemp.Name = "lblAmbientTemp"
        Me.lblAmbientTemp.Size = New System.Drawing.Size(76, 21)
        Me.lblAmbientTemp.TabIndex = 5
        Me.lblAmbientTemp.Text = "Ambient"
        Me.lblAmbientTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAmbientTemp
        '
        Me.txtAmbientTemp.Location = New System.Drawing.Point(368, 64)
        Me.txtAmbientTemp.Name = "txtAmbientTemp"
        Me.txtAmbientTemp.Size = New System.Drawing.Size(72, 21)
        Me.txtAmbientTemp.TabIndex = 9
        Me.txtAmbientTemp.Text = "95"
        '
        'lblTempRange
        '
        Me.lblTempRange.Location = New System.Drawing.Point(289, 36)
        Me.lblTempRange.Name = "lblTempRange"
        Me.lblTempRange.Size = New System.Drawing.Size(76, 21)
        Me.lblTempRange.TabIndex = 3
        Me.lblTempRange.Text = "Range"
        Me.lblTempRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTempRange
        '
        Me.txtTempRange.Location = New System.Drawing.Point(368, 36)
        Me.txtTempRange.Name = "txtTempRange"
        Me.txtTempRange.Size = New System.Drawing.Size(72, 21)
        Me.txtTempRange.TabIndex = 8
        Me.txtTempRange.Text = "10"
        '
        'lblRefrigerant
        '
        Me.lblRefrigerant.Location = New System.Drawing.Point(289, 8)
        Me.lblRefrigerant.Name = "lblRefrigerant"
        Me.lblRefrigerant.Size = New System.Drawing.Size(76, 21)
        Me.lblRefrigerant.TabIndex = 1
        Me.lblRefrigerant.Text = "Refrigerant"
        Me.lblRefrigerant.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboRefrigerant
        '
        Me.cboRefrigerant.Location = New System.Drawing.Point(368, 8)
        Me.cboRefrigerant.Name = "cboRefrigerant"
        Me.cboRefrigerant.Size = New System.Drawing.Size(72, 21)
        Me.cboRefrigerant.TabIndex = 7
        '
        'panRatingCriteriaHeader
        '
        Me.panRatingCriteriaHeader.BackColor = System.Drawing.Color.White
        Me.panRatingCriteriaHeader.Controls.Add(Me.lineRatingCriteria)
        Me.panRatingCriteriaHeader.Controls.Add(Me.btnCriteriaPlus)
        Me.panRatingCriteriaHeader.Controls.Add(Me.lblRatingCriteria)
        Me.panRatingCriteriaHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panRatingCriteriaHeader.Location = New System.Drawing.Point(0, 151)
        Me.panRatingCriteriaHeader.Name = "panRatingCriteriaHeader"
        Me.panRatingCriteriaHeader.Size = New System.Drawing.Size(671, 40)
        Me.panRatingCriteriaHeader.TabIndex = 2
        '
        'lineRatingCriteria
        '
        Me.lineRatingCriteria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lineRatingCriteria.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.lineRatingCriteria.Location = New System.Drawing.Point(12, 36)
        Me.lineRatingCriteria.Name = "lineRatingCriteria"
        Me.lineRatingCriteria.Size = New System.Drawing.Size(500, 2)
        Me.lineRatingCriteria.TabIndex = 6
        Me.lineRatingCriteria.Text = "Button1"
        '
        'btnCriteriaPlus
        '
        Me.btnCriteriaPlus.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnCriteriaPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCriteriaPlus.Font = New System.Drawing.Font("Garamond", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCriteriaPlus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnCriteriaPlus.Location = New System.Drawing.Point(16, 15)
        Me.btnCriteriaPlus.Name = "btnCriteriaPlus"
        Me.btnCriteriaPlus.Size = New System.Drawing.Size(20, 18)
        Me.btnCriteriaPlus.TabIndex = 5
        Me.btnCriteriaPlus.Text = "-"
        Me.btnCriteriaPlus.UseVisualStyleBackColor = False
        '
        'lblRatingCriteria
        '
        Me.lblRatingCriteria.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRatingCriteria.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.lblRatingCriteria.Location = New System.Drawing.Point(44, 12)
        Me.lblRatingCriteria.Name = "lblRatingCriteria"
        Me.lblRatingCriteria.Size = New System.Drawing.Size(472, 24)
        Me.lblRatingCriteria.TabIndex = 5
        Me.lblRatingCriteria.Text = "Rating Criteria"
        Me.lblRatingCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'controlFactorsPanel
        '
        Me.controlFactorsPanel.Controls.Add(Me.Label1)
        Me.controlFactorsPanel.Controls.Add(Me.optionsHeaderLabel)
        Me.controlFactorsPanel.Controls.Add(Me.condenserCapacityFactorTextBox)
        Me.controlFactorsPanel.Controls.Add(Me.compressorAmpFactorTextBox)
        Me.controlFactorsPanel.Controls.Add(Me.compressorKwFactorTextBox)
        Me.controlFactorsPanel.Controls.Add(Me.compressorCapacityFactorTextBox)
        Me.controlFactorsPanel.Controls.Add(Me.compressorAmpFactorLabel)
        Me.controlFactorsPanel.Controls.Add(Me.capacityFactorTextBox)
        Me.controlFactorsPanel.Controls.Add(Me.compressorKwFactorLabel)
        Me.controlFactorsPanel.Controls.Add(Me.compressorCapacityFactorLabel)
        Me.controlFactorsPanel.Controls.Add(Me.condenserCapacityFactorLabel)
        Me.controlFactorsPanel.Controls.Add(Me.capacityFactorLabel)
        Me.controlFactorsPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.controlFactorsPanel.Location = New System.Drawing.Point(0, 64)
        Me.controlFactorsPanel.Name = "controlFactorsPanel"
        Me.controlFactorsPanel.Size = New System.Drawing.Size(671, 87)
        Me.controlFactorsPanel.TabIndex = 10
        Me.controlFactorsPanel.Visible = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(17, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 21)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Correction factors"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'optionsHeaderLabel
        '
        Me.optionsHeaderLabel.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optionsHeaderLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.optionsHeaderLabel.Location = New System.Drawing.Point(44, 3)
        Me.optionsHeaderLabel.Name = "optionsHeaderLabel"
        Me.optionsHeaderLabel.Size = New System.Drawing.Size(448, 24)
        Me.optionsHeaderLabel.TabIndex = 20
        Me.optionsHeaderLabel.Text = "Engineering Options"
        Me.optionsHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'condenserCapacityFactorTextBox
        '
        Me.condenserCapacityFactorTextBox.Location = New System.Drawing.Point(446, 53)
        Me.condenserCapacityFactorTextBox.Name = "condenserCapacityFactorTextBox"
        Me.condenserCapacityFactorTextBox.Size = New System.Drawing.Size(37, 21)
        Me.condenserCapacityFactorTextBox.TabIndex = 18
        Me.condenserCapacityFactorTextBox.Text = "1"
        '
        'compressorAmpFactorTextBox
        '
        Me.compressorAmpFactorTextBox.Location = New System.Drawing.Point(272, 53)
        Me.compressorAmpFactorTextBox.Name = "compressorAmpFactorTextBox"
        Me.compressorAmpFactorTextBox.Size = New System.Drawing.Size(37, 21)
        Me.compressorAmpFactorTextBox.TabIndex = 14
        Me.compressorAmpFactorTextBox.Text = "1"
        '
        'compressorKwFactorTextBox
        '
        Me.compressorKwFactorTextBox.Location = New System.Drawing.Point(619, 52)
        Me.compressorKwFactorTextBox.Name = "compressorKwFactorTextBox"
        Me.compressorKwFactorTextBox.Size = New System.Drawing.Size(37, 21)
        Me.compressorKwFactorTextBox.TabIndex = 12
        Me.compressorKwFactorTextBox.Text = "1"
        Me.compressorKwFactorTextBox.Visible = False
        '
        'compressorCapacityFactorTextBox
        '
        Me.compressorCapacityFactorTextBox.Location = New System.Drawing.Point(619, 25)
        Me.compressorCapacityFactorTextBox.Name = "compressorCapacityFactorTextBox"
        Me.compressorCapacityFactorTextBox.Size = New System.Drawing.Size(37, 21)
        Me.compressorCapacityFactorTextBox.TabIndex = 10
        Me.compressorCapacityFactorTextBox.Text = "1"
        Me.compressorCapacityFactorTextBox.Visible = False
        '
        'compressorAmpFactorLabel
        '
        Me.compressorAmpFactorLabel.Location = New System.Drawing.Point(157, 54)
        Me.compressorAmpFactorLabel.Name = "compressorAmpFactorLabel"
        Me.compressorAmpFactorLabel.Size = New System.Drawing.Size(109, 21)
        Me.compressorAmpFactorLabel.TabIndex = 17
        Me.compressorAmpFactorLabel.Text = "Compressor amps"
        Me.compressorAmpFactorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'capacityFactorTextBox
        '
        Me.capacityFactorTextBox.Location = New System.Drawing.Point(103, 54)
        Me.capacityFactorTextBox.Name = "capacityFactorTextBox"
        Me.capacityFactorTextBox.Size = New System.Drawing.Size(37, 21)
        Me.capacityFactorTextBox.TabIndex = 8
        Me.capacityFactorTextBox.Text = "1"
        '
        'compressorKwFactorLabel
        '
        Me.compressorKwFactorLabel.BackColor = System.Drawing.Color.Red
        Me.compressorKwFactorLabel.Location = New System.Drawing.Point(504, 52)
        Me.compressorKwFactorLabel.Name = "compressorKwFactorLabel"
        Me.compressorKwFactorLabel.Size = New System.Drawing.Size(119, 21)
        Me.compressorKwFactorLabel.TabIndex = 16
        Me.compressorKwFactorLabel.Text = "Compressor KW"
        Me.compressorKwFactorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.compressorKwFactorLabel.Visible = False
        '
        'compressorCapacityFactorLabel
        '
        Me.compressorCapacityFactorLabel.BackColor = System.Drawing.Color.Red
        Me.compressorCapacityFactorLabel.Location = New System.Drawing.Point(504, 25)
        Me.compressorCapacityFactorLabel.Name = "compressorCapacityFactorLabel"
        Me.compressorCapacityFactorLabel.Size = New System.Drawing.Size(119, 21)
        Me.compressorCapacityFactorLabel.TabIndex = 15
        Me.compressorCapacityFactorLabel.Text = "Compressor est. capacity"
        Me.compressorCapacityFactorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.compressorCapacityFactorLabel.Visible = False
        '
        'condenserCapacityFactorLabel
        '
        Me.condenserCapacityFactorLabel.Location = New System.Drawing.Point(331, 53)
        Me.condenserCapacityFactorLabel.Name = "condenserCapacityFactorLabel"
        Me.condenserCapacityFactorLabel.Size = New System.Drawing.Size(109, 21)
        Me.condenserCapacityFactorLabel.TabIndex = 19
        Me.condenserCapacityFactorLabel.Text = "Condenser est. capacity"
        Me.condenserCapacityFactorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'capacityFactorLabel
        '
        Me.capacityFactorLabel.Location = New System.Drawing.Point(18, 53)
        Me.capacityFactorLabel.Name = "capacityFactorLabel"
        Me.capacityFactorLabel.Size = New System.Drawing.Size(79, 21)
        Me.capacityFactorLabel.TabIndex = 9
        Me.capacityFactorLabel.Text = "Est. Capacity"
        Me.capacityFactorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'modelPanel
        '
        Me.modelPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.modelPanel.Controls.Add(Me.cbo_models)
        Me.modelPanel.Controls.Add(Me.cbo_series)
        Me.modelPanel.Controls.Add(Me.lblSeries)
        Me.modelPanel.Controls.Add(Me.txt_model)
        Me.modelPanel.Controls.Add(Me.modelLabel)
        Me.modelPanel.Controls.Add(Me.MenuStrip1)
        Me.modelPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.modelPanel.Location = New System.Drawing.Point(0, 0)
        Me.modelPanel.Name = "modelPanel"
        Me.modelPanel.Size = New System.Drawing.Size(671, 64)
        Me.modelPanel.TabIndex = 1
        '
        'cbo_models
        '
        Me.cbo_models.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_models.Location = New System.Drawing.Point(76, 36)
        Me.cbo_models.MaxDropDownItems = 20
        Me.cbo_models.Name = "cbo_models"
        Me.cbo_models.Size = New System.Drawing.Size(112, 21)
        Me.cbo_models.TabIndex = 2
        '
        'cbo_series
        '
        Me.cbo_series.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_series.Items.AddRange(New Object() {"30A2", "30A1", "30A0"})
        Me.cbo_series.Location = New System.Drawing.Point(76, 8)
        Me.cbo_series.Name = "cbo_series"
        Me.cbo_series.Size = New System.Drawing.Size(112, 21)
        Me.cbo_series.TabIndex = 1
        '
        'lblSeries
        '
        Me.lblSeries.Location = New System.Drawing.Point(4, 8)
        Me.lblSeries.Name = "lblSeries"
        Me.lblSeries.Size = New System.Drawing.Size(64, 21)
        Me.lblSeries.TabIndex = 5
        Me.lblSeries.Text = "Series"
        Me.lblSeries.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_model
        '
        Me.txt_model.Location = New System.Drawing.Point(192, 36)
        Me.txt_model.Name = "txt_model"
        Me.txt_model.Size = New System.Drawing.Size(120, 21)
        Me.txt_model.TabIndex = 3
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(671, 24)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'fileMenuItem
        '
        Me.fileMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.saveMenuItem, Me.saveAsRevisionMenuItem, Me.saveAsMenuItem, Me.ToolStripSeparator3, Me.convertToEquipmentMenuItem, Me.ToolStripSeparator1, Me.printMenuItem})
        Me.fileMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly
        Me.fileMenuItem.Name = "fileMenuItem"
        Me.fileMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.fileMenuItem.Text = "File"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(197, 6)
        '
        'saveMenuItem
        '
        Me.saveMenuItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Save
        Me.saveMenuItem.Name = "saveMenuItem"
        Me.saveMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.saveMenuItem.Text = "Save"
        '
        'saveAsRevisionMenuItem
        '
        Me.saveAsRevisionMenuItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.SaveAsRevision
        Me.saveAsRevisionMenuItem.Name = "saveAsRevisionMenuItem"
        Me.saveAsRevisionMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.saveAsRevisionMenuItem.Text = "Save as Revision"
        '
        'saveAsMenuItem
        '
        Me.saveAsMenuItem.Name = "saveAsMenuItem"
        Me.saveAsMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.saveAsMenuItem.Text = "Save as..."
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(197, 6)
        '
        'convertToEquipmentMenuItem
        '
        Me.convertToEquipmentMenuItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.ConvertToEquipment
        Me.convertToEquipmentMenuItem.Name = "convertToEquipmentMenuItem"
        Me.convertToEquipmentMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.convertToEquipmentMenuItem.Text = "Convert to Equipment..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(197, 6)
        Me.ToolStripSeparator1.Visible = False
        '
        'printMenuItem
        '
        Me.printMenuItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Print
        Me.printMenuItem.Name = "printMenuItem"
        Me.printMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.printMenuItem.Text = "Print..."
        '
        'btn_go_to_pricing
        '
        Me.btn_go_to_pricing.BackColor = System.Drawing.Color.White
        Me.btn_go_to_pricing.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_go_to_pricing.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_go_to_pricing.ForeColor = System.Drawing.Color.Navy
        Me.btn_go_to_pricing.Image = Global.Rae.RaeSolutions.My.Resources.Resources.ConvertToEquipment
        Me.btn_go_to_pricing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_go_to_pricing.Location = New System.Drawing.Point(351, 4)
        Me.btn_go_to_pricing.Name = "btn_go_to_pricing"
        Me.btn_go_to_pricing.Size = New System.Drawing.Size(130, 24)
        Me.btn_go_to_pricing.TabIndex = 116
        Me.btn_go_to_pricing.Text = "Go To Pricing"
        Me.btn_go_to_pricing.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_go_to_pricing.UseVisualStyleBackColor = False
        '
        'btn_create_report
        '
        Me.btn_create_report.BackColor = System.Drawing.Color.White
        Me.btn_create_report.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_create_report.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_create_report.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btn_create_report.Image = CType(resources.GetObject("btn_create_report.Image"), System.Drawing.Image)
        Me.btn_create_report.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_create_report.Location = New System.Drawing.Point(5, 4)
        Me.btn_create_report.Name = "btn_create_report"
        Me.btn_create_report.Size = New System.Drawing.Size(164, 24)
        Me.btn_create_report.TabIndex = 2
        Me.btn_create_report.Text = "Create Report"
        Me.btn_create_report.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_create_report.UseVisualStyleBackColor = False
        '
        'lblErro
        '
        Me.lblErro.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.lblErro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblErro.ForeColor = System.Drawing.Color.Black
        Me.lblErro.Location = New System.Drawing.Point(32, 0)
        Me.lblErro.Name = "lblErro"
        Me.lblErro.Size = New System.Drawing.Size(170, 32)
        Me.lblErro.TabIndex = 5
        Me.lblErro.Text = "If errors occur they will be shown here"
        Me.lblErro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 8000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 500
        '
        'panFooter
        '
        Me.panFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.panFooter.Controls.Add(Me.lblErro)
        Me.panFooter.Controls.Add(Me.panButtons)
        Me.panFooter.Controls.Add(Me.picError)
        Me.panFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panFooter.Location = New System.Drawing.Point(0, 521)
        Me.panFooter.Name = "panFooter"
        Me.panFooter.Size = New System.Drawing.Size(688, 32)
        Me.panFooter.TabIndex = 4
        '
        'panButtons
        '
        Me.panButtons.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.panButtons.Controls.Add(Me.btn_go_to_pricing)
        Me.panButtons.Controls.Add(Me.btn_calculate_page)
        Me.panButtons.Controls.Add(Me.btn_create_report)
        Me.panButtons.Dock = System.Windows.Forms.DockStyle.Right
        Me.panButtons.Location = New System.Drawing.Point(202, 0)
        Me.panButtons.Name = "panButtons"
        Me.panButtons.Size = New System.Drawing.Size(486, 32)
        Me.panButtons.TabIndex = 2
        '
        'btn_calculate_page
        '
        Me.btn_calculate_page.BackColor = System.Drawing.Color.White
        Me.btn_calculate_page.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_calculate_page.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_calculate_page.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btn_calculate_page.Image = CType(resources.GetObject("btn_calculate_page.Image"), System.Drawing.Image)
        Me.btn_calculate_page.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_calculate_page.Location = New System.Drawing.Point(174, 4)
        Me.btn_calculate_page.Name = "btn_calculate_page"
        Me.btn_calculate_page.Size = New System.Drawing.Size(172, 24)
        Me.btn_calculate_page.TabIndex = 1
        Me.btn_calculate_page.Text = "Calculate Page "
        Me.btn_calculate_page.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_calculate_page.UseVisualStyleBackColor = False
        '
        'picError
        '
        Me.picError.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.picError.Dock = System.Windows.Forms.DockStyle.Left
        Me.picError.Image = CType(resources.GetObject("picError.Image"), System.Drawing.Image)
        Me.picError.Location = New System.Drawing.Point(0, 0)
        Me.picError.Name = "picError"
        Me.picError.Size = New System.Drawing.Size(32, 32)
        Me.picError.TabIndex = 0
        Me.picError.TabStop = False
        '
        'err
        '
        Me.err.ContainerControl = Me
        Me.err.Icon = CType(resources.GetObject("err.Icon"), System.Drawing.Icon)
        '
        'SaveToolStripPanel1
        '
        Me.SaveToolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SaveToolStripPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SaveToolStripPanel1.Name = "SaveToolStripPanel1"
        Me.SaveToolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.SaveToolStripPanel1.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.SaveToolStripPanel1.Size = New System.Drawing.Size(688, 0)
        '
        'air_cooled_chiller_balance_window
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(688, 553)
        Me.Controls.Add(Me.SaveToolStripPanel1)
        Me.Controls.Add(Me.panMain)
        Me.Controls.Add(Me.panFooter)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "air_cooled_chiller_balance_window"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Technical Systems - Chiller Rating - Air Cooled"
        CType(Me.results, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panMain.ResumeLayout(False)
        Me.panGrid.ResumeLayout(False)
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panEvapHide.ResumeLayout(False)
        Me.panEvapHide.PerformLayout()
        Me.panEvaporatorHeader.ResumeLayout(False)
        Me.panCondHide.ResumeLayout(False)
        Me.panCondHide.PerformLayout()
        Me.panCondenser.ResumeLayout(False)
        Me.panCondenser.PerformLayout()
        Me.panCondenserHeader.ResumeLayout(False)
        Me.panCompDataHide.ResumeLayout(False)
        Me.panCompressor.ResumeLayout(False)
        Me.panCompressor.PerformLayout()
        Me.panCirc.ResumeLayout(False)
        Me.panCompressorHeader.ResumeLayout(False)
        Me.panRatiCritHide.ResumeLayout(False)
        Me.panRatingCriteria.ResumeLayout(False)
        Me.panRatingCriteria.PerformLayout()
        Me.panRatingCriteriaHeader.ResumeLayout(False)
        Me.controlFactorsPanel.ResumeLayout(False)
        Me.controlFactorsPanel.PerformLayout()
        Me.modelPanel.ResumeLayout(False)
        Me.modelPanel.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.panFooter.ResumeLayout(False)
        Me.panButtons.ResumeLayout(False)
        CType(Me.picError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.err, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


#Region "Variables"
    Dim my_Gly_Pro(12, 4) As Double
    Dim ok_to_print_SPACE As Boolean
    Dim ok_to_print As Boolean
    Dim myarrayprint As New ArrayList    'circuit 1
    Dim myarrayprint2 As New ArrayList   'circuit 2
    Dim myarrayprint3 As New ArrayList       'circuit 1 holding
    Dim Running_Circuit_no As Single

    Dim ok_to_show As Boolean
    Dim Hold_Set_PD(20) As Double


    Dim Q8 As Double                 'CHILLER CAP. @ 8 DEG APPROACH
    Dim Q9 As Double                 'CHILLER CAP. @ 10 DEG APPROACH
    Dim subCoolingFactor As Double                'GLYCOL

    'TODO: reduce scope
    Dim GPMFACT As Double            'GLYCOL
    Dim hz_q, hz_w As Double
    Friend PD_GPM(13, 2) As Double

    Dim CalculatedSubcoolingMultiplier1 As Double
    Dim CalculatedSubcoolingMultiplier2 As Double


#End Region


    Private loaded As Boolean = False
    Private standardRef As New StandardRefrigerationTasks(Me)


#Region "Control Wrappers"

    Friend ReadOnly Property ambient_temperature As Double
        Get
            Return ConvertNull.ToDouble(txtAmbientTemp.Text)
        End Get
    End Property

    Friend Property TempRange As Double
        Get
            Return ConvertNull.ToDouble(txtTempRange.Text)
        End Get
        Set(ByVal value As Double)
            txtTempRange.Text = value.ToString
        End Set
    End Property

    Friend ReadOnly Property EnteringFluidTemp As Double
        Get
            Return leaving_fluid_temperature + TempRange
        End Get
    End Property

    Friend Property leaving_fluid_temperature() As Double
        Get
            Return ConvertNull.ToDouble(txtLeavingFluidTemp.Text)
        End Get
        Set(ByVal value As Double)
            txtLeavingFluidTemp.Text = value.ToString
        End Set
    End Property

    Friend Function CoolingFluid() As CoolingMedia
        Dim fluid As CoolingMedia

        If cboFluid.SelectedItem.ToString = "Water" Then
            fluid = CoolingMedia.Water
        Else ' is glycol
            If cbo_cooling_media.SelectedItem.ToString = "Ethylene" Then
                fluid = CoolingMedia.Ethylene
            ElseIf cbo_cooling_media.SelectedItem.ToString = "Propylene" Then
                fluid = CoolingMedia.Propylene
            End If
        End If

        Return fluid
    End Function

    Friend ReadOnly Property GlycolPercentage As Double
        Get
            Return ConvertNull.ToDouble(txtGlycolPercentage.Text)
        End Get
    End Property

    Friend ReadOnly Property FoulingFactor As Double
        Get
            Return ConvertNull.ToDouble(cboFoulingFactor.SelectedItem)
        End Get
    End Property

    Friend ReadOnly Property MinSuctionTemp As Double
        Get
            Return ConvertNull.ToDouble(txtSuctionTemp.Text.Trim)
        End Get
    End Property

    Friend ReadOnly Property EvaporatorLength As Double
        Get
            Return ConvertNull.ToDouble(txtEvapLength.Text.Trim)
        End Get
    End Property

    Friend ReadOnly Property NumCircuits As Integer
        Get
            Return ConvertNull.ToInteger(txtNumCircuits.Text.Trim)
        End Get
    End Property

    Friend ReadOnly Property RefrigerantString As String
        Get
            Return cboRefrigerant.SelectedItem.ValueName
        End Get
    End Property

    Friend ReadOnly Property EvaporatorModel As String
        Get
            Return txt_evaporator_model.Text.Trim
        End Get
    End Property

    Private ReadOnly Property fan As Business.Entities.Fan
        Get
            Return DirectCast(Me.cboFan.SelectedItem, Business.Entities.Fan)
        End Get
    End Property

#End Region


#Region " Event Handlers"

#Region " Form Event Handlers"

    Private Sub form_Activated() Handles Me.Activated
        initializeSaveToolStripPanel()
        SaveToolStripPanel1.Merge()
    End Sub


    Private Sub form_Deactivate() Handles Me.Deactivate
        SaveToolStripPanel1.Unmerge()
    End Sub


    Private Sub form_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) _
    Handles Me.FormClosing
        If Not Me.ProcessDeleted Then
            If SaveControls(False, False, True) = False Then
                e.Cancel = True
            Else
                RemoveHandler AppInfo.Main.RevisionView1.RevisionChanged, AddressOf RevisionView_RevisionChanged
            End If
        End If
    End Sub

    Private compressor_repository As i_compressor_repository
    Private model_changed_schedule, evaporator_changed_schedule As execution_schedule
    Friend service As service
    Private fluid_properties_controller As fluid_properties.controller

    Private Sub form_load() _
    Handles MyBase.Load
        compressor_repository = New compressor_repository()
        Dim chiller_repository = New repository()
        service = New service(compressor_repository, chiller_repository, AppInfo.User)

        fluid_properties_controller = New fluid_properties.controller(Me)

        initializeSaveToolStripPanel()

        'SIZE WINDOW TO THE HEIGHT OF THE MAIN FORM's CLIENT AREA
        Me.Height = Ui.FormEditor.MaximizeHeight(Me)
        'align child form to top of mdiparent's client area
        Me.Location = New System.Drawing.Point(Me.Location.X, 0)

        colorControls()

        fillComboboxes()

        cboVolts.SelectedIndex = 1

        fillCompressorListBoxes()

        initializeControls()

        authorize()

        initializeValidation()

        Dim model_changed_method As command = AddressOf handle_model_changed
        Dim selected_model = grab_model()
        model_changed_schedule = execution_schedule.Execute(model_changed_method).on(Me).after_last_change_to(selected_model).is_unchanged_for(msec:=500)

        Dim evaporator_changed_method As command = AddressOf handle_evaporator_changed
        Dim evaporator_model = grab_evaporator_model_from_textbox()
        evaporator_changed_schedule = execution_schedule.Execute(evaporator_changed_method).on(Me).after_last_change_to(evaporator_model).is_unchanged_for(msec:=500)

        loaded = True

        'add handler to revision view . revision changed event on main form...
        AddHandler AppInfo.Main.RevisionView1.RevisionChanged, AddressOf RevisionView_RevisionChanged

    End Sub

    Private Function grab_evaporator_model_from_textbox() As String
        Return txt_evaporator_model.Text
    End Function

#End Region


#Region " Button Event Handlers"

    Private Sub btn_alternate_evaporators_click() _
    Handles btn_alternate_evaporators.Click
        set_enabled_on_acme_related_controls(enabled:=False)

        standardRef.ListAlternateEvaporators()
        cbo_evaporator_model.Visible = True

        set_enabled_on_acme_related_controls(enabled:=True)
    End Sub


    ' opens chart in popup form that displays
    ' 1. Leaving Fluid Temp., 2. Recommended Glycol, 3. Freeze Point, 4. Minimum Suction Temp.
    Private Sub btnGlycolChart_Click() _
    Handles btnGlycolChart.Click
        Dim form As New Windows.Forms.Form
        ''Dim myGrid As New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Dim myGrid1 As New Grid
        Dim glycolTable As DataTable
        Dim glycol As String
        Dim formWidth, formHeight As Integer

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        ' sets selected glycol (ethylene or propylene)
        glycol = Me.cbo_cooling_media.SelectedItem.ToString

        ' retrieves glycol table of recommendations
        If glycol = "Ethylene" Then
            glycolTable = DataAccess.Chillers.ChillerDataAccess.RetrieveEthylene()
        ElseIf glycol = "Propylene" Then
            glycolTable = DataAccess.Chillers.ChillerDataAccess.RetrievePropylene()
        Else
            inform("The selected fluid is water; the fluid must be a glycol in order to chart recommendations.")
            Exit Sub
        End If

        ' adds grid to form
        ' Note: need to add grid to form before setting datasource
        form.Controls.Add(myGrid1)
        ' sets datagrid's data source
        myGrid1.DataSource = glycolTable
        myGrid1.Columns(GlycolNames.LeavingFluidTemperature).Width = 200
        myGrid1.Columns(GlycolNames.FreezingPoint).Width = 200
        myGrid1.Columns(GlycolNames.RecommendedGlycolPercentage).Width = 200
        myGrid1.Columns(GlycolNames.RecommendedMinSuctionTemperature).Width = 200
        myGrid1.Columns(GlycolNames.LeavingFluidTemperature).HeaderText = "Leaving Fluid Temperature [°F]"
        myGrid1.Columns(GlycolNames.FreezingPoint).HeaderText = "Freezing Point [°F]"
        myGrid1.Columns(GlycolNames.RecommendedGlycolPercentage).HeaderText = "Recommended Glycol [%]"
        myGrid1.Columns(GlycolNames.RecommendedMinSuctionTemperature).HeaderText = "Recommended Minimum Suction Temperature [°F]"
        myGrid1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray
        myGrid1.EnableHeadersVisualStyles = False
        myGrid1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue
        ' sets column width and captions
        ''With myGrid1.Splits(0)
        ''    ' sets column properties
        ''    .ColumnCaptionHeight = 36

        ''    .DisplayColumns(GlycolNames.LeavingFluidTemperature).Width = 100
        ''    .DisplayColumns(GlycolNames.LeavingFluidTemperature).DataColumn.Caption = "Leaving Fluid Temperature [°F]"
        ''    .DisplayColumns(GlycolNames.FreezingPoint).Width = 80
        ''    .DisplayColumns(GlycolNames.FreezingPoint).DataColumn.Caption = "Freezing Point [°F]"
        ''    .DisplayColumns(GlycolNames.RecommendedGlycolPercentage).Width = 85
        ''    .DisplayColumns(GlycolNames.RecommendedGlycolPercentage).DataColumn.Caption = "Recommended Glycol [%]"
        ''    .DisplayColumns(GlycolNames.RecommendedMinSuctionTemperature).Width = 140
        ''    .DisplayColumns(GlycolNames.RecommendedMinSuctionTemperature).DataColumn.Caption =
        ''       "Recommended Minimum Suction Temperature [°F]"
        ''End With
        myGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        ''myGrid1.Caption = glycol & " Table"

        ' sets grid style to pre-defined style
        ''Rae.Ui.C1GridStyles.BasicGridStyle(myGrid)

        ' initializes form width to outer border width + vertical scroll bar width
        ''formWidth = 5 * 2 + myGrid.VScrollBar.Width
        ''For i As Integer = 0 To myGrid.Splits(0).DisplayColumns.Count - 1
        ''    ' calculates form width based on column width and inner borders
        ''    formWidth += myGrid.Splits(0).DisplayColumns(i).Width + 1
        ''Next

        ''' calculates for height (just estimate)
        ''formHeight = 34 + myGrid.CaptionHeight + myGrid.Splits(0).ColumnCaptionHeight
        ''For i As Integer = 0 To myGrid.Splits(0).Rows.Count - 1
        ''    formHeight += myGrid.RowHeight + 1
        ''Next

        ' sets form properties
        form.Width = 1000
        form.Height = 1000
        form.Text = glycol & " Recommendations"
        form.MdiParent = Me.MdiParent
        ' shows form w/ glycol chart
        form.Show()

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub


    Private Sub btn_calculate_page_Click() _
    Handles btn_calculate_page.Click
        If chiller_model_is_not_selected() Then
            ''dgrC1Results.DataSource = Nothing
            Grid1.DataSource = Nothing
            inform("Please select a valid chiller model.")
            Exit Sub
        End If

        ' checks if validation controls are valid
        Me.addCompressorValidationHandlers()
        If Not Me.chillerVMgr.Validate() Then
            ''Me.dgrC1Results.DataSource = Nothing
            Me.Grid1.DataSource = Nothing
            warn(Me.chillerVMgr.ErrorMessagesSummary)
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        Try
            set_enabled_on_acme_related_controls(enabled:=False)
            startCalculations()
        Catch ex As Exception
            alert("Page cannot be calculated. " & ex.Message)
        Finally
            set_enabled_on_acme_related_controls(enabled:=True)
        End Try

        Me.Cursor = Cursors.Arrow
        panGrid.Focus()
    End Sub


    Private Sub addCompressorValidationHandlers()
        Dim selectedCircuitNum As Integer
        If Me.radCircuit1.Checked Then
            selectedCircuitNum = 1
        ElseIf Me.radCircuit2.Checked Then
            selectedCircuitNum = 2
        End If
        Dim numCircuitsPerUnit = NumCircuits
        Dim circuitsToRun As List(Of Integer) = Me.getCircuitsToRun(Me.cboSystem.Text, numCircuitsPerUnit, selectedCircuitNum)

        RemoveHandler Me.compressor1VCtrl.Validating, AddressOf compressorVCtrl_Validating
        RemoveHandler Me.compressor2VCtrl.Validating, AddressOf compressorVCtrl_Validating
        For Each circuitToRun As Integer In circuitsToRun
            If circuitToRun = 1 Then
                AddHandler Me.compressor1VCtrl.Validating, AddressOf compressorVCtrl_Validating
            ElseIf circuitToRun = 2 Then
                AddHandler Me.compressor2VCtrl.Validating, AddressOf compressorVCtrl_Validating
            End If
        Next
    End Sub


    Private Sub btn_create_report_click() _
    Handles btn_create_report.Click

        If chiller_model_is_not_selected() Then _
           warn("Please select a valid chiller model.") : Exit Sub

        Cursor = Cursors.WaitCursor

        Try
            set_enabled_on_acme_related_controls(enabled:=False)

            Dim safetyOverrideWasChecked = chkSafetyOverride.Checked
            If safetyOverrideWasChecked And user.cannot(view_overrides_on_report) Then _
               chkSafetyOverride.Checked = False
            startCalculations()

            ''If dgrC1Results.Visible Then
            ''    ' If user.is("MikeM", "DrewS", "AdamM") Then
            ''    ' show_crystal_report()
            ''    'Else
            ''    show_word_report()
            ''    'End If

            ''    ' if compressor safety override was checked, report should not show overrides but datagrid should
            ''    If safetyOverrideWasChecked Then
            ''        chkSafetyOverride.Checked = safetyOverrideWasChecked
            ''        startCalculations()
            ''    End If
            ''Else
            ''    Dim errorMessage As String = "Report could not be created."
            ''    If lblErro.Text = "" Then
            ''        lblErro.Text = errorMessage
            ''    Else
            ''        lblErro.Text &= Environment.NewLine & errorMessage
            ''    End If
            ''End If
            If Grid1.Visible Then
                ' If user.is("MikeM", "DrewS", "AdamM") Then
                ' show_crystal_report()
                'Else
                show_word_report()
                'End If

                ' if compressor safety override was checked, report should not show overrides but datagrid should
                If safetyOverrideWasChecked Then
                    chkSafetyOverride.Checked = safetyOverrideWasChecked
                    startCalculations()
                End If
            Else
                Dim errorMessage As String = "Report could not be created."
                If lblErro.Text = "" Then
                    lblErro.Text = errorMessage
                Else
                    lblErro.Text &= Environment.NewLine & errorMessage
                End If
            End If
        Catch ex As Exception
            alert("The report cannot be generated. " & ex.Message)
        Finally
            set_enabled_on_acme_related_controls(enabled:=True)
        End Try

        Cursor = Cursors.Arrow
    End Sub


#End Region


#Region " Combobox Event Handlers"


    Private Sub cboSeries_SelectedIndexChanged() _
    Handles cbo_series.SelectedIndexChanged
        Try
            Dim series = Me.cbo_series.SelectedItem.ToString
            Me.cbo_models.DataSource = service.get_models(series)
        Catch ex As ArgumentException
            alert(ex.Message)
        End Try
    End Sub


    Private Sub cboModels_SelectedIndexChanged() _
    Handles cbo_models.SelectedIndexChanged
        Dim selectedModel = grab_model()

        If Not loaded Or selectedModel = "Choose" Then _
           Exit Sub

        jot("change model: " & selectedModel)
        model_changed_schedule.change(selectedModel)
    End Sub


    Private Sub cboHertz_SelectedIndexChanged() Handles cboHertz.SelectedIndexChanged
        If loaded Then

            ''dgrC1Results.Visible = False 'C1WebGrid2.Visible = False
            Grid1.Visible = False
            lblErro.Text = ""

            Dim switchedFan As String
            Dim fanFileName = Me.fan.FileName

            If cboHertz.SelectedItem = "60" Then
                lblRatiVolt.Visible = False
                lblRatiVolt1.Visible = False
                Select Case fanFileName
                    Case "LAU2429.950" : switchedFan = "LAU2429"
                    Case "BR28IN.950" : switchedFan = "BR28IN"
                    Case "BR28INHA.950" : switchedFan = "BR28IN.HA"
                    Case "BR28IN.708" : switchedFan = "LAU2840.850"
                    Case "S42832.950" : switchedFan = "S42832"
                End Select
            Else
                Select Case fanFileName
                    Case "LAU2429" : switchedFan = "LAU2429.950"
                    Case "BR28IN" : switchedFan = "BR28IN.950"
                    Case "BR28IN.HA" : switchedFan = "BR28INHA.950"
                    Case "LAU2840.850" : switchedFan = "BR28IN.708" 'REP    (BR28IN.708 HOUSE VERSION)
                    Case "S42832" : switchedFan = "S42832.950"
                End Select

                Me.lblRatiVolt.Visible = True
                Me.lblRatiVolt1.Visible = True
            End If

            Dim numFans = cboFan.Items.Count
            For i As Integer = 0 To numFans - 1
                cboFan.SelectedIndex = i
                If Me.fan.FileName = switchedFan Then
                    Exit For
                End If
                If cboFan.SelectedIndex = (numFans - 1) Then
                    cboFan.SelectedIndex = 0
                    Exit For
                End If
            Next i

            Me.setFanWatts()
        End If
    End Sub


    'refrigerant	
    Private Sub cboRatiCritRefr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRefrigerant.SelectedIndexChanged
        Dim compressor As String

        If loaded = True Then
            Me.fillCompressorListBoxes()
            ' retrieves chiller compressor
            Dim chillerTable As DataTable = DataAccess.Chillers.ChillerDataAccess.RetrieveChiller(Me.grab_model())

            ' checks if there is a matching chiller, if model is set to 'Choose', there won't be a match
            If chillerTable.Rows.Count > 0 Then
                ' sets compressor for circuit 1
                compressor = chillerTable.Rows(0)("CompressorMasterID1").ToString
                ' selects compressor
                Me.lboCompressors1.SelectedIndex = ControlAssistant.GetIndexOfValueInListBox(Me.lboCompressors1, compressor)

                ' sets compressor for circuit 2
                compressor = chillerTable.Rows(0)("CompressorMasterID2").ToString
                ' selects compressor
                Me.lboCompressors2.SelectedIndex = ControlAssistant.GetIndexOfValueInListBox(Me.lboCompressors2, compressor)
            End If

            If cboRefrigerant.SelectedItem.ValueName = "R407c" _
            Or cboRefrigerant.SelectedItem.ValueName = "R404a" Then
                btn_alternate_evaporators.Visible = False
            Else
                btn_alternate_evaporators.Visible = True
            End If

            'handles 407c refrigerant
            If cboRefrigerant.SelectedItem.ValueName = "R407c" Then
                txt_evaporator_model.Text = ""
                EvaporatorGrid1.HideApproachSelection()
                EvaporatorGrid1.rboCustom.Checked = True
                'radOtherEvaporator.Checked = True
            Else
                EvaporatorGrid1.ShowApproachSelection()
            End If
        End If
    End Sub


    Private Sub cboSystem_SelectedIndexChanged() Handles cboSystem.SelectedIndexChanged
        ''dgrC1Results.Visible = False
        Grid1.Visible = False
        lblErro.Text() = ""
    End Sub


    Private Sub cboCondenser2_SelectedIndexChanged() Handles cboCondenser2.SelectedIndexChanged
        If loaded = True Then
            setCoilDescription()
        End If
    End Sub

    Private Sub cboCondenser1_SelectedIndexChanged() Handles cboCondenser1.SelectedIndexChanged
        If loaded = True Then
            setCoilDescription()
        End If
    End Sub

    Private Sub cboFan_SelectedIndexChanged() Handles cboFan.SelectedIndexChanged
        If loaded Then
            ''dgrC1Results.Visible = False
            Grid1.Visible = False
            lblErro.Text() = ""

            If fanIsCustom() Then
                Me.txtCfmOverride.Visible = True
                Me.lblCFM.Visible = True
                Me.txtFanWatts.ReadOnly = False
            Else
                Me.txtCfmOverride.Visible = False
                Me.lblCFM.Visible = False
                Me.txtFanWatts.ReadOnly = True
            End If

            setFanWatts()
        End If
    End Sub

    Private Sub cbo_cooling_media_SelectedIndexChanged() Handles cbo_cooling_media.SelectedIndexChanged
        If loaded Then
            set_enabled_on_acme_related_controls(enabled:=False)

            ''dgrC1Results.Visible = False
            Grid1.Visible = False
            lblErro.Text = ""
            standardRef.SetSpecificHeatAndGravity()
            fluid_properties_controller.handle_fluid_changed()

            set_enabled_on_acme_related_controls(enabled:=True)
        End If
    End Sub


    Private Sub cbo_evaporator_model_SelectedIndexChanged() _
    Handles cbo_evaporator_model.SelectedIndexChanged
        set_enabled_on_acme_related_controls(enabled:=False)
        cbo_evaporator_model.Enabled = True

        Dim model = grab_evaporator_model_from_combobox()
        jot("uncomitted evaporator model: " & model)
        evaporator_changed_schedule.change(model)

        If grab_evaporator_model_from_combobox() = "Choose" Then _
           set_enabled_on_acme_related_controls(enabled:=True)
        cbo_evaporator_model.Focus()
    End Sub

    Private Function grab_evaporator_model_from_combobox() As String
        Return cbo_evaporator_model.SelectedItem.ToString()
    End Function

    Private Sub handle_evaporator_changed()
        If loaded Then
            set_enabled_on_acme_related_controls(enabled:=False)

            Dim evaporator_model = cbo_evaporator_model.SelectedItem.ToString.Trim
            If evaporator_model = "Choose" Then _
               Exit Sub

            ''dgrC1Results.Visible = False
            Grid1.Visible = False
            lblErro.Text = ""

            setChillerEvaporatorControls(evaporator_model)
            standardRef.ListEvaporatorDataForApproachRange()

            set_enabled_on_acme_related_controls(enabled:=True)
        End If
    End Sub

    Private Sub cboRatiCritFlui_SelectedIndexChanged() Handles cboFluid.SelectedIndexChanged
        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        ''dgrC1Results.Visible = False
        Grid1.Visible = False
        lblErro.Text() = ""

        If cboFluid.SelectedItem = "Water" Then
            cbo_cooling_media.Visible = False
            txtGlycolPercentage.Enabled = False
            'glycol percentage
            txtGlycolPercentage.Text() = "0"
            Me.btnGlycolChart.Visible = False
            'glycol selected
        Else
            Me.cbo_cooling_media.Visible = True
            Me.txtGlycolPercentage.Enabled = True
            'glycol percentage
            Me.txtGlycolPercentage.Text = "20"
            Me.btnGlycolChart.Visible = True
        End If
        If loaded Then
            standardRef.SetSpecificHeatAndGravity()
            ' TODO: is this necessary?
            fluid_properties_controller.handle_fluid_changed()
        End If

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

#End Region


#Region " Radiobox Event Handlers"

    Private Sub radCompCirc1_CheckedChanged() Handles radCircuit1.CheckedChanged
        If radCircuit1.Checked Then
            lboCompressors1.Enabled = True
            lboCompressors2.Enabled = False
            Running_Circuit_no = 1
        End If
    End Sub

    Private Sub radCompCirc2_CheckedChanged() Handles radCircuit2.CheckedChanged
        If radCircuit2.Checked Then
            lboCompressors2.Enabled = True
            lboCompressors1.Enabled = False
            Running_Circuit_no = 2
        End If
    End Sub

#End Region


#Region " Textbox Event Handlers"

    Private Sub txtGlycolPercentage_TextChanged() _
    Handles txtGlycolPercentage.TextChanged
        If loaded Then
            standardRef.SetSpecificHeatAndGravity()
            fluid_properties_controller.handle_fluid_changed()
        End If
    End Sub


    Private Sub txtLeavingFluidTemp_Leave() _
    Handles txtLeavingFluidTemp.Leave
        leavingFluidTempVCtrl.Validate()
    End Sub

    '1. hide error pic if no errors occurred
    '2. set error text's tooltip
    Private Sub lblErro_TextChanged(ByVal s As Object, ByVal e As EventArgs) _
    Handles lblErro.TextChanged
        ToolTip1.SetToolTip(lblErro, lblErro.Text)
        If lblErro.Text = "" Then
            picError.Visible = False
        Else
            picError.Visible = True
        End If
    End Sub

#End Region


#Region " Listbox Event Handlers"

    Private Sub lbxComp1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lboCompressors1.MouseDown
        If loaded = True Then
            If Me.radCircuit1.Checked Then
                Running_Circuit_no = 1
                Me.txtCompressor1.Text = Me.lboCompressors1.SelectedValue.ToString
            End If
        End If
    End Sub


    Private Sub lbxComp2_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lboCompressors2.MouseDown
        If loaded = True Then
            If radCircuit2.Checked = True Then
                Running_Circuit_no = 2
                Me.txtCompressor2.Text = Me.lboCompressors2.SelectedValue.ToString
            End If
        End If
    End Sub


    Private Sub lbxComp1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lboCompressors1.SelectedIndexChanged
        Me.txtCompressor1.Text = Me.lboCompressors1.SelectedValue.ToString
        Me.txtCompressorMasterID1.Text = CType(Me.lboCompressors1.SelectedItem, DataAccess.CompressorDescription).MasterID
    End Sub


    Private Sub lbxComp2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lboCompressors2.SelectedIndexChanged
        Me.txtCompressor2.Text = Me.lboCompressors2.SelectedValue.ToString
        Me.txtCompressorMasterID2.Text = CType(Me.lboCompressors2.SelectedItem, DataAccess.CompressorDescription).MasterID
    End Sub


#End Region


#Region " Menu Event Handlers"

    ''Private Sub printMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
    ''Handles printMenuItem.Click
    ''    Me.Cursor = Windows.Forms.Cursors.WaitCursor

    ''    Dim doc As New C1.C1PrintDocument.C1PrintDocument
    ''    'controls font and other styles on printed page
    ''    Dim printStyle As New C1.C1PrintDocument.C1DocStyle(doc)  'used in rendering spacer image
    ''    printStyle.Font = New Font("Arial", 10, FontStyle.Regular)
    ''    'the page settings from frmC1PrintPreview.vb are not applied
    ''    'page settings must be set in code in order to be applied
    ''    doc.PageSettings.Margins.Top = 50
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
    ''    doc.RenderBlockControlImage(Me.modelPanel)
    ''    doc.RenderBlockControlImage(Me.panRatingCriteriaHeader)
    ''    doc.RenderBlockControlImage(Me.panRatingCriteria)
    ''    doc.RenderBlockControlImage(Me.panCompressorHeader)
    ''    doc.RenderBlockControlImage(Me.panCompressor)

    ''    'page return				
    ''    Dim whiteImage As Image  'image is used to fill space at the end of a page
    ''    'implemented to function as a page return
    ''    whiteImage = Image.FromFile(AppInfo.AppFolderPath & "Images\whitebox.gif")
    ''    doc.RenderBlockImage(whiteImage, 3, doc.AvailableBlockFlowHeight, printStyle)
    ''    doc.RenderBlockControlImage(Me.panCondenserHeader)
    ''    doc.RenderBlockControlImage(Me.panCondenser)

    ''    'page return		
    ''    doc.RenderBlockImage(whiteImage, 3, doc.AvailableBlockFlowHeight, printStyle)
    ''    doc.RenderBlockControlImage(Me.panEvaporatorHeader)
    ''    doc.RenderBlockControlImage(Me.panEvapHide)

    ''    ''If Not (Me.dgrC1Results.DataSource Is Nothing) Then
    ''    ''    'page return
    ''    ''    doc.RenderBlockImage(whiteImage, 3, doc.AvailableBlockFlowHeight, printStyle)
    ''    ''    doc.RenderBlockControlSmart(Me.dgrC1Results)
    ''    ''End If
    ''    If Not (Me.Grid1.DataSource Is Nothing) Then
    ''        'page return
    ''        doc.RenderBlockImage(whiteImage, 3, doc.AvailableBlockFlowHeight, printStyle)
    ''        doc.RenderBlockControlSmart(Me.Grid1)
    ''    End If
    ''    doc.EndDoc() 'stop rendering

    ''    Dim formPreview As New C1PrintPreviewForm 'create instance form to preview before printing
    ''    formPreview.C1PrintPreview1.Document = doc 'set the form's document to the document just created

    ''    Me.Cursor = Windows.Forms.Cursors.Default

    ''    formPreview.ShowDialog() 'can't have mdiparent otherwise error occurs
    ''    formPreview.Close()
    ''End Sub


    Private Sub saveMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles saveMenuItem.Click
        SaveControls()
    End Sub


    Private Sub saveAsRevisionMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles saveAsRevisionMenuItem.Click
        SaveControls(True)
    End Sub


    Private Sub saveAsMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles saveAsMenuItem.Click
        SaveControls(False, True)
    End Sub


    Private Sub convertToEquipmentMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles convertToEquipmentMenuItem.Click
        SaveControls(False, False, False, True)
    End Sub

#End Region


#Region " Panel Event Handlers"
    '****************************************************************
    '** Button events that hide/show the panels containing the different
    '** sections (Compressor, Condenser, etc) of the form
    '****************************************************************

    'Rating Criteria Hide Button
    Private Sub butRatiCritPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCriteriaPlus.Click
        If Me.btnCriteriaPlus.Text = "+" Then
            Me.panRatiCritHide.Show()
            Me.btnCriteriaPlus.Text = "-"
        Else
            Me.panRatiCritHide.Hide()
            Me.btnCriteriaPlus.Text = "+"
        End If
    End Sub
    'Compressor data Hide Button
    Private Sub butCompDataPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompressorPlus.Click
        If Me.btnCompressorPlus.Text = "+" Then
            Me.panCompDataHide.Show()
            Me.btnCompressorPlus.Text = "-"
        Else
            Me.panCompDataHide.Hide()
            Me.btnCompressorPlus.Text = "+"
        End If
    End Sub
    'Condenser Data Hide Button
    Private Sub butCondPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCondenserPlus.Click
        If Me.btnCondenserPlus.Text = "+" Then
            Me.panCondHide.Show()
            Me.btnCondenserPlus.Text = "-"
        Else
            Me.panCondHide.Hide()
            Me.btnCondenserPlus.Text = "+"
        End If
    End Sub
    'Evaporator Data Hide Button
    Private Sub butEvapPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEvaporatorPlus.Click
        If Me.btnEvaporatorPlus.Text = "+" Then
            Me.panEvapHide.Show()
            Me.btnEvaporatorPlus.Text = "-"
        Else
            Me.panEvapHide.Hide()
            Me.btnEvaporatorPlus.Text = "+"
        End If
    End Sub

#End Region


#End Region


#Region " Helper Methods"

    Private Sub authorize()
        controlFactorsPanel.Visible = user.is_in(chiller_engineering_options)
    End Sub

    ''' <summary>Initializes save tool strip panel. Sets event handlers and tool strip.</summary>
    Private Sub initializeSaveToolStripPanel()
        Me.SaveToolStripPanel1.SetUp(CType(Me.ParentForm, MainForm).mainToolStrip, _
           AddressOf saveMenuItem_Click, AddressOf saveAsRevisionMenuItem_Click)
    End Sub


    ''' <summary>Fills comboboxes with display and hidden values</summary>
    Private Sub fillComboboxes()
        With Me.cboRefrigerant
            .DataSource = Me.GetRefrigerants()
            .DisplayMember = "DisplayName"
            .ValueMember = "ValueName"
        End With

        ' fills condenser comboboxes
        Me.cboCondenser1.DataSource = DataAccess.Chillers.ChillerDataAccess.GetCondensers()
        Me.cboCondenser2.DataSource = DataAccess.Chillers.ChillerDataAccess.GetCondensers()

        ' fills fan comboboxes
        Me.cboFan.DataSource = condensers.condenser_repository.GetChillerFans()

        ' fills fins per inch comboboxes
        Me.cboFinsPerInch1.DataSource = Me.getFinsPerInchOptions()
        Me.cboFinsPerInch2.DataSource = Me.getFinsPerInchOptions()
    End Sub

    Private Function get_report_parameters() As report_parameters
        Dim capacity_at_8, capacity_at_10, condenser_capacity, fan_description As String
        Dim model, condenser_description, system, fluid, circuit_message, operating_limits, catalog_rating_message As String
        Dim numCompressors1, numCompressors2, compressorFileName1, compressorFileName2, compressor_description As String
        Dim circuitsPerUnit, lowerApproach, upperApproach As Integer

        ' sets parameters
        '
        If txt_model.Text = grab_model() Then
            model = Me.grab_model()
        Else
            model = Me.txt_model.Text & "       Base Model: " & Me.grab_model()
        End If

        ' TODO: remove condenser textbox it's only used for report
        If cboSystem.SelectedItem = "FULL" And NumCircuits = 2 _
        Or NumCircuits = 4 Then
            condenser_description = "(" & Me.txtNumCoils1.Text & ")" & Me.txtCondenser_1.Text.Trim _
             & " --- " & "(" & Me.txtNumCoils2.Text & ")" & Me.txtCondenser_2.Text.Trim
        ElseIf cboSystem.SelectedItem = "FULL" And NumCircuits = 1 Then
            condenser_description = "(" & Me.txtNumCoils1.Text & ")" & Me.txtCondenser_1.Text.Trim
        ElseIf cboSystem.SelectedItem = "HALF" And radCircuit1.Checked = True Then
            condenser_description = "(" & Me.txtNumCoils1.Text & ")" & Me.txtCondenser_1.Text.Trim
        ElseIf cboSystem.SelectedItem = "HALF" And radCircuit2.Checked = True Then
            condenser_description = "(" & Me.txtNumCoils2.Text & ")" & Me.txtCondenser_2.Text.Trim
        End If

        system = Me.cboSystem.SelectedItem.ToString
        circuitsPerUnit = NumCircuits
        numCompressors1 = Me.txtNumCompressors1.Text.Trim
        numCompressors2 = Me.txtNumCompressors2.Text.Trim

        compressorFileName1 = txtCompressor1.Text ' DirectCast(Me.lboCompressors1.SelectedItem, DataRowView)("compfile").ToString
        compressorFileName2 = txtCompressor2.Text ' DirectCast(Me.lboCompressors2.SelectedItem, DataRowView)("compfile").ToString

        If system = "FULL" And circuitsPerUnit = 1 Then
            compressor_description = "(" & numCompressors1 & ") " & compressorFileName1
        ElseIf system = "FULL" And circuitsPerUnit = 2 _
        Or circuitsPerUnit = 4 Then
            compressor_description = "(" & numCompressors1 & ") " & compressorFileName1 & _
               " --- " & "(" & numCompressors2 & ") " & compressorFileName2
        ElseIf system = "HALF" And Me.radCircuit1.Checked Then
            compressor_description = "(" & numCompressors1 & ") " & compressorFileName1
        ElseIf system = "HALF" And Me.radCircuit2.Checked Then
            compressor_description = "(" & numCompressors2 & ") " & compressorFileName2
        End If

        If cboFluid.SelectedItem = "Water" Then
            fluid = cboFluid.SelectedItem
        Else
            fluid = Me.cboFluid.SelectedItem.ToString & "   " & Me.txtGlycolPercentage.Text.Trim & "% " & Me.cbo_cooling_media.SelectedItem.ToString
        End If

        If system = "HALF" Then
            If radCircuit1.Checked Then
                If NumCircuits = 1 Then
                    circuit_message = "Showing Circuit 1 of 1"
                Else
                    circuit_message = "Showing Circuit 1 of 2"
                End If
            Else
                circuit_message = "Showing Circuit 2 of 2"
            End If
        Else
            circuit_message = " "
        End If

        If lblOperLimi.Visible = True Then
            operating_limits = Me.lblOperLimi.Text ' Points Omitted
        Else
            operating_limits = ""
        End If

        ' 8F Evaporator, 10F Evaporator, Condenser Capacity @ 25F, Fan
        If cboSystem.SelectedItem = "FULL" And NumCircuits = 1 Then
            If EvaporatorGrid1.CustomSelected Then
                capacity_at_8 = EvaporatorGrid1.CustomCapacityCircuit1Approach8
                capacity_at_10 = EvaporatorGrid1.CustomCapacityCircuit1Approach10
            Else
                capacity_at_8 = Round(EvaporatorGrid1.GetEvaporatorAt(8).capacity)
                capacity_at_10 = Round(EvaporatorGrid1.GetEvaporatorAt(10).capacity)
            End If

            condenser_capacity = Val(Me.txtCondenserCapacity1.Text)
            If fanIsCustom() Then
                fan_description = "(" & Val(txtNumFans1.Text) * Val(txtNumCoils1.Text) & ") " _
                   & Me.fan.FileName & txtCfmOverride.Text & "   Altitude = " & txtAltitude.Text
            Else
                fan_description = "(" & Val(txtNumFans1.Text) * Val(txtNumCoils1.Text) & ") " _
                   & Me.fan.Description & "   Altitude = " & Me.txtAltitude.Text
            End If
        ElseIf cboSystem.SelectedItem = "FULL" And NumCircuits = 2 _
        Or NumCircuits = 4 Then
            If EvaporatorGrid1.CustomSelected Then
                capacity_at_8 = Round(EvaporatorGrid1.CustomCapacityCircuit1Approach8 + EvaporatorGrid1.CustomCapacityCircuit2Approach8)
                capacity_at_10 = Round(EvaporatorGrid1.CustomCapacityCircuit1Approach10 + EvaporatorGrid1.CustomCapacityCircuit2Approach10)
            Else
                capacity_at_8 = Round(Q8 + Q8)
                capacity_at_10 = Round(Q9 + Q9)
            End If
            condenser_capacity = Val(txtCondenserCapacity1.Text) + Val(txtCondenserCapacity2.Text)
            If fanIsCustom() Then
                fan_description = "(" & (Val(txtNumFans1.Text) * Val(txtNumCoils1.Text)) + (Val(txtNumFans2.Text) * Val(txtNumCoils2.Text)) & ") " _
                   & Me.fan.FileName & Val(txtCfmOverride.Text) & "   Altitude = " & Val(txtAltitude.Text)
            Else
                fan_description = "(" & (Val(txtNumFans1.Text) * Val(txtNumCoils1.Text)) + (Val(txtNumFans2.Text) * Val(txtNumCoils2.Text)) & ") " _
                   & Me.fan.Description & "   Altitude = " & Me.txtAltitude.Text
            End If
        ElseIf cboSystem.SelectedItem = "HALF" And radCircuit1.Checked Then
            If EvaporatorGrid1.CustomSelected Then
                capacity_at_8 = EvaporatorGrid1.CustomCapacityCircuit1Approach8 ' Val(tbxEvap8Degr1.Text)
                capacity_at_10 = EvaporatorGrid1.CustomCapacityCircuit1Approach10 ' Val(tbxEvap10Degr1.Text)
            Else
                capacity_at_8 = Round(Q8)
                capacity_at_10 = Round(Q9)
            End If
            condenser_capacity = Val(txtCondenserCapacity1.Text)
            If fanIsCustom() Then
                fan_description = "(" & Val(txtNumFans1.Text) * Val(txtNumCoils1.Text) & ") " & Me.fan.FileName & Val(txtCfmOverride.Text) & "   Altitude = " & Val(txtAltitude.Text())
            Else
                fan_description = "(" & Val(txtNumFans1.Text) * Val(txtNumCoils1.Text) & ") " & Me.fan.Description & "   Altitude = " & Val(txtAltitude.Text)
            End If
        ElseIf cboSystem.SelectedItem = "HALF" And radCircuit2.Checked = True Then
            If EvaporatorGrid1.CustomSelected Then
                capacity_at_8 = EvaporatorGrid1.CustomCapacityCircuit2Approach8 ' tbxEvap8Degr2.Text
            Else
                capacity_at_8 = Round(Q9) 'should this be q8
            End If
            'todo: i think there should be an if here, if custom then custom capacity else q9
            capacity_at_10 = EvaporatorGrid1.CustomCapacityCircuit2Approach10 'tbxEvap10Degr2.Text
            condenser_capacity = txtCondenserCapacity2.Text
            If fanIsCustom() Then
                fan_description = "(" & Val(txtNumFans2.Text) * Val(txtNumCoils2.Text) & ") " & Me.fan.Description & Val(txtCfmOverride.Text) & "   Altitude = " & Val(txtAltitude.Text)
            Else
                fan_description = "(" & Val(txtNumFans2.Text) * Val(txtNumCoils2.Text) & ") " & Me.fan.Description & "   Altitude = " & Val(txtAltitude.Text)
            End If
        End If

        If chkCatalogRating.Checked = True Then
            catalog_rating_message = "Catalog Rating"
        Else
            catalog_rating_message = ""
        End If




        Dim pressure_drop_message As String = ""
        For Each result In Me.results.Rows
            If result.EvaporatorPressureDrop = "*" Then
                pressure_drop_message = "* The fluid pressure drop cannot be calculate when approach is out of range or a custom evaporator is selected."
            End If
        Next

        Dim evaporator_description = txt_evaporator_model.Text.Trim & "   Fouling = " & cboFoulingFactor.SelectedItem
        Dim refrigerant = cboRefrigerant.SelectedItem.DisplayName
        Dim hertz = cboHertz.SelectedItem
        Dim temperature_range_message = "Calculations based on " & txtTempRange.Text.Trim & "ºF Range"
        Dim discharge = cboDischargeLineLoss.SelectedItem.ToString
        Dim suction = cboSuctionLineLoss.SelectedItem.ToString

        Dim parameters As report_parameters
        parameters.model = model
        parameters.pressure_drop_message = pressure_drop_message
        parameters.application_version = My.Application.Info.Version.ToString
        parameters.user = user.username
        parameters.ambient = Me.ambient_temperature.ToString("#.0")
        parameters.leaving_fluid_temperature = Me.leaving_fluid_temperature.ToString("#.0")
        parameters.condenser_description = condenser_description
        parameters.evaporator_description = evaporator_description
        parameters.hertz = hertz
        parameters.system = system
        parameters.compressor_description = compressor_description
        parameters.fan_description = fan_description
        parameters.fluid = fluid
        parameters.refrigerant = refrigerant
        parameters.circuits_message = circuit_message
        parameters.operating_limits_message = operating_limits
        parameters.temperature_range_message = temperature_range_message
        parameters.capacity_at_8 = capacity_at_8
        parameters.capacity_at_10 = capacity_at_10
        parameters.condenser_capacity = condenser_capacity
        parameters.suction_line_loss = suction
        parameters.discharge_line_loss = discharge
        parameters.catalog_rating_message = catalog_rating_message

        Return parameters
    End Function

    Structure report_parameters
        Public application_version, user As String
        Public ambient, leaving_fluid_temperature, temperature_range_message, discharge_line_loss, suction_line_loss As String
        Public model, system, fluid, refrigerant, hertz, condenser_capacity As String
        Public condenser_description, evaporator_description, compressor_description, fan_description As String
        Public pressure_drop_message, circuits_message, operating_limits_message, catalog_rating_message As String
        Public capacity_at_8, capacity_at_10 As String
    End Structure

    Private Sub show_word_report()
        Dim parameters = get_report_parameters()
        Dim text = New Dictionary(Of String, String)


        Dim design_ambient = parameters.ambient
        Dim design_suction = parameters.leaving_fluid_temperature

        'footer
        text.Add("user", parameters.user)
        text.Add("application_version", parameters.application_version)
        text.Add("date_created", Date.Now.ToShortDateString)
        text.Add("year", Date.Now.Year)
        '
        text.Add("model", parameters.model)
        text.Add("condenser_description", parameters.condenser_description)
        text.Add("evaporator_description", parameters.evaporator_description)
        text.Add("compressor_description", parameters.compressor_description)
        text.Add("fan_description", parameters.fan_description)
        text.Add("fluid", parameters.fluid)
        text.Add("refrigerant", parameters.refrigerant)
        text.Add("hertz", parameters.hertz & "hz")
        text.Add("system", parameters.system)
        text.Add("discharge_line_loss", parameters.discharge_line_loss.F)
        text.Add("suction_line_loss", parameters.suction_line_loss.F)


        Dim sc1 As Double
        If Not String.IsNullOrEmpty(Me.txtSubCooling1.Text) AndAlso IsNumeric(Me.txtSubCooling1.Text) Then
            sc1 = Me.txtSubCooling1.Text
            sc1 = System.Math.Round(sc1, 1)
        Else
            sc1 = -1
        End If

        Dim sc2 As Double
        If Not String.IsNullOrEmpty(Me.txtSubCooling2.Text) AndAlso IsNumeric(Me.txtSubCooling2.Text) Then
            sc2 = Me.txtSubCooling2.Text
            sc2 = System.Math.Round(sc2, 1)
        Else
            sc2 = -1
        End If


        text.Add("condenser_capacity", parameters.condenser_capacity.format_number("#,#").BTUH & " (" & sc1 & "/" & sc2 & ")" & " [" & CalculatedSubcoolingMultiplier1 & "/" & CalculatedSubcoolingMultiplier2 & "]")


        text.Add("capacity_at_8", parameters.capacity_at_8.format_number("#,#").BTUH)
        text.Add("capacity_at_10", parameters.capacity_at_10.format_number("#,#").BTUH)

        Dim notes = New List(Of String)
        If parameters.operating_limits_message.is_set Then notes.Add(parameters.operating_limits_message)
        If parameters.pressure_drop_message.is_set Then notes.Add(parameters.pressure_drop_message)
        If parameters.catalog_rating_message.is_set Then notes.Add(parameters.catalog_rating_message)
        If parameters.temperature_range_message.is_set Then notes.Add(parameters.temperature_range_message)

        Dim command = New get_logo_file_path_command(user, AppInfo.Division.ToString)
        Dim logo_file_path = command.execute

        Dim table = Me.results.Copy
        table.Columns(0).ColumnName = "Leaving Fluid [°F]"
        table.Columns(1).ColumnName = "Ambient [°F]"
        table.Columns(2).ColumnName = "Evaporator [°F]"
        table.Columns(3).ColumnName = "Condenser [°F]"
        table.Columns(4).ColumnName = "Est. Capacity [Tons]"
        table.Columns(5).ColumnName = "Unit [KW]"
        table.Columns(6).ColumnName = "GPM"
        table.Columns(7).ColumnName = "Evap. PD"
        table.Columns(8).ColumnName = "Compressor EER"
        table.Columns(9).ColumnName = "Unit EER"

        Dim report = New Rae.reporting.beta.report(reports.file_paths.air_cooled_chiller_balance_template_file_path)
        report.set_text(text)
        report.set_table("table", table, New Rae.reporting.beta.AIR_COOLED_CHILLER_report_table_factory, design_suction, design_ambient)
        'report.set_table("table", table, New rae.reporting.beta.AIR_COOLED_CHILLER_report_table_factory, 44, 95)


        report.set_list("notes", notes)
        report.set_image("logo", logo_file_path)
        report.show()
    End Sub

    'Private Sub show_crystal_report()
    '    Dim parameters = get_report_parameters

    '    Dim report = New report_factory().create(Reports.file_paths.AirCooledChillerRatingReportFilePath)
    '    report.source = Me.results

    '    Dim division = "TSI"
    '    If user.can(choose_report_logo) Then
    '        division = New which_division().ask({"TSI", "CRI", "RSI", "RAE"})
    '    End If
    '    report.pass("logo", division)

    '    report.pass("pfdVersion", parameters.application_version)
    '    report.pass("pfdCreator", parameters.user)

    '    report.pass("pfdModelNumber", parameters.model)
    '    report.pass("pfdDischarge", parameters.discharge_line_loss)
    '    report.pass("pfdSuction", parameters.suction_line_loss)
    '    report.pass("pfdRange", parameters.temperature_range_message)

    '    report.pass("pfdCondenser", parameters.condenser_description)
    '    report.pass("pfdfans", parameters.fan_description)
    '    report.pass("pfdEvaporator", parameters.evaporator_description)
    '    report.pass("pfdCompressor", parameters.compressor_description)

    '    report.pass("pfdSystem", parameters.system)
    '    report.pass("pfdFluid", parameters.fluid)
    '    report.pass("pfdRefrigerant", parameters.refrigerant)
    '    report.pass("pfdHertz", parameters.hertz)
    '    report.pass("pfdCondenserCapacity", parameters.condenser_capacity)
    '    report.pass("pfd8Evaporator", parameters.capacity_at_8)
    '    report.pass("pfd10Evaporator", parameters.capacity_at_10)

    '    report.pass("pfdCircuit", parameters.circuits_message)
    '    report.pass("pfdOperatingLimits", parameters.operating_limits_message)
    '    report.pass("pfdCatalog", parameters.catalog_rating_message)
    '    report.pass("pressure_drop_message", parameters.pressure_drop_message)

    '    report.pass("pfdAuthorization", "Engineer") ' Rep or Engineer
    '    report.pass("pfdTest", Constants.TESTING.ToString)
    '    ' ambient temperature (so row with entered Ambient and Leaving Fluid Temp can be uniquely formatted)
    '    report.pass("pfdAmbient", parameters.ambient)
    '    report.pass("pfdLeavingFluid", parameters.leaving_fluid_temperature)
    '    ' report always shows 8 and 10 degree approach regardless of the approach selected on form.
    '    report.pass("pfdLowerApproach", 8)
    '    report.pass("pfdUpperApproach", 10)

    '    report.show()
    'End Sub


    'sets hid condenser textboxes w/
    '1. Changed Coil Type
    '2. Condenser Fin Height
    '3. Condenser Fin Length
    '4. Fins per Inch
    '5. Changed Rows
    '6. Circuit
    '7. Sub Cooling (Yes/No)
    Private Sub setCoilDescription()
        Dim numRows As String
        Dim coilType As String = ""
        Dim subCooling As String = ""
        Dim coilType2 As String = ""

        If cboCondenser1.Text.Contains("1/2") Then
            coilType = "12"
        ElseIf cboCondenser1.Text.Contains("3/8") Then
            coilType = "38"
        ElseIf cboCondenser1.Text.Contains("5/8") Then
            coilType = "58"
        End If

            ' condenser 1
        'If cboCondenser1.SelectedIndex = 0 Then
        '    numRows = "2"
        'ElseIf cboCondenser1.SelectedIndex = 1 Then
        '    numRows = "3"
        'ElseIf cboCondenser1.SelectedIndex = 2 Then
        '    numRows = "4"
        'ElseIf cboCondenser1.SelectedIndex = 3 Then
        '    numRows = "5"
        'ElseIf cboCondenser1.SelectedIndex = 4 Then
        '    numRows = "6"
        'End If


        If cboCondenser1.Text.Contains("1 Row") Then
            numRows = "1"
        ElseIf cboCondenser1.Text.Contains("2 Row") Then
            numRows = "2"
        ElseIf cboCondenser1.Text.Contains("3 Row") Then
            numRows = "3"
        ElseIf cboCondenser1.Text.Contains("4 Row") Then
            numRows = "4"
        ElseIf cboCondenser1.Text.Contains("5 Row") Then
            numRows = "5"
        ElseIf cboCondenser1.Text.Contains("6 Row") Then
            numRows = "6"
        End If



        ' sub cooling
        If cboSubCooling1.SelectedItem = "Yes" Then
            subCooling = "-S/C"
        End If
        ' sets hid condenser 1 textbox
        Me.txtCondenser_1.Text = coilType & "C" & txtFinHeight1.Text & "X" & Me.txtFinLength1.Text & _
           "-" & Me.cboFinsPerInch1.SelectedItem.ToString & "-" & numRows & "-1C" & subCooling

        ' condenser 2
        'If cboCondenser2.SelectedIndex = 0 Then
        '    numRows = "2"
        'ElseIf cboCondenser2.SelectedIndex = 1 Then
        '    numRows = "3"
        'ElseIf cboCondenser2.SelectedIndex = 2 Then
        '    numRows = "4"
        'ElseIf cboCondenser2.SelectedIndex = 3 Then
        '    numRows = "5"
        'ElseIf cboCondenser2.SelectedIndex = 4 Then
        '    numRows = "6"
        'End If


        If cboCondenser2.Text.Contains("1 Row") Then
            numRows = "1"
        ElseIf cboCondenser2.Text.Contains("2 Row") Then
            numRows = "2"
        ElseIf cboCondenser2.Text.Contains("3 Row") Then
            numRows = "3"
        ElseIf cboCondenser2.Text.Contains("4 Row") Then
            numRows = "4"
        ElseIf cboCondenser2.Text.Contains("5 Row") Then
            numRows = "5"
        ElseIf cboCondenser2.Text.Contains("6 Row") Then
            numRows = "6"
        End If


        ' sub cooling
        If cboSubCooling2.SelectedItem = "Yes" Then
            subCooling = "-S/C"
        Else
            subCooling = ""
        End If

        If cboCondenser2.Text.Contains("1/2") Then
            coilType2 = "12"
        ElseIf cboCondenser2.Text.Contains("3/8") Then
            coilType2 = "38"
        ElseIf cboCondenser2.Text.Contains("5/8") Then
            coilType2 = "58"
        End If

        Me.txtCondenser_2.Text = coilType2 & "C" & Val(txtFinHeight2.Text) & "X" & Val(txtFinLength2.Text) & _
           "-" & cboFinsPerInch2.SelectedItem.ToString & "-" & numRows & "-1C" & subCooling

    End Sub


    Private Sub handle_model_changed()
        Cursor = Cursors.WaitCursor

        Dim selectedModel = Me.grab_model

        If loaded And selectedModel <> "Choose" Then
            set_enabled_on_acme_related_controls(enabled:=False)

            jot("handle model changed: " & selectedModel)
            Dim chiller = BCA.RetrieveChiller(selectedModel)
            ''dgrC1Results.Visible = False 'hide grid
            Grid1.Visible = False
            lblErro.Text = "" 'clear error label text
            callCircuit1(chiller)

            If chiller.num_circuits_per_unit > 1 Then _
               callCircuit2(chiller)

            EvaporatorGrid1.SetNumCircuits(NumCircuits)

            If chiller.num_circuits_per_unit > 1 Then
                txtNumFans2.Visible = True
                txtNumCompressors2.Visible = True
                txtCompressor2.Visible = True
            Else
                txtNumFans2.Visible = False
                txtNumCompressors2.Visible = False
                txtCompressor2.Visible = False
            End If

            If chiller.num_circuits_per_unit = 4 Then
                radCircuit1.Text = "Circuit 1 and 3"
                radCircuit2.Text = "Circuit 2 and 4"
                lblCircuit1.Text = "Circuit 1 and 3"
                lblCircuit2.Text = "Circuit 2 and 4"
            Else
                radCircuit1.Text = "Circuit 1"
                radCircuit2.Text = "Circuit 2"
                lblCircuit1.Text = "Circuit 1"
                lblCircuit2.Text = "Circuit 2"
            End If

            setFanWatts()
            Me.txt_model.Text = selectedModel

            set_enabled_on_acme_related_controls(enabled:=True)
        Else
            jot("do not handle model changed: " & selectedModel)
        End If

        Cursor = Cursors.Arrow
    End Sub


    'reset variables	
    Private Sub resetVariables()
        Q8 = 0                  'CHILLER CAP. @ 8 DEG APPROACH
        Q9 = 0                  'CHILLER CAP. @ 10 DEG APPROACH
        Me.subCoolingFactor = 0                 'GLYCOL
        GPMFACT = 0             'GLYCOL
        hz_q = 0
        hz_w = 0
    End Sub


    ''' <summary>Calculates and fills condenser coil capacity controls for either circuit 1 or 2 using cofan dll</summary>
    Private Sub setCondenserCapacity(ByVal circuit As Integer)
        Dim condenserCapacity As Double

        ' calculates condenser capacity
        '
        Dim cond As Condenser
        ' gets inputs from controls
        Dim fpi As Integer
        Dim altitude As Double = CDbl(Me.txtAltitude.Text)
        Dim fanFileName As String = Me.fan.FileName
        Dim cfmOverride As Double = ConvertNull.ToDouble(Me.txtCfmOverride.Text.Trim)
        If circuit = 1 Then
            Dim td As Double = CDbl(Me.txtCondenserTD1.Text)
            Dim numFans As Double = CDbl(Me.txtNumFans1.Text.Trim)
            Dim coilHeight As Double = CDbl(Me.txtFinHeight1.Text.Trim)
            Dim coilLength As Double = CDbl(Me.txtFinLength1.Text.Trim)
            Dim coilFileName As String = Me.GrabCondenser1.FileName
            fpi = CInt(Me.cboFinsPerInch1.SelectedItem)
            If fanIsCustom() Then
                cond = New Condenser(95, td, coilHeight, coilLength, coilFileName, numFans, cfmOverride, "Smooth")
            Else
                cond = New Condenser(95, td, coilHeight, coilLength, coilFileName, numFans, fanFileName, "Smooth")
            End If
        ElseIf circuit = 2 Then
            Dim td As Double = CDbl(Me.txtCondenserTD2.Text)
            Dim numFans As Double = CDbl(Me.txtNumFans2.Text.Trim)
            Dim coilHeight As Double = CDbl(Me.txtFinHeight2.Text.Trim)
            Dim coilLength As Double = CDbl(Me.txtFinLength2.Text.Trim)
            Dim coilFileName As String = Me.GrabCondenser2.FileName
            fpi = CInt(Me.cboFinsPerInch2.SelectedItem)
            If fanIsCustom() Then
                cond = New Condenser(95, td, coilHeight, coilLength, coilFileName, numFans, cfmOverride, "Smooth")
            Else
                cond = New Condenser(95, td, coilHeight, coilLength, coilFileName, numFans, fanFileName, "Smooth")
            End If
        End If
        cond.Input.Altitude = altitude
        cond.Calculate()
        condenserCapacity = cond.Output.At(fpi).Capacity

        ' adjusts condenser capacity for refrigerant
        '
        Dim refrigerantAbbreviation As String = Me.cboRefrigerant.SelectedItem.ValueName
        condenserCapacity = BCI.ChillerIntel.AdjustCondenserCapacityForRefrigerant(condenserCapacity, refrigerantAbbreviation)

        ' adjusts capacity for sub cooling percentage
        '
        'TODO: pass sub cooling into condenser calculater
        Dim subCoolingPercentage As Double
        If circuit = 1 And Me.cboSubCooling1.SelectedItem = "Yes" Then
            subCoolingPercentage = CDbl(Me.txtSubCooling1.Text.Trim)
            condenserCapacity = BCI.ChillerIntel.AdjustCondenserCapacityForSubCooling(condenserCapacity, subCoolingPercentage)
        ElseIf circuit = 2 And cboSubCooling2.SelectedItem = "Yes" Then
            subCoolingPercentage = CDbl(Me.txtSubCooling2.Text.Trim)
            condenserCapacity = BCI.ChillerIntel.AdjustCondenserCapacityForSubCooling(condenserCapacity, subCoolingPercentage)
        End If

        ' adjusts condenser capacity by condenser capacity factor entered by user
        Dim condenserCapacityFactor As Double
        condenserCapacityFactor = ConvertNull.ToDouble(condenserCapacityFactorTextBox.Text)
        condenserCapacity *= condenserCapacityFactor

        ' sets condenser capacity controls
        '
        If circuit = 1 Then
            Dim numCoils = CInt(txtNumCoils1.Text)
            txtCondenserCapacity1.Text = Round(condenserCapacity * numCoils).ToString
        ElseIf circuit = 2 Then
            Dim numCoils = CInt(txtNumCoils2.Text)
            txtCondenserCapacity2.Text = Round(condenserCapacity * numCoils).ToString
        End If
    End Sub


    Private Sub calculatePage()
        Dim compressorCapacityFactor, compressorKwFactor, compressorAmpFactor As Double
        compressorCapacityFactor = compressorCapacityFactorTextBox.Text
        compressorKwFactor = compressorKwFactorTextBox.Text
        compressorAmpFactor = compressorAmpFactorTextBox.Text

        Dim safetyOverride = chkSafetyOverride.Checked

        calculatePage(compressorCapacityFactor, compressorKwFactor, compressorAmpFactor, safetyOverride)
    End Sub

    Private Function grabVoltage() As Integer
        Return CInt(cboVolts.SelectedItem)
    End Function

    Private Sub jot(ByVal message As String)
        Debug.WriteLine(message)
    End Sub


    Private Sub calculatePage(ByVal compressorCapacityFactor As Double, ByVal compressorKwFactor As Double, _
    ByVal compressorAmpFactor As Double, ByVal safetyOverride As Boolean)
        Dim suctionLineLoss = CDbl(cboSuctionLineLoss.SelectedItem)
        Dim dischargeLineLoss = CDbl(cboDischargeLineLoss.SelectedItem)
        Dim capacityFactor = CDbl(capacityFactorTextBox.Text)

        Try
            fluid_properties_controller.handle_fluid_changed()
            lblOperLimi.Visible = False
            lblOperLimi.Text = "Points outside operating limits omitted, contact factory for selection."

            'EvaporatorGrid1.setVisibility(NumCircuits)

            lblErro.Text = ""   'clear errors
            ''dgrC1Results.Visible = True 'show datagrid
            Grid1.Visible = True

            'Dim coil1 As Coil
            'coil1.FinHeight     = txtFinHeight1.Text
            'coil1.FinLength     = txtFinLength1.Text
            'coil1.Fpi           = cboFinsPerInch1.SelectedItem
            'coil1.Rows          = cboCondenser1.SelectedItem
            'coil1.HasSubCooling = (cboSubCooling1.SelectedItem = "Yes")

            'Dim coil2 As Coil
            'coil2.FinHeight     = txtFinHeight2.Text
            'coil2.FinLength     = txtFinLength2.Text
            'coil2.Fpi           = cboFinsPerInch2.SelectedItem
            'coil2.Rows          = cboCondenser2.SelectedItem
            'coil2.HasSubCooling = (cboSubCooling2.SelectedItem = "Yes")

            'txtCondenser_1.Text = coil1.GetDescription()
            'txtCondenser_2.Text = coil2.GetDescription()
            setCoilDescription()

            Dim my_Counter_pass As Single = 0
            Dim nextCuritem As Integer = 0

            ' todo: store circuit 1 in memory not hidden combobox
            'fill dropdown w/ datagrid values
            If cboSystem.SelectedItem = "FULL" And NumCircuits = 2 _
            Or NumCircuits = 4 Then
                If ok_to_print = True And nextCuritem = 0 Then
                    'fill hidden dropdown with values used to calculate datagrid values
                    'myarrayprint3 contains less values than myarrayprint
                    'this only runs when there is 2 circuits and
                    'when it is ok_to_print (calculating circuit 2)
                    'so this stores circuit 1 in dropdownlist3
                    DropDownList3.DataSource = Nothing
                    DropDownList3.DataSource = myarrayprint3
                End If
            End If

            resetVariables()

            standardRef.SetSpecificHeatAndGravity()
            setCondenserCapacity(Running_Circuit_no)
            standardRef.ListEvaporatorDataForApproachRange()

            If approachIsOutOfRange() Then _
               Exit Sub

            Dim nc As Integer
            Dim fan_w, numFans, condenserCapacity As Double
            Dim m_refg_q, m_refg_aw As Double
            '***************************************************
            '********** set variable values ********************
            If Running_Circuit_no = 1 Then
                nc = Val(txtNumCompressors1.Text)
                numFans = Val(txtNumFans1.Text) * Val(txtNumCoils1.Text)
                condenserCapacity = Val(txtCondenserCapacity1.Text)

                If EvaporatorGrid1.CustomSelected Then
                    Q8 = EvaporatorGrid1.CustomCapacityCircuit1Approach8 ' Val(tbxEvap8Degr1.Text)
                    Q9 = EvaporatorGrid1.CustomCapacityCircuit1Approach10 ' Val(tbxEvap10Degr1.Text)
                Else
                    Q8 = EvaporatorGrid1.SelectedLowerApproach.capacity
                    Q9 = EvaporatorGrid1.SelectedUpperApproach.capacity
                End If
            ElseIf Running_Circuit_no = 2 Then
                nc = Val(txtNumCompressors2.Text)
                numFans = Val(txtNumFans2.Text) * Val(txtNumCoils2.Text)
                condenserCapacity = Val(txtCondenserCapacity2.Text)

                If EvaporatorGrid1.CustomSelected Then
                    Q8 = EvaporatorGrid1.CustomCapacityCircuit2Approach8 ' Val(tbxEvap8Degr2.Text)
                    Q9 = EvaporatorGrid1.CustomCapacityCircuit2Approach10 ' Val(tbxEvap10Degr2.Text)
                Else
                    Q8 = EvaporatorGrid1.SelectedLowerApproach.capacity
                    Q9 = EvaporatorGrid1.SelectedUpperApproach.capacity
                End If
            End If

            Dim voltage = grabVoltage()
            'multiplying factors for compressors
            m_refg_q = 1
            m_refg_aw = 1

            ' sets fan watts based on condenser
            Dim fanFileName = fan.FileName
            Dim hertz = CInt(cboHertz.SelectedItem)

            ' selects fan watts
            fan_w = Logic.FanIntel.SelectFanWatts(fanFileName, hertz, voltage)

            If hertz = 50 Then
                hz_q = 0.833
                hz_w = 0.833
                If voltage = 415 Then
                    hz_q = 1
                    hz_w = 1
                End If
            ElseIf hertz = 60 Then
                hz_q = 1
                hz_w = 1
            Else
                lblErro.Text = lblErro.Text & "Choose Hertz Operation - 50/60"
                Exit Sub
            End If

            If fanIsCustom() Then
                fan_w = Val(Me.txtFanWatts.Text)
                If hertz = 50 Then
                    hz_q = 0.833
                    hz_w = 0.833
                Else
                    hz_q = 1
                    hz_w = 1
                End If
                If fan_w = 0 Then
                    fan_w = 1100
                End If
            End If

            txtFanWatts.Text = fan_w

            Dim EE, F, g, P As Double
            Dim NF_2, TE_2, TC_2, Q_2, KW_2, GP_2, A_2, ER_2, W_2 As Double

            ' sets evaporator temperature range
            Dim TE1, TE2 As Double
            BCI.ChillerIntel.SelectEvaporatorTempRange(leaving_fluid_temperature, TE1, TE2)

            Dim TW1 = leaving_fluid_temperature - 4 ' LOWEST LVG H20 TEMP(OD COMPRESSORS)
            Dim TW2 = leaving_fluid_temperature + 4

            If txtCompressor1.Text = "" Then
                lblErro.Text &= "Make a valid compressor selection, INVALID COMPRESSOR"
                Exit Sub
            End If


            Dim TR = Me.TempRange
            '*********************************************************************
            'Check fluid (water or glycol) and cooling media (ethylene, propylene)
            '** sets related variables: isGlycolSelected, coolingMedia, gPercentGlycol,
            '** GPMFACT?, gSubCoolingTemp, subCoolingFactor, specificHeat, specificGravity
            Dim isGlycolSelected As Boolean
            Dim sg, sh As Double
            Dim subCoolingTemp = Val(txtSubCooling.Text)





            If Trim(Me.cboFluid.SelectedItem) <> "Water" Then
                If Trim(Me.cboFluid.SelectedItem) = "Glycol" Then
                    isGlycolSelected = True

                    If GlycolPercentage = 0 Then
                        lblErro.Text &= "ENTER PERCENTAGE OF GLYCOL (IE 20%, 30%. ETC), ENTER PERCENTAGE GLYCOL"
                        Exit Sub
                    End If
                    'check not needed
                    sh = Val(txtSpecificHeat.Text)
                    If sh = 0 Then
                        lblErro.Text &= "ENTER GLYCOL SPECIFIC HEAT ENTER GLYCOL SPECIFIC HEAT"
                        Exit Sub
                    End If
                    'check not needed
                    sg = Val(txtSpecificGravity.Text)
                    If sg = 0 Then
                        lblErro.Text &= "ENTER GLYCOL SPECIFIC GRAVITY ENTER GLYCOL SPECIFIC GRAVITY"
                        Exit Sub
                    End If

                    GPMFACT = 500 * sh * sg * TR
                    '  Dim subCoolingTemp = Val(txtSubCooling.Text)
                    '   Me.subCoolingFactor = (subCoolingTemp * 0.005) + 1


                    'If cboRefrigerant.SelectedItem.ValueName.ToString.ToUpper = "R410A" Then
                    '    Me.subCoolingFactor = ((subCoolingTemp - compressorCurveSubcooling) * 0.0075) + 1
                    'Else
                    '    Me.subCoolingFactor = ((subCoolingTemp - compressorCurveSubcooling) * 0.005) + 1
                    'End If


                Else
                    lblErro.Text &= "Enter a valid fluid type"
                    Exit Sub
                End If
                'water cooled
            Else
                isGlycolSelected = False

                '   Me.subCoolingFactor = (subCoolingTemp * 0.005) + 1

                'If cboRefrigerant.SelectedItem.ValueName.ToString.ToUpper = "R410A" Then
                '    Me.subCoolingFactor = ((subCoolingTemp - compressorCurveSubcooling) * 0.0075) + 1
                'Else
                '    Me.subCoolingFactor = ((subCoolingTemp - compressorCurveSubcooling) * 0.005) + 1
                'End If

                'If 410
                '                    Me.subCoolingFactor = (subCoolingTemp * 0.0075) + 1
                '            else
                '                    Me.subCoolingFactor = (subCoolingTemp * 0.005) + 1




                sh = 1.0! : sg = 1.0!
            End If

            Dim m = (25 + dischargeLineLoss) / condenserCapacity


            Dim compressorModel As String
            If Running_Circuit_no = 1 Then
                compressorModel = txtCompressorMasterID1.Text.Trim
            ElseIf Running_Circuit_no = 2 Then
                compressorModel = txtCompressorMasterID2.Text.Trim
            End If

            Dim refrigerantString = cboRefrigerant.SelectedItem.ValueName.ToString
            Dim refg = refrigerant.parse(refrigerantString)
            Dim compressor = compressor_repository.get_compressor(compressorModel, refg, voltage, "AirCooledChiller", "N")




            'If cboRefrigerant.SelectedItem.ValueName.ToString.ToUpper = "R410A" Then
            '    Me.subCoolingFactor = ((subCoolingTemp - compressor.coef.SubCooling) * 0.0075) + 1
            'Else
            '    Me.subCoolingFactor = ((subCoolingTemp - compressor.coef.SubCooling) * 0.005) + 1
            'End If




            If Me.Running_Circuit_no = 1 Then
                ToolTip1.SetToolTip(txtCompressor1, compressor.MasterID)
            ElseIf Running_Circuit_no = 2 Then
                ToolTip1.SetToolTip(txtCompressor2, compressor.MasterID)
            End If

            Dim a, q, w, ER, GP, H1, H2, tc, te As Double

            Dim wattFactor = 0.7821 * capacityFactor + 0.2104
            Dim polynomial = New compressor_polynomial()

            For ta = (ambient_temperature - 10) To (ambient_temperature + 20) Step 10
                If ta > ambient_temperature + 15 Then GoTo 1000

                Dim Q1 As Double

                For te = TE1 To TE2 Step 15
                    tc = ta + 10

                    Do
                        tc += 0.2
                        H1 = (tc - ta) / m

                        If tc > 300 Then
                            GoTo Next_Ta
                            'Throw New Exception("While attempting to balance chiller, the condensing temperature became greater than 300. The balance appears to not be converging.")
                        End If

                        Dim result = polynomial.calculate(refg, compressor.coef, te, tc)
                        q = result.q * nc * compressorCapacityFactor * capacityFactor * hz_q
                        w = result.w * nc * compressorKwFactor * wattFactor * hz_w
                        a = result.a * nc * compressorAmpFactor

                        H2 = q + (3.413 * w)
                    Loop While (H1 < H2)

                    If te = TE2 Then GoTo 400
                    Q1 = q
                Next te
                ' Q - capacity @ High TE            (ex. @45)
                ' Q1- capacity @ 15 degree lower TE (ex. @30)
400:            Dim QPD = (q - Q1) / 15 'capacity per degree
                Dim B = te - (q / QPD)
420:            Dim M1 = (te - B) / q
                wattFactor = 0.7821 * capacityFactor + 0.2104
                For tw = TW1 To TW2 Step 2
                    If tw > TW2 Then GoTo 660 '660 step ambient temp

                    Dim upperApproach = 10 ' custom evaporator
                    If Not EvaporatorGrid1.CustomSelected Then
                        upperApproach = EvaporatorGrid1.SelectedUpperApproach.approach
                    End If

                    'comes here If TW = gLeavingFluidTemp - 2
450:                te = tw - (upperApproach + suctionLineLoss)
                    EE = (Q9 - Q8) / 2   ' half of difference
                    F = te + (Q9 / EE)
                    g = (te - F) / Q9 ' -1/half of difference
                    te = ((B * g) - (F * M1)) / (g - M1)

S710:               tc = ta + 10   ' ericc103
                    Do
                        tc = tc + 0.2
                        H1 = (tc - ta) / m

                        ' todo: ensure_balance_is_converging(tc)
                        If tc > 200 Then
                            GoTo SKIP_DATABASE_BUILDER_TABLE1
                        End If

                        Dim result = polynomial.calculate(refg, compressor.coef, te, tc)
                        q = result.q * nc * compressorCapacityFactor * capacityFactor * hz_q
                        w = result.w * nc * compressorKwFactor * wattFactor * hz_w
                        a = result.a * nc * compressorAmpFactor



                        H2 = q + (3.413 * w)



                        ' '''''''''''''''''''''''''''''''''''''''
                        'Dim subcooling = 0.6187 * (tc - ta) + 0.5753    ' ericc103
                        'Me.subCoolingFactor = (subcooling - compressor.coef.SubCooling) / refg.sc / 100 + 1


                        'If Running_Circuit_no = 1 And cboSubCooling1.SelectedItem = "No" Then
                        '    Me.subCoolingFactor = 1
                        'ElseIf Running_Circuit_no = 2 And cboSubCooling2.SelectedItem = "No" Then
                        '    Me.subCoolingFactor = 1
                        'End If

                        'If Me.ambient_temperature = ta _
                        'And Me.leaving_fluid_temperature = tw Then
                        '    txtSubCooling.Text = Round(subcooling, 2)

                        '    If Running_Circuit_no = 1 Then
                        '        CalculatedSubcoolingMultiplier1 = Round(subcooling, 1)

                        '    End If
                        '    If Running_Circuit_no = 2 Then
                        '        CalculatedSubcoolingMultiplier2 = Round(subcooling, 1)

                        '    End If

                        'End If

                        'q = q * Me.subCoolingFactor

                        ' '''''''''''''''''''''''''''''''''''''''












                    Loop While (H1 < H2)


                    If chkCatalogRating.Checked Then q = q * 1.04 'Yes = 6, No = 7
                    q = Convert.BtuhToTons(q)



                    ' SUBCOOLING
                    Dim subcooling = 0.6187 * (tc - ta) + 0.5753    ' ericc103
                    Me.subCoolingFactor = (subcooling - compressor.coef.SubCooling) / refg.sc / 100 + 1


                    If Running_Circuit_no = 1 And cboSubCooling1.SelectedItem = "No" Then
                        Me.subCoolingFactor = 1
                    ElseIf Running_Circuit_no = 2 And cboSubCooling2.SelectedItem = "No" Then
                        Me.subCoolingFactor = 1
                    End If

                    If Me.ambient_temperature = ta _
                    And Me.leaving_fluid_temperature = tw Then
                        txtSubCooling.Text = Round(subcooling, 2)

                        If Running_Circuit_no = 1 Then
                            CalculatedSubcoolingMultiplier1 = Round(subcooling, 1)

                        End If
                        If Running_Circuit_no = 2 Then
                            CalculatedSubcoolingMultiplier2 = Round(subcooling, 1)

                        End If

                    End If

                    q = q * Me.subCoolingFactor
                    ' /SUBCOOLING





                    'TODO: can this if statement be removed, isn't GPMFACT the same as 500*tempRange for water cuz sh & sg = 1
                    If isGlycolSelected Then
                        GP = q / GPMFACT
                        GP = Convert.TonsToBtuh(GP)
                    Else
                        GP = q / (500 * TR)
                        GP = Convert.TonsToBtuh(GP)
                    End If

                    ER = q * 12000 / w
                    Dim comp_kw = Round(w / 1000, 1)
                    Dim fans_w = fan_w * numFans
                    Dim fans_kw = Round(fans_w / 1000, 1)
                    Dim unit_kw = comp_kw + fans_kw

                    Dim EZ = q * 12000 / (w + fans_w)

                    If cboSystem.SelectedItem = "FULL" And NumCircuits = 2 _
                    Or NumCircuits = 4 Then
                        'Circuit 1, ok_to_print is set to False before CalculatePage()
                        'is called for Circuit 1 (see StartCalculations)
                        If ok_to_print = False Then
                            'myarrayprint is never used (i guess it's just for testing)
                            myarrayprint.Add(Format(tw, "###"))
                            myarrayprint.Add(Format(ta, "###"))
                            myarrayprint.Add(Format(te, "##.#"))
                            myarrayprint.Add(Format(tc, "###.#"))
                            myarrayprint.Add(Format(q, "###.#"))
                            myarrayprint.Add(Format(unit_kw, "####.#"))
                            myarrayprint.Add(Format(GP, "####.#"))
                            myarrayprint.Add(Format(a, "####.#"))
                            myarrayprint.Add(Format(ER, "####.#"))
                            myarrayprint.Add(Format(EZ, "####.#"))

                            'myarrayprint3 stores values from first circuit
                            'until circuit 2 is calculated
                            myarrayprint3.Add(Format(te, "##.#")) 'evaporator temperature
                            myarrayprint3.Add(Format(tc, "###.#")) 'condenser temperature
                            myarrayprint3.Add(Format(q, "###.#")) 'capacity
                            myarrayprint3.Add(Format(unit_kw, "####.#")) 'kilowatts
                            myarrayprint3.Add(Format(GP, "####.#")) '?GPM?
                            myarrayprint3.Add(Format(a, "####.#"))  'amps
                            myarrayprint3.Add(Format(ER, "####.#")) '?EER?
                            myarrayprint3.Add(numFans)
                            myarrayprint3.Add(w)

                            If Me.leaving_fluid_temperature = tw And Me.ambient_temperature = ta Then
                                Me.txtApproach.Text = Round(tw - te, 0)
                            End If

                            Dim minSuctionDueToFreezing = MinSuctionTemp
                            ' checks if compressor is safe
                            ' CHANGE 1
                            If safetyOverride Then
                                ok_to_show = True
                            Else
                                ok_to_show = validate(user.authority_group, compressor, te, tc, tw, minSuctionDueToFreezing)
                            End If
                            'ok_to_show = (Me.CheckCompressorSafety(TE, TC, TE, TW))
                            'check to see if needs special formatting
                            If Trim(txtLeavingFluidTemp.Text) = Format(tw, "###") _
                            And Trim(txtAmbientTemp.Text) = Format(ta, "###") Then
                                If ok_to_show = False Then
                                    myarrayprint.Add(2)
                                Else
                                    myarrayprint.Add(1)
                                End If
                            Else
                                If ok_to_show = False Then
                                    myarrayprint.Add(2)
                                Else
                                    myarrayprint.Add(0)
                                End If
                            End If


                        ElseIf ok_to_print = True Then     'Circuit 2
                            'myarrayprint2 is never used (just for testing)
                            myarrayprint2.Add(Format(tw, "###"))
                            myarrayprint2.Add(Format(ta, "###"))
                            myarrayprint2.Add(Format(te, "##.#"))
                            myarrayprint2.Add(Format(tc, "###.#"))
                            myarrayprint2.Add(Format(q, "###.#"))
                            myarrayprint2.Add(Format(unit_kw, "####.#"))
                            myarrayprint2.Add(Format(GP, "####.#"))
                            myarrayprint2.Add(Format(a, "####.#"))
                            myarrayprint2.Add(Format(ER, "####.#"))

                            'use hidden dropdown to set variables used in calculations
                            '?values are for circuit 2
                            nextCuritem = nextCuritem + 1       'locating circuit 1 data
                            If nextCuritem = 1 Then
                                nextCuritem = 0
                            End If

                            'get values from circuit 1	that were saved
                            'in dropdownlist3
                            'TEST: how large does nextCuritem get
                            DropDownList3.SelectedIndex = nextCuritem
                            TE_2 = Val(Me.DropDownList3.SelectedItem)
                            nextCuritem = nextCuritem + 1
                            DropDownList3.SelectedIndex = nextCuritem
                            TC_2 = Val(Me.DropDownList3.SelectedItem)
                            nextCuritem = nextCuritem + 1
                            DropDownList3.SelectedIndex = nextCuritem
                            Q_2 = Val(Me.DropDownList3.SelectedItem)
                            nextCuritem = nextCuritem + 1
                            DropDownList3.SelectedIndex = nextCuritem
                            KW_2 = Val(Me.DropDownList3.SelectedItem)
                            nextCuritem = nextCuritem + 1
                            DropDownList3.SelectedIndex = nextCuritem
                            GP_2 = Val(Me.DropDownList3.SelectedItem)
                            nextCuritem = nextCuritem + 1
                            DropDownList3.SelectedIndex = nextCuritem
                            'not used
                            A_2 = Val(Me.DropDownList3.SelectedItem)
                            nextCuritem = nextCuritem + 1
                            DropDownList3.SelectedIndex = nextCuritem
                            ER_2 = Val(Me.DropDownList3.SelectedItem)
                            nextCuritem = nextCuritem + 1
                            DropDownList3.SelectedIndex = nextCuritem
                            NF_2 = Val(Me.DropDownList3.SelectedItem)
                            nextCuritem = nextCuritem + 1
                            DropDownList3.SelectedIndex = nextCuritem
                            W_2 = Val(Me.DropDownList3.SelectedItem)

                            If Me.leaving_fluid_temperature = tw And Me.ambient_temperature = ta Then
                                Me.txtApproach.Text = Round(tw - ((te + TE_2) / 2), 0)
                            End If


                            Dim evaporatingTemperatureAvg As Single = (te + TE_2) / 2
                            Dim condensingTemperatureAvg As Single = (tc + TC_2) / 2
                            ' CHANGE 1
                            If safetyOverride Then
                                ok_to_show = True
                            Else
                                ok_to_show = validate(user.authority_group, compressor, te, tc, tw, MinSuctionTemp)
                            End If

                            'ok_to_show = Me.CheckCompressorSafety(evaporatingTemperatureAvg, _
                            '   condensingTemperatureAvg, evaporatingTemperatureAvg, TW)

                            EZ = ((q + Q_2) * 12000) / ((w + W_2) + (fan_w * (numFans + NF_2)))     'Recal Unit EER
                            myarrayprint2.Add(Format(EZ, "####.#"))
                            If Trim(txtLeavingFluidTemp.Text()) = Format(tw, "###") And Trim(txtAmbientTemp.Text()) = Format(ta, "###") Then
                                If ok_to_show = False Then
                                    myarrayprint2.Add(2)
                                Else
                                    myarrayprint2.Add(1)
                                End If
                            Else
                                If ok_to_show = False Then
                                    myarrayprint2.Add(2)
                                Else
                                    myarrayprint2.Add(0)
                                End If
                            End If
                        End If

                    Else

                        myarrayprint.Add(Format(tw, "###"))
                        myarrayprint.Add(Format(ta, "###"))
                        myarrayprint.Add(Format(te, "##.#"))
                        myarrayprint.Add(Format(tc, "###.#"))
                        myarrayprint.Add(Format(q, "###.#"))
                        myarrayprint.Add(Format(unit_kw, "####.#"))
                        myarrayprint.Add(Format(GP, "####.#"))
                        myarrayprint.Add(Format(a, "####.#"))
                        myarrayprint.Add(Format(ER, "####.#"))
                        myarrayprint.Add(Format(EZ, "####.#"))

                        If Me.leaving_fluid_temperature = tw And Me.ambient_temperature = ta Then
                            txtApproach.Text() = Round(tw - te, 0)
                        End If
                        ' CHANGE 1
                        If safetyOverride Then
                            ok_to_show = True
                        Else
                            ok_to_show = validate(user.authority_group, compressor, te, tc, tw, MinSuctionTemp)
                        End If

                        'ok_to_show = Me.CheckCompressorSafety(TE, TC, TE, TW)

                        If Trim(txtLeavingFluidTemp.Text()) = Format(tw, "###") And Trim(txtAmbientTemp.Text()) = Format(ta, "###") Then
                            If ok_to_show = False Then
                                myarrayprint.Add(2)
                            Else
                                myarrayprint.Add(1)
                            End If
                        Else
                            If ok_to_show = False Then
                                myarrayprint.Add(2)
                            Else
                                myarrayprint.Add(0)
                            End If
                        End If
                    End If

                    If cboSystem.SelectedItem = "FULL" And NumCircuits = 2 Or NumCircuits = 4 Then
                        If ok_to_print = True Then
                            If Me.leaving_fluid_temperature = tw And Me.ambient_temperature = ta Then
                                txtApproach.Text = Round(tw - ((te + TE_2) / 2), 0)
                            End If

                            Dim evaporatingTemperatureAvg As Single = (te + TE_2) / 2
                            Dim condensingTemperatureAvg As Single = (tc + TC_2) / 2
                            ' CHANGE 1
                            If safetyOverride Then
                                ok_to_show = True
                            Else
                                ok_to_show = validate(user.authority_group, compressor, evaporatingTemperatureAvg, condensingTemperatureAvg, tw, MinSuctionTemp)
                            End If
                            'ok_to_show = Me.CheckCompressorSafety(evaporatingTemperatureAvg, _
                            '   condensingTemperatureAvg, evaporatingTemperatureAvg, TW)
                            If ok_to_show = False Then
                                Me.lblOperLimi.Visible = True
                            End If
                            If ok_to_show = False And Not safetyOverride Then
                                lblOperLimi.Visible = True
                                GoTo SKIP_DATABASE_BUILDER_TABLE1
                            ElseIf ok_to_show = False And safetyOverride Then
                                ok_to_show = True
                            End If
                        End If
                    Else

                        If Me.leaving_fluid_temperature = tw And Me.ambient_temperature = ta Then
                            txtApproach.Text = Round(tw - te, 0)
                        End If
                        ' CHANGE 1
                        If safetyOverride Then
                            ok_to_show = True
                        Else
                            ok_to_show = validate(user.authority_group, compressor, te, tc, tw, MinSuctionTemp)
                        End If
                        'ok_to_show = Me.CheckCompressorSafety(TE, TC, TE, TW)

                        If ok_to_show = False Then
                            lblOperLimi.Visible = True
                        End If
                        If ok_to_show = False And Not safetyOverride Then
                            lblOperLimi.Visible = True
                            GoTo SKIP_DATABASE_BUILDER_TABLE1
                        ElseIf ok_to_show = False And safetyOverride Then
                            ok_to_show = True
                        End If
                    End If


                    Dim approach, pd As Double

                    'checks if dual circuit
                    If Me.cboSystem.SelectedItem = "FULL" And NumCircuits = 2 _
                    Or NumCircuits = 4 Then
                        ' only inserts on second pass
                        If Me.ok_to_print Then
                            approach = Round(tw - ((te + TE_2) / 2), 0)
                            If EvaporatorGrid1.CustomSelected OrElse PD_GPM.GetUpperBound(0) < approach Then
                                pd = 999
                            Else
                                pd = (((GP + GP_2) / PD_GPM(approach, 2)) ^ 2) * PD_GPM(approach, 1)
                            End If
                            ' inserts a row of results
                            Me.insertResults(tw, ta, ((te + TE_2) / 2), ((tc + TC_2) / 2), _
                               (q + Q_2), (unit_kw + KW_2), (GP + GP_2), pd, ((ER + ER_2) / 2), EZ)
                        End If

                    Else  'single circuit
                        approach = Round(tw - te, 0)
                        If EvaporatorGrid1.CustomSelected Then
                            pd = 999
                        Else
                            If approach > 13 Then
                                pd = 999
                            Else
                                pd = ((GP / PD_GPM(approach, 2)) ^ 2) * PD_GPM(approach, 1)
                            End If
                        End If
                        'inserts a row of results
                        Me.insertResults(tw, ta, te, tc, q, unit_kw, GP, pd, ER, EZ)
                    End If


SKIP_DATABASE_BUILDER_TABLE1:

                    'inserts seperator row in database when ambient temperature increments
                    'if on last increment of leaving fluid temperature
                    If Me.leaving_fluid_temperature + 4 = tw Then
                        ' no need to have a seperation after the last ambient temperature section there's nothing after it						
                        If ok_to_print_SPACE _
                        And Me.ambient_temperature + txtTempRange.Text <> ta Then
                            Me.insertBlankRowInResults()
                        End If
                    End If
                    'END seperator *************************************

                    If tw = Me.leaving_fluid_temperature - 2 Then
                        tw = Me.leaving_fluid_temperature - 1
                        GoTo 450
                    ElseIf tw = Me.leaving_fluid_temperature - 1 Then
                        tw = Me.leaving_fluid_temperature - 2
                    End If
                Next tw
Next_Ta:
660:        Next ta

            'stores values from first of 2 circuits in myarrayprint3
            'so that they can be retrieved after 2nd circuit is calculated
1000:       If cboSystem.SelectedItem() = "FULL" And NumCircuits = 2 _
            Or NumCircuits = 4 Then
                If ok_to_print = False Then
                    'MOD: changed method used to copy array into dropdown
                    'for some reason this doesn't always work.
                    'The values in myarrayprint3 are not copied
                    'to dropdownlist3 after the first time it's called.
                    'DropDownList3.DataSource = myarrayprint3

                    'new way, put in sub so try...catch can be used
                    'OnError...GoTo is being used in this subroutine
                    Me.FillDropDownList3()
                    GoTo Skip_Print_or_Cal
                End If
            End If

            ' previously deleted temporary database here

            If cboSystem.SelectedItem() = "FULL" And NumCircuits = 2 _
            Or NumCircuits = 4 Then
                DropDownList2.DataSource = myarrayprint2
            End If
            DropDownList1.DataSource = myarrayprint

            fillResultsGrid() 'fill datagrid
Skip_Print_or_Cal:
            If safetyOverride AndAlso lblOperLimi.Visible Then _
               lblOperLimi.Text = "Compressor Safety Over Ride ON >> points outside operating limits."
        Catch ex As Exception
            Dim msg = "The page cannot be calculated. " & ex.Message & " Contact factory to rate units outside the operating limits."
            lblErro.Text = msg
            warn(msg)
            ''dgrC1Results.Visible = False
            Grid1.Visible = False
            Exit Sub
        End Try
    End Sub

    Private Sub set_enabled_on_acme_related_controls(ByVal enabled As Boolean)
        cbo_models.Enabled = enabled
        cbo_cooling_media.Enabled = enabled
        cbo_series.Enabled = enabled
        cbo_evaporator_model.Enabled = enabled
        btn_alternate_evaporators.Enabled = enabled
        btn_calculate_page.Enabled = enabled
        btn_create_report.Enabled = enabled
        btn_go_to_pricing.Enabled = enabled
    End Sub

    Private Function isValid(ByVal approach As Double, ByVal [for] As user_group) As Boolean
        Dim valid = True

        If approach < 6 And [for] = user_group.rep Then _
           valid = False
        If approach < 5 And [for] = user_group.employee Then _
           valid = False

        Return valid
    End Function

    Private Function validate(ByVal user As user_group, ByVal compressor As compressor, ByVal te As Double, ByVal tc As Double, ByVal tw As Double, ByVal suctionMin As Double) As Boolean
        Dim valid = compressor.is_within_safety_limits(te, tc) _
                And isValid(approach:=(tw - te), for:=user) _
                And te > suctionMin

        Return valid
    End Function



    Private Function approachIsOutOfRange() As Boolean
        Dim inRange = True

        If EvaporatorGrid1.CustomSelected Then
            If EvaporatorGrid1.CustomCapacityCircuit1Approach8 = 0 Or EvaporatorGrid1.CustomCapacityCircuit1Approach10 = 0 Then
                lblErro.Text = "Please enter a valid 8 and 10 deg. approach for circuit 1"
                ''dgrC1Results.Visible = False
                Grid1.Visible = False
                inRange = False
            End If
            If NumCircuits > 1 Then
                If EvaporatorGrid1.CustomCapacityCircuit2Approach8 = 0 Or EvaporatorGrid1.CustomCapacityCircuit2Approach10 = 0 Then
                    lblErro.Text = "Please enter a valid 8 and 10 deg. approach for circuit 2"
                    ''dgrC1Results.Visible = False
                    Grid1.Visible = False
                    inRange = False
                End If
            End If
        Else
            If EvaporatorGrid1.SelectedApproachIsInvalid Then
                lblErro.Text = "Please select a valid approach."
                ''dgrC1Results.Visible = False
                Grid1.Visible = False
                inRange = False
            End If
        End If

        Return Not inRange
    End Function


    'fills dropdown control with values in an array
    'so that the values can be used later to help
    'fill the datagrid
    'this was causing annoying problems before
    Private Sub FillDropDownList3()
        Dim i As Integer
        'set datasource to nothing so that old items in
        'dropdown can be editted (removed); dropdown items
        'can not be removed if dropdown is set to datasource
        Me.DropDownList3.DataSource = Nothing

        'remove old items in dropdown control so that
        'the new items will be added at the beginning
        If Me.DropDownList3.Items.Count > 0 Then
            For i = DropDownList3.Items.Count - 1 To 0 Step -1
                Me.DropDownList3.Items.RemoveAt(i)
            Next
        End If
        'add items in array to dropdown control
        For i = 0 To myarrayprint3.Count - 1
            Me.DropDownList3.Items.Add(myarrayprint3.Item(i))
        Next
    End Sub


    ''' <remarks>
    ''' Only called once (in CalculatePage)
    ''' </remarks>
    Private Sub fillResultsGrid()
        ''Me.dgrC1Results.DataSource = Me.results
        Me.Grid1.DataSource = Me.results
        Me.Grid1.Columns("LeavingTemperature").HeaderText = "Leaving Fluid Temp. [°F]"
        Me.Grid1.Columns("AmbientTemperature").HeaderText = "Ambient Temp. [°F]"
        Me.Grid1.Columns("EvaporatorTemperature").HeaderText = "Evaporator Temp. [°F]"
        Me.Grid1.Columns("CondenserTemperature").HeaderText = "Condenser Temp. [°F]"
        Me.Grid1.Columns("Capacity").HeaderText = "Est. Capcity [Tons]"
        Me.Grid1.Columns("UnitPower").HeaderText = "Unit [KW]"
        Me.Grid1.Columns("FlowRate").HeaderText = "GPM"
        Me.Grid1.Columns("EvaporatorPressureDrop").HeaderText = "Evaporator PD [psi]"
        Me.Grid1.Columns("CompressorEfficiency").HeaderText = "Compressor EER"
        Me.Grid1.Columns("UnitEfficiency").HeaderText = "Unit EER"
        ''Me.formatResultsGrid(Me.Grid1)
    End Sub


    Private Sub startCalculations()
        ok_to_print_SPACE = False
        Me.results.Rows.Clear()

        setCoilDescription()
        'Page_Cal_Pass = 1
run_Second_pass:
        myarrayprint.Clear()
        myarrayprint2.Clear()
        ''' <history>Added by Casey Joyce</history>
        ''' <summary>myarrayprint3 was never cleared; if calculate page is clicked more than once, 
        ''' the array just gets bigger and only the beginning indices are ever used which is incorrect</summary>
        myarrayprint3.Clear()

        'okay to print
        If cboSystem.SelectedItem = "FULL" And NumCircuits = 2 Or NumCircuits = 4 Then
            ok_to_print = False
            Running_Circuit_no = 1
            calculatePage()

            ok_to_print = True
            ok_to_print_SPACE = True
            Running_Circuit_no = 2
            calculatePage()
        ElseIf cboSystem.SelectedItem = "FULL" And NumCircuits = 1 Then
            ok_to_print_SPACE = True
            Running_Circuit_no = 1
            calculatePage()
        ElseIf cboSystem.SelectedItem = "HALF" Then
            If radCircuit1.Checked = True Then
                Running_Circuit_no = 1
            ElseIf radCircuit2.Checked = True Then
                ok_to_print_SPACE = True
                Running_Circuit_no = 2
            End If
            calculatePage()
        End If
    End Sub


    Private Function getCircuitsToRun(ByVal system As String, ByVal numCircuitsPerUnit As Integer, ByVal selectedCircuitNum As Integer) As List(Of Integer)
        Dim circuitsToRun As New List(Of Integer)()

        'okay to print
        If system.ToUpper() = "FULL" And numCircuitsPerUnit = 2 Or numCircuitsPerUnit = 4 Then
            circuitsToRun.Add(1)
            circuitsToRun.Add(2)
        ElseIf system.ToUpper() = "FULL" And numCircuitsPerUnit = 1 Then
            circuitsToRun.Add(1)
        ElseIf cboSystem.SelectedItem = "HALF" Then
            If selectedCircuitNum = 1 Then
                circuitsToRun.Add(1)
            ElseIf selectedCircuitNum = 2 Then
                circuitsToRun.Add(2)
            End If
        Else
            Throw New ApplicationException("Invalid system selection.")
        End If

        Return circuitsToRun
    End Function


    Public Shared Function RetrieveEvaporator(ByVal standardModel As String, ByVal numCircuitsPerUnit As Integer, _
    ByVal length As Single, ByVal authorizationLevel As Integer) As String
        Dim evaporatorModel As String

        If BCE.Evaporator1.IsEvaporatorModelValid(standardModel) Then _
           evaporatorModel = DataAccess.Chillers.ChillerDataAccess.RetrieveEvaporator( _
              standardModel, numCircuitsPerUnit, length, authorizationLevel)

        Return evaporatorModel
    End Function

    'sets fan watts control value based on hertz and condenser fan
    Private Sub setFanWatts()
        Dim fanFileName As String = Me.fan.FileName
        Dim hertz As Integer = CInt(Me.cboHertz.SelectedItem.ToString)
        Dim voltage = grabVoltage()

        Dim fan_watts = Business.Intelligence.FanIntel.SelectFanWatts(fanFileName, hertz, voltage)

        txtFanWatts.Text = fan_watts.ToString
    End Sub

    Private Sub callCircuit1(ByVal chiller As chiller)
        Running_Circuit_no = 1

        ' sets controls
        '
        cboRefrigerant.SelectedIndex = indexOfRefrigerant(cboRefrigerant, chiller.circuit_1.refrigerant)
        txt_evaporator_model.Text = chiller.evaporator_part_number
        txtCondenser_1.Text = chiller.circuit_1.coil.name.ToUpper
        txtCompressor1.Text = chiller.circuit_1.compressor.masterID.ToUpper
        txtNumCompressors1.Text = chiller.circuit_1.compressor_quantity
        txtNumFans1.Text = chiller.circuit_1.fan_quantity
        txtNumCoils1.Text = chiller.circuit_1.coil_quantity
        txtSubCooling1.Text = chiller.circuit_1.subcooling_percentage
        txtNumCircuits.Text = chiller.num_circuits_per_unit

        displaySystemCapacity(Average(chiller.approx_min_capacity, chiller.approx_max_capacity))

        If chiller.num_circuits_per_unit = 1 Then
            cboSystem.SelectedIndex = 0
            cboSystem.Enabled = False
        Else
            cboSystem.Enabled = True
        End If

        lboCompressors1.SelectedIndex = ControlAssistant.GetIndexOfValueInListBox(lboCompressors1, chiller.circuit_1.compressor.masterID)
        cboFinsPerInch1.SelectedIndex = ControlAssistant.GetIndexOfComboboxItem(cboFinsPerInch1, CInt(chiller.circuit_1.coil.fpi))
        txtFinHeight1.Text = chiller.circuit_1.coil.height
        txtFinLength1.Text = chiller.circuit_1.coil.length

        cboCondenser1.SelectedIndex = indexOfCondenser(cboCondenser1, chiller.circuit_1.coil.rows & "RCOND")
        cboFan.SelectedIndex = indexOfFanFileName(cboFan, Logic.FanIntel.SelectFanFileName(chiller.circuit_1.fan_diameter))

        If chiller.num_circuits_per_unit > 1 Then
            radCircuit2.Visible = True
        End If

        setChillerEvaporatorControls(chiller.evaporator_part_number)
        setCondenserCapacity(1)

        standardRef.SetSpecificHeatAndGravity()
        standardRef.ListEvaporatorDataForApproachRange()
    End Sub

    Private Sub callCircuit2(ByVal chiller As air_cooled_chillers.chiller)
        Running_Circuit_no = 2

        txt_evaporator_model.Text = chiller.evaporator_part_number.ToUpper
        txtNumCircuits.Text = chiller.num_circuits_per_unit
        ' fills hid condenser textboxes
        txtCondenser_2.Text = chiller.circuit_2.coil.name.ToUpper
        txtCompressor2.Text = chiller.circuit_2.compressor.masterID.ToUpper
        txtNumCompressors2.Text = chiller.circuit_2.compressor_quantity
        txtNumFans2.Text = chiller.circuit_2.fan_quantity
        txtNumCoils2.Text = chiller.circuit_2.coil_quantity
        txtSubCooling2.Text = chiller.circuit_2.subcooling_percentage.ToString
        ' set evaporator capacity? in tons or gpm, approx. capacities are in tons
        displaySystemCapacity(Average(chiller.approx_min_capacity, chiller.approx_max_capacity))

        ' disables system control if only 1 circuit per unit
        If chiller.num_circuits_per_unit = 1 Then
            cboSystem.SelectedIndex = 0
            cboSystem.Enabled = False
        Else
            cboSystem.Enabled = True
        End If

        lboCompressors2.SelectedIndex = ControlAssistant.GetIndexOfValueInListBox(Me.lboCompressors2, Me.txtCompressor2.Text)
        cboFinsPerInch2.SelectedIndex = rae.Ui.ListHelper.IndexOfComboBoxItem(Me.cboFinsPerInch2, CInt(chiller.circuit_2.coil.fpi))
        txtFinHeight2.Text = chiller.circuit_2.coil.height.ToString
        txtFinLength2.Text = chiller.circuit_2.coil.length.ToString
        cboCondenser2.SelectedIndex = indexOfCondenser(cboCondenser2, chiller.circuit_2.coil.rows.ToString & "RCOND")
        cboFan.SelectedIndex = indexOfFanFileName(cboFan, Logic.FanIntel.SelectFanFileName(chiller.circuit_2.fan_diameter))

        'shows circuit 2 radiobutton if circuits is greater than 1
        If chiller.num_circuits_per_unit > 1 Then
            radCircuit2.Visible = True
        End If

        setChillerEvaporatorControls(chiller.evaporator_part_number)
        setCondenserCapacity(2)

        standardRef.SetSpecificHeatAndGravity()
        standardRef.ListEvaporatorDataForApproachRange()
    End Sub

#End Region


#Region " Private methods"

    Private Function fanIsCustom() As Boolean
        Return Me.fan.FileName = "CFM Per Fan >>>"
    End Function

    Private Sub loadControls(ByVal process_item As ACChillerProcessItem)

        ' If latest revision has not been set then
        ' we need to set it now  based on the ID...
        If Me._latestRevision = -1 Then
            Me._latestRevision = rae.RaeSolutions.DataAccess.Projects.ProcessItemDA.LastestRevision(Me.Tag)
        End If

        ' Increment the current process revision
        ' displayed on this form...
        Me._currentrevision = process_item.Revision

        ' Clone last saved process to passing process item
        LastSavedProcess = process_item.Clone()

        cbo_series.Text = LastSavedProcess.Series

        If Me.LastSavedProcess.Refrigerant IsNot Nothing Then
            cboRefrigerant.Text = LastSavedProcess.Refrigerant
        End If
        If Me.LastSavedProcess.Volts <> 0 Then
            loaded = False
            cboVolts.Text = LastSavedProcess.Volts
            loaded = True
        End If

        model_changed_schedule.disable()
        cbo_models.Text = LastSavedProcess.Model
        txt_model.Text = LastSavedProcess.ModelDesc
        model_changed_schedule.enable()

        If Me.LastSavedProcess.Refrigerant IsNot Nothing Then
            cboRefrigerant.Text = LastSavedProcess.Refrigerant
        End If

        fillCompressorListBoxes()

        If Me.LastSavedProcess.Fluid IsNot Nothing Then
            cboFluid.Text = LastSavedProcess.Fluid
        End If
        txtGlycolPercentage.Text = LastSavedProcess.GlycolPercentage
        If LastSavedProcess.CoolingMedia IsNot Nothing Then
            Me.cbo_cooling_media.Text = LastSavedProcess.CoolingMedia
        End If
        txtSpecificHeat.Text = LastSavedProcess.SpecificHeat
        If Me.LastSavedProcess.SpecificGravity > 0 Then
            txtSpecificGravity.Text = LastSavedProcess.SpecificGravity
        End If
        txtSubCooling.Text = LastSavedProcess.SubCooling

        ' don't override temperature range
        If LastSavedProcess.TempRange > 0 Then
            txtTempRange.Text = LastSavedProcess.TempRange
        End If
        txtAmbientTemp.Text = LastSavedProcess.AmbientTemp
        txtLeavingFluidTemp.Text = LastSavedProcess.LeavingFluidTemp
        If Me.LastSavedProcess.System IsNot Nothing Then
            cboSystem.Text = LastSavedProcess.System
        End If
        If Me.LastSavedProcess.Hertz <> 0 Then
            cboHertz.Text = LastSavedProcess.Hertz
        End If
        If Me.LastSavedProcess.Approach IsNot Nothing Then
            txtApproach.Text = LastSavedProcess.Approach
        End If

        chkSafetyOverride.Checked = LastSavedProcess.SafetyOverride
        radCircuit1.Checked = LastSavedProcess.Circuit1
        radCircuit2.Checked = LastSavedProcess.Circuit2
        ' selects circuit 1 if neither circuit is selected
        If Not Me.LastSavedProcess.Circuit1 And Not Me.LastSavedProcess.Circuit2 Then
            Me.radCircuit1.Checked = True
        End If
        If Me.LastSavedProcess.Compressors1 IsNot Nothing Then
            For i As Integer = 0 To lboCompressors1.Items.Count - 1
                lboCompressors1.SetSelected(i, True)
                If lboCompressors1.Text Like Trim(LastSavedProcess.Compressors1) & "*" Then
                    Exit For
                End If
            Next
            txtCompressor1.Text = LastSavedProcess.Compressors1
        End If
        If Me.LastSavedProcess.Compressors2 IsNot Nothing Then
            For i As Integer = 0 To lboCompressors2.Items.Count - 1
                lboCompressors2.SetSelected(i, True)
                If lboCompressors2.Text Like Trim(LastSavedProcess.Compressors2) & "*" Then
                    Exit For
                End If
            Next
            txtCompressor2.Text = LastSavedProcess.Compressors2
        End If

        ' sets number of compressors on circuit 1 to one if both circuits' number of compressors = 0
        If Me.LastSavedProcess.NumCompressors1 = 0 Then
            Me.txtNumCompressors1.Text = "1"
        Else
            txtNumCompressors1.Text = LastSavedProcess.NumCompressors1
        End If
        If Me.LastSavedProcess.NumCompressors2 = 0 Then
            Me.txtNumCompressors2.Text = "1"
        Else
            Me.txtNumCompressors2.Text = LastSavedProcess.NumCompressors2
        End If

        ' sets number of coils to a default of 1 if number of coils is zero
        If Me.LastSavedProcess.NumCoils1 = 0 Then
            Me.txtNumCoils1.Text = "1"
        Else
            txtNumCoils1.Text = LastSavedProcess.NumCoils1
        End If
        If Me.LastSavedProcess.NumCoils2 = 0 Then
            Me.txtNumCoils2.Text = "0"
        Else
            txtNumCoils2.Text = LastSavedProcess.NumCoils2
        End If
        If Me.LastSavedProcess.Condenser1 IsNot Nothing Then
            Me.cboCondenser1.Text = LastSavedProcess.Condenser1
        Else
            Me.cboCondenser1.SelectedIndex = 0
        End If
        If Me.LastSavedProcess.Condenser2 IsNot Nothing Then
            cboCondenser2.Text = LastSavedProcess.Condenser2
        End If
        Me.cboFinsPerInch1.Text = LastSavedProcess.FinsPerInch1
        Me.cboFinsPerInch2.Text = LastSavedProcess.FinsPerInch2

        If LastSavedProcess.SubCooling1 = True Then
            Me.cboSubCooling1.Text = "Yes"
        Else
            Me.cboSubCooling1.Text = "No"
        End If
        Me.txtSubCooling1.Text = LastSavedProcess.SubCoolingPercent1

        If LastSavedProcess.SubCooling2 = True Then
            Me.cboSubCooling2.Text = "Yes"
        Else
            Me.cboSubCooling2.Text = "No"
        End If
        Me.txtSubCooling2.Text = LastSavedProcess.SubCoolingPercent2

        Me.txtCondenserTD1.Text = LastSavedProcess.CondenserTD1
        Me.txtCondenserTD2.Text = LastSavedProcess.CondenserTD2
        Me.txtFinHeight1.Text = LastSavedProcess.FinHeight1
        Me.txtFinHeight2.Text = LastSavedProcess.FinHeight2
        Me.txtFinLength1.Text = LastSavedProcess.FinLength1
        Me.txtFinLength2.Text = LastSavedProcess.FinLength2


        cboDischargeLineLoss.Text = LastSavedProcess.DischargeLineLoss
        cboSuctionLineLoss.Text = LastSavedProcess.SuctionLineLoss
        txtAltitude.Text = LastSavedProcess.Altitude
        'txtPumpWatts.Text = LastSavedProcess.PumpWatts
        If LastSavedProcess.Fan IsNot Nothing Then
            Me.cboFan.Text = LastSavedProcess.Fan
        End If
        Me.txtCfmOverride.Text = LastSavedProcess.CfmOverride
        Me.txtNumFans1.Text = LastSavedProcess.NumFans1
        Me.txtNumFans2.Text = LastSavedProcess.NumFans2
        If fanIsCustom() Then _
           txtFanWatts.Text = LastSavedProcess.FanWatts
        If Not (Me.LastSavedProcess.CondenserCapacity1) Then
            txtCondenserCapacity1.Text = LastSavedProcess.CondenserCapacity1
        End If
        If Not Me.LastSavedProcess.CondenserCapacity2 = 0 Then
            txtCondenserCapacity2.Text = LastSavedProcess.CondenserCapacity2
        End If
        If Me.LastSavedProcess.EvaporatorModel IsNot Nothing Then
            cbo_evaporator_model.Text = LastSavedProcess.EvaporatorModel
        End If
        If Me.LastSavedProcess.EvaporatorModelDesc IsNot Nothing Then
            txt_evaporator_model.Text = LastSavedProcess.EvaporatorModelDesc
        End If
        'cboNumevap.Text = LastSavedProcess.NumEvap
        If Me.LastSavedProcess.FoulingFactor > 0 Then
            cboFoulingFactor.Text = LastSavedProcess.FoulingFactor
        End If
        If LastSavedProcess.CapacityType = ACChillerProcessItem.eCapacityType.Tons Then
            radTons.Checked = True
        ElseIf LastSavedProcess.CapacityType = ACChillerProcessItem.eCapacityType.GPM Then
            radGpm.Checked = True
        Else
            radGpm.Checked = False
            radTons.Checked = False
        End If
        If Me.LastSavedProcess.EvaporatorCapacity > 0 Then
            Me.txtEvaporatorCapacity.Text = Me.LastSavedProcess.EvaporatorCapacity.ToString
        End If
        chkCatalogRating.Checked = LastSavedProcess.CatalogRating
        ' Approach range...
        If LastSavedProcess.ApproachRange = ACChillerProcessItem.eApproachRange.SixToEight Then
            EvaporatorGrid1.rbo6To8.Checked = True
        ElseIf LastSavedProcess.ApproachRange = ACChillerProcessItem.eApproachRange.SevenToNine Then
            EvaporatorGrid1.rbo7To9.Checked = True
        ElseIf LastSavedProcess.ApproachRange = ACChillerProcessItem.eApproachRange.EightToTen Then
            EvaporatorGrid1.rbo8To10.Checked = True
        ElseIf LastSavedProcess.ApproachRange = ACChillerProcessItem.eApproachRange.NineToEleven Then
            EvaporatorGrid1.rbo9To11.Checked = True
        ElseIf LastSavedProcess.ApproachRange = ACChillerProcessItem.eApproachRange.TenToTwelve Then
            EvaporatorGrid1.rbo10To12.Checked = True
        ElseIf LastSavedProcess.ApproachRange = ACChillerProcessItem.eApproachRange.Other Then
            EvaporatorGrid1.rboCustom.Checked = True
        End If
        EvaporatorGrid1.txtCustomCapacity1At8.Text = LastSavedProcess.Evap8Degr1
        EvaporatorGrid1.txtCustomCapacity1At10.Text = LastSavedProcess.Evap10Degr1
        EvaporatorGrid1.txtCustomCapacity2At8.Text = LastSavedProcess.Evap8Degr2
        EvaporatorGrid1.txtCustomCapacity2At10.Text = LastSavedProcess.Evap10Degr2
        'tbxEvap8Degr1.Text = LastSavedProcess.Evap8Degr1
        'tbxEvap8Degr2.Text = LastSavedProcess.Evap8Degr2
        'tbxEvap10Degr1.Text = LastSavedProcess.Evap10Degr1
        'tbxEvap10Degr2.Text = LastSavedProcess.Evap10Degr2
    End Sub

    Function SaveControls(Optional ByVal SaveAsRevision As Boolean = False, Optional ByVal SaveAsNew As Boolean = False, Optional ByVal FormClosing As Boolean = False, Optional ByVal GenerateEquipment As Boolean = False, Optional ByVal RevChanged As Boolean = False) As Boolean

        If CurrentStateProcess Is Nothing Then
            If LastSavedProcess Is Nothing Then
                CurrentStateProcess = New ACChillerProcessItem(New item_id(user.username, user.password))
            Else
                CurrentStateProcess = LastSavedProcess.Clone
            End If
        Else
            If LastSavedProcess IsNot Nothing Then CurrentStateProcess = LastSavedProcess.Clone
        End If

        Dim ambient = CDbl(txtAmbientTemp.Text)
        Dim leavingFluidTemperature = CDbl(txtLeavingFluidTemp.Text)
        If Me.results.Rows.Count > 0 _
        AndAlso Me.results.Rows.Count > 0 Then
            Dim row = getRowAtDesignConditions(results, ambient, leavingFluidTemperature)
            If row IsNot Nothing Then
                Dim rowAtDesignConditions As Integer
                CurrentStateProcess.CapacityAtDesignConditions = row.Capacity
                If Not row.EvaporatorPressureDrop = "*" Then _
                   CurrentStateProcess.EvaporatorPressureDropAtDesignConditions = row.EvaporatorPressureDrop
                CurrentStateProcess.FlowAtDesignConditions = row.FlowRate
            End If
        End If

        CurrentStateProcess.Series = cbo_series.Text
        CurrentStateProcess.Model = cbo_models.Text
        CurrentStateProcess.ModelDesc = txt_model.Text
        CurrentStateProcess.Fluid = cboFluid.Text
        CurrentStateProcess.GlycolPercentage = Val(txtGlycolPercentage.Text)
        CurrentStateProcess.CoolingMedia = cbo_cooling_media.Text
        CurrentStateProcess.SpecificHeat = txtSpecificHeat.Text
        CurrentStateProcess.SpecificGravity = txtSpecificGravity.Text
        CurrentStateProcess.SubCooling = txtSubCooling.Text
        CurrentStateProcess.Refrigerant = cboRefrigerant.Text
        CurrentStateProcess.TempRange = txtTempRange.Text
        CurrentStateProcess.AmbientTemp = txtAmbientTemp.Text
        CurrentStateProcess.LeavingFluidTemp = txtLeavingFluidTemp.Text
        CurrentStateProcess.System = cboSystem.Text
        CurrentStateProcess.Hertz = cboHertz.Text
        CurrentStateProcess.Approach = txtApproach.Text
        CurrentStateProcess.Volts = cboVolts.Text
        CurrentStateProcess.SafetyOverride = chkSafetyOverride.Checked
        CurrentStateProcess.Circuit1 = radCircuit1.Checked
        CurrentStateProcess.Circuit2 = radCircuit2.Checked
        CurrentStateProcess.Compressors1 = txtCompressor1.Text
        CurrentStateProcess.Compressors2 = txtCompressor2.Text
        CurrentStateProcess.NumCompressors1 = Val(txtNumCompressors1.Text)
        CurrentStateProcess.NumCompressors2 = Val(txtNumCompressors2.Text)
        CurrentStateProcess.NumCoils1 = Val(txtNumCoils1.Text)
        CurrentStateProcess.NumCoils2 = Val(txtNumCoils2.Text)
        CurrentStateProcess.Condenser1 = cboCondenser1.Text
        CurrentStateProcess.Condenser2 = cboCondenser2.Text
        CurrentStateProcess.FinsPerInch1 = cboFinsPerInch1.Text
        CurrentStateProcess.FinsPerInch2 = cboFinsPerInch2.Text
        If cboSubCooling1.Text = "Yes" Then
            CurrentStateProcess.SubCooling1 = True
        Else
            CurrentStateProcess.SubCooling1 = False
        End If
        If cboSubCooling2.Text = "Yes" Then
            CurrentStateProcess.SubCooling2 = True
        Else
            CurrentStateProcess.SubCooling2 = False
        End If
        CurrentStateProcess.SubCoolingPercent1 = Val(Me.txtSubCooling1.Text)
        CurrentStateProcess.SubCoolingPercent2 = Val(Me.txtSubCooling2.Text)
        CurrentStateProcess.CondenserTD1 = Me.txtCondenserTD1.Text
        CurrentStateProcess.CondenserTD2 = Me.txtCondenserTD2.Text
        CurrentStateProcess.FinHeight1 = Val(Me.txtFinHeight1.Text)
        CurrentStateProcess.FinHeight2 = Val(Me.txtFinHeight2.Text)
        CurrentStateProcess.FinLength1 = Val(Me.txtFinLength1.Text)
        CurrentStateProcess.FinLength2 = Val(Me.txtFinLength2.Text)
        CurrentStateProcess.DischargeLineLoss = cboDischargeLineLoss.Text
        CurrentStateProcess.SuctionLineLoss = cboSuctionLineLoss.Text
        CurrentStateProcess.Altitude = txtAltitude.Text
        'CurrentStateProcess.PumpWatts = Val(txtPumpWatts.Text)
        CurrentStateProcess.Fan = Me.cboFan.Text
        CurrentStateProcess.NumFans1 = Val(Me.txtNumFans1.Text)
        CurrentStateProcess.NumFans2 = Val(Me.txtNumFans2.Text)
        CurrentStateProcess.CfmOverride = Val(Me.txtCfmOverride.Text)
        CurrentStateProcess.FanWatts = Val(txtFanWatts.Text)
        CurrentStateProcess.CondenserCapacity1 = Val(txtCondenserCapacity1.Text)
        CurrentStateProcess.CondenserCapacity2 = Val(txtCondenserCapacity2.Text)
        CurrentStateProcess.EvaporatorModel = cbo_evaporator_model.Text
        CurrentStateProcess.EvaporatorModelDesc = txt_evaporator_model.Text
        'CurrentStateProcess.NumEvap = Val(cboNumEvap.Text)
        CurrentStateProcess.FoulingFactor = Val(cboFoulingFactor.Text)
        If radTons.Checked = True Then
            CurrentStateProcess.CapacityType = ACChillerProcessItem.eCapacityType.Tons
        ElseIf radGpm.Checked = True Then
            CurrentStateProcess.CapacityType = ACChillerProcessItem.eCapacityType.GPM
        End If

        CurrentStateProcess.EvaporatorCapacity = Val(txtEvaporatorCapacity.Text)
        CurrentStateProcess.CatalogRating = chkCatalogRating.Checked
        ' Approach range...
        If EvaporatorGrid1.rbo6To8.Checked Then
            CurrentStateProcess.ApproachRange = ACChillerProcessItem.eApproachRange.SixToEight
        ElseIf EvaporatorGrid1.rbo7To9.Checked Then
            CurrentStateProcess.ApproachRange = ACChillerProcessItem.eApproachRange.SevenToNine
        ElseIf EvaporatorGrid1.rbo8To10.Checked Then
            CurrentStateProcess.ApproachRange = ACChillerProcessItem.eApproachRange.EightToTen
        ElseIf EvaporatorGrid1.rbo9To11.Checked Then
            CurrentStateProcess.ApproachRange = ACChillerProcessItem.eApproachRange.NineToEleven
        ElseIf EvaporatorGrid1.rbo10To12.Checked Then
            CurrentStateProcess.ApproachRange = ACChillerProcessItem.eApproachRange.TenToTwelve
        ElseIf EvaporatorGrid1.CustomSelected Then
            CurrentStateProcess.ApproachRange = ACChillerProcessItem.eApproachRange.Other
        End If
        CurrentStateProcess.Evap8Degr1 = EvaporatorGrid1.CustomCapacityCircuit1Approach8 ' Val(tbxEvap8Degr1.Text)
        CurrentStateProcess.Evap8Degr2 = EvaporatorGrid1.CustomCapacityCircuit2Approach8 ' Val(tbxEvap8Degr2.Text)
        CurrentStateProcess.Evap10Degr1 = EvaporatorGrid1.CustomCapacityCircuit1Approach10 ' Val(tbxEvap10Degr1.Text)
        CurrentStateProcess.Evap10Degr2 = EvaporatorGrid1.CustomCapacityCircuit2Approach10 ' Val(tbxEvap10Degr2.Text)

        ' Set save process...
        Dim RevSave As New RevisionSave
        CurrentStateProcess = RevSave.SetSaveProcess(Me, Business.ProcessType.AirCooledChiller, CurrentStateProcess, LastSavedProcess, SaveAsNew, SaveAsRevision, FormClosing, GenerateEquipment, RevChanged)
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
            CurrentStateProcess = LastSavedProcess.Clone
            RevSave = Nothing
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


#Region " Data"

    Private Function GetRefrigerants() As ArrayList
        Dim refrigerants As New ArrayList

        With refrigerants
            ' adds refrigerants to list
            .Add(New cFillCombobox("R134a", "R134a"))
            .Add(New cFillCombobox("R404a", "R404a"))
            .Add(New cFillCombobox("R407c", "R407c"))
            If user.can(balance_R410a_chiller) Then .Add(New cFillCombobox("R410a", "R410a"))
            If user.is_employee Then .Add(New cFillCombobox("R507", "R507"))
            .Add(New cFillCombobox("R22", "R22"))

            If user.is_in(Rae.solutions.group.application_engineering) Then
                .Add(New cFillCombobox("R407a", "R407a"))
                .Add(New cFillCombobox("R407f", "R407f"))
                .Add(New cFillCombobox("R448a", "R448a"))
                .Add(New cFillCombobox("R449a", "R449a"))
            End If


        End With

        Return refrigerants
    End Function

#End Region


#Region " UI"

    Private Function grab_model() As String
        Return Me.cbo_models.SelectedItem.ToString
    End Function

    Private Function grabSpecificGravity() As Double
        Return Round(CDbl(Me.txtSpecificGravity.Text.Trim), 2)
    End Function

    Private Function grabSpecificHeat() As Double
        Return CDbl(Me.txtSpecificHeat.Text.Trim)
    End Function

    Private Function grabSystemCapacity() As Double
        Return CDbl(Me.txtEvaporatorCapacity.Text.Trim)
    End Function

    Friend Function GrabSystemCapacityTons() As Double
        Dim systemCapacityInTons As Double

        If Me.radTons.Checked Then
            systemCapacityInTons = grabSystemCapacity()
        ElseIf Me.radGpm.Checked Then
            systemCapacityInTons = Convert.GpmToTons(grabSystemCapacity(), TempRange, _
               grabSpecificHeat(), grabSpecificGravity())
        End If

        Return systemCapacityInTons
    End Function

    Private Function GrabCondenser1() As Condenser1
        Return DirectCast(Me.cboCondenser1.SelectedItem, Condenser1)
    End Function

    Private Function GrabCondenser2() As Condenser1
        Return DirectCast(Me.cboCondenser2.SelectedItem, Condenser1)
    End Function

    Private Sub displaySystemCapacity(ByVal capacityTons As Single)
        If Me.radTons.Checked Then  'Tons 
            Me.txtEvaporatorCapacity.Text = Round(capacityTons, 2)
        ElseIf radGpm.Checked Then  'GPM 
            Me.txtEvaporatorCapacity.Text = _
               Convert.TonsToGpm(capacityTons, TempRange, grabSpecificHeat(), grabSpecificGravity())
            'Me.txtEvaporatorCapacity.Text = Common.Convert.TonsToGpm(Common.Math.Average(minCapacity, maxCapacity), _
            '   temperatureRange, specificHeat, specificGravity)
        End If
    End Sub


    Private Sub colorControls()
        With New ColorManager
            Me.modelPanel.BackColor = .LightBlue
            Me.panButtons.BackColor = .LightBlue
            Me.lblErro.BackColor = .LightBlue
            Me.panFooter.BackColor = .LightBlue

            ' colors headers
            Me.lblRatingCriteria.ForeColor = .HeaderBlue
            Me.lblCompressor.ForeColor = .HeaderBlue
            Me.lblCondenser.ForeColor = .HeaderBlue
            Me.lblEvaporator.ForeColor = .HeaderBlue

            ' colors lines
            Me.lineRatingCriteria.ForeColor = .HeaderBlue
            Me.lineCompressor.ForeColor = .HeaderBlue
            Me.lineCondenser.ForeColor = .HeaderBlue
            Me.lineEvaporator.ForeColor = .HeaderBlue

            ' colors comments
            Me.lblSubCoolingF.ForeColor = .GreyBlue
            Me.lblMinSuctionF.ForeColor = .GreyBlue
            Me.lblAmbientF.ForeColor = .GreyBlue
            Me.lblFreezePointF.ForeColor = .GreyBlue
            Me.lblLeavingFluidF.ForeColor = .GreyBlue
            Me.lblRangeF.ForeColor = .GreyBlue
            Me.lblCFM.ForeColor = .GreyBlue

            Me.lblCondenserTD1F.ForeColor = .GreyBlue
            Me.lblCondenserTD2F.ForeColor = .GreyBlue
            Me.lblAltitudeFt.ForeColor = .GreyBlue
            Me.lblApplies1.ForeColor = .GreyBlue
            Me.lblApplies2.ForeColor = .GreyBlue
            Me.lblApplies3.ForeColor = .GreyBlue
            Me.lblApplies4.ForeColor = .GreyBlue
            Me.lblDischargeLineLossF.ForeColor = .GreyBlue
            Me.lblSuctionLineLossF.ForeColor = .GreyBlue
            Me.lblCondenserCapacityBtuh.ForeColor = .GreyBlue
            Me.lblCondenserCapacityF.ForeColor = .GreyBlue
            Me.lblCondSubCoolingPercent1.ForeColor = .GreyBlue
            Me.lblCondSubCoolingPercent2.ForeColor = .GreyBlue

            ' colors buttons
            Me.btnCriteriaPlus.ForeColor = .HeaderBlue
            Me.btnCriteriaPlus.BackColor = .LighterBlue
            Me.btnCompressorPlus.ForeColor = .HeaderBlue
            Me.btnCompressorPlus.BackColor = .LighterBlue
            Me.btnCondenserPlus.ForeColor = .HeaderBlue
            Me.btnCondenserPlus.BackColor = .LighterBlue
            Me.btnEvaporatorPlus.ForeColor = .HeaderBlue
            Me.btnEvaporatorPlus.BackColor = .LighterBlue

        End With
    End Sub

    Private Sub setChillerEvaporatorControls(ByVal evaporatorModel As String)
        Dim evaporator As Evaporator1

        Try
            evaporator = BCA.RetrieveChillerEvaporator(evaporatorModel)
        Catch ex As DataException
            alert("Attempt to retrieve the chiller's evaporator information failed. " & ex.Message)
            Exit Sub
        End Try
        txtEvapLength.Text = evaporator.Length

        txt_evaporator_model.Text = evaporator.EvaporatorPartNum

        ToolTip1.SetToolTip(txt_evaporator_model, evaporator.ToString())
        ToolTip1.SetToolTip(txt_model, evaporator.ToString())
        ToolTip1.SetToolTip(modelLabel, evaporator.ToString())
    End Sub

    Private Sub fillCompressorListBoxes()
        'todo: compressorCtrl.Fill(with:=compressors)

        Dim refg = refrigerant.parse(RefrigerantString)
        Dim voltage = grabVoltage()
        Dim compressors = service.get_compressors(refg, voltage, "AirCooledChiller", "N") 'compressorRepository.GetCompressors(refg, voltage)

        Dim descriptions1 = New List(Of CompressorDescription)
        Dim descriptions2 = New List(Of CompressorDescription)
        For Each comp In compressors
            descriptions1.Add(New CompressorDescription(comp.model, comp.MasterID, comp.hp))
            descriptions2.Add(New CompressorDescription(comp.model, comp.MasterID, comp.hp))
        Next
        descriptions1.Add(New CompressorDescription("Choose", "Choose", "Choose"))
        descriptions2.Add(New CompressorDescription("Choose", "Choose", "Choose"))

        lboCompressors1.DataSource = descriptions1
        lboCompressors1.DisplayMember = "Description"
        lboCompressors1.ValueMember = "Model"

        lboCompressors2.DataSource = descriptions2
        lboCompressors2.DisplayMember = "Description"
        lboCompressors2.ValueMember = "Model"
    End Sub

#End Region


    ' TODO: move declarations to top of class
    Private chillerVMgr As ValidationManager
    Private leavingFluidTempVCtrl As ValidationControl
    Private WithEvents compressor1VCtrl As ValidationControl
    Private WithEvents compressor2VCtrl As ValidationControl

    ' initializes validation utilities (managers, controls, and validators)
    Private Sub initializeValidation()
        ' VMgr - ValidationManager
        ' VCtrl - ValidationControl
        ' RangeV - RangeValidator, ReqV - RequiredValidator, NumV - NumberValidator

        Dim leavingFluidTempName = "Leaving fluid temperature textbox"

        ' constructs and sets validation managers error provider
        Me.chillerVMgr = New ValidationManager(Me.err)
        ' constructs and adds leaving fluid temperature textbox to validation control
        Me.leavingFluidTempVCtrl = New ValidationControl(Me.txtLeavingFluidTemp)
        Me.compressor1VCtrl = New ValidationControl(Me.lboCompressors1)
        Me.compressor2VCtrl = New ValidationControl(Me.lboCompressors2)

        ' constructs required validator
        Dim leavingFluidTempReqV = New RequiredValidator(ErrorMessages.Required(leavingFluidTempName))
        ' constructs number (regular expression) validator
        Dim leavingFluidTempNumV = New RegularExpressionValidator( _
           ErrorMessages.Number(leavingFluidTempName), rae.validation.regular_expressions.number)
        ' contstructs range validator w/ error message and limits
        Dim leavingFluidTempRangeV = New AmongRangeValidator( _
           ErrorMessages.Range(leavingFluidTempName, LEAVING_FLUID_TEMP_LOWER_LIMIT, LEAVING_FLUID_TEMP_UPPER_LIMIT), _
           LEAVING_FLUID_TEMP_LOWER_LIMIT, LEAVING_FLUID_TEMP_UPPER_LIMIT)

        ' adds controls to validation manager
        Me.chillerVMgr.ValidationControls.Add(Me.leavingFluidTempVCtrl)
        Me.chillerVMgr.ValidationControls.Add(Me.compressor1VCtrl)
        Me.chillerVMgr.ValidationControls.Add(Me.compressor2VCtrl)

        ' adds validators to leaving fluid temperature textbox
        Me.leavingFluidTempVCtrl.Validators.Add(leavingFluidTempRangeV)
        Me.leavingFluidTempVCtrl.Validators.Add(leavingFluidTempReqV)
        Me.leavingFluidTempVCtrl.Validators.Add(leavingFluidTempNumV)
    End Sub


    Private Sub compressorVCtrl_Validating(ByVal sender As ValidationControl)
        If sender.ControlToValidate.Text Is Nothing Then
            sender.IsValid = False
            sender.ErrorMessages.Add("Compressor is a required field.")
        ElseIf sender.ControlToValidate.Text = "Choose" Then
            sender.IsValid = False
            sender.ErrorMessages.Add("Compressor is a required field.")
        Else
            sender.IsValid = True
            sender.ErrorMessages.Clear()
        End If
    End Sub


    Private Sub initializeControls()
        cboFluid.SelectedIndex = 0
        cbo_cooling_media.SelectedIndex = 0

        ' changing the index so the textbox will fill w/ Choose
        lboCompressors1.SelectedIndex = 1
        lboCompressors1.SelectedIndex = 0
        lboCompressors2.SelectedIndex = 1
        lboCompressors2.SelectedIndex = 0

        cbo_series.SelectedIndex = 0
    End Sub

    Private Function chiller_model_is_not_selected() As Boolean
        Return grab_model() Is Nothing OrElse grab_model.Length = 0 OrElse grab_model() = "Choose"
    End Function

#End Region

    Sub Open(ByVal rating As ProcessItem)
        loadControls(rating)
    End Sub

    Private Sub btnNewEquipmentPricing_Click() Handles btn_go_to_pricing.Click
        set_enabled_on_acme_related_controls(enabled:=False)
        SaveControls(False, False, False, True)
        set_enabled_on_acme_related_controls(enabled:=True)
    End Sub

    Private Sub cboVolts_SelectedIndexChanged() Handles cboVolts.SelectedIndexChanged
        If loaded Then
            fillCompressorListBoxes()

            cboModels_SelectedIndexChanged()
        End If
    End Sub

    <DebuggerStepThrough()> _
    Private Sub modelPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles modelPanel.Paint

    End Sub

    Private Sub btn_create_report_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_create_report.Click

    End Sub

    Private Sub btn_calculate_page_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_calculate_page.Click

    End Sub

    Private Sub btnNewEquipmentPricing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go_to_pricing.Click

    End Sub

    Private Sub cboSeries_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_series.SelectedIndexChanged

    End Sub

    Private Sub cboModels_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_models.SelectedIndexChanged

    End Sub

    Private Sub txtLeavingFluidTemp_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLeavingFluidTemp.Leave

    End Sub

    Private Sub cbo_cooling_media_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_cooling_media.SelectedIndexChanged

    End Sub

    Private Sub cboRatiCritFlui_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFluid.SelectedIndexChanged

    End Sub

    Private Sub txtGlycolPercentage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGlycolPercentage.TextChanged

    End Sub

    Private Sub cboSystem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSystem.SelectedIndexChanged

    End Sub

    Private Sub cboHertz_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHertz.SelectedIndexChanged

    End Sub

    Private Sub btnGlycolChart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGlycolChart.Click

    End Sub

    Private Sub cboVolts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVolts.SelectedIndexChanged

    End Sub

    Private Sub radCompCirc1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radCircuit1.CheckedChanged

    End Sub

    Private Sub radCompCirc2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radCircuit2.CheckedChanged

    End Sub

    Private Sub cboCondenser1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCondenser1.SelectedIndexChanged

    End Sub

    Private Sub cboCondenser2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCondenser2.SelectedIndexChanged

    End Sub

    Private Sub cboFan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFan.SelectedIndexChanged

    End Sub

    Private Sub cbo_evaporator_model_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_evaporator_model.SelectedIndexChanged

    End Sub

    Private Sub btn_alternate_evaporators_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alternate_evaporators.Click

    End Sub

    <DebuggerStepThrough()> _
    Private Sub controlFactorsPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles controlFactorsPanel.Paint

    End Sub
End Class

'7928