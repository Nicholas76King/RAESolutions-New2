option strict off

namespace rae.solutions.evaporative_condenser_chillers

public class h1_calculator
   sub new(condenser_capacity, discharge_line_loss)
      me.condenser_capacity = condenser_capacity
      me.discharge_line_loss = discharge_line_loss
   end sub

   function h1(tc,ta)
      h1 = (1000 * condenser_capacity) * ((0.0375 * (tc - discharge_line_loss)) - 2.9375 + 0.025 * (78 - ta))
   end function

   private condenser_capacity, discharge_line_loss
end class

end namespace