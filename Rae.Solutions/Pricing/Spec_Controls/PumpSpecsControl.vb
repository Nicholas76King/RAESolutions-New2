Imports Rae.RaeSolutions.Business.Entities
Imports Rae.reporting.CrystalReports

Public Class PumpSpecsControl

    Private Sub me_Load() Handles Me.Load
        cboUnitVoltage.Items.Remove("460/1/60")
        cboUnitVoltage.Items.Remove("575/3/60")

        With cboControlVoltage
            .Items.Clear()
            .Items.Add("230/1/60")
            .Items.Add("208/1/60")
            .Items.Add("115/1/60")
            .Items.Add("115/24")
        End With
    End Sub

    Overrides Sub GetControlValues(ByRef unit As EquipmentItem)
        Dim pump As PumpEquipment = unit
        With pump
            .special_instructions = txtSpecialInstructions.Text
            .tag = txtTag.Text
            With .common_specs
                If cboControlVoltage.SelectedItem IsNot Nothing Then _
                   .ControlVoltage.Parse(cboControlVoltage.SelectedItem.ToString)
                If cboUnitVoltage.SelectedItem IsNot Nothing Then _
                   .UnitVoltage.Parse(cboUnitVoltage.SelectedItem.ToString)

                .Height.set_to(txtHeight.Text.Trim)
                .Length.set_to(txtLength.Text.Trim)
                .Width.set_to(txtWidth.Text.Trim)
                .Mca.set_to(txtMca.Text.Trim)
                .Rla.set_to(txtRla.Text.Trim)
                .OperatingWeight.set_to(txtEstOperatingWeight.Text.Trim)
                .ShippingWeight.set_to(txtEstShippingWeight.Text.Trim)
            End With
            .Flow.set_to(pumpView.Flow)
            .Head.set_to(pumpView.Head)
            .Manufacturer = pumpView.Manufacturer
            .System = pumpView.Sys
        End With
    End Sub

    Overrides Sub SetControlValues(ByVal unit As EquipmentItem)
        Dim pump As PumpEquipment = unit
        With pump
            txtSpecialInstructions.Text = .special_instructions
            txtTag.Text = .tag
            With .common_specs
                If .ControlVoltage IsNot Nothing Then _
                   cboControlVoltage.SelectedIndex = cboControlVoltage.Items.IndexOf(.ControlVoltage.ToString)
                If .UnitVoltage IsNot Nothing Then _
                   cboUnitVoltage.SelectedIndex = cboUnitVoltage.Items.IndexOf(.UnitVoltage.ToString)
                txtLength.Text = .Length.ToString
                txtWidth.Text = .Width.ToString
                txtHeight.Text = .Height.ToString
                txtMca.Text = .Mca.ToString
                txtRla.Text = .Rla.ToString
                txtEstOperatingWeight.Text = .OperatingWeight.ToString
                txtEstShippingWeight.Text = .ShippingWeight.ToString
            End With
            pumpView.Flow = .Flow.value_or_default(10)
            pumpView.Head = .Head.value_or_default(50)
            pumpView.Manufacturer = .Manufacturer
            pumpView.Sys = .System
            ' refreshes in case flow changed but other pump values didn't
            ' flow only updates on leave event which wouldn't otherwise get fired here
            pumpView.Refresh()
        End With
    End Sub

End Class
