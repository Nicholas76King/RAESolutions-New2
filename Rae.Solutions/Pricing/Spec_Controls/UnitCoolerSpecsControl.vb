Imports Rae.RaeSolutions.Business.Entities
Imports Rae.Reporting.CrystalReports
imports rae.solutions.group

Public Class UnitCoolerSpecsControl

   property division as string

   Overrides Sub SetControlValues(equipment As EquipmentItem)
      Dim unit_cooler As unit_cooler
      unit_cooler = equipment

      With unit_cooler
         division = .division
         Me.txtSpecialInstructions.Text = .special_instructions
         Me.txtTag.Text = .tag
      End With

      With unit_cooler.common_specs
         Me.txtAltitude.Text              = .Altitude.ToString
         Me.cboControlVoltage.SelectedIndex = Me.cboControlVoltage.Items.IndexOf(.ControlVoltage.ToString)
         Me.txtHeight.Text                = .Height.ToString
         Me.txtLength.Text                = .Length.ToString
         Me.txtMca.Text                   = .Mca.ToString()
         Me.txtEstOperatingWeight.Text    = .OperatingWeight.ToString()
         Me.txtRla.Text                   = .Rla.ToString()
         Me.txtEstShippingWeight.Text     = .ShippingWeight.ToString()
         Me.cboUnitVoltage.SelectedIndex  = Me.cboUnitVoltage.Items.IndexOf(.UnitVoltage.ToString())
         Me.txtWidth.Text                 = .Width.ToString
      End With

      With unit_cooler
         Me.txtBoxTemp.Text         = .box_temperature.ToString
         Me.txtCondensingTemp.Text  = .condensing_temperature.ToString
         Me.txtEvaporatorTemp.Text  = .evaporator_temperature.ToString
         Me.txtLiquidTemp.Text      = .liquid_temperature.ToString
         Me.txtTempDifference.Text  = .temperature_difference.ToString
         Me.txtUnitCapacity.Text    = .Capacity.ToString
         If .unit_cooler_type IsNot Nothing Then
            Select Case .unit_cooler_type.ToString()
               Case "DX"      : radDx.Checked = True
               Case "Flooded" : radFlooded.Checked = True
               Case "Recirc"  : radRecirc.Checked = True
            End Select
         End If
         
         If .refrigerant IsNot Nothing Then _
            Me.cboRefrigerant.SelectedIndex = Me.cboRefrigerant.Items.IndexOf(.refrigerant)
         fanVoltageCombo.SelectedIndex     = fanVoltageCombo.Items.IndexOf(.fan_voltage.ToString)
         defrostVoltageCombo.SelectedIndex = defrostVoltageCombo.Items.IndexOf(.defrost_voltage.ToString)
      End With
   End Sub


   Overrides Sub GetControlValues(ByRef equipment As EquipmentItem)
      Dim unitCooler As unit_cooler

      unitCooler = equipment

      With unitCooler
         .special_instructions = Me.txtSpecialInstructions.Text
         .tag = Me.txtTag.Text
      End With

      With unitCooler.common_specs
         .Altitude.set_to(Me.txtAltitude.Text.Trim)
         If Me.cboControlVoltage.SelectedItem IsNot Nothing Then
            .ControlVoltage.Parse(Me.cboControlVoltage.SelectedItem.ToString)
         End If
         .Height.set_to(Me.txtHeight.Text.Trim)
         .Length.set_to(Me.txtLength.Text.Trim)
         .Mca.set_to(Me.txtMca.Text.Trim)
         .OperatingWeight.set_to(Me.txtEstOperatingWeight.Text.Trim)
         .Rla.set_to(Me.txtRla.Text.Trim)
         .ShippingWeight.set_to(Me.txtEstShippingWeight.Text.Trim)
         If Me.cboUnitVoltage.SelectedItem IsNot Nothing Then
            .UnitVoltage.Parse(Me.cboUnitVoltage.SelectedItem.ToString)
         End If
         .Width.set_to(Me.txtWidth.Text.Trim)
      End With

      With unitCooler
         .box_temperature.set_to(Me.txtBoxTemp.Text.Trim)
         .Capacity.set_to(Me.txtUnitCapacity.Text.Trim)
         .condensing_temperature.set_to(Me.txtCondensingTemp.Text.Trim)
         .evaporator_temperature.set_to(Me.txtEvaporatorTemp.Text.Trim)
         .liquid_temperature.set_to(Me.txtLiquidTemp.Text.Trim)
         .refrigerant = cboRefrigerant.SelectedItem
         .temperature_difference.set_to(Me.txtTempDifference.Text.Trim)
         If fanVoltageCombo.SelectedItem IsNot Nothing Then _
            .fan_voltage.Parse(fanVoltageCombo.SelectedItem.ToString)
         If defrostVoltageCombo.SelectedItem IsNot Nothing Then _
            .defrost_voltage.Parse(defrostVoltageCombo.SelectedItem.ToString)
            
         If radDx.Checked Then
            .unit_cooler_type = "DX"
         ElseIf radFlooded.Checked Then
            .unit_cooler_type = "Flooded"
         ElseIf radRecirc.Checked Then
            .unit_cooler_type = "Recirc"
         Else
            .unit_cooler_type = ""
         End If
      End With
   End Sub


   Private Sub numberTextBox_KeyDown(sender As Object, e As KeyEventArgs) _
   Handles txtAltitude.KeyDown,        txtBoxTemp.KeyDown,     txtCondensingTemp.KeyDown, _
           txtEvaporatorTemp.KeyDown,  txtLiquidTemp.KeyDown,  txtTempDifference.KeyDown, _
           txtUnitCapacity.KeyDown
      e.SuppressKeyPress = Not key_code.is_number(e.KeyCode)
   End Sub

    Private Sub txtEvaporatorTemp_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEvaporatorTemp.LostFocus
        Dim equipmentForm As New EquipmentForm
        equipmentForm = ProjectInfo.Viewer.GetActiveForm()
        equipmentForm.FaceVelocityInRange()
    End Sub
End Class
