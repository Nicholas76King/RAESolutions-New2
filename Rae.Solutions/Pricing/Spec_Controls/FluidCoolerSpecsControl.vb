Imports Rae.RaeSolutions.Business.Entities
Imports Rae.Reporting.CrystalReports

Public Class FluidCoolerSpecsControl

   Overrides Sub SetControlValues(equipment As EquipmentItem)
      Dim fluidCooler As FluidCoolerEquipmentItem
      fluidCooler = equipment

      With fluidCooler
         Me.txtSpecialInstructions.Text = .special_instructions
         Me.txtTag.Text = .tag
      End With

      With fluidCooler.common_specs
         Me.txtAltitude.Text = .Altitude.ToString
         If .ControlVoltage IsNot Nothing Then
            Me.cboControlVoltage.SelectedIndex = Me.cboControlVoltage.Items.IndexOf(.ControlVoltage.ToString)
         End If
         Me.txtHeight.Text = .Height.ToString
         Me.txtLength.Text = .Length.ToString
         Me.txtMca.Text = .Mca.ToString()
         Me.txtEstOperatingWeight.Text = .OperatingWeight.ToString()
         Me.txtRla.Text = .Rla.ToString()
         Me.txtEstShippingWeight.Text = .ShippingWeight.ToString()
         If .UnitVoltage IsNot Nothing Then
            Me.cboUnitVoltage.SelectedIndex = Me.cboUnitVoltage.Items.IndexOf(.UnitVoltage.ToString())
         End If
         Me.txtWidth.Text = .Width.ToString
      End With

      With fluidCooler.Specs
         Me.txtAmbientTemp.Text = .AmbientTemp.ToString()
         Me.txtCapacity.Text = .Capacity.ToString()
         Me.txtEnteringFluidTemp.Text = .EnteringFluidTemp.ToString()
         Me.txtFlow.Text = .Flow.ToString()
         If .Fluid IsNot Nothing Then
            Me.cboFluid.SelectedIndex = Me.cboFluid.Items.IndexOf(.Fluid)
         End If
         Me.txtGlycolPercent.Text = .GlycolPercent.ToString()
         Me.txtLeavingFluidTemp.Text = .LeavingFluidTemp.ToString()
      End With

   End Sub


   Overrides Sub GetControlValues(ByRef equipment As Business.Entities.EquipmentItem)
      Dim fluidCooler As FluidCoolerEquipmentItem

      fluidCooler = equipment

      With fluidCooler
         .special_instructions = Me.txtSpecialInstructions.Text
         .tag = Me.txtTag.Text
      End With

      With fluidCooler.common_specs
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

      With fluidCooler.Specs
         .AmbientTemp.set_to(Me.txtAmbientTemp.Text.Trim)
         .Capacity.set_to(Me.txtCapacity.Text.Trim)
         .EnteringFluidTemp.set_to(Me.txtEnteringFluidTemp.Text.Trim)
         .Flow.set_to(Me.txtFlow.Text.Trim)
         If Me.cboFluid.SelectedItem IsNot Nothing Then
            .Fluid = Me.cboFluid.SelectedItem.ToString
         End If
         .GlycolPercent.set_to(Me.txtGlycolPercent.Text.Trim)
         .LeavingFluidTemp.set_to(Me.txtLeavingFluidTemp.Text.Trim)
      End With

   End Sub


   Private Sub numberTextBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
   Handles txtAltitude.KeyDown, txtAmbientTemp.KeyDown, txtCapacity.KeyDown, _
   txtEnteringFluidTemp.KeyDown, txtEstOperatingWeight.KeyDown, txtEstShippingWeight.KeyDown, _
   txtFlow.KeyDown, txtGlycolPercent.KeyDown, txtHeight.KeyDown, txtLeavingFluidTemp.KeyDown, _
   txtLength.KeyDown, txtMca.KeyDown, txtRla.KeyDown, txtWidth.KeyDown
      e.SuppressKeyPress = Not key_code.is_number(e.KeyCode)
   End Sub

End Class
