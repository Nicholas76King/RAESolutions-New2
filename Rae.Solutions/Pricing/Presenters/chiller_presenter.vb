Imports System.Collections.Generic
Imports System.Data
Imports System.Math
Imports Rae.Ui
Imports Col = Rae.RaeSolutions.DataAccess.Projects.Tables.OptionsObjectTable
Imports OCol = Rae.RaeSolutions.DataAccess.Projects.Tables.EquipmentOptionsTable
Imports Rae.RaeSolutions.Business
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.DataAccess.EquipmentOptionsAgent
Imports System.Environment
Imports Rae.RaeSolutions.SelectedOptionsDataSet

class chiller_order_write_up : inherits order_write_up_base
   sub new(screen as EquipmentForm)
      mybase.new(screen, reports.file_paths.chiller_order_write_up_file_path)
   end sub
end class

Class chiller_presenter : Inherits equipment_pricing_presenter_base

   Sub New(equipment_screen As EquipmentForm, main_screen As MainForm)
      MyBase.New(equipment_screen, main_screen)
   End Sub
   
   protected overrides function create_submittal as accessories_base
      return new chiller_accessories(equipView)
   end function
   
   protected overrides function create_order_write_up as order_write_up_base
      return new chiller_order_write_up(equipview)
   end function

   sub show_order_write_up
      dim report = new ChillerOrderWriteUp(equipView, mainView)
      report.view
   end sub

   
   Sub view_new_pump_package()
      grab_chiller()

      ' creates pump package
      Dim equip = EquipmentFactory.CreateEquipment( _
         "Integrated Pump Package", _
         chiller.id.Username, _
         chiller.id.Password, _
         Business.EquipmentType.PumpPackage, _
         Business.Division.TSI)
      Dim pp = CType(equip, PumpEquipment)

      pp.Flow.set_to(chiller.Specs.Flow.value_or_default(10))

        ' views pump package
        Dim junk As String = ""

        pump_package_screen = CType(ProjectInfo.Viewer.ViewEquipment(pp, False, False, junk), EquipmentForm)
      use_integrated_pump_package_settings()
   End Sub
   
   Sub unselect_pump_package_option(pump_package_row As DataRow)
      ' if pump package form was canceled then it wasn't added to chiller
      If chiller.has_pump_package Then _
         clear_pump_package_options(chiller)
      set_pump_package_description_to_indicate_not_selected(pump_package_row)
      chiller.remove_pump_package()
   End Sub
   
   Sub select_pump_package_option()
      Dim pump_package_row = find_pump_package_row_in_available_options
      set_pump_package_description_to_indicate_it_is_selected(pump_package_row, chiller.pump_package)
      pump_package_row(Col.Selected) = True

        ''Dim table = CType(equipView.selectedOpGrid.DataSource, DataTable)
        ''  For Each op In chiller.pump_package.options
        ''   Dim row = Converter.Convert(op).In(table).ToRow
        ''   table.Rows.Add(row)
        ''Next

        Dim series  = chiller.pump_package.series
      Dim model   = chiller.pump_package.model_without_series
      Dim voltage = chiller.pump_package.common_specs.UnitVoltage.Voltage.value
        Dim standardOptionsTable = Rae.RaeSolutions.DataAccess.EquipmentOptionsAgent.OptionsDA.RetrieveStandardOptions(series, model, voltage, numFans:=0, fanMotorPhase:=0)
        ''CType(equipView.standardOpGrid.DataSource, DataTable).Merge(standardOptionsTable)
    End Sub
   
   function is_pump_option(code as string) as boolean
      return pump_package_codes.has(code)
   end function
   
   sub fill_voltages()
      dim voltages() as string = {"460/3/60", "230/3/60", "208/3/60"}
      equipView.cboUnitVoltage.items.clear()
      equipView.cboUnitVoltage.items.AddRange(voltages)
      
      dim control = ctype(equipView.specsControl, chiller_specs_control)
      control.cboControlVoltage.items.clear()
      dim control_voltages() as string = {"230", "208", "115"}
      control.cboControlVoltage.items.addRange(control_voltages)
   end sub
   
   
   Private pump_package_screen As EquipmentForm
   
   Private Sub updatePumpPackageOp()
      dim pump_package_available_option_row = find_pump_package_row_in_available_options
      dim pump_package_selected_option_row = find_pump_package_in_selected_options
      
      ' updates pump package option
      If pump_package_available_option_row IsNot Nothing Then
         set_pump_package_description_to_indicate_it_is_selected(pump_package_available_option_row, pp)
         set_pump_package_description_to_indicate_it_is_selected(pump_package_selected_option_row, pp)
      End If
   End Sub
   
   Private Function find_pump_package_row_in_available_options() As DataRow
        ''Dim available_options = CType(equipView.availableOpGrid.DataSource, DataTable).Rows

        ''  For Each row In available_options
        ''   If pump_package_code.matches( row(Col.Code) ) Then
        ''      Return row
        ''   End If
        ''Next
    End Function
   
   Private Function find_pump_package_in_selected_options() As DataRow
        ''Dim chillerSelectedOpRows = CType(equipView.selectedOpGrid.DataSource, DataTable).Rows

        ''For Each row In chillerSelectedOpRows
        ''   If pump_package_code.matches( row(Col.Code) ) Then
        ''      Return row
        ''   End If
        ''Next
    End Function
   
   Private Sub set_pump_package_description_to_indicate_it_is_selected(ppRow As DataRow, pp As PumpEquipment)
      Dim repo = PumpRepoFactory.Create()
      Dim pump = repo.GetPump(pp.Manufacturer, pp.Flow.value, pp.Head.value, pp.System)
      Dim hp = pump.HP
      If pp.System=PumpSystem.Single Then
         ppRow(Col.Code) = "HP01"
         ppRow(Col.Description) = "Standard Pump Package " & pp.Manufacturer & " " & hp & "hp"
      Else
         ppRow(Col.Code) = "HP02"
         ppRow(Col.Description) = "Standard Dual Pump Package " & pp.Manufacturer & " " & hp & "hp"
      End If
      ppRow(Col.Price) = pp.pricing.list_price
   End Sub
   
   Private Sub set_pump_package_description_to_indicate_not_selected(ppRow As DataRow)
      ppRow(Col.Code) = "PP"
      ppRow(Col.Description) = "Pump Package (must select to determine price)"
      ppRow(Col.Price) = 0
   End Sub
   
   Private Sub unselect_canceled_pump_package_option()
      Dim op = find_pump_package_row_in_available_options()
      op(Col.Selected) = False
   End Sub
   
   Private Sub clear_pump_package_options(chiller As chiller_equipment)
      For Each op In chiller.pump_package.options
         equipView.selectedOpGrid.Remove(op.Code)
      Next
      
      ' finds pump package options to remove
      Dim opIdsToRemove = New List(Of Integer)
        ''For Each op In CType(equipView.standardOpGrid.DataSource, DataTable).Rows
        ''   If pump_package_codes.has(op(Col.Code)) Then
        ''      opIdsToRemove.Add(op(Col.ID))
        ''   End If
        ''Next
        ' removes pump package options
        For Each opId In opIdsToRemove
         equipView.standardOpGrid.Remove(opId)
      Next
      
   End Sub
   
   Private Sub use_integrated_pump_package_settings()
      ' hides drawing and reporting toolbars
      pump_package_screen.ToolStrip1.Visible = False
      ' hides all equipment menu items (drawing, saving, reporting, close)
      pump_package_screen.mnuSave.Visible = False
      pump_package_screen.mnuSaveAs.Visible = False
      pump_package_screen.mnuSaveAsRevision.Visible = False
      pump_package_screen.mnuDrawings.Visible = False
      pump_package_screen.mnuReports.Visible = False
      pump_package_screen.mnuConvert.Visible = False
      pump_package_screen.mnuSubmittal.Visible = False
      pump_package_screen.mnu_order_write_up.Visible = False
      pump_package_screen.panSpecialOptionsSummary.Visible = False
      pump_package_screen.Splitter1.Visible = False
      ' hides close x button
      pump_package_screen.ControlBox = False
      ' hides option summary tab
      pump_package_screen.tabEquipment.TabPages.Remove(pump_package_screen.tabSpecialOptions)
      ' hides pricing tab
      pump_package_screen.tabEquipment.TabPages.Remove(pump_package_screen.tabPricing)
      pump_package_screen.FormBorderStyle = FormBorderStyle.Sizable
      pump_package_screen.SaveToolStripPanel1.Unmerge
      
      show_chiller_balance_instructions()
      
      Dim resultCtrl = New PumpPackageResultControl() With { .Height=29, .Dock=DockStyle.Top }
      resultCtrl.CancelCommand = AddressOf on_canceled
      resultCtrl.CompleteCommand = AddressOf on_completed
      pump_package_screen.Controls.Add(resultCtrl)
   End Sub
   
   Private Sub show_chiller_balance_instructions()
      Dim instructions = New Label() With { .Height=29, .Dock=DockStyle.Top, .TextAlign=ContentAlignment.MiddleLeft }
      instructions.Font = New Font("Calibri", 10, FontStyle.Regular)
      instructions.ForeColor = Color.Navy
      instructions.Image = My.Resources.Info
      instructions.ImageAlign = ContentAlignment.MiddleLeft
      instructions.Text = "     Please run a chiller balance before selecting a pump package."
      pump_package_screen.tabModel.Controls.Add(instructions)
   End Sub
   
   Private Sub on_canceled()
      unselect_canceled_pump_package_option()
      
      ' prevents saving dialog from showing
      RemoveHandler pump_package_screen.FormClosing, AddressOf pump_package_screen.onFormClosing
      pump_package_screen.Close
   End Sub
   
   Private Sub on_completed()
      chiller.Add( grab_pump_package )

        ' adds options from pump package screen to selected options grid on summary tab in chiller screen
        ''Dim pump_package_available_option_rows = CType(pump_package_screen.availableOpGrid.DataSource, DataTable).Rows
        ''For Each available_option In pump_package_available_option_rows
        ''   If available_option(Col.Selected) Then _
        ''      equipView.selectedOpGrid.Add(available_option)
        ''Next

        ''Dim pump_package_standard_option_rows = CType(pump_package_screen.standardOpGrid.DataSource, DataTable).Rows
        ''For Each standard_option In pump_package_standard_option_rows
        ''   equipView.standardOpGrid.Add(standard_option)
        ''Next

        updatePumpPackageOp()
      
      ' prevents saving dialog from showing
      RemoveHandler pump_package_screen.FormClosing, AddressOf pump_package_screen.onFormClosing
      pump_package_screen.Close
      
      equipView.Refresh()
   End Sub
   
   Private Function grab_pump_package As PumpEquipment
      Return pump_package_screen.grabEquipment()
   End Function
   
   Private Function pp As PumpEquipment
      Return CType(pump_package_screen.Equipment, PumpEquipment)
   End Function
   
   Private Function grab_chiller As chiller_equipment
      Return equipView.grabEquipment()
   End Function
   
   Private Function chiller As chiller_equipment
      Return CType(equipView.Equipment, chiller_equipment)
   End Function

   sub show_submittal
      dim report = new chiller_accessories(equipView)
        Dim junk As String = ""
        report.show(False, "")
   end sub
   
