Public Class ProjectRevisionForm

   Private reason_ As String = ""
   Public Property Reason() As String
      Get
         Return reason_
      End Get
      Set(ByVal value As String)
         reason_ = value
      End Set
   End Property

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
      If Trim(Me.txtReason.text) < " " Then
         MessageBox.Show("You must enter a reason for this project revision.", "Reason for Project Revision", MessageBoxButtons.OK)
         Me.txtReason.BackColor = Color.LemonChiffon
         Me.txtReason.Focus()
      Else
         Me.DialogResult = Windows.Forms.DialogResult.OK
         Me.Hide()
      End If
   End Sub

   Private Sub txtReason_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReason.TextChanged
      If Me.txtReason.Text.Trim < " " Then
         Me.txtReason.BackColor = Color.LemonChiffon
      Else
         Me.txtReason.BackColor = Color.White
      End If
   End Sub

   Private Sub ProjectRevisionForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      Me.lblReason.Text = Me.Reason.ToUpper
   End Sub

   Private Sub lblReason_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblReason.Click
      MessageBox.Show(ToolTip1.GetToolTip(sender), "", MessageBoxButtons.OK)
   End Sub
End Class