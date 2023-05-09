Namespace SpecBuilder

   Public Class RefrigerantData

      '17 properties

#Region " Declarations"

      Private _solenoid As Boolean
      Private _filterDrier As Boolean
      Private _filterDrierType As String
      Private _expansionValve As String
      Private _pressureReliefHigh As Boolean
      Private _pressureReliefLow As Boolean
      Private _suctionAccumulators As String
      Private _hotGasDischargeMuffler As Boolean
      Private _oilSeperator As Boolean
      Private _suctionFilter As Boolean
      Private _suctionFilterType As String
      Private _vibratorbers As String
      'TODO: change vibratorbers to checkboxes/booleans
      Private _hotGasBypass As Boolean
      Private _hotGasBypassDesign As String
      Private _hotGasBypassTons As String
      Private _liquidReceiver As String
      Private _liquidReceiverHandValves As Boolean

#End Region


#Region " Properties"

      Public Property Solenoid() As Boolean
         Get
            Return Me._solenoid
         End Get
         Set(ByVal Value As Boolean)
            Me._solenoid = Value
         End Set
      End Property


      Public Property FilterDrier() As Boolean
         Get
            Return Me._filterDrier
         End Get
         Set(ByVal Value As Boolean)
            Me._filterDrier = Value
         End Set
      End Property


      Public Property FilterDrierType() As String
         Get
            Return Me._filterDrierType
         End Get
         Set(ByVal Value As String)
            Me._filterDrierType = Value
         End Set
      End Property


      Public Property ExpansionValve() As String
         Get
            Return Me._expansionValve
         End Get
         Set(ByVal Value As String)
            Me._expansionValve = Value
         End Set
      End Property


      Public Property PressureReliefHigh() As Boolean
         Get
            Return Me._pressureReliefHigh
         End Get
         Set(ByVal Value As Boolean)
            Me._pressureReliefHigh = Value
         End Set
      End Property


      Public Property PressureReliefLow() As Boolean
         Get
            Return Me._pressureReliefLow
         End Get
         Set(ByVal Value As Boolean)
            Me._pressureReliefLow = Value
         End Set
      End Property


      Public Property SuctionAccumulators() As String
         Get
            Return Me._suctionAccumulators
         End Get
         Set(ByVal Value As String)
            Me._suctionAccumulators = Value
         End Set
      End Property


      Public Property HotGasDischargeMuffler() As Boolean
         Get
            Return Me._hotGasDischargeMuffler
         End Get
         Set(ByVal Value As Boolean)
            Me._hotGasDischargeMuffler = Value
         End Set
      End Property


      Public Property OilSeperator() As Boolean
         Get
            Return Me._oilSeperator
         End Get
         Set(ByVal Value As Boolean)
            Me._oilSeperator = Value
         End Set
      End Property


      Public Property SuctionFilter() As Boolean
         Get
            Return Me._suctionFilter
         End Get
         Set(ByVal Value As Boolean)
            Me._suctionFilter = Value
         End Set
      End Property


      Public Property SuctionFilterType() As String
         Get
            Return Me._suctionFilterType
         End Get
         Set(ByVal Value As String)
            Me._suctionFilterType = Value
         End Set
      End Property


      Public Property Vibratorbers() As String
         Get
            Return Me._vibratorbers
         End Get
         Set(ByVal Value As String)
            Me._vibratorbers = Value
         End Set
      End Property


      Public Property HotGasBypass() As Boolean
         Get
            Return Me._hotGasBypass
         End Get
         Set(ByVal Value As Boolean)
            Me._hotGasBypass = Value
         End Set
      End Property


      Public Property HotGasBypassDesign() As String
         Get
            Return Me._hotGasBypassDesign
         End Get
         Set(ByVal Value As String)
            Me._hotGasBypassDesign = Value
         End Set
      End Property


      Public Property HotGasBypassTons() As String
         Get
            Return Me._hotGasBypassTons
         End Get
         Set(ByVal Value As String)
            Me._hotGasBypassTons = Value
         End Set
      End Property


      Public Property LiquidReceiver() As String
         Get
            Return Me._liquidReceiver
         End Get
         Set(ByVal Value As String)
            Me._liquidReceiver = Value
         End Set
      End Property


      Public Property LiquidReceiverHandValves() As Boolean
         Get
            Return Me._liquidReceiverHandValves
         End Get
         Set(ByVal Value As Boolean)
            Me._liquidReceiverHandValves = Value
         End Set
      End Property

#End Region

      Public Sub New()

      End Sub

   End Class

End Namespace
