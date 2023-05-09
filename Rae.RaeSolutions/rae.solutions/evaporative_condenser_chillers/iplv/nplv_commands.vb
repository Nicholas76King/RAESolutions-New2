imports rae.solutions.evaporative_condenser_chillers
imports rae.solutions.chillers
imports rae.solutions.chiller_evaporators

namespace rae.solutions.evaporative_condenser_chillers

public class nplv_commands : inherits plv_commands

   private structure ambients_at_loads
      sub new(ambient_at_100 as double)
         at_100 = ambient_at_100
         at_25 = 50 'specified for iplv in ari standard, standard doesn't specifiy nplv

         dim drop = (at_100 - at_25) / 4
         at_75 = at_100 - drop
         at_50 = at_75 - drop
      end sub
      public at_25, at_50, at_75, at_100 as double
   end structure

   private ambients as ambients_at_loads
   
   sub new(spec as spec, chiller as chiller, evaporator_context as evaporator_iplv_context)
      logger = new logger()
      ambients = new ambients_at_loads(spec.ambient)
      spec.ambient_upper_range = 0
      spec.ambient_lower_range = 0
      spec.leaving_fluid_temp_upper_range = 0
      spec.leaving_fluid_temp_lower_range = 0
      me.spec = spec
      me.chiller = chiller
      me.evaporator_context = evaporator_context
      me.plv_type = "nplv"
   end sub

   overrides function at_100_load() as plv_commands
      me.evaporators = evaporator_context.recalculate_evaporators_when_temperature_range_changes(spec.range)
      load = 100
      return me
   end function

   overrides function at_75_load(_100 as iplv_output) as plv_commands
      load = 75
      spec.ambient = ambients.at_75
      reduce_compressor_quantity_if_appropriate(load)
      return me
   end function

   overrides function at_50_load(_100 as iplv_output) as plv_commands
      load = 50
      spec.ambient = ambients.at_50
      reduce_compressor_quantity_if_appropriate(load)
      return me
   end function

   overrides function at_25_load(_100 as iplv_output) as plv_commands
      load = 25
      spec.ambient = ambients.at_25
      reduce_compressor_quantity_if_appropriate(load)
      return me
   end function

end class

end namespace