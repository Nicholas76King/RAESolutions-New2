Public Class DrawingForm
   
   Sub SetDrawing(drawingFilePath As String)
      AxEModelViewControl1.OpenDoc(drawingFilePath, _
         isTemp:=False, _
         promptToSave:=False, _
         readOnly:=False, _
         commandString:="")
      
      log("Drawing opened")
      'System.Threading.Thread.Sleep(3000)
      'AxEModelViewControl1.CloseActiveDoc("")
      'Dim i As Integer = 0
      'While Not isLoaded
      '   i += 1
      '   log("not loaded yet " & i.ToString)
      '   Threading.Thread.Sleep(50)
      'End While
   End Sub

   Private isLoaded As Boolean

   Private Sub drawingLoaded(s As Object, e As AxEModelView._IEModelViewControlEvents_OnFinishedLoadingDocumentEvent) _
   Handles AxEModelViewControl1.OnFinishedLoadingDocument
      isLoaded = True
      log(" - Finished loading")
   End Sub
   
   Private Sub drawing_FailedLoading(s As Object, e As AxEModelView._IEModelViewControlEvents_OnFailedLoadingDocumentEvent) _
   Handles AxEModelViewControl1.OnFailedLoadingDocument
      log(" - Loading failed")
   End Sub
   
   Private Sub form_closing(s As Object, e As FormClosingEventArgs) _
   Handles Me.FormClosing
      AxEModelViewControl1.CloseActiveDoc("")
      log(" - Close drawing")
   End Sub

   Private Sub log(message As String)
      My.Application.Log.WriteEntry(message)
   End Sub
   
End Class