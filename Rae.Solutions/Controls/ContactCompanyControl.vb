Imports System
Imports System.Collections.Generic
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.DataAccess.Projects


''' <summary>
''' Control to view contacts in a specified company.
''' The companies can be filtered by category (representative, contractor, engineer, etc.)
''' The contact list shows the contacts in the selected company.
''' </summary>
Public Class ContactCompanyControl

#Region " Properties"

   ''' <summary>
   ''' The selected company filters the contacts.
   ''' </summary>
   Public Property SelectedCompany() As Company
      Get
         If Me.companyComboBox.SelectedIndex = -1 Then
            Return Nothing
         Else
            Return CType(Me.companyComboBox.SelectedItem, Company)
         End If
      End Get
      Set(ByVal value As Company)
         If value Is Nothing Then
            companyComboBox.SelectedIndex = -1
            refreshCompanyToolTip()
            Exit Property
         End If

         If value.Id.has_value Then
            For i As Integer = 0 To companyComboBox.Items.Count - 1
               If CType(companyComboBox.Items(i), Company).Id.value = value.Id.value Then
                  If i <> companyComboBox.SelectedIndex Then
                     companyComboBox.SelectedIndex = i
                  Else
                     Me.handleCompanyChanged()
                  End If
                  refreshCompanyToolTip()
                  Exit Property
               End If
            Next
         ElseIf Not String.IsNullOrEmpty(value.Name) Then
            For i As Integer = 0 To companyComboBox.Items.Count - 1
               If CType(companyComboBox.Items(i), Company).Name.ToUpper() = value.Name.ToUpper() Then
                  If i <> companyComboBox.SelectedIndex Then
                     companyComboBox.SelectedIndex = i
                  Else
                     handleCompanyChanged()
                  End If
                  refreshCompanyToolTip()
                  Exit Property
               End If
            Next
         End If

         ' only gets here if company not found
         companyComboBox.SelectedIndex = -1
         refreshCompanyToolTip()
      End Set
   End Property


   ''' <summary>
   ''' The selected contact.
   ''' </summary>
   Public Property SelectedContact() As Contact
      Get
         If Me.contactComboBox.SelectedIndex = -1 Then
            Return Nothing
         Else
            Return CType(Me.contactComboBox.SelectedItem, Contact)
         End If
      End Get
      Set(ByVal value As Contact)
         If value Is Nothing Then
            contactComboBox.SelectedIndex = -1
            refreshContactToolTip()
            Exit Property
         End If

         For i As Integer = 0 To contactComboBox.Items.Count - 1
            Dim contact As Contact = CType(contactComboBox.Items(i), Contact)
            If value.Id.has_value AndAlso contact.Id.value = value.Id.value Then
               contactComboBox.SelectedIndex = i
               ' refreshes view of selected item (otherwise even though the item's object is up to date the view doesn't refresh
               contactComboBox.Items(contactComboBox.SelectedIndex) = contactComboBox.Items(contactComboBox.SelectedIndex)
               Exit Property
            End If
         Next

         contactComboBox.SelectedIndex = -1
         refreshContactToolTip()
      End Set
   End Property


   Protected category_ As String
   ''' <summary>
   ''' Category of the companies to view (ex. representative, contractor, engineer, etc.).
   ''' </summary>
   Public Property Category() As String
      Get
         Return category_
      End Get
      Set(ByVal value As String)
         category_ = value
         loadCompanies(value)
      End Set
   End Property

#End Region


