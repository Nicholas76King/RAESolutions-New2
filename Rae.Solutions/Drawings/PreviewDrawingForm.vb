Imports Rae.Reporting.Pdf
Imports rae.solutions

Public Class PreviewDrawingForm

#Region " Public"

   Property DrawingPath As String
      Get
         Return _drawingPath
      End Get
      Set(value As String)
         _drawingPath = value
         drawing = New Rae.Io.FileLocation(_drawingPath)
      End Set
   End Property
   
   Private _drawingPath As String
   Private drawing As Rae.Io.FileLocation

#End Region


   Private Sub form_Load() _
   Handles MyBase.Load
      With eViewer
         .OpenDoc(drawing.FilePath, False, False, False, "")
         log("opened")
         
         .BackgroundColorOverride = True
         .BackgroundColor = 16777215
         .PaperColorOverride = True
         .PaperColor = 16777215
         .BackgroundColorGradient = False
      End With
   End Sub
   
   Private Sub form_Closing(s As Object, e As FormClosingEventArgs) _
   Handles Me.FormClosing
      ' documentation says to use "" for command parameter
      eViewer.CloseActiveDoc("")
      log(" - closed")
   End Sub
   

   Private Sub printMenu_Click() _
   Handles PrintMenuItem.Click, printToolItem.Click
      print()
   End Sub

   Private Sub exitMenu_Click() _
   Handles exitMenuItem.Click
      Me.Close()
   End Sub

   Private Sub saveMenu_Click() _
   Handles saveToolItem.Click, saveMenuItem.Click
      save()
   End Sub

   Private Sub eViewer_OnFinishedLoadingDocument(s As Object, e As AxEModelView._IEModelViewControlEvents_OnFinishedLoadingDocumentEvent) _
   Handles eViewer.OnFinishedLoadingDocument
      'ToolStripStatusLabel1.Text = "Document Loaded Successfully"
      log(" - loaded")
   End Sub


   Private Sub print()
      
      Me.eViewer.Print2(True, "", False, False, False, EModelView.EMVPrintType.eScaleToFit)
   End Sub

   Private Sub save()
      eViewer.ViewOrientation = EModelView.EMVViewOrientation.eMVOrientationZoomToFit

      SaveFileDialog1.Reset()
      SaveFileDialog1.Filter = "eDrawings File (*.edrw)|*.edrw|eDrawings Zip File (*.zip)|*.zip|eDrawings HTML File (*.htm)|*.htm|eDrawings Executable File (*.exe)|*.exe|JPEG Picture File (*.jpg)|*.jpg|DWG File(*.dwg)|*.dwg"
      'Adobe Acrobat File (*.pdf)|*.pdf|
      SaveFileDialog1.FilterIndex = 6
      SaveFileDialog1.RestoreDirectory = False
      SaveFileDialog1.OverwritePrompt = True

      SaveFileDialog1.InitialDirectory = getSavePath
      Select Case SaveFileDialog1.ShowDialog()

         Case Windows.Forms.DialogResult.Abort, _
              Windows.Forms.DialogResult.Cancel, _
              Windows.Forms.DialogResult.No, _
              Windows.Forms.DialogResult.None
            Exit Sub

         Case Else
            Dim saveFilePath As String = SaveFileDialog1.FileName
            If InStr(saveFilePath, "Master") > 0 Then
               ' user is trying to save file in master drawing area - DO NOT ALLOW!
               MessageBox.Show("Please choose a new save location.  Saving a drawing to this" & Chr(10) & _
                               "location may overwrite the master drawings needed to generate" & Chr(10) & _
                               "future drawings.", "Choose Another Location", MessageBoxButtons.OK, MessageBoxIcon.Warning)
               save()
               Exit Sub
            End If
            If saveFilePath > "" Then
               If saveFilePath Like "*.dwg" Then
                  ' remove any existing .edrw file extensions & make sure sName ends with .dwg ext...
                  saveFilePath = Replace(Replace(saveFilePath, ".dwg", ""), ".edrw", "") & ".dwg"
                  ' copy edit file to new location...
                  FileCopy(drawing.FilePath, saveFilePath)
                  'ElseIf saveFilePath Like "*.pdf" Then
                  ' TODO: uncomment after EasyPdf responds to support incident
                  'Dim pdfGenerator As CanGeneratePdf = PdfGeneratorFactory.Create(drawing.FilePath, saveFilePath)
                  'pdfGenerator.Generate()
               Else
                  Me.eViewer.Save(saveFilePath, False, "")
               End If
               ' notify user file has been saved...
               MessageBox.Show("File has been saved.", "Save Complete", MessageBoxButtons.OK)
            End If
      End Select

   End Sub
   
   Private Function getSavePath As String
      Dim savePath As String
      Dim user = AppInfo.User
      
      If user.authority_group = user_group.employee _
      AndAlso AppInfo.network_is_available Then
         savePath = "\\fileserver1a\User library\Sales-RAESolutions Drawings"
      Else
         savePath = drawing.DirectoryPath
      End If
      
      Return savePath
   End Function
   
   Private Sub log(message As String)
      My.Application.Log.WriteEntry(message)
   End Sub

End Class