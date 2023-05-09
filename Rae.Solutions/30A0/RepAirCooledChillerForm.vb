Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports AppUsage = Rae.RaeSolutions.Diagnostics.UsageLog.ApplicationUsageLogger
Imports GlycolNames = Rae.RaeSolutions.DataAccess.Chillers.GlycolColumnNames
Imports Microsoft.VisualBasic
Imports Forms = System.Windows.Forms
Imports Rae.Io.Text
Imports rae.solutions
Imports rae.solutions.chiller_evaporators
Imports rae.solutions.chillers
Imports rae.solutions.air_cooled_chillers
Imports rae.solutions.air_cooled_chillers.chiller
Imports rae.solutions.compressors
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.DataAccess
Imports Rae.RaeSolutions.DataAccess.Chillers
Imports Rae.Ui.quickies
Imports Condenser = Rae.RaeSolutions.Business.Entities.Condenser
Imports Rae.Ui.Validation
Imports System.Collections.Generic
Imports Data = System.Data
Imports Logic = Rae.RaeSolutions.Business.Intelligence
Imports Rae.Collections
Imports Rae.Math.Calculate
Imports System.Math
Imports System.Data

Public Class RepAirCooledChillerForm
   Inherits BaseChillerForm
   
   Public ProcessDeleted As Boolean
   Friend WithEvents saveAsRevisionMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents saveAsMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents convertToEquipmentMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents OpenAirCooledChillerRatingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents SaveToolStripPanel1 As Rae.RaeSolutions.SaveToolStripPanel
   Friend WithEvents btn_go_to_pricing As System.Windows.Forms.Button
 
   Public LastSavedProcess As ACChillerProcessItem
   Public CurrentStateProcess As ACChillerProcessItem
   Private m_CurrentRevision As Single = -1
   Friend WithEvents timer1 As System.Windows.Forms.Timer
    ''Friend WithEvents pan_rating_criteria_header As Rae.Ui.Controls.CollapsableHeader
    ''Friend WithEvents pan_compressor_header As Rae.Ui.Controls.CollapsableHeader
    ''Friend WithEvents pan_condenser_header As Rae.Ui.Controls.CollapsableHeader
    ''Friend WithEvents pan_evaporator_header As Rae.Ui.Controls.CollapsableHeader
    Friend WithEvents lbl_select_model As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DataGridView2 As DataGridView

    Property CurrentRevision As Single
        Get
            Return m_CurrentRevision
        End Get
        Set(value As Single)
            m_CurrentRevision = value
        End Set
    End Property

    Private m_LatestRevision As Single = -1
   
   Property LatestRevision As Single
      Get
         Return m_LatestRevision
      End Get
      Set(value As Single)
         m_LatestRevision = value
      End Set
   End Property



