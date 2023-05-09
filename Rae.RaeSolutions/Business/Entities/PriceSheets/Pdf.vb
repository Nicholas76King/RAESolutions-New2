Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports O2S.Components.PDF4NET
Imports System.Diagnostics
Imports System.IO

Namespace Rae.RaeSolutions.Business.Entities.PriceSheets

Class Pdf
   Inherits PDFDocument

   Sub New()
      MyBase.New()
   End Sub

   Sub New(filePath As String)
      MyBase.New(filePath)
   End Sub

   Sub New(pdfStream As Stream)
      MyBase.New(pdfStream)
   End Sub
   
   ''' <summary>Opens pdf in default viewer.</summary>
   ''' <exception cref="System.ComponentModel.Win32Exception">
   ''' Throws when there is no pdf viewer installed on the computer</exception>
   Sub View()
      Dim file = "PriceSheet" & Date.Now.ToString("yyyyMMddhhmmss") & ".pdf"
      ' TODO: move path logic, shouldn't have to know about bin\Debug location
      Dim folder = Path.Combine(Locations.Create().Application.DirectoryPath.Replace("bin\Debug\", ""), "Reports")

      Dim filePath = Path.Combine(folder, file)

      Save(filePath)
      ' throws Win32Ex if there is no pdf viewer
      Process.Start(filePath)
   End Sub

   Sub Append(pdf As PDFDocument)
      For Each page As PDFPage In pdf.Pages
         AddPage(page)
      Next
   End Sub

   Shared Function [From](report As ReportDocument) As Pdf
      Dim pdfStream = report.ExportToStream(ExportFormatType.PortableDocFormat)
      Dim pdf = New Pdf(pdfStream)

      Return pdf
   End Function

End Class

End Namespace