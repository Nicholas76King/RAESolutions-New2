Imports Forms = System.Windows.Forms

Namespace Rae.Validation

   Public Class RegularExpressionValidator
      Inherits Rae.Validation.Validator

      Private _regularExpression As String

      Public Property RegularExpression() As String
         Get
            Return Me._regularExpression
         End Get
         Set(ByVal Value As String)
            Me._regularExpression = Value
         End Set
      End Property


#Region " Public Methods"

      ''' <summary>Constructs regular expression validator object
      ''' </summary>
      ''' <param name="errorMessage">Error message to show, if control is not valid
      ''' </param>
      ''' <param name="regularExpression">Regular expression used to check validity
      ''' </param>
      ''' <history>[Casey.Joyce]	6/6/2005	Created
      ''' </history>
      Public Sub New(ByVal errorMessage As String, ByVal regularExpression As String)
         MyBase.New(errorMessage)
         Me._regularExpression = regularExpression
      End Sub


      ''' <summary>Validates control using regular expression and returns IsValid property
      ''' </summary>
      ''' <returns>Boolean indicating whether or not control is valid
      ''' </returns>
      ''' <remarks>Sets error provider's error property and is valid property
      ''' </remarks>
      ''' <history>[Casey.Joyce]	6/6/2005	Created
      ''' </history>
      Public Overrides Function Validate() As Boolean
         'checks control to validate's text property matches the regular expression
         If System.Text.RegularExpressions.Regex.IsMatch( _
         Me.ValidationControl.ControlToValidate.Text, Me.RegularExpression) Then
            'sets IsValid property
            Me.IsValid = True
            'sets error providers error property
            Me.ValidationControl.ValidationManager.ErrorProvider.SetError(Me.ValidationControl.ControlToValidate, "")
         Else
            Me.IsValid = False
            Me.ValidationControl.ValidationManager.ErrorProvider.SetError( _
               Me.ValidationControl.ControlToValidate, Me.ErrorMessage)
         End If

         Return Me.IsValid
      End Function

#End Region

   End Class

End Namespace
