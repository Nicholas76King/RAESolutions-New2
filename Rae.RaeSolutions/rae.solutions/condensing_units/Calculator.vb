namespace rae.solutions.condensing_units

public class Calculator
   function subcooling(ct as double, at as double) as double
      subcooling = .6187 * (ct-at) + .5753
   end function
end class

end namespace