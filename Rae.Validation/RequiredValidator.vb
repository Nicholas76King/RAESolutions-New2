Imports Forms = System.Windows.Forms

Namespace Rae.Validation

   Public Class RequiredValidator
      Inherits Rae.Validation.Validator

#Region " Public Methods"

      Public Sub New(ByVal errorMessage As String)
         MyBase.New(errorMessage)
      End Sub


      Public Overrides Function Validate() As Boolean
         'checks if text property of control to validate is empty
         If Me.ValidationControl.ControlToValidate.Text.Length = 0 Then
            'sets is valid property
            Me.IsValid = False
            'sets error provider's error message
            Me.ValidationControl.ValidationManager.ErrorProvider.SetError( _
                Me.ValidationControl.ControlToValidate, Me.ErrorMessage)
         Else
            Me.IsValid = True
            Me.ValidationControl.ValidationManager.ErrorProvider.SetError( _
                Me.ValidationControl.ControlToValidate, "")
         End If

         Return Me.IsValid
      End Function

#End Region

   End Class

End Namespace