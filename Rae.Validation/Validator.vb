Imports Forms = System.Windows.Forms

Namespace Rae.Validation

   Public MustInherit Class Validator
      Implements IValidator

#Region " Declarations"
      Private _errorMessage As String
      Private _validationControl As Validation.ValidationControl
      Private _isValid As Boolean = True
#End Region


#Region " Properties"

      Public Property ErrorMessage() As String Implements IValidator.ErrorMessage
         Get
            Return Me._errorMessage
         End Get
         Set(ByVal Value As String)
            Me._errorMessage = Value
         End Set
      End Property

      Public Property ValidationControl() As Validation.ValidationControl Implements IValidator.ValidationControl
         Get
            Return Me._validationControl
         End Get
         Set(ByVal Value As Validation.ValidationControl)
            Me._validationControl = Value
         End Set
      End Property

      Public Property IsValid() As Boolean Implements IValidator.IsValid
         Get
            Return Me._isValid
         End Get
         Set(ByVal Value As Boolean)
            Me._isValid = Value
         End Set
      End Property

#End Region


#Region " Public Methods"

      Public Sub New()
      End Sub

      Public Sub New(ByVal errorMessage As String)
         Me.ErrorMessage = errorMessage
      End Sub

      Public MustOverride Function Validate() As Boolean _
      Implements IValidator.Validate

#End Region

   End Class

End Namespace
