class fluid_cooler_accessories : inherits accessories_base

   sub new(screen as EquipmentForm)
      mybase.new(screen, reports.file_paths.fluid_cooler_accessories_file_path)

      dim fluid_cooler_bag = new fluid_cooler_grabber(screen).grab
      text.add("ambient", fluid_cooler_bag.ambient)
      text.add("entering_temperature", fluid_cooler_bag.entering_temperature)
      text.add("leaving_temperature", fluid_cooler_bag.leaving_temperature)
      text.add("unit_voltage", fluid_cooler_bag.unit_voltage)
      text.add("control_voltage", fluid_cooler_bag.control_voltage)
      text.add("rla", fluid_cooler_bag.rla)
      text.add("mca", fluid_cooler_bag.mca)
      text.add("glycol", fluid_cooler_bag.glycol)
      text.add("gpm", fluid_cooler_bag.gpm)
      text.add("dimensions", fluid_cooler_bag.dimensions)
      text.add("shipping_weight", fluid_cooler_bag.shipping_weight)
      text.add("operating_weight", fluid_cooler_bag.operating_weight)
   end sub

end class