End Class

class chiller_grabber
   private control as chiller_specs_control

   sub new(screen as EquipmentForm)
      control = screen.specsControl
   end sub

   function grab as bag
      dim bag as bag
      bag.ambient = control.txtAmbientTemp.Text.F
      bag.entering_temperature = control.txtEnteringFluidTemp.Text.F
      bag.leaving_temperature = control.txtLeavingFluidTemp.Text.F
      bag.unit_voltage = control.cboUnitVoltage.SelectedItem
      bag.control_voltage = control.cboControlVoltage.SelectedItem
      bag.rla = control.txtRla.Text
      bag.mca = control.txtMca.Text
      if control.txtLength.Text.is_set or control.txtWidth.Text.is_set or control.txtHeight.Text.is_set
         bag.dimensions = control.txtLength.Text & "x" & control.txtWidth.Text & "x" & control.txtHeight.Text & " in."
      end if
      bag.shipping_weight = control.txtEstShippingWeight.Text.lbs
      bag.operating_weight = control.txtEstOperatingWeight.Text.lbs
      bag.tag = control.txtTag.Text
      bag.glycol = control.cboFluid.SelectedItem
      bag.glycol_percentage = control.txtGlycolPercent.Text
      bag.gpm = control.txtFlow.Text
      bag.evaporator_pressure_drop = control.txtEvaporatorPressureDrop.Text
      return bag
   end function

   structure bag
      public ambient, entering_temperature, leaving_temperature as string
      public unit_voltage, control_voltage, rla, mca as string
      public dimensions, shipping_weight, operating_weight, tag as string
      public glycol, glycol_percentage, gpm, evaporator_pressure_drop as string
   end structure
end class