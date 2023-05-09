Imports Rae.RaeSolutions.Reports

class fluid_cooler_pricing_presenter : inherits equipment_pricing_presenter_base

   Sub New(equipView As EquipmentForm, mainView As MainForm)
      MyBase.New(equipView, mainView)
   End Sub

   protected overrides function create_order_write_up as order_write_up_base
      return new fluid_cooler_order_write_up(equipView)
   end function

   protected overrides function create_submittal as accessories_base
      return new fluid_cooler_accessories(equipView)
   end function

    Sub show_order_write_up()
        Dim junk As String = ""
        create_order_write_up.show(False, junk)
    End Sub


end class

class fluid_cooler_grabber
   private control as FluidCoolerSpecsControl

   sub new(screen as EquipmentForm)
      control = screen.specsControl
   end sub

   function grab as bag
      dim bag as bag
      bag.ambient = control.txtAmbientTemp.Text.F
      bag.entering_temperature = control.txtEnteringFluidTemp.Text.F
      bag.leaving_temperature = control.txtLeavingFluidTemp.Text.F
      bag.unit_voltage = control.cboUnitVoltage.SelectedItem
      bag.control_voltage = control.cboControlVoltage.SelectedItem
      bag.rla = control.txtRla.Text
      bag.mca = control.txtMca.Text
      if control.txtLength.Text.is_set or control.txtWidth.Text.is_set or control.txtHeight.Text.is_set
         bag.dimensions = control.txtLength.Text & "x" & 
                          control.txtWidth.Text & "x" & 
                          control.txtHeight.Text & " in."
      end if
      bag.shipping_weight = control.txtEstShippingWeight.Text
      if bag.shipping_weight.is_set then bag.shipping_weight &= " lbs"
      bag.operating_weight = control.txtEstOperatingWeight.Text
      if bag.operating_weight.is_set then bag.operating_weight &= " lbs"
      bag.glycol = control.cboFluid.SelectedItem
      bag.gpm = control.txtFlow.Text
      bag.tag = control.txtTag.Text
      bag.special_instructions = control.txtSpecialInstructions.Text
      return bag
   end function

   structure bag
      public ambient, entering_temperature, leaving_temperature as string
      public unit_voltage, control_voltage, rla, mca as string
      public dimensions, shipping_weight, operating_weight, glycol, gpm, tag, special_instructions as string
   end structure
end class