Imports Rae.RaeSolutions.unit_cooler_selection
Imports Rae.solutions.unit_coolers.selections
Imports Rae.validation
Imports System.IO
Imports Rae.RaeSolutions.DataAccess
Imports System.Data

Public Class unit_cooler_selection_screen : Implements i_view

    Friend Event user_set_room_temperature(ByVal room_temperature As Double, ByVal td As Double) _
    Implements i_view.user_set_room_temperature

    Friend Event user_set_td(ByVal room_temperature As Double, ByVal td As Double) _
    Implements i_view.user_set_td

    Event user_wants_to_find_unit_coolers(ByVal input As unit_cooler_input, ByVal isEmployee As Boolean, sp As Decimal) _
    Implements i_view.user_wants_to_find_unit_coolers

    Property suction_temperature As Double _
    Implements i_view.suction_temperature
        Set(ByVal value As Double)
            lbl_suction_temperature_value.Text = value
        End Set
        Get
            Return lbl_suction_temperature_value.Text
        End Get
    End Property

    Sub initialize(ByVal unit_cooler As unit_cooler_input) _
    Implements i_view.initialize
        txt_total_capacity.Text = unit_cooler.total_capacity
        txt_total_capacity.only.required.positive_number()

        txt_unit_cooler_quantity.Text = unit_cooler.unit_cooler_quantity
        txt_unit_cooler_quantity.only.required.positive_number()

        txt_room_temperature.Text = unit_cooler.room_temperature
        txt_room_temperature.required()

        txt_td.Text = unit_cooler.td
        txt_td.only.required.positive_number()

        cbo_series.SelectedItem = unit_cooler.series
        cbo_refrigerant.SelectedItem = unit_cooler.refrigerant
        cbo_defrost_type.SelectedItem = unit_cooler.defrost_type
        cbo_fan_quantity.SelectedItem = unit_cooler.fan_quantity
        cbo_static_pressure.SelectedItem = unit_cooler.static_pressure
        ddlDOEModels.SelectedItem = unit_cooler.DOEModels
    End Sub

    Sub set_unit_cooler_results(ByVal results As System.Data.DataTable) _
    Implements i_view.set_unit_cooler_results
        grd_unit_coolers.DataSource = results
        grd_unit_coolers.Columns("Model").HeaderText = "Model"
        grd_unit_coolers.Columns("Capacity").DefaultCellStyle.Format = "#,#"
        grd_unit_coolers.Columns("Capacity").HeaderText = "Est. Capacity @ Design TD*"
        grd_unit_coolers.Columns("Length").HeaderText = "Length [in.]*"
        grd_unit_coolers.Columns("Width").HeaderText = "Width [in.]*"
        grd_unit_coolers.Columns("Height").HeaderText = "Height [in.]*"
        grd_unit_coolers.Columns("Actual_td").HeaderText = "Actual TD"
        grd_unit_coolers.Columns("Actual_td").DefaultCellStyle.Format = "#0.0"
        grd_unit_coolers.Columns("Cfm").HeaderText = "CFM"
        grd_unit_coolers.Columns("Cfm").DefaultCellStyle.Format = "#,#"
        grd_unit_coolers.Columns("Face_velocity").HeaderText = "Face Velocity [fpm]"
        grd_unit_coolers.Columns("Face_velocity").DefaultCellStyle.Format = "#,#"
        grd_unit_coolers.Columns("Price").HeaderText = "List Price Per Unit"
        grd_unit_coolers.Columns("Price").DefaultCellStyle.Format = "$#,#"
        grd_unit_coolers.Columns("Price").DefaultCellStyle.NullValue = "NA"
        grd_unit_coolers.Columns("Shipping_weight").HeaderText = "Shipping Weight"
        grd_unit_coolers.Columns("Shipping_weight").DefaultCellStyle.Format = "#,#"
        grd_unit_coolers.Columns("Operating_weight").HeaderText = "Operating Weight"
        grd_unit_coolers.Columns("Operating_weight").DefaultCellStyle.Format = "#,#"
    End Sub

    Sub txt_room_temperature_text_changed() Handles txt_room_temperature.TextChanged
        If txt_room_temperature.valid And txt_td.validate Then
            RaiseEvent user_set_room_temperature(txt_room_temperature.Text, txt_td.Text)
        End If
    End Sub

    Sub txt_td_text_changed() Handles txt_td.TextChanged
        If txt_room_temperature.valid And txt_td.validate Then
            RaiseEvent user_set_td(txt_room_temperature.Text, txt_td.Text)
        End If
    End Sub



    Private Function grab_input() As unit_cooler_input
        Dim input As unit_cooler_input

        input.total_capacity = txt_total_capacity.Text
        input.unit_cooler_quantity = txt_unit_cooler_quantity.Text
        input.room_temperature = txt_room_temperature.Text
        input.td = txt_td.Text
        input.series = cbo_series.SelectedItem
        input.refrigerant = cbo_refrigerant.SelectedItem
        input.defrost_type = cbo_defrost_type.SelectedItem
        input.static_pressure = cbo_static_pressure.SelectedItem
        input.fan_quantity = cbo_fan_quantity.SelectedItem
        input.DOEModels = ddlDOEModels.SelectedItem

        Return input
    End Function

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim report As Rae.reporting.beta.report

        Dim report_file_path As String = Path.Combine(Common.AppFolderPath, "reports")
        If Not report_file_path.EndsWith("\") Then report_file_path &= "\"

        report = New Rae.reporting.beta.report(report_file_path & "Blank.docx")


        'Dim dt1 As New DataTable
        'dt1.Columns.Add("Total Capacity")
        'dt1.Columns.Add("Qty")
        'dt1.Columns.Add("Series")
        'dt1.Columns.Add("Refrigerant")
        'dt1.Columns.Add("Defrost")
        'dt1.Columns.Add("Design Room Temp")
        'dt1.Columns.Add("Design TD")
        'dt1.Columns.Add("Evap Temp")
        'dt1.Columns.Add("Static Pressure")
        'dt1.Columns.Add("Fan Qty")

        'Dim dr1 As DataRow = dt1.NewRow

        'dr1("Total Capacity") = txt_total_capacity.Text
        'dr1("Qty") = txt_unit_cooler_quantity.Text
        'dr1("Series") = cbo_series.Text
        'dr1("Refrigerant") = cbo_refrigerant.Text
        'dr1("Defrost") = cbo_defrost_type.Text
        'dr1("Design Room Temp") = txt_room_temperature.Text
        'dr1("Design TD") = txt_td.Text
        'dr1("Evap Temp") = lbl_suction_temperature_value.Text
        'dr1("Static Pressure") = cbo_static_pressure.Text
        'dr1("Fan Qty") = cbo_fan_quantity.Text

        'dt1.Rows.Add(dr1)

        'report.set_table(dt1)


        Dim sl1 As New List(Of String)

        sl1.Add("Est. Total Capacity: " & txt_total_capacity.Text)
        sl1.Add("Qty: " & txt_unit_cooler_quantity.Text)
        sl1.Add("Series: " & cbo_series.Text)
        sl1.Add("Refrigerant: " & cbo_refrigerant.Text)
        sl1.Add("Defrost: " & cbo_defrost_type.Text)
        sl1.Add("Design Room Temp: " & txt_room_temperature.Text)
        sl1.Add("Design TD: " & txt_td.Text)
        sl1.Add("Evap Temp: " & lbl_suction_temperature_value.Text)
        sl1.Add("Static Pressure: " & cbo_static_pressure.Text)
        sl1.Add("Fan Qty: " & cbo_fan_quantity.Text)

        report.set_list(sl1)


        If Not Me.grd_unit_coolers.DataSource Is Nothing Then
            report.set_table(Me.grd_unit_coolers.DataSource)
        End If
        report.show()

    End Sub


    Private Sub btn_find_unit_coolers_click(sender As System.Object, e As System.EventArgs) Handles btn_find_unit_coolers.Click
        'todo: validate inputs
        Dim input = grab_input()
        RaiseEvent user_wants_to_find_unit_coolers(input, AppInfo.User.is_employee, cbo_static_pressure.SelectedValue)
    End Sub



    Private Sub txt_room_temperature_text_changed(sender As System.Object, e As System.EventArgs) Handles txt_room_temperature.TextChanged

    End Sub
    Private Sub txt_td_text_changed(sender As System.Object, e As System.EventArgs) Handles txt_td.TextChanged

    End Sub
End Class