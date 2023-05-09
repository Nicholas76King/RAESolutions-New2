Imports Rae.RaeSolutions.reports.file_paths
Imports Rae.reporting
Imports CrystalDecisions.CrystalReports.Engine
Imports Rae.RaeSolutions.SelectedOptionsDataSet
Imports System.Data

Class proposal
    Private screen As chiller_pricing_screen
    Private report_file_path As String

    Sub New(ByVal screen As chiller_pricing_screen)
        Me.screen = screen
        Me.report_file_path = evaporative_condenser_chiller_proposal_file_path



    End Sub

    Sub show()


        show_word_report() '()

        Exit Sub


        'Dim report = New report_factory().create(report_file_path)
        'Dim options = set_options_in(report)

        'set_controller_communication_in(report, options)

        'set_project_parameters_in(report)

        'Dim equipment_bag = New equipment_grabber(screen).grab()
        'set_equipment_parameters_in(report, equipment_bag)

        'Dim pricing_bag = New pricing_grabber(screen).grab()
        'set_pricing_parameters_in(report, pricing_bag, equipment_bag)

        'Dim spec_bag = New chiller_proposal_grabber(screen.specsControl).grab()
        'set_spec_parameters_in(report, spec_bag)

        'report.show()
    End Sub





    Private Sub show_word_report()
        'Dim parameters = get_report_parameters
        Dim text = New Dictionary(Of String, String)

        Dim options = setOptionsIn()

        setControllerCommunicationIn(options, text)
        setProjectParametersIn(text)

        Dim equipment_bag = New equipment_grabber(screen).grab()
        setEquipmentParametersIn(equipment_bag, text)

        Dim pricing_bag = New pricing_grabber(screen).grab()
        setPricingParametersIn(pricing_bag, equipment_bag, text)

        Dim spec_bag = New chiller_proposal_grabber(screen.specsControl).grab()
        setSpecParametersIn(spec_bag, text)





        ''footer
        'text.add("user", parameters.user)
        'text.add("application_version", parameters.application_version)
        'text.add("date_created", Date.now.ToShortDateString)
        'text.add("year", Date.now.year)
        ''


        'Dim notes = New list(Of String)
        'If parameters.operating_limits_message.is_set Then notes.add(parameters.operating_limits_message)
        'If parameters.pressure_drop_message.is_set Then notes.add(parameters.pressure_drop_message)
        'If parameters.catalog_rating_message.is_set Then notes.add(parameters.catalog_rating_message)
        'If parameters.temperature_range_message.is_set Then notes.Add(parameters.temperature_range_message)

        '        Dim command = New get_logo_file_path_command(user, AppInfo.division.toString)
        '       Dim logo_file_path = command.execute

        'Dim table = Me.results.copy
        'table.columns(0).ColumnName = "Leaving Fluid [°F]"
        'table.columns(1).ColumnName = "Ambient [°F]"
        'table.columns(2).ColumnName = "Evaporator [°F]"
        'table.columns(3).ColumnName = "Condenser [°F]"
        'table.columns(4).ColumnName = "Capacity [Tons]"
        'table.columns(5).ColumnName = "Unit [KW]"
        'table.columns(6).ColumnName = "GPM"
        'table.columns(7).ColumnName = "Evap. PD"
        'table.columns(8).ColumnName = "Compressor EER"
        'table.columns(9).ColumnName = "Unit EER"

        Dim report = New Rae.reporting.beta.report(reports.file_paths.EvaporativeCondenserChillerProposalFilePath)
        report.set_text(text)
        'report.set_table("table", table, New rae.reporting.beta.AIR_COOLED_CHILLER_report_table_factory, Design_suction, design_ambient)


        Dim filteredOptionsTableList As List(Of DataTable)

        filteredOptionsTableList = BuildFilteredOptions(options)

        For Each filteredOptionsTable As DataTable In filteredOptionsTableList
            report.set_table("SelectedFeaturesTable", filteredOptionsTable, New rae.reporting.beta.default_table_factory)
        Next




        'Dim equipmentDetailsList As DataTable

        'equipmentDetailsList = BuildEquipmentDetails(equipment_bag)

        'report.set_table("EquipmentDetails", equipmentDetailsList, New Rae.reporting.beta.price_sheet_table_factory)






        'report.set_list("notes", notes)
        'report.set_image("logo", logo_file_path)
        report.show()
    End Sub


    'Private Function BuildEquipmentDetails(ByVal bag As equipment_grabber.bag) As DataTable
    '    BuildEquipmentDetails = New DataTable

    '    BuildEquipmentDetails.Columns.Add("Qty")
    '    BuildEquipmentDetails.Columns.Add("Customer Tag")
    '    BuildEquipmentDetails.Columns.Add("Technical Systems Model Number")
    '    BuildEquipmentDetails.Columns.Add("Price Each")
    '    BuildEquipmentDetails.Columns.Add("Extended Price")


    '    Dim qtyRow As DataRow = BuildEquipmentDetails.NewRow
    '    qtyRow("Qty") = bag.quantity
    '    qtyRow("Customer Tag") = bag.tag
    '    qtyRow("Technical Systems Model Number") = bag.model
    '    qtyRow("Price Each") = -9999
    '    qtyRow("Extended Price") = -9999
    '    BuildEquipmentDetails.Rows.Add(qtyRow)

    '    Dim warrantyRow As DataRow = BuildEquipmentDetails.NewRow
    '    warrantyRow("Qty") = ""
    '    warrantyRow("Customer Tag") = ""
    '    warrantyRow("Technical Systems Model Number") = "Extended compressor warranty (5 years total parts only)"
    '    warrantyRow("Price Each") = -9999
    '    warrantyRow("Extended Price") = -9999
    '    BuildEquipmentDetails.Rows.Add(warrantyRow)

    '    Dim startupRow As DataRow = BuildEquipmentDetails.NewRow
    '    startupRow("Qty") = ""
    '    startupRow("Customer Tag") = ""
    '    startupRow("Technical Systems Model Number") = "Startup Supervision (1 tech / 1 trip / 5 days on site)"
    '    startupRow("Price Each") = ""
    '    startupRow("Extended Price") = -9999
    '    BuildEquipmentDetails.Rows.Add(startupRow)

    '    Dim freightRow As DataRow = BuildEquipmentDetails.NewRow
    '    freightRow("Qty") = ""
    '    freightRow("Customer Tag") = ""
    '    freightRow("Technical Systems Model Number") = "Freight (didicated haul)"
    '    freightRow("Price Each") = ""
    '    freightRow("Extended Price") = -9999
    '    BuildEquipmentDetails.Rows.Add(freightRow)

    '    Dim totalRow As DataRow = BuildEquipmentDetails.NewRow
    '    totalRow("Qty") = ""
    '    totalRow("Customer Tag") = ""
    '    totalRow("Technical Systems Model Number") = "Total Sale"
    '    totalRow("Price Each") = ""
    '    totalRow("Extended Price") = -9999
    '    BuildEquipmentDetails.Rows.Add(totalRow)


    'End Function


    Private Function BuildFilteredOptions(ByVal options As SelectedOptionsDataTable) As List(Of DataTable)

        BuildFilteredOptions = New List(Of DataTable)
        Dim categories As New List(Of String)

        Dim MasterList As New DataTable

        'MasterList.TableName = "Testing Table Name"
        MasterList.Columns.Add("Quantity")
        MasterList.Columns.Add("Code")
        MasterList.Columns.Add("Description")
        MasterList.Columns.Add("LongDescription")
        MasterList.Columns.Add("Category")

        For Each r1 In options
            Dim nRow As DataRow = MasterList.NewRow
            nRow("Quantity") = r1.Quantity
            nRow("Code") = r1.Code
            nRow("Description") = r1.Description
            nRow("LongDescription") = r1.LongDescription
            nRow("Category") = r1.Category

            If Not categories.Contains(r1.Category) Then categories.Add(r1.Category)

            MasterList.Rows.Add(nRow)
        Next

        '   categories.Sort()

        If categories.Contains(" Standard Features") Then
            categories.Remove(" Standard Features")
            categories.Insert(0, " Standard Features")
        End If




        For Each category As String In categories
            Dim filteredRows() As DataRow = MasterList.Select("Category = '" & category & "'")
            If filteredRows.Length > 0 Then
                Dim subList As New DataTable
                subList.Columns.Add("Quantity")
                subList.Columns.Add("Code")
                subList.Columns.Add("Description")
                subList.Columns.Add("LongDescription")

                For Each fRow As DataRow In filteredRows
                    Dim nRow As DataRow = subList.NewRow
                    nRow("Quantity") = fRow("Quantity")
                    nRow("Code") = fRow("Code")
                    nRow("Description") = fRow("Description")
                    nRow("LongDescription") = fRow("LongDescription")
                    subList.Rows.Add(nRow)
                Next
                subList.TableName = category
                BuildFilteredOptions.Add(subList)
            End If
        Next







    End Function


    Private Sub set_controller_communication_in(ByVal report As i_report, ByVal options As SelectedOptionsDataTable)
        Dim bms_communication = "None"
        Dim BacNET_code = "CC02"
        Dim LON_code = "CC03"

        For Each op As SelectedOptionsRow In options.Rows
            If op.Code = BacNET_code Then
                bms_communication = "BacNET Communication"
            ElseIf op.Code = LON_code Then
                bms_communication = "LON Communication"
            End If
        Next

        report.pass("controller_communication", bms_communication)
    End Sub



    Private Sub setControllerCommunicationIn(ByVal options As SelectedOptionsDataTable, ByRef text As Dictionary(Of String, String))
        Dim bms_communication = "None"
        'Dim BacNET_code = "CC02"
        'Dim LON_code = "CC03"

        For Each op As SelectedOptionsRow In options.Rows
            'If op.Code = BacNET_code Then
            '    bms_communication = "BacNET Communication"
            'ElseIf op.Code = LON_code Then
            '    bms_communication = "LON Communication"
            'End If


            If op.Code = "CC02" OrElse op.Code = "CC03" OrElse op.Code = "CC04" OrElse op.Code = "CC05" OrElse op.Code = "CC06" Then
                bms_communication = op.Description
            End If



        Next

        text.Add("controllerCommunication", bms_communication)
    End Sub


    Private Function set_options_in(ByVal report As i_report) As SelectedOptionsDataTable
        screen.populateSelectedOptionsDataSet(False)
        Dim options = screen.selectedOpsDs

        For Each op As SelectedOptionsRow In options.SelectedOptions.Rows
            If op.Price = 999999 Then op.Category = " Standard Features"
        Next


        Dim crystal_report = CType(report, ReportDocument)


        crystal_report.Subreports(0).SetDataSource(options)

        Return options.SelectedOptions
    End Function




    Private Function setOptionsIn() As SelectedOptionsDataTable
        screen.populateSelectedOptionsDataSet(False)
        Dim options = screen.selectedOpsDs

        For Each op As SelectedOptionsRow In options.SelectedOptions.Rows
            If op.Price = 999999 Then op.Category = " Standard Features"
        Next
        Return options.SelectedOptions
    End Function



    Private Sub set_project_parameters_in(ByVal report As i_report)
        Dim project_bag = New project_grabber(screen).grab()
        report.pass("project", project_bag.project_name)
        report.pass("representative_name", project_bag.rep)
        report.pass("representative_company_name", project_bag.rep_company)
    End Sub




    Private Sub setProjectParametersIn(ByRef text As Dictionary(Of String, String))
        Dim project_bag = New project_grabber(screen).grab()
        text.Add("project", project_bag.project_name)
        text.Add("representative", project_bag.rep)
        text.Add("RepresentativeCompany", project_bag.rep_company)
    End Sub




    Private Sub set_equipment_parameters_in(ByVal report As i_report, ByVal bag As equipment_grabber.bag)
        report.pass("model", If(bag.custom_model = "", _
                                bag.model, bag.custom_model))
        report.pass("qty", bag.quantity)
    End Sub


    Private Sub setEquipmentParametersIn(ByVal bag As equipment_grabber.bag, ByRef text As Dictionary(Of String, String))
        text.Add("model", If(bag.custom_model = "", bag.model, bag.custom_model))
        text.Add("quantity", bag.quantity)
    End Sub

    Private Sub set_pricing_parameters_in(ByVal report As i_report, ByVal pricing_bag As pricing_grabber.bag, ByVal equipment_bag As equipment_grabber.bag)
        Dim tab = Microsoft.VisualBasic.ControlChars.Tab
        Dim new_line = System.Environment.NewLine

        Dim unit_price_extended = Double.Parse(pricing_bag.par_price, Globalization.NumberStyles.Currency)
        report.pass("unit_price_each", (unit_price_extended / equipment_bag.quantity).ToString(price.dollar))
        report.pass("unit_price_extended", unit_price_extended.ToString(price.dollar))

        'dim start_up_note = if(pricing_bag.start_up = "$0", _
        '                       "", new_line & tab & "Startup Supervision" & tab & tab & pricing_bag.start_up & new_line & tab & "(1 tech / 1 trip / 5 days on site)" & new_line)
        Dim work_count = 3
        Dim start_up_note = ""
        If pricing_bag.start_up <> "$0" Then
            work_count += 1
            start_up_note = new_line & work_count & ". Supervision of Startup procedures by factory personnel"
        End If
        report.pass("startup", pricing_bag.start_up)
        report.pass("freight", pricing_bag.freight)
        report.pass("startup_note", start_up_note)

        report.pass("compressor_warranty_price_each", (pricing_bag.warranty / equipment_bag.quantity).ToString(price.dollar))
        report.pass("compressor_warranty_price_extended", pricing_bag.warranty)
        Dim compressor_note = ""
        If pricing_bag.warranty > 0 Then
            work_count += 1
            compressor_note = new_line & work_count & ". Extended compressor warranty for a total of (5) years, parts only, labor, crane and refrigerant costs are not included."
        End If
        report.pass("compressor_note", compressor_note)

        Dim other_price = If(pricing_bag.other = "$0", "", pricing_bag.other & new_line)
        report.pass("other_price", other_price)
        Dim other_description = If(other_price = "", "", new_line & tab & pricing_bag.other_description)
        report.pass("other_price_description", other_description)
        report.pass("total_sale_price", pricing_bag.nfsp)
    End Sub



    Private Sub setPricingParametersIn(ByVal pricing_bag As pricing_grabber.bag, ByVal equipment_bag As equipment_grabber.bag, ByRef text As Dictionary(Of String, String))
        Dim tab = Microsoft.VisualBasic.ControlChars.Tab
        Dim new_line = System.Environment.NewLine

        Dim unit_price_extended = Double.Parse(pricing_bag.par_price, Globalization.NumberStyles.Currency)
        text.Add("unitpriceeach", (unit_price_extended / equipment_bag.quantity).ToString(price.dollar))
        text.Add("unitpriceextended", unit_price_extended.ToString(price.dollar))

        'dim start_up_note = if(pricing_bag.start_up = "$0", _
        '                       "", new_line & tab & "Startup Supervision" & tab & tab & pricing_bag.start_up & new_line & tab & "(1 tech / 1 trip / 5 days on site)" & new_line)




        Dim work_count = 3
        Dim startupAndCompNOTE = ""
        If pricing_bag.start_up <> "$0" Then
            work_count += 1
            startupAndCompNOTE = work_count & ".   Supervision of Startup procedures by factory personnel" & new_line
        Else

        End If

        text.Add("startup", pricing_bag.start_up)


        '        text.Add("freight", pricing_bag.freight)


        If Not String.IsNullOrEmpty(pricing_bag.freight) AndAlso IsNumeric(pricing_bag.freight) Then
            If pricing_bag.freight = 0 Then
                text.Add("freight", "Not Inc.")
            Else
                text.Add("freight", pricing_bag.freight)
            End If
        Else
            text.Add("freight", "Contact Factory")
        End If


        text.Add("startup_note", startupAndCompNOTE)

        'text.Add("compressorwarrantypriceeach", (pricing_bag.warranty / equipment_bag.quantity).ToString(price.dollar))
        'text.Add("compressorwarrantypriceextended", pricing_bag.warranty)


        If Not String.IsNullOrEmpty(pricing_bag.warranty) AndAlso IsNumeric(pricing_bag.warranty) Then

            If pricing_bag.warranty = 0 Then
                text.Add("compressorwarrantypriceeach", "Not Inc.")
                text.Add("compressorwarrantypriceextended", "Not Inc.")
            Else
                text.Add("compressorwarrantypriceeach", (pricing_bag.warranty / equipment_bag.quantity).ToString(price.dollar))
                text.Add("compressorwarrantypriceextended", pricing_bag.warranty)
            End If

        Else
            text.Add("compressorwarrantypriceeach", "Contact Factory")
            text.Add("compressorwarrantypriceextended", "Contact Factory")

        End If







        ' Dim compressor_note = ""
        If pricing_bag.warranty > 0 Then
            work_count += 1
            startupAndCompNOTE &= work_count & ".   Extended compressor warranty for a total of (5) years" & new_line & StrDup(6, Chr(160)) & "     (parts only -- labor, crane and refrigerant costs are not included.)"
        End If
        '        text.Add("compressornote", compressor_note)

        text.Add("ExtCompNote", startupAndCompNOTE)
        '
        Dim other_price = If(pricing_bag.other = "$0", "", pricing_bag.other & new_line)
        text.Add("otherprice", other_price)
        Dim other_description = If(other_price = "", "", new_line & tab & pricing_bag.other_description)
        text.Add("otherpricedescription", other_description)
        text.Add("totalsaleprice", pricing_bag.nfsp)
    End Sub




    Private Sub set_spec_parameters_in(ByVal report As i_report, ByVal bag As chiller_proposal_grabber.bag)
        Dim specs_control = CType(screen.specsControl, chiller_specs_control)
        Dim tag_length = If(bag.tag.Length > 25, 25, bag.tag.Length)
        report.pass("tag", bag.tag.Substring(0, tag_length))
        report.pass("ambient", bag.ambient)
        report.pass("solution", bag.solution)
        report.pass("entering_fluid_temperature", bag.entering_fluid_temperature)
        report.pass("leaving_fluid_temperature", bag.leaving_fluid_temperature)
        report.pass("refrigerant", bag.refrigerant)
        report.pass("capacity", bag.capacity)
        report.pass("gpm", bag.gpm)
        report.pass("evaporator_pressure_drop", bag.evaporator_pressure_drop)
        report.pass("dimensions", bag.dimensions)
        report.pass("shipping_weight", bag.shipping_weight)
        report.pass("operating_weight", bag.operating_weight)
        report.pass("voltage", bag.voltage)
        Dim rla = If(String.IsNullOrEmpty(bag.rla_2), bag.rla, bag.rla & "; " & bag.rla_2)
        report.pass("rla", rla)
        Dim mca = If(String.IsNullOrEmpty(bag.mca_2), bag.mca, bag.mca & "; " & bag.mca_2)
        report.pass("mca", mca)
        report.pass("power_supply_quantity", bag.power_supply_quantity)


        report.pass("control_voltage", bag.control_voltage & "/60/1")


        report.pass("unit_efficiency", System.Math.Round(ConvertNull.ToDouble(bag.unit_efficiency), 2))
    End Sub


    Private Sub setSpecParametersIn(ByVal bag As chiller_proposal_grabber.bag, ByRef text As Dictionary(Of String, String))
        Dim specs_control = CType(screen.specsControl, chiller_specs_control)
        Dim tag_length = If(bag.tag.Length > 25, 25, bag.tag.Length)
        text.Add("tag", bag.tag.Substring(0, tag_length))
        text.Add("CustomerTag", bag.tag.Substring(0, tag_length))
        text.Add("ambient", bag.ambient)
        text.Add("solution", bag.solution)
        text.Add("enteringfluidtemperature", bag.entering_fluid_temperature)
        text.Add("LeavingFluidTemparature", bag.leaving_fluid_temperature)
        text.Add("refrigerant", bag.refrigerant)
        text.Add("capacity", bag.capacity)
        text.Add("gpm", bag.gpm)
        text.Add("evaporatorpressuredrop", bag.evaporator_pressure_drop)
        text.Add("dimensions", bag.dimensions)
        text.Add("shippingweight", bag.shipping_weight)
        text.Add("operatingweight", bag.operating_weight)
        text.Add("voltage", bag.voltage)
        Dim rla = If(String.IsNullOrEmpty(bag.rla_2), bag.rla, bag.rla & "; " & bag.rla_2)
        text.Add("rla", rla)
        Dim mca = If(String.IsNullOrEmpty(bag.mca_2), bag.mca, bag.mca & "; " & bag.mca_2)
        text.Add("mca", mca)

        ' text.Add("SCCR", bag.s
        text.Add("powersupplyquantity", bag.power_supply_quantity)
        text.Add("controlvoltage", bag.control_voltage & "/60/1")
        text.Add("unitefficiency", System.Math.Round(ConvertNull.ToDouble(bag.unit_efficiency), 2))
    End Sub

End Class