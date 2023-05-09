Imports System.Collections.Generic
Imports Rae.Io.Text
Imports Rae.Ui.Validation
Imports Rae.DataAccess.EquipmentOptions
Imports Rae.Ui.quickies

''' <summary>Form to get equipment type from user.</summary>
Public Class NewUnknownTypePricingForm

   Private validationManager As ValidationManager
   Private equipmentTypeValidationControl As ValidationControl

   ''' <summary>Equipment type user selected.</summary>
   ReadOnly Property EquipmentType As Business.EquipmentType
      Get
         Dim type = typeComboBox.SelectedItem.ToString
         type = type.Replace(" ", "") ' removes spaces
         
         ' converts to enum
         Dim typeEnum As Business.EquipmentType
         GetEnumValue(Of Business.EquipmentType)(type, typeEnum)
         
         Return typeEnum
      End Get
   End Property


#Region " Private event handlers"

   Private Sub form_Load() Handles MyBase.Load
      initializeValidation()

      instructionLabel.Text = "Choose an " & Strings.Equipment.ToLower & " type to view."

      fillTypesCombobox()

      typeComboBox.Focus()
   End Sub

   Private Sub viewButton_Click() Handles viewButton.Click
      If validationManager.Validate Then
         DialogResult = Windows.Forms.DialogResult.OK
         Hide() ' hides dialog so that code will continue
      Else
         warn(validationManager.ErrorMessagesSummary)
      End If
   End Sub

   Private Sub cancelButton_Click() Handles cancel2Button.Click
      DialogResult = Windows.Forms.DialogResult.Cancel
      Hide()
   End Sub


   ''' <summary>Validates equipment name; alerts user if necessary by flashing icon.</summary>
   Private Sub typeComboBox_Leave() Handles typeComboBox.Leave
      equipmentTypeValidationControl.Validate()
   End Sub

#End Region


#Region " Private helper methods"

   ''' <summary>Initializes validation manager, controls, and validators.</summary>
   Private Sub initializeValidation()
      validationManager = New ValidationManager(Me.newErrorProvider)

      equipmentTypeValidationControl = New ValidationControl(Me.typeComboBox)

      Dim equipTypeReqVal As New RequiredValidator(ErrorMessages.Required("Equipment type"))

      equipmentTypeValidationControl.Validators.Add(equipTypeReqVal)

      validationManager.ValidationControls.Add(equipmentTypeValidationControl)
   End Sub


   ''' <summary>Fills equipment type combobox with equipment types.</summary>
   Private Sub fillTypesCombobox()
      Dim equipTypes = EquipmentDataAccess.RetrieveTypes(AppInfo.Division.ToString.ToUpper)
      
        If AppInfo.User.is_rep And AppInfo.Division = Business.Division.TSI Then
            '      equipTypes.Remove("CondensingUnit")
            equipTypes.Remove("Condenser")
            equipTypes.Remove("FluidCooler")
            equipTypes.Remove("PumpPackage")



        End If
        typeComboBox.Items.Clear()

        ' inserts spaces
        For Each typ As String In equipTypes
            typ = Io.Text.SpaceBeforeUpperCase(typ)
            typeComboBox.Items.Add(typ)
        Next

        typeComboBox.SelectedIndex = 0
    End Sub

    Private Sub instructionLabel_Click(sender As Object, e As EventArgs) Handles instructionLabel.Click

    End Sub

#End Region

End Class