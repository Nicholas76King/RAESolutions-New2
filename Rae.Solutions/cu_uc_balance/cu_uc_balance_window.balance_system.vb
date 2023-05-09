imports rae.solutions.cu_uc_balances.balance_system

partial public class cu_uc_balance_window

   private function create_balance_for_one_room() as balance
      dim spec = grab_spec()
      dim condensing_unit = grab_condensing_unit()
      dim unit_coolers = grab_unit_coolers()
      dim custom_unit_cooler = grab_custom_unit_cooler()
         
        Dim balance = New balance(condensing_unit, unit_coolers, custom_unit_cooler, spec, user)
      return balance
   end function

   private function create_balance_for_multiple_rooms() as balance
      dim range_spec = grab_range_spec()
      dim condensing_unit = grab_condensing_unit()
      dim unit_coolers = grab_unit_coolers()
      dim custom_unit_cooler = grab_custom_unit_cooler()

        Dim balance = New balance(condensing_unit, unit_coolers, custom_unit_cooler, range_spec, user)
      return balance
   end function

   private function grab_range_spec() as range_spec
      dim range_spec = new range_spec()

      range_spec.min_room_temp     = double.Parse(txt_min_room_temp.Text.Trim)
      range_spec.max_room_temp     = double.Parse(txt_max_room_temp.Text.Trim)
      range_spec.room_temp_step    = double.Parse(incrementRoomTemperatureTextBox.Text)
      range_spec.min_ambient       = double.Parse(txt_min_ambient.Text.Trim)
      range_spec.max_ambient       = double.Parse(txt_max_ambient.Text.Trim)
      range_spec.ambient_step      = double.Parse(incrementAmbientTemperatureTextBox.Text.Trim)
      range_spec.import(grab_spec())

      return range_spec
   end function

   private function grab_static_pressure_1() as double
      if not rbo_0_static_1.visible and not rbo_025_static_1.visible and not rbo_050_static_1.visible then
         return 0
      else if rbo_0_static_1.visible and rbo_0_static_1.checked then
         return 0
      else if rbo_025_static_1.visible and rbo_025_static_1.checked then 
         return 0.25
      else if rbo_050_static_1.visible and rbo_050_static_1.checked then
         return 0.5
      else
         throw new exception("selected static pressure cannot be determined.")
      end if
   end function

   private function grab_static_pressure_2() as double
      if not rbo_0_static_2.visible and not rbo_025_static_2.visible and not rbo_050_static_2.visible then
         return 0
      else if rbo_0_static_2.visible and rbo_0_static_2.checked then
         return 0
      else if rbo_025_static_2.visible and rbo_025_static_2.checked then 
         return 0.25
      else if rbo_050_static_2.visible and rbo_050_static_2.checked then
         return 0.5
      else
         throw new exception("selected static pressure cannot be determined.")
      end if
   end function

   private function grab_static_pressure_3() as double
      if not rbo_0_static_3.visible and not rbo_025_static_3.visible and not rbo_050_static_3.visible then
         return 0
      else if rbo_0_static_3.visible and rbo_0_static_3.checked then
         return 0
      else if rbo_025_static_3.visible and rbo_025_static_3.checked then 
         return 0.25
      else if rbo_050_static_3.visible and rbo_050_static_3.checked then
         return 0.5
      else
         throw new exception("selected static pressure cannot be determined.")
      end if
   end function

   private function grab_unit_coolers() as unit_cooler_list
      dim unit_coolers = new unit_cooler_list

      dim unit_cooler_model_1_is_selected = not string.isNullOrEmpty(txt_unit_cooler_model_1.text)
      if unit_cooler_model_1_is_selected then
         dim unit_cooler = new unit_cooler
         unit_cooler.model = grab_unit_cooler_model_1()
         unit_cooler.quantity = grab_unit_cooler_quantity_1()
         unit_cooler.static_pressure = grab_static_pressure_1()
         unit_coolers.add(unit_cooler)
      end if

      dim unit_cooler_model_2_is_selected = not string.isNullOrEmpty(txt_unit_cooler_model_2.text)
      if unit_cooler_model_2_is_selected then
         dim unit_cooler = new unit_cooler
         unit_cooler.model = grab_unit_cooler_model_2()
         unit_cooler.quantity = grab_unit_cooler_quantity_2()
         unit_cooler.static_pressure = grab_static_pressure_2()
         unit_coolers.add(unit_cooler)
      end if

      dim unit_cooler_model_3_is_selected = not string.isNullOrEmpty(txt_unit_cooler_model_3.text)
      if unit_cooler_model_3_is_selected then
         dim unit_cooler = new unit_cooler
         unit_cooler.model = grab_unit_cooler_model_3()
         unit_cooler.quantity = grab_unit_cooler_quantity_3()
         unit_cooler.static_pressure = grab_static_pressure_3()
         unit_coolers.add(unit_cooler)
      end if

      return unit_coolers
   end function

   private function grab_unit_cooler_model_1() as string
      return txt_unit_cooler_model_1.text
   end function

   private function grab_unit_cooler_model_2() as string
      return txt_unit_cooler_model_2.text
   end function

   private function grab_unit_cooler_model_3() as string
      return txt_unit_cooler_model_3.text
   end function

   private function grab_unit_cooler_quantity_1() as integer
      return convertNull.ToInteger(txt_unit_cooler_quantity_1.text)
   end function

   private function grab_unit_cooler_quantity_2() as integer
      return convertNull.ToInteger(txt_unit_cooler_quantity_2.text)
   end function

   private function grab_unit_cooler_quantity_3() as integer
      return convertNull.ToInteger(txt_unit_cooler_quantity_3.text)
   end function

   private function grab_custom_unit_cooler() as custom_unit_cooler
      if not chk_custom_unit_cooler.checked then return nothing

      dim custom_unit_cooler = new custom_unit_cooler()
      custom_unit_cooler.capacity = grab_custom_unit_cooler_capacity()
      custom_unit_cooler.quantity = grab_custom_unit_cooler_quantity()

      return custom_unit_cooler
   end function

   private function grab_custom_unit_cooler_quantity() as integer
      return convertNull.toInteger(txt_custom_uc_quantity.text)
   end function

   private function grab_custom_unit_cooler_capacity() as double
      return ConvertNull.ToDouble(txt_custom_uc_capacity.Text.Trim)
   end function

   private function grab_spec() as spec
      dim spec = new spec()

      spec.altitude           = grab_altitude()
      spec.ambient            = grab_ambient()
      spec.division           = AppInfo.Division
      spec.evaporating_temp   = grab_evaporating_temp()
      spec.room_temp          = grab_room_temp()
      spec.suction_temp       = grab_suction_temp()
      spec.suction_line_loss  = grab_suction_line_loss()

      return spec
   end function

   private function grab_condensing_unit() as condensing_unit
      dim condensing_unit as rae.solutions.cu_uc_balances.balance_system.condensing_unit

      condensing_unit.model = grab_condensing_unit_model()
      condensing_unit.refrigerant = grab_refrigerant()

      return condensing_unit
   end function

   private function grab_evaporating_temp() as double
      return grab_suction_temp + grab_suction_line_loss
   end function

end class
