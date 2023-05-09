Imports DocumentFormat.OpenXml
Imports System
Imports Rae.DataAccess.EquipmentOptions
Imports PriceSheetDataSet
Imports System.Linq

Namespace Rae.RaeSolutions.Business.Entities.PriceSheets

Class PriceBySeriesViewer
   Inherits PriceViewer

   Sub New(user As String, app As String, version As String, _
           by As FilterBy, criteria As String)
      MyBase.New(user, app, version, by, criteria)
   End Sub

   Overrides Sub Prepare()
      PriceSheetDataAccess.UseSharedConnections = True
         Dim ops = repository.GetOptionsBySeries(Criteria)
         Dim commonOps = repository.GetCommonOptions(Criteria)
      PriceSheetDataAccess.UseSharedConnections = False

      series_ops.Add(New Series_Options_Assoc(Criteria, ops, commonOps))
   End Sub

   Overrides Sub View()
      Dim pages = New PageArranger(repository, Me.series_ops)
      pages.Arrange()

      ' converts pages to pdfs
      '
      'Dim addition As Pdf
      'Dim final = New Pdf()

      dim price_report = new rae.reporting.beta.report(report_file.price_sheet)
      price_report.clear

      For Each page In pages.Series_PageType_Assocs
         If page.PageType = PageType.Cover Then
            'addition = New CoverPdf(page.Series, App, Version)

            price_report.append_document( report_file.cover_sheet(page.series) )
         ElseIf page.PageType = PageType.PriceSheets Then
            ' price by series only has one series, so it's always the first
            Dim ops As PriceSheetDataTable() = {series_ops(0).Options, series_ops(0).CommonOptions}
            'Dim rpt = New PriceSheetReport(Report, ops, App, User, Version)
            'addition = Pdf.From(rpt)

            dim elements = new options_elements().create(series_ops(0).options, series_ops(0).commonOptions)
            price_report.append_elements(elements)
         Else
            Throw New ApplicationException()
         End If

         'final.Append(addition)
      Next

      dim text = new dictionary(of string, string)
      text.add("print_date", DateTime.Now.ToString("M/d/yyyy"))
      text.add("application", app)
      text.add("created_by", user)
      text.add("version", version)

      price_report.set_text(text)
      'final.View()
      price_report.show
   End Sub

   Private series_ops As New Series_Options_List

End Class

End Namespace