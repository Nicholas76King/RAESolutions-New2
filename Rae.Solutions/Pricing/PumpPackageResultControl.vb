Public Class PumpPackageResultControl
   
   Public CompleteCommand As command
   Public CancelCommand As command


   Private Sub completeButton_Click() Handles completeButton.Click
      If CompleteCommand IsNot Nothing Then _
         CompleteCommand.Invoke()
   End Sub

   Private Sub cancButton_Click() Handles cancButton.Click
      If CancelCommand IsNot Nothing Then _
         CancelCommand.Invoke()
   End Sub
   
End Class