#Region " Public methods"

   ''' <summary>
   ''' Loads companies based on category.
   ''' </summary>
   ''' <param name="category">
   ''' Category to filter companies by (ex. representative, contractor, etc.)
   ''' </param>
   Public Overloads Sub Load(ByVal category As String)
      Me.Category = category
   End Sub

   ''' <summary>
   ''' Loads all companies.
   ''' </summary>
   Public Overloads Sub Load()
      Me.Category = "%"
   End Sub


   ''' <summary>
   ''' Selects contact by name.
   ''' </summary>
   ''' <param name="name">
   ''' Name of contact to select
   ''' </param>
   Public Function SelectContactBy(ByVal name As Name) As Outcome
      If name Is Nothing Then
         Me.contactComboBox.SelectedIndex = -1
         refreshContactToolTip()
      End If
      For i As Integer = 0 To contactComboBox.Items.Count - 1
         Dim contact As Contact = CType(contactComboBox.Items(i), Contact)
         If contact.Name.LastName = name.LastName _
         AndAlso contact.Name.FirstName = name.FirstName Then
            contactComboBox.SelectedIndex = i
            Return Outcome.Succeeded
         End If
      Next

      Return Outcome.Failed
   End Function


   ''' <summary>
   ''' Starts process that allows user to add a new company.
   ''' </summary>
   Public Sub StartUserAddCompany()
      Dim companyForm As New CompanyForm()

      companyForm.Company.Role = category_
      companyForm.Company = companyForm.Company
      companyForm.ShowDialog()

      If companyForm.DialogResult = DialogResult.OK Then
         companyForm.RefreshData()

         Dim newCompany As New Company()
         newCompany.Copy(companyForm.Company)

         newCompany.Role = Me.category_

         newCompany.Save()

         ' adds company to combobox
         Dim newCompanyIndex As Integer = Me.companyComboBox.Items.Add(newCompany)

         ' selects inserted contact
         Me.companyComboBox.SelectedIndex = newCompanyIndex
      End If

      ' closes form (may have only been hidden before)
      If Not companyForm Is Nothing Then companyForm.Close()
   End Sub


   ''' <summary>
   ''' Starts process that allows user to add a new contact.
   ''' </summary>
   ''' <remarks></remarks>
   Public Sub StartUserAddContact()
      If Me.SelectedCompany Is Nothing Then
         Ui.MessageBox.Show("A company must be selected before adding a contact.", MessageBoxIcon.Warning)
         Exit Sub
      End If

      Dim editForm As New EditContactForm()

      editForm.Contact.Company = Me.SelectedCompany
      Dim result As DialogResult = editForm.ShowDialog(Me.ParentForm)

      If result = DialogResult.OK Then
         editForm.RefreshData()

         Dim contact As Contact = editForm.Contact
         contact.Save()

         Me.SelectedCompany = contact.Company
         Me.SelectedContact = contact
      End If
   End Sub


   ''' <summary>
   ''' Starts process that allows user to edit the selected company.
   ''' </summary>
   Public Sub StartUserEditCompany()
      ' determines whether a company is selected
      If Me.SelectedCompany Is Nothing Then
         Ui.MessageBox.Show("Please select the company to edit.", MessageBoxIcon.Information)
         Exit Sub
      End If

      Me.SelectedCompany.OriginalState = Me.SelectedCompany.Clone()
      Dim companyForm As New CompanyForm()
      companyForm.Company = Me.SelectedCompany.Clone()
      companyForm.ShowDialog()

      If companyForm.DialogResult = DialogResult.OK Then
         companyForm.RefreshData()
         Me.SelectedCompany.Copy(companyForm.Company)

         If Me.SelectedCompany.StateChanged Then
            companyComboBox.Items(companyComboBox.SelectedIndex) = companyComboBox.Items(companyComboBox.SelectedIndex) ' refreshes view
            Me.SelectedCompany.Save()
         End If
      End If

      If Not companyForm Is Nothing Then companyForm.Close()
   End Sub


   ''' <summary>
   ''' Starts process to let user edit the selected contact.
   ''' </summary>
   Public Sub StartUserEditContact()
      If Me.SelectedContact Is Nothing Then
         Ui.MessageBox.Show("There is no contact currently selected. Please select the contact to edit.", MessageBoxIcon.Information)
         Exit Sub
      End If

      Dim editForm As New EditContactForm()
      Me.SelectedContact.OriginalState = Me.SelectedContact.Clone()
      editForm.Contact = Me.SelectedContact.Clone()

      editForm.ShowDialog()
      If editForm.DialogResult = DialogResult.OK Then
         editForm.RefreshData()
         Me.SelectedContact.Copy(editForm.Contact)

         If Me.SelectedContact.StateChanged Then
            Me.SelectedContact.Save()  ' save contact first so when contact list is repopulated changed contact will be there
            Dim contactToSelect As Contact = Me.SelectedContact.Clone() ' remembers contact to reselect
            Me.SelectedCompany = Me.SelectedContact.Company ' in case company changed; also if contact list isn't repopulated name changes aren't shown in combobox
            Me.SelectedContact = contactToSelect
         End If
      End If

      ' ensures rep form closes
      If Not editForm Is Nothing Then editForm.Close()
   End Sub

#End Region


