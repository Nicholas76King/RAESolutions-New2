Imports WCChillerProcessDA = Rae.RaeSolutions.DataAccess.Projects.WCChillerProcessDA
Imports System.Reflection

Namespace Rae.RaeSolutions.Business.Entities

   ''' <summary>
   ''' WC Chiller process.
   ''' </summary>
   ''' <history start="2006/08/08" by="JOSHH">
   ''' Created
   ''' </history>
   Public Class WCChillerProcessItem
      Inherits ProcessItem

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


#End Region


#Region " Public methods"

      ''' <summary>
      ''' Constructs a water chiller process that already exists in the data source based on the ID.
      ''' Automatically loads the process from the data source.
      ''' </summary>
      ''' <param name="id">
      ''' ID of the water chiller process to load.
      ''' </param>
      Public Sub New(ByVal id As item_id)
         Me.initialize()
         Me.id = id
      End Sub

      ''' <summary>
      ''' Constructs a water chiller process that already exists in the data source based on the ID.
      ''' Automatically loads the process from the data source.
      ''' </summary>
      ''' <param name="id">
      ''' ID of the water chiller process to load.
      ''' </param>
      ''' <param name="RevNumber">
      ''' Revision number of the water chiller process to load.
      ''' </param>
      Public Sub New(ByVal id As item_id, ByVal RevNumber As Integer)
         Me.initialize()
         Me.id = id
         Me.Revision = RevNumber
      End Sub

      ''' <summary>
      ''' Constructs a new water chiller process with the specified name.
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
      ''' Constructs a new water chiller process with the specified name.
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

      Public Sub New(ByVal chillerEquip As chiller_equipment)

         Me.New(chillerEquip.name, chillerEquip.id.Username, chillerEquip.id.Password, chillerEquip.ProjectManager)
         Me.initialize()

         Static equipFlag As Boolean = False

         ' sets common properties
         Me.Series = chillerEquip.series
         Me.Model = Me.Series + chillerEquip.model_without_series

         Me.AmbientTemp = chillerEquip.Specs.AmbientTemp.value
         Me.Refrigerant = chillerEquip.Specs.Refrigerant
         'Me.Specs.SubCooling = condenserProcess.SubCooling
         'Me.Specs.TempDifference.Value = condenserProcess.TD
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
      ''' Loads water chiller process based on ID. 
      ''' ID must be set before calling this method.
      ''' (Optionally revision can be set to pull specific revision.)
      ''' </summary>
      Public Overrides Sub Load()
         Dim process As WCChillerProcessItem
         If Me.Revision > -1 Then
            process = WCChillerProcessDA.Retrieve(Me.id, Me.Revision)
         Else
            process = WCChillerProcessDA.Retrieve(Me.id)
         End If
         Me.Copy(process)
      End Sub


      'Public Overrides Sub Save()
      '    'If WCChillerProcessDA.Exists(Me.Id) Then
      '    '   WCChillerProcessDA.Update(Me)
      '    'Else
      '    WCChillerProcessDA.Create(Me)
      '    Me.OnSaved()
      '    'End If
      'End Sub

#End Region


      ''' <summary>
      ''' Initializes objects. Prevents NullReference.
      ''' </summary>
      Protected Overrides Sub initialize()
         MyBase.initialize()
      End Sub


   End Class
End Namespace

