class product_cooler_order_write_up : inherits order_write_up_base
   sub new(screen as EquipmentForm)
      mybase.new(screen, reports.file_paths.product_cooler_order_write_up_file_path)
      text.add("title", "Product Cooler Order Write Up")

      dim bag = new product_cooler_pricing_grabber(screen).grab
      text.add("tag", bag.tag)
      text.add("special_instructions", bag.special_instructions)
      text.add("evaporating_temperature", bag.evaporating_temperature)
      text.add("box_temperature", bag.box_temperature)
      text.add("td", bag.td)
      text.add("refrigerant", bag.refrigerant)
        text.Add("control_voltage", bag.control_voltage)
        text.Add("motor_voltage", bag.motor_voltage)

        text.Add("FanMotorLocation", bag.FanMotorLocation)
        text.Add("BlowerDCPosition", bag.BlowerDCPosition)

   end sub
end class