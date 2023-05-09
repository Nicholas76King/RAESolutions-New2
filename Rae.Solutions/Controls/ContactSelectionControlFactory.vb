Imports Rae.RaeSolutions.Business.Entities


''' <summary>
''' Creates contact selection controls.
''' </summary>
Public Class ContactSelectionControlFactory


   Private Sub New()
   End Sub


   ''' <summary>
   ''' Creates contact selection control with a default contact displayed.
   ''' </summary>
   Public Overloads Shared Function CreateEditor() As ContactSelectionControl
      Dim control As New ContactSelectionControl()

      Return control
   End Function


   ''' <summary>
   ''' Creates contact selection control with the specified contact displayed.
   ''' </summary>
   ''' <param name="contact">
   ''' Contact to display
   ''' </param>
   Public Overloads Shared Function CreateEditor(ByVal contact As Contact) As ContactSelectionControl
      Dim control As ContactSelectionControl = CreateEditor()

      control.SelectedContact = contact

      Return control
   End Function


   ''' <summary>
   ''' Creates contact selection control with the specified contact selected. The selected contact cannot be changed or editted.
   ''' </summary>
   ''' <param name="contact">
   ''' Contact to display.
   ''' </param>
   Public Shared Function CreateDisplayOnly(ByVal contact As Contact) As ContactSelectionControl
      Dim control As New ContactSelectionControl()

      control.SelectedContact = contact

      ' disables selection controls so user can't change selection
      control.roleComboBox.Enabled = False
      control.ContactCompanyControl1.companyComboBox.Enabled = False
      control.ContactCompanyControl1.contactComboBox.Enabled = False

      ' hides action controls so user can't add or edit contacts
      control.ActionsVisible = False

      Return control
   End Function


End Class