#Region " Windows Form Designer generated code "

   Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

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
   Friend WithEvents pan_model As System.Windows.Forms.Panel
   Friend WithEvents pan_main As System.Windows.Forms.Panel
   Friend WithEvents TXT_ERROR_1_BOX As System.Windows.Forms.TextBox
   Friend WithEvents cboHertz As System.Windows.Forms.ComboBox
   Friend WithEvents lbl_Volts As System.Windows.Forms.Label
   Friend WithEvents lbl_Volts1 As System.Windows.Forms.Label
   Friend WithEvents panCompressorCircuits As System.Windows.Forms.Panel
   Friend WithEvents lblCompressor1 As System.Windows.Forms.Label
   Friend WithEvents lblCompressor2 As System.Windows.Forms.Label
   Friend WithEvents lblCondenser1 As System.Windows.Forms.Label
   Friend WithEvents lblCondenser2 As System.Windows.Forms.Label
   Friend WithEvents pan_evaporator As System.Windows.Forms.Panel
   Friend WithEvents Panel3 As System.Windows.Forms.Panel
   Friend WithEvents Txtliqcool As System.Windows.Forms.TextBox
   Friend WithEvents TxtCondCap_1 As System.Windows.Forms.TextBox
   Friend WithEvents TxtCondCap_2 As System.Windows.Forms.TextBox
   Friend WithEvents lblEvap6Degr As System.Windows.Forms.Label
   Friend WithEvents lblEvap8Degr As System.Windows.Forms.Label
   Friend WithEvents lblEvap4Degr As System.Windows.Forms.Label
   Friend WithEvents lblEvap5Degr As System.Windows.Forms.Label
   Friend WithEvents lblEvap11Degr As System.Windows.Forms.Label
   Friend WithEvents lblEvap9Degr As System.Windows.Forms.Label
   Friend WithEvents lblEvap7Degr As System.Windows.Forms.Label
   Friend WithEvents lblEvap10Degr As System.Windows.Forms.Label
   Friend WithEvents rbOther_Approch As System.Windows.Forms.RadioButton
   Friend WithEvents rb10_12 As System.Windows.Forms.RadioButton
   Friend WithEvents rb9_11 As System.Windows.Forms.RadioButton
   Friend WithEvents rb8_10 As System.Windows.Forms.RadioButton
   Friend WithEvents rb7_9 As System.Windows.Forms.RadioButton
   Friend WithEvents rb6_8 As System.Windows.Forms.RadioButton
   Friend WithEvents txt5Deg As System.Windows.Forms.TextBox
   Friend WithEvents txt6Deg As System.Windows.Forms.TextBox
   Friend WithEvents txt4Deg As System.Windows.Forms.TextBox
   Friend WithEvents txt8Deg As System.Windows.Forms.TextBox
   Friend WithEvents txt9Deg As System.Windows.Forms.TextBox
   Friend WithEvents txt12Deg As System.Windows.Forms.TextBox
   Friend WithEvents txt11Deg As System.Windows.Forms.TextBox
   Friend WithEvents txt10Deg As System.Windows.Forms.TextBox
   Friend WithEvents txt7Deg As System.Windows.Forms.TextBox
   Friend WithEvents txt4 As System.Windows.Forms.TextBox
   Friend WithEvents txt7 As System.Windows.Forms.TextBox
   Friend WithEvents txt6 As System.Windows.Forms.TextBox
   Friend WithEvents txt5 As System.Windows.Forms.TextBox
   Friend WithEvents txt12 As System.Windows.Forms.TextBox
   Friend WithEvents txt11 As System.Windows.Forms.TextBox
   Friend WithEvents txt10 As System.Windows.Forms.TextBox
   Friend WithEvents txt9 As System.Windows.Forms.TextBox
   Friend WithEvents txt8 As System.Windows.Forms.TextBox
   Friend WithEvents TxtTonsSystemCap As System.Windows.Forms.TextBox
   Friend WithEvents txt_gpm As System.Windows.Forms.TextBox
   Friend WithEvents cbo_Discharge_line_loss As System.Windows.Forms.ComboBox
   Friend WithEvents cbo_Suction_line_loss As System.Windows.Forms.ComboBox
   Friend WithEvents cboChiller11 As System.Windows.Forms.ComboBox
   Friend WithEvents Txt_circuit_per_unit As System.Windows.Forms.TextBox
   Friend WithEvents txt_Evap_Length As System.Windows.Forms.TextBox
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
   Friend WithEvents txtCondenser_1 As System.Windows.Forms.TextBox
   Friend WithEvents txtCondenser_2 As System.Windows.Forms.TextBox
   Friend WithEvents DropDownList3 As System.Windows.Forms.ComboBox
   Friend WithEvents Txt8Deg_1 As System.Windows.Forms.TextBox
   Friend WithEvents Txt8Deg_2 As System.Windows.Forms.TextBox
   Friend WithEvents Txt10Deg_1 As System.Windows.Forms.TextBox
   Friend WithEvents Txt10Deg_2 As System.Windows.Forms.TextBox
   Friend WithEvents cboVolts As System.Windows.Forms.ComboBox
   Friend WithEvents DropDownList2 As System.Windows.Forms.ComboBox
   Friend WithEvents TxtCondCap As System.Windows.Forms.TextBox
   Friend WithEvents pan_rating_criteria As System.Windows.Forms.Panel
   Friend WithEvents pan_condenser As System.Windows.Forms.Panel
   Friend WithEvents pan_compressor As System.Windows.Forms.Panel
   Friend WithEvents picError As System.Windows.Forms.PictureBox
   Friend WithEvents pan_footer As System.Windows.Forms.Panel
   Friend WithEvents lblError As System.Windows.Forms.Label
   Friend WithEvents panFooterButton As System.Windows.Forms.Panel
   Friend WithEvents btn_calculate_page As System.Windows.Forms.Button
   Friend WithEvents panCondenserControls As System.Windows.Forms.Panel
   Friend WithEvents panCompressorControls As System.Windows.Forms.Panel
   Friend WithEvents panCriteriaControls As System.Windows.Forms.Panel
   Friend WithEvents panEvaporatorControls As System.Windows.Forms.Panel
   Friend WithEvents panGrid As System.Windows.Forms.Panel
   Friend WithEvents btn_create_report As System.Windows.Forms.Button
   Friend WithEvents cboHidValues As System.Windows.Forms.ComboBox
   Friend WithEvents lblNumFans2 As System.Windows.Forms.Label
   Friend WithEvents lblFanWatts2 As System.Windows.Forms.Label
   Friend WithEvents btnGlycolChart As System.Windows.Forms.Button
   Friend WithEvents lblSeries As System.Windows.Forms.Label
   Friend WithEvents cbo_series As System.Windows.Forms.ComboBox
   Friend WithEvents cbo_models As System.Windows.Forms.ComboBox
   Friend WithEvents lblCondenserFanValue2 As System.Windows.Forms.Label
   Friend WithEvents btn_alternate_evaporators As System.Windows.Forms.Button
   Friend WithEvents txt_model As System.Windows.Forms.TextBox
   Friend WithEvents lblFreezingPoint As System.Windows.Forms.Label
   Friend WithEvents lblSpecificGravity As System.Windows.Forms.Label
   Friend WithEvents lblSpecificHeat As System.Windows.Forms.Label
   Friend WithEvents lblCoolingMedia As System.Windows.Forms.Label
   Friend WithEvents lblFluid As System.Windows.Forms.Label
   Friend WithEvents lblLeavingFluidTemp As System.Windows.Forms.Label
   Friend WithEvents lblTempRange As System.Windows.Forms.Label
   Friend WithEvents lblAmbientTemp As System.Windows.Forms.Label
   Friend WithEvents lblRefrigerant As System.Windows.Forms.Label
   Friend WithEvents lblSystem As System.Windows.Forms.Label
   Friend WithEvents lblHertz As System.Windows.Forms.Label
   Friend WithEvents lblMinSuctionTemp As System.Windows.Forms.Label
   Friend WithEvents lblCoolingMediaPercent As System.Windows.Forms.Label
   Friend WithEvents lblTempRangeF As System.Windows.Forms.Label
   Friend WithEvents lblLeavingFluidTempF As System.Windows.Forms.Label
   Friend WithEvents lblAmbientTempF As System.Windows.Forms.Label
   Friend WithEvents txtPercentGlycol As System.Windows.Forms.TextBox
   Friend WithEvents cboFluid As System.Windows.Forms.ComboBox
   Friend WithEvents cbo_glycol As System.Windows.Forms.ComboBox
   Friend WithEvents txtSpecificGravity As System.Windows.Forms.TextBox
   Friend WithEvents txtSpecificHeat As System.Windows.Forms.TextBox
   Friend WithEvents txtFreezingPoint As System.Windows.Forms.TextBox
   Friend WithEvents txtMinSuctionTemp As System.Windows.Forms.TextBox
   Friend WithEvents cboRefrigerant As System.Windows.Forms.ComboBox
   Friend WithEvents txtLeavingFluidTemp As System.Windows.Forms.TextBox
   Friend WithEvents txtAmbientTemp As System.Windows.Forms.TextBox
   Friend WithEvents cboTempRange As System.Windows.Forms.ComboBox
   Friend WithEvents cboSystem As System.Windows.Forms.ComboBox
   Friend WithEvents radCircuit1 As System.Windows.Forms.RadioButton
   Friend WithEvents radCircuit2 As System.Windows.Forms.RadioButton
   Friend WithEvents txtNumCompressors1 As System.Windows.Forms.TextBox
   Friend WithEvents lblNumCompressors1 As System.Windows.Forms.Label
   Friend WithEvents txtNumCompressors2 As System.Windows.Forms.TextBox
   Friend WithEvents lblNumCompressors2 As System.Windows.Forms.Label
   Friend WithEvents lboCompressors1 As System.Windows.Forms.ListBox
   Friend WithEvents lboCompressors2 As System.Windows.Forms.ListBox
   Friend WithEvents lblCircuit2 As System.Windows.Forms.Label
   Friend WithEvents lblCircuit1 As System.Windows.Forms.Label
   Friend WithEvents gboCompressor1 As System.Windows.Forms.GroupBox
   Friend WithEvents gboCompressor2 As System.Windows.Forms.GroupBox
   Friend WithEvents lblAltitude1 As System.Windows.Forms.Label
   Friend WithEvents lblFan As System.Windows.Forms.Label
   Friend WithEvents lblNumFans1 As System.Windows.Forms.Label
   Friend WithEvents lblFinHeight1 As System.Windows.Forms.Label
   Friend WithEvents lblFinsPerInch1 As System.Windows.Forms.Label
   Friend WithEvents lblSubCooling1 As System.Windows.Forms.Label
   Friend WithEvents lblFinLength1 As System.Windows.Forms.Label
   Friend WithEvents lblFinLength2 As System.Windows.Forms.Label
   Friend WithEvents lblSubCooling2 As System.Windows.Forms.Label
   Friend WithEvents lblFinsPerInch2 As System.Windows.Forms.Label
   Friend WithEvents lblFanWatts1 As System.Windows.Forms.Label
   Friend WithEvents lblAltitude2 As System.Windows.Forms.Label
   Friend WithEvents lblFinHeight2 As System.Windows.Forms.Label
   Friend WithEvents txtNumCoils1 As System.Windows.Forms.TextBox
   Friend WithEvents lblNumCoils1 As System.Windows.Forms.Label
   Friend WithEvents txtNumCoils2 As System.Windows.Forms.TextBox
   Friend WithEvents lblNumCoils2 As System.Windows.Forms.Label
   Friend WithEvents cboCoilFileName1 As System.Windows.Forms.ComboBox
   Friend WithEvents cboCoilFileName2 As System.Windows.Forms.ComboBox
   Friend WithEvents cboSubCooling2 As System.Windows.Forms.ComboBox
   Friend WithEvents txtSubCoolingPercent2 As System.Windows.Forms.TextBox
   Friend WithEvents cboFpi2 As System.Windows.Forms.ComboBox
   Friend WithEvents txtSubCoolingPercent1 As System.Windows.Forms.TextBox
   Friend WithEvents cboFpi1 As System.Windows.Forms.ComboBox
   Friend WithEvents cboSubCooling1 As System.Windows.Forms.ComboBox
   Friend WithEvents txtCfmOverRide As System.Windows.Forms.TextBox
   Friend WithEvents txtFinLength2 As System.Windows.Forms.TextBox
   Friend WithEvents txtNumFans1 As System.Windows.Forms.TextBox
   Friend WithEvents txtAltitude2 As System.Windows.Forms.TextBox
   Friend WithEvents txtFinHeight2 As System.Windows.Forms.TextBox
   Friend WithEvents txtNumFans2 As System.Windows.Forms.TextBox
   Friend WithEvents txtFinHeight1 As System.Windows.Forms.TextBox
   Friend WithEvents cboFan As System.Windows.Forms.ComboBox
   Friend WithEvents txtFinLength1 As System.Windows.Forms.TextBox
   Friend WithEvents txtFanWatts2 As System.Windows.Forms.TextBox
   Friend WithEvents txtFanWatts1 As System.Windows.Forms.TextBox
   Friend WithEvents txtAltitude1 As System.Windows.Forms.TextBox
   Friend WithEvents txtCapacity As System.Windows.Forms.TextBox
   Friend WithEvents cboFoulingFactor As System.Windows.Forms.ComboBox
   Friend WithEvents lblEvaporator As System.Windows.Forms.Label
   Friend WithEvents cbo_evaporators As System.Windows.Forms.ComboBox
   Friend WithEvents chkCatalog As System.Windows.Forms.CheckBox
   Friend WithEvents txt_evaporator As System.Windows.Forms.TextBox
   Friend WithEvents lblFoulingFactor As System.Windows.Forms.Label
   Friend WithEvents radCapacityTons As System.Windows.Forms.RadioButton
   Friend WithEvents radCapacityGpm As System.Windows.Forms.RadioButton
   Friend WithEvents lblLimits As System.Windows.Forms.Label
    ''Friend WithEvents grd_results As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents lblModel As System.Windows.Forms.Label
   Friend WithEvents hid_panCriteria As System.Windows.Forms.Panel
   Friend WithEvents lblFreezingPointPercentF As System.Windows.Forms.Label
   Friend WithEvents lblMinSuctionTempF As System.Windows.Forms.Label
   Friend WithEvents hid_lblApproach As System.Windows.Forms.Label
   Friend WithEvents hid_txtApproach As System.Windows.Forms.TextBox
   Friend WithEvents hid_panResults As System.Windows.Forms.Panel
   Friend WithEvents hid_panEvaporator As System.Windows.Forms.Panel
   Friend WithEvents hid_panCondenser As System.Windows.Forms.Panel
   Friend WithEvents lblEvap12Degree As System.Windows.Forms.Label
   Friend WithEvents hid_panApproach As System.Windows.Forms.Panel
   Friend WithEvents txtCompressor1 As System.Windows.Forms.TextBox
   Friend WithEvents txtCompressor2 As System.Windows.Forms.TextBox
   Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
   Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents printMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents saveMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents err As System.Windows.Forms.ErrorProvider
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RepAirCooledChillerForm))
        Me.cbo_models = New System.Windows.Forms.ComboBox()
        Me.txt_model = New System.Windows.Forms.TextBox()
        Me.pan_model = New System.Windows.Forms.Panel()
        Me.cbo_series = New System.Windows.Forms.ComboBox()
        Me.lblSeries = New System.Windows.Forms.Label()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenAirCooledChillerRatingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.saveMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.saveAsRevisionMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.saveAsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.convertToEquipmentMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.printMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TXT_ERROR_1_BOX = New System.Windows.Forms.TextBox()
        Me.pan_rating_criteria = New System.Windows.Forms.Panel()
        Me.hid_panCriteria = New System.Windows.Forms.Panel()
        Me.Txtliqcool = New System.Windows.Forms.TextBox()
        Me.cboVolts = New System.Windows.Forms.ComboBox()
        Me.panCriteriaControls = New System.Windows.Forms.Panel()
        Me.lblTempRangeF = New System.Windows.Forms.Label()
        Me.btnGlycolChart = New System.Windows.Forms.Button()
        Me.txtFreezingPoint = New System.Windows.Forms.TextBox()
        Me.lblFreezingPoint = New System.Windows.Forms.Label()
        Me.txtSpecificGravity = New System.Windows.Forms.TextBox()
        Me.txtSpecificHeat = New System.Windows.Forms.TextBox()
        Me.lblSpecificGravity = New System.Windows.Forms.Label()
        Me.lblCoolingMediaPercent = New System.Windows.Forms.Label()
        Me.lblSpecificHeat = New System.Windows.Forms.Label()
        Me.txtPercentGlycol = New System.Windows.Forms.TextBox()
        Me.lblCoolingMedia = New System.Windows.Forms.Label()
        Me.lblFluid = New System.Windows.Forms.Label()
        Me.cboHertz = New System.Windows.Forms.ComboBox()
        Me.lblLeavingFluidTemp = New System.Windows.Forms.Label()
        Me.lblTempRange = New System.Windows.Forms.Label()
        Me.lblAmbientTemp = New System.Windows.Forms.Label()
        Me.txtMinSuctionTemp = New System.Windows.Forms.TextBox()
        Me.lblFreezingPointPercentF = New System.Windows.Forms.Label()
        Me.txtLeavingFluidTemp = New System.Windows.Forms.TextBox()
        Me.lblRefrigerant = New System.Windows.Forms.Label()
        Me.txtAmbientTemp = New System.Windows.Forms.TextBox()
        Me.lblSystem = New System.Windows.Forms.Label()
        Me.cboTempRange = New System.Windows.Forms.ComboBox()
        Me.cboRefrigerant = New System.Windows.Forms.ComboBox()
        Me.cbo_glycol = New System.Windows.Forms.ComboBox()
        Me.lblHertz = New System.Windows.Forms.Label()
        Me.lblMinSuctionTempF = New System.Windows.Forms.Label()
        Me.lblLeavingFluidTempF = New System.Windows.Forms.Label()
        Me.lblMinSuctionTemp = New System.Windows.Forms.Label()
        Me.lblAmbientTempF = New System.Windows.Forms.Label()
        Me.cboSystem = New System.Windows.Forms.ComboBox()
        Me.cboFluid = New System.Windows.Forms.ComboBox()
        Me.lbl_Volts1 = New System.Windows.Forms.Label()
        Me.lbl_Volts = New System.Windows.Forms.Label()
        Me.hid_lblApproach = New System.Windows.Forms.Label()
        Me.hid_txtApproach = New System.Windows.Forms.TextBox()
        Me.pan_main = New System.Windows.Forms.Panel()
        Me.panGrid = New System.Windows.Forms.Panel()
        Me.hid_panResults = New System.Windows.Forms.Panel()
        Me.Txt10Deg_1 = New System.Windows.Forms.TextBox()
        Me.Txt8Deg_2 = New System.Windows.Forms.TextBox()
        Me.Txt_circuit_per_unit = New System.Windows.Forms.TextBox()
        Me.TxtCondCap = New System.Windows.Forms.TextBox()
        Me.Txt10Deg_2 = New System.Windows.Forms.TextBox()
        Me.TxtTonsSystemCap = New System.Windows.Forms.TextBox()
        Me.txt_gpm = New System.Windows.Forms.TextBox()
        Me.cboChiller11 = New System.Windows.Forms.ComboBox()
        Me.txt_Evap_Length = New System.Windows.Forms.TextBox()
        Me.Txt8Deg_1 = New System.Windows.Forms.TextBox()
        Me.lblLimits = New System.Windows.Forms.Label()
        Me.pan_evaporator = New System.Windows.Forms.Panel()
        Me.panEvaporatorControls = New System.Windows.Forms.Panel()
        Me.txtCapacity = New System.Windows.Forms.TextBox()
        Me.btn_alternate_evaporators = New System.Windows.Forms.Button()
        Me.cboFoulingFactor = New System.Windows.Forms.ComboBox()
        Me.lblEvaporator = New System.Windows.Forms.Label()
        Me.cbo_evaporators = New System.Windows.Forms.ComboBox()
        Me.chkCatalog = New System.Windows.Forms.CheckBox()
        Me.txt_evaporator = New System.Windows.Forms.TextBox()
        Me.lblFoulingFactor = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.radCapacityTons = New System.Windows.Forms.RadioButton()
        Me.radCapacityGpm = New System.Windows.Forms.RadioButton()
        Me.hid_panEvaporator = New System.Windows.Forms.Panel()
        Me.txt4Deg = New System.Windows.Forms.TextBox()
        Me.txt9 = New System.Windows.Forms.TextBox()
        Me.txt4 = New System.Windows.Forms.TextBox()
        Me.txt11Deg = New System.Windows.Forms.TextBox()
        Me.hid_panApproach = New System.Windows.Forms.Panel()
        Me.rb10_12 = New System.Windows.Forms.RadioButton()
        Me.rb9_11 = New System.Windows.Forms.RadioButton()
        Me.rb8_10 = New System.Windows.Forms.RadioButton()
        Me.rb7_9 = New System.Windows.Forms.RadioButton()
        Me.rb6_8 = New System.Windows.Forms.RadioButton()
        Me.rbOther_Approch = New System.Windows.Forms.RadioButton()
        Me.txt7Deg = New System.Windows.Forms.TextBox()
        Me.txt7 = New System.Windows.Forms.TextBox()
        Me.txt5 = New System.Windows.Forms.TextBox()
        Me.txt6Deg = New System.Windows.Forms.TextBox()
        Me.txt10Deg = New System.Windows.Forms.TextBox()
        Me.txt9Deg = New System.Windows.Forms.TextBox()
        Me.txt5Deg = New System.Windows.Forms.TextBox()
        Me.lblEvap4Degr = New System.Windows.Forms.Label()
        Me.lblEvap5Degr = New System.Windows.Forms.Label()
        Me.lblEvap7Degr = New System.Windows.Forms.Label()
        Me.txt10 = New System.Windows.Forms.TextBox()
        Me.txt12Deg = New System.Windows.Forms.TextBox()
        Me.txt12 = New System.Windows.Forms.TextBox()
        Me.txt11 = New System.Windows.Forms.TextBox()
        Me.txt8Deg = New System.Windows.Forms.TextBox()
        Me.txt8 = New System.Windows.Forms.TextBox()
        Me.txt6 = New System.Windows.Forms.TextBox()
        Me.lblEvap9Degr = New System.Windows.Forms.Label()
        Me.lblEvap6Degr = New System.Windows.Forms.Label()
        Me.lblEvap8Degr = New System.Windows.Forms.Label()
        Me.lblEvap10Degr = New System.Windows.Forms.Label()
        Me.lblEvap12Degree = New System.Windows.Forms.Label()
        Me.lblEvap11Degr = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.pan_condenser = New System.Windows.Forms.Panel()
        Me.hid_panCondenser = New System.Windows.Forms.Panel()
        Me.DropDownList2 = New System.Windows.Forms.ComboBox()
        Me.cboHidValues = New System.Windows.Forms.ComboBox()
        Me.DropDownList3 = New System.Windows.Forms.ComboBox()
        Me.cbo_Suction_line_loss = New System.Windows.Forms.ComboBox()
        Me.txtCondenser_1 = New System.Windows.Forms.TextBox()
        Me.TxtCondCap_1 = New System.Windows.Forms.TextBox()
        Me.cbo_Discharge_line_loss = New System.Windows.Forms.ComboBox()
        Me.TxtCondCap_2 = New System.Windows.Forms.TextBox()
        Me.txtCondenser_2 = New System.Windows.Forms.TextBox()
        Me.panCondenserControls = New System.Windows.Forms.Panel()
        Me.txtCfmOverRide = New System.Windows.Forms.TextBox()
        Me.lblCondenserFanValue2 = New System.Windows.Forms.Label()
        Me.txtFinLength2 = New System.Windows.Forms.TextBox()
        Me.txtNumFans1 = New System.Windows.Forms.TextBox()
        Me.lblAltitude1 = New System.Windows.Forms.Label()
        Me.lblFan = New System.Windows.Forms.Label()
        Me.cboSubCooling2 = New System.Windows.Forms.ComboBox()
        Me.lblNumFans1 = New System.Windows.Forms.Label()
        Me.cboCoilFileName1 = New System.Windows.Forms.ComboBox()
        Me.txtAltitude2 = New System.Windows.Forms.TextBox()
        Me.txtSubCoolingPercent2 = New System.Windows.Forms.TextBox()
        Me.cboFpi2 = New System.Windows.Forms.ComboBox()
        Me.txtAltitude1 = New System.Windows.Forms.TextBox()
        Me.txtFinHeight2 = New System.Windows.Forms.TextBox()
        Me.txtNumFans2 = New System.Windows.Forms.TextBox()
        Me.cboCoilFileName2 = New System.Windows.Forms.ComboBox()
        Me.lblFinHeight1 = New System.Windows.Forms.Label()
        Me.txtFinHeight1 = New System.Windows.Forms.TextBox()
        Me.lblFinsPerInch1 = New System.Windows.Forms.Label()
        Me.lblSubCooling1 = New System.Windows.Forms.Label()
        Me.txtSubCoolingPercent1 = New System.Windows.Forms.TextBox()
        Me.cboFpi1 = New System.Windows.Forms.ComboBox()
        Me.lblFinLength1 = New System.Windows.Forms.Label()
        Me.lblFinLength2 = New System.Windows.Forms.Label()
        Me.lblSubCooling2 = New System.Windows.Forms.Label()
        Me.txtNumCoils1 = New System.Windows.Forms.TextBox()
        Me.lblNumFans2 = New System.Windows.Forms.Label()
        Me.lblCondenser2 = New System.Windows.Forms.Label()
        Me.lblNumCoils1 = New System.Windows.Forms.Label()
        Me.lblCircuit2 = New System.Windows.Forms.Label()
        Me.txtNumCoils2 = New System.Windows.Forms.TextBox()
        Me.lblFinsPerInch2 = New System.Windows.Forms.Label()
        Me.cboFan = New System.Windows.Forms.ComboBox()
        Me.lblNumCoils2 = New System.Windows.Forms.Label()
        Me.cboSubCooling1 = New System.Windows.Forms.ComboBox()
        Me.lblCondenser1 = New System.Windows.Forms.Label()
        Me.lblCircuit1 = New System.Windows.Forms.Label()
        Me.txtFinLength1 = New System.Windows.Forms.TextBox()
        Me.lblFanWatts1 = New System.Windows.Forms.Label()
        Me.txtFanWatts2 = New System.Windows.Forms.TextBox()
        Me.txtFanWatts1 = New System.Windows.Forms.TextBox()
        Me.lblAltitude2 = New System.Windows.Forms.Label()
        Me.lblFinHeight2 = New System.Windows.Forms.Label()
        Me.lblFanWatts2 = New System.Windows.Forms.Label()
        Me.pan_compressor = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panCompressorControls = New System.Windows.Forms.Panel()
        Me.gboCompressor1 = New System.Windows.Forms.GroupBox()
        Me.txtNumCompressors1 = New System.Windows.Forms.TextBox()
        Me.lblCompressor1 = New System.Windows.Forms.Label()
        Me.lblNumCompressors1 = New System.Windows.Forms.Label()
        Me.txtCompressor1 = New System.Windows.Forms.TextBox()
        Me.lboCompressors1 = New System.Windows.Forms.ListBox()
        Me.gboCompressor2 = New System.Windows.Forms.GroupBox()
        Me.lblCompressor2 = New System.Windows.Forms.Label()
        Me.txtCompressor2 = New System.Windows.Forms.TextBox()
        Me.txtNumCompressors2 = New System.Windows.Forms.TextBox()
        Me.lblNumCompressors2 = New System.Windows.Forms.Label()
        Me.lboCompressors2 = New System.Windows.Forms.ListBox()
        Me.panCompressorCircuits = New System.Windows.Forms.Panel()
        Me.radCircuit1 = New System.Windows.Forms.RadioButton()
        Me.radCircuit2 = New System.Windows.Forms.RadioButton()
        Me.btn_create_report = New System.Windows.Forms.Button()
        Me.picError = New System.Windows.Forms.PictureBox()
        Me.pan_footer = New System.Windows.Forms.Panel()
        Me.lblError = New System.Windows.Forms.Label()
        Me.panFooterButton = New System.Windows.Forms.Panel()
        Me.btn_go_to_pricing = New System.Windows.Forms.Button()
        Me.btn_calculate_page = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.err = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.SaveToolStripPanel1 = New Rae.RaeSolutions.SaveToolStripPanel()
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lbl_select_model = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        CType(Me.results, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pan_model.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.pan_rating_criteria.SuspendLayout()
        Me.hid_panCriteria.SuspendLayout()
        Me.panCriteriaControls.SuspendLayout()
        Me.pan_main.SuspendLayout()
        Me.panGrid.SuspendLayout()
        Me.hid_panResults.SuspendLayout()
        Me.pan_evaporator.SuspendLayout()
        Me.panEvaporatorControls.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.hid_panEvaporator.SuspendLayout()
        Me.hid_panApproach.SuspendLayout()
        Me.pan_condenser.SuspendLayout()
        Me.hid_panCondenser.SuspendLayout()
        Me.panCondenserControls.SuspendLayout()
        Me.pan_compressor.SuspendLayout()
        Me.panCompressorControls.SuspendLayout()
        Me.gboCompressor1.SuspendLayout()
        Me.gboCompressor2.SuspendLayout()
        Me.panCompressorCircuits.SuspendLayout()
        CType(Me.picError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pan_footer.SuspendLayout()
        Me.panFooterButton.SuspendLayout()
        CType(Me.err, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbo_models
        '
        Me.cbo_models.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_models.Location = New System.Drawing.Point(80, 40)
        Me.cbo_models.MaxDropDownItems = 20
        Me.cbo_models.Name = "cbo_models"
        Me.cbo_models.Size = New System.Drawing.Size(112, 21)
        Me.cbo_models.TabIndex = 2
        '
        'txt_model
        '
        Me.txt_model.Location = New System.Drawing.Point(196, 40)
        Me.txt_model.Name = "txt_model"
        Me.txt_model.Size = New System.Drawing.Size(100, 21)
        Me.txt_model.TabIndex = 3
        '
        'pan_model
        '
        Me.pan_model.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pan_model.Controls.Add(Me.cbo_series)
        Me.pan_model.Controls.Add(Me.lblSeries)
        Me.pan_model.Controls.Add(Me.lblModel)
        Me.pan_model.Controls.Add(Me.txt_model)
        Me.pan_model.Controls.Add(Me.cbo_models)
        Me.pan_model.Controls.Add(Me.MenuStrip1)
        Me.pan_model.Dock = System.Windows.Forms.DockStyle.Top
        Me.pan_model.Location = New System.Drawing.Point(0, 0)
        Me.pan_model.Name = "pan_model"
        Me.pan_model.Size = New System.Drawing.Size(662, 68)
        Me.pan_model.TabIndex = 1
        '
        'cbo_series
        '
        Me.cbo_series.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_series.Items.AddRange(New Object() {"30A2"})
        Me.cbo_series.Location = New System.Drawing.Point(80, 12)
        Me.cbo_series.Name = "cbo_series"
        Me.cbo_series.Size = New System.Drawing.Size(112, 21)
        Me.cbo_series.TabIndex = 1
        '
        'lblSeries
        '
        Me.lblSeries.Location = New System.Drawing.Point(16, 12)
        Me.lblSeries.Name = "lblSeries"
        Me.lblSeries.Size = New System.Drawing.Size(56, 23)
        Me.lblSeries.TabIndex = 5
        Me.lblSeries.Text = "Series"
        Me.lblSeries.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblModel
        '
        Me.lblModel.Location = New System.Drawing.Point(16, 40)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(56, 23)
        Me.lblModel.TabIndex = 4
        Me.lblModel.Text = "Model"
        Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(694, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenAirCooledChillerRatingToolStripMenuItem, Me.ToolStripSeparator3, Me.saveMenuItem, Me.saveAsRevisionMenuItem, Me.saveAsMenuItem, Me.ToolStripSeparator2, Me.convertToEquipmentMenuItem, Me.ToolStripSeparator1, Me.printMenuItem})
        Me.mnuFile.MergeAction = System.Windows.Forms.MergeAction.MatchOnly
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(37, 20)
        Me.mnuFile.Text = "File"
        '
        'OpenAirCooledChillerRatingToolStripMenuItem
        '
        Me.OpenAirCooledChillerRatingToolStripMenuItem.Enabled = False
        Me.OpenAirCooledChillerRatingToolStripMenuItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Open
        Me.OpenAirCooledChillerRatingToolStripMenuItem.Name = "OpenAirCooledChillerRatingToolStripMenuItem"
        Me.OpenAirCooledChillerRatingToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.OpenAirCooledChillerRatingToolStripMenuItem.Text = "Open Air Cooled Chiller Rating..."
        Me.OpenAirCooledChillerRatingToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(242, 6)
        '
        'saveMenuItem
        '
        Me.saveMenuItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Save
        Me.saveMenuItem.Name = "saveMenuItem"
        Me.saveMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.saveMenuItem.Text = "Save"
        '
        'saveAsRevisionMenuItem
        '
        Me.saveAsRevisionMenuItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.SaveAsRevision
        Me.saveAsRevisionMenuItem.Name = "saveAsRevisionMenuItem"
        Me.saveAsRevisionMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.saveAsRevisionMenuItem.Text = "Save as Revision"
        '
        'saveAsMenuItem
        '
        Me.saveAsMenuItem.Name = "saveAsMenuItem"
        Me.saveAsMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.saveAsMenuItem.Text = "Save as..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(242, 6)
        '
        'convertToEquipmentMenuItem
        '
        Me.convertToEquipmentMenuItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.ConvertToEquipment
        Me.convertToEquipmentMenuItem.Name = "convertToEquipmentMenuItem"
        Me.convertToEquipmentMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.convertToEquipmentMenuItem.Text = "Convert to Equipment..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(242, 6)
        Me.ToolStripSeparator1.Visible = False
        '
        'printMenuItem
        '
        Me.printMenuItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Print
        Me.printMenuItem.Name = "printMenuItem"
        Me.printMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.printMenuItem.Text = "Print..."
        '
        'TXT_ERROR_1_BOX
        '
        Me.TXT_ERROR_1_BOX.Location = New System.Drawing.Point(52, 148)
        Me.TXT_ERROR_1_BOX.Multiline = True
        Me.TXT_ERROR_1_BOX.Name = "TXT_ERROR_1_BOX"
        Me.TXT_ERROR_1_BOX.ReadOnly = True
        Me.TXT_ERROR_1_BOX.Size = New System.Drawing.Size(320, 20)
        Me.TXT_ERROR_1_BOX.TabIndex = 2
        Me.TXT_ERROR_1_BOX.Text = "If errors occur, they will be shown here"
        '
        'pan_rating_criteria
        '
        Me.pan_rating_criteria.Controls.Add(Me.hid_panCriteria)
        Me.pan_rating_criteria.Controls.Add(Me.panCriteriaControls)
        Me.pan_rating_criteria.Controls.Add(Me.hid_lblApproach)
        Me.pan_rating_criteria.Controls.Add(Me.hid_txtApproach)
        Me.pan_rating_criteria.Dock = System.Windows.Forms.DockStyle.Top
        Me.pan_rating_criteria.Location = New System.Drawing.Point(0, 68)
        Me.pan_rating_criteria.Name = "pan_rating_criteria"
        Me.pan_rating_criteria.Size = New System.Drawing.Size(662, 196)
        Me.pan_rating_criteria.TabIndex = 2
        '
        'hid_panCriteria
        '
        Me.hid_panCriteria.BackColor = System.Drawing.Color.Yellow
        Me.hid_panCriteria.Controls.Add(Me.Txtliqcool)
        Me.hid_panCriteria.Controls.Add(Me.cboVolts)
        Me.hid_panCriteria.Location = New System.Drawing.Point(520, 48)
        Me.hid_panCriteria.Name = "hid_panCriteria"
        Me.hid_panCriteria.Size = New System.Drawing.Size(96, 100)
        Me.hid_panCriteria.TabIndex = 45
        Me.hid_panCriteria.Visible = False
        '
        'Txtliqcool
        '
        Me.Txtliqcool.Location = New System.Drawing.Point(16, 16)
        Me.Txtliqcool.Name = "Txtliqcool"
        Me.Txtliqcool.Size = New System.Drawing.Size(48, 21)
        Me.Txtliqcool.TabIndex = 38
        Me.Txtliqcool.Text = "15"
        '
        'cboVolts
        '
        Me.cboVolts.Items.AddRange(New Object() {"230", "460"})
        Me.cboVolts.Location = New System.Drawing.Point(16, 64)
        Me.cboVolts.Name = "cboVolts"
        Me.cboVolts.Size = New System.Drawing.Size(64, 21)
        Me.cboVolts.TabIndex = 40
        Me.cboVolts.Text = "230"
        '
        'panCriteriaControls
        '
        Me.panCriteriaControls.Controls.Add(Me.lblTempRangeF)
        Me.panCriteriaControls.Controls.Add(Me.btnGlycolChart)
        Me.panCriteriaControls.Controls.Add(Me.txtFreezingPoint)
        Me.panCriteriaControls.Controls.Add(Me.lblFreezingPoint)
        Me.panCriteriaControls.Controls.Add(Me.txtSpecificGravity)
        Me.panCriteriaControls.Controls.Add(Me.txtSpecificHeat)
        Me.panCriteriaControls.Controls.Add(Me.lblSpecificGravity)
        Me.panCriteriaControls.Controls.Add(Me.lblCoolingMediaPercent)
        Me.panCriteriaControls.Controls.Add(Me.lblSpecificHeat)
        Me.panCriteriaControls.Controls.Add(Me.txtPercentGlycol)
        Me.panCriteriaControls.Controls.Add(Me.lblCoolingMedia)
        Me.panCriteriaControls.Controls.Add(Me.lblFluid)
        Me.panCriteriaControls.Controls.Add(Me.cboHertz)
        Me.panCriteriaControls.Controls.Add(Me.lblLeavingFluidTemp)
        Me.panCriteriaControls.Controls.Add(Me.lblTempRange)
        Me.panCriteriaControls.Controls.Add(Me.lblAmbientTemp)
        Me.panCriteriaControls.Controls.Add(Me.txtMinSuctionTemp)
        Me.panCriteriaControls.Controls.Add(Me.lblFreezingPointPercentF)
        Me.panCriteriaControls.Controls.Add(Me.txtLeavingFluidTemp)
        Me.panCriteriaControls.Controls.Add(Me.lblRefrigerant)
        Me.panCriteriaControls.Controls.Add(Me.txtAmbientTemp)
        Me.panCriteriaControls.Controls.Add(Me.lblSystem)
        Me.panCriteriaControls.Controls.Add(Me.cboTempRange)
        Me.panCriteriaControls.Controls.Add(Me.cboRefrigerant)
        Me.panCriteriaControls.Controls.Add(Me.cbo_glycol)
        Me.panCriteriaControls.Controls.Add(Me.lblHertz)
        Me.panCriteriaControls.Controls.Add(Me.lblMinSuctionTempF)
        Me.panCriteriaControls.Controls.Add(Me.lblLeavingFluidTempF)
        Me.panCriteriaControls.Controls.Add(Me.lblMinSuctionTemp)
        Me.panCriteriaControls.Controls.Add(Me.lblAmbientTempF)
        Me.panCriteriaControls.Controls.Add(Me.cboSystem)
        Me.panCriteriaControls.Controls.Add(Me.cboFluid)
        Me.panCriteriaControls.Controls.Add(Me.lbl_Volts1)
        Me.panCriteriaControls.Controls.Add(Me.lbl_Volts)
        Me.panCriteriaControls.Location = New System.Drawing.Point(8, 0)
        Me.panCriteriaControls.Name = "panCriteriaControls"
        Me.panCriteriaControls.Size = New System.Drawing.Size(504, 184)
        Me.panCriteriaControls.TabIndex = 44
        '
        'lblTempRangeF
        '
        Me.lblTempRangeF.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblTempRangeF.Location = New System.Drawing.Point(440, 40)
        Me.lblTempRangeF.Name = "lblTempRangeF"
        Me.lblTempRangeF.Size = New System.Drawing.Size(38, 23)
        Me.lblTempRangeF.TabIndex = 44
        Me.lblTempRangeF.Text = "°F"
        Me.lblTempRangeF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnGlycolChart
        '
        Me.btnGlycolChart.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnGlycolChart.Location = New System.Drawing.Point(188, 40)
        Me.btnGlycolChart.Name = "btnGlycolChart"
        Me.btnGlycolChart.Size = New System.Drawing.Size(80, 23)
        Me.btnGlycolChart.TabIndex = 7
        Me.btnGlycolChart.Text = "Glycol Chart"
        Me.btnGlycolChart.Visible = False
        '
        'txtFreezingPoint
        '
        Me.txtFreezingPoint.Location = New System.Drawing.Point(112, 124)
        Me.txtFreezingPoint.Name = "txtFreezingPoint"
        Me.txtFreezingPoint.ReadOnly = True
        Me.txtFreezingPoint.Size = New System.Drawing.Size(72, 21)
        Me.txtFreezingPoint.TabIndex = 10
        Me.txtFreezingPoint.TabStop = False
        Me.txtFreezingPoint.Text = "32"
        '
        'lblFreezingPoint
        '
        Me.lblFreezingPoint.Location = New System.Drawing.Point(8, 124)
        Me.lblFreezingPoint.Name = "lblFreezingPoint"
        Me.lblFreezingPoint.Size = New System.Drawing.Size(96, 23)
        Me.lblFreezingPoint.TabIndex = 14
        Me.lblFreezingPoint.Text = "Freezing point"
        Me.lblFreezingPoint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSpecificGravity
        '
        Me.txtSpecificGravity.Location = New System.Drawing.Point(112, 96)
        Me.txtSpecificGravity.Name = "txtSpecificGravity"
        Me.txtSpecificGravity.Size = New System.Drawing.Size(72, 21)
        Me.txtSpecificGravity.TabIndex = 9
        Me.txtSpecificGravity.Text = "0"
        '
        'txtSpecificHeat
        '
        Me.txtSpecificHeat.Location = New System.Drawing.Point(112, 68)
        Me.txtSpecificHeat.Name = "txtSpecificHeat"
        Me.txtSpecificHeat.Size = New System.Drawing.Size(72, 21)
        Me.txtSpecificHeat.TabIndex = 8
        Me.txtSpecificHeat.Text = "0"
        '
        'lblSpecificGravity
        '
        Me.lblSpecificGravity.Location = New System.Drawing.Point(8, 96)
        Me.lblSpecificGravity.Name = "lblSpecificGravity"
        Me.lblSpecificGravity.Size = New System.Drawing.Size(96, 23)
        Me.lblSpecificGravity.TabIndex = 12
        Me.lblSpecificGravity.Text = "Specific gravity"
        Me.lblSpecificGravity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCoolingMediaPercent
        '
        Me.lblCoolingMediaPercent.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblCoolingMediaPercent.Location = New System.Drawing.Point(232, 12)
        Me.lblCoolingMediaPercent.Name = "lblCoolingMediaPercent"
        Me.lblCoolingMediaPercent.Size = New System.Drawing.Size(16, 23)
        Me.lblCoolingMediaPercent.TabIndex = 8
        Me.lblCoolingMediaPercent.Text = "%"
        Me.lblCoolingMediaPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSpecificHeat
        '
        Me.lblSpecificHeat.Location = New System.Drawing.Point(8, 68)
        Me.lblSpecificHeat.Name = "lblSpecificHeat"
        Me.lblSpecificHeat.Size = New System.Drawing.Size(96, 23)
        Me.lblSpecificHeat.TabIndex = 11
        Me.lblSpecificHeat.Text = "Specific heat"
        Me.lblSpecificHeat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPercentGlycol
        '
        Me.txtPercentGlycol.Enabled = False
        Me.txtPercentGlycol.Location = New System.Drawing.Point(188, 12)
        Me.txtPercentGlycol.Name = "txtPercentGlycol"
        Me.txtPercentGlycol.Size = New System.Drawing.Size(40, 21)
        Me.txtPercentGlycol.TabIndex = 5
        Me.txtPercentGlycol.Text = "0"
        '
        'lblCoolingMedia
        '
        Me.lblCoolingMedia.Location = New System.Drawing.Point(8, 40)
        Me.lblCoolingMedia.Name = "lblCoolingMedia"
        Me.lblCoolingMedia.Size = New System.Drawing.Size(96, 23)
        Me.lblCoolingMedia.TabIndex = 6
        Me.lblCoolingMedia.Text = "Cooling media"
        Me.lblCoolingMedia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFluid
        '
        Me.lblFluid.Location = New System.Drawing.Point(8, 12)
        Me.lblFluid.Name = "lblFluid"
        Me.lblFluid.Size = New System.Drawing.Size(96, 23)
        Me.lblFluid.TabIndex = 5
        Me.lblFluid.Text = "Fluid"
        Me.lblFluid.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboHertz
        '
        Me.cboHertz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHertz.Items.AddRange(New Object() {"60", "50"})
        Me.cboHertz.Location = New System.Drawing.Point(364, 124)
        Me.cboHertz.Name = "cboHertz"
        Me.cboHertz.Size = New System.Drawing.Size(72, 21)
        Me.cboHertz.TabIndex = 16
        '
        'lblLeavingFluidTemp
        '
        Me.lblLeavingFluidTemp.Location = New System.Drawing.Point(276, 96)
        Me.lblLeavingFluidTemp.Name = "lblLeavingFluidTemp"
        Me.lblLeavingFluidTemp.Size = New System.Drawing.Size(80, 23)
        Me.lblLeavingFluidTemp.TabIndex = 23
        Me.lblLeavingFluidTemp.Text = "Leaving fluid"
        Me.lblLeavingFluidTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTempRange
        '
        Me.lblTempRange.Location = New System.Drawing.Point(276, 40)
        Me.lblTempRange.Name = "lblTempRange"
        Me.lblTempRange.Size = New System.Drawing.Size(80, 23)
        Me.lblTempRange.TabIndex = 19
        Me.lblTempRange.Text = "Range"
        Me.lblTempRange.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAmbientTemp
        '
        Me.lblAmbientTemp.Location = New System.Drawing.Point(276, 68)
        Me.lblAmbientTemp.Name = "lblAmbientTemp"
        Me.lblAmbientTemp.Size = New System.Drawing.Size(80, 23)
        Me.lblAmbientTemp.TabIndex = 21
        Me.lblAmbientTemp.Text = "Ambient"
        Me.lblAmbientTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMinSuctionTemp
        '
        Me.txtMinSuctionTemp.Location = New System.Drawing.Point(112, 152)
        Me.txtMinSuctionTemp.Name = "txtMinSuctionTemp"
        Me.txtMinSuctionTemp.ReadOnly = True
        Me.txtMinSuctionTemp.Size = New System.Drawing.Size(72, 21)
        Me.txtMinSuctionTemp.TabIndex = 11
        Me.txtMinSuctionTemp.TabStop = False
        Me.txtMinSuctionTemp.Text = "33"
        Me.ToolTip1.SetToolTip(Me.txtMinSuctionTemp, "Recommend minimum suction temperature")
        '
        'lblFreezingPointPercentF
        '
        Me.lblFreezingPointPercentF.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblFreezingPointPercentF.Location = New System.Drawing.Point(188, 124)
        Me.lblFreezingPointPercentF.Name = "lblFreezingPointPercentF"
        Me.lblFreezingPointPercentF.Size = New System.Drawing.Size(24, 23)
        Me.lblFreezingPointPercentF.TabIndex = 15
        Me.lblFreezingPointPercentF.Text = "°F"
        Me.lblFreezingPointPercentF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLeavingFluidTemp
        '
        Me.txtLeavingFluidTemp.Location = New System.Drawing.Point(364, 96)
        Me.txtLeavingFluidTemp.Name = "txtLeavingFluidTemp"
        Me.txtLeavingFluidTemp.Size = New System.Drawing.Size(72, 21)
        Me.txtLeavingFluidTemp.TabIndex = 15
        Me.txtLeavingFluidTemp.Text = "44"
        '
        'lblRefrigerant
        '
        Me.lblRefrigerant.Location = New System.Drawing.Point(276, 12)
        Me.lblRefrigerant.Name = "lblRefrigerant"
        Me.lblRefrigerant.Size = New System.Drawing.Size(80, 23)
        Me.lblRefrigerant.TabIndex = 16
        Me.lblRefrigerant.Text = "Refrigerant"
        Me.lblRefrigerant.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAmbientTemp
        '
        Me.txtAmbientTemp.Location = New System.Drawing.Point(364, 68)
        Me.txtAmbientTemp.Name = "txtAmbientTemp"
        Me.txtAmbientTemp.Size = New System.Drawing.Size(72, 21)
        Me.txtAmbientTemp.TabIndex = 14
        Me.txtAmbientTemp.Text = "95"
        '
        'lblSystem
        '
        Me.lblSystem.Location = New System.Drawing.Point(276, 152)
        Me.lblSystem.Name = "lblSystem"
        Me.lblSystem.Size = New System.Drawing.Size(80, 23)
        Me.lblSystem.TabIndex = 36
        Me.lblSystem.Text = "System"
        Me.lblSystem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblSystem.Visible = False
        '
        'cboTempRange
        '
        Me.cboTempRange.Items.AddRange(New Object() {"6", "6.25", "6.5", "6.75", "7", "7.5", "8", "8.5", "9", "9.5", "10", "10.5", "11", "11.5", "12", "12.5", "13", "13.5", "14", "14.5", "15", "15.5", "16", "16.5", "17", "17.5", "18", "18.5", "19", "19.5", "20"})
        Me.cboTempRange.Location = New System.Drawing.Point(364, 40)
        Me.cboTempRange.Name = "cboTempRange"
        Me.cboTempRange.Size = New System.Drawing.Size(72, 21)
        Me.cboTempRange.TabIndex = 13
        Me.cboTempRange.Text = "10"
        '
        'cboRefrigerant
        '
        Me.cboRefrigerant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRefrigerant.Enabled = False
        Me.cboRefrigerant.Location = New System.Drawing.Point(364, 12)
        Me.cboRefrigerant.Name = "cboRefrigerant"
        Me.cboRefrigerant.Size = New System.Drawing.Size(72, 21)
        Me.cboRefrigerant.TabIndex = 12
        Me.cboRefrigerant.TabStop = False
        '
        'cbo_glycol
        '
        Me.cbo_glycol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_glycol.Items.AddRange(New Object() {"Propylene", "Ethylene"})
        Me.cbo_glycol.Location = New System.Drawing.Point(112, 40)
        Me.cbo_glycol.Name = "cbo_glycol"
        Me.cbo_glycol.Size = New System.Drawing.Size(72, 21)
        Me.cbo_glycol.TabIndex = 6
        Me.cbo_glycol.Visible = False
        '
        'lblHertz
        '
        Me.lblHertz.Location = New System.Drawing.Point(276, 124)
        Me.lblHertz.Name = "lblHertz"
        Me.lblHertz.Size = New System.Drawing.Size(80, 23)
        Me.lblHertz.TabIndex = 27
        Me.lblHertz.Text = "Hertz"
        Me.lblHertz.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMinSuctionTempF
        '
        Me.lblMinSuctionTempF.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblMinSuctionTempF.Location = New System.Drawing.Point(188, 152)
        Me.lblMinSuctionTempF.Name = "lblMinSuctionTempF"
        Me.lblMinSuctionTempF.Size = New System.Drawing.Size(24, 23)
        Me.lblMinSuctionTempF.TabIndex = 43
        Me.lblMinSuctionTempF.Text = "°F"
        Me.lblMinSuctionTempF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLeavingFluidTempF
        '
        Me.lblLeavingFluidTempF.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblLeavingFluidTempF.Location = New System.Drawing.Point(440, 96)
        Me.lblLeavingFluidTempF.Name = "lblLeavingFluidTempF"
        Me.lblLeavingFluidTempF.Size = New System.Drawing.Size(64, 23)
        Me.lblLeavingFluidTempF.TabIndex = 42
        Me.lblLeavingFluidTempF.Text = "-40 to 75°F"
        Me.lblLeavingFluidTempF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMinSuctionTemp
        '
        Me.lblMinSuctionTemp.Location = New System.Drawing.Point(8, 152)
        Me.lblMinSuctionTemp.Name = "lblMinSuctionTemp"
        Me.lblMinSuctionTemp.Size = New System.Drawing.Size(96, 23)
        Me.lblMinSuctionTemp.TabIndex = 25
        Me.lblMinSuctionTemp.Text = "Minimum suction"
        Me.lblMinSuctionTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblMinSuctionTemp, "Recommended minimum suction temperature")
        '
        'lblAmbientTempF
        '
        Me.lblAmbientTempF.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblAmbientTempF.Location = New System.Drawing.Point(440, 68)
        Me.lblAmbientTempF.Name = "lblAmbientTempF"
        Me.lblAmbientTempF.Size = New System.Drawing.Size(38, 23)
        Me.lblAmbientTempF.TabIndex = 41
        Me.lblAmbientTempF.Text = "°F"
        Me.lblAmbientTempF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSystem
        '
        Me.cboSystem.Items.AddRange(New Object() {"FULL", "HALF"})
        Me.cboSystem.Location = New System.Drawing.Point(364, 152)
        Me.cboSystem.Name = "cboSystem"
        Me.cboSystem.Size = New System.Drawing.Size(72, 21)
        Me.cboSystem.TabIndex = 17
        Me.cboSystem.Text = "FULL"
        Me.cboSystem.Visible = False
        '
        'cboFluid
        '
        Me.cboFluid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFluid.Items.AddRange(New Object() {"Water", "Glycol"})
        Me.cboFluid.Location = New System.Drawing.Point(112, 12)
        Me.cboFluid.Name = "cboFluid"
        Me.cboFluid.Size = New System.Drawing.Size(72, 21)
        Me.cboFluid.TabIndex = 4
        '
        'lbl_Volts1
        '
        Me.lbl_Volts1.ForeColor = System.Drawing.Color.Gray
        Me.lbl_Volts1.Location = New System.Drawing.Point(440, 132)
        Me.lbl_Volts1.Name = "lbl_Volts1"
        Me.lbl_Volts1.Size = New System.Drawing.Size(32, 21)
        Me.lbl_Volts1.TabIndex = 31
        Me.lbl_Volts1.Text = "only"
        Me.lbl_Volts1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl_Volts1.Visible = False
        '
        'lbl_Volts
        '
        Me.lbl_Volts.ForeColor = System.Drawing.Color.Gray
        Me.lbl_Volts.Location = New System.Drawing.Point(440, 116)
        Me.lbl_Volts.Name = "lbl_Volts"
        Me.lbl_Volts.Size = New System.Drawing.Size(56, 21)
        Me.lbl_Volts.TabIndex = 30
        Me.lbl_Volts.Text = "380 Volts"
        Me.lbl_Volts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl_Volts.Visible = False
        '
        'hid_lblApproach
        '
        Me.hid_lblApproach.BackColor = System.Drawing.Color.Yellow
        Me.hid_lblApproach.Location = New System.Drawing.Point(512, 8)
        Me.hid_lblApproach.Name = "hid_lblApproach"
        Me.hid_lblApproach.Size = New System.Drawing.Size(64, 23)
        Me.hid_lblApproach.TabIndex = 32
        Me.hid_lblApproach.Text = "Approach"
        Me.hid_lblApproach.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'hid_txtApproach
        '
        Me.hid_txtApproach.BackColor = System.Drawing.Color.Yellow
        Me.hid_txtApproach.Location = New System.Drawing.Point(584, 8)
        Me.hid_txtApproach.Name = "hid_txtApproach"
        Me.hid_txtApproach.ReadOnly = True
        Me.hid_txtApproach.Size = New System.Drawing.Size(48, 21)
        Me.hid_txtApproach.TabIndex = 33
        Me.hid_txtApproach.Tag = "leavingFluidTemp - evapTemp"
        Me.ToolTip1.SetToolTip(Me.hid_txtApproach, "leavingFluidTemp - evapTemp")
        '
        'pan_main
        '
        Me.pan_main.AutoScroll = True
        Me.pan_main.Controls.Add(Me.panGrid)
        Me.pan_main.Controls.Add(Me.pan_evaporator)
        Me.pan_main.Controls.Add(Me.pan_condenser)
        Me.pan_main.Controls.Add(Me.pan_compressor)
        Me.pan_main.Controls.Add(Me.pan_rating_criteria)
        Me.pan_main.Controls.Add(Me.pan_model)
        Me.pan_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pan_main.Location = New System.Drawing.Point(0, 32)
        Me.pan_main.Name = "pan_main"
        Me.pan_main.Size = New System.Drawing.Size(679, 519)
        Me.pan_main.TabIndex = 5
        '
        'panGrid
        '
        Me.panGrid.Controls.Add(Me.DataGridView2)
        Me.panGrid.Controls.Add(Me.DataGridView1)
        Me.panGrid.Controls.Add(Me.hid_panResults)
        Me.panGrid.Controls.Add(Me.lblLimits)
        Me.panGrid.Dock = System.Windows.Forms.DockStyle.Top
        Me.panGrid.Location = New System.Drawing.Point(0, 928)
        Me.panGrid.Name = "panGrid"
        Me.panGrid.Size = New System.Drawing.Size(662, 310)
        Me.panGrid.TabIndex = 10
        '
        'hid_panResults
        '
        Me.hid_panResults.BackColor = System.Drawing.Color.Yellow
        Me.hid_panResults.Controls.Add(Me.Txt10Deg_1)
        Me.hid_panResults.Controls.Add(Me.Txt8Deg_2)
        Me.hid_panResults.Controls.Add(Me.Txt_circuit_per_unit)
        Me.hid_panResults.Controls.Add(Me.TxtCondCap)
        Me.hid_panResults.Controls.Add(Me.Txt10Deg_2)
        Me.hid_panResults.Controls.Add(Me.TxtTonsSystemCap)
        Me.hid_panResults.Controls.Add(Me.txt_gpm)
        Me.hid_panResults.Controls.Add(Me.cboChiller11)
        Me.hid_panResults.Controls.Add(Me.txt_Evap_Length)
        Me.hid_panResults.Controls.Add(Me.Txt8Deg_1)
        Me.hid_panResults.Location = New System.Drawing.Point(637, 6)
        Me.hid_panResults.Name = "hid_panResults"
        Me.hid_panResults.Size = New System.Drawing.Size(78, 298)
        Me.hid_panResults.TabIndex = 91
        Me.hid_panResults.Visible = False
        '
        'Txt10Deg_1
        '
        Me.Txt10Deg_1.Location = New System.Drawing.Point(7, 100)
        Me.Txt10Deg_1.Name = "Txt10Deg_1"
        Me.Txt10Deg_1.Size = New System.Drawing.Size(48, 21)
        Me.Txt10Deg_1.TabIndex = 83
        Me.Txt10Deg_1.Text = "0"
        '
        'Txt8Deg_2
        '
        Me.Txt8Deg_2.Location = New System.Drawing.Point(9, 194)
        Me.Txt8Deg_2.Name = "Txt8Deg_2"
        Me.Txt8Deg_2.Size = New System.Drawing.Size(48, 21)
        Me.Txt8Deg_2.TabIndex = 82
        Me.Txt8Deg_2.Text = "0"
        '
        'Txt_circuit_per_unit
        '
        Me.Txt_circuit_per_unit.Location = New System.Drawing.Point(9, 146)
        Me.Txt_circuit_per_unit.Name = "Txt_circuit_per_unit"
        Me.Txt_circuit_per_unit.Size = New System.Drawing.Size(48, 21)
        Me.Txt_circuit_per_unit.TabIndex = 79
        '
        'TxtCondCap
        '
        Me.TxtCondCap.Location = New System.Drawing.Point(6, 53)
        Me.TxtCondCap.Name = "TxtCondCap"
        Me.TxtCondCap.Size = New System.Drawing.Size(48, 21)
        Me.TxtCondCap.TabIndex = 85
        Me.TxtCondCap.Text = "0"
        '
        'Txt10Deg_2
        '
        Me.Txt10Deg_2.Location = New System.Drawing.Point(9, 215)
        Me.Txt10Deg_2.Name = "Txt10Deg_2"
        Me.Txt10Deg_2.Size = New System.Drawing.Size(48, 21)
        Me.Txt10Deg_2.TabIndex = 84
        Me.Txt10Deg_2.Text = "0"
        '
        'TxtTonsSystemCap
        '
        Me.TxtTonsSystemCap.Location = New System.Drawing.Point(6, 5)
        Me.TxtTonsSystemCap.Name = "TxtTonsSystemCap"
        Me.TxtTonsSystemCap.Size = New System.Drawing.Size(48, 21)
        Me.TxtTonsSystemCap.TabIndex = 76
        Me.TxtTonsSystemCap.Text = "0"
        '
        'txt_gpm
        '
        Me.txt_gpm.Location = New System.Drawing.Point(6, 29)
        Me.txt_gpm.Name = "txt_gpm"
        Me.txt_gpm.Size = New System.Drawing.Size(48, 21)
        Me.txt_gpm.TabIndex = 77
        Me.txt_gpm.Text = "0"
        '
        'cboChiller11
        '
        Me.cboChiller11.Location = New System.Drawing.Point(8, 123)
        Me.cboChiller11.Name = "cboChiller11"
        Me.cboChiller11.Size = New System.Drawing.Size(47, 21)
        Me.cboChiller11.TabIndex = 78
        '
        'txt_Evap_Length
        '
        Me.txt_Evap_Length.Location = New System.Drawing.Point(8, 171)
        Me.txt_Evap_Length.Name = "txt_Evap_Length"
        Me.txt_Evap_Length.Size = New System.Drawing.Size(48, 21)
        Me.txt_Evap_Length.TabIndex = 80
        '
        'Txt8Deg_1
        '
        Me.Txt8Deg_1.Location = New System.Drawing.Point(7, 76)
        Me.Txt8Deg_1.Name = "Txt8Deg_1"
        Me.Txt8Deg_1.Size = New System.Drawing.Size(48, 21)
        Me.Txt8Deg_1.TabIndex = 81
        Me.Txt8Deg_1.Text = "0"
        '
        'lblLimits
        '
        Me.lblLimits.Location = New System.Drawing.Point(8, 0)
        Me.lblLimits.Name = "lblLimits"
        Me.lblLimits.Size = New System.Drawing.Size(472, 16)
        Me.lblLimits.TabIndex = 0
        Me.lblLimits.Text = "Points outside operating limits omitted."
        Me.lblLimits.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'pan_evaporator
        '
        Me.pan_evaporator.Controls.Add(Me.panEvaporatorControls)
        Me.pan_evaporator.Controls.Add(Me.hid_panEvaporator)
        Me.pan_evaporator.Dock = System.Windows.Forms.DockStyle.Top
        Me.pan_evaporator.Location = New System.Drawing.Point(0, 788)
        Me.pan_evaporator.Name = "pan_evaporator"
        Me.pan_evaporator.Size = New System.Drawing.Size(662, 140)
        Me.pan_evaporator.TabIndex = 5
        '
        'panEvaporatorControls
        '
        Me.panEvaporatorControls.Controls.Add(Me.txtCapacity)
        Me.panEvaporatorControls.Controls.Add(Me.btn_alternate_evaporators)
        Me.panEvaporatorControls.Controls.Add(Me.cboFoulingFactor)
        Me.panEvaporatorControls.Controls.Add(Me.lblEvaporator)
        Me.panEvaporatorControls.Controls.Add(Me.cbo_evaporators)
        Me.panEvaporatorControls.Controls.Add(Me.chkCatalog)
        Me.panEvaporatorControls.Controls.Add(Me.txt_evaporator)
        Me.panEvaporatorControls.Controls.Add(Me.lblFoulingFactor)
        Me.panEvaporatorControls.Controls.Add(Me.Panel3)
        Me.panEvaporatorControls.Location = New System.Drawing.Point(8, 0)
        Me.panEvaporatorControls.Name = "panEvaporatorControls"
        Me.panEvaporatorControls.Size = New System.Drawing.Size(504, 128)
        Me.panEvaporatorControls.TabIndex = 1
        '
        'txtCapacity
        '
        Me.txtCapacity.Location = New System.Drawing.Point(156, 96)
        Me.txtCapacity.Name = "txtCapacity"
        Me.txtCapacity.Size = New System.Drawing.Size(72, 21)
        Me.txtCapacity.TabIndex = 5
        Me.txtCapacity.Text = "0"
        '
        'btn_alternate_evaporators
        '
        Me.btn_alternate_evaporators.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_alternate_evaporators.Location = New System.Drawing.Point(16, 12)
        Me.btn_alternate_evaporators.Name = "btn_alternate_evaporators"
        Me.btn_alternate_evaporators.Size = New System.Drawing.Size(128, 23)
        Me.btn_alternate_evaporators.TabIndex = 1
        Me.btn_alternate_evaporators.Text = "Alternate Evaporators"
        '
        'cboFoulingFactor
        '
        Me.cboFoulingFactor.Items.AddRange(New Object() {".0001", ".00025", ".0005", ".00075", ".001"})
        Me.cboFoulingFactor.Location = New System.Drawing.Point(156, 68)
        Me.cboFoulingFactor.Name = "cboFoulingFactor"
        Me.cboFoulingFactor.Size = New System.Drawing.Size(72, 21)
        Me.cboFoulingFactor.TabIndex = 3
        Me.cboFoulingFactor.Text = ".0001"
        '
        'lblEvaporator
        '
        Me.lblEvaporator.Location = New System.Drawing.Point(48, 40)
        Me.lblEvaporator.Name = "lblEvaporator"
        Me.lblEvaporator.Size = New System.Drawing.Size(100, 23)
        Me.lblEvaporator.TabIndex = 3
        Me.lblEvaporator.Text = "Evaporator"
        Me.lblEvaporator.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbo_evaporators
        '
        Me.cbo_evaporators.Location = New System.Drawing.Point(156, 12)
        Me.cbo_evaporators.Name = "cbo_evaporators"
        Me.cbo_evaporators.Size = New System.Drawing.Size(120, 21)
        Me.cbo_evaporators.TabIndex = 2
        Me.cbo_evaporators.Visible = False
        '
        'chkCatalog
        '
        Me.chkCatalog.BackColor = System.Drawing.Color.Yellow
        Me.chkCatalog.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkCatalog.Location = New System.Drawing.Point(236, 96)
        Me.chkCatalog.Name = "chkCatalog"
        Me.chkCatalog.Size = New System.Drawing.Size(104, 20)
        Me.chkCatalog.TabIndex = 6
        Me.chkCatalog.Text = "Catalog rating"
        Me.chkCatalog.UseVisualStyleBackColor = False
        '
        'txt_evaporator
        '
        Me.txt_evaporator.Location = New System.Drawing.Point(156, 40)
        Me.txt_evaporator.Name = "txt_evaporator"
        Me.txt_evaporator.ReadOnly = True
        Me.txt_evaporator.Size = New System.Drawing.Size(120, 21)
        Me.txt_evaporator.TabIndex = 2
        Me.txt_evaporator.TabStop = False
        '
        'lblFoulingFactor
        '
        Me.lblFoulingFactor.Location = New System.Drawing.Point(48, 68)
        Me.lblFoulingFactor.Name = "lblFoulingFactor"
        Me.lblFoulingFactor.Size = New System.Drawing.Size(100, 23)
        Me.lblFoulingFactor.TabIndex = 5
        Me.lblFoulingFactor.Text = "Fouling factor"
        Me.lblFoulingFactor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.radCapacityTons)
        Me.Panel3.Controls.Add(Me.radCapacityGpm)
        Me.Panel3.Location = New System.Drawing.Point(32, 88)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(120, 32)
        Me.Panel3.TabIndex = 4
        '
        'radCapacityTons
        '
        Me.radCapacityTons.Checked = True
        Me.radCapacityTons.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.radCapacityTons.Location = New System.Drawing.Point(8, 8)
        Me.radCapacityTons.Name = "radCapacityTons"
        Me.radCapacityTons.Size = New System.Drawing.Size(64, 24)
        Me.radCapacityTons.TabIndex = 1
        Me.radCapacityTons.TabStop = True
        Me.radCapacityTons.Text = "Tons (est.)"
        '
        'radCapacityGpm
        '
        Me.radCapacityGpm.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.radCapacityGpm.Location = New System.Drawing.Point(72, 8)
        Me.radCapacityGpm.Name = "radCapacityGpm"
        Me.radCapacityGpm.Size = New System.Drawing.Size(48, 24)
        Me.radCapacityGpm.TabIndex = 2
        Me.radCapacityGpm.Text = "GPM (est.)"
        '
        'hid_panEvaporator
        '
        Me.hid_panEvaporator.BackColor = System.Drawing.Color.Yellow
        Me.hid_panEvaporator.Controls.Add(Me.txt4Deg)
        Me.hid_panEvaporator.Controls.Add(Me.txt9)
        Me.hid_panEvaporator.Controls.Add(Me.txt4)
        Me.hid_panEvaporator.Controls.Add(Me.txt11Deg)
        Me.hid_panEvaporator.Controls.Add(Me.hid_panApproach)
        Me.hid_panEvaporator.Controls.Add(Me.txt7Deg)
        Me.hid_panEvaporator.Controls.Add(Me.txt7)
        Me.hid_panEvaporator.Controls.Add(Me.txt5)
        Me.hid_panEvaporator.Controls.Add(Me.txt6Deg)
        Me.hid_panEvaporator.Controls.Add(Me.txt10Deg)
        Me.hid_panEvaporator.Controls.Add(Me.txt9Deg)
        Me.hid_panEvaporator.Controls.Add(Me.txt5Deg)
        Me.hid_panEvaporator.Controls.Add(Me.lblEvap4Degr)
        Me.hid_panEvaporator.Controls.Add(Me.lblEvap5Degr)
        Me.hid_panEvaporator.Controls.Add(Me.lblEvap7Degr)
        Me.hid_panEvaporator.Controls.Add(Me.txt10)
        Me.hid_panEvaporator.Controls.Add(Me.txt12Deg)
        Me.hid_panEvaporator.Controls.Add(Me.txt12)
        Me.hid_panEvaporator.Controls.Add(Me.txt11)
        Me.hid_panEvaporator.Controls.Add(Me.txt8Deg)
        Me.hid_panEvaporator.Controls.Add(Me.txt8)
        Me.hid_panEvaporator.Controls.Add(Me.txt6)
        Me.hid_panEvaporator.Controls.Add(Me.lblEvap9Degr)
        Me.hid_panEvaporator.Controls.Add(Me.lblEvap6Degr)
        Me.hid_panEvaporator.Controls.Add(Me.lblEvap8Degr)
        Me.hid_panEvaporator.Controls.Add(Me.lblEvap10Degr)
        Me.hid_panEvaporator.Controls.Add(Me.lblEvap12Degree)
        Me.hid_panEvaporator.Controls.Add(Me.lblEvap11Degr)
        Me.hid_panEvaporator.Controls.Add(Me.TXT_ERROR_1_BOX)
        Me.hid_panEvaporator.Controls.Add(Me.TextBox1)
        Me.hid_panEvaporator.Location = New System.Drawing.Point(520, 4)
        Me.hid_panEvaporator.Name = "hid_panEvaporator"
        Me.hid_panEvaporator.Size = New System.Drawing.Size(320, 224)
        Me.hid_panEvaporator.TabIndex = 77
        Me.hid_panEvaporator.Visible = False
        '
        'txt4Deg
        '
        Me.txt4Deg.Location = New System.Drawing.Point(84, 4)
        Me.txt4Deg.Name = "txt4Deg"
        Me.txt4Deg.ReadOnly = True
        Me.txt4Deg.Size = New System.Drawing.Size(65, 21)
        Me.txt4Deg.TabIndex = 66
        '
        'txt9
        '
        Me.txt9.Location = New System.Drawing.Point(240, 124)
        Me.txt9.Name = "txt9"
        Me.txt9.ReadOnly = True
        Me.txt9.Size = New System.Drawing.Size(70, 21)
        Me.txt9.TabIndex = 72
        '
        'txt4
        '
        Me.txt4.Location = New System.Drawing.Point(240, 4)
        Me.txt4.Name = "txt4"
        Me.txt4.ReadOnly = True
        Me.txt4.Size = New System.Drawing.Size(70, 21)
        Me.txt4.TabIndex = 67
        '
        'txt11Deg
        '
        Me.txt11Deg.Location = New System.Drawing.Point(84, 172)
        Me.txt11Deg.Name = "txt11Deg"
        Me.txt11Deg.ReadOnly = True
        Me.txt11Deg.Size = New System.Drawing.Size(65, 21)
        Me.txt11Deg.TabIndex = 59
        '
        'hid_panApproach
        '
        Me.hid_panApproach.Controls.Add(Me.rb10_12)
        Me.hid_panApproach.Controls.Add(Me.rb9_11)
        Me.hid_panApproach.Controls.Add(Me.rb8_10)
        Me.hid_panApproach.Controls.Add(Me.rb7_9)
        Me.hid_panApproach.Controls.Add(Me.rb6_8)
        Me.hid_panApproach.Controls.Add(Me.rbOther_Approch)
        Me.hid_panApproach.Location = New System.Drawing.Point(4, 4)
        Me.hid_panApproach.Name = "hid_panApproach"
        Me.hid_panApproach.Size = New System.Drawing.Size(72, 204)
        Me.hid_panApproach.TabIndex = 52
        '
        'rb10_12
        '
        Me.rb10_12.Location = New System.Drawing.Point(6, 104)
        Me.rb10_12.Name = "rb10_12"
        Me.rb10_12.Size = New System.Drawing.Size(53, 24)
        Me.rb10_12.TabIndex = 4
        Me.rb10_12.Text = "10-12"
        '
        'rb9_11
        '
        Me.rb9_11.Location = New System.Drawing.Point(6, 80)
        Me.rb9_11.Name = "rb9_11"
        Me.rb9_11.Size = New System.Drawing.Size(52, 24)
        Me.rb9_11.TabIndex = 3
        Me.rb9_11.Text = "9-11"
        '
        'rb8_10
        '
        Me.rb8_10.Checked = True
        Me.rb8_10.Location = New System.Drawing.Point(6, 56)
        Me.rb8_10.Name = "rb8_10"
        Me.rb8_10.Size = New System.Drawing.Size(49, 24)
        Me.rb8_10.TabIndex = 2
        Me.rb8_10.TabStop = True
        Me.rb8_10.Text = "8-10"
        '
        'rb7_9
        '
        Me.rb7_9.Location = New System.Drawing.Point(6, 32)
        Me.rb7_9.Name = "rb7_9"
        Me.rb7_9.Size = New System.Drawing.Size(50, 24)
        Me.rb7_9.TabIndex = 1
        Me.rb7_9.Text = "7-9"
        '
        'rb6_8
        '
        Me.rb6_8.Location = New System.Drawing.Point(6, 8)
        Me.rb6_8.Name = "rb6_8"
        Me.rb6_8.Size = New System.Drawing.Size(43, 24)
        Me.rb6_8.TabIndex = 0
        Me.rb6_8.Text = "6-8"
        '
        'rbOther_Approch
        '
        Me.rbOther_Approch.Location = New System.Drawing.Point(5, 181)
        Me.rbOther_Approch.Name = "rbOther_Approch"
        Me.rbOther_Approch.Size = New System.Drawing.Size(132, 24)
        Me.rbOther_Approch.TabIndex = 3
        Me.rbOther_Approch.Text = "Other Evaporator"
        '
        'txt7Deg
        '
        Me.txt7Deg.Location = New System.Drawing.Point(84, 76)
        Me.txt7Deg.Name = "txt7Deg"
        Me.txt7Deg.ReadOnly = True
        Me.txt7Deg.Size = New System.Drawing.Size(65, 21)
        Me.txt7Deg.TabIndex = 48
        '
        'txt7
        '
        Me.txt7.Location = New System.Drawing.Point(240, 76)
        Me.txt7.Name = "txt7"
        Me.txt7.ReadOnly = True
        Me.txt7.Size = New System.Drawing.Size(70, 21)
        Me.txt7.TabIndex = 70
        '
        'txt5
        '
        Me.txt5.Location = New System.Drawing.Point(240, 28)
        Me.txt5.Name = "txt5"
        Me.txt5.ReadOnly = True
        Me.txt5.Size = New System.Drawing.Size(70, 21)
        Me.txt5.TabIndex = 68
        '
        'txt6Deg
        '
        Me.txt6Deg.Location = New System.Drawing.Point(84, 52)
        Me.txt6Deg.Name = "txt6Deg"
        Me.txt6Deg.ReadOnly = True
        Me.txt6Deg.Size = New System.Drawing.Size(65, 21)
        Me.txt6Deg.TabIndex = 53
        '
        'txt10Deg
        '
        Me.txt10Deg.Location = New System.Drawing.Point(84, 148)
        Me.txt10Deg.Name = "txt10Deg"
        Me.txt10Deg.ReadOnly = True
        Me.txt10Deg.Size = New System.Drawing.Size(65, 21)
        Me.txt10Deg.TabIndex = 58
        '
        'txt9Deg
        '
        Me.txt9Deg.Location = New System.Drawing.Point(84, 124)
        Me.txt9Deg.Name = "txt9Deg"
        Me.txt9Deg.ReadOnly = True
        Me.txt9Deg.Size = New System.Drawing.Size(65, 21)
        Me.txt9Deg.TabIndex = 50
        '
        'txt5Deg
        '
        Me.txt5Deg.Location = New System.Drawing.Point(84, 28)
        Me.txt5Deg.Name = "txt5Deg"
        Me.txt5Deg.ReadOnly = True
        Me.txt5Deg.Size = New System.Drawing.Size(65, 21)
        Me.txt5Deg.TabIndex = 65
        '
        'lblEvap4Degr
        '
        Me.lblEvap4Degr.Location = New System.Drawing.Point(156, 4)
        Me.lblEvap4Degr.Name = "lblEvap4Degr"
        Me.lblEvap4Degr.Size = New System.Drawing.Size(80, 23)
        Me.lblEvap4Degr.TabIndex = 63
        Me.lblEvap4Degr.Text = "4°F Approach"
        Me.lblEvap4Degr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEvap5Degr
        '
        Me.lblEvap5Degr.Location = New System.Drawing.Point(156, 28)
        Me.lblEvap5Degr.Name = "lblEvap5Degr"
        Me.lblEvap5Degr.Size = New System.Drawing.Size(80, 23)
        Me.lblEvap5Degr.TabIndex = 64
        Me.lblEvap5Degr.Text = "5°F Approach"
        Me.lblEvap5Degr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEvap7Degr
        '
        Me.lblEvap7Degr.Location = New System.Drawing.Point(156, 76)
        Me.lblEvap7Degr.Name = "lblEvap7Degr"
        Me.lblEvap7Degr.Size = New System.Drawing.Size(80, 23)
        Me.lblEvap7Degr.TabIndex = 55
        Me.lblEvap7Degr.Text = "7°F Approach"
        Me.lblEvap7Degr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt10
        '
        Me.txt10.Location = New System.Drawing.Point(240, 148)
        Me.txt10.Name = "txt10"
        Me.txt10.ReadOnly = True
        Me.txt10.Size = New System.Drawing.Size(70, 21)
        Me.txt10.TabIndex = 73
        '
        'txt12Deg
        '
        Me.txt12Deg.Location = New System.Drawing.Point(84, 196)
        Me.txt12Deg.Name = "txt12Deg"
        Me.txt12Deg.ReadOnly = True
        Me.txt12Deg.Size = New System.Drawing.Size(65, 21)
        Me.txt12Deg.TabIndex = 60
        '
        'txt12
        '
        Me.txt12.Location = New System.Drawing.Point(240, 196)
        Me.txt12.Name = "txt12"
        Me.txt12.ReadOnly = True
        Me.txt12.Size = New System.Drawing.Size(70, 21)
        Me.txt12.TabIndex = 75
        '
        'txt11
        '
        Me.txt11.Location = New System.Drawing.Point(240, 172)
        Me.txt11.Name = "txt11"
        Me.txt11.ReadOnly = True
        Me.txt11.Size = New System.Drawing.Size(70, 21)
        Me.txt11.TabIndex = 74
        '
        'txt8Deg
        '
        Me.txt8Deg.Location = New System.Drawing.Point(84, 100)
        Me.txt8Deg.Name = "txt8Deg"
        Me.txt8Deg.ReadOnly = True
        Me.txt8Deg.Size = New System.Drawing.Size(65, 21)
        Me.txt8Deg.TabIndex = 49
        '
        'txt8
        '
        Me.txt8.Location = New System.Drawing.Point(240, 100)
        Me.txt8.Name = "txt8"
        Me.txt8.ReadOnly = True
        Me.txt8.Size = New System.Drawing.Size(70, 21)
        Me.txt8.TabIndex = 71
        '
        'txt6
        '
        Me.txt6.Location = New System.Drawing.Point(240, 52)
        Me.txt6.Name = "txt6"
        Me.txt6.ReadOnly = True
        Me.txt6.Size = New System.Drawing.Size(70, 21)
        Me.txt6.TabIndex = 69
        '
        'lblEvap9Degr
        '
        Me.lblEvap9Degr.Location = New System.Drawing.Point(158, 124)
        Me.lblEvap9Degr.Name = "lblEvap9Degr"
        Me.lblEvap9Degr.Size = New System.Drawing.Size(80, 23)
        Me.lblEvap9Degr.TabIndex = 56
        Me.lblEvap9Degr.Text = "9°F Approach"
        Me.lblEvap9Degr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEvap6Degr
        '
        Me.lblEvap6Degr.Location = New System.Drawing.Point(156, 52)
        Me.lblEvap6Degr.Name = "lblEvap6Degr"
        Me.lblEvap6Degr.Size = New System.Drawing.Size(80, 23)
        Me.lblEvap6Degr.TabIndex = 54
        Me.lblEvap6Degr.Text = "6°F Approach"
        Me.lblEvap6Degr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEvap8Degr
        '
        Me.lblEvap8Degr.Location = New System.Drawing.Point(158, 100)
        Me.lblEvap8Degr.Name = "lblEvap8Degr"
        Me.lblEvap8Degr.Size = New System.Drawing.Size(80, 23)
        Me.lblEvap8Degr.TabIndex = 51
        Me.lblEvap8Degr.Text = "8°F Approach"
        Me.lblEvap8Degr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEvap10Degr
        '
        Me.lblEvap10Degr.Location = New System.Drawing.Point(158, 148)
        Me.lblEvap10Degr.Name = "lblEvap10Degr"
        Me.lblEvap10Degr.Size = New System.Drawing.Size(80, 23)
        Me.lblEvap10Degr.TabIndex = 57
        Me.lblEvap10Degr.Text = "10°F Approach"
        Me.lblEvap10Degr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEvap12Degree
        '
        Me.lblEvap12Degree.Location = New System.Drawing.Point(156, 196)
        Me.lblEvap12Degree.Name = "lblEvap12Degree"
        Me.lblEvap12Degree.Size = New System.Drawing.Size(80, 23)
        Me.lblEvap12Degree.TabIndex = 62
        Me.lblEvap12Degree.Text = "12°F Approach"
        Me.lblEvap12Degree.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEvap11Degr
        '
        Me.lblEvap11Degr.Location = New System.Drawing.Point(156, 172)
        Me.lblEvap11Degr.Name = "lblEvap11Degr"
        Me.lblEvap11Degr.Size = New System.Drawing.Size(80, 23)
        Me.lblEvap11Degr.TabIndex = 61
        Me.lblEvap11Degr.Text = "11°F Approach"
        Me.lblEvap11Degr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(60, 172)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(320, 20)
        Me.TextBox1.TabIndex = 10
        '
        'pan_condenser
        '
        Me.pan_condenser.Controls.Add(Me.hid_panCondenser)
        Me.pan_condenser.Controls.Add(Me.panCondenserControls)
        Me.pan_condenser.Dock = System.Windows.Forms.DockStyle.Top
        Me.pan_condenser.Location = New System.Drawing.Point(0, 464)
        Me.pan_condenser.Name = "pan_condenser"
        Me.pan_condenser.Size = New System.Drawing.Size(662, 324)
        Me.pan_condenser.TabIndex = 4
        '
        'hid_panCondenser
        '
        Me.hid_panCondenser.BackColor = System.Drawing.Color.Yellow
        Me.hid_panCondenser.Controls.Add(Me.DropDownList2)
        Me.hid_panCondenser.Controls.Add(Me.cboHidValues)
        Me.hid_panCondenser.Controls.Add(Me.DropDownList3)
        Me.hid_panCondenser.Controls.Add(Me.cbo_Suction_line_loss)
        Me.hid_panCondenser.Controls.Add(Me.txtCondenser_1)
        Me.hid_panCondenser.Controls.Add(Me.TxtCondCap_1)
        Me.hid_panCondenser.Controls.Add(Me.cbo_Discharge_line_loss)
        Me.hid_panCondenser.Controls.Add(Me.TxtCondCap_2)
        Me.hid_panCondenser.Controls.Add(Me.txtCondenser_2)
        Me.hid_panCondenser.Location = New System.Drawing.Point(520, 0)
        Me.hid_panCondenser.Name = "hid_panCondenser"
        Me.hid_panCondenser.Size = New System.Drawing.Size(96, 312)
        Me.hid_panCondenser.TabIndex = 60
        Me.hid_panCondenser.Visible = False
        '
        'DropDownList2
        '
        Me.DropDownList2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DropDownList2.Location = New System.Drawing.Point(12, 257)
        Me.DropDownList2.Name = "DropDownList2"
        Me.DropDownList2.Size = New System.Drawing.Size(77, 21)
        Me.DropDownList2.TabIndex = 54
        '
        'cboHidValues
        '
        Me.cboHidValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHidValues.Location = New System.Drawing.Point(12, 233)
        Me.cboHidValues.Name = "cboHidValues"
        Me.cboHidValues.Size = New System.Drawing.Size(77, 21)
        Me.cboHidValues.TabIndex = 53
        '
        'DropDownList3
        '
        Me.DropDownList3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DropDownList3.Location = New System.Drawing.Point(12, 281)
        Me.DropDownList3.Name = "DropDownList3"
        Me.DropDownList3.Size = New System.Drawing.Size(77, 21)
        Me.DropDownList3.TabIndex = 52
        '
        'cbo_Suction_line_loss
        '
        Me.cbo_Suction_line_loss.Items.AddRange(New Object() {"0", "0.5", "1", "1.5", "2"})
        Me.cbo_Suction_line_loss.Location = New System.Drawing.Point(12, 81)
        Me.cbo_Suction_line_loss.Name = "cbo_Suction_line_loss"
        Me.cbo_Suction_line_loss.Size = New System.Drawing.Size(56, 21)
        Me.cbo_Suction_line_loss.TabIndex = 49
        Me.cbo_Suction_line_loss.Text = "1"
        '
        'txtCondenser_1
        '
        Me.txtCondenser_1.Location = New System.Drawing.Point(12, 33)
        Me.txtCondenser_1.Name = "txtCondenser_1"
        Me.txtCondenser_1.Size = New System.Drawing.Size(76, 21)
        Me.txtCondenser_1.TabIndex = 50
        '
        'TxtCondCap_1
        '
        Me.TxtCondCap_1.Location = New System.Drawing.Point(12, 185)
        Me.TxtCondCap_1.Name = "TxtCondCap_1"
        Me.TxtCondCap_1.Size = New System.Drawing.Size(40, 21)
        Me.TxtCondCap_1.TabIndex = 46
        '
        'cbo_Discharge_line_loss
        '
        Me.cbo_Discharge_line_loss.Items.AddRange(New Object() {"0", "0.5", "1", "1.5", "2"})
        Me.cbo_Discharge_line_loss.Location = New System.Drawing.Point(12, 57)
        Me.cbo_Discharge_line_loss.Name = "cbo_Discharge_line_loss"
        Me.cbo_Discharge_line_loss.Size = New System.Drawing.Size(56, 21)
        Me.cbo_Discharge_line_loss.TabIndex = 48
        Me.cbo_Discharge_line_loss.Text = "1"
        '
        'TxtCondCap_2
        '
        Me.TxtCondCap_2.Location = New System.Drawing.Point(12, 209)
        Me.TxtCondCap_2.Name = "TxtCondCap_2"
        Me.TxtCondCap_2.Size = New System.Drawing.Size(40, 21)
        Me.TxtCondCap_2.TabIndex = 47
        '
        'txtCondenser_2
        '
        Me.txtCondenser_2.Location = New System.Drawing.Point(12, 9)
        Me.txtCondenser_2.Name = "txtCondenser_2"
        Me.txtCondenser_2.Size = New System.Drawing.Size(76, 21)
        Me.txtCondenser_2.TabIndex = 51
        '
        'panCondenserControls
        '
        Me.panCondenserControls.Controls.Add(Me.txtCfmOverRide)
        Me.panCondenserControls.Controls.Add(Me.lblCondenserFanValue2)
        Me.panCondenserControls.Controls.Add(Me.txtFinLength2)
        Me.panCondenserControls.Controls.Add(Me.txtNumFans1)
        Me.panCondenserControls.Controls.Add(Me.lblAltitude1)
        Me.panCondenserControls.Controls.Add(Me.lblFan)
        Me.panCondenserControls.Controls.Add(Me.cboSubCooling2)
        Me.panCondenserControls.Controls.Add(Me.lblNumFans1)
        Me.panCondenserControls.Controls.Add(Me.cboCoilFileName1)
        Me.panCondenserControls.Controls.Add(Me.txtAltitude2)
        Me.panCondenserControls.Controls.Add(Me.txtSubCoolingPercent2)
        Me.panCondenserControls.Controls.Add(Me.cboFpi2)
        Me.panCondenserControls.Controls.Add(Me.txtAltitude1)
        Me.panCondenserControls.Controls.Add(Me.txtFinHeight2)
        Me.panCondenserControls.Controls.Add(Me.txtNumFans2)
        Me.panCondenserControls.Controls.Add(Me.cboCoilFileName2)
        Me.panCondenserControls.Controls.Add(Me.lblFinHeight1)
        Me.panCondenserControls.Controls.Add(Me.txtFinHeight1)
        Me.panCondenserControls.Controls.Add(Me.lblFinsPerInch1)
        Me.panCondenserControls.Controls.Add(Me.lblSubCooling1)
        Me.panCondenserControls.Controls.Add(Me.txtSubCoolingPercent1)
        Me.panCondenserControls.Controls.Add(Me.cboFpi1)
        Me.panCondenserControls.Controls.Add(Me.lblFinLength1)
        Me.panCondenserControls.Controls.Add(Me.lblFinLength2)
        Me.panCondenserControls.Controls.Add(Me.lblSubCooling2)
        Me.panCondenserControls.Controls.Add(Me.txtNumCoils1)
        Me.panCondenserControls.Controls.Add(Me.lblNumFans2)
        Me.panCondenserControls.Controls.Add(Me.lblCondenser2)
        Me.panCondenserControls.Controls.Add(Me.lblNumCoils1)
        Me.panCondenserControls.Controls.Add(Me.lblCircuit2)
        Me.panCondenserControls.Controls.Add(Me.txtNumCoils2)
        Me.panCondenserControls.Controls.Add(Me.lblFinsPerInch2)
        Me.panCondenserControls.Controls.Add(Me.cboFan)
        Me.panCondenserControls.Controls.Add(Me.lblNumCoils2)
        Me.panCondenserControls.Controls.Add(Me.cboSubCooling1)
        Me.panCondenserControls.Controls.Add(Me.lblCondenser1)
        Me.panCondenserControls.Controls.Add(Me.lblCircuit1)
        Me.panCondenserControls.Controls.Add(Me.txtFinLength1)
        Me.panCondenserControls.Controls.Add(Me.lblFanWatts1)
        Me.panCondenserControls.Controls.Add(Me.txtFanWatts2)
        Me.panCondenserControls.Controls.Add(Me.txtFanWatts1)
        Me.panCondenserControls.Controls.Add(Me.lblAltitude2)
        Me.panCondenserControls.Controls.Add(Me.lblFinHeight2)
        Me.panCondenserControls.Controls.Add(Me.lblFanWatts2)
        Me.panCondenserControls.Location = New System.Drawing.Point(8, 0)
        Me.panCondenserControls.Name = "panCondenserControls"
        Me.panCondenserControls.Size = New System.Drawing.Size(504, 312)
        Me.panCondenserControls.TabIndex = 59
        '
        'txtCfmOverRide
        '
        Me.txtCfmOverRide.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCfmOverRide.Location = New System.Drawing.Point(344, 224)
        Me.txtCfmOverRide.Name = "txtCfmOverRide"
        Me.txtCfmOverRide.Size = New System.Drawing.Size(72, 21)
        Me.txtCfmOverRide.TabIndex = 18
        Me.ToolTip1.SetToolTip(Me.txtCfmOverRide, "CFM")
        Me.txtCfmOverRide.Visible = False
        '
        'lblCondenserFanValue2
        '
        Me.lblCondenserFanValue2.BackColor = System.Drawing.SystemColors.Control
        Me.lblCondenserFanValue2.ForeColor = System.Drawing.Color.Gray
        Me.lblCondenserFanValue2.Location = New System.Drawing.Point(344, 224)
        Me.lblCondenserFanValue2.Name = "lblCondenserFanValue2"
        Me.lblCondenserFanValue2.Size = New System.Drawing.Size(104, 23)
        Me.lblCondenserFanValue2.TabIndex = 59
        Me.lblCondenserFanValue2.Text = "Same as circuit 1"
        Me.lblCondenserFanValue2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCondenserFanValue2.Visible = False
        '
        'txtFinLength2
        '
        Me.txtFinLength2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFinLength2.Location = New System.Drawing.Point(344, 168)
        Me.txtFinLength2.Name = "txtFinLength2"
        Me.txtFinLength2.Size = New System.Drawing.Size(72, 21)
        Me.txtFinLength2.TabIndex = 16
        '
        'txtNumFans1
        '
        Me.txtNumFans1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumFans1.Location = New System.Drawing.Point(88, 252)
        Me.txtNumFans1.Name = "txtNumFans1"
        Me.txtNumFans1.Size = New System.Drawing.Size(72, 21)
        Me.txtNumFans1.TabIndex = 9
        Me.txtNumFans1.Text = "1"
        '
        'lblAltitude1
        '
        Me.lblAltitude1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAltitude1.Location = New System.Drawing.Point(0, 196)
        Me.lblAltitude1.Name = "lblAltitude1"
        Me.lblAltitude1.Size = New System.Drawing.Size(80, 23)
        Me.lblAltitude1.TabIndex = 32
        Me.lblAltitude1.Text = "Altitude"
        Me.lblAltitude1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFan
        '
        Me.lblFan.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFan.Location = New System.Drawing.Point(0, 224)
        Me.lblFan.Name = "lblFan"
        Me.lblFan.Size = New System.Drawing.Size(80, 23)
        Me.lblFan.TabIndex = 43
        Me.lblFan.Text = "Fan"
        Me.lblFan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboSubCooling2
        '
        Me.cboSubCooling2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSubCooling2.Items.AddRange(New Object() {"Yes", "No"})
        Me.cboSubCooling2.Location = New System.Drawing.Point(344, 112)
        Me.cboSubCooling2.Name = "cboSubCooling2"
        Me.cboSubCooling2.Size = New System.Drawing.Size(72, 21)
        Me.cboSubCooling2.TabIndex = 14
        Me.cboSubCooling2.Text = "Yes"
        '
        'lblNumFans1
        '
        Me.lblNumFans1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumFans1.Location = New System.Drawing.Point(0, 252)
        Me.lblNumFans1.Name = "lblNumFans1"
        Me.lblNumFans1.Size = New System.Drawing.Size(80, 23)
        Me.lblNumFans1.TabIndex = 41
        Me.lblNumFans1.Text = "Fan quantity"
        Me.lblNumFans1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCoilFileName1
        '
        Me.cboCoilFileName1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCoilFileName1.Location = New System.Drawing.Point(88, 56)
        Me.cboCoilFileName1.Name = "cboCoilFileName1"
        Me.cboCoilFileName1.Size = New System.Drawing.Size(144, 21)
        Me.cboCoilFileName1.TabIndex = 2
        Me.cboCoilFileName1.Text = "1/2"" Diameter 2 Row"
        '
        'txtAltitude2
        '
        Me.txtAltitude2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAltitude2.Location = New System.Drawing.Point(344, 196)
        Me.txtAltitude2.Name = "txtAltitude2"
        Me.txtAltitude2.ReadOnly = True
        Me.txtAltitude2.Size = New System.Drawing.Size(72, 21)
        Me.txtAltitude2.TabIndex = 30
        Me.txtAltitude2.TabStop = False
        Me.txtAltitude2.Text = "0"
        '
        'txtSubCoolingPercent2
        '
        Me.txtSubCoolingPercent2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubCoolingPercent2.Location = New System.Drawing.Point(416, 112)
        Me.txtSubCoolingPercent2.Name = "txtSubCoolingPercent2"
        Me.txtSubCoolingPercent2.ReadOnly = True
        Me.txtSubCoolingPercent2.Size = New System.Drawing.Size(72, 21)
        Me.txtSubCoolingPercent2.TabIndex = 18
        Me.txtSubCoolingPercent2.TabStop = False
        '
        'cboFpi2
        '
        Me.cboFpi2.BackColor = System.Drawing.Color.White
        Me.cboFpi2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFpi2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFpi2.Location = New System.Drawing.Point(344, 84)
        Me.cboFpi2.Name = "cboFpi2"
        Me.cboFpi2.Size = New System.Drawing.Size(72, 21)
        Me.cboFpi2.TabIndex = 13
        '
        'txtAltitude1
        '
        Me.txtAltitude1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAltitude1.Location = New System.Drawing.Point(88, 196)
        Me.txtAltitude1.Name = "txtAltitude1"
        Me.txtAltitude1.Size = New System.Drawing.Size(72, 21)
        Me.txtAltitude1.TabIndex = 7
        Me.txtAltitude1.Text = "0"
        '
        'txtFinHeight2
        '
        Me.txtFinHeight2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFinHeight2.Location = New System.Drawing.Point(344, 140)
        Me.txtFinHeight2.Name = "txtFinHeight2"
        Me.txtFinHeight2.Size = New System.Drawing.Size(72, 21)
        Me.txtFinHeight2.TabIndex = 15
        '
        'txtNumFans2
        '
        Me.txtNumFans2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumFans2.Location = New System.Drawing.Point(344, 252)
        Me.txtNumFans2.Name = "txtNumFans2"
        Me.txtNumFans2.Size = New System.Drawing.Size(72, 21)
        Me.txtNumFans2.TabIndex = 17
        Me.txtNumFans2.Text = "1"
        '
        'cboCoilFileName2
        '
        Me.cboCoilFileName2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCoilFileName2.Location = New System.Drawing.Point(344, 56)
        Me.cboCoilFileName2.Name = "cboCoilFileName2"
        Me.cboCoilFileName2.Size = New System.Drawing.Size(144, 21)
        Me.cboCoilFileName2.TabIndex = 12
        Me.cboCoilFileName2.Text = "1/2"" Diameter 2 Row"
        '
        'lblFinHeight1
        '
        Me.lblFinHeight1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinHeight1.Location = New System.Drawing.Point(0, 140)
        Me.lblFinHeight1.Name = "lblFinHeight1"
        Me.lblFinHeight1.Size = New System.Drawing.Size(80, 23)
        Me.lblFinHeight1.TabIndex = 24
        Me.lblFinHeight1.Text = "Fin height"
        Me.lblFinHeight1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFinHeight1
        '
        Me.txtFinHeight1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFinHeight1.Location = New System.Drawing.Point(88, 140)
        Me.txtFinHeight1.Name = "txtFinHeight1"
        Me.txtFinHeight1.Size = New System.Drawing.Size(72, 21)
        Me.txtFinHeight1.TabIndex = 5
        '
        'lblFinsPerInch1
        '
        Me.lblFinsPerInch1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinsPerInch1.Location = New System.Drawing.Point(0, 84)
        Me.lblFinsPerInch1.Name = "lblFinsPerInch1"
        Me.lblFinsPerInch1.Size = New System.Drawing.Size(80, 23)
        Me.lblFinsPerInch1.TabIndex = 14
        Me.lblFinsPerInch1.Text = "Fins per inch"
        Me.lblFinsPerInch1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSubCooling1
        '
        Me.lblSubCooling1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubCooling1.Location = New System.Drawing.Point(0, 112)
        Me.lblSubCooling1.Name = "lblSubCooling1"
        Me.lblSubCooling1.Size = New System.Drawing.Size(80, 23)
        Me.lblSubCooling1.TabIndex = 19
        Me.lblSubCooling1.Text = "Sub cooling"
        Me.lblSubCooling1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSubCoolingPercent1
        '
        Me.txtSubCoolingPercent1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubCoolingPercent1.Location = New System.Drawing.Point(160, 112)
        Me.txtSubCoolingPercent1.Name = "txtSubCoolingPercent1"
        Me.txtSubCoolingPercent1.ReadOnly = True
        Me.txtSubCoolingPercent1.Size = New System.Drawing.Size(72, 21)
        Me.txtSubCoolingPercent1.TabIndex = 17
        Me.txtSubCoolingPercent1.TabStop = False
        '
        'cboFpi1
        '
        Me.cboFpi1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFpi1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFpi1.Location = New System.Drawing.Point(88, 84)
        Me.cboFpi1.Name = "cboFpi1"
        Me.cboFpi1.Size = New System.Drawing.Size(72, 21)
        Me.cboFpi1.TabIndex = 3
        '
        'lblFinLength1
        '
        Me.lblFinLength1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinLength1.Location = New System.Drawing.Point(16, 168)
        Me.lblFinLength1.Name = "lblFinLength1"
        Me.lblFinLength1.Size = New System.Drawing.Size(64, 23)
        Me.lblFinLength1.TabIndex = 28
        Me.lblFinLength1.Text = "Fin length"
        Me.lblFinLength1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFinLength2
        '
        Me.lblFinLength2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinLength2.Location = New System.Drawing.Point(248, 168)
        Me.lblFinLength2.Name = "lblFinLength2"
        Me.lblFinLength2.Size = New System.Drawing.Size(88, 23)
        Me.lblFinLength2.TabIndex = 27
        Me.lblFinLength2.Text = "Fin length"
        Me.lblFinLength2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSubCooling2
        '
        Me.lblSubCooling2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubCooling2.Location = New System.Drawing.Point(248, 112)
        Me.lblSubCooling2.Name = "lblSubCooling2"
        Me.lblSubCooling2.Size = New System.Drawing.Size(88, 23)
        Me.lblSubCooling2.TabIndex = 20
        Me.lblSubCooling2.Text = "Sub cooling"
        Me.lblSubCooling2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNumCoils1
        '
        Me.txtNumCoils1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumCoils1.Location = New System.Drawing.Point(88, 28)
        Me.txtNumCoils1.Name = "txtNumCoils1"
        Me.txtNumCoils1.Size = New System.Drawing.Size(72, 21)
        Me.txtNumCoils1.TabIndex = 1
        Me.txtNumCoils1.Text = "1"
        '
        'lblNumFans2
        '
        Me.lblNumFans2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumFans2.Location = New System.Drawing.Point(248, 252)
        Me.lblNumFans2.Name = "lblNumFans2"
        Me.lblNumFans2.Size = New System.Drawing.Size(88, 23)
        Me.lblNumFans2.TabIndex = 38
        Me.lblNumFans2.Text = "Fan quantity"
        Me.lblNumFans2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCondenser2
        '
        Me.lblCondenser2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCondenser2.Location = New System.Drawing.Point(248, 56)
        Me.lblCondenser2.Name = "lblCondenser2"
        Me.lblCondenser2.Size = New System.Drawing.Size(88, 23)
        Me.lblCondenser2.TabIndex = 10
        Me.lblCondenser2.Text = "Condenser"
        Me.lblCondenser2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNumCoils1
        '
        Me.lblNumCoils1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumCoils1.Location = New System.Drawing.Point(0, 28)
        Me.lblNumCoils1.Name = "lblNumCoils1"
        Me.lblNumCoils1.Size = New System.Drawing.Size(80, 23)
        Me.lblNumCoils1.TabIndex = 6
        Me.lblNumCoils1.Text = "Coil quantity"
        Me.lblNumCoils1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCircuit2
        '
        Me.lblCircuit2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCircuit2.Location = New System.Drawing.Point(344, 4)
        Me.lblCircuit2.Name = "lblCircuit2"
        Me.lblCircuit2.Size = New System.Drawing.Size(157, 23)
        Me.lblCircuit2.TabIndex = 2
        Me.lblCircuit2.Text = "Circuit 2"
        Me.lblCircuit2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNumCoils2
        '
        Me.txtNumCoils2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumCoils2.Location = New System.Drawing.Point(344, 28)
        Me.txtNumCoils2.Name = "txtNumCoils2"
        Me.txtNumCoils2.Size = New System.Drawing.Size(72, 21)
        Me.txtNumCoils2.TabIndex = 11
        Me.txtNumCoils2.Text = "1"
        '
        'lblFinsPerInch2
        '
        Me.lblFinsPerInch2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinsPerInch2.Location = New System.Drawing.Point(248, 84)
        Me.lblFinsPerInch2.Name = "lblFinsPerInch2"
        Me.lblFinsPerInch2.Size = New System.Drawing.Size(88, 23)
        Me.lblFinsPerInch2.TabIndex = 13
        Me.lblFinsPerInch2.Text = "Fins per inch"
        Me.lblFinsPerInch2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFan
        '
        Me.cboFan.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFan.Location = New System.Drawing.Point(88, 224)
        Me.cboFan.MaxDropDownItems = 11
        Me.cboFan.Name = "cboFan"
        Me.cboFan.Size = New System.Drawing.Size(248, 21)
        Me.cboFan.TabIndex = 8
        '
        'lblNumCoils2
        '
        Me.lblNumCoils2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumCoils2.Location = New System.Drawing.Point(248, 28)
        Me.lblNumCoils2.Name = "lblNumCoils2"
        Me.lblNumCoils2.Size = New System.Drawing.Size(88, 23)
        Me.lblNumCoils2.TabIndex = 5
        Me.lblNumCoils2.Text = "Coil quantity"
        Me.lblNumCoils2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboSubCooling1
        '
        Me.cboSubCooling1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSubCooling1.Items.AddRange(New Object() {"Yes", "No"})
        Me.cboSubCooling1.Location = New System.Drawing.Point(88, 112)
        Me.cboSubCooling1.Name = "cboSubCooling1"
        Me.cboSubCooling1.Size = New System.Drawing.Size(72, 21)
        Me.cboSubCooling1.TabIndex = 4
        Me.cboSubCooling1.Text = "Yes"
        '
        'lblCondenser1
        '
        Me.lblCondenser1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCondenser1.Location = New System.Drawing.Point(0, 56)
        Me.lblCondenser1.Name = "lblCondenser1"
        Me.lblCondenser1.Size = New System.Drawing.Size(80, 23)
        Me.lblCondenser1.TabIndex = 9
        Me.lblCondenser1.Text = "Condenser"
        Me.lblCondenser1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCircuit1
        '
        Me.lblCircuit1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCircuit1.Location = New System.Drawing.Point(88, 4)
        Me.lblCircuit1.Name = "lblCircuit1"
        Me.lblCircuit1.Size = New System.Drawing.Size(152, 23)
        Me.lblCircuit1.TabIndex = 1
        Me.lblCircuit1.Text = "Circuit 1"
        Me.lblCircuit1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFinLength1
        '
        Me.txtFinLength1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFinLength1.Location = New System.Drawing.Point(88, 168)
        Me.txtFinLength1.Name = "txtFinLength1"
        Me.txtFinLength1.Size = New System.Drawing.Size(72, 21)
        Me.txtFinLength1.TabIndex = 6
        '
        'lblFanWatts1
        '
        Me.lblFanWatts1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFanWatts1.Location = New System.Drawing.Point(0, 280)
        Me.lblFanWatts1.Name = "lblFanWatts1"
        Me.lblFanWatts1.Size = New System.Drawing.Size(80, 23)
        Me.lblFanWatts1.TabIndex = 40
        Me.lblFanWatts1.Text = "Fan watts"
        Me.lblFanWatts1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFanWatts2
        '
        Me.txtFanWatts2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFanWatts2.Location = New System.Drawing.Point(344, 280)
        Me.txtFanWatts2.Name = "txtFanWatts2"
        Me.txtFanWatts2.ReadOnly = True
        Me.txtFanWatts2.Size = New System.Drawing.Size(72, 21)
        Me.txtFanWatts2.TabIndex = 37
        Me.txtFanWatts2.TabStop = False
        '
        'txtFanWatts1
        '
        Me.txtFanWatts1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFanWatts1.Location = New System.Drawing.Point(88, 280)
        Me.txtFanWatts1.Name = "txtFanWatts1"
        Me.txtFanWatts1.Size = New System.Drawing.Size(72, 21)
        Me.txtFanWatts1.TabIndex = 10
        '
        'lblAltitude2
        '
        Me.lblAltitude2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAltitude2.Location = New System.Drawing.Point(248, 196)
        Me.lblAltitude2.Name = "lblAltitude2"
        Me.lblAltitude2.Size = New System.Drawing.Size(88, 23)
        Me.lblAltitude2.TabIndex = 31
        Me.lblAltitude2.Text = "Altitude"
        Me.lblAltitude2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFinHeight2
        '
        Me.lblFinHeight2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinHeight2.Location = New System.Drawing.Point(248, 140)
        Me.lblFinHeight2.Name = "lblFinHeight2"
        Me.lblFinHeight2.Size = New System.Drawing.Size(88, 23)
        Me.lblFinHeight2.TabIndex = 23
        Me.lblFinHeight2.Text = "Fin height"
        Me.lblFinHeight2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFanWatts2
        '
        Me.lblFanWatts2.Location = New System.Drawing.Point(264, 280)
        Me.lblFanWatts2.Name = "lblFanWatts2"
        Me.lblFanWatts2.Size = New System.Drawing.Size(72, 16)
        Me.lblFanWatts2.TabIndex = 39
        Me.lblFanWatts2.Text = "Fan watts"
        Me.lblFanWatts2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pan_compressor
        '
        Me.pan_compressor.Controls.Add(Me.Label1)
        Me.pan_compressor.Controls.Add(Me.panCompressorControls)
        Me.pan_compressor.Dock = System.Windows.Forms.DockStyle.Top
        Me.pan_compressor.Location = New System.Drawing.Point(0, 264)
        Me.pan_compressor.Name = "pan_compressor"
        Me.pan_compressor.Size = New System.Drawing.Size(662, 200)
        Me.pan_compressor.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(533, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Label1"
        '
        'panCompressorControls
        '
        Me.panCompressorControls.Controls.Add(Me.gboCompressor1)
        Me.panCompressorControls.Controls.Add(Me.gboCompressor2)
        Me.panCompressorControls.Controls.Add(Me.panCompressorCircuits)
        Me.panCompressorControls.Location = New System.Drawing.Point(8, 0)
        Me.panCompressorControls.Name = "panCompressorControls"
        Me.panCompressorControls.Size = New System.Drawing.Size(504, 188)
        Me.panCompressorControls.TabIndex = 25
        '
        'gboCompressor1
        '
        Me.gboCompressor1.Controls.Add(Me.txtNumCompressors1)
        Me.gboCompressor1.Controls.Add(Me.lblCompressor1)
        Me.gboCompressor1.Controls.Add(Me.lblNumCompressors1)
        Me.gboCompressor1.Controls.Add(Me.txtCompressor1)
        Me.gboCompressor1.Controls.Add(Me.lboCompressors1)
        Me.gboCompressor1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.gboCompressor1.Location = New System.Drawing.Point(24, 24)
        Me.gboCompressor1.Name = "gboCompressor1"
        Me.gboCompressor1.Size = New System.Drawing.Size(212, 156)
        Me.gboCompressor1.TabIndex = 2
        Me.gboCompressor1.TabStop = False
        '
        'txtNumCompressors1
        '
        Me.txtNumCompressors1.Enabled = False
        Me.txtNumCompressors1.Location = New System.Drawing.Point(96, 44)
        Me.txtNumCompressors1.Name = "txtNumCompressors1"
        Me.txtNumCompressors1.Size = New System.Drawing.Size(72, 21)
        Me.txtNumCompressors1.TabIndex = 20
        Me.txtNumCompressors1.Text = "1"
        '
        'lblCompressor1
        '
        Me.lblCompressor1.Location = New System.Drawing.Point(16, 16)
        Me.lblCompressor1.Name = "lblCompressor1"
        Me.lblCompressor1.Size = New System.Drawing.Size(72, 23)
        Me.lblCompressor1.TabIndex = 4
        Me.lblCompressor1.Text = "Compressor"
        Me.lblCompressor1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNumCompressors1
        '
        Me.lblNumCompressors1.Location = New System.Drawing.Point(16, 44)
        Me.lblNumCompressors1.Name = "lblNumCompressors1"
        Me.lblNumCompressors1.Size = New System.Drawing.Size(72, 23)
        Me.lblNumCompressors1.TabIndex = 11
        Me.lblNumCompressors1.Text = "Quantity"
        Me.lblNumCompressors1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCompressor1
        '
        Me.txtCompressor1.Location = New System.Drawing.Point(96, 16)
        Me.txtCompressor1.Name = "txtCompressor1"
        Me.txtCompressor1.ReadOnly = True
        Me.txtCompressor1.Size = New System.Drawing.Size(104, 21)
        Me.txtCompressor1.TabIndex = 5
        Me.txtCompressor1.TabStop = False
        '
        'lboCompressors1
        '
        Me.lboCompressors1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lboCompressors1.ItemHeight = 14
        Me.lboCompressors1.Location = New System.Drawing.Point(12, 72)
        Me.lboCompressors1.Name = "lboCompressors1"
        Me.lboCompressors1.Size = New System.Drawing.Size(188, 74)
        Me.lboCompressors1.TabIndex = 21
        '
        'gboCompressor2
        '
        Me.gboCompressor2.Controls.Add(Me.lblCompressor2)
        Me.gboCompressor2.Controls.Add(Me.txtCompressor2)
        Me.gboCompressor2.Controls.Add(Me.txtNumCompressors2)
        Me.gboCompressor2.Controls.Add(Me.lblNumCompressors2)
        Me.gboCompressor2.Controls.Add(Me.lboCompressors2)
        Me.gboCompressor2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.gboCompressor2.Location = New System.Drawing.Point(272, 24)
        Me.gboCompressor2.Name = "gboCompressor2"
        Me.gboCompressor2.Size = New System.Drawing.Size(212, 156)
        Me.gboCompressor2.TabIndex = 3
        Me.gboCompressor2.TabStop = False
        '
        'lblCompressor2
        '
        Me.lblCompressor2.Location = New System.Drawing.Point(8, 16)
        Me.lblCompressor2.Name = "lblCompressor2"
        Me.lblCompressor2.Size = New System.Drawing.Size(72, 23)
        Me.lblCompressor2.TabIndex = 7
        Me.lblCompressor2.Text = "Compressor"
        Me.lblCompressor2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCompressor2
        '
        Me.txtCompressor2.Location = New System.Drawing.Point(88, 16)
        Me.txtCompressor2.Name = "txtCompressor2"
        Me.txtCompressor2.ReadOnly = True
        Me.txtCompressor2.Size = New System.Drawing.Size(112, 21)
        Me.txtCompressor2.TabIndex = 6
        Me.txtCompressor2.TabStop = False
        '
        'txtNumCompressors2
        '
        Me.txtNumCompressors2.Enabled = False
        Me.txtNumCompressors2.Location = New System.Drawing.Point(88, 44)
        Me.txtNumCompressors2.Name = "txtNumCompressors2"
        Me.txtNumCompressors2.Size = New System.Drawing.Size(72, 21)
        Me.txtNumCompressors2.TabIndex = 22
        Me.txtNumCompressors2.Text = "1"
        '
        'lblNumCompressors2
        '
        Me.lblNumCompressors2.Location = New System.Drawing.Point(8, 44)
        Me.lblNumCompressors2.Name = "lblNumCompressors2"
        Me.lblNumCompressors2.Size = New System.Drawing.Size(72, 23)
        Me.lblNumCompressors2.TabIndex = 10
        Me.lblNumCompressors2.Text = "Quantity"
        Me.lblNumCompressors2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lboCompressors2
        '
        Me.lboCompressors2.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lboCompressors2.ItemHeight = 14
        Me.lboCompressors2.Location = New System.Drawing.Point(12, 72)
        Me.lboCompressors2.Name = "lboCompressors2"
        Me.lboCompressors2.Size = New System.Drawing.Size(188, 74)
        Me.lboCompressors2.TabIndex = 23
        '
        'panCompressorCircuits
        '
        Me.panCompressorCircuits.Controls.Add(Me.radCircuit1)
        Me.panCompressorCircuits.Controls.Add(Me.radCircuit2)
        Me.panCompressorCircuits.Location = New System.Drawing.Point(4, 6)
        Me.panCompressorCircuits.Name = "panCompressorCircuits"
        Me.panCompressorCircuits.Size = New System.Drawing.Size(484, 26)
        Me.panCompressorCircuits.TabIndex = 1
        '
        'radCircuit1
        '
        Me.radCircuit1.Checked = True
        Me.radCircuit1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.radCircuit1.Location = New System.Drawing.Point(6, 2)
        Me.radCircuit1.Name = "radCircuit1"
        Me.radCircuit1.Size = New System.Drawing.Size(220, 21)
        Me.radCircuit1.TabIndex = 18
        Me.radCircuit1.TabStop = True
        Me.radCircuit1.Text = "Circuit 1"
        '
        'radCircuit2
        '
        Me.radCircuit2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.radCircuit2.Location = New System.Drawing.Point(252, 2)
        Me.radCircuit2.Name = "radCircuit2"
        Me.radCircuit2.Size = New System.Drawing.Size(222, 21)
        Me.radCircuit2.TabIndex = 19
        Me.radCircuit2.Text = "Circuit 2"
        '
        'btn_create_report
        '
        Me.btn_create_report.BackColor = System.Drawing.Color.White
        Me.btn_create_report.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_create_report.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_create_report.ForeColor = System.Drawing.Color.Navy
        Me.btn_create_report.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Report
        Me.btn_create_report.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_create_report.Location = New System.Drawing.Point(165, 0)
        Me.btn_create_report.Name = "btn_create_report"
        Me.btn_create_report.Size = New System.Drawing.Size(127, 32)
        Me.btn_create_report.TabIndex = 2
        Me.btn_create_report.Text = "Create Report"
        Me.btn_create_report.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_create_report.UseVisualStyleBackColor = False
        '
        'picError
        '
        Me.picError.Dock = System.Windows.Forms.DockStyle.Left
        Me.picError.Image = CType(resources.GetObject("picError.Image"), System.Drawing.Image)
        Me.picError.Location = New System.Drawing.Point(0, 0)
        Me.picError.Name = "picError"
        Me.picError.Size = New System.Drawing.Size(32, 32)
        Me.picError.TabIndex = 14
        Me.picError.TabStop = False
        Me.picError.Visible = False
        '
        'pan_footer
        '
        Me.pan_footer.BackColor = System.Drawing.Color.White
        Me.pan_footer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pan_footer.Controls.Add(Me.lblError)
        Me.pan_footer.Controls.Add(Me.panFooterButton)
        Me.pan_footer.Controls.Add(Me.picError)
        Me.pan_footer.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pan_footer.Location = New System.Drawing.Point(0, 551)
        Me.pan_footer.Name = "pan_footer"
        Me.pan_footer.Size = New System.Drawing.Size(679, 34)
        Me.pan_footer.TabIndex = 9
        '
        'lblError
        '
        Me.lblError.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblError.Location = New System.Drawing.Point(32, 0)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(224, 32)
        Me.lblError.TabIndex = 6
        Me.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'panFooterButton
        '
        Me.panFooterButton.BackColor = System.Drawing.Color.White
        Me.panFooterButton.Controls.Add(Me.btn_go_to_pricing)
        Me.panFooterButton.Controls.Add(Me.btn_calculate_page)
        Me.panFooterButton.Controls.Add(Me.btn_create_report)
        Me.panFooterButton.Dock = System.Windows.Forms.DockStyle.Right
        Me.panFooterButton.Location = New System.Drawing.Point(256, 0)
        Me.panFooterButton.Name = "panFooterButton"
        Me.panFooterButton.Size = New System.Drawing.Size(421, 32)
        Me.panFooterButton.TabIndex = 16
        '
        'btn_go_to_pricing
        '
        Me.btn_go_to_pricing.BackColor = System.Drawing.Color.White
        Me.btn_go_to_pricing.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_go_to_pricing.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_go_to_pricing.ForeColor = System.Drawing.Color.Navy
        Me.btn_go_to_pricing.Image = Global.Rae.RaeSolutions.My.Resources.Resources.GoToArrow
        Me.btn_go_to_pricing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_go_to_pricing.Location = New System.Drawing.Point(296, 0)
        Me.btn_go_to_pricing.Name = "btn_go_to_pricing"
        Me.btn_go_to_pricing.Size = New System.Drawing.Size(124, 32)
        Me.btn_go_to_pricing.TabIndex = 5
        Me.btn_go_to_pricing.Text = "Go To Pricing"
        Me.btn_go_to_pricing.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_go_to_pricing.UseVisualStyleBackColor = False
        '
        'btn_calculate_page
        '
        Me.btn_calculate_page.BackColor = System.Drawing.Color.White
        Me.btn_calculate_page.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_calculate_page.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_calculate_page.ForeColor = System.Drawing.Color.Navy
        Me.btn_calculate_page.Image = CType(resources.GetObject("btn_calculate_page.Image"), System.Drawing.Image)
        Me.btn_calculate_page.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_calculate_page.Location = New System.Drawing.Point(1, 0)
        Me.btn_calculate_page.Name = "btn_calculate_page"
        Me.btn_calculate_page.Size = New System.Drawing.Size(160, 32)
        Me.btn_calculate_page.TabIndex = 1
        Me.btn_calculate_page.Text = "Run Balance"
        Me.btn_calculate_page.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_calculate_page.UseVisualStyleBackColor = False
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
        Me.SaveToolStripPanel1.Size = New System.Drawing.Size(679, 0)
        '
        'lbl_select_model
        '
        Me.lbl_select_model.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbl_select_model.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_select_model.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lbl_select_model.Location = New System.Drawing.Point(0, 0)
        Me.lbl_select_model.Name = "lbl_select_model"
        Me.lbl_select_model.Padding = New System.Windows.Forms.Padding(6)
        Me.lbl_select_model.Size = New System.Drawing.Size(679, 32)
        Me.lbl_select_model.TabIndex = 14
        Me.lbl_select_model.Text = "Select a model to get started"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(17, 35)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(259, 255)
        Me.DataGridView1.TabIndex = 92
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(292, 35)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(324, 255)
        Me.DataGridView2.TabIndex = 93
        '
        'RepAirCooledChillerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(679, 585)
        Me.Controls.Add(Me.pan_main)
        Me.Controls.Add(Me.lbl_select_model)
        Me.Controls.Add(Me.pan_footer)
        Me.Controls.Add(Me.SaveToolStripPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "RepAirCooledChillerForm"
        Me.Text = "Chiller Rating - Air Cooled"
        CType(Me.results, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pan_model.ResumeLayout(False)
        Me.pan_model.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.pan_rating_criteria.ResumeLayout(False)
        Me.pan_rating_criteria.PerformLayout()
        Me.hid_panCriteria.ResumeLayout(False)
        Me.hid_panCriteria.PerformLayout()
        Me.panCriteriaControls.ResumeLayout(False)
        Me.panCriteriaControls.PerformLayout()
        Me.pan_main.ResumeLayout(False)
        Me.panGrid.ResumeLayout(False)
        Me.hid_panResults.ResumeLayout(False)
        Me.hid_panResults.PerformLayout()
        Me.pan_evaporator.ResumeLayout(False)
        Me.panEvaporatorControls.ResumeLayout(False)
        Me.panEvaporatorControls.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.hid_panEvaporator.ResumeLayout(False)
        Me.hid_panEvaporator.PerformLayout()
        Me.hid_panApproach.ResumeLayout(False)
        Me.pan_condenser.ResumeLayout(False)
        Me.hid_panCondenser.ResumeLayout(False)
        Me.hid_panCondenser.PerformLayout()
        Me.panCondenserControls.ResumeLayout(False)
        Me.panCondenserControls.PerformLayout()
        Me.pan_compressor.ResumeLayout(False)
        Me.pan_compressor.PerformLayout()
        Me.panCompressorControls.ResumeLayout(False)
        Me.gboCompressor1.ResumeLayout(False)
        Me.gboCompressor1.PerformLayout()
        Me.gboCompressor2.ResumeLayout(False)
        Me.gboCompressor2.PerformLayout()
        Me.panCompressorCircuits.ResumeLayout(False)
        CType(Me.picError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pan_footer.ResumeLayout(False)
        Me.panFooterButton.ResumeLayout(False)
        CType(Me.err, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


#Region " Properties"

    ''' <summary>Ambient temperature bound to the associated text box.</summary>
    Private Property AmbientTemp() As Double
      Get
         Return ConvertNull.ToDouble(Me.txtAmbientTemp.Text)
      End Get
      Set(ByVal Value As Double)
         Me.txtAmbientTemp.Text = Value.ToString
      End Set
   End Property

   ''' <summary>Leaving fluid temperature bound to the associated text box.</summary>
   Private Property LeavingFluidTemp() As Double
      Get
         Return ConvertNull.ToDouble(Me.txtLeavingFluidTemp.Text)
      End Get
      Set(ByVal Value As Double)
         Me.txtLeavingFluidTemp.Text = Value.ToString
      End Set
   End Property

#End Region


#Region " Variables"

   Dim LastStateProcess As ACChillerProcessItem
   'Dim CurrentStateProcess As ACChillerProcessItem

   Dim loaded As Boolean = False 'indicates whether the form's load function has ran
   Dim usageLogger As Diagnostics.UsageLog.FormUsageLogger


   Dim PASS_FILENAME1 As String 'was Session variable
   Dim PASS_FILENAME As String 'was Session variable


   Dim ok_to_print_SPACE As Boolean
   Dim Page_Cal_Pass As Single
   Dim gArrGlycolEthylene(12, 4) As Double
   Dim gArrGlycolPropylene(12, 4) As Double
   Dim COMPR_KW(2, 18) As Double
   Dim holding_suction_temp As Double     'PASSING VALUE
   Dim holding_condenser_temp As Double    'PASSING VALUE
   Dim holding_tw_temp As Double     'PASSING VALUE
   Dim holding_te_temp As Double    'PASSING VALUE
   Dim TURN_ON_OMIT_NOTE As Double         'PASSING VALUE
   Dim ok_to_show As Boolean                'PASSING VALUE
   Dim Hold_Set_PD(20) As Double
   Dim Running_Circuit_no As Integer
   Dim gArrHidCircuit1Display As New ArrayList       'circuit 1 holding
   Dim gArrHidDisplay As New ArrayList       'circuit 1
   Dim gArrHidCircuit2Display As New ArrayList      'circuit 2
   Dim MyFileNameMDB As String
   Dim ChillyRAEs_pass_no As Single
   Dim ok_to_print As Boolean
   Dim SG1 As String                'SPECIFIC GRAVITY(GLYCOL)
   Dim SH1 As String                'SPECIFIC HEAT(GLYCOL)
   Dim r As String               'Refrigerant type

   Dim A As Double
   Dim B As Double
   Dim EE As Double
   Dim F As Double
   Dim g As Double
   Dim M As Double                  '25/CC
   Dim P As Double
   Dim Q As Double
   Dim T As Double
   Dim W As Double
   Dim Z As Double

   Dim EZ As Double
   Dim ER As Double
   Dim GP As Double
   Dim H1 As Double
   Dim H2 As Double
   Dim KW As Double
   Dim M1 As Double
   Dim NC As Double                 'NUMBER OF COMPRESSOR CIRCUITS
   Dim NF As Double                 'NUMBER OF FANS
   Dim PC As Double
   Dim PD As Double
   Dim PE As Double
   Dim Q1 As Double
   Dim Q8 As Double                 'CHILLER CAP. @ 8 DEG APPROACH
   Dim Q9 As Double                 'CHILLER CAP. @ 10 DEG APPROACH
   Dim SG As Double                 'SPECIFIC GRAVITY(GLYCOL)
   Dim TA As Double
   Dim TC As Double
   Dim TE As Double
   Dim TW As Double
   Dim GPM As Double
   Dim SCF As Double                'GLYCOL
   Dim TA1 As Double
   Dim TE1 As Double
   Dim TE2 As Double
   Dim TW1 As Double
   Dim TW2 As Double
   Dim CR_S As Double               'PRINT OUT CATALOG RATINGS?Y/N
   Dim GPMFACT As Double            'GLYCOL
   Dim fanWatts As Double

   Dim TE_2 As Double
   Dim TC_2 As Double
   Dim Q_2 As Double
   Dim KW_2 As Double
   Dim GP_2 As Double
   Dim ER_2 As Double
   Dim NF_2 As Double
   Dim W_2 As Double
   Dim PD_GPM(13, 2) As Double

#End Region

   Sub Open(process_item As ProcessItem)
      Me.LoadControls(process_item)
   End Sub
   
   Sub LoadControls(process_item As ACChillerProcessItem)

      ' if latest revision has not been set then
      ' we need to set it now  based on the ID...
      If Me.m_LatestRevision = -1 Then
         Me.m_LatestRevision = Rae.RaeSolutions.DataAccess.Projects.ProcessItemDA.LastestRevision(Me.Tag)
      End If

      ' increment the current process revision displayed on this form...
      Me.m_CurrentRevision = process_item.Revision

      ' clone last saved process to passing process item
      LastSavedProcess = process_item.Clone()

      cbo_series.Text = LastSavedProcess.Series
      
      model_changed_schedule.Disable()
         cbo_models.Text = LastSavedProcess.Model
         txt_model.Text = LastSavedProcess.ModelDesc
      model_changed_schedule.Enable()
      
      If Me.LastSavedProcess.Fluid IsNot Nothing Then
         cboFluid.Text = LastSavedProcess.Fluid
      End If
      txtPercentGlycol.Text = LastSavedProcess.GlycolPercentage
      If LastSavedProcess.CoolingMedia IsNot Nothing Then
         Me.cbo_glycol.Text = LastSavedProcess.CoolingMedia
      End If
      txtSpecificHeat.Text = LastSavedProcess.SpecificHeat
      If Me.LastSavedProcess.SpecificGravity > 0 Then
         txtSpecificGravity.Text = LastSavedProcess.SpecificGravity
      End If
      '''''txtSubCooling.Text = LastSavedProcess.SubCooling
      If Me.LastSavedProcess.Refrigerant IsNot Nothing Then
         cboRefrigerant.Text = LastSavedProcess.Refrigerant
      End If
      ' don't override temperature range
      If LastSavedProcess.TempRange > 0 Then
         cboTempRange.Text = LastSavedProcess.TempRange
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
         hid_txtApproach.Text = LastSavedProcess.Approach
      End If
      If Me.LastSavedProcess.Volts <> 0 Then
         cboVolts.Text = LastSavedProcess.Volts
      End If
      '''''cboSafetyOverride.Checked = LastSavedProcess.SafetyOverride
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
            If lboCompressors2.Text.ToString Like Trim(LastSavedProcess.Compressors2) & "*" Then
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
      Try
         lboCompressors1.SetSelected(lboCompressors1.Items.IndexOf(LastSavedProcess.Compressors1), True)
      Catch ex As Exception
      End Try
      Try
         lboCompressors2.SetSelected(lboCompressors2.Items.IndexOf(LastSavedProcess.Compressors2), True)
      Catch ex As Exception
      End Try

      ' sets number of coils to a default of 1 if number of coils is zero
      If Me.LastSavedProcess.NumCoils1 = 0 Then
         Me.txtNumCoils1.Text = "1"
      Else
         txtNumCoils1.Text = LastSavedProcess.NumCoils1
      End If
      If Me.LastSavedProcess.NumCoils2 = 0 Then
         Me.txtNumCoils2.Text = "1"
      Else
         txtNumCoils2.Text = LastSavedProcess.NumCoils2
      End If
      If Me.LastSavedProcess.Condenser1 IsNot Nothing Then
         Me.cboCoilFileName1.Text = LastSavedProcess.Condenser1
      Else
         Me.cboCoilFileName1.SelectedIndex = 0
      End If
      If Me.LastSavedProcess.Condenser2 IsNot Nothing Then
         cboCoilFileName2.Text = LastSavedProcess.Condenser2
      End If
      Me.cboFpi1.Text = LastSavedProcess.FinsPerInch1
      Me.cboFpi2.Text = LastSavedProcess.FinsPerInch2

      If LastSavedProcess.SubCooling1 = True Then
         Me.cboSubCooling1.Text = "Yes"
      Else
         Me.cboSubCooling1.Text = "No"
      End If
      Me.txtSubCoolingPercent1.Text = LastSavedProcess.SubCoolingPercent1

      If LastSavedProcess.SubCooling2 = True Then
         Me.cboSubCooling2.Text = "Yes"
      Else
         Me.cboSubCooling2.Text = "No"
      End If
      Me.txtSubCoolingPercent2.Text = LastSavedProcess.SubCoolingPercent2

      '''''Me.txtCondenserTD1.Text = LastSavedProcess.CondenserTD1
      '''''Me.txtCondenserTD2.Text = LastSavedProcess.CondenserTD2
      Me.txtFinHeight1.Text = LastSavedProcess.FinHeight1
      Me.txtFinHeight2.Text = LastSavedProcess.FinHeight2
      Me.txtFinLength1.Text = LastSavedProcess.FinLength1
      Me.txtFinLength2.Text = LastSavedProcess.FinLength2


      cbo_Discharge_line_loss.Text = LastSavedProcess.DischargeLineLoss
      cbo_Suction_line_loss.Text = LastSavedProcess.SuctionLineLoss
      txtAltitude1.Text = LastSavedProcess.Altitude
      txtAltitude2.Text = LastSavedProcess.Altitude
      If LastSavedProcess.Fan IsNot Nothing Then
         Me.cboFan.Text = LastSavedProcess.Fan
      End If
      Me.txtCfmOverRide.Text = LastSavedProcess.CfmOverride
      Me.txtNumFans1.Text = LastSavedProcess.NumFans1
      Me.txtNumFans2.Text = LastSavedProcess.NumFans2
      txtFanWatts1.Text = LastSavedProcess.FanWatts
      txtFanWatts2.Text = LastSavedProcess.FanWatts
      If Not (Me.LastSavedProcess.CondenserCapacity1) Then
         Me.TxtCondCap_1.Text = LastSavedProcess.CondenserCapacity1
      End If
      If Not Me.LastSavedProcess.CondenserCapacity2 = 0 Then
         Me.TxtCondCap_2.Text = LastSavedProcess.CondenserCapacity2
      End If
      If Me.LastSavedProcess.EvaporatorModel IsNot Nothing Then
         cbo_evaporators.Text = LastSavedProcess.EvaporatorModel
      End If
      If Me.LastSavedProcess.EvaporatorModelDesc IsNot Nothing Then
         txt_evaporator.Text = LastSavedProcess.EvaporatorModelDesc
      End If
      'cboNumevap.Text = LastSavedProcess.NumEvap
      If Me.LastSavedProcess.FoulingFactor > 0 Then
         cboFoulingFactor.Text = LastSavedProcess.FoulingFactor
      End If
      If LastSavedProcess.CapacityType = ACChillerProcessItem.eCapacityType.Tons Then
         radCapacityTons.Checked = True
      ElseIf LastSavedProcess.CapacityType = ACChillerProcessItem.eCapacityType.GPM Then
         radCapacityGpm.Checked = True
      Else
         radCapacityGpm.Checked = False
         radCapacityTons.Checked = False
      End If
      If Me.LastSavedProcess.EvaporatorCapacity > 0 Then
         Me.txtCapacity.Text = Me.LastSavedProcess.EvaporatorCapacity.ToString
      End If
      Me.chkCatalog.Checked = LastSavedProcess.CatalogRating
      ' Approach range...
      If LastSavedProcess.ApproachRange = ACChillerProcessItem.eApproachRange.SixToEight Then
         rb6_8.Checked = True
      ElseIf LastSavedProcess.ApproachRange = ACChillerProcessItem.eApproachRange.SevenToNine Then
         rb7_9.Checked = True
      ElseIf LastSavedProcess.ApproachRange = ACChillerProcessItem.eApproachRange.EightToTen Then
         rb8_10.Checked = True
      ElseIf LastSavedProcess.ApproachRange = ACChillerProcessItem.eApproachRange.NineToEleven Then
         rb9_11.Checked = True
      ElseIf LastSavedProcess.ApproachRange = ACChillerProcessItem.eApproachRange.TenToTwelve Then
         rb10_12.Checked = True
      ElseIf LastSavedProcess.ApproachRange = ACChillerProcessItem.eApproachRange.Other Then
         rbOther_Approch.Checked = True
      End If
      Txt8Deg_1.Text = LastSavedProcess.Evap8Degr1
      Txt8Deg_2.Text = LastSavedProcess.Evap8Degr2
      Txt10Deg_1.Text = LastSavedProcess.Evap10Degr1
      Txt10Deg_2.Text = LastSavedProcess.Evap10Degr2

   End Sub

   Function SaveControls( _
      Optional SaveAsRevision As Boolean = False, _
      Optional SaveAsNew As Boolean = False, _
      Optional FormClosing As Boolean = False, _
      Optional GenerateEquipment As Boolean = False, _
      Optional RevChanged As Boolean = False _
   ) As Boolean

      If CurrentStateProcess Is Nothing Then
         If LastSavedProcess Is Nothing Then
            CurrentStateProcess = New ACChillerProcessItem(New item_id(AppInfo.User.username, AppInfo.User.password))
         Else
            CurrentStateProcess = LastSavedProcess.Clone
         End If
      Else
         If LastSavedProcess IsNot Nothing Then CurrentStateProcess = LastSavedProcess.Clone
      End If
      
      Dim ambient = CDbl(txtAmbientTemp.Text)
      Dim leavingFluidTemperature = CDbl(txtLeavingFluidTemp.Text)
      If Me.results IsNot Nothing _
      AndAlso Me.results.Rows.Count > 0 Then
         Dim row = getRowAtDesignConditions(results, ambient, leavingFluidTemperature)
         If row IsNot Nothing Then
            Dim rowAtDesignConditions As Integer
            CurrentStateProcess.CapacityAtDesignConditions               = row.Capacity
            if not row.EvaporatorPressureDrop = "*" then _
               CurrentStateProcess.EvaporatorPressureDropAtDesignConditions = row.EvaporatorPressureDrop
            CurrentStateProcess.FlowAtDesignConditions                   = row.FlowRate
         End If
      End If
      
      CurrentStateProcess.Series = cbo_series.Text
      CurrentStateProcess.Model = cbo_models.Text
      CurrentStateProcess.ModelDesc = txt_model.Text
      CurrentStateProcess.Fluid = cboFluid.Text
      CurrentStateProcess.GlycolPercentage = ConvertNull.ToDouble(txtPercentGlycol.Text)
      CurrentStateProcess.CoolingMedia = cbo_glycol.Text
      CurrentStateProcess.SpecificHeat = txtSpecificHeat.Text
      CurrentStateProcess.SpecificGravity = txtSpecificGravity.Text
      '''''CurrentStateProcess.SubCooling = txtSubCooling.Text
      CurrentStateProcess.Refrigerant = cboRefrigerant.Text
      CurrentStateProcess.TempRange = cboTempRange.Text
      CurrentStateProcess.AmbientTemp = txtAmbientTemp.Text
      CurrentStateProcess.LeavingFluidTemp = txtLeavingFluidTemp.Text
      CurrentStateProcess.System = cboSystem.Text
      CurrentStateProcess.Hertz = cboHertz.Text
      CurrentStateProcess.Approach = hid_txtApproach.Text
      CurrentStateProcess.Volts = cboVolts.Text
      '''''CurrentStateProcess.SafetyOverride = cboSafetyOverride.Checked
      CurrentStateProcess.Circuit1 = radCircuit1.Checked
      CurrentStateProcess.Circuit2 = radCircuit2.Checked
      CurrentStateProcess.Compressors1 = txtCompressor1.Text
      CurrentStateProcess.Compressors2 = txtCompressor2.Text
      CurrentStateProcess.NumCompressors1 = Val(txtNumCompressors1.Text)
      CurrentStateProcess.NumCompressors2 = Val(txtNumCompressors2.Text)
      CurrentStateProcess.NumCoils1 = Val(txtNumCoils1.Text)
      CurrentStateProcess.NumCoils2 = Val(txtNumCoils2.Text)
      CurrentStateProcess.Condenser1 = cboCoilFileName1.Text
      CurrentStateProcess.Condenser2 = cboCoilFileName2.Text
      CurrentStateProcess.FinsPerInch1 = cboFpi1.Text
      CurrentStateProcess.FinsPerInch2 = cboFpi2.Text
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
      CurrentStateProcess.SubCoolingPercent1 = Val(Me.txtSubCoolingPercent1.Text)
      CurrentStateProcess.SubCoolingPercent2 = Val(Me.txtSubCoolingPercent2.Text)
      '''''CurrentStateProcess.CondenserTD1 = Me.txtCondenserTD1.Text
      '''''CurrentStateProcess.CondenserTD2 = Me.txtCondenserTD2.Text
      CurrentStateProcess.FinHeight1 = Val(Me.txtFinHeight1.Text)
      CurrentStateProcess.FinHeight2 = Val(Me.txtFinHeight2.Text)
      CurrentStateProcess.FinLength1 = Val(Me.txtFinLength1.Text)
      CurrentStateProcess.FinLength2 = Val(Me.txtFinLength2.Text)
      CurrentStateProcess.DischargeLineLoss = cbo_Discharge_line_loss.Text
      CurrentStateProcess.SuctionLineLoss = cbo_Suction_line_loss.Text
      CurrentStateProcess.Altitude = txtAltitude1.Text
      CurrentStateProcess.Fan = Me.cboFan.Text
      CurrentStateProcess.NumFans1 = Val(Me.txtNumFans1.Text)
      CurrentStateProcess.NumFans2 = Val(Me.txtNumFans2.Text)
      CurrentStateProcess.CfmOverride = Val(Me.txtCfmOverRide.Text)
      CurrentStateProcess.FanWatts = Val(txtFanWatts1.Text)
      CurrentStateProcess.CondenserCapacity1 = Val(TxtCondCap_1.Text)
      CurrentStateProcess.CondenserCapacity2 = Val(TxtCondCap_2.Text)
      CurrentStateProcess.EvaporatorModel = cbo_evaporators.Text
      CurrentStateProcess.EvaporatorModelDesc = txt_evaporator.Text
      'CurrentStateProcess.NumEvap = Val(cboNumEvap.Text)
      CurrentStateProcess.FoulingFactor = Val(cboFoulingFactor.Text)
      If radCapacityTons.Checked = True Then
         CurrentStateProcess.CapacityType = ACChillerProcessItem.eCapacityType.Tons
      ElseIf radCapacityGpm.Checked = True Then
         CurrentStateProcess.CapacityType = ACChillerProcessItem.eCapacityType.GPM
      End If

      CurrentStateProcess.EvaporatorCapacity = Val(txtCapacity.Text)
      CurrentStateProcess.CatalogRating = chkCatalog.Checked
      ' Approach range...
      If rb6_8.Checked = True Then
         CurrentStateProcess.ApproachRange = ACChillerProcessItem.eApproachRange.SixToEight
      ElseIf rb7_9.Checked = True Then
         CurrentStateProcess.ApproachRange = ACChillerProcessItem.eApproachRange.SevenToNine
      ElseIf rb8_10.Checked = True Then
         CurrentStateProcess.ApproachRange = ACChillerProcessItem.eApproachRange.EightToTen
      ElseIf rb9_11.Checked = True Then
         CurrentStateProcess.ApproachRange = ACChillerProcessItem.eApproachRange.NineToEleven
      ElseIf rb10_12.Checked = True Then
         CurrentStateProcess.ApproachRange = ACChillerProcessItem.eApproachRange.TenToTwelve
      ElseIf rbOther_Approch.Checked = True Then
         CurrentStateProcess.ApproachRange = ACChillerProcessItem.eApproachRange.Other
      End If

      CurrentStateProcess.Evap8Degr1 = Val(Txt8Deg_1.Text)
      CurrentStateProcess.Evap8Degr2 = Val(Txt8Deg_2.Text)
      CurrentStateProcess.Evap10Degr1 = Val(Txt10Deg_1.Text)
      CurrentStateProcess.Evap10Degr2 = Val(Txt10Deg_2.Text)
      
      CurrentStateProcess.EvaporatorCapacity = 1

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


#Region " Private methods"

   ''' <summary>
   ''' Initializes save tool strip panel. Sets event handlers and tool strip.
   ''' </summary>
   Private Sub initializeSaveToolStripPanel()
      Me.SaveToolStripPanel1.SetUp(CType(Me.ParentForm, MainForm).mainToolStrip, _
         AddressOf saveMenuItem_Click, AddressOf saveAsRevisionMenuItem_Click)
   End Sub


   ''' <summary>
   ''' Handles revision view control's revision changed event.
   ''' If user has unsaved changes, asks user to save before navigating revisions.
   ''' </summary>
   Private Sub RevisionView_RevisionChanged(ByVal sender As RevisionView, ByVal e As ValueChangedEventArgs(Of Single))
      If sender.ActiveProcessForm Is Me Then
         SaveControls(RevChanged:=True)
      End If
   End Sub

#Region " Event handlers"

   private model_changed_schedule, evaporator_changed_schedule as execution_schedule
   private compressor_repository As i_compressor_repository

   private sub form_load() handles mybase.load
      Me.Cursor = Cursors.WaitCursor
      
      compressor_repository = new compressor_repository()
      set_initial_control_visibility(visible:=false)
      
      initializeSaveToolStripPanel()
      ' sets height of form to height of mdiparent's client area
      Me.Height = Ui.FormEditor.MaximizeHeight(Me)
      ' aligns top of child form to the top of the mdiparent's client area
      Me.Location = New Point(Me.Location.X, 0)

      Me.fillComboboxes()

      Me.SetControlsVisibility()

      Me.initializeControls()
      Me.InitializeValidation()

      loaded = True

      calculate_specific_heat_and_gravity()
      
      dim selected_model = grab_model()
      dim model_changed_method as command = addressof handle_model_changed
      model_changed_schedule = execution_schedule.Execute(model_changed_method).on(me).after_last_change_to(selected_model).is_unchanged_for(msec:=500)

      dim evaporator_model = grab_evaporator_model_from_textbox()
      dim evaporator_changed_method as command = addressof handle_evaporator_changed
      evaporator_changed_schedule = execution_schedule.Execute(evaporator_changed_method).on(me).after_last_change_to(evaporator_model).is_unchanged_for(msec:=500)

      Me.Cursor = Cursors.Default

      'add handler to revision view . revision changed event on main form...
      Dim mainForm = AppInfo.Main
      AddHandler mainForm.RevisionView1.RevisionChanged, AddressOf RevisionView_RevisionChanged
   End Sub


   Private Sub form_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) _
      Handles Me.FormClosing
      If Not Me.ProcessDeleted Then
         If SaveControls(FormClosing:=True) = False Then
            e.Cancel = True
         Else
            RemoveHandler CType(My.Application.ApplicationContext.MainForm, MainForm).RevisionView1.RevisionChanged, AddressOf RevisionView_RevisionChanged
         End If
      End If
   End Sub


   Private Sub form_Activated() _
   Handles Me.Activated
      Me.initializeSaveToolStripPanel()
      Me.SaveToolStripPanel1.Merge()
   End Sub


   Private Sub form_Deactivate() _
   Handles Me.Deactivate
      Me.SaveToolStripPanel1.Unmerge()
   End Sub


   private sub cbo_series_SelectedIndexChanged() _
   Handles cbo_series.SelectedIndexChanged
      dim series = cbo_series.SelectedItem.ToString()
      
      cbo_models.dataSource = service.get_models(series)
   end sub


   Private Sub txtLeavingFluidTemp_Leave() _
   Handles txtLeavingFluidTemp.Leave
      Me.leavingFluidTempVCtrl.Validate()
   End Sub

#End Region


#Region " Data"

   ''' <summary>
   ''' DisplayMember: refrigerant name
   ''' ValueMember: short refrigerant name
   ''' </summary>
   Private Sub fillRefrigerants()
      Me.cboRefrigerant.Items.Clear()

      With Me.cboRefrigerant.Items
         .Add(New RefrigerantItem("R134a", "R134a"))
      End With
   End Sub

#End Region


#Region " UI"

   Private Function grab_model() As String
      Return Me.cbo_models.SelectedItem.ToString.Trim
   End Function

   Private Function grab_evaporator_model_from_textbox() As String
      Return Me.txt_evaporator.Text.Trim
   End Function


   Private Function GrabMinSuctionTemperature() As Single
      Return CSng(Me.txtMinSuctionTemp.Text.Trim)
   End Function

   Private Function GrabSpecificHeat() As Double
      Return CDbl(Me.txtSpecificHeat.Text.Trim)
   End Function

   Private Function GrabSpecificGravity() As Double
      Return CDbl(Me.txtSpecificGravity.Text.Trim)
   End Function

   Private Function GrabTemperatureRange() As Double
      Return CDbl(Me.cboTempRange.SelectedItem)
   End Function

   Private Function grab_system() As String
      Return Me.cboSystem.SelectedItem.ToString
   End Function

   Private Function GrabCircuitsPerUnit() As String
      Return Me.Txt_circuit_per_unit.Text
   End Function

   Private Function GrabCircuit1Checked() As Boolean
      Return Me.radCircuit1.Checked
   End Function

   Private Function GrabCircuit2Checked() As Boolean
      Return Me.radCircuit2.Checked
   End Function

   Private Function GrabCondenser1() As Condenser1
      Return DirectCast(Me.cboCoilFileName1.SelectedItem, Condenser1)
   End Function

   Private Function GrabCondenser2() As Condenser1
      Return DirectCast(Me.cboCoilFileName2.SelectedItem, Condenser1)
   End Function

   Private Function GrabCompressor(ByVal circuitNum As Integer) As String
      Dim compressor As String

      compressor = ""

      If circuitNum = 1 Then
         compressor = Me.txtCompressor1.Text.Trim
      ElseIf circuitNum = 2 Then
         compressor = Me.txtCompressor2.Text.Trim
      End If

      Return compressor
   End Function

   Private Function GrabNumCompressors(ByVal circuitNum As Integer) As Integer
      If circuitNum = 1 Then
         Return CInt(Me.txtNumCompressors1.Text.Trim)
      Else
         Return CInt(Me.txtNumCompressors2.Text.Trim)
      End If
   End Function

   Private Function GrabFan() As Business.Entities.Fan
      Return DirectCast(Me.cboFan.SelectedItem, Business.Entities.Fan)
   End Function

   Private Function GrabRefrigerant() As RefrigerantItem
      Return DirectCast(Me.cboRefrigerant.SelectedItem, RefrigerantItem)
   End Function


#End Region


   Private Sub initializeControls()
      cboFluid.SelectedIndex = 0
      cbo_glycol.SelectedIndex = 0

      Me.cboHertz.SelectedIndex = 0
      Me.cbo_series.SelectedIndex = 0
      Me.cboRefrigerant.SelectedIndex = 0
      Me.cboFpi1.SelectedIndex = 0
      Me.cboFpi2.SelectedIndex = 0
   End Sub


   Private chillerVMgr As ValidationManager
   Private leavingFluidTempVCtrl As ValidationControl


   ''' <summary>Initializes validation utilities (managers, controls, and validators).</summary>
   Private Sub InitializeValidation()
      ' VMgr - ValidationManager
      ' VCtrl - ValidationControl
      ' RangeV - RangeValidator, ReqV - RequiredValidator, NumV - NumberValidator

      Dim leavingFluidTempReqV As RequiredValidator
      Dim leavingFluidTempNumV As RegularExpressionValidator
      Dim leavingFluidTempRangeV As AmongRangeValidator
      Dim leavingFluidTempName As String = "Leaving fluid temperature textbox"

      ' constructs and sets validation managers error provider
      Me.chillerVMgr = New ValidationManager(Me.err)
      ' constructs and adds leaving fluid temperature textbox to validation control
      Me.leavingFluidTempVCtrl = New ValidationControl(Me.txtLeavingFluidTemp)

      ' constructs required validator
      leavingFluidTempReqV = New RequiredValidator(ErrorMessages.Required(leavingFluidTempName))
      ' constructs number (regular expression) validator
      leavingFluidTempNumV = New RegularExpressionValidator( _
         ErrorMessages.Number(leavingFluidTempName), rae.validation.regular_expressions.number)
      ' contstructs range validator w/ error message and limits
      leavingFluidTempRangeV = New AmongRangeValidator(ErrorMessages.Range( _
         leavingFluidTempName, LEAVING_FLUID_TEMP_LOWER_LIMIT, LEAVING_FLUID_TEMP_UPPER_LIMIT), _
         LEAVING_FLUID_TEMP_LOWER_LIMIT, LEAVING_FLUID_TEMP_UPPER_LIMIT)
      ' adds leaving fluid temperature control to validation manager
      Me.chillerVMgr.ValidationControls.Add(Me.leavingFluidTempVCtrl)

      ' adds validators to leaving fluid temperature textbox
      '
      ' adds range validator
      Me.leavingFluidTempVCtrl.Validators.Add(leavingFluidTempRangeV)
      ' adds required validator
      Me.leavingFluidTempVCtrl.Validators.Add(leavingFluidTempReqV)
      ' adds number (regular expression) validator
      Me.leavingFluidTempVCtrl.Validators.Add(leavingFluidTempNumV)

   End Sub

   Private Sub selectCompressor(listbox As ListBox, compressorModel As String)
      Dim compressorToSelect As compressor
      For Each compr As compressor In listbox.Items
         If compr.model = compressorModel Then
            listbox.SelectedItem = compr
            GoTo skipNotFound
         End If
      Next
      listbox.SelectedIndex = 0
skipNotFound:
   End Sub


   Private Function IsFullDualCircuit() As Boolean
      If Me.grab_system() = "FULL" And Me.GrabCircuitsPerUnit() = "2" _
      Or Me.GrabCircuitsPerUnit() = "4" Then
         Return True
      Else
         Return False
      End If
   End Function

   Private Function IsFullSingleCircuit() As Boolean
      If Me.grab_system() = "FULL" And Me.GrabCircuitsPerUnit() = "1" Then
         Return True
      Else
         Return False
      End If
   End Function

   Private Function IsHalfCircuit1() As Boolean
      If Me.grab_system() = "HALF" And Me.GrabCircuit1Checked() Then
         Return True
      Else
         Return False
      End If
   End Function

   Private Function IsHalfCircuit2() As Boolean
      If Me.grab_system() = "HALF" And Me.GrabCircuit2Checked() Then
         Return True
      Else
         Return False
      End If
   End Function

#End Region



   Private Sub fillComboboxes()
      Me.fillRefrigerants()

      ' fills condenser comboboxes
      Me.cboCoilFileName1.DataSource = DataAccess.Chillers.ChillerDataAccess.GetCondensers()
      Me.cboCoilFileName2.DataSource = DataAccess.Chillers.ChillerDataAccess.GetCondensers()

      Me.cboFan.DataSource = condensers.condenser_repository.GetChillerFans(user.is_rep)

      Me.cboFpi1.DataSource = Me.getFinsPerInchOptions()
      Me.cboFpi2.DataSource = Me.getFinsPerInchOptions()
   End Sub


   ''' <summary>Sets control visibility base on authorization level
   ''' </summary>
   Private Sub SetControlsVisibility()

      ' if not employee
      If AppInfo.User.authority_group > 2 Then
         Me.hid_lblApproach.Visible = False
         Me.hid_txtApproach.Visible = False
         Me.Txtliqcool.ReadOnly = True

         Me.txtNumCoils1.ReadOnly = True
         Me.txtNumCoils2.ReadOnly = True
         Me.cboFpi1.Enabled = True
         Me.cboFpi2.Enabled = True
         Me.cboSubCooling1.Enabled = False
         Me.cboSubCooling2.Enabled = False
         Me.cboCoilFileName1.Enabled = False
         Me.cboCoilFileName2.Enabled = False
         Me.txtSubCoolingPercent1.Visible = False
         Me.txtSubCoolingPercent2.Visible = False
         Me.txtFinHeight1.ReadOnly = True
         Me.txtFinHeight2.ReadOnly = True
         Me.txtFinLength1.ReadOnly = True
         Me.txtFinLength2.ReadOnly = True
         Me.txtNumFans1.ReadOnly = True
         Me.txtNumFans2.ReadOnly = True
         Me.TxtCondCap_1.Visible = False
         Me.TxtCondCap_2.Visible = False
         Me.chkCatalog.Checked = True
         Me.chkCatalog.Visible = False
         Me.rbOther_Approch.Visible = False
      End If
   End Sub

   Private Function grabGlycolPerc() As Double
      Return ConvertNull.ToDouble(txtPercentGlycol.Text.Trim)
   End Function
   
   ' TODO: refacto
   Private Function grabFluid() As CoolingMedia
      Dim fluid As CoolingMedia

      If cboFluid.SelectedItem.ToString = "Water" Then
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
   

   ' fills freeze point and suction temperature textboxes
   Private Sub calcFreezePoint(fluid As CoolingMedia, glycolPerc As Double)
      Dim glycol = New FluidFactory().Create(fluid, glycolPerc)
      
      If glycol.PercentageInRange Then
         txtFreezingPoint.Text  = glycol.FreezePoint
         txtMinSuctionTemp.Text = glycol.MinSuctionTemp
      Else
         warn( msg(glycol.Min, glycol.Max) )
         txtPercentGlycol.Text = "20"
      End If
   End Sub



   Private Sub start_calculations()
      ok_to_print_SPACE = False
      Me.results.Rows.Clear()

      change_coil_desc()

      If Me.LeavingFluidTemp < 25 Or Me.LeavingFluidTemp > 60 Then
         TextBox1.Text() = "Leaving Fluid (25ºF to 60ºF), Please enter a correct value."
         If Trim(TextBox1.Text()) <= "  " Then
            TXT_ERROR_1_BOX.Visible = False
            TXT_ERROR_1_BOX.Text() = TextBox1.Text()
         Else
            TXT_ERROR_1_BOX.Visible = True
            TXT_ERROR_1_BOX.Text() = TextBox1.Text()
            ToolTip1.SetToolTip(TXT_ERROR_1_BOX, TextBox1.Text)
         End If
         Exit Sub
      End If

      Page_Cal_Pass = 1
run_Second_pass:
      cal_Tons_GPM()

      gArrHidDisplay.Clear()
      gArrHidCircuit2Display.Clear()
      ''' <history>Added by Casey Joyce</history>
      ''' <summary>gArrHidCircuit1Display was never cleared; if calculate page is clicked more than once, 
      ''' the array just gets bigger and only the beginning indices are ever used which is incorrect</summary>
      gArrHidCircuit1Display.Clear()

      If cboSystem.SelectedItem = "FULL" And Val(Txt_circuit_per_unit.Text) = 2 Or Val(Me.Txt_circuit_per_unit.Text) = 4 Then
         ok_to_print = False
         Running_Circuit_no = 1
         calculatePage()

         ok_to_print = True
         ok_to_print_SPACE = True
         Running_Circuit_no = 2
         calculatePage()
      ElseIf cboSystem.SelectedItem = "FULL" And Val(Txt_circuit_per_unit.Text()) = 1 Then
         Running_Circuit_no = 1
         ok_to_print_SPACE = True
         calculatePage()
      ElseIf cboSystem.SelectedItem = "HALF" Then
         If radCircuit1.Checked = True Then
            Running_Circuit_no = 1
         End If
         If radCircuit2.Checked = True Then
            ok_to_print_SPACE = True
            Running_Circuit_no = 2
         End If
         calculatePage()
      End If

      If Page_Cal_Pass = 1 Then
         Page_Cal_Pass = 2
         GoTo run_Second_pass
      End If

      If Trim(TextBox1.Text()) <= "  " Then
         TXT_ERROR_1_BOX.Visible = False
         TXT_ERROR_1_BOX.Text() = TextBox1.Text()
      Else
         TXT_ERROR_1_BOX.Visible = True
         TXT_ERROR_1_BOX.Text() = TextBox1.Text()
         ToolTip1.SetToolTip(TXT_ERROR_1_BOX, TextBox1.Text())
      End If
   End Sub


   Private Sub change_coil_desc()
      Dim changedRows As String
      Dim changedCoilType As String

      Select Case Me.cboCoilFileName1.SelectedIndex
         Case 0 : changedRows = "2"
         Case 1 : changedRows = "3"
         Case 2 : changedRows = "4"
         Case 3 : changedRows = "5"
         Case 4 : changedRows = "6"
         Case Else : Throw New Exception("Invalid coil file index.")
      End Select
      changedCoilType = "12"

      If Me.cboSubCooling1.SelectedItem = "Yes" Then
         Me.txtCondenser_1.Text = changedCoilType & "C" & Val(txtFinHeight1.Text) & "X" & Val(txtFinLength1.Text()) & "-" & cboFpi1.SelectedItem & "-" & changedRows & "-1C-S/C"
      Else
         Me.txtCondenser_1.Text = changedCoilType & "C" & Val(txtFinHeight1.Text) & "X" & Val(txtFinLength1.Text()) & "-" & cboFpi1.SelectedItem & "-" & changedRows & "-1C"
      End If

      Select Case Me.cboCoilFileName2.SelectedIndex
         Case 0 : changedRows = "2"
         Case 1 : changedRows = "3"
         Case 2 : changedRows = "4"
         Case 3 : changedRows = "5"
         Case 4 : changedRows = "6"
         Case Else
      End Select
      changedCoilType = "12"

      If Me.cboSubCooling2.SelectedItem = "Yes" Then
         Me.txtCondenser_2.Text = changedCoilType & "C" & Val(txtFinHeight2.Text) & "X" & Val(txtFinLength2.Text()) & "-" & cboFpi2.SelectedItem & "-" & changedRows & "-1C-S/C"
      Else
         Me.txtCondenser_2.Text = changedCoilType & "C" & Val(txtFinHeight2.Text) & "X" & Val(txtFinLength2.Text()) & "-" & cboFpi2.SelectedItem & "-" & changedRows & "-1C"
      End If
   End Sub


   Private Sub ResetVariables()
      '*****RESET VERIABLES***************
      CR_S = 0               'PRINT OUT CATALOG RATINGS?Y/N
      SG1 = ""                'SPECIFIC GRAVITY(GLYCOL)
      SH1 = ""                'SPECIFIC HEAT(GLYCOL)
      r = ""               'Refrigerant type

      A = 0
      B = 0
      EE = 0
      F = 0
      g = 0
      M = 0                   '25/CC
      P = 0
      Q = 0
      T = 0
      W = 0
      Z = 0


      EZ = 0
      ER = 0
      GP = 0
      H1 = 0
      H2 = 0
      KW = 0
      M1 = 0
      NC = 0                  'NUMBER OF COMPRESSOR CIRCUITS
      NF = 0                  'NUMBER OF FANS
      PC = 0
      PD = 0
      PE = 0
      Q1 = 0
      Q8 = 0                  'CHILLER CAP. @ 8 DEG APPROACH
      Q9 = 0                  'CHILLER CAP. @ 10 DEG APPROACH
      SG = 0                  'SPECIFIC GRAVITY(GLYCOL)
      TA = 0
      TC = 0
      TE = 0
      TW = 0
      SCF = 0                 'GLYCOL
      TA1 = 0
      TE1 = 0
      TE2 = 0
      TW1 = 0
      TW2 = 0
      GPMFACT = 0             'GLYCOL
      Me.fanWatts = 0

      '***** END *************************
   End Sub


   Private Sub calculatePage()
      Dim Compr_KW1 As Double
      Dim COMPR_KW_COUNTER As Double
      Dim hz_w, hz_a, hz_q As Double
      Dim capacityR507Multiplier, wattsR507Multiplier As Double     ' multiplier for compressors
      Dim range As Double                  'RANGE IN DEG. F.
      Dim CC As Double                 'COND. CAP. @ 25 DEG TEMP. DIF.
      Dim Exit_Glycol As Boolean           'TEST FOR EXITING GLYCOL PROCEDURE

      COMPR_KW_COUNTER = 1
      Page_Cal_Pass = Page_Cal_Pass + 1
      calcFreezePoint(grabFluid, grabGlycolPerc)

      Dim APP_Change As Double
      Dim count_passes As Single = 1
      lblLimits.Visible = False
      lblLimits.Text() = "Points outside operating limits omitted, contact factory for selection."
      If AppInfo.User.authority_group <= 2 Then
         If rbOther_Approch.Checked = True Then
            Txt8Deg_1.Visible = True
            Txt10Deg_1.Visible = True
            If Val(Txt_circuit_per_unit.Text()) > 1 Then
               Txt8Deg_2.Visible = True
               Txt10Deg_2.Visible = True
            End If
         Else
            Txt8Deg_1.Visible = False
            Txt10Deg_1.Visible = False
            Txt8Deg_2.Visible = False
            Txt10Deg_2.Visible = False
         End If
      End If

      TextBox1.Text = ""
        ''grd_results.Visible = True
        DataGridView2.Visible = True
        change_coil_desc()
      Dim my_Counter_pass As Single
      my_Counter_pass = 0
      Dim nextCuritem As Integer
      nextCuritem = 0

      If cboSystem.SelectedItem = "FULL" And Val(Txt_circuit_per_unit.Text) = 2 _
      Or Val(Txt_circuit_per_unit.Text) = 4 Then
         If ok_to_print = True And nextCuritem = 0 Then
            Me.DropDownList3.DataSource = Nothing
            Me.DropDownList3.DataSource = gArrHidCircuit1Display
         End If
      End If

      ResetVariables()

      calculate_specific_heat_and_gravity()
      setCondenserCapacity()
      showEvaporatorDataAtApproaches()

      'check approach for errors
      If rbOther_Approch.Checked = True Then
         If Val(Txt8Deg_1.Text()) = 0 Or Val(Txt10Deg_1.Text()) = 0 Then
            TextBox1.Text() = "Please enter a valid 8 and 10 deg. approach for circuit 1"
                ''grd_results.Visible = False
                DataGridView2.Visible = False
                Exit Sub
         End If
         If Val(Txt_circuit_per_unit.Text()) > 1 Then
            If Val(Txt8Deg_2.Text()) = 0 Or Val(Txt10Deg_2.Text()) = 0 Then
               TextBox1.Text() = "Please enter a valid 8 and 10 deg. approach for circuit 2"
                    ''grd_results.Visible = False
                    DataGridView2.Visible = False
                    Exit Sub
            End If
         End If
      Else
         If rb6_8.Checked = True Then
            If Val(txt6Deg.Text()) = 0 Or Val(txt8Deg.Text()) = 0 Then
               TextBox1.Text() = "Please select a different vessel."
                    ''grd_results.Visible = False
                    DataGridView2.Visible = False
                    Exit Sub
            End If
         ElseIf rb7_9.Checked = True Then
            If Val(txt7Deg.Text()) = 0 Or Val(txt9Deg.Text()) = 0 Then
               TextBox1.Text() = "Please select a different vessel."
                    ''grd_results.Visible = False
                    DataGridView2.Visible = False
                    Exit Sub
            End If
         ElseIf rb8_10.Checked = True Then
            If Val(txt8Deg.Text()) = 0 Or Val(txt10Deg.Text()) = 0 Then
               TextBox1.Text() = "Please select a different vessel."
                    ''grd_results.Visible = False
                    DataGridView2.Visible = False
                    Exit Sub
            End If
         ElseIf rb9_11.Checked = True Then
            If Val(txt9Deg.Text()) = 0 Or Val(txt11Deg.Text()) = 0 Then
               TextBox1.Text() = "Please select a different vessel."
                    ''grd_results.Visible = False
                    DataGridView2.Visible = False
                    Exit Sub
            End If
         ElseIf rb10_12.Checked = True Then
            If Val(txt10Deg.Text()) = 0 Or Val(txt12Deg.Text()) = 0 Then
               TextBox1.Text() = "Please select a different vessel."
                    ''grd_results.Visible = False
                    DataGridView2.Visible = False
                    Exit Sub
            End If
         End If
      End If

Print_Selection_1:
      '*******************Start Start_Selection() *********
      'set variable values
      If Running_Circuit_no = 1 Then
         NC = Val(txtNumCompressors1.Text())
         NF = Val(txtNumFans1.Text()) * Val(txtNumCoils1.Text())
         If rb6_8.Checked = True Then
            Q8 = Val(txt6Deg.Text())
            Q9 = Val(txt8Deg.Text())
         ElseIf rb7_9.Checked = True Then
            Q8 = Val(txt7Deg.Text())
            Q9 = Val(txt9Deg.Text())
         ElseIf rb8_10.Checked = True Then
            Q8 = Val(txt8Deg.Text())
            Q9 = Val(txt10Deg.Text())
         ElseIf rb9_11.Checked = True Then
            Q8 = Val(txt9Deg.Text())
            Q9 = Val(txt11Deg.Text())
         ElseIf rb10_12.Checked = True Then
            Q8 = Val(txt10Deg.Text())
            Q9 = Val(txt12Deg.Text())
         ElseIf rbOther_Approch.Checked = True Then
            Q8 = Val(Txt8Deg_1.Text())
            Q9 = Val(Txt10Deg_1.Text())
         End If
         CC = Val(TxtCondCap_1.Text)
      ElseIf Running_Circuit_no = 2 Then
         NC = Val(txtNumCompressors2.Text())
         NF = Val(txtNumFans2.Text()) * Val(txtNumCoils2.Text)
         If rb6_8.Checked = True Then
            Q8 = Val(txt6Deg.Text())
            Q9 = Val(txt8Deg.Text())
         End If
         If rb7_9.Checked = True Then
            Q8 = Val(txt7Deg.Text())
            Q9 = Val(txt9Deg.Text())
         End If
         If rb8_10.Checked = True Then
            Q8 = Val(txt8Deg.Text())
            Q9 = Val(txt10Deg.Text())
         End If
         If rb9_11.Checked = True Then
            Q8 = Val(txt9Deg.Text())
            Q9 = Val(txt11Deg.Text())
         End If
         If rb10_12.Checked = True Then
            Q8 = Val(txt10Deg.Text())
            Q9 = Val(txt12Deg.Text())
         End If
         If rbOther_Approch.Checked = True Then
            Q8 = Val(Txt8Deg_2.Text())
            Q9 = Val(Txt10Deg_2.Text())
         End If
         CC = Val(TxtCondCap_2.Text)
      End If

      range = Val(cboTempRange.SelectedItem)
      r = Me.GrabRefrigerant.Abbreviation
      TA1 = Me.AmbientTemp
      capacityR507Multiplier = 1
      wattsR507Multiplier = 1

      If chkCatalog.Checked = True Then
         CR_S = vbYes
      Else
         CR_S = vbNo
      End If

      Dim fanFileName As String = Me.GrabFan.FileName
      Dim hertz As Integer = CInt(Me.cboHertz.SelectedItem)
      Dim voltage As Integer = CInt(Me.cboVolts.SelectedItem)
      Me.fanWatts = Business.Intelligence.FanIntel.SelectFanWatts(fanFileName, hertz, voltage)
      'set hertz
      If cboHertz.SelectedItem = "50" Then
         hz_q = 0.833
         hz_w = 0.833
         hz_a = 1  'Changed per Dision 3/5/03 was 0.61
      ElseIf cboHertz.SelectedItem = "60" Then
         hz_q = 1
         hz_w = 1
         hz_a = 1
      Else
         Me.TextBox1.Text = TextBox1.Text & "Choose Hertz Operation - 50/60"
         Exit Sub
      End If

      If fanFileName = "CFM Per Fan >>>" Then
         Me.fanWatts = Val(Me.txtFanWatts1.Text)
         hz_q = 1
         hz_w = 1
         hz_a = 1
         If Me.fanWatts = 0 Then
            Me.fanWatts = 1100
         End If
      End If

      Me.txtFanWatts1.Text = Me.fanWatts.ToString

      If cboSystem.SelectedItem <> "FULL" And cboSystem.SelectedItem <> "HALF" Then
         Me.TextBox1.Text = Me.TextBox1.Text & "Make Selection for system - HALF/FULL"
         Exit Sub
      End If

      ' selects evaporator temperature range (sets upper and lower evaporator temperatures)
      Business.Intelligence.Chillers.ChillerIntel.SelectEvaporatorTempRange(Me.LeavingFluidTemp, Me.TE1, Me.TE2)

      TW1 = Me.LeavingFluidTemp - 4
      TW2 = Me.LeavingFluidTemp + 4

      '**********************End**************

      If Me.txtCompressor1.Text = "" Then
         TextBox1.Text() = TextBox1.Text() & "Make a valid compressor selection, INVALID COMPRESSOR"
         Exit Sub
      End If


      '*******************start 'FLUID_CHECK()***********************
      Dim coolingMedia As String  'ethylene, propylene
      Dim bGlycol As Boolean = False
      Dim sGlycolPercentage As String
      Dim liquidCooling As Double = CDbl(Me.Txtliqcool.Text)

      If cboFluid.SelectedItem <> "Water" Then
         If cboFluid.SelectedItem = "Glycol" Then
            bGlycol = True
            coolingMedia = cbo_glycol.SelectedItem
            If coolingMedia = "Ethylene" Then
               coolingMedia = "ETHYLENE GLYCOL"
            ElseIf coolingMedia = "Propylene" Then
               coolingMedia = "PROPYLENE GLYCOL"
            ElseIf coolingMedia = "  CHOOSE" Then
               Exit_Glycol = True
               Exit Sub
            End If

            sGlycolPercentage = Val(txtPercentGlycol.Text())
            If sGlycolPercentage = 0 Then
               TextBox1.Text() = TextBox1.Text() & "ENTER PERCENTAGE OF GLYCOL (IE 20%, 30%. ETC), ENTER PERCENTAGE GLYCOL"
               Exit_Glycol = True
               Exit Sub
            End If

            Dim specificHeat As Double = CDbl(Me.txtSpecificHeat.Text)
            If specificHeat = 0 Then
               TextBox1.Text = TextBox1.Text() & "ENTER GLYCOL SPECIFIC HEAT ENTER GLYCOL SPECIFIC HEAT"
               Exit_Glycol = True : Exit Sub
            End If

            SG = Val(txtSpecificGravity.Text)
            If SG = 0 Then
               TextBox1.Text() = TextBox1.Text() & "ENTER GLYCOL SPECIFIC GRAVITY ENTER GLYCOL SPECIFIC GRAVITY"
               Exit_Glycol = True
               Exit Sub
            End If
            GPMFACT = 500 * specificHeat * SG * range
            SCF = (liquidCooling * 0.005) + 1
            '********end***********************
            If Exit_Glycol = True Then
               TextBox1.Text = TextBox1.Text & "Exit_Glycol = True"
               Exit Sub
            End If
         Else
            TextBox1.Text = TextBox1.Text & "Enter a valid fluid type"
            Exit Sub
         End If
      Else
         SCF = (liquidCooling * 0.005) + 1
      End If
      '************************end*******************
40:
      M = (25 + cbo_Discharge_line_loss.SelectedItem) / CC

      Dim compressorModel = Me.GrabCompressor(Me.Running_Circuit_no)
      Dim refg =  refrigerant.parse(r)
        Dim compressor = compressor_repository.get_compressor(compressorModel, refg, voltage, "AirCooledChiller", "N")
      
      If Me.Running_Circuit_no = 1 Then
            ToolTip1.SetToolTip(txtCompressor1, compressor.MasterID)
        ElseIf Me.Running_Circuit_no = 2 Then
            ToolTip1.SetToolTip(txtCompressor2, compressor.MasterID)
        End If

        Dim capacityFactor = 1 ' always one for reps
        Dim wattFactor = 0.7821 * capacityFactor + 0.2104 ' use to match employee results
        Dim polynomial = New compressor_polynomial()

        For TA = (TA1 - 10) To (TA1 + 20) Step 10
            If TA > TA1 + 15 Then GoTo 1000

            For TE = TE1 To TE2 Step 15
                TC = TA + 10

                Do
                    TC += 0.2
                    H1 = (TC - TA) / M

                    Dim result = polynomial.calculate(refg, compressor.coef, TE, TC)
                    Q = result.q * NC * hz_q
                    W = result.w * NC * hz_w * wattFactor
                    A = result.a * NC * hz_a

                    H2 = Q + (3.413 * W)
                Loop While (H1 < H2)

                If TE = TE2 Then GoTo 400
                Q1 = Q
            Next TE

400:        A = (Q - Q1) / 15
            On Error GoTo ERR_404_1 'Resume Next 
410:        B = TE - (Q / A)
            GoTo 420  'skip error

ERR_404_1:
            TextBox1.Text() = "AN ERROR HAS OCCURRED, Contact factory for Rating of units outside the operating limits"
            ''grd_results.Visible = False
            DataGridView2.Visible = False
            Exit Sub

420:        M1 = (TE - B) / Q
            For TW = TW1 To TW2 Step 2
                If TW > TW2 Then GoTo 660
                APP_Change = 10
                If rb6_8.Checked = True Then
                    APP_Change = 8
                ElseIf rb7_9.Checked = True Then
                    APP_Change = 9
                ElseIf rb8_10.Checked = True Then
                    APP_Change = 10
                ElseIf rb9_11.Checked = True Then
                    APP_Change = 11
                ElseIf rb10_12.Checked = True Then
                    APP_Change = 12
                End If
450:            TE = TW - (APP_Change + cbo_Suction_line_loss.SelectedItem)
                EE = (Q9 - Q8) / 2
470:            F = TE + (Q9 / EE)
480:            g = (TE - F) / Q9
490:            TE = ((B * g) - (F * M1)) / (g - M1)
500:

S710:           TC = TA + 10
                Do
                    TC = TC + 0.2
                    H1 = (TC - TA) / M

                    Dim result = polynomial.calculate(refg, compressor.coef, TE, TC)
                    q = result.q * NC * hz_q
                    W = result.w * NC * hz_w * wattFactor
                    A = result.a * NC * hz_a

                    H2 = Q + (3.413 * W)
                Loop While (H1 < H2)

                If CR_S = vbYes Then _
                   Q = Q * 1.04

                Q = Q / 12000

                SCF = (((0.6187 * (TC - TA)) + 0.5753) * 0.005) + 1

                If Running_Circuit_no = 1 Then
                    If cboSubCooling1.SelectedItem = "No" Then
                        SCF = 1
                    End If
                End If
                If Running_Circuit_no = 2 Then
                    If cboSubCooling2.SelectedItem = "No" Then
                        SCF = 1
                    End If
                End If

                ' UNSURE: Is liquid cooling
                If Me.AmbientTemp = TA And Me.LeavingFluidTemp = TW Then
                    Me.Txtliqcool.Text = Round((0.6187 * (TC - TA)) + 0.5753, 1)
                End If

                Q = Q * SCF

                If bGlycol = True Then
                    GP = 12000 * Q / GPMFACT
                Else
                    GP = 12000 * Q / (500 * range)
                End If

550:            ER = Q * 12000 / W
560:            Compr_KW1 = Round(W / 1000, 1)

                KW = Compr_KW1 + Round(((Me.fanWatts * NF) / 1000), 1)    'add fan watts to make unit K Watts DBG 3/12/03
570:            EZ = Q * 12000 / (W + (Me.fanWatts * NF))

                'fill arrays with datagrid values
                If cboSystem.SelectedItem = "FULL" And Val(Txt_circuit_per_unit.Text()) = 2 _
                Or Val(Txt_circuit_per_unit.Text()) = 4 Then
                    If ok_to_print = False Then     'Circuit 1
                        COMPR_KW(1, COMPR_KW_COUNTER) = Format(Compr_KW1, "####.#")
                        COMPR_KW_COUNTER = COMPR_KW_COUNTER + 1
                        'fills hidden dropdown
                        gArrHidDisplay.Add(Format(TW, "###"))
                        gArrHidDisplay.Add(Format(TA, "###"))
                        gArrHidDisplay.Add(Format(TE, "##.#"))

                        gArrHidDisplay.Add(Format(TC, "###.#"))
                        gArrHidDisplay.Add(Format(Q, "###.#"))
                        gArrHidDisplay.Add(Format(KW, "####.#"))
                        gArrHidDisplay.Add(Format(GP, "####.#"))
                        gArrHidDisplay.Add(Format(A, "####.#"))
                        gArrHidDisplay.Add(Format(ER, "####.#"))
                        gArrHidDisplay.Add(Format(EZ, "####.#"))

                        'fills hidden dropdown
                        gArrHidCircuit1Display.Add(Format(TE, "##.#"))
                        gArrHidCircuit1Display.Add(Format(TC, "###.#"))
                        gArrHidCircuit1Display.Add(Format(Q, "###.#"))
                        gArrHidCircuit1Display.Add(Format(KW, "####.#"))
                        gArrHidCircuit1Display.Add(Format(GP, "####.#"))
                        gArrHidCircuit1Display.Add(Format(A, "####.#"))
                        gArrHidCircuit1Display.Add(Format(ER, "####.#"))
                        gArrHidCircuit1Display.Add(NF)
                        gArrHidCircuit1Display.Add(W)

                        If Me.LeavingFluidTemp = TW And Me.AmbientTemp = TA Then
                            hid_txtApproach.Text() = Round(TW - TE, 0)
                        End If

                        holding_tw_temp = TW
                        holding_te_temp = TE
                        holding_suction_temp = TE       'PASSING VALUE
                        holding_condenser_temp = TC     'PASSING VALUE

                        ok_to_show = Business.Intelligence.CompressorService.IsCompressorSafe(TE, TC, TE, TW, Me.GrabRefrigerant.Abbreviation, _
                           compressorModel, Me.GrabMinSuctionTemperature(), AppInfo.User.authority_group)

                        If Trim(txtLeavingFluidTemp.Text()) = Format(TW, "###") And Trim(txtAmbientTemp.Text()) = Format(TA, "###") Then
                            If ok_to_show = False Then
                                gArrHidDisplay.Add(2)
                            Else
                                gArrHidDisplay.Add(1)
                            End If
                        Else
                            If ok_to_show = False Then
                                gArrHidDisplay.Add(2)
                            Else
                                gArrHidDisplay.Add(0)
                            End If
                        End If
                    ElseIf ok_to_print = True Then     'Circuit 2
                        COMPR_KW(2, COMPR_KW_COUNTER) = Format(Compr_KW1, "####.#")
                        COMPR_KW_COUNTER = COMPR_KW_COUNTER + 1
                        'fill hidden dropdown
                        gArrHidCircuit2Display.Add(Format(TW, "###"))
                        gArrHidCircuit2Display.Add(Format(TA, "###"))
                        gArrHidCircuit2Display.Add(Format(TE, "##.#"))
                        gArrHidCircuit2Display.Add(Format(TC, "###.#"))
                        gArrHidCircuit2Display.Add(Format(Q, "###.#"))
                        gArrHidCircuit2Display.Add(Format(KW, "####.#"))
                        gArrHidCircuit2Display.Add(Format(GP, "####.#"))
                        gArrHidCircuit2Display.Add(Format(A, "####.#"))
                        gArrHidCircuit2Display.Add(Format(ER, "####.#"))

                        nextCuritem = nextCuritem + 1       'locating circuit 1 data
                        If nextCuritem = 1 Then
                            nextCuritem = 0
                        End If
                        'set display2 variables
                        DropDownList3.SelectedIndex = nextCuritem
                        TE_2 = Val(DropDownList3.SelectedItem)
                        nextCuritem = nextCuritem + 1
                        DropDownList3.SelectedIndex = nextCuritem
                        TC_2 = Val(DropDownList3.SelectedItem)
                        nextCuritem = nextCuritem + 1
                        DropDownList3.SelectedIndex = nextCuritem
                        Q_2 = Val(DropDownList3.SelectedItem)
                        nextCuritem = nextCuritem + 1
                        DropDownList3.SelectedIndex = nextCuritem
                        KW_2 = Val(DropDownList3.SelectedItem)
                        nextCuritem = nextCuritem + 1
                        DropDownList3.SelectedIndex = nextCuritem
                        GP_2 = Val(DropDownList3.SelectedItem)
                        nextCuritem = nextCuritem + 1
                        DropDownList3.SelectedIndex = nextCuritem
                        nextCuritem = nextCuritem + 1
                        DropDownList3.SelectedIndex = nextCuritem
                        ER_2 = Val(DropDownList3.SelectedItem)
                        nextCuritem = nextCuritem + 1
                        DropDownList3.SelectedIndex = nextCuritem
                        NF_2 = Val(DropDownList3.SelectedItem)
                        nextCuritem = nextCuritem + 1
                        DropDownList3.SelectedIndex = nextCuritem
                        W_2 = Val(DropDownList3.SelectedItem)


                        If Me.LeavingFluidTemp = TW And Me.AmbientTemp = TA Then
                            hid_txtApproach.Text() = Round(TW - ((TE + TE_2) / 2), 0)
                        End If

                        holding_tw_temp = TW
                        holding_te_temp = (TE + TE_2) / 2
                        holding_suction_temp = (TE + TE_2) / 2       'PASSING VALUE
                        holding_condenser_temp = (TC + TC_2) / 2     'PASSING VALUE

                        ok_to_show = Business.Intelligence.CompressorService.IsCompressorSafe(holding_te_temp, _
                           holding_condenser_temp, holding_te_temp, holding_tw_temp, _
                           Me.GrabRefrigerant.Abbreviation, compressorModel, Me.GrabMinSuctionTemperature(), AppInfo.User.authority_group)


                        EZ = ((Q + Q_2) * 12000) / ((W + W_2) + (Me.fanWatts * (NF + NF_2)))     'Recal Unit EER
                        gArrHidCircuit2Display.Add(Format(EZ, "####.#"))
                        If Trim(txtLeavingFluidTemp.Text()) = Format(TW, "###") And Trim(txtAmbientTemp.Text()) = Format(TA, "###") Then
                            If ok_to_show = False Then
                                gArrHidCircuit2Display.Add(2)
                            Else
                                gArrHidCircuit2Display.Add(1)
                            End If
                        Else
                            If ok_to_show = False Then
                                gArrHidCircuit2Display.Add(2)
                            Else
                                gArrHidCircuit2Display.Add(0)
                            End If
                        End If
                    End If

                Else
                    COMPR_KW(1, COMPR_KW_COUNTER) = Format(Compr_KW1, "####.#")
                    COMPR_KW_COUNTER = COMPR_KW_COUNTER + 1
                    gArrHidDisplay.Add(Format(TW, "###"))
                    gArrHidDisplay.Add(Format(TA, "###"))
                    gArrHidDisplay.Add(Format(TE, "##.#"))
                    gArrHidDisplay.Add(Format(TC, "###.#"))
                    gArrHidDisplay.Add(Format(Q, "###.#"))
                    gArrHidDisplay.Add(Format(KW, "####.#"))
                    gArrHidDisplay.Add(Format(GP, "####.#"))
                    gArrHidDisplay.Add(Format(A, "####.#"))
                    gArrHidDisplay.Add(Format(ER, "####.#"))
                    gArrHidDisplay.Add(Format(EZ, "####.#"))

                    If Me.LeavingFluidTemp = TW And Me.AmbientTemp = TA Then
                        hid_txtApproach.Text() = Round(TW - TE, 0)
                    End If

                    holding_tw_temp = TW
                    holding_te_temp = TE
                    holding_suction_temp = TE       'PASSING VALUE
                    holding_condenser_temp = TC     'PASSING VALUE

                    ok_to_show = Business.Intelligence.CompressorService.IsCompressorSafe(TE, TC, TE, TW, Me.GrabRefrigerant.Abbreviation, compressorModel, _
                       Me.GrabMinSuctionTemperature(), AppInfo.User.authority_group)

                    If Trim(txtLeavingFluidTemp.Text()) = Format(TW, "###") _
                    And Trim(txtAmbientTemp.Text()) = Format(TA, "###") Then
                        If ok_to_show = False Then
                            gArrHidDisplay.Add(2)
                        Else
                            gArrHidDisplay.Add(1)
                        End If
                    Else
                        If ok_to_show = False Then
                            gArrHidDisplay.Add(2)
                        Else
                            gArrHidDisplay.Add(0)
                        End If
                    End If
                End If


                If cboSystem.SelectedItem = "FULL" And Val(Txt_circuit_per_unit.Text()) = 2 _
                Or Val(Txt_circuit_per_unit.Text()) = 4 Then
                    If ok_to_print = True Then
                        If Me.LeavingFluidTemp = TW And Me.AmbientTemp = TA Then
                            hid_txtApproach.Text() = Round(TW - ((TE + TE_2) / 2), 0)
                        End If

                        holding_tw_temp = TW
                        holding_te_temp = (TE + TE_2) / 2
                        holding_suction_temp = (TE + TE_2) / 2       'PASSING VALUE
                        holding_condenser_temp = (TC + TC_2) / 2     'PASSING VALUE

                        ok_to_show = Business.Intelligence.CompressorService.IsCompressorSafe(holding_suction_temp, holding_condenser_temp, holding_te_temp, TW, _
                           Me.GrabRefrigerant.Abbreviation, compressorModel, Me.GrabMinSuctionTemperature(), AppInfo.User.authority_group)
                        'If ok_to_show = False Then
                        '   lblLimits.Visible = True
                        'End If
                        If ok_to_show = False Then
                            lblLimits.Visible = True
                            GoTo SKIP_DATABASE_BUILDER_TABLE1
                        End If
                    End If
                Else
                    If Me.LeavingFluidTemp = TW And Me.AmbientTemp = TA Then
                        hid_txtApproach.Text = Round(TW - TE, 0)
                    End If

                    holding_tw_temp = TW
                    holding_te_temp = TE
                    holding_suction_temp = TE       'PASSING VALUE
                    holding_condenser_temp = TC     'PASSING VALUE

                    ok_to_show = Business.Intelligence.CompressorService.IsCompressorSafe(TE, TC, TE, TW, Me.GrabRefrigerant.Abbreviation, compressorModel, _
                       Me.GrabMinSuctionTemperature(), AppInfo.User.authority_group)
                    If ok_to_show = False Then
                        lblLimits.Visible = True
                    End If
                    If ok_to_show = False Then
                        lblLimits.Visible = True
                        GoTo SKIP_DATABASE_BUILDER_TABLE1
                    End If
                End If

                'INSERT
                Dim COUNT_PD_GPM As Single, SET_PD As Double

                If cboSystem.SelectedItem = "FULL" And Val(Txt_circuit_per_unit.Text()) = 2 _
                Or Val(Txt_circuit_per_unit.Text()) = 4 Then
                    If ok_to_print = True Then
                        COUNT_PD_GPM = Round(TW - ((TE + TE_2) / 2), 0)
                        If PD_GPM.GetUpperBound(0) < COUNT_PD_GPM Then
                            SET_PD = 999
                        Else
                            SET_PD = (((GP + GP_2) / PD_GPM(COUNT_PD_GPM, 2)) ^ 2) * PD_GPM(COUNT_PD_GPM, 1)
                        End If

                        Hold_Set_PD(count_passes) = SET_PD

                        Me.insertResults(TW, TA, (TE + TE_2) / 2, (TC + TC_2) / 2, Q + Q_2, _
                           KW + KW_2, GP + GP_2, SET_PD, (ER + ER_2) / 2, EZ)
                    End If
                Else
                    COUNT_PD_GPM = Round(TW - TE, 0)
                    If PD_GPM.GetUpperBound(0) < COUNT_PD_GPM Then
                        SET_PD = 999
                    Else
                        SET_PD = ((GP / PD_GPM(COUNT_PD_GPM, 2)) ^ 2) * PD_GPM(COUNT_PD_GPM, 1)
                    End If
                    Hold_Set_PD(count_passes) = SET_PD

                    Me.insertResults(TW, TA, TE, TC, Q, KW, GP, SET_PD, ER, EZ)
                End If

SKIP_DATABASE_BUILDER_TABLE1:
                count_passes = count_passes + 1

                If Me.LeavingFluidTemp + 4 = TW Then
                    If ok_to_print_SPACE = True And Me.AmbientTemp + cboTempRange.SelectedItem <> TA Then
                        Me.insertBlankRowInResults()
                    End If
                End If

600:            If TW = Me.LeavingFluidTemp - 2 Then GoTo 610 Else GoTo 630
610:            TW = Me.LeavingFluidTemp - 1
620:            GoTo 450
630:            If TW = Me.LeavingFluidTemp - 1 Then GoTo 640 Else GoTo 650
640:            TW = Me.LeavingFluidTemp - 2
650:        Next TW
660:    Next TA

1000:   If Page_Cal_Pass = 1 Then
            Exit Sub
        End If

        If cboSystem.SelectedItem = "FULL" And Val(Txt_circuit_per_unit.Text()) = 2 _
        Or Val(Txt_circuit_per_unit.Text()) = 4 Then
            If ok_to_print = False Then
                DropDownList3.DataSource = gArrHidCircuit1Display
                GoTo Skip_Print_or_Cal
            End If
        End If

        If cboSystem.SelectedItem = "FULL" And Val(Txt_circuit_per_unit.Text()) = 2 Or Val(Txt_circuit_per_unit.Text()) = 4 Then
            DropDownList2.DataSource = gArrHidCircuit2Display
        End If
        cboHidValues.DataSource = gArrHidDisplay

        ' fills datagrid
        Me.fillGrid()
Skip_Print_or_Cal:

    End Sub

    Private Function grab_compressor_1() As compressor
        Return lboCompressors1.SelectedItem
    End Function
    Private Function grab_compressor_2() As compressor
        Return lboCompressors2.SelectedItem
    End Function

    Private Function get_report_parameters() As report_parameters
        Dim chillerModel, condenser_description, evaporator_description, compressor_description, fluid, circuits_message, operating_limits_message, temperature_range_message As String
        Dim capacity_at_8, capacity_at_10, condenser_capacity, catalog_rating_message As String
        Dim numFans As Double

        Dim line As String = System.Environment.NewLine

        ' sets value of parameters to be passed
        '       
        ' sets chiller model
        If Me.txt_model.Text = Me.grab_model() Then
            chillerModel = Me.grab_model()
        Else
            chillerModel = Me.txt_model.Text & "       Base Model: " & Me.grab_model()
        End If
        Dim compressor_1 = grab_compressor_1()
        Dim compressor_2 = grab_compressor_2()
        Dim numCoils1 = ConvertNull.ToDouble(txtNumCoils1.Text)
        Dim numCoils2 = ConvertNull.ToDouble(txtNumCoils2.Text)

        ' sets condenser description
        If IsFullDualCircuit Then
            condenser_description = "(" & numCoils1 & ")" & Me.txtCondenser_1.Text & _
               " --- " & "(" & numCoils2 & ")" & Me.txtCondenser_2.Text
        ElseIf IsFullSingleCircuit Then
            condenser_description = "(" & numCoils1 & ")" & Trim(txtCondenser_1.Text)
        ElseIf IsHalfCircuit1 Then
            condenser_description = "(" & numCoils1 & ")" & Me.txtCondenser_1.Text
        ElseIf Me.IsHalfCircuit2() Then
            condenser_description = "(" & numCoils2 & ")" & Me.txtCondenser_2.Text
        End If

        ' sets evaporator description
        evaporator_description = Me.grab_evaporator_model_from_textbox() & "   Fouling = " & Me.cboFoulingFactor.SelectedItem

        ' sets compressor description
        If Me.IsFullSingleCircuit() Then
            compressor_description = "(" & Me.GrabNumCompressors(1).ToString & ") " & compressor_1.MasterID
        ElseIf Me.IsFullDualCircuit() Then
            compressor_description = "(" & Me.GrabNumCompressors(1).ToString & ") " & compressor_1.MasterID & _
               " --- " & "(" & Me.GrabNumCompressors(2).ToString & ") " & compressor_2.MasterID
        ElseIf Me.IsHalfCircuit1() Then
            compressor_description = "(" & Me.GrabNumCompressors(1).ToString & ") " & compressor_1.MasterID
        ElseIf Me.IsHalfCircuit2() Then
            compressor_description = "(" & Me.GrabNumCompressors(2) & ") " & compressor_2.MasterID
        End If

        ' sets fluid
        If Me.cboFluid.SelectedItem = "Water" Then
            fluid = Me.cboFluid.SelectedItem
        Else
            fluid = Me.cboFluid.SelectedItem & "   " & Me.txtPercentGlycol.Text & "% " & Me.cbo_glycol.SelectedItem
        End If

        ' sets circuit label indicating circuits if half system is selected
        If Me.grab_system() = "HALF" Then
            If Me.GrabCircuit1Checked() Then
                If Me.GrabCircuitsPerUnit() = 1 Then
                    circuits_message = "Showing Circuit 1 of 1"
                Else
                    circuits_message = "Showing Circuit 1 of 2"
                End If
            Else
                circuits_message = "Showing Circuit 2 of 2"
            End If
        Else
            circuits_message = " "
        End If

        ' sets operating limits note
        If Me.lblLimits.Visible Then
            operating_limits_message = Me.lblLimits.Text.Trim ' Points Omitted
        Else : operating_limits_message = "" : End If

        ' sets temperature range note
        temperature_range_message = "Calculations based on " & Trim(Me.cboTempRange.SelectedItem) & "ºF range"

        If Me.rbOther_Approch.Checked Then
        Else
            If Me.rb6_8.Checked Then
                Q8 = Val(Me.txt6Deg.Text)
                Q9 = Val(Me.txt8Deg.Text)
            ElseIf Me.rb7_9.Checked Then
                Q8 = Val(Me.txt7Deg.Text)
                Q9 = Val(Me.txt9Deg.Text)
            ElseIf Me.rb8_10.Checked Then
                Q8 = Val(Me.txt8Deg.Text)
                Q9 = Val(Me.txt10Deg.Text)
            ElseIf Me.rb9_11.Checked Then
                Q8 = Val(Me.txt9Deg.Text)
                Q9 = Val(Me.txt11Deg.Text)
            ElseIf Me.rb10_12.Checked Then
                Q8 = Val(Me.txt10Deg.Text)
                Q9 = Val(Me.txt12Deg.Text)
            End If
        End If

        Dim numFans1 = ConvertNull.ToDouble(txtNumFans1.Text)
        Dim numFans2 = ConvertNull.ToDouble(txtNumFans2.Text)
        Dim cc1 = ConvertNull.ToDouble(TxtCondCap_1.Text)
        Dim cc2 = ConvertNull.ToDouble(TxtCondCap_2.Text)
        Dim altitude = ConvertNull.ToDouble(txtAltitude1.Text)
        Dim cfm = ConvertNull.ToDouble(txtCfmOverRide.Text)
        Dim fan = GrabFan()
        Dim usingCustomFan = (fan.FileName = "CFM Per Fan >>>")
        Dim fan_description As String

        If IsFullSingleCircuit Then
            capacity_at_8 = Q8
            capacity_at_10 = Q9
            condenser_capacity = cc1
            numFans = numFans1 * numCoils1
        ElseIf IsFullDualCircuit Then
            capacity_at_8 = Q8 * 2
            capacity_at_10 = Q9 * 2
            condenser_capacity = cc1 + cc2
            numFans = numFans1 * numCoils1 + numFans2 * numCoils2
        ElseIf IsHalfCircuit1 Then
            capacity_at_8 = Q8
            capacity_at_10 = Q9
            condenser_capacity = cc1
            numFans = numFans1 * numCoils1
        ElseIf IsHalfCircuit2 Then
            capacity_at_8 = Q8
            capacity_at_10 = Q9
            condenser_capacity = cc2
            numFans = numFans2 * numCoils2
        End If

        Dim highAltitude = Business.Intelligence.FanIntel.HighAltitude
        Dim highAltitudeRecommendation = If(altitude >= highAltitude AndAlso Not fan.IsHighAltitudeFan, "high altitude fan recommended", "")

        If usingCustomFan Then
            fan_description = Str("({0}) {1}{2}   Altitude = {3}", _
                           numFans, fan.FileName, cfm, altitude)
        Else
            fan_description = Str("({0}) {1}   Altitude = {2} {3}", _
                           numFans, fan.Description, altitude, highAltitudeRecommendation)
        End If

        ' sets catalog rating note
        If Me.chkCatalog.Checked Then
            catalog_rating_message = "Catalog Rating"
        Else : catalog_rating_message = "" : End If

        Dim pressure_drop_message As String = ""
        For Each result In Me.results.Rows
            If result.EvaporatorPressureDrop = "*" Then
                pressure_drop_message = "* The fluid pressure drop cannot be calculate when approach is out of range or a custom evaporator is selected."
            End If
        Next

        Dim ambient = AmbientTemp.ToString("#.0")
        Dim leaving_fluid_temperature = LeavingFluidTemp.ToString("#.0")
        Dim hertz = cboHertz.SelectedItem
        Dim discharge_line_loss = cbo_Discharge_line_loss.SelectedItem
        Dim suction_line_loss = cbo_Suction_line_loss.SelectedItem

        Dim parameters As report_parameters
        parameters.model = chillerModel
        parameters.pressure_drop_message = pressure_drop_message
        'report.pass("pfdAuthorization", "Rep")
        parameters.application_version = my.application.info.version.toString
        parameters.ambient = ambient
        parameters.leaving_fluid_temperature = leaving_fluid_temperature
        'report.pass("pfdTest", Constants.TESTING.ToString)
        parameters.user = user.username
        parameters.condenser_description = condenser_description
        parameters.evaporator_description = evaporator_description
        parameters.system = grab_system
        parameters.compressor_description = compressor_description
        parameters.refrigerant = grabRefrigerant.refrigerant
        parameters.hertz = hertz
        parameters.fluid = fluid
        parameters.circuits_message = circuits_message
        parameters.operating_limits_message = operating_limits_message
        parameters.temperature_range_message = temperature_range_message
        parameters.capacity_at_8 = capacity_at_8
        parameters.capacity_at_10 = capacity_at_10
        parameters.condenser_capacity = condenser_capacity
        parameters.fan_description = fan_description
        parameters.discharge_line_loss = discharge_line_loss
        parameters.suction_line_loss = suction_line_loss
        parameters.catalog_rating_message = catalog_rating_message

        Return parameters
    End Function

   structure report_parameters
      public application_version, user as string
      public ambient, leaving_fluid_temperature, temperature_range_message, discharge_line_loss, suction_line_loss as string
      public model, system, fluid, refrigerant, hertz, condenser_capacity as string
      public condenser_description, evaporator_description, compressor_description, fan_description as string
      public pressure_drop_message, circuits_message, operating_limits_message, catalog_rating_message as string
      public capacity_at_8, capacity_at_10 as string
   end structure

   private sub show_word_report
      dim command = new get_logo_file_path_command(user, AppInfo.division.toString)
      dim logo_file_path = command.execute

      dim parameters = get_report_parameters
      dim text = new dictionary(of string, string)

      'footer
      text.add("user", parameters.user)
      text.add("application_version", parameters.application_version)
      text.add("date_created", date.now.ToShortDateString)
      text.add("year", date.now.year)
      '
      text.add("model", parameters.model)
      text.add("condenser_description", parameters.condenser_description)
      text.add("evaporator_description", parameters.evaporator_description)
      text.add("compressor_description", parameters.compressor_description)
      text.add("fan_description", parameters.fan_description)
      text.add("fluid", parameters.fluid)
      text.add("refrigerant", parameters.refrigerant)
      text.add("hertz", parameters.hertz & "hz")
      text.add("system", parameters.system)
      text.add("discharge_line_loss", parameters.discharge_line_loss.F)
      text.add("suction_line_loss", parameters.suction_line_loss.F)
      text.add("condenser_capacity", parameters.condenser_capacity.format_number("#,#").BTUH)
      text.add("capacity_at_8", parameters.capacity_at_8.format_number("#,#").BTUH)
      text.add("capacity_at_10", parameters.capacity_at_10.format_number("#,#").BTUH)

      dim notes = new list(of string)
      if parameters.operating_limits_message.is_set then notes.add(parameters.operating_limits_message)
      if parameters.pressure_drop_message.is_set then notes.add(parameters.pressure_drop_message)
      if parameters.catalog_rating_message.is_set then notes.add(parameters.catalog_rating_message)
      if parameters.temperature_range_message.is_set then notes.add(parameters.temperature_range_message)

      dim table = me.results.copy
      table.columns(0).ColumnName = "Leaving Fluid [°F]"
      table.columns(1).ColumnName = "Ambient [°F]"
      table.columns(2).ColumnName = "Evaporator [°F]"
      table.columns(3).ColumnName = "Condenser [°F]"
        table.Columns(4).ColumnName = "Est. Capacity [Tons]"
      table.columns(5).ColumnName = "Unit [KW]"
      table.columns(6).ColumnName = "GPM"
      table.columns(7).ColumnName = "Evap. PD"
      table.columns(8).ColumnName = "Compressor EER"
      table.columns(9).ColumnName = "Unit EER"

      dim report = new rae.reporting.beta.report( reports.file_paths.air_cooled_chiller_balance_template_file_path )
      report.set_text(text)
      report.set_table("table", table)
      report.set_list("notes", notes)
      report.set_image("logo", logo_file_path)
      report.remove("employee_section")
      report.show
   end sub

    'Private Sub show_crystal_report()
    '   dim report = new report_factory().create(Reports.file_paths.AirCooledChillerRatingReportFilePath)
    '   report.source = Me.results

    '   report.pass("pfdAuthorization", "Rep")
    '   report.pass("logo", "TSI")

    '   dim parameters = get_report_parameters
    '   report.pass("pressure_drop_message", parameters.pressure_drop_message)
    '   report.pass("pfdVersion", parameters.application_version)
    '   report.pass("pfdAmbient", parameters.ambient)
    '   report.pass("pfdLeavingFluid", parameters.leaving_fluid_temperature)
    '   report.pass("pfdTest", Constants.TESTING.ToString)
    '   report.pass("pfdCreator", parameters.user)
    '   report.pass("pfdModelNumber", parameters.model)
    '   report.pass("pfdCondenser", parameters.condenser_description)
    '   report.pass("pfdEvaporator", parameters.evaporator_description)
    '   report.pass("pfdSystem", parameters.system)
    '   report.pass("pfdCompressor", parameters.compressor_description)
    '   report.pass("pfdRefrigerant", parameters.refrigerant)
    '   report.pass("pfdHertz", parameters.hertz)
    '   report.pass("pfdFluid", parameters.fluid)
    '   report.pass("pfdCircuit", parameters.circuits_message)
    '   report.pass("pfdOperatingLimits", parameters.operating_limits_message)
    '   report.pass("pfdRange", parameters.temperature_range_message)
    '   report.pass("pfd8Evaporator", parameters.capacity_at_8)
    '   report.pass("pfd10Evaporator", parameters.capacity_at_10)
    '   report.pass("pfdLowerApproach", 8)
    '   report.pass("pfdUpperApproach", 10)
    '   report.pass("pfdCondenserCapacity", parameters.condenser_capacity)
    '   report.pass("pfdFans", parameters.fan_description)
    '   report.pass("pfdDischarge", parameters.discharge_line_loss)
    '   report.pass("pfdSuction", parameters.suction_line_loss)
    '   report.pass("pfdCatalog", parameters.catalog_rating_message)

    '   report.show()
    'End Sub


   Private Sub cal_Tons_GPM()
      If radCapacityGpm.Checked = True Then 'GPM entered
         TxtTonsSystemCap.Text() = Round(Val(txtCapacity.Text()) * cboTempRange.SelectedItem * 500 * Val(txtSpecificHeat.Text) * Val(txtSpecificGravity.Text()) / 12000, 2)
         ToolTip1.SetToolTip(txtCapacity, "Tons = " & Val(TxtTonsSystemCap.Text))
         txt_gpm.Text() = Val(txtCapacity.Text())
      ElseIf radCapacityTons.Checked = True Then  'Tons entered
         TxtTonsSystemCap.Text = Val(txtCapacity.Text)
         txt_gpm.Text = Round((Val(txtCapacity.Text) * 12000) / (cboTempRange.SelectedItem * 500 * Val(txtSpecificHeat.Text) * Val(txtSpecificGravity.Text)), 2)
         ToolTip1.SetToolTip(txtCapacity, "GPM = " & Val(txt_gpm.Text))
      End If
   End Sub


   ' fills and formats datagrid
   Private Sub fillGrid()
        ' fills datagrid w/ results
        ''Me.grd_results.DataSource = Me.results
        Me.DataGridView2.DataSource = Me.results

        ' formats datagrid
        ''Me.formatResultsGrid(Me.grd_results)
    End Sub


   Private Sub setCondenserCapacity()
      ' calculates condenser capacity
      '
      ' gets inputs from controls
      Dim altitude, td, coilHeight, coilLength, ambient, condenserCapacity As Double
      Dim fpi as integer
      dim fans As Double
      Dim coilFileName As String
      Dim fanFile As String = Me.GrabFan.FileName
      Dim cfmOverride As Double = ConvertNull.ToDouble(Me.txtCfmOverRide.Text)
      ambient = 95
      td = 25
      If Running_Circuit_no = 1 Then
         ' TODO: validate inputs
         altitude = CDbl(Me.txtAltitude1.Text.Trim)
         fans = CDbl(Me.txtNumFans1.Text)
         coilHeight = CDbl(Me.txtFinHeight1.Text.Trim)
         coilLength = CDbl(Me.txtFinLength1.Text.Trim)
         coilFileName = Me.GrabCondenser1.FileName
         fpi = CInt(Me.cboFpi1.SelectedItem)
      ElseIf Running_Circuit_no = 2 Then
         altitude = CDbl(Me.txtAltitude2.Text.Trim)
         fans = CDbl(Me.txtNumFans2.Text.Trim)
         coilHeight = CDbl(Me.txtFinHeight2.Text.Trim)
         coilLength = CDbl(Me.txtFinLength2.Text.Trim)
         coilFileName = Me.GrabCondenser2.FileName
         fpi = CInt(Me.cboFpi2.SelectedItem)
      End If
      ' calls condenser dll
      Dim cond As Condenser
      If Me.GrabFan.FileName = "CFM Per Fan >>>" Then
            cond = New Condenser(ambient, td, coilHeight, coilLength, coilFileName, fans, cfmOverride, "Smooth")
      Else
            cond = New Condenser(ambient, td, coilHeight, coilLength, coilFileName, fans, fanFile, "Smooth")
      End If
      cond.Calculate()
      condenserCapacity = cond.Output.At(fpi).Capacity

      ' adjusts condenser capacity for refrigerant
      '
      Dim refrigerant As String = Me.GrabRefrigerant.Abbreviation
      condenserCapacity = Logic.Chillers.ChillerIntel.AdjustCondenserCapacityForRefrigerant(condenserCapacity, refrigerant)

      ' adjusts coil capacity for sub cooling percentage
      '
      If Running_Circuit_no = 1 Then
         If Me.cboSubCooling1.SelectedItem = "Yes" Then
            Dim subCoolingPercentage As Double = CDbl(Me.txtSubCoolingPercent1.Text.Trim)
            condenserCapacity = Logic.Chillers.ChillerIntel.AdjustCondenserCapacityForSubCooling(condenserCapacity, subCoolingPercentage)
         End If
      ElseIf Running_Circuit_no = 2 Then
         If cboSubCooling2.SelectedItem = "Yes" Then
            Dim subCoolingPercentage As Double = CDbl(Me.txtSubCoolingPercent2.Text.Trim)
            condenserCapacity = Logic.Chillers.ChillerIntel.AdjustCondenserCapacityForSubCooling(condenserCapacity, subCoolingPercentage)
         End If
      End If

      ' set controls with calculated condenser capacity
      Me.TxtCondCap.Text = Round(condenserCapacity, 0)
      If Running_Circuit_no = 1 Then
         Dim numCoils As Integer = CInt(Me.txtNumCoils1.Text)
         Me.TxtCondCap_1.Text = Round(condenserCapacity, 0) * numCoils
      ElseIf Running_Circuit_no = 2 Then
         Dim numCoils As Integer = CInt(Me.txtNumCoils2.Text)
         Me.TxtCondCap_2.Text = Round(condenserCapacity, 0) * numCoils
      End If
   End Sub

    Private service As New rep_service(New compressor_repository(), New rep_repository(), AppInfo.User)
      
   private function grab_voltage() as integer
      return 230
   end function

   private sub fill_compressors(chiller as chiller)
      dim r = refrigerant.parse(chiller.circuit_1.refrigerant)
      dim voltage = grab_voltage()
      

        Dim compressors = service.get_compressors(r, voltage, chiller.circuit_1.compressor.masterID, "")
        'todo: lboCompressors1.Fill(compressors)
        lboCompressors1.Items.Clear()
        For Each compr In compressors
            lboCompressors1.Items.Add(compr)
        Next

        'todo: lboCompressors2.Fill(compressors)
        lboCompressors2.Items.Clear()
        For Each compr In compressors
            lboCompressors2.Items.Add(compr)
        Next
    End Sub


    Public Sub Set_Fan_Watts()
        ' grabs fan file name
        Dim fanFileName As String = Me.GrabFan.FileName
        Dim hertz As Integer = CInt(Me.cboHertz.SelectedItem.ToString)
        Dim voltage As Integer = CInt(Me.cboVolts.SelectedItem)

        Dim fanWatts As Integer = Business.Intelligence.FanIntel.SelectFanWatts(fanFileName, hertz, voltage)

        Me.txtFanWatts1.Text = fanWatts
        Me.fanWatts = fanWatts
    End Sub


    Private Sub CALL_Circuit1(ByVal chiller As chiller)
        Dim avgCapacity As Double


        ' calculates capacity average
        avgCapacity = Round(Average(chiller.approx_min_capacity, chiller.approx_max_capacity), 2)

        ' sets controls
        ' ----------------

        Me.txt_evaporator.Text = chiller.evaporator_part_number
        Me.txtCondenser_1.Text = chiller.circuit_1.coil.Name
        Me.txtCompressor1.Text = chiller.circuit_1.compressor.masterID
        Me.txtNumCompressors1.Text = chiller.circuit_1.compressor_quantity.ToString
        Me.txtNumFans1.Text = chiller.circuit_1.fan_quantity.ToString
        Me.txtNumCoils1.Text = chiller.circuit_1.coil_quantity
        Me.Txt_circuit_per_unit.Text = chiller.num_circuits_per_unit.ToString
        Me.txtSubCoolingPercent1.Text = chiller.circuit_1.subcooling_percentage.ToString
        Me.txtFinHeight1.Text = chiller.circuit_1.coil.Height.ToString
        Me.txtFinLength1.Text = chiller.circuit_1.coil.Length.ToString

        If Me.radCapacityTons.Checked Then  ' Tons 
            Me.txtCapacity.Text = avgCapacity.ToString
        ElseIf radCapacityGpm.Checked = True Then  ' GPM 
            Me.txtCapacity.Text = Round(Convert.TonsToGpm( _
               avgCapacity, Me.GrabTemperatureRange(), Me.GrabSpecificHeat(), Me.GrabSpecificGravity()), 2)
        End If

        Me.cal_Tons_GPM()

        If chiller.num_circuits_per_unit = 1 Then
            Me.cboSystem.SelectedIndex = 0
            Me.cboSystem.Enabled = False
        Else
            Me.cboSystem.Enabled = True
        End If

        ' selects compressor
        selectCompressor(lboCompressors1, chiller.circuit_1.compressor.masterID.ToUpper)

        ' selects fins per inch
        Me.cboFpi1.SelectedIndex = RAE.UI.ListHelper.IndexOfComboBoxItem(Me.cboFpi1, CInt(chiller.circuit_1.coil.fpi))

        ' selects condenser with matching file name (number of rows)
        Me.cboCoilFileName1.SelectedIndex = Me.indexOfCondenser( _
           Me.cboCoilFileName1, chiller.circuit_1.coil.Rows.ToString & "RCOND")

        ' selects fan with matching fan file name determined by fan diameter (applies to both circuits)
        Me.cboFan.SelectedIndex = Me.indexOfFanFileName( _
           Me.cboFan, Business.Intelligence.FanIntel.SelectFanFileName(chiller.circuit_1.fan_diameter))

        If chiller.num_circuits_per_unit > 1 Then
            Me.radCircuit2.Visible = True
        End If

        ' retrieves evaporator info
        Dim evaporator = Business.Agents.ChillerAgent.RetrieveChillerEvaporator(Me.grab_evaporator_model_from_textbox())
        ' sets evaporator tooltip
        Me.ToolTip1.SetToolTip(Me.txt_evaporator, evaporator.ToString)
        Me.txt_Evap_Length.Text = evaporator.Length.ToString
        setCondenserCapacity()
        calculate_specific_heat_and_gravity()
        showEvaporatorDataAtApproaches()
    End Sub


    Private Sub CALL_Circuit2(ByVal chiller As chiller)
        ' calculates average of minimum and maximum capacity
        Dim avgCapacity = Round(Average(chiller.approx_min_capacity, chiller.approx_max_capacity), 2)

        ' sets controls
        Me.txt_evaporator.Text = chiller.evaporator_part_number
        Me.txtCondenser_2.Text = chiller.circuit_2.coil.Name
        Me.txtCompressor2.Text = chiller.circuit_2.compressor.masterID
        Me.txtNumCompressors2.Text = chiller.circuit_2.compressor_quantity.ToString
        Me.txtNumFans2.Text = chiller.circuit_2.fan_quantity.ToString
        Me.txtNumCoils2.Text = chiller.circuit_2.coil_quantity.ToString
        Me.Txt_circuit_per_unit.Text = chiller.num_circuits_per_unit.ToString
        Me.txtSubCoolingPercent2.Text = chiller.circuit_2.subcooling_percentage.ToString

        If Me.radCapacityTons.Checked Then  'Tons 
            Me.txtCapacity.Text = Round(avgCapacity, 2)
        ElseIf radCapacityGpm.Checked Then  'GPM 
            Me.txtCapacity.Text = Convert.TonsToGpm( _
               avgCapacity, Me.GrabTemperatureRange(), Me.GrabSpecificHeat, Me.GrabSpecificGravity)
        End If
        Me.cal_Tons_GPM()

        If chiller.num_circuits_per_unit = 1 Then
            Me.cboSystem.SelectedIndex = 0
            Me.cboSystem.Enabled = False
        Else
            Me.cboSystem.Enabled = True
        End If

        selectCompressor(lboCompressors2, chiller.circuit_2.compressor.masterID.ToUpper)

        ' selects fpi
        Me.cboFpi2.SelectedIndex = RAE.UI.ListHelper.IndexOfComboBoxItem(Me.cboFpi2, CInt(chiller.circuit_2.coil.fpi))
        ' sets fin size
        Me.txtFinHeight2.Text = chiller.circuit_2.coil.Height.ToString
        Me.txtFinLength2.Text = chiller.circuit_2.coil.Length.ToString

        ' selects condenser
        Me.cboCoilFileName2.SelectedIndex = Me.indexOfCondenser( _
           Me.cboCoilFileName2, chiller.circuit_2.coil.Rows.ToString & "RCOND")
        ' selects fan based on fan diameter
        Me.cboFan.SelectedIndex = Me.indexOfFanFileName( _
           Me.cboFan, Business.Intelligence.FanIntel.SelectFanFileName(chiller.circuit_2.fan_diameter))


        ' retrieves evaporator
        Dim evaporator = Business.Agents.ChillerAgent.RetrieveChillerEvaporator(Me.grab_evaporator_model_from_textbox())
        Me.ToolTip1.SetToolTip(Me.txt_evaporator, evaporator.ToString)
        Me.txt_Evap_Length.Text = evaporator.Length.ToString


        If chiller.num_circuits_per_unit > 1 Then Me.radCircuit2.Visible = True

        Me.setCondenserCapacity()
        'calculateSpecificHeatAndGravity()
        showEvaporatorDataAtApproaches()
    End Sub
   
   Private Sub jot(message As String)
      System.Diagnostics.Debug.WriteLine(message)
   End Sub
   
   Private Sub cbo_models_SelectedIndexChanged() _
   Handles cbo_models.SelectedIndexChanged      
      jot("model changed " & Threading.Thread.CurrentThread.ManagedThreadId)
      
      Dim selectedModel = grab_model()
      
      If Not loaded OrElse selectedModel="Choose" Then _
         Exit Sub
         
      model_changed_schedule.Change(selectedModel)
   End Sub
   
   Private Sub handle_model_changed()
      Me.Cursor = Cursors.WaitCursor
      
      jot("handle model changed " & Threading.Thread.CurrentThread.ManagedThreadId)
      
      If loaded And Me.grab_model() <> "Choose" Then
         set_initial_control_visibility(visible:=true)
         set_enabled_on_acme_releated_controls(enabled:=false)

            ''grd_results.Visible = False
            DataGridView2.Visible = False
            TextBox1.Text = ""
         
         Dim chiller = Business.Agents.ChillerAgent.RetrieveChiller(Me.grab_model())
         chiller.circuit_1.refrigerant = grabRefrigerant.Abbreviation
         Me.fill_compressors(chiller)

         Running_Circuit_no = 1 : CALL_Circuit1(chiller)
         If Val(Me.Txt_circuit_per_unit.Text) > 1 Then
            Running_Circuit_no = 2 : CALL_Circuit2(chiller)
         End If

         ' sets compressor control visibility
         If Val(Me.Txt_circuit_per_unit.Text) > 1 Then
            Me.txtNumFans2.Visible = True
            Me.txtNumCompressors2.Visible = True
            Me.txtCompressor2.Visible = True
         Else
            Me.txtNumFans2.Visible = False
            Me.txtNumCompressors2.Visible = False
            Me.txtCompressor2.Visible = False
         End If

         ' sets circuit text
         If CInt(Me.Txt_circuit_per_unit.Text) = 4 Then
            Me.radCircuit1.Text = "Circuit 1 and 3"
            Me.radCircuit2.Text = "Circuit 2 and 4"
            Me.lblCircuit1.Text = "Circuit 1 and 3"
            Me.lblCircuit2.Text = "Circuit 2 and 4"
         Else
            Me.radCircuit1.Text = "Circuit 1"
            Me.radCircuit2.Text = "Circuit 2"
            Me.lblCircuit1.Text = "Circuit 1"
            Me.lblCircuit2.Text = "Circuit 2"
         End If

         Me.Set_Fan_Watts()

         Me.txt_model.Text = Me.grab_model()
         
         set_enabled_on_acme_releated_controls(enabled:=true)
      End If

      jot("end model changed")
      
      Me.Cursor = Cursors.Arrow
   End Sub


   Private Sub cboFluid_SelectedIndexChanged() _
   Handles cboFluid.SelectedIndexChanged
      If loaded Then
            ''grd_results.Visible = False
            DataGridView2.Visible = False
            TextBox1.Text = ""

         If cboFluid.SelectedItem = "Water" Then
            cbo_glycol.Visible = False
            txtPercentGlycol.Enabled = False
            txtPercentGlycol.Text = "0"
            btnGlycolChart.Visible = False
         Else
            cbo_glycol.Visible = True
            txtPercentGlycol.Enabled = True
            txtPercentGlycol.Text = "20"
            btnGlycolChart.Visible = True
         End If
         calculate_specific_heat_and_gravity()
         calcFreezePoint(grabFluid, grabGlycolPerc)
      End If
   End Sub


   private sub cbo_glycol_SelectedIndexChanged() _
   Handles cbo_glycol.SelectedIndexChanged
      if loaded Then
            set_enabled_on_acme_releated_controls(enabled:=False)
            ''grd_results.Visible = False
            DataGridView2.Visible = False
            TextBox1.Text() = ""
         calculate_specific_heat_and_gravity()
         set_enabled_on_acme_releated_controls(enabled:=true)
      end if
   end sub


   Private Sub cboRefrigerant_SelectedIndexChanged() _
   Handles cboRefrigerant.SelectedIndexChanged
      If loaded And Me.grab_model() <> "Choose" Then
            ''Me.grd_results.Visible = False
            Me.DataGridView2.Visible = False
            Me.TextBox1.Text = ""
         
         Dim chiller = Business.Agents.ChillerAgent.RetrieveChiller(Me.grab_model())
         chiller.circuit_1.refrigerant = grabRefrigerant.Abbreviation
         fill_compressors(chiller)

         Dim refrigerant As String = Me.GrabRefrigerant.Abbreviation
         Select Case refrigerant
            Case "407c", "407cH", "407cM", "407cL"
               Me.btn_alternate_evaporators.Visible = False
               Me.cbo_evaporators.Visible = False
            Case Else
               Me.btn_alternate_evaporators.Visible = True
               Me.cbo_evaporators.Visible = True
         End Select
      End If
   End Sub


   Private Sub cboHertz_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles cboHertz.SelectedIndexChanged
      If Me.loaded Then
            ''grd_results.Visible = False
            DataGridView2.Visible = False

            Me.TextBox1.Text = ""

         Dim selectedFanFileName As String = Me.GrabFan.FileName

         Dim SWITCHING_FAN As String

         ' sets fan file name
         ' shows / hides 380 volts text
         If cboHertz.SelectedItem = "60" Then
            lbl_Volts.Visible = False
            lbl_Volts1.Visible = False

            If selectedFanFileName = "LAU2429.950" Then
               SWITCHING_FAN = "LAU2429"
            ElseIf selectedFanFileName = "BR28IN.950" Then
               SWITCHING_FAN = "BR28IN"
            ElseIf selectedFanFileName = "BR28INHA.950" Then
               SWITCHING_FAN = "BR28IN.HA"
            ElseIf selectedFanFileName = "BR28IN.950" Then
               SWITCHING_FAN = "LAU2840.850"    'REP    (BR28IN.708 HOUSE VERSION)
            ElseIf selectedFanFileName = "S42832.950" Then
               SWITCHING_FAN = "S42832"
            End If
         Else
            If selectedFanFileName = "LAU2429" Then
               SWITCHING_FAN = "LAU2429.950"
            ElseIf selectedFanFileName = "BR28IN" Then
               SWITCHING_FAN = "BR28IN.950"
            ElseIf selectedFanFileName = "BR28IN.HA" Then
               SWITCHING_FAN = "BR28INHA.950"
            ElseIf selectedFanFileName = "LAU2840850" Then
               SWITCHING_FAN = "BR28IN.950"    'REP    (BR28IN.708 HOUSE VERSION)
            ElseIf selectedFanFileName = "S42832" Then
               SWITCHING_FAN = "S42832.950"
            End If

            lbl_Volts.Visible = True
            lbl_Volts1.Visible = True
         End If

         ' selects fan
         Me.cboFan.SelectedIndex = Me.indexOfFanFileName(Me.cboFan, SWITCHING_FAN)

         ' sets fan watts textbox
         Me.Set_Fan_Watts()
      End If
   End Sub


   Private Sub cboSystem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles cboSystem.SelectedIndexChanged
        ''grd_results.Visible = False
        DataGridView2.Visible = False
        TextBox1.Text() = ""
   End Sub


   Private Sub radCircuit1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles radCircuit1.CheckedChanged
      If radCircuit1.Checked Then
         Running_Circuit_no = 1
         Me.lboCompressors1.Enabled = True
         Me.lboCompressors2.Enabled = False
      End If
   End Sub


   Private Sub radCircuit2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles radCircuit2.CheckedChanged
      If radCircuit2.Checked Then
         Running_Circuit_no = 2
         Me.lboCompressors1.Enabled = False
         Me.lboCompressors2.Enabled = True
      End If
   End Sub


   Private Sub lboCompressors1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles lboCompressors1.SelectedIndexChanged
        ''grd_results.Visible = False
        DataGridView2.Visible = False
        Me.TextBox1.Text = ""
      If radCircuit1.Checked = True Then
         Running_Circuit_no = 1
         Me.txtCompressor1.Text = lboCompressors1.SelectedItem.Model
      End If
   End Sub


   Private Sub lboCompressors2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles lboCompressors2.SelectedIndexChanged
        ''grd_results.Visible = False
        DataGridView2.Visible = False
        Me.TextBox1.Text = ""
      If radCircuit2.Checked = True Then
         Running_Circuit_no = 2
         Me.txtCompressor2.Text = lboCompressors2.SelectedItem.Model
      End If
   End Sub


   Private Sub txtPercentGlycol_TextChanged() _
   Handles txtPercentGlycol.TextChanged
      If loaded Then 'was executing before loader() executed
         calculate_specific_heat_and_gravity()
      End If
   End Sub


   private sub cbo_evaporators_SelectedIndexChanged() _
   Handles cbo_evaporators.SelectedIndexChanged
      set_enabled_on_acme_releated_controls(enabled:=false)
      cbo_evaporators.enabled = true
   
      dim model = grab_evaporator_model_from_combobox()
      jot("uncommitted evaporator change: " & model)
      
      evaporator_changed_schedule.change(model)
      
      if grab_evaporator_model_from_combobox = "Choose" then _
         set_enabled_on_acme_releated_controls(enabled:=true)
      cbo_evaporators.focus()
   end sub
   
   private sub handle_evaporator_changed()
      set_enabled_on_acme_releated_controls(enabled:=false)

        ''Me.grd_results.Visible = False
        Me.DataGridView2.Visible = False
        Me.TextBox1.Text = ""

      dim evaporator_model = grab_evaporator_model_from_combobox()

      if evaporator_model = "Choose" then _
         set_enabled_on_acme_releated_controls(enabled:=true) : exit sub
   
      dim evaporator = Business.Agents.ChillerAgent.RetrieveChillerEvaporator(evaporator_model)
      txt_evaporator.Text = evaporator_model '.Item("EvaporatorPartNum")
      ToolTip1.SetToolTip(txt_evaporator, evaporator.ToString)

      showEvaporatorDataAtApproaches()
      
      set_enabled_on_acme_releated_controls(enabled:=true)
   end sub
   
   private function grab_evaporator_model_from_combobox() as string
      return cbo_evaporators.SelectedItem.ToString()
   end function

   Private Sub Cbo_coil_file_name_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles cboCoilFileName1.SelectedIndexChanged
      Me.change_coil_desc()
   End Sub

   Private Sub cboCoilFileName2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles cboCoilFileName2.SelectedIndexChanged
      Me.change_coil_desc()
   End Sub


   Private Sub cboFanFileName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles cboFan.SelectedIndexChanged
        ''Me.grd_results.Visible = False
        Me.DataGridView2.Visible = False
        Me.TextBox1.Text = ""
      If Me.loaded Then
         If Me.GrabFan.FileName = "CFM Per Fan >>>" Then
            Me.txtCfmOverRide.Visible = True
            Me.txtFanWatts1.ReadOnly = False
         Else
            Me.txtCfmOverRide.Visible = False
            Me.txtFanWatts1.ReadOnly = True
         End If

         Me.Set_Fan_Watts()
      End If
   End Sub


   private sub btn_alternate_evaporators_click() _
   Handles btn_alternate_evaporators.Click
      handle_alternate_evaporators_requested()
   end sub
   
   private sub handle_alternate_evaporators_requested()
      if chiller_model_is_not_selected then
         warn("Select a chiller model.")
         cbo_models.focus()
         exit sub
      end if
      
      jot("before getting evaporators")
      set_enabled_on_acme_releated_controls(enabled:=false) ' prevents acme dll from crashing
      
      cal_Tons_GPM()
      listAlternateEvaporators()
      cbo_evaporators.Visible = True
      
      set_enabled_on_acme_releated_controls(enabled:=true)
      jot("after getting_evaporators")
   end sub
   
   private sub set_enabled_on_acme_releated_controls(enabled as boolean)
      cbo_models.enabled      = enabled
      cbo_series.enabled      = enabled
      cbo_glycol.enabled      = enabled
      cbo_evaporators.enabled = enabled
      btn_calculate_page.enabled        = enabled
      btn_alternate_evaporators.enabled = enabled
      btn_go_to_pricing.enabled         = enabled
      btn_create_report.enabled         = enabled
   end sub

   private function chiller_model_is_not_selected as boolean
      return (cbo_models.selectedIndex < 0) orElse (cbo_models.SelectedItem.ToString = "Choose")
   end function

   Private Sub btnGlycolChart_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles btnGlycolChart.Click
      Dim form As New Windows.Forms.Form
        ''Dim myGrid As New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Dim glycolTable As DataTable
      Dim glycol As String
      Dim formWidth, formHeight As Integer

      ' sets selected glycol (ethylene or propylene)
      glycol = Me.cbo_glycol.SelectedItem.ToString

      ' retrieves glycol table of recommendations
      If glycol = "Ethylene" Then
         glycolTable = DataAccess.Chillers.ChillerDataAccess.RetrieveEthylene()
      ElseIf glycol = "Propylene" Then
         glycolTable = DataAccess.Chillers.ChillerDataAccess.RetrievePropylene()
      Else
         Ui.MessageBox.Show("The selected fluid is water; the fluid must be a glycol in order to chart recommendations.", _
            MessageBoxIcon.Information)
         Exit Sub
      End If

        ' adds grid to form
        ' Note: need to add grid to form before setting datasource
        form.Controls.Add(DataGridView1)
        ' sets datagrid's data source
        DataGridView1.DataSource = glycolTable

        ' sets column width and captions
        ''  With myGrid.Splits(0)
        ''   .ColumnCaptionHeight = 36

        ''   .DisplayColumns(GlycolNames.LeavingFluidTemperature).Width = 100
        ''   .DisplayColumns(GlycolNames.LeavingFluidTemperature).DataColumn.Caption = "Leaving Fluid Temperature [°F]"
        ''   .DisplayColumns(GlycolNames.FreezingPoint).Width = 80
        ''   .DisplayColumns(GlycolNames.FreezingPoint).DataColumn.Caption = "Freezing Point [°F]"
        ''   .DisplayColumns(GlycolNames.RecommendedGlycolPercentage).Width = 85
        ''   .DisplayColumns(GlycolNames.RecommendedGlycolPercentage).DataColumn.Caption = "Recommended Glycol [%]"
        ''   .DisplayColumns(GlycolNames.RecommendedMinSuctionTemperature).Width = 140
        ''   .DisplayColumns(GlycolNames.RecommendedMinSuctionTemperature).DataColumn.Caption = _
        ''      "Recommended Minimum Suction Temperature [°F]"
        ''End With
        DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        ''myGrid.Caption = glycol & " Table"

        ' sets grid style to pre-defined style

        ' initializes form width to outer border width + vertical scroll bar width
        ''  formWidth = 5 * 2 + myGrid.VScrollBar.Width
        ''For i As Integer = 0 To myGrid.Splits(0).DisplayColumns.Count - 1
        ''   ' calculates form width based on column width and inner borders
        ''   formWidth += myGrid.Splits(0).DisplayColumns(i).Width + 1
        ''Next

        ''' calculates for height (just estimate)
        ''formHeight = 34 + myGrid.CaptionHeight + myGrid.Splits(0).ColumnCaptionHeight
        ''For i As Integer = 0 To myGrid.Splits(0).Rows.Count - 1
        ''   formHeight += myGrid.RowHeight + 1
        ''Next

        form.Width = formWidth
      form.Height = formHeight
      form.Text = glycol & " Recommendations"
      form.MdiParent = Me.MdiParent
      form.Show()
   End Sub


   Private Sub txtAltitude1_TextChanged() Handles txtAltitude1.TextChanged
      txtAltitude2.Text = txtAltitude1.Text
   End Sub
   
   Private Sub txtAltitude1_Leave() Handles txtAltitude1.Leave
      If txtAltitude1.Text = "" Then Exit Sub
      
      Dim highAltitude = Business.Intelligence.FanIntel.HighAltitude
      If txtAltitude1.Text >= highAltitude Then
         inform("A high altitude fan is recommend for altitudes above " & highAltitude & " feet.")
      End If
   End Sub


   Private Sub txtFanWatts1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFanWatts1.TextChanged
      txtFanWatts2.Text = txtFanWatts1.Text
   End Sub

   Private Sub TXT_ERROR_1_BOX_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles TXT_ERROR_1_BOX.TextChanged
      lblError.Text = TXT_ERROR_1_BOX.Text
      ToolTip1.SetToolTip(lblError, TXT_ERROR_1_BOX.Text)
   End Sub

   'TODO: consolidate error controls into one
   Private Sub lblError_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles lblError.TextChanged
      If lblError.Text = "" Then
         picError.Visible = False
      Else
         picError.Visible = True
      End If
   End Sub


   private sub btn_calculate_page_click() _
   Handles btn_calculate_page.click
      if not chillerVMgr.Validate() then
         warn(chillerVMgr.ErrorMessagesSummary)
         exit sub
      end if

      cursor = cursors.waitCursor
      
      try
         jot("before calculate page")
         set_enabled_on_acme_releated_controls(enabled:=false)
         start_calculations()
      catch ex as exception
         alert("The page cannot be calculated. " & ex.message)
      finally
         set_enabled_on_acme_releated_controls(enabled:=true)
         jot("after calculate page")
      end try

      cursor = cursors.default
      panGrid.focus()
   end sub

   private sub set_initial_control_visibility(visible as boolean)
      static shown as boolean = false
      if shown then exit sub
      
      for each panel as panel in pan_main.controls
         panel.visible = visible
      next
      
      pan_footer.visible = visible
      lbl_select_model.visible = not visible
      pan_model.visible = true
      
      if visible then shown = true
   end sub

   private sub btn_create_report_click() _
   handles btn_create_report.click
      cursor = cursors.waitCursor

      try
         set_enabled_on_acme_releated_controls(enabled:=false)
      
         start_calculations()
            ''If grd_results.visible Then
            ''    show_word_report()
            ''Else
            If DataGridView2.Visible Then
                show_word_report()
            Else
                TXT_ERROR_1_BOX.Text &= Chr(10) & Chr(13) & "Report could not be created."
         end if
      catch ex as exception
         alert("The report cannot be viewed. " & ex.message)
      finally
         set_enabled_on_acme_releated_controls(enabled:=true)
      end try
      
      cursor = cursors.default
   end Sub


    ''Private Sub mnuChillerRepPrint_Click(sender As Object, e As EventArgs) Handles printMenuItem.Click
    ''   Dim doc As New C1.C1PrintDocument.C1PrintDocument
    ''   'controls font and other styles on printed page
    ''   Dim printStyle As New C1.C1PrintDocument.C1DocStyle(doc)  'used in rendering spacer image
    ''   printStyle.Font = New Font("Arial", 10, FontStyle.Regular)
    ''   'the page settings from frmC1PrintPreview.vb are not applied
    ''   'page settings must be set in code in order to be applied
    ''   doc.PageSettings.Margins.Top = 50
    ''   doc.PageSettings.Margins.Bottom = 50

    ''   doc.DefaultUnit = C1.C1PrintDocument.UnitTypeEnum.Mm
    ''   'header
    ''   doc.PageHeader.Height = 8
    ''   doc.PageHeader.RenderText.Style = printStyle
    ''   doc.PageHeader.RenderText.Style.TextAlignHorz = C1.C1PrintDocument.AlignHorzEnum.Center
    ''   doc.PageHeader.RenderText.Style.TextAlignVert = C1.C1PrintDocument.AlignVertEnum.Top
    ''   doc.PageHeader.RenderText.Text = Me.Text
    ''   'footer
    ''   doc.PageFooter.Height = 8
    ''   doc.PageFooter.RenderText.Style = printStyle
    ''   doc.PageFooter.RenderText.Style.TextAlignHorz = C1.C1PrintDocument.AlignHorzEnum.Right
    ''   doc.PageFooter.RenderText.Style.TextAlignVert = C1.C1PrintDocument.AlignVertEnum.Bottom
    ''   doc.PageFooter.RenderText.Text = "Page [@@PageNo@@] of [@@PageCount@@]"

    ''   doc.StartDoc() 'start rendering
    ''   doc.RenderBlockControlImage(Me.pan_model)
    ''   doc.RenderBlockControlImage(Me.pan_rating_criteria)
    ''   doc.RenderBlockControlImage(Me.panCriteriaControls)
    ''   doc.RenderBlockControlImage(Me.pan_compressor_header)
    ''   doc.RenderBlockControlImage(Me.panCompressorControls)
    ''   doc.RenderBlockControlImage(Me.pan_condenser_header)
    ''   doc.RenderBlockControlImage(Me.panCondenserControls)
    ''   doc.RenderBlockControlImage(Me.pan_evaporator_header)
    ''   doc.RenderBlockControlImage(Me.panEvaporatorControls)

    ''   'image is used to fill space at the end of a page
    ''   'implemented to function as a page return
    ''   Dim whiteImage As Image
    ''   whiteImage = Image.FromFile(AppInfo.AppFolderPath & "Images\whitebox.gif")
    ''   doc.RenderBlockImage(whiteImage, 3, doc.AvailableBlockFlowHeight, printStyle)
    ''   'page return
    ''   doc.RenderBlockControlImage(Me.lblLimits)
    ''   doc.RenderBlockControlSmart(Me.grd_results)
    ''   doc.RenderBlockControlImage(Me.pan_footer)

    ''   'page return		
    ''   'doc.RenderBlockImage(whiteImage, 3, doc.AvailableBlockFlowHeight, printStyle)

    ''   doc.EndDoc() 'stop rendering

    ''   Dim formPreview As New C1PrintPreviewForm 'create instance form to preview before printing
    ''   formPreview.C1PrintPreview1.Document = doc 'set the form's document to the document just created
    ''   formPreview.ShowDialog() 'can't have mdiparent otherwise error occurs
    ''   formPreview.Dispose()
    ''End Sub

    Private Sub saveMenuItem_Click() _
   Handles saveMenuItem.Click
      SaveControls()
   End Sub

   Private Sub convertToEquipmentMenuItem_Click() _
   Handles convertToEquipmentMenuItem.Click
      SaveControls(GenerateEquipment:=True)
   End Sub

   Private Sub saveAsMenuItem_Click() _
   Handles saveAsMenuItem.Click
      SaveControls(SaveAsNew:=True)
   End Sub

   Private Sub saveAsRevisionMenuItem_Click() _
   Handles saveAsRevisionMenuItem.Click
      SaveControls(SaveAsRevision:=True)
   End Sub

   private sub btn_go_to_pricing_click() Handles btn_go_to_pricing.click
      set_enabled_on_acme_releated_controls(enabled:=false)
      SaveControls(SaveAsRevision:=False, SaveAsNew:=False, FormClosing:=False, GenerateEquipment:=True)
      set_enabled_on_acme_releated_controls(enabled:=true)
   end sub
   
   
   
   Private Sub calculate_specific_heat_and_gravity()
      Dim mapping = New evaporator_mapper()
      Dim media                     = grabFluid()
      Dim fluid                     = mapping.map(media)
      Dim glycolPercentage          = grabGlycolPerc()
      Dim enteringFluidTemperature  = LeavingFluidTemp + GrabTemperatureRange
      Dim leavingFluidTemperature   = LeavingFluidTemp
      
      Dim specific = service.calculate_specific_heat_and_gravity(fluid, glycolPercentage, enteringFluidTemperature, leavingFluidTemperature)

      txtSpecificHeat.Text    = specific.heat.ToString("0.####")
      txtSpecificGravity.Text = specific.gravity.ToString("0.####")
   End Sub
   
   Private Function grabEnteringFluidTemperature() As Double
      Return CDbl(LeavingFluidTemp + GrabTemperatureRange)
   End Function
   
   Private Function grabSpec() As evaporator_spec
      Dim additionalEvaporatorLength = 6
      Dim model = cbo_models.SelectedItem

      'increases length of evaporators that are available to reps from 6 to 13
      If model Like "*SM*" _
      Or model Like "*CM*" _
      Or model Like "*SS1*" _
      Or model Like "*SD1*" _
      Or model Like "*SD2*" _
      Or model Like "*CD100*" _
      Or model Like "*CD110*" _
      Or model Like "*CD120*" Then
         additionalEvaporatorLength = 13
      End If
      Dim evaporatorLength = CDbl(txt_Evap_Length.Text)
      Dim maxLength        = additionalEvaporatorLength + evaporatorLength
      Dim numCircuits      = CInt(Txt_circuit_per_unit.Text)
      
      Dim mapping = New evaporator_mapper()
      Dim spec As evaporator_spec
      spec.refrigerant     = mapping.map(GrabRefrigerant.Refrigerant)
      spec.fluid           = mapping.map(grabFluid())
      spec.glycol_percentage= grabGlycolPerc()
      spec.num_circuits     = numCircuits
      spec.entering_fluid_temp  = grabEnteringFluidTemperature()
      spec.leaving_fluid_temp   = LeavingFluidTemp
      spec.evaporating_temp    = GrabMinSuctionTemperature()
      spec.length          = maxLength
      spec.authorization   = 3
      
      Return spec
   End Function
   
   Private Sub listAlternateEvaporators()
      Dim spec  = grabSpec()
      Dim svc   = New evaporator_service_factory().create()
      
      dim evaps as list(of evaporator)
      if user.is_employee
         evaps = svc.get_alternate_evaporators(spec)
      else
         evaps = svc.get_alternate_evaporators_for_rep(spec, txt_evaporator.text)
      end if
      
      Dim evaporatorPartNums = New List(Of String)
      evaporatorPartNums.Add("Choose")
      For Each evap In evaps
         evaporatorPartNums.Add(evap.evaporator_part_number)
      Next
      cbo_evaporators.DataSource = evaporatorPartNums
   End Sub
   
   Private Sub showEvaporatorDataAtApproaches()
      Dim evaporatorPartNum = txt_evaporator.Text
      Dim spec = grabSpec()
      Dim svc = New evaporator_service_factory().create()
      Dim range = svc.get_approach_range(evaporatorPartNum, spec)
      Dim numCircuits = Txt_circuit_per_unit.Text
      
      For Each evap In range
         Dim controlName = "txt" & evap.approach & "Deg"
         If numCircuits=4
            hid_panEvaporator.Controls(controlName).Text = evap.capacity '/ 2
         Else
            hid_panEvaporator.Controls(controlName).Text = evap.capacity '/ numCircuits
         End If
         Dim description = "Fluid PD = " & Round(evap.fluid_pressure_drop, 2) & "   GPM = " & Round(evap.fluid_flow, 2)
         ToolTip1.SetToolTip(hid_panEvaporator.Controls(controlName), description)
         
         controlName = "txt" & evap.approach
         hid_panEvaporator.Controls(controlName).Text = description
         
         PD_GPM(evap.approach, 1) = Round(evap.fluid_pressure_drop, 2)
         PD_GPM(evap.approach, 2) = Round(evap.fluid_flow, 2)
      Next
   End Sub
   
End Class
'7023
