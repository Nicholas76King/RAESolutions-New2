Imports System
Imports Rae.RaeSolutions.Business.Entities

Public Class ContactSelectionControl

   ''' <summary>
   ''' The selected contact.
   ''' </summary>
   Public Property SelectedContact() As Contact
      Get
         Dim contact_ As Contact = Me.ContactCompanyControl1.SelectedContact
         If contact_ IsNot Nothing Then
            contact_.Company = Me.ContactCompanyControl1.SelectedCompany
         End If
         Return contact_
      End Get
      Set(ByVal value As Contact)
         If value Is Nothing _
         OrElse value.Company Is Nothing _
         OrElse String.IsNullOrEmpty(value.Company.Role) Then
            Me.roleComboBox.SelectedIndex = -1
         Else
            For i As Integer = 0 To Me.roleComboBox.Items.Count - 1
               If Me.roleComboBox.Items(i).ToString = value.Company.Role Then
                  Me.roleComboBox.SelectedIndex = i
                  Exit For
               End If
            Next

            Me.ContactCompanyControl1.SelectedCompany = value.Company
            Me.ContactCompanyControl1.SelectedContact = value
         End If

      End Set
   End Property


   Private actionsVisible_ As Boolean = True
   ''' <summary>
   ''' Hides or shows panel containing controls with add and edit functionality.
   ''' </summary>
   Public Property ActionsVisible() As Boolean
      Get
         Return actionsVisible_
      End Get
      Set(ByVal value As Boolean)
         If Not actionsVisible_ = value Then
            actionsVisible_ = value
            Me.ContactCompanyControl1.actionsPanel.Visible = actionsVisible_
            If actionsVisible_ Then
               Me.roleComboBox.Width = Me.Width - Me.roleComboBox.Left - 50
            Else
               Me.roleComboBox.Width = Me.Width - Me.roleComboBox.Left - 3
            End If
         End If
      End Set
   End Property



   Private Sub ContactSelectionControl_Load(ByVal sender As Object, ByVal e As EventArgs) _
   Handles Me.Load
      ensureRoleIsSelected()
   End Sub


   Private Sub ensureRoleIsSelected()
      If Me.roleComboBox.SelectedIndex = -1 Then
         Me.roleComboBox.SelectedIndex = 0
      End If
   End Sub


   Private Sub roleComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
   Handles roleComboBox.SelectedIndexChanged
      Me.ContactCompanyControl1.Load(Me.roleComboBox.Text)
   End Sub


   ''' <summary>
   ''' Focuses control when role label or gradient panel is clicked in order help selection functionality.
   ''' </summary>
   Private Sub control_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles roleLabel.Click, GradientPanel1.Click
      Me.Focus()
   End Sub


End Class
