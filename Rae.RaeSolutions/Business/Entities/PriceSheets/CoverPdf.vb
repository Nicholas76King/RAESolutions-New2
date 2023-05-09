Imports O2S.Components.PDF4NET.Graphics
Imports O2S.Components.PDF4NET

Namespace Rae.RaeSolutions.Business.Entities.PriceSheets

Class CoverPdf
   Inherits Pdf
   
   Sub New(series As String, app As String, version As String)
      MyBase.New( getCoverFilePath( Broaden(series) ))
      
      Dim footer = app & " " & version
      add(footer)
   End Sub
   
   ''' <summary>Prefixes cover file name with series parameter.</summary>
   ''' <param name="series">Series prefix.</param>
   Shared Protected Function getCoverFilePath(series As String) As String
      Dim coverFileName = series & "PriceSheetCover.pdf"
      Dim coverFilePath = Locations.Create().SearchForFile(coverFileName, "Reports")
      If coverFilePath Is Nothing Then _
         Throw New System.ApplicationException("The price sheet cover for " & series & " cannot be found.")

      Return coverFilePath
   End Function
   
   Private Sub add(footer As String)
      Dim font As New PDFFont(FontFace.TimesRoman, 8)
      ' pen weight is zero; otherwise, text looks bold
      Dim pen As New PDFPen(New PDFColor(0, 0, 0), 0)
      Dim blackBrush As New PDFBrush(New PDFColor(0, 0, 0))
      Dim width As Single = 555
      Dim height As Single = 748

      Me.Pages(0).Canvas.DrawText(footer, font, pen, blackBrush, width, height, 0, Shapes.TextAlign.MiddleRight)
   End Sub
   
   Private series As String
   
End Class

End Namespace