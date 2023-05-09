Imports Rae.DataAccess.SpecialOptions
Imports System.Windows.Forms
Imports System.Environment

Namespace Rae.Presentation.SpecialOptions

   Public Class SpecialOptionVerifier

      Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles btnOk.Click
         Me.Verify()
      End Sub


      Private Sub txtCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
      Handles txtCode.KeyUp, txtPrice.KeyUp
         If e.KeyCode = Keys.Enter Then
            Verify()
            e.Handled = True
         End If
      End Sub


      Private Sub Verify()
         Dim message As String
         Dim id As Integer, price As Double

         ' validates user's input
         If Not Me.ValidateInput() Then Exit Sub

         ' grabs id from code (handles prefix "SP" if entered)
         id = CInt(Me.txtCode.Text.Replace("SP", ""))
         ' grabs price (handles currency)
         price = Double.Parse(Me.txtPrice.Text, System.Globalization.NumberStyles.Currency)

         ' verifies code and price match what the salesman authorized
         message = SpecialOptionsDa.Verify(id, price)

         Me.lblMessage.Text = message

         ' sets image in message
         If message Is Nothing Then
            ' shows warning if verification fails
            Me.lblMessage.Image = Me.ImageList1.Images(0)
            Me.lblMessage.Text = "Verification succeeded."
         Else
            ' shows success check if verfication passes
            Me.lblMessage.Image = My.Resources.WarningHS()
         End If
      End Sub


      Private Function ValidateInput() As Boolean
         Dim message As String
         If Me.txtCode.Text = "" Then
            message = "Code is required." & NewLine
         End If
         If Me.txtPrice.Text = "" Then
            message &= "Price is required."
         End If
         If Not String.IsNullOrEmpty(message) Then
            MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
         Else
            Return True
         End If
      End Function


   End Class

End Namespace