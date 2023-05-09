Imports EvapChillerProcessDA = Rae.RaeSolutions.DataAccess.Projects.EvaporativeCondenerChillerBalanceDa
Imports System.Reflection

Namespace Rae.RaeSolutions.Business.Entities

Public Class EvaporativeCondenserChillerBalance : Inherits ProcessItem
   
   Private Equipment As EquipmentItemList

#Region " Properties"

   Public Enum eApproachRange
      SixToEight
      SevenToNine
      EightToTen
      NineToEleven
      TenToTwelve
      Other
   End Enum

   Public Enum eCapacityType
      Tons
      GPM
   End Enum

   Private m_ModelDesc As String
   Property ModelDesc() As String
      Get
         Return Me.m_ModelDesc
      End Get
      Set(value As String)
         Me.m_ModelDesc = value
      End Set
   End Property

   Private m_NewCoefficients As Boolean
   Property NewCoefficients() As Boolean
      Get
         Return Me.m_NewCoefficients
      End Get
      Set(value As Boolean)
         Me.m_NewCoefficients = value
      End Set
   End Property

   Private m_Fluid As String
   Property Fluid() As String
      Get
         Return Me.m_Fluid
      End Get
      Set(value As String)
         Me.m_Fluid = value
      End Set
   End Property

   Private m_GlycolPercentage As Double
   Property GlycolPercentage() As Double
      Get
         Return Me.m_GlycolPercentage
      End Get
      Set(value As Double)
         Me.m_GlycolPercentage = value
      End Set
   End Property

   Private m_CoolingMedia As String
   Property CoolingMedia() As String
      Get
         Return Me.m_CoolingMedia
      End Get
      Set(value As String)
         Me.m_CoolingMedia = value
      End Set
   End Property

   Private m_SpecificHeat As Double
   Property SpecificHeat() As Double
      Get
         Return Me.m_SpecificHeat
      End Get
      Set(value As Double)
         Me.m_SpecificHeat = value
      End Set
   End Property

   Private m_SpecificGravity As Double
   Property SpecificGravity() As Double
      Get
         Return Me.m_SpecificGravity
      End Get
      Set(value As Double)
         Me.m_SpecificGravity = value
      End Set
   End Property

   Private m_SubCooling As Double
   Property SubCooling() As Double
      Get
         Return Me.m_SubCooling
      End Get
      Set(value As Double)
         Me.m_SubCooling = value
      End Set
   End Property

   Private m_Refrigerant As String
   Property Refrigerant() As String
      Get
         Return Me.m_Refrigerant
      End Get
      Set(value As String)
         Me.m_Refrigerant = value
      End Set
   End Property

   Private m_TempRange As Double
   Property TempRange() As Double
      Get
         Return Me.m_TempRange
      End Get
      Set(value As Double)
         Me.m_TempRange = value
      End Set
   End Property

   Private m_AmbientTemp As Double
   Property AmbientTemp() As Double
      Get
         Return Me.m_AmbientTemp
      End Get
      Set(value As Double)
         Me.m_AmbientTemp = value
      End Set
   End Property

   Private m_LeavingFluidTemp As Double
   Property LeavingFluidTemp() As Double
      Get
         Return Me.m_LeavingFluidTemp
      End Get
      Set(value As Double)
         Me.m_LeavingFluidTemp = value
      End Set
   End Property

   Private m_System As String
   Property System As String
      Get
         Return Me.m_System
      End Get
      Set(value As String)
         Me.m_System = value
      End Set
   End Property

   Private m_Hertz As Double
   Property Hertz As Double
      Get
         Return Me.m_Hertz
      End Get
      Set(value As Double)
         Me.m_Hertz = value
      End Set
   End Property

   Private m_Volts As Double
   Property Volts As Double
      Get
         Return Me.m_Volts
      End Get
      Set(value As Double)
         Me.m_Volts = value
      End Set
   End Property

   Private m_Approach As String
   Property Approach As String
      Get
         Return Me.m_Approach
      End Get
      Set(value As String)
         Me.m_Approach = value
      End Set
   End Property

   Private m_SafetyOverride As Boolean
   Property SafetyOverride As Boolean
      Get
         Return Me.m_SafetyOverride
      End Get
      Set(value As Boolean)
         Me.m_SafetyOverride = value
      End Set
   End Property

   Private m_Circuit1 As Boolean
   Property Circuit1 As Boolean
      Get
         Return Me.m_Circuit1
      End Get
      Set(value As Boolean)
         Me.m_Circuit1 = value
      End Set
   End Property

   Private m_Circuit2 As Boolean
   Property Circuit2 As Boolean
      Get
         Return Me.m_Circuit2
      End Get
      Set(value As Boolean)
         Me.m_Circuit2 = value
      End Set
   End Property

   Private m_NumCompressors1 As Double
   Property NumCompressors1 As Double
      Get
         Return Me.m_NumCompressors1
      End Get
      Set(value As Double)
         Me.m_NumCompressors1 = value
      End Set
   End Property

   Private m_NumCompressors2 As Double
   Property NumCompressors2 As Double
      Get
         Return Me.m_NumCompressors2
      End Get
      Set(value As Double)
         Me.m_NumCompressors2 = value
      End Set
   End Property

   Private m_Compressors1 As String
   Property Compressors1 As String
      Get
         Return Me.m_Compressors1
      End Get
      Set(value As String)
         Me.m_Compressors1 = value
      End Set
   End Property

   Private m_Compressors2 As String
   Property Compressors2 As String
      Get
         Return Me.m_Compressors2
      End Get
      Set(value As String)
         Me.m_Compressors2 = value
      End Set
   End Property
   
   property compressor_file_name_1 as string
      get
         return _compressor_file_name_1
      end get
      set(value as string)
         _compressor_file_name_1 = value
      end set
   end property
   private _compressor_file_name_1 as string
   
   property compressor_file_name_2 as string
      get
         return _compressor_file_name_2
      end get
      set(value as string)
         _compressor_file_name_2 = value
      end set
   end property
   private _compressor_file_name_2 as string

   Private m_NumCoils1 As Double
   Property NumCoils1 As Double
      Get
         Return Me.m_NumCoils1
      End Get
      Set(value As Double)
         Me.m_NumCoils1 = value
      End Set
   End Property

   Private m_NumCoils2 As Double
   Property NumCoils2 As Double
      Get
         Return Me.m_NumCoils2
      End Get
      Set(value As Double)
         Me.m_NumCoils2 = value
      End Set
   End Property

   Private m_Condenser1 As String
   Property Condenser1 As String
      Get
         Return Me.m_Condenser1
      End Get
      Set(value As String)
         Me.m_Condenser1 = value
      End Set
   End Property
   
   property custom_condenser_model as string
      get
         return _custom_condenser_model
      end get
      set(value as string)
         _custom_condenser_model = value
      end set
   end property
   private _custom_condenser_model as string
   
   property fan_motor_hp as double
      get
         return _fan_motor_hp
      end get
      set(value as double)
         _fan_motor_hp = value
      end set
   end property
   private _fan_motor_hp as double
   
   property pump_motor_hp as double
      get
         return _pump_motor_hp
      end get
      set(value as double)
         _pump_motor_hp = value
      end set
   end property
   private _pump_motor_hp as double

   Private m_Condenser2 As String
   Property Condenser2 As String
      Get
         Return Me.m_Condenser2
      End Get
      Set(value As String)
         Me.m_Condenser2 = value
      End Set
   End Property

   Private m_DischargeLineLoss As Double
   Property DischargeLineLoss As Double
      Get
         Return Me.m_DischargeLineLoss
      End Get
      Set(value As Double)
         Me.m_DischargeLineLoss = value
      End Set
   End Property

   Private m_SuctionLineLoss As Double
   Property SuctionLineLoss As Double
      Get
         Return Me.m_SuctionLineLoss
      End Get
      Set(value As Double)
         Me.m_SuctionLineLoss = value
      End Set
   End Property

   Private m_Altitude As Double
   Property Altitude As Double
      Get
         Return Me.m_Altitude
      End Get
      Set(value As Double)
         Me.m_Altitude = value
      End Set
   End Property

   Private m_PumpWatts As Double
   Property PumpWatts As Double
      Get
         Return Me.m_PumpWatts
      End Get
      Set(value As Double)
         Me.m_PumpWatts = value
      End Set
   End Property

   Private m_FanWatts As Double
   Property FanWatts As Double
      Get
         Return Me.m_FanWatts
      End Get
      Set(value As Double)
         Me.m_FanWatts = value
      End Set
   End Property

   Private m_CondenserCapacity1 As Double
   Property CondenserCapacity1 As Double
      Get
         Return Me.m_CondenserCapacity1
      End Get
      Set(value As Double)
         Me.m_CondenserCapacity1 = value
      End Set
   End Property

   Private m_CondenserCapacity2 As Double
   Property CondenserCapacity2 As Double
      Get
         Return Me.m_CondenserCapacity2
      End Get
      Set(value As Double)
         Me.m_CondenserCapacity2 = value
      End Set
   End Property

   Private m_EvaporatorModel As String
   Property EvaporatorModel As String
      Get
         Return Me.m_EvaporatorModel
      End Get
      Set(value As String)
         Me.m_EvaporatorModel = value
      End Set
   End Property

   Private m_EvaporatorModelDesc As String
   Property EvaporatorModelDesc As String
      Get
         Return Me.m_EvaporatorModelDesc
      End Get
      Set(value As String)
         Me.m_EvaporatorModelDesc = value
      End Set
   End Property

   Private m_NumEvap As Double
   Property NumEvap As Double
      Get
         Return Me.m_NumEvap
      End Get
      Set(value As Double)
         Me.m_NumEvap = value
      End Set
   End Property

   Private m_FoulingFactor As Double
   Property FoulingFactor As Double
      Get
         Return Me.m_FoulingFactor
      End Get
      Set(value As Double)
         Me.m_FoulingFactor = value
      End Set
   End Property

   Private m_CapacityType As eCapacityType
   Property CapacityType As eCapacityType
      Get
         Return Me.m_CapacityType
      End Get
      Set(value As eCapacityType)
         Me.m_CapacityType = value
      End Set
   End Property

   Private m_EvaporatorCapacity As Double
   Property EvaporatorCapacity As Double
      Get
         Return Me.m_EvaporatorCapacity
      End Get
      Set(value As Double)
         Me.m_EvaporatorCapacity = value
      End Set
   End Property

   Private m_CatalogRating As Boolean
   Property CatalogRating As Boolean
      Get
         Return Me.m_CatalogRating
      End Get
      Set(value As Boolean)
         Me.m_CatalogRating = value
      End Set
   End Property

   Private m_ApproachRange As eApproachRange
   Property ApproachRange As eApproachRange
      Get
         Return Me.m_ApproachRange
      End Get
      Set(value As eApproachRange)
         Me.m_ApproachRange = value
      End Set
   End Property

   Private m_Evap8Degr1 As Double
   Property Evap8Degr1 As Double
      Get
         Return Me.m_Evap8Degr1
      End Get
      Set(value As Double)
         Me.m_Evap8Degr1 = value
      End Set
   End Property

   Private m_Evap8Degr2 As Double
   Property Evap8Degr2 As Double
      Get
         Return Me.m_Evap8Degr2
      End Get
      Set(value As Double)
         Me.m_Evap8Degr2 = value
      End Set
   End Property

   Private m_Evap10Degr1 As Double
   Property Evap10Degr1 As Double
      Get
         Return Me.m_Evap10Degr1
      End Get
      Set(value As Double)
         Me.m_Evap10Degr1 = value
      End Set
   End Property

   Private m_Evap10Degr2 As Double
   Property Evap10Degr2 As Double
      Get
         Return Me.m_Evap10Degr2
      End Get
      Set(value As Double)
         Me.m_Evap10Degr2 = value
      End Set
   End Property

   Private m_TEMin As Double
   Property TEMin As Double
      Get
         Return Me.m_TEMin
      End Get
      Set(value As Double)
         Me.m_TEMin = value
      End Set
   End Property

   Private m_TEMax As Double
   Property TEMax As Double
      Get
         Return Me.m_TEMax
      End Get
      Set(value As Double)
         Me.m_TEMax = value
      End Set
   End Property

   Private m_TEIncrement As Double
   Property TEIncrement As Double
      Get
         Return Me.m_TEIncrement
      End Get
      Set(value As Double)
         Me.m_TEIncrement = value
      End Set
   End Property

   Private m_ATMin As Double
   Property ATMin As Double
      Get
         Return Me.m_ATMin
      End Get
      Set(value As Double)
         Me.m_ATMin = value
      End Set
   End Property

   Private m_ATMax As Double
   Property ATMax As Double
      Get
         Return Me.m_ATMax
      End Get
      Set(value As Double)
         Me.m_ATMax = value
      End Set
   End Property

   Private m_ATIncrement As Double
   Property ATIncrement As Double
      Get
         Return Me.m_ATIncrement
      End Get
      Set(value As Double)
         Me.m_ATIncrement = value
      End Set
   End Property

   property CapacityAtDesignConditions as double
      set(value as double)
         _capacity_at_design_conditions = value
      end set
      get
         return _capacity_at_design_conditions
      end get
   end property
   private _capacity_at_design_conditions as double
   
   property EvaporatorPressureDropAtDesignConditions as double
      set(value as double)
         _pd_at_design_conditions = value
      end set
      get
         return _pd_at_design_conditions
      end get
   end property
   private _pd_at_design_conditions as double
   
   property FlowAtDesignConditions as double
      set(value as double)
         _flow_at_design_conditions = value
      end set
      get
         return _flow_at_design_conditions
      end get
   end property
   private _flow_at_design_conditions as double
   
   property subcooling_coil_option_selected as boolean
      get
         return _subcooling_coil_option_selected
      end get
      set(value as boolean)
         _subcooling_coil_option_selected = value
      end set
   end property
   private _subcooling_coil_option_selected as boolean
   
   property sound_attenuation_option_selected as boolean
      get
         return _sound_attenuation_option_selected
      end get
      set(value as boolean)
         _sound_attenuation_option_selected = value
      end set
   end property
   private _sound_attenuation_option_selected as boolean
   
   property unit_kw_per_ton_at_design_conditions as double
      get
         return _unit_efficiency_at_design_conditions
      end get
      set(value as double)
         _unit_efficiency_at_design_conditions = value
      end set
   end property
   private _unit_efficiency_at_design_conditions as double
   
