Option Strict Off

Imports rae.Io.Text
Imports System.Data
Imports System.Data.ConnectionState
Imports ct1 = RAE.Solutions.compressors.compressor_table
Imports cot = rae.solutions.compressors.coefficients_table
'Imports ta = rae.solutions.compressors.compressor_amps_table
'Imports c10 = rae.solutions.compressors.coefficients_10_table
'Imports c5 = rae.solutions.compressors.coefficients_5_table
Imports ed1 = RAE.Solutions.compressors.ElectricalTable

Imports rae.solutions
Imports System.Collections

Namespace rae.solutions.compressors

    Public Class compressor_repository : Implements i_compressor_repository

        'Function isCompressorTandem(ByVal MasterID As String) As Boolean

        '    isCompressorTandem = False

        '    Dim connectionT = create_connection()
        '    Dim commandT = connectionT.CreateCommand()
        '    Dim sqlT = "select TandemID1, TandemID2, TandemID3 from Electrical where MasterID = '" & file_name & "' "
        '    Dim rdrT As IDataReader

        '    Try

        '        connectionT.Open()
        '        commandT.CommandText = sqlT
        '        rdrT = commandT.ExecuteReader()
        '        If rdrT.Read() Then

        '        End If

        '    Finally
        '        If connectionT.State <> ConnectionState.Closed Then connectionT.Close()
        '    End Try


        'End Function



        Function GetCompressorOverrideAmps(ByVal MasterIDPrefix As String, ByVal voltage As Integer, ByVal appliesTo As String, ByVal phase As Integer) As Double
            ' Return 0   6/14/2016
            If String.IsNullOrEmpty(MasterIDPrefix) Then Return 0

            Dim chars() As Char = MasterIDPrefix.ToCharArray
            If chars.Length < 10 Then Return 0


            Dim connection = create_connection()
            Dim command = connection.CreateCommand()
            'Dim sql = "select [RLA] * (" & voltage & " / [Voltage]) as RLAOut from ElectricalOverride where "
            'sql &= "(mid([masteridprefix],1,1) = '" & chars(0) & "' or mid([masteridprefix],1,1) = '^' ) and "
            'sql &= "(mid([masteridprefix],2,1) = '" & chars(1) & "' or mid([masteridprefix],2,1) = '^' ) and "
            'sql &= "(mid([masteridprefix],3,1) = '" & chars(2) & "' or mid([masteridprefix],3,1) = '^' ) and "
            'sql &= "(mid([masteridprefix],4,1) = '" & chars(3) & "' or mid([masteridprefix],4,1) = '^' ) and "
            'sql &= "(mid([masteridprefix],5,1) = '" & chars(4) & "' or mid([masteridprefix],5,1) = '^' ) and "
            'sql &= "(mid([masteridprefix],6,1) = '" & chars(5) & "' or mid([masteridprefix],6,1) = '^' ) and "
            'sql &= "(mid([masteridprefix],7,1) = '" & chars(6) & "' or mid([masteridprefix],7,1) = '^' ) and "
            'sql &= "(mid([masteridprefix],8,1) = '" & chars(7) & "' or mid([masteridprefix],8,1) = '^' ) and "
            'sql &= "(mid([masteridprefix],9,1) = '" & chars(8) & "' or mid([masteridprefix],9,1) = '^' ) and "
            'sql &= "(mid([masteridprefix],10,1) = '" & chars(9) & "' or mid([masteridprefix],10,1) = '^' ) and "
            'sql &= "  AppliesTo = '" & appliesTo & "'"

            Dim sql = "select [RLA] * ([Voltage] / " & voltage & ") as RLAOut from ElectricalOverrideBuilt where "
            sql &= "[masterid] = '" & MasterIDPrefix & "'  and "
            sql &= "  AppliesTo = '" & appliesTo & "'"
            sql &= " and Phase = " & phase & ""




            Dim amps As Double
            Try
                connection.Open()
                command.CommandText = sql

                amps = CDbl(command.ExecuteScalar())

            Catch ex As Exception
                Return 0

            Finally
                If connection.State <> ConnectionState.Closed Then _
                   connection.Close()
            End Try


            Return amps


        End Function






        Function get_compressor_amps(ByVal file_name As String, ByVal unit_type As String, _
                                     ByVal voltage As Integer, ByVal phase As Integer, ByVal hertz As Integer, ByVal division As String) As Double _
        Implements i_compressor_repository.get_compressor_amps


            Dim ampOverrideID As String = ""

            If unit_type.ToUpper = "CONDENSINGUNIT" AndAlso division.ToUpper = "CENTURY" Then ampOverrideID = "CenturyCU"

            Dim tAmps As Double = 0

            If Not file_name Is Nothing AndAlso Not String.IsNullOrEmpty(file_name) AndAlso Not String.IsNullOrEmpty(ampOverrideID) Then
                tAmps = GetCompressorOverrideAmps(file_name, voltage, ampOverrideID, phase)
            End If


            If tAmps > 0 Then Return tAmps

            Dim connection = create_connection()
            Dim command = connection.CreateCommand()
            Dim sql = "select RLA from Electrical where MasterID = '" & file_name & "' and voltage = '" & voltage & "' and Phase = " & phase & " and Frequency = " & hertz  ' & " and [Type] = '" & unit_type & "'"

            Dim amps As Double
            Try
                connection.Open()
                command.CommandText = sql
                amps = CDbl(command.ExecuteScalar())



            Finally
                If connection.State <> ConnectionState.Closed Then _
                   connection.Close()
            End Try

            'If amps = 0 AndAlso unit_type.ToUpper <> "CONDENSINGUNIT" Then  ' If no amps exists for equipment type, just use the condensing unit amps.
            '    amps = get_compressor_amps(file_name, "CondensingUnit", voltage, phase, hertz)
            'End If

            Return amps


        End Function

        Private Sub GetElectricalData(ByVal masterID As String, ByVal voltage As Integer, ByRef mcc As Decimal, ByRef rla As Decimal, ByVal multiplier As Decimal)
            Static ElecticalCache As New Hashtable


            Dim key As String = masterID & "_" & voltage
            If ElecticalCache.ContainsKey(key) Then
                Dim value1 As String = ElecticalCache(key)
                mcc = value1.Split("_")(0)
                rla = value1.Split("_")(1)
                '   multiplier = value1.Split("_")(2)
                Exit Sub
            End If




            Dim con = create_connection()
            Dim cmd = con.CreateCommand()

            Dim sql As String

            sql = "select MCC, RLA from Electrical where Frequency = 60 and Phase = 3 and MasterID = '" & masterID & "' and voltage = '" & voltage & "'"
            Dim foundRecord As Boolean = False


            cmd.CommandText = sql
            Dim rdr As IDataReader

            Try
                con.Open()
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    mcc = rdr("MCC") * multiplier
                    rla = rdr("RLA") * multiplier
                    foundRecord = True

                    Dim cacheValue As String = mcc & "_" & rla
                    ElecticalCache.Add(key, cacheValue)


                End If

            Finally
                If rdr IsNot Nothing Then _
                   rdr.Close()
                If con.State <> ConnectionState.Closed Then _
                   con.Close()
            End Try

            If Not foundRecord AndAlso multiplier = 1 Then
                If voltage = 460 Then
                    GetElectricalData(masterID, 230, mcc, rla, 2)
                ElseIf voltage = 230 Then
                    GetElectricalData(masterID, 230, mcc, rla, 0.5)
                End If
            End If


        End Sub


        Function get_compressor(ByVal masterID As String, ByVal refrigerant As refrigerant, ByVal voltage As Integer, ByVal model_type As String, ByVal constantReturnGasTemp As String) As compressor _
        Implements i_compressor_repository.get_compressor

