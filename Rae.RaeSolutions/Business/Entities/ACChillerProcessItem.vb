Imports ACChillerProcessDA = Rae.RaeSolutions.DataAccess.Projects.ACChillerProcessDA
Imports System.Reflection

Namespace Rae.RaeSolutions.Business.Entities

   ''' <summary>
   ''' ACChiller process.
   ''' </summary>
   ''' <history start="2006/08/06" by="JOSHH">
   ''' Created
   ''' </history>
   Public Class ACChillerProcessItem
      Inherits ProcessItem

      Private Equipment As EquipmentItemList

      Public EvaporatorPressureDropAtDesignConditions, CapacityAtDesignConditions, FlowAtDesignConditions As Double

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
      ''' <summary>
      ''' Model Description
      ''' </summary>
      Public Property ModelDesc() As String
         Get
            Return Me.m_ModelDesc
         End Get
         Set(ByVal value As String)
            Me.m_ModelDesc = value
         End Set
      End Property

      Private m_NewCoefficients As Boolean
      ''' <summary>
      ''' NewCoefficients
      ''' </summary>
      Public Property NewCoefficients() As Boolean
         Get
            Return Me.m_NewCoefficients
         End Get
         Set(ByVal value As Boolean)
            Me.m_NewCoefficients = value
         End Set
      End Property

      Private m_Fluid As String
      ''' <summary>
      ''' Fluid
      ''' </summary>
      Public Property Fluid() As String
         Get
            Return Me.m_Fluid
         End Get
         Set(ByVal value As String)
            Me.m_Fluid = value
         End Set
      End Property

      Private m_GlycolPercentage As Double
      ''' <summary>
      ''' GlycolPercentage
      ''' </summary>
      Public Property GlycolPercentage() As Double
         Get
            Return Me.m_GlycolPercentage
         End Get
         Set(ByVal value As Double)
            Me.m_GlycolPercentage = value
         End Set
      End Property

      Private m_CoolingMedia As String
      ''' <summary>
      ''' CoolingMedia
      ''' </summary>
      Public Property CoolingMedia() As String
         Get
            Return Me.m_CoolingMedia
         End Get
         Set(ByVal value As String)
            Me.m_CoolingMedia = value
         End Set
      End Property

      Private m_SpecificHeat As Double
      ''' <summary>
      ''' SpecificHeat
      ''' </summary>
      Public Property SpecificHeat() As Double
         Get
            Return Me.m_SpecificHeat
         End Get
         Set(ByVal value As Double)
            Me.m_SpecificHeat = value
         End Set
      End Property

      Private m_SpecificGravity As Double
      ''' <summary>
      ''' SpecificGravity
      ''' </summary>
      Public Property SpecificGravity() As Double
         Get
            Return Me.m_SpecificGravity
         End Get
         Set(ByVal value As Double)
            Me.m_SpecificGravity = value
         End Set
      End Property

      Private m_SubCooling As Double
      ''' <summary>
      ''' SubCooling
      ''' </summary>
      Public Property SubCooling() As Double
         Get
            Return Me.m_SubCooling
         End Get
         Set(ByVal value As Double)
            Me.m_SubCooling = value
         End Set
      End Property

      Private m_Refrigerant As String
      ''' <summary>
      ''' Refrigrant
      ''' </summary>
      Public Property Refrigerant() As String
         Get
            Return Me.m_Refrigerant
         End Get
         Set(ByVal value As String)
            Me.m_Refrigerant = value
         End Set
      End Property

      Private m_TempRange As Double
      ''' <summary>
      ''' TempRange
      ''' </summary>
      Public Property TempRange() As Double
         Get
            Return Me.m_TempRange
         End Get
         Set(ByVal value As Double)
            Me.m_TempRange = value
         End Set
      End Property

      Private m_AmbientTemp As Double
      ''' <summary>
      ''' AmbientTemp
      ''' </summary>
      Public Property AmbientTemp() As Double
         Get
            Return Me.m_AmbientTemp
         End Get
         Set(ByVal value As Double)
            Me.m_AmbientTemp = value
         End Set
      End Property

      Private m_LeavingFluidTemp As Double
      ''' <summary>
      ''' LeavingFluidTemp
      ''' </summary>
      Public Property LeavingFluidTemp() As Double
         Get
            Return Me.m_LeavingFluidTemp
         End Get
         Set(ByVal value As Double)
            Me.m_LeavingFluidTemp = value
         End Set
      End Property

      Private m_System As String
      ''' <summary>
      ''' System
      ''' </summary>
      Public Property System() As String
         Get
            Return Me.m_System
         End Get
         Set(ByVal value As String)
            Me.m_System = value
         End Set
      End Property

      Private m_Hertz As Double
      ''' <summary>
      ''' Hertz
      ''' </summary>
      Public Property Hertz() As Double
         Get
            Return Me.m_Hertz
         End Get
         Set(ByVal value As Double)
            Me.m_Hertz = value
         End Set
      End Property

      Private m_Volts As Double
      ''' <summary>
      ''' Volts
      ''' </summary>
      Public Property Volts() As Double
         Get
            Return Me.m_Volts
         End Get
         Set(ByVal value As Double)
            Me.m_Volts = value
         End Set
      End Property

      Private m_Approach As String
      ''' <summary>
      ''' Approach
      ''' </summary>
      Public Property Approach() As String
         Get
            Return Me.m_Approach
         End Get
         Set(ByVal value As String)
            Me.m_Approach = value
         End Set
      End Property

      Private m_SafetyOverride As Boolean
      ''' <summary>
      ''' SafetyOverride
      ''' </summary>
      Public Property SafetyOverride() As Boolean
         Get
            Return Me.m_SafetyOverride
         End Get
         Set(ByVal value As Boolean)
            Me.m_SafetyOverride = value
         End Set
      End Property

      Private m_Circuit1 As Boolean
      ''' <summary>
      ''' Circuit1
      ''' </summary>
      Public Property Circuit1() As Boolean
         Get
            Return Me.m_Circuit1
         End Get
         Set(ByVal value As Boolean)
            Me.m_Circuit1 = value
         End Set
      End Property

      Private m_Circuit2 As Boolean
      ''' <summary>
      ''' Circuit2
      ''' </summary>
      Public Property Circuit2() As Boolean
         Get
            Return Me.m_Circuit2
         End Get
         Set(ByVal value As Boolean)
            Me.m_Circuit2 = value
         End Set
      End Property

      Private m_NumCompressors1 As Double
      ''' <summary>
      ''' NumCompressors1
      ''' </summary>
      Public Property NumCompressors1() As Double
         Get
            Return Me.m_NumCompressors1
         End Get
         Set(ByVal value As Double)
            Me.m_NumCompressors1 = value
         End Set
      End Property

      Private m_NumCompressors2 As Double
      ''' <summary>
      ''' NumCompressors2
      ''' </summary>
      Public Property NumCompressors2() As Double
         Get
            Return Me.m_NumCompressors2
         End Get
         Set(ByVal value As Double)
            Me.m_NumCompressors2 = value
         End Set
      End Property

      Private m_Compressors1 As String
      ''' <summary>
      ''' Compressors1
      ''' </summary>
      Public Property Compressors1() As String
         Get
            Return Me.m_Compressors1
         End Get
         Set(ByVal value As String)
            Me.m_Compressors1 = value
         End Set
      End Property

      Private m_Compressors2 As String
      ''' <summary>
      ''' Compressors2
      ''' </summary>
      Public Property Compressors2() As String
         Get
            Return Me.m_Compressors2
         End Get
         Set(ByVal value As String)
            Me.m_Compressors2 = value
         End Set
      End Property

      Private m_NumCoils1 As Double
      ''' <summary>
      ''' NumCoils1
      ''' </summary>
      Public Property NumCoils1() As Double
         Get
            Return Me.m_NumCoils1
         End Get
         Set(ByVal value As Double)
            Me.m_NumCoils1 = value
         End Set
      End Property

      Private m_NumCoils2 As Double
      ''' <summary>
      ''' NumCoils2
      ''' </summary>
      Public Property NumCoils2() As Double
         Get
            Return Me.m_NumCoils2
         End Get
         Set(ByVal value As Double)
            Me.m_NumCoils2 = value
         End Set
      End Property

      Private m_Condenser1 As String
      ''' <summary>
      ''' Condenser1
      ''' </summary>
      Public Property Condenser1() As String
         Get
            Return Me.m_Condenser1
         End Get
         Set(ByVal value As String)
            Me.m_Condenser1 = value
         End Set
      End Property

      Private m_Condenser2 As String
      ''' <summary>
      ''' Condenser2
      ''' </summary>
      Public Property Condenser2() As String
         Get
            Return Me.m_Condenser2
         End Get
         Set(ByVal value As String)
            Me.m_Condenser2 = value
         End Set
      End Property

      Private m_FinsPerInch1 As Double
      ''' <summary>
      ''' FinsPerInch1
      ''' </summary>
      Public Property FinsPerInch1() As Double
         Get
            Return Me.m_FinsPerInch1
         End Get
         Set(ByVal value As Double)
            Me.m_FinsPerInch1 = value
         End Set
      End Property

      Private m_FinsPerInch2 As Double
      ''' <summary>
      ''' FinsPerInch2
      ''' </summary>
      Public Property FinsPerInch2() As Double
         Get
            Return Me.m_FinsPerInch2
         End Get
         Set(ByVal value As Double)
            Me.m_FinsPerInch2 = value
         End Set
      End Property

      Private m_SubCooling1 As Boolean
      ''' <summary>
      ''' SubCooling1
      ''' </summary>
      Public Property SubCooling1() As Boolean
         Get
            Return Me.m_SubCooling1
         End Get
         Set(ByVal value As Boolean)
            Me.m_SubCooling1 = value
         End Set
      End Property

      Private m_SubCooling2 As Boolean
      ''' <summary>
      ''' SubCooling2
      ''' </summary>
      Public Property SubCooling2() As Boolean
         Get
            Return Me.m_SubCooling2
         End Get
         Set(ByVal value As Boolean)
            Me.m_SubCooling2 = value
         End Set
      End Property

      Private m_SubCoolingPercent1 As Double
      ''' <summary>
      ''' SubCoolingPercent1
      ''' </summary>
      Public Property SubCoolingPercent1() As Double
         Get
            Return Me.m_SubCoolingPercent1
         End Get
         Set(ByVal value As Double)
            Me.m_SubCoolingPercent1 = value
         End Set
      End Property

      Private m_SubCoolingPercent2 As Double
      ''' <summary>
      ''' SubCoolingPercent2
      ''' </summary>
      Public Property SubCoolingPercent2() As Double
         Get
            Return Me.m_SubCoolingPercent2
         End Get
         Set(ByVal value As Double)
            Me.m_SubCoolingPercent2 = value
         End Set
      End Property

      Private m_CondenserTD1 As Double
      ''' <summary>
      ''' CondenserTD1
      ''' </summary>
      Public Property CondenserTD1() As Double
         Get
            Return Me.m_CondenserTD1
         End Get
         Set(ByVal value As Double)
            Me.m_CondenserTD1 = value
         End Set
      End Property

      Private m_CondenserTD2 As Double
      ''' <summary>
      ''' CondenserTD2
      ''' </summary>
      Public Property CondenserTD2() As Double
         Get
            Return Me.m_CondenserTD2
         End Get
         Set(ByVal value As Double)
            Me.m_CondenserTD2 = value
         End Set
      End Property

      Private m_FinHeight1 As Double
      ''' <summary>
      ''' FinHeight1
      ''' </summary>
      Public Property FinHeight1() As Double
         Get
            Return Me.m_FinHeight1
         End Get
         Set(ByVal value As Double)
            Me.m_FinHeight1 = value
         End Set
      End Property

      Private m_FinHeight2 As Double
      ''' <summary>
      ''' FinHeight2
      ''' </summary>
      Public Property FinHeight2() As Double
         Get
            Return Me.m_FinHeight2
         End Get
         Set(ByVal value As Double)
            Me.m_FinHeight2 = value
         End Set
      End Property

      Private m_FinLength1 As Double
      ''' <summary>
      ''' FinLength1
      ''' </summary>
      Public Property FinLength1() As Double
         Get
            Return Me.m_FinLength1
         End Get
         Set(ByVal value As Double)
            Me.m_FinLength1 = value
         End Set
      End Property

      Private m_FinLength2 As Double
      ''' <summary>
      ''' FinLength2
      ''' </summary>
      Public Property FinLength2() As Double
         Get
            Return Me.m_FinLength2
         End Get
         Set(ByVal value As Double)
            Me.m_FinLength2 = value
         End Set
      End Property

      Private m_Fan As String
      ''' <summary>
      ''' Fan
      ''' </summary>
      Public Property Fan() As String
         Get
            Return Me.m_Fan
         End Get
         Set(ByVal value As String)
            Me.m_Fan = value
         End Set
      End Property

      Private m_NumFans1 As Double
      ''' <summary>
      ''' NumFans1
      ''' </summary>
      Public Property NumFans1() As Double
         Get
            Return Me.m_NumFans1
         End Get
         Set(ByVal value As Double)
            Me.m_NumFans1 = value
         End Set
      End Property

      Private m_NumFans2 As Double
      ''' <summary>
      ''' NumFans2
      ''' </summary>
      Public Property NumFans2() As Double
         Get
            Return Me.m_NumFans2
         End Get
         Set(ByVal value As Double)
            Me.m_NumFans2 = value
         End Set
      End Property

      Private m_CfmOverride As Double
      ''' <summary>
      ''' CfmOverride
      ''' </summary>
      Public Property CfmOverride() As Double
         Get
            Return Me.m_CfmOverride
         End Get
         Set(ByVal value As Double)
            Me.m_CfmOverride = value
         End Set
      End Property


      Private m_DischargeLineLoss As Double
      ''' <summary>
      ''' DischargeLineLoss
      ''' </summary>
      Public Property DischargeLineLoss() As Double
         Get
            Return Me.m_DischargeLineLoss
         End Get
         Set(ByVal value As Double)
            Me.m_DischargeLineLoss = value
         End Set
      End Property

      Private m_SuctionLineLoss As Double
      ''' <summary>
      ''' SuctionLineLoss
      ''' </summary>
      Public Property SuctionLineLoss() As Double
         Get
            Return Me.m_SuctionLineLoss
         End Get
         Set(ByVal value As Double)
            Me.m_SuctionLineLoss = value
         End Set
      End Property

      Private m_Altitude As Double
      ''' <summary>
      ''' Altitude
      ''' </summary>
      Public Property Altitude() As Double
         Get
            Return Me.m_Altitude
         End Get
         Set(ByVal value As Double)
            Me.m_Altitude = value
         End Set
      End Property

      Private m_PumpWatts As Double
      ''' <summary>
      ''' PumpWatts
      ''' </summary>
      Public Property PumpWatts() As Double
         Get
            Return Me.m_PumpWatts
         End Get
         Set(ByVal value As Double)
            Me.m_PumpWatts = value
         End Set
      End Property

      Private m_FanWatts As Double
      ''' <summary>
      ''' FanWatts
      ''' </summary>
      Public Property FanWatts() As Double
         Get
            Return Me.m_FanWatts
         End Get
         Set(ByVal value As Double)
            Me.m_FanWatts = value
         End Set
      End Property

      Private m_CondenserCapacity1 As Double
      ''' <summary>
      ''' CondenserCapacity1
      ''' </summary>
      Public Property CondenserCapacity1() As Double
         Get
            Return Me.m_CondenserCapacity1
         End Get
         Set(ByVal value As Double)
            Me.m_CondenserCapacity1 = value
         End Set
      End Property

      Private m_CondenserCapacity2 As Double
      ''' <summary>
      ''' CondenserCapacity2
      ''' </summary>
      Public Property CondenserCapacity2() As Double
         Get
            Return Me.m_CondenserCapacity2
         End Get
         Set(ByVal value As Double)
            Me.m_CondenserCapacity2 = value
         End Set
      End Property

      Private m_EvaporatorModel As String
      ''' <summary>
      ''' EvaporatorModel
      ''' </summary>
      Public Property EvaporatorModel() As String
         Get
            Return Me.m_EvaporatorModel
         End Get
         Set(ByVal value As String)
            Me.m_EvaporatorModel = value
         End Set
      End Property

      Private m_EvaporatorModelDesc As String
      ''' <summary>
      ''' EvaporatorModelDesc
      ''' </summary>
      Public Property EvaporatorModelDesc() As String
         Get
            Return Me.m_EvaporatorModelDesc
         End Get
         Set(ByVal value As String)
            Me.m_EvaporatorModelDesc = value
         End Set
      End Property

      Private m_NumEvap As Double
      ''' <summary>
      ''' NumEvap
      ''' </summary>
      Public Property NumEvap() As Double
         Get
            Return Me.m_NumEvap
         End Get
         Set(ByVal value As Double)
            Me.m_NumEvap = value
         End Set
      End Property

      Private m_FoulingFactor As Double
      ''' <summary>
      ''' FoulingFactor
      ''' </summary>
      Public Property FoulingFactor() As Double
         Get
            Return Me.m_FoulingFactor
         End Get
         Set(ByVal value As Double)
            Me.m_FoulingFactor = value
         End Set
      End Property

      Private m_CapacityType As eCapacityType
      ''' <summary>
      ''' CapacityType
      ''' </summary>
      Public Property CapacityType() As eCapacityType
         Get
            Return Me.m_CapacityType
         End Get
         Set(ByVal value As eCapacityType)
            Me.m_CapacityType = value
         End Set
      End Property

      Private m_EvaporatorCapacity As Double
      ''' <summary>
      ''' EvaporatorCapacity
      ''' </summary>
      Public Property EvaporatorCapacity() As Double
         Get
            Return Me.m_EvaporatorCapacity
         End Get
         Set(ByVal value As Double)
            Me.m_EvaporatorCapacity = value
         End Set
      End Property

      Private m_CatalogRating As Boolean
      ''' <summary>
      ''' CatalogRating
      ''' </summary>
      Public Property CatalogRating() As Boolean
         Get
            Return Me.m_CatalogRating
         End Get
         Set(ByVal value As Boolean)
            Me.m_CatalogRating = value
         End Set
      End Property

      Private m_ApproachRange As eApproachRange
      ''' <summary>
      ''' ApproachRange
      ''' </summary>
      Public Property ApproachRange() As eApproachRange
         Get
            Return Me.m_ApproachRange
         End Get
         Set(ByVal value As eApproachRange)
            Me.m_ApproachRange = value
         End Set
      End Property

      Private m_Evap8Degr1 As Double
      ''' <summary>
      ''' Evap8Degr1
      ''' </summary>
      Public Property Evap8Degr1() As Double
         Get
            Return Me.m_Evap8Degr1
         End Get
         Set(ByVal value As Double)
            Me.m_Evap8Degr1 = value
         End Set
      End Property

      Private m_Evap8Degr2 As Double
      ''' <summary>
      ''' Evap8Degr2
      ''' </summary>
      Public Property Evap8Degr2() As Double
         Get
            Return Me.m_Evap8Degr2
         End Get
         Set(ByVal value As Double)
            Me.m_Evap8Degr2 = value
         End Set
      End Property

      Private m_Evap10Degr1 As Double
      ''' <summary>
      ''' Evap10Degr1
      ''' </summary>
      Public Property Evap10Degr1() As Double
         Get
            Return Me.m_Evap10Degr1
         End Get
         Set(ByVal value As Double)
            Me.m_Evap10Degr1 = value
         End Set
      End Property

      Private m_Evap10Degr2 As Double
      ''' <summary>
      ''' Evap10Degr2
      ''' </summary>
      Public Property Evap10Degr2() As Double
         Get
            Return Me.m_Evap10Degr2
         End Get
         Set(ByVal value As Double)
            Me.m_Evap10Degr2 = value
         End Set
      End Property

      Private m_TEMin As Double
      ''' <summary>
      ''' TEMin
      ''' </summary>
      Public Property TEMin() As Double
         Get
            Return Me.m_TEMin
         End Get
         Set(ByVal value As Double)
            Me.m_TEMin = value
         End Set
      End Property

      Private m_TEMax As Double
      ''' <summary>
      ''' TEMax
      ''' </summary>
      Public Property TEMax() As Double
         Get
            Return Me.m_TEMax
         End Get
         Set(ByVal value As Double)
            Me.m_TEMax = value
         End Set
      End Property

      Private m_TEIncrement As Double
      ''' <summary>
      ''' TEIncrement
      ''' </summary>
      Public Property TEIncrement() As Double
         Get
            Return Me.m_TEIncrement
         End Get
         Set(ByVal value As Double)
            Me.m_TEIncrement = value
         End Set
      End Property

      Private m_ATMin As Double
      ''' <summary>
      ''' ATMin
      ''' </summary>
      Public Property ATMin() As Double
         Get
            Return Me.m_ATMin
         End Get
         Set(ByVal value As Double)
            Me.m_ATMin = value
         End Set
      End Property

      Private m_ATMax As Double
      ''' <summary>
      ''' ATMax
      ''' </summary>
      Public Property ATMax() As Double
         Get
            Return Me.m_ATMax
         End Get
         Set(ByVal value As Double)
            Me.m_ATMax = value
         End Set
      End Property

      Private m_ATIncrement As Double
      ''' <summary>
      ''' ATIncrement
      ''' </summary>
      Public Property ATIncrement() As Double
         Get
            Return Me.m_ATIncrement
         End Get
         Set(ByVal value As Double)
            Me.m_ATIncrement = value
         End Set
      End Property

