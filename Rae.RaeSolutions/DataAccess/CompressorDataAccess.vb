Option Strict On
Option Explicit On

Imports System.Data
Imports Rae.solutions.compressors
Imports System.Collections
Imports System.Collections.Generic
Imports System.Environment
Imports Rae.ConvertNull
Imports Rae.Io.Text

Namespace Rae.RaeSolutions.DataAccess

    ''' <summary>Data access to compressor data source</summary>
    Public Class CompressorDataAccess

#Region " Public methods"

        ''' <summary>Retrieves all compressor data for the compressor model with the specified refrigerant.</summary>
        ''' <param name="compressorModel">Compressor model to retrieve data for</param>
        ''' <param name="refrigerant">Refrigerant compressor uses</param>
        Shared Function RetrieveCompressor(ByVal compressorModel As String, ByVal refrigerant As String) As DataTable
            Dim sql = _
               "SELECT * FROM AllData " & _
               "WHERE compmodel='" & compressorModel.Trim & "' " & _
               "AND refr='" & refrigerant.Trim & "'"

            Return retrieveCompressorsBy(sql)
        End Function

        Shared Function RetrieveCompressor2(ByVal compressorModel As String, ByVal refrigerant As String) As DataTable
            Dim sql = _
               "SELECT * FROM AllData " & _
               "WHERE [compModel] = '" & compressorModel.Trim & "' " & _
               "AND [REFR] LIKE '" & refrigerant.Trim & "%'"

            Return retrieveCompressorsBy(sql)
        End Function


        ''' <summary>Retrieves compressors that use the specified refrigerant.</summary>
        ''' <param name="refrigerant">Refrigerant that compressor should use</param>
        Shared Function RetrieveCompressors(ByVal refrigerant As String) As DataTable
            Dim sql = "SELECT * FROM AllData " & _
               "WHERE REFR = '" & refrigerant.Trim & "'"

            Return retrieveCompressorsBy(sql)
        End Function

        Shared Function RetrieveCompressors( _
        ByVal refrigerant As String, ByVal newCoeff As Boolean, ByVal voltage As String) As DataTable
            Dim sql As String
            If newCoeff = False Then
                sql = "SELECT * FROM [AllData] WHERE [compmodel] LIKE 'SC%' AND REFR ='" + refrigerant.Trim + "'"
            Else
                sql = "SELECT * FROM [Compr_Curves_10Cof] WHERE [compmodel] LIKE 'SC%' AND [refr] ='" + refrigerant.Trim + "' AND [Voltage] = " + voltage
            End If

            Return retrieveCompressorsBy(sql)
        End Function


        Shared Function RetrieveCompressorDescriptions( _
        ByVal refrigerant As String, ByVal newCoeff As Boolean, ByVal voltage As String) As DataTable
            Dim row As DataRow

            ' retrieves table of all compressors w/ refrigerant
            Dim compressorsTable = RetrieveCompressors(refrigerant, newCoeff, voltage)
            ' adds description column
            compressorsTable.Columns.Add("Description", GetType(String))

            ' creates a list of compressor descriptions from table
            For Each row In compressorsTable.Rows
                If newCoeff = False Then
                    ' adds a description to the list, 'model        HP: hp'
                    row("Description") = row("compmodel").ToString.PadRight(13) & "HP: " & row("hp").ToString
                Else
                    row("Description") = row("Model").ToString.PadRight(13) & "    HP: " & row("hp").ToString
                End If
            Next

            Return compressorsTable
        End Function


        Shared Function RetrieveCompressors2(ByVal refrigerant As String, Optional ByVal isNewCoeff As Boolean = False) As DataTable
            Dim sql = "SELECT * FROM AllData " & _
                      "WHERE REFR LIKE '" & refrigerant.Trim & "%'"

            If Not isNewCoeff Then
                sql = "SELECT * FROM AllData WHERE REFR LIKE '" & refrigerant.Trim & "%'"
            Else
                sql = "SELECT ad.* FROM AllData ad inner join Compr_Curves_10cof cc on cc.compfile = ad.compfile  WHERE ad.REFR LIKE '" & refrigerant.Trim & "%'"
            End If

            Return retrieveCompressorsBy(sql)
        End Function

        'todo: remove if not used
        Shared Function RetrieveCompressorVolts() As List(Of String)
            Dim rdr As IDataReader

            Dim sql = "SELECT DISTINCT [Voltage] FROM [Compr_Curves_10cof] WHERE [Voltage] IS NOT NULL"
            Dim con = Common.CreateConnection(Common.CompressorDbPath)
            Dim com = con.CreateCommand
            com.CommandText = sql

            Dim voltage As New List(Of String)
            Dim v As Double

            Try
                con.Open()
                rdr = com.ExecuteReader()
                While rdr.Read() <> False
                    v = CDbl(rdr.GetInt32(0))
                    voltage.Add(CStr(System.Math.Round(v)))
                End While
            Finally
                If con.State <> ConnectionState.Closed Then _
                   con.Close()
            End Try

            Return voltage
        End Function


        Shared Function RetrieveCompressorModelsForReps(ByVal chillerModel As String) As IList(Of String)
            Dim connection = Common.CreateConnection(Common.CompressorDbPath)
            Dim command = connection.CreateCommand()
            Dim sql = "SELECT [compmodel] FROM [All Data] WHERE [comptype]='SCREW'"
            command.CommandText = sql

            Dim reader As IDataReader
            Dim models = New List(Of String)
            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read()
                    models.Add(reader("compmodel").ToString)
                End While
            Finally
                If connection.State <> ConnectionState.Closed Then _
                   connection.Close()
            End Try

            Return models
        End Function

        ''' <summary>Retrieves compressor models for the provided chiller model</summary>
        ''' <param name="chillerModel">The chiller model to retrieve the compressor models for</param>
        ''' <returns>List of compressor models</returns>
        Shared Function RetrieveCompressorModels(ByVal chillerModel As String) As List(Of String)
            Dim rdr As IDataReader

            Dim sql = "SELECT [" & chillerModel & "] " & _
               "FROM Rep_comp_22 " & _
               "ORDER BY [" & chillerModel & "]"

            Dim con = Common.CreateConnection(Common.CompressorDbPath)
            Dim com = con.CreateCommand
            com.CommandText = sql
            Dim models = New List(Of String)

            Try
                con.Open()
                rdr = com.ExecuteReader()
                While rdr.Read()
                    If rdr.GetString(0) <> "NA" Then _
                       models.Add(rdr.GetString(0))
                End While
            Finally
                If rdr IsNot Nothing Then rdr.Close()
                If con.State <> ConnectionState.Closed Then con.Close()
            End Try

            Return models
        End Function


        '''' <summary>
        '''' Retrieves refrigerants that the specified compressor can use.
        '''' </summary>
        '''' <param name="compressorModel">
        '''' Compressor model whose refrigerants are being determined
        '''' </param>
        'Shared Function RetrieveRefrigerants(compressorModel As String) As List(Of String)
        '   Dim reader As IDataReader
        '   Dim refrigerants As New List(Of String)

        '   Dim sqlCommand = _
        '      "SELECT [refr] " & _
        '      "FROM ALLDATA " & _
        '      "WHERE [COMPMODEL] = '" + compressorModel + "'"

        '   Dim con = Common.CreateConnection(Common.CompressorDbPath)
        '   Dim com = con.CreateCommand
        '   com.CommandText = sqlCommand

        '   Try
        '      con.Open()
        '      reader = com.ExecuteReader()
        '      While reader.Read()
        '         refrigerants.Add(reader.GetString(0))
        '      End While
        '   Finally
        '      If Not (reader Is Nothing) Then reader.Close()
        '      If con.State <> ConnectionState.Closed Then con.Close()
        '   End Try

        '   Return refrigerants
        'End Function


        ''' <summary>Retrieves compressor safety information
        ''' </summary>
        ''' <param name="compressorModel">Compressor model
        ''' </param>
        ''' <param name="refrigerant">Refrigerant
        ''' </param>
        ''' <returns>Compressor safety information
        ''' </returns>
        ''' <history>[CASEYJ]	6/14/2005	Created
        ''' </history>
        Shared Function RetrieveCompressorSafety( _
        ByVal compressorModel As String, ByVal refrigerant As String) As CompressorSafety
            Dim rdr As IDataReader

            Dim sql = _
               "SELECT * FROM AllData " & _
               "WHERE [compModel] = '" & compressorModel & "' " & _
               "AND [REFR] = '" & refrigerant & "'"

            Dim compressor = New CompressorSafety
            Dim con = Common.CreateConnection(Common.CompressorDbPath)
            Dim com = con.CreateCommand
            com.CommandText = sql
            Try
                con.Open()
                rdr = com.ExecuteReader()
                While rdr.Read()
                    With rdr
                        compressor.MinSuctionTemperature = CDbl(.Item("minst"))
                        compressor.MinCondensingTemperature = CDbl(.Item("minct"))
                        compressor.MaxSuctionTemperature = CDbl(.Item("maxst"))
                        compressor.MaxCondensingTemperature = CDbl(.Item("maxct"))
                        compressor.Unloading = .Item("unloading").ToString
                        compressor.HeatingAndCoolingFan = .Item("hcfan").ToString
                        compressor.Demandc = .Item("demandc").ToString
                        compressor.LiquidInjection = .Item("liqinj").ToString
                        compressor.OilCooling = .Item("oilcool").ToString
                    End With
                End While
            Catch dbEx As DataException
                Throw dbEx
            Finally
                If Not (rdr Is Nothing) Then rdr.Close()
                If con.State <> ConnectionState.Closed Then con.Close()
            End Try

            Return compressor
        End Function


        ''' <summary>Retrieves condensing and suction temperature limits
        ''' </summary>
        ''' <param name="compressorFileName">Compressor file with temperature limits
        ''' </param>
        ''' <returns>Table containing temperature limits.
        ''' Columns: "minst", "maxst", "minct", "maxct"
        ''' </returns>
        ''' <history>[CASEYJ]	6/23/2005	Created
        ''' </history>
        Shared Function RetrieveCompressorTemperatureLimits(ByVal compressorFileName As String) As DataTable
            Dim ds As New DataSet

            Dim sql = _
               "SELECT [minst], [maxst], [minct], [maxct] " & _
               "FROM [All Data] " & _
               "WHERE [compfile] = '" & compressorFileName & "'"
            Dim con = Common.CreateConnection(Common.CompressorDbPath)
            Dim cmd = con.CreateCommand
            cmd.CommandText = sql

            Dim adapter = Common.CreateAdapter(cmd)
            Dim limitsTable = New DataTable("TemperatureLimits")
            Try
                con.Open()
                ' fills dataset with condensing and suction temperature limits
                adapter.Fill(ds)
            Finally
                If con.State <> ConnectionState.Closed Then con.Close()
            End Try

            Return ds.Tables(0)
        End Function

