option strict off

imports rae.solutions.cu_uc_balances

partial public class cu_uc_balance_window

   property balance as double
   	get
   		return txt_balance.text
   	end get
   	set(value as double)
   		txt_balance.text = value
   	end set
   end property
   
   friend function grab_unit_coolers_for_capacity() as units
      dim unit_coolers = new units()
      
      dim unit_cooler_1 = grab_unit_cooler_for_capacity(txt_unit_cooler_capacity_1, txt_unit_cooler_quantity_1)
      if unit_cooler_1 isnot nothing then _
         unit_coolers.add(unit_cooler_1)
      
      dim unit_cooler_2 = grab_unit_cooler_for_capacity(txt_unit_cooler_capacity_2, txt_unit_cooler_quantity_2)
      if unit_cooler_2 isnot nothing then _
         unit_coolers.add(unit_cooler_2)
         
      dim unit_cooler_3 = grab_unit_cooler_for_capacity(txt_unit_cooler_capacity_3, txt_unit_cooler_quantity_3)
      if unit_cooler_3 isnot nothing then _
         unit_coolers.add(unit_cooler_3)
         
      dim custom_unit_cooler = grab_custom_unit_cooler_for_capacity(chk_custom_unit_cooler.checked, txt_custom_uc_capacity, txt_custom_uc_quantity)
      if custom_unit_cooler isnot nothing then _
         unit_coolers.add(custom_unit_cooler)
         
      return unit_coolers
   end function
   
   private function grab_custom_unit_cooler_for_capacity(selected as boolean, txt_capacity as textbox, txt_quantity as textbox) as unit
      dim quantity = convertNull.toInteger(txt_quantity.text.trim)
      
      if not selected or quantity <= 0 then _
         return nothing
      
      dim capacity = convertNull.toDouble(txt_capacity.text.trim)
         
      return new unit(capacity, quantity)
   end function
   
   private function grab_unit_cooler_for_capacity(txt_capacity as textbox, txt_quantity as textbox) as unit
      dim quantity = convertNull.toInteger(txt_quantity.text.trim)
      if quantity = 0 then _
         return nothing
      
      dim capacity = convertNull.toDouble(txt_capacity.text.trim)
      dim unit_cooler = new unit(capacity, quantity)
      return unit_cooler
   end function
   
   friend function grab_condensing_unit_for_capacity() as unit
      dim capacity = grab_condensing_unit_capacity()
      dim quantity = grab_condensing_unit_quantity()
      return new unit(capacity, quantity)
   end function
   
   private function grab_condensing_unit_capacity() as double
      dim capacity as double

      if condensingunit1radiobutton.checked then
         capacity = convertnull.todouble(txt_condensing_unit_1_capacity.text)
      elseif condensingunit2radiobutton.checked then
         capacity = convertnull.todouble(txt_condensing_unit_2_capacity.text)
      elseif condensingunit3radiobutton.checked then
         capacity = convertnull.todouble(txt_condensing_unit_3_capacity.text)
      elseif customcondensingunitradiobutton.checked then
         capacity = convertnull.todouble(customcondenserevapcapacitytextbox.text.trim)
      end if

      return capacity
   end function
   
   private function grab_condensing_unit_quantity() as integer
      return convertnull.tointeger(txt_condensing_unit_quantity.text.trim)
   end function
   
end class
