Public Class WelcomeWizardForm

   Public Sub continue_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles continueButton.Click
      Me.DialogResult = Windows.Forms.DialogResult.OK
      Me.Close()
   End Sub

   Private Sub cancelButton2_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles cancelButton2.Click
      Me.DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

End Class
