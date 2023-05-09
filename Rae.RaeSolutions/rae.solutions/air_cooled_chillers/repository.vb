Imports Rae.RaeSolutions.DataAccess
Imports system.data
Imports rae.io.text
Imports rae.data.access

namespace rae.solutions.air_cooled_chillers

public class repository : implements i_repository
   private db as db
   
   sub new()
      db = new db(common.ChillerDbPath)
   end sub
   
   function get_models(series as string) as list(of string) _
   implements i_repository.get_models
      dim sql = str("SELECT [{0}] FROM [{1}] WHERE [{2}]='{3}' ORDER BY [{0}]", _
         table.model, table.table_name, table.series, series)

      dim models = db.get_strings(sql)

      return models
   end function
   
end class

end namespace