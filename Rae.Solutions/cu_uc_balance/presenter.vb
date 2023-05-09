Imports Rae.Solutions.cu_uc_balances
Imports Rae.Solutions.unit_coolers
Imports Rae.Ui.quickies

Interface i_cu_uc_balance_view
    Property balance As Double
    'Property unit_coolers_grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Property DataGridView1 As DataGridView
End Interface

Class presenter
    Private view As cu_uc_balance_window
    Private service As service
    Sub New(ByVal view As cu_uc_balance_window)
        Me.view = view
        service = New service()
    End Sub

    Function calculate_balance() As Double
        Dim unit_coolers = view.grab_unit_coolers_for_capacity()
        Dim condensing_unit = view.grab_condensing_unit_for_capacity()

        condensing_unit.capacity = condensing_unit.capacity / condensing_unit.quantity

        view.balance = service.calculate_balance(condensing_unit, unit_coolers)




        Return view.balance
    End Function

    Sub fill_unit_coolers()
        Dim validators = view.grab_fill_unit_coolers_validators()
        If validators.validate().is_invalid Then
            alert(validators.messages.toString)
            ''view.unit_coolers_grid.Visible = False
            view.DataGridView1.Visible = False
            Exit Sub
        Else
            'view.unit_coolers_grid.Visible = True
            view.DataGridView1.Visible = True
        End If

        Dim balance = calculate_balance()

        Dim criteria = view.grab_criteria_to_find_unit_coolers()
        Dim unit_coolers = service.find_unit_coolers(criteria)



        'view.unit_coolers_grid.DataSource = convert_to_table(unit_coolers, balance, criteria.suction_temp, criteria.td)

        'view.format_unit_coolers_grid()
        Try

            'Dim table As System.Data.DataTable = convert_to_table(unit_coolers, balance, criteria.suction_temp, criteria.td)
            view.grdCoolerView.BorderStyle = BorderStyle.Fixed3D

            view.grdCoolerView.DataSource = convert_to_table(unit_coolers, balance, criteria.suction_temp, criteria.td)
        Catch ex As Exception
            Beep()
        End Try
    End Sub

    Public Function convert_to_table(ByVal unit_coolers As Rae.Solutions.unit_coolers.unit_cooler_list, ByVal balance As Double, ByVal suction_temp As Double, ByVal td As Double) As System.Data.DataTable
        Try
            Dim table = New System.Data.DataTable()
            table.Columns.Add("Model")
            table.Columns.Add("Quantity Required")
            table.Columns.Add("Est. Capacity")
            table.Columns.Add("Face Velocity")

            For Each unit_cooler In unit_coolers
                Dim quantity_required = System.Math.Round(balance / unit_cooler.capacity_at(suction_temp, td, 0), 2)
                If CInt(unit_cooler.face_velocity) < 626 And suction_temp > 25 Then
                    table.Rows.Add(unit_cooler.model, quantity_required, System.Math.Round(unit_cooler.capacity_at(suction_temp, td, 0)), System.Math.Round(unit_cooler.face_velocity))
                ElseIf suction_temp <= 25 Then
                    table.Rows.Add(unit_cooler.model, quantity_required, System.Math.Round(unit_cooler.capacity_at(suction_temp, td, 0)), System.Math.Round(unit_cooler.face_velocity))
                End If
            Next
            Return table
        Catch ex As Exception
            Return New System.Data.DataTable()
        End Try
    End Function


End Class