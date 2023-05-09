Imports Text = Rae.Io.Text
Imports RegularExpression = System.Text.RegularExpressions.Regex

Module mValidator

#Region "Blank"

   ''' <summary>
   ''' Indicates whether or not text parameter is blank
   ''' </summary>
   ''' <param name="text">String to test</param>
   ''' <returns>Boolean indicating whether or not text parameter is blank</returns>
   ''' <remarks>Returns true if text parameter is blank.</remarks>
   ''' <history>
   ''' 	[CASEYJ]	6/2/2005	Created
   ''' </history>
   Friend Function IsBlank(ByVal text As String) As Boolean
      Dim _isBlank As Boolean

      If text = "" Or text Is Nothing Then
         _isBlank = True
      Else
         _isBlank = False
      End If

      Return _isBlank
   End Function


   'returns True and sets error message, if control is blank  
   Friend Function ValidateBlankControl(ByRef controlToValidate As Control, ByRef errorControl As ErrorProvider) As Boolean
      If IsBlank(controlToValidate.Text) Then
         errorControl.SetError(controlToValidate, Text.CapitalizeFirstLetter(controlToValidate.Tag) & " is a required field.")
      Else
         errorControl.SetError(controlToValidate, "")
      End If
      Return IsBlank(controlToValidate.Text)
   End Function

#End Region


#Region "Number"

   '* true if decimal or integer
   '* control passed must have text property
   Friend Function ValidateNumericControl(ByRef controlToValidate As Control, ByRef errorControl As ErrorProvider) As Boolean
      If Not IsNumber(controlToValidate.Text) Then
         errorControl.SetError(controlToValidate, _
            Text.CapitalizeFirstLetter(controlToValidate.Tag) & " is a numeric field.")
      Else
         errorControl.SetError(controlToValidate, "")
      End If

      Return IsNumber(controlToValidate.Text)
   End Function


   ''' -----------------------------------------------------------------------------
   ''' <summary>
   ''' Determines if string is a number.
   ''' </summary>
   ''' <param name="text">String that may be a number</param>
   ''' <returns>Boolean indicating whether or not string is a number</returns>
   ''' <remarks>
   ''' Returns true for both integers and decimals. Returns false if parameter
   ''' contains commas.
   ''' </remarks>
   ''' <history>
   ''' 	[CASEYJ]	6/2/2005	Created
   ''' </history>
   ''' -----------------------------------------------------------------------------
   Friend Function IsNumber(ByVal text As String) As Boolean
      Dim _isNumber As Boolean

      '0 or more numbers then 0 or 1 decimal then 0 or more numbers
      If RegularExpression.IsMatch(text, "^\d{0,}\.{0,1}\d{0,}$") _
      And text <> "." Then
         _isNumber = True
      Else
         _isNumber = False
      End If

      Return _isNumber
   End Function

#End Region

   ''' -----------------------------------------------------------------------------
   ''' <summary>
   ''' Indicates if text parameter is an integer.
   ''' </summary>
   ''' <param name="text">String to test whether or not it is an integer</param>
   ''' <returns>Boolean indicating whether or not the text parameter is an integer
   ''' </returns>
   ''' <remarks>
   ''' True indicates text parameter is an integer. False indicates it is not an 
   ''' integer. If text parameter includes commas, false is returned.</remarks>
   ''' <history>
   ''' 	[CASEYJ]	6/2/2005	Created
   ''' </history>
   ''' -----------------------------------------------------------------------------
   Friend Function IsInteger(ByVal text As String) As Boolean
      Dim _isInteger As Boolean

      'checks if all characters are integers
      If RegularExpression.IsMatch(text, "^\d{1,)$") Then
         _isInteger = True
      Else
         _isInteger = False
      End If

      Return _isInteger
   End Function


   ''' -----------------------------------------------------------------------------
   ''' <summary>
   ''' Indicates whether or not text parameter is a decimal value less than one
   ''' </summary>
   ''' <param name="text">String to test</param>
   ''' <returns>Boolean indicating whether or not text parameter is a decimal value
   ''' less than one</returns>
   ''' <remarks>
   ''' Text parameter must be less than one, contain a decimal point and all other
   ''' characters must be numbers.
   ''' </remarks>
   ''' <history>
   ''' 	[CASEYJ]	6/2/2005	Created
   ''' </history>
   ''' -----------------------------------------------------------------------------
   Friend Function IsDecimal(ByVal text As String) As Boolean
      Dim _isDecimal As Boolean

      'checks that number is less than 1
      'checks that there is a decimal point
      'checks that all characters following decimal point or numbers
      If RegularExpression.IsMatch(text, "^0{0,}\.{1}\d{1,}$") Then
         _isDecimal = True
      Else
         _isDecimal = False
      End If

      Return _isDecimal
   End Function

   'Friend Function IsUSCurrency(ByVal text As String) As Boolean
   '   Dim _IsUSCurrency As Boolean = False
   '   'If System.Text.RegularExpressions.Regex.IsMatch(text, "^$(0,1)$
   'End Function


End Module
