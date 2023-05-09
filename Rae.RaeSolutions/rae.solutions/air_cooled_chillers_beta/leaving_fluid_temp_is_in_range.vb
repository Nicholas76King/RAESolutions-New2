imports rae.validation
imports rae.io.text

namespace rae.solutions.chillers

class leaving_fluid_temp_is_in_range : inherits validator_base
   public const lower_limit as double = -40
   public const upper_limit as double = 75
   
   private leaving_fluid_temp as double

   sub new(leaving_fluid_temp as double)
      me.leaving_fluid_temp = leaving_fluid_temp
   end sub

   overrides function validate() as i_validate
      messages.clear()
      valid = leaving_fluid_temp >= lower_limit and leaving_fluid_temp <= upper_limit
      if not valid then messages.add( new message(validation_status.failure, "The leaving fluid temperature is out of range." & new_line & "leaving fluid temperature: " & leaving_fluid_temp) )
      return me
   end function
   
end class

end namespace