imports Rae.RaeSolutions.DataAccess
imports system.io

namespace Rae.RaeSolutions.Business.Entities.PriceSheets

module report_file
   function report_folder as string
      return path.combine(Common.AppFolderPath, "reports")
   end function

   function price_sheet as string
      return path.combine(report_folder, "price_sheet_template.docx")
   end function

   function cover_sheet(series as string) as string
      return path.combine(report_folder, Broaden(series) & "_cover_sheet.docx")
   end function
end module

end namespace