Imports System.Windows.Forms

Namespace Rae.Presentation.SpecialOptions

   Public Class SpecialOptionsView


#Region " Event handlers"

      Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles btnRefresh.Click
         Me.SpecialOptionsGrid1.ViewAll()
      End Sub

      Private Sub btnSalesman_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles btnSalesman.Click
         Me.ViewByName()
      End Sub

      Private Sub btnCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles btnCode.Click
         Me.ViewById()
      End Sub

      Private Sub txtCode_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) _
      Handles txtCode.KeyUp
         If e.KeyCode = Keys.Enter Then
            Me.ViewById()
            e.Handled = True
         End If
      End Sub

      Private Sub txtSalesman_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) _
      Handles txtSalesman.KeyUp
         If e.KeyCode = Keys.Enter Then
            Me.ViewByName()
            e.Handled = True
         End If
      End Sub

#End Region


      Private Sub ViewById()
         If Me.txtCode.Text.Length > 0 Then
            Me.SpecialOptionsGrid1.ViewById(CInt(Me.txtCode.Text.Replace("SP", "")))
         Else
            MessageBox.Show("Enter special option code.")
         End If
      End Sub


      Private Sub ViewByName()
         If Me.txtSalesman.Text.Length > 0 Then
            ' searches by assigned by first
            Me.SpecialOptionsGrid1.ViewBySalesman(Me.txtSalesman.Text)
            ' if no results
            If Me.SpecialOptionsGrid1.DataGridView1.RowCount = 0 Then
               ' searches by assigned to
               Me.SpecialOptionsGrid1.ViewByAssignedTo(Me.txtSalesman.Text)
            End If
         Else
            MessageBox.Show("Enter the name of the person who authorized the special option.")
         End If
      End Sub


   End Class

End Namespace