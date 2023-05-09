Class condensing_unit_pricing_presenter : Inherits equipment_pricing_presenter_base

   Sub New(equipView As EquipmentForm, mainView As MainForm)
      MyBase.New(equipView, mainView)
   End Sub

   protected overrides function create_order_write_up() as order_write_up_base
      return new condensing_unit_order_write_up(equipView)
   end function

   protected overrides function create_submittal as accessories_base
      return new condensing_unit_accessories(equipview)
   end function

    Sub show_order_write_up()
        Dim junk As String = ""

        create_order_write_up.show(False, junk)
    End Sub




End Class

class condensing_unit_grabber
   private screen as EquipmentForm
   private control as CondensingUnitSpecsControl

   sub new(screen as EquipmentForm)
      me.screen = screen
      control = screen.specsControl
   end sub

   function grab as bag
      dim bag as bag
      bag.altitude = control.txtAltitude.Text.append(" ft")
      bag.refrigerant = control.cboRefrigerant.SelectedItem
      bag.ambient = control.txtAmbientTemp.Text.F
      bag.suction = control.txtSuctionTemp.Text.F
      bag.evaporating_temperature = control.txtEvapTemp.Text.F
      bag.capacity_1 = control.txtCapacity1.Text.append(" " & bag.capacity_units)
      bag.capacity_2 = control.txtCapacity2.Text.append(" " & bag.capacity_units)
      bag.capacity_units = control.lblCapacity1Units.Text
      bag.dimensions = control.txtLength.Text & "x" & control.txtWidth.Text & "x" & control.txtHeight.Text
      bag.shipping_weight = control.txtEstShippingWeight.Text.lbs
      bag.operating_weight = control.txtEstOperatingWeight.Text.lbs
      bag.unit_voltage = control.cboUnitVoltage.SelectedItem
      bag.control_voltage = control.cboControlVoltage.SelectedItem
      bag.rla = control.txtRla.Text
      bag.mca = control.txtMca.Text
      bag.tag = control.txtTag.Text
      bag.special_instructions = control.txtSpecialInstructions.Text
      return bag
   end function

   structure bag
      public refrigerant, ambient, suction, evaporating_temperature as string
      public altitude, capacity_1, capacity_2, capacity_units as string
      public dimensions, operating_weight, shipping_weight as string
      public unit_voltage, control_voltage, rla, mca, tag, special_instructions as string
   end structure
end class