Namespace SpecBuilder

   Public Class EvaporatorData


#Region " Declarations"

      Private _evaporator As String
      Private _pressure As String

#End Region


#Region " Properties"

      Public Property Evaporator() As String
         Get
            Return Me._evaporator
         End Get
         Set(ByVal Value As String)
            Me._evaporator = Value
         End Set
      End Property


      Public Property Pressure() As String
         Get
            Return Me._pressure
         End Get
         Set(ByVal Value As String)
            Me._pressure = Value
         End Set
      End Property

#End Region


      Public Sub New()

      End Sub

   End Class

End Namespace