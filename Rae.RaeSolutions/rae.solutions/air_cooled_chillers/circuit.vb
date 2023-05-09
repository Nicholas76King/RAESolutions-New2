namespace rae.solutions.air_cooled_chillers

public class circuit

   public compressor as compressor_info
   public compressor_quantity as integer

   public refrigerant as string
   public num_refrigeration_circuits as integer
    
   public is_subcooling as boolean
   public subcooling_percentage as double

   public coil as coil
   public coil_quantity as integer

   public fan_diameter, fan_quantity as double

end class

end namespace