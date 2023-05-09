Option Strict Off
Option Explicit On

Imports System
Imports System.Math
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Validation = rae.validation
Imports Debug = System.Diagnostics.Debug
Imports System.Data
Imports rae.RaeSolutions.Business
Imports Microsoft.VisualBasic
Imports System.Environment
Imports Process = System.Diagnostics.Process
Imports rae.RaeSolutions.Business.Entities
Imports CNull = rae.ConvertNull
Imports System.Collections.Generic
Imports rae.Collections
Imports rae.RaeSolutions.Business.Intelligence
Imports rae.RaeSolutions.Persistence
Imports rae.solutions
Imports rae.solutions.cu_uc_balances
Imports rae.solutions.cu_uc_balances.balance_system
Imports rae.solutions.group
Imports rae.Ui.Validation
Imports rae.validation
Imports rae.solutions.condensing_units
Imports rae.Ui.quickies

''' <summary>Unit cooler and condensing unit balance form.</summary>
Public Class cu_uc_balance_window : Inherits Form
    Public ProcessDeleted As Boolean

    Friend WithEvents separator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents saveAsRevisionMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents saveAsMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents separator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents convertToEquipmentMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents separator1 As System.Windows.Forms.ToolStripSeparator


#Region " Revision Control / Saving Variables..."

    ' Last saved state...
    Public LastSavedProcess As cu_uc_balance_screen_model
    ' Current state before save...
    Public CurrentStateProcess As cu_uc_balance_screen_model
    ' Current displayed state revision 
    ' number reference...
    Private m_Currentrevision As Single = -1
    Private m_Latestrevision As Single = -1

    Friend WithEvents btn_print As System.Windows.Forms.Button
    ''Friend WithEvents condensingUnitDataCollapsableHeader As Rae.Ui.Controls.CollapsableHeader
    ''Friend WithEvents condensingUnitSpecificationsCollapsableHeader As Rae.Ui.Controls.CollapsableHeader
    ''Friend WithEvents unitCoolerSpecificationsHeader As Rae.Ui.Controls.Header
    Friend WithEvents SaveToolStripPanel1 As Rae.RaeSolutions.SaveToolStripPanel
    Public WithEvents txtCoolStuffid As System.Windows.Forms.TextBox
    Public WithEvents btnCoolStuffInvoke As System.Windows.Forms.Button
    Friend WithEvents grpboxload As System.Windows.Forms.GroupBox
    Private WithEvents lblboxloadlinkedto As System.Windows.Forms.Label
    Public WithEvents txtcoolstuffBlName As System.Windows.Forms.TextBox
    Public WithEvents btnremoveboxloadLink As System.Windows.Forms.Button

    Private WithEvents customCondenserEvapCapacityTextBox As System.Windows.Forms.TextBox
    Private WithEvents cmdGetCustomCUCapacity As System.Windows.Forms.Button
    Friend WithEvents pan_static_pressure_1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_static_pressure As System.Windows.Forms.Label
    Friend WithEvents rbo_050_static_1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbo_025_static_1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbo_0_static_1 As System.Windows.Forms.RadioButton
    Friend WithEvents pan_static_pressure_3 As System.Windows.Forms.Panel
    Friend WithEvents rbo_050_static_3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbo_025_static_3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbo_0_static_3 As System.Windows.Forms.RadioButton
    Friend WithEvents pan_static_pressure_2 As System.Windows.Forms.Panel
    Friend WithEvents rbo_050_static_2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbo_025_static_2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbo_0_static_2 As System.Windows.Forms.RadioButton

    ''' <summary>
    ''' The current revision # of process being displayed on this form.
    ''' </summary>
    Public Property CurrentRevision() As Single
        Get
            Return Me.m_Currentrevision
        End Get
        Set(ByVal value As Single)
            Me.m_Currentrevision = value
        End Set
    End Property


    ''' <summary>
    ''' The latest revision # of process being displayed on this form.
    ''' </summary>
    Public Property LatestRevision() As Single
        Get
            Return Me.m_Latestrevision
        End Get
        Set(ByVal value As Single)
            Me.m_Latestrevision = value
        End Set
    End Property

#End Region


#Region " Enumerations"

    Friend Enum PFEIndex As Integer
        LastStateProcess
        CurrentStateProcess
        UnitCooler3
    End Enum

#End Region

    Private presenter As presenter
    Friend WithEvents btn_convert_to_pricing As System.Windows.Forms.Button
    Friend WithEvents cbCondTempOverride As System.Windows.Forms.CheckBox
    Friend WithEvents txt_unit_cooler_DOE_3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_unit_cooler_DOE_2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_unit_cooler_DOE_1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_condensing_unit_DOE_1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_condensing_unit_DOE_3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_condensing_unit_DOE_2 As System.Windows.Forms.TextBox
    Private WithEvents ddlDOE As System.Windows.Forms.ComboBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents lblNoCUResults As System.Windows.Forms.Label
    Friend WithEvents grdCoolerView As DataGridView
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label2 As Label
    ''Friend WithEvents unit_coolers_grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private service As unit_coolers.service

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.isInitializing = False
        presenter = New presenter(Me)
        service = New unit_coolers.service()
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
    Friend WithEvents cboCondensingUnitSeries As System.Windows.Forms.ComboBox
    Private WithEvents runTimeLabel As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents customCondensingUnitDescriptionLabel As System.Windows.Forms.Label
    Private WithEvents roomTemperatureTextBox As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Qty_Required As System.Windows.Forms.Label
    Friend WithEvents lbl_BTUH_Balance As System.Windows.Forms.Label
    Friend WithEvents lbl_Model_Number As System.Windows.Forms.Label
    Friend WithEvents lbl_Room_Temp_Range As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Private WithEvents adjustCapacityForRunTimePanel As System.Windows.Forms.Panel
    Private WithEvents minTemperatureLabel As System.Windows.Forms.Label
    Private WithEvents maxTemperatureLabel As System.Windows.Forms.Label
    Private WithEvents incrementTemperatureLabel As System.Windows.Forms.Label
    Private WithEvents roomsPanel As System.Windows.Forms.Panel
    Friend WithEvents balanceToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents panUnitCoolGrid As System.Windows.Forms.Panel
    Friend WithEvents panRate As System.Windows.Forms.Panel
    Friend WithEvents panBalaGrid As System.Windows.Forms.Panel
    Private WithEvents condensingUnitSeriesLabel As System.Windows.Forms.Label
    Private WithEvents adjustCapacityForRunTimeYesRadioButton As System.Windows.Forms.RadioButton
    Private WithEvents adjustCapacityForRunTimeNoRadioButton As System.Windows.Forms.RadioButton
    Private WithEvents runTimeTextBox As System.Windows.Forms.TextBox
    Private WithEvents adjustCapacityForRunTimeLabel As System.Windows.Forms.Label
    Private WithEvents compressorTypeLabel As System.Windows.Forms.Label
    Private WithEvents compressorTypeComboBox As System.Windows.Forms.ComboBox
    Private WithEvents refrigerantLabel As System.Windows.Forms.Label
    Private WithEvents cbo_refrigerant As System.Windows.Forms.ComboBox
    Private WithEvents numCompressorsPerUnitLabel As System.Windows.Forms.Label
    Private WithEvents numCompressorsPerUnitComboBox As System.Windows.Forms.ComboBox
    Private WithEvents numCircuitsPerUnitComboBox As System.Windows.Forms.ComboBox
    Private WithEvents numCircuitsPerUnitLabel As System.Windows.Forms.Label
    Private WithEvents capacityRequiredLabel As System.Windows.Forms.Label
    Private WithEvents txt_capacity_required As System.Windows.Forms.TextBox
    Private WithEvents altitudeLabel As System.Windows.Forms.Label
    Private WithEvents altitudeTextBox As System.Windows.Forms.TextBox
    Private WithEvents numCondensingUnitsLabel As System.Windows.Forms.Label
    Private WithEvents txt_condensing_unit_quantity As System.Windows.Forms.TextBox
    Private WithEvents suctionTemperatureLabel As System.Windows.Forms.Label
    Private WithEvents txt_suction_temp As System.Windows.Forms.TextBox
    Private WithEvents suctionTemperatureUnitsLabel As System.Windows.Forms.Label
    Private WithEvents numRoomsLabel As System.Windows.Forms.Label
    Private WithEvents oneRoomComboBox As System.Windows.Forms.RadioButton
    Private WithEvents multipleRoomsComboBox As System.Windows.Forms.RadioButton
    Private WithEvents ambientTemperatureLabel As System.Windows.Forms.Label
    Private WithEvents ambientTemperatureTextBox As System.Windows.Forms.TextBox
    Private WithEvents roomTemperatureLabel As System.Windows.Forms.Label
    Private WithEvents txt_max_ambient As System.Windows.Forms.TextBox
    Private WithEvents txt_max_room_temp As System.Windows.Forms.TextBox
    Private WithEvents txt_min_ambient As System.Windows.Forms.TextBox
    Private WithEvents txt_min_room_temp As System.Windows.Forms.TextBox
    Private WithEvents incrementAmbientTemperatureTextBox As System.Windows.Forms.TextBox
    Private WithEvents incrementRoomTemperatureTextBox As System.Windows.Forms.TextBox
    Private WithEvents findCondensingUnitsButton As System.Windows.Forms.Button
    Private WithEvents condensingUnit1DescriptionLabel As System.Windows.Forms.Label
    Private WithEvents condensingUnit2DescriptionLabel As System.Windows.Forms.Label
    Private WithEvents condensingUnit3DescriptionLabel As System.Windows.Forms.Label
    Private WithEvents condensingUnit3RadioButton As System.Windows.Forms.RadioButton
    Private WithEvents condensingUnit2RadioButton As System.Windows.Forms.RadioButton
    Private WithEvents condensingUnit1RadioButton As System.Windows.Forms.RadioButton
    Private WithEvents customCondensingUnitRadioButton As System.Windows.Forms.RadioButton
    Private WithEvents customCondensingUnitTextBox As System.Windows.Forms.TextBox
    Friend WithEvents cbo_unit_cooler_series As System.Windows.Forms.ComboBox
    Friend WithEvents lblUnitCoolerSeries As System.Windows.Forms.Label
    Friend WithEvents lblSuctionLineLoss As System.Windows.Forms.Label
    Friend WithEvents cbo_suction_line_loss As System.Windows.Forms.ComboBox
    Friend WithEvents btn_find_unit_coolers As System.Windows.Forms.Button
    Friend WithEvents txt_unit_cooler_model_1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_unit_cooler_model_2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_unit_cooler_model_3 As System.Windows.Forms.TextBox
    Friend WithEvents rbo_unit_cooler_1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbo_unit_cooler_2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbo_unit_cooler_3 As System.Windows.Forms.RadioButton
    Friend WithEvents btn_clear_unit_cooler_1 As System.Windows.Forms.Button
    Friend WithEvents btn_clear_unit_cooler_2 As System.Windows.Forms.Button
    Friend WithEvents btn_clear_unit_cooler_3 As System.Windows.Forms.Button
    Friend WithEvents txt_balance As System.Windows.Forms.TextBox
    Friend WithEvents btn_balance As System.Windows.Forms.Button
    Friend WithEvents btn_show_report As System.Windows.Forms.Button
    Friend WithEvents lblErrors As System.Windows.Forms.Label
    Private WithEvents txt_condensing_unit_1_capacity As System.Windows.Forms.TextBox
    Private WithEvents txt_condensing_unit_2_capacity As System.Windows.Forms.TextBox
    Private WithEvents txt_condensing_unit_3_capacity As System.Windows.Forms.TextBox
    Private WithEvents capacityRequiredUnitsLabel As System.Windows.Forms.Label
    Private WithEvents altitudeUnitsLabel As System.Windows.Forms.Label
    Private WithEvents customCondenserCapacityPerDegreeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents panFooter As System.Windows.Forms.Panel
    Friend WithEvents picError As System.Windows.Forms.PictureBox
    Friend WithEvents panMain As System.Windows.Forms.Panel
    Friend WithEvents txt_unit_cooler_quantity_1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_unit_cooler_quantity_2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_unit_cooler_quantity_3 As System.Windows.Forms.TextBox
    Private WithEvents condensingUnit2CondenserCapacityTextBox As System.Windows.Forms.TextBox
    Private WithEvents condensingUnit3CondenserCapacityTextBox As System.Windows.Forms.TextBox
    Private WithEvents condensingUnit1CondenserCapacityPerDegreeTextBox As System.Windows.Forms.TextBox
    Private WithEvents ambientTemperatureUnitsLabel As System.Windows.Forms.Label
    Private WithEvents roomTemperatureUnitsLabel As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents runTimeUnitsLabel As System.Windows.Forms.Label
    Friend WithEvents panCondensingUnitDataBody As System.Windows.Forms.Panel
    Friend WithEvents lblCondensingUnitModel As System.Windows.Forms.Label
    Friend WithEvents lblEvaporatorTemperature As System.Windows.Forms.Label
    Friend WithEvents txtCondensingUnitModel1 As System.Windows.Forms.TextBox
    Friend WithEvents txtEvaporatorTemperature1 As System.Windows.Forms.TextBox
    Friend WithEvents lblAirTemperature As System.Windows.Forms.Label
    Friend WithEvents txtAirTemperature1 As System.Windows.Forms.TextBox
    Friend WithEvents lblCondenserTemperature As System.Windows.Forms.Label
    Friend WithEvents txtCondenserTemperature1 As System.Windows.Forms.TextBox
    Friend WithEvents lblCapacity As System.Windows.Forms.Label
    Friend WithEvents txtCapacity1 As System.Windows.Forms.TextBox
    Friend WithEvents lblRunTime As System.Windows.Forms.Label
    Friend WithEvents txtRunTime1 As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitKW1 As System.Windows.Forms.TextBox
    Friend WithEvents lblUnitKW As System.Windows.Forms.Label
    Friend WithEvents lblCondenserCapacity As System.Windows.Forms.Label
    Friend WithEvents txtCondenserCapacity11 As System.Windows.Forms.TextBox
    Friend WithEvents lblUnitAmps230 As System.Windows.Forms.Label
    Friend WithEvents txtUnitAmps2301 As System.Windows.Forms.TextBox
    Friend WithEvents lblUnitAmps460 As System.Windows.Forms.Label
    Friend WithEvents txtUnitAmps4601 As System.Windows.Forms.TextBox
    Friend WithEvents lblUnitEER As System.Windows.Forms.Label
    Friend WithEvents txtUnitEER1 As System.Windows.Forms.TextBox
    Friend WithEvents txtTD1 As System.Windows.Forms.TextBox
    Friend WithEvents lblTD As System.Windows.Forms.Label
    Friend WithEvents lblUnitMCA230 As System.Windows.Forms.Label
    Friend WithEvents txtUnitMCA2301 As System.Windows.Forms.TextBox
    Friend WithEvents lblUnitMCA460 As System.Windows.Forms.Label
    Friend WithEvents txtUnitMCA4601 As System.Windows.Forms.TextBox
    Friend WithEvents lblDimensions As System.Windows.Forms.Label
    Friend WithEvents txtDimensions1 As System.Windows.Forms.TextBox
    Friend WithEvents lblBaseListPrice As System.Windows.Forms.Label
    Friend WithEvents txtBaseListPrice1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtBaseListPrice2 As System.Windows.Forms.TextBox
    Friend WithEvents txtDimensions2 As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitMCA4602 As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitMCA2302 As System.Windows.Forms.TextBox
    Friend WithEvents txtTD2 As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitEER2 As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitAmps4602 As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitAmps2302 As System.Windows.Forms.TextBox
    Friend WithEvents txtCondenserCapacity22 As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitKW2 As System.Windows.Forms.TextBox
    Friend WithEvents txtRunTime2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCapacity2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCondenserTemperature2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAirTemperature2 As System.Windows.Forms.TextBox
    Friend WithEvents txtEvaporatorTemperature2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCondensingUnitModel2 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtBaseListPrice3 As System.Windows.Forms.TextBox
    Friend WithEvents txtDimensions3 As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitMCA4603 As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitMCA2303 As System.Windows.Forms.TextBox
    Friend WithEvents txtTD3 As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitEER3 As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitAmps4603 As System.Windows.Forms.TextBox
    Friend WithEvents txtCondenserCapacity33 As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitKW3 As System.Windows.Forms.TextBox
    Friend WithEvents txtRunTime3 As System.Windows.Forms.TextBox
    Friend WithEvents txtCapacity3 As System.Windows.Forms.TextBox
    Friend WithEvents txtCondenserTemperature3 As System.Windows.Forms.TextBox
    Friend WithEvents txtAirTemperature3 As System.Windows.Forms.TextBox
    Friend WithEvents txtEvaporatorTemperature3 As System.Windows.Forms.TextBox
    Friend WithEvents txtCondensingUnitModel3 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtUnitAmps2303 As System.Windows.Forms.TextBox
    Friend WithEvents panCondensingUnitSpecBody As System.Windows.Forms.Panel
    Friend WithEvents panUnitCoolerSpec As System.Windows.Forms.Panel
    Friend WithEvents lblUCCapacity As System.Windows.Forms.Label
    Friend WithEvents txt_unit_cooler_capacity_3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_unit_cooler_capacity_2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_unit_cooler_capacity_1 As System.Windows.Forms.TextBox
    Friend WithEvents lblEvaporatorCapacity As System.Windows.Forms.Label
    Friend WithEvents txt_evaporator_capacity_per_degree_1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_evaporator_capacity_per_degree_2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_custom_evaporator_capacity As System.Windows.Forms.TextBox
    Friend WithEvents txt_custom_uc_quantity As System.Windows.Forms.TextBox
    Friend WithEvents txt_custom_uc_capacity As System.Windows.Forms.TextBox
    Friend WithEvents txt_custom_uc_model As System.Windows.Forms.TextBox
    Friend WithEvents chk_custom_unit_cooler As System.Windows.Forms.CheckBox
    Friend WithEvents txt_evaporator_capacity_per_degree_3 As System.Windows.Forms.TextBox
    Friend WithEvents chk_unit_cooler_override As System.Windows.Forms.CheckBox
    Friend WithEvents balanceErrorProvider As System.Windows.Forms.ErrorProvider
    Private WithEvents condenserCapacityPerDegreeLabel As System.Windows.Forms.Label
    Friend WithEvents status_bar As System.Windows.Forms.Label
    Friend WithEvents balanceMenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents FileMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents printMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents saveMenuItem As System.Windows.Forms.ToolStripMenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cu_uc_balance_window))
        Me.cmdGetCustomCUCapacity = New System.Windows.Forms.Button()
        Me.condensingUnitSeriesLabel = New System.Windows.Forms.Label()
        Me.capacityRequiredLabel = New System.Windows.Forms.Label()
        Me.cboCondensingUnitSeries = New System.Windows.Forms.ComboBox()
        Me.txt_capacity_required = New System.Windows.Forms.TextBox()
        Me.runTimeLabel = New System.Windows.Forms.Label()
        Me.adjustCapacityForRunTimeLabel = New System.Windows.Forms.Label()
        Me.runTimeTextBox = New System.Windows.Forms.TextBox()
        Me.adjustCapacityForRunTimeYesRadioButton = New System.Windows.Forms.RadioButton()
        Me.adjustCapacityForRunTimeNoRadioButton = New System.Windows.Forms.RadioButton()
        Me.ambientTemperatureLabel = New System.Windows.Forms.Label()
        Me.ambientTemperatureTextBox = New System.Windows.Forms.TextBox()
        Me.suctionTemperatureLabel = New System.Windows.Forms.Label()
        Me.txt_suction_temp = New System.Windows.Forms.TextBox()
        Me.suctionTemperatureUnitsLabel = New System.Windows.Forms.Label()
        Me.refrigerantLabel = New System.Windows.Forms.Label()
        Me.cbo_refrigerant = New System.Windows.Forms.ComboBox()
        Me.compressorTypeLabel = New System.Windows.Forms.Label()
        Me.compressorTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.numCompressorsPerUnitLabel = New System.Windows.Forms.Label()
        Me.numCompressorsPerUnitComboBox = New System.Windows.Forms.ComboBox()
        Me.numCircuitsPerUnitComboBox = New System.Windows.Forms.ComboBox()
        Me.numCircuitsPerUnitLabel = New System.Windows.Forms.Label()
        Me.altitudeLabel = New System.Windows.Forms.Label()
        Me.altitudeTextBox = New System.Windows.Forms.TextBox()
        Me.txt_condensing_unit_quantity = New System.Windows.Forms.TextBox()
        Me.numCondensingUnitsLabel = New System.Windows.Forms.Label()
        Me.findCondensingUnitsButton = New System.Windows.Forms.Button()
        Me.condensingUnit1DescriptionLabel = New System.Windows.Forms.Label()
        Me.condensingUnit2DescriptionLabel = New System.Windows.Forms.Label()
        Me.txt_condensing_unit_1_capacity = New System.Windows.Forms.TextBox()
        Me.condensingUnit3DescriptionLabel = New System.Windows.Forms.Label()
        Me.txt_condensing_unit_2_capacity = New System.Windows.Forms.TextBox()
        Me.txt_condensing_unit_3_capacity = New System.Windows.Forms.TextBox()
        Me.condensingUnit3RadioButton = New System.Windows.Forms.RadioButton()
        Me.condensingUnit2RadioButton = New System.Windows.Forms.RadioButton()
        Me.condensingUnit1RadioButton = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblNoCUResults = New System.Windows.Forms.Label()
        Me.condensingUnit2CondenserCapacityTextBox = New System.Windows.Forms.TextBox()
        Me.condensingUnit3CondenserCapacityTextBox = New System.Windows.Forms.TextBox()
        Me.customCondensingUnitTextBox = New System.Windows.Forms.TextBox()
        Me.customCondenserCapacityPerDegreeTextBox = New System.Windows.Forms.TextBox()
        Me.condensingUnit1CondenserCapacityPerDegreeTextBox = New System.Windows.Forms.TextBox()
        Me.customCondensingUnitRadioButton = New System.Windows.Forms.RadioButton()
        Me.customCondensingUnitDescriptionLabel = New System.Windows.Forms.Label()
        Me.condenserCapacityPerDegreeLabel = New System.Windows.Forms.Label()
        Me.customCondenserEvapCapacityTextBox = New System.Windows.Forms.TextBox()
        Me.lblErrors = New System.Windows.Forms.Label()
        Me.cbo_unit_cooler_series = New System.Windows.Forms.ComboBox()
        Me.lblUnitCoolerSeries = New System.Windows.Forms.Label()
        Me.lblSuctionLineLoss = New System.Windows.Forms.Label()
        Me.cbo_suction_line_loss = New System.Windows.Forms.ComboBox()
        Me.roomTemperatureTextBox = New System.Windows.Forms.TextBox()
        Me.roomTemperatureLabel = New System.Windows.Forms.Label()
        Me.btn_find_unit_coolers = New System.Windows.Forms.Button()
        Me.txt_unit_cooler_quantity_1 = New System.Windows.Forms.TextBox()
        Me.txt_unit_cooler_quantity_2 = New System.Windows.Forms.TextBox()
        Me.txt_unit_cooler_quantity_3 = New System.Windows.Forms.TextBox()
        Me.lbl_Qty_Required = New System.Windows.Forms.Label()
        Me.txt_balance = New System.Windows.Forms.TextBox()
        Me.lbl_BTUH_Balance = New System.Windows.Forms.Label()
        Me.lbl_Model_Number = New System.Windows.Forms.Label()
        Me.txt_unit_cooler_model_1 = New System.Windows.Forms.TextBox()
        Me.txt_unit_cooler_model_2 = New System.Windows.Forms.TextBox()
        Me.txt_unit_cooler_model_3 = New System.Windows.Forms.TextBox()
        Me.rbo_unit_cooler_1 = New System.Windows.Forms.RadioButton()
        Me.rbo_unit_cooler_2 = New System.Windows.Forms.RadioButton()
        Me.rbo_unit_cooler_3 = New System.Windows.Forms.RadioButton()
        Me.lbl_Room_Temp_Range = New System.Windows.Forms.Label()
        Me.btn_balance = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btn_clear_unit_cooler_1 = New System.Windows.Forms.Button()
        Me.btn_clear_unit_cooler_2 = New System.Windows.Forms.Button()
        Me.btn_clear_unit_cooler_3 = New System.Windows.Forms.Button()
        Me.btn_show_report = New System.Windows.Forms.Button()
        Me.numRoomsLabel = New System.Windows.Forms.Label()
        Me.adjustCapacityForRunTimePanel = New System.Windows.Forms.Panel()
        Me.oneRoomComboBox = New System.Windows.Forms.RadioButton()
        Me.multipleRoomsComboBox = New System.Windows.Forms.RadioButton()
        Me.minTemperatureLabel = New System.Windows.Forms.Label()
        Me.maxTemperatureLabel = New System.Windows.Forms.Label()
        Me.txt_max_ambient = New System.Windows.Forms.TextBox()
        Me.txt_max_room_temp = New System.Windows.Forms.TextBox()
        Me.txt_min_ambient = New System.Windows.Forms.TextBox()
        Me.txt_min_room_temp = New System.Windows.Forms.TextBox()
        Me.incrementTemperatureLabel = New System.Windows.Forms.Label()
        Me.incrementAmbientTemperatureTextBox = New System.Windows.Forms.TextBox()
        Me.incrementRoomTemperatureTextBox = New System.Windows.Forms.TextBox()
        Me.roomsPanel = New System.Windows.Forms.Panel()
        Me.roomTemperatureUnitsLabel = New System.Windows.Forms.Label()
        Me.ambientTemperatureUnitsLabel = New System.Windows.Forms.Label()
        Me.balanceToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.picError = New System.Windows.Forms.PictureBox()
        Me.panCondensingUnitSpecBody = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ddlDOE = New System.Windows.Forms.ComboBox()
        Me.cbCondTempOverride = New System.Windows.Forms.CheckBox()
        Me.grpboxload = New System.Windows.Forms.GroupBox()
        Me.btnremoveboxloadLink = New System.Windows.Forms.Button()
        Me.lblboxloadlinkedto = New System.Windows.Forms.Label()
        Me.txtcoolstuffBlName = New System.Windows.Forms.TextBox()
        Me.btnCoolStuffInvoke = New System.Windows.Forms.Button()
        Me.txtCoolStuffid = New System.Windows.Forms.TextBox()
        Me.runTimeUnitsLabel = New System.Windows.Forms.Label()
        Me.altitudeUnitsLabel = New System.Windows.Forms.Label()
        Me.capacityRequiredUnitsLabel = New System.Windows.Forms.Label()
        Me.balanceMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.separator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.saveMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.saveAsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.saveAsRevisionMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.separator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.convertToEquipmentMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.separator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.printMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.panUnitCoolerSpec = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.panUnitCoolGrid = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.chk_unit_cooler_override = New System.Windows.Forms.CheckBox()
        Me.grdCoolerView = New System.Windows.Forms.DataGridView()
        Me.panRate = New System.Windows.Forms.Panel()
        Me.txt_unit_cooler_DOE_3 = New System.Windows.Forms.TextBox()
        Me.txt_unit_cooler_DOE_2 = New System.Windows.Forms.TextBox()
        Me.txt_unit_cooler_DOE_1 = New System.Windows.Forms.TextBox()
        Me.pan_static_pressure_3 = New System.Windows.Forms.Panel()
        Me.rbo_050_static_3 = New System.Windows.Forms.RadioButton()
        Me.rbo_025_static_3 = New System.Windows.Forms.RadioButton()
        Me.rbo_0_static_3 = New System.Windows.Forms.RadioButton()
        Me.pan_static_pressure_2 = New System.Windows.Forms.Panel()
        Me.rbo_050_static_2 = New System.Windows.Forms.RadioButton()
        Me.rbo_025_static_2 = New System.Windows.Forms.RadioButton()
        Me.rbo_0_static_2 = New System.Windows.Forms.RadioButton()
        Me.lbl_static_pressure = New System.Windows.Forms.Label()
        Me.pan_static_pressure_1 = New System.Windows.Forms.Panel()
        Me.rbo_050_static_1 = New System.Windows.Forms.RadioButton()
        Me.rbo_025_static_1 = New System.Windows.Forms.RadioButton()
        Me.rbo_0_static_1 = New System.Windows.Forms.RadioButton()
        Me.lblEvaporatorCapacity = New System.Windows.Forms.Label()
        Me.txt_custom_uc_model = New System.Windows.Forms.TextBox()
        Me.txt_custom_uc_capacity = New System.Windows.Forms.TextBox()
        Me.txt_custom_uc_quantity = New System.Windows.Forms.TextBox()
        Me.txt_evaporator_capacity_per_degree_3 = New System.Windows.Forms.TextBox()
        Me.txt_custom_evaporator_capacity = New System.Windows.Forms.TextBox()
        Me.txt_evaporator_capacity_per_degree_2 = New System.Windows.Forms.TextBox()
        Me.txt_evaporator_capacity_per_degree_1 = New System.Windows.Forms.TextBox()
        Me.txt_unit_cooler_capacity_3 = New System.Windows.Forms.TextBox()
        Me.txt_unit_cooler_capacity_2 = New System.Windows.Forms.TextBox()
        Me.txt_unit_cooler_capacity_1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblUCCapacity = New System.Windows.Forms.Label()
        Me.chk_custom_unit_cooler = New System.Windows.Forms.CheckBox()
        Me.txt_condensing_unit_DOE_1 = New System.Windows.Forms.TextBox()
        Me.panBalaGrid = New System.Windows.Forms.Panel()
        Me.btn_convert_to_pricing = New System.Windows.Forms.Button()
        Me.btn_print = New System.Windows.Forms.Button()
        Me.panFooter = New System.Windows.Forms.Panel()
        Me.panMain = New System.Windows.Forms.Panel()
        Me.panCondensingUnitDataBody = New System.Windows.Forms.Panel()
        Me.txt_condensing_unit_DOE_3 = New System.Windows.Forms.TextBox()
        Me.txt_condensing_unit_DOE_2 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtBaseListPrice3 = New System.Windows.Forms.TextBox()
        Me.txtDimensions3 = New System.Windows.Forms.TextBox()
        Me.txtUnitMCA4603 = New System.Windows.Forms.TextBox()
        Me.txtUnitMCA2303 = New System.Windows.Forms.TextBox()
        Me.txtTD3 = New System.Windows.Forms.TextBox()
        Me.txtUnitEER3 = New System.Windows.Forms.TextBox()
        Me.txtUnitAmps4603 = New System.Windows.Forms.TextBox()
        Me.txtUnitAmps2303 = New System.Windows.Forms.TextBox()
        Me.txtCondenserCapacity33 = New System.Windows.Forms.TextBox()
        Me.txtUnitKW3 = New System.Windows.Forms.TextBox()
        Me.txtRunTime3 = New System.Windows.Forms.TextBox()
        Me.txtCapacity3 = New System.Windows.Forms.TextBox()
        Me.txtCondenserTemperature3 = New System.Windows.Forms.TextBox()
        Me.txtAirTemperature3 = New System.Windows.Forms.TextBox()
        Me.txtEvaporatorTemperature3 = New System.Windows.Forms.TextBox()
        Me.txtCondensingUnitModel3 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtBaseListPrice2 = New System.Windows.Forms.TextBox()
        Me.txtDimensions2 = New System.Windows.Forms.TextBox()
        Me.txtUnitMCA4602 = New System.Windows.Forms.TextBox()
        Me.txtUnitMCA2302 = New System.Windows.Forms.TextBox()
        Me.txtTD2 = New System.Windows.Forms.TextBox()
        Me.txtUnitEER2 = New System.Windows.Forms.TextBox()
        Me.txtUnitAmps4602 = New System.Windows.Forms.TextBox()
        Me.txtUnitAmps2302 = New System.Windows.Forms.TextBox()
        Me.txtCondenserCapacity22 = New System.Windows.Forms.TextBox()
        Me.txtUnitKW2 = New System.Windows.Forms.TextBox()
        Me.txtRunTime2 = New System.Windows.Forms.TextBox()
        Me.txtCapacity2 = New System.Windows.Forms.TextBox()
        Me.txtCondenserTemperature2 = New System.Windows.Forms.TextBox()
        Me.txtAirTemperature2 = New System.Windows.Forms.TextBox()
        Me.txtEvaporatorTemperature2 = New System.Windows.Forms.TextBox()
        Me.txtCondensingUnitModel2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBaseListPrice1 = New System.Windows.Forms.TextBox()
        Me.lblBaseListPrice = New System.Windows.Forms.Label()
        Me.txtDimensions1 = New System.Windows.Forms.TextBox()
        Me.lblDimensions = New System.Windows.Forms.Label()
        Me.txtUnitMCA4601 = New System.Windows.Forms.TextBox()
        Me.lblUnitMCA460 = New System.Windows.Forms.Label()
        Me.txtUnitMCA2301 = New System.Windows.Forms.TextBox()
        Me.lblUnitMCA230 = New System.Windows.Forms.Label()
        Me.lblTD = New System.Windows.Forms.Label()
        Me.txtTD1 = New System.Windows.Forms.TextBox()
        Me.txtUnitEER1 = New System.Windows.Forms.TextBox()
        Me.lblUnitEER = New System.Windows.Forms.Label()
        Me.txtUnitAmps4601 = New System.Windows.Forms.TextBox()
        Me.lblUnitAmps460 = New System.Windows.Forms.Label()
        Me.txtUnitAmps2301 = New System.Windows.Forms.TextBox()
        Me.lblUnitAmps230 = New System.Windows.Forms.Label()
        Me.txtCondenserCapacity11 = New System.Windows.Forms.TextBox()
        Me.lblCondenserCapacity = New System.Windows.Forms.Label()
        Me.lblUnitKW = New System.Windows.Forms.Label()
        Me.txtUnitKW1 = New System.Windows.Forms.TextBox()
        Me.txtRunTime1 = New System.Windows.Forms.TextBox()
        Me.lblRunTime = New System.Windows.Forms.Label()
        Me.txtCapacity1 = New System.Windows.Forms.TextBox()
        Me.lblCapacity = New System.Windows.Forms.Label()
        Me.txtCondenserTemperature1 = New System.Windows.Forms.TextBox()
        Me.lblCondenserTemperature = New System.Windows.Forms.Label()
        Me.txtAirTemperature1 = New System.Windows.Forms.TextBox()
        Me.lblAirTemperature = New System.Windows.Forms.Label()
        Me.txtEvaporatorTemperature1 = New System.Windows.Forms.TextBox()
        Me.lblEvaporatorTemperature = New System.Windows.Forms.Label()
        Me.txtCondensingUnitModel1 = New System.Windows.Forms.TextBox()
        Me.lblCondensingUnitModel = New System.Windows.Forms.Label()
        Me.balanceErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.status_bar = New System.Windows.Forms.Label()
        Me.SaveToolStripPanel1 = New Rae.RaeSolutions.SaveToolStripPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.adjustCapacityForRunTimePanel.SuspendLayout()
        Me.roomsPanel.SuspendLayout()
        CType(Me.picError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panCondensingUnitSpecBody.SuspendLayout()
        Me.grpboxload.SuspendLayout()
        Me.balanceMenuStrip.SuspendLayout()
        Me.panUnitCoolerSpec.SuspendLayout()
        Me.panUnitCoolGrid.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdCoolerView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panRate.SuspendLayout()
        Me.pan_static_pressure_3.SuspendLayout()
        Me.pan_static_pressure_2.SuspendLayout()
        Me.pan_static_pressure_1.SuspendLayout()
        Me.panBalaGrid.SuspendLayout()
        Me.panFooter.SuspendLayout()
        Me.panMain.SuspendLayout()
        Me.panCondensingUnitDataBody.SuspendLayout()
        CType(Me.balanceErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdGetCustomCUCapacity
        '
        Me.cmdGetCustomCUCapacity.BackColor = System.Drawing.Color.White
        Me.cmdGetCustomCUCapacity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGetCustomCUCapacity.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGetCustomCUCapacity.ForeColor = System.Drawing.Color.Navy
        Me.cmdGetCustomCUCapacity.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cmdGetCustomCUCapacity.Location = New System.Drawing.Point(426, 111)
        Me.cmdGetCustomCUCapacity.Name = "cmdGetCustomCUCapacity"
        Me.cmdGetCustomCUCapacity.Size = New System.Drawing.Size(99, 26)
        Me.cmdGetCustomCUCapacity.TabIndex = 105
        Me.cmdGetCustomCUCapacity.Text = "Get Est. Capacity"
        Me.cmdGetCustomCUCapacity.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cmdGetCustomCUCapacity.UseVisualStyleBackColor = False
        Me.cmdGetCustomCUCapacity.Visible = False
        '
        'condensingUnitSeriesLabel
        '
        Me.condensingUnitSeriesLabel.BackColor = System.Drawing.Color.Transparent
        Me.condensingUnitSeriesLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.condensingUnitSeriesLabel.Location = New System.Drawing.Point(68, 9)
        Me.condensingUnitSeriesLabel.Name = "condensingUnitSeriesLabel"
        Me.condensingUnitSeriesLabel.Size = New System.Drawing.Size(155, 21)
        Me.condensingUnitSeriesLabel.TabIndex = 1
        Me.condensingUnitSeriesLabel.Text = "Condensing unit series"
        Me.condensingUnitSeriesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'capacityRequiredLabel
        '
        Me.capacityRequiredLabel.BackColor = System.Drawing.Color.Transparent
        Me.capacityRequiredLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.capacityRequiredLabel.Location = New System.Drawing.Point(68, 171)
        Me.capacityRequiredLabel.Name = "capacityRequiredLabel"
        Me.capacityRequiredLabel.Size = New System.Drawing.Size(155, 21)
        Me.capacityRequiredLabel.TabIndex = 2
        Me.capacityRequiredLabel.Text = "Total capacity required"
        Me.capacityRequiredLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCondensingUnitSeries
        '
        Me.cboCondensingUnitSeries.BackColor = System.Drawing.Color.White
        Me.cboCondensingUnitSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCondensingUnitSeries.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCondensingUnitSeries.Items.AddRange(New Object() {"DS", "DD", "DM", "LUO", "LUI", "NDB", "NSB", "NSC", "NDC", "NMB", "NMC", "NSF", "NDF", "BLU-L", "BLU-B"})
        Me.cboCondensingUnitSeries.Location = New System.Drawing.Point(231, 9)
        Me.cboCondensingUnitSeries.Name = "cboCondensingUnitSeries"
        Me.cboCondensingUnitSeries.Size = New System.Drawing.Size(85, 21)
        Me.cboCondensingUnitSeries.TabIndex = 1
        '
        'txt_capacity_required
        '
        Me.txt_capacity_required.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_capacity_required.Location = New System.Drawing.Point(231, 171)
        Me.txt_capacity_required.Name = "txt_capacity_required"
        Me.txt_capacity_required.Size = New System.Drawing.Size(85, 21)
        Me.txt_capacity_required.TabIndex = 9
        Me.txt_capacity_required.Text = "28000"
        '
        'runTimeLabel
        '
        Me.runTimeLabel.BackColor = System.Drawing.Color.Transparent
        Me.runTimeLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.runTimeLabel.Location = New System.Drawing.Point(407, 36)
        Me.runTimeLabel.Name = "runTimeLabel"
        Me.runTimeLabel.Size = New System.Drawing.Size(66, 21)
        Me.runTimeLabel.TabIndex = 5
        Me.runTimeLabel.Text = "Run time"
        Me.runTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'adjustCapacityForRunTimeLabel
        '
        Me.adjustCapacityForRunTimeLabel.BackColor = System.Drawing.Color.Transparent
        Me.adjustCapacityForRunTimeLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.adjustCapacityForRunTimeLabel.Location = New System.Drawing.Point(68, 36)
        Me.adjustCapacityForRunTimeLabel.Name = "adjustCapacityForRunTimeLabel"
        Me.adjustCapacityForRunTimeLabel.Size = New System.Drawing.Size(155, 21)
        Me.adjustCapacityForRunTimeLabel.TabIndex = 6
        Me.adjustCapacityForRunTimeLabel.Text = "Adjust capacity for run time"
        Me.adjustCapacityForRunTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'runTimeTextBox
        '
        Me.runTimeTextBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.runTimeTextBox.Location = New System.Drawing.Point(479, 36)
        Me.runTimeTextBox.Name = "runTimeTextBox"
        Me.runTimeTextBox.Size = New System.Drawing.Size(47, 21)
        Me.runTimeTextBox.TabIndex = 4
        Me.runTimeTextBox.Text = "16"
        '
        'adjustCapacityForRunTimeYesRadioButton
        '
        Me.adjustCapacityForRunTimeYesRadioButton.BackColor = System.Drawing.SystemColors.Control
        Me.adjustCapacityForRunTimeYesRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.adjustCapacityForRunTimeYesRadioButton.Location = New System.Drawing.Point(0, 0)
        Me.adjustCapacityForRunTimeYesRadioButton.Name = "adjustCapacityForRunTimeYesRadioButton"
        Me.adjustCapacityForRunTimeYesRadioButton.Size = New System.Drawing.Size(66, 21)
        Me.adjustCapacityForRunTimeYesRadioButton.TabIndex = 2
        Me.adjustCapacityForRunTimeYesRadioButton.Text = "Yes"
        Me.adjustCapacityForRunTimeYesRadioButton.UseVisualStyleBackColor = False
        '
        'adjustCapacityForRunTimeNoRadioButton
        '
        Me.adjustCapacityForRunTimeNoRadioButton.BackColor = System.Drawing.SystemColors.Control
        Me.adjustCapacityForRunTimeNoRadioButton.Checked = True
        Me.adjustCapacityForRunTimeNoRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.adjustCapacityForRunTimeNoRadioButton.Location = New System.Drawing.Point(61, 0)
        Me.adjustCapacityForRunTimeNoRadioButton.Name = "adjustCapacityForRunTimeNoRadioButton"
        Me.adjustCapacityForRunTimeNoRadioButton.Size = New System.Drawing.Size(55, 21)
        Me.adjustCapacityForRunTimeNoRadioButton.TabIndex = 3
        Me.adjustCapacityForRunTimeNoRadioButton.TabStop = True
        Me.adjustCapacityForRunTimeNoRadioButton.Text = "No"
        Me.adjustCapacityForRunTimeNoRadioButton.UseVisualStyleBackColor = False
        '
        'ambientTemperatureLabel
        '
        Me.ambientTemperatureLabel.BackColor = System.Drawing.Color.Transparent
        Me.ambientTemperatureLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ambientTemperatureLabel.Location = New System.Drawing.Point(60, 33)
        Me.ambientTemperatureLabel.Name = "ambientTemperatureLabel"
        Me.ambientTemperatureLabel.Size = New System.Drawing.Size(158, 21)
        Me.ambientTemperatureLabel.TabIndex = 11
        Me.ambientTemperatureLabel.Text = "Ambient temperature"
        Me.ambientTemperatureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ambientTemperatureTextBox
        '
        Me.ambientTemperatureTextBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ambientTemperatureTextBox.Location = New System.Drawing.Point(224, 33)
        Me.ambientTemperatureTextBox.Name = "ambientTemperatureTextBox"
        Me.ambientTemperatureTextBox.Size = New System.Drawing.Size(85, 21)
        Me.ambientTemperatureTextBox.TabIndex = 15
        Me.ambientTemperatureTextBox.Text = "95"
        '
        'suctionTemperatureLabel
        '
        Me.suctionTemperatureLabel.BackColor = System.Drawing.Color.Transparent
        Me.suctionTemperatureLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.suctionTemperatureLabel.Location = New System.Drawing.Point(68, 252)
        Me.suctionTemperatureLabel.Name = "suctionTemperatureLabel"
        Me.suctionTemperatureLabel.Size = New System.Drawing.Size(155, 21)
        Me.suctionTemperatureLabel.TabIndex = 13
        Me.suctionTemperatureLabel.Text = "Saturated suction temp."
        Me.suctionTemperatureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_suction_temp
        '
        Me.txt_suction_temp.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_suction_temp.Location = New System.Drawing.Point(231, 252)
        Me.txt_suction_temp.Name = "txt_suction_temp"
        Me.txt_suction_temp.Size = New System.Drawing.Size(85, 21)
        Me.txt_suction_temp.TabIndex = 12
        Me.txt_suction_temp.Text = "35"
        '
        'suctionTemperatureUnitsLabel
        '
        Me.suctionTemperatureUnitsLabel.BackColor = System.Drawing.Color.Transparent
        Me.suctionTemperatureUnitsLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.suctionTemperatureUnitsLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.suctionTemperatureUnitsLabel.Location = New System.Drawing.Point(322, 254)
        Me.suctionTemperatureUnitsLabel.Name = "suctionTemperatureUnitsLabel"
        Me.suctionTemperatureUnitsLabel.Size = New System.Drawing.Size(130, 21)
        Me.suctionTemperatureUnitsLabel.TabIndex = 15
        Me.suctionTemperatureUnitsLabel.Text = "range -40 to +55 [°F]"
        Me.suctionTemperatureUnitsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'refrigerantLabel
        '
        Me.refrigerantLabel.BackColor = System.Drawing.Color.Transparent
        Me.refrigerantLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.refrigerantLabel.Location = New System.Drawing.Point(68, 90)
        Me.refrigerantLabel.Name = "refrigerantLabel"
        Me.refrigerantLabel.Size = New System.Drawing.Size(155, 21)
        Me.refrigerantLabel.TabIndex = 16
        Me.refrigerantLabel.Text = "Refrigerant"
        Me.refrigerantLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbo_refrigerant
        '
        Me.cbo_refrigerant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_refrigerant.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_refrigerant.Items.AddRange(New Object() {"R507", "R22", "R404a", "R134a", "R407a", "R407c", "R407f", "R448a", "R449a"})
        Me.cbo_refrigerant.Location = New System.Drawing.Point(231, 90)
        Me.cbo_refrigerant.Name = "cbo_refrigerant"
        Me.cbo_refrigerant.Size = New System.Drawing.Size(85, 21)
        Me.cbo_refrigerant.TabIndex = 6
        '
        'compressorTypeLabel
        '
        Me.compressorTypeLabel.BackColor = System.Drawing.Color.Transparent
        Me.compressorTypeLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.compressorTypeLabel.Location = New System.Drawing.Point(68, 63)
        Me.compressorTypeLabel.Name = "compressorTypeLabel"
        Me.compressorTypeLabel.Size = New System.Drawing.Size(155, 21)
        Me.compressorTypeLabel.TabIndex = 18
        Me.compressorTypeLabel.Text = "Compressor type"
        Me.compressorTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'compressorTypeComboBox
        '
        Me.compressorTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.compressorTypeComboBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.compressorTypeComboBox.Items.AddRange(New Object() {"Best-optimized", "Scroll", "Semi-Hermetic Discus", "Semi-Hermetic Reed"})
        Me.compressorTypeComboBox.Location = New System.Drawing.Point(231, 63)
        Me.compressorTypeComboBox.Name = "compressorTypeComboBox"
        Me.compressorTypeComboBox.Size = New System.Drawing.Size(163, 21)
        Me.compressorTypeComboBox.TabIndex = 5
        '
        'numCompressorsPerUnitLabel
        '
        Me.numCompressorsPerUnitLabel.BackColor = System.Drawing.Color.Transparent
        Me.numCompressorsPerUnitLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numCompressorsPerUnitLabel.Location = New System.Drawing.Point(68, 117)
        Me.numCompressorsPerUnitLabel.Name = "numCompressorsPerUnitLabel"
        Me.numCompressorsPerUnitLabel.Size = New System.Drawing.Size(155, 21)
        Me.numCompressorsPerUnitLabel.TabIndex = 20
        Me.numCompressorsPerUnitLabel.Text = "Compressors per unit"
        Me.numCompressorsPerUnitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numCompressorsPerUnitComboBox
        '
        Me.numCompressorsPerUnitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.numCompressorsPerUnitComboBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numCompressorsPerUnitComboBox.Items.AddRange(New Object() {"ALL", "1", "2", "3", "4"})
        Me.numCompressorsPerUnitComboBox.Location = New System.Drawing.Point(231, 117)
        Me.numCompressorsPerUnitComboBox.Name = "numCompressorsPerUnitComboBox"
        Me.numCompressorsPerUnitComboBox.Size = New System.Drawing.Size(85, 21)
        Me.numCompressorsPerUnitComboBox.TabIndex = 7
        '
        'numCircuitsPerUnitComboBox
        '
        Me.numCircuitsPerUnitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.numCircuitsPerUnitComboBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numCircuitsPerUnitComboBox.Items.AddRange(New Object() {"ALL", "1", "2", "3", "4"})
        Me.numCircuitsPerUnitComboBox.Location = New System.Drawing.Point(231, 144)
        Me.numCircuitsPerUnitComboBox.Name = "numCircuitsPerUnitComboBox"
        Me.numCircuitsPerUnitComboBox.Size = New System.Drawing.Size(85, 21)
        Me.numCircuitsPerUnitComboBox.TabIndex = 8
        '
        'numCircuitsPerUnitLabel
        '
        Me.numCircuitsPerUnitLabel.BackColor = System.Drawing.Color.Transparent
        Me.numCircuitsPerUnitLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numCircuitsPerUnitLabel.Location = New System.Drawing.Point(68, 144)
        Me.numCircuitsPerUnitLabel.Name = "numCircuitsPerUnitLabel"
        Me.numCircuitsPerUnitLabel.Size = New System.Drawing.Size(155, 21)
        Me.numCircuitsPerUnitLabel.TabIndex = 23
        Me.numCircuitsPerUnitLabel.Text = "Circuits per unit"
        Me.numCircuitsPerUnitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'altitudeLabel
        '
        Me.altitudeLabel.BackColor = System.Drawing.Color.Transparent
        Me.altitudeLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.altitudeLabel.Location = New System.Drawing.Point(68, 198)
        Me.altitudeLabel.Name = "altitudeLabel"
        Me.altitudeLabel.Size = New System.Drawing.Size(155, 21)
        Me.altitudeLabel.TabIndex = 24
        Me.altitudeLabel.Text = "Altitude"
        Me.altitudeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'altitudeTextBox
        '
        Me.altitudeTextBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.altitudeTextBox.Location = New System.Drawing.Point(231, 198)
        Me.altitudeTextBox.Name = "altitudeTextBox"
        Me.altitudeTextBox.Size = New System.Drawing.Size(85, 21)
        Me.altitudeTextBox.TabIndex = 10
        Me.altitudeTextBox.Text = "0"
        '
        'txt_condensing_unit_quantity
        '
        Me.txt_condensing_unit_quantity.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_condensing_unit_quantity.Location = New System.Drawing.Point(231, 225)
        Me.txt_condensing_unit_quantity.Name = "txt_condensing_unit_quantity"
        Me.txt_condensing_unit_quantity.Size = New System.Drawing.Size(85, 21)
        Me.txt_condensing_unit_quantity.TabIndex = 11
        Me.txt_condensing_unit_quantity.Text = "1"
        '
        'numCondensingUnitsLabel
        '
        Me.numCondensingUnitsLabel.BackColor = System.Drawing.Color.Transparent
        Me.numCondensingUnitsLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numCondensingUnitsLabel.Location = New System.Drawing.Point(68, 225)
        Me.numCondensingUnitsLabel.Name = "numCondensingUnitsLabel"
        Me.numCondensingUnitsLabel.Size = New System.Drawing.Size(155, 21)
        Me.numCondensingUnitsLabel.TabIndex = 27
        Me.numCondensingUnitsLabel.Text = "Condensing units required"
        Me.numCondensingUnitsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'findCondensingUnitsButton
        '
        Me.findCondensingUnitsButton.BackColor = System.Drawing.Color.White
        Me.findCondensingUnitsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.findCondensingUnitsButton.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.findCondensingUnitsButton.ForeColor = System.Drawing.Color.Navy
        Me.findCondensingUnitsButton.Image = CType(resources.GetObject("findCondensingUnitsButton.Image"), System.Drawing.Image)
        Me.findCondensingUnitsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.findCondensingUnitsButton.Location = New System.Drawing.Point(15, 371)
        Me.findCondensingUnitsButton.Name = "findCondensingUnitsButton"
        Me.findCondensingUnitsButton.Size = New System.Drawing.Size(191, 32)
        Me.findCondensingUnitsButton.TabIndex = 28
        Me.findCondensingUnitsButton.Text = "Find Condensing Units "
        Me.findCondensingUnitsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.findCondensingUnitsButton.UseVisualStyleBackColor = False
        '
        'condensingUnit1DescriptionLabel
        '
        Me.condensingUnit1DescriptionLabel.BackColor = System.Drawing.Color.Transparent
        Me.condensingUnit1DescriptionLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.condensingUnit1DescriptionLabel.Location = New System.Drawing.Point(116, 30)
        Me.condensingUnit1DescriptionLabel.Name = "condensingUnit1DescriptionLabel"
        Me.condensingUnit1DescriptionLabel.Size = New System.Drawing.Size(233, 21)
        Me.condensingUnit1DescriptionLabel.TabIndex = 29
        Me.condensingUnit1DescriptionLabel.Text = "(condensing unit description)"
        Me.condensingUnit1DescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'condensingUnit2DescriptionLabel
        '
        Me.condensingUnit2DescriptionLabel.BackColor = System.Drawing.Color.Transparent
        Me.condensingUnit2DescriptionLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.condensingUnit2DescriptionLabel.Location = New System.Drawing.Point(116, 57)
        Me.condensingUnit2DescriptionLabel.Name = "condensingUnit2DescriptionLabel"
        Me.condensingUnit2DescriptionLabel.Size = New System.Drawing.Size(233, 21)
        Me.condensingUnit2DescriptionLabel.TabIndex = 30
        Me.condensingUnit2DescriptionLabel.Text = "(condensing unit description)"
        Me.condensingUnit2DescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_condensing_unit_1_capacity
        '
        Me.txt_condensing_unit_1_capacity.BackColor = System.Drawing.Color.Yellow
        Me.txt_condensing_unit_1_capacity.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_condensing_unit_1_capacity.Location = New System.Drawing.Point(384, 31)
        Me.txt_condensing_unit_1_capacity.Name = "txt_condensing_unit_1_capacity"
        Me.txt_condensing_unit_1_capacity.Size = New System.Drawing.Size(51, 21)
        Me.txt_condensing_unit_1_capacity.TabIndex = 31
        Me.txt_condensing_unit_1_capacity.TabStop = False
        Me.txt_condensing_unit_1_capacity.Visible = False
        '
        'condensingUnit3DescriptionLabel
        '
        Me.condensingUnit3DescriptionLabel.BackColor = System.Drawing.Color.Transparent
        Me.condensingUnit3DescriptionLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.condensingUnit3DescriptionLabel.Location = New System.Drawing.Point(116, 84)
        Me.condensingUnit3DescriptionLabel.Name = "condensingUnit3DescriptionLabel"
        Me.condensingUnit3DescriptionLabel.Size = New System.Drawing.Size(233, 21)
        Me.condensingUnit3DescriptionLabel.TabIndex = 32
        Me.condensingUnit3DescriptionLabel.Text = "(condensing unit description)"
        Me.condensingUnit3DescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_condensing_unit_2_capacity
        '
        Me.txt_condensing_unit_2_capacity.BackColor = System.Drawing.Color.Yellow
        Me.txt_condensing_unit_2_capacity.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_condensing_unit_2_capacity.Location = New System.Drawing.Point(384, 57)
        Me.txt_condensing_unit_2_capacity.Name = "txt_condensing_unit_2_capacity"
        Me.txt_condensing_unit_2_capacity.Size = New System.Drawing.Size(51, 21)
        Me.txt_condensing_unit_2_capacity.TabIndex = 33
        Me.txt_condensing_unit_2_capacity.TabStop = False
        Me.txt_condensing_unit_2_capacity.Visible = False
        '
        'txt_condensing_unit_3_capacity
        '
        Me.txt_condensing_unit_3_capacity.BackColor = System.Drawing.Color.Yellow
        Me.txt_condensing_unit_3_capacity.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_condensing_unit_3_capacity.Location = New System.Drawing.Point(384, 84)
        Me.txt_condensing_unit_3_capacity.Name = "txt_condensing_unit_3_capacity"
        Me.txt_condensing_unit_3_capacity.Size = New System.Drawing.Size(51, 21)
        Me.txt_condensing_unit_3_capacity.TabIndex = 34
        Me.txt_condensing_unit_3_capacity.TabStop = False
        Me.txt_condensing_unit_3_capacity.Visible = False
        '
        'condensingUnit3RadioButton
        '
        Me.condensingUnit3RadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.condensingUnit3RadioButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.condensingUnit3RadioButton.ForeColor = System.Drawing.SystemColors.Highlight
        Me.condensingUnit3RadioButton.Location = New System.Drawing.Point(3, 84)
        Me.condensingUnit3RadioButton.Name = "condensingUnit3RadioButton"
        Me.condensingUnit3RadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.condensingUnit3RadioButton.Size = New System.Drawing.Size(106, 21)
        Me.condensingUnit3RadioButton.TabIndex = 3
        Me.condensingUnit3RadioButton.Text = "Selection 3"
        '
        'condensingUnit2RadioButton
        '
        Me.condensingUnit2RadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.condensingUnit2RadioButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.condensingUnit2RadioButton.ForeColor = System.Drawing.SystemColors.Highlight
        Me.condensingUnit2RadioButton.Location = New System.Drawing.Point(3, 57)
        Me.condensingUnit2RadioButton.Name = "condensingUnit2RadioButton"
        Me.condensingUnit2RadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.condensingUnit2RadioButton.Size = New System.Drawing.Size(106, 21)
        Me.condensingUnit2RadioButton.TabIndex = 2
        Me.condensingUnit2RadioButton.Text = "Selection 2"
        '
        'condensingUnit1RadioButton
        '
        Me.condensingUnit1RadioButton.Checked = True
        Me.condensingUnit1RadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.condensingUnit1RadioButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.condensingUnit1RadioButton.ForeColor = System.Drawing.SystemColors.Highlight
        Me.condensingUnit1RadioButton.Location = New System.Drawing.Point(3, 30)
        Me.condensingUnit1RadioButton.Name = "condensingUnit1RadioButton"
        Me.condensingUnit1RadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.condensingUnit1RadioButton.Size = New System.Drawing.Size(106, 21)
        Me.condensingUnit1RadioButton.TabIndex = 1
        Me.condensingUnit1RadioButton.TabStop = True
        Me.condensingUnit1RadioButton.Text = "Best selection"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblNoCUResults)
        Me.Panel1.Controls.Add(Me.condensingUnit2CondenserCapacityTextBox)
        Me.Panel1.Controls.Add(Me.condensingUnit3CondenserCapacityTextBox)
        Me.Panel1.Controls.Add(Me.condensingUnit2DescriptionLabel)
        Me.Panel1.Controls.Add(Me.condensingUnit3DescriptionLabel)
        Me.Panel1.Controls.Add(Me.customCondensingUnitTextBox)
        Me.Panel1.Controls.Add(Me.txt_condensing_unit_3_capacity)
        Me.Panel1.Controls.Add(Me.txt_condensing_unit_2_capacity)
        Me.Panel1.Controls.Add(Me.condensingUnit1RadioButton)
        Me.Panel1.Controls.Add(Me.condensingUnit2RadioButton)
        Me.Panel1.Controls.Add(Me.condensingUnit3RadioButton)
        Me.Panel1.Controls.Add(Me.customCondenserCapacityPerDegreeTextBox)
        Me.Panel1.Controls.Add(Me.condensingUnit1CondenserCapacityPerDegreeTextBox)
        Me.Panel1.Controls.Add(Me.customCondensingUnitRadioButton)
        Me.Panel1.Controls.Add(Me.customCondensingUnitDescriptionLabel)
        Me.Panel1.Controls.Add(Me.condensingUnit1DescriptionLabel)
        Me.Panel1.Controls.Add(Me.txt_condensing_unit_1_capacity)
        Me.Panel1.Controls.Add(Me.condenserCapacityPerDegreeLabel)
        Me.Panel1.Controls.Add(Me.cmdGetCustomCUCapacity)
        Me.Panel1.Controls.Add(Me.customCondenserEvapCapacityTextBox)
        Me.Panel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Panel1.Location = New System.Drawing.Point(15, 402)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(556, 113)
        Me.Panel1.TabIndex = 35
        '
        'lblNoCUResults
        '
        Me.lblNoCUResults.BackColor = System.Drawing.Color.Salmon
        Me.lblNoCUResults.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoCUResults.ForeColor = System.Drawing.Color.Snow
        Me.lblNoCUResults.Location = New System.Drawing.Point(18, 6)
        Me.lblNoCUResults.Name = "lblNoCUResults"
        Me.lblNoCUResults.Size = New System.Drawing.Size(302, 21)
        Me.lblNoCUResults.TabIndex = 107
        Me.lblNoCUResults.Text = "No Condensing Units Found that Match Input Criteria"
        Me.lblNoCUResults.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblNoCUResults.Visible = False
        '
        'condensingUnit2CondenserCapacityTextBox
        '
        Me.condensingUnit2CondenserCapacityTextBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.condensingUnit2CondenserCapacityTextBox.Location = New System.Drawing.Point(353, 57)
        Me.condensingUnit2CondenserCapacityTextBox.Name = "condensingUnit2CondenserCapacityTextBox"
        Me.condensingUnit2CondenserCapacityTextBox.ReadOnly = True
        Me.condensingUnit2CondenserCapacityTextBox.Size = New System.Drawing.Size(66, 21)
        Me.condensingUnit2CondenserCapacityTextBox.TabIndex = 100
        Me.condensingUnit2CondenserCapacityTextBox.TabStop = False
        '
        'condensingUnit3CondenserCapacityTextBox
        '
        Me.condensingUnit3CondenserCapacityTextBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.condensingUnit3CondenserCapacityTextBox.Location = New System.Drawing.Point(353, 84)
        Me.condensingUnit3CondenserCapacityTextBox.Name = "condensingUnit3CondenserCapacityTextBox"
        Me.condensingUnit3CondenserCapacityTextBox.ReadOnly = True
        Me.condensingUnit3CondenserCapacityTextBox.Size = New System.Drawing.Size(66, 21)
        Me.condensingUnit3CondenserCapacityTextBox.TabIndex = 101
        Me.condensingUnit3CondenserCapacityTextBox.TabStop = False
        '
        'customCondensingUnitTextBox
        '
        Me.customCondensingUnitTextBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.customCondensingUnitTextBox.Location = New System.Drawing.Point(208, 111)
        Me.customCondensingUnitTextBox.Name = "customCondensingUnitTextBox"
        Me.customCondensingUnitTextBox.Size = New System.Drawing.Size(131, 21)
        Me.customCondensingUnitTextBox.TabIndex = 19
        Me.customCondensingUnitTextBox.Visible = False
        '
        'customCondenserCapacityPerDegreeTextBox
        '
        Me.customCondenserCapacityPerDegreeTextBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.customCondenserCapacityPerDegreeTextBox.Location = New System.Drawing.Point(354, 111)
        Me.customCondenserCapacityPerDegreeTextBox.Name = "customCondenserCapacityPerDegreeTextBox"
        Me.customCondenserCapacityPerDegreeTextBox.Size = New System.Drawing.Size(66, 21)
        Me.customCondenserCapacityPerDegreeTextBox.TabIndex = 20
        Me.customCondenserCapacityPerDegreeTextBox.Text = "0"
        Me.customCondenserCapacityPerDegreeTextBox.Visible = False
        '
        'condensingUnit1CondenserCapacityPerDegreeTextBox
        '
        Me.condensingUnit1CondenserCapacityPerDegreeTextBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.condensingUnit1CondenserCapacityPerDegreeTextBox.Location = New System.Drawing.Point(353, 31)
        Me.condensingUnit1CondenserCapacityPerDegreeTextBox.Name = "condensingUnit1CondenserCapacityPerDegreeTextBox"
        Me.condensingUnit1CondenserCapacityPerDegreeTextBox.ReadOnly = True
        Me.condensingUnit1CondenserCapacityPerDegreeTextBox.Size = New System.Drawing.Size(66, 21)
        Me.condensingUnit1CondenserCapacityPerDegreeTextBox.TabIndex = 99
        Me.condensingUnit1CondenserCapacityPerDegreeTextBox.TabStop = False
        '
        'customCondensingUnitRadioButton
        '
        Me.customCondensingUnitRadioButton.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.customCondensingUnitRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.customCondensingUnitRadioButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.customCondensingUnitRadioButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.customCondensingUnitRadioButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.customCondensingUnitRadioButton.Location = New System.Drawing.Point(4, 111)
        Me.customCondensingUnitRadioButton.Name = "customCondensingUnitRadioButton"
        Me.customCondensingUnitRadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.customCondensingUnitRadioButton.Size = New System.Drawing.Size(105, 21)
        Me.customCondensingUnitRadioButton.TabIndex = 18
        Me.customCondensingUnitRadioButton.Text = "Custom"
        Me.balanceToolTip.SetToolTip(Me.customCondensingUnitRadioButton, " - Use Total Capacity Requirements as shown above**")
        Me.customCondensingUnitRadioButton.Visible = False
        '
        'customCondensingUnitDescriptionLabel
        '
        Me.customCondensingUnitDescriptionLabel.BackColor = System.Drawing.Color.Transparent
        Me.customCondensingUnitDescriptionLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.customCondensingUnitDescriptionLabel.Location = New System.Drawing.Point(110, 111)
        Me.customCondensingUnitDescriptionLabel.Name = "customCondensingUnitDescriptionLabel"
        Me.customCondensingUnitDescriptionLabel.Size = New System.Drawing.Size(93, 21)
        Me.customCondensingUnitDescriptionLabel.TabIndex = 39
        Me.customCondensingUnitDescriptionLabel.Text = "Custom Model #"
        Me.customCondensingUnitDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.customCondensingUnitDescriptionLabel.Visible = False
        '
        'condenserCapacityPerDegreeLabel
        '
        Me.condenserCapacityPerDegreeLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.condenserCapacityPerDegreeLabel.Location = New System.Drawing.Point(326, 0)
        Me.condenserCapacityPerDegreeLabel.Name = "condenserCapacityPerDegreeLabel"
        Me.condenserCapacityPerDegreeLabel.Size = New System.Drawing.Size(122, 30)
        Me.condenserCapacityPerDegreeLabel.TabIndex = 104
        Me.condenserCapacityPerDegreeLabel.Text = "Condenser Est. Capacity Per Degree"
        Me.condenserCapacityPerDegreeLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'customCondenserEvapCapacityTextBox
        '
        Me.customCondenserEvapCapacityTextBox.BackColor = System.Drawing.Color.Yellow
        Me.customCondenserEvapCapacityTextBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.customCondenserEvapCapacityTextBox.Location = New System.Drawing.Point(384, 111)
        Me.customCondenserEvapCapacityTextBox.Name = "customCondenserEvapCapacityTextBox"
        Me.customCondenserEvapCapacityTextBox.Size = New System.Drawing.Size(51, 21)
        Me.customCondenserEvapCapacityTextBox.TabIndex = 106
        Me.customCondenserEvapCapacityTextBox.TabStop = False
        Me.customCondenserEvapCapacityTextBox.Visible = False
        '
        'lblErrors
        '
        Me.lblErrors.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblErrors.BackColor = System.Drawing.Color.White
        Me.lblErrors.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrors.ForeColor = System.Drawing.Color.Red
        Me.lblErrors.Location = New System.Drawing.Point(50, 0)
        Me.lblErrors.Name = "lblErrors"
        Me.lblErrors.Size = New System.Drawing.Size(572, 32)
        Me.lblErrors.TabIndex = 36
        Me.lblErrors.Text = "If errors occur, they will be shown here."
        '
        'cbo_unit_cooler_series
        '
        Me.cbo_unit_cooler_series.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_unit_cooler_series.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_unit_cooler_series.Items.AddRange(New Object() {"ALL", "AWSM", "A", "BALV", "BOC", "E", "FV", "PFE", "UFH", "XBOC", "WIBR"})
        Me.cbo_unit_cooler_series.Location = New System.Drawing.Point(198, 6)
        Me.cbo_unit_cooler_series.Name = "cbo_unit_cooler_series"
        Me.cbo_unit_cooler_series.Size = New System.Drawing.Size(85, 21)
        Me.cbo_unit_cooler_series.TabIndex = 30
        '
        'lblUnitCoolerSeries
        '
        Me.lblUnitCoolerSeries.BackColor = System.Drawing.Color.Transparent
        Me.lblUnitCoolerSeries.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnitCoolerSeries.Location = New System.Drawing.Point(49, 6)
        Me.lblUnitCoolerSeries.Name = "lblUnitCoolerSeries"
        Me.lblUnitCoolerSeries.Size = New System.Drawing.Size(143, 21)
        Me.lblUnitCoolerSeries.TabIndex = 45
        Me.lblUnitCoolerSeries.Text = "Unit cooler series"
        Me.lblUnitCoolerSeries.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSuctionLineLoss
        '
        Me.lblSuctionLineLoss.BackColor = System.Drawing.Color.Transparent
        Me.lblSuctionLineLoss.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuctionLineLoss.Location = New System.Drawing.Point(49, 33)
        Me.lblSuctionLineLoss.Name = "lblSuctionLineLoss"
        Me.lblSuctionLineLoss.Size = New System.Drawing.Size(143, 21)
        Me.lblSuctionLineLoss.TabIndex = 46
        Me.lblSuctionLineLoss.Text = "Suction line loss"
        Me.lblSuctionLineLoss.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbo_suction_line_loss
        '
        Me.cbo_suction_line_loss.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_suction_line_loss.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_suction_line_loss.Items.AddRange(New Object() {"0", "1", "2", "3", "4"})
        Me.cbo_suction_line_loss.Location = New System.Drawing.Point(198, 33)
        Me.cbo_suction_line_loss.Name = "cbo_suction_line_loss"
        Me.cbo_suction_line_loss.Size = New System.Drawing.Size(85, 21)
        Me.cbo_suction_line_loss.TabIndex = 31
        '
        'roomTemperatureTextBox
        '
        Me.roomTemperatureTextBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.roomTemperatureTextBox.Location = New System.Drawing.Point(225, 60)
        Me.roomTemperatureTextBox.Name = "roomTemperatureTextBox"
        Me.roomTemperatureTextBox.Size = New System.Drawing.Size(85, 21)
        Me.roomTemperatureTextBox.TabIndex = 16
        Me.roomTemperatureTextBox.Text = "45"
        '
        'roomTemperatureLabel
        '
        Me.roomTemperatureLabel.BackColor = System.Drawing.Color.Transparent
        Me.roomTemperatureLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.roomTemperatureLabel.Location = New System.Drawing.Point(60, 60)
        Me.roomTemperatureLabel.Name = "roomTemperatureLabel"
        Me.roomTemperatureLabel.Size = New System.Drawing.Size(158, 21)
        Me.roomTemperatureLabel.TabIndex = 49
        Me.roomTemperatureLabel.Text = "Design room temperature"
        Me.roomTemperatureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_find_unit_coolers
        '
        Me.btn_find_unit_coolers.BackColor = System.Drawing.Color.White
        Me.btn_find_unit_coolers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_find_unit_coolers.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_find_unit_coolers.ForeColor = System.Drawing.Color.Navy
        Me.btn_find_unit_coolers.Image = CType(resources.GetObject("btn_find_unit_coolers.Image"), System.Drawing.Image)
        Me.btn_find_unit_coolers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_find_unit_coolers.Location = New System.Drawing.Point(18, 2)
        Me.btn_find_unit_coolers.Name = "btn_find_unit_coolers"
        Me.btn_find_unit_coolers.Size = New System.Drawing.Size(168, 32)
        Me.btn_find_unit_coolers.TabIndex = 33
        Me.btn_find_unit_coolers.Text = "Find Unit Coolers "
        Me.btn_find_unit_coolers.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_find_unit_coolers.UseVisualStyleBackColor = False
        '
        'txt_unit_cooler_quantity_1
        '
        Me.txt_unit_cooler_quantity_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_unit_cooler_quantity_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_unit_cooler_quantity_1.Location = New System.Drawing.Point(308, 35)
        Me.txt_unit_cooler_quantity_1.Name = "txt_unit_cooler_quantity_1"
        Me.txt_unit_cooler_quantity_1.Size = New System.Drawing.Size(42, 21)
        Me.txt_unit_cooler_quantity_1.TabIndex = 34
        Me.txt_unit_cooler_quantity_1.Tag = "0"
        Me.txt_unit_cooler_quantity_1.Text = "0"
        '
        'txt_unit_cooler_quantity_2
        '
        Me.txt_unit_cooler_quantity_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_unit_cooler_quantity_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_unit_cooler_quantity_2.Location = New System.Drawing.Point(308, 61)
        Me.txt_unit_cooler_quantity_2.Name = "txt_unit_cooler_quantity_2"
        Me.txt_unit_cooler_quantity_2.Size = New System.Drawing.Size(42, 21)
        Me.txt_unit_cooler_quantity_2.TabIndex = 35
        Me.txt_unit_cooler_quantity_2.Tag = "0"
        Me.txt_unit_cooler_quantity_2.Text = "0"
        '
        'txt_unit_cooler_quantity_3
        '
        Me.txt_unit_cooler_quantity_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_unit_cooler_quantity_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_unit_cooler_quantity_3.Location = New System.Drawing.Point(308, 87)
        Me.txt_unit_cooler_quantity_3.Name = "txt_unit_cooler_quantity_3"
        Me.txt_unit_cooler_quantity_3.Size = New System.Drawing.Size(42, 21)
        Me.txt_unit_cooler_quantity_3.TabIndex = 36
        Me.txt_unit_cooler_quantity_3.Tag = "0"
        Me.txt_unit_cooler_quantity_3.Text = "0"
        '
        'lbl_Qty_Required
        '
        Me.lbl_Qty_Required.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Qty_Required.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Qty_Required.Location = New System.Drawing.Point(307, 4)
        Me.lbl_Qty_Required.Name = "lbl_Qty_Required"
        Me.lbl_Qty_Required.Size = New System.Drawing.Size(54, 29)
        Me.lbl_Qty_Required.TabIndex = 54
        Me.lbl_Qty_Required.Text = "Quantity"
        Me.lbl_Qty_Required.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txt_balance
        '
        Me.txt_balance.BackColor = System.Drawing.Color.Yellow
        Me.txt_balance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_balance.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txt_balance.Location = New System.Drawing.Point(248, 137)
        Me.txt_balance.Name = "txt_balance"
        Me.txt_balance.ReadOnly = True
        Me.txt_balance.Size = New System.Drawing.Size(57, 21)
        Me.txt_balance.TabIndex = 55
        Me.txt_balance.Text = "0"
        '
        'lbl_BTUH_Balance
        '
        Me.lbl_BTUH_Balance.BackColor = System.Drawing.Color.Transparent
        Me.lbl_BTUH_Balance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_BTUH_Balance.Location = New System.Drawing.Point(180, 140)
        Me.lbl_BTUH_Balance.Name = "lbl_BTUH_Balance"
        Me.lbl_BTUH_Balance.Size = New System.Drawing.Size(63, 20)
        Me.lbl_BTUH_Balance.TabIndex = 56
        Me.lbl_BTUH_Balance.Text = "Balance"
        Me.lbl_BTUH_Balance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Model_Number
        '
        Me.lbl_Model_Number.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Model_Number.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Model_Number.Location = New System.Drawing.Point(112, 12)
        Me.lbl_Model_Number.Name = "lbl_Model_Number"
        Me.lbl_Model_Number.Size = New System.Drawing.Size(117, 27)
        Me.lbl_Model_Number.TabIndex = 57
        Me.lbl_Model_Number.Text = "Model Number"
        Me.lbl_Model_Number.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_unit_cooler_model_1
        '
        Me.txt_unit_cooler_model_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_unit_cooler_model_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_unit_cooler_model_1.Location = New System.Drawing.Point(112, 35)
        Me.txt_unit_cooler_model_1.Name = "txt_unit_cooler_model_1"
        Me.txt_unit_cooler_model_1.ReadOnly = True
        Me.txt_unit_cooler_model_1.Size = New System.Drawing.Size(132, 21)
        Me.txt_unit_cooler_model_1.TabIndex = 58
        Me.txt_unit_cooler_model_1.TabStop = False
        '
        'txt_unit_cooler_model_2
        '
        Me.txt_unit_cooler_model_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_unit_cooler_model_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_unit_cooler_model_2.Location = New System.Drawing.Point(112, 61)
        Me.txt_unit_cooler_model_2.Name = "txt_unit_cooler_model_2"
        Me.txt_unit_cooler_model_2.ReadOnly = True
        Me.txt_unit_cooler_model_2.Size = New System.Drawing.Size(132, 21)
        Me.txt_unit_cooler_model_2.TabIndex = 59
        Me.txt_unit_cooler_model_2.TabStop = False
        '
        'txt_unit_cooler_model_3
        '
        Me.txt_unit_cooler_model_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_unit_cooler_model_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_unit_cooler_model_3.Location = New System.Drawing.Point(112, 87)
        Me.txt_unit_cooler_model_3.Name = "txt_unit_cooler_model_3"
        Me.txt_unit_cooler_model_3.ReadOnly = True
        Me.txt_unit_cooler_model_3.Size = New System.Drawing.Size(132, 21)
        Me.txt_unit_cooler_model_3.TabIndex = 60
        Me.txt_unit_cooler_model_3.TabStop = False
        '
        'rbo_unit_cooler_1
        '
        Me.rbo_unit_cooler_1.BackColor = System.Drawing.SystemColors.Control
        Me.rbo_unit_cooler_1.Checked = True
        Me.rbo_unit_cooler_1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbo_unit_cooler_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbo_unit_cooler_1.Location = New System.Drawing.Point(12, 12)
        Me.rbo_unit_cooler_1.Name = "rbo_unit_cooler_1"
        Me.rbo_unit_cooler_1.Size = New System.Drawing.Size(89, 29)
        Me.rbo_unit_cooler_1.TabIndex = 26
        Me.rbo_unit_cooler_1.TabStop = True
        Me.rbo_unit_cooler_1.Text = "Unit cooler 1"
        Me.rbo_unit_cooler_1.UseVisualStyleBackColor = False
        '
        'rbo_unit_cooler_2
        '
        Me.rbo_unit_cooler_2.BackColor = System.Drawing.SystemColors.Control
        Me.rbo_unit_cooler_2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbo_unit_cooler_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbo_unit_cooler_2.Location = New System.Drawing.Point(12, 37)
        Me.rbo_unit_cooler_2.Name = "rbo_unit_cooler_2"
        Me.rbo_unit_cooler_2.Size = New System.Drawing.Size(93, 29)
        Me.rbo_unit_cooler_2.TabIndex = 27
        Me.rbo_unit_cooler_2.Text = "Unit cooler 2"
        Me.rbo_unit_cooler_2.UseVisualStyleBackColor = False
        '
        'rbo_unit_cooler_3
        '
        Me.rbo_unit_cooler_3.BackColor = System.Drawing.SystemColors.Control
        Me.rbo_unit_cooler_3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbo_unit_cooler_3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbo_unit_cooler_3.Location = New System.Drawing.Point(12, 63)
        Me.rbo_unit_cooler_3.Name = "rbo_unit_cooler_3"
        Me.rbo_unit_cooler_3.Size = New System.Drawing.Size(91, 28)
        Me.rbo_unit_cooler_3.TabIndex = 28
        Me.rbo_unit_cooler_3.Text = "Unit cooler 3"
        Me.rbo_unit_cooler_3.UseVisualStyleBackColor = False
        '
        'lbl_Room_Temp_Range
        '
        Me.lbl_Room_Temp_Range.BackColor = System.Drawing.Color.Red
        Me.lbl_Room_Temp_Range.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Room_Temp_Range.Location = New System.Drawing.Point(212, 371)
        Me.lbl_Room_Temp_Range.Name = "lbl_Room_Temp_Range"
        Me.lbl_Room_Temp_Range.Size = New System.Drawing.Size(133, 28)
        Me.lbl_Room_Temp_Range.TabIndex = 65
        Me.lbl_Room_Temp_Range.Text = "Range -36 to +75 (°F)"
        Me.lbl_Room_Temp_Range.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl_Room_Temp_Range.Visible = False
        '
        'btn_balance
        '
        Me.btn_balance.BackColor = System.Drawing.Color.White
        Me.btn_balance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_balance.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_balance.ForeColor = System.Drawing.Color.Navy
        Me.btn_balance.Image = CType(resources.GetObject("btn_balance.Image"), System.Drawing.Image)
        Me.btn_balance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_balance.Location = New System.Drawing.Point(15, 2)
        Me.btn_balance.Name = "btn_balance"
        Me.btn_balance.Size = New System.Drawing.Size(151, 32)
        Me.btn_balance.TabIndex = 41
        Me.btn_balance.Text = "Rate System "
        Me.btn_balance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_balance.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.rbo_unit_cooler_1)
        Me.Panel2.Controls.Add(Me.rbo_unit_cooler_2)
        Me.Panel2.Controls.Add(Me.rbo_unit_cooler_3)
        Me.Panel2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(13, 22)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(106, 93)
        Me.Panel2.TabIndex = 71
        '
        'btn_clear_unit_cooler_1
        '
        Me.btn_clear_unit_cooler_1.BackColor = System.Drawing.Color.Navy
        Me.btn_clear_unit_cooler_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_clear_unit_cooler_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_clear_unit_cooler_1.ForeColor = System.Drawing.Color.White
        Me.btn_clear_unit_cooler_1.Location = New System.Drawing.Point(405, 33)
        Me.btn_clear_unit_cooler_1.Name = "btn_clear_unit_cooler_1"
        Me.btn_clear_unit_cooler_1.Size = New System.Drawing.Size(54, 24)
        Me.btn_clear_unit_cooler_1.TabIndex = 72
        Me.btn_clear_unit_cooler_1.TabStop = False
        Me.btn_clear_unit_cooler_1.Text = "Clear"
        Me.btn_clear_unit_cooler_1.UseVisualStyleBackColor = False
        '
        'btn_clear_unit_cooler_2
        '
        Me.btn_clear_unit_cooler_2.BackColor = System.Drawing.Color.Navy
        Me.btn_clear_unit_cooler_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_clear_unit_cooler_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_clear_unit_cooler_2.ForeColor = System.Drawing.Color.White
        Me.btn_clear_unit_cooler_2.Location = New System.Drawing.Point(405, 59)
        Me.btn_clear_unit_cooler_2.Name = "btn_clear_unit_cooler_2"
        Me.btn_clear_unit_cooler_2.Size = New System.Drawing.Size(54, 24)
        Me.btn_clear_unit_cooler_2.TabIndex = 73
        Me.btn_clear_unit_cooler_2.TabStop = False
        Me.btn_clear_unit_cooler_2.Text = "Clear"
        Me.btn_clear_unit_cooler_2.UseVisualStyleBackColor = False
        '
        'btn_clear_unit_cooler_3
        '
        Me.btn_clear_unit_cooler_3.BackColor = System.Drawing.Color.Navy
        Me.btn_clear_unit_cooler_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_clear_unit_cooler_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_clear_unit_cooler_3.ForeColor = System.Drawing.Color.White
        Me.btn_clear_unit_cooler_3.Location = New System.Drawing.Point(405, 85)
        Me.btn_clear_unit_cooler_3.Name = "btn_clear_unit_cooler_3"
        Me.btn_clear_unit_cooler_3.Size = New System.Drawing.Size(54, 24)
        Me.btn_clear_unit_cooler_3.TabIndex = 74
        Me.btn_clear_unit_cooler_3.TabStop = False
        Me.btn_clear_unit_cooler_3.Text = "Clear"
        Me.btn_clear_unit_cooler_3.UseVisualStyleBackColor = False
        '
        'btn_show_report
        '
        Me.btn_show_report.BackColor = System.Drawing.Color.White
        Me.btn_show_report.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_show_report.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_show_report.ForeColor = System.Drawing.Color.Navy
        Me.btn_show_report.Image = CType(resources.GetObject("btn_show_report.Image"), System.Drawing.Image)
        Me.btn_show_report.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_show_report.Location = New System.Drawing.Point(164, 2)
        Me.btn_show_report.Name = "btn_show_report"
        Me.btn_show_report.Size = New System.Drawing.Size(153, 32)
        Me.btn_show_report.TabIndex = 42
        Me.btn_show_report.Text = "View Report "
        Me.btn_show_report.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_show_report.UseVisualStyleBackColor = False
        '
        'numRoomsLabel
        '
        Me.numRoomsLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numRoomsLabel.Location = New System.Drawing.Point(61, 6)
        Me.numRoomsLabel.Name = "numRoomsLabel"
        Me.numRoomsLabel.Size = New System.Drawing.Size(152, 21)
        Me.numRoomsLabel.TabIndex = 81
        Me.numRoomsLabel.Text = "Number of rooms"
        Me.numRoomsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'adjustCapacityForRunTimePanel
        '
        Me.adjustCapacityForRunTimePanel.Controls.Add(Me.adjustCapacityForRunTimeNoRadioButton)
        Me.adjustCapacityForRunTimePanel.Controls.Add(Me.adjustCapacityForRunTimeYesRadioButton)
        Me.adjustCapacityForRunTimePanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.adjustCapacityForRunTimePanel.Location = New System.Drawing.Point(231, 36)
        Me.adjustCapacityForRunTimePanel.Name = "adjustCapacityForRunTimePanel"
        Me.adjustCapacityForRunTimePanel.Size = New System.Drawing.Size(135, 21)
        Me.adjustCapacityForRunTimePanel.TabIndex = 2
        '
        'oneRoomComboBox
        '
        Me.oneRoomComboBox.Checked = True
        Me.oneRoomComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.oneRoomComboBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.oneRoomComboBox.Location = New System.Drawing.Point(225, 6)
        Me.oneRoomComboBox.Name = "oneRoomComboBox"
        Me.oneRoomComboBox.Size = New System.Drawing.Size(75, 21)
        Me.oneRoomComboBox.TabIndex = 13
        Me.oneRoomComboBox.TabStop = True
        Me.oneRoomComboBox.Tag = "Y"
        Me.oneRoomComboBox.Text = "One"
        '
        'multipleRoomsComboBox
        '
        Me.multipleRoomsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.multipleRoomsComboBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.multipleRoomsComboBox.Location = New System.Drawing.Point(282, 6)
        Me.multipleRoomsComboBox.Name = "multipleRoomsComboBox"
        Me.multipleRoomsComboBox.Size = New System.Drawing.Size(73, 21)
        Me.multipleRoomsComboBox.TabIndex = 14
        Me.multipleRoomsComboBox.Text = "Multiple"
        '
        'minTemperatureLabel
        '
        Me.minTemperatureLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minTemperatureLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.minTemperatureLabel.Location = New System.Drawing.Point(351, 3)
        Me.minTemperatureLabel.Name = "minTemperatureLabel"
        Me.minTemperatureLabel.Size = New System.Drawing.Size(59, 27)
        Me.minTemperatureLabel.TabIndex = 84
        Me.minTemperatureLabel.Text = "Minimum"
        Me.minTemperatureLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'maxTemperatureLabel
        '
        Me.maxTemperatureLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maxTemperatureLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.maxTemperatureLabel.Location = New System.Drawing.Point(411, 3)
        Me.maxTemperatureLabel.Name = "maxTemperatureLabel"
        Me.maxTemperatureLabel.Size = New System.Drawing.Size(64, 27)
        Me.maxTemperatureLabel.TabIndex = 85
        Me.maxTemperatureLabel.Text = "Maximum"
        Me.maxTemperatureLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txt_max_ambient
        '
        Me.txt_max_ambient.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_max_ambient.Location = New System.Drawing.Point(412, 33)
        Me.txt_max_ambient.Name = "txt_max_ambient"
        Me.txt_max_ambient.Size = New System.Drawing.Size(47, 21)
        Me.txt_max_ambient.TabIndex = 86
        Me.txt_max_ambient.Text = "90"
        '
        'txt_max_room_temp
        '
        Me.txt_max_room_temp.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_max_room_temp.Location = New System.Drawing.Point(412, 60)
        Me.txt_max_room_temp.Name = "txt_max_room_temp"
        Me.txt_max_room_temp.Size = New System.Drawing.Size(47, 21)
        Me.txt_max_room_temp.TabIndex = 87
        Me.txt_max_room_temp.Text = "50"
        '
        'txt_min_ambient
        '
        Me.txt_min_ambient.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_min_ambient.Location = New System.Drawing.Point(352, 33)
        Me.txt_min_ambient.Name = "txt_min_ambient"
        Me.txt_min_ambient.Size = New System.Drawing.Size(48, 21)
        Me.txt_min_ambient.TabIndex = 88
        Me.txt_min_ambient.Text = "80"
        '
        'txt_min_room_temp
        '
        Me.txt_min_room_temp.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_min_room_temp.Location = New System.Drawing.Point(352, 60)
        Me.txt_min_room_temp.Name = "txt_min_room_temp"
        Me.txt_min_room_temp.Size = New System.Drawing.Size(48, 21)
        Me.txt_min_room_temp.TabIndex = 89
        Me.txt_min_room_temp.Text = "40"
        '
        'incrementTemperatureLabel
        '
        Me.incrementTemperatureLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.incrementTemperatureLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.incrementTemperatureLabel.Location = New System.Drawing.Point(471, 3)
        Me.incrementTemperatureLabel.Name = "incrementTemperatureLabel"
        Me.incrementTemperatureLabel.Size = New System.Drawing.Size(67, 27)
        Me.incrementTemperatureLabel.TabIndex = 90
        Me.incrementTemperatureLabel.Text = "Increment"
        Me.incrementTemperatureLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'incrementAmbientTemperatureTextBox
        '
        Me.incrementAmbientTemperatureTextBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.incrementAmbientTemperatureTextBox.Location = New System.Drawing.Point(472, 33)
        Me.incrementAmbientTemperatureTextBox.Name = "incrementAmbientTemperatureTextBox"
        Me.incrementAmbientTemperatureTextBox.Size = New System.Drawing.Size(47, 21)
        Me.incrementAmbientTemperatureTextBox.TabIndex = 91
        Me.incrementAmbientTemperatureTextBox.Text = "5"
        '
        'incrementRoomTemperatureTextBox
        '
        Me.incrementRoomTemperatureTextBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.incrementRoomTemperatureTextBox.Location = New System.Drawing.Point(472, 60)
        Me.incrementRoomTemperatureTextBox.Name = "incrementRoomTemperatureTextBox"
        Me.incrementRoomTemperatureTextBox.Size = New System.Drawing.Size(47, 21)
        Me.incrementRoomTemperatureTextBox.TabIndex = 92
        Me.incrementRoomTemperatureTextBox.Text = "5"
        '
        'roomsPanel
        '
        Me.roomsPanel.BackColor = System.Drawing.SystemColors.Control
        Me.roomsPanel.Controls.Add(Me.incrementTemperatureLabel)
        Me.roomsPanel.Controls.Add(Me.roomTemperatureUnitsLabel)
        Me.roomsPanel.Controls.Add(Me.ambientTemperatureUnitsLabel)
        Me.roomsPanel.Controls.Add(Me.maxTemperatureLabel)
        Me.roomsPanel.Controls.Add(Me.txt_min_ambient)
        Me.roomsPanel.Controls.Add(Me.txt_min_room_temp)
        Me.roomsPanel.Controls.Add(Me.txt_max_room_temp)
        Me.roomsPanel.Controls.Add(Me.txt_max_ambient)
        Me.roomsPanel.Controls.Add(Me.incrementRoomTemperatureTextBox)
        Me.roomsPanel.Controls.Add(Me.incrementAmbientTemperatureTextBox)
        Me.roomsPanel.Controls.Add(Me.ambientTemperatureTextBox)
        Me.roomsPanel.Controls.Add(Me.roomTemperatureTextBox)
        Me.roomsPanel.Controls.Add(Me.minTemperatureLabel)
        Me.roomsPanel.Controls.Add(Me.multipleRoomsComboBox)
        Me.roomsPanel.Controls.Add(Me.oneRoomComboBox)
        Me.roomsPanel.Controls.Add(Me.numRoomsLabel)
        Me.roomsPanel.Controls.Add(Me.ambientTemperatureLabel)
        Me.roomsPanel.Controls.Add(Me.roomTemperatureLabel)
        Me.roomsPanel.Location = New System.Drawing.Point(7, 276)
        Me.roomsPanel.Name = "roomsPanel"
        Me.roomsPanel.Size = New System.Drawing.Size(577, 94)
        Me.roomsPanel.TabIndex = 12
        '
        'roomTemperatureUnitsLabel
        '
        Me.roomTemperatureUnitsLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.roomTemperatureUnitsLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.roomTemperatureUnitsLabel.Location = New System.Drawing.Point(316, 60)
        Me.roomTemperatureUnitsLabel.Name = "roomTemperatureUnitsLabel"
        Me.roomTemperatureUnitsLabel.Size = New System.Drawing.Size(34, 21)
        Me.roomTemperatureUnitsLabel.TabIndex = 94
        Me.roomTemperatureUnitsLabel.Text = "[°F]"
        Me.roomTemperatureUnitsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ambientTemperatureUnitsLabel
        '
        Me.ambientTemperatureUnitsLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ambientTemperatureUnitsLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ambientTemperatureUnitsLabel.Location = New System.Drawing.Point(315, 33)
        Me.ambientTemperatureUnitsLabel.Name = "ambientTemperatureUnitsLabel"
        Me.ambientTemperatureUnitsLabel.Size = New System.Drawing.Size(34, 21)
        Me.ambientTemperatureUnitsLabel.TabIndex = 93
        Me.ambientTemperatureUnitsLabel.Text = "[°F]"
        Me.ambientTemperatureUnitsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picError
        '
        Me.picError.Image = CType(resources.GetObject("picError.Image"), System.Drawing.Image)
        Me.picError.Location = New System.Drawing.Point(0, 0)
        Me.picError.Name = "picError"
        Me.picError.Size = New System.Drawing.Size(32, 32)
        Me.picError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picError.TabIndex = 0
        Me.picError.TabStop = False
        Me.balanceToolTip.SetToolTip(Me.picError, "Double click to re-size of footer")
        '
        'panCondensingUnitSpecBody
        '
        Me.panCondensingUnitSpecBody.BackColor = System.Drawing.SystemColors.Control
        Me.panCondensingUnitSpecBody.Controls.Add(Me.Label1)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.ddlDOE)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.cbCondTempOverride)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.grpboxload)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.txtCoolStuffid)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.findCondensingUnitsButton)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.runTimeUnitsLabel)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.runTimeLabel)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.altitudeUnitsLabel)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.capacityRequiredUnitsLabel)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.cboCondensingUnitSeries)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.lbl_Room_Temp_Range)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.txt_suction_temp)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.altitudeTextBox)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.txt_condensing_unit_quantity)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.cbo_refrigerant)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.suctionTemperatureUnitsLabel)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.compressorTypeComboBox)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.runTimeTextBox)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.numCompressorsPerUnitComboBox)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.txt_capacity_required)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.numCircuitsPerUnitComboBox)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.numCircuitsPerUnitLabel)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.altitudeLabel)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.refrigerantLabel)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.suctionTemperatureLabel)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.numCondensingUnitsLabel)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.compressorTypeLabel)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.capacityRequiredLabel)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.numCompressorsPerUnitLabel)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.roomsPanel)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.Panel1)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.adjustCapacityForRunTimePanel)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.adjustCapacityForRunTimeLabel)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.condensingUnitSeriesLabel)
        Me.panCondensingUnitSpecBody.Controls.Add(Me.balanceMenuStrip)
        Me.panCondensingUnitSpecBody.Dock = System.Windows.Forms.DockStyle.Top
        Me.panCondensingUnitSpecBody.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panCondensingUnitSpecBody.Location = New System.Drawing.Point(0, 0)
        Me.panCondensingUnitSpecBody.Name = "panCondensingUnitSpecBody"
        Me.panCondensingUnitSpecBody.Size = New System.Drawing.Size(625, 526)
        Me.panCondensingUnitSpecBody.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(359, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 21)
        Me.Label1.TabIndex = 108
        Me.Label1.Text = "DOE Compliant System?"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ddlDOE
        '
        Me.ddlDOE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlDOE.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ddlDOE.Items.AddRange(New Object() {"Yes", "No"})
        Me.ddlDOE.Location = New System.Drawing.Point(500, 6)
        Me.ddlDOE.Name = "ddlDOE"
        Me.ddlDOE.Size = New System.Drawing.Size(54, 21)
        Me.ddlDOE.TabIndex = 107
        '
        'cbCondTempOverride
        '
        Me.cbCondTempOverride.AutoSize = True
        Me.cbCondTempOverride.Location = New System.Drawing.Point(376, 378)
        Me.cbCondTempOverride.Name = "cbCondTempOverride"
        Me.cbCondTempOverride.Size = New System.Drawing.Size(157, 17)
        Me.cbCondTempOverride.TabIndex = 106
        Me.cbCondTempOverride.Text = "Cond. Temp. Limit Override"
        Me.cbCondTempOverride.UseVisualStyleBackColor = True
        Me.cbCondTempOverride.Visible = False
        '
        'grpboxload
        '
        Me.grpboxload.Controls.Add(Me.btnremoveboxloadLink)
        Me.grpboxload.Controls.Add(Me.lblboxloadlinkedto)
        Me.grpboxload.Controls.Add(Me.txtcoolstuffBlName)
        Me.grpboxload.Controls.Add(Me.btnCoolStuffInvoke)
        Me.grpboxload.Location = New System.Drawing.Point(380, 97)
        Me.grpboxload.Name = "grpboxload"
        Me.grpboxload.Size = New System.Drawing.Size(158, 100)
        Me.grpboxload.TabIndex = 105
        Me.grpboxload.TabStop = False
        Me.grpboxload.Text = "Box Load"
        '
        'btnremoveboxloadLink
        '
        Me.btnremoveboxloadLink.Location = New System.Drawing.Point(12, 29)
        Me.btnremoveboxloadLink.Name = "btnremoveboxloadLink"
        Me.btnremoveboxloadLink.Size = New System.Drawing.Size(120, 23)
        Me.btnremoveboxloadLink.TabIndex = 107
        Me.btnremoveboxloadLink.Text = "Remove Link"
        Me.btnremoveboxloadLink.UseVisualStyleBackColor = True
        Me.btnremoveboxloadLink.Visible = False
        '
        'lblboxloadlinkedto
        '
        Me.lblboxloadlinkedto.BackColor = System.Drawing.Color.Transparent
        Me.lblboxloadlinkedto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblboxloadlinkedto.Location = New System.Drawing.Point(3, 55)
        Me.lblboxloadlinkedto.Name = "lblboxloadlinkedto"
        Me.lblboxloadlinkedto.Size = New System.Drawing.Size(63, 15)
        Me.lblboxloadlinkedto.TabIndex = 106
        Me.lblboxloadlinkedto.Text = "Linked to:"
        Me.lblboxloadlinkedto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtcoolstuffBlName
        '
        Me.txtcoolstuffBlName.Location = New System.Drawing.Point(6, 73)
        Me.txtcoolstuffBlName.Name = "txtcoolstuffBlName"
        Me.txtcoolstuffBlName.Size = New System.Drawing.Size(140, 21)
        Me.txtcoolstuffBlName.TabIndex = 105
        '
        'btnCoolStuffInvoke
        '
        Me.btnCoolStuffInvoke.Location = New System.Drawing.Point(14, 20)
        Me.btnCoolStuffInvoke.Name = "btnCoolStuffInvoke"
        Me.btnCoolStuffInvoke.Size = New System.Drawing.Size(120, 23)
        Me.btnCoolStuffInvoke.TabIndex = 103
        Me.btnCoolStuffInvoke.Text = "Link Box Load"
        Me.btnCoolStuffInvoke.UseVisualStyleBackColor = True
        '
        'txtCoolStuffid
        '
        Me.txtCoolStuffid.Location = New System.Drawing.Point(452, 105)
        Me.txtCoolStuffid.Name = "txtCoolStuffid"
        Me.txtCoolStuffid.Size = New System.Drawing.Size(62, 21)
        Me.txtCoolStuffid.TabIndex = 104
        Me.txtCoolStuffid.Visible = False
        '
        'runTimeUnitsLabel
        '
        Me.runTimeUnitsLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.runTimeUnitsLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.runTimeUnitsLabel.Location = New System.Drawing.Point(532, 36)
        Me.runTimeUnitsLabel.Name = "runTimeUnitsLabel"
        Me.runTimeUnitsLabel.Size = New System.Drawing.Size(39, 21)
        Me.runTimeUnitsLabel.TabIndex = 99
        Me.runTimeUnitsLabel.Text = "[hr]"
        Me.runTimeUnitsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'altitudeUnitsLabel
        '
        Me.altitudeUnitsLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.altitudeUnitsLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.altitudeUnitsLabel.Location = New System.Drawing.Point(322, 200)
        Me.altitudeUnitsLabel.Name = "altitudeUnitsLabel"
        Me.altitudeUnitsLabel.Size = New System.Drawing.Size(130, 21)
        Me.altitudeUnitsLabel.TabIndex = 98
        Me.altitudeUnitsLabel.Text = "[ft] above sea level"
        Me.altitudeUnitsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'capacityRequiredUnitsLabel
        '
        Me.capacityRequiredUnitsLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.capacityRequiredUnitsLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.capacityRequiredUnitsLabel.Location = New System.Drawing.Point(322, 171)
        Me.capacityRequiredUnitsLabel.Name = "capacityRequiredUnitsLabel"
        Me.capacityRequiredUnitsLabel.Size = New System.Drawing.Size(130, 21)
        Me.capacityRequiredUnitsLabel.TabIndex = 97
        Me.capacityRequiredUnitsLabel.Text = "[BTUH]"
        Me.capacityRequiredUnitsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'balanceMenuStrip
        '
        Me.balanceMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenuItem})
        Me.balanceMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.balanceMenuStrip.Name = "balanceMenuStrip"
        Me.balanceMenuStrip.Size = New System.Drawing.Size(595, 24)
        Me.balanceMenuStrip.TabIndex = 102
        Me.balanceMenuStrip.Text = "MenuStrip1"
        Me.balanceMenuStrip.Visible = False
        '
        'FileMenuItem
        '
        Me.FileMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.separator3, Me.saveMenuItem, Me.saveAsMenuItem, Me.saveAsRevisionMenuItem, Me.separator2, Me.convertToEquipmentMenuItem, Me.separator1, Me.printMenuItem})
        Me.FileMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly
        Me.FileMenuItem.Name = "FileMenuItem"
        Me.FileMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileMenuItem.Text = "File"
        '
        'separator3
        '
        Me.separator3.Name = "separator3"
        Me.separator3.Size = New System.Drawing.Size(197, 6)
        '
        'saveMenuItem
        '
        Me.saveMenuItem.Image = CType(resources.GetObject("saveMenuItem.Image"), System.Drawing.Image)
        Me.saveMenuItem.Name = "saveMenuItem"
        Me.saveMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.saveMenuItem.Text = "Save"
        '
        'saveAsMenuItem
        '
        Me.saveAsMenuItem.Name = "saveAsMenuItem"
        Me.saveAsMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.saveAsMenuItem.Text = "Save as..."
        '
        'saveAsRevisionMenuItem
        '
        Me.saveAsRevisionMenuItem.Image = CType(resources.GetObject("saveAsRevisionMenuItem.Image"), System.Drawing.Image)
        Me.saveAsRevisionMenuItem.Name = "saveAsRevisionMenuItem"
        Me.saveAsRevisionMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.saveAsRevisionMenuItem.Text = "Save as Revision"
        '
        'separator2
        '
        Me.separator2.Name = "separator2"
        Me.separator2.Size = New System.Drawing.Size(197, 6)
        '
        'convertToEquipmentMenuItem
        '
        Me.convertToEquipmentMenuItem.Image = CType(resources.GetObject("convertToEquipmentMenuItem.Image"), System.Drawing.Image)
        Me.convertToEquipmentMenuItem.Name = "convertToEquipmentMenuItem"
        Me.convertToEquipmentMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.convertToEquipmentMenuItem.Text = "Convert to Equipment..."
        Me.convertToEquipmentMenuItem.Visible = False
        '
        'separator1
        '
        Me.separator1.Name = "separator1"
        Me.separator1.Size = New System.Drawing.Size(197, 6)
        Me.separator1.Visible = False
        '
        'printMenuItem
        '
        Me.printMenuItem.Image = CType(resources.GetObject("printMenuItem.Image"), System.Drawing.Image)
        Me.printMenuItem.Name = "printMenuItem"
        Me.printMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.printMenuItem.Text = "Print"
        '
        'panUnitCoolerSpec
        '
        Me.panUnitCoolerSpec.Controls.Add(Me.Label4)
        Me.panUnitCoolerSpec.Controls.Add(Me.cbo_unit_cooler_series)
        Me.panUnitCoolerSpec.Controls.Add(Me.cbo_suction_line_loss)
        Me.panUnitCoolerSpec.Controls.Add(Me.lblSuctionLineLoss)
        Me.panUnitCoolerSpec.Controls.Add(Me.lblUnitCoolerSeries)
        Me.panUnitCoolerSpec.Dock = System.Windows.Forms.DockStyle.Top
        Me.panUnitCoolerSpec.Location = New System.Drawing.Point(0, 968)
        Me.panUnitCoolerSpec.Name = "panUnitCoolerSpec"
        Me.panUnitCoolerSpec.Size = New System.Drawing.Size(625, 60)
        Me.panUnitCoolerSpec.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label4.Location = New System.Drawing.Point(289, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 21)
        Me.Label4.TabIndex = 94
        Me.Label4.Text = "[°F]"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'panUnitCoolGrid
        '
        Me.panUnitCoolGrid.Controls.Add(Me.DataGridView1)
        Me.panUnitCoolGrid.Controls.Add(Me.chk_unit_cooler_override)
        Me.panUnitCoolGrid.Controls.Add(Me.btn_find_unit_coolers)
        Me.panUnitCoolGrid.Dock = System.Windows.Forms.DockStyle.Top
        Me.panUnitCoolGrid.Location = New System.Drawing.Point(0, 1028)
        Me.panUnitCoolGrid.Name = "panUnitCoolGrid"
        Me.panUnitCoolGrid.Size = New System.Drawing.Size(625, 323)
        Me.panUnitCoolGrid.TabIndex = 3
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(20, 40)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(539, 267)
        Me.DataGridView1.TabIndex = 72
        Me.DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.MultiSelect = False
        '
        'chk_unit_cooler_override
        '
        Me.chk_unit_cooler_override.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chk_unit_cooler_override.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_unit_cooler_override.Location = New System.Drawing.Point(199, 5)
        Me.chk_unit_cooler_override.Name = "chk_unit_cooler_override"
        Me.chk_unit_cooler_override.Size = New System.Drawing.Size(260, 24)
        Me.chk_unit_cooler_override.TabIndex = 32
        Me.chk_unit_cooler_override.Text = "Override unit cooler capacity criteria"
        '
        'grdCoolerView
        '
        Me.grdCoolerView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCoolerView.Location = New System.Drawing.Point(13, 63)
        Me.grdCoolerView.MultiSelect = False
        Me.grdCoolerView.Name = "grdCoolerView"
        Me.grdCoolerView.Size = New System.Drawing.Size(562, 287)
        Me.grdCoolerView.TabIndex = 71
        Me.grdCoolerView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.grdCoolerView.MultiSelect = False
        '
        'panRate
        '
        Me.panRate.Controls.Add(Me.txt_unit_cooler_DOE_3)
        Me.panRate.Controls.Add(Me.txt_unit_cooler_DOE_2)
        Me.panRate.Controls.Add(Me.txt_unit_cooler_DOE_1)
        Me.panRate.Controls.Add(Me.pan_static_pressure_3)
        Me.panRate.Controls.Add(Me.pan_static_pressure_2)
        Me.panRate.Controls.Add(Me.lbl_static_pressure)
        Me.panRate.Controls.Add(Me.pan_static_pressure_1)
        Me.panRate.Controls.Add(Me.lblEvaporatorCapacity)
        Me.panRate.Controls.Add(Me.txt_custom_uc_model)
        Me.panRate.Controls.Add(Me.txt_custom_uc_capacity)
        Me.panRate.Controls.Add(Me.txt_custom_uc_quantity)
        Me.panRate.Controls.Add(Me.txt_evaporator_capacity_per_degree_3)
        Me.panRate.Controls.Add(Me.txt_custom_evaporator_capacity)
        Me.panRate.Controls.Add(Me.txt_evaporator_capacity_per_degree_2)
        Me.panRate.Controls.Add(Me.txt_evaporator_capacity_per_degree_1)
        Me.panRate.Controls.Add(Me.txt_unit_cooler_capacity_3)
        Me.panRate.Controls.Add(Me.txt_unit_cooler_capacity_2)
        Me.panRate.Controls.Add(Me.txt_unit_cooler_capacity_1)
        Me.panRate.Controls.Add(Me.Label5)
        Me.panRate.Controls.Add(Me.txt_unit_cooler_quantity_1)
        Me.panRate.Controls.Add(Me.txt_unit_cooler_quantity_2)
        Me.panRate.Controls.Add(Me.txt_unit_cooler_quantity_3)
        Me.panRate.Controls.Add(Me.lbl_BTUH_Balance)
        Me.panRate.Controls.Add(Me.btn_clear_unit_cooler_2)
        Me.panRate.Controls.Add(Me.btn_clear_unit_cooler_1)
        Me.panRate.Controls.Add(Me.btn_clear_unit_cooler_3)
        Me.panRate.Controls.Add(Me.txt_unit_cooler_model_1)
        Me.panRate.Controls.Add(Me.txt_unit_cooler_model_2)
        Me.panRate.Controls.Add(Me.txt_unit_cooler_model_3)
        Me.panRate.Controls.Add(Me.lbl_Model_Number)
        Me.panRate.Controls.Add(Me.Panel2)
        Me.panRate.Controls.Add(Me.txt_balance)
        Me.panRate.Controls.Add(Me.lblUCCapacity)
        Me.panRate.Controls.Add(Me.lbl_Qty_Required)
        Me.panRate.Controls.Add(Me.chk_custom_unit_cooler)
        Me.panRate.Dock = System.Windows.Forms.DockStyle.Top
        Me.panRate.Location = New System.Drawing.Point(0, 1351)
        Me.panRate.Name = "panRate"
        Me.panRate.Size = New System.Drawing.Size(625, 216)
        Me.panRate.TabIndex = 4
        '
        'txt_unit_cooler_DOE_3
        '
        Me.txt_unit_cooler_DOE_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_unit_cooler_DOE_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_unit_cooler_DOE_3.Location = New System.Drawing.Point(568, 136)
        Me.txt_unit_cooler_DOE_3.Name = "txt_unit_cooler_DOE_3"
        Me.txt_unit_cooler_DOE_3.ReadOnly = True
        Me.txt_unit_cooler_DOE_3.Size = New System.Drawing.Size(57, 21)
        Me.txt_unit_cooler_DOE_3.TabIndex = 116
        Me.txt_unit_cooler_DOE_3.TabStop = False
        Me.txt_unit_cooler_DOE_3.Visible = False
        '
        'txt_unit_cooler_DOE_2
        '
        Me.txt_unit_cooler_DOE_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_unit_cooler_DOE_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_unit_cooler_DOE_2.Location = New System.Drawing.Point(448, 124)
        Me.txt_unit_cooler_DOE_2.Name = "txt_unit_cooler_DOE_2"
        Me.txt_unit_cooler_DOE_2.ReadOnly = True
        Me.txt_unit_cooler_DOE_2.Size = New System.Drawing.Size(57, 21)
        Me.txt_unit_cooler_DOE_2.TabIndex = 115
        Me.txt_unit_cooler_DOE_2.TabStop = False
        Me.txt_unit_cooler_DOE_2.Visible = False
        '
        'txt_unit_cooler_DOE_1
        '
        Me.txt_unit_cooler_DOE_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_unit_cooler_DOE_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_unit_cooler_DOE_1.Location = New System.Drawing.Point(514, 114)
        Me.txt_unit_cooler_DOE_1.Name = "txt_unit_cooler_DOE_1"
        Me.txt_unit_cooler_DOE_1.ReadOnly = True
        Me.txt_unit_cooler_DOE_1.Size = New System.Drawing.Size(57, 21)
        Me.txt_unit_cooler_DOE_1.TabIndex = 114
        Me.txt_unit_cooler_DOE_1.TabStop = False
        Me.txt_unit_cooler_DOE_1.Visible = False
        '
        'pan_static_pressure_3
        '
        Me.pan_static_pressure_3.Controls.Add(Me.rbo_050_static_3)
        Me.pan_static_pressure_3.Controls.Add(Me.rbo_025_static_3)
        Me.pan_static_pressure_3.Controls.Add(Me.rbo_0_static_3)
        Me.pan_static_pressure_3.Location = New System.Drawing.Point(466, 85)
        Me.pan_static_pressure_3.Name = "pan_static_pressure_3"
        Me.pan_static_pressure_3.Size = New System.Drawing.Size(157, 23)
        Me.pan_static_pressure_3.TabIndex = 113
        '
        'rbo_050_static_3
        '
        Me.rbo_050_static_3.AutoSize = True
        Me.rbo_050_static_3.Location = New System.Drawing.Point(108, 5)
        Me.rbo_050_static_3.Name = "rbo_050_static_3"
        Me.rbo_050_static_3.Size = New System.Drawing.Size(45, 17)
        Me.rbo_050_static_3.TabIndex = 0
        Me.rbo_050_static_3.Tag = "0.5"
        Me.rbo_050_static_3.Text = "0.5"""
        Me.rbo_050_static_3.UseVisualStyleBackColor = True
        Me.rbo_050_static_3.Visible = False
        '
        'rbo_025_static_3
        '
        Me.rbo_025_static_3.AutoSize = True
        Me.rbo_025_static_3.Location = New System.Drawing.Point(48, 5)
        Me.rbo_025_static_3.Name = "rbo_025_static_3"
        Me.rbo_025_static_3.Size = New System.Drawing.Size(51, 17)
        Me.rbo_025_static_3.TabIndex = 0
        Me.rbo_025_static_3.Tag = "0.25"
        Me.rbo_025_static_3.Text = "0.25"""
        Me.rbo_025_static_3.UseVisualStyleBackColor = True
        Me.rbo_025_static_3.Visible = False
        '
        'rbo_0_static_3
        '
        Me.rbo_0_static_3.AutoSize = True
        Me.rbo_0_static_3.Checked = True
        Me.rbo_0_static_3.Location = New System.Drawing.Point(4, 5)
        Me.rbo_0_static_3.Name = "rbo_0_static_3"
        Me.rbo_0_static_3.Size = New System.Drawing.Size(35, 17)
        Me.rbo_0_static_3.TabIndex = 0
        Me.rbo_0_static_3.TabStop = True
        Me.rbo_0_static_3.Tag = "0"
        Me.rbo_0_static_3.Text = "0"""
        Me.rbo_0_static_3.UseVisualStyleBackColor = True
        Me.rbo_0_static_3.Visible = False
        '
        'pan_static_pressure_2
        '
        Me.pan_static_pressure_2.Controls.Add(Me.rbo_050_static_2)
        Me.pan_static_pressure_2.Controls.Add(Me.rbo_025_static_2)
        Me.pan_static_pressure_2.Controls.Add(Me.rbo_0_static_2)
        Me.pan_static_pressure_2.Location = New System.Drawing.Point(466, 59)
        Me.pan_static_pressure_2.Name = "pan_static_pressure_2"
        Me.pan_static_pressure_2.Size = New System.Drawing.Size(157, 23)
        Me.pan_static_pressure_2.TabIndex = 112
        '
        'rbo_050_static_2
        '
        Me.rbo_050_static_2.AutoSize = True
        Me.rbo_050_static_2.Location = New System.Drawing.Point(108, 5)
        Me.rbo_050_static_2.Name = "rbo_050_static_2"
        Me.rbo_050_static_2.Size = New System.Drawing.Size(45, 17)
        Me.rbo_050_static_2.TabIndex = 0
        Me.rbo_050_static_2.Tag = "0.5"
        Me.rbo_050_static_2.Text = "0.5"""
        Me.rbo_050_static_2.UseVisualStyleBackColor = True
        Me.rbo_050_static_2.Visible = False
        '
        'rbo_025_static_2
        '
        Me.rbo_025_static_2.AutoSize = True
        Me.rbo_025_static_2.Location = New System.Drawing.Point(48, 5)
        Me.rbo_025_static_2.Name = "rbo_025_static_2"
        Me.rbo_025_static_2.Size = New System.Drawing.Size(51, 17)
        Me.rbo_025_static_2.TabIndex = 0
        Me.rbo_025_static_2.Tag = "0.25"
        Me.rbo_025_static_2.Text = "0.25"""
        Me.rbo_025_static_2.UseVisualStyleBackColor = True
        Me.rbo_025_static_2.Visible = False
        '
        'rbo_0_static_2
        '
        Me.rbo_0_static_2.AutoSize = True
        Me.rbo_0_static_2.Checked = True
        Me.rbo_0_static_2.Location = New System.Drawing.Point(4, 5)
        Me.rbo_0_static_2.Name = "rbo_0_static_2"
        Me.rbo_0_static_2.Size = New System.Drawing.Size(35, 17)
        Me.rbo_0_static_2.TabIndex = 0
        Me.rbo_0_static_2.TabStop = True
        Me.rbo_0_static_2.Tag = "0"
        Me.rbo_0_static_2.Text = "0"""
        Me.rbo_0_static_2.UseVisualStyleBackColor = True
        Me.rbo_0_static_2.Visible = False
        '
        'lbl_static_pressure
        '
        Me.lbl_static_pressure.AutoSize = True
        Me.lbl_static_pressure.Location = New System.Drawing.Point(502, 19)
        Me.lbl_static_pressure.Name = "lbl_static_pressure"
        Me.lbl_static_pressure.Size = New System.Drawing.Size(79, 13)
        Me.lbl_static_pressure.TabIndex = 1
        Me.lbl_static_pressure.Text = "Static Pressure"
        '
        'pan_static_pressure_1
        '
        Me.pan_static_pressure_1.Controls.Add(Me.rbo_050_static_1)
        Me.pan_static_pressure_1.Controls.Add(Me.rbo_025_static_1)
        Me.pan_static_pressure_1.Controls.Add(Me.rbo_0_static_1)
        Me.pan_static_pressure_1.Location = New System.Drawing.Point(466, 34)
        Me.pan_static_pressure_1.Name = "pan_static_pressure_1"
        Me.pan_static_pressure_1.Size = New System.Drawing.Size(157, 23)
        Me.pan_static_pressure_1.TabIndex = 111
        '
        'rbo_050_static_1
        '
        Me.rbo_050_static_1.AutoSize = True
        Me.rbo_050_static_1.Location = New System.Drawing.Point(108, 5)
        Me.rbo_050_static_1.Name = "rbo_050_static_1"
        Me.rbo_050_static_1.Size = New System.Drawing.Size(45, 17)
        Me.rbo_050_static_1.TabIndex = 0
        Me.rbo_050_static_1.Tag = "0.5"
        Me.rbo_050_static_1.Text = "0.5"""
        Me.rbo_050_static_1.UseVisualStyleBackColor = True
        Me.rbo_050_static_1.Visible = False
        '
        'rbo_025_static_1
        '
        Me.rbo_025_static_1.AutoSize = True
        Me.rbo_025_static_1.Location = New System.Drawing.Point(48, 5)
        Me.rbo_025_static_1.Name = "rbo_025_static_1"
        Me.rbo_025_static_1.Size = New System.Drawing.Size(51, 17)
        Me.rbo_025_static_1.TabIndex = 0
        Me.rbo_025_static_1.Tag = "0.25"
        Me.rbo_025_static_1.Text = "0.25"""
        Me.rbo_025_static_1.UseVisualStyleBackColor = True
        Me.rbo_025_static_1.Visible = False
        '
        'rbo_0_static_1
        '
        Me.rbo_0_static_1.AutoSize = True
        Me.rbo_0_static_1.Checked = True
        Me.rbo_0_static_1.Location = New System.Drawing.Point(4, 5)
        Me.rbo_0_static_1.Name = "rbo_0_static_1"
        Me.rbo_0_static_1.Size = New System.Drawing.Size(35, 17)
        Me.rbo_0_static_1.TabIndex = 0
        Me.rbo_0_static_1.TabStop = True
        Me.rbo_0_static_1.Tag = "0"
        Me.rbo_0_static_1.Text = "0"""
        Me.rbo_0_static_1.UseVisualStyleBackColor = True
        Me.rbo_0_static_1.Visible = False
        '
        'lblEvaporatorCapacity
        '
        Me.lblEvaporatorCapacity.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEvaporatorCapacity.Location = New System.Drawing.Point(353, 4)
        Me.lblEvaporatorCapacity.Name = "lblEvaporatorCapacity"
        Me.lblEvaporatorCapacity.Size = New System.Drawing.Size(113, 29)
        Me.lblEvaporatorCapacity.TabIndex = 102
        Me.lblEvaporatorCapacity.Text = "Evaporator Est. Capacity Per Degree"
        Me.lblEvaporatorCapacity.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txt_custom_uc_model
        '
        Me.txt_custom_uc_model.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_custom_uc_model.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_custom_uc_model.Location = New System.Drawing.Point(136, 112)
        Me.txt_custom_uc_model.Name = "txt_custom_uc_model"
        Me.txt_custom_uc_model.Size = New System.Drawing.Size(108, 21)
        Me.txt_custom_uc_model.TabIndex = 37
        '
        'txt_custom_uc_capacity
        '
        Me.txt_custom_uc_capacity.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_custom_uc_capacity.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_custom_uc_capacity.Location = New System.Drawing.Point(248, 112)
        Me.txt_custom_uc_capacity.Name = "txt_custom_uc_capacity"
        Me.txt_custom_uc_capacity.Size = New System.Drawing.Size(57, 21)
        Me.txt_custom_uc_capacity.TabIndex = 38
        Me.txt_custom_uc_capacity.Text = "0"
        '
        'txt_custom_uc_quantity
        '
        Me.txt_custom_uc_quantity.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_custom_uc_quantity.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_custom_uc_quantity.Location = New System.Drawing.Point(308, 112)
        Me.txt_custom_uc_quantity.Name = "txt_custom_uc_quantity"
        Me.txt_custom_uc_quantity.Size = New System.Drawing.Size(42, 21)
        Me.txt_custom_uc_quantity.TabIndex = 39
        Me.txt_custom_uc_quantity.Tag = "0"
        Me.txt_custom_uc_quantity.Text = "0"
        '
        'txt_evaporator_capacity_per_degree_3
        '
        Me.txt_evaporator_capacity_per_degree_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_evaporator_capacity_per_degree_3.Location = New System.Drawing.Point(353, 87)
        Me.txt_evaporator_capacity_per_degree_3.Name = "txt_evaporator_capacity_per_degree_3"
        Me.txt_evaporator_capacity_per_degree_3.ReadOnly = True
        Me.txt_evaporator_capacity_per_degree_3.Size = New System.Drawing.Size(49, 21)
        Me.txt_evaporator_capacity_per_degree_3.TabIndex = 106
        Me.txt_evaporator_capacity_per_degree_3.TabStop = False
        Me.txt_evaporator_capacity_per_degree_3.Text = "0"
        '
        'txt_custom_evaporator_capacity
        '
        Me.txt_custom_evaporator_capacity.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_custom_evaporator_capacity.Location = New System.Drawing.Point(353, 112)
        Me.txt_custom_evaporator_capacity.Name = "txt_custom_evaporator_capacity"
        Me.txt_custom_evaporator_capacity.Size = New System.Drawing.Size(49, 21)
        Me.txt_custom_evaporator_capacity.TabIndex = 40
        Me.txt_custom_evaporator_capacity.Text = "0"
        '
        'txt_evaporator_capacity_per_degree_2
        '
        Me.txt_evaporator_capacity_per_degree_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_evaporator_capacity_per_degree_2.Location = New System.Drawing.Point(353, 61)
        Me.txt_evaporator_capacity_per_degree_2.Name = "txt_evaporator_capacity_per_degree_2"
        Me.txt_evaporator_capacity_per_degree_2.ReadOnly = True
        Me.txt_evaporator_capacity_per_degree_2.Size = New System.Drawing.Size(49, 21)
        Me.txt_evaporator_capacity_per_degree_2.TabIndex = 104
        Me.txt_evaporator_capacity_per_degree_2.TabStop = False
        Me.txt_evaporator_capacity_per_degree_2.Text = "0"
        '
        'txt_evaporator_capacity_per_degree_1
        '
        Me.txt_evaporator_capacity_per_degree_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_evaporator_capacity_per_degree_1.Location = New System.Drawing.Point(353, 35)
        Me.txt_evaporator_capacity_per_degree_1.Name = "txt_evaporator_capacity_per_degree_1"
        Me.txt_evaporator_capacity_per_degree_1.ReadOnly = True
        Me.txt_evaporator_capacity_per_degree_1.Size = New System.Drawing.Size(49, 21)
        Me.txt_evaporator_capacity_per_degree_1.TabIndex = 103
        Me.txt_evaporator_capacity_per_degree_1.TabStop = False
        Me.txt_evaporator_capacity_per_degree_1.Text = "0"
        '
        'txt_unit_cooler_capacity_3
        '
        Me.txt_unit_cooler_capacity_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_unit_cooler_capacity_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_unit_cooler_capacity_3.Location = New System.Drawing.Point(248, 87)
        Me.txt_unit_cooler_capacity_3.Name = "txt_unit_cooler_capacity_3"
        Me.txt_unit_cooler_capacity_3.ReadOnly = True
        Me.txt_unit_cooler_capacity_3.Size = New System.Drawing.Size(57, 21)
        Me.txt_unit_cooler_capacity_3.TabIndex = 101
        Me.txt_unit_cooler_capacity_3.TabStop = False
        Me.txt_unit_cooler_capacity_3.Text = "0"
        '
        'txt_unit_cooler_capacity_2
        '
        Me.txt_unit_cooler_capacity_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_unit_cooler_capacity_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_unit_cooler_capacity_2.Location = New System.Drawing.Point(248, 61)
        Me.txt_unit_cooler_capacity_2.Name = "txt_unit_cooler_capacity_2"
        Me.txt_unit_cooler_capacity_2.ReadOnly = True
        Me.txt_unit_cooler_capacity_2.Size = New System.Drawing.Size(57, 21)
        Me.txt_unit_cooler_capacity_2.TabIndex = 100
        Me.txt_unit_cooler_capacity_2.TabStop = False
        Me.txt_unit_cooler_capacity_2.Text = "0"
        '
        'txt_unit_cooler_capacity_1
        '
        Me.txt_unit_cooler_capacity_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_unit_cooler_capacity_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_unit_cooler_capacity_1.Location = New System.Drawing.Point(248, 35)
        Me.txt_unit_cooler_capacity_1.Name = "txt_unit_cooler_capacity_1"
        Me.txt_unit_cooler_capacity_1.ReadOnly = True
        Me.txt_unit_cooler_capacity_1.Size = New System.Drawing.Size(57, 21)
        Me.txt_unit_cooler_capacity_1.TabIndex = 99
        Me.txt_unit_cooler_capacity_1.TabStop = False
        Me.txt_unit_cooler_capacity_1.Text = "0"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label5.Location = New System.Drawing.Point(309, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 26)
        Me.Label5.TabIndex = 97
        Me.Label5.Text = "[BTUH]"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUCCapacity
        '
        Me.lblUCCapacity.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUCCapacity.Location = New System.Drawing.Point(248, 4)
        Me.lblUCCapacity.Name = "lblUCCapacity"
        Me.lblUCCapacity.Size = New System.Drawing.Size(61, 29)
        Me.lblUCCapacity.TabIndex = 98
        Me.lblUCCapacity.Text = "Est. Capacity"
        Me.lblUCCapacity.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'chk_custom_unit_cooler
        '
        Me.chk_custom_unit_cooler.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chk_custom_unit_cooler.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_custom_unit_cooler.Location = New System.Drawing.Point(23, 111)
        Me.chk_custom_unit_cooler.Name = "chk_custom_unit_cooler"
        Me.chk_custom_unit_cooler.Size = New System.Drawing.Size(124, 24)
        Me.chk_custom_unit_cooler.TabIndex = 110
        Me.chk_custom_unit_cooler.TabStop = False
        Me.chk_custom_unit_cooler.Text = "Custom unit cooler"
        '
        'txt_condensing_unit_DOE_1
        '
        Me.txt_condensing_unit_DOE_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_condensing_unit_DOE_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_condensing_unit_DOE_1.Location = New System.Drawing.Point(168, 314)
        Me.txt_condensing_unit_DOE_1.Name = "txt_condensing_unit_DOE_1"
        Me.txt_condensing_unit_DOE_1.ReadOnly = True
        Me.txt_condensing_unit_DOE_1.Size = New System.Drawing.Size(57, 21)
        Me.txt_condensing_unit_DOE_1.TabIndex = 117
        Me.txt_condensing_unit_DOE_1.TabStop = False
        Me.txt_condensing_unit_DOE_1.Text = "  "
        Me.txt_condensing_unit_DOE_1.Visible = False
        '
        'panBalaGrid
        '
        Me.panBalaGrid.Controls.Add(Me.Label2)
        Me.panBalaGrid.Controls.Add(Me.btn_convert_to_pricing)
        Me.panBalaGrid.Controls.Add(Me.grdCoolerView)
        Me.panBalaGrid.Controls.Add(Me.btn_print)
        Me.panBalaGrid.Controls.Add(Me.btn_show_report)
        Me.panBalaGrid.Controls.Add(Me.btn_balance)
        Me.panBalaGrid.Dock = System.Windows.Forms.DockStyle.Top
        Me.panBalaGrid.Location = New System.Drawing.Point(0, 1567)
        Me.panBalaGrid.Name = "panBalaGrid"
        Me.panBalaGrid.Size = New System.Drawing.Size(625, 356)
        Me.panBalaGrid.TabIndex = 5
        '
        'btn_convert_to_pricing
        '
        Me.btn_convert_to_pricing.BackColor = System.Drawing.Color.White
        Me.btn_convert_to_pricing.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_convert_to_pricing.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_convert_to_pricing.ForeColor = System.Drawing.Color.Navy
        Me.btn_convert_to_pricing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_convert_to_pricing.Location = New System.Drawing.Point(316, 2)
        Me.btn_convert_to_pricing.Name = "btn_convert_to_pricing"
        Me.btn_convert_to_pricing.Size = New System.Drawing.Size(189, 32)
        Me.btn_convert_to_pricing.TabIndex = 82
        Me.btn_convert_to_pricing.Text = "Convert to Pricing (beta)"
        Me.btn_convert_to_pricing.UseVisualStyleBackColor = False
        '
        'btn_print
        '
        Me.btn_print.BackColor = System.Drawing.Color.White
        Me.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_print.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_print.ForeColor = System.Drawing.Color.MidnightBlue
        Me.btn_print.Location = New System.Drawing.Point(522, 2)
        Me.btn_print.Name = "btn_print"
        Me.btn_print.Size = New System.Drawing.Size(58, 32)
        Me.btn_print.TabIndex = 81
        Me.btn_print.Text = "Print"
        Me.btn_print.UseVisualStyleBackColor = False
        Me.btn_print.Visible = False
        '
        'panFooter
        '
        Me.panFooter.BackColor = System.Drawing.Color.White
        Me.panFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panFooter.Controls.Add(Me.lblErrors)
        Me.panFooter.Controls.Add(Me.picError)
        Me.panFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panFooter.Location = New System.Drawing.Point(0, 599)
        Me.panFooter.Name = "panFooter"
        Me.panFooter.Size = New System.Drawing.Size(642, 34)
        Me.panFooter.TabIndex = 103
        Me.panFooter.Visible = False
        '
        'panMain
        '
        Me.panMain.AutoScroll = True
        Me.panMain.Controls.Add(Me.panBalaGrid)
        Me.panMain.Controls.Add(Me.panRate)
        Me.panMain.Controls.Add(Me.panUnitCoolGrid)
        Me.panMain.Controls.Add(Me.panUnitCoolerSpec)
        Me.panMain.Controls.Add(Me.panCondensingUnitDataBody)
        Me.panMain.Controls.Add(Me.panCondensingUnitSpecBody)
        Me.panMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panMain.Location = New System.Drawing.Point(0, 0)
        Me.panMain.Name = "panMain"
        Me.panMain.Size = New System.Drawing.Size(642, 599)
        Me.panMain.TabIndex = 104
        '
        'panCondensingUnitDataBody
        '
        Me.panCondensingUnitDataBody.Controls.Add(Me.txt_condensing_unit_DOE_3)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txt_condensing_unit_DOE_2)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txt_condensing_unit_DOE_1)
        Me.panCondensingUnitDataBody.Controls.Add(Me.Label9)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtBaseListPrice3)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtDimensions3)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtUnitMCA4603)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtUnitMCA2303)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtTD3)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtUnitEER3)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtUnitAmps4603)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtUnitAmps2303)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtCondenserCapacity33)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtUnitKW3)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtRunTime3)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtCapacity3)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtCondenserTemperature3)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtAirTemperature3)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtEvaporatorTemperature3)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtCondensingUnitModel3)
        Me.panCondensingUnitDataBody.Controls.Add(Me.Label8)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtBaseListPrice2)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtDimensions2)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtUnitMCA4602)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtUnitMCA2302)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtTD2)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtUnitEER2)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtUnitAmps4602)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtUnitAmps2302)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtCondenserCapacity22)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtUnitKW2)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtRunTime2)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtCapacity2)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtCondenserTemperature2)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtAirTemperature2)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtEvaporatorTemperature2)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtCondensingUnitModel2)
        Me.panCondensingUnitDataBody.Controls.Add(Me.Label7)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtBaseListPrice1)
        Me.panCondensingUnitDataBody.Controls.Add(Me.lblBaseListPrice)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtDimensions1)
        Me.panCondensingUnitDataBody.Controls.Add(Me.lblDimensions)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtUnitMCA4601)
        Me.panCondensingUnitDataBody.Controls.Add(Me.lblUnitMCA460)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtUnitMCA2301)
        Me.panCondensingUnitDataBody.Controls.Add(Me.lblUnitMCA230)
        Me.panCondensingUnitDataBody.Controls.Add(Me.lblTD)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtTD1)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtUnitEER1)
        Me.panCondensingUnitDataBody.Controls.Add(Me.lblUnitEER)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtUnitAmps4601)
        Me.panCondensingUnitDataBody.Controls.Add(Me.lblUnitAmps460)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtUnitAmps2301)
        Me.panCondensingUnitDataBody.Controls.Add(Me.lblUnitAmps230)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtCondenserCapacity11)
        Me.panCondensingUnitDataBody.Controls.Add(Me.lblCondenserCapacity)
        Me.panCondensingUnitDataBody.Controls.Add(Me.lblUnitKW)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtUnitKW1)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtRunTime1)
        Me.panCondensingUnitDataBody.Controls.Add(Me.lblRunTime)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtCapacity1)
        Me.panCondensingUnitDataBody.Controls.Add(Me.lblCapacity)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtCondenserTemperature1)
        Me.panCondensingUnitDataBody.Controls.Add(Me.lblCondenserTemperature)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtAirTemperature1)
        Me.panCondensingUnitDataBody.Controls.Add(Me.lblAirTemperature)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtEvaporatorTemperature1)
        Me.panCondensingUnitDataBody.Controls.Add(Me.lblEvaporatorTemperature)
        Me.panCondensingUnitDataBody.Controls.Add(Me.txtCondensingUnitModel1)
        Me.panCondensingUnitDataBody.Controls.Add(Me.lblCondensingUnitModel)
        Me.panCondensingUnitDataBody.Dock = System.Windows.Forms.DockStyle.Top
        Me.panCondensingUnitDataBody.Location = New System.Drawing.Point(0, 526)
        Me.panCondensingUnitDataBody.Name = "panCondensingUnitDataBody"
        Me.panCondensingUnitDataBody.Size = New System.Drawing.Size(625, 442)
        Me.panCondensingUnitDataBody.TabIndex = 104
        '
        'txt_condensing_unit_DOE_3
        '
        Me.txt_condensing_unit_DOE_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_condensing_unit_DOE_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_condensing_unit_DOE_3.Location = New System.Drawing.Point(437, 314)
        Me.txt_condensing_unit_DOE_3.Name = "txt_condensing_unit_DOE_3"
        Me.txt_condensing_unit_DOE_3.ReadOnly = True
        Me.txt_condensing_unit_DOE_3.Size = New System.Drawing.Size(57, 21)
        Me.txt_condensing_unit_DOE_3.TabIndex = 119
        Me.txt_condensing_unit_DOE_3.TabStop = False
        Me.txt_condensing_unit_DOE_3.Text = "  "
        Me.txt_condensing_unit_DOE_3.Visible = False
        '
        'txt_condensing_unit_DOE_2
        '
        Me.txt_condensing_unit_DOE_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_condensing_unit_DOE_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_condensing_unit_DOE_2.Location = New System.Drawing.Point(304, 314)
        Me.txt_condensing_unit_DOE_2.Name = "txt_condensing_unit_DOE_2"
        Me.txt_condensing_unit_DOE_2.ReadOnly = True
        Me.txt_condensing_unit_DOE_2.Size = New System.Drawing.Size(57, 21)
        Me.txt_condensing_unit_DOE_2.TabIndex = 118
        Me.txt_condensing_unit_DOE_2.TabStop = False
        Me.txt_condensing_unit_DOE_2.Text = "  "
        Me.txt_condensing_unit_DOE_2.Visible = False
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(434, 2)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 33)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "Next Smaller Selection"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txtBaseListPrice3
        '
        Me.txtBaseListPrice3.Location = New System.Drawing.Point(433, 412)
        Me.txtBaseListPrice3.Name = "txtBaseListPrice3"
        Me.txtBaseListPrice3.ReadOnly = True
        Me.txtBaseListPrice3.Size = New System.Drawing.Size(106, 21)
        Me.txtBaseListPrice3.TabIndex = 65
        Me.txtBaseListPrice3.TabStop = False
        '
        'txtDimensions3
        '
        Me.txtDimensions3.Location = New System.Drawing.Point(433, 387)
        Me.txtDimensions3.Name = "txtDimensions3"
        Me.txtDimensions3.ReadOnly = True
        Me.txtDimensions3.Size = New System.Drawing.Size(106, 21)
        Me.txtDimensions3.TabIndex = 64
        Me.txtDimensions3.TabStop = False
        '
        'txtUnitMCA4603
        '
        Me.txtUnitMCA4603.Location = New System.Drawing.Point(433, 362)
        Me.txtUnitMCA4603.Name = "txtUnitMCA4603"
        Me.txtUnitMCA4603.ReadOnly = True
        Me.txtUnitMCA4603.Size = New System.Drawing.Size(106, 21)
        Me.txtUnitMCA4603.TabIndex = 63
        Me.txtUnitMCA4603.TabStop = False
        '
        'txtUnitMCA2303
        '
        Me.txtUnitMCA2303.Location = New System.Drawing.Point(433, 337)
        Me.txtUnitMCA2303.Name = "txtUnitMCA2303"
        Me.txtUnitMCA2303.ReadOnly = True
        Me.txtUnitMCA2303.Size = New System.Drawing.Size(106, 21)
        Me.txtUnitMCA2303.TabIndex = 62
        Me.txtUnitMCA2303.TabStop = False
        '
        'txtTD3
        '
        Me.txtTD3.Location = New System.Drawing.Point(433, 312)
        Me.txtTD3.Name = "txtTD3"
        Me.txtTD3.ReadOnly = True
        Me.txtTD3.Size = New System.Drawing.Size(106, 21)
        Me.txtTD3.TabIndex = 61
        Me.txtTD3.TabStop = False
        '
        'txtUnitEER3
        '
        Me.txtUnitEER3.Location = New System.Drawing.Point(433, 287)
        Me.txtUnitEER3.Name = "txtUnitEER3"
        Me.txtUnitEER3.ReadOnly = True
        Me.txtUnitEER3.Size = New System.Drawing.Size(106, 21)
        Me.txtUnitEER3.TabIndex = 60
        Me.txtUnitEER3.TabStop = False
        '
        'txtUnitAmps4603
        '
        Me.txtUnitAmps4603.Location = New System.Drawing.Point(433, 262)
        Me.txtUnitAmps4603.Name = "txtUnitAmps4603"
        Me.txtUnitAmps4603.ReadOnly = True
        Me.txtUnitAmps4603.Size = New System.Drawing.Size(106, 21)
        Me.txtUnitAmps4603.TabIndex = 59
        Me.txtUnitAmps4603.TabStop = False
        '
        'txtUnitAmps2303
        '
        Me.txtUnitAmps2303.Location = New System.Drawing.Point(433, 237)
        Me.txtUnitAmps2303.Name = "txtUnitAmps2303"
        Me.txtUnitAmps2303.ReadOnly = True
        Me.txtUnitAmps2303.Size = New System.Drawing.Size(106, 21)
        Me.txtUnitAmps2303.TabIndex = 58
        Me.txtUnitAmps2303.TabStop = False
        '
        'txtCondenserCapacity33
        '
        Me.txtCondenserCapacity33.Location = New System.Drawing.Point(433, 212)
        Me.txtCondenserCapacity33.Name = "txtCondenserCapacity33"
        Me.txtCondenserCapacity33.ReadOnly = True
        Me.txtCondenserCapacity33.Size = New System.Drawing.Size(106, 21)
        Me.txtCondenserCapacity33.TabIndex = 57
        Me.txtCondenserCapacity33.TabStop = False
        '
        'txtUnitKW3
        '
        Me.txtUnitKW3.Location = New System.Drawing.Point(433, 187)
        Me.txtUnitKW3.Name = "txtUnitKW3"
        Me.txtUnitKW3.ReadOnly = True
        Me.txtUnitKW3.Size = New System.Drawing.Size(106, 21)
        Me.txtUnitKW3.TabIndex = 56
        Me.txtUnitKW3.TabStop = False
        '
        'txtRunTime3
        '
        Me.txtRunTime3.Location = New System.Drawing.Point(433, 162)
        Me.txtRunTime3.Name = "txtRunTime3"
        Me.txtRunTime3.ReadOnly = True
        Me.txtRunTime3.Size = New System.Drawing.Size(106, 21)
        Me.txtRunTime3.TabIndex = 55
        Me.txtRunTime3.TabStop = False
        '
        'txtCapacity3
        '
        Me.txtCapacity3.Location = New System.Drawing.Point(433, 137)
        Me.txtCapacity3.Name = "txtCapacity3"
        Me.txtCapacity3.ReadOnly = True
        Me.txtCapacity3.Size = New System.Drawing.Size(106, 21)
        Me.txtCapacity3.TabIndex = 54
        Me.txtCapacity3.TabStop = False
        '
        'txtCondenserTemperature3
        '
        Me.txtCondenserTemperature3.Location = New System.Drawing.Point(433, 112)
        Me.txtCondenserTemperature3.Name = "txtCondenserTemperature3"
        Me.txtCondenserTemperature3.ReadOnly = True
        Me.txtCondenserTemperature3.Size = New System.Drawing.Size(106, 21)
        Me.txtCondenserTemperature3.TabIndex = 53
        Me.txtCondenserTemperature3.TabStop = False
        '
        'txtAirTemperature3
        '
        Me.txtAirTemperature3.Location = New System.Drawing.Point(433, 87)
        Me.txtAirTemperature3.Name = "txtAirTemperature3"
        Me.txtAirTemperature3.ReadOnly = True
        Me.txtAirTemperature3.Size = New System.Drawing.Size(106, 21)
        Me.txtAirTemperature3.TabIndex = 52
        Me.txtAirTemperature3.TabStop = False
        '
        'txtEvaporatorTemperature3
        '
        Me.txtEvaporatorTemperature3.Location = New System.Drawing.Point(433, 62)
        Me.txtEvaporatorTemperature3.Name = "txtEvaporatorTemperature3"
        Me.txtEvaporatorTemperature3.ReadOnly = True
        Me.txtEvaporatorTemperature3.Size = New System.Drawing.Size(106, 21)
        Me.txtEvaporatorTemperature3.TabIndex = 51
        Me.txtEvaporatorTemperature3.TabStop = False
        '
        'txtCondensingUnitModel3
        '
        Me.txtCondensingUnitModel3.Location = New System.Drawing.Point(433, 37)
        Me.txtCondensingUnitModel3.Name = "txtCondensingUnitModel3"
        Me.txtCondensingUnitModel3.ReadOnly = True
        Me.txtCondensingUnitModel3.Size = New System.Drawing.Size(106, 21)
        Me.txtCondensingUnitModel3.TabIndex = 50
        Me.txtCondensingUnitModel3.TabStop = False
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(316, 2)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 33)
        Me.Label8.TabIndex = 49
        Me.Label8.Text = "Next Larger Selection"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txtBaseListPrice2
        '
        Me.txtBaseListPrice2.Location = New System.Drawing.Point(315, 412)
        Me.txtBaseListPrice2.Name = "txtBaseListPrice2"
        Me.txtBaseListPrice2.ReadOnly = True
        Me.txtBaseListPrice2.Size = New System.Drawing.Size(106, 21)
        Me.txtBaseListPrice2.TabIndex = 48
        Me.txtBaseListPrice2.TabStop = False
        '
        'txtDimensions2
        '
        Me.txtDimensions2.Location = New System.Drawing.Point(315, 387)
        Me.txtDimensions2.Name = "txtDimensions2"
        Me.txtDimensions2.ReadOnly = True
        Me.txtDimensions2.Size = New System.Drawing.Size(106, 21)
        Me.txtDimensions2.TabIndex = 47
        Me.txtDimensions2.TabStop = False
        '
        'txtUnitMCA4602
        '
        Me.txtUnitMCA4602.Location = New System.Drawing.Point(315, 362)
        Me.txtUnitMCA4602.Name = "txtUnitMCA4602"
        Me.txtUnitMCA4602.ReadOnly = True
        Me.txtUnitMCA4602.Size = New System.Drawing.Size(106, 21)
        Me.txtUnitMCA4602.TabIndex = 46
        Me.txtUnitMCA4602.TabStop = False
        '
        'txtUnitMCA2302
        '
        Me.txtUnitMCA2302.Location = New System.Drawing.Point(315, 337)
        Me.txtUnitMCA2302.Name = "txtUnitMCA2302"
        Me.txtUnitMCA2302.ReadOnly = True
        Me.txtUnitMCA2302.Size = New System.Drawing.Size(106, 21)
        Me.txtUnitMCA2302.TabIndex = 45
        Me.txtUnitMCA2302.TabStop = False
        '
        'txtTD2
        '
        Me.txtTD2.Location = New System.Drawing.Point(315, 312)
        Me.txtTD2.Name = "txtTD2"
        Me.txtTD2.ReadOnly = True
        Me.txtTD2.Size = New System.Drawing.Size(106, 21)
        Me.txtTD2.TabIndex = 44
        Me.txtTD2.TabStop = False
        '
        'txtUnitEER2
        '
        Me.txtUnitEER2.Location = New System.Drawing.Point(315, 287)
        Me.txtUnitEER2.Name = "txtUnitEER2"
        Me.txtUnitEER2.ReadOnly = True
        Me.txtUnitEER2.Size = New System.Drawing.Size(106, 21)
        Me.txtUnitEER2.TabIndex = 43
        Me.txtUnitEER2.TabStop = False
        '
        'txtUnitAmps4602
        '
        Me.txtUnitAmps4602.Location = New System.Drawing.Point(315, 262)
        Me.txtUnitAmps4602.Name = "txtUnitAmps4602"
        Me.txtUnitAmps4602.ReadOnly = True
        Me.txtUnitAmps4602.Size = New System.Drawing.Size(106, 21)
        Me.txtUnitAmps4602.TabIndex = 42
        Me.txtUnitAmps4602.TabStop = False
        '
        'txtUnitAmps2302
        '
        Me.txtUnitAmps2302.Location = New System.Drawing.Point(315, 237)
        Me.txtUnitAmps2302.Name = "txtUnitAmps2302"
        Me.txtUnitAmps2302.ReadOnly = True
        Me.txtUnitAmps2302.Size = New System.Drawing.Size(106, 21)
        Me.txtUnitAmps2302.TabIndex = 41
        Me.txtUnitAmps2302.TabStop = False
        '
        'txtCondenserCapacity22
        '
        Me.txtCondenserCapacity22.Location = New System.Drawing.Point(315, 212)
        Me.txtCondenserCapacity22.Name = "txtCondenserCapacity22"
        Me.txtCondenserCapacity22.ReadOnly = True
        Me.txtCondenserCapacity22.Size = New System.Drawing.Size(106, 21)
        Me.txtCondenserCapacity22.TabIndex = 40
        Me.txtCondenserCapacity22.TabStop = False
        '
        'txtUnitKW2
        '
        Me.txtUnitKW2.Location = New System.Drawing.Point(315, 187)
        Me.txtUnitKW2.Name = "txtUnitKW2"
        Me.txtUnitKW2.ReadOnly = True
        Me.txtUnitKW2.Size = New System.Drawing.Size(106, 21)
        Me.txtUnitKW2.TabIndex = 39
        Me.txtUnitKW2.TabStop = False
        '
        'txtRunTime2
        '
        Me.txtRunTime2.Location = New System.Drawing.Point(315, 162)
        Me.txtRunTime2.Name = "txtRunTime2"
        Me.txtRunTime2.ReadOnly = True
        Me.txtRunTime2.Size = New System.Drawing.Size(106, 21)
        Me.txtRunTime2.TabIndex = 38
        Me.txtRunTime2.TabStop = False
        '
        'txtCapacity2
        '
        Me.txtCapacity2.Location = New System.Drawing.Point(315, 137)
        Me.txtCapacity2.Name = "txtCapacity2"
        Me.txtCapacity2.ReadOnly = True
        Me.txtCapacity2.Size = New System.Drawing.Size(106, 21)
        Me.txtCapacity2.TabIndex = 37
        Me.txtCapacity2.TabStop = False
        '
        'txtCondenserTemperature2
        '
        Me.txtCondenserTemperature2.Location = New System.Drawing.Point(315, 112)
        Me.txtCondenserTemperature2.Name = "txtCondenserTemperature2"
        Me.txtCondenserTemperature2.ReadOnly = True
        Me.txtCondenserTemperature2.Size = New System.Drawing.Size(106, 21)
        Me.txtCondenserTemperature2.TabIndex = 36
        Me.txtCondenserTemperature2.TabStop = False
        '
        'txtAirTemperature2
        '
        Me.txtAirTemperature2.Location = New System.Drawing.Point(315, 87)
        Me.txtAirTemperature2.Name = "txtAirTemperature2"
        Me.txtAirTemperature2.ReadOnly = True
        Me.txtAirTemperature2.Size = New System.Drawing.Size(106, 21)
        Me.txtAirTemperature2.TabIndex = 35
        Me.txtAirTemperature2.TabStop = False
        '
        'txtEvaporatorTemperature2
        '
        Me.txtEvaporatorTemperature2.Location = New System.Drawing.Point(315, 62)
        Me.txtEvaporatorTemperature2.Name = "txtEvaporatorTemperature2"
        Me.txtEvaporatorTemperature2.ReadOnly = True
        Me.txtEvaporatorTemperature2.Size = New System.Drawing.Size(106, 21)
        Me.txtEvaporatorTemperature2.TabIndex = 34
        Me.txtEvaporatorTemperature2.TabStop = False
        '
        'txtCondensingUnitModel2
        '
        Me.txtCondensingUnitModel2.Location = New System.Drawing.Point(315, 37)
        Me.txtCondensingUnitModel2.Name = "txtCondensingUnitModel2"
        Me.txtCondensingUnitModel2.ReadOnly = True
        Me.txtCondensingUnitModel2.Size = New System.Drawing.Size(106, 21)
        Me.txtCondensingUnitModel2.TabIndex = 33
        Me.txtCondensingUnitModel2.TabStop = False
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(198, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(105, 31)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Closest Selection"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txtBaseListPrice1
        '
        Me.txtBaseListPrice1.Location = New System.Drawing.Point(198, 412)
        Me.txtBaseListPrice1.Name = "txtBaseListPrice1"
        Me.txtBaseListPrice1.ReadOnly = True
        Me.txtBaseListPrice1.Size = New System.Drawing.Size(106, 21)
        Me.txtBaseListPrice1.TabIndex = 31
        Me.txtBaseListPrice1.TabStop = False
        '
        'lblBaseListPrice
        '
        Me.lblBaseListPrice.Location = New System.Drawing.Point(39, 410)
        Me.lblBaseListPrice.Name = "lblBaseListPrice"
        Me.lblBaseListPrice.Size = New System.Drawing.Size(153, 21)
        Me.lblBaseListPrice.TabIndex = 30
        Me.lblBaseListPrice.Text = "Base list price (no options)"
        Me.lblBaseListPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDimensions1
        '
        Me.txtDimensions1.Location = New System.Drawing.Point(198, 387)
        Me.txtDimensions1.Name = "txtDimensions1"
        Me.txtDimensions1.ReadOnly = True
        Me.txtDimensions1.Size = New System.Drawing.Size(106, 21)
        Me.txtDimensions1.TabIndex = 29
        Me.txtDimensions1.TabStop = False
        '
        'lblDimensions
        '
        Me.lblDimensions.Location = New System.Drawing.Point(39, 385)
        Me.lblDimensions.Name = "lblDimensions"
        Me.lblDimensions.Size = New System.Drawing.Size(153, 21)
        Me.lblDimensions.TabIndex = 28
        Me.lblDimensions.Text = "Dimensions"
        Me.lblDimensions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUnitMCA4601
        '
        Me.txtUnitMCA4601.Location = New System.Drawing.Point(198, 362)
        Me.txtUnitMCA4601.Name = "txtUnitMCA4601"
        Me.txtUnitMCA4601.ReadOnly = True
        Me.txtUnitMCA4601.Size = New System.Drawing.Size(106, 21)
        Me.txtUnitMCA4601.TabIndex = 27
        Me.txtUnitMCA4601.TabStop = False
        '
        'lblUnitMCA460
        '
        Me.lblUnitMCA460.Location = New System.Drawing.Point(39, 360)
        Me.lblUnitMCA460.Name = "lblUnitMCA460"
        Me.lblUnitMCA460.Size = New System.Drawing.Size(153, 21)
        Me.lblUnitMCA460.TabIndex = 26
        Me.lblUnitMCA460.Text = "Unit MCA 460"
        Me.lblUnitMCA460.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUnitMCA2301
        '
        Me.txtUnitMCA2301.Location = New System.Drawing.Point(198, 337)
        Me.txtUnitMCA2301.Name = "txtUnitMCA2301"
        Me.txtUnitMCA2301.ReadOnly = True
        Me.txtUnitMCA2301.Size = New System.Drawing.Size(106, 21)
        Me.txtUnitMCA2301.TabIndex = 25
        Me.txtUnitMCA2301.TabStop = False
        '
        'lblUnitMCA230
        '
        Me.lblUnitMCA230.Location = New System.Drawing.Point(39, 335)
        Me.lblUnitMCA230.Name = "lblUnitMCA230"
        Me.lblUnitMCA230.Size = New System.Drawing.Size(153, 21)
        Me.lblUnitMCA230.TabIndex = 24
        Me.lblUnitMCA230.Text = "Unit MCA 230"
        Me.lblUnitMCA230.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTD
        '
        Me.lblTD.Location = New System.Drawing.Point(39, 310)
        Me.lblTD.Name = "lblTD"
        Me.lblTD.Size = New System.Drawing.Size(153, 21)
        Me.lblTD.TabIndex = 23
        Me.lblTD.Text = "Temperature difference"
        Me.lblTD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTD1
        '
        Me.txtTD1.Location = New System.Drawing.Point(198, 312)
        Me.txtTD1.Name = "txtTD1"
        Me.txtTD1.ReadOnly = True
        Me.txtTD1.Size = New System.Drawing.Size(106, 21)
        Me.txtTD1.TabIndex = 22
        Me.txtTD1.TabStop = False
        '
        'txtUnitEER1
        '
        Me.txtUnitEER1.Location = New System.Drawing.Point(198, 287)
        Me.txtUnitEER1.Name = "txtUnitEER1"
        Me.txtUnitEER1.ReadOnly = True
        Me.txtUnitEER1.Size = New System.Drawing.Size(106, 21)
        Me.txtUnitEER1.TabIndex = 21
        Me.txtUnitEER1.TabStop = False
        '
        'lblUnitEER
        '
        Me.lblUnitEER.Location = New System.Drawing.Point(39, 285)
        Me.lblUnitEER.Name = "lblUnitEER"
        Me.lblUnitEER.Size = New System.Drawing.Size(153, 21)
        Me.lblUnitEER.TabIndex = 20
        Me.lblUnitEER.Text = "Unit EER"
        Me.lblUnitEER.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUnitAmps4601
        '
        Me.txtUnitAmps4601.Location = New System.Drawing.Point(198, 262)
        Me.txtUnitAmps4601.Name = "txtUnitAmps4601"
        Me.txtUnitAmps4601.ReadOnly = True
        Me.txtUnitAmps4601.Size = New System.Drawing.Size(106, 21)
        Me.txtUnitAmps4601.TabIndex = 19
        Me.txtUnitAmps4601.TabStop = False
        '
        'lblUnitAmps460
        '
        Me.lblUnitAmps460.Location = New System.Drawing.Point(39, 260)
        Me.lblUnitAmps460.Name = "lblUnitAmps460"
        Me.lblUnitAmps460.Size = New System.Drawing.Size(153, 21)
        Me.lblUnitAmps460.TabIndex = 18
        Me.lblUnitAmps460.Text = "Unit amps @ 460"
        Me.lblUnitAmps460.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUnitAmps2301
        '
        Me.txtUnitAmps2301.Location = New System.Drawing.Point(198, 237)
        Me.txtUnitAmps2301.Name = "txtUnitAmps2301"
        Me.txtUnitAmps2301.ReadOnly = True
        Me.txtUnitAmps2301.Size = New System.Drawing.Size(106, 21)
        Me.txtUnitAmps2301.TabIndex = 17
        Me.txtUnitAmps2301.TabStop = False
        '
        'lblUnitAmps230
        '
        Me.lblUnitAmps230.Location = New System.Drawing.Point(39, 235)
        Me.lblUnitAmps230.Name = "lblUnitAmps230"
        Me.lblUnitAmps230.Size = New System.Drawing.Size(153, 21)
        Me.lblUnitAmps230.TabIndex = 16
        Me.lblUnitAmps230.Text = "Unit amps @ 230"
        Me.lblUnitAmps230.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCondenserCapacity11
        '
        Me.txtCondenserCapacity11.Location = New System.Drawing.Point(198, 212)
        Me.txtCondenserCapacity11.Name = "txtCondenserCapacity11"
        Me.txtCondenserCapacity11.ReadOnly = True
        Me.txtCondenserCapacity11.Size = New System.Drawing.Size(106, 21)
        Me.txtCondenserCapacity11.TabIndex = 15
        Me.txtCondenserCapacity11.TabStop = False
        '
        'lblCondenserCapacity
        '
        Me.lblCondenserCapacity.Location = New System.Drawing.Point(39, 210)
        Me.lblCondenserCapacity.Name = "lblCondenserCapacity"
        Me.lblCondenserCapacity.Size = New System.Drawing.Size(153, 21)
        Me.lblCondenserCapacity.TabIndex = 14
        Me.lblCondenserCapacity.Text = "Condenser Est. capacity [BTUH]"
        Me.lblCondenserCapacity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUnitKW
        '
        Me.lblUnitKW.Location = New System.Drawing.Point(39, 185)
        Me.lblUnitKW.Name = "lblUnitKW"
        Me.lblUnitKW.Size = New System.Drawing.Size(153, 21)
        Me.lblUnitKW.TabIndex = 13
        Me.lblUnitKW.Text = "Unit kW"
        Me.lblUnitKW.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUnitKW1
        '
        Me.txtUnitKW1.Location = New System.Drawing.Point(198, 187)
        Me.txtUnitKW1.Name = "txtUnitKW1"
        Me.txtUnitKW1.ReadOnly = True
        Me.txtUnitKW1.Size = New System.Drawing.Size(106, 21)
        Me.txtUnitKW1.TabIndex = 12
        Me.txtUnitKW1.TabStop = False
        '
        'txtRunTime1
        '
        Me.txtRunTime1.Location = New System.Drawing.Point(198, 162)
        Me.txtRunTime1.Name = "txtRunTime1"
        Me.txtRunTime1.ReadOnly = True
        Me.txtRunTime1.Size = New System.Drawing.Size(106, 21)
        Me.txtRunTime1.TabIndex = 11
        Me.txtRunTime1.TabStop = False
        '
        'lblRunTime
        '
        Me.lblRunTime.Location = New System.Drawing.Point(39, 160)
        Me.lblRunTime.Name = "lblRunTime"
        Me.lblRunTime.Size = New System.Drawing.Size(153, 21)
        Me.lblRunTime.TabIndex = 10
        Me.lblRunTime.Text = "Run time [Hr]"
        Me.lblRunTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCapacity1
        '
        Me.txtCapacity1.Location = New System.Drawing.Point(198, 137)
        Me.txtCapacity1.Name = "txtCapacity1"
        Me.txtCapacity1.ReadOnly = True
        Me.txtCapacity1.Size = New System.Drawing.Size(106, 21)
        Me.txtCapacity1.TabIndex = 9
        Me.txtCapacity1.TabStop = False
        '
        'lblCapacity
        '
        Me.lblCapacity.Location = New System.Drawing.Point(39, 135)
        Me.lblCapacity.Name = "lblCapacity"
        Me.lblCapacity.Size = New System.Drawing.Size(153, 21)
        Me.lblCapacity.TabIndex = 8
        Me.lblCapacity.Text = "Est. Capacity [BTUH]"
        Me.lblCapacity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCondenserTemperature1
        '
        Me.txtCondenserTemperature1.Location = New System.Drawing.Point(198, 112)
        Me.txtCondenserTemperature1.Name = "txtCondenserTemperature1"
        Me.txtCondenserTemperature1.ReadOnly = True
        Me.txtCondenserTemperature1.Size = New System.Drawing.Size(106, 21)
        Me.txtCondenserTemperature1.TabIndex = 7
        Me.txtCondenserTemperature1.TabStop = False
        '
        'lblCondenserTemperature
        '
        Me.lblCondenserTemperature.Location = New System.Drawing.Point(39, 110)
        Me.lblCondenserTemperature.Name = "lblCondenserTemperature"
        Me.lblCondenserTemperature.Size = New System.Drawing.Size(153, 21)
        Me.lblCondenserTemperature.TabIndex = 6
        Me.lblCondenserTemperature.Text = "Condenser temp. [°F]"
        Me.lblCondenserTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAirTemperature1
        '
        Me.txtAirTemperature1.Location = New System.Drawing.Point(198, 87)
        Me.txtAirTemperature1.Name = "txtAirTemperature1"
        Me.txtAirTemperature1.ReadOnly = True
        Me.txtAirTemperature1.Size = New System.Drawing.Size(106, 21)
        Me.txtAirTemperature1.TabIndex = 5
        Me.txtAirTemperature1.TabStop = False
        '
        'lblAirTemperature
        '
        Me.lblAirTemperature.Location = New System.Drawing.Point(39, 85)
        Me.lblAirTemperature.Name = "lblAirTemperature"
        Me.lblAirTemperature.Size = New System.Drawing.Size(153, 21)
        Me.lblAirTemperature.TabIndex = 4
        Me.lblAirTemperature.Text = "Air on temperature [°F]"
        Me.lblAirTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEvaporatorTemperature1
        '
        Me.txtEvaporatorTemperature1.Location = New System.Drawing.Point(198, 62)
        Me.txtEvaporatorTemperature1.Name = "txtEvaporatorTemperature1"
        Me.txtEvaporatorTemperature1.ReadOnly = True
        Me.txtEvaporatorTemperature1.Size = New System.Drawing.Size(106, 21)
        Me.txtEvaporatorTemperature1.TabIndex = 3
        Me.txtEvaporatorTemperature1.TabStop = False
        '
        'lblEvaporatorTemperature
        '
        Me.lblEvaporatorTemperature.Location = New System.Drawing.Point(39, 60)
        Me.lblEvaporatorTemperature.Name = "lblEvaporatorTemperature"
        Me.lblEvaporatorTemperature.Size = New System.Drawing.Size(153, 21)
        Me.lblEvaporatorTemperature.TabIndex = 2
        Me.lblEvaporatorTemperature.Text = "Evaporator temp. [°F]"
        Me.lblEvaporatorTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCondensingUnitModel1
        '
        Me.txtCondensingUnitModel1.Location = New System.Drawing.Point(198, 37)
        Me.txtCondensingUnitModel1.Name = "txtCondensingUnitModel1"
        Me.txtCondensingUnitModel1.ReadOnly = True
        Me.txtCondensingUnitModel1.Size = New System.Drawing.Size(106, 21)
        Me.txtCondensingUnitModel1.TabIndex = 1
        Me.txtCondensingUnitModel1.TabStop = False
        '
        'lblCondensingUnitModel
        '
        Me.lblCondensingUnitModel.Location = New System.Drawing.Point(39, 37)
        Me.lblCondensingUnitModel.Name = "lblCondensingUnitModel"
        Me.lblCondensingUnitModel.Size = New System.Drawing.Size(153, 21)
        Me.lblCondensingUnitModel.TabIndex = 0
        Me.lblCondensingUnitModel.Text = "Model number"
        Me.lblCondensingUnitModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'balanceErrorProvider
        '
        Me.balanceErrorProvider.ContainerControl = Me
        '
        'status_bar
        '
        Me.status_bar.BackColor = System.Drawing.Color.White
        Me.status_bar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.status_bar.Location = New System.Drawing.Point(0, 633)
        Me.status_bar.Name = "status_bar"
        Me.status_bar.Size = New System.Drawing.Size(642, 21)
        Me.status_bar.TabIndex = 70
        Me.status_bar.Text = "Status:"
        Me.status_bar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SaveToolStripPanel1
        '
        Me.SaveToolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SaveToolStripPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SaveToolStripPanel1.Name = "SaveToolStripPanel1"
        Me.SaveToolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.SaveToolStripPanel1.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.SaveToolStripPanel1.Size = New System.Drawing.Size(642, 0)
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(220, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(172, 19)
        Me.Label2.TabIndex = 83
        Me.Label2.Text = "Unit Cooler Balance"
        '
        'cu_uc_balance_window
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(642, 654)
        Me.Controls.Add(Me.SaveToolStripPanel1)
        Me.Controls.Add(Me.panMain)
        Me.Controls.Add(Me.panFooter)
        Me.Controls.Add(Me.status_bar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuStrip = Me.balanceMenuStrip
        Me.Name = "cu_uc_balance_window"
        Me.Text = "Unit Cooler - Condensing Unit Balance"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.adjustCapacityForRunTimePanel.ResumeLayout(False)
        Me.roomsPanel.ResumeLayout(False)
        Me.roomsPanel.PerformLayout()
        CType(Me.picError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panCondensingUnitSpecBody.ResumeLayout(False)
        Me.panCondensingUnitSpecBody.PerformLayout()
        Me.grpboxload.ResumeLayout(False)
        Me.grpboxload.PerformLayout()
        Me.balanceMenuStrip.ResumeLayout(False)
        Me.balanceMenuStrip.PerformLayout()
        Me.panUnitCoolerSpec.ResumeLayout(False)
        Me.panUnitCoolGrid.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdCoolerView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panRate.ResumeLayout(False)
        Me.panRate.PerformLayout()
        Me.pan_static_pressure_3.ResumeLayout(False)
        Me.pan_static_pressure_3.PerformLayout()
        Me.pan_static_pressure_2.ResumeLayout(False)
        Me.pan_static_pressure_2.PerformLayout()
        Me.pan_static_pressure_1.ResumeLayout(False)
        Me.pan_static_pressure_1.PerformLayout()
        Me.panBalaGrid.ResumeLayout(False)
        Me.panFooter.ResumeLayout(False)
        Me.panMain.ResumeLayout(False)
        Me.panCondensingUnitDataBody.ResumeLayout(False)
        Me.panCondensingUnitDataBody.PerformLayout()
        CType(Me.balanceErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


#Region " Classes"

    Friend Class Strings

        ''' <summary>
        ''' Report cannot be opened. The attempt to set the database connection for the report failed.
        ''' </summary>
        ''' <param name="databasePath">
        ''' Path to database that report is trying to open.
        ''' </param>
        ''' <param name="exceptionMessage">
        ''' Exception message thrown
        ''' </param>
        Public Shared Function CannotViewReportDatabaseConnectionFailed(ByVal databasePath As String, ByVal exceptionMessage As String) As String
            Dim message As String = "Report cannot be opened. The attempt to set the database connection for the report failed." &
               NewLine & databasePath & NewLine & exceptionMessage
            Return message
        End Function

    End Class

