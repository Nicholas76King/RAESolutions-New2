imports rae.solutions
imports rae.solutions.evaporative_condenser_chillers

module evaporative_condenser_chiller_mocks
   function default_spec() as spec
      dim spec as spec
      spec.ambient = 75
      spec.leaving_fluid_temp = 44
      spec.ambient_upper_range = 4
      spec.ambient_lower_range = 4
      spec.ambient_step = 4
      spec.compressor_capacity_factor = 1
      spec.catalog_rating = false
      spec.compressor_amp_factor = 1
      spec.condenser_capacity_factor = 1
      spec.discharge_line_loss = 1
      spec.fluid = coolingmedia.water
      spec.hertz = 60
      spec.leaving_fluid_temp_upper_range = 4
      spec.leaving_fluid_temp_lower_range = 4
      spec.leaving_fluid_temp_step = 2
      spec.lower_approach = 8
      spec.upper_approach = 10
      spec.specific_gravity = 1
      spec.specific_heat = 1
      spec.subcooling_temp = 5
      spec.suction_line_loss = 1
      spec.range = 10
      spec.user = new user("CASEYJ", "PASS", "CASEY", "JOYCE", user_group.employee, access_level.ALL)
      
      return spec
   end function
end module