#End Region

#Region " New Coefficients Testing"

        ''' <summary>Gets coefficients based on the specified compressor file name</summary>
        Shared Function GetCoefficients(ByVal compressorFileName As String) As Coefficients
            Dim c As New Coefficients
            Dim table = retrieveCoefficients(compressorFileName)

            If table.Rows.Count = 0 Then
                ' using this for now, need to standardize missing data exception handling
                Throw New System.Data.RowNotInTableException("Compressor's 10 coefficients cannot be retrieved. Compressor file, " & compressorFileName & ", cannot be found.")
            End If

            With table.Rows(0)
                If .Item("C0") Is System.DBNull.Value Then
                    ' using this for now even though it's not very accurate, need to standardize missing data exception handling
                    Throw New System.Data.RowNotInTableException("Compressor's 10 coefficients cannot be retrieved. Coefficients are missing for the compressor file, " & compressorFileName & ".")
                End If

                c.C0 = CDbl(.Item("C0"))
                c.C1 = CDbl(.Item("C1"))
                c.C2 = CDbl(.Item("C2"))
                c.C3 = CDbl(.Item("C3"))
                c.C4 = CDbl(.Item("C4"))
                c.C5 = CDbl(.Item("C5"))
                c.C6 = CDbl(.Item("C6"))
                c.C7 = CDbl(.Item("C7"))
                c.C8 = CDbl(.Item("C8"))
                c.C9 = CDbl(.Item("C9"))

                c.A0 = CDbl(.Item("A0"))
                c.A1 = CDbl(.Item("A1"))
                c.A2 = CDbl(.Item("A2"))
                c.A3 = CDbl(.Item("A3"))
                c.A4 = CDbl(.Item("A4"))
                c.A5 = CDbl(.Item("A5"))
                c.A6 = CDbl(.Item("A6"))
                c.A7 = CDbl(.Item("A7"))
                c.A8 = CDbl(.Item("A8"))
                c.A9 = CDbl(.Item("A9"))

                c.W0 = CDbl(.Item("W0"))
                c.W1 = CDbl(.Item("W1"))
                c.W2 = CDbl(.Item("W2"))
                c.W3 = CDbl(.Item("W3"))
                c.W4 = CDbl(.Item("W4"))
                c.W5 = CDbl(.Item("W5"))
                c.W6 = CDbl(.Item("W6"))
                c.W7 = CDbl(.Item("W7"))
                c.W8 = CDbl(.Item("W8"))
                c.W9 = CDbl(.Item("W9"))
            End With
            Return c
        End Function


        ''' <summary>New coefficients; 10 rather than 7; based on temperature rather than pressure</summary>
        Public Class Coefficients
            Public A0, A1, A2, A3, A4, A5, A6, A7, A8, A9 As Double
            Public C0, C1, C2, C3, C4, C5, C6, C7, C8, C9 As Double
            Public W0, W1, W2, W3, W4, W5, W6, W7, W8, W9 As Double
        End Class

