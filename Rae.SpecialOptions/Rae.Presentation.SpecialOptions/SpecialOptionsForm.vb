Namespace Rae.Presentation.SpecialOptions

   Public Class SpecialOptionsForm

      Private Sub SpecialOptionsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
         Me.SpecialOptionsView1.SpecialOptionsGrid1.ViewAll()
      End Sub

      Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles btnOk.Click
         Me.OnOkClicked(sender)
      End Sub

      Protected Overridable Sub OnOkClicked(ByVal sender As Object)
         Me.Close()
      End Sub

   End Class

End Namespace