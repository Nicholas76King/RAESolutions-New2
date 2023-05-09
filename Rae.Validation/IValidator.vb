Namespace Rae.Validation

   Public Interface IValidator
      Property ValidationControl() As Validation.ValidationControl
      Property ErrorMessage() As String
      Property IsValid() As Boolean

      Function Validate() As Boolean
   End Interface

End Namespace
