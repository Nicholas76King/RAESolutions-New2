option strict off

imports system.environment
imports system.math

namespace rae.solutions.cu_uc_balances.balance_system

public class custom_unit_cooler
   public capacity as double
   public quantity as double
end class

public class unit_cooler
   public model as string
   public quantity as integer
   public static_pressure as double

   function capacity_at(suction as double, room_temp as double) as double
      dim td = room_temp - suction
      
      if uc is nothing then 'if called multiple times no need to retrive data unless model changes
         uc = new unit_coolers.service().get_unit_cooler(model)
      end if
      
      return uc.capacity_at(suction, td, static_pressure)
   end function

   private uc as unit_coolers.unit_cooler

end class

public class unit_cooler_list : inherits list(of unit_cooler)

   function total_quantity as integer
      dim total as integer
      for each unit_cooler in me
         total += unit_cooler.quantity
      next
      return total
   end function
   
   function total_capacity_at(evaporating_temp as double, room_temp as double) as double
      dim total as double = 0
      for each unit_cooler in me
         total += unit_cooler.capacity_at(evaporating_temp, room_temp) * unit_cooler.quantity
      next
      return total
   end function

end class

public structure condensing_unit
   public model as string
   public refrigerant as string
end structure

end namespace