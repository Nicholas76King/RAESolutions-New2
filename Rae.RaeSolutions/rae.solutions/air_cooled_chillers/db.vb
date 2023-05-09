imports system.data
Imports Rae.RaeSolutions.DataAccess

namespace rae.data.access

class db
   private db_path as string
   
   sub new(db_path as string)
      me.db_path = db_path
   end sub
   
   function get_strings(sql as string) as list(of string)
      dim connection = create_connection()
      dim strings = new list(of string)
      dim command = connection.createcommand()
      command.commandtext = sql
      dim reader as idatareader
      
      try
         connection.open()
         reader = command.ExecuteReader
         while reader.read
            strings.add(reader.getstring(0))
         end while
      finally
         if reader isnot nothing then _
            reader.close()
         if connection.state <> connectionstate.closed then _
            connection.close()
      end try
      return strings
   end function
   
   private function create_connection() as idbconnection
      return common.CreateConnection(db_path)
   end function
end class

end namespace