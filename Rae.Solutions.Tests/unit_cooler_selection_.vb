imports Rae.RaeSolutions.unit_cooler_selection
imports rae.solutions.unit_coolers.selections

<TestClass>
public class unit_cooler_selection_ : inherits test_base

   private function get_a_unit_cooler_to_test_with() as unit_cooler_input
      dim input as unit_cooler_input
      input.total_capacity = 48000
      input.unit_cooler_quantity = 1
      input.room_temperature = 45
      input.td = 15
      input.series = "BOC"
      input.refrigerant = "R404a"
      input.defrost_type = "A"
      return input
   end function

   private function get_a_view_to_test_with() as i_view
      return new view()
   end function

   <TestMethod>
   sub setting_room_temperature_updates_suction_temperature
      dim view = get_a_view_to_test_with()
      dim unit_cooler = get_a_unit_cooler_to_test_with()
      view.initialize(unit_cooler)

      dim controller = new controller(view)
      
      ctype(view, view).simulate_user_changed_room_temperature(46)
      assert(view.suction_temperature = 31)
   end sub

   <TestMethod>
   sub setting_td_updates_suction_temperature
      dim view = get_a_view_to_test_with()
      dim unit_cooler = get_a_unit_cooler_to_test_with()
      view.initialize(unit_cooler)

      dim controller = new controller(view)

      ctype(view, view).simulate_user_changed_td(10)
      assert(view.suction_temperature = 35)
   end sub
   'sub setting_series_updates_available_refrigerants
end class