#End Region


#Region " Public methods"

      ''' <summary>
      ''' Constructs a evap chiller process that already exists in the data source based on the ID.
      ''' Automatically loads the process from the data source.
      ''' </summary>
      ''' <param name="id">
      ''' ID of the evap chiller process to load.
      ''' </param>
      Public Sub New(ByVal id As item_id)
         Me.initialize()
         Me.id = id
      End Sub

      ''' <summary>
      ''' Constructs a evap chiller process that already exists in the data source based on the ID.
      ''' Automatically loads the process from the data source.
      ''' </summary>
      ''' <param name="id">
      ''' ID of the evap chiller process to load.
      ''' </param>
      ''' <param name="RevNumber">
      ''' Revision number of the evap chiller process to load.
      ''' </param>
      Public Sub New(ByVal id As item_id, ByVal RevNumber As Integer)
         Me.initialize()
         Me.id = id
         Me.Revision = RevNumber
      End Sub

      ''' <summary>
      ''' Constructs a new evap chiller process with the specified name.
      ''' Generates a new ID.
      ''' </summary>
      ''' <param name="name">
      ''' Name of the process.
      ''' </param>
      ''' <param name="createdBy">
      ''' Username of the person who created the process.
      ''' </param>
      ''' <param name="password">
      ''' Password of the person who created the process.
      ''' </param>
      ''' <param name="parent">
      ''' Parent project manager that process should be included in.
      ''' </param>
      Public Sub New(ByVal name As String, ByVal createdBy As String, ByVal password As String, ByVal parent As project_manager)
         Me.initialize()
         Me.name = name
         Me.id = New item_id(createdBy, password)
         Me.ProjectManager = parent
      End Sub


      ''' <summary>
      ''' Constructs a new evap chiller process with the specified name.
      ''' Used when making a clone.
      ''' </summary>
      ''' <param name="name">
      ''' Name of process.
      ''' </param>
      ''' <param name="id">
      ''' ID of process.
      ''' </param>
      Public Sub New(ByVal name As String, ByVal id As item_id)
         Me.initialize()
         Me.name = name
         Me.id = id
      End Sub


      Sub New(chillerEquip As chiller_equipment)
         Me.New(chillerEquip.name, chillerEquip.id.Username, chillerEquip.id.Password, chillerEquip.ProjectManager)
         Me.initialize()

         Static equipFlag As Boolean = False

         ' sets common properties
         Me.Series = chillerEquip.series.Remove(chillerEquip.series.Length-2, 2)
         Me.Model = chillerEquip.model

         If chillerEquip.Specs.Fluid = "Water" Then
            Me.Fluid = chillerEquip.Specs.Fluid
         ElseIf chillerEquip.Specs.Fluid = "Ethylene" _
         OrElse chillerEquip.Specs.Fluid = "Propylene" Then
            Me.Fluid = "Glycol"
            Me.CoolingMedia = chillerEquip.Specs.Fluid
         End If

         Me.AmbientTemp = chillerEquip.Specs.AmbientTemp.value_or_default
         Me.LeavingFluidTemp = chillerEquip.Specs.LeavingFluidTemp.value_or_default
         Me.GlycolPercentage = chillerEquip.Specs.GlycolPercent.value_or_default
         Me.Refrigerant = chillerEquip.Specs.Refrigerant
         Me.Altitude = chillerEquip.common_specs.Altitude.value_or_default

         'prevent null ref
         If equipFlag = False Then
            Me.Equipment = New EquipmentItemList
            equipFlag = True
         End If

         ' associate equipment w/ process
         Me.Equipment.Add(chillerEquip)

         'link process and equipment in a database table
         DataAccess.Projects.ProcessEquipDA.Create(Me.id.ToString, chillerEquip.id.ToString)
      End Sub

      ''' <summary>
      ''' Loads evap chiller process based on ID. 
      ''' ID must be set before calling this method.
      ''' (Optionally revision can be set to pull specific revision.)
      ''' </summary>
      Public Overrides Sub Load()
         Dim process As ACChillerProcessItem
         If Me.Revision > -1 Then
            process = ACChillerProcessDA.Retrieve(Me.id, Me.Revision)
         Else
            process = ACChillerProcessDA.Retrieve(Me.id)
         End If
         Me.Copy(process)
      End Sub



      'Public Overrides Sub Save()
      '    'If ACChillerProcessDA.Exists(Me.Id) Then
      '    '   ACChillerProcessDA.Update(Me)
      '    'Else
      '    ACChillerProcessDA.Create(Me)
      '    Me.OnSaved()
      '    'End If
      'End Sub


      'Public Sub CopyObject(ByVal objType As System.Type, _
      'ByVal CurrentObj As Object, _
      'ByRef NewObj As Object)

      '    Dim Props() As PropertyInfo = _
      '    objType.GetProperties(BindingFlags.Public Or _
      '    BindingFlags.Instance)
      '    For Each PropItem As PropertyInfo In Props
      '        If PropItem.CanWrite Then
      '            PropItem.SetValue(NewObj, _
      '            PropItem.GetValue(CurrentObj, Nothing), Nothing)
      '        End If
      '    Next

      'End Sub

      '''' <summary>
      '''' Copies the values of another evap chiller process.
      '''' </summary>
      '''' <param name="objectToCopy">
      '''' Evap chiller process to copy.
      '''' </param>
      'Public Sub Copy(ByVal objectToCopy As ACChillerProcessItem) _
      'Implements Core.ICopyable(Of ACChillerProcessItem).Copy

      '    CopyObject(GetType(ACChillerProcessItem), objectToCopy, Me)

      '    'With objectToCopy
      '    '    Me.Id = New ItemId(.Id.ToString)
      '    '    Me.Name = .Name
      '    '    Me.ProjectManager = .ProjectManager
      '    '    Me.MetaData = .MetaData.Clone()
      '    '    Me.Notes = .Notes
      '    '    Me.Version = .Version
      '    '    Me.Revision = .Revision
      '    '    Me.CreatedBy = .CreatedBy
      '    '    Me.RevisionDate = .RevisionDate
      '    '    Me.Series = .Series
      '    '    Me.NewCoefficients = .NewCoefficients
      '    '    Me.Model = .Model
      '    '    Me.ModelDesc = .ModelDesc
      '    '    Me.Fluid = .Fluid
      '    '    Me.GlycolPercentage = .GlycolPercentage
      '    '    Me.CoolingMedia = .CoolingMedia
      '    '    Me.SpecificHeat = .SpecificHeat
      '    '    Me.SpecificGravity = .SpecificGravity
      '    '    Me.SubCooling = .SubCooling
      '    '    Me.Refrigerant = .Refrigerant
      '    '    Me.TempRange = .TempRange
      '    '    Me.AmbientTemp = .AmbientTemp
      '    '    Me.LeavingFluidTemp = .LeavingFluidTemp
      '    '    Me.System = .System
      '    '    Me.Hertz = .Hertz
      '    '    Me.Volts = .Volts
      '    '    Me.Approach = .Approach
      '    '    Me.SafetyOverride = .SafetyOverride
      '    '    Me.Circuit1 = .Circuit1
      '    '    Me.Circuit2 = .Circuit2
      '    '    Me.NumCompressors1 = .NumCompressors1
      '    '    Me.NumCompressors2 = .NumCompressors2
      '    '    Me.Compressors1 = .Compressors1
      '    '    Me.Compressors2 = .Compressors2
      '    '    Me.NumCoils1 = .NumCoils1
      '    '    Me.NumCoils2 = .NumCoils2
      '    '    Me.Condenser1 = .Condenser1
      '    '    Me.Condenser2 = .Condenser2
      '    '    Me.DischargeLineLoss = .DischargeLineLoss
      '    '    Me.SuctionLineLoss = .SuctionLineLoss
      '    '    Me.Altitude = .Altitude
      '    '    Me.PumpWatts = .PumpWatts
      '    '    Me.FanWatts = .FanWatts
      '    '    Me.CondenserCapacity1 = .CondenserCapacity1
      '    '    Me.CondenserCapacity2 = .CondenserCapacity2
      '    '    Me.EvaporatorModel = .EvaporatorModel
      '    '    Me.EvaporatorModelDesc = .EvaporatorModelDesc
      '    '    Me.NumEvap = .NumEvap
      '    '    Me.FoulingFactor = .FoulingFactor
      '    '    Me.CapacityType = .CapacityType
      '    '    Me.EvaporatorCapacity = .EvaporatorCapacity
      '    '    Me.CatalogRating = .CatalogRating
      '    '    Me.ApproachRange = .ApproachRange
      '    '    Me.Evap8Degr1 = .Evap8Degr1
      '    '    Me.Evap8Degr2 = .Evap8Degr2
      '    '    Me.Evap10Degr1 = .Evap10Degr1
      '    '    Me.Evap10Degr2 = .Evap10Degr2
      '    'End With
      'End Sub


      '''' <summary>
      '''' Creates a clone of this evap chiller process.
      '''' </summary>
      '''' <returns>
      '''' Clone of this evap chiller process.
      '''' </returns>
      'Public Function Clone() As ACChillerProcessItem _
      'Implements Core.ICloneable(Of ACChillerProcessItem).Clone
      '    Dim other As New ACChillerProcessItem(Me.Name, Me.Id)
      '    other.Id = Me.Id
      '    other.Name = Me.Name
      '    other.ProjectManager = Me.ProjectManager
      '    other.MetaData = Me.MetaData
      '    other.Notes = Me.Notes
      '    other.Version = Me.Version
      '    other.Revision = Me.Revision
      '    other.CreatedBy = Me.CreatedBy
      '    other.RevisionDate = Me.RevisionDate
      '    other.Series = Me.Series
      '    other.NewCoefficients = Me.NewCoefficients
      '    other.Model = Me.Model
      '    other.ModelDesc = Me.ModelDesc
      '    other.Fluid = Me.Fluid
      '    other.GlycolPercentage = Me.GlycolPercentage
      '    other.CoolingMedia = Me.CoolingMedia
      '    other.SpecificHeat = Me.SpecificHeat
      '    other.SpecificGravity = Me.SpecificGravity
      '    other.SubCooling = Me.SubCooling
      '    other.Refrigerant = Me.Refrigerant
      '    other.TempRange = Me.TempRange
      '    other.AmbientTemp = Me.AmbientTemp
      '    other.LeavingFluidTemp = Me.LeavingFluidTemp
      '    other.System = Me.System
      '    other.Hertz = Me.Hertz
      '    other.Volts = Me.Volts
      '    other.Approach = Me.Approach
      '    other.SafetyOverride = Me.SafetyOverride
      '    other.Circuit1 = Me.Circuit1
      '    other.Circuit2 = Me.Circuit2
      '    other.NumCompressors1 = Me.NumCompressors1
      '    other.NumCompressors2 = Me.NumCompressors2
      '    other.Compressors1 = Me.Compressors1
      '    other.Compressors2 = Me.Compressors2
      '    other.NumCoils1 = Me.NumCoils1
      '    other.NumCoils2 = Me.NumCoils2
      '    other.Condenser1 = Me.Condenser1
      '    other.Condenser2 = Me.Condenser2
      '    other.DischargeLineLoss = Me.DischargeLineLoss
      '    other.SuctionLineLoss = Me.SuctionLineLoss
      '    other.Altitude = Me.Altitude
      '    other.PumpWatts = Me.PumpWatts
      '    other.FanWatts = Me.FanWatts
      '    other.CondenserCapacity1 = Me.CondenserCapacity1
      '    other.CondenserCapacity2 = Me.CondenserCapacity2
      '    other.EvaporatorModel = Me.EvaporatorModel
      '    other.EvaporatorModelDesc = Me.EvaporatorModelDesc
      '    other.NumEvap = Me.NumEvap
      '    other.FoulingFactor = Me.FoulingFactor
      '    other.CapacityType = Me.CapacityType
      '    other.EvaporatorCapacity = Me.EvaporatorCapacity
      '    other.CatalogRating = Me.CatalogRating
      '    other.ApproachRange = Me.ApproachRange
      '    other.Evap8Degr1 = Me.Evap8Degr1
      '    other.Evap8Degr2 = Me.Evap8Degr2
      '    other.Evap10Degr1 = Me.Evap10Degr1
      '    other.Evap10Degr2 = Me.Evap10Degr2
      '    Return other
      'End Function


      '''' <summary>
      '''' Determines whether this evap chiller process is equal to the other process.
      '''' True if are equal; else false.
      '''' </summary>
      '''' <param name="other">
      '''' Other evap chiller process to compare.
      '''' </param>
      'Public Overloads Function Equals(ByVal other As ACChillerProcessItem) As Boolean _
      'Implements System.IEquatable(Of ACChillerProcessItem).Equals

      '    If Me.Id.Equals(other.Id) _
      '    AndAlso Me.Name = other.Name _
      '    AndAlso Me.MetaData.Equals(other.MetaData) _
      '    AndAlso Me.Notes = other.Notes _
      '    AndAlso Me.Version = other.Version _
      '    AndAlso Me.Revision = other.Revision _
      '    AndAlso Me.CreatedBy = other.CreatedBy _
      '    AndAlso Me.RevisionDate = other.RevisionDate _
      '    AndAlso Me.Series = other.Series _
      '    AndAlso Me.NewCoefficients = other.NewCoefficients _
      '    AndAlso Me.Model = other.Model _
      '    AndAlso Me.ModelDesc = other.ModelDesc _
      '    AndAlso Me.Fluid = other.Fluid _
      '    AndAlso Me.GlycolPercentage = other.GlycolPercentage _
      '    AndAlso Me.CoolingMedia = other.CoolingMedia _
      '    AndAlso Me.SpecificHeat = other.SpecificHeat _
      '    AndAlso Me.SpecificGravity = other.SpecificGravity _
      '    AndAlso Me.SubCooling = other.SubCooling _
      '    AndAlso Me.Refrigerant = other.Refrigerant _
      '    AndAlso Me.TempRange = other.TempRange _
      '    AndAlso Me.AmbientTemp = other.AmbientTemp _
      '    AndAlso Me.LeavingFluidTemp = other.LeavingFluidTemp _
      '    AndAlso Me.System = other.System _
      '    AndAlso Me.Hertz = other.Hertz _
      '    AndAlso Me.Volts = other.Volts _
      '    AndAlso Me.Approach = other.Approach _
      '    AndAlso Me.SafetyOverride = other.SafetyOverride _
      '    AndAlso Me.Circuit1 = other.Circuit1 _
      '    AndAlso Me.Circuit2 = other.Circuit2 _
      '    AndAlso Me.NumCompressors1 = other.NumCompressors1 _
      '    AndAlso Me.NumCompressors2 = other.NumCompressors2 _
      '    AndAlso Me.Compressors1 = other.Compressors1 _
      '    AndAlso Me.Compressors2 = other.Compressors2 _
      '    AndAlso Me.NumCoils1 = other.NumCoils1 _
      '    AndAlso Me.NumCoils2 = other.NumCoils2 _
      '    AndAlso Me.Condenser1 = other.Condenser1 _
      '    AndAlso Me.Condenser2 = other.Condenser2 _
      '    AndAlso Me.DischargeLineLoss = other.DischargeLineLoss _
      '    AndAlso Me.SuctionLineLoss = other.SuctionLineLoss _
      '    AndAlso Me.Altitude = other.Altitude _
      '    AndAlso Me.PumpWatts = other.PumpWatts _
      '    AndAlso Me.FanWatts = other.FanWatts _
      '    AndAlso Me.CondenserCapacity1 = other.CondenserCapacity1 _
      '    AndAlso Me.CondenserCapacity2 = other.CondenserCapacity2 _
      '    AndAlso Me.EvaporatorModel = other.EvaporatorModel _
      '    AndAlso Me.EvaporatorModelDesc = other.EvaporatorModelDesc _
      '    AndAlso Me.NumEvap = other.NumEvap _
      '    AndAlso Me.FoulingFactor = other.FoulingFactor _
      '    AndAlso Me.CapacityType = other.CapacityType _
      '    AndAlso Me.EvaporatorCapacity = other.EvaporatorCapacity _
      '    AndAlso Me.CatalogRating = other.CatalogRating _
      '    AndAlso Me.ApproachRange = other.ApproachRange _
      '    AndAlso Me.Evap8Degr1 = other.Evap8Degr1 _
      '    AndAlso Me.Evap8Degr2 = other.Evap8Degr2 _
      '    AndAlso Me.Evap10Degr1 = other.Evap10Degr1 _
      '    AndAlso Me.Evap10Degr2 = other.Evap10Degr2 Then
      '        Return True
      '    Else
      '        Return False
      '    End If

      'End Function

#End Region


      ''' <summary>
      ''' Initializes objects. Prevents NullReference.
      ''' </summary>
      Protected Overrides Sub initialize()
         MyBase.initialize()
      End Sub


   End Class
End Namespace

