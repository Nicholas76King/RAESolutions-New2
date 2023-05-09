Option Strict On
Option Explicit On

Imports rae.Io.Text
Imports rae.RaeSolutions.DataAccess.Common
Imports System.Collections.Generic
Imports System.Data
Imports Table = rae.solutions.condensers.condensers_table
Imports ft1 = RAE.RAESolutions.DataAccess.FansTable
Imports CNull = rae.ConvertNull
Imports rae.RaeSolutions.Business.Entities

Namespace rae.solutions.condensers

    Public Structure condenser
        Public model As String
        ''' <summary>Subcooling percentage (ex. 10% would be 10)</summary>
        Public subcooling_percentage As Double
        Public number_of_circuits As Integer
        Public refrigerant As String
        Public fin_height, fin_length As Double
        Public fan_quantity As Integer
        Public fan_file_name, coil_file_name As String
        Public length, height, width As Double
        Public single_circuit_inlet_diameter, dual_circuit_inlet_diameter As String ' in inches
        Public single_circuit_outlet_diameter, dual_circuit_outlet_diameter As String
        Public connection_type As String 'ex ODS Copper
        Public shipping_weight, operating_weight As Double
        Public motor_part_number230460 As String
        Public motor_part_number575 As String
        Public TubeSurface As String
    End Structure

    Public Class condenser_repository

#Region " Data transfer objects"

        Public Structure FanTransferData
            Public FileName As String
            Public GroupName As String
            Public Horsepower As Double
            Public Diameter As Double
            Public Rpm As Double
            Public Hertz As Double
            Public IsHighAltitude As Boolean
            Public Description As String
            Public RepsAuthorized As Boolean
            Public IsVariableSpeed As Boolean
        End Structure

        Public Structure CoilTransferData
            Public Diameter As Double
            Public NumRows As Double
            Public FileName As String
            Public RepsAuthorized As Boolean
            Public CoilType As String
            Public FinType As String
            Public TubeSurface As String
        End Structure

#End Region

#Region " Public methods"

        ''' <summary>Retrieves list of condenser models for the condenser series.</summary>
        ''' <param name="series">Condenser series to get models for (ie 10AO, PFC, RAC)</param>
        Shared Function RetrieveModels(ByVal series As String) As List(Of String)
            Dim reader As IDataReader
            Dim models As New List(Of String)

            Dim sql = "SELECT [Model] FROM [" & CommonTableName(CondenserDbPath, "Condensers") & "]  WHERE [Model_Type] = '" & series & "' ORDER BY [Model_Sort] ASC"
            Dim connection = CreateConnection(CondenserDbPath)
            Dim command = connection.CreateCommand()
            command.CommandText = sql

            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read()
                    models.Add(reader("Model").ToString)
                End While
            Finally
                If reader IsNot Nothing Then reader.Close()
                If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
            End Try

            Return models
        End Function

        ''' <summary>
        ''' Retrieves condenser data based on the condenser model.
        ''' </summary>
        ''' <param name="model">
        ''' Condenser model to retrieve data for
        ''' </param>
        ''' <exception cref="System.ArgumentNullException">
        ''' Thrown when the condenser model parameter is null or empty.
        ''' </exception>
        ''' <exception cref="System.ArgumentException">
        ''' Thrown when the condenser model does not exist in the data source.
        ''' </exception>
        Shared Function RetrieveCondenser(ByVal model As String) As condenser
            If String.IsNullOrEmpty(model) Then _
               Throw New System.ArgumentNullException("The condenser data cannot be retrieved. The condenser model is null or empty.")

            Dim condenser As condenser

            Dim connectionString = GetConnectionString(CondenserDbPath)
            Dim connection = CreateConnection(CondenserDbPath)

            Dim command = connection.CreateCommand()
            Dim sql = "SELECT * " & _
                      "FROM [" & CommonTableName(CondenserDbPath, Table.table_name) & "] " & _
                      "WHERE [" & Table.model & "]='" & model & "'"
            command.CommandText = sql

            Dim reader As IDataReader
            Try
                connection.Open()
                reader = command.ExecuteReader()

                Dim modelFound = False

                While reader.Read()
                    condenser.model = reader(Table.model).ToString
                    condenser.refrigerant = reader(Table.refrigerant).ToString
                    condenser.length = CNull.ToDouble(reader(Table.length))
                    condenser.width = CNull.ToDouble(reader(Table.width))
                    condenser.height = CNull.ToDouble(reader(Table.height))
                    condenser.fan_file_name = reader(Table.fan_file_name).ToString
                    condenser.coil_file_name = reader(Table.coil_file_name).ToString
                    condenser.fin_height = CNull.ToDouble(reader(Table.fin_height))
                    condenser.fin_length = CNull.ToDouble(reader(Table.fin_length))
                    condenser.single_circuit_inlet_diameter = reader(Table.single_circuit_inlet_diameter).ToString
                    condenser.dual_circuit_inlet_diameter = reader(Table.dual_circuit_inlet_diameter).ToString
                    condenser.single_circuit_outlet_diameter = reader(Table.single_circuit_outlet_diameter).ToString
                    condenser.dual_circuit_outlet_diameter = reader(Table.dual_circuit_outlet_diameter).ToString
                    condenser.shipping_weight = CNull.ToDouble(reader(Table.shipping_weight))
                    condenser.operating_weight = CNull.ToDouble(reader(Table.operating_weight))
                    condenser.number_of_circuits = CNull.ToInteger(reader(Table.number_of_circuits))
                    condenser.fan_quantity = CNull.ToInteger(reader(Table.fan_quantity))
                    condenser.subcooling_percentage = CNull.ToDouble(reader(Table.subcooling_percentage))
                    condenser.connection_type = reader(Table.connection_type).ToString
                    condenser.motor_part_number230460 = reader(Table.motor_part_number230460).ToString
                    condenser.motor_part_number575 = reader(Table.motor_part_number575).ToString
                    condenser.TubeSurface = "Smooth"
                    modelFound = True
                End While
                If Not modelFound Then _
                   Throw New Exception("The condenser model cannot be found.")
                modelFound = modelFound
            Finally
                If reader IsNot Nothing Then reader.Close()
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try

            Return condenser
        End Function


        Shared Function RetrieveCondenserRepFans(ByVal fanGroup As String) As List(Of FanTransferData)
            Dim sql = RAE.Io.Text.Str("SELECT * FROM [{0}] WHERE [{1}]='{2}' AND [{3}]=True AND [{4}]=True",
                                      ft1.TableName, ft1.GroupName, fanGroup, ft1.Condenser, ft1.Rep)
            If fanGroup = String.Empty Then
                sql = RAE.Io.Text.Str("SELECT * FROM [{0}] WHERE [{1}]=True AND [{2}]=True",
                                      ft1.TableName, ft1.Condenser, ft1.Rep)
            End If
            Return retrieveFans(sql)
        End Function

        Shared Function RetrieveCondenserEmployeeFans() As List(Of FanTransferData)
            Dim sql = RAE.Io.Text.Str("SELECT * FROM [{0}] WHERE [{1}]=True",
                                       ft1.TableName, ft1.Condenser)
            Return retrieveFans(sql)
        End Function

        Shared Function GetChillerFans(Optional ByVal is_rep As Boolean = False) As List(Of RAE.RAESolutions.Business.Entities.Fan)
            Dim connection = CreateConnection(CondenserDbPath)
            Dim command = connection.CreateCommand()
            Dim sql = RAE.Io.Text.Str("SELECT * FROM [{0}] WHERE [{1}]=True",
                                       ft1.TableName, ft1.Chiller)
            command.CommandText = sql
            Dim reader As IDataReader
            Dim fans = New List(Of Fan)
            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read()
                    Dim fileName = reader(ft1.FileName).ToString
                    Dim hp = CDbl(reader(ft1.Hp))
                    Dim diameter = CDbl(reader(ft1.Diameter))
                    Dim rpm = CDbl(reader(ft1.Rpm))
                    Dim hertz = CInt(reader(ft1.Hertz)) ' if db null, should throw exception
                    Dim highAltitude = CBool(reader(ft1.HighAltitude))
                    Dim isVariableSpeed = CBool(reader(ft1.VariableSpeed))
                    Dim fan = New Fan(fileName, hp, diameter, rpm, highAltitude, hertz, isVariableSpeed)

                    fans.Add(fan)
                End While
            Finally
                If reader IsNot Nothing Then _
                   reader.Close()
                If connection.State <> ConnectionState.Closed Then _
                   connection.Close()
            End Try

            If Not is_rep Then
                Dim customFan As New Fan("CFM Per Fan >>>", 0, 0, 0, False, 0, False)
                customFan.Description = "CFM Per Fan >>>"
                fans.Add(customFan)
            End If

            Return fans
        End Function

        Shared Function GetCondensingUnitFans() As List(Of Fan)
            Dim connection = CreateConnection(CondenserDbPath)
            Dim command = connection.CreateCommand()
            Dim sql = RAE.Io.Text.Str("SELECT * FROM [{0}] WHERE [{1}]=True",
                                       ft1.TableName, ft1.CondensingUnit)
            command.CommandText = sql
            Dim reader As IDataReader
            Dim fans = New List(Of Fan)
            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read()
                    Dim fileName = reader(ft1.FileName).ToString
                    Dim hp = CDbl(reader(ft1.Hp))
                    Dim diameter = CDbl(reader(ft1.Diameter))
                    Dim rpm = CDbl(reader(ft1.Rpm))
                    Dim highAltitude = CBool(reader(ft1.HighAltitude))
                    Dim isVariableSpeed = CBool(reader(ft1.VariableSpeed))
                    Dim hertz = CInt(reader(ft1.Hertz))
                    Dim fan = New Fan(fileName, hp, diameter, rpm, highAltitude, hertz, isVariableSpeed)

                    fans.Add(fan)
                End While
            Finally
                If reader IsNot Nothing Then _
                   reader.Close()
                If connection.State <> ConnectionState.Closed Then _
                   connection.Close()
            End Try

            Return fans
        End Function


        Public Shared Function RetrieveConstant(ByVal key As String) As String
            Dim connection As IDbConnection = CreateConnection(CondenserDbPath)
            Dim sql As String = "SELECT [Value] FROM [Constants] WHERE [Key]='" & key & "'"
            Dim command As IDbCommand = connection.CreateCommand
            command.CommandText = sql
            Dim value As String

            Try
                connection.Open()
                value = command.ExecuteScalar().ToString()
            Catch ex As Exception
                Throw ex
            Finally
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try

            Return value
        End Function


        Public Shared Function RetrieveRepCoils(Optional ByVal condenserOnly As Boolean = False) As List(Of CoilTransferData)
            Dim sql As String = "SELECT * FROM [" & CommonTableName(CondenserDbPath, "Coils") & "] WHERE [RepsAuthorized]=True"

            If condenserOnly Then
                sql &= " AND CoilType = 'Condenser'"
            End If


            Return retrieveCoils(sql)
        End Function

        Public Shared Function RetrieveEmployeeCoils(Optional ByVal condenserOnly As Boolean = False) As List(Of CoilTransferData)
            Dim sql As String = "SELECT * FROM [" & CommonTableName(CondenserDbPath, "Coils") & "]"
            If condenserOnly Then
                sql &= " where CoilType = 'Condenser'"
            End If


            Return retrieveCoils(sql)




        End Function

        Private Shared Function retrieveCoils(ByVal sql As String) As List(Of CoilTransferData)
            Dim connection As IDbConnection = CreateConnection(CondenserDbPath)
            Dim command As IDbCommand = connection.CreateCommand
            Command.CommandText = sql
            Dim reader As iDataReader
            Dim coil As CoilTransferData
            Dim coils As New List(Of CoilTransferData)()

            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read()
                    coil.CoilType = reader("CoilType").ToString()
                    coil.Diameter = CDbl(reader("Diameter"))
                    coil.FileName = reader("FileName").ToString()
                    coil.FinType = reader("FinType").ToString()
                    coil.NumRows = CDbl(reader("NumRows"))
                    coil.RepsAuthorized = CBool(reader("RepsAuthorized"))
                    coil.TubeSurface = reader("TubeSurface").ToString()
                    coils.Add(coil)
                End While
            Catch ex As Exception
                Throw ex
            Finally
                If reader IsNot Nothing Then reader.Close()
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try

            Return coils
        End Function

        Private Shared Function retrieveFans(ByVal sql As String) As List(Of FanTransferData)
            Dim connection = CreateConnection(CondenserDbPath)
            Dim command = connection.CreateCommand
            command.CommandText = sql
            Dim reader As IDataReader
            Dim fan As FanTransferData
            Dim fans = New List(Of FanTransferData)()

            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read()
                    fan.FileName = reader("FileName").ToString()
                    fan.GroupName = reader("GroupName").ToString()
                    fan.Horsepower = CDbl(reader("Horsepower"))
                    fan.Diameter = CDbl(reader("Diameter"))
                    fan.Rpm = CDbl(reader("Rpm"))
                    fan.Hertz = CDbl(reader("Hertz"))
                    fan.IsHighAltitude = CBool(reader("IsHighAltitude"))
                    fan.Description = reader("Description").ToString()
                    fan.RepsAuthorized = CBool(reader("RepsAuthorized"))
                    fan.IsVariableSpeed = CBool(reader("IsVariableSpeed"))


                    fans.Add(fan)
                End While
            Finally
                If reader IsNot Nothing Then reader.Close()
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try

            Return fans
        End Function


        Shared Function RetrieveFanCurve(ByVal filename As String) As DataRow
            Dim connection As IDbConnection = CreateConnection(CondenserDbPath)
            Dim command As IDbCommand = connection.CreateCommand
            command.CommandText = "Select * from FanCurves where FileName = '" & filename & "'"
            Dim da As IDbDataAdapter = CreateAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Return ds.Tables(0).Rows(0)
            End If
            Return Nothing
        End Function


        ''' <summary>
        ''' Retrieve data in coil curves table (curves, number of rows, diameter)
        ''' </summary>
        Public Shared Function RetrieveCoilData(ByVal coilFile As String, ByVal tubeSurface As String) As CoilData
            Dim connection As IDbConnection = CreateConnection(CondenserDbPath)
            Dim command As IDbCommand = connection.CreateCommand
            command.CommandText = "SELECT * FROM CoilCurves WHERE FileName='" & coilFile & "'"
            Dim reader As IDataReader

            Dim data As CoilData
            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read
                    Dim numRows As Double
                    numRows = CDbl(reader("Rows"))
                    Dim diameter As Double
                    diameter = CDbl(reader("Diameter"))
                    Dim pressureCoefficients As New List(Of Double)()
                    With pressureCoefficients
                        .Add(CDbl(reader("P0")))
                        .Add(CDbl(reader("P1")))
                        .Add(CDbl(reader("P2")))
                        .Add(CDbl(reader("P3")))
                        .Add(CDbl(reader("P4")))
                    End With

                    Dim fpi As Double
                    fpi = CDbl(reader("Fpi_1"))

                    Dim pressureCoefficient As Double
                    pressureCoefficient = CDbl(reader("P_1"))

                    Dim fanCoefficients As New List(Of Double)()
                    With fanCoefficients
                        .Add(CDbl(reader("F0_1")))
                        .Add(CDbl(reader("F1_1")))
                        .Add(CDbl(reader("F2_1")))
                        .Add(CDbl(reader("F3_1")))
                        .Add(CDbl(reader("F4_1")))
                    End With

                    Dim fpiData1 As New FpiData(fpi, pressureCoefficient, fanCoefficients)

                    fpi = CDbl(reader("Fpi_2"))
                    pressureCoefficient = CDbl(reader("P_2"))
                    fanCoefficients = New List(Of Double)()
                    With fanCoefficients
                        .Add(CDbl(reader("F0_2")))
                        .Add(CDbl(reader("F1_2")))
                        .Add(CDbl(reader("F2_2")))
                        .Add(CDbl(reader("F3_2")))
                        .Add(CDbl(reader("F4_2")))
                    End With
                    Dim fpiData2 As New FpiData(fpi, pressureCoefficient, fanCoefficients)

                    fpi = CDbl(reader("Fpi_3"))
                    pressureCoefficient = CDbl(reader("P_3"))
                    fanCoefficients = New List(Of Double)()
                    With fanCoefficients
                        .Add(CDbl(reader("F0_3")))
                        .Add(CDbl(reader("F1_3")))
                        .Add(CDbl(reader("F2_3")))
                        .Add(CDbl(reader("F3_3")))
                        .Add(CDbl(reader("F4_3")))
                    End With
                    Dim fpiData3 As New FpiData(fpi, pressureCoefficient, fanCoefficients)

                    fpi = CDbl(reader("Fpi_4"))
                    pressureCoefficient = CDbl(reader("P_4"))
                    fanCoefficients = New List(Of Double)()
                    With fanCoefficients
                        .Add(CDbl(reader("F0_4")))
                        .Add(CDbl(reader("F1_4")))
                        .Add(CDbl(reader("F2_4")))  ' C30 and C31 are the same
                        .Add(CDbl(reader("F3_4")))
                        .Add(CDbl(reader("F4_4")))
                    End With
                    Dim fpiData4 As New FpiData(fpi, pressureCoefficient, fanCoefficients)

                    Dim fpiData As New List(Of FpiData)()
                    With fpiData
                        .Add(fpiData1)
                        .Add(fpiData2)
                        .Add(fpiData3)
                        .Add(fpiData4)
                    End With

                    data = New CoilData(numRows, diameter, pressureCoefficients, fpiData, tubeSurface)
                End While

            Catch ex As Exception
                Throw
            Finally
                If reader IsNot Nothing Then
                    reader.Close()
                End If
                If connection.State <> ConnectionState.Closed Then
                    connection.Close()
                End If
            End Try

            Return data
        End Function


