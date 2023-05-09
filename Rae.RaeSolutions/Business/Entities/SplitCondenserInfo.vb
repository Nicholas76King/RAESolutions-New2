Imports System
Imports Rae.RaeSolutions.DataAccess.Projects
Imports Rae.DataAccess.EquipmentOptions

Namespace Rae.RaeSolutions.Business.Entities

   ''' <summary>
   ''' Provides information about a split condenser for a specified chiller.
   ''' </summary>
   ''' <remarks>
   ''' Used with 33A0 series.
   ''' A condenser's price can vary depending on the chiller it is selected with.
   ''' </remarks>
   ''' <history by="Casey Joyce" finish="2006/05/26">
   ''' Created
   ''' </history>
   Public Class SplitCondenserInfo

#Region " Properties"

      Private m_ChillerModel As String
      ''' <summary>
      ''' Chiller model
      ''' </summary>
      Public ReadOnly Property ChillerModel() As String
         Get
            Return Me.m_ChillerModel
         End Get
      End Property


      Private m_CondenserModel As String
      ''' <summary>
      ''' Condenser model associated with specified chiller.
      ''' </summary>
      Public ReadOnly Property CondenserModel() As String
         Get
            Return Me.m_CondenserModel
         End Get
      End Property


      Private m_CondenserPrice As Double
      ''' <summary>
      ''' Price of split condenser when with specified chiller.
      ''' </summary>
      Public ReadOnly Property CondenserPrice() As Double
         Get
            Return Me.m_CondenserPrice
         End Get
      End Property

#End Region


      ''' <summary>
      ''' Constructs split condenser info.
      ''' </summary>
      ''' <param name="chillerModel"></param>
      ''' <exception cref="ArgumentException">
      ''' Thrown when chiller model parameter is null or empty.
      ''' </exception>
      Public Sub New(ByVal chillerModel As String)
         ' validates chiller model parameter
         If String.IsNullOrEmpty(chillerModel) Then
            Throw New ArgumentException("Split condenser for chiller cannot be determined. Chiller model is empty or null.")
         End If

         Me.m_ChillerModel = chillerModel.Trim

         ' retrieves condenser model and price
         Me.m_CondenserModel = SuggestedModelsDataAccess.Retrieve(chillerModel)
         Me.m_CondenserPrice = OptionsDataAccess.RetrieveBaseListPrice(Me.m_CondenserModel.Substring(0, 4), Me.m_CondenserModel.Remove(0, 4))
      End Sub

   End Class

End Namespace