imports Rae.RaeSolutions.Business.Entities
imports rae.solutions
Imports rae.solutions.evaporative_condenser_chillers
Imports rae.solutions.chiller_evaporators
Imports System.Math

<TestClass> _
public class evaporative_condenser_chiller_35E2SS50_ : inherits test_chiller_base

   <TestMethod> _
   sub balance_point_is_correct
      dim point = balance_point()
      
      assert( round(point.evaporating_temp, 1) = 35.6,   "evaporating temperature is wrong")
      assert( round(point.condensing_temp, 1) = 102.8,   "condensing temperature is wrong")
      assert( round(point.capacity, 1) = 38.8,           "capacity is wrong")
      assert( round(point.compressor_kw, 1) = 34.9,      "compressor kw is wrong")
      assert( round(point.unit_kw, 1) = 40,              "unit kw is wrong")
      assert( round(point.gpm, 1) = 93.1,                "gpm is wrong")
      assert( round(point.fluid_pressure_drop, 2) = 3.19,"fluid pressure drop is wrong")
      assert( round(point.compressor_kw_per_ton, 1) = .9,"compressor efficiency is wrong")
      assert( round(point.unit_kw_per_ton, 2) = 1.03,    "unit efficiency is wrong")
   end sub
   
   
   private function balance_point() as balance.point
      dim spec = evaporative_condenser_chiller_mocks.default_spec
      
      config.db
      dim chiller = get_chiller("35E2SS50", 230)
      dim evaporators = get_evaporators(chiller, spec)
      
      dim balance = new balance()
      dim points = balance.run(chiller, evaporators, spec)

      return points.at(spec.leaving_fluid_temp, spec.ambient)
   end function
   
end class
   
public class test_chiller_base : inherits test_base
   
   protected function get_chiller(model as string, voltage as integer) as chiller
      dim chiller = new repository().get(model, voltage)
      return chiller
   end function
   
   ' todo: right now the evaporator length needs to be retrieved before the evaporators can be retrieved, is there a better way?
   protected function get_evaporators(chiller as chiller, spec as spec) as Evaporator_list
      dim evaporator_repo = new Evaporator_repository()
      dim evaporator = evaporator_repo.get_evaporator_by_part_number(chiller.evaporator_model)
      
      dim evaporator_service = new Evaporator_service_factory().create()
      
      dim evaporator_spec As Evaporator_spec
      evaporator_spec.authorization       = 1
      evaporator_spec.entering_fluid_temp = spec.leaving_fluid_temp + spec.range
      evaporator_spec.evaporating_temp    = 33
      evaporator_spec.fluid               = StandardRefrigeration.Fluid.Water
      evaporator_spec.glycol_percentage   = 0
      evaporator_spec.leaving_fluid_temp  = spec.leaving_fluid_temp
      evaporator_spec.length              = evaporator.length
      evaporator_spec.num_circuits        = CInt(chiller.num_circuits)
      evaporator_spec.refrigerant         = StandardRefrigeration.Refrigerant.R134a
      
      dim evaporators = evaporator_service.get_approach_range(chiller.evaporator_model, evaporator_spec)
      return evaporators
   end function
   
end class