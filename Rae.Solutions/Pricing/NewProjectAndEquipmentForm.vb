imports Rae.Ui.Validation

''' <summary>
''' Form to get project and equipment name from user.
''' </summary>
Public Class NewProjectAndEquipmentForm

   Private validationManager As ValidationManager
   Private projectNameValidationControl As ValidationControl
   Private equipmentNameValidationControl As ValidationControl


#Region " Properties"

   ''' <summary>
   ''' Project name user entered.
   ''' </summary>
   Public ReadOnly Property ProjectName() As String
      Get
         Return Me.projectNameTextBox.Text.Trim
      End Get
   End Property


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
   Private Sub NewProjectAndEquipmentForm_Load(ByVal sender As Object, ByVal e As EventArgs) _
   Handles MyBase.Load
      Me.InitializeValidation()

      Me.projectNameTextBox.Focus()
   End Sub


   ''' <summary>
   ''' Handles ok button's click event. 
   ''' Validates inputs and hides form (if is valid) or alerts user (if is not valid).
   ''' </summary>
   Private Sub okButton_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles okButton.Click

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
   ''' Handles project name textbox's leave event.
   ''' Validates user's project name; alerts user if necessary by flashing icon.
   ''' </summary>
   Private Sub projectNameTextBox_Leave(ByVal sender As Object, ByVal e As EventArgs) _
   Handles projectNameTextBox.Leave
      Me.projectNameValidationControl.Validate()
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
      Me.projectNameValidationControl = New ValidationControl(Me.projectNameTextBox)
      Me.equipmentNameValidationControl = New ValidationControl(Me.equipmentNameTextBox)

      ' constructs validators
      Dim projectNameRequiredValidator As New RequiredValidator(ErrorMessages.Required("Project name"))
      Dim equipmentNameRequiredValidator As New RequiredValidator(ErrorMessages.Required("Equipment name"))

      ' adds validators to validation controls
      projectNameValidationControl.Validators.Add(projectNameRequiredValidator)
      equipmentNameValidationControl.Validators.Add(equipmentNameRequiredValidator)

      ' adds validation controls to validation manager
      Me.validationManager.ValidationControls.Add(projectNameValidationControl)
      Me.validationManager.ValidationControls.Add(equipmentNameValidationControl)

   End Sub

#End Region

End Class