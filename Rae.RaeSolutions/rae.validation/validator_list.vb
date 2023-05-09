namespace rae.validation

public class validator_list : inherits validator_base
   sub new()
      mybase.new()
      validators = new list(of i_validate)
   end sub

   sub add(validator as i_validate)
      validators.add(validator)
   end sub
   
   sub add_range(validators as validator_list)
      me.validators.addrange(validators.items)
   end sub
   
   overrides function validate() as i_validate
      messages.clear
      valid = true
      for each validator in validators
         validator.validate()
         _messages.addRange(validator.messages)
         if validator.is_invalid then
            valid = false
         end if
      next
      
      return me
   end function

   sub clear
      validators.clear
   end sub
   
   private function items() as list(of i_validate)
      return validators
   end function

   private validators as list(of i_validate)
end class

end namespace