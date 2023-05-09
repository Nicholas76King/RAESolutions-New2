imports rae.validation

namespace rae.solutions.drawings

class unit_cooler_model_is_in_database : inherits validator_base

   private model_is_in_database as boolean
   private unit_cooler_model as string

   sub new(model_is_in_database as boolean, unit_cooler_model as string)
      me.model_is_in_database = model_is_in_database
      me.unit_cooler_model = unit_cooler_model
   end sub

   overrides function validate() as i_validate
      messages.clear()
      
      valid = model_is_in_database
      if not model_is_in_database then
         messages.add(new message(validation_status.warning, "The unit cooler model, '" & unit_cooler_model & "', is not in the database."))   
      end if

      return me
   end function

end class

end namespace