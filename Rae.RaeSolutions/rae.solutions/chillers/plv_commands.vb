imports rae.solutions.evaporative_condenser_chillers
imports rae.solutions.chiller_evaporators

namespace rae.solutions.chillers

public class evaporator_iplv_context
   public spec_used_for_balance as evaporator_spec
   public service as i_evaporator_service
   public evaporator_part_number as string
   function recalculate_evaporators_when_temperature_range_changes(temperature_range as double) as evaporator_list
      spec_used_for_balance.entering_fluid_temp = spec_used_for_balance.leaving_fluid_temp + temperature_range
      return service.get_approach_range(evaporator_part_number, spec_used_for_balance)
   end function
end class

public mustinherit class plv_commands
   protected spec as spec
   protected chiller as chiller
   protected evaporators as evaporator_list
   protected evaporator_context as evaporator_iplv_context
   protected logger as logger
   protected load as double
   private factor_step as double = 0.01

   function run() as iplv_output
      dim points = new balance().run(chiller, evaporators, spec)
      dim point = points.at(spec.leaving_fluid_temp, spec.ambient)

      dim output = new conversion().to_iplv_output(spec, chiller, point, load)
      return output
   end function

   'iplv or nplv
   public plv_type as string

   mustoverride function at_100_load() as plv_commands
   mustoverride function at_75_load(_100 as iplv_output) as plv_commands
   mustoverride function at_50_load(_100 as iplv_output) as plv_commands
   mustoverride function at_25_load(_100 as iplv_output) as plv_commands

   sub reduce_compressor_quantity_if_appropriate(load as double)
      'note: when a unit actually has 4 circuits, the program merges 2 of the circuits together
      if load = 75 and chiller.num_circuits = 4 andAlso chiller.circuits(1).compressor_qty > 1
         chiller.circuits(1).compressor_qty -= 1
         chiller.num_circuits -= 1
      else if load = 50 and chiller.num_circuits >= 2
         chiller.circuits.RemoveAt(1)
         chiller.num_circuits -= 1
      else if load = 25 and chiller.circuits(0).compressor_qty > 1
         chiller.circuits(0).compressor_qty -= 1
      end if
   end sub

   function calculate_iplv(_100 as iplv_output, _75 as iplv_output, _50 as iplv_output, _25 as iplv_output) as double
      dim a = _100.eer : dim b = _75.eer : dim c = _50.eer : dim d = _25.eer
      dim iplv = 0.01*a + 0.42*b + 0.45*c + 0.12*d
      return iplv
   end function

   function reduce_temperature_range(range_step as double) as plv_commands
      spec.range -= range_step
      evaporators = evaporator_context.recalculate_evaporators_when_temperature_range_changes(spec.range)
      return me
   end function

   function increase_temperature_range(range_step as double) as plv_commands
      spec.range += range_step
      evaporators = evaporator_context.recalculate_evaporators_when_temperature_range_changes(spec.range)
      return me
   end function

   function recalculate_evaporators_when_temperature_range_changes(temperature_range as double) as evaporator_list
      evaporators = evaporator_context.recalculate_evaporators_when_temperature_range_changes(spec.range)
      return evaporators
   end function

   function increase_compressor_capacity_factor(factor_step as double) as plv_commands
      spec.compressor_capacity_factor += factor_step
      return me
   end function

   function decrease_compressor_capacity_factor(factor_step as double) as plv_commands
      spec.compressor_capacity_factor -= factor_step
      return me
   end function

   function decrease_condenser_capacity_factor() as plv_commands
      spec.condenser_capacity_factor -= factor_step
      logger.log("condenser capacity factor: " & system.math.round(spec.condenser_capacity_factor,2))
      return me
   end function

   private function calculate_condenser_fan_watts_factor(load as double) as double
      dim x = load
      dim factor = 0.000199*x^3 - 0.012576*x^2 + 0.265307*x - 0.86014
      factor *= 0.01

      return factor
   end function

end class

end namespace