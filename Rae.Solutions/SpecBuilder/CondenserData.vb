Namespace SpecBuilder

   Public Class CondenserData
      '21 properties

#Region " Declarations"

      Private _condenser As String

      'air-cooled
      Private _condenserDesign As String
      Private _finMaterial As String
      Private _casingsAndTubeSheets As String
      Private _tubeThickness As String
      Private _finThickness As String
      Private _condenserType As String
      Private _discharge As String
      Private _rainHood As Boolean
      Private _subCoolingCircuit As Boolean
      Private _motor As String
      Private _lowAmbient As String
      Private _ambient As String
      Private _floodedCondenserControl As Boolean
      Private _heatedAndInsulatedReceivers As Boolean

      'water-cooled
      Private _waterValves As Boolean
      Private _heatExchanger As String

      'evaporative-cooled
      Private _material As String
      Private _headPressure As String
      Private _coil As String
      Private _acousticAttenuatorsIntake As Boolean
      Private _acousticAttenuatorsDischarge As Boolean

#End Region


#Region " Properties"

#Region " Air-cooled"

      Public Property Condenser() As String
         Get
            Return Me._condenser
         End Get
         Set(ByVal Value As String)
            Me._condenser = Value
         End Set
      End Property

      Public Property CondenserDesign() As String
         Get
            Return Me._condenserDesign
         End Get
         Set(ByVal Value As String)
            Me._condenserDesign = Value
         End Set
      End Property

      Public Property FinMaterial() As String
         Get
            Return Me._finMaterial
         End Get
         Set(ByVal Value As String)
            Me._finMaterial = Value
         End Set
      End Property

      Public Property CasingsAndTubeSheets() As String
         Get
            Return Me._casingsAndTubeSheets
         End Get
         Set(ByVal Value As String)
            Me._casingsAndTubeSheets = Value
         End Set
      End Property

      Public Property TubeThickness() As String
         Get
            Return Me._tubeThickness
         End Get
         Set(ByVal Value As String)
            Me._tubeThickness = Value
         End Set
      End Property

      Public Property FinThickness() As String
         Get
            Return Me._finThickness
         End Get
         Set(ByVal Value As String)
            Me._finThickness = Value
         End Set
      End Property

      Public Property CondenserType() As String
         Get
            Return Me._condenserType
         End Get
         Set(ByVal Value As String)
            Me._condenserType = Value
         End Set
      End Property

      Public Property Discharge() As String
         Get
            Return Me._discharge
         End Get
         Set(ByVal Value As String)
            Me._discharge = Value
         End Set
      End Property

      Public Property RainHood() As Boolean
         Get
            Return Me._rainHood
         End Get
         Set(ByVal Value As Boolean)
            Me._rainHood = Value
         End Set
      End Property

      Public Property SubCoolingCircuit() As Boolean
         Get
            Return Me._subCoolingCircuit
         End Get
         Set(ByVal Value As Boolean)
            Me._subCoolingCircuit = Value
         End Set
      End Property

      Public Property Motor() As String
         Get
            Return Me._motor
         End Get
         Set(ByVal Value As String)
            Me._motor = Value
         End Set
      End Property

      Public Property LowAmbient() As String
         Get
            Return Me._lowAmbient
         End Get
         Set(ByVal Value As String)
            Me._lowAmbient = Value
         End Set
      End Property

      Public Property Ambient() As String
         Get
            Return Me._ambient
         End Get
         Set(ByVal Value As String)
            Me._ambient = Value
         End Set
      End Property

      Public Property FloodedCondenserControl() As Boolean
         Get
            Return Me._floodedCondenserControl
         End Get
         Set(ByVal Value As Boolean)
            Me._floodedCondenserControl = Value
         End Set
      End Property

      Public Property HeatedAndInsulatedReceivers() As Boolean
         Get
            Return Me._heatedAndInsulatedReceivers
         End Get
         Set(ByVal Value As Boolean)
            Me._heatedAndInsulatedReceivers = Value
         End Set
      End Property

#End Region

#Region " Water-cooled"

      Public Property WaterValves() As Boolean
         Get
            Return Me._waterValves
         End Get
         Set(ByVal Value As Boolean)
            Me._waterValves = Value
         End Set
      End Property

      Public Property HeatExchanger() As String
         Get
            Return Me._heatExchanger
         End Get
         Set(ByVal Value As String)
            Me._heatExchanger = Value
         End Set
      End Property

#End Region

#Region " Evaporative-cooled"

      Public Property Material() As String
         Get
            Return Me._material
         End Get
         Set(ByVal Value As String)
            Me._material = Value
         End Set
      End Property

      Public Property HeadPressure() As String
         Get
            Return Me._headPressure
         End Get
         Set(ByVal Value As String)
            Me._headPressure = Value
         End Set
      End Property

      Public Property Coil() As String
         Get
            Return Me._coil
         End Get
         Set(ByVal Value As String)
            Me._coil = Value
         End Set
      End Property

      Public Property AcousticAttenuatorsIntake() As Boolean
         Get
            Return Me._acousticAttenuatorsIntake
         End Get
         Set(ByVal Value As Boolean)
            Me._acousticAttenuatorsIntake = Value
         End Set
      End Property

      Public Property AcousticAttenuatorsDischarge() As Boolean
         Get
            Return Me._acousticAttenuatorsDischarge
         End Get
         Set(ByVal Value As Boolean)
            Me._acousticAttenuatorsDischarge = Value
         End Set
      End Property

#End Region

#End Region


      Public Sub New()

      End Sub

   End Class

End Namespace