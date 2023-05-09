Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports Rae.RaeSolutions.DataAccess
Imports Rae.Security.IntegratedSecurity
Imports Rae.solutions.unit_coolers
Imports Rae.solutions.condensing_units

Class order_write_up_base
    Protected report As Rae.reporting.beta.report
    Protected text As Dictionary(Of String, String)

    Sub New(ByVal screen As EquipmentForm, ByVal report_file_path As String, Optional ByVal logo As String = "")
        screen.calculateAndDisplayPrices()

        Dim project_bag = New project_grabber(screen).grab
        text = New Dictionary(Of String, String)
        text.Add("project", project_bag.project_name)
        text.Add("project_id", project_bag.project_id)
        text.Add("representative", project_bag.rep)
        text.Add("representative_company", project_bag.rep_company)
        text.Add("architect", project_bag.architect)
        text.Add("architect_company", project_bag.architect_company)
        text.Add("engineer", project_bag.engineer)
        text.Add("engineer_company", project_bag.engineer_company)
        text.Add("contractor", project_bag.contractor)
        text.Add("contractor_company", project_bag.contractor_company)
        text.Add("date_created", DateTime.Now.ToString("M/d/yyyy"))

        text.Add("user", AppInfo.User.username)
        text.Add("application_version", My.Application.Info.Version.ToString)
        text.Add("year", DateTime.Now.Year)

        Dim equipment_bag = New equipment_grabber(screen).grab
        text.Add("job", equipment_bag.job)
        text.Add("unit_quantity", equipment_bag.quantity)
        Dim model As String
        If equipment_bag.custom_model.is_not_set Then
            model = equipment_bag.model
        Else
            model = equipment_bag.custom_model & " (Base:" & equipment_bag.model & ")"
        End If
        text.Add("model", model)


        Select Case equipment_bag.equipmentType.ToUpper
            Case "UNITCOOLER"
                Dim bagUC = New unit_cooler_specs_grabber(screen).grab


                Dim ucr = New Rae.solutions.unit_coolers.repository
                Dim doeFlag As Boolean = ucr.CheckDOE(bagUC.model.Replace("-E", "").Replace("-A", "").Replace("-HG", ""))

                If doeFlag Then
                    text.Add("DOE", "Yes")
                Else
                    text.Add("DOE", "No")
                End If


            Case "CONDENSINGUNIT"
                Dim doeFlag As Boolean = New Rae.solutions.condensing_units.Repository().CheckDOE(model)

                If doeFlag Then
                    text.Add("DOE", "Yes")
                Else
                    text.Add("DOE", "No")
                End If

            Case Else
                text.Add("DOE", "No")
        End Select


        Dim pricing_bag = New pricing_grabber(screen).grab
        text.Add("total_base_list_price", pricing_bag.base_list)
        text.Add("total_options_price", pricing_bag.options)
        text.Add("total_list_price", pricing_bag.total_list)
        text.Add("other_price", pricing_bag.other)
        text.Add("other_description", pricing_bag.other_description)

        'blargg
        Dim contractor As String = "Yes"
        Dim connection = New OleDbConnection(ConnectionString.Text)
        Dim command = connection.CreateCommand
        Dim rdr As IDataReader

        Try
            Dim strSQL As String = "SELECT [Contractor] FROM [Table1] WHERE User_Name = '" & AppInfo.User.username.ToString & "'"

            command.CommandText = strSQL
            command.Connection = connection
            connection.Open()

            rdr = command.ExecuteReader()

            If rdr.Read Then
                If rdr("Contractor").ToString() = "False" Then
                    contractor = "No"
                Else
                    contractor = "Yes"
                End If
            End If

        Catch ex As Exception
            contractor = "Yes"
        Finally
            If Not rdr Is Nothing Then rdr.Close()
            command.Dispose()
            connection.Dispose()
        End Try

        If contractor = "Yes" Then
            text.Add("multiplier", " ")
            text.Add("par_price", " ")
            text.Add("commission", " ")
            text.Add("commission_rate", " ")
            text.Add("ParMultiplierLabel", " ")
            text.Add("ParPriceLabel", " ")
            text.Add("CommissionLabel", " ")
            text.Add("CommissionRateLabel", " ")
        Else
            text.Add("multiplier", pricing_bag.par_multiplier)
            text.Add("par_price", pricing_bag.par_price)

            Dim parPrice As String = pricing_bag.par_price.Replace("$", "")
            Dim warranty As String = pricing_bag.warranty.Replace("$", "")
            Dim startUp As String = pricing_bag.start_up.Replace("$", "")
            Dim otherPrice As String = pricing_bag.other.Replace("$", "")

            If Not Int32.TryParse(parPrice, 0) Then parPrice = "0"
            If Not Int32.TryParse(warranty, 0) Then warranty = "0"
            If Not Int32.TryParse(startUp, 0) Then startUp = "0"
            If Not Int32.TryParse(otherPrice, 0) Then otherPrice = "0"


            Dim totalInvoice As Integer = Int32.Parse(parPrice) + Int32.Parse(warranty) + Int32.Parse(startUp) + Int32.Parse(otherPrice)
            text.Add("total_invoice", "$" & totalInvoice.ToString())
            text.Add("commission", pricing_bag.commission)

            Dim temp As Decimal
            Dim commisionRate As String = pricing_bag.commission_rate.ToString()
            'If Decimal.TryParse(commisionRate, temp) Then
            '    commisionRate = temp.ToString("0.0000")
            'Else
            '    commisionRate = pricing_bag.commission_rate.ToString().Substring(0, 6)
            'End If

            text.Add("commission_rate", commisionRate)
        End If



        text.Add("freight", pricing_bag.freight)
        text.Add("start_up", pricing_bag.start_up)
        text.Add("warranty", pricing_bag.warranty)

        screen.populateSelectedOptionsDataSet(False)
        Dim options = screen.selectedOpsDs.SelectedOptions



        Dim options_table = New DataTable
        options_table.Columns.Add("Quantity")
        options_table.Columns.Add("Code")
        options_table.Columns.Add("Description")
        options_table.Columns.Add("Price")



        For Each op In options
            ' find out if quantity is read only and has a lock in quantity column

            Dim price As String
            If Not AppInfo.User.can_view_pricing Then
                If op.Price = 999999 Then price = "Standard" Else price = ""
            ElseIf op.Price = 999999 Then
                price = "Standard"
            ElseIf op.ContactFactory Then
                price = "Contact Factory"
            Else
                price = "$" & op.Price.ToString("#,#")
            End If
            Dim description As String
            If Not op.LongDescription = "" Then
                description = op.Description & "  Details: " & op.LongDescription
            Else
                description = op.Description
            End If
            options_table.Rows.Add(op.Quantity, op.Code, description, price)
        Next

        Dim form As MainForm = MainForm

        If MainForm.currentLogo <> "" Then
            Dim logo_command = New get_logo_file_path_command(AppInfo.User, MainForm.currentLogo)
            Dim logo_file_path = logo_command.executeWithLogo(MainForm.currentLogo)

            report = New Rae.reporting.beta.report(report_file_path)
            report.set_table("options", options_table, New Rae.reporting.beta.order_write_up_table_factory)
            report.set_image("logo", logo_file_path)
        Else
            Dim logo_command = New get_logo_file_path_command(AppInfo.User, AppInfo.Division.ToString)
            Dim logo_file_path = logo_command.execute

            report = New Rae.reporting.beta.report(report_file_path)
            report.set_table("options", options_table, New Rae.reporting.beta.order_write_up_table_factory)
            report.set_image("logo", logo_file_path)
        End If

    End Sub

    Sub show(ByVal generateOnly As Boolean, ByRef fileName As String, Optional ByVal showReport As Boolean = False, Optional ByVal logo As String = "")
        Try
            report.set_text(text)
            report.mark_as_final()

            If generateOnly Then
                If showReport Then
                    If MainForm.currentLogo <> "" Then
                        report.close()
                        Dim p As Process = New Process()
                        Dim psi As ProcessStartInfo = New ProcessStartInfo()
                        psi.CreateNoWindow = True
                        psi.Verb = "print"
                        psi.FileName = report.report_file_path
                        p.StartInfo = psi
                        p.Start()
                    Else
                        report.show()
                    End If
                Else
                    fileName = report.generate
                End If
            Else
                report.show()
            End If

        Catch ex As System.ComponentModel.Win32Exception
            Rae.Ui.warn(ex.Message)
        End Try
    End Sub



    'Sub show(ByVal generateOnly As Boolean, ByRef fileName As String)
    '    Try
    '        report.set_text(text)
    '        If generateOnly Then
    '            fileName = report.generate
    '        Else
    '            report.show()
    '        End If

    '    Catch ex As System.ComponentModel.Win32Exception
    '        Rae.Ui.warn(ex.Message)
    '    End Try
    'End Sub





End Class