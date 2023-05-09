Imports Rae.RaeSolutions.DataAccess
Imports System.Data

Class condenser_accessories : Inherits accessories_base

    Sub New(ByVal screen As condenser_pricing_screen)
        MyBase.New(screen, reports.file_paths.condenser_accessories_file_path)

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

        Dim condenser_bag = New condenser_grabber(screen).grab
        text.Add("refrigerant", condenser_bag.refrigerant)
        If stdCharge <> "" Or floodCharge <> "" Then
            text.Add("stdCharge", stdCharge & " lbs")
            text.Add("floodCharge", floodCharge & " lbs")
        Else
            text.Add("stdCharge", "Not Avail.")
            text.Add("floodCharge", "Not Avail.")
        End If
        text.Add("ambient", condenser_bag.ambient)
        text.Add("td", condenser_bag.td)
        text.Add("unit_voltage", condenser_bag.unit_voltage)
        text.Add("control_voltage", condenser_bag.control_voltage)
        text.Add("total_heat_rejection_1", condenser_bag.total_heat_rejection_1.format_number("#,#").BTUH)
        text.Add("total_heat_rejection_2_label", condenser_bag.total_heat_rejection_2_label)
        text.Add("total_heat_rejection_2", condenser_bag.total_heat_rejection_2.format_number("#,#").BTUH)
        text.Add("total_heat_rejection_3_label", condenser_bag.total_heat_rejection_3_label)
        text.Add("total_heat_rejection_3", condenser_bag.total_heat_rejection_3.format_number("#,#").BTUH)
        text.Add("total_heat_rejection_4_label", condenser_bag.total_heat_rejection_4_label)
        text.Add("total_heat_rejection_4", condenser_bag.total_heat_rejection_4.format_number("#,#").BTUH)
    End Sub

End Class