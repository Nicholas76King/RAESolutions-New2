Namespace SpecBuilder

   <Serializable()> _
   Public Class SpecBuilderData

      Public HousingAndPiping As HousingAndPipingData
      Public Compressor As CompressorData
      Public Evaporator As EvaporatorData
      Public Condenser As CondenserData
      Public Refrigerant As RefrigerantData
      Public Controls As ControlsData
      Public Pump As PumpData
      Public Hazard As HazardData
      Public Acoustic As AcousticData
      Public Other As OtherData

      'MAINTAIN: Add new data classes


#Region " Declarations"

      'unit
      Private _unit As String
      Private _coolingSolution As String
      Private _solutionPercentage As Integer
      Private _name As String

#End Region


#Region " Properties"

      Public Property Name() As String
         Get
            Return Me._name
         End Get
         Set(ByVal Value As String)
            Me._name = Value
         End Set
      End Property


      Public Property Version() As String
         Get
            Return "0.9"
         End Get
         Set(ByVal Value As String)
            'Set sub just so this property will write to file using XmlSerializer
         End Set
      End Property


      Public Property Unit() As String
         Get
            Return Me._unit
         End Get
         Set(ByVal Value As String)
            Me._unit = Value
         End Set
      End Property


      Public Property CoolingSolution() As String
         Get
            Return Me._coolingSolution
         End Get
         Set(ByVal Value As String)
            Me._coolingSolution = Value
         End Set
      End Property


      Public Property SolutionPercentage() As Integer
         Get
            Return Me._solutionPercentage
         End Get
         Set(ByVal Value As Integer)
            Me._solutionPercentage = Value
         End Set
      End Property

#End Region


#Region " Public Methods"

      Public Sub New()
         HousingAndPiping = New HousingAndPipingData
         Compressor = New CompressorData
         Evaporator = New EvaporatorData
         Condenser = New CondenserData
         Refrigerant = New RefrigerantData
         Controls = New ControlsData
         Pump = New PumpData
         Hazard = New HazardData
         Acoustic = New AcousticData
         Other = New OtherData
      End Sub

#End Region


   End Class

End Namespace