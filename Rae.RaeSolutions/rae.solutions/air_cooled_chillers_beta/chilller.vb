namespace rae.solutions.air_cooled_chillers_balance

public class chiller
   public refrigerant as refrigerant
   public circuits as new list(of circuit)
end class

public structure circuit
   public condenser_capacity as double
   public compressor_quantity as double
end structure

end namespace