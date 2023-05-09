imports rae.reporting
imports rae.reporting.CrystalReports

''' <summary>Report factory used by RAESolutions to create reports</summary>
friend class report_factory

   ''' <summary>Creates a report based on the report file path</summary>
   function create(path as string) as i_report
      return new crystal_report(path)
   end function
   
end class