Imports Rae.RaeSolutions.Business.Entities
Imports Rae.reporting.CrystalReports

Public Class ProductCoolerSpecsControl

    Overrides Sub SetControlValues(ByVal equipment As Business.Entities.EquipmentItem)
        Dim productCooler As ProductCoolerEquipmentItem

        productCooler = equipment

        With productCooler
            Me.txtSpecialInstructions.Text = .special_instructions
            Me.txtTag.Text = .tag
        End With

        With productCooler.common_specs
            Me.txtAltitude.Text = .Altitude.ToString
            Me.cboControlVoltage.SelectedIndex = Me.cboControlVoltage.Items.IndexOf(.ControlVoltage.ToString)
            Me.txtHeight.Text = .Height.ToString
            Me.txtLength.Text = .Length.ToString
            Me.txtMca.Text = .Mca.ToString()
            Me.txtEstOperatingWeight.Text = .OperatingWeight.ToString()
            Me.txtRla.Text = .Rla.ToString()
            Me.txtEstShippingWeight.Text = .ShippingWeight.ToString()
            Me.cboUnitVoltage.SelectedIndex = Me.cboUnitVoltage.Items.IndexOf(.UnitVoltage.ToString())
            Me.txtWidth.Text = .Width.ToString
        End With

        With productCooler.Specs
            Me.txtBoxTemp.Text = .BoxTemp.ToString
            Me.txtCondensingTemp.Text = .CondensingTemp.ToString
            Me.txtEvaporatorTemp.Text = .EvaporatorTemp.ToString
            Me.txtLiquidTemp.Text = .LiquidTemp.ToString
            Me.txtTempDifference.Text = .TempDifference.ToString
            Me.txtUnitCapacity.Text = .Capacity.ToString
            If .Refrigerant IsNot Nothing Then
                Me.cboRefrigerant.SelectedIndex = Me.cboRefrigerant.Items.IndexOf(.Refrigerant)
            End If

            Me.txtCFM.Text = .CFM.ToString
            Me.txtPSI.Text = .ExternalSP.ToString




            If .FanMotorHP IsNot Nothing Then Me.cboFanMotorHP.SelectedIndex = Me.cboFanMotorHP.Items.IndexOf(.FanMotorHP)
            If .FanMotorType IsNot Nothing Then Me.cboFanMotorType.SelectedIndex = Me.cboFanMotorType.Items.IndexOf(.FanMotorType)
            If .Hand IsNot Nothing Then Me.cboHand.SelectedIndex = Me.cboHand.Items.IndexOf(.Hand)
            If .MotorLocation IsNot Nothing Then Me.cboMotorLocation.SelectedIndex = Me.cboMotorLocation.Items.IndexOf(.MotorLocation)
            If .BlowerDCPosition IsNot Nothing Then Me.cboBlowerDCPosition.SelectedIndex = Me.cboBlowerDCPosition.Items.IndexOf(.BlowerDCPosition)



        End With
    End Sub

    Overrides Sub GetControlValues(ByRef equipment As Business.Entities.EquipmentItem)
        Dim productCooler As ProductCoolerEquipmentItem

        productCooler = equipment

        With productCooler
            .special_instructions = Me.txtSpecialInstructions.Text
            .tag = Me.txtTag.Text
        End With

        With productCooler.common_specs
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

        With productCooler.Specs
            .BoxTemp.set_to(Me.txtBoxTemp.Text.Trim)
            .Capacity.set_to(Me.txtUnitCapacity.Text.Trim)
            .CondensingTemp.set_to(Me.txtCondensingTemp.Text.Trim)
            .EvaporatorTemp.set_to(Me.txtEvaporatorTemp.Text.Trim)
            .LiquidTemp.set_to(Me.txtLiquidTemp.Text.Trim)
            If Me.cboRefrigerant.SelectedItem IsNot Nothing Then
                .Refrigerant = Me.cboRefrigerant.SelectedItem.ToString
            End If
            .TempDifference.set_to(Me.txtTempDifference.Text.Trim)

            .CFM.set_to(Me.txtCFM.Text.Trim)
            .ExternalSP.set_to(Me.txtPSI.Text.Trim)

            'If Not cboMotorLocation.SelectedItem Is Nothing Then
            '    .MotorLocation = cboMotorLocation.SelectedItem.ToString
            'Else
            '    .MotorLocation = ""
            'End If

            If Me.cboFanMotorHP.SelectedItem IsNot Nothing Then .FanMotorHP = Me.cboFanMotorHP.SelectedItem.ToString
            If Me.cboFanMotorType.SelectedItem IsNot Nothing Then .FanMotorType = Me.cboFanMotorType.SelectedItem.ToString
            If Me.cboHand.SelectedItem IsNot Nothing Then .Hand = Me.cboHand.SelectedItem.ToString
            If Me.cboMotorLocation.SelectedItem IsNot Nothing Then .MotorLocation = Me.cboMotorLocation.SelectedItem.ToString
            If Me.cboBlowerDCPosition.SelectedItem IsNot Nothing Then .BlowerDCPosition = Me.cboBlowerDCPosition.SelectedItem.ToString


        End With
    End Sub

    Private Sub numberTextBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
    Handles txtAltitude.KeyDown, txtBoxTemp.KeyDown, txtCondensingTemp.KeyDown, _
    txtEvaporatorTemp.KeyDown, txtLiquidTemp.KeyDown, txtTempDifference.KeyDown, _
    txtUnitCapacity.KeyDown, txtCFM.KeyDown, txtPSI.KeyDown
        e.SuppressKeyPress = Not key_code.is_number(e.KeyCode)
    End Sub



    Public Sub SetBlowerDischarge(ByVal series As String)
        Select Case series.ToUpper
            Case "VPC"
                cboBlowerDCPosition.Visible = True
                lblBlowerDCPosition.Visible = True
                cboBlowerDCPosition.Items.Clear()
                cboBlowerDCPosition.Items.Add("Front Horiz")
                cboBlowerDCPosition.Items.Add("Vert. Up")
                cboBlowerDCPosition.Items.Add("Rear Horiz")


            Case "HPC"
                cboBlowerDCPosition.Visible = True
                lblBlowerDCPosition.Visible = True
                lblBlowerDCPosition.Visible = True
                cboBlowerDCPosition.Items.Clear()
                cboBlowerDCPosition.Items.Add("Vert. Up")
                cboBlowerDCPosition.Items.Add("Rear Horiz")
            Case Else
                cboBlowerDCPosition.Visible = False
                lblBlowerDCPosition.Visible = False
        End Select
    End Sub


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()




        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class