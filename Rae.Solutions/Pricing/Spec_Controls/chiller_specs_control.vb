Imports Rae.RaeSolutions.Business.Entities
imports rae.solutions.group

Public Class chiller_specs_control

   property division as string
   
   ''' <summary>Passes order write up parameters to report.</summary>
   Overrides Sub PassOrderWriteUpParams(reportViewer As Rae.Reporting.CrystalReports.base_report_viewer)
      Dim viewer As Reports.chiller_order_write_up_report_viewer = reportViewer

      With viewer
         .ambient_temperature         = txtAmbientTemp.Text
         .gpm                 = txtFlow.Text
         .entering_temperature        = txtEnteringFluidTemp.Text
         .leaving_temperature         = txtLeavingFluidTemp.Text
         .glycol              = ConvertNull.ToString(Me.cboFluid.SelectedItem)
         .glycol_percentage    = txtGlycolPercent.Text
         .unit_voltage         = ConvertNull.ToString(Me.cboUnitVoltage.SelectedItem)
         .control_voltage      = ConvertNull.ToString(Me.cboControlVoltage.SelectedItem)
         .tag                 = txtTag.Text
         .special_instructions = txtSpecialInstructions.Text
         .title               = If(.model_number Like "35*", "Equipment Proposal", "Water Chiller Order Write Up")
         .ambient_label       = lblAmbientTemp.Text
         if AppInfo.user.can(choose_report_logo) then
            .division = new which_division().ask({"TSI", "CRI", "RSI", "RAE"})
         else
            .division = me.division.ToString
         end if
      End With
   End Sub

   ''' <summary>Updates equipment with control values.</summary>
   ''' <param name="equipment">Equipment to update.</param>
   Overrides Sub GetControlValues(ByRef equipment As EquipmentItem)
      Dim chiller As chiller_equipment

      chiller = equipment

      With chiller
         .special_instructions = Me.txtSpecialInstructions.Text
         .tag = Me.txtTag.Text
      End With

      With chiller.common_specs
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

      With chiller.Specs
         .AmbientTemp.set_to(Me.txtAmbientTemp.Text.Trim)
         .Capacity.set_to(Me.txtCapacity.Text.Trim)
         .EnteringFluidTemp.set_to(Me.txtEnteringFluidTemp.Text.Trim)
         .EvaporatorPressureDrop.set_to(Me.txtEvaporatorPressureDrop.Text.Trim)
         .Flow.set_to(Me.txtFlow.Text.Trim)
         If Me.cboFluid.SelectedItem IsNot Nothing Then
            .Fluid = Me.cboFluid.SelectedItem.ToString
         End If
         .GlycolPercent.set_to(Me.txtGlycolPercent.Text.Trim)
         .LeavingFluidTemp.set_to(Me.txtLeavingFluidTemp.Text.Trim)
         If Me.cboRefrigerant.SelectedItem IsNot Nothing Then
            .Refrigerant = Me.cboRefrigerant.SelectedItem.ToString
         End If
         .unit_kw_per_ton = txt_unit_efficiency.text
      End With

   End Sub

   ''' <summary>Set control values to represent chiller.</summary>
   Overrides Sub SetControlValues(equipment As EquipmentItem)
      Dim chiller As chiller_equipment = equipment

      With chiller
         division = .division
         Me.txtSpecialInstructions.Text = .special_instructions
         Me.txtTag.Text = .tag
      End With

      With chiller.common_specs
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

      With chiller.Specs
         Me.txtAmbientTemp.Text = .AmbientTemp.ToString()
         Me.txtCapacity.Text = .Capacity.ToString()
         Me.txtEnteringFluidTemp.Text = .EnteringFluidTemp.ToString()
         Me.txtEvaporatorPressureDrop.Text = .EvaporatorPressureDrop.ToString()
         Me.txtFlow.Text = .Flow.ToString()
         If .Fluid IsNot Nothing Then
            Me.cboFluid.SelectedIndex = Me.cboFluid.Items.IndexOf(.Fluid)
         End If
         Me.txtGlycolPercent.Text = .GlycolPercent.ToString()
         Me.txtLeavingFluidTemp.Text = .LeavingFluidTemp.ToString()
         If .Refrigerant IsNot Nothing Then
            Me.cboRefrigerant.SelectedIndex = Me.cboRefrigerant.Items.IndexOf(.Refrigerant)
         End If
         txt_unit_efficiency.text = .unit_kw_per_ton
      End With

   End Sub


   Private Sub numberTextBox_KeyDown(sender As Object, e As KeyEventArgs) _
   Handles txtAltitude.KeyDown, txtAmbientTemp.KeyDown, txtCapacity.KeyDown, _
   txtEnteringFluidTemp.KeyDown,   _
   txtEvaporatorPressureDrop.KeyDown, txtFlow.KeyDown, txtGlycolPercent.KeyDown, _
    txtLeavingFluidTemp.KeyDown
      If Not DesignMode Then _
         e.SuppressKeyPress = Not key_code.is_number(e.KeyCode)
   End Sub