20:
            Dim recordFound As Boolean = False

            Dim c As New compressor
            Dim con = create_connection()
            Dim cmd = con.CreateCommand()




            '    Dim oldMethodFlag As Boolean
            Dim sql As String


            'sql = "select " & ct.table_name & "." & ct.MasterID & ", " & ct.ManufacturerModelNumber & ", " & ct.CompressorType & ", " & ct.Refrigerant & ", " & ct.Manufacturer & ", " & ct.table_name & "." & ct.DemandCoolingLimit
            'sql &= ", " & ct.Horsepower & ", " & cot.table_name & "." & cot.CurveVoltage & " as CurveVoltage, " & ct.TemperatureRange & ", " & ct.LimitID & ", " & ed.table_name & "." & ed.Voltage & ", " & ed.table_name & "." & ed.MCC & ", " & ed.table_name & "." & ed.RLA
            'sql &= " from (" & ct.table_name & " "
            'sql &= " inner join " & cot.table_name & " on " & cot.table_name & "." & cot.MasterID & " = " & ct.table_name & "." & ct.MasterID & " ) "
            'sql &= " inner join " & ed.table_name & " on " & ed.table_name & "." & ed.MasterID & " = " & ct.table_name & "." & ct.MasterID
            'sql &= " where " & ct.table_name & "." & ct.MasterID & " = '" & masterID & "' AND " & ct.Refrigerant & " = '" & refrigerant.value & "' AND " & ed.table_name & "." & ed.Frequency & " = 60 " & " AND " & ed.table_name & "." & ed.Voltage & " = '" & voltage & "'"


            sql = "select " & ct1.table_name & "." & ct1.MasterID & ", " & ct1.ManufacturerModelNumber & ", " & ct1.CompressorType & ", " & ct1.Refrigerant & ", " & ct1.Manufacturer & ", " & ct1.table_name & "." & ct1.DemandCoolingLimit
            sql &= ", " & ct1.Horsepower & ", " & cot.table_name & "." & cot.CurveVoltage & " as CurveVoltage, " & ct1.TemperatureRange & ", " & ct1.LimitID '& ", " & ed.table_name & "." & ed.Voltage & ", " & ed.table_name & "." & ed.MCC & ", " & ed.table_name & "." & ed.RLA
            sql &= " from (" & ct1.table_name & " "
            sql &= " inner join " & cot.table_name & " on " & cot.table_name & "." & cot.MasterID & " = " & ct1.table_name & "." & ct1.MasterID & " ) "
            sql &= " where " & ct1.table_name & "." & ct1.MasterID & " = '" & masterID & "' AND " & ct1.Refrigerant & " = '" & refrigerant.value & "' " ' AND " & ed.table_name & "." & ed.Frequency & " = 60 " & " AND " & ed.table_name & "." & ed.Voltage & " = '" & voltage & "'"




            cmd.CommandText = sql
            Dim rdr As IDataReader

            Try
                con.Open()
                rdr = cmd.ExecuteReader()
                While rdr.Read()
                    c = get_compressor_data_from_all_data_table(rdr, voltage, constantReturnGasTemp)

                    If c Is Nothing Then
                        If rdr IsNot Nothing Then _
                           rdr.Close()
                        If con.State <> ConnectionState.Closed Then _
                           con.Close()
                        GoTo 20

                    End If




                    GetElectricalData(masterID, voltage, c.mcc, c.rla, 1)


                    set_coefficients_for(c, refrigerant, voltage, model_type, constantReturnGasTemp)
                    recordFound = True
                    Exit While ' there is some duplicate data in table, no need to search any more once a match is found
                End While
            Finally
                If rdr IsNot Nothing Then _
                   rdr.Close()
                If con.State <> ConnectionState.Closed Then _
                   con.Close()
            End Try


            If recordFound = False AndAlso (model_type = "AirCooledChiller" OrElse model_type = "EvaporativeCondenserChiller") Then
                c = get_compressor(masterID, refrigerant, voltage, "DontCare", constantReturnGasTemp)
            End If


            '     DateHash(specialKey) = c
            Return c

            '    End If

        End Function




        Function getCompressorLimitID(ByVal masterID As String) As String


            Dim c As New compressor
            Dim con = create_connection()
            Dim cmd = con.CreateCommand()


            getCompressorLimitID = ""

            '    Dim oldMethodFlag As Boolean
            Dim sql As String


            sql = "select LimitID from Master where MasterID = '" & masterID & "'"



            cmd.CommandText = sql
            Dim rdr As IDataReader

            Try
                con.Open()
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    getCompressorLimitID = rdr("LimitID")
                End If
            Finally
                If rdr IsNot Nothing Then _
                   rdr.Close()
                If con.State <> ConnectionState.Closed Then _
                   con.Close()
            End Try



            '    End If

        End Function




        Function get_compressors(ByVal refrigerant As refrigerant, ByVal voltage As Integer, ByVal suction As Double, ByVal model_type As String, ByVal overrideSafetyLimit As Boolean, ByVal constantReturnGasTemp As String) As List(Of compressor) _
        Implements i_compressor_repository.get_compressors
            Dim compressors = get_compressors(refrigerant, voltage, model_type, constantReturnGasTemp)

            get_compressors = New List(Of compressor)


            Static CompressorLimitCache As New Hashtable

            For Each c In compressors
                Dim cLSI As CompressorLimits

                If CompressorLimitCache.ContainsKey(c.limitID) Then
                    cLSI = CType(CompressorLimitCache(c.limitID), CompressorLimits)
                Else
                    Dim SuccessFlag As Boolean = False

                    cLSI = New CompressorLimits(c.limitID, False, successFlag)
                    CompressorLimitCache.Add(c.limitID, cLSI)
                End If

                If overrideSafetyLimit OrElse cLSI.Valid(suction) Then
                    get_compressors.Add(c)
                End If
            Next



            '   Return compressors.FindAll(Function(x) suction <= x.suction_max And suction >= x.suction_min)
        End Function





        Function get_compressors(ByVal refrigerant As refrigerant, ByVal voltage As Integer, ByVal model_type As String, ByVal constantReturnGasTemp As String) As List(Of compressor) _
        Implements i_compressor_repository.get_compressors
            Dim compressors_10 = getCompressors(refrigerant, voltage, model_type, constantReturnGasTemp)
            'Dim compressors_5 = get_5_coefficient_compressors(refrigerant)

            Dim compressors = New List(Of compressor)
            compressors.AddRange(compressors_10)
            'compressors.AddRange(compressors_5)

            Return compressors
        End Function

        ''context: reps can only run 30A2, R134a units with SCA2* compressors, mikem says will prob change soon - 10/2/09
        'Function get_rep_air_cooled_chiller_compressors(ByVal refrigerant As refrigerant, ByVal voltage As Integer, ByVal standard_hp As Double) As List(Of compressor) _
        'Implements i_compressor_repository.get_rep_air_cooled_chiller_compressors
        '    Dim available_hps = get_hp_size_above_and_below(standard_hp)

        '    Dim sql = Str(" AND [{0}].{1} LIKE 'SCA2%' AND (", _
        '                  ct.table_name, ct.model)

        '    For i As Integer = 0 To available_hps.Count - 1
        '        sql &= Str(" [{0}].{1}='{2}'", ct.table_name, ct.hp, available_hps(i))
        '        If i < available_hps.Count - 1 Then _
        '           sql &= " OR"
        '    Next

        '    sql &= ")"

        '    Dim compressors = getCompressors(refrigerant, voltage, sql, "AirCooledChillers")

        '    compressors.Sort(New Comparison(Of compressor)(AddressOf compare_compressor_by_hp))

        '    Return compressors
        'End Function

        Function compressor_amps_exist(ByVal compressor_file As String) As Boolean
            'Dim sql = Str("SELECT {0} FROM {1} WHERE {0}='{2}' AND {3}='Condenser'",
            '              ta.file_name, ta.table_name, compressor_file, ta.unit_type)
            'Dim connection = create_connection()
            'Dim command = connection.CreateCommand
            'command.CommandText = sql
            'Dim reader As IDataReader

            'Dim exists = False

            'Try
            '    connection.Open()
            '    reader = command.ExecuteReader
            '    While reader.Read
            '        exists = True
            '    End While
            'Finally
            '    If Not reader Is Nothing Then reader.Close()
            '    If connection.State <> Closed Then connection.Close()
            'End Try

            'Return exists
            MsgBox("Add THis method!!!!  15465")

            Return False
        End Function


        Private Function get_hp_size_above_and_below(ByVal standard_hp As Double) As List(Of Double)
            Dim standard_hp_index As Integer
            Dim all_hps = New List(Of Double)(New Double() {35, 40, 50, 60, 70, 80, 90, 110, 120, 140, 160, 180, 210, 240})
            For i = 0 To all_hps.Count - 1
                If all_hps(i) = standard_hp Then
                    standard_hp_index = i
                    Exit For
                End If
            Next
            Dim hps = New List(Of Double)
            If standard_hp_index > 0 Then _
               hps.Add(all_hps(standard_hp_index - 1))
            hps.Add(all_hps(standard_hp_index))
            If standard_hp_index < all_hps.Count - 1 Then _
               hps.Add(all_hps(standard_hp_index + 1))

            Return hps
        End Function

        Private Function compare_compressor_by_hp(ByVal x As compressor, ByVal y As compressor) As Integer
            Return x.hp - y.hp
        End Function

        Private Function get_10_coefficients(ByVal masterID As String, ByVal unitVoltage As Integer, ByVal ConstantReturnGasTemp As String) As coef
            Static CachedCoef As New Hashtable
            If CachedCoef.ContainsKey(masterID & "_" & unitVoltage) Then
                Return CType(CachedCoef(masterID & "_" & unitVoltage), coef)
            End If



            ' blarg

            Dim con = create_connection()
            Try
                Dim c As New coef
                con.Open()


                Dim hasCC As Boolean = LoadCurrentCoeff(masterID, c, con, unitVoltage, ConstantReturnGasTemp, 1)
                Dim hasCapC As Boolean = LoadCapacityCoeff(masterID, c, con, ConstantReturnGasTemp)
                Dim hasPC As Boolean = LoadPowerCoeff(masterID, c, con, ConstantReturnGasTemp)
                CachedCoef.Add(masterID & "_" & unitVoltage, c)


                If (hasCC OrElse hasCapC OrElse hasPC) = False Then Return Nothing


                Return c
            Catch ex As Exception
            Finally
                If con.State <> ConnectionState.Closed Then con.Close()

            End Try





        End Function



        Private Function LoadCurrentCoeff(ByVal masterID As String, ByRef c As coef, ByVal CON As IDbConnection, ByVal unitVoltage As Integer, ByVal ConstantReturnGasTemp As String, ByVal multiplier As Decimal) As Boolean
            LoadCurrentCoeff = False

            Dim sql As String
            '            sql = "SELECT c0, c1, c2, c3, c4, c5, c6, c7, c8, c9, Voltage from Coefficients where MasterID ='" & masterID & "' and CoefficientType = 'Current' and Frequency = 60 and ConstantReturnGasTemp = '" & ConstantReturnGasTemp & "'"
            ' sql = "SELECT c0, c1, c2, c3, c4, c5, c6, c7, c8, c9, Voltage from Coefficients where MasterID ='" & masterID & "' and CoefficientType = 'Current' and Frequency = 60 and ConstantReturnGasTemp = '65'"


            sql = "SELECT c0, c1, c2, c3, c4, c5, c6, c7, c8, c9, Voltage, 1 as iOrder from Coefficients where MasterID ='" & masterID & "' and voltage = " & unitVoltage & " and CoefficientType = 'Current' and frequency = 60  and ConstantReturnGasTemp = '65'"
            sql &= " UNION "
            sql &= "SELECT c0, c1, c2, c3, c4, c5, c6, c7, c8, c9, Voltage, 2 as iOrder from Coefficients where MasterID ='" & masterID & "' and voltage = " & unitVoltage & " and CoefficientType = 'Current' and frequency = 60  and ConstantSuperheat = '20'"
            sql &= " order by iOrder "

            Dim foundAnAnswer As Boolean = False

            '   Dim con = create_connection()
            Dim cmd = CON.CreateCommand()

            cmd.CommandText = sql
            Dim rdr As IDataReader

            '    Dim c As coef

            Try

                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    '  c = New coef()

                    c.a(0) = rdr("c0") * multiplier
                    c.a(1) = rdr("c1") * multiplier
                    c.a(2) = rdr("c2") * multiplier
                    c.a(3) = rdr("c3") * multiplier
                    c.a(4) = rdr("c4") * multiplier
                    c.a(5) = rdr("c5") * multiplier
                    c.a(6) = rdr("c6") * multiplier
                    c.a(7) = rdr("c7") * multiplier
                    c.a(8) = rdr("c8") * multiplier
                    c.a(9) = rdr("c9") * multiplier

                    c.unitVoltage = unitVoltage / multiplier
                    LoadCurrentCoeff = True
                    foundAnAnswer = True

                End If
            Finally
                If rdr IsNot Nothing Then _
                   rdr.Close()

            End Try


            If (Not foundAnAnswer AndAlso multiplier = 1) Then
                If unitVoltage = 230 Then
                    Return LoadCurrentCoeff(masterID, c, CON, 460, "", 2)
                    ' Exit Function
                ElseIf unitVoltage = 460 Then
                    Return LoadCurrentCoeff(masterID, c, CON, 230, "", 0.5)
                    'Exit Function
                End If
            End If


        End Function



        Private Function LoadCapacityCoeff(ByVal masterID As String, ByRef c As coef, ByVal CON As IDbConnection, ByVal ConstantReturnGasTemp As String) As Boolean

            LoadCapacityCoeff = False

            Dim sql As String
            '            sql = "SELECT c0, c1, c2, c3, c4, c5, c6, c7, c8, c9, SubCooling from Coefficients where MasterID ='" & masterID & "' and CoefficientType = 'Capacity' and frequency = 60 and ConstantReturnGasTemp = '" & ConstantReturnGasTemp & "'"
            sql = "SELECT c0, c1, c2, c3, c4, c5, c6, c7, c8, c9, SubCooling, 1 as iOrder from Coefficients where MasterID ='" & masterID & "' and CoefficientType = 'Capacity' and frequency = 60  and ConstantReturnGasTemp = '65'"
            sql &= " UNION "
            sql &= "SELECT c0, c1, c2, c3, c4, c5, c6, c7, c8, c9, SubCooling, 2 as iOrder from Coefficients where MasterID ='" & masterID & "' and CoefficientType = 'Capacity' and frequency = 60  and ConstantSuperheat = '20'"
            sql &= " order by iOrder "
            '   Dim con = create_connection()
            Dim cmd = CON.CreateCommand()

            cmd.CommandText = sql
            Dim rdr As IDataReader

            '    Dim c As coef

            Try
                '  con.Open()
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    '  c = New coef()

                    c.c(0) = rdr("c0")
                    c.c(1) = rdr("c1")
                    c.c(2) = rdr("c2")
                    c.c(3) = rdr("c3")
                    c.c(4) = rdr("c4")
                    c.c(5) = rdr("c5")
                    c.c(6) = rdr("c6")
                    c.c(7) = rdr("c7")
                    c.c(8) = rdr("c8")
                    c.c(9) = rdr("c9")

                    c.SubCooling = rdr("SubCooling")
                    LoadCapacityCoeff = True
                End If

            Finally
                If rdr IsNot Nothing Then _
                   rdr.Close()
                '  If con.State <> ConnectionState.Closed Then _
                '   con.Close()
            End Try


        End Function

        Private Function LoadPowerCoeff(ByVal masterID As String, ByRef c As coef, ByVal CON As IDbConnection, ByVal ConstantReturnGasTemp As String) As Boolean

            LoadPowerCoeff = False

            Dim sql As String
            ' sql = "SELECT c0, c1, c2, c3, c4, c5, c6, c7, c8, c9 from Coefficients where MasterID ='" & masterID & "' and CoefficientType = 'Power' and frequency = 60  and ConstantReturnGasTemp = '65'"
            '            sql = "SELECT c0, c1, c2, c3, c4, c5, c6, c7, c8, c9 from Coefficients where MasterID ='" & masterID & "' and CoefficientType = 'Power' and frequency = 60 and ConstantReturnGasTemp = '" & ConstantReturnGasTemp & "'"""



            sql = "SELECT c0, c1, c2, c3, c4, c5, c6, c7, c8, c9, 1 as iOrder from Coefficients where MasterID ='" & masterID & "' and CoefficientType = 'Power' and frequency = 60  and ConstantReturnGasTemp = '65'"
            sql &= " UNION "
            sql &= "SELECT c0, c1, c2, c3, c4, c5, c6, c7, c8, c9, 2 as iOrder from Coefficients where MasterID ='" & masterID & "' and CoefficientType = 'Power' and frequency = 60  and ConstantSuperheat = '20'"
            sql &= " order by iOrder "



            ' Dim con = create_connection()
            Dim cmd = CON.CreateCommand()

            cmd.CommandText = sql
            Dim rdr As IDataReader

            '    Dim c As coef

            Try
                '   con.Open()
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    '  c = New coef()

                    c.w(0) = rdr("c0")
                    c.w(1) = rdr("c1")
                    c.w(2) = rdr("c2")
                    c.w(3) = rdr("c3")
                    c.w(4) = rdr("c4")
                    c.w(5) = rdr("c5")
                    c.w(6) = rdr("c6")
                    c.w(7) = rdr("c7")
                    c.w(8) = rdr("c8")
                    c.w(9) = rdr("c9")
                    LoadPowerCoeff = True


                End If
            Finally
                If rdr IsNot Nothing Then _
                   rdr.Close()
                ' If con.State <> ConnectionState.Closed Then _
                'CON.Close()
            End Try


        End Function




        'Private Function get_5_coefficients(ByVal fileName As String) As coef
        '    Dim con = create_connection()
        '    Dim cmd = con.CreateCommand()
        '    Dim sql = Str("SELECT * FROM {0} WHERE [{1}]='{2}'", _
        '                  c5.table_name, c5.file_name, fileName)
        '    cmd.CommandText = sql
        '    Dim rdr As IDataReader

        '    Dim c = New coef()
        '    Dim count As Integer = 0
        '    Try
        '        con.Open()
        '        rdr = cmd.ExecuteReader()
        '        While rdr.Read()
        '            c.c(0) = rdr(c5.c0)
        '            c.c(1) = rdr(c5.c1)
        '            c.c(2) = rdr(c5.c2)
        '            c.c(3) = rdr(c5.c3)
        '            c.c(4) = rdr(c5.c4)

        '            c.a(0) = rdr(c5.a0)
        '            c.a(1) = rdr(c5.a1)
        '            c.a(2) = rdr(c5.a2)
        '            c.a(3) = rdr(c5.a3)
        '            c.a(4) = rdr(c5.a4)

        '            c.w(0) = rdr(c5.w0)
        '            c.w(1) = rdr(c5.w1)
        '            c.w(2) = rdr(c5.w2)
        '            c.w(3) = rdr(c5.w3)
        '            c.w(4) = rdr(c5.w4)
        '            count += 1
        '        End While

        '        If count = 0 Then _
        '           Throw New rae.Data.NotFoundEx("There is no 5 coefficient data for " & fileName)
        '    Finally
        '        If rdr IsNot Nothing Then _
        '           rdr.Close()
        '        If con.State <> ConnectionState.Closed Then _
        '           con.Close()
        '    End Try

        '    Return c
        'End Function


        Private Function convertCompressorType(ByVal cString As String) As compressor_type
            Select Case cString.ToUpper
                Case "RECIPROCATING"
                    Return compressor_type.recip
                Case "RECIP"
                    Return compressor_type.recip
                Case "SCREW"
                    Return compressor_type.screw
                Case "SCROLL"
                    Return compressor_type.scroll
                Case Else
                    Throw New Exception("Unknow compressor type: " & cString)
                    '                    Return compressor_type.semihermetic_discus
            End Select
        End Function


        Private Function getCompressors(ByVal refrigerant As refrigerant, ByVal voltage As Integer, ByVal model_type As String, ByVal constantReturnGasTemp As String) As List(Of compressor)
            Dim con = create_connection()
            Dim cmd = con.CreateCommand()
            'WHERE All.Field1>0 AND 10coef.Field1=All.Field1 AND All.Refrigerant=refrigerant AND 10coef.Voltage=voltage
            '  Dim sql = Str("SELECT * FROM [{0}], {1} WHERE [{0}].{2}>0 AND {1}.{3}=[{0}].{2} AND [{0}].{4}='{5}' AND {1}.{6}={7}{8}", _
            '        ct.table_name, c10.table_name, ct.id, c10.id, ct.refrigerant, refrigerant.value, c10.voltage, voltage, additionalSql)
            '
            Dim sql As String
            Dim oldMethodFlag As Boolean = False
            'Select Case model_type
            '    Case "AirCooledChiller", "EvaporativeCondenserChiller"
            '        'WHERE All.Field1>0 AND 10coef.Field1=All.Field1 AND All.Refrigerant=refrigerant AND 10coef.Voltage=voltage
            '        sql = Str("SELECT * FROM [{0}], {1} WHERE [{0}].{2}>0 AND {1}.{3}=[{0}].{2} AND [{0}].{4}='{5}' AND {1}.{6}={7}{8}", _
            '              ct.table_name, c10.table_name, ct.id, c10.id, ct.refrigerant, refrigerant.value, c10.voltage, voltage, additionalSql)

            '        oldMethodFlag = True
            '    Case Else

            '        sql = Str("SELECT [{0}].*, {1}.*, {9}.{10} FROM {9} INNER JOIN ([{0}] INNER JOIN {1} ON [{0}].{2} = {1}.{3}) ON {9}.{11} = {1}.{12} WHERE [{0}].field1 > 0 AND [{0}].{4}='{5}' AND {9}.{10}={7} AND model_type='" & model_type & "'", _
            '                  ct.table_name, c10.table_name, ct.id, c10.id, ct.refrigerant, refrigerant.value, c10.voltage, voltage, additionalSql, ta.table_name, ta.voltage, ta.CompressorFileName, ct.CompressorFileName)

            'End Select


            sql = "select distinct " & ct1.table_name & "." & ct1.MasterID & ", " & ct1.ManufacturerModelNumber & ", " & ct1.CompressorType & ", " & ct1.Refrigerant & ", " & ct1.Manufacturer & ", " & ct1.DemandCoolingLimit
            sql &= ", " & ct1.Horsepower & ", " & ct1.TemperatureRange & ", " & ct1.LimitID & ", " & ed1.table_name & "." & ed1.Voltage
            sql &= " from (" & ct1.table_name & " "
            sql &= " inner join " & cot.table_name & " on " & cot.table_name & "." & cot.MasterID & " = " & ct1.table_name & "." & ct1.MasterID & " ) "

            sql &= " inner join " & ed1.table_name & " on " & ed1.table_name & "." & ed1.MasterID & " = " & ct1.table_name & "." & ct1.MasterID
            sql &= ""
            sql &= " WHERE " & ct1.Refrigerant & " ='" & refrigerant.value & "' "
            sql &= " AND " & ed1.table_name & "." & ed1.Voltage & " = '" & voltage & "' AND " & cot.table_name & "." & cot.CoefficientType & " = 'Capacity' "
            'Dim sql = Str("SELECT [{0}].*, {1}.*, {9}.{10} FROM {9} INNER JOIN ([{0}] INNER JOIN {1} ON [{0}].{2} = {1}.{3}) ON {9}.{11} = {1}.{12} WHERE [{0}].field1 > 0 AND [{0}].{4}='{5}' AND {9}.{10}={7} AND model_type='" & model_type & "'", _
            '          ct.table_name, c10.table_name, ct.id, c10.id, ct.refrigerant, refrigerant.value, c10.voltage, voltage, additionalSql, ta.table_name, ta.voltage, ta.CompressorFileName, ct.CompressorFileName)



            'sql = "select distinct " & ct.table_name & "." & ct.MasterID & ", " & ct.ManufacturerModelNumber & ", " & ct.CompressorType & ", " & ct.Refrigerant & ", " & ct.Manufacturer
            'sql &= ", " & ct.Horsepower & ", " & cot.table_name & "." & cot.CurveVoltage & " as CurveVoltage, " & ct.TemperatureRange & ", " & ct.LimitID & ", " & ed.table_name & "." & ed.Voltage
            'sql &= " from (" & ct.table_name & " "
            'sql &= " inner join " & cot.table_name & " on " & cot.table_name & "." & cot.MasterID & " = " & ct.table_name & "." & ct.MasterID & " ) "

            'sql &= " inner join " & ed.table_name & " on " & ed.table_name & "." & ed.MasterID & " = " & ct.table_name & "." & ct.MasterID
            'sql &= ""
            'sql &= " WHERE " & ct.Refrigerant & " ='" & refrigerant.value & "' "
            'sql &= " AND " & ed.table_name & "." & ed.Voltage & " = '" & voltage & "' AND " & cot.table_name & "." & cot.CoefficientType & " = 'Capacity' "





            cmd.CommandText = sql
            Dim rdr As IDataReader
            Dim compressors = New List(Of compressor)
            Try
                con.Open()
                rdr = cmd.ExecuteReader()
                Dim c As compressor
                While rdr.Read()
                    Try

                        c = New compressor()

                        c.model = rdr(ct1.ManufacturerModelNumber)
                        c.type = convertCompressorType(rdr(ct1.CompressorType))
                        c.refrigerant = rdr(ct1.Refrigerant)
                        c.MasterID = rdr(ct1.MasterID)
                        c.manufacturer = rdr(ct1.Manufacturer)
                        c.hp = rdr(ct1.Horsepower)
                        ' c.CurveVoltage = rdr(cot.Voltage)
                        c.TempApplication = rdr(ct1.TemperatureRange).ToString.Substring(0, 1).ToUpper
                        c.limitID = rdr(ct1.LimitID)
                        c.DemandCoolingLimit = rdr(ct1.DemandCoolingLimit).ToString
                        '   c.CurveVoltage = rdr("CurveVoltage")
                        ' c.coef.curveVoltage = rdr(cot.CurveVoltage)
                        '  c.coef.unitVoltage = voltage
                        ' c.v
                        'c.old_model = ConvertNull.ToString(rdr(ct.old_model))
                        'c.part_number = rdr(ct.rae_part_number)
                        'c.discharge_min = rdr(ct.DischargeMin)
                        'c.discharge_max = rdr(ct.DischargeMax)
                        'c.suction_min = rdr(ct.SuctionMin)
                        'c.suction_max = rdr(ct.SuctionMax)
                        'c.Unloading = rdr(ct.Unloading)
                        'c.HeadCoolingFan = rdr(ct.HeadCoolingFan)
                        'c.HeadCoolingFanSuctionMin = rdr(ct.HeadCoolingFanSuctionMin)
                        'c.HeadCoolingFanSuctionMax = rdr(ct.HeadCoolingFanSuctionMax)
                        'c.OilCool = rdr(ct.OilCool)
                        'c.OilCoolSuctionMin = rdr(ct.OilCoolSuctionMin)
                        'c.OilCoolSuctionMax = rdr(ct.OilCoolSuctionMax)
                        'c.LiquidInjection = rdr(ct.LiquidInjection)
                        'c.LiquidInjectionSuctionMin = rdr(ct.LiquidInjectionSuctionMin)
                        'c.LiquidInjectionSuctionMax = rdr(ct.LiquidInjectionSuctionMax)
                        'c.DemandC = rdr(ct.DemandC)
                        'c.DemandCSuctionMin = rdr(ct.DemandCSuctionMin)
                        'c.DemandCSuctionMax = rdr(ct.DemandCSuctionMax)

                        'c.TempApplication = ConvertNull.ToString(rdr(ct.TempApplication))
                        'c.OilDistSystem = ConvertNull.ToString(rdr(ct.OilDistSystem))



                        Dim coef = get_10_coefficients(c.MasterID, voltage, constantReturnGasTemp)
                        If coef Is Nothing Then
                            Throw New rae.Data.NotFoundEx("The compressor data cannot be retrieved. There is no 10 coefficient data for compressor: " & c.model)
                        End If
                        c.coef = coef
                        c.num_coef = 10
                        ' c.coef.curveVoltage = c.CurveVoltage
                        c.coef.unitVoltage = voltage
                        compressors.Add(c)

                    Catch ex As Exception

                    End Try



                End While
            Catch e As Exception
                Beep()

            Finally
                If rdr IsNot Nothing Then _
                   rdr.Close()
                If con.State <> ConnectionState.Closed Then _
                   con.Close()
            End Try

            Return compressors
        End Function

        'Private Function get_5_coefficient_compressors(ByVal refrigerant As refrigerant) As List(Of compressor)
        '    Dim con = create_connection()
        '    Dim cmd = con.CreateCommand()
        '    Dim sql = Str("SELECT * FROM [{0}] WHERE ({1} Is Null OR {1}=0) AND {2}='{3}'", _
        '              ct.table_name, ct.id, ct.refrigerant, refrigerant)





        '    'Dim sql = Str("SELECT [{0}].*, {1}.*, {9}.{10} FROM {9} INNER JOIN ([{0}] INNER JOIN {1} ON [{0}].{2} = {1}.{3}) ON {9}.{11} = {1}.{12} WHERE [{0}].field1 > 0 AND [{0}].{4}='{5}' AND {9}.{10}={7} AND model_type='Condenser'", _
        '    '          ct.table_name, c10.table_name, ct.id, c10.id, ct.refrigerant, refrigerant.value, c10.voltage, voltage, additionalSql, ta.table_name, ta.voltage, ta.CompressorFileName, ct.CompressorFileName)



        '    cmd.CommandText = sql
        '    Dim rdr As IDataReader
        '    Dim compressors = New List(Of compressor)
        '    Try
        '        con.Open()
        '        rdr = cmd.ExecuteReader()
        '        Dim c As compressor
        '        While rdr.Read()
        '            c = get_compressor_data_from_all_data_table(rdr, False)
        '            c.num_coef = 5


        '            Try
        '                Dim coef = get_5_coefficients(c.MasterID)
        '                If coef Is Nothing Then
        '                    Throw New rae.Data.NotFoundEx("The compressor data cannot be retrieved. There is no 5 coefficient data for compressor: " & c.model)
        '                Else
        '                    c.coef = coef
        '                End If
        '                compressors.Add(c)
        '            Catch ex As rae.Data.NotFoundEx
        '                ' keep going just don't add compressor to list
        '            End Try
        '        End While
        '    Finally
        '        If rdr IsNot Nothing Then _
        '           rdr.Close()
        '        If con.State <> ConnectionState.Closed Then _
        '           con.Close()
        '    End Try

        '    Return compressors
        'End Function

        Private Function set_coefficients_for(ByVal c As compressor, ByVal refrigerant As refrigerant, ByVal voltage As Integer, ByVal model_type As String, ByVal constantReturnGasTemp As String) As coef


            Dim coef = get_10_coefficients(c.MasterID, voltage, constantReturnGasTemp)

            c.num_coef = 10
            c.coef = coef

            Return coef
        End Function

        Private Function get_compressor_data_from_all_data_table(ByVal rdr As IDataReader, ByVal unitVoltage As Integer, ByVal constantReturnGasTemp As String) As compressor

            Dim c = New compressor()


            c.model = rdr(ct1.ManufacturerModelNumber)
            c.type = convertCompressorType(rdr(ct1.CompressorType))
            c.refrigerant = rdr(ct1.Refrigerant)
            c.MasterID = rdr(ct1.MasterID)
            c.manufacturer = rdr(ct1.Manufacturer)
            c.hp = rdr(ct1.Horsepower)
            '  c.CurveVoltage = rdr(cot.CurveVoltage)
            c.TempApplication = rdr(ct1.TemperatureRange).ToString.Substring(0, 1).ToUpper
            c.limitID = rdr(ct1.LimitID)
            c.DemandCoolingLimit = rdr(ct1.DemandCoolingLimit).ToString
            'c.mcc = rdr(ed.MCC)
            'c.rla = rdr(ed.RLA)
            Dim SuccessFlag As Boolean = False

            Dim cLSI As New CompressorLimits(c.limitID, False, SuccessFlag)
            If Not SuccessFlag Then GoTo 10

            cLSI.GetMinMaxSuction(c.suctionMin, c.suctionMax)


            'c.suction_min = rdr(ct.SuctionMin)
            'c.suction_max = rdr(ct.SuctionMax)



            Dim coef = get_10_coefficients(c.MasterID, unitVoltage, constantReturnGasTemp)
            If coef Is Nothing Then
                Throw New rae.Data.NotFoundEx("The compressor data cannot be retrieved. There is no 10 coefficient data for compressor: " & c.model)
            End If
            c.coef = coef
            c.num_coef = 10


            Return c


10:
            Return Nothing

        End Function

        Private Function tbl(ByVal column As String) As String
            Return ct1.table_name & "." & column
        End Function



        Private Function create_connection() As IDbConnection
            Return rae.RaeSolutions.DataAccess.Common.CreateConnection(rae.RaeSolutions.DataAccess.Common.CompressorDbPath)
        End Function

    End Class

End Namespace