Imports CrEngine = CrystalDecisions.CrystalReports.Engine
Imports CrShared = CrystalDecisions.Shared
Imports AppUsage = Rae.RaeSolutions.Diagnostics.UsageLog.ApplicationUsageLogger
Imports GlycolNames = Rae.RaeSolutions.DataAccess.Chillers.GlycolColumnNames
Imports BCI = Rae.RaeSolutions.Business.Intelligence.Chillers
Imports Microsoft.VisualBasic
Imports Forms = System.Windows.Forms
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.Solutions.Chillers
Imports Rae.Solutions.Chillers.Chiller
Imports Rae.Validation
Imports System.Data
Imports System.Collections.Generic
Imports System.Math
Imports Rae.Math.Calculate



Public Class frmEvapCooledRep
   Inherits BaseChillerForm
   Public ProcessDeleted As Boolean

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
   Friend WithEvents lblRatingCriteria As System.Windows.Forms.Label
   Friend WithEvents panTop As System.Windows.Forms.Panel
   Friend WithEvents panMain As System.Windows.Forms.Panel
   Friend WithEvents TXT_ERROR_1_BOX As System.Windows.Forms.TextBox
   Friend WithEvents cboHertz As System.Windows.Forms.ComboBox
   Friend WithEvents lbl_Volts As System.Windows.Forms.Label
   Friend WithEvents lbl_Volts1 As System.Windows.Forms.Label
   Friend WithEvents lblCompressor As System.Windows.Forms.Label
   Friend WithEvents panCompressorCircuits As System.Windows.Forms.Panel
   Friend WithEvents lblCompressor1 As System.Windows.Forms.Label
   Friend WithEvents lblCompressor2 As System.Windows.Forms.Label
   Friend WithEvents lblCondenser As System.Windows.Forms.Label
   Friend WithEvents lblCondenser1 As System.Windows.Forms.Label
   Friend WithEvents lblCondenser2 As System.Windows.Forms.Label
   Friend WithEvents panEvaporatorHeader As System.Windows.Forms.Panel
   Friend WithEvents panEvaporatorBody As System.Windows.Forms.Panel
   Friend WithEvents lblEvaporatorHeader As System.Windows.Forms.Label
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
   Friend WithEvents CboFpi As System.Windows.Forms.ComboBox
   Friend WithEvents btnEvaporatorVisibility As System.Windows.Forms.Button
   Friend WithEvents panCondenserHeader As System.Windows.Forms.Panel
   Friend WithEvents panCompressorHeader As System.Windows.Forms.Panel
   Friend WithEvents panCriteriaHeader As System.Windows.Forms.Panel
   Friend WithEvents panCriteriaBody As System.Windows.Forms.Panel
   Friend WithEvents panCondenserBody As System.Windows.Forms.Panel
   Friend WithEvents panCompressorBody As System.Windows.Forms.Panel
   Friend WithEvents btnCondenserVisibility As System.Windows.Forms.Button
   Friend WithEvents btnCompressorVisibility As System.Windows.Forms.Button
   Friend WithEvents btnCriteriaVisibility As System.Windows.Forms.Button
   Friend WithEvents picError As System.Windows.Forms.PictureBox
   Friend WithEvents picCompressorVisibility As System.Windows.Forms.PictureBox
   Friend WithEvents picCriteriaVisibility As System.Windows.Forms.PictureBox
   Friend WithEvents picCondenserVisibility As System.Windows.Forms.PictureBox
   Friend WithEvents picEvaporatorVisibility As System.Windows.Forms.PictureBox
   Friend WithEvents panFooter As System.Windows.Forms.Panel
   Friend WithEvents lblError As System.Windows.Forms.Label
   Friend WithEvents panFooterButton As System.Windows.Forms.Panel
   Friend WithEvents btnCalculatePage As System.Windows.Forms.Button
   Friend WithEvents panCondenserControls As System.Windows.Forms.Panel
   Friend WithEvents panCompressorControls As System.Windows.Forms.Panel
   Friend WithEvents panCriteriaControls As System.Windows.Forms.Panel
   Friend WithEvents panEvaporatorControls As System.Windows.Forms.Panel
   Friend WithEvents panGrid As System.Windows.Forms.Panel
   Friend WithEvents btnCreateReport As System.Windows.Forms.Button
   Friend WithEvents cboHidValues As System.Windows.Forms.ComboBox
   Friend WithEvents lblNumFans2 As System.Windows.Forms.Label
   Friend WithEvents lblFanWatts2 As System.Windows.Forms.Label
   Friend WithEvents btnGlycolChart As System.Windows.Forms.Button
   Friend WithEvents lblSeries As System.Windows.Forms.Label
   Friend WithEvents cboSeries As System.Windows.Forms.ComboBox
   Friend WithEvents cboModels As System.Windows.Forms.ComboBox
   Friend WithEvents lblCondenserFanValue2 As System.Windows.Forms.Label
   Friend WithEvents btnAlternateEvaporators As System.Windows.Forms.Button
   Friend WithEvents txtModelChange As System.Windows.Forms.TextBox
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
   Friend WithEvents cboGlycol As System.Windows.Forms.ComboBox
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
   Friend WithEvents cboFanFileName As System.Windows.Forms.ComboBox
   Friend WithEvents txtFinLength1 As System.Windows.Forms.TextBox
   Friend WithEvents txtFanWatts2 As System.Windows.Forms.TextBox
   Friend WithEvents txtFanWatts1 As System.Windows.Forms.TextBox
   Friend WithEvents txtAltitude1 As System.Windows.Forms.TextBox
   Friend WithEvents txtCapacity As System.Windows.Forms.TextBox
   Friend WithEvents cboFoulingFactor As System.Windows.Forms.ComboBox
   Friend WithEvents lblEvaporator As System.Windows.Forms.Label
   Friend WithEvents cboEvaporators As System.Windows.Forms.ComboBox
   Friend WithEvents chkCatalog As System.Windows.Forms.CheckBox
   Friend WithEvents txtEvaporator As System.Windows.Forms.TextBox
   Friend WithEvents lblFoulingFactor As System.Windows.Forms.Label
   Friend WithEvents radCapacityTons As System.Windows.Forms.RadioButton
   Friend WithEvents radCapacityGpm As System.Windows.Forms.RadioButton
   Friend WithEvents lblLimits As System.Windows.Forms.Label
   Friend WithEvents grdResults As C1.Win.C1TrueDBGrid.C1TrueDBGrid
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
   Friend WithEvents mnuChillerRepPrint As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents err As System.Windows.Forms.ErrorProvider
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEvapCooledRep))
      Me.cboModels = New System.Windows.Forms.ComboBox
      Me.txtModelChange = New System.Windows.Forms.TextBox
      Me.lblRatingCriteria = New System.Windows.Forms.Label
      Me.panTop = New System.Windows.Forms.Panel
      Me.cboSeries = New System.Windows.Forms.ComboBox
      Me.lblSeries = New System.Windows.Forms.Label
      Me.lblModel = New System.Windows.Forms.Label
      Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
      Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuChillerRepPrint = New System.Windows.Forms.ToolStripMenuItem
      Me.TXT_ERROR_1_BOX = New System.Windows.Forms.TextBox
      Me.panCriteriaBody = New System.Windows.Forms.Panel
      Me.hid_panCriteria = New System.Windows.Forms.Panel
      Me.Txtliqcool = New System.Windows.Forms.TextBox
      Me.cboVolts = New System.Windows.Forms.ComboBox
      Me.panCriteriaControls = New System.Windows.Forms.Panel
      Me.lblTempRangeF = New System.Windows.Forms.Label
      Me.btnGlycolChart = New System.Windows.Forms.Button
      Me.txtFreezingPoint = New System.Windows.Forms.TextBox
      Me.lblFreezingPoint = New System.Windows.Forms.Label
      Me.txtSpecificGravity = New System.Windows.Forms.TextBox
      Me.txtSpecificHeat = New System.Windows.Forms.TextBox
      Me.lblSpecificGravity = New System.Windows.Forms.Label
      Me.lblCoolingMediaPercent = New System.Windows.Forms.Label
      Me.lblSpecificHeat = New System.Windows.Forms.Label
      Me.txtPercentGlycol = New System.Windows.Forms.TextBox
      Me.lblCoolingMedia = New System.Windows.Forms.Label
      Me.lblFluid = New System.Windows.Forms.Label
      Me.cboHertz = New System.Windows.Forms.ComboBox
      Me.lblLeavingFluidTemp = New System.Windows.Forms.Label
      Me.lblTempRange = New System.Windows.Forms.Label
      Me.lblAmbientTemp = New System.Windows.Forms.Label
      Me.txtMinSuctionTemp = New System.Windows.Forms.TextBox
      Me.lblFreezingPointPercentF = New System.Windows.Forms.Label
      Me.txtLeavingFluidTemp = New System.Windows.Forms.TextBox
      Me.lblRefrigerant = New System.Windows.Forms.Label
      Me.txtAmbientTemp = New System.Windows.Forms.TextBox
      Me.lblSystem = New System.Windows.Forms.Label
      Me.cboTempRange = New System.Windows.Forms.ComboBox
      Me.cboRefrigerant = New System.Windows.Forms.ComboBox
      Me.cboGlycol = New System.Windows.Forms.ComboBox
      Me.lblHertz = New System.Windows.Forms.Label
      Me.lblMinSuctionTempF = New System.Windows.Forms.Label
      Me.lblLeavingFluidTempF = New System.Windows.Forms.Label
      Me.lblMinSuctionTemp = New System.Windows.Forms.Label
      Me.lblAmbientTempF = New System.Windows.Forms.Label
      Me.cboSystem = New System.Windows.Forms.ComboBox
      Me.cboFluid = New System.Windows.Forms.ComboBox
      Me.lbl_Volts1 = New System.Windows.Forms.Label
      Me.lbl_Volts = New System.Windows.Forms.Label
      Me.hid_lblApproach = New System.Windows.Forms.Label
      Me.hid_txtApproach = New System.Windows.Forms.TextBox
      Me.panMain = New System.Windows.Forms.Panel
      Me.panGrid = New System.Windows.Forms.Panel
      Me.grdResults = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
      Me.hid_panResults = New System.Windows.Forms.Panel
      Me.Txt10Deg_1 = New System.Windows.Forms.TextBox
      Me.Txt8Deg_2 = New System.Windows.Forms.TextBox
      Me.Txt_circuit_per_unit = New System.Windows.Forms.TextBox
      Me.TxtCondCap = New System.Windows.Forms.TextBox
      Me.Txt10Deg_2 = New System.Windows.Forms.TextBox
      Me.CboFpi = New System.Windows.Forms.ComboBox
      Me.TxtTonsSystemCap = New System.Windows.Forms.TextBox
      Me.txt_gpm = New System.Windows.Forms.TextBox
      Me.cboChiller11 = New System.Windows.Forms.ComboBox
      Me.txt_Evap_Length = New System.Windows.Forms.TextBox
      Me.Txt8Deg_1 = New System.Windows.Forms.TextBox
      Me.lblLimits = New System.Windows.Forms.Label
      Me.panEvaporatorBody = New System.Windows.Forms.Panel
      Me.panEvaporatorControls = New System.Windows.Forms.Panel
      Me.txtCapacity = New System.Windows.Forms.TextBox
      Me.btnAlternateEvaporators = New System.Windows.Forms.Button
      Me.cboFoulingFactor = New System.Windows.Forms.ComboBox
      Me.lblEvaporator = New System.Windows.Forms.Label
      Me.cboEvaporators = New System.Windows.Forms.ComboBox
      Me.chkCatalog = New System.Windows.Forms.CheckBox
      Me.txtEvaporator = New System.Windows.Forms.TextBox
      Me.lblFoulingFactor = New System.Windows.Forms.Label
      Me.Panel3 = New System.Windows.Forms.Panel
      Me.radCapacityTons = New System.Windows.Forms.RadioButton
      Me.radCapacityGpm = New System.Windows.Forms.RadioButton
      Me.hid_panEvaporator = New System.Windows.Forms.Panel
      Me.txt4Deg = New System.Windows.Forms.TextBox
      Me.txt9 = New System.Windows.Forms.TextBox
      Me.txt4 = New System.Windows.Forms.TextBox
      Me.txt11Deg = New System.Windows.Forms.TextBox
      Me.hid_panApproach = New System.Windows.Forms.Panel
      Me.rb10_12 = New System.Windows.Forms.RadioButton
      Me.rb9_11 = New System.Windows.Forms.RadioButton
      Me.rb8_10 = New System.Windows.Forms.RadioButton
      Me.rb7_9 = New System.Windows.Forms.RadioButton
      Me.rb6_8 = New System.Windows.Forms.RadioButton
      Me.rbOther_Approch = New System.Windows.Forms.RadioButton
      Me.txt7Deg = New System.Windows.Forms.TextBox
      Me.txt7 = New System.Windows.Forms.TextBox
      Me.txt5 = New System.Windows.Forms.TextBox
      Me.txt6Deg = New System.Windows.Forms.TextBox
      Me.txt10Deg = New System.Windows.Forms.TextBox
      Me.txt9Deg = New System.Windows.Forms.TextBox
      Me.txt5Deg = New System.Windows.Forms.TextBox
      Me.lblEvap4Degr = New System.Windows.Forms.Label
      Me.lblEvap5Degr = New System.Windows.Forms.Label
      Me.lblEvap7Degr = New System.Windows.Forms.Label
      Me.txt10 = New System.Windows.Forms.TextBox
      Me.txt12Deg = New System.Windows.Forms.TextBox
      Me.txt12 = New System.Windows.Forms.TextBox
      Me.txt11 = New System.Windows.Forms.TextBox
      Me.txt8Deg = New System.Windows.Forms.TextBox
      Me.txt8 = New System.Windows.Forms.TextBox
      Me.txt6 = New System.Windows.Forms.TextBox
      Me.lblEvap9Degr = New System.Windows.Forms.Label
      Me.lblEvap6Degr = New System.Windows.Forms.Label
      Me.lblEvap8Degr = New System.Windows.Forms.Label
      Me.lblEvap10Degr = New System.Windows.Forms.Label
      Me.lblEvap12Degree = New System.Windows.Forms.Label
      Me.lblEvap11Degr = New System.Windows.Forms.Label
      Me.TextBox1 = New System.Windows.Forms.TextBox
      Me.panEvaporatorHeader = New System.Windows.Forms.Panel
      Me.picEvaporatorVisibility = New System.Windows.Forms.PictureBox
      Me.btnEvaporatorVisibility = New System.Windows.Forms.Button
      Me.lblEvaporatorHeader = New System.Windows.Forms.Label
      Me.panCondenserBody = New System.Windows.Forms.Panel
      Me.hid_panCondenser = New System.Windows.Forms.Panel
      Me.DropDownList2 = New System.Windows.Forms.ComboBox
      Me.cboHidValues = New System.Windows.Forms.ComboBox
      Me.DropDownList3 = New System.Windows.Forms.ComboBox
      Me.cbo_Suction_line_loss = New System.Windows.Forms.ComboBox
      Me.txtCondenser_1 = New System.Windows.Forms.TextBox
      Me.TxtCondCap_1 = New System.Windows.Forms.TextBox
      Me.cbo_Discharge_line_loss = New System.Windows.Forms.ComboBox
      Me.TxtCondCap_2 = New System.Windows.Forms.TextBox
      Me.txtCondenser_2 = New System.Windows.Forms.TextBox
      Me.panCondenserControls = New System.Windows.Forms.Panel
      Me.txtCfmOverRide = New System.Windows.Forms.TextBox
      Me.lblCondenserFanValue2 = New System.Windows.Forms.Label
      Me.txtFinLength2 = New System.Windows.Forms.TextBox
      Me.txtNumFans1 = New System.Windows.Forms.TextBox
      Me.lblAltitude1 = New System.Windows.Forms.Label
      Me.lblFan = New System.Windows.Forms.Label
      Me.cboSubCooling2 = New System.Windows.Forms.ComboBox
      Me.lblNumFans1 = New System.Windows.Forms.Label
      Me.cboCoilFileName1 = New System.Windows.Forms.ComboBox
      Me.txtAltitude2 = New System.Windows.Forms.TextBox
      Me.txtSubCoolingPercent2 = New System.Windows.Forms.TextBox
      Me.cboFpi2 = New System.Windows.Forms.ComboBox
      Me.txtAltitude1 = New System.Windows.Forms.TextBox
      Me.txtFinHeight2 = New System.Windows.Forms.TextBox
      Me.txtNumFans2 = New System.Windows.Forms.TextBox
      Me.cboCoilFileName2 = New System.Windows.Forms.ComboBox
      Me.lblFinHeight1 = New System.Windows.Forms.Label
      Me.txtFinHeight1 = New System.Windows.Forms.TextBox
      Me.lblFinsPerInch1 = New System.Windows.Forms.Label
      Me.lblSubCooling1 = New System.Windows.Forms.Label
      Me.txtSubCoolingPercent1 = New System.Windows.Forms.TextBox
      Me.cboFpi1 = New System.Windows.Forms.ComboBox
      Me.lblFinLength1 = New System.Windows.Forms.Label
      Me.lblFinLength2 = New System.Windows.Forms.Label
      Me.lblSubCooling2 = New System.Windows.Forms.Label
      Me.txtNumCoils1 = New System.Windows.Forms.TextBox
      Me.lblNumFans2 = New System.Windows.Forms.Label
      Me.lblCondenser2 = New System.Windows.Forms.Label
      Me.lblNumCoils1 = New System.Windows.Forms.Label
      Me.lblCircuit2 = New System.Windows.Forms.Label
      Me.txtNumCoils2 = New System.Windows.Forms.TextBox
      Me.lblFinsPerInch2 = New System.Windows.Forms.Label
      Me.cboFanFileName = New System.Windows.Forms.ComboBox
      Me.lblNumCoils2 = New System.Windows.Forms.Label
      Me.cboSubCooling1 = New System.Windows.Forms.ComboBox
      Me.lblCondenser1 = New System.Windows.Forms.Label
      Me.lblCircuit1 = New System.Windows.Forms.Label
      Me.txtFinLength1 = New System.Windows.Forms.TextBox
      Me.lblFanWatts1 = New System.Windows.Forms.Label
      Me.txtFanWatts2 = New System.Windows.Forms.TextBox
      Me.txtFanWatts1 = New System.Windows.Forms.TextBox
      Me.lblAltitude2 = New System.Windows.Forms.Label
      Me.lblFinHeight2 = New System.Windows.Forms.Label
      Me.lblFanWatts2 = New System.Windows.Forms.Label
      Me.panCondenserHeader = New System.Windows.Forms.Panel
      Me.picCondenserVisibility = New System.Windows.Forms.PictureBox
      Me.btnCondenserVisibility = New System.Windows.Forms.Button
      Me.lblCondenser = New System.Windows.Forms.Label
      Me.panCompressorBody = New System.Windows.Forms.Panel
      Me.panCompressorControls = New System.Windows.Forms.Panel
      Me.gboCompressor1 = New System.Windows.Forms.GroupBox
      Me.txtNumCompressors1 = New System.Windows.Forms.TextBox
      Me.lblCompressor1 = New System.Windows.Forms.Label
      Me.lblNumCompressors1 = New System.Windows.Forms.Label
      Me.txtCompressor1 = New System.Windows.Forms.TextBox
      Me.lboCompressors1 = New System.Windows.Forms.ListBox
      Me.gboCompressor2 = New System.Windows.Forms.GroupBox
      Me.lblCompressor2 = New System.Windows.Forms.Label
      Me.txtCompressor2 = New System.Windows.Forms.TextBox
      Me.txtNumCompressors2 = New System.Windows.Forms.TextBox
      Me.lblNumCompressors2 = New System.Windows.Forms.Label
      Me.lboCompressors2 = New System.Windows.Forms.ListBox
      Me.panCompressorCircuits = New System.Windows.Forms.Panel
      Me.radCircuit1 = New System.Windows.Forms.RadioButton
      Me.radCircuit2 = New System.Windows.Forms.RadioButton
      Me.panCompressorHeader = New System.Windows.Forms.Panel
      Me.picCompressorVisibility = New System.Windows.Forms.PictureBox
      Me.btnCompressorVisibility = New System.Windows.Forms.Button
      Me.lblCompressor = New System.Windows.Forms.Label
      Me.panCriteriaHeader = New System.Windows.Forms.Panel
      Me.picCriteriaVisibility = New System.Windows.Forms.PictureBox
      Me.btnCriteriaVisibility = New System.Windows.Forms.Button
      Me.btnCreateReport = New System.Windows.Forms.Button
      Me.picError = New System.Windows.Forms.PictureBox
      Me.panFooter = New System.Windows.Forms.Panel
      Me.lblError = New System.Windows.Forms.Label
      Me.panFooterButton = New System.Windows.Forms.Panel
      Me.btnCalculatePage = New System.Windows.Forms.Button
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.err = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.panTop.SuspendLayout()
      Me.MenuStrip1.SuspendLayout()
      Me.panCriteriaBody.SuspendLayout()
      Me.hid_panCriteria.SuspendLayout()
      Me.panCriteriaControls.SuspendLayout()
      Me.panMain.SuspendLayout()
      Me.panGrid.SuspendLayout()
      CType(Me.grdResults, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.hid_panResults.SuspendLayout()
      Me.panEvaporatorBody.SuspendLayout()
      Me.panEvaporatorControls.SuspendLayout()
      Me.Panel3.SuspendLayout()
      Me.hid_panEvaporator.SuspendLayout()
      Me.hid_panApproach.SuspendLayout()
      Me.panEvaporatorHeader.SuspendLayout()
      CType(Me.picEvaporatorVisibility, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.panCondenserBody.SuspendLayout()
      Me.hid_panCondenser.SuspendLayout()
      Me.panCondenserControls.SuspendLayout()
      Me.panCondenserHeader.SuspendLayout()
      CType(Me.picCondenserVisibility, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.panCompressorBody.SuspendLayout()
      Me.panCompressorControls.SuspendLayout()
      Me.gboCompressor1.SuspendLayout()
      Me.gboCompressor2.SuspendLayout()
      Me.panCompressorCircuits.SuspendLayout()
      Me.panCompressorHeader.SuspendLayout()
      CType(Me.picCompressorVisibility, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.panCriteriaHeader.SuspendLayout()
      CType(Me.picCriteriaVisibility, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.picError, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.panFooter.SuspendLayout()
      Me.panFooterButton.SuspendLayout()
      CType(Me.err, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'cboModels
      '
      Me.cboModels.Location = New System.Drawing.Point(80, 40)
      Me.cboModels.MaxDropDownItems = 15
      Me.cboModels.Name = "cboModels"
      Me.cboModels.Size = New System.Drawing.Size(112, 21)
      Me.cboModels.TabIndex = 2
      '
      'txtModelChange
      '
      Me.txtModelChange.Location = New System.Drawing.Point(196, 40)
      Me.txtModelChange.Name = "txtModelChange"
      Me.txtModelChange.Size = New System.Drawing.Size(100, 21)
      Me.txtModelChange.TabIndex = 3
      '
      'lblRatingCriteria
      '
      Me.lblRatingCriteria.BackColor = System.Drawing.Color.Maroon
      Me.lblRatingCriteria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblRatingCriteria.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblRatingCriteria.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.lblRatingCriteria.Location = New System.Drawing.Point(8, 0)
      Me.lblRatingCriteria.Name = "lblRatingCriteria"
      Me.lblRatingCriteria.Size = New System.Drawing.Size(152, 22)
      Me.lblRatingCriteria.TabIndex = 2
      Me.lblRatingCriteria.Text = " Rating Criteria"
      Me.lblRatingCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'panTop
      '
      Me.panTop.Controls.Add(Me.cboSeries)
      Me.panTop.Controls.Add(Me.lblSeries)
      Me.panTop.Controls.Add(Me.lblModel)
      Me.panTop.Controls.Add(Me.txtModelChange)
      Me.panTop.Controls.Add(Me.cboModels)
      Me.panTop.Controls.Add(Me.MenuStrip1)
      Me.panTop.Dock = System.Windows.Forms.DockStyle.Top
      Me.panTop.Location = New System.Drawing.Point(0, 0)
      Me.panTop.Name = "panTop"
      Me.panTop.Size = New System.Drawing.Size(669, 68)
      Me.panTop.TabIndex = 1
      '
      'cboSeries
      '
      Me.cboSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboSeries.Items.AddRange(New Object() {"35A0", "35A1", "RECH"})
      Me.cboSeries.Location = New System.Drawing.Point(80, 12)
      Me.cboSeries.Name = "cboSeries"
      Me.cboSeries.Size = New System.Drawing.Size(112, 21)
      Me.cboSeries.TabIndex = 1
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
      Me.MenuStrip1.Size = New System.Drawing.Size(639, 24)
      Me.MenuStrip1.TabIndex = 6
      Me.MenuStrip1.Text = "MenuStrip1"
      Me.MenuStrip1.Visible = False
      '
      'mnuFile
      '
      Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuChillerRepPrint})
      Me.mnuFile.MergeAction = System.Windows.Forms.MergeAction.MatchOnly
      Me.mnuFile.Name = "mnuFile"
      Me.mnuFile.Size = New System.Drawing.Size(35, 20)
      Me.mnuFile.Text = "File"
      '
      'mnuChillerRepPrint
      '
      Me.mnuChillerRepPrint.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Print
      Me.mnuChillerRepPrint.Name = "mnuChillerRepPrint"
      Me.mnuChillerRepPrint.Size = New System.Drawing.Size(278, 22)
      Me.mnuChillerRepPrint.Text = "Print Evap Cooled Chiller Rating (Rep)..."
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
      'panCriteriaBody
      '
      Me.panCriteriaBody.Controls.Add(Me.hid_panCriteria)
      Me.panCriteriaBody.Controls.Add(Me.panCriteriaControls)
      Me.panCriteriaBody.Controls.Add(Me.hid_lblApproach)
      Me.panCriteriaBody.Controls.Add(Me.hid_txtApproach)
      Me.panCriteriaBody.Dock = System.Windows.Forms.DockStyle.Top
      Me.panCriteriaBody.Location = New System.Drawing.Point(0, 90)
      Me.panCriteriaBody.Name = "panCriteriaBody"
      Me.panCriteriaBody.Size = New System.Drawing.Size(669, 196)
      Me.panCriteriaBody.TabIndex = 2
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
      Me.panCriteriaControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
      Me.panCriteriaControls.Controls.Add(Me.cboGlycol)
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
      Me.txtAmbientTemp.Text = "75"
      '
      'lblSystem
      '
      Me.lblSystem.Location = New System.Drawing.Point(276, 152)
      Me.lblSystem.Name = "lblSystem"
      Me.lblSystem.Size = New System.Drawing.Size(80, 23)
      Me.lblSystem.TabIndex = 36
      Me.lblSystem.Text = "System"
      Me.lblSystem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      'cboGlycol
      '
      Me.cboGlycol.Items.AddRange(New Object() {"Ethylene", "Propylene"})
      Me.cboGlycol.Location = New System.Drawing.Point(112, 40)
      Me.cboGlycol.Name = "cboGlycol"
      Me.cboGlycol.Size = New System.Drawing.Size(72, 21)
      Me.cboGlycol.TabIndex = 6
      Me.cboGlycol.Text = "Ethylene"
      Me.cboGlycol.Visible = False
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
      '
      'cboFluid
      '
      Me.cboFluid.Items.AddRange(New Object() {"Water", "Glycol"})
      Me.cboFluid.Location = New System.Drawing.Point(112, 12)
      Me.cboFluid.Name = "cboFluid"
      Me.cboFluid.Size = New System.Drawing.Size(72, 21)
      Me.cboFluid.TabIndex = 4
      Me.cboFluid.Text = "Water"
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
      'panMain
      '
      Me.panMain.AutoScroll = True
      Me.panMain.Controls.Add(Me.panGrid)
      Me.panMain.Controls.Add(Me.panEvaporatorBody)
      Me.panMain.Controls.Add(Me.panEvaporatorHeader)
      Me.panMain.Controls.Add(Me.panCondenserBody)
      Me.panMain.Controls.Add(Me.panCondenserHeader)
      Me.panMain.Controls.Add(Me.panCompressorBody)
      Me.panMain.Controls.Add(Me.panCompressorHeader)
      Me.panMain.Controls.Add(Me.panCriteriaBody)
      Me.panMain.Controls.Add(Me.panCriteriaHeader)
      Me.panMain.Controls.Add(Me.panTop)
      Me.panMain.Dock = System.Windows.Forms.DockStyle.Fill
      Me.panMain.Location = New System.Drawing.Point(0, 0)
      Me.panMain.Name = "panMain"
      Me.panMain.Size = New System.Drawing.Size(686, 551)
      Me.panMain.TabIndex = 5
      '
      'panGrid
      '
      Me.panGrid.Controls.Add(Me.grdResults)
      Me.panGrid.Controls.Add(Me.hid_panResults)
      Me.panGrid.Controls.Add(Me.lblLimits)
      Me.panGrid.Dock = System.Windows.Forms.DockStyle.Top
      Me.panGrid.Location = New System.Drawing.Point(0, 1016)
      Me.panGrid.Name = "panGrid"
      Me.panGrid.Size = New System.Drawing.Size(669, 310)
      Me.panGrid.TabIndex = 10
      '
      'grdResults
      '
      Me.grdResults.CaptionHeight = 17
      Me.grdResults.GroupByCaption = "Drag a column header here to group by that column"
      Me.grdResults.Images.Add(CType(resources.GetObject("grdResults.Images"), System.Drawing.Image))
      Me.grdResults.Location = New System.Drawing.Point(9, 21)
      Me.grdResults.Name = "grdResults"
      Me.grdResults.PreviewInfo.Location = New System.Drawing.Point(0, 0)
      Me.grdResults.PreviewInfo.Size = New System.Drawing.Size(0, 0)
      Me.grdResults.PreviewInfo.ZoomFactor = 75
      Me.grdResults.PrintInfo.PageSettings = CType(resources.GetObject("grdResults.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
      Me.grdResults.RowHeight = 15
      Me.grdResults.Size = New System.Drawing.Size(622, 279)
      Me.grdResults.TabIndex = 92
      Me.grdResults.Text = "C1TrueDBGrid1"
      Me.grdResults.PropBag = resources.GetString("grdResults.PropBag")
      '
      'hid_panResults
      '
      Me.hid_panResults.BackColor = System.Drawing.Color.Yellow
      Me.hid_panResults.Controls.Add(Me.Txt10Deg_1)
      Me.hid_panResults.Controls.Add(Me.Txt8Deg_2)
      Me.hid_panResults.Controls.Add(Me.Txt_circuit_per_unit)
      Me.hid_panResults.Controls.Add(Me.TxtCondCap)
      Me.hid_panResults.Controls.Add(Me.Txt10Deg_2)
      Me.hid_panResults.Controls.Add(Me.CboFpi)
      Me.hid_panResults.Controls.Add(Me.TxtTonsSystemCap)
      Me.hid_panResults.Controls.Add(Me.txt_gpm)
      Me.hid_panResults.Controls.Add(Me.cboChiller11)
      Me.hid_panResults.Controls.Add(Me.txt_Evap_Length)
      Me.hid_panResults.Controls.Add(Me.Txt8Deg_1)
      Me.hid_panResults.Location = New System.Drawing.Point(644, 5)
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
      'CboFpi
      '
      Me.CboFpi.Location = New System.Drawing.Point(9, 237)
      Me.CboFpi.Name = "CboFpi"
      Me.CboFpi.Size = New System.Drawing.Size(56, 21)
      Me.CboFpi.TabIndex = 86
      Me.CboFpi.Text = "12"
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
      'panEvaporatorBody
      '
      Me.panEvaporatorBody.Controls.Add(Me.panEvaporatorControls)
      Me.panEvaporatorBody.Controls.Add(Me.hid_panEvaporator)
      Me.panEvaporatorBody.Dock = System.Windows.Forms.DockStyle.Top
      Me.panEvaporatorBody.Location = New System.Drawing.Point(0, 876)
      Me.panEvaporatorBody.Name = "panEvaporatorBody"
      Me.panEvaporatorBody.Size = New System.Drawing.Size(669, 140)
      Me.panEvaporatorBody.TabIndex = 5
      '
      'panEvaporatorControls
      '
      Me.panEvaporatorControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.panEvaporatorControls.Controls.Add(Me.txtCapacity)
      Me.panEvaporatorControls.Controls.Add(Me.btnAlternateEvaporators)
      Me.panEvaporatorControls.Controls.Add(Me.cboFoulingFactor)
      Me.panEvaporatorControls.Controls.Add(Me.lblEvaporator)
      Me.panEvaporatorControls.Controls.Add(Me.cboEvaporators)
      Me.panEvaporatorControls.Controls.Add(Me.chkCatalog)
      Me.panEvaporatorControls.Controls.Add(Me.txtEvaporator)
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
      'btnAlternateEvaporators
      '
      Me.btnAlternateEvaporators.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAlternateEvaporators.Location = New System.Drawing.Point(16, 12)
      Me.btnAlternateEvaporators.Name = "btnAlternateEvaporators"
      Me.btnAlternateEvaporators.Size = New System.Drawing.Size(128, 23)
      Me.btnAlternateEvaporators.TabIndex = 1
      Me.btnAlternateEvaporators.Text = "Alternate Evaporators"
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
      'cboEvaporators
      '
      Me.cboEvaporators.Location = New System.Drawing.Point(156, 12)
      Me.cboEvaporators.Name = "cboEvaporators"
      Me.cboEvaporators.Size = New System.Drawing.Size(120, 21)
      Me.cboEvaporators.TabIndex = 2
      Me.cboEvaporators.Visible = False
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
      'txtEvaporator
      '
      Me.txtEvaporator.Location = New System.Drawing.Point(156, 40)
      Me.txtEvaporator.Name = "txtEvaporator"
      Me.txtEvaporator.ReadOnly = True
      Me.txtEvaporator.Size = New System.Drawing.Size(120, 21)
      Me.txtEvaporator.TabIndex = 2
      Me.txtEvaporator.TabStop = False
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
      Me.radCapacityTons.Text = "Tons"
      '
      'radCapacityGpm
      '
      Me.radCapacityGpm.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.radCapacityGpm.Location = New System.Drawing.Point(72, 8)
      Me.radCapacityGpm.Name = "radCapacityGpm"
      Me.radCapacityGpm.Size = New System.Drawing.Size(48, 24)
      Me.radCapacityGpm.TabIndex = 2
      Me.radCapacityGpm.Text = "GPM"
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
      'panEvaporatorHeader
      '
      Me.panEvaporatorHeader.Controls.Add(Me.picEvaporatorVisibility)
      Me.panEvaporatorHeader.Controls.Add(Me.btnEvaporatorVisibility)
      Me.panEvaporatorHeader.Controls.Add(Me.lblEvaporatorHeader)
      Me.panEvaporatorHeader.Dock = System.Windows.Forms.DockStyle.Top
      Me.panEvaporatorHeader.Location = New System.Drawing.Point(0, 854)
      Me.panEvaporatorHeader.Name = "panEvaporatorHeader"
      Me.panEvaporatorHeader.Size = New System.Drawing.Size(669, 22)
      Me.panEvaporatorHeader.TabIndex = 7
      '
      'picEvaporatorVisibility
      '
      Me.picEvaporatorVisibility.Image = CType(resources.GetObject("picEvaporatorVisibility.Image"), System.Drawing.Image)
      Me.picEvaporatorVisibility.Location = New System.Drawing.Point(128, 1)
      Me.picEvaporatorVisibility.Name = "picEvaporatorVisibility"
      Me.picEvaporatorVisibility.Size = New System.Drawing.Size(22, 20)
      Me.picEvaporatorVisibility.TabIndex = 77
      Me.picEvaporatorVisibility.TabStop = False
      Me.picEvaporatorVisibility.Tag = "expanded"
      Me.ToolTip1.SetToolTip(Me.picEvaporatorVisibility, "Hide evaporator section")
      '
      'btnEvaporatorVisibility
      '
      Me.btnEvaporatorVisibility.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnEvaporatorVisibility.Location = New System.Drawing.Point(192, 2)
      Me.btnEvaporatorVisibility.Name = "btnEvaporatorVisibility"
      Me.btnEvaporatorVisibility.Size = New System.Drawing.Size(16, 16)
      Me.btnEvaporatorVisibility.TabIndex = 76
      Me.btnEvaporatorVisibility.Text = "-"
      Me.ToolTip1.SetToolTip(Me.btnEvaporatorVisibility, "Show/hide Evaporator Data section")
      Me.btnEvaporatorVisibility.Visible = False
      '
      'lblEvaporatorHeader
      '
      Me.lblEvaporatorHeader.BackColor = System.Drawing.Color.Maroon
      Me.lblEvaporatorHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblEvaporatorHeader.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblEvaporatorHeader.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.lblEvaporatorHeader.Location = New System.Drawing.Point(8, 0)
      Me.lblEvaporatorHeader.Name = "lblEvaporatorHeader"
      Me.lblEvaporatorHeader.Size = New System.Drawing.Size(152, 22)
      Me.lblEvaporatorHeader.TabIndex = 0
      Me.lblEvaporatorHeader.Text = " Evaporator Data"
      Me.lblEvaporatorHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'panCondenserBody
      '
      Me.panCondenserBody.Controls.Add(Me.hid_panCondenser)
      Me.panCondenserBody.Controls.Add(Me.panCondenserControls)
      Me.panCondenserBody.Dock = System.Windows.Forms.DockStyle.Top
      Me.panCondenserBody.Location = New System.Drawing.Point(0, 530)
      Me.panCondenserBody.Name = "panCondenserBody"
      Me.panCondenserBody.Size = New System.Drawing.Size(669, 324)
      Me.panCondenserBody.TabIndex = 4
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
      Me.panCondenserControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
      Me.panCondenserControls.Controls.Add(Me.cboFanFileName)
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
      Me.lblCondenser2.Text = "Evaperator"
      Me.lblCondenser2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblNumCoils1
      '
      Me.lblNumCoils1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblNumCoils1.Location = New System.Drawing.Point(0, 28)
      Me.lblNumCoils1.Name = "lblNumCoils1"
      Me.lblNumCoils1.Size = New System.Drawing.Size(80, 23)
      Me.lblNumCoils1.TabIndex = 6
      Me.lblNumCoils1.Text = "Evap quantity"
      Me.lblNumCoils1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCircuit2
      '
      Me.lblCircuit2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblCircuit2.Location = New System.Drawing.Point(344, 4)
      Me.lblCircuit2.Name = "lblCircuit2"
      Me.lblCircuit2.Size = New System.Drawing.Size(160, 23)
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
      'cboFanFileName
      '
      Me.cboFanFileName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cboFanFileName.Location = New System.Drawing.Point(88, 224)
      Me.cboFanFileName.MaxDropDownItems = 11
      Me.cboFanFileName.Name = "cboFanFileName"
      Me.cboFanFileName.Size = New System.Drawing.Size(248, 21)
      Me.cboFanFileName.TabIndex = 8
      '
      'lblNumCoils2
      '
      Me.lblNumCoils2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblNumCoils2.Location = New System.Drawing.Point(248, 28)
      Me.lblNumCoils2.Name = "lblNumCoils2"
      Me.lblNumCoils2.Size = New System.Drawing.Size(88, 23)
      Me.lblNumCoils2.TabIndex = 5
      Me.lblNumCoils2.Text = "Evap quantity"
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
      Me.lblCondenser1.Text = "Evaperator"
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
      'panCondenserHeader
      '
      Me.panCondenserHeader.Controls.Add(Me.picCondenserVisibility)
      Me.panCondenserHeader.Controls.Add(Me.btnCondenserVisibility)
      Me.panCondenserHeader.Controls.Add(Me.lblCondenser)
      Me.panCondenserHeader.Dock = System.Windows.Forms.DockStyle.Top
      Me.panCondenserHeader.Location = New System.Drawing.Point(0, 508)
      Me.panCondenserHeader.Name = "panCondenserHeader"
      Me.panCondenserHeader.Size = New System.Drawing.Size(669, 22)
      Me.panCondenserHeader.TabIndex = 11
      '
      'picCondenserVisibility
      '
      Me.picCondenserVisibility.Image = CType(resources.GetObject("picCondenserVisibility.Image"), System.Drawing.Image)
      Me.picCondenserVisibility.Location = New System.Drawing.Point(128, 1)
      Me.picCondenserVisibility.Name = "picCondenserVisibility"
      Me.picCondenserVisibility.Size = New System.Drawing.Size(22, 20)
      Me.picCondenserVisibility.TabIndex = 78
      Me.picCondenserVisibility.TabStop = False
      Me.picCondenserVisibility.Tag = "expanded"
      Me.ToolTip1.SetToolTip(Me.picCondenserVisibility, "Hide condenser section")
      '
      'btnCondenserVisibility
      '
      Me.btnCondenserVisibility.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnCondenserVisibility.Location = New System.Drawing.Point(184, 2)
      Me.btnCondenserVisibility.Name = "btnCondenserVisibility"
      Me.btnCondenserVisibility.Size = New System.Drawing.Size(16, 16)
      Me.btnCondenserVisibility.TabIndex = 77
      Me.btnCondenserVisibility.Text = "-"
      Me.ToolTip1.SetToolTip(Me.btnCondenserVisibility, "Show/hide Condenser Data section")
      Me.btnCondenserVisibility.Visible = False
      '
      'lblCondenser
      '
      Me.lblCondenser.BackColor = System.Drawing.Color.Maroon
      Me.lblCondenser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblCondenser.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblCondenser.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.lblCondenser.Location = New System.Drawing.Point(8, 0)
      Me.lblCondenser.Name = "lblCondenser"
      Me.lblCondenser.Size = New System.Drawing.Size(152, 22)
      Me.lblCondenser.TabIndex = 0
      Me.lblCondenser.Text = " Condenser Data"
      Me.lblCondenser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'panCompressorBody
      '
      Me.panCompressorBody.Controls.Add(Me.panCompressorControls)
      Me.panCompressorBody.Dock = System.Windows.Forms.DockStyle.Top
      Me.panCompressorBody.Location = New System.Drawing.Point(0, 308)
      Me.panCompressorBody.Name = "panCompressorBody"
      Me.panCompressorBody.Size = New System.Drawing.Size(669, 200)
      Me.panCompressorBody.TabIndex = 3
      '
      'panCompressorControls
      '
      Me.panCompressorControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
      'panCompressorHeader
      '
      Me.panCompressorHeader.Controls.Add(Me.picCompressorVisibility)
      Me.panCompressorHeader.Controls.Add(Me.btnCompressorVisibility)
      Me.panCompressorHeader.Controls.Add(Me.lblCompressor)
      Me.panCompressorHeader.Dock = System.Windows.Forms.DockStyle.Top
      Me.panCompressorHeader.Location = New System.Drawing.Point(0, 286)
      Me.panCompressorHeader.Name = "panCompressorHeader"
      Me.panCompressorHeader.Size = New System.Drawing.Size(669, 22)
      Me.panCompressorHeader.TabIndex = 12
      '
      'picCompressorVisibility
      '
      Me.picCompressorVisibility.Image = CType(resources.GetObject("picCompressorVisibility.Image"), System.Drawing.Image)
      Me.picCompressorVisibility.Location = New System.Drawing.Point(128, 1)
      Me.picCompressorVisibility.Name = "picCompressorVisibility"
      Me.picCompressorVisibility.Size = New System.Drawing.Size(22, 20)
      Me.picCompressorVisibility.TabIndex = 79
      Me.picCompressorVisibility.TabStop = False
      Me.picCompressorVisibility.Tag = "expanded"
      Me.ToolTip1.SetToolTip(Me.picCompressorVisibility, "Hide compressor section")
      '
      'btnCompressorVisibility
      '
      Me.btnCompressorVisibility.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnCompressorVisibility.Location = New System.Drawing.Point(184, 2)
      Me.btnCompressorVisibility.Name = "btnCompressorVisibility"
      Me.btnCompressorVisibility.Size = New System.Drawing.Size(16, 16)
      Me.btnCompressorVisibility.TabIndex = 78
      Me.btnCompressorVisibility.Text = "-"
      Me.ToolTip1.SetToolTip(Me.btnCompressorVisibility, "Show/hide Compressor Data section")
      Me.btnCompressorVisibility.Visible = False
      '
      'lblCompressor
      '
      Me.lblCompressor.BackColor = System.Drawing.Color.Maroon
      Me.lblCompressor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblCompressor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblCompressor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.lblCompressor.Location = New System.Drawing.Point(8, 0)
      Me.lblCompressor.Name = "lblCompressor"
      Me.lblCompressor.Size = New System.Drawing.Size(152, 22)
      Me.lblCompressor.TabIndex = 0
      Me.lblCompressor.Text = " Compressor Data"
      Me.lblCompressor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'panCriteriaHeader
      '
      Me.panCriteriaHeader.Controls.Add(Me.picCriteriaVisibility)
      Me.panCriteriaHeader.Controls.Add(Me.btnCriteriaVisibility)
      Me.panCriteriaHeader.Controls.Add(Me.lblRatingCriteria)
      Me.panCriteriaHeader.Dock = System.Windows.Forms.DockStyle.Top
      Me.panCriteriaHeader.Location = New System.Drawing.Point(0, 68)
      Me.panCriteriaHeader.Name = "panCriteriaHeader"
      Me.panCriteriaHeader.Size = New System.Drawing.Size(669, 22)
      Me.panCriteriaHeader.TabIndex = 13
      '
      'picCriteriaVisibility
      '
      Me.picCriteriaVisibility.Image = CType(resources.GetObject("picCriteriaVisibility.Image"), System.Drawing.Image)
      Me.picCriteriaVisibility.Location = New System.Drawing.Point(128, 1)
      Me.picCriteriaVisibility.Name = "picCriteriaVisibility"
      Me.picCriteriaVisibility.Size = New System.Drawing.Size(22, 20)
      Me.picCriteriaVisibility.TabIndex = 80
      Me.picCriteriaVisibility.TabStop = False
      Me.picCriteriaVisibility.Tag = "expanded"
      Me.ToolTip1.SetToolTip(Me.picCriteriaVisibility, "Hide rating criteria section")
      '
      'btnCriteriaVisibility
      '
      Me.btnCriteriaVisibility.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnCriteriaVisibility.Location = New System.Drawing.Point(184, 2)
      Me.btnCriteriaVisibility.Name = "btnCriteriaVisibility"
      Me.btnCriteriaVisibility.Size = New System.Drawing.Size(16, 16)
      Me.btnCriteriaVisibility.TabIndex = 79
      Me.btnCriteriaVisibility.Text = "-"
      Me.ToolTip1.SetToolTip(Me.btnCriteriaVisibility, "Show/hide Rating Criteria section")
      Me.btnCriteriaVisibility.Visible = False
      '
      'btnCreateReport
      '
      Me.btnCreateReport.BackColor = System.Drawing.Color.White
      Me.btnCreateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.btnCreateReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnCreateReport.ForeColor = System.Drawing.Color.Maroon
      Me.btnCreateReport.Image = CType(resources.GetObject("btnCreateReport.Image"), System.Drawing.Image)
      Me.btnCreateReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCreateReport.Location = New System.Drawing.Point(0, 0)
      Me.btnCreateReport.Name = "btnCreateReport"
      Me.btnCreateReport.Size = New System.Drawing.Size(165, 32)
      Me.btnCreateReport.TabIndex = 2
      Me.btnCreateReport.Text = "Create Report"
      Me.btnCreateReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCreateReport.UseVisualStyleBackColor = False
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
      'panFooter
      '
      Me.panFooter.BackColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.panFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.panFooter.Controls.Add(Me.lblError)
      Me.panFooter.Controls.Add(Me.panFooterButton)
      Me.panFooter.Controls.Add(Me.picError)
      Me.panFooter.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.panFooter.Location = New System.Drawing.Point(0, 551)
      Me.panFooter.Name = "panFooter"
      Me.panFooter.Size = New System.Drawing.Size(686, 34)
      Me.panFooter.TabIndex = 9
      '
      'lblError
      '
      Me.lblError.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lblError.Location = New System.Drawing.Point(32, 0)
      Me.lblError.Name = "lblError"
      Me.lblError.Size = New System.Drawing.Size(319, 32)
      Me.lblError.TabIndex = 6
      Me.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'panFooterButton
      '
      Me.panFooterButton.BackColor = System.Drawing.SystemColors.Control
      Me.panFooterButton.Controls.Add(Me.btnCalculatePage)
      Me.panFooterButton.Controls.Add(Me.btnCreateReport)
      Me.panFooterButton.Dock = System.Windows.Forms.DockStyle.Right
      Me.panFooterButton.Location = New System.Drawing.Point(351, 0)
      Me.panFooterButton.Name = "panFooterButton"
      Me.panFooterButton.Size = New System.Drawing.Size(333, 32)
      Me.panFooterButton.TabIndex = 16
      '
      'btnCalculatePage
      '
      Me.btnCalculatePage.BackColor = System.Drawing.Color.White
      Me.btnCalculatePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.btnCalculatePage.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnCalculatePage.ForeColor = System.Drawing.Color.Maroon
      Me.btnCalculatePage.Image = CType(resources.GetObject("btnCalculatePage.Image"), System.Drawing.Image)
      Me.btnCalculatePage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCalculatePage.Location = New System.Drawing.Point(165, 0)
      Me.btnCalculatePage.Name = "btnCalculatePage"
      Me.btnCalculatePage.Size = New System.Drawing.Size(168, 32)
      Me.btnCalculatePage.TabIndex = 1
      Me.btnCalculatePage.Text = "Calculate Page "
      Me.btnCalculatePage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCalculatePage.UseVisualStyleBackColor = False
      '
      'err
      '
      Me.err.ContainerControl = Me
      Me.err.Icon = CType(resources.GetObject("err.Icon"), System.Drawing.Icon)
      '
      'frmEvapCooledRep
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
      Me.ClientSize = New System.Drawing.Size(686, 585)
      Me.Controls.Add(Me.panMain)
      Me.Controls.Add(Me.panFooter)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.MainMenuStrip = Me.MenuStrip1
      Me.Name = "frmEvapCooledRep"
      Me.Text = "Chiller Rating - Evap Cooled"
      Me.panTop.ResumeLayout(False)
      Me.panTop.PerformLayout()
      Me.MenuStrip1.ResumeLayout(False)
      Me.MenuStrip1.PerformLayout()
      Me.panCriteriaBody.ResumeLayout(False)
      Me.panCriteriaBody.PerformLayout()
      Me.hid_panCriteria.ResumeLayout(False)
      Me.hid_panCriteria.PerformLayout()
      Me.panCriteriaControls.ResumeLayout(False)
      Me.panCriteriaControls.PerformLayout()
      Me.panMain.ResumeLayout(False)
      Me.panGrid.ResumeLayout(False)
      CType(Me.grdResults, System.ComponentModel.ISupportInitialize).EndInit()
      Me.hid_panResults.ResumeLayout(False)
      Me.hid_panResults.PerformLayout()
      Me.panEvaporatorBody.ResumeLayout(False)
      Me.panEvaporatorControls.ResumeLayout(False)
      Me.panEvaporatorControls.PerformLayout()
      Me.Panel3.ResumeLayout(False)
      Me.hid_panEvaporator.ResumeLayout(False)
      Me.hid_panEvaporator.PerformLayout()
      Me.hid_panApproach.ResumeLayout(False)
      Me.panEvaporatorHeader.ResumeLayout(False)
      CType(Me.picEvaporatorVisibility, System.ComponentModel.ISupportInitialize).EndInit()
      Me.panCondenserBody.ResumeLayout(False)
      Me.hid_panCondenser.ResumeLayout(False)
      Me.hid_panCondenser.PerformLayout()
      Me.panCondenserControls.ResumeLayout(False)
      Me.panCondenserControls.PerformLayout()
      Me.panCondenserHeader.ResumeLayout(False)
      CType(Me.picCondenserVisibility, System.ComponentModel.ISupportInitialize).EndInit()
      Me.panCompressorBody.ResumeLayout(False)
      Me.panCompressorControls.ResumeLayout(False)
      Me.gboCompressor1.ResumeLayout(False)
      Me.gboCompressor1.PerformLayout()
      Me.gboCompressor2.ResumeLayout(False)
      Me.gboCompressor2.PerformLayout()
      Me.panCompressorCircuits.ResumeLayout(False)
      Me.panCompressorHeader.ResumeLayout(False)
      CType(Me.picCompressorVisibility, System.ComponentModel.ISupportInitialize).EndInit()
      Me.panCriteriaHeader.ResumeLayout(False)
      CType(Me.picCriteriaVisibility, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.picError, System.ComponentModel.ISupportInitialize).EndInit()
      Me.panFooter.ResumeLayout(False)
      Me.panFooterButton.ResumeLayout(False)
      CType(Me.err, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

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

   Dim EvapChiller1 As EvapChillerProcessItem
   Dim EvapChiller2 As EvapChillerProcessItem


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
   Dim gRef As String               'Refrigerant type

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


#Region " Private methods"


#Region " Event handlers"

   Private Sub frmEvapCooledRep_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
      If Not Me.ProcessDeleted Then

      End If
   End Sub

   Private Sub Me_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

      ' sets cursor to hour glass
      Me.Cursor = Cursors.WaitCursor
      'starts usage log for this form
      Me.StartUsageLog()
      ' sets height of form to height of mdiparent's client area
      Me.Height = Ui.FormEditor.MaximizeHeight(Me)
      ' aligns top of child form to the top of the mdiparent's client area
      Me.Location = New Point(Me.Location.X, 0)

      ' fills comboboxes
      Me.FillComboboxes()

      ' sets controls visibility
      Me.SetControlsVisibility()

      Me.InitializeControls()
      ' initializes validation utilities
      Me.InitializeValidation()

      loaded = True

      ' sets specific heat and gravity
      ChillyRAEs_pass_no = 1 : Call_ChillyRAE_Parms()

      Me.Cursor = Cursors.Default
   End Sub


   Private Sub frmChillerAirCooledRep_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
   Handles MyBase.Closing
      ' ends usage log for form
      Me.EndUsageLog()
   End Sub

   ''' <summary>
   ''' 
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   ''' <remarks></remarks>
   Private Sub cboSeries_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles cboSeries.SelectedIndexChanged
      ' grabs selected series
      Dim series As String = Me.cboSeries.SelectedItem.ToString
      Dim seriesEnum = BCI.ChillerIntel.ConvertStringToSeries(series)

      ' retrieves chiller models for the selected series
      'Dim chillerModels As System.Collections.Specialized.StringCollection = Me.RetrieveChillerModels(seriesEnum)
      Dim chillerModels As DataTable = Rae.RaeSolutions.DataAccess.Chillers.ChillerDataAccess.RetrieveChillerModels(CInt(series))

      ' fills model combobox
      Me.cboModels.DataSource = chillerModels

   End Sub


   Private Sub txtLeavingFluidTemp_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles txtLeavingFluidTemp.Leave
      ' validates leaving fluid temperature textbox
      Me.leavingFluidTempVCtrl.Validate()
   End Sub

#End Region


#Region " Data"

   ''' <summary>Gets refrigerant list
   ''' </summary>
   ''' <remarks>
   ''' DisplayMember: refrigerant name
   ''' ValueMember: short refrigerant name
   ''' </remarks>
   Private Sub AddRefrigerants()
      Me.cboRefrigerant.Items.Clear()

      With Me.cboRefrigerant.Items
         ' adds refrigerants to list
         .Add(New RefrigerantItem("R-22H", "22H"))
         .Add(New RefrigerantItem("R-22M", "22M"))
         .Add(New RefrigerantItem("R-22L", "22L"))
         .Add(New RefrigerantItem("R-134a", "134a"))
      End With
   End Sub

#End Region


#Region " UI"

   Private Function GrabModel() As String
      Return Me.cboModels.SelectedItem.ToString.Trim
   End Function

   Private Function GrabEvaporatorModel() As String
      Return Me.txtEvaporator.Text.Trim
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

   Private Function GrabSystem() As String
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
      Return DirectCast(Me.cboFanFileName.SelectedItem, Business.Entities.Fan)
   End Function

   Private Function GrabRefrigerant() As RefrigerantItem
      Return DirectCast(Me.cboRefrigerant.SelectedItem, RefrigerantItem)
   End Function


#End Region



   ''' <summary>Start usage log for form.
   ''' </summary>
   ''' <history>[CASEYJ]	3/16/2005	Created
   ''' </history>
   Private Sub StartUsageLog()
      Try
         'initializes usage log
         usageLogger = New Diagnostics.UsageLog.FormUsageLogger(AppUsage.ApplicationID, AppUsage.LogFile.FullName)
         'starts usage log
         usageLogger.LogFormStart(Me.Text)
      Catch ex As Exception
      End Try
   End Sub


   ''' <summary>Ends usage log for form.
   ''' </summary>
   ''' <history>[CASEYJ]	3/16/2005	Created
   ''' </history>
   Private Sub EndUsageLog()
      Dim model, refrigerant As String
      Dim suctionTemperature As Single

      Try
         ' sets data to be logged
         model = Me.GrabModel()
         refrigerant = Me.GrabRefrigerant.Refrigerant
         suctionTemperature = Me.txtMinSuctionTemp.Text

         ' logs form usage statistics
         Me.usageLogger.LogFormEnd(model, refrigerant, suctionTemperature, Me.AmbientTemp)
      Catch ex As Exception
      End Try
   End Sub


   Private Sub InitializeControls()
      Me.cboHertz.SelectedIndex = 0
      Me.cboSeries.SelectedIndex = 0
      Me.cboRefrigerant.SelectedIndex = 0
      'Me.cboFpi1.SelectedIndex = 0
      'Me.cboFpi2.SelectedIndex = 0
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
         ErrorMessages.Number(leavingFluidTempName), RegularExpressions.Number)
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

   ''' <summary>Returns the index of the compressor model</summary>
   Private Function IndexOfCompressor(ByVal listbox As Forms.ListBox, ByVal compressor As String, _
   Optional ByVal compressorNotFoundIndex As Integer = 0) As Integer
      Dim index As Integer

      ' selects compressor
      For i As Integer = 0 To listbox.Items.Count - 1 Step 1
         listbox.SelectedIndex = i
         If DirectCast(listbox.SelectedItem, DataRowView)("compmodel") = compressor.ToUpper Then
            index = i : Exit For
         ElseIf lboCompressors1.SelectedIndex = listbox.Items.Count - 1 Then
            index = compressorNotFoundIndex
         End If
      Next

      Return index
   End Function


   Private Function Round(ByVal value As Double, ByVal digits As Integer) As Double
      Return Round(value, digits)
   End Function


   Private Function IsFullDualCircuit() As Boolean
      If Me.GrabSystem() = "FULL" And Me.GrabCircuitsPerUnit() = "2" _
      Or Me.GrabCircuitsPerUnit() = "4" Then
         Return True
      Else
         Return False
      End If
   End Function

   Private Function IsFullSingleCircuit() As Boolean
      If Me.GrabSystem() = "FULL" And Me.GrabCircuitsPerUnit() = "1" Then
         Return True
      Else
         Return False
      End If
   End Function

   Private Function IsHalfCircuit1() As Boolean
      If Me.GrabSystem() = "HALF" And Me.GrabCircuit1Checked() Then
         Return True
      Else
         Return False
      End If
   End Function

   Private Function IsHalfCircuit2() As Boolean
      If Me.GrabSystem() = "HALF" And Me.GrabCircuit2Checked() Then
         Return True
      Else
         Return False
      End If
   End Function

#End Region

   Public Sub Open(ByVal Process_Item As ProcessItem)
      Me.LoadControls(Process_Item)
   End Sub

   Private Sub LoadControls(ByVal Process_Item As EvapChillerProcessItem)

      ' Clone process item to form EvapChillerProcessItem (EvapChiller1)
      EvapChiller1 = Process_Item.Clone()

      cboSeries.Text = EvapChiller1.Series
      cboModels.Text = EvapChiller1.Model
      'txtModel.Text = EvapChiller1.ModelDesc
      cboFluid.Text = EvapChiller1.Fluid
      'txtGlycolPercentage.Text = EvapChiller1.GlycolPercentage
      'cboCoolingMedia.Text = EvapChiller1.CoolingMedia
      txtSpecificHeat.Text = EvapChiller1.SpecificHeat
      txtSpecificGravity.Text = EvapChiller1.SpecificGravity
      'txtSubCooling.Text = EvapChiller1.SubCooling
      cboRefrigerant.Text = EvapChiller1.Refrigerant
      'txtTempRange.Text = EvapChiller1.TempRange
      txtAmbientTemp.Text = EvapChiller1.AmbientTemp
      txtLeavingFluidTemp.Text = EvapChiller1.LeavingFluidTemp
      cboSystem.Text = EvapChiller1.System
      cboHertz.Text = EvapChiller1.Hertz
      'txtApproach.Text = EvapChiller1.Approach
      cboVolts.Text = EvapChiller1.Volts
      'txtTEMin.Text = EvapChiller1.TEMin
      'txtTEMax.Text = EvapChiller1.TEMax
      'txtTEIncrement.Text = EvapChiller1.TEIncrement
      'txtATMin.Text = EvapChiller1.ATMin
      'txtATMax.Text = EvapChiller1.ATMax
      'txtATIncrement.Text = EvapChiller1.ATIncrement
      'chkSafetyOverride.Checked = EvapChiller1.SafetyOverride
      radCircuit1.Checked = EvapChiller1.Circuit1
      radCircuit2.Checked = EvapChiller1.Circuit2
      txtCompressor1.Text = EvapChiller1.Compressors1
      txtCompressor2.Text = EvapChiller1.Compressors2
      txtNumCompressors1.Text = EvapChiller1.NumCompressors1
      txtNumCompressors2.Text = EvapChiller1.NumCompressors2
      Try
         lboCompressors1.SetSelected(lboCompressors1.Items.IndexOf(EvapChiller1.Compressors1), True)
      Catch ex As Exception
      End Try
      Try
         lboCompressors2.SetSelected(lboCompressors2.Items.IndexOf(EvapChiller1.Compressors2), True)
      Catch ex As Exception
      End Try
      txtNumCoils1.Text = EvapChiller1.NumCoils1
      txtNumCoils2.Text = EvapChiller1.NumCoils2
      'cboCondenser1.Text = EvapChiller1.Condenser1
      'cboCondenser2.Text = EvapChiller1.Condenser2
      'cboDischargeLineLoss.Text = EvapChiller1.DischargeLineLoss
      'cboSuctionLineLoss.Text = EvapChiller1.SuctionLineLoss
      'txtAltitude.Text = EvapChiller1.Altitude
      'txtPumpWatts.Text = EvapChiller1.PumpWatts
      'txtFanWatts.Text = EvapChiller1.FanWatts
      'txtCondenserCapacity1.Text = EvapChiller1.CondenserCapacity1
      'txtCondenserCapacity2.Text = EvapChiller1.CondenserCapacity2
      'cboEvaporatorModel.Text = EvapChiller1.EvaporatorModel
      'txtEvaporatorModel.Text = EvapChiller1.EvaporatorModelDesc
      'cboNumEvap.Text = EvapChiller1.NumEvap
      cboFoulingFactor.Text = EvapChiller1.FoulingFactor
      'If EvapChiller1.CapacityType = EvapChillerProcessItem.eCapacityType.Tons Then
      '    radTons.Checked = True
      'ElseIf EvapChiller1.CapacityType = EvapChillerProcessItem.eCapacityType.GPM Then
      '    radGpm.Checked = True
      'Else
      '    radGpm.Checked = False
      '    radTons.Checked = False
      'End If
      'txtEvaporatorCapacity.Text = EvapChiller1.EvaporatorCapacity
      'chkCatalogRating.Checked = EvapChiller1.CatalogRating
      ' Approach range...
      'If EvapChiller1.ApproachRange = EvapChillerProcessItem.eApproachRange.SixToEight Then
      '    rad6To8Approach.Checked = True
      'ElseIf EvapChiller1.ApproachRange = EvapChillerProcessItem.eApproachRange.SevenToNine Then
      '    rad7To9Approach.Checked = True
      'ElseIf EvapChiller1.ApproachRange = EvapChillerProcessItem.eApproachRange.EightToTen Then
      '    rad8To10Approach.Checked = True
      'ElseIf EvapChiller1.ApproachRange = EvapChillerProcessItem.eApproachRange.NineToEleven Then
      '    rad9To11Approach.Checked = True
      'ElseIf EvapChiller1.ApproachRange = EvapChillerProcessItem.eApproachRange.TenToTwelve Then
      '    rad10To12Approach.Checked = True
      'ElseIf EvapChiller1.ApproachRange = EvapChillerProcessItem.eApproachRange.Other Then
      '    radOtherEvaporator.Checked = True
      'End If
      'tbxEvap8Degr1.Text = EvapChiller1.Evap8Degr1
      'tbxEvap8Degr2.Text = EvapChiller1.Evap8Degr2
      'tbxEvap10Degr1.Text = EvapChiller1.Evap10Degr1
      'tbxEvap10Degr2.Text = EvapChiller1.Evap10Degr2

      ' Calculate page...
      btnCalculatePage_Click(btnCalculatePage, Nothing)

   End Sub

   Private Sub SaveControls()

      ' Clone process item to form EvapChillerProcessItem (EvapChiller1)
      If Not IsNothing(EvapChiller1) Then
         EvapChiller2 = EvapChiller1.Clone()
      Else
         If Not OpenedProject.IsOpened Then
            ' No project is open - if user wants to
            ' save rating they should associate it 
            ' with a project for future reference...
            ProjectInfo.Creator.CreateProject()
         End If
         EvapChiller2 = ProjectInfo.Creator.CreateProcess(Business.ProcessType.EvapChiller)
         If IsNothing(EvapChiller2) Then
            ' Evap chiller process item was not created
            ' unable to save
            Ui.MessageBox.Show("Unable to save evap chiller process.", MessageBoxIcon.Information)
            Exit Sub
         End If
      End If

      EvapChiller2.Series = cboSeries.Text
      EvapChiller2.Model = cboModels.Text
      'EvapChiller2.ModelDesc = txtModel.Text
      EvapChiller2.Fluid = cboFluid.Text
      'EvapChiller2.GlycolPercentage = txtGlycolPercentage.Text
      'EvapChiller2.CoolingMedia = cboCoolingMedia.Text
      EvapChiller2.SpecificHeat = txtSpecificHeat.Text
      EvapChiller2.SpecificGravity = txtSpecificGravity.Text
      'EvapChiller2.SubCooling = txtSubCooling.Text
      EvapChiller2.Refrigerant = cboRefrigerant.Text
      'EvapChiller2.TempRange = txtTempRange.Text
      EvapChiller2.AmbientTemp = txtAmbientTemp.Text
      EvapChiller2.LeavingFluidTemp = txtLeavingFluidTemp.Text
      EvapChiller2.System = cboSystem.Text
      EvapChiller2.Hertz = cboHertz.Text
      'EvapChiller2.Approach = txtApproach.Text
      'EvapChiller2.Volts = cboVolts.Text
      'EvapChiller2.TEMin = txtTEMin.Text
      'EvapChiller2.TEMax = txtTEMax.Text
      'EvapChiller2.TEIncrement = txtTEIncrement.Text
      'EvapChiller2.ATMin = txtATMin.Text
      'EvapChiller2.ATMax = txtATMax.Text
      'EvapChiller2.ATIncrement = txtATIncrement.Text
      'EvapChiller2.SafetyOverride = chkSafetyOverride.Checked
      EvapChiller2.Circuit1 = radCircuit1.Checked
      EvapChiller2.Circuit2 = radCircuit2.Checked
      EvapChiller2.Compressors1 = txtCompressor1.Text
      EvapChiller2.Compressors2 = txtCompressor2.Text
      EvapChiller2.NumCompressors1 = txtNumCompressors1.Text
      EvapChiller2.NumCompressors2 = txtNumCompressors2.Text
      EvapChiller2.NumCoils1 = txtNumCoils1.Text
      EvapChiller2.NumCoils2 = txtNumCoils2.Text
      'EvapChiller2.Condenser1 = cboCondenser1.Text
      'EvapChiller2.Condenser2 = cboCondenser2.Text
      'EvapChiller2.DischargeLineLoss = cboDischargeLineLoss.Text
      'EvapChiller2.SuctionLineLoss = cboSuctionLineLoss.Text
      'EvapChiller2.Altitude = txtAltitude.Text
      'EvapChiller2.PumpWatts = Val(txtPumpWatts.Text)
      'EvapChiller2.FanWatts = Val(txtFanWatts.Text)
      'EvapChiller2.CondenserCapacity1 = Val(txtCondenserCapacity1.Text)
      'EvapChiller2.CondenserCapacity2 = Val(txtCondenserCapacity2.Text)
      'EvapChiller2.EvaporatorModel = cboEvaporatorModel.Text
      'EvapChiller2.EvaporatorModelDesc = txtEvaporatorModel.Text
      'EvapChiller2.NumEvap = Val(cboNumEvap.Text)
      EvapChiller2.FoulingFactor = Val(cboFoulingFactor.Text)
      'If radTons.Checked = True Then
      '    EvapChiller2.CapacityType = EvapChillerProcessItem.eCapacityType.Tons
      'ElseIf radGpm.Checked = True Then
      '    EvapChiller2.CapacityType = EvapChillerProcessItem.eCapacityType.GPM
      'End If
      'EvapChiller2.EvaporatorCapacity = Val(txtEvaporatorCapacity.Text)
      'EvapChiller2.CatalogRating = chkCatalogRating.Checked
      '' Approach range...
      'If rad6To8Approach.Checked = True Then
      '    EvapChiller2.ApproachRange = EvapChillerProcessItem.eApproachRange.SixToEight
      'ElseIf rad7To9Approach.Checked = True Then
      '    EvapChiller2.ApproachRange = EvapChillerProcessItem.eApproachRange.SevenToNine
      'ElseIf rad8To10Approach.Checked = True Then
      '    EvapChiller2.ApproachRange = EvapChillerProcessItem.eApproachRange.EightToTen
      'ElseIf rad9To11Approach.Checked = True Then
      '    EvapChiller2.ApproachRange = EvapChillerProcessItem.eApproachRange.NineToEleven
      'ElseIf rad10To12Approach.Checked = True Then
      '    EvapChiller2.ApproachRange = EvapChillerProcessItem.eApproachRange.TenToTwelve
      'ElseIf radOtherEvaporator.Checked = True Then
      '    EvapChiller2.ApproachRange = EvapChillerProcessItem.eApproachRange.Other
      'End If
      'EvapChiller2.Evap8Degr1 = Val(tbxEvap8Degr1.Text)
      'EvapChiller2.Evap8Degr2 = Val(tbxEvap8Degr2.Text)
      'EvapChiller2.Evap10Degr1 = Val(tbxEvap10Degr1.Text)
      'EvapChiller2.Evap10Degr2 = Val(tbxEvap10Degr2.Text)

      If Not IsNothing(EvapChiller1) Then

         ' TEST: process reference needs to be same as reference in OpenedProject
         For Each process As ProcessItem In OpenedProject.Manager.Processes
            If process.Id.ToString = Me.EvapChiller2.Id.ToString Then
               process.Copy(Me.EvapChiller2)
               process.Save()
               Exit For
            End If
         Next

         If EvapChiller2.Equals(EvapChiller1) Then
            MessageBox.Show("Match")
         Else
            MessageBox.Show("Changed")
         End If
      Else
         EvapChiller2.Save()
         EvapChiller1 = EvapChiller2.Clone()
      End If

   End Sub

   ''' <summary>Fills comboboxes with display and hidden values
   ''' </summary>
   Private Sub FillComboboxes()
      ' fills refrigerant combobox
      Me.AddRefrigerants()

      ' fills condenser comboboxes
      Me.cboCoilFileName1.DataSource = DataAccess.Chillers.ChillerDataAccess.GetCondensers()
      Me.cboCoilFileName2.DataSource = DataAccess.Chillers.ChillerDataAccess.GetCondensers()

      ' fills fan comboboxes
      'Me.cboFanFileName.DataSource = Business.Intelligence.Chillers.Chiller.GetFans()

      'Me.CboFpi.DataSource = frmChillerAirCooled.GetFinsPerInchOptions()
      'Me.cboFpi1.DataSource = frmChillerAirCooled.GetFinsPerInchOptions()
      'Me.cboFpi2.DataSource = frmChillerAirCooled.GetFinsPerInchOptions()
   End Sub


   ''' <summary>Sets control visibility base on authorization level
   ''' </summary>
   Private Sub SetControlsVisibility()

      ' if not employee
      If AppInfo.User.AuthorityGroup > 2 Then
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


   Private Sub Call_ChillyRAE_Parms()
      Dim read_cooler As String

      CalculateFreezePoint()

      Try
         ' retrieves standard model
         Dim chillerTable As DataTable = DataAccess.Chillers.ChillerDataAccess.RetrieveChillerEvaporator(Me.GrabEvaporatorModel())
         If chillerTable.Rows.Count > 0 Then read_cooler = chillerTable.Rows(0)("StandardModelNum").ToString()
      Catch dbEx As OleDb.OleDbException
         Ui.MessageBox.Show("An exception occurred while attempting to retrieve the standard evaporator model. " & dbEx.Message)
         Exit Sub
      End Try
      ' standard model is nothing when a chiller model is not yet chosen 
      'i.e. when the form first runs
      If read_cooler Is Nothing Then Exit Sub
      ' UNSURE: option 3 doesn't work w/out this line, removed b/c 30A0S models didn't run
      'read_cooler = read_cooler.ToLower

      Dim ChillyRAE_Parms As New RAEDLL_CONDENSING_UNIT.Selection_Mod

      ' 1 = Parms    2 = Models    3 = 8 & 10 deg approach
      If ChillyRAEs_pass_no = 1 Then
         With ChillyRAE_Parms
            .RAE_ChillyRAEs_pass = 1        '1 = Parms    2 = Models    3 = 8&10 deg approach
            .RAE_Fouling_Factor = Val(cboFoulingFactor.SelectedItem)
            .RAE_Cbo_Fluid = cboFluid.SelectedItem
            .RAE_tempin = Me.LeavingFluidTemp + Val(cboTempRange.SelectedItem)
            .RAE_tempot = Me.LeavingFluidTemp
            .RAE_txtCondCap = (Val(TxtTonsSystemCap.Text()) * 12000) 'Val(TxtCondCap.Text())
            .RAE_cboRef_Text = "R" & Me.GrabRefrigerant.Abbreviation
            .RAE_cboCCM_Text = Trim(cboGlycol.SelectedItem)
            .RAE_txtPctGly_Text = Val(txtPercentGlycol.Text)
            .RAE_conduc = 0
            .RAE_visc = 0
            .RAE_spht = Val(txtSpecificHeat.Text())
            .RAE_allmod = "all"
            .RAE_units = "U.S. UNIT"     'METRIC
            .RAE_cbo_chillers_Text = read_cooler 'Trim(txtEvaporator.Text())
            .RAE_txtSpGr = 0     'Val(txtSpecificGravity.Text())
            .AddToDatabase5()

            Me.txtSpecificHeat.Text = .RAE_Out_txtSpHt_Text.ToString
            Me.txtSpecificGravity.Text = .RAE_Out_txtSpGr_Text.ToString
         End With
      End If

      If ChillyRAEs_pass_no = 2 Then
         Dim evaporatorPartNums As ArrayList = New ArrayList
         Dim myList_CHILLER As ArrayList = New ArrayList
         Dim additionalEvaporatorLength As Double = 6

         ''' <history>Added by Casey J. on 9/28/2005 per Danny G.</history>
         ''' <summary>Increases length of evaporators that are available to reps by 6 or 13</summary>
         If Me.cboModels.SelectedItem Like "*SM*" _
         Or Me.cboModels.SelectedItem Like "*CM*" _
         Or Me.cboModels.SelectedItem Like "*SS1*" _
         Or Me.cboModels.SelectedItem Like "*SD1*" _
         Or Me.cboModels.SelectedItem Like "*SD2*" _
         Or Me.cboModels.SelectedItem Like "*CD100*" _
         Or Me.cboModels.SelectedItem Like "*CD110*" _
         Or Me.cboModels.SelectedItem Like "*CD120*" Then
            additionalEvaporatorLength = 13
         End If

         With ChillyRAE_Parms
            .RAE_ChillyRAEs_pass = 2        '1 = Parms    2 = Models    3 = 8&10 deg approach
            .RAE_Fouling_Factor = Val(cboFoulingFactor.SelectedItem)
            .RAE_Cbo_Fluid = cboFluid.SelectedItem
            .RAE_tempin = Me.LeavingFluidTemp + Val(cboTempRange.SelectedItem)
            .RAE_tempot = Me.LeavingFluidTemp
            .RAE_txtCondCap = (Val(TxtTonsSystemCap.Text()) * 12000)   'Val(TxtCondCap.Text())
            .RAE_cboRef_Text = "R" & Me.GrabRefrigerant.Abbreviation
            .RAE_cboCCM_Text = Trim(cboGlycol.SelectedItem)
            .RAE_txtPctGly_Text = Val(txtPercentGlycol.Text())
            .RAE_conduc = 0
            .RAE_visc = 0
            .RAE_spht = 0    'Val(txtSpecificHeat.Text())
            .RAE_allmod = "all"
            .RAE_units = "U.S. UNIT"     'METRIC
            .RAE_cbo_chillers_Text = "all"   'Trim(txtEvaporator.Text())
            .RAE_txtSpGr = 0     'Val(txtSpecificGravity.Text())
            .AddToDatabase5()

            myList_CHILLER.Add(Trim(.RAE_Out_cbo_chillers1))
            myList_CHILLER.Add(Trim(.RAE_Out_cbo_chillers2))
            myList_CHILLER.Add(Trim(.RAE_Out_cbo_chillers3))
            myList_CHILLER.Add(Trim(.RAE_Out_cbo_chillers4))
            myList_CHILLER.Add(Trim(.RAE_Out_cbo_chillers5))
            myList_CHILLER.Add(Trim(.RAE_Out_cbo_chillers6))
            myList_CHILLER.Add(Trim(.RAE_Out_cbo_chillers7))
            myList_CHILLER.Add(Trim(.RAE_Out_cbo_chillers8))
            myList_CHILLER.Add(Trim(.RAE_Out_cbo_chillers9))
            myList_CHILLER.Add(Trim(.RAE_Out_cbo_chillers10))
            myList_CHILLER.Add(Trim(.RAE_Out_cbo_chillers11))
            myList_CHILLER.Add(Trim(.RAE_Out_cbo_chillers12))
            myList_CHILLER.Add(Trim(.RAE_Out_cbo_chillers13))
            myList_CHILLER.Add(Trim(.RAE_Out_cbo_chillers14))
            myList_CHILLER.Add(Trim(.RAE_Out_cbo_chillers15))
            myList_CHILLER.Add(Trim(.RAE_Out_cbo_chillers16))
            myList_CHILLER.Add(Trim(.RAE_Out_cbo_chillers17))
            myList_CHILLER.Add(Trim(.RAE_Out_cbo_chillers18))
            myList_CHILLER.Add(Trim(.RAE_Out_cbo_chillers19))
            myList_CHILLER.Add(Trim(.RAE_Out_cbo_chillers20))
            cboChiller11.DataSource = myList_CHILLER


            evaporatorPartNums.Add("Choose")

            Dim evaporatorModel As String
            Dim maxLength, evaporatorLength As Double
            Dim circuitsPerUnit As Integer
            Dim authorization As Business.UserGroup

            evaporatorLength = CDbl(Me.txt_Evap_Length.Text)
            maxLength = additionalEvaporatorLength + evaporatorLength
            circuitsPerUnit = CInt(Me.GrabCircuitsPerUnit())
            authorization = AppInfo.User.AuthorityGroup


            ' retrieves evaporator part number from database
            evaporatorModel = RaeSolutions.AirCooledChillerForm.RetrieveEvaporator( _
               .RAE_Out_cbo_chillers1, circuitsPerUnit, maxLength, authorization)
            ' adds evaporator part number to list if it is valid
            If Not evaporatorModel Is Nothing AndAlso evaporatorModel.Length > 0 Then evaporatorPartNums.Add(evaporatorModel)

            evaporatorModel = RaeSolutions.AirCooledChillerForm.RetrieveEvaporator( _
               .RAE_Out_cbo_chillers2, circuitsPerUnit, maxLength, authorization)
            If Not evaporatorModel Is Nothing AndAlso evaporatorModel.Length > 0 Then evaporatorPartNums.Add(evaporatorModel)

            evaporatorModel = RaeSolutions.AirCooledChillerForm.RetrieveEvaporator( _
               .RAE_Out_cbo_chillers3, circuitsPerUnit, maxLength, authorization)
            If Not evaporatorModel Is Nothing AndAlso evaporatorModel.Length > 0 Then evaporatorPartNums.Add(evaporatorModel)

            evaporatorModel = RaeSolutions.AirCooledChillerForm.RetrieveEvaporator( _
               .RAE_Out_cbo_chillers4, circuitsPerUnit, maxLength, authorization)
            If Not evaporatorModel Is Nothing AndAlso evaporatorModel.Length > 0 Then evaporatorPartNums.Add(evaporatorModel)

            evaporatorModel = RaeSolutions.AirCooledChillerForm.RetrieveEvaporator( _
               .RAE_Out_cbo_chillers5, circuitsPerUnit, maxLength, authorization)
            If Not evaporatorModel Is Nothing AndAlso evaporatorModel.Length > 0 Then evaporatorPartNums.Add(evaporatorModel)

            evaporatorModel = RaeSolutions.AirCooledChillerForm.RetrieveEvaporator( _
               .RAE_Out_cbo_chillers6, circuitsPerUnit, maxLength, authorization)
            If Not evaporatorModel Is Nothing AndAlso evaporatorModel.Length > 0 Then evaporatorPartNums.Add(evaporatorModel)

            evaporatorModel = RaeSolutions.AirCooledChillerForm.RetrieveEvaporator( _
               .RAE_Out_cbo_chillers7, circuitsPerUnit, maxLength, authorization)
            If Not evaporatorModel Is Nothing AndAlso evaporatorModel.Length > 0 Then evaporatorPartNums.Add(evaporatorModel)

            evaporatorModel = RaeSolutions.AirCooledChillerForm.RetrieveEvaporator( _
               .RAE_Out_cbo_chillers8, circuitsPerUnit, maxLength, authorization)
            If Not evaporatorModel Is Nothing AndAlso evaporatorModel.Length > 0 Then evaporatorPartNums.Add(evaporatorModel)

            evaporatorModel = RaeSolutions.AirCooledChillerForm.RetrieveEvaporator( _
               .RAE_Out_cbo_chillers9, circuitsPerUnit, maxLength, authorization)
            If Not evaporatorModel Is Nothing AndAlso evaporatorModel.Length > 0 Then evaporatorPartNums.Add(evaporatorModel)

            evaporatorModel = RaeSolutions.AirCooledChillerForm.RetrieveEvaporator( _
               .RAE_Out_cbo_chillers10, circuitsPerUnit, maxLength, authorization)
            If Not evaporatorModel Is Nothing AndAlso evaporatorModel.Length > 0 Then evaporatorPartNums.Add(evaporatorModel)

            evaporatorModel = RaeSolutions.AirCooledChillerForm.RetrieveEvaporator( _
               .RAE_Out_cbo_chillers11, circuitsPerUnit, maxLength, authorization)
            If Not evaporatorModel Is Nothing AndAlso evaporatorModel.Length > 0 Then evaporatorPartNums.Add(evaporatorModel)

            evaporatorModel = RaeSolutions.AirCooledChillerForm.RetrieveEvaporator( _
               .RAE_Out_cbo_chillers12, circuitsPerUnit, maxLength, authorization)
            If Not evaporatorModel Is Nothing AndAlso evaporatorModel.Length > 0 Then evaporatorPartNums.Add(evaporatorModel)

            evaporatorModel = RaeSolutions.AirCooledChillerForm.RetrieveEvaporator( _
               .RAE_Out_cbo_chillers13, circuitsPerUnit, maxLength, authorization)
            If Not evaporatorModel Is Nothing AndAlso evaporatorModel.Length > 0 Then evaporatorPartNums.Add(evaporatorModel)

            evaporatorModel = RaeSolutions.AirCooledChillerForm.RetrieveEvaporator( _
               .RAE_Out_cbo_chillers14, circuitsPerUnit, maxLength, authorization)
            If Not evaporatorModel Is Nothing AndAlso evaporatorModel.Length > 0 Then evaporatorPartNums.Add(evaporatorModel)

            evaporatorModel = RaeSolutions.AirCooledChillerForm.RetrieveEvaporator( _
               .RAE_Out_cbo_chillers15, circuitsPerUnit, maxLength, authorization)
            If Not evaporatorModel Is Nothing AndAlso evaporatorModel.Length > 0 Then evaporatorPartNums.Add(evaporatorModel)

            evaporatorModel = RaeSolutions.AirCooledChillerForm.RetrieveEvaporator( _
               .RAE_Out_cbo_chillers16, circuitsPerUnit, maxLength, authorization)
            If Not evaporatorModel Is Nothing AndAlso evaporatorModel.Length > 0 Then evaporatorPartNums.Add(evaporatorModel)

            evaporatorModel = RaeSolutions.AirCooledChillerForm.RetrieveEvaporator( _
               .RAE_Out_cbo_chillers17, circuitsPerUnit, maxLength, authorization)
            If Not evaporatorModel Is Nothing AndAlso evaporatorModel.Length > 0 Then evaporatorPartNums.Add(evaporatorModel)

            evaporatorModel = RaeSolutions.AirCooledChillerForm.RetrieveEvaporator( _
               .RAE_Out_cbo_chillers18, circuitsPerUnit, maxLength, authorization)
            If Not evaporatorModel Is Nothing AndAlso evaporatorModel.Length > 0 Then evaporatorPartNums.Add(evaporatorModel)

            evaporatorModel = RaeSolutions.AirCooledChillerForm.RetrieveEvaporator( _
               .RAE_Out_cbo_chillers19, circuitsPerUnit, maxLength, authorization)
            If Not evaporatorModel Is Nothing AndAlso evaporatorModel.Length > 0 Then evaporatorPartNums.Add(evaporatorModel)

            evaporatorModel = RaeSolutions.AirCooledChillerForm.RetrieveEvaporator( _
               .RAE_Out_cbo_chillers20, circuitsPerUnit, maxLength, authorization)
            If Not evaporatorModel Is Nothing AndAlso evaporatorModel.Length > 0 Then evaporatorPartNums.Add(evaporatorModel)

            Me.cboEvaporators.DataSource = evaporatorPartNums
         End With
      End If

      If ChillyRAEs_pass_no = 3 Then
         ChillyRAE_Parms.RAE_ChillyRAEs_pass = 3        '1 = Parms    2 = Models    3 = 8&10 deg approach
         ChillyRAE_Parms.RAE_Fouling_Factor = Val(cboFoulingFactor.SelectedItem)
         ChillyRAE_Parms.RAE_Cbo_Fluid = cboFluid.SelectedItem
         ChillyRAE_Parms.RAE_tempin = Me.LeavingFluidTemp + Val(cboTempRange.SelectedItem)
         ChillyRAE_Parms.RAE_tempot = Me.LeavingFluidTemp
         ChillyRAE_Parms.RAE_txtCondCap = (Val(TxtTonsSystemCap.Text()) * 12000) 'Val(TxtCondCap.Text())
         ChillyRAE_Parms.RAE_cboRef_Text = "R" & Me.GrabRefrigerant.Abbreviation
         ChillyRAE_Parms.RAE_cboCCM_Text = Trim(cboGlycol.SelectedItem)
         ChillyRAE_Parms.RAE_txtPctGly_Text = Val(txtPercentGlycol.Text)
         ChillyRAE_Parms.RAE_conduc = 0
         ChillyRAE_Parms.RAE_visc = 0
         ChillyRAE_Parms.RAE_spht = Val(txtSpecificHeat.Text())
         ChillyRAE_Parms.RAE_allmod = "all"
         ChillyRAE_Parms.RAE_units = "U.S. UNIT"     'METRIC
         ChillyRAE_Parms.RAE_cbo_chillers_Text = read_cooler 'Trim(txtEvaporator.Text())
         ChillyRAE_Parms.RAE_txtSpGr = 0     'Val(txtSpecificGravity.Text())
         ChillyRAE_Parms.AddToDatabase5()

         If Val(Txt_circuit_per_unit.Text()) = 4 Then
            txt4Deg.Text() = Val(ChillyRAE_Parms.RAE_Out_txt4DEG_Text) / 2
         Else
            txt4Deg.Text() = Val(ChillyRAE_Parms.RAE_Out_txt4DEG_Text) / Val(Txt_circuit_per_unit.Text())
         End If
         'TXT4DEG.ToolTip() = "Fluid PD = " & Round(Val(ChillyRAE_Parms.RAE_out_4deg_pd), 2) & "   GPM = " & Round(Val(ChillyRAE_Parms.RAE_out_4FLOW), 2)
         ToolTip1.SetToolTip(txt4Deg, "Fluid PD = " & Round(Val(ChillyRAE_Parms.RAE_Out_4DEG_PD), 2) & "   GPM = " & Round(Val(ChillyRAE_Parms.RAE_Out_4FLOW), 2))
         PD_GPM(4, 1) = Round(Val(ChillyRAE_Parms.RAE_Out_4DEG_PD), 2)
         PD_GPM(4, 2) = Round(Val(ChillyRAE_Parms.RAE_Out_4FLOW), 2)
         txt4.Text() = ToolTip1.GetToolTip(txt4Deg) 'TXT4DEG.ToolTip()

         If Val(Txt_circuit_per_unit.Text()) = 4 Then
            txt5Deg.Text() = Val(ChillyRAE_Parms.RAE_Out_txt5DEG_Text) / 2
         Else
            txt5Deg.Text() = Val(ChillyRAE_Parms.RAE_Out_txt5DEG_Text) / Val(Txt_circuit_per_unit.Text())
         End If
         ToolTip1.SetToolTip(txt5Deg, "Fluid PD = " & Round(Val(ChillyRAE_Parms.RAE_Out_5DEG_PD), 2) & "   GPM = " & Round(Val(ChillyRAE_Parms.RAE_Out_5FLOW), 2))
         PD_GPM(5, 1) = Round(Val(ChillyRAE_Parms.RAE_Out_5DEG_PD), 2)
         PD_GPM(5, 2) = Round(Val(ChillyRAE_Parms.RAE_Out_5FLOW), 2)
         txt5.Text() = ToolTip1.GetToolTip(txt5Deg)

         If Val(Txt_circuit_per_unit.Text()) = 4 Then
            txt6Deg.Text() = Val(ChillyRAE_Parms.RAE_Out_txt6DEG_Text) / 2
         Else
            txt6Deg.Text() = Val(ChillyRAE_Parms.RAE_Out_txt6DEG_Text) / Val(Txt_circuit_per_unit.Text())
         End If
         ToolTip1.SetToolTip(txt6Deg, "Fluid PD = " & Round(Val(ChillyRAE_Parms.RAE_Out_6DEG_PD), 2) & "   GPM = " & Round(Val(ChillyRAE_Parms.RAE_Out_6FLOW), 2))
         PD_GPM(6, 1) = Round(Val(ChillyRAE_Parms.RAE_Out_6DEG_PD), 2)
         PD_GPM(6, 2) = Round(Val(ChillyRAE_Parms.RAE_Out_6FLOW), 2)
         txt6.Text() = ToolTip1.GetToolTip(txt6Deg)
         If Val(Txt_circuit_per_unit.Text()) = 4 Then
            txt7Deg.Text() = Val(ChillyRAE_Parms.RAE_Out_txt7DEG_Text) / 2
         Else
            txt7Deg.Text() = Val(ChillyRAE_Parms.RAE_Out_txt7DEG_Text) / Val(Txt_circuit_per_unit.Text())
         End If
         ToolTip1.SetToolTip(txt7Deg, "Fluid PD = " & Round(Val(ChillyRAE_Parms.RAE_Out_7DEG_PD), 2) & "   GPM = " & Round(Val(ChillyRAE_Parms.RAE_Out_7FLOW), 2))
         PD_GPM(7, 1) = Round(Val(ChillyRAE_Parms.RAE_Out_7DEG_PD), 2)
         PD_GPM(7, 2) = Round(Val(ChillyRAE_Parms.RAE_Out_7FLOW), 2)
         txt7.Text() = ToolTip1.GetToolTip(txt7Deg)
         If Val(Txt_circuit_per_unit.Text()) = 4 Then
            txt8Deg.Text() = Val(ChillyRAE_Parms.RAE_Out_txt8DEG_Text) / 2
         Else
            txt8Deg.Text() = Val(ChillyRAE_Parms.RAE_Out_txt8DEG_Text) / Val(Txt_circuit_per_unit.Text())
         End If
         ToolTip1.SetToolTip(txt8Deg, "Fluid PD = " & Round(Val(ChillyRAE_Parms.RAE_Out_8DEG_PD), 2) & "   GPM = " & Round(Val(ChillyRAE_Parms.RAE_Out_8FLOW), 2))
         PD_GPM(8, 1) = Round(Val(ChillyRAE_Parms.RAE_Out_8DEG_PD), 2)
         PD_GPM(8, 2) = Round(Val(ChillyRAE_Parms.RAE_Out_8FLOW), 2)
         txt8.Text() = ToolTip1.GetToolTip(txt8Deg)
         If Val(Txt_circuit_per_unit.Text()) = 4 Then
            txt9Deg.Text() = Val(ChillyRAE_Parms.RAE_Out_txt9DEG_Text) / 2
         Else
            txt9Deg.Text() = Val(ChillyRAE_Parms.RAE_Out_txt9DEG_Text) / Val(Txt_circuit_per_unit.Text())
         End If
         ToolTip1.SetToolTip(txt9Deg, "Fluid PD = " & Round(Val(ChillyRAE_Parms.RAE_Out_9DEG_PD), 2) & "   GPM = " & Round(Val(ChillyRAE_Parms.RAE_Out_9FLOW), 2))
         PD_GPM(9, 1) = Round(Val(ChillyRAE_Parms.RAE_Out_9DEG_PD), 2)
         PD_GPM(9, 2) = Round(Val(ChillyRAE_Parms.RAE_Out_9FLOW), 2)
         txt9.Text() = ToolTip1.GetToolTip(txt9Deg)
         If Val(Txt_circuit_per_unit.Text()) = 4 Then
            txt10Deg.Text() = Val(ChillyRAE_Parms.RAE_Out_txt10DEG_Text) / 2
         Else
            txt10Deg.Text() = Val(ChillyRAE_Parms.RAE_Out_txt10DEG_Text) / Val(Txt_circuit_per_unit.Text())
         End If
         ToolTip1.SetToolTip(txt10Deg, "Fluid PD = " & Round(Val(ChillyRAE_Parms.RAE_Out_10DEG_PD), 2) & "   GPM = " & Round(Val(ChillyRAE_Parms.RAE_Out_10FLOW), 2))
         PD_GPM(10, 1) = Round(Val(ChillyRAE_Parms.RAE_Out_10DEG_PD), 2)
         PD_GPM(10, 2) = Round(Val(ChillyRAE_Parms.RAE_Out_10FLOW), 2)
         txt10.Text() = ToolTip1.GetToolTip(txt10Deg)
         If Val(Txt_circuit_per_unit.Text()) = 4 Then
            txt11Deg.Text() = Val(ChillyRAE_Parms.RAE_Out_txt11DEG_Text) / 2
         Else
            txt11Deg.Text() = Val(ChillyRAE_Parms.RAE_Out_txt11DEG_Text) / Val(Txt_circuit_per_unit.Text())
         End If
         ToolTip1.SetToolTip(txt11Deg, "Fluid PD = " & Round(Val(ChillyRAE_Parms.RAE_Out_11DEG_PD), 2) & "   GPM = " & Round(Val(ChillyRAE_Parms.RAE_Out_11FLOW), 2))
         PD_GPM(11, 1) = Round(Val(ChillyRAE_Parms.RAE_Out_11DEG_PD), 2)
         PD_GPM(11, 2) = Round(Val(ChillyRAE_Parms.RAE_Out_11FLOW), 2)
         txt11.Text() = ToolTip1.GetToolTip(txt11Deg)
         If Val(Txt_circuit_per_unit.Text()) = 4 Then
            txt12Deg.Text() = Val(ChillyRAE_Parms.RAE_Out_txt12DEG_Text) / 2
         Else
            txt12Deg.Text() = Val(ChillyRAE_Parms.RAE_Out_txt12DEG_Text) / Val(Txt_circuit_per_unit.Text())
         End If
         ToolTip1.SetToolTip(txt12Deg, "Fluid PD = " & Round(Val(ChillyRAE_Parms.RAE_Out_12DEG_PD), 2) & "   GPM = " & Round(Val(ChillyRAE_Parms.RAE_Out_12FLOW), 2))
         PD_GPM(12, 1) = Round(Val(ChillyRAE_Parms.RAE_Out_12DEG_PD), 2)
         PD_GPM(12, 2) = Round(Val(ChillyRAE_Parms.RAE_Out_12FLOW), 2)
         txt12.Text() = ToolTip1.GetToolTip(txt12Deg)
      End If
   End Sub


   ' fills freeze point and suction temperature textboxes   
   Public Sub CalculateFreezePoint()
      ' grabs glycol percentage
      Dim glycolPercentage As Double = CDbl(Me.txtPercentGlycol.Text.Trim)

      ' checks if glycol percentage is outside range
      If Business.Intelligence.Chillers.FreezingPoint.IsGlycolPercentageOutsideRange(glycolPercentage) Then
         Ui.MessageBox.Show("The glycol percentage must be in the range 0% to 60%; the glycol percentage is reset to 20%")
         Me.txtPercentGlycol.Text = "20"   ' text change causes this method to be called again
         Exit Sub ' exit sub; this method will be called by text changed event handler
      End If

      If Me.cboFluid.SelectedItem.ToString = "Water" Then
         ' sets freezing point textbox
         Me.txtFreezingPoint.Text = Business.Intelligence.Chillers.FreezingPoint.FreezingPointForWater
         ' sets recommended minimum suction temperature textbox
         Me.txtMinSuctionTemp.Text = Business.Intelligence.Chillers.FreezingPoint.RecommendedMinSuctionTemperatureForWater
      Else
         Dim glycol As Glycol
         Dim freezingPoint As Business.Intelligence.Chillers.FreezingPoint

         ' parses combobox to get glycol enumerator
         glycol = DirectCast([Enum].Parse(GetType(Glycol), Me.cboGlycol.SelectedItem.ToString), Glycol)
         ' constructs freezing point object
         freezingPoint = New Business.Intelligence.Chillers.FreezingPoint(glycol, glycolPercentage)

         ' sets freezing point textbox
         Me.txtFreezingPoint.Text = freezingPoint.FreezingPoint.ToString
         ' sets recommended minimum suction temperature textbox
         Me.txtMinSuctionTemp.Text = freezingPoint.RecommendedMinSuctionTemperature.ToString
      End If
   End Sub



   Private Sub start_cal()
      ok_to_print_SPACE = False

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

      If cboSystem.SelectedItem = "FULL" And Val(Txt_circuit_per_unit.Text()) = 2 Or Val(Txt_circuit_per_unit.Text()) = 4 Then
         ok_to_print = False
         Running_Circuit_no = 1
         CalculatePage()

         ok_to_print = True
         ok_to_print_SPACE = True
         Running_Circuit_no = 2
         CalculatePage()
      ElseIf cboSystem.SelectedItem = "FULL" And Val(Txt_circuit_per_unit.Text()) = 1 Then
         Running_Circuit_no = 1
         ok_to_print_SPACE = True
         CalculatePage()
      ElseIf cboSystem.SelectedItem = "HALF" Then
         If radCircuit1.Checked = True Then
            Running_Circuit_no = 1
         End If
         If radCircuit2.Checked = True Then
            ok_to_print_SPACE = True
            Running_Circuit_no = 2
         End If
         CalculatePage()
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
      gRef = ""               'Refrigerant type

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


   Private Sub CalculatePage()
      Dim Compr_KW1 As Double
      Dim COMPR_KW_COUNTER As Double
      Dim wattsHzMultiplier, ampsHzMultiplier, capacityHzMultiplier As Double
      Dim capacityR507Multiplier, wattsR507Multiplier As Double     ' multiplier for compressors
      Dim range As Double                  'RANGE IN DEG. F.
      Dim CC As Double                 'COND. CAP. @ 25 DEG TEMP. DIF.
      Dim Exit_Glycol As Boolean           'TEST FOR EXITING GLYCOL PROCEDURE

      COMPR_KW_COUNTER = 1
      Page_Cal_Pass = Page_Cal_Pass + 1
      CalculateFreezePoint() 'set freeze point and suction temp textboxes

      Dim APP_Change As Double
      Dim count_passes As Single = 1
      lblLimits.Visible = False
      lblLimits.Text() = "Points outside operating limits omitted, contact factory for selection."
      If AppInfo.User.AuthorityGroup <= 2 Then
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

      TextBox1.Text() = ""
      grdResults.Visible = True
      change_coil_desc()
      Dim my_Counter_pass As Single
      my_Counter_pass = 0
      Dim nextCuritem As Integer
      nextCuritem = 0

      If cboSystem.SelectedItem = "FULL" And Val(Txt_circuit_per_unit.Text()) = 2 _
      Or Val(Txt_circuit_per_unit.Text()) = 4 Then
         If ok_to_print = True And nextCuritem = 0 Then
            Me.DropDownList3.DataSource = Nothing
            Me.DropDownList3.DataSource = gArrHidCircuit1Display
         End If
      End If

      ResetVariables()

      Dim rightNow As DateTime = DateTime.Now
      Dim Current_TIME As String = rightNow.ToString("hhmmss")
      Dim Current_date As String = rightNow.ToString("MM/dd/yyyy")
      Dim Current_date1 As String = rightNow.ToString("yyyyMMdd")

      Dim temp_Pass_Filename As String = AppInfo.User.Username & Current_TIME & Current_date1
      PASS_FILENAME1 = temp_Pass_Filename  'for pdf
      MyFileNameMDB = temp_Pass_Filename & ".MDB"
      PASS_FILENAME = MyFileNameMDB

      Dim MyFile As System.IO.FileInfo
      Dim MyCopiedFile As System.IO.FileInfo

      MyFile = New System.IO.FileInfo(DataAccess.Common.MasterDbPath)
      'copy database, set column headings in database
      MyCopiedFile = MyFile.CopyTo(AppInfo.AppFolderPath & "Reports\" & MyFileNameMDB, True)
      'set specific heat and gravity
      ChillyRAEs_pass_no = 1  '1 = Parms    2 = Models    3 = 8&10 deg approach
      Call_ChillyRAE_Parms()
      'fills condenser capacity textbox
      Call_CoFan()
      'fill approach and evaporator capacity
      ChillyRAEs_pass_no = 3  '1 = Parms    2 = Models    3 = 8&10 deg approach
      Call_ChillyRAE_Parms()

      'check approach for errors
      If rbOther_Approch.Checked = True Then
         If Val(Txt8Deg_1.Text()) = 0 Or Val(Txt10Deg_1.Text()) = 0 Then
            TextBox1.Text() = "Please enter a valid 8 and 10 deg. approach for circuit 1"
            grdResults.Visible = False
            Exit Sub
         End If
         If Val(Txt_circuit_per_unit.Text()) > 1 Then
            If Val(Txt8Deg_2.Text()) = 0 Or Val(Txt10Deg_2.Text()) = 0 Then
               TextBox1.Text() = "Please enter a valid 8 and 10 deg. approach for circuit 2"
               grdResults.Visible = False
               Exit Sub
            End If
         End If
      Else
         If rb6_8.Checked = True Then
            If Val(txt6Deg.Text()) = 0 Or Val(txt8Deg.Text()) = 0 Then
               TextBox1.Text() = "Please select a different vessel."
               grdResults.Visible = False
               Exit Sub
            End If
         ElseIf rb7_9.Checked = True Then
            If Val(txt7Deg.Text()) = 0 Or Val(txt9Deg.Text()) = 0 Then
               TextBox1.Text() = "Please select a different vessel."
               grdResults.Visible = False
               Exit Sub
            End If
         ElseIf rb8_10.Checked = True Then
            If Val(txt8Deg.Text()) = 0 Or Val(txt10Deg.Text()) = 0 Then
               TextBox1.Text() = "Please select a different vessel."
               grdResults.Visible = False
               Exit Sub
            End If
         ElseIf rb9_11.Checked = True Then
            If Val(txt9Deg.Text()) = 0 Or Val(txt11Deg.Text()) = 0 Then
               TextBox1.Text() = "Please select a different vessel."
               grdResults.Visible = False
               Exit Sub
            End If
         ElseIf rb10_12.Checked = True Then
            If Val(txt10Deg.Text()) = 0 Or Val(txt12Deg.Text()) = 0 Then
               TextBox1.Text() = "Please select a different vessel."
               grdResults.Visible = False
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
      Dim volts As Integer = CInt(Me.cboVolts.SelectedItem)  'set at 230
      gRef = Me.GrabRefrigerant.Abbreviation
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
         capacityHzMultiplier = 0.833
         wattsHzMultiplier = 0.833
         ampsHzMultiplier = 1  'Changed per Dision 3/5/03 was 0.61
         If volts = 415 Then
            capacityHzMultiplier = 1
            wattsHzMultiplier = 1
            ampsHzMultiplier = 1
         End If
      ElseIf cboHertz.SelectedItem = "60" Then
         capacityHzMultiplier = 1
         wattsHzMultiplier = 1
         ampsHzMultiplier = 1
      Else
         Me.TextBox1.Text = TextBox1.Text & "Choose Hertz Operation - 50/60"
         Exit Sub
      End If

      If fanFileName = "CFM Per Fan >>>" Then
         Me.fanWatts = Val(Me.txtFanWatts1.Text)
         capacityHzMultiplier = 1
         wattsHzMultiplier = 1
         ampsHzMultiplier = 1
         If Me.fanWatts = 0 Then
            Me.fanWatts = 1100
         End If
      End If

      Me.txtFanWatts1.Text = Me.fanWatts.ToString

      If cboSystem.SelectedItem <> "FULL" And cboSystem.SelectedItem <> "HALF" Then
         Me.TextBox1.Text = Me.TextBox1.Text & "Make Selection for system - HALF/FULL" : Exit Sub : End If

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
            coolingMedia = cboGlycol.SelectedItem
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

      Dim compressor As String
      Dim compressorFile As String
      Dim compressorTable As DataTable
        Dim coefs As Business.Entities.CompressorCoefficients5

      ' grabs user selected compressor
      compressor = Me.GrabCompressor(Me.Running_Circuit_no)
      ' retrieves row of compressor data including compressor file name
      compressorTable = DataAccess.CompressorDataAccess.RetrieveCompressor(compressor, Me.GrabRefrigerant.Abbreviation)
      ' sets compressor file name
      compressorFile = compressorTable.Rows(0).Item("COMPFILE")
      ' retrieves compressor coefficients
      coefs = DataAccess.CompressorDataAccess.RetrieveCompressorCoefficients(compressorFile)

      ' sets tool tip
      If Me.Running_Circuit_no = 1 Then
         Me.ToolTip1.SetToolTip(Me.txtCompressor1, compressorFile)
      ElseIf Me.Running_Circuit_no = 2 Then
         Me.ToolTip1.SetToolTip(Me.txtCompressor2, compressorFile)
      End If


      For TA = (TA1 - 8) To (TA1 + 8) Step 4
         If TA > TA1 + 15 Then GoTo 1000

         ' DEBUG: counting number of loops
         'Static counter As Integer = 0
         'counter += 1
         'Console.WriteLine("Counter: {0}, TA: {1}", counter.ToString, TA.ToString)

         'For TE = TE1 To TE2 Step 15
         For TE = 30 To 45 Step 15

            ' DEBUG: counting number of loops
            'Static counter2 As Integer = 0
            'counter2 += 1
            'Console.WriteLine("Counter: {0}, TE: {1}", counter2.ToString, TE.ToString)

            T = TE + 459.69

            '*********** Start Select_P_PE() ***********
            If gRef = "22" Or gRef = "22H" Or gRef = "22L" Or gRef = "22M" Then
               P = Round(29.35754453 + (-3845.193152 / T) + (-7.86103122 * (Log(T) / Log(10))) + (0.002190939 * T) + ((0.445746703 * (686.1 - T)) / T) * (Log(686.1 - T) / Log(10)), 10)
               PE = Round(10 ^ P, 10)
            ElseIf gRef = "404a" Or gRef = "404aH" Or gRef = "404aL" Or gRef = "404aM" Then
               P = 72.1209 + (-7315.14 / T) + ((-8.717729) * (Log(T)) + (0.0000051875 * T ^ 2))
               PE = 2.7182818 ^ P
            ElseIf gRef = "507c" Or gRef = "507c" Or gRef = "507cH" Or gRef = "507cL" Or gRef = "507cM" Then
               P = 29.24862663 + (-6980.5944 / T) + (-0.03143806111 * T) + (0.00002034543662 * T ^ 2)
               PE = 2.7182818 ^ P
            ElseIf gRef = "502" Then
               P = 10.644955 + (-3671.153813 / T) + (-0.369835 * (Log(T) / Log(10))) + (-0.001746352 * T) + ((0.8161139 * (654 - T)) / T) * (Log(654 - T) / Log(10))
               PE = 10 ^ P
            ElseIf gRef = "407c" Or gRef = "407cH" Or gRef = "407cL" Or gRef = "R407cM" Then
               P = 78.3549 + (-8101.06 / T) + (-9.51789 * Log(T)) + (0.0000053558 * (T ^ 2))
               PE = 2.7182818 ^ P
            ElseIf gRef = "134a" Or gRef = "134aH" Or gRef = "134aL" Or gRef = "134aM" Then
               P = 22.98993635 + (-7243.876722 / T) + (-0.013362956 * T) + (0.00000692966 * T ^ 2) + ((0.1995548 * (674.72514 - T)) / T) * (Log(674.72514 - T))
               PE = 2.7182818 ^ P
            End If
            '*********** End ***************************
            'TE for loop
            TC = TA + 10
            Z = 1
            GoTo SS800
SS730:      TC = TC + 10
            GoTo SS800
SS750:      TC = TC + 5
            GoTo SS800
SS770:      TC = TC + 1
            GoTo SS800
SS790:      TC = TC + 0.2

SS800:      'H1 = (TC - TA) / M
            'H1 = (1000 * CDbl(Me.txtCondenserCapacity1.Text)) * ((0.0375 * TC) - 2.9375 + (0.025) * (78 - TA))
            T = TC + 459.69

            '***************** Start Select_P_PC() ********
            If gRef = "22" Or gRef = "22H" Or gRef = "22L" Or gRef = "22M" Then
               P = Round(29.35754453 + (-3845.193152 / T) + (-7.86103122 * (Log(T) / Log(10))) + (0.002190939 * T) + ((0.445746703 * (686.1 - T)) / T) * (Log(686.1 - T) / Log(10)), 10)
               PC = Round(10 ^ P, 10)
            ElseIf gRef = "404a" Or gRef = "404aH" Or gRef = "404aL" Or gRef = "404aM" Then
               P = 57.5895 + (-6526.55 / T) + ((-6.58061) * (Log(T)) + (0.00000393732 * T ^ 2))
               PC = 2.7182818 ^ P
            ElseIf gRef = "507c" Or gRef = "507cH" Or gRef = "507cL" Or gRef = "507cM" Then
               P = 29.24862663 + (-6980.5944 / T) + (-0.03143806111 * T) + (0.00002034543662 * T ^ 2)
               PC = 2.7182818 ^ P
            ElseIf gRef = "502" Then
               P = 10.644955 + (-3671.153813 / T) + (-0.369835 * (Log(T) / Log(10))) + (-0.001746352 * T) + ((0.8161139 * (654 - T)) / T) * (Log(654 - T) / Log(10))
               PC = 10 ^ P
            ElseIf gRef = "407c" Or gRef = "407cH" Or gRef = "407cL" Or gRef = "407cM" Then
               P = 43.3622 + (-6020.28 / T) + (-4.3987 * Log(T)) + (0.00000212036 * (T ^ 2))
               PC = 2.7182818 ^ P
            ElseIf gRef = "134a" Or gRef = "134aH" Or gRef = "134aL" Or gRef = "134aM" Then
               P = 22.98993635 + (-7243.876722 / T) + (-0.013362956 * T) + (0.00000692966 * T ^ 2) + ((0.1995548 * (674.72514 - T)) / T) * (Log(674.72514 - T))
               PC = 2.7182818 ^ P
            End If
            '***************** end ************************

            'SET MULTIPLYING FACTORS FOR 507
            If gRef = "507c" Or gRef = "507cH" Or gRef = "507cL" Or gRef = "507cM" Then
               capacityR507Multiplier = 1.03
               wattsR507Multiplier = 1.02
            End If

            With coefs
SS840:              Q = (.capacity0 + (.capacity1 * TC) + (.capacity2 * PE) + ((.capacity3 * PE) * PC) + (.capacity4 * PC) / Sqrt(PE)) * NC * capacityHzMultiplier * capacityR507Multiplier
SS850:              W = (.watt0 + (.watt1 * TC) + (.watt2 * PE) + ((.watt3 * PE) * PC) + (.watt4 * PC) / Sqrt(PE)) * NC * wattsHzMultiplier * wattsR507Multiplier
SS860:              A = (.amp0 + (.amp1 * TC) + (.amp2 * PE) + ((.amp3 * PE) * PC) + (.amp4 * PC) / Sqrt(PE)) * NC * ampsHzMultiplier * wattsR507Multiplier
            End With

            'H2 = Q + (3.413 * W)
            H2 = Q + (3.415 * W)

            'TE for loop
            If Z = 1 Then GoTo SS920
            If Z = 2 Then GoTo SS940
            If Z = 3 Then GoTo SS960
            If Z = 4 Then GoTo SS980
SS920:      If H1 < H2 Then GoTo SS730
            TC = TC - 10 : Z = 2 : GoTo SS750
SS940:      If H1 < H2 Then GoTo SS750
            TC = TC - 5 : Z = 3 : GoTo SS770
SS960:      If H1 < H2 Then GoTo SS770
            TC = TC - 1 : Z = 4 : GoTo SS790
SS980:      If H1 < H2 Then GoTo SS790
            '******** END *********************

            If TE = TE2 Then GoTo 400
            Q1 = Q
         Next TE

400:     A = (Q - Q1) / 15
         On Error GoTo ERR_404_1 'Resume Next 
410:     B = TE - (Q / A)
         GoTo 420  'skip error

ERR_404_1:
         TextBox1.Text() = "AN ERROR HAS OCCURED, Contact factory for Rating of units outside the operating limits"
         grdResults.Visible = False
         Exit Sub

420:     M1 = (TE - B) / Q
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
450:        'TE = TW - (APP_Change + cbo_Suction_line_loss.SelectedItem)
            TE = TW - 10

            EE = (Q9 - Q8) / 2
470:        F = TE + (Q9 / EE)
480:        g = (TE - F) / Q9
490:        TE = ((B * g) - (F * M1)) / (g - M1)
500:
            '*************Start  Run680() **********
S680:       T = TE + 459.69

            '*********** Start Select_P_PE() ***********
            If gRef = "22" Or gRef = "22H" Or gRef = "22L" Or gRef = "22M" Then
               P = Round(29.35754453 + (-3845.193152 / T) + (-7.86103122 * (Log(T) / Log(10))) + (0.002190939 * T) + ((0.445746703 * (686.1 - T)) / T) * (Log(686.1 - T) / Log(10)), 10)
               PE = Round(10 ^ P, 10)
            ElseIf gRef = "404a" Or gRef = "404aH" Or gRef = "404aL" Or gRef = "404aM" Then
               P = 72.1209 + (-7315.14 / T) + ((-8.717729) * (Log(T)) + (0.0000051875 * T ^ 2))
               PE = 2.7182818 ^ P
            ElseIf gRef = "507c" Or gRef = "507cH" Or gRef = "507cL" Or gRef = "507cM" Then
               P = 29.24862663 + (-6980.5944 / T) + (-0.03143806111 * T) + (0.00002034543662 * T ^ 2)
               PE = 2.7182818 ^ P
            ElseIf gRef = "502" Then
               P = 10.644955 + (-3671.153813 / T) + (-0.369835 * (Log(T) / Log(10))) + (-0.001746352 * T) + ((0.8161139 * (654 - T)) / T) * (Log(654 - T) / Log(10))
               PE = 10 ^ P
            ElseIf gRef = "407c" Or gRef = "407cH" Or gRef = "407cL" Or gRef = "407cM" Then
               P = 78.3549 + (-8101.06 / T) + (-9.51789 * Log(T)) + (0.0000053558 * (T ^ 2))
               PE = 2.7182818 ^ P
            ElseIf gRef = "134a" Or gRef = "134aH" Or gRef = "134aL" Or gRef = "134aM" Then
               P = 22.98993635 + (-7243.876722 / T) + (-0.013362956 * T) + (0.00000692966 * T ^ 2) + ((0.1995548 * (674.72514 - T)) / T) * (Log(674.72514 - T))
               PE = 2.7182818 ^ P
            End If
            '*********** End ***************************
            'TW for loop
S710:       TC = TA + 10
            Z = 1
            GoTo S800
S730:       TC = TC + 10
            GoTo S800
S750:       TC = TC + 5
            GoTo S800
S770:       TC = TC + 1
            GoTo S800
S790:       TC = TC + 0.2
S800:       'H1 = (TC - TA) / M
            'H1 = (1000 * CDbl(Me.txtCondenserCapacity1.Text)) * ((0.0375 * TC) - 2.9375 + (0.025) * (78 - TA))
            T = TC + 459.69

            '***************** Start Select_P_PC() ********
            If gRef = "22" Or gRef = "22H" Or gRef = "22L" Or gRef = "22M" Then
               P = Round(29.35754453 + (-3845.193152 / T) + (-7.86103122 * (Log(T) / Log(10))) + (0.002190939 * T) + ((0.445746703 * (686.1 - T)) / T) * (Log(686.1 - T) / Log(10)), 10)
               PC = Round(10 ^ P, 10)
            ElseIf gRef = "404a" Or gRef = "404aH" Or gRef = "404aL" Or gRef = "404aM" Then
               P = 57.5895 + (-6526.55 / T) + ((-6.58061) * (Log(T)) + (0.00000393732 * T ^ 2))
               PC = 2.7182818 ^ P
            ElseIf gRef = "507c" Or gRef = "507cH" Or gRef = "507cL" Or gRef = "507cM" Then
               P = 29.24862663 + (-6980.5944 / T) + (-0.03143806111 * T) + (0.00002034543662 * T ^ 2)
               PC = 2.7182818 ^ P
            ElseIf gRef = "502" Then
               P = 10.644955 + (-3671.153813 / T) + (-0.369835 * (Log(T) / Log(10))) + (-0.001746352 * T) + ((0.8161139 * (654 - T)) / T) * (Log(654 - T) / Log(10))
               PC = 10 ^ P
            ElseIf gRef = "407c" Or gRef = "407cH" Or gRef = "407cL" Or gRef = "407cM" Then
               P = 43.3622 + (-6020.28 / T) + (-4.3987 * Log(T)) + (0.00000212036 * (T ^ 2))
               PC = 2.7182818 ^ P
            ElseIf gRef = "134a" Or gRef = "134aH" Or gRef = "134aL" Or gRef = "134aM" Then
               P = 22.98993635 + (-7243.876722 / T) + (-0.013362956 * T) + (0.00000692966 * T ^ 2) + ((0.1995548 * (674.72514 - T)) / T) * (Log(674.72514 - T))
               PC = 2.7182818 ^ P
            End If
            '***************** end ************************

            'SET MULTIPLYING FACTORS FOR 507
            If gRef = "507c" Or gRef = "507cH" Or gRef = "507cL" Or gRef = "507cM" Then
               capacityR507Multiplier = 1.03
               wattsR507Multiplier = 1.02
            End If
            With coefs
S840:               Q = (.capacity0 + (.capacity1 * TC) + (.capacity2 * PE) + ((.capacity3 * PE) * PC) + (.capacity4 * PC) / Sqrt(PE)) * NC * capacityHzMultiplier * capacityR507Multiplier
S850:               W = (.watt0 + (.watt1 * TC) + (.watt2 * PE) + ((.watt3 * PE) * PC) + (.watt4 * PC) / Sqrt(PE)) * NC * wattsHzMultiplier * wattsR507Multiplier
S860:               A = (.amp0 + (.amp1 * TC) + (.amp2 * PE) + ((.amp3 * PE) * PC) + (.amp4 * PC) / Sqrt(PE)) * NC * ampsHzMultiplier * wattsR507Multiplier
            End With

            'H2 = Q + (3.413 * W)
            H2 = Q + (3.415 * W)

            'TW for loop
S880:       If Z = 1 Then GoTo S920
S890:       If Z = 2 Then GoTo S940
S900:       If Z = 3 Then GoTo S960
S910:       If Z = 4 Then GoTo S980

            'Z = 1
S920:       If H1 < H2 Then GoTo S730
S930:       TC = TC - 10 : Z = 2 : GoTo S750

            'Z = 2
S940:       If H1 < H2 Then GoTo S750
S950:       TC = TC - 5 : Z = 3 : GoTo S770

            'Z = 3
S960:       If H1 < H2 Then GoTo S770
S970:       TC = TC - 1 : Z = 4 : GoTo S790

            'Z = 4
S980:       If H1 < H2 Then GoTo S790

            '*************end***********************

            If CR_S = vbYes Then Q = Q * 1.04

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

            'additional watts from fans and pump
            'XW = (CDbl(Me.txtFanWatts.Text) + CDbl(Me.txtPumpWatts.Text)) / 1000

            KW = W / 1000

550:        'ER = Q * 12000 / W
            ER = KW / Q
560:        'Compr_KW1 = Round(W / 1000, 1)

            'KW = Compr_KW1 + Round(((Me.fanWatts * NF) / 1000), 1)    'add fan watts to make unit K Watts DBG 3/12/03
570:        'EZ = Q * 12000 / (W + (Me.fanWatts * NF))
            'EZ = (KW + XW) / Q

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
                     compressor, Me.GrabMinSuctionTemperature(), AppInfo.User.AuthorityGroup)

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
                     Me.GrabRefrigerant.Abbreviation, compressor, Me.GrabMinSuctionTemperature(), AppInfo.User.AuthorityGroup)


                  'EZ = ((Q + Q_2) * 12000) / ((W + W_2) + (Me.fanWatts * (NF + NF_2)))     'Recal Unit EER
                  'EZ = Q * 12000 / (W + (XW * 1000))
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

               ok_to_show = Business.Intelligence.CompressorService.IsCompressorSafe(TE, TC, TE, TW, Me.GrabRefrigerant.Abbreviation, compressor, _
                  Me.GrabMinSuctionTemperature(), AppInfo.User.AuthorityGroup)

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


            Dim reportDatabasePath As String = AppInfo.AppFolderPath & "Reports\" & MyFileNameMDB
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
                     Me.GrabRefrigerant.Abbreviation, compressor, Me.GrabMinSuctionTemperature(), AppInfo.User.AuthorityGroup)
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

               ok_to_show = Business.Intelligence.CompressorService.IsCompressorSafe(TE, TC, TE, TW, Me.GrabRefrigerant.Abbreviation, compressor, _
                  Me.GrabMinSuctionTemperature(), AppInfo.User.AuthorityGroup)
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
                  SET_PD = (((GP + GP_2) / PD_GPM(COUNT_PD_GPM, 2)) ^ 2) * PD_GPM(COUNT_PD_GPM, 1)
                  Hold_Set_PD(count_passes) = SET_PD

                  Me.insertResults(TW, TA, (TE + TE_2) / 2, (TC + TC_2) / 2, Q + Q_2, _
                     KW + KW_2, GP + GP_2, SET_PD, (ER + ER_2) / 2, EZ)
               End If
            Else
               COUNT_PD_GPM = Round(TW - TE, 0)
               SET_PD = ((GP / PD_GPM(COUNT_PD_GPM, 2)) ^ 2) * PD_GPM(COUNT_PD_GPM, 1)
               Hold_Set_PD(count_passes) = SET_PD

               Me.insertResults( _
                  TW, TA, TE, TC, Q, KW, GP, SET_PD, ER, EZ)
            End If

SKIP_DATABASE_BUILDER_TABLE1:
            count_passes = count_passes + 1

            If Me.LeavingFluidTemp + 4 = TW Then
               If ok_to_print_SPACE = True And Me.AmbientTemp + cboTempRange.SelectedItem <> TA Then
                  Me.insertBlankRowInResults()
               End If
            End If

600:        If TW = Me.LeavingFluidTemp - 2 Then GoTo 610 Else GoTo 630
610:        TW = Me.LeavingFluidTemp - 1
620:        GoTo 450
630:        If TW = Me.LeavingFluidTemp - 1 Then GoTo 640 Else GoTo 650
640:        TW = Me.LeavingFluidTemp - 2
650:     Next TW
660:  Next TA

1000: If Page_Cal_Pass = 1 Then
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
      Me.FillDatagrid()
Skip_Print_or_Cal:

      'delete Circuit 1 database
      If Me.cboSystem.SelectedItem() = "FULL" And Val(Txt_circuit_per_unit.Text) = 2 _
      Or Val(Txt_circuit_per_unit.Text) = 4 Then
         'if ok_to_print = false and if statement above is true then
         'this CalculatePage() is calculating circuit 1 of 2
         If ok_to_print = False Then
            ' deletes circuit 1 database. If there are multiple circuits,
            '  it is never filled or used; only circuit 2 database is used.
            Dim dbPath As String = AppInfo.AppFolderPath & "Reports\" & Me.MyFileNameMDB
            Io.FileTasks.Delete(dbPath)
         End If
      End If
   End Sub


   'Private Sub CreateReport()

   '   ' Copies table from newly created, temporary database [UserName][Date].mdb to master30.mdb. 
   '   '  This temporary copy of data is done because crystal reports needs a database connection when the form is created.
   '   '  Since this new database did not exist during design time, the data is copied to a database (Master30) that 
   '   '  did exist during design time.

   '   Dim tempDbPath, dbPath, line As String
   '   Dim chillerTable As DataTable
   '   Dim report As New CrEngine.ReportDocument()
   '   Dim reportForm As New Rae.Reporting.CrystalReports.ReportViewerForm()
   '   Dim field As Rae.Reporting.CrystalReports.SingleParameterFieldDefinition
   '   Dim fields As CrEngine.ParameterFieldDefinitions

   '   report.Load(Reports.FilePaths.AirCooledChillerRatingReportFilePath)

   '   Dim chillerModel, condenser, evaporator, compressor, fluid, circuit, limits, temperatureRange As String
   '   Dim evaporator8, evaporator10, condenserCapacity, fan, catalog, compressorFileName1, compressorFileName2 As String
   '   Dim numFans As Double


   '   ' sets temporary database path
   '   tempDbPath = AppInfo.AppFolderPath & "Reports\" & MyFileNameMDB
   '   ' sets permanent report database path
   '   dbPath = DataAccess.Common.MasterDbPath
   '   ' line break
   '   line = System.Environment.NewLine

   '   ' copies results from temporary database to permanent report database
   '   '
   '   ' retrieves chiller results from temporary database
   '   chillerTable = DataAccess.Chillers.ChillerDataAccess.RetrieveChillerResults(tempDbPath)
   '   ' inserts chiller results into the table that the report is bound to
   '   DataAccess.Chillers.ChillerDataAccess.InsertChillerResults(chillerTable)

   '   'sets database location so it's not pointing to database location on the development computer
   '   Try
   '      report.DataSourceConnections.Item(0).SetConnection(dbPath, dbPath, "", "")
   '   Catch ex As Exception
   '      Ui.MessageBox.Show("Attempt to set the database connection for the report failed." & line & dbPath & line & ex.ToString)
   '   End Try

   '   ' sets field parameters to a report's fields
   '   fields = report.DataDefinition.ParameterFields
   '   ' constructs field object
   '   field = New Rae.Reporting.CrystalReports.SingleParameterFieldDefinition(fields)




   '   ' sets value of parameters to be passed
   '   ' -------------------------------------

   '   compressorFileName1 = DirectCast(Me.lboCompressors1.SelectedItem, DataRowView)("compfile").ToString
   '   compressorFileName2 = DirectCast(Me.lboCompressors2.SelectedItem, DataRowView)("compfile").ToString

   '   ' sets chiller model
   '   If Me.txtModelChange.Text = Me.GrabModel() Then
   '      chillerModel = Me.GrabModel()
   '   Else
   '      chillerModel = Me.txtModelChange.Text & "       Base Model: " & Me.GrabModel()
   '   End If

   '   ' sets condenser description
   '   If Me.IsFullDualCircuit() Then
   '      condenser = "(" & Me.txtNumCoils1.Text & ")" & Me.txtCondenser_1.Text & _
   '         " --- " & "(" & Me.txtNumCoils2.Text & ")" & Me.txtCondenser_2.Text
   '   ElseIf Me.IsFullSingleCircuit() Then
   '      condenser = "(" & Me.txtNumCoils1.Text & ")" & Trim(txtCondenser_1.Text)
   '   ElseIf Me.IsHalfCircuit1() Then
   '      condenser = "(" & Me.txtNumCoils1.Text & ")" & Me.txtCondenser_1.Text
   '   ElseIf Me.IsHalfCircuit2() Then
   '      condenser = "(" & Me.txtNumCoils2.Text & ")" & Me.txtCondenser_2.Text
   '   End If

   '   ' sets evaporator description
   '   evaporator = Me.GrabEvaporatorModel() & "   Fouling = " & Me.cboFoulingFactor.SelectedItem

   '   ' sets compressor description
   '   If Me.IsFullSingleCircuit() Then
   '      compressor = "(" & Me.GrabNumCompressors(1).ToString & ") " & compressorFileName1
   '   ElseIf Me.IsFullDualCircuit() Then
   '      compressor = "(" & Me.GrabNumCompressors(1).ToString & ") " & compressorFileName1 & _
   '         " --- " & "(" & Me.GrabNumCompressors(2).ToString & ") " & compressorFileName2
   '   ElseIf Me.IsHalfCircuit1() Then
   '      compressor = "(" & Me.GrabNumCompressors(1).ToString & ") " & compressorFileName1
   '   ElseIf Me.IsHalfCircuit2() Then
   '      compressor = "(" & Me.GrabNumCompressors(2) & ") " & compressorFileName2
   '   End If

   '   ' sets fluid
   '   If Me.cboFluid.SelectedItem = "Water" Then
   '      fluid = Me.cboFluid.SelectedItem
   '   Else
   '      fluid = Me.cboFluid.SelectedItem & "   " & Me.txtPercentGlycol.Text & "% " & Me.cboGlycol.SelectedItem
   '   End If

   '   ' sets circuit label indicating circuits if half system is selected
   '   If Me.GrabSystem() = "HALF" Then
   '      If Me.GrabCircuit1Checked() Then
   '         If Me.GrabCircuitsPerUnit() = 1 Then
   '            circuit = "Showing Circuit 1 of 1"
   '         Else
   '            circuit = "Showing Circuit 1 of 2"
   '         End If
   '      Else
   '         circuit = "Showing Circuit 2 of 2"
   '      End If
   '   Else
   '      circuit = " "
   '   End If

   '   ' sets operating limits note
   '   If Me.lblLimits.Visible Then
   '      limits = Me.lblLimits.Text.Trim ' Points Omitted
   '   Else : limits = "" : End If

   '   ' sets temperature range note
   '   temperatureRange = "Calculations based on " & Trim(Me.cboTempRange.SelectedItem) & "ºF range"

   '   If Me.rbOther_Approch.Checked Then
   '   Else
   '      If Me.rb6_8.Checked Then
   '         Q8 = Val(Me.txt6Deg.Text)
   '         Q9 = Val(Me.txt8Deg.Text)
   '      ElseIf Me.rb7_9.Checked Then
   '         Q8 = Val(Me.txt7Deg.Text)
   '         Q9 = Val(Me.txt9Deg.Text)
   '      ElseIf Me.rb8_10.Checked Then
   '         Q8 = Val(Me.txt8Deg.Text)
   '         Q9 = Val(Me.txt10Deg.Text)
   '      ElseIf Me.rb9_11.Checked Then
   '         Q8 = Val(Me.txt9Deg.Text)
   '         Q9 = Val(Me.txt11Deg.Text)
   '      ElseIf Me.rb10_12.Checked Then
   '         Q8 = Val(Me.txt10Deg.Text)
   '         Q9 = Val(Me.txt12Deg.Text)
   '      End If
   '   End If

   '   ' 8F Evaporator, 10F Evaporator, Condenser Capacity @ 25F, Fan
   '   If Me.IsFullSingleCircuit() Then
   '      If Me.rbOther_Approch.Checked Then
   '         evaporator8 = Me.Txt8Deg_1.Text
   '      Else
   '         evaporator8 = Q8
   '      End If

   '      If Me.rbOther_Approch.Checked = True Then
   '         evaporator10 = Me.Txt10Deg_1.Text
   '      Else
   '         evaporator10 = Q9
   '      End If
   '      condenserCapacity = Val(Me.TxtCondCap_1.Text)
   '      If Me.GrabFan.FileName = "CFM Per Fan >>>" Then
   '         numFans = Val(Me.txtNumFans1.Text) * Val(Me.txtNumCoils1.Text)
   '         fan = "(" & numFans.ToString & ") " & Me.GrabFan.FileName & txtCfmOverRide.Text & _
   '            "   Altitude = " & Me.txtAltitude1.Text
   '      Else
   '         numFans = Val(Me.txtNumFans1.Text) * Val(Me.txtNumCoils1.Text)
   '         fan = "(" & numFans.ToString & ") " & Me.GrabFan.Description & "   Altitude = " & Val(Me.txtAltitude1.Text)
   '      End If

   '   ElseIf Me.IsFullDualCircuit() Then
   '      If Me.rbOther_Approch.Checked Then
   '         evaporator8 = Val(Me.Txt8Deg_1.Text) + Val(Me.Txt8Deg_2.Text)
   '      Else
   '         evaporator8 = Q8 + Q8
   '      End If
   '      If Me.rbOther_Approch.Checked Then
   '         evaporator10 = Val(Me.Txt10Deg_1.Text) + Val(Me.Txt10Deg_2.Text)
   '      Else
   '         evaporator10 = Q9 + Q9
   '      End If
   '      condenserCapacity = Val(Me.TxtCondCap_1.Text) + Val(Me.TxtCondCap_2.Text)
   '      If Me.GrabFan.FileName = "CFM Per Fan >>>" Then
   '         numFans = Val(Me.txtNumFans1.Text) * Val(Me.txtNumCoils1.Text)
   '         fan = "(" & (numFans.ToString) + (Val(Me.txtNumFans2.Text) * Val(Me.txtNumCoils2.Text)) & ") " _
   '            & Me.GrabFan.FileName & Val(txtCfmOverRide.Text) & "   Altitude = " & Val(Me.txtAltitude1.Text)
   '      Else
   '         numFans = Val(Me.txtNumFans1.Text) * Val(Me.txtNumCoils1.Text)
   '         fan = "(" & numFans.ToString & (Val(Me.txtNumFans2.Text) * Val(Me.txtNumCoils2.Text)) & ") " _
   '            & Me.GrabFan.Description & "   Altitude = " & Val(txtAltitude1.Text)
   '      End If

   '   ElseIf Me.IsHalfCircuit1() Then
   '      If Me.rbOther_Approch.Checked Then
   '         evaporator8 = Val(Me.Txt8Deg_1.Text)
   '      Else
   '         evaporator8 = Q8
   '      End If
   '      If Me.rbOther_Approch.Checked = True Then
   '         evaporator10 = Val(Me.Txt10Deg_1.Text)
   '      Else
   '         evaporator10 = Q9
   '      End If
   '      condenserCapacity = Val(Me.TxtCondCap_1.Text)
   '      If Me.GrabFan.FileName = "CFM Per Fan >>>" Then
   '         numFans = Val(Me.txtNumFans1.Text) * Val(Me.txtNumCoils1.Text)
   '         fan = "(" & numFans.ToString & ") " & Me.GrabFan.FileName & Me.txtCfmOverRide.Text & _
   '            "   Altitude = " & Me.txtAltitude1.Text
   '      Else
   '         numFans = Val(Me.txtNumFans1.Text) * Val(Me.txtNumCoils1.Text)
   '         fan = "(" & numFans & ") " & Me.GrabFan.Description & "   Altitude = " & Val(txtAltitude1.Text())
   '      End If

   '   ElseIf Me.IsHalfCircuit2() Then
   '      If Me.rbOther_Approch.Checked = True Then
   '         evaporator8 = Me.Txt8Deg_2.Text
   '      Else
   '         evaporator8 = Q9
   '      End If
   '      evaporator10 = Me.Txt10Deg_2.Text
   '      condenserCapacity = Me.TxtCondCap_2.Text
   '      If Me.GrabFan.FileName = "CFM Per Fan >>>" Then
   '         numFans = Val(Me.txtNumFans2.Text) * Val(Me.txtNumCoils2.Text)
   '         fan = "(" & numFans.ToString & ") " & Me.GrabFan.FileName & Val(txtCfmOverRide.Text()) & "   Altitude = " & Val(txtAltitude1.Text())
   '      Else
   '         numFans = Val(Me.txtNumFans2.Text) * Val(Me.txtNumCoils2.Text)
   '         fan = "(" & numFans.ToString & ") " & Me.GrabFan.Description & "   Altitude = " & Me.txtAltitude1.Text
   '      End If
   '   End If

   '   ' sets catalog rating note
   '   If Me.chkCatalog.Checked Then
   '      catalog = "Catalog Rating"
   '   Else : catalog = "" : End If




   '   ' passes values to parameter fields
   '   ' ---------------------------------

   '   field.Pass("Rep", "pfdAuthorization")
   '   field.Pass(My.Application.Info.Version.ToString, "pfdVersion")
   '   field.Pass(Me.AmbientTemp, "pfdAmbient")
   '   field.Pass(Me.LeavingFluidTemp, "pfdLeavingFluid")
   '   field.Pass(Constants.TESTING.ToString, "pfdTest")
   '   field.Pass("TSI", "pfdLogo")
   '   field.Pass(AppInfo.User.Username, "pfdCreator")
   '   field.Pass(chillerModel, "pfdModelNumber")
   '   field.Pass(condenser, "pfdCondenser")
   '   field.Pass(evaporator, "pfdEvaporator")
   '   field.Pass(Me.GrabSystem(), "pfdSystem")
   '   field.Pass(compressor, "pfdCompressor")
   '   field.Pass(Me.GrabRefrigerant.Refrigerant, "pfdRefrigerant")
   '   field.Pass(Me.cboHertz.SelectedItem, "pfdHertz")
   '   field.Pass(fluid, "pfdFluid")
   '   field.Pass(circuit, "pfdCircuit")
   '   field.Pass(limits, "pfdOperatingLimits")
   '   field.Pass(temperatureRange, "pfdRange")
   '   field.Pass(evaporator8, "pfd8Evaporator")
   '   field.Pass(evaporator10, "pfd10Evaporator")
   '   field.Pass(8, "pfdLowerApproach")
   '   field.Pass(10, "pfdUpperApproach")
   '   field.Pass(condenserCapacity, "pfdCondenserCapacity")
   '   field.Pass(fan, "pfdFans") 'Fan (set here because, value is based on variables that weren't set before)
   '   field.Pass(Me.cbo_Discharge_line_loss.SelectedItem, "pfdDischarge") ' discharge line loss
   '   field.Pass(Me.cbo_Suction_line_loss.SelectedItem, "pfdSuction") ' suction line loss
   '   field.Pass(catalog, "pfdCatalog")   ' catalog rating note


   '   'Set CR Viewer report source to appropriate CR Report		
   '   reportForm.ReportViewer.ReportSource = report
   '   ' alternatively can be set with file path as below
   '   'ReportForm.CRViewer1.ReportSource = "..\Report1.rpt"
   '   reportForm.ReportViewer.Zoom(1) '1 = page width, 2 = whole page, else %
   '   reportForm.Show()

   '   ' clears master 30 database (it was holding temporary info for crystal report)
   '   DataAccess.Chillers.ChillerDataAccess.DeleteChillerResults()
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
   Private Sub FillDatagrid()
      Me.MyFileNameMDB = Me.PASS_FILENAME
      ' sets path to temporary database
      Dim dbPath As String = AppInfo.AppFolderPath & "Reports\" & MyFileNameMDB

      ' retrieves chiller results
      'Dim chillerTable As DataTable = DataAccess.Chillers.ChillerDataAccess.RetrieveChillerResults(dbPath)
      ' fills datagrid w/ results
      'Me.grdResults.DataSource = chillerTable

      ' formats datagrid
      Me.FormatDatagrid()
   End Sub


   Private Sub FormatDatagrid()
      ' sets general datagrid stylings
      Rae.Ui.C1GridStyles.BasicGridStyle(Me.grdResults)

      With Me.grdResults.Splits(0)
         ' sets column heading height
         .ColumnCaptionHeight = 36

         ' sets column heading text
         .DisplayColumns("TW").DataColumn.Caption = "Leaving Fluid Temp. [°F]"
         .DisplayColumns("TA").DataColumn.Caption = "Ambient Temp. [°F]"
         .DisplayColumns("TE").DataColumn.Caption = "Evaporator Temp. [°F]"
         .DisplayColumns("TC").DataColumn.Caption = "Condenser Temp. [°F]"
         .DisplayColumns("Q").DataColumn.Caption = "Capacity [Tons]"
         .DisplayColumns("KW").DataColumn.Caption = "Unit [kW]"
         .DisplayColumns("GP").DataColumn.Caption = "GPM"
         .DisplayColumns("A").DataColumn.Caption = "Current [Amps]"
         .DisplayColumns("ER").DataColumn.Caption = "Compressor EER"
         .DisplayColumns("EZ").DataColumn.Caption = "Unit EER"

         ' sets column widths
         .DisplayColumns("TW").Width = 76
         .DisplayColumns("TA").Width = 68
         .DisplayColumns("TE").Width = 70
         .DisplayColumns("TC").Width = 70
         .DisplayColumns("Q").Width = 55
         .DisplayColumns("KW").Width = 43
         .DisplayColumns("GP").Width = 42
         .DisplayColumns("A").Width = 54
         .DisplayColumns("ER").Width = 70
         .DisplayColumns("EZ").Width = 45
      End With

   End Sub


   Private Sub Call_CoFan()
      Dim Cap_at_8_FPI As Double
      Dim Cap_at_10_FPI As Double
      Dim Cap_at_12_FPI As Double
      Dim Cap_at_14_FPI As Double

      'get cofan capacities from cofan dll
      If Running_Circuit_no = 1 Then
         Dim cofan As Condenser
         If GrabFan.FileName = "CFM Per Fan >>>" Then
            cofan = New Condenser(95, 25, Val(txtFinHeight1.Text), Val(txtFinLength1.Text), GrabCondenser1.FileName, Val(txtNumFans1.Text), Val(txtCfmOverRide.Text))
         Else
            cofan = New Condenser(95, 25, Val(txtFinHeight1.Text), Val(txtFinLength1.Text), GrabCondenser1.FileName, Val(txtNumFans1.Text), GrabFan.FileName)
         End If
         cofan.Calculate()
         Cap_at_8_FPI = cofan.Output.At(8).Capacity
         Cap_at_10_FPI = cofan.Output.At(10).Capacity
         Cap_at_12_FPI = cofan.Output.At(12).Capacity
         Cap_at_14_FPI = cofan.Output.At(14).Capacity

         'Dim RaeDllcofan As New RAEDLL_COFAN.RRAEDLL_COFAN
         'RaeDllcofan.RAE_Input_Altitude_in_feet = Val(txtAltitude1.Text())
         'RaeDllcofan.RAE_Input_Ambient_Temp_Degrees_F = 95   'Val(txtAmbientTemp.Text())
         'RaeDllcofan.RAE_Input_Temperature_Difference_Degrees_F = 25 'Val(txt_cofan_dt_1.Text())
         'RaeDllcofan.RAE_Input_Number_of_Fans = Val(txtNumFans1.Text()) '*  Val(txtNumCoils1.Text())
         'RaeDllcofan.RAE_Input_Condenser_Fin_Width = txtFinHeight1.Text()
         'RaeDllcofan.RAE_Input_Condenser_Fin_Length = txtFinLength1.Text()
         'RaeDllcofan.RAE_COIL_FILE_NAME = Me.GrabCondenser1.FileName
         'If Me.GrabFan.FileName = "CFM Per Fan >>>" Then
         '   RaeDllcofan.RAE_FAN_FILE_NAME = "OVERRIDE" & Val(txtCfmOverRide.Text)
         'Else
         '   RaeDllcofan.RAE_FAN_FILE_NAME = Me.GrabFan.FileName
         'End If
         'RaeDllcofan.AddToDatabase()
         'Cap_at_8_FPI = RaeDllcofan.RAE_Out_COFAN_CAPACITY_Output1
         'Cap_at_10_FPI = RaeDllcofan.RAE_Out_COFAN_CAPACITY_Output2
         'Cap_at_12_FPI = RaeDllcofan.RAE_Out_COFAN_CAPACITY_Output3
         'Cap_at_14_FPI = RaeDllcofan.RAE_Out_COFAN_CAPACITY_Output4
      ElseIf Running_Circuit_no = 2 Then
         Dim cofan As Condenser
         If Me.GrabFan.FileName = "CFM Per Fan >>>" Then
            cofan = New Condenser(95, 25, Val(txtFinHeight2.Text), Val(txtFinLength2.Text), GrabCondenser2.FileName, Val(txtNumFans2.Text), Val(txtCfmOverRide.Text))
         Else
            cofan = New Condenser(95, 25, Val(txtFinHeight2.Text), Val(txtFinLength2.Text), GrabCondenser2.FileName, Val(txtNumFans2.Text), GrabFan.FileName)
         End If
         cofan.Calculate()
         Cap_at_8_FPI = cofan.Output.At(8).Capacity
         Cap_at_10_FPI = cofan.Output.At(10).Capacity
         Cap_at_12_FPI = cofan.Output.At(12).Capacity
         Cap_at_14_FPI = cofan.Output.At(14).Capacity

         'Dim RaeDllcofan As New RAEDLL_COFAN.RRAEDLL_COFAN
         'RaeDllcofan.RAE_Input_Altitude_in_feet = Val(txtAltitude1.Text())
         'RaeDllcofan.RAE_Input_Ambient_Temp_Degrees_F = 95   'Val(txtAmbientTemp.Text())
         'RaeDllcofan.RAE_Input_Temperature_Difference_Degrees_F = 25 'Val(txt_cofan_dt_2.Text())
         'RaeDllcofan.RAE_Input_Number_of_Fans = Val(txtNumFans2.Text) '* Val(txtNumCoils2.Text())
         'RaeDllcofan.RAE_Input_Condenser_Fin_Width = txtFinHeight2.Text
         'RaeDllcofan.RAE_Input_Condenser_Fin_Length = txtFinLength2.Text
         'RaeDllcofan.RAE_COIL_FILE_NAME = Me.GrabCondenser2.FileName
         'If Me.GrabFan.FileName = "CFM Per Fan >>>" Then
         '   RaeDllcofan.RAE_FAN_FILE_NAME = "OVERRIDE" & Val(txtCfmOverRide.Text)
         'Else
         '   RaeDllcofan.RAE_FAN_FILE_NAME = Me.GrabFan.FileName
         'End If
         'RaeDllcofan.AddToDatabase()
         'Cap_at_8_FPI = RaeDllcofan.RAE_Out_COFAN_CAPACITY_Output1
         'Cap_at_10_FPI = RaeDllcofan.RAE_Out_COFAN_CAPACITY_Output2
         'Cap_at_12_FPI = RaeDllcofan.RAE_Out_COFAN_CAPACITY_Output3
         'Cap_at_14_FPI = RaeDllcofan.RAE_Out_COFAN_CAPACITY_Output4
      End If

      'calculate coil capacity based on fins per inch
      Dim CALULATED_COIL_CAP As Double
      If CboFpi.SelectedItem = 8 Then
         CALULATED_COIL_CAP = Int(Cap_at_8_FPI)
      ElseIf CboFpi.SelectedItem = 9 Then
         CALULATED_COIL_CAP = Int(((Cap_at_10_FPI - Cap_at_8_FPI) / 2) + Cap_at_8_FPI)
      ElseIf CboFpi.SelectedItem = 10 Then
         CALULATED_COIL_CAP = Int(Cap_at_10_FPI)
      ElseIf CboFpi.SelectedItem = 11 Then
         CALULATED_COIL_CAP = Int(((Cap_at_12_FPI - Cap_at_10_FPI) / 2) + Cap_at_10_FPI)
      ElseIf CboFpi.SelectedItem = 12 Then
         CALULATED_COIL_CAP = Int(Cap_at_12_FPI)
      ElseIf CboFpi.SelectedItem = 13 Then
         CALULATED_COIL_CAP = Int(((Cap_at_14_FPI - Cap_at_12_FPI) / 2) + Cap_at_12_FPI)
      ElseIf CboFpi.SelectedItem = 14 Then
         CALULATED_COIL_CAP = Int(Cap_at_14_FPI)
      End If

      Dim refrigerant As String
      Dim refrigerantMultiplier As Double

      ' grabs refrigerant
      refrigerant = Me.GrabRefrigerant.Abbreviation
      ' sets refrigerant multiplier that adjusts coil capacity
      refrigerantMultiplier = Business.Intelligence.Chillers.ChillerIntel.SelectRefrigerantMultiplier(refrigerant)
      ' adjusts coil capacity
      CALULATED_COIL_CAP = CALULATED_COIL_CAP * refrigerantMultiplier

      'adjust coil capacity for sub cooling percentage
      If Running_Circuit_no = 1 Then
         If cboSubCooling1.SelectedItem = "Yes" Then
            CALULATED_COIL_CAP = CALULATED_COIL_CAP * (1 - (Val(txtSubCoolingPercent1.Text()) / 100)) '0.85    'Preset to 15 Deg. Sub Cooling
         End If
      ElseIf Running_Circuit_no = 2 Then
         If cboSubCooling2.SelectedItem = "Yes" Then
            CALULATED_COIL_CAP = CALULATED_COIL_CAP * (1 - (Val(txtSubCoolingPercent2.Text()) / 100)) '0.85    'Preset to 15 Deg. Sub Cooling
         End If
      End If

      'set controls with calculated coil/condenser? capacity
      TxtCondCap.Text = Round(CALULATED_COIL_CAP, 0)
      If Running_Circuit_no = 1 Then
         TxtCondCap_1.Text = Round(CALULATED_COIL_CAP, 0) * Val(txtNumCoils1.Text())
      ElseIf Running_Circuit_no = 2 Then
         TxtCondCap_2.Text = Round(CALULATED_COIL_CAP, 0) * Val(txtNumCoils2.Text())
      End If
   End Sub


   Private Sub fillCompressorListBoxes(chillerModel As String, refrigerant As String)
      ' retrieves compressor model list based on chiller model
      Dim compressorModels = DataAccess.CompressorDataAccess.RetrieveCompressorModels(chillerModel)

      ' retrieves compressor description
      Dim compressorTable = Business.Agents.Compressor.RetrieveCompressorDescriptions(compressorModels, refrigerant)

      Me.lboCompressors1.DataSource = compressorTable.Copy()
      Me.lboCompressors1.DisplayMember = "Description"

      Me.lboCompressors2.DataSource = compressorTable.Copy()
      Me.lboCompressors2.DisplayMember = "Description"
   End Sub


   Sub Set_Fan_Watts()
      ' grabs fan file name
      Dim fanFileName As String = Me.GrabFan.FileName
      Dim hertz As Integer = CInt(Me.cboHertz.SelectedItem.ToString)
      Dim voltage As Integer = CInt(Me.cboVolts.SelectedItem)

      Dim fanWatts As Integer = Business.Intelligence.FanIntel.SelectFanWatts(fanFileName, hertz, voltage)

      Me.txtFanWatts1.Text = fanWatts
      Me.fanWatts = fanWatts
   End Sub


   Private Sub CALL_Circuit1()
      Dim chiller As Chiller
      Dim avgCapacity As Double

      ' retrieves chiller object
      chiller = Business.Agents.ChillerAgent.RetrieveChiller(Me.GrabModel())
      ' calculates capacity average
      avgCapacity = Round(Average(chiller.ApproxMinCapacity, chiller.ApproxMaxCapacity), 2)

      ' sets controls
      ' ----------------

      Me.txtEvaporator.Text = chiller.EvaporatorPartNum
      Me.txtCondenser_1.Text = chiller.Circuit1.Coil.Name
      Me.txtCompressor1.Text = chiller.Circuit1.Compressor.Name
      Me.txtNumCompressors1.Text = chiller.Circuit1.NumCompressors.ToString
      Me.txtNumFans1.Text = chiller.Circuit1.NumFans.ToString
      Me.txtNumCoils1.Text = chiller.Circuit1.NumCoils
      Me.Txt_circuit_per_unit.Text = chiller.NumCircuitsPerUnit.ToString
      Me.txtSubCoolingPercent1.Text = chiller.Circuit1.SubCoolingPercentage.ToString
      Me.txtFinHeight1.Text = chiller.Circuit1.Coil.Height.ToString
      Me.txtFinLength1.Text = chiller.Circuit1.Coil.Length.ToString

      If Me.radCapacityTons.Checked Then  ' Tons 
         Me.txtCapacity.Text = avgCapacity.ToString
      ElseIf radCapacityGpm.Checked = True Then  ' GPM 
         Me.txtCapacity.Text = Round(Convert.TonsToGpm( _
            avgCapacity, Me.GrabTemperatureRange(), Me.GrabSpecificHeat(), Me.GrabSpecificGravity()), 2)
      End If

      Me.cal_Tons_GPM()

      If chiller.NumCircuitsPerUnit = 1 Then
         Me.cboSystem.SelectedIndex = 0
         Me.cboSystem.Enabled = False
      Else
         Me.cboSystem.Enabled = True
      End If

      ' selects compressor
      Me.lboCompressors1.SelectedIndex = Me.IndexOfCompressor(Me.lboCompressors1, chiller.Circuit1.Compressor.Name.ToUpper)
      ' selects fins per inch
      Me.CboFpi.SelectedIndex = Rae.Ui.ListHelper.IndexOfComboBoxItem(Me.CboFpi, chiller.Circuit1.Coil.FinsPerInch)
      Me.cboFpi1.SelectedIndex = Rae.Ui.ListHelper.IndexOfComboBoxItem(Me.cboFpi1, chiller.Circuit1.Coil.FinsPerInch)
      ' selects condenser with matching file name (number of rows)
      Me.cboCoilFileName1.SelectedIndex = Me.indexOfCondenser( _
         Me.cboCoilFileName1, chiller.Circuit1.Coil.Rows.ToString & "RCOND")
      ' selects fan with matching fan file name determined by fan diameter (applies to both circuits)
      Me.cboFanFileName.SelectedIndex = Me.indexOfFanFileName( _
         Me.cboFanFileName, Business.Intelligence.FanIntel.SelectFanFileName(chiller.Circuit1.FanDiameter))

      If chiller.NumCircuitsPerUnit > 1 Then
         Me.radCircuit2.Visible = True
      End If

      ' retrieves evaporator info
      Dim evaporator = Business.Agents.ChillerAgent.RetrieveChillerEvaporator(Me.GrabEvaporatorModel())
      ' sets evaporator tooltip
      Me.ToolTip1.SetToolTip(Me.txtEvaporator, evaporator.ToString)
      Me.txt_Evap_Length.Text = evaporator.Length.ToString
      ' sets condenser capacity using cofan dll
      Call_CoFan()
      '1 = specific heat & gravity    2 = evaporator models    3 = 8&10 deg approach
      ChillyRAEs_pass_no = 1 : Call_ChillyRAE_Parms()
      ChillyRAEs_pass_no = 3 : Call_ChillyRAE_Parms()
   End Sub


   Private Sub CALL_Circuit2()
      Dim chiller As Chiller
      Dim avgCapacity As Double

      ' retrieves chiller object
      chiller = Business.Agents.ChillerAgent.RetrieveChiller(Me.GrabModel())
      ' calaculates average of minimum and maximum capacity
      avgCapacity = Round(Average(chiller.ApproxMinCapacity, chiller.ApproxMaxCapacity), 2)

      ' sets controls
      Me.txtEvaporator.Text = chiller.EvaporatorPartNum
      Me.txtCondenser_2.Text = chiller.Circuit2.Coil.Name
      Me.txtCompressor2.Text = chiller.Circuit2.Compressor.Name
      Me.txtNumCompressors2.Text = chiller.Circuit2.NumCompressors.ToString
      Me.txtNumFans2.Text = chiller.Circuit2.NumFans.ToString
      Me.txtNumCoils2.Text = chiller.Circuit2.NumCoils.ToString
      Me.Txt_circuit_per_unit.Text = chiller.NumCircuitsPerUnit.ToString
      Me.txtSubCoolingPercent2.Text = chiller.Circuit2.SubCoolingPercentage.ToString

      If Me.radCapacityTons.Checked Then  'Tons 
         Me.txtCapacity.Text = Round(avgCapacity, 2)
      ElseIf radCapacityGpm.Checked Then  'GPM 
         Me.txtCapacity.Text = Convert.TonsToGpm( _
            avgCapacity, Me.GrabTemperatureRange(), Me.GrabSpecificHeat, Me.GrabSpecificGravity)
      End If
      Me.cal_Tons_GPM()

      If chiller.NumCircuitsPerUnit = 1 Then
         Me.cboSystem.SelectedIndex = 0
         Me.cboSystem.Enabled = False
      Else
         Me.cboSystem.Enabled = True
      End If

      ' selects compressor
      Me.lboCompressors2.SelectedIndex = Me.IndexOfCompressor(Me.lboCompressors2, chiller.Circuit2.Compressor.Name.ToUpper)

      ' selects fpi
      Me.CboFpi.SelectedIndex = Rae.Ui.ListHelper.IndexOfComboBoxItem(Me.CboFpi, chiller.Circuit2.Coil.FinsPerInch)
      Me.cboFpi2.SelectedIndex = Rae.Ui.ListHelper.IndexOfComboBoxItem(Me.cboFpi2, chiller.Circuit2.Coil.FinsPerInch)
      ' sets fin size
      Me.txtFinHeight2.Text = chiller.Circuit2.Coil.Height.ToString
      Me.txtFinLength2.Text = chiller.Circuit2.Coil.Length.ToString

      ' selects condenser
      Me.cboCoilFileName2.SelectedIndex = Me.indexOfCondenser( _
         Me.cboCoilFileName2, chiller.Circuit2.Coil.Rows.ToString & "RCOND")
      ' selects fan based on fan diameter
      Me.cboFanFileName.SelectedIndex = Me.indexOfFanFileName( _
         Me.cboFanFileName, Business.Intelligence.FanIntel.SelectFanFileName(chiller.Circuit2.FanDiameter))


      ' retrieves evaporator
      Dim evaporator As Evaporator1

      evaporator = Business.Agents.ChillerAgent.RetrieveChillerEvaporator(Me.GrabEvaporatorModel())
      Me.ToolTip1.SetToolTip(Me.txtEvaporator, evaporator.ToString)
      Me.txt_Evap_Length.Text = evaporator.Length.ToString


      If chiller.NumCircuitsPerUnit > 1 Then Me.radCircuit2.Visible = True

      ' calculates coil capacity
      Me.Call_CoFan()
      ' 1 = specific heat and gravity    2 = evaporator models    3 = 8&10 deg approach
      ChillyRAEs_pass_no = 1 : Me.Call_ChillyRAE_Parms()
      ChillyRAEs_pass_no = 3 : Me.Call_ChillyRAE_Parms()
   End Sub


   Private Sub cboModels_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles cboModels.SelectedIndexChanged
      Me.Cursor = Cursors.WaitCursor

      If loaded And Me.GrabModel() <> "Choose" Then
         grdResults.Visible = False
         TextBox1.Text = ""

         Me.fillCompressorListBoxes(Me.GrabModel(), Me.GrabRefrigerant.Abbreviation)

         Running_Circuit_no = 1 : CALL_Circuit1()
         If Val(Me.Txt_circuit_per_unit.Text) > 1 Then
            Running_Circuit_no = 2 : CALL_Circuit2()
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

         Me.txtModelChange.Text = Me.GrabModel()
      End If

      Me.Cursor = Cursors.Arrow
   End Sub


   Private Sub cboFluid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles cboFluid.SelectedIndexChanged
      If loaded = True Then
         grdResults.Visible = False
         TextBox1.Text = ""

         If cboFluid.SelectedItem = "Water" Then
            cboGlycol.Visible = False
            txtPercentGlycol.Enabled = False
            txtPercentGlycol.Text = "0"
            Me.btnGlycolChart.Visible = False
         Else
            cboGlycol.Visible = True
            txtPercentGlycol.Enabled = True
            txtPercentGlycol.Text() = "20"
            Me.btnGlycolChart.Visible = True
         End If
         ChillyRAEs_pass_no = 1  '1 = Parms    2 = Models    3 = 8&10 deg approach
         Call_ChillyRAE_Parms()
         CalculateFreezePoint()
      End If
   End Sub


   Private Sub cboGlycol_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles cboGlycol.SelectedIndexChanged
      If loaded = True Then 'was executing before loader() executed
         grdResults.Visible = False
         TextBox1.Text() = ""
         ChillyRAEs_pass_no = 1  '1 = Parms    2 = Models    3 = 8&10 deg approach
         Call_ChillyRAE_Parms()
      End If
   End Sub


   Private Sub cboRefrigerant_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles cboRefrigerant.SelectedIndexChanged
      If loaded And Me.GrabModel() <> "Choose" Then
         Me.grdResults.Visible = False
         Me.TextBox1.Text = ""
         Me.fillCompressorListBoxes(Me.GrabModel(), Me.GrabRefrigerant.Abbreviation)

         Dim refrigerant As String = Me.GrabRefrigerant.Abbreviation
         Select Case refrigerant
            Case "407c", "407cH", "407cM", "407cL"
               Me.btnAlternateEvaporators.Visible = False
               Me.cboEvaporators.Visible = False
            Case Else
               Me.btnAlternateEvaporators.Visible = True
               Me.cboEvaporators.Visible = True
         End Select
      End If
   End Sub


   Private Sub cboHertz_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles cboHertz.SelectedIndexChanged
      If Me.loaded Then
         grdResults.Visible = False
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
         Me.cboFanFileName.SelectedIndex = Me.indexOfFanFileName(Me.cboFanFileName, SWITCHING_FAN)

         ' sets fan watts textbox
         Me.Set_Fan_Watts()
      End If
   End Sub


   Private Sub cboSystem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles cboSystem.SelectedIndexChanged
      grdResults.Visible = False
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
      grdResults.Visible = False
      Me.TextBox1.Text = ""
      If radCircuit1.Checked = True Then
         Running_Circuit_no = 1
         Me.txtCompressor1.Text = DirectCast(Me.lboCompressors1.SelectedItem, DataRowView)("compmodel").ToString
      End If
   End Sub


   Private Sub lboCompressors2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles lboCompressors2.SelectedIndexChanged
      grdResults.Visible = False
      Me.TextBox1.Text = ""
      If radCircuit2.Checked = True Then
         Running_Circuit_no = 2
         Me.txtCompressor2.Text = DirectCast(Me.lboCompressors2.SelectedItem, DataRowView)("compmodel")
      End If
   End Sub


   Private Sub txtPercentGlycol_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles txtPercentGlycol.TextChanged
      If loaded = True Then 'was executing before loader() executed
         ChillyRAEs_pass_no = 1  '1 = Parms    2 = Models    3 = 8&10 deg approach
         Call_ChillyRAE_Parms()
      End If
   End Sub


   Private Sub CboChiller_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles cboEvaporators.SelectedIndexChanged
      Me.grdResults.Visible = False
      Me.TextBox1.Text = ""

      ' grabs selected evaporator
      Dim evaporatorModel As String = Me.cboEvaporators.SelectedItem.ToString

      ' checks if an alternate evaporator has been selected yet
      If evaporatorModel <> "Choose" Then
         ' retrieves evaporator
         Dim evaporator = Business.Agents.ChillerAgent.RetrieveChillerEvaporator(evaporatorModel)
         ' sets textbox text
         Me.txtEvaporator.Text = evaporatorModel '.Item("EvaporatorPartNum")
         ' sets tool tip
         Me.ToolTip1.SetToolTip(Me.txtEvaporator, evaporator.ToString)
      End If

      ChillyRAEs_pass_no = 3  '1 = Parms    2 = Models    3 = 8&10 deg approach
      Me.Call_ChillyRAE_Parms()
   End Sub

   Private Sub Cbo_coil_file_name_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles cboCoilFileName1.SelectedIndexChanged
      Me.change_coil_desc()
   End Sub

   Private Sub cboCoilFileName2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles cboCoilFileName2.SelectedIndexChanged
      Me.change_coil_desc()
   End Sub


   Private Sub cboFanFileName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles cboFanFileName.SelectedIndexChanged
      Me.grdResults.Visible = False
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


   'select alternate evaporators
   Private Sub btnAlternateEvaporators_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles btnAlternateEvaporators.Click
      Me.cal_Tons_GPM()
      ' 1 = Parms    2 = Models    3 = 8&10 deg approach
      ChillyRAEs_pass_no = 2 : Me.Call_ChillyRAE_Parms()
      Me.cboEvaporators.Visible = True
   End Sub


   Private Sub btnGlycolChart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGlycolChart.Click
      Dim form As New Windows.Forms.Form
      Dim myGrid As New C1.Win.C1TrueDBGrid.C1TrueDBGrid
      Dim glycolTable As DataTable
      Dim glycol As String
      Dim formWidth, formHeight As Integer

      ' sets selected glycol (ethylene or propylene)
      glycol = Me.cboGlycol.SelectedItem.ToString

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
      form.Controls.Add(myGrid)
      ' sets datagrid's data source
      myGrid.DataSource = glycolTable

      ' sets column width and captions
      With myGrid.Splits(0)
         .ColumnCaptionHeight = 36

         .DisplayColumns(GlycolNames.LeavingFluidTemperature).Width = 100
         .DisplayColumns(GlycolNames.LeavingFluidTemperature).DataColumn.Caption = "Leaving Fluid Temperature [°F]"
         .DisplayColumns(GlycolNames.FreezingPoint).Width = 80
         .DisplayColumns(GlycolNames.FreezingPoint).DataColumn.Caption = "Freezing Point [°F]"
         .DisplayColumns(GlycolNames.RecommendedGlycolPercentage).Width = 85
         .DisplayColumns(GlycolNames.RecommendedGlycolPercentage).DataColumn.Caption = "Recommended Glycol [%]"
         .DisplayColumns(GlycolNames.RecommendedMinSuctionTemperature).Width = 140
         .DisplayColumns(GlycolNames.RecommendedMinSuctionTemperature).DataColumn.Caption = _
            "Recommended Minimum Suction Temperature [°F]"
      End With
      myGrid.Dock = System.Windows.Forms.DockStyle.Fill
      myGrid.Caption = glycol & " Table"

      ' sets grid style to pre-defined style
      Rae.Ui.C1GridStyles.BasicGridStyle(myGrid)

      ' initializes form width to outer border width + vertical scroll bar width
      formWidth = 5 * 2 + myGrid.VScrollBar.Width
      For i As Integer = 0 To myGrid.Splits(0).DisplayColumns.Count - 1
         ' calculates form width based on column width and inner borders
         formWidth += myGrid.Splits(0).DisplayColumns(i).Width + 1
      Next

      ' calculates for height (just estimate)
      formHeight = 34 + myGrid.CaptionHeight + myGrid.Splits(0).ColumnCaptionHeight
      For i As Integer = 0 To myGrid.Splits(0).Rows.Count - 1
         formHeight += myGrid.RowHeight + 1
      Next

      form.Width = formWidth
      form.Height = formHeight
      form.Text = glycol & " Recommendations"
      form.MdiParent = Me.MdiParent
      form.Show()
   End Sub


   Private Sub txtAltitude1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAltitude1.TextChanged
      Me.txtAltitude2.Text = txtAltitude1.Text
   End Sub


   Private Sub txtFanWatts1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFanWatts1.TextChanged
      txtFanWatts2.Text = txtFanWatts1.Text
   End Sub


#Region "Section Visibility"
   Private Sub btnEvaporatorVisibility_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles btnEvaporatorVisibility.Click
      Static Dim show As Boolean = True
      show = Not show
      If show = True Then
         panEvaporatorBody.Show()
         btnEvaporatorVisibility.Text = "-"
      ElseIf show = False Then
         panEvaporatorBody.Hide()
         btnEvaporatorVisibility.Text = "+"
      End If
   End Sub

   Private Sub btnCondenserVisibility_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles btnCondenserVisibility.Click
      Static Dim show As Boolean = True
      show = Not show
      If show = True Then
         panCondenserBody.Show()
         btnCondenserVisibility.Text = "-"
      ElseIf show = False Then
         panCondenserBody.Hide()
         btnCondenserVisibility.Text = "+"
      End If
   End Sub

   Private Sub btnCompressorVisibility_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles btnCompressorVisibility.Click
      Static Dim show As Boolean = True
      show = Not show
      If show = True Then
         panCompressorBody.Show()
         btnCompressorVisibility.Text = "-"
      ElseIf show = False Then
         panCompressorBody.Hide()
         btnCompressorVisibility.Text = "+"
      End If
   End Sub

   Private Sub btnCriteriaVisibility_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles btnCriteriaVisibility.Click
      Static Dim show As Boolean = True
      show = Not show
      If show = True Then
         panCriteriaBody.Show()
         btnCriteriaVisibility.Text = "-"
      ElseIf show = False Then
         panCriteriaBody.Hide()
         btnCriteriaVisibility.Text = "+"
      End If
   End Sub
#End Region


#Region "Button Mouse Events"
   'compressor	section's visibility button
   Private Sub picCompressorVisibility_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles picCompressorVisibility.MouseEnter
      If picCompressorVisibility.Tag = "expanded" Then
         picCompressorVisibility.Image = Image.FromFile(AppInfo.AppFolderPath & "images\hideGlow.jpg")
      ElseIf picCompressorVisibility.Tag = "collapsed" Then
         picCompressorVisibility.Image = Image.FromFile(AppInfo.AppFolderPath & "images\showGlow.jpg")
      End If
   End Sub
   Private Sub picCompressorVisibility_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles picCompressorVisibility.MouseLeave
      If picCompressorVisibility.Tag = "expanded" Then
         picCompressorVisibility.Image = Image.FromFile(AppInfo.AppFolderPath & "images\hide.jpg")
      ElseIf picCompressorVisibility.Tag = "collapsed" Then
         picCompressorVisibility.Image = Image.FromFile(AppInfo.AppFolderPath & "images\show.jpg")
      End If
   End Sub
   Private Sub picCompressorVisibility_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles picCompressorVisibility.Click
      If picCompressorVisibility.Tag = "expanded" Then
         picCompressorVisibility.Tag = "collapsed"
         ToolTip1.SetToolTip(picCompressorVisibility, "Show compressor section")
         picCompressorVisibility.Image = Image.FromFile(AppInfo.AppFolderPath & "images\showGlow.jpg")
         panCompressorBody.Hide()
      ElseIf picCompressorVisibility.Tag = "collapsed" Then
         picCompressorVisibility.Tag = "expanded"
         ToolTip1.SetToolTip(picCompressorVisibility, "Hide compressor section")
         picCompressorVisibility.Image = Image.FromFile(AppInfo.AppFolderPath & "images\hideGlow.jpg")
         panCompressorBody.Show()
      End If
   End Sub

   'rating criteria section's visibility button
   Private Sub picCriteriaVisibility_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles picCriteriaVisibility.MouseEnter
      If picCriteriaVisibility.Tag = "expanded" Then
         picCriteriaVisibility.Image = Image.FromFile(AppInfo.AppFolderPath & "images\hideGlow.jpg")
      ElseIf picCriteriaVisibility.Tag = "collapsed" Then
         picCriteriaVisibility.Image = Image.FromFile(AppInfo.AppFolderPath & "images\showGlow.jpg")
      End If
   End Sub
   Private Sub picCriteriaVisibility_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles picCriteriaVisibility.MouseLeave
      If picCriteriaVisibility.Tag = "expanded" Then
         picCriteriaVisibility.Image = Image.FromFile(AppInfo.AppFolderPath & "images\hide.jpg")
      ElseIf picCriteriaVisibility.Tag = "collapsed" Then
         picCriteriaVisibility.Image = Image.FromFile(AppInfo.AppFolderPath & "images\show.jpg")
      End If
   End Sub
   Private Sub picCriteriaVisibility_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles picCriteriaVisibility.Click
      If picCriteriaVisibility.Tag = "expanded" Then
         picCriteriaVisibility.Tag = "collapsed"
         ToolTip1.SetToolTip(picCriteriaVisibility, "Show rating criteria section")
         picCriteriaVisibility.Image = Image.FromFile(AppInfo.AppFolderPath & "images\showGlow.jpg")
         panCriteriaBody.Hide()
      ElseIf picCriteriaVisibility.Tag = "collapsed" Then
         picCriteriaVisibility.Tag = "expanded"
         ToolTip1.SetToolTip(picCriteriaVisibility, "Hide rating criteria section")
         picCriteriaVisibility.Image = Image.FromFile(AppInfo.AppFolderPath & "images\hideGlow.jpg")
         panCriteriaBody.Show()
      End If
   End Sub

   'condenser section's visibility button
   Private Sub picCondenserVisibility_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picCondenserVisibility.MouseEnter
      If picCondenserVisibility.Tag = "expanded" Then
         picCondenserVisibility.Image = Image.FromFile(AppInfo.AppFolderPath & "images\hideGlow.jpg")
      ElseIf picCondenserVisibility.Tag = "collapsed" Then
         picCondenserVisibility.Image = Image.FromFile(AppInfo.AppFolderPath & "images\showGlow.jpg")
      End If
   End Sub
   Private Sub picCondenserVisibility_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picCondenserVisibility.MouseLeave
      If picCondenserVisibility.Tag = "expanded" Then
         picCondenserVisibility.Image = Image.FromFile(AppInfo.AppFolderPath & "images\hide.jpg")
      ElseIf picCondenserVisibility.Tag = "collapsed" Then
         picCondenserVisibility.Image = Image.FromFile(AppInfo.AppFolderPath & "images\show.jpg")
      End If
   End Sub
   Private Sub picCondenserVisibility_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picCondenserVisibility.Click
      If picCondenserVisibility.Tag = "expanded" Then
         picCondenserVisibility.Tag = "collapsed"
         ToolTip1.SetToolTip(picCondenserVisibility, "Show condenser section")
         picCondenserVisibility.Image = Image.FromFile(AppInfo.AppFolderPath & "images\showGlow.jpg")
         panCondenserBody.Hide()
      ElseIf picCondenserVisibility.Tag = "collapsed" Then
         picCondenserVisibility.Tag = "expanded"
         ToolTip1.SetToolTip(picCondenserVisibility, "Hide condenser section")
         picCondenserVisibility.Image = Image.FromFile(AppInfo.AppFolderPath & "images\hideGlow.jpg")
         panCondenserBody.Show()
      End If
   End Sub

   'evaporator section's visibility button
   Private Sub picEvaporatorVisibility_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picEvaporatorVisibility.MouseEnter
      If picEvaporatorVisibility.Tag = "expanded" Then
         picEvaporatorVisibility.Image = Image.FromFile(AppInfo.AppFolderPath & "images\hideGlow.jpg")
      ElseIf picEvaporatorVisibility.Tag = "collapsed" Then
         picEvaporatorVisibility.Image = Image.FromFile(AppInfo.AppFolderPath & "images\showGlow.jpg")
      End If
   End Sub
   Private Sub picEvaporatorVisibility_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picEvaporatorVisibility.MouseLeave
      If picEvaporatorVisibility.Tag = "expanded" Then
         picEvaporatorVisibility.Image = Image.FromFile(AppInfo.AppFolderPath & "images\hide.jpg")
      ElseIf picEvaporatorVisibility.Tag = "collapsed" Then
         picEvaporatorVisibility.Image = Image.FromFile(AppInfo.AppFolderPath & "images\show.jpg")
      End If
   End Sub
   Private Sub picEvaporatorVisibility_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picEvaporatorVisibility.Click
      If picEvaporatorVisibility.Tag = "expanded" Then
         picEvaporatorVisibility.Tag = "collapsed"
         ToolTip1.SetToolTip(picEvaporatorVisibility, "Show evaporator section")
         picEvaporatorVisibility.Image = Image.FromFile(AppInfo.AppFolderPath & "images\showGlow.jpg")
         panEvaporatorBody.Hide()
      ElseIf picEvaporatorVisibility.Tag = "collapsed" Then
         picEvaporatorVisibility.Tag = "expanded"
         ToolTip1.SetToolTip(picEvaporatorVisibility, "Hide evaporator section")
         picEvaporatorVisibility.Image = Image.FromFile(AppInfo.AppFolderPath & "images\hideGlow.jpg")
         panEvaporatorBody.Show()
      End If
   End Sub
#End Region


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


   Private Sub btnCalculatePage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles btnCalculatePage.Click
      ' determines whether chiller form is valid
      If Not Me.chillerVMgr.Validate() Then
         Ui.MessageBox.Show(Me.chillerVMgr.ErrorMessagesSummary, MessageBoxIcon.Warning)
         Exit Sub : End If

      Me.Cursor = Cursors.WaitCursor
      start_cal()

      ' deletes temporary database; if there is multiple circuits;
      Dim dbPath As String = AppInfo.AppFolderPath & "Reports\" & Me.MyFileNameMDB
      Io.FileTasks.Delete(dbPath)

      Me.Cursor = Cursors.Default
   End Sub


   'Private Sub btnCreateReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateReport.Click
   '   Me.Cursor = Cursors.WaitCursor
   '   start_cal()
   '   If grdResults.Visible = True Then
   '      CreateReport()
   '   ElseIf grdResults.Visible = False Then
   '      TXT_ERROR_1_BOX.Text &= Chr(10) & Chr(13) & "Report could not be created."
   '   End If

   '   ' deletes database that the report was created from
   '   Dim dbPath As String = AppInfo.AppFolderPath & "Reports\" & Me.MyFileNameMDB
   '   Io.FileTasks.Delete(dbPath)

   '   Me.Cursor = Cursors.Default
   'End Sub

   Private Sub mnuChillerRepPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuChillerRepPrint.Click
      Dim doc As New C1.C1PrintDocument.C1PrintDocument
      'controls font and other styles on printed page
      Dim printStyle As New C1.C1PrintDocument.C1DocStyle(doc)  'used in rendering spacer image
      printStyle.Font = New Font("Arial", 10, FontStyle.Regular)
      'the page settings from frmC1PrintPreview.vb are not applied
      'page settings must be set in code in order to be applied
      doc.PageSettings.Margins.Top = 50
      doc.PageSettings.Margins.Bottom = 50

      doc.DefaultUnit = C1.C1PrintDocument.UnitTypeEnum.Mm
      'header
      doc.PageHeader.Height = 8
      doc.PageHeader.RenderText.Style = printStyle
      doc.PageHeader.RenderText.Style.TextAlignHorz = C1.C1PrintDocument.AlignHorzEnum.Center
      doc.PageHeader.RenderText.Style.TextAlignVert = C1.C1PrintDocument.AlignVertEnum.Top
      doc.PageHeader.RenderText.Text = Me.Text
      'footer
      doc.PageFooter.Height = 8
      doc.PageFooter.RenderText.Style = printStyle
      doc.PageFooter.RenderText.Style.TextAlignHorz = C1.C1PrintDocument.AlignHorzEnum.Right
      doc.PageFooter.RenderText.Style.TextAlignVert = C1.C1PrintDocument.AlignVertEnum.Bottom
      doc.PageFooter.RenderText.Text = "Page [@@PageNo@@] of [@@PageCount@@]"

      doc.StartDoc() 'start rendering
      doc.RenderBlockControlImage(Me.panTop)
      doc.RenderBlockControlImage(Me.panCriteriaHeader)
      doc.RenderBlockControlImage(Me.panCriteriaControls)
      doc.RenderBlockControlImage(Me.panCompressorHeader)
      doc.RenderBlockControlImage(Me.panCompressorControls)
      doc.RenderBlockControlImage(Me.panCondenserHeader)
      doc.RenderBlockControlImage(Me.panCondenserControls)
      doc.RenderBlockControlImage(Me.panEvaporatorHeader)
      doc.RenderBlockControlImage(Me.panEvaporatorControls)

      'image is used to fill space at the end of a page
      'implemented to function as a page return
      Dim whiteImage As Image
      whiteImage = Image.FromFile(AppInfo.AppFolderPath & "Images\whitebox.gif")
      doc.RenderBlockImage(whiteImage, 3, doc.AvailableBlockFlowHeight, printStyle)
      'page return
      doc.RenderBlockControlImage(Me.lblLimits)
      doc.RenderBlockControlSmart(Me.grdResults)
      doc.RenderBlockControlImage(Me.panFooter)

      'page return		
      'doc.RenderBlockImage(whiteImage, 3, doc.AvailableBlockFlowHeight, printStyle)

      doc.EndDoc() 'stop rendering

      Dim formPreview As New C1PrintPreviewForm 'create instance form to preview before printing
      formPreview.C1PrintPreview1.Document = doc 'set the form's document to the document just created
      formPreview.ShowDialog() 'can't have mdiparent otherwise error occurs
      formPreview.Dispose()
   End Sub
End Class
'7023