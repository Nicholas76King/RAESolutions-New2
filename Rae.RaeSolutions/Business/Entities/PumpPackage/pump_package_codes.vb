namespace Rae.RaeSolutions.Business.Entities

public class pump_package_codes
   shared function has(code as string) as boolean
      if code like "HT*" then
         return true
      end if
      select case code
         case "HA01", "HA02", "HP07", "HV06", "HD01", "HV05", "HG02", "HG03", "HC01", "HP03", "HP04", _
              "MC50", "MC51", "MC52", "MC55", "EB01", _
              "HP05", "HV01", "HD02", "HU01", "HG01", "MP01", "HP08", "HV02", "HV06" : return true
      end select
      return false
   end function
end class

end namespace