Imports System.Math
Imports System.Runtime.InteropServices
Imports CREngine = CrystalDecisions.CrystalReports.Engine
Imports CRShared = CrystalDecisions.Shared
Imports VB = Microsoft.VisualBasic
Imports GlycolNames = Rae.RaeSolutions.DataAccess.Chillers.GlycolColumnNames
Imports Forms = System.Windows.Forms
Imports Rae.Validation
Imports Rae.Solutions.Chillers
Imports Rae.Solutions.Chillers.chiller
Imports BCI = Rae.RaeSolutions.Business.Intelligence.Chillers
Imports BCA = Rae.RaeSolutions.Business.Agents.ChillerAgent
Imports System.Data
Imports Rae.RaeSolutions.DataAccess
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.Math.Calculate


Public Class ChillerWaterCooledForm
   Inherits Forms.Form
'   Public ProcessDeleted As Boolean
'   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
'   Friend WithEvents saveAsRevisionMenuItem As System.Windows.Forms.ToolStripMenuItem
'   Friend WithEvents saveAsMenuItem As System.Windows.Forms.ToolStripMenuItem
'   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
'   Friend WithEvents convertToEquipmentMenuItem As System.Windows.Forms.ToolStripMenuItem
'   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
'   ' Revision Control / Saving Variables...
'   ' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
'   ' Last saved state...
'   Public LastSavedProcess As Rae.RaeSolutions.Business.Entities.WCChillerProcessItem
'   ' Current state before save...
'   Public CurrentStateProcess As Rae.RaeSolutions.Business.Entities.WCChillerProcessItem
'   ' Current displayed state revision 
'   ' number reference...
'   Private m_CurrentRevision As Single = -1

'   Private dtb As DataTable
'   Friend WithEvents controlFactorsPanel As System.Windows.Forms.Panel
'   Friend WithEvents optionsHeaderLabel As System.Windows.Forms.Label
'   Friend WithEvents condenserCapacityFactorTextBox As System.Windows.Forms.TextBox
'   Friend WithEvents compressorAmpFactorTextBox As System.Windows.Forms.TextBox
'   Friend WithEvents compressorKwFactorTextBox As System.Windows.Forms.TextBox
'   Friend WithEvents compressorCapacityFactorTextBox As System.Windows.Forms.TextBox
'   Friend WithEvents compressorAmpFactorLabel As System.Windows.Forms.Label
'   Friend WithEvents compressorKwFactorLabel As System.Windows.Forms.Label
'   Friend WithEvents compressorCapacityFactorLabel As System.Windows.Forms.Label
'   Friend WithEvents condenserCapacityFactorLabel As System.Windows.Forms.Label
'   Friend WithEvents Label1 As System.Windows.Forms.Label
'   ''' <summary>
'   ''' The current revision # of process 
'   ''' being displayed on this form.
'   ''' </summary>
'   Public Property CurrentRevision() As Single
'      Get
'         Return Me.m_CurrentRevision
'      End Get
'      Set(ByVal value As Single)
'         Me.m_CurrentRevision = value
'      End Set
'   End Property
'   ' Latest revision # of the current 
'   ' process ID (if any)...
'   Private m_LatestRevision As Single = -1
'   ''' <summary>
'   ''' The latest revision # of process 
'   ''' being displayed on this form.
'   ''' </summary>
'   Public Property LatestRevision() As Single
'      Get
'         Return Me.m_LatestRevision
'      End Get
'      Set(ByVal value As Single)
'         Me.m_LatestRevision = value
'      End Set
'   End Property
'   ' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~



'#Region " Windows Form Designer generated code "

'   Public Sub New()
'      MyBase.New()

'      'This call is required by the Windows Form Designer.
'      InitializeComponent()

'      '**************************************************************
'      '** Add any initialization after the InitializeComponent() call
'      '**************************************************************

'   End Sub

'   'Form overrides dispose to clean up the component list.
'   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
'      If disposing Then
'         If Not (components Is Nothing) Then
'            components.Dispose()
'         End If
'      End If
'      MyBase.Dispose(disposing)
'   End Sub

'   'Required by the Windows Form Designer
'   Private components As System.ComponentModel.IContainer

'   'NOTE: The following procedure is required by the Windows Form Designer
'   'It can be modified using the Windows Form Designer.  
'   'Do not modify it using the code editor.
'   Friend WithEvents panCirc As System.Windows.Forms.Panel
'   Friend WithEvents panMain As System.Windows.Forms.Panel
'   Friend WithEvents panRatiCritHide As System.Windows.Forms.Panel
'   Friend WithEvents panCompDataHide As System.Windows.Forms.Panel
'   Friend WithEvents panCondHide As System.Windows.Forms.Panel
'   Friend WithEvents lblErro As System.Windows.Forms.Label
'   Friend WithEvents DropDownList1 As System.Windows.Forms.ComboBox
'   Friend WithEvents DropDownList2 As System.Windows.Forms.ComboBox
'   Friend WithEvents DropDownList3 As System.Windows.Forms.ComboBox
'   Friend WithEvents Txt_circuit_per_unit As System.Windows.Forms.TextBox
'   Friend WithEvents txtCondenser_1 As System.Windows.Forms.TextBox
'   Friend WithEvents txtCondenser_2 As System.Windows.Forms.TextBox
'   Friend WithEvents panEvapHide As System.Windows.Forms.Panel
'   Friend WithEvents Panel1 As System.Windows.Forms.Panel
'   Friend WithEvents tbxEvap8Degr1 As System.Windows.Forms.TextBox
'   Friend WithEvents tbxEvap8Degr2 As System.Windows.Forms.TextBox
'   Friend WithEvents panGrid As System.Windows.Forms.Panel
'   Friend WithEvents lblOperLimi As System.Windows.Forms.Label
'   Friend WithEvents tbxEvap10Degr1 As System.Windows.Forms.TextBox
'   Friend WithEvents tbxEvap10Degr2 As System.Windows.Forms.TextBox
'   Friend WithEvents cboVolts As System.Windows.Forms.ComboBox
'   Friend WithEvents txt_Evap_Length As System.Windows.Forms.TextBox
'   Friend WithEvents lblRatiVolt As System.Windows.Forms.Label
'   Friend WithEvents lblRatiVolt1 As System.Windows.Forms.Label
'   Friend WithEvents tbxEvap4 As System.Windows.Forms.TextBox
'   Friend WithEvents tbxEvap5 As System.Windows.Forms.TextBox
'   Friend WithEvents tbxEvap6 As System.Windows.Forms.TextBox
'   Friend WithEvents tbxEvap7 As System.Windows.Forms.TextBox
'   Friend WithEvents tbxEvap8 As System.Windows.Forms.TextBox
'   Friend WithEvents tbxEvap9 As System.Windows.Forms.TextBox
'   Friend WithEvents tbxEvap10 As System.Windows.Forms.TextBox
'   Friend WithEvents tbxEvap11 As System.Windows.Forms.TextBox
'   Friend WithEvents tbxEvap12 As System.Windows.Forms.TextBox
'   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
'   Friend WithEvents panFooter As System.Windows.Forms.Panel
'   Friend WithEvents picError As System.Windows.Forms.PictureBox
'   Friend WithEvents btnCalculatePage As System.Windows.Forms.Button
'   Friend WithEvents btnCreateReport As System.Windows.Forms.Button
'   Friend WithEvents panEvaporatorApproach As System.Windows.Forms.Panel
'   Friend WithEvents lblCFM As System.Windows.Forms.Label
'   Friend WithEvents lblModel As System.Windows.Forms.Label
'   Friend WithEvents cboSeries As System.Windows.Forms.ComboBox
'   Friend WithEvents btnGlycolChart As System.Windows.Forms.Button
'   Friend WithEvents dgrC1Results As C1.Win.C1TrueDBGrid.C1TrueDBGrid
'   Friend WithEvents lblRatingCriteria As System.Windows.Forms.Label
'   Friend WithEvents lblCondenser As System.Windows.Forms.Label
'   Friend WithEvents lblCompressor As System.Windows.Forms.Label
'   Friend WithEvents lineRatingCriteria As System.Windows.Forms.Button
'   Friend WithEvents lineCompressor As System.Windows.Forms.Button
'   Friend WithEvents lineCondenser As System.Windows.Forms.Button
'   Friend WithEvents lineEvaporator As System.Windows.Forms.Button
'   Friend WithEvents panButtons As System.Windows.Forms.Panel
'   Friend WithEvents panEvaporator As System.Windows.Forms.Panel
'   Friend WithEvents panEvaporatorHeader As System.Windows.Forms.Panel
'   Friend WithEvents panCondenser As System.Windows.Forms.Panel
'   Friend WithEvents panCondenserHeader As System.Windows.Forms.Panel
'   Friend WithEvents panCompressor As System.Windows.Forms.Panel
'   Friend WithEvents panCompressorHeader As System.Windows.Forms.Panel
'   Friend WithEvents panRatingCriteria As System.Windows.Forms.Panel
'   Friend WithEvents panRatingCriteriaHeader As System.Windows.Forms.Panel
'   Friend WithEvents lblEvaporator As System.Windows.Forms.Label
'   Friend WithEvents lblRangeF As System.Windows.Forms.Label
'   Friend WithEvents lblAmbientF As System.Windows.Forms.Label
'   Friend WithEvents lblLeavingFluidF As System.Windows.Forms.Label
'   Friend WithEvents lblSubCoolingF As System.Windows.Forms.Label
'   Friend WithEvents lblFreezePointF As System.Windows.Forms.Label
'   Friend WithEvents lblMinSuctionF As System.Windows.Forms.Label
'   Friend WithEvents lblCondenserTD2F As System.Windows.Forms.Label
'   Friend WithEvents lblAltitudeFt As System.Windows.Forms.Label
'   Friend WithEvents lblDischargeLineLossF As System.Windows.Forms.Label
'   Friend WithEvents lblCondenserTD1F As System.Windows.Forms.Label
'   Friend WithEvents lblCondenserCapacityBtuh As System.Windows.Forms.Label
'   Friend WithEvents lblSuctionLineLossF As System.Windows.Forms.Label
'   Friend WithEvents lblCondSubCoolingPercent2 As System.Windows.Forms.Label
'   Friend WithEvents lblCondSubCoolingPercent1 As System.Windows.Forms.Label
'   Friend WithEvents btnAlternateEvaporators As System.Windows.Forms.Button
'   Friend WithEvents btnEvaporatorPlus As System.Windows.Forms.Button
'   Friend WithEvents btnCondenserPlus As System.Windows.Forms.Button
'   Friend WithEvents btnCompressorPlus As System.Windows.Forms.Button
'   Friend WithEvents btnCriteriaPlus As System.Windows.Forms.Button
'   Friend WithEvents cboModels As System.Windows.Forms.ComboBox
'   Friend WithEvents lblSeries As System.Windows.Forms.Label
'   Friend WithEvents txtModel As System.Windows.Forms.TextBox
'   Friend WithEvents lblApproach As System.Windows.Forms.Label
'   Friend WithEvents lblHertz As System.Windows.Forms.Label
'   Friend WithEvents lblSystem As System.Windows.Forms.Label
'   Friend WithEvents lblFreezingPoint As System.Windows.Forms.Label
'   Friend WithEvents lblSpecificGravity As System.Windows.Forms.Label
'   Friend WithEvents lblSpecificHeat As System.Windows.Forms.Label
'   Friend WithEvents lblGlycolPercentage As System.Windows.Forms.Label
'   Friend WithEvents lblFluid As System.Windows.Forms.Label
'   Friend WithEvents lblCoolingMedia As System.Windows.Forms.Label
'   Friend WithEvents lblMinSuctionTemp As System.Windows.Forms.Label
'   Friend WithEvents lblSubCooling As System.Windows.Forms.Label
'   Friend WithEvents lblLeavingFluidTemp As System.Windows.Forms.Label
'   Friend WithEvents lblAmbientTemp As System.Windows.Forms.Label
'   Friend WithEvents lblTempRange As System.Windows.Forms.Label
'   Friend WithEvents lblRefrigerant As System.Windows.Forms.Label
'   Friend WithEvents lblEvaporatorUserCapacities As System.Windows.Forms.Label
'   Friend WithEvents lblEvaporatorCapacity As System.Windows.Forms.Label
'   Friend WithEvents lblFoulingFactor As System.Windows.Forms.Label
'   Friend WithEvents lblEvaporatorModel As System.Windows.Forms.Label
'   Friend WithEvents lbl8DegreeApproach As System.Windows.Forms.Label
'   Friend WithEvents lblEvaporatorCircuit1 As System.Windows.Forms.Label
'   Friend WithEvents lbl10DegreeApproach As System.Windows.Forms.Label
'   Friend WithEvents lblEvaporatorCircuit2 As System.Windows.Forms.Label
'   Friend WithEvents lblFan As System.Windows.Forms.Label
'   Friend WithEvents lblCondenserCapacity2 As System.Windows.Forms.Label
'   Friend WithEvents lblAltitude As System.Windows.Forms.Label
'   Friend WithEvents lblSuctionLineLoss As System.Windows.Forms.Label
'   Friend WithEvents lblDischargeLineLoss As System.Windows.Forms.Label
'   Friend WithEvents lblFanWatts As System.Windows.Forms.Label
'   Friend WithEvents lblCondenserCapacity1 As System.Windows.Forms.Label
'   Friend WithEvents lblNumFans2 As System.Windows.Forms.Label
'   Friend WithEvents lblNumFans1 As System.Windows.Forms.Label
'   Friend WithEvents lblCondenserTD2 As System.Windows.Forms.Label
'   Friend WithEvents lblCondenserTD1 As System.Windows.Forms.Label
'   Friend WithEvents lblSubCooling2 As System.Windows.Forms.Label
'   Friend WithEvents lblSubCooling1 As System.Windows.Forms.Label
'   Friend WithEvents lblCondenser2 As System.Windows.Forms.Label
'   Friend WithEvents lblCondenser1 As System.Windows.Forms.Label
'   Friend WithEvents lblNumCoils2 As System.Windows.Forms.Label
'   Friend WithEvents lblNumCoils1 As System.Windows.Forms.Label
'   Friend WithEvents lblNumCompressors2 As System.Windows.Forms.Label
'   Friend WithEvents lblCompressor2 As System.Windows.Forms.Label
'   Friend WithEvents lblNumCompressors1 As System.Windows.Forms.Label
'   Friend WithEvents lblCompressor1 As System.Windows.Forms.Label
'   Friend WithEvents panModel As System.Windows.Forms.Panel
'   Friend WithEvents txtFreezingPoint As System.Windows.Forms.TextBox
'   Friend WithEvents txtSpecificGravity As System.Windows.Forms.TextBox
'   Friend WithEvents txtSpecificHeat As System.Windows.Forms.TextBox
'   Friend WithEvents txtGlycolPercentage As System.Windows.Forms.TextBox
'   Friend WithEvents cboFluid As System.Windows.Forms.ComboBox
'   Friend WithEvents cboCoolingMedia As System.Windows.Forms.ComboBox
'   Friend WithEvents txtSuctionTemp As System.Windows.Forms.TextBox
'   Friend WithEvents txtSubCooling As System.Windows.Forms.TextBox
'   Friend WithEvents txtApproach As System.Windows.Forms.TextBox
'   Friend WithEvents cboHertz As System.Windows.Forms.ComboBox
'   Friend WithEvents cboSystem As System.Windows.Forms.ComboBox
'   Friend WithEvents txtLeavingFluidTemp As System.Windows.Forms.TextBox
'   Friend WithEvents txtAmbientTemp As System.Windows.Forms.TextBox
'   Friend WithEvents txtTempRange As System.Windows.Forms.TextBox
'   Friend WithEvents cboRefrigerant As System.Windows.Forms.ComboBox
'   Friend WithEvents cboSafetyOverride As System.Windows.Forms.CheckBox
'   Friend WithEvents txtNumCompressors2 As System.Windows.Forms.TextBox
'   Friend WithEvents txtCompressor2 As System.Windows.Forms.TextBox
'   Friend WithEvents txtNumCompressors1 As System.Windows.Forms.TextBox
'   Friend WithEvents txtCompressor1 As System.Windows.Forms.TextBox
'   Friend WithEvents lboCompressors2 As System.Windows.Forms.ListBox
'   Friend WithEvents lboCompressors1 As System.Windows.Forms.ListBox
'   Friend WithEvents radCircuit2 As System.Windows.Forms.RadioButton
'   Friend WithEvents radCircuit1 As System.Windows.Forms.RadioButton
'   Friend WithEvents txtAltitude As System.Windows.Forms.TextBox
'   Friend WithEvents cboSuctionLineLoss As System.Windows.Forms.ComboBox
'   Friend WithEvents cboDischargeLineLoss As System.Windows.Forms.ComboBox
'   Friend WithEvents txtFanWatts As System.Windows.Forms.TextBox
'   Friend WithEvents cboFan As System.Windows.Forms.ComboBox
'   Friend WithEvents txtNumFans2 As System.Windows.Forms.TextBox
'   Friend WithEvents txtNumFans1 As System.Windows.Forms.TextBox
'   Friend WithEvents txtCondenserTD2 As System.Windows.Forms.TextBox
'   Friend WithEvents txtCondenserTD1 As System.Windows.Forms.TextBox
'   Friend WithEvents txtSubCooling2 As System.Windows.Forms.TextBox
'   Friend WithEvents txtSubCooling1 As System.Windows.Forms.TextBox
'   Friend WithEvents cboSubCooling2 As System.Windows.Forms.ComboBox
'   Friend WithEvents cboSubCooling1 As System.Windows.Forms.ComboBox
'   Friend WithEvents cboCondenser2 As System.Windows.Forms.ComboBox
'   Friend WithEvents cboCondenser1 As System.Windows.Forms.ComboBox
'   Friend WithEvents txtNumCoils2 As System.Windows.Forms.TextBox
'   Friend WithEvents lblCircuit2 As System.Windows.Forms.Label
'   Friend WithEvents lblCircuit1 As System.Windows.Forms.Label
'   Friend WithEvents txtCfmOverride As System.Windows.Forms.TextBox
'   Friend WithEvents txtCondenserCapacity2 As System.Windows.Forms.TextBox
'   Friend WithEvents txtCondenserCapacity1 As System.Windows.Forms.TextBox
'   Friend WithEvents chkCatalogRating As System.Windows.Forms.CheckBox
'   Friend WithEvents cboFoulingFactor As System.Windows.Forms.ComboBox
'   Friend WithEvents cboEvaporatorModel As System.Windows.Forms.ComboBox
'   Friend WithEvents txtEvaporatorModel As System.Windows.Forms.TextBox
'   Friend WithEvents txtEvaporatorCapacity As System.Windows.Forms.TextBox
'   Friend WithEvents radGpm As System.Windows.Forms.RadioButton
'   Friend WithEvents radTons As System.Windows.Forms.RadioButton
'   Friend WithEvents txtCapacityAt9FApproach As System.Windows.Forms.TextBox
'   Friend WithEvents lbl11FApproach As System.Windows.Forms.Label
'   Friend WithEvents txtCapacityAt4FApproach As System.Windows.Forms.TextBox
'   Friend WithEvents txtCapacityAt12FApproach As System.Windows.Forms.TextBox
'   Friend WithEvents lbl5FApproach As System.Windows.Forms.Label
'   Friend WithEvents txtCapacityAt11FApproach As System.Windows.Forms.TextBox
'   Friend WithEvents txtCapacityAt8FApproach As System.Windows.Forms.TextBox
'   Friend WithEvents txtCapacityAt7FApproach As System.Windows.Forms.TextBox
'   Friend WithEvents lbl9FApproach As System.Windows.Forms.Label
'   Friend WithEvents txtCapacityAt5FApproach As System.Windows.Forms.TextBox
'   Friend WithEvents lbl7FApproach As System.Windows.Forms.Label
'   Friend WithEvents lbl6FApproach As System.Windows.Forms.Label
'   Friend WithEvents txtCapacityAt6FApproach As System.Windows.Forms.TextBox
'   Friend WithEvents lbl8FApproach As System.Windows.Forms.Label
'   Friend WithEvents lbl10FApproach As System.Windows.Forms.Label
'   Friend WithEvents lbl4FApproach As System.Windows.Forms.Label
'   Friend WithEvents lbl12FApproach As System.Windows.Forms.Label
'   Friend WithEvents rad10To12Approach As System.Windows.Forms.RadioButton
'   Friend WithEvents rad9To11Approach As System.Windows.Forms.RadioButton
'   Friend WithEvents rad8To10Approach As System.Windows.Forms.RadioButton
'   Friend WithEvents rad7To9Approach As System.Windows.Forms.RadioButton
'   Friend WithEvents rad6To8Approach As System.Windows.Forms.RadioButton
'   Friend WithEvents radOtherEvaporator As System.Windows.Forms.RadioButton
'   Friend WithEvents txtCapacityAt10FApproach As System.Windows.Forms.TextBox
'   Friend WithEvents chkNewCoefficients As System.Windows.Forms.CheckBox
'   Friend WithEvents txtNumCoils1 As System.Windows.Forms.TextBox
'   Friend WithEvents Label3 As System.Windows.Forms.Label
'   Friend WithEvents Label2 As System.Windows.Forms.Label
'   Friend WithEvents txtCondTemp As System.Windows.Forms.TextBox
'   Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
'   Friend WithEvents fileMenuItem As System.Windows.Forms.ToolStripMenuItem
'   Friend WithEvents printMenuItem As System.Windows.Forms.ToolStripMenuItem
'   Friend WithEvents saveMenuItem As System.Windows.Forms.ToolStripMenuItem
'   Friend WithEvents err As System.Windows.Forms.ErrorProvider
'   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
'      Me.components = New System.ComponentModel.Container
'      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChillerWaterCooledForm))
'      Me.lblModel = New System.Windows.Forms.Label
'      Me.panMain = New System.Windows.Forms.Panel
'      Me.panGrid = New System.Windows.Forms.Panel
'      Me.dgrC1Results = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
'      Me.lblOperLimi = New System.Windows.Forms.Label
'      Me.panEvapHide = New System.Windows.Forms.Panel
'      Me.txt_Evap_Length = New System.Windows.Forms.TextBox
'      Me.panEvaporator = New System.Windows.Forms.Panel
'      Me.lblEvaporatorUserCapacities = New System.Windows.Forms.Label
'      Me.chkCatalogRating = New System.Windows.Forms.CheckBox
'      Me.panEvaporatorApproach = New System.Windows.Forms.Panel
'      Me.txtCapacityAt9FApproach = New System.Windows.Forms.TextBox
'      Me.lbl11FApproach = New System.Windows.Forms.Label
'      Me.txtCapacityAt4FApproach = New System.Windows.Forms.TextBox
'      Me.txtCapacityAt12FApproach = New System.Windows.Forms.TextBox
'      Me.lbl5FApproach = New System.Windows.Forms.Label
'      Me.txtCapacityAt11FApproach = New System.Windows.Forms.TextBox
'      Me.txtCapacityAt10FApproach = New System.Windows.Forms.TextBox
'      Me.txtCapacityAt8FApproach = New System.Windows.Forms.TextBox
'      Me.txtCapacityAt7FApproach = New System.Windows.Forms.TextBox
'      Me.lbl9FApproach = New System.Windows.Forms.Label
'      Me.txtCapacityAt5FApproach = New System.Windows.Forms.TextBox
'      Me.lbl7FApproach = New System.Windows.Forms.Label
'      Me.lbl6FApproach = New System.Windows.Forms.Label
'      Me.txtCapacityAt6FApproach = New System.Windows.Forms.TextBox
'      Me.lbl8FApproach = New System.Windows.Forms.Label
'      Me.lbl10FApproach = New System.Windows.Forms.Label
'      Me.lbl4FApproach = New System.Windows.Forms.Label
'      Me.lbl12FApproach = New System.Windows.Forms.Label
'      Me.lblEvaporatorCapacity = New System.Windows.Forms.Label
'      Me.tbxEvap4 = New System.Windows.Forms.TextBox
'      Me.tbxEvap10 = New System.Windows.Forms.TextBox
'      Me.tbxEvap12 = New System.Windows.Forms.TextBox
'      Me.tbxEvap11 = New System.Windows.Forms.TextBox
'      Me.tbxEvap7 = New System.Windows.Forms.TextBox
'      Me.tbxEvap9 = New System.Windows.Forms.TextBox
'      Me.tbxEvap6 = New System.Windows.Forms.TextBox
'      Me.tbxEvap8 = New System.Windows.Forms.TextBox
'      Me.tbxEvap5 = New System.Windows.Forms.TextBox
'      Me.cboFoulingFactor = New System.Windows.Forms.ComboBox
'      Me.lblFoulingFactor = New System.Windows.Forms.Label
'      Me.btnAlternateEvaporators = New System.Windows.Forms.Button
'      Me.cboEvaporatorModel = New System.Windows.Forms.ComboBox
'      Me.lblEvaporatorModel = New System.Windows.Forms.Label
'      Me.txtEvaporatorModel = New System.Windows.Forms.TextBox
'      Me.radGpm = New System.Windows.Forms.RadioButton
'      Me.radTons = New System.Windows.Forms.RadioButton
'      Me.txtEvaporatorCapacity = New System.Windows.Forms.TextBox
'      Me.lbl8DegreeApproach = New System.Windows.Forms.Label
'      Me.lblEvaporatorCircuit1 = New System.Windows.Forms.Label
'      Me.tbxEvap10Degr2 = New System.Windows.Forms.TextBox
'      Me.tbxEvap8Degr2 = New System.Windows.Forms.TextBox
'      Me.tbxEvap10Degr1 = New System.Windows.Forms.TextBox
'      Me.lbl10DegreeApproach = New System.Windows.Forms.Label
'      Me.tbxEvap8Degr1 = New System.Windows.Forms.TextBox
'      Me.lblEvaporatorCircuit2 = New System.Windows.Forms.Label
'      Me.Panel1 = New System.Windows.Forms.Panel
'      Me.rad10To12Approach = New System.Windows.Forms.RadioButton
'      Me.rad9To11Approach = New System.Windows.Forms.RadioButton
'      Me.rad8To10Approach = New System.Windows.Forms.RadioButton
'      Me.rad7To9Approach = New System.Windows.Forms.RadioButton
'      Me.rad6To8Approach = New System.Windows.Forms.RadioButton
'      Me.radOtherEvaporator = New System.Windows.Forms.RadioButton
'      Me.panEvaporatorHeader = New System.Windows.Forms.Panel
'      Me.lineEvaporator = New System.Windows.Forms.Button
'      Me.btnEvaporatorPlus = New System.Windows.Forms.Button
'      Me.lblEvaporator = New System.Windows.Forms.Label
'      Me.panCondHide = New System.Windows.Forms.Panel
'      Me.txtCondenser_2 = New System.Windows.Forms.TextBox
'      Me.txtCondenser_1 = New System.Windows.Forms.TextBox
'      Me.Txt_circuit_per_unit = New System.Windows.Forms.TextBox
'      Me.DropDownList3 = New System.Windows.Forms.ComboBox
'      Me.DropDownList2 = New System.Windows.Forms.ComboBox
'      Me.lblFan = New System.Windows.Forms.Label
'      Me.DropDownList1 = New System.Windows.Forms.ComboBox
'      Me.panCondenser = New System.Windows.Forms.Panel
'      Me.txtCondTemp = New System.Windows.Forms.TextBox
'      Me.Label3 = New System.Windows.Forms.Label
'      Me.Label2 = New System.Windows.Forms.Label
'      Me.lblCondenserTD2F = New System.Windows.Forms.Label
'      Me.lblAltitudeFt = New System.Windows.Forms.Label
'      Me.lblSuctionLineLossF = New System.Windows.Forms.Label
'      Me.lblDischargeLineLossF = New System.Windows.Forms.Label
'      Me.lblCondenserTD1F = New System.Windows.Forms.Label
'      Me.txtNumCoils2 = New System.Windows.Forms.TextBox
'      Me.lblNumCoils2 = New System.Windows.Forms.Label
'      Me.txtNumCoils1 = New System.Windows.Forms.TextBox
'      Me.lblNumCoils1 = New System.Windows.Forms.Label
'      Me.lblCondenserCapacity2 = New System.Windows.Forms.Label
'      Me.lblCondenserCapacityBtuh = New System.Windows.Forms.Label
'      Me.lblAltitude = New System.Windows.Forms.Label
'      Me.txtAltitude = New System.Windows.Forms.TextBox
'      Me.cboSuctionLineLoss = New System.Windows.Forms.ComboBox
'      Me.lblSuctionLineLoss = New System.Windows.Forms.Label
'      Me.lblDischargeLineLoss = New System.Windows.Forms.Label
'      Me.cboDischargeLineLoss = New System.Windows.Forms.ComboBox
'      Me.txtCondenserCapacity2 = New System.Windows.Forms.TextBox
'      Me.txtCondenserCapacity1 = New System.Windows.Forms.TextBox
'      Me.lblCondenserCapacity1 = New System.Windows.Forms.Label
'      Me.txtCondenserTD2 = New System.Windows.Forms.TextBox
'      Me.lblCondenserTD2 = New System.Windows.Forms.Label
'      Me.txtCondenserTD1 = New System.Windows.Forms.TextBox
'      Me.lblCondenserTD1 = New System.Windows.Forms.Label
'      Me.lblCondSubCoolingPercent2 = New System.Windows.Forms.Label
'      Me.lblCondSubCoolingPercent1 = New System.Windows.Forms.Label
'      Me.txtSubCooling2 = New System.Windows.Forms.TextBox
'      Me.txtSubCooling1 = New System.Windows.Forms.TextBox
'      Me.cboSubCooling2 = New System.Windows.Forms.ComboBox
'      Me.lblSubCooling2 = New System.Windows.Forms.Label
'      Me.cboSubCooling1 = New System.Windows.Forms.ComboBox
'      Me.lblSubCooling1 = New System.Windows.Forms.Label
'      Me.cboCondenser2 = New System.Windows.Forms.ComboBox
'      Me.lblCondenser2 = New System.Windows.Forms.Label
'      Me.cboCondenser1 = New System.Windows.Forms.ComboBox
'      Me.lblCondenser1 = New System.Windows.Forms.Label
'      Me.lblCircuit2 = New System.Windows.Forms.Label
'      Me.lblCircuit1 = New System.Windows.Forms.Label
'      Me.cboFan = New System.Windows.Forms.ComboBox
'      Me.txtCfmOverride = New System.Windows.Forms.TextBox
'      Me.lblCFM = New System.Windows.Forms.Label
'      Me.txtNumFans1 = New System.Windows.Forms.TextBox
'      Me.lblNumFans1 = New System.Windows.Forms.Label
'      Me.txtNumFans2 = New System.Windows.Forms.TextBox
'      Me.lblNumFans2 = New System.Windows.Forms.Label
'      Me.txtFanWatts = New System.Windows.Forms.TextBox
'      Me.lblFanWatts = New System.Windows.Forms.Label
'      Me.panCondenserHeader = New System.Windows.Forms.Panel
'      Me.lineCondenser = New System.Windows.Forms.Button
'      Me.btnCondenserPlus = New System.Windows.Forms.Button
'      Me.lblCondenser = New System.Windows.Forms.Label
'      Me.panCompDataHide = New System.Windows.Forms.Panel
'      Me.panCompressor = New System.Windows.Forms.Panel
'      Me.cboSafetyOverride = New System.Windows.Forms.CheckBox
'      Me.lblNumCompressors2 = New System.Windows.Forms.Label
'      Me.lblCompressor2 = New System.Windows.Forms.Label
'      Me.txtNumCompressors2 = New System.Windows.Forms.TextBox
'      Me.txtCompressor2 = New System.Windows.Forms.TextBox
'      Me.lblNumCompressors1 = New System.Windows.Forms.Label
'      Me.txtNumCompressors1 = New System.Windows.Forms.TextBox
'      Me.txtCompressor1 = New System.Windows.Forms.TextBox
'      Me.lblCompressor1 = New System.Windows.Forms.Label
'      Me.lboCompressors2 = New System.Windows.Forms.ListBox
'      Me.lboCompressors1 = New System.Windows.Forms.ListBox
'      Me.panCirc = New System.Windows.Forms.Panel
'      Me.radCircuit2 = New System.Windows.Forms.RadioButton
'      Me.radCircuit1 = New System.Windows.Forms.RadioButton
'      Me.panCompressorHeader = New System.Windows.Forms.Panel
'      Me.lineCompressor = New System.Windows.Forms.Button
'      Me.btnCompressorPlus = New System.Windows.Forms.Button
'      Me.lblCompressor = New System.Windows.Forms.Label
'      Me.panRatiCritHide = New System.Windows.Forms.Panel
'      Me.cboVolts = New System.Windows.Forms.ComboBox
'      Me.panRatingCriteria = New System.Windows.Forms.Panel
'      Me.lblRangeF = New System.Windows.Forms.Label
'      Me.lblAmbientF = New System.Windows.Forms.Label
'      Me.lblLeavingFluidF = New System.Windows.Forms.Label
'      Me.lblSubCoolingF = New System.Windows.Forms.Label
'      Me.lblFreezePointF = New System.Windows.Forms.Label
'      Me.lblMinSuctionF = New System.Windows.Forms.Label
'      Me.lblRatiVolt = New System.Windows.Forms.Label
'      Me.btnGlycolChart = New System.Windows.Forms.Button
'      Me.txtApproach = New System.Windows.Forms.TextBox
'      Me.lblApproach = New System.Windows.Forms.Label
'      Me.lblRatiVolt1 = New System.Windows.Forms.Label
'      Me.cboHertz = New System.Windows.Forms.ComboBox
'      Me.lblHertz = New System.Windows.Forms.Label
'      Me.cboSystem = New System.Windows.Forms.ComboBox
'      Me.lblSystem = New System.Windows.Forms.Label
'      Me.txtFreezingPoint = New System.Windows.Forms.TextBox
'      Me.lblFreezingPoint = New System.Windows.Forms.Label
'      Me.lblSpecificGravity = New System.Windows.Forms.Label
'      Me.lblSpecificHeat = New System.Windows.Forms.Label
'      Me.txtSpecificGravity = New System.Windows.Forms.TextBox
'      Me.txtSpecificHeat = New System.Windows.Forms.TextBox
'      Me.txtGlycolPercentage = New System.Windows.Forms.TextBox
'      Me.lblGlycolPercentage = New System.Windows.Forms.Label
'      Me.cboFluid = New System.Windows.Forms.ComboBox
'      Me.lblFluid = New System.Windows.Forms.Label
'      Me.cboCoolingMedia = New System.Windows.Forms.ComboBox
'      Me.lblCoolingMedia = New System.Windows.Forms.Label
'      Me.txtSuctionTemp = New System.Windows.Forms.TextBox
'      Me.lblMinSuctionTemp = New System.Windows.Forms.Label
'      Me.txtSubCooling = New System.Windows.Forms.TextBox
'      Me.lblSubCooling = New System.Windows.Forms.Label
'      Me.txtLeavingFluidTemp = New System.Windows.Forms.TextBox
'      Me.lblLeavingFluidTemp = New System.Windows.Forms.Label
'      Me.lblAmbientTemp = New System.Windows.Forms.Label
'      Me.txtAmbientTemp = New System.Windows.Forms.TextBox
'      Me.lblTempRange = New System.Windows.Forms.Label
'      Me.txtTempRange = New System.Windows.Forms.TextBox
'      Me.lblRefrigerant = New System.Windows.Forms.Label
'      Me.cboRefrigerant = New System.Windows.Forms.ComboBox
'      Me.panRatingCriteriaHeader = New System.Windows.Forms.Panel
'      Me.lineRatingCriteria = New System.Windows.Forms.Button
'      Me.btnCriteriaPlus = New System.Windows.Forms.Button
'      Me.lblRatingCriteria = New System.Windows.Forms.Label
'      Me.panModel = New System.Windows.Forms.Panel
'      Me.chkNewCoefficients = New System.Windows.Forms.CheckBox
'      Me.cboModels = New System.Windows.Forms.ComboBox
'      Me.cboSeries = New System.Windows.Forms.ComboBox
'      Me.lblSeries = New System.Windows.Forms.Label
'      Me.txtModel = New System.Windows.Forms.TextBox
'      Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
'      Me.fileMenuItem = New System.Windows.Forms.ToolStripMenuItem
'      Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
'      Me.saveMenuItem = New System.Windows.Forms.ToolStripMenuItem
'      Me.saveAsRevisionMenuItem = New System.Windows.Forms.ToolStripMenuItem
'      Me.saveAsMenuItem = New System.Windows.Forms.ToolStripMenuItem
'      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
'      Me.convertToEquipmentMenuItem = New System.Windows.Forms.ToolStripMenuItem
'      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
'      Me.printMenuItem = New System.Windows.Forms.ToolStripMenuItem
'      Me.btnCreateReport = New System.Windows.Forms.Button
'      Me.lblErro = New System.Windows.Forms.Label
'      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
'      Me.panFooter = New System.Windows.Forms.Panel
'      Me.panButtons = New System.Windows.Forms.Panel
'      Me.btnCalculatePage = New System.Windows.Forms.Button
'      Me.picError = New System.Windows.Forms.PictureBox
'      Me.err = New System.Windows.Forms.ErrorProvider(Me.components)
'      Me.controlFactorsPanel = New System.Windows.Forms.Panel
'      Me.Label1 = New System.Windows.Forms.Label
'      Me.optionsHeaderLabel = New System.Windows.Forms.Label
'      Me.condenserCapacityFactorTextBox = New System.Windows.Forms.TextBox
'      Me.compressorAmpFactorTextBox = New System.Windows.Forms.TextBox
'      Me.compressorKwFactorTextBox = New System.Windows.Forms.TextBox
'      Me.compressorCapacityFactorTextBox = New System.Windows.Forms.TextBox
'      Me.compressorAmpFactorLabel = New System.Windows.Forms.Label
'      Me.compressorKwFactorLabel = New System.Windows.Forms.Label
'      Me.compressorCapacityFactorLabel = New System.Windows.Forms.Label
'      Me.condenserCapacityFactorLabel = New System.Windows.Forms.Label
'      Me.panMain.SuspendLayout()
'      Me.panGrid.SuspendLayout()
'      CType(Me.dgrC1Results, System.ComponentModel.ISupportInitialize).BeginInit()
'      Me.panEvapHide.SuspendLayout()
'      Me.panEvaporator.SuspendLayout()
'      Me.panEvaporatorApproach.SuspendLayout()
'      Me.Panel1.SuspendLayout()
'      Me.panEvaporatorHeader.SuspendLayout()
'      Me.panCondHide.SuspendLayout()
'      Me.panCondenser.SuspendLayout()
'      Me.panCondenserHeader.SuspendLayout()
'      Me.panCompDataHide.SuspendLayout()
'      Me.panCompressor.SuspendLayout()
'      Me.panCirc.SuspendLayout()
'      Me.panCompressorHeader.SuspendLayout()
'      Me.panRatiCritHide.SuspendLayout()
'      Me.panRatingCriteria.SuspendLayout()
'      Me.panRatingCriteriaHeader.SuspendLayout()
'      Me.panModel.SuspendLayout()
'      Me.MenuStrip1.SuspendLayout()
'      Me.panFooter.SuspendLayout()
'      Me.panButtons.SuspendLayout()
'      CType(Me.picError, System.ComponentModel.ISupportInitialize).BeginInit()
'      CType(Me.err, System.ComponentModel.ISupportInitialize).BeginInit()
'      Me.controlFactorsPanel.SuspendLayout()
'      Me.SuspendLayout()
'      '
'      'lblModel
'      '
'      Me.lblModel.Location = New System.Drawing.Point(4, 36)
'      Me.lblModel.Name = "lblModel"
'      Me.lblModel.Size = New System.Drawing.Size(64, 23)
'      Me.lblModel.TabIndex = 0
'      Me.lblModel.Text = "Model #"
'      Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'panMain
'      '
'      Me.panMain.AutoScroll = True
'      Me.panMain.BackColor = System.Drawing.Color.White
'      Me.panMain.Controls.Add(Me.panGrid)
'      Me.panMain.Controls.Add(Me.panEvapHide)
'      Me.panMain.Controls.Add(Me.panEvaporatorHeader)
'      Me.panMain.Controls.Add(Me.panCondHide)
'      Me.panMain.Controls.Add(Me.panCondenserHeader)
'      Me.panMain.Controls.Add(Me.panCompDataHide)
'      Me.panMain.Controls.Add(Me.panCompressorHeader)
'      Me.panMain.Controls.Add(Me.panRatiCritHide)
'      Me.panMain.Controls.Add(Me.panRatingCriteriaHeader)
'      Me.panMain.Controls.Add(Me.controlFactorsPanel)
'      Me.panMain.Controls.Add(Me.panModel)
'      Me.panMain.Dock = System.Windows.Forms.DockStyle.Fill
'      Me.panMain.Location = New System.Drawing.Point(0, 0)
'      Me.panMain.Name = "panMain"
'      Me.panMain.Size = New System.Drawing.Size(688, 521)
'      Me.panMain.TabIndex = 3
'      '
'      'panGrid
'      '
'      Me.panGrid.BackColor = System.Drawing.Color.White
'      Me.panGrid.Controls.Add(Me.dgrC1Results)
'      Me.panGrid.Controls.Add(Me.lblOperLimi)
'      Me.panGrid.Dock = System.Windows.Forms.DockStyle.Top
'      Me.panGrid.Location = New System.Drawing.Point(0, 1516)
'      Me.panGrid.Name = "panGrid"
'      Me.panGrid.Size = New System.Drawing.Size(671, 300)
'      Me.panGrid.TabIndex = 20
'      '
'      'dgrC1Results
'      '
'      Me.dgrC1Results.CaptionHeight = 17
'      Me.dgrC1Results.GroupByCaption = "Drag a column header here to group by that column"
'      Me.dgrC1Results.Images.Add(CType(resources.GetObject("dgrC1Results.Images"), System.Drawing.Image))
'      Me.dgrC1Results.Location = New System.Drawing.Point(12, 24)
'      Me.dgrC1Results.Name = "dgrC1Results"
'      Me.dgrC1Results.PreviewInfo.Location = New System.Drawing.Point(0, 0)
'      Me.dgrC1Results.PreviewInfo.Size = New System.Drawing.Size(0, 0)
'      Me.dgrC1Results.PreviewInfo.ZoomFactor = 75
'      Me.dgrC1Results.PrintInfo.PageSettings = CType(resources.GetObject("dgrC1Results.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
'      Me.dgrC1Results.RowHeight = 15
'      Me.dgrC1Results.Size = New System.Drawing.Size(644, 268)
'      Me.dgrC1Results.TabIndex = 3
'      Me.dgrC1Results.Text = "C1TrueDBGrid1"
'      Me.dgrC1Results.PropBag = resources.GetString("dgrC1Results.PropBag")
'      '
'      'lblOperLimi
'      '
'      Me.lblOperLimi.BackColor = System.Drawing.Color.Transparent
'      Me.lblOperLimi.ForeColor = System.Drawing.Color.Red
'      Me.lblOperLimi.Location = New System.Drawing.Point(12, 4)
'      Me.lblOperLimi.Name = "lblOperLimi"
'      Me.lblOperLimi.Size = New System.Drawing.Size(640, 17)
'      Me.lblOperLimi.TabIndex = 0
'      Me.lblOperLimi.Text = "Points outside operating range omitted."
'      Me.lblOperLimi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'      '
'      'panEvapHide
'      '
'      Me.panEvapHide.BackColor = System.Drawing.Color.White
'      Me.panEvapHide.Controls.Add(Me.txt_Evap_Length)
'      Me.panEvapHide.Controls.Add(Me.panEvaporator)
'      Me.panEvapHide.Dock = System.Windows.Forms.DockStyle.Top
'      Me.panEvapHide.Location = New System.Drawing.Point(0, 1012)
'      Me.panEvapHide.Name = "panEvapHide"
'      Me.panEvapHide.Size = New System.Drawing.Size(671, 504)
'      Me.panEvapHide.TabIndex = 9
'      '
'      'txt_Evap_Length
'      '
'      Me.txt_Evap_Length.Location = New System.Drawing.Point(540, 16)
'      Me.txt_Evap_Length.Name = "txt_Evap_Length"
'      Me.txt_Evap_Length.Size = New System.Drawing.Size(100, 21)
'      Me.txt_Evap_Length.TabIndex = 3
'      Me.txt_Evap_Length.Visible = False
'      '
'      'panEvaporator
'      '
'      Me.panEvaporator.BackColor = System.Drawing.Color.White
'      Me.panEvaporator.Controls.Add(Me.lblEvaporatorUserCapacities)
'      Me.panEvaporator.Controls.Add(Me.chkCatalogRating)
'      Me.panEvaporator.Controls.Add(Me.panEvaporatorApproach)
'      Me.panEvaporator.Controls.Add(Me.cboFoulingFactor)
'      Me.panEvaporator.Controls.Add(Me.lblFoulingFactor)
'      Me.panEvaporator.Controls.Add(Me.btnAlternateEvaporators)
'      Me.panEvaporator.Controls.Add(Me.cboEvaporatorModel)
'      Me.panEvaporator.Controls.Add(Me.lblEvaporatorModel)
'      Me.panEvaporator.Controls.Add(Me.txtEvaporatorModel)
'      Me.panEvaporator.Controls.Add(Me.radGpm)
'      Me.panEvaporator.Controls.Add(Me.radTons)
'      Me.panEvaporator.Controls.Add(Me.txtEvaporatorCapacity)
'      Me.panEvaporator.Controls.Add(Me.lbl8DegreeApproach)
'      Me.panEvaporator.Controls.Add(Me.lblEvaporatorCircuit1)
'      Me.panEvaporator.Controls.Add(Me.tbxEvap10Degr2)
'      Me.panEvaporator.Controls.Add(Me.tbxEvap8Degr2)
'      Me.panEvaporator.Controls.Add(Me.tbxEvap10Degr1)
'      Me.panEvaporator.Controls.Add(Me.lbl10DegreeApproach)
'      Me.panEvaporator.Controls.Add(Me.tbxEvap8Degr1)
'      Me.panEvaporator.Controls.Add(Me.lblEvaporatorCircuit2)
'      Me.panEvaporator.Controls.Add(Me.Panel1)
'      Me.panEvaporator.Location = New System.Drawing.Point(12, -1)
'      Me.panEvaporator.Name = "panEvaporator"
'      Me.panEvaporator.Size = New System.Drawing.Size(504, 505)
'      Me.panEvaporator.TabIndex = 0
'      '
'      'lblEvaporatorUserCapacities
'      '
'      Me.lblEvaporatorUserCapacities.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.lblEvaporatorUserCapacities.Location = New System.Drawing.Point(216, 420)
'      Me.lblEvaporatorUserCapacities.Name = "lblEvaporatorUserCapacities"
'      Me.lblEvaporatorUserCapacities.Size = New System.Drawing.Size(112, 19)
'      Me.lblEvaporatorUserCapacities.TabIndex = 14
'      Me.lblEvaporatorUserCapacities.Text = "Capacities (BTUH)"
'      '
'      'chkCatalogRating
'      '
'      Me.chkCatalogRating.FlatStyle = System.Windows.Forms.FlatStyle.System
'      Me.chkCatalogRating.Location = New System.Drawing.Point(172, 120)
'      Me.chkCatalogRating.Name = "chkCatalogRating"
'      Me.chkCatalogRating.Size = New System.Drawing.Size(104, 24)
'      Me.chkCatalogRating.TabIndex = 8
'      Me.chkCatalogRating.Text = "Catalog rating"
'      '
'      'panEvaporatorApproach
'      '
'      Me.panEvaporatorApproach.Controls.Add(Me.txtCapacityAt9FApproach)
'      Me.panEvaporatorApproach.Controls.Add(Me.lbl11FApproach)
'      Me.panEvaporatorApproach.Controls.Add(Me.txtCapacityAt4FApproach)
'      Me.panEvaporatorApproach.Controls.Add(Me.txtCapacityAt12FApproach)
'      Me.panEvaporatorApproach.Controls.Add(Me.lbl5FApproach)
'      Me.panEvaporatorApproach.Controls.Add(Me.txtCapacityAt11FApproach)
'      Me.panEvaporatorApproach.Controls.Add(Me.txtCapacityAt10FApproach)
'      Me.panEvaporatorApproach.Controls.Add(Me.txtCapacityAt8FApproach)
'      Me.panEvaporatorApproach.Controls.Add(Me.txtCapacityAt7FApproach)
'      Me.panEvaporatorApproach.Controls.Add(Me.lbl9FApproach)
'      Me.panEvaporatorApproach.Controls.Add(Me.txtCapacityAt5FApproach)
'      Me.panEvaporatorApproach.Controls.Add(Me.lbl7FApproach)
'      Me.panEvaporatorApproach.Controls.Add(Me.lbl6FApproach)
'      Me.panEvaporatorApproach.Controls.Add(Me.txtCapacityAt6FApproach)
'      Me.panEvaporatorApproach.Controls.Add(Me.lbl8FApproach)
'      Me.panEvaporatorApproach.Controls.Add(Me.lbl10FApproach)
'      Me.panEvaporatorApproach.Controls.Add(Me.lbl4FApproach)
'      Me.panEvaporatorApproach.Controls.Add(Me.lbl12FApproach)
'      Me.panEvaporatorApproach.Controls.Add(Me.lblEvaporatorCapacity)
'      Me.panEvaporatorApproach.Controls.Add(Me.tbxEvap4)
'      Me.panEvaporatorApproach.Controls.Add(Me.tbxEvap10)
'      Me.panEvaporatorApproach.Controls.Add(Me.tbxEvap12)
'      Me.panEvaporatorApproach.Controls.Add(Me.tbxEvap11)
'      Me.panEvaporatorApproach.Controls.Add(Me.tbxEvap7)
'      Me.panEvaporatorApproach.Controls.Add(Me.tbxEvap9)
'      Me.panEvaporatorApproach.Controls.Add(Me.tbxEvap6)
'      Me.panEvaporatorApproach.Controls.Add(Me.tbxEvap8)
'      Me.panEvaporatorApproach.Controls.Add(Me.tbxEvap5)
'      Me.panEvaporatorApproach.Location = New System.Drawing.Point(88, 152)
'      Me.panEvaporatorApproach.Name = "panEvaporatorApproach"
'      Me.panEvaporatorApproach.Size = New System.Drawing.Size(384, 252)
'      Me.panEvaporatorApproach.TabIndex = 49
'      '
'      'txtCapacityAt9FApproach
'      '
'      Me.txtCapacityAt9FApproach.Location = New System.Drawing.Point(24, 156)
'      Me.txtCapacityAt9FApproach.Name = "txtCapacityAt9FApproach"
'      Me.txtCapacityAt9FApproach.ReadOnly = True
'      Me.txtCapacityAt9FApproach.Size = New System.Drawing.Size(65, 21)
'      Me.txtCapacityAt9FApproach.TabIndex = 6
'      Me.txtCapacityAt9FApproach.TabStop = False
'      '
'      'lbl11FApproach
'      '
'      Me.lbl11FApproach.Location = New System.Drawing.Point(96, 204)
'      Me.lbl11FApproach.Name = "lbl11FApproach"
'      Me.lbl11FApproach.Size = New System.Drawing.Size(80, 23)
'      Me.lbl11FApproach.TabIndex = 26
'      Me.lbl11FApproach.Text = "11°F Approach"
'      Me.lbl11FApproach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'txtCapacityAt4FApproach
'      '
'      Me.txtCapacityAt4FApproach.Location = New System.Drawing.Point(24, 36)
'      Me.txtCapacityAt4FApproach.Name = "txtCapacityAt4FApproach"
'      Me.txtCapacityAt4FApproach.ReadOnly = True
'      Me.txtCapacityAt4FApproach.Size = New System.Drawing.Size(65, 21)
'      Me.txtCapacityAt4FApproach.TabIndex = 31
'      Me.txtCapacityAt4FApproach.TabStop = False
'      '
'      'txtCapacityAt12FApproach
'      '
'      Me.txtCapacityAt12FApproach.Location = New System.Drawing.Point(24, 228)
'      Me.txtCapacityAt12FApproach.Name = "txtCapacityAt12FApproach"
'      Me.txtCapacityAt12FApproach.ReadOnly = True
'      Me.txtCapacityAt12FApproach.Size = New System.Drawing.Size(65, 21)
'      Me.txtCapacityAt12FApproach.TabIndex = 25
'      Me.txtCapacityAt12FApproach.TabStop = False
'      '
'      'lbl5FApproach
'      '
'      Me.lbl5FApproach.Location = New System.Drawing.Point(96, 60)
'      Me.lbl5FApproach.Name = "lbl5FApproach"
'      Me.lbl5FApproach.Size = New System.Drawing.Size(80, 23)
'      Me.lbl5FApproach.TabIndex = 29
'      Me.lbl5FApproach.Text = "5°F Approach"
'      Me.lbl5FApproach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'txtCapacityAt11FApproach
'      '
'      Me.txtCapacityAt11FApproach.Location = New System.Drawing.Point(24, 204)
'      Me.txtCapacityAt11FApproach.Name = "txtCapacityAt11FApproach"
'      Me.txtCapacityAt11FApproach.ReadOnly = True
'      Me.txtCapacityAt11FApproach.Size = New System.Drawing.Size(65, 21)
'      Me.txtCapacityAt11FApproach.TabIndex = 24
'      Me.txtCapacityAt11FApproach.TabStop = False
'      '
'      'txtCapacityAt10FApproach
'      '
'      Me.txtCapacityAt10FApproach.Location = New System.Drawing.Point(24, 180)
'      Me.txtCapacityAt10FApproach.Name = "txtCapacityAt10FApproach"
'      Me.txtCapacityAt10FApproach.ReadOnly = True
'      Me.txtCapacityAt10FApproach.Size = New System.Drawing.Size(65, 21)
'      Me.txtCapacityAt10FApproach.TabIndex = 23
'      Me.txtCapacityAt10FApproach.TabStop = False
'      '
'      'txtCapacityAt8FApproach
'      '
'      Me.txtCapacityAt8FApproach.Location = New System.Drawing.Point(24, 132)
'      Me.txtCapacityAt8FApproach.Name = "txtCapacityAt8FApproach"
'      Me.txtCapacityAt8FApproach.ReadOnly = True
'      Me.txtCapacityAt8FApproach.Size = New System.Drawing.Size(65, 21)
'      Me.txtCapacityAt8FApproach.TabIndex = 5
'      Me.txtCapacityAt8FApproach.TabStop = False
'      '
'      'txtCapacityAt7FApproach
'      '
'      Me.txtCapacityAt7FApproach.Location = New System.Drawing.Point(24, 108)
'      Me.txtCapacityAt7FApproach.Name = "txtCapacityAt7FApproach"
'      Me.txtCapacityAt7FApproach.ReadOnly = True
'      Me.txtCapacityAt7FApproach.Size = New System.Drawing.Size(65, 21)
'      Me.txtCapacityAt7FApproach.TabIndex = 4
'      Me.txtCapacityAt7FApproach.TabStop = False
'      '
'      'lbl9FApproach
'      '
'      Me.lbl9FApproach.Location = New System.Drawing.Point(96, 156)
'      Me.lbl9FApproach.Name = "lbl9FApproach"
'      Me.lbl9FApproach.Size = New System.Drawing.Size(80, 23)
'      Me.lbl9FApproach.TabIndex = 21
'      Me.lbl9FApproach.Text = "9°F Approach"
'      Me.lbl9FApproach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'txtCapacityAt5FApproach
'      '
'      Me.txtCapacityAt5FApproach.Location = New System.Drawing.Point(24, 60)
'      Me.txtCapacityAt5FApproach.Name = "txtCapacityAt5FApproach"
'      Me.txtCapacityAt5FApproach.ReadOnly = True
'      Me.txtCapacityAt5FApproach.Size = New System.Drawing.Size(65, 21)
'      Me.txtCapacityAt5FApproach.TabIndex = 30
'      Me.txtCapacityAt5FApproach.TabStop = False
'      '
'      'lbl7FApproach
'      '
'      Me.lbl7FApproach.Location = New System.Drawing.Point(96, 108)
'      Me.lbl7FApproach.Name = "lbl7FApproach"
'      Me.lbl7FApproach.Size = New System.Drawing.Size(80, 23)
'      Me.lbl7FApproach.TabIndex = 20
'      Me.lbl7FApproach.Text = "7°F Approach"
'      Me.lbl7FApproach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'lbl6FApproach
'      '
'      Me.lbl6FApproach.Location = New System.Drawing.Point(96, 84)
'      Me.lbl6FApproach.Name = "lbl6FApproach"
'      Me.lbl6FApproach.Size = New System.Drawing.Size(80, 23)
'      Me.lbl6FApproach.TabIndex = 19
'      Me.lbl6FApproach.Text = "6°F Approach"
'      Me.lbl6FApproach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'txtCapacityAt6FApproach
'      '
'      Me.txtCapacityAt6FApproach.Location = New System.Drawing.Point(24, 84)
'      Me.txtCapacityAt6FApproach.Name = "txtCapacityAt6FApproach"
'      Me.txtCapacityAt6FApproach.ReadOnly = True
'      Me.txtCapacityAt6FApproach.Size = New System.Drawing.Size(65, 21)
'      Me.txtCapacityAt6FApproach.TabIndex = 18
'      Me.txtCapacityAt6FApproach.TabStop = False
'      '
'      'lbl8FApproach
'      '
'      Me.lbl8FApproach.Location = New System.Drawing.Point(96, 132)
'      Me.lbl8FApproach.Name = "lbl8FApproach"
'      Me.lbl8FApproach.Size = New System.Drawing.Size(80, 23)
'      Me.lbl8FApproach.TabIndex = 7
'      Me.lbl8FApproach.Text = "8°F Approach"
'      Me.lbl8FApproach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'lbl10FApproach
'      '
'      Me.lbl10FApproach.Location = New System.Drawing.Point(96, 180)
'      Me.lbl10FApproach.Name = "lbl10FApproach"
'      Me.lbl10FApproach.Size = New System.Drawing.Size(80, 23)
'      Me.lbl10FApproach.TabIndex = 22
'      Me.lbl10FApproach.Text = "10°F Approach"
'      Me.lbl10FApproach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'lbl4FApproach
'      '
'      Me.lbl4FApproach.Location = New System.Drawing.Point(96, 36)
'      Me.lbl4FApproach.Name = "lbl4FApproach"
'      Me.lbl4FApproach.Size = New System.Drawing.Size(80, 23)
'      Me.lbl4FApproach.TabIndex = 28
'      Me.lbl4FApproach.Text = "4°F Approach"
'      Me.lbl4FApproach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'lbl12FApproach
'      '
'      Me.lbl12FApproach.Location = New System.Drawing.Point(96, 228)
'      Me.lbl12FApproach.Name = "lbl12FApproach"
'      Me.lbl12FApproach.Size = New System.Drawing.Size(80, 23)
'      Me.lbl12FApproach.TabIndex = 27
'      Me.lbl12FApproach.Text = "12°F Approach"
'      Me.lbl12FApproach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'lblEvaporatorCapacity
'      '
'      Me.lblEvaporatorCapacity.Location = New System.Drawing.Point(4, 4)
'      Me.lblEvaporatorCapacity.Name = "lblEvaporatorCapacity"
'      Me.lblEvaporatorCapacity.Size = New System.Drawing.Size(120, 26)
'      Me.lblEvaporatorCapacity.TabIndex = 48
'      Me.lblEvaporatorCapacity.Text = "Evaporator Per Circuit Capacity (BTUH)"
'      Me.lblEvaporatorCapacity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'      '
'      'tbxEvap4
'      '
'      Me.tbxEvap4.Location = New System.Drawing.Point(180, 36)
'      Me.tbxEvap4.Name = "tbxEvap4"
'      Me.tbxEvap4.ReadOnly = True
'      Me.tbxEvap4.Size = New System.Drawing.Size(197, 21)
'      Me.tbxEvap4.TabIndex = 39
'      Me.tbxEvap4.TabStop = False
'      '
'      'tbxEvap10
'      '
'      Me.tbxEvap10.Location = New System.Drawing.Point(180, 180)
'      Me.tbxEvap10.Name = "tbxEvap10"
'      Me.tbxEvap10.ReadOnly = True
'      Me.tbxEvap10.Size = New System.Drawing.Size(197, 21)
'      Me.tbxEvap10.TabIndex = 45
'      Me.tbxEvap10.TabStop = False
'      '
'      'tbxEvap12
'      '
'      Me.tbxEvap12.Location = New System.Drawing.Point(180, 228)
'      Me.tbxEvap12.Name = "tbxEvap12"
'      Me.tbxEvap12.ReadOnly = True
'      Me.tbxEvap12.Size = New System.Drawing.Size(197, 21)
'      Me.tbxEvap12.TabIndex = 47
'      Me.tbxEvap12.TabStop = False
'      '
'      'tbxEvap11
'      '
'      Me.tbxEvap11.Location = New System.Drawing.Point(180, 204)
'      Me.tbxEvap11.Name = "tbxEvap11"
'      Me.tbxEvap11.ReadOnly = True
'      Me.tbxEvap11.Size = New System.Drawing.Size(197, 21)
'      Me.tbxEvap11.TabIndex = 46
'      Me.tbxEvap11.TabStop = False
'      '
'      'tbxEvap7
'      '
'      Me.tbxEvap7.Location = New System.Drawing.Point(180, 108)
'      Me.tbxEvap7.Name = "tbxEvap7"
'      Me.tbxEvap7.ReadOnly = True
'      Me.tbxEvap7.Size = New System.Drawing.Size(197, 21)
'      Me.tbxEvap7.TabIndex = 42
'      Me.tbxEvap7.TabStop = False
'      '
'      'tbxEvap9
'      '
'      Me.tbxEvap9.Location = New System.Drawing.Point(180, 156)
'      Me.tbxEvap9.Name = "tbxEvap9"
'      Me.tbxEvap9.ReadOnly = True
'      Me.tbxEvap9.Size = New System.Drawing.Size(197, 21)
'      Me.tbxEvap9.TabIndex = 44
'      Me.tbxEvap9.TabStop = False
'      '
'      'tbxEvap6
'      '
'      Me.tbxEvap6.Location = New System.Drawing.Point(180, 84)
'      Me.tbxEvap6.Name = "tbxEvap6"
'      Me.tbxEvap6.ReadOnly = True
'      Me.tbxEvap6.Size = New System.Drawing.Size(197, 21)
'      Me.tbxEvap6.TabIndex = 41
'      Me.tbxEvap6.TabStop = False
'      '
'      'tbxEvap8
'      '
'      Me.tbxEvap8.Location = New System.Drawing.Point(180, 132)
'      Me.tbxEvap8.Name = "tbxEvap8"
'      Me.tbxEvap8.ReadOnly = True
'      Me.tbxEvap8.Size = New System.Drawing.Size(197, 21)
'      Me.tbxEvap8.TabIndex = 43
'      Me.tbxEvap8.TabStop = False
'      '
'      'tbxEvap5
'      '
'      Me.tbxEvap5.Location = New System.Drawing.Point(180, 60)
'      Me.tbxEvap5.Name = "tbxEvap5"
'      Me.tbxEvap5.ReadOnly = True
'      Me.tbxEvap5.Size = New System.Drawing.Size(197, 21)
'      Me.tbxEvap5.TabIndex = 40
'      Me.tbxEvap5.TabStop = False
'      '
'      'cboFoulingFactor
'      '
'      Me.cboFoulingFactor.Items.AddRange(New Object() {".0001", ".00025", ".0005", ".00075", ".001"})
'      Me.cboFoulingFactor.Location = New System.Drawing.Point(172, 64)
'      Me.cboFoulingFactor.Name = "cboFoulingFactor"
'      Me.cboFoulingFactor.Size = New System.Drawing.Size(72, 21)
'      Me.cboFoulingFactor.TabIndex = 4
'      Me.cboFoulingFactor.Text = ".0001"
'      '
'      'lblFoulingFactor
'      '
'      Me.lblFoulingFactor.Location = New System.Drawing.Point(64, 64)
'      Me.lblFoulingFactor.Name = "lblFoulingFactor"
'      Me.lblFoulingFactor.Size = New System.Drawing.Size(100, 23)
'      Me.lblFoulingFactor.TabIndex = 37
'      Me.lblFoulingFactor.Text = "Fouling factor"
'      Me.lblFoulingFactor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'btnAlternateEvaporators
'      '
'      Me.btnAlternateEvaporators.BackColor = System.Drawing.SystemColors.Control
'      Me.btnAlternateEvaporators.FlatStyle = System.Windows.Forms.FlatStyle.System
'      Me.btnAlternateEvaporators.Location = New System.Drawing.Point(8, 7)
'      Me.btnAlternateEvaporators.Name = "btnAlternateEvaporators"
'      Me.btnAlternateEvaporators.Size = New System.Drawing.Size(156, 23)
'      Me.btnAlternateEvaporators.TabIndex = 1
'      Me.btnAlternateEvaporators.Text = "Select Alternate Evaporators"
'      Me.btnAlternateEvaporators.UseVisualStyleBackColor = False
'      '
'      'cboEvaporatorModel
'      '
'      Me.cboEvaporatorModel.Location = New System.Drawing.Point(172, 8)
'      Me.cboEvaporatorModel.Name = "cboEvaporatorModel"
'      Me.cboEvaporatorModel.Size = New System.Drawing.Size(144, 21)
'      Me.cboEvaporatorModel.TabIndex = 2
'      Me.cboEvaporatorModel.Visible = False
'      '
'      'lblEvaporatorModel
'      '
'      Me.lblEvaporatorModel.Location = New System.Drawing.Point(52, 36)
'      Me.lblEvaporatorModel.Name = "lblEvaporatorModel"
'      Me.lblEvaporatorModel.Size = New System.Drawing.Size(110, 23)
'      Me.lblEvaporatorModel.TabIndex = 33
'      Me.lblEvaporatorModel.Text = "Evaporator model #"
'      Me.lblEvaporatorModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'txtEvaporatorModel
'      '
'      Me.txtEvaporatorModel.Location = New System.Drawing.Point(172, 36)
'      Me.txtEvaporatorModel.Name = "txtEvaporatorModel"
'      Me.txtEvaporatorModel.Size = New System.Drawing.Size(144, 21)
'      Me.txtEvaporatorModel.TabIndex = 3
'      '
'      'radGpm
'      '
'      Me.radGpm.FlatStyle = System.Windows.Forms.FlatStyle.System
'      Me.radGpm.Location = New System.Drawing.Point(116, 92)
'      Me.radGpm.Name = "radGpm"
'      Me.radGpm.Size = New System.Drawing.Size(53, 24)
'      Me.radGpm.TabIndex = 7
'      Me.radGpm.Text = "GPM"
'      '
'      'radTons
'      '
'      Me.radTons.Checked = True
'      Me.radTons.FlatStyle = System.Windows.Forms.FlatStyle.System
'      Me.radTons.Location = New System.Drawing.Point(52, 92)
'      Me.radTons.Name = "radTons"
'      Me.radTons.Size = New System.Drawing.Size(68, 24)
'      Me.radTons.TabIndex = 6
'      Me.radTons.TabStop = True
'      Me.radTons.Text = "Tons or"
'      '
'      'txtEvaporatorCapacity
'      '
'      Me.txtEvaporatorCapacity.Location = New System.Drawing.Point(172, 92)
'      Me.txtEvaporatorCapacity.Name = "txtEvaporatorCapacity"
'      Me.txtEvaporatorCapacity.Size = New System.Drawing.Size(72, 21)
'      Me.txtEvaporatorCapacity.TabIndex = 5
'      Me.txtEvaporatorCapacity.Text = "0"
'      '
'      'lbl8DegreeApproach
'      '
'      Me.lbl8DegreeApproach.Location = New System.Drawing.Point(100, 456)
'      Me.lbl8DegreeApproach.Name = "lbl8DegreeApproach"
'      Me.lbl8DegreeApproach.Size = New System.Drawing.Size(110, 23)
'      Me.lbl8DegreeApproach.TabIndex = 9
'      Me.lbl8DegreeApproach.Text = "8 Degree Approach"
'      Me.lbl8DegreeApproach.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'lblEvaporatorCircuit1
'      '
'      Me.lblEvaporatorCircuit1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.lblEvaporatorCircuit1.Location = New System.Drawing.Point(216, 432)
'      Me.lblEvaporatorCircuit1.Name = "lblEvaporatorCircuit1"
'      Me.lblEvaporatorCircuit1.Size = New System.Drawing.Size(84, 19)
'      Me.lblEvaporatorCircuit1.TabIndex = 10
'      Me.lblEvaporatorCircuit1.Text = "Circuit 1"
'      Me.lblEvaporatorCircuit1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
'      '
'      'tbxEvap10Degr2
'      '
'      Me.tbxEvap10Degr2.Location = New System.Drawing.Point(300, 480)
'      Me.tbxEvap10Degr2.Name = "tbxEvap10Degr2"
'      Me.tbxEvap10Degr2.Size = New System.Drawing.Size(72, 21)
'      Me.tbxEvap10Degr2.TabIndex = 13
'      Me.tbxEvap10Degr2.Text = "0"
'      Me.tbxEvap10Degr2.Visible = False
'      '
'      'tbxEvap8Degr2
'      '
'      Me.tbxEvap8Degr2.Location = New System.Drawing.Point(300, 456)
'      Me.tbxEvap8Degr2.Name = "tbxEvap8Degr2"
'      Me.tbxEvap8Degr2.Size = New System.Drawing.Size(72, 21)
'      Me.tbxEvap8Degr2.TabIndex = 12
'      Me.tbxEvap8Degr2.Text = "0"
'      Me.tbxEvap8Degr2.Visible = False
'      '
'      'tbxEvap10Degr1
'      '
'      Me.tbxEvap10Degr1.Location = New System.Drawing.Point(216, 480)
'      Me.tbxEvap10Degr1.Name = "tbxEvap10Degr1"
'      Me.tbxEvap10Degr1.Size = New System.Drawing.Size(72, 21)
'      Me.tbxEvap10Degr1.TabIndex = 11
'      Me.tbxEvap10Degr1.Text = "0"
'      Me.tbxEvap10Degr1.Visible = False
'      '
'      'lbl10DegreeApproach
'      '
'      Me.lbl10DegreeApproach.Location = New System.Drawing.Point(100, 480)
'      Me.lbl10DegreeApproach.Name = "lbl10DegreeApproach"
'      Me.lbl10DegreeApproach.Size = New System.Drawing.Size(110, 23)
'      Me.lbl10DegreeApproach.TabIndex = 15
'      Me.lbl10DegreeApproach.Text = "10 Degree Approach"
'      Me.lbl10DegreeApproach.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'tbxEvap8Degr1
'      '
'      Me.tbxEvap8Degr1.Location = New System.Drawing.Point(216, 456)
'      Me.tbxEvap8Degr1.Name = "tbxEvap8Degr1"
'      Me.tbxEvap8Degr1.Size = New System.Drawing.Size(72, 21)
'      Me.tbxEvap8Degr1.TabIndex = 10
'      Me.tbxEvap8Degr1.Text = "0"
'      Me.tbxEvap8Degr1.Visible = False
'      '
'      'lblEvaporatorCircuit2
'      '
'      Me.lblEvaporatorCircuit2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.lblEvaporatorCircuit2.Location = New System.Drawing.Point(300, 428)
'      Me.lblEvaporatorCircuit2.Name = "lblEvaporatorCircuit2"
'      Me.lblEvaporatorCircuit2.Size = New System.Drawing.Size(100, 23)
'      Me.lblEvaporatorCircuit2.TabIndex = 11
'      Me.lblEvaporatorCircuit2.Text = "Circuit 2"
'      Me.lblEvaporatorCircuit2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
'      '
'      'Panel1
'      '
'      Me.Panel1.Controls.Add(Me.rad10To12Approach)
'      Me.Panel1.Controls.Add(Me.rad9To11Approach)
'      Me.Panel1.Controls.Add(Me.rad8To10Approach)
'      Me.Panel1.Controls.Add(Me.rad7To9Approach)
'      Me.Panel1.Controls.Add(Me.rad6To8Approach)
'      Me.Panel1.Controls.Add(Me.radOtherEvaporator)
'      Me.Panel1.Location = New System.Drawing.Point(20, 208)
'      Me.Panel1.Name = "Panel1"
'      Me.Panel1.Size = New System.Drawing.Size(116, 236)
'      Me.Panel1.TabIndex = 9
'      '
'      'rad10To12Approach
'      '
'      Me.rad10To12Approach.FlatStyle = System.Windows.Forms.FlatStyle.System
'      Me.rad10To12Approach.Location = New System.Drawing.Point(6, 108)
'      Me.rad10To12Approach.Name = "rad10To12Approach"
'      Me.rad10To12Approach.Size = New System.Drawing.Size(53, 24)
'      Me.rad10To12Approach.TabIndex = 5
'      Me.rad10To12Approach.Text = "10-12"
'      '
'      'rad9To11Approach
'      '
'      Me.rad9To11Approach.FlatStyle = System.Windows.Forms.FlatStyle.System
'      Me.rad9To11Approach.Location = New System.Drawing.Point(6, 84)
'      Me.rad9To11Approach.Name = "rad9To11Approach"
'      Me.rad9To11Approach.Size = New System.Drawing.Size(52, 24)
'      Me.rad9To11Approach.TabIndex = 4
'      Me.rad9To11Approach.Text = "9-11"
'      '
'      'rad8To10Approach
'      '
'      Me.rad8To10Approach.Checked = True
'      Me.rad8To10Approach.FlatStyle = System.Windows.Forms.FlatStyle.System
'      Me.rad8To10Approach.Location = New System.Drawing.Point(6, 60)
'      Me.rad8To10Approach.Name = "rad8To10Approach"
'      Me.rad8To10Approach.Size = New System.Drawing.Size(49, 24)
'      Me.rad8To10Approach.TabIndex = 3
'      Me.rad8To10Approach.TabStop = True
'      Me.rad8To10Approach.Text = "8-10"
'      '
'      'rad7To9Approach
'      '
'      Me.rad7To9Approach.FlatStyle = System.Windows.Forms.FlatStyle.System
'      Me.rad7To9Approach.Location = New System.Drawing.Point(6, 36)
'      Me.rad7To9Approach.Name = "rad7To9Approach"
'      Me.rad7To9Approach.Size = New System.Drawing.Size(50, 24)
'      Me.rad7To9Approach.TabIndex = 2
'      Me.rad7To9Approach.Text = "7-9"
'      '
'      'rad6To8Approach
'      '
'      Me.rad6To8Approach.FlatStyle = System.Windows.Forms.FlatStyle.System
'      Me.rad6To8Approach.Location = New System.Drawing.Point(6, 12)
'      Me.rad6To8Approach.Name = "rad6To8Approach"
'      Me.rad6To8Approach.Size = New System.Drawing.Size(43, 24)
'      Me.rad6To8Approach.TabIndex = 1
'      Me.rad6To8Approach.Text = "6-8"
'      '
'      'radOtherEvaporator
'      '
'      Me.radOtherEvaporator.FlatStyle = System.Windows.Forms.FlatStyle.System
'      Me.radOtherEvaporator.Location = New System.Drawing.Point(5, 208)
'      Me.radOtherEvaporator.Name = "radOtherEvaporator"
'      Me.radOtherEvaporator.Size = New System.Drawing.Size(132, 24)
'      Me.radOtherEvaporator.TabIndex = 6
'      Me.radOtherEvaporator.Text = "Other evaporator"
'      '
'      'panEvaporatorHeader
'      '
'      Me.panEvaporatorHeader.BackColor = System.Drawing.Color.White
'      Me.panEvaporatorHeader.Controls.Add(Me.lineEvaporator)
'      Me.panEvaporatorHeader.Controls.Add(Me.btnEvaporatorPlus)
'      Me.panEvaporatorHeader.Controls.Add(Me.lblEvaporator)
'      Me.panEvaporatorHeader.Dock = System.Windows.Forms.DockStyle.Top
'      Me.panEvaporatorHeader.Location = New System.Drawing.Point(0, 968)
'      Me.panEvaporatorHeader.Name = "panEvaporatorHeader"
'      Me.panEvaporatorHeader.Size = New System.Drawing.Size(671, 44)
'      Me.panEvaporatorHeader.TabIndex = 8
'      '
'      'lineEvaporator
'      '
'      Me.lineEvaporator.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'      Me.lineEvaporator.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
'      Me.lineEvaporator.Location = New System.Drawing.Point(12, 40)
'      Me.lineEvaporator.Name = "lineEvaporator"
'      Me.lineEvaporator.Size = New System.Drawing.Size(500, 2)
'      Me.lineEvaporator.TabIndex = 7
'      Me.lineEvaporator.Text = "Button4"
'      '
'      'btnEvaporatorPlus
'      '
'      Me.btnEvaporatorPlus.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
'      Me.btnEvaporatorPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'      Me.btnEvaporatorPlus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.btnEvaporatorPlus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
'      Me.btnEvaporatorPlus.Location = New System.Drawing.Point(16, 19)
'      Me.btnEvaporatorPlus.Name = "btnEvaporatorPlus"
'      Me.btnEvaporatorPlus.Size = New System.Drawing.Size(20, 18)
'      Me.btnEvaporatorPlus.TabIndex = 1
'      Me.btnEvaporatorPlus.Text = "-"
'      Me.btnEvaporatorPlus.UseVisualStyleBackColor = False
'      '
'      'lblEvaporator
'      '
'      Me.lblEvaporator.BackColor = System.Drawing.Color.White
'      Me.lblEvaporator.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.lblEvaporator.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
'      Me.lblEvaporator.Location = New System.Drawing.Point(44, 16)
'      Me.lblEvaporator.Name = "lblEvaporator"
'      Me.lblEvaporator.Size = New System.Drawing.Size(464, 23)
'      Me.lblEvaporator.TabIndex = 0
'      Me.lblEvaporator.Text = "Evaporator"
'      Me.lblEvaporator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'panCondHide
'      '
'      Me.panCondHide.BackColor = System.Drawing.Color.White
'      Me.panCondHide.Controls.Add(Me.txtCondenser_2)
'      Me.panCondHide.Controls.Add(Me.txtCondenser_1)
'      Me.panCondHide.Controls.Add(Me.Txt_circuit_per_unit)
'      Me.panCondHide.Controls.Add(Me.DropDownList3)
'      Me.panCondHide.Controls.Add(Me.DropDownList2)
'      Me.panCondHide.Controls.Add(Me.lblFan)
'      Me.panCondHide.Controls.Add(Me.DropDownList1)
'      Me.panCondHide.Controls.Add(Me.panCondenser)
'      Me.panCondHide.Controls.Add(Me.cboFan)
'      Me.panCondHide.Controls.Add(Me.txtCfmOverride)
'      Me.panCondHide.Controls.Add(Me.lblCFM)
'      Me.panCondHide.Controls.Add(Me.txtNumFans1)
'      Me.panCondHide.Controls.Add(Me.lblNumFans1)
'      Me.panCondHide.Controls.Add(Me.txtNumFans2)
'      Me.panCondHide.Controls.Add(Me.lblNumFans2)
'      Me.panCondHide.Controls.Add(Me.txtFanWatts)
'      Me.panCondHide.Controls.Add(Me.lblFanWatts)
'      Me.panCondHide.Dock = System.Windows.Forms.DockStyle.Top
'      Me.panCondHide.Location = New System.Drawing.Point(0, 748)
'      Me.panCondHide.Name = "panCondHide"
'      Me.panCondHide.Size = New System.Drawing.Size(671, 220)
'      Me.panCondHide.TabIndex = 7
'      '
'      'txtCondenser_2
'      '
'      Me.txtCondenser_2.Location = New System.Drawing.Point(532, 24)
'      Me.txtCondenser_2.Name = "txtCondenser_2"
'      Me.txtCondenser_2.Size = New System.Drawing.Size(100, 21)
'      Me.txtCondenser_2.TabIndex = 7
'      Me.txtCondenser_2.Visible = False
'      '
'      'txtCondenser_1
'      '
'      Me.txtCondenser_1.Location = New System.Drawing.Point(532, 3)
'      Me.txtCondenser_1.Name = "txtCondenser_1"
'      Me.txtCondenser_1.Size = New System.Drawing.Size(100, 21)
'      Me.txtCondenser_1.TabIndex = 6
'      Me.txtCondenser_1.Visible = False
'      '
'      'Txt_circuit_per_unit
'      '
'      Me.Txt_circuit_per_unit.BackColor = System.Drawing.SystemColors.Info
'      Me.Txt_circuit_per_unit.Location = New System.Drawing.Point(536, 118)
'      Me.Txt_circuit_per_unit.Name = "Txt_circuit_per_unit"
'      Me.Txt_circuit_per_unit.Size = New System.Drawing.Size(100, 21)
'      Me.Txt_circuit_per_unit.TabIndex = 4
'      Me.Txt_circuit_per_unit.Visible = False
'      '
'      'DropDownList3
'      '
'      Me.DropDownList3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
'      Me.DropDownList3.Location = New System.Drawing.Point(532, 90)
'      Me.DropDownList3.Name = "DropDownList3"
'      Me.DropDownList3.Size = New System.Drawing.Size(121, 21)
'      Me.DropDownList3.TabIndex = 3
'      Me.DropDownList3.Visible = False
'      '
'      'DropDownList2
'      '
'      Me.DropDownList2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
'      Me.DropDownList2.Location = New System.Drawing.Point(531, 78)
'      Me.DropDownList2.Name = "DropDownList2"
'      Me.DropDownList2.Size = New System.Drawing.Size(121, 21)
'      Me.DropDownList2.TabIndex = 2
'      Me.DropDownList2.Visible = False
'      '
'      'lblFan
'      '
'      Me.lblFan.Location = New System.Drawing.Point(536, 153)
'      Me.lblFan.Name = "lblFan"
'      Me.lblFan.Size = New System.Drawing.Size(46, 23)
'      Me.lblFan.TabIndex = 58
'      Me.lblFan.Text = "Fan"
'      Me.lblFan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      Me.lblFan.Visible = False
'      '
'      'DropDownList1
'      '
'      Me.DropDownList1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
'      Me.DropDownList1.Location = New System.Drawing.Point(531, 51)
'      Me.DropDownList1.Name = "DropDownList1"
'      Me.DropDownList1.Size = New System.Drawing.Size(121, 21)
'      Me.DropDownList1.TabIndex = 1
'      Me.DropDownList1.Visible = False
'      '
'      'panCondenser
'      '
'      Me.panCondenser.BackColor = System.Drawing.Color.White
'      Me.panCondenser.Controls.Add(Me.txtCondTemp)
'      Me.panCondenser.Controls.Add(Me.Label3)
'      Me.panCondenser.Controls.Add(Me.Label2)
'      Me.panCondenser.Controls.Add(Me.lblCondenserTD2F)
'      Me.panCondenser.Controls.Add(Me.lblAltitudeFt)
'      Me.panCondenser.Controls.Add(Me.lblSuctionLineLossF)
'      Me.panCondenser.Controls.Add(Me.lblDischargeLineLossF)
'      Me.panCondenser.Controls.Add(Me.lblCondenserTD1F)
'      Me.panCondenser.Controls.Add(Me.txtNumCoils2)
'      Me.panCondenser.Controls.Add(Me.lblNumCoils2)
'      Me.panCondenser.Controls.Add(Me.txtNumCoils1)
'      Me.panCondenser.Controls.Add(Me.lblNumCoils1)
'      Me.panCondenser.Controls.Add(Me.lblCondenserCapacity2)
'      Me.panCondenser.Controls.Add(Me.lblCondenserCapacityBtuh)
'      Me.panCondenser.Controls.Add(Me.lblAltitude)
'      Me.panCondenser.Controls.Add(Me.txtAltitude)
'      Me.panCondenser.Controls.Add(Me.cboSuctionLineLoss)
'      Me.panCondenser.Controls.Add(Me.lblSuctionLineLoss)
'      Me.panCondenser.Controls.Add(Me.lblDischargeLineLoss)
'      Me.panCondenser.Controls.Add(Me.cboDischargeLineLoss)
'      Me.panCondenser.Controls.Add(Me.txtCondenserCapacity2)
'      Me.panCondenser.Controls.Add(Me.txtCondenserCapacity1)
'      Me.panCondenser.Controls.Add(Me.lblCondenserCapacity1)
'      Me.panCondenser.Controls.Add(Me.txtCondenserTD2)
'      Me.panCondenser.Controls.Add(Me.lblCondenserTD2)
'      Me.panCondenser.Controls.Add(Me.txtCondenserTD1)
'      Me.panCondenser.Controls.Add(Me.lblCondenserTD1)
'      Me.panCondenser.Controls.Add(Me.lblCondSubCoolingPercent2)
'      Me.panCondenser.Controls.Add(Me.lblCondSubCoolingPercent1)
'      Me.panCondenser.Controls.Add(Me.txtSubCooling2)
'      Me.panCondenser.Controls.Add(Me.txtSubCooling1)
'      Me.panCondenser.Controls.Add(Me.cboSubCooling2)
'      Me.panCondenser.Controls.Add(Me.lblSubCooling2)
'      Me.panCondenser.Controls.Add(Me.cboSubCooling1)
'      Me.panCondenser.Controls.Add(Me.lblSubCooling1)
'      Me.panCondenser.Controls.Add(Me.cboCondenser2)
'      Me.panCondenser.Controls.Add(Me.lblCondenser2)
'      Me.panCondenser.Controls.Add(Me.cboCondenser1)
'      Me.panCondenser.Controls.Add(Me.lblCondenser1)
'      Me.panCondenser.Controls.Add(Me.lblCircuit2)
'      Me.panCondenser.Controls.Add(Me.lblCircuit1)
'      Me.panCondenser.Location = New System.Drawing.Point(12, 0)
'      Me.panCondenser.Name = "panCondenser"
'      Me.panCondenser.Size = New System.Drawing.Size(518, 218)
'      Me.panCondenser.TabIndex = 1
'      '
'      'txtCondTemp
'      '
'      Me.txtCondTemp.Location = New System.Drawing.Point(252, 148)
'      Me.txtCondTemp.Name = "txtCondTemp"
'      Me.txtCondTemp.Size = New System.Drawing.Size(72, 21)
'      Me.txtCondTemp.TabIndex = 68
'      Me.txtCondTemp.Text = "85"
'      '
'      'Label3
'      '
'      Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
'      Me.Label3.Location = New System.Drawing.Point(331, 147)
'      Me.Label3.Name = "Label3"
'      Me.Label3.Size = New System.Drawing.Size(28, 21)
'      Me.Label3.TabIndex = 67
'      Me.Label3.Text = "°F"
'      Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'Label2
'      '
'      Me.Label2.Location = New System.Drawing.Point(130, 148)
'      Me.Label2.Name = "Label2"
'      Me.Label2.Size = New System.Drawing.Size(114, 22)
'      Me.Label2.TabIndex = 66
'      Me.Label2.Text = "Condenser Ent. Temp"
'      Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'lblCondenserTD2F
'      '
'      Me.lblCondenserTD2F.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
'      Me.lblCondenserTD2F.Location = New System.Drawing.Point(433, 83)
'      Me.lblCondenserTD2F.Name = "lblCondenserTD2F"
'      Me.lblCondenserTD2F.Size = New System.Drawing.Size(28, 21)
'      Me.lblCondenserTD2F.TabIndex = 64
'      Me.lblCondenserTD2F.Text = "°F"
'      Me.lblCondenserTD2F.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'lblAltitudeFt
'      '
'      Me.lblAltitudeFt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
'      Me.lblAltitudeFt.Location = New System.Drawing.Point(192, 225)
'      Me.lblAltitudeFt.Name = "lblAltitudeFt"
'      Me.lblAltitudeFt.Size = New System.Drawing.Size(28, 21)
'      Me.lblAltitudeFt.TabIndex = 63
'      Me.lblAltitudeFt.Text = "ft."
'      Me.lblAltitudeFt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      Me.lblAltitudeFt.Visible = False
'      '
'      'lblSuctionLineLossF
'      '
'      Me.lblSuctionLineLossF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
'      Me.lblSuctionLineLossF.Location = New System.Drawing.Point(332, 194)
'      Me.lblSuctionLineLossF.Name = "lblSuctionLineLossF"
'      Me.lblSuctionLineLossF.Size = New System.Drawing.Size(28, 21)
'      Me.lblSuctionLineLossF.TabIndex = 62
'      Me.lblSuctionLineLossF.Text = "°F"
'      Me.lblSuctionLineLossF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'lblDischargeLineLossF
'      '
'      Me.lblDischargeLineLossF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
'      Me.lblDischargeLineLossF.Location = New System.Drawing.Point(334, 172)
'      Me.lblDischargeLineLossF.Name = "lblDischargeLineLossF"
'      Me.lblDischargeLineLossF.Size = New System.Drawing.Size(28, 21)
'      Me.lblDischargeLineLossF.TabIndex = 61
'      Me.lblDischargeLineLossF.Text = "°F"
'      Me.lblDischargeLineLossF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'lblCondenserTD1F
'      '
'      Me.lblCondenserTD1F.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
'      Me.lblCondenserTD1F.Location = New System.Drawing.Point(193, 83)
'      Me.lblCondenserTD1F.Name = "lblCondenserTD1F"
'      Me.lblCondenserTD1F.Size = New System.Drawing.Size(28, 21)
'      Me.lblCondenserTD1F.TabIndex = 60
'      Me.lblCondenserTD1F.Text = "°F"
'      Me.lblCondenserTD1F.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'txtNumCoils2
'      '
'      Me.txtNumCoils2.Location = New System.Drawing.Point(356, 29)
'      Me.txtNumCoils2.Name = "txtNumCoils2"
'      Me.txtNumCoils2.Size = New System.Drawing.Size(72, 21)
'      Me.txtNumCoils2.TabIndex = 15
'      Me.txtNumCoils2.Text = "0"
'      '
'      'lblNumCoils2
'      '
'      Me.lblNumCoils2.Location = New System.Drawing.Point(265, 27)
'      Me.lblNumCoils2.Name = "lblNumCoils2"
'      Me.lblNumCoils2.Size = New System.Drawing.Size(80, 23)
'      Me.lblNumCoils2.TabIndex = 3
'      Me.lblNumCoils2.Text = "WC quantity"
'      Me.lblNumCoils2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'txtNumCoils1
'      '
'      Me.txtNumCoils1.Location = New System.Drawing.Point(116, 33)
'      Me.txtNumCoils1.Name = "txtNumCoils1"
'      Me.txtNumCoils1.Size = New System.Drawing.Size(72, 21)
'      Me.txtNumCoils1.TabIndex = 1
'      Me.txtNumCoils1.Text = "1"
'      '
'      'lblNumCoils1
'      '
'      Me.lblNumCoils1.Location = New System.Drawing.Point(5, 27)
'      Me.lblNumCoils1.Name = "lblNumCoils1"
'      Me.lblNumCoils1.Size = New System.Drawing.Size(104, 23)
'      Me.lblNumCoils1.TabIndex = 2
'      Me.lblNumCoils1.Text = "WC quantity"
'      Me.lblNumCoils1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'lblCondenserCapacity2
'      '
'      Me.lblCondenserCapacity2.Location = New System.Drawing.Point(254, 248)
'      Me.lblCondenserCapacity2.Name = "lblCondenserCapacity2"
'      Me.lblCondenserCapacity2.Size = New System.Drawing.Size(108, 53)
'      Me.lblCondenserCapacity2.TabIndex = 56
'      Me.lblCondenserCapacity2.Text = "WC Cond Cap @ 78 deg WB and 105 Cond Tmp (Per Cond):"
'      Me.lblCondenserCapacity2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      Me.lblCondenserCapacity2.Visible = False
'      '
'      'lblCondenserCapacityBtuh
'      '
'      Me.lblCondenserCapacityBtuh.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
'      Me.lblCondenserCapacityBtuh.Location = New System.Drawing.Point(200, 263)
'      Me.lblCondenserCapacityBtuh.Name = "lblCondenserCapacityBtuh"
'      Me.lblCondenserCapacityBtuh.Size = New System.Drawing.Size(48, 23)
'      Me.lblCondenserCapacityBtuh.TabIndex = 55
'      Me.lblCondenserCapacityBtuh.Text = "MBTUH"
'      Me.lblCondenserCapacityBtuh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      Me.lblCondenserCapacityBtuh.Visible = False
'      '
'      'lblAltitude
'      '
'      Me.lblAltitude.Location = New System.Drawing.Point(9, 226)
'      Me.lblAltitude.Name = "lblAltitude"
'      Me.lblAltitude.Size = New System.Drawing.Size(104, 23)
'      Me.lblAltitude.TabIndex = 53
'      Me.lblAltitude.Text = "Altitude"
'      Me.lblAltitude.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      Me.lblAltitude.Visible = False
'      '
'      'txtAltitude
'      '
'      Me.txtAltitude.Location = New System.Drawing.Point(119, 226)
'      Me.txtAltitude.Name = "txtAltitude"
'      Me.txtAltitude.Size = New System.Drawing.Size(72, 21)
'      Me.txtAltitude.TabIndex = 11
'      Me.txtAltitude.Text = "0"
'      Me.txtAltitude.Visible = False
'      '
'      'cboSuctionLineLoss
'      '
'      Me.cboSuctionLineLoss.Items.AddRange(New Object() {"0", "0.5", "1", "1.5", "2"})
'      Me.cboSuctionLineLoss.Location = New System.Drawing.Point(254, 195)
'      Me.cboSuctionLineLoss.Name = "cboSuctionLineLoss"
'      Me.cboSuctionLineLoss.Size = New System.Drawing.Size(72, 21)
'      Me.cboSuctionLineLoss.TabIndex = 10
'      Me.cboSuctionLineLoss.Text = "0"
'      '
'      'lblSuctionLineLoss
'      '
'      Me.lblSuctionLineLoss.Location = New System.Drawing.Point(147, 193)
'      Me.lblSuctionLineLoss.Name = "lblSuctionLineLoss"
'      Me.lblSuctionLineLoss.Size = New System.Drawing.Size(104, 23)
'      Me.lblSuctionLineLoss.TabIndex = 49
'      Me.lblSuctionLineLoss.Text = "Suction line loss"
'      Me.lblSuctionLineLoss.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'lblDischargeLineLoss
'      '
'      Me.lblDischargeLineLoss.Location = New System.Drawing.Point(140, 170)
'      Me.lblDischargeLineLoss.Name = "lblDischargeLineLoss"
'      Me.lblDischargeLineLoss.Size = New System.Drawing.Size(108, 23)
'      Me.lblDischargeLineLoss.TabIndex = 47
'      Me.lblDischargeLineLoss.Text = "Discharge line loss"
'      Me.lblDischargeLineLoss.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'cboDischargeLineLoss
'      '
'      Me.cboDischargeLineLoss.Items.AddRange(New Object() {"0", "0.5", "1", "1.5", "2"})
'      Me.cboDischargeLineLoss.Location = New System.Drawing.Point(254, 172)
'      Me.cboDischargeLineLoss.Name = "cboDischargeLineLoss"
'      Me.cboDischargeLineLoss.Size = New System.Drawing.Size(72, 21)
'      Me.cboDischargeLineLoss.TabIndex = 9
'      Me.cboDischargeLineLoss.Text = "0"
'      '
'      'txtCondenserCapacity2
'      '
'      Me.txtCondenserCapacity2.Location = New System.Drawing.Point(362, 265)
'      Me.txtCondenserCapacity2.Name = "txtCondenserCapacity2"
'      Me.txtCondenserCapacity2.Size = New System.Drawing.Size(66, 21)
'      Me.txtCondenserCapacity2.TabIndex = 24
'      Me.txtCondenserCapacity2.Text = "0"
'      Me.txtCondenserCapacity2.Visible = False
'      '
'      'txtCondenserCapacity1
'      '
'      Me.txtCondenserCapacity1.Location = New System.Drawing.Point(122, 263)
'      Me.txtCondenserCapacity1.Name = "txtCondenserCapacity1"
'      Me.txtCondenserCapacity1.Size = New System.Drawing.Size(72, 21)
'      Me.txtCondenserCapacity1.TabIndex = 14
'      Me.txtCondenserCapacity1.Text = "0"
'      Me.txtCondenserCapacity1.Visible = False
'      '
'      'lblCondenserCapacity1
'      '
'      Me.lblCondenserCapacity1.Location = New System.Drawing.Point(8, 261)
'      Me.lblCondenserCapacity1.Name = "lblCondenserCapacity1"
'      Me.lblCondenserCapacity1.Size = New System.Drawing.Size(108, 53)
'      Me.lblCondenserCapacity1.TabIndex = 38
'      Me.lblCondenserCapacity1.Text = "WC Cond Cap @ 78 deg WB and 105 Cond Tmp (Per Cond):"
'      Me.lblCondenserCapacity1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      Me.lblCondenserCapacity1.Visible = False
'      '
'      'txtCondenserTD2
'      '
'      Me.txtCondenserTD2.Enabled = False
'      Me.txtCondenserTD2.Location = New System.Drawing.Point(357, 83)
'      Me.txtCondenserTD2.Name = "txtCondenserTD2"
'      Me.txtCondenserTD2.Size = New System.Drawing.Size(72, 21)
'      Me.txtCondenserTD2.TabIndex = 20
'      Me.txtCondenserTD2.Text = "10"
'      '
'      'lblCondenserTD2
'      '
'      Me.lblCondenserTD2.Location = New System.Drawing.Point(269, 83)
'      Me.lblCondenserTD2.Name = "lblCondenserTD2"
'      Me.lblCondenserTD2.Size = New System.Drawing.Size(80, 23)
'      Me.lblCondenserTD2.TabIndex = 24
'      Me.lblCondenserTD2.Text = "Condenser TD"
'      Me.lblCondenserTD2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'txtCondenserTD1
'      '
'      Me.txtCondenserTD1.Location = New System.Drawing.Point(117, 83)
'      Me.txtCondenserTD1.Name = "txtCondenserTD1"
'      Me.txtCondenserTD1.Size = New System.Drawing.Size(72, 21)
'      Me.txtCondenserTD1.TabIndex = 6
'      Me.txtCondenserTD1.Text = "10"
'      '
'      'lblCondenserTD1
'      '
'      Me.lblCondenserTD1.Location = New System.Drawing.Point(5, 83)
'      Me.lblCondenserTD1.Name = "lblCondenserTD1"
'      Me.lblCondenserTD1.Size = New System.Drawing.Size(104, 23)
'      Me.lblCondenserTD1.TabIndex = 22
'      Me.lblCondenserTD1.Text = "Condenser TD"
'      Me.lblCondenserTD1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'lblCondSubCoolingPercent2
'      '
'      Me.lblCondSubCoolingPercent2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
'      Me.lblCondSubCoolingPercent2.Location = New System.Drawing.Point(480, 116)
'      Me.lblCondSubCoolingPercent2.Name = "lblCondSubCoolingPercent2"
'      Me.lblCondSubCoolingPercent2.Size = New System.Drawing.Size(22, 23)
'      Me.lblCondSubCoolingPercent2.TabIndex = 21
'      Me.lblCondSubCoolingPercent2.Text = "%"
'      Me.lblCondSubCoolingPercent2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      Me.lblCondSubCoolingPercent2.Visible = False
'      '
'      'lblCondSubCoolingPercent1
'      '
'      Me.lblCondSubCoolingPercent1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
'      Me.lblCondSubCoolingPercent1.Location = New System.Drawing.Point(240, 116)
'      Me.lblCondSubCoolingPercent1.Name = "lblCondSubCoolingPercent1"
'      Me.lblCondSubCoolingPercent1.Size = New System.Drawing.Size(19, 23)
'      Me.lblCondSubCoolingPercent1.TabIndex = 20
'      Me.lblCondSubCoolingPercent1.Text = "%"
'      Me.lblCondSubCoolingPercent1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      Me.lblCondSubCoolingPercent1.Visible = False
'      '
'      'txtSubCooling2
'      '
'      Me.txtSubCooling2.Location = New System.Drawing.Point(428, 116)
'      Me.txtSubCooling2.Name = "txtSubCooling2"
'      Me.txtSubCooling2.Size = New System.Drawing.Size(48, 21)
'      Me.txtSubCooling2.TabIndex = 19
'      Me.txtSubCooling2.Visible = False
'      '
'      'txtSubCooling1
'      '
'      Me.txtSubCooling1.Location = New System.Drawing.Point(188, 116)
'      Me.txtSubCooling1.Name = "txtSubCooling1"
'      Me.txtSubCooling1.Size = New System.Drawing.Size(48, 21)
'      Me.txtSubCooling1.TabIndex = 5
'      Me.txtSubCooling1.Visible = False
'      '
'      'cboSubCooling2
'      '
'      Me.cboSubCooling2.Items.AddRange(New Object() {"Yes", "No"})
'      Me.cboSubCooling2.Location = New System.Drawing.Point(356, 116)
'      Me.cboSubCooling2.Name = "cboSubCooling2"
'      Me.cboSubCooling2.Size = New System.Drawing.Size(72, 21)
'      Me.cboSubCooling2.TabIndex = 18
'      Me.cboSubCooling2.Text = "Yes"
'      Me.cboSubCooling2.Visible = False
'      '
'      'lblSubCooling2
'      '
'      Me.lblSubCooling2.Location = New System.Drawing.Point(268, 116)
'      Me.lblSubCooling2.Name = "lblSubCooling2"
'      Me.lblSubCooling2.Size = New System.Drawing.Size(80, 23)
'      Me.lblSubCooling2.TabIndex = 16
'      Me.lblSubCooling2.Text = "Sub cooling"
'      Me.lblSubCooling2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      Me.lblSubCooling2.Visible = False
'      '
'      'cboSubCooling1
'      '
'      Me.cboSubCooling1.Items.AddRange(New Object() {"Yes", "No"})
'      Me.cboSubCooling1.Location = New System.Drawing.Point(116, 116)
'      Me.cboSubCooling1.Name = "cboSubCooling1"
'      Me.cboSubCooling1.Size = New System.Drawing.Size(72, 21)
'      Me.cboSubCooling1.TabIndex = 4
'      Me.cboSubCooling1.Text = "Yes"
'      Me.cboSubCooling1.Visible = False
'      '
'      'lblSubCooling1
'      '
'      Me.lblSubCooling1.Location = New System.Drawing.Point(4, 116)
'      Me.lblSubCooling1.Name = "lblSubCooling1"
'      Me.lblSubCooling1.Size = New System.Drawing.Size(104, 23)
'      Me.lblSubCooling1.TabIndex = 14
'      Me.lblSubCooling1.Text = "Sub cooling"
'      Me.lblSubCooling1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      Me.lblSubCooling1.Visible = False
'      '
'      'cboCondenser2
'      '
'      Me.cboCondenser2.Location = New System.Drawing.Point(356, 60)
'      Me.cboCondenser2.Name = "cboCondenser2"
'      Me.cboCondenser2.Size = New System.Drawing.Size(120, 21)
'      Me.cboCondenser2.TabIndex = 16
'      '
'      'lblCondenser2
'      '
'      Me.lblCondenser2.Location = New System.Drawing.Point(252, 58)
'      Me.lblCondenser2.Name = "lblCondenser2"
'      Me.lblCondenser2.Size = New System.Drawing.Size(96, 23)
'      Me.lblCondenser2.TabIndex = 8
'      Me.lblCondenser2.Text = "W.C. Condenser"
'      Me.lblCondenser2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'cboCondenser1
'      '
'      Me.cboCondenser1.Location = New System.Drawing.Point(116, 60)
'      Me.cboCondenser1.Name = "cboCondenser1"
'      Me.cboCondenser1.Size = New System.Drawing.Size(120, 21)
'      Me.cboCondenser1.TabIndex = 2
'      '
'      'lblCondenser1
'      '
'      Me.lblCondenser1.Location = New System.Drawing.Point(4, 60)
'      Me.lblCondenser1.Name = "lblCondenser1"
'      Me.lblCondenser1.Size = New System.Drawing.Size(104, 23)
'      Me.lblCondenser1.TabIndex = 6
'      Me.lblCondenser1.Text = "W.C. Condenser"
'      Me.lblCondenser1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'lblCircuit2
'      '
'      Me.lblCircuit2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.lblCircuit2.Location = New System.Drawing.Point(272, 4)
'      Me.lblCircuit2.Name = "lblCircuit2"
'      Me.lblCircuit2.Size = New System.Drawing.Size(216, 23)
'      Me.lblCircuit2.TabIndex = 1
'      Me.lblCircuit2.Text = "Circuit 2"
'      Me.lblCircuit2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'      '
'      'lblCircuit1
'      '
'      Me.lblCircuit1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.lblCircuit1.Location = New System.Drawing.Point(44, 4)
'      Me.lblCircuit1.Name = "lblCircuit1"
'      Me.lblCircuit1.Size = New System.Drawing.Size(192, 23)
'      Me.lblCircuit1.TabIndex = 0
'      Me.lblCircuit1.Text = "Circuit 1"
'      Me.lblCircuit1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'      '
'      'cboFan
'      '
'      Me.cboFan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
'      Me.cboFan.Location = New System.Drawing.Point(586, 155)
'      Me.cboFan.MaxDropDownItems = 11
'      Me.cboFan.Name = "cboFan"
'      Me.cboFan.Size = New System.Drawing.Size(67, 21)
'      Me.cboFan.TabIndex = 12
'      Me.cboFan.Visible = False
'      '
'      'txtCfmOverride
'      '
'      Me.txtCfmOverride.Location = New System.Drawing.Point(586, 182)
'      Me.txtCfmOverride.Name = "txtCfmOverride"
'      Me.txtCfmOverride.Size = New System.Drawing.Size(72, 21)
'      Me.txtCfmOverride.TabIndex = 12
'      Me.txtCfmOverride.Visible = False
'      '
'      'lblCFM
'      '
'      Me.lblCFM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
'      Me.lblCFM.Location = New System.Drawing.Point(549, 180)
'      Me.lblCFM.Name = "lblCFM"
'      Me.lblCFM.Size = New System.Drawing.Size(31, 23)
'      Me.lblCFM.TabIndex = 59
'      Me.lblCFM.Text = "CFM"
'      Me.lblCFM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      Me.lblCFM.Visible = False
'      '
'      'txtNumFans1
'      '
'      Me.txtNumFans1.Location = New System.Drawing.Point(586, 209)
'      Me.txtNumFans1.Name = "txtNumFans1"
'      Me.txtNumFans1.Size = New System.Drawing.Size(72, 21)
'      Me.txtNumFans1.TabIndex = 13
'      Me.txtNumFans1.Text = "1"
'      Me.txtNumFans1.Visible = False
'      '
'      'lblNumFans1
'      '
'      Me.lblNumFans1.Location = New System.Drawing.Point(476, 207)
'      Me.lblNumFans1.Name = "lblNumFans1"
'      Me.lblNumFans1.Size = New System.Drawing.Size(104, 23)
'      Me.lblNumFans1.TabIndex = 34
'      Me.lblNumFans1.Text = "Fan quantity"
'      Me.lblNumFans1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      Me.lblNumFans1.Visible = False
'      '
'      'txtNumFans2
'      '
'      Me.txtNumFans2.Location = New System.Drawing.Point(586, 236)
'      Me.txtNumFans2.Name = "txtNumFans2"
'      Me.txtNumFans2.Size = New System.Drawing.Size(72, 21)
'      Me.txtNumFans2.TabIndex = 23
'      Me.txtNumFans2.Text = "1"
'      Me.txtNumFans2.Visible = False
'      '
'      'lblNumFans2
'      '
'      Me.lblNumFans2.Location = New System.Drawing.Point(509, 236)
'      Me.lblNumFans2.Name = "lblNumFans2"
'      Me.lblNumFans2.Size = New System.Drawing.Size(69, 23)
'      Me.lblNumFans2.TabIndex = 35
'      Me.lblNumFans2.Text = "Fan quantity"
'      Me.lblNumFans2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      Me.lblNumFans2.Visible = False
'      '
'      'txtFanWatts
'      '
'      Me.txtFanWatts.Location = New System.Drawing.Point(586, 263)
'      Me.txtFanWatts.Name = "txtFanWatts"
'      Me.txtFanWatts.ReadOnly = True
'      Me.txtFanWatts.Size = New System.Drawing.Size(72, 21)
'      Me.txtFanWatts.TabIndex = 43
'      Me.txtFanWatts.TabStop = False
'      Me.txtFanWatts.Visible = False
'      '
'      'lblFanWatts
'      '
'      Me.lblFanWatts.Location = New System.Drawing.Point(478, 261)
'      Me.lblFanWatts.Name = "lblFanWatts"
'      Me.lblFanWatts.Size = New System.Drawing.Size(104, 23)
'      Me.lblFanWatts.TabIndex = 44
'      Me.lblFanWatts.Text = "Fan watts"
'      Me.lblFanWatts.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      Me.lblFanWatts.Visible = False
'      '
'      'panCondenserHeader
'      '
'      Me.panCondenserHeader.BackColor = System.Drawing.Color.White
'      Me.panCondenserHeader.Controls.Add(Me.lineCondenser)
'      Me.panCondenserHeader.Controls.Add(Me.btnCondenserPlus)
'      Me.panCondenserHeader.Controls.Add(Me.lblCondenser)
'      Me.panCondenserHeader.Dock = System.Windows.Forms.DockStyle.Top
'      Me.panCondenserHeader.Location = New System.Drawing.Point(0, 704)
'      Me.panCondenserHeader.Name = "panCondenserHeader"
'      Me.panCondenserHeader.Size = New System.Drawing.Size(671, 44)
'      Me.panCondenserHeader.TabIndex = 6
'      '
'      'lineCondenser
'      '
'      Me.lineCondenser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'      Me.lineCondenser.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
'      Me.lineCondenser.Location = New System.Drawing.Point(12, 40)
'      Me.lineCondenser.Name = "lineCondenser"
'      Me.lineCondenser.Size = New System.Drawing.Size(500, 2)
'      Me.lineCondenser.TabIndex = 7
'      Me.lineCondenser.Text = "Button3"
'      '
'      'btnCondenserPlus
'      '
'      Me.btnCondenserPlus.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
'      Me.btnCondenserPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'      Me.btnCondenserPlus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.btnCondenserPlus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
'      Me.btnCondenserPlus.Location = New System.Drawing.Point(16, 19)
'      Me.btnCondenserPlus.Name = "btnCondenserPlus"
'      Me.btnCondenserPlus.Size = New System.Drawing.Size(20, 18)
'      Me.btnCondenserPlus.TabIndex = 1
'      Me.btnCondenserPlus.Text = "-"
'      Me.btnCondenserPlus.UseVisualStyleBackColor = False
'      '
'      'lblCondenser
'      '
'      Me.lblCondenser.BackColor = System.Drawing.SystemColors.ActiveCaptionText
'      Me.lblCondenser.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.lblCondenser.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
'      Me.lblCondenser.Location = New System.Drawing.Point(44, 16)
'      Me.lblCondenser.Name = "lblCondenser"
'      Me.lblCondenser.Size = New System.Drawing.Size(452, 24)
'      Me.lblCondenser.TabIndex = 0
'      Me.lblCondenser.Text = "Condenser"
'      Me.lblCondenser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'panCompDataHide
'      '
'      Me.panCompDataHide.BackColor = System.Drawing.Color.White
'      Me.panCompDataHide.Controls.Add(Me.panCompressor)
'      Me.panCompDataHide.Dock = System.Windows.Forms.DockStyle.Top
'      Me.panCompDataHide.Location = New System.Drawing.Point(0, 500)
'      Me.panCompDataHide.Name = "panCompDataHide"
'      Me.panCompDataHide.Size = New System.Drawing.Size(671, 204)
'      Me.panCompDataHide.TabIndex = 5
'      '
'      'panCompressor
'      '
'      Me.panCompressor.BackColor = System.Drawing.Color.White
'      Me.panCompressor.Controls.Add(Me.cboSafetyOverride)
'      Me.panCompressor.Controls.Add(Me.lblNumCompressors2)
'      Me.panCompressor.Controls.Add(Me.lblCompressor2)
'      Me.panCompressor.Controls.Add(Me.txtNumCompressors2)
'      Me.panCompressor.Controls.Add(Me.txtCompressor2)
'      Me.panCompressor.Controls.Add(Me.lblNumCompressors1)
'      Me.panCompressor.Controls.Add(Me.txtNumCompressors1)
'      Me.panCompressor.Controls.Add(Me.txtCompressor1)
'      Me.panCompressor.Controls.Add(Me.lblCompressor1)
'      Me.panCompressor.Controls.Add(Me.lboCompressors2)
'      Me.panCompressor.Controls.Add(Me.lboCompressors1)
'      Me.panCompressor.Controls.Add(Me.panCirc)
'      Me.panCompressor.Location = New System.Drawing.Point(12, -1)
'      Me.panCompressor.Name = "panCompressor"
'      Me.panCompressor.Size = New System.Drawing.Size(504, 205)
'      Me.panCompressor.TabIndex = 8
'      '
'      'cboSafetyOverride
'      '
'      Me.cboSafetyOverride.FlatStyle = System.Windows.Forms.FlatStyle.System
'      Me.cboSafetyOverride.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.cboSafetyOverride.Location = New System.Drawing.Point(12, 4)
'      Me.cboSafetyOverride.Name = "cboSafetyOverride"
'      Me.cboSafetyOverride.Size = New System.Drawing.Size(118, 24)
'      Me.cboSafetyOverride.TabIndex = 1
'      Me.cboSafetyOverride.Text = "Safety override"
'      '
'      'lblNumCompressors2
'      '
'      Me.lblNumCompressors2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.lblNumCompressors2.Location = New System.Drawing.Point(272, 88)
'      Me.lblNumCompressors2.Name = "lblNumCompressors2"
'      Me.lblNumCompressors2.Size = New System.Drawing.Size(76, 23)
'      Me.lblNumCompressors2.TabIndex = 10
'      Me.lblNumCompressors2.Text = "Quantity"
'      Me.lblNumCompressors2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'lblCompressor2
'      '
'      Me.lblCompressor2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.lblCompressor2.Location = New System.Drawing.Point(272, 60)
'      Me.lblCompressor2.Name = "lblCompressor2"
'      Me.lblCompressor2.Size = New System.Drawing.Size(76, 23)
'      Me.lblCompressor2.TabIndex = 9
'      Me.lblCompressor2.Text = "Compressor"
'      Me.lblCompressor2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'txtNumCompressors2
'      '
'      Me.txtNumCompressors2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.txtNumCompressors2.Location = New System.Drawing.Point(356, 88)
'      Me.txtNumCompressors2.Name = "txtNumCompressors2"
'      Me.txtNumCompressors2.Size = New System.Drawing.Size(72, 21)
'      Me.txtNumCompressors2.TabIndex = 5
'      Me.txtNumCompressors2.Text = "1"
'      '
'      'txtCompressor2
'      '
'      Me.txtCompressor2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.txtCompressor2.Location = New System.Drawing.Point(356, 60)
'      Me.txtCompressor2.Name = "txtCompressor2"
'      Me.txtCompressor2.ReadOnly = True
'      Me.txtCompressor2.Size = New System.Drawing.Size(128, 21)
'      Me.txtCompressor2.TabIndex = 7
'      '
'      'lblNumCompressors1
'      '
'      Me.lblNumCompressors1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.lblNumCompressors1.Location = New System.Drawing.Point(12, 88)
'      Me.lblNumCompressors1.Name = "lblNumCompressors1"
'      Me.lblNumCompressors1.Size = New System.Drawing.Size(76, 23)
'      Me.lblNumCompressors1.TabIndex = 6
'      Me.lblNumCompressors1.Text = "Quantity"
'      Me.lblNumCompressors1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'txtNumCompressors1
'      '
'      Me.txtNumCompressors1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.txtNumCompressors1.Location = New System.Drawing.Point(96, 88)
'      Me.txtNumCompressors1.Name = "txtNumCompressors1"
'      Me.txtNumCompressors1.Size = New System.Drawing.Size(72, 21)
'      Me.txtNumCompressors1.TabIndex = 3
'      Me.txtNumCompressors1.Text = "1"
'      '
'      'txtCompressor1
'      '
'      Me.txtCompressor1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.txtCompressor1.Location = New System.Drawing.Point(96, 60)
'      Me.txtCompressor1.Name = "txtCompressor1"
'      Me.txtCompressor1.ReadOnly = True
'      Me.txtCompressor1.Size = New System.Drawing.Size(128, 21)
'      Me.txtCompressor1.TabIndex = 3
'      Me.txtCompressor1.TabStop = False
'      '
'      'lblCompressor1
'      '
'      Me.lblCompressor1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.lblCompressor1.Location = New System.Drawing.Point(12, 60)
'      Me.lblCompressor1.Name = "lblCompressor1"
'      Me.lblCompressor1.Size = New System.Drawing.Size(78, 23)
'      Me.lblCompressor1.TabIndex = 3
'      Me.lblCompressor1.Text = "Compressor"
'      Me.lblCompressor1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'lboCompressors2
'      '
'      Me.lboCompressors2.Enabled = False
'      Me.lboCompressors2.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.lboCompressors2.ItemHeight = 14
'      Me.lboCompressors2.Location = New System.Drawing.Point(288, 116)
'      Me.lboCompressors2.Name = "lboCompressors2"
'      Me.lboCompressors2.Size = New System.Drawing.Size(196, 88)
'      Me.lboCompressors2.TabIndex = 6
'      '
'      'lboCompressors1
'      '
'      Me.lboCompressors1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.lboCompressors1.ItemHeight = 14
'      Me.lboCompressors1.Location = New System.Drawing.Point(28, 116)
'      Me.lboCompressors1.Name = "lboCompressors1"
'      Me.lboCompressors1.Size = New System.Drawing.Size(196, 88)
'      Me.lboCompressors1.TabIndex = 4
'      Me.lboCompressors1.Tag = ""
'      '
'      'panCirc
'      '
'      Me.panCirc.Controls.Add(Me.radCircuit2)
'      Me.panCirc.Controls.Add(Me.radCircuit1)
'      Me.panCirc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.panCirc.Location = New System.Drawing.Point(4, 26)
'      Me.panCirc.Name = "panCirc"
'      Me.panCirc.Size = New System.Drawing.Size(490, 30)
'      Me.panCirc.TabIndex = 2
'      '
'      'radCircuit2
'      '
'      Me.radCircuit2.FlatStyle = System.Windows.Forms.FlatStyle.System
'      Me.radCircuit2.Location = New System.Drawing.Point(264, 4)
'      Me.radCircuit2.Name = "radCircuit2"
'      Me.radCircuit2.Size = New System.Drawing.Size(190, 24)
'      Me.radCircuit2.TabIndex = 2
'      Me.radCircuit2.Text = "Circuit 2"
'      '
'      'radCircuit1
'      '
'      Me.radCircuit1.Checked = True
'      Me.radCircuit1.FlatStyle = System.Windows.Forms.FlatStyle.System
'      Me.radCircuit1.Location = New System.Drawing.Point(8, 4)
'      Me.radCircuit1.Name = "radCircuit1"
'      Me.radCircuit1.Size = New System.Drawing.Size(201, 24)
'      Me.radCircuit1.TabIndex = 1
'      Me.radCircuit1.TabStop = True
'      Me.radCircuit1.Text = "Circuit 1"
'      '
'      'panCompressorHeader
'      '
'      Me.panCompressorHeader.BackColor = System.Drawing.Color.White
'      Me.panCompressorHeader.Controls.Add(Me.lineCompressor)
'      Me.panCompressorHeader.Controls.Add(Me.btnCompressorPlus)
'      Me.panCompressorHeader.Controls.Add(Me.lblCompressor)
'      Me.panCompressorHeader.Dock = System.Windows.Forms.DockStyle.Top
'      Me.panCompressorHeader.Location = New System.Drawing.Point(0, 456)
'      Me.panCompressorHeader.Name = "panCompressorHeader"
'      Me.panCompressorHeader.Size = New System.Drawing.Size(671, 44)
'      Me.panCompressorHeader.TabIndex = 4
'      '
'      'lineCompressor
'      '
'      Me.lineCompressor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'      Me.lineCompressor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
'      Me.lineCompressor.Location = New System.Drawing.Point(12, 40)
'      Me.lineCompressor.Name = "lineCompressor"
'      Me.lineCompressor.Size = New System.Drawing.Size(500, 2)
'      Me.lineCompressor.TabIndex = 10
'      Me.lineCompressor.Text = "Button2"
'      '
'      'btnCompressorPlus
'      '
'      Me.btnCompressorPlus.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
'      Me.btnCompressorPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'      Me.btnCompressorPlus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.btnCompressorPlus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
'      Me.btnCompressorPlus.Location = New System.Drawing.Point(16, 19)
'      Me.btnCompressorPlus.Name = "btnCompressorPlus"
'      Me.btnCompressorPlus.Size = New System.Drawing.Size(20, 18)
'      Me.btnCompressorPlus.TabIndex = 5
'      Me.btnCompressorPlus.Text = "-"
'      Me.btnCompressorPlus.UseVisualStyleBackColor = False
'      '
'      'lblCompressor
'      '
'      Me.lblCompressor.BackColor = System.Drawing.Color.White
'      Me.lblCompressor.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.lblCompressor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
'      Me.lblCompressor.Location = New System.Drawing.Point(44, 16)
'      Me.lblCompressor.Name = "lblCompressor"
'      Me.lblCompressor.Size = New System.Drawing.Size(416, 24)
'      Me.lblCompressor.TabIndex = 9
'      Me.lblCompressor.Text = "Compressor"
'      Me.lblCompressor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'panRatiCritHide
'      '
'      Me.panRatiCritHide.BackColor = System.Drawing.Color.White
'      Me.panRatiCritHide.Controls.Add(Me.cboVolts)
'      Me.panRatiCritHide.Controls.Add(Me.panRatingCriteria)
'      Me.panRatiCritHide.Dock = System.Windows.Forms.DockStyle.Top
'      Me.panRatiCritHide.Location = New System.Drawing.Point(0, 256)
'      Me.panRatiCritHide.Name = "panRatiCritHide"
'      Me.panRatiCritHide.Size = New System.Drawing.Size(671, 200)
'      Me.panRatiCritHide.TabIndex = 3
'      '
'      'cboVolts
'      '
'      Me.cboVolts.Items.AddRange(New Object() {"230", "460"})
'      Me.cboVolts.Location = New System.Drawing.Point(536, 12)
'      Me.cboVolts.Name = "cboVolts"
'      Me.cboVolts.Size = New System.Drawing.Size(59, 21)
'      Me.cboVolts.TabIndex = 10
'      Me.cboVolts.Text = "230"
'      Me.cboVolts.Visible = False
'      '
'      'panRatingCriteria
'      '
'      Me.panRatingCriteria.BackColor = System.Drawing.Color.White
'      Me.panRatingCriteria.Controls.Add(Me.lblRangeF)
'      Me.panRatingCriteria.Controls.Add(Me.lblAmbientF)
'      Me.panRatingCriteria.Controls.Add(Me.lblLeavingFluidF)
'      Me.panRatingCriteria.Controls.Add(Me.lblSubCoolingF)
'      Me.panRatingCriteria.Controls.Add(Me.lblFreezePointF)
'      Me.panRatingCriteria.Controls.Add(Me.lblMinSuctionF)
'      Me.panRatingCriteria.Controls.Add(Me.lblRatiVolt)
'      Me.panRatingCriteria.Controls.Add(Me.btnGlycolChart)
'      Me.panRatingCriteria.Controls.Add(Me.txtApproach)
'      Me.panRatingCriteria.Controls.Add(Me.lblApproach)
'      Me.panRatingCriteria.Controls.Add(Me.lblRatiVolt1)
'      Me.panRatingCriteria.Controls.Add(Me.cboHertz)
'      Me.panRatingCriteria.Controls.Add(Me.lblHertz)
'      Me.panRatingCriteria.Controls.Add(Me.cboSystem)
'      Me.panRatingCriteria.Controls.Add(Me.lblSystem)
'      Me.panRatingCriteria.Controls.Add(Me.txtFreezingPoint)
'      Me.panRatingCriteria.Controls.Add(Me.lblFreezingPoint)
'      Me.panRatingCriteria.Controls.Add(Me.lblSpecificGravity)
'      Me.panRatingCriteria.Controls.Add(Me.lblSpecificHeat)
'      Me.panRatingCriteria.Controls.Add(Me.txtSpecificGravity)
'      Me.panRatingCriteria.Controls.Add(Me.txtSpecificHeat)
'      Me.panRatingCriteria.Controls.Add(Me.txtGlycolPercentage)
'      Me.panRatingCriteria.Controls.Add(Me.lblGlycolPercentage)
'      Me.panRatingCriteria.Controls.Add(Me.cboFluid)
'      Me.panRatingCriteria.Controls.Add(Me.lblFluid)
'      Me.panRatingCriteria.Controls.Add(Me.cboCoolingMedia)
'      Me.panRatingCriteria.Controls.Add(Me.lblCoolingMedia)
'      Me.panRatingCriteria.Controls.Add(Me.txtSuctionTemp)
'      Me.panRatingCriteria.Controls.Add(Me.lblMinSuctionTemp)
'      Me.panRatingCriteria.Controls.Add(Me.txtSubCooling)
'      Me.panRatingCriteria.Controls.Add(Me.lblSubCooling)
'      Me.panRatingCriteria.Controls.Add(Me.txtLeavingFluidTemp)
'      Me.panRatingCriteria.Controls.Add(Me.lblLeavingFluidTemp)
'      Me.panRatingCriteria.Controls.Add(Me.lblAmbientTemp)
'      Me.panRatingCriteria.Controls.Add(Me.txtAmbientTemp)
'      Me.panRatingCriteria.Controls.Add(Me.lblTempRange)
'      Me.panRatingCriteria.Controls.Add(Me.txtTempRange)
'      Me.panRatingCriteria.Controls.Add(Me.lblRefrigerant)
'      Me.panRatingCriteria.Controls.Add(Me.cboRefrigerant)
'      Me.panRatingCriteria.Location = New System.Drawing.Point(12, -1)
'      Me.panRatingCriteria.Name = "panRatingCriteria"
'      Me.panRatingCriteria.Size = New System.Drawing.Size(516, 201)
'      Me.panRatingCriteria.TabIndex = 1
'      '
'      'lblRangeF
'      '
'      Me.lblRangeF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
'      Me.lblRangeF.Location = New System.Drawing.Point(444, 36)
'      Me.lblRangeF.Name = "lblRangeF"
'      Me.lblRangeF.Size = New System.Drawing.Size(64, 21)
'      Me.lblRangeF.TabIndex = 40
'      Me.lblRangeF.Text = "5 to 20°F"
'      Me.lblRangeF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'lblAmbientF
'      '
'      Me.lblAmbientF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
'      Me.lblAmbientF.Location = New System.Drawing.Point(444, 64)
'      Me.lblAmbientF.Name = "lblAmbientF"
'      Me.lblAmbientF.Size = New System.Drawing.Size(28, 21)
'      Me.lblAmbientF.TabIndex = 39
'      Me.lblAmbientF.Text = "°F"
'      Me.lblAmbientF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      Me.lblAmbientF.Visible = False
'      '
'      'lblLeavingFluidF
'      '
'      Me.lblLeavingFluidF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
'      Me.lblLeavingFluidF.Location = New System.Drawing.Point(444, 92)
'      Me.lblLeavingFluidF.Name = "lblLeavingFluidF"
'      Me.lblLeavingFluidF.Size = New System.Drawing.Size(64, 21)
'      Me.lblLeavingFluidF.TabIndex = 38
'      Me.lblLeavingFluidF.Text = "-40 to 75°F"
'      Me.lblLeavingFluidF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'lblSubCoolingF
'      '
'      Me.lblSubCoolingF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
'      Me.lblSubCoolingF.Location = New System.Drawing.Point(180, 176)
'      Me.lblSubCoolingF.Name = "lblSubCoolingF"
'      Me.lblSubCoolingF.Size = New System.Drawing.Size(28, 21)
'      Me.lblSubCoolingF.TabIndex = 37
'      Me.lblSubCoolingF.Text = "°F"
'      Me.lblSubCoolingF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'lblFreezePointF
'      '
'      Me.lblFreezePointF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
'      Me.lblFreezePointF.Location = New System.Drawing.Point(180, 120)
'      Me.lblFreezePointF.Name = "lblFreezePointF"
'      Me.lblFreezePointF.Size = New System.Drawing.Size(28, 21)
'      Me.lblFreezePointF.TabIndex = 36
'      Me.lblFreezePointF.Text = "°F"
'      Me.lblFreezePointF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'lblMinSuctionF
'      '
'      Me.lblMinSuctionF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
'      Me.lblMinSuctionF.Location = New System.Drawing.Point(180, 148)
'      Me.lblMinSuctionF.Name = "lblMinSuctionF"
'      Me.lblMinSuctionF.Size = New System.Drawing.Size(28, 21)
'      Me.lblMinSuctionF.TabIndex = 35
'      Me.lblMinSuctionF.Text = "°F"
'      Me.lblMinSuctionF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'lblRatiVolt
'      '
'      Me.lblRatiVolt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
'      Me.lblRatiVolt.Location = New System.Drawing.Point(444, 140)
'      Me.lblRatiVolt.Name = "lblRatiVolt"
'      Me.lblRatiVolt.Size = New System.Drawing.Size(53, 21)
'      Me.lblRatiVolt.TabIndex = 29
'      Me.lblRatiVolt.Text = "380 Volts"
'      Me.lblRatiVolt.TextAlign = System.Drawing.ContentAlignment.BottomLeft
'      Me.lblRatiVolt.Visible = False
'      '
'      'btnGlycolChart
'      '
'      Me.btnGlycolChart.BackColor = System.Drawing.SystemColors.Control
'      Me.btnGlycolChart.FlatStyle = System.Windows.Forms.FlatStyle.System
'      Me.btnGlycolChart.Location = New System.Drawing.Point(180, 35)
'      Me.btnGlycolChart.Name = "btnGlycolChart"
'      Me.btnGlycolChart.Size = New System.Drawing.Size(74, 23)
'      Me.btnGlycolChart.TabIndex = 4
'      Me.btnGlycolChart.Text = "Glycol Chart"
'      Me.btnGlycolChart.UseVisualStyleBackColor = False
'      Me.btnGlycolChart.Visible = False
'      '
'      'txtApproach
'      '
'      Me.txtApproach.Location = New System.Drawing.Point(368, 176)
'      Me.txtApproach.Name = "txtApproach"
'      Me.txtApproach.ReadOnly = True
'      Me.txtApproach.Size = New System.Drawing.Size(70, 21)
'      Me.txtApproach.TabIndex = 32
'      Me.txtApproach.TabStop = False
'      Me.txtApproach.Visible = False
'      '
'      'lblApproach
'      '
'      Me.lblApproach.Location = New System.Drawing.Point(280, 176)
'      Me.lblApproach.Name = "lblApproach"
'      Me.lblApproach.Size = New System.Drawing.Size(80, 21)
'      Me.lblApproach.TabIndex = 31
'      Me.lblApproach.Text = "Approach"
'      Me.lblApproach.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      Me.lblApproach.Visible = False
'      '
'      'lblRatiVolt1
'      '
'      Me.lblRatiVolt1.ForeColor = System.Drawing.Color.SteelBlue
'      Me.lblRatiVolt1.Location = New System.Drawing.Point(444, 160)
'      Me.lblRatiVolt1.Name = "lblRatiVolt1"
'      Me.lblRatiVolt1.Size = New System.Drawing.Size(36, 21)
'      Me.lblRatiVolt1.TabIndex = 30
'      Me.lblRatiVolt1.Text = "only"
'      Me.lblRatiVolt1.Visible = False
'      '
'      'cboHertz
'      '
'      Me.cboHertz.Items.AddRange(New Object() {"60", "50"})
'      Me.cboHertz.Location = New System.Drawing.Point(368, 148)
'      Me.cboHertz.Name = "cboHertz"
'      Me.cboHertz.Size = New System.Drawing.Size(72, 21)
'      Me.cboHertz.TabIndex = 12
'      Me.cboHertz.Text = "60"
'      Me.cboHertz.Visible = False
'      '
'      'lblHertz
'      '
'      Me.lblHertz.Location = New System.Drawing.Point(280, 148)
'      Me.lblHertz.Name = "lblHertz"
'      Me.lblHertz.Size = New System.Drawing.Size(80, 21)
'      Me.lblHertz.TabIndex = 27
'      Me.lblHertz.Text = "Hertz"
'      Me.lblHertz.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      Me.lblHertz.Visible = False
'      '
'      'cboSystem
'      '
'      Me.cboSystem.Items.AddRange(New Object() {"FULL", "HALF"})
'      Me.cboSystem.Location = New System.Drawing.Point(368, 120)
'      Me.cboSystem.Name = "cboSystem"
'      Me.cboSystem.Size = New System.Drawing.Size(72, 21)
'      Me.cboSystem.TabIndex = 11
'      Me.cboSystem.Text = "FULL"
'      Me.cboSystem.Visible = False
'      '
'      'lblSystem
'      '
'      Me.lblSystem.Location = New System.Drawing.Point(280, 120)
'      Me.lblSystem.Name = "lblSystem"
'      Me.lblSystem.Size = New System.Drawing.Size(80, 21)
'      Me.lblSystem.TabIndex = 25
'      Me.lblSystem.Text = "System"
'      Me.lblSystem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      Me.lblSystem.Visible = False
'      '
'      'txtFreezingPoint
'      '
'      Me.txtFreezingPoint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.txtFreezingPoint.Location = New System.Drawing.Point(104, 120)
'      Me.txtFreezingPoint.Name = "txtFreezingPoint"
'      Me.txtFreezingPoint.ReadOnly = True
'      Me.txtFreezingPoint.Size = New System.Drawing.Size(72, 21)
'      Me.txtFreezingPoint.TabIndex = 23
'      Me.txtFreezingPoint.TabStop = False
'      Me.txtFreezingPoint.Text = "32"
'      '
'      'lblFreezingPoint
'      '
'      Me.lblFreezingPoint.Location = New System.Drawing.Point(4, 120)
'      Me.lblFreezingPoint.Name = "lblFreezingPoint"
'      Me.lblFreezingPoint.Size = New System.Drawing.Size(92, 21)
'      Me.lblFreezingPoint.TabIndex = 22
'      Me.lblFreezingPoint.Text = "Freeze point"
'      Me.lblFreezingPoint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'lblSpecificGravity
'      '
'      Me.lblSpecificGravity.Location = New System.Drawing.Point(4, 92)
'      Me.lblSpecificGravity.Name = "lblSpecificGravity"
'      Me.lblSpecificGravity.Size = New System.Drawing.Size(92, 21)
'      Me.lblSpecificGravity.TabIndex = 21
'      Me.lblSpecificGravity.Text = "Specific gravity"
'      Me.lblSpecificGravity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'lblSpecificHeat
'      '
'      Me.lblSpecificHeat.Location = New System.Drawing.Point(4, 64)
'      Me.lblSpecificHeat.Name = "lblSpecificHeat"
'      Me.lblSpecificHeat.Size = New System.Drawing.Size(92, 21)
'      Me.lblSpecificHeat.TabIndex = 20
'      Me.lblSpecificHeat.Text = "Specific heat"
'      Me.lblSpecificHeat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'txtSpecificGravity
'      '
'      Me.txtSpecificGravity.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.txtSpecificGravity.Location = New System.Drawing.Point(104, 92)
'      Me.txtSpecificGravity.Name = "txtSpecificGravity"
'      Me.txtSpecificGravity.Size = New System.Drawing.Size(72, 21)
'      Me.txtSpecificGravity.TabIndex = 6
'      Me.txtSpecificGravity.Text = "0"
'      '
'      'txtSpecificHeat
'      '
'      Me.txtSpecificHeat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.txtSpecificHeat.Location = New System.Drawing.Point(104, 64)
'      Me.txtSpecificHeat.Name = "txtSpecificHeat"
'      Me.txtSpecificHeat.Size = New System.Drawing.Size(72, 21)
'      Me.txtSpecificHeat.TabIndex = 5
'      Me.txtSpecificHeat.Text = "0"
'      '
'      'txtGlycolPercentage
'      '
'      Me.txtGlycolPercentage.Enabled = False
'      Me.txtGlycolPercentage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.txtGlycolPercentage.Location = New System.Drawing.Point(180, 8)
'      Me.txtGlycolPercentage.Name = "txtGlycolPercentage"
'      Me.txtGlycolPercentage.Size = New System.Drawing.Size(36, 21)
'      Me.txtGlycolPercentage.TabIndex = 2
'      Me.txtGlycolPercentage.Text = "0"
'      Me.ToolTip1.SetToolTip(Me.txtGlycolPercentage, "Range 0-60")
'      '
'      'lblGlycolPercentage
'      '
'      Me.lblGlycolPercentage.Location = New System.Drawing.Point(220, 8)
'      Me.lblGlycolPercentage.Name = "lblGlycolPercentage"
'      Me.lblGlycolPercentage.Size = New System.Drawing.Size(52, 21)
'      Me.lblGlycolPercentage.TabIndex = 16
'      Me.lblGlycolPercentage.Text = "% Glycol"
'      Me.lblGlycolPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'cboFluid
'      '
'      Me.cboFluid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.cboFluid.Items.AddRange(New Object() {"Water", "Glycol"})
'      Me.cboFluid.Location = New System.Drawing.Point(104, 8)
'      Me.cboFluid.Name = "cboFluid"
'      Me.cboFluid.Size = New System.Drawing.Size(72, 21)
'      Me.cboFluid.TabIndex = 1
'      Me.cboFluid.Text = "Water"
'      '
'      'lblFluid
'      '
'      Me.lblFluid.Location = New System.Drawing.Point(4, 8)
'      Me.lblFluid.Name = "lblFluid"
'      Me.lblFluid.Size = New System.Drawing.Size(92, 21)
'      Me.lblFluid.TabIndex = 14
'      Me.lblFluid.Text = "Fluid"
'      Me.lblFluid.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'cboCoolingMedia
'      '
'      Me.cboCoolingMedia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.cboCoolingMedia.Items.AddRange(New Object() {"Ethylene", "Propylene"})
'      Me.cboCoolingMedia.Location = New System.Drawing.Point(104, 36)
'      Me.cboCoolingMedia.Name = "cboCoolingMedia"
'      Me.cboCoolingMedia.Size = New System.Drawing.Size(72, 21)
'      Me.cboCoolingMedia.TabIndex = 3
'      Me.cboCoolingMedia.Text = "Ethylene"
'      '
'      'lblCoolingMedia
'      '
'      Me.lblCoolingMedia.Location = New System.Drawing.Point(4, 36)
'      Me.lblCoolingMedia.Name = "lblCoolingMedia"
'      Me.lblCoolingMedia.Size = New System.Drawing.Size(92, 21)
'      Me.lblCoolingMedia.TabIndex = 12
'      Me.lblCoolingMedia.Text = "Cooling media"
'      Me.lblCoolingMedia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      Me.lblCoolingMedia.Visible = False
'      '
'      'txtSuctionTemp
'      '
'      Me.txtSuctionTemp.Location = New System.Drawing.Point(104, 148)
'      Me.txtSuctionTemp.Name = "txtSuctionTemp"
'      Me.txtSuctionTemp.ReadOnly = True
'      Me.txtSuctionTemp.Size = New System.Drawing.Size(72, 21)
'      Me.txtSuctionTemp.TabIndex = 11
'      Me.txtSuctionTemp.TabStop = False
'      Me.txtSuctionTemp.Text = "33"
'      '
'      'lblMinSuctionTemp
'      '
'      Me.lblMinSuctionTemp.Location = New System.Drawing.Point(4, 148)
'      Me.lblMinSuctionTemp.Name = "lblMinSuctionTemp"
'      Me.lblMinSuctionTemp.Size = New System.Drawing.Size(92, 21)
'      Me.lblMinSuctionTemp.TabIndex = 10
'      Me.lblMinSuctionTemp.Text = "Minimum suction"
'      Me.lblMinSuctionTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'txtSubCooling
'      '
'      Me.txtSubCooling.Location = New System.Drawing.Point(104, 176)
'      Me.txtSubCooling.Name = "txtSubCooling"
'      Me.txtSubCooling.Size = New System.Drawing.Size(72, 21)
'      Me.txtSubCooling.TabIndex = 9
'      Me.txtSubCooling.TabStop = False
'      Me.txtSubCooling.Text = "5"
'      '
'      'lblSubCooling
'      '
'      Me.lblSubCooling.Location = New System.Drawing.Point(16, 176)
'      Me.lblSubCooling.Name = "lblSubCooling"
'      Me.lblSubCooling.Size = New System.Drawing.Size(80, 21)
'      Me.lblSubCooling.TabIndex = 8
'      Me.lblSubCooling.Text = "Sub cooling"
'      Me.lblSubCooling.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'txtLeavingFluidTemp
'      '
'      Me.txtLeavingFluidTemp.Location = New System.Drawing.Point(368, 92)
'      Me.txtLeavingFluidTemp.Name = "txtLeavingFluidTemp"
'      Me.txtLeavingFluidTemp.Size = New System.Drawing.Size(72, 21)
'      Me.txtLeavingFluidTemp.TabIndex = 10
'      Me.txtLeavingFluidTemp.Text = "44"
'      Me.ToolTip1.SetToolTip(Me.txtLeavingFluidTemp, "Leaving fluid temperature, range -40°F to 75°F")
'      '
'      'lblLeavingFluidTemp
'      '
'      Me.lblLeavingFluidTemp.Location = New System.Drawing.Point(280, 92)
'      Me.lblLeavingFluidTemp.Name = "lblLeavingFluidTemp"
'      Me.lblLeavingFluidTemp.Size = New System.Drawing.Size(80, 28)
'      Me.lblLeavingFluidTemp.TabIndex = 6
'      Me.lblLeavingFluidTemp.Text = "Leaving Fluid Temp"
'      Me.lblLeavingFluidTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'lblAmbientTemp
'      '
'      Me.lblAmbientTemp.Location = New System.Drawing.Point(280, 64)
'      Me.lblAmbientTemp.Name = "lblAmbientTemp"
'      Me.lblAmbientTemp.Size = New System.Drawing.Size(80, 21)
'      Me.lblAmbientTemp.TabIndex = 5
'      Me.lblAmbientTemp.Text = "Ambient"
'      Me.lblAmbientTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      Me.lblAmbientTemp.Visible = False
'      '
'      'txtAmbientTemp
'      '
'      Me.txtAmbientTemp.Location = New System.Drawing.Point(368, 64)
'      Me.txtAmbientTemp.Name = "txtAmbientTemp"
'      Me.txtAmbientTemp.Size = New System.Drawing.Size(72, 21)
'      Me.txtAmbientTemp.TabIndex = 9
'      Me.txtAmbientTemp.Text = "75"
'      Me.txtAmbientTemp.Visible = False
'      '
'      'lblTempRange
'      '
'      Me.lblTempRange.Location = New System.Drawing.Point(280, 36)
'      Me.lblTempRange.Name = "lblTempRange"
'      Me.lblTempRange.Size = New System.Drawing.Size(80, 21)
'      Me.lblTempRange.TabIndex = 3
'      Me.lblTempRange.Text = "Range"
'      Me.lblTempRange.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'txtTempRange
'      '
'      Me.txtTempRange.Location = New System.Drawing.Point(368, 36)
'      Me.txtTempRange.Name = "txtTempRange"
'      Me.txtTempRange.Size = New System.Drawing.Size(72, 21)
'      Me.txtTempRange.TabIndex = 8
'      Me.txtTempRange.Text = "10"
'      '
'      'lblRefrigerant
'      '
'      Me.lblRefrigerant.Location = New System.Drawing.Point(280, 8)
'      Me.lblRefrigerant.Name = "lblRefrigerant"
'      Me.lblRefrigerant.Size = New System.Drawing.Size(80, 21)
'      Me.lblRefrigerant.TabIndex = 1
'      Me.lblRefrigerant.Text = "Refrigerant"
'      Me.lblRefrigerant.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'cboRefrigerant
'      '
'      Me.cboRefrigerant.Location = New System.Drawing.Point(368, 8)
'      Me.cboRefrigerant.Name = "cboRefrigerant"
'      Me.cboRefrigerant.Size = New System.Drawing.Size(72, 21)
'      Me.cboRefrigerant.TabIndex = 7
'      '
'      'panRatingCriteriaHeader
'      '
'      Me.panRatingCriteriaHeader.BackColor = System.Drawing.Color.White
'      Me.panRatingCriteriaHeader.Controls.Add(Me.lineRatingCriteria)
'      Me.panRatingCriteriaHeader.Controls.Add(Me.btnCriteriaPlus)
'      Me.panRatingCriteriaHeader.Controls.Add(Me.lblRatingCriteria)
'      Me.panRatingCriteriaHeader.Dock = System.Windows.Forms.DockStyle.Top
'      Me.panRatingCriteriaHeader.Location = New System.Drawing.Point(0, 216)
'      Me.panRatingCriteriaHeader.Name = "panRatingCriteriaHeader"
'      Me.panRatingCriteriaHeader.Size = New System.Drawing.Size(671, 40)
'      Me.panRatingCriteriaHeader.TabIndex = 2
'      '
'      'lineRatingCriteria
'      '
'      Me.lineRatingCriteria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'      Me.lineRatingCriteria.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
'      Me.lineRatingCriteria.Location = New System.Drawing.Point(12, 36)
'      Me.lineRatingCriteria.Name = "lineRatingCriteria"
'      Me.lineRatingCriteria.Size = New System.Drawing.Size(500, 2)
'      Me.lineRatingCriteria.TabIndex = 6
'      Me.lineRatingCriteria.Text = "Button1"
'      '
'      'btnCriteriaPlus
'      '
'      Me.btnCriteriaPlus.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
'      Me.btnCriteriaPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'      Me.btnCriteriaPlus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.btnCriteriaPlus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
'      Me.btnCriteriaPlus.Location = New System.Drawing.Point(16, 15)
'      Me.btnCriteriaPlus.Name = "btnCriteriaPlus"
'      Me.btnCriteriaPlus.Size = New System.Drawing.Size(20, 18)
'      Me.btnCriteriaPlus.TabIndex = 5
'      Me.btnCriteriaPlus.Text = "-"
'      Me.btnCriteriaPlus.UseVisualStyleBackColor = False
'      '
'      'lblRatingCriteria
'      '
'      Me.lblRatingCriteria.BackColor = System.Drawing.SystemColors.ActiveCaptionText
'      Me.lblRatingCriteria.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.lblRatingCriteria.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
'      Me.lblRatingCriteria.Location = New System.Drawing.Point(44, 12)
'      Me.lblRatingCriteria.Name = "lblRatingCriteria"
'      Me.lblRatingCriteria.Size = New System.Drawing.Size(472, 24)
'      Me.lblRatingCriteria.TabIndex = 5
'      Me.lblRatingCriteria.Text = "Rating Criteria"
'      Me.lblRatingCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'panModel
'      '
'      Me.panModel.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(255, Byte), Integer))
'      Me.panModel.Controls.Add(Me.cboModels)
'      Me.panModel.Controls.Add(Me.cboSeries)
'      Me.panModel.Controls.Add(Me.lblSeries)
'      Me.panModel.Controls.Add(Me.txtModel)
'      Me.panModel.Controls.Add(Me.lblModel)
'      Me.panModel.Controls.Add(Me.MenuStrip1)
'      Me.panModel.Dock = System.Windows.Forms.DockStyle.Top
'      Me.panModel.Location = New System.Drawing.Point(0, 0)
'      Me.panModel.Name = "panModel"
'      Me.panModel.Size = New System.Drawing.Size(671, 64)
'      Me.panModel.TabIndex = 1
'      '
'      'chkNewCoefficients
'      '
'      Me.chkNewCoefficients.AutoSize = True
'      Me.chkNewCoefficients.Location = New System.Drawing.Point(48, 32)
'      Me.chkNewCoefficients.Name = "chkNewCoefficients"
'      Me.chkNewCoefficients.Size = New System.Drawing.Size(125, 17)
'      Me.chkNewCoefficients.TabIndex = 6
'      Me.chkNewCoefficients.Text = "Use new coefficients"
'      Me.chkNewCoefficients.UseVisualStyleBackColor = True
'      '
'      'cboModels
'      '
'      Me.cboModels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
'      Me.cboModels.Location = New System.Drawing.Point(76, 36)
'      Me.cboModels.Name = "cboModels"
'      Me.cboModels.Size = New System.Drawing.Size(112, 21)
'      Me.cboModels.TabIndex = 2
'      '
'      'cboSeries
'      '
'      Me.cboSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
'      Me.cboSeries.Items.AddRange(New Object() {"34W0"})
'      Me.cboSeries.Location = New System.Drawing.Point(76, 8)
'      Me.cboSeries.Name = "cboSeries"
'      Me.cboSeries.Size = New System.Drawing.Size(112, 21)
'      Me.cboSeries.TabIndex = 1
'      '
'      'lblSeries
'      '
'      Me.lblSeries.Location = New System.Drawing.Point(4, 8)
'      Me.lblSeries.Name = "lblSeries"
'      Me.lblSeries.Size = New System.Drawing.Size(64, 23)
'      Me.lblSeries.TabIndex = 5
'      Me.lblSeries.Text = "Series"
'      Me.lblSeries.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      '
'      'txtModel
'      '
'      Me.txtModel.Location = New System.Drawing.Point(192, 36)
'      Me.txtModel.Name = "txtModel"
'      Me.txtModel.Size = New System.Drawing.Size(120, 21)
'      Me.txtModel.TabIndex = 3
'      '
'      'MenuStrip1
'      '
'      Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileMenuItem})
'      Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
'      Me.MenuStrip1.Name = "MenuStrip1"
'      Me.MenuStrip1.Size = New System.Drawing.Size(671, 24)
'      Me.MenuStrip1.TabIndex = 7
'      Me.MenuStrip1.Text = "MenuStrip1"
'      Me.MenuStrip1.Visible = False
'      '
'      'fileMenuItem
'      '
'      Me.fileMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.saveMenuItem, Me.saveAsRevisionMenuItem, Me.saveAsMenuItem, Me.ToolStripSeparator2, Me.convertToEquipmentMenuItem, Me.ToolStripSeparator1, Me.printMenuItem})
'      Me.fileMenuItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Save
'      Me.fileMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly
'      Me.fileMenuItem.Name = "fileMenuItem"
'      Me.fileMenuItem.Size = New System.Drawing.Size(51, 20)
'      Me.fileMenuItem.Text = "File"
'      '
'      'ToolStripSeparator3
'      '
'      Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
'      Me.ToolStripSeparator3.Size = New System.Drawing.Size(199, 6)
'      '
'      'saveMenuItem
'      '
'      Me.saveMenuItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Save
'      Me.saveMenuItem.Name = "saveMenuItem"
'      Me.saveMenuItem.Size = New System.Drawing.Size(202, 22)
'      Me.saveMenuItem.Text = "Save"
'      '
'      'saveAsRevisionMenuItem
'      '
'      Me.saveAsRevisionMenuItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.SaveAsRevision
'      Me.saveAsRevisionMenuItem.Name = "saveAsRevisionMenuItem"
'      Me.saveAsRevisionMenuItem.Size = New System.Drawing.Size(202, 22)
'      Me.saveAsRevisionMenuItem.Text = "Save as Revision"
'      '
'      'saveAsMenuItem
'      '
'      Me.saveAsMenuItem.Name = "saveAsMenuItem"
'      Me.saveAsMenuItem.Size = New System.Drawing.Size(202, 22)
'      Me.saveAsMenuItem.Text = "Save as..."
'      '
'      'ToolStripSeparator2
'      '
'      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
'      Me.ToolStripSeparator2.Size = New System.Drawing.Size(199, 6)
'      '
'      'convertToEquipmentMenuItem
'      '
'      Me.convertToEquipmentMenuItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.ConvertToEquipment
'      Me.convertToEquipmentMenuItem.Name = "convertToEquipmentMenuItem"
'      Me.convertToEquipmentMenuItem.Size = New System.Drawing.Size(202, 22)
'      Me.convertToEquipmentMenuItem.Text = "Convert to Equipment..."
'      Me.convertToEquipmentMenuItem.Visible = False
'      '
'      'ToolStripSeparator1
'      '
'      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
'      Me.ToolStripSeparator1.Size = New System.Drawing.Size(199, 6)
'      Me.ToolStripSeparator1.Visible = False
'      '
'      'printMenuItem
'      '
'      Me.printMenuItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Print
'      Me.printMenuItem.Name = "printMenuItem"
'      Me.printMenuItem.Size = New System.Drawing.Size(202, 22)
'      Me.printMenuItem.Text = "Print..."
'      '
'      'btnCreateReport
'      '
'      Me.btnCreateReport.BackColor = System.Drawing.Color.White
'      Me.btnCreateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'      Me.btnCreateReport.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.btnCreateReport.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(150, Byte), Integer))
'      Me.btnCreateReport.Image = CType(resources.GetObject("btnCreateReport.Image"), System.Drawing.Image)
'      Me.btnCreateReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
'      Me.btnCreateReport.Location = New System.Drawing.Point(0, 4)
'      Me.btnCreateReport.Name = "btnCreateReport"
'      Me.btnCreateReport.Size = New System.Drawing.Size(164, 24)
'      Me.btnCreateReport.TabIndex = 2
'      Me.btnCreateReport.Text = "Create Report"
'      Me.btnCreateReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      Me.btnCreateReport.UseVisualStyleBackColor = False
'      '
'      'lblErro
'      '
'      Me.lblErro.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
'      Me.lblErro.Dock = System.Windows.Forms.DockStyle.Fill
'      Me.lblErro.ForeColor = System.Drawing.Color.Black
'      Me.lblErro.Location = New System.Drawing.Point(32, 0)
'      Me.lblErro.Name = "lblErro"
'      Me.lblErro.Size = New System.Drawing.Size(312, 32)
'      Me.lblErro.TabIndex = 5
'      Me.lblErro.Text = "If errors occur they will be shown here"
'      Me.lblErro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'ToolTip1
'      '
'      Me.ToolTip1.AutoPopDelay = 8000
'      Me.ToolTip1.InitialDelay = 500
'      Me.ToolTip1.ReshowDelay = 500
'      '
'      'panFooter
'      '
'      Me.panFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
'      Me.panFooter.Controls.Add(Me.lblErro)
'      Me.panFooter.Controls.Add(Me.panButtons)
'      Me.panFooter.Controls.Add(Me.picError)
'      Me.panFooter.Dock = System.Windows.Forms.DockStyle.Bottom
'      Me.panFooter.Location = New System.Drawing.Point(0, 521)
'      Me.panFooter.Name = "panFooter"
'      Me.panFooter.Size = New System.Drawing.Size(688, 32)
'      Me.panFooter.TabIndex = 4
'      '
'      'panButtons
'      '
'      Me.panButtons.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
'      Me.panButtons.Controls.Add(Me.btnCalculatePage)
'      Me.panButtons.Controls.Add(Me.btnCreateReport)
'      Me.panButtons.Dock = System.Windows.Forms.DockStyle.Right
'      Me.panButtons.Location = New System.Drawing.Point(344, 0)
'      Me.panButtons.Name = "panButtons"
'      Me.panButtons.Size = New System.Drawing.Size(344, 32)
'      Me.panButtons.TabIndex = 2
'      '
'      'btnCalculatePage
'      '
'      Me.btnCalculatePage.BackColor = System.Drawing.Color.White
'      Me.btnCalculatePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'      Me.btnCalculatePage.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.btnCalculatePage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(150, Byte), Integer))
'      Me.btnCalculatePage.Image = CType(resources.GetObject("btnCalculatePage.Image"), System.Drawing.Image)
'      Me.btnCalculatePage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
'      Me.btnCalculatePage.Location = New System.Drawing.Point(168, 4)
'      Me.btnCalculatePage.Name = "btnCalculatePage"
'      Me.btnCalculatePage.Size = New System.Drawing.Size(172, 24)
'      Me.btnCalculatePage.TabIndex = 1
'      Me.btnCalculatePage.Text = "Calculate Page "
'      Me.btnCalculatePage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'      Me.btnCalculatePage.UseVisualStyleBackColor = False
'      '
'      'picError
'      '
'      Me.picError.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
'      Me.picError.Dock = System.Windows.Forms.DockStyle.Left
'      Me.picError.Image = CType(resources.GetObject("picError.Image"), System.Drawing.Image)
'      Me.picError.Location = New System.Drawing.Point(0, 0)
'      Me.picError.Name = "picError"
'      Me.picError.Size = New System.Drawing.Size(32, 32)
'      Me.picError.TabIndex = 0
'      Me.picError.TabStop = False
'      '
'      'err
'      '
'      Me.err.ContainerControl = Me
'      Me.err.Icon = CType(resources.GetObject("err.Icon"), System.Drawing.Icon)
'      '
'      'controlFactorsPanel
'      '
'      Me.controlFactorsPanel.Controls.Add(Me.chkNewCoefficients)
'      Me.controlFactorsPanel.Controls.Add(Me.optionsHeaderLabel)
'      Me.controlFactorsPanel.Controls.Add(Me.condenserCapacityFactorTextBox)
'      Me.controlFactorsPanel.Controls.Add(Me.compressorAmpFactorTextBox)
'      Me.controlFactorsPanel.Controls.Add(Me.compressorKwFactorTextBox)
'      Me.controlFactorsPanel.Controls.Add(Me.compressorCapacityFactorTextBox)
'      Me.controlFactorsPanel.Controls.Add(Me.compressorAmpFactorLabel)
'      Me.controlFactorsPanel.Controls.Add(Me.compressorKwFactorLabel)
'      Me.controlFactorsPanel.Controls.Add(Me.compressorCapacityFactorLabel)
'      Me.controlFactorsPanel.Controls.Add(Me.condenserCapacityFactorLabel)
'      Me.controlFactorsPanel.Controls.Add(Me.Label1)
'      Me.controlFactorsPanel.Dock = System.Windows.Forms.DockStyle.Top
'      Me.controlFactorsPanel.Location = New System.Drawing.Point(0, 64)
'      Me.controlFactorsPanel.Name = "controlFactorsPanel"
'      Me.controlFactorsPanel.Size = New System.Drawing.Size(671, 152)
'      Me.controlFactorsPanel.TabIndex = 11
'      Me.controlFactorsPanel.Visible = False
'      '
'      'Label1
'      '
'      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
'      Me.Label1.Location = New System.Drawing.Point(46, 53)
'      Me.Label1.Name = "Label1"
'      Me.Label1.Size = New System.Drawing.Size(119, 21)
'      Me.Label1.TabIndex = 21
'      Me.Label1.Text = "Correction factors"
'      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'optionsHeaderLabel
'      '
'      Me.optionsHeaderLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText
'      Me.optionsHeaderLabel.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.optionsHeaderLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(210, Byte), Integer))
'      Me.optionsHeaderLabel.Location = New System.Drawing.Point(44, 3)
'      Me.optionsHeaderLabel.Name = "optionsHeaderLabel"
'      Me.optionsHeaderLabel.Size = New System.Drawing.Size(472, 24)
'      Me.optionsHeaderLabel.TabIndex = 20
'      Me.optionsHeaderLabel.Text = "Engineering Options"
'      Me.optionsHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'condenserCapacityFactorTextBox
'      '
'      Me.condenserCapacityFactorTextBox.Location = New System.Drawing.Point(399, 74)
'      Me.condenserCapacityFactorTextBox.Name = "condenserCapacityFactorTextBox"
'      Me.condenserCapacityFactorTextBox.Size = New System.Drawing.Size(37, 21)
'      Me.condenserCapacityFactorTextBox.TabIndex = 18
'      Me.condenserCapacityFactorTextBox.Text = "1"
'      '
'      'compressorAmpFactorTextBox
'      '
'      Me.compressorAmpFactorTextBox.Location = New System.Drawing.Point(162, 131)
'      Me.compressorAmpFactorTextBox.Name = "compressorAmpFactorTextBox"
'      Me.compressorAmpFactorTextBox.Size = New System.Drawing.Size(37, 21)
'      Me.compressorAmpFactorTextBox.TabIndex = 14
'      Me.compressorAmpFactorTextBox.Text = "1"
'      '
'      'compressorKwFactorTextBox
'      '
'      Me.compressorKwFactorTextBox.Location = New System.Drawing.Point(162, 104)
'      Me.compressorKwFactorTextBox.Name = "compressorKwFactorTextBox"
'      Me.compressorKwFactorTextBox.Size = New System.Drawing.Size(37, 21)
'      Me.compressorKwFactorTextBox.TabIndex = 12
'      Me.compressorKwFactorTextBox.Text = "1"
'      '
'      'compressorCapacityFactorTextBox
'      '
'      Me.compressorCapacityFactorTextBox.Location = New System.Drawing.Point(162, 77)
'      Me.compressorCapacityFactorTextBox.Name = "compressorCapacityFactorTextBox"
'      Me.compressorCapacityFactorTextBox.Size = New System.Drawing.Size(37, 21)
'      Me.compressorCapacityFactorTextBox.TabIndex = 10
'      Me.compressorCapacityFactorTextBox.Text = "1"
'      '
'      'compressorAmpFactorLabel
'      '
'      Me.compressorAmpFactorLabel.Location = New System.Drawing.Point(47, 131)
'      Me.compressorAmpFactorLabel.Name = "compressorAmpFactorLabel"
'      Me.compressorAmpFactorLabel.Size = New System.Drawing.Size(119, 21)
'      Me.compressorAmpFactorLabel.TabIndex = 17
'      Me.compressorAmpFactorLabel.Text = "Compressor amps"
'      Me.compressorAmpFactorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'compressorKwFactorLabel
'      '
'      Me.compressorKwFactorLabel.BackColor = System.Drawing.Color.Transparent
'      Me.compressorKwFactorLabel.Location = New System.Drawing.Point(47, 104)
'      Me.compressorKwFactorLabel.Name = "compressorKwFactorLabel"
'      Me.compressorKwFactorLabel.Size = New System.Drawing.Size(119, 21)
'      Me.compressorKwFactorLabel.TabIndex = 16
'      Me.compressorKwFactorLabel.Text = "Compressor KW"
'      Me.compressorKwFactorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'compressorCapacityFactorLabel
'      '
'      Me.compressorCapacityFactorLabel.BackColor = System.Drawing.Color.Transparent
'      Me.compressorCapacityFactorLabel.Location = New System.Drawing.Point(47, 77)
'      Me.compressorCapacityFactorLabel.Name = "compressorCapacityFactorLabel"
'      Me.compressorCapacityFactorLabel.Size = New System.Drawing.Size(119, 21)
'      Me.compressorCapacityFactorLabel.TabIndex = 15
'      Me.compressorCapacityFactorLabel.Text = "Compressor capacity"
'      Me.compressorCapacityFactorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'condenserCapacityFactorLabel
'      '
'      Me.condenserCapacityFactorLabel.Location = New System.Drawing.Point(284, 74)
'      Me.condenserCapacityFactorLabel.Name = "condenserCapacityFactorLabel"
'      Me.condenserCapacityFactorLabel.Size = New System.Drawing.Size(129, 21)
'      Me.condenserCapacityFactorLabel.TabIndex = 19
'      Me.condenserCapacityFactorLabel.Text = "Condenser capacity"
'      Me.condenserCapacityFactorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'      '
'      'ChillerWaterCooledForm
'      '
'      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
'      Me.BackColor = System.Drawing.Color.White
'      Me.ClientSize = New System.Drawing.Size(688, 553)
'      Me.Controls.Add(Me.panMain)
'      Me.Controls.Add(Me.panFooter)
'      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'      Me.MainMenuStrip = Me.MenuStrip1
'      Me.Name = "ChillerWaterCooledForm"
'      Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
'      Me.Text = "Technical Systems - Water Cooled Chiller"
'      Me.panMain.ResumeLayout(False)
'      Me.panGrid.ResumeLayout(False)
'      CType(Me.dgrC1Results, System.ComponentModel.ISupportInitialize).EndInit()
'      Me.panEvapHide.ResumeLayout(False)
'      Me.panEvapHide.PerformLayout()
'      Me.panEvaporator.ResumeLayout(False)
'      Me.panEvaporator.PerformLayout()
'      Me.panEvaporatorApproach.ResumeLayout(False)
'      Me.panEvaporatorApproach.PerformLayout()
'      Me.Panel1.ResumeLayout(False)
'      Me.panEvaporatorHeader.ResumeLayout(False)
'      Me.panCondHide.ResumeLayout(False)
'      Me.panCondHide.PerformLayout()
'      Me.panCondenser.ResumeLayout(False)
'      Me.panCondenser.PerformLayout()
'      Me.panCondenserHeader.ResumeLayout(False)
'      Me.panCompDataHide.ResumeLayout(False)
'      Me.panCompressor.ResumeLayout(False)
'      Me.panCompressor.PerformLayout()
'      Me.panCirc.ResumeLayout(False)
'      Me.panCompressorHeader.ResumeLayout(False)
'      Me.panRatiCritHide.ResumeLayout(False)
'      Me.panRatingCriteria.ResumeLayout(False)
'      Me.panRatingCriteria.PerformLayout()
'      Me.panRatingCriteriaHeader.ResumeLayout(False)
'      Me.panModel.ResumeLayout(False)
'      Me.panModel.PerformLayout()
'      Me.MenuStrip1.ResumeLayout(False)
'      Me.MenuStrip1.PerformLayout()
'      Me.panFooter.ResumeLayout(False)
'      Me.panButtons.ResumeLayout(False)
'      CType(Me.picError, System.ComponentModel.ISupportInitialize).EndInit()
'      CType(Me.err, System.ComponentModel.ISupportInitialize).EndInit()
'      Me.controlFactorsPanel.ResumeLayout(False)
'      Me.controlFactorsPanel.PerformLayout()
'      Me.ResumeLayout(False)

'   End Sub

'#End Region


'#Region "Old Variable Names"
'   'ASP.NET			vs				Windows names
'   '----------						----------------
'   'TextBox1					e	lblErro					Error Message
'   'txtUMN						e	cboModeNumb				UNIT COOLER COMBOBOX
'   'ListBox1						lbxCompDataCirc1		Model Number and Horsepower
'   'ListBox4						lbxCompDataCirc2		Model Number and Horsepower
'   'TxtPctgly						txtGlycolPercentage		Percent Glycol
'   'txt_Freez_point				txtFreezingPoint		Freeze Point Temperature
'   'txt_recommended_min_suct	txtSuctionTemp		Minimum Suction Temperature
'   'cboCCM							cboRatiCritMedi		Cooling Media (Ethylene..)
'   'txtUMN_CHANGE					tbxModeNumb				Unit Cooler Model Number
'   'cboSystem						cboSystem		System (Full, Half)
'   'cboRef							cboRefrigerant		Refrigerant
'   'TxtAmbient						txtAmbientTemp		Ambient Temperature
'   'TxtLFT							txtLeavingFluidTemp		Leaving Fluid Temperature
'   'Cbo_coil_file_name			cboCondCond1			DisplayMember: Condenser / ValueMember: Coil File Name
'   'CboFpi_1						cboCondFinsPerInch	Fins Per Inch
'   'CboRange					e	txtTempRange		Temperature Range
'   'Txtspht							txtSpecificHeat	Specific Heat
'   'Cbo_Fan_File_name			cboFan
'   'cbo_CSOR						cboSafetyOverride				Compressor Safety Override
'   'txtChiller						txtEvaporatorModel				Evaporator Model
'   'cboFluid						cboRatiCritFlui		Fluid: water, glycol
'   'cboChiller						cboEvaporatorModel				Evaporator Model
'#End Region


'#Region "Variables"
'   'Dim LastSavedProcess As WCChillerProcessItem
'   'Dim CurrentStateProcess As WCChillerProcessItem

'   Dim COILQTY_1 As Double
'   Dim ChillyRAEs_pass_no As Single

'   Dim my_Gly_Pro(12, 4) As Double
'   Dim ok_to_print_SPACE As Boolean
'   Dim ok_to_print As Boolean
'   Dim myarrayprint As New ArrayList    'circuit 1
'   Dim myarrayprint2 As New ArrayList   'circuit 2
'   Dim myarrayprint3 As New ArrayList       'circuit 1 holding
'   Dim Running_Circuit_no As Single


'   Dim ok_to_show As Boolean
'   Dim Hold_Set_PD(20) As Double

'   Dim BAD_FLUID_TYPE As Boolean        'TEST FOR BAD FLUID TYPE
'   Dim gRef As String               'Refrigerant type

'   Dim A As Double
'   Dim B As Double
'   Dim Q As Double
'   Dim gTemperatureRange As Double                  'RANGE IN DEG. F.
'   Dim T As Double
'   Dim W As Double



'   Dim gCondenserCapacity As Double                 'COND. CAP. @ 25 DEG TEMP. DIF.
'   Dim EZ As Double
'   Dim ER As Double
'   Dim GP As Double
'   Dim NT As Double 'Integer
'   Dim cond As Rae.RaeSolutions.Business.Entities.WCCondenser
'   Dim CC As Double
'   Dim H1 As Double
'   Dim H2 As Double
'   Dim KW As Double
'   Dim gSubCoolingTemp As Double                 'LIQUID COOLING(GLYCOL)
'   Dim M1 As Double
'   Dim gCompressorQuantity As Double                 'NUMBER OF COMPRESSOR CIRCUITS
'   Dim gNumberOfFans As Double                 'NUMBER OF FANS
'   Dim PC As Double
'   Dim PE As Double
'   Dim Q1 As Double
'   Dim Q8 As Double                 'CHILLER CAP. @ 8 DEG APPROACH
'   Dim Q9 As Double                 'CHILLER CAP. @ 10 DEG APPROACH
'   Dim gAmbientTempStep As Double
'   Dim TC As Double
'   Dim TE As Double
'   Dim TW As Double
'   Dim GPM As Double
'   Dim gTD As Double                'Condenser T. D.
'   Dim subCoolingFactor As Double                'GLYCOL
'   Dim TE1 As Double
'   Dim TE2 As Double
'   Dim TW1 As Double
'   Dim TW2 As Double
'   Dim gMF1 As Double               'MULTIPLY FACTOR FOR COMPRESSORS
'   Dim gMF2 As Double               'MULTIPLY FACTOR FOR COMPRESSORS
'   Dim gMF3 As Double               'MULTIPLY FACTOR FOR COMPRESSORS
'   Dim Temp As Double
'   Dim gCatalogRating As Double               'PRINT OUT CATALOG RATINGS?Y/N
'   Dim gVolts As Double             'VOLTAGE
'   'TODO: reduce scope
'   Dim GPMFACT As Double            'GLYCOL
'   Dim fanWatts, Hertz2, Hertz3, Hertz4, Hertz21 As Double

'   'TODO: make local variable to CalculatePage
'   'it's only used there

'   Dim PD_GPM(13, 2) As Double
'   Dim gOD As Boolean                   'TEST FOR OPEN DRIVE
'   Dim gHP_O As Boolean                 'TEST FOR HORSEPOWER(OTHER)
'   Dim gPrint As Boolean                'TEST FOR PRINT SELECTION
'   Dim gClosed As Boolean               'TEST FOR DATA100.CLOSE
'   Dim Exit_Select As Boolean           'TEST FOR EXITING START SELECTION PROCEDURE
'   Dim Exit_Glycol As Boolean           'TEST FOR EXITING GLYCOL PROCEDURE

'   Dim gMyFileNameMDB As String

'#End Region


'   Dim loaded As Boolean = False
'   Dim gReportFilename As String = "" 'file name for report
'   Dim PASS_FILENAME As String = ""
'   Dim logger As Rae.RaeSolutions.Diagnostics.UsageLog.FormUsageLogger
'   'Dim dt As New DataTable
'   'Dim dc As DataColumn
'   Dim cd As RaeSolutions.CRDAL


'#Region " Properties"

'   Private Property AmbientTemp() As Double
'      Get
'         Return ConvertNull.ToDouble(Me.txtCondTemp.Text) 'Return ConvertNull.ToDouble(Me.txtAmbientTemp.Text)
'      End Get
'      Set(ByVal Value As Double)
'         Me.txtCondTemp.Text = Value.ToString 'Me.txtAmbientTemp.Text = Value.ToString
'      End Set
'   End Property

'   Private Property LeavingFluidTemp() As Double
'      Get
'         Return ConvertNull.ToDouble(Me.txtLeavingFluidTemp.Text)
'      End Get
'      Set(ByVal Value As Double)
'         Me.txtLeavingFluidTemp.Text = Value.ToString
'      End Set
'   End Property

'   Private Property EvapTemp() As Double
'      Get
'         Return ConvertNull.ToDouble(Me.txtLeavingFluidTemp.Text) 'Return ConvertNull.ToDouble(Me.txtEvapTemp.Text)
'      End Get
'      Set(ByVal Value As Double)
'         Me.txtLeavingFluidTemp.Text = Value.ToString 'Me.txtEvapTemp.Text = Value.ToString
'      End Set
'   End Property

'   Private Property EnteringFluidTemp() As Double
'      Get
'         Return ConvertNull.ToDouble(Me.txtCondTemp.Text)
'      End Get
'      Set(ByVal Value As Double)
'         Me.txtCondTemp.Text = Value.ToString
'      End Set
'   End Property

'   Private Property Refrigerant() As Rae.Engineering.Refrigerant
'      Get
'         Return New Rae.Engineering.Refrigerant(System.Enum.Parse(Rae.Engineering.RefrigerantType.R134a.GetType(), cboRefrigerant.SelectedIndex))
'      End Get
'      Set(ByVal value As Rae.Engineering.Refrigerant)
'         cboRefrigerant.SelectedIndex = CInt(value.Type)
'      End Set
'   End Property

'#End Region


'#Region " Event Handlers"

'#Region " Form Event Handlers"

'   ''' <summary>Authorizes user before showing privledge controls and info
'   ''' </summary>
'   ''' <history on="2006/2/26" by="Casey">Extracted/Created
'   ''' </history>
'   Private Sub Authorize()
'      Select Case AppInfo.User.Username.ToUpper
'         Case "CASEYJ", "DANNYG", "SCOTTR", "JAYK", "JIMM", "FAISALB", "LYNND", "JOHNJ"
'            controlFactorsPanel.Visible = True
'         Case Else
'            controlFactorsPanel.Visible = False
'      End Select
'      If AppInfo.User.AuthorityGroup > 2 Then Me.SetControlAccess()
'   End Sub

'   Private Sub ChillerWaterCooledForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
'      If Not Me.ProcessDeleted Then
'         If SaveControls(False, False, True) = False Then
'            e.Cancel = True
'         Else
'            RemoveHandler CType(My.Application.ApplicationContext.MainForm, MainForm).RevisionView1.RevisionChanged, AddressOf RevisionView_RevisionChanged
'         End If
'      End If
'   End Sub

'   'on form load
'   Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

'      'cd = New RaeSolutions.CRDAL
'      'cd.CRDAL(True)


'      'dc = New DataColumn
'      'dc.ColumnName = "TW"
'      'dc.DataType = System.Type.GetType("System.Double")
'      'dt.Columns.Add(dc)

'      'dc = New DataColumn
'      'dc.ColumnName = "TA"
'      'dc.DataType = System.Type.GetType("System.Double")
'      'dt.Columns.Add(dc)

'      'dc = New DataColumn
'      'dc.ColumnName = "TE"
'      'dc.DataType = System.Type.GetType("System.Double")
'      'dt.Columns.Add(dc)

'      'dc = New DataColumn
'      'dc.ColumnName = "TC"
'      'dc.DataType = System.Type.GetType("System.Double")
'      'dt.Columns.Add(dc)

'      'dc = New DataColumn
'      'dc.ColumnName = "Q"
'      'dc.DataType = System.Type.GetType("System.Double")
'      'dt.Columns.Add(dc)

'      'dc = New DataColumn
'      'dc.ColumnName = "KW"
'      'dc.DataType = System.Type.GetType("System.Double")
'      'dt.Columns.Add(dc)

'      'dc = New DataColumn
'      'dc.ColumnName = "GP"
'      'dc.DataType = System.Type.GetType("System.Double")
'      'dt.Columns.Add(dc)

'      'dc = New DataColumn
'      'dc.ColumnName = "A"
'      'dc.DataType = System.Type.GetType("System.Double")
'      'dt.Columns.Add(dc)

'      'dc = New DataColumn
'      'dc.ColumnName = "ER"
'      'dc.DataType = System.Type.GetType("System.Double")
'      'dt.Columns.Add(dc)

'      'dc = New DataColumn
'      'dc.ColumnName = "EZ"
'      'dc.DataType = System.Type.GetType("System.Double")
'      'dt.Columns.Add(dc)

'      'logs form usage statistics
'      Me.LogFormStart()
'      'SIZE WINDOW TO THE HEIGHT OF THE MAIN FORM's CLIENT AREA
'      Me.Height = Ui.FormEditor.MaximizeHeight(Me) 'me.MdiParent.ClientSize.Height - me.MdiParent.DockPadding.Top - me.MdiParent.DockPadding.Bottom - 5
'      'align child form to top of mdiparent's client area
'      Me.Location = New Point(Me.Location.X, 0)

'      ' colors controls' forecolors, backcolors, etc. using pre-defined color pallette
'      Me.ColorControls()

'      ' fills comboboxes
'      Me.FillComboboxes()

'      ' fills listboxes with compressor descriptions ({model} HP: {horsepower})
'      Me.FillCompressorListBoxes()
'      Dim condModels As System.Collections.Generic.List(Of Business.Entities.WCCondenser) = Business.Entities.WCCondenser.RetrieveCondensers '.Collections.Specialized.StringCollection = DataAccess35A0.RetrieveWCCondModels()
'      Me.cboCondenser1.DataSource = condModels
'      Me.cboCondenser2.DataSource = condModels
'      Me.cboCondenser1.DisplayMember = "Model"
'      Me.cboCondenser2.DisplayMember = "Model"
'      Me.InitializeControls()

'      Me.Authorize()

'      ' initializes validation utilities (managers, controls, and validators)
'      Me.InitializeValidation()
'      'ChillyRAEs_pass_no = 1 : ChillyRAE() '1 = Parms    2 = Models    3 = 8&10 deg approach

'      loaded = True

'      'add handler to revision view . revision changed event on main form...
'      Dim mainForm As MainForm = CType(My.Application.ApplicationContext.MainForm, MainForm)
'      AddHandler mainForm.RevisionView1.RevisionChanged, AddressOf RevisionView_RevisionChanged

'   End Sub


'   Private Sub Me_Closing(ByVal s As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
'   Handles MyBase.Closing
'      ' logs usage statistics
'      Me.LogFormEnd()
'   End Sub

'#End Region


'#Region " Button Event Handlers"


'   ' Select Alternative Evaporator
'   Private Sub btnAlternateEvaporators_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
'   Handles btnAlternateEvaporators.Click
'      ChillyRAEs_pass_no = 2  ' 1 = Parms    2 = Models    3 = 8&10 deg approach
'      ChillyRAE()
'      Me.cboEvaporatorModel.Visible = True
'   End Sub


'   ' opens chart in popup form that displays
'   ' 1. Leaving Fluid Temp., 2. Recommended Glycol, 3. Freeze Point, 4. Minimum Suction Temp.
'   Private Sub btnGlycolChart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
'   Handles btnGlycolChart.Click
'      Dim form As New Windows.Forms.Form
'      Dim myGrid As New C1.Win.C1TrueDBGrid.C1TrueDBGrid
'      Dim glycolTable As DataTable
'      Dim glycol As String
'      Dim formWidth, formHeight As Integer

'      Me.Cursor = Windows.Forms.Cursors.WaitCursor

'      ' sets selected glycol (ethylene or propylene)
'      glycol = Me.cboCoolingMedia.SelectedItem.ToString

'      ' retrieves glycol table of recommendations
'      If glycol = "Ethylene" Then
'         glycolTable = DataAccess.Chillers.ChillerDataAccess.RetrieveEthylene()
'      ElseIf glycol = "Propylene" Then
'         glycolTable = DataAccess.Chillers.ChillerDataAccess.RetrievePropylene()
'      Else
'         Ui.MessageBox.Show("The selected fluid is water; the fluid must be a glycol in order to chart recommendations.", _
'            MessageBoxIcon.Information)
'         Exit Sub
'      End If

'      ' adds grid to form
'      ' Note: need to add grid to form before setting datasource
'      form.Controls.Add(myGrid)
'      ' sets datagrid's data source
'      myGrid.DataSource = glycolTable

'      ' sets column width and captions
'      With myGrid.Splits(0)
'         ' sets column properties
'         .ColumnCaptionHeight = 36

'         .DisplayColumns(GlycolNames.LeavingFluidTemperature).Width = 100
'         .DisplayColumns(GlycolNames.LeavingFluidTemperature).DataColumn.Caption = "Leaving Fluid Temperature [°F]"
'         .DisplayColumns(GlycolNames.FreezingPoint).Width = 80
'         .DisplayColumns(GlycolNames.FreezingPoint).DataColumn.Caption = "Freezing Point [°F]"
'         .DisplayColumns(GlycolNames.RecommendedGlycolPercentage).Width = 85
'         .DisplayColumns(GlycolNames.RecommendedGlycolPercentage).DataColumn.Caption = "Recommended Glycol [%]"
'         .DisplayColumns(GlycolNames.RecommendedMinSuctionTemperature).Width = 140
'         .DisplayColumns(GlycolNames.RecommendedMinSuctionTemperature).DataColumn.Caption = _
'            "Recommended Minimum Suction Temperature [°F]"
'      End With
'      myGrid.Dock = System.Windows.Forms.DockStyle.Fill
'      myGrid.Caption = glycol & " Table"

'      ' sets grid style to pre-defined style
'      Rae.Ui.C1GridStyles.BasicGridStyle(myGrid)

'      ' initializes form width to outer border width + vertical scroll bar width
'      formWidth = 5 * 2 + myGrid.VScrollBar.Width
'      For i As Integer = 0 To myGrid.Splits(0).DisplayColumns.Count - 1
'         ' calculates form width based on column width and inner borders
'         formWidth += myGrid.Splits(0).DisplayColumns(i).Width + 1
'      Next

'      ' calculates for height (just estimate)
'      formHeight = 34 + myGrid.CaptionHeight + myGrid.Splits(0).ColumnCaptionHeight
'      For i As Integer = 0 To myGrid.Splits(0).Rows.Count - 1
'         formHeight += myGrid.RowHeight + 1
'      Next

'      ' sets form properties
'      form.Width = formWidth
'      form.Height = formHeight
'      form.Text = glycol & " Recommendations"
'      form.MdiParent = Me.MdiParent
'      ' shows form w/ glycol chart
'      form.Show()

'      Me.Cursor = Windows.Forms.Cursors.Default
'   End Sub


'   Private Sub btnCalculatePage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
'   Handles btnCalculatePage.Click
'      ' checks if chiller model is valid
'      If Me.IsChillerModelValid = False Then
'         Ui.MessageBox.Show("Please select a valid chiller model.", MessageBoxIcon.Warning) : Exit Sub : End If

'      ' checks if validation controls are valid
'      If Not Me.chillerVMgr.Validate() Then
'         Ui.MessageBox.Show(Me.chillerVMgr.ErrorMessagesSummary, MessageBoxIcon.Warning) : Exit Sub : End If

'      Me.Cursor = Cursors.WaitCursor

'      Me.StartCalculations()

'      ' deletes temporary database, if there is multiple circuits
'      'Dim dbPath As String = AppInfo.AppFolderPath & "Reports\" & gMyFileNameMDB
'      'Common.IO.DeleteFile(dbPath)

'      Me.Cursor = Cursors.Arrow
'   End Sub


'   Private Sub btnCreateReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreateReport.Click
'      ' checks if chiller model is valid
'      If Me.IsChillerModelValid = False Then _
'         Ui.MessageBox.Show("Please select a valid chiller model.", MessageBoxIcon.Warning) : Exit Sub

'      Me.Cursor = Cursors.WaitCursor

'      Me.StartCalculations() ' calls calculate page
'      If Me.dgrC1Results.Visible = True Then
'         ' copies chiller results from temporary db to permanent db for report
'         'Me.CopyChillerResults()
'         ' builds and shows report
'         Me.ShowReport()
'         ' clears master 30 database (it held temporary info for crystal report)
'         'Try
'         'DataAccess.Chillers.Chiller.DeleteChillerResults()
'         'Catch ex As OleDb.OleDbException
'         'Ui.MessageBox.Show("Attempt to delete chiller results failed. " & ex.Message, MessageBoxButtons.OK)
'         'End Try
'      Else
'         Dim errorMessage As String = "Report could not be created."
'         If lblErro.Text = "" Then
'            lblErro.Text = errorMessage
'         Else
'            lblErro.Text &= Environment.NewLine & errorMessage
'         End If
'      End If

'      ' deletes database that the report was created from
'      'Dim dbPath As String = AppInfo.AppFolderPath & "Reports\" & gMyFileNameMDB
'      'Common.IO.DeleteFile(dbPath)
'      Me.Cursor = Cursors.Arrow
'   End Sub


'#End Region


'#Region " Combobox Event Handlers"


'   Private Sub cboSeries_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
'   Handles cboSeries.SelectedIndexChanged
'      ' sets series
'      Dim series As String = Me.cboSeries.SelectedItem.ToString
'      Dim seriesEnum As Rae.Solutions.Chillers.Series = BCI.ChillerIntel.ConvertStringToSeries(series)

'      ' retrieves chiller models in the selected series
'      Dim chillerModels As DataTable = Rae.RaeSolutions.DataAccess.Chillers.ChillerDataAccess.RetrieveChillerModels(CInt(seriesEnum))


'      ' fills models combobox
'      Me.cboModels.DataSource = chillerModels
'      Me.cboModels.DisplayMember = "Model"
'      loaded = True
'   End Sub

'   Private Function FindSelectedIndex(ByRef cbo As ComboBox, ByVal val As String) As Integer
'      For i As Integer = 0 To cbo.Items.Count - 1
'         If val = cbo.Items(i).ToString Then
'            Return i
'         End If
'      Next
'      Return 0
'   End Function


'   'Model Number combobox selected index changed
'   Private Sub cboModelNumbers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboModels.SelectedIndexChanged
'      Me.Cursor = Cursors.WaitCursor
'      Dim chill As String = Me.GrabChillerModel()
'      ' If loaded = True And Me.GrabChillerModel() <> "Choose" Then

'      'Dim condModels As System.Collections.Generic.List(Of Business.Entities.WCCondenser) = Business.Entities.WCCondenser.RetrieveCondensers '.Collections.Specialized.StringCollection = DataAccess35A0.RetrieveWCCondModels()
'      'Me.cboCondenser1.DataSource = condModels
'      'Me.cboCondenser2.DataSource = condModels

'      'HL_printout.NavigateUrl() = ""
'      dgrC1Results.Visible = False 'hide datagrid
'      lblErro.Text() = "" 'Clear error label text
'      Running_Circuit_no = 1 : CALL_Circuit1()

'      If Val(Txt_circuit_per_unit.Text()) > 1 Then
'         Running_Circuit_no = 2 : CALL_Circuit2()
'      End If

'      ' shows/hides evaporator capacity textboxes
'      Me.SetOtherEvaporatorVisibility()

'      If Val(Txt_circuit_per_unit.Text()) > 1 Then
'         'txtNumFans2.Visible = True
'         txtNumCompressors2.Visible = True
'         txtCompressor2.Visible = True

'      Else
'         txtNumFans2.Visible = False
'         txtNumCompressors2.Visible = False
'         txtCompressor2.Visible = False
'      End If

'      Dim cond1 As New Business.Entities.WCCondenser(DataAccess.WaterCooledDA.RetrieveCondenserByChiller(chill, 1))
'      Me.cboCondenser1.SelectedIndex = FindSelectedIndex(cboCondenser1, cond1.Model)
'      If Val(Txt_circuit_per_unit.Text()) = 4 Then
'         Dim cond4 As New Business.Entities.WCCondenser(DataAccess.WaterCooledDA.RetrieveCondenserByChiller(chill, 4))
'         Me.cboCondenser2.SelectedIndex = FindSelectedIndex(cboCondenser2, cond4.Model)
'         radCircuit1.Text = "Circuit 1 and 3"
'         radCircuit2.Text = "Circuit 2 and 4"
'         lblCircuit1.Text = "Circuit 1 and 3"
'         lblCircuit2.Text = "Circuit 2 and 4"
'         txtCondenserTD2.Enabled = True
'      Else
'         If Val(Txt_circuit_per_unit.Text()) = 2 Then
'            Dim cond2 As New Business.Entities.WCCondenser(DataAccess.WaterCooledDA.RetrieveCondenserByChiller(chill, 2))
'            Me.cboCondenser2.SelectedIndex = FindSelectedIndex(cboCondenser2, cond2.Model)
'         End If
'         radCircuit1.Text = "Circuit 1"
'         radCircuit2.Text = "Circuit 2"
'         lblCircuit1.Text = "Circuit 1"
'         lblCircuit2.Text = "Circuit 2"
'         txtCondenserTD2.Enabled = True
'      End If



'      SetFanWatts()

'      Me.txtModel.Text = Me.GrabChillerModel()
'      'End If

'      Dim chiller As DataTable
'      Try
'         chiller = Rae.RaeSolutions.DataAccess.Chillers.ChillerDataAccess.RetrieveChiller(Me.GrabChillerModel())
'         Me.txtEvaporatorModel.Text = ConvertNull.ToString(chiller.Rows(0).Item("Evap_part_no"))
'      Catch ex As Exception
'         Ui.MessageBox.Show("An exception occurred while attempting to retrieve evaporator model. " & ex.Message)
'      End Try

'      ChillyRAEs_pass_no = 2  ' 1 = Parms    2 = Models    3 = 8&10 deg approach
'      ChillyRAE()

'      'If loaded = True Then
'      Dim line As String = Environment.NewLine
'      Dim evaporatorModel, caption As String

'      ' gets selected evaporator model
'      evaporatorModel = Me.txtEvaporatorModel.Text.Trim

'      ' checks if evaporator model is selected
'      If evaporatorModel = "Choose" Then
'         Me.Cursor = Cursors.Arrow
'         Exit Sub
'      End If


'      Me.dgrC1Results.Visible = False
'      Me.lblErro.Text = ""

'      ChillyRAEs_pass_no = 3  '1 = Parms    2 = Models    3 = 8&10 deg approach
'      ChillyRAE()
'      FillCompressorListBoxes()
'      SetCompressors()
'      'End If

'      Me.Cursor = Cursors.Arrow
'   End Sub

'   'hertz
'   Private Sub cboHertz_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHertz.SelectedIndexChanged
'      If loaded = True Then

'         'HL_printout.NavigateUrl() = ""
'         dgrC1Results.Visible = False 'C1WebGrid2.Visible = False
'         lblErro.Text() = ""

'         Dim switchedFan As String
'         Dim fanFileName As String = Me.GrabFan.FileName

'         If cboHertz.SelectedItem = "60" Then
'            lblRatiVolt.Visible = False
'            lblRatiVolt1.Visible = False
'            Select Case fanFileName
'               Case "LAU2429.950" : switchedFan = "LAU2429"
'               Case "BR28IN.950" : switchedFan = "BR28IN"
'               Case "BR28INHA.950" : switchedFan = "BR28IN.HA"
'               Case "BR28IN.708" : switchedFan = "LAU2840.850"
'               Case "S42832.950" : switchedFan = "S42832"
'            End Select
'         Else
'            Select Case fanFileName
'               Case "LAU2429" : switchedFan = "LAU2429.950"
'               Case "BR28IN" : switchedFan = "BR28IN.950"
'               Case "BR28IN.HA" : switchedFan = "BR28INHA.950"
'               Case "LAU2840.850" : switchedFan = "BR28IN.708" 'REP    (BR28IN.708 HOUSE VERSION)
'               Case "S42832" : switchedFan = "S42832.950"
'            End Select

'            Me.lblRatiVolt.Visible = True
'            Me.lblRatiVolt1.Visible = True
'         End If

'         Dim xxx, xxxx As Single
'         xxxx = cboFan.Items.Count()
'         For xxx = 0 To (xxxx - 1) Step 1
'            cboFan.SelectedIndex = xxx
'            If Me.GrabFan.FileName = switchedFan Then
'               Exit For
'            End If
'            If cboFan.SelectedIndex = (xxxx - 1) Then
'               cboFan.SelectedIndex = 0
'               Exit For
'            End If
'         Next xxx

'         Me.SetFanWatts()
'      End If
'   End Sub

'   Private Sub SetCompressors()
'      Dim compressor As String
'      Dim chillerTable As DataTable = DataAccess.Chillers.ChillerDataAccess.RetrieveChiller(Me.GrabChillerModel(), Rae.RaeSolutions.DataAccess.Common.WCCondenserDbPath)

'      ' checks if there is a matching chiller, if model is set to 'Choose', there won't be a match
'      If chillerTable.Rows.Count > 0 Then
'         ' sets compressor for circuit 1
'         compressor = chillerTable.Rows(0)("Compressor_1").ToString
'         ' selects compressor
'         Me.lboCompressors1.SelectedIndex = ControlAssistant.GetIndexOfValueInListBox(Me.lboCompressors1, compressor)
'         If (compressor <> "" And compressor <> "0") AndAlso Me.lboCompressors1.SelectedIndex = 0 Then
'            Dim compfile As String = chillerTable.Rows(0)("Comprfile_1").ToString
'            For ix As Integer = 0 To Me.lboCompressors1.Items.Count - 1
'               If compfile.ToUpper = Me.lboCompressors1.Items(ix).Row("compfile").ToString().ToUpper Then
'                  Me.lboCompressors1.SelectedIndex = ix
'               End If
'            Next
'         End If
'         ' sets compressor for circuit 2
'         compressor = chillerTable.Rows(0)("Compressor_2").ToString
'         ' selects compressor
'         Me.lboCompressors2.SelectedIndex = ControlAssistant.GetIndexOfValueInListBox(Me.lboCompressors2, compressor)
'         If (compressor <> "" And compressor <> "0") AndAlso Me.lboCompressors2.SelectedIndex = 0 Then
'            Dim compfile As String = chillerTable.Rows(0)("Comprfile_2").ToString
'            For ix As Integer = 0 To Me.lboCompressors1.Items.Count - 1
'               If compfile.ToUpper = Me.lboCompressors2.Items(ix).Row("compfile").ToString().ToUpper Then
'                  Me.lboCompressors2.SelectedIndex = ix
'               End If
'            Next
'         End If

'      End If
'   End Sub


'   'refrigerant	
'   Private Sub cboRatiCritRefr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRefrigerant.SelectedIndexChanged
'      Dim compressor As String

'      If loaded = True Then
'         Me.FillCompressorListBoxes()
'         ' retrieves chiller compressor
'         SetCompressors()

'         If Refrigerant.Type.ToString().IndexOf("404") > -1 Then 'cboRefrigerant.SelectedItem.ValueName = "407c" _
'            'Or cboRefrigerant.SelectedItem.ValueName = "404cH" _
'            'Or cboRefrigerant.SelectedItem.ValueName = "404cM" _
'            'Or cboRefrigerant.SelectedItem.ValueName = "404cL" Then
'            Me.btnAlternateEvaporators.Visible = False
'            cboEvaporatorModel.Visible = False
'         Else
'            Me.btnAlternateEvaporators.Visible = True
'            cboEvaporatorModel.Visible = True
'         End If

'         'handles 407c refrigerant
'         If Refrigerant.Type.ToString().IndexOf("407") > -1 Then 'Me.cboRefrigerant.SelectedItem.ValueName = "407c" Then
'            'clears evaporator model
'            Me.txtEvaporatorModel.Text = ""
'            'hides approach
'            Me.panEvaporatorApproach.Visible = False
'            'selects other evaporator radiobutton
'            Me.radOtherEvaporator.Checked = True
'            'disables approach radiobuttons
'            Me.rad6To8Approach.Enabled = False
'            Me.rad7To9Approach.Enabled = False
'            Me.rad8To10Approach.Enabled = False
'            Me.rad9To11Approach.Enabled = False
'            Me.rad10To12Approach.Enabled = False
'         Else
'            'shows approach
'            Me.panEvaporatorApproach.Visible = True
'            'enables approach radiobuttons
'            Me.rad6To8Approach.Enabled = True
'            Me.rad7To9Approach.Enabled = True
'            Me.rad8To10Approach.Enabled = True
'            Me.rad9To11Approach.Enabled = True
'            Me.rad10To12Approach.Enabled = True
'         End If
'         ChillyRAEs_pass_no = 1 : ChillyRAE()
'         'fills approach and evaporator capacity
'         ChillyRAEs_pass_no = 3 : ChillyRAE()
'      End If
'   End Sub


'   Private Sub cboRatiCritSyst_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSystem.SelectedIndexChanged
'      dgrC1Results.Visible = False
'      lblErro.Text() = ""
'   End Sub

'   Private Sub cboCondCond2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCondenser2.SelectedIndexChanged
'      If loaded = True Then
'         SetCondenserCapacity()
'         ChangeCoilDescription()
'      End If
'   End Sub

'   Private Sub cboCondCond1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCondenser1.SelectedIndexChanged
'      If loaded = True Then
'         SetCondenserCapacity()
'         ChangeCoilDescription()
'      End If
'   End Sub

'   Private Sub cboCondFan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFan.SelectedIndexChanged
'      If loaded = True Then
'         dgrC1Results.Visible = False
'         lblErro.Text() = ""

'         If Me.GrabFan.FileName = "CFM Per Fan >>>" Then
'            Me.txtCfmOverride.Visible = True
'            Me.lblCFM.Visible = True
'            Me.txtFanWatts.ReadOnly = False
'         Else
'            Me.txtCfmOverride.Visible = False
'            Me.lblCFM.Visible = False
'            Me.txtFanWatts.ReadOnly = True
'         End If

'         SetFanWatts()
'      End If
'   End Sub

'   Private Sub cboRatiCritMedi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoolingMedia.SelectedIndexChanged
'      If loaded = True Then
'         'HL_printout.NavigateUrl() = ""
'         dgrC1Results.Visible = False
'         lblErro.Text() = ""

'         ChillyRAEs_pass_no = 1  '1 = Parms    2 = Models    3 = 8&10 deg approach
'         ChillyRAE()
'      End If
'   End Sub


'   'sets evaporator model and fills approach and evaporator capacity
'   Private Sub cboEvapMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEvaporatorModel.SelectedIndexChanged
'      If loaded = True Then
'         Dim line As String = Environment.NewLine
'         Dim evaporatorModel, caption As String

'         ' gets selected evaporator model
'         evaporatorModel = Me.cboEvaporatorModel.SelectedItem.ToString.Trim
'         ' checks if evaporator model is selected
'         If evaporatorModel = "Choose" Then Exit Sub

'         Me.dgrC1Results.Visible = False
'         Me.lblErro.Text = ""

'         Try
'            ' retrieves chiller data
'            Dim chillerTable As DataTable = DataAccess.Chillers.ChillerDataAccess.RetrieveChillerEvaporator(evaporatorModel)
'            With chillerTable.Rows(0)
'               ' builds tool tip caption
'               caption = _
'                  "RAE part number: " & .Item("RaePartNum").ToString & line & _
'                  "Nominal tons: " & .Item("NominalTons").ToString & line & _
'                  "Connection size: " & .Item("ConnectionSize").ToString & line & _
'                  "LxWxH: " & .Item("Length").ToString & "x" & .Item("Width").ToString & "x" & .Item("Height").ToString
'            End With
'            ' sets textbox text to evaporator model
'            Me.txtEvaporatorModel.Text = evaporatorModel
'            ' sets textbox tool tip to basic evaporator info
'            Me.ToolTip1.SetToolTip(Me.txtEvaporatorModel, caption)
'         Catch ex As Exception
'            Ui.MessageBox.Show("An exception occurred while attempting to retrieve evaporator data. " & ex.Message)
'         End Try

'         ' fills approach and evaporator capacity
'         ChillyRAEs_pass_no = 3  '1 = Parms    2 = Models    3 = 8&10 deg approach
'         ChillyRAE()
'      End If
'   End Sub


'   Private Sub cboRatiCritFlui_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFluid.SelectedIndexChanged
'      Me.Cursor = Windows.Forms.Cursors.WaitCursor

'      dgrC1Results.Visible = False
'      lblErro.Text() = ""

'      If cboFluid.SelectedItem = "Water" Then
'         cboCoolingMedia.Visible = False
'         txtGlycolPercentage.Enabled = False
'         'glycol percentage
'         txtGlycolPercentage.Text() = "0"
'         Me.btnGlycolChart.Visible = False
'         'glycol selected
'      Else
'         Me.cboCoolingMedia.Visible = True
'         Me.txtGlycolPercentage.Enabled = True
'         'glycol percentage
'         Me.txtGlycolPercentage.Text = "20"
'         Me.btnGlycolChart.Visible = True
'      End If
'      If loaded Then
'         'sets specific heat and gravity
'         ChillyRAEs_pass_no = 1  '1 = Parms    2 = Models    3 = 8&10 deg approach
'         ChillyRAE()
'         CalculateFreezePoint()
'      End If

'      Me.Cursor = Windows.Forms.Cursors.Default
'   End Sub

'#End Region


'#Region " Radiobox Event Handlers"

'   Private Sub radCompCirc1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radCircuit1.CheckedChanged
'      If radCircuit1.Checked = True Then
'         lboCompressors1.Enabled = True
'         lboCompressors2.Enabled = False
'         Running_Circuit_no = 1
'         'CALL_Circuit1()
'      End If
'   End Sub


'   Private Sub radCompCirc2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radCircuit2.CheckedChanged
'      If radCircuit2.Checked = True Then
'         lboCompressors2.Enabled = True
'         lboCompressors1.Enabled = False
'         Running_Circuit_no = 2
'         'CALL_Circuit2()
'      End If
'   End Sub


'   Private Sub radEvapOtheEvap_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radOtherEvaporator.CheckedChanged
'      Me.SetOtherEvaporatorVisibility()
'   End Sub


'#End Region


'#Region " Textbox Event Handlers"

'   Private Sub txtGlycolPercentage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
'   Handles txtGlycolPercentage.TextChanged
'      If Me.loaded = True Then
'         ChillyRAEs_pass_no = 1  '1 = Parms    2 = Models    3 = 8&10 deg approach
'         ChillyRAE()
'      End If
'   End Sub


'   Private Sub txtLeavingFluidTemp_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
'   Handles txtLeavingFluidTemp.Leave
'      ' validates leaving fluid temperature textbox value
'      Me.leavingFluidTempVCtrl.Validate()
'   End Sub

'   '1. hide error pic if no errors occurred
'   '2. set error text's tooltip
'   Private Sub lblErro_TextChanged(ByVal s As Object, ByVal e As EventArgs) _
'   Handles lblErro.TextChanged
'      ToolTip1.SetToolTip(lblErro, lblErro.Text)
'      If lblErro.Text = "" Then
'         picError.Visible = False
'      Else
'         picError.Visible = True
'      End If
'   End Sub

'#End Region


'#Region " Listbox Event Handlers"

'   Private Sub lbxComp1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lboCompressors1.MouseDown
'      If loaded = True Then
'         If Me.radCircuit1.Checked Then
'            Running_Circuit_no = 1
'            Me.txtCompressor1.Text = Me.lboCompressors1.SelectedValue.ToString
'         End If
'      End If
'   End Sub


'   Private Sub lbxComp2_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lboCompressors2.MouseDown
'      If loaded = True Then
'         If radCircuit2.Checked = True Then
'            Running_Circuit_no = 2
'            Me.txtCompressor2.Text = Me.lboCompressors2.SelectedValue.ToString
'         End If
'      End If
'   End Sub


'   Private Sub lbxComp1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lboCompressors1.SelectedIndexChanged
'      Me.txtCompressor1.Text = Me.lboCompressors1.SelectedValue.ToString
'   End Sub


'   Private Sub lbxComp2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lboCompressors2.SelectedIndexChanged
'      Me.txtCompressor2.Text = Me.lboCompressors2.SelectedValue.ToString
'   End Sub


'#End Region


'#Region " Menu Event Handlers"

'#End Region


'#Region " Panel Event Handlers"
'   '****************************************************************
'   '** Button events that hide/show the panels containing the different
'   '** sections (Compressor, Condenser, etc) of the form
'   '****************************************************************

'   'Rating Criteria Hide Button
'   Private Sub butRatiCritPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCriteriaPlus.Click
'      If Me.btnCriteriaPlus.Text = "+" Then
'         Me.panRatiCritHide.Show()
'         Me.btnCriteriaPlus.Text = "-"
'      Else
'         Me.panRatiCritHide.Hide()
'         Me.btnCriteriaPlus.Text = "+"
'      End If
'   End Sub
'   'Compressor data Hide Button
'   Private Sub butCompDataPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompressorPlus.Click
'      If Me.btnCompressorPlus.Text = "+" Then
'         Me.panCompDataHide.Show()
'         Me.btnCompressorPlus.Text = "-"
'      Else
'         Me.panCompDataHide.Hide()
'         Me.btnCompressorPlus.Text = "+"
'      End If
'   End Sub
'   'Condenser Data Hide Button
'   Private Sub butCondPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCondenserPlus.Click
'      If Me.btnCondenserPlus.Text = "+" Then
'         Me.panCondHide.Show()
'         Me.btnCondenserPlus.Text = "-"
'      Else
'         Me.panCondHide.Hide()
'         Me.btnCondenserPlus.Text = "+"
'      End If
'   End Sub
'   'Evaporator Data Hide Button
'   Private Sub butEvapPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEvaporatorPlus.Click
'      If Me.btnEvaporatorPlus.Text = "+" Then
'         Me.panEvapHide.Show()
'         Me.btnEvaporatorPlus.Text = "-"
'      Else
'         Me.panEvapHide.Hide()
'         Me.btnEvaporatorPlus.Text = "+"
'      End If
'   End Sub

'#End Region


'#End Region


'#Region " Helper Methods"

'   ''' <summary>Logs usage statistics available while form is closing.
'   ''' </summary>
'   ''' <history>[CASEYJ]	3/15/2005	Created
'   ''' </history>
'   Private Sub LogFormEnd()
'      Dim model, refrigerant As String
'      Dim suctionTemperature As Single

'      Try
'         suctionTemperature = Me.txtSuctionTemp.Text
'         model = Me.GrabChillerModel()
'         refrigerant = Me.cboRefrigerant.SelectedItem.DisplayName
'         'logs form usage statistics
'         logger.LogFormEnd(model, refrigerant, suctionTemperature, Me.AmbientTemp)
'      Catch ex As Exception

'      End Try
'   End Sub


'   ''' <summary>Logs start of form.
'   ''' </summary>
'   ''' <history>[CASEYJ]	3/15/2005	Created
'   ''' </history>
'   Private Sub LogFormStart()
'      Try
'         'logs form usage statistics
'         logger = New Diagnostics.UsageLog.FormUsageLogger( _
'            Diagnostics.UsageLog.ApplicationUsageLogger.ApplicationID, _
'            Diagnostics.UsageLog.ApplicationUsageLogger.LogFile.FullName)
'         logger.LogFormStart(Me.Text)
'      Catch ex As Exception

'      End Try
'   End Sub


'   ''' <summary>Fills comboboxes with display and hidden values
'   ''' </summary>
'   Private Sub FillComboboxes()

'      ' fills refrigerant combobox
'      Dim dtbRef As DataTable = Utility.Enum2DataTable(Rae.Engineering.RefrigerantType.R134a)
'      With Me.cboRefrigerant
'         .DataSource = dtbRef 'Me.GetRefrigerants()
'         .DisplayMember = "Key"
'         .ValueMember = "Value"
'         For i As Integer = 0 To .Items.Count - 1
'            Dim drv As DataRowView = .Items(i)
'            If drv.Row("Key") = "R22" Then
'               .SelectedIndex = i
'            End If
'         Next
'      End With

'      ' fills condenser comboboxes
'      'Me.cboCondenser1.DataSource = DataAccess.Chillers.ChillerDataAccess.GetCondensers()
'      'Me.cboCondenser2.DataSource = DataAccess.Chillers.ChillerDataAccess.GetCondensers()

'      ' fills fan comboboxes
'      Me.cboFan.DataSource = CondenserDataAccess.GetChillerFans()

'      ' fills fins per inch comboboxes
'      'Me.cboFinsPerInch1.DataSource = Me.GetFinsPerInchOptions()
'      'Me.cboFinsPerInch2.DataSource = Me.GetFinsPerInchOptions()

'   End Sub

'   Public Function writexmldata(ByVal formname As Form) As Boolean
'      Dim ctl As Control, ctl2 As Control, ctl3 As Control
'      For Each ctl In formname.Controls
'         If ctl.Name Like "i_*" Then

'         End If
'         If ctl.HasChildren = True Then
'            For Each ctl2 In ctl.Controls
'               If ctl2.Name Like "i_*" Then

'               End If
'            Next
'         End If
'      Next
'   End Function



'   Private Sub ShowReport()
'      Dim report As CREngine.ReportDocument
'      Dim dbPath As String
'      Dim fields As CREngine.ParameterFieldDefinitions
'      Dim field As Rae.Reporting.CrystalReports.SingleParameterFieldDefinition
'      Dim evaporator8, evaporator10, condenserCapacity, fan As String
'      Dim reportForm As Rae.Reporting.CrystalReports.ReportViewerForm
'      Dim chillerModel, condenser, system, fluid, circuitNote, operatingLimits, catalogRating As String
'      Dim numCompressors1, numCompressors2, compressorFileName1, compressorFileName2, compressor As String
'      Dim circuitsPerUnit, lowerApproach, upperApproach As Integer

'      report = New CREngine.ReportDocument()
'      report.Load(Reports.FilePaths.WaterCooledChillerRatingReportFilePath)
'      reportForm = New Rae.Reporting.CrystalReports.ReportViewerForm()

'      'sets database location so it's not pointing to database location
'      'on the development computer
'      'dbPath = AppInfo.Database(eDatabase.dbMaster30)
'      Try
'         Dim dt2 As DataTable
'         dt2 = cd.dt.Copy()
'         'dt2.WriteXml("C:\" & dt2.TableName & ".xml")
'         'report.SetDataSource(cd.ds)
'         report.SetDataSource(dt2)
'         'report.DataSourceConnections.Item(0).SetConnection(dbPath, dbPath, "", "")
'         'report.DataSourceConnections.Item(0).SetConnection()

'      Catch ex As Exception
'         MessageBox.Show( _
'            "Attempt to set the database connection for the report failed." & _
'            Environment.NewLine & dbPath & Environment.NewLine & ex.ToString, _
'            "Crystal Reports", MessageBoxButtons.OK, MessageBoxIcon.Error)
'      End Try

'      fields = report.DataDefinition.ParameterFields
'      field = New Rae.Reporting.CrystalReports.SingleParameterFieldDefinition(fields)


'      ' sets parameters
'      '
'      If Me.txtModel.Text = Me.GrabChillerModel() Then
'         chillerModel = Me.GrabChillerModel()
'      Else
'         chillerModel = Me.txtModel.Text & "       Base Model: " & Me.GrabChillerModel()
'      End If

'      ' TODO: remove condenser textbox it's only used for report
'      If cboSystem.SelectedItem = "FULL" And Val(Txt_circuit_per_unit.Text()) = 2 _
'      Or Val(Txt_circuit_per_unit.Text()) = 4 Then
'         condenser = "(" & Me.txtNumCoils1.Text & ")" & Me.cboCondenser1.Text.Trim _
'          & " --- " & "(" & Me.txtNumCoils2.Text & ")" & Me.cboCondenser2.Text.Trim
'      ElseIf cboSystem.SelectedItem = "FULL" And Val(Txt_circuit_per_unit.Text()) = 1 Then
'         condenser = "(" & Me.txtNumCoils1.Text & ")" & Me.cboCondenser1.Text.Trim
'      ElseIf cboSystem.SelectedItem = "HALF" And radCircuit1.Checked = True Then
'         condenser = "(" & Me.txtNumCoils1.Text & ")" & Me.cboCondenser1.Text.Trim
'      ElseIf cboSystem.SelectedItem = "HALF" And radCircuit2.Checked = True Then
'         condenser = "(" & Me.txtNumCoils2.Text & ")" & Me.cboCondenser2.Text.Trim
'      End If

'      system = Me.cboSystem.SelectedItem.ToString
'      circuitsPerUnit = CInt(Me.Txt_circuit_per_unit.Text.Trim)
'      numCompressors1 = Me.txtNumCompressors1.Text.Trim
'      numCompressors2 = Me.txtNumCompressors2.Text.Trim
'      compressorFileName1 = DirectCast(Me.lboCompressors1.SelectedItem, DataRowView)("compfile").ToString
'      compressorFileName2 = DirectCast(Me.lboCompressors2.SelectedItem, DataRowView)("compfile").ToString

'      If system = "FULL" And circuitsPerUnit = 1 Then
'         compressor = "(" & numCompressors1 & ") " & compressorFileName1
'      ElseIf system = "FULL" And circuitsPerUnit = 2 _
'      Or circuitsPerUnit = 4 Then
'         compressor = "(" & numCompressors1 & ") " & compressorFileName1 & _
'            " --- " & "(" & numCompressors2 & ") " & compressorFileName2
'      ElseIf system = "HALF" And Me.radCircuit1.Checked Then
'         compressor = "(" & numCompressors1 & ") " & compressorFileName1
'      ElseIf system = "HALF" And Me.radCircuit2.Checked Then
'         compressor = "(" & numCompressors2 & ") " & compressorFileName2
'      End If

'      If cboFluid.SelectedItem = "Water" Then
'         fluid = cboFluid.SelectedItem
'      Else
'         fluid = Me.cboFluid.SelectedItem.ToString & "   " & Me.txtGlycolPercentage.Text.Trim & "% " & Me.cboCoolingMedia.SelectedItem.ToString
'      End If

'      If system = "HALF" Then
'         If radCircuit1.Checked Then
'            If Val(Me.Txt_circuit_per_unit.Text) = 1 Then
'               circuitNote = "Showing Circuit 1 of 1"
'            Else
'               circuitNote = "Showing Circuit 1 of 2"
'            End If
'         Else
'            circuitNote = "Showing Circuit 2 of 2"
'         End If
'      Else
'         circuitNote = " "
'      End If

'      If lblOperLimi.Visible = True Then
'         operatingLimits = Me.lblOperLimi.Text ' Points Omitted
'      Else
'         operatingLimits = ""
'      End If

'      If Me.rad6To8Approach.Checked Then
'         lowerApproach = 6 : upperApproach = 8
'      ElseIf Me.rad7To9Approach.Checked Then
'         lowerApproach = 7 : upperApproach = 9
'      ElseIf Me.rad8To10Approach.Checked Then
'         lowerApproach = 8 : upperApproach = 10
'      ElseIf Me.rad9To11Approach.Checked Then
'         lowerApproach = 9 : upperApproach = 11
'      ElseIf Me.rad10To12Approach.Checked Then
'         lowerApproach = 10 : upperApproach = 12
'      ElseIf Me.radOtherEvaporator.Checked Then
'         lowerApproach = 8 : upperApproach = 10
'      End If

'      ' 8F Evaporator, 10F Evaporator, Condenser Capacity @ 25F, Fan
'      If cboSystem.SelectedItem = "FULL" And Val(Txt_circuit_per_unit.Text) = 1 Then
'         If radOtherEvaporator.Checked Then
'            evaporator8 = tbxEvap8Degr1.Text
'            evaporator10 = tbxEvap10Degr1.Text
'         Else
'            evaporator8 = txtCapacityAt8FApproach.Text
'            evaporator10 = txtCapacityAt10FApproach.Text
'         End If

'         condenserCapacity = Val(Me.txtCondenserCapacity1.Text)
'         If Me.GrabFan.FileName = "CFM Per Fan >>>" Then
'            fan = "(" & Val(txtNumFans1.Text) * Val(txtNumCoils1.Text) & ") " _
'            & Me.GrabFan.FileName & txtCfmOverride.Text & "   Altitude = " & txtAltitude.Text
'         Else
'            fan = "(" & Val(txtNumFans1.Text) * Val(txtNumCoils1.Text) & ") " _
'            & Me.GrabFan.Description & "   Altitude = " & Me.txtAltitude.Text
'         End If
'      ElseIf cboSystem.SelectedItem = "FULL" And Val(Txt_circuit_per_unit.Text) = 2 _
'      Or Val(Txt_circuit_per_unit.Text) = 4 Then
'         If radOtherEvaporator.Checked = True Then
'            evaporator8 = Val(tbxEvap8Degr1.Text) + Val(tbxEvap8Degr2.Text)
'            evaporator10 = Val(tbxEvap10Degr1.Text) + Val(tbxEvap10Degr2.Text)
'         Else
'            evaporator8 = Q8 + Q8
'            evaporator10 = Q9 + Q9
'         End If
'         condenserCapacity = Val(txtCondenserCapacity1.Text) + Val(txtCondenserCapacity2.Text)
'         If Me.GrabFan.FileName = "CFM Per Fan >>>" Then
'            fan = "(" & (Val(txtNumFans1.Text) * Val(txtNumCoils1.Text)) + (Val(txtNumFans2.Text) * Val(txtNumCoils2.Text)) & ") " _
'            & Me.GrabFan.FileName & Val(txtCfmOverride.Text) & "   Altitude = " & Val(txtAltitude.Text)
'         Else
'            fan = "(" & (Val(txtNumFans1.Text) * Val(txtNumCoils1.Text)) + (Val(txtNumFans2.Text) * Val(txtNumCoils2.Text)) & ") " _
'            & Me.GrabFan.Description & "   Altitude = " & Me.txtAltitude.Text
'         End If
'      ElseIf cboSystem.SelectedItem = "HALF" And radCircuit1.Checked = True Then
'         If radOtherEvaporator.Checked Then
'            evaporator8 = Val(tbxEvap8Degr1.Text)
'            evaporator10 = Val(tbxEvap10Degr1.Text)
'         Else
'            evaporator8 = Q8
'            evaporator10 = Q9
'         End If
'         condenserCapacity = Val(txtCondenserCapacity1.Text)
'         If Me.GrabFan.FileName = "CFM Per Fan >>>" Then
'            fan = "(" & Val(txtNumFans1.Text()) * Val(txtNumCoils1.Text()) & ") " & Me.GrabFan.FileName & Val(txtCfmOverride.Text()) & "   Altitude = " & Val(txtAltitude.Text())
'         Else
'            fan = "(" & Val(txtNumFans1.Text()) * Val(txtNumCoils1.Text()) & ") " & Me.GrabFan.Description & "   Altitude = " & Val(txtAltitude.Text())
'         End If
'      ElseIf cboSystem.SelectedItem = "HALF" And radCircuit2.Checked = True Then
'         If radOtherEvaporator.Checked = True Then
'            evaporator8 = tbxEvap8Degr2.Text
'         Else
'            evaporator8 = Q9
'         End If
'         evaporator10 = tbxEvap10Degr2.Text
'         condenserCapacity = txtCondenserCapacity2.Text
'         If Me.GrabFan.FileName = "CFM Per Fan >>>" Then
'            fan = "(" & Val(txtNumFans2.Text()) * Val(txtNumCoils2.Text()) & ") " & Me.GrabFan.Description & Val(txtCfmOverride.Text()) & "   Altitude = " & Val(txtAltitude.Text())
'         Else
'            fan = "(" & Val(txtNumFans2.Text()) * Val(txtNumCoils2.Text()) & ") " & Me.GrabFan.Description & "   Altitude = " & Val(txtAltitude.Text())
'         End If
'      End If

'      If chkCatalogRating.Checked = True Then
'         catalogRating = "Catalog Rating"
'      Else
'         catalogRating = ""
'      End If

'      ' authorization ("Rep" or "Engineer")
'      field.Pass("Engineer", "pfdAuthorization")
'      ' version
'      field.Pass(My.Application.Info.Version.ToString, "pfdVersion")
'      ' ambient Temperature (so row with entered Ambient and Leaving Fluid Temp can be uniquely formatted)
'      field.Pass(Me.AmbientTemp, "pfdAmbient")
'      ' leaving fluid temperature
'      field.Pass(Me.LeavingFluidTemp, "pfdLeavingFluid")
'      ' test
'      field.Pass(Constants.TESTING.ToString, "pfdTest")
'      ' logo
'      field.Pass("TSI", "pfdLogo")
'      ' user name for login
'      field.Pass(AppInfo.User.Username, "pfdCreator")
'      ' model number
'      field.Pass(chillerModel, "pfdModelNumber")
'      ' condenser
'      field.Pass(condenser, "pfdCondenser")
'      ' evaporator
'      field.Pass(Me.txtEvaporatorModel.Text.Trim & "   Fouling = " & cboFoulingFactor.SelectedItem, "pfdEvaporator")
'      ' system
'      field.Pass(system, "pfdSystem")
'      ' compressor
'      field.Pass(compressor, "pfdCompressor")
'      ' fan is set below
'      ' fluid
'      field.Pass(fluid, "pfdFluid")
'      ' refrigerant
'      field.Pass(Me.Refrigerant.Name, "pfdRefrigerant")
'      ' hertz
'      field.Pass(Me.cboHertz.SelectedItem, "pfdHertz")
'      ' circuit
'      field.Pass(circuitNote, "pfdCircuit")
'      ' operating limits
'      field.Pass(operatingLimits, "pfdOperatingLimits")
'      ' temperature range
'      field.Pass("Calculations based on " & Me.txtTempRange.Text.Trim & "ºF Range", "pfdRange")

'      'Change:          Report always shows 8 and 10 degree approach regardless of the approach selected on form.

'      '                 Previously, the approach selected was being shown, but the labels always said 8 and 10, 
'      '                 even if the approach was different.

'      'Requested by:    Jim McLarty
'      'Modified by:     Casey Joyce
'      'Date modified:   12/9/2004
'      ' lower approach
'      field.Pass(lowerApproach, "pfdLowerApproach")
'      ' upper approach
'      field.Pass(upperApproach, "pfdUpperApproach")

'      ' 8F Evaporator
'      field.Pass(evaporator8, "pfd8Evaporator")
'      ' 10F Evaporator
'      field.Pass(evaporator10, "pfd10Evaporator")
'      ' Condenser Capacity
'      field.Pass(condenserCapacity, "pfdCondenserCapacity")
'      ' fan (set here because, value is based on variables that weren't set before)
'      field.Pass(fan, "pfdfans")
'      ' discharge line loss
'      field.Pass(Me.cboDischargeLineLoss.SelectedItem, "pfdDischarge")
'      ' suction line loss
'      field.Pass(Me.cboSuctionLineLoss.SelectedItem, "pfdSuction")
'      ' catalog rating
'      field.Pass(catalogRating, "pfdCatalog")


'      ' sets CR Viewer report source to appropriate CR Report
'      reportForm.ReportViewer.ReportSource = report
'      ' alternatively can be set with file path as below
    '   ReportForm.CRViewer1.ReportSource = "..\Report1.rpt"
'      reportForm.ReportViewer.Zoom(1) '1 = page width, 2 = whole page, else %
'      reportForm.Show()
'   End Sub


'   'sets hid condenser textboxes w/
'   '1. Changed Coil Type
'   '2. Condenser Fin Height
'   '3. Condenser Fin Length
'   '4. Fins per Inch
'   '5. Changed Rows
'   '6. Sub Cooling (Yes/No)
'   Private Sub ChangeCoilDescription()
'      Dim numRows As String
'      Dim coilType As String = "12"
'      Dim subCooling As String = ""

'      ' condenser 1
'      If cboCondenser1.SelectedIndex = 0 Then
'         numRows = "2"
'      ElseIf cboCondenser1.SelectedIndex = 1 Then
'         numRows = "3"
'      ElseIf cboCondenser1.SelectedIndex = 2 Then
'         numRows = "4"
'      ElseIf cboCondenser1.SelectedIndex = 3 Then
'         numRows = "5"
'      ElseIf cboCondenser1.SelectedIndex = 4 Then
'         numRows = "6"
'      End If
'      ' sub cooling
'      If cboSubCooling1.SelectedItem = "Yes" Then
'         subCooling = "-S/C"
'      End If
'      ' sets hid condenser 1 textbox
'      'Me.txtCondenser_1.Text = coilType & "C" & txtFinHeight1.Text & "X" & Me.txtFinLength1.Text & _
'      '   "-" & Me.cboFinsPerInch1.SelectedItem.ToString & "-" & numRows & "-1C" & subCooling

'      ' condenser 2
'      'If cboCondenser2.SelectedIndex = 0 Then
'      ' numRows = "2"
'      'ElseIf cboCondenser2.SelectedIndex = 1 Then
'      'numRows = "3"
'      'ElseIf cboCondenser2.SelectedIndex = 2 Then
'      'numRows = "4"
'      'ElseIf cboCondenser2.SelectedIndex = 3 Then
'      'numRows = "5"
'      'ElseIf cboCondenser2.SelectedIndex = 4 Then
'      'numRows = "6"
'      'End If

'      ' sub cooling
'      If cboSubCooling2.SelectedItem = "Yes" Then
'         subCooling = "-S/C"
'      Else
'         subCooling = ""
'      End If

'      'Me.txtCondenser_2.Text = coilType & "C" & Val(txtFinHeight2.Text) & "X" & Val(txtFinLength2.Text) & _
'      '   "-" & cboFinsPerInch2.SelectedItem.ToString & "-" & numRows & "-1C" & subCooling

'      ''''SetCondenserCapacity()

'   End Sub

'   '    Private Sub Do_Calc_2()

'   '        T = TE + 459.69

'   '        If gRef = "R-22" Then
'   '            P = 29.35754453 + (-3845.193152 / T) + (-7.86103122 * (Log(T) / Log(10))) + (0.002190939 * T) + ((0.445746703 * (686.1 - T)) / T) * (Log(686.1 - T) / Log(10))
'   '            PE = 10 ^ P
'   '        ElseIf gRef = "404" Then
'   '            P = 72.1209 + (-7315.14 / T) + ((-8.717729) * (Log(T)) + (0.0000051875 * T ^ 2))
'   '            PE = 2.7182818 ^ P
'   '        ElseIf gRef = "507" Then
'   '            P = 29.24862663 + (-6980.5944 / T) + (-0.03143806111 * T) + (0.00002034543662 * T ^ 2)
'   '            PE = 2.7182818 ^ P
'   '        ElseIf gRef = "R-502" Then
'   '            P = 10.644955 + (-3671.153813 / T) + (-0.369835 * (Log(T) / Log(10))) + (-0.001746352 * T) + ((0.8161139 * (654 - T)) / T) * (Log(654 - T) / Log(10))
'   '            PE = 10 ^ P
'   '        ElseIf gRef = "407C" Then
'   '            P = 78.3549 + (-8101.06 / T) + (-9.51789 * Log(T)) + (0.0000053558 * (T ^ 2))
'   '            PE = 2.7182818 ^ P
'   '        ElseIf gRef = "134A" Then
'   '            P = 22.98993635 + (-7243.876722 / T) + (-0.013362956 * T) + (0.00000692966 * T ^ 2) + ((0.1995548 * (674.72514 - T)) / T) * (Log(674.72514 - T))
'   '            PE = 2.7182818 ^ P
'   '        End If

'   '        ''''''''''''''''''''''''''''''11111095 TC = 95: GoTo 11900000 '*********************************************************
'   '11000000: Z = 1 : GoTo 11800000
'   '11100000: TC = TC + 10
'   '11200000: GoTo 11800000
'   '11300000: TC = TC + 5
'   '11400000: GoTo 11800000
'   '11500000: TC = TC + 1
'   '11600000: GoTo 11800000
'   '11700000: TC = TC + 0.2
'   '11800000: H1 = (TC - T1) / M
'   '11900000: T = TC + 459.69

'   '        If gRef = "R-22" Then
'   '            P = Round(29.35754453 + (-3845.193152 / T) + (-7.86103122 * (Log(T) / Log(10))) + (0.002190939 * T) + ((0.445746703 * (686.1 - T)) / T) * (Log(686.1 - T) / Log(10)), 10)
'   '            PC = Round(10 ^ P, 16)
'   '        ElseIf gRef = "404" Then
'   '            P = 57.5895 + (-6526.55 / T) + ((-6.58061) * (Log(T)) + (0.00000393732 * T ^ 2))
'   '            PC = 2.7182818 ^ P
'   '        ElseIf gRef = "507" Then
'   '            P = 29.24862663 + (-6980.5944 / T) + (-0.03143806111 * T) + (0.00002034543662 * T ^ 2)
'   '            PC = 2.7182818 ^ P
'   '        ElseIf gRef = "R-502" Then
'   '            P = 10.644955 + (-3671.153813 / T) + (-0.369835 * (Log(T) / Log(10))) + (-0.001746352 * T) + ((0.8161139 * (654 - T)) / T) * (Log(654 - T) / Log(10))
'   '            PC = 10 ^ P
'   '        ElseIf gRef = "407C" Then
'   '            P = 43.3622 + (-6020.28 / T) + (-4.3987 * Log(T)) + (0.00000212036 * (T ^ 2))
'   '            PC = 2.7182818 ^ P
'   '        ElseIf gRef = "134A" Then
'   '            P = 22.98993635 + (-7243.876722 / T) + (-0.013362956 * T) + (0.00000692966 * T ^ 2) + ((0.1995548 * (674.72514 - T)) / T) * (Log(674.72514 - T))
'   '            PC = 2.7182818 ^ P
'   '        End If

'   '        A = C0 + C1 * TC
'   '        BA = C2 * PC + C3 * PE + C4 * PC * PE
'   '        DA = C5 * PE ^ 0.5 + C6 * PC / PE ^ 0.5
'   '        Y1 = A + BA + DA
'   '        TONS = Y1 * CAPM * NC
'   '        Q = TONS * 12000
'   '        A1 = P0 + P1 * TC
'   '        BB = P2 * PC + P3 * PE + P4 * PC * PE
'   '        DD = P5 * PE ^ 0.5 + P6 * PC / PE ^ 0.5
'   '        W1 = A1 + BB + DD
'   '        BHP = W1 * BHPM * NC
'   '        H2 = Q + (2545 * BHP)
'   '        ER = TONS * 12 / (BHP * 0.746 * 1.1)

'   '        ''''''''''''''''''''''''''''''Exit Sub '*****************************************************************************

'   '        'Q = (C0 + (C1 * TC) + (C2 * PE) + ((C3 * PE) * PC) + (C4 * PC) / Sqr(PE)) * NC
'   '        'BHP = (P0 + (P1 * TC) + (P2 * PE) + ((P3 * PE) * PC) + (P4 * PC) / Sqr(PE)) * NC
'   '        'TONS = Q / 12000
'   '        'H2 = Q + (2545 * BHP)
'   '        'ER = TONS * 12 / (BHP * 0.746 * 1.1)

'   '        If Z = 1 Then GoTo 13900000
'   '        If Z = 2 Then GoTo 14100000
'   '        If Z = 3 Then GoTo 14300000
'   '        If Z = 4 Then GoTo 14500000
'   '13900000: If H1 < H2 Then GoTo 11100000
'   '14000000: TC = TC - 10 : Z = 2 : GoTo 11300000
'   '14100000: If H1 < H2 Then GoTo 11300000
'   '14200000: TC = TC - 5 : Z = 3 : GoTo 11500000
'   '14300000: If H1 < H2 Then GoTo 11500000
'   '14400000: TC = TC - 1 : Z = 4 : GoTo 11700000
'   '14500000: If H1 < H2 Then GoTo 11700000
'   '        '14600000 Return

'   '    End Sub

'   'reset variables	
'   Private Sub ResetVariables()

'      gCatalogRating = 0  'CR_S PRINT OUT CATALOG RATINGS?Y/N
'      gRef = ""               'Refrigerant type


'      A = 0
'      B = 0
'      Q = 0
'      gTemperatureRange = 0                   'RANGE IN DEG. F.
'      T = 0
'      W = 0


'      gCondenserCapacity = 0                  'COND. CAP. @ 25 DEG TEMP. DIF.
'      EZ = 0
'      ER = 0
'      GP = 0
'      H1 = 0
'      H2 = 0
'      KW = 0
'      gSubCoolingTemp = 0                  'LIQUID COOLING(GLYCOL)
'      M1 = 0
'      gCompressorQuantity = 0  'NUMBER OF COMPRESSOR CIRCUITS
'      gNumberOfFans = 0        'NUMBER OF FANS
'      PC = 0
'      'PD = 0
'      PE = 0
'      Q1 = 0
'      Q8 = 0                  'CHILLER CAP. @ 8 DEG APPROACH
'      Q9 = 0                  'CHILLER CAP. @ 10 DEG APPROACH
'      gAmbientTempStep = 0
'      TC = 0
'      TE = 0
'      TW = 0
'      Me.subCoolingFactor = 0                 'GLYCOL
'      TE1 = 0
'      TE2 = 0
'      TW1 = 0
'      TW2 = 0
'      gMF1 = 0                'MULTIPLY FACTOR FOR COMPRESSORS
'      gMF2 = 0                'MULTIPLY FACTOR FOR COMPRESSORS
'      gMF3 = 0                'MULTIPLY FACTOR FOR COMPRESSORS
'      gVolts = 0              'VOLTAGE
'      GPMFACT = 0             'GLYCOL
'      fanWatts = 0
'      Hertz2 = 0
'      Hertz3 = 0
'      Hertz4 = 0
'      Hertz21 = 0

'      gOD = False             'TEST FOR OPEN DRIVE
'      gHP_O = False           'TEST FOR HORSEPOWER(OTHER)
'      gClosed = False         'TEST FOR DATA100.CLOSE
'      Exit_Select = False     'TEST FOR EXITING START SELECTION PROCEDURE
'      Exit_Glycol = False     'TEST FOR EXITING GLYCOL PROCEDURE
'      BAD_FLUID_TYPE = False  'TEST FOR BAD FLUID TYPE
'      '***** END *************************
'   End Sub


'   ' calculates and fills condenser coil capacity for either circuit 1 or 2
'   Private Sub SetCondenserCapacity()
'      Dim cond1 As New Rae.RaeSolutions.Business.Entities.WCCondenser(Rae.RaeSolutions.DataAccess.WaterCooledDA.RetrieveCondenser(Me.cboCondenser1.Text))
'      Dim cond2 As New Rae.RaeSolutions.Business.Entities.WCCondenser(Rae.RaeSolutions.DataAccess.WaterCooledDA.RetrieveCondenser(Me.cboCondenser2.Text))

'      Me.txtCondenserCapacity1.Text = CStr(Round(cond1.Capacity * CDbl(Me.txtNumCoils1.Text), 2))
'      Me.txtCondenserCapacity2.Text = CStr(Round(cond2.Capacity * CDbl(Me.txtNumCoils2.Text), 2))
'   End Sub

'   Private Sub Add10(ByRef v As Double)
'      v += 10
'   End Sub

'   Private Sub Add5(ByRef v As Double)
'      v += 5
'   End Sub

'   Private Sub Add1(ByRef v As Double)
'      v += 1
'   End Sub

'   Private Sub Add2Tenths(ByRef v As Double)
'      v += 0.2
'   End Sub

'   Private Sub PreCalculate()

'      cd = New RaeSolutions.CRDAL
'      cd.CRDAL(True)

'      CalculateFreezePoint()  'set freeze point and suction temp controls
'      'count_passes = 1
'      lblOperLimi.Visible = False
'      lblOperLimi.Text() = "Points outside operating limits omitted, contact factory for selection."

'      'Show/hide other evaporator textboxes
'      If AppInfo.User.AuthorityGroup <= 2 Then
'         If radOtherEvaporator.Checked = True Then
'            tbxEvap8Degr1.Visible = True
'            tbxEvap10Degr1.Visible = True
'            If Val(Txt_circuit_per_unit.Text()) > 1 Then
'               tbxEvap8Degr2.Visible = True
'               tbxEvap10Degr2.Visible = True
'            End If
'         Else
'            tbxEvap8Degr1.Visible = False
'            tbxEvap10Degr1.Visible = False
'            tbxEvap8Degr2.Visible = False
'            tbxEvap10Degr2.Visible = False
'         End If
'      End If

'      lblErro.Text() = ""   'clear errors
'      dgrC1Results.Visible = True 'show datagrid

'      ChangeCoilDescription()  'fills hid condenser textboxes
'      Dim my_Counter_pass As Single = 0
'      Dim nextCuritem As Integer = 0

'      'fill dropdown w/ datagrid values
'      If cboSystem.SelectedItem = "FULL" And Val(Txt_circuit_per_unit.Text()) = 2 _
'      Or Val(Txt_circuit_per_unit.Text()) = 4 Then
'         If ok_to_print = True And nextCuritem = 0 Then
'            Me.DropDownList3.DataSource = Nothing
'            DropDownList3.DataSource = myarrayprint3
'         End If
'      End If

'      ResetVariables()

'      'set specific heat and specific gravity controls 
'      ChillyRAEs_pass_no = 1  '1 = Parms    2 = Models    3 = 8&10 deg approach
'      ChillyRAE()
'      'fills condenser capacity textbox
'      SetCondenserCapacity()
'      'fill approach and evaporative capacity
'      ChillyRAEs_pass_no = 3  '1 = Parms    2 = Models    3 = 8&10 deg approach
'      ChillyRAE()

'      '******************************************
'      '** Display error message if error occurs (select valid approach)
'      '******************************************
'      If radOtherEvaporator.Checked = True Then
'         If Val(tbxEvap8Degr1.Text) = 0 Or Val(tbxEvap10Degr1.Text) = 0 Then
'            lblErro.Text() = "Please enter a valid 8 and 10 deg. approach for circuit 1"
'            dgrC1Results.Visible = False
'            Exit Sub
'         End If
'         If Val(Txt_circuit_per_unit.Text) > 1 Then
'            If Val(tbxEvap8Degr2.Text) = 0 Or Val(tbxEvap10Degr2.Text) = 0 Then
'               lblErro.Text = "Please enter a valid 8 and 10 deg. approach for circuit 2"
'               dgrC1Results.Visible = False
'               Exit Sub
'            End If
'         End If
'      Else
'         If rad6To8Approach.Checked = True Then
'            If Val(txtCapacityAt6FApproach.Text) = 0 Or Val(txtCapacityAt8FApproach.Text) = 0 Then
'               lblErro.Text = "Please select a valid approach"
'               dgrC1Results.Visible = False
'               Exit Sub
'            End If
'         ElseIf rad7To9Approach.Checked = True Then
'            If Val(txtCapacityAt7FApproach.Text) = 0 Or Val(txtCapacityAt9FApproach.Text) = 0 Then
'               lblErro.Text() = "Please select a valid approach"
'               dgrC1Results.Visible = False
'               Exit Sub
'            End If
'         ElseIf rad8To10Approach.Checked = True Then
'            If Val(txtCapacityAt8FApproach.Text) = 0 Or Val(txtCapacityAt10FApproach.Text) = 0 Then '58200, 66, 738
'               lblErro.Text = "Please select a valid approach"
'               dgrC1Results.Visible = False
'               Exit Sub
'            End If
'         ElseIf rad9To11Approach.Checked = True Then
'            If Val(txtCapacityAt9FApproach.Text) = 0 Or Val(txtCapacityAt11FApproach.Text) = 0 Then
'               lblErro.Text() = "Please select a valid approach"
'               dgrC1Results.Visible = False
'               Exit Sub
'            End If
'         ElseIf rad10To12Approach.Checked = True Then
'            If Val(txtCapacityAt10FApproach.Text()) = 0 Or Val(txtCapacityAt12FApproach.Text()) = 0 Then
'               lblErro.Text() = "Please select a valid approach"
'               dgrC1Results.Visible = False
'               Exit Sub
'            End If
'         End If
'      End If
'   End Sub

'   Private Function GetWTs() As ArrayList
'      Dim gLFT As Integer = LeavingFluidTemp
'      Dim al As New ArrayList
'      If gLFT > -40 And gLFT <= -35 Then
'         al.Add(-50)
'         al.Add(-35)
'      ElseIf gLFT > -35 And gLFT <= -30 Then
'         al.Add(-45)
'         al.Add(-30)
'      ElseIf gLFT > -30 And gLFT <= -25 Then
'         al.Add(-40)
'         al.Add(-25)
'      ElseIf gLFT > -25 And gLFT <= -20 Then
'         al.Add(-35)
'         al.Add(-20)
'      ElseIf gLFT > -20 And gLFT <= -15 Then
'         al.Add(-30)
'         al.Add(-15)
'      ElseIf gLFT > -15 And gLFT <= -10 Then
'         al.Add(-25)
'         al.Add(-10)
'      ElseIf gLFT > -10 And gLFT <= -5 Then
'         al.Add(-20)
'         al.Add(-5)
'      ElseIf gLFT > -5 And gLFT <= 0 Then
'         al.Add(-15)
'         al.Add(0)
'      ElseIf gLFT > 0 And gLFT <= 5 Then
'         al.Add(-10)
'         al.Add(5)
'      ElseIf gLFT > 5 And gLFT <= 10 Then
'         al.Add(-5)
'         al.Add(10)
'      ElseIf gLFT > 10 And gLFT <= 15 Then
'         al.Add(0)
'         al.Add(15)
'      ElseIf gLFT > 15 And gLFT <= 20 Then
'         al.Add(5)
'         al.Add(20)
'      ElseIf gLFT > 20 And gLFT <= 25 Then
'         al.Add(10)
'         al.Add(25)
'      ElseIf gLFT > 25 And gLFT <= 30 Then
'         al.Add(15)
'         al.Add(30)
'      ElseIf gLFT > 30 And gLFT <= 35 Then
'         al.Add(20)
'         al.Add(35)
'      ElseIf gLFT > 35 And gLFT <= 40 Then
'         al.Add(25)
'         al.Add(40)
'      ElseIf gLFT > 40 And gLFT <= 45 Then
'         al.Add(30)
'         al.Add(45)
'      ElseIf gLFT > 45 And gLFT <= 50 Then
'         al.Add(35)
'         al.Add(50)
'      ElseIf gLFT > 50 And gLFT <= 55 Then
'         al.Add(40)
'         al.Add(55)
'      ElseIf gLFT > 55 And gLFT <= 60 Then
'         al.Add(45)
'         al.Add(60)
'      ElseIf gLFT > 60 And gLFT <= 65 Then
'         al.Add(50)
'         al.Add(65)
'      End If
'      Return al
'   End Function

'   Private Sub CalculatePage()
'      PreCalculate()
'      Dim Compr_KW1 As Double
'      Dim count_passes As Single
'      Dim glycolPercentage As Single
'      Dim EE, F, g, P, Z As Double
'      'Dim NF_2, TE_2, TC_2, Q_2, KW_2, GP_2, A_2, ER_2, W_2 As Double
'      'Dim Q2, GPM2, GP2, PD2, ER2 As Double
'      Dim specificGravity, specificHeat As Single
'      Dim coolingMedia As String
'      Dim isGlycolSelected As Boolean
'      count_passes = 1

'      '********** set variable values ********************
'      If Running_Circuit_no = 1 Then
'         gCompressorQuantity = Val(txtNumCompressors1.Text())
'         gNumberOfFans = Val(txtNumFans1.Text()) * Val(txtNumCoils1.Text())
'         gCondenserCapacity = Val(txtCondenserCapacity1.Text)
'         If rad6To8Approach.Checked = True Then
'            Q8 = Val(txtCapacityAt6FApproach.Text())
'            Q9 = Val(txtCapacityAt8FApproach.Text())
'         ElseIf rad7To9Approach.Checked = True Then
'            Q8 = Val(txtCapacityAt7FApproach.Text())
'            Q9 = Val(txtCapacityAt9FApproach.Text())
'         ElseIf rad8To10Approach.Checked = True Then
'            Q8 = Val(txtCapacityAt8FApproach.Text())
'            Q9 = Val(txtCapacityAt10FApproach.Text())
'         ElseIf rad9To11Approach.Checked = True Then
'            Q8 = Val(txtCapacityAt9FApproach.Text())
'            Q9 = Val(txtCapacityAt11FApproach.Text())
'         ElseIf rad10To12Approach.Checked = True Then
'            Q8 = Val(txtCapacityAt10FApproach.Text())
'            Q9 = Val(txtCapacityAt12FApproach.Text())
'         ElseIf radOtherEvaporator.Checked = True Then
'            Q8 = Val(tbxEvap8Degr1.Text())
'            Q9 = Val(tbxEvap10Degr1.Text())
'         End If
'      ElseIf Running_Circuit_no = 2 Then
'         gCompressorQuantity = Val(txtNumCompressors2.Text())
'         gNumberOfFans = Val(txtNumFans2.Text()) * Val(txtNumCoils2.Text())
'         gCondenserCapacity = Val(txtCondenserCapacity2.Text)
'         If rad6To8Approach.Checked = True Then
'            Q8 = Val(txtCapacityAt6FApproach.Text())
'            Q9 = Val(txtCapacityAt8FApproach.Text())
'         ElseIf rad7To9Approach.Checked = True Then
'            Q8 = Val(txtCapacityAt7FApproach.Text())
'            Q9 = Val(txtCapacityAt9FApproach.Text())
'         ElseIf rad8To10Approach.Checked = True Then
'            Q8 = Val(txtCapacityAt8FApproach.Text())
'            Q9 = Val(txtCapacityAt10FApproach.Text())
'         ElseIf rad9To11Approach.Checked = True Then
'            Q8 = Val(txtCapacityAt9FApproach.Text())
'            Q9 = Val(txtCapacityAt11FApproach.Text())
'         ElseIf rad10To12Approach.Checked = True Then
'            Q8 = Val(txtCapacityAt10FApproach.Text())
'            Q9 = Val(txtCapacityAt12FApproach.Text())
'         ElseIf radOtherEvaporator.Checked = True Then
'            Q8 = Val(tbxEvap8Degr2.Text())
'            Q9 = Val(tbxEvap10Degr2.Text())
'         End If
'      End If
'      gTemperatureRange = Val(txtTempRange.Text())
'      gVolts = Val(cboVolts.SelectedItem)  'set at 230
'      gRef = Refrigerant.Name 'Trim(cboRefrigerant.SelectedItem.ValueName)
'      'multiplying factors for compressors
'      gMF1 = 1
'      gMF2 = 1
'      gMF3 = 1
'      If chkCatalogRating.Checked = True Then
'         gCatalogRating = vbYes
'      Else
'         gCatalogRating = vbNo
'      End If

'      Hertz2 = 1
'      Hertz21 = 1
'      Hertz3 = 1
'      Hertz4 = 1

'      Dim TE1, TE2 As Double
'      Dim T3 As Integer = EnteringFluidTemp
'      Dim compressorModel, compressorFile
'      Dim C0, C11, C2, C3, C4 As Double
'      Dim W0, W1, W2, W3, W4 As Double
'      Dim A0, A1, A2, A3, A4 As Double              'COMPRESSOR INPUTS
'      Dim coefficients As CompressorCoefficients5
'      Dim c As CompressorCoefficients10
'      Dim T1 As Double
'      'Dim NT As Double 'Integer
'      'Dim cond As Rae.RaeSolutions.CondenserCoefficients
'      'Dim CC As Double
'      Dim PD As Double
'      Dim X As Integer
'      Dim T2 As Double
'      Dim NC As Integer = CInt(Txt_circuit_per_unit.Text)
'      Dim gTD As Integer
'      Dim alWT As ArrayList = GetWTs()
'      TE1 = alWT(0)
'      TE2 = alWT(1)
'      'TE1 = Me.EvapTemp - 4 'CInt(txtTempRange.Text)
'      'TE2 = Me.EvapTemp + 4 'CInt(txtTempRange.Text)
'      TW1 = Me.LeavingFluidTemp - 4 ' - 10 'CInt(txtTempRange.Text) ' LOWEST LVG H20 TEMP(OD COMPRESSORS)
'      TW2 = Me.LeavingFluidTemp + 4 'Me.EnteringFluidTemp + CInt(txtTempRange.Text)

'      If Me.txtCompressor1.Text = "" Or Me.txtCompressor1.Text = "Choose" Then
'         Me.lblErro.Text = lblErro.Text & "Make a valid compressor selection, INVALID COMPRESSOR"
'         Exit Sub
'      End If

'      If Trim(Me.cboFluid.SelectedItem) <> "Water" Then
'         If Trim(Me.cboFluid.SelectedItem) = "Glycol" Then
'            isGlycolSelected = True
'            coolingMedia = Trim(cboCoolingMedia.SelectedItem) 'value
'            If coolingMedia = "Ethylene" Then
'               coolingMedia = "ETHYLENE GLYCOL"
'            ElseIf coolingMedia = "Propylene" Then
'               coolingMedia = "PROPYLENE GLYCOL"
'            End If
'            glycolPercentage = Single.Parse(Me.txtGlycolPercentage.Text)
'            If glycolPercentage = 0 Then
'               lblErro.Text() = lblErro.Text() & "ENTER PERCENTAGE OF GLYCOL (IE 20%, 30%. ETC), ENTER PERCENTAGE GLYCOL"
'               Exit_Glycol = True : Exit Sub
'            End If
'            specificHeat = Val(txtSpecificHeat.Text())
'            If specificHeat = 0 Then
'               lblErro.Text() = lblErro.Text() & "ENTER GLYCOL SPECIFIC HEAT ENTER GLYCOL SPECIFIC HEAT"
'               Exit_Glycol = True : Exit Sub
'            End If
'            specificGravity = Val(txtSpecificGravity.Text)
'            If specificGravity = 0 Then
'               lblErro.Text() = lblErro.Text() & "ENTER GLYCOL SPECIFIC GRAVITY ENTER GLYCOL SPECIFIC GRAVITY"
'               Exit_Glycol = True : Exit Sub
'            End If

'            GPMFACT = 500 * specificHeat * specificGravity * gTemperatureRange
'            gSubCoolingTemp = Val(txtSubCooling.Text)
'            Me.subCoolingFactor = (gSubCoolingTemp * 0.005) + 1
'         Else
'            BAD_FLUID_TYPE = True
'            lblErro.Text() = lblErro.Text() & "Enter a valid fluid type"
'            Exit Sub
'         End If
'      Else
'         isGlycolSelected = False
'         gSubCoolingTemp = Val(txtSubCooling.Text)
'         Me.subCoolingFactor = (gSubCoolingTemp * 0.005) + 1
'         coolingMedia = "WATER"
'         specificHeat = 1.0! : specificGravity = 1.0!
'         glycolPercentage = 100
'      End If

'      Dim M As Double '= (25 + cboDischargeLineLoss.SelectedItem) / gCondenserCapacity

'      '-------------------------------------------------------






'      If Running_Circuit_no = 1 Then
'         compressorModel = Trim(Me.txtCompressor1.Text)
'         NT = CInt(Me.txtNumCoils1.Text) ' / Val(Me.Txt_circuit_per_unit.Text)
'         'CC = CDbl(Me.txtCondenserCapacity1.Text)
'         cond = CType(cboCondenser1.SelectedItem, Business.Entities.WCCondenser)
'         GP = cond.GP
'         CC = cond.Capacity * NT
'         compressorFile = DataAccess.CompressorDataAccess.RetrieveCompressor2(compressorModel, Me.Refrigerant.Name.Replace("R", "")).Rows(0)("CompFile").ToString
'         Me.ToolTip1.SetToolTip(Me.txtCompressor1, compressorFile)
'         gTD = CInt(Me.txtCondenserTD1.Text)
'      ElseIf Running_Circuit_no = 2 Then
'         compressorModel = Trim(Me.txtCompressor2.Text)
'         NT = CInt(Me.txtNumCoils2.Text) ' / Val(Me.Txt_circuit_per_unit.Text)
'         'CC = CDbl(Me.txtCondenserCapacity2.Text)
'         cond = CType(cboCondenser2.SelectedItem, Business.Entities.WCCondenser)
'         GP = cond.GP
'         compressorFile = DataAccess.CompressorDataAccess.RetrieveCompressor2(compressorModel, Me.Refrigerant.Name.Replace("R", "")).Rows(0)("CompFile").ToString
'         CC = cond.Capacity * NT '* Val(TXT_CCXF.Text)
'         Me.ToolTip1.SetToolTip(Me.txtCompressor2, compressorFile)
'         gTD = CInt(Me.txtCondenserTD2.Text)
'      End If

'      If Me.chkNewCoefficients.Checked Then
'         c = DataAccess.CompressorDataAccess.RetrieveCompressorCoefficients10(compressorFile)
'         'If c Is Nothing Then Exit Sub
'      Else
'         ' retrieves compressor coefficients
'         coefficients = DataAccess.CompressorDataAccess.RetrieveCompressorCoefficients(compressorFile)
'         With coefficients
'            ' sets compressor coefficients
'            C0 = .capacity0 : C11 = .capacity1 : C2 = .capacity2 : C3 = .capacity3 : C4 = .capacity4
'            W0 = .watt0 : W1 = .watt1 : W2 = .watt2 : W3 = .watt3 : W4 = .watt4
'            A0 = .amp0 : A1 = .amp1 : A2 = .amp2 : A3 = .amp3 : A4 = .amp4
'         End With
'      End If

'      If Refrigerant.Type = Engineering.RefrigerantType.R507a Then
'         gMF1 = 1.03
'         gMF2 = 1.02
'      ElseIf Refrigerant.Type = Engineering.RefrigerantType.R407c Then
'         gMF1 = 0.96
'         gMF2 = 1.03
'      End If

'      For T1 = T3 To T3 Step 5
'         M = (20 + cboDischargeLineLoss.SelectedItem) / CC 'M = 25 / CC
'         For TE = TE1 To TE2 Step 15
'            'TC = Rae.Engineering.Utility.GetTC(T1, TE, Compressor, 1, Refrigerant, 60, False, M, gTD)
'            Do_Calc(T1, gTD, M, compressorFile)
'            If TE = TE2 Then GoTo A_Call_1
'            Q1 = Q
'         Next TE
'A_Call_1:
'         A = (Q - Q1) / 15
'         B = TE - (Q / A)
'         M1 = (TE - B) / Q

'         For TW = TW1 To TW2 Step 2

'TW_Call:
'            If TW > TW2 Then GoTo End_Print1
'            TE = TW - 10
'            Dim Ex As Double = (Q9 - Q8) / 2
'            F = TE + (Q9 / Ex)
'            g = (TE - F) / Q9
'            TE = Round(((B * g) - (F * M1)) / (g - M1), 1)

'            Do_Calc(T1, gTD, M, compressorFile)

'            'Catalog rating...
'            If Me.chkCatalogRating.Checked = True Then Q = Q * 1.04

'            Q = Q / 12000

'            'Subcooling...
'            Q = Q * Me.subCoolingFactor



'            'Recalculate H2...
'            H2 = (Q * 12000) + (3.415 * W)


'            GP = H2 / (500 * gTD * Val(Me.txtSpecificHeat.Text) * Val(Me.txtSpecificGravity.Text))
'            GP = GP / NT
'            PD = (cond.B5 + cond.B6 * GP ^ 4 + cond.B7 * GP ^ 3 + cond.B8 * GP ^ 2 + cond.B9 * GP)
'            GP = GP * NT

'            W = W / 1000




'            ER = Q * 12 / W
'            T2 = T1 + gTD
'            GPM = (Q * 12000) / (Val(Me.txtSpecificHeat.Text) * Val(Me.txtSpecificGravity.Text) * Val(Me.txtTempRange.Text) * 500)


'            ''Subcooling...
'            'Q = Q * Me.subCoolingFactor



'            ''Recalculate H2...
'            'H2 = (Q * 12000) + (3.415 * W)
'            '' PD = (cond.B5 + cond.B6 * GP ^ 4 + cond.B7 * GP ^ 3 + cond.B8 * GP ^ 2 + cond.B9 * GP)

'            'GP = H2 / (500 * gTD * Val(Me.txtSpecificHeat.Text) * Val(Me.txtSpecificGravity.Text))
'            'GP = GP / NT
'            'PD = (cond.B5 + cond.B6 * GP ^ 4 + cond.B7 * GP ^ 3 + cond.B8 * GP ^ 2 + cond.B9 * GP)
'            'GP = GP * NT

'            'W = W / 1000
'            ''ER = Q * 12000 / W
'            ''ER = W / Q

'            ''W = W / 1000
'            'ER = Q * 12 / W
'            'T2 = T1 + gTD
'            'GPM = (Q * 12000) / (Val(Me.txtSpecificHeat.Text) * Val(Me.txtSpecificGravity.Text) * Val(Me.txtTempRange.Text) * 500)


'            Dim dr As DataRow = dtb.NewRow
'            dr("TW") = TW
'            dr("T1") = T1
'            dr("T2") = T2
'            dr("TE") = TE
'            dr("TC") = TC
'            dr("Q") = Q
'            dr("GPM") = GPM
'            dr("W") = W
'            dr("GP") = GP
'            dr("PD") = PD
'            dr("ER") = ER
'            dtb.Rows.Add(dr)

'            'If cboSystem.SelectedItem = "FULL" And Val(Txt_circuit_per_unit.Text()) = 2 Or Val(Txt_circuit_per_unit.Text()) = 4 Then
'            '    If Running_Circuit_no = 1 Then
'            '        Q2 = Q
'            '        GPM2 = GPM
'            '        W2 = W
'            '        GP2 = GP
'            '        PD2 = PD
'            '        ER2 = ER
'            '    Else
'            '        cd.InsertResults2(TW, T1, T2, TE, TC, Q + Q2, GPM + GPM2, W + W2, GP + GP2, System.Math.Round((PD + PD2) / 2, 2), System.Math.Round((ER + ER2) / 2, 2))
'            '    End If
'            'Else
'            '    cd.InsertResults2(TW, T1, T2, TE, TC, Q, GPM, W, GP, PD, ER)
'            'End If


'            If TW = 44 Then
'               TW = 45
'               GoTo TW_Call
'            End If

'            If TW = 45 Then
'               TW = 44
'            End If
'         Next TW

'         'cd.InsertBlankRowInResults2()
'      Next T1
'End_Print1:

'      'stores values from first of 2 circuits in myarrayprint3
'      'so that they can be retrieved after 2nd circuit is calculated
'1000: If cboSystem.SelectedItem() = "FULL" And Val(Txt_circuit_per_unit.Text()) = 2 _
'  Or Val(Txt_circuit_per_unit.Text()) = 4 Then
'         If ok_to_print = False Then
'            Me.FillDropDownList3()
'            GoTo Skip_Print_or_Cal
'         End If
'      End If

'      If cboSystem.SelectedItem() = "FULL" And Val(Txt_circuit_per_unit.Text()) = 2 Or Val(Txt_circuit_per_unit.Text()) = 4 Then
'         DropDownList2.DataSource = myarrayprint2
'         '-------------------
'         Dim TW_1, T1_1, T2_1, TE_1, TC_1, Q_1, GPM_1, W_1, GP_1, PD_1, ER_1, TW_2, T1_2, T2_2, TE_2, TC_2, Q_2, GPM_2, W_2, GP_2, PD_2, ER_2 As Double
'         Dim dv As DataView = dtb.DefaultView
'         dv.Sort = "TW asc"
'         Dim _tw As Integer = 0
'         For i As Integer = 0 To dv.Count - 1
'            If dv.Item(i).Row("TW") = _tw Then 'add record
'               TW_2 = Val(dv.Item(i).Row("TW"))
'               T1_2 = Val(dv.Item(i).Row("T1"))
'               T2_2 = Val(dv.Item(i).Row("T2"))
'               TE_2 = Val(dv.Item(i).Row("TE"))
'               TC_2 = Val(dv.Item(i).Row("TC"))
'               Q_2 = Val(dv.Item(i).Row("Q"))
'               GPM_2 = Val(dv.Item(i).Row("GPM"))
'               W_2 = Val(dv.Item(i).Row("W"))
'               GP_2 = Val(dv.Item(i).Row("GP"))
'               PD_2 = Val(dv.Item(i).Row("PD"))
'               ER_2 = Val(dv.Item(i).Row("ER"))
'               cd.InsertResults2(TW_2, T1_2, T2_2, TE_2, TC_2, Q_1 + Q_2, GPM_1 + GPM_2, W_1 + W_2, GP_1 + GP_2, System.Math.Round((PD_1 + PD_2) / 2, 2), System.Math.Round((ER_1 + ER_2) / 2, 2))
'               'cd.InsertBlankRowInResults2()
'            Else 'new record
'               TW_2 = 0
'               T1_2 = 0
'               T2_2 = 0
'               TE_2 = 0
'               TC_2 = 0
'               Q_2 = 0
'               GPM_2 = 0
'               W_2 = 0
'               GP_2 = 0
'               PD_2 = 0
'               ER_2 = 0
'               TW_1 = Val(dv.Item(i).Row("TW"))
'               T1_1 = Val(dv.Item(i).Row("T1"))
'               T2_1 = Val(dv.Item(i).Row("T2"))
'               TE_1 = Val(dv.Item(i).Row("TE"))
'               TC_1 = Val(dv.Item(i).Row("TC"))
'               Q_1 = Val(dv.Item(i).Row("Q"))
'               GPM_1 = Val(dv.Item(i).Row("GPM"))
'               W_1 = Val(dv.Item(i).Row("W"))
'               GP_1 = Val(dv.Item(i).Row("GP"))
'               PD_1 = Val(dv.Item(i).Row("PD"))
'               ER_1 = Val(dv.Item(i).Row("ER"))
'               _tw = TW_1
'            End If

'         Next
'         '----------------
'      Else
'         '-------------------
'         For Each dr As DataRow In dtb.Rows
'            cd.InsertResults2(Val(dr("TW")), Val(dr("T1")), Val(dr("T2")), Val(dr("TE")), Val(dr("TC")), Val(dr("Q")), Val(dr("GPM")), Val(dr("W")), Val(dr("GP")), Val(dr("PD")), Val(dr("ER")))
'            'cd.InsertBlankRowInResults2()
'         Next
'         '----------------
'      End If
'      DropDownList1.DataSource = myarrayprint


'      FillDatagrid(cd.dt) 'fill datagrid

'Skip_Print_or_Cal:
'      If cboSafetyOverride.Checked = True Then
'         If lblOperLimi.Visible = True Then
'            lblOperLimi.Text() = "Compressor Safety Over Ride ON >> points outside operating limits."
'         End If
'      End If

'      'delete Circuit 1 database
'      If cboSystem.SelectedItem() = "FULL" And Val(Txt_circuit_per_unit.Text) = 2 _
'            Or Val(Txt_circuit_per_unit.Text) = 4 Then
'         'if ok_to_print = false and if statement above is true then
'         'this CalculatePage() is calculating circuit 1 of 2
'         If ok_to_print = False Then
'            'Delete Circuit 1 database. If there are multiple circuits,
'            'it is never filled or used; only circuit 2 database is used.
'            'Dim dbPath As String = AppInfo.AppFolderPath & "Reports\" & gMyFileNameMDB
'            'Common.IO.DeleteFile(dbPath)
'            cd.Reset()

'         End If
'      End If
'   End Sub

'   Private Sub Do_Calc(ByVal T1 As Integer, ByVal gtd As Integer, ByVal M As Double, ByVal compressorfile As String)
'      Dim C0, C11, C2, C3, C4 As Double
'      Dim W0, W1, W2, W3, W4 As Double
'      Dim A0, A1, A2, A3, A4 As Double              'COMPRESSOR INPUTS
'      Dim coefficients As CompressorCoefficients5
'      Dim c As CompressorCoefficients10
'      If Me.chkNewCoefficients.Checked Then
'         c = DataAccess.CompressorDataAccess.RetrieveCompressorCoefficients10(compressorfile)
'         'If c Is Nothing Then Exit Sub
'      Else
'         ' retrieves compressor coefficients
'         coefficients = DataAccess.CompressorDataAccess.RetrieveCompressorCoefficients(compressorfile)
'         With coefficients
'            ' sets compressor coefficients
'            C0 = .capacity0 : C11 = .capacity1 : C2 = .capacity2 : C3 = .capacity3 : C4 = .capacity4
'            W0 = .watt0 : W1 = .watt1 : W2 = .watt2 : W3 = .watt3 : W4 = .watt4
'            A0 = .amp0 : A1 = .amp1 : A2 = .amp2 : A3 = .amp3 : A4 = .amp4
'         End With
'      End If

'      PE = Refrigerant.GetEvapPressure(TE)
'      TC = T1 + gtd

'      Dim z As Integer = 1 : GoTo SET_H1

'ADD_TC_10:
'      TC = TC + 10
'      GoTo SET_H1
'ADD_TC_5:
'      TC = TC + 5
'      GoTo SET_H1
'ADD_TC_1:
'      TC = TC + 1
'      GoTo SET_H1
'ADD_TC_p2:
'      TC = TC + 0.2
'      GoTo SET_H1



'SET_H1:
'      H1 = (TC - T1) / (20 / CC) 'M

'      PC = Refrigerant.GetCondenserPressure(TC)

'      If Me.chkNewCoefficients.Checked Then
'         Q = c.capacity0 + c.capacity1 * (TE) + c.capacity2 * TC + c.capacity3 * (TE ^ 2) + c.capacity4 * (TE * TC) + c.capacity5 * (TC ^ 2) + c.capacity6 * (TE ^ 3) + c.capacity7 * (TC * TE ^ 2) + c.capacity8 * (TE * TC ^ 2) + c.capacity9 * (TC ^ 3) * gCompressorQuantity
'         A = c.amp0 + c.amp1 * (TE) + c.amp2 * TC + c.amp3 * (TE ^ 2) + c.amp4 * (TE * TC) + c.amp5 * (TC ^ 2) + c.amp6 * (TE ^ 3) + c.amp7 * (TC * TE ^ 2) + c.amp8 * (TE * TC ^ 2) + c.amp9 * (TC ^ 3) * gCompressorQuantity
'         W = c.watt0 + c.watt1 * (TE) + c.watt2 * TC + c.watt3 * (TE ^ 2) + c.watt4 * (TE * TC) + c.watt5 * (TC ^ 2) + c.watt6 * (TE ^ 3) + c.watt7 * (TC * TE ^ 2) + c.watt8 * (TE * TC ^ 2) + c.watt9 * (TC ^ 3) * gCompressorQuantity
'      Else
'         Q = (C0 + (C11 * TC) + (C2 * PE) + ((C3 * PE) * PC) + (C4 * PC) / Sqrt(PE)) _
'            * gCompressorQuantity * Hertz2 * gMF1
'         W = (W0 + (W1 * TC) + (W2 * PE) + ((W3 * PE) * PC) + (W4 * PC) / Sqrt(PE)) _
'            * gCompressorQuantity * Hertz21 * gMF2
'         A = (A0 + (A1 * TC) + (A2 * PE) + ((A3 * PE) * PC) + (A4 * PC) / Sqrt(PE)) _
'            * gCompressorQuantity * Hertz3 * gMF2
'      End If

'      Dim compressorCapacityFactor, compressorWattFactor, compressorAmpFactor As Double
'      compressorCapacityFactor = ConvertNull.ToDouble(compressorCapacityFactorTextBox.Text)
'      compressorWattFactor = ConvertNull.ToDouble(compressorKwFactorTextBox.Text)
'      compressorAmpFactor = ConvertNull.ToDouble(compressorAmpFactorTextBox.Text)
'      Q *= compressorCapacityFactor
'      W *= compressorWattFactor
'      A *= compressorAmpFactor

'      H2 = Q + (3.415 * W)
'      If Running_Circuit_no = 1 Then
'         NT = CInt(Me.txtNumCoils1.Text)
'      ElseIf Running_Circuit_no = 2 Then
'         NT = CInt(Me.txtNumCoils2.Text)
'      End If
'      GP = H2 / (500 * gtd * Val(Me.txtSpecificHeat.Text) * Val(Me.txtSpecificGravity.Text))
'      CC = (cond.B0 + cond.B1 * GP ^ 4 + cond.B2 * GP ^ 3 + cond.B3 * GP ^ 2 + cond.B4 * GP) * NT

'      Dim condenserCapacityFactor As Double
'      condenserCapacityFactor = ConvertNull.ToDouble(condenserCapacityFactorTextBox.Text.Trim)
'      CC *= condenserCapacityFactor

'      If H1 = H2 * 1.01 Then
'         H1 = H2
'      Else
'         If z = 1 Then GoTo SS920
'         If z = 2 Then GoTo SS940
'         If z = 3 Then GoTo SS960
'         If z = 4 Then GoTo SS980

'SS920:   If H1 < H2 Then GoTo ADD_TC_10
'         TC = TC - 10 : z = 2 : GoTo ADD_TC_5
'SS940:   If H1 < H2 Then GoTo ADD_TC_5
'         TC = TC - 5 : z = 3 : GoTo ADD_TC_1
'SS960:   If H1 < H2 Then GoTo ADD_TC_1
'         TC = TC - 1 : z = 4 : GoTo ADD_TC_p2


'SS980:   If H1 < H2 Then GoTo ADD_TC_p2
'      End If
'   End Sub



'   ''' <summary>Inserts results
'   ''' </summary>
'   ''' <param name="leavingFluidTemperature"></param>
'   ''' <param name="ambientTemperature"></param>
'   ''' <param name="evaporatingTemperature"></param>
'   ''' <param name="condensingTemperature"></param>
'   ''' <param name="capacity"></param>
'   ''' <param name="kilowatts"></param>
'   ''' <param name="gpm"></param>
'   ''' <param name="amps"></param>
'   ''' <param name="er"></param>
'   ''' <param name="ez"></param>
'   ''' <remarks>
'   ''' </remarks>
'   ''' <history>[CASEYJ]	6/13/2005	Created
'   ''' </history>
'   'Public Shared Sub InsertResults( _
'   'ByVal dbPath As String, _
'   'ByVal leavingFluidTemperature As Single, _
'   'ByVal ambientTemperature As Single, _
'   'ByVal evaporatingTemperature As Single, _
'   'ByVal condensingTemperature As Single, _
'   'ByVal capacity As Single, _
'   'ByVal kilowatts As Single, _
'   'ByVal gpm As Single, _
'   'ByVal amps As Single, _
'   'ByVal er As Single, _
'   'ByVal ez As Single)
'   '   Dim connectionString As String
'   '   Dim sqlInsert As System.Text.StringBuilder
'   '   Dim conResults As OleDb.OleDbConnection
'   '   Dim comResults As OleDb.OleDbCommand

'   '   sqlInsert = New System.Text.StringBuilder

'   '   'gets connection string for db path
'   '   connectionString = DataAccess.Common.GetConnectionString(dbPath)

'   '   'builds insert sql command
'   '   sqlInsert.Append("INSERT INTO CALULATIONS ")
'   '   sqlInsert.Append("([TW], [TA], [TE], [TC], [Q], [KW], [GP], [A], [ER], [EZ]) Values ")
'   '   sqlInsert.AppendFormat( _
'   '      "('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')", _
'   '      Format(leavingFluidTemperature, "###"), _
'   '      Format(ambientTemperature, "###"), _
'   '      Format(evaporatingTemperature, "##.0"), _
'   '      Format(condensingTemperature, "###.0"), _
'   '      Format(capacity, "###.0"), _
'   '      Format(kilowatts, "####.0"), _
'   '      Format(gpm, "####.0"), _
'   '      Format(amps, "###.#0"), _
'   '      Format(er, "####.0"), _
'   '      Format(ez, "####.0"))

'   '   conResults = New OleDb.OleDbConnection(connectionString)
'   '   Try
'   '      conResults.Open()
'   '      comResults = New OleDb.OleDbCommand(sqlInsert.ToString, conResults)
'   '      comResults.ExecuteNonQuery()
'   '   Catch dbEx As OleDb.OleDbException
'   '      Dim message As String
'   '      message = "An exception occurred while attempting to fill temporary " & _
'   '         "results database." & Environment.NewLine & dbEx.Message
'   '      Ui.MessageBox.Show(message)
'   '   Finally
'   '      If conResults.State <> ConnectionState.Closed Then conResults.Close()
'   '   End Try
'   'End Sub


'   'fills dropdown control with values in an array
'   'so that the values can be used later to help
'   'fill the datagrid
'   'this was causing annoying problems before
'   Private Sub FillDropDownList3()
'      Dim i As Integer
'      'set datasource to nothing so that old items in
'      'dropdown can be editted (removed); dropdown items
'      'can not be removed if dropdown is set to datasource
'      Me.DropDownList3.DataSource = Nothing

'      'remove old items in dropdown control so that
'      'the new items will be added at the beginning
'      If Me.DropDownList3.Items.Count > 0 Then
'         For i = DropDownList3.Items.Count - 1 To 0 Step -1
'            Me.DropDownList3.Items.RemoveAt(i)
'         Next
'      End If
'      'add items in array to dropdown control
'      For i = 0 To myarrayprint3.Count - 1
'         Me.DropDownList3.Items.Add(myarrayprint3.Item(i))
'      Next
'   End Sub


'   'fill datagrid
'   'only called once (in CalculatePage)
'   Private Sub FillDatagrid(ByVal resultsTable As DataTable)
'      'Dim temp_connection_name As String = AppInfo.AppFolderPath & "Reports\" & gMyFileNameMDB          'UNSURE: 2?
'      ' retrieves results
'      'Dim resultsTable As DataTable = DataAccess.Chillers.Chiller.RetrieveChillerResults(temp_connection_name)
'      ' fills grid with results
'      Me.dgrC1Results.DataSource = resultsTable
'      ' formats grid
'      Me.FormatResultsGrid()

'      'why is gMyFileNameMDB being set again
'      'gMyFileNameMDB = PASS_FILENAME
'   End Sub


'   Private Sub FormatResultsGrid()

'      Rae.Ui.C1GridStyles.BasicGridStyle(Me.dgrC1Results)

'      With Me.dgrC1Results.Splits(0)
'         ' sets column properties
'         .ColumnCaptionHeight = 36
'         .HeadingStyle.BackColor = ColorManager.LightBlue

'         .OddRowStyle.BackColor = ColorManager.LighterBlue
'         .Style.Borders.Color = ColorManager.GreyBlue
'         For i As Integer = 0 To .DisplayColumns.Count - 1
'            .DisplayColumns(i).ColumnDivider.Color = ColorManager.GreyBlue
'         Next

'         .DisplayColumns("TW").Width = 65
'         .DisplayColumns("TW").DataColumn.Caption = "Evap. LWT" & vbCrLf & "[°F]"
'         .DisplayColumns("CE").Width = 65
'         .DisplayColumns("CE").DataColumn.Caption = "Cond. EWT" & vbCrLf & "[°F]"
'         .DisplayColumns("CL").Width = 65
'         .DisplayColumns("CL").DataColumn.Caption = "Cond. LWT" & vbCrLf & "[°F]"
'         .DisplayColumns("TE").Width = 65
'         .DisplayColumns("TE").DataColumn.Caption = "Evap. Temp." & vbCrLf & "[°F]"
'         .DisplayColumns("TC").Width = 65
'         .DisplayColumns("TC").DataColumn.Caption = "Cond. Temp." & vbCrLf & "[°F]"
'         .DisplayColumns("Q").Width = 65
'         .DisplayColumns("Q").DataColumn.Caption = "Capacity" & vbCrLf & "[Tons]"
'         .DisplayColumns("GPM").Width = 45
'         .DisplayColumns("GPM").DataColumn.Caption = "EVAP. GPM"
'         .DisplayColumns("KW").Width = 45
'         .DisplayColumns("KW").DataColumn.Caption = "Comp. [KW]"
'         .DisplayColumns("GP").Width = 45
'         .DisplayColumns("GP").DataColumn.Caption = "COND. GPM"
'         .DisplayColumns("PD").Width = 55
'         .DisplayColumns("PD").DataColumn.Caption = "COND. PD"
'         .DisplayColumns("ER").Width = 55
'         .DisplayColumns("ER").DataColumn.Caption = "EER"
'      End With
'   End Sub


'   Private Sub StartCalculations()
'      ok_to_print_SPACE = False
'      dtb = New DataTable
'      dtb.Columns.Add("TW")
'      dtb.Columns.Add("T1")
'      dtb.Columns.Add("T2")
'      dtb.Columns.Add("TE")
'      dtb.Columns.Add("TC")
'      dtb.Columns.Add("Q")
'      dtb.Columns.Add("GPM")
'      dtb.Columns.Add("W")
'      dtb.Columns.Add("GP")
'      dtb.Columns.Add("PD")
'      dtb.Columns.Add("ER")

'      ChangeCoilDescription()
'      'Page_Cal_Pass = 1
'run_Second_pass:
'      myarrayprint.Clear()
'      myarrayprint2.Clear()
'      ''' <history>Added by Casey Joyce</history>
'      ''' <summary>myarrayprint3 was never cleared; if calculate page is clicked more than once, 
'      ''' the array just gets bigger and only the beginning indices are ever used which is incorrect</summary>
'      myarrayprint3.Clear()

'      'okay to print
'      If cboSystem.SelectedItem = "FULL" And Val(Txt_circuit_per_unit.Text()) = 2 Or Val(Txt_circuit_per_unit.Text()) = 4 Then
'         ok_to_print = False
'         Running_Circuit_no = 1
'         CalculatePage()

'         ok_to_print = True
'         ok_to_print_SPACE = True
'         Running_Circuit_no = 2
'         CalculatePage()
'      ElseIf cboSystem.SelectedItem = "FULL" And Val(Txt_circuit_per_unit.Text()) = 1 Then
'         ok_to_print_SPACE = True
'         Running_Circuit_no = 1
'         CalculatePage()
'      ElseIf cboSystem.SelectedItem = "HALF" Then
'         If radCircuit1.Checked = True Then
'            Running_Circuit_no = 1
'         ElseIf radCircuit2.Checked = True Then
'            ok_to_print_SPACE = True
'            Running_Circuit_no = 2
'         End If
'         CalculatePage()
'      End If
'   End Sub

'   'Set  Freeze Point  &  Suction Temperature
'   Private Sub CalculateFreezePoint()
'      ' grabs glycol percentage
'      Dim glycolPercentage As Double = CDbl(Me.txtGlycolPercentage.Text.Trim)

'      ' checks glycol percentage is in proper range
'      If BCI.FreezingPoint.IsGlycolPercentageOutsideRange(glycolPercentage) Then
'         Ui.MessageBox.Show("Glycol percentage must be in the range 0% to 60%; resetting glycol percentage to 20%.", _
'            MessageBoxIcon.Information)
'         ' resets glycol percentage to 20
'         Me.txtGlycolPercentage.Text = "20"
'         Exit Sub
'      End If

'      ' sets freezing point and suction temperature textboxes
'      If Me.cboFluid.SelectedItem = "Water" Then
'         ' sets freeze point textbox to water's freezing point
'         Me.txtFreezingPoint.Text = BCI.FreezingPoint.FreezingPointForWater.ToString
'         ' sets recommended minimum suction temperature textbox to water's recommended minimum suction temperature
'         Me.txtSuctionTemp.Text = BCI.FreezingPoint.RecommendedMinSuctionTemperatureForWater

'      Else
'         Dim glycol As Rae.Solutions.Chillers.Glycol
'         Dim freezingPoint As BCI.FreezingPoint

'         ' parses selected combobox item to glycol
'         glycol = DirectCast(glycol.Parse(GetType(Rae.Solutions.Chillers.Glycol), Me.cboCoolingMedia.SelectedItem.ToString), _
'            Rae.Solutions.Chillers.Glycol)

'         ' constructs new freezing point using selected glycol and glycol percentage
'         freezingPoint = New BCI.FreezingPoint(glycol, glycolPercentage)

'         ' sets freezing point textbox
'         Me.txtFreezingPoint.Text = Round(freezingPoint.FreezingPoint, 1).ToString
'         ' sets recommended minimum suction temperature textbox
'         Me.txtSuctionTemp.Text = Round(freezingPoint.RecommendedMinSuctionTemperature, 1).ToString
'      End If
'   End Sub



'   Public Shared Function RetrieveEvaporator(ByVal standardModel As String, ByVal numCircuitsPerUnit As Integer, _
'   ByVal length As Single, ByVal authorizationLevel As Integer) As String
'      Dim evaporatorModel As String

'      ' checks if evaporator model is valid
'      If Evaporator1.IsEvaporatorModelValid(standardModel) Then
'         ' retrieves evaporator model that matches parameters
'         evaporatorModel = DataAccess.Chillers.ChillerDataAccess.RetrieveEvaporator(standardModel, numCircuitsPerUnit, length, authorizationLevel)
'      End If

'      Return evaporatorModel
'   End Function



'   '****************************************************************
'   '** THREE FUNCTIONS DEPENDING ON NUMBER IN GLOBAL ChillyRAEs_pass_no
'   '** 1 - sets specific heat and specific gravity textboxes
'   '** 2 - fills combobox w/ evaporators
'   '** 3 - sets approach and evap capacity textboxes
'   '****************************************************************
'   'OLDERROR: Interfacing w/ RAEDLL_CONDENSING_UNIT.dll when 3 is passed to ChillyRAEs_pass_no
'   '****** ChillyRAE_Parms.RAE_out_#deg_pd always returns 0
'   '****** ChillyRAE_Parms.RAE_out_4FLOW always returns 0
'   'UPDATE:passing 3 now works w/ the same chillyrae.dll that the website is using,
'   '****** but not the new chillyrae.dll,
'   '****** the new dll probably has an error in it 9/2/2004
'   '****************************************************************
'   Sub ChillyRAE()
'      'If Me.cboModels.SelectedItem = "Choose" Then
'      '   Exit Sub
'      'End If
'      Dim standardModel As String
'      Dim ChillyRAE_Parms As New RAEDLL_CONDENSING_UNIT.Selection_Mod

'      Me.CalculateFreezePoint()

'      '1 <<<<<<<<<<<<<<<<<<<<<<<<
'      'get specific heat and gravity
'      If ChillyRAEs_pass_no = 1 Then
'         Try
'            ' gets standard model number based on evaporator part number
'            Dim evaporator = BCA.RetrieveChillerEvaporator(Me.GrabEvaporatorModel())
'            standardModel = evaporator.StandardModelNum
'         Catch ex As Exception
'            Dim message As String = "An exception occurred while attempting to retrieve the standard evaporator model. " & ex.Message
'            Ui.MessageBox.Show(message) : Exit Sub
'         End Try
'         With ChillyRAE_Parms
'            ' pass data
'            .RAE_ChillyRAEs_pass = 1        '1 = Parms    2 = Models    3 = 8&10 deg approach
'            .RAE_Fouling_Factor = CDbl(Me.cboFoulingFactor.SelectedItem)
'            .RAE_Cbo_Fluid = Me.cboFluid.SelectedItem.ToString
'            .RAE_tempin = Me.LeavingFluidTemp + VB.Val(txtTempRange.Text)
'            .RAE_tempot = Me.LeavingFluidTemp
'            .RAE_txtCondCap = Me.GrabSystemCapacityBtuh()
'            .RAE_cboRef_Text = Refrigerant.Type.ToString() '"R" & Trim(cboRefrigerant.SelectedItem.ValueName)
'            .RAE_cboCCM_Text = cboCoolingMedia.SelectedItem.ToString.Trim
'            .RAE_txtPctGly_Text = VB.Val(Me.txtGlycolPercentage.Text.Trim)
'            .RAE_conduc = 0
'            .RAE_visc = 0
'            .RAE_spht = VB.Val(Me.txtSpecificHeat.Text)
'            .RAE_allmod = "all"
'            .RAE_units = "U.S. UNIT"     'METRIC
'            .RAE_cbo_chillers_Text = standardModel 'Trim(TxtChiller.Text())
'            .RAE_txtSpGr = 0        'Val(Txtspgr.Text())
'            .AddToDatabase5()

'            'get data
'            Me.txtSpecificHeat.Text = .RAE_Out_txtSpHt_Text 'get specific heat         
'            Me.txtSpecificGravity.Text = .RAE_Out_txtSpGr_Text 'get specific gravity
'         End With

'         '2 <<<<<<<<<<<<<<<<<<<<<<<<
'         'fill combobox w/ evaporators
'      ElseIf ChillyRAEs_pass_no = 2 Then
'         Dim evaporatorModels As New ArrayList
'         Dim evaporatorModel As String
'         Dim numCircuitsPerUnit, authorization As Integer
'         Dim evaporatorLength As Single

'         With ChillyRAE_Parms
'            ' pass data
'            .RAE_ChillyRAEs_pass = 2        '1 = Parms    2 = Models    3 = 8&10 deg approach
'            .RAE_Fouling_Factor = Val(cboFoulingFactor.SelectedItem)
'            ' Glycol, Water
'            .RAE_Cbo_Fluid = cboFluid.SelectedItem
'            ' temperature in = leaving temperature + range
'            .RAE_tempin = Me.LeavingFluidTemp + VB.Val(Me.txtTempRange.Text)
'            ' temperature out = leaving temperature
'            .RAE_tempot = Me.LeavingFluidTemp
'            .RAE_txtCondCap = Me.GrabSystemCapacityBtuh()
'            ' refrigerant
'            .RAE_cboRef_Text = Refrigerant.Type.ToString() '"R" & Trim(cboRefrigerant.SelectedItem.ValueName)
'            ' cooling media - ethylene, propylene
'            .RAE_cboCCM_Text = Me.cboCoolingMedia.SelectedItem.ToString.Trim
'            ' percent glycol
'            .RAE_txtPctGly_Text = VB.Val(Me.txtGlycolPercentage.Text)

'            ' constants
'            ' conductivity
'            .RAE_conduc = 0
'            ' viscosity
'            .RAE_visc = 0
'            ' specific heat
'            .RAE_spht = 0
'            ' specific gravity
'            .RAE_txtSpGr = 0
'            .RAE_allmod = "all"
'            ' U.S. UNIT, METRIC
'            .RAE_units = "U.S. UNIT"
'            .RAE_cbo_chillers_Text = "all"
'            .AddToDatabase5()
'         End With

'         evaporatorModels.Add("Choose")
'         numCircuitsPerUnit = CInt(Me.Txt_circuit_per_unit.Text.Trim)
'         evaporatorLength = CSng(Me.txt_Evap_Length.Text.Trim)
'         authorization = AppInfo.User.AuthorityGroup

'         With ChillyRAE_Parms
'            evaporatorModel = Me.RetrieveEvaporator(.RAE_Out_cbo_chillers1, numCircuitsPerUnit, evaporatorLength, authorization)
'            If Not (evaporatorModel Is Nothing) AndAlso evaporatorModel.Length > 0 Then evaporatorModels.Add(evaporatorModel)

'            evaporatorModel = Me.RetrieveEvaporator(.RAE_Out_cbo_chillers2, numCircuitsPerUnit, evaporatorLength, authorization)
'            If Not (evaporatorModel Is Nothing) AndAlso evaporatorModel.Length > 0 Then _
'               evaporatorModels.Add(evaporatorModel)

'            evaporatorModel = Me.RetrieveEvaporator(.RAE_Out_cbo_chillers3, numCircuitsPerUnit, evaporatorLength, authorization)
'            If Not (evaporatorModel Is Nothing) AndAlso evaporatorModel.Length > 0 Then _
'               evaporatorModels.Add(evaporatorModel)

'            evaporatorModel = Me.RetrieveEvaporator(.RAE_Out_cbo_chillers4, numCircuitsPerUnit, evaporatorLength, authorization)
'            If Not (evaporatorModel Is Nothing) AndAlso evaporatorModel.Length > 0 Then _
'               evaporatorModels.Add(evaporatorModel)

'            evaporatorModel = Me.RetrieveEvaporator(.RAE_Out_cbo_chillers5, numCircuitsPerUnit, evaporatorLength, authorization)
'            If Not (evaporatorModel Is Nothing) AndAlso evaporatorModel.Length > 0 Then _
'               evaporatorModels.Add(evaporatorModel)

'            evaporatorModel = Me.RetrieveEvaporator(.RAE_Out_cbo_chillers6, numCircuitsPerUnit, evaporatorLength, authorization)
'            If Not (evaporatorModel Is Nothing) AndAlso evaporatorModel.Length > 0 Then _
'               evaporatorModels.Add(evaporatorModel)

'            evaporatorModel = Me.RetrieveEvaporator(.RAE_Out_cbo_chillers7, numCircuitsPerUnit, evaporatorLength, authorization)
'            If Not (evaporatorModel Is Nothing) AndAlso evaporatorModel.Length > 0 Then _
'               evaporatorModels.Add(evaporatorModel)

'            evaporatorModel = Me.RetrieveEvaporator(.RAE_Out_cbo_chillers8, numCircuitsPerUnit, evaporatorLength, authorization)
'            If Not (evaporatorModel Is Nothing) AndAlso evaporatorModel.Length > 0 Then _
'               evaporatorModels.Add(evaporatorModel)

'            evaporatorModel = Me.RetrieveEvaporator(.RAE_Out_cbo_chillers9, numCircuitsPerUnit, evaporatorLength, authorization)
'            If Not (evaporatorModel Is Nothing) AndAlso evaporatorModel.Length > 0 Then _
'               evaporatorModels.Add(evaporatorModel)

'            evaporatorModel = Me.RetrieveEvaporator(.RAE_Out_cbo_chillers10, numCircuitsPerUnit, evaporatorLength, authorization)
'            If Not (evaporatorModel Is Nothing) AndAlso evaporatorModel.Length > 0 Then _
'               evaporatorModels.Add(evaporatorModel)

'            evaporatorModel = Me.RetrieveEvaporator(.RAE_Out_cbo_chillers11, numCircuitsPerUnit, evaporatorLength, authorization)
'            If Not (evaporatorModel Is Nothing) AndAlso evaporatorModel.Length > 0 Then _
'               evaporatorModels.Add(evaporatorModel)

'            evaporatorModel = Me.RetrieveEvaporator(.RAE_Out_cbo_chillers12, numCircuitsPerUnit, evaporatorLength, authorization)
'            If Not (evaporatorModel Is Nothing) AndAlso evaporatorModel.Length > 0 Then _
'               evaporatorModels.Add(evaporatorModel)

'            evaporatorModel = Me.RetrieveEvaporator(.RAE_Out_cbo_chillers13, numCircuitsPerUnit, evaporatorLength, authorization)
'            If Not (evaporatorModel Is Nothing) AndAlso evaporatorModel.Length > 0 Then _
'               evaporatorModels.Add(evaporatorModel)

'            evaporatorModel = Me.RetrieveEvaporator(.RAE_Out_cbo_chillers14, numCircuitsPerUnit, evaporatorLength, authorization)
'            If Not (evaporatorModel Is Nothing) AndAlso evaporatorModel.Length > 0 Then _
'               evaporatorModels.Add(evaporatorModel)

'            evaporatorModel = Me.RetrieveEvaporator(.RAE_Out_cbo_chillers15, numCircuitsPerUnit, evaporatorLength, authorization)
'            If Not (evaporatorModel Is Nothing) AndAlso evaporatorModel.Length > 0 Then _
'               evaporatorModels.Add(evaporatorModel)

'            evaporatorModel = Me.RetrieveEvaporator(.RAE_Out_cbo_chillers16, numCircuitsPerUnit, evaporatorLength, authorization)
'            If Not (evaporatorModel Is Nothing) AndAlso evaporatorModel.Length > 0 Then _
'               evaporatorModels.Add(evaporatorModel)

'            evaporatorModel = Me.RetrieveEvaporator(.RAE_Out_cbo_chillers17, numCircuitsPerUnit, evaporatorLength, authorization)
'            If Not (evaporatorModel Is Nothing) AndAlso evaporatorModel.Length > 0 Then _
'               evaporatorModels.Add(evaporatorModel)

'            evaporatorModel = Me.RetrieveEvaporator(.RAE_Out_cbo_chillers18, numCircuitsPerUnit, evaporatorLength, authorization)
'            If Not (evaporatorModel Is Nothing) AndAlso evaporatorModel.Length > 0 Then _
'               evaporatorModels.Add(evaporatorModel)

'            evaporatorModel = Me.RetrieveEvaporator(.RAE_Out_cbo_chillers19, numCircuitsPerUnit, evaporatorLength, authorization)
'            If Not (evaporatorModel Is Nothing) AndAlso evaporatorModel.Length > 0 Then _
'               evaporatorModels.Add(evaporatorModel)

'            evaporatorModel = Me.RetrieveEvaporator(.RAE_Out_cbo_chillers20, numCircuitsPerUnit, evaporatorLength, authorization)
'            If Not (evaporatorModel Is Nothing) AndAlso evaporatorModel.Length > 0 Then _
'               evaporatorModels.Add(evaporatorModel)
'         End With

'         ' adds queried evaporators to combobox
'         Me.cboEvaporatorModel.DataSource = evaporatorModels

'         '3 <<<<<<<<<<<<<<<<<<<<<<<<<<         
'      ElseIf ChillyRAEs_pass_no = 3 Then
'         Dim circuitsPerUnit As Integer

'         Try
'            ' gets standard model number based on evaporator part number
'            standardModel = BCA.RetrieveChillerEvaporator(Me.GrabEvaporatorModel()).StandardModelNum
'         Catch ex As System.Exception
'            Dim message As String = "An exception occurred while attempting to retrieve the standard evaporator model. " & ex.Message
'            Ui.MessageBox.Show(message) : Exit Sub
'         End Try

'         circuitsPerUnit = CInt(Me.Txt_circuit_per_unit.Text.Trim)

'         With ChillyRAE_Parms
'            ' pass data
'            .RAE_ChillyRAEs_pass = 3
'            .RAE_Fouling_Factor = VB.Val(Me.cboFoulingFactor.SelectedItem)
'            .RAE_Cbo_Fluid = Me.cboFluid.SelectedItem
'            .RAE_tempin = Me.LeavingFluidTemp + VB.Val(Me.txtTempRange.Text)
'            .RAE_tempot = Me.LeavingFluidTemp
'            .RAE_txtCondCap = Me.GrabSystemCapacityBtuh()
'            .RAE_cboRef_Text = Refrigerant.Type.ToString() '"R" & Me.cboRefrigerant.SelectedItem.ValueName
'            .RAE_cboCCM_Text = Me.cboCoolingMedia.SelectedItem.ToString.Trim
'            .RAE_txtPctGly_Text = VB.Val(Me.txtGlycolPercentage.Text)
'            .RAE_conduc = 0
'            .RAE_visc = 0
'            .RAE_spht = VB.Val(Me.txtSpecificHeat.Text)
'            .RAE_allmod = "all"
'            .RAE_units = "U.S. UNIT"     'METRIC
'            .RAE_cbo_chillers_Text = standardModel
'            .RAE_txtSpGr = 0
'            .AddToDatabase5()

'            ' 4 Degree
'            If circuitsPerUnit = 4 Then
'               Me.txtCapacityAt4FApproach.Text = .RAE_Out_txt4DEG_Text / 2
'            Else
'               Me.txtCapacityAt4FApproach.Text = .RAE_Out_txt4DEG_Text / circuitsPerUnit
'            End If
'            PD_GPM(4, 1) = Round(.RAE_Out_4DEG_PD, 2)
'            PD_GPM(4, 2) = Round(.RAE_Out_4FLOW, 2)
'            Me.tbxEvap4.Text = "Fluid PD = " & Round(.RAE_Out_4DEG_PD, 2) & "   GPM = " & Round(.RAE_Out_4FLOW, 2)

'            '5 Degree
'            If circuitsPerUnit = 4 Then
'               Me.txtCapacityAt5FApproach.Text = .RAE_Out_txt5DEG_Text / 2
'            Else
'               Me.txtCapacityAt5FApproach.Text = .RAE_Out_txt5DEG_Text / circuitsPerUnit
'            End If
'            PD_GPM(5, 1) = Round(.RAE_Out_5DEG_PD, 2)
'            PD_GPM(5, 2) = Round(.RAE_Out_5FLOW, 2)
'            Me.tbxEvap5.Text = "Fluid PD = " & Round(.RAE_Out_5DEG_PD, 2) & "   GPM = " & Round(.RAE_Out_5FLOW, 2)

'            '6 Degree
'            If circuitsPerUnit = 4 Then
'               Me.txtCapacityAt6FApproach.Text = .RAE_Out_txt6DEG_Text / 2
'            Else
'               Me.txtCapacityAt6FApproach.Text = .RAE_Out_txt6DEG_Text / circuitsPerUnit
'            End If
'            PD_GPM(6, 1) = Round(.RAE_Out_6DEG_PD, 2)
'            PD_GPM(6, 2) = Round(.RAE_Out_6FLOW, 2)
'            Me.tbxEvap6.Text = "Fluid PD = " & Round(.RAE_Out_6DEG_PD, 2) & "   GPM = " & Round(.RAE_Out_6FLOW, 2)

'            '7 Degree         
'            If circuitsPerUnit = 4 Then
'               Me.txtCapacityAt7FApproach.Text = .RAE_Out_txt7DEG_Text / 2
'            Else
'               Me.txtCapacityAt7FApproach.Text = .RAE_Out_txt7DEG_Text / circuitsPerUnit
'            End If
'            PD_GPM(7, 1) = Round(.RAE_Out_7DEG_PD, 2)
'            PD_GPM(7, 2) = Round(.RAE_Out_7FLOW, 2)
'            Me.tbxEvap7.Text = "Fluid PD = " & Round(.RAE_Out_7DEG_PD, 2) & "   GPM = " & Round(.RAE_Out_7FLOW, 2)

'            '8 Degree
'            If circuitsPerUnit = 4 Then
'               Me.txtCapacityAt8FApproach.Text = .RAE_Out_txt8DEG_Text / 2
'            Else
'               Me.txtCapacityAt8FApproach.Text = .RAE_Out_txt8DEG_Text / circuitsPerUnit
'            End If
'            PD_GPM(8, 1) = Round(.RAE_Out_8DEG_PD, 2)
'            PD_GPM(8, 2) = Round(.RAE_Out_8FLOW, 2)
'            Me.tbxEvap8.Text = "Fluid PD = " & Round(.RAE_Out_8DEG_PD, 2) & "   GPM = " & Round(.RAE_Out_8FLOW, 2)

'            '9 Degree         
'            If circuitsPerUnit = 4 Then
'               Me.txtCapacityAt9FApproach.Text = .RAE_Out_txt9DEG_Text / 2
'            Else
'               Me.txtCapacityAt9FApproach.Text = .RAE_Out_txt9DEG_Text / circuitsPerUnit
'            End If
'            PD_GPM(9, 1) = Round(.RAE_Out_9DEG_PD, 2)
'            PD_GPM(9, 2) = Round(.RAE_Out_9FLOW, 2)
'            Me.tbxEvap9.Text = "Fluid PD = " & Round(.RAE_Out_9DEG_PD, 2) & "   GPM = " & Round(.RAE_Out_9FLOW, 2)

'            '10 Degree
'            If circuitsPerUnit = 4 Then
'               Me.txtCapacityAt10FApproach.Text = .RAE_Out_txt10DEG_Text / 2
'            Else
'               Me.txtCapacityAt10FApproach.Text = .RAE_Out_txt10DEG_Text / circuitsPerUnit
'            End If
'            PD_GPM(10, 1) = Round(.RAE_Out_10DEG_PD, 2)
'            PD_GPM(10, 2) = Round(.RAE_Out_10FLOW, 2)
'            Me.tbxEvap10.Text = "Fluid PD = " & Round(.RAE_Out_10DEG_PD, 2) & "   GPM = " & Round(.RAE_Out_10FLOW, 2)

'            '11 Degree
'            If circuitsPerUnit = 4 Then
'               Me.txtCapacityAt11FApproach.Text = .RAE_Out_txt11DEG_Text / 2
'            Else
'               Me.txtCapacityAt11FApproach.Text = .RAE_Out_txt11DEG_Text / circuitsPerUnit
'            End If
'            PD_GPM(11, 1) = Round(.RAE_Out_11DEG_PD, 2)
'            PD_GPM(11, 2) = Round(.RAE_Out_11FLOW, 2)
'            Me.tbxEvap11.Text = "Fluid PD = " & Round(.RAE_Out_11DEG_PD, 2) & "   GPM = " & Round(.RAE_Out_11FLOW, 2)

'            '12 Degree
'            If circuitsPerUnit = 4 Then
'               Me.txtCapacityAt12FApproach.Text = .RAE_Out_txt12DEG_Text / 2
'            Else
'               Me.txtCapacityAt12FApproach.Text = .RAE_Out_txt12DEG_Text / circuitsPerUnit
'            End If
'            PD_GPM(12, 1) = Round(.RAE_Out_12DEG_PD, 2)
'            PD_GPM(12, 2) = Round(.RAE_Out_12FLOW, 2)
'            Me.tbxEvap12.Text = "Fluid PD = " & Round(.RAE_Out_12DEG_PD, 2) & "   GPM = " & Round(.RAE_Out_12FLOW, 2)
'         End With
'      End If
'   End Sub


'   'sets fan watts control value based on hertz and condenser fan
'   Private Sub SetFanWatts()
'      Dim fanFileName As String = Me.GrabFan.FileName
'      Dim hertz As Integer = CInt(Me.cboHertz.SelectedItem.ToString)

'      Me.fanWatts = Business.Intelligence.FanIntel.SelectFanWatts(fanFileName, hertz, gVolts)

'      Me.txtFanWatts.Text = Me.fanWatts.ToString
'   End Sub




'   'sets control values returned from 30a0database for circuit 1
'   '1. evaporator and length, 2. condenser, 3. compressor and quantity,
'   '4. fan quantity and diameter, 5. coil quantity, 6. circuits per unit,
'   '7. sub cooling, 8. evaporator capacity, 
'   '9. fpi, fin width and height, 10. fan 
'   'fills hidden refrigerant comboboxes based on compressor
'   'sets condenser capacity
'   'sets specific heat and specific gravity
'   'fills approach and evaporator capacity
'   Private Sub CALL_Circuit1()
'      Dim chiller As DataTable

'      ' retrieves chiller object for model
'      chiller = Rae.RaeSolutions.DataAccess.Chillers.ChillerDataAccess.RetrieveChiller(Me.GrabChillerModel())

'      ' sets controls
'      '
'      Me.txtEvaporatorModel.Text = ConvertNull.ToString(chiller.Rows(0).Item("Evap_part_no"))
'      'COILQTY_1 = chiller.Circuit1.NumCoils.ToString
'      Me.txtCondenser_1.Text = ConvertNull.ToString(chiller.Rows(0).Item("Coil_1")).ToUpper
'      Me.txtCompressor1.Text = ConvertNull.ToString(chiller.Rows(0).Item("Compressor_1")).ToUpper
'      Me.txtNumCompressors1.Text = ConvertNull.ToString(chiller.Rows(0).Item("Compr_Qty_1")).ToString
'      Me.txtNumCoils1.Text = chiller.Rows(0).Item("CoilQty_1").ToString
'      ''Me.txtNumFans1.Text = chiller.Rows(0).Item("FanQty_1").ToString
'      'Me.txtNumCoils1.Text = chiller.Circuit1.NumCoils.ToString
'      Me.txtSubCooling1.Text = ConvertNull.ToString(chiller.Rows(0).Item("Degrees_Sub_Cooling_Coil_1")).ToString
'      Me.Txt_circuit_per_unit.Text = ConvertNull.ToString(chiller.Rows(0).Item("Circuits_Per_Unit")).ToString()

'      Me.DisplaySystemCapacity(Average(ConvertNull.ToDouble(chiller.Rows(0).Item("Approx_Min_Cap")), ConvertNull.ToDouble(chiller.Rows(0).Item("Approx_Max_Cap"))))

'      If Val(Me.Txt_circuit_per_unit.Text) = 1 Then
'         Me.cboSystem.SelectedIndex = 0
'         Me.cboSystem.Enabled = False
'      Else
'         Me.cboSystem.Enabled = True
'      End If

'      Me.lboCompressors1.SelectedIndex = ControlAssistant.GetIndexOfValueInListBox(Me.lboCompressors1, chiller.Rows(0).Item("Compressor_1"))
'      'Me.cboFinsPerInch1.SelectedIndex = _
'      'ControlAssistant.GetIndexOfComboboxItem(Me.cboFinsPerInch1, chiller.Circuit1.Coil.FinsPerInch)
'      'Me.txtFinHeight1.Text = chiller.Circuit1.Coil.Height.ToString
'      'Me.txtFinLength1.Text = chiller.Circuit1.Coil.Length.ToString

'      'Me.cboCondenser1.SelectedIndex = IndexOfCondenser(Me.cboCondenser1, chiller.Circuit1.Coil.Rows.ToString & "RCOND")
'      'Me.cboFan.SelectedIndex = IndexOfFanFileName(Me.cboFan, Business.Intelligence.Fan.SelectFanFileName(chiller.Circuit1.FanDiameter))

'      If chiller.Rows(0).Item("Circuits_Per_Unit") > 1 Then
'         Me.radCircuit2.Visible = True
'      End If

'      'sets chiller evaporator controls
'      Me.SetChillerEvaporatorControls()

'      SetCondenserCapacity()
'      ' 1 = Parms    2 = Models    3 = 8&10 deg approach
'      ' sets specific heat and specific gravity
'      ChillyRAEs_pass_no = 1 : ChillyRAE()
'      'fills approach and evaporator capacity
'      ChillyRAEs_pass_no = 3 : ChillyRAE()
'   End Sub


'   'sets control values returned from 30a0database for circuit 2
'   '1. evaporator and length, 2. condenser, 3. compressor and quantity,
'   '4. fan quantity and diameter, 5. coil quantity, 6. circuits per unit,
'   '7. sub cooling, 8. evaporator capacity, 
'   '9. fpi, fin width and height, 10. fan 
'   'fills hidden refrigerant comboboxes based on compressor
'   'sets condenser capacity
'   'sets specific heat and specific gravity
'   'fills approach and evaporator capacity
'   Private Sub CALL_Circuit2()
'      'Dim chiller As Business.Entities.Chillers.Chiller
'      Dim chiller As DataTable

'      ' retrieves chiller object for model
'      'chiller = Business.Agents.Chiller.RetrieveChiller(Me.GrabChillerModel())
'      chiller = Rae.RaeSolutions.DataAccess.Chillers.ChillerDataAccess.RetrieveChiller(Me.GrabChillerModel())

'      ' sets evaporator model
'      'Me.txtEvaporatorModel.Text = chiller.EvaporatorPartNum.ToUpper
'      Me.txtEvaporatorModel.Text = chiller.Rows(0).Item("Evap_part_no")

'      ' fills hid condenser textboxes
'      'Me.txtCondenser_2.Text = chiller.Circuit2.Coil.Name.ToUpper
'      ' sets compressor
'      'Me.txtCompressor2.Text = chiller.Circuit2.Compressor.Name.ToUpper
'      'sets number of compressors
'      'Me.txtNumCompressors2.Text = chiller.Circuit2.NumCompressors.ToString
'      Me.txtCondenser_2.Text = chiller.Rows(0).Item("Coil_2").ToUpper
'      Me.txtCompressor2.Text = chiller.Rows(0).Item("Compressor_2").ToUpper
'      Me.txtNumCompressors2.Text = chiller.Rows(0).Item("Compr_Qty_2").ToString
'      Me.txtNumCoils2.Text = chiller.Rows(0).Item("CoilQty_2").ToString

'      ' sets number of fans
'      'Me.txtNumFans2.Text = chiller.Circuit2.NumFans.ToString
'      ' sets coil quantity
'      'Me.txtNumCoils2.Text = chiller.Circuit2.NumCoils.ToString

'      ' sets number of circuits per unit
'      'Me.Txt_circuit_per_unit.Text = chiller.NumCircuitsPerUnit.ToString
'      Me.Txt_circuit_per_unit.Text = chiller.Rows(0).Item("Circuits_Per_Unit").ToString()

'      ' sets sub cooling
'      'Me.txtSubCooling2.Text = chiller.Circuit2.SubCoolingPercentage.ToString
'      Me.txtSubCooling2.Text = chiller.Rows(0).Item("Degrees_Sub_Cooling_Coil_2").ToString

'      ' set evaporator capacity? in tons or gpm, approx. capacities are in tons
'      'Me.DisplaySystemCapacity(Common.Math.Average(chiller.ApproxMinCapacity, chiller.ApproxMaxCapacity))
'      Me.DisplaySystemCapacity(Average(chiller.Rows(0).Item("Approx_Min_Cap"), chiller.Rows(0).Item("Approx_Max_Cap")))

'      ' disables system control if only 1 circuit per unit
'      'If chiller.NumCircuitsPerUnit = 1 Then
'      If chiller.Rows(0).Item("Circuits_Per_Unit") = 1 Then
'         Me.cboSystem.SelectedIndex = 0
'         Me.cboSystem.Enabled = False
'      Else
'         Me.cboSystem.Enabled = True
'      End If

'      ' selects compressor
'      Me.lboCompressors2.SelectedIndex = ControlAssistant.GetIndexOfValueInListBox(Me.lboCompressors2, Me.txtCompressor2.Text)
'      ' selects fins per inch
'      'Me.cboFinsPerInch2.SelectedIndex = RAE.UI.ListHelper.IndexOfComboBoxItem(Me.cboFinsPerInch2, chiller.Circuit2.Coil.FinsPerInch)
'      ' sets fin width and length
'      'Me.txtFinHeight2.Text = chiller.Circuit2.Coil.Height.ToString
'      'Me.txtFinLength2.Text = chiller.Circuit2.Coil.Length.ToString
'      ' selects condenser
'      'Me.cboCondenser2.SelectedIndex = IndexOfCondenser(Me.cboCondenser2, chiller.Circuit2.Coil.Rows.ToString & "RCOND")
'      ' selects fan diameter
'      'Me.cboFan.SelectedIndex = IndexOfFanFileName(Me.cboFan, Business.Intelligence.Fan.SelectFanFileName(chiller.Circuit2.FanDiameter))

'      'shows circuit 2 radiobutton if circuits is greater than 1
'      'If chiller.NumCircuitsPerUnit > 1 Then
'      If chiller.Rows(0).Item("Circuits_Per_Unit") > 1 Then
'         radCircuit2.Visible = True
'      End If

'      ' sets evaporator description
'      Me.SetChillerEvaporatorControls()
'      ' calls cofan to get condenser capacity
'      Me.SetCondenserCapacity()
'      ' 1 = specific heat and gravity    2 = evaporator models    3 = 8&10 deg approach
'      ChillyRAEs_pass_no = 1 : ChillyRAE()
'      ChillyRAEs_pass_no = 3 : ChillyRAE()
'   End Sub

'#End Region


'#Region " Private Methods"

'#Region " UI"


'   Private Function GrabChillerModel() As String
'      Dim drv As DataRowView = Me.cboModels.SelectedItem
'      Return drv("Model")
'      ' Return Me.cboModels.SelectedItem.ToString
'   End Function

'   Private Function GrabSpecificGravity() As Single
'      Return Round(CSng(Me.txtSpecificGravity.Text.Trim), 2)
'   End Function

'   Private Function GrabSpecificHeat() As Single
'      Return CSng(Me.txtSpecificHeat.Text.Trim)
'   End Function

'   Private Function GrabMinSuctionTemp() As Single
'      Return CSng(Me.txtSuctionTemp.Text.Trim)
'   End Function

'   Private Function GrabTemperatureRange() As Single
'      Return CSng(Me.txtTempRange.Text.Trim)
'   End Function

'   Private Function GrabSystemCapacity() As Single
'      Return CSng(Me.txtEvaporatorCapacity.Text.Trim)
'   End Function

'   Private Function GrabSystemCapacityBtuh() As Single
'      Dim systemCapacityBtuh As Single
'      If Me.radTons.Checked Then
'         ' grabs system capacity from textbox
'         systemCapacityBtuh = Convert.TonsToBtuh(GrabSystemCapacity())
'      ElseIf Me.radGpm.Checked Then
'         ' converts from gpm to btuh
'         systemCapacityBtuh = Convert.GpmToBtuh(Me.GrabSystemCapacity(), Me.GrabTemperatureRange(), _
'            Me.GrabSpecificHeat(), Me.GrabSpecificGravity())
'      End If
'      Return systemCapacityBtuh
'   End Function

'   Private Function GrabCondenser1() As Condenser1
'      Return DirectCast(Me.cboCondenser1.SelectedItem, Condenser1)
'   End Function

'   Private Function GrabCondenser2() As Condenser1
'      Return DirectCast(Me.cboCondenser2.SelectedItem, Condenser1)
'   End Function

'   Private Function GrabFan() As Business.Entities.Fan
'      Return DirectCast(Me.cboFan.SelectedItem, Business.Entities.Fan)
'   End Function

'   Private Function GrabEvaporatorModel() As String
'      Return Me.txtEvaporatorModel.Text.Trim
'   End Function


'   Private Sub DisplaySystemCapacity(ByVal capacityTons As Single)
'      If Me.radTons.Checked Then  'Tons 
'         Me.txtEvaporatorCapacity.Text = Round(capacityTons, 2)
'      ElseIf radGpm.Checked Then  'GPM 
'         Me.txtEvaporatorCapacity.Text = _
'            Convert.TonsToGpm(capacityTons, Me.GrabTemperatureRange(), Me.GrabSpecificHeat(), Me.GrabSpecificGravity())
'         'Me.txtEvaporatorCapacity.Text = Convert.TonsToGpm(Common.Math.Average(minCapacity, maxCapacity), _
'         '   temperatureRange, specificHeat, specificGravity)
'      End If
'   End Sub



'   Private Sub ColorControls()
'      With New ColorManager
'         Me.panModel.BackColor = .LightBlue
'         Me.panButtons.BackColor = .LightBlue
'         Me.lblErro.BackColor = .LightBlue
'         Me.panFooter.BackColor = .LightBlue

'         ' colors headers
'         Me.lblRatingCriteria.ForeColor = .HeaderBlue
'         Me.lblCompressor.ForeColor = .HeaderBlue
'         Me.lblCondenser.ForeColor = .HeaderBlue
'         Me.lblEvaporator.ForeColor = .HeaderBlue

'         ' colors lines
'         Me.lineRatingCriteria.ForeColor = .HeaderBlue
'         Me.lineCompressor.ForeColor = .HeaderBlue
'         Me.lineCondenser.ForeColor = .HeaderBlue
'         Me.lineEvaporator.ForeColor = .HeaderBlue

'         ' colors comments
'         Me.lblSubCoolingF.ForeColor = .GreyBlue
'         Me.lblMinSuctionF.ForeColor = .GreyBlue
'         Me.lblAmbientF.ForeColor = .GreyBlue
'         Me.lblFreezePointF.ForeColor = .GreyBlue
'         Me.lblLeavingFluidF.ForeColor = .GreyBlue
'         Me.lblRangeF.ForeColor = .GreyBlue
'         Me.lblCFM.ForeColor = .GreyBlue

'         Me.lblCondenserTD1F.ForeColor = .GreyBlue
'         Me.lblCondenserTD2F.ForeColor = .GreyBlue
'         Me.lblAltitudeFt.ForeColor = .GreyBlue
'         'Me.lblApplies1.ForeColor = .GreyBlue
'         'Me.lblApplies2.ForeColor = .GreyBlue
'         'Me.lblApplies3.ForeColor = .GreyBlue
'         'Me.lblApplies4.ForeColor = .GreyBlue
'         Me.lblDischargeLineLossF.ForeColor = .GreyBlue
'         Me.lblSuctionLineLossF.ForeColor = .GreyBlue
'         Me.lblCondenserCapacityBtuh.ForeColor = .GreyBlue
'         'Me.lblCondenserCapacityF.ForeColor = .GreyBlue
'         Me.lblCondSubCoolingPercent1.ForeColor = .GreyBlue
'         Me.lblCondSubCoolingPercent2.ForeColor = .GreyBlue

'         ' colors buttons
'         Me.btnCriteriaPlus.ForeColor = .HeaderBlue
'         Me.btnCriteriaPlus.BackColor = .LighterBlue
'         Me.btnCompressorPlus.ForeColor = .HeaderBlue
'         Me.btnCompressorPlus.BackColor = .LighterBlue
'         Me.btnCondenserPlus.ForeColor = .HeaderBlue
'         Me.btnCondenserPlus.BackColor = .LighterBlue
'         Me.btnEvaporatorPlus.ForeColor = .HeaderBlue
'         Me.btnEvaporatorPlus.BackColor = .LighterBlue

'      End With
'   End Sub



'   Private Sub SetOtherEvaporatorVisibility()
'      If Me.radOtherEvaporator.Checked Then
'         Me.tbxEvap8Degr1.Visible = True
'         Me.tbxEvap10Degr1.Visible = True
'         If Int32.Parse(Me.Txt_circuit_per_unit.Text) > 1 Then
'            Me.tbxEvap8Degr2.Visible = True
'            Me.tbxEvap10Degr2.Visible = True
'         Else
'            Me.tbxEvap8Degr2.Visible = False
'            Me.tbxEvap10Degr2.Visible = False
'         End If
'      Else
'         Me.tbxEvap8Degr1.Visible = False
'         Me.tbxEvap10Degr1.Visible = False
'         Me.tbxEvap8Degr2.Visible = False
'         Me.tbxEvap10Degr2.Visible = False
'      End If
'   End Sub


'   ''' <summary>Sets the chiller's evaporator controls
'   ''' </summary>
'   ''' <remarks>Sets evaporator length textbox and chiller model textbox and label
'   ''' </remarks>
'   ''' <history>[CASEYJ]	5/9/2005	Created
'   ''' </history>
'   Private Sub SetChillerEvaporatorControls()
'      Dim evaporator As Evaporator1
'      Dim chillerDescription As String
'      Dim newLine As String = System.Environment.NewLine

'      Try
'         'retrieves chiller evaporator information
'         evaporator = BCA.RetrieveChillerEvaporator(Me.GrabEvaporatorModel())
'      Catch ex As OleDb.OleDbException
'         MessageBox.Show("Attempt to retrieve the chiller's evaporator information failed. " & ex.Message, _
'            "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
'      End Try
'      With evaporator
'         'sets evaporator length textbox
'         Me.txt_Evap_Length.Text = .Length
'         'sets chiller description
'         chillerDescription = "P#: " & .RaePartNum & newLine & _
'            "  Nom Tons: " & .NominalTons & newLine & _
'            "  Connection Size: " & .ConnectionSize & newLine & _
'            "  LxWxH: " & .Length & "x" & .Width & "x" & .Height
'         'sets tool tip for chiller model number textbox and label
'         Me.ToolTip1.SetToolTip(Me.txtModel, chillerDescription)
'         Me.ToolTip1.SetToolTip(Me.lblModel, chillerDescription)
'      End With
'   End Sub


'   Private Sub SetControlAccess()
'      'Label3.Visible = False

'      '****** NEWER ********
'      txtApproach.Visible = False
'      txtSubCooling.ReadOnly = True

'      'Label2.Visible = False
'      cboSafetyOverride.Visible = False
'      lboCompressors1.Visible = False
'      lboCompressors2.Visible = False
'      txtNumCompressors1.ReadOnly = True
'      txtNumCompressors2.ReadOnly = True
'      txtNumCoils1.ReadOnly = True
'      txtNumCoils2.ReadOnly = True
'      'cboFinsPerInch1.Enabled = True
'      'cboFinsPerInch2.Enabled = True
'      cboSubCooling1.Enabled = False
'      cboSubCooling2.Enabled = False
'      cboCondenser1.Enabled = False
'      cboCondenser2.Enabled = False
'      txtSubCooling1.Visible = False
'      txtSubCooling2.Visible = False
'      'txtFinHeight1.ReadOnly = True
'      'txtFinHeight2.ReadOnly = True
'      'txtFinLength1.ReadOnly = True
'      'txtFinLength2.ReadOnly = True
'      txtCondenserTD1.Visible = False
'      txtCondenserTD2.Visible = False
'      txtNumFans1.ReadOnly = True
'      txtNumFans2.ReadOnly = True
'      txtCondenserCapacity1.Visible = False
'      txtCondenserCapacity2.Visible = False
'      chkCatalogRating.Checked = True
'      chkCatalogRating.Visible = False
'      radOtherEvaporator.Visible = False

'      rad6To8Approach.Visible = False
'      rad7To9Approach.Visible = False
'      rad8To10Approach.Visible = False
'      rad9To11Approach.Visible = False
'      rad10To12Approach.Visible = False

'      txtCapacityAt4FApproach.Visible = False
'      txtCapacityAt5FApproach.Visible = False
'      txtCapacityAt6FApproach.Visible = False
'      txtCapacityAt7FApproach.Visible = False
'      txtCapacityAt8FApproach.Visible = False
'      txtCapacityAt9FApproach.Visible = False
'      txtCapacityAt10FApproach.Visible = False
'      txtCapacityAt11FApproach.Visible = False
'      txtCapacityAt12FApproach.Visible = False

'      tbxEvap4.Visible = False
'      tbxEvap5.Visible = False
'      tbxEvap6.Visible = False
'      tbxEvap7.Visible = False
'      tbxEvap8.Visible = False
'      tbxEvap9.Visible = False
'      tbxEvap10.Visible = False
'      tbxEvap11.Visible = False
'      tbxEvap12.Visible = False
'      txtSubCooling.Enabled = False
'      cboSystem.Visible = False
'      cboFoulingFactor.Visible = True
'      cboDischargeLineLoss.Visible = False
'      cboSuctionLineLoss.Visible = False
'   End Sub


'   ''' <summary>Fills listbox with compressor description
'   ''' </summary>
'   ''' <history>[CASEYJ]	5/4/2005	Created
'   ''' </history>
'   Private Sub FillCompressorListBoxes()
'      Dim compressorsTable As DataTable

'      Try
'         ' gets list of compressors for selected refrigerant
'         compressorsTable = Business.Agents.Compressor.RetrieveCompressorDescriptions2(Refrigerant.Name.Replace("R", ""), chkNewCoefficients.Checked)
'         'Dim strRef As String = Refrigerant.Name '.Replace("R", "")
'         'If strRef.IndexOf("22") > -1 Then
'         '    strRef += "H"
'         'End If
'         'compressorsTable = Rae.RaeSolutions.DataAccess35A0.RetrieveCompressorDescriptions(strRef, chkNewCoefficients.Checked, Me.cboVolts.SelectedItem.ToString)
'      Catch ex As OleDb.OleDbException
'         Ui.MessageBox.Show("Attempt to retrieve compressor descriptions failed." & Environment.NewLine & ex.Message)
'         Exit Sub
'      End Try

'      ' inserts 'Choose' in list
'      Dim row As DataRow
'      row = compressorsTable.NewRow
'      row("Description") = "Choose"
'      row("compmodel") = "Choose"
'      compressorsTable.Rows.InsertAt(row, 0)

'      'fills compressor listboxes, use copy of table so that the listboxes aren't forced to stay in sync
'      Me.lboCompressors1.DataSource = compressorsTable.Copy()
'      Me.lboCompressors1.DisplayMember = "Description"
'      Me.lboCompressors1.ValueMember = "compmodel"

'      Me.lboCompressors2.DataSource = compressorsTable.Copy()
'      Me.lboCompressors2.DisplayMember = "Description"
'      Me.lboCompressors2.ValueMember = "compmodel"
'   End Sub


'#End Region


'   ' TODO: move declarations to top of class
'   Private chillerVMgr As ValidationManager
'   Private leavingFluidTempVCtrl As ValidationControl


'   ''' <summary>Initializes validation utilities (managers, controls, and validators).</summary>
'   Private Sub InitializeValidation()
'      ' VMgr - ValidationManager
'      ' VCtrl - ValidationControl
'      ' RangeV - RangeValidator, ReqV - RequiredValidator, NumV - NumberValidator

'      Dim leavingFluidTempReqV As RequiredValidator
'      Dim leavingFluidTempNumV As RegularExpressionValidator
'      Dim leavingFluidTempRangeV As AmongRangeValidator
'      Dim leavingFluidTempName As String = "Leaving fluid temperature textbox"

'      ' constructs and sets validation managers error provider
'      Me.chillerVMgr = New ValidationManager(Me.err)
'      ' constructs and adds leaving fluid temperature textbox to validation control
'      Me.leavingFluidTempVCtrl = New ValidationControl(Me.txtLeavingFluidTemp)

'      ' constructs required validator
'      leavingFluidTempReqV = New RequiredValidator(ErrorMessages.Required(leavingFluidTempName))
'      ' constructs number (regular expression) validator
'      leavingFluidTempNumV = New RegularExpressionValidator( _
'         ErrorMessages.Number(leavingFluidTempName), RegularExpressions.Number)
'      ' contstructs range validator w/ error message and limits
'      leavingFluidTempRangeV = New AmongRangeValidator(ErrorMessages.Range( _
'         leavingFluidTempName, LEAVING_FLUID_TEMP_LOWER_LIMIT, LEAVING_FLUID_TEMP_UPPER_LIMIT), _
'         LEAVING_FLUID_TEMP_LOWER_LIMIT, LEAVING_FLUID_TEMP_UPPER_LIMIT)

'      ' adds leaving fluid temperature control to validation manager
'      Me.chillerVMgr.ValidationControls.Add(Me.leavingFluidTempVCtrl)

'      ' adds validators to leaving fluid temperature textbox
'      '
'      ' adds range validator
'      Me.leavingFluidTempVCtrl.Validators.Add(leavingFluidTempRangeV)
'      ' adds required validator
'      Me.leavingFluidTempVCtrl.Validators.Add(leavingFluidTempReqV)
'      ' adds number (regular expression) validator
'      Me.leavingFluidTempVCtrl.Validators.Add(leavingFluidTempNumV)


'   End Sub


'   Private Sub InitializeControls()
'      ' changing the index so the textbox will fill w/ Choose
'      Me.lboCompressors1.SelectedIndex = 1
'      Me.lboCompressors1.SelectedIndex = 0
'      Me.lboCompressors2.SelectedIndex = 1
'      Me.lboCompressors2.SelectedIndex = 0

'      ' sets series default
'      Me.cboSeries.SelectedIndex = 0
'      ' sets model default
'      'Me.cboSeries_SelectedIndexChanged(New Object, New EventArgs)


'   End Sub


'   Private Function IsChillerModelValid() As Boolean
'      Dim isValid As Boolean

'      ' checks if model is valid
'      If Me.GrabChillerModel Is Nothing OrElse Me.GrabChillerModel.Length = 0 OrElse Me.GrabChillerModel = "Choose" Then
'         isValid = False
'      Else
'         isValid = True
'      End If

'      Return isValid
'   End Function

'   Sub LoadControls(ByVal process_item As WCChillerProcessItem)

'      ' If latest revision has not been set then
'      ' we need to set it now  based on the ID...
'      If Me.m_LatestRevision = 0 Then
'         Me.m_LatestRevision = Rae.RaeSolutions.DataAccess.Projects.ProcessItemDA.LastestRevision(Me.Tag)
'      End If

'      ' Increment the current process revision
'      ' displayed on this form...
'      Me.m_CurrentRevision = process_item.Revision

'      ' Clone last saved process to passing process item
'      LastSavedProcess = process_item.Clone()

'      cboSeries.Text = LastSavedProcess.Series
'      cboModels.Text = LastSavedProcess.Model
'      txtModel.Text = LastSavedProcess.ModelDesc
'      cboFluid.Text = LastSavedProcess.Fluid
'      txtGlycolPercentage.Text = LastSavedProcess.GlycolPercentage
'      cboCoolingMedia.Text = LastSavedProcess.CoolingMedia
'      txtSpecificHeat.Text = LastSavedProcess.SpecificHeat
'      txtSpecificGravity.Text = LastSavedProcess.SpecificGravity
'      txtSubCooling.Text = LastSavedProcess.SubCooling
'      cboRefrigerant.Text = LastSavedProcess.Refrigerant
'      txtTempRange.Text = LastSavedProcess.TempRange
'      txtAmbientTemp.Text = LastSavedProcess.AmbientTemp
'      txtLeavingFluidTemp.Text = LastSavedProcess.LeavingFluidTemp
'      cboSystem.Text = LastSavedProcess.System
'      cboHertz.Text = LastSavedProcess.Hertz
'      txtApproach.Text = LastSavedProcess.Approach
'      cboVolts.Text = LastSavedProcess.Volts
'      'txtTEMin.Text = LastSavedProcess.TEMin
'      'txtTEMax.Text = LastSavedProcess.TEMax
'      'txtTEIncrement.Text = LastSavedProcess.TEIncrement
'      'txtATMin.Text = LastSavedProcess.ATMin
'      'txtATMax.Text = LastSavedProcess.ATMax
'      'txtATIncrement.Text = LastSavedProcess.ATIncrement
'      cboSafetyOverride.Checked = LastSavedProcess.SafetyOverride
'      radCircuit1.Checked = LastSavedProcess.Circuit1
'      radCircuit2.Checked = LastSavedProcess.Circuit2
'      txtCompressor1.Text = LastSavedProcess.Compressors1
'      txtCompressor2.Text = LastSavedProcess.Compressors2
'      txtNumCompressors1.Text = LastSavedProcess.NumCompressors1
'      txtNumCompressors2.Text = LastSavedProcess.NumCompressors2
'      Try
'         lboCompressors1.SetSelected(lboCompressors1.Items.IndexOf(LastSavedProcess.Compressors1), True)
'      Catch ex As Exception
'      End Try
'      Try
'         lboCompressors2.SetSelected(lboCompressors2.Items.IndexOf(LastSavedProcess.Compressors2), True)
'      Catch ex As Exception
'      End Try
'      txtNumCoils1.Text = LastSavedProcess.NumCoils1
'      txtNumCoils2.Text = LastSavedProcess.NumCoils2
'      cboCondenser1.Text = LastSavedProcess.Condenser1
'      cboCondenser2.Text = LastSavedProcess.Condenser2
'      cboDischargeLineLoss.Text = LastSavedProcess.DischargeLineLoss
'      cboSuctionLineLoss.Text = LastSavedProcess.SuctionLineLoss
'      txtAltitude.Text = LastSavedProcess.Altitude
'      'txtPumpWatts.Text = LastSavedProcess.PumpWatts
'      txtFanWatts.Text = LastSavedProcess.FanWatts
'      txtCondenserCapacity1.Text = LastSavedProcess.CondenserCapacity1
'      txtCondenserCapacity2.Text = LastSavedProcess.CondenserCapacity2
'      cboEvaporatorModel.Text = LastSavedProcess.EvaporatorModel
'      txtEvaporatorModel.Text = LastSavedProcess.EvaporatorModelDesc
'      'cboNumEvap.Text = LastSavedProcess.NumEvap
'      cboFoulingFactor.Text = LastSavedProcess.FoulingFactor
'      If LastSavedProcess.CapacityType = WCChillerProcessItem.eCapacityType.Tons Then
'         radTons.Checked = True
'      ElseIf LastSavedProcess.CapacityType = WCChillerProcessItem.eCapacityType.GPM Then
'         radGpm.Checked = True
'      Else
'         radGpm.Checked = False
'         radTons.Checked = False
'      End If
'      txtEvaporatorCapacity.Text = LastSavedProcess.EvaporatorCapacity
'      chkCatalogRating.Checked = LastSavedProcess.CatalogRating
'      ' Approach range...
'      If LastSavedProcess.ApproachRange = WCChillerProcessItem.eApproachRange.SixToEight Then
'         rad6To8Approach.Checked = True
'      ElseIf LastSavedProcess.ApproachRange = WCChillerProcessItem.eApproachRange.SevenToNine Then
'         rad7To9Approach.Checked = True
'      ElseIf LastSavedProcess.ApproachRange = WCChillerProcessItem.eApproachRange.EightToTen Then
'         rad8To10Approach.Checked = True
'      ElseIf LastSavedProcess.ApproachRange = WCChillerProcessItem.eApproachRange.NineToEleven Then
'         rad9To11Approach.Checked = True
'      ElseIf LastSavedProcess.ApproachRange = WCChillerProcessItem.eApproachRange.TenToTwelve Then
'         rad10To12Approach.Checked = True
'      ElseIf LastSavedProcess.ApproachRange = WCChillerProcessItem.eApproachRange.Other Then
'         radOtherEvaporator.Checked = True
'      End If
'      tbxEvap8Degr1.Text = LastSavedProcess.Evap8Degr1
'      tbxEvap8Degr2.Text = LastSavedProcess.Evap8Degr2
'      tbxEvap10Degr1.Text = LastSavedProcess.Evap10Degr1
'      tbxEvap10Degr2.Text = LastSavedProcess.Evap10Degr2

'      ' Calculate page...
'      'btnCalculatePage_Click(btnCalculatePage, Nothing)

'   End Sub

'   ''' <summary>
'   ''' Handles revision view control's revision changed event.
'   ''' If user has unsaved changes, asks user to save before navigating revisions.
'   ''' </summary>
'   Private Sub RevisionView_RevisionChanged(ByVal sender As RevisionView, ByVal e As ValueChangedEventArgs(Of Single))
'      If sender.ActiveProcessForm Is Me Then
'         SaveControls(False, False, False, False, True)
'      End If
'   End Sub

'   Function SaveControls(Optional ByVal SaveAsRevision As Boolean = False, Optional ByVal SaveAsNew As Boolean = False, Optional ByVal FormClosing As Boolean = False, Optional ByVal GenerateEquipment As Boolean = False, Optional ByVal RevChanged As Boolean = False) As Boolean

'      If CurrentStateProcess Is Nothing Then
'         If LastSavedProcess Is Nothing Then
'            CurrentStateProcess = New WCChillerProcessItem(New ItemId(AppInfo.User.Username, AppInfo.User.Password))
'         Else
'            CurrentStateProcess = LastSavedProcess.Clone
'         End If
'      Else
'         If LastSavedProcess IsNot Nothing Then CurrentStateProcess = LastSavedProcess.Clone
'      End If

'      CurrentStateProcess.Series = cboSeries.Text
'      CurrentStateProcess.Model = cboModels.Text
'      CurrentStateProcess.ModelDesc = txtModel.Text
'      CurrentStateProcess.Fluid = cboFluid.Text
'      CurrentStateProcess.GlycolPercentage = txtGlycolPercentage.Text
'      CurrentStateProcess.CoolingMedia = cboCoolingMedia.Text
'      CurrentStateProcess.SpecificHeat = txtSpecificHeat.Text
'      CurrentStateProcess.SpecificGravity = txtSpecificGravity.Text
'      CurrentStateProcess.SubCooling = txtSubCooling.Text
'      CurrentStateProcess.Refrigerant = cboRefrigerant.Text
'      CurrentStateProcess.TempRange = txtTempRange.Text
'      CurrentStateProcess.AmbientTemp = txtAmbientTemp.Text
'      CurrentStateProcess.LeavingFluidTemp = txtLeavingFluidTemp.Text
'      CurrentStateProcess.System = cboSystem.Text
'      CurrentStateProcess.Hertz = cboHertz.Text
'      CurrentStateProcess.Approach = txtApproach.Text
'      CurrentStateProcess.Volts = cboVolts.Text
'      'CurrentStateProcess.TEMin = txtTEMin.Text
'      'CurrentStateProcess.TEMax = txtTEMax.Text
'      'CurrentStateProcess.TEIncrement = txtTEIncrement.Text
'      'CurrentStateProcess.ATMin = txtATMin.Text
'      'CurrentStateProcess.ATMax = txtATMax.Text
'      'CurrentStateProcess.ATIncrement = txtATIncrement.Text
'      CurrentStateProcess.SafetyOverride = cboSafetyOverride.Checked
'      CurrentStateProcess.Circuit1 = radCircuit1.Checked
'      CurrentStateProcess.Circuit2 = radCircuit2.Checked
'      CurrentStateProcess.Compressors1 = txtCompressor1.Text
'      CurrentStateProcess.Compressors2 = txtCompressor2.Text
'      CurrentStateProcess.NumCompressors1 = txtNumCompressors1.Text
'      CurrentStateProcess.NumCompressors2 = txtNumCompressors2.Text
'      CurrentStateProcess.NumCoils1 = txtNumCoils1.Text
'      CurrentStateProcess.NumCoils2 = txtNumCoils2.Text
'      CurrentStateProcess.Condenser1 = cboCondenser1.Text
'      CurrentStateProcess.Condenser2 = cboCondenser2.Text
'      CurrentStateProcess.DischargeLineLoss = cboDischargeLineLoss.Text
'      CurrentStateProcess.SuctionLineLoss = cboSuctionLineLoss.Text
'      CurrentStateProcess.Altitude = txtAltitude.Text
'      'CurrentStateProcess.PumpWatts = txtPumpWatts.Text
'      CurrentStateProcess.FanWatts = Val(txtFanWatts.Text)
'      CurrentStateProcess.CondenserCapacity1 = CDbl(txtCondenserCapacity1.Text)
'      CurrentStateProcess.CondenserCapacity2 = CDbl(txtCondenserCapacity2.Text)
'      CurrentStateProcess.EvaporatorModel = cboEvaporatorModel.Text
'      CurrentStateProcess.EvaporatorModelDesc = txtEvaporatorModel.Text
'      'CurrentStateProcess.NumEvap = cboNumEvap.Text
'      CurrentStateProcess.FoulingFactor = cboFoulingFactor.Text
'      If radTons.Checked = True Then
'         CurrentStateProcess.CapacityType = WCChillerProcessItem.eCapacityType.Tons
'      ElseIf radGpm.Checked = True Then
'         CurrentStateProcess.CapacityType = WCChillerProcessItem.eCapacityType.GPM
'      End If
'      CurrentStateProcess.EvaporatorCapacity = txtEvaporatorCapacity.Text
'      CurrentStateProcess.CatalogRating = chkCatalogRating.Checked
'      ' Approach range...
'      If rad6To8Approach.Checked = True Then
'         CurrentStateProcess.ApproachRange = WCChillerProcessItem.eApproachRange.SixToEight
'      ElseIf rad7To9Approach.Checked = True Then
'         CurrentStateProcess.ApproachRange = WCChillerProcessItem.eApproachRange.SevenToNine
'      ElseIf rad8To10Approach.Checked = True Then
'         CurrentStateProcess.ApproachRange = WCChillerProcessItem.eApproachRange.EightToTen
'      ElseIf rad9To11Approach.Checked = True Then
'         CurrentStateProcess.ApproachRange = WCChillerProcessItem.eApproachRange.NineToEleven
'      ElseIf rad10To12Approach.Checked = True Then
'         CurrentStateProcess.ApproachRange = WCChillerProcessItem.eApproachRange.TenToTwelve
'      ElseIf radOtherEvaporator.Checked = True Then
'         CurrentStateProcess.ApproachRange = WCChillerProcessItem.eApproachRange.Other
'      End If
'      CurrentStateProcess.Evap8Degr1 = tbxEvap8Degr1.Text
'      CurrentStateProcess.Evap8Degr2 = tbxEvap8Degr2.Text
'      CurrentStateProcess.Evap10Degr1 = tbxEvap10Degr1.Text
'      CurrentStateProcess.Evap10Degr2 = tbxEvap10Degr2.Text

'      ' Set save process...
'      Dim RevSave As New RevisionSave
'      CurrentStateProcess = RevSave.SetSaveProcess(Me, Business.ProcessType.WCChiller, CurrentStateProcess, LastSavedProcess, SaveAsNew, SaveAsRevision, FormClosing, GenerateEquipment, RevChanged)
'      If RevSave.CancelSave = True Then
'         If CurrentStateProcess Is Nothing Then
'            ' canceled
'            RevSave = Nothing
'            Return False
'         Else
'            ' do not save and continue to close
'            RevSave = Nothing
'            Return True
'         End If
'      End If

'      ' Set last saved process...
'      LastSavedProcess = RevSave.RevisionSaved(CurrentStateProcess)
'      If RevSave.CancelSave = False Then
'         ' only save if user chooses...
'         CurrentStateProcess = LastSavedProcess.Clone
'         RevSave = Nothing
'         Return True
'      Else
'         ' User cancelled form close...
'         RevSave = Nothing
'         Return False
'      End If


'   End Function

'#Region " Testing"

'   'Fill hidden listboxes w/ refrigerants based on compressor     
'   'Private Sub FillHidRefrigerantsForSelectedCompressor()
'   '   Dim compressorModel As String = Me.txtCompressor.Text.Trim

'   '   Dim refrigerants As System.Collections.Specialized.StringCollection
'   '   refrigerants = DataAccess.Compressor.RetrieveRefrigerants(compressorModel)

'   '   If Me.Running_Circuit_no = 1 Then
'   '      Me.ListBox2.DataSource = refrigerants
'   '   ElseIf Me.Running_Circuit_no = 2 Then
'   '      Me.ListBox3.DataSource = refrigerants
'   '   End If
'   'End Sub

'#End Region


'#End Region


'#Region " Public methods"

'   Public Sub Open(ByVal Process_Item As ProcessItem)
'      Me.LoadControls(Process_Item)
'   End Sub


'   ''' <summary>Returns the index of the item with a matching condenser file name</summary>
'   Public Shared Function IndexOfCondenser(ByVal combobox As Forms.ComboBox, ByVal condenserFileName As String, _
'   Optional ByVal condenserNotFoundIndex As Integer = 0) As Integer
'      Dim index As Integer

'      ' selects condenser with matching file name (number of rows)
'      For i As Integer = 0 To combobox.Items.Count - 1
'         combobox.SelectedIndex = i
'         If DirectCast(combobox.SelectedItem, Condenser1).FileName = condenserFileName Then
'            index = i : Exit For
'         ElseIf combobox.SelectedIndex = combobox.Items.Count - 1 Then
'            index = condenserNotFoundIndex
'         End If
'      Next

'      Return index
'   End Function


'   ''' <summary>Returns the index of the item with a matching fan file name</summary>
'   Public Shared Function IndexOfFanFileName( _
'   ByVal combobox As Forms.ComboBox, ByVal fanFileName As String, Optional ByVal fanNotFoundIndex As Integer = 0) As Integer
'      Dim index As Integer

'      For i As Integer = 0 To combobox.Items.Count - 1
'         ' iteratively selects fan
'         combobox.SelectedIndex = i
'         ' checks if selected fan is a match
'         If DirectCast(combobox.SelectedItem, Business.Entities.Fan).FileName = fanFileName Then
'            ' match is found exit
'            index = i : Exit For
'            ' checks if this is the last item in list
'         ElseIf i = combobox.Items.Count - 1 Then
'            ' the fan file name is not in the list; selects fan not found index
'            index = fanNotFoundIndex
'         End If
'      Next

'      Return index
'   End Function


'   ''' <summary>Gets list of fins per inch options</summary>
'   'Public Shared Function GetFinsPerInchOptions() As Integer()
'   'Dim fpis(6) As Integer

'   '   fpis(0) = 8
'   '  fpis(1) = 9
'   ' fpis(2) = 10
'   'fpis(3) = 11
'   'fpis(4) = 12
'   'fpis(5) = 13
'   'fpis(6) = 14

'   'Return fpis
'   'End Function

'#End Region

'   Private Sub mnuChillerFilePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles printMenuItem.Click
'      Me.Cursor = Windows.Forms.Cursors.WaitCursor

'      Dim doc As New C1.C1PrintDocument.C1PrintDocument
'      'controls font and other styles on printed page
'      Dim printStyle As New C1.C1PrintDocument.C1DocStyle(doc)  'used in rendering spacer image
'      printStyle.Font = New Font("Arial", 10, FontStyle.Regular)
'      'the page settings from frmC1PrintPreview.vb are not applied
'      'page settings must be set in code in order to be applied
'      doc.PageSettings.Margins.Top = 50
'      doc.PageSettings.Margins.Bottom = 50

'      doc.DefaultUnit = C1.C1PrintDocument.UnitTypeEnum.Mm
'      'header
'      doc.PageHeader.Height = 8
'      doc.PageHeader.RenderText.Style = printStyle
'      doc.PageHeader.RenderText.Style.TextAlignHorz = C1.C1PrintDocument.AlignHorzEnum.Center
'      doc.PageHeader.RenderText.Style.TextAlignVert = C1.C1PrintDocument.AlignVertEnum.Top
'      doc.PageHeader.RenderText.Text = Me.Text
'      'footer
'      doc.PageFooter.Height = 8
'      doc.PageFooter.RenderText.Style = printStyle
'      doc.PageFooter.RenderText.Style.TextAlignHorz = C1.C1PrintDocument.AlignHorzEnum.Right
'      doc.PageFooter.RenderText.Style.TextAlignVert = C1.C1PrintDocument.AlignVertEnum.Bottom
'      doc.PageFooter.RenderText.Text = "Page [@@PageNo@@] of [@@PageCount@@]"

'      doc.StartDoc() 'start rendering
'      doc.RenderBlockControlImage(Me.panModel)
'      doc.RenderBlockControlImage(Me.panRatingCriteriaHeader)
'      doc.RenderBlockControlImage(Me.panRatingCriteria)
'      doc.RenderBlockControlImage(Me.panCompressorHeader)
'      doc.RenderBlockControlImage(Me.panCompressor)

'      'page return				
'      Dim whiteImage As Image  'image is used to fill space at the end of a page
'      'implemented to function as a page return
'      whiteImage = Image.FromFile(AppInfo.AppFolderPath & "Images\whitebox.gif")
'      doc.RenderBlockImage(whiteImage, 3, doc.AvailableBlockFlowHeight, printStyle)
'      doc.RenderBlockControlImage(Me.panCondenserHeader)
'      doc.RenderBlockControlImage(Me.panCondenser)

'      'page return		
'      doc.RenderBlockImage(whiteImage, 3, doc.AvailableBlockFlowHeight, printStyle)
'      doc.RenderBlockControlImage(Me.panEvaporatorHeader)
'      doc.RenderBlockControlImage(Me.panEvaporator)

'      If Not (Me.dgrC1Results.DataSource Is Nothing) Then
'         'page return
'         doc.RenderBlockImage(whiteImage, 3, doc.AvailableBlockFlowHeight, printStyle)
'         doc.RenderBlockControlSmart(Me.dgrC1Results)
'      End If
'      doc.EndDoc() 'stop rendering

'      Dim formPreview As New C1PrintPreviewForm 'create instance form to preview before printing
'      formPreview.C1PrintPreview1.Document = doc 'set the form's document to the document just created

'      Me.Cursor = Windows.Forms.Cursors.Default

'      formPreview.ShowDialog() 'can't have mdiparent otherwise error occurs
'      formPreview.Close()
'   End Sub

'   Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveMenuItem.Click
'      SaveControls()
'   End Sub

'   Private Sub RevisionWaterCooledChillerRatingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveAsRevisionMenuItem.Click
'      SaveControls(True)
'   End Sub

'   Private Sub SaveAsNewWaterCooledChillerRatingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveAsMenuItem.Click
'      SaveControls(False, True)
'   End Sub

'   Private Sub ConvertWaterCooledChillerRatingToEquipmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles convertToEquipmentMenuItem.Click
'      SaveControls(False, False, False, True)
'   End Sub

'   Private Sub chkNewCoefficients_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNewCoefficients.CheckedChanged
'      FillCompressorListBoxes()
'      SetCompressors()
'   End Sub

 
End Class
'7928