#End Region

        ''' <summary>
        ''' Data for the coil such as curves, number of rows, etc.
        ''' </summary>
        Public Class CoilData


            Public Sub New(ByVal numRows As Double, ByVal diameter As Double, _
            ByVal pressureCoefficients As List(Of Double), ByVal fpiData As List(Of FpiData), ByVal tubeSurface As String)
                pressureCoefficients_ = New List(Of Double)()

                numRows_ = numRows
                diameter_ = diameter
                pressureCoefficients_ = pressureCoefficients
                fpiData_ = fpiData
                tubeSurface_ = tubeSurface
            End Sub


            Protected tubeSurface_ As String
            ''' <summary>
            ''' Number of rows
            ''' </summary>
            Public ReadOnly Property TubeSurface() As String
                Get
                    Return tubeSurface_
                End Get
            End Property


            Protected numRows_ As Double
            ''' <summary>
            ''' Number of rows
            ''' </summary>
            Public ReadOnly Property NumRows() As Double
                Get
                    Return numRows_
                End Get
            End Property


            Protected diameter_ As Double
            ''' <summary>
            ''' Diameter
            ''' </summary>
            Public ReadOnly Property Diameter() As Double
                Get
                    Return diameter_
                End Get
            End Property


            Protected pressureCoefficients_ As List(Of Double)
            ''' <summary>
            ''' Pressure coefficients (indices 0-4)
            ''' </summary>
            Public ReadOnly Property PressureCoefficients() As List(Of Double)
                Get
                    Return pressureCoefficients_
                End Get
            End Property


            Protected fpiData_ As List(Of FpiData)
            ''' <summary>
            ''' Data that is dependent on the fins per inch in a coil
            ''' </summary>
            Public ReadOnly Property FpiData() As List(Of FpiData)
                Get
                    Return fpiData_
                End Get
            End Property

        End Class


        ''' <summary>
        ''' Data that is dependent on the number of fins per inch the coil has
        ''' </summary>
        Public Class FpiData

            Public Sub New(ByVal finsPerInch As Double, ByVal pressureCoefficient As Double, ByVal fanCoefficients As List(Of Double))
                fanCoefficients_ = New List(Of Double)()

                fpi_ = finsPerInch
                pressureCoefficient_ = pressureCoefficient
                fanCoefficients_ = fanCoefficients
            End Sub


            Protected fpi_ As Double
            ''' <summary>
            ''' Fins per inch
            ''' </summary>
            Public ReadOnly Property Fpi() As Double
                Get
                    Return fpi_
                End Get
            End Property


            Protected pressureCoefficient_ As Double
            ''' <summary>
            ''' Pressure coefficient
            ''' </summary>
            Public ReadOnly Property PressureCoefficient() As Double
                Get
                    Return pressureCoefficient_
                End Get
            End Property


            Protected fanCoefficients_ As List(Of Double)
            ''' <summary>
            ''' Fan coefficients (indices 0-4)
            ''' </summary>
            Public ReadOnly Property FanCoefficients() As List(Of Double)
                Get
                    Return fanCoefficients_
                End Get
            End Property

        End Class

    End Class

End Namespace