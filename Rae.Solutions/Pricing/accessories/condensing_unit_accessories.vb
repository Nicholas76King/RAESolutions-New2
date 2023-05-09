Imports Rae.RaeSolutions.DataAccess
Imports System.Data

Class condensing_unit_accessories : Inherits accessories_base

    Sub New(ByVal screen As EquipmentForm)
        MyBase.New(screen, reports.file_paths.condensing_unit_accessories_file_path)

        Dim model As String = screen.grabEquipment.model.ToString()

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

        Dim cu_bag = New condensing_unit_grabber(screen).grab
        text.Add("refrigerant", cu_bag.refrigerant)

        Dim temp As Decimal
        If Decimal.TryParse(stdCharge, temp) Then
            stdCharge = System.Math.Round(temp, 1).ToString()
        End If

        Dim temp1 As Decimal
        If Decimal.TryParse(floodCharge, temp1) Then
            floodCharge = System.Math.Round(temp1, 1).ToString()
        End If

        If stdCharge <> "" Or floodCharge <> "" Then
            text.Add("stdCharge", stdCharge & " lbs per compressor circuit *")
            text.Add("floodCharge", floodCharge & " lbs per compressor circuit *")
        Else
            text.Add("stdCharge", "Not Avail.")
            text.Add("floodCharge", "Not Avail.")
        End If


        If model.Contains("LUI") Or model.Contains("LUO") Or model.Contains("BLU") Then
            text.Add("footNote", "* Based on 50 ft. of equivalent refrigerant line piping (does not include the evaporator).")
        Else
            text.Add("footNote", "* Based on 100 ft. of equivalent refrigerant line piping (does not include the evaporator).")
        End If


        text.Add("ambient", cu_bag.ambient)
        text.Add("suction", cu_bag.suction)
        text.Add("evaporating_temperature", cu_bag.evaporating_temperature)


        Dim capacity1 As String
        If Not String.IsNullOrEmpty(cu_bag.capacity_1) Then
            capacity1 = FormatNumber(cu_bag.capacity_1, 0, , , TriState.True)
        Else
            capacity1 = ""
        End If

        Dim capacity2 As String
        If Not String.IsNullOrEmpty(cu_bag.capacity_2) Then
            capacity2 = FormatNumber(cu_bag.capacity_2, 0, , , TriState.True)
        Else
            capacity2 = ""
        End If


        text.Add("capacity_1", capacity1)
        text.Add("capacity_2", capacity2)




        text.Add("capacity_units", cu_bag.capacity_units)
        text.Add("dimensions", cu_bag.dimensions)
        text.Add("operating_weight", cu_bag.operating_weight)
        text.Add("shipping_weight", cu_bag.shipping_weight)
        text.Add("unit_voltage", cu_bag.unit_voltage)
        text.Add("control_voltage", cu_bag.control_voltage)
        text.Add("rla", cu_bag.rla)
        text.Add("mca", cu_bag.mca)
    End Sub

End Class