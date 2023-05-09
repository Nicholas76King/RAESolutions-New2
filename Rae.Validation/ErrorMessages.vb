Namespace Rae.Validation
   '
   Public Class ErrorMessages

      ''' <summary>Message indicating field is required
      ''' </summary>
      ''' <param name="controlName">Name to identify the control being validated
      ''' </param>
      ''' <value>String indicating field is required
      ''' </value>
      ''' <history>[Casey.Joyce]	6/6/2005	Created
      ''' </history>
      Public Shared ReadOnly Property Required(ByVal controlName As String) As String
         Get
            Return (controlName & " is required.")
         End Get
      End Property

      Public Shared ReadOnly Property Number(ByVal controlName As String) As String
         Get
            Return (controlName & " must be a number.")
         End Get
      End Property

      Public Shared ReadOnly Property PositiveNumber(ByVal controlName As String) _
      As String
         Get
            Return (controlName & " must be a positive number.")
         End Get
      End Property

      Public Shared ReadOnly Property [Integer](ByVal controlName As String) _
      As String
         Get
            Return (controlName & " must be an integer.")
         End Get
      End Property

      Public Shared ReadOnly Property PositiveInteger(ByVal controlName As String) _
      As String
         Get
            Return (controlName & " must be a positive integer.")
         End Get
      End Property

      Public Shared ReadOnly Property Range(ByVal controlName As String, ByVal lowerLimit As Double, _
      ByVal upperLimit As Double) As String
         Get
            Return (controlName & " must be in range " & lowerLimit.ToString & " to " & upperLimit.ToString)
         End Get
      End Property

   End Class

End Namespace
