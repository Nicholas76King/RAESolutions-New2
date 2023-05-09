Imports Rae.Validation
imports Rae.Validation.validation_status

namespace rae.solutions.evaporative_condenser_chillers

public class evaporating_temp_satisfies_recommendation : inherits validator_base
   sub new(evaporating_temp as double, recommended_min_evaporating_temp as double)
      if evaporating_temp < recommended_min_evaporating_temp
         valid = false
         messages.add(new message(failure, "evaporating temperature, " & system.math.round(evaporating_temp,1) & ", is less than recommended minimum evaporating temperature, " & recommended_min_evaporating_temp))
      else
         valid = true
      end if
   end sub
   
   overrides function validate() as i_validate
      return me
   end function
end class

end namespace