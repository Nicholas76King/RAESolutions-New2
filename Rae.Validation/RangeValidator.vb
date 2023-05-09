Option Strict On
Option Explicit On 


Imports V = Rae.Validation


Namespace Rae.Validation

   Public MustInherit Class RangeValidator : Inherits V.Validator


      Public Sub New(ByVal errorMessage As String)
         MyBase.New(errorMessage)
      End Sub


      Protected _lowerLimit As Double
      Protected _upperLimit As Double


      Public Property LowerLimit() As Double
         Get
            Return Me._lowerLimit
         End Get
         Set(ByVal Value As Double)
            Me._lowerLimit = Value
         End Set
      End Property

      Public Property UpperLimit() As Double
         Get
            Return Me._upperLimit
         End Get
         Set(ByVal Value As Double)
            Me._upperLimit = Value
         End Set
      End Property

   End Class

End Namespace
