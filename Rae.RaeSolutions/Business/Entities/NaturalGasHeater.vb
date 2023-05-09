Namespace Rae.RaeSolutions.Business.Entities

   ''' <summary>
   ''' Natural gas heater section for air handler.
   ''' </summary>
   Public Class NaturalGasHeater

      Public Enum HeaterType
         TwoStage = 0 ' default
         Modulating
      End Enum


      Private Const SECTION_ABBREVIATION As String = "C5"
      Private laborHours As Double


#Region " Properties"

      Private maxPower_ As Integer
      Public ReadOnly Property MaxPower() As Integer
         Get
            Return Me.maxPower_
         End Get
      End Property


      Private isBoardRequired_ As Boolean
      Public ReadOnly Property IsBoardRequired() As Boolean
         Get
            Return Me.isBoardRequired_
         End Get
      End Property


      Private airHandlerModel_ As String
      Public ReadOnly Property AirHandlerModel() As String
         Get
            Return Me.airHandlerModel_
         End Get
      End Property


      Private modulatingHeaterCost_ As Double
      Public ReadOnly Property ModulatingHeaterCost() As Double
         Get
            Return Me.modulatingHeaterCost_
         End Get
      End Property


      Private twoStageHeaterCost_ As Double
      Public ReadOnly Property TwoStageHeaterCost() As Double
         Get
            Return Me.twoStageHeaterCost_
         End Get
      End Property


      Private length_ As Integer
      Public ReadOnly Property Length() As Integer
         Get
            Return Me.length_
         End Get
      End Property


      Private power_ As Integer
      Public Property Power() As Integer
         Get
            Return Me.power_
         End Get
         Set(ByVal value As Integer)
            If Me.power_ <> value Then
               Me.power_ = value

               Me.retrieveNaturalGasHeaterInfo(Me.power_)
               Me.isBoardRequired_ = Me.checkIfBoardIsRequired(Me.power_, Me.type_)
            End If
         End Set
      End Property


      Private type_ As HeaterType
      Public Property Type() As HeaterType
         Get
            Return type_
         End Get
         Set(ByVal value As HeaterType)
            If value <> Me.type_ Then
               Me.type_ = value
               Me.isBoardRequired_ = Me.checkIfBoardIsRequired(Me.power_, type_)
            End If
         End Set
      End Property

#End Region


      ''' <summary>
      ''' Constructs natural gas heater section for air handler.
      ''' </summary>
      ''' <param name="airHandlerModel">
      ''' Air handler model is expected to be in the format: TPAH-##.
      ''' </param>
      Public Sub New(ByVal airHandlerModel As String)
         Me.initialize()

         Me.airHandlerModel_ = airHandlerModel

         Me.retrieveLength(Me.airHandlerModel_)
         Me.retrieveNaturalGasHeaterInfo(Me.power_)

         Me.maxPower_ = Me.getMaxPower(airHandlerModel)

         Me.isBoardRequired_ = Me.checkIfBoardIsRequired(Me.power_, Me.type_)
      End Sub


#Region " Private methods"

      Private Sub initialize()
         Me.type_ = HeaterType.TwoStage
         Me.power_ = 200
      End Sub


      Private Sub retrieveNaturalGasHeaterInfo(ByVal power As Integer)
         Dim info As DataAccess.AirHandlers.NaturalGasHeaterInfo = DataAccess.AirHandlers.RetrieveNaturalGasHeaterInfo(power)
         Me.modulatingHeaterCost_ = info.ModulatingHeaterCost
         Me.twoStageHeaterCost_ = info.TwoStageHeaterCost
         Me.laborHours = info.LaborHours
      End Sub


      Private Sub retrieveLength(ByVal airHandlerModel As String)
         Me.length_ = DataAccess.AirHandlers.RetrieveSectionLength(Me.airHandlerModel_, NaturalGasHeater.SECTION_ABBREVIATION)
      End Sub


      Private Function getMaxPower(ByVal airHandlerModel As String) As Integer
         Dim maxPower As Integer

         Dim modelNumber As Integer = Me.parseModelNumber(airHandlerModel)

         If modelNumber <= 22 Then
            maxPower = 400
         Else
            maxPower = 1600
         End If

         Return maxPower
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
      Private Function checkIfBoardIsRequired(ByVal power As Double, ByVal type As HeaterType) As Boolean
         Dim isBoardRequired As Boolean

         If power > 400 _
         OrElse type = HeaterType.Modulating Then
            isBoardRequired = True
         Else
            isBoardRequired = False
         End If

         Return isBoardRequired
      End Function


      Private Function parseModelNumber(ByVal airHandlerModel As String) As Integer
         Dim modelNumberString As String = airHandlerModel.Replace("TPAH-", "")
         Dim modelNumber As Integer = CInt(modelNumberString)
         Return modelNumber
      End Function

#End Region

   End Class

End Namespace