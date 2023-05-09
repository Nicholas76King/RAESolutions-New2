<TestClass>
public class condensing_unit_specifications_ : inherits test_base

    <TestMethod>
    sub are_equal
      dim x = new condensing_unit_specifications
      x.ambient.set_to(95)
      dim y = new condensing_unit_specifications
      y.ambient.set_to(95)

      assert( x.equals(y) )
    end sub

    <TestMethod>
    sub are_not_equal
      dim x = new condensing_unit_specifications
      x.ambient.set_to(95)
      dim y = new condensing_unit_specifications

      assert( not x.equals(y) )
    end sub

    <TestMethod>
    sub clone
      dim x = new condensing_unit_specifications
      x.ambient.set_to(95)
      x.capacity_1.set_to(100000)
      x.capacity_2.set_to(111111)
      x.evaporating_temperature.set_to(34)
      x.refrigerant = "R507"
      x.suction.set_to(35)

      dim y = x.clone

      assert( x.equals(y) )
    end sub

end class
