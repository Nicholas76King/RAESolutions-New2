Option Strict Off

Imports Rae.Data.Access
Imports Rae.RaeSolutions.Business.Entities
Imports rae.solutions.compressors
imports Rae.Io.Text
imports Rae.RaeSolutions.DataAccess
imports System.Data
Imports ct1 = RAE.Solutions.evaporative_condenser_chillers.evaporative_condenser_table
Imports t1 = RAE.Solutions.evaporative_condenser_chillers.table
Imports Microsoft1.VisualStudio.TestTools.UnitTesting.Assert

Namespace RAE.Solutions.evaporative_condenser_chillers

    Public Interface i_repository
        Function get_models(series As String, refrigerant As String) As List(Of String)
        Function [get](model As String, voltage As Integer) As chiller
        Function get_condensers() As List(Of evaporative_condenser)
        Function get_distinct_compressor_models(series As String) As List(Of String)
    End Interface

    Public Class repository : Implements i_repository

        Private compressor_repo As i_compressor_repository

        Sub New()
            compressor_repo = New compressor_repository()
        End Sub

        Function get_models(series As String, refrigerant As String) As List(Of String) _
   Implements i_repository.get_models
            Dim connection = create_connection()
            Dim command = connection.CreateCommand()
            Dim sql = Str("SELECT [{0}] FROM [{1}] WHERE [{2}]='{3}'",
                    t1.model, t1.table_name, t1.refrigerant, refrigerant)
            command.CommandText = sql

            Dim models = New List(Of String)
            Dim reader As IDataReader
            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read()
                    models.Add(reader.GetString(0))
                End While
            Finally
                If reader IsNot Nothing Then _
            reader.Close()
                If connection.State <> ConnectionState.Closed Then _
            connection.Close()
            End Try

            Return models
        End Function

        ' check if compressor is null when using this method
        Function [get](model As String, voltage As Integer) As chiller _
   Implements i_repository.get
            Dim connection = Common.CreateConnection(Common.ChillerDbPath)
            Dim command = connection.CreateCommand()

            Dim sql = Str("SELECT * FROM [{0}] WHERE [{1}]='{2}'",
                    t1.table_name, t1.model, model)
            command.CommandText = sql

            Dim reader As IDataReader
            Dim chiller = New chiller
            chiller.model = model

            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read()
                    chiller.refg = refrigerant.parse(reader(t1.refrigerant))
                    chiller.num_circuits = CDbl(reader(t1.num_circuits))
                    chiller.evaporator_model = reader(t1.evaporator_model).ToString()
                    chiller.min_capacity = CDbl(reader(t1.min_capacity))
                    chiller.max_capacity = CDbl(reader(t1.max_capacity))

                    Dim circuit = New circuit()
                    Dim compressor_model = reader(t1.compressor_1).ToString()

                    Try
                        circuit.compressor = compressor_repo.get_compressor(compressor_model, chiller.refg, voltage, "EvaporativeCondenserChiller", "N")
                    Catch ex As RAE.Data.NotFoundEx
                        circuit.compressor = Nothing
                    End Try
                    circuit.compressor_qty = CDbl(reader(t1.compressor_quantity_1))

                    Dim condenser_model = reader(t1.condenser_model_1).ToString()
                    chiller.condenser = get_condenser(condenser_model)
                    chiller.condenser_quantity = CDbl(reader(t1.condenser_quantity_1))

                    chiller.circuits.Add(circuit)

                    If chiller.num_circuits > 1 Then
                        chiller.condenser_quantity *= 2

                        Dim circuit2 = New circuit()

                        Try
                            circuit2.compressor = get_compressor(compressor_model, chiller.refg, voltage)
                        Catch ex As RAE.Data.NotFoundEx
                            circuit2.compressor = Nothing
                        End Try
                        circuit2.compressor_qty = reader(t1.compressor_quantity_2)

                        chiller.circuits.Add(circuit2)
                    End If

                    chiller.calculate_fan_watts()
                    chiller.calculate_pump_watts()
                End While
            Finally
                If reader IsNot Nothing Then _
            reader.Close()
                If connection.State <> ConnectionState.Closed Then _
            connection.Close()
            End Try

            Return chiller
        End Function

        Private Sub throw_not_implemented()
            Throw New NotImplementedException("aggregate evaporative condensers not implemented")
        End Sub

        Private Function get_compressor(model, refg, voltage) As compressor
            Return compressor_repo.get_compressor(model, refg, voltage, "EvaporativeCondenserChiller", "N")
        End Function

        Private Function get_distinct_compressor_models(series As String) As List(Of String) _
   Implements i_repository.get_distinct_compressor_models
            Dim connection = create_connection()
            Dim sql = Str("SELECT DISTINCT [{0}] FROM [{1}] WHERE [{2}] LIKE '{3}%'",
                    t1.compressor_1, t1.table_name, t1.model, series)
            Dim command = connection.CreateCommand()
            command.CommandText = sql
            Dim reader As IDataReader

            Dim compressor_models = New List(Of String)
            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read()
                    compressor_models.Add(reader.GetString(0))
                End While
            Finally
                If reader IsNot Nothing Then reader.Close()
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try

            Return compressor_models
        End Function

        Function get_condensers() As List(Of evaporative_condenser) _
   Implements i_repository.get_condensers
            Dim connection = create_connection()
            Dim command = connection.CreateCommand()
            command.CommandText = Str("SELECT * FROM [{0}]", ct1.table_name)
            Dim reader As IDataReader
            Dim condensers = New List(Of evaporative_condenser)

            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read()
                    Dim condenser = readCondenser(reader)
                    condensers.Add(condenser)
                End While
            Finally
                If reader IsNot Nothing Then _
            reader.Close()
                If connection.State <> ConnectionState.Closed Then _
            connection.Close()
            End Try

            Return condensers
        End Function

        Private Function get_condenser(model As String) As evaporative_condenser
            Dim connection = create_connection()
            Dim command = connection.CreateCommand()
            command.CommandText = Str("SELECT * FROM [{0}] WHERE [{1}]='{2}'",
                                ct1.table_name, ct1.model, model)
            Dim reader As IDataReader
            Dim condenser As evaporative_condenser
            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read
                    condenser = readCondenser(reader)
                End While
            Finally
                If reader IsNot Nothing Then _
            reader.Close()
                If connection.State <> ConnectionState.Closed Then _
            connection.Close()
            End Try

            Return condenser
        End Function

        Private Function readCondenser(reader As IDataReader) As evaporative_condenser
            Dim condenser As evaporative_condenser

            condenser.air_flow = reader(ct1.air_flow)
            condenser.capacity = reader(ct1.capacity)
            condenser.fan_hp = reader(ct1.fan_hp)
            condenser.gpm = reader(ct1.gpm)
            condenser.height = reader(ct1.height)
            condenser.length = reader(ct1.length)
            condenser.model = reader(ct1.model)
            condenser.pump_hp = reader(ct1.pump_hp)
            condenser.width = reader(ct1.width)
            condenser.operating_weight = reader(ct1.operating_weight)
            condenser.shipping_weight = reader(ct1.shipping_weight)

            condenser.is_custom = false
      
      return condenser
   end function
   
   private function create_connection() as idbconnection
      return Common.CreateConnection(Common.ChillerDbPath)
   end function
end class

end namespace