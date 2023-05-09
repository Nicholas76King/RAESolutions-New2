namespace rae.solutions.air_cooled_chillers

public class chiller

   public shared LEAVING_FLUID_TEMP_LOWER_LIMIT as double = -40
   public shared LEAVING_FLUID_TEMP_UPPER_LIMIT as double = 85

   public model, evaporator_part_number as string
   public approx_min_capacity, approx_max_capacity as double
   public num_circuits_per_unit as integer

   public circuit_1, circuit_2 as circuit

end class

end namespace