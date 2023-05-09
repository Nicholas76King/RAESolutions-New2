Option Strict Off

Imports rae.RaeSolutions.DataAccess
Imports rae.Io.Text
Imports rae.solutions.condensing_units
Imports rae.solutions
Imports System.Data
Imports t1 = RAE.Solutions.condensing_units.Table
Imports rae.solutions.compressors

Namespace rae.solutions.condensing_units

    Public Class Repository : Implements I_Repository


        Function get_units_where_model_starts_with(ByVal start_of_model As String) As List(Of Condensing_Unit) _
        Implements I_Repository.get_units_where_model_starts_with
            Dim sql = New Query().condensing_units.where.model_starts_with(start_of_model) _
                                                  .and.refrigerant_is_not(refrigerant.R22) _
                                                  .order_by_model.sql
            Dim condensing_units = Me.get(sql)
            Return condensing_units
        End Function

        Function get_units(ByVal criteria As Criteria) As List(Of Condensing_Unit) _
        Implements I_Repository.get_units
            Dim query = New Query()

            query.condensing_units.where _
               .refrigerant_is(criteria.refrigerant) _
               .[and].division_is(criteria.division) _
               .[and].series_is(criteria.series) _
               .[and].DOECompliant(criteria.DOEModels)
            ' .[and].suction_is_in_range(criteria.suction_temp)

            If criteria.compressor_qty_description IsNot Nothing Then _
               query.[and].compressor_quantity_description_is(criteria.compressor_qty_description)

            If criteria.compressor_type IsNot Nothing Then _
               query.[and].compressor_type_is(criteria.compressor_type)

            Dim cus = Me.get(query.sql)

            Return cus
        End Function

        Function get_unit(ByVal model As String) As Condensing_Unit _
        Implements I_Repository.get_unit
            Dim query = New Query()
            Dim sql = query.condensing_units.where.model_is(model).sql

            Dim units = Me.get(sql)
            Return If(units.Count > 0, units(0), Nothing)
        End Function

        Function get_models(ByVal series As String, ByVal refrigerant As String, DOEFlag As String) As List(Of String) _
        Implements I_Repository.get_models
            Dim db = New RAE.Data.Access.db(Common.CondensingUnitDbPath)

            Dim sql As String = "select Model from Table5 where Model like '" & series & "%' "

            If Not String.IsNullOrEmpty(refrigerant) Then
                sql &= " and Refg_1 = '" & refrigerant & "'"
            End If

            If Not String.IsNullOrEmpty(DOEFlag) Then
                If DOEFlag.ToUpper = "YES" Then
                    sql &= " and DOECompliant = True"
                ElseIf DOEFlag.ToUpper = "NO" Then
                    '   sql &= " and DOECompliant = False"
                End If
            End If


            sql &= " order by model"



            'If Not String.IsNullOrEmpty(refrigerant) Then
            '    sql = Str("SELECT {0} FROM {1} WHERE {0} LIKE '{2}%' and {3} = '{4}' ORDER BY {0}",t1.model,t1.table_name, series,t1.refrigerant, refrigerant)
            'Else  'SELECT Model FROM Table5 WHERE Model LIKE 'LUO%' ORDER BY Model
            '    sql = Str("SELECT {0} FROM {1} WHERE {0} LIKE '{2}%' ORDER BY {0}",t1.model,t1.table_name, series)
            'End If


            Return db.get_strings(sql)
        End Function

        Function get_all() As IList(Of Condensing_Unit)
            Dim sql = New Query().condensing_units.sql
            Return Me.get(sql)
        End Function



        Public Function SelectFanCurveRPM(ByVal fanFileName As String, ByVal hp As Double) As Decimal

            If fanFileName.StartsWith("OVERRIDE") Then Return 0

            Dim con = create_connection_10A0()
            Dim cmd = con.CreateCommand()
            Dim sql As String

            If hp = 0 Then
                sql = "select RPM from Fans where FileName = '" & fanFileName & "' "
            Else
                sql = "select RPM from Fans where FileName = '" & fanFileName & "' and Horsepower = " & hp
            End If


            cmd.CommandText = sql
            Dim rdr As IDataReader


            Try

                con.Open()
                rdr = cmd.ExecuteReader()

                If rdr.Read Then  ' Technically, the same fan can exist in the DB with 2 different HP values.  As of writing this, that condition only exists for single speed fans and the 1 case has 1140 RPM on both (somehow)

                    SelectFanCurveRPM = rdr("Rpm")
                Else
                    MsgBox("A serious error has occurred.  No rpm information found for fan: " & fanFileName & " at " & hp & " hp. Please report this problem to the RAE I.T. department1.")
                End If


            Catch ex As Exception
                MsgBox("A serious error (exception) has occurred.  No rpm information found for fan: " & fanFileName & " at " & hp & " hp. Please report this problem to the RAE I.T. department1.")

            Finally
                If rdr IsNot Nothing Then _
                   rdr.Close()
                If con.State <> ConnectionState.Closed Then _
                   con.Close()
            End Try






        End Function



        Public Function IsFanVariableSpeed(ByVal fanFileName As String) As Boolean
            IsFanVariableSpeed = False
            'Return False
            If fanFileName.StartsWith("OVERRIDE") Then Return False

            Dim con = create_connection_10A0()
            Dim cmd = con.CreateCommand()
            Dim sql As String

            sql = "select IsVariableSpeed from Fans where FileName = '" & fanFileName & "' "


            cmd.CommandText = sql
            Dim rdr As IDataReader


            Try

                con.Open()
                rdr = cmd.ExecuteReader()

                If rdr.Read Then

                    IsFanVariableSpeed = rdr("IsVariableSpeed")
                Else
                    MsgBox("A serious error has occurred.  Could not determine if selected fan is variable speed. Please report this problem to the RAE I.T. department1.")
                End If


            Catch ex As Exception
                MsgBox("A serious error (exception) has occurred.  Could not determine if selected fan is variable speed. Please report this problem to the RAE I.T. department1.")

            Finally
                If rdr IsNot Nothing Then _
                   rdr.Close()
                If con.State <> ConnectionState.Closed Then _
                   con.Close()
            End Try






        End Function



        Public Function CheckDOE(ByVal model As String) As Boolean
            CheckDOE = False
            'Return False

            Dim con = create_connection()
            Dim cmd = con.CreateCommand()
            Dim sql As String

            sql = "select DOECompliant from table5 where model = '" & model & "' "


            cmd.CommandText = sql
            Dim rdr As IDataReader


            Try

                con.Open()
                rdr = cmd.ExecuteReader()

                If rdr.Read Then
                    If rdr("DOECompliant") = True Then CheckDOE = True
                End If


            Catch ex As Exception

            Finally
                If rdr IsNot Nothing Then _
                   rdr.Close()
                If con.State <> ConnectionState.Closed Then _
                   con.Close()
            End Try






        End Function


        Public Function CheckDOE(ByVal model As String, circuitCount As Integer, compressorMasterID1 As String, compressorQty1 As Integer, CoilID1 As String, FinHeight1 As Decimal, FinLength1 As Decimal, FPI1 As Decimal, Subcooling1 As Decimal, FanID1 As String, FanQty1 As Decimal, compressorMasterID2 As String, compressorQty2 As Integer, CoilID2 As String, FinHeight2 As Decimal, FinLength2 As Decimal, FPI2 As Decimal, Subcooling2 As Decimal, FanID2 As String, FanQty2 As Decimal) As Boolean
            CheckDOE = False
            'Return False

            Dim con = create_connection()
            Dim cmd = con.CreateCommand()
            Dim sql As String

            sql = "select DOECompliant from table5 where model = '" & model & "' "


            cmd.CommandText = sql
            Dim rdr As IDataReader


            Try

                con.Open()
                rdr = cmd.ExecuteReader()

                If rdr.Read Then
                    If rdr("DOECompliant") = True Then CheckDOE = True
                End If


            Catch ex As Exception

            Finally
                If rdr IsNot Nothing Then _
                   rdr.Close()
                If con.State <> ConnectionState.Closed Then _
                   con.Close()
            End Try






        End Function



        Private Sub GetDBCoil(ByVal CoilID As Integer, ByRef Coil1 As Coil)


            Dim con = create_connection()
            Dim cmd = con.CreateCommand()
            Dim sql As String = "select * from Coils where COilID = " & CoilID

            cmd.CommandText = sql
            Dim rdr As IDataReader


            Try

                con.Open()
                rdr = cmd.ExecuteReader()

                If rdr.Read Then

                    Coil1.capacity = 0  ' ???
                    Coil1.TubeDiameter = rdr("TubeDiameter")
                    Coil1.FPI = rdr("FPI")
                    Coil1.FinHeight = rdr("FinHeight")
                    Coil1.FinLength = rdr("FinLength")
                    Coil1.model = ""
                    Coil1.RowsDeep = rdr("Rows")
                    Coil1.UseDLLForPerformance = True


                    Coil1.CondFeeds = rdr("CondFeeds")
                    Coil1.CondPasses = rdr("CondPasses")
                    Coil1.SubCoolerFeeds = rdr("SubCoolerFeeds")
                    Coil1.SubCoolerPasses = rdr("SubCoolerPasses")
                    Coil1.FinSurface = rdr("FinSurface")
                    Coil1.FinMaterial = rdr("FinMaterial")
                    Coil1.FinThickness = rdr("FinThickness")
                    Coil1.TubeSurface = rdr("TubeSurface")
                    Coil1.TubeMaterial = rdr("TubeMaterial")
                    Coil1.TubeThickness = rdr("TubeThickness")


                Else
                    MsgBox("A serious error has occurred.  No coil found for coil id: " & CoilID & ". Please report this problem to the RAE I.T. department1.")
                End If


            Catch ex As Exception
                MsgBox("A serious error has occurred.  Coil (id: " & CoilID & ") could not be loaded. Please report this problem to the RAE I.T. department1.")

            Finally
                If rdr IsNot Nothing Then _
                   rdr.Close()
                If con.State <> ConnectionState.Closed Then _
                   con.Close()
            End Try









        End Sub

        Private Function [get](ByVal sql As String) As IList(Of Condensing_Unit)
            Dim con = create_connection()
            Dim cmd = con.CreateCommand()
            cmd.CommandText = sql
            Dim rdr As IDataReader

            Dim cus = New List(Of Condensing_Unit)

            Try
                con.Open()
                rdr = cmd.ExecuteReader()
                While rdr.Read()
                    Dim cu = New Condensing_Unit()
                    cu.max_capacity = rdr(t1.capacity_max)
                    cu.min_capacity = rdr(t1.capacity_min)

                    If String.IsNullOrEmpty(RAE.ConvertNull.ToString(rdr(t1.number_of_circuits))) Then
                        cu.number_of_circuits = 0
                    Else
                        cu.number_of_circuits = rdr(t1.number_of_circuits)
                    End If


                    '                    cu.constantReturnGasTemp = rdr(t1.ConstantReturnGasTemp)


                    'If cu.number_of_circuits > 0 Then
                    '    Dim circuit = New Circuit()
                    '    With circuit
                    '        .coil.capacity = ConvertNull.ToDouble(rdr(t1.capacity_1))
                    '        .coil.diameter = rdr(t1.coil_diameter_1)
                    '        .coil.fpi = rdr(t1.fpi_1)
                    '        .coil.height = rdr(t1.coil_height_1)
                    '        .coil.length = rdr(t1.coil_length_1)
                    '        '.coil.model = ""
                    '        .coil.model = rae.ConvertNull.ToString(rdr(t1.coil_model_1))
                    '        .coil.rows = rdr(t1.number_of_rows_1)
                    '        .coil.quantity = rdr(t1.coil_quantity_1)
                    '        .compressor_file_name = rdr(t1.compressor_file_1)
                    '        .compressor_model = rdr(t1.compressor_model_1)
                    '        .compressor_type = rdr(t1.compressor_type_1)
                    '        .compressor_quantity = rdr(t1.compressor_quantity_1)
                    '        .fan_diameter = rdr(t1.fan_diameter_1)
                    '        .hp = rdr(t1.fan_hp_1)
                    '        .fan_quantity = rdr(t1.fan_quantity_1)
                    '        .has_subcooling = rdr(t1.has_subcooling_1)
                    '        .num_refrigerant_circuits = rdr(t1.number_of_refrigerant_circuits_1)
                    '        .refrigerant = refrigerant1.parse(rdr(t1.refrigerant))
                    '        .subcooling = rdr(t1.subcooling_percent_1)
                    '    End With
                    '    cu.circuits.Add(circuit)

                    'End If
                    '  If cu.number_of_circuits > 1 Then

                    For j As Integer = 0 To cu.number_of_circuits - 1

                        Dim circuit = New Circuit()

                        ' eric121219

                        If j Mod 2 = 0 Then
                            With circuit
                                'If Not String.IsNullOrEmpty(ConvertNull.ToString(rdr(t1.CoilID_1))) Then
                                '    GetDBCoil(rdr(t1.CoilID_1), .coil)
                                '    .coil.quantity = rdr(t1.coil_quantity_1)
                                '    .subcooling = 0  ' I think this should be zero.  Check with Kyle/Jay
                                'Else
                                .coil.capacity = ConvertNull.ToDouble(rdr(t1.capacity_1))
                                .coil.TubeDiameter = rdr(t1.coil_diameter_1)


                                If .coil.TubeDiameter = 0.375 Then
                                    .coil.TubeSurface = "rifled"
                                Else
                                    .coil.TubeSurface = "smooth"
                                End If

                                .coil.FPI = rdr(t1.fpi_1)
                                .coil.FinHeight = rdr(t1.coil_height_1)
                                .coil.FinLength = rdr(t1.coil_length_1)
                                .coil.model = RAE.ConvertNull.ToString(rdr(t1.coil_model_1))
                                .coil.RowsDeep = rdr(t1.number_of_rows_1)
                                .coil.Quantity = rdr(t1.coil_quantity_1)
                                .subcooling = rdr(t1.subcooling_percent_1)
                                .coil.UseDLLForPerformance = False
                                '   End If




                                ' .compressor_file_name = rdr(t1.compressor_file_1)
                                .compressorMasterID = rdr(t1.CompressorMasterID1)
                                .compressor_type = rdr(t1.compressor_type_1)
                                .compressor_quantity = rdr(t1.compressor_quantity_1)
                                .fanID = rdr(t1.fanID_1)
                                .hp = rdr(t1.fan_hp_1)
                                .fan_quantity = rdr(t1.fan_quantity_1)
                                .fanOperatingRPM = rdr(t1.fanRPM_1)
                                .has_subcooling = rdr(t1.has_subcooling_1)
                                .num_refrigerant_circuits = rdr(t1.number_of_refrigerant_circuits_1)
                                .refrigerant = refrigerant.parse(rdr(t1.refrigerant))
                            End With
                        Else
                            With circuit

                                'If Not String.IsNullOrEmpty(ConvertNull.ToString(rdr(t1.CoilID_2))) Then
                                '    GetDBCoil(rdr(t1.CoilID_2), .coil)
                                '    .coil.Quantity = rdr(t1.coil_quantity_2)
                                '    .subcooling = 0  ' I think this should be zero.  Check with Kyle/Jay
                                'Else
                                .coil.capacity = ConvertNull.ToDouble(rdr(t1.capacity_2))
                                .coil.TubeDiameter = rdr(t1.coil_diameter_2)
                                .coil.FPI = rdr(t1.fpi_2)
                                .coil.FinHeight = rdr(t1.coil_height_2)
                                .coil.FinLength = rdr(t1.coil_length_2)
                                .coil.model = RAE.ConvertNull.ToString(rdr(t1.coil_model_2))
                                .coil.RowsDeep = rdr(t1.number_of_rows_2)
                                .coil.Quantity = rdr(t1.coil_quantity_2)
                                .subcooling = rdr(t1.subcooling_percent_2)
                                .coil.UseDLLForPerformance = False
                                '                                End If


                                ' .compressor_file_name = rdr(t1.compressor_file_2)
                                .compressorMasterID = rdr(t1.CompressorMasterID2)
                                .compressor_type = ConvertNull.ToString(rdr(t1.compressor_type_2), cu.circuits(0).compressor_type)
                                .compressor_quantity = rdr(t1.compressor_quantity_2)
                                .fanID = rdr(t1.fanID_2)
                                .hp = rdr(t1.fan_hp_2)
                                .fan_quantity = rdr(t1.fan_quantity_2)
                                .fanOperatingRPM = rdr(t1.fanRPM_2)

                                .has_subcooling = rdr(t1.has_subcooling_2)
                                ' TODO: decide how to handle nulls in database
                                .num_refrigerant_circuits = cu.circuits(0).num_refrigerant_circuits ' rdr(t1.NumRefrigerantCircuits2)
                                ' todo: probably can assume refrigerant is same as circuit 1 refrigerant
                                Dim refg = rdr(t1.refrigerant_2)
                                If refg Is DBNull.Value Then
                                    .refrigerant = cu.circuits(0).refrigerant
                                Else
                                    .refrigerant = Solutions.refrigerant.parse(refg)
                                End If
                            End With

                        End If

                        cu.circuits.Add(circuit)

                    Next

                    '   End If

                    cu.dimensions = ConvertNull.ToString(rdr(t1.dimensions))
                    cu.mca_208 = ConvertNull.ToDouble(rdr(t1.mca_208))
                    cu.mca_460 = ConvertNull.ToDouble(rdr(t1.mca_460))
                    cu.division = rdr(t1.division)
                    cu.model = rdr(t1.model)
                    cu.series = rdr(t1.series)


                    Dim SuccessFlag As Boolean = False

                    ' Dim cLSI As New CompressorLimits(cu.circuits(0).compressorMasterID, True, successFlag)
                    ' cLSI.GetMinMaxSuction(cu.minSuctionFromEnvelope, cu.maxSuctionFromEnvelope)

                    cu.minSuctionOfUnit = rdr(t1.minSuctionOfUnit)
                    cu.maxSuctionOfUnit = rdr(t1.maxSuctionOfUnit)

                    '   cu.maxSuctionOfUnit = cu.maxSuctionFromEnvelope  'rdr(t1.maxSuctionOfUnit)
                    '  cu.minSuctionOfUnit = cu.minSuctionFromEnvelope  'rdr(t1.minSuctionOfUnit)

                    cu.temperature_range = ConvertNull.ToString(rdr(t1.temperature_range))
                    cu.motor_part_number_single_phase = ConvertNull.ToString(rdr(t1.single_phase_motor_part_number))
                    cu.motor_part_number_3_phase230460 = ConvertNull.ToString(rdr(t1.three_phase_motor_part_number230460))


                    If Not String.IsNullOrEmpty(rdr(t1.three_phase_motor_part_number575).ToString) Then
                        cu.motor_part_number_3_phase575 = ConvertNull.ToString(rdr(t1.three_phase_motor_part_number575))
                    Else
                        cu.motor_part_number_3_phase575 = ""
                    End If



                    cu.operating_weight = ConvertNull.ToDouble(rdr(t1.operating_weight))
                    cu.shipping_weight = ConvertNull.ToDouble(rdr(t1.shipping_weight))

                    If cu.division = "CRI" Then
                        cu.shipping_weight *= 1.15
                        cu.shipping_weight = System.Math.Round(cu.shipping_weight)
                        cu.operating_weight *= 1.15
                        cu.operating_weight = System.Math.Round(cu.operating_weight)
                    End If

                    cu.compressor_quantity_description = rdr(t1.compressor_quantity_description)

                    cus.Add(cu)
                End While
            Finally
                If rdr IsNot Nothing Then _
                   rdr.Close()
                If con.State <> ConnectionState.Closed Then _
                   con.Close()
            End Try

            Return cus
        End Function

        Private Function create_connection() As IDbConnection
            Return Common.CreateConnection(Common.CondensingUnitDbPath)
        End Function


        Private Function create_connection_10A0() As IDbConnection
            Return Common.CreateConnection(Common.CondenserDbPath)
        End Function






        'Private Function [get](ByVal sql As String) As IList(Of Condensing_Unit)
        '    Dim con = create_connection()
        '    Dim cmd = con.createcommand()
        '    cmd.commandtext = sql
        '    Dim rdr As idatareader

        '    Dim cus = New list(Of Condensing_Unit)

        '    Try
        '        con.open()
        '        rdr = cmd.ExecuteReader()
        '        While rdr.Read()
        '            Dim cu = New Condensing_Unit()
        '            cu.max_capacity = rdr(t1.capacity_max)
        '            cu.min_capacity = rdr(t1.capacity_min)

        '            If String.IsNullOrEmpty(RAE.convertNull.ToString(rdr(t1.number_of_circuits))) Then
        '                cu.number_of_circuits = 0
        '            Else
        '                cu.number_of_circuits = rdr(t1.number_of_circuits)
        '            End If

        '            If cu.number_of_circuits > 0 Then
        '                Dim circuit = New Circuit()
        '                With circuit
        '                    .coil.capacity = ConvertNull.ToDouble(rdr(t1.capacity_1))
        '                    .coil.diameter = rdr(t1.coil_diameter_1)
        '                    .coil.fpi = rdr(t1.fpi_1)
        '                    .coil.height = rdr(t1.coil_height_1)
        '                    .coil.length = rdr(t1.coil_length_1)
        '                    '.coil.model = ""
        '                    .coil.model = rae.ConvertNull.ToString(rdr(t1.coil_model_1))
        '                    .coil.rows = rdr(t1.number_of_rows_1)
        '                    .coil.quantity = rdr(t1.coil_quantity_1)
        '                    .compressor_file_name = rdr(t1.compressor_file_1)
        '                    .compressor_model = rdr(t1.compressor_model_1)
        '                    .compressor_type = rdr(t1.compressor_type_1)
        '                    .compressor_quantity = rdr(t1.compressor_quantity_1)
        '                    .fan_diameter = rdr(t1.fan_diameter_1)
        '                    .hp = rdr(t1.fan_hp_1)
        '                    .fan_quantity = rdr(t1.fan_quantity_1)
        '                    .has_subcooling = rdr(t1.has_subcooling_1)
        '                    .num_refrigerant_circuits = rdr(t1.number_of_refrigerant_circuits_1)
        '                    .refrigerant = refrigerant1.parse(rdr(t1.refrigerant))
        '                    .subcooling = rdr(t1.subcooling_percent_1)
        '                End With
        '                cu.circuits.Add(circuit)

        '            End If
        '            If cu.number_of_circuits > 1 Then
        '                Dim circuit = New Circuit()
        '                With circuit
        '                    .coil.capacity = ConvertNull.ToDouble(rdr(t1.capacity_2))
        '                    .coil.diameter = rdr(t1.coil_diameter_2)
        '                    .coil.fpi = rdr(t1.fpi_2)
        '                    .coil.height = rdr(t1.coil_height_2)
        '                    .coil.length = rdr(t1.coil_length_2)
        '                    .coil.model = "" 'rdr(t1.coil_model_2)
        '                    .coil.rows = rdr(t1.number_of_rows_2)
        '                    .coil.quantity = rdr(t1.coil_quantity_2)
        '                    .compressor_file_name = rdr(t1.compressor_file_2)
        '                    .compressor_model = rdr(t1.compressor_model_2)
        '                    .compressor_type = ConvertNull.ToString(rdr(t1.compressor_type_2), cu.circuits(0).compressor_type)
        '                    .compressor_quantity = rdr(t1.compressor_quantity_2)
        '                    .fan_diameter = rdr(t1.fan_diameter_2)
        '                    .hp = rdr(t1.fan_hp_2)
        '                    .fan_quantity = rdr(t1.fan_quantity_2)
        '                    .has_subcooling = rdr(t1.has_subcooling_2)
        '                    ' TODO: decide how to handle nulls in database
        '                    .num_refrigerant_circuits = cu.circuits(0).num_refrigerant_circuits ' rdr(t1.NumRefrigerantCircuits2)
        '                    ' todo: probably can assume refrigerant is same as circuit 1 refrigerant
        '                    Dim refg = rdr(t1.refrigerant_2)
        '                    If refg Is DBNull.Value Then
        '                        .refrigerant = cu.circuits(0).refrigerant
        '                    Else
        '                        .refrigerant = solutions.refrigerant1.parse(refg)
        '                    End If
        '                    .subcooling = rdr(t1.subcooling_percent_2)
        '                End With
        '                cu.circuits.Add(circuit)
        '            End If

        '            cu.dimensions = ConvertNull.ToString(rdr(t1.dimensions))
        '            cu.mca_208 = ConvertNull.ToDouble(rdr(t1.mca_208))
        '            cu.mca_460 = ConvertNull.ToDouble(rdr(t1.mca_460))
        '            cu.division = rdr(t1.division)
        '            cu.model = rdr(t1.model)
        '            cu.series = rdr(t1.series)
        '            cu.max_suction = rdr(t1.suction_max)
        '            cu.min_suction = rdr(t1.suction_min)
        '            cu.temperature_range = ConvertNull.ToString(rdr(t1.temperature_range))
        '            cu.motor_part_number_single_phase = ConvertNull.ToString(rdr(t1.single_phase_motor_part_number))
        '            cu.motor_part_number_3_phase = ConvertNull.ToString(rdr(t1.three_phase_motor_part_number))
        '            cu.operating_weight = ConvertNull.ToDouble(rdr(t1.operating_weight))
        '            cu.shipping_weight = ConvertNull.ToDouble(rdr(t1.shipping_weight))
        '            cu.compressor_quantity_description = rdr(t1.compressor_quantity_description)

        '            cus.Add(cu)
        '        End While
        '    Finally
        '        If rdr IsNot Nothing Then _
        '           rdr.close()
        '        If con.state <> connectionstate.closed Then _
        '           con.close()
        '    End Try

        '    Return cus
        'End Function



    End Class

End Namespace