#End Region


#Region " Public methods"

   ''' <summary>
   ''' Constructs a evap chiller process that already exists in the data source based on the ID.
   ''' Automatically loads the process from the data source.
   ''' </summary>
   ''' <param name="id">ID of the evap chiller process to load.</param>
   Sub New(id As item_id)
      Me.initialize()
      Me.id = id
   End Sub

   ''' <summary>
   ''' Constructs a evap chiller process that already exists in the data source based on the ID.
   ''' Automatically loads the process from the data source.
   ''' </summary>
   ''' <param name="id">ID of the evap chiller process to load.</param>
   ''' <param name="RevNumber">Revision number of the evap chiller process to load.</param>
   Public Sub New(id As item_id, RevNumber As Integer)
      Me.initialize()
      Me.id = id
      Me.Revision = RevNumber
   End Sub

   ''' <summary>
   ''' Constructs a new evap chiller process with the specified name.
   ''' Generates a new ID.
   ''' </summary>
   ''' <param name="name">Name of the process.</param>
   ''' <param name="createdBy">Username of the person who created the process.</param>
   ''' <param name="password">Password of the person who created the process.</param>
   ''' <param name="parent">Parent project manager that process should be included in.</param>
   Public Sub New(name As String, createdBy As String, password As String, parent As project_manager)
      Me.initialize()
      Me.name = name
      Me.id = New item_id(createdBy, password)
      Me.ProjectManager = parent
   End Sub

   ''' <summary>
   ''' Constructs a new evap chiller process with the specified name.
   ''' Used when making a clone.
   ''' </summary>
   Sub New(name As String, id As item_id)
      Me.initialize()
      Me.name = name
      Me.id = id
   End Sub

   Sub New(chillerEquip As chiller_equipment)
      Me.New(chillerEquip.name, chillerEquip.id.Username, chillerEquip.id.Password, chillerEquip.ProjectManager)
      Me.initialize()

      Static equipFlag As Boolean = False

      ' sets common properties
      Me.Series = chillerEquip.series
      Me.Model = Me.Series + chillerEquip.model_without_series

      Me.AmbientTemp = chillerEquip.Specs.AmbientTemp.value
      Me.Refrigerant = chillerEquip.Specs.Refrigerant
      Me.LeavingFluidTemp = chillerEquip.Specs.LeavingFluidTemp.value
      Me.GlycolPercentage = chillerEquip.Specs.GlycolPercent.value
      Me.Altitude = chillerEquip.common_specs.Altitude.value

      'prevent null ref
      If equipFlag = False Then
         Me.Equipment = New EquipmentItemList
         equipFlag = True
      End If

      ' associate equipment w/ process
      Me.Equipment.Add(chillerEquip)

      'write out the data table?
      Rae.RaeSolutions.DataAccess.Projects.ProcessEquipDA.Create(Me.id.ToString, chillerEquip.id.ToString)
   End Sub


   ''' <summary>
   ''' Loads evap chiller process based on ID.
   ''' ID must be set before calling this method.
   ''' (Optionally revision can be set to pull specific revision.)
   ''' </summary>
   Overrides Sub Load()
      Dim process As EvaporativeCondenserChillerBalance
      If Me.Revision > -1 Then
         process = EvapChillerProcessDA.Retrieve(Me.id, Me.Revision)
      Else
         process = EvapChillerProcessDA.Retrieve(Me.id)
      End If
      Me.Copy(process)
   End Sub

#End Region
   
   Protected Overrides Sub initialize()
      MyBase.initialize()
   End Sub

End Class
End Namespace