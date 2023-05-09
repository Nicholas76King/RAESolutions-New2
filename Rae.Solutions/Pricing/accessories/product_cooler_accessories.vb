class product_cooler_accessories : inherits accessories_base
   sub new(screen as EquipmentForm)
      mybase.new(screen, reports.file_paths.product_cooler_accessories_file_path)

      dim product_cooler_bag = new product_cooler_pricing_grabber(screen).grab
      text.add("refrigerant", product_cooler_bag.refrigerant)
      text.add("evaporating_temperature", product_cooler_bag.evaporating_temperature)
      text.add("box_temperature", product_cooler_bag.box_temperature)
      text.add("td", product_cooler_bag.td)
        text.Add("control_voltage", product_cooler_bag.control_voltage)




        ' text.Add("motor_voltage", "1")
   end sub

end class