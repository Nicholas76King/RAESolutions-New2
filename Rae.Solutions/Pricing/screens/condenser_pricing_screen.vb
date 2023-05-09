Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.DataAccess
imports rae.ui.quickies

Class condenser_pricing_screen

   Private condenser_specs_control As CondenserSpecsControl

   Sub New()
      InitializeComponent()
      
      dim condenser_presenter = ctype(presenter, condenser_pricing_presenter)
      loadEngineeringData = AddressOf loadCondenserDataFor
      convertToProcess = AddressOf convertToCondenserProcess

      if user.can_view_pricing then
         barReports.DropDownItems.Add("Order Write Up", nothing, addressof condenser_presenter.show_order_write_up)
         mnu_order_write_up = mnuReports.DropDownItems.Add("Order Write Up", nothing, addressof condenser_presenter.show_order_write_up)
      end if
   End Sub
   
   Protected Overrides Function create_presenter() As equipment_pricing_presenter_base
      Return New condenser_pricing_presenter(Me, AppInfo.Main)
   End Function
   
   Protected Overrides Function createSpecsControl() As UserControl
      Return New CondenserSpecsControl()
   End Function
   
   
   Private Sub me_load() Handles Me.Load
      condenser_specs_control = CType(specsControl, CondenserSpecsControl)
      
      With cboUnitVoltage.Items
         .Clear()
         .Add("460/3/60")
         .Add("230/3/60")
            '  .Add("208/3/60")
      End With
   End Sub
   
   Private Sub loadCondenserDataFor(unit As EquipmentItem)
      loadCondenserData(unit.series, unit.model_without_series)
   End Sub
   
   Private Sub loadCondenserData(series As String, model As String)
      ' formats condenser model as listed in data source (10A0-4 and PFC-6)
      Dim condenserModel = series & "-" & model
      
      condenser_specs_control.GetControlValues(Me.Equipment)
      
      Try
         Dim condenser = rae.solutions.condensers.condenser_repository.RetrieveCondenser(condenserModel)
         CType(Me.Equipment, CondenserEquipmentItem).Specs.Refrigerant = condenser.refrigerant
         With Me.Equipment.common_specs
            .Length.value = condenser.length
            .Width.value = condenser.width
            .Height.value = condenser.height
            .ShippingWeight.value = condenser.shipping_weight
            .OperatingWeight.value = condenser.operating_weight
         End With
      Catch ex As ArgumentException
         ' ignores ArgumentException and ArgumentNullException
      Catch ex As Exception
         With Me.Equipment.common_specs
            .Length.set_to_null
            .Width.set_to_null
            .Height.set_to_null
            .ShippingWeight.set_to_null
            .OperatingWeight.set_to_null
         End With
         warn("The condenser data cannot be loaded. " & ex.Message)
      End Try
      
      condenser_specs_control.SetControlValues(Me.Equipment)
   End Sub
   
   Private Function convertToCondenserProcess() As ProcessItem
      Dim unit = CType(grabEquipment(), CondenserEquipmentItem)
      Dim process = New CondenserProcessItem(CType(unit, CondenserEquipmentItem))
      Return process
   End Function


End Class
