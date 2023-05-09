Namespace SpecBuilder

   Public Class OtherData

      '3 properties
#Region " Declarations"
      Private _watersideEconomizer As Boolean
      Private _additionalWarranty As Boolean
      Private _supervisedStartup As Boolean
#End Region


#Region " Properties"
      Public Property WatersideEconomizer() As Boolean
         Get
            Return Me._watersideEconomizer
         End Get
         Set(ByVal Value As Boolean)
            Me._watersideEconomizer = Value
         End Set
      End Property

      Public Property AdditionalWarranty() As Boolean
         Get
            Return Me._additionalWarranty
         End Get
         Set(ByVal Value As Boolean)
            Me._additionalWarranty = Value
         End Set
      End Property

      Public Property SupervisedStartup() As Boolean
         Get
            Return Me._supervisedStartup
         End Get
         Set(ByVal Value As Boolean)
            Me._supervisedStartup = Value
         End Set
      End Property
#End Region


      Public Sub New()

      End Sub

   End Class

End Namespace
