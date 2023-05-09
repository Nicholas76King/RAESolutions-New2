Imports rae.data.access
imports Rae.RaeSolutions.DataAccess
Imports rae.io.text

namespace rae.solutions.air_cooled_chillers

public class rep_repository : implements i_repository

   function get_models(series as string) as list(of string) _
   implements i_repository.get_models
      dim db = new db(common.ChillerDbPath)
      dim sql = str("SELECT [{0}] FROM [{1}] WHERE [{2}]='{3}' AND [{4}]=3 ORDER BY [{0}]", _
         table.model, table.table_name, table.series, series, table.authorization)
      
      dim models = db.get_strings(sql)
      
      return models
   end function
   
end class

end namespace