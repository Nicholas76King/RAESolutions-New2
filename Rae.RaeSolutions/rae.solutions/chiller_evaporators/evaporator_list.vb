namespace rae.solutions.chiller_evaporators

public class evaporator_list : inherits list(of evaporator)
   function at(approach as integer) as evaporator
      for each evaporator in me
         if evaporator.approach = approach then
            return evaporator
         end if
      next
   end function
end class

end namespace