#Region " Private methods"

#Region " Event handlers"

   Private Sub companyComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
   Handles companyComboBox.SelectedIndexChanged
      Me.handleCompanyChanged()
   End Sub


   Private Sub contactComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
   Handles contactComboBox.SelectedIndexChanged
      If contactComboBox.SelectedIndex = -1 Then Exit Sub

      refreshContactToolTip()
   End Sub


   Private Sub addCompanyRolloverPictureBox_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles addCompanyRolloverPictureBox.Click
      StartUserAddCompany()
   End Sub


   Private Sub addContactRolloverPictureBox_Click(ByVal sender As Object, ByVal e As EventArgs) _
     Handles addContactRolloverPictureBox.Click
      StartUserAddContact()
   End Sub


   Private Sub editContactRolloverPictureBox_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles editContactRolloverPictureBox.Click
      StartUserEditContact()
   End Sub


   Private Sub editCompanyRolloverPictureBox_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles editCompanyRolloverPictureBox.Click
      StartUserEditCompany()
   End Sub


   ''' <remarks>
   ''' Useful if you want to tell when the label's parent control is selected.
   ''' </remarks>
   Private Sub control_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles companyLabel.Click, contactLabel.Click, contactPanel.Click, actionsPanel.Click
      Me.Focus()
   End Sub

#End Region


   Private Sub loadCompanies(ByVal category As String)
      If category Is Nothing Then
         companyComboBox.Items.Clear()
         contactComboBox.Items.Clear()
         Exit Sub
      End If

      Dim companies As CompanyList = retrieveCompanies(category)
      companyComboBox.Items.Clear()
      If Not (companies Is Nothing OrElse companies.Count = 0) Then
         For Each company As Company In companies
            companyComboBox.Items.Add(company)
         Next
         companyComboBox.SelectedIndex = 0
      Else
         contactComboBox.Items.Clear()
         refreshContactToolTip()
      End If
      refreshCompanyToolTip()
   End Sub


   Private Sub loadContacts(ByVal companyId As Integer)
      Dim contacts As ContactList = retrieveContacts(companyId)
      contactComboBox.Items.Clear()
      If Not (contacts Is Nothing OrElse contacts.Count = 0) Then
         For Each contact As Contact In contacts
            contactComboBox.Items.Add(contact)
         Next
         Me.contactComboBox.SelectedIndex = 0 ' in case index is -1
      End If
      refreshContactToolTip()
   End Sub


   ''' <summary>
   ''' Retrieves companies with contacts of the specified category (ex. Representative, Contractor, etc.)
   ''' </summary>
   ''' <param name="category">
   ''' Category of the company (ex. Representative, Contractor, Engineer, Customer, Architect)
   ''' </param>
   Private Function retrieveCompanies(ByVal category As String) As CompanyList
      Dim companies As CompanyList

      companies = CompaniesDa.RetrieveByDescription(category)

      Return companies
   End Function


   ''' <summary>
   ''' Retrieves contacts in the company with the specified ID.
   ''' </summary>
   ''' <param name="companyId">
   ''' The ID of the company of the contacts being retrieved.
   ''' </param>
   Private Function retrieveContacts(ByVal companyId As Integer) As ContactList
      Dim contacts As ContactList

      contacts = ContactsDataAccess.RetrieveByCompanyId(companyId)

      ' sets category b/c contact info from database didn't include category of company
      For Each contact As Contact In contacts
         contact.Company.Role = Me.category_
         contact.Role = category_
      Next

      Return contacts
   End Function


   Private Sub refreshCompanyToolTip()
      If Me.SelectedCompany Is Nothing Then
         tip.SetToolTip(companyComboBox, "")
      Else
         tip.SetToolTip(companyComboBox, Me.SelectedCompany.Profile)
      End If
   End Sub


   Private Sub refreshContactToolTip()
      If Me.SelectedContact Is Nothing Then
         tip.SetToolTip(contactComboBox, "")
      Else
         tip.SetToolTip(contactComboBox, Me.SelectedContact.Profile)
      End If
   End Sub


   Private Sub handleCompanyChanged()
      If companyComboBox.SelectedIndex = -1 Then
         contactComboBox.Items.Clear()
         Exit Sub
      End If

      refreshCompanyToolTip()

      loadContacts(Me.SelectedCompany.Id.value)
   End Sub

#End Region

End Class
