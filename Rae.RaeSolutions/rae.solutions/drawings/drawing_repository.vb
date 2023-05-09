Option Strict Off

Imports rae.RaeSolutions.DataAccess
Imports rae.RaeSolutions.Business.Entities
Imports System.Data
Imports rae.Io.Text
Imports CNull = rae.ConvertNull
Imports t1 = RAE.Solutions.drawings.ChillerTable
Imports et1 = RAE.Solutions.evaporative_condenser_chillers.table
Imports cut = rae.solutions.condensing_units.Table
Imports wt = rae.solutions.drawings.PumpPackageWeightsTable

Namespace rae.solutions.drawings

    Public Structure PumpPackageWeights
        Public BaseWithSinglePump, BaseWithDualPump, FluidInPipe, EmptyTank, FullTank As Double
    End Structure

    Public Structure CondensingUnitConnectionSizes
        Public Suction, Suction1, Suction2, suction3, suction4 As String
        Public Liquid, Liquid1, Liquid2, liquid3, liquid4 As String
    End Structure

    Public Structure ConnectionSize
        Public Inlet, Outlet As String
    End Structure


    Public Class drawing_repository : Implements i_drawing_repository

        Function get_unit_cooler_electrical_data(ByVal unit_cooler_model As String) As unit_cooler_electrical_data _
        Implements i_drawing_repository.get_unit_cooler_electrical_data
            Dim connection = Common.CreateConnection(Common.UnitCoolerDbPath)
            Dim command = connection.CreateCommand()
            Dim sql = "SELECT * " & _
                             "FROM [unit_coolers] " & _
                             "WHERE [Model] = '" & unit_cooler_model & "'"
            command.CommandText = sql
            Dim reader As IDataReader
            Dim data As unit_cooler_electrical_data
            data.model_is_in_database = False

            Try
                connection.open()
                reader = command.ExecuteReader()
                If reader.read() Then
                    Dim db = New db(reader)
                    data.motor_amps_115v_1ph = db.dbl("MOTOR_AMPS_115_1Ph")
                    data.motor_amps_208v_3ph = db.dbl("MOTOR_AMPS_208_3Ph")
                    data.motor_amps_230v_1ph = db.dbl("MOTOR_AMPS_230_1Ph")
                    data.heater_amps_230v_1ph = db.dbl("DH_AMPS_230_1Ph_TOT")
                    data.motor_amps_230v_3ph = db.dbl("MOTOR_AMPS_230_3Ph")
                    data.heater_amps_230v_3ph = db.dbl("DH_AMPS_230_3Ph_TOT")
                    data.motor_amps_460v_1ph = db.dbl("MOTOR_AMPS_460_1Ph")
                    data.heater_amps_460v_1ph = db.dbl("DH_AMPS_460_1Ph_TOT")
                    data.motor_amps_460v_3ph = db.dbl("MOTOR_AMPS_460_3Ph")
                    data.heater_amps_460v_3ph = db.dbl("DH_AMPS_460_3Ph_TOT")

                    data.motor_amps_575v_1ph = db.dbl("MOTOR_AMPS_575_3Ph")
                    data.motor_amps_575v_3ph = db.dbl("MOTOR_AMPS_575_3Ph")
                    data.heater_amps_575v_1ph = db.dbl("DH_AMPS_575_3Ph_TOT")
                    data.heater_amps_575v_3ph = db.dbl("DH_AMPS_575_3Ph_TOT")


                    data.One_ph_115volt_mtr_part_number = db.str("1_ph_115volt_mtr_part_number")
                    data.One_ph_230volt_mtr_part_number = db.str("1_ph_230volt_mtr_part_number")
                    data.Three_ph_mtr_part_number = db.str("3_ph_mtr_part_number")
                    data.Three_ph_575_mtr_part_number = db.str("3_ph_575_mtr_part_number")


                    data.fan_quantity = db.dbl("Fans")
                    data.heater_watts = db.dbl("DH_WATTS")
                    data.model_is_in_database = True
                End If
            Finally
                If reader IsNot Nothing Then _
                   reader.close()
                If connection.state <> connectionState.Closed Then _
                   connection.close()
            End Try

            Return data
        End Function

        Function GetCondensingUnit(ByVal model, ByVal phase, ByVal voltage) As condensing_unit_data _
        Implements i_drawing_repository.GetCondensingUnit
            Dim con = Common.CreateConnection(Common.CondensingUnitDbPath)
            Dim cmd = con.CreateCommand()
            Dim sql = Str("SELECT {3}, {4}, {5}, [{6}] as MPN1, [{7}] as MPN3, [{12}] as MPN575, {8}, {9}, {10}, {11}  FROM {0} WHERE {1}='{2}'", _
                          cut.table_name, cut.model, model, cut.compressor_quantity_1, cut.CompressorMasterID1, cut.fan_quantity_1, cut.single_phase_motor_part_number, cut.three_phase_motor_part_number230460, cut.number_of_circuits, cut.compressor_quantity_2, cut.CompressorMasterID2, cut.fan_quantity_2, cut.three_phase_motor_part_number575)
            cmd.CommandText = sql
            Dim rdr As IDataReader
            Dim cu As condensing_unit_data
            Try
                con.Open()
                rdr = cmd.ExecuteReader
                While rdr.Read
                    cu.compressor_quantity_1 = rdr(cut.compressor_quantity_1)
                    cu.compressorMasterID1 = rdr(cut.CompressorMasterID1)
                    cu.fan_quantity_1 = rdr(cut.fan_quantity_1)

                    Dim motorCol As String

                    If phase = 1 Then
                        motorCol = "MPN1" ' cut.single_phase_motor_part_number
                    Else
                        If voltage = 575 Then
                            motorCol = "MPN575"  ' cut.three_phase_motor_part_number575
                        Else
                            motorCol = "MPN3" ' cut.three_phase_motor_part_number230460
                        End If
                    End If




                    cu.motor_part_number = rdr(motorCol).ToString

                    cu.circuits = rdr(cut.number_of_circuits)

                    If cu.circuits > 1 Then
                        cu.compressor_quantity_2 = rdr(cut.compressor_quantity_2)
                        cu.compressorMasterID2 = rdr(cut.CompressorMasterID2)
                        cu.fan_quantity_2 = rdr(cut.fan_quantity_2)
                    End If
                End While
            Finally
                If rdr IsNot Nothing Then _
                   rdr.Close()
                If con.State <> ConnectionState.Closed Then _
                   con.Close()
            End Try

            Return cu
        End Function

        Function GetFanAmps(ByVal motorPartNumber As String, ByVal voltage As Integer) As Double _
        Implements i_drawing_repository.GetFanAmps
            Return New rae.solutions.motors.repository().get_amps(motorPartNumber, voltage)
        End Function

        Function GetCompressorAmps(ByVal file_name As String, ByVal unit_type As String, ByVal voltage As Integer, ByVal phase As Integer, ByVal hertz As Integer, ByVal division As String) As Double _
        Implements i_drawing_repository.GetCompressorAmps
            Dim repository = New rae.solutions.compressors.compressor_repository()
            Return repository.get_compressor_amps(file_name, unit_type, voltage, phase, hertz, division)
        End Function

        Function get_evaporative_condenser_chiller(ByVal model As String, ByVal unit_voltage As Integer) As chiller_electrical_data _
        Implements i_drawing_repository.get_evaporative_condenser_chiller
            Dim chiller = New rae.solutions.evaporative_condenser_chillers.repository().get(model, unit_voltage)

            Dim data As chiller_electrical_data
            data.compressor_file_1 = chiller.circuits(0).compressor.MasterID
            data.compressor_quantity_1 = chiller.circuits(0).compressor_qty
            data.fan_quantity_1 = chiller.condenser_quantity '1 fan per condenser
            data.motor_part_number_1_phase = 2 'get_motor_part_num(chiller.condenser.fan_hp) '1 phase
            'data.MotorPartNum3Phase = get_motor_part_num(chiller.condenser.fan_hp) '3 phase
            data.number_of_circuits = chiller.num_circuits
            If chiller.num_circuits > 1 Then
                data.compressor_file_2 = chiller.circuits(1).compressor.MasterID
                data.compressor_quantity_2 = chiller.circuits(1).compressor_qty
                data.fan_quantity_2 = chiller.condenser_quantity
            End If

            Return data
        End Function

        Function GetChiller(ByVal model As String) As chiller_electrical_data _
        Implements i_drawing_repository.GetChiller
            Dim connection = Common.CreateConnection(Common.ChillerDbPath)
            Dim command = connection.CreateCommand()
            command.CommandText = Str("SELECT * FROM {0} WHERE {1}='{2}'", t1.TableName, t1.Model, model)
            Dim reader As IDataReader

            Dim data As chiller_electrical_data

            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read()
                    Dim db = New DB(reader)
                    data.compressor_file_1 = db.str(t1.CompressorFile1)
                    data.compressor_file_2 = db.str(t1.CompressorFile2)
                    data.compressor_quantity_1 = db.dbl(t1.CompressorQuantity1)
                    data.compressor_quantity_2 = db.dbl(t1.CompressorQuantity2)
                    data.fan_quantity_1 = db.dbl(t1.FanQuantity1)
                    data.fan_quantity_2 = db.dbl(t1.FanQuantity2)
                    data.motor_part_number_1_phase = db.str(t1.MotorPartNum1Phase)
                    data.motor_part_number_3_phase = db.str(t1.MotorPartNum3Phase230460)
                    data.number_of_circuits = db.int(t1.NumCircuits)
                    data.Number_ref_circuits_1 = db.dbl(t1.Number_ref_circuits_1)
                    data.Number_ref_circuits_2 = db.dbl(t1.Number_ref_circuits_2)
                    data.coil_qty1 = db.dbl(t1.Coil_QTY_1)
                    data.coil_qty2 = db.dbl(t1.Coil_QTY_2)

                End While
            Finally
                If reader IsNot Nothing Then _
                   reader.Close()
                If connection.State <> ConnectionState.Closed Then _
                   connection.Close()
            End Try

            Return data
        End Function

        Function GetCondenser(ByVal model As String) As condensers.condenser _
        Implements i_drawing_repository.GetCondenser
            Return condensers.condenser_repository.RetrieveCondenser(model)
        End Function

        Function GetPumpPackageHp(ByVal mfg As String, ByVal gpm As Double, ByVal head As Double, ByVal system As PumpSystem) As Double _
        Implements i_drawing_repository.GetPumpPackageHp
            Dim repo = PumpRepoFactory.Create()
            Dim pp = repo.GetPump(mfg, gpm, head, system)
            Return pp.HP
        End Function

        ' only have data for 3 phase 115,208,230,460,575
        Function GetPumpPackageMotorAmps(ByVal hp As Double, ByVal voltage As Integer) As Double _
        Implements i_drawing_repository.GetPumpPackageMotorAmps
            Return New rae.solutions.motors.repository().get_amps(hp, voltage)
        End Function

        Function GetPumpPackageWeights(ByVal flow As Double) As PumpPackageWeights _
        Implements i_drawing_repository.GetPumpPackageWeights
            Dim connection = Common.CreateConnection(Common.PumpPackagesDbPath)
            Dim command = connection.CreateCommand()
            command.CommandText = Str("SELECT * FROM [{0}] WHERE {1}={2}", _
                                      wt.TableName, wt.Flow, flow)
            Dim reader As IDataReader

            Dim weights As PumpPackageWeights
            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read()
                    weights.BaseWithSinglePump = reader(wt.BaseWithSinglePump)
                    weights.BaseWithDualPump = reader(wt.BaseWithDualPump)
                    weights.EmptyTank = reader(wt.EmptyTank)
                    weights.FullTank = reader(wt.FullTank)
                    weights.FluidInPipe = reader(wt.FluidInPipe)
                End While
            Finally
                If reader IsNot Nothing Then _
                   reader.Close()
                If connection.State <> ConnectionState.Closed Then _
                   connection.Close()
            End Try

            Return weights
        End Function

        Function GetPumpPackageConnectionSize( _
           ByVal manufacturer As String, ByVal flow As Double, ByVal head As Double, ByVal system As PumpSystem _
        ) As String Implements i_drawing_repository.GetPumpPackageConnectionSize
            Dim repo = New PumpRepoFactory().Create()
            Dim pumpPackage = repo.GetPump(manufacturer, flow, head, system)
            Return pumpPackage.ConnectionSize
        End Function

        Function GetChillerConnectionSizes(ByVal model As String) As ConnectionSize _
        Implements i_drawing_repository.GetChillerConnectionSizes
            Dim connection = Common.CreateConnection(Common.ChillerDbPath)
            Dim command = connection.CreateCommand()
            Dim sql = Str("SELECT * FROM [{0}] WHERE [{1}]='{2}'",
                                 t1.TableName, t1.Model, model)
            command.CommandText = sql
            Dim reader As IDataReader
            Dim connectionSize As ConnectionSize
            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read()
                    connectionSize.Inlet = CNull.ToString(reader(t1.InletFluidConnectionSize), "NA")
                    connectionSize.Outlet = CNull.ToString(reader(t1.OutletFluidConnectionSize), "NA")
                End While
            Finally
                If reader IsNot Nothing Then _
                   reader.Close()
                If connection.State <> ConnectionState.Closed Then _
                   connection.Close()
            End Try

            Return connectionSize
        End Function

        Function GetCondensingUnitConnectionSize(ByVal model As String) As CondensingUnitConnectionSizes _
        Implements i_drawing_repository.GetCondensingUnitConnectionSizes
            Dim connection = Common.CreateConnection(Common.CondensingUnitDbPath)
            Dim command = connection.CreateCommand()
            Dim sql = Str("SELECT * FROM [{0}] WHERE [{1}]='{2}'", _
                                 cut.table_name, cut.model, model)
            command.CommandText = sql
            Dim reader As IDataReader
            Dim connectionSizes As CondensingUnitConnectionSizes
            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read()
                    ' i know they're backwards - see cliff mines
                    connectionSizes.Suction = CNull.ToString(reader(cut.single_circuit_suction_connection_ods), "NA")
                    connectionSizes.Suction1 = CNull.ToString(reader(cut.suction_connection_ods_1), "NA")
                    connectionSizes.Suction2 = CNull.ToString(reader(cut.suction_connection_ods_2), "NA")

                    connectionSizes.Liquid = CNull.ToString(reader(cut.single_circuit_liquid_connection_ods), "NA")
                    connectionSizes.Liquid1 = CNull.ToString(reader(cut.liquid_connection_ods_1), "NA")
                    connectionSizes.Liquid2 = CNull.ToString(reader(cut.liquid_connection_ods_2), "NA")


                    If model.ToUpper.StartsWith("20A4") Then
                        If CNull.ToString(reader(cut.compressor_quantity_2)) = "2" Then
                            connectionSizes.suction3 = CNull.ToString(reader(cut.suction_connection_ods_1), "NA")
                            connectionSizes.suction4 = CNull.ToString(reader(cut.suction_connection_ods_2), "NA")

                            connectionSizes.liquid3 = CNull.ToString(reader(cut.liquid_connection_ods_1), "NA")
                            connectionSizes.liquid4 = CNull.ToString(reader(cut.liquid_connection_ods_2), "NA")
                        End If
                    End If



                End While
            Finally
                If reader IsNot Nothing Then _
                   reader.Close()
                If connection.State <> ConnectionState.Closed Then _
                   connection.Close()
            End Try

            Return connectionSizes
        End Function

    End Class

    Class ChillerTable
        Public Const TableName As String = "Table5"
        Public Const Model As String = "Model"
        Public Const CompressorQuantity1 As String = "Compr_Qty_1"
        Public Const CompressorFile1 As String = "CompressorMasterID1" ' "Comprfile_1"
        Public Const FanQuantity1 As String = "FanQty_1"
        Public Const CompressorQuantity2 As String = "Compr_Qty_2"
        Public Const CompressorFile2 As String = "CompressorMasterID2" '"Comprfile_2"
        Public Const FanQuantity2 As String = "FanQty_2"
        Public Const MotorPartNum1Phase As String = "1_ph_mtr_part_number"
        Public Const MotorPartNum3Phase230460 As String = "3_ph_mtr_part_number"
        Public Const MotorPartNum3Phase575 As String = "3_ph_575V_mtr_part_number"

        Public Const NumCircuits As String = "Circuits_Per_Unit"
        Public Const InletFluidConnectionSize As String = "Inlet_Fluid_Connection_Size"
        Public Const OutletFluidConnectionSize As String = "Outlet_Fluid_Connection_Size"

        Public Const Number_ref_circuits_1 As String = "Number_ref_circuits_1"
        Public Const Number_ref_circuits_2 As String = "Number_ref_circuits_2"

        Public Const Coil_QTY_1 As String = "CoilQTY_1"
        Public Const Coil_QTY_2 As String = "CoilQTY_2"


    End Class

    Class PumpPackageWeightsTable
        Public Const TableName As String = "Weights"
        Public Const Flow As String = "GPM"
        Public Const FluidInPipe As String = "FluidInPipe"
        Public Const EmptyTank As String = "EmptyTank"
        Public Const FullTank As String = "FullTank"
        Public Const BaseWithSinglePump As String = "SinglePump"
        Public Const BaseWithDualPump As String = "DualPump"
    End Class

End Namespace