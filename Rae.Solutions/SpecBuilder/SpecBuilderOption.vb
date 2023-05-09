Namespace SpecBuilder

   Public Class SpecBuilderOption

      Private _isOption As Boolean
      Private _standardValue As Object
      Private _explanation As String


      Public Property IsOption() As Boolean
         Get
            Return Me._isOption
         End Get
         Set(ByVal Value As Boolean)
            Me._isOption = Value
         End Set
      End Property


      Public Property StandardValue() As Object
         Get
            Return Me._standardValue
         End Get
         Set(ByVal Value As Object)
            Me._standardValue = Value
         End Set
      End Property


      Public Property Explanation() As String
         Get
            Return Me._explanation
         End Get
         Set(ByVal Value As String)
            Me._explanation = Value
         End Set
      End Property


      Public Sub New()

      End Sub


      Public Sub New(ByVal isOption As Boolean, ByVal standardValue As Object, _
      ByVal explanation As String)
         Me._isOption = isOption
         Me._standardValue = standardValue
         Me._explanation = explanation
      End Sub

   End Class

End Namespace
