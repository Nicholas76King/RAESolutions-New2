Option Strict Off
Option Explicit On 

Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.Compatibility
Imports Data = System.Data
Imports Process = System.Diagnostics.Process
Imports CNull = Rae.ConvertNull
Imports DataAgent = Rae.RaeSolutions.Business.Agents.AirHandlerDataAgent
Imports ReferenceData = Rae.RaeSolutions.Business.Entities.AirHandlerReferenceData
Imports Rae.RaeSolutions.Business
Imports Consts = Rae.RaeSolutions.Business.Intelligence.AirHandlerConstants
Imports Rae.RaeSolutions.Business.Intelligence.AirHandlerConstants.Weights
Imports Rae.RaeSolutions.Business.Intelligence.AirHandlerConstants.Multipliers
Imports Rae.RaeSolutions.Business.Intelligence.AirHandlerConstants.Costs
Imports System.Text
Imports System.Math
Imports System.Data.OleDb
Imports System.Data
Imports Rae.RaeSolutions.Business.Entities
imports rae.solutions
Imports System.Collections.Generic


Public Class form_unit_info
   Inherits System.Windows.Forms.Form


#Region "My Globals"

   'cj - used to ignore event handlers until all controls are initialized
   Private IsInitializing As Boolean = True

   'cj - name of project info form
   Private frmProjectName As String = "form_project_info"

   Private sectionTextChangedCounter As Integer = 0

   Private _daddy As form_project_info

   Private _airHandlerID As Integer = -2

   Private airHandlerIndex As Integer = -2

   'stores the order index of the selected section drawing
   Private selectedSectionDrawingOrderIndex As Integer = -1

   Private _numDoors As Integer = 0
   Private _numAirSeals As Integer = 0
   Private _numSS1s As Integer = 0
   Private _numSS2s As Integer = 0
   Private _numSS3s As Integer = 0
   Private _numUS1s As Integer = 0

   Private pricingAuthorized As Boolean
   Friend WithEvents picGasHeater As System.Windows.Forms.PictureBox
   Friend WithEvents lblGasHeater As System.Windows.Forms.Label
   Friend WithEvents panGasHeaterContainer As System.Windows.Forms.Panel
   Friend WithEvents panGasHeater As System.Windows.Forms.Panel
   Friend WithEvents radC5TypeModulating As System.Windows.Forms.RadioButton
   Friend WithEvents radC5TypeTwoStage As System.Windows.Forms.RadioButton
   Friend WithEvents cboC5Power As System.Windows.Forms.ComboBox
   Friend WithEvents lblC5Type As System.Windows.Forms.Label
   Friend WithEvents lblC5Power As System.Windows.Forms.Label
   Friend WithEvents lblGasHeaterOrderIndex As System.Windows.Forms.Label
   Public WithEvents lblGasHeaterCost As System.Windows.Forms.Label
   Public WithEvents Label34 As System.Windows.Forms.Label
   Friend WithEvents lblC5TypeValue As System.Windows.Forms.Label

   Friend Const TSIMultiplier As Single = 0.495

   'stores cost and weight of item
   Private Structure CostWeight
      Dim cost As Decimal
      Dim weight As Single

      Public Sub Initialize()
         cost = 0
         weight = 0
      End Sub
   End Structure

#End Region


#Region "Properties"

   'allows this form to reference the form that created it
   Friend Property Daddy() As form_project_info
      Get
         Return _daddy
      End Get
      Set(ByVal Value As form_project_info)
         _daddy = Value
      End Set
   End Property


   'Air handler id, indicates which air handler is being modified
   Property AirHandlerID() As Integer
      Get
         Return _airHandlerID
      End Get
      Set(ByVal Value As Integer)
         _airHandlerID = Value
      End Set
   End Property

   Property NumDoors() As Integer
      Get
         Return _numDoors
      End Get
      Set(ByVal Value As Integer)
         _numDoors = Value
         Me.txt_doors.Text = _numDoors.ToString
      End Set
   End Property

   Property NumAirSeals() As Integer
      Get
         Return _numAirSeals
      End Get
      Set(ByVal Value As Integer)
         _numAirSeals = Value
         Me.lblAirSealQuantity.Text = _numAirSeals.ToString
      End Set
   End Property

   Property NumSS1s() As Integer
      Get
         Return _numSS1s
      End Get
      Set(ByVal Value As Integer)
         _numSS1s = Value
         Me.lblSS1Quantity.Text = _numSS1s.ToString
      End Set
   End Property

   Property NumSS2s() As Integer
      Get
         Return _numSS2s
      End Get
      Set(ByVal Value As Integer)
         _numSS2s = Value
         Me.lblSS2Quantity.Text = _numSS2s.ToString
      End Set
   End Property

   Property NumSS3s() As Integer
      Get
         Return _numSS3s
      End Get
      Set(ByVal Value As Integer)
         _numSS3s = Value
         Me.lblSS3Quantity.Text = _numSS3s.ToString
      End Set
   End Property

   Property NumUS1s() As Integer
      Get
         Return _numUS1s
      End Get
      Set(ByVal Value As Integer)
         _numUS1s = Value
         Me.lblUS1Quantity.Text = _numUS1s.ToString
      End Set
   End Property

#End Region


   ''' <summary>Abbreviations for the sections in the air handler
   ''' </summary>
   ''' <remarks>Enumerated text must match column names in section dimensions database table.
   ''' The enumerated text is used to retrieve column values.
   ''' </remarks>
   Public Enum sectionAbbreviation As Integer
      MB1
      BLD1
      FF1
      FF2
      PF1
      HF1
      HF2
      C1
      C2
      C3
      C5
      SS1
      SS2
      SS3
      D1
      D2
      US1
   End Enum


#Region " Windows Form Designer generated code"

   Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      IsInitializing = False
   End Sub

   'Form overrides dispose to clean up the component list.
   Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
      If Disposing Then
         If Not components Is Nothing Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(Disposing)
   End Sub
   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer
   Public ToolTip1 As System.Windows.Forms.ToolTip
   Public WithEvents _SSTab2_TabPage0 As System.Windows.Forms.TabPage
   Public WithEvents lbl_unit_sections As System.Windows.Forms.Label
   Public WithEvents Line1 As System.Windows.Forms.Label
   Public WithEvents _SSTab2_TabPage1 As System.Windows.Forms.TabPage
   Public WithEvents _cbo_mixing_box_1 As System.Windows.Forms.ComboBox
   Public WithEvents _ck_MB1_al_1 As System.Windows.Forms.CheckBox
   Public WithEvents _ck_MB1_gal_1 As System.Windows.Forms.CheckBox
   Public WithEvents _cbo_ff_sets_2 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_ff_2 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_pre_sets_2 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_pre_ff_2 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_ff_sets_1 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_ff_1 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_pre_sets_1 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_pre_ff_1 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_ff_sets_0 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_ff_0 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_pre_sets_0 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_pre_ff_0 As System.Windows.Forms.ComboBox
   Public WithEvents _ck_MB1_gal_0 As System.Windows.Forms.CheckBox
   Public WithEvents _ck_MB1_al_0 As System.Windows.Forms.CheckBox
   Public WithEvents _cbo_mixing_box_0 As System.Windows.Forms.ComboBox
   Public WithEvents _lbl_MB1_cost_1 As System.Windows.Forms.Label
   Public WithEvents _lbl_ff_weight_2 As System.Windows.Forms.Label
   Public WithEvents _lbl_ff_weight_1 As System.Windows.Forms.Label
   Public WithEvents _lbl_ff_weight_0 As System.Windows.Forms.Label
   Public WithEvents _lbl_ff_cost_2 As System.Windows.Forms.Label
   Public WithEvents _lbl_ff_cost_1 As System.Windows.Forms.Label
   Public WithEvents _lbl_ff_cost_0 As System.Windows.Forms.Label
   Public WithEvents _lbl_ff_2 As System.Windows.Forms.Label
   Public WithEvents _lbl_ff_1 As System.Windows.Forms.Label
   Public WithEvents _lbl_ff_0 As System.Windows.Forms.Label
   Public WithEvents _lbl_MB1_cost_0 As System.Windows.Forms.Label
   Public WithEvents _SSTab2_TabPage2 As System.Windows.Forms.TabPage
   Public WithEvents _lbl_fan_cost_0 As System.Windows.Forms.Label
   Public WithEvents _lbl_hp_0 As System.Windows.Forms.Label
   Public WithEvents _lbl_rpm_0 As System.Windows.Forms.Label
   Public WithEvents _lbl_motor_info_0 As System.Windows.Forms.Label
   Public WithEvents _lbl_enclosure_0 As System.Windows.Forms.Label
   Public WithEvents _lbl_eff_0 As System.Windows.Forms.Label
   Public WithEvents _lbl_fan_type_0 As System.Windows.Forms.Label
   Public WithEvents _lbl_fan_info_0 As System.Windows.Forms.Label
   Public WithEvents _lbl_motor_weight_0 As System.Windows.Forms.Label
   Public WithEvents _lbl_fan_weight_0 As System.Windows.Forms.Label
   Public WithEvents _lbl_iso_cost_0 As System.Windows.Forms.Label
   Public WithEvents _lbl_iso_weight_0 As System.Windows.Forms.Label
   Public WithEvents _lbl_iso_weight_1 As System.Windows.Forms.Label
   Public WithEvents _lbl_iso_cost_1 As System.Windows.Forms.Label
   Public WithEvents _lbl_fan_weight_1 As System.Windows.Forms.Label
   Public WithEvents _lbl_motor_weight_1 As System.Windows.Forms.Label
   Public WithEvents _lbl_fan_cost_1 As System.Windows.Forms.Label
   Public WithEvents _lbl_fan_info_1 As System.Windows.Forms.Label
   Public WithEvents _lbl_motor_cost_1 As System.Windows.Forms.Label
   Public WithEvents _lbl_fan_type_1 As System.Windows.Forms.Label
   Public WithEvents _lbl_eff_1 As System.Windows.Forms.Label
   Public WithEvents _lbl_enclosure_1 As System.Windows.Forms.Label
   Public WithEvents _lbl_motor_info_1 As System.Windows.Forms.Label
   Public WithEvents _lbl_rpm_1 As System.Windows.Forms.Label
   Public WithEvents _lbl_hp_1 As System.Windows.Forms.Label
   Public WithEvents _lbl_iso_weight_2 As System.Windows.Forms.Label
   Public WithEvents _lbl_iso_cost_2 As System.Windows.Forms.Label
   Public WithEvents _lbl_fan_weight_2 As System.Windows.Forms.Label
   Public WithEvents _lbl_motor_weight_2 As System.Windows.Forms.Label
   Public WithEvents _lbl_fan_cost_2 As System.Windows.Forms.Label
   Public WithEvents _lbl_fan_info_2 As System.Windows.Forms.Label
   Public WithEvents _lbl_motor_cost_2 As System.Windows.Forms.Label
   Public WithEvents _lbl_fan_type_2 As System.Windows.Forms.Label
   Public WithEvents _lbl_eff_2 As System.Windows.Forms.Label
   Public WithEvents _lbl_enclosure_2 As System.Windows.Forms.Label
   Public WithEvents _lbl_motor_info_2 As System.Windows.Forms.Label
   Public WithEvents _lbl_rpm_2 As System.Windows.Forms.Label
   Public WithEvents _lbl_hp_2 As System.Windows.Forms.Label
   Public WithEvents _cbo_fan_type_2 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_fan_class_2 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_fan_size_2 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_drive_type_2 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_fan_iso_2 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_fan_type_1 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_fan_class_1 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_fan_size_1 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_drive_type_1 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_fan_iso_1 As System.Windows.Forms.ComboBox
   Public WithEvents _ck_odp_2 As System.Windows.Forms.CheckBox
   Public WithEvents _ck_high_2 As System.Windows.Forms.CheckBox
   Public WithEvents _ck_odp_1 As System.Windows.Forms.CheckBox
   Public WithEvents _ck_high_1 As System.Windows.Forms.CheckBox
   Public WithEvents _ck_premium_1 As System.Windows.Forms.CheckBox
   Public WithEvents _cbo_fan_type_0 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_fan_class_0 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_fan_size_0 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_drive_type_0 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_fan_iso_0 As System.Windows.Forms.ComboBox
   Public WithEvents _ck_high_0 As System.Windows.Forms.CheckBox
   Public WithEvents _ck_odp_0 As System.Windows.Forms.CheckBox
   Public WithEvents _cbo_hp_0 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_rpm_0 As System.Windows.Forms.ComboBox
   Public WithEvents _ck_premium_0 As System.Windows.Forms.CheckBox
   Public WithEvents _ck_tefc_0 As System.Windows.Forms.CheckBox
   Public WithEvents _ck_tefc_1 As System.Windows.Forms.CheckBox
   Public WithEvents _cbo_rpm_1 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_hp_1 As System.Windows.Forms.ComboBox
   Public WithEvents _ck_tefc_2 As System.Windows.Forms.CheckBox
   Public WithEvents _ck_premium_2 As System.Windows.Forms.CheckBox
   Public WithEvents _cbo_rpm_2 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_hp_2 As System.Windows.Forms.ComboBox
   Public WithEvents _SSTab2_TabPage3 As System.Windows.Forms.TabPage
   Public WithEvents lbl_C3_min_stages_val As System.Windows.Forms.Label
   Public WithEvents lbl_C3_extra_stages As System.Windows.Forms.Label
   Public WithEvents lbl_C3_op_temp_1 As System.Windows.Forms.Label
   Public WithEvents lbl_C3_op_temp As System.Windows.Forms.Label
   Public WithEvents lbl_C3_min_stages As System.Windows.Forms.Label
   Public WithEvents lbl_C3_kw As System.Windows.Forms.Label
   Public WithEvents lbl_C3 As System.Windows.Forms.Label
   Public WithEvents lbl_heater_cost As System.Windows.Forms.Label
   Public WithEvents _lbl_coil_cost_4 As System.Windows.Forms.Label
   Public WithEvents _lbl_coil_cost_3 As System.Windows.Forms.Label
   Public WithEvents _lbl_coil_cost_2 As System.Windows.Forms.Label
   Public WithEvents _lbl_coil_cost_1 As System.Windows.Forms.Label
   Public WithEvents _lbl_coil_cost_0 As System.Windows.Forms.Label
   Public WithEvents _lbl_tube_thickness_4 As System.Windows.Forms.Label
   Public WithEvents _lbl_fin_thickness_4 As System.Windows.Forms.Label
   Public WithEvents _lbl_num_fins_4 As System.Windows.Forms.Label
   Public WithEvents _lbl_num_rows_4 As System.Windows.Forms.Label
   Public WithEvents _lbl_casing_4 As System.Windows.Forms.Label
   Public WithEvents _lbl_fin_mtl_4 As System.Windows.Forms.Label
   Public WithEvents _lbl_coil_type_4 As System.Windows.Forms.Label
   Public WithEvents _lbl_tube_thickness_3 As System.Windows.Forms.Label
   Public WithEvents _lbl_fin_thickness_3 As System.Windows.Forms.Label
   Public WithEvents _lbl_num_fins_3 As System.Windows.Forms.Label
   Public WithEvents _lbl_num_rows_3 As System.Windows.Forms.Label
   Public WithEvents _lbl_casing_3 As System.Windows.Forms.Label
   Public WithEvents _lbl_fin_mtl_3 As System.Windows.Forms.Label
   Public WithEvents _lbl_coil_type_3 As System.Windows.Forms.Label
   Public WithEvents _lbl_tube_thickness_2 As System.Windows.Forms.Label
   Public WithEvents _lbl_fin_thickness_2 As System.Windows.Forms.Label
   Public WithEvents _lbl_num_fins_2 As System.Windows.Forms.Label
   Public WithEvents _lbl_num_rows_2 As System.Windows.Forms.Label
   Public WithEvents _lbl_casing_2 As System.Windows.Forms.Label
   Public WithEvents _lbl_fin_mtl_2 As System.Windows.Forms.Label
   Public WithEvents _lbl_coil_type_2 As System.Windows.Forms.Label
   Public WithEvents _lbl_tube_thickness_1 As System.Windows.Forms.Label
   Public WithEvents _lbl_fin_thickness_1 As System.Windows.Forms.Label
   Public WithEvents _lbl_num_fins_1 As System.Windows.Forms.Label
   Public WithEvents _lbl_num_rows_1 As System.Windows.Forms.Label
   Public WithEvents _lbl_casing_1 As System.Windows.Forms.Label
   Public WithEvents _lbl_fin_mtl_1 As System.Windows.Forms.Label
   Public WithEvents _lbl_coil_type_1 As System.Windows.Forms.Label
   Public WithEvents _lbl_tube_thickness_0 As System.Windows.Forms.Label
   Public WithEvents _lbl_fin_thickness_0 As System.Windows.Forms.Label
   Public WithEvents _lbl_num_fins_0 As System.Windows.Forms.Label
   Public WithEvents _lbl_num_rows_0 As System.Windows.Forms.Label
   Public WithEvents _lbl_casing_0 As System.Windows.Forms.Label
   Public WithEvents _lbl_fin_mtl_0 As System.Windows.Forms.Label
   Public WithEvents _lbl_coil_type_0 As System.Windows.Forms.Label
   Public WithEvents ck_C3_scr As System.Windows.Forms.CheckBox
   Public WithEvents ck_C3_disconnect As System.Windows.Forms.CheckBox
   Public WithEvents cbo_C3_extra_stages As System.Windows.Forms.ComboBox
   Public WithEvents cbo_C3_kw As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_tube_thickness_4 As System.Windows.Forms.ComboBox
   Public WithEvents _ck_gal_4 As System.Windows.Forms.CheckBox
   Public WithEvents _cbo_fin_thickness_4 As System.Windows.Forms.ComboBox
   Public WithEvents _ck_cu_4 As System.Windows.Forms.CheckBox
   Public WithEvents _ck_al_4 As System.Windows.Forms.CheckBox
   Public WithEvents _cbo_fins_4 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_rows_4 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_tube_thickness_3 As System.Windows.Forms.ComboBox
   Public WithEvents _ck_gal_3 As System.Windows.Forms.CheckBox
   'Private WithEvents _ck_ss_3 As System.Windows.Forms.CheckBox
   Public WithEvents _cbo_fin_thickness_3 As System.Windows.Forms.ComboBox
   Public WithEvents _ck_cu_3 As System.Windows.Forms.CheckBox
   Public WithEvents _ck_al_3 As System.Windows.Forms.CheckBox
   Public WithEvents _cbo_fins_3 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_rows_3 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_tube_thickness_2 As System.Windows.Forms.ComboBox
   Public WithEvents _ck_gal_2 As System.Windows.Forms.CheckBox
   'Private WithEvents _ck_ss_2 As System.Windows.Forms.CheckBox
   Public WithEvents _cbo_fin_thickness_2 As System.Windows.Forms.ComboBox
   Public WithEvents _ck_cu_2 As System.Windows.Forms.CheckBox
   Public WithEvents _ck_al_2 As System.Windows.Forms.CheckBox
   Public WithEvents _cbo_fins_2 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_rows_2 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_tube_thickness_1 As System.Windows.Forms.ComboBox
   Public WithEvents _ck_gal_1 As System.Windows.Forms.CheckBox
   'Private WithEvents _ck_ss_1 As System.Windows.Forms.CheckBox
   Public WithEvents _cbo_fin_thickness_1 As System.Windows.Forms.ComboBox
   Public WithEvents _ck_cu_1 As System.Windows.Forms.CheckBox
   Public WithEvents _ck_al_1 As System.Windows.Forms.CheckBox
   Public WithEvents _cbo_fins_1 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_rows_1 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_tube_thickness_0 As System.Windows.Forms.ComboBox
   Public WithEvents _ck_gal_0 As System.Windows.Forms.CheckBox
   Public WithEvents _ck_ss_0 As System.Windows.Forms.CheckBox
   Public WithEvents _ck_ss_1 As System.Windows.Forms.CheckBox
   Public WithEvents _ck_ss_2 As System.Windows.Forms.CheckBox
   Public WithEvents _ck_ss_3 As System.Windows.Forms.CheckBox
   Public WithEvents _ck_ss_4 As System.Windows.Forms.CheckBox
   Public WithEvents _cbo_fin_thickness_0 As System.Windows.Forms.ComboBox
   Public WithEvents _ck_cu_0 As System.Windows.Forms.CheckBox
   Public WithEvents _ck_al_0 As System.Windows.Forms.CheckBox
   Public WithEvents _cbo_fins_0 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_rows_0 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_coil_type_0 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_coil_type_1 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_coil_type_2 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_coil_type_3 As System.Windows.Forms.ComboBox
   Public WithEvents _cbo_coil_type_4 As System.Windows.Forms.ComboBox
   Public WithEvents _SSTab2_TabPage4 As System.Windows.Forms.TabPage
   Public WithEvents lbl_discharge As System.Windows.Forms.Label
   Public WithEvents lbl_ATT_sound_att As System.Windows.Forms.Label
   Public WithEvents lbl_base As System.Windows.Forms.Label
   Public WithEvents lbl_doors As System.Windows.Forms.Label
   Public WithEvents lbl_D1_grating_cost As System.Windows.Forms.Label
   Public WithEvents lbl_bld1_cost As System.Windows.Forms.Label
   Public WithEvents ck_D1_grating As System.Windows.Forms.CheckBox
   Public WithEvents ck_ATT_5 As System.Windows.Forms.CheckBox
   Public WithEvents ck_ATT_4 As System.Windows.Forms.CheckBox
   Public WithEvents ck_ATT_3 As System.Windows.Forms.CheckBox
   Public WithEvents txt_doors As System.Windows.Forms.TextBox
   Public WithEvents ck_ATT As System.Windows.Forms.CheckBox
   Public WithEvents cmd_close_2 As System.Windows.Forms.Button
   Public WithEvents _SSTab2_TabPage5 As System.Windows.Forms.TabPage
   Public WithEvents SSTab2 As System.Windows.Forms.TabControl
   Public WithEvents cbo_coil_type As Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray
   Public WithEvents cbo_drive_type As Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray
   Public WithEvents cbo_fan_class As Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray
   Public WithEvents cbo_fan_iso As Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray
   Public WithEvents cbo_fan_size As Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray
   Public WithEvents cbo_fan_type As Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray
   Public WithEvents cbo_ff As Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray
   Public WithEvents cbo_ff_sets As Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray
   Public WithEvents cbo_fin_thickness As Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray
   Public WithEvents cbo_fins As Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray
   Public WithEvents cbo_hp As Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray
   Public WithEvents cbo_mixing_box As Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray
   Public WithEvents cbo_pre_ff As Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray
   Public WithEvents cbo_pre_sets As Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray
   Public WithEvents cbo_rows As Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray
   Public WithEvents cbo_rpm As Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray
   Public WithEvents cbo_tube_thickness As Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray
   Public WithEvents ck_MB1_al As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
   Public WithEvents ck_MB1_gal As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
   Public WithEvents ck_al As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
   Public WithEvents ck_cu As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
   Public WithEvents ck_ff_sets As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
   Public WithEvents ck_gal As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
   Public WithEvents ck_high As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
   Public WithEvents ck_odp As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
   Public WithEvents ck_pre_sets As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
   Public WithEvents ck_premium As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
   Public WithEvents ck_ss As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
   Public WithEvents ck_tefc As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
   Public WithEvents lbl_MB1_cost As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
   Public WithEvents lbl_casing As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
   Public WithEvents lbl_coil_cost As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
   Public WithEvents lbl_coil_type As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
   Public WithEvents lbl_eff As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
   Public WithEvents lbl_enclosure As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
   Public WithEvents lbl_fan_cost As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
   Public WithEvents lbl_fan_info As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
   Public WithEvents lbl_fan_type As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
   Public WithEvents lbl_fan_weight As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
   Public WithEvents lbl_ff As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
   Public WithEvents lbl_ff_cost As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
   Public WithEvents lbl_ff_weight As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
   Public WithEvents lbl_fin_mtl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
   Public WithEvents lbl_fin_thickness As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
   Public WithEvents lbl_hp As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
   Public WithEvents lbl_iso_cost As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
   Public WithEvents lbl_iso_weight As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
   Public WithEvents lbl_motor_cost As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
   Public WithEvents lbl_motor_info As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
   Public WithEvents lbl_motor_weight As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
   Public WithEvents lbl_num_fins As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
   Public WithEvents lbl_num_rows As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
   Public WithEvents lbl_rpm As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
   Public WithEvents lbl_tube_thickness As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.
   'Do not modify it using the code editor.
   Public WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents btnClose As System.Windows.Forms.Button
   Friend WithEvents lblFanWeightLabel1 As System.Windows.Forms.Label
   Friend WithEvents lblFanCostLabel1 As System.Windows.Forms.Label
   Friend WithEvents lblMotorWeightLabel1 As System.Windows.Forms.Label
   Friend WithEvents lblMotorCostLabel2 As System.Windows.Forms.Label
   Friend WithEvents lblMotorCostLabel3 As System.Windows.Forms.Label
   Friend WithEvents lblMotorWeightLabel2 As System.Windows.Forms.Label
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents lblFanCostLabel2 As System.Windows.Forms.Label
   Friend WithEvents lblFanCostLabel3 As System.Windows.Forms.Label
   Friend WithEvents lblFanIsolator0 As System.Windows.Forms.Label
   Friend WithEvents lblFanDrive0 As System.Windows.Forms.Label
   Friend WithEvents lblFanSize0 As System.Windows.Forms.Label
   Friend WithEvents lblFanClass0 As System.Windows.Forms.Label
   Friend WithEvents lblFanType0 As System.Windows.Forms.Label
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents Label12 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents lblNumFilterSpares3 As System.Windows.Forms.Label
   Friend WithEvents lblNumFilterSpares2 As System.Windows.Forms.Label
   Friend WithEvents lblNumFilterSpares1 As System.Windows.Forms.Label
   Friend WithEvents lblNumSpareSets6 As System.Windows.Forms.Label
   Friend WithEvents lblNumSpareSets5 As System.Windows.Forms.Label
   Friend WithEvents lblNumSpareSets4 As System.Windows.Forms.Label
   Friend WithEvents panMixingBox2 As System.Windows.Forms.Panel
   Friend WithEvents panMixingBox1 As System.Windows.Forms.Panel
   Friend WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents Label14 As System.Windows.Forms.Label
   Friend WithEvents Label15 As System.Windows.Forms.Label
   Friend WithEvents Label17 As System.Windows.Forms.Label
   Friend WithEvents Label18 As System.Windows.Forms.Label
   Friend WithEvents Label21 As System.Windows.Forms.Label
   Friend WithEvents Label22 As System.Windows.Forms.Label
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents Label23 As System.Windows.Forms.Label
   Friend WithEvents Label24 As System.Windows.Forms.Label
   Friend WithEvents Label25 As System.Windows.Forms.Label
   Friend WithEvents Label26 As System.Windows.Forms.Label
   Friend WithEvents Label27 As System.Windows.Forms.Label
   Friend WithEvents Panel3 As System.Windows.Forms.Panel
   Friend WithEvents lblSS1Quantity As System.Windows.Forms.Label
   Friend WithEvents lblSS2Quantity As System.Windows.Forms.Label
   Friend WithEvents lblSS3Quantity As System.Windows.Forms.Label
   Friend WithEvents lblBLD1Quantity As System.Windows.Forms.Label
   Friend WithEvents lblUS1Quantity As System.Windows.Forms.Label
   Friend WithEvents Panel4 As System.Windows.Forms.Panel
   Friend WithEvents Panel5 As System.Windows.Forms.Panel
   Friend WithEvents panSectionQuantities As System.Windows.Forms.Panel
   Friend WithEvents Panel6 As System.Windows.Forms.Panel
   Friend WithEvents Label19 As System.Windows.Forms.Label
   Friend WithEvents Label28 As System.Windows.Forms.Label
   Friend WithEvents Panel7 As System.Windows.Forms.Panel
   Friend WithEvents Label29 As System.Windows.Forms.Label
   Friend WithEvents lblAirSealQuantity As System.Windows.Forms.Label
   Friend WithEvents Panel8 As System.Windows.Forms.Panel
    ''Friend WithEvents dgrC1Select As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents conSelect As System.Data.OleDb.OleDbConnection
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents lllCatalog As System.Windows.Forms.LinkLabel
   Friend WithEvents panDropSections As System.Windows.Forms.Panel
   Friend WithEvents picMixingBox As System.Windows.Forms.PictureBox
   Friend WithEvents picAirBlender As System.Windows.Forms.PictureBox
   Friend WithEvents picFilter As System.Windows.Forms.PictureBox
   Friend WithEvents picPreFilterBag As System.Windows.Forms.PictureBox
   Friend WithEvents picBlank As System.Windows.Forms.PictureBox
   Friend WithEvents panDragSections As System.Windows.Forms.Panel
   Friend WithEvents lblMixingBox As System.Windows.Forms.Label
   Friend WithEvents lblFilter As System.Windows.Forms.Label
   Friend WithEvents lblPreFilterBag As System.Windows.Forms.Label
   Friend WithEvents dadSection As System.Data.OleDb.OleDbDataAdapter
   Friend WithEvents OleDbConnection1 As System.Data.OleDb.OleDbConnection
    ''Friend WithEvents dgrC1SectionInfo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnMoveRight As System.Windows.Forms.Button
   Friend WithEvents btnMoveLeft As System.Windows.Forms.Button
   Friend WithEvents btnDelete As System.Windows.Forms.Button
   Friend WithEvents picPlenumFan As System.Windows.Forms.PictureBox
   Friend WithEvents lblAirBlender As System.Windows.Forms.Label
   Friend WithEvents lblPlenumFan As System.Windows.Forms.Label
   Friend WithEvents picHouseFan1 As System.Windows.Forms.PictureBox
   Friend WithEvents lblHouseFan1 As System.Windows.Forms.Label
   Friend WithEvents picHouseFan2 As System.Windows.Forms.PictureBox
   Friend WithEvents lblHouseFan2 As System.Windows.Forms.Label
   Friend WithEvents picHeatingCoil As System.Windows.Forms.PictureBox
   Friend WithEvents lblCoil1 As System.Windows.Forms.Label
   Friend WithEvents lblCoolingCoil As System.Windows.Forms.Label
   Friend WithEvents lblElectricHeater As System.Windows.Forms.Label
   Friend WithEvents picSpace1 As System.Windows.Forms.PictureBox
   Friend WithEvents picSpace2 As System.Windows.Forms.PictureBox
   Friend WithEvents picSpace3 As System.Windows.Forms.PictureBox
   Friend WithEvents picDischarge1 As System.Windows.Forms.PictureBox
   Friend WithEvents picDischarge2 As System.Windows.Forms.PictureBox
   Friend WithEvents lblSpace1 As System.Windows.Forms.Label
   Friend WithEvents lblSpace2 As System.Windows.Forms.Label
   Friend WithEvents lblSpace3 As System.Windows.Forms.Label
   Friend WithEvents lblDischarge1 As System.Windows.Forms.Label
   Friend WithEvents lblDischarge2 As System.Windows.Forms.Label
   Friend WithEvents picElectricHeater As System.Windows.Forms.PictureBox
   Friend WithEvents picCoolingCoil As System.Windows.Forms.PictureBox
   Friend WithEvents picSplit As System.Windows.Forms.PictureBox
   Friend WithEvents lblSplit As System.Windows.Forms.Label
   Friend WithEvents dadAirHandler As System.Data.OleDb.OleDbDataAdapter
   Friend WithEvents lblMB1Header As System.Windows.Forms.Label
   Friend WithEvents lblMB1Air As System.Windows.Forms.Label
   Friend WithEvents lblMB1Casing As System.Windows.Forms.Label
   Friend WithEvents lblMB1CostLabel As System.Windows.Forms.Label
   Friend WithEvents lblMB2Header As System.Windows.Forms.Label
   Friend WithEvents lblMB2CostLabel As System.Windows.Forms.Label
   Friend WithEvents lblMB2Casing As System.Windows.Forms.Label
   Friend WithEvents lblMB2Air As System.Windows.Forms.Label
   Friend WithEvents panMB1Container As System.Windows.Forms.Panel
   Friend WithEvents panMB2Container As System.Windows.Forms.Panel
   Friend WithEvents panSectionsSummaryHeader As System.Windows.Forms.Panel
   Friend WithEvents Panel9 As System.Windows.Forms.Panel
   Friend WithEvents Panel10 As System.Windows.Forms.Panel
   Friend WithEvents Panel11 As System.Windows.Forms.Panel
   Friend WithEvents panFF1Prefilter As System.Windows.Forms.Panel
   Friend WithEvents panFF1FinalFilter As System.Windows.Forms.Panel
   Friend WithEvents lblFF1FinalFilter As System.Windows.Forms.Label
   Friend WithEvents lblFF1Prefilter As System.Windows.Forms.Label
   Friend WithEvents panFF2Prefilter As System.Windows.Forms.Panel
   Friend WithEvents lblFF2Prefilter As System.Windows.Forms.Label
   Friend WithEvents panFF2FinalFilter As System.Windows.Forms.Panel
   Friend WithEvents lblFF2FinalFilter As System.Windows.Forms.Label
   Friend WithEvents panFF3PreFilter As System.Windows.Forms.Panel
   Friend WithEvents lblFF3Prefilter As System.Windows.Forms.Label
   Friend WithEvents panFF3FinalFilter As System.Windows.Forms.Panel
   Friend WithEvents lblFF3FinalFilter As System.Windows.Forms.Label
   Friend WithEvents panFF1Container As System.Windows.Forms.Panel
   Friend WithEvents panFF2Container As System.Windows.Forms.Panel
   Friend WithEvents panFF3Container As System.Windows.Forms.Panel
   Friend WithEvents lblMB1OrderIndex As System.Windows.Forms.Label
   Friend WithEvents lblMB2OrderIndex As System.Windows.Forms.Label
   Friend WithEvents lblFF1OrderIndex As System.Windows.Forms.Label
   Friend WithEvents lblFF3OrderIndex As System.Windows.Forms.Label
   Friend WithEvents lblFF2OrderIndex As System.Windows.Forms.Label
   Friend WithEvents lblFF3CostLabel As System.Windows.Forms.Label
   Friend WithEvents lblFF2CostLabel As System.Windows.Forms.Label
   Friend WithEvents lblFF1CostLabel As System.Windows.Forms.Label
   Friend WithEvents panFan1Container As System.Windows.Forms.Panel
   Friend WithEvents lblFan1OrderIndex As System.Windows.Forms.Label
   Friend WithEvents panFan1Motor As System.Windows.Forms.Panel
   Friend WithEvents panFan1Fan As System.Windows.Forms.Panel
   Friend WithEvents lblMotorCostLabel1 As System.Windows.Forms.Label
   Public WithEvents _lbl_motor_cost_0 As System.Windows.Forms.Label
   Friend WithEvents lblIsolatorCostLabel1 As System.Windows.Forms.Label
   Friend WithEvents panFan2Container As System.Windows.Forms.Panel
   Friend WithEvents panFan2Motor As System.Windows.Forms.Panel
   Friend WithEvents panFan2Fan As System.Windows.Forms.Panel
   Friend WithEvents lblIsolatorCostLabel2 As System.Windows.Forms.Label
   Friend WithEvents panFan3Container As System.Windows.Forms.Panel
   Friend WithEvents panFan3Motor As System.Windows.Forms.Panel
   Friend WithEvents lblIsolatorCostLabel3 As System.Windows.Forms.Label
   Friend WithEvents panFan3Fan As System.Windows.Forms.Panel
   Friend WithEvents lblFan2OrderIndex As System.Windows.Forms.Label
   Friend WithEvents lblFan3OrderIndex As System.Windows.Forms.Label
   Friend WithEvents panCoil1Container As System.Windows.Forms.Panel
   Friend WithEvents panCoil1 As System.Windows.Forms.Panel
   Friend WithEvents panCoil2Container As System.Windows.Forms.Panel
   Friend WithEvents panCoil2 As System.Windows.Forms.Panel
   Friend WithEvents lblCoil2OrderIndex As System.Windows.Forms.Label
   Friend WithEvents lblCoil1OrderIndex As System.Windows.Forms.Label
   Friend WithEvents panCoil3Container As System.Windows.Forms.Panel
   Friend WithEvents panCoil3 As System.Windows.Forms.Panel
   Friend WithEvents lblCoil3OrderIndex As System.Windows.Forms.Label
   Friend WithEvents panC3Container As System.Windows.Forms.Panel
   Friend WithEvents panC3 As System.Windows.Forms.Panel
   Friend WithEvents panCoil4Container As System.Windows.Forms.Panel
   Friend WithEvents panCoil4 As System.Windows.Forms.Panel
   Friend WithEvents lblCoil4OrderIndex As System.Windows.Forms.Label
   Friend WithEvents panCoil5Container As System.Windows.Forms.Panel
   Friend WithEvents lblCoil5OrderIndex As System.Windows.Forms.Label
   Friend WithEvents panCoil5 As System.Windows.Forms.Panel
   Friend WithEvents lblC3OrderIndex As System.Windows.Forms.Label
   Friend WithEvents lblGratingCost As System.Windows.Forms.Label
   Friend WithEvents panDischargeContainer As System.Windows.Forms.Panel
   Friend WithEvents lblDischargeOrderIndex As System.Windows.Forms.Label
   Friend WithEvents lblCoil1Type As System.Windows.Forms.Label
   Friend WithEvents Label16 As System.Windows.Forms.Label
   Friend WithEvents Label20 As System.Windows.Forms.Label
   Friend WithEvents Label30 As System.Windows.Forms.Label
   Friend WithEvents Label31 As System.Windows.Forms.Label
   Friend WithEvents lblDischargeLocation As System.Windows.Forms.Label
   Friend WithEvents lblMB1CasingChkValue As System.Windows.Forms.Label
   Friend WithEvents lblMB2CasingChkValue As System.Windows.Forms.Label
   Friend WithEvents lblEfficiency1 As System.Windows.Forms.Label
   Friend WithEvents lblEnclosure1 As System.Windows.Forms.Label
   Friend WithEvents lblEfficiency2 As System.Windows.Forms.Label
   Friend WithEvents lblEnclosure2 As System.Windows.Forms.Label
   Friend WithEvents lblEfficiency3 As System.Windows.Forms.Label
   Friend WithEvents lblEnclosure3 As System.Windows.Forms.Label
   Friend WithEvents lblFinMaterial1 As System.Windows.Forms.Label
   Friend WithEvents lblFinMaterial2 As System.Windows.Forms.Label
   Friend WithEvents lblFinMaterial3 As System.Windows.Forms.Label
   Friend WithEvents lblFinMaterial4 As System.Windows.Forms.Label
   Friend WithEvents lblFinMaterial5 As System.Windows.Forms.Label
   Friend WithEvents lblCoilCasing1 As System.Windows.Forms.Label
   Friend WithEvents lblCoilCasing2 As System.Windows.Forms.Label
   Friend WithEvents lblCoilCasing3 As System.Windows.Forms.Label
   Friend WithEvents lblCoilCasing4 As System.Windows.Forms.Label
   Friend WithEvents lblCoilCasing5 As System.Windows.Forms.Label
   Friend WithEvents lblDischargeLocationChkValue As System.Windows.Forms.Label
   Friend WithEvents lblBaseMaterialChkValue As System.Windows.Forms.Label
   Friend WithEvents lblDragInstructions As System.Windows.Forms.Label
   Friend WithEvents btnSectionOptions As System.Windows.Forms.Button
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents Label32 As System.Windows.Forms.Label
   Friend WithEvents lblTag As System.Windows.Forms.Label
   Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
   Friend WithEvents DseProject1 As RaeSolutions.dseProject
   Friend WithEvents dadSectionDetails As System.Data.OleDb.OleDbDataAdapter
   Friend WithEvents OleDbSelectCommand3 As System.Data.OleDb.OleDbCommand
   Friend WithEvents OleDbInsertCommand3 As System.Data.OleDb.OleDbCommand
   Friend WithEvents OleDbUpdateCommand3 As System.Data.OleDb.OleDbCommand
   Friend WithEvents OleDbDeleteCommand3 As System.Data.OleDb.OleDbCommand
   Friend WithEvents Panel12 As System.Windows.Forms.Panel
   Friend WithEvents radD1Floor As System.Windows.Forms.RadioButton
   Friend WithEvents radD1EndWall As System.Windows.Forms.RadioButton
   Friend WithEvents radD1Ceiling As System.Windows.Forms.RadioButton
   Friend WithEvents btnPrintDrawing As System.Windows.Forms.Button
   Friend WithEvents Label33 As System.Windows.Forms.Label
   Friend WithEvents OleDbSelectCommand4 As System.Data.OleDb.OleDbCommand
   Friend WithEvents OleDbInsertCommand4 As System.Data.OleDb.OleDbCommand
   Friend WithEvents OleDbUpdateCommand4 As System.Data.OleDb.OleDbCommand
   Friend WithEvents OleDbDeleteCommand4 As System.Data.OleDb.OleDbCommand
   Friend WithEvents radBaseMaterialSheetMetal As System.Windows.Forms.RadioButton
   Friend WithEvents radBaseMaterialSteel As System.Windows.Forms.RadioButton
   Friend WithEvents OleDbSelectCommand1 As System.Data.OleDb.OleDbCommand
   Friend WithEvents OleDbInsertCommand1 As System.Data.OleDb.OleDbCommand
   Friend WithEvents OleDbUpdateCommand1 As System.Data.OleDb.OleDbCommand
   Friend WithEvents OleDbDeleteCommand1 As System.Data.OleDb.OleDbCommand
   Friend WithEvents AirHandlerData1 As Rae.RaeSolutions.Business.Entities.AirHandlerReferenceData

   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form_unit_info))
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.picMixingBox = New System.Windows.Forms.PictureBox
      Me.picDischarge2 = New System.Windows.Forms.PictureBox
      Me.picDischarge1 = New System.Windows.Forms.PictureBox
      Me.picSpace3 = New System.Windows.Forms.PictureBox
      Me.picSpace2 = New System.Windows.Forms.PictureBox
      Me.picSpace1 = New System.Windows.Forms.PictureBox
      Me.picElectricHeater = New System.Windows.Forms.PictureBox
      Me.picCoolingCoil = New System.Windows.Forms.PictureBox
      Me.picHeatingCoil = New System.Windows.Forms.PictureBox
      Me.picHouseFan2 = New System.Windows.Forms.PictureBox
      Me.picHouseFan1 = New System.Windows.Forms.PictureBox
      Me.picPlenumFan = New System.Windows.Forms.PictureBox
      Me.picPreFilterBag = New System.Windows.Forms.PictureBox
      Me.picFilter = New System.Windows.Forms.PictureBox
      Me.picAirBlender = New System.Windows.Forms.PictureBox
      Me.picSplit = New System.Windows.Forms.PictureBox
      Me.picGasHeater = New System.Windows.Forms.PictureBox
      Me.SSTab2 = New System.Windows.Forms.TabControl
      Me._SSTab2_TabPage0 = New System.Windows.Forms.TabPage
      Me.GroupBox1 = New System.Windows.Forms.GroupBox
        ''Me.dgrC1Select = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.AirHandlerData1 = New Rae.RaeSolutions.Business.Entities.AirHandlerReferenceData
      Me.Label1 = New System.Windows.Forms.Label
      Me._SSTab2_TabPage1 = New System.Windows.Forms.TabPage
      Me.btnPrintDrawing = New System.Windows.Forms.Button
      Me.GroupBox3 = New System.Windows.Forms.GroupBox
      Me.GroupBox2 = New System.Windows.Forms.GroupBox
      Me.btnSectionOptions = New System.Windows.Forms.Button
      Me.lblDragInstructions = New System.Windows.Forms.Label
      Me.btnDelete = New System.Windows.Forms.Button
      Me.btnMoveLeft = New System.Windows.Forms.Button
      Me.btnMoveRight = New System.Windows.Forms.Button
      Me.panDropSections = New System.Windows.Forms.Panel
      Me.panDragSections = New System.Windows.Forms.Panel
      Me.lblGasHeater = New System.Windows.Forms.Label
      Me.lblSplit = New System.Windows.Forms.Label
      Me.lblDischarge2 = New System.Windows.Forms.Label
      Me.lblDischarge1 = New System.Windows.Forms.Label
      Me.lblSpace3 = New System.Windows.Forms.Label
      Me.lblSpace2 = New System.Windows.Forms.Label
      Me.lblSpace1 = New System.Windows.Forms.Label
      Me.lblElectricHeater = New System.Windows.Forms.Label
      Me.lblCoolingCoil = New System.Windows.Forms.Label
      Me.lblCoil1 = New System.Windows.Forms.Label
      Me.lblHouseFan2 = New System.Windows.Forms.Label
      Me.lblHouseFan1 = New System.Windows.Forms.Label
      Me.lblPlenumFan = New System.Windows.Forms.Label
      Me.lblPreFilterBag = New System.Windows.Forms.Label
      Me.lblFilter = New System.Windows.Forms.Label
      Me.lblAirBlender = New System.Windows.Forms.Label
      Me.lblMixingBox = New System.Windows.Forms.Label
      Me.picBlank = New System.Windows.Forms.PictureBox
      Me.lbl_unit_sections = New System.Windows.Forms.Label
      Me.Line1 = New System.Windows.Forms.Label
        ''Me.dgrC1SectionInfo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me._SSTab2_TabPage2 = New System.Windows.Forms.TabPage
      Me.panFF3Container = New System.Windows.Forms.Panel
      Me.lblFF3OrderIndex = New System.Windows.Forms.Label
      Me.panFF3PreFilter = New System.Windows.Forms.Panel
      Me.lblFF3Prefilter = New System.Windows.Forms.Label
      Me.lblNumFilterSpares3 = New System.Windows.Forms.Label
      Me._cbo_pre_sets_2 = New System.Windows.Forms.ComboBox
      Me._cbo_pre_ff_2 = New System.Windows.Forms.ComboBox
      Me._lbl_ff_2 = New System.Windows.Forms.Label
      Me.lblFF3CostLabel = New System.Windows.Forms.Label
      Me.panFF3FinalFilter = New System.Windows.Forms.Panel
      Me.lblFF3FinalFilter = New System.Windows.Forms.Label
      Me.lblNumSpareSets6 = New System.Windows.Forms.Label
      Me._cbo_ff_sets_2 = New System.Windows.Forms.ComboBox
      Me._cbo_ff_2 = New System.Windows.Forms.ComboBox
      Me._lbl_ff_cost_2 = New System.Windows.Forms.Label
      Me._lbl_ff_weight_2 = New System.Windows.Forms.Label
      Me.panFF2Container = New System.Windows.Forms.Panel
      Me.lblFF2OrderIndex = New System.Windows.Forms.Label
      Me.panFF2FinalFilter = New System.Windows.Forms.Panel
      Me.lblFF2FinalFilter = New System.Windows.Forms.Label
      Me.lblNumSpareSets5 = New System.Windows.Forms.Label
      Me._cbo_ff_sets_1 = New System.Windows.Forms.ComboBox
      Me._cbo_ff_1 = New System.Windows.Forms.ComboBox
      Me.panFF2Prefilter = New System.Windows.Forms.Panel
      Me.lblFF2Prefilter = New System.Windows.Forms.Label
      Me._cbo_pre_ff_1 = New System.Windows.Forms.ComboBox
      Me.lblNumFilterSpares2 = New System.Windows.Forms.Label
      Me._cbo_pre_sets_1 = New System.Windows.Forms.ComboBox
      Me._lbl_ff_1 = New System.Windows.Forms.Label
      Me._lbl_ff_cost_1 = New System.Windows.Forms.Label
      Me.lblFF2CostLabel = New System.Windows.Forms.Label
      Me._lbl_ff_weight_1 = New System.Windows.Forms.Label
      Me.panFF1Container = New System.Windows.Forms.Panel
      Me.lblFF1OrderIndex = New System.Windows.Forms.Label
      Me.panFF1FinalFilter = New System.Windows.Forms.Panel
      Me._cbo_ff_0 = New System.Windows.Forms.ComboBox
      Me.lblFF1FinalFilter = New System.Windows.Forms.Label
      Me.lblNumSpareSets4 = New System.Windows.Forms.Label
      Me._cbo_ff_sets_0 = New System.Windows.Forms.ComboBox
      Me._lbl_ff_0 = New System.Windows.Forms.Label
      Me.lblFF1CostLabel = New System.Windows.Forms.Label
      Me.panFF1Prefilter = New System.Windows.Forms.Panel
      Me._cbo_pre_sets_0 = New System.Windows.Forms.ComboBox
      Me._cbo_pre_ff_0 = New System.Windows.Forms.ComboBox
      Me.lblFF1Prefilter = New System.Windows.Forms.Label
      Me.lblNumFilterSpares1 = New System.Windows.Forms.Label
      Me._lbl_ff_cost_0 = New System.Windows.Forms.Label
      Me._lbl_ff_weight_0 = New System.Windows.Forms.Label
      Me.panMB2Container = New System.Windows.Forms.Panel
      Me.lblMB2CasingChkValue = New System.Windows.Forms.Label
      Me.lblMB2OrderIndex = New System.Windows.Forms.Label
      Me.lblMB2Header = New System.Windows.Forms.Label
      Me.panMixingBox2 = New System.Windows.Forms.Panel
      Me.lblMB2Casing = New System.Windows.Forms.Label
      Me.lblMB2Air = New System.Windows.Forms.Label
      Me._cbo_mixing_box_1 = New System.Windows.Forms.ComboBox
      Me._ck_MB1_al_1 = New System.Windows.Forms.CheckBox
      Me._ck_MB1_gal_1 = New System.Windows.Forms.CheckBox
      Me.lblMB2CostLabel = New System.Windows.Forms.Label
      Me._lbl_MB1_cost_1 = New System.Windows.Forms.Label
      Me.panMB1Container = New System.Windows.Forms.Panel
      Me.lblMB1CasingChkValue = New System.Windows.Forms.Label
      Me.lblMB1OrderIndex = New System.Windows.Forms.Label
      Me.panMixingBox1 = New System.Windows.Forms.Panel
      Me.lblMB1Casing = New System.Windows.Forms.Label
      Me.lblMB1Air = New System.Windows.Forms.Label
      Me._ck_MB1_gal_0 = New System.Windows.Forms.CheckBox
      Me._ck_MB1_al_0 = New System.Windows.Forms.CheckBox
      Me._cbo_mixing_box_0 = New System.Windows.Forms.ComboBox
      Me.lblMB1Header = New System.Windows.Forms.Label
      Me.lblMB1CostLabel = New System.Windows.Forms.Label
      Me._lbl_MB1_cost_0 = New System.Windows.Forms.Label
      Me._SSTab2_TabPage3 = New System.Windows.Forms.TabPage
      Me.panFan3Container = New System.Windows.Forms.Panel
      Me.lblEnclosure3 = New System.Windows.Forms.Label
      Me.lblEfficiency3 = New System.Windows.Forms.Label
      Me.lblFan3OrderIndex = New System.Windows.Forms.Label
      Me.panFan3Fan = New System.Windows.Forms.Panel
      Me._lbl_fan_info_2 = New System.Windows.Forms.Label
      Me._cbo_fan_size_2 = New System.Windows.Forms.ComboBox
      Me._cbo_fan_iso_2 = New System.Windows.Forms.ComboBox
      Me._cbo_fan_type_2 = New System.Windows.Forms.ComboBox
      Me.Label2 = New System.Windows.Forms.Label
      Me.Label3 = New System.Windows.Forms.Label
      Me.Label4 = New System.Windows.Forms.Label
      Me._cbo_drive_type_2 = New System.Windows.Forms.ComboBox
      Me.Label5 = New System.Windows.Forms.Label
      Me.Label6 = New System.Windows.Forms.Label
      Me._cbo_fan_class_2 = New System.Windows.Forms.ComboBox
      Me.lblIsolatorCostLabel3 = New System.Windows.Forms.Label
      Me.panFan3Motor = New System.Windows.Forms.Panel
      Me._lbl_motor_info_2 = New System.Windows.Forms.Label
      Me._cbo_rpm_2 = New System.Windows.Forms.ComboBox
      Me._cbo_hp_2 = New System.Windows.Forms.ComboBox
      Me._lbl_hp_2 = New System.Windows.Forms.Label
      Me._lbl_eff_2 = New System.Windows.Forms.Label
      Me._lbl_enclosure_2 = New System.Windows.Forms.Label
      Me._lbl_rpm_2 = New System.Windows.Forms.Label
      Me._ck_odp_2 = New System.Windows.Forms.CheckBox
      Me._ck_high_2 = New System.Windows.Forms.CheckBox
      Me._ck_tefc_2 = New System.Windows.Forms.CheckBox
      Me._ck_premium_2 = New System.Windows.Forms.CheckBox
      Me._lbl_fan_type_2 = New System.Windows.Forms.Label
      Me.Label7 = New System.Windows.Forms.Label
      Me._lbl_motor_weight_2 = New System.Windows.Forms.Label
      Me.lblFanCostLabel3 = New System.Windows.Forms.Label
      Me._lbl_fan_cost_2 = New System.Windows.Forms.Label
      Me._lbl_iso_cost_2 = New System.Windows.Forms.Label
      Me.lblMotorCostLabel3 = New System.Windows.Forms.Label
      Me._lbl_motor_cost_2 = New System.Windows.Forms.Label
      Me._lbl_iso_weight_2 = New System.Windows.Forms.Label
      Me._lbl_fan_weight_2 = New System.Windows.Forms.Label
      Me.panFan2Container = New System.Windows.Forms.Panel
      Me.lblEnclosure2 = New System.Windows.Forms.Label
      Me.lblEfficiency2 = New System.Windows.Forms.Label
      Me.lblFan2OrderIndex = New System.Windows.Forms.Label
      Me.lblIsolatorCostLabel2 = New System.Windows.Forms.Label
      Me.panFan2Fan = New System.Windows.Forms.Panel
      Me._lbl_fan_info_1 = New System.Windows.Forms.Label
      Me.Label8 = New System.Windows.Forms.Label
      Me.Label9 = New System.Windows.Forms.Label
      Me.Label10 = New System.Windows.Forms.Label
      Me.Label11 = New System.Windows.Forms.Label
      Me.Label12 = New System.Windows.Forms.Label
      Me._cbo_fan_type_1 = New System.Windows.Forms.ComboBox
      Me._cbo_fan_class_1 = New System.Windows.Forms.ComboBox
      Me._cbo_fan_size_1 = New System.Windows.Forms.ComboBox
      Me._cbo_drive_type_1 = New System.Windows.Forms.ComboBox
      Me._cbo_fan_iso_1 = New System.Windows.Forms.ComboBox
      Me.panFan2Motor = New System.Windows.Forms.Panel
      Me._lbl_motor_info_1 = New System.Windows.Forms.Label
      Me._cbo_rpm_1 = New System.Windows.Forms.ComboBox
      Me._lbl_eff_1 = New System.Windows.Forms.Label
      Me._lbl_enclosure_1 = New System.Windows.Forms.Label
      Me._lbl_rpm_1 = New System.Windows.Forms.Label
      Me._lbl_hp_1 = New System.Windows.Forms.Label
      Me._ck_odp_1 = New System.Windows.Forms.CheckBox
      Me._ck_high_1 = New System.Windows.Forms.CheckBox
      Me._ck_premium_1 = New System.Windows.Forms.CheckBox
      Me._cbo_hp_1 = New System.Windows.Forms.ComboBox
      Me._ck_tefc_1 = New System.Windows.Forms.CheckBox
      Me._lbl_fan_type_1 = New System.Windows.Forms.Label
      Me._lbl_motor_weight_1 = New System.Windows.Forms.Label
      Me.lblMotorWeightLabel2 = New System.Windows.Forms.Label
      Me.lblMotorCostLabel2 = New System.Windows.Forms.Label
      Me._lbl_motor_cost_1 = New System.Windows.Forms.Label
      Me._lbl_fan_cost_1 = New System.Windows.Forms.Label
      Me.lblFanCostLabel2 = New System.Windows.Forms.Label
      Me._lbl_fan_weight_1 = New System.Windows.Forms.Label
      Me._lbl_iso_weight_1 = New System.Windows.Forms.Label
      Me._lbl_iso_cost_1 = New System.Windows.Forms.Label
      Me.panFan1Container = New System.Windows.Forms.Panel
      Me.lblEnclosure1 = New System.Windows.Forms.Label
      Me.lblEfficiency1 = New System.Windows.Forms.Label
      Me.lblIsolatorCostLabel1 = New System.Windows.Forms.Label
      Me.lblMotorCostLabel1 = New System.Windows.Forms.Label
      Me._lbl_motor_cost_0 = New System.Windows.Forms.Label
      Me.panFan1Fan = New System.Windows.Forms.Panel
      Me._lbl_fan_info_0 = New System.Windows.Forms.Label
      Me.lblFanType0 = New System.Windows.Forms.Label
      Me.lblFanSize0 = New System.Windows.Forms.Label
      Me.lblFanIsolator0 = New System.Windows.Forms.Label
      Me.lblFanDrive0 = New System.Windows.Forms.Label
      Me._cbo_fan_type_0 = New System.Windows.Forms.ComboBox
      Me._cbo_fan_class_0 = New System.Windows.Forms.ComboBox
      Me._cbo_fan_size_0 = New System.Windows.Forms.ComboBox
      Me._cbo_drive_type_0 = New System.Windows.Forms.ComboBox
      Me._cbo_fan_iso_0 = New System.Windows.Forms.ComboBox
      Me.lblFanClass0 = New System.Windows.Forms.Label
      Me.lblFan1OrderIndex = New System.Windows.Forms.Label
      Me._lbl_fan_type_0 = New System.Windows.Forms.Label
      Me.panFan1Motor = New System.Windows.Forms.Panel
      Me._cbo_rpm_0 = New System.Windows.Forms.ComboBox
      Me._ck_premium_0 = New System.Windows.Forms.CheckBox
      Me._ck_tefc_0 = New System.Windows.Forms.CheckBox
      Me._lbl_enclosure_0 = New System.Windows.Forms.Label
      Me._lbl_rpm_0 = New System.Windows.Forms.Label
      Me._lbl_eff_0 = New System.Windows.Forms.Label
      Me._ck_odp_0 = New System.Windows.Forms.CheckBox
      Me._lbl_hp_0 = New System.Windows.Forms.Label
      Me._ck_high_0 = New System.Windows.Forms.CheckBox
      Me._cbo_hp_0 = New System.Windows.Forms.ComboBox
      Me._lbl_motor_info_0 = New System.Windows.Forms.Label
      Me.lblMotorWeightLabel1 = New System.Windows.Forms.Label
      Me._lbl_motor_weight_0 = New System.Windows.Forms.Label
      Me.lblFanWeightLabel1 = New System.Windows.Forms.Label
      Me._lbl_fan_weight_0 = New System.Windows.Forms.Label
      Me._lbl_iso_weight_0 = New System.Windows.Forms.Label
      Me._lbl_fan_cost_0 = New System.Windows.Forms.Label
      Me.lblFanCostLabel1 = New System.Windows.Forms.Label
      Me._lbl_iso_cost_0 = New System.Windows.Forms.Label
      Me._SSTab2_TabPage4 = New System.Windows.Forms.TabPage
      Me.panGasHeaterContainer = New System.Windows.Forms.Panel
      Me.panGasHeater = New System.Windows.Forms.Panel
      Me.lblC5TypeValue = New System.Windows.Forms.Label
      Me.radC5TypeModulating = New System.Windows.Forms.RadioButton
      Me.radC5TypeTwoStage = New System.Windows.Forms.RadioButton
      Me.cboC5Power = New System.Windows.Forms.ComboBox
      Me.lblC5Type = New System.Windows.Forms.Label
      Me.lblC5Power = New System.Windows.Forms.Label
      Me.lblGasHeaterOrderIndex = New System.Windows.Forms.Label
      Me.lblGasHeaterCost = New System.Windows.Forms.Label
      Me.Label34 = New System.Windows.Forms.Label
      Me.panCoil4Container = New System.Windows.Forms.Panel
      Me.lblCoil4OrderIndex = New System.Windows.Forms.Label
      Me._lbl_coil_cost_3 = New System.Windows.Forms.Label
      Me.panCoil4 = New System.Windows.Forms.Panel
      Me._ck_cu_3 = New System.Windows.Forms.CheckBox
      Me.lblCoilCasing4 = New System.Windows.Forms.Label
      Me.lblFinMaterial4 = New System.Windows.Forms.Label
      Me.Label30 = New System.Windows.Forms.Label
      Me._cbo_coil_type_3 = New System.Windows.Forms.ComboBox
      Me._cbo_fins_3 = New System.Windows.Forms.ComboBox
      Me._cbo_rows_3 = New System.Windows.Forms.ComboBox
      Me._lbl_num_rows_3 = New System.Windows.Forms.Label
      Me._lbl_num_fins_3 = New System.Windows.Forms.Label
      Me._lbl_fin_mtl_3 = New System.Windows.Forms.Label
      Me._ck_al_3 = New System.Windows.Forms.CheckBox
      Me._lbl_fin_thickness_3 = New System.Windows.Forms.Label
      Me._cbo_fin_thickness_3 = New System.Windows.Forms.ComboBox
      Me._cbo_tube_thickness_3 = New System.Windows.Forms.ComboBox
      Me._lbl_tube_thickness_3 = New System.Windows.Forms.Label
      Me._lbl_casing_3 = New System.Windows.Forms.Label
      Me._ck_gal_3 = New System.Windows.Forms.CheckBox
      Me._ck_ss_3 = New System.Windows.Forms.CheckBox
      Me._lbl_coil_type_3 = New System.Windows.Forms.Label
      Me.panCoil3Container = New System.Windows.Forms.Panel
      Me._lbl_coil_cost_2 = New System.Windows.Forms.Label
      Me.lblCoil3OrderIndex = New System.Windows.Forms.Label
      Me.panCoil3 = New System.Windows.Forms.Panel
      Me._ck_cu_2 = New System.Windows.Forms.CheckBox
      Me.lblCoilCasing3 = New System.Windows.Forms.Label
      Me.lblFinMaterial3 = New System.Windows.Forms.Label
      Me.Label20 = New System.Windows.Forms.Label
      Me._cbo_tube_thickness_2 = New System.Windows.Forms.ComboBox
      Me._ck_gal_2 = New System.Windows.Forms.CheckBox
      Me._cbo_fin_thickness_2 = New System.Windows.Forms.ComboBox
      Me._ck_al_2 = New System.Windows.Forms.CheckBox
      Me._cbo_fins_2 = New System.Windows.Forms.ComboBox
      Me._cbo_rows_2 = New System.Windows.Forms.ComboBox
      Me._ck_ss_2 = New System.Windows.Forms.CheckBox
      Me._cbo_coil_type_2 = New System.Windows.Forms.ComboBox
      Me._lbl_num_rows_2 = New System.Windows.Forms.Label
      Me._lbl_num_fins_2 = New System.Windows.Forms.Label
      Me._lbl_fin_thickness_2 = New System.Windows.Forms.Label
      Me._lbl_tube_thickness_2 = New System.Windows.Forms.Label
      Me._lbl_casing_2 = New System.Windows.Forms.Label
      Me._lbl_fin_mtl_2 = New System.Windows.Forms.Label
      Me._lbl_coil_type_2 = New System.Windows.Forms.Label
      Me.panCoil5Container = New System.Windows.Forms.Panel
      Me.panCoil5 = New System.Windows.Forms.Panel
      Me._ck_cu_4 = New System.Windows.Forms.CheckBox
      Me.lblCoilCasing5 = New System.Windows.Forms.Label
      Me.lblFinMaterial5 = New System.Windows.Forms.Label
      Me.Label31 = New System.Windows.Forms.Label
      Me._lbl_casing_4 = New System.Windows.Forms.Label
      Me._lbl_fin_mtl_4 = New System.Windows.Forms.Label
      Me._cbo_tube_thickness_4 = New System.Windows.Forms.ComboBox
      Me._ck_gal_4 = New System.Windows.Forms.CheckBox
      Me._cbo_fin_thickness_4 = New System.Windows.Forms.ComboBox
      Me._ck_al_4 = New System.Windows.Forms.CheckBox
      Me._cbo_fins_4 = New System.Windows.Forms.ComboBox
      Me._cbo_rows_4 = New System.Windows.Forms.ComboBox
      Me._ck_ss_4 = New System.Windows.Forms.CheckBox
      Me._cbo_coil_type_4 = New System.Windows.Forms.ComboBox
      Me._lbl_num_rows_4 = New System.Windows.Forms.Label
      Me._lbl_num_fins_4 = New System.Windows.Forms.Label
      Me._lbl_fin_thickness_4 = New System.Windows.Forms.Label
      Me._lbl_tube_thickness_4 = New System.Windows.Forms.Label
      Me.lblCoil5OrderIndex = New System.Windows.Forms.Label
      Me._lbl_coil_cost_4 = New System.Windows.Forms.Label
      Me._lbl_coil_type_4 = New System.Windows.Forms.Label
      Me.panCoil2Container = New System.Windows.Forms.Panel
      Me._lbl_coil_cost_1 = New System.Windows.Forms.Label
      Me.lblCoil2OrderIndex = New System.Windows.Forms.Label
      Me._lbl_coil_type_1 = New System.Windows.Forms.Label
      Me.panCoil2 = New System.Windows.Forms.Panel
      Me._ck_cu_1 = New System.Windows.Forms.CheckBox
      Me.lblCoilCasing2 = New System.Windows.Forms.Label
      Me.lblFinMaterial2 = New System.Windows.Forms.Label
      Me._ck_gal_1 = New System.Windows.Forms.CheckBox
      Me.Label16 = New System.Windows.Forms.Label
      Me._cbo_fins_1 = New System.Windows.Forms.ComboBox
      Me._cbo_rows_1 = New System.Windows.Forms.ComboBox
      Me._cbo_coil_type_1 = New System.Windows.Forms.ComboBox
      Me._lbl_num_rows_1 = New System.Windows.Forms.Label
      Me._lbl_num_fins_1 = New System.Windows.Forms.Label
      Me._ck_al_1 = New System.Windows.Forms.CheckBox
      Me._lbl_fin_mtl_1 = New System.Windows.Forms.Label
      Me._lbl_fin_thickness_1 = New System.Windows.Forms.Label
      Me._cbo_fin_thickness_1 = New System.Windows.Forms.ComboBox
      Me._lbl_tube_thickness_1 = New System.Windows.Forms.Label
      Me._cbo_tube_thickness_1 = New System.Windows.Forms.ComboBox
      Me._lbl_casing_1 = New System.Windows.Forms.Label
      Me._ck_ss_1 = New System.Windows.Forms.CheckBox
      Me.panCoil1Container = New System.Windows.Forms.Panel
      Me._lbl_coil_cost_0 = New System.Windows.Forms.Label
      Me.lblCoil1OrderIndex = New System.Windows.Forms.Label
      Me.panCoil1 = New System.Windows.Forms.Panel
      Me._ck_cu_0 = New System.Windows.Forms.CheckBox
      Me.lblCoilCasing1 = New System.Windows.Forms.Label
      Me.lblFinMaterial1 = New System.Windows.Forms.Label
      Me.lblCoil1Type = New System.Windows.Forms.Label
      Me._lbl_fin_thickness_0 = New System.Windows.Forms.Label
      Me._cbo_fins_0 = New System.Windows.Forms.ComboBox
      Me._cbo_rows_0 = New System.Windows.Forms.ComboBox
      Me._lbl_num_rows_0 = New System.Windows.Forms.Label
      Me._lbl_num_fins_0 = New System.Windows.Forms.Label
      Me._cbo_coil_type_0 = New System.Windows.Forms.ComboBox
      Me._lbl_fin_mtl_0 = New System.Windows.Forms.Label
      Me._ck_al_0 = New System.Windows.Forms.CheckBox
      Me._cbo_fin_thickness_0 = New System.Windows.Forms.ComboBox
      Me._lbl_tube_thickness_0 = New System.Windows.Forms.Label
      Me._cbo_tube_thickness_0 = New System.Windows.Forms.ComboBox
      Me._ck_gal_0 = New System.Windows.Forms.CheckBox
      Me._ck_ss_0 = New System.Windows.Forms.CheckBox
      Me._lbl_casing_0 = New System.Windows.Forms.Label
      Me._lbl_coil_type_0 = New System.Windows.Forms.Label
      Me.panC3Container = New System.Windows.Forms.Panel
      Me.lblC3OrderIndex = New System.Windows.Forms.Label
      Me.lbl_heater_cost = New System.Windows.Forms.Label
      Me.panC3 = New System.Windows.Forms.Panel
      Me.Label33 = New System.Windows.Forms.Label
      Me.lbl_C3_kw = New System.Windows.Forms.Label
      Me.cbo_C3_kw = New System.Windows.Forms.ComboBox
      Me.lbl_C3_min_stages = New System.Windows.Forms.Label
      Me.lbl_C3_op_temp = New System.Windows.Forms.Label
      Me.lbl_C3_op_temp_1 = New System.Windows.Forms.Label
      Me.ck_C3_scr = New System.Windows.Forms.CheckBox
      Me.ck_C3_disconnect = New System.Windows.Forms.CheckBox
      Me.lbl_C3_min_stages_val = New System.Windows.Forms.Label
      Me.lbl_C3_extra_stages = New System.Windows.Forms.Label
      Me.cbo_C3_extra_stages = New System.Windows.Forms.ComboBox
      Me.lbl_C3 = New System.Windows.Forms.Label
      Me._SSTab2_TabPage5 = New System.Windows.Forms.TabPage
      Me.panDischargeContainer = New System.Windows.Forms.Panel
      Me.lblDischargeLocationChkValue = New System.Windows.Forms.Label
      Me.lblDischargeOrderIndex = New System.Windows.Forms.Label
      Me.lblGratingCost = New System.Windows.Forms.Label
      Me.lbl_discharge = New System.Windows.Forms.Label
      Me.Panel11 = New System.Windows.Forms.Panel
      Me.lblDischargeLocation = New System.Windows.Forms.Label
      Me.Panel12 = New System.Windows.Forms.Panel
      Me.radD1Floor = New System.Windows.Forms.RadioButton
      Me.radD1EndWall = New System.Windows.Forms.RadioButton
      Me.radD1Ceiling = New System.Windows.Forms.RadioButton
      Me.ck_D1_grating = New System.Windows.Forms.CheckBox
      Me.lbl_D1_grating_cost = New System.Windows.Forms.Label
      Me.lbl_base = New System.Windows.Forms.Label
      Me.Panel10 = New System.Windows.Forms.Panel
      Me.radBaseMaterialSteel = New System.Windows.Forms.RadioButton
      Me.radBaseMaterialSheetMetal = New System.Windows.Forms.RadioButton
      Me.lblBaseMaterialChkValue = New System.Windows.Forms.Label
      Me.Panel9 = New System.Windows.Forms.Panel
      Me.lbl_doors = New System.Windows.Forms.Label
      Me.Label28 = New System.Windows.Forms.Label
      Me.panSectionsSummaryHeader = New System.Windows.Forms.Panel
      Me.Label23 = New System.Windows.Forms.Label
      Me.Label15 = New System.Windows.Forms.Label
      Me.Panel8 = New System.Windows.Forms.Panel
      Me.Panel6 = New System.Windows.Forms.Panel
      Me.Label19 = New System.Windows.Forms.Label
      Me.txt_doors = New System.Windows.Forms.TextBox
      Me.Panel7 = New System.Windows.Forms.Panel
      Me.lblAirSealQuantity = New System.Windows.Forms.Label
      Me.Label29 = New System.Windows.Forms.Label
      Me.panSectionQuantities = New System.Windows.Forms.Panel
      Me.Panel3 = New System.Windows.Forms.Panel
      Me.lblBLD1Quantity = New System.Windows.Forms.Label
      Me.Label27 = New System.Windows.Forms.Label
      Me.Label26 = New System.Windows.Forms.Label
      Me.lbl_bld1_cost = New System.Windows.Forms.Label
      Me.Panel1 = New System.Windows.Forms.Panel
      Me.lblSS1Quantity = New System.Windows.Forms.Label
      Me.Label13 = New System.Windows.Forms.Label
      Me.Label14 = New System.Windows.Forms.Label
      Me.Panel4 = New System.Windows.Forms.Panel
      Me.lblSS2Quantity = New System.Windows.Forms.Label
      Me.Label17 = New System.Windows.Forms.Label
      Me.Label18 = New System.Windows.Forms.Label
      Me.Panel2 = New System.Windows.Forms.Panel
      Me.lblSS3Quantity = New System.Windows.Forms.Label
      Me.Label21 = New System.Windows.Forms.Label
      Me.Label22 = New System.Windows.Forms.Label
      Me.Panel5 = New System.Windows.Forms.Panel
      Me.Label25 = New System.Windows.Forms.Label
      Me.Label24 = New System.Windows.Forms.Label
      Me.lblUS1Quantity = New System.Windows.Forms.Label
      Me.lbl_ATT_sound_att = New System.Windows.Forms.Label
      Me.ck_ATT_5 = New System.Windows.Forms.CheckBox
      Me.ck_ATT_4 = New System.Windows.Forms.CheckBox
      Me.ck_ATT_3 = New System.Windows.Forms.CheckBox
      Me.ck_ATT = New System.Windows.Forms.CheckBox
      Me.cmd_close_2 = New System.Windows.Forms.Button
      Me.cbo_coil_type = New Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray(Me.components)
      Me.cbo_drive_type = New Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray(Me.components)
      Me.cbo_fan_class = New Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray(Me.components)
      Me.cbo_fan_iso = New Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray(Me.components)
      Me.cbo_fan_size = New Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray(Me.components)
      Me.cbo_fan_type = New Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray(Me.components)
      Me.cbo_ff = New Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray(Me.components)
      Me.cbo_ff_sets = New Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray(Me.components)
      Me.cbo_fin_thickness = New Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray(Me.components)
      Me.cbo_fins = New Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray(Me.components)
      Me.cbo_hp = New Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray(Me.components)
      Me.cbo_mixing_box = New Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray(Me.components)
      Me.cbo_pre_ff = New Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray(Me.components)
      Me.cbo_pre_sets = New Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray(Me.components)
      Me.cbo_rows = New Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray(Me.components)
      Me.cbo_rpm = New Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray(Me.components)
      Me.cbo_tube_thickness = New Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray(Me.components)
      Me.ck_MB1_al = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(Me.components)
      Me.ck_MB1_gal = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(Me.components)
      Me.ck_al = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(Me.components)
      Me.ck_cu = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(Me.components)
      Me.ck_ff_sets = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(Me.components)
      Me.ck_gal = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(Me.components)
      Me.ck_high = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(Me.components)
      Me.ck_odp = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(Me.components)
      Me.ck_pre_sets = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(Me.components)
      Me.ck_premium = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(Me.components)
      Me.ck_ss = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(Me.components)
      Me.ck_tefc = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(Me.components)
      Me.lbl_MB1_cost = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
      Me.lbl_casing = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
      Me.lbl_coil_cost = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
      Me.lbl_coil_type = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
      Me.lbl_eff = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
      Me.lbl_enclosure = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
      Me.lbl_fan_cost = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
      Me.lbl_fan_info = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
      Me.lbl_fan_type = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
      Me.lbl_fan_weight = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
      Me.lbl_ff = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
      Me.lbl_ff_cost = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
      Me.lbl_ff_weight = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
      Me.lbl_fin_mtl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
      Me.lbl_fin_thickness = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
      Me.lbl_hp = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
      Me.lbl_iso_cost = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
      Me.lbl_iso_weight = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
      Me.lbl_motor_cost = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
      Me.lbl_motor_info = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
      Me.lbl_motor_weight = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
      Me.lbl_num_fins = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
      Me.lbl_num_rows = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
      Me.lbl_rpm = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
      Me.lbl_tube_thickness = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
      Me.btnClose = New System.Windows.Forms.Button
      Me.conSelect = New System.Data.OleDb.OleDbConnection
      Me.lllCatalog = New System.Windows.Forms.LinkLabel
      Me.dadSection = New System.Data.OleDb.OleDbDataAdapter
      Me.OleDbDeleteCommand1 = New System.Data.OleDb.OleDbCommand
      Me.OleDbConnection1 = New System.Data.OleDb.OleDbConnection
      Me.OleDbInsertCommand1 = New System.Data.OleDb.OleDbCommand
      Me.OleDbSelectCommand1 = New System.Data.OleDb.OleDbCommand
      Me.OleDbUpdateCommand1 = New System.Data.OleDb.OleDbCommand
      Me.dadAirHandler = New System.Data.OleDb.OleDbDataAdapter
      Me.OleDbDeleteCommand3 = New System.Data.OleDb.OleDbCommand
      Me.OleDbInsertCommand3 = New System.Data.OleDb.OleDbCommand
      Me.OleDbSelectCommand3 = New System.Data.OleDb.OleDbCommand
      Me.OleDbUpdateCommand3 = New System.Data.OleDb.OleDbCommand
      Me.Label32 = New System.Windows.Forms.Label
      Me.lblTag = New System.Windows.Forms.Label
      Me.DseProject1 = New Rae.RaeSolutions.dseProject
      Me.dadSectionDetails = New System.Data.OleDb.OleDbDataAdapter
      Me.OleDbDeleteCommand4 = New System.Data.OleDb.OleDbCommand
      Me.OleDbInsertCommand4 = New System.Data.OleDb.OleDbCommand
      Me.OleDbSelectCommand4 = New System.Data.OleDb.OleDbCommand
      Me.OleDbUpdateCommand4 = New System.Data.OleDb.OleDbCommand
      CType(Me.picMixingBox, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.picDischarge2, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.picDischarge1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.picSpace3, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.picSpace2, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.picSpace1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.picElectricHeater, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.picCoolingCoil, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.picHeatingCoil, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.picHouseFan2, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.picHouseFan1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.picPlenumFan, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.picPreFilterBag, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.picFilter, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.picAirBlender, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.picSplit, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.picGasHeater, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SSTab2.SuspendLayout()
      Me._SSTab2_TabPage0.SuspendLayout()
        ''CType(Me.dgrC1Select, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AirHandlerData1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._SSTab2_TabPage1.SuspendLayout()
      Me.panDragSections.SuspendLayout()
      CType(Me.picBlank, System.ComponentModel.ISupportInitialize).BeginInit()
        ''CType(Me.dgrC1SectionInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._SSTab2_TabPage2.SuspendLayout()
      Me.panFF3Container.SuspendLayout()
      Me.panFF3PreFilter.SuspendLayout()
      Me.panFF3FinalFilter.SuspendLayout()
      Me.panFF2Container.SuspendLayout()
      Me.panFF2FinalFilter.SuspendLayout()
      Me.panFF2Prefilter.SuspendLayout()
      Me.panFF1Container.SuspendLayout()
      Me.panFF1FinalFilter.SuspendLayout()
      Me.panFF1Prefilter.SuspendLayout()
      Me.panMB2Container.SuspendLayout()
      Me.panMixingBox2.SuspendLayout()
      Me.panMB1Container.SuspendLayout()
      Me.panMixingBox1.SuspendLayout()
      Me._SSTab2_TabPage3.SuspendLayout()
      Me.panFan3Container.SuspendLayout()
      Me.panFan3Fan.SuspendLayout()
      Me.panFan3Motor.SuspendLayout()
      Me.panFan2Container.SuspendLayout()
      Me.panFan2Fan.SuspendLayout()
      Me.panFan2Motor.SuspendLayout()
      Me.panFan1Container.SuspendLayout()
      Me.panFan1Fan.SuspendLayout()
      Me.panFan1Motor.SuspendLayout()
      Me._SSTab2_TabPage4.SuspendLayout()
      Me.panGasHeaterContainer.SuspendLayout()
      Me.panGasHeater.SuspendLayout()
      Me.panCoil4Container.SuspendLayout()
      Me.panCoil4.SuspendLayout()
      Me.panCoil3Container.SuspendLayout()
      Me.panCoil3.SuspendLayout()
      Me.panCoil5Container.SuspendLayout()
      Me.panCoil5.SuspendLayout()
      Me.panCoil2Container.SuspendLayout()
      Me.panCoil2.SuspendLayout()
      Me.panCoil1Container.SuspendLayout()
      Me.panCoil1.SuspendLayout()
      Me.panC3Container.SuspendLayout()
      Me.panC3.SuspendLayout()
      Me._SSTab2_TabPage5.SuspendLayout()
      Me.panDischargeContainer.SuspendLayout()
      Me.Panel11.SuspendLayout()
      Me.Panel12.SuspendLayout()
      Me.Panel10.SuspendLayout()
      Me.Panel9.SuspendLayout()
      Me.panSectionsSummaryHeader.SuspendLayout()
      Me.Panel8.SuspendLayout()
      Me.Panel6.SuspendLayout()
      Me.Panel7.SuspendLayout()
      Me.panSectionQuantities.SuspendLayout()
      Me.Panel3.SuspendLayout()
      Me.Panel1.SuspendLayout()
      Me.Panel4.SuspendLayout()
      Me.Panel2.SuspendLayout()
      Me.Panel5.SuspendLayout()
      CType(Me.cbo_coil_type, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cbo_drive_type, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cbo_fan_class, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cbo_fan_iso, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cbo_fan_size, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cbo_fan_type, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cbo_ff, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cbo_ff_sets, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cbo_fin_thickness, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cbo_fins, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cbo_hp, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cbo_mixing_box, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cbo_pre_ff, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cbo_pre_sets, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cbo_rows, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cbo_rpm, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cbo_tube_thickness, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ck_MB1_al, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ck_MB1_gal, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ck_al, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ck_cu, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ck_ff_sets, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ck_gal, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ck_high, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ck_odp, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ck_pre_sets, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ck_premium, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ck_ss, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ck_tefc, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.lbl_MB1_cost, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.lbl_casing, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.lbl_coil_cost, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.lbl_coil_type, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.lbl_eff, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.lbl_enclosure, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.lbl_fan_cost, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.lbl_fan_info, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.lbl_fan_type, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.lbl_fan_weight, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.lbl_ff, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.lbl_ff_cost, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.lbl_ff_weight, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.lbl_fin_mtl, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.lbl_fin_thickness, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.lbl_hp, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.lbl_iso_cost, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.lbl_iso_weight, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.lbl_motor_cost, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.lbl_motor_info, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.lbl_motor_weight, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.lbl_num_fins, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.lbl_num_rows, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.lbl_rpm, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.lbl_tube_thickness, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DseProject1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ToolTip1
      '
      Me.ToolTip1.AutoPopDelay = 10000
      Me.ToolTip1.InitialDelay = 500
      Me.ToolTip1.ReshowDelay = 500
      '
      'picMixingBox
      '
      Me.picMixingBox.BackColor = System.Drawing.Color.White
      Me.picMixingBox.Cursor = System.Windows.Forms.Cursors.SizeAll
      Me.picMixingBox.Image = CType(resources.GetObject("picMixingBox.Image"), System.Drawing.Image)
      Me.picMixingBox.Location = New System.Drawing.Point(8, 4)
      Me.picMixingBox.Name = "picMixingBox"
      Me.picMixingBox.Size = New System.Drawing.Size(101, 100)
      Me.picMixingBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.picMixingBox.TabIndex = 0
      Me.picMixingBox.TabStop = False
      Me.picMixingBox.Tag = "MB1"
      Me.ToolTip1.SetToolTip(Me.picMixingBox, "MB1 (Mixing Box) consists of either one or two dampers for a combination of outsi" & _
              "de air and return air. Outdoor units will also consist of a rainhood")
      '
      'picDischarge2
      '
      Me.picDischarge2.Cursor = System.Windows.Forms.Cursors.SizeAll
      Me.picDischarge2.Image = CType(resources.GetObject("picDischarge2.Image"), System.Drawing.Image)
      Me.picDischarge2.Location = New System.Drawing.Point(1136, 4)
      Me.picDischarge2.Name = "picDischarge2"
      Me.picDischarge2.Size = New System.Drawing.Size(12, 100)
      Me.picDischarge2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.picDischarge2.TabIndex = 28
      Me.picDischarge2.TabStop = False
      Me.picDischarge2.Tag = "D2"
      Me.ToolTip1.SetToolTip(Me.picDischarge2, "D2 (Discharge) consists of an end discharge")
      '
      'picDischarge1
      '
      Me.picDischarge1.Cursor = System.Windows.Forms.Cursors.SizeAll
      Me.picDischarge1.Image = CType(resources.GetObject("picDischarge1.Image"), System.Drawing.Image)
      Me.picDischarge1.Location = New System.Drawing.Point(1052, 4)
      Me.picDischarge1.Name = "picDischarge1"
      Me.picDischarge1.Size = New System.Drawing.Size(50, 100)
      Me.picDischarge1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.picDischarge1.TabIndex = 27
      Me.picDischarge1.TabStop = False
      Me.picDischarge1.Tag = "D1"
      Me.ToolTip1.SetToolTip(Me.picDischarge1, "D1 (Discharge) consists of a down or up discharge; an end discharge can be applie" & _
              "d if the cabinet length is required for proper airflow")
      '
      'picSpace3
      '
      Me.picSpace3.Cursor = System.Windows.Forms.Cursors.SizeAll
      Me.picSpace3.Image = CType(resources.GetObject("picSpace3.Image"), System.Drawing.Image)
      Me.picSpace3.Location = New System.Drawing.Point(984, 4)
      Me.picSpace3.Name = "picSpace3"
      Me.picSpace3.Size = New System.Drawing.Size(41, 100)
      Me.picSpace3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.picSpace3.TabIndex = 26
      Me.picSpace3.TabStop = False
      Me.picSpace3.Tag = "SS3"
      Me.ToolTip1.SetToolTip(Me.picSpace3, "SS3 (Space Section) consists of a 3' space section")
      '
      'picSpace2
      '
      Me.picSpace2.Cursor = System.Windows.Forms.Cursors.SizeAll
      Me.picSpace2.Image = CType(resources.GetObject("picSpace2.Image"), System.Drawing.Image)
      Me.picSpace2.Location = New System.Drawing.Point(936, 4)
      Me.picSpace2.Name = "picSpace2"
      Me.picSpace2.Size = New System.Drawing.Size(28, 100)
      Me.picSpace2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.picSpace2.TabIndex = 25
      Me.picSpace2.TabStop = False
      Me.picSpace2.Tag = "SS2"
      Me.ToolTip1.SetToolTip(Me.picSpace2, "SS2 (Space Section) consists of a 2' space section")
      '
      'picSpace1
      '
      Me.picSpace1.Cursor = System.Windows.Forms.Cursors.SizeAll
      Me.picSpace1.Image = CType(resources.GetObject("picSpace1.Image"), System.Drawing.Image)
      Me.picSpace1.Location = New System.Drawing.Point(888, 4)
      Me.picSpace1.Name = "picSpace1"
      Me.picSpace1.Size = New System.Drawing.Size(16, 100)
      Me.picSpace1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.picSpace1.TabIndex = 24
      Me.picSpace1.TabStop = False
      Me.picSpace1.Tag = "SS1"
      Me.ToolTip1.SetToolTip(Me.picSpace1, "SS1 (Space Section) consists of a 1' space section")
      '
      'picElectricHeater
      '
      Me.picElectricHeater.Cursor = System.Windows.Forms.Cursors.SizeAll
      Me.picElectricHeater.Image = CType(resources.GetObject("picElectricHeater.Image"), System.Drawing.Image)
      Me.picElectricHeater.Location = New System.Drawing.Point(804, 4)
      Me.picElectricHeater.Name = "picElectricHeater"
      Me.picElectricHeater.Size = New System.Drawing.Size(59, 100)
      Me.picElectricHeater.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.picElectricHeater.TabIndex = 20
      Me.picElectricHeater.TabStop = False
      Me.picElectricHeater.Tag = "C3"
      Me.ToolTip1.SetToolTip(Me.picElectricHeater, "C3 (Coil) consists of the cabinet required to house a typical electric heater")
      '
      'picCoolingCoil
      '
      Me.picCoolingCoil.Cursor = System.Windows.Forms.Cursors.SizeAll
      Me.picCoolingCoil.Image = CType(resources.GetObject("picCoolingCoil.Image"), System.Drawing.Image)
      Me.picCoolingCoil.Location = New System.Drawing.Point(728, 4)
      Me.picCoolingCoil.Name = "picCoolingCoil"
      Me.picCoolingCoil.Size = New System.Drawing.Size(52, 100)
      Me.picCoolingCoil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.picCoolingCoil.TabIndex = 19
      Me.picCoolingCoil.TabStop = False
      Me.picCoolingCoil.Tag = "C2"
      Me.ToolTip1.SetToolTip(Me.picCoolingCoil, "C2 (Coil) consists of the cabinet required to house a cooling coil and includes a" & _
              " drain pan")
      '
      'picHeatingCoil
      '
      Me.picHeatingCoil.Cursor = System.Windows.Forms.Cursors.SizeAll
      Me.picHeatingCoil.Image = CType(resources.GetObject("picHeatingCoil.Image"), System.Drawing.Image)
      Me.picHeatingCoil.Location = New System.Drawing.Point(676, 4)
      Me.picHeatingCoil.Name = "picHeatingCoil"
      Me.picHeatingCoil.Size = New System.Drawing.Size(22, 100)
      Me.picHeatingCoil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.picHeatingCoil.TabIndex = 18
      Me.picHeatingCoil.TabStop = False
      Me.picHeatingCoil.Tag = "C1"
      Me.ToolTip1.SetToolTip(Me.picHeatingCoil, "C1 (Coil) consists of the cabinet required to house a 1 or 2 row heating coil")
      '
      'picHouseFan2
      '
      Me.picHouseFan2.Cursor = System.Windows.Forms.Cursors.SizeAll
      Me.picHouseFan2.Image = CType(resources.GetObject("picHouseFan2.Image"), System.Drawing.Image)
      Me.picHouseFan2.Location = New System.Drawing.Point(572, 4)
      Me.picHouseFan2.Name = "picHouseFan2"
      Me.picHouseFan2.Size = New System.Drawing.Size(78, 100)
      Me.picHouseFan2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.picHouseFan2.TabIndex = 16
      Me.picHouseFan2.TabStop = False
      Me.picHouseFan2.Tag = "HF2"
      Me.ToolTip1.SetToolTip(Me.picHouseFan2, "HF2 (House Fan) consists of the cabinet required to house a DWDI housed fan with " & _
              "discharge external to the unit")
      '
      'picHouseFan1
      '
      Me.picHouseFan1.Cursor = System.Windows.Forms.Cursors.SizeAll
      Me.picHouseFan1.Image = CType(resources.GetObject("picHouseFan1.Image"), System.Drawing.Image)
      Me.picHouseFan1.Location = New System.Drawing.Point(444, 4)
      Me.picHouseFan1.Name = "picHouseFan1"
      Me.picHouseFan1.Size = New System.Drawing.Size(104, 100)
      Me.picHouseFan1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.picHouseFan1.TabIndex = 14
      Me.picHouseFan1.TabStop = False
      Me.picHouseFan1.Tag = "HF1"
      Me.ToolTip1.SetToolTip(Me.picHouseFan1, "HF1 (House Fan) consists of the cabinet required to house a DWDI housed fan with " & _
              "discharge internal to the unit")
      '
      'picPlenumFan
      '
      Me.picPlenumFan.Cursor = System.Windows.Forms.Cursors.SizeAll
      Me.picPlenumFan.Image = CType(resources.GetObject("picPlenumFan.Image"), System.Drawing.Image)
      Me.picPlenumFan.Location = New System.Drawing.Point(296, 4)
      Me.picPlenumFan.Name = "picPlenumFan"
      Me.picPlenumFan.Size = New System.Drawing.Size(121, 100)
      Me.picPlenumFan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.picPlenumFan.TabIndex = 12
      Me.picPlenumFan.TabStop = False
      Me.picPlenumFan.Tag = "PF1"
      Me.ToolTip1.SetToolTip(Me.picPlenumFan, "PF1 (Plenum Fan) consists of the cabinet required to house an SWSI plenum fan.")
      '
      'picPreFilterBag
      '
      Me.picPreFilterBag.BackColor = System.Drawing.Color.White
      Me.picPreFilterBag.Cursor = System.Windows.Forms.Cursors.SizeAll
      Me.picPreFilterBag.Image = CType(resources.GetObject("picPreFilterBag.Image"), System.Drawing.Image)
      Me.picPreFilterBag.Location = New System.Drawing.Point(244, 4)
      Me.picPreFilterBag.Name = "picPreFilterBag"
      Me.picPreFilterBag.Size = New System.Drawing.Size(31, 100)
      Me.picPreFilterBag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.picPreFilterBag.TabIndex = 3
      Me.picPreFilterBag.TabStop = False
      Me.picPreFilterBag.Tag = "FF2"
      Me.ToolTip1.SetToolTip(Me.picPreFilterBag, "FF2 (Filter) consists of universal filter holding frames to hold either 2"" or 4"" " & _
              "pre-filters and up to 22"" bag filters")
      '
      'picFilter
      '
      Me.picFilter.BackColor = System.Drawing.Color.White
      Me.picFilter.Cursor = System.Windows.Forms.Cursors.SizeAll
      Me.picFilter.Image = CType(resources.GetObject("picFilter.Image"), System.Drawing.Image)
      Me.picFilter.Location = New System.Drawing.Point(208, 4)
      Me.picFilter.Name = "picFilter"
      Me.picFilter.Size = New System.Drawing.Size(11, 100)
      Me.picFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.picFilter.TabIndex = 2
      Me.picFilter.TabStop = False
      Me.picFilter.Tag = "FF1"
      Me.ToolTip1.SetToolTip(Me.picFilter, "FF1 (Filter) consists of universal filter holding frames to hold either 2"" or 4"" " & _
              "filters")
      '
      'picAirBlender
      '
      Me.picAirBlender.BackColor = System.Drawing.Color.White
      Me.picAirBlender.Cursor = System.Windows.Forms.Cursors.SizeAll
      Me.picAirBlender.Image = CType(resources.GetObject("picAirBlender.Image"), System.Drawing.Image)
      Me.picAirBlender.Location = New System.Drawing.Point(132, 4)
      Me.picAirBlender.Name = "picAirBlender"
      Me.picAirBlender.Size = New System.Drawing.Size(53, 100)
      Me.picAirBlender.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.picAirBlender.TabIndex = 1
      Me.picAirBlender.TabStop = False
      Me.picAirBlender.Tag = "BLD1"
      Me.ToolTip1.SetToolTip(Me.picAirBlender, "BLD1 (Air Blender) consists of an air mixing device to blend two airstreams at di" & _
              "fferent temperatures into a non-stratified airstream")
      '
      'picSplit
      '
      Me.picSplit.Cursor = System.Windows.Forms.Cursors.SizeAll
      Me.picSplit.Image = CType(resources.GetObject("picSplit.Image"), System.Drawing.Image)
      Me.picSplit.Location = New System.Drawing.Point(1196, 4)
      Me.picSplit.Name = "picSplit"
      Me.picSplit.Size = New System.Drawing.Size(7, 100)
      Me.picSplit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.picSplit.TabIndex = 34
      Me.picSplit.TabStop = False
      Me.picSplit.Tag = "US1"
      Me.ToolTip1.SetToolTip(Me.picSplit, "US1 (Unit Split) consists of the required space to split a unit into two pieces")
      '
      'picGasHeater
      '
      Me.picGasHeater.Cursor = System.Windows.Forms.Cursors.SizeAll
      Me.picGasHeater.Image = Global.Rae.RaeSolutions.My.Resources.Resources.SectC5
      Me.picGasHeater.Location = New System.Drawing.Point(1236, 4)
      Me.picGasHeater.Name = "picGasHeater"
      Me.picGasHeater.Size = New System.Drawing.Size(72, 100)
      Me.picGasHeater.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.picGasHeater.TabIndex = 36
      Me.picGasHeater.TabStop = False
      Me.picGasHeater.Tag = "C5"
      Me.ToolTip1.SetToolTip(Me.picGasHeater, "C5 (Natural Gas Heater) consists of a natural gas heater.")
      '
      'SSTab2
      '
      Me.SSTab2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.SSTab2.Controls.Add(Me._SSTab2_TabPage0)
      Me.SSTab2.Controls.Add(Me._SSTab2_TabPage1)
      Me.SSTab2.Controls.Add(Me._SSTab2_TabPage2)
      Me.SSTab2.Controls.Add(Me._SSTab2_TabPage3)
      Me.SSTab2.Controls.Add(Me._SSTab2_TabPage4)
      Me.SSTab2.Controls.Add(Me._SSTab2_TabPage5)
      Me.SSTab2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.SSTab2.ItemSize = New System.Drawing.Size(42, 18)
      Me.SSTab2.Location = New System.Drawing.Point(6, 6)
      Me.SSTab2.Name = "SSTab2"
      Me.SSTab2.SelectedIndex = 0
      Me.SSTab2.Size = New System.Drawing.Size(724, 446)
      Me.SSTab2.TabIndex = 0
      '
      '_SSTab2_TabPage0
      '
      Me._SSTab2_TabPage0.BackColor = System.Drawing.SystemColors.ControlLightLight
      Me._SSTab2_TabPage0.Controls.Add(Me.GroupBox1)
        ''Me._SSTab2_TabPage0.Controls.Add(Me.dgrC1Select)
        Me._SSTab2_TabPage0.Controls.Add(Me.Label1)
      Me._SSTab2_TabPage0.Location = New System.Drawing.Point(4, 22)
      Me._SSTab2_TabPage0.Name = "_SSTab2_TabPage0"
      Me._SSTab2_TabPage0.Size = New System.Drawing.Size(716, 420)
      Me._SSTab2_TabPage0.TabIndex = 0
      Me._SSTab2_TabPage0.Text = "Cabinet Size"
      '
      'GroupBox1
      '
      Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.GroupBox1.Location = New System.Drawing.Point(12, 40)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(688, 8)
      Me.GroupBox1.TabIndex = 132
      Me.GroupBox1.TabStop = False
        '''
        '''dgrC1Select
        '''
        ''Me.dgrC1Select.AllowColSelect = False
        ''Me.dgrC1Select.AllowUpdate = False
        ''Me.dgrC1Select.AllowUpdateOnBlur = False
        ''Me.dgrC1Select.CaptionHeight = 17
        ''Me.dgrC1Select.DataSource = Me.AirHandlerData1.Coils
        ''Me.dgrC1Select.GroupByCaption = "Drag a column header here to group by that column"
        ''Me.dgrC1Select.Images.Add(CType(resources.GetObject("dgrC1Select.Images"), System.Drawing.Image))
        ''Me.dgrC1Select.Location = New System.Drawing.Point(20, 64)
        ''Me.dgrC1Select.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder
        ''Me.dgrC1Select.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
        ''Me.dgrC1Select.Name = "dgrC1Select"
        ''Me.dgrC1Select.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        ''Me.dgrC1Select.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        ''Me.dgrC1Select.PreviewInfo.ZoomFactor = 75
        ''Me.dgrC1Select.PrintInfo.PageSettings = CType(resources.GetObject("dgrC1Select.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        ''Me.dgrC1Select.RowHeight = 22
        ''Me.dgrC1Select.Size = New System.Drawing.Size(558, 296)
        ''Me.dgrC1Select.TabIndex = 131
        ''Me.dgrC1Select.Text = "Select Air Handler Model"
        ''Me.dgrC1Select.PropBag = resources.GetString("dgrC1Select.PropBag")
        '
        'AirHandlerData1
        '
        Me.AirHandlerData1.DataSetName = "AirHandlerData"
      Me.AirHandlerData1.Locale = New System.Globalization.CultureInfo("en-US")
      Me.AirHandlerData1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'Label1
      '
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.Label1.Location = New System.Drawing.Point(20, 20)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(360, 25)
      Me.Label1.TabIndex = 130
      Me.Label1.Text = "Select an air handler model."
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_SSTab2_TabPage1
      '
      Me._SSTab2_TabPage1.BackColor = System.Drawing.SystemColors.ControlLightLight
      Me._SSTab2_TabPage1.Controls.Add(Me.btnPrintDrawing)
      Me._SSTab2_TabPage1.Controls.Add(Me.GroupBox3)
      Me._SSTab2_TabPage1.Controls.Add(Me.GroupBox2)
      Me._SSTab2_TabPage1.Controls.Add(Me.btnSectionOptions)
      Me._SSTab2_TabPage1.Controls.Add(Me.lblDragInstructions)
      Me._SSTab2_TabPage1.Controls.Add(Me.btnDelete)
      Me._SSTab2_TabPage1.Controls.Add(Me.btnMoveLeft)
      Me._SSTab2_TabPage1.Controls.Add(Me.btnMoveRight)
      Me._SSTab2_TabPage1.Controls.Add(Me.panDropSections)
      Me._SSTab2_TabPage1.Controls.Add(Me.panDragSections)
      Me._SSTab2_TabPage1.Controls.Add(Me.lbl_unit_sections)
      Me._SSTab2_TabPage1.Controls.Add(Me.Line1)
        ''Me._SSTab2_TabPage1.Controls.Add(Me.dgrC1SectionInfo)
        Me._SSTab2_TabPage1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._SSTab2_TabPage1.Location = New System.Drawing.Point(4, 22)
      Me._SSTab2_TabPage1.Name = "_SSTab2_TabPage1"
      Me._SSTab2_TabPage1.Size = New System.Drawing.Size(716, 420)
      Me._SSTab2_TabPage1.TabIndex = 1
      Me._SSTab2_TabPage1.Text = "Unit Layout"
      '
      'btnPrintDrawing
      '
      Me.btnPrintDrawing.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnPrintDrawing.Location = New System.Drawing.Point(20, 222)
      Me.btnPrintDrawing.Name = "btnPrintDrawing"
      Me.btnPrintDrawing.Size = New System.Drawing.Size(90, 23)
      Me.btnPrintDrawing.TabIndex = 174
      Me.btnPrintDrawing.Text = "Print Drawing..."
      '
      'GroupBox3
      '
      Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.GroupBox3.Location = New System.Drawing.Point(12, 44)
      Me.GroupBox3.Name = "GroupBox3"
      Me.GroupBox3.Size = New System.Drawing.Size(686, 4)
      Me.GroupBox3.TabIndex = 173
      Me.GroupBox3.TabStop = False
      '
      'GroupBox2
      '
      Me.GroupBox2.Location = New System.Drawing.Point(25, 248)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(81, 6)
      Me.GroupBox2.TabIndex = 172
      Me.GroupBox2.TabStop = False
      '
      'btnSectionOptions
      '
      Me.btnSectionOptions.BackColor = System.Drawing.SystemColors.Control
      Me.btnSectionOptions.Enabled = False
      Me.btnSectionOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSectionOptions.Location = New System.Drawing.Point(22, 222)
      Me.btnSectionOptions.Name = "btnSectionOptions"
      Me.btnSectionOptions.Size = New System.Drawing.Size(62, 23)
      Me.btnSectionOptions.TabIndex = 171
      Me.btnSectionOptions.Text = "Options..."
      Me.btnSectionOptions.UseVisualStyleBackColor = False
      '
      'lblDragInstructions
      '
      Me.lblDragInstructions.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblDragInstructions.ForeColor = System.Drawing.SystemColors.ControlDark
      Me.lblDragInstructions.Location = New System.Drawing.Point(210, 254)
      Me.lblDragInstructions.Name = "lblDragInstructions"
      Me.lblDragInstructions.Size = New System.Drawing.Size(366, 30)
      Me.lblDragInstructions.TabIndex = 170
      Me.lblDragInstructions.Text = "Drag section drawings into this box"
      Me.lblDragInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnDelete
      '
      Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnDelete.Location = New System.Drawing.Point(20, 306)
      Me.btnDelete.Name = "btnDelete"
      Me.btnDelete.Size = New System.Drawing.Size(90, 22)
      Me.btnDelete.TabIndex = 169
      Me.btnDelete.Text = "Delete"
      '
      'btnMoveLeft
      '
      Me.btnMoveLeft.Enabled = False
      Me.btnMoveLeft.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnMoveLeft.Location = New System.Drawing.Point(20, 282)
      Me.btnMoveLeft.Name = "btnMoveLeft"
      Me.btnMoveLeft.Size = New System.Drawing.Size(90, 22)
      Me.btnMoveLeft.TabIndex = 168
      Me.btnMoveLeft.Text = "< Move"
      '
      'btnMoveRight
      '
      Me.btnMoveRight.BackColor = System.Drawing.SystemColors.Control
      Me.btnMoveRight.Enabled = False
      Me.btnMoveRight.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnMoveRight.Location = New System.Drawing.Point(20, 258)
      Me.btnMoveRight.Name = "btnMoveRight"
      Me.btnMoveRight.Size = New System.Drawing.Size(90, 22)
      Me.btnMoveRight.TabIndex = 167
      Me.btnMoveRight.Text = "Move >"
      Me.btnMoveRight.UseVisualStyleBackColor = False
      '
      'panDropSections
      '
      Me.panDropSections.AllowDrop = True
      Me.panDropSections.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.panDropSections.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.panDropSections.Location = New System.Drawing.Point(114, 216)
      Me.panDropSections.Name = "panDropSections"
      Me.panDropSections.Size = New System.Drawing.Size(578, 115)
      Me.panDropSections.TabIndex = 163
      '
      'panDragSections
      '
      Me.panDragSections.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.panDragSections.AutoScroll = True
      Me.panDragSections.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.panDragSections.Controls.Add(Me.lblGasHeater)
      Me.panDragSections.Controls.Add(Me.picGasHeater)
      Me.panDragSections.Controls.Add(Me.lblSplit)
      Me.panDragSections.Controls.Add(Me.picSplit)
      Me.panDragSections.Controls.Add(Me.lblDischarge2)
      Me.panDragSections.Controls.Add(Me.lblDischarge1)
      Me.panDragSections.Controls.Add(Me.lblSpace3)
      Me.panDragSections.Controls.Add(Me.lblSpace2)
      Me.panDragSections.Controls.Add(Me.lblSpace1)
      Me.panDragSections.Controls.Add(Me.picDischarge2)
      Me.panDragSections.Controls.Add(Me.picDischarge1)
      Me.panDragSections.Controls.Add(Me.picSpace3)
      Me.panDragSections.Controls.Add(Me.picSpace2)
      Me.panDragSections.Controls.Add(Me.picSpace1)
      Me.panDragSections.Controls.Add(Me.lblElectricHeater)
      Me.panDragSections.Controls.Add(Me.lblCoolingCoil)
      Me.panDragSections.Controls.Add(Me.lblCoil1)
      Me.panDragSections.Controls.Add(Me.picElectricHeater)
      Me.panDragSections.Controls.Add(Me.picCoolingCoil)
      Me.panDragSections.Controls.Add(Me.picHeatingCoil)
      Me.panDragSections.Controls.Add(Me.lblHouseFan2)
      Me.panDragSections.Controls.Add(Me.picHouseFan2)
      Me.panDragSections.Controls.Add(Me.lblHouseFan1)
      Me.panDragSections.Controls.Add(Me.picHouseFan1)
      Me.panDragSections.Controls.Add(Me.lblPlenumFan)
      Me.panDragSections.Controls.Add(Me.picPlenumFan)
      Me.panDragSections.Controls.Add(Me.lblPreFilterBag)
      Me.panDragSections.Controls.Add(Me.lblFilter)
      Me.panDragSections.Controls.Add(Me.lblAirBlender)
      Me.panDragSections.Controls.Add(Me.lblMixingBox)
      Me.panDragSections.Controls.Add(Me.picBlank)
      Me.panDragSections.Controls.Add(Me.picPreFilterBag)
      Me.panDragSections.Controls.Add(Me.picFilter)
      Me.panDragSections.Controls.Add(Me.picAirBlender)
      Me.panDragSections.Controls.Add(Me.picMixingBox)
      Me.panDragSections.Location = New System.Drawing.Point(20, 62)
      Me.panDragSections.Name = "panDragSections"
      Me.panDragSections.Size = New System.Drawing.Size(672, 152)
      Me.panDragSections.TabIndex = 165
      '
      'lblGasHeater
      '
      Me.lblGasHeater.Location = New System.Drawing.Point(1236, 108)
      Me.lblGasHeater.Name = "lblGasHeater"
      Me.lblGasHeater.Size = New System.Drawing.Size(72, 22)
      Me.lblGasHeater.TabIndex = 37
      Me.lblGasHeater.Text = "Gas Heater"
      Me.lblGasHeater.TextAlign = System.Drawing.ContentAlignment.TopCenter
      '
      'lblSplit
      '
      Me.lblSplit.Location = New System.Drawing.Point(1184, 108)
      Me.lblSplit.Name = "lblSplit"
      Me.lblSplit.Size = New System.Drawing.Size(34, 22)
      Me.lblSplit.TabIndex = 35
      Me.lblSplit.Text = "Split"
      Me.lblSplit.TextAlign = System.Drawing.ContentAlignment.TopCenter
      '
      'lblDischarge2
      '
      Me.lblDischarge2.Location = New System.Drawing.Point(1112, 108)
      Me.lblDischarge2.Name = "lblDischarge2"
      Me.lblDischarge2.Size = New System.Drawing.Size(68, 22)
      Me.lblDischarge2.TabIndex = 33
      Me.lblDischarge2.Text = "Discharge 2"
      Me.lblDischarge2.TextAlign = System.Drawing.ContentAlignment.TopCenter
      '
      'lblDischarge1
      '
      Me.lblDischarge1.Location = New System.Drawing.Point(1044, 108)
      Me.lblDischarge1.Name = "lblDischarge1"
      Me.lblDischarge1.Size = New System.Drawing.Size(64, 22)
      Me.lblDischarge1.TabIndex = 32
      Me.lblDischarge1.Text = "Discharge 1"
      Me.lblDischarge1.TextAlign = System.Drawing.ContentAlignment.TopCenter
      '
      'lblSpace3
      '
      Me.lblSpace3.Location = New System.Drawing.Point(980, 108)
      Me.lblSpace3.Name = "lblSpace3"
      Me.lblSpace3.Size = New System.Drawing.Size(52, 22)
      Me.lblSpace3.TabIndex = 31
      Me.lblSpace3.Text = "Space 3'"
      Me.lblSpace3.TextAlign = System.Drawing.ContentAlignment.TopCenter
      '
      'lblSpace2
      '
      Me.lblSpace2.Location = New System.Drawing.Point(928, 108)
      Me.lblSpace2.Name = "lblSpace2"
      Me.lblSpace2.Size = New System.Drawing.Size(48, 22)
      Me.lblSpace2.TabIndex = 30
      Me.lblSpace2.Text = "Space 2'"
      Me.lblSpace2.TextAlign = System.Drawing.ContentAlignment.TopCenter
      '
      'lblSpace1
      '
      Me.lblSpace1.Location = New System.Drawing.Point(872, 108)
      Me.lblSpace1.Name = "lblSpace1"
      Me.lblSpace1.Size = New System.Drawing.Size(56, 22)
      Me.lblSpace1.TabIndex = 29
      Me.lblSpace1.Text = "Space 1'"
      Me.lblSpace1.TextAlign = System.Drawing.ContentAlignment.TopCenter
      '
      'lblElectricHeater
      '
      Me.lblElectricHeater.Location = New System.Drawing.Point(796, 108)
      Me.lblElectricHeater.Name = "lblElectricHeater"
      Me.lblElectricHeater.Size = New System.Drawing.Size(80, 22)
      Me.lblElectricHeater.TabIndex = 23
      Me.lblElectricHeater.Text = "Electric Heater"
      Me.lblElectricHeater.TextAlign = System.Drawing.ContentAlignment.TopCenter
      '
      'lblCoolingCoil
      '
      Me.lblCoolingCoil.Location = New System.Drawing.Point(724, 108)
      Me.lblCoolingCoil.Name = "lblCoolingCoil"
      Me.lblCoolingCoil.Size = New System.Drawing.Size(64, 22)
      Me.lblCoolingCoil.TabIndex = 22
      Me.lblCoolingCoil.Text = "Cooling Coil"
      Me.lblCoolingCoil.TextAlign = System.Drawing.ContentAlignment.TopCenter
      '
      'lblCoil1
      '
      Me.lblCoil1.Location = New System.Drawing.Point(660, 108)
      Me.lblCoil1.Name = "lblCoil1"
      Me.lblCoil1.Size = New System.Drawing.Size(64, 22)
      Me.lblCoil1.TabIndex = 21
      Me.lblCoil1.Text = "Heating Coil"
      Me.lblCoil1.TextAlign = System.Drawing.ContentAlignment.TopCenter
      '
      'lblHouseFan2
      '
      Me.lblHouseFan2.Location = New System.Drawing.Point(576, 108)
      Me.lblHouseFan2.Name = "lblHouseFan2"
      Me.lblHouseFan2.Size = New System.Drawing.Size(76, 22)
      Me.lblHouseFan2.TabIndex = 17
      Me.lblHouseFan2.Text = "House Fan 2"
      Me.lblHouseFan2.TextAlign = System.Drawing.ContentAlignment.TopCenter
      '
      'lblHouseFan1
      '
      Me.lblHouseFan1.Location = New System.Drawing.Point(444, 108)
      Me.lblHouseFan1.Name = "lblHouseFan1"
      Me.lblHouseFan1.Size = New System.Drawing.Size(100, 22)
      Me.lblHouseFan1.TabIndex = 15
      Me.lblHouseFan1.Text = "House Fan 1"
      Me.lblHouseFan1.TextAlign = System.Drawing.ContentAlignment.TopCenter
      '
      'lblPlenumFan
      '
      Me.lblPlenumFan.Location = New System.Drawing.Point(296, 108)
      Me.lblPlenumFan.Name = "lblPlenumFan"
      Me.lblPlenumFan.Size = New System.Drawing.Size(120, 22)
      Me.lblPlenumFan.TabIndex = 13
      Me.lblPlenumFan.Text = "Plenum Fan"
      Me.lblPlenumFan.TextAlign = System.Drawing.ContentAlignment.TopCenter
      '
      'lblPreFilterBag
      '
      Me.lblPreFilterBag.Location = New System.Drawing.Point(236, 108)
      Me.lblPreFilterBag.Name = "lblPreFilterBag"
      Me.lblPreFilterBag.Size = New System.Drawing.Size(48, 22)
      Me.lblPreFilterBag.TabIndex = 8
      Me.lblPreFilterBag.Text = "Filter 2"
      Me.lblPreFilterBag.TextAlign = System.Drawing.ContentAlignment.TopCenter
      '
      'lblFilter
      '
      Me.lblFilter.Location = New System.Drawing.Point(196, 108)
      Me.lblFilter.Name = "lblFilter"
      Me.lblFilter.Size = New System.Drawing.Size(40, 23)
      Me.lblFilter.TabIndex = 7
      Me.lblFilter.Text = "Filter 1"
      Me.lblFilter.TextAlign = System.Drawing.ContentAlignment.TopCenter
      '
      'lblAirBlender
      '
      Me.lblAirBlender.Location = New System.Drawing.Point(128, 108)
      Me.lblAirBlender.Name = "lblAirBlender"
      Me.lblAirBlender.Size = New System.Drawing.Size(60, 22)
      Me.lblAirBlender.TabIndex = 6
      Me.lblAirBlender.Text = "Air Blender"
      Me.lblAirBlender.TextAlign = System.Drawing.ContentAlignment.TopCenter
      '
      'lblMixingBox
      '
      Me.lblMixingBox.Location = New System.Drawing.Point(8, 108)
      Me.lblMixingBox.Name = "lblMixingBox"
      Me.lblMixingBox.Size = New System.Drawing.Size(104, 22)
      Me.lblMixingBox.TabIndex = 5
      Me.lblMixingBox.Text = "Mixing Box"
      Me.lblMixingBox.TextAlign = System.Drawing.ContentAlignment.TopCenter
      '
      'picBlank
      '
      Me.picBlank.Location = New System.Drawing.Point(1325, 8)
      Me.picBlank.Name = "picBlank"
      Me.picBlank.Size = New System.Drawing.Size(5, 100)
      Me.picBlank.TabIndex = 4
      Me.picBlank.TabStop = False
      '
      'lbl_unit_sections
      '
      Me.lbl_unit_sections.BackColor = System.Drawing.Color.Transparent
      Me.lbl_unit_sections.Cursor = System.Windows.Forms.Cursors.Default
      Me.lbl_unit_sections.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lbl_unit_sections.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_unit_sections.Location = New System.Drawing.Point(20, 20)
      Me.lbl_unit_sections.Name = "lbl_unit_sections"
      Me.lbl_unit_sections.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lbl_unit_sections.Size = New System.Drawing.Size(584, 25)
      Me.lbl_unit_sections.TabIndex = 71
      Me.lbl_unit_sections.Text = "Drag section drawings from the upper box to the lower box to include them in the " & _
          "air handler."
      Me.lbl_unit_sections.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Line1
      '
      Me.Line1.BackColor = System.Drawing.SystemColors.WindowText
      Me.Line1.Location = New System.Drawing.Point(-4992, 96)
      Me.Line1.Name = "Line1"
      Me.Line1.Size = New System.Drawing.Size(874, 1)
      Me.Line1.TabIndex = 159
        '''
        '''dgrC1SectionInfo
        '''
        ''Me.dgrC1SectionInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
        ''            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ''Me.dgrC1SectionInfo.CaptionHeight = 2
        ''Me.dgrC1SectionInfo.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.Inverted
        ''Me.dgrC1SectionInfo.GroupByCaption = "Drag a column header here to group by that column"
        ''Me.dgrC1SectionInfo.Images.Add(CType(resources.GetObject("dgrC1SectionInfo.Images"), System.Drawing.Image))
        ''Me.dgrC1SectionInfo.Location = New System.Drawing.Point(20, 332)
        ''Me.dgrC1SectionInfo.Name = "dgrC1SectionInfo"
        ''Me.dgrC1SectionInfo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        ''Me.dgrC1SectionInfo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        ''Me.dgrC1SectionInfo.PreviewInfo.ZoomFactor = 75
        ''Me.dgrC1SectionInfo.PrintInfo.PageSettings = CType(resources.GetObject("dgrC1SectionInfo.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        ''Me.dgrC1SectionInfo.RecordSelectors = False
        ''Me.dgrC1SectionInfo.RecordSelectorWidth = 2
        ''Me.dgrC1SectionInfo.RowHeight = 22
        ''Me.dgrC1SectionInfo.Size = New System.Drawing.Size(672, 67)
        ''Me.dgrC1SectionInfo.TabIndex = 166
        ''Me.dgrC1SectionInfo.Text = "C1TrueDBGrid1"
        ''Me.dgrC1SectionInfo.ViewCaptionWidth = 75
        ''Me.dgrC1SectionInfo.ViewColumnWidth = 55
        ''Me.dgrC1SectionInfo.PropBag = resources.GetString("dgrC1SectionInfo.PropBag")
        '
        '_SSTab2_TabPage2
        '
        Me._SSTab2_TabPage2.BackColor = System.Drawing.SystemColors.ControlLightLight
      Me._SSTab2_TabPage2.Controls.Add(Me.panFF3Container)
      Me._SSTab2_TabPage2.Controls.Add(Me.panFF2Container)
      Me._SSTab2_TabPage2.Controls.Add(Me.panFF1Container)
      Me._SSTab2_TabPage2.Controls.Add(Me.panMB2Container)
      Me._SSTab2_TabPage2.Controls.Add(Me.panMB1Container)
      Me._SSTab2_TabPage2.Location = New System.Drawing.Point(4, 22)
      Me._SSTab2_TabPage2.Name = "_SSTab2_TabPage2"
      Me._SSTab2_TabPage2.Size = New System.Drawing.Size(716, 420)
      Me._SSTab2_TabPage2.TabIndex = 2
      Me._SSTab2_TabPage2.Text = "Mixing Box / Filters"
      '
      'panFF3Container
      '
      Me.panFF3Container.Controls.Add(Me.lblFF3OrderIndex)
      Me.panFF3Container.Controls.Add(Me.panFF3PreFilter)
      Me.panFF3Container.Controls.Add(Me._lbl_ff_2)
      Me.panFF3Container.Controls.Add(Me.lblFF3CostLabel)
      Me.panFF3Container.Controls.Add(Me.panFF3FinalFilter)
      Me.panFF3Container.Controls.Add(Me._lbl_ff_cost_2)
      Me.panFF3Container.Controls.Add(Me._lbl_ff_weight_2)
      Me.panFF3Container.Location = New System.Drawing.Point(224, 214)
      Me.panFF3Container.Name = "panFF3Container"
      Me.panFF3Container.Size = New System.Drawing.Size(228, 186)
      Me.panFF3Container.TabIndex = 363
      Me.panFF3Container.Tag = "-1"
      Me.panFF3Container.Visible = False
      '
      'lblFF3OrderIndex
      '
      Me.lblFF3OrderIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblFF3OrderIndex.Location = New System.Drawing.Point(192, 0)
      Me.lblFF3OrderIndex.Name = "lblFF3OrderIndex"
      Me.lblFF3OrderIndex.Size = New System.Drawing.Size(28, 23)
      Me.lblFF3OrderIndex.TabIndex = 361
      Me.lblFF3OrderIndex.Text = "-1"
      Me.lblFF3OrderIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'panFF3PreFilter
      '
      Me.panFF3PreFilter.BackColor = System.Drawing.Color.WhiteSmoke
      Me.panFF3PreFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.panFF3PreFilter.Controls.Add(Me.lblFF3Prefilter)
      Me.panFF3PreFilter.Controls.Add(Me.lblNumFilterSpares3)
      Me.panFF3PreFilter.Controls.Add(Me._cbo_pre_sets_2)
      Me.panFF3PreFilter.Controls.Add(Me._cbo_pre_ff_2)
      Me.panFF3PreFilter.Location = New System.Drawing.Point(0, 22)
      Me.panFF3PreFilter.Name = "panFF3PreFilter"
      Me.panFF3PreFilter.Size = New System.Drawing.Size(220, 70)
      Me.panFF3PreFilter.TabIndex = 357
      '
      'lblFF3Prefilter
      '
      Me.lblFF3Prefilter.Location = New System.Drawing.Point(4, 10)
      Me.lblFF3Prefilter.Name = "lblFF3Prefilter"
      Me.lblFF3Prefilter.Size = New System.Drawing.Size(64, 23)
      Me.lblFF3Prefilter.TabIndex = 280
      Me.lblFF3Prefilter.Text = "Pre-filter"
      Me.lblFF3Prefilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblNumFilterSpares3
      '
      Me.lblNumFilterSpares3.Location = New System.Drawing.Point(4, 34)
      Me.lblNumFilterSpares3.Name = "lblNumFilterSpares3"
      Me.lblNumFilterSpares3.Size = New System.Drawing.Size(64, 28)
      Me.lblNumFilterSpares3.TabIndex = 279
      Me.lblNumFilterSpares3.Text = "Number of spare sets"
      Me.lblNumFilterSpares3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_cbo_pre_sets_2
      '
      Me._cbo_pre_sets_2.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_pre_sets_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_pre_sets_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_pre_sets_2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_pre_sets.SetIndex(Me._cbo_pre_sets_2, CType(2, Short))
      Me._cbo_pre_sets_2.Location = New System.Drawing.Point(78, 38)
      Me._cbo_pre_sets_2.Name = "_cbo_pre_sets_2"
      Me._cbo_pre_sets_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_pre_sets_2.Size = New System.Drawing.Size(52, 21)
      Me._cbo_pre_sets_2.TabIndex = 269
      '
      '_cbo_pre_ff_2
      '
      Me._cbo_pre_ff_2.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_pre_ff_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_pre_ff_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_pre_ff_2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_pre_ff.SetIndex(Me._cbo_pre_ff_2, CType(2, Short))
      Me._cbo_pre_ff_2.Location = New System.Drawing.Point(78, 10)
      Me._cbo_pre_ff_2.Name = "_cbo_pre_ff_2"
      Me._cbo_pre_ff_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_pre_ff_2.Size = New System.Drawing.Size(126, 21)
      Me._cbo_pre_ff_2.TabIndex = 267
      '
      '_lbl_ff_2
      '
      Me._lbl_ff_2.BackColor = System.Drawing.Color.DarkGray
      Me._lbl_ff_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._lbl_ff_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_ff_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_ff_2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_ff.SetIndex(Me._lbl_ff_2, CType(2, Short))
      Me._lbl_ff_2.Location = New System.Drawing.Point(0, 0)
      Me._lbl_ff_2.Name = "_lbl_ff_2"
      Me._lbl_ff_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_ff_2.Size = New System.Drawing.Size(220, 23)
      Me._lbl_ff_2.TabIndex = 266
      Me._lbl_ff_2.Text = " Filter Type"
      Me._lbl_ff_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblFF3CostLabel
      '
      Me.lblFF3CostLabel.ForeColor = System.Drawing.Color.Blue
      Me.lblFF3CostLabel.Location = New System.Drawing.Point(8, 160)
      Me.lblFF3CostLabel.Name = "lblFF3CostLabel"
      Me.lblFF3CostLabel.Size = New System.Drawing.Size(60, 22)
      Me.lblFF3CostLabel.TabIndex = 360
      Me.lblFF3CostLabel.Text = "Filter cost"
      Me.lblFF3CostLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'panFF3FinalFilter
      '
      Me.panFF3FinalFilter.BackColor = System.Drawing.Color.WhiteSmoke
      Me.panFF3FinalFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.panFF3FinalFilter.Controls.Add(Me.lblFF3FinalFilter)
      Me.panFF3FinalFilter.Controls.Add(Me.lblNumSpareSets6)
      Me.panFF3FinalFilter.Controls.Add(Me._cbo_ff_sets_2)
      Me.panFF3FinalFilter.Controls.Add(Me._cbo_ff_2)
      Me.panFF3FinalFilter.Location = New System.Drawing.Point(0, 90)
      Me.panFF3FinalFilter.Name = "panFF3FinalFilter"
      Me.panFF3FinalFilter.Size = New System.Drawing.Size(220, 70)
      Me.panFF3FinalFilter.TabIndex = 358
      '
      'lblFF3FinalFilter
      '
      Me.lblFF3FinalFilter.Location = New System.Drawing.Point(4, 10)
      Me.lblFF3FinalFilter.Name = "lblFF3FinalFilter"
      Me.lblFF3FinalFilter.Size = New System.Drawing.Size(64, 23)
      Me.lblFF3FinalFilter.TabIndex = 281
      Me.lblFF3FinalFilter.Text = "Final Filter"
      Me.lblFF3FinalFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblNumSpareSets6
      '
      Me.lblNumSpareSets6.Location = New System.Drawing.Point(4, 34)
      Me.lblNumSpareSets6.Name = "lblNumSpareSets6"
      Me.lblNumSpareSets6.Size = New System.Drawing.Size(64, 28)
      Me.lblNumSpareSets6.TabIndex = 280
      Me.lblNumSpareSets6.Text = "Number of spare sets"
      Me.lblNumSpareSets6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_cbo_ff_sets_2
      '
      Me._cbo_ff_sets_2.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_ff_sets_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_ff_sets_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_ff_sets_2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_ff_sets.SetIndex(Me._cbo_ff_sets_2, CType(2, Short))
      Me._cbo_ff_sets_2.Location = New System.Drawing.Point(76, 38)
      Me._cbo_ff_sets_2.Name = "_cbo_ff_sets_2"
      Me._cbo_ff_sets_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_ff_sets_2.Size = New System.Drawing.Size(52, 21)
      Me._cbo_ff_sets_2.TabIndex = 272
      '
      '_cbo_ff_2
      '
      Me._cbo_ff_2.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_ff_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_ff_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_ff_2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_ff.SetIndex(Me._cbo_ff_2, CType(2, Short))
      Me._cbo_ff_2.Location = New System.Drawing.Point(76, 10)
      Me._cbo_ff_2.Name = "_cbo_ff_2"
      Me._cbo_ff_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_ff_2.Size = New System.Drawing.Size(128, 21)
      Me._cbo_ff_2.TabIndex = 270
      '
      '_lbl_ff_cost_2
      '
      Me._lbl_ff_cost_2.BackColor = System.Drawing.Color.Transparent
      Me._lbl_ff_cost_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_ff_cost_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_ff_cost_2.ForeColor = System.Drawing.Color.Blue
      Me.lbl_ff_cost.SetIndex(Me._lbl_ff_cost_2, CType(2, Short))
      Me._lbl_ff_cost_2.Location = New System.Drawing.Point(78, 160)
      Me._lbl_ff_cost_2.Name = "_lbl_ff_cost_2"
      Me._lbl_ff_cost_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_ff_cost_2.Size = New System.Drawing.Size(80, 22)
      Me._lbl_ff_cost_2.TabIndex = 275
      Me._lbl_ff_cost_2.Text = "0"
      Me._lbl_ff_cost_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me._lbl_ff_cost_2.Visible = False
      '
      '_lbl_ff_weight_2
      '
      Me._lbl_ff_weight_2.BackColor = System.Drawing.Color.Red
      Me._lbl_ff_weight_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_ff_weight_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_ff_weight_2.ForeColor = System.Drawing.Color.Blue
      Me.lbl_ff_weight.SetIndex(Me._lbl_ff_weight_2, CType(2, Short))
      Me._lbl_ff_weight_2.Location = New System.Drawing.Point(128, 160)
      Me._lbl_ff_weight_2.Name = "_lbl_ff_weight_2"
      Me._lbl_ff_weight_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_ff_weight_2.Size = New System.Drawing.Size(80, 22)
      Me._lbl_ff_weight_2.TabIndex = 278
      Me._lbl_ff_weight_2.Text = "Filter Weight"
      Me._lbl_ff_weight_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me._lbl_ff_weight_2.Visible = False
      '
      'panFF2Container
      '
      Me.panFF2Container.Controls.Add(Me.lblFF2OrderIndex)
      Me.panFF2Container.Controls.Add(Me.panFF2FinalFilter)
      Me.panFF2Container.Controls.Add(Me.panFF2Prefilter)
      Me.panFF2Container.Controls.Add(Me._lbl_ff_1)
      Me.panFF2Container.Controls.Add(Me._lbl_ff_cost_1)
      Me.panFF2Container.Controls.Add(Me.lblFF2CostLabel)
      Me.panFF2Container.Controls.Add(Me._lbl_ff_weight_1)
      Me.panFF2Container.Location = New System.Drawing.Point(478, 20)
      Me.panFF2Container.Name = "panFF2Container"
      Me.panFF2Container.Size = New System.Drawing.Size(226, 194)
      Me.panFF2Container.TabIndex = 362
      Me.panFF2Container.Tag = "-1"
      Me.panFF2Container.Visible = False
      '
      'lblFF2OrderIndex
      '
      Me.lblFF2OrderIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblFF2OrderIndex.Location = New System.Drawing.Point(192, 0)
      Me.lblFF2OrderIndex.Name = "lblFF2OrderIndex"
      Me.lblFF2OrderIndex.Size = New System.Drawing.Size(28, 23)
      Me.lblFF2OrderIndex.TabIndex = 360
      Me.lblFF2OrderIndex.Text = "-1"
      Me.lblFF2OrderIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'panFF2FinalFilter
      '
      Me.panFF2FinalFilter.BackColor = System.Drawing.Color.WhiteSmoke
      Me.panFF2FinalFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.panFF2FinalFilter.Controls.Add(Me.lblFF2FinalFilter)
      Me.panFF2FinalFilter.Controls.Add(Me.lblNumSpareSets5)
      Me.panFF2FinalFilter.Controls.Add(Me._cbo_ff_sets_1)
      Me.panFF2FinalFilter.Controls.Add(Me._cbo_ff_1)
      Me.panFF2FinalFilter.Location = New System.Drawing.Point(0, 90)
      Me.panFF2FinalFilter.Name = "panFF2FinalFilter"
      Me.panFF2FinalFilter.Size = New System.Drawing.Size(220, 72)
      Me.panFF2FinalFilter.TabIndex = 356
      '
      'lblFF2FinalFilter
      '
      Me.lblFF2FinalFilter.Location = New System.Drawing.Point(8, 10)
      Me.lblFF2FinalFilter.Name = "lblFF2FinalFilter"
      Me.lblFF2FinalFilter.Size = New System.Drawing.Size(60, 22)
      Me.lblFF2FinalFilter.TabIndex = 283
      Me.lblFF2FinalFilter.Text = "Final Filter"
      Me.lblFF2FinalFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblNumSpareSets5
      '
      Me.lblNumSpareSets5.Location = New System.Drawing.Point(4, 34)
      Me.lblNumSpareSets5.Name = "lblNumSpareSets5"
      Me.lblNumSpareSets5.Size = New System.Drawing.Size(64, 28)
      Me.lblNumSpareSets5.TabIndex = 280
      Me.lblNumSpareSets5.Text = "Number of spare sets"
      Me.lblNumSpareSets5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_cbo_ff_sets_1
      '
      Me._cbo_ff_sets_1.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_ff_sets_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_ff_sets_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_ff_sets_1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_ff_sets.SetIndex(Me._cbo_ff_sets_1, CType(1, Short))
      Me._cbo_ff_sets_1.Location = New System.Drawing.Point(76, 38)
      Me._cbo_ff_sets_1.Name = "_cbo_ff_sets_1"
      Me._cbo_ff_sets_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_ff_sets_1.Size = New System.Drawing.Size(52, 21)
      Me._cbo_ff_sets_1.TabIndex = 265
      '
      '_cbo_ff_1
      '
      Me._cbo_ff_1.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_ff_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_ff_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_ff_1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_ff.SetIndex(Me._cbo_ff_1, CType(1, Short))
      Me._cbo_ff_1.Location = New System.Drawing.Point(76, 10)
      Me._cbo_ff_1.Name = "_cbo_ff_1"
      Me._cbo_ff_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_ff_1.Size = New System.Drawing.Size(128, 21)
      Me._cbo_ff_1.TabIndex = 263
      '
      'panFF2Prefilter
      '
      Me.panFF2Prefilter.BackColor = System.Drawing.Color.WhiteSmoke
      Me.panFF2Prefilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.panFF2Prefilter.Controls.Add(Me.lblFF2Prefilter)
      Me.panFF2Prefilter.Controls.Add(Me._cbo_pre_ff_1)
      Me.panFF2Prefilter.Controls.Add(Me.lblNumFilterSpares2)
      Me.panFF2Prefilter.Controls.Add(Me._cbo_pre_sets_1)
      Me.panFF2Prefilter.Location = New System.Drawing.Point(0, 22)
      Me.panFF2Prefilter.Name = "panFF2Prefilter"
      Me.panFF2Prefilter.Size = New System.Drawing.Size(220, 70)
      Me.panFF2Prefilter.TabIndex = 355
      '
      'lblFF2Prefilter
      '
      Me.lblFF2Prefilter.Location = New System.Drawing.Point(4, 10)
      Me.lblFF2Prefilter.Name = "lblFF2Prefilter"
      Me.lblFF2Prefilter.Size = New System.Drawing.Size(62, 23)
      Me.lblFF2Prefilter.TabIndex = 279
      Me.lblFF2Prefilter.Text = "Pre-filter"
      Me.lblFF2Prefilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_cbo_pre_ff_1
      '
      Me._cbo_pre_ff_1.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_pre_ff_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_pre_ff_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_pre_ff_1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_pre_ff.SetIndex(Me._cbo_pre_ff_1, CType(1, Short))
      Me._cbo_pre_ff_1.Location = New System.Drawing.Point(76, 10)
      Me._cbo_pre_ff_1.Name = "_cbo_pre_ff_1"
      Me._cbo_pre_ff_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_pre_ff_1.Size = New System.Drawing.Size(128, 21)
      Me._cbo_pre_ff_1.TabIndex = 260
      '
      'lblNumFilterSpares2
      '
      Me.lblNumFilterSpares2.Location = New System.Drawing.Point(4, 34)
      Me.lblNumFilterSpares2.Name = "lblNumFilterSpares2"
      Me.lblNumFilterSpares2.Size = New System.Drawing.Size(64, 28)
      Me.lblNumFilterSpares2.TabIndex = 278
      Me.lblNumFilterSpares2.Text = "Number of spare sets"
      Me.lblNumFilterSpares2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_cbo_pre_sets_1
      '
      Me._cbo_pre_sets_1.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_pre_sets_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_pre_sets_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_pre_sets_1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_pre_sets.SetIndex(Me._cbo_pre_sets_1, CType(1, Short))
      Me._cbo_pre_sets_1.Location = New System.Drawing.Point(76, 38)
      Me._cbo_pre_sets_1.Name = "_cbo_pre_sets_1"
      Me._cbo_pre_sets_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_pre_sets_1.Size = New System.Drawing.Size(52, 21)
      Me._cbo_pre_sets_1.TabIndex = 262
      '
      '_lbl_ff_1
      '
      Me._lbl_ff_1.BackColor = System.Drawing.Color.DarkGray
      Me._lbl_ff_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._lbl_ff_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_ff_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_ff_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_ff.SetIndex(Me._lbl_ff_1, CType(1, Short))
      Me._lbl_ff_1.Location = New System.Drawing.Point(0, 0)
      Me._lbl_ff_1.Name = "_lbl_ff_1"
      Me._lbl_ff_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_ff_1.Size = New System.Drawing.Size(220, 23)
      Me._lbl_ff_1.TabIndex = 259
      Me._lbl_ff_1.Text = " FF2 (Filter)"
      Me._lbl_ff_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_lbl_ff_cost_1
      '
      Me._lbl_ff_cost_1.BackColor = System.Drawing.Color.Transparent
      Me._lbl_ff_cost_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_ff_cost_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_ff_cost_1.ForeColor = System.Drawing.Color.Blue
      Me.lbl_ff_cost.SetIndex(Me._lbl_ff_cost_1, CType(1, Short))
      Me._lbl_ff_cost_1.Location = New System.Drawing.Point(78, 162)
      Me._lbl_ff_cost_1.Name = "_lbl_ff_cost_1"
      Me._lbl_ff_cost_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_ff_cost_1.Size = New System.Drawing.Size(80, 22)
      Me._lbl_ff_cost_1.TabIndex = 274
      Me._lbl_ff_cost_1.Text = "0"
      Me._lbl_ff_cost_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me._lbl_ff_cost_1.Visible = False
      '
      'lblFF2CostLabel
      '
      Me.lblFF2CostLabel.ForeColor = System.Drawing.Color.Blue
      Me.lblFF2CostLabel.Location = New System.Drawing.Point(4, 162)
      Me.lblFF2CostLabel.Name = "lblFF2CostLabel"
      Me.lblFF2CostLabel.Size = New System.Drawing.Size(66, 22)
      Me.lblFF2CostLabel.TabIndex = 359
      Me.lblFF2CostLabel.Text = "Filter cost"
      Me.lblFF2CostLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_ff_weight_1
      '
      Me._lbl_ff_weight_1.BackColor = System.Drawing.Color.Red
      Me._lbl_ff_weight_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_ff_weight_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_ff_weight_1.ForeColor = System.Drawing.Color.Blue
      Me.lbl_ff_weight.SetIndex(Me._lbl_ff_weight_1, CType(1, Short))
      Me._lbl_ff_weight_1.Location = New System.Drawing.Point(128, 162)
      Me._lbl_ff_weight_1.Name = "_lbl_ff_weight_1"
      Me._lbl_ff_weight_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_ff_weight_1.Size = New System.Drawing.Size(80, 22)
      Me._lbl_ff_weight_1.TabIndex = 277
      Me._lbl_ff_weight_1.Text = "Filter Weight"
      Me._lbl_ff_weight_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me._lbl_ff_weight_1.Visible = False
      '
      'panFF1Container
      '
      Me.panFF1Container.Controls.Add(Me.lblFF1OrderIndex)
      Me.panFF1Container.Controls.Add(Me.panFF1FinalFilter)
      Me.panFF1Container.Controls.Add(Me._lbl_ff_0)
      Me.panFF1Container.Controls.Add(Me.lblFF1CostLabel)
      Me.panFF1Container.Controls.Add(Me.panFF1Prefilter)
      Me.panFF1Container.Controls.Add(Me._lbl_ff_cost_0)
      Me.panFF1Container.Controls.Add(Me._lbl_ff_weight_0)
      Me.panFF1Container.Location = New System.Drawing.Point(224, 20)
      Me.panFF1Container.Name = "panFF1Container"
      Me.panFF1Container.Size = New System.Drawing.Size(228, 184)
      Me.panFF1Container.TabIndex = 361
      Me.panFF1Container.Tag = "-1"
      Me.panFF1Container.Visible = False
      '
      'lblFF1OrderIndex
      '
      Me.lblFF1OrderIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblFF1OrderIndex.Location = New System.Drawing.Point(192, 0)
      Me.lblFF1OrderIndex.Name = "lblFF1OrderIndex"
      Me.lblFF1OrderIndex.Size = New System.Drawing.Size(28, 23)
      Me.lblFF1OrderIndex.TabIndex = 355
      Me.lblFF1OrderIndex.Text = "-1"
      Me.lblFF1OrderIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'panFF1FinalFilter
      '
      Me.panFF1FinalFilter.BackColor = System.Drawing.Color.WhiteSmoke
      Me.panFF1FinalFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.panFF1FinalFilter.Controls.Add(Me._cbo_ff_0)
      Me.panFF1FinalFilter.Controls.Add(Me.lblFF1FinalFilter)
      Me.panFF1FinalFilter.Controls.Add(Me.lblNumSpareSets4)
      Me.panFF1FinalFilter.Controls.Add(Me._cbo_ff_sets_0)
      Me.panFF1FinalFilter.Location = New System.Drawing.Point(0, 90)
      Me.panFF1FinalFilter.Name = "panFF1FinalFilter"
      Me.panFF1FinalFilter.Size = New System.Drawing.Size(220, 72)
      Me.panFF1FinalFilter.TabIndex = 353
      '
      '_cbo_ff_0
      '
      Me._cbo_ff_0.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_ff_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_ff_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_ff_0.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_ff.SetIndex(Me._cbo_ff_0, CType(0, Short))
      Me._cbo_ff_0.Location = New System.Drawing.Point(78, 10)
      Me._cbo_ff_0.Name = "_cbo_ff_0"
      Me._cbo_ff_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_ff_0.Size = New System.Drawing.Size(126, 21)
      Me._cbo_ff_0.TabIndex = 256
      '
      'lblFF1FinalFilter
      '
      Me.lblFF1FinalFilter.Location = New System.Drawing.Point(10, 10)
      Me.lblFF1FinalFilter.Name = "lblFF1FinalFilter"
      Me.lblFF1FinalFilter.Size = New System.Drawing.Size(60, 22)
      Me.lblFF1FinalFilter.TabIndex = 282
      Me.lblFF1FinalFilter.Text = "Final Filter"
      Me.lblFF1FinalFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblNumSpareSets4
      '
      Me.lblNumSpareSets4.Location = New System.Drawing.Point(6, 34)
      Me.lblNumSpareSets4.Name = "lblNumSpareSets4"
      Me.lblNumSpareSets4.Size = New System.Drawing.Size(64, 28)
      Me.lblNumSpareSets4.TabIndex = 280
      Me.lblNumSpareSets4.Text = "Number of spare sets"
      Me.lblNumSpareSets4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_cbo_ff_sets_0
      '
      Me._cbo_ff_sets_0.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_ff_sets_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_ff_sets_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_ff_sets_0.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_ff_sets.SetIndex(Me._cbo_ff_sets_0, CType(0, Short))
      Me._cbo_ff_sets_0.Location = New System.Drawing.Point(78, 38)
      Me._cbo_ff_sets_0.Name = "_cbo_ff_sets_0"
      Me._cbo_ff_sets_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_ff_sets_0.Size = New System.Drawing.Size(52, 21)
      Me._cbo_ff_sets_0.TabIndex = 258
      '
      '_lbl_ff_0
      '
      Me._lbl_ff_0.BackColor = System.Drawing.Color.DarkGray
      Me._lbl_ff_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._lbl_ff_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_ff_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_ff_0.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_ff.SetIndex(Me._lbl_ff_0, CType(0, Short))
      Me._lbl_ff_0.Location = New System.Drawing.Point(0, 0)
      Me._lbl_ff_0.Name = "_lbl_ff_0"
      Me._lbl_ff_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_ff_0.Size = New System.Drawing.Size(220, 23)
      Me._lbl_ff_0.TabIndex = 252
      Me._lbl_ff_0.Text = " FF1 (Filter)"
      Me._lbl_ff_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblFF1CostLabel
      '
      Me.lblFF1CostLabel.ForeColor = System.Drawing.Color.Blue
      Me.lblFF1CostLabel.Location = New System.Drawing.Point(4, 162)
      Me.lblFF1CostLabel.Name = "lblFF1CostLabel"
      Me.lblFF1CostLabel.Size = New System.Drawing.Size(66, 22)
      Me.lblFF1CostLabel.TabIndex = 354
      Me.lblFF1CostLabel.Text = "Filter cost"
      Me.lblFF1CostLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'panFF1Prefilter
      '
      Me.panFF1Prefilter.BackColor = System.Drawing.Color.WhiteSmoke
      Me.panFF1Prefilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.panFF1Prefilter.Controls.Add(Me._cbo_pre_sets_0)
      Me.panFF1Prefilter.Controls.Add(Me._cbo_pre_ff_0)
      Me.panFF1Prefilter.Controls.Add(Me.lblFF1Prefilter)
      Me.panFF1Prefilter.Controls.Add(Me.lblNumFilterSpares1)
      Me.panFF1Prefilter.Location = New System.Drawing.Point(0, 22)
      Me.panFF1Prefilter.Name = "panFF1Prefilter"
      Me.panFF1Prefilter.Size = New System.Drawing.Size(220, 70)
      Me.panFF1Prefilter.TabIndex = 352
      '
      '_cbo_pre_sets_0
      '
      Me._cbo_pre_sets_0.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_pre_sets_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_pre_sets_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_pre_sets_0.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_pre_sets.SetIndex(Me._cbo_pre_sets_0, CType(0, Short))
      Me._cbo_pre_sets_0.Location = New System.Drawing.Point(76, 38)
      Me._cbo_pre_sets_0.Name = "_cbo_pre_sets_0"
      Me._cbo_pre_sets_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_pre_sets_0.Size = New System.Drawing.Size(52, 21)
      Me._cbo_pre_sets_0.TabIndex = 255
      '
      '_cbo_pre_ff_0
      '
      Me._cbo_pre_ff_0.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_pre_ff_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_pre_ff_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_pre_ff_0.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_pre_ff.SetIndex(Me._cbo_pre_ff_0, CType(0, Short))
      Me._cbo_pre_ff_0.Location = New System.Drawing.Point(76, 10)
      Me._cbo_pre_ff_0.Name = "_cbo_pre_ff_0"
      Me._cbo_pre_ff_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_pre_ff_0.Size = New System.Drawing.Size(128, 21)
      Me._cbo_pre_ff_0.TabIndex = 253
      '
      'lblFF1Prefilter
      '
      Me.lblFF1Prefilter.Location = New System.Drawing.Point(4, 10)
      Me.lblFF1Prefilter.Name = "lblFF1Prefilter"
      Me.lblFF1Prefilter.Size = New System.Drawing.Size(64, 22)
      Me.lblFF1Prefilter.TabIndex = 281
      Me.lblFF1Prefilter.Text = "Pre-filter"
      Me.lblFF1Prefilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblNumFilterSpares1
      '
      Me.lblNumFilterSpares1.Location = New System.Drawing.Point(4, 34)
      Me.lblNumFilterSpares1.Name = "lblNumFilterSpares1"
      Me.lblNumFilterSpares1.Size = New System.Drawing.Size(64, 28)
      Me.lblNumFilterSpares1.TabIndex = 277
      Me.lblNumFilterSpares1.Text = "Number of spare sets"
      Me.lblNumFilterSpares1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_ff_cost_0
      '
      Me._lbl_ff_cost_0.BackColor = System.Drawing.Color.Transparent
      Me._lbl_ff_cost_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_ff_cost_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_ff_cost_0.ForeColor = System.Drawing.Color.Blue
      Me.lbl_ff_cost.SetIndex(Me._lbl_ff_cost_0, CType(0, Short))
      Me._lbl_ff_cost_0.Location = New System.Drawing.Point(80, 162)
      Me._lbl_ff_cost_0.Name = "_lbl_ff_cost_0"
      Me._lbl_ff_cost_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_ff_cost_0.Size = New System.Drawing.Size(80, 22)
      Me._lbl_ff_cost_0.TabIndex = 273
      Me._lbl_ff_cost_0.Text = "0"
      Me._lbl_ff_cost_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me._lbl_ff_cost_0.Visible = False
      '
      '_lbl_ff_weight_0
      '
      Me._lbl_ff_weight_0.BackColor = System.Drawing.Color.Red
      Me._lbl_ff_weight_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_ff_weight_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_ff_weight_0.ForeColor = System.Drawing.Color.Blue
      Me.lbl_ff_weight.SetIndex(Me._lbl_ff_weight_0, CType(0, Short))
      Me._lbl_ff_weight_0.Location = New System.Drawing.Point(128, 162)
      Me._lbl_ff_weight_0.Name = "_lbl_ff_weight_0"
      Me._lbl_ff_weight_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_ff_weight_0.Size = New System.Drawing.Size(80, 22)
      Me._lbl_ff_weight_0.TabIndex = 276
      Me._lbl_ff_weight_0.Text = "Filter Weight"
      Me._lbl_ff_weight_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me._lbl_ff_weight_0.Visible = False
      '
      'panMB2Container
      '
      Me.panMB2Container.Controls.Add(Me.lblMB2CasingChkValue)
      Me.panMB2Container.Controls.Add(Me.lblMB2OrderIndex)
      Me.panMB2Container.Controls.Add(Me.lblMB2Header)
      Me.panMB2Container.Controls.Add(Me.panMixingBox2)
      Me.panMB2Container.Controls.Add(Me.lblMB2CostLabel)
      Me.panMB2Container.Controls.Add(Me._lbl_MB1_cost_1)
      Me.panMB2Container.Location = New System.Drawing.Point(20, 214)
      Me.panMB2Container.Name = "panMB2Container"
      Me.panMB2Container.Size = New System.Drawing.Size(176, 140)
      Me.panMB2Container.TabIndex = 351
      Me.panMB2Container.Tag = "-1"
      Me.panMB2Container.Visible = False
      '
      'lblMB2CasingChkValue
      '
      Me.lblMB2CasingChkValue.BackColor = System.Drawing.Color.Yellow
      Me.lblMB2CasingChkValue.Location = New System.Drawing.Point(184, 132)
      Me.lblMB2CasingChkValue.Name = "lblMB2CasingChkValue"
      Me.lblMB2CasingChkValue.Size = New System.Drawing.Size(78, 23)
      Me.lblMB2CasingChkValue.TabIndex = 350
      Me.lblMB2CasingChkValue.Text = "b"
      Me.lblMB2CasingChkValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblMB2OrderIndex
      '
      Me.lblMB2OrderIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblMB2OrderIndex.Location = New System.Drawing.Point(140, 0)
      Me.lblMB2OrderIndex.Name = "lblMB2OrderIndex"
      Me.lblMB2OrderIndex.Size = New System.Drawing.Size(28, 23)
      Me.lblMB2OrderIndex.TabIndex = 349
      Me.lblMB2OrderIndex.Text = "-1"
      Me.lblMB2OrderIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblMB2Header
      '
      Me.lblMB2Header.BackColor = System.Drawing.Color.DarkGray
      Me.lblMB2Header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblMB2Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblMB2Header.Location = New System.Drawing.Point(0, 0)
      Me.lblMB2Header.Name = "lblMB2Header"
      Me.lblMB2Header.Size = New System.Drawing.Size(168, 23)
      Me.lblMB2Header.TabIndex = 169
      Me.lblMB2Header.Text = " Mixing Box (MB1)"
      Me.lblMB2Header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'panMixingBox2
      '
      Me.panMixingBox2.BackColor = System.Drawing.Color.WhiteSmoke
      Me.panMixingBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.panMixingBox2.Controls.Add(Me.lblMB2Casing)
      Me.panMixingBox2.Controls.Add(Me.lblMB2Air)
      Me.panMixingBox2.Controls.Add(Me._cbo_mixing_box_1)
      Me.panMixingBox2.Controls.Add(Me._ck_MB1_al_1)
      Me.panMixingBox2.Controls.Add(Me._ck_MB1_gal_1)
      Me.panMixingBox2.Location = New System.Drawing.Point(0, 22)
      Me.panMixingBox2.Name = "panMixingBox2"
      Me.panMixingBox2.Size = New System.Drawing.Size(168, 88)
      Me.panMixingBox2.TabIndex = 167
      '
      'lblMB2Casing
      '
      Me.lblMB2Casing.Location = New System.Drawing.Point(4, 36)
      Me.lblMB2Casing.Name = "lblMB2Casing"
      Me.lblMB2Casing.Size = New System.Drawing.Size(44, 22)
      Me.lblMB2Casing.TabIndex = 347
      Me.lblMB2Casing.Text = "Casing"
      Me.lblMB2Casing.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblMB2Air
      '
      Me.lblMB2Air.Location = New System.Drawing.Point(4, 8)
      Me.lblMB2Air.Name = "lblMB2Air"
      Me.lblMB2Air.Size = New System.Drawing.Size(44, 22)
      Me.lblMB2Air.TabIndex = 346
      Me.lblMB2Air.Text = "Air"
      Me.lblMB2Air.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_cbo_mixing_box_1
      '
      Me._cbo_mixing_box_1.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_mixing_box_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_mixing_box_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_mixing_box_1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_mixing_box.SetIndex(Me._cbo_mixing_box_1, CType(1, Short))
      Me._cbo_mixing_box_1.Location = New System.Drawing.Point(56, 10)
      Me._cbo_mixing_box_1.Name = "_cbo_mixing_box_1"
      Me._cbo_mixing_box_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_mixing_box_1.Size = New System.Drawing.Size(96, 21)
      Me._cbo_mixing_box_1.TabIndex = 344
      '
      '_ck_MB1_al_1
      '
      Me._ck_MB1_al_1.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_MB1_al_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_MB1_al_1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_MB1_al_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_MB1_al_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_MB1_al.SetIndex(Me._ck_MB1_al_1, CType(1, Short))
      Me._ck_MB1_al_1.Location = New System.Drawing.Point(56, 38)
      Me._ck_MB1_al_1.Name = "_ck_MB1_al_1"
      Me._ck_MB1_al_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_MB1_al_1.Size = New System.Drawing.Size(80, 22)
      Me._ck_MB1_al_1.TabIndex = 343
      Me._ck_MB1_al_1.Text = "Aluminum"
      Me._ck_MB1_al_1.UseVisualStyleBackColor = False
      '
      '_ck_MB1_gal_1
      '
      Me._ck_MB1_gal_1.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_MB1_gal_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_MB1_gal_1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_MB1_gal_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_MB1_gal_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_MB1_gal.SetIndex(Me._ck_MB1_gal_1, CType(1, Short))
      Me._ck_MB1_gal_1.Location = New System.Drawing.Point(56, 58)
      Me._ck_MB1_gal_1.Name = "_ck_MB1_gal_1"
      Me._ck_MB1_gal_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_MB1_gal_1.Size = New System.Drawing.Size(80, 22)
      Me._ck_MB1_gal_1.TabIndex = 342
      Me._ck_MB1_gal_1.Text = "Galvanized"
      Me._ck_MB1_gal_1.UseVisualStyleBackColor = False
      '
      'lblMB2CostLabel
      '
      Me.lblMB2CostLabel.ForeColor = System.Drawing.Color.Blue
      Me.lblMB2CostLabel.Location = New System.Drawing.Point(4, 110)
      Me.lblMB2CostLabel.Name = "lblMB2CostLabel"
      Me.lblMB2CostLabel.Size = New System.Drawing.Size(44, 22)
      Me.lblMB2CostLabel.TabIndex = 348
      Me.lblMB2CostLabel.Text = "Cost"
      Me.lblMB2CostLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_MB1_cost_1
      '
      Me._lbl_MB1_cost_1.BackColor = System.Drawing.SystemColors.ControlLightLight
      Me._lbl_MB1_cost_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_MB1_cost_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_MB1_cost_1.ForeColor = System.Drawing.Color.Blue
      Me.lbl_MB1_cost.SetIndex(Me._lbl_MB1_cost_1, CType(1, Short))
      Me._lbl_MB1_cost_1.Location = New System.Drawing.Point(56, 110)
      Me._lbl_MB1_cost_1.Name = "_lbl_MB1_cost_1"
      Me._lbl_MB1_cost_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_MB1_cost_1.Size = New System.Drawing.Size(88, 22)
      Me._lbl_MB1_cost_1.TabIndex = 345
      Me._lbl_MB1_cost_1.Text = "0"
      Me._lbl_MB1_cost_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me._lbl_MB1_cost_1.Visible = False
      '
      'panMB1Container
      '
      Me.panMB1Container.Controls.Add(Me.lblMB1CasingChkValue)
      Me.panMB1Container.Controls.Add(Me.lblMB1OrderIndex)
      Me.panMB1Container.Controls.Add(Me.panMixingBox1)
      Me.panMB1Container.Controls.Add(Me.lblMB1Header)
      Me.panMB1Container.Controls.Add(Me.lblMB1CostLabel)
      Me.panMB1Container.Controls.Add(Me._lbl_MB1_cost_0)
      Me.panMB1Container.Location = New System.Drawing.Point(20, 20)
      Me.panMB1Container.Name = "panMB1Container"
      Me.panMB1Container.Size = New System.Drawing.Size(176, 138)
      Me.panMB1Container.TabIndex = 350
      Me.panMB1Container.Tag = "-1"
      Me.panMB1Container.Visible = False
      '
      'lblMB1CasingChkValue
      '
      Me.lblMB1CasingChkValue.BackColor = System.Drawing.Color.Yellow
      Me.lblMB1CasingChkValue.Location = New System.Drawing.Point(184, 136)
      Me.lblMB1CasingChkValue.Name = "lblMB1CasingChkValue"
      Me.lblMB1CasingChkValue.Size = New System.Drawing.Size(74, 23)
      Me.lblMB1CasingChkValue.TabIndex = 171
      Me.lblMB1CasingChkValue.Text = "a"
      Me.lblMB1CasingChkValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblMB1OrderIndex
      '
      Me.lblMB1OrderIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblMB1OrderIndex.Location = New System.Drawing.Point(140, 0)
      Me.lblMB1OrderIndex.Name = "lblMB1OrderIndex"
      Me.lblMB1OrderIndex.Size = New System.Drawing.Size(28, 23)
      Me.lblMB1OrderIndex.TabIndex = 170
      Me.lblMB1OrderIndex.Text = "-1"
      Me.lblMB1OrderIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'panMixingBox1
      '
      Me.panMixingBox1.BackColor = System.Drawing.Color.WhiteSmoke
      Me.panMixingBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.panMixingBox1.Controls.Add(Me.lblMB1Casing)
      Me.panMixingBox1.Controls.Add(Me.lblMB1Air)
      Me.panMixingBox1.Controls.Add(Me._ck_MB1_gal_0)
      Me.panMixingBox1.Controls.Add(Me._ck_MB1_al_0)
      Me.panMixingBox1.Controls.Add(Me._cbo_mixing_box_0)
      Me.panMixingBox1.Location = New System.Drawing.Point(0, 22)
      Me.panMixingBox1.Name = "panMixingBox1"
      Me.panMixingBox1.Size = New System.Drawing.Size(168, 88)
      Me.panMixingBox1.TabIndex = 168
      '
      'lblMB1Casing
      '
      Me.lblMB1Casing.Location = New System.Drawing.Point(8, 38)
      Me.lblMB1Casing.Name = "lblMB1Casing"
      Me.lblMB1Casing.Size = New System.Drawing.Size(40, 22)
      Me.lblMB1Casing.TabIndex = 168
      Me.lblMB1Casing.Text = "Casing"
      Me.lblMB1Casing.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblMB1Air
      '
      Me.lblMB1Air.Location = New System.Drawing.Point(8, 10)
      Me.lblMB1Air.Name = "lblMB1Air"
      Me.lblMB1Air.Size = New System.Drawing.Size(40, 22)
      Me.lblMB1Air.TabIndex = 167
      Me.lblMB1Air.Text = "Air"
      Me.lblMB1Air.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_ck_MB1_gal_0
      '
      Me._ck_MB1_gal_0.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_MB1_gal_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_MB1_gal_0.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_MB1_gal_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_MB1_gal_0.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_MB1_gal.SetIndex(Me._ck_MB1_gal_0, CType(0, Short))
      Me._ck_MB1_gal_0.Location = New System.Drawing.Point(56, 58)
      Me._ck_MB1_gal_0.Name = "_ck_MB1_gal_0"
      Me._ck_MB1_gal_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_MB1_gal_0.Size = New System.Drawing.Size(80, 22)
      Me._ck_MB1_gal_0.TabIndex = 3
      Me._ck_MB1_gal_0.Text = "Galvanized"
      Me._ck_MB1_gal_0.UseVisualStyleBackColor = False
      '
      '_ck_MB1_al_0
      '
      Me._ck_MB1_al_0.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_MB1_al_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_MB1_al_0.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_MB1_al_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_MB1_al_0.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_MB1_al.SetIndex(Me._ck_MB1_al_0, CType(0, Short))
      Me._ck_MB1_al_0.Location = New System.Drawing.Point(56, 38)
      Me._ck_MB1_al_0.Name = "_ck_MB1_al_0"
      Me._ck_MB1_al_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_MB1_al_0.Size = New System.Drawing.Size(80, 22)
      Me._ck_MB1_al_0.TabIndex = 2
      Me._ck_MB1_al_0.Text = "Aluminum"
      Me._ck_MB1_al_0.UseVisualStyleBackColor = False
      '
      '_cbo_mixing_box_0
      '
      Me._cbo_mixing_box_0.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_mixing_box_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_mixing_box_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_mixing_box_0.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_mixing_box.SetIndex(Me._cbo_mixing_box_0, CType(0, Short))
      Me._cbo_mixing_box_0.Location = New System.Drawing.Point(56, 10)
      Me._cbo_mixing_box_0.Name = "_cbo_mixing_box_0"
      Me._cbo_mixing_box_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_mixing_box_0.Size = New System.Drawing.Size(96, 21)
      Me._cbo_mixing_box_0.TabIndex = 1
      '
      'lblMB1Header
      '
      Me.lblMB1Header.BackColor = System.Drawing.Color.DarkGray
      Me.lblMB1Header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblMB1Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblMB1Header.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblMB1Header.Location = New System.Drawing.Point(0, 0)
      Me.lblMB1Header.Name = "lblMB1Header"
      Me.lblMB1Header.Size = New System.Drawing.Size(168, 23)
      Me.lblMB1Header.TabIndex = 0
      Me.lblMB1Header.Text = " Mixing Box (MB1)"
      Me.lblMB1Header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblMB1CostLabel
      '
      Me.lblMB1CostLabel.ForeColor = System.Drawing.Color.Blue
      Me.lblMB1CostLabel.Location = New System.Drawing.Point(8, 110)
      Me.lblMB1CostLabel.Name = "lblMB1CostLabel"
      Me.lblMB1CostLabel.Size = New System.Drawing.Size(40, 22)
      Me.lblMB1CostLabel.TabIndex = 169
      Me.lblMB1CostLabel.Text = "Cost"
      Me.lblMB1CostLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_MB1_cost_0
      '
      Me._lbl_MB1_cost_0.BackColor = System.Drawing.Color.Transparent
      Me._lbl_MB1_cost_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_MB1_cost_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_MB1_cost_0.ForeColor = System.Drawing.Color.Blue
      Me.lbl_MB1_cost.SetIndex(Me._lbl_MB1_cost_0, CType(0, Short))
      Me._lbl_MB1_cost_0.Location = New System.Drawing.Point(56, 110)
      Me._lbl_MB1_cost_0.Name = "_lbl_MB1_cost_0"
      Me._lbl_MB1_cost_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_MB1_cost_0.Size = New System.Drawing.Size(84, 22)
      Me._lbl_MB1_cost_0.TabIndex = 166
      Me._lbl_MB1_cost_0.Text = "0"
      Me._lbl_MB1_cost_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me._lbl_MB1_cost_0.Visible = False
      '
      '_SSTab2_TabPage3
      '
      Me._SSTab2_TabPage3.BackColor = System.Drawing.SystemColors.ControlLightLight
      Me._SSTab2_TabPage3.Controls.Add(Me.panFan3Container)
      Me._SSTab2_TabPage3.Controls.Add(Me.panFan2Container)
      Me._SSTab2_TabPage3.Controls.Add(Me.panFan1Container)
      Me._SSTab2_TabPage3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._SSTab2_TabPage3.Location = New System.Drawing.Point(4, 22)
      Me._SSTab2_TabPage3.Name = "_SSTab2_TabPage3"
      Me._SSTab2_TabPage3.Size = New System.Drawing.Size(716, 420)
      Me._SSTab2_TabPage3.TabIndex = 3
      Me._SSTab2_TabPage3.Text = "Fans"
      '
      'panFan3Container
      '
      Me.panFan3Container.Controls.Add(Me.lblEnclosure3)
      Me.panFan3Container.Controls.Add(Me.lblEfficiency3)
      Me.panFan3Container.Controls.Add(Me.lblFan3OrderIndex)
      Me.panFan3Container.Controls.Add(Me.panFan3Fan)
      Me.panFan3Container.Controls.Add(Me.lblIsolatorCostLabel3)
      Me.panFan3Container.Controls.Add(Me.panFan3Motor)
      Me.panFan3Container.Controls.Add(Me._lbl_fan_type_2)
      Me.panFan3Container.Controls.Add(Me.Label7)
      Me.panFan3Container.Controls.Add(Me._lbl_motor_weight_2)
      Me.panFan3Container.Controls.Add(Me.lblFanCostLabel3)
      Me.panFan3Container.Controls.Add(Me._lbl_fan_cost_2)
      Me.panFan3Container.Controls.Add(Me._lbl_iso_cost_2)
      Me.panFan3Container.Controls.Add(Me.lblMotorCostLabel3)
      Me.panFan3Container.Controls.Add(Me._lbl_motor_cost_2)
      Me.panFan3Container.Controls.Add(Me._lbl_iso_weight_2)
      Me.panFan3Container.Controls.Add(Me._lbl_fan_weight_2)
      Me.panFan3Container.Location = New System.Drawing.Point(480, 20)
      Me.panFan3Container.Name = "panFan3Container"
      Me.panFan3Container.Size = New System.Drawing.Size(224, 382)
      Me.panFan3Container.TabIndex = 348
      Me.panFan3Container.Visible = False
      '
      'lblEnclosure3
      '
      Me.lblEnclosure3.BackColor = System.Drawing.Color.Yellow
      Me.lblEnclosure3.Location = New System.Drawing.Point(128, 388)
      Me.lblEnclosure3.Name = "lblEnclosure3"
      Me.lblEnclosure3.Size = New System.Drawing.Size(80, 20)
      Me.lblEnclosure3.TabIndex = 347
      Me.lblEnclosure3.Text = "Label35"
      '
      'lblEfficiency3
      '
      Me.lblEfficiency3.BackColor = System.Drawing.Color.Yellow
      Me.lblEfficiency3.Location = New System.Drawing.Point(14, 388)
      Me.lblEfficiency3.Name = "lblEfficiency3"
      Me.lblEfficiency3.Size = New System.Drawing.Size(80, 20)
      Me.lblEfficiency3.TabIndex = 346
      Me.lblEfficiency3.Text = "Label34"
      '
      'lblFan3OrderIndex
      '
      Me.lblFan3OrderIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblFan3OrderIndex.Location = New System.Drawing.Point(186, 0)
      Me.lblFan3OrderIndex.Name = "lblFan3OrderIndex"
      Me.lblFan3OrderIndex.Size = New System.Drawing.Size(28, 23)
      Me.lblFan3OrderIndex.TabIndex = 345
      Me.lblFan3OrderIndex.Text = "-1"
      Me.lblFan3OrderIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'panFan3Fan
      '
      Me.panFan3Fan.BackColor = System.Drawing.Color.WhiteSmoke
      Me.panFan3Fan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.panFan3Fan.Controls.Add(Me._lbl_fan_info_2)
      Me.panFan3Fan.Controls.Add(Me._cbo_fan_size_2)
      Me.panFan3Fan.Controls.Add(Me._cbo_fan_iso_2)
      Me.panFan3Fan.Controls.Add(Me._cbo_fan_type_2)
      Me.panFan3Fan.Controls.Add(Me.Label2)
      Me.panFan3Fan.Controls.Add(Me.Label3)
      Me.panFan3Fan.Controls.Add(Me.Label4)
      Me.panFan3Fan.Controls.Add(Me._cbo_drive_type_2)
      Me.panFan3Fan.Controls.Add(Me.Label5)
      Me.panFan3Fan.Controls.Add(Me.Label6)
      Me.panFan3Fan.Controls.Add(Me._cbo_fan_class_2)
      Me.panFan3Fan.Location = New System.Drawing.Point(0, 150)
      Me.panFan3Fan.Name = "panFan3Fan"
      Me.panFan3Fan.Size = New System.Drawing.Size(214, 156)
      Me.panFan3Fan.TabIndex = 342
      '
      '_lbl_fan_info_2
      '
      Me._lbl_fan_info_2.BackColor = System.Drawing.Color.LightGray
      Me._lbl_fan_info_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._lbl_fan_info_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_fan_info_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_fan_info_2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_fan_info.SetIndex(Me._lbl_fan_info_2, CType(2, Short))
      Me._lbl_fan_info_2.Location = New System.Drawing.Point(-1, -1)
      Me._lbl_fan_info_2.Name = "_lbl_fan_info_2"
      Me._lbl_fan_info_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_fan_info_2.Size = New System.Drawing.Size(214, 23)
      Me._lbl_fan_info_2.TabIndex = 319
      Me._lbl_fan_info_2.Text = "Fan Information"
      Me._lbl_fan_info_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_cbo_fan_size_2
      '
      Me._cbo_fan_size_2.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_fan_size_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_fan_size_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_fan_size_2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_fan_size.SetIndex(Me._cbo_fan_size_2, CType(2, Short))
      Me._cbo_fan_size_2.Location = New System.Drawing.Point(84, 78)
      Me._cbo_fan_size_2.Name = "_cbo_fan_size_2"
      Me._cbo_fan_size_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_fan_size_2.Size = New System.Drawing.Size(89, 22)
      Me._cbo_fan_size_2.TabIndex = 311
      '
      '_cbo_fan_iso_2
      '
      Me._cbo_fan_iso_2.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_fan_iso_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_fan_iso_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_fan_iso_2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_fan_iso.SetIndex(Me._cbo_fan_iso_2, CType(2, Short))
      Me._cbo_fan_iso_2.Location = New System.Drawing.Point(84, 126)
      Me._cbo_fan_iso_2.Name = "_cbo_fan_iso_2"
      Me._cbo_fan_iso_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_fan_iso_2.Size = New System.Drawing.Size(89, 22)
      Me._cbo_fan_iso_2.TabIndex = 309
      '
      '_cbo_fan_type_2
      '
      Me._cbo_fan_type_2.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_fan_type_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_fan_type_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_fan_type_2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_fan_type.SetIndex(Me._cbo_fan_type_2, CType(2, Short))
      Me._cbo_fan_type_2.Location = New System.Drawing.Point(84, 30)
      Me._cbo_fan_type_2.Name = "_cbo_fan_type_2"
      Me._cbo_fan_type_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_fan_type_2.Size = New System.Drawing.Size(89, 22)
      Me._cbo_fan_type_2.TabIndex = 313
      '
      'Label2
      '
      Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.Location = New System.Drawing.Point(10, 126)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(64, 22)
      Me.Label2.TabIndex = 355
      Me.Label2.Text = "Isolation"
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label3
      '
      Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.Location = New System.Drawing.Point(10, 102)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(64, 22)
      Me.Label3.TabIndex = 354
      Me.Label3.Text = "Drive"
      Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label4
      '
      Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label4.Location = New System.Drawing.Point(10, 78)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(64, 22)
      Me.Label4.TabIndex = 353
      Me.Label4.Text = "Size"
      Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_cbo_drive_type_2
      '
      Me._cbo_drive_type_2.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_drive_type_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_drive_type_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_drive_type_2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_drive_type.SetIndex(Me._cbo_drive_type_2, CType(2, Short))
      Me._cbo_drive_type_2.Location = New System.Drawing.Point(84, 102)
      Me._cbo_drive_type_2.Name = "_cbo_drive_type_2"
      Me._cbo_drive_type_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_drive_type_2.Size = New System.Drawing.Size(89, 22)
      Me._cbo_drive_type_2.TabIndex = 310
      '
      'Label5
      '
      Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label5.Location = New System.Drawing.Point(10, 54)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(64, 22)
      Me.Label5.TabIndex = 352
      Me.Label5.Text = "Class"
      Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label6
      '
      Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label6.Location = New System.Drawing.Point(10, 30)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(64, 22)
      Me.Label6.TabIndex = 351
      Me.Label6.Text = "Type"
      Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_cbo_fan_class_2
      '
      Me._cbo_fan_class_2.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_fan_class_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_fan_class_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_fan_class_2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_fan_class.SetIndex(Me._cbo_fan_class_2, CType(2, Short))
      Me._cbo_fan_class_2.Location = New System.Drawing.Point(84, 54)
      Me._cbo_fan_class_2.Name = "_cbo_fan_class_2"
      Me._cbo_fan_class_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_fan_class_2.Size = New System.Drawing.Size(89, 22)
      Me._cbo_fan_class_2.TabIndex = 312
      '
      'lblIsolatorCostLabel3
      '
      Me.lblIsolatorCostLabel3.ForeColor = System.Drawing.Color.Blue
      Me.lblIsolatorCostLabel3.Location = New System.Drawing.Point(6, 350)
      Me.lblIsolatorCostLabel3.Name = "lblIsolatorCostLabel3"
      Me.lblIsolatorCostLabel3.Size = New System.Drawing.Size(70, 23)
      Me.lblIsolatorCostLabel3.TabIndex = 344
      Me.lblIsolatorCostLabel3.Text = "Isolator cost"
      Me.lblIsolatorCostLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'panFan3Motor
      '
      Me.panFan3Motor.BackColor = System.Drawing.Color.WhiteSmoke
      Me.panFan3Motor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.panFan3Motor.Controls.Add(Me._lbl_motor_info_2)
      Me.panFan3Motor.Controls.Add(Me._cbo_rpm_2)
      Me.panFan3Motor.Controls.Add(Me._cbo_hp_2)
      Me.panFan3Motor.Controls.Add(Me._lbl_hp_2)
      Me.panFan3Motor.Controls.Add(Me._lbl_eff_2)
      Me.panFan3Motor.Controls.Add(Me._lbl_enclosure_2)
      Me.panFan3Motor.Controls.Add(Me._lbl_rpm_2)
      Me.panFan3Motor.Controls.Add(Me._ck_odp_2)
      Me.panFan3Motor.Controls.Add(Me._ck_high_2)
      Me.panFan3Motor.Controls.Add(Me._ck_tefc_2)
      Me.panFan3Motor.Controls.Add(Me._ck_premium_2)
      Me.panFan3Motor.Location = New System.Drawing.Point(0, 22)
      Me.panFan3Motor.Name = "panFan3Motor"
      Me.panFan3Motor.Size = New System.Drawing.Size(214, 130)
      Me.panFan3Motor.TabIndex = 322
      '
      '_lbl_motor_info_2
      '
      Me._lbl_motor_info_2.BackColor = System.Drawing.Color.LightGray
      Me._lbl_motor_info_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._lbl_motor_info_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_motor_info_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_motor_info_2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_motor_info.SetIndex(Me._lbl_motor_info_2, CType(2, Short))
      Me._lbl_motor_info_2.Location = New System.Drawing.Point(-1, -1)
      Me._lbl_motor_info_2.Name = "_lbl_motor_info_2"
      Me._lbl_motor_info_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_motor_info_2.Size = New System.Drawing.Size(214, 23)
      Me._lbl_motor_info_2.TabIndex = 324
      Me._lbl_motor_info_2.Text = " Motor Information"
      Me._lbl_motor_info_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_cbo_rpm_2
      '
      Me._cbo_rpm_2.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_rpm_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_rpm_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_rpm_2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_rpm.SetIndex(Me._cbo_rpm_2, CType(2, Short))
      Me._cbo_rpm_2.Location = New System.Drawing.Point(82, 98)
      Me._cbo_rpm_2.Name = "_cbo_rpm_2"
      Me._cbo_rpm_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_rpm_2.Size = New System.Drawing.Size(89, 22)
      Me._cbo_rpm_2.TabIndex = 305
      '
      '_cbo_hp_2
      '
      Me._cbo_hp_2.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_hp_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_hp_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_hp_2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_hp.SetIndex(Me._cbo_hp_2, CType(2, Short))
      Me._cbo_hp_2.Location = New System.Drawing.Point(82, 74)
      Me._cbo_hp_2.Name = "_cbo_hp_2"
      Me._cbo_hp_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_hp_2.Size = New System.Drawing.Size(89, 22)
      Me._cbo_hp_2.TabIndex = 306
      '
      '_lbl_hp_2
      '
      Me._lbl_hp_2.BackColor = System.Drawing.Color.Transparent
      Me._lbl_hp_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_hp_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_hp_2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_hp.SetIndex(Me._lbl_hp_2, CType(2, Short))
      Me._lbl_hp_2.Location = New System.Drawing.Point(6, 74)
      Me._lbl_hp_2.Name = "_lbl_hp_2"
      Me._lbl_hp_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_hp_2.Size = New System.Drawing.Size(68, 22)
      Me._lbl_hp_2.TabIndex = 326
      Me._lbl_hp_2.Text = "Horsepower"
      Me._lbl_hp_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_eff_2
      '
      Me._lbl_eff_2.BackColor = System.Drawing.Color.Transparent
      Me._lbl_eff_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_eff_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_eff_2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_eff.SetIndex(Me._lbl_eff_2, CType(2, Short))
      Me._lbl_eff_2.Location = New System.Drawing.Point(6, 26)
      Me._lbl_eff_2.Name = "_lbl_eff_2"
      Me._lbl_eff_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_eff_2.Size = New System.Drawing.Size(68, 22)
      Me._lbl_eff_2.TabIndex = 322
      Me._lbl_eff_2.Text = "Effenciency"
      Me._lbl_eff_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_enclosure_2
      '
      Me._lbl_enclosure_2.BackColor = System.Drawing.Color.Transparent
      Me._lbl_enclosure_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_enclosure_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_enclosure_2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_enclosure.SetIndex(Me._lbl_enclosure_2, CType(2, Short))
      Me._lbl_enclosure_2.Location = New System.Drawing.Point(6, 50)
      Me._lbl_enclosure_2.Name = "_lbl_enclosure_2"
      Me._lbl_enclosure_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_enclosure_2.Size = New System.Drawing.Size(68, 22)
      Me._lbl_enclosure_2.TabIndex = 323
      Me._lbl_enclosure_2.Text = "Enclosure"
      Me._lbl_enclosure_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_rpm_2
      '
      Me._lbl_rpm_2.BackColor = System.Drawing.Color.Transparent
      Me._lbl_rpm_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_rpm_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_rpm_2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_rpm.SetIndex(Me._lbl_rpm_2, CType(2, Short))
      Me._lbl_rpm_2.Location = New System.Drawing.Point(6, 98)
      Me._lbl_rpm_2.Name = "_lbl_rpm_2"
      Me._lbl_rpm_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_rpm_2.Size = New System.Drawing.Size(68, 22)
      Me._lbl_rpm_2.TabIndex = 325
      Me._lbl_rpm_2.Text = "RPM"
      Me._lbl_rpm_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_ck_odp_2
      '
      Me._ck_odp_2.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_odp_2.Checked = True
      Me._ck_odp_2.CheckState = System.Windows.Forms.CheckState.Checked
      Me._ck_odp_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_odp_2.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_odp_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_odp_2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_odp.SetIndex(Me._ck_odp_2, CType(2, Short))
      Me._ck_odp_2.Location = New System.Drawing.Point(82, 50)
      Me._ck_odp_2.Name = "_ck_odp_2"
      Me._ck_odp_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_odp_2.Size = New System.Drawing.Size(52, 22)
      Me._ck_odp_2.TabIndex = 307
      Me._ck_odp_2.Text = "ODP"
      Me._ck_odp_2.UseVisualStyleBackColor = False
      '
      '_ck_high_2
      '
      Me._ck_high_2.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_high_2.Checked = True
      Me._ck_high_2.CheckState = System.Windows.Forms.CheckState.Checked
      Me._ck_high_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_high_2.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_high_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_high_2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_high.SetIndex(Me._ck_high_2, CType(2, Short))
      Me._ck_high_2.Location = New System.Drawing.Point(82, 26)
      Me._ck_high_2.Name = "_ck_high_2"
      Me._ck_high_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_high_2.Size = New System.Drawing.Size(52, 22)
      Me._ck_high_2.TabIndex = 308
      Me._ck_high_2.Text = "High"
      Me._ck_high_2.UseVisualStyleBackColor = False
      '
      '_ck_tefc_2
      '
      Me._ck_tefc_2.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_tefc_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_tefc_2.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_tefc_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_tefc_2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_tefc.SetIndex(Me._ck_tefc_2, CType(2, Short))
      Me._ck_tefc_2.Location = New System.Drawing.Point(138, 50)
      Me._ck_tefc_2.Name = "_ck_tefc_2"
      Me._ck_tefc_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_tefc_2.Size = New System.Drawing.Size(68, 22)
      Me._ck_tefc_2.TabIndex = 303
      Me._ck_tefc_2.Text = "TEFC"
      Me._ck_tefc_2.UseVisualStyleBackColor = False
      '
      '_ck_premium_2
      '
      Me._ck_premium_2.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_premium_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_premium_2.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_premium_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_premium_2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_premium.SetIndex(Me._ck_premium_2, CType(2, Short))
      Me._ck_premium_2.Location = New System.Drawing.Point(138, 26)
      Me._ck_premium_2.Name = "_ck_premium_2"
      Me._ck_premium_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_premium_2.Size = New System.Drawing.Size(68, 22)
      Me._ck_premium_2.TabIndex = 304
      Me._ck_premium_2.Text = "Premium"
      Me._ck_premium_2.UseVisualStyleBackColor = False
      '
      '_lbl_fan_type_2
      '
      Me._lbl_fan_type_2.BackColor = System.Drawing.Color.DarkGray
      Me._lbl_fan_type_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._lbl_fan_type_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_fan_type_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_fan_type_2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_fan_type.SetIndex(Me._lbl_fan_type_2, CType(2, Short))
      Me._lbl_fan_type_2.Location = New System.Drawing.Point(0, 0)
      Me._lbl_fan_type_2.Name = "_lbl_fan_type_2"
      Me._lbl_fan_type_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_fan_type_2.Size = New System.Drawing.Size(214, 23)
      Me._lbl_fan_type_2.TabIndex = 321
      Me._lbl_fan_type_2.Text = " Plenum Fan (PF1)"
      Me._lbl_fan_type_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label7
      '
      Me.Label7.BackColor = System.Drawing.Color.Red
      Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label7.ForeColor = System.Drawing.Color.Blue
      Me.Label7.Location = New System.Drawing.Point(184, 132)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(60, 23)
      Me.Label7.TabIndex = 341
      Me.Label7.Text = "Motor Weight"
      Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.Label7.Visible = False
      '
      '_lbl_motor_weight_2
      '
      Me._lbl_motor_weight_2.BackColor = System.Drawing.Color.Red
      Me._lbl_motor_weight_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_motor_weight_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_motor_weight_2.ForeColor = System.Drawing.Color.Blue
      Me.lbl_motor_weight.SetIndex(Me._lbl_motor_weight_2, CType(2, Short))
      Me._lbl_motor_weight_2.Location = New System.Drawing.Point(212, 152)
      Me._lbl_motor_weight_2.Name = "_lbl_motor_weight_2"
      Me._lbl_motor_weight_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_motor_weight_2.Size = New System.Drawing.Size(32, 22)
      Me._lbl_motor_weight_2.TabIndex = 317
      Me._lbl_motor_weight_2.Text = "0"
      Me._lbl_motor_weight_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me._lbl_motor_weight_2.Visible = False
      '
      'lblFanCostLabel3
      '
      Me.lblFanCostLabel3.ForeColor = System.Drawing.Color.Blue
      Me.lblFanCostLabel3.Location = New System.Drawing.Point(12, 328)
      Me.lblFanCostLabel3.Name = "lblFanCostLabel3"
      Me.lblFanCostLabel3.Size = New System.Drawing.Size(64, 22)
      Me.lblFanCostLabel3.TabIndex = 343
      Me.lblFanCostLabel3.Text = "Fan cost"
      Me.lblFanCostLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.lblFanCostLabel3.Visible = False
      '
      '_lbl_fan_cost_2
      '
      Me._lbl_fan_cost_2.BackColor = System.Drawing.SystemColors.ControlLightLight
      Me._lbl_fan_cost_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_fan_cost_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_fan_cost_2.ForeColor = System.Drawing.Color.Blue
      Me.lbl_fan_cost.SetIndex(Me._lbl_fan_cost_2, CType(2, Short))
      Me._lbl_fan_cost_2.Location = New System.Drawing.Point(82, 328)
      Me._lbl_fan_cost_2.Name = "_lbl_fan_cost_2"
      Me._lbl_fan_cost_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_fan_cost_2.Size = New System.Drawing.Size(80, 22)
      Me._lbl_fan_cost_2.TabIndex = 318
      Me._lbl_fan_cost_2.Text = "0"
      Me._lbl_fan_cost_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me._lbl_fan_cost_2.Visible = False
      '
      '_lbl_iso_cost_2
      '
      Me._lbl_iso_cost_2.BackColor = System.Drawing.SystemColors.ControlLightLight
      Me._lbl_iso_cost_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_iso_cost_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_iso_cost_2.ForeColor = System.Drawing.Color.Blue
      Me.lbl_iso_cost.SetIndex(Me._lbl_iso_cost_2, CType(2, Short))
      Me._lbl_iso_cost_2.Location = New System.Drawing.Point(82, 350)
      Me._lbl_iso_cost_2.Name = "_lbl_iso_cost_2"
      Me._lbl_iso_cost_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_iso_cost_2.Size = New System.Drawing.Size(80, 22)
      Me._lbl_iso_cost_2.TabIndex = 315
      Me._lbl_iso_cost_2.Text = "0"
      Me._lbl_iso_cost_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me._lbl_iso_cost_2.Visible = False
      '
      'lblMotorCostLabel3
      '
      Me.lblMotorCostLabel3.ForeColor = System.Drawing.Color.Blue
      Me.lblMotorCostLabel3.Location = New System.Drawing.Point(8, 306)
      Me.lblMotorCostLabel3.Name = "lblMotorCostLabel3"
      Me.lblMotorCostLabel3.Size = New System.Drawing.Size(68, 22)
      Me.lblMotorCostLabel3.TabIndex = 339
      Me.lblMotorCostLabel3.Text = "Motor cost"
      Me.lblMotorCostLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.lblMotorCostLabel3.Visible = False
      '
      '_lbl_motor_cost_2
      '
      Me._lbl_motor_cost_2.BackColor = System.Drawing.Color.Transparent
      Me._lbl_motor_cost_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_motor_cost_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_motor_cost_2.ForeColor = System.Drawing.Color.Blue
      Me.lbl_motor_cost.SetIndex(Me._lbl_motor_cost_2, CType(2, Short))
      Me._lbl_motor_cost_2.Location = New System.Drawing.Point(82, 306)
      Me._lbl_motor_cost_2.Name = "_lbl_motor_cost_2"
      Me._lbl_motor_cost_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_motor_cost_2.Size = New System.Drawing.Size(80, 22)
      Me._lbl_motor_cost_2.TabIndex = 320
      Me._lbl_motor_cost_2.Text = "0"
      Me._lbl_motor_cost_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me._lbl_motor_cost_2.Visible = False
      '
      '_lbl_iso_weight_2
      '
      Me._lbl_iso_weight_2.BackColor = System.Drawing.Color.Red
      Me._lbl_iso_weight_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_iso_weight_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_iso_weight_2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_iso_weight.SetIndex(Me._lbl_iso_weight_2, CType(2, Short))
      Me._lbl_iso_weight_2.Location = New System.Drawing.Point(216, 236)
      Me._lbl_iso_weight_2.Name = "_lbl_iso_weight_2"
      Me._lbl_iso_weight_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_iso_weight_2.Size = New System.Drawing.Size(32, 22)
      Me._lbl_iso_weight_2.TabIndex = 314
      Me._lbl_iso_weight_2.Text = "0"
      Me._lbl_iso_weight_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me._lbl_iso_weight_2.Visible = False
      '
      '_lbl_fan_weight_2
      '
      Me._lbl_fan_weight_2.BackColor = System.Drawing.Color.Red
      Me._lbl_fan_weight_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_fan_weight_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_fan_weight_2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_fan_weight.SetIndex(Me._lbl_fan_weight_2, CType(2, Short))
      Me._lbl_fan_weight_2.Location = New System.Drawing.Point(196, 270)
      Me._lbl_fan_weight_2.Name = "_lbl_fan_weight_2"
      Me._lbl_fan_weight_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_fan_weight_2.Size = New System.Drawing.Size(44, 22)
      Me._lbl_fan_weight_2.TabIndex = 316
      Me._lbl_fan_weight_2.Text = "0"
      Me._lbl_fan_weight_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me._lbl_fan_weight_2.Visible = False
      '
      'panFan2Container
      '
      Me.panFan2Container.Controls.Add(Me.lblEnclosure2)
      Me.panFan2Container.Controls.Add(Me.lblEfficiency2)
      Me.panFan2Container.Controls.Add(Me.lblFan2OrderIndex)
      Me.panFan2Container.Controls.Add(Me.lblIsolatorCostLabel2)
      Me.panFan2Container.Controls.Add(Me.panFan2Fan)
      Me.panFan2Container.Controls.Add(Me.panFan2Motor)
      Me.panFan2Container.Controls.Add(Me._lbl_fan_type_1)
      Me.panFan2Container.Controls.Add(Me._lbl_motor_weight_1)
      Me.panFan2Container.Controls.Add(Me.lblMotorWeightLabel2)
      Me.panFan2Container.Controls.Add(Me.lblMotorCostLabel2)
      Me.panFan2Container.Controls.Add(Me._lbl_motor_cost_1)
      Me.panFan2Container.Controls.Add(Me._lbl_fan_cost_1)
      Me.panFan2Container.Controls.Add(Me.lblFanCostLabel2)
      Me.panFan2Container.Controls.Add(Me._lbl_fan_weight_1)
      Me.panFan2Container.Controls.Add(Me._lbl_iso_weight_1)
      Me.panFan2Container.Controls.Add(Me._lbl_iso_cost_1)
      Me.panFan2Container.Location = New System.Drawing.Point(250, 20)
      Me.panFan2Container.Name = "panFan2Container"
      Me.panFan2Container.Size = New System.Drawing.Size(222, 382)
      Me.panFan2Container.TabIndex = 347
      Me.panFan2Container.Visible = False
      '
      'lblEnclosure2
      '
      Me.lblEnclosure2.BackColor = System.Drawing.Color.Yellow
      Me.lblEnclosure2.Location = New System.Drawing.Point(130, 386)
      Me.lblEnclosure2.Name = "lblEnclosure2"
      Me.lblEnclosure2.Size = New System.Drawing.Size(100, 23)
      Me.lblEnclosure2.TabIndex = 346
      Me.lblEnclosure2.Text = "Label33"
      '
      'lblEfficiency2
      '
      Me.lblEfficiency2.BackColor = System.Drawing.Color.Yellow
      Me.lblEfficiency2.Location = New System.Drawing.Point(20, 388)
      Me.lblEfficiency2.Name = "lblEfficiency2"
      Me.lblEfficiency2.Size = New System.Drawing.Size(100, 23)
      Me.lblEfficiency2.TabIndex = 345
      Me.lblEfficiency2.Text = "Label32"
      '
      'lblFan2OrderIndex
      '
      Me.lblFan2OrderIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblFan2OrderIndex.Location = New System.Drawing.Point(186, 0)
      Me.lblFan2OrderIndex.Name = "lblFan2OrderIndex"
      Me.lblFan2OrderIndex.Size = New System.Drawing.Size(28, 23)
      Me.lblFan2OrderIndex.TabIndex = 344
      Me.lblFan2OrderIndex.Text = "-1"
      Me.lblFan2OrderIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblIsolatorCostLabel2
      '
      Me.lblIsolatorCostLabel2.ForeColor = System.Drawing.Color.Blue
      Me.lblIsolatorCostLabel2.Location = New System.Drawing.Point(4, 350)
      Me.lblIsolatorCostLabel2.Name = "lblIsolatorCostLabel2"
      Me.lblIsolatorCostLabel2.Size = New System.Drawing.Size(72, 23)
      Me.lblIsolatorCostLabel2.TabIndex = 343
      Me.lblIsolatorCostLabel2.Text = "Isolator cost"
      Me.lblIsolatorCostLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'panFan2Fan
      '
      Me.panFan2Fan.BackColor = System.Drawing.Color.WhiteSmoke
      Me.panFan2Fan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.panFan2Fan.Controls.Add(Me._lbl_fan_info_1)
      Me.panFan2Fan.Controls.Add(Me.Label8)
      Me.panFan2Fan.Controls.Add(Me.Label9)
      Me.panFan2Fan.Controls.Add(Me.Label10)
      Me.panFan2Fan.Controls.Add(Me.Label11)
      Me.panFan2Fan.Controls.Add(Me.Label12)
      Me.panFan2Fan.Controls.Add(Me._cbo_fan_type_1)
      Me.panFan2Fan.Controls.Add(Me._cbo_fan_class_1)
      Me.panFan2Fan.Controls.Add(Me._cbo_fan_size_1)
      Me.panFan2Fan.Controls.Add(Me._cbo_drive_type_1)
      Me.panFan2Fan.Controls.Add(Me._cbo_fan_iso_1)
      Me.panFan2Fan.Location = New System.Drawing.Point(0, 150)
      Me.panFan2Fan.Name = "panFan2Fan"
      Me.panFan2Fan.Size = New System.Drawing.Size(214, 156)
      Me.panFan2Fan.TabIndex = 341
      '
      '_lbl_fan_info_1
      '
      Me._lbl_fan_info_1.BackColor = System.Drawing.Color.LightGray
      Me._lbl_fan_info_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._lbl_fan_info_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_fan_info_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_fan_info_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_fan_info.SetIndex(Me._lbl_fan_info_1, CType(1, Short))
      Me._lbl_fan_info_1.Location = New System.Drawing.Point(-1, -1)
      Me._lbl_fan_info_1.Name = "_lbl_fan_info_1"
      Me._lbl_fan_info_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_fan_info_1.Size = New System.Drawing.Size(215, 23)
      Me._lbl_fan_info_1.TabIndex = 295
      Me._lbl_fan_info_1.Text = " Fan Information"
      Me._lbl_fan_info_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label8
      '
      Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label8.Location = New System.Drawing.Point(10, 124)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(64, 22)
      Me.Label8.TabIndex = 350
      Me.Label8.Text = "Isolation"
      Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label9
      '
      Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label9.Location = New System.Drawing.Point(10, 100)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(64, 22)
      Me.Label9.TabIndex = 349
      Me.Label9.Text = "Drive"
      Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label10
      '
      Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label10.Location = New System.Drawing.Point(10, 76)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(64, 22)
      Me.Label10.TabIndex = 348
      Me.Label10.Text = "Size"
      Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label11
      '
      Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label11.Location = New System.Drawing.Point(10, 52)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(64, 22)
      Me.Label11.TabIndex = 347
      Me.Label11.Text = "Class"
      Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label12
      '
      Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label12.Location = New System.Drawing.Point(10, 28)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(64, 22)
      Me.Label12.TabIndex = 346
      Me.Label12.Text = "Type"
      Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_cbo_fan_type_1
      '
      Me._cbo_fan_type_1.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_fan_type_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_fan_type_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_fan_type_1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_fan_type.SetIndex(Me._cbo_fan_type_1, CType(1, Short))
      Me._cbo_fan_type_1.Location = New System.Drawing.Point(82, 28)
      Me._cbo_fan_type_1.Name = "_cbo_fan_type_1"
      Me._cbo_fan_type_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_fan_type_1.Size = New System.Drawing.Size(89, 22)
      Me._cbo_fan_type_1.TabIndex = 289
      '
      '_cbo_fan_class_1
      '
      Me._cbo_fan_class_1.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_fan_class_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_fan_class_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_fan_class_1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_fan_class.SetIndex(Me._cbo_fan_class_1, CType(1, Short))
      Me._cbo_fan_class_1.Location = New System.Drawing.Point(82, 52)
      Me._cbo_fan_class_1.Name = "_cbo_fan_class_1"
      Me._cbo_fan_class_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_fan_class_1.Size = New System.Drawing.Size(89, 22)
      Me._cbo_fan_class_1.TabIndex = 288
      '
      '_cbo_fan_size_1
      '
      Me._cbo_fan_size_1.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_fan_size_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_fan_size_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_fan_size_1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_fan_size.SetIndex(Me._cbo_fan_size_1, CType(1, Short))
      Me._cbo_fan_size_1.Location = New System.Drawing.Point(82, 76)
      Me._cbo_fan_size_1.Name = "_cbo_fan_size_1"
      Me._cbo_fan_size_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_fan_size_1.Size = New System.Drawing.Size(89, 22)
      Me._cbo_fan_size_1.TabIndex = 287
      '
      '_cbo_drive_type_1
      '
      Me._cbo_drive_type_1.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_drive_type_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_drive_type_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_drive_type_1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_drive_type.SetIndex(Me._cbo_drive_type_1, CType(1, Short))
      Me._cbo_drive_type_1.Location = New System.Drawing.Point(82, 100)
      Me._cbo_drive_type_1.Name = "_cbo_drive_type_1"
      Me._cbo_drive_type_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_drive_type_1.Size = New System.Drawing.Size(89, 22)
      Me._cbo_drive_type_1.TabIndex = 286
      '
      '_cbo_fan_iso_1
      '
      Me._cbo_fan_iso_1.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_fan_iso_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_fan_iso_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_fan_iso_1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_fan_iso.SetIndex(Me._cbo_fan_iso_1, CType(1, Short))
      Me._cbo_fan_iso_1.Location = New System.Drawing.Point(82, 124)
      Me._cbo_fan_iso_1.Name = "_cbo_fan_iso_1"
      Me._cbo_fan_iso_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_fan_iso_1.Size = New System.Drawing.Size(89, 22)
      Me._cbo_fan_iso_1.TabIndex = 285
      '
      'panFan2Motor
      '
      Me.panFan2Motor.BackColor = System.Drawing.Color.WhiteSmoke
      Me.panFan2Motor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.panFan2Motor.Controls.Add(Me._lbl_motor_info_1)
      Me.panFan2Motor.Controls.Add(Me._cbo_rpm_1)
      Me.panFan2Motor.Controls.Add(Me._lbl_eff_1)
      Me.panFan2Motor.Controls.Add(Me._lbl_enclosure_1)
      Me.panFan2Motor.Controls.Add(Me._lbl_rpm_1)
      Me.panFan2Motor.Controls.Add(Me._lbl_hp_1)
      Me.panFan2Motor.Controls.Add(Me._ck_odp_1)
      Me.panFan2Motor.Controls.Add(Me._ck_high_1)
      Me.panFan2Motor.Controls.Add(Me._ck_premium_1)
      Me.panFan2Motor.Controls.Add(Me._cbo_hp_1)
      Me.panFan2Motor.Controls.Add(Me._ck_tefc_1)
      Me.panFan2Motor.Location = New System.Drawing.Point(0, 22)
      Me.panFan2Motor.Name = "panFan2Motor"
      Me.panFan2Motor.Size = New System.Drawing.Size(214, 130)
      Me.panFan2Motor.TabIndex = 298
      '
      '_lbl_motor_info_1
      '
      Me._lbl_motor_info_1.BackColor = System.Drawing.Color.LightGray
      Me._lbl_motor_info_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._lbl_motor_info_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_motor_info_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_motor_info_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_motor_info.SetIndex(Me._lbl_motor_info_1, CType(1, Short))
      Me._lbl_motor_info_1.Location = New System.Drawing.Point(-1, -1)
      Me._lbl_motor_info_1.Name = "_lbl_motor_info_1"
      Me._lbl_motor_info_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_motor_info_1.Size = New System.Drawing.Size(217, 23)
      Me._lbl_motor_info_1.TabIndex = 300
      Me._lbl_motor_info_1.Text = " Motor Information"
      Me._lbl_motor_info_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_cbo_rpm_1
      '
      Me._cbo_rpm_1.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_rpm_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_rpm_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_rpm_1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_rpm.SetIndex(Me._cbo_rpm_1, CType(1, Short))
      Me._cbo_rpm_1.Location = New System.Drawing.Point(82, 100)
      Me._cbo_rpm_1.Name = "_cbo_rpm_1"
      Me._cbo_rpm_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_rpm_1.Size = New System.Drawing.Size(89, 22)
      Me._cbo_rpm_1.TabIndex = 281
      '
      '_lbl_eff_1
      '
      Me._lbl_eff_1.BackColor = System.Drawing.Color.Transparent
      Me._lbl_eff_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_eff_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_eff_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_eff.SetIndex(Me._lbl_eff_1, CType(1, Short))
      Me._lbl_eff_1.Location = New System.Drawing.Point(6, 28)
      Me._lbl_eff_1.Name = "_lbl_eff_1"
      Me._lbl_eff_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_eff_1.Size = New System.Drawing.Size(68, 22)
      Me._lbl_eff_1.TabIndex = 298
      Me._lbl_eff_1.Text = "Effenciency"
      Me._lbl_eff_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_enclosure_1
      '
      Me._lbl_enclosure_1.BackColor = System.Drawing.Color.Transparent
      Me._lbl_enclosure_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_enclosure_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_enclosure_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_enclosure.SetIndex(Me._lbl_enclosure_1, CType(1, Short))
      Me._lbl_enclosure_1.Location = New System.Drawing.Point(6, 52)
      Me._lbl_enclosure_1.Name = "_lbl_enclosure_1"
      Me._lbl_enclosure_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_enclosure_1.Size = New System.Drawing.Size(68, 22)
      Me._lbl_enclosure_1.TabIndex = 299
      Me._lbl_enclosure_1.Text = "Enclosure"
      Me._lbl_enclosure_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_rpm_1
      '
      Me._lbl_rpm_1.BackColor = System.Drawing.Color.Transparent
      Me._lbl_rpm_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_rpm_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_rpm_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_rpm.SetIndex(Me._lbl_rpm_1, CType(1, Short))
      Me._lbl_rpm_1.Location = New System.Drawing.Point(6, 100)
      Me._lbl_rpm_1.Name = "_lbl_rpm_1"
      Me._lbl_rpm_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_rpm_1.Size = New System.Drawing.Size(68, 22)
      Me._lbl_rpm_1.TabIndex = 301
      Me._lbl_rpm_1.Text = "RPM"
      Me._lbl_rpm_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_hp_1
      '
      Me._lbl_hp_1.BackColor = System.Drawing.Color.Transparent
      Me._lbl_hp_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_hp_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_hp_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_hp.SetIndex(Me._lbl_hp_1, CType(1, Short))
      Me._lbl_hp_1.Location = New System.Drawing.Point(6, 76)
      Me._lbl_hp_1.Name = "_lbl_hp_1"
      Me._lbl_hp_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_hp_1.Size = New System.Drawing.Size(68, 22)
      Me._lbl_hp_1.TabIndex = 302
      Me._lbl_hp_1.Text = "Horsepower"
      Me._lbl_hp_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_ck_odp_1
      '
      Me._ck_odp_1.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_odp_1.Checked = True
      Me._ck_odp_1.CheckState = System.Windows.Forms.CheckState.Checked
      Me._ck_odp_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_odp_1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_odp_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_odp_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_odp.SetIndex(Me._ck_odp_1, CType(1, Short))
      Me._ck_odp_1.Location = New System.Drawing.Point(82, 52)
      Me._ck_odp_1.Name = "_ck_odp_1"
      Me._ck_odp_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_odp_1.Size = New System.Drawing.Size(52, 22)
      Me._ck_odp_1.TabIndex = 283
      Me._ck_odp_1.Text = "ODP"
      Me._ck_odp_1.UseVisualStyleBackColor = False
      '
      '_ck_high_1
      '
      Me._ck_high_1.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_high_1.Checked = True
      Me._ck_high_1.CheckState = System.Windows.Forms.CheckState.Checked
      Me._ck_high_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_high_1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_high_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_high_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_high.SetIndex(Me._ck_high_1, CType(1, Short))
      Me._ck_high_1.Location = New System.Drawing.Point(82, 28)
      Me._ck_high_1.Name = "_ck_high_1"
      Me._ck_high_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_high_1.Size = New System.Drawing.Size(52, 22)
      Me._ck_high_1.TabIndex = 284
      Me._ck_high_1.Text = "High"
      Me._ck_high_1.UseVisualStyleBackColor = False
      '
      '_ck_premium_1
      '
      Me._ck_premium_1.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_premium_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_premium_1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_premium_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_premium_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_premium.SetIndex(Me._ck_premium_1, CType(1, Short))
      Me._ck_premium_1.Location = New System.Drawing.Point(138, 28)
      Me._ck_premium_1.Name = "_ck_premium_1"
      Me._ck_premium_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_premium_1.Size = New System.Drawing.Size(72, 22)
      Me._ck_premium_1.TabIndex = 280
      Me._ck_premium_1.Text = "Premium"
      Me._ck_premium_1.UseVisualStyleBackColor = False
      '
      '_cbo_hp_1
      '
      Me._cbo_hp_1.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_hp_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_hp_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_hp_1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_hp.SetIndex(Me._cbo_hp_1, CType(1, Short))
      Me._cbo_hp_1.Location = New System.Drawing.Point(82, 76)
      Me._cbo_hp_1.Name = "_cbo_hp_1"
      Me._cbo_hp_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_hp_1.Size = New System.Drawing.Size(89, 22)
      Me._cbo_hp_1.TabIndex = 282
      '
      '_ck_tefc_1
      '
      Me._ck_tefc_1.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_tefc_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_tefc_1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_tefc_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_tefc_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_tefc.SetIndex(Me._ck_tefc_1, CType(1, Short))
      Me._ck_tefc_1.Location = New System.Drawing.Point(138, 52)
      Me._ck_tefc_1.Name = "_ck_tefc_1"
      Me._ck_tefc_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_tefc_1.Size = New System.Drawing.Size(72, 22)
      Me._ck_tefc_1.TabIndex = 279
      Me._ck_tefc_1.Text = "TEFC"
      Me._ck_tefc_1.UseVisualStyleBackColor = False
      '
      '_lbl_fan_type_1
      '
      Me._lbl_fan_type_1.BackColor = System.Drawing.Color.DarkGray
      Me._lbl_fan_type_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._lbl_fan_type_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_fan_type_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_fan_type_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_fan_type.SetIndex(Me._lbl_fan_type_1, CType(1, Short))
      Me._lbl_fan_type_1.Location = New System.Drawing.Point(0, 0)
      Me._lbl_fan_type_1.Name = "_lbl_fan_type_1"
      Me._lbl_fan_type_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_fan_type_1.Size = New System.Drawing.Size(214, 23)
      Me._lbl_fan_type_1.TabIndex = 297
      Me._lbl_fan_type_1.Text = " Housed Fan (HF2)"
      Me._lbl_fan_type_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_lbl_motor_weight_1
      '
      Me._lbl_motor_weight_1.BackColor = System.Drawing.Color.Red
      Me._lbl_motor_weight_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_motor_weight_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_motor_weight_1.ForeColor = System.Drawing.Color.Blue
      Me.lbl_motor_weight.SetIndex(Me._lbl_motor_weight_1, CType(1, Short))
      Me._lbl_motor_weight_1.Location = New System.Drawing.Point(204, 108)
      Me._lbl_motor_weight_1.Name = "_lbl_motor_weight_1"
      Me._lbl_motor_weight_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_motor_weight_1.Size = New System.Drawing.Size(32, 22)
      Me._lbl_motor_weight_1.TabIndex = 293
      Me._lbl_motor_weight_1.Text = "0"
      Me._lbl_motor_weight_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me._lbl_motor_weight_1.Visible = False
      '
      'lblMotorWeightLabel2
      '
      Me.lblMotorWeightLabel2.BackColor = System.Drawing.Color.Red
      Me.lblMotorWeightLabel2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblMotorWeightLabel2.ForeColor = System.Drawing.Color.Blue
      Me.lblMotorWeightLabel2.Location = New System.Drawing.Point(156, 108)
      Me.lblMotorWeightLabel2.Name = "lblMotorWeightLabel2"
      Me.lblMotorWeightLabel2.Size = New System.Drawing.Size(72, 23)
      Me.lblMotorWeightLabel2.TabIndex = 340
      Me.lblMotorWeightLabel2.Text = "Motor Weight"
      Me.lblMotorWeightLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.lblMotorWeightLabel2.Visible = False
      '
      'lblMotorCostLabel2
      '
      Me.lblMotorCostLabel2.ForeColor = System.Drawing.Color.Blue
      Me.lblMotorCostLabel2.Location = New System.Drawing.Point(8, 306)
      Me.lblMotorCostLabel2.Name = "lblMotorCostLabel2"
      Me.lblMotorCostLabel2.Size = New System.Drawing.Size(68, 22)
      Me.lblMotorCostLabel2.TabIndex = 338
      Me.lblMotorCostLabel2.Text = "Motor cost"
      Me.lblMotorCostLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.lblMotorCostLabel2.Visible = False
      '
      '_lbl_motor_cost_1
      '
      Me._lbl_motor_cost_1.BackColor = System.Drawing.Color.Transparent
      Me._lbl_motor_cost_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_motor_cost_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_motor_cost_1.ForeColor = System.Drawing.Color.Blue
      Me.lbl_motor_cost.SetIndex(Me._lbl_motor_cost_1, CType(1, Short))
      Me._lbl_motor_cost_1.Location = New System.Drawing.Point(80, 306)
      Me._lbl_motor_cost_1.Name = "_lbl_motor_cost_1"
      Me._lbl_motor_cost_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_motor_cost_1.Size = New System.Drawing.Size(80, 22)
      Me._lbl_motor_cost_1.TabIndex = 296
      Me._lbl_motor_cost_1.Text = "0"
      Me._lbl_motor_cost_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me._lbl_motor_cost_1.Visible = False
      '
      '_lbl_fan_cost_1
      '
      Me._lbl_fan_cost_1.BackColor = System.Drawing.SystemColors.ControlLightLight
      Me._lbl_fan_cost_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_fan_cost_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_fan_cost_1.ForeColor = System.Drawing.Color.Blue
      Me.lbl_fan_cost.SetIndex(Me._lbl_fan_cost_1, CType(1, Short))
      Me._lbl_fan_cost_1.Location = New System.Drawing.Point(80, 328)
      Me._lbl_fan_cost_1.Name = "_lbl_fan_cost_1"
      Me._lbl_fan_cost_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_fan_cost_1.Size = New System.Drawing.Size(80, 22)
      Me._lbl_fan_cost_1.TabIndex = 294
      Me._lbl_fan_cost_1.Text = "0"
      Me._lbl_fan_cost_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me._lbl_fan_cost_1.Visible = False
      '
      'lblFanCostLabel2
      '
      Me.lblFanCostLabel2.ForeColor = System.Drawing.Color.Blue
      Me.lblFanCostLabel2.Location = New System.Drawing.Point(4, 328)
      Me.lblFanCostLabel2.Name = "lblFanCostLabel2"
      Me.lblFanCostLabel2.Size = New System.Drawing.Size(72, 22)
      Me.lblFanCostLabel2.TabIndex = 342
      Me.lblFanCostLabel2.Text = "Fan cost"
      Me.lblFanCostLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.lblFanCostLabel2.Visible = False
      '
      '_lbl_fan_weight_1
      '
      Me._lbl_fan_weight_1.BackColor = System.Drawing.Color.Red
      Me._lbl_fan_weight_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_fan_weight_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_fan_weight_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_fan_weight.SetIndex(Me._lbl_fan_weight_1, CType(1, Short))
      Me._lbl_fan_weight_1.Location = New System.Drawing.Point(212, 296)
      Me._lbl_fan_weight_1.Name = "_lbl_fan_weight_1"
      Me._lbl_fan_weight_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_fan_weight_1.Size = New System.Drawing.Size(52, 22)
      Me._lbl_fan_weight_1.TabIndex = 292
      Me._lbl_fan_weight_1.Text = "0"
      Me._lbl_fan_weight_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me._lbl_fan_weight_1.Visible = False
      '
      '_lbl_iso_weight_1
      '
      Me._lbl_iso_weight_1.BackColor = System.Drawing.Color.Red
      Me._lbl_iso_weight_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_iso_weight_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_iso_weight_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_iso_weight.SetIndex(Me._lbl_iso_weight_1, CType(1, Short))
      Me._lbl_iso_weight_1.Location = New System.Drawing.Point(216, 276)
      Me._lbl_iso_weight_1.Name = "_lbl_iso_weight_1"
      Me._lbl_iso_weight_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_iso_weight_1.Size = New System.Drawing.Size(32, 22)
      Me._lbl_iso_weight_1.TabIndex = 290
      Me._lbl_iso_weight_1.Text = "0"
      Me._lbl_iso_weight_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me._lbl_iso_weight_1.Visible = False
      '
      '_lbl_iso_cost_1
      '
      Me._lbl_iso_cost_1.BackColor = System.Drawing.SystemColors.ControlLightLight
      Me._lbl_iso_cost_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_iso_cost_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_iso_cost_1.ForeColor = System.Drawing.Color.Blue
      Me.lbl_iso_cost.SetIndex(Me._lbl_iso_cost_1, CType(1, Short))
      Me._lbl_iso_cost_1.Location = New System.Drawing.Point(80, 350)
      Me._lbl_iso_cost_1.Name = "_lbl_iso_cost_1"
      Me._lbl_iso_cost_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_iso_cost_1.Size = New System.Drawing.Size(80, 22)
      Me._lbl_iso_cost_1.TabIndex = 291
      Me._lbl_iso_cost_1.Text = "0"
      Me._lbl_iso_cost_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me._lbl_iso_cost_1.Visible = False
      '
      'panFan1Container
      '
      Me.panFan1Container.Controls.Add(Me.lblEnclosure1)
      Me.panFan1Container.Controls.Add(Me.lblEfficiency1)
      Me.panFan1Container.Controls.Add(Me.lblIsolatorCostLabel1)
      Me.panFan1Container.Controls.Add(Me.lblMotorCostLabel1)
      Me.panFan1Container.Controls.Add(Me._lbl_motor_cost_0)
      Me.panFan1Container.Controls.Add(Me.panFan1Fan)
      Me.panFan1Container.Controls.Add(Me.lblFan1OrderIndex)
      Me.panFan1Container.Controls.Add(Me._lbl_fan_type_0)
      Me.panFan1Container.Controls.Add(Me.panFan1Motor)
      Me.panFan1Container.Controls.Add(Me.lblMotorWeightLabel1)
      Me.panFan1Container.Controls.Add(Me._lbl_motor_weight_0)
      Me.panFan1Container.Controls.Add(Me.lblFanWeightLabel1)
      Me.panFan1Container.Controls.Add(Me._lbl_fan_weight_0)
      Me.panFan1Container.Controls.Add(Me._lbl_iso_weight_0)
      Me.panFan1Container.Controls.Add(Me._lbl_fan_cost_0)
      Me.panFan1Container.Controls.Add(Me.lblFanCostLabel1)
      Me.panFan1Container.Controls.Add(Me._lbl_iso_cost_0)
      Me.panFan1Container.Location = New System.Drawing.Point(20, 20)
      Me.panFan1Container.Name = "panFan1Container"
      Me.panFan1Container.Size = New System.Drawing.Size(222, 378)
      Me.panFan1Container.TabIndex = 346
      Me.panFan1Container.Visible = False
      '
      'lblEnclosure1
      '
      Me.lblEnclosure1.BackColor = System.Drawing.Color.Yellow
      Me.lblEnclosure1.Location = New System.Drawing.Point(110, 386)
      Me.lblEnclosure1.Name = "lblEnclosure1"
      Me.lblEnclosure1.Size = New System.Drawing.Size(100, 23)
      Me.lblEnclosure1.TabIndex = 340
      Me.lblEnclosure1.Text = "Label33"
      '
      'lblEfficiency1
      '
      Me.lblEfficiency1.BackColor = System.Drawing.Color.Yellow
      Me.lblEfficiency1.Location = New System.Drawing.Point(6, 386)
      Me.lblEfficiency1.Name = "lblEfficiency1"
      Me.lblEfficiency1.Size = New System.Drawing.Size(100, 23)
      Me.lblEfficiency1.TabIndex = 339
      Me.lblEfficiency1.Text = "Label32"
      '
      'lblIsolatorCostLabel1
      '
      Me.lblIsolatorCostLabel1.ForeColor = System.Drawing.Color.Blue
      Me.lblIsolatorCostLabel1.Location = New System.Drawing.Point(2, 350)
      Me.lblIsolatorCostLabel1.Name = "lblIsolatorCostLabel1"
      Me.lblIsolatorCostLabel1.Size = New System.Drawing.Size(74, 22)
      Me.lblIsolatorCostLabel1.TabIndex = 338
      Me.lblIsolatorCostLabel1.Text = "Isolator cost"
      Me.lblIsolatorCostLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblMotorCostLabel1
      '
      Me.lblMotorCostLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblMotorCostLabel1.ForeColor = System.Drawing.Color.Blue
      Me.lblMotorCostLabel1.Location = New System.Drawing.Point(8, 306)
      Me.lblMotorCostLabel1.Name = "lblMotorCostLabel1"
      Me.lblMotorCostLabel1.Size = New System.Drawing.Size(68, 22)
      Me.lblMotorCostLabel1.TabIndex = 337
      Me.lblMotorCostLabel1.Text = "Motor cost"
      Me.lblMotorCostLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.lblMotorCostLabel1.Visible = False
      '
      '_lbl_motor_cost_0
      '
      Me._lbl_motor_cost_0.BackColor = System.Drawing.Color.Transparent
      Me._lbl_motor_cost_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_motor_cost_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_motor_cost_0.ForeColor = System.Drawing.Color.Blue
      Me.lbl_motor_cost.SetIndex(Me._lbl_motor_cost_0, CType(0, Short))
      Me._lbl_motor_cost_0.Location = New System.Drawing.Point(88, 306)
      Me._lbl_motor_cost_0.Name = "_lbl_motor_cost_0"
      Me._lbl_motor_cost_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_motor_cost_0.Size = New System.Drawing.Size(88, 22)
      Me._lbl_motor_cost_0.TabIndex = 336
      Me._lbl_motor_cost_0.Text = "0"
      Me._lbl_motor_cost_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me._lbl_motor_cost_0.Visible = False
      '
      'panFan1Fan
      '
      Me.panFan1Fan.BackColor = System.Drawing.Color.WhiteSmoke
      Me.panFan1Fan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.panFan1Fan.Controls.Add(Me._lbl_fan_info_0)
      Me.panFan1Fan.Controls.Add(Me.lblFanType0)
      Me.panFan1Fan.Controls.Add(Me.lblFanSize0)
      Me.panFan1Fan.Controls.Add(Me.lblFanIsolator0)
      Me.panFan1Fan.Controls.Add(Me.lblFanDrive0)
      Me.panFan1Fan.Controls.Add(Me._cbo_fan_type_0)
      Me.panFan1Fan.Controls.Add(Me._cbo_fan_class_0)
      Me.panFan1Fan.Controls.Add(Me._cbo_fan_size_0)
      Me.panFan1Fan.Controls.Add(Me._cbo_drive_type_0)
      Me.panFan1Fan.Controls.Add(Me._cbo_fan_iso_0)
      Me.panFan1Fan.Controls.Add(Me.lblFanClass0)
      Me.panFan1Fan.Location = New System.Drawing.Point(0, 150)
      Me.panFan1Fan.Name = "panFan1Fan"
      Me.panFan1Fan.Size = New System.Drawing.Size(214, 156)
      Me.panFan1Fan.TabIndex = 334
      '
      '_lbl_fan_info_0
      '
      Me._lbl_fan_info_0.BackColor = System.Drawing.Color.LightGray
      Me._lbl_fan_info_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._lbl_fan_info_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_fan_info_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_fan_info_0.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_fan_info.SetIndex(Me._lbl_fan_info_0, CType(0, Short))
      Me._lbl_fan_info_0.Location = New System.Drawing.Point(-1, -2)
      Me._lbl_fan_info_0.Name = "_lbl_fan_info_0"
      Me._lbl_fan_info_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_fan_info_0.Size = New System.Drawing.Size(236, 23)
      Me._lbl_fan_info_0.TabIndex = 164
      Me._lbl_fan_info_0.Text = " Fan Information"
      Me._lbl_fan_info_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblFanType0
      '
      Me.lblFanType0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblFanType0.Location = New System.Drawing.Point(12, 28)
      Me.lblFanType0.Name = "lblFanType0"
      Me.lblFanType0.Size = New System.Drawing.Size(64, 22)
      Me.lblFanType0.TabIndex = 327
      Me.lblFanType0.Text = "Type"
      Me.lblFanType0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblFanSize0
      '
      Me.lblFanSize0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblFanSize0.Location = New System.Drawing.Point(12, 76)
      Me.lblFanSize0.Name = "lblFanSize0"
      Me.lblFanSize0.Size = New System.Drawing.Size(64, 22)
      Me.lblFanSize0.TabIndex = 329
      Me.lblFanSize0.Text = "Size"
      Me.lblFanSize0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblFanIsolator0
      '
      Me.lblFanIsolator0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblFanIsolator0.Location = New System.Drawing.Point(12, 124)
      Me.lblFanIsolator0.Name = "lblFanIsolator0"
      Me.lblFanIsolator0.Size = New System.Drawing.Size(64, 22)
      Me.lblFanIsolator0.TabIndex = 331
      Me.lblFanIsolator0.Text = "Isolation"
      Me.lblFanIsolator0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblFanDrive0
      '
      Me.lblFanDrive0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblFanDrive0.Location = New System.Drawing.Point(12, 100)
      Me.lblFanDrive0.Name = "lblFanDrive0"
      Me.lblFanDrive0.Size = New System.Drawing.Size(64, 22)
      Me.lblFanDrive0.TabIndex = 330
      Me.lblFanDrive0.Text = "Drive"
      Me.lblFanDrive0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_cbo_fan_type_0
      '
      Me._cbo_fan_type_0.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_fan_type_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_fan_type_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_fan_type_0.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_fan_type.SetIndex(Me._cbo_fan_type_0, CType(0, Short))
      Me._cbo_fan_type_0.Location = New System.Drawing.Point(86, 28)
      Me._cbo_fan_type_0.Name = "_cbo_fan_type_0"
      Me._cbo_fan_type_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_fan_type_0.Size = New System.Drawing.Size(96, 22)
      Me._cbo_fan_type_0.TabIndex = 10
      '
      '_cbo_fan_class_0
      '
      Me._cbo_fan_class_0.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_fan_class_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_fan_class_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_fan_class_0.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_fan_class.SetIndex(Me._cbo_fan_class_0, CType(0, Short))
      Me._cbo_fan_class_0.Location = New System.Drawing.Point(86, 52)
      Me._cbo_fan_class_0.Name = "_cbo_fan_class_0"
      Me._cbo_fan_class_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_fan_class_0.Size = New System.Drawing.Size(96, 22)
      Me._cbo_fan_class_0.TabIndex = 11
      '
      '_cbo_fan_size_0
      '
      Me._cbo_fan_size_0.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_fan_size_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_fan_size_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_fan_size_0.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_fan_size.SetIndex(Me._cbo_fan_size_0, CType(0, Short))
      Me._cbo_fan_size_0.Location = New System.Drawing.Point(86, 76)
      Me._cbo_fan_size_0.Name = "_cbo_fan_size_0"
      Me._cbo_fan_size_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_fan_size_0.Size = New System.Drawing.Size(96, 22)
      Me._cbo_fan_size_0.TabIndex = 12
      '
      '_cbo_drive_type_0
      '
      Me._cbo_drive_type_0.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_drive_type_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_drive_type_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_drive_type_0.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_drive_type.SetIndex(Me._cbo_drive_type_0, CType(0, Short))
      Me._cbo_drive_type_0.Location = New System.Drawing.Point(86, 100)
      Me._cbo_drive_type_0.Name = "_cbo_drive_type_0"
      Me._cbo_drive_type_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_drive_type_0.Size = New System.Drawing.Size(96, 22)
      Me._cbo_drive_type_0.TabIndex = 13
      '
      '_cbo_fan_iso_0
      '
      Me._cbo_fan_iso_0.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_fan_iso_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_fan_iso_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_fan_iso_0.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_fan_iso.SetIndex(Me._cbo_fan_iso_0, CType(0, Short))
      Me._cbo_fan_iso_0.Location = New System.Drawing.Point(86, 124)
      Me._cbo_fan_iso_0.Name = "_cbo_fan_iso_0"
      Me._cbo_fan_iso_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_fan_iso_0.Size = New System.Drawing.Size(96, 22)
      Me._cbo_fan_iso_0.TabIndex = 14
      '
      'lblFanClass0
      '
      Me.lblFanClass0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblFanClass0.Location = New System.Drawing.Point(12, 52)
      Me.lblFanClass0.Name = "lblFanClass0"
      Me.lblFanClass0.Size = New System.Drawing.Size(64, 22)
      Me.lblFanClass0.TabIndex = 328
      Me.lblFanClass0.Text = "Class"
      Me.lblFanClass0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblFan1OrderIndex
      '
      Me.lblFan1OrderIndex.BackColor = System.Drawing.SystemColors.ControlLightLight
      Me.lblFan1OrderIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblFan1OrderIndex.Location = New System.Drawing.Point(186, 0)
      Me.lblFan1OrderIndex.Name = "lblFan1OrderIndex"
      Me.lblFan1OrderIndex.Size = New System.Drawing.Size(28, 23)
      Me.lblFan1OrderIndex.TabIndex = 70
      Me.lblFan1OrderIndex.Text = "-1"
      Me.lblFan1OrderIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      '_lbl_fan_type_0
      '
      Me._lbl_fan_type_0.BackColor = System.Drawing.Color.DarkGray
      Me._lbl_fan_type_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._lbl_fan_type_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_fan_type_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_fan_type_0.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_fan_type.SetIndex(Me._lbl_fan_type_0, CType(0, Short))
      Me._lbl_fan_type_0.Location = New System.Drawing.Point(0, 0)
      Me._lbl_fan_type_0.Name = "_lbl_fan_type_0"
      Me._lbl_fan_type_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_fan_type_0.Size = New System.Drawing.Size(214, 23)
      Me._lbl_fan_type_0.TabIndex = 69
      Me._lbl_fan_type_0.Text = " Housed Fan (HF1)"
      Me._lbl_fan_type_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'panFan1Motor
      '
      Me.panFan1Motor.BackColor = System.Drawing.Color.WhiteSmoke
      Me.panFan1Motor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.panFan1Motor.Controls.Add(Me._cbo_rpm_0)
      Me.panFan1Motor.Controls.Add(Me._ck_premium_0)
      Me.panFan1Motor.Controls.Add(Me._ck_tefc_0)
      Me.panFan1Motor.Controls.Add(Me._lbl_enclosure_0)
      Me.panFan1Motor.Controls.Add(Me._lbl_rpm_0)
      Me.panFan1Motor.Controls.Add(Me._lbl_eff_0)
      Me.panFan1Motor.Controls.Add(Me._ck_odp_0)
      Me.panFan1Motor.Controls.Add(Me._lbl_hp_0)
      Me.panFan1Motor.Controls.Add(Me._ck_high_0)
      Me.panFan1Motor.Controls.Add(Me._cbo_hp_0)
      Me.panFan1Motor.Controls.Add(Me._lbl_motor_info_0)
      Me.panFan1Motor.Location = New System.Drawing.Point(0, 22)
      Me.panFan1Motor.Name = "panFan1Motor"
      Me.panFan1Motor.Size = New System.Drawing.Size(214, 130)
      Me.panFan1Motor.TabIndex = 71
      '
      '_cbo_rpm_0
      '
      Me._cbo_rpm_0.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_rpm_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_rpm_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_rpm_0.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_rpm.SetIndex(Me._cbo_rpm_0, CType(0, Short))
      Me._cbo_rpm_0.Location = New System.Drawing.Point(84, 98)
      Me._cbo_rpm_0.Name = "_cbo_rpm_0"
      Me._cbo_rpm_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_rpm_0.Size = New System.Drawing.Size(96, 22)
      Me._cbo_rpm_0.TabIndex = 9
      '
      '_ck_premium_0
      '
      Me._ck_premium_0.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_premium_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_premium_0.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_premium_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_premium_0.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_premium.SetIndex(Me._ck_premium_0, CType(0, Short))
      Me._ck_premium_0.Location = New System.Drawing.Point(140, 26)
      Me._ck_premium_0.Name = "_ck_premium_0"
      Me._ck_premium_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_premium_0.Size = New System.Drawing.Size(68, 22)
      Me._ck_premium_0.TabIndex = 5
      Me._ck_premium_0.Text = "Premium"
      Me._ck_premium_0.UseVisualStyleBackColor = False
      '
      '_ck_tefc_0
      '
      Me._ck_tefc_0.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_tefc_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_tefc_0.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_tefc_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_tefc_0.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_tefc.SetIndex(Me._ck_tefc_0, CType(0, Short))
      Me._ck_tefc_0.Location = New System.Drawing.Point(140, 50)
      Me._ck_tefc_0.Name = "_ck_tefc_0"
      Me._ck_tefc_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_tefc_0.Size = New System.Drawing.Size(68, 22)
      Me._ck_tefc_0.TabIndex = 7
      Me._ck_tefc_0.Text = "TEFC"
      Me._ck_tefc_0.UseVisualStyleBackColor = False
      '
      '_lbl_enclosure_0
      '
      Me._lbl_enclosure_0.BackColor = System.Drawing.Color.Transparent
      Me._lbl_enclosure_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_enclosure_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_enclosure_0.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_enclosure.SetIndex(Me._lbl_enclosure_0, CType(0, Short))
      Me._lbl_enclosure_0.Location = New System.Drawing.Point(6, 50)
      Me._lbl_enclosure_0.Name = "_lbl_enclosure_0"
      Me._lbl_enclosure_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_enclosure_0.Size = New System.Drawing.Size(68, 22)
      Me._lbl_enclosure_0.TabIndex = 66
      Me._lbl_enclosure_0.Text = "Enclosure"
      Me._lbl_enclosure_0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_rpm_0
      '
      Me._lbl_rpm_0.BackColor = System.Drawing.Color.Transparent
      Me._lbl_rpm_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_rpm_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_rpm_0.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_rpm.SetIndex(Me._lbl_rpm_0, CType(0, Short))
      Me._lbl_rpm_0.Location = New System.Drawing.Point(6, 98)
      Me._lbl_rpm_0.Name = "_lbl_rpm_0"
      Me._lbl_rpm_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_rpm_0.Size = New System.Drawing.Size(68, 22)
      Me._lbl_rpm_0.TabIndex = 64
      Me._lbl_rpm_0.Text = "RPM"
      Me._lbl_rpm_0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_eff_0
      '
      Me._lbl_eff_0.BackColor = System.Drawing.Color.Transparent
      Me._lbl_eff_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_eff_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_eff_0.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_eff.SetIndex(Me._lbl_eff_0, CType(0, Short))
      Me._lbl_eff_0.Location = New System.Drawing.Point(6, 26)
      Me._lbl_eff_0.Name = "_lbl_eff_0"
      Me._lbl_eff_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_eff_0.Size = New System.Drawing.Size(68, 22)
      Me._lbl_eff_0.TabIndex = 68
      Me._lbl_eff_0.Text = "Effenciency"
      Me._lbl_eff_0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_ck_odp_0
      '
      Me._ck_odp_0.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_odp_0.Checked = True
      Me._ck_odp_0.CheckState = System.Windows.Forms.CheckState.Checked
      Me._ck_odp_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_odp_0.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_odp_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_odp_0.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_odp.SetIndex(Me._ck_odp_0, CType(0, Short))
      Me._ck_odp_0.Location = New System.Drawing.Point(84, 50)
      Me._ck_odp_0.Name = "_ck_odp_0"
      Me._ck_odp_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_odp_0.Size = New System.Drawing.Size(52, 22)
      Me._ck_odp_0.TabIndex = 6
      Me._ck_odp_0.Text = "ODP"
      Me._ck_odp_0.UseVisualStyleBackColor = False
      '
      '_lbl_hp_0
      '
      Me._lbl_hp_0.BackColor = System.Drawing.Color.Transparent
      Me._lbl_hp_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_hp_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_hp_0.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_hp.SetIndex(Me._lbl_hp_0, CType(0, Short))
      Me._lbl_hp_0.Location = New System.Drawing.Point(6, 74)
      Me._lbl_hp_0.Name = "_lbl_hp_0"
      Me._lbl_hp_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_hp_0.Size = New System.Drawing.Size(68, 22)
      Me._lbl_hp_0.TabIndex = 63
      Me._lbl_hp_0.Text = "Horsepower"
      Me._lbl_hp_0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_ck_high_0
      '
      Me._ck_high_0.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_high_0.Checked = True
      Me._ck_high_0.CheckState = System.Windows.Forms.CheckState.Checked
      Me._ck_high_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_high_0.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_high_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_high_0.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_high.SetIndex(Me._ck_high_0, CType(0, Short))
      Me._ck_high_0.Location = New System.Drawing.Point(84, 26)
      Me._ck_high_0.Name = "_ck_high_0"
      Me._ck_high_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_high_0.Size = New System.Drawing.Size(52, 22)
      Me._ck_high_0.TabIndex = 4
      Me._ck_high_0.Text = "High"
      Me._ck_high_0.UseVisualStyleBackColor = False
      '
      '_cbo_hp_0
      '
      Me._cbo_hp_0.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_hp_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_hp_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_hp_0.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_hp.SetIndex(Me._cbo_hp_0, CType(0, Short))
      Me._cbo_hp_0.Location = New System.Drawing.Point(84, 74)
      Me._cbo_hp_0.Name = "_cbo_hp_0"
      Me._cbo_hp_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_hp_0.Size = New System.Drawing.Size(96, 22)
      Me._cbo_hp_0.TabIndex = 8
      '
      '_lbl_motor_info_0
      '
      Me._lbl_motor_info_0.BackColor = System.Drawing.Color.LightGray
      Me._lbl_motor_info_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._lbl_motor_info_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_motor_info_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_motor_info_0.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_motor_info.SetIndex(Me._lbl_motor_info_0, CType(0, Short))
      Me._lbl_motor_info_0.Location = New System.Drawing.Point(-1, -1)
      Me._lbl_motor_info_0.Name = "_lbl_motor_info_0"
      Me._lbl_motor_info_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_motor_info_0.Size = New System.Drawing.Size(238, 23)
      Me._lbl_motor_info_0.TabIndex = 65
      Me._lbl_motor_info_0.Text = " Motor Information"
      Me._lbl_motor_info_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblMotorWeightLabel1
      '
      Me.lblMotorWeightLabel1.BackColor = System.Drawing.Color.Red
      Me.lblMotorWeightLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblMotorWeightLabel1.ForeColor = System.Drawing.Color.Blue
      Me.lblMotorWeightLabel1.Location = New System.Drawing.Point(168, 68)
      Me.lblMotorWeightLabel1.Name = "lblMotorWeightLabel1"
      Me.lblMotorWeightLabel1.Size = New System.Drawing.Size(72, 23)
      Me.lblMotorWeightLabel1.TabIndex = 333
      Me.lblMotorWeightLabel1.Text = "Motor Weight"
      Me.lblMotorWeightLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.lblMotorWeightLabel1.Visible = False
      '
      '_lbl_motor_weight_0
      '
      Me._lbl_motor_weight_0.BackColor = System.Drawing.Color.Red
      Me._lbl_motor_weight_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_motor_weight_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_motor_weight_0.ForeColor = System.Drawing.Color.Blue
      Me.lbl_motor_weight.SetIndex(Me._lbl_motor_weight_0, CType(0, Short))
      Me._lbl_motor_weight_0.Location = New System.Drawing.Point(200, 36)
      Me._lbl_motor_weight_0.Name = "_lbl_motor_weight_0"
      Me._lbl_motor_weight_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_motor_weight_0.Size = New System.Drawing.Size(32, 22)
      Me._lbl_motor_weight_0.TabIndex = 167
      Me._lbl_motor_weight_0.Text = "0"
      Me._lbl_motor_weight_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me._lbl_motor_weight_0.Visible = False
      '
      'lblFanWeightLabel1
      '
      Me.lblFanWeightLabel1.BackColor = System.Drawing.Color.Red
      Me.lblFanWeightLabel1.ForeColor = System.Drawing.Color.Blue
      Me.lblFanWeightLabel1.Location = New System.Drawing.Point(152, 204)
      Me.lblFanWeightLabel1.Name = "lblFanWeightLabel1"
      Me.lblFanWeightLabel1.Size = New System.Drawing.Size(72, 23)
      Me.lblFanWeightLabel1.TabIndex = 335
      Me.lblFanWeightLabel1.Text = "Fan Weight"
      Me.lblFanWeightLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.lblFanWeightLabel1.Visible = False
      '
      '_lbl_fan_weight_0
      '
      Me._lbl_fan_weight_0.BackColor = System.Drawing.Color.Red
      Me._lbl_fan_weight_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_fan_weight_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_fan_weight_0.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_fan_weight.SetIndex(Me._lbl_fan_weight_0, CType(0, Short))
      Me._lbl_fan_weight_0.Location = New System.Drawing.Point(178, 246)
      Me._lbl_fan_weight_0.Name = "_lbl_fan_weight_0"
      Me._lbl_fan_weight_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_fan_weight_0.Size = New System.Drawing.Size(52, 22)
      Me._lbl_fan_weight_0.TabIndex = 168
      Me._lbl_fan_weight_0.Text = "0"
      Me._lbl_fan_weight_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me._lbl_fan_weight_0.Visible = False
      '
      '_lbl_iso_weight_0
      '
      Me._lbl_iso_weight_0.BackColor = System.Drawing.Color.Red
      Me._lbl_iso_weight_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_iso_weight_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_iso_weight_0.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_iso_weight.SetIndex(Me._lbl_iso_weight_0, CType(0, Short))
      Me._lbl_iso_weight_0.Location = New System.Drawing.Point(202, 256)
      Me._lbl_iso_weight_0.Name = "_lbl_iso_weight_0"
      Me._lbl_iso_weight_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_iso_weight_0.Size = New System.Drawing.Size(32, 22)
      Me._lbl_iso_weight_0.TabIndex = 171
      Me._lbl_iso_weight_0.Text = "0"
      Me._lbl_iso_weight_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me._lbl_iso_weight_0.Visible = False
      '
      '_lbl_fan_cost_0
      '
      Me._lbl_fan_cost_0.BackColor = System.Drawing.SystemColors.ControlLightLight
      Me._lbl_fan_cost_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_fan_cost_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_fan_cost_0.ForeColor = System.Drawing.Color.Blue
      Me.lbl_fan_cost.SetIndex(Me._lbl_fan_cost_0, CType(0, Short))
      Me._lbl_fan_cost_0.Location = New System.Drawing.Point(88, 328)
      Me._lbl_fan_cost_0.Name = "_lbl_fan_cost_0"
      Me._lbl_fan_cost_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_fan_cost_0.Size = New System.Drawing.Size(88, 22)
      Me._lbl_fan_cost_0.TabIndex = 165
      Me._lbl_fan_cost_0.Text = "0"
      Me._lbl_fan_cost_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me._lbl_fan_cost_0.Visible = False
      '
      'lblFanCostLabel1
      '
      Me.lblFanCostLabel1.ForeColor = System.Drawing.Color.Blue
      Me.lblFanCostLabel1.Location = New System.Drawing.Point(6, 328)
      Me.lblFanCostLabel1.Name = "lblFanCostLabel1"
      Me.lblFanCostLabel1.Size = New System.Drawing.Size(70, 22)
      Me.lblFanCostLabel1.TabIndex = 334
      Me.lblFanCostLabel1.Text = "Fan cost"
      Me.lblFanCostLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.lblFanCostLabel1.Visible = False
      '
      '_lbl_iso_cost_0
      '
      Me._lbl_iso_cost_0.BackColor = System.Drawing.SystemColors.ControlLightLight
      Me._lbl_iso_cost_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_iso_cost_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_iso_cost_0.ForeColor = System.Drawing.Color.Blue
      Me.lbl_iso_cost.SetIndex(Me._lbl_iso_cost_0, CType(0, Short))
      Me._lbl_iso_cost_0.Location = New System.Drawing.Point(88, 350)
      Me._lbl_iso_cost_0.Name = "_lbl_iso_cost_0"
      Me._lbl_iso_cost_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_iso_cost_0.Size = New System.Drawing.Size(88, 22)
      Me._lbl_iso_cost_0.TabIndex = 170
      Me._lbl_iso_cost_0.Tag = "use pop-up text instead"
      Me._lbl_iso_cost_0.Text = "0"
      Me._lbl_iso_cost_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me._lbl_iso_cost_0.Visible = False
      '
      '_SSTab2_TabPage4
      '
      Me._SSTab2_TabPage4.BackColor = System.Drawing.SystemColors.ControlLightLight
      Me._SSTab2_TabPage4.Controls.Add(Me.panGasHeaterContainer)
      Me._SSTab2_TabPage4.Controls.Add(Me.panCoil4Container)
      Me._SSTab2_TabPage4.Controls.Add(Me.panCoil3Container)
      Me._SSTab2_TabPage4.Controls.Add(Me.panCoil5Container)
      Me._SSTab2_TabPage4.Controls.Add(Me.panCoil2Container)
      Me._SSTab2_TabPage4.Controls.Add(Me.panCoil1Container)
      Me._SSTab2_TabPage4.Controls.Add(Me.panC3Container)
      Me._SSTab2_TabPage4.Location = New System.Drawing.Point(4, 22)
      Me._SSTab2_TabPage4.Name = "_SSTab2_TabPage4"
      Me._SSTab2_TabPage4.Size = New System.Drawing.Size(716, 420)
      Me._SSTab2_TabPage4.TabIndex = 4
      Me._SSTab2_TabPage4.Text = "Coil"
      '
      'panGasHeaterContainer
      '
      Me.panGasHeaterContainer.Controls.Add(Me.panGasHeater)
      Me.panGasHeaterContainer.Controls.Add(Me.lblGasHeaterOrderIndex)
      Me.panGasHeaterContainer.Controls.Add(Me.lblGasHeaterCost)
      Me.panGasHeaterContainer.Controls.Add(Me.Label34)
      Me.panGasHeaterContainer.Location = New System.Drawing.Point(478, 220)
      Me.panGasHeaterContainer.Name = "panGasHeaterContainer"
      Me.panGasHeaterContainer.Size = New System.Drawing.Size(230, 130)
      Me.panGasHeaterContainer.TabIndex = 345
      Me.panGasHeaterContainer.Visible = False
      '
      'panGasHeater
      '
      Me.panGasHeater.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.panGasHeater.Controls.Add(Me.lblC5TypeValue)
      Me.panGasHeater.Controls.Add(Me.radC5TypeModulating)
      Me.panGasHeater.Controls.Add(Me.radC5TypeTwoStage)
      Me.panGasHeater.Controls.Add(Me.cboC5Power)
      Me.panGasHeater.Controls.Add(Me.lblC5Type)
      Me.panGasHeater.Controls.Add(Me.lblC5Power)
      Me.panGasHeater.Location = New System.Drawing.Point(0, 22)
      Me.panGasHeater.Name = "panGasHeater"
      Me.panGasHeater.Size = New System.Drawing.Size(220, 96)
      Me.panGasHeater.TabIndex = 337
      '
      'lblC5TypeValue
      '
      Me.lblC5TypeValue.BackColor = System.Drawing.Color.Yellow
      Me.lblC5TypeValue.Location = New System.Drawing.Point(11, 102)
      Me.lblC5TypeValue.Name = "lblC5TypeValue"
      Me.lblC5TypeValue.Size = New System.Drawing.Size(45, 13)
      Me.lblC5TypeValue.TabIndex = 5
      '
      'radC5TypeModulating
      '
      Me.radC5TypeModulating.AutoSize = True
      Me.radC5TypeModulating.Location = New System.Drawing.Point(66, 66)
      Me.radC5TypeModulating.Name = "radC5TypeModulating"
      Me.radC5TypeModulating.Size = New System.Drawing.Size(77, 17)
      Me.radC5TypeModulating.TabIndex = 4
      Me.radC5TypeModulating.Text = "Modulating"
      Me.radC5TypeModulating.UseVisualStyleBackColor = True
      '
      'radC5TypeTwoStage
      '
      Me.radC5TypeTwoStage.AutoSize = True
      Me.radC5TypeTwoStage.Checked = True
      Me.radC5TypeTwoStage.Location = New System.Drawing.Point(66, 40)
      Me.radC5TypeTwoStage.Name = "radC5TypeTwoStage"
      Me.radC5TypeTwoStage.Size = New System.Drawing.Size(75, 17)
      Me.radC5TypeTwoStage.TabIndex = 3
      Me.radC5TypeTwoStage.TabStop = True
      Me.radC5TypeTwoStage.Text = "Two stage"
      Me.radC5TypeTwoStage.UseVisualStyleBackColor = True
      '
      'cboC5Power
      '
      Me.cboC5Power.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboC5Power.FormattingEnabled = True
      Me.cboC5Power.Location = New System.Drawing.Point(66, 6)
      Me.cboC5Power.Name = "cboC5Power"
      Me.cboC5Power.Size = New System.Drawing.Size(121, 21)
      Me.cboC5Power.TabIndex = 2
      '
      'lblC5Type
      '
      Me.lblC5Type.Location = New System.Drawing.Point(8, 38)
      Me.lblC5Type.Name = "lblC5Type"
      Me.lblC5Type.Size = New System.Drawing.Size(45, 21)
      Me.lblC5Type.TabIndex = 1
      Me.lblC5Type.Text = "Type"
      Me.lblC5Type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblC5Power
      '
      Me.lblC5Power.Location = New System.Drawing.Point(8, 6)
      Me.lblC5Power.Name = "lblC5Power"
      Me.lblC5Power.Size = New System.Drawing.Size(45, 21)
      Me.lblC5Power.TabIndex = 0
      Me.lblC5Power.Text = "Power"
      Me.lblC5Power.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblGasHeaterOrderIndex
      '
      Me.lblGasHeaterOrderIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblGasHeaterOrderIndex.Location = New System.Drawing.Point(192, 0)
      Me.lblGasHeaterOrderIndex.Name = "lblGasHeaterOrderIndex"
      Me.lblGasHeaterOrderIndex.Size = New System.Drawing.Size(28, 23)
      Me.lblGasHeaterOrderIndex.TabIndex = 336
      Me.lblGasHeaterOrderIndex.Text = "-1"
      Me.lblGasHeaterOrderIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblGasHeaterCost
      '
      Me.lblGasHeaterCost.BackColor = System.Drawing.Color.DarkGray
      Me.lblGasHeaterCost.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblGasHeaterCost.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblGasHeaterCost.ForeColor = System.Drawing.Color.Blue
      Me.lblGasHeaterCost.Location = New System.Drawing.Point(92, 2)
      Me.lblGasHeaterCost.Name = "lblGasHeaterCost"
      Me.lblGasHeaterCost.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblGasHeaterCost.Size = New System.Drawing.Size(96, 18)
      Me.lblGasHeaterCost.TabIndex = 246
      Me.lblGasHeaterCost.Text = "0"
      Me.lblGasHeaterCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.lblGasHeaterCost.Visible = False
      '
      'Label34
      '
      Me.Label34.BackColor = System.Drawing.Color.DarkGray
      Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Label34.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label34.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label34.ForeColor = System.Drawing.SystemColors.ControlText
      Me.Label34.Location = New System.Drawing.Point(0, 0)
      Me.Label34.Name = "Label34"
      Me.Label34.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label34.Size = New System.Drawing.Size(220, 23)
      Me.Label34.TabIndex = 245
      Me.Label34.Text = "C5"
      Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'panCoil4Container
      '
      Me.panCoil4Container.Controls.Add(Me.lblCoil4OrderIndex)
      Me.panCoil4Container.Controls.Add(Me._lbl_coil_cost_3)
      Me.panCoil4Container.Controls.Add(Me.panCoil4)
      Me.panCoil4Container.Controls.Add(Me._lbl_coil_type_3)
      Me.panCoil4Container.Location = New System.Drawing.Point(250, 218)
      Me.panCoil4Container.Name = "panCoil4Container"
      Me.panCoil4Container.Size = New System.Drawing.Size(226, 202)
      Me.panCoil4Container.TabIndex = 343
      Me.panCoil4Container.Visible = False
      '
      'lblCoil4OrderIndex
      '
      Me.lblCoil4OrderIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblCoil4OrderIndex.Location = New System.Drawing.Point(192, 0)
      Me.lblCoil4OrderIndex.Name = "lblCoil4OrderIndex"
      Me.lblCoil4OrderIndex.Size = New System.Drawing.Size(28, 23)
      Me.lblCoil4OrderIndex.TabIndex = 342
      Me.lblCoil4OrderIndex.Text = "-1"
      Me.lblCoil4OrderIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      '_lbl_coil_cost_3
      '
      Me._lbl_coil_cost_3.BackColor = System.Drawing.Color.DarkGray
      Me._lbl_coil_cost_3.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_coil_cost_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_coil_cost_3.ForeColor = System.Drawing.Color.Blue
      Me.lbl_coil_cost.SetIndex(Me._lbl_coil_cost_3, CType(3, Short))
      Me._lbl_coil_cost_3.Location = New System.Drawing.Point(98, 2)
      Me._lbl_coil_cost_3.Name = "_lbl_coil_cost_3"
      Me._lbl_coil_cost_3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_coil_cost_3.Size = New System.Drawing.Size(90, 18)
      Me._lbl_coil_cost_3.TabIndex = 213
      Me._lbl_coil_cost_3.Text = "0"
      Me._lbl_coil_cost_3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me._lbl_coil_cost_3.Visible = False
      '
      'panCoil4
      '
      Me.panCoil4.BackColor = System.Drawing.Color.WhiteSmoke
      Me.panCoil4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.panCoil4.Controls.Add(Me._ck_cu_3)
      Me.panCoil4.Controls.Add(Me.lblCoilCasing4)
      Me.panCoil4.Controls.Add(Me.lblFinMaterial4)
      Me.panCoil4.Controls.Add(Me.Label30)
      Me.panCoil4.Controls.Add(Me._cbo_coil_type_3)
      Me.panCoil4.Controls.Add(Me._cbo_fins_3)
      Me.panCoil4.Controls.Add(Me._cbo_rows_3)
      Me.panCoil4.Controls.Add(Me._lbl_num_rows_3)
      Me.panCoil4.Controls.Add(Me._lbl_num_fins_3)
      Me.panCoil4.Controls.Add(Me._lbl_fin_mtl_3)
      Me.panCoil4.Controls.Add(Me._ck_al_3)
      Me.panCoil4.Controls.Add(Me._lbl_fin_thickness_3)
      Me.panCoil4.Controls.Add(Me._cbo_fin_thickness_3)
      Me.panCoil4.Controls.Add(Me._cbo_tube_thickness_3)
      Me.panCoil4.Controls.Add(Me._lbl_tube_thickness_3)
      Me.panCoil4.Controls.Add(Me._lbl_casing_3)
      Me.panCoil4.Controls.Add(Me._ck_gal_3)
      Me.panCoil4.Controls.Add(Me._ck_ss_3)
      Me.panCoil4.Location = New System.Drawing.Point(0, 22)
      Me.panCoil4.Name = "panCoil4"
      Me.panCoil4.Size = New System.Drawing.Size(220, 176)
      Me.panCoil4.TabIndex = 335
      '
      '_ck_cu_3
      '
      Me._ck_cu_3.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_cu_3.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_cu_3.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_cu_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_cu_3.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_cu.SetIndex(Me._ck_cu_3, CType(3, Short))
      Me._ck_cu_3.Location = New System.Drawing.Point(160, 70)
      Me._ck_cu_3.Name = "_ck_cu_3"
      Me._ck_cu_3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_cu_3.Size = New System.Drawing.Size(60, 22)
      Me._ck_cu_3.TabIndex = 184
      Me._ck_cu_3.Text = "Copper"
      Me._ck_cu_3.UseVisualStyleBackColor = False
      '
      'lblCoilCasing4
      '
      Me.lblCoilCasing4.BackColor = System.Drawing.Color.Yellow
      Me.lblCoilCasing4.Location = New System.Drawing.Point(116, 176)
      Me.lblCoilCasing4.Name = "lblCoilCasing4"
      Me.lblCoilCasing4.Size = New System.Drawing.Size(100, 23)
      Me.lblCoilCasing4.TabIndex = 341
      Me.lblCoilCasing4.Text = "Label32"
      '
      'lblFinMaterial4
      '
      Me.lblFinMaterial4.BackColor = System.Drawing.Color.Yellow
      Me.lblFinMaterial4.Location = New System.Drawing.Point(2, 180)
      Me.lblFinMaterial4.Name = "lblFinMaterial4"
      Me.lblFinMaterial4.Size = New System.Drawing.Size(70, 23)
      Me.lblFinMaterial4.TabIndex = 340
      Me.lblFinMaterial4.Text = "Label32"
      '
      'Label30
      '
      Me.Label30.Location = New System.Drawing.Point(2, 4)
      Me.Label30.Name = "Label30"
      Me.Label30.Size = New System.Drawing.Size(80, 23)
      Me.Label30.TabIndex = 339
      Me.Label30.Text = "Type"
      Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_cbo_coil_type_3
      '
      Me._cbo_coil_type_3.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_coil_type_3.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_coil_type_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_coil_type_3.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_coil_type.SetIndex(Me._cbo_coil_type_3, CType(3, Short))
      Me._cbo_coil_type_3.Location = New System.Drawing.Point(88, 4)
      Me._cbo_coil_type_3.Name = "_cbo_coil_type_3"
      Me._cbo_coil_type_3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_coil_type_3.Size = New System.Drawing.Size(97, 21)
      Me._cbo_coil_type_3.TabIndex = 334
      Me._cbo_coil_type_3.Text = "Coil Type"
      '
      '_cbo_fins_3
      '
      Me._cbo_fins_3.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_fins_3.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_fins_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_fins_3.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_fins.SetIndex(Me._cbo_fins_3, CType(3, Short))
      Me._cbo_fins_3.Location = New System.Drawing.Point(88, 48)
      Me._cbo_fins_3.Name = "_cbo_fins_3"
      Me._cbo_fins_3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_fins_3.Size = New System.Drawing.Size(52, 21)
      Me._cbo_fins_3.TabIndex = 186
      Me._cbo_fins_3.Text = "0"
      '
      '_cbo_rows_3
      '
      Me._cbo_rows_3.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_rows_3.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_rows_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_rows_3.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_rows.SetIndex(Me._cbo_rows_3, CType(3, Short))
      Me._cbo_rows_3.Location = New System.Drawing.Point(88, 26)
      Me._cbo_rows_3.Name = "_cbo_rows_3"
      Me._cbo_rows_3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_rows_3.Size = New System.Drawing.Size(52, 21)
      Me._cbo_rows_3.TabIndex = 187
      Me._cbo_rows_3.Text = "0"
      '
      '_lbl_num_rows_3
      '
      Me._lbl_num_rows_3.BackColor = System.Drawing.Color.Transparent
      Me._lbl_num_rows_3.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_num_rows_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_num_rows_3.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_num_rows.SetIndex(Me._lbl_num_rows_3, CType(3, Short))
      Me._lbl_num_rows_3.Location = New System.Drawing.Point(-2, 26)
      Me._lbl_num_rows_3.Name = "_lbl_num_rows_3"
      Me._lbl_num_rows_3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_num_rows_3.Size = New System.Drawing.Size(84, 22)
      Me._lbl_num_rows_3.TabIndex = 227
      Me._lbl_num_rows_3.Text = "# of rows"
      Me._lbl_num_rows_3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_num_fins_3
      '
      Me._lbl_num_fins_3.BackColor = System.Drawing.Color.Transparent
      Me._lbl_num_fins_3.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_num_fins_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_num_fins_3.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_num_fins.SetIndex(Me._lbl_num_fins_3, CType(3, Short))
      Me._lbl_num_fins_3.Location = New System.Drawing.Point(-2, 48)
      Me._lbl_num_fins_3.Name = "_lbl_num_fins_3"
      Me._lbl_num_fins_3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_num_fins_3.Size = New System.Drawing.Size(84, 22)
      Me._lbl_num_fins_3.TabIndex = 226
      Me._lbl_num_fins_3.Text = "# of fins"
      Me._lbl_num_fins_3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_fin_mtl_3
      '
      Me._lbl_fin_mtl_3.BackColor = System.Drawing.Color.Transparent
      Me._lbl_fin_mtl_3.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_fin_mtl_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_fin_mtl_3.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_fin_mtl.SetIndex(Me._lbl_fin_mtl_3, CType(3, Short))
      Me._lbl_fin_mtl_3.Location = New System.Drawing.Point(-2, 70)
      Me._lbl_fin_mtl_3.Name = "_lbl_fin_mtl_3"
      Me._lbl_fin_mtl_3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_fin_mtl_3.Size = New System.Drawing.Size(84, 22)
      Me._lbl_fin_mtl_3.TabIndex = 229
      Me._lbl_fin_mtl_3.Text = "Fin material"
      Me._lbl_fin_mtl_3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_ck_al_3
      '
      Me._ck_al_3.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_al_3.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_al_3.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_al_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_al_3.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_al.SetIndex(Me._ck_al_3, CType(3, Short))
      Me._ck_al_3.Location = New System.Drawing.Point(88, 70)
      Me._ck_al_3.Name = "_ck_al_3"
      Me._ck_al_3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_al_3.Size = New System.Drawing.Size(81, 22)
      Me._ck_al_3.TabIndex = 185
      Me._ck_al_3.Text = "Aluminum"
      Me._ck_al_3.UseVisualStyleBackColor = False
      '
      '_lbl_fin_thickness_3
      '
      Me._lbl_fin_thickness_3.BackColor = System.Drawing.Color.Transparent
      Me._lbl_fin_thickness_3.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_fin_thickness_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_fin_thickness_3.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_fin_thickness.SetIndex(Me._lbl_fin_thickness_3, CType(3, Short))
      Me._lbl_fin_thickness_3.Location = New System.Drawing.Point(-2, 92)
      Me._lbl_fin_thickness_3.Name = "_lbl_fin_thickness_3"
      Me._lbl_fin_thickness_3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_fin_thickness_3.Size = New System.Drawing.Size(84, 22)
      Me._lbl_fin_thickness_3.TabIndex = 225
      Me._lbl_fin_thickness_3.Text = "Fin thickness"
      Me._lbl_fin_thickness_3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_cbo_fin_thickness_3
      '
      Me._cbo_fin_thickness_3.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_fin_thickness_3.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_fin_thickness_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_fin_thickness_3.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_fin_thickness.SetIndex(Me._cbo_fin_thickness_3, CType(3, Short))
      Me._cbo_fin_thickness_3.Location = New System.Drawing.Point(88, 92)
      Me._cbo_fin_thickness_3.Name = "_cbo_fin_thickness_3"
      Me._cbo_fin_thickness_3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_fin_thickness_3.Size = New System.Drawing.Size(81, 21)
      Me._cbo_fin_thickness_3.TabIndex = 183
      Me._cbo_fin_thickness_3.Text = "0"
      '
      '_cbo_tube_thickness_3
      '
      Me._cbo_tube_thickness_3.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_tube_thickness_3.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_tube_thickness_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_tube_thickness_3.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_tube_thickness.SetIndex(Me._cbo_tube_thickness_3, CType(3, Short))
      Me._cbo_tube_thickness_3.Location = New System.Drawing.Point(88, 114)
      Me._cbo_tube_thickness_3.Name = "_cbo_tube_thickness_3"
      Me._cbo_tube_thickness_3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_tube_thickness_3.Size = New System.Drawing.Size(81, 21)
      Me._cbo_tube_thickness_3.TabIndex = 180
      Me._cbo_tube_thickness_3.Text = "0"
      '
      '_lbl_tube_thickness_3
      '
      Me._lbl_tube_thickness_3.BackColor = System.Drawing.Color.Transparent
      Me._lbl_tube_thickness_3.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_tube_thickness_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_tube_thickness_3.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_tube_thickness.SetIndex(Me._lbl_tube_thickness_3, CType(3, Short))
      Me._lbl_tube_thickness_3.Location = New System.Drawing.Point(-2, 112)
      Me._lbl_tube_thickness_3.Name = "_lbl_tube_thickness_3"
      Me._lbl_tube_thickness_3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_tube_thickness_3.Size = New System.Drawing.Size(84, 22)
      Me._lbl_tube_thickness_3.TabIndex = 224
      Me._lbl_tube_thickness_3.Text = "Tube thickness"
      Me._lbl_tube_thickness_3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_casing_3
      '
      Me._lbl_casing_3.BackColor = System.Drawing.Color.Transparent
      Me._lbl_casing_3.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_casing_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_casing_3.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_casing.SetIndex(Me._lbl_casing_3, CType(3, Short))
      Me._lbl_casing_3.Location = New System.Drawing.Point(-2, 134)
      Me._lbl_casing_3.Name = "_lbl_casing_3"
      Me._lbl_casing_3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_casing_3.Size = New System.Drawing.Size(84, 22)
      Me._lbl_casing_3.TabIndex = 228
      Me._lbl_casing_3.Text = "Casing"
      Me._lbl_casing_3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_ck_gal_3
      '
      Me._ck_gal_3.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_gal_3.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_gal_3.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_gal_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_gal_3.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_gal.SetIndex(Me._ck_gal_3, CType(3, Short))
      Me._ck_gal_3.Location = New System.Drawing.Point(88, 152)
      Me._ck_gal_3.Name = "_ck_gal_3"
      Me._ck_gal_3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_gal_3.Size = New System.Drawing.Size(105, 22)
      Me._ck_gal_3.TabIndex = 181
      Me._ck_gal_3.Text = "Galvanized steel"
      Me._ck_gal_3.UseVisualStyleBackColor = False
      '
      '_ck_ss_3
      '
      Me._ck_ss_3.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_ss_3.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_ss_3.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_ss_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_ss_3.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_ss.SetIndex(Me._ck_ss_3, CType(3, Short))
      Me._ck_ss_3.Location = New System.Drawing.Point(88, 134)
      Me._ck_ss_3.Name = "_ck_ss_3"
      Me._ck_ss_3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_ss_3.Size = New System.Drawing.Size(105, 22)
      Me._ck_ss_3.TabIndex = 338
      Me._ck_ss_3.Text = "Stainless steel"
      Me._ck_ss_3.UseVisualStyleBackColor = False
      '
      '_lbl_coil_type_3
      '
      Me._lbl_coil_type_3.BackColor = System.Drawing.Color.DarkGray
      Me._lbl_coil_type_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._lbl_coil_type_3.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_coil_type_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_coil_type_3.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_coil_type.SetIndex(Me._lbl_coil_type_3, CType(3, Short))
      Me._lbl_coil_type_3.Location = New System.Drawing.Point(0, 0)
      Me._lbl_coil_type_3.Name = "_lbl_coil_type_3"
      Me._lbl_coil_type_3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_coil_type_3.Size = New System.Drawing.Size(212, 23)
      Me._lbl_coil_type_3.TabIndex = 230
      Me._lbl_coil_type_3.Text = "Coil Type"
      Me._lbl_coil_type_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'panCoil3Container
      '
      Me.panCoil3Container.Controls.Add(Me._lbl_coil_cost_2)
      Me.panCoil3Container.Controls.Add(Me.lblCoil3OrderIndex)
      Me.panCoil3Container.Controls.Add(Me.panCoil3)
      Me.panCoil3Container.Controls.Add(Me._lbl_coil_type_2)
      Me.panCoil3Container.Location = New System.Drawing.Point(20, 218)
      Me.panCoil3Container.Name = "panCoil3Container"
      Me.panCoil3Container.Size = New System.Drawing.Size(226, 198)
      Me.panCoil3Container.TabIndex = 341
      Me.panCoil3Container.Visible = False
      '
      '_lbl_coil_cost_2
      '
      Me._lbl_coil_cost_2.BackColor = System.Drawing.Color.DarkGray
      Me._lbl_coil_cost_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_coil_cost_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_coil_cost_2.ForeColor = System.Drawing.Color.Blue
      Me.lbl_coil_cost.SetIndex(Me._lbl_coil_cost_2, CType(2, Short))
      Me._lbl_coil_cost_2.Location = New System.Drawing.Point(108, 2)
      Me._lbl_coil_cost_2.Name = "_lbl_coil_cost_2"
      Me._lbl_coil_cost_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_coil_cost_2.Size = New System.Drawing.Size(80, 18)
      Me._lbl_coil_cost_2.TabIndex = 214
      Me._lbl_coil_cost_2.Text = "0"
      Me._lbl_coil_cost_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me._lbl_coil_cost_2.Visible = False
      '
      'lblCoil3OrderIndex
      '
      Me.lblCoil3OrderIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblCoil3OrderIndex.Location = New System.Drawing.Point(192, 0)
      Me.lblCoil3OrderIndex.Name = "lblCoil3OrderIndex"
      Me.lblCoil3OrderIndex.Size = New System.Drawing.Size(28, 23)
      Me.lblCoil3OrderIndex.TabIndex = 336
      Me.lblCoil3OrderIndex.Text = "-1"
      Me.lblCoil3OrderIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'panCoil3
      '
      Me.panCoil3.BackColor = System.Drawing.Color.WhiteSmoke
      Me.panCoil3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.panCoil3.Controls.Add(Me._ck_cu_2)
      Me.panCoil3.Controls.Add(Me.lblCoilCasing3)
      Me.panCoil3.Controls.Add(Me.lblFinMaterial3)
      Me.panCoil3.Controls.Add(Me.Label20)
      Me.panCoil3.Controls.Add(Me._cbo_tube_thickness_2)
      Me.panCoil3.Controls.Add(Me._ck_gal_2)
      Me.panCoil3.Controls.Add(Me._cbo_fin_thickness_2)
      Me.panCoil3.Controls.Add(Me._ck_al_2)
      Me.panCoil3.Controls.Add(Me._cbo_fins_2)
      Me.panCoil3.Controls.Add(Me._cbo_rows_2)
      Me.panCoil3.Controls.Add(Me._ck_ss_2)
      Me.panCoil3.Controls.Add(Me._cbo_coil_type_2)
      Me.panCoil3.Controls.Add(Me._lbl_num_rows_2)
      Me.panCoil3.Controls.Add(Me._lbl_num_fins_2)
      Me.panCoil3.Controls.Add(Me._lbl_fin_thickness_2)
      Me.panCoil3.Controls.Add(Me._lbl_tube_thickness_2)
      Me.panCoil3.Controls.Add(Me._lbl_casing_2)
      Me.panCoil3.Controls.Add(Me._lbl_fin_mtl_2)
      Me.panCoil3.Location = New System.Drawing.Point(0, 22)
      Me.panCoil3.Name = "panCoil3"
      Me.panCoil3.Size = New System.Drawing.Size(220, 176)
      Me.panCoil3.TabIndex = 238
      '
      '_ck_cu_2
      '
      Me._ck_cu_2.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_cu_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_cu_2.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_cu_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_cu_2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_cu.SetIndex(Me._ck_cu_2, CType(2, Short))
      Me._ck_cu_2.Location = New System.Drawing.Point(160, 70)
      Me._ck_cu_2.Name = "_ck_cu_2"
      Me._ck_cu_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_cu_2.Size = New System.Drawing.Size(66, 22)
      Me._ck_cu_2.TabIndex = 192
      Me._ck_cu_2.Text = "Copper"
      Me._ck_cu_2.UseVisualStyleBackColor = False
      '
      'lblCoilCasing3
      '
      Me.lblCoilCasing3.BackColor = System.Drawing.Color.Yellow
      Me.lblCoilCasing3.Location = New System.Drawing.Point(114, 176)
      Me.lblCoilCasing3.Name = "lblCoilCasing3"
      Me.lblCoilCasing3.Size = New System.Drawing.Size(100, 23)
      Me.lblCoilCasing3.TabIndex = 340
      Me.lblCoilCasing3.Text = "Label32"
      '
      'lblFinMaterial3
      '
      Me.lblFinMaterial3.BackColor = System.Drawing.Color.Yellow
      Me.lblFinMaterial3.Location = New System.Drawing.Point(2, 180)
      Me.lblFinMaterial3.Name = "lblFinMaterial3"
      Me.lblFinMaterial3.Size = New System.Drawing.Size(70, 23)
      Me.lblFinMaterial3.TabIndex = 339
      Me.lblFinMaterial3.Text = "Label32"
      '
      'Label20
      '
      Me.Label20.Location = New System.Drawing.Point(0, 4)
      Me.Label20.Name = "Label20"
      Me.Label20.Size = New System.Drawing.Size(80, 23)
      Me.Label20.TabIndex = 338
      Me.Label20.Text = "Type"
      Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_cbo_tube_thickness_2
      '
      Me._cbo_tube_thickness_2.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_tube_thickness_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_tube_thickness_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_tube_thickness_2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_tube_thickness.SetIndex(Me._cbo_tube_thickness_2, CType(2, Short))
      Me._cbo_tube_thickness_2.Location = New System.Drawing.Point(86, 114)
      Me._cbo_tube_thickness_2.Name = "_cbo_tube_thickness_2"
      Me._cbo_tube_thickness_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_tube_thickness_2.Size = New System.Drawing.Size(81, 21)
      Me._cbo_tube_thickness_2.TabIndex = 188
      Me._cbo_tube_thickness_2.Text = "0"
      '
      '_ck_gal_2
      '
      Me._ck_gal_2.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_gal_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_gal_2.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_gal_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_gal_2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_gal.SetIndex(Me._ck_gal_2, CType(2, Short))
      Me._ck_gal_2.Location = New System.Drawing.Point(86, 152)
      Me._ck_gal_2.Name = "_ck_gal_2"
      Me._ck_gal_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_gal_2.Size = New System.Drawing.Size(105, 22)
      Me._ck_gal_2.TabIndex = 189
      Me._ck_gal_2.Text = "Galvanized steel"
      Me._ck_gal_2.UseVisualStyleBackColor = False
      '
      '_cbo_fin_thickness_2
      '
      Me._cbo_fin_thickness_2.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_fin_thickness_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_fin_thickness_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_fin_thickness_2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_fin_thickness.SetIndex(Me._cbo_fin_thickness_2, CType(2, Short))
      Me._cbo_fin_thickness_2.Location = New System.Drawing.Point(86, 92)
      Me._cbo_fin_thickness_2.Name = "_cbo_fin_thickness_2"
      Me._cbo_fin_thickness_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_fin_thickness_2.Size = New System.Drawing.Size(81, 21)
      Me._cbo_fin_thickness_2.TabIndex = 191
      Me._cbo_fin_thickness_2.Text = "0"
      '
      '_ck_al_2
      '
      Me._ck_al_2.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_al_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_al_2.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_al_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_al_2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_al.SetIndex(Me._ck_al_2, CType(2, Short))
      Me._ck_al_2.Location = New System.Drawing.Point(86, 70)
      Me._ck_al_2.Name = "_ck_al_2"
      Me._ck_al_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_al_2.Size = New System.Drawing.Size(81, 22)
      Me._ck_al_2.TabIndex = 193
      Me._ck_al_2.Text = "Aluminum"
      Me._ck_al_2.UseVisualStyleBackColor = False
      '
      '_cbo_fins_2
      '
      Me._cbo_fins_2.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_fins_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_fins_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_fins_2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_fins.SetIndex(Me._cbo_fins_2, CType(2, Short))
      Me._cbo_fins_2.Location = New System.Drawing.Point(86, 48)
      Me._cbo_fins_2.Name = "_cbo_fins_2"
      Me._cbo_fins_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_fins_2.Size = New System.Drawing.Size(52, 21)
      Me._cbo_fins_2.TabIndex = 194
      Me._cbo_fins_2.Text = "0"
      '
      '_cbo_rows_2
      '
      Me._cbo_rows_2.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_rows_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_rows_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_rows_2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_rows.SetIndex(Me._cbo_rows_2, CType(2, Short))
      Me._cbo_rows_2.Location = New System.Drawing.Point(86, 26)
      Me._cbo_rows_2.Name = "_cbo_rows_2"
      Me._cbo_rows_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_rows_2.Size = New System.Drawing.Size(52, 21)
      Me._cbo_rows_2.TabIndex = 195
      Me._cbo_rows_2.Text = "0"
      '
      '_ck_ss_2
      '
      Me._ck_ss_2.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_ss_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_ss_2.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_ss_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_ss_2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_ss.SetIndex(Me._ck_ss_2, CType(2, Short))
      Me._ck_ss_2.Location = New System.Drawing.Point(86, 134)
      Me._ck_ss_2.Name = "_ck_ss_2"
      Me._ck_ss_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_ss_2.Size = New System.Drawing.Size(105, 22)
      Me._ck_ss_2.TabIndex = 337
      Me._ck_ss_2.Text = "Stainless steel"
      Me._ck_ss_2.UseVisualStyleBackColor = False
      '
      '_cbo_coil_type_2
      '
      Me._cbo_coil_type_2.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_coil_type_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_coil_type_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_coil_type_2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_coil_type.SetIndex(Me._cbo_coil_type_2, CType(2, Short))
      Me._cbo_coil_type_2.Location = New System.Drawing.Point(86, 4)
      Me._cbo_coil_type_2.Name = "_cbo_coil_type_2"
      Me._cbo_coil_type_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_coil_type_2.Size = New System.Drawing.Size(97, 21)
      Me._cbo_coil_type_2.TabIndex = 333
      Me._cbo_coil_type_2.Text = "Coil Type"
      '
      '_lbl_num_rows_2
      '
      Me._lbl_num_rows_2.BackColor = System.Drawing.Color.Transparent
      Me._lbl_num_rows_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_num_rows_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_num_rows_2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_num_rows.SetIndex(Me._lbl_num_rows_2, CType(2, Short))
      Me._lbl_num_rows_2.Location = New System.Drawing.Point(-2, 26)
      Me._lbl_num_rows_2.Name = "_lbl_num_rows_2"
      Me._lbl_num_rows_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_num_rows_2.Size = New System.Drawing.Size(82, 22)
      Me._lbl_num_rows_2.TabIndex = 234
      Me._lbl_num_rows_2.Text = "# of rows"
      Me._lbl_num_rows_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_num_fins_2
      '
      Me._lbl_num_fins_2.BackColor = System.Drawing.Color.Transparent
      Me._lbl_num_fins_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_num_fins_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_num_fins_2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_num_fins.SetIndex(Me._lbl_num_fins_2, CType(2, Short))
      Me._lbl_num_fins_2.Location = New System.Drawing.Point(-2, 48)
      Me._lbl_num_fins_2.Name = "_lbl_num_fins_2"
      Me._lbl_num_fins_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_num_fins_2.Size = New System.Drawing.Size(82, 22)
      Me._lbl_num_fins_2.TabIndex = 233
      Me._lbl_num_fins_2.Text = "# of fins"
      Me._lbl_num_fins_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_fin_thickness_2
      '
      Me._lbl_fin_thickness_2.BackColor = System.Drawing.Color.Transparent
      Me._lbl_fin_thickness_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_fin_thickness_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_fin_thickness_2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_fin_thickness.SetIndex(Me._lbl_fin_thickness_2, CType(2, Short))
      Me._lbl_fin_thickness_2.Location = New System.Drawing.Point(-2, 90)
      Me._lbl_fin_thickness_2.Name = "_lbl_fin_thickness_2"
      Me._lbl_fin_thickness_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_fin_thickness_2.Size = New System.Drawing.Size(82, 24)
      Me._lbl_fin_thickness_2.TabIndex = 232
      Me._lbl_fin_thickness_2.Text = "Fin thickness"
      Me._lbl_fin_thickness_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_tube_thickness_2
      '
      Me._lbl_tube_thickness_2.BackColor = System.Drawing.Color.Transparent
      Me._lbl_tube_thickness_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_tube_thickness_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_tube_thickness_2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_tube_thickness.SetIndex(Me._lbl_tube_thickness_2, CType(2, Short))
      Me._lbl_tube_thickness_2.Location = New System.Drawing.Point(-2, 114)
      Me._lbl_tube_thickness_2.Name = "_lbl_tube_thickness_2"
      Me._lbl_tube_thickness_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_tube_thickness_2.Size = New System.Drawing.Size(82, 24)
      Me._lbl_tube_thickness_2.TabIndex = 231
      Me._lbl_tube_thickness_2.Text = "Tube thickness"
      Me._lbl_tube_thickness_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_casing_2
      '
      Me._lbl_casing_2.BackColor = System.Drawing.Color.Transparent
      Me._lbl_casing_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_casing_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_casing_2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_casing.SetIndex(Me._lbl_casing_2, CType(2, Short))
      Me._lbl_casing_2.Location = New System.Drawing.Point(-2, 132)
      Me._lbl_casing_2.Name = "_lbl_casing_2"
      Me._lbl_casing_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_casing_2.Size = New System.Drawing.Size(82, 22)
      Me._lbl_casing_2.TabIndex = 235
      Me._lbl_casing_2.Text = "Casing"
      Me._lbl_casing_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_fin_mtl_2
      '
      Me._lbl_fin_mtl_2.BackColor = System.Drawing.Color.Transparent
      Me._lbl_fin_mtl_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_fin_mtl_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_fin_mtl_2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_fin_mtl.SetIndex(Me._lbl_fin_mtl_2, CType(2, Short))
      Me._lbl_fin_mtl_2.Location = New System.Drawing.Point(-2, 70)
      Me._lbl_fin_mtl_2.Name = "_lbl_fin_mtl_2"
      Me._lbl_fin_mtl_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_fin_mtl_2.Size = New System.Drawing.Size(82, 22)
      Me._lbl_fin_mtl_2.TabIndex = 236
      Me._lbl_fin_mtl_2.Text = "Fin material"
      Me._lbl_fin_mtl_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_coil_type_2
      '
      Me._lbl_coil_type_2.BackColor = System.Drawing.Color.DarkGray
      Me._lbl_coil_type_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._lbl_coil_type_2.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_coil_type_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_coil_type_2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_coil_type.SetIndex(Me._lbl_coil_type_2, CType(2, Short))
      Me._lbl_coil_type_2.Location = New System.Drawing.Point(0, 0)
      Me._lbl_coil_type_2.Name = "_lbl_coil_type_2"
      Me._lbl_coil_type_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_coil_type_2.Size = New System.Drawing.Size(210, 23)
      Me._lbl_coil_type_2.TabIndex = 237
      Me._lbl_coil_type_2.Text = "Coil Type"
      Me._lbl_coil_type_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'panCoil5Container
      '
      Me.panCoil5Container.Controls.Add(Me.panCoil5)
      Me.panCoil5Container.Controls.Add(Me.lblCoil5OrderIndex)
      Me.panCoil5Container.Controls.Add(Me._lbl_coil_cost_4)
      Me.panCoil5Container.Controls.Add(Me._lbl_coil_type_4)
      Me.panCoil5Container.Location = New System.Drawing.Point(478, 218)
      Me.panCoil5Container.Name = "panCoil5Container"
      Me.panCoil5Container.Size = New System.Drawing.Size(228, 200)
      Me.panCoil5Container.TabIndex = 344
      Me.panCoil5Container.Visible = False
      '
      'panCoil5
      '
      Me.panCoil5.BackColor = System.Drawing.Color.WhiteSmoke
      Me.panCoil5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.panCoil5.Controls.Add(Me._ck_cu_4)
      Me.panCoil5.Controls.Add(Me.lblCoilCasing5)
      Me.panCoil5.Controls.Add(Me.lblFinMaterial5)
      Me.panCoil5.Controls.Add(Me.Label31)
      Me.panCoil5.Controls.Add(Me._lbl_casing_4)
      Me.panCoil5.Controls.Add(Me._lbl_fin_mtl_4)
      Me.panCoil5.Controls.Add(Me._cbo_tube_thickness_4)
      Me.panCoil5.Controls.Add(Me._ck_gal_4)
      Me.panCoil5.Controls.Add(Me._cbo_fin_thickness_4)
      Me.panCoil5.Controls.Add(Me._ck_al_4)
      Me.panCoil5.Controls.Add(Me._cbo_fins_4)
      Me.panCoil5.Controls.Add(Me._cbo_rows_4)
      Me.panCoil5.Controls.Add(Me._ck_ss_4)
      Me.panCoil5.Controls.Add(Me._cbo_coil_type_4)
      Me.panCoil5.Controls.Add(Me._lbl_num_rows_4)
      Me.panCoil5.Controls.Add(Me._lbl_num_fins_4)
      Me.panCoil5.Controls.Add(Me._lbl_fin_thickness_4)
      Me.panCoil5.Controls.Add(Me._lbl_tube_thickness_4)
      Me.panCoil5.Location = New System.Drawing.Point(0, 22)
      Me.panCoil5.Name = "panCoil5"
      Me.panCoil5.Size = New System.Drawing.Size(220, 176)
      Me.panCoil5.TabIndex = 343
      '
      '_ck_cu_4
      '
      Me._ck_cu_4.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_cu_4.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_cu_4.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_cu_4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_cu_4.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_cu.SetIndex(Me._ck_cu_4, CType(4, Short))
      Me._ck_cu_4.Location = New System.Drawing.Point(160, 72)
      Me._ck_cu_4.Name = "_ck_cu_4"
      Me._ck_cu_4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_cu_4.Size = New System.Drawing.Size(60, 22)
      Me._ck_cu_4.TabIndex = 176
      Me._ck_cu_4.Text = "Copper"
      Me._ck_cu_4.UseVisualStyleBackColor = False
      '
      'lblCoilCasing5
      '
      Me.lblCoilCasing5.BackColor = System.Drawing.Color.Yellow
      Me.lblCoilCasing5.Location = New System.Drawing.Point(110, 178)
      Me.lblCoilCasing5.Name = "lblCoilCasing5"
      Me.lblCoilCasing5.Size = New System.Drawing.Size(100, 23)
      Me.lblCoilCasing5.TabIndex = 338
      Me.lblCoilCasing5.Text = "Label32"
      '
      'lblFinMaterial5
      '
      Me.lblFinMaterial5.BackColor = System.Drawing.Color.Yellow
      Me.lblFinMaterial5.Location = New System.Drawing.Point(4, 180)
      Me.lblFinMaterial5.Name = "lblFinMaterial5"
      Me.lblFinMaterial5.Size = New System.Drawing.Size(70, 23)
      Me.lblFinMaterial5.TabIndex = 337
      Me.lblFinMaterial5.Text = "Label32"
      '
      'Label31
      '
      Me.Label31.Location = New System.Drawing.Point(2, 6)
      Me.Label31.Name = "Label31"
      Me.Label31.Size = New System.Drawing.Size(80, 23)
      Me.Label31.TabIndex = 336
      Me.Label31.Text = "Type"
      Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_casing_4
      '
      Me._lbl_casing_4.BackColor = System.Drawing.Color.Transparent
      Me._lbl_casing_4.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_casing_4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_casing_4.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_casing.SetIndex(Me._lbl_casing_4, CType(4, Short))
      Me._lbl_casing_4.Location = New System.Drawing.Point(0, 136)
      Me._lbl_casing_4.Name = "_lbl_casing_4"
      Me._lbl_casing_4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_casing_4.Size = New System.Drawing.Size(82, 22)
      Me._lbl_casing_4.TabIndex = 221
      Me._lbl_casing_4.Text = "Casing"
      Me._lbl_casing_4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_fin_mtl_4
      '
      Me._lbl_fin_mtl_4.BackColor = System.Drawing.Color.Transparent
      Me._lbl_fin_mtl_4.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_fin_mtl_4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_fin_mtl_4.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_fin_mtl.SetIndex(Me._lbl_fin_mtl_4, CType(4, Short))
      Me._lbl_fin_mtl_4.Location = New System.Drawing.Point(0, 72)
      Me._lbl_fin_mtl_4.Name = "_lbl_fin_mtl_4"
      Me._lbl_fin_mtl_4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_fin_mtl_4.Size = New System.Drawing.Size(82, 22)
      Me._lbl_fin_mtl_4.TabIndex = 222
      Me._lbl_fin_mtl_4.Text = "Fin material"
      Me._lbl_fin_mtl_4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_cbo_tube_thickness_4
      '
      Me._cbo_tube_thickness_4.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_tube_thickness_4.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_tube_thickness_4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_tube_thickness_4.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_tube_thickness.SetIndex(Me._cbo_tube_thickness_4, CType(4, Short))
      Me._cbo_tube_thickness_4.Location = New System.Drawing.Point(88, 116)
      Me._cbo_tube_thickness_4.Name = "_cbo_tube_thickness_4"
      Me._cbo_tube_thickness_4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_tube_thickness_4.Size = New System.Drawing.Size(81, 21)
      Me._cbo_tube_thickness_4.TabIndex = 172
      Me._cbo_tube_thickness_4.Text = "0"
      '
      '_ck_gal_4
      '
      Me._ck_gal_4.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_gal_4.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_gal_4.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_gal_4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_gal_4.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_gal.SetIndex(Me._ck_gal_4, CType(4, Short))
      Me._ck_gal_4.Location = New System.Drawing.Point(88, 154)
      Me._ck_gal_4.Name = "_ck_gal_4"
      Me._ck_gal_4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_gal_4.Size = New System.Drawing.Size(105, 22)
      Me._ck_gal_4.TabIndex = 173
      Me._ck_gal_4.Text = "Galvanized steel"
      Me._ck_gal_4.UseVisualStyleBackColor = False
      '
      '_cbo_fin_thickness_4
      '
      Me._cbo_fin_thickness_4.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_fin_thickness_4.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_fin_thickness_4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_fin_thickness_4.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_fin_thickness.SetIndex(Me._cbo_fin_thickness_4, CType(4, Short))
      Me._cbo_fin_thickness_4.Location = New System.Drawing.Point(88, 94)
      Me._cbo_fin_thickness_4.Name = "_cbo_fin_thickness_4"
      Me._cbo_fin_thickness_4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_fin_thickness_4.Size = New System.Drawing.Size(81, 21)
      Me._cbo_fin_thickness_4.TabIndex = 175
      Me._cbo_fin_thickness_4.Text = "0"
      '
      '_ck_al_4
      '
      Me._ck_al_4.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_al_4.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_al_4.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_al_4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_al_4.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_al.SetIndex(Me._ck_al_4, CType(4, Short))
      Me._ck_al_4.Location = New System.Drawing.Point(88, 72)
      Me._ck_al_4.Name = "_ck_al_4"
      Me._ck_al_4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_al_4.Size = New System.Drawing.Size(80, 22)
      Me._ck_al_4.TabIndex = 177
      Me._ck_al_4.Text = "Aluminum"
      Me._ck_al_4.UseVisualStyleBackColor = False
      '
      '_cbo_fins_4
      '
      Me._cbo_fins_4.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_fins_4.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_fins_4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_fins_4.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_fins.SetIndex(Me._cbo_fins_4, CType(4, Short))
      Me._cbo_fins_4.Location = New System.Drawing.Point(88, 50)
      Me._cbo_fins_4.Name = "_cbo_fins_4"
      Me._cbo_fins_4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_fins_4.Size = New System.Drawing.Size(81, 21)
      Me._cbo_fins_4.TabIndex = 178
      Me._cbo_fins_4.Text = "0"
      '
      '_cbo_rows_4
      '
      Me._cbo_rows_4.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_rows_4.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_rows_4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_rows_4.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_rows.SetIndex(Me._cbo_rows_4, CType(4, Short))
      Me._cbo_rows_4.Location = New System.Drawing.Point(88, 28)
      Me._cbo_rows_4.Name = "_cbo_rows_4"
      Me._cbo_rows_4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_rows_4.Size = New System.Drawing.Size(81, 21)
      Me._cbo_rows_4.TabIndex = 179
      Me._cbo_rows_4.Text = "0"
      '
      '_ck_ss_4
      '
      Me._ck_ss_4.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_ss_4.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_ss_4.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_ss_4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_ss_4.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_ss.SetIndex(Me._ck_ss_4, CType(4, Short))
      Me._ck_ss_4.Location = New System.Drawing.Point(88, 136)
      Me._ck_ss_4.Name = "_ck_ss_4"
      Me._ck_ss_4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_ss_4.Size = New System.Drawing.Size(105, 22)
      Me._ck_ss_4.TabIndex = 174
      Me._ck_ss_4.Text = "Stainless steel"
      Me._ck_ss_4.UseVisualStyleBackColor = False
      '
      '_cbo_coil_type_4
      '
      Me._cbo_coil_type_4.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_coil_type_4.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_coil_type_4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_coil_type_4.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_coil_type.SetIndex(Me._cbo_coil_type_4, CType(4, Short))
      Me._cbo_coil_type_4.Location = New System.Drawing.Point(88, 6)
      Me._cbo_coil_type_4.Name = "_cbo_coil_type_4"
      Me._cbo_coil_type_4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_coil_type_4.Size = New System.Drawing.Size(97, 21)
      Me._cbo_coil_type_4.TabIndex = 335
      Me._cbo_coil_type_4.Text = "Coil Type"
      '
      '_lbl_num_rows_4
      '
      Me._lbl_num_rows_4.BackColor = System.Drawing.Color.Transparent
      Me._lbl_num_rows_4.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_num_rows_4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_num_rows_4.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_num_rows.SetIndex(Me._lbl_num_rows_4, CType(4, Short))
      Me._lbl_num_rows_4.Location = New System.Drawing.Point(0, 30)
      Me._lbl_num_rows_4.Name = "_lbl_num_rows_4"
      Me._lbl_num_rows_4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_num_rows_4.Size = New System.Drawing.Size(82, 22)
      Me._lbl_num_rows_4.TabIndex = 220
      Me._lbl_num_rows_4.Text = "# of rows"
      Me._lbl_num_rows_4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_num_fins_4
      '
      Me._lbl_num_fins_4.BackColor = System.Drawing.Color.Transparent
      Me._lbl_num_fins_4.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_num_fins_4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_num_fins_4.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_num_fins.SetIndex(Me._lbl_num_fins_4, CType(4, Short))
      Me._lbl_num_fins_4.Location = New System.Drawing.Point(0, 52)
      Me._lbl_num_fins_4.Name = "_lbl_num_fins_4"
      Me._lbl_num_fins_4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_num_fins_4.Size = New System.Drawing.Size(82, 22)
      Me._lbl_num_fins_4.TabIndex = 219
      Me._lbl_num_fins_4.Text = "# of fins"
      Me._lbl_num_fins_4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_fin_thickness_4
      '
      Me._lbl_fin_thickness_4.BackColor = System.Drawing.Color.Transparent
      Me._lbl_fin_thickness_4.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_fin_thickness_4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_fin_thickness_4.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_fin_thickness.SetIndex(Me._lbl_fin_thickness_4, CType(4, Short))
      Me._lbl_fin_thickness_4.Location = New System.Drawing.Point(0, 94)
      Me._lbl_fin_thickness_4.Name = "_lbl_fin_thickness_4"
      Me._lbl_fin_thickness_4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_fin_thickness_4.Size = New System.Drawing.Size(82, 22)
      Me._lbl_fin_thickness_4.TabIndex = 218
      Me._lbl_fin_thickness_4.Text = "Fin thickness"
      Me._lbl_fin_thickness_4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_tube_thickness_4
      '
      Me._lbl_tube_thickness_4.BackColor = System.Drawing.Color.Transparent
      Me._lbl_tube_thickness_4.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_tube_thickness_4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_tube_thickness_4.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_tube_thickness.SetIndex(Me._lbl_tube_thickness_4, CType(4, Short))
      Me._lbl_tube_thickness_4.Location = New System.Drawing.Point(0, 116)
      Me._lbl_tube_thickness_4.Name = "_lbl_tube_thickness_4"
      Me._lbl_tube_thickness_4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_tube_thickness_4.Size = New System.Drawing.Size(82, 22)
      Me._lbl_tube_thickness_4.TabIndex = 217
      Me._lbl_tube_thickness_4.Text = "Tube thickness"
      Me._lbl_tube_thickness_4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCoil5OrderIndex
      '
      Me.lblCoil5OrderIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblCoil5OrderIndex.Location = New System.Drawing.Point(192, 0)
      Me.lblCoil5OrderIndex.Name = "lblCoil5OrderIndex"
      Me.lblCoil5OrderIndex.Size = New System.Drawing.Size(28, 23)
      Me.lblCoil5OrderIndex.TabIndex = 342
      Me.lblCoil5OrderIndex.Text = "-1"
      Me.lblCoil5OrderIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      '_lbl_coil_cost_4
      '
      Me._lbl_coil_cost_4.BackColor = System.Drawing.Color.DarkGray
      Me._lbl_coil_cost_4.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_coil_cost_4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_coil_cost_4.ForeColor = System.Drawing.Color.Blue
      Me.lbl_coil_cost.SetIndex(Me._lbl_coil_cost_4, CType(4, Short))
      Me._lbl_coil_cost_4.Location = New System.Drawing.Point(102, 2)
      Me._lbl_coil_cost_4.Name = "_lbl_coil_cost_4"
      Me._lbl_coil_cost_4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_coil_cost_4.Size = New System.Drawing.Size(86, 18)
      Me._lbl_coil_cost_4.TabIndex = 212
      Me._lbl_coil_cost_4.Text = "0"
      Me._lbl_coil_cost_4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me._lbl_coil_cost_4.Visible = False
      '
      '_lbl_coil_type_4
      '
      Me._lbl_coil_type_4.BackColor = System.Drawing.Color.DarkGray
      Me._lbl_coil_type_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._lbl_coil_type_4.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_coil_type_4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_coil_type_4.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_coil_type.SetIndex(Me._lbl_coil_type_4, CType(4, Short))
      Me._lbl_coil_type_4.Location = New System.Drawing.Point(0, 0)
      Me._lbl_coil_type_4.Name = "_lbl_coil_type_4"
      Me._lbl_coil_type_4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_coil_type_4.Size = New System.Drawing.Size(212, 23)
      Me._lbl_coil_type_4.TabIndex = 223
      Me._lbl_coil_type_4.Text = "Coil Type"
      Me._lbl_coil_type_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'panCoil2Container
      '
      Me.panCoil2Container.Controls.Add(Me._lbl_coil_cost_1)
      Me.panCoil2Container.Controls.Add(Me.lblCoil2OrderIndex)
      Me.panCoil2Container.Controls.Add(Me._lbl_coil_type_1)
      Me.panCoil2Container.Controls.Add(Me.panCoil2)
      Me.panCoil2Container.Location = New System.Drawing.Point(250, 20)
      Me.panCoil2Container.Name = "panCoil2Container"
      Me.panCoil2Container.Size = New System.Drawing.Size(226, 204)
      Me.panCoil2Container.TabIndex = 340
      Me.panCoil2Container.Visible = False
      '
      '_lbl_coil_cost_1
      '
      Me._lbl_coil_cost_1.BackColor = System.Drawing.Color.DarkGray
      Me._lbl_coil_cost_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_coil_cost_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_coil_cost_1.ForeColor = System.Drawing.Color.Blue
      Me.lbl_coil_cost.SetIndex(Me._lbl_coil_cost_1, CType(1, Short))
      Me._lbl_coil_cost_1.Location = New System.Drawing.Point(92, 2)
      Me._lbl_coil_cost_1.Name = "_lbl_coil_cost_1"
      Me._lbl_coil_cost_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_coil_cost_1.Size = New System.Drawing.Size(96, 18)
      Me._lbl_coil_cost_1.TabIndex = 215
      Me._lbl_coil_cost_1.Text = "0"
      Me._lbl_coil_cost_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me._lbl_coil_cost_1.Visible = False
      '
      'lblCoil2OrderIndex
      '
      Me.lblCoil2OrderIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblCoil2OrderIndex.Location = New System.Drawing.Point(192, 0)
      Me.lblCoil2OrderIndex.Name = "lblCoil2OrderIndex"
      Me.lblCoil2OrderIndex.Size = New System.Drawing.Size(28, 23)
      Me.lblCoil2OrderIndex.TabIndex = 335
      Me.lblCoil2OrderIndex.Text = "-1"
      Me.lblCoil2OrderIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      '_lbl_coil_type_1
      '
      Me._lbl_coil_type_1.BackColor = System.Drawing.Color.DarkGray
      Me._lbl_coil_type_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._lbl_coil_type_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_coil_type_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_coil_type_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_coil_type.SetIndex(Me._lbl_coil_type_1, CType(1, Short))
      Me._lbl_coil_type_1.Location = New System.Drawing.Point(0, 0)
      Me._lbl_coil_type_1.Name = "_lbl_coil_type_1"
      Me._lbl_coil_type_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_coil_type_1.Size = New System.Drawing.Size(220, 23)
      Me._lbl_coil_type_1.TabIndex = 244
      Me._lbl_coil_type_1.Text = "Coil Type"
      Me._lbl_coil_type_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'panCoil2
      '
      Me.panCoil2.BackColor = System.Drawing.Color.WhiteSmoke
      Me.panCoil2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.panCoil2.Controls.Add(Me._ck_cu_1)
      Me.panCoil2.Controls.Add(Me.lblCoilCasing2)
      Me.panCoil2.Controls.Add(Me.lblFinMaterial2)
      Me.panCoil2.Controls.Add(Me._ck_gal_1)
      Me.panCoil2.Controls.Add(Me.Label16)
      Me.panCoil2.Controls.Add(Me._cbo_fins_1)
      Me.panCoil2.Controls.Add(Me._cbo_rows_1)
      Me.panCoil2.Controls.Add(Me._cbo_coil_type_1)
      Me.panCoil2.Controls.Add(Me._lbl_num_rows_1)
      Me.panCoil2.Controls.Add(Me._lbl_num_fins_1)
      Me.panCoil2.Controls.Add(Me._ck_al_1)
      Me.panCoil2.Controls.Add(Me._lbl_fin_mtl_1)
      Me.panCoil2.Controls.Add(Me._lbl_fin_thickness_1)
      Me.panCoil2.Controls.Add(Me._cbo_fin_thickness_1)
      Me.panCoil2.Controls.Add(Me._lbl_tube_thickness_1)
      Me.panCoil2.Controls.Add(Me._cbo_tube_thickness_1)
      Me.panCoil2.Controls.Add(Me._lbl_casing_1)
      Me.panCoil2.Controls.Add(Me._ck_ss_1)
      Me.panCoil2.Location = New System.Drawing.Point(0, 22)
      Me.panCoil2.Name = "panCoil2"
      Me.panCoil2.Size = New System.Drawing.Size(220, 178)
      Me.panCoil2.TabIndex = 245
      '
      '_ck_cu_1
      '
      Me._ck_cu_1.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_cu_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_cu_1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_cu_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_cu_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_cu.SetIndex(Me._ck_cu_1, CType(1, Short))
      Me._ck_cu_1.Location = New System.Drawing.Point(160, 70)
      Me._ck_cu_1.Name = "_ck_cu_1"
      Me._ck_cu_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_cu_1.Size = New System.Drawing.Size(64, 22)
      Me._ck_cu_1.TabIndex = 200
      Me._ck_cu_1.Text = "Copper"
      Me._ck_cu_1.UseVisualStyleBackColor = False
      '
      'lblCoilCasing2
      '
      Me.lblCoilCasing2.BackColor = System.Drawing.Color.Yellow
      Me.lblCoilCasing2.Location = New System.Drawing.Point(112, 178)
      Me.lblCoilCasing2.Name = "lblCoilCasing2"
      Me.lblCoilCasing2.Size = New System.Drawing.Size(100, 23)
      Me.lblCoilCasing2.TabIndex = 339
      Me.lblCoilCasing2.Text = "Label32"
      '
      'lblFinMaterial2
      '
      Me.lblFinMaterial2.BackColor = System.Drawing.Color.Yellow
      Me.lblFinMaterial2.Location = New System.Drawing.Point(4, 180)
      Me.lblFinMaterial2.Name = "lblFinMaterial2"
      Me.lblFinMaterial2.Size = New System.Drawing.Size(70, 23)
      Me.lblFinMaterial2.TabIndex = 338
      Me.lblFinMaterial2.Text = "Label32"
      '
      '_ck_gal_1
      '
      Me._ck_gal_1.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_gal_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_gal_1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_gal_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_gal_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_gal.SetIndex(Me._ck_gal_1, CType(1, Short))
      Me._ck_gal_1.Location = New System.Drawing.Point(88, 152)
      Me._ck_gal_1.Name = "_ck_gal_1"
      Me._ck_gal_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_gal_1.Size = New System.Drawing.Size(105, 22)
      Me._ck_gal_1.TabIndex = 197
      Me._ck_gal_1.Text = "Galvanized steel"
      Me._ck_gal_1.UseVisualStyleBackColor = False
      '
      'Label16
      '
      Me.Label16.Location = New System.Drawing.Point(2, 4)
      Me.Label16.Name = "Label16"
      Me.Label16.Size = New System.Drawing.Size(80, 23)
      Me.Label16.TabIndex = 337
      Me.Label16.Text = "Type"
      Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_cbo_fins_1
      '
      Me._cbo_fins_1.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_fins_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_fins_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_fins_1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_fins.SetIndex(Me._cbo_fins_1, CType(1, Short))
      Me._cbo_fins_1.Location = New System.Drawing.Point(88, 48)
      Me._cbo_fins_1.Name = "_cbo_fins_1"
      Me._cbo_fins_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_fins_1.Size = New System.Drawing.Size(52, 21)
      Me._cbo_fins_1.TabIndex = 202
      Me._cbo_fins_1.Text = "0"
      '
      '_cbo_rows_1
      '
      Me._cbo_rows_1.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_rows_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_rows_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_rows_1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_rows.SetIndex(Me._cbo_rows_1, CType(1, Short))
      Me._cbo_rows_1.Location = New System.Drawing.Point(88, 26)
      Me._cbo_rows_1.Name = "_cbo_rows_1"
      Me._cbo_rows_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_rows_1.Size = New System.Drawing.Size(52, 21)
      Me._cbo_rows_1.TabIndex = 203
      Me._cbo_rows_1.Text = "0"
      '
      '_cbo_coil_type_1
      '
      Me._cbo_coil_type_1.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_coil_type_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_coil_type_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_coil_type_1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_coil_type.SetIndex(Me._cbo_coil_type_1, CType(1, Short))
      Me._cbo_coil_type_1.Location = New System.Drawing.Point(88, 4)
      Me._cbo_coil_type_1.Name = "_cbo_coil_type_1"
      Me._cbo_coil_type_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_coil_type_1.Size = New System.Drawing.Size(97, 21)
      Me._cbo_coil_type_1.TabIndex = 332
      Me._cbo_coil_type_1.Text = "Coil Type"
      '
      '_lbl_num_rows_1
      '
      Me._lbl_num_rows_1.BackColor = System.Drawing.Color.Transparent
      Me._lbl_num_rows_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_num_rows_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_num_rows_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_num_rows.SetIndex(Me._lbl_num_rows_1, CType(1, Short))
      Me._lbl_num_rows_1.Location = New System.Drawing.Point(0, 26)
      Me._lbl_num_rows_1.Name = "_lbl_num_rows_1"
      Me._lbl_num_rows_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_num_rows_1.Size = New System.Drawing.Size(82, 22)
      Me._lbl_num_rows_1.TabIndex = 241
      Me._lbl_num_rows_1.Text = "# of rows"
      Me._lbl_num_rows_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_num_fins_1
      '
      Me._lbl_num_fins_1.BackColor = System.Drawing.Color.Transparent
      Me._lbl_num_fins_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_num_fins_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_num_fins_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_num_fins.SetIndex(Me._lbl_num_fins_1, CType(1, Short))
      Me._lbl_num_fins_1.Location = New System.Drawing.Point(0, 48)
      Me._lbl_num_fins_1.Name = "_lbl_num_fins_1"
      Me._lbl_num_fins_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_num_fins_1.Size = New System.Drawing.Size(82, 22)
      Me._lbl_num_fins_1.TabIndex = 240
      Me._lbl_num_fins_1.Text = "# of fins"
      Me._lbl_num_fins_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_ck_al_1
      '
      Me._ck_al_1.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_al_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_al_1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_al_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_al_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_al.SetIndex(Me._ck_al_1, CType(1, Short))
      Me._ck_al_1.Location = New System.Drawing.Point(88, 70)
      Me._ck_al_1.Name = "_ck_al_1"
      Me._ck_al_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_al_1.Size = New System.Drawing.Size(81, 22)
      Me._ck_al_1.TabIndex = 201
      Me._ck_al_1.Text = "Aluminum"
      Me._ck_al_1.UseVisualStyleBackColor = False
      '
      '_lbl_fin_mtl_1
      '
      Me._lbl_fin_mtl_1.BackColor = System.Drawing.Color.Transparent
      Me._lbl_fin_mtl_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_fin_mtl_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_fin_mtl_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_fin_mtl.SetIndex(Me._lbl_fin_mtl_1, CType(1, Short))
      Me._lbl_fin_mtl_1.Location = New System.Drawing.Point(0, 68)
      Me._lbl_fin_mtl_1.Name = "_lbl_fin_mtl_1"
      Me._lbl_fin_mtl_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_fin_mtl_1.Size = New System.Drawing.Size(82, 22)
      Me._lbl_fin_mtl_1.TabIndex = 243
      Me._lbl_fin_mtl_1.Text = "Fin material"
      Me._lbl_fin_mtl_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_fin_thickness_1
      '
      Me._lbl_fin_thickness_1.BackColor = System.Drawing.Color.Transparent
      Me._lbl_fin_thickness_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_fin_thickness_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_fin_thickness_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_fin_thickness.SetIndex(Me._lbl_fin_thickness_1, CType(1, Short))
      Me._lbl_fin_thickness_1.Location = New System.Drawing.Point(0, 92)
      Me._lbl_fin_thickness_1.Name = "_lbl_fin_thickness_1"
      Me._lbl_fin_thickness_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_fin_thickness_1.Size = New System.Drawing.Size(82, 22)
      Me._lbl_fin_thickness_1.TabIndex = 239
      Me._lbl_fin_thickness_1.Text = "Fin thickness"
      Me._lbl_fin_thickness_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_cbo_fin_thickness_1
      '
      Me._cbo_fin_thickness_1.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_fin_thickness_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_fin_thickness_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_fin_thickness_1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_fin_thickness.SetIndex(Me._cbo_fin_thickness_1, CType(1, Short))
      Me._cbo_fin_thickness_1.Location = New System.Drawing.Point(88, 92)
      Me._cbo_fin_thickness_1.Name = "_cbo_fin_thickness_1"
      Me._cbo_fin_thickness_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_fin_thickness_1.Size = New System.Drawing.Size(81, 21)
      Me._cbo_fin_thickness_1.TabIndex = 199
      Me._cbo_fin_thickness_1.Text = "0"
      '
      '_lbl_tube_thickness_1
      '
      Me._lbl_tube_thickness_1.BackColor = System.Drawing.Color.Transparent
      Me._lbl_tube_thickness_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_tube_thickness_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_tube_thickness_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_tube_thickness.SetIndex(Me._lbl_tube_thickness_1, CType(1, Short))
      Me._lbl_tube_thickness_1.Location = New System.Drawing.Point(0, 114)
      Me._lbl_tube_thickness_1.Name = "_lbl_tube_thickness_1"
      Me._lbl_tube_thickness_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_tube_thickness_1.Size = New System.Drawing.Size(82, 22)
      Me._lbl_tube_thickness_1.TabIndex = 238
      Me._lbl_tube_thickness_1.Text = "Tube thickness"
      Me._lbl_tube_thickness_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_cbo_tube_thickness_1
      '
      Me._cbo_tube_thickness_1.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_tube_thickness_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_tube_thickness_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_tube_thickness_1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_tube_thickness.SetIndex(Me._cbo_tube_thickness_1, CType(1, Short))
      Me._cbo_tube_thickness_1.Location = New System.Drawing.Point(88, 114)
      Me._cbo_tube_thickness_1.Name = "_cbo_tube_thickness_1"
      Me._cbo_tube_thickness_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_tube_thickness_1.Size = New System.Drawing.Size(81, 21)
      Me._cbo_tube_thickness_1.TabIndex = 196
      Me._cbo_tube_thickness_1.Text = "0"
      '
      '_lbl_casing_1
      '
      Me._lbl_casing_1.BackColor = System.Drawing.Color.Transparent
      Me._lbl_casing_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_casing_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_casing_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_casing.SetIndex(Me._lbl_casing_1, CType(1, Short))
      Me._lbl_casing_1.Location = New System.Drawing.Point(0, 134)
      Me._lbl_casing_1.Name = "_lbl_casing_1"
      Me._lbl_casing_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_casing_1.Size = New System.Drawing.Size(82, 22)
      Me._lbl_casing_1.TabIndex = 242
      Me._lbl_casing_1.Text = "Casing"
      Me._lbl_casing_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_ck_ss_1
      '
      Me._ck_ss_1.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_ss_1.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_ss_1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_ss_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_ss_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_ss.SetIndex(Me._ck_ss_1, CType(1, Short))
      Me._ck_ss_1.Location = New System.Drawing.Point(88, 134)
      Me._ck_ss_1.Name = "_ck_ss_1"
      Me._ck_ss_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_ss_1.Size = New System.Drawing.Size(105, 22)
      Me._ck_ss_1.TabIndex = 336
      Me._ck_ss_1.Text = "Stainless steel"
      Me._ck_ss_1.UseVisualStyleBackColor = False
      '
      'panCoil1Container
      '
      Me.panCoil1Container.Controls.Add(Me._lbl_coil_cost_0)
      Me.panCoil1Container.Controls.Add(Me.lblCoil1OrderIndex)
      Me.panCoil1Container.Controls.Add(Me.panCoil1)
      Me.panCoil1Container.Controls.Add(Me._lbl_coil_type_0)
      Me.panCoil1Container.Location = New System.Drawing.Point(20, 20)
      Me.panCoil1Container.Name = "panCoil1Container"
      Me.panCoil1Container.Size = New System.Drawing.Size(226, 204)
      Me.panCoil1Container.TabIndex = 339
      Me.panCoil1Container.Visible = False
      '
      '_lbl_coil_cost_0
      '
      Me._lbl_coil_cost_0.BackColor = System.Drawing.Color.DarkGray
      Me._lbl_coil_cost_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_coil_cost_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_coil_cost_0.ForeColor = System.Drawing.Color.Blue
      Me.lbl_coil_cost.SetIndex(Me._lbl_coil_cost_0, CType(0, Short))
      Me._lbl_coil_cost_0.Location = New System.Drawing.Point(63, 2)
      Me._lbl_coil_cost_0.Name = "_lbl_coil_cost_0"
      Me._lbl_coil_cost_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_coil_cost_0.Size = New System.Drawing.Size(128, 18)
      Me._lbl_coil_cost_0.TabIndex = 216
      Me._lbl_coil_cost_0.Text = "0"
      Me._lbl_coil_cost_0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCoil1OrderIndex
      '
      Me.lblCoil1OrderIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblCoil1OrderIndex.Location = New System.Drawing.Point(192, 0)
      Me.lblCoil1OrderIndex.Name = "lblCoil1OrderIndex"
      Me.lblCoil1OrderIndex.Size = New System.Drawing.Size(28, 23)
      Me.lblCoil1OrderIndex.TabIndex = 341
      Me.lblCoil1OrderIndex.Text = "-1"
      Me.lblCoil1OrderIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'panCoil1
      '
      Me.panCoil1.BackColor = System.Drawing.Color.WhiteSmoke
      Me.panCoil1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.panCoil1.Controls.Add(Me._ck_cu_0)
      Me.panCoil1.Controls.Add(Me.lblCoilCasing1)
      Me.panCoil1.Controls.Add(Me.lblFinMaterial1)
      Me.panCoil1.Controls.Add(Me.lblCoil1Type)
      Me.panCoil1.Controls.Add(Me._lbl_fin_thickness_0)
      Me.panCoil1.Controls.Add(Me._cbo_fins_0)
      Me.panCoil1.Controls.Add(Me._cbo_rows_0)
      Me.panCoil1.Controls.Add(Me._lbl_num_rows_0)
      Me.panCoil1.Controls.Add(Me._lbl_num_fins_0)
      Me.panCoil1.Controls.Add(Me._cbo_coil_type_0)
      Me.panCoil1.Controls.Add(Me._lbl_fin_mtl_0)
      Me.panCoil1.Controls.Add(Me._ck_al_0)
      Me.panCoil1.Controls.Add(Me._cbo_fin_thickness_0)
      Me.panCoil1.Controls.Add(Me._lbl_tube_thickness_0)
      Me.panCoil1.Controls.Add(Me._cbo_tube_thickness_0)
      Me.panCoil1.Controls.Add(Me._ck_gal_0)
      Me.panCoil1.Controls.Add(Me._ck_ss_0)
      Me.panCoil1.Controls.Add(Me._lbl_casing_0)
      Me.panCoil1.Location = New System.Drawing.Point(0, 22)
      Me.panCoil1.Name = "panCoil1"
      Me.panCoil1.Size = New System.Drawing.Size(220, 178)
      Me.panCoil1.TabIndex = 332
      '
      '_ck_cu_0
      '
      Me._ck_cu_0.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_cu_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_cu_0.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_cu_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_cu_0.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_cu.SetIndex(Me._ck_cu_0, CType(0, Short))
      Me._ck_cu_0.Location = New System.Drawing.Point(160, 70)
      Me._ck_cu_0.Name = "_ck_cu_0"
      Me._ck_cu_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_cu_0.Size = New System.Drawing.Size(66, 22)
      Me._ck_cu_0.TabIndex = 208
      Me._ck_cu_0.Text = "Copper"
      Me._ck_cu_0.UseVisualStyleBackColor = False
      '
      'lblCoilCasing1
      '
      Me.lblCoilCasing1.BackColor = System.Drawing.Color.Yellow
      Me.lblCoilCasing1.Location = New System.Drawing.Point(220, 118)
      Me.lblCoilCasing1.Name = "lblCoilCasing1"
      Me.lblCoilCasing1.Size = New System.Drawing.Size(100, 23)
      Me.lblCoilCasing1.TabIndex = 334
      Me.lblCoilCasing1.Text = "Label32"
      '
      'lblFinMaterial1
      '
      Me.lblFinMaterial1.BackColor = System.Drawing.Color.Yellow
      Me.lblFinMaterial1.Location = New System.Drawing.Point(4, 178)
      Me.lblFinMaterial1.Name = "lblFinMaterial1"
      Me.lblFinMaterial1.Size = New System.Drawing.Size(70, 23)
      Me.lblFinMaterial1.TabIndex = 333
      Me.lblFinMaterial1.Text = "Label32"
      '
      'lblCoil1Type
      '
      Me.lblCoil1Type.Location = New System.Drawing.Point(2, 4)
      Me.lblCoil1Type.Name = "lblCoil1Type"
      Me.lblCoil1Type.Size = New System.Drawing.Size(80, 23)
      Me.lblCoil1Type.TabIndex = 332
      Me.lblCoil1Type.Text = "Type"
      Me.lblCoil1Type.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_fin_thickness_0
      '
      Me._lbl_fin_thickness_0.BackColor = System.Drawing.Color.Transparent
      Me._lbl_fin_thickness_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_fin_thickness_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_fin_thickness_0.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_fin_thickness.SetIndex(Me._lbl_fin_thickness_0, CType(0, Short))
      Me._lbl_fin_thickness_0.Location = New System.Drawing.Point(0, 92)
      Me._lbl_fin_thickness_0.Name = "_lbl_fin_thickness_0"
      Me._lbl_fin_thickness_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_fin_thickness_0.Size = New System.Drawing.Size(82, 22)
      Me._lbl_fin_thickness_0.TabIndex = 246
      Me._lbl_fin_thickness_0.Text = "Fin thickness"
      Me._lbl_fin_thickness_0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_cbo_fins_0
      '
      Me._cbo_fins_0.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_fins_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_fins_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_fins_0.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_fins.SetIndex(Me._cbo_fins_0, CType(0, Short))
      Me._cbo_fins_0.Location = New System.Drawing.Point(88, 48)
      Me._cbo_fins_0.Name = "_cbo_fins_0"
      Me._cbo_fins_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_fins_0.Size = New System.Drawing.Size(52, 21)
      Me._cbo_fins_0.TabIndex = 210
      Me._cbo_fins_0.Text = "0"
      '
      '_cbo_rows_0
      '
      Me._cbo_rows_0.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_rows_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_rows_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_rows_0.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_rows.SetIndex(Me._cbo_rows_0, CType(0, Short))
      Me._cbo_rows_0.Location = New System.Drawing.Point(88, 26)
      Me._cbo_rows_0.Name = "_cbo_rows_0"
      Me._cbo_rows_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_rows_0.Size = New System.Drawing.Size(52, 21)
      Me._cbo_rows_0.TabIndex = 211
      Me._cbo_rows_0.Text = "0"
      '
      '_lbl_num_rows_0
      '
      Me._lbl_num_rows_0.BackColor = System.Drawing.Color.Transparent
      Me._lbl_num_rows_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_num_rows_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_num_rows_0.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_num_rows.SetIndex(Me._lbl_num_rows_0, CType(0, Short))
      Me._lbl_num_rows_0.Location = New System.Drawing.Point(0, 28)
      Me._lbl_num_rows_0.Name = "_lbl_num_rows_0"
      Me._lbl_num_rows_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_num_rows_0.Size = New System.Drawing.Size(82, 22)
      Me._lbl_num_rows_0.TabIndex = 248
      Me._lbl_num_rows_0.Text = "# of rows"
      Me._lbl_num_rows_0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_num_fins_0
      '
      Me._lbl_num_fins_0.BackColor = System.Drawing.Color.Transparent
      Me._lbl_num_fins_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_num_fins_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_num_fins_0.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_num_fins.SetIndex(Me._lbl_num_fins_0, CType(0, Short))
      Me._lbl_num_fins_0.Location = New System.Drawing.Point(0, 50)
      Me._lbl_num_fins_0.Name = "_lbl_num_fins_0"
      Me._lbl_num_fins_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_num_fins_0.Size = New System.Drawing.Size(82, 22)
      Me._lbl_num_fins_0.TabIndex = 247
      Me._lbl_num_fins_0.Text = "# of fins"
      Me._lbl_num_fins_0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_cbo_coil_type_0
      '
      Me._cbo_coil_type_0.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_coil_type_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_coil_type_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_coil_type_0.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_coil_type.SetIndex(Me._cbo_coil_type_0, CType(0, Short))
      Me._cbo_coil_type_0.Location = New System.Drawing.Point(88, 4)
      Me._cbo_coil_type_0.Name = "_cbo_coil_type_0"
      Me._cbo_coil_type_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_coil_type_0.Size = New System.Drawing.Size(94, 21)
      Me._cbo_coil_type_0.TabIndex = 331
      Me._cbo_coil_type_0.TabStop = False
      Me._cbo_coil_type_0.Text = "Coil Type"
      '
      '_lbl_fin_mtl_0
      '
      Me._lbl_fin_mtl_0.BackColor = System.Drawing.Color.Transparent
      Me._lbl_fin_mtl_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_fin_mtl_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_fin_mtl_0.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_fin_mtl.SetIndex(Me._lbl_fin_mtl_0, CType(0, Short))
      Me._lbl_fin_mtl_0.Location = New System.Drawing.Point(0, 70)
      Me._lbl_fin_mtl_0.Name = "_lbl_fin_mtl_0"
      Me._lbl_fin_mtl_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_fin_mtl_0.Size = New System.Drawing.Size(82, 23)
      Me._lbl_fin_mtl_0.TabIndex = 250
      Me._lbl_fin_mtl_0.Text = " Fin material"
      Me._lbl_fin_mtl_0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_ck_al_0
      '
      Me._ck_al_0.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_al_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_al_0.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_al_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_al_0.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_al.SetIndex(Me._ck_al_0, CType(0, Short))
      Me._ck_al_0.Location = New System.Drawing.Point(88, 70)
      Me._ck_al_0.Name = "_ck_al_0"
      Me._ck_al_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_al_0.Size = New System.Drawing.Size(72, 22)
      Me._ck_al_0.TabIndex = 209
      Me._ck_al_0.Text = "Aluminum"
      Me._ck_al_0.UseVisualStyleBackColor = False
      '
      '_cbo_fin_thickness_0
      '
      Me._cbo_fin_thickness_0.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_fin_thickness_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_fin_thickness_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_fin_thickness_0.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_fin_thickness.SetIndex(Me._cbo_fin_thickness_0, CType(0, Short))
      Me._cbo_fin_thickness_0.Location = New System.Drawing.Point(88, 92)
      Me._cbo_fin_thickness_0.Name = "_cbo_fin_thickness_0"
      Me._cbo_fin_thickness_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_fin_thickness_0.Size = New System.Drawing.Size(81, 21)
      Me._cbo_fin_thickness_0.TabIndex = 207
      Me._cbo_fin_thickness_0.Text = "0"
      '
      '_lbl_tube_thickness_0
      '
      Me._lbl_tube_thickness_0.BackColor = System.Drawing.Color.Transparent
      Me._lbl_tube_thickness_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_tube_thickness_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_tube_thickness_0.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_tube_thickness.SetIndex(Me._lbl_tube_thickness_0, CType(0, Short))
      Me._lbl_tube_thickness_0.Location = New System.Drawing.Point(0, 114)
      Me._lbl_tube_thickness_0.Name = "_lbl_tube_thickness_0"
      Me._lbl_tube_thickness_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_tube_thickness_0.Size = New System.Drawing.Size(82, 22)
      Me._lbl_tube_thickness_0.TabIndex = 245
      Me._lbl_tube_thickness_0.Text = "Tube thickness"
      Me._lbl_tube_thickness_0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_cbo_tube_thickness_0
      '
      Me._cbo_tube_thickness_0.BackColor = System.Drawing.SystemColors.Window
      Me._cbo_tube_thickness_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._cbo_tube_thickness_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._cbo_tube_thickness_0.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_tube_thickness.SetIndex(Me._cbo_tube_thickness_0, CType(0, Short))
      Me._cbo_tube_thickness_0.Location = New System.Drawing.Point(88, 114)
      Me._cbo_tube_thickness_0.Name = "_cbo_tube_thickness_0"
      Me._cbo_tube_thickness_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._cbo_tube_thickness_0.Size = New System.Drawing.Size(81, 21)
      Me._cbo_tube_thickness_0.TabIndex = 204
      Me._cbo_tube_thickness_0.Text = "0"
      '
      '_ck_gal_0
      '
      Me._ck_gal_0.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_gal_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_gal_0.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_gal_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_gal_0.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_gal.SetIndex(Me._ck_gal_0, CType(0, Short))
      Me._ck_gal_0.Location = New System.Drawing.Point(88, 152)
      Me._ck_gal_0.Name = "_ck_gal_0"
      Me._ck_gal_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_gal_0.Size = New System.Drawing.Size(105, 22)
      Me._ck_gal_0.TabIndex = 205
      Me._ck_gal_0.Text = "Galvanized steel"
      Me._ck_gal_0.UseVisualStyleBackColor = False
      '
      '_ck_ss_0
      '
      Me._ck_ss_0.BackColor = System.Drawing.Color.WhiteSmoke
      Me._ck_ss_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._ck_ss_0.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._ck_ss_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._ck_ss_0.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_ss.SetIndex(Me._ck_ss_0, CType(0, Short))
      Me._ck_ss_0.Location = New System.Drawing.Point(88, 134)
      Me._ck_ss_0.Name = "_ck_ss_0"
      Me._ck_ss_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._ck_ss_0.Size = New System.Drawing.Size(105, 22)
      Me._ck_ss_0.TabIndex = 206
      Me._ck_ss_0.Text = "Stainless steel"
      Me._ck_ss_0.UseVisualStyleBackColor = False
      '
      '_lbl_casing_0
      '
      Me._lbl_casing_0.BackColor = System.Drawing.Color.Transparent
      Me._lbl_casing_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_casing_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_casing_0.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_casing.SetIndex(Me._lbl_casing_0, CType(0, Short))
      Me._lbl_casing_0.Location = New System.Drawing.Point(0, 134)
      Me._lbl_casing_0.Name = "_lbl_casing_0"
      Me._lbl_casing_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_casing_0.Size = New System.Drawing.Size(82, 22)
      Me._lbl_casing_0.TabIndex = 249
      Me._lbl_casing_0.Text = "Casing"
      Me._lbl_casing_0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_lbl_coil_type_0
      '
      Me._lbl_coil_type_0.BackColor = System.Drawing.Color.DarkGray
      Me._lbl_coil_type_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._lbl_coil_type_0.Cursor = System.Windows.Forms.Cursors.Default
      Me._lbl_coil_type_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lbl_coil_type_0.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_coil_type.SetIndex(Me._lbl_coil_type_0, CType(0, Short))
      Me._lbl_coil_type_0.Location = New System.Drawing.Point(0, 0)
      Me._lbl_coil_type_0.Name = "_lbl_coil_type_0"
      Me._lbl_coil_type_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._lbl_coil_type_0.Size = New System.Drawing.Size(192, 23)
      Me._lbl_coil_type_0.TabIndex = 251
      Me._lbl_coil_type_0.Text = "Coil Type"
      Me._lbl_coil_type_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'panC3Container
      '
      Me.panC3Container.Controls.Add(Me.lblC3OrderIndex)
      Me.panC3Container.Controls.Add(Me.lbl_heater_cost)
      Me.panC3Container.Controls.Add(Me.panC3)
      Me.panC3Container.Controls.Add(Me.lbl_C3)
      Me.panC3Container.Location = New System.Drawing.Point(480, 20)
      Me.panC3Container.Name = "panC3Container"
      Me.panC3Container.Size = New System.Drawing.Size(228, 202)
      Me.panC3Container.TabIndex = 342
      Me.panC3Container.Visible = False
      '
      'lblC3OrderIndex
      '
      Me.lblC3OrderIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblC3OrderIndex.Location = New System.Drawing.Point(188, 0)
      Me.lblC3OrderIndex.Name = "lblC3OrderIndex"
      Me.lblC3OrderIndex.Size = New System.Drawing.Size(28, 23)
      Me.lblC3OrderIndex.TabIndex = 343
      Me.lblC3OrderIndex.Text = "-1"
      Me.lblC3OrderIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lbl_heater_cost
      '
      Me.lbl_heater_cost.BackColor = System.Drawing.Color.DarkGray
      Me.lbl_heater_cost.Cursor = System.Windows.Forms.Cursors.Default
      Me.lbl_heater_cost.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lbl_heater_cost.ForeColor = System.Drawing.Color.Blue
      Me.lbl_heater_cost.Location = New System.Drawing.Point(110, 2)
      Me.lbl_heater_cost.Name = "lbl_heater_cost"
      Me.lbl_heater_cost.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lbl_heater_cost.Size = New System.Drawing.Size(72, 18)
      Me.lbl_heater_cost.TabIndex = 159
      Me.lbl_heater_cost.Text = "0"
      Me.lbl_heater_cost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.lbl_heater_cost.Visible = False
      '
      'panC3
      '
      Me.panC3.BackColor = System.Drawing.Color.WhiteSmoke
      Me.panC3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.panC3.Controls.Add(Me.Label33)
      Me.panC3.Controls.Add(Me.lbl_C3_kw)
      Me.panC3.Controls.Add(Me.cbo_C3_kw)
      Me.panC3.Controls.Add(Me.lbl_C3_min_stages)
      Me.panC3.Controls.Add(Me.lbl_C3_op_temp)
      Me.panC3.Controls.Add(Me.lbl_C3_op_temp_1)
      Me.panC3.Controls.Add(Me.ck_C3_scr)
      Me.panC3.Controls.Add(Me.ck_C3_disconnect)
      Me.panC3.Controls.Add(Me.lbl_C3_min_stages_val)
      Me.panC3.Controls.Add(Me.lbl_C3_extra_stages)
      Me.panC3.Controls.Add(Me.cbo_C3_extra_stages)
      Me.panC3.Location = New System.Drawing.Point(0, 22)
      Me.panC3.Name = "panC3"
      Me.panC3.Size = New System.Drawing.Size(216, 177)
      Me.panC3.TabIndex = 68
      '
      'Label33
      '
      Me.Label33.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label33.Location = New System.Drawing.Point(6, 2)
      Me.Label33.Name = "Label33"
      Me.Label33.Size = New System.Drawing.Size(170, 23)
      Me.Label33.TabIndex = 63
      Me.Label33.Text = "Open Element Duct Heater"
      Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lbl_C3_kw
      '
      Me.lbl_C3_kw.BackColor = System.Drawing.Color.Transparent
      Me.lbl_C3_kw.Cursor = System.Windows.Forms.Cursors.Default
      Me.lbl_C3_kw.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lbl_C3_kw.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_C3_kw.Location = New System.Drawing.Point(2, 24)
      Me.lbl_C3_kw.Name = "lbl_C3_kw"
      Me.lbl_C3_kw.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lbl_C3_kw.Size = New System.Drawing.Size(124, 22)
      Me.lbl_C3_kw.TabIndex = 62
      Me.lbl_C3_kw.Text = "KW"
      Me.lbl_C3_kw.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cbo_C3_kw
      '
      Me.cbo_C3_kw.BackColor = System.Drawing.SystemColors.Window
      Me.cbo_C3_kw.Cursor = System.Windows.Forms.Cursors.Default
      Me.cbo_C3_kw.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cbo_C3_kw.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_C3_kw.Location = New System.Drawing.Point(132, 26)
      Me.cbo_C3_kw.Name = "cbo_C3_kw"
      Me.cbo_C3_kw.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.cbo_C3_kw.Size = New System.Drawing.Size(66, 21)
      Me.cbo_C3_kw.TabIndex = 15
      Me.cbo_C3_kw.Text = "0"
      '
      'lbl_C3_min_stages
      '
      Me.lbl_C3_min_stages.BackColor = System.Drawing.Color.Transparent
      Me.lbl_C3_min_stages.Cursor = System.Windows.Forms.Cursors.Default
      Me.lbl_C3_min_stages.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lbl_C3_min_stages.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_C3_min_stages.Location = New System.Drawing.Point(2, 50)
      Me.lbl_C3_min_stages.Name = "lbl_C3_min_stages"
      Me.lbl_C3_min_stages.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lbl_C3_min_stages.Size = New System.Drawing.Size(124, 22)
      Me.lbl_C3_min_stages.TabIndex = 61
      Me.lbl_C3_min_stages.Text = "Minimum # of stages"
      Me.lbl_C3_min_stages.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lbl_C3_op_temp
      '
      Me.lbl_C3_op_temp.BackColor = System.Drawing.Color.Transparent
      Me.lbl_C3_op_temp.Cursor = System.Windows.Forms.Cursors.Default
      Me.lbl_C3_op_temp.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lbl_C3_op_temp.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_C3_op_temp.Location = New System.Drawing.Point(2, 74)
      Me.lbl_C3_op_temp.Name = "lbl_C3_op_temp"
      Me.lbl_C3_op_temp.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lbl_C3_op_temp.Size = New System.Drawing.Size(124, 32)
      Me.lbl_C3_op_temp.TabIndex = 59
      Me.lbl_C3_op_temp.Text = "Operating  temperature difference"
      Me.lbl_C3_op_temp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lbl_C3_op_temp_1
      '
      Me.lbl_C3_op_temp_1.BackColor = System.Drawing.Color.Transparent
      Me.lbl_C3_op_temp_1.Cursor = System.Windows.Forms.Cursors.Default
      Me.lbl_C3_op_temp_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lbl_C3_op_temp_1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_C3_op_temp_1.Location = New System.Drawing.Point(132, 74)
      Me.lbl_C3_op_temp_1.Name = "lbl_C3_op_temp_1"
      Me.lbl_C3_op_temp_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lbl_C3_op_temp_1.Size = New System.Drawing.Size(66, 32)
      Me.lbl_C3_op_temp_1.TabIndex = 58
      Me.lbl_C3_op_temp_1.Text = "0"
      Me.lbl_C3_op_temp_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'ck_C3_scr
      '
      Me.ck_C3_scr.BackColor = System.Drawing.Color.WhiteSmoke
      Me.ck_C3_scr.Cursor = System.Windows.Forms.Cursors.Default
      Me.ck_C3_scr.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ck_C3_scr.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ck_C3_scr.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_C3_scr.Location = New System.Drawing.Point(132, 124)
      Me.ck_C3_scr.Name = "ck_C3_scr"
      Me.ck_C3_scr.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.ck_C3_scr.Size = New System.Drawing.Size(78, 22)
      Me.ck_C3_scr.TabIndex = 17
      Me.ck_C3_scr.Text = "SCR"
      Me.ck_C3_scr.UseVisualStyleBackColor = False
      '
      'ck_C3_disconnect
      '
      Me.ck_C3_disconnect.BackColor = System.Drawing.Color.WhiteSmoke
      Me.ck_C3_disconnect.Cursor = System.Windows.Forms.Cursors.Default
      Me.ck_C3_disconnect.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ck_C3_disconnect.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ck_C3_disconnect.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_C3_disconnect.Location = New System.Drawing.Point(132, 106)
      Me.ck_C3_disconnect.Name = "ck_C3_disconnect"
      Me.ck_C3_disconnect.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.ck_C3_disconnect.Size = New System.Drawing.Size(78, 22)
      Me.ck_C3_disconnect.TabIndex = 16
      Me.ck_C3_disconnect.Text = "Disconnect"
      Me.ck_C3_disconnect.UseVisualStyleBackColor = False
      '
      'lbl_C3_min_stages_val
      '
      Me.lbl_C3_min_stages_val.BackColor = System.Drawing.Color.Transparent
      Me.lbl_C3_min_stages_val.Cursor = System.Windows.Forms.Cursors.Default
      Me.lbl_C3_min_stages_val.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lbl_C3_min_stages_val.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_C3_min_stages_val.Location = New System.Drawing.Point(132, 50)
      Me.lbl_C3_min_stages_val.Name = "lbl_C3_min_stages_val"
      Me.lbl_C3_min_stages_val.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lbl_C3_min_stages_val.Size = New System.Drawing.Size(66, 22)
      Me.lbl_C3_min_stages_val.TabIndex = 60
      Me.lbl_C3_min_stages_val.Text = "0"
      Me.lbl_C3_min_stages_val.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lbl_C3_extra_stages
      '
      Me.lbl_C3_extra_stages.BackColor = System.Drawing.Color.Transparent
      Me.lbl_C3_extra_stages.Cursor = System.Windows.Forms.Cursors.Default
      Me.lbl_C3_extra_stages.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lbl_C3_extra_stages.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_C3_extra_stages.Location = New System.Drawing.Point(2, 146)
      Me.lbl_C3_extra_stages.Name = "lbl_C3_extra_stages"
      Me.lbl_C3_extra_stages.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lbl_C3_extra_stages.Size = New System.Drawing.Size(124, 22)
      Me.lbl_C3_extra_stages.TabIndex = 57
      Me.lbl_C3_extra_stages.Text = "Extra stages"
      Me.lbl_C3_extra_stages.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cbo_C3_extra_stages
      '
      Me.cbo_C3_extra_stages.BackColor = System.Drawing.SystemColors.Window
      Me.cbo_C3_extra_stages.Cursor = System.Windows.Forms.Cursors.Default
      Me.cbo_C3_extra_stages.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cbo_C3_extra_stages.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cbo_C3_extra_stages.Location = New System.Drawing.Point(132, 148)
      Me.cbo_C3_extra_stages.Name = "cbo_C3_extra_stages"
      Me.cbo_C3_extra_stages.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.cbo_C3_extra_stages.Size = New System.Drawing.Size(52, 21)
      Me.cbo_C3_extra_stages.TabIndex = 18
      Me.cbo_C3_extra_stages.Text = "0"
      '
      'lbl_C3
      '
      Me.lbl_C3.BackColor = System.Drawing.Color.DarkGray
      Me.lbl_C3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lbl_C3.Cursor = System.Windows.Forms.Cursors.Default
      Me.lbl_C3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lbl_C3.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_C3.Location = New System.Drawing.Point(0, 0)
      Me.lbl_C3.Name = "lbl_C3"
      Me.lbl_C3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lbl_C3.Size = New System.Drawing.Size(202, 23)
      Me.lbl_C3.TabIndex = 67
      Me.lbl_C3.Text = " C3"
      Me.lbl_C3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_SSTab2_TabPage5
      '
      Me._SSTab2_TabPage5.BackColor = System.Drawing.SystemColors.ControlLightLight
      Me._SSTab2_TabPage5.Controls.Add(Me.panDischargeContainer)
      Me._SSTab2_TabPage5.Controls.Add(Me.lbl_base)
      Me._SSTab2_TabPage5.Controls.Add(Me.Panel10)
      Me._SSTab2_TabPage5.Controls.Add(Me.Panel9)
      Me._SSTab2_TabPage5.Controls.Add(Me.panSectionsSummaryHeader)
      Me._SSTab2_TabPage5.Controls.Add(Me.Panel8)
      Me._SSTab2_TabPage5.Controls.Add(Me.panSectionQuantities)
      Me._SSTab2_TabPage5.Controls.Add(Me.lbl_ATT_sound_att)
      Me._SSTab2_TabPage5.Controls.Add(Me.ck_ATT_5)
      Me._SSTab2_TabPage5.Controls.Add(Me.ck_ATT_4)
      Me._SSTab2_TabPage5.Controls.Add(Me.ck_ATT_3)
      Me._SSTab2_TabPage5.Controls.Add(Me.ck_ATT)
      Me._SSTab2_TabPage5.Location = New System.Drawing.Point(4, 22)
      Me._SSTab2_TabPage5.Name = "_SSTab2_TabPage5"
      Me._SSTab2_TabPage5.Size = New System.Drawing.Size(716, 420)
      Me._SSTab2_TabPage5.TabIndex = 5
      Me._SSTab2_TabPage5.Text = "Other"
      '
      'panDischargeContainer
      '
      Me.panDischargeContainer.Controls.Add(Me.lblDischargeLocationChkValue)
      Me.panDischargeContainer.Controls.Add(Me.lblDischargeOrderIndex)
      Me.panDischargeContainer.Controls.Add(Me.lblGratingCost)
      Me.panDischargeContainer.Controls.Add(Me.lbl_discharge)
      Me.panDischargeContainer.Controls.Add(Me.Panel11)
      Me.panDischargeContainer.Controls.Add(Me.lbl_D1_grating_cost)
      Me.panDischargeContainer.Location = New System.Drawing.Point(500, 20)
      Me.panDischargeContainer.Name = "panDischargeContainer"
      Me.panDischargeContainer.Size = New System.Drawing.Size(198, 186)
      Me.panDischargeContainer.TabIndex = 374
      Me.panDischargeContainer.Visible = False
      '
      'lblDischargeLocationChkValue
      '
      Me.lblDischargeLocationChkValue.BackColor = System.Drawing.Color.Yellow
      Me.lblDischargeLocationChkValue.Location = New System.Drawing.Point(28, 186)
      Me.lblDischargeLocationChkValue.Name = "lblDischargeLocationChkValue"
      Me.lblDischargeLocationChkValue.Size = New System.Drawing.Size(100, 23)
      Me.lblDischargeLocationChkValue.TabIndex = 376
      Me.lblDischargeLocationChkValue.Text = "Label32"
      '
      'lblDischargeOrderIndex
      '
      Me.lblDischargeOrderIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblDischargeOrderIndex.Location = New System.Drawing.Point(162, 0)
      Me.lblDischargeOrderIndex.Name = "lblDischargeOrderIndex"
      Me.lblDischargeOrderIndex.Size = New System.Drawing.Size(28, 23)
      Me.lblDischargeOrderIndex.TabIndex = 375
      Me.lblDischargeOrderIndex.Text = "-1"
      Me.lblDischargeOrderIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblGratingCost
      '
      Me.lblGratingCost.ForeColor = System.Drawing.Color.Blue
      Me.lblGratingCost.Location = New System.Drawing.Point(4, 130)
      Me.lblGratingCost.Name = "lblGratingCost"
      Me.lblGratingCost.Size = New System.Drawing.Size(70, 23)
      Me.lblGratingCost.TabIndex = 374
      Me.lblGratingCost.Text = "Grating cost"
      Me.lblGratingCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lbl_discharge
      '
      Me.lbl_discharge.BackColor = System.Drawing.Color.DarkGray
      Me.lbl_discharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lbl_discharge.Cursor = System.Windows.Forms.Cursors.Default
      Me.lbl_discharge.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lbl_discharge.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_discharge.Location = New System.Drawing.Point(0, 0)
      Me.lbl_discharge.Name = "lbl_discharge"
      Me.lbl_discharge.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lbl_discharge.Size = New System.Drawing.Size(190, 23)
      Me.lbl_discharge.TabIndex = 51
      Me.lbl_discharge.Text = " Discharge (D1)"
      Me.lbl_discharge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Panel11
      '
      Me.Panel11.BackColor = System.Drawing.Color.WhiteSmoke
      Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Panel11.Controls.Add(Me.lblDischargeLocation)
      Me.Panel11.Controls.Add(Me.Panel12)
      Me.Panel11.Controls.Add(Me.ck_D1_grating)
      Me.Panel11.Location = New System.Drawing.Point(0, 22)
      Me.Panel11.Name = "Panel11"
      Me.Panel11.Size = New System.Drawing.Size(190, 108)
      Me.Panel11.TabIndex = 373
      '
      'lblDischargeLocation
      '
      Me.lblDischargeLocation.Location = New System.Drawing.Point(0, 4)
      Me.lblDischargeLocation.Name = "lblDischargeLocation"
      Me.lblDischargeLocation.Size = New System.Drawing.Size(56, 23)
      Me.lblDischargeLocation.TabIndex = 38
      Me.lblDischargeLocation.Text = "Location"
      Me.lblDischargeLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Panel12
      '
      Me.Panel12.Controls.Add(Me.radD1Floor)
      Me.Panel12.Controls.Add(Me.radD1EndWall)
      Me.Panel12.Controls.Add(Me.radD1Ceiling)
      Me.Panel12.Location = New System.Drawing.Point(56, 2)
      Me.Panel12.Name = "Panel12"
      Me.Panel12.Size = New System.Drawing.Size(132, 76)
      Me.Panel12.TabIndex = 375
      '
      'radD1Floor
      '
      Me.radD1Floor.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.radD1Floor.Location = New System.Drawing.Point(6, 52)
      Me.radD1Floor.Name = "radD1Floor"
      Me.radD1Floor.Size = New System.Drawing.Size(122, 24)
      Me.radD1Floor.TabIndex = 2
      Me.radD1Floor.Text = "Floor discharge"
      '
      'radD1EndWall
      '
      Me.radD1EndWall.Checked = True
      Me.radD1EndWall.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.radD1EndWall.Location = New System.Drawing.Point(6, 28)
      Me.radD1EndWall.Name = "radD1EndWall"
      Me.radD1EndWall.Size = New System.Drawing.Size(122, 24)
      Me.radD1EndWall.TabIndex = 1
      Me.radD1EndWall.TabStop = True
      Me.radD1EndWall.Text = "End wall discharge"
      '
      'radD1Ceiling
      '
      Me.radD1Ceiling.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.radD1Ceiling.Location = New System.Drawing.Point(6, 4)
      Me.radD1Ceiling.Name = "radD1Ceiling"
      Me.radD1Ceiling.Size = New System.Drawing.Size(120, 24)
      Me.radD1Ceiling.TabIndex = 0
      Me.radD1Ceiling.Text = "Ceiling discharge"
      '
      'ck_D1_grating
      '
      Me.ck_D1_grating.BackColor = System.Drawing.Color.WhiteSmoke
      Me.ck_D1_grating.Cursor = System.Windows.Forms.Cursors.Default
      Me.ck_D1_grating.Enabled = False
      Me.ck_D1_grating.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ck_D1_grating.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ck_D1_grating.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_D1_grating.Location = New System.Drawing.Point(92, 80)
      Me.ck_D1_grating.Name = "ck_D1_grating"
      Me.ck_D1_grating.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.ck_D1_grating.Size = New System.Drawing.Size(60, 22)
      Me.ck_D1_grating.TabIndex = 37
      Me.ck_D1_grating.Text = "Grating"
      Me.ck_D1_grating.UseVisualStyleBackColor = False
      '
      'lbl_D1_grating_cost
      '
      Me.lbl_D1_grating_cost.BackColor = System.Drawing.SystemColors.ControlLightLight
      Me.lbl_D1_grating_cost.Cursor = System.Windows.Forms.Cursors.Default
      Me.lbl_D1_grating_cost.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lbl_D1_grating_cost.ForeColor = System.Drawing.Color.Blue
      Me.lbl_D1_grating_cost.Location = New System.Drawing.Point(80, 130)
      Me.lbl_D1_grating_cost.Name = "lbl_D1_grating_cost"
      Me.lbl_D1_grating_cost.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lbl_D1_grating_cost.Size = New System.Drawing.Size(76, 22)
      Me.lbl_D1_grating_cost.TabIndex = 169
      Me.lbl_D1_grating_cost.Text = "0"
      Me.lbl_D1_grating_cost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.lbl_D1_grating_cost.Visible = False
      '
      'lbl_base
      '
      Me.lbl_base.BackColor = System.Drawing.Color.DarkGray
      Me.lbl_base.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lbl_base.Cursor = System.Windows.Forms.Cursors.Default
      Me.lbl_base.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lbl_base.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_base.Location = New System.Drawing.Point(274, 20)
      Me.lbl_base.Name = "lbl_base"
      Me.lbl_base.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lbl_base.Size = New System.Drawing.Size(160, 23)
      Me.lbl_base.TabIndex = 160
      Me.lbl_base.Text = " Base Material"
      Me.lbl_base.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Panel10
      '
      Me.Panel10.BackColor = System.Drawing.Color.WhiteSmoke
      Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Panel10.Controls.Add(Me.radBaseMaterialSteel)
      Me.Panel10.Controls.Add(Me.radBaseMaterialSheetMetal)
      Me.Panel10.Controls.Add(Me.lblBaseMaterialChkValue)
      Me.Panel10.Location = New System.Drawing.Point(274, 42)
      Me.Panel10.Name = "Panel10"
      Me.Panel10.Size = New System.Drawing.Size(160, 64)
      Me.Panel10.TabIndex = 372
      '
      'radBaseMaterialSteel
      '
      Me.radBaseMaterialSteel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.radBaseMaterialSteel.Location = New System.Drawing.Point(14, 32)
      Me.radBaseMaterialSteel.Name = "radBaseMaterialSteel"
      Me.radBaseMaterialSteel.Size = New System.Drawing.Size(88, 24)
      Me.radBaseMaterialSteel.TabIndex = 377
      Me.radBaseMaterialSteel.Text = "Steel"
      '
      'radBaseMaterialSheetMetal
      '
      Me.radBaseMaterialSheetMetal.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.radBaseMaterialSheetMetal.Location = New System.Drawing.Point(14, 8)
      Me.radBaseMaterialSheetMetal.Name = "radBaseMaterialSheetMetal"
      Me.radBaseMaterialSheetMetal.Size = New System.Drawing.Size(88, 24)
      Me.radBaseMaterialSheetMetal.TabIndex = 376
      Me.radBaseMaterialSheetMetal.Text = "Sheet metal"
      '
      'lblBaseMaterialChkValue
      '
      Me.lblBaseMaterialChkValue.BackColor = System.Drawing.Color.Yellow
      Me.lblBaseMaterialChkValue.Location = New System.Drawing.Point(108, 62)
      Me.lblBaseMaterialChkValue.Name = "lblBaseMaterialChkValue"
      Me.lblBaseMaterialChkValue.Size = New System.Drawing.Size(46, 23)
      Me.lblBaseMaterialChkValue.TabIndex = 375
      Me.lblBaseMaterialChkValue.Text = "Label32"
      '
      'Panel9
      '
      Me.Panel9.BackColor = System.Drawing.Color.DarkGray
      Me.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Panel9.Controls.Add(Me.lbl_doors)
      Me.Panel9.Controls.Add(Me.Label28)
      Me.Panel9.Location = New System.Drawing.Point(20, 280)
      Me.Panel9.Name = "Panel9"
      Me.Panel9.Size = New System.Drawing.Size(176, 23)
      Me.Panel9.TabIndex = 371
      '
      'lbl_doors
      '
      Me.lbl_doors.BackColor = System.Drawing.Color.Transparent
      Me.lbl_doors.Cursor = System.Windows.Forms.Cursors.Default
      Me.lbl_doors.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lbl_doors.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_doors.Location = New System.Drawing.Point(8, 0)
      Me.lbl_doors.Name = "lbl_doors"
      Me.lbl_doors.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lbl_doors.Size = New System.Drawing.Size(84, 22)
      Me.lbl_doors.TabIndex = 161
      Me.lbl_doors.Text = "Materials"
      Me.lbl_doors.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label28
      '
      Me.Label28.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label28.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label28.Location = New System.Drawing.Point(100, 0)
      Me.Label28.Name = "Label28"
      Me.Label28.Size = New System.Drawing.Size(68, 22)
      Me.Label28.TabIndex = 367
      Me.Label28.Text = "Quantity"
      Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'panSectionsSummaryHeader
      '
      Me.panSectionsSummaryHeader.BackColor = System.Drawing.Color.DarkGray
      Me.panSectionsSummaryHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.panSectionsSummaryHeader.Controls.Add(Me.Label23)
      Me.panSectionsSummaryHeader.Controls.Add(Me.Label15)
      Me.panSectionsSummaryHeader.Location = New System.Drawing.Point(20, 20)
      Me.panSectionsSummaryHeader.Name = "panSectionsSummaryHeader"
      Me.panSectionsSummaryHeader.Size = New System.Drawing.Size(176, 23)
      Me.panSectionsSummaryHeader.TabIndex = 370
      '
      'Label23
      '
      Me.Label23.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label23.Location = New System.Drawing.Point(8, 0)
      Me.Label23.Name = "Label23"
      Me.Label23.Size = New System.Drawing.Size(72, 22)
      Me.Label23.TabIndex = 356
      Me.Label23.Text = "Sections"
      Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label15
      '
      Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label15.Location = New System.Drawing.Point(100, 0)
      Me.Label15.Name = "Label15"
      Me.Label15.Size = New System.Drawing.Size(68, 22)
      Me.Label15.TabIndex = 346
      Me.Label15.Text = "Quantity"
      Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Panel8
      '
      Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Panel8.Controls.Add(Me.Panel6)
      Me.Panel8.Controls.Add(Me.Panel7)
      Me.Panel8.Location = New System.Drawing.Point(20, 302)
      Me.Panel8.Name = "Panel8"
      Me.Panel8.Size = New System.Drawing.Size(176, 64)
      Me.Panel8.TabIndex = 369
      '
      'Panel6
      '
      Me.Panel6.Controls.Add(Me.Label19)
      Me.Panel6.Controls.Add(Me.txt_doors)
      Me.Panel6.Location = New System.Drawing.Point(0, 0)
      Me.Panel6.Name = "Panel6"
      Me.Panel6.Size = New System.Drawing.Size(176, 32)
      Me.Panel6.TabIndex = 366
      '
      'Label19
      '
      Me.Label19.Location = New System.Drawing.Point(8, 6)
      Me.Label19.Name = "Label19"
      Me.Label19.Size = New System.Drawing.Size(100, 22)
      Me.Label19.TabIndex = 357
      Me.Label19.Text = "Door"
      Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txt_doors
      '
      Me.txt_doors.AcceptsReturn = True
      Me.txt_doors.BackColor = System.Drawing.SystemColors.Window
      Me.txt_doors.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txt_doors.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txt_doors.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txt_doors.Location = New System.Drawing.Point(124, 6)
      Me.txt_doors.MaxLength = 0
      Me.txt_doors.Name = "txt_doors"
      Me.txt_doors.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txt_doors.Size = New System.Drawing.Size(40, 21)
      Me.txt_doors.TabIndex = 21
      Me.txt_doors.Text = "0"
      Me.txt_doors.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Panel7
      '
      Me.Panel7.BackColor = System.Drawing.Color.WhiteSmoke
      Me.Panel7.Controls.Add(Me.lblAirSealQuantity)
      Me.Panel7.Controls.Add(Me.Label29)
      Me.Panel7.Location = New System.Drawing.Point(0, 32)
      Me.Panel7.Name = "Panel7"
      Me.Panel7.Size = New System.Drawing.Size(176, 32)
      Me.Panel7.TabIndex = 368
      '
      'lblAirSealQuantity
      '
      Me.lblAirSealQuantity.BackColor = System.Drawing.Color.WhiteSmoke
      Me.lblAirSealQuantity.Location = New System.Drawing.Point(124, 6)
      Me.lblAirSealQuantity.Name = "lblAirSealQuantity"
      Me.lblAirSealQuantity.Size = New System.Drawing.Size(40, 22)
      Me.lblAirSealQuantity.TabIndex = 362
      Me.lblAirSealQuantity.Text = "0"
      Me.lblAirSealQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label29
      '
      Me.Label29.BackColor = System.Drawing.Color.WhiteSmoke
      Me.Label29.Location = New System.Drawing.Point(8, 6)
      Me.Label29.Name = "Label29"
      Me.Label29.Size = New System.Drawing.Size(100, 22)
      Me.Label29.TabIndex = 360
      Me.Label29.Text = "Air seal"
      Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'panSectionQuantities
      '
      Me.panSectionQuantities.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.panSectionQuantities.Controls.Add(Me.Panel3)
      Me.panSectionQuantities.Controls.Add(Me.Panel1)
      Me.panSectionQuantities.Controls.Add(Me.Panel4)
      Me.panSectionQuantities.Controls.Add(Me.Panel2)
      Me.panSectionQuantities.Controls.Add(Me.Panel5)
      Me.panSectionQuantities.Location = New System.Drawing.Point(20, 42)
      Me.panSectionQuantities.Name = "panSectionQuantities"
      Me.panSectionQuantities.Size = New System.Drawing.Size(176, 196)
      Me.panSectionQuantities.TabIndex = 365
      '
      'Panel3
      '
      Me.Panel3.BackColor = System.Drawing.Color.White
      Me.Panel3.Controls.Add(Me.lblBLD1Quantity)
      Me.Panel3.Controls.Add(Me.Label27)
      Me.Panel3.Controls.Add(Me.Label26)
      Me.Panel3.Controls.Add(Me.lbl_bld1_cost)
      Me.Panel3.Location = New System.Drawing.Point(0, 0)
      Me.Panel3.Name = "Panel3"
      Me.Panel3.Size = New System.Drawing.Size(176, 40)
      Me.Panel3.TabIndex = 361
      '
      'lblBLD1Quantity
      '
      Me.lblBLD1Quantity.BackColor = System.Drawing.Color.White
      Me.lblBLD1Quantity.Location = New System.Drawing.Point(124, 16)
      Me.lblBLD1Quantity.Name = "lblBLD1Quantity"
      Me.lblBLD1Quantity.Size = New System.Drawing.Size(40, 22)
      Me.lblBLD1Quantity.TabIndex = 362
      Me.lblBLD1Quantity.Text = "0"
      Me.lblBLD1Quantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label27
      '
      Me.Label27.BackColor = System.Drawing.Color.White
      Me.Label27.Location = New System.Drawing.Point(10, 16)
      Me.Label27.Name = "Label27"
      Me.Label27.Size = New System.Drawing.Size(100, 22)
      Me.Label27.TabIndex = 360
      Me.Label27.Text = "Air blender"
      Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label26
      '
      Me.Label26.BackColor = System.Drawing.Color.White
      Me.Label26.Location = New System.Drawing.Point(10, 0)
      Me.Label26.Name = "Label26"
      Me.Label26.Size = New System.Drawing.Size(100, 22)
      Me.Label26.TabIndex = 359
      Me.Label26.Text = "BLD1"
      Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lbl_bld1_cost
      '
      Me.lbl_bld1_cost.BackColor = System.Drawing.Color.Transparent
      Me.lbl_bld1_cost.Cursor = System.Windows.Forms.Cursors.Default
      Me.lbl_bld1_cost.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lbl_bld1_cost.ForeColor = System.Drawing.Color.Blue
      Me.lbl_bld1_cost.Location = New System.Drawing.Point(88, 0)
      Me.lbl_bld1_cost.Name = "lbl_bld1_cost"
      Me.lbl_bld1_cost.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lbl_bld1_cost.Size = New System.Drawing.Size(76, 22)
      Me.lbl_bld1_cost.TabIndex = 339
      Me.lbl_bld1_cost.Text = "0"
      Me.lbl_bld1_cost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.lbl_bld1_cost.Visible = False
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
      Me.Panel1.Controls.Add(Me.lblSS1Quantity)
      Me.Panel1.Controls.Add(Me.Label13)
      Me.Panel1.Controls.Add(Me.Label14)
      Me.Panel1.Location = New System.Drawing.Point(0, 38)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(176, 40)
      Me.Panel1.TabIndex = 354
      '
      'lblSS1Quantity
      '
      Me.lblSS1Quantity.BackColor = System.Drawing.Color.WhiteSmoke
      Me.lblSS1Quantity.Location = New System.Drawing.Point(124, 16)
      Me.lblSS1Quantity.Name = "lblSS1Quantity"
      Me.lblSS1Quantity.Size = New System.Drawing.Size(40, 22)
      Me.lblSS1Quantity.TabIndex = 349
      Me.lblSS1Quantity.Text = "0"
      Me.lblSS1Quantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label13
      '
      Me.Label13.BackColor = System.Drawing.Color.WhiteSmoke
      Me.Label13.Location = New System.Drawing.Point(10, 16)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(108, 22)
      Me.Label13.TabIndex = 343
      Me.Label13.Text = "1-foot space"
      Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label14
      '
      Me.Label14.BackColor = System.Drawing.Color.WhiteSmoke
      Me.Label14.Location = New System.Drawing.Point(10, 0)
      Me.Label14.Name = "Label14"
      Me.Label14.Size = New System.Drawing.Size(108, 22)
      Me.Label14.TabIndex = 345
      Me.Label14.Text = "SS1"
      Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Panel4
      '
      Me.Panel4.Controls.Add(Me.lblSS2Quantity)
      Me.Panel4.Controls.Add(Me.Label17)
      Me.Panel4.Controls.Add(Me.Label18)
      Me.Panel4.Location = New System.Drawing.Point(0, 77)
      Me.Panel4.Name = "Panel4"
      Me.Panel4.Size = New System.Drawing.Size(176, 40)
      Me.Panel4.TabIndex = 363
      '
      'lblSS2Quantity
      '
      Me.lblSS2Quantity.Location = New System.Drawing.Point(124, 16)
      Me.lblSS2Quantity.Name = "lblSS2Quantity"
      Me.lblSS2Quantity.Size = New System.Drawing.Size(40, 22)
      Me.lblSS2Quantity.TabIndex = 350
      Me.lblSS2Quantity.Text = "0"
      Me.lblSS2Quantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label17
      '
      Me.Label17.Location = New System.Drawing.Point(8, 0)
      Me.Label17.Name = "Label17"
      Me.Label17.Size = New System.Drawing.Size(108, 22)
      Me.Label17.TabIndex = 348
      Me.Label17.Text = "SS2"
      Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label18
      '
      Me.Label18.Location = New System.Drawing.Point(8, 16)
      Me.Label18.Name = "Label18"
      Me.Label18.Size = New System.Drawing.Size(108, 22)
      Me.Label18.TabIndex = 347
      Me.Label18.Text = "2-foot space"
      Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Panel2
      '
      Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
      Me.Panel2.Controls.Add(Me.lblSS3Quantity)
      Me.Panel2.Controls.Add(Me.Label21)
      Me.Panel2.Controls.Add(Me.Label22)
      Me.Panel2.Location = New System.Drawing.Point(0, 116)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(176, 40)
      Me.Panel2.TabIndex = 355
      '
      'lblSS3Quantity
      '
      Me.lblSS3Quantity.BackColor = System.Drawing.Color.WhiteSmoke
      Me.lblSS3Quantity.Location = New System.Drawing.Point(124, 16)
      Me.lblSS3Quantity.Name = "lblSS3Quantity"
      Me.lblSS3Quantity.Size = New System.Drawing.Size(40, 22)
      Me.lblSS3Quantity.TabIndex = 353
      Me.lblSS3Quantity.Text = "0"
      Me.lblSS3Quantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label21
      '
      Me.Label21.BackColor = System.Drawing.Color.WhiteSmoke
      Me.Label21.Location = New System.Drawing.Point(10, 0)
      Me.Label21.Name = "Label21"
      Me.Label21.Size = New System.Drawing.Size(108, 22)
      Me.Label21.TabIndex = 352
      Me.Label21.Text = "SS3"
      Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label22
      '
      Me.Label22.BackColor = System.Drawing.Color.WhiteSmoke
      Me.Label22.Location = New System.Drawing.Point(10, 16)
      Me.Label22.Name = "Label22"
      Me.Label22.Size = New System.Drawing.Size(108, 22)
      Me.Label22.TabIndex = 351
      Me.Label22.Text = "3-foot space"
      Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Panel5
      '
      Me.Panel5.Controls.Add(Me.Label25)
      Me.Panel5.Controls.Add(Me.Label24)
      Me.Panel5.Controls.Add(Me.lblUS1Quantity)
      Me.Panel5.Location = New System.Drawing.Point(0, 155)
      Me.Panel5.Name = "Panel5"
      Me.Panel5.Size = New System.Drawing.Size(176, 40)
      Me.Panel5.TabIndex = 364
      '
      'Label25
      '
      Me.Label25.Location = New System.Drawing.Point(8, 16)
      Me.Label25.Name = "Label25"
      Me.Label25.Size = New System.Drawing.Size(100, 22)
      Me.Label25.TabIndex = 358
      Me.Label25.Text = "Unit split"
      Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label24
      '
      Me.Label24.Location = New System.Drawing.Point(8, 0)
      Me.Label24.Name = "Label24"
      Me.Label24.Size = New System.Drawing.Size(100, 22)
      Me.Label24.TabIndex = 357
      Me.Label24.Text = "US1"
      Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblUS1Quantity
      '
      Me.lblUS1Quantity.Location = New System.Drawing.Point(124, 16)
      Me.lblUS1Quantity.Name = "lblUS1Quantity"
      Me.lblUS1Quantity.Size = New System.Drawing.Size(40, 22)
      Me.lblUS1Quantity.TabIndex = 362
      Me.lblUS1Quantity.Text = "0"
      Me.lblUS1Quantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lbl_ATT_sound_att
      '
      Me.lbl_ATT_sound_att.BackColor = System.Drawing.Color.Red
      Me.lbl_ATT_sound_att.Cursor = System.Windows.Forms.Cursors.Default
      Me.lbl_ATT_sound_att.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lbl_ATT_sound_att.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lbl_ATT_sound_att.Location = New System.Drawing.Point(556, 278)
      Me.lbl_ATT_sound_att.Name = "lbl_ATT_sound_att"
      Me.lbl_ATT_sound_att.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lbl_ATT_sound_att.Size = New System.Drawing.Size(108, 22)
      Me.lbl_ATT_sound_att.TabIndex = 56
      Me.lbl_ATT_sound_att.Text = "Sound Attenuator"
      Me.lbl_ATT_sound_att.TextAlign = System.Drawing.ContentAlignment.BottomLeft
      Me.lbl_ATT_sound_att.Visible = False
      '
      'ck_ATT_5
      '
      Me.ck_ATT_5.BackColor = System.Drawing.Color.Red
      Me.ck_ATT_5.Cursor = System.Windows.Forms.Cursors.Default
      Me.ck_ATT_5.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ck_ATT_5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ck_ATT_5.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_ATT_5.Location = New System.Drawing.Point(556, 350)
      Me.ck_ATT_5.Name = "ck_ATT_5"
      Me.ck_ATT_5.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.ck_ATT_5.Size = New System.Drawing.Size(120, 22)
      Me.ck_ATT_5.TabIndex = 25
      Me.ck_ATT_5.Text = "ATT5 - 5'"
      Me.ck_ATT_5.UseVisualStyleBackColor = False
      Me.ck_ATT_5.Visible = False
      '
      'ck_ATT_4
      '
      Me.ck_ATT_4.BackColor = System.Drawing.Color.Red
      Me.ck_ATT_4.Cursor = System.Windows.Forms.Cursors.Default
      Me.ck_ATT_4.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ck_ATT_4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ck_ATT_4.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_ATT_4.Location = New System.Drawing.Point(556, 326)
      Me.ck_ATT_4.Name = "ck_ATT_4"
      Me.ck_ATT_4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.ck_ATT_4.Size = New System.Drawing.Size(120, 22)
      Me.ck_ATT_4.TabIndex = 24
      Me.ck_ATT_4.Text = "ATT4 - 4'"
      Me.ck_ATT_4.UseVisualStyleBackColor = False
      Me.ck_ATT_4.Visible = False
      '
      'ck_ATT_3
      '
      Me.ck_ATT_3.BackColor = System.Drawing.Color.Red
      Me.ck_ATT_3.Cursor = System.Windows.Forms.Cursors.Default
      Me.ck_ATT_3.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ck_ATT_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ck_ATT_3.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_ATT_3.Location = New System.Drawing.Point(556, 302)
      Me.ck_ATT_3.Name = "ck_ATT_3"
      Me.ck_ATT_3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.ck_ATT_3.Size = New System.Drawing.Size(120, 22)
      Me.ck_ATT_3.TabIndex = 23
      Me.ck_ATT_3.Text = "ATT3 - 3'"
      Me.ck_ATT_3.UseVisualStyleBackColor = False
      Me.ck_ATT_3.Visible = False
      '
      'ck_ATT
      '
      Me.ck_ATT.BackColor = System.Drawing.Color.Yellow
      Me.ck_ATT.Cursor = System.Windows.Forms.Cursors.Default
      Me.ck_ATT.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ck_ATT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ck_ATT.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ck_ATT.Location = New System.Drawing.Point(556, 378)
      Me.ck_ATT.Name = "ck_ATT"
      Me.ck_ATT.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.ck_ATT.Size = New System.Drawing.Size(120, 22)
      Me.ck_ATT.TabIndex = 330
      Me.ck_ATT.Text = "Sound Attenuator"
      Me.ck_ATT.UseVisualStyleBackColor = False
      Me.ck_ATT.Visible = False
      '
      'cmd_close_2
      '
      Me.cmd_close_2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmd_close_2.BackColor = System.Drawing.SystemColors.Control
      Me.cmd_close_2.Cursor = System.Windows.Forms.Cursors.Default
      Me.cmd_close_2.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmd_close_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmd_close_2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.cmd_close_2.Location = New System.Drawing.Point(584, 458)
      Me.cmd_close_2.Name = "cmd_close_2"
      Me.cmd_close_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.cmd_close_2.Size = New System.Drawing.Size(70, 22)
      Me.cmd_close_2.TabIndex = 338
      Me.cmd_close_2.Text = "Save"
      Me.cmd_close_2.UseVisualStyleBackColor = False
      '
      'cbo_coil_type
      '
      '
      'cbo_drive_type
      '
      '
      'cbo_fan_class
      '
      '
      'cbo_fan_iso
      '
      '
      'cbo_fan_size
      '
      '
      'cbo_fan_type
      '
      '
      'cbo_ff
      '
      '
      'cbo_ff_sets
      '
      '
      'cbo_fin_thickness
      '
      '
      'cbo_fins
      '
      '
      'cbo_hp
      '
      '
      'cbo_mixing_box
      '
      '
      'cbo_pre_ff
      '
      '
      'cbo_pre_sets
      '
      '
      'cbo_rows
      '
      '
      'cbo_rpm
      '
      '
      'cbo_tube_thickness
      '
      '
      'ck_MB1_al
      '
      '
      'ck_MB1_gal
      '
      '
      'ck_al
      '
      '
      'ck_cu
      '
      '
      'ck_gal
      '
      '
      'ck_high
      '
      '
      'ck_odp
      '
      '
      'ck_premium
      '
      '
      'ck_ss
      '
      '
      'ck_tefc
      '
      '
      'btnClose
      '
      Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnClose.Location = New System.Drawing.Point(660, 458)
      Me.btnClose.Name = "btnClose"
      Me.btnClose.Size = New System.Drawing.Size(70, 22)
      Me.btnClose.TabIndex = 338
      Me.btnClose.Text = "Close"
      '
      'conSelect
      '
      Me.conSelect.ConnectionString = resources.GetString("conSelect.ConnectionString")
      '
      'lllCatalog
      '
      Me.lllCatalog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lllCatalog.BackColor = System.Drawing.SystemColors.Control
      Me.lllCatalog.Location = New System.Drawing.Point(548, 2)
      Me.lllCatalog.Name = "lllCatalog"
      Me.lllCatalog.Size = New System.Drawing.Size(178, 23)
      Me.lllCatalog.TabIndex = 339
      Me.lllCatalog.TabStop = True
      Me.lllCatalog.Text = "Air Handling Units catalog"
      Me.lllCatalog.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dadSection
      '
      Me.dadSection.DeleteCommand = Me.OleDbDeleteCommand1
      Me.dadSection.InsertCommand = Me.OleDbInsertCommand1
      Me.dadSection.SelectCommand = Me.OleDbSelectCommand1
      Me.dadSection.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "_Section", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Abbreviation", "Abbreviation"), New System.Data.Common.DataColumnMapping("AirHandlerID", "AirHandlerID"), New System.Data.Common.DataColumnMapping("OrderIndex", "OrderIndex"), New System.Data.Common.DataColumnMapping("SectionID", "SectionID"), New System.Data.Common.DataColumnMapping("SectionLength", "SectionLength")})})
      Me.dadSection.UpdateCommand = Me.OleDbUpdateCommand1
      '
      'OleDbDeleteCommand1
      '
      Me.OleDbDeleteCommand1.CommandText = "DELETE FROM _Section WHERE (SectionID = ?)"
      Me.OleDbDeleteCommand1.Connection = Me.OleDbConnection1
      Me.OleDbDeleteCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_SectionID", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SectionID", System.Data.DataRowVersion.Original, Nothing)})
      '
      'OleDbConnection1
      '
      Me.OleDbConnection1.ConnectionString = resources.GetString("OleDbConnection1.ConnectionString")
      '
      'OleDbInsertCommand1
      '
      Me.OleDbInsertCommand1.CommandText = "INSERT INTO _Section(Abbreviation, AirHandlerID, OrderIndex, SectionLength) VALUE" & _
          "S (?, ?, ?, ?)"
      Me.OleDbInsertCommand1.Connection = Me.OleDbConnection1
      Me.OleDbInsertCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Abbreviation", System.Data.OleDb.OleDbType.VarWChar, 50, "Abbreviation"), New System.Data.OleDb.OleDbParameter("AirHandlerID", System.Data.OleDb.OleDbType.[Integer], 0, "AirHandlerID"), New System.Data.OleDb.OleDbParameter("OrderIndex", System.Data.OleDb.OleDbType.SmallInt, 0, "OrderIndex"), New System.Data.OleDb.OleDbParameter("SectionLength", System.Data.OleDb.OleDbType.[Integer], 0, "SectionLength")})
      '
      'OleDbSelectCommand1
      '
      Me.OleDbSelectCommand1.CommandText = "SELECT Abbreviation, AirHandlerID, OrderIndex, SectionID, SectionLength FROM _Sec" & _
          "tion WHERE (AirHandlerID = ?)"
      Me.OleDbSelectCommand1.Connection = Me.OleDbConnection1
      Me.OleDbSelectCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("AirHandlerID", System.Data.OleDb.OleDbType.[Integer], 0, "AirHandlerID")})
      '
      'OleDbUpdateCommand1
      '
      Me.OleDbUpdateCommand1.CommandText = "UPDATE _Section SET Abbreviation = ?, AirHandlerID = ?, OrderIndex = ?, SectionLe" & _
          "ngth = ? WHERE (SectionID = ?)"
      Me.OleDbUpdateCommand1.Connection = Me.OleDbConnection1
      Me.OleDbUpdateCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Abbreviation", System.Data.OleDb.OleDbType.VarWChar, 50, "Abbreviation"), New System.Data.OleDb.OleDbParameter("AirHandlerID", System.Data.OleDb.OleDbType.[Integer], 0, "AirHandlerID"), New System.Data.OleDb.OleDbParameter("OrderIndex", System.Data.OleDb.OleDbType.SmallInt, 0, "OrderIndex"), New System.Data.OleDb.OleDbParameter("SectionLength", System.Data.OleDb.OleDbType.[Integer], 0, "SectionLength"), New System.Data.OleDb.OleDbParameter("Original_SectionID", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SectionID", System.Data.DataRowVersion.Original, Nothing)})
      '
      'dadAirHandler
      '
      Me.dadAirHandler.DeleteCommand = Me.OleDbDeleteCommand3
      Me.dadAirHandler.InsertCommand = Me.OleDbInsertCommand3
      Me.dadAirHandler.SelectCommand = Me.OleDbSelectCommand3
      Me.dadAirHandler.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "SavedAirHandler", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Airflow", "Airflow"), New System.Data.Common.DataColumnMapping("AirHandlerID", "AirHandlerID"), New System.Data.Common.DataColumnMapping("BaseCost", "BaseCost"), New System.Data.Common.DataColumnMapping("BaseMaterial", "BaseMaterial"), New System.Data.Common.DataColumnMapping("CabinetIndex", "CabinetIndex"), New System.Data.Common.DataColumnMapping("CoilFaceVelocity", "CoilFaceVelocity"), New System.Data.Common.DataColumnMapping("CoilIndex", "CoilIndex"), New System.Data.Common.DataColumnMapping("CoilSize", "CoilSize"), New System.Data.Common.DataColumnMapping("ExternalStaticPressure", "ExternalStaticPressure"), New System.Data.Common.DataColumnMapping("FilterFaceVelocity", "FilterFaceVelocity"), New System.Data.Common.DataColumnMapping("FilterSize", "FilterSize"), New System.Data.Common.DataColumnMapping("Height", "Height"), New System.Data.Common.DataColumnMapping("Length", "Length"), New System.Data.Common.DataColumnMapping("ListPrice", "ListPrice"), New System.Data.Common.DataColumnMapping("Location", "Location"), New System.Data.Common.DataColumnMapping("MarginPrice", "MarginPrice"), New System.Data.Common.DataColumnMapping("ModelNumber", "ModelNumber"), New System.Data.Common.DataColumnMapping("NumAirSeals", "NumAirSeals"), New System.Data.Common.DataColumnMapping("NumDoors", "NumDoors"), New System.Data.Common.DataColumnMapping("Paint", "Paint"), New System.Data.Common.DataColumnMapping("PanelThickness", "PanelThickness"), New System.Data.Common.DataColumnMapping("ProjectID", "ProjectID"), New System.Data.Common.DataColumnMapping("ShipWeight", "ShipWeight"), New System.Data.Common.DataColumnMapping("Tag", "Tag"), New System.Data.Common.DataColumnMapping("Width", "Width")})})
      Me.dadAirHandler.UpdateCommand = Me.OleDbUpdateCommand3
      '
      'OleDbDeleteCommand3
      '
      Me.OleDbDeleteCommand3.CommandText = "DELETE FROM SavedAirHandler WHERE (AirHandlerID = ?)"
      Me.OleDbDeleteCommand3.Connection = Me.OleDbConnection1
      Me.OleDbDeleteCommand3.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_AirHandlerID", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AirHandlerID", System.Data.DataRowVersion.Original, Nothing)})
      '
      'OleDbInsertCommand3
      '
      Me.OleDbInsertCommand3.CommandText = resources.GetString("OleDbInsertCommand3.CommandText")
      Me.OleDbInsertCommand3.Connection = Me.OleDbConnection1
      Me.OleDbInsertCommand3.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Airflow", System.Data.OleDb.OleDbType.[Double], 0, "Airflow"), New System.Data.OleDb.OleDbParameter("BaseCost", System.Data.OleDb.OleDbType.[Single], 0, "BaseCost"), New System.Data.OleDb.OleDbParameter("BaseMaterial", System.Data.OleDb.OleDbType.VarWChar, 50, "BaseMaterial"), New System.Data.OleDb.OleDbParameter("CabinetIndex", System.Data.OleDb.OleDbType.[Integer], 0, "CabinetIndex"), New System.Data.OleDb.OleDbParameter("CoilFaceVelocity", System.Data.OleDb.OleDbType.[Double], 0, "CoilFaceVelocity"), New System.Data.OleDb.OleDbParameter("CoilIndex", System.Data.OleDb.OleDbType.SmallInt, 0, "CoilIndex"), New System.Data.OleDb.OleDbParameter("CoilSize", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilSize"), New System.Data.OleDb.OleDbParameter("ExternalStaticPressure", System.Data.OleDb.OleDbType.[Double], 0, "ExternalStaticPressure"), New System.Data.OleDb.OleDbParameter("FilterFaceVelocity", System.Data.OleDb.OleDbType.[Double], 0, "FilterFaceVelocity"), New System.Data.OleDb.OleDbParameter("FilterSize", System.Data.OleDb.OleDbType.VarWChar, 50, "FilterSize"), New System.Data.OleDb.OleDbParameter("Height", System.Data.OleDb.OleDbType.[Single], 0, "Height"), New System.Data.OleDb.OleDbParameter("Length", System.Data.OleDb.OleDbType.[Single], 0, "Length"), New System.Data.OleDb.OleDbParameter("ListPrice", System.Data.OleDb.OleDbType.[Single], 0, "ListPrice"), New System.Data.OleDb.OleDbParameter("Location", System.Data.OleDb.OleDbType.VarWChar, 50, "Location"), New System.Data.OleDb.OleDbParameter("MarginPrice", System.Data.OleDb.OleDbType.[Single], 0, "MarginPrice"), New System.Data.OleDb.OleDbParameter("ModelNumber", System.Data.OleDb.OleDbType.VarWChar, 50, "ModelNumber"), New System.Data.OleDb.OleDbParameter("NumAirSeals", System.Data.OleDb.OleDbType.[Integer], 0, "NumAirSeals"), New System.Data.OleDb.OleDbParameter("NumDoors", System.Data.OleDb.OleDbType.[Integer], 0, "NumDoors"), New System.Data.OleDb.OleDbParameter("Paint", System.Data.OleDb.OleDbType.[Boolean], 2, "Paint"), New System.Data.OleDb.OleDbParameter("PanelThickness", System.Data.OleDb.OleDbType.SmallInt, 0, "PanelThickness"), New System.Data.OleDb.OleDbParameter("ProjectID", System.Data.OleDb.OleDbType.[Integer], 0, "ProjectID"), New System.Data.OleDb.OleDbParameter("ShipWeight", System.Data.OleDb.OleDbType.VarWChar, 50, "ShipWeight"), New System.Data.OleDb.OleDbParameter("Tag", System.Data.OleDb.OleDbType.VarWChar, 50, "Tag"), New System.Data.OleDb.OleDbParameter("Width", System.Data.OleDb.OleDbType.[Single], 0, "Width")})
      '
      'OleDbSelectCommand3
      '
      Me.OleDbSelectCommand3.CommandText = resources.GetString("OleDbSelectCommand3.CommandText")
      Me.OleDbSelectCommand3.Connection = Me.OleDbConnection1
      Me.OleDbSelectCommand3.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("AirHandlerID", System.Data.OleDb.OleDbType.[Integer], 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AirHandlerID", System.Data.DataRowVersion.Current, "59")})
      '
      'OleDbUpdateCommand3
      '
      Me.OleDbUpdateCommand3.CommandText = resources.GetString("OleDbUpdateCommand3.CommandText")
      Me.OleDbUpdateCommand3.Connection = Me.OleDbConnection1
      Me.OleDbUpdateCommand3.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Airflow", System.Data.OleDb.OleDbType.[Double], 0, "Airflow"), New System.Data.OleDb.OleDbParameter("BaseCost", System.Data.OleDb.OleDbType.[Single], 0, "BaseCost"), New System.Data.OleDb.OleDbParameter("BaseMaterial", System.Data.OleDb.OleDbType.VarWChar, 50, "BaseMaterial"), New System.Data.OleDb.OleDbParameter("CabinetIndex", System.Data.OleDb.OleDbType.[Integer], 0, "CabinetIndex"), New System.Data.OleDb.OleDbParameter("CoilFaceVelocity", System.Data.OleDb.OleDbType.[Double], 0, "CoilFaceVelocity"), New System.Data.OleDb.OleDbParameter("CoilIndex", System.Data.OleDb.OleDbType.SmallInt, 0, "CoilIndex"), New System.Data.OleDb.OleDbParameter("CoilSize", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilSize"), New System.Data.OleDb.OleDbParameter("ExternalStaticPressure", System.Data.OleDb.OleDbType.[Double], 0, "ExternalStaticPressure"), New System.Data.OleDb.OleDbParameter("FilterFaceVelocity", System.Data.OleDb.OleDbType.[Double], 0, "FilterFaceVelocity"), New System.Data.OleDb.OleDbParameter("FilterSize", System.Data.OleDb.OleDbType.VarWChar, 50, "FilterSize"), New System.Data.OleDb.OleDbParameter("Height", System.Data.OleDb.OleDbType.[Single], 0, "Height"), New System.Data.OleDb.OleDbParameter("Length", System.Data.OleDb.OleDbType.[Single], 0, "Length"), New System.Data.OleDb.OleDbParameter("ListPrice", System.Data.OleDb.OleDbType.[Single], 0, "ListPrice"), New System.Data.OleDb.OleDbParameter("Location", System.Data.OleDb.OleDbType.VarWChar, 50, "Location"), New System.Data.OleDb.OleDbParameter("MarginPrice", System.Data.OleDb.OleDbType.[Single], 0, "MarginPrice"), New System.Data.OleDb.OleDbParameter("ModelNumber", System.Data.OleDb.OleDbType.VarWChar, 50, "ModelNumber"), New System.Data.OleDb.OleDbParameter("NumAirSeals", System.Data.OleDb.OleDbType.[Integer], 0, "NumAirSeals"), New System.Data.OleDb.OleDbParameter("NumDoors", System.Data.OleDb.OleDbType.[Integer], 0, "NumDoors"), New System.Data.OleDb.OleDbParameter("Paint", System.Data.OleDb.OleDbType.[Boolean], 2, "Paint"), New System.Data.OleDb.OleDbParameter("PanelThickness", System.Data.OleDb.OleDbType.SmallInt, 0, "PanelThickness"), New System.Data.OleDb.OleDbParameter("ProjectID", System.Data.OleDb.OleDbType.[Integer], 0, "ProjectID"), New System.Data.OleDb.OleDbParameter("ShipWeight", System.Data.OleDb.OleDbType.VarWChar, 50, "ShipWeight"), New System.Data.OleDb.OleDbParameter("Tag", System.Data.OleDb.OleDbType.VarWChar, 50, "Tag"), New System.Data.OleDb.OleDbParameter("Width", System.Data.OleDb.OleDbType.[Single], 0, "Width"), New System.Data.OleDb.OleDbParameter("Original_AirHandlerID", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AirHandlerID", System.Data.DataRowVersion.Original, Nothing)})
      '
      'Label32
      '
      Me.Label32.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label32.Location = New System.Drawing.Point(2, 458)
      Me.Label32.Name = "Label32"
      Me.Label32.Size = New System.Drawing.Size(38, 23)
      Me.Label32.TabIndex = 340
      Me.Label32.Text = "Tag:"
      Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblTag
      '
      Me.lblTag.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblTag.Location = New System.Drawing.Point(42, 458)
      Me.lblTag.Name = "lblTag"
      Me.lblTag.Size = New System.Drawing.Size(120, 23)
      Me.lblTag.TabIndex = 341
      Me.lblTag.Text = "Tag goes here"
      Me.lblTag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'DseProject1
      '
      Me.DseProject1.DataSetName = "dseProject"
      Me.DseProject1.Locale = New System.Globalization.CultureInfo("en-US")
      Me.DseProject1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'dadSectionDetails
      '
      Me.dadSectionDetails.DeleteCommand = Me.OleDbDeleteCommand4
      Me.dadSectionDetails.InsertCommand = Me.OleDbInsertCommand4
      Me.dadSectionDetails.SelectCommand = Me.OleDbSelectCommand4
      Me.dadSectionDetails.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "SectionDetails", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("AirHandlerID", "AirHandlerID"), New System.Data.Common.DataColumnMapping("C3Disconnect", "C3Disconnect"), New System.Data.Common.DataColumnMapping("C3KW", "C3KW"), New System.Data.Common.DataColumnMapping("C3MinNumStages", "C3MinNumStages"), New System.Data.Common.DataColumnMapping("C3NumExtraStages", "C3NumExtraStages"), New System.Data.Common.DataColumnMapping("C3OperatingTemperature", "C3OperatingTemperature"), New System.Data.Common.DataColumnMapping("C3OrderIndex", "C3OrderIndex"), New System.Data.Common.DataColumnMapping("C3SiliconControlledRectifier", "C3SiliconControlledRectifier"), New System.Data.Common.DataColumnMapping("Coil0OrderIndex", "Coil0OrderIndex"), New System.Data.Common.DataColumnMapping("Coil1OrderIndex", "Coil1OrderIndex"), New System.Data.Common.DataColumnMapping("Coil2OrderIndex", "Coil2OrderIndex"), New System.Data.Common.DataColumnMapping("CoilCasing0", "CoilCasing0"), New System.Data.Common.DataColumnMapping("CoilCasing1", "CoilCasing1"), New System.Data.Common.DataColumnMapping("CoilCasing2", "CoilCasing2"), New System.Data.Common.DataColumnMapping("CoilRows0", "CoilRows0"), New System.Data.Common.DataColumnMapping("CoilRows1", "CoilRows1"), New System.Data.Common.DataColumnMapping("CoilRows2", "CoilRows2"), New System.Data.Common.DataColumnMapping("CoilType0", "CoilType0"), New System.Data.Common.DataColumnMapping("CoilType1", "CoilType1"), New System.Data.Common.DataColumnMapping("CoilType2", "CoilType2"), New System.Data.Common.DataColumnMapping("DischargeGrating", "DischargeGrating"), New System.Data.Common.DataColumnMapping("DischargeHeight", "DischargeHeight"), New System.Data.Common.DataColumnMapping("DischargeOpeningLocation", "DischargeOpeningLocation"), New System.Data.Common.DataColumnMapping("DischargeOrderIndex", "DischargeOrderIndex"), New System.Data.Common.DataColumnMapping("DischargeWidth", "DischargeWidth"), New System.Data.Common.DataColumnMapping("Fan0OrderIndex", "Fan0OrderIndex"), New System.Data.Common.DataColumnMapping("Fan1OrderIndex", "Fan1OrderIndex"), New System.Data.Common.DataColumnMapping("Fan2OrderIndex", "Fan2OrderIndex"), New System.Data.Common.DataColumnMapping("FanClass0", "FanClass0"), New System.Data.Common.DataColumnMapping("FanClass1", "FanClass1"), New System.Data.Common.DataColumnMapping("FanClass2", "FanClass2"), New System.Data.Common.DataColumnMapping("FanDrive0", "FanDrive0"), New System.Data.Common.DataColumnMapping("FanDrive1", "FanDrive1"), New System.Data.Common.DataColumnMapping("FanDrive2", "FanDrive2"), New System.Data.Common.DataColumnMapping("FanEfficiency0", "FanEfficiency0"), New System.Data.Common.DataColumnMapping("FanEfficiency1", "FanEfficiency1"), New System.Data.Common.DataColumnMapping("FanEfficiency2", "FanEfficiency2"), New System.Data.Common.DataColumnMapping("FanEnclosure0", "FanEnclosure0"), New System.Data.Common.DataColumnMapping("FanEnclosure1", "FanEnclosure1"), New System.Data.Common.DataColumnMapping("FanEnclosure2", "FanEnclosure2"), New System.Data.Common.DataColumnMapping("FanHorsepower0", "FanHorsepower0"), New System.Data.Common.DataColumnMapping("FanHorsepower1", "FanHorsepower1"), New System.Data.Common.DataColumnMapping("FanHorsepower2", "FanHorsepower2"), New System.Data.Common.DataColumnMapping("FanIsolator0", "FanIsolator0"), New System.Data.Common.DataColumnMapping("FanIsolator1", "FanIsolator1"), New System.Data.Common.DataColumnMapping("FanIsolator2", "FanIsolator2"), New System.Data.Common.DataColumnMapping("FanRPM0", "FanRPM0"), New System.Data.Common.DataColumnMapping("FanRPM1", "FanRPM1"), New System.Data.Common.DataColumnMapping("FanRPM2", "FanRPM2"), New System.Data.Common.DataColumnMapping("FanSize0", "FanSize0"), New System.Data.Common.DataColumnMapping("FanSize1", "FanSize1"), New System.Data.Common.DataColumnMapping("FanSize2", "FanSize2"), New System.Data.Common.DataColumnMapping("FanType0", "FanType0"), New System.Data.Common.DataColumnMapping("FanType1", "FanType1"), New System.Data.Common.DataColumnMapping("FanType2", "FanType2"), New System.Data.Common.DataColumnMapping("Filt0", "Filt0"), New System.Data.Common.DataColumnMapping("Filt0OrderIndex", "Filt0OrderIndex"), New System.Data.Common.DataColumnMapping("Filt1", "Filt1"), New System.Data.Common.DataColumnMapping("Filt1OrderIndex", "Filt1OrderIndex"), New System.Data.Common.DataColumnMapping("Filt2", "Filt2"), New System.Data.Common.DataColumnMapping("Filt2OrderIndex", "Filt2OrderIndex"), New System.Data.Common.DataColumnMapping("FinMaterial0", "FinMaterial0"), New System.Data.Common.DataColumnMapping("FinMaterial1", "FinMaterial1"), New System.Data.Common.DataColumnMapping("FinMaterial2", "FinMaterial2"), New System.Data.Common.DataColumnMapping("FinThickness0", "FinThickness0"), New System.Data.Common.DataColumnMapping("FinThickness1", "FinThickness1"), New System.Data.Common.DataColumnMapping("FinThickness2", "FinThickness2"), New System.Data.Common.DataColumnMapping("MB1Casing", "MB1Casing"), New System.Data.Common.DataColumnMapping("MB1IncomingAir", "MB1IncomingAir"), New System.Data.Common.DataColumnMapping("MB1OrderIndex", "MB1OrderIndex"), New System.Data.Common.DataColumnMapping("MB2Casing", "MB2Casing"), New System.Data.Common.DataColumnMapping("MB2IncomingAir", "MB2IncomingAir"), New System.Data.Common.DataColumnMapping("MB2OrderIndex", "MB2OrderIndex"), New System.Data.Common.DataColumnMapping("NumFilts0", "NumFilts0"), New System.Data.Common.DataColumnMapping("NumFilts1", "NumFilts1"), New System.Data.Common.DataColumnMapping("NumFilts2", "NumFilts2"), New System.Data.Common.DataColumnMapping("NumFins0", "NumFins0"), New System.Data.Common.DataColumnMapping("NumFins1", "NumFins1"), New System.Data.Common.DataColumnMapping("NumFins2", "NumFins2"), New System.Data.Common.DataColumnMapping("NumPreFilts0", "NumPreFilts0"), New System.Data.Common.DataColumnMapping("NumPreFilts1", "NumPreFilts1"), New System.Data.Common.DataColumnMapping("NumPreFilts2", "NumPreFilts2"), New System.Data.Common.DataColumnMapping("PreFilt0", "PreFilt0"), New System.Data.Common.DataColumnMapping("PreFilt1", "PreFilt1"), New System.Data.Common.DataColumnMapping("PreFilt2", "PreFilt2"), New System.Data.Common.DataColumnMapping("SectionDetailsID", "SectionDetailsID"), New System.Data.Common.DataColumnMapping("TubeThickness0", "TubeThickness0"), New System.Data.Common.DataColumnMapping("TubeThickness1", "TubeThickness1"), New System.Data.Common.DataColumnMapping("TubeThickness2", "TubeThickness2"), New System.Data.Common.DataColumnMapping("CoilType4", "CoilType4"), New System.Data.Common.DataColumnMapping("Coil4OrderIndex", "Coil4OrderIndex"), New System.Data.Common.DataColumnMapping("FinMaterial4", "FinMaterial4")})})
      Me.dadSectionDetails.UpdateCommand = Me.OleDbUpdateCommand4
      '
      'OleDbDeleteCommand4
      '
      Me.OleDbDeleteCommand4.CommandText = "DELETE FROM SectionDetails WHERE (SectionDetailsID = ?)"
      Me.OleDbDeleteCommand4.Connection = Me.OleDbConnection1
      Me.OleDbDeleteCommand4.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_SectionDetailsID", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SectionDetailsID", System.Data.DataRowVersion.Original, Nothing)})
      '
      'OleDbInsertCommand4
      '
      Me.OleDbInsertCommand4.CommandText = resources.GetString("OleDbInsertCommand4.CommandText")
      Me.OleDbInsertCommand4.Connection = Me.OleDbConnection1
      Me.OleDbInsertCommand4.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("AirHandlerID", System.Data.OleDb.OleDbType.[Integer], 0, "AirHandlerID"), New System.Data.OleDb.OleDbParameter("C3Disconnect", System.Data.OleDb.OleDbType.[Boolean], 2, "C3Disconnect"), New System.Data.OleDb.OleDbParameter("C3KW", System.Data.OleDb.OleDbType.VarWChar, 50, "C3KW"), New System.Data.OleDb.OleDbParameter("C3MinNumStages", System.Data.OleDb.OleDbType.[Integer], 0, "C3MinNumStages"), New System.Data.OleDb.OleDbParameter("C3NumExtraStages", System.Data.OleDb.OleDbType.[Integer], 0, "C3NumExtraStages"), New System.Data.OleDb.OleDbParameter("C3OperatingTemperature", System.Data.OleDb.OleDbType.[Single], 0, "C3OperatingTemperature"), New System.Data.OleDb.OleDbParameter("C3OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "C3OrderIndex"), New System.Data.OleDb.OleDbParameter("C3SiliconControlledRectifier", System.Data.OleDb.OleDbType.[Boolean], 2, "C3SiliconControlledRectifier"), New System.Data.OleDb.OleDbParameter("Coil0OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Coil0OrderIndex"), New System.Data.OleDb.OleDbParameter("Coil1OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Coil1OrderIndex"), New System.Data.OleDb.OleDbParameter("Coil2OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Coil2OrderIndex"), New System.Data.OleDb.OleDbParameter("CoilCasing0", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilCasing0"), New System.Data.OleDb.OleDbParameter("CoilCasing1", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilCasing1"), New System.Data.OleDb.OleDbParameter("CoilCasing2", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilCasing2"), New System.Data.OleDb.OleDbParameter("CoilRows0", System.Data.OleDb.OleDbType.[Integer], 0, "CoilRows0"), New System.Data.OleDb.OleDbParameter("CoilRows1", System.Data.OleDb.OleDbType.[Integer], 0, "CoilRows1"), New System.Data.OleDb.OleDbParameter("CoilRows2", System.Data.OleDb.OleDbType.[Integer], 0, "CoilRows2"), New System.Data.OleDb.OleDbParameter("CoilType0", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilType0"), New System.Data.OleDb.OleDbParameter("CoilType1", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilType1"), New System.Data.OleDb.OleDbParameter("CoilType2", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilType2"), New System.Data.OleDb.OleDbParameter("DischargeGrating", System.Data.OleDb.OleDbType.[Boolean], 2, "DischargeGrating"), New System.Data.OleDb.OleDbParameter("DischargeHeight", System.Data.OleDb.OleDbType.[Integer], 0, "DischargeHeight"), New System.Data.OleDb.OleDbParameter("DischargeOpeningLocation", System.Data.OleDb.OleDbType.VarWChar, 50, "DischargeOpeningLocation"), New System.Data.OleDb.OleDbParameter("DischargeOrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "DischargeOrderIndex"), New System.Data.OleDb.OleDbParameter("DischargeWidth", System.Data.OleDb.OleDbType.[Integer], 0, "DischargeWidth"), New System.Data.OleDb.OleDbParameter("Fan0OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Fan0OrderIndex"), New System.Data.OleDb.OleDbParameter("Fan1OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Fan1OrderIndex"), New System.Data.OleDb.OleDbParameter("Fan2OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Fan2OrderIndex"), New System.Data.OleDb.OleDbParameter("FanClass0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanClass0"), New System.Data.OleDb.OleDbParameter("FanClass1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanClass1"), New System.Data.OleDb.OleDbParameter("FanClass2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanClass2"), New System.Data.OleDb.OleDbParameter("FanDrive0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanDrive0"), New System.Data.OleDb.OleDbParameter("FanDrive1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanDrive1"), New System.Data.OleDb.OleDbParameter("FanDrive2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanDrive2"), New System.Data.OleDb.OleDbParameter("FanEfficiency0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanEfficiency0"), New System.Data.OleDb.OleDbParameter("FanEfficiency1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanEfficiency1"), New System.Data.OleDb.OleDbParameter("FanEfficiency2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanEfficiency2"), New System.Data.OleDb.OleDbParameter("FanEnclosure0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanEnclosure0"), New System.Data.OleDb.OleDbParameter("FanEnclosure1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanEnclosure1"), New System.Data.OleDb.OleDbParameter("FanEnclosure2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanEnclosure2"), New System.Data.OleDb.OleDbParameter("FanHorsepower0", System.Data.OleDb.OleDbType.[Single], 0, "FanHorsepower0"), New System.Data.OleDb.OleDbParameter("FanHorsepower1", System.Data.OleDb.OleDbType.[Single], 0, "FanHorsepower1"), New System.Data.OleDb.OleDbParameter("FanHorsepower2", System.Data.OleDb.OleDbType.[Single], 0, "FanHorsepower2"), New System.Data.OleDb.OleDbParameter("FanIsolator0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanIsolator0"), New System.Data.OleDb.OleDbParameter("FanIsolator1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanIsolator1"), New System.Data.OleDb.OleDbParameter("FanIsolator2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanIsolator2"), New System.Data.OleDb.OleDbParameter("FanRPM0", System.Data.OleDb.OleDbType.[Integer], 0, "FanRPM0"), New System.Data.OleDb.OleDbParameter("FanRPM1", System.Data.OleDb.OleDbType.[Integer], 0, "FanRPM1"), New System.Data.OleDb.OleDbParameter("FanRPM2", System.Data.OleDb.OleDbType.[Integer], 0, "FanRPM2"), New System.Data.OleDb.OleDbParameter("FanSize0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanSize0"), New System.Data.OleDb.OleDbParameter("FanSize1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanSize1"), New System.Data.OleDb.OleDbParameter("FanSize2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanSize2"), New System.Data.OleDb.OleDbParameter("FanType0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanType0"), New System.Data.OleDb.OleDbParameter("FanType1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanType1"), New System.Data.OleDb.OleDbParameter("FanType2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanType2"), New System.Data.OleDb.OleDbParameter("Filt0", System.Data.OleDb.OleDbType.VarWChar, 50, "Filt0"), New System.Data.OleDb.OleDbParameter("Filt0OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Filt0OrderIndex"), New System.Data.OleDb.OleDbParameter("Filt1", System.Data.OleDb.OleDbType.VarWChar, 50, "Filt1"), New System.Data.OleDb.OleDbParameter("Filt1OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Filt1OrderIndex"), New System.Data.OleDb.OleDbParameter("Filt2", System.Data.OleDb.OleDbType.VarWChar, 50, "Filt2"), New System.Data.OleDb.OleDbParameter("Filt2OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Filt2OrderIndex"), New System.Data.OleDb.OleDbParameter("FinMaterial0", System.Data.OleDb.OleDbType.VarWChar, 50, "FinMaterial0"), New System.Data.OleDb.OleDbParameter("FinMaterial1", System.Data.OleDb.OleDbType.VarWChar, 50, "FinMaterial1"), New System.Data.OleDb.OleDbParameter("FinMaterial2", System.Data.OleDb.OleDbType.VarWChar, 50, "FinMaterial2"), New System.Data.OleDb.OleDbParameter("FinThickness0", System.Data.OleDb.OleDbType.[Single], 0, "FinThickness0"), New System.Data.OleDb.OleDbParameter("FinThickness1", System.Data.OleDb.OleDbType.[Single], 0, "FinThickness1"), New System.Data.OleDb.OleDbParameter("FinThickness2", System.Data.OleDb.OleDbType.[Single], 0, "FinThickness2"), New System.Data.OleDb.OleDbParameter("MB1Casing", System.Data.OleDb.OleDbType.VarWChar, 50, "MB1Casing"), New System.Data.OleDb.OleDbParameter("MB1IncomingAir", System.Data.OleDb.OleDbType.VarWChar, 50, "MB1IncomingAir"), New System.Data.OleDb.OleDbParameter("MB1OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "MB1OrderIndex"), New System.Data.OleDb.OleDbParameter("MB2Casing", System.Data.OleDb.OleDbType.VarWChar, 50, "MB2Casing"), New System.Data.OleDb.OleDbParameter("MB2IncomingAir", System.Data.OleDb.OleDbType.VarWChar, 50, "MB2IncomingAir"), New System.Data.OleDb.OleDbParameter("MB2OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "MB2OrderIndex"), New System.Data.OleDb.OleDbParameter("NumFilts0", System.Data.OleDb.OleDbType.[Integer], 0, "NumFilts0"), New System.Data.OleDb.OleDbParameter("NumFilts1", System.Data.OleDb.OleDbType.[Integer], 0, "NumFilts1"), New System.Data.OleDb.OleDbParameter("NumFilts2", System.Data.OleDb.OleDbType.[Integer], 0, "NumFilts2"), New System.Data.OleDb.OleDbParameter("NumFins0", System.Data.OleDb.OleDbType.[Integer], 0, "NumFins0"), New System.Data.OleDb.OleDbParameter("NumFins1", System.Data.OleDb.OleDbType.[Integer], 0, "NumFins1"), New System.Data.OleDb.OleDbParameter("NumFins2", System.Data.OleDb.OleDbType.[Integer], 0, "NumFins2"), New System.Data.OleDb.OleDbParameter("NumPreFilts0", System.Data.OleDb.OleDbType.[Integer], 0, "NumPreFilts0"), New System.Data.OleDb.OleDbParameter("NumPreFilts1", System.Data.OleDb.OleDbType.[Integer], 0, "NumPreFilts1"), New System.Data.OleDb.OleDbParameter("NumPreFilts2", System.Data.OleDb.OleDbType.[Integer], 0, "NumPreFilts2"), New System.Data.OleDb.OleDbParameter("PreFilt0", System.Data.OleDb.OleDbType.VarWChar, 50, "PreFilt0"), New System.Data.OleDb.OleDbParameter("PreFilt1", System.Data.OleDb.OleDbType.VarWChar, 50, "PreFilt1"), New System.Data.OleDb.OleDbParameter("PreFilt2", System.Data.OleDb.OleDbType.VarWChar, 50, "PreFilt2"), New System.Data.OleDb.OleDbParameter("TubeThickness0", System.Data.OleDb.OleDbType.[Single], 0, "TubeThickness0"), New System.Data.OleDb.OleDbParameter("TubeThickness1", System.Data.OleDb.OleDbType.[Single], 0, "TubeThickness1"), New System.Data.OleDb.OleDbParameter("TubeThickness2", System.Data.OleDb.OleDbType.[Single], 0, "TubeThickness2"), New System.Data.OleDb.OleDbParameter("CoilType4", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilType4"), New System.Data.OleDb.OleDbParameter("FinMaterial4", System.Data.OleDb.OleDbType.VarWChar, 50, "FinMaterial4"), New System.Data.OleDb.OleDbParameter("Coil4OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Coil4OrderIndex")})
      '
      'OleDbSelectCommand4
      '
      Me.OleDbSelectCommand4.CommandText = resources.GetString("OleDbSelectCommand4.CommandText")
      Me.OleDbSelectCommand4.Connection = Me.OleDbConnection1
      Me.OleDbSelectCommand4.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("AirHandlerID", System.Data.OleDb.OleDbType.[Integer], 0, "AirHandlerID")})
      '
      'OleDbUpdateCommand4
      '
      Me.OleDbUpdateCommand4.CommandText = resources.GetString("OleDbUpdateCommand4.CommandText")
      Me.OleDbUpdateCommand4.Connection = Me.OleDbConnection1
      Me.OleDbUpdateCommand4.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("AirHandlerID", System.Data.OleDb.OleDbType.[Integer], 0, "AirHandlerID"), New System.Data.OleDb.OleDbParameter("C3Disconnect", System.Data.OleDb.OleDbType.[Boolean], 2, "C3Disconnect"), New System.Data.OleDb.OleDbParameter("C3KW", System.Data.OleDb.OleDbType.VarWChar, 50, "C3KW"), New System.Data.OleDb.OleDbParameter("C3MinNumStages", System.Data.OleDb.OleDbType.[Integer], 0, "C3MinNumStages"), New System.Data.OleDb.OleDbParameter("C3NumExtraStages", System.Data.OleDb.OleDbType.[Integer], 0, "C3NumExtraStages"), New System.Data.OleDb.OleDbParameter("C3OperatingTemperature", System.Data.OleDb.OleDbType.[Single], 0, "C3OperatingTemperature"), New System.Data.OleDb.OleDbParameter("C3OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "C3OrderIndex"), New System.Data.OleDb.OleDbParameter("C3SiliconControlledRectifier", System.Data.OleDb.OleDbType.[Boolean], 2, "C3SiliconControlledRectifier"), New System.Data.OleDb.OleDbParameter("Coil0OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Coil0OrderIndex"), New System.Data.OleDb.OleDbParameter("Coil1OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Coil1OrderIndex"), New System.Data.OleDb.OleDbParameter("Coil2OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Coil2OrderIndex"), New System.Data.OleDb.OleDbParameter("CoilCasing0", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilCasing0"), New System.Data.OleDb.OleDbParameter("CoilCasing1", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilCasing1"), New System.Data.OleDb.OleDbParameter("CoilCasing2", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilCasing2"), New System.Data.OleDb.OleDbParameter("CoilRows0", System.Data.OleDb.OleDbType.[Integer], 0, "CoilRows0"), New System.Data.OleDb.OleDbParameter("CoilRows1", System.Data.OleDb.OleDbType.[Integer], 0, "CoilRows1"), New System.Data.OleDb.OleDbParameter("CoilRows2", System.Data.OleDb.OleDbType.[Integer], 0, "CoilRows2"), New System.Data.OleDb.OleDbParameter("CoilType0", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilType0"), New System.Data.OleDb.OleDbParameter("CoilType1", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilType1"), New System.Data.OleDb.OleDbParameter("CoilType2", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilType2"), New System.Data.OleDb.OleDbParameter("DischargeGrating", System.Data.OleDb.OleDbType.[Boolean], 2, "DischargeGrating"), New System.Data.OleDb.OleDbParameter("DischargeHeight", System.Data.OleDb.OleDbType.[Integer], 0, "DischargeHeight"), New System.Data.OleDb.OleDbParameter("DischargeOpeningLocation", System.Data.OleDb.OleDbType.VarWChar, 50, "DischargeOpeningLocation"), New System.Data.OleDb.OleDbParameter("DischargeOrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "DischargeOrderIndex"), New System.Data.OleDb.OleDbParameter("DischargeWidth", System.Data.OleDb.OleDbType.[Integer], 0, "DischargeWidth"), New System.Data.OleDb.OleDbParameter("Fan0OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Fan0OrderIndex"), New System.Data.OleDb.OleDbParameter("Fan1OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Fan1OrderIndex"), New System.Data.OleDb.OleDbParameter("Fan2OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Fan2OrderIndex"), New System.Data.OleDb.OleDbParameter("FanClass0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanClass0"), New System.Data.OleDb.OleDbParameter("FanClass1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanClass1"), New System.Data.OleDb.OleDbParameter("FanClass2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanClass2"), New System.Data.OleDb.OleDbParameter("FanDrive0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanDrive0"), New System.Data.OleDb.OleDbParameter("FanDrive1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanDrive1"), New System.Data.OleDb.OleDbParameter("FanDrive2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanDrive2"), New System.Data.OleDb.OleDbParameter("FanEfficiency0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanEfficiency0"), New System.Data.OleDb.OleDbParameter("FanEfficiency1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanEfficiency1"), New System.Data.OleDb.OleDbParameter("FanEfficiency2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanEfficiency2"), New System.Data.OleDb.OleDbParameter("FanEnclosure0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanEnclosure0"), New System.Data.OleDb.OleDbParameter("FanEnclosure1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanEnclosure1"), New System.Data.OleDb.OleDbParameter("FanEnclosure2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanEnclosure2"), New System.Data.OleDb.OleDbParameter("FanHorsepower0", System.Data.OleDb.OleDbType.[Single], 0, "FanHorsepower0"), New System.Data.OleDb.OleDbParameter("FanHorsepower1", System.Data.OleDb.OleDbType.[Single], 0, "FanHorsepower1"), New System.Data.OleDb.OleDbParameter("FanHorsepower2", System.Data.OleDb.OleDbType.[Single], 0, "FanHorsepower2"), New System.Data.OleDb.OleDbParameter("FanIsolator0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanIsolator0"), New System.Data.OleDb.OleDbParameter("FanIsolator1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanIsolator1"), New System.Data.OleDb.OleDbParameter("FanIsolator2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanIsolator2"), New System.Data.OleDb.OleDbParameter("FanRPM0", System.Data.OleDb.OleDbType.[Integer], 0, "FanRPM0"), New System.Data.OleDb.OleDbParameter("FanRPM1", System.Data.OleDb.OleDbType.[Integer], 0, "FanRPM1"), New System.Data.OleDb.OleDbParameter("FanRPM2", System.Data.OleDb.OleDbType.[Integer], 0, "FanRPM2"), New System.Data.OleDb.OleDbParameter("FanSize0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanSize0"), New System.Data.OleDb.OleDbParameter("FanSize1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanSize1"), New System.Data.OleDb.OleDbParameter("FanSize2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanSize2"), New System.Data.OleDb.OleDbParameter("FanType0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanType0"), New System.Data.OleDb.OleDbParameter("FanType1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanType1"), New System.Data.OleDb.OleDbParameter("FanType2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanType2"), New System.Data.OleDb.OleDbParameter("Filt0", System.Data.OleDb.OleDbType.VarWChar, 50, "Filt0"), New System.Data.OleDb.OleDbParameter("Filt0OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Filt0OrderIndex"), New System.Data.OleDb.OleDbParameter("Filt1", System.Data.OleDb.OleDbType.VarWChar, 50, "Filt1"), New System.Data.OleDb.OleDbParameter("Filt1OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Filt1OrderIndex"), New System.Data.OleDb.OleDbParameter("Filt2", System.Data.OleDb.OleDbType.VarWChar, 50, "Filt2"), New System.Data.OleDb.OleDbParameter("Filt2OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Filt2OrderIndex"), New System.Data.OleDb.OleDbParameter("FinMaterial0", System.Data.OleDb.OleDbType.VarWChar, 50, "FinMaterial0"), New System.Data.OleDb.OleDbParameter("FinMaterial1", System.Data.OleDb.OleDbType.VarWChar, 50, "FinMaterial1"), New System.Data.OleDb.OleDbParameter("FinMaterial2", System.Data.OleDb.OleDbType.VarWChar, 50, "FinMaterial2"), New System.Data.OleDb.OleDbParameter("FinThickness0", System.Data.OleDb.OleDbType.[Single], 0, "FinThickness0"), New System.Data.OleDb.OleDbParameter("FinThickness1", System.Data.OleDb.OleDbType.[Single], 0, "FinThickness1"), New System.Data.OleDb.OleDbParameter("FinThickness2", System.Data.OleDb.OleDbType.[Single], 0, "FinThickness2"), New System.Data.OleDb.OleDbParameter("MB1Casing", System.Data.OleDb.OleDbType.VarWChar, 50, "MB1Casing"), New System.Data.OleDb.OleDbParameter("MB1IncomingAir", System.Data.OleDb.OleDbType.VarWChar, 50, "MB1IncomingAir"), New System.Data.OleDb.OleDbParameter("MB1OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "MB1OrderIndex"), New System.Data.OleDb.OleDbParameter("MB2Casing", System.Data.OleDb.OleDbType.VarWChar, 50, "MB2Casing"), New System.Data.OleDb.OleDbParameter("MB2IncomingAir", System.Data.OleDb.OleDbType.VarWChar, 50, "MB2IncomingAir"), New System.Data.OleDb.OleDbParameter("MB2OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "MB2OrderIndex"), New System.Data.OleDb.OleDbParameter("NumFilts0", System.Data.OleDb.OleDbType.[Integer], 0, "NumFilts0"), New System.Data.OleDb.OleDbParameter("NumFilts1", System.Data.OleDb.OleDbType.[Integer], 0, "NumFilts1"), New System.Data.OleDb.OleDbParameter("NumFilts2", System.Data.OleDb.OleDbType.[Integer], 0, "NumFilts2"), New System.Data.OleDb.OleDbParameter("NumFins0", System.Data.OleDb.OleDbType.[Integer], 0, "NumFins0"), New System.Data.OleDb.OleDbParameter("NumFins1", System.Data.OleDb.OleDbType.[Integer], 0, "NumFins1"), New System.Data.OleDb.OleDbParameter("NumFins2", System.Data.OleDb.OleDbType.[Integer], 0, "NumFins2"), New System.Data.OleDb.OleDbParameter("NumPreFilts0", System.Data.OleDb.OleDbType.[Integer], 0, "NumPreFilts0"), New System.Data.OleDb.OleDbParameter("NumPreFilts1", System.Data.OleDb.OleDbType.[Integer], 0, "NumPreFilts1"), New System.Data.OleDb.OleDbParameter("NumPreFilts2", System.Data.OleDb.OleDbType.[Integer], 0, "NumPreFilts2"), New System.Data.OleDb.OleDbParameter("PreFilt0", System.Data.OleDb.OleDbType.VarWChar, 50, "PreFilt0"), New System.Data.OleDb.OleDbParameter("PreFilt1", System.Data.OleDb.OleDbType.VarWChar, 50, "PreFilt1"), New System.Data.OleDb.OleDbParameter("PreFilt2", System.Data.OleDb.OleDbType.VarWChar, 50, "PreFilt2"), New System.Data.OleDb.OleDbParameter("TubeThickness0", System.Data.OleDb.OleDbType.[Single], 0, "TubeThickness0"), New System.Data.OleDb.OleDbParameter("TubeThickness1", System.Data.OleDb.OleDbType.[Single], 0, "TubeThickness1"), New System.Data.OleDb.OleDbParameter("TubeThickness2", System.Data.OleDb.OleDbType.[Single], 0, "TubeThickness2"), New System.Data.OleDb.OleDbParameter("CoilType4", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilType4"), New System.Data.OleDb.OleDbParameter("FinMaterial4", System.Data.OleDb.OleDbType.VarWChar, 50, "FinMaterial4"), New System.Data.OleDb.OleDbParameter("Coil4OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Coil4OrderIndex"), New System.Data.OleDb.OleDbParameter("Original_SectionDetailsID", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SectionDetailsID", System.Data.DataRowVersion.Original, Nothing)})
      '
      'form_unit_info
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
      Me.BackColor = System.Drawing.SystemColors.Control
      Me.ClientSize = New System.Drawing.Size(742, 486)
      Me.Controls.Add(Me.cmd_close_2)
      Me.Controls.Add(Me.lblTag)
      Me.Controls.Add(Me.Label32)
      Me.Controls.Add(Me.lllCatalog)
      Me.Controls.Add(Me.btnClose)
      Me.Controls.Add(Me.SSTab2)
      Me.Cursor = System.Windows.Forms.Cursors.Default
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Location = New System.Drawing.Point(59, 120)
      Me.Name = "form_unit_info"
      Me.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
      Me.Text = "Unit Info"
      CType(Me.picMixingBox, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.picDischarge2, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.picDischarge1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.picSpace3, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.picSpace2, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.picSpace1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.picElectricHeater, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.picCoolingCoil, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.picHeatingCoil, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.picHouseFan2, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.picHouseFan1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.picPlenumFan, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.picPreFilterBag, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.picFilter, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.picAirBlender, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.picSplit, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.picGasHeater, System.ComponentModel.ISupportInitialize).EndInit()
      Me.SSTab2.ResumeLayout(False)
      Me._SSTab2_TabPage0.ResumeLayout(False)
        ''CType(Me.dgrC1Select, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AirHandlerData1, System.ComponentModel.ISupportInitialize).EndInit()
      Me._SSTab2_TabPage1.ResumeLayout(False)
      Me.panDragSections.ResumeLayout(False)
      Me.panDragSections.PerformLayout()
      CType(Me.picBlank, System.ComponentModel.ISupportInitialize).EndInit()
        ''CType(Me.dgrC1SectionInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me._SSTab2_TabPage2.ResumeLayout(False)
      Me.panFF3Container.ResumeLayout(False)
      Me.panFF3PreFilter.ResumeLayout(False)
      Me.panFF3FinalFilter.ResumeLayout(False)
      Me.panFF2Container.ResumeLayout(False)
      Me.panFF2FinalFilter.ResumeLayout(False)
      Me.panFF2Prefilter.ResumeLayout(False)
      Me.panFF1Container.ResumeLayout(False)
      Me.panFF1FinalFilter.ResumeLayout(False)
      Me.panFF1Prefilter.ResumeLayout(False)
      Me.panMB2Container.ResumeLayout(False)
      Me.panMixingBox2.ResumeLayout(False)
      Me.panMB1Container.ResumeLayout(False)
      Me.panMixingBox1.ResumeLayout(False)
      Me._SSTab2_TabPage3.ResumeLayout(False)
      Me.panFan3Container.ResumeLayout(False)
      Me.panFan3Fan.ResumeLayout(False)
      Me.panFan3Motor.ResumeLayout(False)
      Me.panFan2Container.ResumeLayout(False)
      Me.panFan2Fan.ResumeLayout(False)
      Me.panFan2Motor.ResumeLayout(False)
      Me.panFan1Container.ResumeLayout(False)
      Me.panFan1Fan.ResumeLayout(False)
      Me.panFan1Motor.ResumeLayout(False)
      Me._SSTab2_TabPage4.ResumeLayout(False)
      Me.panGasHeaterContainer.ResumeLayout(False)
      Me.panGasHeater.ResumeLayout(False)
      Me.panGasHeater.PerformLayout()
      Me.panCoil4Container.ResumeLayout(False)
      Me.panCoil4.ResumeLayout(False)
      Me.panCoil3Container.ResumeLayout(False)
      Me.panCoil3.ResumeLayout(False)
      Me.panCoil5Container.ResumeLayout(False)
      Me.panCoil5.ResumeLayout(False)
      Me.panCoil2Container.ResumeLayout(False)
      Me.panCoil2.ResumeLayout(False)
      Me.panCoil1Container.ResumeLayout(False)
      Me.panCoil1.ResumeLayout(False)
      Me.panC3Container.ResumeLayout(False)
      Me.panC3.ResumeLayout(False)
      Me._SSTab2_TabPage5.ResumeLayout(False)
      Me.panDischargeContainer.ResumeLayout(False)
      Me.Panel11.ResumeLayout(False)
      Me.Panel12.ResumeLayout(False)
      Me.Panel10.ResumeLayout(False)
      Me.Panel9.ResumeLayout(False)
      Me.panSectionsSummaryHeader.ResumeLayout(False)
      Me.Panel8.ResumeLayout(False)
      Me.Panel6.ResumeLayout(False)
      Me.Panel6.PerformLayout()
      Me.Panel7.ResumeLayout(False)
      Me.panSectionQuantities.ResumeLayout(False)
      Me.Panel3.ResumeLayout(False)
      Me.Panel1.ResumeLayout(False)
      Me.Panel4.ResumeLayout(False)
      Me.Panel2.ResumeLayout(False)
      Me.Panel5.ResumeLayout(False)
      CType(Me.cbo_coil_type, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cbo_drive_type, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cbo_fan_class, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cbo_fan_iso, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cbo_fan_size, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cbo_fan_type, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cbo_ff, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cbo_ff_sets, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cbo_fin_thickness, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cbo_fins, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cbo_hp, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cbo_mixing_box, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cbo_pre_ff, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cbo_pre_sets, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cbo_rows, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cbo_rpm, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cbo_tube_thickness, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ck_MB1_al, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ck_MB1_gal, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ck_al, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ck_cu, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ck_ff_sets, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ck_gal, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ck_high, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ck_odp, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ck_pre_sets, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ck_premium, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ck_ss, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ck_tefc, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.lbl_MB1_cost, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.lbl_casing, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.lbl_coil_cost, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.lbl_coil_type, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.lbl_eff, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.lbl_enclosure, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.lbl_fan_cost, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.lbl_fan_info, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.lbl_fan_type, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.lbl_fan_weight, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.lbl_ff, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.lbl_ff_cost, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.lbl_ff_weight, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.lbl_fin_mtl, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.lbl_fin_thickness, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.lbl_hp, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.lbl_iso_cost, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.lbl_iso_weight, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.lbl_motor_cost, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.lbl_motor_info, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.lbl_motor_weight, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.lbl_num_fins, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.lbl_num_rows, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.lbl_rpm, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.lbl_tube_thickness, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DseProject1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
#End Region


#Region "Routine descriptions"
   '______________________________________________________________________________________________
   '//                     """"""""""""""""""""""""""
   '//                     ""      Subroutines     ""
   '//                     """"""""""""""""""""""""""
   '//
   '// BlenderCosts(BlenderCost).............. This sub prices the air blender
   '// CoilTypeLoad2(coilset, coiltype)....... This sub loads the required coil selection
   '//                                             info...
   '// LoadFan(fanIndex, fansel)................ This sub loads the fan selection info
   '//                                             for a selected set of fans
   '// LoadFilter(ffset, ffsel)............... This sub loads the filter selections
   '// SetMaterialPriceAndWeights().............. This sub holds the cost per ft^2 and the weight
   '// MB1Load(mbset)......................... This sub loads the mixing box selections
   '// MotorCostAndWeight(index).............. Costs the fan motor and gives the weight
   '// FillPlenumFanSize(index)....................... This sub loads the plenum fan sizes
   '// Selection(Index)....................... This sub checks to see what section was chosen and
   '//                                             then adds up the differnet items needed for
   '//                                             each section such as air seals and doors
   '// CoilCost(rows, coilbasecost)........... This sub will calculate the cost of the selected
   '//                                             coil
   '// Costs.................................. Includes the Cost of material given by Jay Kindle
   '//                                             and the summing up of the different costs
   '//                                             of the air handling units.
   '// SetFilterPriceAndWeight(prefilter, filter, sets)....... This sub will retreive the price of the selected
   '//                                             filter and spare filters
   '// FillHousedFanSize(index)....................... This sub fills the Housed fan sizes of both
   '//                                             the BI and FC fans
   '// MaterialCosts(unit,L,W,H,cost,weight).. This sub figures the Cost of the material used
   '//                                             in a unit and sends the cost to the Costs sub
   '// HeaterKW()............................. This sub finds the minimum airflow of the selected
   '//                                             model and then calculates the KW's at 100, 75,
   '//                                             50, and 25 delta T's.  Then it loads them into
   '//                                             the combo box to be selected.
   '// MixingBoxCost()........................ This sub takes all the selected options for the
   '//                                             mixing box and returns the cost of the
   '//                                             mixing box.
   '// SetHousedFanPriceAndWeight(index)......................... This sub prices the housed fans
   '// PricePF1(index)........................ This sub prices the plenum fans by fan size
   '//                                             and class
   '// SelectionCheck()....................... This sub checks to make sure the user has made all
   '//                                             the selections needed to correctly price
   '//                                             the air handler
   '// WriteInfo()............................ This sub collects all of the information selected
   '//                                             in the unit_info form and writes it to a
   '//                                             database when the form is closed.  This
   '//                                             allows the information selected for the
   '//                                             unit to be temporarily saved to be referenced
   '//                                             by the CallInfo() sub if the user wants to
   '//                                             veiw or change the info selected
   '// PrintInfo()............................ This sub will fill the printinitinfo database
   '//                                             with the required info to print the report
   '// Volt460(volts)......................... This sub takes the voltage and kw to find the
   '//                                             cost of the heater
   '// Volt230(volts)......................... This sub takes the voltage and kw to find the
   '//                                             cost of the heater
   '// Volt208(volts)......................... This sub takes the voltage and kw to find the
   '//                                             cost of the heater
   '// FindHFPrice(volts, totalList).......... This sub reads the voltage and kw to send back a
   '//                                             total price for the heater, min stages,
   '//                                             and other options
   '// Form_LOAD()............................ Loads the cbo boxes and lists in the form
   '// CheckForInfo()......................... This sub checks to see if there is data
   '//                                             stored in the database and reloads it
   '//                                             if it is there...
   '// ReadInfo()............................. Fills the form with the saved info
   '// Form_Unload().......................... This sub will write the info selected by the
   '//                                             user into a database to be read back if
   '//                                             required
   '______________________________________________________________________________________________
#End Region


#Region "Unfinished"


   'UPGRADE_WARNING: Event ck_ATT_3.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
   Private Sub ck_ATT_3_CheckStateChanged(ByVal eventSender As System.Object, _
   ByVal eventArgs As System.EventArgs)
      'Handles ck_ATT_3.CheckStateChanged

      If ck_ATT_3.CheckState = 1 Then

         ck_ATT_4.CheckState = System.Windows.Forms.CheckState.Unchecked
         ck_ATT_5.CheckState = System.Windows.Forms.CheckState.Unchecked

      End If

   End Sub


   'UPGRADE_WARNING: Event ck_ATT_4.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
   Private Sub ck_ATT_4_CheckStateChanged(ByVal eventSender As System.Object, _
   ByVal eventArgs As System.EventArgs)
      'Handles ck_ATT_4.CheckStateChanged

      If ck_ATT_4.CheckState = 1 Then

         ck_ATT_3.CheckState = System.Windows.Forms.CheckState.Unchecked
         ck_ATT_5.CheckState = System.Windows.Forms.CheckState.Unchecked

      End If

   End Sub


   'UPGRADE_WARNING: Event ck_ATT_5.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
   Private Sub ck_ATT_5_CheckStateChanged(ByVal eventSender As System.Object, _
   ByVal eventArgs As System.EventArgs)
      'Handles ck_ATT_5.CheckStateChanged

      If ck_ATT_5.CheckState = 1 Then
         ck_ATT_3.CheckState = System.Windows.Forms.CheckState.Unchecked
         ck_ATT_4.CheckState = System.Windows.Forms.CheckState.Unchecked

      End If

   End Sub


   'UPGRADE_WARNING: Event ck_ATT.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
   Private Sub ck_ATT_CheckStateChanged(ByVal eventSender As System.Object, _
   ByVal eventArgs As System.EventArgs)
      'Handles ck_ATT.CheckStateChanged

      If ck_ATT.CheckState = 1 Then

         lbl_ATT_sound_att.Visible = True
         ck_ATT_3.Visible = True
         ck_ATT_4.Visible = True
         ck_ATT_5.Visible = True

      Else

         lbl_ATT_sound_att.Visible = False
         ck_ATT_3.Visible = False
         ck_ATT_4.Visible = False
         ck_ATT_5.Visible = False

      End If

   End Sub


#End Region

   Private TotalHours As Double

#Region " Event Handlers"



   Private Sub form_Load(ByVal sender As Object, ByVal e As EventArgs) _
   Handles MyBase.Load
      Dim i As Integer
      Dim airflow As Single
      Dim message As String
      Dim sectionEnum As sectionAbbreviation
      Dim dviSection As DataView


      ' sets connection strings
      Me.OleDbConnection1.ConnectionString = DataAccess.Common.GetConnectionString(DataAccess.Common.AirHandlerProjectsDbPath)

      ' authorizes pricing for employees and those with pricing privileges
      pricingAuthorized = (AppInfo.User.authority_group = user_group.employee) _
         OrElse ((AppInfo.User.access_level = access_level.TSI_P) OrElse (AppInfo.User.access_level = access_level.ALL_P))

      'gets project data from first form
      Me.DseProject1.Clear()
      Me.DseProject1 = Me.Daddy.DseProject1
      ' gets row index of air handler to be modified
      Me.airHandlerIndex = Me.GetAirHandlerIndex(Me.AirHandlerID)
      ' sets air flow
      airflow = Me.DseProject1.SavedAirHandler(airHandlerIndex).Airflow


      Dim airHandlersTable As ReferenceData.CoilsDataTable

      Try
         ' retrieves air handler information for airflow parameter
         airHandlersTable = DataAgent.RetrieveAirHandlers(airflow)
         Me.AirHandlerData1.Merge(airHandlersTable)
      Catch dbEx As System.Data.OleDb.OleDbException
         message = "An exception occurred while attempting to retrieve coil sizes. " & dbEx.Message
         Ui.MessageBox.Show(message) : Exit Sub
      End Try
      ' checks if any air handlers were found
      If (airHandlersTable Is Nothing) _
      Or airHandlersTable.Rows.Count = 0 Then
         message = "There are no air handlers matching the selection criteria."
         Ui.MessageBox.Show(message, MessageBoxIcon.Warning)
         Me.Close() : Exit Sub
      End If

      'adds data bindings
      Try
         Me.AddDatabindings()
      Catch Ex1 As Exception
         MessageBox.Show("Attempt to add data bindings failed. " & Ex1.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

      ' sets container controls text property
      ' text property for panel isn't shown in property window
      'UPDATE: when adding section
      Me.panMB1Container.Text = "-1"
      Me.panMB2Container.Text = "-1"
      Me.panFF1Container.Text = "-1"
      Me.panFF2Container.Text = "-1"
      Me.panFF3Container.Text = "-1"
      Me.panFan1Container.Text = "-1"
      Me.panFan2Container.Text = "-1"
      Me.panFan3Container.Text = "-1"
      Me.panCoil1Container.Text = "-1"
      Me.panCoil2Container.Text = "-1"
      Me.panCoil3Container.Text = "-1"
      Me.panCoil4Container.Text = "-1"
      Me.panCoil5Container.Text = "-1"
      Me.panC3Container.Text = "-1"
      Me.panDischargeContainer.Text = "-1"
      Me.panGasHeaterContainer.Text = "-1"

        ' fills datagrid with air handlers that match selection criteria
        ' Note: directly setting datasource resets column settings ex. Datasource = dataset
        ''Me.dgrC1Select.SetDataBinding(Me.AirHandlerData1, "Coils", True)

        ' fills Mixing Box comboboxes
        For i = 0 To 1
         ' Outside Air, Return Air
         Me.cbo_mixing_box(i).Items.AddRange(New Object() {"None", "OA", "RA", "OA & RA"})
      Next
      ' fills Filter comboboxes and fan horsepower comboboxes
      For i = 0 To 2
         Me.cbo_pre_ff(i).Items.AddRange(New Object() {"No filter", "2in. 30% Pleated", "4in. 30% Pleated"})
         Me.cbo_ff(i).Items.AddRange(New Object() {"No final filter", "12in. 65% Pleated", "12in. 85% Pleated", "12in. 95% Pleated"})
         '// Load the Spare Sets, 0-3
         Me.cbo_pre_sets(i).Items.AddRange(New Object() {"0", "1", "2", "3"})
         Me.cbo_ff_sets(i).Items.AddRange(New Object() {"0", "1", "2", "3"})
         Me.cbo_hp(i).Items.AddRange(Me.GetFanHorsepowers())
         'selects first option as default to prevent null value
         Me.cbo_hp(i).SelectedIndex = 0
      Next
      '//Load C3 extra stages
      Me.cbo_C3_extra_stages.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5"})

      'fills saved info
      '--------------------------
      Me.lblTag.Text = Me.DseProject1.SavedAirHandler(Me.airHandlerIndex).Tag

      Me.DseProject1._Section.Clear()
      Me.dadSection.SelectCommand.Parameters(0).Value = Me.AirHandlerID
      Me.dadSection.Fill(Me.DseProject1._Section)
        'fills sections dataset/datagrid
        ''Me.dgrC1SectionInfo.DataSource = Me.DseProject1._Section
        ''Me.FormatSectionDatagrid()


        'forces selection of model in datagrid
        Dim cabinetIndex As Integer
      If Me.DseProject1.SavedAirHandler(Me.airHandlerIndex).IsCabinetIndexNull Then
         cabinetIndex = -1
      Else
         cabinetIndex = ConvertNull.ToInteger(Me.DseProject1.SavedAirHandler(Me.airHandlerIndex).CabinetIndex, -1)
      End If
      
      Dim airHandlerHasChanges As Boolean = False
      If cabinetIndex > -1 Then
         airHandlerHasChanges = (Me.DseProject1.SavedAirHandler(Me.airHandlerIndex).RowState <> DataRowState.Unchanged)
         'selects saved model
         Me.SelectModel(cabinetIndex)
         If Not airHandlerHasChanges Then
            '>> accepts changes to selected air handler b/c in this case the model was not
            '   changed and the tag, airflow, etc. didn't change but SelectModel() changes
            '   rowstate to modified anyways
            '>> accepts changes, so that if no changes are made before closing, message
            '   asking if user wants to save won't appear
            Me.DseProject1.SavedAirHandler.Rows(Me.airHandlerIndex).AcceptChanges()
         End If
         Me.gPreviousRow = cabinetIndex
         Me.gSelectedRow = cabinetIndex
      Else
         'selects first model as default
         Me.SelectModel(0)
         'sets dataset cabinetIndex to 0 as default
         Me.DseProject1.SavedAirHandler.Rows(Me.airHandlerIndex)(Me.DseProject1.SavedAirHandler.CabinetIndexColumn) = 0
         Me.gPreviousRow = 0
         Me.gSelectedRow = 0
      End If

      Me.populateC5Powers(Me.DseProject1.SavedAirHandler(Me.airHandlerIndex).ModelNumber)

      'fills section details dataset which fills controls
      Try
         Me.DseProject1.SectionDetails.Clear()
         Me.dadSectionDetails.SelectCommand.Parameters(0).Value = Me.DseProject1.SavedAirHandler(Me.airHandlerIndex).AirHandlerID
         Me.dadSectionDetails.Fill(Me.DseProject1.SectionDetails)
         If Me.DseProject1.SectionDetails.Rows.Count = 0 Then
            Me.AddSectionDetailsRow()
         End If
      Catch Ex As Exception
         MessageBox.Show("Attempt to open section details failed." & Environment.NewLine & _
            Environment.NewLine & Ex.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

      'sorts sections by order index so that they're inserted in order
      Try
         dviSection = Me.DseProject1._Section.DefaultView
         dviSection.Sort = "OrderIndex ASC"
         For i = 0 To dviSection.Count - 1
            sectionEnum = Me.ConvertToEnum(dviSection(i)("Abbreviation"), GetType(sectionAbbreviation))
            'fills drawings
            Me.InsertSectionDrawing(sectionEnum)
            'fills controls
            Me.InsertSectionControls(sectionEnum, i)
         Next
      Catch Ex2 As Exception
         MessageBox.Show("Attempt to retrieve saved section data failed. " & Ex2.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try


      'shows each tab b/c bound controls are not filled until shown
      For i = 0 To Me.SSTab2.TabPages.Count - 1
         Me.SSTab2.TabPages(i).Show()
      Next

   End Sub


#Region "Combobox Events"

   'removed _TextChanged event
   Private Sub cbo_C3_extra_stages_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) _
   Handles cbo_C3_extra_stages.SelectedIndexChanged
      If IsInitializing = False Then
         Dim volts As Integer

         volts = CInt(Me.Daddy.cbo_voltage.SelectedItem)
         '// The different Voltage subs find the cost for the heater with the additional stages
         If volts = 460 Then
            Volt460(volts)
         ElseIf volts = 230 Then
            Volt230(volts)
         ElseIf volts = 208 Then
            Volt208(volts)
         End If
      End If
   End Sub


   'removed _TextChanged event
   Private Sub cbo_C3_kw_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
   Handles cbo_C3_kw.SelectedIndexChanged
      If IsInitializing = False Then
         Dim volts As Short

         volts = CInt(Me.Daddy.cbo_voltage.SelectedItem)

         '// Finds the cost of the heater for the given voltage
         If volts = 460 Then
            Volt460(volts)
         ElseIf volts = 230 Then
            Volt230(volts)
         ElseIf volts = 208 Then
            Volt208(volts)
         End If
      End If
   End Sub


   'sets isolator price and weight
   Private Sub cbo_fan_iso_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbo_fan_iso.SelectedIndexChanged
      If Me.IsInitializing = False Then
         Dim Index As Short = cbo_fan_iso.GetIndex(eventSender)

         '// Check to see what type of Isolation was selected
         '// If None is selected then iso cost is 0
         If cbo_fan_iso(Index).SelectedItem = "None" Or _
         Me.cbo_fan_iso(Index).SelectedItem = Nothing Then
            lbl_iso_cost(Index).Text = Format(0, "C")
            lbl_iso_weight(Index).Text = CStr(0)
            '// If rubber add the cost of four ND-type C Neoprene Mounts
            '// Use type C because that will cover the heavier fans
         ElseIf cbo_fan_iso(Index).SelectedItem = "Rubber" Then
            lbl_iso_cost(Index).Text = Format(4 * 28, "C")
            lbl_iso_weight(Index).Text = CStr(4 * 1.5)
            '// If 1in Open spring is chosen then the cost of an SLFH A type Mason spring is $50
         ElseIf cbo_fan_iso(Index).SelectedItem = "1in. Open" Then
            lbl_iso_cost(Index).Text = Format(4 * 50, "C")
            lbl_iso_weight(Index).Text = CStr(4 * 1)
            '// 2in Open SLFH B type Mason springs cost $67
         ElseIf cbo_fan_iso(Index).SelectedItem = "2in. Open" Then
            lbl_iso_cost(Index).Text = Format(4 * 67, "C")
            lbl_iso_weight(Index).Text = CStr(4 * 4)
            '// If 1in seismic spring is chosen then the cost of an SLFH A type Mason spring is $50
         ElseIf cbo_fan_iso(Index).SelectedItem = "1in. Seismic" Then
            lbl_iso_cost(Index).Text = Format(4 * 120, "C")
            lbl_iso_weight(Index).Text = CStr(4 * 8)
            '// 2in seismic SLFH B type Mason springs cost $67
         ElseIf cbo_fan_iso(Index).SelectedItem = "2in. Seismic" Then
            lbl_iso_cost(Index).Text = Format(4 * 180, "C")
            lbl_iso_weight(Index).Text = CStr(4 * 14)
         End If

         ' TODO: move mason multiplier
         '// The Mason Multiplier given by Linda is .92
         lbl_iso_cost(Index).Text = (Convert.UsCurrencyToDouble(Me.lbl_iso_cost(Index).Text) * 0.92).ToString("c")
      End If
   End Sub


   'removed _TextChanged event
   Private Sub cbo_ff_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
   Handles cbo_ff.SelectedIndexChanged
      If IsInitializing = False Then
         Dim Index As Short = cbo_ff.GetIndex(sender)
         SetFilterPriceAndWeight(Index)
      End If
   End Sub


   'removed _TextChanged event
   Private Sub cbo_ff_sets_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbo_ff_sets.SelectedIndexChanged
      If IsInitializing = False Then
         Dim Index As Short = cbo_ff_sets.GetIndex(eventSender)
         SetFilterPriceAndWeight(Index)
      End If
   End Sub


   'removed _TextChanged event
   Private Sub cbo_fin_thickness_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
   Handles cbo_fin_thickness.SelectedIndexChanged
      If Me.IsInitializing = False Then
         Dim index As Short = cbo_fin_thickness.GetIndex(sender)
         Me.setCoilCostControlValue(index)
      End If
   End Sub


   'removed _TextChanged event
   Private Sub cbo_fins_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
   Handles cbo_fins.SelectedIndexChanged
      If Me.IsInitializing = False Then
         Dim index As Short = cbo_fins.GetIndex(sender)
         Dim previousThickness As Double

         'gets previous item
         previousThickness = Round(ConvertNull.ToDouble(Me.cbo_fin_thickness(index).Text), 3)

         'if previous thickness is 0 or less then don't try to choose previous thickness
         If previousThickness > 0 Then
            'added per Jay on 1/27/2005
            'hides 0.006 fin thickness if fpi is less than 8
            Me.cbo_fin_thickness(index).Items.Clear()
            If CInt(Me.cbo_fins(index).Text) < 8 Then
               Me.cbo_fin_thickness(index).Items.AddRange(New Object() {0.008, 0.01})
               '0.006 is no longer an option select 0.008 as default
               If previousThickness = 0.006 Then
                  Me.cbo_fin_thickness(index).SelectedIndex = 0
                  'selecting index doesn't change text, so set text property as well
                  Me.cbo_fin_thickness(index).Text = Me.cbo_fin_thickness(index).SelectedItem
               Else
                  'selects index to match text
                  Me.cbo_fin_thickness(index).SelectedIndex = Me.cbo_fin_thickness(index).Items.IndexOf(CDbl(Me.cbo_fin_thickness(index).Text))
               End If
            Else
               'adds all items in case 0.006 was removed earlier
               Me.cbo_fin_thickness(index).Items.AddRange(New Object() {0.006, 0.008, 0.01})
               'selects index to match text
               Me.cbo_fin_thickness(index).SelectedIndex = Me.cbo_fin_thickness(index).Items.IndexOf(CDbl(Me.cbo_fin_thickness(index).Text))
            End If

            Me.setCoilCostControlValue(index)
         End If
      End If
   End Sub


   Private Sub cbo_mixing_box_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
   Handles cbo_mixing_box.TextChanged
      If IsInitializing = False Then
         Dim index As Short = cbo_mixing_box.GetIndex(sender)

         'calculates mixing box cost and sets textbox
         Me.MixingBoxCost(index)

         If Me.cbo_mixing_box(index).Text = "None" Then
            ck_MB1_al(index).Enabled = False
            ck_MB1_gal(index).Enabled = False
         Else
            ck_MB1_al(index).Enabled = True
            ck_MB1_gal(index).Enabled = True
         End If
      End If
   End Sub


   'removed _TextChanged event
   Private Sub cbo_pre_ff_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
   Handles cbo_pre_ff.SelectedIndexChanged
      If IsInitializing = False Then
         Dim index As Short = cbo_pre_ff.GetIndex(sender)
         Me.SetFilterPriceAndWeight((index))
      End If
   End Sub


   'removed _TextChanged event
   Private Sub cbo_pre_sets_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
   Handles cbo_pre_sets.SelectedIndexChanged
      If IsInitializing = False Then
         Dim Index As Integer = cbo_pre_sets.GetIndex(sender)
         SetFilterPriceAndWeight(Index)
      End If
   End Sub


   'removed _TextChanged event
   Private Sub cbo_rows_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
   Handles cbo_rows.SelectedIndexChanged
      If Me.IsInitializing = False Then
         Dim index As Short = cbo_rows.GetIndex(sender)

         Me.setCoilCostControlValue(index)
      End If
   End Sub



   'removed _TextChanged event
   Private Sub cbo_tube_thickness_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
   Handles cbo_tube_thickness.SelectedIndexChanged
      If IsInitializing = False Then
         Dim index As Short = Me.cbo_tube_thickness.GetIndex(sender)
         Me.setCoilCostControlValue(index)
      End If
   End Sub


   '1. fills rpm combobox
   '2. fills fan size combobox
   '3. sets fan price and weight labels
   Private Sub cbo_hp_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
   Handles cbo_hp.SelectedIndexChanged
      If Me.IsInitializing = True Then
         Exit Sub
      End If

      Dim index As Integer = Me.cbo_hp.GetIndex(sender)

      If lbl_fan_type(index).Text.EndsWith("HF1)") _
      Or lbl_fan_type(index).Text.EndsWith("HF2)") Then
         'fills rpm combobox (costs motor on rpm changed)
         Me.FillMotorRPM(index)
         'fills fan size combobox
         Me.FillHousedFanSize(index)
         'sets fan price and weight labels
         SetHousedFanPriceAndWeight(index)
      ElseIf lbl_fan_type(index).Text.EndsWith("PF1)") Then
         'fills rpm combobox
         Me.FillMotorRPM(index)
         'fills fan size combobox
         Me.FillPlenumFanSize(index)
         'sets fan price and weight labels
         Me.updatePlenumFanControls(index)
      End If
   End Sub


   Private Sub cbo_rpm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles cbo_rpm.SelectedIndexChanged
      If Me.IsInitializing Then Exit Sub

      Dim index As Integer
      Dim motorTable As ReferenceData.MotorsDataTable

      index = cbo_rpm.GetIndex(sender)

      Me.updateMotorControls(index)

      ' sets fan price and weight
      If lbl_fan_type(index).Text.EndsWith("HF1)") Or lbl_fan_type(index).Text.EndsWith("HF2)") Then
         Me.SetHousedFanPriceAndWeight(index)
      ElseIf lbl_fan_type(index).Text.EndsWith("PF1)") Then
         updatePlenumFanControls(index)
      End If

   End Sub


   'fills fan size combobox and sets fan price and weight labels
   Private Sub cbo_fan_type_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) _
   Handles cbo_fan_type.SelectedIndexChanged
      If Me.IsInitializing = False Then
         Dim Index As Short = cbo_fan_type.GetIndex(eventSender)

         'fills fan size combobox and sets fan price and weight labels
         If Me.lbl_fan_type(Index).Text.EndsWith("HF1)") Or Me.lbl_fan_type(Index).Text.EndsWith("HF2)") Then
            Me.FillHousedFanSize(Index)
            Me.SetHousedFanPriceAndWeight(Index)
         ElseIf lbl_fan_type(Index).Text.EndsWith("PF1)") Then
            Me.FillPlenumFanSize(Index)
            Me.updatePlenumFanControls(Index)
         End If
      End If
   End Sub


   'sets fan price and weight
   Private Sub cbo_fan_size_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) _
   Handles cbo_fan_size.SelectedIndexChanged
      If Me.IsInitializing = False Then
         Dim Index As Short = cbo_fan_size.GetIndex(eventSender)

         'sets fan price and weight
         If lbl_fan_type(Index).Text.EndsWith("HF1)") Or lbl_fan_type(Index).Text.EndsWith("HF2)") Then
            SetHousedFanPriceAndWeight(Index)
         ElseIf lbl_fan_type(Index).Text.EndsWith("PF1)") Then
            updatePlenumFanControls((Index))
         End If
      End If
   End Sub



   Private Sub cbo_fan_size_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) _
   Handles cbo_fan_size.Enter
      Dim Index As Short = cbo_fan_size.GetIndex(eventSender)

      If cbo_fan_type(Index).SelectedIndex = -1 Then
         MessageBox.Show( _
            "A fan type must be selected before the related fan sizes are displayed.", _
            "RAESolutions", _
            MessageBoxButtons.OK, _
            MessageBoxIcon.Information)
         Exit Sub
      ElseIf cbo_fan_class(Index).SelectedIndex = -1 Then
         MessageBox.Show( _
            "A fan class must be selected before the related fan sizes are displayed.", _
            "RAESolutions", _
            MessageBoxButtons.OK, _
            MessageBoxIcon.Information)
         Exit Sub
      End If

      'fills fan size combobox
      If lbl_fan_type(Index).Text.EndsWith("HF1)") Or lbl_fan_type(Index).Text.EndsWith("HF2)") Then
         FillHousedFanSize(Index)
      ElseIf lbl_fan_type(Index).Text.EndsWith("PF1)") Then
         FillPlenumFanSize(Index)
      End If
   End Sub


   Private Sub cbo_C3_kw_Enter(ByVal sender As Object, ByVal e As EventArgs) _
   Handles cbo_C3_kw.Enter
      '// This sub populates the KW combo box
      HeaterKW()
   End Sub


#End Region


#Region " Checkbox Events"

   'UPGRADE_WARNING: Event ck_cu.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
   Private Sub ck_cu_CheckStateChanged(ByVal sender As Object, ByVal e As EventArgs) _
   Handles ck_cu.CheckStateChanged
      Dim index As Short = ck_cu.GetIndex(sender)
      Dim value As String = "Copper"

      If ck_cu(index).CheckState = 1 Then
         ck_al(index).Checked = False
         If index = 0 Then
            ' TODO: Me.lbl_fin_mtl(index).Text = value
            Me.lblFinMaterial1.Text = value
         ElseIf index = 1 Then
            Me.lblFinMaterial2.Text = value
         ElseIf index = 2 Then
            Me.lblFinMaterial3.Text = value
         ElseIf index = 3 Then
            Me.lblFinMaterial4.Text = value
         ElseIf index = 4 Then
            Me.lblFinMaterial5.Text = value
         Else
            MessageBox.Show("There is no index " & index.ToString & " in order set the coil fin material.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End If
      End If

      Me.setCoilCostControlValue(index)
   End Sub


   'UPGRADE_WARNING: Event ck_gal.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
   Private Sub ck_gal_CheckStateChanged(ByVal sender As Object, ByVal e As EventArgs) _
   Handles ck_gal.CheckStateChanged
      Dim index As Short = Me.ck_gal.GetIndex(sender)
      Dim value As String = "Galvanized steel"

      If ck_gal(index).CheckState = 1 Then
         ck_ss(index).Checked = False
         If index = 0 Then
            Me.lblCoilCasing1.Text = value
         ElseIf index = 1 Then
            Me.lblCoilCasing2.Text = value
         ElseIf index = 2 Then
            Me.lblCoilCasing3.Text = value
         ElseIf index = 3 Then
            Me.lblCoilCasing4.Text = value
         ElseIf index = 4 Then
            Me.lblCoilCasing5.Text = value
         Else
            MessageBox.Show("Coil casing index out of range. Index = " & index.ToString, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End If
      End If

      Me.setCoilCostControlValue(index)
   End Sub


   Private Sub ck_MB1_al_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles ck_MB1_al.CheckStateChanged
      If Me.IsInitializing = True Then
         Exit Sub
      End If

      Dim index As Integer = ck_MB1_al.GetIndex(sender)

      If ck_MB1_al(index).Checked Then
         ck_MB1_gal(index).Checked = False

         If index = 0 Then
            Me.lblMB1CasingChkValue.Text = "Aluminum"
         ElseIf index = 1 Then
            Me.lblMB2CasingChkValue.Text = "Aluminum"
         End If
      End If

      Me.MixingBoxCost(index)
   End Sub


   Private Sub ck_MB1_gal_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) _
   Handles ck_MB1_gal.CheckStateChanged
      Dim Index As Short = ck_MB1_gal.GetIndex(eventSender)

      If ck_MB1_gal(Index).CheckState = 1 Then
         ck_MB1_al(Index).CheckState = System.Windows.Forms.CheckState.Unchecked

         If Index = 0 Then
            Me.lblMB1CasingChkValue.Text = "Galvanized"
         ElseIf Index = 1 Then
            Me.lblMB2CasingChkValue.Text = "Galvanized"
         End If
      End If

      Me.MixingBoxCost(Index)
   End Sub


   'Enclosure, ODP
   Private Sub ck_odp_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles ck_odp.CheckStateChanged
      If Me.IsInitializing Then
         Exit Sub
      End If

      Dim index As Short = ck_odp.GetIndex(sender)
      'Dim motorInfo As CostWeight

      If ck_odp(index).Checked = True Then
         ck_tefc(index).Checked = False
         'mod_GlobalVariables.FanEnc(index) = "ODP"
         If index = 0 Then
            Me.lblEnclosure1.Text = "ODP"
         ElseIf index = 1 Then
            Me.lblEnclosure2.Text = "ODP"
         ElseIf index = 2 Then
            Me.lblEnclosure3.Text = "ODP"
         End If
      End If

      Me.updateMotorControls(index)

      '// Price the fan...
      If lbl_fan_type(index).Text.EndsWith("HF1)") Or lbl_fan_type(index).Text.EndsWith("HF2)") Then
         SetHousedFanPriceAndWeight(index)
      ElseIf lbl_fan_type(index).Text.EndsWith("PF1)") Then
         updatePlenumFanControls(index)
      End If

   End Sub


   'Enclosure, TEFC
   Private Sub ck_tefc_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles ck_tefc.CheckStateChanged
      If Me.IsInitializing Then Exit Sub

      Dim index As Short = ck_tefc.GetIndex(sender)

      If ck_tefc(index).Checked = True Then
         ck_odp(index).Checked = False
         'mod_GlobalVariables.FanEnc(index) = "TEFC"
         If index = 0 Then
            Me.lblEnclosure1.Text = "TEFC"
         ElseIf index = 1 Then
            Me.lblEnclosure2.Text = "TEFC"
         ElseIf index = 2 Then
            Me.lblEnclosure3.Text = "TEFC"
         End If
      End If

      Me.updateMotorControls(index)

      '// Price the fan...
      If lbl_fan_type(index).Text.EndsWith("HF1)") _
      Or lbl_fan_type(index).Text.EndsWith("HF2)") Then
         SetHousedFanPriceAndWeight(index)
      ElseIf lbl_fan_type(index).Text.EndsWith("PF1)") Then
         updatePlenumFanControls(index)
      End If
   End Sub


   'Efficiency, High
   Private Sub ck_high_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles ck_high.CheckStateChanged
      If Me.IsInitializing Then Exit Sub

      Dim index As Integer

      index = ck_high.GetIndex(sender)

      If Me.ck_high(index).Checked Then
         ck_premium(index).Checked = False
         If index = 0 Then
            Me.lblEfficiency1.Text = "High"
         ElseIf index = 1 Then
            Me.lblEfficiency2.Text = "High"
         ElseIf index = 2 Then
            Me.lblEfficiency3.Text = "High"
         End If
      End If

      Me.updateMotorControls(index)

      '// Price the fan...
      If lbl_fan_type(index).Text.EndsWith("HF1)") Or lbl_fan_type(index).Text.EndsWith("HF2)") Then
         SetHousedFanPriceAndWeight(index)
      ElseIf lbl_fan_type(index).Text.EndsWith("PF1)") Then
         updatePlenumFanControls(index)
      End If
   End Sub


   'Efficiency, Premium
   Private Sub ck_premium_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles ck_premium.CheckStateChanged
      If Me.IsInitializing Then Exit Sub

      Dim index As Integer

      index = ck_premium.GetIndex(sender)

      If ck_premium(index).Checked Then
         Me.ck_high(index).Checked = False
         If index = 0 Then
            Me.lblEfficiency1.Text = "Premium"
         ElseIf index = 1 Then
            Me.lblEfficiency2.Text = "Premium"
         ElseIf index = 2 Then
            Me.lblEfficiency3.Text = "Premium"
         End If
      End If

      Me.updateMotorControls(index)

      '// Price the fan...
      If lbl_fan_type(index).Text.EndsWith("HF1)") Or lbl_fan_type(index).Text.EndsWith("HF2)") Then
         SetHousedFanPriceAndWeight(index)
      ElseIf lbl_fan_type(index).Text.EndsWith("PF1)") Then
         updatePlenumFanControls((index))
      End If
   End Sub


   'UPGRADE_WARNING: Event ck_ss.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
   Private Sub ck_ss_CheckStateChanged(ByVal sender As Object, ByVal e As EventArgs) _
   Handles ck_ss.CheckStateChanged
      Dim index As Short = ck_ss.GetIndex(sender)
      Dim value As String = "Stainless steel"

      If ck_ss(index).CheckState = 1 Then
         ck_gal(index).Checked = False
         If index = 0 Then
            ' TODO: Me.lbl_casing(index).Text = value
            Me.lblCoilCasing1.Text = value
         ElseIf index = 1 Then
            Me.lblCoilCasing2.Text = value
         ElseIf index = 2 Then
            Me.lblCoilCasing3.Text = value
         ElseIf index = 3 Then
            Me.lblCoilCasing4.Text = value
         ElseIf index = 4 Then
            Me.lblCoilCasing5.Text = value
         Else
            MessageBox.Show("Coil casing index out of range. Index = " & index.ToString, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End If
      End If

      Me.setCoilCostControlValue(index)
   End Sub


   'UPGRADE_WARNING: Event ck_C3_disconnect.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
   Private Sub ck_C3_disconnect_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) _
   Handles ck_C3_disconnect.CheckStateChanged
      Dim volts As Integer

      volts = Me.Daddy.cbo_voltage.Text

      '// Run the costing of the heater
      If volts = 460 Then
         Volt460(volts)
      ElseIf volts = 230 Then
         Volt230(volts)
      ElseIf volts = 208 Then
         Volt208(volts)
      End If

   End Sub


   Private Sub ck_C3_scr_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) _
   Handles ck_C3_scr.CheckStateChanged
      If Me.IsInitializing = True Then
         Exit Sub
      End If

      Dim volts As Short

      volts = CInt(Me.Daddy.cbo_voltage.SelectedItem)

      '// Run the costing of the heater
      If volts = 460 Then
         Volt460(volts)
      ElseIf volts = 230 Then
         Volt230(volts)
      ElseIf volts = 208 Then
         Volt208(volts)
      End If
   End Sub


   Private Sub radD1_CheckedChanged(ByVal s As Object, ByVal e As EventArgs) _
   Handles radD1Floor.CheckedChanged, radD1Ceiling.CheckedChanged, radD1EndWall.CheckedChanged
      If Me.IsInitializing = True Then
         Exit Sub
      End If
      Dim value As String

      If Me.radD1Ceiling.Checked Then
         value = Me.radD1Ceiling.Text
      ElseIf Me.radD1EndWall.Checked Then
         value = Me.radD1EndWall.Text
      ElseIf Me.radD1Floor.Checked Then
         value = Me.radD1Floor.Text
      End If

      'sets label that is bound to dataset
      Me.lblDischargeLocationChkValue.Text = value
      'enables grating if floor checked
      Me.ck_D1_grating.Enabled = (Me.radD1Floor.Checked)
      'unchecks grating and sets grating cost to 0 if floor is unchecked
      If Me.radD1Floor.Checked = False Then
         Me.lbl_D1_grating_cost.Text = Format(0, "c")
         Me.ck_D1_grating.Checked = False
      End If
   End Sub



   'UPGRADE_WARNING: Event ck_D1_grating.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
   Private Sub ck_D1_grating_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) _
   Handles ck_D1_grating.CheckStateChanged
      If Me.IsInitializing Then Exit Sub

      Dim gratingHeight, gratingWidth, gratingArea As Double
      Dim model As String
      Dim dimensionsTable As ReferenceData.SectionDimensionsDataTable

      If ck_D1_grating.Checked Then
         Try

            model = Me.DseProject1.SavedAirHandler(Me.airHandlerIndex).ModelNumber

            ' retrieves the section dimensions for the selected air handler
            dimensionsTable = DataAgent.RetrieveDimensions(model)

            ' converts dimensions from inches to feet
            gratingHeight = dimensionsTable(0).DH / 12
            gratingWidth = dimensionsTable(0).DW / 12
            ' calculates the grating face area
            gratingArea = gratingHeight * gratingWidth

            ' Grating is $10 per ft^2 given by Jay Kindle
            ' calculates grating cost
            Me.lbl_D1_grating_cost.Text = (10 * gratingArea).ToString("c")
         Catch ex As Exception
            MessageBox.Show("Attempt to calculate D1 (Discharge) related values failed. " & ex.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      Else
         lbl_D1_grating_cost.Text = Format(0, "c")
      End If

   End Sub


   'UPGRADE_WARNING: Event ck_al.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
   Private Sub ck_al_CheckStateChanged(ByVal sender As Object, ByVal e As EventArgs) _
   Handles ck_al.CheckedChanged
      If IsInitializing = False Then
         Dim index As Short = ck_al.GetIndex(sender)
         Dim value As String = "Aluminum"

         If ck_al(index).CheckState = 1 Then
            ck_cu(index).Checked = False
            If index = 0 Then
               Me.lblFinMaterial1.Text = value
            ElseIf index = 1 Then
               Me.lblFinMaterial2.Text = value
            ElseIf index = 2 Then
               Me.lblFinMaterial3.Text = value
            ElseIf index = 3 Then
               Me.lblFinMaterial4.Text = value
               'ElseIf index = 4 Then
               '   Me.lblFinMaterial5.Text = value
            Else
               MessageBox.Show("There is no index " & index.ToString & " to set the coil fin material.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
         End If

         Me.setCoilCostControlValue(index)
      End If
   End Sub


#End Region


#Region " Radiobox Events"
   ''' -----------------------------------------------------------------------------
   ''' <summary>
   ''' Synchronizes base material check value with data bound label.
   ''' </summary>
   ''' <history>
   ''' 	[CASEYJ]	5/4/2005	Created
   '''   <para>Replaced checkboxes with radioboxes, since only one option can be checked
   '''   at a time.</para>
   ''' </history>
   ''' -----------------------------------------------------------------------------
   Private Sub radBaseMaterialSheetMetal_CheckedChanged( _
   ByVal sender As Object, ByVal e As EventArgs) _
   Handles radBaseMaterialSheetMetal.CheckedChanged
      If Me.IsInitializing Then Exit Sub

      If Me.radBaseMaterialSheetMetal.Checked Then
         'sets text property for label that with databinding
         Me.lblBaseMaterialChkValue.Text = "Sheet metal"
      End If
   End Sub


   ''' -----------------------------------------------------------------------------
   ''' <summary>
   ''' Synchronizes base material check value with data bound label.
   ''' </summary>
   ''' <history>
   ''' 	[CASEYJ]	5/4/2005	Created
   ''' </history>
   ''' -----------------------------------------------------------------------------
   Private Sub radBaseMaterialSteel_CheckedChanged( _
   ByVal sender As Object, ByVal e As EventArgs) _
   Handles radBaseMaterialSteel.CheckedChanged
      If Me.IsInitializing Then Exit Sub

      If Me.radBaseMaterialSteel.Checked Then
         Me.lblBaseMaterialChkValue.Text = "Steel"
      End If

   End Sub
#End Region


#Region "Button Events"

   '"Save" button
   Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles cmd_close_2.Click
      Dim message As String
      Dim header As String = "There are incomplete or erroneous inputs. These invalid inputs may cause pricing inaccuracies."
      Dim footer As String = "RAESolutions will attempt to save invalid inputs."

      'validates controls
      message = Me.GetValidationMessage()

      'if there are invalid controls, notify user
      If message <> "" Then
         message = header & Environment.NewLine & Environment.NewLine & message & footer
         MessageBox.Show(message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      End If

      'save changes
      Me.SaveUnit()

   End Sub



   Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles btnDelete.Click
      If Me.selectedSectionDrawingOrderIndex > -1 Then
         'removes section's dataset row, drawing and hides its controls
         Me.RemoveSection(Me.selectedSectionDrawingOrderIndex)

         'updates section details dataset's order indices
         Me.UpdateOrderIndices()
      Else
         MessageBox.Show("The section drawing to be deleted must be selected first.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      End If
   End Sub



   '"Close" button
   Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles btnClose.Click
      Me.Close()
   End Sub

#End Region


#Region "TextChanged"

   ''' -----------------------------------------------------------------------------
   ''' <summary>
   ''' Synchronizes base material radio box control values with dataset.
   ''' </summary>
   ''' <history>
   ''' 	[CASEYJ]	5/4/2005	Created
   ''' </history>
   ''' -----------------------------------------------------------------------------
   Private Sub lblBaseMaterialChkValue_TextChanged( _
   ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles lblBaseMaterialChkValue.TextChanged
      If Me.IsInitializing Then Exit Sub

      If Me.lblBaseMaterialChkValue.Text = "Steel" Then
         Me.radBaseMaterialSteel.Checked = True
      ElseIf Me.lblBaseMaterialChkValue.Text = "Sheet metal" Then
         Me.radBaseMaterialSheetMetal.Checked = True
      End If
   End Sub


   'changes order index label
   Private Sub Container_TextChanged(ByVal sender As Object, ByVal e As EventArgs) _
   Handles panMB1Container.TextChanged, panMB2Container.TextChanged, panFF1Container.TextChanged, panFF2Container.TextChanged, _
   panFF3Container.TextChanged, panFan1Container.TextChanged, panFan2Container.TextChanged, panFan3Container.TextChanged, _
   panCoil1Container.TextChanged, panCoil2Container.TextChanged, panCoil3Container.TextChanged, _
   panCoil4Container.TextChanged, panCoil5Container.TextChanged, panC3Container.TextChanged, _
   panDischargeContainer.TextChanged, panGasHeaterContainer.TextChanged
      'UPDATE: controls to handle
      Dim i As Integer
      Dim container As New Panel

      container = CType(sender, Panel)

      Try
         For i = 0 To container.Controls.Count - 1
            If container.Controls(i).Name.EndsWith("OrderIndex") Then
               container.Controls(i).Text = container.Text
               Exit For
            End If
         Next
      Catch ex As Exception
         MessageBox.Show("Attempt to set order index label failed. " & ex.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub


   Private Sub lblDischargeLocationChkValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles lblDischargeLocationChkValue.TextChanged
      Try
         If Me.lblDischargeLocationChkValue.Text = "Ceiling discharge" Then
            Me.radD1Ceiling.Checked = True
         ElseIf Me.lblDischargeLocationChkValue.Text = "Floor discharge" Then
            Me.radD1Floor.Checked = True
         ElseIf Me.lblDischargeLocationChkValue.Text = "End wall discharge" Then
            Me.radD1EndWall.Checked = True
         End If
      Catch ex As Exception
         MessageBox.Show("Attempt to set discharge opening location failed. " & ex.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub


   Private Sub lblMB1CasingChkValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles lblMB1CasingChkValue.TextChanged
      If Me.lblMB1CasingChkValue.Text = "Aluminum" Then
         Me.ck_MB1_al(0).Checked = True
         Me.ck_MB1_gal(0).Checked = False
      ElseIf Me.lblMB1CasingChkValue.Text = "Galvanized" Then
         Me.ck_MB1_al(0).Checked = False
         Me.ck_MB1_gal(0).Checked = True
      End If
   End Sub


   Private Sub lblMB2CasingChkValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles lblMB2CasingChkValue.TextChanged
      If Me.lblMB2CasingChkValue.Text = "Aluminum" Then
         Me.ck_MB1_al(1).Checked = True
         Me.ck_MB1_gal(1).Checked = False
      ElseIf Me.lblMB2CasingChkValue.Text = "Galvanized" Then
         Me.ck_MB1_al(1).Checked = False
         Me.ck_MB1_gal(1).Checked = True
      End If
   End Sub


   Private Sub lblEfficiency_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles lblEfficiency1.TextChanged, lblEfficiency2.TextChanged, lblEfficiency3.TextChanged
      Dim lbl As Label = CType(sender, Label)
      Dim i As Integer = lbl.Name.Substring(lbl.Name.Length - 1, 1) - 1

      If lbl.Text = "High" Then
         Me.ck_high(i).Checked = True
         Me.ck_premium(i).Checked = False
      ElseIf lbl.Text = "Premium" Then
         Me.ck_high(i).Checked = False
         Me.ck_premium(i).Checked = True
      End If
   End Sub


   Private Sub lblEnclosure_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles lblEnclosure1.TextChanged, lblEnclosure2.TextChanged, lblEnclosure3.TextChanged
      Dim lbl As Label = CType(sender, Label)
      Dim i As Integer = lbl.Name.Substring(lbl.Name.Length - 1, 1) - 1

      If lbl.Text = "ODP" Then
         Me.ck_odp(i).Checked = True
         Me.ck_tefc(i).Checked = False
      ElseIf lbl.Text = "TEFC" Then
         Me.ck_odp(i).Checked = False
         Me.ck_tefc(i).Checked = True
      End If
   End Sub


   Private Sub lblFinMaterial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles lblFinMaterial1.TextChanged, lblFinMaterial2.TextChanged, lblFinMaterial3.TextChanged, lblFinMaterial4.TextChanged, lblFinMaterial5.TextChanged
      Dim lbl As Label = CType(sender, Label)
      Dim i As Integer = lbl.Name.Substring(lbl.Name.Length - 1, 1) - 1

      If lbl.Text = "Aluminum" Then
         Me.ck_al(i).Checked = True
         Me.ck_cu(i).Checked = False
      ElseIf lbl.Text = "Copper" Then
         Me.ck_al(i).Checked = False
         Me.ck_cu(i).Checked = True
      End If
   End Sub


   Private Sub lblCoilCasing_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles lblCoilCasing1.TextChanged, lblCoilCasing2.TextChanged, lblCoilCasing3.TextChanged, lblCoilCasing4.TextChanged, lblCoilCasing5.TextChanged
      Dim lbl As Label = CType(sender, Label)
      Dim i As Integer = lbl.Name.Substring(lbl.Name.Length - 1, 1) - 1

      If lbl.Text = "Galvanized steel" Then
         Me.ck_gal(i).Checked = True
         Me.ck_ss(i).Checked = False
      ElseIf lbl.Text = "Stainless steel" Then
         Me.ck_gal(i).Checked = False
         Me.ck_ss(i).Checked = True
      End If
   End Sub


#End Region


   'opens pdf of air handler catalog
   Private Sub lllCatalog_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lllCatalog.LinkClicked
      Process.Start(AppInfo.AppFolderPath & "Files\AirHandlingUnits.pdf")
   End Sub


   Private Sub form_unit_info_Closing(ByVal eventSender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) _
   Handles MyBase.Closing
      Dim message As String = "Do you want to save unit information changes?"
      Dim warningMessage As String = "There are incomplete or erroneous input fields. These invalid fields may cause pricing inaccuracies."
      Dim messageBody As String
      Dim title As String = My.Application.Info.ProductName
      Dim result As DialogResult


      'if user made changes then ask if they want to save them before closing
      If Me.ChangesOccurred() Then
         'determines whether to save or not
         result = MessageBox.Show(message, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
         If result = DialogResult.Yes Then
            'gets an validation warnings
            messageBody = Me.GetValidationMessage
            If messageBody = "" Then
               Me.SaveUnit()
            Else
               warningMessage &= Environment.NewLine & Environment.NewLine & messageBody & _
                  "Do you want to correct invalid inputs before closing?"
               result = MessageBox.Show(warningMessage, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
               If result = DialogResult.Yes Then
                  e.Cancel = True
               ElseIf result = DialogResult.No Then
                  Me.SaveUnit()
               ElseIf result = DialogResult.Cancel Then
                  e.Cancel = True
               End If
            End If
         ElseIf result = DialogResult.No Then
            Me.DseProject1.SavedAirHandler.RejectChanges()
            Me.DseProject1._Section.RejectChanges()
            Me.DseProject1.SectionDetails.RejectChanges()
         ElseIf result = DialogResult.Cancel Then
            e.Cancel = True
         End If

      End If
   End Sub


   Private Function ChangesOccurred() As Boolean
      Dim i As Integer
      Dim hasChanged As Boolean = False

      Me.BindingContext(Me.DseProject1.SavedAirHandler).EndCurrentEdit()
      For i = 0 To Me.DseProject1.SavedAirHandler.Rows.Count - 1
         If Me.DseProject1.SavedAirHandler.Rows(i).RowState <> DataRowState.Unchanged Then
            hasChanged = True
            Return hasChanged
            Exit Function
         End If
      Next

      Me.BindingContext(Me.DseProject1._Section).EndCurrentEdit()
      For i = 0 To Me.DseProject1._Section.Rows.Count - 1
         If Me.DseProject1._Section.Rows(i).RowState <> DataRowState.Unchanged Then
            hasChanged = True
            Return hasChanged
            Exit Function
         End If
      Next

      Me.BindingContext(Me.DseProject1.SectionDetails).EndCurrentEdit()
      For i = 0 To Me.DseProject1.SectionDetails.Rows.Count - 1
         If Me.DseProject1.SectionDetails.Rows(i).RowState <> DataRowState.Unchanged Then
            hasChanged = True
            Return hasChanged
            Exit Function
         End If
      Next

      Return hasChanged
   End Function


#End Region



   Private Sub AddSectionDetailsRow()
      Dim row As dseProject.SectionDetailsRow

      Try
         row = Me.DseProject1.SectionDetails.NewSectionDetailsRow
         row.AirHandlerID = Me.DseProject1.SavedAirHandler.Rows(Me.airHandlerIndex)(Me.DseProject1.SavedAirHandler.AirHandlerIDColumn)
         Me.DseProject1.SectionDetails.AddSectionDetailsRow(row)
      Catch Ex As Exception
         MessageBox.Show("Attempt to add section details datarow failed. " & Ex.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub


    ''fills unbound columns in datagrid
    'Private Sub C1TrueDBGrid1_UnboundColumnFetch(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs) _
    'Handles dgrC1Select.UnboundColumnFetch

    '   Select Case Me.dgrC1Select.Columns(e.Col).Caption
    '      Case "Coil Face Velocity"
    '         e.Value = Round(Me.DseProject1.SavedAirHandler(Me.airHandlerIndex).Airflow / Me.AirHandlerData1.Coils(e.Row).ActualCoilArea)
    '      Case "Filter Face Velocity"
    '         e.Value = Round(Me.DseProject1.SavedAirHandler(Me.airHandlerIndex).Airflow _
    '            / (Me.AirHandlerData1.Coils(e.Row).FilterHeight * Me.AirHandlerData1.Coils(e.Row).FilterLength / 144))
    '      Case Else

    '   End Select
    'End Sub


    'gets the index this air handler out of all of the air handlers in the project
    Private Function GetAirHandlerIndex(ByVal airHandlerID As Integer) As Integer
      Dim i As Integer
      Dim _airHandlerIndex As Integer = -3

      'gets row index of air handler to be modified
      For i = 0 To Me.DseProject1.SavedAirHandler.Rows.Count - 1
         If Me.AirHandlerID = Me.DseProject1.SavedAirHandler(i).AirHandlerID Then
            _airHandlerIndex = i
            Exit For
         End If
      Next

      Return _airHandlerIndex
   End Function


    'formats the air handler selection datagrid
    ''Private Sub FormatSectionDatagrid()
    ''   Dim dc As C1.Win.C1TrueDBGrid.C1DisplayColumn

    ''   'formats sections datagrid; order index, length and section abbreviation in inverted style
    ''   With Me.dgrC1SectionInfo
    ''      .DataView = C1.Win.C1TrueDBGrid.DataViewEnum.Inverted
    ''      .Splits(0).DisplayColumns("SectionID").Visible = False
    ''      .Splits(0).DisplayColumns("AirHandlerID").Visible = False
    ''   End With
    ''   With Me.dgrC1SectionInfo.Splits(0).DisplayColumns("SectionLength")
    ''      .DataColumn.Caption = "Length"
    ''      .Height = 20
    ''      .Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    ''      .Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
    ''   End With
    ''   With Me.dgrC1SectionInfo.Splits(0).DisplayColumns("Abbreviation")
    ''      .Height = 20
    ''      .Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    ''      .Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
    ''   End With
    ''   With Me.dgrC1SectionInfo.Splits(0).DisplayColumns("OrderIndex")
    ''      .DataColumn.Caption = "Order Index"
    ''      .Height = 20
    ''      .Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    ''      .Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
    ''   End With
    ''   'moves order index column to top
    ''   dc = Me.dgrC1SectionInfo.Splits(0).DisplayColumns("OrderIndex")
    ''   Me.dgrC1SectionInfo.Splits(0).DisplayColumns.RemoveAt(Me.dgrC1SectionInfo.Splits(0).DisplayColumns.IndexOf(dc))
    ''   Me.dgrC1SectionInfo.Splits(0).DisplayColumns.Insert(0, dc)
    ''End Sub


    'sets section detail controls' databindings
    Private Sub AddDatabindings()

      'mixing boxes
      Me.lblMB1CasingChkValue.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "MB1Casing"))
      Me.cbo_mixing_box(0).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "MB1IncomingAir"))

      Me.lblMB2CasingChkValue.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "MB2Casing"))
      Me.cbo_mixing_box(1).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "MB2IncomingAir"))

      'filters
      Me.cbo_pre_ff(0).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "PreFilt0"))
      Me.cbo_pre_sets(0).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "NumPreFilts0"))
      Me.cbo_ff(0).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "Filt0"))
      Me.cbo_ff_sets(0).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "NumFilts0"))

      Me.cbo_pre_ff(1).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "PreFilt1"))
      Me.cbo_pre_sets(1).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "NumPreFilts1"))
      Me.cbo_ff(1).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "Filt1"))
      Me.cbo_ff_sets(1).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "NumFilts1"))

      Me.cbo_pre_ff(2).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "PreFilt2"))
      Me.cbo_pre_sets(2).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "NumPreFilts2"))
      Me.cbo_ff(2).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "Filt2"))
      Me.cbo_ff_sets(2).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "NumFilts2"))

      'fans
      '0
      Me.lblEfficiency1.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FanEfficiency0"))
      Me.lblEnclosure1.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FanEnclosure0"))
      Me.cbo_hp(0).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FanHorsepower0"))
      Me.cbo_rpm(0).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FanRPM0"))
      Me.cbo_fan_type(0).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FanType0"))
      Me.cbo_fan_class(0).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FanClass0"))
      Me.cbo_drive_type(0).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FanDrive0"))
      Me.cbo_fan_size(0).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FanSize0"))
      Me.cbo_fan_iso(0).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FanIsolator0"))
      '1
      Me.lblEfficiency2.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FanEfficiency1"))
      Me.lblEnclosure2.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FanEnclosure1"))
      Me.cbo_hp(1).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FanHorsepower1"))
      Me.cbo_rpm(1).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FanRPM1"))
      Me.cbo_fan_type(1).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FanType1"))
      Me.cbo_fan_class(1).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FanClass1"))
      Me.cbo_drive_type(1).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FanDrive1"))
      Me.cbo_fan_size(1).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FanSize1"))
      Me.cbo_fan_iso(1).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FanIsolator1"))
      '2
      Me.lblEfficiency3.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FanEfficiency2"))
      Me.lblEnclosure3.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FanEnclosure2"))
      Me.cbo_hp(2).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FanHorsepower2"))
      Me.cbo_rpm(2).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FanRPM2"))
      Me.cbo_fan_type(2).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FanType2"))
      Me.cbo_fan_class(2).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FanClass2"))
      Me.cbo_drive_type(2).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FanDrive2"))
      Me.cbo_fan_size(2).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FanSize2"))
      Me.cbo_fan_iso(2).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FanIsolator2"))

      'coils
      Me.cbo_coil_type(0).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "CoilType0"))
      Me.cbo_coil_type(1).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "CoilType1"))
      Me.cbo_coil_type(2).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "CoilType2"))
      Me.cbo_coil_type(3).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "CoilType3"))
      'Me.cbo_coil_type(4).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "CoilType4"))

      Me.cbo_rows(0).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "CoilRows0"))
      Me.cbo_rows(1).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "CoilRows1"))
      Me.cbo_rows(2).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "CoilRows2"))
      Me.cbo_rows(3).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "CoilRows3"))
      'Me.cbo_rows(4).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "CoilRows4"))

      Me.cbo_fins(0).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "NumFins0"))
      Me.cbo_fins(1).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "NumFins1"))
      Me.cbo_fins(2).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "NumFins2"))
      Me.cbo_fins(3).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "NumFins3"))
      'Me.cbo_fins(4).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "NumFins4"))

      Me.cbo_fin_thickness(0).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FinThickness0"))
      Me.cbo_fin_thickness(1).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FinThickness1"))
      Me.cbo_fin_thickness(2).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FinThickness2"))
      Me.cbo_fin_thickness(3).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FinThickness3"))
      '.cbo_fin_thickness(4).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FinThickness4"))

      Me.cbo_tube_thickness(0).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "TubeThickness0"))
      Me.cbo_tube_thickness(1).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "TubeThickness1"))
      Me.cbo_tube_thickness(2).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "TubeThickness2"))
      Me.cbo_tube_thickness(3).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "TubeThickness3"))
      'Me.cbo_tube_thickness(4).DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "TubeThickness4"))

      Me.lblFinMaterial1.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FinMaterial0"))
      Me.lblFinMaterial2.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FinMaterial1"))
      Me.lblFinMaterial3.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FinMaterial2"))
      Me.lblFinMaterial4.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FinMaterial3"))
      'Me.lblFinMaterial5.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FinMaterial4"))

      Me.lblCoilCasing1.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "CoilCasing0"))
      Me.lblCoilCasing2.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "CoilCasing1"))
      Me.lblCoilCasing3.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "CoilCasing2"))
      Me.lblCoilCasing4.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "CoilCasing3"))
      'Me.lblCoilCasing5.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "CoilCasing4"))

      ' apparently coil 4 is not being used, so use for C5
      Me.cboC5Power.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "FinMaterial4"))
      Me.lblC5TypeValue.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "CoilType4"))

      'C3
      Me.cbo_C3_kw.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "C3KW"))
      Me.lbl_C3_min_stages_val.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "C3MinNumStages"))
      Me.lbl_C3_op_temp_1.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "C3OperatingTemperature"))
      Me.ck_C3_disconnect.DataBindings.Add(New Binding("Checked", Me.DseProject1.SectionDetails, "C3Disconnect"))
      Me.ck_C3_scr.DataBindings.Add(New Binding("Checked", Me.DseProject1.SectionDetails, "C3SiliconControlledRectifier"))
      Me.cbo_C3_extra_stages.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "C3NumExtraStages"))

      'discharge
      'TODO: add back discharge bindings
      Me.lblDischargeLocationChkValue.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "DischargeOpeningLocation"))
      Me.ck_D1_grating.DataBindings.Add(New Binding("Checked", Me.DseProject1.SectionDetails, "DischargeGrating"))
      'TODO: discharge height, width

      'order indices
      'Me.panMB1Container.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "MB1OrderIndex"))
      'Me.panMB2Container.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "MB2OrderIndex"))
      'Me.panFF1Container.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "Filt0OrderIndex"))
      'Me.panFF2Container.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "Filt1OrderIndex"))
      'Me.panFF3Container.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "Filt2OrderIndex"))
      'Me.panFan1Container.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "Fan0OrderIndex"))
      'Me.panFan2Container.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "Fan1OrderIndex"))
      'Me.panFan3Container.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "Fan2OrderIndex"))
      'Me.panCoil1Container.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "Coil0OrderIndex"))
      'Me.panCoil2Container.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "Coil1OrderIndex"))
      'Me.panCoil3Container.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "Coil2OrderIndex"))
      'Me.panCoil4Container.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "Coil3OrderIndex"))
      'Me.panCoil5Container.DataBindings.Add(New Binding("Text", Me.DseProject1.SectionDetails, "Coil4OrderIndex"))

      'SavedAirHandler
      'base material
      Dim retrieve As String = "SELECT AirHandlerID, C3Disconnect, C3KW, C3MinNumStages, C3NumExtraStages, C3OperatingTemperature, C3OrderIndex, C3SiliconControlledRectifier, Coil0OrderIndex, Coil1OrderIndex, Coil2OrderIndex, CoilCasing0, CoilCasing1, CoilCasing2, CoilRows0, CoilRows1, CoilRows2, CoilType0, CoilType1, CoilType2, DischargeGrating, DischargeHeight, DischargeOpeningLocation, DischargeOrderIndex, DischargeWidth, Fan0OrderIndex, Fan1OrderIndex, Fan2OrderIndex, FanClass0, FanClass1, FanClass2, FanDrive0, FanDrive1, FanDrive2, FanEfficiency0, FanEfficiency1, FanEfficiency2, FanEnclosure0, FanEnclosure1, FanEnclosure2, FanHorsepower0, FanHorsepower1, FanHorsepower2, FanIsolator0, FanIsolator1, FanIsolator2, FanRPM0, FanRPM1, FanRPM2, FanSize0, FanSize1, FanSize2, FanType0, FanType1, FanType2, Filt0, Filt0OrderIndex, Filt1, Filt1OrderIndex, Filt2, Filt2OrderIndex, FinMaterial0, FinMaterial1, FinMaterial2, FinThickness0, FinThickness1, FinThickness2, MB1Casing, MB1IncomingAir, MB1OrderIndex, MB2Casing, MB2IncomingAir, MB2OrderIndex, NumFilts0, NumFilts1, NumFilts2, NumFins0, NumFins1, NumFins2, NumPreFilts0, NumPreFilts1, NumPreFilts2, PreFilt0, PreFilt1, PreFilt2, SectionDetailsID, TubeThickness0, TubeThickness1, TubeThickness2, Coil4OrderIndex, CoilType4, FinMaterial4 FROM SectionDetails WHERE (AirHandlerID = ?)"
      Me.dadSectionDetails.SelectCommand.CommandText = retrieve
      Me.lblBaseMaterialChkValue.DataBindings.Add(New Binding("Text", Me.DseProject1.SavedAirHandler, "BaseMaterial"))
      Me.BindingContext(Me.DseProject1.SavedAirHandler).Position = Me.airHandlerIndex

   End Sub



#Region "Arrays for comboboxes"

   Private Function GetFanHorsepowers() As Object()
      Dim arrHorsepowers(14) As Object
      arrHorsepowers(0) = "1"
      arrHorsepowers(1) = "1.5"
      arrHorsepowers(2) = "2"
      arrHorsepowers(3) = "3"
      arrHorsepowers(4) = "5"
      arrHorsepowers(5) = "7.5"
      arrHorsepowers(6) = "10"
      arrHorsepowers(7) = "15"
      arrHorsepowers(8) = "20"
      arrHorsepowers(9) = "25"
      arrHorsepowers(10) = "30"
      arrHorsepowers(11) = "40"
      arrHorsepowers(12) = "50"
      arrHorsepowers(13) = "60"
      arrHorsepowers(14) = "75"

      Return arrHorsepowers
   End Function


   'returns sections (to add to combobox) i.e. MB1, HF1, C1, FF1, etc.
   Private Function GetComboboxSections() As ArrayList
      Dim arrSections As New ArrayList
      arrSections.Add("")
      arrSections.AddRange([Enum].GetNames(GetType(sectionAbbreviation)))

      Return arrSections
   End Function


   'fills fan size combobox, depends on 1. fan type (SWSI)
   Private Sub FillPlenumFanSize(ByRef Index As Short)
      If cbo_fan_type(Index).SelectedItem = "SWSI Airfoil" Then
         cbo_fan_size(Index).Items.Clear()
         cbo_fan_size(Index).Items.AddRange( _
            New Object() {"12", "13", "15", "16", "18", "20", "22", "24", "27", "30", "33", "36", "40", "44", "49"})
      End If
   End Sub


   '>> fills fan size combobox, does NOT select specific item
   '>> depends on 1.fan type (DWDI), 2.HP
   'also this routine is called from w/in an if statement
   'that depends on fan 3.type header (HF1)
   Private Sub FillHousedFanSize(ByVal index As Integer)
      If Me.cbo_fan_type(index).SelectedIndex = -1 _
      OrElse Me.cbo_hp(index).SelectedIndex = -1 Then
         Exit Sub
      End If

      Dim currentSize As String

      currentSize = CNull.ToString(Me.cbo_fan_size(index).SelectedItem)

      If cbo_fan_type(index).Text = "DWDI BI" Then
         '// These values were takin from the delhi catalog
         '// HP is a text item so each hp has to be referenced
         Select Case Me.cbo_hp(index).SelectedItem.ToString
            Case "1", "1.5", "2", "3", "5", "7.5", "10", "15"
               Me.cbo_fan_size(index).Items.Clear()
               Me.cbo_fan_size(index).Items.AddRange( _
                  New Object() {"10", "12", "13", "15", "16", "18", "20", "22", "24", "27"})
            Case "20", "25", "30", "40", "50", "60", "75"
               Me.cbo_fan_size(index).Items.Clear()
               Me.cbo_fan_size(index).Items.AddRange(New Object() {"22", "24", "27"})
         End Select

         'TODO: add proper sizes for DWDI FC type fans
         '// If DWDI FC is chosen then open the HousedFC table from the Fans database
         '// Then fill the combo box with the fan sizes that match the selected hp's
      ElseIf cbo_fan_type(index).SelectedItem = "DWDI FC" Then
         Dim housedFCFanSizes As System.Collections.Specialized.StringCollection

         ' retrieves housed forward curved fan sizes
         housedFCFanSizes = Rae.RaeSolutions.DataAccess.AirHandlers.RetrieveForwardCurvedFanSizes

         ' clears fan size combobox
         Me.cbo_fan_size(index).Items.Clear()
         For i As Integer = 0 To housedFCFanSizes.Count - 1
            ' adds fan size to combobox
            Me.cbo_fan_size(index).Items.Add(housedFCFanSizes(i))
         Next
      End If

      're-selects current fan size if still available otherwise
      'sets first item as default
      If Me.cbo_fan_size(index).Items.Contains(currentSize) Then
         Me.cbo_fan_size(index).SelectedIndex = Me.cbo_fan_size(index).FindString(currentSize)
      Else
         Me.cbo_fan_size(index).SelectedIndex = 0
      End If
   End Sub


#End Region


#Region "Costs"


   Private Sub Costs(ByRef L As Single, ByRef W As Single, ByRef H As Single)
      'costs
      Dim totalCosts As Decimal
      Dim materialCost As Decimal
      Dim MBCosts As Decimal
      Dim blenderCost As Decimal
      Dim motorCost, fanCost, fanIsoCost As Decimal
      Dim coilCost, HeaterCost As Decimal
      Dim filterCost As Decimal
      Dim gratingCost As Decimal
      Dim totalListPrice As Decimal = 0
      'weights
      Dim totalWeight As Single
      Dim materialWeight As Single
      Dim fanWeight As Single
      Dim fanIsoWeight As Single
      Dim filterWeight As Single
      Dim motorWeight As Single
      Dim i As Integer

      'calculates cost of the air handlers frame...panel box...base...etc.
      MaterialCosts(L, W, H, materialCost, materialWeight)
      'adds the coil costs
      coilCost = 0
      'checks if controls are being used, if so adds cost to total cost
      If CInt(Me.panCoil1Container.Text) > -1 Then coilCost += Convert.UsCurrencyToDouble(Me.lbl_coil_cost(0).Text)
      If CInt(Me.panCoil2Container.Text) > -1 Then coilCost += Convert.UsCurrencyToDouble(Me.lbl_coil_cost(1).Text)
      If CInt(Me.panCoil3Container.Text) > -1 Then coilCost += Convert.UsCurrencyToDouble(Me.lbl_coil_cost(2).Text)
      If CInt(Me.panCoil4Container.Text) > -1 Then coilCost += Convert.UsCurrencyToDouble(Me.lbl_coil_cost(3).Text)
      If CInt(Me.panCoil5Container.Text) > -1 Then coilCost += Convert.UsCurrencyToDouble(Me.lbl_coil_cost(4).Text)
      If CInt(Me.panGasHeaterContainer.Text) > -1 Then coilCost += Convert.UsCurrencyToDouble(Me.lblGasHeaterCost.Text)

      'adds the mixingbox costs up
      MBCosts = 0
      If CInt(Me.panMB1Container.Text) > -1 Then MBCosts += Convert.UsCurrencyToDouble(Me.lbl_MB1_cost(0).Text)
      If CInt(Me.panMB2Container.Text) > -1 Then MBCosts += Convert.UsCurrencyToDouble(Me.lbl_MB1_cost(1).Text)

      filterCost = 0
      If CInt(Me.panFF1Container.Text) > -1 Then filterCost += Convert.UsCurrencyToDouble(Me.lbl_ff_cost(0).Text)
      If CInt(Me.panFF2Container.Text) > -1 Then filterCost += Convert.UsCurrencyToDouble(Me.lbl_ff_cost(1).Text)
      If CInt(Me.panFF3Container.Text) > -1 Then filterCost += Convert.UsCurrencyToDouble(Me.lbl_ff_cost(2).Text)

      'adds the fan costs
      fanCost = 0
      motorCost = 0
      fanIsoCost = 0
      If Me.panFan1Container.Text > -1 Then
         fanCost += Convert.UsCurrencyToDouble(lbl_fan_cost(0).Text)
         motorCost += Convert.UsCurrencyToDouble(lbl_motor_cost(0).Text)
         fanIsoCost += Convert.UsCurrencyToDouble(lbl_iso_cost(0).Text)
      ElseIf Me.panFan2Container.Text > -1 Then
         fanCost += Convert.UsCurrencyToDouble(lbl_fan_cost(1).Text)
         motorCost += Convert.UsCurrencyToDouble(lbl_motor_cost(1).Text)
         fanIsoCost += Convert.UsCurrencyToDouble(lbl_iso_cost(1).Text)
      ElseIf Me.panFan3Container.Text > -1 Then
         fanCost += Convert.UsCurrencyToDouble(lbl_fan_cost(2).Text)
         motorCost += Convert.UsCurrencyToDouble(lbl_motor_cost(2).Text)
         fanIsoCost += Convert.UsCurrencyToDouble(lbl_iso_cost(2).Text)
      End If

      HeaterCost = 0
      If CInt(Me.panC3Container.Text) > -1 Then HeaterCost = Convert.UsCurrencyToDouble(Me.lbl_heater_cost.Text)

      gratingCost = 0
      If CInt(Me.panDischargeContainer.Text) > -1 Then gratingCost = Convert.UsCurrencyToDouble(Me.lbl_D1_grating_cost.Text)

      totalCosts = HeaterCost + materialCost + motorCost _
         + MBCosts + fanCost + filterCost + fanIsoCost _
         + gratingCost + coilCost + Convert.UsCurrencyToDouble(lbl_bld1_cost.Text)

      'sets base price
      Me.DseProject1.SavedAirHandler.Rows(Me.airHandlerIndex)(Me.DseProject1.SavedAirHandler.BaseCostColumn) = _
         totalCosts

      'calculates 40% margin
      Dim marginPrice As Double
      marginPrice = totalCosts / 0.6
      Me.DseProject1.SavedAirHandler.Rows(Me.airHandlerIndex)(Me.DseProject1.SavedAirHandler.MarginPriceColumn) = _
         marginPrice

      Dim multiplier As Single = ConvertNull.ToSingle(Me.DseProject1.SavedProject.Rows(0)(Me.DseProject1.SavedProject.MultiplierColumn))

      'calculates the unit list price
      If multiplier = 0 Then
         MessageBox.Show("Cost calculations failed. Multiplier cannot be zero.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         multiplier = 1
      End If

      Me.DseProject1.SavedAirHandler.Rows(Me.airHandlerIndex)(Me.DseProject1.SavedAirHandler.ListPriceColumn) = _
         marginPrice / multiplier

      'calculates net price
      totalListPrice = 0
      For i = 0 To Me.DseProject1.SavedAirHandler.Rows.Count - 1
         totalListPrice += Convert.UsCurrencyToDouble(ConvertNull.ToDouble(Me.DseProject1.SavedAirHandler(i).ListPrice))
      Next

      'total list price
      Me.DseProject1.SavedProject.Rows(0)(Me.DseProject1.SavedProject.TotalListPriceColumn) = totalListPrice

      'net price
      Me.Daddy.lbl_Unit_Net_1.Text = (totalListPrice * multiplier).ToString("c")

      'calculates weights
      filterWeight = Val(lbl_ff_weight(0).Text) + Val(lbl_ff_weight(1).Text) _
         + Val(lbl_ff_weight(2).Text)
      fanWeight = Val(lbl_fan_weight(0).Text) + Val(lbl_fan_weight(1).Text) _
         + Val(lbl_fan_weight(2).Text)
      motorWeight = Val(lbl_motor_weight(0).Text) + Val(lbl_motor_weight(1).Text) _
         + Val(lbl_motor_weight(2).Text)
      fanIsoWeight = Val(lbl_iso_weight(0).Text) + Val(lbl_iso_weight(1).Text) _
         + Val(lbl_iso_weight(2).Text)
      '// Total Weight adds the weight of all the components of the air handlers
      'TotalWeight = MaterialWeight + FanWeight + MotorWeight + FilterWeight + FanIsoWeight
      '// Show the weight on the sumary page of the project info form
      'form_project_info.lbl_ship_weight_1(unit) = TotalWeight & " lbs"

      'shows base cost if user has authorization
      'Me.Daddy.lbl_base_cost.Visible = (mGlobal.RevLevel = mGlobal.eRevLevel.employee)
      'Me.Daddy.lbl_base_cost_1(unit).Visible = (mGlobal.RevLevel = mGlobal.eRevLevel.employee)
   End Sub


   Private Sub MaterialCosts(ByRef L As Object, ByRef W As Object, ByRef H As Object, ByRef cost As Single, ByRef weight As Single)

      '// Find the Amount and Cost of the Panel Material Required for the sides of the unit
      Dim NumSidePanels As Integer
      Dim ExteriorCost, InteriorCost, InsulationCost As Decimal
      Dim ExteriorArea, InteriorArea, InsulatedArea As Single
      Dim PanelHth, PanelWth As Single
      Dim InteriorWeight, ExteriorWeight, InsWeight As Single
      Dim US1Hours As Single
      Dim panelThickness As Integer

      panelThickness = Me.DseProject1.SavedAirHandler(Me.airHandlerIndex).PanelThickness
      '// Finds the Number of Side Panels to cover the perimeter of the unit
      '// L = Length of the unit, W = width of the unit
      '// Each panel is 18" wide so the sum of the perimeter length divided by the panel
      '//     width will equal the number of side panels required
      NumSidePanels = Ceiling(2 * (L / 18 + W / 18))

      '// The total panel height including the bends in inches
      '//             _______________
      '//            |               |
      '//    Bends=> |               |<==PanelThk
      '//            |_             _|
      '//                          /\
      '//                          ||
      '//                         1" lip

      '// The PanelThk for the unit was selected on the Unit Information page of the
      '//     Project Info form.  It stays constant for the whole unit.
      '// H = the height of the unit
      '// The +2 is for the two 1" lips on the panel
      PanelHth = H + (2 * panelThickness) + 2 '// PanelHth is in inches

      '// The total panel width including the bends in inches
      PanelWth = 18 + (2 * panelThickness) + 2 '// PanelWth is in inches

      '// The Exterior Area is the Area of the material needed to make the panel with the bends and lips
      '// Divide by 144 to convert inches^2 to feet^2
      '// scrap = set value in Sub Cost for the extra material to be added for scrap
      ExteriorArea = NumSidePanels * (PanelHth * PanelWth / 144) * (1 + SCRAP)

      '// ExteriorCost = Exterior Area * the Material Cost/ft^2 which is defined in Sub Cost
      ExteriorCost = ExteriorArea * EXTERIOR_COST

      '// ExteriorWeight = ExteriorArea * the Material Weight/ft^2 which is defined in Sub Cost
      ExteriorWeight = ExteriorArea * EXTERIOR_WEIGHT

      '// InteriorArea is the face area of the panel.
      '// Divide by 144 to convert from in^2 to ft^2
      '// scrap = set value in Sub Cost for the extra material to be added for scrap
      InteriorArea = NumSidePanels * (H * 18 / 144) * (1 + SCRAP)

      '// InteriorCost is just the Interior Area * the Material Cost/ft^2 which is defined in Sub Cost
      InteriorCost = InteriorArea * INTERIOR_COST

      '// InteriorWeight is the InteriorArea * the Material Weight/ft^2 which is defined in
      InteriorWeight = InteriorArea * INTERIOR_WEIGHT

      '// InsulatedArea is the Amount of face area the insulation will take up.
      '// This is going to be equal to the Interior Area of the panel
      InsulatedArea = InteriorArea

      '// InsulationCost is just the InsulatedArea * the Insulation Material Cost given in Sub Cost
      InsulationCost = InsulatedArea * PANEL_INSULATION_COST

      '// InsWeight is just the InsulatedArea * the Insulation Material Weight given in Sub Cost
      InsWeight = InsulatedArea * PANEL_INSULATION_WEIGHT

      ' adds 2 hours for every unit split to accomidate for the extra time needed to modify the panels
      US1Hours = 2 * CDbl(Me.lblUS1Quantity.Text)

      '// Find the amount of material needed for the top panels
      Dim NumRoofPnls As Short
      Dim ExteriorRoofArea As Single
      Dim InteriorRoofArea, InsRoofArea As Single
      Dim RoofPnlHth As Single
      Dim W2 As Single
      Dim ExteriorRoofCost As Decimal
      Dim InteriorRoofCost As Decimal
      Dim InsRoofCost As Decimal
      Dim ExteriorRoofWeight As Single
      Dim InsRoofWeight, InteriorRoofWeight As Single

      '// The roof panels are constructed so that their length span the width of the unit.
      '// The maximum roof panel length set by Jay Kindle is 96".  So if the width of the unit
      '// is greater than 96" then two rows of panels must be constructed.  This is what
      '// the if statement is determining.  Jay has said that the width of the unit will
      '// not exceed 2 * 96 which is why I can use the > 1 relation.  If the width/96 > 1
      '// then the two rows are needed.  Otherwise only one row is needed.  Once I know how
      '// many rows are needed then I devide the unit length by 18" to get the number of panels
      '// per row.  Each panel width is 18".
      If W / 96 > 1 Then
         NumRoofPnls = 2 * (L / 18)
         RoofPnlHth = W / 2 + 2 * panelThickness + 2
         W2 = W / 2
      Else
         NumRoofPnls = L / 18
         RoofPnlHth = W + 2 * panelThickness + 2
         W2 = W
      End If
      NumRoofPnls = Ceiling(NumRoofPnls)
      '// Round the number of panels up
      'If Round(NumRoofPnls, 0) < Round(NumRoofPnls + 0.5, 0) Then
      '   NumRoofPnls = Round(NumRoofPnls + 0.5, 0)
      'Else
      '   NumRoofPnls = Round(NumRoofPnls, 0)
      'End If

      '// These steps are done exactly like the steps above for the side panels.
      ExteriorRoofArea = NumRoofPnls * (RoofPnlHth * PanelWth / 144) * (1 + SCRAP)
      ExteriorRoofCost = ExteriorRoofArea * EXTERIOR_COST
      ExteriorRoofWeight = ExteriorRoofArea * EXTERIOR_WEIGHT
      InteriorRoofArea = NumRoofPnls * (W2 * 18 / 144) * (1 + SCRAP)
      InteriorRoofCost = InteriorRoofArea * INTERIOR_COST
      InteriorRoofWeight = InteriorRoofArea * INTERIOR_WEIGHT
      InsRoofArea = InteriorRoofArea
      InsRoofCost = InsRoofArea * PANEL_INSULATION_COST
      InsRoofWeight = InsRoofArea * PANEL_INSULATION_WEIGHT

      '// Find the amount of material needed for the floor or base
      '// Sheetmetal Base
      Dim NumBasePnlsL, NumBasePnlsW, NumBasePerimeterPnls As Single
      Dim NumBaseInnerRows, NumBaseInnerPnls As Single
      Dim SMInsCost, SMInsArea, SMInsWeight As Single
      Dim SMFloorCost, SMFloorArea, SMFloorWeight As Single


      '//             ______________________________________
      '//            |            |            |            |
      '//            |____________|____________|____________|         ______________________
      '//            |   |       |       |       |      |   |         _       ^Floor       _   .
      '//            |   |       |       |       |      |   |        | |                  | |
      '//            |   |       |       |       |      |   |        |                      |
      '//            |   |       |       |       |      |   |        |______________________|
      '//            |   |       |       |       |      |   |                     ^
      '//            |   |       |       |       |      |   |                     Panel
      '//            |___|_______|_______|_______|______|___|
      '//            |            |            |            |
      '//            |____________|____________|____________|

      '// Figure the # of Perimeter Panels
      '// The sheetmetal base is made of panels that run along the perimeter of the unit
      '// and then fill in the middle.
      '// The perimeter panels are 120" long. So the Length and Width divided by 120 will
      '//     give the # of panels on these sides.  A little overlap at the corners will
      '//     occure.
      NumBasePnlsW = W / 120
      NumBasePnlsL = L / 120

      '// Round the number of panels width wise up
      If Round(NumBasePnlsW, 0) < Round(NumBasePnlsW + 0.5, 0) Then
         NumBasePnlsW = Round(NumBasePnlsW + 0.5, 0)
      Else
         NumBasePnlsW = Round(NumBasePnlsW, 0)
      End If

      '// Round the # of Length wise panels up
      If Round(NumBasePnlsL, 0) < Round(NumBasePnlsL + 0.5, 0) Then
         NumBasePnlsL = Round(NumBasePnlsL + 0.5, 0)
      Else
         NumBasePnlsL = Round(NumBasePnlsL, 0)
      End If

      '// the sheetmetal base perimeter is consisted of 2 lengths and 2 widths
      NumBasePerimeterPnls = NumBasePnlsW * 2 + NumBasePnlsL * 2

      '// Figure the # Inner Panels
      '// The inner panels are also a max of 120" long and run lengthwise across the
      '//     width of the unit.
      '// The sheetmetal base panels are each 12" wide so 24" must be subtracted
      '//     from the unit width to account for the perimeter panels that have already
      '//     been accounted for.  Divide the new width (W-24) by 120 to get the number
      '//     of inner panel rows required.  This is much like the proceedure for the
      '//     roof.
      NumBaseInnerRows = (W - 24) / 120

      '// Round the number of rows up
      If Round(NumBaseInnerRows, 0) < Round(NumBaseInnerRows + 0.5, 0) Then
         NumBaseInnerRows = Round(NumBaseInnerRows + 0.5, 0)
      Else
         NumBaseInnerRows = Round(NumBaseInnerRows, 0)
      End If

      '// That Inner panels are 24" wide so the new unit length(L-24)(Remember the -24
      '//     accounts for the perimeter panels) devided by 24" gives the # of panels
      '//     per row
      'UPGRADE_WARNING: Couldn't resolve default property of object L. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
      NumBaseInnerPnls = (L - 24) / 24

      '// Round UP
      If Round(NumBaseInnerPnls, 0) < Round(NumBaseInnerPnls + 0.5, 0) Then
         NumBaseInnerPnls = Round(NumBaseInnerPnls + 0.5, 0)
      Else
         NumBaseInnerPnls = Round(NumBaseInnerPnls, 0)
      End If

      '// Rows * Panels per row gives total # of inner panels.
      NumBaseInnerPnls = NumBaseInnerRows * NumBaseInnerPnls

      If Me.radBaseMaterialSheetMetal.Checked Then
         '// The SheetMetal Base panels are covered by a sheetmetal floor as shown above.
         '// The area of this floor is equal to the face area of the unit base.  4" and
         '//     a scrap factor have been added to the area to account for some extra material
         'UPGRADE_WARNING: Couldn't resolve default property of object W. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
         'UPGRADE_WARNING: Couldn't resolve default property of object L. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
         SMFloorArea = (L + 4) * (W + 4) / 144 * (1 + SCRAP)

         '// The cost is given in the Cost subroutine.
         SMFloorCost = SMFloorArea * SHEET_METAL_FLOOR_COST

         '// The weight is also given in the Cost subroutine
         SMFloorWeight = SMFloorArea * SHEET_METAL_FLOOR_WEIGHT

         '// The insulation will be placed between the base panels and the floor.
         '// 3" have been subtracted from the face area cal to account for the area takin
         '//     up by the bends of the panels in the face area.
         SMInsArea = (W - 3) * (L - 3) / 144 * (1 + SCRAP)

         '// The Cost is found in the Cost sub
         SMInsCost = SMInsArea * FLOOR_INSULATION_COST

         '// The Weight is found in the Cost sub
         SMInsWeight = SMInsArea * FLOOR_INSULATION_WEIGHT
      End If

      '// Steel Base
      Dim SBInsCost, SBInsArea, SBInsWeight As Single
      Dim SBFloorCost, SBFloorArea, SBFloorWeight As Single
      Dim SBSubFloorCost, SBSubFloorArea, SBSubFloorWeight As Single
      Dim SBMaterialCost, SBMaterial, SBMaterialWeight As Single
      Dim SBMisMaterialCost, SBMisMaterialWeight As Single

      If Me.radBaseMaterialSteel.Checked Then

         '// SBMaterial is the Length in ft of 6" steel channel used in the base
         '// The base is made of channel running around the perimeter and supports
         '//     through the middle 24" appart
         '//
         '//                    _____________L__________
         '//                   | 24"| 24"| 24"| 24"| 24"|
         '//                 W |    |    |    |    |    |
         '//                   |    |    |    |    |    |
         '//                   |____|____|____|____|____|
         '// Divide by 12 to convert from in to ft
         '// scrap = set value in Sub Cost for the extra material to be added for scrap
         SBMaterial = ((2 * L + 2 * W) / 12 + (W / 12) * (L / 24)) * (1 + SCRAP)

         '// The Cost is found in the Cost sub
         SBMaterialCost = SBMaterial * STEEL_BASE_COST

         '// The Weight is found in the Cost sub
         SBMaterialWeight = SBMaterial * STEEL_BASE_WEIGHT

         SBFloorArea = L * W / 144 * (1 + SCRAP)

         '// The Cost is found in the Cost sub
         SBFloorCost = SBFloorArea * STEEL_BASE_FLOOR_COST

         '// The Weight is found in the Cost sub
         SBFloorWeight = SBFloorArea * SBFloorWeight

         SBInsArea = W * L / 144 * (1 + SCRAP)

         '// The Cost is found in the Cost sub
         SBInsCost = SBInsArea * FLOOR_INSULATION_COST

         '// The Weight is found in the Cost sub
         SBInsWeight = SBInsArea * FLOOR_INSULATION_WEIGHT

         SBSubFloorArea = L * W / 144 * (1 + SCRAP)

         SBSubFloorCost = SBSubFloorArea * STEEL_BASE_SUB_FLOOR_COST
         SBSubFloorWeight = SBSubFloorArea * STEEL_BASE_SUB_FLOOR_WEIGHT

         '// Added Miselanious Material For the Steel Base
         SBMisMaterialCost = STEEL_BASE_MISC_MULTIPLIER * (SBMaterialCost + SBFloorCost + SBInsCost + SBSubFloorCost)

         SBMisMaterialWeight = STEEL_BASE_MISC_MULTIPLIER * (SBMaterialWeight + SBFloorWeight + SBInsWeight + SBSubFloorWeight)
      End If

      '// Cost for the air seal
      '// Certain sections of the unit require an air seal. The Section sub tallies the number
      '//     of sections that require the air seal.  The user can also change this number to
      '//     have as many air seals as they would like.  This value is given in the text box
      '//     on the Other page of the Unit Info form
      Dim AirSealCost1, AirSealArea, AirSealWeight1 As Single

      '// The air seal is just made of perimeter pieces
      AirSealArea = Val(Me.lblAirSealQuantity.Text) * ((W * 24) + (L * 12)) / 144 * (1 + SCRAP)

      '// The cost is found in the Cost sub
      AirSealCost1 = AirSealArea * AIR_SEAL_COST

      '// The weight is found in the Cost sub
      AirSealWeight1 = AirSealArea * AIR_SEAL_WEIGHT

      '// Cost for doors
      '// Certain sections of the unit require doors. The Section sub tallies the number
      '//     of sections that require doors.  The user can also change this number to
      '//     have as many doors as they would like.  This value is given in the text box
      '//     on the Other page of the Unit Info form
      Dim DoorCost1, DoorWeight1 As Single

      '// The cost is given in the Cost sub
      DoorCost1 = Val(txt_doors.Text) * DOOR_COST

      '// The weight is given in the Cost sub
      DoorWeight1 = Val(txt_doors.Text) * DOOR_WEIGHT




      ' PAINT
      '
      Dim areaToPaint As Double
      Dim airHandlerPainter As Business.Entities.Painter

      ' the surface area of all the sides and the top of the unit must be painted
      ' calculates area to paint
      areaToPaint = ExteriorArea + ExteriorRoofArea
      ' determines paint information
      airHandlerPainter = New Business.Entities.Painter(areaToPaint)



      '// Find the hours for each section
      Dim FAWallPnlHrs, FAWallPnlCost As Double
      Dim FARoofPnlHrs, FARoofPnlCost As Double
      Dim OtherWallPnlHrs, OtherWallPnlCost As Double
      Dim OtherRoofPnlHrs, OtherRoofPnlCost As Double
      Dim SMPerimeterLth, SMPerimeterWth, SMBaseHth, SMPerimeterWeight, SMPerimeterArea, SMPerimeterCost As Double
      Dim SMInnerLth, SMInnerWth, SMInnerArea, SMInnerWeight, SMInnerCost, SMBottomCost, SMBottomWeight As Double
      Dim MisMaterialBottom, MisMaterialBottomArea, MisMaterialBottomCost, MisMaterialBottomWeight As Double
      Dim FASMPnlHrs, FASMPnlCost As Double
      Dim OtherSMPnlHrs, OtherSMPnlCost As Double
      Dim FAAirSealHrs, FAAirSealCost, OtherAirSealHrs, OtherAirSealCost As Double
      Dim FADoorHrs, FADoorCost, OtherDoorHrs, OtherDoorCost As Double
      Dim UniversalFrameCost, UniversalFrameWeight As Double
      Dim FAUFrameHrs, FAUFrameCost As Double
      Dim FASBPnlHrs, FASBPnlCost As Double
      Dim OtherSBPnlHrs, OtherSBPnlCost As Double

      Dim model As String
      Dim numAirSeals, numDoors As Integer
      Dim hoursTable As ReferenceData.HoursDataTable
      Dim isSheetMetal, isSteel As Boolean

      ' grabs values from controls
      '
      numAirSeals = CNull.ToInteger(Me.lblAirSealQuantity.Text)
      numDoors = CNull.ToInteger(Me.txt_doors.Text)
      isSheetMetal = Me.radBaseMaterialSheetMetal.Checked
      isSteel = Me.radBaseMaterialSteel.Checked

      ' sets air handler model
      model = Me.DseProject1.SavedAirHandler(Me.airHandlerIndex).ModelNumber

      ' TODO: Put in business layer CalculateManHourCost(model, material)

      ' retrieves hours for model
      hoursTable = DataAgent.RetrieveHours(model)

      If Not hoursTable Is Nothing AndAlso hoursTable.Rows.Count > 0 Then
         With hoursTable(0)
            FAWallPnlHrs = NumSidePanels * .FAHoursPerWallPanel + US1Hours
            FAWallPnlCost = FAWallPnlHrs * Consts.HOURLY_WAGE

            OtherWallPnlHrs = NumSidePanels * .OtherHoursPerWallPanel + US1Hours
            OtherWallPnlCost = OtherWallPnlHrs * Consts.HOURLY_WAGE

            FARoofPnlHrs = NumRoofPnls * .FAHoursPerRoofPanel
            FARoofPnlCost = FARoofPnlHrs * Consts.HOURLY_WAGE

            OtherRoofPnlHrs = NumRoofPnls * .OtherHoursPerRoofPanel
            OtherRoofPnlCost = OtherRoofPnlHrs * Consts.HOURLY_WAGE

            FAAirSealHrs = numAirSeals * 4 * .FAHoursPerAirSeal
            FAAirSealCost = FAAirSealHrs * Consts.HOURLY_WAGE

            OtherAirSealHrs = numAirSeals * 4 * .OtherHoursPerAirSeal
            OtherAirSealCost = OtherAirSealHrs * Consts.HOURLY_WAGE

            FADoorHrs = .FAHoursPerDoor * numDoors
            FADoorCost = FADoorHrs * Consts.HOURLY_WAGE

            OtherDoorHrs = .OtherHoursPerDoor * numDoors
            OtherDoorCost = OtherDoorHrs * Consts.HOURLY_WAGE

            UniversalFrameCost = .UniversalFrameAndClips * 15
            UniversalFrameWeight = .UniversalFrameAndClips * 6
            FAUFrameHrs = .UniversalFrameAndClips * 0.25
            FAUFrameCost = FAUFrameHrs * Consts.HOURLY_WAGE

            ' determines base material
            If isSheetMetal Then
               ' gets the number of hours both FA and Other to complete the smbase
               FASMPnlHrs = (NumBasePerimeterPnls + NumBaseInnerPnls) * .FAHoursPerFloorPanel
               FASMPnlCost = FASMPnlHrs * Consts.HOURLY_WAGE
               OtherSMPnlHrs = (NumBasePerimeterPnls + NumBaseInnerPnls) * .OtherHoursPerFloorPanel
               OtherSMPnlCost = OtherSMPnlHrs * Consts.HOURLY_WAGE

               ' The panel thickness of the sheetmetal and later the steel bases are not the same as the side and roof panels
               '  The base panel thicknesses are given for a certain model.
               SMBaseHth = .SMBaseHeight

               ' calculates new lengths for the area calc.
               '  12" wide + 2(1" lip) + 2 * (base panel thickness)
               SMPerimeterWth = 12 + 2 + (2 * SMBaseHth)

               ' 120" long + 2(1" lip) + 2 * (base panel thickness)
               SMPerimeterLth = 120 + 2 + (2 * SMBaseHth)

               ' Area of the base panel * # of panels / 144 gets the area of metal in ft^2
               SMPerimeterArea = (SMPerimeterWth * SMPerimeterLth / 144) * NumBasePerimeterPnls * (1 + SCRAP)
               SMPerimeterCost = SMPerimeterArea * SHEET_METAL_BASE_COST

               ' weight is in the Cost sub
               SMPerimeterWeight = SMPerimeterArea * SHEET_METAL_BASE_WEIGHT

               ' Now Find the Inner Base Panel material area, Same as above but 24" wide
               SMInnerWth = 24 + 2 + (2 * SMBaseHth)

               ' Check for the number of rows needed and calculate length
               If (W - 24) / 120 > 1 Then
                  SMInnerLth = ((W - 24) / 2) + 2 + (2 * SMBaseHth)
               ElseIf (W - 24) / 120 < 1 Then
                  SMInnerLth = (W - 24) + 2 + (2 * SMBaseHth)
               End If

               ' Area of the base panel * # of panels / 144 gets the area of metal in ft^2
               SMInnerArea = (SMInnerWth * SMInnerLth / 144) * NumBaseInnerPnls * (1 + SCRAP)

               ' cost is found in the Cost sub
               SMInnerCost = SMInnerArea * SHEET_METAL_BASE_COST

               ' weight is found in the Cost sub
               SMInnerWeight = SMInnerArea * SHEET_METAL_BASE_WEIGHT

               ' calculates total cost of the base
               SMBottomCost = SMPerimeterCost + SMInnerCost

               'calculates total weight of the base
               SMBottomWeight = SMPerimeterWeight + SMInnerWeight

               ' Jay added an additional 15% of Miselanious Material to the unit
               MisMaterialBottom = 0.1
               MisMaterialBottomCost = MisMaterialBottom * (SMBottomCost + SMFloorCost + SMInsCost)
               MisMaterialBottomWeight = MisMaterialBottom * (SMBottomWeight + SMFloorWeight + SMInsWeight)
            ElseIf isSteel Then
               ' The FA Hours For a Steel Base are just Twice that of a sheetmetal base
               ' This was stipulated by Jay Kindle and is subject to change.
               FASBPnlHrs = 2 * (NumBasePerimeterPnls + NumBaseInnerPnls) * .FAHoursPerFloorPanel
               FASBPnlCost = FASBPnlHrs * Consts.HOURLY_WAGE
               OtherSBPnlHrs = 2 * (NumBasePerimeterPnls + NumBaseInnerPnls) * .OtherHoursPerFloorPanel
               OtherSBPnlCost = OtherSBPnlHrs * Consts.HOURLY_WAGE
            End If
         End With
      End If

      ' calculates total cost of the base and panel material
      cost = ExteriorCost + InteriorCost + InsulationCost + ExteriorRoofCost + InteriorRoofCost + InsRoofCost + FAWallPnlCost + OtherWallPnlCost + FARoofPnlCost + OtherRoofPnlCost + SMBottomCost + MisMaterialBottomCost + SMFloorCost + SMInsCost + FASMPnlCost + OtherSMPnlCost + SBFloorCost + SBInsCost + SBSubFloorCost + AirSealCost1 + FAAirSealCost + OtherAirSealCost + DoorCost1 + FADoorCost + OtherDoorCost + airHandlerPainter.TotalCost + UniversalFrameCost + FAUFrameCost + SBMaterialCost + SBMisMaterialCost + FASBPnlCost + OtherSBPnlCost
      cost = Round(cost, 2)

      ' calculates total hours, but it is currently not used
      Dim totalhours, gasHeaterLaborHours, twoStage, modulating As Double

      Me.retrieveNaturalGasHeaterInfo(Me.grabGasHeaterPower(), twoStage, modulating, gasHeaterLaborHours)
      totalhours += gasHeaterLaborHours
      totalhours += US1Hours + airHandlerPainter.HoursToPaint + FAWallPnlHrs + OtherWallPnlHrs + FARoofPnlHrs + OtherRoofPnlHrs + FASMPnlHrs + OtherSMPnlHrs + FAAirSealHrs + OtherAirSealHrs + FADoorHrs + OtherDoorHrs + FAUFrameHrs + FASBPnlHrs + OtherSBPnlHrs
      totalhours = Round(totalhours, 1)
      Me.TotalHours = totalhours

      ' calculates air handler's weight
      weight = ExteriorWeight + InteriorWeight + InsWeight + ExteriorRoofWeight + InteriorRoofWeight + InsRoofWeight + SMBottomWeight + MisMaterialBottomWeight + SMFloorWeight + SBInsWeight + SBFloorWeight + SBInsWeight + SBSubFloorWeight + AirSealWeight1 + DoorWeight1 + airHandlerPainter.Weight + UniversalFrameWeight + SBMaterialWeight + SBMisMaterialWeight

   End Sub


   Private Function RetrieveMotor(ByVal efficiency As String, ByVal enclosure As String, _
   ByVal horsepower As String, ByVal RPM As Integer) As ReferenceData.MotorsDataTable
      Dim ds As New ReferenceData
      Dim motorTable As ReferenceData.MotorsDataTable

      If efficiency Is Nothing OrElse enclosure Is Nothing OrElse horsepower Is Nothing Then
         ' adds empty row if parameters are null
         ds.Motors.AddMotorsRow("", "", "", 0, "", "", "", 0, 0, 0, 0, 0, "", 0, "", 0)
         ' copies table
         motorTable = ds.Motors.Copy()
      Else
         Try
            ' retrieves motor table if parameters are not null
            motorTable = DataAgent.RetrieveMotor(efficiency, enclosure, horsepower, RPM)
         Catch ex As System.IndexOutOfRangeException
            ' motor was not found
            ' adds empty row if parameters are null
            ds.Motors.AddMotorsRow("", "", "", 0, "", "", "", 0, 0, 0, 0, 0, "", 0, "", 0)
            ' copies table
            motorTable = ds.Motors.Copy()
         End Try
      End If

      Return motorTable
   End Function


   ''' <summary>
   ''' Get coil cost; has all the parameters necessary to calculate coil cost.
   ''' </summary>
   Private Function getCoilCost(ByVal type As CoilPricingWrapper.CoilType, ByVal numRows As Integer, _
   ByVal finMaterial As CoilPricingWrapper.FinMaterial, ByVal finsPerInch As Integer, _
   ByVal isCasingStainlessSteel As Boolean, _
   ByVal tubeThickness As Double, ByVal finThickness As Double, _
   ByVal numCoils As Integer, ByVal finHeight As Double, ByVal finLength As Double) As Double
      Dim coil As New CoilPricingWrapper(type, isCasingStainlessSteel, finLength, finHeight, _
         numRows, tubeThickness, finsPerInch, finThickness, finMaterial, numCoils)

      Return coil.Price
   End Function

   ''' <summary>
   ''' Gets coil cost; retrieves coil data from data source.
   ''' </summary>
   Private Function getCoilCost(ByVal type As CoilPricingWrapper.CoilType, ByVal numRows As Integer, _
   ByVal finMaterial As CoilPricingWrapper.FinMaterial, ByVal finsPerInch As Integer, _
   ByVal isCasingStainlessSteel As Boolean, _
   ByVal tubeThickness As Double, ByVal finThickness As Double)
      Dim model As String = Me.DseProject1.SavedAirHandler(Me.airHandlerIndex).ModelNumber
      Dim coilData As AirHandlerReferenceData.CoilsRow = Business.Agents.AirHandlerDataAgent.RetrieveCoil(model)

      Dim cost As Double = Me.getCoilCost(type, numRows, finMaterial, finsPerInch, isCasingStainlessSteel, _
         tubeThickness, finThickness, coilData.NumCoils, coilData.FinHeight, coilData.FinLength)

      Return cost
   End Function

   ''' <summary>
   ''' Gets coil cost; get coil inputs from control values and data source.
   ''' </summary>
   ''' <param name="index">
   ''' Index of the control array to get coil pricing for.
   ''' </param>
   Private Function getCoilCost(ByVal index As Integer) As Double
      ' get values from controls
      '
      Dim numRows As Integer = Val(Me.cbo_rows(index).Text)
      Dim tubeThickness As Double = Val(cbo_tube_thickness(index).Text)
      Dim finThickness As Double = Val(cbo_fin_thickness(index).Text)
      Dim finsPerInch As Integer = Val(cbo_fins(index).Text)
      Dim isCasingStainlessSteel As Boolean = Me.ck_ss(index).Checked

      Dim isFinMaterialAluminum As Boolean = Me.ck_al(index).Checked
      Dim isFinMaterialCopper As Boolean = Me.ck_cu(index).Checked
      Dim finMaterial As CoilPricingWrapper.FinMaterial
      If isFinMaterialCopper Then
         finMaterial = CoilPricingWrapper.FinMaterial.Copper
      Else
         finMaterial = CoilPricingWrapper.FinMaterial.Aluminum
      End If

      Dim coilType As String = Me.cbo_coil_type(index).Text
      Dim type As CoilPricingWrapper.CoilType
      Select Case coilType
         Case "Chilled Water", "Hot Water"
            type = CoilPricingWrapper.CoilType.Water
         Case "DX"
            type = CoilPricingWrapper.CoilType.DirectExpansion
         Case "Std. Steam"
            type = CoilPricingWrapper.CoilType.Steam
         Case Else
            type = CoilPricingWrapper.CoilType.Water
      End Select

      Dim coilCost As Double = Me.getCoilCost(type, numRows, finMaterial, finsPerInch, isCasingStainlessSteel, _
         tubeThickness, finThickness)

      Return coilCost
   End Function


   Private Sub setCoilCostControlValue(ByVal index As Integer)
      Dim coilCost As Double = Me.getCoilCost(index)
      Me.lbl_coil_cost(index).Text = Round(coilCost, 2).ToString("c")
   End Sub


   'TODO: make sure called when saving; do final validation then
   ''' <summary>
   ''' Sets labels displaying cost and weight of fan
   ''' </summary>
   ''' <param name="Index">
   ''' </param>
   ''' <remarks>
   ''' Requires fan type, fan size, and hp
   ''' </remarks>
   Private Sub SetHousedFanPriceAndWeight(ByVal index As Short)
      Dim platformCost As Double = 0
      Dim fanCost As Double = 0
      Dim fanWeight As Double = 0

      'if not selected exit sub
      If Me.cbo_fan_type(index).SelectedIndex = -1 _
      Or Me.cbo_fan_size(index).SelectedIndex = -1 _
      Or Me.cbo_hp(index).SelectedIndex = -1 Then
         Exit Sub
      End If

      '// Check to see what type of blade has been selected
      '// If the DWDI BI fan type has been selected the open the HousedBIDI table from the Fans database
      If Me.cbo_fan_type(index).Text = "DWDI BI" Then
         Dim fanSize As Double
         Dim fanTable As ReferenceData.BidiFansDataTable

         ' gets fan size from control
         fanSize = CDbl(Me.cbo_fan_size(index).Text)
         ' retrieves fan table
         fanTable = DataAgent.RetrieveBidiFan(fanSize)

         Dim laborCost As Double = Consts.HOURLY_WAGE * fanTable(0).LaborHours

         Select Case Me.cbo_hp(index).SelectedItem.ToString
            Case "1", "1.5", "2", "3", "5", "7.5", "10", "15"
               platformCost = fanTable(0).PlatformCost1
            Case "20", "25", "30", "40", "50", "60", "75"
               platformCost = fanTable(0).PlatformCost2
         End Select

         ' adds fan cost and platform cost
         fanCost = fanTable(0).Cost + platformCost + laborCost
         ' sets fan weight
         fanWeight = fanTable(0).Weight

         ' type, size, and hp will be used to pick out the correct fan and price.
      ElseIf cbo_fan_type(index).Text = "DWDI FC" Then
         Dim fanSize As String
         Dim fanTable As ReferenceData.ForwardCurvedFansDataTable

         fanSize = Me.cbo_fan_size(index).Text
         ' retrieves housed forward curved fan
         fanTable = DataAgent.RetrieveForwardCurvedFan(fanSize)
         For i As Integer = 0 To fanTable.Rows.Count - 1
            ' finds fan that match selected horsepower
            If fanTable(i).HP >= CDbl(Me.cbo_hp(index).SelectedItem) Then
               Dim laborCost As Double = Consts.HOURLY_WAGE * fanTable(i).LaborHours
               fanCost = fanTable(i).Cost + fanTable(i).MotorPlatform1 + fanTable(i).MotorPlatform2 + laborCost
               fanWeight = fanTable(i).Weight
               Exit For
            End If
         Next
      End If

      Me.lbl_fan_cost(index).Text = Format(fanCost, "C")
      Me.lbl_fan_weight(index).Text = fanWeight.ToString
   End Sub


   'sets plenum fan cost label
   Private Sub updatePlenumFanControls(ByVal index As Integer)
      ' validates inputs
      If cbo_fan_class(index).SelectedIndex = -1 _
      Or cbo_fan_size(index).SelectedIndex = -1 Then
         Exit Sub : End If

      Dim fanClass As String : Dim fanSize As Double
      ' gets inputs from controls
      fanClass = Me.cbo_fan_class(index).Text
      fanSize = Me.cbo_fan_size(index).Text

      Dim cost As Double = Me.calculatePlenumFanCost(fanClass, fanSize)

      ' sets control value
      Me.lbl_fan_cost(index).Text = cost.ToString("c")
   End Sub


   ''' <summary>
   ''' Calculates plenum fan cost and includes labor.
   ''' </summary>
   Private Function calculatePlenumFanCost(ByVal fanClass As String, ByVal fanSize As Double) As Double
      Dim laborHours As Integer : Dim cost As Double

      ' retrieves plenum fan cost
      DataAgent.RetrievePlenumFanPrice(fanClass, fanSize, cost, laborHours)
      cost = laborHours * Consts.HOURLY_WAGE + cost

      Return cost
   End Function


   Private Function calculateHousedFanCost(ByVal volts As Integer, ByVal power As Double, _
   ByVal hasDisconnectSwitch As Boolean, ByVal hasScr As Boolean, ByVal numExtraStages As Integer) As Double
      Dim totalCost As Double
      Dim heaterTable As ReferenceData.DuctHeatersDataTable = DataAgent.RetrieveDuctHeaters(volts, power)

      ' totals costs
      If heaterTable.Rows.Count > 0 Then
         Dim baseListCost As Double = heaterTable(0).BaseCost

         Dim extraStageCost As Double = heaterTable(0).ExtraStageCost
         extraStageCost *= numExtraStages

         Dim disconnectSwitchCost As Double
         If hasDisconnectSwitch Then
            disconnectSwitchCost = heaterTable(0).DisconnectSwitchCost
         End If

         Dim minFusingCost As Double = heaterTable(0).FusingCostMin

         Dim scrCost As Double
         If hasScr Then
            scrCost = heaterTable(0).ScrCost
         End If

         Dim laborCost As Double = Consts.HOURLY_WAGE * heaterTable(0).LaborHours

         totalCost = baseListCost + extraStageCost + disconnectSwitchCost + minFusingCost + scrCost + laborCost
      End If

      ' applies multipliers
      totalCost = totalCost * 0.4 * HOUSED_FAN_MULTIPLIER

      Return totalCost
   End Function


   ''' <summary>
   ''' Calculates housed fan cost; updates minimum number of stages control.
   ''' </summary>
   Private Function calculateHousedFanCost() As Double
      Dim totalListCost, baseListCost, extraStageListCost, disconnectCost, minimumFusing, scrCost, laborCost As Double

      Dim volts As Double = CInt(Me.Daddy.cbo_voltage.SelectedItem)
      Dim powerKw As Double = CNull.ToDouble(Me.cbo_C3_kw.Text)
      Dim numExtraStages As Integer = CNull.ToInteger(Me.cbo_C3_extra_stages.Text)
      Dim hasDisconnectSwitch As Boolean = Me.ck_C3_disconnect.Checked
      Dim hasScr As Boolean = Me.ck_C3_scr.Checked

      Dim totalCost As Double = Me.calculateHousedFanCost(volts, powerKw, hasDisconnectSwitch, hasScr, numExtraStages)

      ' TODO: figure out way to not retrieve duct heater data twice
      Dim heaterTable As ReferenceData.DuctHeatersDataTable = DataAgent.RetrieveDuctHeaters(volts, powerKw)
      If heaterTable.Rows.Count > 0 Then
         Me.lbl_C3_min_stages_val.Text = heaterTable(0).Stage
      End If

      totalListCost = baseListCost + extraStageListCost * numExtraStages + disconnectCost + minimumFusing + scrCost + laborCost
      ' 10% for list price increase from markel
      totalListCost = totalListCost * 0.4 * HOUSED_FAN_MULTIPLIER
      Return totalListCost
   End Function


   'gets blender cost based on coil
   Private Function GetBlenderCost(ByVal coilModel As String) As Double
      Dim totalCost As Double = 0
      Dim quantity As Integer

      ' gets quantity of blenders
      Select Case coilModel
         Case "TPAH-4", "TPAH-5", "TPAH-6"
            quantity = 1
         Case "TPAH-7", "TPAH-8", "TPAH-10", "TPAH-11", "TPAH-12", "TPAH-15", "TPAH-18", "TPAH-22", "TPAH-24", _
              "TPAH-28", "TPAH-32", "TPAH-38", "TPAH-44", "TPAH-50", "TPAH-58"
            quantity = 2
         Case Else
            MessageBox.Show("Attempt to retrieve air blender cost failed. Coil model did not match values in list.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Select

      ' calculates total cost of blender
      totalCost = quantity * BlenderCost(coilModel) * BLENDER_MULTIPLIER

      Return totalCost
   End Function


   Private Sub SetFilterPriceAndWeight(ByRef Index As Short)
      Dim numFilters, filterWeight, prefilterWeight, weight As Double
      Dim filterCost, prefilterCost, cost As Double
      Dim cabinetIndex, numPreFilterSets, numFilterSets As Integer
      Dim filtersTable As ReferenceData.FiltersDataTable

      'sets number of filters for unit selected
      cabinetIndex = Me.DseProject1.SavedAirHandler(Me.airHandlerIndex).CabinetIndex
        ''numFilters = Me.dgrC1Select.Splits(0).DisplayColumns("NumFilters").DataColumn.CellValue(cabinetIndex)
        numPreFilterSets = Val(cbo_pre_sets(Index).Text)
      numFilterSets = Val(cbo_ff_sets(Index).Text)

      filtersTable = DataAgent.RetrieveFilters()

      For i As Integer = 0 To filtersTable.Rows.Count - 1
         ' pre-filter
         If Not Me.cbo_pre_ff(Index).SelectedItem Is Nothing _
         AndAlso Me.cbo_pre_ff(Index).SelectedItem = filtersTable(i).Specification Then
            Dim laborCost As Double = filtersTable(i).LaborHours * Consts.HOURLY_WAGE
            ' .45 is the Filter price multiplier supplied by Jay Kindle
            prefilterCost = filtersTable(i).ListPrice * FILTER_MULTIPLIER + laborCost
            prefilterWeight = filtersTable(i).Weight

            ' filter
         ElseIf Not Me.cbo_ff(Index).SelectedItem Is Nothing _
         AndAlso Me.cbo_ff(Index).SelectedItem = filtersTable(i).Specification Then
            Dim laborCost As Double = filtersTable(i).LaborHours * Consts.HOURLY_WAGE
            ' .45 is the Filter price multiplier supplied by Jay Kindle
            filterCost = filtersTable(i).ListPrice * FILTER_MULTIPLIER + laborCost
            filterWeight = filtersTable(i).Weight
         End If
      Next

      ' sums the total cost of the filters including the extra sets if ordered
      cost = (prefilterCost * numFilters) _
         + (prefilterCost * numFilters) * numPreFilterSets _
         + (filterCost * numFilters) _
         + (filterCost * numFilters) * numFilterSets
      ' weight of the filters in the unit not including the extra sets ordered
      weight = (prefilterWeight * numFilters) + (filterWeight * numFilters)

      'sets control values
      Me.lbl_ff_cost(Index).Text = Format(cost, "c")
      Me.lbl_ff_weight(Index).Text = CStr(Round(weight, 2))
   End Sub


   Private Sub MixingBoxCost(ByRef index As Integer)
      Dim numHoods As Double
      Dim FAHoodHrs, otherHoodHrs As Double
      Dim FAHoodCost, otherHoodCost, damperCost As Double
      'height of Open Air, height of Return Air
      Dim heightOA, heightRA As Double
      Dim model, mixingBoxMetal As String

      mixingBoxMetal = Me.GetMixingBoxMetal(index)
      'didn't work Me.DseProject1.SectionDetails.Rows(0)("MB" & (index + 1).ToString & "Casing")
      model = Me.DseProject1.SavedAirHandler(Me.airHandlerIndex).ModelNumber

      Dim damperTable As ReferenceData.DampersDataTable
      Dim damperType As String

      damperType = Me.cbo_mixing_box(index).SelectedItem

      ' determines whether parameters are null
      If model Is Nothing OrElse damperType Is Nothing OrElse mixingBoxMetal Is Nothing Then Exit Sub

      ' retrieves damper
      damperTable = DataAgent.RetrieveDamper(model, damperType, mixingBoxMetal)

      If damperTable.Rows.Count > 0 Then
         '// .56 is the Vent Products Co. Multiplier
         model = damperTable(0).Model
         Select Case model
            Case "TPAH-4", "TPAH-5", "TPAH-6", "TPAH-7", "TPAH-8", "TPAH-10", "TPAH-11", "TPAH-12", "TPAH-15", "TPAH-24"
               damperCost = damperTable(0).Cost * VENT_PRODUCTS_CO_MULTIPLIER
               'these models will have two dampers in them, so they are multiplied by 2
               '// The value for TPAH-18 RA is not doubled so the price was cut in half in the database
            Case "TPAH-18", "TPAH-22", "TPAH-24", "TPAH-28", "TPAH-32", "TPAH-38", "TPAH-44", "TPAH-50", "TPAH-58"
               damperCost = damperTable(0).Cost * VENT_PRODUCTS_CO_MULTIPLIER * 2
         End Select

         ' sometimes one will be null if not both OA & RA
         heightOA = CNull.ToDouble(damperTable(0).OAHeight)
         heightRA = CNull.ToDouble(damperTable(0).RAHeight)

         '// Markups for freight given by Jay Kindle
         damperCost = damperCost * DamperMultiplier(heightOA, heightRA)
         damperCost = damperCost + (damperTable(0).LaborHours * Consts.HOURLY_WAGE)
         '// FA and Other Hours given by Jay Kindle
         If damperTable(0).Type = "OA" Then
            '// The outside air mixing boxs need to have rain hoods
            '// Each hood is 18" tall so the heighth of the opening/18 gives the number of hoods
            numHoods = heightOA / 18
            '// Round UP
            numHoods = Ceiling(numHoods)
         End If



         Dim hoursTable As ReferenceData.HoursDataTable

         ' retrieves hours
         hoursTable = DataAgent.RetrieveHours(model)

         If hoursTable.Rows.Count > 0 Then
            '// To hide the real hours in the database I multiplied them by 2.3
            FAHoodHrs = numHoods * hoursTable(0).FAHoodHours
            otherHoodHrs = numHoods * hoursTable(0).OtherHoodHours
            FAHoodCost = FAHoodHrs * Consts.HOURLY_WAGE
            otherHoodCost = otherHoodHrs * Consts.HOURLY_WAGE
         End If
      End If

      'calculates cost of the mixing box; DamperCost + Hours
      Me.lbl_MB1_cost(index).Text = Format(damperCost + FAHoodCost + otherHoodCost, "c")
   End Sub


#End Region


   Private Sub UpdateOrderIndices()
      'saves order indices
      Try
         With Me.DseProject1.SectionDetails.Rows(0)
            .Item(Me.DseProject1.SectionDetails.MB1OrderIndexColumn) = Me.panMB1Container.Text
            .Item(Me.DseProject1.SectionDetails.MB2OrderIndexColumn) = Me.panMB2Container.Text
            .Item(Me.DseProject1.SectionDetails.Filt0OrderIndexColumn) = Me.panFF1Container.Text
            .Item(Me.DseProject1.SectionDetails.Filt1OrderIndexColumn) = Me.panFF2Container.Text
            .Item(Me.DseProject1.SectionDetails.Filt2OrderIndexColumn) = Me.panFF3Container.Text
            .Item(Me.DseProject1.SectionDetails.Fan0OrderIndexColumn) = Me.panFan1Container.Text
            .Item(Me.DseProject1.SectionDetails.Fan1OrderIndexColumn) = Me.panFan2Container.Text
            .Item(Me.DseProject1.SectionDetails.Fan2OrderIndexColumn) = Me.panFan3Container.Text

            .Item(Me.DseProject1.SectionDetails.Coil0OrderIndexColumn) = Me.panCoil1Container.Text
            .Item(Me.DseProject1.SectionDetails.Coil1OrderIndexColumn) = Me.panCoil2Container.Text
            .Item(Me.DseProject1.SectionDetails.Coil2OrderIndexColumn) = Me.panCoil3Container.Text
            .Item(Me.DseProject1.SectionDetails.Coil3OrderIndexColumn) = Me.panCoil4Container.Text
            .Item(Me.DseProject1.SectionDetails.Coil4OrderIndexColumn) = Me.panGasHeaterContainer.Text
            '.Item(Me.DseProject1.SectionDetails.Coil4OrderIndexColumn) = Me.panCoil5Container.Text

            .Item(Me.DseProject1.SectionDetails.C3OrderIndexColumn) = Me.panC3Container.Text
            .Item(Me.DseProject1.SectionDetails.DischargeOrderIndexColumn) = Me.panDischargeContainer.Text
         End With
      Catch Ex As Exception
         MessageBox.Show("Attempt to save order indices failed. " & Ex.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub



   'saves the unit info to InfoReturn-UnitInfo and InfoReturn-PrintUnitInfo1
   Private Sub SaveUnit()
      Dim numAirHandlers As Integer
      Dim cabinetLength, cabinetWidth, cabinetHeight As Integer

      'this is necessary to update the value in the DischargeChkValue data
      'bound label; otherwise when UpdateOrderIndices runs the discharge
      'changes are lost
      Me.BindingContext(Me.DseProject1.SectionDetails).EndCurrentEdit()
      'updates order indices in section details
      Me.UpdateOrderIndices()

      With Me.DseProject1.SavedAirHandler
         'if current edit is not ended, the base material selected will be lost when
         'records are set programmatically
         Me.BindingContext(Me.DseProject1.SavedAirHandler).EndCurrentEdit()
         'updates variables that are dependent upon the sections chosen
         Me.GetDatasetCabinetDimensions(cabinetLength, cabinetWidth, cabinetHeight)
         'stores dimensions in dataset, updates summary datagrid in project form
         .Rows(Me.airHandlerIndex)(.LengthColumn) = cabinetLength
         .Rows(Me.airHandlerIndex)(.WidthColumn) = cabinetWidth
         .Rows(Me.airHandlerIndex)(.HeightColumn) = cabinetHeight

         'displays the cost of the unit on the summary page
         Me.Costs(cabinetLength, cabinetWidth, cabinetHeight)
      End With

      With Me.DseProject1
         'counts number of air handlers
         numAirHandlers = .SavedAirHandler.Rows.Count
         'stores number of air handlers
         .SavedProject.Rows(0)(.SavedProject.QuantityColumn) = numAirHandlers
         'stores number of air seals
         .SavedAirHandler.Rows(Me.airHandlerIndex)( _
            .SavedAirHandler.NumAirSealsColumn) = Me.lblAirSealQuantity.Text
         'stores number of doors
         .SavedAirHandler.Rows(Me.airHandlerIndex)(.SavedAirHandler.NumDoorsColumn) _
            = Me.txt_doors.Text

         'updates databases
         '--------------------------------------------------------------
         'saves air handler data (model, cabinetIndex, coil and filter size and FV)
         Me.BindingContext(.SavedAirHandler).EndCurrentEdit()
         Try
            Me.dadAirHandler.Update(.SavedAirHandler)
            Me.SaveTotalHours(.SavedAirHandler(Me.airHandlerIndex).AirHandlerID, Me.TotalHours)
         Catch Ex As System.Data.DBConcurrencyException
            Ui.MessageBox.Show("Attempt to save air handler failed. " & Ex.Message)
         End Try

         'saves section data (Abbr, Length, OrderIndex)
         Me.BindingContext(._Section).EndCurrentEdit()
         Try
            Me.dadSection.Update(._Section)
         Catch Ex1 As Exception
            Ui.MessageBox.Show("Attempt to save sections failed. " & Ex1.Message)
         End Try

         Try
            'saves section details
            Me.BindingContext(.SectionDetails).EndCurrentEdit()
            Me.dadSectionDetails.ContinueUpdateOnError = False
            Dim insert As String = "INSERT INTO SectionDetails(AirHandlerID, C3Disconnect, C3KW, C3MinNumStages, C3NumExtraStages, C3OperatingTemperature, C3OrderIndex, C3SiliconControlledRectifier, Coil0OrderIndex, Coil1OrderIndex, Coil2OrderIndex, CoilCasing0, CoilCasing1, CoilCasing2, CoilRows0, CoilRows1, CoilRows2, CoilType0, CoilType1, CoilType2, DischargeGrating, DischargeHeight, DischargeOpeningLocation, DischargeOrderIndex, DischargeWidth, Fan0OrderIndex, Fan1OrderIndex, Fan2OrderIndex, FanClass0, FanClass1, FanClass2, FanDrive0, FanDrive1, FanDrive2, FanEfficiency0, FanEfficiency1, FanEfficiency2, FanEnclosure0, FanEnclosure1, FanEnclosure2, FanHorsepower0, FanHorsepower1, FanHorsepower2, FanIsolator0, FanIsolator1, FanIsolator2, FanRPM0, FanRPM1, FanRPM2, FanSize0, FanSize1, FanSize2, FanType0, FanType1, FanType2, Filt0, Filt0OrderIndex, Filt1, Filt1OrderIndex, Filt2, Filt2OrderIndex, FinMaterial0, FinMaterial1, FinMaterial2, FinThickness0, FinThickness1, FinThickness2, MB1Casing, MB1IncomingAir, MB1OrderIndex, MB2Casing, MB2IncomingAir, MB2OrderIndex, NumFilts0, NumFilts1, NumFilts2, NumFins0, NumFins1, NumFins2, NumPreFilts0, NumPreFilts1, NumPreFilts2, PreFilt0, PreFilt1, PreFilt2, TubeThickness0, TubeThickness1, TubeThickness2, CoilType4 ,FinMaterial4, Coil4OrderIndex) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
            Dim update As String = "UPDATE SectionDetails SET AirHandlerID = ?, C3Disconnect = ?, C3KW = ?, C3MinNumStages = ?, C3NumExtraStages = ?, C3OperatingTemperature = ?, C3OrderIndex = ?, C3SiliconControlledRectifier = ?, Coil0OrderIndex = ?, Coil1OrderIndex = ?, Coil2OrderIndex = ?, CoilCasing0 = ?, CoilCasing1 = ?, CoilCasing2 = ?, CoilRows0 = ?, CoilRows1 = ?, CoilRows2 = ?, CoilType0 = ?, CoilType1 = ?, CoilType2 = ?, DischargeGrating = ?, DischargeHeight = ?, DischargeOpeningLocation = ?, DischargeOrderIndex = ?, DischargeWidth = ?, Fan0OrderIndex = ?, Fan1OrderIndex = ?, Fan2OrderIndex = ?, FanClass0 = ?, FanClass1 = ?, FanClass2 = ?, FanDrive0 = ?, FanDrive1 = ?, FanDrive2 = ?, FanEfficiency0 = ?, FanEfficiency1 = ?, FanEfficiency2 = ?, FanEnclosure0 = ?, FanEnclosure1 = ?, FanEnclosure2 = ?, FanHorsepower0 = ?, FanHorsepower1 = ?, FanHorsepower2 = ?, FanIsolator0 = ?, FanIsolator1 = ?, FanIsolator2 = ?, FanRPM0 = ?, FanRPM1 = ?, FanRPM2 = ?, FanSize0 = ?, FanSize1 = ?, FanSize2 = ?, FanType0 = ?, FanType1 = ?, FanType2 = ?, Filt0 = ?, Filt0OrderIndex = ?, Filt1 = ?, Filt1OrderIndex = ?, Filt2 = ?, Filt2OrderIndex = ?, FinMaterial0 = ?, FinMaterial1 = ?, FinMaterial2 = ?, FinThickness0 = ?, FinThickness1 = ?, FinThickness2 = ?, MB1Casing = ?, MB1IncomingAir = ?, MB1OrderIndex = ?, MB2Casing = ?, MB2IncomingAir = ?, MB2OrderIndex = ?, NumFilts0 = ?, NumFilts1 = ?, NumFilts2 = ?, NumFins0 = ?, NumFins1 = ?, NumFins2 = ?, NumPreFilts0 = ?, NumPreFilts1 = ?, NumPreFilts2 = ?, PreFilt0 = ?, PreFilt1 = ?, PreFilt2 = ?, TubeThickness0 = ?, TubeThickness1 = ?, TubeThickness2 = ?, CoilType4 = ?, FinMaterial4 = ?, Coil4OrderIndex = ? WHERE (SectionDetailsID = ?)"
            Me.dadSectionDetails.InsertCommand.CommandText = insert
            Me.dadSectionDetails.UpdateCommand.CommandText = update
            Me.dadSectionDetails.Update(.SectionDetails)
         Catch Ex2 As Exception
            Ui.MessageBox.Show("Attempt to save section details failed. " & Ex2.Message)
         End Try
      End With
      '-------------------------------------------------------------

      'puts an 'X' next to unit's row to indicate its selection
      'Me.Daddy.lbl_X(unit).Visible = True
      'Me.Daddy.lbl_X(unit).Text = "X"

      '// Check to make sure all the required selections were made
      'SelectionCheck()

   End Sub


   Private Sub GetDatasetCabinetDimensions(ByRef cabinetLength As Integer, ByRef cabinetWidth As Integer, ByRef cabinetHeight As Integer)
      Dim model As String
      Dim dimensionsTable As ReferenceData.SectionDimensionsDataTable

      cabinetLength = 0
      model = Me.DseProject1.SavedAirHandler(Me.airHandlerIndex).ModelNumber

      ' retrieves dimensions for air handler model
      dimensionsTable = DataAgent.RetrieveDimensions(model)

      cabinetWidth = dimensionsTable(0).W
      cabinetHeight = dimensionsTable(0).H

      ' sums each section's length
      For i As Integer = 0 To Me.DseProject1._Section.Rows.Count - 1
         cabinetLength += Me.DseProject1._Section(i).SectionLength
      Next

   End Sub


   Private Sub HeaterKW()
      Dim kw50, kw100, kw75, kw25 As Single
      Dim minAirflow As Single
      Dim cabinetIndex As Integer

      cabinetIndex = Me.DseProject1.SavedAirHandler(Me.airHandlerIndex).CabinetIndex
        ' gets Airflow Minimum corresponding to the Model selected
        ''minAirflow = Me.dgrC1Select(cabinetIndex)("AirflowMin")

        '// Find and load the possible kw's to the form
        '// The value 3413 converts BTU to cfm because the 1.0845 term has BTU in it.
        '// 1.0845 is the density * specific weight * a 60min/1hr conversion
        kw100 = 1.0845 * 100 * minAirflow / 3413
      kw75 = 1.0845 * 75 * minAirflow / 3413
      kw50 = 1.0845 * 50 * minAirflow / 3413
      kw25 = 1.0845 * 25 * minAirflow / 3413

      '// First clear the combo box so you don't add KW's to a list and select the wrong one
      cbo_C3_kw.Items.Clear()
      '// Then add the new KW's
      cbo_C3_kw.Items.Add(CStr(Round(kw100, 1)))
      cbo_C3_kw.Items.Add(CStr(Round(kw75, 1)))
      cbo_C3_kw.Items.Add(CStr(Round(kw50, 1)))
      cbo_C3_kw.Items.Add(CStr(Round(kw25, 1)))
   End Sub


   'TODO: get good label text from jay for each control so warning messages
   '      can be more specific
   Private Function GetValidationMessage() As String
      Dim i As Integer
      Dim container As Control
      Dim ctrl As New Control
      Dim subCtrl As New Control
      Dim orderIndex As Integer
      Dim message As String = ""
      Dim returnTwice As String = Environment.NewLine & Environment.NewLine

      'checks the base type
      If Not Me.radBaseMaterialSheetMetal.Checked _
      And Not Me.radBaseMaterialSteel.Checked Then
         message = "- choose a base material" & returnTwice
      End If
      'checks section control input
      For i = 0 To Me.DseProject1._Section.Rows.Count - 1
         orderIndex = Me.DseProject1._Section.Rows(i)(Me.DseProject1._Section.OrderIndexColumn)
         If orderIndex < 0 Then
            MessageBox.Show("Attempt to validate user input failed. Order index is negative.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
         Else
            Select Case Me.ConvertToEnum(Me.DseProject1._Section.Rows(i)(Me.DseProject1._Section.AbbreviationColumn), GetType(sectionAbbreviation))

               'mixing box
               Case sectionAbbreviation.MB1
                  Dim aluminumChecked As Boolean = True
                  Dim galvanizedChecked As Boolean = True

                  container = Me.GetSectionControlsContainer(orderIndex)
                  For Each ctrl In container.Controls
                     If ctrl.Name.StartsWith("panMixingBox") Then
                        For Each subCtrl In ctrl.Controls
                           If subCtrl.Name.StartsWith("_cbo_mixing_box") Then
                              If subCtrl.Text = "" Then
                                 message &= "- select mixing box options" & returnTwice
                              End If
                           ElseIf subCtrl.Name.StartsWith("_ck_MB1_al") Then
                              aluminumChecked = CType(subCtrl, CheckBox).Checked
                           ElseIf subCtrl.Name.StartsWith("_ck_MB1_gal") Then
                              galvanizedChecked = CType(subCtrl, CheckBox).Checked
                           End If
                        Next
                        'once panel is found the other controls don't need to be checked
                        Exit For
                     End If
                  Next
                  If aluminumChecked = False And galvanizedChecked = False Then
                     message &= "- select mixing box material" & returnTwice
                  End If

               Case sectionAbbreviation.FF1
                  container = Me.GetSectionControlsContainer(orderIndex)
                  For Each ctrl In container.Controls
                     If ctrl.Name.EndsWith("Prefilter") Then
                        For Each subCtrl In ctrl.Controls
                           If subCtrl.Name.StartsWith("_cbo_pre_ff") Then
                              If subCtrl.Text = "" Then
                                 message &= "- select a filter" & returnTwice
                              End If
                           End If
                        Next
                     End If
                  Next

               Case sectionAbbreviation.FF2
                  container = Me.GetSectionControlsContainer(orderIndex)
                  For Each ctrl In container.Controls
                     If ctrl.Name.EndsWith("Prefilter") Then
                        For Each subCtrl In ctrl.Controls
                           If subCtrl.Name.StartsWith("_cbo_pre_ff") Then
                              If subCtrl.Text = "" Then
                                 message &= "- select a pre-filter" & returnTwice
                              End If
                           ElseIf subCtrl.Name.StartsWith("_cbo_final_filter") Then
                              If subCtrl.Text = "" Then
                                 message &= "- select a final filter" & returnTwice
                              End If
                           End If
                        Next
                     End If
                  Next

               Case sectionAbbreviation.HF1, sectionAbbreviation.HF2, sectionAbbreviation.PF1
                  container = Me.GetSectionControlsContainer(orderIndex)
                  Dim efficiencyHigh, efficiencyPremium As Boolean
                  Dim enclosureODP, enclosureTEFC As Boolean

                  For Each ctrl In container.Controls
                     'motor options
                     If ctrl.Name.StartsWith("pan") And ctrl.Name.EndsWith("Motor") Then
                        For Each subCtrl In ctrl.Controls
                           If subCtrl.Name.StartsWith("_ck_high") Then
                              efficiencyHigh = CType(subCtrl, CheckBox).Checked
                           ElseIf subCtrl.Name.StartsWith("_ck_premium") Then
                              efficiencyPremium = CType(subCtrl, CheckBox).Checked
                           ElseIf subCtrl.Name.StartsWith("_ck_odp") Then
                              enclosureODP = CType(subCtrl, CheckBox).Checked
                           ElseIf subCtrl.Name.StartsWith("_ck_tefc") Then
                              enclosureTEFC = CType(subCtrl, CheckBox).Checked
                           ElseIf subCtrl.Name.StartsWith("_cbo_hp") Then
                              If subCtrl.Text = "" Then
                                 message &= "- select fan motor options" & returnTwice
                              End If
                           End If
                        Next
                     End If
                     'fan options
                     If ctrl.Name.StartsWith("pan") And ctrl.Name.EndsWith("Fan") Then
                        For Each subCtrl In ctrl.Controls
                           If subCtrl.Name.StartsWith("_cbo") Then
                              If subCtrl.Text = "" Then
                                 message &= "- select fan options" & returnTwice
                                 'prevents same warning message from appearing multiple times
                                 Exit Select
                              End If
                           End If
                        Next
                     End If
                  Next
                  If efficiencyHigh = False And efficiencyPremium = False Then
                     message &= "- select motor efficiency" & returnTwice
                  End If
                  If enclosureODP = False And enclosureTEFC = False Then
                     message &= "- select motor enclosure" & returnTwice
                  End If


               Case sectionAbbreviation.C1, sectionAbbreviation.C2
                  container = Me.GetSectionControlsContainer(orderIndex)
                  Dim aluminum, copper As Boolean
                  Dim stainless, galvanized As Boolean

                  For Each ctrl In container.Controls
                     If ctrl.Name.StartsWith("pan") Then
                        For Each subCtrl In ctrl.Controls
                           If subCtrl.Name.StartsWith("_cbo") Then
                              If subCtrl.Text = "" Then
                                 message &= "- choose all coil options" & returnTwice
                                 'prevents same error message from occuring multiple times
                                 Exit Select
                              End If
                           ElseIf subCtrl.Name.StartsWith("_ck_al") Then
                              aluminum = CType(subCtrl, CheckBox).Checked
                           ElseIf subCtrl.Name.StartsWith("_ck_cu") Then
                              copper = CType(subCtrl, CheckBox).Checked
                           ElseIf subCtrl.Name.StartsWith("_ck_ss") Then
                              stainless = CType(subCtrl, CheckBox).Checked
                           ElseIf subCtrl.Name.StartsWith("_ck_gal") Then
                              galvanized = CType(subCtrl, CheckBox).Checked
                           End If
                        Next
                     End If
                  Next
                  If aluminum = False And copper = False Then
                     message &= "- select coil options" & returnTwice
                  End If
                  If stainless = False And galvanized = False Then
                     message &= "- select coil options" & returnTwice
                  End If

               Case sectionAbbreviation.C3
                  container = Me.GetSectionControlsContainer(orderIndex)
                  If Me.cbo_C3_kw.Text = "" Then
                     message &= "- select the heater KW" & returnTwice
                  End If

               Case sectionAbbreviation.D1
                  container = Me.GetSectionControlsContainer(orderIndex)
                  If Me.radD1Ceiling.Checked = False And Me.radD1EndWall.Checked = False And Me.radD1Floor.Checked = False Then
                     message &= "- select discharge options" & returnTwice
                  End If
            End Select
         End If
      Next

      Return message
   End Function


   Private Sub Volt460(ByRef volts As Short)
      Dim stageList As Decimal
      Dim heaterTotalList As Decimal
      Dim base, stages As Single
      Dim minAirflow As Single
      Dim altitude As Single
      Dim cabinetIndex As Integer
      Dim kw As Single
      Dim extraStages As Single

      cabinetIndex = Me.DseProject1.SavedAirHandler(Me.airHandlerIndex).CabinetIndex
        ''minAirflow = Me.dgrC1Select(cabinetIndex)("AirflowMin")
        altitude = Me.Daddy.txt_altitude.Text
      kw = ConvertNull.ToSingle(Me.cbo_C3_kw.Text)
      extraStages = ConvertNull.ToSingle(Me.cbo_C3_extra_stages.Text)

      Try
         '// Check to see if the KW is out of the pricing range
         '// If so then use the catalogs formulas to calculate the price
         If CNull.ToDouble(cbo_C3_kw.Text) > 119.8 Then
            base = 24 * kw
            stages = Round(kw / 39.9, 0)
            stageList = (stages + extraStages) * 245
            heaterTotalList = base + stageList

            Me.lbl_C3_min_stages_val.Text = CStr(stages)
            Me.lbl_heater_cost.Text = heaterTotalList.ToString("c")

            Me.ck_C3_disconnect.Enabled = False
            Me.ck_C3_scr.Enabled = False

            ' actual temp difference
            Dim operatingTemperature As Double = Me.calculateCoilOperatingTemperature(kw, minAirflow, altitude)
            Me.lbl_C3_op_temp_1.Text = operatingTemperature & " F"
         Else
            heaterTotalList = Me.calculateHousedFanCost()
            Me.lbl_heater_cost.Text = heaterTotalList.ToString("c")

            Dim operatingTemperature As Double = Me.calculateCoilOperatingTemperature(kw, minAirflow, altitude)
            Me.lbl_C3_op_temp_1.Text = operatingTemperature.ToString & " F"
         End If
      Catch ex As Exception
         MessageBox.Show("Error occurred while handling C3 (Coil) options. " & ex.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub


   Private Sub Volt230(ByRef volts As Short)
      Dim heaterTotalList As Decimal
      Dim minAirflow As Double
      Dim altitude As Double
      Dim cabinetIndex As Integer

      '// Check to see if the KW is out of the pricing range
      '// If so then prompt the user to consult factory for pricing
      If CNull.ToDouble(Me.cbo_C3_kw.Text) > 99.6 Then
         Me.ck_C3_disconnect.Enabled = False
         Me.ck_C3_scr.Enabled = False
         Me.lbl_heater_cost.Text = (0).ToString("c")

         MessageBox.Show("Consult factor for pricing.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Else
         cabinetIndex = Me.DseProject1.SavedAirHandler(Me.airHandlerIndex).CabinetIndex
            ''minAirflow = Me.dgrC1Select(cabinetIndex)("AirflowMin")
            altitude = Me.Daddy.txt_altitude.Text
         heaterTotalList = Me.calculateHousedFanCost()
         Dim powerKw As Double = CDbl(Me.cbo_C3_kw.Text)

         Dim operatingTemperature As Double = Me.calculateCoilOperatingTemperature(powerKw, minAirflow, altitude)
         Me.lbl_C3_op_temp_1.Text = operatingTemperature.ToString() & " F"
         Me.lbl_heater_cost.Text = heaterTotalList.ToString("c")
      End If
   End Sub


   Private Function calculateCoilOperatingTemperature( _
   ByVal powerKw As Double, ByVal minAirFlow As Double, ByVal altitude As Double) As Double
      ' line fit to data found on density changing with altitude
      Dim roeAltitude As Double = 2 * 10 ^ (-11) * altitude - 2 * 10 ^ (-6) * altitude + 0.0766
      Dim temperature As Double = powerKw / minAirFlow * 3413 / roeAltitude / 60 / 0.241
      temperature = Round(temperature, 1)

      Return temperature
   End Function


   Public Sub Volt208(ByRef volts As Short)
      Dim heaterTotalList As Decimal
      Dim i As Integer
      Dim altitude As Double
      Dim cabinetIndex As Integer

      altitude = CDbl(Me.Daddy.txt_altitude.Text)
      cabinetIndex = Me.DseProject1.SavedAirHandler(Me.airHandlerIndex).CabinetIndex

      If CNull.ToDouble(Me.cbo_C3_kw.Text) > 86 Then
         Me.ck_C3_disconnect.Enabled = False
         Me.ck_C3_scr.Enabled = False
         Me.lbl_heater_cost.Text = (0).ToString("c")
         Ui.MessageBox.Show("Consult factory for pricing.", MessageBoxIcon.Information)
      Else
         heaterTotalList = Me.calculateHousedFanCost()
         Me.lbl_heater_cost.Text = heaterTotalList.ToString("c")

            ''Dim minAirflow As Double = Me.dgrC1Select(cabinetIndex)("AirflowMin")
            Dim powerKw As Double = CDbl(Me.cbo_C3_kw.Text)
            ''Dim operatingTemperature As Double = Me.calculateCoilOperatingTemperature(powerKw, minAirflow, altitude)
            ''Me.lbl_C3_op_temp_1.Text = operatingTemperature.ToString() & " F"
        End If
   End Sub


   'fills rpm combobox based on (Efficiency, Enclosure, HP, and Voltage)
   Private Sub FillMotorRPM(ByVal Index As Integer)
      Dim motorsTable As ReferenceData.MotorsDataTable
      Dim cboVoltage As New ComboBox
      Dim efficiency, enclosure, hp As String

      ' grabs parameters from controls
      '
      If Me.ck_high(Index).Checked Then
         efficiency = "High"
      ElseIf Me.ck_premium(Index).Checked = True Then
         efficiency = "Premium"
      Else
         Exit Sub
      End If
      If Me.ck_odp(Index).Checked = True Then
         enclosure = "ODP"
      ElseIf Me.ck_tefc(Index).Checked = True Then
         enclosure = "TEFC"
      Else
         Exit Sub
      End If
      hp = Me.cbo_hp(Index).SelectedItem
      If hp Is Nothing Then Exit Sub

      ' retrieves motors
      motorsTable = DataAgent.RetrieveMotors(efficiency, enclosure, hp)

      If motorsTable.Rows.Count > 0 Then
         ' clears rpm combobox
         Me.cbo_rpm(Index).Items.Clear()
         ' references control from other form
         cboVoltage = Me.Daddy.cbo_voltage

         If Val(cboVoltage.Text) = 208 Then
            ' loops through each row in motors table
            For i As Integer = 0 To motorsTable.Rows.Count - 1
               ' adds item to combobox if voltage code is not F
               If motorsTable(i).VoltageCode = "F" Then
               Else
                  ' adds rpm to combobox
                  cbo_rpm(Index).Items.Add(motorsTable(i).RPM.ToString)
               End If
            Next
         Else
            For i As Integer = 0 To motorsTable.Rows.Count - 1
               ' adds rpm to combobox
               Me.cbo_rpm(Index).Items.Add(motorsTable(i).RPM.ToString)
            Next
         End If
      End If

      ' selects default; prevents null value
      Me.cbo_rpm(Index).SelectedIndex = 0
   End Sub



   Dim gMouseDownRow As Integer = 0
   Dim gSelectedRow As Integer = 0
   Dim gPreviousRow As Integer = 0
    'Private Sub dgrC1Select_MouseDown(ByVal sender As System.Object, ByVal e As MouseEventArgs) _
    'Handles dgrC1Select.MouseDown
    '   gMouseDownRow = Me.dgrC1Select.RowContaining(e.Y)
    'End Sub
    'Private Sub dgrC1Select_MouseUp(ByVal sender As System.Object, ByVal e As MouseEventArgs) _
    'Handles dgrC1Select.MouseUp
    '   Dim rowUp As Integer = Me.dgrC1Select.RowContaining(e.Y)

    '   If rowUp = gMouseDownRow And rowUp > -1 Then
    '      '>> if user has made any section selections
    '      '>> if this cabinet index is not already selected
    '      If Me.DseProject1._Section.Rows.Count > 0 And gSelectedRow <> rowUp Then
    '         Dim result As DialogResult
    '         'warns user section data will be lost if model changes
    '         result = MessageBox.Show("Due to the sections' dependence upon the selected model, changing the model requires the current section data to be cleared." & _
    '            Environment.NewLine & Environment.NewLine & _
    '            "Do you want to change models?", "RAESolutions", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
    '         If result = DialogResult.Yes Then
    '            gPreviousRow = gSelectedRow
    '            gSelectedRow = rowUp
    '            'removes all section and sectiondetails rows
    '            Me.RemoveAllSections()
    '            'adds new section details row; since the previous one was deleted
    '            Me.AddSectionDetailsRow()
    '            Me.populateC5Powers(Me.DseProject1.SavedAirHandler(Me.airHandlerIndex).ModelNumber)
    '         End If
    '      Else
    '         Me.gPreviousRow = Me.gSelectedRow
    '         Me.gSelectedRow = rowUp
    '      End If
    '   End If

    '   'selects row and sets dataset values
    '   Me.SelectModel(gSelectedRow)

    '   'testing below
    '   'Dim row2 As Integer = -2
    '   'If Me.dgrC1Select.SelectedRows.Count > 0 Then
    '   '   row2 = Me.dgrC1Select.SelectedRows.Item(0)
    '   'End If
    '   'Console.WriteLine("Y Row: " & row.ToString & "    Selected Row: " & row2.ToString & "     Count: " & Me.dgrC1Select.SelectedRows.Count)
    'End Sub


    'selects model in datagrid and sets dataset appropriately
    Private Sub SelectModel(ByVal rowIndex As Integer)
      Dim cabinetIndex As Integer
      Dim modelNum As String

        'clears any current row selections
        ''Me.dgrC1Select.SelectedRows.Clear()
        'selects row that MouseDown and MouseUp occured on
        ''Me.dgrC1Select.SelectedRows.Add(rowIndex)
        'sets row index
        ''cabinetIndex = Me.dgrC1Select.SelectedRows(0)

        'sets related dataset values
        '
        'sets cabinet index to selected rows index
        Me.DseProject1.SavedAirHandler(Me.airHandlerIndex).CabinetIndex = cabinetIndex
        'sets model number
        ''Me.DseProject1.SavedAirHandler(Me.airHandlerIndex).ModelNumber = Me.dgrC1Select.Columns("Model").CellText(cabinetIndex)
        ''modelNum = Me.dgrC1Select.Columns("Model").CellText(cabinetIndex)
        'sets coil size
        ''Me.DseProject1.SavedAirHandler(Me.airHandlerIndex).CoilSize = _
        ''Me.dgrC1Select.Columns("FinLength").CellText(cabinetIndex) & "x" & _
        ''Me.dgrC1Select.Columns("FinHeight").CellText(cabinetIndex)
        'sets coil face velocity
        ''Me.DseProject1.SavedAirHandler(Me.airHandlerIndex).CoilFaceVelocity = _
        ''Me.dgrC1Select.Columns("Coil Face Velocity").CellText(cabinetIndex)
        'sets filter size
        ''Me.DseProject1.SavedAirHandler(Me.airHandlerIndex).FilterSize = _
        ''Me.dgrC1Select.Columns("FilterLength").CellText(cabinetIndex) & "x" & _
        ''Me.dgrC1Select.Columns("FilterHeight").CellText(cabinetIndex)
        'sets filter face velocity
        ''Me.DseProject1.SavedAirHandler(Me.airHandlerIndex).FilterFaceVelocity = _
        ''Me.dgrC1Select.Columns("Filter Face Velocity").CellText(cabinetIndex)

        'checks steel and disables sheet metal for base material if unit is TPAH-22 or larger
        Select Case modelNum
         Case "TPAH-22", "TPAH-24", "TPAH-28", "TPAH-32", "TPAH-38", "TPAH-44", "TPAH-50", "TPAH-58"
            Me.radBaseMaterialSheetMetal.Enabled = False
            Me.radBaseMaterialSteel.Checked = True
         Case Else
            Me.radBaseMaterialSheetMetal.Enabled = True
      End Select

   End Sub


#Region "Drag and drop"

   Private Sub picMixingBox_MouseDown(ByVal s As Object, ByVal e As MouseEventArgs) _
   Handles picMixingBox.MouseDown, picAirBlender.MouseDown, picFilter.MouseDown, picPreFilterBag.MouseDown, _
   picHouseFan1.MouseDown, picHouseFan2.MouseDown, picPlenumFan.MouseDown, picHeatingCoil.MouseDown, _
   picCoolingCoil.MouseDown, picElectricHeater.MouseDown, picSpace1.MouseDown, picSpace2.MouseDown, _
   picSpace3.MouseDown, picDischarge1.MouseDown, picDischarge2.MouseDown, picSplit.MouseDown, picGasHeater.MouseDown
      Dim real As New PictureBox
      Dim fake As New PictureBox
      Dim i As Integer
      Dim xPosition As Integer = 0

      real = CType(s, PictureBox)

      'gets x position
      For i = 0 To Me.panDropSections.Controls.Count - 1
         xPosition += Me.panDropSections.Controls(i).Width
      Next

      '>> creates a copy of real picturebox
      '>> if the real picturebox is sent it is moved even if DragDropEffects is Copy
      With fake
         .Image = real.Image
         .Location = New Point(xPosition, 3)
         .Size = real.Size
         .SizeMode = real.SizeMode
         .Tag = real.Tag
      End With

      Try
         real.DoDragDrop(real.Tag, DragDropEffects.Copy)
      Catch Ex As Exception
         MessageBox.Show("Drag and drop failed.", "RAESolutions", _
            MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub panDropSections_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) _
   Handles panDropSections.DragEnter
      'TODO: 3 check type before dropping
      e.Effect = DragDropEffects.Copy
   End Sub


   '1. adds picture to panel
   '2. updates datagrid (section abbreviation and length)
   Private Sub panDropSections_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) _
   Handles panDropSections.DragDrop
      Dim abbreviation As String
      Dim eAbbreviation As sectionAbbreviation

      abbreviation = e.Data.GetData(GetType(String))
      eAbbreviation = Me.ConvertToEnum(abbreviation, GetType(sectionAbbreviation))

      'inserts row in dataset and drawing and shows controls for passed section type
      Me.InsertSection(eAbbreviation)

      'updates section details dataset's order indices
      Me.UpdateOrderIndices()
   End Sub


   'checks if the passed section can be added
   Private Function IsMaxNumSectionsContained(ByVal sectionEnum As sectionAbbreviation) As Boolean
      Dim numSections As Integer = Me.GetSectionQuantity(sectionEnum)
      Dim full As Boolean = False
      Dim totalNumSections As Integer

      Select Case sectionEnum
         Case sectionAbbreviation.MB1
            If numSections >= 2 Then full = True
         Case sectionAbbreviation.FF1, sectionAbbreviation.FF2
            totalNumSections = _
               Me.GetSectionQuantity(sectionAbbreviation.FF1) _
               + Me.GetSectionQuantity(sectionAbbreviation.FF2)
            If totalNumSections >= 3 Then full = True
         Case sectionAbbreviation.HF1, sectionAbbreviation.HF2, sectionAbbreviation.PF1
            totalNumSections = _
               Me.GetSectionQuantity(sectionAbbreviation.HF1) _
               + Me.GetSectionQuantity(sectionAbbreviation.HF2) _
               + Me.GetSectionQuantity(sectionAbbreviation.PF1)
            If totalNumSections >= 3 Then full = True
         Case sectionAbbreviation.C1, sectionAbbreviation.C2
            totalNumSections = _
               Me.GetSectionQuantity(sectionAbbreviation.C1) _
               + Me.GetSectionQuantity(sectionAbbreviation.C2)
            If totalNumSections >= 3 Then full = True
         Case sectionAbbreviation.C3
            If numSections >= 1 Then full = True
         Case sectionAbbreviation.D1, sectionAbbreviation.D2
            totalNumSections = _
               Me.GetSectionQuantity(sectionAbbreviation.D1) _
               + Me.GetSectionQuantity(sectionAbbreviation.D2)
            If totalNumSections >= 1 Then full = True
         Case Else
            'section doesn't have limit
      End Select

      Return full
   End Function


   Private Sub pic_MouseEnter(ByVal s As Object, ByVal e As EventArgs)
      Dim pic As New PictureBox

      pic = CType(s, PictureBox)

      pic.BackColor = Color.FromArgb(&HFFFFFF99)
   End Sub
   Private Sub pic_MouseLeave(ByVal s As Object, ByVal e As EventArgs)
      Dim pic As New PictureBox

      pic = CType(s, PictureBox)

      pic.BackColor = Color.White
   End Sub

   'selects section
   Private Sub pic_Click(ByVal sender As System.Object, ByVal e As EventArgs)
      Dim pic As New PictureBox
      Dim previousPic As New PictureBox
      Dim i As Integer

      pic = CType(sender, PictureBox)

      'if already selected, unselect
      If Me.selectedSectionDrawingOrderIndex = pic.Tag Then
         Me.selectedSectionDrawingOrderIndex = -1
         'removes border
         RemoveHandler pic.Paint, AddressOf pic_Paint
      Else
         'if not selected
         'unselects previous, if there is one
         If Me.selectedSectionDrawingOrderIndex > -1 Then
            'gets selected section drawing
            previousPic = Me.GetSectionDrawing(Me.selectedSectionDrawingOrderIndex)
            'removes border
            RemoveHandler previousPic.Paint, AddressOf pic_Paint
            'forces section to be re-painted
            previousPic.Refresh()
         End If
         'selects this as new
         Me.selectedSectionDrawingOrderIndex = pic.Tag
         'puts border on section to indicate its selected
         AddHandler pic.Paint, AddressOf pic_Paint
      End If

      'causes border to be drawn now, rather than waiting for its invalidation
      pic.Refresh()
      'testing
      Console.WriteLine(Me.selectedSectionDrawingOrderIndex.ToString)
   End Sub


   'draws border to indicate section is selected
   Private Sub pic_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
      Dim pic As New PictureBox

      pic = CType(sender, PictureBox)
      e.Graphics.DrawRectangle(New Pen(Color.Orange, 2), New Rectangle(1, 1, pic.Width - 2, pic.Height - 2))
   End Sub

#End Region


#Region "General"


   Private Function ConvertToEnum(ByVal item As String, ByVal enumType As Type) As Integer
      Dim i As Integer
      Dim eItem As Integer

      For i = 0 To [Enum].GetNames(enumType).GetLength(0) - 1
         If item = [Enum].GetName(enumType, i) Then
            eItem = i
            Exit For
         End If
      Next

      Return eItem
   End Function


   'don't allow users to enter text into combobox
   Private Sub cbo_KeyDown(ByVal sender As System.Object, ByVal e As KeyEventArgs) _
   Handles cbo_mixing_box.KeyDown, cbo_pre_ff.KeyDown, cbo_pre_sets.KeyDown, cbo_ff.KeyDown, cbo_ff_sets.KeyDown, cbo_hp.KeyDown, cbo_rpm.KeyDown, cbo_fan_type.KeyDown, cbo_fan_class.KeyDown, cbo_fan_size.KeyDown, cbo_fan_iso.KeyDown, cbo_drive_type.KeyDown, cbo_coil_type.KeyDown, cbo_rows.KeyDown, cbo_fins.KeyDown, cbo_fin_thickness.KeyDown, cbo_tube_thickness.KeyDown
      e.Handled = True
   End Sub


   Private Sub cbo_KeyPress(ByVal s As Object, ByVal e As KeyPressEventArgs) _
   Handles cbo_mixing_box.KeyPress, cbo_pre_ff.KeyPress, cbo_pre_sets.KeyPress, cbo_ff.KeyPress, cbo_ff_sets.KeyPress, cbo_hp.KeyPress, cbo_rpm.KeyPress, cbo_fan_type.KeyPress, cbo_fan_class.KeyPress, cbo_fan_size.KeyPress, cbo_fan_iso.KeyPress, cbo_drive_type.KeyPress, cbo_coil_type.KeyPress, cbo_rows.KeyPress, cbo_fins.KeyPress, cbo_fin_thickness.KeyPress, cbo_tube_thickness.KeyPress
      e.Handled = True
   End Sub


#End Region


#Region "Insert / Remove"

   'removes section
   Private Sub RemoveSection(ByVal orderIndex As Integer)
      'hides section's controls
      Me.RemoveSectionControls(orderIndex)

      'removes row in section dataset for passed orderIndex
      Me.RemoveSectionDatasetRow(orderIndex)

      'removes section drawing and adjust other drawings' properties appropriately
      Me.RemoveSectionDrawing(orderIndex)

      'deselects section
      Me.selectedSectionDrawingOrderIndex = -1
   End Sub

   'removes all _Section rows and all SectionDetails rows
   Private Sub RemoveAllSections()
      Dim i As Integer

      Try
         'deletes all sections in dataset/datagrid
         For i = Me.DseProject1._Section.Rows.Count - 1 To 0 Step -1
            Me.RemoveSection(i)
         Next
         Me.BindingContext(Me.DseProject1._Section).EndCurrentEdit()
         Me.dadSection.Update(Me.DseProject1._Section)
      Catch ex As Exception
         MessageBox.Show("Attempt to delete section datarows failed. " & ex.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

      'deletes SectionDetails row
      Try
         If Me.DseProject1.SectionDetails.Rows.Count > 0 Then
            Me.DseProject1.SectionDetails.Rows(0).Delete()
            Me.BindingContext(Me.DseProject1.SectionDetails).EndCurrentEdit()
            Me.dadSectionDetails.Update(Me.DseProject1.SectionDetails)
         End If
      Catch ex2 As Exception
         MessageBox.Show("Attempt to delete section details datarow failed. " & ex2.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   'removes row with matching order index
   Private Sub RemoveSectionDatasetRow(ByVal orderIndex As Integer)
      Dim i As Integer
      Dim iToDelete As Integer = -1
      Dim numRows As Integer

      Try

         'adjusts dataset (datagrid)
         '----------------------------
         'get array of datarows with rowstate that aren't deleted
         For i = 0 To Me.DseProject1._Section.Rows.Count - 1
            Try
               If Me.DseProject1._Section.Rows(i)(Me.DseProject1._Section.OrderIndexColumn) > orderIndex Then
                  'adjusts other sections indices
                  Me.DseProject1._Section.Rows(i)(Me.DseProject1._Section.OrderIndexColumn) -= 1
               ElseIf Me.DseProject1._Section.Rows(i)(Me.DseProject1._Section.OrderIndexColumn) = orderIndex Then
                  'marks index to delete
                  iToDelete = i
               End If
            Catch ex1 As Exception
               MessageBox.Show("Attempt to delete dataset row failed." & Environment.NewLine & _
                  "index = " & i.ToString & Environment.NewLine & "index to delete = " & iToDelete.ToString & Environment.NewLine & ex1.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
         Next

         'deletes _Section row
         '--------------------------
         Try
            'stores number of rows before deletion
            numRows = Me.DseProject1._Section.Rows.Count
            '>> removes section from dataset (datagrid)
            '>> wait til out of for loop to delete so that the 
            '   delete won't cause an OutOfRangeException
            '>> MS Documentation: If the RowState of the row is Added, the row will be removed from the table
            '   opposed to just setting RowState to Delete
            Me.DseProject1._Section.Rows(iToDelete).Delete()
            'if number of rows didn't update, perform update
            If numRows = Me.DseProject1._Section.Rows.Count Then
               Dim rows(0) As DataRow
               rows(0) = Me.DseProject1._Section.Rows(iToDelete)
               '>> updates single row, not the entire table
               '>> deletes single row permantly
               Me.dadSection.Update(rows)
               'MessageBox.Show("During dataset row deletion, row count was not updated.", "RAESolution", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
         Catch ex3 As Exception
            MessageBox.Show("Attempt to delete section datarow failed. " & ex3.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try

         'AcceptChanges() didn't update database
         'Me.DseProject1._Section.Rows(iToDelete).AcceptChanges()
      Catch ex As Exception
         MessageBox.Show("Attempt to delete dataset row failed." & Environment.NewLine & _
            Environment.NewLine & _
            ex.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   'removes section drawing and adjusts other drawings accordingly
   Private Sub RemoveSectionDrawing(ByVal orderIndex As Integer)
      Dim i As Integer
      Dim pic As New PictureBox

      'gets section drawing at specified order index
      pic = Me.GetSectionDrawing(orderIndex)

      'removes picturebox
      Me.panDropSections.Controls.Remove(pic)

      'adjusts section drawings (picturebox)
      For i = 0 To Me.panDropSections.Controls.Count - 1
         If orderIndex < Me.panDropSections.Controls(i).Tag Then
            'adjusts other section drawings indices in tag property
            Me.panDropSections.Controls(i).Tag -= 1
            'adjusts other section drawings location
            Me.panDropSections.Controls(i).Left -= pic.Width
         End If
      Next

      If Me.panDropSections.Controls.Count = 0 Then
         'shows instructions
         Me.lblDragInstructions.Visible = True
      End If
   End Sub

   'hides section's control at passed order index
   Private Sub RemoveSectionControls(ByVal orderIndex As Integer)
      Dim container As New Control
      Dim abbreviation As String
      Dim eAbbreviation As sectionAbbreviation

      'gets section abbreviation from dataset
      abbreviation = Me.DseProject1._Section.Rows(Me.GetSectionDatasetRowIndex(orderIndex))(Me.DseProject1._Section.AbbreviationColumn)
      eAbbreviation = Me.ConvertToEnum(abbreviation, GetType(sectionAbbreviation))

      Select Case eAbbreviation
         Case sectionAbbreviation.MB1
            Dim i As Integer

            'gets the container holding the section to be removed's controls
            container = Me.GetSectionControlsContainer(orderIndex)
            'hides control container
            container.Visible = False
            '>> removes the door that was added
            'user can set the # of doors so this calculation can be inaccurate
            If Me.NumDoors > 0 Then Me.NumDoors -= 1
            'adjusts all controls order indices
            Me.RemoveAllContainerOrderIndex(orderIndex)

         Case sectionAbbreviation.BLD1
            Dim blenderCost As Single
            Dim model As String
            Dim numBLDs As Integer

            '>> gets number of air blenders
            '>> (minus one because this is executed before dataset is actually modified)
            numBLDs = Me.GetSectionQuantity(sectionAbbreviation.BLD1) - 1
            'gets model
            model = Me.DseProject1.SavedAirHandler.Rows(Me.airHandlerIndex)(Me.DseProject1.SavedAirHandler.ModelNumberColumn)
            'calculates air blender cost
            blenderCost = Me.GetBlenderCost(model)

            'decrements # of doors and air seals
            If Me.NumDoors > 0 Then Me.NumDoors -= 1
            Me.NumAirSeals -= 1

            'decrements # of air blenders
            Me.lblBLD1Quantity.Text = CInt(Me.lblBLD1Quantity.Text) - 1

            'sets blender cost textbox
            Me.lbl_bld1_cost.Text = CStr(blenderCost * numBLDs)
            'shows blender cost if user is authorized
            Me.lbl_bld1_cost.Visible = Me.pricingAuthorized

            'adjust all controls order indices
            Me.RemoveAllContainerOrderIndex(orderIndex)

         Case sectionAbbreviation.FF1, sectionAbbreviation.FF2
            container = Me.GetSectionControlsContainer(orderIndex)
            container.Visible = False
            container.Text = "-1"
            Me.NumAirSeals -= 1
            Me.RemoveAllContainerOrderIndex(orderIndex)

         Case sectionAbbreviation.HF1, sectionAbbreviation.HF2, sectionAbbreviation.PF1
            container = Me.GetSectionControlsContainer(orderIndex)
            container.Visible = False
            container.Text = "-1"
            Me.NumAirSeals -= 1
            If Me.NumDoors > 0 Then Me.NumDoors -= 1
            Me.RemoveAllContainerOrderIndex(orderIndex)

         Case sectionAbbreviation.C1, sectionAbbreviation.C2
            container = Me.GetSectionControlsContainer(orderIndex)
            container.Visible = False
            container.Text = "-1"
            Me.NumAirSeals -= 1
            If Me.NumDoors > 0 Then Me.NumDoors -= 1
            Me.RemoveAllContainerOrderIndex(orderIndex)

         Case sectionAbbreviation.C3
            container = Me.GetSectionControlsContainer(orderIndex)
            container.Visible = False
            container.Text = "-1"
            Me.NumAirSeals -= 1
            If Me.NumDoors > 1 Then
               Me.NumDoors -= 2
            Else
               Me.NumDoors = 0
            End If
            Me.RemoveAllContainerOrderIndex(orderIndex)

         Case sectionAbbreviation.C5
            container = Me.GetSectionControlsContainer(orderIndex)
            container.Visible = False
            container.Text = "-1"
            Me.RemoveAllContainerOrderIndex(orderIndex)

         Case sectionAbbreviation.SS1
            Me.NumSS1s -= 1
            Me.RemoveAllContainerOrderIndex(orderIndex)
         Case sectionAbbreviation.SS2
            Me.NumSS2s -= 1
            Me.RemoveAllContainerOrderIndex(orderIndex)
         Case sectionAbbreviation.SS3
            Me.NumSS3s -= 1
            Me.RemoveAllContainerOrderIndex(orderIndex)

         Case sectionAbbreviation.D1
            Me.NumDoors -= 1
            Me.panDischargeContainer.Visible = False
            Me.panDischargeContainer.Text = -1
            Me.RemoveAllContainerOrderIndex(orderIndex)
         Case sectionAbbreviation.D2
            Me.RemoveAllContainerOrderIndex(orderIndex)

         Case sectionAbbreviation.US1
            Me.NumUS1s -= 1
            Me.RemoveAllContainerOrderIndex(orderIndex)

         Case Else
            MessageBox.Show("Attempt to remove section " & abbreviation & "'s controls failed. No match can be found for abbreviation.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Select

   End Sub

   '>> ignores indices less than orderIndex
   '>> decrements indices greater than orderIndex
   '>> defaults the index equal to orderIndex
   Private Sub RemoveContainerOrderIndex(ByVal container As Panel, ByVal orderIndex As Integer)
      If CInt(container.Text) > -1 Then
         If CInt(container.Text) > orderIndex Then
            container.Text = CInt(container.Text) - 1
         ElseIf CInt(container.Text) = orderIndex Then
            container.Text = "-1"
         End If
      End If
   End Sub

   Private Sub RemoveAllContainerOrderIndex(ByVal orderIndex As Integer)
      'adjusts containers' text which holds order index
      'UPDATE:
      Me.RemoveContainerOrderIndex(Me.panMB1Container, orderIndex)
      Me.RemoveContainerOrderIndex(Me.panMB2Container, orderIndex)
      Me.RemoveContainerOrderIndex(Me.panFF1Container, orderIndex)
      Me.RemoveContainerOrderIndex(Me.panFF2Container, orderIndex)
      Me.RemoveContainerOrderIndex(Me.panFF3Container, orderIndex)
      Me.RemoveContainerOrderIndex(Me.panFan1Container, orderIndex)
      Me.RemoveContainerOrderIndex(Me.panFan2Container, orderIndex)
      Me.RemoveContainerOrderIndex(Me.panFan3Container, orderIndex)
      Me.RemoveContainerOrderIndex(Me.panCoil1Container, orderIndex)
      Me.RemoveContainerOrderIndex(Me.panCoil2Container, orderIndex)
      Me.RemoveContainerOrderIndex(Me.panCoil3Container, orderIndex)
      Me.RemoveContainerOrderIndex(Me.panCoil4Container, orderIndex)
      Me.RemoveContainerOrderIndex(Me.panCoil5Container, orderIndex)
      Me.RemoveContainerOrderIndex(Me.panC3Container, orderIndex)
      Me.RemoveContainerOrderIndex(Me.panDischargeContainer, orderIndex)
      Me.RemoveContainerOrderIndex(Me.panGasHeaterContainer, orderIndex)

   End Sub



   'shows section controls, inserts dataset row, inserts drawing
   Private Function InsertSection(ByVal sectionEnum As sectionAbbreviation, Optional ByVal orderIndex As Integer = -1) As Boolean
      Dim succeeded As Boolean = True

      'checks if the section can be added
      If Me.IsMaxNumSectionsContained(sectionEnum) Then
         Dim message As String = "This air handler already contains the maximum number of " & _
            sectionEnum.ToString & " sections. This section can not be added."
         MessageBox.Show(message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         succeeded = False

      Else

         'inserts section drawing corresponding to section abbreviation
         Me.InsertSectionDrawing(sectionEnum)

         'inserts row into section dataset for passed section type
         Me.InsertSectionDatasetRow(sectionEnum)

         'shows controls for passed section type
         Me.InsertSectionControls(sectionEnum)
      End If

      Return succeeded
   End Function

   'TOD0: finish sub
   'shows controls for section
   Private Sub InsertSectionControls(ByVal sectionEnum As sectionAbbreviation, Optional ByVal orderIndex As Integer = -1)
      Dim container As New Control

      'UPDATE: Cases
      Select Case sectionEnum
         'MB1 = Mixing Box
         Case sectionAbbreviation.MB1
            Dim i, iCost, iCostLabel As Integer

            'increments number of doors
            Me.NumDoors += 1

            'checks if saved data exists
            If orderIndex > -1 Then
               If orderIndex = ConvertNull.ToInteger(Me.DseProject1.SectionDetails.Rows(0)(Me.DseProject1.SectionDetails.MB1OrderIndexColumn), -2) Then
                  container = Me.panMB1Container
               ElseIf orderIndex = ConvertNull.ToInteger(Me.DseProject1.SectionDetails.Rows(0)(Me.DseProject1.SectionDetails.MB2OrderIndexColumn), -2) Then
                  container = Me.panMB2Container
               End If
            Else
               '>> if no saved data
               '>> gets container based on unused container
               If Me.panMB1Container.Text = -1 Then
                  container = Me.panMB1Container
               ElseIf Me.panMB2Container.Text = -1 Then
                  container = Me.panMB2Container
               Else
                  MessageBox.Show("There is not an available control container for an additional mixing box.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
                  Exit Sub
               End If
            End If

            'shows controls
            container.Visible = True
            'sets text to order index
            If orderIndex > -1 Then
               container.Text = orderIndex
            Else
               'assumes drawing has already been added
               container.Text = Me.panDropSections.Controls.Count - 1
            End If

            'gets indices for labels that show cost
            For i = 0 To container.Controls.Count - 1
               If container.Controls(i).Name.StartsWith("_lbl_MB1_cost") Then
                  iCost = i
               ElseIf container.Controls(i).Name.EndsWith("CostLabel") Then
                  iCostLabel = i
               End If
            Next

            'shows mixing box cost if user is authorized
            container.Controls(iCost).Visible = Me.pricingAuthorized
            container.Controls(iCostLabel).Visible = Me.pricingAuthorized

            'BLD1 = Air Blender
         Case sectionAbbreviation.BLD1
            Dim model As String
            Dim numBLDs As Integer
            Dim blenderCost As Single

            'gets selected cabinet index
            model = Me.DseProject1.SavedAirHandler.Rows(Me.airHandlerIndex)(Me.DseProject1.SavedAirHandler.ModelNumberColumn)
            'gets number of BLD1 sections
            Me.lblBLD1Quantity.Text = Me.GetSectionQuantity(sectionAbbreviation.BLD1)
            'calculates blender cost
            blenderCost = GetBlenderCost(model)
            'gets number of air blenders
            numBLDs = Me.GetSectionQuantity(sectionAbbreviation.BLD1)

            'adds a door and an air seal
            Me.NumAirSeals += 1
            Me.NumDoors += 1

            'no special controls to show

            'sets blender cost textbox
            Me.lbl_bld1_cost.Text = Format(blenderCost * numBLDs, "c")
            'shows blender cost if user is authorized
            Me.lbl_bld1_cost.Visible = Me.pricingAuthorized

            '>> FF1 = Filter 2" or 4", FF2 = Filter 2" or 4" w/ bag filter up to 22"
            '>> 1. adds air seal, 2. sets container and control values
         Case sectionAbbreviation.FF1, sectionAbbreviation.FF2
            Dim i, iCost, iCostLabel As Integer
            Dim cboText, lblText As String
            Dim finalFilterVisible As Boolean

            'adds an air seal
            Me.NumAirSeals += 1

            'gets container based on unused container
            '----------------------------------------
            If orderIndex > -1 Then
               If orderIndex = ConvertNull.ToInteger(Me.DseProject1.SectionDetails.Rows(0)(Me.DseProject1.SectionDetails.Filt0OrderIndexColumn), -2) Then
                  container = Me.panFF1Container
               ElseIf orderIndex = ConvertNull.ToInteger(Me.DseProject1.SectionDetails.Rows(0)(Me.DseProject1.SectionDetails.Filt1OrderIndexColumn), -2) Then
                  container = Me.panFF2Container
               ElseIf orderIndex = ConvertNull.ToInteger(Me.DseProject1.SectionDetails.Rows(0)(Me.DseProject1.SectionDetails.Filt2OrderIndexColumn), -2) Then
                  container = Me.panFF3Container
               End If
               'if no saved data
            Else
               If Me.panFF1Container.Text = -1 Then
                  container = Me.panFF1Container
               ElseIf Me.panFF2Container.Text = -1 Then
                  container = Me.panFF2Container
               ElseIf Me.panFF3Container.Text = -1 Then
                  container = Me.panFF3Container
               Else
                  MessageBox.Show("There is not an available control container for an additional filter.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
                  Exit Sub
               End If
            End If

            'sets container's properties
            '---------------------------
            'shows container
            container.Visible = True
            'sets container's text to order index
            If orderIndex > -1 Then
               container.Text = orderIndex
            Else
               container.Text = Me.panDropSections.Controls.Count - 1
            End If

            'gets controls values
            '--------------------------
            If sectionEnum = sectionAbbreviation.FF2 Then
               cboText = "No pre-filter"
               lblText = "Pre-filter"
               finalFilterVisible = True
            ElseIf sectionEnum = sectionAbbreviation.FF1 Then
               cboText = "No filter"
               lblText = "Filter"
               finalFilterVisible = False
            End If

            'sets control values and visibility
            '-------------------------------------
            If container.Controls.Contains(Me.panFF1Prefilter) Then
               'sets first item in combobox
               Me._cbo_pre_ff_0.Items(0) = cboText
               'sets comboboxe's label
               Me.lblFF1Prefilter.Text = lblText
               'sets section's header
               Me._lbl_ff_0.Text = " Filter (" & sectionEnum.ToString & ")"
               'sets visibility for final filter section
               Me.panFF1FinalFilter.Visible = finalFilterVisible
               'sets visiblity of cost
               Me.lblFF1CostLabel.Visible = Me.pricingAuthorized
               Me._lbl_ff_cost_0.Visible = Me.pricingAuthorized
            ElseIf container.Controls.Contains(Me.panFF2Prefilter) Then
               Me._cbo_pre_ff_1.Items(0) = cboText
               Me.lblFF2Prefilter.Text = lblText
               Me._lbl_ff_1.Text = " Filter (" & sectionEnum.ToString & ")"
               Me.panFF2FinalFilter.Visible = finalFilterVisible
               Me.lblFF2CostLabel.Visible = Me.pricingAuthorized
               Me._lbl_ff_cost_1.Visible = Me.pricingAuthorized
            ElseIf container.Controls.Contains(Me.panFF3PreFilter) Then
               Me._cbo_pre_ff_2.Items(0) = cboText
               Me.lblFF3Prefilter.Text = lblText
               Me._lbl_ff_2.Text = " Filter (" & sectionEnum.ToString & ")"
               Me.panFF3FinalFilter.Visible = finalFilterVisible
               Me.lblFF3CostLabel.Visible = Me.pricingAuthorized
               Me._lbl_ff_cost_2.Visible = Me.pricingAuthorized
            End If

         Case sectionAbbreviation.HF1, sectionAbbreviation.HF2, sectionAbbreviation.PF1
            Dim fanIndex As Integer

            'gets container based on unused container
            '----------------------------------------
            If orderIndex > -1 Then
               If orderIndex = ConvertNull.ToInteger(Me.DseProject1.SectionDetails.Rows(0)(Me.DseProject1.SectionDetails.Fan0OrderIndexColumn), -2) Then
                  container = Me.panFan1Container
               ElseIf orderIndex = ConvertNull.ToInteger(Me.DseProject1.SectionDetails.Rows(0)(Me.DseProject1.SectionDetails.Fan1OrderIndexColumn), -2) Then
                  container = Me.panFan2Container
               ElseIf orderIndex = ConvertNull.ToInteger(Me.DseProject1.SectionDetails.Rows(0)(Me.DseProject1.SectionDetails.Fan2OrderIndexColumn), -2) Then
                  container = Me.panFan3Container
               End If
            Else
               'if no saved data
               If Me.panFan1Container.Text = -1 Then
                  container = Me.panFan1Container
               ElseIf Me.panFan2Container.Text = -1 Then
                  container = Me.panFan2Container
               ElseIf Me.panFan3Container.Text = -1 Then
                  container = Me.panFan3Container
               Else
                  MessageBox.Show("There is not an available control container for an additional fan.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
                  Exit Sub
               End If
            End If

            'sets container's text to order index
            If orderIndex > -1 Then
               container.Text = orderIndex
            Else
               container.Text = Me.panDropSections.Controls.Count - 1
            End If

            If container.Contains(Me.panFan1Fan) Then
               'shows controls
               Me.panFan1Container.Visible = True
               'shows fan related costs (to authorized users)
               Me.lblFanCostLabel1.Visible = Me.pricingAuthorized
               Me._lbl_fan_cost_0.Visible = Me.pricingAuthorized
               Me.lblMotorCostLabel1.Visible = Me.pricingAuthorized
               Me._lbl_motor_cost_0.Visible = Me.pricingAuthorized
               Me.lblIsolatorCostLabel1.Visible = Me.pricingAuthorized
               Me._lbl_iso_cost_0.Visible = Me.pricingAuthorized
               'sets header
               Me._lbl_fan_type_0.Text = " Fan (" & sectionEnum.ToString & ")"
               'sets fan index which index which container is being filled
               fanIndex = 0
            ElseIf container.Contains(Me.panFan2Fan) Then
               Me.panFan2Container.Visible = True
               Me.lblFanCostLabel2.Visible = Me.pricingAuthorized
               Me._lbl_fan_cost_1.Visible = Me.pricingAuthorized
               Me.lblMotorCostLabel2.Visible = Me.pricingAuthorized
               Me._lbl_motor_cost_1.Visible = Me.pricingAuthorized
               Me.lblIsolatorCostLabel2.Visible = Me.pricingAuthorized
               Me._lbl_iso_cost_1.Visible = Me.pricingAuthorized
               Me._lbl_fan_type_1.Text = " Fan (" & sectionEnum.ToString & ")"
               fanIndex = 1
            ElseIf container.Contains(Me.panFan3Fan) Then
               Me.panFan3Container.Visible = True
               Me.lblFanCostLabel3.Visible = Me.pricingAuthorized
               Me._lbl_fan_cost_2.Visible = Me.pricingAuthorized
               Me.lblMotorCostLabel3.Visible = Me.pricingAuthorized
               Me._lbl_motor_cost_2.Visible = Me.pricingAuthorized
               Me.lblIsolatorCostLabel3.Visible = Me.pricingAuthorized
               Me._lbl_iso_cost_2.Visible = Me.pricingAuthorized
               Me._lbl_fan_type_2.Text = " Fan (" & sectionEnum.ToString & ")"
               fanIndex = 2
            End If

            '4. fills fan related comboboxes

            '>> fills fan type combobox options whose SelectedIndexChanged
            '   event fills fan size
            If sectionEnum.ToString = "HF1" Or sectionEnum.ToString = "HF2" Then
               Me.cbo_fan_type(fanIndex).Items.Clear()
               Me.cbo_fan_type(fanIndex).Items.Add("DWDI BI")
               Me.cbo_fan_type(fanIndex).Items.Add("DWDI FC")
            ElseIf sectionEnum.ToString = "PF1" Then
               Me.cbo_fan_type(fanIndex).Items.Clear()
               Me.cbo_fan_type(fanIndex).Items.Add("SWSI Airfoil")
            End If

            'fills fan class options
            If sectionEnum.ToString = "HF1" Or sectionEnum.ToString = "HF2" Then
               Me.cbo_fan_class(fanIndex).Items.Clear()
               Me.cbo_fan_class(fanIndex).Items.Add("None")
            ElseIf sectionEnum.ToString = "PF1" Then
               Me.cbo_fan_class(fanIndex).Items.Clear()
               Me.cbo_fan_class(fanIndex).Items.Add("Class I")
               Me.cbo_fan_class(fanIndex).Items.Add("Class II")
               Me.cbo_fan_class(fanIndex).Items.Add("Class III")
            End If

            'TODO: Should fan drive be readonly; there are no options
            'fills drive type combobox
            Me.cbo_drive_type(fanIndex).Items.Clear()
            Me.cbo_drive_type(fanIndex).Items.Add("Belt Drive")

            'fills fan isolator
            Me.cbo_fan_iso(fanIndex).Items.Clear()
            Me.cbo_fan_iso(fanIndex).Items.Add("None")
            Me.cbo_fan_iso(fanIndex).Items.Add("1in. Open")
            Me.cbo_fan_iso(fanIndex).Items.Add("2in. Open")
            Me.cbo_fan_iso(fanIndex).Items.Add("1in. Seismic")
            Me.cbo_fan_iso(fanIndex).Items.Add("2in. Seismic")
            Me.cbo_fan_iso(fanIndex).Items.Add("Rubber")

            Me.NumAirSeals += 1
            Me.NumDoors += 1

         Case sectionAbbreviation.C1, sectionAbbreviation.C2
            Dim coilIndex As Integer

            'gets container
            '----------------------------------------
            If orderIndex > -1 Then
               If orderIndex = ConvertNull.ToInteger(Me.DseProject1.SectionDetails.Rows(0)(Me.DseProject1.SectionDetails.Coil0OrderIndexColumn), -2) Then
                  container = Me.panCoil1Container
               ElseIf orderIndex = ConvertNull.ToInteger(Me.DseProject1.SectionDetails.Rows(0)(Me.DseProject1.SectionDetails.Coil1OrderIndexColumn), -2) Then
                  container = Me.panCoil2Container
               ElseIf orderIndex = ConvertNull.ToInteger(Me.DseProject1.SectionDetails.Rows(0)(Me.DseProject1.SectionDetails.Coil2OrderIndexColumn), -2) Then
                  container = Me.panCoil3Container
               ElseIf orderIndex = ConvertNull.ToInteger(Me.DseProject1.SectionDetails.Rows(0)(Me.DseProject1.SectionDetails.Coil3OrderIndexColumn), -2) Then
                  container = Me.panCoil4Container
                  'ElseIf orderIndex = ConvertNull.ToInteger(Me.DseProject1.SectionDetails.Rows(0)(Me.DseProject1.SectionDetails.Coil4OrderIndexColumn), -2) Then
                  '   container = Me.panCoil5Container
               End If
            Else
               'if no saved data
               If Me.panCoil1Container.Text = -1 Then
                  container = Me.panCoil1Container
               ElseIf Me.panCoil2Container.Text = -1 Then
                  container = Me.panCoil2Container
               ElseIf Me.panCoil3Container.Text = -1 Then
                  container = Me.panCoil3Container
               ElseIf Me.panCoil4Container.Text = -1 Then
                  container = Me.panCoil4Container
                  'ElseIf Me.panCoil5Container.Text = -1 Then
                  '   container = Me.panCoil5Container
               Else
                  MessageBox.Show("There is not an available control container for an additional coil.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
                  Exit Sub
               End If
            End If

            Me.NumAirSeals += 1
            Me.NumDoors += 1

            'sets container's text to order index
            If orderIndex > -1 Then
               container.Text = orderIndex
            Else
               container.Text = Me.panDropSections.Controls.Count - 1
            End If

            container.Visible = True

            If container.Contains(Me.panCoil1) Then
               coilIndex = 0
            ElseIf container.Contains(Me.panCoil2) Then
               coilIndex = 1
            ElseIf container.Contains(Me.panCoil3) Then
               coilIndex = 2
            ElseIf container.Contains(Me.panCoil4) Then
               coilIndex = 3
            ElseIf container.Contains(Me.panCoil5) Then
               coilIndex = 4
            End If

            Me.lbl_coil_cost(coilIndex).Visible = Me.pricingAuthorized

            Me.lbl_coil_type(coilIndex).Text = sectionEnum.ToString
            cbo_coil_type(coilIndex).Items.Clear()
            cbo_coil_type(coilIndex).Text = "Coil Type"

            If sectionEnum.ToString = "C1" Then
               '// Load the coil types
               cbo_coil_type(coilIndex).Items.Add("Hot Water")
               cbo_coil_type(coilIndex).Items.Add("Std. Steam")

               '// Load the rows available
               cbo_rows(coilIndex).Items.Clear()
               cbo_rows(coilIndex).Items.Add(CStr(1))
               cbo_rows(coilIndex).Items.Add(CStr(2))

            ElseIf sectionEnum.ToString = "C2" Then
               '// Load the coil types
               cbo_coil_type(coilIndex).Items.Add("Chilled Water")
               cbo_coil_type(coilIndex).Items.Add("DX")

               '// Load the rows available
               Me.cbo_rows(coilIndex).Items.Clear()
               Me.cbo_rows(coilIndex).Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "10", "12"})
            End If

            Me.cbo_fins(coilIndex).Items.Clear()
            Me.cbo_fins(coilIndex).Items.AddRange(New Object() {"4", "6", "8", "10", "12", "14"})

            Me.cbo_fin_thickness(coilIndex).Items.Clear()
            Me.cbo_fin_thickness(coilIndex).Items.AddRange(New Object() {0.006, 0.008, 0.01})

            Me.cbo_tube_thickness(coilIndex).Items.Clear()
            Me.cbo_tube_thickness(coilIndex).Items.AddRange(New Object() {"0.02", "0.025", "0.035", "0.049"})

         Case sectionAbbreviation.C3
            'gets container
            If Me.panC3Container.Text <> -1 Then
               MessageBox.Show("There is not an available control container for an additional C3 coil.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
               Exit Sub
            End If

            Me.panC3Container.Visible = True
            'sets container's text to order index
            If orderIndex > -1 Then
               Me.panC3Container.Text = orderIndex
            Else
               Me.panC3Container.Text = Me.panDropSections.Controls.Count - 1
            End If

            'shows cost if authorized
            Me.lbl_heater_cost.Visible = Me.pricingAuthorized

            Me.NumAirSeals += 1
            Me.NumDoors += 2

         Case sectionAbbreviation.C5
            If Me.panGasHeaterContainer.Text <> -1 Then
               MessageBox.Show("There is not an available control container for an addition C5 coil.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
               Exit Sub
            End If

            Me.panGasHeaterContainer.Visible = True
            If orderIndex > -1 Then
               Me.panGasHeaterContainer.Text = orderIndex
            Else
               Me.panGasHeaterContainer.Text = Me.panDropSections.Controls.Count - 1
            End If

            Me.lblGasHeaterCost.Visible = Me.pricingAuthorized

            ' TODO: air seals and doors for C5?

         Case sectionAbbreviation.SS1
            Me.NumSS1s += 1
         Case sectionAbbreviation.SS2
            Me.NumSS2s += 1
         Case sectionAbbreviation.SS3
            Me.NumSS3s += 1

         Case sectionAbbreviation.D1
            Try
               If Me.panDischargeContainer.Text <> -1 Then
                  MessageBox.Show("There is not an available control container for an additional discharge D1.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
                  Exit Sub
               End If
               'sets container's text to order index
               If orderIndex > -1 Then
                  Me.panDischargeContainer.Text = orderIndex
               Else
                  Me.panDischargeContainer.Text = Me.panDropSections.Controls.Count - 1
               End If
               Me.panDischargeContainer.Visible = True
               Me.lblGratingCost.Visible = Me.pricingAuthorized
               Me.lbl_D1_grating_cost.Visible = Me.pricingAuthorized
               Me.NumDoors += 1
            Catch ex As Exception
               MessageBox.Show("Attempt to insert section controls failed. " & ex.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

         Case sectionAbbreviation.US1
            Me.NumUS1s += 1

         Case Else
            'no controls need to be set for this section
      End Select

   End Sub

   'inserts row into section dataset for passed section type
   Private Sub InsertSectionDatasetRow(ByVal sectionEnum As sectionAbbreviation, Optional ByVal orderIndex As Integer = -1)
      Dim model As String
      Dim length As Single = 0
      Dim abbreviation As String
      Dim dimensionsTable As ReferenceData.SectionDimensionsDataTable

      abbreviation = sectionEnum.ToString

      ' gets section length
      '
      If abbreviation = "SS1" Then
         length = 12
      ElseIf abbreviation = "SS2" Then
         length = 24
      ElseIf abbreviation = "SS3" Then
         length = 36
      Else
         model = Me.DseProject1.SavedAirHandler(Me.airHandlerIndex).ModelNumber
         dimensionsTable = DataAgent.RetrieveDimensions(model)
         length = dimensionsTable(0)(abbreviation)
      End If

      ' adds new row to datagrid/dataset
      '
      Dim r As dseProject._SectionRow

      r = DseProject1._Section.New_SectionRow

      r.Abbreviation = abbreviation
      r.SectionLength = length
      r.AirHandlerID = Me.AirHandlerID

      If orderIndex > -1 Then
         r.OrderIndex = orderIndex
      Else
         r.OrderIndex = Me.panDropSections.Controls.Count - 1
      End If

      Me.DseProject1._Section.Rows.Add(r)
   End Sub

   'not finished doesn't allow user to insert at a certain index yet
   Private Sub InsertSectionDrawing(ByVal section As sectionAbbreviation, Optional ByVal orderIndex As Integer = -1)
      Dim realPic As New PictureBox
      Dim copyPic As New PictureBox
      Dim i As Integer
      Dim xPosition As Integer = 0
      Const yPosition As Integer = 5

      'hides instructions so that they don't cover drawings
      Me.lblDragInstructions.Visible = False

      'gets xposition, will change if inserting at particular index
      For i = 0 To Me.panDropSections.Controls.Count - 1
         xPosition += Me.panDropSections.Controls(i).Width
      Next

      'copy picturebox
      For i = 0 To Me.panDragSections.Controls.Count - 1
         If Me.panDragSections.Controls(i).Tag = section.ToString Then
            realPic = Me.panDragSections.Controls(i)
            With copyPic
               If orderIndex < 0 Then
                  'adds pic to end of drawing
                  .Tag = Me.panDropSections.Controls.Count
                  .Location = New Point(xPosition, yPosition)
               Else
                  'inserts pic at specific index
                  .Tag = orderIndex
                  'TODO: calculate location
               End If
               .SizeMode = realPic.SizeMode
               .Size = realPic.Size
               .Image = realPic.Image
            End With
            'sets Tooltip
            Me.ToolTip1.SetToolTip(copyPic, Me.ToolTip1.GetToolTip(realPic))
         End If
      Next

      'adds mouse events that causes pic backcolor to change
      AddHandler copyPic.MouseEnter, AddressOf pic_MouseEnter
      AddHandler copyPic.MouseLeave, AddressOf pic_MouseLeave
      'adds event that selects section on click
      AddHandler copyPic.Click, AddressOf pic_Click

      'adds picture to drag panel
      Me.panDropSections.Controls.Add(copyPic)
   End Sub


#End Region



   'gets the number of sections with the same abbreviation
   Private Function GetSectionQuantity(ByVal sectionEnum As sectionAbbreviation)
      Dim abbreviation As String = sectionEnum.ToString
      Dim filter As String = "Abbreviation = '" & abbreviation & "'"
      Dim dr() As DataRow = Me.DseProject1._Section.Select(filter)

      Return dr.Length
   End Function


   'UPDATE: finish function
   'returns container for section's order index
   Private Function GetSectionControlsContainer(ByVal orderIndex As Integer) As Control
      Dim container As New Control

      Select Case orderIndex.ToString
         Case Me.panMB1Container.Text
            container = Me.panMB1Container
         Case Me.panMB2Container.Text
            container = Me.panMB2Container
         Case Me.panFF1Container.Text
            container = Me.panFF1Container
         Case Me.panFF2Container.Text
            container = Me.panFF2Container
         Case Me.panFF3Container.Text
            container = Me.panFF3Container
         Case Me.panFan1Container.Text
            container = Me.panFan1Container
         Case Me.panFan2Container.Text
            container = Me.panFan2Container
         Case Me.panFan3Container.Text
            container = Me.panFan3Container
         Case Me.panCoil1Container.Text
            container = Me.panCoil1Container
         Case Me.panCoil2Container.Text
            container = Me.panCoil2Container
         Case Me.panCoil3Container.Text
            container = Me.panCoil3Container
         Case Me.panCoil4Container.Text
            container = Me.panCoil4Container
         Case Me.panCoil5Container.Text
            container = Me.panCoil5Container
         Case Me.panC3Container.Text
            container = Me.panC3Container
         Case Me.panDischargeContainer.Text
            container = Me.panDischargeContainer
         Case Me.panGasHeaterContainer.Text
            container = Me.panGasHeaterContainer
         Case Else
            MessageBox.Show("Attempt to find related controls for order index, " & orderIndex.ToString & " failed.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Select

      Return container
   End Function

   'returns section drawing at specified order index
   Private Function GetSectionDrawing(ByVal orderIndex As Integer) As PictureBox
      Dim i As Integer
      Dim pic As New PictureBox

      For i = 0 To panDropSections.Controls.Count - 1
         If Me.panDropSections.Controls(i).Tag = orderIndex Then
            'sets previously selected section
            pic = DirectCast(Me.panDropSections.Controls(i), PictureBox)
            Exit For
         End If
      Next

      Return pic
   End Function

   Private Function GetSectionDatasetRowIndex(ByVal orderIndex As Integer) As Integer
      Dim i As Integer

      For i = 0 To Me.DseProject1._Section.Rows.Count - 1
         If Me.DseProject1._Section.Rows(i)(Me.DseProject1._Section.OrderIndexColumn) = orderIndex Then
            Exit For
         End If
         If i = Me.DseProject1._Section.Rows.Count - 1 Then
            MessageBox.Show("A 'Section' dataset row with a matching order index, " & orderIndex.ToString & ", cannot be found.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End If
      Next

      Return i
   End Function

    ''Private Sub btnPrintDrawing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintDrawing.Click
    ''   Dim doc As New C1.C1PrintDocument.C1PrintDocument
    ''   'controls font and other styles on printed page
    ''   Dim printStyle As New C1.C1PrintDocument.C1DocStyle(doc)  'used in rendering spacer image
    ''   Dim whiteImage As Image  'image is used to fill unused space at the end of a page
    ''   Dim alignCenter As New C1.C1PrintDocument.ImageAlignDef

    ''   Me.Cursor = Cursors.WaitCursor

    ''   Try
    ''      alignCenter.AlignHorz = C1.C1PrintDocument.ImageAlignHorzEnum.Center
    ''      alignCenter.KeepAspectRatio = True
    ''      'blank vertical space
    ''      whiteImage = Image.FromFile(AppInfo.AppFolderPath & "Images\whitebox.gif")
    ''      'font format
    ''      printStyle.Font = New Font("Arial", 10, FontStyle.Regular)
    ''      'the page settings from frmC1PrintPreview.vb are not applied
    ''      'page settings must be set in code in order to be applied
    ''      'margins
    ''      doc.PageSettings.Margins.Top = 50 'in hundredths of an inch
    ''      doc.PageSettings.Margins.Bottom = 50
    ''      doc.PageSettings.Margins.Left = 80
    ''      doc.PageSettings.Margins.Right = 80
    ''      'units
    ''      doc.DefaultUnit = C1.C1PrintDocument.UnitTypeEnum.Mm
    ''      'header
    ''      doc.PageHeader.Height = 8
    ''      doc.PageHeader.RenderText.Style = printStyle
    ''      doc.PageHeader.RenderText.Style.TextAlignHorz = C1.C1PrintDocument.AlignHorzEnum.Center
    ''      doc.PageHeader.RenderText.Style.TextAlignVert = C1.C1PrintDocument.AlignVertEnum.Top
    ''      doc.PageHeader.RenderText.Text = "Air Handler Drawing"
    ''      'footer
    ''      doc.PageFooter.Height = 8
    ''      doc.PageFooter.RenderText.Style = printStyle
    ''      doc.PageFooter.RenderText.Style.TextAlignHorz = C1.C1PrintDocument.AlignHorzEnum.Right
    ''      doc.PageFooter.RenderText.Style.TextAlignVert = C1.C1PrintDocument.AlignVertEnum.Bottom
    ''      doc.PageFooter.RenderText.Text = "Page [@@PageNo@@] of [@@PageCount@@]"

    ''      doc.StartDoc() 'start rendering
    ''      'space
    ''      doc.RenderBlockImage(whiteImage, 3, 5, printStyle)
    ''      'info
    ''      doc.RenderBlockText("Project: " & Me.DseProject1.SavedProject.Rows(0)(Me.DseProject1.SavedProject.ProjectNameColumn), printStyle)
    ''      doc.RenderBlockText("Quote Number: " & Me.DseProject1.SavedProject.Rows(0)(Me.DseProject1.SavedProject.QuoteNumberColumn), printStyle)
    ''      doc.RenderBlockText("Tag: " & Me.lblTag.Text, printStyle)
    ''      'space
    ''      doc.RenderBlockImage(whiteImage, 3, 20, printStyle)
    ''      '>> air handler drawing
    ''      '>> image expands proportional until a dimension is exceed
    ''      '>> center doesn't center in page rather centers in the width parameter
    ''      '   so width parameter is set to width of page (trial and error)
    ''      doc.RenderBlockControlImage(Me.panDropSections, 220, 35, True, alignCenter)
    ''      'space
    ''      doc.RenderBlockImage(whiteImage, 3, 20, printStyle)
    ''      'section info table
    ''      doc.RenderBlockControlImage(Me.dgrC1SectionInfo, 220, 18, printStyle)
    ''      'stops rendering
    ''      doc.EndDoc()
    ''   Catch Ex As Exception
    ''      MessageBox.Show("Attempt to render drawing for printing failed. Printer may not be compatible." & _
    ''         Environment.NewLine & Environment.NewLine & Ex.Message, "RAESolutions", _
    ''         MessageBoxButtons.OK, MessageBoxIcon.Error)
    ''      Exit Sub
    ''   End Try

    ''   Try
    ''      Dim formPreview As New C1PrintPreviewForm 'create instance form to preview before printing
    ''      formPreview.C1PrintPreview1.Document = doc 'set the form's document to the document just created
    ''      formPreview.ShowDialog() 'can't have mdiparent otherwise error occurs
    ''      formPreview.Dispose()
    ''   Catch Ex As Exception
    ''      MessageBox.Show("Attempt to preview drawing failed. " & Ex.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
    ''   End Try

    ''   Me.Cursor = Cursors.Arrow
    ''End Sub

    Private Function GetFanEfficiency(ByVal index As Integer) As String
      Dim efficiency As String

      'default
      efficiency = ""

      If Me.ck_high(index).Checked Then
         efficiency = "High"
      ElseIf Me.ck_premium(index).Checked Then
         efficiency = "Premium"
      End If

      Return efficiency
   End Function

   Private Function GetFanEnclosure(ByVal index As Integer) As String
      Dim enclosure As String

      'default
      enclosure = ""

      If Me.ck_odp(index).Checked Then
         enclosure = "ODP"
      ElseIf Me.ck_tefc(index).Checked Then
         enclosure = "TEFC"
      End If

      Return enclosure
   End Function

   Private Function GetMixingBoxMetal(ByVal index As Integer) As String
      Dim metal As String

      If Me.ck_MB1_al(index).Checked Then
         metal = "Aluminum"
      ElseIf Me.ck_MB1_gal(index).Checked Then
         metal = "Galvanized"
      Else
         metal = ""
      End If

      Return metal
   End Function


   Friend Shared Function RetrieveTotalHours(ByVal id As Integer) As Double
      Dim connection As OleDbConnection
      Dim command As OleDbCommand
      Dim connectionString, sql As String
      Dim totalHours As Double

      connectionString = DataAccess.Common.GetConnectionString(RAE.RAESolutions.DataAccess.Common.AirHandlerProjectsDbPath)
      connection = New OleDbConnection(connectionString)

      sql = "SELECT [Double1] FROM [SavedAirHandler] WHERE [AirHandlerId]=" & id.ToString
      command = New OleDbCommand(sql, connection)

      Try
         connection.Open()
         totalHours = CNull.ToDouble(command.ExecuteScalar())
      Catch ex As OleDbException
         Throw ex
      Finally
         If connection.State <> ConnectionState.Closed Then connection.Close()
      End Try

      Return totalHours
   End Function


   Private Sub SaveTotalHours(ByVal id As Integer, ByVal totalHours As Double)
      Dim connection As OleDbConnection
      Dim command As OleDbCommand
      Dim connectionString, sql As String

      connectionString = DataAccess.Common.GetConnectionString(DataAccess.Common.AirHandlerProjectsDbPath)
      connection = New OleDbConnection(connectionString)

      sql = "UPDATE [SavedAirHandler] SET [Double1]=" & totalHours.ToString & " WHERE [AirHandlerId]=" & id.ToString()
      command = New OleDbCommand(sql, connection)

      Try
         connection.Open()
         command.ExecuteNonQuery()
      Catch ex As OleDbException
         Throw ex
      Finally
         If connection.State <> ConnectionState.Closed Then connection.Close()
      End Try
   End Sub


   Private Function calculatePriceWithLabor(ByVal listPrice As Double, ByVal laborHours As Double) As Double
      Dim laborCost As Double = laborHours * Consts.HOURLY_WAGE
      Dim price As Double = listPrice + laborCost

      Return price
   End Function


   Private Sub updateMotorControls(ByVal index As Integer)
      Dim motorTable As ReferenceData.MotorsDataTable
      motorTable = Me.RetrieveMotor(Me.GetFanEfficiency(index), Me.GetFanEnclosure(index), _
         Me.cbo_hp(index).SelectedItem, Me.cbo_rpm(index).SelectedItem)

      Dim motorCost As Double = Me.calculatePriceWithLabor(motorTable(0).ListCost, motorTable(0).LaborHours)

      Me.lbl_motor_cost(index).Text = motorCost.ToString("c")
      Me.lbl_motor_weight(index).Text = motorTable(0).ShipWeight.ToString
   End Sub


#Region " Natural gas heater"

   Private Sub radC5TypeTwoStage_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
   Handles radC5TypeTwoStage.CheckedChanged
      If Me.radC5TypeTwoStage.Checked Then
         Me.lblC5TypeValue.Text = "TwoStage"
         Me.updateGasHeaterCost()
      End If
   End Sub

   Private Sub radC5TypeModulating_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
   Handles radC5TypeModulating.CheckedChanged
      If Me.radC5TypeModulating.Checked Then
         Me.lblC5TypeValue.Text = "Modulating"
         Me.updateGasHeaterCost()
      End If
   End Sub

   Private Sub lblC5TypeValue_TextChanged(ByVal sender As Object, ByVal e As EventArgs) _
   Handles lblC5TypeValue.TextChanged
      If lblC5TypeValue.Text = "TwoStage" Then
         Me.radC5TypeTwoStage.Checked = True
      ElseIf lblC5TypeValue.Text = "Modulating" Then
         Me.radC5TypeModulating.Checked = True
      End If
   End Sub

   Private Sub cboC5Power_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
   Handles cboC5Power.SelectedIndexChanged
      Me.updateGasHeaterCost()
   End Sub


   Private Function grabGasHeaterPower() As Double
      Dim power As Double
      If Me.cboC5Power.SelectedIndex <= -1 Then
         If Me.cboC5Power.Items.Count > 0 Then
            Me.cboC5Power.SelectedIndex = 0
         Else
            Return 0
         End If
      End If

      power = CDbl(Me.cboC5Power.SelectedItem.ToString())

      Return power
   End Function

   Private Function grabGasHeaterType() As String
      Dim type As String
      If Me.radC5TypeModulating.Checked Then
         type = "Modulating"
      Else
         type = "TwoStage"
      End If
      Return type
   End Function


   ''' <summary>
   ''' Determines if MCB-1 board is required. Returns true if required; else false.
   ''' </summary>
   ''' <param name="power">
   ''' Power in MBH
   ''' </param>
   ''' <param name="type">
   ''' Heater type
   ''' </param>
   Private Function checkIfBoardIsRequired(ByVal power As Double, ByVal type As String) As Boolean
      Dim isBoardRequired As Boolean

      If power > 400 _
      OrElse type = "Modulating" Then
         isBoardRequired = True
      Else
         isBoardRequired = False
      End If

      Return isBoardRequired
   End Function

   ''' <summary>
   ''' Calculates cost of natural gas heater section.
   ''' </summary>
   Private Function calculateGasHeaterCost(ByVal type As String, ByVal power As Double, ByVal isBoardRequired As Boolean) As Double
      Dim cost As Double

      Dim modulatingHeaterCost, twoStageHeaterCost, laborHours As Double
      Me.retrieveNaturalGasHeaterInfo(power, _
         twoStageHeaterCost, modulatingHeaterCost, laborHours)

      cost += laborHours * Consts.HOURLY_WAGE

      If type = "Modulating" Then
         cost += modulatingHeaterCost
      ElseIf type = "TwoStage" Then
         cost += twoStageHeaterCost
      Else
         Throw New System.ArgumentException("The natural gas heater air handler section cost cannot be calculated. The type is invalid.")
      End If

      ' TODO: add labor hours to gas heater cost

      If isBoardRequired Then
         cost += 837.2
      End If

      Return cost
   End Function


   ''' <summary>
   ''' Updates cost property.
   ''' </summary>
   Private Sub updateCostGasHeaterCost(ByVal type As String, ByVal power As Double, ByVal isBoardRequired As Boolean)
      Dim cost As Double = Me.calculateGasHeaterCost(type, power, isBoardRequired)
      Me.lblGasHeaterCost.Text = cost.ToString("c")
   End Sub

   Private Sub retrieveNaturalGasHeaterInfo(ByVal power As Double, _
   ByRef twoStageHeaterCost As Double, ByRef modulatingHeaterCost As Double, ByRef laborHours As Double)
      Dim connectionString As String = DataAccess.Common.GetConnectionString(DataAccess.Common.AirHandlerDbPath)
      Dim sql As String = "SELECT * FROM [GasHeaters] WHERE [Power]=" & power.ToString()
      Dim connection As New OleDbConnection(connectionString)
      Dim command As New OleDbCommand(sql, connection)
      Dim reader As OleDbDataReader

      Try
         connection.Open()
         reader = command.ExecuteReader()
         While reader.Read()
            twoStageHeaterCost = CDbl(reader("TwoStageHeaterCost")) / 2.8
            modulatingHeaterCost = CDbl(reader("ModulatingHeaterCost")) / 2.8
            laborHours = CDbl(reader("LaborHours"))
         End While
      Catch ex As Exception
         Throw
      Finally
         If reader IsNot Nothing Then reader.Close()
         If connection.State <> ConnectionState.Closed Then connection.Close()
      End Try

   End Sub

   Private Sub populateC5Powers(ByVal airHandlerModel As String)
      Dim maxPower As Double = Me.getMaxPower(airHandlerModel)
      Dim powers As New List(Of Double)()
      powers.AddRange(New Double() {200, 250, 300, 350, 400, 800, 1200, 1600})
      Dim filteredPowers As New List(Of Double)()

      Me.cboC5Power.Items.Clear()
      For Each power As Double In powers
         If power <= maxPower Then
            filteredPowers.Add(power)
            Me.cboC5Power.Items.Add(power)
         End If
      Next
   End Sub

   ''' <summary>
   ''' Gets the max power of the heater based on the air handler model.
   ''' </summary>
   ''' <param name="airHandlerModel">
   ''' Air handler model this section is in.
   ''' </param>
   Private Function getMaxPower(ByVal airHandlerModel As String) As Integer
      Dim maxPower As Integer

      Dim modelNumber As Integer = ParseModelNum(airHandlerModel)

      If modelNumber <= 22 Then
         maxPower = 400
      Else
         maxPower = 1600
      End If

      Return maxPower
   End Function

   ''' <summary>
   ''' Parses and returns just the number portion of the model number (ex. TPAH-22 > 22).
   ''' </summary>
   ''' <param name="model">
   ''' Air handler model should be in the format TPAH-##.
   ''' </param>
   Public Shared Function ParseModelNum(ByVal model As String) As Integer
      Dim modelNumberString As String = model.Replace("TPAH-", "")
      Dim modelNumber As Integer = CInt(modelNumberString)
      Return modelNumber
   End Function

   Private Sub updateGasHeaterCost()
      Me.updateCostGasHeaterCost(Me.grabGasHeaterType(), Me.grabGasHeaterPower(), Me.checkIfBoardIsRequired(Me.grabGasHeaterPower, Me.grabGasHeaterType))
   End Sub

#End Region


End Class
' 13194