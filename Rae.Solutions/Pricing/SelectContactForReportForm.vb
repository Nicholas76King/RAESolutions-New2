Imports System
Imports Rae.RaeSolutions.Business.Entities

''' <summary>Lets user select contacts to display in report.</summary>
Public Class SelectContactForReportForm

#Region " Public"

   ''' <summary>The contact the report is to.</summary>
   ReadOnly Property SelectedTo As Contact
      Get
         Return Me.toContactControl.SelectedContact
      End Get
   End Property


   ''' <summary>The contact the report is from.</summary>
   ReadOnly Property SelectedFrom As Contact
      Get
         Return Me.fromContactControl.SelectedContact
      End Get
   End Property


   ''' <summary>Loads project contacts that can be selected.</summary>
   ''' <param name="contacts">Contacts that can be selected</param>
   Sub Load(contacts As ContactList)
      contacts = filterIncomplete(contacts)
      If contacts.Count = 0 Then _
         Throw New ArgumentException("Contacts to select for the report cannot be listed. There are no complete contacts.")
      
      toContactControl.AddContacts(contacts)
      fromContactControl.AddContacts(contacts)

      toContactControl.CanEdit = False
      fromContactControl.CanEdit = False

      selectDefaultFrom
   End Sub

#End Region


#Region " Private"

   Private Function filterIncomplete(contacts As ContactList) As ContactList
      Dim filteredContacts As New ContactList()
      For Each contact As Contact In contacts
         If contact IsNot Nothing AndAlso contact.Company IsNot Nothing Then
            filteredContacts.Add(contact)
         End If
      Next
      Return filteredContacts
   End Function
   
   
   Private Sub selectDefaultFrom()
      fromContactControl.SelectedContactControl = fromContactControl.contactsFlowLayoutPanel.Controls(0)
   End Sub


   Private Sub okButton_Click() _
      Handles okButton.Click
      Me.DialogResult = Windows.Forms.DialogResult.OK
      Me.Close()
   End Sub


   Private Sub cancelButton2_Click() _
   Handles cancelButton2.Click
      Me.DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

#End Region
   
End Class