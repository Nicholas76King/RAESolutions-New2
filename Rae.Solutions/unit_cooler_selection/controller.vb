imports rae.io.text
imports rae.solutions.unit_coolers.selections

namespace unit_cooler_selection


public class controller
   sub new(view as i_view)
      me.view = view

      dim default_unit_cooler as unit_cooler_input
      with default_unit_cooler
         .defrost_type = "A"
                .refrigerant = "R448a"
         .room_temperature = 45
         .series = "All"
         .td = 10
         .total_capacity = 100000
         .unit_cooler_quantity = 1
         .static_pressure = "0"
                .fan_quantity = "Any"
                .DOEModels = "No"
      end with
      view.initialize(default_unit_cooler)
   end sub

   sub handle_user_set_room_temperature(room_temperature as double, td as double) _
   handles view.user_set_room_temperature, view.user_set_td
      dim suction = room_temperature - td
      view.suction_temperature = suction
   end sub

        Sub handle_user_wants_to_find_unit_cooler(ByVal input As unit_cooler_input, ByVal isEmployee As Boolean, sp As Decimal) _
   Handles view.user_wants_to_find_unit_coolers
            Dim service = New rae.solutions.unit_coolers.service()

            Dim results = service.find_unit_cooler_results_for_selection(input, isEmployee, sp)

            view.set_unit_cooler_results(results)
        End Sub

   private withevents view as i_view
end class

end namespace