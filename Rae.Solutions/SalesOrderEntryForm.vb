Imports System
Imports System.Data
Imports System.Environment
Imports System.Linq
Imports Validation = Rae.validation
Imports CNull = Rae.ConvertNull
Imports Rae.RaeSolutions.Business
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.DataAccess
Imports CrystalDecisions.CrystalReports.Engine
Imports Rae.reporting
Imports Rae.reporting.CrystalReports
Imports System.Collections.Generic
Imports Rae.Ui.quickies
Imports System.IO
Imports ClosedXML.Excel
Imports System.Data.OleDb
Imports System.Math
Imports Rae.DataAccess.EquipmentOptions

Public Class SalesOrderEntryForm
    Private Sub SalesOrderEntryForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        loadData()
        addMarketCodes()
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

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        generateDocument()
    End Sub

    Private Sub generateDocument()
        Dim projectID As String = OpenedProject.ProjectId.ToString()

        Dim sql = "select top 1 ProjectRevision, Name, ReleaseNum, HoursBeforeDeliveryToCall, PoNum, PoDate, RequestedShipDate, RepId, RepCompanyId, ProjectOwner from Projects where ProjectID = '" & projectID & "' ORDER BY ProjectRevision DESC"
        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Dim items As Integer = 0
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
                'If Not String.IsNullOrWhiteSpace(rdr("PoDate").ToString()) Then
                '    poDate = CDate(rdr("PoDate")).ToShortDateString()
                'End If
                hoursBefore = rdr("HoursBeforeDeliveryToCall").ToString()
                salesman = rdr("ProjectOwner").ToString()
                revisionNum = rdr("ProjectRevision")
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then connection.Close()
        End Try


        Dim sql1 = "SELECT Equip, ListPosition FROM ( select DISTINCT(EquipmentID) AS Equip, MAX(Revision), ListPosition from Equipment where ProjectID = '" & projectID & "' AND Included = Yes GROUP BY EquipmentID, ListPosition ) t ORDER BY ListPosition"
        command.Parameters.Clear()
        command = connection.CreateCommand
        command.CommandText = sql1

        Dim equipIDList As New List(Of String)
        'Dim items As Integer = 0

        Try
            items = 0
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                items += 1
                equipIDList.Add(rdr("Equip"))
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try

        'Dim sql2 = "select ContactID from ProjectContacts where ProjectID = '" & projectID & "'"
        'command.Parameters.Clear()
        'command = connection.CreateCommand
        'command.CommandText = sql2

        'Dim contactList As New List(Of String)
        ''Dim items As Integer = 0

        'Try
        '    connection.Open()
        '    rdr = command.ExecuteReader()
        '    While rdr.Read
        '        contactList.Add(rdr("ContactID").ToString())
        '    End While
        'Finally
        '    If rdr IsNot Nothing Then _
        '       rdr.Close()
        '    If connection.State <> ConnectionState.Closed Then _
        '       connection.Close()
        'End Try


        'Dim sql3 = "select Description, FirstName, LastName, Line1, Line2, City, State, ZipCode5, ZipCode4, PhoneNumAreaCode, PhoneNum, " &
        '           "PhoneNumExtension from Contacts where (Description = 'Ship To' OR Description = 'Invoice To')"

        'Dim firstPass As Boolean = True

        'For Each contactID In contactList
        '    If firstPass = True Then
        '        sql3 &= " AND (Id = " & contactID
        '        firstPass = False
        '    Else
        '        sql3 &= " OR Id = " & contactID
        '    End If
        'Next

        'If contactList.Count > 0 Then
        '    sql3 &= ")"
        'End If

        'command.Parameters.Clear()
        'command = connection.CreateCommand
        'command.CommandText = sql3

        Dim shipName As String = txtShipName.Text.Trim()
        Dim shipLine1 As String = txtShipAddress.Text.Trim()
        Dim shipLine2 As String = txtShipAddress2.Text.Trim()
        Dim shipCity As String = txtShipCity.Text.Trim()
        Dim shipState As String = txtShipState.Text.Trim()
        Dim shipZip As String = txtShipZip.Text.Trim()
        Dim shipPhone As String = "" 'txtShipPhone.Text.Trim()

        Dim invoiceName As String = txtInvoiceName.Text.Trim()
        Dim invoiceLine1 As String = txtInvoiceAddress.Text.Trim()
        Dim invoiceLine2 As String = txtInvoiceAddress2.Text.Trim()
        Dim invoiceCity As String = txtInvoiceCity.Text.Trim()
        Dim invoiceState As String = txtInvoiceState.Text.Trim()
        Dim invoiceZip As String = txtInvoiceZip.Text.Trim()
        Dim invoicePhone As String = "" 'txtInvoicePhone.Text.Trim()

        'Try
        '    connection.Open()
        '    rdr = command.ExecuteReader()
        '    While rdr.Read
        '        If rdr("Description").ToString().ToLower() = "ship to" Then
        '            shipName = rdr("FirstName").ToString().Trim() & " " & rdr("LastName").ToString().Trim()
        '            shipLine1 = rdr("Line1").ToString().Trim()
        '            shipLine2 = rdr("Line2").ToString().Trim()
        '            shipCity = rdr("City").ToString().Trim()
        '            shipState = rdr("State").ToString().Trim()

        '            'If String.IsNullOrEmpty(rdr("ZipCode4")) Then
        '            '    shipZip = rdr("ZipCode5").ToString().Trim()
        '            'Else
        '            shipZip = rdr("ZipCode5").ToString().Trim() & " " & rdr("ZipCode4").ToString().Trim()
        '            'End If

        '            'If IsDBNull(rdr("PhoneNumExtension")) Then
        '            shipPhone = rdr("PhoneNumAreaCode").ToString().Trim() & "-" & rdr("PhoneNum").ToString().Trim()
        '            'Else
        '            shipPhone = rdr("PhoneNumAreaCode").ToString().Trim() & "-" & rdr("PhoneNum").ToString().Trim() & " " & rdr("PhoneNumExtension").ToString().Trim()
        '            'End If
        '        ElseIf rdr("Description").ToString().ToLower() = "invoice to" Then
        '            invoiceName = rdr("FirstName").ToString().Trim() & " " & rdr("LastName").ToString().Trim()
        '            invoiceLine1 = rdr("Line1").ToString().Trim()
        '            invoiceLine2 = rdr("Line2").ToString().Trim()
        '            invoiceCity = rdr("City").ToString().Trim()
        '            invoiceState = rdr("State").ToString().Trim()

        '            'If String.IsNullOrEmpty(rdr("ZipCode4")) Then
        '            '    invoiceZip = rdr("ZipCode5").ToString().Trim()
        '            'Else
        '            invoiceZip = rdr("ZipCode5").ToString().Trim() & " " & rdr("ZipCode4").ToString().Trim()
        '            'End If

        '            'If String.IsNullOrEmpty(rdr("PhoneNumExtension")) Then
        '            invoicePhone = rdr("PhoneNumAreaCode").ToString().Trim() & "-" & rdr("PhoneNum").ToString().Trim() & " " & rdr("PhoneNumExtension").ToString().Trim()
        '            'Else
        '            '   invoicePhone = rdr("PhoneNumAreaCode").ToString().Trim() & "-" & rdr("PhoneNum").ToString().Trim()
        '            'End If
        '        End If
        '    End While
        'Finally
        '    If rdr IsNot Nothing Then _
        '       rdr.Close()
        '    If connection.State <> ConnectionState.Closed Then _
        '       connection.Close()
        'End Try

        Dim pages As Integer = System.Math.Floor((items / 5) + 1)
        Dim workbook As New XLWorkbook(AppDomain.CurrentDomain.BaseDirectory.Replace("\bin\Debug", "") & "reports\EquipmentTemplate.xlsx")
        Dim worksheet As IXLWorksheet
        Dim template As IXLWorksheet = workbook.Worksheet("Sheet1")

        Dim summary As IXLWorksheet
        summary = workbook.Worksheet("Summary")

        If rbResale.Checked Then summary.Cell("F8").Value = "X"
        If rbTaxable.Checked Then summary.Cell("F9").Value = "X"
        If rbTaxExempt.Checked Then summary.Cell("F10").Value = "X"

        If txtTaxNumber.Text <> "" Then summary.Cell("H10").Value = txtTaxNumber.Text.ToString().Trim()

        summary.Cell("H2").Value = "1  of  " & (pages + 1).ToString()
        summary.Cell("D2").Value = Now.ToShortDateString()

        summary.Cell("F3").Value = txtPR.Text.ToString().Trim()
        summary.Cell("F4").Value = txtRepName.Text.ToString().Trim() 'repName
        summary.Cell("F5").Value = txtRepAccount.Text.ToString().Trim() 'txtTaxNumber.Text
        summary.Cell("F6").Value = txtPO.Text.ToString().Trim()
        summary.Cell("F7").Value = txtPODate.Text.ToString().Trim()
        summary.Cell("B4").Value = invoiceName
        summary.Cell("B5").Value = invoiceLine1
        summary.Cell("B6").Value = invoiceLine2

        If Not String.IsNullOrEmpty(invoiceCity) And Not String.IsNullOrEmpty(invoiceState) Then
            summary.Cell("B7").Value = invoiceCity & ", " & invoiceState & " " & invoiceZip
        End If

        'summary.Cell("B7").Value = invoiceZip
        summary.Cell("B35").Value = shipName
        summary.Cell("B36").Value = shipLine1
        summary.Cell("B37").Value = shipLine2

        If Not String.IsNullOrEmpty(shipState) And Not String.IsNullOrEmpty(shipCity) Then
            summary.Cell("B38").Value = shipCity & ", " & shipState & " " & shipZip
        End If

        'summary.Cell("B38").Value = shipZip
        summary.Cell("E41").Value = txtSalesperson.Text.ToString().Trim() 'AppInfo.User.username.ToString().Trim()
        summary.Cell("D40").Value = cboMarket.SelectedText.ToString().Trim()
        summary.Cell("G41").Value = txtReqShip.Text.ToString().Trim()
        summary.Cell("G35").Value = "Call " & txtCallName.Text.ToString().Trim()
        summary.Cell("G36").Value = txtHours.Text.ToString().Trim() & " hours before delivery."
        summary.Cell("G37").Value = txtCallNumber.Text.ToString().Trim()
        summary.Cell("D35").Value = txtNotes.Text.ToString().Trim()

        If cboMarket.Text <> "" Then 'cboMarket.SelectedItem.ToString() <> "" OR 
            Dim marketNum As String = cboMarket.Text 'cboMarket.SelectedItem.ToString()
            If marketNum.Length > 5 Then
                Dim arr As String() = marketNum.Split(" ")
                summary.Cell("D40").Value = arr(0)
            End If
        End If

        Select Case pages
            Case 1
                summary.Column("I").Hide()
                summary.Column("J").Hide()
                summary.Column("K").Hide()
                summary.Column("L").Hide()
                summary.Column("M").Hide()
                summary.Cell("E12").Value = ""
                summary.Cell("F12").Value = ""
                summary.Cell("G12").Value = ""
                summary.Cell("H12").Value = ""
                worksheet = workbook.Worksheet("Sheet2")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet3")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet4")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet5")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet6")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet7")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet8")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet9")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet10")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Summary")
                worksheet.Hide()
            Case 2
                summary.Column("I").Hide()
                summary.Column("J").Hide()
                summary.Column("K").Hide()
                summary.Column("L").Hide()
                summary.Column("M").Hide()
                summary.Cell("F12").Value = ""
                summary.Cell("G12").Value = ""
                summary.Cell("H12").Value = ""
                worksheet = workbook.Worksheet("Sheet3")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet4")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet5")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet6")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet7")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet8")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet9")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet10")
                worksheet.Hide()
            Case 3
                summary.Column("I").Hide()
                summary.Column("J").Hide()
                summary.Column("K").Hide()
                summary.Column("L").Hide()
                summary.Column("M").Hide()
                summary.Cell("G12").Value = ""
                summary.Cell("H12").Value = ""
                worksheet = workbook.Worksheet("Sheet4")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet5")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet6")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet7")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet8")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet9")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet10")
                worksheet.Hide()
            Case 4
                summary.Column("I").Hide()
                summary.Column("J").Hide()
                summary.Column("K").Hide()
                summary.Column("L").Hide()
                summary.Column("M").Hide()
                summary.Cell("H12").Value = ""
                worksheet = workbook.Worksheet("Sheet5")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet6")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet7")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet8")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet9")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet10")
                worksheet.Hide()
            Case 5
                summary.Column("I").Hide()
                summary.Column("J").Hide()
                summary.Column("K").Hide()
                summary.Column("L").Hide()
                summary.Column("M").Hide()
                worksheet = workbook.Worksheet("Sheet6")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet7")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet8")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet9")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet10")
                worksheet.Hide()
            Case 6
                summary.Column("J").Hide()
                summary.Column("K").Hide()
                summary.Column("L").Hide()
                summary.Column("M").Hide()
                worksheet = workbook.Worksheet("Sheet7")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet8")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet9")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet10")
                worksheet.Hide()
            Case 7
                summary.Column("K").Hide()
                summary.Column("L").Hide()
                summary.Column("M").Hide()
                worksheet = workbook.Worksheet("Sheet8")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet9")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet10")
                worksheet.Hide()
            Case 8
                summary.Column("L").Hide()
                summary.Column("M").Hide()
                worksheet = workbook.Worksheet("Sheet9")
                worksheet.Hide()
                worksheet = workbook.Worksheet("Sheet10")
                worksheet.Hide()
            Case 9
                summary.Column("M").Hide()
                worksheet = workbook.Worksheet("Sheet10")
                worksheet.Hide()
        End Select

        Dim i As Integer = 1
        For x As Integer = 1 To pages
            'If x <> 1 Then

            'Dim sheetx As IXLWorksheet
            'sheetx = workbook.Worksheet("Sheet" & x)

            'template.CopyTo(workbook, sheetx)
            'worksheet = workbook.Worksheet("Sheet" & x)
            'worksheet.Cell("I2").Value = x.ToString()
            'worksheet.Cell("K2").Value = pages.ToString()

            'Else
            worksheet = workbook.Worksheet("Sheet" & x)

            If rbResale.Checked Then worksheet.Cell("F8").Value = "X"
            If rbTaxable.Checked Then worksheet.Cell("F9").Value = "X"
            If rbTaxExempt.Checked Then worksheet.Cell("F10").Value = "X"

            If txtTaxNumber.Text <> "" Then worksheet.Cell("H10").Value = txtTaxNumber.Text.ToString().Trim()

            worksheet.Cell("I2").Value = (x + 1).ToString()
            worksheet.Cell("D2").Value = Now.ToShortDateString()
            worksheet.Cell("K2").Value = (pages + 1).ToString()

            If pages = 1 Then
                worksheet.Cell("K2").Value = "1"
                worksheet.Cell("I2").Value = "1"
            End If

            worksheet.Cell("F3").Value = txtPR.Text.ToString().Trim()
            worksheet.Cell("F4").Value = txtRepName.Text.ToString().Trim() 'repName
            worksheet.Cell("F5").Value = txtRepAccount.Text.ToString().Trim() 'txtTaxNumber.Text
            worksheet.Cell("F6").Value = txtPO.Text.ToString().Trim()
            worksheet.Cell("F7").Value = txtPODate.Text.ToString().Trim()
            worksheet.Cell("B4").Value = invoiceName
            worksheet.Cell("B5").Value = invoiceLine1
            worksheet.Cell("B6").Value = invoiceLine2

            If Not String.IsNullOrEmpty(invoiceCity) And Not String.IsNullOrEmpty(invoiceState) Then
                worksheet.Cell("B7").Value = invoiceCity & ", " & invoiceState & " " & invoiceZip
            End If

            'worksheet.Cell("B7").Value = invoiceZip
            worksheet.Cell("B42").Value = shipName
            worksheet.Cell("B43").Value = shipLine1
            worksheet.Cell("B44").Value = shipLine2

            If Not String.IsNullOrEmpty(shipState) And Not String.IsNullOrEmpty(shipCity) Then
                worksheet.Cell("B45").Value = shipCity & ", " & shipState & " " & shipZip
            End If

            'worksheet.Cell("B45").Value = shipZip
            worksheet.Cell("E48").Value = txtSalesperson.Text.ToString().Trim() 'AppInfo.User.username.ToString().Trim()
            'worksheet.Cell("D47").Value = cboMarket.SelectedText.ToString().Trim()
            worksheet.Cell("H48").Value = txtReqShip.Text.ToString().Trim()

            If txtCallName.Text.ToString().Trim() <> "" Then
                worksheet.Cell("H42").Value = "Call " & txtCallName.Text.ToString().Trim()
            End If

            If txtHours.Text.ToString().Trim() <> "" Then
                worksheet.Cell("H43").Value = txtHours.Text.ToString().Trim() & " hours before delivery."
            End If

            worksheet.Cell("H44").Value = txtCallNumber.Text.ToString().Trim()
            worksheet.Cell("E42").Value = txtNotes.Text.ToString().Trim()

            If cboMarket.Text <> "" Then 'cboMarket.SelectedItem.ToString() <> "" OR 
                Dim marketNum As String = cboMarket.Text 'cboMarket.SelectedItem.ToString()
                If marketNum.Length > 5 Then
                    Dim arr As String() = marketNum.Split(" ")
                    worksheet.Cell("D47").Value = arr(0)
                End If
                'End If
            End If

            If i + 5 > items Then
                Dim difference As Integer = items - (i - 1)

                If difference = 0 Then
                    worksheet.Cell("D12").Value = "-"
                    worksheet.Cell("E12").Value = "-"
                    worksheet.Cell("F12").Value = "-"
                    worksheet.Cell("G12").Value = "-"
                    worksheet.Cell("H12").Value = "-"
                    worksheet.Cell("J12").Value = "TOTAL"
                    Exit For
                End If

                If difference = 1 Then
                    worksheet.Cell("D12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("E12").Value = "-"
                    i += 1
                    worksheet.Cell("F12").Value = "-"
                    i += 1
                    worksheet.Cell("G12").Value = "-"
                    i += 1
                    worksheet.Cell("H12").Value = "-"
                    worksheet.Cell("J12").Value = "TOTAL"
                End If

                If difference = 2 Then
                    worksheet.Cell("D12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("E12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("F12").Value = "-"
                    i += 1
                    worksheet.Cell("G12").Value = "-"
                    i += 1
                    worksheet.Cell("H12").Value = "-"
                    worksheet.Cell("J12").Value = "TOTAL"
                End If

                If difference = 3 Then
                    worksheet.Cell("D12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("E12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("F12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("G12").Value = "-"
                    i += 1
                    worksheet.Cell("H12").Value = "-"
                    worksheet.Cell("J12").Value = "TOTAL"
                End If

                If difference = 4 Then
                    worksheet.Cell("D12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("E12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("F12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("G12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("H12").Value = "-"
                    worksheet.Cell("J12").Value = "TOTAL"
                End If

                If difference = 5 Then
                    worksheet.Cell("D12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("E12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("F12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("G12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("H12").Value = i.ToString()
                    i += 1
                    worksheet.Cell("J12").Value = "TOTAL"
                End If
            Else
                worksheet.Cell("D12").Value = i.ToString()
                i += 1
                worksheet.Cell("E12").Value = i.ToString()
                i += 1
                worksheet.Cell("F12").Value = i.ToString()
                i += 1
                worksheet.Cell("G12").Value = i.ToString()
                i += 1
                worksheet.Cell("H12").Value = i.ToString()
                i += 1
                worksheet.Cell("J12").Value = "TOTAL"
            End If
        Next

        Dim itemNum As Integer = 0
        Dim currentSheet As Integer = 1

        For Each equipmentID In equipIDList
            Dim model As String = ""
            Dim series As String = ""
            Dim salesClass As String = ""
            Dim unitTag As String = ""
            Dim quantity As Integer = 0
            Dim multiplier As String = ""
            Dim multiplierType As String = ""
            Dim warrantyPrice As String = ""

            itemNum += 1

            worksheet = workbook.Worksheet("Sheet" & currentSheet.ToString())

            Dim temp As Integer

            temp = itemNum Mod 5
            Dim column As String = ""

            Select Case temp
                Case 1
                    column = "D"
                Case 2
                    column = "E"
                Case 3
                    column = "F"
                Case 4
                    column = "G"
                Case 0
                    column = "H"
                    currentSheet += 1
                Case Else
            End Select

            Dim sql4 = "select Series, Tag, Quantity, Model, ParMultiplier, MultiplierType, WarrantyPrice, MAX(Revision) from Equipment where EquipmentID = '" & equipmentID & "' GROUP BY Series , Tag, Quantity, Model, ParMultiplier, MultiplierType, WarrantyPrice"
            command.Parameters.Clear()
            command = connection.CreateCommand
            command.CommandText = sql4

            Try
                items = 0
                connection.Open()
                rdr = command.ExecuteReader()
                While rdr.Read
                    model = rdr("Model").ToString().Trim()
                    series = rdr("Series").ToString().Trim()
                    unitTag = rdr("Tag").ToString().Trim()
                    quantity = rdr("Quantity")
                    multiplier = rdr("ParMultiplier").ToString().Trim()
                    multiplierType = rdr("MultiplierType").ToString().Trim()
                    warrantyPrice = rdr("WarrantyPrice").ToString().Trim()
                End While
            Finally
                If rdr IsNot Nothing Then _
                   rdr.Close()
                If connection.State <> ConnectionState.Closed Then _
                   connection.Close()
            End Try

            Select Case series
                Case "PFC"
                    salesClass = "401064"
                Case "LUI", "LUO"
                    salesClass = "404001"
                Case "RS"
                    salesClass = "402070"
                Case "DS"
                    salesClass = "402080"
                Case "DD"
                    salesClass = "410001"
                Case "DM"
                    salesClass = "411001"
                Case "FV"
                    salesClass = "421001"
                Case "UFH"
                    salesClass = "422001"
                Case "AWSM"
                    salesClass = "423001"
                Case "E"
                    salesClass = "423003"
                Case "BOC"
                    salesClass = "424001"
                Case "XBOC"
                    salesClass = "424002"
                Case "PFE"
                    salesClass = "424501"
                Case "HPC", "VPC"
                    salesClass = "428001"
                Case "BALV"
                    salesClass = "425510"
                Case "WC DS"
                    salesClass = "402401"
                Case "DX"
                    salesClass = "405201"
                Case "WIBR"
                    salesClass = "425520"
                Case "NSB"
                    salesClass = "402083"
                Case "NDB"
                    salesClass = "410003"
                Case "NMB"
                    salesClass = "411003"
                Case "NDS"
                    salesClass = "402082"
                Case "NDD"
                    salesClass = "410002"
                Case "NDM"
                    salesClass = "411002"
                Case "BRS"
                    salesClass = "402601"
                Case "BDS"
                    salesClass = "402501"
                Case "MPX"
                    salesClass = "402701"
                Case "NSC"
                    salesClass = "402082"
                Case "NDC"
                    salesClass = "410002"
                Case "NMC"
                    salesClass = "411002"
                Case Else
                    salesClass = ""
            End Select

            worksheet.Cell(column & "13").Value = salesClass
            worksheet.Cell(column & "14").Value = unitTag
            worksheet.Cell("C21").Value = multiplier
            worksheet.Cell(column & "16").Value = series & model
            worksheet.Cell(column & "15").Value = quantity
            worksheet.Cell(column & "34").Value = warrantyPrice

            Dim listPrice As String = ""

            Dim connectionEO = Common.CreateConnection(Common.ProjectsDbPath.Replace("Projects.mdb", "EquipmentOptions.mdb"))
            Dim sql5 = "select Price from EquipmentPricingView where Series = '" & series & "' AND Model = '" & model & "'"
            command.Parameters.Clear()
            command = connectionEO.CreateCommand
            command.CommandText = sql5

            Try
                items = 0
                connectionEO.Open()
                rdr = command.ExecuteReader()
                While rdr.Read
                    listPrice = rdr("Price").ToString().Trim()
                End While
            Finally
                If rdr IsNot Nothing Then _
                   rdr.Close()
                If connectionEO.State <> ConnectionState.Closed Then _
                   connectionEO.Close()
            End Try

            worksheet.Cell(column & "17").Value = CDbl(listPrice * quantity)

            Dim commissionRate As Double = 0
            If multiplierType = "Resco" Then
                If multiplier <= 0.281 Then
                    commissionRate = 0.0
                ElseIf multiplier > 0.281 And multiplier < 0.3194 Then
                    commissionRate = 3.13316 * multiplier - 0.880418
                ElseIf multiplier > 0.3193 Then
                    Dim num As Double = (((listPrice * multiplier) - (listPrice * 0.3193)) / 2) + (0.12 * (listPrice * 0.3193))
                    Dim den As Double = (listPrice * multiplier)
                    commissionRate = num / den
                End If
            Else
                If multiplier <= 0.29 Then
                    commissionRate = 0.0
                ElseIf multiplier > 0.29 And multiplier < 0.3296 Then
                    commissionRate = 2.85714286 * multiplier - 0.8214
                ElseIf multiplier > 0.3295 Then
                    Dim num1 As Double = (((listPrice * multiplier) - (listPrice * 0.3295)) / 2) + (0.12 * (listPrice * 0.3295))
                    Dim den1 As Double = (listPrice * multiplier)
                    commissionRate = num1 / den1
                End If
            End If

            worksheet.Cell("C27").Value = System.Math.Round(commissionRate, 6)

            'get option codes
            Dim optionPrice As Double = 0

            Dim sql6 = "SELECT PricingID, Quantity, MAX(Revision) FROM EquipmentOptions WHERE EquipmentID = '" & equipmentID & "' GROUP BY PricingID, Quantity"
            command.Parameters.Clear()
            command = connection.CreateCommand
            command.CommandText = sql6

            Try
                connection.Open()
                rdr = command.ExecuteReader()
                While rdr.Read()
                    Dim sql7 = "SELECT Price FROM OptionPricing WHERE [Id] = " & rdr("PricingID")
                    command.Parameters.Clear()
                    command = connectionEO.CreateCommand

                    command.CommandText = sql7
                    Dim rdr1 As IDataReader

                    Try
                        connectionEO.Open()
                        rdr1 = command.ExecuteReader()
                        While rdr1.Read
                            If CInt(rdr1("Price").ToString()) < 999997 Then
                                optionPrice += CDbl(rdr1("Price")) * CDbl(rdr("Quantity"))
                            End If
                        End While
                    Finally
                        If rdr1 IsNot Nothing Then _
                           rdr1.Close()
                        If connectionEO.State <> ConnectionState.Closed Then _
                           connectionEO.Close()
                    End Try

                End While
            Finally
                If rdr IsNot Nothing Then _
                   rdr.Close()
                If connection.State <> ConnectionState.Closed Then _
                   connection.Close()
            End Try

            Dim sql8 = "SELECT Price, Quantity, MAX(Revision) FROM SpecialOptions WHERE EquipmentId = '" & equipmentID & "' GROUP BY Price, Quantity"
            command.Parameters.Clear()
            command = connection.CreateCommand

            command.CommandText = sql8

            Try
                connection.Open()
                rdr = command.ExecuteReader()
                While rdr.Read()
                    optionPrice += CDbl(rdr("Price")) * CDbl(rdr("Quantity"))
                End While
            Finally
                If rdr IsNot Nothing Then _
                   rdr.Close()
                If connection.State <> ConnectionState.Closed Then _
                   connection.Close()
            End Try

            worksheet.Cell(column & "19").Value = CDbl(optionPrice * quantity)
        Next


        Dim saveAs As String = ""
        If String.IsNullOrEmpty(txtSaveAs.Text.ToString().Trim()) Then
            If String.IsNullOrEmpty(txtPR.Text.ToString().Trim()) Then
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

    Private Sub loadData()
        loadDropDowns()
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

        txtSalesperson.Text = AppInfo.User.first_name & " " & AppInfo.User.last_name

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

        Dim sql2 = "select ContactID from ProjectContacts where ProjectID = '" & projectID & "'"
        command.Parameters.Clear()
        command = connection.CreateCommand
        command.CommandText = sql2

        Dim contactList As New List(Of String)
        'Dim items As Integer = 0

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                contactList.Add(rdr("ContactID").ToString())
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try


        Dim sql3 = "select RepNum, CustomerNum from Contacts where (Description = 'Representative')"

        Dim firstPass As Boolean = True

        For Each contactID In contactList
            If firstPass = True Then
                sql3 &= " AND (Id = " & contactID
                firstPass = False
            Else
                sql3 &= " OR Id = " & contactID
            End If
        Next

        If contactList.Count > 0 Then
            sql3 &= ")"
        End If

        command.Parameters.Clear()
        command = connection.CreateCommand
        command.CommandText = sql3


        Dim repNum As String = ""
        Dim customerNum As String = ""

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                repNum = rdr("RepNum").ToString().Trim()
                customerNum = rdr("CustomerNum").ToString().Trim()
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try

        If String.IsNullOrEmpty(repNum) And Not String.IsNullOrEmpty(customerNum) Then
            Dim sql4 = "select RepNum from Companies where CustomerNum = '" & customerNum & "'"

            command.Parameters.Clear()
            command = connection.CreateCommand
            command.CommandText = sql4

            Try
                connection.Open()
                rdr = command.ExecuteReader()
                While rdr.Read
                    repNum = rdr("RepNum").ToString().Trim()
                End While
            Finally
                If rdr IsNot Nothing Then _
                   rdr.Close()
                If connection.State <> ConnectionState.Closed Then _
                   connection.Close()
            End Try
        End If

        If OpenedProject.Manager.Project.Contacts.Count > 0 Then
            If String.IsNullOrEmpty(OpenedProject.Manager.Project.Contacts(0).Company.ToString()) Then
                txtRepName.Text = ""
            Else
                txtRepName.Text = OpenedProject.Manager.Project.Contacts(0).Company.ToString()
            End If
        End If

        If OpenedProject.Manager.Project.Contacts.Count = 0 Then
            MessageBox.Show("We recommend adding a representative contact in the Contact Manager.")
            Return
        End If

        If String.IsNullOrEmpty(repNum) And String.IsNullOrEmpty(customerNum) And Not String.IsNullOrEmpty(OpenedProject.Manager.Project.Contacts(0).Company.ToString().Trim()) Then
            Dim sql5 = "select RepNum from Companies where Name = @repname"
            Dim command1 As New OleDbCommand
            command1 = connection.CreateCommand
            command1.Connection = connection
            command1.CommandType = CommandType.Text
            command1.Parameters.Add("@repname", OleDbType.VarChar)
            command1.Parameters("@repname").Value = OpenedProject.Manager.Project.Contacts(0).Company.ToString().Trim()
            command1.CommandText = sql5

            Try
                connection.Open()
                rdr = command1.ExecuteReader()
                While rdr.Read
                    repNum = rdr("RepNum").ToString().Trim()
                End While
            Finally
                If rdr IsNot Nothing Then _
                   rdr.Close()
                If connection.State <> ConnectionState.Closed Then _
                   connection.Close()
            End Try
        End If

        If OpenedProject.Manager.Project.Contacts.Count > 0 Then
            If String.IsNullOrEmpty(OpenedProject.Manager.Project.Contacts(0).RepNum.ToString()) Then
                txtRepAccount.Text = ""
            Else
                txtRepAccount.Text = OpenedProject.Manager.Project.Contacts(0).RepNum.ToString()
            End If
        End If

        If Not String.IsNullOrEmpty(repNum) Then
            txtRepAccount.Text = repNum
        End If

    End Sub


    Private Sub loadDropDowns()
        Dim projectID As String = OpenedProject.ProjectId.ToString()

        ', ProjectID, Address1, Address2, City, Zip, State, Phone, ContactType, UniqueID, ImportedFromCloud
        Dim sql = "SELECT DISTINCT Name FROM OrderEntryContacts WHERE ImportedFromCloud IS NULL ORDER BY Name"
        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        ddInvoiceName.Items.Add("")
        ddShipName.Items.Add("")

        Dim name As String = ""

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                ddInvoiceName.Items.Add(rdr("Name").ToString().Trim())
                ddShipName.Items.Add(rdr("Name").ToString().Trim())
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try

        Dim sql1 = "SELECT TOP 1 Name, ProjectID, Address1, Address2, City, Zip, State, Phone, ContactType, UniqueID, ImportedFromCloud FROM OrderEntryContacts WHERE ContactType = 'Invoice' AND ProjectID = @projectID ORDER BY UniqueID DESC"
        Dim command1 As OleDbCommand
        command1 = connection.CreateCommand()
        command1.CommandText = sql1
        Dim rdr1 As IDataReader

        command1.Parameters.Add("@projectID", OleDbType.VarChar)
        command1.Parameters("@projectID").Value = projectID

        Try
            connection.Open()
            rdr1 = command1.ExecuteReader()
            While rdr1.Read()
                name = rdr1("Name").ToString()

                If rdr1("ImportedFromCloud").ToString().Trim() = "True" Then
                    ddInvoiceName.Items.Add("Imported Contact")
                    ddInvoiceName.SelectedItem = "Imported Contact"
                End If

                If projectID = rdr1("ProjectID").ToString().Trim() Then
                    If rdr1("ImportedFromCloud").ToString().Trim() <> "True" Then
                        ddInvoiceName.SelectedItem = name
                    End If

                    txtInvoiceName.Text = name
                    txtInvoiceID.Text = rdr1("UniqueID").ToString().Trim()
                    txtInvoiceAddress.Text = rdr1("Address1").ToString().Trim()
                    txtInvoiceAddress2.Text = rdr1("Address2").ToString().Trim()
                    txtInvoiceState.Text = rdr1("State").ToString().Trim()
                    txtInvoiceCity.Text = rdr1("City").ToString().Trim()
                    txtInvoiceZip.Text = rdr1("Zip").ToString().Trim()
                    'txtInvoicePhone.Text = rdr1("Phone").ToString().Trim()
                End If
            End While
        Finally
            If rdr1 IsNot Nothing Then _
               rdr1.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try

        Dim sql2 = "SELECT TOP 1 Name, ProjectID, Address1, Address2, City, Zip, State, Phone, ContactType, UniqueID, ImportedFromCloud FROM OrderEntryContacts WHERE ContactType = 'Shipping' AND ProjectID = @projectID ORDER BY UniqueID DESC"
        Dim command2 As OleDbCommand
        command2 = connection.CreateCommand()
        command2.CommandText = sql2
        Dim rdr2 As IDataReader

        command2.Parameters.Add("@projectID", OleDbType.VarChar)
        command2.Parameters("@projectID").Value = projectID

        Try
            connection.Open()
            rdr2 = command2.ExecuteReader()
            While rdr2.Read()
                name = rdr2("Name").ToString()

                If rdr2("ImportedFromCloud").ToString().Trim() = "True" Then
                    ddShipName.Items.Add("Imported Contact")
                    ddShipName.SelectedItem = "Imported Contact"
                End If

                If projectID = rdr2("ProjectID").ToString().Trim() Then

                    If rdr2("ImportedFromCloud").ToString().Trim() <> "True" Then
                        ddShipName.SelectedItem = name
                    End If

                    txtShipName.Text = name
                    txtShipID.Text = rdr2("UniqueID").ToString().Trim()
                    txtShipAddress.Text = rdr2("Address1").ToString().Trim()
                    txtShipAddress2.Text = rdr2("Address2").ToString().Trim()
                    txtShipState.Text = rdr2("State").ToString().Trim()
                    txtShipCity.Text = rdr2("City").ToString().Trim()
                    txtShipZip.Text = rdr2("Zip").ToString().Trim()
                    'txtShipPhone.Text = rdr2("Phone").ToString().Trim()
                End If
            End While
        Finally
            If rdr2 IsNot Nothing Then _
               rdr2.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try

    End Sub

    Private Sub chkCopyInfo_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkCopyInfo.CheckedChanged
        If chkCopyInfo.Checked Then
            txtShipAddress.Text = txtInvoiceAddress.Text
            txtShipCity.Text = txtInvoiceCity.Text
            txtShipName.Text = txtInvoiceName.Text
            'txtShipPhone.Text = txtInvoicePhone.Text
            txtShipState.Text = txtInvoiceState.Text
            txtShipZip.Text = txtInvoiceZip.Text
            txtShipAddress2.Text = txtInvoiceAddress2.Text
        Else
            txtShipAddress.Text = ""
            txtShipCity.Text = ""
            txtShipName.Text = ""
            'txtShipPhone.Text = ""
            txtShipState.Text = ""
            txtShipZip.Text = ""
            txtShipAddress2.Text = ""
        End If
    End Sub

    Private Sub btnSaveInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveInvoice.Click
        Dim projectID As String = OpenedProject.ProjectId.ToString()

        Dim sql = ""
        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command As New OleDbCommand
        command = connection.CreateCommand()
        command.CommandText = sql
        command.CommandType = CommandType.Text

        sql = "INSERT INTO OrderEntryContacts (Name, Address1, Address2, City, State, Zip, Phone, ProjectID, ContactType) VALUES (@name, @address1, @address2, @city, @state, @zip, @phone, @projectID, 'Invoice')"

        connection = Common.CreateConnection(Common.ProjectsDbPath)
        command = connection.CreateCommand
        command.CommandText = sql
        command.CommandType = CommandType.Text
        command.Parameters.Add("@name", OleDbType.VarChar)
        command.Parameters("@name").Value = txtInvoiceName.Text.Trim()
        command.Parameters.Add("@address1", OleDbType.VarChar)
        command.Parameters("@address1").Value = txtInvoiceAddress.Text.Trim()
        command.Parameters.Add("@address2", OleDbType.VarChar)
        command.Parameters("@address2").Value = txtInvoiceAddress2.Text.Trim()
        command.Parameters.Add("@city", OleDbType.VarChar)
        command.Parameters("@city").Value = txtInvoiceCity.Text.Trim()
        command.Parameters.Add("@state", OleDbType.VarChar)
        command.Parameters("@state").Value = txtInvoiceState.Text.Trim()
        command.Parameters.Add("@zip", OleDbType.VarChar)
        command.Parameters("@zip").Value = txtInvoiceZip.Text.Trim()
        command.Parameters.Add("@phone", OleDbType.VarChar)
        command.Parameters("@phone").Value = "" 'txtInvoicePhone.Text.Trim()
        command.Parameters.Add("@projectID", OleDbType.VarChar)
        command.Parameters("@projectid").Value = OpenedProject.ProjectId.ToString()

        Try
            connection.Open()
            command.ExecuteNonQuery()
            connection.Dispose()
        Finally
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
            command.Parameters.Clear()
            command.Dispose()
        End Try

        MessageBox.Show("Contact has been saved to project and contact drop-down.")
    End Sub

    Private Sub btnSaveShipping_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveShipping.Click
        Dim projectID As String = OpenedProject.ProjectId.ToString()

        Dim sql = ""
        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command As New OleDbCommand
        command = connection.CreateCommand()
        command.CommandText = sql

        Dim rdr As IDataReader

        sql = "INSERT INTO OrderEntryContacts (Name, Address1, Address2, City, State, Zip, Phone, ProjectID, ContactType) VALUES (@name, @address1, @address2, @city, @state, @zip, @phone, @projectID, 'Shipping')"

        connection = Common.CreateConnection(Common.ProjectsDbPath)
        command = connection.CreateCommand
        command.CommandText = sql
        command.CommandType = CommandType.Text
        command.Parameters.Add("@name", OleDbType.VarChar)
        command.Parameters("@name").Value = txtShipName.Text.Trim()
        command.Parameters.Add("@address1", OleDbType.VarChar)
        command.Parameters("@address1").Value = txtShipAddress.Text.Trim()
        command.Parameters.Add("@address2", OleDbType.VarChar)
        command.Parameters("@address2").Value = txtShipAddress2.Text.Trim()
        command.Parameters.Add("@city", OleDbType.VarChar)
        command.Parameters("@city").Value = txtShipCity.Text.Trim()
        command.Parameters.Add("@state", OleDbType.VarChar)
        command.Parameters("@state").Value = txtShipState.Text.Trim()
        command.Parameters.Add("@zip", OleDbType.VarChar)
        command.Parameters("@zip").Value = txtShipZip.Text.Trim()
        command.Parameters.Add("@phone", OleDbType.VarChar)
        command.Parameters("@phone").Value = "" ' txtShipPhone.Text.Trim()
        command.Parameters.Add("@projectID", OleDbType.VarChar)
        command.Parameters("@projectid").Value = OpenedProject.ProjectId.ToString()

        Try
            connection.Open()
            command.ExecuteNonQuery()
            connection.Dispose()
        Finally
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
            command.Parameters.Clear()
            command.Dispose()
        End Try

        MessageBox.Show("Contact has been saved to project and contact drop-down.")
    End Sub

    Private Sub ddInvoiceName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddInvoiceName.SelectedIndexChanged
        Dim projectID As String = OpenedProject.ProjectId.ToString()
        Dim name As String = ddInvoiceName.Text

        Dim sql = "SELECT TOP 1 Name, ProjectID, Address1, Address2, City, Zip, State, Phone, ContactType, UniqueID FROM OrderEntryContacts WHERE Name = @name ORDER BY UniqueID DESC"
        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command As OleDbCommand = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        command.Parameters.Add("@name", OleDbType.VarChar)
        command.Parameters("@name").Value = name

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                name = rdr("Name").ToString()
                txtInvoiceName.Text = name
                txtInvoiceAddress.Text = rdr("Address1").ToString().Trim()
                txtInvoiceAddress2.Text = rdr("Address2").ToString().Trim()
                txtInvoiceState.Text = rdr("State").ToString().Trim()
                txtInvoiceCity.Text = rdr("City").ToString().Trim()
                txtInvoiceZip.Text = rdr("Zip").ToString().Trim()
                If rdr("UniqueID").ToString().Trim() <> "" Then
                    txtInvoiceID.Text = rdr("UniqueID").ToString().Trim()
                End If
                'txtInvoicePhone.Text = rdr("Phone").ToString().Trim()
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try

    End Sub

    Private Sub ddShipName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddShipName.SelectedIndexChanged
        Dim projectID As String = OpenedProject.ProjectId.ToString()
        Dim name As String = ddShipName.Text

        Dim sql = "SELECT TOP 1 Name, ProjectID, Address1, Address2, City, Zip, State, Phone, ContactType, UniqueID FROM OrderEntryContacts WHERE Name = @name ORDER BY UniqueID DESC"
        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command As OleDbCommand = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        command.Parameters.Add("@name", OleDbType.VarChar)
        command.Parameters("@name").Value = name

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                txtShipName.Text = name
                txtShipAddress.Text = rdr("Address1").ToString().Trim()
                txtShipAddress2.Text = rdr("Address2").ToString().Trim()
                txtShipState.Text = rdr("State").ToString().Trim()
                txtShipCity.Text = rdr("City").ToString().Trim()
                txtShipZip.Text = rdr("Zip").ToString().Trim()
                If rdr("UniqueID").ToString().Trim() <> "" Then
                    txtInvoiceID.Text = rdr("UniqueID").ToString().Trim()
                End If
                'txtShipPhone.Text = rdr("Phone").ToString().Trim()
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try
    End Sub
End Class