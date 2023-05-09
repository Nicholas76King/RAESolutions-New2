Imports Rae.RaeSolutions.Business.Entities
Imports Rae.reporting.CrystalReports
Imports Rae.solutions.group

Public Class CondensingUnitSpecsControl
    Inherits CommonSpecsControl


    Private m_Division As Business.Division
    ''' <summary>Division</summary>
    Property Division As Business.Division
        Get
            Return Me.m_Division
        End Get
        Set(ByVal value As Business.Division)
            Me.m_Division = value
        End Set
    End Property


    ''' <summary>Units of measurement for the condensing unit's capcacity</summary>
    ''' <remarks>Use Tons for TSI and BTUH for CRI</remarks>
    Property CapacityUnits As String
        Get
            Return Me.lblCapacity1Units.Text
        End Get
        Set(ByVal value As String)
            Me.lblCapacity1Units.Text = value
            Me.lblCapacity2Units.Text = value
            Me.lblCapacity3Units.Text = value
            Me.lblCapacity4Units.Text = value
        End Set
    End Property


    ''' <summary>Updates equipment with control values.</summary>
    ''' <param name="equipment">Equipment to update.</param>
    Overrides Sub GetControlValues(ByRef equipment As EquipmentItem)
        Dim condUnit As CondensingUnitEquipmentItem
        'equipment.Name, equipment.Equipment.Division, equipment.Id, equipment.ProjectManager)

        condUnit = equipment

        With condUnit
            .special_instructions = Me.txtSpecialInstructions.Text.Trim
            .tag = Me.txtTag.Text.Trim
        End With

        With condUnit.common_specs
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

        With condUnit.specs
            .ambient.set_to(Me.txtAmbientTemp.Text.Trim)
            .suction.set_to(txtSuctionTemp.Text.Trim)
            .evaporating_temperature.set_to(txtEvapTemp.Text.Trim)
            .capacity_1.set_to(Me.txtCapacity1.Text.Trim)
            .capacity_2.set_to(Me.txtCapacity2.Text.Trim)
            .capacity_3.set_to(Me.txtCapacity3.Text.Trim)
            .capacity_4.set_to(Me.txtCapacity4.Text.Trim)
            .efficiency.set_to(Me.txtEER.Text.Trim)
            If Me.cboRefrigerant.SelectedItem IsNot Nothing Then
                .refrigerant = Me.cboRefrigerant.SelectedItem.ToString
            End If
            .suction.set_to(Me.txtSuctionTemp.Text.Trim)
        End With

    End Sub


    ''' <summary>Sets control values to represent condensing unit.</summary>
    ''' <param name="equipment">Condensing unit equipment item to display in controls.</param>
    Overrides Sub SetControlValues(ByVal equipment As EquipmentItem)
        Dim condUnit As CondensingUnitEquipmentItem

        condUnit = equipment

        Me.Division = condUnit.division

        If Me.Division = Business.Division.CRI Then
            Me.CapacityUnits = "BTUH"
        ElseIf Me.Division = Business.Division.TSI Then
            Me.CapacityUnits = "Tons"

            Me.lblCapacity1.Text = "Total Est. Capacity"
            Me.lblCapacity2.Visible = False
            Me.lblCapacity3.Visible = False
            Me.lblCapacity4.Visible = False
            Me.lblCapacity2Units.Visible = False
            Me.lblCapacity3Units.Visible = False
            Me.lblCapacity4Units.Visible = False

            Me.txtCapacity2.Visible = False
            Me.txtCapacity3.Visible = False
            Me.txtCapacity4.Visible = False


            Me.lblEER.Visible = True
            Me.txtEER.Visible = True
            Me.lblEERUnit.Visible = True

            '  cboControlVoltage.Text = "115"
            '  Me.cboControlVoltage.Items.

        End If

        With condUnit
            Me.txtSpecialInstructions.Text = .special_instructions
            Me.txtTag.Text = .tag
        End With

        With condUnit.common_specs
            Me.txtAltitude.Text = .Altitude.ToString


            'If Division = Business.Division.TSI Then
            '    Me.cboControlVoltage.SelectedIndex = Me.cboControlVoltage.Items.IndexOf("115")
            'Else

            Me.cboControlVoltage.SelectedIndex = Me.cboControlVoltage.Items.IndexOf(.ControlVoltage.ToString)
            '            End If



            If .Height.has_value Then
                Me.txtHeight.Text = .Height.ToString
            End If
            If .Length.has_value Then
                Me.txtLength.Text = .Length.ToString
            End If
            Me.txtMca.Text = .Mca.ToString()

            If .OperatingWeight.has_value Then
                Me.txtEstOperatingWeight.Text = .OperatingWeight.ToString()   'set 1  2  3  4
            End If

            Me.txtRla.Text = .Rla.ToString()


            If .ShippingWeight.has_value Then
                Me.txtEstShippingWeight.Text = .ShippingWeight.ToString()
            End If

                Me.cboUnitVoltage.SelectedIndex = Me.cboUnitVoltage.Items.IndexOf(.UnitVoltage.ToString())

                If .Width.has_value Then
                    Me.txtWidth.Text = .Width.ToString
                End If
        End With

        With condUnit.specs
            Me.txtAmbientTemp.Text = .ambient.ToString
            txtSuctionTemp.Text = .suction.ToString()
            txtEvapTemp.Text = .evaporating_temperature.ToString
            Me.txtCapacity1.Text = .capacity_1.ToString
            Me.txtCapacity2.Text = .capacity_2.ToString
            Me.txtCapacity3.Text = .capacity_3.ToString
            Me.txtCapacity4.Text = .capacity_4.ToString
            Me.txtMca.Text = .mca.ToString
            Me.txtRla.Text = .rla.ToString


            Me.txtEER.Text = .efficiency.ToString
            If .refrigerant IsNot Nothing Then
                Me.cboRefrigerant.SelectedIndex = Me.cboRefrigerant.Items.IndexOf(.refrigerant)
            End If



        End With

    End Sub


    Private Sub numberTextBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
    Handles txtAltitude.KeyDown, txtAmbientTemp.KeyDown, txtCapacity1.KeyDown, txtCapacity2.KeyDown, _
    txtCapacity3.KeyDown, txtCapacity4.KeyDown, txtSuctionTemp.KeyDown, txtEER.KeyDown
        e.SuppressKeyPress = Not key_code.is_number(e.KeyCode)
    End Sub

    Private Sub CondensingUnitSpecsControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class