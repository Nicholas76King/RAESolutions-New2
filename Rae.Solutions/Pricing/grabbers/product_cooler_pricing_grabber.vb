imports Rae.RaeSolutions.Business

class product_cooler_pricing_grabber
   private control as ProductCoolerSpecsControl

   sub new(screen as EquipmentForm)
      control = screen.specsControl
   end sub

   function grab as bag
      dim bag as bag
      bag.refrigerant = control.cboRefrigerant.SelectedItem
      bag.evaporating_temperature = control.txtEvaporatorTemp.Text.F
      bag.box_temperature = control.txtBoxTemp.Text.F
      bag.td = control.txtTempDifference.Text.F
      bag.control_voltage = control.cboControlVoltage.SelectedItem
      bag.tag = control.txtTag.Text
        bag.special_instructions = control.txtSpecialInstructions.Text
        bag.motor_voltage = control.cboUnitVoltage.SelectedItem


        If control.cboMotorLocation.SelectedItem IsNot Nothing Then
            bag.FanMotorLocation = control.cboMotorLocation.SelectedItem.ToString
        Else
            bag.FanMotorLocation = "Not Specified"
        End If


        If control.cboBlowerDCPosition.SelectedItem IsNot Nothing Then
            bag.BlowerDCPosition = control.cboBlowerDCPosition.SelectedItem.ToString
        Else
            bag.BlowerDCPosition = "Not Specified"
        End If


        Return bag
    End Function

    Structure bag
        Public evaporating_temperature, box_temperature, td As String
        Public refrigerant, control_voltage, tag, special_instructions As String
        Public motor_voltage As String
        Public FanMotorLocation As String
        Public BlowerDCPosition As String
    End Structure
end class