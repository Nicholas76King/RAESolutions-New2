Imports System

Friend Class ProgressForm

   Private Sub ProgressForm_Load(ByVal sender As Object, ByVal e As EventArgs) _
   Handles MyBase.Load
      Me.Timer1.Enabled = True
      Me.Timer1.Start()
   End Sub


   Private Sub ProgressForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
      Me.Timer1.Stop()
   End Sub


   Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) _
   Handles Timer1.Tick
      Static progressValue As Integer = 0
      progressValue += 1
      If progressValue > 100 Then
         progressValue = 1
      End If
      Me.ProgressBar1.Value = progressValue
   End Sub

End Class