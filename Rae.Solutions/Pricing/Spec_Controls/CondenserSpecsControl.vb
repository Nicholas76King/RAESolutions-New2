Imports Rae.RaeSolutions.Business.Entities
Imports Rae.Reporting.CrystalReports
imports rae.solutions.group

Public Class CondenserSpecsControl

   Private m_Division As Business.Division
   Property Division() As Business.Division
      Get
         Return Me.m_Division
      End Get
      Set(ByVal value As Business.Division)
         Me.m_Division = value
         SetCapacityUnitLabels(value)
      End Set
   End Property

#Region " Public methods"

   Overrides Sub SetControlValues(ByVal equipment As EquipmentItem)
      Dim condenser As CondenserEquipmentItem

      condenser = equipment

      With condenser
         Me.Division = .division
         Me.txtSpecialInstructions.Text = .special_instructions
         Me.txtTag.Text = .tag
      End With

      With condenser.common_specs
         Me.txtAltitude.Text = .Altitude.ToString
         If .ControlVoltage IsNot Nothing Then _
            Me.cboControlVoltage.SelectedIndex = Me.cboControlVoltage.Items.IndexOf(.ControlVoltage.ToString)
         Me.txtHeight.Text = .Height.ToString
         Me.txtLength.Text = .Length.ToString
         Me.txtMca.Text = .Mca.ToString
         Me.txtEstOperatingWeight.Text = .OperatingWeight.ToString
         Me.txtRla.Text = .Rla.ToString
         Me.txtEstShippingWeight.Text = .ShippingWeight.ToString
         If .UnitVoltage IsNot Nothing Then _
            Me.cboUnitVoltage.SelectedIndex = Me.cboUnitVoltage.Items.IndexOf(.UnitVoltage.ToString())
         Me.txtWidth.Text = .Width.ToString
      End With

      With condenser.Specs
         Me.txtAmbientTemp.Text = .AmbientTemp.ToString()
         Me.txtCondenserTD.Text = .TempDifference.ToString()
         If .Fpi.has_value Then
            Me.cboFinsPerInch.SelectedIndex = Me.cboFinsPerInch.Items.IndexOf(.Fpi.ToString)
         End If
         Me.chkSubCooling.Checked = .SubCooling
         Me.txtTotalHeatRejection1.Text = .TotalHeatRejection1.ToString
         Me.txtTotalHeatRejection2.Text = .TotalHeatRejection2.ToString
         Me.txtTotalHeatRejection3.Text = .TotalHeatRejection3.ToString
         Me.txtTotalHeatRejection4.Text = .TotalHeatRejection4.ToString
         If .Refrigerant IsNot Nothing Then
            Me.cboRefrigerant.SelectedIndex = Me.cboRefrigerant.Items.IndexOf(.Refrigerant)
         End If
      End With
   End Sub


   Overrides Sub GetControlValues(ByRef equipment As EquipmentItem)
      Dim condenser As CondenserEquipmentItem

      condenser = equipment

      With condenser
         .special_instructions = Me.txtSpecialInstructions.Text
         .tag = Me.txtTag.Text
      End With

      With condenser.common_specs
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

      With condenser.Specs
         .AmbientTemp.set_to(Me.txtAmbientTemp.Text.Trim)
         If Me.cboFinsPerInch.SelectedItem IsNot Nothing Then
            .Fpi.set_to(Me.cboFinsPerInch.SelectedItem.ToString)
         End If
         .TotalHeatRejection1.set_to(Me.txtTotalHeatRejection1.Text.Trim)
         .TotalHeatRejection2.set_to(Me.txtTotalHeatRejection2.Text.Trim)
         .TotalHeatRejection3.set_to(Me.txtTotalHeatRejection3.Text.Trim)
         .TotalHeatRejection4.set_to(Me.txtTotalHeatRejection4.Text.Trim)
         .SubCooling = Me.chkSubCooling.Checked
         If Me.cboRefrigerant.SelectedItem IsNot Nothing Then
            .Refrigerant = Me.cboRefrigerant.SelectedItem.ToString
         End If
         .TempDifference.set_to(Me.txtCondenserTD.Text.Trim)
      End With
   End Sub

#End Region


#Region " Private methods"

   Private Function GetCapacityUnits(ByVal division As Business.Division) As String
      Dim capacityUnits As String

      If division = Business.Division.CRI Then
            capacityUnits = "BTUH"
      ElseIf division = Business.Division.TSI Then
            capacityUnits = "Tons"
      End If

      Return capacityUnits
   End Function


   Private Sub SetCapacityUnitLabels(ByVal division As Business.Division)
      Dim capacityUnits As String
      capacityUnits = GetCapacityUnits(division)

      Me.lblCapacity1Units.Text = capacityUnits
      Me.lblCapacity2Units.Text = capacityUnits
      Me.lblCapacity3Units.Text = capacityUnits
      Me.lblCapacity4Units.Text = capacityUnits
      'Me.lblCapacityUnits.Text = capacityUnits
   End Sub

   
   'Private Sub numberTextBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
   'Handles txtAltitude.KeyDown, txtAmbientTemp.KeyDown, txtCondenserTD.KeyDown, txtEstOperatingWeight.KeyDown, _
   'txtEstShippingWeight.KeyDown, txtHeight.KeyDown, txtLength.KeyDown, txtMca.KeyDown, txtRla.KeyDown, _
   'txtTotalHeatRejection1.KeyDown, txtTotalHeatRejection2.KeyDown, txtTotalHeatRejection3.KeyDown, _
   'txtTotalHeatRejection4.KeyDown, txtWidth.KeyDown
   '   If DesignMode Then Exit Sub
   '   e.SuppressKeyPress = Not KeyCode.IsNumber(e.KeyCode)
   'End Sub

#End Region


End Class
