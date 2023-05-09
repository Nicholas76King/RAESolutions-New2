option strict off

namespace rae.solutions.condensing_units

class H1_Calculator
   sub new(condenser_capacity)
      me.condenser_capacity = condenser_capacity
   end sub
   
   function h1(tc, ta)
      h1 = (tc - ta) * condenser_capacity
   end function
   
   private condenser_capacity
end class

end namespace