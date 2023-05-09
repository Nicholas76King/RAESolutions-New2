option strict off

imports raen.math.equations
imports rae.solutions.chillers
imports rae.solutions.chiller_evaporators

namespace rae.solutions.evaporative_condenser_chillers

public class logger
   sub log(message as string)
      system.diagnostics.debug.writeLine(message)
   end sub
   
   sub log(spec as spec)
      log("ambient: " & rae.io.text.conjoin(new object() {spec.ambient, spec.ambient_upper_range, spec.ambient_lower_range, spec.ambient_step}, Rae.Io.Conjunction.And))
      log("catalog: " & spec.catalog_rating)
      log("factors: amp:" & spec.compressor_amp_factor & " comp. capacity:" & spec.compressor_capacity_factor & " cond. capacity:" & spec.condenser_capacity_factor)
      log("dishcarge ll: " & spec.discharge_line_loss & " suction ll: " & spec.suction_line_loss)
      log("fluid: " & spec.fluid.value)
      log("hertz: " & spec.hertz)
      log("leaving fluid: " & spec.leaving_fluid_temp & ", " & spec.leaving_fluid_temp_upper_range & ", " & spec.leaving_fluid_temp_lower_range & ", " & spec.leaving_fluid_temp_step)
      log("approach: " & spec.lower_approach & ", " & spec.upper_approach)
      log("specific gravity: " & spec.specific_gravity & ", " & spec.specific_heat)
      log("subcooling temp: " & spec.subcooling_temp)
      log("temp range: " & spec.range)
      log(spec.user.authority_group.toString)
   end sub
   
   sub log(chiller as chiller)
      log("# circuits: " & chiller.num_circuits & ", " & chiller.refg.value & ", " & chiller.refg.for_db & ", " & chiller.min_capacity & ", " & chiller.max_capacity)
      for each circuit in chiller.circuits
                log("compressor:" & circuit.compressor.model & " (" & circuit.compressor_qty & "), " & circuit.compressor.refrigerant & ", hp:" & circuit.compressor.hp & ", coef:" & circuit.compressor.num_coef & ", suction max:" & circuit.compressor.suctionMax & ", suction min:" & circuit.compressor.suctionMin)
         log("coef: " & circuit.compressor.coef.a(0) & ", " & circuit.compressor.coef.c(0) & ", " & circuit.compressor.coef.w(0))
         log("condenser:" & chiller.condenser.model & ", gpm:" & chiller.condenser.gpm & ", " & chiller.condenser.fan_hp & ", pump hp:" & chiller.condenser.pump_hp)
         log("condenser qty:" & chiller.condenser_quantity & ", air flow:" & chiller.condenser.air_flow & ", capacity:" & chiller.condenser.capacity)
         log("total fan watts:" & chiller.total_fan_watts & ", total pump watts:" & chiller.total_pump_watts)
      next
   end sub
   
   sub log(evaporators as evaporator_list)
      dim evap8 = evaporators.at(8)
      log(evap8)
      dim evap10 = evaporators.at(10)
      log(evap10)
   end sub
   
   sub log(evap as evaporator)
      log("approach: " & evap.approach)
      log("model: " & evap.model)
      log("capacity: " & evap.capacity)
      log("fluid flow: " & evap.fluid_flow)
      log("fluid pd: " & evap.fluid_pressure_drop)
      log("tons: " & evap.nominal_tons)
      log("# circuits: " & evap.num_circuits)
      log("warnings: " & evap.warnings.count)
   end sub
   
   sub log(output as iplv_output)
      log("load:" & output.load & ", capacity:" & round(output.capacity,1) & ", comp. kw/ton:" & round(output.compressor_kw_per_ton,2) & ", unit kw/ton:" & round(output.unit_kw_per_ton,2) & ", gpm:" & round(output.gpm) & ", gpm/ton:" & round(output.gpm_per_ton,1) _
          & ", range:" & round(output.range,1) & ", cond. fan watts:" & round(output.condenser_fan_watts) & ", comp. capacity factor:" & round(output.compressor_capacity_factor,2) & ", cond. capacity factor:" & round(output.condenser_capacity_factor,2))
   end sub
   
   sub log(low as iplv_output, high as iplv_output, capacity_percentage as double)
      log("gpm difference:" & round(low.gpm - high.gpm, 1) & ", gpm:" & round(low.gpm) & ", gpm/ton:" & round(low.gpm_per_ton,1))
      dim difference = low.load * 0.01 * high.capacity - low.capacity
      log("capacity difference:" & round(difference, 1) & "  " & round(low.capacity, 1) & " " & round(high.capacity, 1) & " tons")
   end sub
   
   sub log_range(output as iplv_output)
      log("range:" & round(output.range,1) & ", gpm:" & round(output.gpm) & ", gpm/ton:" & round(output.gpm_per_ton,1))
   end sub
   
   sub log_compressor_capacity_factor(output as iplv_output)
      log("compressor capacity factor:" & round(output.compressor_capacity_factor,2) & ", capacity:" & round(output.capacity,1))
   end sub
   
   sub log(factor as double, previous_watts as double, new_watts as double)
      log("condenser fan watt factor:" & round(factor,2) & " previous:" & round(previous_watts) & " new:" & round(new_watts))
   end sub
   
end class

end namespace