Option Strict On
Option Explicit On

Imports CompressorDataAccess = Rae.RaeSolutions.DataAccess.CompressorDataAccess

Namespace Rae.RaeSolutions.Business.Intelligence

   ''' <summary>
   ''' Determines compressor temperature limits based on compressor file name
   ''' </summary>
   Public Class CompressorTemperatureLimits

      Private maxSuctionTemperature_ As Double
      Private minSuctionTemperature_ As Double
      Private maxCondensingTemperature_ As Double
      Private minCondensingTemperature_ As Double


      Public Const ABSOLUTE_MIN_SUCTION_TEMPERATURE As Double = -40


#Region " Properties"

      ''' <summary>
      ''' Maximum suction temperature in degrees Fahrenheit
      ''' </summary>
      Public ReadOnly Property MaxSuctionTemperature() As Double
         Get
            Return Me.maxSuctionTemperature_
         End Get
      End Property


      ''' <summary>
      ''' Minimum suction temperature in degrees Fahrenheit
      ''' </summary>
      Public ReadOnly Property MinSuctionTemperature() As Double
         Get
            Return Me.minSuctionTemperature_
         End Get
      End Property


      ''' <summary>
      ''' Maximum condensing temperature in degrees Fahrenheit
      ''' </summary>
      Public ReadOnly Property MaxCondensingTemperature() As Double
         Get
            Return Me.maxCondensingTemperature_
         End Get
      End Property


      ''' <summary>
      ''' Minimum condensing temperature in degrees Fahrenheit
      ''' </summary>
      Public ReadOnly Property MinCondensingTemperature() As Double
         Get
            Return Me.minCondensingTemperature_
         End Get
      End Property

#End Region


      ''' <summary>
      ''' Compressor temperature limits for compressor file name
      ''' </summary>
      ''' <param name="compressorFileName">
      ''' Compressor file name to get temperature limits for
      ''' </param>
      Public Sub New(ByVal compressorFileName As String)
         ' retrieves temperature limits for the compressor file name
         Dim temperatureLimits As CompressorService.TemperatureLimitsTransferientialData
         temperatureLimits = CompressorService.GetTemperatureLimits(compressorFileName)

         ' sets property values
         Me.minSuctionTemperature_ = temperatureLimits.MinSuctionTemperature
         Me.maxSuctionTemperature_ = temperatureLimits.MaxSuctionTemperature
         Me.minCondensingTemperature_ = temperatureLimits.MinCondensingTemperature
         Me.maxCondensingTemperature_ = temperatureLimits.MaxCondensingTemperature
      End Sub

   End Class

End Namespace