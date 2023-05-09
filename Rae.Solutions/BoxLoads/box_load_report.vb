Imports System.Data

Namespace CoolStuff

    Class box_load_report
        Private report As rae.reporting.beta.report

        Sub New(ByVal report_file_path As String, ByVal screen As frmboxloadcalc2, ByVal products_table As DataTable)
            report = New rae.reporting.beta.report(report_file_path)

            Dim text = New dictionary(Of String, String)

            Dim customer_id = screen.txt_customer_id.text
            'todo: dim customer = new contact(customer_id)
            Dim customer = DataAccess.Projects.ContactsDataAccess.Retrieve(customer_id)
            If customer.is_set AndAlso customer.company.id.has_value Then
                customer.company = DataAccess.Projects.CompaniesDa.Retrieve(customer.company.id.value)
            End If

            'todo: get_contact_list
            Dim customer_contact_info = New list(Of String)


            If Not customer Is Nothing Then
                With customer_contact_info

                    .Add(customer.Name.FirstThenLastName)
                    .Add(customer.Company.Name)
                    Dim address = customer.Company.Address
                    If address.Line1Exists Then .Add(address.Line1)
                    If address.Line2Exists Then .Add(address.Line2)
                    .Add(address.City & ", " & address.State & " " & If(address.Zip5.has_value, address.Zip5.value, ""))
                    .Add(If(customer.PhoneNum.ToString.is_set, "Phone: " & customer.PhoneNum.ToString, "") & "   " & _
                          If(customer.FaxNum.ToString.is_set, "Fax: " & customer.FaxNum.ToString, ""))
                    If customer.Email.IsValid Then .Add(customer.Email.ToString)
                End With

                report.set_list("customer_contact_info", customer_contact_info)

            End If

            Dim representative_id = screen.txt_representative_id.Text
            'todo: dim customer = new contact(customer_id)
            Dim representative = DataAccess.Projects.ContactsDataAccess.Retrieve(representative_id)
            If representative.is_set AndAlso representative.Company.Id.has_value Then
                representative.Company = DataAccess.Projects.CompaniesDa.Retrieve(representative.Company.Id.value)
            End If

            'todo: get_contact_list

            If Not representative Is Nothing Then

                Dim representative_contact_info = New List(Of String)
                With representative_contact_info
                    .Add(representative.Name.FirstThenLastName)
                    .Add(representative.Company.Name)
                    Dim address = representative.Company.Address
                    If address.Line1Exists Then .Add(address.Line1)
                    If address.Line2Exists Then .Add(address.Line2)
                    .Add(address.City & ", " & address.State & " " & If(address.Zip5.has_value, address.Zip5.value, ""))
                    .Add(If(representative.PhoneNum.ToString.is_set, "Phone: " & representative.PhoneNum.ToString, "") & "   " & _
                          If(representative.FaxNum.ToString.is_set, "Fax: " & representative.FaxNum.ToString, ""))
                    If representative.Email.IsValid Then .Add(representative.Email.ToString)
                End With
                report.set_list("representative_contact_info", representative_contact_info)

            End If

            Dim box_load = screen.BoxLoad

            text.Add("project_name", box_load.name)
            text.Add("project_description", box_load.Description)

            text.Add("transmission_load", box_load.TransTotal)
            text.Add("infiltration_load", box_load.SumInf)
            text.Add("product_load", box_load.SumProd)
            text.Add("miscellaneous_load", box_load.SumOther)
            text.Add("total_load_without_safety", box_load.SumTotal)
            text.Add("run_variance", box_load.RunVarTotal)
            text.Add("safety_variance", box_load.SafetyTotal)
            text.Add("runtime", box_load.RunVar)
            text.Add("total_load", box_load.LoadTotal)

            text.Add("room_temperature_db", box_load.RoomTemperature.F)
            text.Add("room_temperature_wb", box_load.RoomWetBulb.F)
            text.Add("ambient_db", box_load.Ambient.F)
            text.Add("ambient_wb", box_load.ExternalWb.F)


            text.Add("infiltration_volume", box_load.IVolume)
            text.Add("usage_factor", box_load.IFactor)
            text.Add("number_of_air_changes", box_load.IAirChg)
            text.Add("infiltrating_air_db", box_load.InfDb.F)
            text.Add("infiltrating_air_wb", box_load.InfWb.F)

            text.Add("lighting", box_load.WattL.append(" Watts Per Sq. Ft."))
            text.Add("motors", box_load.MotorHp.append(" Equivalent HP"))
            text.Add("personnel", box_load.People)
            text.Add("other", box_load.OtherType & " (" & box_load.OtherBtu & " BHU/24hr)")
            text.Add("other_type", box_load.OtherType)
            text.Add("fork_lifts", box_load.ForkLift)
            text.Add("dock_doors", box_load.DockDoors)

            Dim factor = If(screen.rdoKFactor.Checked, "K", "R")

            Dim table = New DataTable
            table.Columns.Add(" ")
            table.Columns.Add("Length")
            table.Columns.Add("Height")
            table.Columns.Add("Insulation")
            table.Columns.Add("Thick")
            table.Columns.Add(factor & " Factor")
            table.Columns.Add("Temp.")

            table.Rows.Add("Wall #1", box_load.Wall1, box_load.Height1, box_load.InsulW1, box_load.ThickW1, If(factor = "R", box_load.Rw1, box_load.KFactor1), box_load.ExternalWallTemperature1.F)
            table.Rows.Add("Wall #2", box_load.Wall2, box_load.Height2, box_load.InsulW2, box_load.ThickW2, If(factor = "R", box_load.Rw2, box_load.KFactor2), box_load.ExternalWallTemperature2.F)
            table.Rows.Add("Wall #3", box_load.Wall3, box_load.Height3, box_load.InsulW3, box_load.ThickW3, If(factor = "R", box_load.Rw3, box_load.KFactor3), box_load.ExternalWallTemperature3.F)
            table.Rows.Add("Wall #4", box_load.Wall4, box_load.Height4, box_load.InsulW4, box_load.ThickW4, If(factor = "R", box_load.Rw4, box_load.KFactor4), box_load.ExternalWallTemperature4.F)
            If Not box_load.rdoRectangle Then
                table.Rows.Add("Wall #5", box_load.Wall5, box_load.Height5, box_load.InsulW5, box_load.ThickW5, If(factor = "R", box_load.Rw5, box_load.KFactor5), box_load.ExternalWallTemperature5.F)
                table.Rows.Add("Wall #6", box_load.Wall6, box_load.Height6, box_load.InsulW6, box_load.ThickW6, If(factor = "R", box_load.Rw5, box_load.KFactor6), box_load.ExternalWallTemperature6.F)
            End If
            table.Rows.Add("Ceiling", "     Area", box_load.RoomArea, box_load.InsulC, box_load.ThickC, If(factor = "R", box_load.RwCeiling, box_load.KFactorC), box_load.CExtTemp.F)
            table.Rows.Add("Floor", "     Area", box_load.RoomArea, box_load.InsulF, box_load.ThickF, If(factor = "R", box_load.RwFloor, box_load.KFactorF), box_load.FExtTemp.F)


            Dim products = New List(Of String)
            For Each row In products_table.Rows
                products.Add("Description: " & row("Product") & "      Type: " & row("Type"))
                products.Add("Load (Lbs): " & row("CIbs") & "       Load Time (Hrs): " & row("CLoad") & "          Pulldown (Hrs): " & row("CPull"))
                products.Add("Entering Temp: " & row("CEnter") & "             Final Temp: " & row("CFinal"))
                products.Add("Specific Heat: " & row("CHeat") & "            Freeze Point: " & row("FreezePt"))
                products.Add("Latent Heat: " & row("FLatent") & "         Total Lbs Stored per Day: " & row("RIbs") & "     Respiration: " & row("RTot"))
                products.Add("Product Total: " & row("ProdTot"))
                products.Add(" ")
                products.Add(" ")
            Next

            report.set_list("product_data", products)
            report.set_table("transmission_table", table, New Rae.reporting.beta.box_load_table_factory)
            report.set_text(text)
            report.mark_as_final()
        End Sub

        Sub show()
            Try
                report.show()
            Catch ex As exception
                rae.ui.alert("Cannot open box load report. " & ex.message)
            End Try
        End Sub
    End Class

End Namespace