#End Region



        Private Shared Function retrieveCompressorsBy(ByVal sql As String) As DataTable
            Dim ds As New DataSet
            Dim con = Common.CreateConnection(Common.CompressorDbPath)
            Dim cmd = con.CreateCommand
            cmd.CommandText = sql
            Dim adapter = Common.CreateAdapter(cmd)
            Try
                con.Open()
                adapter.Fill(ds)
            Finally
                If con.State <> ConnectionState.Closed Then _
                   con.Close()
            End Try

            Return ds.Tables(0)
        End Function

        ''' <summary>Retrieves new coefficients based on temperature (not pressure)</summary>
        Private Shared Function retrieveCoefficients(ByVal compressorFileName As String) As DataTable
            If compressorFileName Is Nothing Then
                Throw New System.ArgumentNullException("Compressor's 10 coefficients cannot be retrieved. Compressor file name is null.")
            End If

            Dim connectionString As String
            connectionString = DataAccess.Common.GetConnectionString(DataAccess.Common.CompressorDbPath)
            Dim connection As IDbConnection
            connection = Common.CreateConnection(connectionString)

            Dim sql As String = "SELECT * FROM Compr_Curves_10cof WHERE [compfile]='" & compressorFileName & "'"
            Dim command As IDbCommand
            command = connection.CreateCommand()
            command.CommandText = sql

            Dim adapter As IDbDataAdapter = Common.CreateAdapter(command)
            Dim ds As New DataSet

            Try
                connection.Open()
                adapter.Fill(ds)
            Finally
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try

            Dim table As DataTable
            table = ds.Tables(0)
            table.TableName = "Coefficients"

            Return table
        End Function

    End Class


    ''' <summary>Compressor description contains model, file and horsepower.</summary>
    Public Class CompressorDescription

        Private Sub New()
            initializeToStringDelegate()
        End Sub

        Sub New(ByVal model As String, ByVal masterID As String, ByVal horsepower As String)
            MyClass.New()
            model_ = model
            masterID_ = masterID
            horsepower_ = horsepower
            oldModel_ = ""
        End Sub

        'Sub New(model As String, oldModel As String, file As String, horsepower As String)
        '   MyClass.New(model, file, horsepower)
        '   oldModel_ = oldModel
        '   ToStringPointer = AddressOf getOldDescription
        'End Sub


        ''' <summary>Compressor file name</summary>
        ReadOnly Property MasterID As String
            Get
                Return masterID_
            End Get
        End Property : Friend masterID_ As String


        ''' <summary>Compressor model</summary>
        ReadOnly Property Model As String
            Get
                Return model_
            End Get
        End Property : Friend model_ As String

        ReadOnly Property OldModel As String
            Get
                Return oldModel_
            End Get
        End Property : Private oldModel_ As String


        ''' <summary>Horsepower</summary>
        ReadOnly Property Horsepower As String
            Get
                Return horsepower_
            End Get
        End Property : Friend horsepower_ As String


        ReadOnly Property Description As String
            Get
                Return getDescription()
            End Get
        End Property

        'Private Function getCompressorDescription(ByVal model As String, ByVal horsepower As String) As String
        '    Dim d As String

        '    d = model.ToUpper
        '    ' padding aligns horsepowers for monospaced fonts
        '    d = d.PadRight(13)
        '    d &= "HP: " & horsepower

        '    Return d
        'End Function

        Private Function getCompressorDescription(ByVal model As String, ByVal masterID As String, ByVal horsepower As String) As String
            Dim d = model.ToUpper() & " (" & masterID & ")"
            d = d.PadRight(27)
            d &= "HP: " & horsepower
            Return d
        End Function



        Private Function getDescription() As String
            Return getCompressorDescription(Model, MasterID, Horsepower)
        End Function


#Region " ToString()"

        ''' <summary>Delegate (method signature) for ToString() method.</summary>
        Public Delegate Function ToStringSignature() As String

        ''' <summary>This delegate determines what is returned by the ToString() method.</summary>
        Public ToStringPointer As ToStringSignature

        Protected Overridable Sub initializeToStringDelegate()
            Me.ToStringPointer = AddressOf getDescription
        End Sub

        ''' <summary>Returns description of compressor by default</summary>
        Overrides Function ToString() As String
            Return Me.ToStringPointer.Invoke()
        End Function

#End Region

    End Class

End Namespace
