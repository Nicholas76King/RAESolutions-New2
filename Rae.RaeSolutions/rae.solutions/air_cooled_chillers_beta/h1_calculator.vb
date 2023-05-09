option strict off

namespace rae.solutions.air_cooled_chillers_balance

public class h1_calculator
   private dll, cc

   sub new(discharge_line_loss, condenser_capacity)
      dll = discharge_line_loss
      cc = condenser_capacity
   end sub

   function h1(tc,ta)
      h1 = (tc-ta) / (25 + dll) / cc
   end function
end class

End Namespace



'option strict off

'imports rae.math.calculate
'imports rae.solutions.chiller_evaporators
'imports rae.solutions.chillers

'namespace rae.solutions.air_cooled_chillers_balance

'public class algorithm

'   private service as balance_service

'   sub new(service as balance_service)
'      me.service = service
'   end sub

'   function run(chiller as chiller, spec as spec) as result
'      dim result as result
'      result.ambient = spec.ambient
'      return result
'   end function

'   function run(chiller as chiller, spec as spec) as result_list
'      dim leaving_fluid_temp_is_in_range = new leaving_fluid_temp_is_in_range(spec.leaving_fluid_temp)

'      dim lower_te, upper_te as double
'      service.select_evaporating_temp_range(spec.leaving_fluid_temp, lower_te, upper_te)

'      dim hz_factor = service.get_hertz_multipliers(spec.hertz)
'      'dim lower_ambient_difference = 10

'      dim compressor_factor as polynomial_set
'      compressor_factor.q = spec.compressor_capacity_factor
'      compressor_factor.w = 0.7821 * spec.capacity_factor + 0.2104
'      compressor_factor.a = spec.compressor_amp_factor

'      dim polynomial = new compressor_polynomial()

'      for each circuit in chiller.circuits
'         dim h1_calc = new h1_calculator(spec.discharge_line_loss, circuit.condenser_capacity)

'         dim multiplier as polynomial_set
'         multiplier.q = circuit.compressor_quantity * compressor_factor.q * hz_factor.q
'         multiplier.w = circuit.compressor_quantity * compressor_factor.w * hz_factor.w
'         multiplier.a = circuit.compressor_quantity * compressor_factor.a * hz_factor.a

'         dim balance_compressor_and_condenser = new balance_compressor_and_condenser(polynomial, h1_calc, multiplier)

'         dim lower_leaving_fluid_temp = spec.leaving_fluid_temp - 4
'         dim upper_leaving_fluid_temp = spec.leaving_fluid_temp + 4

'         for ta = spec.ambient - spec.degrees_below_ambient to spec.ambient + spec.degrees_above_ambient step spec.ambient_step
'            dim q_at_lower_te = balance_compressor_and_condenser.at(lower_te, ta).q
'            dim q_at_upper_te = balance_compressor_and_condenser.at(upper_te, ta).q

'            dim q_per_degree = (q_at_upper_te - q_at_lower_te) / 15
'            dim b = upper_te - (q_at_upper_te / q_per_degree)
'            dim m1 = (upper_te - b) / q_at_upper_te

'            for tw = lower_leaving_fluid_temp to upper_leaving_fluid_temp step 2
'               if tw > upper_leaving_fluid_temp then exit for

'               dim upper_approach = 10
'               if not evaporator.is_custom then
'                  upper_approach = evaporator.upper_approach
'               end if

'               dim q9 = evaporator.capacity_at_upper_approach
'               dim q8 = evaporator.capacity_at_lower_approach

'               dim te = tw - (upper_approach + spec.suction_line_loss)
'               dim ee = average(q9, q8)
'               dim f = te + q9 / ee
'               dim g = (te - f) / q9
'               te = ((b * g) - (f * m1)) / (g - m1)

'               dim point = balance_compressor_and_condenser.at(te, ta)

'               if spec.catalog_rating then point.q *= 1.04

'               dim subcooling = 0.6187 * (point.tc - ta) + 0.5753
'               dim subcooling_factor = subcooling / chiller.refrigerant.sc / 100 + 1
'               'if not circuit.has_subcooling then subcooling_factor = 1

'               q *= subcooling_factor

'               'if chiller.fluid_is_glycol then
'                  'gpm = q / fluid.gpm_factor
'               'else
'                  'gpm = q / 500 * tr
'               'end if

'               dim result as result
'               result.ambient = ta
'               result.evaporating_temp = te
'               result.leaving_fluid_temp = tw
'               result.condensing_temp = tc
'               result.compressor_eer = point.q / point.w
'               result.compressor_kw = (point.w / 1000
'               dim fans_w = fan_w * chiller.fan_quantity
'               result.fans_kw = fans_w / 1000
'               result.unit_kw = result.compressor_kw + result.fans_kw
'               result.unit_eer = point.q / (compressor_w + fans_w)
'               result.subcooling = subcooling
'               result.approach = round(tw-te)
'            next
'         next
'      next

'      'circuit, ambient, lft
'   end function


