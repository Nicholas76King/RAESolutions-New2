class fluid_cooler_pricing_screen

   sub new
      InitializeComponent

      dim fluid_cooler_presenter = ctype(presenter, fluid_cooler_pricing_presenter)
      if user.can_view_pricing then
         barReports.DropDownItems.Add("Order Write Up", nothing, addressof fluid_cooler_presenter.show_order_write_up)
         mnu_order_write_up = mnuReports.DropDownItems.Add("Order Write Up", nothing, addressof fluid_cooler_presenter.show_order_write_up)
      end if
   end sub

   protected overrides function create_presenter() As equipment_pricing_presenter_base
      return new fluid_cooler_pricing_presenter(me, appInfo.main)
   end function

end class