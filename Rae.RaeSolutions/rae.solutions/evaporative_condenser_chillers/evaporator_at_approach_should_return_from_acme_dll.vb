Imports rae.io.text
imports rae.solutions.chiller_evaporators
imports rae.validation
imports rae.validation.validation_status

namespace rae.solutions.evaporative_condenser_chillers

class approach_should_be_returned_by_acme_dll : inherits validation.validator_base
   sub new(evaporator as evaporator, approach as double)
      me.evaporator = evaporator
      me.approach = approach
   end sub
   
   overrides function validate() as i_validate
      _messages.clear()
      if evaporator is nothing
         valid = false
         _messages.add(new message(failure, str("the approach {0}F was in range but the evaporator data was not returned by the acme dll for an unknown reason", approach)))
         _messages.add(new message(warning, "* the fluid pressure drop cannot be calculated because the acme dll did not return data"))
      else
         valid = true
      end if
      
      return me
   end function
   
   private evaporator as evaporator
   private approach as double
end class

end namespace