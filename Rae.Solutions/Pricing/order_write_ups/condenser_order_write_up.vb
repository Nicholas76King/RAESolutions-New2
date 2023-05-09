class condenser_order_write_up : inherits order_write_up_base
   sub new(screen as EquipmentForm)
      mybase.new(screen, reports.file_paths.condenser_order_write_up_file_path)
      text.add("title", "Condenser Order Write Up")

      dim bag = new condenser_grabber(screen).grab
      text.add("ambient", bag.ambient)
      text.add("approach", bag.td)
      text.add("refrigerant", bag.refrigerant)
      text.add("unit_voltage", bag.unit_voltage)
      text.add("control_voltage", bag.control_voltage)
      text.add("total_heat_rejection_1", bag.total_heat_rejection_1)
      text.add("total_heat_rejection_2_label", bag.total_heat_rejection_2_label)
      text.add("total_heat_rejection_2", bag.total_heat_rejection_2)
      text.add("total_heat_rejection_3_label", bag.total_heat_rejection_3_label)
      text.add("total_heat_rejection_3", bag.total_heat_rejection_3)
      text.add("total_heat_rejection_4_label", bag.total_heat_rejection_4_label)
      text.add("total_heat_rejection_4", bag.total_heat_rejection_4)
      text.add("tag", bag.tag)
      text.add("special_instructions", bag.special_instructions)
   end sub
end class