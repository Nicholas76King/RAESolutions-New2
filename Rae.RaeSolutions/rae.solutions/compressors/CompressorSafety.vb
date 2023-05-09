namespace rae.solutions.compressors

''' <summary>Compressor safety data</summary>
Public Structure CompressorSafety
   Public MaxSuctionTemperature As Double
   Public MinSuctionTemperature As Double
   Public MaxCondensingTemperature As Double
   Public MinCondensingTemperature As Double
   Public Unloading As String
   Public HeatingAndCoolingFan As String
   Public Demandc As String
   Public LiquidInjection As String
   Public OilCooling As String

   Public Sub Clear()
      Me.MaxSuctionTemperature = 0
      Me.MinSuctionTemperature = 0
      Me.MaxCondensingTemperature = 0
      Me.MinCondensingTemperature = 0
      Me.Unloading = ""
      Me.HeatingAndCoolingFan = ""
      Me.Demandc = ""
      Me.LiquidInjection = ""
      Me.OilCooling = ""
   End Sub

End Structure
End Namespace