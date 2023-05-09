namespace rae.solutions.evaporative_condenser_chillers

public structure evaporative_condenser
   public model as string
   public capacity, fan_hp, pump_hp, air_flow, gpm as double
   public shipping_weight, operating_weight as double
   public height, width, length as double
   public is_custom as boolean
   
   overrides function toString() as string
      return model
   end function
end structure

end namespace