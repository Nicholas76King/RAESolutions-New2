Imports Rae.Collections
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.solutions.drawings
Imports System.Data


Imports Rae.RaeSolutions.DataAccess
Imports System.Math
Imports System.IO
Imports Rae.RaeSolutions.Business.Entities.ProjectItem

Class unit_cooler_pricing_presenter : Inherits equipment_pricing_presenter_base

    Sub New(ByVal equip_screen As EquipmentForm, ByVal main_screen As MainForm)
        MyBase.New(equip_screen, main_screen)
    End Sub

    Sub load_data(ByVal unit As EquipmentItem)
        If unit.series Is Nothing OrElse String.IsNullOrEmpty(unit.model_without_series) Then Exit Sub

        Dim control = CType(equipView.specsControl, UnitCoolerSpecsControl)
        control.GetControlValues(unit)

        Dim unit_cooler = CType(unit, unit_cooler)

        Dim model = equipView.EquipmentSelector1.Series & equipView.EquipmentSelector1.Model
        Dim refrigerant = unit_cooler.refrigerant

        If refrigerant Is Nothing Then
            refrigerant = get_refrigerants(unit.series)(0)
        End If


        Dim model_with_refrigerant = New rae.solutions.unit_coolers.database_formatter().format_model(model, refrigerant)
        Dim unitCoolerTable = DataAccess.UnitCoolerDataAccess.RetrieveUnitCooler(model_with_refrigerant)


        If Not Integer.TryParse(unit_cooler.model_without_series(1).ToString, unit_cooler.fan_quantity) Then
            Exit Sub
        End If

        ' checks if unit cooler model was found
        If unitCoolerTable.Rows.Count > 0 Then
            ' sets object that will set control values
            With unitCoolerTable.Rows(0)
                unit_cooler.liquid_line_connection_quantity.set_to(.Item("LL_CONX_QTY"))
                unit_cooler.common_specs.Length.set_to(.Item("Unit_Length"))
                unit_cooler.common_specs.Width.set_to(.Item("Unit_Width"))
                unit_cooler.common_specs.Height.set_to(.Item("Unit_Height"))
                If Not IsDBNull(.Item("Shipping_Weight")) Then
                    unit_cooler.common_specs.ShippingWeight.set_to(.Item("Shipping_Weight"))

                    If unit_cooler.division = Business.Division.CRI Then
                        unit_cooler.common_specs.ShippingWeight.set_to(System.Math.Round(unit_cooler.common_specs.ShippingWeight.value * 1.2))
                    End If

                End If
                If Not IsDBNull(.Item("Operating_Weight")) Then
                    unit_cooler.common_specs.OperatingWeight.set_to(.Item("Operating_Weight"))


                    If unit_cooler.division = Business.Division.CRI Then
                        unit_cooler.common_specs.OperatingWeight.set_to(System.Math.Round(unit_cooler.common_specs.OperatingWeight.value * 1.2))
                    End If

                End If





                unit_cooler.coilLength = .Item("Coil_Length")
                unit_cooler.coilHeight = .Item("Coil_Height")
                unit_cooler.CFM = .Item("CFM")


            End With

        Else
        With unit_cooler.common_specs
            .Length.set_to_null()
            .Width.set_to_null()
            .Height.set_to_null()
            .ShippingWeight.set_to_null()
            .OperatingWeight.set_to_null()

            unit_cooler.coilLength = 0
            unit_cooler.coilHeight = 0
            unit_cooler.CFM = 0


        End With
        End If



        'If equipView.EquipmentSelector1.Model.EndsWith("E") Then
        '    Beep()
        'Else

        '    Beep()
        'End If


        control.SetControlValues(unit)
    End Sub

    Function get_refrigerants(ByVal series As String) As String()
        Dim refrigerants = New StringList()

        If String.IsNullOrEmpty(series) Then _
           Return refrigerants.ToArray()

        Select Case series
            Case "A", "AWSM", "BALV", "BOC", "UFH", "FV", "PFE", "WIBR" : refrigerants.Add("R22", "R404a", "R507", "R134a", "R407a", "R407c", "R407f", "R448a", "R449a")
                'Case "A", "BALV", "BOC", "FH", "FV", "PFE", "WIBR" : refrigerants.Add("R22", "R404a", "R507", "R134a", "R407a", "R407c", "R407f")
            Case "NIBR" : refrigerants.Add("R22")
                'Case "XBOC" : refrigerants.Add("R404a", "R507", "R134a", "R407a", "R407c", "R407f")
                '            Case "E" : refrigerants.Add("R404a", "R507", "R407a", "R407c", "R407f")
            Case "XBOC" : refrigerants.Add("R404a", "R507", "R134a", "R407a", "R407c", "R407f", "R448a", "R449a")
            Case "E" : refrigerants.Add("R404a", "R507", "R407a", "R407c", "R407f", "R448a", "R449a")
            Case Else : Throw New ArgumentException("The refrigerants for series '" & series & "' cannot be determined.")
        End Select
        Return refrigerants.ToArray()
    End Function


    Function get_fan_voltages(ByVal series As String, ByVal model As String) As String()
        Dim voltages = New StringList()

        model = series & model

        If model.EndsWith("E") Then
            model = model.Substring(0, model.Length - 2)
        ElseIf model.EndsWith("A") Then
            model = model.Substring(0, model.Length - 2)
        ElseIf model.EndsWith("HG") Then
            model = model.Substring(0, model.Length - 3)
        End If

        If String.IsNullOrEmpty(series) Then _
           Return voltages.ToArray()

        'Dim projectID As String = OpenedProject.ProjectId.ToString()

        Dim sql = "select v575_3, v460_3, v230_3, v208_3, v460_1, v230_1, v208_1, v115_1 from UnitDetails where ModelWithoutRefrigerant = '" & model & "'"
        Dim connection = Common.CreateConnection(Common.UnitCoolerDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Dim v575_3 As String = ""
        Dim v460_3 As String = ""
        Dim v230_3 As String = ""
        Dim v208_3 As String = ""
        Dim v460_1 As String = ""
        Dim v230_1 As String = ""
        Dim v208_1 As String = ""
        Dim v115_1 As String = ""

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                v575_3 = rdr("v575_3").ToString().ToUpper
                v460_3 = rdr("v460_3").ToString().ToUpper
                v230_3 = rdr("v230_3").ToString().ToUpper
                v208_3 = rdr("v208_3").ToString().ToUpper
                v460_1 = rdr("v460_1").ToString().ToUpper
                v230_1 = rdr("v230_1").ToString().ToUpper
                v208_1 = rdr("v208_1").ToString().ToUpper
                v115_1 = rdr("v115_1").ToString().ToUpper
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try

        If v575_3 = "TRUE" Then voltages.Add("575/3/60")
        If v460_3 = "TRUE" Then voltages.Add("460/3/60")
        If v230_3 = "TRUE" Then voltages.Add("230/3/60")
        If v208_3 = "TRUE" Then voltages.Add("208/3/60")
        If v460_1 = "TRUE" Then voltages.Add("460/1/60")
        If v230_1 = "TRUE" Then voltages.Add("230/1/60")
        If v208_1 = "TRUE" Then voltages.Add("208/1/60")
        If v115_1 = "TRUE" Then voltages.Add("115/1/60")

        'Select Case series
        '    Case "NIBR" : voltages.Add("230/1/60", "115/1/60")
        '    Case "WIBR" : voltages.Add("460/3/60", "230/3/60")
        '    Case "BALV" : voltages.Add("460/3/60", "230/3/60")
        '    Case "FH", "FV" : voltages.Add("230/1/60", "115/1/60")
        '    Case "A" : voltages.Add("575/3/60", "460/3/60", "230/3/60", "230/1/60", "115/1/60")
        '    Case "E" : voltages.Add("460/3/60", "230/3/60")
        '    Case "BOC"
        '        If model.Substring(1, 1) = "5" Then
        '            voltages.Add("460/3/60", "230/3/60")
        '        Else
        '            voltages.Add("575/3/60", "460/3/60", "230/3/60")
        '        End If
        '    Case "XBOC", "PFE" : voltages.Add("460/3/60", "230/3/60")
        '    Case Else : Throw New ArgumentException("The unit voltages for series '" & series & "' cannot be determined.")
        'End Select

        Return voltages.ToArray()
    End Function

    Function get_defrost_voltages(ByVal series As String, ByVal model As String) As String()
        Dim voltages = New StringList()

        If String.IsNullOrEmpty(series) Then Return voltages.ToArray()



        Select Case series
            Case "NIBR", "WIBR" : voltages.Add("460/3/60", "230/3/60")
            Case "BALV" : voltages.Add("460/3/60", "230/3/60", "230/1/60")
            Case "UFH" : voltages.Add("460/1/60", "230/3/60", "230/1/60")
            Case "FV" : voltages.Add("460/1/60", "230/1/60")
            Case "A", "AWSM" : voltages.Add("575/3/60", "460/3/60", "230/3/60", "230/1/60")
            Case "E" : voltages.Add("460/3/60", "230/3/60")
            Case "BOC"
                If model.Substring(1, 1) = "5" Then
                    voltages.Add("460/3/60", "230/3/60")
                Else
                    voltages.Add("575/3/60", "460/3/60", "230/3/60")
                End If
            Case "XBOC", "PFE" : voltages.Add("460/3/60", "230/3/60")
            Case Else : Throw New ArgumentException("The unit voltages for series '" & series & "' cannot be determined.")
        End Select


        If String.IsNullOrEmpty(model) OrElse model.EndsWith("E") Then
        Else ' wipe list if not electric defrost
            voltages.Clear()
        End If







        Return voltages.ToArray()
    End Function

    Protected Overrides Function create_order_write_up() As order_write_up_base
        Return New unit_cooler_order_write_up(equipview)
    End Function

    Protected Overrides Function create_submittal() As accessories_base
        Return New unit_cooler_accessories(equipView)
    End Function

    Sub show_submittal()
        Try
            Dim report = New unit_cooler_accessories(equipView)
            Dim junk As String = ""
            report.show(False, junk)
        Catch ex As exception
            rae.ui.alert("Cannot open submittal report. " & ex.message)
        End Try
    End Sub

    Sub show_order_write_up()
        Try
            '            equipView

            If Not equipView.FaceVelocityInRange() Then
                ' Me.tabEquipment.SelectedIndex = 0
                Exit Sub
            End If


            Dim returnTab As Integer
            If Not equipView.CheckObligatoryOptionsAndSpecs(returnTab) Then
                ' Me.tabEquipment.SelectedIndex = 1
                Exit Sub
            End If



            Dim report = New unit_cooler_order_write_up(equipView)
            Dim junk As String = ""
            report.show(False, junk)
        Catch ex As exception
            rae.ui.alert("Cannot open order write up. " & ex.message)
        End Try
    End Sub

End Class

Class unit_cooler_specs_grabber
    Private screen As unit_cooler_pricing_screen
    Private control As UnitCoolerSpecsControl

    Sub New(ByVal screen As unit_cooler_pricing_screen)
        Me.screen = screen
        control = screen.specsControl
    End Sub

    Function grab() As bag
        Dim bag As bag
        bag.capacity = control.txtUnitCapacity.Text
        bag.refrigerant = control.cboRefrigerant.SelectedItem
        bag.box_temperature = control.txtBoxTemp.Text.F
        bag.evaporating_temperature = control.txtEvaporatorTemp.Text.F
        bag.td = control.txtTempDifference.Text.F
        bag.liquid_temperature = control.txtLiquidTemp.Text.F
        bag.condensing_temperature = control.txtCondensingTemp.Text.F
        bag.fan_voltage = control.fanVoltageCombo.SelectedItem
        bag.defrost_voltage = control.defrostVoltageCombo.SelectedItem
        bag.control_voltage = control.cboControlVoltage.SelectedItem
        bag.tag = control.txtTag.Text
        bag.special_instructions = control.txtSpecialInstructions.Text

        Dim model = screen.equipment.model
        Dim refrigerant As String = control.cboRefrigerant.SelectedItem
        bag.model = New rae.solutions.unit_coolers _
           .Model_with_Refrigerant(model, refrigerant).to_string
        Return bag
    End Function

    Structure bag
        Public model, capacity, refrigerant, tag, special_instructions As String
        Public box_temperature, evaporating_temperature, td, liquid_temperature, condensing_temperature As String
        Public fan_voltage, defrost_voltage, control_voltage As String
    End Structure
End Class