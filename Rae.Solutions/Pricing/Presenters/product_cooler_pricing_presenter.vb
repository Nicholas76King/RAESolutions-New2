class product_cooler_pricing_presenter : inherits equipment_pricing_presenter_base
   sub new(equipment_screen as EquipmentForm, main_screen as MainForm)
        MyBase.new(equipment_screen, main_screen)



   end sub
   
   protected overrides function create_order_write_up as order_write_up_base
      return new product_cooler_order_write_up(equipView)
   end function

   protected overrides function create_submittal as accessories_base
      return new product_cooler_accessories(equipView)
   end function

    Sub show_order_write_up()

        Dim returnTab As Integer
        If Not equipView.CheckObligatoryOptionsAndSpecs(returnTab) Then
            ' Me.tabEquipment.SelectedIndex = 1
            Exit Sub
        End If




        Dim junk As String = ""
        create_order_write_up.show(False, junk)
    End Sub
end class