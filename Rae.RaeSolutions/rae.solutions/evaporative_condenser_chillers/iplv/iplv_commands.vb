imports rae.solutions.chillers
imports rae.solutions.chiller_evaporators

namespace rae.solutions.evaporative_condenser_chillers

public class iplv_commands : inherits plv_commands

   sub new(spec as spec, chiller as chiller, evaporator_context as evaporator_iplv_context)
      logger = new logger()
      spec.fluid = coolingmedia.water
      spec.ambient_upper_range = 0
      spec.ambient_lower_range = 0
      spec.leaving_fluid_temp_upper_range = 0
      spec.leaving_fluid_temp_lower_range = 0
      spec.compressor_capacity_factor = 1
      spec.condenser_capacity_factor = 1
      spec.compressor_amp_factor = 1
      me.spec = spec
      me.chiller = chiller
      me.plv_type = "iplv"

      ' ARI requirements
      evaporator_context.spec_used_for_balance.fluid = StandardRefrigeration.Fluid.Water
      evaporator_context.spec_used_for_balance.glycol_percentage = 0
      evaporator_context.spec_used_for_balance.entering_fluid_temp = spec.entering_fluid_temp
      evaporator_context.spec_used_for_balance.evaporating_temp = new Water().FreezePoint
      me.evaporator_context = evaporator_context
   end sub

   overrides function at_100_load() as plv_commands
      load = 100
      spec.ambient = 75
      spec.range = 10
      spec.leaving_fluid_temp = 44
      evaporators = evaporator_context.recalculate_evaporators_when_temperature_range_changes(spec.range)
      return me
   end function

   overrides function at_75_load(_100 as iplv_output) as plv_commands
      load = 75
      spec.ambient = 68.75
      reduce_compressor_quantity_if_appropriate(load)
      return me
   end function

   overrides function at_50_load(_100 as iplv_output) as plv_commands
      load = 50
      spec.ambient = 62.5
      reduce_compressor_quantity_if_appropriate(load)
      return me
   end function

   overrides function at_25_load(_100 as iplv_output) as plv_commands
      load = 25
      spec.ambient = 56.25
      reduce_compressor_quantity_if_appropriate(load)
      return me
   end function

end class

end namespace
