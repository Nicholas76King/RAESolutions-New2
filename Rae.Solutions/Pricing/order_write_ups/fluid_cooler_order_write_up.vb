class fluid_cooler_order_write_up : inherits order_write_up_base
   sub new(screen as EquipmentForm)
      mybase.new(screen, reports.file_paths.fluid_cooler_order_write_up_file_path)
      text.add("title", "Fluid Cooler Order Write Up")

      dim bag = new fluid_cooler_grabber(screen).grab
      text.add("ambient", bag.ambient)
      text.add("entering_temperature", bag.entering_temperature)
      text.add("leaving_temperature", bag.leaving_temperature)
      text.add("gpm", bag.gpm)
      text.add("glycol", bag.glycol)
      text.add("unit_voltage", bag.unit_voltage)
      text.add("control_voltage", bag.control_voltage)
      text.add("tag", bag.tag)
      text.add("special_instructions", bag.special_instructions)
   end sub
end class
