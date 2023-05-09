Option Strict Off

Imports RAE.Io.Text
Imports RAE.RAESolutions.DataAccess
Imports System.Data
Imports System.Environment
Imports System.IO
Imports t1 = RAE.Solutions.condensing_units.Table

Public Class d_series_data

    Function get_data(ByVal letter As String, ByVal division As String) As DataTable
        Dim table = get_condensing_units_for_d_series(letter, division)

        Dim price_column_name = "List Price"
        table.Columns.Add(price_column_name, GetType(String))
        For Each row As DataRow In table.Rows
            row(price_column_name) = get_base_list(row("Model"))
        Next


        Dim rla_208_SF_1_column_name = "Unit RLA 208v 1PH Ckt1"
        table.Columns.Add(rla_208_SF_1_column_name, GetType(String))
        Dim rla_208_SF_2_column_name = "Unit RLA 208v 1PH Ckt2"
        table.Columns.Add(rla_208_SF_2_column_name, GetType(String))
        Dim mca_208_SF_1_column_name = "Unit MCA 208v 1PH Ckt1"
        table.Columns.Add(mca_208_SF_1_column_name, GetType(String))
        Dim mca_208_SF_2_column_name = "Unit MCA 208v 1PH Ckt2"
        table.Columns.Add(mca_208_SF_2_column_name, GetType(String))


        Dim rla_208_1_column_name = "Unit RLA 208v 3PH Ckt1"
        table.Columns.Add(rla_208_1_column_name, GetType(String))
        Dim rla_208_2_column_name = "Unit RLA 208v 3PH Ckt2"
        table.Columns.Add(rla_208_2_column_name, GetType(String))
        Dim mca_208_1_column_name = "Unit MCA 208v 3PH Ckt1"
        table.Columns.Add(mca_208_1_column_name, GetType(String))
        Dim mca_208_2_column_name = "Unit MCA 208v 3PH Ckt2"
        table.Columns.Add(mca_208_2_column_name, GetType(String))


        '' add 230v s ph,  round integers to integers, otherwize tenths


        Dim rla_230_SF_1_column_name = "Unit RLA 230v 1PH Ckt1"
        table.Columns.Add(rla_230_SF_1_column_name, GetType(String))
        Dim rla_230_SF_2_column_name = "Unit RLA 230v 1PH Ckt2"
        table.Columns.Add(rla_230_SF_2_column_name, GetType(String))
        Dim mca_230_SF_1_column_name = "Unit MCA 230v 1PH Ckt1"
        table.Columns.Add(mca_230_SF_1_column_name, GetType(String))
        Dim mca_230_SF_2_column_name = "Unit MCA 230v 1PH Ckt2"
        table.Columns.Add(mca_230_SF_2_column_name, GetType(String))



        Dim rla_230_1_column_name = "Unit RLA 230v 3PH Ckt1"
        table.Columns.Add(rla_230_1_column_name, GetType(String))
        Dim rla_230_2_column_name = "Unit RLA 230v 3PH Ckt2"
        table.Columns.Add(rla_230_2_column_name, GetType(String))
        Dim mca_230_1_column_name = "Unit MCA 230v 3PH Ckt1"
        table.Columns.Add(mca_230_1_column_name, GetType(String))
        Dim mca_230_2_column_name = "Unit MCA 230v 3PH Ckt2"
        table.Columns.Add(mca_230_2_column_name, GetType(String))

        Dim rla_460_1_column_name = "Unit RLA 460v 3PH Ckt1"
        table.Columns.Add(rla_460_1_column_name, GetType(String))
        Dim rla_460_2_column_name = "Unit RLA 460v 3PH Ckt2"
        table.Columns.Add(rla_460_2_column_name, GetType(String))
        Dim mca_460_1_column_name = "Unit MCA 460v 3PH Ckt1"
        table.Columns.Add(mca_460_1_column_name, GetType(String))
        Dim mca_460_2_column_name = "Unit MCA 460v 3PH Ckt2"
        table.Columns.Add(mca_460_2_column_name, GetType(String))



        Dim rla_575_1_column_name = "Unit RLA 575v 3PH Ckt1"
        table.Columns.Add(rla_575_1_column_name, GetType(String))
        Dim rla_575_2_column_name = "Unit RLA 575v 3PH Ckt2"
        table.Columns.Add(rla_575_2_column_name, GetType(String))
        Dim mca_575_1_column_name = "Unit MCA 575v 3PH Ckt1"
        table.Columns.Add(mca_575_1_column_name, GetType(String))
        Dim mca_575_2_column_name = "Unit MCA 575v 3PH Ckt2"
        table.Columns.Add(mca_575_2_column_name, GetType(String))


        Dim CompAmps_208_SF_1_column_name = "Comp RLA 208v 1PH Ckt1"
        table.Columns.Add(CompAmps_208_SF_1_column_name, GetType(String))
        Dim CompAmps_208_SF_2_column_name = "Comp RLA 208v 1PH Ckt2"
        table.Columns.Add(CompAmps_208_SF_2_column_name, GetType(String))

        Dim CompAmps_208_1_column_name = "Comp RLA 208v 3PH Ckt1"
        table.Columns.Add(CompAmps_208_1_column_name, GetType(String))
        Dim CompAmps_208_2_column_name = "Comp RLA 208v 3PH Ckt2"
        table.Columns.Add(CompAmps_208_2_column_name, GetType(String))

        Dim CompAmps_230_SF_1_column_name = "Comp RLA 230v 1PH Ckt1"
        table.Columns.Add(CompAmps_230_SF_1_column_name, GetType(String))
        Dim CompAmps_230_SF_2_column_name = "Comp RLA 230v 1PH Ckt2"
        table.Columns.Add(CompAmps_230_SF_2_column_name, GetType(String))


        Dim CompAmps_230_1_column_name = "Comp RLA 230v 3PH Ckt1"
        table.Columns.Add(CompAmps_230_1_column_name, GetType(String))
        Dim CompAmps_230_2_column_name = "Comp RLA 230v 3PH Ckt2"
        table.Columns.Add(CompAmps_230_2_column_name, GetType(String))


        Dim CompAmps_460_1_column_name = "Comp RLA 460v 3PH Ckt1"
        table.Columns.Add(CompAmps_460_1_column_name, GetType(String))
        Dim CompAmps_460_2_column_name = "Comp RLA 460v 3PH Ckt2"
        table.Columns.Add(CompAmps_460_2_column_name, GetType(String))
        Dim CompAmps_575_1_column_name = "Comp RLA 575v 3PH Ckt1"
        table.Columns.Add(CompAmps_575_1_column_name, GetType(String))
        Dim CompAmps_575_2_column_name = "Comp RLA 575v 3PH Ckt2"
        table.Columns.Add(CompAmps_575_2_column_name, GetType(String))


        ' add single plase motor amps @ 1ph for 208 and 230
        ' round everything right of Unit RLA 208v 1PH Ckt1 to tenths.  Include .0


        Dim motor_amps_at_208v_SP_column_name = "Motor Amps 208v 1PH"
        table.Columns.Add(motor_amps_at_208v_SP_column_name, GetType(String))
        Dim motor_amps_at_208v_column_name = "Motor Amps 208v 3PH"
        table.Columns.Add(motor_amps_at_208v_column_name, GetType(String))
        Dim motor_amps_at_230v_SP_column_name = "Motor Amps 230v 1PH"
        table.Columns.Add(motor_amps_at_230v_SP_column_name, GetType(String))
        Dim motor_amps_at_230v_column_name = "Motor Amps 230v 3PH"
        table.Columns.Add(motor_amps_at_230v_column_name, GetType(String))
        Dim motor_amps_at_460v_column_name = "Motor Amps 460v 3PH"
        table.Columns.Add(motor_amps_at_460v_column_name, GetType(String))
        Dim motor_amps_at_575v_column_name = "Motor Amps 575v 3PH"
        table.Columns.Add(motor_amps_at_575v_column_name, GetType(String))




        For Each row As DataRow In table.Rows

            Dim electrical_info_at_208 = get_rla(row(t1.model), voltage:=208, phase:=3)
            row(rla_208_1_column_name) = FixNumberForCatalog(electrical_info_at_208.rla1, 1)
            row(rla_208_2_column_name) = FixNumberForCatalog(electrical_info_at_208.rla2, 1)
            row(mca_208_1_column_name) = FixNumberForCatalog(electrical_info_at_208.mca1, 1)
            row(mca_208_2_column_name) = FixNumberForCatalog(electrical_info_at_208.mca2, 1)
            row(CompAmps_208_1_column_name) = FixNumberForCatalog(electrical_info_at_208.compAmps1, 1)
            row(CompAmps_208_2_column_name) = FixNumberForCatalog(electrical_info_at_208.compAmps2, 1)


            Dim electrical_info_at_208_1PH = get_rla(row(t1.model), voltage:=208, phase:=1)
            row(rla_208_SF_1_column_name) = FixNumberForCatalog(electrical_info_at_208_1PH.rla1, 1)
            row(rla_208_SF_2_column_name) = FixNumberForCatalog(electrical_info_at_208_1PH.rla2, 1)
            row(mca_208_SF_1_column_name) = FixNumberForCatalog(electrical_info_at_208_1PH.mca1, 1)
            row(mca_208_SF_2_column_name) = FixNumberForCatalog(electrical_info_at_208_1PH.mca2, 1)
            row(CompAmps_208_SF_1_column_name) = FixNumberForCatalog(electrical_info_at_208_1PH.compAmps1, 1)
            row(CompAmps_208_SF_2_column_name) = FixNumberForCatalog(electrical_info_at_208_1PH.compAmps2, 1)



            Dim electrical_info_at_230 = get_rla(row(t1.model), voltage:=230, phase:=3)
            row(rla_230_1_column_name) = FixNumberForCatalog(electrical_info_at_230.rla1, 1)
            row(rla_230_2_column_name) = FixNumberForCatalog(electrical_info_at_230.rla2, 1)
            row(mca_230_1_column_name) = FixNumberForCatalog(electrical_info_at_230.mca1, 1)
            row(mca_230_2_column_name) = FixNumberForCatalog(electrical_info_at_230.mca2, 1)
            row(CompAmps_230_1_column_name) = FixNumberForCatalog(electrical_info_at_230.compAmps1, 1)
            row(CompAmps_230_2_column_name) = FixNumberForCatalog(electrical_info_at_230.compAmps2, 1)



            Dim electrical_info_at_230_1PH = get_rla(row(t1.model), voltage:=230, phase:=1)
            row(rla_230_SF_1_column_name) = FixNumberForCatalog(electrical_info_at_230_1PH.rla1, 1)
            row(rla_230_SF_2_column_name) = FixNumberForCatalog(electrical_info_at_230_1PH.rla2, 1)
            row(mca_230_SF_1_column_name) = FixNumberForCatalog(electrical_info_at_230_1PH.mca1, 1)
            row(mca_230_SF_2_column_name) = FixNumberForCatalog(electrical_info_at_230_1PH.mca2, 1)
            row(CompAmps_230_SF_1_column_name) = FixNumberForCatalog(electrical_info_at_230_1PH.compAmps1, 1)
            row(CompAmps_230_SF_2_column_name) = FixNumberForCatalog(electrical_info_at_230_1PH.compAmps2, 1)



            Dim electrical_info_at_460 = get_rla(row(t1.model), voltage:=460, phase:=3)
            row(rla_460_1_column_name) = FixNumberForCatalog(electrical_info_at_460.rla1, 1)
            row(rla_460_2_column_name) = FixNumberForCatalog(electrical_info_at_460.rla2, 1)
            row(mca_460_1_column_name) = FixNumberForCatalog(electrical_info_at_460.mca1, 1)
            row(mca_460_2_column_name) = FixNumberForCatalog(electrical_info_at_460.mca2, 1)
            row(CompAmps_460_1_column_name) = FixNumberForCatalog(electrical_info_at_460.compAmps1, 1)
            row(CompAmps_460_2_column_name) = FixNumberForCatalog(electrical_info_at_460.compAmps2, 1)


            Dim electrical_info_at_575 = get_rla(row(t1.model), voltage:=575, phase:=3)
            row(rla_575_1_column_name) = FixNumberForCatalog(electrical_info_at_575.rla1, 1)
            row(rla_575_2_column_name) = FixNumberForCatalog(electrical_info_at_575.rla2, 1)
            row(mca_575_1_column_name) = FixNumberForCatalog(electrical_info_at_575.mca1, 1)
            row(mca_575_2_column_name) = FixNumberForCatalog(electrical_info_at_575.mca2, 1)
            row(CompAmps_575_1_column_name) = FixNumberForCatalog(electrical_info_at_575.compAmps1, 1)
            row(CompAmps_575_2_column_name) = FixNumberForCatalog(electrical_info_at_575.compAmps2, 1)

            Dim motor_repository = New RAE.Solutions.motors.repository()
            row(motor_amps_at_208v_column_name) = motor_repository.get_amps(row(t1.three_phase_motor_part_number230460), 208)
            row(motor_amps_at_230v_column_name) = motor_repository.get_amps(row(t1.three_phase_motor_part_number230460), 230)
            row(motor_amps_at_460v_column_name) = motor_repository.get_amps(row(t1.three_phase_motor_part_number230460), 460)



            If String.IsNullOrEmpty(row(t1.single_phase_motor_part_number).ToString) Then
                row(motor_amps_at_208v_SP_column_name) = FixNumberForCatalog("", 1)
            Else
                row(motor_amps_at_208v_SP_column_name) = motor_repository.get_amps(row(t1.single_phase_motor_part_number), 208)
            End If

            If String.IsNullOrEmpty(row(t1.single_phase_motor_part_number).ToString) Then
                row(motor_amps_at_230v_SP_column_name) = FixNumberForCatalog("", 1)
            Else
                row(motor_amps_at_230v_SP_column_name) = motor_repository.get_amps(row(t1.single_phase_motor_part_number), 230)
            End If



            If String.IsNullOrEmpty(row("3_ph_575V_mtr_part_number").ToString) Then
                row(motor_amps_at_575v_column_name) = FixNumberForCatalog("", 1)
            Else
                row(motor_amps_at_575v_column_name) = FixNumberForCatalog(motor_repository.get_amps(row(t1.three_phase_motor_part_number575), 575), 1)
            End If

        Next

        Return table
    End Function






    Private Function FixNumberForCatalog(ByVal x As String, ByVal i As Integer) As String
        '  If String.IsNullOrEmpty(x) OrElse (IsNumeric(x) AndAlso Double.Parse(x) = 0) Then Return "N/A"

        If Not String.IsNullOrEmpty(x) AndAlso IsNumeric(x) Then
            Return Math.Round(CDbl(x), i).ToString("0.0")
        End If


        Return x
    End Function

    Private Function get_rla(ByVal model As String, ByVal voltage As Integer, ByVal phase As Integer) As RAE.Solutions.drawings.condensing_unit_electrical_info


        Dim service As RAE.Solutions.drawings.i_drawing_service =
         New RAE.Solutions.drawings.drawing_service()
        Dim electrical_info = service.GetCondensingUnitElectricalInfo(model, voltage, phase, 60,
         et10:=False, mc20:=False, division:=RAE.RAESolutions.Business.Division.CRI)

        Return electrical_info




    End Function

    Private Function build_string_builder_format_for_sql_select(ByVal number_of_columns As Integer, ByVal includeBrackets As Boolean) As String
        Dim sql = "SELECT "
        For i = 0 To number_of_columns - 1
            If includeBrackets Then
                sql &= "[{" & i & "}]"
            Else
                sql &= "{" & i & "} "
            End If
            sql &= If(i < number_of_columns - 1, ", ", "")
        Next

        Return sql
    End Function

    Private Function get_condensing_units_for_d_series(ByVal letter As String, ByVal division As String) As DataTable
        Dim connection = Common.CreateConnection(Common.CondensingUnitDbPath)
        Dim command = connection.CreateCommand()
        Dim sql = build_string_builder_format_for_sql_select(72, False)
        sql = Str(sql & "FROM {72} ",
                      t1.model, t1.refrigerant, t1.temperature_range, "'' as CompManuModel1", t1.CompressorMasterID1, t1.compressor_quantity_1, "'' as CompManuModel2",
                      t1.CompressorMasterID2, t1.compressor_quantity_2, t1.compressor_quantity_description, t1.compressor_type_1,
                      t1.coil_diameter_1, t1.fanID_1, t1.fan_quantity_1, t1.fan_hp_1, t1.coil_model_1, t1.coil_quantity_1, t1.coil_height_1, t1.coil_length_1, t1.number_of_rows_1, t1.fpi_1, t1.capacity_1,
                      t1.has_subcooling_1, t1.subcooling_percent_1, t1.suction_connection_ods_1, t1.liquid_connection_ods_1,
                      t1.single_circuit_suction_connection_ods, t1.single_circuit_liquid_connection_ods, t1.suction_connection_ods_2, t1.liquid_connection_ods_2,
                      t1.compressor_type_2, t1.has_subcooling_2, t1.refrigerant_2, t1.coil_diameter_2, t1.fanID_2, t1.fan_quantity_2, t1.fan_hp_2,
                      t1.coil_model_2, t1.coil_quantity_2, t1.coil_height_2, t1.coil_length_2, t1.number_of_rows_2, t1.fpi_2, t1.capacity_2,
                      t1.subcooling_percent_2, t1.number_of_circuits, t1.number_of_refrigerant_circuits_1, t1.number_of_refrigerant_circuits_2, t1.authorization_level,
                      t1.division, "[" & t1.single_phase_motor_part_number & "]", "[" & t1.three_phase_motor_part_number230460 & "]", "[" & t1.three_phase_motor_part_number575 & "]", t1.capacity_min, t1.capacity_max,
                      t1.series, t1.dimensions, t1.mca_208, t1.mca_460, t1.operating_weight, t1.flood_operating_charge,
                      t1.receiver_size, "[" & t1.receiver_capacity_at_80_percent & "]", t1.standard_operating_charge, t1.dimension_d, t1.unit_length, t1.unit_width, t1.unit_height,
                      t1.dimension_a, t1.dimension_b, t1.dimension_c, t1.shipping_weight, t1.table_name) '72
        sql &= Str("WHERE {0} LIKE '" & letter & "%' AND {1} <> 'R22' ORDER BY {1}, {2} DESC, {0}",
                  t1.model, t1.refrigerant, t1.temperature_range)
        command.CommandText = sql
        Dim reader As IDataReader
        Dim table As New DataTable()
        Try
            connection.Open()
            reader = command.ExecuteReader()
            table.Load(reader)


            If division = "CRI" Then
                For Each row As DataRow In table.Rows
                    row(t1.operating_weight) = System.Math.Round(row(t1.operating_weight) * 1.15)
                    row(t1.shipping_weight) = System.Math.Round(row(t1.shipping_weight) * 1.15)
                Next
            End If


            table.Columns("CompManuModel1").ReadOnly = False
            table.Columns("CompManuModel2").ReadOnly = False

            For Each row As DataRow In table.Rows
                row("CompManuModel1") = getCompressorManuModel(row("CompressorMasterID1"))
                row("CompManuModel2") = getCompressorManuModel(row("CompressorMasterID2"))
            Next



        Finally
            If reader IsNot Nothing Then _
               reader.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try

        Return table
    End Function


    Function getCompressorManuModel(ByVal masterID As String) As String

        Dim con = Common.CreateConnection(Common.CompressorDbPath)
        Dim cmd = con.CreateCommand()

        getCompressorManuModel = ""


        '    Dim oldMethodFlag As Boolean
        Dim sql As String


        sql = "select manufacturermodelnumber from master where masterid = '" & masterID & "'"

        cmd.CommandText = sql
        Dim rdr As IDataReader

        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                getCompressorManuModel = rdr("manufacturermodelnumber")
            End If
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If con.State <> ConnectionState.Closed Then _
               con.Close()
        End Try



    End Function











    Private Function get_base_list(model As String) As String
        Dim series = model.Substring(0, 2)
        model = model.Substring(2, model.Length - 2)
        Dim list_price As String
        Try
            list_price = RAE.DataAccess.EquipmentOptions.OptionsDataAccess.RetrieveBaseListPrice(series, model)
        Catch
            list_price = "NA"
        End Try

        Return list_price
    End Function

End Class
