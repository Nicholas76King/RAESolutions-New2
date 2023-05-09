Imports Rae.solutions.unit_coolers.selections

Namespace unit_cooler_selection

    Public Interface i_view
        Event user_set_room_temperature(ByVal room_temperature As Double, ByVal td As Double)
        Event user_set_td(ByVal room_temperature As Double, ByVal td As Double)
        Event user_wants_to_find_unit_coolers(ByVal input As unit_cooler_input, ByVal isEmployee As Boolean, sp As Decimal)
        Property suction_temperature As Double
        Sub initialize(ByVal unit_cooler As unit_cooler_input)
        Sub set_unit_cooler_results(ByVal unit_coolers As system.data.datatable)
    End Interface



    Public Class view : Implements i_view

        Event user_set_room_temperature(ByVal room_temperature As Double, ByVal td As Double) _
        Implements i_view.user_set_room_temperature

        Event user_set_td(ByVal room_temperature As Double, ByVal td As Double) _
        Implements i_view.user_set_td

        Event user_wants_to_find_unit_coolers(ByVal input As unit_cooler_input, ByVal isEmployee As Boolean, sp As Decimal) _
   Implements i_view.user_wants_to_find_unit_coolers

        Property suction_temperature As Double _
        Implements i_view.suction_temperature

        Sub initialize(ByVal unit_cooler As unit_cooler_input) _
        Implements i_view.initialize
            _total_capacity = unit_cooler.total_capacity
            _unit_cooler_quantity = unit_cooler.unit_cooler_quantity
            _room_temperature = unit_cooler.room_temperature
            _td = unit_cooler.td
            _series = unit_cooler.series
            _refrigerant = unit_cooler.refrigerant
        End Sub

        Sub set_unit_cooler_results(ByVal unit_coolers As system.data.datatable) _
        Implements i_view.set_unit_cooler_results

        End Sub

        Sub simulate_user_changed_room_temperature(ByVal room_temperature As Double)
            RaiseEvent user_set_room_temperature(room_temperature, _td)
        End Sub

        Sub simulate_user_changed_td(ByVal td As Double)
            RaiseEvent user_set_td(_room_temperature, td)
        End Sub

        Private _total_capacity, _room_temperature, _td As Double
        Private _unit_cooler_quantity As Integer
        Private _series, _refrigerant As String

    End Class

End Namespace