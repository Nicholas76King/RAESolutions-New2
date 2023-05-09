Imports Rae.RaeSolutions.Business
Imports rae.solutions
Imports rae.solutions.evaporative_condenser_chillers

<TestClass> _
public class approach_ : inherits test_base

   private employee as new user("casey", "pass", "casey", "joyce", user_group.employee, access_level.ALL)
   
   private function create_point() as balance.point
      dim point = new balance.point()
      point.ambient = 78
      point.leaving_fluid_temp = 35
      return point
   end function
   
   <TestMethod> _
   sub is_valid_for_employee_at_5
      dim point = create_point()
      point.approach = 5
      
      dim validator = new approach_is_in_range(point, employee)
      validator.validate()
      assert(validator.is_valid)
      assert( validator.messages.count = 0 )
   end sub
   
   <TestMethod> _
   sub is_invalid_below_5_for_employee
      dim point = create_point()
      point.approach = 4
      dim validator = new approach_is_in_range(point, employee).validate()
      assert( validator.is_invalid )
      assert( validator.messages(0).description = "approach, 4.0, is below minimum, 5" )
   end sub
   
   <TestMethod> _
   Sub is_invalid_below_6_for_rep
      dim point = create_point()
      point.approach = 5
      dim rep = new user("reppy", "pass", "reppy", "mcrepton", user_group.rep, access_level.ALL)
      dim validator = new approach_is_in_range(point, rep).validate()
      assert( validator.is_invalid )
   End Sub
   
   <TestMethod> _
   sub is_invalid_above_12
      dim point = create_point()
      point.approach = 15
      dim validator = new approach_is_in_range(point, employee).validate()
      assert( validator.is_invalid )
      assert( validator.messages(0).description = "approach, 15.0, is above max, 12" )
   end sub
   
end class
