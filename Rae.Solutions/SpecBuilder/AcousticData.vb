Namespace SpecBuilder

   Public Class AcousticData

#Region " Declarations"

      Private _acoustic As Boolean
      Private _compressors As Boolean
      Private _compressorCovering As String
      Private _compressorSpringIsolator As Boolean
      Private _condenserFans As Boolean
      Private _condenserFanType As String
      Private _condenserShroud As Boolean

#End Region


#Region " Properties"

      Public Property Acoustic() As Boolean
         Get
            Return Me._acoustic
         End Get
         Set(ByVal Value As Boolean)
            Me._acoustic = Value
         End Set
      End Property

      Public Property Compressors() As Boolean
         Get
            Return Me._compressors
         End Get
         Set(ByVal Value As Boolean)
            Me._compressors = Value
         End Set
      End Property

      Public Property CompressorCovering() As String
         Get
            Return Me._compressorCovering
         End Get
         Set(ByVal Value As String)
            Me._compressorCovering = Value
         End Set
      End Property

      Public Property CompressorSpringIsolator() As Boolean
         Get
            Return Me._compressorSpringIsolator
         End Get
         Set(ByVal Value As Boolean)
            Me._compressorSpringIsolator = Value
         End Set
      End Property

      Public Property CondenserFans() As Boolean
         Get
            Return Me._condenserFans
         End Get
         Set(ByVal Value As Boolean)
            Me._condenserFans = Value
         End Set
      End Property

      Public Property CondenserFanType() As String
         Get
            Return Me._condenserFanType
         End Get
         Set(ByVal Value As String)
            Me._condenserFanType = Value
         End Set
      End Property

      Public Property CondenserShroud() As Boolean
         Get
            Return Me._condenserShroud
         End Get
         Set(ByVal Value As Boolean)
            Me._condenserShroud = Value
         End Set
      End Property

#End Region


      Public Sub New()

      End Sub

   End Class

End Namespace