'   'function run(chiller as chiller, spec as spec) as result_list
'   '   dim leaving_fluid_temp_is_in_range = new leaving_fluid_temp_is_in_range(spec.leaving_fluid_temp)

'   '   dim lower_te, upper_te as double
'   '   service.select_evaporating_temp_range(spec.leaving_fluid_temp, lower_te, upper_te)

'   '   dim hz_factor = service.get_hertz_multipliers(spec.hertz)
'   '   'dim lower_ambient_difference = 10

'   '   dim polynomial = new compressor_polynomial()

'   '   for each circuit in chiller.circuits
'   '      dim h1_calc = new h1_calculator(spec.discharge_line_loss, circuit.condenser_capacity)

'   ''   dim compressor_factor as polynomial_set
'   ''   compressor_factor.q = spec.compressor_capacity_factor
'   ''   compressor_factor.w = 0.7821 * spec.capacity_factor + 0.2104
'   ''   compressor_factor.a = spec.compressor_amp_factor

'   ''   dim multiplier as polynomial_set
'   ''   multiplier.q = chiller.circuit_1.compressor_quantity * compressor_factor.q * hz_factor.q
'   ''   multiplier.w = chiller.circuit_1.compressor_quantity * compressor_factor.w * hz_factor.w
'   ''   multiplier.a = chiller.circuit_1.compressor_quantity * compressor_factor.a * hz_factor.a

'   ''   dim balance_compressor_and_condenser = new balance_compressor_and_condenser(polynomial, h1_calc, multiplier)

'   ''   dim lower_leaving_fluid_temp = spec.leaving_fluid_temp - 4
'   ''   dim upper_leaving_fluid_temp = spec.leaving_fluid_temp + 4

'   ''   for ta = spec.ambient - spec.degrees_below_ambient to spec.ambient + spec.degrees_above_ambient step spec.ambient_step
'   ''      dim q_at_lower = balance_compressor_and_condenser.at(lower_te, ta).q
'   ''      dim q_at_upper = balance_compressor_and_condenser.at(upper_te, ta).q

'   ''      dim q_per_degree = (q_at_upper - q_at_lower) / 15
'   ''      dim b = upper_te - (q_at_upper / q_per_degree)
'   ''      dim m1 = (upper_te - b) / q_at_upper

'   ''      for tw = lower_leaving_fluid_temp to upper_leaving_fluid_temp step 2
'   ''         if tw > upper_leaving_fluid_temp then goto 660

'   ''         dim upper_approach = 10
'   ''         if not evaporator.is_custom then
'   ''            upper_approach = evaporator.upper_approach
'   ''         end if

'   ''         dim q9 = evaporator.capacity_at_upper_approach
'   ''         dim q8 = evaporator.capacity_at_lower_approach

'   ''         dim te = tw - (upper_approach + spec.suction_line_loss)
'   ''         dim ee = average(q9, q8)
'   ''         dim f = te + q9 / ee
'   ''         dim g = (te - f) / q9
'   ''         te = ((b * g) - (f * m1)) / (g - m1)

'   ''         dim point = balance_compressor_and_condenser.at(te, ta)

'   ''         if spec.catalog_rating then point.q *= 1.04

'   ''         dim subcooling = 0.6187 * (point.tc - ta) + 0.5753
'   ''         dim subcooling_factor = subcooling / chiller.refrigerant.sc / 100 + 1
'   ''         'if not circuit.has_subcooling then subcooling_factor = 1

'   ''         q *= subcooling_factor

'   ''         'if chiller.fluid_is_glycol then
'   ''            'gpm = q / fluid.gpm_factor
'   ''         'else
'   ''            'gpm = q / 500 * tr
'   ''         'end if

'   ''         dim result as result
'   ''         result.ambient = ta
'   ''         result.evaporating_temp = te
'   ''         result.leaving_fluid_temp = tw
'   ''         result.condensing_temp = tc
'   ''         result.compressor_eer = point.q / point.w
'   ''         result.compressor_kw = (point.w / 1000
'   ''         dim fans_w = fan_w * chiller.fan_quantity
'   ''         result.fans_kw = fans_w / 1000
'   ''         result.unit_kw = result.compressor_kw + result.fans_kw
'   ''         result.unit_eer = point.q / (compressor_w + fans_w)
'   ''         result.subcooling = subcooling
'   ''         result.approach = round(tw-te)
'   ''      next
'   ''   next
'   '   next
'   'end function

'   'if spec.ambient = ta and spec.leaving_fluid_temp = tw then
'       'set subcooling control
'       'set approach control

'end class

''public class result_list
''   'inputs
''   public spec as spec
''   'public evaporator as evaporator
''   public chiller as chiller
''   'outputs
''   public results as new list(of result)
''end class

'public structure result
'   public ambient, leaving_fluid_temp, evaporating_temp, condensing_temp as double
'   public capacity, gpm, fluid_pressure_drop as double
'   public compressor_eer, unit_eer as double
'   public compressor_kw, fan_kw, unit_kw as double
'   public subcooling, approach as double
'end structure

'end namespace