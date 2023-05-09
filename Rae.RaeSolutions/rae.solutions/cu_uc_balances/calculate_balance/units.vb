namespace rae.solutions.cu_uc_balances

public class units : inherits list(of unit)
   function total_capacity() as double
      total_capacity = 0
      for each unit in me
         total_capacity += unit.capacity * unit.quantity
      next
   end function
end class

end namespace