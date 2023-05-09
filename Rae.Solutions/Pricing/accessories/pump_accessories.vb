class pump_accessories : inherits accessories_base
   sub new(screen as EquipmentForm)
      mybase.new(screen, reports.file_paths.pump_accessories_file_path)

      dim bag = new pump_grabber(screen).grab
      text.add("manufacturer", bag.manufacturer)
      text.add("flow", bag.flow)
      text.add("head", bag.head)
      text.add("system", bag.system)
      text.add("unit_voltage", bag.unit_voltage)
      text.add("control_voltage", bag.control_voltage)
      text.add("open_tank_note", bag.open_tank_note)
   end sub   
end class