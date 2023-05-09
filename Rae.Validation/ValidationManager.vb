Imports Forms = System.Windows.Forms
Imports System.Collections.Specialized

Namespace Rae.Validation

   Public Class ValidationManager

#Region " Declarations"
      Private _errorProvider As Forms.ErrorProvider
      Private WithEvents _validationControls As Validation.ValidationControlList
      Private _errorMessages As StringCollection
      Private _isValid As Boolean
      Private _errorMessagesSummary As String
#End Region


#Region " Properties"

      ''' -----------------------------------------------------------------------------
      ''' <summary>
      ''' Error provider handles displaying validation icon and pop-ups
      ''' </summary>
      ''' <value>System.Windows.Forms.ErrorProvider control</value>
      ''' <remarks>No remarks
      ''' </remarks>
      ''' <history>
      ''' 	[CASEYJ]	7/29/2005	Created
      ''' </history>
      ''' -----------------------------------------------------------------------------
      Public Property ErrorProvider() As Forms.ErrorProvider
         Get
            Return Me._errorProvider
         End Get
         Set(ByVal Value As System.Windows.Forms.ErrorProvider)
            Me._errorProvider = Value
         End Set
      End Property

      ''' <summary>List of controls that can be validated by the manager
      ''' </summary>
      Public Property ValidationControls() As Validation.ValidationControlList
         Get
            Return Me._validationControls
         End Get
         Set(ByVal Value As Validation.ValidationControlList)
            Me._validationControls = Value
         End Set
      End Property

      ''' <summary>List of error messages generated due to invalid inputs
      ''' </summary>
      Public Property ErrorMessages() As StringCollection
         Get
            Return Me._errorMessages
         End Get
         Set(ByVal Value As StringCollection)
            Me._errorMessages = Value
         End Set
      End Property

      ''' <summary>Boolean indicating whether or not managed controls are valid
      ''' </summary>
      ''' <remarks>Does not execute validation method, just is set after validation runs
      ''' </remarks>
      Public ReadOnly Property IsValid() As Boolean
         Get
            Return Me._isValid
         End Get
      End Property

      ''' <summary>String that summarizes the list of error messages
      ''' </summary>
      Public ReadOnly Property ErrorMessagesSummary() As String
         Get
            Return Me._errorMessagesSummary
         End Get
      End Property

#End Region


#Region " Public Methods"

      ''' <summary>Constructs a validation manager object with error provider parameter
      ''' </summary>
      ''' <param name="errorProvider">Error provider to handle validation
      ''' </param>
      ''' <remarks>Constructs lists and sets error provider.
      ''' </remarks>
      ''' <history>[Casey.Joyce]	6/6/2005	Created
      ''' </history>
      Public Sub New(ByVal errorProvider As Forms.ErrorProvider)
         'constructs validation control list
         Me._validationControls = New Validation.ValidationControlList
         'constructs error message list
         Me._errorMessages = New StringCollection
         'sets error provider
         Me._errorProvider = errorProvider
      End Sub


      ''' <summary>Validates managed controls
      ''' </summary>
      ''' <returns>Boolean indicating whether or not managed controls are valid
      ''' </returns>
      ''' <remarks>Sets error message list and error messages summary properties. 
      ''' Sets is valid property.
      ''' </remarks>
      ''' <history>[Casey.Joyce]	6/6/2005	Created
      ''' </history>
      Public Function Validate() As Boolean
         Dim i, j As Integer

         'clears any previous error messages
         Me._errorMessages.Clear()

         'steps through each managed control
         For j = 0 To Me._validationControls.Count - 1
            'validates each managed control
            If Not Me._validationControls.Item(j).Validate() Then
               'steps through each validation control's error messages
               For i = 0 To Me._validationControls.Item(j).ErrorMessages.Count - 1
                  'adds error message
                  Me._errorMessages.Add( _
                     Me._validationControls.Item(j).ErrorMessages.Item(i))
               Next
            End If
         Next

         'clears error messages summary
         Me._errorMessagesSummary = String.Empty

         If Me._errorMessages.Count = 0 Then
            'if no errors (errorMessages is empty) then is valid
            'sets IsValid property
            Me._isValid = True
         Else
            Me._isValid = False
            'sets error messages summary property
            For i = 0 To Me.ErrorMessages.Count - 1
               Me._errorMessagesSummary &= Me.ErrorMessages.Item(i) & _
                  System.Environment.NewLine
            Next
         End If

         Return Me._isValid
      End Function


      ''' <summary>Handles validation control added to list
      ''' </summary>
      ''' <param name="validationControl">Validation control that was added
      ''' </param>
      ''' <history>[Casey.Joyce]	6/6/2005	Created
      ''' </history>
      Public Sub ValidationControl_Added(ByVal validationControl As Validation.ValidationControl) _
      Handles _validationControls.ValidationControlAdded
         'sets validationControl's validation manager to the manager it was added to
         validationControl.ValidationManager = Me
      End Sub

#End Region

   End Class
End Namespace
