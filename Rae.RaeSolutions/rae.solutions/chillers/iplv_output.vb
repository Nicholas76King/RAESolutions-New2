

namespace rae.solutions.chillers

public structure iplv_output
   public gpm, capacity, condensing_temp, range, compressor_capacity_factor, condenser_capacity_factor, load as double
   public eer, unit_kw_per_ton, compressor_kw_per_ton, compressor_eer, leaving_fluid_temperature, ambient as double
   public condenser_fan_watts as double
   
   function gpm_per_ton() as double
      return gpm / capacity
   end function
end structure

end namespace