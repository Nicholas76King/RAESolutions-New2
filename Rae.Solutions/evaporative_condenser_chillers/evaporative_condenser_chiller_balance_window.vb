Imports GlycolNames = Rae.RaeSolutions.DataAccess.Chillers.GlycolColumnNames
Imports BCA = Rae.RaeSolutions.Business.Agents.ChillerAgent
Imports System.Data
Imports System.Environment
Imports System.Math

Imports Rae.RaeSolutions.Business.Entities
Imports Rae.Ui.quickies
Imports Rae.math.Calculate

Imports Rae.Collections
Imports Rae.solutions
Imports Rae.solutions.air_cooled_chillers.chiller
Imports Rae.solutions.chiller_evaporators
Imports Rae.solutions.compressors
Imports Rae.solutions.evaporative_condenser_chillers
Imports Rae.solutions.evaporative_condenser_chillers.balance
Imports Rae.solutions.group
Imports Rae.RaeSolutions.evaporative_condenser_chillers
Imports Rae.validation
Imports Rae.Ui.Validation


Public Class evaporative_condenser_chiller_balance_window : Inherits BaseChillerForm
    Public ProcessDeleted As Boolean
    ' Revision Control / Saving Variables...
    ' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    ' Last saved state...
    Public LastSavedProcess As Rae.RaeSolutions.Business.Entities.EvaporativeCondenserChillerBalance
    ' Current state before save...
    Public CurrentStateProcess As Rae.RaeSolutions.Business.Entities.EvaporativeCondenserChillerBalance
    ' Current displayed state revision number reference...
    Private m_CurrentRevision As Single = -1
    Friend WithEvents capacityFactorLabel As System.Windows.Forms.Label
    Friend WithEvents txt_compressor_capacity_factor As System.Windows.Forms.TextBox
    Friend WithEvents pan_factors As System.Windows.Forms.Panel
    Friend WithEvents txt_condenser_capacity_factor As System.Windows.Forms.TextBox
    Friend WithEvents txt_compressor_amp_factor As System.Windows.Forms.TextBox
    Friend WithEvents compressorAmpFactorLabel As System.Windows.Forms.Label
    Friend WithEvents condenserCapacityFactorLabel As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents evaporator_grid_1 As Rae.RaeSolutions.EvaporatorGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLeavingFluidTemperatureUpperVariance As System.Windows.Forms.TextBox
    Friend WithEvents txtLeavingFluidTemperatureLowerVariance As System.Windows.Forms.TextBox
    Friend WithEvents lbl_condenser_capacity_note As System.Windows.Forms.Label
    Friend WithEvents SaveToolStripPanel1 As Rae.RaeSolutions.SaveToolStripPanel
    Friend WithEvents lbl_35e1_warning As System.Windows.Forms.Label
    Friend WithEvents pan_options_content As System.Windows.Forms.Panel
    Friend WithEvents lbl_suction_loss_F As System.Windows.Forms.Label
    Friend WithEvents lbl_discharge_loss_F As System.Windows.Forms.Label
    Friend WithEvents cbo_suction_loss As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_suction_loss As System.Windows.Forms.Label
    Friend WithEvents lbl_discharge_loss As System.Windows.Forms.Label
    Friend WithEvents cbo_discharge_loss As System.Windows.Forms.ComboBox
    Friend WithEvents pan_range As System.Windows.Forms.Panel
    Friend WithEvents lbl_total_pump_watts As System.Windows.Forms.Label
    Friend WithEvents txt_total_fan_watts As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_pump_watts As System.Windows.Forms.TextBox
    Friend WithEvents lbl_pump_quantity As System.Windows.Forms.Label
    Friend WithEvents txt_fan_quantity As System.Windows.Forms.TextBox
    Friend WithEvents txt_pump_quantity As System.Windows.Forms.TextBox
    Friend WithEvents txt_fan_motor_hp As System.Windows.Forms.TextBox
    Friend WithEvents txt_pump_motor_hp As System.Windows.Forms.TextBox
    Friend WithEvents lblAltitudeFt As System.Windows.Forms.Label
    Friend WithEvents lblAltitude As System.Windows.Forms.Label
    Friend WithEvents txt_altitude As System.Windows.Forms.TextBox
    Friend WithEvents pan_evaporative_condenser As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lbl_pump_hp As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lbl_pump As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents lbl_fan As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel3 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lbl_total_fan_watts As System.Windows.Forms.Label
    Friend WithEvents lbl_fan_hp As System.Windows.Forms.Label
    Friend WithEvents lbl_fan_quantity As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents lbl_altitude_feet As System.Windows.Forms.Label
    Friend WithEvents lbl_custom_condenser_model As System.Windows.Forms.Label
    Friend WithEvents txt_custom_condenser_model As System.Windows.Forms.TextBox
    Friend WithEvents pan_compressor_2 As System.Windows.Forms.Panel
    Friend WithEvents lbl_select_model As System.Windows.Forms.Label
    ''Friend WithEvents pan_rating_criteria_header As Rae.Ui.Controls.CollapsableHeader
    ''Friend WithEvents pan_compressor_header As Rae.Ui.Controls.CollapsableHeader
    ''Friend WithEvents pan_evaporative_condenser_header As Rae.Ui.Controls.CollapsableHeader
    ''Friend WithEvents pan_evaporator_header As Rae.Ui.Controls.CollapsableHeader
    Friend WithEvents btn_go_to_pricing As System.Windows.Forms.Button
    Friend WithEvents btn_create_report As System.Windows.Forms.Button
    Friend WithEvents btn_run_balance As System.Windows.Forms.Button
    Friend WithEvents pan_buttons As System.Windows.Forms.Panel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_show_iplv_report As System.Windows.Forms.Button
    Friend WithEvents btn_show_nplv_report As System.Windows.Forms.Button
    Friend WithEvents plv_background_worker As System.ComponentModel.BackgroundWorker
    Friend WithEvents progress_bar As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView

    ''' <summary>
    ''' The current revision # of process 
    ''' being displayed on this form.
    ''' </summary>
    Property CurrentRevision() As Single
        Get
            Return Me.m_CurrentRevision
        End Get
        Set(ByVal value As Single)
            Me.m_CurrentRevision = value
        End Set
    End Property
    ' Latest revision # of the current 
    ' process ID (if any)...
    Private m_LatestRevision As Single = -1
    ''' <summary>
    ''' The latest revision # of process 
    ''' being displayed on this form.
    ''' </summary>
    Property LatestRevision() As Single
        Get
            Return Me.m_LatestRevision
        End Get
        Set(ByVal value As Single)
            Me.m_LatestRevision = value
        End Set
    End Property
    ' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

