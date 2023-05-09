imports rae.solutions.evaporative_condenser_chillers

<TestClass> _
public class evaporative_condenser_chiller_35E2SM240_ : inherits test_chiller_base

<TestMethod> _
sub balance_point_is_correct()
   dim point = calculate_balance_point()
   assert(point.ambient = 75)
   assert(point.leaving_fluid_temp = 44)
   assert(point.approach = 8)
   assert(round(point.capacity, 1) = 201.2)
   assert(round(point.compressor_amps) = 262)
   assert(round(point.compressor_kw_per_ton, 2) = 0.89)
   assert(round(point.compressor_kw, 1) = 178.8)
   assert(round(point.condensing_temp, 1) = 107.4)
   assert(round(point.eer, 1) =12.8)
   assert(round(point.evaporating_temp, 1) = 35.3)
   assert(round(point.fluid_pressure_drop, 2) = 5.65)
   assert(round(point.gpm, 1) = 482.9)
   assert(round(point.unit_kw, 1) = 189.2)
   assert(round(point.unit_kw_per_ton, 2) = 0.94)
end sub

private function calculate_balance_point() as balance.point
   dim spec = evaporative_condenser_chiller_mocks.default_spec
   config.db
   
   dim chiller = get_chiller("35E2SM240", 460)
   
   dim evaporators = get_evaporators(chiller, spec)
   
   dim balance = new balance()
   dim points = balance.run(chiller, evaporators, spec)
   
   return points.at(spec.leaving_fluid_temp, spec.ambient)
end function

end class
