Imports Rae.DataAccess.EquipmentOptions
Imports PriceSheetDataSet

Namespace Rae.RaeSolutions.Business.Entities.PriceSheets

class cover_sheet
   function get_file_path(series as string) as string
      
   end function
end class

Class PriceByModelViewer
   Inherits PriceViewer

   private model as string

   'IDEA: New(user, app, version, series, model)
   Sub New(user As String, app As String, version As String, _
           by As FilterBy, criteria As String)
      MyBase.New(user, app, version, by, criteria)
   End Sub

   Overrides Sub Prepare()
      Dim splitFilterCriteria = Criteria.Split(",".ToCharArray())
      series = splitFilterCriteria(0)
      model = splitFilterCriteria(1)

      PriceSheetDataAccess.UseSharedConnections = True
         ops = repository.GetOptionsByModel(series, model)
         commonOps = repository.GetCommonOptions(series)
      PriceSheetDataAccess.UseSharedConnections = False
   End Sub

   Overrides Sub View()
      dim price_report = new rae.reporting.beta.report(report_file.price_sheet)

      dim cover_sheet_file_path = report_file.cover_sheet(series)
      price_report.clear
      price_report.append_document(cover_sheet_file_path)
      price_report.append_elements(new options_elements().create(ops, commonOps))
      
      dim text = new dictionary(of string, string)
      text.add("print_date", DateTime.Now.ToString("M/d/yyyy"))
      text.add("application", app)
      text.add("created_by", user)
      text.add("version", version)

      price_report.set_text(text)
      price_report.show
   End Sub

   Private series As String
   Private ops, commonOps As PriceSheetDataSet.PriceSheetDataTable
End Class

End Namespace