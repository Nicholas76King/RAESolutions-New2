Class condenser_pricing_presenter : Inherits equipment_pricing_presenter_base
   Sub New(equipmentView As condenser_pricing_screen, mainView As MainForm)
      MyBase.New(equipmentView, mainView)
   End Sub
   
   protected overrides function create_submittal as accessories_base
      return new condenser_accessories(equipView)
   end function
   
   protected overrides function create_order_write_up as order_write_up_base
      return new condenser_order_write_up(equipView)
   end function

    Sub show_order_write_up()
        Dim junk As String = ""

        create_order_write_up.show(False, junk)
    End Sub

end class

class condenser_grabber
   private screen as condenser_pricing_screen
   private control as CondenserSpecsControl

   sub new(screen as condenser_pricing_screen)
      me.screen = screen
      control = screen.specsControl
   end sub

   function grab as bag
      dim bag as bag
      bag.refrigerant = control.cboRefrigerant.SelectedItem
      bag.ambient = control.txtAmbientTemp.Text.F
      bag.td = control.txtCondenserTD.Text.F
      bag.unit_voltage = control.cboUnitVoltage.SelectedItem
      bag.control_voltage = control.cboControlVoltage.SelectedItem
      bag.tag = control.txtTag.Text
      bag.special_instructions = control.txtSpecialInstructions.Text

      bag.total_heat_rejection_1 = control.txtTotalHeatRejection1.Text
      bag.total_heat_rejection_2 = control.txtTotalHeatRejection2.Text
      bag.total_heat_rejection_3 = control.txtTotalHeatRejection3.Text
      bag.total_heat_rejection_4 = control.txtTotalHeatRejection4.Text

      bag.total_heat_rejection_2_label = if(bag.total_heat_rejection_2.is_not_set, "", "Circuit 2 THR")
      bag.total_heat_rejection_3_label = if(bag.total_heat_rejection_3.is_not_set, "", "Circuit 3 THR")
      bag.total_heat_rejection_4_label = if(bag.total_heat_rejection_4.is_not_set, "", "Circuit 4 THR")
      return bag
   end function

   structure bag
      public refrigerant, ambient, td, tag, special_instructions as string
      public unit_voltage, control_voltage as string
      public total_heat_rejection_1, total_heat_rejection_2, total_heat_rejection_3, total_heat_rejection_4 as string
      public total_heat_rejection_2_label, total_heat_rejection_3_label, total_heat_rejection_4_label as string
   end structure
end class