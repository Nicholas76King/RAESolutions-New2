imports rae.validation
imports rae.io.text

namespace rae.solutions.drawings

class unit_cooler_fan_amps_are_available : inherits validator_base
   
   private fan_amps, fan_voltage as double
   private unit_cooler_model as string

   sub new(fan_amps as double, fan_voltage as double, unit_cooler_model as string)
      me.fan_amps = fan_amps
      me.fan_voltage = fan_voltage
      me.unit_cooler_model = unit_cooler_model
   end sub

   overrides function validate() as i_validate
      messages.clear()
      
      valid = fan_amps <> 0
      if not valid then
         dim message = str("Fan amps are not available for unit cooler model '{0}' at voltage '{1}'.", unit_cooler_model, fan_voltage)
         messages.add(new message(validation_status.warning, message))
      end if

      return me
   end function
end class

end namespace