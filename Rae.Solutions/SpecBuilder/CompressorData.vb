Namespace SpecBuilder

   Public Class CompressorData

#Region " Declarations"

      Private _compressor As String
      Private _refrigerant As String
      Private _cylinderLoading As Boolean
      Private _cylinderLoadingOption As String
      Private _capacitySlideValveModulation As String

#End Region


#Region " Properties"

      Public Property Compressor() As String
         Get
            Return Me._compressor
         End Get
         Set(ByVal Value As String)
            Me._compressor = Value
         End Set
      End Property


      Public Property Refrigerant() As String
         Get
            Return Me._refrigerant
         End Get
         Set(ByVal Value As String)
            Me._refrigerant = Value
         End Set
      End Property


      Public Property CylinderLoading() As Boolean
         Get
            Return Me._cylinderLoading
         End Get
         Set(ByVal Value As Boolean)
            Me._cylinderLoading = Value
         End Set
      End Property


      Public Property CylinderLoadingOption() As String
         Get
            Return Me._cylinderLoadingOption
         End Get
         Set(ByVal Value As String)
            Me._cylinderLoadingOption = Value
         End Set
      End Property


      Public Property CapacitySlideValveModulation() As String
         Get
            Return Me._capacitySlideValveModulation
         End Get
         Set(ByVal Value As String)
            Me._capacitySlideValveModulation = Value
         End Set
      End Property

#End Region


      Public Sub New()

      End Sub


   End Class

End Namespace
