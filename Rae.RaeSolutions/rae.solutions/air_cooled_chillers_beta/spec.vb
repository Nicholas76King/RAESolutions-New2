namespace rae.solutions.air_cooled_chillers_balance

public structure spec
   public ambient, leaving_fluid_temp as double
   public degrees_below_ambient as double '= 10
   public degrees_above_ambient as double '= 20
   public ambient_step as double '= 10

   public compressor_capacity_factor, compressor_watt_factor, compressor_amp_factor as double
   public capacity_factor, watt_factor as double
   public discharge_line_loss, suction_line_loss, hertz as double
   public catalog_rating as boolean
   'public override_compressor_safety as boolean
end structure

end namespace