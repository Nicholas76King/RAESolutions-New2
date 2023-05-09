<TestClass>
public class pricing_ : inherits test_base

   <TestMethod>
   sub clone_and_equals_works
      dim y = new equipment_pricing
      y.base_list_price_is_overridden = false
      y.commission_rate = 1
      y.freight = 2
      y.list_price = 3
      y.multiplier_code = nothing
      y.other_description = "something"
      y.other_price = 100
      y.others.add("technical instructions", 20)
      y.overridden_base_list_price = 0
      y.par_multiplier = 0.123
      y.quantity = 2
      y.start_up = 2000
      y.warranty = 1500

      dim x = y.clone
      assert( x.equals(y) )

      y.warranty = 2
      assert( not x.equals(y) )
   end sub

end class