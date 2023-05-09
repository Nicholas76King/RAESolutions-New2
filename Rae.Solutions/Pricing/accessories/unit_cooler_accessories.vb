Imports rae.RaeSolutions.DataAccess
Imports System.Data

Class unit_cooler_accessories : Inherits accessories_base
    Sub New(ByVal screen As EquipmentForm)
        MyBase.New(screen, reports.file_paths.unit_cooler_accessories_file_path)

        Dim equipment_bag = New equipment_grabber(screen).grab
        Dim uc_bag = New unit_cooler_specs_grabber(screen).grab

        text.Remove("model")
        Dim model As String
        If equipment_bag.custom_model.is_not_set Then
            model = uc_bag.model
        Else
            model = equipment_bag.custom_model & " (Base:" & uc_bag.model & ")"
        End If

        Dim modelArr() As String = model.Split("-")
        If modelArr(0).EndsWith("0") Then

            Dim value As String = uc_bag.refrigerant
            Select Case value
                Case "R22"
                    value = "2"
                Case "R404a"
                    value = "4"
                Case "R507a"
                    value = "7"
                Case "R134a"
                    value = "1A"
                Case "R407a"
                    value = "7A"
                Case "R407c"
                    value = "7C"
                Case "R407f"
                    value = "7F"
                Case "R448a"
                    value = "8A"
                Case "R449a"
                    value = "9A"
                Case Else
                    value = "0"
            End Select
            modelArr(0) = modelArr(0).Replace("0", value)
        End If

        model = String.Join("-", modelArr)

        text.Add("model", model)

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


        text.Add("capacity", uc_bag.capacity.format_number("#,#"))
        text.Add("refrigerant", uc_bag.refrigerant)

        If stdCharge <> "" Then
            text.Add("stdCharge", stdCharge & " lbs")
        Else
            text.Add("stdCharge", "Not Avail.")
        End If

        text.Add("box_temperature", uc_bag.box_temperature)
        text.Add("evaporating_temperature", uc_bag.evaporating_temperature)
        text.Add("td", uc_bag.td)
        text.Add("liquid_temperature", uc_bag.liquid_temperature)
        text.Add("condensing_temperature", uc_bag.condensing_temperature)
        text.Add("fan_voltage", uc_bag.fan_voltage)
        text.Add("defrost_voltage", uc_bag.defrost_voltage)
        text.Add("control_voltage", uc_bag.control_voltage)
    End Sub
End Class