Imports System.IO
Imports PriceSheetDataSet
Imports Rae.DataAccess.EquipmentOptions
Imports Rae.RaeSolutions.DataAccess

Namespace Rae.RaeSolutions.Business.Entities.PriceSheets

Class PriceByDivisionViewer
   Inherits PriceViewer

   Sub New(user As String, app As String, version As String, _
           by As FilterBy, criteria As String)
      MyBase.New(user, app, version, by, criteria)
   End Sub

   Overrides Sub Prepare()
      Dim seriesList = repository.GetSeriesIn(Criteria)


            ' If seriesList.Contains("NSB") Then seriesList.Remove("NSB")
            '   If seriesList.Contains("NDB") Then seriesList.Remove("NDB")
            If seriesList.Contains("RS") Then seriesList.Remove("RS")


      PriceSheetDataAccess.UseSharedConnections = True
         For Each series In seriesList
            Dim ops = repository.GetOptionsBySeries(series)
            Dim commonOps = repository.GetCommonOptions(series)
            series_ops.Add(series, ops, commonOps)
         Next
      PriceSheetDataAccess.UseSharedConnections = False
   End Sub

   Overrides Sub View()
      Dim pages = New PageArranger(repository, series_ops)
      pages.Arrange()

      dim price_report = new rae.reporting.beta.report(report_file.price_sheet)
      price_report.clear

      'Dim final = New Pdf()
      'Dim addition As Pdf
      dim first_time = true

      For Each page In pages.Series_PageType_Assocs
         If page.PageType = PageType.Cover Then
            'addition = New CoverPdf(page.Series, App, Version)
            if not first_time then
               price_report.append_page_break
            end if
            first_time = false
            price_report.append_document( report_file.cover_sheet(page.series) )
         ElseIf page.PageType = PageType.PriceSheets Then
            Dim assoc = series_ops.OptionsFor(page.Series)
            'Dim ops As PriceSheetDataTable() = {assoc.Options, assoc.CommonOptions}
            'Dim rpt = New PriceSheetReport(Report, ops, App, User, Version)
            'addition = Pdf.From(rpt)

            price_report.append_elements(new options_elements().create(assoc.options, assoc.commonOptions) )
         Else
            Throw New System.ApplicationException()
         End If
         'final.Append(addition)
      Next
      'final.View()
      dim text = new dictionary(of string, string)
      text.add("print_date", DateTime.Now.ToString("M/d/yyyy"))
      text.add("application", app)
      text.add("created_by", user)
      text.add("version", version)

      price_report.set_text(text)
      price_report.show
   End Sub

   Private series_ops As New Series_Options_List
End Class

End Namespace