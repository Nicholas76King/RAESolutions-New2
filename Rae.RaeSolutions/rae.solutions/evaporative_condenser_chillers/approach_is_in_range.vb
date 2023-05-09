Imports Rae.RaeSolutions.Business.Entities
Imports Rae.Io.Text
imports rae.solutions.group
imports rae.validation
imports rae.validation.validation_status

namespace rae.solutions.evaporative_condenser_chillers

class approach_is_in_range : inherits validator_base
   sub new(point as balance.point, user as user)
      me.point = point
      me.user = user
   end sub
   
   overrides function validate() as i_validate
      _messages.clear()
      dim approach = point.approach
      if user.can(calculate_iplv)
         valid = true
      elseif user.is_rep and approach < rep_min
         valid = false
         _messages.add(new message(failure, below_min_message(rep_min)))
      elseIf user.is_employee and approach < employee_min
         valid = false
         _messages.add(new message(failure, below_min_message(employee_min)))
      elseIf approach > max
         valid = false
         _messages.add(new message(failure, str("approach, {0}, is above max, {1}", approach.toString("#0.0"), max)))
      else
         valid = true
      end if
      
      if _messages.count > 0 then _
         _messages.add(new message(warning, "* pressure drop cannot be calculated because approach is out of range"))
      
      return me
   end function
   
   private point as balance.point
   private user as user
   private const rep_min      as double = 6
   private const employee_min as double = 5
   private const max          as double = 12
   
   private function below_min_message(min as double) as string
      return str("approach, {0}, is below minimum, {1}", point.approach.toString("#0.0"), min)
   end function
   
end class

end namespace