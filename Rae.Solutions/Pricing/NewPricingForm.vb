imports Rae.Ui.Validation

''' <summary>
''' Form to get project and equipment name from user.
''' </summary>
Public Class NewPricingForm

   Private validationManager As ValidationManager
   Private equipmentNameValidationControl As ValidationControl


#Region " Properties"

   ''' <summary>
   ''' Equipment name user entered.
   ''' </summary>
   Public ReadOnly Property EquipmentName() As String
      Get
         Return Me.equipmentNameTextBox.Text.Trim
      End Get
   End Property

#End Region


#Region " Private event handlers"

   ''' <summary>
   ''' Handles form's load event.
   ''' </summary>
   Private Sub NewPricingForm_Load(ByVal sender As Object, ByVal e As EventArgs) _
   Handles MyBase.Load
      Me.InitializeValidation()

      Me.instructionLabel.Text = "Choose a name for the " & Strings.Equipment.ToLower & " before saving."

      Me.equipmentNameTextBox.Focus()
   End Sub


   ''' <summary>
   ''' Handles ok button's click event. 
   ''' Validates inputs and hides form (if is valid) or alerts user (if is not valid).
   ''' </summary>
   Private Sub okButton_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles saveButton.Click

      ' are user inputs valid
      If Me.validationManager.Validate Then
         ' user inputs are valid

         Me.DialogResult = Windows.Forms.DialogResult.OK
         ' hides dialog so that code will continue
         Me.Hide()
      Else
         ' user inputs are NOT valid

         ' alerts user of invalid inputs
         Ui.MessageBox.Show(Me.validationManager.ErrorMessagesSummary)
      End If
   End Sub


   ''' <summary>
   ''' Handles cancel button's click event. Cancels and hides form.
   ''' </summary>
   Private Sub cancelButton_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles cancel2Button.Click

      Me.DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Hide()
   End Sub


   ''' <summary>
   ''' Handles equipment name textbox's leave event.
   ''' Validates equipment name; alerts user if necessary by flashing icon.
   ''' </summary>
   Private Sub equipmentNameTextBox_Leave(ByVal sender As Object, ByVal e As EventArgs) _
   Handles equipmentNameTextBox.Leave
      Me.equipmentNameValidationControl.Validate()
   End Sub

#End Region


#Region " Private helper methods"

   ''' <summary>
   ''' Initializes validation manager, controls, and validators.
   ''' </summary>
   Private Sub InitializeValidation()
      ' constructs validation manager
      Me.validationManager = New ValidationManager(Me.newErrorProvider)

      ' constructs validation controls
      Me.equipmentNameValidationControl = New ValidationControl(Me.equipmentNameTextBox)

      ' constructs validators
      Dim equipmentNameRequiredValidator As New RequiredValidator(ErrorMessages.Required("Equipment name"))

      ' adds validators to validation controls
      equipmentNameValidationControl.Validators.Add(equipmentNameRequiredValidator)

      ' adds validation controls to validation manager
      Me.validationManager.ValidationControls.Add(equipmentNameValidationControl)

   End Sub

#End Region

End Class