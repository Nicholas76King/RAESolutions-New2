Friend Class product_cooler_pricing_screen
    Sub New()
        InitializeComponent()

        Dim product_cooler_presenter = CType(presenter, product_cooler_pricing_presenter)
        If user.can_view_pricing Then
            barReports.DropDownItems.Add("Order Write Up", Nothing, AddressOf product_cooler_presenter.show_order_write_up)
            mnu_order_write_up = mnuReports.DropDownItems.Add("Order Write Up", Nothing, AddressOf product_cooler_presenter.show_order_write_up)
        End If
        mnuDrawings.Visible = False
        barDrawings.Visible = False






    End Sub

    Protected Overrides Function create_presenter() As equipment_pricing_presenter_base
        Return New product_cooler_pricing_presenter(Me, appInfo.main)
    End Function
End Class