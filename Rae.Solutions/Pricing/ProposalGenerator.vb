Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.DataAccess
Imports System.Data
Imports Rae.RaeSolutions.Business
Imports Rae.RaeSolutions.DataAccess.OptionsDS
Imports DaEo = Rae.DataAccess.EquipmentOptions
Imports System.Data.OleDb


Public Class ProposalGenerator

    Private Sub ProposalGenerator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ContactManagerControl1.ContactLimit = 1
        ContactManagerControl1.SetupProposal()

        cboBasePrice.SelectedIndex = 0
        cboLeadTime.SelectedIndex = 0

        loadUserInfo()

        LoadEquipment()
    End Sub


    Private Class EquipDDItem
        Public Property EquipItem As EquipmentItem

        Public Overrides Function ToString() As String
            Return EquipItem.ToString & "(" & EquipItem.name & ")"
        End Function



    End Class

    Private Sub LoadEquipment()
        For Each e As EquipmentItem In OpenedProject.Manager.Equipment
            Dim ei As New EquipDDItem
            ei.EquipItem = e
            cblEquipment.Items.Add(ei, True)
        Next

        'Dim elv As New EquipmentListView

        'For Each e As  In elv.grdEquipment


        'Next
    End Sub

    Private Sub loadUserInfo()
        Dim user As String = AppInfo.User.username

        Dim sql = "select Company, MyName, MyPhone, MyEmail, MyTitle from ProposalInfo where Username = '" & user & "'"
        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Dim company As String = ""
        Dim name As String = ""
        Dim phone As String = ""
        Dim email As String = ""
        Dim title As String = ""

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                company = rdr("Company").ToString()
                name = rdr("MyName").ToString()
                phone = rdr("MyPhone").ToString()
                email = rdr("MyEmail").ToString()
                title = rdr("MyTitle").ToString()
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try

        txtMyCompanyName.Text = company
        txtMyName.Text = name
        txtMyPhone.Text = phone
        txtMyEmail.Text = email
        txtMyTitle.Text = title
    End Sub

    Private Sub generateProposal()

        Dim path1 As String = reports.file_paths.CenturyProposalFrontDocsPath


        Dim path2 As String = reports.file_paths.CenturyProposalEndDocsPath


        Dim text = New Dictionary(Of String, String)
        text.Add("ProposalDate", Now.ToShortDateString)
        text.Add("FromCompany", txtMyCompanyName.Text)
        text.Add("FromName", txtMyName.Text)
        text.Add("FromEmail", txtMyEmail.Text)
        text.Add("FromPhone", txtMyPhone.Text)
        text.Add("SignedBy", txtMyName.Text)
        text.Add("SignedTitle", txtMyTitle.Text)
        text.Add("QuoteNum", txtQuoteNumber.Text)
        text.Add("Revision", txtRevisionNumber.Text)

        text.Add("LeadTime", cboLeadTime.SelectedItem.ToString)
        text.Add("CompanyName", txtMyCompanyName.Text)


        If ContactManagerControl1.Contacts.Count > 0 Then
            '            Dim x As String = ContactManagerControl1.Contacts.Item(0).Company.Name
            text.Add("ToName", ContactManagerControl1.Contacts.Item(0).Company.Name)
            text.Add("ToEmail", ContactManagerControl1.Contacts.Item(0).Email.Address)
            text.Add("ToPhone", ContactManagerControl1.Contacts.Item(0).Company.PhoneNum.ToString)

        Else
            text.Add("ToCompany", "Insert Company Name")
            text.Add("ToEmail", "Insert Email")
            text.Add("ToPhone", "Insert Phone")

        End If

        If cboBasePrice.SelectedItem.ToString.Contains("Net") Then
            text.Add("warrantyNote", "* Extended Compressor Warranty is not included in net price each." & vbCrLf & "** Extended Compressor Warranty is ONLY included in the extended net price if a price is indicated in the Extended Compressor Warranty column.")
        Else
            text.Add("warrantyNote", "* Extended Compressor Warranty is NOT included in list price.")
        End If

        '        Dim table = create_table(Me.resultsDataGrid.DataSource)


        Dim report = New Rae.reporting.beta.report(path1)

        Dim frontDocs As String = report.report_file_path

        For i As Integer = 0 To cblEquipment.Items.Count - 1
            If cblEquipment.GetItemChecked(i) Then
                Dim container As EquipDDItem = CType(cblEquipment.Items(i), EquipDDItem)
                Dim ei As EquipmentItem = container.EquipItem


                Select Case ei.type
                    Case Business.EquipmentType.Condenser
                        AddPricingSheet(CType(ei, CondenserEquipmentItem), report)
                    Case Business.EquipmentType.CondensingUnit
                        AddPricingSheet(CType(ei, CondensingUnitEquipmentItem), report)
                    Case Business.EquipmentType.ProductCooler
                        AddPricingSheet(CType(ei, ProductCoolerEquipmentItem), report)
                    Case Business.EquipmentType.UnitCooler
                        AddPricingSheet(CType(ei, unit_cooler), report)
                End Select


            End If
        Next


        'report.append_page_break()
        'report.append_document(pathCU)
        'report.append_page_break()
        'report.append_document(pathUC)
        'report.append_page_break()
        'report.append_document(pathPC)

        report.append_page_break()
        report.append_document(path2)


        ' report.set_list("information", list_of_info.toList)
        report.set_text(text)


        Dim priceTitle1 As String
        Dim priceTitle2 As String




        Select Case cboBasePrice.SelectedItem.ToString
            Case "List Price"
                priceTitle1 = "List Price Each"
                priceTitle2 = "Extended List Price"
            Case "Net Price"
                priceTitle1 = "Net Price Each"
                priceTitle2 = "Extended Net Price"
        End Select


        Dim table1 As New DataTable
        table1.Columns.Add("Qty")
        table1.Columns.Add("Customer Tag")
        table1.Columns.Add("Model Number")
        table1.Columns.Add("Freight")
        table1.Columns.Add("Startup")
        table1.Columns.Add("Other")
        table1.Columns.Add("Ext Comp Warranty")
        table1.Columns.Add(priceTitle1)
        table1.Columns.Add(priceTitle2)


        Dim totalList As Decimal = 0
        Dim totalExtededList As Decimal = 0
        Dim totalFreight As Decimal = 0
        Dim totalStartup As Decimal = 0
        Dim totalOther As Decimal = 0
        Dim totalWarranty As Decimal = 0

        Dim totalCFFlag As Boolean = False


        For i As Integer = 0 To cblEquipment.Items.Count - 1

            If cblEquipment.GetItemChecked(i) Then

                Dim cfFlag As Boolean = False

                Dim container As EquipDDItem = CType(cblEquipment.Items(i), EquipDDItem)
                Dim e As EquipmentItem = container.EquipItem


                Dim multiplier As Single = 1
                If cboBasePrice.SelectedItem.ToString = "Net Price" Then
                    multiplier = e.pricing.par_multiplier
                End If

                Dim r As DataRow = table1.NewRow
                r("Qty") = e.pricing.quantity
                r("Customer Tag") = e.tag

                If container.EquipItem.type = EquipmentType.UnitCooler Then
                    Dim ei As unit_cooler = container.EquipItem
                    Dim model As String
                    Dim modelWithRefrigerant = New Rae.solutions.unit_coolers.database_formatter().format_model(ei.model, ei.refrigerant)

                    If ei.model.EndsWith("E") Then
                        modelWithRefrigerant = modelWithRefrigerant & "E"
                    End If
                    If ei.model.EndsWith("HG") Then
                        modelWithRefrigerant = modelWithRefrigerant & "HG"
                    End If
                    If ei.model.EndsWith("A") Then
                        modelWithRefrigerant = modelWithRefrigerant & "A"
                    End If

                    r("Model Number") = modelWithRefrigerant
                Else
                    r("Model Number") = e.model
                End If



                Dim standardOptionCost As Double = 0
                Dim specialOptionCost As Double = 0
                Dim warrantyCost As Double = 0




                For Each op1 In e.options

                    Dim opWP = DaEo.OptionsDataAccess.RetrieveOption(op1.PricingId)

                    If opWP.ContactFactory Then
                        cfFlag = True
                    ElseIf opWP.IsDependentCommonOption Then
                        MsgBox("A dependent common option is included in this project.  Pricing may not be correct")

                    ElseIf opWP.IsStandard Then
                    Else
                        standardOptionCost += (op1.Price * op1.Quantity)
                    End If


                Next


                For Each op1 In e.special_options
                    If op1.Price.has_value AndAlso op1.Quantity.has_value Then
                        standardOptionCost += (op1.Price.value * op1.Quantity.value)
                    Else
                        standardOptionCost += 0
                        cfFlag = True
                    End If

                Next


                warrantyCost = e.pricing.warranty                


                Dim freight As Double = e.pricing.freight
                Dim startup As Double = e.pricing.start_up
                Dim other As Double = e.pricing.other_price

                Dim totExtra As Double = freight + startup + other + warrantyCost


                r("Freight") = FormatCurrency(freight, 0)
                r("Startup") = FormatCurrency(startup, 0)
                r("Other") = FormatCurrency(other, 0)
                r("Ext Comp Warranty") = FormatCurrency(warrantyCost / e.pricing.quantity, 0) & " ea."

                totalFreight += freight
                totalStartup += startup
                totalOther += other
                totalWarranty += warrantyCost

                Dim totalOptionCost As Double = standardOptionCost + specialOptionCost

                If cfFlag = True Then
                    r(priceTitle1) = "Cont Fact"
                    r(priceTitle2) = "Cont Fact"
                    totalCFFlag = True

                ElseIf e.pricing.overridden_base_list_price Then
                    ' DL - Commented this out to try to get the correct Net Price Each
                    'r(priceTitle1) = FormatCurrency((e.pricing.overridden_base_list_price + totalOptionCost * multiplier), 0)
                    'r(priceTitle1) = FormatCurrency(((e.pricing.overridden_base_list_price + totalOptionCost) * multiplier), 0) & " *"
                    'r(priceTitle2) = FormatCurrency(((e.pricing.overridden_base_list_price + totalOptionCost) * e.pricing.quantity * multiplier), 0) & " *"
                    'totalList += ((e.pricing.overridden_base_list_price + totalOptionCost) * multiplier)
                    'totalExtededList += ((e.pricing.overridden_base_list_price + totalOptionCost) * e.pricing.quantity * multiplier)

                    If priceTitle1.Contains("Net") Or priceTitle2.Contains("Net") Then
                        r(priceTitle1) = FormatCurrency(((e.pricing.overridden_base_list_price + totalOptionCost) * multiplier), 0) & " *"
                        r(priceTitle2) = FormatCurrency(((e.pricing.overridden_base_list_price + totalOptionCost) * e.pricing.quantity * multiplier) + warrantyCost, 0) & " **"
                        totalList += ((e.pricing.overridden_base_list_price + totalOptionCost) * multiplier) + warrantyCost
                        totalExtededList += ((e.pricing.overridden_base_list_price + totalOptionCost) * e.pricing.quantity * multiplier) + warrantyCost
                    Else
                        r(priceTitle1) = FormatCurrency(((e.pricing.overridden_base_list_price + totalOptionCost) * multiplier), 0) & " *"
                        r(priceTitle2) = FormatCurrency(((e.pricing.overridden_base_list_price + totalOptionCost) * e.pricing.quantity * multiplier), 0) & " *"
                        totalList += ((e.pricing.overridden_base_list_price + totalOptionCost) * multiplier)
                        totalExtededList += ((e.pricing.overridden_base_list_price + totalOptionCost) * e.pricing.quantity * multiplier)
                    End If
                Else

                    Dim price = EquipmentOptionsAgent.OptionsDA.RetrieveBaseListPrice(e.model.Replace(e.model_without_series, ""), e.model_without_series)

                    If priceTitle1.Contains("Net") Or priceTitle2.Contains("Net") Then
                        r(priceTitle1) = FormatCurrency(((price + totalOptionCost) * multiplier), 0) & " *"
                        'r(priceTitle1) = FormatCurrency((price + totalOptionCost * multiplier), 0)
                        r(priceTitle2) = FormatCurrency(((price + totalOptionCost) * e.pricing.quantity * multiplier) + warrantyCost, 0) & " **"
                        totalList += ((price + totalOptionCost) * multiplier) + warrantyCost
                        totalExtededList += ((price + totalOptionCost) * e.pricing.quantity * multiplier) + warrantyCost
                    Else
                        r(priceTitle1) = FormatCurrency(((price + totalOptionCost) * multiplier), 0) & " *"
                        'r(priceTitle1) = FormatCurrency((price + totalOptionCost * multiplier), 0)
                        r(priceTitle2) = FormatCurrency(((price + totalOptionCost) * e.pricing.quantity * multiplier), 0) & " *"
                        totalList += ((price + totalOptionCost) * multiplier)
                        totalExtededList += ((price + totalOptionCost) * e.pricing.quantity * multiplier)
                    End If

                End If

                table1.Rows.Add(r)
            End If
        Next

        Dim sR As DataRow = table1.NewRow

        sR("Qty") = ""
        sR("Customer Tag") = ""
        sR("Model Number") = "Totals:"
        sR("Freight") = FormatCurrency(totalFreight, 0)
        sR("Startup") = FormatCurrency(totalStartup, 0)
        sR("Other") = FormatCurrency(totalOther, 0)
        sR("Ext Comp Warranty") = FormatCurrency(totalWarranty, 0)
        sR(priceTitle1) = ""

        If totalCFFlag Then
            sR(priceTitle2) = "Cont Fact"
        Else
            If priceTitle1.Contains("Net") Or priceTitle2.Contains("Net") Then
                sR(priceTitle2) = FormatCurrency(totalExtededList, 0) & " **"
            Else
                sR(priceTitle2) = FormatCurrency(totalExtededList, 0) & " *"
            End If
        End If

        table1.Rows.Add(sR)

        report.set_table("Table1", table1, New Rae.reporting.beta.proposal_table_factory)

        report.mark_as_final()

        report.report_file_path = frontDocs

        report.show()
    End Sub




    Private Function AddPricingSheet(ByVal cEquip As CondenserEquipmentItem, ByVal report As reporting.beta.report)
        Dim pathC As String = reports.file_paths.CenturyProposalCondenserSheetPath

        Dim tempReport = New Rae.reporting.beta.report(pathC)
        Dim d1 = New Dictionary(Of String, String)

        SetProjectAndReleaseStatus(d1, cEquip)


        d1.Add("refrigerant", cEquip.Specs.Refrigerant)
        If cEquip.Specs.AmbientTemp.has_value Then d1.Add("ambient", cEquip.Specs.AmbientTemp.ToString & "°F") Else d1.Add("ambient", "Not Specified")
        If cEquip.Specs.TempDifference.has_value Then d1.Add("td", cEquip.Specs.TempDifference.ToString & "°F") Else d1.Add("td", "Not Specified")
        If Not IsNothing(cEquip.common_specs.UnitVoltage) AndAlso Not String.IsNullOrEmpty(cEquip.common_specs.UnitVoltage.ToString) Then d1.Add("unit_voltage", cEquip.common_specs.UnitVoltage.ToString) Else d1.Add("unit_voltage", "Not Specified")
        If Not IsNothing(cEquip.common_specs.ControlVoltage) AndAlso Not String.IsNullOrEmpty(cEquip.common_specs.ControlVoltage.ToString) Then d1.Add("control_voltage", cEquip.common_specs.ControlVoltage.ToString) Else d1.Add("control_voltage", "Not Specified")
        If Not IsNothing(cEquip.tag) AndAlso Not String.IsNullOrEmpty(cEquip.tag) Then d1.Add("tag", cEquip.tag) Else d1.Add("tag", " ")

        If cEquip.Specs.TotalHeatRejection1.has_value Then
            d1.Add("total_heat_rejection_1", cEquip.Specs.TotalHeatRejection1.ToString.format_number("#,#").BTUH)
            d1.Add("total_heat_rejection_1_label", "Circuit 1 THR")
        Else
            d1.Add("total_heat_rejection_1", " ")
            d1.Add("total_heat_rejection_1_label", " ")
        End If

        If cEquip.Specs.TotalHeatRejection2.has_value Then
            d1.Add("total_heat_rejection_2", cEquip.Specs.TotalHeatRejection2.ToString.format_number("#,#").BTUH)
            d1.Add("total_heat_rejection_2_label", "Circuit 2 THR")
        Else
            d1.Add("total_heat_rejection_2", " ")
            d1.Add("total_heat_rejection_2_label", " ")
        End If

        If cEquip.Specs.TotalHeatRejection3.has_value Then
            d1.Add("total_heat_rejection_3", cEquip.Specs.TotalHeatRejection3.ToString.format_number("#,#").BTUH)
            d1.Add("total_heat_rejection_3_label", "Circuit 3 THR")
        Else
            d1.Add("total_heat_rejection_3", " ")
            d1.Add("total_heat_rejection_3_label", " ")
        End If

        If cEquip.Specs.TotalHeatRejection4.has_value Then
            d1.Add("total_heat_rejection_4", cEquip.Specs.TotalHeatRejection4.ToString.format_number("#,#").BTUH)
            d1.Add("total_heat_rejection_4_label", "Circuit 4 THR")
        Else
            d1.Add("total_heat_rejection_4", " ")
            d1.Add("total_heat_rejection_4_label", " ")
        End If



        tempReport.set_text(d1)

        Dim options = GetOptions(cEquip, False)
        tempReport.set_list("options", options)



        report.append_page_break()
        report.append_document(tempReport.generate)
    End Function

    Private Function AddPricingSheet(ByVal cEquip As CondensingUnitEquipmentItem, ByVal report As reporting.beta.report)
        Dim pathCU As String = reports.file_paths.CenturyProposalCondensingUnitSheetPath

        Dim tempReport = New Rae.reporting.beta.report(pathCU)
        Dim d1 = New Dictionary(Of String, String)

        SetProjectAndReleaseStatus(d1, cEquip)

        'If Not IsNothing(cEquip.capacity) AndAlso Not String.IsNullOrEmpty(cEquip.capacity.ToString) Then d1.Add("capacity", cEquip.capacity.ToString.format_number("#,#")) Else d1.Add("capacity", "Not Specified")
        'If Not IsNothing(cEquip.refrigerant) AndAlso Not String.IsNullOrEmpty(cEquip.refrigerant) Then d1.Add("refrigerant", cEquip.refrigerant.ToString) Else d1.Add("refrigerant", "Not Specified")


        d1.Add("refrigerant", cEquip.specs.refrigerant)
        If cEquip.specs.ambient.has_value Then d1.Add("ambient", cEquip.specs.ambient.ToString & "°F") Else d1.Add("ambient", "Not Specified")
        If cEquip.specs.suction.has_value Then d1.Add("suction", cEquip.specs.suction.ToString & "°F") Else d1.Add("suction", "Not Specified")
        If cEquip.specs.evaporating_temperature.has_value Then d1.Add("evaporating_temperature", cEquip.specs.evaporating_temperature.ToString & "°F") Else d1.Add("evaporating_temperature", "Not Specified")
        'If cEquip.common_specs..capacity_units.has_value Then d1.Add("capacity_units", cEquip.specs.capacity_units.ToString) Else d1.Add("capacity_units", "Not Specified")
        d1.Add("capacity_units", "BTUH")

        If cEquip.common_specs.OperatingWeight.has_value Then d1.Add("operating_weight", cEquip.common_specs.OperatingWeight.ToString & " lbs") Else d1.Add("operating_weight", "Not Specified")
        If cEquip.common_specs.ShippingWeight.has_value Then d1.Add("shipping_weight", cEquip.common_specs.ShippingWeight.ToString & " lbs") Else d1.Add("shipping_weight", "Not Specified")
        If Not IsNothing(cEquip.common_specs.UnitVoltage) AndAlso Not String.IsNullOrEmpty(cEquip.common_specs.UnitVoltage.ToString) Then d1.Add("unit_voltage", cEquip.common_specs.UnitVoltage.ToString) Else d1.Add("unit_voltage", "Not Specified")
        If Not IsNothing(cEquip.common_specs.ControlVoltage) AndAlso Not String.IsNullOrEmpty(cEquip.common_specs.ControlVoltage.ToString) Then d1.Add("control_voltage", cEquip.common_specs.ControlVoltage.ToString) Else d1.Add("control_voltage", "Not Specified")
        If cEquip.common_specs.Rla.has_value Then d1.Add("rla", cEquip.common_specs.Rla.ToString) Else d1.Add("rla", "Not Specified")
        If cEquip.common_specs.Mca.has_value Then d1.Add("mca", cEquip.common_specs.Mca.ToString) Else d1.Add("mca", "Not Specified")
        If Not IsNothing(cEquip.pricing.quantity) AndAlso Not String.IsNullOrEmpty(cEquip.pricing.quantity.ToString) Then d1.Add("quantity", cEquip.pricing.quantity.ToString) Else d1.Add("quantity", "Not Specified")
        If Not IsNothing(cEquip.tag) AndAlso Not String.IsNullOrEmpty(cEquip.tag) Then d1.Add("tag", cEquip.tag) Else d1.Add("tag", " ")


        Dim dimensions As String
        If cEquip.common_specs.Length.has_value AndAlso cEquip.common_specs.Width.has_value AndAlso cEquip.common_specs.Height.has_value Then
            dimensions = cEquip.common_specs.Length.ToString & "x" & cEquip.common_specs.Width.ToString & "x" & cEquip.common_specs.Height.ToString
            d1.Add("dimensions", dimensions)
        Else
            d1.Add("dimensions", "Not Specified")
        End If


        Dim capacity1 As String
        If cEquip.specs.capacity_1.has_value Then
            capacity1 = FormatNumber(cEquip.specs.capacity_1.ToString, 0, , , TriState.True)
        Else
            capacity1 = ""
        End If

        Dim capacity2 As String
        If cEquip.specs.capacity_2.has_value Then
            capacity2 = FormatNumber(cEquip.specs.capacity_2.ToString, 0, , , TriState.True)
        Else
            capacity2 = ""
        End If


        d1.Add("capacity_1", capacity1)
        d1.Add("capacity_2", capacity2)


        Dim model As String = cEquip.model.ToString()

        Dim sql = "select top 1 Flood_op_charge, Std_op_charge from Table5 where Model = '" & model & "' AND Company = 'CRI'"
        Dim connection = Common.CreateConnection(Common.CondensingUnitDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Dim stdCharge As String = ""
        Dim floodCharge As String = ""

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                stdCharge = rdr("Std_op_charge").ToString()
                floodCharge = rdr("Flood_op_charge").ToString()
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try

        Dim temp As Decimal
        If Decimal.TryParse(floodCharge, temp) Then
            floodCharge = System.Math.Round(temp, 1).ToString()
        End If

        Dim temp1 As Decimal
        If Decimal.TryParse(stdCharge, temp1) Then
            stdCharge = System.Math.Round(temp1, 1).ToString()
        End If

        If stdCharge <> "" Or floodCharge <> "" Then
            d1.Add("stdCharge", stdCharge & " lbs *")
            d1.Add("floodCharge", floodCharge & " lbs *")
        Else
            d1.Add("stdCharge", "Not Avail.")
            d1.Add("floodCharge", "Not Avail.")
        End If

        If model.Contains("LUI") Or model.Contains("LUO") Then
            d1.Add("footNote", "* Based on 50 ft. of equivalent refrigerant line piping (does not include the evaporator).")
        Else
            d1.Add("footNote", "* Based on 100 ft. of equivalent refrigerant line piping (does not include the evaporator).")
        End If

        tempReport.set_text(d1)

        Dim options = GetOptions(cEquip, cEquip.pricing.warranty > 0)




        tempReport.set_list("options", options)



        report.append_page_break()
        report.append_document(tempReport.generate)
    End Function

    Private Function AddPricingSheet(ByVal cEquip As ProductCoolerEquipmentItem, ByVal report As reporting.beta.report)
        Dim pathPC As String = reports.file_paths.CenturyProposalProductCoolerSheetPath

        Dim tempReport = New Rae.reporting.beta.report(pathPC)
        Dim d1 = New Dictionary(Of String, String)

        SetProjectAndReleaseStatus(d1, cEquip)

        'If Not IsNothing(cEquip.capacity) AndAlso Not String.IsNullOrEmpty(cEquip.capacity.ToString) Then d1.Add("capacity", cEquip.capacity.ToString.format_number("#,#")) Else d1.Add("capacity", "Not Specified")
        'If Not IsNothing(cEquip.refrigerant) AndAlso Not String.IsNullOrEmpty(cEquip.refrigerant) Then d1.Add("refrigerant", cEquip.refrigerant.ToString) Else d1.Add("refrigerant", "Not Specified")

        If Not IsNothing(cEquip.Specs.Refrigerant) AndAlso Not String.IsNullOrEmpty(cEquip.Specs.Refrigerant) Then d1.Add("refrigerant", cEquip.Specs.Refrigerant.ToString) Else d1.Add("refrigerant", "Not Specified")
        If Not IsNothing(cEquip.Specs.EvaporatorTemp) AndAlso Not String.IsNullOrEmpty(cEquip.Specs.EvaporatorTemp.ToString) Then d1.Add("evaporating_temperature", cEquip.Specs.EvaporatorTemp.ToString & "°F") Else d1.Add("evaporating_temperature", "Not Specified")
        If Not IsNothing(cEquip.Specs.BoxTemp) AndAlso Not String.IsNullOrEmpty(cEquip.Specs.BoxTemp.ToString) Then d1.Add("box_temperature", cEquip.Specs.BoxTemp.ToString & "°F") Else d1.Add("box_temperature", "Not Specified")
        If Not IsNothing(cEquip.Specs.TempDifference) AndAlso Not String.IsNullOrEmpty(cEquip.Specs.TempDifference.ToString) Then d1.Add("td", cEquip.Specs.TempDifference.ToString & "°F") Else d1.Add("td", "Not Specified")
        If Not IsNothing(cEquip.common_specs.ControlVoltage) AndAlso Not String.IsNullOrEmpty(cEquip.common_specs.ControlVoltage.ToString) Then d1.Add("control_voltage", cEquip.common_specs.ControlVoltage.ToString) Else d1.Add("control_voltage", "Not Specified")
        If Not IsNothing(cEquip.tag) AndAlso Not String.IsNullOrEmpty(cEquip.tag) Then d1.Add("tag", cEquip.tag) Else d1.Add("tag", " ")




        tempReport.set_text(d1)

        Dim options = GetOptions(cEquip, False)
        tempReport.set_list("options", options)



        report.append_page_break()
        report.append_document(tempReport.generate)
    End Function



    Private Function AddPricingSheet(ByVal cEquip As unit_cooler, ByVal report As reporting.beta.report)
        Dim pathUC As String = reports.file_paths.CenturyProposalUnitCoolerSheetPath

        Dim tempReport = New Rae.reporting.beta.report(pathUC)
        Dim d1 = New Dictionary(Of String, String)

        SetProjectAndReleaseStatus(d1, cEquip)

        Dim model As String
        Dim modelWithRefrigerant = New Rae.solutions.unit_coolers.database_formatter().format_model(cEquip.model, cEquip.refrigerant)
        Dim modelTemp As String = cEquip.model.ToString()

        If cEquip.custom_model.is_not_set Then
            model = modelWithRefrigerant
        Else
            model = cEquip.custom_model & " (Base:" & modelWithRefrigerant & ")"
        End If

        If modelTemp.EndsWith("A") Then
            model = model & "A"
        End If

        If modelTemp.EndsWith("HG") Then
            model = model & "HG"
        End If

        If modelTemp.EndsWith("E") Then
            model = model & "E"
        End If

        d1.Remove("model")

        d1.Add("model", model)


        If model.EndsWith("A") Then
            model = model.Trim().Substring(0, model.Length - 1)
        End If

        If model.EndsWith("HG") Then
            model = model.Trim().Substring(0, model.Length - 2)
        End If

        If model.EndsWith("E") Then
            model = model.Trim().Substring(0, model.Length - 1)
        End If

        Dim sql = "select top 1 REFR_CHARGE from unit_coolers where Model = '" & model & "'"
        Dim connection = Common.CreateConnection(Common.UnitCoolerDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Dim stdCharge As String = ""

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                stdCharge = rdr("REFR_CHARGE").ToString()
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try

        If stdCharge <> "" Then
            d1.Add("stdCharge", stdCharge & " lbs")
        Else
            d1.Add("stdCharge", "Not Avail.")
        End If


        If Not IsNothing(cEquip.capacity) AndAlso Not String.IsNullOrEmpty(cEquip.capacity.ToString) Then d1.Add("capacity", cEquip.capacity.ToString.format_number("#,#")) Else d1.Add("capacity", "Not Specified")
        If Not IsNothing(cEquip.refrigerant) AndAlso Not String.IsNullOrEmpty(cEquip.refrigerant) Then d1.Add("refrigerant", cEquip.refrigerant.ToString) Else d1.Add("refrigerant", "Not Specified")
        If Not IsNothing(cEquip.box_temperature) AndAlso Not String.IsNullOrEmpty(cEquip.box_temperature.ToString) Then d1.Add("box_temperature", cEquip.box_temperature.ToString & "°F") Else d1.Add("box_temperature", "Not Specified")
        If Not IsNothing(cEquip.evaporator_temperature) AndAlso Not String.IsNullOrEmpty(cEquip.evaporator_temperature.ToString) Then d1.Add("evaporating_temperature", cEquip.evaporator_temperature.ToString & "°F") Else d1.Add("evaporating_temperature", "Not Specified")
        If Not IsNothing(cEquip.temperature_difference) AndAlso Not String.IsNullOrEmpty(cEquip.temperature_difference.ToString) Then d1.Add("td", cEquip.temperature_difference.ToString & "°F") Else d1.Add("td", "Not Specified")
        If Not IsNothing(cEquip.liquid_temperature) AndAlso Not String.IsNullOrEmpty(cEquip.liquid_temperature.ToString) Then d1.Add("liquid_temperature", cEquip.liquid_temperature.ToString & "°F") Else d1.Add("liquid_temperature", "Not Specified")
        If Not IsNothing(cEquip.condensing_temperature) AndAlso Not String.IsNullOrEmpty(cEquip.condensing_temperature.ToString) Then d1.Add("condensing_temperature", cEquip.condensing_temperature.ToString & "°F") Else d1.Add("condensing_temperature", "Not Specified")
        If Not IsNothing(cEquip.fan_voltage) AndAlso Not String.IsNullOrEmpty(cEquip.fan_voltage.ToString) Then d1.Add("fan_voltage", cEquip.fan_voltage.ToString) Else d1.Add("fan_voltage", "Not Specified")
        If Not IsNothing(cEquip.defrost_voltage) AndAlso Not String.IsNullOrEmpty(cEquip.defrost_voltage.ToString) Then d1.Add("defrost_voltage", cEquip.defrost_voltage.ToString) Else d1.Add("defrost_voltage", "Not Specified")
        If Not IsNothing(cEquip.common_specs.ControlVoltage) AndAlso Not String.IsNullOrEmpty(cEquip.common_specs.ControlVoltage.ToString) Then d1.Add("control_voltage", cEquip.common_specs.ControlVoltage.ToString) Else d1.Add("control_voltage", "Not Specified")
        If Not IsNothing(cEquip.pricing.quantity) AndAlso Not String.IsNullOrEmpty(cEquip.pricing.quantity.ToString) Then d1.Add("quantity", cEquip.pricing.quantity.ToString) Else d1.Add("quantity", "Not Specified")
        If Not IsNothing(cEquip.tag) AndAlso Not String.IsNullOrEmpty(cEquip.tag) Then d1.Add("tag", cEquip.tag) Else d1.Add("tag", " ")

        tempReport.set_text(d1)

        Dim options = GetOptions(cEquip, False)
        tempReport.set_list("options", options)



        report.append_page_break()
        report.append_document(tempReport.generate)
    End Function


    Private Function GetOptions(ByVal cEquip As EquipmentItem, ByVal hasWarranty As Boolean) As List(Of String)
        GetOptions = New List(Of String)

        For Each op In cEquip.options
            GetOptions.Add("• " & op.Description.Replace("Warranty (Net)", "Warranty"))  ' for Brookei
        Next

        If hasWarranty Then
            GetOptions.Add("• 4 Year Extended Compressor Warranty")
        End If


        For Each op In GetStandardOptions(cEquip)
            GetOptions.Add("• " & op.Description.Replace("Warranty (Net)", "Warranty"))  ' for Brookei
        Next

        For Each op In cEquip.special_options
            GetOptions.Add("• " & op.Description.Replace("Warranty (Net)", "Warranty"))  ' for Brookei
        Next

    End Function


    Private Sub btnGenerateProposal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateProposal.Click
        generateProposal()
    End Sub


    Private Function GetStandardOptions(ByVal EquipItem As EquipmentItem) As EquipmentOptionDataTable

        Dim series = EquipItem.series
        Dim model = EquipItem.model_without_series
        Dim voltage As Integer

        If Not Integer.TryParse(parseVoltage(GrabUnitVoltage(EquipItem)), voltage) Then
            voltage = 0
        End If

        ' retrieves typed table of standard options



        Dim standardOptionsTable = EquipmentOptionsAgent.OptionsDA.RetrieveStandardOptions(series, model, voltage, getNumFans(EquipItem), getFanMotorPhase(EquipItem))

        Return standardOptionsTable
    End Function


    Private Function GrabUnitVoltage(ByVal EquipItem As EquipmentItem) As String
        If EquipItem.common_specs.UnitVoltage Is Nothing OrElse String.IsNullOrEmpty(EquipItem.common_specs.UnitVoltage.ToString) Then
            Return ""
        Else
            Return EquipItem.common_specs.UnitVoltage.ToString

        End If
    End Function

    Private Function parseVoltage(ByVal voltageDescription As String) As String
        Dim voltage As String

        ' parses voltage
        If Not String.IsNullOrEmpty(voltageDescription) AndAlso voltageDescription.Contains("/") Then
            voltage = voltageDescription.Substring(0, voltageDescription.IndexOf("/"))
        Else
            voltage = ""
        End If

        Return voltage
    End Function

    Private Function getNumFans(ByVal EquipItem As EquipmentItem) As Integer
        If TypeOf EquipItem Is unit_cooler Then
            Return CType(EquipItem, unit_cooler).fan_quantity


        ElseIf TypeOf EquipItem Is CondensingUnitEquipmentItem Then

            Return getNumberOfFansForCondUnit(EquipItem.model)

        Else
            Return 0
        End If
    End Function


    Public Function getFanMotorPhase(ByVal EquipItem As EquipmentItem) As Integer

        Select Case EquipItem.type
            Case EquipmentType.UnitCooler
                Dim cu = CType(EquipItem, unit_cooler)
                If Not cu.fan_voltage Is Nothing AndAlso Not String.IsNullOrEmpty(cu.fan_voltage.ToString) Then
                    Dim fVolt As String = cu.fan_voltage.ToString
                    Dim p() As String = fVolt.Split("/")
                    If p.Length > 2 Then
                        Return p(1)
                    Else
                        Return 0
                    End If
                Else
                    Return 0
                End If


            Case EquipmentType.ProductCooler
                Return 0
            Case EquipmentType.Condenser
                Return 0
            Case EquipmentType.CondensingUnit
                Return 0
        End Select



    End Function

    Private Function getNumberOfFansForCondUnit(ByVal model As String) As Integer
        Dim connection = Common.CreateConnection(Common.CondensingUnitDbPath)
        Dim command = connection.CreateCommand()
        Dim sql As String

        Dim FanQTY1 As Integer
        Dim FanQTY2 As Integer

        sql = "select fanqty_1,  fanqty_2  from table5 where model = '" & model & "'"
        command.CommandText = sql
        Dim reader As IDataReader
        Try
            connection.Open()
            reader = command.ExecuteReader()

            If reader.Read Then
                If Not Integer.TryParse(reader("FanQTY_1").ToString, FanQTY1) Then FanQTY1 = 0
                If Not Integer.TryParse(reader("FanQTY_2").ToString, FanQTY2) Then FanQTY2 = 0
                '                FanQTY = reader("FanQTY")
            Else
                FanQTY1 = 0
                FanQTY2 = 0
            End If

        Catch
            FanQTY1 = 0
            FanQTY2 = 0
        Finally
            If reader IsNot Nothing Then _
               reader.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try

        Return FanQTY1 + FanQTY2

    End Function



    Private Sub SetProjectAndReleaseStatus(ByRef d1 As Dictionary(Of String, String), ByVal cEquip As EquipmentItem)

        Dim model As String
        If cEquip.custom_model.is_not_set Then
            model = cEquip.model
        Else
            model = cEquip.custom_model & " (Base:" & cEquip.model & ")"
        End If

        d1.Add("model", model)

        If Not IsNothing(OpenedProject.Manager.Project.ReleaseNum) AndAlso Not String.IsNullOrEmpty(OpenedProject.Manager.Project.ReleaseNum.ToString) Then d1.Add("release_number", OpenedProject.Manager.Project.ReleaseNum.ToString) Else d1.Add("release_number", "Not Specified")


        '        If Not IsNothing(cEquip.Proj) AndAlso Not String.IsNullOrEmpty(cEquip.tag) Then d1.Add("representative", cEquip.tag) Else d1.Add("representative", " ")
        If Not IsNothing(OpenedProject.Manager.Project.name) AndAlso Not String.IsNullOrEmpty(OpenedProject.Manager.Project.name) Then d1.Add("project", OpenedProject.Manager.Project.name) Else d1.Add("project", " ")

        Select Case OpenedProject.Manager.Project.ReleaseStatus
            Case Business.ReleaseStatus.HR
                d1.Add("release_status", "HR #")
            Case Business.ReleaseStatus.PR
                d1.Add("release_status", "PR #")
            Case Business.ReleaseStatus.Project
                d1.Add("release_status", "Project #")
            Case Else
        End Select
    End Sub

    Private Sub btnGenerateProjectSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateProjectSummary.Click

        GenerateProjectSummary()


    End Sub

    Private Sub GenerateProjectSummary()

        Dim pathC As String = reports.file_paths.PROJECT_SUMMARY_PATH


        Dim report = New Rae.reporting.beta.ExcelReportClosed(pathC)

        Dim eList As New List(Of ProposalEquipmentItem)

        Dim dashNumber As Integer = 0

        Dim optionCodes As New Dictionary(Of String, String)

        Dim prNumber As String
        Dim Altitude As String
        Dim projectName As String
        Dim represenative As String = "Unknown"
        Dim todaysDate As String = Now.ToShortDateString



        If Not IsNothing(OpenedProject.Manager.Project.ReleaseNum) AndAlso Not String.IsNullOrEmpty(OpenedProject.Manager.Project.ReleaseNum.ToString) Then
            prNumber = OpenedProject.Manager.Project.ReleaseNum.ToString
        End If

        If Not IsNothing(OpenedProject.Manager.Project.name) AndAlso Not String.IsNullOrEmpty(OpenedProject.Manager.Project.name.ToString) Then
            projectName = OpenedProject.Manager.Project.name
        End If


        Try

            For Each contact1 In OpenedProject.Manager.Project.Contacts
                If contact1.Role = contact1.Roles.Representative Then
                    represenative = contact1.Name.FullName.ToString & ", " & contact1.Company.Name.ToString
                End If
            Next

        Catch ex As Exception

        End Try



        For i As Integer = 0 To cblEquipment.Items.Count - 1
            If cblEquipment.GetItemChecked(i) Then
                dashNumber += 1
                Dim container As EquipDDItem = CType(cblEquipment.Items(i), EquipDDItem)
                Dim ei As EquipmentItem = container.EquipItem

                Dim pItem As New ProposalEquipmentItem



                pItem.DashNumber = dashNumber
                pItem.UnitModelNumber = ei.model
                pItem.UnitQuantity = ei.pricing.quantity
                pItem.UnitTagOrRoom = ei.tag

                Dim dimensions As String
                If ei.common_specs.Length.has_value AndAlso ei.common_specs.Width.has_value AndAlso ei.common_specs.Height.has_value Then
                    dimensions = ei.common_specs.Length.ToString & "x" & ei.common_specs.Width.ToString & "x" & ei.common_specs.Height.ToString
                Else
                    dimensions = "Not Specified"
                End If

                pItem.UnitDimensions = dimensions
                pItem.UnitPrimaryVoltage = ei.common_specs.UnitVoltage.ToString
                pItem.UnitControlVoltage = ei.common_specs.ControlVoltage.ToString


                If String.IsNullOrEmpty(Altitude) Then
                    Altitude = ei.common_specs.Altitude.ToString
                Else
                    If Altitude <> ei.common_specs.Altitude.ToString Then
                        Altitude = "Varies"
                    End If
                End If


                pItem.EstimatedOperatingWeight = ei.common_specs.OperatingWeight.ToString

                Select Case ei.type
                    Case Business.EquipmentType.Condenser
                        Dim pEI As CondenserEquipmentItem = CType(ei, CondenserEquipmentItem)
                        pItem.DesignRefrigType = pEI.Specs.Refrigerant
                        pItem.DefrostType = ""
                        pItem.DesignAmbientTemp = pEI.Specs.AmbientTemp.ToString
                        pItem.DesignRoomTemp = ""
                        pItem.DesignEvapTemp = ""
                        pItem.DesignSuctionTemp = ""
                        pItem.DesignTD = pEI.Specs.TempDifference.ToString
                        pItem.Capacity = ""
                        pItem.CondUnitMCA = ""
                        pItem.UnitCoolerFanMotorAmps = ""
                        pItem.UnitCoolerDefrostHeaterAmps = ""

                    Case Business.EquipmentType.CondensingUnit
                        Dim pEI As CondensingUnitEquipmentItem = CType(ei, CondensingUnitEquipmentItem)
                        pItem.DesignRefrigType = pEI.specs.refrigerant
                        pItem.DefrostType = ""
                        pItem.DesignAmbientTemp = pEI.specs.ambient.ToString
                        pItem.DesignRoomTemp = ""
                        pItem.DesignEvapTemp = pEI.specs.evaporating_temperature.ToString
                        pItem.DesignSuctionTemp = pEI.specs.suction.ToString
                        pItem.DesignTD = ""
                        pItem.Capacity = pEI.specs.capacity_1.value_or_default(0) + pEI.specs.capacity_2.value_or_default(0) + pEI.specs.capacity_3.value_or_default(0) + pEI.specs.capacity_4.value_or_default(0)
                        pItem.CondUnitMCA = pEI.specs.mca.ToString
                        pItem.UnitCoolerFanMotorAmps = ""
                        pItem.UnitCoolerDefrostHeaterAmps = ""

                    Case Business.EquipmentType.ProductCooler
                        Dim pEI As ProductCoolerEquipmentItem = CType(ei, ProductCoolerEquipmentItem)
                        pItem.DesignRefrigType = pEI.Specs.Refrigerant
                        pItem.DefrostType = ""
                        pItem.DesignAmbientTemp = ""
                        pItem.DesignRoomTemp = pEI.Specs.BoxTemp.ToString
                        pItem.DesignEvapTemp = pEI.Specs.EvaporatorTemp.ToString
                        pItem.DesignSuctionTemp = ""
                        pItem.DesignTD = pItem.DesignTD
                        pItem.Capacity = pItem.Capacity
                        pItem.CondUnitMCA = ""
                        pItem.UnitCoolerFanMotorAmps = ""
                        pItem.UnitCoolerDefrostHeaterAmps = ""

                    Case Business.EquipmentType.UnitCooler
                        Dim pEI As unit_cooler = CType(ei, unit_cooler)
                        Dim motorAmps As Decimal = 0
                        Dim defrostAmps As Decimal = 0
                        GetUnitCoolerElectrical(pEI.model, pEI.fan_voltage.ToString, pEI.defrost_voltage.ToString, motorAmps, defrostAmps)
                        pItem.UnitCoolerFanMotorAmps = motorAmps

                        pItem.DesignRefrigType = pEI.refrigerant
                        If pEI.model_without_series.ToUpper.EndsWith("HG") Then
                            pItem.DefrostType = "Hot Gas"
                            pItem.UnitCoolerDefrostHeaterAmps = ""
                        ElseIf pEI.model_without_series.ToUpper.EndsWith("E") Then
                            pItem.DefrostType = "Elec."
                            pItem.UnitCoolerDefrostHeaterAmps = defrostAmps
                        ElseIf pEI.model_without_series.ToUpper.EndsWith("A") Then
                            pItem.DefrostType = "Air"
                            pItem.UnitCoolerDefrostHeaterAmps = ""
                        End If
                        pItem.DesignAmbientTemp = ""
                        pItem.DesignRoomTemp = pEI.box_temperature.ToString
                        pItem.DesignEvapTemp = pEI.evaporator_temperature.ToString
                        pItem.DesignSuctionTemp = ""
                        pItem.DesignTD = ""
                        pItem.Capacity = ""
                        pItem.CondUnitMCA = ""


                End Select


                For Each op In ei.options
                    pItem.OptionCodes.Add(op.Code)

                    If Not optionCodes.ContainsKey(op.Code) Then
                        optionCodes.Add(op.Code, op.Description)
                    End If

                Next

                For Each op In ei.special_options
                    pItem.OptionCodes.Add(op.Code)

                    If Not optionCodes.ContainsKey(op.Code) Then
                        optionCodes.Add(op.Code, op.Description)
                    End If

                Next


                eList.Add(pItem)

            End If
        Next

        '  report.
        Dim k As Integer = 10

        For Each e1 In eList

            Dim l As Integer = 65
            '   report.SetStrCellValue("A" & k, e1.PRNumber)
            PopulateCellWithBorder(Chr(l) & k, e1.DashNumber, report, l)

            PopulateCellWithBorder(Chr(l) & k, e1.UnitModelNumber, report, l)
            PopulateCellWithBorder(Chr(l) & k, e1.UnitQuantity, report, l)
            PopulateCellWithBorder(Chr(l) & k, e1.UnitTagOrRoom, report, l)
            PopulateCellWithBorder(Chr(l) & k, e1.DesignRefrigType, report, l)
            PopulateCellWithBorder(Chr(l) & k, e1.DefrostType, report, l)
            PopulateCellWithBorder(Chr(l) & k, e1.UnitPrimaryVoltage, report, l)
            PopulateCellWithBorder(Chr(l) & k, e1.UnitControlVoltage, report, l)
            PopulateCellWithBorder(Chr(l) & k, e1.DesignAmbientTemp, report, l)
            PopulateCellWithBorder(Chr(l) & k, e1.DesignRoomTemp, report, l)
            PopulateCellWithBorder(Chr(l) & k, e1.DesignEvapTemp, report, l)
            PopulateCellWithBorder(Chr(l) & k, e1.DesignSuctionTemp, report, l)
            PopulateCellWithBorder(Chr(l) & k, e1.DesignTD, report, l)
            PopulateCellWithBorder(Chr(l) & k, e1.Capacity, report, l)
            PopulateCellWithBorder(Chr(l) & k, e1.UnitDimensions, report, l)
            PopulateCellWithBorder(Chr(l) & k, e1.EstimatedOperatingWeight, report, l)
            PopulateCellWithBorder(Chr(l) & k, e1.CondUnitMCA, report, l)
            PopulateCellWithBorder(Chr(l) & k, e1.UnitCoolerFanMotorAmps, report, l)
            PopulateCellWithBorder(Chr(l) & k, e1.UnitCoolerDefrostHeaterAmps, report, l)
            PopulateCellWithBorder(Chr(l) & k, String.Join(", ", e1.OptionCodes.ToArray()), report, l)



            k += 1

        Next

        k += 2
        Dim sk As Integer = k

        Dim sortedOptionCodes As New List(Of String)
        'For Each s As String In optionCodes.Keys
        '    sortedOptionCodes.Add(s)
        'Next


        For Each s In optionCodes
            sortedOptionCodes.Add(s.Value & " || " & s.Key)
        Next

        sortedOptionCodes.Sort()


        report.document.Worksheet("Sheet1").Cell("A" & k).Value = "Option Codes"
        k += 1

        Dim letter1 As String = "A"
        Dim letter2 As String = "B"
        Dim letter3 As String = "C"
        Dim letter4 As String = "D"
        Dim letter5 As String = "E"
        Dim letter6 As String = "F"
        Dim letter7 As String = "G"

        ' Dim cRow As Integer = 35
        For Each s As String In sortedOptionCodes
            '            report.document.Worksheet("Sheet1").Cell(letter1 & k).Value = s
            '            report.document.Worksheet("Sheet1").Cell(letter2 & k).Value = optionCodes(s)

            Dim d As String = s.Substring(0, s.IndexOf("||")).Trim
            Dim c As String = s.Substring(s.IndexOf("||") + 2).Trim

            If ((k Mod 2) = 0) Then
                PopulateCell(letter1 & k, c, report)
                PopulateCell(letter2 & k, d, report)
            Else
                PopulateCellWithShade(letter1 & k, c, report)
                PopulateCellWithShade(letter2 & k, d, report)
                PopulateCellWithShade(letter3 & k, "", report)
                PopulateCellWithShade(letter4 & k, "", report)
                PopulateCellWithShade(letter5 & k, "", report)
                PopulateCellWithShade(letter6 & k, "", report)
                PopulateCellWithShade(letter7 & k, "", report)

            End If


            k += 1
            If k > 40 Then
                letter1 = "I"
                letter2 = "J"
                letter3 = "K"
                letter4 = "L"
                letter5 = "M"
                letter6 = "N"
                letter7 = "O"

                k = sk + 1
            End If

        Next


        report.document.Worksheet("Sheet1").Cell("I2").Value = projectName
        report.document.Worksheet("Sheet1").Cell("I3").Value = represenative
        report.document.Worksheet("Sheet1").Cell("I4").Value = todaysDate
        report.document.Worksheet("Sheet1").Cell("I5").Value = prNumber
        report.document.Worksheet("Sheet1").Cell("N5").Value = Altitude



        '  report.document.Worksheet("Sheet1").Cell("G19", "Test!!!!!!!!!!!!!!!!!!!!!!!!!!!")

        ' report.mark_as_final()
        report.show()

    End Sub

    Private Sub PopulateCellWithBorder(ByVal address As String, ByVal value As String, ByVal report As Rae.reporting.beta.ExcelReportClosed, ByRef l As Integer)
        PopulateCellWithBorder(address, value, report)
        l += 1
    End Sub

    Private Sub PopulateCellWithBorder(ByVal address As String, ByVal value As String, ByVal report As Rae.reporting.beta.ExcelReportClosed)
        report.document.Worksheet("Sheet1").Cell(address).Value = value
        report.document.Worksheet("Sheet1").Cell(address).Style.Border.BottomBorder = ClosedXML.Excel.XLBorderStyleValues.Thin
        report.document.Worksheet("Sheet1").Cell(address).Style.Border.LeftBorder = ClosedXML.Excel.XLBorderStyleValues.Thin
        report.document.Worksheet("Sheet1").Cell(address).Style.Border.RightBorder = ClosedXML.Excel.XLBorderStyleValues.Thin
    End Sub

    Private Sub PopulateCell(ByVal address As String, ByVal value As String, ByVal report As Rae.reporting.beta.ExcelReportClosed)
        report.document.Worksheet("Sheet1").Cell(address).Value = value
        '        report.document.Worksheet("Sheet1").Cell(address).Style.Border.BottomBorder = ClosedXML.Excel.XLBorderStyleValues.Thin
        '        report.document.Worksheet("Sheet1").Cell(address).Style.Border.LeftBorder = ClosedXML.Excel.XLBorderStyleValues.Thin
        '        report.document.Worksheet("Sheet1").Cell(address).Style.Border.RightBorder = ClosedXML.Excel.XLBorderStyleValues.Thin
    End Sub


    Private Sub PopulateCellWithShade(ByVal address As String, ByVal value As String, ByVal report As Rae.reporting.beta.ExcelReportClosed)
        report.document.Worksheet("Sheet1").Cell(address).Value = value
        report.document.Worksheet("Sheet1").Cell(address).Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.LightGray
    End Sub


    Sub GetUnitCoolerElectrical(ByVal unit_cooler_model As String, ByVal motorVoltage As String, ByVal defrostVoltage As String, ByRef MotorAmps As Double, ByRef DefrostAmps As Double)


        If unit_cooler_model.EndsWith("E") Then
            unit_cooler_model = unit_cooler_model.Substring(0, unit_cooler_model.Length - 1)
        ElseIf unit_cooler_model.EndsWith("A") Then
            unit_cooler_model = unit_cooler_model.Substring(0, unit_cooler_model.Length - 1)
        ElseIf unit_cooler_model.EndsWith("HG") Then
            unit_cooler_model = unit_cooler_model.Substring(0, unit_cooler_model.Length - 2)

        End If

        Dim connection = Common.CreateConnection(Common.UnitCoolerDbPath)
        Dim command = connection.CreateCommand()
        ' blargg - DL changed unit_coolers table to unitdetails
        Dim sql = "SELECT * " & _
                         "FROM [UnitDetails] " & _
                         "WHERE [modelwithoutrefrigerant] = '" & unit_cooler_model & "'"
        command.CommandText = sql
        Dim reader As IDataReader

        Try
            connection.Open()
            reader = command.ExecuteReader()
            If reader.Read() Then
                Select Case motorVoltage
                    Case "460/3/60"
                        MotorAmps = reader("MOTOR_AMPS_460_3Ph")
                    Case "460/1/60"
                        MotorAmps = reader("MOTOR_AMPS_460_1Ph")
                    Case "230/3/60"
                        MotorAmps = reader("MOTOR_AMPS_230_3Ph")
                    Case "230/1/60"
                        MotorAmps = reader("MOTOR_AMPS_230_1Ph")
                    Case "575/3/60"
                        MotorAmps = reader("MOTOR_AMPS_575_3Ph")
                    Case "575/1/60"
                        MotorAmps = reader("MOTOR_AMPS_575_3Ph")
                    Case "208/3/60"
                        MotorAmps = reader("MOTOR_AMPS_208_3Ph")
                    Case "115/1/60"
                        MotorAmps = reader("MOTOR_AMPS_115_1Ph")

                End Select

                Select Case defrostVoltage
                    Case "460/3/60"
                        DefrostAmps = reader("DH_AMPS_460_3Ph_TOT")
                    Case "460/1/60"
                        DefrostAmps = reader("DH_AMPS_460_1Ph_TOT")
                    Case "230/3/60"
                        DefrostAmps = reader("DH_AMPS_230_3Ph_TOT")
                    Case "230/1/60"
                        DefrostAmps = reader("DH_AMPS_230_1Ph_TOT")
                    Case "575/3/60"
                        DefrostAmps = reader("DH_AMPS_575_3Ph_TOT")
                    Case "575/1/60"
                        DefrostAmps = reader("DH_AMPS_575_3Ph_TOT")
                    Case "208/3/60"
                        DefrostAmps = reader("DH_AMPS_230_3Ph_TOT")
                    Case "115/1/60"
                        DefrostAmps = 0

                End Select


            End If
        Finally
            If reader IsNot Nothing Then _
               reader.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try


    End Sub




    Private Class ProposalEquipmentItem
        ' Public Property PRNumber As String = ""
        Public Property DashNumber As String = ""
        Public Property UnitModelNumber As String = ""
        Public Property UnitQuantity As String = ""
        Public Property UnitTagOrRoom As String = ""
        Public Property DesignRefrigType As String = ""
        Public Property DefrostType As String = ""
        Public Property UnitPrimaryVoltage As String = ""
        Public Property UnitControlVoltage As String = ""
        Public Property DesignAmbientTemp As String = ""
        Public Property DesignRoomTemp As String = ""
        Public Property DesignEvapTemp As String = ""
        Public Property DesignSuctionTemp As String = ""
        Public Property DesignTD As String
        Public Property Capacity As String = ""
        ' Public Property Altitude As String = ""
        Public Property UnitDimensions As String = ""
        Public Property EstimatedOperatingWeight As String = ""
        Public Property CondUnitMCA As String = ""
        Public Property UnitCoolerFanMotorAmps As String = ""
        Public Property UnitCoolerDefrostHeaterAmps As String = ""
        Public Property OptionCodes As New List(Of String)

    End Class

    Private Sub btnSaveInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveInfo.Click
        Dim user As String = AppInfo.User.username

        Dim sql = "select ID from ProposalInfo where Username = '" & user & "'"
        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Dim count As Integer = 0
        Dim id As String = ""

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                count += 1
                id = rdr("ID").ToString()
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try

        If count > 0 Then
            Dim update As String = "UPDATE ProposalInfo SET Company = @company, MyName = @name, MyPhone = @phone, MyEmail = @email, " &
                "MyTitle = @title, Username = @user WHERE ID = @id"
            Dim connection1 = Common.CreateConnection(Common.ProjectsDbPath)
            Dim updateCommand As New OleDbCommand
            updateCommand.CommandText = update
            updateCommand.Connection = connection1

            Dim company = New OleDbParameter("@company", OleDbType.VarChar)
            company.Value = txtMyCompanyName.Text
            updateCommand.Parameters.Add(company)
            Dim name = New OleDbParameter("@name", OleDbType.VarChar)
            name.Value = txtMyName.Text
            updateCommand.Parameters.Add(name)
            Dim phone = New OleDbParameter("@phone", OleDbType.VarChar)
            phone.Value = txtMyPhone.Text
            updateCommand.Parameters.Add(phone)
            Dim email = New OleDbParameter("@email", OleDbType.VarChar)
            email.Value = txtMyEmail.Text
            updateCommand.Parameters.Add(email)
            Dim title = New OleDbParameter("@title", OleDbType.VarChar)
            title.Value = txtMyTitle.Text
            updateCommand.Parameters.Add(title)
            Dim userParam = New OleDbParameter("@user", OleDbType.VarChar)
            userParam.Value = user
            updateCommand.Parameters.Add(userParam)
            Dim idParam = New OleDbParameter("@id", OleDbType.VarChar)
            idParam.Value = id
            updateCommand.Parameters.Add(idParam)

            Try
                connection1.Open()
                updateCommand.ExecuteNonQuery()
                MessageBox.Show("Your information has been updated successfully.")
            Finally
                If connection1.State <> ConnectionState.Closed Then _
                   connection1.Close()
            End Try
        Else
            Dim insert As String = "INSERT INTO ProposalInfo (Company, MyName, MyPhone, MyEmail, MyTitle, Username) " &
                "VALUES (@company, @name, @phone, @email, @title, @user)"
            Dim connection2 = Common.CreateConnection(Common.ProjectsDbPath)            
            Dim insertCommand As New OleDbCommand
            insertCommand.CommandText = insert
            insertCommand.Connection = connection2

            Dim company = New OleDbParameter("@company", OleDbType.VarChar)
            company.Value = txtMyCompanyName.Text
            insertCommand.Parameters.Add(company)
            Dim name = New OleDbParameter("@name", OleDbType.VarChar)
            name.Value = txtMyName.Text
            insertCommand.Parameters.Add(name)
            Dim phone = New OleDbParameter("@phone", OleDbType.VarChar)
            phone.Value = txtMyPhone.Text
            insertCommand.Parameters.Add(phone)
            Dim email = New OleDbParameter("@email", OleDbType.VarChar)
            email.Value = txtMyEmail.Text
            insertCommand.Parameters.Add(email)
            Dim title = New OleDbParameter("@title", OleDbType.VarChar)
            title.Value = txtMyTitle.Text
            insertCommand.Parameters.Add(title)
            Dim userParam = New OleDbParameter("@user", OleDbType.VarChar)
            userParam.Value = user
            insertCommand.Parameters.Add(userParam)

            Try
                connection2.Open()
                insertCommand.ExecuteNonQuery()
                MessageBox.Show("Your information has been saved successfully.")
            Finally
                If connection2.State <> ConnectionState.Closed Then _
                   connection2.Close()
            End Try
        End If
    End Sub
End Class