#Region " Split condenser"

   ' Split condenser must be enabled before being clicked

   Private _splitCondenserModel As String
   ''' <summary>Split condenser model number (ex. 10A06-SC).</summary>
   ReadOnly Property SplitCondenserModel As String
      Get
         Return Me._splitCondenserModel
      End Get
   End Property

   Private _splitCondenserPrice As Double
   ''' <summary>Price of split condenser</summary>
   ReadOnly Property SplitCondenserPrice As Double
      Get
         Return Me._splitCondenserPrice
      End Get
   End Property

   Private _splitCondenserEnabled As Boolean
   ''' <summary>True if split condenser is enabled, else false.</summary>
   ReadOnly Property SplitCondenserEnabled() As Boolean
      Get
         Return _splitCondenserEnabled
      End Get
   End Property


   ''' <summary>Enables split condenser.</summary>
   ''' <param name="model">Split condenser model (ex. 10A06-SC).</param>
   ''' <param name="price">Split condenser price.</param>
   ''' <param name="clicked">Method that is invoked when split condenser text is clicked (ex. AddressOf AddCondenser).</param>
   Sub EnableSplitCondenser(model As String, price As Double, clicked As SplitCondenserClicked)
      If _splitCondenserEnabled Then Exit Sub

      _splitCondenserModel = model
      _splitCondenserPrice = price

      showSplitCondenser
      setSplitCondenserText(model, price)
      ' sets which method will be invoked when the split condenser link is clicked
      Me.clicked = clicked
      _splitCondenserEnabled = True
   End Sub


   ''' <summary>Disables split condenser.</summary>
   Sub DisableSplitCondenser()
      If Not _splitCondenserEnabled Then Exit Sub
      
      _splitCondenserModel = ""
      _splitCondenserPrice = 0
      
      hideSplitCondenser()
      lllSplitCondenser.Text = ""
      ' removes delegate
      Me.clicked = Nothing
      ' sets enabled property
      _splitCondenserEnabled = False
   End Sub

   ''' <summary>
   ''' Handles split condenser being clicked
   ''' </summary>
   ''' <param name="model">
   ''' Split condenser model</param>
   ''' <param name="price">
   ''' Split condenser price</param>
   Public Delegate Sub SplitCondenserClicked(model As String, price As Double)
   Private clicked As SplitCondenserClicked


   Private Sub lllSplitCondenser_LinkClicked() _
   Handles lllSplitCondenser.LinkClicked
      clicked.Invoke(Me.SplitCondenserModel, Me.SplitCondenserPrice)
   End Sub

   Private Function getSplitCondenserHeight()
      Return (Me.panSplitCondenser.Height + Me.panSplitCondenser.Margin.Top + Me.panSplitCondenser.Margin.Bottom)
   End Function

   Private Sub showSplitCondenser()
      If Me.panSplitCondenser.Visible = False Then
         Me.panSplitCondenser.Visible = True
         Me.Height += getSplitCondenserHeight()
         Me.FlowLayoutPanel1.Height += Me.getSplitCondenserHeight()
      End If
   End Sub

   Private Sub hideSplitCondenser()
      If Me.panSplitCondenser.Visible Then
         Me.panSplitCondenser.Visible = False
         Me.Height -= Me.getSplitCondenserHeight
         Me.FlowLayoutPanel1.Height -= Me.getSplitCondenserHeight()
      End If
   End Sub

   Private Sub setSplitCondenserText(model As String, price As Double)
      lllSplitCondenser.Text = model & ", Click to Add" '& price.ToString("c")
   End Sub

#End Region


   Private Sub me_Load() Handles Me.Load
      cboControlVoltage.Items.Remove("24")
      
      dim txt_rla_2 = new textbox()
      txt_rla_2.name = "txt_rla_2"
      txt_rla_2.parent = txtRla.parent
      txt_rla_2.width = txtRla.width/2
      txt_rla_2.location = txtRla.location
      txt_rla_2.location = new point(txt_rla_2.location.x + txt_rla_2.width, txt_rla_2.location.y)
      txt_rla_2.BringToFront()
      txt_rla_2.enabled = false
      
      dim txt_mca_2 = new textbox()
      txt_mca_2.name = "txt_mca_2"
      txt_mca_2.parent = txtMca.parent
      txt_mca_2.width = txtMca.width/2
      txt_mca_2.location = txtMca.Location
      txt_mca_2.location = new point(txt_mca_2.location.x + txt_mca_2.width, txt_mca_2.location.y)
      txt_mca_2.bringToFront()
      txt_mca_2.enabled = false
   End Sub
   
End Class
