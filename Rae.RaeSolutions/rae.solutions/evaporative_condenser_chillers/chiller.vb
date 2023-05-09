Imports rae.solutions.compressors

namespace rae.solutions.evaporative_condenser_chillers

public class chiller
   sub new()
      circuits = new list(of circuit)
   end sub
   
   public model, evaporator_model as string
   public refg As refrigerant
   public num_circuits, min_capacity, max_capacity as double
   public circuits as list(of circuit)
   
   public condenser as evaporative_condenser
   public condenser_quantity as double
   
   function total_condenser_watts() as double
      return total_fan_watts + total_pump_watts
   end function
   
   public total_fan_watts, total_pump_watts as double
   
   sub calculate_fan_watts()
      total_fan_watts = calculate_watts(condenser.fan_hp, condenser_quantity)
   end sub
   
   sub calculate_pump_watts()
      total_pump_watts = calculate_watts(condenser.pump_hp, condenser_quantity)
   end sub
   
   function calculate_watts(hp as double, quantity as double) as double
      return hp * 877.3 * quantity
   end function
end class

public class circuit
   sub new()
      compressor = new compressor()
   end sub
   public compressor as compressor
   public compressor_qty as double
end class

end namespace