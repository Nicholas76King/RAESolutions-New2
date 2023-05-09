Imports Rae.RaeSolutions.Business
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.Reports
Imports Rae.RaeSolutions.SelectedOptionsDataSet
Imports Rae.Reflection.MethodInvoker
Imports System.Collections.Generic
Imports System.Data
Imports System.Environment
Imports System.Math

Class chiller_pricing_screen
   private bar_order_write_up, mnu_order_write_up as ToolStripItem
   
   Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
      
      ' Add any initialization after the InitializeComponent() call.
      loadEngineeringData = AddressOf load_engineering_data_for
      convertToProcess = AddressOf convert_to_chiller_process

      if user.can_view_pricing then
         bar_order_write_up = barReports.DropDownItems.Add("Order Write Up", nothing, addressof chiller_presenter.show_order_write_up)
         mnu_order_write_up = mnuReports.DropDownItems.Add("Order Write Up", nothing, addressof chiller_presenter.show_order_write_up)
      end if
   End Sub
   
   private chiller_presenter as chiller_presenter
   
   Protected Overrides Function create_presenter() As equipment_pricing_presenter_base
      chiller_presenter = New chiller_presenter(Me, AppInfo.Main)
      return chiller_presenter
   End Function
   
   Protected Overrides Function createSpecsControl() As UserControl
      Return New chiller_specs_control
   End Function
   
   Protected Overrides Sub onOpSelected(code As String, description As String)
      If pump_package_code.matches(code) _
      AndAlso Not is_opening Then
         chiller_presenter.view_new_pump_package
      End If
   End Sub
   
   Private Sub me_load() Handles Me.Load
      chiller_presenter.fill_voltages()
      barConvert.Visible = False
   End Sub
   
   Private Sub load_engineering_data_for(unit As EquipmentItem)
      Dim chiller_specs_control = CType(specsControl, chiller_specs_control)
      
      If unit.series Like "35*" Then
         chiller_specs_control.lblAmbientTemp.Text = "Design Wet Bulb"
         mnu_equipment_proposal.visible = true
         bar_equipment_proposal.visible = true
         mnu_order_write_up.visible = false
         bar_order_write_up.visible = false
         mnuFluidPiping.visible = false
         barFluidPiping.visible = false
         chiller_specs_control.txtRla.enabled = false
         chiller_specs_control.txtMca.enabled = false
      Else
         chiller_specs_control.lblAmbientTemp.Text = "Design Ambient"
         mnu_equipment_proposal.visible = false
         bar_equipment_proposal.visible = false
         mnu_order_write_up.visible = true
         bar_order_write_up.visible = true
         mnuFluidPiping.visible = true
         barFluidPiping.visible = true
         chiller_specs_control.txtRla.enabled = true
         chiller_specs_control.txtMca.enabled = true
      End If
      
      dim control_voltage_is_not_selected = chiller_specs_control.cboControlVoltage.SelectedIndex = -1
      
      if control_voltage_is_not_selected then _
         unit.common_specs.controlVoltage.Voltage.set_to(115)
      
      ' determines whether to run 33A0 (split condenser) specific logic
      If unit.series Like "33A0*" AndAlso unit.model_without_series <> EquipmentSelector1.choose Then
         Dim c As New SplitCondenserInfo(unit.model)
         chiller_specs_control.EnableSplitCondenser(c.CondenserModel, c.CondenserPrice, AddressOf add_split_condenser)
      Else
         chiller_specs_control.DisableSplitCondenser()
      End If
      
      load_chiller_data(unit)
   End Sub
   
   private sub mnu_equipment_proposal_click() _
   handles mnu_equipment_proposal.click, bar_equipment_proposal.click
      dim proposal = new proposal(me)
      proposal.show()
   end sub
   
   ''' <summary>Sets control values that are static for a specific chiller model.</summary>
   Private Sub load_chiller_data(ByVal unit As EquipmentItem)
      Try
         Dim chInfo = New ChillerInfo(unit.model)
         
         ' updates equipment with specs info
         Dim ctrl = CType(specsControl, chiller_specs_control)
         ctrl.SetControlValues(unit)
         'InvokeMethod(specsControl, methodName_GetControlValues, unit)

         ' updates dimensions and refrigerant based on selected model
         With unit.common_specs
            .Length.set_to(Round(chInfo.Length, 2))
            .Width.set_to(Round(chInfo.Width, 2))
            .Height.set_to(Round(chInfo.Height, 2))
            .OperatingWeight.set_to(Round(chInfo.OperatingWeight, 2))
            .ShippingWeight.set_to(Round(chInfo.ShippingWeight, 2))
            
            set_rla_and_mca_for_evaporative_condenser_chiller()
         end with

         Dim formattedRefrigerant As String
         formattedRefrigerant = chInfo.Refrigerant
         
         Dim chiller = CType(unit, chiller_equipment)
         chiller.Specs.Refrigerant = formattedRefrigerant
         chiller.Specs.NumCircuits = chInfo.NumCircuits
      Catch ex As ApplicationException
         'Ui.MessageBox.Show(ex.Message, MessageBoxIcon.Warning)
         With unit.common_specs
            .Length.set_to_null()
            .Width.set_to_null()
            .Height.set_to_null()
            .ShippingWeight.set_to_null()
            .OperatingWeight.set_to_null()
         End With
      Finally
         ' sets spec controls' values with updated dimensions and refrigerant
         InvokeMethod(specsControl, methodName_SetControlValues, unit)
      End Try
   End Sub
   
   Private Sub add_split_condenser(model As String, price As Double)
      ' sets text to prompt user with
      Dim promptText = "Series 33 chillers have a split condenser." & NewLine & NewLine
      promptText &= "Condenser model: " & model & NewLine
      If pricingAuthorized Then
         promptText &= "Condenser price: " & price.ToString(price_format) & NewLine
      End If
      promptText &= NewLine & "Do you want to include the split condenser in the project?"

      Dim result = MessageBox.Show(promptText, My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Information)

      If result = Windows.Forms.DialogResult.Yes Then
         ' adds condenser to project
         Dim equipForm = CType(ProjectInfo.Viewer.ViewEquipment(EquipmentType.Condenser), EquipmentForm)

         With equipForm.EquipmentSelector1
            .Series = "10A0"
            .Model = model.Remove(0, 4)
         End With
      End If
   End Sub
   
   Private Function convert_to_chiller_process() As ProcessItem
      Dim unit = CType(grabEquipment, chiller_equipment)
      Dim proc As ProcessItem
      
      If unit.series Like "RECH%" Or _
      unit.series Like "35A0%" Then
         proc = New EvaporativeCondenserChillerBalance(unit)
      ElseIf unit.series Like "30A1%" Or _
      unit.series Like "30A*" Then
         proc = New ACChillerProcessItem(unit)
      ElseIf unit.series Like "20W0%" Or _
      unit.series Like "25W0%" Then
         proc = New WCChillerProcessItem(unit)
      End If
      
      Return proc
   End Function

End Class
