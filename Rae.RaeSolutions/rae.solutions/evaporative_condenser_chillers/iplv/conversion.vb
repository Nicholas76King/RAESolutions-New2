namespace rae.solutions.evaporative_condenser_chillers

class conversion

   function to_iplv_output(spec     as spec, 
                           chiller  as chiller, 
                           point    as balance.point, 
                           load     as double
   ) as chillers.iplv_output
      dim output as chillers.iplv_output

      output.ambient          = point.ambient
      output.capacity         = point.capacity
      output.condensing_temp  = point.condensing_temp
      output.eer              = point.eer
      output.compressor_eer   = point.compressor_eer
      output.unit_kw_per_ton  = point.unit_kw_per_ton
      output.gpm              = point.gpm
      output.range            = spec.range
      output.load             = load
      output.leaving_fluid_temperature = point.leaving_fluid_temp
      output.condenser_fan_watts       = chiller.total_fan_watts
      output.compressor_kw_per_ton     = point.compressor_kw_per_ton
      output.compressor_capacity_factor= spec.compressor_capacity_factor
      output.condenser_capacity_factor = spec.condenser_capacity_factor

      return output
   end function

end class

end namespace