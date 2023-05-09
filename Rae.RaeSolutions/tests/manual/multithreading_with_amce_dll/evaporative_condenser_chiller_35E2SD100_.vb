Imports Rae.RaeSolutions.Business.Entities
Imports rae.solutions.evaporative_condenser_chillers

<TestClass> _
Public Class evaporative_condenser_chiller_35E2SD100_ : inherits test_chiller_base
   
   <TestMethod> _
   sub balance_point_is_correct
      dim point = balance_point()
      assert(point.leaving_fluid_temp = 44,              "leaving fluid temperature is wrong")
      assert(point.ambient = 75,                         "ambient is wrong")
      assert(round(point.evaporating_temp, 1) = 36.8,    "evaporating temperature is wrong")
      assert(round(point.condensing_temp, 1) = 104,      "condensing temperature is wrong")
      assert(round(point.capacity, 1) = 79.1,            "capacity is wrong")
      assert(round(point.compressor_kw, 1) = 70.9,       "compressor watts are wrong")
      assert(round(point.unit_kw, 1) = 78.1,             "unit watts are wrong")
      assert(round(point.gpm, 1) = 189.8,                "gpm is wrong")
      assert(round(point.fluid_pressure_drop, 2) = 2.25, "fluid pressure drop is wrong")
      assert(round(point.compressor_kw_per_ton, 2) = .9, "compressor efficiency is wrong")
      assert(round(point.unit_kw_per_ton, 2) = .99,      "unit efficiency is wrong")
   end sub
   
   private function balance_point() as balance.point
      dim spec = evaporative_condenser_chiller_mocks.default_spec
      
      dim logger = new logger()
      logger.log(spec)
      
      config.db
      dim chiller = get_chiller("35E2SD100", 230)
      logger.log(chiller)
      
      dim evaporators = get_evaporators(chiller, spec)
      logger.log(evaporators)
      
      dim balance = new balance()
      dim points = balance.run(chiller, evaporators, spec)
      
      return points.at(spec.leaving_fluid_temp, spec.ambient)
   end function
   
end class