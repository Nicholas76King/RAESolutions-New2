Imports System.IO
Imports O2S.Components

Namespace rae.solutions.drawings


   ''' <summary>
   ''' A pdf containing a drawing (an image).
   ''' </summary>
   ''' <remarks>
   ''' Example: 
   ''' Dim unitDrawingPdf As New DrawingPdf(drawingPath)
   ''' unitDrawingPdf.SavePdf()
   ''' unitDrawingPdf.DeleteDrawing()
   ''' </remarks>
   Public Class DrawingPdf

#Region " Public"

      Protected drawingFilePath_ As String
      ''' <summary>
      ''' The file path to the drawing to generate the pdf from.
      ''' </summary>
      Public ReadOnly Property DrawingFilePath() As String
         Get
            Return Me.drawingFilePath_
         End Get
      End Property


      Protected pdf_ As PDF4NET.PDFDocument
      ''' <summary>
      ''' The pdf document containing the drawing.
      ''' </summary>
      Public ReadOnly Property Pdf() As PDF4NET.PDFDocument
         Get
            Return Me.pdf_
         End Get
      End Property


      ''' <summary>
      ''' Constructs a new drawing pdf containing the drawing at the specified file path.
      ''' </summary>
      ''' <param name="drawingFilePath">
      ''' File path to the drawing to generate the pdf from (could be a jpg).
      ''' </param>
      Public Sub New(ByVal drawingFilePath As String)
         If String.IsNullOrEmpty(drawingFilePath) Then
            Throw New ArgumentNullException("The pdf drawing cannot be created. The drawing path is null or empty.")
         End If
         If Not File.Exists(drawingFilePath) Then
            ' wait for drawing file to be created
            System.Threading.Thread.Sleep(2000)
            If Not File.Exists(drawingFilePath) Then
               Throw New ArgumentException("The pdf drawing cannot be created. There is no drawing at the specified drawing path, " & drawingFilePath & ".")
            End If
         End If

         Me.drawingFilePath_ = drawingFilePath

         Me.pdf_ = Me.createDrawingPdf(drawingFilePath)
      End Sub


      ''' <summary>
      ''' Saves pdf containing drawing to the same directory the drawing was in.
      ''' </summary>
      Public Overloads Sub SavePdf()
         Me.saveDrawingPdfBasedOnDrawingPath(Me.drawingFilePath_)
      End Sub

      ''' <summary>
      ''' Saves pdf containing drawing to the specified file path.
      ''' </summary>
      ''' <param name="filePath">
      ''' File path to save the pdf to (example: c:\drawing.pdf)
      ''' </param>
      Public Overloads Sub SavePdf(ByVal filePath As String)
         Me.saveDrawingPdfToSpecifiedPath(filePath)
      End Sub


      ''' <summary>
      ''' Deletes the drawing used to generate the pdf.
      ''' </summary>
      Public Sub DeleteDrawing()
         Me.deleteFile(Me.drawingFilePath_)
      End Sub

#End Region


#Region " Private methods"

      Private Function createDrawingPdf(ByVal drawingPath As String) As PDF4NET.PDFDocument
         Dim pdf As New PDF4NET.PDFDocument()

         Me.addLetterPageWithDrawing(pdf, drawingPath)

         Return pdf
      End Function


      Private Function saveDrawingPdfBasedOnDrawingPath(ByVal drawingPath As String) As String
         Dim drawingPdfFilePath As String = getDrawingPdfFilePath(drawingPath)

         Me.pdf_.SaveToFile(drawingPdfFilePath)

         Return drawingPdfFilePath
      End Function


      Private Sub saveDrawingPdfToSpecifiedPath(ByVal pdfFilePath As String)
         Me.pdf_.SaveToFile(pdfFilePath)
      End Sub


      Private Function getDrawingPdfFilePath(ByVal drawingPath As String) As String
         Dim pdfDirectory As String = Path.GetDirectoryName(drawingPath)
         Dim drawingFileName As String = Path.GetFileName(drawingPath)
         Dim indexOfLastDot As Integer = drawingFileName.LastIndexOf(".")
         Dim extensionLength As Integer = drawingFileName.Length - indexOfLastDot - 1
         Dim pdfFileName As String = drawingFileName.Remove(indexOfLastDot + 1, extensionLength) & "pdf"
         Dim pdfFilePath As String = Path.Combine(pdfDirectory, pdfFileName)

         Return pdfFilePath
      End Function


      Private Sub addLetterPageWithDrawing(ByRef pdf As PDF4NET.PDFDocument, ByVal drawingPath As String)
         pdf.AddPage()
         pdf.Pages(0).Orientation = PDF4NET.PageOrientation.Landscape
         pdf.Pages(0).Canvas.DrawImage(drawingPath, 30, 47, 730, 730, 0, PDF4NET.Graphics.Shapes.KeepAspectRatio.KeepBoth)
      End Sub


      Private Sub deleteFile(ByVal drawingPath As String)
         If File.Exists(drawingPath) Then
            File.Delete(drawingPath)
         End If
      End Sub

#End Region

   End Class

End Namespace