#End Region


#Region " Declarations"

    Private vmaBalance As ValidationManager
    Private vma_balance As ValidationManager
    Private vcoSuctionTemperature As ValidationControl
    Private vcoNumCondensingUnits As ValidationControl
    Private vcoAltitude As ValidationControl
    Private vcoCapacity As ValidationControl
    Private vcoRunTime As ValidationControl
    Private vcoAmbientTemperature As ValidationControl
    Private vcoRoomTemperature As ValidationControl
    Private vcoNumUnitCoolers1, vcoNumUnitCoolers2, vcoNumUnitCoolers3 As ValidationControl

    Dim PFEStatic As Integer = 1 'indicates 0.00", 0.25", or 0.50" PFE External Static
    Dim hertz As Integer = 60
    Dim LastStateProcess As cu_uc_balance_screen_model
    Private results_dataset As New balance_dataset()
    Private changesSinceFindCondensingUnit As New UniqueList(Of String)() 'for find Unit Cooler button
    Private changesSinceFindUnitCoolers As New UniqueList(Of String)() 'for find Rate System button
    Private capacityUnits As String = "BTUH" ' btuh or tons
    Private digits As Integer = 0  ' number of significant digits (TSI = 2, CRI = 0)
    Private is_loading As Boolean = True
    Private isInitializing As Boolean = True

    ' Condensing unit rating for balance...
    Private m_CondensingUnitRating As Rae.RaeSolutions.Business.Entities.CondensingUnitProcessItem
    ''' <summary>
    ''' CondensingUnitRating
    ''' </summary>
    Public Property CondensingUnitRating() As Rae.RaeSolutions.Business.Entities.CondensingUnitProcessItem
        Get
            Return Me.m_CondensingUnitRating
        End Get
        Set(ByVal value As Rae.RaeSolutions.Business.Entities.CondensingUnitProcessItem)
            Me.m_CondensingUnitRating = value
        End Set
    End Property
#End Region


#Region " Event handlers"

#Region " Menu event handlers"

    Private Sub printMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles printMenuItem.Click
        ''Me.PrintForm()
    End Sub

    Private Sub saveMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles saveMenuItem.Click
        SaveControls()
    End Sub

    Private Sub SaveAsRevisionMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
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

    Private Sub form_Activated(ByVal sender As Object, ByVal e As EventArgs) _
    Handles Me.Activated
        Me.initializeSaveToolStripPanel()
        Me.SaveToolStripPanel1.Merge()
    End Sub


    Private Sub form_Deactivate(ByVal sender As Object, ByVal e As EventArgs) _
    Handles Me.Deactivate
        Me.SaveToolStripPanel1.Unmerge()
    End Sub

    Private user As user

    Private Sub form_Load() _
    Handles MyBase.Load
        status_bar.Text = "Loading..."

        user = AppInfo.User

        initializeSaveToolStripPanel()

        'SIZE WINDOW TO THE HEIGHT OF THE MAIN FORM
        Me.Height = Ui.FormEditor.MaximizeHeight(Me)
        'align form to top of mdiParent's client area
        Me.Location = New Point(Me.Location.X, 0)

        initializeValidation()
        initializeComboboxes()
        setDivisionSpecificControls()
        setAuthorizationSpecificControls()

        cboCondensingUnitSeries.Focus()
        ddlDOE.SelectedIndex = 1


        status_bar.Text = "Ready"
        Me.is_loading = False
        'Coolstuff 
        If user.is_rep Then
            grpboxload.Visible = False
        Else
            Try
                If OpenedProject.Manager.Project.id.Id > "" Then
                    grpboxload.Visible = True
                End If
            Catch ex As Exception
                grpboxload.Visible = False
            End Try
        End If

        'add handler to revision view . revision changed event on main form...
        AddHandler AppInfo.Main.RevisionView1.RevisionChanged, AddressOf RevisionView_RevisionChanged
    End Sub


    ''' <summary>Asks user if they want to save.</summary>
    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) _
    Handles Me.FormClosing
        If Not Me.ProcessDeleted Then
            If SaveControls(False, False, True) = False Then
                e.Cancel = True
            Else
                RemoveHandler AppInfo.Main.RevisionView1.RevisionChanged, AddressOf RevisionView_RevisionChanged
            End If
        End If
    End Sub

