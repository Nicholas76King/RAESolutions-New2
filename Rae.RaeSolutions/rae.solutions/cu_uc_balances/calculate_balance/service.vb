imports rae.solutions.cu_uc_balances

namespace rae.solutions.unit_coolers

partial public class service
   function calculate_balance(condensing_unit as unit, unit_coolers as units) as double
      return (condensing_unit.capacity * condensing_unit.quantity) - unit_coolers.total_capacity
   end function
end class

end namespace
