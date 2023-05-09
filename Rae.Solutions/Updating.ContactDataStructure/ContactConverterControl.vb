Imports System.Windows.Forms
Imports System.Collections.Generic
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.Updating.ContactDataStructure

''' <summary>
''' Control to display contact name, company and role and let user create or select the contact.
''' </summary>
Public Class ContactConverterControl

   Private convertedContacts As New ContactList()


#Region " Events"

   ''' <summary>
   ''' Occurs after all contacts have been converted.
   ''' </summary>
   Public Event Completed As EventHandler(Of ContactConverterControl, EventArgs)

   ''' <summary>
   ''' Raises Completed event.
   ''' </summary>
   ''' <param name="e">
   ''' Event arguments to pass in event.
   ''' </param>
   Protected Overridable Sub OnCompleted(ByVal e As EventArgs)
      contacts_ = convertedContacts
      If Me.CompletedEvent IsNot Nothing Then
         RaiseEvent Completed(Me, e)
      End If
   End Sub

#End Region


#Region " Public"

   Protected contacts_ As ContactList
   ''' <summary>
   ''' List of converted contacts to add to project.
   ''' </summary>
   Public ReadOnly Property Contacts() As ContactList
      Get
         Return contacts_
      End Get
   End Property


   ''' <summary>
   ''' Initializes contact converter control with contacts that need to be converted.
   ''' </summary>
   ''' <param name="contacts">
   ''' Contacts that need to be converted.
   ''' </param>
   Public Sub Initialize(ByVal contacts As ContactList)
      contacts_ = New ContactList()
      convertedImage = DirectCast(ImageList1.Images(0), Bitmap)
      populateGrid(contacts)
   End Sub

#End Region


#Region " Private"

   Private convertedImage As Bitmap
   Private notConvertedImage As Bitmap = My.Resources.Warning
   Private numUnconverted As Integer


   Private Sub checkIfAllContactsAreConverted(ByVal numUnconverted As Integer)
      If numUnconverted = 0 Then
         OnCompleted(EventArgs.Empty)
      End If
   End Sub

   Private Sub populateGrid(ByVal contacts As ContactList)
      numUnconverted = contacts.Count
      checkIfAllContactsAreConverted(numUnconverted)

      For Each contact As Contact In contacts
         addContactToGrid(contact)
      Next
   End Sub


   Private Sub addContactToGrid(ByVal contact As Contact)
      Dim rowIndex As Integer = Me.contactGrid.Rows.Add()
      With Me.contactGrid.Rows(rowIndex)
         .Cells(Me.IsConvertedColumn.Name).Value = notConvertedImage
         .Cells(Me.IsConvertedColumn.Name).ToolTipText = "This contact has not been converted."
         .Cells(Me.CompanyNameColumn.Name).Value = contact.Company.Name
         .Cells(Me.ContactNameColumn.Name).Value = contact.Name.FullName
         .Cells(Me.RoleColumn.Name).Value = contact.Company.Role
         .Cells(Me.CreateColumn.Name).Value = "Create"
         .Cells(Me.CreateColumn.Name).ToolTipText = "Click to create a new profile for this person."
         .Cells(Me.OrColumn.Name).Value = "-or-"
         .Cells(Me.SelectColumn.Name).Value = "Find"
         .Cells(Me.SelectColumn.Name).ToolTipText = "Click to select this person's existing profile."
      End With
   End Sub


   Private Function getContactFromGrid(ByVal rowIndex As Integer) As Contact
      Dim contact As New Contact()
      With Me.contactGrid.Rows(rowIndex)
         contact.Name.FullName = .Cells(Me.ContactNameColumn.Index).Value
         contact.Company.Name = .Cells(Me.CompanyNameColumn.Index).Value
         contact.Company.Role = .Cells(Me.RoleColumn.Index).Value
      End With
      Return contact
   End Function


   Private Sub createContact(ByVal e As DataGridViewCellEventArgs)
      Dim contact As Contact = getContactFromGrid(e.RowIndex)

      Dim contactForm As New EditContactForm()
      contactForm.Contact = contact
      If contactForm.ShowDialog() = DialogResult.OK Then
         contactForm.RefreshData()
         Dim newContact As Contact = contactForm.Contact
         newContact.Save()
         convertedContacts.Add(newContact)

         checkContact(e.RowIndex, newContact)
         numUnconverted -= 1
         checkIfAllContactsAreConverted(numUnconverted)
      End If
   End Sub


   Private Sub selectContact(ByVal e As DataGridViewCellEventArgs)
      Dim contact As Contact = getContactFromGrid(e.RowIndex)

      Dim selectionForm As New ContactSelectionForm()
      selectionForm.Initialize(contact)
      If selectionForm.ShowDialog() = DialogResult.OK Then
         Dim newContact As Contact = selectionForm.SelectedContact
         convertedContacts.Add(newContact)
         checkContact(e.RowIndex, newContact)
         numUnconverted -= 1
         checkIfAllContactsAreConverted(numUnconverted)
      End If
   End Sub


   Private Sub checkContact(ByVal rowIndex As Integer, ByVal contact As Contact)
      With Me.contactGrid.Rows(rowIndex)
         .Cells(IsConvertedColumn.Name).Value = convertedImage
         .Cells(IsConvertedColumn.Name).ToolTipText = "Contact has been converted."
         .Cells(SelectColumn.Name) = New DataGridViewTextBoxCell()
         .Cells(OrColumn.Name).Value = ""
         .Cells(CreateColumn.Name) = New DataGridViewTextBoxCell()
      End With

      contacts_.Add(contact)
   End Sub


   Private Sub contactGrid_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) _
   Handles contactGrid.CellContentClick
      Select Case e.ColumnIndex
         Case Me.CreateColumn.Index
            createContact(e)
         Case Me.SelectColumn.Index
            selectContact(e)
         Case Else
            'ignore
      End Select
   End Sub

#End Region

End Class
