Imports Forms = System.Windows.Forms
Imports Rae.RaeSolutions.Business.Entities

Namespace Updating.ContactDataStructure

   ''' <summary>
   ''' Form to select a contact on
   ''' </summary>
   Public Class ContactSelectionForm

      ''' <summary>
      ''' The selected contact on the form
      ''' </summary>
      Public ReadOnly Property SelectedContact() As Contact
         Get
            Return Me.ContactSelectionControl1.SelectedContact
         End Get
      End Property

      ''' <summary>
      ''' Initializes contact selector form
      ''' </summary>
      ''' <param name="existingContact">
      ''' An existing contact to select in control
      ''' </param>
      Public Sub Initialize(ByVal existingContact As Contact)
         Me.ContactSelectionControl1.ActionsVisible = False
         Me.ContactSelectionControl1.SelectedContact = existingContact
         Me.ContactSelectionControl1.ContactCompanyControl1.SelectContactBy(existingContact.Name)
      End Sub



      Private Sub cancelButton2_Click(ByVal sender As Object, ByVal e As EventArgs) _
      Handles cancelButton2.Click
         Me.DialogResult = Forms.DialogResult.Cancel
         Me.Hide()
      End Sub

      Private Sub selectButton_Click(ByVal sender As Object, ByVal e As EventArgs) _
      Handles selectButton.Click
         Me.DialogResult = Forms.DialogResult.OK
         Me.Hide()
      End Sub


      '#Region " Testing"

      '      Private Sub testButton_Click(ByVal sender As Object, ByVal e As EventArgs) _
      '      Handles testButton.Click
      '         Me.Initialize(getContact())
      '      End Sub

      '      Private Function getContact() As Contact
      '         Dim casey As New Contact()
      '         casey.Company.Name = "RAE Corporation"
      '         casey.Company.Description = "Employee"
      '         casey.Name.FirstName = "Casey"
      '         casey.Name.LastName = "Joyce"

      '         Return casey
      '      End Function

      '#End Region

   End Class

End Namespace