Imports Forms = System.Windows.Forms
Imports Validation = RAE.Validation
Imports System.Collections.Specialized

Namespace Rae.Validation

   Public Class ValidationControl


#Region " Declarations"
      Private _controlToValidate As Forms.Control
      Private _isValid As Boolean
      Private _errorMessages As StringCollection
      Private _validationManager As Validation.ValidationManager
      Private WithEvents _validators As Validation.ValidatorList
#End Region


#Region " Properties"

      Public Property ControlToValidate() As Forms.Control
         Get
            Return Me._controlToValidate
         End Get
         Set(ByVal Value As Forms.Control)
            Me._controlToValidate = Value
         End Set
      End Property

      Public Property IsValid() As Boolean
         Get
            Return Me._isValid
         End Get
         Set(ByVal Value As Boolean)
            Me._isValid = Value
         End Set
      End Property

      Public Property ErrorMessages() As StringCollection
         Get
            Return Me._errorMessages
         End Get
         Set(ByVal Value As StringCollection)
            Me._errorMessages = Value
         End Set
      End Property

      Public Property ValidationManager() As ValidationManager
         Get
            Return Me._validationManager
         End Get
         Set(ByVal Value As Validation.ValidationManager)
            Me._validationManager = Value
         End Set
      End Property

      Public Property Validators() As ValidatorList
         Get
            Return Me._validators
         End Get
         Set(ByVal Value As ValidatorList)
            Me._validators = Value
         End Set
      End Property

#End Region


#Region " Events"
      ''' <summary>Allows custom validation to run besides validators
      ''' </summary>
      ''' <remarks>Add a message to the error message list if the control is found to be invalid.
      ''' Event is raised after the validators Validate() method is executed.
      ''' </remarks>
      Public Event Validating(ByVal sender As RAE.Validation.ValidationControl)
#End Region

#Region " Public methods"

      ''' <summary>Constructs a new validation control for the controlToValidate 
      ''' parameter
      ''' </summary>
      ''' <param name="controlToValidate">Control to validate
      ''' </param>
      ''' <remarks>Also constructs lists
      ''' </remarks>
      ''' <history>[Casey.Joyce]	6/6/2005	Created
      ''' </history>
      Public Sub New(ByVal controlToValidate As Forms.Control)
         'constructs error messages
         Me._errorMessages = New StringCollection
         'constructs validator list so validators can be added w/out null exception
         Me._validators = New ValidatorList
         'sets control to validate
         Me._controlToValidate = controlToValidate
      End Sub


      ''' <summary>Validates control and returns is valid property
      ''' </summary>
      ''' <returns>Boolean indicating whether or not control is valid
      ''' </returns>
      ''' <remarks>Sets IsValid property. Sets error provider's error message.
      ''' Validates each of the control's validators.
      ''' </remarks>
      ''' <history>[Casey.Joyce]	6/6/2005	Created
      ''' </history>
      Public Function Validate() As Boolean
         Dim i As Integer

         'clears previous error message
         Me._errorMessages.Clear()

         ' steps through each validator for this control
         For i = 0 To Me._validators.Count - 1
            ' checks if validator is valid
            If Not Me._validators.Item(i).Validate() Then
               ' adds error message
               Me._errorMessages.Add(Me._validators.Item(i).ErrorMessage)
            End If
         Next

         ' raises event so that other custom validation can execute
         RaiseEvent Validating(Me)

         If Me._errorMessages.Count = 0 Then
            ' sets is valid property
            Me._isValid = True
            ' clears errors
            Me.ValidationManager.ErrorProvider.SetError(Me.ControlToValidate, "")
         Else
            Me._isValid = False
            ' sets error provider
            Me.ValidationManager.ErrorProvider.SetError(Me.ControlToValidate, Me._errorMessages.Item(0))
         End If

         Return Me._isValid
      End Function


      ''' <summary>Handles validator added to list
      ''' </summary>
      ''' <param name="validator">Validator that was added
      ''' </param>
      ''' <history>[Casey.Joyce]	6/6/2005	Created
      ''' </history>
      Public Sub Validator_Added(ByVal validator As Validation.Validator) _
      Handles _validators.ValidatorAdded
         'sets validator's validation control to the control it was added to
         validator.ValidationControl = Me
      End Sub

#End Region

   End Class

End Namespace
