class unit_cooler_order_write_up : inherits order_write_up_base
   sub new(screen as EquipmentForm)
      mybase.new(screen, reports.file_paths.unit_cooler_order_write_up_file_path)
      text.add("title", "Unit Cooler Order Write Up")

      dim bag = new unit_cooler_specs_grabber(screen).grab
      text.add("box_temperature", bag.box_temperature)
      text.add("evaporating_temperature", bag.evaporating_temperature)
      text.add("td", bag.td)
      text.add("liquid_temperature", bag.liquid_temperature)
      text.add("condensing_temperature", bag.condensing_temperature)
      text.add("refrigerant", bag.refrigerant)
      text.add("capacity", bag.capacity)
      text.add("control_voltage", bag.control_voltage)
      text.add("fan_voltage", bag.fan_voltage)
      text.add("heater_voltage", bag.defrost_voltage)
      text.add("tag", bag.tag)
      text.add("special_instructions", bag.special_instructions)
      ' includes refrigerant indicator in model
      text.remove("model")
         dim equipment_bag = new equipment_grabber(screen).grab
         dim model as string
         if equipment_bag.custom_model.is_not_set then
            model = bag.model
         else
            model = equipment_bag.custom_model & " (Base:" & bag.model & ")"
         end if
      text.add("model", model)
   end sub

end class