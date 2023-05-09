Namespace SpecBuilder

   Public Class HazardData

      '6 properties
#Region " Declarations"

      Private _hazard As Boolean
      Private _structuralBase As String
      Private _condenserCasings As String
      Private _condenserFins As String
      Private _controlEnclosure As String
      Private _hazardousDutyClassification As Boolean

#End Region


#Region " Properties"

      Public Property Hazard() As Boolean
         Get
            Return Me._hazard
         End Get
         Set(ByVal Value As Boolean)
            Me._hazard = Value
         End Set
      End Property

      Public Property StructuralBase() As String
         Get
            Return Me._structuralBase
         End Get
         Set(ByVal Value As String)
            Me._structuralBase = Value
         End Set
      End Property

      Public Property CondenserCasings() As String
         Get
            Return Me._condenserCasings
         End Get
         Set(ByVal Value As String)
            Me._condenserCasings = Value
         End Set
      End Property

      Public Property CondenserFins() As String
         Get
            Return Me._condenserFins
         End Get
         Set(ByVal Value As String)
            Me._condenserFins = Value
         End Set
      End Property

      Public Property ControlEnclosure() As String
         Get
            Return Me._controlEnclosure
         End Get
         Set(ByVal Value As String)
            Me._controlEnclosure = Value
         End Set
      End Property

      Public Property HazardousDutyClassification() As Boolean
         Get
            Return Me._hazardousDutyClassification
         End Get
         Set(ByVal Value As Boolean)
            Me._hazardousDutyClassification = Value
         End Set
      End Property

#End Region


      Public Sub New()

      End Sub

   End Class

End Namespace
