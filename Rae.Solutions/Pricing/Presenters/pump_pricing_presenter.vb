Class pump_pricing_presenter : Inherits equipment_pricing_presenter_base

   Sub New(equipView As EquipmentForm, mainView As MainForm)
      MyBase.New(equipView, mainView)
   End Sub
   
   protected overrides function create_submittal as accessories_base
      return new pump_accessories(equipview)
   end function
   
   protected overrides function create_order_write_up() as order_write_up_base
      return new pump_order_write_up(equipView)
   end function
   
End Class
