Namespace SpecBuilder

   Public Class HousingAndPipingData

#Region " Declarations"

      Private _baseFrame As String
      Private _housing As String
      Private _epoxyCoated As Boolean
      Private _piping As String

#End Region


#Region " Properties"

      Public Property BaseFrame() As String
         Get
            Return Me._baseFrame
         End Get
         Set(ByVal Value As String)
            Me._baseFrame = Value
         End Set
      End Property


      Public Property Housing() As String
         Get
            Return Me._housing
         End Get
         Set(ByVal Value As String)
            Me._housing = Value
         End Set
      End Property


      Public Property EpoxyCoated() As Boolean
         Get
            Return Me._epoxyCoated
         End Get
         Set(ByVal Value As Boolean)
            Me._epoxyCoated = Value
         End Set
      End Property


      Public Property Piping() As String
         Get
            Return Me._piping
         End Get
         Set(ByVal Value As String)
            Me._piping = Value
         End Set
      End Property

#End Region


      Public Sub New()

      End Sub

   End Class

End Namespace
