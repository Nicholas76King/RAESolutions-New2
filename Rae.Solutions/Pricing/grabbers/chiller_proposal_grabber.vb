imports rae.io.text

class chiller_proposal_grabber
   private control as chiller_specs_control
   
   sub new(specs_control as chiller_specs_control)
      me.control = specs_control
   end sub
   
   function grab() as bag
      dim bag as bag
      bag.tag = control.txtTag.text
      bag.ambient = control.txtAmbientTemp.text
      bag.solution = control.txtGlycolPercent.Text & "% " & control.cboFluid.text
      bag.refrigerant = control.cboRefrigerant.text
      bag.entering_fluid_temperature = control.txtEnteringFluidTemp.text
      bag.leaving_fluid_temperature = control.txtLeavingFluidTemp.text
      
      'performance
      bag.capacity = control.txtCapacity.text
      bag.gpm = control.txtFlow.text
      bag.evaporator_pressure_drop = control.txtEvaporatorPressureDrop.text
      'dimensions
      bag.dimensions = str("{0}""W x {1}""L x {2}""H", _
                           control.txtWidth.text, control.txtLength.text, control.txtHeight.text)
      bag.shipping_weight = control.txtEstShippingWeight.text
      bag.operating_weight = control.txtEstOperatingWeight.text
      bag.voltage = control.cboUnitVoltage.text
      bag.rla = control.txtRla.text
      bag.mca = control.txtMca.text
      bag.rla_2 = control.panCommonSpecs.controls("txt_rla_2").text
      bag.mca_2 = control.panCommonSpecs.controls("txt_mca_2").text
      bag.power_supply_quantity = if(string.isNullOrEmpty(bag.rla_2), "1", "2")
      bag.control_voltage = ConvertNull.ToString(control.cboControlVoltage.SelectedItem)
      bag.unit_efficiency = control.txt_unit_efficiency.text
      
      return bag
   end function
   
   structure bag
      public tag, solution, refrigerant as string
      public ambient, entering_fluid_temperature, leaving_fluid_temperature as string
      public capacity, gpm, evaporator_pressure_drop as string
      public dimensions, shipping_weight, operating_weight as string
      public rla, mca, rla_2, mca_2, power_supply_quantity as string
      public voltage, control_voltage, unit_efficiency as string
   end structure
end class
