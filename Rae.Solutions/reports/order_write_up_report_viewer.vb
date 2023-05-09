Imports Rae.Reporting.CrystalReports

namespace reports

public mustinherit class order_write_up_report_viewer : Inherits base_report_viewer

   sub new(file_path as string)
      mybase.new(file_path)
   end sub

   <parameter> property job as string
   <parameter> property project as string
   <parameter> property project_id as string
   <parameter> property representative as string
   <parameter> property representative_company as string
   <parameter> property architect as string
   <parameter> property architect_company as string
   <parameter> property engineer as string
   <parameter> property engineer_company as string
   <parameter> property contractor as string
   <parameter> property contractor_company as string
   <parameter> property special_instructions as string
   <parameter> property tag as string
   ''' <summary>Version of application</summary>
   <parameter> property version as string
   <Parameter> Property model_number As String
   <parameter> property unit_quantity as string
   <parameter> property base_list_price as string
   ''' <summary>Total options price for a single unit</summary>
   <parameter> property options_price as string
   <parameter> property total_list_price as string
   ''' <summary>PAR multiplier (as decimal)</summary>
   <parameter> property par_multiplier as string
   <parameter> property par_price as string
   <parameter> property warranty as string
   <parameter> property freight as string
   <parameter> property start_up as string
   ''' <summary>Description of other costs</summary>
   <parameter> property other_description as string
   <parameter> property other_price as string
   <parameter> property commission_rate as string
   <parameter> property commission_price as string
   <parameter> property creator as string
   <parameter> property pricing_is_authorized as string

end class

end namespace