Imports Rae.Reporting.CrystalReports

namespace reports

public class chiller_order_write_up_report_viewer : inherits order_write_up_report_viewer

   sub new()
      mybase.new(file_paths.chiller_order_write_up_report_file_path)
   end sub

   <parameter> property division as string
   <parameter> property ambient_temperature as string
   <parameter> property gpm as string
   <parameter> property entering_temperature as string
   <parameter> property leaving_temperature as string
   <parameter> property glycol as string
   <parameter> property glycol_percentage as string
   <parameter> property unit_voltage as string
   <parameter> property control_voltage as string
   <parameter> property title as string
   <parameter> property ambient_label as string

end class

end namespace