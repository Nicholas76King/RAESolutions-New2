imports rae.solutions.air_cooled_chillers_balance
imports rae.solutions.chillers
imports rae.math.comparisons

<TestClass>
public class _30A0CS5_R22_standard_at_44_leaving_fluid_temperature_and_95_ambient : inherits test_base
   
   'private result as result

   '<TestInitialize>
   'sub initialize_test
   '   dim service = new balance_service()
   '   dim algorithm = new algorithm(service)
   '   dim chiller = new chiller()
   '   chiller.refrigerant = refrigerant.R22
   '   dim spec as spec
   '   spec.ambient = 95
   '   result = algorithm.run(chiller, spec)
   'end sub

   '<TestMethod>
   'sub ambient_is_95
   '   assert(result.ambient = 95)
   'end sub

   '<TestMethod>
   'sub evaporating_temperature_is_34
   '   assert( is_accurate(result.evaporating_temp, percentage:=1, expected:=34.5) )
   'end sub

end class
