Option Strict On
Option Explicit On 

Imports V = Rae.Validation
Imports Rae.Math.Comparisons

Namespace Rae.Validation

   ''' <summary>Determines whether a value is among the range.
   ''' </summary>
   ''' <remarks>Value is valid when it is greater than or equal to lower limit and less than or equal to upper limit.
   ''' </remarks>
   ''' <history>Created by Casey J. on 10/19/2005
   ''' </history>
   Public Class AmongRangeValidator : Inherits V.RangeValidator


      ''' <summary>Constructs validator with error message and limits.</summary>
      ''' <param name="errorMessage">Message to show if value is out of range.</param>
      ''' <param name="lowerLimit">Lower limit that the value must be greater than or equal to.</param>
      ''' <param name="upperLimit">Upper limit that the value must be less than or equal to.</param>
      Public Sub New(ByVal errorMessage As String, ByVal lowerLimit As Double, ByVal upperLimit As Double)
         MyBase.New(errorMessage)
         'Me.ErrorMessage = errorMessage
         Me._lowerLimit = lowerLimit
         Me._upperLimit = upperLimit
      End Sub


      ''' <summary>Determines whether value is among the range and sets control and error provider accordingly.
      ''' </summary>
      ''' <remarks>Sets IsValid property. Sets ErrorProvider using ErrorMessage.
      ''' </remarks>
      ''' <returns>Returns true when value is among the range. True is returned when the value is equal to either limit.
      ''' </returns>
      ''' <history>Created by Casey J. on 10/19/2005
      ''' </history>
      Public Overrides Function Validate() As Boolean
         Dim valueToValidate As Double

         ' sets value
         valueToValidate = ConvertNull.ToDouble(Me.ValidationControl.ControlToValidate.Text, 0)

         ' determines whether value is in range
         If is_among(valueToValidate, Me.LowerLimit, Me.UpperLimit) Then
            ' value is in range
            ' sets is valid
            Me.IsValid = True
            ' sets error provider
            Me.ValidationControl.ValidationManager.ErrorProvider.SetError(Me.ValidationControl.ControlToValidate, "")
         Else
            ' value is out of range
            Me.IsValid = False
            Me.ValidationControl.ValidationManager.ErrorProvider.SetError(Me.ValidationControl.ControlToValidate, Me.ErrorMessage)
         End If

         Return Me.IsValid
      End Function

   End Class

End Namespace