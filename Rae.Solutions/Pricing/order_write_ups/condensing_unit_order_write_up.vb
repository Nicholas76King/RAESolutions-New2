class condensing_unit_order_write_up : inherits order_write_up_base
   sub new(screen as EquipmentForm)
      mybase.new(screen, reports.file_paths.condensing_unit_order_write_up_file_path)
      text.add("title", "Condensing Unit Order Write Up")

      dim bag = new condensing_unit_grabber(screen).grab
      text.add("altitude", bag.altitude)
      text.add("ambient", bag.ambient)
      text.add("capacity_1", bag.capacity_1)
      text.add("capacity_2", bag.capacity_2)
      text.add("control_voltage", bag.control_voltage)
      text.add("dimensions", bag.dimensions)
      text.add("evaporating_temperature", bag.evaporating_temperature)
      text.add("refrigerant", bag.refrigerant)
      text.add("suction", bag.suction)
      text.add("tag", bag.tag)
      text.add("unit_voltage", bag.unit_voltage)
      text.add("special_instructions", bag.special_instructions)
   end sub
end class