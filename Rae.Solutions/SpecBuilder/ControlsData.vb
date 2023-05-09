Namespace SpecBuilder

   Public Class ControlsData

#Region " Declarations"
      '21 Properties
      Private _controlsType As String
      Private _powerConnection As String
      Private _disconnectOption As Boolean
      Private _disconnectOptionType As String
      Private _compressorStatusLight As Boolean
      Private _failureStatusLight As Boolean
      Private _pumpStatusLight As Boolean
      Private _moldedCaseDisconnectSwitch As Boolean
      Private _compressorLeadLagSwitch As String
      Private _unitPhaseMonitor As Boolean
      Private _unitPhaseMonitorScope As String
      Private _refrigerantAndOilGauges As Boolean
      Private _Lcd As Boolean
      Private _LcdDemandLimitingSetPoint, _LcdChilledWaterSetPoint As Boolean
      Private _LcdCompressorAmps, _LcdCompressorStatus As Boolean
      Private _LcdRefrigerantDischargePressureAndTemperature As Boolean
      Private _LcdRefrigerantSuctionPressureAndTemperature As Boolean
      Private _LcdWaterTemperatures As Boolean
      Private _LcdFailureAndAlarmHistory As Boolean
#End Region


#Region " Properties"

      Public Property ControlsType() As String
         Get
            Return Me._controlsType
         End Get
         Set(ByVal Value As String)
            Me._controlsType = Value
         End Set
      End Property

      Public Property PowerConnection() As String
         Get
            Return Me._powerConnection
         End Get
         Set(ByVal Value As String)
            Me._powerConnection = Value
         End Set
      End Property

      Public Property DisconnectOption() As Boolean
         Get
            Return Me._disconnectOption
         End Get
         Set(ByVal Value As Boolean)
            Me._disconnectOption = Value
         End Set
      End Property

      Public Property DisconnectOptionType() As String
         Get
            Return Me._disconnectOptionType
         End Get
         Set(ByVal Value As String)
            Me._disconnectOptionType = Value
         End Set
      End Property

      Public Property CompressorStatusLight() As Boolean
         Get
            Return Me._compressorStatusLight
         End Get
         Set(ByVal Value As Boolean)
            Me._compressorStatusLight = Value
         End Set
      End Property

      Public Property FailureStatusLight() As Boolean
         Get
            Return Me._failureStatusLight
         End Get
         Set(ByVal Value As Boolean)
            Me._failureStatusLight = Value
         End Set
      End Property

      Public Property PumpStatusLight() As Boolean
         Get
            Return Me._pumpStatusLight
         End Get
         Set(ByVal Value As Boolean)
            Me._pumpStatusLight = Value
         End Set
      End Property

      Public Property MoldedCaseDisconnectSwitch() As Boolean
         Get
            Return Me._moldedCaseDisconnectSwitch
         End Get
         Set(ByVal Value As Boolean)
            Me._moldedCaseDisconnectSwitch = Value
         End Set
      End Property

      Public Property CompressorLeadLagSwitch() As String
         Get
            Return Me._compressorLeadLagSwitch
         End Get
         Set(ByVal Value As String)
            Me._compressorLeadLagSwitch = Value
         End Set
      End Property

      Public Property UnitPhaseMonitor() As Boolean
         Get
            Return Me._unitPhaseMonitor
         End Get
         Set(ByVal Value As Boolean)
            Me._unitPhaseMonitor = Value
         End Set
      End Property

      Public Property UnitPhaseMonitorScope() As String
         Get
            Return Me._unitPhaseMonitorScope
         End Get
         Set(ByVal Value As String)
            Me._unitPhaseMonitorScope = Value
         End Set
      End Property

      Public Property RefrigerantAndOilGauges() As Boolean
         Get
            Return Me._refrigerantAndOilGauges
         End Get
         Set(ByVal Value As Boolean)
            Me._refrigerantAndOilGauges = Value
         End Set
      End Property

      Public Property Lcd() As Boolean
         Get
            Return Me._Lcd
         End Get
         Set(ByVal Value As Boolean)
            Me._Lcd = Value
         End Set
      End Property

      Public Property LcdDemandLimitingSetPoint() As Boolean
         Get
            Return Me._LcdDemandLimitingSetPoint
         End Get
         Set(ByVal Value As Boolean)
            Me._LcdDemandLimitingSetPoint = Value
         End Set
      End Property

      Public Property LcdChilledWaterSetPoint() As Boolean
         Get
            Return Me._LcdChilledWaterSetPoint
         End Get
         Set(ByVal Value As Boolean)
            Me._LcdChilledWaterSetPoint = Value
         End Set
      End Property

      Public Property LcdCompressorAmps() As Boolean
         Get
            Return Me._LcdCompressorAmps
         End Get
         Set(ByVal Value As Boolean)
            Me._LcdCompressorAmps = Value
         End Set
      End Property

      Public Property LcdCompressorStatus() As Boolean
         Get
            Return Me._LcdCompressorStatus
         End Get
         Set(ByVal Value As Boolean)
            Me._LcdCompressorStatus = Value
         End Set
      End Property

      Public Property LcdRefrigerantDischargePressureAndTemperature() As Boolean
         Get
            Return Me._LcdRefrigerantDischargePressureAndTemperature
         End Get
         Set(ByVal Value As Boolean)
            Me._LcdRefrigerantDischargePressureAndTemperature = Value
         End Set
      End Property

      Public Property LcdRefrigerantSuctionPressureAndTemperature() As Boolean
         Get
            Return Me._LcdRefrigerantSuctionPressureAndTemperature
         End Get
         Set(ByVal Value As Boolean)
            Me._LcdRefrigerantSuctionPressureAndTemperature = Value
         End Set
      End Property

      Public Property LcdWaterTemperatures() As Boolean
         Get
            Return Me._LcdWaterTemperatures
         End Get
         Set(ByVal Value As Boolean)
            Me._LcdWaterTemperatures = Value
         End Set
      End Property

      Public Property LcdFailureAndAlarmHistory() As Boolean
         Get
            Return Me._LcdFailureAndAlarmHistory
         End Get
         Set(ByVal Value As Boolean)
            Me._LcdFailureAndAlarmHistory = Value
         End Set
      End Property

#End Region


      Public Sub New()

      End Sub


   End Class

End Namespace
