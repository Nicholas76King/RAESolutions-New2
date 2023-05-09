Imports Rae.Io.Text

Class CondensingUnit_Proposal_Grabber
    Private control As CondensingUnitSpecsControl

    Sub New(ByVal specs_control As CondensingUnitSpecsControl)
        Me.control = specs_control
    End Sub

    Function grab() As bag
        Dim bag As bag
        bag.tag = control.txtTag.Text
        bag.ambient = control.txtAmbientTemp.Text
        ' bag.solution = "XXXXXXXXX" 'control.txtGlycolPercent.Text & "% " & control.cboFluid.Text
        bag.refrigerant = control.cboRefrigerant.Text
        'bag.entering_fluid_temperature = "XXXXXXXXX" 'control.txtEnteringFluidTemp.Text
        'bag.leaving_fluid_temperature = "XXXXXXXXX" 'control.txtLeavingFluidTemp.Text

        'performance
        'bag.capacity = "XXXXXXXXX" 'control.txtCapacity.Text
        'bag.gpm = "XXXXXXXXX" 'control.txtFlow.Text
        'bag.evaporator_pressure_drop = "XXXXXXXXX" 'control.txtEvaporatorPressureDrop.Text
        'dimensions
        bag.dimensions = Str("{0}""W x {1}""L x {2}""H", _
                             control.txtWidth.Text, control.txtLength.Text, control.txtHeight.Text)
        bag.shipping_weight = control.txtEstShippingWeight.Text
        bag.operating_weight = control.txtEstOperatingWeight.Text
        bag.voltage = control.cboUnitVoltage.Text
        bag.rla = control.txtRla.Text
        bag.mca = control.txtMca.Text
        bag.rla_2 = "" 'control.panCommonSpecs.Controls("txt_rla_2").Text
        bag.mca_2 = "" 'control.panCommonSpecs.Controls("txt_mca_2").Text
        bag.power_supply_quantity = If(String.IsNullOrEmpty(bag.rla_2), "1", "2")
        bag.control_voltage = ConvertNull.ToString(control.cboControlVoltage.SelectedItem)
        ' bag.unit_efficiency = "XXXXXXXXX" 'control.txt_unit_efficiency.Text



        bag.CapacityCircuit1 = control.txtCapacity1.Text
        bag.CapacityCircuit2 = control.txtCapacity2.Text
        bag.CapacityCircuit3 = control.txtCapacity3.Text
        bag.CapacityCircuit4 = control.txtCapacity4.Text
        bag.SuctionTemp = control.txtSuctionTemp.Text
        bag.EvapTemp = control.txtEvapTemp.Text
        bag.altitude = control.txtAltitude.Text

        bag.efficiency = control.txtEER.Text

        Return bag
    End Function

    Structure bag
        Public tag, refrigerant As String
        Public ambient As String
        '  Public capacity, gpm, evaporator_pressure_drop As String
        Public dimensions, shipping_weight, operating_weight As String
        Public rla, mca, rla_2, mca_2, power_supply_quantity As String
        Public voltage, control_voltage As String
        Public CapacityCircuit1 As String
        Public CapacityCircuit2 As String
        Public CapacityCircuit3 As String
        Public CapacityCircuit4 As String
        Public SuctionTemp, EvapTemp As String
        Public altitude As String
        Public efficiency As String
    End Structure
End Class
