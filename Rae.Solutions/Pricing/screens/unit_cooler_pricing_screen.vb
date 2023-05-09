Imports Rae.RaeSolutions.Business.Entities
Imports System.ComponentModel
imports System.Linq

Class unit_cooler_pricing_screen

   private uc_presenter as unit_cooler_pricing_presenter
   private unit_cooler_specs_control as UnitCoolerSpecsControl

   Sub New()
      InitializeComponent()




      uc_presenter = presenter
      loadEngineeringData = AddressOf uc_presenter.load_data
      convertToProcess    = AddressOf convertToBalance
      if user.can_view_pricing then
            barReports.DropDownItems.Add("Order Write Up", Nothing, AddressOf ShowOrderWriteUp)
            ' mnu_order_write_up = mnuReports.DropDownItems.Add("Order Write Up", nothing, addressof uc_presenter.show_order_write_up)

            mnu_order_write_up = mnuReports.DropDownItems.Add("Order Write Up", Nothing, AddressOf ShowOrderWriteUp)


        End If
   End Sub



    Private Sub ShowOrderWriteUp()

        uc_presenter.show_order_write_up()
    End Sub




   Protected Overrides Function create_presenter() As equipment_pricing_presenter_base
      Return New unit_cooler_pricing_presenter(Me, AppInfo.Main)
   End Function
   
   Protected Overrides Function createSpecsControl() As UserControl
      Return New UnitCoolerSpecsControl()
   End Function
   
   Private Function convertToBalance() As ProcessItem
      Return New cu_uc_balance_screen_model(CType(Equipment, unit_cooler))
   End Function
   
   Private Sub form_Load() Handles Me.Load
      unit_cooler_specs_control = specsControl
      
      ' don't show unit voltage, it will be selected with condensing unit
      cboUnitVoltage.Visible = False
      lblUnitVoltage.Visible = False
      unit_cooler_specs_control.cboUnitVoltage.Visible = False
      unit_cooler_specs_control.lblUnitVoltage.Visible = False
      
      AddHandler unit_cooler_specs_control.cboRefrigerant.SelectedIndexChanged, AddressOf refrigerant_changed
   End Sub
   
   private sub refrigerant_changed(sender as object, e as eventArgs)
      uc_presenter.load_data(me.Equipment)
   end sub
   
    Private Sub series_Changed(ByVal sender As Object, ByVal series As String) Handles EquipmentSelector1.SeriesChanged
        Dim refrigerants = uc_presenter.get_refrigerants(series)
        unit_cooler_specs_control.cboRefrigerant.Items.Clear()
        unit_cooler_specs_control.cboRefrigerant.Items.AddRange(refrigerants)

        'Dim fanVoltages = uc_presenter.get_fan_voltages(series)
        'unit_cooler_specs_control.fanVoltageCombo.Items.Clear()
        'unit_cooler_specs_control.fanVoltageCombo.Items.AddRange(fanVoltages)

        'Dim defrostVoltages = uc_presenter.get_defrost_voltages(series)
        'unit_cooler_specs_control.defrostVoltageCombo.Items.Clear()
        'unit_cooler_specs_control.defrostVoltageCombo.Items.AddRange(defrostVoltages)
    End Sub

    Private Sub MODEL_Changed(ByVal s As EquipmentSelector, ByVal selectedModel As String) Handles EquipmentSelector1.ModelChanged
        '    Dim refrigerants = uc_presenter.get_refrigerants(series)
        '    unit_cooler_specs_control.cboRefrigerant.Items.Clear()
        '    unit_cooler_specs_control.cboRefrigerant.Items.AddRange(refrigerants)



        Dim series As String = EquipmentSelector1.Series


        Dim fanVoltage As String = unit_cooler_specs_control.fanVoltageCombo.SelectedItem
        Dim fanVoltages = uc_presenter.get_fan_voltages(series, selectedModel)
        unit_cooler_specs_control.fanVoltageCombo.Items.Clear()
        unit_cooler_specs_control.fanVoltageCombo.Items.AddRange(fanVoltages)
        If Not String.IsNullOrEmpty(fanVoltage) AndAlso unit_cooler_specs_control.fanVoltageCombo.FindStringExact(fanVoltage) >= 0 Then
            unit_cooler_specs_control.fanVoltageCombo.SelectedIndex = unit_cooler_specs_control.fanVoltageCombo.FindStringExact(fanVoltage)
        End If


        Dim defrostVoltage As String = unit_cooler_specs_control.defrostVoltageCombo.SelectedItem
        Dim defrostVoltages = uc_presenter.get_defrost_voltages(series, selectedModel)
        unit_cooler_specs_control.defrostVoltageCombo.Items.Clear()

        If defrostVoltages.Length > 0 Then
            unit_cooler_specs_control.defrostVoltageCombo.Visible = True
            unit_cooler_specs_control.defrostVoltageLabel.Visible = True

            unit_cooler_specs_control.defrostVoltageCombo.Items.AddRange(defrostVoltages)
        Else
            unit_cooler_specs_control.defrostVoltageLabel.Visible = False
            unit_cooler_specs_control.defrostVoltageCombo.Visible = False
        End If



        If Not String.IsNullOrEmpty(defrostVoltage) AndAlso unit_cooler_specs_control.defrostVoltageCombo.FindStringExact(defrostVoltage) >= 0 Then
            unit_cooler_specs_control.defrostVoltageCombo.SelectedIndex = unit_cooler_specs_control.defrostVoltageCombo.FindStringExact(defrostVoltage)
        End If
    End Sub



End Class
