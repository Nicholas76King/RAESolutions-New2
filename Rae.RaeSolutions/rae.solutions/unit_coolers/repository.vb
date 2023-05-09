Option Strict Off

Imports rae.Io.Text
Imports rae.math.Calculate
Imports System.Data
Imports common = rae.RaeSolutions.dataacess.common

Namespace rae.solutions.unit_coolers

    Public Class repository

        'used by balance 'find unit coolers'. disregards capacity
        Function get_unit_coolers(ByVal suction As Double, ByVal refrigerant As String, ByVal series As String, doeModels As String) As unit_cooler_list
            series = convert_series(series)
            Dim indicator = convert_to_indicator(refrigerant) 'todo: change refrigerant format in unit coolers

            Dim sql = New query().unit_coolers.where _
                                 .series_like(series) _
                                 .and.refrigerant_is(indicator) _
                                 .and.suction_is_within_limits(suction) _
                                 .and.DOECompliant_is(doeModels) _
                                 .sql

            Dim unit_coolers = get_unit_coolers(Sql)
            Return unit_coolers
        End Function

        Function get_unit_coolers(ByVal input As selections.unit_cooler_input) As unit_cooler_list
            Dim refrigerant_indicator = convert_to_indicator(input.refrigerant)
            Dim series = If(input.series.toUpper = "ALL", "%", input.series)

            Dim sql = New query().unit_coolers.where _
                                 .series_like(series) _
                                 .and.refrigerant_is(refrigerant_indicator) _
                                 .and.defrost_type_is_available(input.defrost_type) _
                                 .and.suction_is_within_limits(input.suction) _
                                 .and.static_pressure_is(input.static_pressure) _
                                 .and.fan_quantity_is(input.fan_quantity) _
                                 .and.DOECompliant_is(input.DOEModels) _
                                 .sql

            Dim unit_coolers = get_unit_coolers(sql)
            Return unit_coolers
        End Function

        Function get_unit_cooler(ByVal model As String) As unit_cooler
            Dim sql = str("SELECT * FROM [{0}] WHERE [{1}]='{2}'", table.table_name, table.model, model)
            Return get_unit_coolers(sql)(0)
        End Function

        Function get_by_series(ByVal series As String) As unit_cooler_list
            Dim sql = str("SELECT * FROM [{0}] WHERE [{1}]='{2}'", table.table_name, table.series, series)
            Return get_unit_coolers(sql)
        End Function

        Function get_bocs() As unit_cooler_list
            Dim sql = str("SELECT * FROM [{0}] WHERE [{1}]='{2}'", table.table_name, table.series, "BOC")
            Return get_unit_coolers(sql)
        End Function

        Sub mark_as_not_in_pricing(ByVal model As String)
            Dim connection = create_connection()
            Dim command = connection.createCommand()
            command.commandText = str("UPDATE {0} SET {1}={2} WHERE {3}='{4}'", "Table1", "not_in_pricing", "True", table.model, model)
            Try
                connection.open()
                command.ExecuteNonQuery()
            Finally
                If connection.state <> connectionState.closed Then connection.close()
            End Try
        End Sub


        Public Function CheckDOE(model As String) As Boolean
            CheckDOE = False
            Dim connection = create_connection()
            Dim command = connection.createCommand()
            command.CommandText = "select DOECompliant from unit_coolers where Model = '" & model & "'"


            Dim rdr As IDataReader

            Try
                connection.Open()

                rdr = command.ExecuteReader
                If rdr.Read Then
                    If rdr("DOECOmpliant") = True Then CheckDOE = True
                End If
            Catch e As Exception
            Finally
                If rdr IsNot Nothing Then _
                   rdr.Close()
                If connection.State <> ConnectionState.Closed Then _
               connection.Close()
            End Try




        End Function



        Private Function GetUnitCoolerInfo(BaseModel As String, FPI As Integer, Fans As Integer, Model_BTUH As Integer, Rows As Integer, ApplicationTemp As String, Refrigerant As String, StaticPressure As Decimal, connection As IDbConnection) As unit_cooler.info_at_static_pressure

            'Dim connection = create_connection()
            Dim command = connection.CreateCommand()





            command.CommandText = "select * from UnitCapacities where Base_Model = '" & BaseModel & "' and FPI = " & FPI & " and Fans = " & Fans & " and Model_BTUH = " & Model_BTUH & " and [Rows] = " & Rows & " and ApplicationTemp = '" & ApplicationTemp & "' and Refrigerant = '" & Refrigerant & "' and StaticPressure = " & StaticPressure


            Dim Cap_Neg40 As Decimal = 0
            Dim Cap_Neg30 As Decimal = 0
            Dim Cap_Neg20 As Decimal = 0
            Dim Cap_Neg10 As Decimal = 0
            Dim Cap_0 As Decimal = 0
            Dim Cap_10 As Decimal = 0
            Dim Cap_20 As Decimal = 0
            Dim Cap_25 As Decimal = 0
            Dim Cap_35 As Decimal = 0
            Dim Cap_45 As Decimal = 0


            Dim rdr As IDataReader

            Try
                '    connection.Open()

                rdr = command.ExecuteReader
                If rdr.Read Then
                    If Not IsDBNull(rdr("Cap_Neg40")) Then Cap_Neg40 = rdr("Cap_Neg40")
                    If Not IsDBNull(rdr("Cap_Neg30")) Then Cap_Neg30 = rdr("Cap_Neg30")
                    If Not IsDBNull(rdr("Cap_Neg20")) Then Cap_Neg20 = rdr("Cap_Neg20")
                    If Not IsDBNull(rdr("Cap_Neg10")) Then Cap_Neg10 = rdr("Cap_Neg10")
                    If Not IsDBNull(rdr("Cap_0")) Then Cap_0 = rdr("Cap_0")
                    If Not IsDBNull(rdr("Cap_10")) Then Cap_10 = rdr("Cap_10")
                    If Not IsDBNull(rdr("Cap_20")) Then Cap_20 = rdr("Cap_20")
                    If Not IsDBNull(rdr("Cap_25")) Then Cap_25 = rdr("Cap_25")
                    If Not IsDBNull(rdr("Cap_35")) Then Cap_35 = rdr("Cap_35")
                    If Not IsDBNull(rdr("Cap_45")) Then Cap_45 = rdr("Cap_45")



                    GetUnitCoolerInfo = New unit_cooler.info_at_static_pressure(rdr("Refrigerant"), rdr("CFM"), rdr("FPM"), Cap_Neg40, Cap_Neg30, Cap_Neg20, Cap_Neg10, Cap_0, Cap_10, Cap_20, Cap_25, Cap_35, Cap_45)

                End If
            Catch e As Exception
            Finally
                If rdr IsNot Nothing Then _
                   rdr.Close()
                ' If connection.State <> ConnectionState.Closed Then _
                'connection.Close()
            End Try



        End Function


        Private Function get_unit_coolers(ByVal sql As String) As unit_cooler_list
            Dim connection = create_connection()
            Dim command = connection.CreateCommand()
            command.CommandText = sql

            Dim reader As IDataReader
            Dim unit_coolers = New unit_cooler_list()
            Try
                connection.Open()

                'return new rae.solutions.motors.repository().get_amps(motorPartNumber, voltage)


                reader = command.ExecuteReader
                While reader.Read
                    Dim uc = New unit_cooler()
                    uc.model = reader(table.model)
                    uc.model_capacity = reader(table.model_capacity)
                    uc.series = reader(table.series)
                    uc.fpi = reader(table.fpi)
                    uc.fan_quantity = reader(table.fan_quantity)
                    uc.refrigerant = convert_to_refrigerant(reader(table.refrigerant))
                    uc.cfm = reader(table.cfm)
                    uc.coil_height = reader(table.coil_height)
                    uc.coil_length = reader(table.coil_length)
                    uc.rows = reader(table.rows)
                    uc.fan_motor_part_number_115v_1ph = reader(table.fan_motor_part_number_115v_1ph).ToString
                    uc.fan_motor_part_number_230v_1ph = reader(table.fan_motor_part_number_230v_1ph).ToString
                    uc.fan_motor_part_number_460v_3ph = reader(table.fan_motor_part_number_230460v_3ph).ToString
                    uc.fan_motor_part_number_575v_3ph = reader(table.fan_motor_part_number_575v_3ph).ToString
                    uc.fan_motor_hp = reader(table.fan_motor_hp)
                    uc.rpm = reader(table.rpm)
                    uc.fan_motor_amps_at_115v_1ph = ConvertNull.ToDouble(reader(table.fan_motor_amps_at_115v_1ph))
                    uc.fan_motor_amps_at_230v_1ph = ConvertNull.ToDouble(reader(table.fan_motor_amps_at_230v_1ph))
                    uc.fan_motor_amps_at_208v_3ph = ConvertNull.ToDouble(reader(table.fan_motor_amps_at_208v_3ph))
                    uc.fan_motor_amps_at_230v_3ph = ConvertNull.ToDouble(reader(table.fan_motor_amps_at_230v_3ph))
                    uc.fan_motor_amps_at_460v_3ph = ConvertNull.ToDouble(reader(table.fan_motor_amps_at_460v_3ph))
                    uc.fan_motor_amps_at_575v_3ph = ConvertNull.ToDouble(reader(table.fan_motor_amps_at_575v_3ph))
                    uc.defrost_heater_watts = ConvertNull.ToDouble(reader(table.defrost_heater_watts))
                    uc.total_defrost_heater_amps_at_230v_1ph = ConvertNull.ToDouble(reader(table.total_defrost_heater_amps_at_230v_1ph))
                    uc.total_defrost_heater_amps_at_230v_3ph = ConvertNull.ToDouble(reader(table.total_defrost_heater_amps_at_230v_3ph))
                    uc.total_defrost_heater_amps_at_460v_3ph = ConvertNull.ToDouble(reader(table.total_defrost_heater_amps_at_460v_3ph))
                    uc.total_defrost_heater_amps_at_575v_3ph = ConvertNull.ToDouble(reader(table.total_defrost_heater_amps_at_575v_3ph))
                    uc.shipping_weight = reader(table.shipping_weight)
                    uc.operating_weight = reader(table.operating_weight)

                    ' If division = "CRI" Then
                    uc.shipping_weight *= 1.2
                    uc.shipping_weight = System.Math.Round(uc.shipping_weight)
                    uc.operating_weight *= 1.2
                    uc.operating_weight = System.Math.Round(uc.operating_weight)
                    '  End If



                    uc.liquid_line_connection_size = reader(table.liquid_line_connection_size)
                    uc.liquid_line_connection_quantity = reader(table.liquid_line_connection_quantity)
                    uc.suction_line_connection_size = reader(table.suction_line_connection_size)
                    uc.suction_line_connection_quantity = reader(table.suction_line_connection_quantity)
                    uc.hot_gas_connection_size = reader(table.hot_gas_line_connection_size)
                    uc.unit_length = reader(table.unit_length)
                    uc.unit_height = reader(table.unit_height)
                    uc.unit_width = reader(table.unit_width)
                    uc.refrigerant_charge = reader(table.refrigerant_charge)

                    '  uc.capacity_at_25_suction = reader(table.capacity_at_0_static_pressure)
                    uc.min_suction = ConvertNull.ToDouble(reader(table.min_suction))
                    uc.max_suction = ConvertNull.ToDouble(reader(table.max_suction))

                    uc.DOECompliant = reader(table.DOECompliant)


                    uc.Sound = ConvertNull.ToDouble(reader(table.Sound))
                    uc.AirThrow = ConvertNull.ToDouble(reader(table.AirThrow))

                    ' right here, we need to load the data from the new table.
                    'If ConvertNull.ToDouble(reader("Has050SP")) > 0 Then
                    Dim info0 As unit_cooler.info_at_static_pressure = GetUnitCoolerInfo(uc.series, uc.fpi, uc.fan_quantity, uc.model_capacity, uc.rows, reader("ApplicationTemp"), reader("Refrigerant"), 0, connection)
                    If Not info0 Is Nothing Then
                        uc.at.Add(0, info0)
                    Else
                        '   Beep()
                    End If
                    'End If


                    If ConvertNull.ToDouble(reader("Has025SP")) > 0 Then
                        Dim info025 As unit_cooler.info_at_static_pressure = GetUnitCoolerInfo(uc.series, uc.fpi, uc.fan_quantity, uc.model_capacity, uc.rows, reader("ApplicationTemp"), reader("Refrigerant"), 0.25, connection)
                        If Not info025 Is Nothing Then uc.at.Add(0.25, info025)
                    End If

                    If ConvertNull.ToDouble(reader("Has050SP")) > 0 Then
                        Dim info050 As unit_cooler.info_at_static_pressure = GetUnitCoolerInfo(uc.series, uc.fpi, uc.fan_quantity, uc.model_capacity, uc.rows, reader("ApplicationTemp"), reader("Refrigerant"), 0.5, connection)
                        If Not info050 Is Nothing Then uc.at.Add(0.5, info050)
                    End If

                    'If ConvertNull.ToDouble(reader(table.capacity_at_025_static_pressure)) > 0 Then
                    '    Dim info = New unit_cooler.info_at_static_pressure(uc.model) With {
                    '       .capacity = reader(table.capacity_at_025_static_pressure),
                    '       .cfm = reader(table.cfm_at_025_static_pressure),
                    '       .face_velocity = reader(table.face_velocity_at_025_static_pressure)}
                    '    uc.at.Add(0.25, info)
                    'End If

                    'If ConvertNull.ToDouble(reader(table.capacity_at_050_static_pressure)) > 0 Then
                    '    Dim info = New unit_cooler.info_at_static_pressure(uc.model) With {
                    '       .capacity = reader(table.capacity_at_050_static_pressure),
                    '       .cfm = reader(table.cfm_at_050_static_pressure),
                    '       .face_velocity = reader(table.face_velocity_at_050_static_pressure)}
                    '    uc.at.Add(0.5, info)
                    'End If

                    unit_coolers.Add(uc)
                End While
            Catch e As Exception
            Finally
                If reader IsNot Nothing Then _
                   reader.Close()
                If connection.State <> ConnectionState.Closed Then _
                   connection.Close()
            End Try

            Return unit_coolers
        End Function




     





        Private Function create_connection() As idbconnection
            Return rae.raesolutions.DataAccess.Common.CreateConnection(rae.raesolutions.dataaccess.Common.UnitCoolerDbPath)
        End Function

        Private Function convert_series(ByVal series As String) As String
            Return If(series = "ALL", "%", series)
        End Function

        Private Function convert_to_refrigerant(ByVal refrigerant_indicator As String) As refrigerant
            If refrigerant_indicator = "2" Then Return refrigerant.R22
            If refrigerant_indicator = "4" Then Return refrigerant.R404a
            If refrigerant_indicator = "7" Then Return refrigerant.R507

            If refrigerant_indicator = "7A" Then Return refrigerant.R407a
            If refrigerant_indicator = "7C" Then Return refrigerant.R407c
            If refrigerant_indicator = "7F" Then Return refrigerant.R407f
            If refrigerant_indicator = "8A" Then Return refrigerant.R448a
            If refrigerant_indicator = "9A" Then Return refrigerant.R449a
            'If refrigerant_indicator = "50" Then Return
            'If refrigerant_indicator = "2B" Then Return refrigerant.R50
            'If refrigerant_indicator = "10" Then Return refrigerant.R507
            'If refrigerant_indicator = "32" Then Return refrigerant.R507
            If refrigerant_indicator = "1A" Then Return refrigerant.R134a
            'If refrigerant_indicator = "ZE" Then Return refrigerant.R507
            'If refrigerant_indicator = "YF" Then Return refrigerant.R507


            Throw New Exception("The refrigerant indicator, " & refrigerant_indicator & ", cannot be deciphered.")
        End Function

        Private Function convert_to_indicator(ByVal refrigerant As String) As String
            Dim indicator As String
            refrigerant = refrigerant.ToLower

            If refrigerant Like "*22*" Then
                indicator = "2"
            ElseIf refrigerant Like "*404*" Then
                indicator = "4"
            ElseIf refrigerant Like "*507*" Then
                indicator = "7"
            ElseIf refrigerant Like "*407a*" Then
                indicator = "7A"
            ElseIf refrigerant Like "*407c*" Then
                indicator = "7C"
            ElseIf refrigerant Like "*407f*" Then
                indicator = "7F"
            ElseIf refrigerant Like "*448a*" Then
                indicator = "8A"
            ElseIf refrigerant Like "*449a*" Then
                indicator = "9A"
            ElseIf refrigerant Like "*450a*" Then
                indicator = "50"
            ElseIf refrigerant Like "*422b*" Then
                indicator = "2B"
            ElseIf refrigerant Like "*410a*" Then
                indicator = "10"
            ElseIf refrigerant Like "*32*" Then
                indicator = "32"
            ElseIf refrigerant Like "*134a*" Then
                indicator = "1A"
            ElseIf refrigerant Like "*1234ze*" Then
                indicator = "ZE"
            ElseIf refrigerant Like "*1234yf*" Then
                indicator = "YF"

            Else
                indicator = -1
            End If

            Return indicator
        End Function

    End Class

End Namespace