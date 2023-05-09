Imports System
Imports System.Windows.Forms
Imports Rae.RaeSolutions.Business


Public Class RenameForm

   Private Sub RenameForm_Load(ByVal sender As Object, ByVal e As EventArgs) _
   Handles Me.Load
      Me.txtNewName.Focus()
   End Sub


   Private Sub btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles btnOk.Click
      If Me.ValidateName(Me.txtNewName.Text) = ValidationStatus.Valid Then
         Me.DialogResult = Windows.Forms.DialogResult.OK
      End If
   End Sub


   Private Function ValidateName(ByVal name As String) As ValidationStatus
      If String.IsNullOrEmpty(name) Then
         MessageBox.Show("Please enter a name.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return ValidationStatus.Invalid
      End If
      Return ValidationStatus.Valid
   End Function

   
End Class