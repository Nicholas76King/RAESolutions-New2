Friend Class condensing_unit_pricing_screen

    Sub New()
        InitializeComponent()

        Dim cu_presenter = CType(presenter, condensing_unit_pricing_presenter)
        If user.can_view_pricing Then


            If AppInfo.Division = Business.Division.CRI OrElse user.username.ToLower = "adamm" OrElse user.username.ToLower = "caseyj" Then
                barReports.DropDownItems.Add("Order Write Up", Nothing, AddressOf cu_presenter.show_order_write_up)
                mnu_order_write_up = mnuReports.DropDownItems.Add("Order Write Up", Nothing, AddressOf cu_presenter.show_order_write_up)
            End If

            If AppInfo.Division = Business.Division.TSI Then
                barReports.DropDownItems.Add("Equipment Proposal", Nothing, AddressOf showEquipmentProposal)
                mnu_order_write_up = mnuReports.DropDownItems.Add("Equipment Proposal", Nothing, AddressOf showEquipmentProposal)
            End If

        End If
    End Sub


    Sub showEquipmentProposal()
        Dim junk As String = ""

        Try

            Dim proposal = New CondensingUnitProposal(Me)
            proposal.show()

        Catch ex As Exception
            MsgBox("An error occurred while generating report.  Pleasy verify all inputs and try again.")
        End Try




    End Sub


    Protected Overrides Function create_presenter() As equipment_pricing_presenter_base
        Return New condensing_unit_pricing_presenter(Me, AppInfo.Main)
    End Function


End Class