#Region " Button event handlers"

    ''' <summary>Handles Find Condensing Units button click event
    ''' </summary>
    ''' <remarks>Finds condensing units that match inputs and sets appropriate 
    ''' controls
    ''' 1. set number of rooms and room temperature (not for dll)
    ''' INPUTS **************************************
    ''' 2. set dll condensing unit series
    ''' 3. set dll condenser capacity
    ''' 4. set dll ambient and suction temperature
    ''' 5. set dll refrigerant type
    ''' 6a)set dll compressor type and b) dll # of compressors per unit
    ''' 7. set dll number of circuits per condensing unit
    ''' 8. set dll altitude
    ''' 9. set dll company division
    ''' OUTPUTS *************************************
    ''' 1. fill condensing unit description, condensing unit capacity and condenser capacity
    ''' 2. format condensing units' radiobutton appearance
    ''' </remarks>
    ''' <history>[CASEYJ]	6/13/2005	Created
    ''' </history>

    Private Sub findCondensingUnitsButton_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles findCondensingUnitsButton.Click
        ' checks if managed controls are valid
        If Not Me.vmaBalance.Validate() Then
            Ui.MessageBox.Show(Me.vmaBalance.ErrorMessagesSummary, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim cur As New condensing_units.Repository

        ' clears text in condensing unit controls
        Me.ClearCondensingUnits()
        ' hides and unchecks condensing units since the text has been cleared
        Me.FormatCondensingUnits()
        Me.clearUnitCoolers()

        ' checks if suction temperature is a number and is within temperature range
        If Not Me.IsSuctionTemperatureInValidRange(Me.grab_suction_temp()) Then
            Dim message As String
            message = "The entered suction temperature is not within the valid range."
            Ui.MessageBox.Show(message)
            Exit Sub
        End If

        ' sets cursor to hour glass
        Me.Cursor = Cursors.WaitCursor
        ' sets status bar text
        Me.status_bar.Text = "Finding condensing units..."
        ' forces control to redraw
        Me.status_bar.Refresh()

        ' allow "Find Units Coolers" button to be clicked
        Me.changesSinceFindCondensingUnit.Clear()


        Dim condenserCapacity As Double
        Dim lowAmbientTemperature, highAmbientTemperature As Double
        Dim compressorsPerUnit, circuitsPerUnit As Integer


        If Me.numCompressorsPerUnitComboBox.SelectedItem.ToString.Trim.ToUpper = "ALL" Then
            compressorsPerUnit = 0
        Else
            compressorsPerUnit = CInt(Me.numCompressorsPerUnitComboBox.SelectedItem.ToString)
        End If


        If Me.numCircuitsPerUnitComboBox.SelectedItem.ToString.Trim.ToUpper = "ALL" Then
            circuitsPerUnit = 0
        Else
            circuitsPerUnit = CInt(Me.numCircuitsPerUnitComboBox.SelectedItem)
        End If

        Dim condensingUnitSeries = cboCondensingUnitSeries.SelectedItem.ToString.Trim
        Dim suctionTemperature = grab_suction_temp()
        Dim refrigerant = grab_refrigerant()
        ' sets compressor type
        If compressorTypeComboBox.SelectedIndex = -1 Then
            compressorTypeComboBox.SelectedIndex = 0
        End If

        Dim compressorType = compressorTypeComboBox.SelectedItem.ToString.Trim
        Dim altitude = grab_altitude()

        Dim requiredCapacityPerUnit = grab_required_condensing_unit_capacity() / grab_condensing_unit_quantity()
        ' calculates condenser capacity
        If adjustCapacityForRunTimeNoRadioButton.Checked Then
            condenserCapacity = requiredCapacityPerUnit
        Else
            condenserCapacity = requiredCapacityPerUnit * 24.0 / grab_run_time_hours()
        End If

        ' sets ambient temperature
        If there_is_one_room() Then
            lowAmbientTemperature = CNull.ToDouble(Me.ambientTemperatureTextBox.Text.Trim)
            highAmbientTemperature = CNull.ToDouble(Me.ambientTemperatureTextBox.Text.Trim)
        Else
            lowAmbientTemperature = CNull.ToDouble(Me.txt_min_ambient.Text.Trim)
            highAmbientTemperature = CNull.ToDouble(Me.txt_max_ambient.Text.Trim)
        End If


        Dim best = New Best_Matches()
        Dim spec As Best_Matches.Spec
        spec.capacity = condenserCapacity
        spec.compressor_quantity = compressorsPerUnit
        spec.compressor_type = compressorType
        spec.division = AppInfo.Division
        spec.num_circuits = circuitsPerUnit
        spec.refrigerant = Solutions.refrigerant.parse(refrigerant)
        spec.series = condensingUnitSeries
        spec.DOEModels = ddlDOE.Text

        Dim conditions As Best_Matches.Conditions
        conditions.altitude = altitude
        conditions.ambient = highAmbientTemperature
        conditions.catalog_rating = False

        '  conditions.catalog_rating = True


        conditions.hertz = 60
        conditions.suction = suctionTemperature
        conditions.voltage = 460

        Dim selections = best.given(spec, at:=conditions, CondTempOverride:=cbCondTempOverride.Checked)



        Dim resultFlag As Boolean = False
        ' clears condensing unit description and capacity
        Me.ClearCondensingUnits()
        lblNoCUResults.Visible = False

        If best.closest IsNot Nothing Then
            resultFlag = True
            Dim selection = best.closest
            Dim point = selection.balance_point

            If condensingUnit1RadioButton.Checked Then
                condensingUnit1DescriptionLabel.BackColor = Color.Yellow
            Else
                condensingUnit1DescriptionLabel.BackColor = Color.Transparent
            End If

            condensingUnit1DescriptionLabel.Text =
               selection.unit.model & " est. capacity " &
               Format(Round(point.capacity, digits), "###,###,###.##") & " " & capacityUnits
            txt_condensing_unit_1_capacity.Text = Round(point.capacity, digits)
            ' tag holds condensing unit model
            txt_condensing_unit_1_capacity.Tag = selection.unit.model
            If AppInfo.Division = Division.TSI Then
                condensingUnit1CondenserCapacityPerDegreeTextBox.Text = Round(point.condenser_capacity / point.td / 12000, 2)
            Else
                condensingUnit1CondenserCapacityPerDegreeTextBox.Text = Round(point.condenser_capacity / point.td, digits)
            End If

            Dim runtime = grab_required_condensing_unit_capacity() / grab_condensing_unit_quantity() _
                           / point.capacity * grab_run_time_hours()

            ' shows extra condensing unit data
            txtCondensingUnitModel1.Text = selection.unit.model

            txt_condensing_unit_DOE_1.Text = cur.CheckDOE(selection.unit.model)

            txtEvaporatorTemperature1.Text = selection.conditions.suction
            txtAirTemperature1.Text = selection.conditions.ambient
            txtCondenserTemperature1.Text = Round(point.condensing_temp, 1)
            txtCapacity1.Text = Round(point.capacity, digits).ToString
            txtRunTime1.Text = Round(runtime, 1)
            txtUnitKW1.Text = Round((point.unit_kw), 2).ToString
            txtCondenserCapacity11.Text = Round(point.condenser_capacity, digits).ToString
            txtUnitAmps2301.Text = Round(point.unit_amps, 1)
            txtUnitAmps4601.Text = Round(point.unit_amps, 1)
            txtUnitEER1.Text = Round(point.unit_eer, 2)
            txtTD1.Text = Round(point.td, 1)
            txtUnitMCA2301.Text = selection.unit.mca_208
            txtUnitMCA4601.Text = selection.unit.mca_460
            txtDimensions1.Text = selection.unit.dimensions
        End If

        If best.above IsNot Nothing Then
            resultFlag = True

            Dim selection = best.above
            Dim point = selection.balance_point

            If condensingUnit2RadioButton.Checked Then
                condensingUnit2DescriptionLabel.BackColor = Color.Yellow
            Else
                condensingUnit2DescriptionLabel.BackColor = Color.Transparent
            End If
            condensingUnit2DescriptionLabel.Text = selection.unit.model & " est. capacity " & Format(Round(point.capacity), "###,###,###") & " BTUH"
            txt_condensing_unit_2_capacity.Text = Round(point.capacity, digits)
            condensingUnit2CondenserCapacityTextBox.Text = Round(point.condenser_capacity / point.td)
            txt_condensing_unit_2_capacity.Tag = selection.unit.model
            If AppInfo.Division = Division.TSI Then
                Me.condensingUnit2DescriptionLabel.Text = selection.unit.model & " est. capacity " & Round(point.capacity, 2) & " " & capacityUnits
                Me.condensingUnit2CondenserCapacityTextBox.Text = Round(point.condenser_capacity / point.td / 12000, 2).ToString
                Me.txt_condensing_unit_2_capacity.Tag = selection.unit.model
            End If
            'show more data temporarily
            txtCondensingUnitModel2.Text = selection.unit.model


            txt_condensing_unit_DOE_2.Text = cur.CheckDOE(selection.unit.model)


            txtEvaporatorTemperature2.Text = selection.conditions.suction
            txtAirTemperature2.Text = selection.conditions.ambient
            txtCondenserTemperature2.Text = Round(point.condensing_temp, 1)
            txtCapacity2.Text = Round(point.capacity, digits)
            txtRunTime2.Text = Round(requiredCapacityPerUnit / point.capacity * grab_run_time_hours(), 1)
            txtUnitKW2.Text = Round(point.unit_kw, 2)
            txtCondenserCapacity22.Text = Round(point.condenser_capacity, digits)
            txtUnitAmps2302.Text = Round(point.unit_amps, 2)
            txtUnitAmps4602.Text = Round(point.unit_amps, 2)
            txtUnitEER2.Text = Round(point.unit_eer, 2)
            txtTD2.Text = Round(point.td, 1)
            txtUnitMCA2302.Text = selection.unit.mca_208
            txtUnitMCA4602.Text = selection.unit.mca_460
            txtDimensions2.Text = selection.unit.dimensions
        End If

        If best.below IsNot Nothing Then
            resultFlag = True

            Dim selection = best.below
            Dim point = selection.balance_point

            If condensingUnit3RadioButton.Checked Then
                condensingUnit3DescriptionLabel.BackColor = Color.Yellow
            Else
                condensingUnit3DescriptionLabel.BackColor = Color.Transparent
            End If

            condensingUnit3DescriptionLabel.Text = selection.unit.model & " est. capacity " & Format(Round(point.capacity), "###,###,###") & " BTUH"
            txt_condensing_unit_3_capacity.Text = Round(point.capacity, digits)
            condensingUnit3CondenserCapacityTextBox.Text = Round(point.condenser_capacity / point.td)
            txt_condensing_unit_3_capacity.Tag = selection.unit.model
            If AppInfo.Division = Division.TSI Then
                condensingUnit3DescriptionLabel.Text = selection.unit.model & " est. capacity " & Round(point.capacity, 2) & " Tons"
                condensingUnit3CondenserCapacityTextBox.Text = Round(point.condenser_capacity / 12000, 2)
                txt_condensing_unit_3_capacity.Tag = selection.unit.model
            End If

            'show more data temporarily
            txtCondensingUnitModel3.Text = selection.unit.model

            txt_condensing_unit_DOE_3.Text = cur.CheckDOE(selection.unit.model)


            txtEvaporatorTemperature3.Text = selection.conditions.suction
            txtAirTemperature3.Text = selection.conditions.ambient
            txtCondenserTemperature3.Text = Round(point.condensing_temp, 1)
            txtCapacity3.Text = Round(point.capacity, digits)
            txtRunTime3.Text = Round(requiredCapacityPerUnit / point.capacity * grab_run_time_hours(), 1)
            txtUnitKW3.Text = Round(point.unit_kw, 2)
            txtCondenserCapacity33.Text = Round(point.condenser_capacity, digits)
            txtUnitAmps2303.Text = Round(point.unit_amps, 2)
            txtUnitAmps4603.Text = Round(point.unit_amps, 2)
            txtUnitEER3.Text = Round(point.unit_eer, 2)
            txtTD3.Text = Round(point.td, 2)
            txtUnitMCA2303.Text = selection.unit.mca_208
            txtUnitMCA4603.Text = selection.unit.mca_460
            txtDimensions3.Text = selection.unit.dimensions
        End If

        If Not resultFlag Then
            lblNoCUResults.Visible = True
        End If


        '2. format condensing units' radiobutton appearance settings
        Me.FormatCondensingUnits()

        Me.status_bar.Text = "Ready"
        Me.Cursor = Cursors.Default 'set hour glass cursor back to default
    End Sub


    Private Sub btn_find_unit_coolers_click() Handles btn_find_unit_coolers.Click
        Cursor = Cursors.WaitCursor
        status_bar.Text = "Finding unit coolers..." : status_bar.Refresh()

        ' make sure none of the used control values have been changed
        If changesSinceFindCondensingUnit.Count = 0 _
        Or Me.customCondensingUnitRadioButton.Checked Then
            'presenter.fill_unit_coolers()

            Dim balance = presenter.calculate_balance()
            Dim criteria = grab_criteria_to_find_unit_coolers()
            Dim unit_coolers = service.find_unit_coolers(criteria)
            DataGridView1.DataSource = presenter.convert_to_table(unit_coolers, balance, criteria.suction_temp, criteria.td)
            DataGridView1.Columns(1).HeaderText = "Quantity Required per Cond Unit"
            DataGridView1.Columns(2).HeaderText = "Est. Capacity [BTUH]"
            DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Else
            showControlsChangedAfterFindCondensingUnitMessage()

            ''unit_coolers_grid.DataSource = Nothing

            clearUnitCoolers()
        End If

        'clear list of modified controls, so that Rate System will work
        changesSinceFindUnitCoolers.Clear()

        status_bar.Text = "Ready"
        Cursor = Cursors.Default
    End Sub


    Private Sub btn_print_click() Handles btn_print.Click
        ''PrintForm()
    End Sub


    Private Sub btn_balance_click() Handles btn_balance.Click
        Cursor = Cursors.WaitCursor
        status_bar.Text = "Rating system..." : status_bar.Refresh()
        'todo: try catch
        ' validates control inputs
        If Not vma_balance.Validate() Then
            warn(vma_balance.ErrorMessagesSummary)
            ''grd_results.DataSource = Nothing
        Else
            balance_system()
        End If

        status_bar.Text = "Ready"
        Cursor = Cursors.Default
    End Sub

    Private Sub btn_show_report_click() Handles btn_show_report.Click
        Cursor = Cursors.WaitCursor
        status_bar.Text = "Creating report..."

        Try
            btn_balance_click()
            show_report()
        Catch ex As Exception
            alert("An exception occurred while attempting to create balance report. " & ex.Message)
        Finally
            status_bar.Text = "Ready"
            Cursor = Cursors.Default
        End Try
    End Sub


    ''' <summary>Handles a data cell in the datagrid being clicked</summary>
    ''Private Sub unit_coolers_grid_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles unit_coolers_grid.MouseDown _

    ''    'use event MouseDown not Click, SelectedItems is apparently not updated before Click event executes
    ''    Dim row = unit_coolers_grid.RowContaining(e.Y)
    ''    Try
    ''        fill_unit_cooler_controls_for_selected_row(row)
    ''    Catch ex As Exception
    ''        alert(ex.Message)
    ''    End Try
    ''End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'use event MouseDown not Click, SelectedItems is apparently not updated before Click event executes
        Dim row = e.RowIndex
        Try
            fill_unit_cooler_controls_for_selected_row(row)
        Catch ex As Exception
            alert(ex.Message)
        End Try
    End Sub

#End Region

    Private Sub radCustomCondensingUnit_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles customCondensingUnitRadioButton.CheckedChanged

        'cmdGetCustomCUCapacity.Visible = customCondensingUnitRadioButton.Checked
        SetRatingControls(customCondensingUnitRadioButton.Checked)

        'If Me.customCondensingUnitRadioButton.Checked Then
        '    Me.rateSystemButton.Enabled = False
        '    Me.viewReportButton.Enabled = False
        '    Me.balanceToolTip.SetToolTip(Me.rateSystemButton, "The system cannot be rated when a custom condensing unit is selected.")
        '    Me.balanceToolTip.SetToolTip(Me.viewReportButton, "The report cannot be viewed when a custom condensing unit is selected.")
        '    Me.C1dgrResults.DataSource = Nothing
        '    Me.printButton.Visible = True
        'Else
        Me.btn_balance.Enabled = True
        Me.btn_show_report.Enabled = True
        Me.balanceToolTip.SetToolTip(Me.btn_balance, "")
        Me.balanceToolTip.SetToolTip(Me.btn_show_report, "")
        Me.btn_print.Visible = False
        'End If
    End Sub


    Private Sub radCondensingUnit1_CheckedChanged(ByVal sender As System.Object,
    ByVal e As System.EventArgs) Handles condensingUnit1RadioButton.CheckedChanged
        ' highlights selected condensing unit model
        If Me.condensingUnit1RadioButton.Checked = True Then
            condensingUnit1DescriptionLabel.BackColor = Color.Yellow
        Else
            condensingUnit1DescriptionLabel.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub radCondensingUnit2_CheckedChanged(ByVal sender As System.Object,
    ByVal e As System.EventArgs) Handles condensingUnit2RadioButton.CheckedChanged
        ' sets selected condensing unit backcolor
        If Me.condensingUnit2RadioButton.Checked Then
            Me.condensingUnit2DescriptionLabel.BackColor = Color.Yellow
        Else
            Me.condensingUnit2DescriptionLabel.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub radCondensingUnit3_CheckedChanged(ByVal sender As System.Object,
    ByVal e As System.EventArgs) Handles condensingUnit3RadioButton.CheckedChanged
        ' sets selected condensing unit backcolor
        If Me.condensingUnit3RadioButton.Checked Then
            Me.condensingUnit3DescriptionLabel.BackColor = Color.Yellow
        Else
            Me.condensingUnit3DescriptionLabel.BackColor = Color.Transparent
        End If
    End Sub


    Private Sub btnClearUnitCooler1_Click() _
    Handles btn_clear_unit_cooler_1.Click
        ClearUnitCooler1()
        presenter.calculate_balance()
    End Sub

    Private Sub btnClearUnitCooler2_Click() _
    Handles btn_clear_unit_cooler_2.Click
        ClearUnitCooler2()
        presenter.calculate_balance()
    End Sub

    Private Sub btnClearUnitCooler3_Click() _
    Handles btn_clear_unit_cooler_3.Click
        ClearUnitCooler3()
        presenter.calculate_balance()
    End Sub

    ''' <summary>Handles error label's TextChanged event</summary>
    Private Sub lblErrors_TextChanged(ByVal sender As System.Object,
    ByVal e As System.EventArgs) Handles lblErrors.TextChanged
        ' sets error label's tooltip to its text
        Me.balanceToolTip.SetToolTip(Me.lblErrors, Me.lblErrors.Text)

        ' checks if there are errors
        If lblErrors.Text = "" Then
            ' hides footer containing error messages
            Me.panFooter.Visible = False
        Else
            Me.panFooter.Visible = True
        End If
    End Sub


    Private Sub radOneRoom_CheckedChanged() Handles oneRoomComboBox.CheckedChanged
        setVisibilityForControlsDependentOnNumberOfRooms()
        changesSinceFindUnitCoolers.Add("Number of Rooms radiobutton")
    End Sub

    Private Sub radMultipleRooms_CheckedChanged() Handles multipleRoomsComboBox.CheckedChanged
        setVisibilityForControlsDependentOnNumberOfRooms()
        changesSinceFindUnitCoolers.Add("Number of Rooms radiobutton")
    End Sub


    ''' <summary>Handles refrigerant combobox SelectedIndexChanged event</summary>
    Private Sub refrigerantComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles cbo_refrigerant.SelectedIndexChanged
        ' indicates refrigerant has changed
        changesSinceFindCondensingUnit.Add("Refrigerant combobox")
        changesSinceFindUnitCoolers.Add("Refrigerant combobox")
    End Sub



    ''' <summary>Handles unit cooler datagrid's increment height button click event
    ''' </summary>
    ''Private Sub btnUnitCoolIncr_Click(ByVal sender As System.Object,
    ''ByVal e As System.EventArgs)
    ''    Const rowHeight As Integer = 17

    ''    ' increases height of panel containing unit cooler datagrid
    ''    Me.panUnitCoolGrid.Height = panUnitCoolGrid.Height + rowHeight
    ''    ' increases unit cooler datagrid size
    ''    Me.unit_coolers_grid.Height = unit_coolers_grid.Height + rowHeight
    ''End Sub

    ''' <summary>Handles unit cooler datagrid's decrement height button click event</summary>
    ''Private Sub btnUnitCoolGridDecr_Click(ByVal sender As System.Object,
    ''ByVal e As System.EventArgs)
    ''    Const rowHeight As Integer = 17
    ''    Const minHeight As Integer = 34

    ''    If Me.unit_coolers_grid.Height > minHeight Then
    ''        ' decrements height of panel containing unit cooler datagrid
    ''        Me.panUnitCoolGrid.Height = panUnitCoolGrid.Height - rowHeight
    ''        ' decrements height of unit cooler datagrid
    ''        Me.unit_coolers_grid.Height = unit_coolers_grid.Height - rowHeight
    ''    End If
    ''End Sub

    ''' <summary>Handles results datagrid's increment height button click event
    ''' </summary>
    ''Private Sub btnBalaGridIncr_Click(ByVal sender As System.Object,
    ''ByVal e As System.EventArgs)
    ''    Const rowHeight As Integer = 17

    ''    ' increments height of panel
    ''    Me.panBalaGrid.Height = panBalaGrid.Height + rowHeight
    ''    ' increments height of datagrid
    ''    ''Me.grd_results.Height = grd_results.Height + rowHeight
    ''End Sub

    ''' <summary>Handles results datagrid's decrement height button click event
    ''' </summary>
    ''Private Sub btnBalaGridDecr_Click(ByVal sender As System.Object,
    ''ByVal e As System.EventArgs)
    ''    Const rowHeight As Integer = 17
    ''    Const minHeight As Integer = 34

    ''    ' checks datagrid's height is not to small
    ''    If Me.grd_results.Height > minHeight Then
    ''        ' increments height of panel
    ''        Me.panBalaGrid.Height = Me.panBalaGrid.Height - rowHeight
    ''        ' increments height of datagrid
    ''        Me.grd_results.Height = Me.grd_results.Height - rowHeight
    ''    End If
    ''End Sub


    ''' <summary>Adjusts footer's height</summary>
    Private Sub picError_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) _
    Handles picError.DoubleClick
        If Me.panFooter.Height <= 32 Then
            Me.panFooter.Height = 17 * 10
        ElseIf Me.picError.Height > 17 Then
            Me.panFooter.Height = 32
        End If
    End Sub


#Region " Validation"

    ''' <summary>Validates suction temperature text box
    ''' </summary>
    ''' <history>[CASEYJ]	6/6/2005	Created
    ''' </history>
    Private Sub txtSuctionTemp_Validating(ByVal sender As System.Object,
    ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_suction_temp.Validating

        'sets error provider error message
        Me.vcoSuctionTemperature.Validate()
    End Sub

    ''' <summary>Validates number of condensing units text box
    ''' </summary>
    ''' <history>[CASEYJ]	6/6/2005	Created
    ''' </history>
    Private Sub txtCondensingUnitsRequired_Validating(ByVal sender As Object,
    ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_condensing_unit_quantity.Validating

        'validates control
        Me.vcoNumCondensingUnits.Validate()
    End Sub

    ''' <summary>Validates altitude text box
    ''' </summary>
    ''' <history>[CASEYJ]	6/6/2005	Created
    ''' </history>
    Private Sub txtAltitude_Validating(ByVal sender As Object,
    ByVal e As System.ComponentModel.CancelEventArgs) Handles altitudeTextBox.Validating
        Me.vcoAltitude.Validate()
    End Sub



    ''' <summary>Validates capacity text box
    ''' </summary>
    ''' <history>[CASEYJ]	6/6/2005	Created
    ''' </history>
    Private Sub txtCapacityRequired_Validating(ByVal sender As Object,
    ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_capacity_required.Validating

        Me.vcoCapacity.Validate()
    End Sub

    ''' <summary>Validates run time text box
    ''' </summary>
    ''' <history>[CASEYJ]	6/6/2005	Created
    ''' </history>
    Private Sub txtRunTimeHours_Validating(ByVal sender As Object,
    ByVal e As System.ComponentModel.CancelEventArgs) Handles runTimeTextBox.Validating

        Me.vcoRunTime.Validate()
    End Sub

    ''' <summary>Validates ambient temperature text box
    ''' </summary>
    ''' <history>[CASEYJ]	6/6/2005	Created
    ''' </history>
    Private Sub txtAmbientTemp_Validating(ByVal sender As Object,
    ByVal e As System.ComponentModel.CancelEventArgs) Handles ambientTemperatureTextBox.Validating

        Me.vcoAmbientTemperature.Validate()
    End Sub

    ''' <summary>Validates room temperature text box
    ''' </summary>
    ''' <history>[CASEYJ]	6/6/2005	Created
    ''' </history>
    Private Sub txtRoomTemp_Validating(ByVal sender As Object,
    ByVal e As System.ComponentModel.CancelEventArgs) Handles roomTemperatureTextBox.Validating

        Me.vcoRoomTemperature.Validate()
    End Sub

    ''' <summary>Validates number of unit coolers of the first model type
    ''' </summary>
    ''' <history>[CASEYJ]	6/6/2005	Created
    ''' </history>
    Private Sub txtUnitCooler1Quantity_Validating(ByVal sender As Object,
    ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles txt_unit_cooler_quantity_1.Validating
        Me.vcoNumUnitCoolers1.Validate()
    End Sub

    ''' <summary>Validates number of unit coolers of the second model type
    ''' </summary>
    ''' <history>[CASEYJ]	6/6/2005	Created
    ''' </history>
    Private Sub txtUnitCooler2Quantity_Validating(ByVal sender As Object,
    ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles txt_unit_cooler_quantity_2.Validating
        Me.vcoNumUnitCoolers2.Validate()
    End Sub

    ''' <summary>Validates number of unit coolers of the third model type
    ''' </summary>
    ''' <history>[CASEYJ]	6/6/2005	Created
    ''' </history>
    Private Sub txtUnitCooler3Quantity_Validating(ByVal sender As Object,
    ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles txt_unit_cooler_quantity_3.Validating
        Me.vcoNumUnitCoolers3.Validate()
    End Sub

#End Region


#Region " Calculates est. capacity balance"

    Private Sub txt_unit_cooler_quantity_1_TextChanged() Handles txt_unit_cooler_quantity_1.TextChanged
        If is_loading = False Then

            txt_evaporator_capacity_per_degree_1.Text =
                (ConvertNull.ToDouble(txt_evaporator_capacity_per_degree_1.Tag) _
               * grab_unit_cooler_quantity_1()).ToString(whole_number_format)
            presenter.calculate_balance()
            clear_balance_results()
        End If
    End Sub

    Private Sub txt_unit_cooler_quantity_2_TextChanged() Handles txt_unit_cooler_quantity_2.TextChanged
        If is_loading = False Then
            txt_evaporator_capacity_per_degree_2.Text =
                (ConvertNull.ToDouble(txt_evaporator_capacity_per_degree_2.Tag) _
               * grab_unit_cooler_quantity_2()).ToString(whole_number_format)
            presenter.calculate_balance()
            clear_balance_results()
        End If
    End Sub

    Private Sub txtUnitCooler3Quantity_TextChanged() Handles txt_unit_cooler_quantity_3.TextChanged
        If is_loading = False Then
            txt_evaporator_capacity_per_degree_3.Text =
                (ConvertNull.ToDouble(Me.txt_evaporator_capacity_per_degree_3.Tag) _
               * grab_unit_cooler_quantity_3()).ToString(whole_number_format)
            presenter.calculate_balance()
            clear_balance_results()
        End If
    End Sub


    Private Sub txtUnitCoolerCapacity_TextChanged() _
    Handles txt_unit_cooler_capacity_1.TextChanged, txt_unit_cooler_capacity_2.TextChanged, txt_unit_cooler_capacity_3.TextChanged
        If is_loading = False Then
            presenter.calculate_balance()
            clear_balance_results()
        End If
    End Sub

    ''' <summary>Handles Custom Unit Cooler's Quantity or Capacity textbox 
    ''' Textchanged event</summary>
    Private Sub txtCustomUnitCoolerCapacity_TextChanged() _
    Handles txt_custom_uc_capacity.TextChanged, txt_custom_uc_quantity.TextChanged
        If chk_custom_unit_cooler.Checked Then
            presenter.calculate_balance()
            clear_balance_results()
        End If
    End Sub

    ''' <summary>Handles Custom Unit Cooler checkbox CheckChanged event</summary>
    Private Sub chkCustomUnitCooler_CheckedChanged() _
    Handles chk_custom_unit_cooler.CheckedChanged
        presenter.calculate_balance()
        clear_balance_results()
    End Sub

#End Region

#End Region


    ''' <summary>Determines condensing unit's visibility and check state.
    ''' </summary>
    ''' <history>[CASEYJ]	5/31/2005	Created
    ''' </history>
    Private Sub FormatCondensingUnits()
        'if condensing unit label is nothing, make RB invisible; else make RB visible
        '1
        If Me.condensingUnit1DescriptionLabel.Text = "" Then
            Me.condensingUnit1DescriptionLabel.Visible = False 'cj
            Me.condensingUnit1RadioButton.Visible = False
            Me.condensingUnit1CondenserCapacityPerDegreeTextBox.Visible = False
        Else
            condensingUnit1DescriptionLabel.Visible = True  'cj
            condensingUnit1RadioButton.Visible = True
            condensingUnit1CondenserCapacityPerDegreeTextBox.Visible = True
        End If
        '2
        If Me.condensingUnit2DescriptionLabel.Text = "" Then
            condensingUnit2DescriptionLabel.Visible = False 'cj
            condensingUnit2RadioButton.Visible = False
            condensingUnit2CondenserCapacityTextBox.Visible = False
        Else
            condensingUnit2DescriptionLabel.Visible = True  'cj
            condensingUnit2RadioButton.Visible = True
            condensingUnit2CondenserCapacityTextBox.Visible = True
        End If
        '3
        If Me.condensingUnit3DescriptionLabel.Text = "" Then
            condensingUnit3DescriptionLabel.Visible = False 'cj
            condensingUnit3RadioButton.Visible = False
            condensingUnit3CondenserCapacityTextBox.Visible = False
        Else
            condensingUnit3DescriptionLabel.Visible = True  'cj
            condensingUnit3RadioButton.Visible = True
            condensingUnit3CondenserCapacityTextBox.Visible = True
        End If

        'if condensing unit RB is not visible, uncheck RB
        If Me.condensingUnit1RadioButton.Visible = False Then
            If Me.condensingUnit1RadioButton.Checked = True Then
                Me.condensingUnit1RadioButton.Checked = False
            End If
        End If
        If Me.condensingUnit2RadioButton.Visible = False Then
            If condensingUnit2RadioButton.Checked = True Then
                condensingUnit2RadioButton.Checked = False
            End If
        End If
        If Me.condensingUnit3RadioButton.Visible = False Then
            If condensingUnit3RadioButton.Checked = True Then
                condensingUnit3RadioButton.Checked = False
            End If
        End If

        'if condensing unit RB not selected, check first visible RB
        If Me.condensingUnit1RadioButton.Checked = False _
        AndAlso Me.condensingUnit2RadioButton.Checked = False _
        AndAlso Me.condensingUnit3RadioButton.Checked = False Then
            If Me.condensingUnit1RadioButton.Visible = True Then
                Me.condensingUnit1RadioButton.Checked = True
            ElseIf Me.condensingUnit2RadioButton.Visible = True Then
                Me.condensingUnit2RadioButton.Checked = True
            ElseIf condensingUnit3RadioButton.Visible = True Then
                Me.condensingUnit3RadioButton.Checked = True
            End If
        End If
    End Sub


    Private Sub showControlsChangedAfterFindCondensingUnitMessage()
        Dim message As String = ""
        Dim i As Integer
        Dim list() As String = changesSinceFindCondensingUnit.ToArray()

        For i = 0 To changesSinceFindCondensingUnit.Count - 1
            message &= list(i) & ", "
        Next
        MsgBox("The values entered into the following control(s) were modified after 'Find Condensing Units' was clicked." & Chr(10) & Chr(13) _
         & "     " & message & Chr(10) & Chr(13) _
         & "In order to get accurate results please click 'Find Condensing Units' again before proceeding." _
         & Chr(10) & Chr(13) & Chr(10) & Chr(13) _
         & "Filling out the form in the order presented will prevent this exception.",
         MsgBoxStyle.OkOnly, "RAESolutions")
    End Sub


    Private Sub clearUnitCoolers()
        Me.ClearUnitCooler1()
        Me.ClearUnitCooler2()
        Me.ClearUnitCooler3()
        ''Me.unit_coolers_grid.ClearFields()

        presenter.calculate_balance()
        clear_balance_results()
    End Sub

    Private Sub clear_balance_results()
        Me.results_dataset.balance_results.Clear()
        ''Me.grd_results.DataSource = Nothing
    End Sub

    Friend Function grab_fill_unit_coolers_validators() As validator_list
        Dim suction_temp = grab_suction_temp()
        Dim suction_line_loss = grab_suction_line_loss()
        Dim room_temp = grab_room_temp()

        Dim evaporating_temp = suction_temp - suction_line_loss

        Dim validators = New validator_list()

        Dim td_range As Rae.validation.i_validate
        If there_is_one_room() Then
            Dim td = Abs(room_temp - evaporating_temp)
            td_range = New td_is_in_range_for_one_room(td)
        Else
            Dim min_room_temp = CNull.ToDouble(txt_min_room_temp.Text.Trim)
            Dim max_room_temp = CNull.ToDouble(txt_max_room_temp.Text.Trim)
            Dim low_td = min_room_temp - evaporating_temp
            Dim high_td = max_room_temp - evaporating_temp
            td_range = New td_is_in_range_for_multiple_rooms(low_td, high_td)
        End If

        Return validators
    End Function

    Friend Function grab_criteria_to_find_unit_coolers() As unit_coolers.criteria
        Dim criteria As unit_coolers.criteria

        criteria.filter_by_capacity = Not chk_unit_cooler_override.Checked
        criteria.capacity_balance = grab_balance() '* 1.15
        criteria.refrigerant = grab_refrigerant()
        criteria.series = grab_unit_cooler_series()
        criteria.suction_temp = grab_suction_temp()
        Dim room_temp = grab_room_temp()
        criteria.td = room_temp - criteria.suction_temp
        criteria.user_is_employee = user.is_employee
        criteria.DOEModels = ddlDOE.Text

        Return criteria
    End Function

    Private Function grab_balance() As Double
        Return CNull.ToDouble(txt_balance.Text)
    End Function

    Private Function grab_unit_cooler_series() As String
        Return cbo_unit_cooler_series.SelectedItem
    End Function

    Private Sub balanceSystem()
        Dim condenser_capacity_per_degree = grab_condenser_capacity_per_degree()

        Dim balance As balance_system.balance
        If there_is_one_room() Then
            balance = create_balance_for_one_room()
        Else
            balance = create_balance_for_multiple_rooms()
        End If
        results_dataset = balance.run()
        If Not String.IsNullOrEmpty(balance.messages) Then alert(balance.messages)
    End Sub


    'increases evaporating temperature until condensing unit capacity < evaporator capacity

#Region "Datagrids"

    'Create Data Source for Unit Cooler Datagrid that has:
    '** 1. unit cooler model
    '** 2. unit cooler capacity
    '** 3. quantity of unit coolers required to fulfill remaining capacity balance
    Private Function CreateUnitCoolersDatasource(
    ByVal unitCoolerModels As List(Of String),
    ByVal unitCoolerCapacities As List(Of Double),
    ByVal balance As Double) As ICollection
        Dim DT As New DataTable
        Dim DR As DataRow
        Dim i As Integer

        DT.TableName = "UnitCooler"

        ' Note: columns 1 and 3 are both unit cooler capacity but format is different
        ' creates data table columns
        DT.Columns.Add(New DataColumn("Model", GetType(String)))
        DT.Columns.Add(New DataColumn("Capacity", GetType(String)))
        DT.Columns.Add(New DataColumn("Required", GetType(String)))
        DT.Columns.Add(New DataColumn("BTUH", GetType(String)))

        ' adds row for each unit cooler
        For i = 0 To (unitCoolerModels.Count - 1)
            DR = DT.NewRow()

            DR(0) = unitCoolerModels(i).ToString
            If AppInfo.Division = Division.TSI Then
                DR(1) = Round(unitCoolerCapacities(i) / 12000, digits)
                DR(2) = Round(balance / Round(unitCoolerCapacities(i) / 12000, digits), 2)
                DR(3) = Round(unitCoolerCapacities(i) / 12000, digits)
            Else
                DR(1) = Format(Round(unitCoolerCapacities(i), digits), "###,###,###")
                DR(2) = Round(balance / unitCoolerCapacities(i), 2)
                DR(3) = Format(Round(unitCoolerCapacities(i), digits), "#########")
            End If

            DT.Rows.Add(DR)
        Next

        Return DT.DefaultView
    End Function

#End Region


    '1. fills and formats unit cooler textboxes (model, quantity, capacity)
    '2. calls CalculateBalance
    Private Sub fill_unit_cooler_controls_for_selected_row(ByVal row As Integer)
        If row >= 0 Then

            Dim ucr = New unit_coolers.repository


            ' clears UC / CU balance
            Me.clear_balance_results()

            '1
            If rbo_unit_cooler_1.Checked Then
                'Dim model1 = unit_coolers_grid.Columns(0).CellValue(row).ToString
                Dim model = DataGridView1.Rows(row).Cells(0).Value.ToString
                'Dim capacity1 = CDbl(unit_coolers_grid.Columns(2).CellValue(row))
                Dim capacity = CDbl(DataGridView1.Rows(row).Cells(2).Value)
                'Dim quantity1 = CInt(unit_coolers_grid.Columns(1).CellValue(row))
                Dim quantity = CDbl(DataGridView1.Rows(row).Cells(1).Value)
                If quantity < 1 Then quantity = 1
                quantity = System.Math.Round(quantity)
                txt_unit_cooler_model_1.Text = model
                txt_unit_cooler_capacity_1.Text = capacity.ToString(whole_number_format)
                'Unit cooler quantity change causes event to occur that 
                'calls calculate balance. When called from this routine it
                'causes invalid calculations, if the unit cooler capacity is not set yet.
                'So it is necessary to set unit cooler quantity after capacity is set.
                txt_unit_cooler_quantity_1.Text = quantity


                txt_unit_cooler_DOE_1.Text = ucr.CheckDOE(model)



                Dim unit_cooler = service.get_unit_cooler(model)
                'todo: this may be different than before
                Dim capacity_per_degree = unit_cooler.capacity_per_degree_at(grab_suction_temp, 0)
                'capacity_per_degree = new unit_cooler_capacity_per_degree(txt_unit_cooler_model_1.text).capacity_per_degree
                txt_evaporator_capacity_per_degree_1.Tag = capacity_per_degree ' new unit_cooler_capacity_per_degree(txt_unit_cooler_model_1.text).capacity_per_degree
                txt_evaporator_capacity_per_degree_1.Text = (capacity_per_degree * quantity).ToString(whole_number_format)

                'highlights updated fields
                txt_unit_cooler_model_1.BackColor = Color.Yellow
                txt_unit_cooler_capacity_1.BackColor = Color.Yellow
                txt_unit_cooler_quantity_1.BackColor = Color.Yellow
                txt_evaporator_capacity_per_degree_1.BackColor = Color.Yellow

                ' shows static
                rbo_0_static_1.Visible = unit_cooler.at.ContainsKey(0)
                rbo_0_static_1.Checked = True
                rbo_025_static_1.Visible = unit_cooler.at.ContainsKey(0.25)
                rbo_050_static_1.Visible = unit_cooler.at.ContainsKey(0.5)

                '2
            ElseIf rbo_unit_cooler_2.Checked Then
                'Dim model1 = unit_coolers_grid.Columns(0).CellValue(row).ToString
                Dim model = DataGridView1.Rows(row).Cells(0).Value.ToString
                'Dim capacity1 = CDbl(unit_coolers_grid.Columns(2).CellValue(row))
                Dim capacity = CDbl(DataGridView1.Rows(row).Cells(2).Value)
                'Dim quantity1 = CInt(unit_coolers_grid.Columns(1).CellValue(row))
                Dim quantity = CDbl(DataGridView1.Rows(row).Cells(1).Value)
                If quantity < 1 Then quantity = 1
                quantity = System.Math.Round(quantity)
                txt_unit_cooler_model_2.Text = model
                txt_unit_cooler_capacity_2.Text = capacity.ToString(whole_number_format)
                txt_unit_cooler_quantity_2.Text = quantity

                txt_unit_cooler_DOE_2.Text = ucr.CheckDOE(model)


                Dim unit_cooler = service.get_unit_cooler(model)
                Dim capacity_per_degree = unit_cooler.capacity_per_degree_at(grab_suction_temp, 0)
                txt_evaporator_capacity_per_degree_2.Tag = capacity_per_degree
                txt_evaporator_capacity_per_degree_2.Text = (capacity_per_degree * quantity).ToString(whole_number_format)

                'highlights updated fields
                txt_unit_cooler_model_2.BackColor = Color.Yellow
                txt_unit_cooler_capacity_2.BackColor = Color.Yellow
                txt_unit_cooler_quantity_2.BackColor = Color.Yellow
                txt_evaporator_capacity_per_degree_2.BackColor = Color.Yellow

                rbo_0_static_2.Visible = unit_cooler.at.ContainsKey(0)
                rbo_0_static_2.Checked = True
                rbo_025_static_2.Visible = unit_cooler.at.ContainsKey(0.25)
                rbo_050_static_2.Visible = unit_cooler.at.ContainsKey(0.5)

                '3
            ElseIf rbo_unit_cooler_3.Checked Then
                'Dim model1 = unit_coolers_grid.Columns(0).CellValue(row).ToString
                Dim model = DataGridView1.Rows(row).Cells(0).Value.ToString
                'Dim capacity1 = CDbl(unit_coolers_grid.Columns(2).CellValue(row))
                Dim capacity = CDbl(DataGridView1.Rows(row).Cells(2).Value)
                'Dim quantity1 = CInt(unit_coolers_grid.Columns(1).CellValue(row))
                Dim quantity = CDbl(DataGridView1.Rows(row).Cells(1).Value)
                If quantity < 1 Then quantity = 1
                quantity = System.Math.Round(quantity)
                txt_unit_cooler_model_3.Text = model
                txt_unit_cooler_capacity_3.Text = capacity.ToString(whole_number_format)
                txt_unit_cooler_quantity_3.Text = quantity

                txt_unit_cooler_DOE_3.Text = ucr.CheckDOE(model)


                Dim unit_cooler = service.get_unit_cooler(model)
                Dim capacity_per_degree = unit_cooler.capacity_per_degree_at(grab_suction_temp, 0)

                txt_evaporator_capacity_per_degree_3.Tag = capacity_per_degree
                txt_evaporator_capacity_per_degree_3.Text = (capacity_per_degree * quantity).ToString(whole_number_format)

                txt_unit_cooler_model_3.BackColor = Color.Yellow
                txt_unit_cooler_capacity_3.BackColor = Color.Yellow
                txt_unit_cooler_quantity_3.BackColor = Color.Yellow
                txt_evaporator_capacity_per_degree_3.BackColor = Color.Yellow

                rbo_0_static_3.Visible = unit_cooler.at.ContainsKey(0)
                rbo_0_static_3.Checked = True
                rbo_025_static_3.Visible = unit_cooler.at.ContainsKey(0.25)
                rbo_050_static_3.Visible = unit_cooler.at.ContainsKey(0.5)
            End If

            presenter.calculate_balance()
        End If
    End Sub






    Sub Open(ByVal processItem As cu_uc_balance_screen_model)
        Me.LoadControls(processItem)
    End Sub

    Public Const whole_number_format As String = "#,#"

    Sub LoadControls(ByVal processItem As cu_uc_balance_screen_model)

        ' If latest revision has not been set then
        ' we need to set it now  based on the ID...
        If Me.m_Latestrevision = -1 Then
            Me.m_Latestrevision = Rae.RaeSolutions.DataAccess.Projects.ProcessItemDA.LastestRevision(Me.Tag)
        End If

        ' Increment the current process revision
        ' displayed on this form...
        Me.m_Currentrevision = processItem.Revision

        ' Clone last saved process to passing process item
        LastSavedProcess = processItem.Clone()




        If String.IsNullOrEmpty(Me.LastSavedProcess.condensing_unit_series) Then
            Me.cboCondensingUnitSeries.SelectedIndex = 0
        Else
            Me.cboCondensingUnitSeries.Text = Me.LastSavedProcess.condensing_unit_series
        End If
        Me.adjustCapacityForRunTimeYesRadioButton.Checked = Me.LastSavedProcess.capacity_is_adjusted_for_runtime
        Me.runTimeTextBox.Text = Me.LastSavedProcess.run_time_hours_per_day.ToString
        If String.IsNullOrEmpty(LastSavedProcess.compressor_type) Then
            Me.compressorTypeComboBox.SelectedIndex = 0
        Else
            Me.compressorTypeComboBox.Text = Me.LastSavedProcess.compressor_type
        End If
        'old projects may have refrigerants formatted like R507aL so convert that to R507

        If Not Me.LastSavedProcess.refrigerant Is Nothing Then
            cbo_refrigerant.Text = refrigerant.parse(Me.LastSavedProcess.refrigerant).value

        End If



        If Me.LastSavedProcess.compressor_quantity_per_unit = 0 Then
            Me.numCompressorsPerUnitComboBox.SelectedIndex = 0
        Else
            Me.numCompressorsPerUnitComboBox.Text = Me.LastSavedProcess.compressor_quantity_per_unit.ToString
        End If
        If Me.LastSavedProcess.refrigerant_circuits_per_unit = 0 Then
            Me.numCircuitsPerUnitComboBox.SelectedIndex = 0
        Else
            Me.numCircuitsPerUnitComboBox.Text = Me.LastSavedProcess.refrigerant_circuits_per_unit.ToString
        End If

        Me.txt_capacity_required.Text = Me.LastSavedProcess.capacity_required.ToString
        Me.altitudeTextBox.Text = Me.LastSavedProcess.altitude.ToString
        Me.txt_condensing_unit_quantity.Text = Me.LastSavedProcess.condensing_unit_quantity.ToString
        Me.txt_suction_temp.Text = Me.LastSavedProcess.suction.ToString

        If Me.LastSavedProcess.rooms = 1 Then
            Me.oneRoomComboBox.Checked = True
        Else
            Me.multipleRoomsComboBox.Checked = True
        End If

        Me.ambientTemperatureTextBox.Text = Me.LastSavedProcess.ambient.ToString
        Me.txt_min_ambient.Text = Me.LastSavedProcess.min_ambient.ToString
        Me.txt_max_ambient.Text = Me.LastSavedProcess.max_ambient.ToString
        Me.incrementAmbientTemperatureTextBox.Text = Me.LastSavedProcess.ambient_increment.ToString

        Me.roomTemperatureTextBox.Text = Me.LastSavedProcess.room_temperature.ToString
        Me.txt_min_room_temp.Text = Me.LastSavedProcess.min_room_temperature.ToString
        Me.txt_max_room_temp.Text = Me.LastSavedProcess.max_room_temperature.ToString
        Me.incrementRoomTemperatureTextBox.Text = Me.LastSavedProcess.room_temperature_increment.ToString



        If String.IsNullOrEmpty(Me.LastSavedProcess.DOEModel) Then
            Me.ddlDOE.Text = "No"
        Else
            Me.ddlDOE.Text = Me.LastSavedProcess.DOEModel
        End If





        openBoxLoad()

        ' finds condensing units
        If CNull.ToDouble(txt_capacity_required.Text) > 0 Then
            Me.findCondensingUnitsButton_Click(findCondensingUnitsButton, Nothing)
        End If

        ' set condensing unit rating
        If Not String.IsNullOrEmpty(Me.LastSavedProcess.ObjectLinkXML) Then
            Me.CondensingUnitRating = New Rae.RaeSolutions.Business.Entities.CondensingUnitProcessItem()
            Me.CondensingUnitRating = Rae.RaeSolutions.Utility.Deserialize(Me.LastSavedProcess.ObjectLinkXML.ToString, Me.CondensingUnitRating.GetType)
        End If

        Dim modelFromRadioBox As String
        Dim modelFound As Boolean = False
        If condensingUnit1RadioButton.Visible Then
            modelFromRadioBox = condensingUnit1DescriptionLabel.Text.Substring(0, Me.condensingUnit1DescriptionLabel.Text.IndexOf(" "))
            If modelFromRadioBox = Me.LastSavedProcess.condensing_unit_model Then 'And _
                'Val(Me.condensingUnit1CondenserCapacityPerDegreeTextBox.Text) = Me.LastSavedProcess.CondenserCapacityPerDegree Then
                condensingUnit1RadioButton.Checked = True
                modelFound = True
            End If
        End If
        If Not modelFound Then
            If condensingUnit2RadioButton.Visible Then
                modelFromRadioBox = Me.condensingUnit2DescriptionLabel.Text.Substring(0, Me.condensingUnit2DescriptionLabel.Text.IndexOf(" "))
                If modelFromRadioBox = Me.LastSavedProcess.condensing_unit_model Then 'And _
                    'Val(Me.condensingUnit2CondenserCapacityTextBox.Text) = Me.LastSavedProcess.CondenserCapacityPerDegree Then
                    condensingUnit2RadioButton.Checked = True
                    modelFound = True
                End If
            End If
        End If
        If Not modelFound Then
            If Me.condensingUnit3RadioButton.Visible Then
                modelFromRadioBox = Me.condensingUnit3DescriptionLabel.Text.Substring(0, Me.condensingUnit3DescriptionLabel.Text.IndexOf(" "))
                If modelFromRadioBox = Me.LastSavedProcess.condensing_unit_model Then 'And _
                    'Val(Me.condensingUnit3CondenserCapacityTextBox.Text) = Me.LastSavedProcess.CondenserCapacityPerDegree Then
                    condensingUnit3RadioButton.Checked = True
                    modelFound = True
                End If
            End If
        End If
        If Not modelFound Then
            Me.customCondensingUnitRadioButton.Checked = True
            'SetRatingControls(True)
            'Me.customCondenserCapacityPerDegreeTextBox.Text = Me.LastSavedProcess.CondenserCapacityPerDegree
        End If

        ' unit coolers
        '
        Me.cbo_unit_cooler_series.Text = LastSavedProcess.unit_cooler_series
        Me.cbo_suction_line_loss.Text = LastSavedProcess.suction_line_loss.ToString
        Me.chk_unit_cooler_override.Checked = LastSavedProcess.do_not_filter_unit_coolers_based_on_capacity

        btn_find_unit_coolers_click()

        Select Case Me.LastSavedProcess.selected_unit_cooler_index
            Case 0 : Me.rbo_unit_cooler_1.Checked = True
            Case 1 : Me.rbo_unit_cooler_2.Checked = True
            Case 2 : Me.rbo_unit_cooler_3.Checked = True
            Case Else : Me.rbo_unit_cooler_1.Checked = True
        End Select

        If Me.LastSavedProcess.selected_unit_coolers.Count > 0 Then
            With Me.LastSavedProcess.selected_unit_coolers(0)
                Me.txt_unit_cooler_model_1.Text = .model
                Me.txt_unit_cooler_quantity_1.Text = .quantity.ToString
                Me.txt_unit_cooler_capacity_1.Text = .capacity.ToString(whole_number_format)
                Me.txt_evaporator_capacity_per_degree_1.Text = .capacity_per_degree.ToString(whole_number_format)
                Dim unit_cooler = New unit_coolers.repository().get_unit_cooler(.model)
                rbo_0_static_1.Visible = unit_cooler.at.ContainsKey(0)
                rbo_025_static_1.Visible = unit_cooler.at.ContainsKey(0.25)
                rbo_050_static_1.Visible = unit_cooler.at.ContainsKey(0.5)
                If .static_pressure = 0 Then
                    rbo_0_static_1.Checked = True
                ElseIf .static_pressure = 0.25 Then
                    rbo_025_static_1.Checked = True
                ElseIf .static_pressure = 0.5 Then
                    rbo_050_static_1.Checked = True
                End If
            End With
        End If
        If Me.LastSavedProcess.selected_unit_coolers.Count > 1 Then
            With Me.LastSavedProcess.selected_unit_coolers(1)
                txt_unit_cooler_model_2.Text = .model
                txt_unit_cooler_quantity_2.Text = .quantity.ToString
                txt_unit_cooler_capacity_2.Text = .capacity.ToString(whole_number_format)
                txt_evaporator_capacity_per_degree_2.Text = .capacity_per_degree.ToString(whole_number_format)
                Dim unit_cooler = New unit_coolers.repository().get_unit_cooler(.model)
                rbo_0_static_2.Visible = unit_cooler.at.ContainsKey(0)
                rbo_025_static_2.Visible = unit_cooler.at.ContainsKey(0.25)
                rbo_050_static_2.Visible = unit_cooler.at.ContainsKey(0.5)
                If .static_pressure = 0 Then
                    rbo_0_static_2.Checked = True
                ElseIf .static_pressure = 0.25 Then
                    rbo_025_static_2.Checked = True
                ElseIf .static_pressure = 0.5 Then
                    rbo_050_static_2.Checked = True
                End If
            End With
        End If
        If Me.LastSavedProcess.selected_unit_coolers.Count > 2 Then
            With Me.LastSavedProcess.selected_unit_coolers(2)
                txt_unit_cooler_model_3.Text = .model
                txt_unit_cooler_quantity_3.Text = .quantity.ToString
                txt_unit_cooler_capacity_3.Text = .capacity.ToString(whole_number_format)
                txt_evaporator_capacity_per_degree_3.Text = .capacity_per_degree.ToString(whole_number_format)
                Dim unit_cooler = New unit_coolers.repository().get_unit_cooler(.model)
                rbo_0_static_3.Visible = unit_cooler.at.ContainsKey(0)
                rbo_025_static_3.Visible = unit_cooler.at.ContainsKey(0.25)
                rbo_050_static_3.Visible = unit_cooler.at.ContainsKey(0.5)
                If .static_pressure = 0 Then
                    rbo_0_static_3.Checked = True
                ElseIf .static_pressure = 0.25 Then
                    rbo_025_static_3.Checked = True
                ElseIf .static_pressure = 0.5 Then
                    rbo_050_static_3.Checked = True
                End If
                'Me.findUnitCoolersButton_Click(Nothing, EventArgs.Empty)
            End With
        End If

        presenter.calculate_balance()

        Me.chk_custom_unit_cooler.Checked = Me.LastSavedProcess.custom_unit_cooler_is_selected

        Me.txt_custom_uc_model.Text = CNull.ToString(Me.LastSavedProcess.CustomUnitCooler.model)
        Me.txt_custom_uc_capacity.Text = Me.LastSavedProcess.CustomUnitCooler.capacity.ToString(whole_number_format)
        Me.txt_custom_uc_quantity.Text = Me.LastSavedProcess.CustomUnitCooler.quantity.ToString
        Me.txt_custom_evaporator_capacity.Text = Me.LastSavedProcess.CustomUnitCooler.capacity_per_degree.ToString

        If String.IsNullOrEmpty(grab_condensing_unit_model()) _
        OrElse Not Me.vma_balance.Validate() Then
            ''Me.grd_results.DataSource = Nothing
        Else
            Me.balance_system()
        End If

    End Sub


    ''' <summary>
    ''' Saves control values to new UnitCoolerProcessItem
    ''' and compares to existing UnitCoolerProcessItem (if exists)
    ''' to determine if we need to query user as to revise, update, etc...
    ''' </summary>
    Function SaveControls(Optional ByVal SaveAsRevision As Boolean = False, Optional ByVal SaveAsNew As Boolean = False, Optional ByVal FormClosing As Boolean = False, Optional ByVal GenerateEquipment As Boolean = False, Optional ByVal RevChanged As Boolean = False) As Boolean
        If CurrentStateProcess Is Nothing Then
            If LastSavedProcess Is Nothing Then
                CurrentStateProcess = New cu_uc_balance_screen_model(New item_id(user.username, user.password))
            Else
                CurrentStateProcess = LastSavedProcess.Clone
            End If
        Else
            If LastSavedProcess IsNot Nothing Then CurrentStateProcess = LastSavedProcess.Clone
        End If

        With Me.CurrentStateProcess
            ' associated condensing unit
            If Me.CondensingUnitRating IsNot Nothing Then
                .ObjectLinkXML = Rae.RaeSolutions.Utility.Serialize(Me.CondensingUnitRating)
                .ObjectLinkType = "CondensingUnitProcessItem"
            Else
                .ObjectLinkXML = ""
                .ObjectLinkType = ""
            End If

            ' saves condensing unit
            .condensing_unit_series = Me.cboCondensingUnitSeries.Text
            If Me.adjustCapacityForRunTimeYesRadioButton.Checked Then
                .capacity_is_adjusted_for_runtime = True
            Else
                .capacity_is_adjusted_for_runtime = False
            End If
            .run_time_hours_per_day = CNull.ToDouble(Me.runTimeTextBox.Text)
            .compressor_type = Me.compressorTypeComboBox.Text
            .refrigerant = Me.cbo_refrigerant.Text
            If Me.numCompressorsPerUnitComboBox.Text = "ALL" Then
                .compressor_quantity_per_unit = 0
            Else
                .compressor_quantity_per_unit = CInt(Me.numCompressorsPerUnitComboBox.Text)
            End If
            If Me.numCircuitsPerUnitComboBox.Text = "ALL" Then
                .refrigerant_circuits_per_unit = 0
            Else
                .refrigerant_circuits_per_unit = Val(numCircuitsPerUnitComboBox.Text)
            End If

            .condenser_capacity_per_degree = GrabCondensingPerDegreeCapacity()
            .capacity_required = CNull.ToDouble(Me.txt_capacity_required.Text)
            .altitude = CNull.ToDouble(Me.altitudeTextBox.Text)
            .condensing_unit_quantity = CNull.ToInteger(Me.txt_condensing_unit_quantity.Text)
            .suction = CNull.ToDouble(Me.txt_suction_temp.Text)

            If Me.oneRoomComboBox.Checked Then
                .rooms = 1
            Else
                .rooms = 2
            End If

            .ambient = Val(ambientTemperatureTextBox.Text)
            .min_ambient = Val(txt_min_ambient.Text)
            .max_ambient = Val(txt_max_ambient.Text)
            .ambient_increment = Val(incrementAmbientTemperatureTextBox.Text)

            .room_temperature = Val(roomTemperatureTextBox.Text)
            .min_room_temperature = Val(txt_min_room_temp.Text)
            .max_room_temperature = Val(txt_max_room_temp.Text)
            .room_temperature_increment = Val(incrementRoomTemperatureTextBox.Text)
            '.Series = cboCondensingUnitSeries.SelectedItem
            .condensing_unit_model = Me.grab_condensing_unit_model()
            .Model = .condensing_unit_model
            .unit_cooler_series = Me.cbo_unit_cooler_series.Text
            .suction_line_loss = Val(cbo_suction_line_loss.Text)
            .do_not_filter_unit_coolers_based_on_capacity = Me.chk_unit_cooler_override.Checked

            If Me.rbo_unit_cooler_1.Checked = True Then
                .selected_unit_cooler_index = 0
            ElseIf Me.rbo_unit_cooler_2.Checked = True Then
                .selected_unit_cooler_index = 1
            ElseIf Me.rbo_unit_cooler_3.Checked = True Then
                .selected_unit_cooler_index = 2
            End If
            If Me.chk_custom_unit_cooler.Checked = True Then
                .custom_unit_cooler_is_selected = True
                .CustomUnitCooler.model = Me.txt_custom_uc_model.Text
                .CustomUnitCooler.capacity = CNull.ToDouble(Me.txt_custom_uc_capacity.Text)
                .CustomUnitCooler.quantity = CNull.ToInteger(Me.txt_custom_uc_quantity.Text)
                .CustomUnitCooler.capacity_per_degree = CNull.ToDouble(Me.txt_custom_evaporator_capacity.Text)
            Else
                .custom_unit_cooler_is_selected = False
            End If

            .selected_unit_coolers.Clear()
            If Not String.IsNullOrEmpty(Me.txt_unit_cooler_model_1.Text) Then
                Dim unitCooler1 As cu_uc_balance_screen_model.UnitCooler
                unitCooler1.model = Me.txt_unit_cooler_model_1.Text
                unitCooler1.capacity = CNull.ToDouble(Me.txt_unit_cooler_capacity_1.Text)
                unitCooler1.quantity = CNull.ToInteger(Me.txt_unit_cooler_quantity_1.Text) * CNull.ToInteger(Me.txt_condensing_unit_quantity.Text)
                unitCooler1.capacity_per_degree = CNull.ToDouble(Me.txt_evaporator_capacity_per_degree_1.Text)
                unitCooler1.static_pressure = grab_static_pressure_1()
                .selected_unit_coolers.Add(unitCooler1)
            End If
            If Not String.IsNullOrEmpty(Me.txt_unit_cooler_model_2.Text) Then
                Dim unitCooler2 As cu_uc_balance_screen_model.UnitCooler
                unitCooler2.model = Me.txt_unit_cooler_model_2.Text
                unitCooler2.capacity = CNull.ToDouble(Me.txt_unit_cooler_capacity_2.Text)
                unitCooler2.quantity = CNull.ToInteger(Me.txt_unit_cooler_quantity_2.Text) * CNull.ToInteger(Me.txt_condensing_unit_quantity.Text)
                unitCooler2.capacity_per_degree = CNull.ToDouble(Me.txt_evaporator_capacity_per_degree_2.Text)
                unitCooler2.static_pressure = grab_static_pressure_2()
                .selected_unit_coolers.Add(unitCooler2)
            End If
            If Not String.IsNullOrEmpty(Me.txt_unit_cooler_model_3.Text) Then
                Dim unitCooler3 As cu_uc_balance_screen_model.UnitCooler
                unitCooler3.model = Me.txt_unit_cooler_model_3.Text
                unitCooler3.capacity = CNull.ToDouble(Me.txt_unit_cooler_capacity_3.Text)
                unitCooler3.quantity = CNull.ToInteger(Me.txt_unit_cooler_quantity_3.Text) * CNull.ToInteger(Me.txt_condensing_unit_quantity.Text)
                unitCooler3.capacity_per_degree = CNull.ToDouble(Me.txt_evaporator_capacity_per_degree_3.Text)
                unitCooler3.static_pressure = grab_static_pressure_3()
                .selected_unit_coolers.Add(unitCooler3)
            End If

            If results_dataset.balance_results.Count > 0 AndAlso results_dataset.balance_results(0).evaporating_temp <> "TD Too Low" Then
                Dim r = results_dataset.balance_results(0)
                .results.evaporating_temperature = r.evaporating_temp
                .results.suction = r.suction_temp
                .results.condensing_temperature = r.condensing_temp
                .results.td = r.td
                .results.capacity = r.Capacity
            End If


            .DOEModel = ddlDOE.Text

            ' box load update link was here

            'If FormClosing = False And CurrentStateProcess.Model = "" Or CurrentStateProcess.Model Is Nothing Then
            '   Ui.MessageBox.Show("No model number exists.  Choose a Unit Cooler first. (Click on the ratings tab)")
            '   Exit Function
            'End If

        End With

        ' Set save process...
        Dim RevSave As New RevisionSave
        CurrentStateProcess = RevSave.SetSaveProcess(Me, Business.ProcessType.UnitCoolerBalance, CurrentStateProcess, LastSavedProcess, SaveAsNew, SaveAsRevision, FormClosing, GenerateEquipment, RevChanged)
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

#Region " Private methods"

    Private Sub initializeValidation()
        Dim valRequiredSuctionTemperature As RequiredValidator
        Dim valNumberSuctionTemperature As RegularExpressionValidator
        Dim valRequiredNumCondensingUnits As RequiredValidator
        Dim valPositiveIntegerNumCondensingUnits As RegularExpressionValidator
        Dim valNumberAltitude As RegularExpressionValidator
        Dim valRequiredAltitude As RequiredValidator
        Dim valRequiredCapacity As RequiredValidator
        Dim valPositiveNumberCapacity As RegularExpressionValidator
        Dim valRequiredRunTime As RequiredValidator
        Dim valPositiveNumberRunTime As RegularExpressionValidator
        Dim valRequiredAmbientTemperature As RequiredValidator
        Dim valNumberAmbientTemperature As RegularExpressionValidator
        Dim valRequiredRoomTemperature As RequiredValidator
        Dim valNumberRoomTemperature As RegularExpressionValidator
        Dim valRequiredNumUnitCoolers1, valRequiredNumUnitCoolers2,
           valRequiredNumUnitCoolers3 As RequiredValidator
        Dim valPositiveIntegerNumUnitCoolers1, valPositiveIntegerNumUnitCoolers2,
           valPositiveIntegerNumUnitCOolers3 As RegularExpressionValidator

        'constructs validation manager for form
        Me.vmaBalance = New ValidationManager(Me.balanceErrorProvider)
        Me.vma_balance = New ValidationManager(Me.balanceErrorProvider)

        'constructs validation control for suction temperature textbox
        Me.vcoSuctionTemperature = New ValidationControl(Me.txt_suction_temp)
        'constructs required validator for suction temperature textbox
        valRequiredSuctionTemperature = New RequiredValidator(
           ErrorMessages.Required("Suction temperature text box"))
        'constructs number validator for suction temperature textbox
        valNumberSuctionTemperature = New RegularExpressionValidator(
           ErrorMessages.Number("Suction temperature text box"),
           regular_expressions.number)
        'adds suction temperature validation control
        Me.vmaBalance.ValidationControls.Add(Me.vcoSuctionTemperature)
        'adds validator to suction temperature control
        Me.vcoSuctionTemperature.Validators.Add(valRequiredSuctionTemperature)
        Me.vcoSuctionTemperature.Validators.Add(valNumberSuctionTemperature)

        'number of condensing units text box
        Me.vcoNumCondensingUnits = New ValidationControl(Me.txt_condensing_unit_quantity)
        valPositiveIntegerNumCondensingUnits = New RegularExpressionValidator(
           ErrorMessages.PositiveInteger("Number of condensing units text box"),
           regular_expressions.positive_integer())
        valRequiredNumCondensingUnits = New RequiredValidator(
           ErrorMessages.Required("Number of condensing units text box"))
        Me.vmaBalance.ValidationControls.Add(Me.vcoNumCondensingUnits)
        Me.vcoNumCondensingUnits.Validators.Add(valPositiveIntegerNumCondensingUnits)
        Me.vcoNumCondensingUnits.Validators.Add(valRequiredNumCondensingUnits)

        'altitude text box
        Me.vcoAltitude = New ValidationControl(Me.altitudeTextBox)
        valRequiredAltitude = New RequiredValidator(ErrorMessages.Required("Altitude text box"))
        valNumberAltitude = New RegularExpressionValidator(
           ErrorMessages.Number("Altitude text box"),
           regular_expressions.number())
        Me.vmaBalance.ValidationControls.Add(Me.vcoAltitude)
        Me.vcoAltitude.Validators.Add(valRequiredAltitude)
        Me.vcoAltitude.Validators.Add(valNumberAltitude)

        'capacity text box
        Me.vcoCapacity = New ValidationControl(Me.txt_capacity_required)
        valRequiredCapacity = New RequiredValidator(
           ErrorMessages.Required("Capacity text box"))
        valPositiveNumberCapacity = New RegularExpressionValidator(
           ErrorMessages.PositiveNumber("Capacity text box"),
           regular_expressions.positive_number)
        Me.vmaBalance.ValidationControls.Add(Me.vcoCapacity)
        Me.vcoCapacity.Validators.Add(valRequiredCapacity)
        Me.vcoCapacity.Validators.Add(valPositiveNumberCapacity)

        'run time text box
        Me.vcoRunTime = New ValidationControl(Me.runTimeTextBox)
        valRequiredRunTime = New RequiredValidator(
           ErrorMessages.Required("Run time hour text box"))
        valPositiveNumberRunTime = New RegularExpressionValidator(
           ErrorMessages.PositiveNumber("Run time hour text box"),
           validation.regular_expressions.positive_number)
        Me.vmaBalance.ValidationControls.Add(Me.vcoRunTime)
        Me.vcoRunTime.Validators.Add(valRequiredRunTime)
        Me.vcoRunTime.Validators.Add(valPositiveNumberRunTime)

        'ambient temperature text box
        Me.vcoAmbientTemperature = New ValidationControl(Me.ambientTemperatureTextBox)
        valRequiredAmbientTemperature = New RequiredValidator(
           ErrorMessages.Required("Ambient temperature text box"))
        valNumberAmbientTemperature = New RegularExpressionValidator(
           ErrorMessages.Number("Ambient temperature text box"),
           validation.regular_expressions.number)
        Me.vmaBalance.ValidationControls.Add(Me.vcoAmbientTemperature)
        Me.vcoAmbientTemperature.Validators.Add(valRequiredAmbientTemperature)
        Me.vcoAmbientTemperature.Validators.Add(valNumberAmbientTemperature)

        'room temperature text box
        Me.vcoRoomTemperature = New ValidationControl(Me.roomTemperatureTextBox)
        valRequiredRoomTemperature = New RequiredValidator(
           ErrorMessages.Required("Room temperature text box"))
        valNumberRoomTemperature = New RegularExpressionValidator(
           ErrorMessages.Number("Room temperature text box"),
           regular_expressions.number)
        Me.vmaBalance.ValidationControls.Add(Me.vcoRoomTemperature)
        Me.vcoRoomTemperature.Validators.Add(valRequiredRoomTemperature)
        Me.vcoRoomTemperature.Validators.Add(valNumberRoomTemperature)

        'number of unit coolers 1
        Me.vcoNumUnitCoolers1 = New ValidationControl(
           Me.txt_unit_cooler_quantity_1)
        valRequiredNumUnitCoolers1 = New RequiredValidator(
           ErrorMessages.Required("Number of unit coolers 1"))
        valPositiveIntegerNumUnitCoolers1 = New RegularExpressionValidator(
           ErrorMessages.PositiveInteger("Number of unit coolers 1"),
           regular_expressions.positive_integer)
        Me.vma_balance.ValidationControls.Add(Me.vcoNumUnitCoolers1)
        Me.vcoNumUnitCoolers1.Validators.Add(valRequiredNumUnitCoolers1)
        Me.vcoNumUnitCoolers1.Validators.Add(valPositiveIntegerNumUnitCoolers1)

        'number of unit coolers 2
        Me.vcoNumUnitCoolers2 = New ValidationControl(
           Me.txt_unit_cooler_quantity_2)
        valRequiredNumUnitCoolers2 = New RequiredValidator(
           ErrorMessages.Required("Number of unit coolers 2"))
        valPositiveIntegerNumUnitCoolers2 = New RegularExpressionValidator _
           (ErrorMessages.PositiveInteger("Number of unit coolers 2"),
           regular_expressions.positive_integer)
        Me.vma_balance.ValidationControls.Add(Me.vcoNumUnitCoolers2)
        Me.vcoNumUnitCoolers2.Validators.Add(valRequiredNumUnitCoolers2)
        Me.vcoNumUnitCoolers2.Validators.Add(valPositiveIntegerNumUnitCoolers2)

        'number of unit coolers 3
        Me.vcoNumUnitCoolers3 = New ValidationControl(
           Me.txt_unit_cooler_quantity_3)
        valRequiredNumUnitCoolers3 = New RequiredValidator(
           ErrorMessages.Required("Number of unit coolers 3"))
        valPositiveIntegerNumUnitCOolers3 = New RegularExpressionValidator _
           (ErrorMessages.PositiveInteger("NumberOf unit cooler 3"),
           regular_expressions.positive_integer)
        Me.vma_balance.ValidationControls.Add(Me.vcoNumUnitCoolers3)
        Me.vcoNumUnitCoolers3.Validators.Add(valRequiredNumUnitCoolers3)
        Me.vcoNumUnitCoolers3.Validators.Add(valPositiveIntegerNumUnitCOolers3)
    End Sub


    Private Sub initializeComboboxes()
        Me.cboCondensingUnitSeries.SelectedIndex = 0
        Me.numCompressorsPerUnitComboBox.SelectedIndex = 0
        Me.numCircuitsPerUnitComboBox.SelectedIndex = 0
        Me.cbo_unit_cooler_series.SelectedIndex = 0
        Me.cbo_suction_line_loss.SelectedIndex = 0
        Me.cbo_refrigerant.SelectedIndex = 7
        Me.compressorTypeComboBox.SelectedIndex = 0
    End Sub


    ''' <summary>Sets controls that are dependent upon the division used to login</summary>
    ''' <remarks>TSI's capacity unit is Tons. Century's capacity unit is BTUH.</remarks>
    Private Sub setDivisionSpecificControls()
        'if tsi then capacity units are tons not btuh
        If AppInfo.Division = Division.TSI Then
            Me.digits = 2
            Me.capacityUnits = "Tons"
            Me.capacityRequiredUnitsLabel.Text = "[Tons]"
            Me.lblCapacity.Text = "Est. Capacity [Tons]"
            Me.lblCondenserCapacity.Text = "Condenser Est. Capacity [Tons]"
            Me.cboCondensingUnitSeries.Items.Clear()
            Me.cboCondensingUnitSeries.Text = "20A0"
            Me.cboCondensingUnitSeries.Items.Add("20A0")
            'If user.can(rate_20A4) Then _
            Me.cboCondensingUnitSeries.Items.Add("20A4")
            Me.cboCondensingUnitSeries.Items.Add("RCUL")
            Me.cboCondensingUnitSeries.SelectedIndex = 0
            Me.txt_capacity_required.Text = "0"
            Me.Label5.Text = "[" & Me.capacityUnits & "]"
        ElseIf AppInfo.Division = Division.CRI AndAlso user.is_rep Then

            Me.cboCondensingUnitSeries.Items.Clear()
            Me.cboCondensingUnitSeries.Text = "NSB"
            Me.cboCondensingUnitSeries.Items.Add("NSB")
            Me.cboCondensingUnitSeries.Items.Add("NDB")
            Me.cboCondensingUnitSeries.Items.Add("NSC")
            Me.cboCondensingUnitSeries.Items.Add("NDC")
            Me.cboCondensingUnitSeries.Items.Add("NSF")
            Me.cboCondensingUnitSeries.Items.Add("NDF")
            Me.cboCondensingUnitSeries.Items.Add("DM")
            Me.cboCondensingUnitSeries.Items.Add("BLU-L")
            Me.cboCondensingUnitSeries.Items.Add("BLU-B")
            Me.cboCondensingUnitSeries.SelectedIndex = 0
            '"DM", "NDB", "NSB", "NSC", "NDC", "BLU-L", "BLU-B"

        End If
    End Sub


    Private Sub setAuthorizationSpecificControls()
        If user.is_employee Then
            cbCondTempOverride.Visible = True
            ''condensingUnitDataCollapsableHeader.Visible = True
            panCondensingUnitDataBody.Visible = True
            chk_unit_cooler_override.Visible = True
        Else
            ''condensingUnitDataCollapsableHeader.Visible = False
            panCondensingUnitDataBody.Visible = False
            chk_unit_cooler_override.Visible = False
        End If
    End Sub

    ' TODO: move to compressor intelligence
    ''' <summary>Checks if entered suction temperature is valid
    ''' </summary>
    ''' <returns>Boolean indicating whether or not suction temperature is valid
    ''' </returns>
    ''' <remarks>Checks that entered suction temperature is within the valid 
    ''' temperature range.
    ''' </remarks>
    ''' <history>[CASEYJ]	5/31/2005	Created
    ''' </history>
    Private Function IsSuctionTemperatureInValidRange(
    ByVal suctionTemperature As Single) As Boolean
        Const maxSuctionTemperature As Single = 55
        Const minSuctionTemperature As Single = -40
        Dim _isSuctionTemperatureValid As Boolean

        'validates suction temperature range
        If suctionTemperature > maxSuctionTemperature _
        Or suctionTemperature < minSuctionTemperature Then
            'temperature is out of range
            _isSuctionTemperatureValid = False
        Else
            'temperature is within valid range
            _isSuctionTemperatureValid = True
        End If

        Return _isSuctionTemperatureValid
    End Function


    ''' <summary>Clears text in condensing unit and condensing unit's capacity controls.</summary>
    Private Sub ClearCondensingUnits()
        condensingUnit1DescriptionLabel.Text = ""
        condensingUnit1DescriptionLabel.BackColor = Color.Transparent
        condensingUnit2DescriptionLabel.Text = ""
        condensingUnit2DescriptionLabel.BackColor = Color.Transparent
        condensingUnit3DescriptionLabel.Text = ""
        condensingUnit3DescriptionLabel.BackColor = Color.Transparent
        txt_condensing_unit_1_capacity.Text = ""
        txt_condensing_unit_2_capacity.Text = ""
        txt_condensing_unit_3_capacity.Text = ""
    End Sub


    ''' <summary>
    ''' Shows message box indicating a control necessary to rate system has been changed
    ''' </summary>
    Private Sub showRateSystemMessage()
        ' gets list of controls that have been changed that shouldn't have been
        Dim controlNameList() As String = changesSinceFindUnitCoolers.ToArray()

        ' seperates control names by commas
        Dim message As String
        For i As Integer = 0 To changesSinceFindUnitCoolers.Count - 1
            message &= controlNameList(i) & ", "
        Next
        Ui.MessageBox.Show(
           "The values entered into the following control(s) were modified after 'Find Unit Coolers' was clicked." _
         & NewLine & "     " & message & NewLine _
         & "In order to get accurate results please begin again by clicking " _
         & "'Find Condensing Units' then 'Find Unit Coolers' and then 'Rate System'." _
         & NewLine & NewLine _
         & "Filling out the form in the order presented will prevent this exception.")
    End Sub

    Private Sub openBoxLoad()
        Dim linkedItemId As String = Me.Tag
        Dim linkedItemRevision As Single = Me.CurrentRevision
        Dim da As New Rae.Data.Access.BoxLoadProjects()
        Dim dbId As nullable_value(Of Integer)
        dbId = da.RetrieveDbId(linkedItemId, linkedItemRevision) '  CoolStuff.cl_connection.GetProjectRecordNumber(Me.Tag, Me.CurrentRevision, "UI")
        btnCoolStuffInvoke.Tag = dbId.value_or_default(0)
        If Me.Tag IsNot Nothing And Me.btnCoolStuffInvoke.Tag IsNot Nothing _
        AndAlso Me.btnCoolStuffInvoke.Tag > 0 Then
            Dim c As New CoolStuff.CoolStuffCommon, capacity As Single
            c.CallingForm = Me

            Dim itemId As String = Me.Tag

            Dim b As Rae.Data.Access.OverrideData
            b = da.RetrieveLinkData(itemId, Me.CurrentRevision)
            'c.GetOverridesFromDb()
            capacity = b.LoadTot
            'capacity = c.CoolStuffCapacity
            If b.UserCapacityChecked Then
                capacity = b.UserCapacity
            ElseIf AppInfo.Division = Division.TSI Then
                capacity = Rae.Convert.BtuhToTons(capacity)
            End If
            'If c.CoolStuffUserCapacityChecked Then
            '   capacity = c.CoolStuffUserCapacity
            'ElseIf AppInfo.Division = Division.TSI Then
            '   capacity = Round(capacity / 12000, 2)
            'End If
            overrideControlsWithBoxLoad(capacity, b.RunTime, b.Ambient, b.RmTemp)
            txtcoolstuffBlName.Text = b.BlName
            'txtcoolstuffBlName.Text = c.CoolStuffBlName
            btnCoolStuffInvoke.Visible = False
            btnremoveboxloadLink.Visible = True
        End If
    End Sub

    ''' <summary>
    ''' Handles revision view control's revision changed event.
    ''' If user has unsaved changes, asks user to save before navigating revisions.
    ''' </summary>
    Private Sub RevisionView_RevisionChanged(ByVal sender As RevisionView, ByVal e As ValueChangedEventArgs(Of Single))
        If sender.ActiveProcessForm Is Me Then
            SaveControls(False, False, False, False, True)
        End If
    End Sub


#End Region


#Region " UI"

    Private Function grab_run_time_hours() As Single
        Return ConvertNull.ToSingle(Me.runTimeTextBox.Text.Trim)
    End Function

    Private Function GrabNumCustomUnitCoolers() As Integer
        Return ConvertNull.ToInteger(Me.txt_custom_uc_quantity.Text.Trim)
    End Function


    Private Function GrabNumUnitCoolers(ByVal index As Integer) As Integer
        Dim numUnitCoolers As Integer

        If index = 0 Then
            numUnitCoolers = ConvertNull.ToInteger(Me.txt_unit_cooler_quantity_1.Text.Trim)
        ElseIf index = 1 Then
            numUnitCoolers = ConvertNull.ToInteger(Me.txt_unit_cooler_quantity_2.Text.Trim)
        ElseIf index = 2 Then
            numUnitCoolers = ConvertNull.ToInteger(Me.txt_unit_cooler_quantity_3.Text.Trim)
        End If

        Return numUnitCoolers
    End Function


    ''' <summary>Grabs condenser capacity per degree from user interface control
    ''' </summary>
    ''' <remarks>For standard units the condenser capacity per degree control is set
    ''' by the condensing unit dll which calls the cofan dll
    ''' </remarks>
    Private Function grab_condenser_capacity_per_degree() As Single
        Dim condenserCapacityPerDegree As Single

        ' sets condenser capacity per degree
        If condensingUnit1RadioButton.Checked Then
            condenserCapacityPerDegree = Single.Parse(Me.condensingUnit1CondenserCapacityPerDegreeTextBox.Text)
        ElseIf condensingUnit2RadioButton.Checked Then
            condenserCapacityPerDegree = Single.Parse(Me.condensingUnit2CondenserCapacityTextBox.Text)
        ElseIf condensingUnit3RadioButton.Checked Then
            condenserCapacityPerDegree = Single.Parse(Me.condensingUnit3CondenserCapacityTextBox.Text)
        ElseIf customCondensingUnitRadioButton.Checked Then
            condenserCapacityPerDegree = Single.Parse(CNull.ToDouble(Me.customCondenserCapacityPerDegreeTextBox.Text))
        End If
        If AppInfo.Division = Division.TSI Then
            ' converts Tons to BTUH
            condenserCapacityPerDegree =
               Round(condenserCapacityPerDegree * 12000, 2)
        End If

        Return condenserCapacityPerDegree
    End Function


    Private Function grab_condensing_unit_model() As String
        Dim condensingUnitModel As String

        ' grabs selected condensing unit from control's tag
        If Me.condensingUnit1RadioButton.Checked Then
            condensingUnitModel = CNull.ToString(txt_condensing_unit_1_capacity.Tag)
        ElseIf Me.condensingUnit2RadioButton.Checked Then
            condensingUnitModel = Me.txt_condensing_unit_2_capacity.Tag.ToString
        ElseIf Me.condensingUnit3RadioButton.Checked Then
            condensingUnitModel = Me.txt_condensing_unit_3_capacity.Tag.ToString
        ElseIf Me.customCondensingUnitRadioButton.Checked Then
            condensingUnitModel = Me.customCondensingUnitTextBox.Text
        End If

        Return condensingUnitModel
    End Function

    Private Function GrabCondensingPerDegreeCapacity() As Double
        Dim capacityPerDegree As Double
        If Me.condensingUnit1RadioButton.Checked Then
            capacityPerDegree = Val(Me.condensingUnit1CondenserCapacityPerDegreeTextBox.Text)
        ElseIf Me.condensingUnit2RadioButton.Checked Then
            capacityPerDegree = Val(Me.condensingUnit2CondenserCapacityTextBox.Text)
        ElseIf Me.condensingUnit3RadioButton.Checked Then
            capacityPerDegree = Val(Me.condensingUnit3CondenserCapacityTextBox.Text)
        ElseIf Me.customCondensingUnitRadioButton.Checked Then
            capacityPerDegree = Val(Me.customCondenserCapacityPerDegreeTextBox.Text)
        End If
        Return capacityPerDegree
    End Function

    Private Function grab_suction_temp() As Double
        Return ConvertNull.ToDouble(txt_suction_temp.Text.Trim)
    End Function

    Private Function grab_refrigerant() As String
        Return cbo_refrigerant.SelectedItem.ToString()
    End Function

    Private Function grab_altitude() As Single
        Return ConvertNull.ToSingle(Me.altitudeTextBox.Text)
    End Function


    Private Function grab_suction_line_loss() As Single
        Return CInt(cbo_suction_line_loss.SelectedItem)
    End Function

    Private Function grab_room_temp() As Single
        Dim roomTemperature As Single
        Dim max, min As Single

        If Me.there_is_one_room Then
            roomTemperature = Single.Parse(Me.roomTemperatureTextBox.Text.Trim)
        ElseIf Me.multipleRoomsComboBox.Checked Then
            max = Single.Parse(Me.txt_max_room_temp.Text.Trim)
            min = Single.Parse(Me.txt_min_room_temp.Text.Trim)
            ' gets average if there is multiple rooms
            roomTemperature = (max + min) / 2
        Else
            Ui.MessageBox.Show("Select number of rooms.")
            roomTemperature = 0
        End If

        Return roomTemperature
    End Function


    Private Function grab_ambient() As Single
        Dim ambientTemperature As Single
        Dim max, min As Single

        If Me.there_is_one_room Then
            ambientTemperature = ConvertNull.ToSingle(Me.ambientTemperatureTextBox.Text.Trim)
        ElseIf multipleRoomsComboBox.Checked Then
            max = ConvertNull.ToSingle(Me.txt_max_ambient.Text.Trim)
            min = ConvertNull.ToSingle(Me.txt_min_ambient.Text.Trim)
            ' gets average if there is multiple rooms
            ambientTemperature = (max + min) / 2
        Else
            Ui.MessageBox.Show("Select number of rooms.")
            ambientTemperature = 0
        End If

        Return ambientTemperature
    End Function


    Private Function GrabUnitCooler(ByVal index As Integer) As String
        Dim unitCooler As String

        If index > 2 Or index < 0 Then
            Throw New System.ArgumentException("The 'index' parameter for the unit cooler must be 0 to 2.")
        End If

        Select Case index
            Case 0 : unitCooler = Me.txt_unit_cooler_model_1.Text.Trim
            Case 1 : unitCooler = Me.txt_unit_cooler_model_2.Text.Trim
            Case 2 : unitCooler = Me.txt_unit_cooler_model_3.Text.Trim
        End Select

        Return unitCooler
    End Function


    Private Function there_is_one_room() As Boolean
        there_is_one_room = Me.oneRoomComboBox.Checked
    End Function

#Region " results grid"

    ''Private Sub set_results_grid_size()
    ''    If there_is_one_room() Then
    ''        grd_results.Height = 100 - (17 * 2)
    ''        panBalaGrid.Height = 145 - (17 * 2)
    ''    Else
    ''        grd_results.Height = 100 + 17 * 7 '17 is about the height of a row
    ''        panBalaGrid.Height = 145 + 17 * 7
    ''    End If
    ''End Sub

    ''Private Sub format_results_grid()
    ''    ' hides amp column (value is incorrect)
    ''    Dim nl As String = System.Environment.NewLine

    ''    With Me.grd_results
    ''        ' sets column heading text
    ''        .Columns(0).Caption = "Ambient" & nl & "[°F]"
    ''        .Columns(1).Caption = "Room" & nl & "[°F]"
    ''        .Columns(2).Caption = "Evaporator" & nl & "[°F]"
    ''        .Columns(3).Caption = "Suction" & nl & "[°F]"
    ''        .Columns(4).Caption = "Condenser" & nl & "[°F]"
    ''        .Columns(5).Caption = "Temperature" & nl & "Difference [°F]"
    ''        .Columns(6).Caption = "Est. Capacity" & nl & "[" & Me.capacityUnits & "]"
    ''        ' TODO: Change to either unit or system instead of compressor
    ''        .Columns(7).Caption = "System" & nl & "[KW]"

    ''        'removes amp column
    ''        Dim amp_column_index = grd_results.Columns.Count - 1
    ''        If amp_column_index = 8 Then _
    ''           grd_results.Columns.RemoveAt(amp_column_index)
    ''        '.Columns(8).Caption = "System" & nl & "460 / 230 [A]"

    ''        ' sets column widths
    ''        .Splits(0).DisplayColumns(0).Width = 50
    ''        .Splits(0).DisplayColumns(1).Width = 36
    ''        .Splits(0).DisplayColumns(2).Width = 65
    ''        .Splits(0).DisplayColumns(3).Width = 45
    ''        .Splits(0).DisplayColumns(4).Width = 65
    ''        .Splits(0).DisplayColumns(5).Width = 81
    ''        .Splits(0).DisplayColumns(6).Width = 125
    ''        .Splits(0).DisplayColumns(7).Width = 70
    ''        '.Splits(0).DisplayColumns(8).Width = 70

    ''        ' sets column headers height (so can wrap text)
    ''        .Splits(0).ColumnCaptionHeight = 28
    ''        ' formats consistently w/ other datagrids
    ''        mVisualStyles.FormatC1Datagrid(Me.grd_results)
    ''        .Splits(0).RecordSelectors = False
    ''    End With

    ''    ' set results datagrid size based on whether multiple rooms are selected
    ''    Me.set_results_grid_size()
    ''End Sub

#End Region

    ''Friend Sub format_unit_coolers_grid()
    ''    With Me.unit_coolers_grid
    ''        ' sets column header text
    ''        .Columns(0).Caption = "Model"
    ''        .Columns(1).Caption = "Quantity Required per Cond Unit"
    ''        .Columns(2).Caption = "Est. Capacity [" & capacityUnits & "]"
    ''        .Columns(3).Caption = "Face Velocity"

    ''        ' sets column widths
    ''        .Splits(0).DisplayColumns(0).Width = 120
    ''        .Splits(0).DisplayColumns(1).Width = 130
    ''        .Splits(0).DisplayColumns(2).Width = 120
    ''        .Splits(0).DisplayColumns(3).Width = 120

    ''        ' sets column header height to allow user to see wrapped text
    ''        .Splits(0).ColumnCaptionHeight = 22
    ''        'Enum HighlightRow - clicking on a cell highlights its whole row
    ''        .MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
    ''        .Visible = True

    ''        ' formats datagrid properties that are common to all datagrids
    ''        mVisualStyles.FormatC1Datagrid(Me.unit_coolers_grid)
    ''    End With
    ''End Sub

    ''' <summary>Clears unit cooler 1's row of controls</summary>
    Private Sub ClearUnitCooler1()
        txt_unit_cooler_model_1.Text = ""
        txt_unit_cooler_quantity_1.Text = "0"
        txt_unit_cooler_capacity_1.Text = "0"
        txt_evaporator_capacity_per_degree_1.Text = "0"
        txt_unit_cooler_model_1.BackColor = SystemColors.Control
        txt_unit_cooler_capacity_1.BackColor = SystemColors.Control
        txt_unit_cooler_quantity_1.BackColor = Color.White
        txt_evaporator_capacity_per_degree_1.BackColor = SystemColors.Control
        rbo_0_static_1.Visible = False
        rbo_025_static_1.Visible = False
        rbo_050_static_1.Visible = False
        clear_balance_results()
    End Sub

    ''' <summary>Clears unit cooler 2's row of controls</summary>
    Private Sub ClearUnitCooler2()
        txt_unit_cooler_model_2.Text = ""
        txt_unit_cooler_quantity_2.Text = "0"
        txt_unit_cooler_capacity_2.Text = "0"
        txt_evaporator_capacity_per_degree_2.Text = "0"
        txt_unit_cooler_model_2.BackColor = SystemColors.Control
        txt_unit_cooler_capacity_2.BackColor = SystemColors.Control
        txt_unit_cooler_quantity_2.BackColor = Color.White
        txt_evaporator_capacity_per_degree_2.BackColor = SystemColors.Control
        rbo_0_static_2.Visible = False
        rbo_025_static_2.Visible = False
        rbo_050_static_2.Visible = False
        clear_balance_results()
    End Sub

    ''' <summary>Clears unit cooler 3's row of controls</summary>
    Private Sub ClearUnitCooler3()
        txt_unit_cooler_model_3.Text = ""
        txt_unit_cooler_quantity_3.Text = "0"
        txt_unit_cooler_capacity_3.Text = "0"
        txt_evaporator_capacity_per_degree_3.Text = "0"
        txt_unit_cooler_model_3.BackColor = SystemColors.Control
        txt_unit_cooler_capacity_3.BackColor = SystemColors.Control
        txt_unit_cooler_quantity_3.BackColor = Color.White
        txt_evaporator_capacity_per_degree_3.BackColor = SystemColors.Control
        rbo_0_static_3.Visible = False
        rbo_025_static_3.Visible = False
        rbo_050_static_3.Visible = False
        clear_balance_results()
    End Sub


    Private Sub setVisibilityForControlsDependentOnNumberOfRooms()
        Dim multipleRooms = Not Me.there_is_one_room

        ' controls for multiple rooms
        Me.minTemperatureLabel.Visible = multipleRooms
        Me.maxTemperatureLabel.Visible = multipleRooms
        Me.incrementTemperatureLabel.Visible = multipleRooms
        Me.txt_min_ambient.Visible = multipleRooms
        Me.txt_max_ambient.Visible = multipleRooms
        Me.incrementAmbientTemperatureTextBox.Visible = multipleRooms
        Me.txt_min_room_temp.Visible = multipleRooms
        Me.txt_max_room_temp.Visible = multipleRooms
        Me.incrementRoomTemperatureTextBox.Visible = multipleRooms
        ' controls for single room
        Me.ambientTemperatureTextBox.Visible = Not (multipleRooms)
        Me.roomTemperatureTextBox.Visible = Not (multipleRooms)
    End Sub


#End Region




    ''' <summary>
    ''' Opens print preview of balance form.
    ''' </summary>
    ''Private Sub PrintForm()
    ''    Dim doc As New C1.C1PrintDocument.C1PrintDocument
    ''    Dim printStyle As C1.C1PrintDocument.C1DocStyle
    ''    Dim whiteImage As Image
    ''    Dim formPreview As C1PrintPreviewForm

    ''    ' used in rendering spacer image
    ''    printStyle = New C1.C1PrintDocument.C1DocStyle(doc)
    ''    ' sets font (used in header and footer)
    ''    printStyle.Font = New Font("Arial", 10, FontStyle.Regular)

    ''    ' the page settings from frmC1PrintPreview.vb are not applied
    ''    ' page settings must be set in code in order to be applied
    ''    doc.PageSettings.Margins.Top = 50 'in hundredths of an inch
    ''    doc.PageSettings.Margins.Bottom = 50

    ''    doc.DefaultUnit = C1.C1PrintDocument.UnitTypeEnum.Mm
    ''    ' header
    ''    With doc.PageHeader
    ''        .Height = 8
    ''        .RenderText.Style = printStyle
    ''        .RenderText.Style.TextAlignHorz = C1.C1PrintDocument.AlignHorzEnum.Center
    ''        .RenderText.Style.TextAlignVert = C1.C1PrintDocument.AlignVertEnum.Top
    ''        .RenderText.Text = Me.Text
    ''    End With
    ''    ' footer
    ''    With doc.PageFooter
    ''        .Height = 8
    ''        .RenderText.Style = printStyle
    ''        .RenderText.Style.TextAlignHorz = C1.C1PrintDocument.AlignHorzEnum.Right
    ''        .RenderText.Style.TextAlignVert = C1.C1PrintDocument.AlignVertEnum.Bottom
    ''        .RenderText.Text = "Page [@@PageNo@@] of [@@PageCount@@]"
    ''    End With

    ''    ' starts rendering
    ''    doc.StartDoc()

    ''    ' Page 1
    ''    doc.RenderBlockControlImage(Me.panCondensingUnitSpecBody)
    ''    ' in effect, image is a page return
    ''    whiteImage = Image.FromFile(AppInfo.AppFolderPath & "Images\whitebox.gif")
    ''    doc.RenderBlockImage(whiteImage, 3, doc.AvailableBlockFlowHeight, printStyle)

    ''    ' Page 2
    ''    ' shows extra condensing unit info to employees
    ''    If user.is_employee Then
    ''        ''doc.RenderBlockControlImage(Me.condensingUnitDataCollapsableHeader)
    ''        doc.RenderBlockControlImage(Me.panCondensingUnitDataBody)
    ''        ' page return
    ''        doc.RenderBlockImage(whiteImage, 3, doc.AvailableBlockFlowHeight, printStyle)
    ''    End If

    ''    ' Page 3
    ''    ' renders the rest of the controls
    ''    doc.RenderBlockControlImage(panUnitCoolerSpec)
    ''    doc.RenderBlockControlImage(panUnitCoolGrid)
    ''    doc.RenderBlockControlImage(panRate)
    ''    doc.RenderBlockControlImage(panBalaGrid)

    ''    ' stops rendering
    ''    doc.EndDoc()

    ''    formPreview = New C1PrintPreviewForm
    ''    ' sets the print preview document to the document just created
    ''    formPreview.C1PrintPreview1.Document = doc
    ''    ' shows print preview
    ''    formPreview.ShowDialog() ' can't have mdiparent otherwise error occurs
    ''    formPreview.Close()
    ''End Sub

    Private Sub show_report()
        Dim report = New Rae.reporting.beta.report(reports.file_paths.cu_uc_balance_template_file_path)
        Dim doeFlag As Boolean = False

        Dim text = New Dictionary(Of String, String)
        text.Add("user", user.username)
        text.Add("application_version", My.Application.Info.Version.ToString)
        text.Add("date_created", DateTime.Now.ToString("M/d/yyyy"))
        text.Add("year", DateTime.Now.Year)


        Dim condensing_unit_quantity = CNull.ToInteger(txt_condensing_unit_quantity.Text)

        text.Add("capacity_required", txt_capacity_required.Text.format_number("#,#").BTUH)

        text.Add("condensing_unit_model", grab_condensing_unit_model)
        text.Add("condensing_unit_quantity", condensing_unit_quantity)
        text.Add("condensing_unit_capacity", grab_condensing_unit_capacity.ToString("#,#"))

        If txt_unit_cooler_DOE_1.Text.ToUpper = "TRUE" Then
            text.Add("unit_cooler_doe_1", "*")
            doeFlag = True
        Else
            text.Add("unit_cooler_doe_1", "")
        End If

        If txt_unit_cooler_DOE_2.Text.ToUpper = "TRUE" Then
            text.Add("unit_cooler_doe_2", "*")
            doeFlag = True
        Else
            text.Add("unit_cooler_doe_2", "")
        End If

        If txt_unit_cooler_DOE_3.Text.ToUpper = "TRUE" Then
            text.Add("unit_cooler_doe_3", "*")
            doeFlag = True
        Else
            text.Add("unit_cooler_doe_3", "")
        End If


        If txt_condensing_unit_DOE_1.Text.ToUpper = "TRUE" Then
            text.Add("condensing_unit_doe_1", "*")
            doeFlag = True
        Else
            text.Add("condensing_unit_doe_1", "")
        End If



        text.Add("unit_cooler_model_1", txt_unit_cooler_model_1.Text)
        text.Add("unit_cooler_quantity_1", CNull.ToInteger(txt_unit_cooler_quantity_1.Text) * condensing_unit_quantity)
        text.Add("unit_cooler_capacity_1", txt_unit_cooler_capacity_1.Text.format_number("#,#"))

        text.Add("unit_cooler_model_2", txt_unit_cooler_model_2.Text)
        text.Add("unit_cooler_quantity_2", CNull.ToInteger(txt_unit_cooler_quantity_2.Text) * condensing_unit_quantity)
        text.Add("unit_cooler_capacity_2", txt_unit_cooler_capacity_2.Text.format_number("#,#"))

        text.Add("unit_cooler_model_3", txt_unit_cooler_model_3.Text)
        text.Add("unit_cooler_quantity_3", CNull.ToInteger(txt_unit_cooler_quantity_3.Text) * condensing_unit_quantity)
        text.Add("unit_cooler_capacity_3", txt_unit_cooler_capacity_3.Text.format_number("#,#"))

        If chk_custom_unit_cooler.Checked Then
            text.Add("custom_unit_cooler_capacity", txt_custom_uc_capacity.Text.format_number("#,#"))
            text.Add("custom_unit_cooler_model", txt_custom_uc_model.Text)
            text.Add("custom_unit_cooler_quantity", txt_custom_uc_quantity.Text)
        Else
            text.Add("custom_unit_cooler_capacity", "")
            text.Add("custom_unit_cooler_model", "")
            text.Add("custom_unit_cooler_quantity", "")
        End If

        text.Add("balance", txt_balance.Text.format_number("#,#"))

        text.Add("compressor_type", compressorTypeComboBox.SelectedItem)
        text.Add("compressors_per_unit", numCompressorsPerUnitComboBox.SelectedItem)
        text.Add("circuits_per_unit", numCircuitsPerUnitComboBox.SelectedItem)
        text.Add("refrigerant", grab_refrigerant)
        text.Add("suction_line_loss", cbo_suction_line_loss.SelectedItem)
        text.Add("adjust_capacity", If(adjustCapacityForRunTimeYesRadioButton.Checked, "Yes", "No"))
        text.Add("run_time", grab_run_time_hours)
        text.Add("altitude", altitudeTextBox.Text.append(" ft"))

        If doeFlag Then
            '  text.Add("DOENotice", "(d) DOE Model")
        Else
            text.Add("DOENotice", " ")
        End If


        Dim table = create_table(results_dataset.balance_results)

        Dim command = New get_logo_file_path_command(user, AppInfo.Division.ToString)
        Dim logo_file_path = command.execute

        report.set_text(text)
        report.set_table("table", table)
        report.set_image("logo", logo_file_path)
        report.mark_as_final()
        report.show()
    End Sub

    Private Function create_table(ByVal data_table As balance_dataset.balance_resultsDataTable) As DataTable
        Dim table = New DataTable

        table.Columns.Add("Ambient")
        table.Columns.Add("Room")
        table.Columns.Add("Evaporating")
        table.Columns.Add("Suction")
        table.Columns.Add("Condensing")
        table.Columns.Add("TD")
        table.Columns.Add("Est. Capacity [BTUH]")
        table.Columns.Add("System [KW]")

        For Each row As balance_dataset.balance_resultsRow In data_table.Rows
            table.Rows.Add(row.ambient_temp.F, row.room_temp.F, row.evaporating_temp.F,
                           row.suction_temp.F, row.condensing_temp.F, row.td.F,
                           row.Capacity.format_number("#,#"), row.system_power)
        Next
        Return table
    End Function


    ' ''' <summary>Passes values from form to report and views report.</summary>
    'Private Sub show_report
    '   Dim report As New ReportDocument()
    '   report.Load(Reports.file_paths.cu_uc_balance_report_file_path)

    '   Dim fields As ParameterFieldDefinitions = report.DataDefinition.ParameterFields
    '   Dim field As New Rae.Reporting.CrystalReports.SingleParameterFieldDefinition(fields)

    '   report.SetDataSource(Me.results_dataset)

    '   ' determines report parameter values
    '   '
    '   ' determines selected condensing unit and its capacity
    '   Dim condensingUnit As String, condensingUnitCapacity As String
    '   condensingUnit = Me.grab_condensing_unit_model()
    '   condensingUnitCapacity = Me.grab_condensing_unit_capacity().ToString

    '   Dim runTime As String = ""
    '   If Me.adjustCapacityForRunTimeYesRadioButton.Checked Then
    '      runTime = "Yes"
    '   ElseIf adjustCapacityForRunTimeNoRadioButton.Checked Then
    '      runTime = "No"
    '   End If

    '   Dim numCondensingUnits As Integer = CNull.ToInteger(Me.txt_condensing_unit_quantity.Text)

    '   dim division = AppInfo.Division.ToString()
    '   if user.can(choose_report_logo) then
    '      division = new which_division().ask({"CRI", "TSI", "RSI", "RAE"})
    '   end if

    '   ' passes values to report
    '   '

    '   if chk_custom_unit_cooler.checked then
    '      field.pass(txt_custom_uc_capacity.text, "custom_uc_capacity")
    '      field.pass(txt_custom_uc_model.text, "custom_uc_model")
    '      field.pass(txt_custom_uc_quantity.text, "custom_uc_quantity")
    '   else
    '      field.pass("", "custom_uc_capacity")
    '      field.pass("", "custom_uc_model")
    '      field.pass("", "custom_uc_quantity")
    '   end if

    '   field.Pass(Me.capacityRequiredTextBox.Text, "pfdTotalCapacityRequired")
    '   ' passes application version
    '   field.Pass(My.Application.Info.Version.ToString, "pfdVersion")
    '   field.Pass(division, "logo")
    '   ' passes test - indicates if application is being test, shows/hides test watermark
    '   field.Pass(Constants.TESTING.ToString, "pfdTest")
    '   ' passes capacity units (BTUH or Tons) depending on company
    '   field.Pass(capacityUnits, "pfdUnits")
    '   ' passes condensing unit model
    '   field.Pass(condensingUnit, "pfdCondensingUnit")
    '   ' passes number of condensing units required
    '   field.Pass(Me.txt_condensing_unit_quantity.Text, "pfdCondensingUnitQuantity")
    '   ' passes condensing unit capacity
    '   field.Pass(condensingUnitCapacity, "pfdCondensingUnitCapacity")
    '   ' passes unit cooler 1 model
    '   field.Pass(Me.txt_unit_cooler_model_1.Text, "pfdUnitCooler1")
    '   ' passes unit cooler 1 quantity
    '   field.Pass(CNull.ToInteger(Me.txt_unit_cooler_quantity_1.Text) * numCondensingUnits, "pfdUnitCooler1Quantity")
    '   ' passes unit cooler 1 capacity
    '   field.Pass(Me.txt_unit_cooler_capacity_1.Text, "pfdUnitCooler1Capacity")
    '   ' passes unit cooler 2 model
    '   field.Pass(Me.txt_unit_cooler_model_2.Text, "pfdUnitCooler2")
    '   ' passes unit cooler 2 quantity
    '   field.Pass(CNull.ToInteger(Me.txt_unit_cooler_quantity_2.Text) * numCondensingUnits, "pfdUnitCooler2Quantity")
    '   ' passes unit cooler 2 capacity
    '   field.Pass(Me.txt_unit_cooler_capacity_2.Text, "pfdUnitCooler2Capacity")
    '   ' passes unit cooler 3 model
    '   field.Pass(Me.txt_unit_cooler_model_3.Text, "pfdUnitCooler3")
    '   ' passes unit cooler 3 quantity
    '   field.Pass(CNull.ToInteger(Me.txt_unit_cooler_quantity_3.Text) * numCondensingUnits, "pfdUnitCooler3Quantity")
    '   ' passes unit cooler 3 capacity
    '   field.Pass(Me.txt_unit_cooler_capacity_3.Text, "pfdUnitCooler3Capacity")
    '   ' passes balance
    '   field.Pass(Me.txt_balance.Text, "pfdBTUHBalance")

    '   field.Pass(grab_refrigerant(), "pfdRefrigerant")
    '   field.Pass(Me.cbo_suction_line_loss.SelectedItem, "pfdLineLoss")
    '   ' passes yes/no to adjust for run time
    '   field.Pass(runTime, "pfdAdjustCapacityForRunTime")
    '   ' passes run time hours
    '   field.Pass(Me.GrabRunTimeHours().ToString, "pfdRunTime")
    '   ' passes compressor type
    '   field.Pass(Me.compressorTypeComboBox.SelectedItem, "pfdCompressorType")
    '   ' passes number of compressors per condensing unit
    '   field.Pass(Me.numCompressorsPerUnitComboBox.SelectedItem, "pfdCompressorPerUnit")
    '   ' passes number of circuits per unit
    '   field.Pass(Me.numCircuitsPerUnitComboBox.SelectedItem, "pfdCircuitsPerUnit")
    '   ' passes altitude
    '   field.Pass(Me.altitudeTextBox.Text, "pfdAltitude")
    '   ' passes creator of report
    '   field.Pass(user.username, "pfdCreator")



    '   ' views report
    '   '
    '   Dim balanceReportViewerForm As New Rae.Reporting.CrystalReports.ReportViewerForm()
    '   balanceReportViewerForm.ReportViewer.ReportSource = report
    '   balanceReportViewerForm.ReportViewer.Zoom(1)  'zoom percentage
    '   balanceReportViewerForm.Show()
    'End Sub


    ''' <summary>Balances system and sets grid to results.</summary>
    Private Sub balance_system()
        If changesSinceFindUnitCoolers.Count = 0 Then
            results_dataset.balance_results.Clear()

            balanceSystem()
            grdCoolerView.DataSource = results_dataset.balance_results
            grdCoolerView.Columns(0).HeaderText = "Ambient [°F]"
            grdCoolerView.Columns(1).HeaderText = "Room [°F]"
            grdCoolerView.Columns(2).HeaderText = "Evaporator [°F]"
            grdCoolerView.Columns(3).HeaderText = "Suction [°F]"
            grdCoolerView.Columns(4).HeaderText = "Condenser [°F]"
            grdCoolerView.Columns(5).HeaderText = "Temperature Difference [°F]"
            grdCoolerView.Columns(6).HeaderText = "Est. Capacity [BTUH]"
            grdCoolerView.Columns(7).HeaderText = "System [KW]"
            grdCoolerView.Columns(8).Visible = False
            grdCoolerView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray
            grdCoolerView.EnableHeadersVisualStyles = False
            grdCoolerView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue

            ''grd_results.DataSource = results_dataset.balance_results

            ''format_results_grid()
        Else
            showRateSystemMessage()
            ''grd_results.DataSource = Nothing
        End If
    End Sub


    Private Sub initializeSaveToolStripPanel()
        Me.SaveToolStripPanel1.SetUp(CType(Me.ParentForm, MainForm).mainToolStrip,
           AddressOf saveMenuItem_Click, AddressOf SaveAsRevisionMenuItem_Click)
    End Sub


    Private Sub cmdGetCustomCUCapacity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetCustomCUCapacity.Click
        Dim tmpfrm As New condensing_unit_rating_screen()
        tmpfrm.IsBalance = True
        tmpfrm.cboCondensingUnitSeries.Text = Me.cboCondensingUnitSeries.Text
        tmpfrm.txtCondensingUnitsRequired.Text = Me.txt_condensing_unit_quantity.Text
        tmpfrm.txtCapacity.Text = Me.txt_capacity_required.Text
        tmpfrm.radRunTimeAdjustYes.Checked = Me.adjustCapacityForRunTimeYesRadioButton.Checked
        tmpfrm.radRunTimeAdjustNo.Checked = Me.adjustCapacityForRunTimeNoRadioButton.Checked
        tmpfrm.txtRunTime.Text = Me.runTimeTextBox.Text
        tmpfrm.txtSelectionTabAmbient.Text = Me.ambientTemperatureTextBox.Text
        If multipleRoomsComboBox.Checked Then
            If Val(Me.txt_min_ambient.Text) > 0 AndAlso Val(Me.txt_max_ambient.Text) > 0 Then
                tmpfrm.txtSelectionTabAmbient.Text = (Val(Me.txt_min_ambient.Text) + Val(Me.txt_max_ambient.Text)) / 2
            End If
        End If
        tmpfrm.txtSelectionTabSuction.Text = Me.txt_suction_temp.Text
        tmpfrm.cboSelectionTabRefrigerant.Text = Me.cbo_refrigerant.Text
        tmpfrm.cboCompressor.Text = Me.compressorTypeComboBox.Text
        tmpfrm.cboCompressorPerUnit.Text = Me.numCompressorsPerUnitComboBox.Text
        tmpfrm.cboCircuitsPerUnit.Text = Me.numCircuitsPerUnitComboBox.Text
        tmpfrm.txtSelectionTabAltitude.Text = Me.altitudeTextBox.Text

        'show condensing unit form
        tmpfrm.ShowDialog(Me)

        Me.CondensingUnitRating = tmpfrm.CurrentStateProcess
        tmpfrm.ReturnToBalance = True
        tmpfrm.Close()
        If Not IsNothing(Me.CondensingUnitRating) Then
            SetRatingControls(True)
        End If
        tmpfrm = Nothing
    End Sub

    Private Sub SetRatingControls(ByVal IsCustomCondensingUnit As Boolean)

        'If IsCustomCondensingUnit Then

        '   Dim hasRating As Boolean = Me.CondensingUnitRating IsNot Nothing
        '   Dim doesNotHaveRating As Boolean = Not hasRating
        '   If hasRating Then
        '      customCondensingUnitTextBox.Text = Me.CondensingUnitRating.Model
        '      customCondenserCapacityPerDegreeTextBox.Text = Round(Me.CondensingUnitRating.RateMe(CondensingUnitProcessItem.CondensingUnitRatingReturnType.condPerDegreeBTUH), 0)
        '      customCondenserEvapCapacityTextBox.Text = Round(Me.CondensingUnitRating.RateMe(CondensingUnitProcessItem.CondensingUnitRatingReturnType.evapCapacity), 0)
        '   Else
        '      customCondensingUnitTextBox.Text = ""
        '      customCondenserCapacityPerDegreeTextBox.Text = ""
        '      customCondenserEvapCapacityTextBox.Text = ""
        '   End If

        '   cboCondensingUnitSeries.Enabled = doesNotHaveRating
        '   adjustCapacityForRunTimeYesRadioButton.Enabled = doesNotHaveRating
        '   adjustCapacityForRunTimeNoRadioButton.Enabled = doesNotHaveRating
        '   runTimeTextBox.Enabled = doesNotHaveRating
        '   compressorTypeComboBox.Enabled = doesNotHaveRating
        '   cbo_refrigerant.Enabled = doesNotHaveRating
        '   numCompressorsPerUnitComboBox.Enabled = doesNotHaveRating
        '   numCircuitsPerUnitComboBox.Enabled = doesNotHaveRating
        '   capacityRequiredTextBox.Enabled = doesNotHaveRating
        '   altitudeTextBox.Enabled = doesNotHaveRating
        '   txt_condensing_unit_quantity.Enabled = doesNotHaveRating
        '   txt_suction_temp.Enabled = doesNotHaveRating

        '   If hasRating Then
        '      cboCondensingUnitSeries.Text = CondensingUnitRating.Series
        '      adjustCapacityForRunTimeYesRadioButton.Checked = CondensingUnitRating.RuntimeAdjust
        '      runTimeTextBox.Text = Me.CondensingUnitRating.Runtime
        '      compressorTypeComboBox.Text = Me.CondensingUnitRating.Compressor
        '      cbo_refrigerant.Text = Me.CondensingUnitRating.Refrigerant
        '      numCompressorsPerUnitComboBox.Text = Me.CondensingUnitRating.CompressorPerUnit
        '      numCircuitsPerUnitComboBox.Text = Me.CondensingUnitRating.CircuitsPerUnit
        '      capacityRequiredTextBox.Text = Me.CondensingUnitRating.Capacity
        '      altitudeTextBox.Text = Me.CondensingUnitRating.Altitude
        '      txt_condensing_unit_quantity.Enabled = Me.CondensingUnitRating.NoCondensingUnits
        '      txt_suction_temp.Text = Me.CondensingUnitRating.SuctionTemperature
        '      ambientTemperatureTextBox.Text = Me.CondensingUnitRating.AmbientTemperature
        '      txt_min_ambient.Text = Me.CondensingUnitRating.AmbientTemperature - Val(Me.incrementAmbientTemperatureTextBox.Text)
        '      txt_max_ambient.Text = Me.CondensingUnitRating.AmbientTemperature + Val(Me.incrementAmbientTemperatureTextBox.Text)
        '   End If
        '   'oneRoomComboBox.Enabled = False
        '   'multipleRoomsComboBox.Enabled = False
        '   ambientTemperatureTextBox.Enabled = doesNotHaveRating
        '   txt_min_ambient.Enabled = doesNotHaveRating
        '   txt_max_ambient.Enabled = doesNotHaveRating
        '   incrementAmbientTemperatureTextBox.Enabled = doesNotHaveRating
        '   'roomTemperatureTextBox.Enabled = False
        '   'minRoomTemperatureTextBox.Enabled = False
        '   'maxRoomTemperatureTextBox.Enabled = False
        '   'incrementRoomTemperatureTextBox.Enabled = False

        'Else

        customCondensingUnitTextBox.Text = ""
        customCondenserCapacityPerDegreeTextBox.Text = ""

        cboCondensingUnitSeries.Enabled = True
        adjustCapacityForRunTimeYesRadioButton.Enabled = True
        adjustCapacityForRunTimeNoRadioButton.Enabled = True
        compressorTypeComboBox.Enabled = True
        cbo_refrigerant.Enabled = True
        numCompressorsPerUnitComboBox.Enabled = True
        numCircuitsPerUnitComboBox.Enabled = True
        altitudeTextBox.Enabled = True
        txt_condensing_unit_quantity.Enabled = True
        txt_suction_temp.Enabled = True
        oneRoomComboBox.Enabled = True
        multipleRoomsComboBox.Enabled = True
        txt_min_ambient.Enabled = True
        txt_max_ambient.Enabled = True
        incrementAmbientTemperatureTextBox.Enabled = True
        txt_min_room_temp.Enabled = True
        txt_max_room_temp.Enabled = True
        incrementRoomTemperatureTextBox.Enabled = True

        enableControlsLinkedToBoxLoad(Not isLinkedToBoxLoad())
        'ambientTemperatureTextBox.Enabled = True
        'capacityRequiredTextBox.Enabled = True
        'roomTemperatureTextBox.Enabled = True
        'runTimeTextBox.Enabled = True
        'End If

    End Sub

    Private Function grab_required_condensing_unit_capacity() As Double
        Return ConvertNull.ToDouble(txt_capacity_required.Text.Trim)
    End Function

#Region " Box Load"

    Private Function overrideControlsWithBoxLoad(
    ByVal capacity As Integer, ByVal runTime As String, ByVal ambient As String, ByVal room As String) As Boolean
        txt_capacity_required.Text = capacity
        runTimeTextBox.Text = runTime
        ambientTemperatureTextBox.Text = ambient
        roomTemperatureTextBox.Text = room

        enableControlsLinkedToBoxLoad(False)
    End Function

    Private Sub enableControlsLinkedToBoxLoad(ByVal enable As Boolean)
        ambientTemperatureTextBox.Enabled = enable
        txt_capacity_required.Enabled = enable
        roomTemperatureTextBox.Enabled = enable
        runTimeTextBox.Enabled = enable
    End Sub

    Private Function isLinkedToBoxLoad() As Boolean
        Dim dbId As Integer = CNull.ToInteger(btnCoolStuffInvoke.Tag)
        Return (dbId > 0)
    End Function


    Private Sub removeBoxLoadLinkButton_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles btnremoveboxloadLink.Click
        ' updates data source
        Dim boxLoadId As Integer = btnCoolStuffInvoke.Tag
        Dim da As New Rae.Data.Access.BoxLoadProjects()
        Dim boxLoadItemId As String = da.Retrieve(boxLoadId).ItemId
        da.DeleteLink(boxLoadId)

        ' updates controls
        btnCoolStuffInvoke.Tag = 0
        enableControlsLinkedToBoxLoad(True)
        txtcoolstuffBlName.Text = ""
        btnCoolStuffInvoke.Visible = True
        btnremoveboxloadLink.Visible = False
        AppInfo.Main.BoxLoadListView1.Unlink(boxLoadItemId)
    End Sub

    Private Function askUserToSaveBeforeLinkingToBoxLoad() As Boolean
        Dim prompt As IAskUserToSave = New AskUserToSave(
           "Please save before linking to a box load?",
           New String() {},
           New StringDictionary() _
              .Add("Save", "Save and view available box loads") _
              .Add("Cancel", "Do not save and do not link to box load."))

        Dim canceled As Boolean
        Dim response As SaveResponse = prompt.Ask()
        Select Case response.SelectedCommand
            Case "Save"
                Me.SaveControls()
            Case Else
                canceled = True
        End Select

        Return canceled
    End Function

    Private Sub addBoxLoadLinkButton_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles btnCoolStuffInvoke.Click
        ' makes sure balance has been saved (has an item ID)
        Dim balanceIsSaved As Boolean = (Me.LastSavedProcess IsNot Nothing)
        If Not balanceIsSaved Then
            If askUserToSaveBeforeLinkingToBoxLoad() Then _
               Exit Sub
        End If

        ' ask user to select box load to link to
        Dim fromProject As String = OpenedProject.ProjectId.ToString
        Dim prompt As ISelectBoxLoad = New BoxLoadLinksForm()
        Dim response As ISelectBoxLoadResponse
        response = prompt.AskUserToSelectBoxLoad(fromProject)
        Dim dbId As Integer
        If response.Result = SelectBoxLoadResult.Selected Then
            dbId = response.SelectedBoxLoadDbId
        Else
            Exit Sub
        End If

        ' loads selected box load
        Dim b As New BoxLoad()
        b.Load(dbId)

        ' set controls
        overrideControlsWithBoxLoad(b.LoadTotal, b.RunVar, b.Ambient, b.RoomTemperature)
        txtCoolStuffid.Text = dbId
        txtcoolstuffBlName.Text = b.name
        Me.btnCoolStuffInvoke.Tag = dbId
        btnremoveboxloadLink.Visible = True
        btnCoolStuffInvoke.Visible = False
        AppInfo.Main.BoxLoadListView1.Link(b.id.ToString)

        ' updates link data source
        Dim boxLoadId As Integer = btnCoolStuffInvoke.Tag
        Dim linkedItemId As String = Me.Tag
        Dim linkedItemRevision As Integer = Me.CurrentRevision
        Dim da As New Rae.Data.Access.BoxLoadProjects()
        da.UpdateLink(boxLoadId, linkedItemId, linkedItemRevision)
    End Sub

#End Region

    Private Sub rbo_static_1_checkedChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles rbo_0_static_1.CheckedChanged, rbo_025_static_1.CheckedChanged, rbo_050_static_1.CheckedChanged
        If is_loading Then Exit Sub
        If sender.checked Then
            Dim unit_cooler = New unit_coolers.repository().get_unit_cooler(txt_unit_cooler_model_1.Text)
            Dim suction_temp = grab_suction_temp()
            Dim static_pressure As Double = sender.tag

            If unit_cooler.at.ContainsKey(static_pressure) Then
                txt_unit_cooler_capacity_1.Text = unit_cooler.at(static_pressure).capacity_at(suction_temp, unit_cooler.model).ToString(whole_number_format)
            End If
        End If
    End Sub

    Private Sub rbo_static_2_checkedChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles rbo_0_static_2.CheckedChanged, rbo_025_static_2.CheckedChanged, rbo_050_static_2.CheckedChanged
        If is_loading Then Exit Sub
        If sender.checked Then
            Dim unit_cooler = New unit_coolers.repository().get_unit_cooler(txt_unit_cooler_model_2.Text)
            Dim suction_temp = grab_suction_temp()
            Dim static_pressure As Double = sender.tag

            If unit_cooler.at.ContainsKey(static_pressure) Then
                txt_unit_cooler_capacity_2.Text = unit_cooler.at(static_pressure).capacity_at(suction_temp, unit_cooler.model).ToString(whole_number_format)
            End If
        End If
    End Sub

    Private Sub rbo_static_3_checkedChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles rbo_0_static_3.CheckedChanged, rbo_025_static_3.CheckedChanged, rbo_050_static_3.CheckedChanged
        If is_loading Then Exit Sub
        If sender.checked Then
            Dim unit_cooler = New unit_coolers.repository().get_unit_cooler(txt_unit_cooler_model_3.Text)
            Dim suction_temp = grab_suction_temp()
            Dim static_pressure As Double = sender.tag

            If unit_cooler.at.ContainsKey(static_pressure) Then
                txt_unit_cooler_capacity_3.Text = unit_cooler.at(static_pressure).capacity_at(suction_temp, unit_cooler.model).ToString(whole_number_format)
            End If
        End If
    End Sub

    Private Function unit_cooler_is_selected() As Boolean
        Return grab_unit_coolers().Count > 0
    End Function

    Private Function condensing_unit_is_selected() As Boolean
        Return Not grab_condensing_unit.model Is Nothing
    End Function

    Private Sub btn_convert_to_pricing_click() Handles btn_convert_to_pricing.Click
        Dim prerequisites = New condensing_unit_and_unit_cooler_are_selected(unit_cooler_is_selected, condensing_unit_is_selected)
        If prerequisites.validate.is_invalid Then
            warn(prerequisites.messages.toString)
            Exit Sub
        End If

        Try
            SaveControls(GenerateEquipment:=True)
        Catch ex As Exception
            alert("An error occurred while attempting to generate pricing. " & ex.Message)
        End Try
    End Sub




    Private Sub cbCondTempOverride_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCondTempOverride.CheckStateChanged
        changesSinceFindCondensingUnit.Add("Cond Temp Override Checkbox")

    End Sub


End Class
' 6993 on 10/6/2006

Class td_is_in_range_for_one_room : Inherits rae.validation.validator_base
    Sub New(ByVal td As Double)
        Me.td = td
    End Sub

    Protected min As Double = 6
    Protected max As Double = 25

    Overrides Function validate() As rae.validation.i_validate
        messages.clear()

        If td < min Or td > max Then
            valid = False
            messages.add(New rae.validation.message(rae.validation.validation_status.failure, display_message))
        Else
            valid = True
        End If

        Return Me
    End Function

    Protected Function display_message() As String
        Return "TD is out of range (min:" & min & ", max:" & max & ")."
    End Function

    Private td As Double
End Class

Class which_defrost_type
    Const air_defrost As String = "A"
    Const electric_defrost As String = "E"
    Const hot_gas_defrost As String = "HG"

    Function ask(ByVal unit_coolers As cu_uc_balance_screen_model.unit_cooler_list) As list(Of String)
        Dim defrost_types = New list(Of String)

        For Each unit_cooler In unit_coolers
            Dim message = "Select a defrost type for unit cooler, " & unit_cooler.model & "."
            Dim commands = New StringDictionary()
            commands.add(air_defrost, "Air Defrost")
            commands.add(electric_defrost, "Electric Defrost")
            commands.add(hot_gas_defrost, "Hot Gas Defrost")

            Dim prompt As Persistence.IAskUserToSave
            prompt = New Persistence.AskUserToSave(message,
               New String() {},
               commands)

            defrost_types.add(prompt.ask().SelectedCommand)
        Next

        Return defrost_types
    End Function

End Class

Class td_is_in_range_for_multiple_rooms : Inherits td_is_in_range_for_one_room
    Sub New(ByVal low_td As Double, ByVal high_td As Double)
        MyBase.new(low_td)
        Me.low_td = low_td
        Me.high_td = high_td
    End Sub

    Overrides Function validate() As rae.validation.i_validate
        messages.clear()

        If (low_td < min And high_td < min) Or (low_td > max And high_td > max) Then
            valid = False
            messages.add(New rae.validation.message(rae.validation.validation_status.failure, display_message))
        Else
            valid = True
        End If

        Return Me
    End Function

    Private low_td, high_td As Double
End Class

Class condensing_unit_and_unit_cooler_are_selected : Inherits validator_base
    Private unit_cooler_is_selected, condensing_unit_is_selected As Boolean

    Sub New(ByVal unit_cooler_is_selected As Boolean, ByVal condensing_unit_is_selected As Boolean)
        Me.unit_cooler_is_selected = unit_cooler_is_selected
        Me.condensing_unit_is_selected = condensing_unit_is_selected
    End Sub

    Overrides Function validate() As i_validate
        messages.clear()
        valid = unit_cooler_is_selected And condensing_unit_is_selected
        If Not unit_cooler_is_selected Then
            _messages.add(validation_status.warning, "Please select a unit cooler.")
        End If
        If Not condensing_unit_is_selected Then
            _messages.add(validation_status.warning, "Please select a condensing unit.")
        End If
        Return Me
    End Function
End Class

''' <summary>Shows PFE form containing options</summary>
'Private Sub btn_PFE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
'Handles btnPFE1.Click, btnPFE2.Click, btnPFE3.Click
'   Dim num As Integer
'   Dim senderButton As Button
'   Dim unitCoolers(2) As String
'   Dim horsepower, evaporatorCapacityAt20F As Double

'   ' sets button that was clicked
'   senderButton = DirectCast(sender, Button)
'   ' sets num of unit cooler
'   num = Integer.Parse(senderButton.Name.Substring(senderButton.Name.Length - 1, 1))
'   ' sets unit cooler model, in case Rate System has not been pressed yet
'   unitCoolers(num - 1) = Me.GrabUnitCooler(num - 1)

'   Try
'      ' retrieves horsepower and evaporator capacity at 20F
'      Me.RetrieveEvaporatorInfo(unitCoolers(num - 1), _
'         horsepower, evaporatorCapacityAt20F)
'   Catch dbEx As OleDb.OleDbException
'      RAE.Ui.MessageBox.Show("An exception occurred while attempting " & _
'         " to retrieve evaporator info for PFE series. " & dbEx.Message)
'      ' skips opening PFE options form
'      Exit Sub
'   End Try

'   Dim strHP As String
'   Dim strRPM As String
'   Dim numRB As Integer

'   If evaporatorCapacityAt20F > 0 Then
'      ' sets evaporator capacity
'      If num = 1 Then
'         Me.txtEvaporatorCapacity1.Tag = evaporatorCapacityAt20F
'         ' if textbox is empty or a non-integer, quantity = 0
'         ' sets evaporator capacity per degree
'         Me.txtEvaporatorCapacity1.Text = (evaporatorCapacityAt20F _
'            * ConvertNull.ToInteger(Me.txtUnitCooler1Quantity.Text)).ToString
'      ElseIf num = 2 Then
'         Me.txtEvaporatorCapacity2.Tag = evaporatorCapacityAt20F
'         Me.txtEvaporatorCapacity2.Text = (evaporatorCapacityAt20F _
'            * ConvertNull.ToInteger(Me.txtUnitCooler2Quantity.Text)).ToString
'      ElseIf num = 3 Then
'         Me.txtEvaporatorCapacity3.Tag = evaporatorCapacityAt20F
'         Me.txtEvaporatorCapacity3.Text = (evaporatorCapacityAt20F _
'            * ConvertNull.ToInteger(Me.txtUnitCooler3Quantity.Text)).ToString
'      End If

'      If horsepower = 3 Then
'         strHP = "3 HP"
'         strRPM = "1,750 RPM Fans"
'         numRB = 3
'      Else
'         strHP = "1 1/2 HP"
'         strRPM = "1,140 RPM Fans"
'         numRB = 2
'      End If

'      Dim form As New frmPFEOptions(strHP, strRPM, numRB)
'      form.TopMost = True
'      form.ShowDialog(Me)  'must be closed before continuing
'   Else
'      RAE.Ui.MessageBox.Show( _
'         "This program will only run DRY SURFACE PFE Series", _
'         MessageBoxIcon.Warning)
'   End If
'End Sub
