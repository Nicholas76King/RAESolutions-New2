class pump_order_write_up : inherits order_write_up_base
   sub new(screen as EquipmentForm)
      mybase.new(screen, reports.file_paths.pump_order_write_up_file_path)
      text.add("title", "Pump Package Order Write Up")

      dim bag = new pump_grabber(screen).grab
      text.add("unit_voltage", bag.unit_voltage)
      text.add("control_voltage", bag.control_voltage)
      text.add("tag", bag.tag)
      text.add("special_instructions", bag.special_instructions)
      text.add("manufacturer", bag.manufacturer)
      text.add("flow", bag.flow)
      text.add("head", bag.head)
      text.add("system", bag.system)
   end sub
end class

class pump_grabber
   private control as PumpSpecsControl
   private screen as EquipmentForm

   sub new(screen as pump_package_pricing_screen)
      me.screen = screen
      control = screen.specsControl
   end sub

   function grab as bag
      dim bag as bag
      bag.control_voltage = control.cboControlVoltage.SelectedItem
      bag.unit_voltage = control.cboUnitVoltage.SelectedItem
      bag.tag = control.txtTag.Text
      bag.special_instructions = control.txtSpecialInstructions.Text
      bag.manufacturer = control.pumpView.Manufacturer
      bag.flow = control.pumpView.Flow
      bag.head = control.pumpView.Head
      bag.system = control.pumpView.Sys
      dim has_open_tank = screen.grabEquipment.options.Contains("HT05")
      bag.open_tank_note = if(has_open_tank, "Note: Open tank must be located above connected loads or overflow may occur", "")
      return bag
   end function
   
   structure bag
      public tag, special_instructions, unit_voltage, control_voltage as string
      public manufacturer, flow, head, system, open_tank_note as string
   end structure
end class