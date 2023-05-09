Imports System
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.DataAccess.Projects

''' <summary>Contact manager</summary>
Public Class ContactManagerControl

#Region " Public"


    Public Property ContactLimit As Integer = 999



    Public Sub SetupProposal()
        contactsCollapsableHeader.Visible = False
    End Sub

   Sub Initialize(projectId As item_id)
      projectId_ = projectId
   End Sub


   Sub Initialize(projectId As item_id, contactsToAdd As ContactList)
      Initialize(projectId)
      AddContacts(contactsToAdd)
   End Sub


   Protected projectId_ As item_id
   ''' <summary>
   ''' ID of project that this contact is in
   ''' </summary>
   ReadOnly Property ProjectId As item_id
      Get
         Return projectId_
      End Get
   End Property
   

   ''' <summary>Returns the selected contact</summary>
   ReadOnly Property SelectedContact As Contact
      Get
         If Me.SelectedContactControl Is Nothing Then
            Return Nothing
         Else
            Return Me.SelectedContactControl.SelectedContact
         End If
      End Get
   End Property


   Private selectedContactControl_ As ContactSelectionControl
   ''' <summary>Selected contact control</summary>
   Property SelectedContactControl As ContactSelectionControl
      Get
         Return selectedContactControl_
      End Get
      Set(value As ContactSelectionControl)
         selectControl(value)
      End Set
   End Property


   ''' <summary>
   ''' Contacts added to contact manager.
   ''' </summary>
   ReadOnly Property Contacts() As ContactList
      Get
         Dim contacts_ As New ContactList
         For Each control As ContactSelectionControl In Me.contactsFlowLayoutPanel.Controls
            If control.SelectedContact IsNot Nothing Then
               contacts_.Add(control.SelectedContact)
            End If
         Next
         Return contacts_
      End Get
   End Property


   ''' <summary>
   ''' Add default contact to contact manager.
   ''' </summary>
   Function AddContact() As ContactSelectionControl
      Dim newContact As ContactSelectionControl = ContactSelectionControlFactory.CreateEditor
      AddHandler newContact.Enter, AddressOf contactSelectionControl_Entered
      Me.contactsFlowLayoutPanel.Controls.Add(newContact)

      Return newContact
   End Function

   ''' <summary>
   ''' Add contact for selection.
   ''' </summary>
   ''' <param name="contact">
   ''' Contact to add
   ''' </param>
   Function AddContact(contact As Contact) As ContactSelectionControl
      Dim newContact As ContactSelectionControl = ContactSelectionControlFactory.CreateEditor(contact)
      AddHandler newContact.Enter, AddressOf contactSelectionControl_Entered
      Me.contactsFlowLayoutPanel.Controls.Add(newContact)

      Return newContact
   End Function


   ''' <summary>
   ''' Adds contact list.
   ''' </summary>
   ''' <param name="contacts">
   ''' List of contacts to add
   ''' </param>
   Sub AddContacts(contacts As ContactList)
      For Each contact As Contact In contacts
         AddContact(contact)
      Next
   End Sub


   ''' <summary>
   ''' Remove selected contact.
   ''' </summary>
   ''' <remarks>
   ''' Doesn't error if a contact is not selected.
   ''' </remarks>
   Sub RemoveContact()
      Dim str As String = "Do you wish to delete this contact permanently? If so, choose YES; if you would like to remove this contact from this project, choose NO; if you made this selection in error, choose CANCEL."
      Dim dlg As DialogResult = MessageBox.Show(str, "Remove Contact", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3)
      If dlg = DialogResult.Cancel Then

      Else
         If dlg = DialogResult.Yes Then
            If SelectedContact IsNot Nothing Then
               DataAccess.Projects.ContactsDataAccess.DeleteContact(Me.SelectedContact.Id.value)
            End If
         ElseIf dlg = DialogResult.No Then
            'ProjectContactsDataAccess.Delete(projectId_.Id, SelectedContact.Id.Value)
         End If
         Me.contactsFlowLayoutPanel.Controls.Remove(Me.SelectedContactControl)
      End If

   End Sub
   
   
   ''' <summary>True if control can be editted.</summary>
   Property CanEdit As Boolean
   	Get
   		Return _canEdit
   	End Get
   	Set(value As Boolean)
   	   If value <> _canEdit Then
   		   _canEdit = value
   		   edit(_canEdit)
         End If
   	End Set
   End Property : Private _canEdit As Boolean = True

#End Region


#Region " Private"

   ' button event handlers

    Private Sub addContactToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles addContactToolStripButton.Click
        If Me.contactsFlowLayoutPanel.Controls.Count >= ContactLimit Then Exit Sub
        Me.AddContact()
    End Sub

   Private Sub removeContactToolStripButton_Click(sender As Object, e As EventArgs) _
   Handles removeContactToolStripButton.Click
      Me.RemoveContact
   End Sub


   ' selection event handlers

   Private Sub contactSelectionControl_Entered(sender As Object, e As EventArgs)
      selectControl(sender)
   End Sub
   
   
   Private Sub edit(canEdit As Boolean)
      contactsCollapsableHeader.Visible = canEdit
      ToolStrip1.Visible = canEdit
      
      For Each control As ContactSelectionControl In contactsFlowLayoutPanel.Controls
         control.ActionsVisible = canEdit
         control.roleComboBox.Enabled = canEdit
         control.ContactCompanyControl1.companyComboBox.Enabled = canEdit
         control.ContactCompanyControl1.contactComboBox.Enabled = canEdit
      Next
   End Sub


   Private Sub selectControl(control As ContactSelectionControl)
      If control Is Nothing Then Exit Sub

      Me.unformatPreviousContactSelection(Me.selectedContactControl_)
      Me.selectedContactControl_ = control
      Me.formatNewContactSelection(Me.selectedContactControl_)
   End Sub


   Private Sub formatNewContactSelection(control As ContactSelectionControl)
      With control.GradientPanel1
         .GradientStartColor = Color.FromArgb(255, 255, 128)
         .GradientEndColor = Color.LightYellow
         .BorderWidth = 3
         .BorderColor = Color.Orange
      End With
   End Sub


   Private Sub unformatPreviousContactSelection(control As ContactSelectionControl)
      If control Is Nothing Then Exit Sub

      With control.GradientPanel1
         .GradientStartColor = Color.White
         .GradientEndColor = Color.White
         .BorderWidth = 1
         .BorderColor = Color.LightGray
      End With
   End Sub

#End Region

End Class
