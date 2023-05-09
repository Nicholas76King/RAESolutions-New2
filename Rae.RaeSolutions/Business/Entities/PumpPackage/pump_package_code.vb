imports system.collections.generic

namespace Rae.RaeSolutions.Business.Entities

public class pump_package_code
   shared function matches(code as string) as boolean
      select case code
         case "PP", "HP01", "HP02" : return true
      end select
      return false
   end function
end class

end namespace
