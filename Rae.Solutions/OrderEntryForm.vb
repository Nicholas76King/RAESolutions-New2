Imports System.Data
Imports ClosedXML.Excel
Imports Rae.RaeSolutions.DataAccess
Imports System.Math
Imports System.IO
Imports Rae.RaeSolutions.Business.Entities.ProjectItem



Public Class OrderEntryForm
    Public Shared items As Integer = 0

    Private Sub OrderEntryForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        addMarketCodes()
        loadData()
    End Sub

    Private Sub loadData()
        Dim projectID As String = OpenedProject.ProjectId.ToString()

        Dim sql = "select top 1 ProjectRevision, Name, ReleaseNum, HoursBeforeDeliveryToCall, PoNum, PoDate, RequestedShipDate, RepId, RepCompanyId, ProjectOwner from Projects where ProjectID = '" & projectID & "' ORDER BY ProjectRevision DESC"
        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Dim releaseNum As String = ""
        Dim name As String = ""
        Dim repID As String = ""
        Dim repCompanyID As String = ""
        Dim poNumber As String = ""
        Dim requestedShipDate As String = ""
        Dim hoursBefore As String = ""
        Dim poDate As String = ""
        Dim salesman As String = ""
        Dim revisionNum As Integer = 0

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                releaseNum = rdr("ReleaseNum").ToString()
                name = rdr("Name").ToString()
                repID = rdr("RepID").ToString()
                repCompanyID = rdr("RepCompanyId").ToString()
                poNumber = rdr("PoNum").ToString()
                requestedShipDate = rdr("RequestedShipDate").ToString()
                If Not String.IsNullOrWhiteSpace(rdr("PoDate").ToString()) Then
                    poDate = CDate(rdr("PoDate")).ToShortDateString()
                End If
                hoursBefore = rdr("HoursBeforeDeliveryToCall").ToString()
                salesman = rdr("ProjectOwner").ToString()
                revisionNum = rdr("ProjectRevision")
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try

        If releaseNum = "" Or releaseNum = "0" Then
            txtPR.Text = ""
        Else
            txtPR.Text = releaseNum
        End If

        If String.IsNullOrEmpty(salesman) Then
            txtSalesperson.Text = ""
        Else
            txtSalesperson.Text = salesman
        End If

        If String.IsNullOrEmpty(repCompanyID) Or repCompanyID = "0" Then
            txtRepAccount.Text = ""
        Else
            txtRepAccount.Text = repCompanyID
        End If

        If poNumber = "" Or poNumber = "0" Then
            txtPO.Text = ""
        Else
            txtPO.Text = poNumber
        End If

        If poDate = "12/30/1899" Then
            txtPODate.Text = ""
        Else
            txtPODate.Text = poDate
        End If

        If String.IsNullOrEmpty(requestedShipDate) Then
            txtReqShip.Text = ""
        Else
            txtReqShip.Text = requestedShipDate
        End If

        If String.IsNullOrEmpty(hoursBefore) Then
            txtHours.Text = ""
        Else
            txtHours.Text = hoursBefore
        End If

        Dim sql1 = "select EquipmentID from Equipment where ProjectID = '" & projectID & "' AND ProjectRevision = " & revisionNum
        command.Parameters.Clear()
        command = connection.CreateCommand
        command.CommandText = sql1

        'Dim items As Integer = 0

        Try
            items = 0
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                items += 1
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try

        Dim pages As Integer = (items / 5) + 1
        Dim workbook As New XLWorkbook(AppDomain.CurrentDomain.BaseDirectory.Replace("\bin\Debug", "") & "\reports\EquipmentOrderEntry.xlsx")
        'Dim tempWorksheet As IXLWorksheet = workbook.Worksheet("Sheet1")
        'Dim template = tempWorksheet.Range("A1:O38")
        Dim worksheet As IXLWorksheet
        Dim template As IXLWorksheet = workbook.Worksheet("Sheet1")

        Dim customerNum As String = ""
        Dim repNum As String = ""
        Dim address1 As String = ""
        Dim address2 As String = ""
        Dim city As String = ""
        Dim state As String = ""
        Dim zipcode1 As String = ""
        Dim zipcode2 As String = ""
        Dim phone As String = ""
        Dim fax As String = ""
        Dim customerName As String = ""
        If OpenedProject.Manager.Project.Contacts.Count > 0 Then
            If Not String.IsNullOrEmpty(OpenedProject.Manager.Project.Contacts(0).RepNum.ToString()) Then
                Dim sql3 = "select Id, CustomerNum, RepNum, FirstName, LastName, Line1, Line2, City, State, ZipCode5, ZipCode4, PhoneNumAreaCode, PhoneNum, PhoneNumExtension, FaxNum, FaxNumAreaCode from Contacts where RepNum = " & OpenedProject.Manager.Project.Contacts(0).RepNum.ToString()
                command.Parameters.Clear()
                command = connection.CreateCommand
                command.CommandText = sql3

                Try
                    connection.Open()
                    rdr = command.ExecuteReader()
                    While rdr.Read
                        customerNum = rdr("CustomerNum").ToString()
                        repNum = rdr("RepNum").ToString()
                        address1 = rdr("Line1").ToString()
                        address2 = rdr("Line2").ToString()
                        city = rdr("City").ToString()
                        state = rdr("State").ToString()
                        zipcode1 = rdr("ZipCode5").ToString()
                        zipcode2 = rdr("ZipCode4").ToString()
                        name = rdr("FirstName").ToString() & " " & rdr("LastName").ToString()
                        phone = "(" & rdr("PhoneNumAreaCode").ToString() & ")" & " " & rdr("PhoneNum").ToString()
                        If rdr("PhoneNumExtension").ToString() <> "0" Then
                            phone += ", Ext. " & rdr("PhoneNumExtension").ToString()
                        End If
                        fax = "(" & rdr("FaxNumAreaCode").ToString() & ")" & " " & rdr("FaxNum").ToString()
                    End While
                Finally
                    If rdr IsNot Nothing Then _
                       rdr.Close()
                    If connection.State <> ConnectionState.Closed Then _
                       connection.Close()
                End Try
            End If
        End If

        If OpenedProject.Manager.Project.Contacts.Count > 0 Then
            If String.IsNullOrEmpty(OpenedProject.Manager.Project.Contacts(0).Company.ToString()) Then
                txtRepName.Text = ""
            Else
                txtRepName.Text = OpenedProject.Manager.Project.Contacts(0).Company.ToString()
            End If
        End If

        If OpenedProject.Manager.Project.Contacts.Count > 0 Then
            If String.IsNullOrEmpty(OpenedProject.Manager.Project.Contacts(0).RepNum.ToString()) Then
                txtRepAccount.Text = ""
            Else
                txtRepAccount.Text = OpenedProject.Manager.Project.Contacts(0).RepNum.ToString()
            End If
        End If

        If String.IsNullOrEmpty(address1) Then
            txtInvoiceAddress.Text = ""
        Else
            txtInvoiceAddress.Text = address1
        End If

        If String.IsNullOrEmpty(address2) Then
            txtInvoiceAddress2.Text = ""
        Else
            txtInvoiceAddress2.Text = address2
        End If

        If String.IsNullOrEmpty(city) Then
            txtInvoiceCity.Text = ""
        Else
            txtInvoiceCity.Text = city
        End If

        If String.IsNullOrEmpty(state) Then
            txtInvoiceState.Text = ""
        Else
            txtInvoiceState.Text = state
        End If

        If String.IsNullOrEmpty(zipcode1) Then
            txtInvoiceZip.Text = ""
        Else
            txtInvoiceZip.Text = zipcode1
        End If

        If phone = "(0) 0" Then
            txtInvoicePhone.Text = ""
        Else
            txtInvoicePhone.Text = phone
        End If

        'If String.IsNullOrEmpty(name) Then
        '    txtInvoiceName.Text = ""
        'Else
        '    txtInvoiceName.Text = name
        'End If

        If OpenedProject.Manager.Project.Contacts.Count > 0 Then
            If String.IsNullOrEmpty(OpenedProject.Manager.Project.Contacts(0).Name.ToString()) Then
                txtInvoiceName.Text = ""
            Else
                txtInvoiceName.Text = OpenedProject.Manager.Project.Contacts(0).Name.ToString()
            End If
        End If
        'txtShipAddress.Text = address1
        'txtShipCity.Text = city
        'txtShipState.Text = state
        'txtShipZip.Text = zipcode1
        'txtShipPhone.Text = phone

    End Sub

    Private Sub generateDocument()
        Dim projectID As String = OpenedProject.ProjectId.ToString()

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        Dim rdr As IDataReader

        Dim pages As Integer = System.Math.Floor((items / 5) + 1)
        Dim workbook As New XLWorkbook(AppDomain.CurrentDomain.BaseDirectory.Replace("\bin\Debug", "") & "\reports\EquipmentOrderEntry.xlsx")
        Dim worksheet As IXLWorksheet
        Dim template As IXLWorksheet = workbook.Worksheet("Sheet1")

        Dim i As Integer = 1
        For x As Integer = 1 To pages
            If x <> 1 Then

                template.CopyTo(workbook, "Sheet" & x)
                worksheet = workbook.Worksheet("Sheet" & x)
                worksheet.Cell("O2").Value = x.ToString()
            Else
                worksheet = workbook.Worksheet("Sheet1")
                worksheet.Cell("O2").Value = x.ToString()
                worksheet.Cell("O5").Value = Now.ToShortDateString()

                If rbResale.Checked Then worksheet.Cell("L7").Value = "X"
                If rbTaxable.Checked Then worksheet.Cell("L8").Value = "X"
                If rbTaxExempt.Checked Then worksheet.Cell("L9").Value = "X"

                worksheet.Cell("H3").Value = txtOrderNumber.Text
                worksheet.Cell("H4").Value = txtRepName.Text
                worksheet.Cell("O9").Value = txtTaxNumber.Text
                worksheet.Cell("M32").Value = txtReqShip.Text
                worksheet.Cell("N4").Value = txtPR.Text
                worksheet.Cell("H6").Value = txtPO.Text
                worksheet.Cell("H7").Value = txtPODate.Text
                worksheet.Cell("N27").Value = txtHours.Text
                worksheet.Cell("H5").Value = txtRepAccount.Text
                worksheet.Cell("B28").Value = txtShipName.Text
                worksheet.Cell("B29").Value = txtShipAddress.Text
                worksheet.Cell("B30").Value = txtShipAddress2.Text
                worksheet.Cell("B31").Value = txtShipCity.Text & ", " & txtShipState.Text & " " & txtShipZip.Text
                worksheet.Cell("G34").Value = AppInfo.User.username.ToString()
                worksheet.Cell("A2").Value = "Attn: " & txtSalesperson.Text
                worksheet.Cell("B4").Value = txtInvoiceName.Text
                worksheet.Cell("B5").Value = txtInvoiceAddress.Text
                worksheet.Cell("B6").Value = txtInvoiceAddress2.Text
                worksheet.Cell("B7").Value = txtInvoiceCity.Text & ", " & txtInvoiceState.Text & " " & txtInvoiceZip.Text
                worksheet.Cell("G34").Value = AppInfo.User.username.ToString()
                worksheet.Cell("G28").Value = txtNotes.Text
                worksheet.Cell("M29").Value = txtCallName.Text & " " & txtCallNumber.Text

                If cboMarket.Text <> "" Then 'cboMarket.SelectedItem.ToString() <> "" OR 
                    Dim marketNum As String = cboMarket.Text 'cboMarket.SelectedItem.ToString()
                    If marketNum.Length > 5 Then
                        Dim arr As String() = marketNum.Split(" ")
                        worksheet.Cell("D33").Value = arr(0)
                    End If
                End If
            End If

            If i + 5 > items Then
                Dim difference As Integer = items - (i - 1)

                If difference = 0 Then
                    worksheet.Cell("E12").Value = "-"
                    worksheet.Cell("G12").Value = "-"
                    worksheet.Cell("H12").Value = "-"
                    worksheet.Cell("J12").Value = "-"
                    worksheet.Cell("N12").Value = "TOTAL"
                    Exit For
                End If

                If difference = 1 Then
                    worksheet.Cell("E12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("G12").Value = "-"
                    i += 1
                    worksheet.Cell("H12").Value = "-"
                    i += 1
                    worksheet.Cell("J12").Value = "-"
                    i += 1
                    worksheet.Cell("N12").Value = "TOTAL"
                End If

                If difference = 2 Then
                    worksheet.Cell("E12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("G12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("H12").Value = "-"
                    i += 1
                    worksheet.Cell("J12").Value = "-"
                    i += 1
                    worksheet.Cell("N12").Value = "TOTAL"
                End If

                If difference = 3 Then
                    worksheet.Cell("E12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("G12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("H12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("J12").Value = "-"
                    i += 1
                    worksheet.Cell("N12").Value = "TOTAL"
                End If

                If difference = 4 Then
                    worksheet.Cell("E12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("G12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("H12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("J12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("N12").Value = "TOTAL"
                End If

                If difference = 5 Then
                    worksheet.Cell("E12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("G12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("H12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("J12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("N12").Value = i.ToString()
                    i += 1
                End If

                'wrong
                'If ((i - 1) - difference) = items Then
                '    worksheet.Cell("N12").Value = "TOTAL"
                'End If

            Else
                worksheet.Cell("E12").Value = i.ToString()
                i += 1
                worksheet.Cell("G12").Value = i.ToString()
                i += 1
                worksheet.Cell("H12").Value = i.ToString()
                i += 1
                worksheet.Cell("J12").Value = i.ToString()
                i += 1
                worksheet.Cell("N12").Value = i.ToString()
                i += 1
            End If
        Next

        Dim saveAs As String = ""
        If String.IsNullOrEmpty(txtSaveAs.Text) Then
            If String.IsNullOrEmpty(txtPR.Text) Then
                Dim rnd As New Random
                saveAs = "OrderEntry_" & Date.Today.ToString("MM-dd-yyyy") & "_" & rnd.Next(0, Integer.MaxValue).ToString()
            Else
                saveAs = "OrderEntry_" & txtPR.Text.ToString().Replace("\", "-").Replace("/", "-").Replace(Chr(34), "").Replace(":", "").Replace("&", "and").Trim()
            End If
        Else
            saveAs = txtSaveAs.Text.ToString().Replace("\", "-").Replace("/", "-").Replace(Chr(34), "").Replace(":", "").Replace("&", "and").Trim()
        End If

        Dim filepath As String = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents") & "\Order Entry Forms\" & saveAs & ".xlsx"

        workbook.SaveAs(filepath)
        Dim p As Process = New Process()
        Dim psi As ProcessStartInfo = New ProcessStartInfo()
        psi.CreateNoWindow = True
        psi.Verb = "Open"
        psi.FileName = filepath
        p.StartInfo = psi
        p.Start()

    End Sub

    Private Sub addMarketCodes()
        cboMarket.Items.Add("111100 - Grain Farming")
        cboMarket.Items.Add("111200 - Vegetable Farming")
        cboMarket.Items.Add("111300 - Fruit and Nut Farming")
        cboMarket.Items.Add("111400 - Nursery and Tree Farming")
        cboMarket.Items.Add("111900 - Tobacco, Sugar, Beet, and Peanut Farming")
        cboMarket.Items.Add("112100 - Beef & Dairy Cattle Ranching and Farming")
        cboMarket.Items.Add("112200 - Hog Farming")
        cboMarket.Items.Add("112300 - Chicken & Poultry Hatheries & Production")
        cboMarket.Items.Add("115100 - Post Harvest Crop Activities")
        cboMarket.Items.Add("311100 - Dog, Cat, & Other Animal Food Production")
        cboMarket.Items.Add("311222 - Soybean Processing")
        cboMarket.Items.Add("311230 - Breakfast Cereal Manufacturing")
        cboMarket.Items.Add("311411 - Frozen Fruit, Juice, and Vegetable Manufacturing")
        cboMarket.Items.Add("311412 - Frozen Specialty Food Manufacturing")
        cboMarket.Items.Add("311421 - Fruit and Vegetable Canning")
        cboMarket.Items.Add("311423 - Dried and Dehydrated Food Manufacturing")
        cboMarket.Items.Add("311500 - Dairy Products Manufacturing")
        cboMarket.Items.Add("311611 - Animal (Except Poultry) Slaughtering")
        cboMarket.Items.Add("311612 - Meat Processed From Carcasses")
        cboMarket.Items.Add("311613 - Rendering and Meat Byproduct Processing")
        cboMarket.Items.Add("311615 - Poultry Processing")
        cboMarket.Items.Add("311700 - Fresh and Frozen Seafood Processing")
        cboMarket.Items.Add("311800 - Bakery: Retail, Commercial, and Manufacturing")
        cboMarket.Items.Add("311823 - Dry Pasta Manufacturing")
        cboMarket.Items.Add("311830 - Tortilla Manufacturing")
        cboMarket.Items.Add("311910 - Roasted Nuts, Peanut Butter, and Other Snack Food Mfg.")
        cboMarket.Items.Add("311920 - Coffee and Tea Manufacturing")
        cboMarket.Items.Add("311930 - Flavoring Syrup and Concentrate Manufacturing")
        cboMarket.Items.Add("311940 - Dressing, Sauce, and Spice Manufacturing")
        cboMarket.Items.Add("311990 - Perishable and Miscellaneous Food Manufacturing")
        cboMarket.Items.Add("312110 - Soft Drink and Bottled Water Manufacturing")
        cboMarket.Items.Add("312113 - Ice Manufacturing")
        cboMarket.Items.Add("312120 - Breweries and Distilleries")
        cboMarket.Items.Add("312130 - Wineries")
        cboMarket.Items.Add("314100 - Carpet and Drapery Mills")
        cboMarket.Items.Add("324110 - Petroleum Refineries and Products Mfg.")
        cboMarket.Items.Add("325110 - PetroChemical Manufacturing")
        cboMarket.Items.Add("325400 - Medicinal and Biopharmiceutical Mnaufactruing")
        cboMarket.Items.Add("336111 - Automobile Mnaufacturing")
        cboMarket.Items.Add("424400 - Product Merchant Wholesalers")
        cboMarket.Items.Add("424500 - Grain and Farm Product Wholesalers")
        cboMarket.Items.Add("424800 - Beer, Wine, & Distilled Product Merchant Wholesalers")
        cboMarket.Items.Add("424900 - Farm Supplies, Nursery, & Flourist Supplies Wholesalers")
        cboMarket.Items.Add("445100 - Supermarkets, Grocery, and Convenience Stores")
        cboMarket.Items.Add("445200 - Meat, Fish, and Seafood Markets")
        cboMarket.Items.Add("445230 - Fruit and Vegetable Markets")
        cboMarket.Items.Add("445291 - Baked Goods Stores")
        cboMarket.Items.Add("445292 - Confectionary and Nut Stores")
        cboMarket.Items.Add("445299 - All Other Specialty Food Stores")
        cboMarket.Items.Add("445310 - Beer, Wine, and Liquor Stores")
        cboMarket.Items.Add("446100 - Pharmacies, Drugs, and Health Food Stores")
        cboMarket.Items.Add("447110 - Gas Stations with Convenience Stores")
        cboMarket.Items.Add("452910 - Warehouse Clubs and Supercenters")
        cboMarket.Items.Add("453110 - Flourists")
        cboMarket.Items.Add("453991 - Tobacco Stores")
        cboMarket.Items.Add("493120 - Refrigerated Warehousing and Storage")
        cboMarket.Items.Add("493130 - Farm Product Warehousing and Storage")
        cboMarket.Items.Add("541380 - Testing Laboratories")
        cboMarket.Items.Add("541710 - Research and Development for Biotechnology")
        cboMarket.Items.Add("621510 - Medical Labs and Diagnostic Imaging Centers")
        cboMarket.Items.Add("621991 - Blood and Organ Banks")
        cboMarket.Items.Add("624210 - Community Food Banks")
        cboMarket.Items.Add("722210 - Restaurants, Grill Buffets, Cafeterias, & Snack Bars")
        cboMarket.Items.Add("722300 - Food Service Contractors and Caterers")
        cboMarket.Items.Add("722410 - Drinking Places (Alcoholic Beverages)")
        cboMarket.Items.Add("927110 - Space Research and Technology")
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        generateDocument()
    End Sub

    Private Sub chkCopyInfo_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkCopyInfo.CheckedChanged
        If chkCopyInfo.Checked Then
            txtShipAddress.Text = txtInvoiceAddress.Text
            txtShipCity.Text = txtInvoiceCity.Text
            txtShipName.Text = txtInvoiceName.Text
            txtShipPhone.Text = txtInvoicePhone.Text
            txtShipState.Text = txtInvoiceState.Text
            txtShipZip.Text = txtInvoiceZip.Text
            txtShipAddress2.Text = txtInvoiceAddress2.Text
        Else
            txtShipAddress.Text = ""
            txtShipCity.Text = ""
            txtShipName.Text = ""
            txtShipPhone.Text = ""
            txtShipState.Text = ""
            txtShipZip.Text = ""
            txtShipAddress2.Text = ""
        End If
    End Sub
End Class