#Region " Windows Form Designer generated code "

    Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()


        If AppInfo.User.authority_group = user_group.rep Then
            txt_compressor_qty_1.ReadOnly = True
            txt_compressor_qty_2.ReadOnly = True
        End If

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
    Friend WithEvents pan_main As System.Windows.Forms.Panel
    Friend WithEvents pan_rating_criteria As System.Windows.Forms.Panel
    Friend WithEvents pan_compressor As System.Windows.Forms.Panel
    Friend WithEvents lblErro As System.Windows.Forms.Label
    Friend WithEvents Txt_circuit_per_unit As System.Windows.Forms.TextBox
    Friend WithEvents pan_evaporator As System.Windows.Forms.Panel
    Friend WithEvents panGrid As System.Windows.Forms.Panel
    Friend WithEvents lblOperLimi As System.Windows.Forms.Label
    Friend WithEvents cbo_voltage As System.Windows.Forms.ComboBox
    Friend WithEvents txt_Evap_Length As System.Windows.Forms.TextBox
    Friend WithEvents lblRatiVolt As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents pan_footer As System.Windows.Forms.Panel
    Friend WithEvents picError As System.Windows.Forms.PictureBox
    Friend WithEvents lblModel As System.Windows.Forms.Label
    Friend WithEvents cbo_series As System.Windows.Forms.ComboBox
    Friend WithEvents btn_glycol_chart As System.Windows.Forms.Button
    Friend WithEvents panEvaporator As System.Windows.Forms.Panel
    Friend WithEvents pan_compressor_1 As System.Windows.Forms.Panel
    Friend WithEvents panRatingCriteria As System.Windows.Forms.Panel
    Friend WithEvents lbl_range_f As System.Windows.Forms.Label
    Friend WithEvents lblAmbientF As System.Windows.Forms.Label
    Friend WithEvents lblLeavingFluidF As System.Windows.Forms.Label
    Friend WithEvents lbl_subcooling_f As System.Windows.Forms.Label
    Friend WithEvents lbl_freeze_point_f As System.Windows.Forms.Label
    Friend WithEvents lbl_min_suction_f As System.Windows.Forms.Label
    Friend WithEvents lblCondenserCapacityBtuh As System.Windows.Forms.Label
    Friend WithEvents btn_alternate_evaporators As System.Windows.Forms.Button
    Friend WithEvents cbo_models As System.Windows.Forms.ComboBox
    Friend WithEvents lblSeries As System.Windows.Forms.Label
    Friend WithEvents txt_model As System.Windows.Forms.TextBox
    Friend WithEvents lbl_approach As System.Windows.Forms.Label
    Friend WithEvents lblHertz As System.Windows.Forms.Label
    Friend WithEvents lbl_freeze_point As System.Windows.Forms.Label
    Friend WithEvents lbl_specific_gravity As System.Windows.Forms.Label
    Friend WithEvents lbl_specific_heat As System.Windows.Forms.Label
    Friend WithEvents lblGlycolPercentage As System.Windows.Forms.Label
    Friend WithEvents lblFluid As System.Windows.Forms.Label
    Friend WithEvents lbl_glycol As System.Windows.Forms.Label
    Friend WithEvents lbl_min_suction As System.Windows.Forms.Label
    Friend WithEvents lbl_subcooling As System.Windows.Forms.Label
    Friend WithEvents lbl_leaving_fluid_temp As System.Windows.Forms.Label
    Friend WithEvents lbl_ambient As System.Windows.Forms.Label
    Friend WithEvents lbl_range As System.Windows.Forms.Label
    Friend WithEvents lbl_refrigerant As System.Windows.Forms.Label
    Friend WithEvents lblFoulingFactor As System.Windows.Forms.Label
    Friend WithEvents lblEvaporatorModel As System.Windows.Forms.Label
    Friend WithEvents lbl_condenser_capacity As System.Windows.Forms.Label
    Friend WithEvents lbl_condenser_model As System.Windows.Forms.Label
    Friend WithEvents lbl_condenser_quantity As System.Windows.Forms.Label
    Friend WithEvents lblNumCompressors2 As System.Windows.Forms.Label
    Friend WithEvents lblCompressor2 As System.Windows.Forms.Label
    Friend WithEvents lblNumCompressors1 As System.Windows.Forms.Label
    Friend WithEvents lblCompressor1 As System.Windows.Forms.Label
    Friend WithEvents pan_model As System.Windows.Forms.Panel
    Friend WithEvents txt_freeze_point As System.Windows.Forms.TextBox
    Friend WithEvents txt_specific_gravity As System.Windows.Forms.TextBox
    Friend WithEvents txt_specific_heat As System.Windows.Forms.TextBox
    Friend WithEvents txt_glycol_percentage As System.Windows.Forms.TextBox
    Friend WithEvents cbo_fluid As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_glycol As System.Windows.Forms.ComboBox
    Friend WithEvents txt_min_suction As System.Windows.Forms.TextBox
    Friend WithEvents txt_subcooling As System.Windows.Forms.TextBox
    Friend WithEvents txt_approach As System.Windows.Forms.TextBox
    Friend WithEvents cbo_hertz As System.Windows.Forms.ComboBox
    Friend WithEvents txt_leaving_fluid_temp As System.Windows.Forms.TextBox
    Friend WithEvents txt_ambient As System.Windows.Forms.TextBox
    Friend WithEvents txt_range As System.Windows.Forms.TextBox
    Friend WithEvents cbo_refrigerant As System.Windows.Forms.ComboBox
    Friend WithEvents chk_safety_override As System.Windows.Forms.CheckBox
    Friend WithEvents txt_compressor_qty_2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_compressor_2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_compressor_qty_1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_compressor_1 As System.Windows.Forms.TextBox
    Friend WithEvents lbo_compressors_2 As System.Windows.Forms.ListBox
    Friend WithEvents lbo_compressors_1 As System.Windows.Forms.ListBox
    Friend WithEvents cbo_condenser_model As System.Windows.Forms.ComboBox
    Friend WithEvents txt_condenser_capacity As System.Windows.Forms.TextBox
    Friend WithEvents chk_catalog_rating As System.Windows.Forms.CheckBox
    Friend WithEvents cboFoulingFactor As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_evaporator_model As System.Windows.Forms.ComboBox
    Friend WithEvents txt_evaporator_model As System.Windows.Forms.TextBox
    Friend WithEvents txtEvaporatorCapacity As System.Windows.Forms.TextBox
    Friend WithEvents radGpm As System.Windows.Forms.RadioButton
    Friend WithEvents radTons As System.Windows.Forms.RadioButton
    Friend WithEvents cboNumEvap As System.Windows.Forms.ComboBox
    Friend WithEvents lblNumEvap As System.Windows.Forms.Label
    Friend WithEvents txt_condenser_quantity As System.Windows.Forms.TextBox
    Friend WithEvents lbl_voltage As System.Windows.Forms.Label
    Friend WithEvents lblLeavingFluidTemperatureStep As System.Windows.Forms.Label
    Friend WithEvents lblTE As System.Windows.Forms.Label
    Friend WithEvents txtLeavingFluidTemperatureStep As System.Windows.Forms.TextBox
    Friend WithEvents lblAmbientStep As System.Windows.Forms.Label
    Friend WithEvents txtATIncrement As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtATMax As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtATMin As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents fileMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSaveAs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuConvert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSaveAsRevision As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents err As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(evaporative_condenser_chiller_balance_window))
        Me.lblModel = New System.Windows.Forms.Label()
        Me.pan_main = New System.Windows.Forms.Panel()
        Me.panGrid = New System.Windows.Forms.Panel()
        Me.lblOperLimi = New System.Windows.Forms.Label()
        Me.pan_evaporator = New System.Windows.Forms.Panel()
        Me.evaporator_grid_1 = New Rae.RaeSolutions.EvaporatorGrid()
        Me.txt_Evap_Length = New System.Windows.Forms.TextBox()
        Me.panEvaporator = New System.Windows.Forms.Panel()
        Me.cboNumEvap = New System.Windows.Forms.ComboBox()
        Me.lblNumEvap = New System.Windows.Forms.Label()
        Me.chk_catalog_rating = New System.Windows.Forms.CheckBox()
        Me.cboFoulingFactor = New System.Windows.Forms.ComboBox()
        Me.lblFoulingFactor = New System.Windows.Forms.Label()
        Me.btn_alternate_evaporators = New System.Windows.Forms.Button()
        Me.cbo_evaporator_model = New System.Windows.Forms.ComboBox()
        Me.lblEvaporatorModel = New System.Windows.Forms.Label()
        Me.txt_evaporator_model = New System.Windows.Forms.TextBox()
        Me.radGpm = New System.Windows.Forms.RadioButton()
        Me.radTons = New System.Windows.Forms.RadioButton()
        Me.txtEvaporatorCapacity = New System.Windows.Forms.TextBox()
        Me.pan_evaporative_condenser = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.lbl_custom_condenser_model = New System.Windows.Forms.Label()
        Me.txt_custom_condenser_model = New System.Windows.Forms.TextBox()
        Me.lbl_condenser_capacity = New System.Windows.Forms.Label()
        Me.lbl_condenser_capacity_note = New System.Windows.Forms.Label()
        Me.txt_condenser_capacity = New System.Windows.Forms.TextBox()
        Me.lbl_condenser_model = New System.Windows.Forms.Label()
        Me.lblCondenserCapacityBtuh = New System.Windows.Forms.Label()
        Me.cbo_condenser_model = New System.Windows.Forms.ComboBox()
        Me.txt_condenser_quantity = New System.Windows.Forms.TextBox()
        Me.lbl_condenser_quantity = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lbl_pump = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.lbl_total_pump_watts = New System.Windows.Forms.Label()
        Me.txt_total_pump_watts = New System.Windows.Forms.TextBox()
        Me.lbl_pump_hp = New System.Windows.Forms.Label()
        Me.txt_pump_motor_hp = New System.Windows.Forms.TextBox()
        Me.lbl_pump_quantity = New System.Windows.Forms.Label()
        Me.txt_pump_quantity = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lbl_fan = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.lbl_total_fan_watts = New System.Windows.Forms.Label()
        Me.txt_total_fan_watts = New System.Windows.Forms.TextBox()
        Me.lbl_fan_hp = New System.Windows.Forms.Label()
        Me.txt_fan_motor_hp = New System.Windows.Forms.TextBox()
        Me.lbl_fan_quantity = New System.Windows.Forms.Label()
        Me.txt_fan_quantity = New System.Windows.Forms.TextBox()
        Me.lbl_discharge_loss = New System.Windows.Forms.Label()
        Me.cbo_discharge_loss = New System.Windows.Forms.ComboBox()
        Me.lbl_discharge_loss_F = New System.Windows.Forms.Label()
        Me.lbl_suction_loss = New System.Windows.Forms.Label()
        Me.cbo_suction_loss = New System.Windows.Forms.ComboBox()
        Me.lbl_suction_loss_F = New System.Windows.Forms.Label()
        Me.pan_options_content = New System.Windows.Forms.Panel()
        Me.pan_compressor = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pan_compressor_2 = New System.Windows.Forms.Panel()
        Me.lblCompressor2 = New System.Windows.Forms.Label()
        Me.lblNumCompressors2 = New System.Windows.Forms.Label()
        Me.lbo_compressors_2 = New System.Windows.Forms.ListBox()
        Me.txt_compressor_2 = New System.Windows.Forms.TextBox()
        Me.txt_compressor_qty_2 = New System.Windows.Forms.TextBox()
        Me.pan_compressor_1 = New System.Windows.Forms.Panel()
        Me.lblNumCompressors1 = New System.Windows.Forms.Label()
        Me.txt_compressor_qty_1 = New System.Windows.Forms.TextBox()
        Me.txt_compressor_1 = New System.Windows.Forms.TextBox()
        Me.lblCompressor1 = New System.Windows.Forms.Label()
        Me.lbo_compressors_1 = New System.Windows.Forms.ListBox()
        Me.chk_safety_override = New System.Windows.Forms.CheckBox()
        Me.Txt_circuit_per_unit = New System.Windows.Forms.TextBox()
        Me.pan_rating_criteria = New System.Windows.Forms.Panel()
        Me.panRatingCriteria = New System.Windows.Forms.Panel()
        Me.lbl_altitude_feet = New System.Windows.Forms.Label()
        Me.lblAltitudeFt = New System.Windows.Forms.Label()
        Me.lblAltitude = New System.Windows.Forms.Label()
        Me.txt_altitude = New System.Windows.Forms.TextBox()
        Me.pan_range = New System.Windows.Forms.Panel()
        Me.lblAmbientStep = New System.Windows.Forms.Label()
        Me.lblTE = New System.Windows.Forms.Label()
        Me.txtATIncrement = New System.Windows.Forms.TextBox()
        Me.txtLeavingFluidTemperatureLowerVariance = New System.Windows.Forms.TextBox()
        Me.txtLeavingFluidTemperatureUpperVariance = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtLeavingFluidTemperatureStep = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtATMax = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblLeavingFluidTemperatureStep = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtATMin = New System.Windows.Forms.TextBox()
        Me.lbl_range_f = New System.Windows.Forms.Label()
        Me.lblAmbientF = New System.Windows.Forms.Label()
        Me.lblRatiVolt = New System.Windows.Forms.Label()
        Me.cbo_hertz = New System.Windows.Forms.ComboBox()
        Me.lblLeavingFluidF = New System.Windows.Forms.Label()
        Me.lbl_subcooling_f = New System.Windows.Forms.Label()
        Me.lbl_freeze_point_f = New System.Windows.Forms.Label()
        Me.lbl_voltage = New System.Windows.Forms.Label()
        Me.cbo_voltage = New System.Windows.Forms.ComboBox()
        Me.lbl_min_suction_f = New System.Windows.Forms.Label()
        Me.lblHertz = New System.Windows.Forms.Label()
        Me.btn_glycol_chart = New System.Windows.Forms.Button()
        Me.txt_approach = New System.Windows.Forms.TextBox()
        Me.lbl_approach = New System.Windows.Forms.Label()
        Me.txt_freeze_point = New System.Windows.Forms.TextBox()
        Me.lbl_freeze_point = New System.Windows.Forms.Label()
        Me.lbl_specific_gravity = New System.Windows.Forms.Label()
        Me.lbl_specific_heat = New System.Windows.Forms.Label()
        Me.txt_specific_gravity = New System.Windows.Forms.TextBox()
        Me.txt_specific_heat = New System.Windows.Forms.TextBox()
        Me.txt_glycol_percentage = New System.Windows.Forms.TextBox()
        Me.lblGlycolPercentage = New System.Windows.Forms.Label()
        Me.cbo_fluid = New System.Windows.Forms.ComboBox()
        Me.lblFluid = New System.Windows.Forms.Label()
        Me.cbo_glycol = New System.Windows.Forms.ComboBox()
        Me.lbl_glycol = New System.Windows.Forms.Label()
        Me.txt_min_suction = New System.Windows.Forms.TextBox()
        Me.lbl_min_suction = New System.Windows.Forms.Label()
        Me.txt_subcooling = New System.Windows.Forms.TextBox()
        Me.lbl_subcooling = New System.Windows.Forms.Label()
        Me.txt_leaving_fluid_temp = New System.Windows.Forms.TextBox()
        Me.lbl_leaving_fluid_temp = New System.Windows.Forms.Label()
        Me.lbl_ambient = New System.Windows.Forms.Label()
        Me.txt_ambient = New System.Windows.Forms.TextBox()
        Me.lbl_range = New System.Windows.Forms.Label()
        Me.txt_range = New System.Windows.Forms.TextBox()
        Me.lbl_refrigerant = New System.Windows.Forms.Label()
        Me.cbo_refrigerant = New System.Windows.Forms.ComboBox()
        Me.pan_factors = New System.Windows.Forms.Panel()
        Me.txt_compressor_capacity_factor = New System.Windows.Forms.TextBox()
        Me.txt_condenser_capacity_factor = New System.Windows.Forms.TextBox()
        Me.txt_compressor_amp_factor = New System.Windows.Forms.TextBox()
        Me.compressorAmpFactorLabel = New System.Windows.Forms.Label()
        Me.condenserCapacityFactorLabel = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.capacityFactorLabel = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pan_model = New System.Windows.Forms.Panel()
        Me.lbl_35e1_warning = New System.Windows.Forms.Label()
        Me.cbo_models = New System.Windows.Forms.ComboBox()
        Me.cbo_series = New System.Windows.Forms.ComboBox()
        Me.lblSeries = New System.Windows.Forms.Label()
        Me.txt_model = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.fileMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSaveAsRevision = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuConvert = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_go_to_pricing = New System.Windows.Forms.Button()
        Me.btn_create_report = New System.Windows.Forms.Button()
        Me.btn_run_balance = New System.Windows.Forms.Button()
        Me.lblErro = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pan_footer = New System.Windows.Forms.Panel()
        Me.pan_buttons = New System.Windows.Forms.Panel()
        Me.progress_bar = New System.Windows.Forms.ProgressBar()
        Me.btn_show_nplv_report = New System.Windows.Forms.Button()
        Me.btn_show_iplv_report = New System.Windows.Forms.Button()
        Me.picError = New System.Windows.Forms.PictureBox()
        Me.err = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.SaveToolStripPanel1 = New Rae.RaeSolutions.SaveToolStripPanel()
        Me.lbl_select_model = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.plv_background_worker = New System.ComponentModel.BackgroundWorker()
        CType(Me.results, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pan_main.SuspendLayout()
        Me.panGrid.SuspendLayout()
        Me.pan_evaporator.SuspendLayout()
        Me.panEvaporator.SuspendLayout()
        Me.pan_evaporative_condenser.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.pan_compressor.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pan_compressor_2.SuspendLayout()
        Me.pan_compressor_1.SuspendLayout()
        Me.pan_rating_criteria.SuspendLayout()
        Me.panRatingCriteria.SuspendLayout()
        Me.pan_range.SuspendLayout()
        Me.pan_factors.SuspendLayout()
        Me.pan_model.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.pan_footer.SuspendLayout()
        Me.pan_buttons.SuspendLayout()
        CType(Me.picError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.err, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblModel
        '
        Me.lblModel.Location = New System.Drawing.Point(44, 33)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(54, 23)
        Me.lblModel.TabIndex = 0
        Me.lblModel.Text = "Model #"
        Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pan_main
        '
        Me.pan_main.AutoScroll = True
        Me.pan_main.BackColor = System.Drawing.Color.White
        Me.pan_main.Controls.Add(Me.panGrid)
        Me.pan_main.Controls.Add(Me.pan_evaporator)
        Me.pan_main.Controls.Add(Me.pan_evaporative_condenser)
        Me.pan_main.Controls.Add(Me.pan_compressor)
        Me.pan_main.Controls.Add(Me.pan_rating_criteria)
        Me.pan_main.Controls.Add(Me.pan_factors)
        Me.pan_main.Controls.Add(Me.pan_model)
        Me.pan_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pan_main.Location = New System.Drawing.Point(0, 32)
        Me.pan_main.Name = "pan_main"
        Me.pan_main.Size = New System.Drawing.Size(941, 485)
        Me.pan_main.TabIndex = 3
        '
        'panGrid
        '
        Me.panGrid.BackColor = System.Drawing.Color.White
        Me.panGrid.Controls.Add(Me.lblOperLimi)
        Me.panGrid.Dock = System.Windows.Forms.DockStyle.Top
        Me.panGrid.Location = New System.Drawing.Point(0, 1340)
        Me.panGrid.Name = "panGrid"
        Me.panGrid.Size = New System.Drawing.Size(924, 405)
        Me.panGrid.TabIndex = 20
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
        'pan_evaporator
        '
        Me.pan_evaporator.BackColor = System.Drawing.Color.White
        Me.pan_evaporator.Controls.Add(Me.evaporator_grid_1)
        Me.pan_evaporator.Controls.Add(Me.txt_Evap_Length)
        Me.pan_evaporator.Controls.Add(Me.panEvaporator)
        Me.pan_evaporator.Dock = System.Windows.Forms.DockStyle.Top
        Me.pan_evaporator.Location = New System.Drawing.Point(0, 866)
        Me.pan_evaporator.Name = "pan_evaporator"
        Me.pan_evaporator.Padding = New System.Windows.Forms.Padding(10, 10, 10, 2)
        Me.pan_evaporator.Size = New System.Drawing.Size(924, 474)
        Me.pan_evaporator.TabIndex = 9
        '
        'evaporator_grid_1
        '
        Me.evaporator_grid_1.BackColor = System.Drawing.Color.White
        Me.evaporator_grid_1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.evaporator_grid_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.evaporator_grid_1.ForeColor = System.Drawing.Color.Black
        Me.evaporator_grid_1.Location = New System.Drawing.Point(10, 141)
        Me.evaporator_grid_1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.evaporator_grid_1.Name = "evaporator_grid_1"
        Me.evaporator_grid_1.Size = New System.Drawing.Size(904, 331)
        Me.evaporator_grid_1.TabIndex = 51
        '
        'txt_Evap_Length
        '
        Me.txt_Evap_Length.Location = New System.Drawing.Point(540, 16)
        Me.txt_Evap_Length.Name = "txt_Evap_Length"
        Me.txt_Evap_Length.Size = New System.Drawing.Size(100, 21)
        Me.txt_Evap_Length.TabIndex = 3
        Me.txt_Evap_Length.Visible = False
        '
        'panEvaporator
        '
        Me.panEvaporator.BackColor = System.Drawing.Color.White
        Me.panEvaporator.Controls.Add(Me.cboNumEvap)
        Me.panEvaporator.Controls.Add(Me.lblNumEvap)
        Me.panEvaporator.Controls.Add(Me.chk_catalog_rating)
        Me.panEvaporator.Controls.Add(Me.cboFoulingFactor)
        Me.panEvaporator.Controls.Add(Me.lblFoulingFactor)
        Me.panEvaporator.Controls.Add(Me.btn_alternate_evaporators)
        Me.panEvaporator.Controls.Add(Me.cbo_evaporator_model)
        Me.panEvaporator.Controls.Add(Me.lblEvaporatorModel)
        Me.panEvaporator.Controls.Add(Me.txt_evaporator_model)
        Me.panEvaporator.Controls.Add(Me.radGpm)
        Me.panEvaporator.Controls.Add(Me.radTons)
        Me.panEvaporator.Controls.Add(Me.txtEvaporatorCapacity)
        Me.panEvaporator.Location = New System.Drawing.Point(12, 3)
        Me.panEvaporator.Name = "panEvaporator"
        Me.panEvaporator.Size = New System.Drawing.Size(504, 144)
        Me.panEvaporator.TabIndex = 0
        '
        'cboNumEvap
        '
        Me.cboNumEvap.Items.AddRange(New Object() {"1", "2", "4"})
        Me.cboNumEvap.Location = New System.Drawing.Point(391, 38)
        Me.cboNumEvap.Name = "cboNumEvap"
        Me.cboNumEvap.Size = New System.Drawing.Size(72, 21)
        Me.cboNumEvap.TabIndex = 51
        Me.cboNumEvap.Visible = False
        '
        'lblNumEvap
        '
        Me.lblNumEvap.Location = New System.Drawing.Point(330, 36)
        Me.lblNumEvap.Name = "lblNumEvap"
        Me.lblNumEvap.Size = New System.Drawing.Size(55, 23)
        Me.lblNumEvap.TabIndex = 50
        Me.lblNumEvap.Text = "Evap Qty"
        Me.lblNumEvap.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblNumEvap.Visible = False
        '
        'chk_catalog_rating
        '
        Me.chk_catalog_rating.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chk_catalog_rating.Location = New System.Drawing.Point(172, 120)
        Me.chk_catalog_rating.Name = "chk_catalog_rating"
        Me.chk_catalog_rating.Size = New System.Drawing.Size(104, 24)
        Me.chk_catalog_rating.TabIndex = 8
        Me.chk_catalog_rating.Text = "Catalog rating"
        '
        'cboFoulingFactor
        '
        Me.cboFoulingFactor.Items.AddRange(New Object() {".0001", ".00025", ".0005", ".00075", ".001"})
        Me.cboFoulingFactor.Location = New System.Drawing.Point(172, 64)
        Me.cboFoulingFactor.Name = "cboFoulingFactor"
        Me.cboFoulingFactor.Size = New System.Drawing.Size(72, 21)
        Me.cboFoulingFactor.TabIndex = 4
        Me.cboFoulingFactor.Text = ".0001"
        '
        'lblFoulingFactor
        '
        Me.lblFoulingFactor.Location = New System.Drawing.Point(64, 64)
        Me.lblFoulingFactor.Name = "lblFoulingFactor"
        Me.lblFoulingFactor.Size = New System.Drawing.Size(100, 23)
        Me.lblFoulingFactor.TabIndex = 37
        Me.lblFoulingFactor.Text = "Fouling factor"
        Me.lblFoulingFactor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn_alternate_evaporators
        '
        Me.btn_alternate_evaporators.BackColor = System.Drawing.SystemColors.Control
        Me.btn_alternate_evaporators.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_alternate_evaporators.Location = New System.Drawing.Point(8, 7)
        Me.btn_alternate_evaporators.Name = "btn_alternate_evaporators"
        Me.btn_alternate_evaporators.Size = New System.Drawing.Size(156, 23)
        Me.btn_alternate_evaporators.TabIndex = 1
        Me.btn_alternate_evaporators.Text = "List Alternate Evaporators"
        Me.btn_alternate_evaporators.UseVisualStyleBackColor = False
        '
        'cbo_evaporator_model
        '
        Me.cbo_evaporator_model.Location = New System.Drawing.Point(172, 8)
        Me.cbo_evaporator_model.Name = "cbo_evaporator_model"
        Me.cbo_evaporator_model.Size = New System.Drawing.Size(144, 21)
        Me.cbo_evaporator_model.TabIndex = 2
        Me.cbo_evaporator_model.Visible = False
        '
        'lblEvaporatorModel
        '
        Me.lblEvaporatorModel.Location = New System.Drawing.Point(52, 36)
        Me.lblEvaporatorModel.Name = "lblEvaporatorModel"
        Me.lblEvaporatorModel.Size = New System.Drawing.Size(110, 23)
        Me.lblEvaporatorModel.TabIndex = 33
        Me.lblEvaporatorModel.Text = "Evaporator model #"
        Me.lblEvaporatorModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_evaporator_model
        '
        Me.txt_evaporator_model.Location = New System.Drawing.Point(172, 36)
        Me.txt_evaporator_model.Name = "txt_evaporator_model"
        Me.txt_evaporator_model.Size = New System.Drawing.Size(144, 21)
        Me.txt_evaporator_model.TabIndex = 3
        '
        'radGpm
        '
        Me.radGpm.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.radGpm.Location = New System.Drawing.Point(116, 92)
        Me.radGpm.Name = "radGpm"
        Me.radGpm.Size = New System.Drawing.Size(53, 24)
        Me.radGpm.TabIndex = 7
        Me.radGpm.Text = "GPM"
        '
        'radTons
        '
        Me.radTons.Checked = True
        Me.radTons.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.radTons.Location = New System.Drawing.Point(52, 92)
        Me.radTons.Name = "radTons"
        Me.radTons.Size = New System.Drawing.Size(68, 24)
        Me.radTons.TabIndex = 6
        Me.radTons.TabStop = True
        Me.radTons.Text = "Tons or"
        '
        'txtEvaporatorCapacity
        '
        Me.txtEvaporatorCapacity.Location = New System.Drawing.Point(172, 92)
        Me.txtEvaporatorCapacity.Name = "txtEvaporatorCapacity"
        Me.txtEvaporatorCapacity.Size = New System.Drawing.Size(72, 21)
        Me.txtEvaporatorCapacity.TabIndex = 5
        Me.txtEvaporatorCapacity.Text = "0"
        '
        'pan_evaporative_condenser
        '
        Me.pan_evaporative_condenser.AutoSize = True
        Me.pan_evaporative_condenser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pan_evaporative_condenser.Controls.Add(Me.Panel6)
        Me.pan_evaporative_condenser.Controls.Add(Me.Panel2)
        Me.pan_evaporative_condenser.Controls.Add(Me.Panel4)
        Me.pan_evaporative_condenser.Controls.Add(Me.lbl_discharge_loss)
        Me.pan_evaporative_condenser.Controls.Add(Me.cbo_discharge_loss)
        Me.pan_evaporative_condenser.Controls.Add(Me.lbl_discharge_loss_F)
        Me.pan_evaporative_condenser.Controls.Add(Me.lbl_suction_loss)
        Me.pan_evaporative_condenser.Controls.Add(Me.cbo_suction_loss)
        Me.pan_evaporative_condenser.Controls.Add(Me.lbl_suction_loss_F)
        Me.pan_evaporative_condenser.Controls.Add(Me.pan_options_content)
        Me.pan_evaporative_condenser.Dock = System.Windows.Forms.DockStyle.Top
        Me.pan_evaporative_condenser.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pan_evaporative_condenser.Location = New System.Drawing.Point(0, 562)
        Me.pan_evaporative_condenser.Name = "pan_evaporative_condenser"
        Me.pan_evaporative_condenser.Padding = New System.Windows.Forms.Padding(3)
        Me.pan_evaporative_condenser.Size = New System.Drawing.Size(924, 304)
        Me.pan_evaporative_condenser.TabIndex = 8
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.White
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.pan_evaporative_condenser.SetFlowBreak(Me.Panel6, True)
        Me.Panel6.Location = New System.Drawing.Point(5, 5)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel6.Size = New System.Drawing.Size(490, 90)
        Me.Panel6.TabIndex = 1
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.White
        Me.Panel7.Controls.Add(Me.lbl_custom_condenser_model)
        Me.Panel7.Controls.Add(Me.txt_custom_condenser_model)
        Me.Panel7.Controls.Add(Me.lbl_condenser_capacity)
        Me.Panel7.Controls.Add(Me.lbl_condenser_capacity_note)
        Me.Panel7.Controls.Add(Me.txt_condenser_capacity)
        Me.Panel7.Controls.Add(Me.lbl_condenser_model)
        Me.Panel7.Controls.Add(Me.lblCondenserCapacityBtuh)
        Me.Panel7.Controls.Add(Me.cbo_condenser_model)
        Me.Panel7.Controls.Add(Me.txt_condenser_quantity)
        Me.Panel7.Controls.Add(Me.lbl_condenser_quantity)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(2, 2)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(486, 86)
        Me.Panel7.TabIndex = 91
        '
        'lbl_custom_condenser_model
        '
        Me.lbl_custom_condenser_model.AutoSize = True
        Me.lbl_custom_condenser_model.Location = New System.Drawing.Point(257, 12)
        Me.lbl_custom_condenser_model.Margin = New System.Windows.Forms.Padding(3, 11, 3, 3)
        Me.lbl_custom_condenser_model.Name = "lbl_custom_condenser_model"
        Me.lbl_custom_condenser_model.Size = New System.Drawing.Size(74, 13)
        Me.lbl_custom_condenser_model.TabIndex = 73
        Me.lbl_custom_condenser_model.Text = "Custom model"
        Me.lbl_custom_condenser_model.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txt_custom_condenser_model
        '
        Me.txt_custom_condenser_model.Location = New System.Drawing.Point(338, 7)
        Me.txt_custom_condenser_model.Name = "txt_custom_condenser_model"
        Me.txt_custom_condenser_model.Size = New System.Drawing.Size(132, 21)
        Me.txt_custom_condenser_model.TabIndex = 2
        '
        'lbl_condenser_capacity
        '
        Me.lbl_condenser_capacity.AutoSize = True
        Me.lbl_condenser_capacity.Location = New System.Drawing.Point(55, 37)
        Me.lbl_condenser_capacity.Margin = New System.Windows.Forms.Padding(3, 8, 3, 3)
        Me.lbl_condenser_capacity.Name = "lbl_condenser_capacity"
        Me.lbl_condenser_capacity.Size = New System.Drawing.Size(77, 13)
        Me.lbl_condenser_capacity.TabIndex = 38
        Me.lbl_condenser_capacity.Text = "Est. Capacity*"
        Me.lbl_condenser_capacity.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lbl_condenser_capacity_note
        '
        Me.lbl_condenser_capacity_note.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lbl_condenser_capacity_note.Location = New System.Drawing.Point(6, 58)
        Me.lbl_condenser_capacity_note.Name = "lbl_condenser_capacity_note"
        Me.lbl_condenser_capacity_note.Size = New System.Drawing.Size(476, 21)
        Me.lbl_condenser_capacity_note.TabIndex = 71
        Me.lbl_condenser_capacity_note.Text = "* est. condenser capacity is at 78 degree wet bulb and 105 condensing temperature" &
    " (per condenser)"
        Me.lbl_condenser_capacity_note.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_condenser_capacity
        '
        Me.txt_condenser_capacity.Location = New System.Drawing.Point(138, 34)
        Me.txt_condenser_capacity.Name = "txt_condenser_capacity"
        Me.txt_condenser_capacity.ReadOnly = True
        Me.txt_condenser_capacity.Size = New System.Drawing.Size(49, 21)
        Me.txt_condenser_capacity.TabIndex = 3
        '
        'lbl_condenser_model
        '
        Me.lbl_condenser_model.AutoSize = True
        Me.lbl_condenser_model.Location = New System.Drawing.Point(57, 12)
        Me.lbl_condenser_model.Margin = New System.Windows.Forms.Padding(3, 11, 3, 3)
        Me.lbl_condenser_model.Name = "lbl_condenser_model"
        Me.lbl_condenser_model.Size = New System.Drawing.Size(35, 13)
        Me.lbl_condenser_model.TabIndex = 6
        Me.lbl_condenser_model.Text = "Model"
        Me.lbl_condenser_model.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblCondenserCapacityBtuh
        '
        Me.lblCondenserCapacityBtuh.AutoSize = True
        Me.lblCondenserCapacityBtuh.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblCondenserCapacityBtuh.Location = New System.Drawing.Point(194, 39)
        Me.lblCondenserCapacityBtuh.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.lblCondenserCapacityBtuh.Name = "lblCondenserCapacityBtuh"
        Me.lblCondenserCapacityBtuh.Size = New System.Drawing.Size(41, 13)
        Me.lblCondenserCapacityBtuh.TabIndex = 55
        Me.lblCondenserCapacityBtuh.Text = "MBTUH"
        Me.lblCondenserCapacityBtuh.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cbo_condenser_model
        '
        Me.cbo_condenser_model.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_condenser_model.Location = New System.Drawing.Point(122, 7)
        Me.cbo_condenser_model.Margin = New System.Windows.Forms.Padding(3, 7, 3, 3)
        Me.cbo_condenser_model.Name = "cbo_condenser_model"
        Me.cbo_condenser_model.Size = New System.Drawing.Size(90, 21)
        Me.cbo_condenser_model.TabIndex = 1
        '
        'txt_condenser_quantity
        '
        Me.txt_condenser_quantity.Location = New System.Drawing.Point(338, 34)
        Me.txt_condenser_quantity.Name = "txt_condenser_quantity"
        Me.txt_condenser_quantity.ReadOnly = True
        Me.txt_condenser_quantity.Size = New System.Drawing.Size(55, 21)
        Me.txt_condenser_quantity.TabIndex = 4
        Me.txt_condenser_quantity.TabStop = False
        Me.txt_condenser_quantity.Text = "0"
        '
        'lbl_condenser_quantity
        '
        Me.lbl_condenser_quantity.AutoSize = True
        Me.lbl_condenser_quantity.Location = New System.Drawing.Point(282, 39)
        Me.lbl_condenser_quantity.Margin = New System.Windows.Forms.Padding(15, 8, 3, 3)
        Me.lbl_condenser_quantity.Name = "lbl_condenser_quantity"
        Me.lbl_condenser_quantity.Size = New System.Drawing.Size(49, 13)
        Me.lbl_condenser_quantity.TabIndex = 2
        Me.lbl_condenser_quantity.Text = "Quantity"
        Me.lbl_condenser_quantity.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.pan_evaporative_condenser.SetFlowBreak(Me.Panel2, True)
        Me.Panel2.Location = New System.Drawing.Point(5, 99)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel2.Size = New System.Drawing.Size(490, 44)
        Me.Panel2.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.lbl_pump)
        Me.Panel3.Controls.Add(Me.FlowLayoutPanel2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(2, 2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(486, 40)
        Me.Panel3.TabIndex = 91
        '
        'lbl_pump
        '
        Me.lbl_pump.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pump.Location = New System.Drawing.Point(3, 4)
        Me.lbl_pump.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lbl_pump.Name = "lbl_pump"
        Me.lbl_pump.Size = New System.Drawing.Size(50, 32)
        Me.lbl_pump.TabIndex = 82
        Me.lbl_pump.Text = "Pump"
        Me.lbl_pump.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.lbl_total_pump_watts)
        Me.FlowLayoutPanel2.Controls.Add(Me.txt_total_pump_watts)
        Me.FlowLayoutPanel2.Controls.Add(Me.lbl_pump_hp)
        Me.FlowLayoutPanel2.Controls.Add(Me.txt_pump_motor_hp)
        Me.FlowLayoutPanel2.Controls.Add(Me.lbl_pump_quantity)
        Me.FlowLayoutPanel2.Controls.Add(Me.txt_pump_quantity)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(53, 4)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(428, 32)
        Me.FlowLayoutPanel2.TabIndex = 89
        '
        'lbl_total_pump_watts
        '
        Me.lbl_total_pump_watts.AutoSize = True
        Me.lbl_total_pump_watts.Location = New System.Drawing.Point(3, 8)
        Me.lbl_total_pump_watts.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.lbl_total_pump_watts.Name = "lbl_total_pump_watts"
        Me.lbl_total_pump_watts.Size = New System.Drawing.Size(61, 13)
        Me.lbl_total_pump_watts.TabIndex = 80
        Me.lbl_total_pump_watts.Text = "Total watts"
        Me.lbl_total_pump_watts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_total_pump_watts
        '
        Me.txt_total_pump_watts.Location = New System.Drawing.Point(70, 5)
        Me.txt_total_pump_watts.Name = "txt_total_pump_watts"
        Me.txt_total_pump_watts.ReadOnly = True
        Me.txt_total_pump_watts.Size = New System.Drawing.Size(49, 21)
        Me.txt_total_pump_watts.TabIndex = 78
        Me.txt_total_pump_watts.TabStop = False
        '
        'lbl_pump_hp
        '
        Me.lbl_pump_hp.AutoSize = True
        Me.lbl_pump_hp.Location = New System.Drawing.Point(137, 8)
        Me.lbl_pump_hp.Margin = New System.Windows.Forms.Padding(15, 6, 3, 3)
        Me.lbl_pump_hp.Name = "lbl_pump_hp"
        Me.lbl_pump_hp.Size = New System.Drawing.Size(20, 13)
        Me.lbl_pump_hp.TabIndex = 88
        Me.lbl_pump_hp.Text = "HP"
        Me.lbl_pump_hp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_pump_motor_hp
        '
        Me.txt_pump_motor_hp.Location = New System.Drawing.Point(163, 5)
        Me.txt_pump_motor_hp.Name = "txt_pump_motor_hp"
        Me.txt_pump_motor_hp.ReadOnly = True
        Me.txt_pump_motor_hp.Size = New System.Drawing.Size(49, 21)
        Me.txt_pump_motor_hp.TabIndex = 1
        '
        'lbl_pump_quantity
        '
        Me.lbl_pump_quantity.AutoSize = True
        Me.lbl_pump_quantity.Location = New System.Drawing.Point(230, 8)
        Me.lbl_pump_quantity.Margin = New System.Windows.Forms.Padding(15, 6, 3, 3)
        Me.lbl_pump_quantity.Name = "lbl_pump_quantity"
        Me.lbl_pump_quantity.Size = New System.Drawing.Size(49, 13)
        Me.lbl_pump_quantity.TabIndex = 88
        Me.lbl_pump_quantity.Text = "Quantity"
        Me.lbl_pump_quantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_pump_quantity
        '
        Me.txt_pump_quantity.Location = New System.Drawing.Point(285, 5)
        Me.txt_pump_quantity.Name = "txt_pump_quantity"
        Me.txt_pump_quantity.ReadOnly = True
        Me.txt_pump_quantity.Size = New System.Drawing.Size(49, 21)
        Me.txt_pump_quantity.TabIndex = 86
        Me.txt_pump_quantity.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.pan_evaporative_condenser.SetFlowBreak(Me.Panel4, True)
        Me.Panel4.Location = New System.Drawing.Point(5, 147)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel4.Size = New System.Drawing.Size(490, 44)
        Me.Panel4.TabIndex = 5
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.Controls.Add(Me.lbl_fan)
        Me.Panel5.Controls.Add(Me.FlowLayoutPanel3)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(2, 2)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(486, 40)
        Me.Panel5.TabIndex = 91
        '
        'lbl_fan
        '
        Me.lbl_fan.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_fan.Location = New System.Drawing.Point(3, 4)
        Me.lbl_fan.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lbl_fan.Name = "lbl_fan"
        Me.lbl_fan.Size = New System.Drawing.Size(50, 32)
        Me.lbl_fan.TabIndex = 82
        Me.lbl_fan.Text = "Fan"
        Me.lbl_fan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Controls.Add(Me.lbl_total_fan_watts)
        Me.FlowLayoutPanel3.Controls.Add(Me.txt_total_fan_watts)
        Me.FlowLayoutPanel3.Controls.Add(Me.lbl_fan_hp)
        Me.FlowLayoutPanel3.Controls.Add(Me.txt_fan_motor_hp)
        Me.FlowLayoutPanel3.Controls.Add(Me.lbl_fan_quantity)
        Me.FlowLayoutPanel3.Controls.Add(Me.txt_fan_quantity)
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(53, 4)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(428, 32)
        Me.FlowLayoutPanel3.TabIndex = 89
        '
        'lbl_total_fan_watts
        '
        Me.lbl_total_fan_watts.AutoSize = True
        Me.lbl_total_fan_watts.Location = New System.Drawing.Point(3, 8)
        Me.lbl_total_fan_watts.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.lbl_total_fan_watts.Name = "lbl_total_fan_watts"
        Me.lbl_total_fan_watts.Size = New System.Drawing.Size(61, 13)
        Me.lbl_total_fan_watts.TabIndex = 80
        Me.lbl_total_fan_watts.Text = "Total watts"
        Me.lbl_total_fan_watts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_total_fan_watts
        '
        Me.txt_total_fan_watts.Location = New System.Drawing.Point(70, 5)
        Me.txt_total_fan_watts.Name = "txt_total_fan_watts"
        Me.txt_total_fan_watts.ReadOnly = True
        Me.txt_total_fan_watts.Size = New System.Drawing.Size(49, 21)
        Me.txt_total_fan_watts.TabIndex = 79
        Me.txt_total_fan_watts.TabStop = False
        '
        'lbl_fan_hp
        '
        Me.lbl_fan_hp.AutoSize = True
        Me.lbl_fan_hp.Location = New System.Drawing.Point(137, 8)
        Me.lbl_fan_hp.Margin = New System.Windows.Forms.Padding(15, 6, 3, 3)
        Me.lbl_fan_hp.Name = "lbl_fan_hp"
        Me.lbl_fan_hp.Size = New System.Drawing.Size(20, 13)
        Me.lbl_fan_hp.TabIndex = 88
        Me.lbl_fan_hp.Text = "HP"
        Me.lbl_fan_hp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_fan_motor_hp
        '
        Me.txt_fan_motor_hp.Location = New System.Drawing.Point(163, 5)
        Me.txt_fan_motor_hp.Name = "txt_fan_motor_hp"
        Me.txt_fan_motor_hp.ReadOnly = True
        Me.txt_fan_motor_hp.Size = New System.Drawing.Size(49, 21)
        Me.txt_fan_motor_hp.TabIndex = 1
        '
        'lbl_fan_quantity
        '
        Me.lbl_fan_quantity.AutoSize = True
        Me.lbl_fan_quantity.Location = New System.Drawing.Point(230, 8)
        Me.lbl_fan_quantity.Margin = New System.Windows.Forms.Padding(15, 6, 3, 3)
        Me.lbl_fan_quantity.Name = "lbl_fan_quantity"
        Me.lbl_fan_quantity.Size = New System.Drawing.Size(49, 13)
        Me.lbl_fan_quantity.TabIndex = 88
        Me.lbl_fan_quantity.Text = "Quantity"
        Me.lbl_fan_quantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_fan_quantity
        '
        Me.txt_fan_quantity.Location = New System.Drawing.Point(285, 5)
        Me.txt_fan_quantity.Name = "txt_fan_quantity"
        Me.txt_fan_quantity.ReadOnly = True
        Me.txt_fan_quantity.Size = New System.Drawing.Size(49, 21)
        Me.txt_fan_quantity.TabIndex = 87
        Me.txt_fan_quantity.TabStop = False
        '
        'lbl_discharge_loss
        '
        Me.lbl_discharge_loss.Location = New System.Drawing.Point(8, 196)
        Me.lbl_discharge_loss.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.lbl_discharge_loss.Name = "lbl_discharge_loss"
        Me.lbl_discharge_loss.Size = New System.Drawing.Size(109, 21)
        Me.lbl_discharge_loss.TabIndex = 74
        Me.lbl_discharge_loss.Text = "Discharge line loss"
        Me.lbl_discharge_loss.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbo_discharge_loss
        '
        Me.cbo_discharge_loss.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_discharge_loss.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"})
        Me.cbo_discharge_loss.Location = New System.Drawing.Point(123, 196)
        Me.cbo_discharge_loss.Name = "cbo_discharge_loss"
        Me.cbo_discharge_loss.Size = New System.Drawing.Size(72, 21)
        Me.cbo_discharge_loss.TabIndex = 7
        '
        'lbl_discharge_loss_F
        '
        Me.pan_evaporative_condenser.SetFlowBreak(Me.lbl_discharge_loss_F, True)
        Me.lbl_discharge_loss_F.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lbl_discharge_loss_F.Location = New System.Drawing.Point(201, 193)
        Me.lbl_discharge_loss_F.Name = "lbl_discharge_loss_F"
        Me.lbl_discharge_loss_F.Size = New System.Drawing.Size(28, 21)
        Me.lbl_discharge_loss_F.TabIndex = 76
        Me.lbl_discharge_loss_F.Text = "°F"
        Me.lbl_discharge_loss_F.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_suction_loss
        '
        Me.lbl_suction_loss.Location = New System.Drawing.Point(8, 223)
        Me.lbl_suction_loss.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.lbl_suction_loss.Name = "lbl_suction_loss"
        Me.lbl_suction_loss.Size = New System.Drawing.Size(109, 21)
        Me.lbl_suction_loss.TabIndex = 75
        Me.lbl_suction_loss.Text = "Suction line loss"
        Me.lbl_suction_loss.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbo_suction_loss
        '
        Me.cbo_suction_loss.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_suction_loss.Items.AddRange(New Object() {"0", "1", "2", "3", "4"})
        Me.cbo_suction_loss.Location = New System.Drawing.Point(123, 223)
        Me.cbo_suction_loss.Name = "cbo_suction_loss"
        Me.cbo_suction_loss.Size = New System.Drawing.Size(72, 21)
        Me.cbo_suction_loss.TabIndex = 8
        '
        'lbl_suction_loss_F
        '
        Me.pan_evaporative_condenser.SetFlowBreak(Me.lbl_suction_loss_F, True)
        Me.lbl_suction_loss_F.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lbl_suction_loss_F.Location = New System.Drawing.Point(201, 220)
        Me.lbl_suction_loss_F.Name = "lbl_suction_loss_F"
        Me.lbl_suction_loss_F.Size = New System.Drawing.Size(28, 21)
        Me.lbl_suction_loss_F.TabIndex = 77
        Me.lbl_suction_loss_F.Text = "°F"
        Me.lbl_suction_loss_F.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pan_options_content
        '
        Me.pan_options_content.Location = New System.Drawing.Point(6, 250)
        Me.pan_options_content.Name = "pan_options_content"
        Me.pan_options_content.Size = New System.Drawing.Size(492, 48)
        Me.pan_options_content.TabIndex = 9
        '
        'pan_compressor
        '
        Me.pan_compressor.AutoSize = True
        Me.pan_compressor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pan_compressor.BackColor = System.Drawing.Color.White
        Me.pan_compressor.Controls.Add(Me.FlowLayoutPanel1)
        Me.pan_compressor.Controls.Add(Me.Txt_circuit_per_unit)
        Me.pan_compressor.Dock = System.Windows.Forms.DockStyle.Top
        Me.pan_compressor.Location = New System.Drawing.Point(0, 355)
        Me.pan_compressor.Name = "pan_compressor"
        Me.pan_compressor.Size = New System.Drawing.Size(924, 207)
        Me.pan_compressor.TabIndex = 5
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel1)
        Me.FlowLayoutPanel1.Controls.Add(Me.chk_safety_override)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(5, 6)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(637, 198)
        Me.FlowLayoutPanel1.TabIndex = 9
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pan_compressor_2)
        Me.Panel1.Controls.Add(Me.pan_compressor_1)
        Me.FlowLayoutPanel1.SetFlowBreak(Me.Panel1, True)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(493, 160)
        Me.Panel1.TabIndex = 10
        '
        'pan_compressor_2
        '
        Me.pan_compressor_2.Controls.Add(Me.lblCompressor2)
        Me.pan_compressor_2.Controls.Add(Me.lblNumCompressors2)
        Me.pan_compressor_2.Controls.Add(Me.lbo_compressors_2)
        Me.pan_compressor_2.Controls.Add(Me.txt_compressor_2)
        Me.pan_compressor_2.Controls.Add(Me.txt_compressor_qty_2)
        Me.pan_compressor_2.Location = New System.Drawing.Point(257, 3)
        Me.pan_compressor_2.Name = "pan_compressor_2"
        Me.pan_compressor_2.Size = New System.Drawing.Size(228, 155)
        Me.pan_compressor_2.TabIndex = 9
        '
        'lblCompressor2
        '
        Me.lblCompressor2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompressor2.Location = New System.Drawing.Point(4, 6)
        Me.lblCompressor2.Name = "lblCompressor2"
        Me.lblCompressor2.Size = New System.Drawing.Size(76, 23)
        Me.lblCompressor2.TabIndex = 9
        Me.lblCompressor2.Text = "Compressor"
        Me.lblCompressor2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNumCompressors2
        '
        Me.lblNumCompressors2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumCompressors2.Location = New System.Drawing.Point(4, 34)
        Me.lblNumCompressors2.Name = "lblNumCompressors2"
        Me.lblNumCompressors2.Size = New System.Drawing.Size(76, 23)
        Me.lblNumCompressors2.TabIndex = 10
        Me.lblNumCompressors2.Text = "Quantity"
        Me.lblNumCompressors2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbo_compressors_2
        '
        Me.lbo_compressors_2.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbo_compressors_2.ItemHeight = 14
        Me.lbo_compressors_2.Location = New System.Drawing.Point(20, 62)
        Me.lbo_compressors_2.Name = "lbo_compressors_2"
        Me.lbo_compressors_2.Size = New System.Drawing.Size(196, 88)
        Me.lbo_compressors_2.TabIndex = 6
        '
        'txt_compressor_2
        '
        Me.txt_compressor_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_compressor_2.Location = New System.Drawing.Point(88, 6)
        Me.txt_compressor_2.Name = "txt_compressor_2"
        Me.txt_compressor_2.ReadOnly = True
        Me.txt_compressor_2.Size = New System.Drawing.Size(128, 21)
        Me.txt_compressor_2.TabIndex = 7
        '
        'txt_compressor_qty_2
        '
        Me.txt_compressor_qty_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_compressor_qty_2.Location = New System.Drawing.Point(88, 34)
        Me.txt_compressor_qty_2.Name = "txt_compressor_qty_2"
        Me.txt_compressor_qty_2.Size = New System.Drawing.Size(72, 21)
        Me.txt_compressor_qty_2.TabIndex = 5
        Me.txt_compressor_qty_2.Text = "1"
        '
        'pan_compressor_1
        '
        Me.pan_compressor_1.BackColor = System.Drawing.Color.White
        Me.pan_compressor_1.Controls.Add(Me.lblNumCompressors1)
        Me.pan_compressor_1.Controls.Add(Me.txt_compressor_qty_1)
        Me.pan_compressor_1.Controls.Add(Me.txt_compressor_1)
        Me.pan_compressor_1.Controls.Add(Me.lblCompressor1)
        Me.pan_compressor_1.Controls.Add(Me.lbo_compressors_1)
        Me.pan_compressor_1.Location = New System.Drawing.Point(5, 3)
        Me.pan_compressor_1.Name = "pan_compressor_1"
        Me.pan_compressor_1.Size = New System.Drawing.Size(247, 155)
        Me.pan_compressor_1.TabIndex = 8
        '
        'lblNumCompressors1
        '
        Me.lblNumCompressors1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumCompressors1.Location = New System.Drawing.Point(3, 34)
        Me.lblNumCompressors1.Name = "lblNumCompressors1"
        Me.lblNumCompressors1.Size = New System.Drawing.Size(76, 23)
        Me.lblNumCompressors1.TabIndex = 6
        Me.lblNumCompressors1.Text = "Quantity"
        Me.lblNumCompressors1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_compressor_qty_1
        '
        Me.txt_compressor_qty_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_compressor_qty_1.Location = New System.Drawing.Point(87, 34)
        Me.txt_compressor_qty_1.Name = "txt_compressor_qty_1"
        Me.txt_compressor_qty_1.Size = New System.Drawing.Size(72, 21)
        Me.txt_compressor_qty_1.TabIndex = 3
        Me.txt_compressor_qty_1.Text = "1"
        '
        'txt_compressor_1
        '
        Me.txt_compressor_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_compressor_1.Location = New System.Drawing.Point(87, 6)
        Me.txt_compressor_1.Name = "txt_compressor_1"
        Me.txt_compressor_1.ReadOnly = True
        Me.txt_compressor_1.Size = New System.Drawing.Size(128, 21)
        Me.txt_compressor_1.TabIndex = 3
        Me.txt_compressor_1.TabStop = False
        '
        'lblCompressor1
        '
        Me.lblCompressor1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompressor1.Location = New System.Drawing.Point(3, 6)
        Me.lblCompressor1.Name = "lblCompressor1"
        Me.lblCompressor1.Size = New System.Drawing.Size(78, 23)
        Me.lblCompressor1.TabIndex = 3
        Me.lblCompressor1.Text = "Compressor"
        Me.lblCompressor1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbo_compressors_1
        '
        Me.lbo_compressors_1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbo_compressors_1.ItemHeight = 14
        Me.lbo_compressors_1.Location = New System.Drawing.Point(19, 62)
        Me.lbo_compressors_1.Name = "lbo_compressors_1"
        Me.lbo_compressors_1.Size = New System.Drawing.Size(196, 88)
        Me.lbo_compressors_1.TabIndex = 4
        Me.lbo_compressors_1.Tag = ""
        '
        'chk_safety_override
        '
        Me.chk_safety_override.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.FlowLayoutPanel1.SetFlowBreak(Me.chk_safety_override, True)
        Me.chk_safety_override.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_safety_override.Location = New System.Drawing.Point(26, 169)
        Me.chk_safety_override.Margin = New System.Windows.Forms.Padding(26, 3, 3, 3)
        Me.chk_safety_override.Name = "chk_safety_override"
        Me.chk_safety_override.Size = New System.Drawing.Size(109, 26)
        Me.chk_safety_override.TabIndex = 1
        Me.chk_safety_override.Text = "Safety override"
        '
        'Txt_circuit_per_unit
        '
        Me.Txt_circuit_per_unit.BackColor = System.Drawing.SystemColors.Info
        Me.Txt_circuit_per_unit.Location = New System.Drawing.Point(772, 45)
        Me.Txt_circuit_per_unit.Name = "Txt_circuit_per_unit"
        Me.Txt_circuit_per_unit.Size = New System.Drawing.Size(100, 21)
        Me.Txt_circuit_per_unit.TabIndex = 4
        Me.Txt_circuit_per_unit.Visible = False
        '
        'pan_rating_criteria
        '
        Me.pan_rating_criteria.BackColor = System.Drawing.Color.White
        Me.pan_rating_criteria.Controls.Add(Me.panRatingCriteria)
        Me.pan_rating_criteria.Dock = System.Windows.Forms.DockStyle.Top
        Me.pan_rating_criteria.Location = New System.Drawing.Point(0, 116)
        Me.pan_rating_criteria.Name = "pan_rating_criteria"
        Me.pan_rating_criteria.Size = New System.Drawing.Size(924, 239)
        Me.pan_rating_criteria.TabIndex = 3
        '
        'panRatingCriteria
        '
        Me.panRatingCriteria.BackColor = System.Drawing.Color.White
        Me.panRatingCriteria.Controls.Add(Me.lbl_altitude_feet)
        Me.panRatingCriteria.Controls.Add(Me.lblAltitudeFt)
        Me.panRatingCriteria.Controls.Add(Me.lblAltitude)
        Me.panRatingCriteria.Controls.Add(Me.txt_altitude)
        Me.panRatingCriteria.Controls.Add(Me.pan_range)
        Me.panRatingCriteria.Controls.Add(Me.lbl_range_f)
        Me.panRatingCriteria.Controls.Add(Me.lblAmbientF)
        Me.panRatingCriteria.Controls.Add(Me.lblRatiVolt)
        Me.panRatingCriteria.Controls.Add(Me.cbo_hertz)
        Me.panRatingCriteria.Controls.Add(Me.lblLeavingFluidF)
        Me.panRatingCriteria.Controls.Add(Me.lbl_subcooling_f)
        Me.panRatingCriteria.Controls.Add(Me.lbl_freeze_point_f)
        Me.panRatingCriteria.Controls.Add(Me.lbl_voltage)
        Me.panRatingCriteria.Controls.Add(Me.cbo_voltage)
        Me.panRatingCriteria.Controls.Add(Me.lbl_min_suction_f)
        Me.panRatingCriteria.Controls.Add(Me.lblHertz)
        Me.panRatingCriteria.Controls.Add(Me.btn_glycol_chart)
        Me.panRatingCriteria.Controls.Add(Me.txt_approach)
        Me.panRatingCriteria.Controls.Add(Me.lbl_approach)
        Me.panRatingCriteria.Controls.Add(Me.txt_freeze_point)
        Me.panRatingCriteria.Controls.Add(Me.lbl_freeze_point)
        Me.panRatingCriteria.Controls.Add(Me.lbl_specific_gravity)
        Me.panRatingCriteria.Controls.Add(Me.lbl_specific_heat)
        Me.panRatingCriteria.Controls.Add(Me.txt_specific_gravity)
        Me.panRatingCriteria.Controls.Add(Me.txt_specific_heat)
        Me.panRatingCriteria.Controls.Add(Me.txt_glycol_percentage)
        Me.panRatingCriteria.Controls.Add(Me.lblGlycolPercentage)
        Me.panRatingCriteria.Controls.Add(Me.cbo_fluid)
        Me.panRatingCriteria.Controls.Add(Me.lblFluid)
        Me.panRatingCriteria.Controls.Add(Me.cbo_glycol)
        Me.panRatingCriteria.Controls.Add(Me.lbl_glycol)
        Me.panRatingCriteria.Controls.Add(Me.txt_min_suction)
        Me.panRatingCriteria.Controls.Add(Me.lbl_min_suction)
        Me.panRatingCriteria.Controls.Add(Me.txt_subcooling)
        Me.panRatingCriteria.Controls.Add(Me.lbl_subcooling)
        Me.panRatingCriteria.Controls.Add(Me.txt_leaving_fluid_temp)
        Me.panRatingCriteria.Controls.Add(Me.lbl_leaving_fluid_temp)
        Me.panRatingCriteria.Controls.Add(Me.lbl_ambient)
        Me.panRatingCriteria.Controls.Add(Me.txt_ambient)
        Me.panRatingCriteria.Controls.Add(Me.lbl_range)
        Me.panRatingCriteria.Controls.Add(Me.txt_range)
        Me.panRatingCriteria.Controls.Add(Me.lbl_refrigerant)
        Me.panRatingCriteria.Controls.Add(Me.cbo_refrigerant)
        Me.panRatingCriteria.Location = New System.Drawing.Point(12, 3)
        Me.panRatingCriteria.Name = "panRatingCriteria"
        Me.panRatingCriteria.Size = New System.Drawing.Size(680, 232)
        Me.panRatingCriteria.TabIndex = 1
        '
        'lbl_altitude_feet
        '
        Me.lbl_altitude_feet.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lbl_altitude_feet.Location = New System.Drawing.Point(173, 175)
        Me.lbl_altitude_feet.Name = "lbl_altitude_feet"
        Me.lbl_altitude_feet.Size = New System.Drawing.Size(28, 21)
        Me.lbl_altitude_feet.TabIndex = 67
        Me.lbl_altitude_feet.Text = "ft"
        Me.lbl_altitude_feet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAltitudeFt
        '
        Me.lblAltitudeFt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblAltitudeFt.Location = New System.Drawing.Point(5, 198)
        Me.lblAltitudeFt.Name = "lblAltitudeFt"
        Me.lblAltitudeFt.Size = New System.Drawing.Size(288, 19)
        Me.lblAltitudeFt.TabIndex = 66
        Me.lblAltitudeFt.Text = "Consult factory for applications above 5000 ft"
        Me.lblAltitudeFt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAltitude
        '
        Me.lblAltitude.Location = New System.Drawing.Point(4, 175)
        Me.lblAltitude.Name = "lblAltitude"
        Me.lblAltitude.Size = New System.Drawing.Size(86, 23)
        Me.lblAltitude.TabIndex = 65
        Me.lblAltitude.Text = "Altitude"
        Me.lblAltitude.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_altitude
        '
        Me.txt_altitude.Location = New System.Drawing.Point(97, 175)
        Me.txt_altitude.Name = "txt_altitude"
        Me.txt_altitude.Size = New System.Drawing.Size(72, 21)
        Me.txt_altitude.TabIndex = 12
        Me.txt_altitude.Text = "0"
        '
        'pan_range
        '
        Me.pan_range.Controls.Add(Me.lblAmbientStep)
        Me.pan_range.Controls.Add(Me.lblTE)
        Me.pan_range.Controls.Add(Me.txtATIncrement)
        Me.pan_range.Controls.Add(Me.txtLeavingFluidTemperatureLowerVariance)
        Me.pan_range.Controls.Add(Me.txtLeavingFluidTemperatureUpperVariance)
        Me.pan_range.Controls.Add(Me.Label6)
        Me.pan_range.Controls.Add(Me.txtLeavingFluidTemperatureStep)
        Me.pan_range.Controls.Add(Me.Label1)
        Me.pan_range.Controls.Add(Me.txtATMax)
        Me.pan_range.Controls.Add(Me.Label2)
        Me.pan_range.Controls.Add(Me.lblLeavingFluidTemperatureStep)
        Me.pan_range.Controls.Add(Me.Label5)
        Me.pan_range.Controls.Add(Me.Label4)
        Me.pan_range.Controls.Add(Me.txtATMin)
        Me.pan_range.Location = New System.Drawing.Point(550, 2)
        Me.pan_range.Name = "pan_range"
        Me.pan_range.Size = New System.Drawing.Size(120, 228)
        Me.pan_range.TabIndex = 28
        '
        'lblAmbientStep
        '
        Me.lblAmbientStep.Location = New System.Drawing.Point(28, 199)
        Me.lblAmbientStep.Name = "lblAmbientStep"
        Me.lblAmbientStep.Size = New System.Drawing.Size(36, 21)
        Me.lblAmbientStep.TabIndex = 44
        Me.lblAmbientStep.Text = "Step"
        Me.lblAmbientStep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTE
        '
        Me.lblTE.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTE.Location = New System.Drawing.Point(3, 3)
        Me.lblTE.Name = "lblTE"
        Me.lblTE.Size = New System.Drawing.Size(116, 21)
        Me.lblTE.TabIndex = 34
        Me.lblTE.Text = "Leaving Fluid Range"
        Me.lblTE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtATIncrement
        '
        Me.txtATIncrement.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtATIncrement.Location = New System.Drawing.Point(70, 199)
        Me.txtATIncrement.Name = "txtATIncrement"
        Me.txtATIncrement.Size = New System.Drawing.Size(42, 21)
        Me.txtATIncrement.TabIndex = 12
        Me.txtATIncrement.Text = "4"
        '
        'txtLeavingFluidTemperatureLowerVariance
        '
        Me.txtLeavingFluidTemperatureLowerVariance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLeavingFluidTemperatureLowerVariance.Location = New System.Drawing.Point(70, 30)
        Me.txtLeavingFluidTemperatureLowerVariance.Name = "txtLeavingFluidTemperatureLowerVariance"
        Me.txtLeavingFluidTemperatureLowerVariance.Size = New System.Drawing.Size(42, 21)
        Me.txtLeavingFluidTemperatureLowerVariance.TabIndex = 1
        Me.txtLeavingFluidTemperatureLowerVariance.Text = "4"
        '
        'txtLeavingFluidTemperatureUpperVariance
        '
        Me.txtLeavingFluidTemperatureUpperVariance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLeavingFluidTemperatureUpperVariance.Location = New System.Drawing.Point(70, 57)
        Me.txtLeavingFluidTemperatureUpperVariance.Name = "txtLeavingFluidTemperatureUpperVariance"
        Me.txtLeavingFluidTemperatureUpperVariance.Size = New System.Drawing.Size(42, 21)
        Me.txtLeavingFluidTemperatureUpperVariance.TabIndex = 2
        Me.txtLeavingFluidTemperatureUpperVariance.Text = "4"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(28, 172)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 21)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "Max"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLeavingFluidTemperatureStep
        '
        Me.txtLeavingFluidTemperatureStep.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLeavingFluidTemperatureStep.Location = New System.Drawing.Point(70, 84)
        Me.txtLeavingFluidTemperatureStep.Name = "txtLeavingFluidTemperatureStep"
        Me.txtLeavingFluidTemperatureStep.Size = New System.Drawing.Size(42, 21)
        Me.txtLeavingFluidTemperatureStep.TabIndex = 3
        Me.txtLeavingFluidTemperatureStep.Text = "2"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(31, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 21)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Min"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtATMax
        '
        Me.txtATMax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtATMax.Location = New System.Drawing.Point(70, 172)
        Me.txtATMax.Name = "txtATMax"
        Me.txtATMax.Size = New System.Drawing.Size(42, 21)
        Me.txtATMax.TabIndex = 11
        Me.txtATMax.Text = "4"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(31, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 21)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Max"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLeavingFluidTemperatureStep
        '
        Me.lblLeavingFluidTemperatureStep.Location = New System.Drawing.Point(31, 84)
        Me.lblLeavingFluidTemperatureStep.Name = "lblLeavingFluidTemperatureStep"
        Me.lblLeavingFluidTemperatureStep.Size = New System.Drawing.Size(33, 21)
        Me.lblLeavingFluidTemperatureStep.TabIndex = 37
        Me.lblLeavingFluidTemperatureStep.Text = "Step"
        Me.lblLeavingFluidTemperatureStep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(28, 145)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 21)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Min"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 21)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Ambient Range"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtATMin
        '
        Me.txtATMin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtATMin.Location = New System.Drawing.Point(70, 145)
        Me.txtATMin.Name = "txtATMin"
        Me.txtATMin.Size = New System.Drawing.Size(42, 21)
        Me.txtATMin.TabIndex = 10
        Me.txtATMin.Text = "4"
        '
        'lbl_range_f
        '
        Me.lbl_range_f.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lbl_range_f.Location = New System.Drawing.Point(470, 144)
        Me.lbl_range_f.Name = "lbl_range_f"
        Me.lbl_range_f.Size = New System.Drawing.Size(64, 21)
        Me.lbl_range_f.TabIndex = 40
        Me.lbl_range_f.Text = "5 to 20°F"
        Me.lbl_range_f.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAmbientF
        '
        Me.lblAmbientF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblAmbientF.Location = New System.Drawing.Point(470, 35)
        Me.lblAmbientF.Name = "lblAmbientF"
        Me.lblAmbientF.Size = New System.Drawing.Size(85, 21)
        Me.lblAmbientF.TabIndex = 39
        Me.lblAmbientF.Text = "°F (wet bulb)"
        Me.lblAmbientF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRatiVolt
        '
        Me.lblRatiVolt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblRatiVolt.Location = New System.Drawing.Point(470, 88)
        Me.lblRatiVolt.Name = "lblRatiVolt"
        Me.lblRatiVolt.Size = New System.Drawing.Size(74, 21)
        Me.lblRatiVolt.TabIndex = 29
        Me.lblRatiVolt.Text = "380 Volts"
        Me.lblRatiVolt.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.lblRatiVolt.Visible = False
        '
        'cbo_hertz
        '
        Me.cbo_hertz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_hertz.Items.AddRange(New Object() {"60", "50"})
        Me.cbo_hertz.Location = New System.Drawing.Point(394, 117)
        Me.cbo_hertz.Name = "cbo_hertz"
        Me.cbo_hertz.Size = New System.Drawing.Size(72, 21)
        Me.cbo_hertz.TabIndex = 20
        '
        'lblLeavingFluidF
        '
        Me.lblLeavingFluidF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblLeavingFluidF.Location = New System.Drawing.Point(470, 63)
        Me.lblLeavingFluidF.Name = "lblLeavingFluidF"
        Me.lblLeavingFluidF.Size = New System.Drawing.Size(64, 21)
        Me.lblLeavingFluidF.TabIndex = 38
        Me.lblLeavingFluidF.Text = "-40 to 75°F"
        Me.lblLeavingFluidF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_subcooling_f
        '
        Me.lbl_subcooling_f.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lbl_subcooling_f.Location = New System.Drawing.Point(470, 198)
        Me.lbl_subcooling_f.Name = "lbl_subcooling_f"
        Me.lbl_subcooling_f.Size = New System.Drawing.Size(28, 21)
        Me.lbl_subcooling_f.TabIndex = 37
        Me.lbl_subcooling_f.Text = "°F"
        Me.lbl_subcooling_f.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_freeze_point_f
        '
        Me.lbl_freeze_point_f.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lbl_freeze_point_f.Location = New System.Drawing.Point(173, 120)
        Me.lbl_freeze_point_f.Name = "lbl_freeze_point_f"
        Me.lbl_freeze_point_f.Size = New System.Drawing.Size(28, 21)
        Me.lbl_freeze_point_f.TabIndex = 36
        Me.lbl_freeze_point_f.Text = "°F"
        Me.lbl_freeze_point_f.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_voltage
        '
        Me.lbl_voltage.Location = New System.Drawing.Point(311, 90)
        Me.lbl_voltage.Name = "lbl_voltage"
        Me.lbl_voltage.Size = New System.Drawing.Size(80, 21)
        Me.lbl_voltage.TabIndex = 30
        Me.lbl_voltage.Text = "Voltage"
        Me.lbl_voltage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbo_voltage
        '
        Me.cbo_voltage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_voltage.Items.AddRange(New Object() {"460"})
        Me.cbo_voltage.Location = New System.Drawing.Point(394, 90)
        Me.cbo_voltage.Name = "cbo_voltage"
        Me.cbo_voltage.Size = New System.Drawing.Size(72, 21)
        Me.cbo_voltage.TabIndex = 18
        '
        'lbl_min_suction_f
        '
        Me.lbl_min_suction_f.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lbl_min_suction_f.Location = New System.Drawing.Point(173, 148)
        Me.lbl_min_suction_f.Name = "lbl_min_suction_f"
        Me.lbl_min_suction_f.Size = New System.Drawing.Size(28, 21)
        Me.lbl_min_suction_f.TabIndex = 35
        Me.lbl_min_suction_f.Text = "°F"
        Me.lbl_min_suction_f.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHertz
        '
        Me.lblHertz.Location = New System.Drawing.Point(311, 118)
        Me.lblHertz.Name = "lblHertz"
        Me.lblHertz.Size = New System.Drawing.Size(80, 21)
        Me.lblHertz.TabIndex = 27
        Me.lblHertz.Text = "Hertz"
        Me.lblHertz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_glycol_chart
        '
        Me.btn_glycol_chart.BackColor = System.Drawing.SystemColors.Control
        Me.btn_glycol_chart.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_glycol_chart.Location = New System.Drawing.Point(173, 35)
        Me.btn_glycol_chart.Name = "btn_glycol_chart"
        Me.btn_glycol_chart.Size = New System.Drawing.Size(74, 23)
        Me.btn_glycol_chart.TabIndex = 4
        Me.btn_glycol_chart.Text = "Glycol Chart"
        Me.btn_glycol_chart.UseVisualStyleBackColor = False
        Me.btn_glycol_chart.Visible = False
        '
        'txt_approach
        '
        Me.txt_approach.Location = New System.Drawing.Point(394, 171)
        Me.txt_approach.Name = "txt_approach"
        Me.txt_approach.ReadOnly = True
        Me.txt_approach.Size = New System.Drawing.Size(72, 21)
        Me.txt_approach.TabIndex = 24
        Me.txt_approach.TabStop = False
        '
        'lbl_approach
        '
        Me.lbl_approach.Location = New System.Drawing.Point(311, 173)
        Me.lbl_approach.Name = "lbl_approach"
        Me.lbl_approach.Size = New System.Drawing.Size(80, 21)
        Me.lbl_approach.TabIndex = 31
        Me.lbl_approach.Text = "Approach"
        Me.lbl_approach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_freeze_point
        '
        Me.txt_freeze_point.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_freeze_point.Location = New System.Drawing.Point(97, 120)
        Me.txt_freeze_point.Name = "txt_freeze_point"
        Me.txt_freeze_point.ReadOnly = True
        Me.txt_freeze_point.Size = New System.Drawing.Size(72, 21)
        Me.txt_freeze_point.TabIndex = 8
        Me.txt_freeze_point.TabStop = False
        Me.txt_freeze_point.Text = "32"
        '
        'lbl_freeze_point
        '
        Me.lbl_freeze_point.Location = New System.Drawing.Point(6, 120)
        Me.lbl_freeze_point.Name = "lbl_freeze_point"
        Me.lbl_freeze_point.Size = New System.Drawing.Size(88, 21)
        Me.lbl_freeze_point.TabIndex = 22
        Me.lbl_freeze_point.Text = "Freeze point"
        Me.lbl_freeze_point.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_specific_gravity
        '
        Me.lbl_specific_gravity.Location = New System.Drawing.Point(6, 92)
        Me.lbl_specific_gravity.Name = "lbl_specific_gravity"
        Me.lbl_specific_gravity.Size = New System.Drawing.Size(88, 21)
        Me.lbl_specific_gravity.TabIndex = 21
        Me.lbl_specific_gravity.Text = "Specific gravity"
        Me.lbl_specific_gravity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_specific_heat
        '
        Me.lbl_specific_heat.Location = New System.Drawing.Point(6, 64)
        Me.lbl_specific_heat.Name = "lbl_specific_heat"
        Me.lbl_specific_heat.Size = New System.Drawing.Size(88, 21)
        Me.lbl_specific_heat.TabIndex = 20
        Me.lbl_specific_heat.Text = "Specific heat"
        Me.lbl_specific_heat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_specific_gravity
        '
        Me.txt_specific_gravity.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_specific_gravity.Location = New System.Drawing.Point(97, 92)
        Me.txt_specific_gravity.Name = "txt_specific_gravity"
        Me.txt_specific_gravity.ReadOnly = True
        Me.txt_specific_gravity.Size = New System.Drawing.Size(72, 21)
        Me.txt_specific_gravity.TabIndex = 6
        Me.txt_specific_gravity.Text = "0"
        '
        'txt_specific_heat
        '
        Me.txt_specific_heat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_specific_heat.Location = New System.Drawing.Point(97, 64)
        Me.txt_specific_heat.Name = "txt_specific_heat"
        Me.txt_specific_heat.ReadOnly = True
        Me.txt_specific_heat.Size = New System.Drawing.Size(72, 21)
        Me.txt_specific_heat.TabIndex = 5
        Me.txt_specific_heat.Text = "0"
        '
        'txt_glycol_percentage
        '
        Me.txt_glycol_percentage.Enabled = False
        Me.txt_glycol_percentage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_glycol_percentage.Location = New System.Drawing.Point(173, 8)
        Me.txt_glycol_percentage.Name = "txt_glycol_percentage"
        Me.txt_glycol_percentage.Size = New System.Drawing.Size(36, 21)
        Me.txt_glycol_percentage.TabIndex = 2
        Me.txt_glycol_percentage.Text = "0"
        Me.ToolTip1.SetToolTip(Me.txt_glycol_percentage, "Range 0-60")
        '
        'lblGlycolPercentage
        '
        Me.lblGlycolPercentage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblGlycolPercentage.Location = New System.Drawing.Point(213, 8)
        Me.lblGlycolPercentage.Name = "lblGlycolPercentage"
        Me.lblGlycolPercentage.Size = New System.Drawing.Size(52, 21)
        Me.lblGlycolPercentage.TabIndex = 16
        Me.lblGlycolPercentage.Text = "% Glycol"
        Me.lblGlycolPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbo_fluid
        '
        Me.cbo_fluid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_fluid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_fluid.Items.AddRange(New Object() {"Water", "Glycol"})
        Me.cbo_fluid.Location = New System.Drawing.Point(97, 8)
        Me.cbo_fluid.Name = "cbo_fluid"
        Me.cbo_fluid.Size = New System.Drawing.Size(72, 21)
        Me.cbo_fluid.TabIndex = 1
        '
        'lblFluid
        '
        Me.lblFluid.Location = New System.Drawing.Point(6, 8)
        Me.lblFluid.Name = "lblFluid"
        Me.lblFluid.Size = New System.Drawing.Size(88, 21)
        Me.lblFluid.TabIndex = 14
        Me.lblFluid.Text = "Fluid"
        Me.lblFluid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbo_glycol
        '
        Me.cbo_glycol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_glycol.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_glycol.Items.AddRange(New Object() {"Ethylene", "Propylene"})
        Me.cbo_glycol.Location = New System.Drawing.Point(97, 36)
        Me.cbo_glycol.Name = "cbo_glycol"
        Me.cbo_glycol.Size = New System.Drawing.Size(72, 21)
        Me.cbo_glycol.TabIndex = 3
        '
        'lbl_glycol
        '
        Me.lbl_glycol.Location = New System.Drawing.Point(6, 36)
        Me.lbl_glycol.Name = "lbl_glycol"
        Me.lbl_glycol.Size = New System.Drawing.Size(88, 21)
        Me.lbl_glycol.TabIndex = 12
        Me.lbl_glycol.Text = "Glycol"
        Me.lbl_glycol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_min_suction
        '
        Me.txt_min_suction.Location = New System.Drawing.Point(97, 148)
        Me.txt_min_suction.Name = "txt_min_suction"
        Me.txt_min_suction.ReadOnly = True
        Me.txt_min_suction.Size = New System.Drawing.Size(72, 21)
        Me.txt_min_suction.TabIndex = 10
        Me.txt_min_suction.TabStop = False
        Me.txt_min_suction.Text = "33"
        '
        'lbl_min_suction
        '
        Me.lbl_min_suction.Location = New System.Drawing.Point(6, 148)
        Me.lbl_min_suction.Name = "lbl_min_suction"
        Me.lbl_min_suction.Size = New System.Drawing.Size(88, 21)
        Me.lbl_min_suction.TabIndex = 10
        Me.lbl_min_suction.Text = "Minimum suction"
        Me.lbl_min_suction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_subcooling
        '
        Me.txt_subcooling.Location = New System.Drawing.Point(394, 198)
        Me.txt_subcooling.Name = "txt_subcooling"
        Me.txt_subcooling.Size = New System.Drawing.Size(72, 21)
        Me.txt_subcooling.TabIndex = 26
        Me.txt_subcooling.TabStop = False
        Me.txt_subcooling.Text = "5"
        '
        'lbl_subcooling
        '
        Me.lbl_subcooling.Location = New System.Drawing.Point(311, 198)
        Me.lbl_subcooling.Name = "lbl_subcooling"
        Me.lbl_subcooling.Size = New System.Drawing.Size(80, 21)
        Me.lbl_subcooling.TabIndex = 8
        Me.lbl_subcooling.Text = "Sub cooling"
        Me.lbl_subcooling.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_leaving_fluid_temp
        '
        Me.txt_leaving_fluid_temp.Location = New System.Drawing.Point(394, 63)
        Me.txt_leaving_fluid_temp.Name = "txt_leaving_fluid_temp"
        Me.txt_leaving_fluid_temp.Size = New System.Drawing.Size(72, 21)
        Me.txt_leaving_fluid_temp.TabIndex = 16
        Me.txt_leaving_fluid_temp.Text = "44"
        Me.ToolTip1.SetToolTip(Me.txt_leaving_fluid_temp, "Leaving fluid temperature, range -40°F to 75°F")
        '
        'lbl_leaving_fluid_temp
        '
        Me.lbl_leaving_fluid_temp.Location = New System.Drawing.Point(311, 63)
        Me.lbl_leaving_fluid_temp.Name = "lbl_leaving_fluid_temp"
        Me.lbl_leaving_fluid_temp.Size = New System.Drawing.Size(80, 21)
        Me.lbl_leaving_fluid_temp.TabIndex = 6
        Me.lbl_leaving_fluid_temp.Text = "Leaving fluid"
        Me.lbl_leaving_fluid_temp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_ambient
        '
        Me.lbl_ambient.Location = New System.Drawing.Point(311, 35)
        Me.lbl_ambient.Name = "lbl_ambient"
        Me.lbl_ambient.Size = New System.Drawing.Size(80, 21)
        Me.lbl_ambient.TabIndex = 5
        Me.lbl_ambient.Text = "Ambient"
        Me.lbl_ambient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_ambient
        '
        Me.txt_ambient.Location = New System.Drawing.Point(394, 35)
        Me.txt_ambient.Name = "txt_ambient"
        Me.txt_ambient.Size = New System.Drawing.Size(72, 21)
        Me.txt_ambient.TabIndex = 15
        Me.txt_ambient.Text = "75"
        '
        'lbl_range
        '
        Me.lbl_range.Location = New System.Drawing.Point(311, 145)
        Me.lbl_range.Name = "lbl_range"
        Me.lbl_range.Size = New System.Drawing.Size(80, 21)
        Me.lbl_range.TabIndex = 3
        Me.lbl_range.Text = "Range"
        Me.lbl_range.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_range
        '
        Me.txt_range.Location = New System.Drawing.Point(394, 144)
        Me.txt_range.Name = "txt_range"
        Me.txt_range.Size = New System.Drawing.Size(72, 21)
        Me.txt_range.TabIndex = 22
        Me.txt_range.Text = "10"
        '
        'lbl_refrigerant
        '
        Me.lbl_refrigerant.Location = New System.Drawing.Point(311, 8)
        Me.lbl_refrigerant.Name = "lbl_refrigerant"
        Me.lbl_refrigerant.Size = New System.Drawing.Size(80, 21)
        Me.lbl_refrigerant.TabIndex = 1
        Me.lbl_refrigerant.Text = "Refrigerant"
        Me.lbl_refrigerant.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbo_refrigerant
        '
        Me.cbo_refrigerant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_refrigerant.ItemHeight = 13
        Me.cbo_refrigerant.Location = New System.Drawing.Point(394, 8)
        Me.cbo_refrigerant.Name = "cbo_refrigerant"
        Me.cbo_refrigerant.Size = New System.Drawing.Size(72, 21)
        Me.cbo_refrigerant.TabIndex = 7
        '
        'pan_factors
        '
        Me.pan_factors.Controls.Add(Me.txt_compressor_capacity_factor)
        Me.pan_factors.Controls.Add(Me.txt_condenser_capacity_factor)
        Me.pan_factors.Controls.Add(Me.txt_compressor_amp_factor)
        Me.pan_factors.Controls.Add(Me.compressorAmpFactorLabel)
        Me.pan_factors.Controls.Add(Me.condenserCapacityFactorLabel)
        Me.pan_factors.Controls.Add(Me.Label10)
        Me.pan_factors.Controls.Add(Me.capacityFactorLabel)
        Me.pan_factors.Controls.Add(Me.GroupBox1)
        Me.pan_factors.Dock = System.Windows.Forms.DockStyle.Top
        Me.pan_factors.Location = New System.Drawing.Point(0, 58)
        Me.pan_factors.Name = "pan_factors"
        Me.pan_factors.Size = New System.Drawing.Size(924, 58)
        Me.pan_factors.TabIndex = 12
        Me.pan_factors.Visible = False
        '
        'txt_compressor_capacity_factor
        '
        Me.txt_compressor_capacity_factor.Location = New System.Drawing.Point(108, 29)
        Me.txt_compressor_capacity_factor.Name = "txt_compressor_capacity_factor"
        Me.txt_compressor_capacity_factor.Size = New System.Drawing.Size(37, 21)
        Me.txt_compressor_capacity_factor.TabIndex = 1
        Me.txt_compressor_capacity_factor.Text = "1"
        '
        'txt_condenser_capacity_factor
        '
        Me.txt_condenser_capacity_factor.Location = New System.Drawing.Point(305, 29)
        Me.txt_condenser_capacity_factor.Name = "txt_condenser_capacity_factor"
        Me.txt_condenser_capacity_factor.Size = New System.Drawing.Size(37, 21)
        Me.txt_condenser_capacity_factor.TabIndex = 2
        Me.txt_condenser_capacity_factor.Text = "1"
        '
        'txt_compressor_amp_factor
        '
        Me.txt_compressor_amp_factor.Location = New System.Drawing.Point(502, 29)
        Me.txt_compressor_amp_factor.Name = "txt_compressor_amp_factor"
        Me.txt_compressor_amp_factor.Size = New System.Drawing.Size(37, 21)
        Me.txt_compressor_amp_factor.TabIndex = 3
        Me.txt_compressor_amp_factor.Text = "1"
        '
        'compressorAmpFactorLabel
        '
        Me.compressorAmpFactorLabel.Location = New System.Drawing.Point(387, 29)
        Me.compressorAmpFactorLabel.Name = "compressorAmpFactorLabel"
        Me.compressorAmpFactorLabel.Size = New System.Drawing.Size(109, 21)
        Me.compressorAmpFactorLabel.TabIndex = 17
        Me.compressorAmpFactorLabel.Text = "Compressor amps"
        Me.compressorAmpFactorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'condenserCapacityFactorLabel
        '
        Me.condenserCapacityFactorLabel.Location = New System.Drawing.Point(190, 29)
        Me.condenserCapacityFactorLabel.Name = "condenserCapacityFactorLabel"
        Me.condenserCapacityFactorLabel.Size = New System.Drawing.Size(109, 21)
        Me.condenserCapacityFactorLabel.TabIndex = 19
        Me.condenserCapacityFactorLabel.Text = "Condenser Est. Capacity"
        Me.condenserCapacityFactorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(46, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(119, 21)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Correction factors"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'capacityFactorLabel
        '
        Me.capacityFactorLabel.Location = New System.Drawing.Point(47, 29)
        Me.capacityFactorLabel.Name = "capacityFactorLabel"
        Me.capacityFactorLabel.Size = New System.Drawing.Size(109, 21)
        Me.capacityFactorLabel.TabIndex = 13
        Me.capacityFactorLabel.Text = "Est. Capacity"
        Me.capacityFactorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(0, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(924, 247)
        Me.GroupBox1.TabIndex = 68
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rating Criteria"
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(120, 21)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(693, 252)
        Me.DataGridView1.TabIndex = 9
        '
        'DataGridView2
        '
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(120, 21)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.Size = New System.Drawing.Size(693, 252)
        Me.DataGridView2.TabIndex = 9
        '
        'pan_model
        '
        Me.pan_model.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pan_model.Controls.Add(Me.lbl_35e1_warning)
        Me.pan_model.Controls.Add(Me.cbo_models)
        Me.pan_model.Controls.Add(Me.cbo_series)
        Me.pan_model.Controls.Add(Me.lblSeries)
        Me.pan_model.Controls.Add(Me.txt_model)
        Me.pan_model.Controls.Add(Me.lblModel)
        Me.pan_model.Controls.Add(Me.MenuStrip1)
        Me.pan_model.Dock = System.Windows.Forms.DockStyle.Top
        Me.pan_model.Location = New System.Drawing.Point(0, 0)
        Me.pan_model.Name = "pan_model"
        Me.pan_model.Size = New System.Drawing.Size(924, 58)
        Me.pan_model.TabIndex = 1
        '
        'lbl_35e1_warning
        '
        Me.lbl_35e1_warning.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_35e1_warning.BackColor = System.Drawing.Color.IndianRed
        Me.lbl_35e1_warning.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_35e1_warning.Location = New System.Drawing.Point(227, 5)
        Me.lbl_35e1_warning.Name = "lbl_35e1_warning"
        Me.lbl_35e1_warning.Size = New System.Drawing.Size(682, 21)
        Me.lbl_35e1_warning.TabIndex = 12
        Me.lbl_35e1_warning.Text = " 35E1 is available only for engineers. Verify components."
        Me.lbl_35e1_warning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbo_models
        '
        Me.cbo_models.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_models.Location = New System.Drawing.Point(108, 32)
        Me.cbo_models.MaxDropDownItems = 20
        Me.cbo_models.Name = "cbo_models"
        Me.cbo_models.Size = New System.Drawing.Size(112, 21)
        Me.cbo_models.TabIndex = 2
        '
        'cbo_series
        '
        Me.cbo_series.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_series.Location = New System.Drawing.Point(108, 5)
        Me.cbo_series.Name = "cbo_series"
        Me.cbo_series.Size = New System.Drawing.Size(112, 21)
        Me.cbo_series.TabIndex = 1
        '
        'lblSeries
        '
        Me.lblSeries.Location = New System.Drawing.Point(44, 6)
        Me.lblSeries.Name = "lblSeries"
        Me.lblSeries.Size = New System.Drawing.Size(54, 23)
        Me.lblSeries.TabIndex = 5
        Me.lblSeries.Text = "Series"
        Me.lblSeries.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_model
        '
        Me.txt_model.Location = New System.Drawing.Point(226, 32)
        Me.txt_model.Name = "txt_model"
        Me.txt_model.Size = New System.Drawing.Size(120, 21)
        Me.txt_model.TabIndex = 3
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(924, 24)
        Me.MenuStrip1.TabIndex = 11
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'fileMenuItem
        '
        Me.fileMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.mnuSave, Me.mnuSaveAs, Me.mnuSaveAsRevision, Me.ToolStripSeparator3, Me.mnuConvert, Me.ToolStripSeparator2, Me.mnuPrint})
        Me.fileMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly
        Me.fileMenuItem.Name = "fileMenuItem"
        Me.fileMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.fileMenuItem.Text = "&File"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(188, 6)
        '
        'mnuSave
        '
        Me.mnuSave.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Save
        Me.mnuSave.Name = "mnuSave"
        Me.mnuSave.Size = New System.Drawing.Size(191, 22)
        Me.mnuSave.Text = "Save"
        '
        'mnuSaveAs
        '
        Me.mnuSaveAs.Name = "mnuSaveAs"
        Me.mnuSaveAs.Size = New System.Drawing.Size(191, 22)
        Me.mnuSaveAs.Text = "Save as..."
        '
        'mnuSaveAsRevision
        '
        Me.mnuSaveAsRevision.Image = Global.Rae.RaeSolutions.My.Resources.Resources.SaveAsRevision
        Me.mnuSaveAsRevision.Name = "mnuSaveAsRevision"
        Me.mnuSaveAsRevision.Size = New System.Drawing.Size(191, 22)
        Me.mnuSaveAsRevision.Text = "Save as Revision"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(188, 6)
        '
        'mnuConvert
        '
        Me.mnuConvert.Image = Global.Rae.RaeSolutions.My.Resources.Resources.ConvertToEquipment
        Me.mnuConvert.Name = "mnuConvert"
        Me.mnuConvert.Size = New System.Drawing.Size(191, 22)
        Me.mnuConvert.Text = "Convert to Equipment"
        Me.mnuConvert.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(188, 6)
        Me.ToolStripSeparator2.Visible = False
        '
        'mnuPrint
        '
        Me.mnuPrint.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Print
        Me.mnuPrint.Name = "mnuPrint"
        Me.mnuPrint.Size = New System.Drawing.Size(191, 22)
        Me.mnuPrint.Text = "Print..."
        '
        'btn_go_to_pricing
        '
        Me.btn_go_to_pricing.BackColor = System.Drawing.Color.White
        Me.btn_go_to_pricing.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_go_to_pricing.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_go_to_pricing.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btn_go_to_pricing.Image = Global.Rae.RaeSolutions.My.Resources.Resources.GoToArrow
        Me.btn_go_to_pricing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_go_to_pricing.Location = New System.Drawing.Point(524, 0)
        Me.btn_go_to_pricing.Name = "btn_go_to_pricing"
        Me.btn_go_to_pricing.Size = New System.Drawing.Size(124, 25)
        Me.btn_go_to_pricing.TabIndex = 3
        Me.btn_go_to_pricing.Text = "Go To Pricing"
        Me.btn_go_to_pricing.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_go_to_pricing.UseVisualStyleBackColor = False
        '
        'btn_create_report
        '
        Me.btn_create_report.BackColor = System.Drawing.Color.White
        Me.btn_create_report.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_create_report.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_create_report.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btn_create_report.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Report
        Me.btn_create_report.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_create_report.Location = New System.Drawing.Point(161, 0)
        Me.btn_create_report.Name = "btn_create_report"
        Me.btn_create_report.Size = New System.Drawing.Size(130, 25)
        Me.btn_create_report.TabIndex = 2
        Me.btn_create_report.Text = "Balance Report"
        Me.btn_create_report.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_create_report.UseVisualStyleBackColor = False
        '
        'btn_run_balance
        '
        Me.btn_run_balance.BackColor = System.Drawing.Color.White
        Me.btn_run_balance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_run_balance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_run_balance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btn_run_balance.Image = CType(resources.GetObject("btn_run_balance.Image"), System.Drawing.Image)
        Me.btn_run_balance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_run_balance.Location = New System.Drawing.Point(1, 0)
        Me.btn_run_balance.Name = "btn_run_balance"
        Me.btn_run_balance.Size = New System.Drawing.Size(155, 25)
        Me.btn_run_balance.TabIndex = 1
        Me.btn_run_balance.Text = "Run Balance"
        Me.btn_run_balance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_run_balance.UseVisualStyleBackColor = False
        '
        'lblErro
        '
        Me.lblErro.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.lblErro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblErro.ForeColor = System.Drawing.Color.Black
        Me.lblErro.Location = New System.Drawing.Point(32, 0)
        Me.lblErro.Name = "lblErro"
        Me.lblErro.Size = New System.Drawing.Size(260, 36)
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
        'pan_footer
        '
        Me.pan_footer.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.pan_footer.Controls.Add(Me.lblErro)
        Me.pan_footer.Controls.Add(Me.pan_buttons)
        Me.pan_footer.Controls.Add(Me.picError)
        Me.pan_footer.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pan_footer.Location = New System.Drawing.Point(0, 517)
        Me.pan_footer.Name = "pan_footer"
        Me.pan_footer.Size = New System.Drawing.Size(941, 36)
        Me.pan_footer.TabIndex = 4
        '
        'pan_buttons
        '
        Me.pan_buttons.Controls.Add(Me.progress_bar)
        Me.pan_buttons.Controls.Add(Me.btn_show_nplv_report)
        Me.pan_buttons.Controls.Add(Me.btn_show_iplv_report)
        Me.pan_buttons.Controls.Add(Me.btn_go_to_pricing)
        Me.pan_buttons.Controls.Add(Me.btn_run_balance)
        Me.pan_buttons.Controls.Add(Me.btn_create_report)
        Me.pan_buttons.Dock = System.Windows.Forms.DockStyle.Right
        Me.pan_buttons.Location = New System.Drawing.Point(292, 0)
        Me.pan_buttons.Name = "pan_buttons"
        Me.pan_buttons.Size = New System.Drawing.Size(649, 36)
        Me.pan_buttons.TabIndex = 6
        '
        'progress_bar
        '
        Me.progress_bar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.progress_bar.Location = New System.Drawing.Point(3, 25)
        Me.progress_bar.Name = "progress_bar"
        Me.progress_bar.Size = New System.Drawing.Size(643, 10)
        Me.progress_bar.TabIndex = 11
        Me.progress_bar.Visible = False
        '
        'btn_show_nplv_report
        '
        Me.btn_show_nplv_report.BackColor = System.Drawing.Color.White
        Me.btn_show_nplv_report.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_show_nplv_report.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_show_nplv_report.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btn_show_nplv_report.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Report
        Me.btn_show_nplv_report.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_show_nplv_report.Location = New System.Drawing.Point(410, 0)
        Me.btn_show_nplv_report.Name = "btn_show_nplv_report"
        Me.btn_show_nplv_report.Size = New System.Drawing.Size(110, 25)
        Me.btn_show_nplv_report.TabIndex = 3
        Me.btn_show_nplv_report.Text = "NPLV Report"
        Me.btn_show_nplv_report.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_show_nplv_report.UseVisualStyleBackColor = False
        '
        'btn_show_iplv_report
        '
        Me.btn_show_iplv_report.BackColor = System.Drawing.Color.White
        Me.btn_show_iplv_report.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_show_iplv_report.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_show_iplv_report.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btn_show_iplv_report.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Report
        Me.btn_show_iplv_report.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_show_iplv_report.Location = New System.Drawing.Point(296, 0)
        Me.btn_show_iplv_report.Name = "btn_show_iplv_report"
        Me.btn_show_iplv_report.Size = New System.Drawing.Size(110, 25)
        Me.btn_show_iplv_report.TabIndex = 3
        Me.btn_show_iplv_report.Text = "IPLV Report"
        Me.btn_show_iplv_report.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_show_iplv_report.UseVisualStyleBackColor = False
        '
        'picError
        '
        Me.picError.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.picError.Dock = System.Windows.Forms.DockStyle.Left
        Me.picError.Image = CType(resources.GetObject("picError.Image"), System.Drawing.Image)
        Me.picError.Location = New System.Drawing.Point(0, 0)
        Me.picError.Name = "picError"
        Me.picError.Size = New System.Drawing.Size(32, 36)
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
        Me.SaveToolStripPanel1.Location = New System.Drawing.Point(0, 32)
        Me.SaveToolStripPanel1.Name = "SaveToolStripPanel1"
        Me.SaveToolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.SaveToolStripPanel1.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.SaveToolStripPanel1.Size = New System.Drawing.Size(941, 0)
        '
        'lbl_select_model
        '
        Me.lbl_select_model.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbl_select_model.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_select_model.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lbl_select_model.Location = New System.Drawing.Point(0, 0)
        Me.lbl_select_model.Name = "lbl_select_model"
        Me.lbl_select_model.Padding = New System.Windows.Forms.Padding(6)
        Me.lbl_select_model.Size = New System.Drawing.Size(941, 32)
        Me.lbl_select_model.TabIndex = 13
        Me.lbl_select_model.Text = "Select a model to get started"
        '
        'plv_background_worker
        '
        Me.plv_background_worker.WorkerReportsProgress = True
        '
        'evaporative_condenser_chiller_balance_window
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(941, 553)
        Me.Controls.Add(Me.SaveToolStripPanel1)
        Me.Controls.Add(Me.pan_main)
        Me.Controls.Add(Me.lbl_select_model)
        Me.Controls.Add(Me.pan_footer)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "evaporative_condenser_chiller_balance_window"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Technical Systems - Evaporative Condenser Chiller Balance"
        CType(Me.results, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pan_main.ResumeLayout(False)
        Me.pan_main.PerformLayout()
        Me.panGrid.ResumeLayout(False)
        Me.pan_evaporator.ResumeLayout(False)
        Me.pan_evaporator.PerformLayout()
        Me.panEvaporator.ResumeLayout(False)
        Me.panEvaporator.PerformLayout()
        Me.pan_evaporative_condenser.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel3.PerformLayout()
        Me.pan_compressor.ResumeLayout(False)
        Me.pan_compressor.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.pan_compressor_2.ResumeLayout(False)
        Me.pan_compressor_2.PerformLayout()
        Me.pan_compressor_1.ResumeLayout(False)
        Me.pan_compressor_1.PerformLayout()
        Me.pan_rating_criteria.ResumeLayout(False)
        Me.panRatingCriteria.ResumeLayout(False)
        Me.panRatingCriteria.PerformLayout()
        Me.pan_range.ResumeLayout(False)
        Me.pan_range.PerformLayout()
        Me.pan_factors.ResumeLayout(False)
        Me.pan_factors.PerformLayout()
        Me.pan_model.ResumeLayout(False)
        Me.pan_model.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.pan_footer.ResumeLayout(False)
        Me.pan_buttons.ResumeLayout(False)
        CType(Me.picError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.err, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Dim loaded As Boolean = False
    Dim cd As RaeSolutions.CRDAL

#Region " Properties"

    Private Property AmbientTemp As Double
        Get
            Return ConvertNull.ToDouble(txt_ambient.Text)
        End Get
        Set(ByVal value As Double)
            txt_ambient.Text = value.ToString
        End Set
    End Property

    Private Property LeavingFluidTemp() As Double
        Get
            Return ConvertNull.ToDouble(Me.txt_leaving_fluid_temp.Text)
        End Get
        Set(ByVal Value As Double)
            Me.txt_leaving_fluid_temp.Text = Value.ToString
        End Set
    End Property

#End Region

    Sub Open(ByVal Process_Item As ProcessItem)
        Me.LoadControls(Process_Item)
    End Sub

    Private Sub authorize()
        pan_factors.visible = user.is_in(group.chiller_engineering_options)

        If user.is_rep Then initialize_controls_for_rep()
    End Sub

#Region " Event Handlers"

#Region " Form Event Handlers"

    Private Sub form_Activated() Handles Me.Activated
        initializeSaveToolStripPanel()
        SaveToolStripPanel1.Merge()
    End Sub

    Private Sub form_Deactivate() Handles Me.Deactivate
        SaveToolStripPanel1.Unmerge()
    End Sub

    Private Sub form_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)

        If Not Me.ProcessDeleted Then
            If chiller_model_is_selected AndAlso SaveControls(False, False, True) = False Then
                e.Cancel = True
            Else
                RemoveHandler AppInfo.Main.RevisionView1.RevisionChanged, AddressOf RevisionView_RevisionChanged
            End If
        End If
    End Sub

    Private service As service
    Private compressor_repository As i_compressor_repository
    Private model_changed_schedule, evaporator_changed_schedule As execution_schedule

    Private Sub form_Load() Handles MyBase.Load
        compressor_repository = New compressor_repository()
        Dim chiller_repository = New repository()
        service = New service(compressor_repository, chiller_repository)

        set_initial_control_visibility(False)
        'initialize control save functionality...
        txt_model.Tag = "0,,string"
        cbo_series.Tag = "1,,string"
        cbo_models.Tag = "2,,string"

        cd = New RaeSolutions.CRDAL
        cd.CRDAL()

        height = Ui.FormEditor.MaximizeHeight(Me)

        'WindowState = FormWindowState.Maximized ' makes screens that are opened later maximized
        ColorControls()

        fill_comboboxes()

        cbo_condenser_model.dataSource = service.get_evaporative_condensers()

        cbo_voltage.SelectedIndex = 1

        Dim model_changed_method As command = AddressOf model_changed
        Dim selected_model = grab_chiller_model()
        model_changed_schedule = execution_schedule.Execute(model_changed_method).On(Me).after_last_change_to(selected_model).is_unchanged_for(msec:=500)

        Dim evaporator_changed_method As command = AddressOf evaporator_changed
        Dim selected_evaporator = grab_evaporator_model()
        evaporator_changed_schedule = execution_schedule.Execute(evaporator_changed_method).On(Me).after_last_change_to(selected_evaporator).is_unchanged_for(msec:=500)

        initialize_controls()

        authorize()

        initializeValidation()

        loaded = True

        'add handler to revision view . revision changed event on main form...
        Dim mainForm As MainForm = CType(My.Application.ApplicationContext.MainForm, MainForm)
        AddHandler mainForm.RevisionView1.RevisionChanged, AddressOf RevisionView_RevisionChanged
    End Sub

#End Region


#Region " Button Event Handlers"

    Private Sub btn_alternate_evaporators_click() _
    Handles btn_alternate_evaporators.click


        Static hasWarningBeenShown As Boolean = False

        ' If user.is_rep Then
        If hasWarningBeenShown = False Then
            hasWarningBeenShown = True
            MsgBox("Evaporator changes are not reflected in unit's pricing.  Contact factory for pricing impact.")
        End If
        'End If

        set_enabled_on_acme_related_controls(enabled:=False)

        jot("before unmanaged call")
        list_alternate_evaporators()
        cbo_evaporator_model.Visible = True
        jot("after unmanaged call")

        set_enabled_on_acme_related_controls(enabled:=True)
    End Sub


    ' opens chart in popup form that displays
    ' 1. Leaving Fluid Temp., 2. Recommended Glycol, 3. Freeze Point, 4. Minimum Suction Temp.
    Private Sub btnGlycolChart_Click() _
    Handles btn_glycol_chart.Click
        Dim form As New Windows.Forms.Form
        ''Dim myGrid As New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Dim glycolTable As DataTable
        Dim formWidth, formHeight As Integer
        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        Dim glycol = Me.cbo_glycol.SelectedItem.ToString
        ' retrieves glycol table of recommendations
        If glycol = "Ethylene" Then
            glycolTable = DataAccess.Chillers.ChillerDataAccess.RetrieveEthylene()
            form.Controls.Add(DataGridView1)
            ' sets datagrid's data source
            Me.DataGridView1.DataSource = glycolTable
            Me.DataGridView1.Columns(GlycolNames.LeavingFluidTemperature).Width = 100
            Me.DataGridView1.Columns(GlycolNames.FreezingPoint).Width = 80
            Me.DataGridView1.Columns(GlycolNames.RecommendedGlycolPercentage).Width = 85
            Me.DataGridView1.Columns(GlycolNames.RecommendedMinSuctionTemperature).Width = 140
            Me.DataGridView1.Columns(GlycolNames.LeavingFluidTemperature).HeaderText = "Leaving Fluid Temperature [°F]"
            Me.DataGridView1.Columns(GlycolNames.FreezingPoint).HeaderText = "Freezing Point [°F]"
            Me.DataGridView1.Columns(GlycolNames.RecommendedGlycolPercentage).HeaderText = "Recommended Glycol [%]"
            Me.DataGridView1.Columns(GlycolNames.RecommendedMinSuctionTemperature).HeaderText = "Recommended Minimum Suction Temperature [°F]"
        ElseIf glycol = "Propylene" Then
            glycolTable = DataAccess.Chillers.ChillerDataAccess.RetrievePropylene()
            form.Controls.Add(DataGridView2)
            ' sets datagrid's data source
            Me.DataGridView2.DataSource = glycolTable
            Me.DataGridView2.Columns(GlycolNames.LeavingFluidTemperature).Width = 100
            Me.DataGridView2.Columns(GlycolNames.FreezingPoint).Width = 80
            Me.DataGridView2.Columns(GlycolNames.RecommendedGlycolPercentage).Width = 85
            Me.DataGridView2.Columns(GlycolNames.RecommendedMinSuctionTemperature).Width = 140
            Me.DataGridView2.Columns(GlycolNames.LeavingFluidTemperature).HeaderText = "Leaving Fluid Temperature [°F]"
            Me.DataGridView2.Columns(GlycolNames.FreezingPoint).HeaderText = "Freezing Point [°F]"
            Me.DataGridView2.Columns(GlycolNames.RecommendedGlycolPercentage).HeaderText = "Recommended Glycol [%]"
            Me.DataGridView2.Columns(GlycolNames.RecommendedMinSuctionTemperature).HeaderText = "Recommended Minimum Suction Temperature [°F]"
        Else
            Ui.MessageBox.Show("The selected fluid is water; the fluid must be a glycol in order to chart recommendations.", _
               MessageBoxIcon.Information)
            Exit Sub
        End If
        ''form.Controls.Clear()
        ' adds grid to form
        ' Note: need to add grid to form before setting datasource
        ''form.Controls.Add(DataGridView1)
        ''' sets datagrid's data source
        ''Me.DataGridView1.DataSource = glycolTable
        ''Me.DataGridView1.Columns(GlycolNames.LeavingFluidTemperature).Width = 100
        ''Me.DataGridView1.Columns(GlycolNames.FreezingPoint).Width = 80
        ''Me.DataGridView1.Columns(GlycolNames.RecommendedGlycolPercentage).Width = 85
        ''Me.DataGridView1.Columns(GlycolNames.RecommendedMinSuctionTemperature).Width = 140
        ''Me.DataGridView1.Columns(GlycolNames.LeavingFluidTemperature).HeaderText = "Leaving Fluid Temperature [°F]"
        ''Me.DataGridView1.Columns(GlycolNames.FreezingPoint).HeaderText = "Freezing Point [°F]"
        ''Me.DataGridView1.Columns(GlycolNames.RecommendedGlycolPercentage).HeaderText = "Recommended Glycol [%]"
        ''Me.DataGridView1.Columns(GlycolNames.RecommendedMinSuctionTemperature).HeaderText = "Recommended Minimum Suction Temperature [°F]"
        ' sets column width and captions
        ''With myGrid.Splits(0)
        ''    ' sets column properties
        ''    .ColumnCaptionHeight = 36

        ''    .DisplayColumns(GlycolNames.LeavingFluidTemperature).Width = 100
        ''    .DisplayColumns(GlycolNames.LeavingFluidTemperature).DataColumn.Caption = "Leaving Fluid Temperature [°F]"
        ''    .DisplayColumns(GlycolNames.FreezingPoint).Width = 80
        ''    .DisplayColumns(GlycolNames.FreezingPoint).DataColumn.Caption = "Freezing Point [°F]"
        ''    .DisplayColumns(GlycolNames.RecommendedGlycolPercentage).Width = 85
        ''    .DisplayColumns(GlycolNames.RecommendedGlycolPercentage).DataColumn.Caption = "Recommended Glycol [%]"
        ''    .DisplayColumns(GlycolNames.RecommendedMinSuctionTemperature).Width = 140
        ''    .DisplayColumns(GlycolNames.RecommendedMinSuctionTemperature).DataColumn.Caption = _
        ''       "Recommended Minimum Suction Temperature [°F]"
        ''End With
        ''myGrid.Dock = System.Windows.Forms.DockStyle.Fill
        ''myGrid.Caption = glycol & " Table"

        ' sets grid style to pre-defined style
        ''Rae.Ui.C1GridStyles.BasicGridStyle(myGrid)

        ' initializes form width to outer border width + vertical scroll bar width
        ''formWidth = 5 * 2 + DataGridView1.VScrollBar.Width
        ''For i As Integer = 0 To myGrid.Splits(0).DisplayColumns.Count - 1
        ''    ' calculates form width based on column width and inner borders
        ''    formWidth += myGrid.Splits(0).DisplayColumns(i).Width + 1
        ''Next

        ' calculates for height (just estimate)
        ''formHeight = 34 + myGrid.CaptionHeight + myGrid.Splits(0).ColumnCaptionHeight
        ''For i As Integer = 0 To myGrid.Splits(0).Rows.Count - 1
        ''    formHeight += myGrid.RowHeight + 1
        ''Next

        ' sets form properties
        form.Width = 1000
        form.Height = 400
        form.Text = glycol & " Recommendations"
        form.MdiParent = Me.MdiParent
        ' shows form w/ glycol chart
        form.Show()

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub


    Private Sub btn_run_balance_click() Handles btn_run_balance.click
        If Not chiller_model_is_selected Then
            warn("Please select a valid chiller model.")
            Exit Sub
        End If

        ' checks if validation controls are valid
        If Not Me.chillerVMgr.Validate() Then
            warn(Me.chillerVMgr.ErrorMessagesSummary)
            Exit Sub
        End If

        cursor = cursors.waitcursor
        Try
            set_enabled_on_acme_related_controls(enabled:=False)
            start_calculations()
        Catch ex As exception
            alert("An error occurred. The balance cannot be completed." & system.environment.newline & ex.message)
            invalidate_results()
        Finally
            set_enabled_on_acme_related_controls(enabled:=True)
        End Try
        cursor = cursors.arrow

        panGrid.focus()
    End Sub


    Private Sub btn_create_report_click() Handles btn_create_report.click
        If Not chiller_model_is_selected Then _
           warn("Please select a valid chiller model.") : Exit Sub

        cursor = cursors.waitcursor

        Try
            set_enabled_on_acme_related_controls(enabled:=False)
            Dim points = start_calculations()
            If points Is Nothing Then
                Dim errormessage = "Report could not be created."
                'if error_message = "" then error_message = message else error_message &= new_line & message
                If lblerro.text = "" Then lblErro.Text = errorMessage Else lblErro.Text &= Environment.NewLine & errorMessage
            Else
                If user.is_in(Rae.solutions.group.technical_systems_sales) Then

                    Dim CF As Integer = MsgBox("Do you want to print the word report (no will print the old report)?", MsgBoxStyle.YesNo)

                    If CF = vbYes Then
                        show_word_report(points)
                    Else
                        show_balance_report(points)
                    End If
                Else
                    show_word_report(points)
                End If
            End If
        Catch ex As exception
            invalidate_results()
            lblerro.text = "An error occurred. Contact factory for rating of units outside the operating limits"
        Finally
            set_enabled_on_acme_related_controls(enabled:=True)
        End Try

        cursor = cursors.arrow
    End Sub


    Private Sub progress_changed(ByVal percentage As Double)
        plv_background_worker.ReportProgress(percentage)
    End Sub

    Private Sub show_plv_report(ByVal points As balance.point_list, ByVal plv As String)
        Dim spec = grab_spec()
        Dim chiller = grab_chiller()
        Dim commands As chillers.plv_commands

        Dim evaporator_context = get_evaporator_iplv_context()
        If plv = "iplv" Then
            commands = New iplv_commands(spec, chiller, evaporator_context)
        Else
            commands = New nplv_commands(spec, chiller, evaporator_context)
        End If
        progress_bar.visible = True
        Dim algorithm = New plv_algorithm(commands)
        AddHandler algorithm.progress_changed, AddressOf progress_changed
        progress_bar.value = 4
        plv_background_worker.RunWorkerAsync(algorithm)
    End Sub

    Private Sub show_plv_report(ByVal algorithm As plv_algorithm, ByVal points As balance.point_list)
        Dim outputs = algorithm.outputs
        Dim iplv = algorithm.iplv_value
        RemoveHandler algorithm.progress_changed, AddressOf progress_changed

        Dim iplv_dataset = New evaporative_condenser_chiller_iplv_data()

        For Each output In outputs
            iplv_dataset.iplv_data.Addiplv_dataRow(output.load & "%", round(output.leaving_fluid_temperature, 1), round(output.ambient), round(output.capacity, 1), round(output.compressor_eer, 1), round(output.compressor_kw_per_ton, 2), round(output.eer, 1), round(output.unit_kw_per_ton, 2))
        Next
        iplv_dataset.AcceptChanges()

        Dim report = New rae.reporting.beta.report(reports.file_paths.evaporative_condenser_chiller_plv_file_path)
        report.set_table("table", iplv_dataset.tables(0))

        Dim parameters = get_report_parameters(points)
        Dim text = New dictionary(Of String, String)
        text.add("model_number", parameters.model_number)
        text.add("condenser_description", parameters.condenser_description)
        text.add("evaporator_description", parameters.evaporator_description)
        text.add("compressor_description", parameters.compressor_description)
        text.add("fluid", parameters.fluid)
        text.add("refrigerant", parameters.refrigerant)
        text.add("hertz", parameters.hertz)
        text.add("altitude", parameters.altitude & " ft.")
        text.add("condenser_capacity", parameters.condenser_capacity & " BTUH")
        text.add("discharge_line_loss", parameters.discharge_line_loss & "°F")
        text.add("suction_line_loss", parameters.suction_line_loss & "°F")
        text.add("plv", round(iplv, 1))
        text.add("plv_label", algorithm.plv_type.toupper())
        text.add("application_version", parameters.application_version)
        text.add("year", DateTime.Now.Year.ToString)
        text.add("user", user.username)
        text.add("date_created", Date.Now.ToShortDateString)
        report.set_text(text)
        report.show()
    End Sub


    Private Sub btn_show_iplv_report_click() Handles btn_show_iplv_report.click
        cursor = cursors.waitcursor

        Try
            set_enabled_on_acme_related_controls(enabled:=False)
            Me.points = start_calculations()
            If points Is Nothing Then
                Dim error_message = "The IPLV report cannot be shown. The balance did not return results."
                alert(error_message)
            Else
                show_plv_report(points, "iplv")
            End If
        Catch ex As Exception
            invalidate_results()
            Dim error_message = "An error occurred when showing IPLV report. " & ex.Message
            alert(error_message)
        End Try

        cursor = cursors.arrow
    End Sub
    Private points As balance.point_list

    Sub plv_background_worker_do_work(ByVal sender As Object, ByVal e As system.componentModel.DoWorkEventArgs) Handles plv_background_worker.DoWork
        Dim algorithm = e.argument
        algorithm.calculate()
        e.result = algorithm
    End Sub

    Sub plv_background_worker_completed(ByVal sender As Object, ByVal e As system.componentModel.RunWorkerCompletedEventArgs) Handles plv_background_worker.RunWorkerCompleted
        If e.error.is_set Then
            alert("The report cannot be created. " & e.error.message)
            progress_bar.visible = False
            set_enabled_on_acme_related_controls(enabled:=True)
        Else
            Dim algorithm = e.result
            show_plv_report(algorithm, Me.points)
            progress_bar.visible = False
            set_enabled_on_acme_related_controls(enabled:=True)
        End If
    End Sub

    Sub plv_background_worker_report_progress(ByVal sender As Object, ByVal e As system.componentModel.ProgressChangedEventArgs) Handles plv_background_worker.ProgressChanged
        progress_bar.value = e.ProgressPercentage
    End Sub

    Private Sub btn_show_nplv_report_click() Handles btn_show_nplv_report.click
        cursor = cursors.waitcursor

        Try
            set_enabled_on_acme_related_controls(enabled:=False)
            Me.points = start_calculations()
            If points Is Nothing Then
                Dim error_message = "The NPLV report cannot be shown. The balance did not return results."
                alert(error_message)
            Else
                show_plv_report(points, "nplv")
            End If
        Catch ex As exception
            invalidate_results()
            Dim error_message = "An error occurred when showing NPLV report. " & ex.message
            alert(error_message)
        Finally
            set_enabled_on_acme_related_controls(enabled:=True)
        End Try

        cursor = cursors.arrow
    End Sub

    Private Sub btnSave_Click()
        Dim dsSave As DataSet
        dsSave = New DataSet("ProcessSet")

        Dim dtSave As DataTable = New DataTable("Process")
        dsSave.Tables.Add(dtSave)

        Dim dcSave As DataColumn
        Dim drSave As DataRow

        dcSave = New DataColumn
        dcSave.ColumnName = "Key"
        dcSave.DataType = System.Type.GetType("System.String")
        dtSave.Columns.Add(dcSave)

        dcSave = New DataColumn
        dcSave.ColumnName = "Value"
        dcSave.DataType = System.Type.GetType("System.String")
        dtSave.Columns.Add(dcSave)

        dcSave = New DataColumn
        dcSave.ColumnName = "Seq"
        dcSave.DataType = System.Type.GetType("System.String")
        dtSave.Columns.Add(dcSave)


        'gather form data from all the controls
        Dim ctl As Control, ctl2 As Control, ctl3 As Control
        For Each ctl In Me.Controls
            If ctl.Name Like "i_*" Then
                drSave = dtSave.NewRow()
                drSave("Key") = ctl.Name
                drSave("Value") = ctl.Text
                drSave("Seq") = LSet(ctl.Tag, InStr(ctl.Tag, ",") - 1)
                dtSave.Rows.Add(drSave)
            End If
            'If ctl.Name Like "cbo*" Then
            '    'drSave = dtSave.NewRow()
            '    'drSave("Key") = ctl.Name
            '    'drSave("Value") = ctl.s
            '    'dtSave.Rows.Add(drSave)
            'End If
            If ctl.HasChildren Then
                For Each ctl2 In ctl.Controls
                    If ctl2.Name Like "i_*" Then
                        drSave = dtSave.NewRow()
                        drSave("Key") = ctl2.Name
                        drSave("Value") = ctl2.Text
                        drSave("Seq") = LSet(ctl2.Tag, InStr(ctl2.Tag, ",") - 1)
                        dtSave.Rows.Add(drSave)
                    End If
                    If ctl2.HasChildren Then
                        For Each ctl3 In ctl2.Controls
                            If ctl3.Name Like "i_*" Then
                                drSave = dtSave.NewRow
                                drSave("Key") = ctl3.Name
                                drSave("Value") = ctl3.Text
                                MessageBox.Show(LSet(ctl3.Tag, InStr(ctl3.Tag, ",") - 1))
                                drSave("Seq") = LSet(ctl3.Tag, InStr(ctl3.Tag, ",") - 1)
                                dtSave.Rows.Add(drSave)
                            End If
                        Next
                    End If
                Next
            End If
        Next
    End Sub

#End Region


#Region " Combobox Event Handlers"


    Private Sub cboSeries_SelectedIndexChanged() _
    Handles cbo_series.SelectedIndexChanged
        Dim series = cbo_series.SelectedItem.ToString

        lbl_35e1_warning.visible = (series = "35E1")

        Dim refrigerants = get_refrigerants(series)
        fill_refrigerant_combobox(refrigerants)
        Dim refg = grab_refrigerant()
        Dim models = service.get_models(series, refg)

        cbo_models.Items.Clear()
        For Each chillerModel In models
            cbo_models.Items.Add(chillerModel)
        Next

        If loaded Then
            cbo_models.SelectedIndex = 0
        End If
    End Sub

    Private Sub fill_refrigerant_combobox(ByVal refrigerants As list(Of refrigerant))
        cbo_refrigerant.items.clear()
        For Each refg In refrigerants
            cbo_refrigerant.items.add(refg)
        Next
        cbo_refrigerant.selectedIndex = 0
    End Sub

    Private Function get_refrigerants(ByVal series As String) As list(Of refrigerant)
        Dim refrigerants = New list(Of refrigerant)

        If series = "35E1" Then
            refrigerants.add(refrigerant.parse("R22"))
        ElseIf series = "35E2" Then
            refrigerants.add(refrigerant.parse("R134a"))
            refrigerants.add(refrigerant.parse("R22"))
        End If

        Return refrigerants
    End Function


    Private Sub cbo_models_SelectedIndexChanged() Handles cbo_models.SelectedIndexChanged
        Dim selected_model = grab_chiller_model()

        jot("schedule change model: " & selected_model)
        model_changed_schedule.change(selected_model)

    End Sub

    Private Sub set_enabled_on_acme_related_controls(ByVal enabled As Boolean)
        cbo_models.enabled = enabled
        cbo_series.enabled = enabled
        cbo_evaporator_model.enabled = enabled
        cbo_glycol.enabled = enabled
        btn_show_iplv_report.enabled = enabled
        btn_show_nplv_report.enabled = enabled
        btn_create_report.enabled = enabled
        btn_go_to_pricing.enabled = enabled
        btn_run_balance.enabled = enabled
        btn_alternate_evaporators.enabled = enabled
    End Sub

    Private Sub set_initial_control_visibility(ByVal visible As Boolean)
        Static shown As Boolean = False

        If shown Then Exit Sub

        For Each panel As panel In pan_main.controls
            If Not panel Is pan_model And Not panel Is pan_factors Then
                panel.visible = visible
            End If
        Next

        pan_footer.visible = visible
        lbl_select_model.visible = Not visible

        If visible Then shown = True
    End Sub


    Private Sub model_changed()
        cursor = cursors.waitcursor

        jot("actually changed: " & grab_chiller_model)

        Try
            set_initial_control_visibility(True)
            set_enabled_on_acme_related_controls(enabled:=False)

            Dim model = grab_chiller_model()
            Dim voltage = grab_voltage()
            Dim chiller = get_chiller(model, voltage)

            invalidate_results()
            lblErro.Text = ""

            fill_compressor_listboxes(grab_refrigerant)

            evaporator_grid_1.SetNumCircuits(chiller.num_circuits)

            pan_compressor_2.visible = chiller.num_circuits > 1

            set_controls(chiller)
        Catch ex As exception
            alert("An error occurred when changing model. " & ex.message)
        Finally
            set_enabled_on_acme_related_controls(enabled:=True)
        End Try

        cursor = cursors.arrow
    End Sub

    'sets evaporator model and fills approach and evaporator capacity
    Private Sub cbo_evaporator_model_SelectedIndexChanged() Handles cbo_evaporator_model.SelectedIndexChanged
        set_enabled_on_acme_related_controls(enabled:=False)
        cbo_evaporator_model.enabled = True

        Dim model = grab_evaporator_model_from_combobox()
        jot("temporal evaporator model: " & model)
        evaporator_changed_schedule.change(model)

        If grab_evaporator_model_from_combobox() = "Choose" Then _
           set_enabled_on_acme_related_controls(enabled:=True) 'after model is selected the execution schedule will re-enable controls unless Choose is selected
        cbo_evaporator_model.focus()
    End Sub

    Private Function grab_evaporator_model_from_combobox() As String
        Return cbo_evaporator_model.SelectedItem.ToString()
    End Function

    Private Sub evaporator_changed()
        If loaded Then
            Dim model = cbo_evaporator_model.SelectedItem.ToString.Trim

            If model = "Choose" Then Exit Sub

            set_enabled_on_acme_related_controls(enabled:=False)

            jot("committed evaporator model: " & model)
            invalidate_results()
            lblErro.Text = ""

            set_chiller_evaporator_controls(model)

            show_evaporator_data_over_approach_range()

            set_enabled_on_acme_related_controls(enabled:=True)
        End If
    End Sub

    Private Function get_chiller(ByVal model As String, ByVal voltage As Integer) As chiller
        Dim chiller = service.get(model, voltage)

        If opening_standard Then
            chiller.circuits(0).compressor = lbo_compressors_1.items(0)
            If chiller.num_circuits > 1 Then _
               chiller.circuits(1).compressor = lbo_compressors_2.items(0)
            Return chiller
        End If

        If chiller.circuits(0).compressor Is Nothing Then
            warn("Standard compressor data for " & model & " at " & voltage & " volts is not available. Another compressor will need to be selected.")
            chiller.circuits(0).compressor = lbo_compressors_1.items(0)
        ElseIf chiller.num_circuits > 1 AndAlso chiller.circuits(1).compressor Is Nothing Then
            warn("Standard compressor data for " & model & " at " & voltage & " volts is not available. Another compressor will need to be selected.")
            chiller.circuits(1).compressor = lbo_compressors_2.items(0)
        End If

        Return chiller
    End Function


    Private Sub set_controls(ByVal chiller As chiller)
        txt_pump_motor_hp.text = chiller.condenser.pump_hp
        txt_pump_quantity.text = chiller.condenser_quantity
        txt_total_pump_watts.text = round(chiller.total_pump_watts)

        txt_fan_motor_hp.text = chiller.condenser.fan_hp
        txt_fan_quantity.text = chiller.condenser_quantity
        txt_total_fan_watts.text = round(chiller.total_fan_watts)

        set_circuit_1_controls(chiller)

        txt_condenser_quantity.text = chiller.condenser_quantity
        txt_condenser_capacity.text = chiller.condenser.capacity

        If chiller.num_circuits > 1 Then _
           set_circuit_2_controls(chiller)

        If chiller.num_circuits > 1 Then
            txt_compressor_qty_2.visible = True
            txt_compressor_2.visible = True
        Else
            txt_compressor_qty_2.visible = False
            txt_compressor_2.visible = False
        End If

        'If chiller.num_circuits = 4 Then
        '   radCircuit1.Text = "Circuit 1 and 3"
        '   radCircuit2.Text = "Circuit 2 and 4"
        '   lblCircuit1.Text = "Circuit 1 and 3"
        '   lblCircuit2.Text = "Circuit 2 and 4"
        'Else
        '   radCircuit1.Text = "Circuit 1"
        '   radCircuit2.Text = "Circuit 2"
        '   lblCircuit1.Text = "Circuit 1"
        '   lblCircuit2.Text = "Circuit 2"
        'End If

        txt_model.text = chiller.model
    End Sub

    Private Sub cboRefrigerant_SelectedIndexChanged() Handles cbo_refrigerant.SelectedIndexChanged
        If loaded Then
            Dim refg = grab_refrigerant()
            fill_compressor_listboxes(refg)

            If refg.for_db = "R134a" AndAlso user.is_rep Then
                evaporator_grid_1.rboCustom.Checked = True
                evaporator_grid_1.ShowApproachSelection()

            ElseIf refg.for_db = "R22" Then
                evaporator_grid_1.rbo8To10.Checked = True
                evaporator_grid_1.HideApproachSelection()
            End If

        End If
    End Sub

    Private Sub cboHertz_SelectedIndexChanged() Handles cbo_hertz.SelectedIndexChanged
        If loaded Then
            invalidate_results()
            lblErro.Text() = ""
        End If
    End Sub

    Private Function select_compressor(ByVal listbox As listbox, ByVal compressor_model As String) As Boolean
        For Each c As compressor In listbox.items
            If c.model = compressor_model Then
                listbox.selectedItem = c
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub cboSystem_SelectedIndexChanged()
        invalidate_results()
        lblErro.Text() = ""
    End Sub

    Private Sub cbo_condenser_model_SelectedIndexChanged() Handles cbo_condenser_model.SelectedIndexChanged
        update_watts_and_capacity(circuit:=1)
    End Sub

    Private Function FindSelectedIndex(ByRef cbo As ComboBox, ByVal val As String, Optional ByVal prop As String = "") As Integer
        For i As Integer = 0 To cbo.Items.Count - 1
            If cbo.Items(i).GetType().Name = "DataRowView" Then
                Dim drv As DataRow = cbo.Items(i)
                If val = drv(prop) Then
                    Return i
                End If
            ElseIf cbo.Items(i).GetType().Namespace.ToUpper().IndexOf("RAE") > -1 Then
                If val = cbo.Items(i).GetType().GetProperty(prop).GetValue(cbo.Items(i), Nothing).ToString() Then
                    Return i
                End If
            Else
                If val = cbo.Items(i).ToString Then
                    Return i
                End If
            End If
        Next
        Return 0
    End Function


    Private Sub cboRatiCritFlui_SelectedIndexChanged() Handles cbo_fluid.SelectedIndexChanged
        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        invalidate_results()
        lblErro.Text() = ""

        If cbo_fluid.SelectedItem = "Water" Then
            cbo_glycol.Visible = False
            txt_glycol_percentage.Enabled = False
            'glycol percentage
            txt_glycol_percentage.Text() = "0"
            Me.btn_glycol_chart.Visible = False
            'glycol selected
        Else
            Me.cbo_glycol.Visible = True
            Me.txt_glycol_percentage.Enabled = True
            'glycol percentage
            Me.txt_glycol_percentage.Text = "20"
            Me.btn_glycol_chart.Visible = True
        End If
        If loaded Then
            specific_heat_and_gravity_controller.calculate()
            calculate_freeze_point_and_suction_temp(grab_fluid, grabGlycolPerc)
        End If

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

#End Region

#Region " Textbox Event Handlers"

    Private Sub txt_fluid_percentage_TextChanged() _
    Handles txt_glycol_percentage.TextChanged, cbo_glycol.SelectedIndexChanged, txt_range.textChanged, txt_leaving_fluid_temp.textChanged
        If loaded Then
            invalidate_results()
            specific_heat_and_gravity_controller.calculate()
        End If
    End Sub

    Private Sub txtLeavingFluidTemp_Leave() _
    Handles txt_leaving_fluid_temp.Leave
        ' validates leaving fluid temperature textbox value
        Me.leavingFluidTempVCtrl.Validate()
    End Sub

    '1. hide error pic if no errors occurred
    '2. set error text's tooltip
    Private Sub lblErro_TextChanged() _
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

    Private Sub lbo_compressors_1_MouseDown() Handles lbo_compressors_1.MouseDown
        If loaded Then txt_compressor_1.Text = grab_compressor_1().model

        Static hasWarningBeenShown As Boolean = False

        If hasWarningBeenShown = False Then
            hasWarningBeenShown = True
            MsgBox("Compressor changes are not reflected in unit's pricing.  Contact factory for pricing impact.")
        End If
    End Sub

    Private Sub lbo_compressor_2_MouseDown() Handles lbo_compressors_2.MouseDown
        If loaded Then txt_compressor_2.Text = grab_compressor_2().model

        Static hasWarningBeenShown As Boolean = False

        If hasWarningBeenShown = False Then
            hasWarningBeenShown = True
            MsgBox("Compressor changes are not reflected in unit's pricing.  Contact factory for pricing impact.")
        End If
    End Sub

    Private Sub lbo_compressor_1_SelectedIndexChanged() Handles lbo_compressors_1.SelectedIndexChanged



        Dim compressor = grab_compressor_1()
        txt_compressor_1.Text = compressor.model
        ToolTip1.SetToolTip(txt_compressor_1, compressor.MasterID)

        invalidate_results()
    End Sub

    Private Sub lbo_compressor_2_SelectedIndexChanged() Handles lbo_compressors_2.SelectedIndexChanged


        Dim compressor = grab_compressor_2()
        txt_compressor_2.Text = compressor.model
        ToolTip1.SetToolTip(txt_compressor_2, compressor.MasterID)

        invalidate_results()
    End Sub

#End Region

#End Region


#Region " Helper Methods"

    Private Sub fill_comboboxes()
        cbo_series.items.add("35E2")
        If user.is_in(group.application_engineering) Or user.is_in(group.IT) Then _
           cbo_series.items.add("35E1") ' 35E1 is R22 series
        Dim refrigerants = get_refrigerants("35E2")
        fill_refrigerant_combobox(refrigerants)

        Dim voltages = New rae.collections.display_value_list(Of Integer, String)
        voltages.add(230, "208-230") : voltages.add(460, "460") ': voltages.add(575, "575")
        'cbo_voltage.datasource = service.get_voltages()
        cbo_voltage.DataSource = voltages ' Rae.RaeSolutions.DataAccess.CompressorDataAccess.RetrieveCompressorVolts()
    End Sub


    Private Function get_report_parameters(ByVal points As balance.point_list) As report_parameters
        Dim condenser_capacity, fan As String
        Dim catalog_rating As String

        ' sets parameters
        '
        Dim chiller_model As String
        If txt_model.text = grab_chiller_model() Then
            chiller_model = grab_chiller_model()
        Else
            chiller_model = txt_model.Text & "       Base Model: " & grab_chiller_model()
        End If

        ' NOTE: It appears:
        ' The condenser text box contains the standard condenser model based on the selected chiller
        ' The condenser combobox contains the user's condenser selection (may differ from standard)

        Dim circuits_per_unit = CInt(Me.Txt_circuit_per_unit.Text.Trim)

        Dim condenser = grab_condenser()
        Dim condenser_quantity = grab_condenser_quantity()
        Dim subcooling_note = If(subcooling_option_control.checked, " w/ Subcooling", "")
        Dim sound_attenuation_note = If(sound_attenuation_option_control.checked, "w/ Sound Attenuation", "")
        Dim condenser_description = rae.io.text.str("({0}) {1} {2} {3}", _
            condenser_quantity, condenser.model, subcooling_note, sound_attenuation_note)

        Dim compressor_quantity_1 = txt_compressor_qty_1.text.trim
        Dim compressor_quantity_2 = txt_compressor_qty_2.text.trim

        Dim compressor_file_name_1 = grab_compressor_1().model
        Dim compressor_file_name_2 As String
        If circuits_per_unit > 1 Then _
           compressor_file_name_2 = grab_compressor_2().model

        Dim compressor As String
        If circuits_per_unit = 1 Then
            compressor = "(" & compressor_quantity_1 & ") " & compressor_file_name_1
        ElseIf circuits_per_unit = 2 Or circuits_per_unit = 4 Then
            compressor = "(" & compressor_quantity_1 & ") " & compressor_file_name_1 & _
               " --- " & "(" & compressor_quantity_2 & ") " & compressor_file_name_2
        End If

        Dim fluid As String
        If cbo_fluid.SelectedItem = "Water" Then
            fluid = cbo_fluid.SelectedItem
        Else
            fluid = Me.cbo_fluid.SelectedItem.ToString & "   " & Me.txt_glycol_percentage.Text.Trim & "% " & Me.cbo_glycol.SelectedItem.ToString
        End If

        Dim operating_limits_message As String
        If points.contain_invalid_point Then
            operating_limits_message = Me.lblOperLimi.Text
        Else
            operating_limits_message = ""
        End If

        Dim lower_approach, upper_approach As String
        If evaporator_grid_1.CustomSelected Then
            lower_approach = 8
            upper_approach = 10
        Else
            lower_approach = evaporator_grid_1.SelectedLowerApproach.approach
            upper_approach = evaporator_grid_1.SelectedUpperApproach.approach
        End If

        ' 8F Evaporator, 10F Evaporator, Condenser Capacity @ 25F, Fan
        Dim lower_capacity, upper_capacity As Double
        If Val(Txt_circuit_per_unit.Text) = 1 Then
            If evaporator_grid_1.CustomSelected Then
                lower_capacity = evaporator_grid_1.CustomCapacityCircuit1Approach8 ' tbxEvap8Degr1.Text
                upper_capacity = evaporator_grid_1.CustomCapacityCircuit1Approach10 ' tbxEvap10Degr1.Text
            Else
                Dim evaporatorAt8DegreeApproach = evaporator_grid_1.GetEvaporatorAt(8)
                If evaporatorAt8DegreeApproach IsNot Nothing Then
                    lower_capacity = round(evaporatorAt8DegreeApproach.capacity)
                Else
                    lower_capacity = 0
                End If

                Dim evaporatorAt10DegreeApproach = evaporator_grid_1.GetEvaporatorAt(10)
                If evaporatorAt10DegreeApproach IsNot Nothing Then
                    upper_capacity = round(evaporatorAt10DegreeApproach.capacity)
                Else
                    upper_capacity = 0
                End If
            End If

            condenser_capacity = Val(Me.txt_condenser_capacity.Text)
        ElseIf Val(Txt_circuit_per_unit.Text) = 2 Or Val(Txt_circuit_per_unit.Text) = 4 Then
            If evaporator_grid_1.CustomSelected Then
                lower_capacity = evaporator_grid_1.CustomCapacityCircuit1Approach8 + evaporator_grid_1.CustomCapacityCircuit2Approach8
                upper_capacity = evaporator_grid_1.CustomCapacityCircuit1Approach10 + evaporator_grid_1.CustomCapacityCircuit2Approach10
            Else
                lower_capacity = round(evaporator_grid_1.SelectedLowerApproach.capacity + evaporator_grid_1.SelectedLowerApproach.capacity) ' Q8 + Q8
                upper_capacity = round(evaporator_grid_1.SelectedUpperApproach.capacity + evaporator_grid_1.SelectedUpperApproach.capacity) ' Q9 + Q9
            End If
            condenser_capacity = Val(txt_condenser_capacity.Text)
        End If

        If chk_catalog_rating.checked Then
            catalog_rating = "Catalog Rating"
        Else
            catalog_rating = ""
        End If

        Dim subcooling_message = "S/C " & txt_subcooling.text & "°F"

        ' authorization ("Rep" or "Engineer")
        Dim pressure_drop_message As String
        If points.contain_invalid_fluid_pd Then
            pressure_drop_message = "* The fluid pressure drop cannot be calculated when the approach is out of range or a custom evaporator is selected."
        Else
            pressure_drop_message = ""
        End If

        Dim evaporator = txt_evaporator_model.text.trim & "   Fouling = " & cboFoulingFactor.SelectedItem
        Dim hertz = grab_hertz()
        Dim range_message = "Calculations based on " & txt_range.Text.Trim & "ºF Range"

        Dim whole_number_format = "###,###,###"
        Dim parameters As report_parameters
        parameters.application_version = My.Application.Info.Version.ToString
        parameters.altitude = grab_altitude()
        parameters.ambient = AmbientTemp
        parameters.leaving_fluid_temperature = LeavingFluidTemp
        parameters.catalog_message = catalog_rating
        parameters.subcooling_message = subcooling_message
        parameters.compressor_description = compressor
        parameters.condenser_description = condenser_description
        parameters.condenser_capacity = condenser_capacity
        parameters.discharge_line_loss = grab_discharge_line_loss()
        parameters.evaporator_description = evaporator
        parameters.fluid = fluid
        parameters.hertz = grab_hertz()
        parameters.lower_approach = lower_approach
        parameters.lower_capacity = lower_capacity.toString(whole_number_format)
        parameters.model_number = chiller_model
        parameters.operating_limits_message = operating_limits_message
        parameters.pressure_drop_message = pressure_drop_message
        parameters.range_message = range_message
        parameters.refrigerant = grab_refrigerant().value
        parameters.suction_line_loss = grab_suction_line_loss()
        parameters.upper_approach = upper_approach
        parameters.upper_capacity = upper_capacity.toString(whole_number_format)

        Return parameters
    End Function

    Private Function grab_suction_line_loss() As Double
        Return cbo_suction_loss.selectedItem
    End Function

    Private Function grab_altitude() As Double
        Return ConvertNull.ToInteger(txt_altitude.text)
    End Function

    Private Function grab_hertz() As Integer
        Return cbo_hertz.SelectedItem
    End Function

    Private Function get_evaporator_iplv_context() As chillers.evaporator_iplv_context
        Dim context = New chillers.evaporator_iplv_context()
        context.evaporator_part_number = grab_evaporator_model()
        context.service = evaporator_service
        '        context.spec_used_for_balance = grab_evaporator_spec()
        context.spec_used_for_balance = grab_evaporator_spec_for_iplv()


        '
        Return context
    End Function

    Private Sub show_balance_report(ByVal points As balance.point_list)
        cd.clean()
        For Each point In points
            If point.validators.is_valid Then
                cd.InsertResults(point.leaving_fluid_temp, point.ambient, point.evaporating_temp, point.condensing_temp, _
                                 point.capacity, point.unit_kw, point.compressor_kw, point.gpm, point.fluid_pressure_drop, _
                                 point.compressor_kw_per_ton, point.unit_kw_per_ton)
            End If
        Next

        Dim table = cd.dt.Copy()
        Dim report = New report_factory().create(reports.file_paths.EvaporativeCooledChillerRatingReportFilePath)
        report.source = table

        Dim parameters = get_report_parameters(points)

        report.pass("authorization", "Engineer")
        report.pass("version", parameters.application_version)
        ' ambient Temperature (so row with entered Ambient and Leaving Fluid Temp can be uniquely formatted)
        report.pass("design_ambient", parameters.ambient)
        report.pass("design_leaving_fluid_temperature", parameters.leaving_fluid_temperature)
        report.pass("pfdTest", "False")
        Dim division = "TSI"
        If user.can(choose_report_logo) Then
            division = New which_division().ask({"TSI", "CRI", "RSI", "RAE"})
        End If
        report.pass("logo", division)
        report.pass("creator", AppInfo.User.username)
        report.pass("MaxAT", CStr(CDbl(txt_ambient.Text) + CDbl(txtATMax.Text)))

        report.pass("model_number", parameters.model_number)
        report.pass("condenser_description", parameters.condenser_description)
        report.pass("evaporator_description", parameters.evaporator_description)
        report.pass("compressor_description", parameters.compressor_description)
        report.pass("fluid", parameters.fluid)
        report.pass("refrigerant", parameters.refrigerant)
        report.pass("hertz", parameters.hertz)
        report.pass("altitude", parameters.altitude)

        report.pass("lower_approach", parameters.lower_approach)
        report.pass("upper_approach", parameters.upper_approach)
        report.pass("lower_capacity", parameters.lower_capacity) 'capacity
        report.pass("upper_capacity", parameters.upper_capacity)
        report.pass("condenser_capacity", parameters.condenser_capacity)
        report.pass("discharge_line_loss", parameters.discharge_line_loss)
        report.pass("suction_line_loss", parameters.suction_line_loss)

        Dim notes = ""
        If Not String.IsNullOrEmpty(parameters.operating_limits_message) Then _
           notes &= parameters.operating_limits_message & newLine
        If Not String.IsNullOrEmpty(parameters.catalog_message) Then _
           notes &= parameters.catalog_message & newLine
        If Not String.IsNullOrEmpty(parameters.range_message) Then _
           notes &= parameters.range_message & newLine
        If Not String.IsNullOrEmpty(parameters.pressure_drop_message) Then _
           notes &= parameters.pressure_drop_message
        report.pass("notes", notes)

        report.pass("pfdCircuit", " ")

        report.show()
    End Sub

    Private Sub show_word_report(ByVal points As balance.point_list)
        cd.clean()
        For Each point In points
            If point.validators.is_valid Then
                cd.InsertResults(point.leaving_fluid_temp, point.ambient, point.evaporating_temp, point.condensing_temp, _
                                 point.capacity, point.unit_kw, point.compressor_kw, point.gpm, point.fluid_pressure_drop, _
                                 point.compressor_kw_per_ton, point.unit_kw_per_ton)
            End If
        Next

        Dim table = cd.dt.Copy()
        Dim report = New rae.reporting.beta.report(reports.file_paths.evaporative_condenser_chiller_balance_file_path)

        Dim parameters = get_report_parameters(points)

        Dim text = New dictionary(Of String, String)
        'text.add("MaxAT", CStr(CDbl(txt_ambient.Text) + CDbl(txtATMax.Text)))
        ' ambient Temperature (so row with entered Ambient and Leaving Fluid Temp can be uniquely formatted)
        'text.add("design_ambient", parameters.ambient)
        'text.add("design_leaving_fluid_temperature", parameters.leaving_fluid_temperature)

        text.add("application_version", parameters.application_version)
        text.add("user", user.username)
        text.add("year", Date.now.year)
        text.add("date_created", Date.now.ToShortDateString)
        text.add("model", parameters.model_number)
        text.add("condenser_description", parameters.condenser_description)
        text.add("evaporator_description", parameters.evaporator_description)
        text.add("compressor_description", parameters.compressor_description)
        text.add("fluid", parameters.fluid)
        text.add("refrigerant", parameters.refrigerant)
        text.add("hertz", parameters.hertz)
        text.add("altitude", parameters.altitude & " ft")

        text.add("capacity_at_8", parameters.lower_capacity.BTUH) 'capacity
        text.add("capacity_at_10", parameters.upper_capacity.BTUH)
        text.add("condenser_capacity", parameters.condenser_capacity.BTUH)
        text.add("discharge_line_loss", parameters.discharge_line_loss.F)
        text.add("suction_line_loss", parameters.suction_line_loss.F)

        Dim notes = New list(Of String)
        If parameters.operating_limits_message.is_set Then notes.add(parameters.operating_limits_message)
        If parameters.catalog_message.is_set Then notes.add(parameters.catalog_message)
        If parameters.range_message.is_set Then notes.add(parameters.range_message)
        If parameters.pressure_drop_message.is_set Then notes.add(parameters.pressure_drop_message)

        Dim command = New get_logo_file_path_command(user, AppInfo.division.toString)
        Dim logo_file_path = command.execute

        table.columns("TW").ColumnName = "Leaving Fluid [°F]"
        table.columns("TA").ColumnName = "Ambient Wet Bulb [°F]"
        table.columns("TE").ColumnName = "Evap [°F]"
        table.columns("TC").ColumnName = "Condenser [°F]"
        table.Columns("Q").ColumnName = "Est. Capacity [Tons]"
        table.columns("UKW").ColumnName = "Unit [KW]"
        table.columns("KW").ColumnName = "Comp [KW]"
        table.columns("GP").ColumnName = "GPM"
        table.columns("A").ColumnName = "Evap PD"
        table.columns("ER").ColumnName = "Comp [KW/Ton]"
        table.columns("EZ").ColumnName = "Unit [KW/Ton]"

        report.set_text(text)
        report.set_list("notes", notes)
        report.set_table("table", table, New Rae.reporting.beta.exavorative_condensor_chiller_balance_report_table_factory, parameters.leaving_fluid_temperature, parameters.ambient)
        report.set_image("logo", logo_file_path)
        If user.is_rep Then report.remove("employee_section")
        report.show()
    End Sub

    Private Function grab_discharge_line_loss() As Double
        Return cbo_discharge_loss.SelectedItem
    End Function

    'todo: remove duplicate of watt calculation in chiller.circuit
    Private Function calculate_watts(ByVal hp As Double, ByVal coilQuantity As Double) As Double
        Return hp * 877.3 * coilQuantity
    End Function

    Private Sub update_watts_and_capacity(ByVal circuit As Integer)
        Dim condenser_capacity_factor = ConvertNull.ToDouble(txt_condenser_capacity_factor.Text.Trim)

        Dim condenser = grab_condenser()
        Dim condenser_quantity = CDbl(txt_condenser_quantity.Text)

        Dim condenser_is_standard = Not condenser.is_custom
        txt_condenser_capacity.readonly = condenser_is_standard
        txt_fan_motor_hp.readonly = condenser_is_standard
        txt_pump_motor_hp.readonly = condenser_is_standard
        txt_custom_condenser_model.visible = condenser.is_custom
        lbl_custom_condenser_model.visible = condenser.is_custom

        txt_condenser_capacity.text = condenser.capacity
        txt_fan_motor_hp.text = condenser.fan_hp
        txt_pump_motor_hp.text = condenser.pump_hp

        Dim fan_watts = calculate_watts(condenser.fan_hp, condenser_quantity)
        Dim pump_watts = calculate_watts(condenser.pump_hp, condenser_quantity)

        txt_total_fan_watts.text = round(fan_watts)
        txt_total_pump_watts.text = round(pump_watts)

        If sound_attenuation_option_control IsNot Nothing And loaded Then
            sound_attenuation_option_control.notify_user = False
            sound_attenuation_option_controller.update_watts()
            sound_attenuation_option_control.notify_user = True
        End If
    End Sub

    Private Function grab_voltage() As Integer
        Return cbo_voltage.selectedItem.value
    End Function

    Private Function grab_refrigerant() As refrigerant
        Return cbo_refrigerant.selectedItem
    End Function

    Private Function grab_condenser_quantity() As Double
        Return val(txt_condenser_quantity.text)
    End Function

    Private Function grab_chiller() As chiller
        Dim model = grab_chiller_model()
        Dim voltage = grab_voltage()

        Dim chiller = service.get(model, voltage)
        chiller.evaporator_model = grab_evaporator_model()
        chiller.refg = grab_refrigerant()
        chiller.condenser = grab_condenser()
        chiller.condenser_quantity = grab_condenser_quantity()
        chiller.total_fan_watts = val(txt_total_fan_watts.text)
        chiller.total_pump_watts = val(txt_total_pump_watts.text)

        Dim c1 = chiller.circuits(0)
        c1.compressor = grab_compressor_1()
        c1.compressor_qty = val(txt_compressor_qty_1.Text)

        If chiller.num_circuits > 1 Then
            Dim c2 = chiller.circuits(1)
            c2.compressor = grab_compressor_2()
            c2.compressor_qty = val(txt_compressor_qty_2.text)
        End If

        Return chiller
    End Function

    Function grab_spec() As spec
        Dim spec As spec

        Dim number_of_circuits = CInt(txt_circuit_per_unit.text)
        Dim lower_approach, upper_approach As Double
        If evaporator_grid_1.CustomSelected Then
            lower_approach = 8
            upper_approach = 10
            spec.capacity_at_lower_approach_for_circuit_1_if_custom_evaporator = evaporator_grid_1.txtCustomCapacity1At8.text
            spec.capacity_at_upper_approach_for_circuit_1_if_custom_evaporator = evaporator_grid_1.txtCustomCapacity1At10.text
            If number_of_circuits > 1 Then
                spec.capacity_at_lower_approach_for_circuit_2_if_custom_evaporator = evaporator_grid_1.txtCustomCapacity2At8.text
                spec.capacity_at_upper_approach_for_circuit_2_if_custom_evaporator = evaporator_grid_1.txtCustomCapacity2At10.text
            End If
        Else
            lower_approach = evaporator_grid_1.SelectedLowerApproach.approach
            upper_approach = evaporator_grid_1.SelectedUpperApproach.approach
        End If

        spec.ambient = AmbientTemp
        spec.ambient_upper_range = txtATMax.text
        spec.ambient_lower_range = txtATMin.text
        spec.ambient_step = txtATIncrement.text
        spec.catalog_rating = chk_catalog_rating.checked
        spec.compressor_amp_factor = txt_compressor_amp_factor.text
        spec.compressor_capacity_factor = txt_compressor_capacity_factor.text
        spec.condenser_capacity_factor = txt_condenser_capacity_factor.text
        spec.discharge_line_loss = grab_discharge_line_loss()
        spec.fluid = grab_fluid()
        spec.hertz = cbo_hertz.selectedItem
        spec.leaving_fluid_temp = LeavingFluidTemp
        spec.leaving_fluid_temp_upper_range = val(txtLeavingFluidTemperatureUpperVariance.text)
        spec.leaving_fluid_temp_lower_range = val(txtLeavingFluidTemperatureLowerVariance.text)
        spec.leaving_fluid_temp_step = txtLeavingFluidTemperatureStep.text
        spec.lower_approach = lower_approach
        spec.upper_approach = upper_approach
        spec.specific_gravity = txt_specific_gravity.text
        spec.specific_heat = txt_specific_heat.text
        spec.subcooling_temp = txt_subcooling.text
        spec.suction_line_loss = cbo_suction_loss.selectedItem
        spec.range = txt_range.text
        spec.user = user

        Return spec
    End Function

    Private Function grab_condenser() As evaporative_condenser
        Dim condenser = CType(cbo_condenser_model.selectedItem, evaporative_condenser)

        If condenser.is_custom Then
            condenser.model = txt_custom_condenser_model.text
            condenser.capacity = grab_condenser_capacity()
            condenser.fan_hp = txt_fan_motor_hp.text
            condenser.pump_hp = txt_pump_motor_hp.text
        End If

        Return condenser
    End Function

    Private Function grab_condenser_capacity() As Double
        Return val(txt_condenser_capacity.text)
    End Function

    Private Function calculate_page() As balance.point_list
        Dim refg = grab_refrigerant()
        Dim glycol_percentage = grabGlycolPerc()

        lblOperLimi.Visible = False
        lblErro.Text = ""


        ' *** VALIDATE CONTROLS ***
        'todo: do validation in try...catch, if exception occurs catch and add validator (ExceptionValidator)
        Dim control_validators = New validator_list()

        Dim fluid = grab_fluid()
        If fluid <> CoolingMedia.Water Then
            'controlValidation.Add( New GlycolPercentageShouldBePositiveNumberAndAllowPercentSign(txtGlycolPercentage.Text) )
            'controlValidation.Add( New GlycolPercentageShouldBeGreaterThan(0, txtGlycolPercentage.Text) )
        End If

        calculate_freeze_point_and_suction_temp(fluid, glycol_percentage)  'set freeze point and suction temp controls

        specific_heat_and_gravity_controller.calculate()

        control_validators.Add(New specific_heat_should_be_greater_than_zero(txt_specific_heat.Text))

        control_validators.validate()
        If control_validators.is_invalid Then
            lblErro.Text = control_validators.messages.toString()
            Return Nothing
        ElseIf lbo_compressors_1.SelectedIndex = -1 Then
            lblErro.Text = "Please select a compressor before running balance"
            Return Nothing
        End If

        Dim evaporators = show_evaporator_data_over_approach_range()

        If evaporator_grid_1.CustomSelected Then
            control_validators.add(New custom_evaporator_capacities_should_not_be_zero(evaporator_grid_1))
        Else
            control_validators.add(New selected_approach_should_be_available(evaporator_grid_1))
        End If
        'controlValidation.Add( New SpecificGravityShouldBePositiveNumber(txtSpecificHeat.Text) )
        'controlValidation.Add( New SpecificGravityShouldBeGreaterThanZero(txtSpecificHeat.Text) )

        control_validators.validate()

        If control_validators.is_invalid Then
            invalidate_results()
            lblErro.Text = ""
            lblErro.Text &= control_validators.messages.toString()
            Return Nothing
        End If

        Dim series = cbo_series.SelectedItem.ToString()

        Dim chiller = grab_chiller()
        Dim spec = grab_spec()

        Dim balance = New balance()
        Dim points = balance.run(chiller, evaporators, spec)

        points = add_validators_to(points, chiller)

        Dim using_custom_evaporator = evaporator_grid_1.CustomSelected

        Dim table = New evaporative_condenser_chiller_table(spec.leaving_fluid_temp, spec.ambient)
        Dim result_table = table.create(points, using_custom_evaporator)
        panGrid.controls.clear()
        panGrid.controls.add(result_table)

        Dim point_at_design_conditions = points.at(spec.leaving_fluid_temp, spec.ambient)
        If point_at_design_conditions Is Nothing Then
            txt_approach.text = "NA"
        Else
            txt_approach.text = point_at_design_conditions.approach
        End If

        Return points
    End Function


    Private Function add_validators_to(ByVal points As point_list, ByVal chiller As chiller) As point_list
        For Each point In points
            Dim compressor = chiller.circuits(0).compressor
            Dim compressor_validator = compressor.validate(point.evaporating_temp, point.condensing_temp)
            point.validators.add(compressor_validator)

            If chiller.num_circuits > 1 Then
                Dim compressor2 = chiller.circuits(0).compressor
                Dim compressor2_validator = compressor2.validate(point.evaporating_temp, point.condensing_temp)
                point.validators.add(compressor2_validator)
            End If

            Dim recommended_min_evaporating_temp = grab_min_suction_temp()
            Dim evaporating_temp_validator = New evaporating_temp_satisfies_recommendation(point.evaporating_temp, recommended_min_evaporating_temp)
            point.validators.add(evaporating_temp_validator)
        Next

        Return points
    End Function

    Private Sub txt_fan_motor_hp_text_changed() Handles txt_fan_motor_hp.textChanged
        Dim hp As Double = txt_fan_motor_hp.text
        Dim quantity As Double = grab_condenser_quantity()
        txt_total_fan_watts.text = round(calculate_watts(hp, quantity))
    End Sub

    Private Sub txt_pump_motor_hp_text_changed() Handles txt_pump_motor_hp.textChanged
        Dim hp As Double = convertNull.toDouble(txt_pump_motor_hp.text)
        Dim quantity As Double = grab_condenser_quantity()
        txt_total_pump_watts.text = round(calculate_watts(hp, quantity))
    End Sub

    Private Sub numberTextBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
    Handles txt_compressor_capacity_factor.KeyDown, txt_compressor_amp_factor.KeyDown, txt_condenser_capacity_factor.KeyDown, txt_range.KeyDown, txt_specific_heat.KeyDown, txt_specific_gravity.KeyDown, txt_glycol_percentage.KeyDown, txt_ambient.KeyDown, txt_leaving_fluid_temp.KeyDown, txt_subcooling.KeyDown, txtLeavingFluidTemperatureLowerVariance.KeyDown, txtLeavingFluidTemperatureUpperVariance.KeyDown, txtLeavingFluidTemperatureStep.KeyDown, txtATMin.KeyDown, txtATMax.KeyDown, txtATIncrement.KeyDown, txt_compressor_qty_1.KeyDown, txt_compressor_qty_2.KeyDown, txt_condenser_quantity.KeyDown, txt_condenser_capacity.KeyDown, txtEvaporatorCapacity.KeyDown, txt_fan_motor_hp.keyDown, txt_pump_motor_hp.keyDown
        If Not DesignMode Then _
           e.SuppressKeyPress = Not key_code.is_number(e.KeyCode)
    End Sub

    Private Sub number_textbox_keypress(ByVal sender As Object, ByVal e As KeyPressEventArgs) _
    Handles txt_glycol_percentage.KeyPress
        Debug.WriteLine("Key Pressed: " & e.KeyChar.ToString())
        If e.KeyChar.ToString() = "%" Then e.handled = True
    End Sub

    Private Sub jot(ByVal message As String)
        System.Diagnostics.Debug.WriteLine(message)
    End Sub

    Private Function resultset(ByVal tw, ByVal ta, ByVal te, ByVal tc, ByVal q, ByVal ukw, ByVal ckw, ByVal gpm, ByVal eer, ByVal ueer) As String
        Return Rae.Io.Text.Str("tw:{0} ta:{1} - te:{2} tc:{3} q:{4} ukw:{5} ckw:{6} gpm:{7} eer:{8} ueer:{9}", _
                               Round(tw), Round(ta), Round(te), Round(tc), Round(q), Round(ukw), Round(ckw), Round(gpm), Round(eer, 2), Round(ueer, 2))
    End Function

    Private Function start_calculations() As balance.point_list
        Dim altitude = grab_altitude()
        'todo: shouldn't have business logic in ui
        If altitude >= 5000 Then
            warn("Contact factory for altitudes of 5000 feet or higher.")
            invalidate_results()
            Return Nothing
        End If

        Return calculate_page()
    End Function

    Private Sub invalidate_results()
        panGrid.controls.clear()
        lblErro.Text() = ""
    End Sub

    ' sets freeze point & suction temperature based on glycol
    Private Sub calculate_freeze_point_and_suction_temp(ByVal fluid As CoolingMedia, ByVal glycolPerc As Double)
        Dim glycol = New FluidFactory().Create(fluid, glycolPerc)

        If glycol.PercentageInRange Then
            txt_freeze_point.Text = glycol.FreezePoint
            txt_min_suction.Text = glycol.MinSuctionTemp
        Else
            warn(msg(glycol.Min, glycol.Max))
            txt_glycol_percentage.Text = "20"
        End If
    End Sub

    Private Sub set_circuit_1_controls(ByVal chiller As chiller)
        txt_evaporator_model.Text = chiller.evaporator_model
        Dim circuit = chiller.circuits(0)

        txt_compressor_qty_1.Text = circuit.compressor_qty
        txt_condenser_quantity.Text = chiller.condenser_quantity

        cbo_condenser_model.SelectedIndex = cbo_condenser_model.Items.IndexOf(chiller.condenser)

        update_watts_and_capacity(circuit:=1)

        Txt_circuit_per_unit.Text = chiller.num_circuits

        Me.DisplaySystemCapacity(Average(chiller.min_capacity, chiller.max_capacity))

        Dim found = select_compressor(lbo_compressors_1, circuit.compressor.model)
        If Not found Then
            If opening_standard Then
                lbo_compressors_1.selectedIndex = 0
            Else
                alert("The compressor, " & circuit.compressor.model & ", is not available.")
                lbo_compressors_1.selectedIndex = 0
            End If
        End If
        txt_compressor_1.Text = lbo_compressors_1.selectedItem.model

        set_chiller_evaporator_controls(chiller.evaporator_model)
        specific_heat_and_gravity_controller.calculate()
        show_evaporator_data_over_approach_range()
    End Sub


    Private Sub set_circuit_2_controls(ByVal chiller As chiller)
        txt_evaporator_model.Text = chiller.evaporator_model

        Dim circuit = chiller.circuits(1)

        txt_compressor_qty_2.Text = circuit.compressor_qty

        Txt_circuit_per_unit.Text = chiller.num_circuits

        DisplaySystemCapacity(Average(chiller.min_capacity, chiller.max_capacity))

        Dim found = select_compressor(lbo_compressors_2, circuit.compressor.model)
        If Not found Then
            alert("The compressor, " & circuit.compressor.model & ", is not available.")
            lbo_compressors_2.selectedIndex = 0
        End If
        txt_compressor_2.Text = lbo_compressors_2.selectedItem.model

        show_evaporator_data_over_approach_range()
    End Sub

#End Region


#Region " Private Methods"

#Region " UI"

    Private Sub cbo_volts_SelectedIndexChanged() Handles cbo_voltage.SelectedIndexChanged
        If loaded Then
            Dim refg = grab_refrigerant()
            fill_compressor_listboxes(refg)

            cbo_models_SelectedIndexChanged()
        End If
    End Sub

    Private Function grab_chiller_model() As String
        Return cbo_models.SelectedItem
    End Function

    Function grab_fluid() As CoolingMedia
        Dim fluid As CoolingMedia

        If cbo_fluid.SelectedItem.ToString = "Water" Then
            fluid = CoolingMedia.Water
        Else ' is glycol
            If cbo_glycol.SelectedItem.ToString = "Ethylene" Then
                fluid = CoolingMedia.Ethylene
            ElseIf cbo_glycol.SelectedItem.ToString = "Propylene" Then
                fluid = CoolingMedia.Propylene
            End If
        End If

        Return fluid
    End Function

    Private Function grabGlycolPerc() As Double
        If txt_glycol_percentage.Text = "" Then Return 0
        Return CDbl(txt_glycol_percentage.Text.Trim)
    End Function

    Private Function grab_compressor_1() As compressor
        Return lbo_compressors_1.SelectedItem
    End Function

    Private Function grab_compressor_2() As compressor
        Return lbo_compressors_2.SelectedItem
    End Function

    Private Function GrabSpecificGravity() As Single
        Return Round(CSng(Me.txt_specific_gravity.Text.Trim), 2)
    End Function

    Private Function GrabSpecificHeat() As Single
        Return CSng(Me.txt_specific_heat.Text.Trim)
    End Function

    Private Function grab_min_suction_temp() As Single
        Return CSng(txt_min_suction.Text.Trim)
    End Function

    Private Function GrabTemperatureRange() As Single
        Return CSng(Me.txt_range.Text.Trim)
    End Function

    Private Function GrabSystemCapacity() As Single
        Return CSng(Me.txtEvaporatorCapacity.Text.Trim)
    End Function

    Private Function GrabSystemCapacityBtuh() As Single
        Dim systemCapacityBtuh As Single
        If Me.radTons.Checked Then
            ' grabs system capacity from textbox
            systemCapacityBtuh = Convert.TonsToBtuh(GrabSystemCapacity())
        ElseIf Me.radGpm.Checked Then
            ' converts from gpm to btuh
            systemCapacityBtuh = Convert.GpmToBtuh(Me.GrabSystemCapacity(), Me.GrabTemperatureRange(), _
               Me.GrabSpecificHeat(), Me.GrabSpecificGravity())
        End If
        Return systemCapacityBtuh
    End Function

    Private Function grab_evaporator_model() As String
        Return Me.txt_evaporator_model.Text.Trim
    End Function


    Private Sub DisplaySystemCapacity(ByVal capacityTons As Single)
        If Me.radTons.Checked Then  'Tons 
            Me.txtEvaporatorCapacity.Text = Round(capacityTons, 2)
        ElseIf radGpm.Checked Then  'GPM 
            Me.txtEvaporatorCapacity.Text = _
               Convert.TonsToGpm(capacityTons, Me.GrabTemperatureRange(), Me.GrabSpecificHeat(), Me.GrabSpecificGravity())
            'Me.txtEvaporatorCapacity.Text = Common.Convert.TonsToGpm(Common.Math.Average(minCapacity, maxCapacity), _
            '   temperatureRange, specificHeat, specificGravity)
        End If
    End Sub

    Private Sub ColorControls()
        With New ColorManager
            Me.pan_model.BackColor = .LightBlue
            Me.lblErro.BackColor = .LightBlue
            Me.pan_footer.BackColor = .LightBlue

            ' colors comments
            Me.lbl_subcooling_f.ForeColor = .GreyBlue
            Me.lbl_min_suction_f.ForeColor = .GreyBlue
            Me.lblAmbientF.ForeColor = .GreyBlue
            Me.lbl_freeze_point_f.ForeColor = .GreyBlue
            Me.lblLeavingFluidF.ForeColor = .GreyBlue
            Me.lbl_range_f.ForeColor = .GreyBlue

            Me.lblAltitudeFt.ForeColor = .GreyBlue
            Me.lbl_discharge_loss_F.ForeColor = .GreyBlue
            Me.lbl_suction_loss_F.ForeColor = .GreyBlue
            Me.lblCondenserCapacityBtuh.ForeColor = .GreyBlue
        End With
    End Sub

    Private Sub set_chiller_evaporator_controls(ByVal evaporatorModel As String)
        Dim evaporator As Solutions.Chillers.Evaporator1

        'todo: bind and get evaporator data from evaporator combobox
        Try
            evaporator = BCA.RetrieveChillerEvaporator(evaporatorModel)
        Catch ex As OleDb.OleDbException
            alert("Attempt to retrieve the chiller's evaporator information failed. " & ex.Message)
            Exit Sub
        End Try

        txt_Evap_Length.Text = evaporator.Length

        txt_evaporator_model.Text = evaporatorModel

        ToolTip1.SetToolTip(txt_model, evaporator.ToString())
        ToolTip1.SetToolTip(lblModel, evaporator.ToString())

    End Sub


    Private Sub initialize_controls_for_rep()
        pan_factors.visible = False

        cbo_refrigerant.enabled = False

        cbo_hertz.enabled = False

        cboFoulingFactor.Visible = True

        lbl_approach.visible = False
        txt_approach.visible = False

        lbl_subcooling.visible = False
        lbl_subcooling_f.visible = False
        txt_subcooling.visible = False

        pan_range.visible = False

        chk_safety_override.Visible = False

        lbl_suction_loss.visible = False
        lbl_suction_loss_F.visible = False
        cbo_suction_loss.visible = False

        lbl_discharge_loss.visible = False
        lbl_discharge_loss_F.visible = False
        cbo_discharge_loss.visible = False

        txt_condenser_quantity.ReadOnly = True

        cbo_condenser_model.enabled = False

        txt_total_pump_watts.enabled = False

        txt_total_fan_watts.enabled = False

        txt_condenser_capacity.enabled = False

        evaporator_grid_1.visible = False
        evaporator_grid_1.parent.height = evaporator_grid_1.parent.height - evaporator_grid_1.height

        chk_catalog_rating.checked = True
        chk_catalog_rating.visible = False
    End Sub


    Private Sub fill_compressor_listboxes(ByVal refg As refrigerant, Optional ByVal chiller_model As String = Nothing)
        Dim voltage = grab_voltage()
        If chiller_model Is Nothing Then _
           chiller_model = grab_chiller_model()
        Dim standard_hp = service.get(chiller_model, voltage).circuits(0).compressor.hp

        Dim compressors = service.get_compressors(refg, voltage, standard_hp, user)

        lbo_compressors_1.items.clear()
        lbo_compressors_2.items.clear()

        For Each compressor In compressors
            lbo_compressors_1.items.add(compressor)
            lbo_compressors_2.items.add(compressor)
        Next
    End Sub


#End Region


    ' TODO: move declarations to top of class
    Private chillerVMgr As ValidationManager
    Private leavingFluidTempVCtrl As ValidationControl

    Private Sub initializeValidation()
        Dim leavingFluidTempName As String = "Leaving fluid temperature textbox"

        Me.chillerVMgr = New ValidationManager(Me.err)
        Me.leavingFluidTempVCtrl = New ValidationControl(txt_leaving_fluid_temp)

        Dim leavingFluidTempReqV = New RequiredValidator(ErrorMessages.Required(leavingFluidTempName))
        Dim leavingFluidTempNumV = New RegularExpressionValidator( _
           ErrorMessages.Number(leavingFluidTempName), _
           regular_expressions.number)
        Dim leavingFluidTempRangeV = New AmongRangeValidator( _
           ErrorMessages.Range(leavingFluidTempName, LEAVING_FLUID_TEMP_LOWER_LIMIT, LEAVING_FLUID_TEMP_UPPER_LIMIT), _
           LEAVING_FLUID_TEMP_LOWER_LIMIT, _
           LEAVING_FLUID_TEMP_UPPER_LIMIT)

        Me.chillerVMgr.ValidationControls.Add(Me.leavingFluidTempVCtrl)

        Me.leavingFluidTempVCtrl.Validators.Add(leavingFluidTempRangeV)
        Me.leavingFluidTempVCtrl.Validators.Add(leavingFluidTempReqV)
        Me.leavingFluidTempVCtrl.Validators.Add(leavingFluidTempNumV)
    End Sub

    Private subcooling_option_control, sound_attenuation_option_control As i_option_control
    Private sound_attenuation_option_controller As sound_attenuation_option.controller
    Private specific_heat_and_gravity_controller As specific_heat_and_gravity.controller

    Private Sub initialize_controls()
        ' adds subcooling circuit option control
        subcooling_option_control = New option_control()
        pan_options_content.controls.add(subcooling_option_control)
        Dim pricing_repository = New pricing_repository()
        Dim subcooling_option_controller = New subcooling_circuit_option.controller(subcooling_option_control, txt_subcooling, pricing_repository)

        ' adds sound attention option control
        sound_attenuation_option_control = New option_control()
        Dim sound_attenuation_option_context = New sound_attenuation_option.static_context()
        sound_attenuation_option_context.fan_watts_control = txt_total_fan_watts
        sound_attenuation_option_context.fan_hp_control = txt_fan_motor_hp
        sound_attenuation_option_context.option_control = sound_attenuation_option_control
        sound_attenuation_option_context.grab_dynamic_context = AddressOf grab_sound_attenuation_option_context

        pan_options_content.controls.add(sound_attenuation_option_control)
        Me.sound_attenuation_option_controller = New sound_attenuation_option.controller(sound_attenuation_option_context)

        ' initialize specific heat and gravity
        Dim controls As specific_heat_and_gravity.controls
        controls.leaving_fluid_temperature_control = txt_leaving_fluid_temp
        controls.temperature_range_control = txt_range
        controls.fluid_control = cbo_fluid
        controls.glycol_control = cbo_glycol
        controls.glycol_percentage_control = txt_glycol_percentage
        controls.specific_gravity_control = txt_specific_gravity
        controls.specific_heat_control = txt_specific_heat

        specific_heat_and_gravity_controller = New specific_heat_and_gravity.controller(controls, service)

        cbo_hertz.SelectedIndex = 0

        cbo_fluid.SelectedIndex = 0
        cbo_glycol.SelectedIndex = 0
        cbo_suction_loss.selectedIndex = 1
        cbo_discharge_loss.selectedIndex = 1

        cbo_series.SelectedIndex = 0
    End Sub

    Private Function grab_sound_attenuation_option_context() As sound_attenuation_option.dynamic_context
        Dim context As sound_attenuation_option.dynamic_context

        If Not loaded Then
            Return Nothing
        Else
            context.chiller = grab_chiller()
        End If

        Return context
    End Function

    Private Function chiller_model_is_selected() As Boolean
        Dim chiller_model = grab_chiller_model

        Dim invalid = String.isNullOrEmpty(chiller_model) _
                      OrElse chiller_model = "Choose"
        Return Not invalid
    End Function

    Private opening_standard As Boolean

    Sub LoadControls(ByVal process_item As EvaporativeCondenserChillerBalance)
        ' If latest revision has not been set then
        ' we need to set it now  based on the ID...
        If Me.m_LatestRevision = 0 Then
            Me.m_LatestRevision = Rae.RaeSolutions.DataAccess.Projects.ProcessItemDA.LastestRevision(Me.Tag)
        End If

        ' Increment the current process revision
        ' displayed on this form...
        Me.m_CurrentRevision = process_item.Revision

        ' Clone last saved process to passing process item
        LastSavedProcess = process_item.Clone()

        ' changes model to default (ss50)
        cbo_series.Text = LastSavedProcess.Series

        loaded = False
        Dim index_to_select As Integer
        For i As Integer = 0 To cbo_voltage.items.count - 1
            If cbo_voltage.items(i).value = LastSavedProcess.Volts Then
                index_to_select = i : Exit For
            End If
        Next
        cbo_voltage.selectedIndex = index_to_select
        loaded = True
        cbo_refrigerant.Text = LastSavedProcess.Refrigerant

        'fill_compressor_listboxes(grab_refrigerant())
        fill_compressor_listboxes(grab_refrigerant(), LastSavedProcess.Model)
        opening_standard = True ' prevents compressor not found in case saved refrigerant is not standard
        model_changed_schedule.Disable()
        Dim previousModelIndex = cbo_models.SelectedIndex
        cbo_models.Text = LastSavedProcess.Model
        Dim loadedModelIndex = cbo_models.SelectedIndex
        If previousModelIndex = loadedModelIndex Then _
           model_changed() 'forces updates if model was default
        txt_model.Text = LastSavedProcess.ModelDesc
        model_changed_schedule.Enable()
        opening_standard = False

        subcooling_option_control.notify_user = False
        subcooling_option_control.checked = LastSavedProcess.subcooling_coil_option_selected
        subcooling_option_control.notify_user = True

        sound_attenuation_option_control.notify_user = False
        sound_attenuation_option_control.checked = LastSavedProcess.sound_attenuation_option_selected
        sound_attenuation_option_control.notify_user = True

        cbo_fluid.Text = LastSavedProcess.Fluid
        txt_glycol_percentage.Text = LastSavedProcess.GlycolPercentage
        cbo_glycol.Text = LastSavedProcess.CoolingMedia
        txt_specific_heat.Text = LastSavedProcess.SpecificHeat
        txt_specific_gravity.Text = LastSavedProcess.SpecificGravity
        txt_subcooling.Text = LastSavedProcess.SubCooling
        txt_range.Text = LastSavedProcess.TempRange
        txt_ambient.Text = LastSavedProcess.AmbientTemp
        txt_leaving_fluid_temp.Text = LastSavedProcess.LeavingFluidTemp
        cbo_hertz.Text = LastSavedProcess.Hertz
        txt_approach.Text = LastSavedProcess.Approach
        txtLeavingFluidTemperatureLowerVariance.Text = LastSavedProcess.TEMin
        txtLeavingFluidTemperatureUpperVariance.Text = LastSavedProcess.TEMax
        txtLeavingFluidTemperatureStep.Text = LastSavedProcess.TEIncrement
        txtATMin.Text = LastSavedProcess.ATMin
        txtATMax.Text = LastSavedProcess.ATMax
        txtATIncrement.Text = LastSavedProcess.ATIncrement
        chk_safety_override.Checked = LastSavedProcess.SafetyOverride

        ' compressor 1
        select_compressor(lbo_compressors_1, LastSavedProcess.Compressors1)
        txt_compressor_1.Text = LastSavedProcess.Compressors1
        txt_compressor_qty_1.Text = LastSavedProcess.NumCompressors1

        ' compressor 2
        select_compressor(lbo_compressors_2, LastSavedProcess.Compressors2)
        txt_compressor_2.Text = LastSavedProcess.Compressors2
        txt_compressor_qty_2.Text = LastSavedProcess.NumCompressors2

        txt_condenser_quantity.Text = LastSavedProcess.NumCoils1
        cbo_condenser_model.Text = LastSavedProcess.Condenser1
        txt_custom_condenser_model.text = LastSavedProcess.custom_condenser_model
        txt_fan_motor_hp.text = LastSavedProcess.fan_motor_hp
        txt_pump_motor_hp.text = LastSavedProcess.pump_motor_hp
        cbo_discharge_loss.Text = LastSavedProcess.DischargeLineLoss
        cbo_suction_loss.Text = LastSavedProcess.SuctionLineLoss
        txt_altitude.Text = LastSavedProcess.Altitude
        txt_total_pump_watts.Text = LastSavedProcess.PumpWatts
        txt_total_fan_watts.Text = LastSavedProcess.FanWatts
        txt_condenser_capacity.Text = LastSavedProcess.CondenserCapacity1
        cbo_evaporator_model.Text = LastSavedProcess.EvaporatorModel
        txt_evaporator_model.Text = LastSavedProcess.EvaporatorModelDesc
        cboNumEvap.Text = LastSavedProcess.NumEvap
        cboFoulingFactor.Text = LastSavedProcess.FoulingFactor
        If LastSavedProcess.CapacityType = EvaporativeCondenserChillerBalance.eCapacityType.Tons Then
            radTons.Checked = True
        ElseIf LastSavedProcess.CapacityType = EvaporativeCondenserChillerBalance.eCapacityType.GPM Then
            radGpm.Checked = True
        Else
            radGpm.Checked = False
            radTons.Checked = False
        End If
        txtEvaporatorCapacity.Text = LastSavedProcess.EvaporatorCapacity
        chk_catalog_rating.Checked = LastSavedProcess.CatalogRating

        If LastSavedProcess.ApproachRange = EvaporativeCondenserChillerBalance.eApproachRange.SixToEight Then
            evaporator_grid_1.rbo6To8.Checked = True
        ElseIf LastSavedProcess.ApproachRange = EvaporativeCondenserChillerBalance.eApproachRange.SevenToNine Then
            evaporator_grid_1.rbo7To9.Checked = True
        ElseIf LastSavedProcess.ApproachRange = EvaporativeCondenserChillerBalance.eApproachRange.EightToTen Then
            evaporator_grid_1.rbo8To10.Checked = True
        ElseIf LastSavedProcess.ApproachRange = EvaporativeCondenserChillerBalance.eApproachRange.NineToEleven Then
            evaporator_grid_1.rbo9To11.Checked = True
        ElseIf LastSavedProcess.ApproachRange = EvaporativeCondenserChillerBalance.eApproachRange.TenToTwelve Then
            evaporator_grid_1.rbo10To12.Checked = True
        ElseIf LastSavedProcess.ApproachRange = EvaporativeCondenserChillerBalance.eApproachRange.Other Then
            evaporator_grid_1.rboCustom.Checked = True
        End If
        evaporator_grid_1.txtCustomCapacity1At8.Text = LastSavedProcess.Evap8Degr1
        evaporator_grid_1.txtCustomCapacity2At8.Text = LastSavedProcess.Evap8Degr2
        evaporator_grid_1.txtCustomCapacity1At10.Text = LastSavedProcess.Evap10Degr1
        evaporator_grid_1.txtCustomCapacity2At10.Text = LastSavedProcess.Evap10Degr2
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

    Function SaveControls(Optional ByVal SaveAsRevision As Boolean = False, Optional ByVal SaveAsNew As Boolean = False, Optional ByVal FormClosing As Boolean = False, Optional ByVal GenerateEquipment As Boolean = False, Optional ByVal RevChanged As Boolean = False, Optional ByVal points As balance.point_list = Nothing) As Boolean

        If CurrentStateProcess Is Nothing Then
            If LastSavedProcess Is Nothing Then
                CurrentStateProcess = New EvaporativeCondenserChillerBalance(New item_id(AppInfo.User.username, AppInfo.User.password))
            Else
                CurrentStateProcess = LastSavedProcess.Clone
            End If
        Else
            If LastSavedProcess IsNot Nothing Then CurrentStateProcess = LastSavedProcess.Clone
        End If

        Dim ambient = CDbl(txt_ambient.Text)
        Dim leaving_fluid_temp = CDbl(txt_leaving_fluid_temp.Text)
        Dim chiller = grab_chiller()

        If points IsNot Nothing AndAlso points.count > 0 Then
            Dim point = points.at(leaving_fluid_temp, ambient)
            If point IsNot Nothing Then
                CurrentStateProcess.CapacityAtDesignConditions = point.capacity
                CurrentStateProcess.EvaporatorPressureDropAtDesignConditions = point.fluid_pressure_drop
                CurrentStateProcess.FlowAtDesignConditions = point.gpm
                CurrentStateProcess.unit_kw_per_ton_at_design_conditions = point.unit_kw_per_ton
            End If
        End If

        CurrentStateProcess.Series = cbo_series.Text
        CurrentStateProcess.Model = cbo_models.Text
        CurrentStateProcess.ModelDesc = txt_model.Text
        CurrentStateProcess.sound_attenuation_option_selected = sound_attenuation_option_control.checked
        CurrentStateProcess.subcooling_coil_option_selected = subcooling_option_control.checked
        CurrentStateProcess.Fluid = cbo_fluid.Text
        CurrentStateProcess.GlycolPercentage = txt_glycol_percentage.Text
        CurrentStateProcess.CoolingMedia = cbo_glycol.Text
        CurrentStateProcess.SpecificHeat = txt_specific_heat.Text
        CurrentStateProcess.SpecificGravity = txt_specific_gravity.Text
        CurrentStateProcess.SubCooling = txt_subcooling.Text
        CurrentStateProcess.Refrigerant = cbo_refrigerant.Text
        CurrentStateProcess.TempRange = txt_range.Text
        CurrentStateProcess.AmbientTemp = txt_ambient.Text
        CurrentStateProcess.LeavingFluidTemp = txt_leaving_fluid_temp.Text
        CurrentStateProcess.Hertz = cbo_hertz.Text
        CurrentStateProcess.Approach = txt_approach.Text
        CurrentStateProcess.Volts = grab_voltage() 'cbo_voltage.Text
        CurrentStateProcess.TEMin = txtLeavingFluidTemperatureLowerVariance.Text
        CurrentStateProcess.TEMax = txtLeavingFluidTemperatureUpperVariance.Text
        CurrentStateProcess.TEIncrement = txtLeavingFluidTemperatureStep.Text
        CurrentStateProcess.ATMin = txtATMin.Text
        CurrentStateProcess.ATMax = txtATMax.Text
        CurrentStateProcess.ATIncrement = txtATIncrement.Text
        CurrentStateProcess.SafetyOverride = chk_safety_override.Checked
        CurrentStateProcess.Compressors1 = txt_compressor_1.Text
        CurrentStateProcess.Compressors2 = txt_compressor_2.Text
        CurrentStateProcess.compressor_file_name_1 = chiller.circuits(0).compressor.MasterID
        If chiller.num_circuits > 1 Then
            CurrentStateProcess.compressor_file_name_2 = chiller.circuits(1).compressor.MasterID
        End If
        CurrentStateProcess.NumCompressors1 = txt_compressor_qty_1.Text
        CurrentStateProcess.NumCompressors2 = txt_compressor_qty_2.Text
        CurrentStateProcess.NumCoils1 = txt_condenser_quantity.Text
        CurrentStateProcess.Condenser1 = cbo_condenser_model.Text
        CurrentStateProcess.custom_condenser_model = txt_custom_condenser_model.text
        CurrentStateProcess.fan_motor_hp = txt_fan_motor_hp.text
        CurrentStateProcess.pump_motor_hp = txt_pump_motor_hp.text
        CurrentStateProcess.DischargeLineLoss = cbo_discharge_loss.text
        CurrentStateProcess.SuctionLineLoss = cbo_suction_loss.Text
        CurrentStateProcess.Altitude = txt_altitude.Text
        CurrentStateProcess.PumpWatts = Val(txt_total_pump_watts.Text)
        CurrentStateProcess.FanWatts = Val(txt_total_fan_watts.Text)
        CurrentStateProcess.CondenserCapacity1 = Val(txt_condenser_capacity.Text)
        CurrentStateProcess.EvaporatorModel = cbo_evaporator_model.Text
        CurrentStateProcess.EvaporatorModelDesc = txt_evaporator_model.Text
        CurrentStateProcess.NumEvap = Val(cboNumEvap.Text)
        CurrentStateProcess.FoulingFactor = Val(cboFoulingFactor.Text)
        If radTons.Checked = True Then
            CurrentStateProcess.CapacityType = EvaporativeCondenserChillerBalance.eCapacityType.Tons
        ElseIf radGpm.Checked = True Then
            CurrentStateProcess.CapacityType = EvaporativeCondenserChillerBalance.eCapacityType.GPM
        End If
        CurrentStateProcess.EvaporatorCapacity = Val(txtEvaporatorCapacity.Text)
        CurrentStateProcess.CatalogRating = chk_catalog_rating.Checked
        ' Approach range...
        If evaporator_grid_1.rbo6To8.Checked Then
            CurrentStateProcess.ApproachRange = EvaporativeCondenserChillerBalance.eApproachRange.SixToEight
        ElseIf evaporator_grid_1.rbo7To9.Checked Then
            CurrentStateProcess.ApproachRange = EvaporativeCondenserChillerBalance.eApproachRange.SevenToNine
        ElseIf evaporator_grid_1.rbo8To10.Checked Then
            CurrentStateProcess.ApproachRange = EvaporativeCondenserChillerBalance.eApproachRange.EightToTen
        ElseIf evaporator_grid_1.rbo9To11.Checked Then
            CurrentStateProcess.ApproachRange = EvaporativeCondenserChillerBalance.eApproachRange.NineToEleven
        ElseIf evaporator_grid_1.rbo10To12.Checked Then
            CurrentStateProcess.ApproachRange = EvaporativeCondenserChillerBalance.eApproachRange.TenToTwelve
        ElseIf evaporator_grid_1.CustomSelected Then
            CurrentStateProcess.ApproachRange = EvaporativeCondenserChillerBalance.eApproachRange.Other
        End If
        CurrentStateProcess.Evap8Degr1 = evaporator_grid_1.CustomCapacityCircuit1Approach8 ' Val(tbxEvap8Degr1.Text)
        CurrentStateProcess.Evap8Degr2 = evaporator_grid_1.CustomCapacityCircuit2Approach8 ' Val(tbxEvap8Degr2.Text)
        CurrentStateProcess.Evap10Degr1 = evaporator_grid_1.CustomCapacityCircuit1Approach10 ' Val(tbxEvap10Degr1.Text)
        CurrentStateProcess.Evap10Degr2 = evaporator_grid_1.CustomCapacityCircuit2Approach10 ' Val(tbxEvap10Degr2.Text)

        ' Set save process...
        Dim RevSave As New RevisionSave
        CurrentStateProcess = RevSave.SetSaveProcess(Me, Business.ProcessType.EvaporativeCondenserChiller, CurrentStateProcess, LastSavedProcess, SaveAsNew, SaveAsRevision, FormClosing, GenerateEquipment, RevChanged)
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

#End Region




    Private Sub initializeSaveToolStripPanel()
        SaveToolStripPanel1.SetUp(CType(Me.ParentForm, MainForm).mainToolStrip, _
           AddressOf mnuSave_Click, AddressOf mnuSaveAsRevision_Click)
    End Sub

    Private Sub mnuSave_Click() Handles mnuSave.Click
        SaveControls()
    End Sub

    'prints form in a format similar to the screen view
    ''Private Sub PrintToolStripMenuItem_Click() Handles mnuPrint.Click

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
    ''    doc.RenderBlockControlImage(Me.pan_model)
    ''    doc.RenderBlockControlImage(Me.panRatingCriteria)
    ''    doc.RenderBlockControlImage(Me.pan_compressor_1)

    ''    ' functions as a page return				
    ''    Dim whiteImage = Image.FromFile(AppInfo.AppFolderPath & "Images\whitebox.gif")
    ''    doc.RenderBlockImage(whiteImage, 3, doc.AvailableBlockFlowHeight, printStyle)
    ''    doc.RenderBlockControlImage(Me.pan_evaporative_condenser)

    ''    'page return		
    ''    doc.RenderBlockImage(whiteImage, 3, doc.AvailableBlockFlowHeight, printStyle)
    ''    doc.RenderBlockControlImage(Me.panEvaporator)
    ''    doc.RenderBlockControlImage(Me.panGrid)
    ''    doc.EndDoc() 'stop rendering

    ''    ''Dim formPreview As New C1PrintPreviewForm 'create instance form to preview before printing
    ''    formPreview.C1PrintPreview1.Document = doc 'set the form's document to the document just created

    ''    Me.Cursor = Windows.Forms.Cursors.Default

    ''    formPreview.ShowDialog() 'can't have mdiparent otherwise error occurs
    ''    formPreview.Close()

    ''End Sub

    Private Sub ConvertToEquipmentToolStripMenuItem_Click() Handles mnuConvert.Click
        ' Force user to save before creating equipment...
        SaveControls(False, False, False, True)
    End Sub

    Private Sub mnuSaveAsRevision_Click() Handles mnuSaveAsRevision.Click
        SaveControls(True)
    End Sub

    Private Sub mnuSaveAs_Click() Handles mnuSaveAs.Click
        SaveControls(False, True)
    End Sub

    Private Sub txt_condenser_quantity_lostFocus() _
    Handles txt_condenser_quantity.lostFocus
        If loaded And chiller_model_is_selected Then
            update_watts_and_capacity(circuit:=1)
        End If
    End Sub

    Private evaporator_service As i_evaporator_service = New evaporator_service_factory().create()

    Private Sub list_alternate_evaporators()
        If cbo_models.selectedIndex < 0 Then
            warn("Please select a chiller model")
            Exit Sub
        End If

        Dim spec = grab_evaporator_spec()

        Dim evaps = New list(Of evaporator)
        If user.is_employee Then
            evaps = evaporator_service.get_alternate_evaporators(spec)
        Else
            Dim standard_evaporator_part_number = txt_evaporator_model.text
            evaps = evaporator_service.get_alternate_evaporators_for_rep(spec, standard_evaporator_part_number)
        End If

        Dim evaporator_part_numbers = New List(Of String)
        evaporator_part_numbers.add("Choose")
        For Each evap In evaps
            evaporator_part_numbers.add(evap.evaporator_part_number)
        Next
        cbo_evaporator_model.dataSource = evaporator_part_numbers
    End Sub

    Private Function show_evaporator_data_over_approach_range() As evaporator_list
        Dim spec = grab_evaporator_spec()
        Dim evaporator_part_number = grab_evaporator_model()
        Dim range = New evaporator_list()

        Try
            If Not evaporator_grid_1.CustomSelected Then
                range = evaporator_service.get_approach_range(evaporator_part_number, spec)
                evaporator_grid_1.Show(range)
            End If
        Catch ex As StandardRefrigerationException
            evaporator_grid_1.show(Nothing)
            alert(ex.message)
        End Try

        Return range
    End Function


    Private Function grab_evaporator_spec() As evaporator_spec
        Dim mapping = New evaporator_mapper()
        Dim default_evaporator_length = CDbl(txt_Evap_Length.Text)
        Dim refg = grab_refrigerant().for_db()

        If user.is_rep Then default_evaporator_length += 13

        Dim spec As evaporator_spec
        spec.entering_fluid_temp = grab_entering_fluid_temp()
        spec.length = default_evaporator_length
        spec.glycol_percentage = grabGlycolPerc()
        spec.leaving_fluid_temp = LeavingFluidTemp
        spec.num_circuits = CDbl(Txt_circuit_per_unit.Text)
        spec.evaporating_temp = grab_min_suction_temp()
        spec.authorization = user.authority_group
        spec.fluid = mapping.map(grab_fluid)
        spec.refrigerant = mapping.map(refg)

        Return spec
    End Function

    Private Function grab_evaporator_spec_for_iplv() As evaporator_spec
        Dim evaporator_spec = grab_evaporator_spec()
        Dim leaving_fluid_temp = 44
        Dim temperature_range = 10
        evaporator_spec.entering_fluid_temp = leaving_fluid_temp + temperature_range
        evaporator_spec.fluid = StandardRefrigeration.fluid.water
        evaporator_spec.glycol_percentage = 0

        Return evaporator_spec
    End Function

    Private Function grab_entering_fluid_temp() As Double
        Return LeavingFluidTemp + GrabTemperatureRange
    End Function

    Private Sub btn_go_to_pricing_click() Handles btn_go_to_pricing.click

        If chiller_model_is_selected = False Then _
           warn("Please select a valid chiller model.") : Exit Sub

        cursor = cursors.waitCursor

        Try
            set_enabled_on_acme_related_controls(enabled:=False)
            Dim points = start_calculations()
            If points Is Nothing Then
                Dim errorMessage = "Attempt to go to pricing failed. Balance did not return any results."
                If lblErro.Text = "" Then lblErro.Text = errorMessage Else lblErro.Text &= Environment.NewLine & errorMessage
            Else
                SaveControls(False, False, False, True, points:=points)
            End If
        Catch ex As exception
            lblErro.Text = "Attempt to go to pricing failed. " & ex.message
            invalidate_results()
        Finally
            set_enabled_on_acme_related_controls(enabled:=True)
        End Try

        cursor = cursors.arrow
    End Sub




End Class

Class combobox_should_have_selection : Inherits validator_base
    Sub New(ByVal combobox As combobox, ByVal message As String)
        Me.combobox = combobox
        Me.message = message
    End Sub

    Overrides Function validate() As i_validate
        _messages = New message_list()
        valid = (combobox.selectedindex > -1)
        If Not valid Then
            _messages.add(New message(validation_status.failure, message))
        End If

        Return Me
    End Function

    Private combobox As combobox
    Private message As String
End Class

Class specific_heat_should_be_greater_than_zero : Inherits validator_base
    Sub New(ByVal specific_heat As String)
        Me.specific_heat = specific_heat
    End Sub

    Overrides Function validate() As i_validate
        valid = True
        Dim value As Double
        Try
            value = CDbl(specific_heat)
        Catch ex As exception
            valid = False
            _messages.add(New message(validation_status.failure, "specific heat should be a number."))
            Return Me
        End Try

        If value <= 0 Then
            valid = False
            _messages.add(New message(validation_status.failure, "specific heat should be greater than zero."))
        End If
        Return Me
    End Function

    Private specific_heat As String
End Class

'Class TextShouldMatchRegularExpression : Inherits validator_base
'   Sub New(text As String, regularExpression As String, message As String)
'      Me.text = text
'      Me.regularExpression = regularExpression
'      Me.message = message
'   End Sub

'   Overrides Sub Validate()
'      valid = System.Text.RegularExpressions.Regex.IsMatch(text, regularExpression)
'      If Not valid Then
'         _messages.Add( New Message(validation_status.failure, message) ) 
'      End If
'   End Sub

'   Private text, regularExpression, message As String
'End Class

Class selected_approach_should_be_available : Inherits validator_base
    Sub New(ByVal control As evaporatorgrid)
        Me.control = control
    End Sub

    Overrides Function validate() As i_validate
        valid = Not control.selectedapproachisinvalid
        _messages = New message_list()
        If Not valid Then
            Dim message = New message(validation_status.failure, "the selected approach is invalid.")
            _messages.add(message)
        End If
        Return Me
    End Function

    Private control As evaporatorgrid
End Class

Class custom_evaporator_capacities_should_not_be_zero : Inherits validator_base
    Sub New(ByVal control As evaporatorgrid)
        Me.control = control
    End Sub

    Overrides Function validate() As i_validate
        valid = Not control.customcapacityiszero
        _messages = New message_list()
        If Not valid Then
            Dim message = New message(validation_status.failure, "the custom evaporator est. capacity should not be zero.")
            _messages.add(message)
        End If
        Return Me
    End Function

    Private control As evaporatorgrid
End Class

Namespace evaporative_condenser_chillers

    Structure report_parameters
        Public model_number, application_version As String
        Public condenser_description, condenser_capacity, compressor_description, evaporator_description As String
        Public ambient, leaving_fluid_temperature, fluid, refrigerant, hertz, altitude As String
        Public operating_limits_message, pressure_drop_message, range_message, catalog_message, subcooling_message As String
        Public lower_approach, upper_approach, lower_capacity, upper_capacity As String
        Public discharge_line_loss, suction_line_loss As String
    End Structure

End Namespace

'7928
'Private Sub txtAltitude_Leave() 
'   Dim altitude = ConvertNull.ToInteger(txt_altitude.Text)

'   If altitude >= 5000 Then
'      warn("Please contact factory for altitudes of 5000 feet or higher.")
'   End If
'End Sub