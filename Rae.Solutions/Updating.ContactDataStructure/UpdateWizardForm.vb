Imports System.Collections.Generic
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.Updating.ContactDataStructure

Public Class UpdateWizardForm

   Private projectId As item_id


   Public Sub Initialize(ByVal projectId As item_id)
      Me.projectId = projectId

      Dim oldContacts As ContactList = DataAccess.Projects.ProjectsDataAccess.RetrieveDeficientContacts(projectId.Id)
      ContactConverterControl1.Initialize(oldContacts)
   End Sub


#Region " Private"

   Private Sub contactConverterControl_Completed(ByVal sender As ContactConverterControl, ByVal e As EventArgs) _
   Handles ContactConverterControl1.Completed
      onConvertedAll()
   End Sub

   Private Sub onConvertedAll()
      markProjectAsConverted()
      addContactsToProject()
      thankYou()
      DialogResult = Windows.Forms.DialogResult.OK
      Me.Close()
   End Sub

   Private Function getContactIds() As List(Of Integer)
      Dim contactIds As New List(Of Integer)()

      'Dim repId As NullableValue(Of Integer) = DataAccess.Projects.ProjectsDataAccess.RetrieveRepId(projectId.Id)
      'If repId.HasValue Then
      '   contactIds.Add(repId.Value)
      'End If

      For Each contact As Contact In Me.ContactConverterControl1.Contacts
         contactIds.Add(contact.Id.value)
      Next

      Return contactIds
   End Function

   Private Sub addContactsToProject()
      Dim contactIds As List(Of Integer) = getContactIds()

      For Each contactId As Integer In contactIds
         DataAccess.Projects.ProjectContactsDataAccess.Create(projectId.Id, contactId)
      Next
   End Sub

   Private Sub markProjectAsConverted()
      DataAccess.Projects.ProjectsDataAccess.UpdateContactDataStructure( _
         ContactDataStructureDescription.SingleMapping.ToString(), projectId.Id)
   End Sub

   Private Shared Sub thankYou()
      MessageBox.Show("The project contacts have successfully been converted.")
   End Sub

   'Private Shared Function retrieveMockContactsToConvert() As List(Of DeficientContactMessage)
   '   Dim oldContacts As New List(Of DeficientContactMessage)()

   '   Dim casey As New DeficientContactMessage("Casey Joyce", "RAE Corporation", "Employee")
   '   oldContacts.Add(casey)

   '   Dim sam As New DeficientContactMessage("Sam Jones", "RAE Corporation", "Employee")
   '   oldContacts.Add(sam)

   '   Return oldContacts
   'End Function

#End Region

   Private Sub cancelButton2_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles cancelButton2.Click
      Me.DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

End Class
