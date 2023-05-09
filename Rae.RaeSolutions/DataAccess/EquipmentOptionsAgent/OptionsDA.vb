Imports System.Collections.Generic
Imports DaEo = Rae.DataAccess.EquipmentOptions
Imports Da1 = RAE.RAESolutions.DataAccess
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.solutions
Imports System.Drawing
Imports System.Data


Namespace Rae.RaeSolutions.DataAccess.EquipmentOptionsAgent

    ''' <summary>Data access to equipment options database</summary>
    Public Class OptionsDA

#Region " Public methods"

        ''' <summary>Retrieves available options for the specified equipment</summary>
        ''' <param name="series">Equipment series</param>
        ''' <param name="model">Equipment model</param>
        ''' <param name="voltage">Unit voltage</param>
        ''' <returns>Available options for the specified equipment</returns>
        Shared Function RetrieveAvailableOptions(
        ByVal series As String, ByVal model As String, ByVal voltage As Integer, ByVal numFans As Integer, ByVal user As user, ByVal fanMotorPhase As Integer) As Da1.OptionsDS.EquipmentOptionDataTable
            Dim table = New Da1.OptionsDS.EquipmentOptionDataTable

            ' retrieves list of option objects
            Dim ops = DaEo.OptionsDataAccess.RetrieveAvailableOptions(series, model, voltage, numFans, fanMotorPhase)


            ops.Sort(New RAE.DataAccess.EquipmentOptions.OptionComparer)


            addCompressorWarrantyOp(ops, series, model)
            'If user.IsEmployee Then _
            addPumpPackageOp(ops, series, model)

            ' converts list to typed DataTable
            table = OptionToTable(ops, model, fanMotorPhase, series, voltage)

            Return table
        End Function

        Private Shared Sub addCompressorWarrantyOp(ByVal ops As List(Of DaEo.Option), ByVal series As String, ByVal model As String)
            If series = "DD" Or series = "DM" Or series = "DS" Or series Like "2*" Or series Like "3*" Or series Like "4*" Or series = "LUI" Or series = "LUO" Or series = "RS" Or series Like "N*" Or series Like "BLU*" Then
                Dim op = New DaEo.Option

                op.Code = "FYCW"
                op.MasterId = 999888
                op.Description = "4 Year Extended Compressor Warranty (Net)"
                op.Details = "sss"
                op.Category = "Warranty and Parts"
                op.Voltage = 0
                op.PricingId = 999777
                op.Equipment.Series = series
                op.Equipment.Model = model

                Dim warcost As Double = GetCompressorWarrantyCost(series, model)
                op.Price = warcost
                op.Quantity = 1
                If warcost = 999998 Then
                    op.Description += " (Contact Factory for Price)"
                End If

                If series Like "35*" OrElse series Like "20*" Then
                    op.Details = "Extends the Standard 1 year parts warranty for an additional 4 years (5 yrs total) on the compressors only. Parts warranty - labor, crane, and refrigerant costs are not included."
                End If


                ops.Add(op)
            End If
        End Sub

        Private Shared Sub addPumpPackageOp(ByVal ops As List(Of DaEo.Option), ByVal series As String, ByVal model As String)
            If Not series Like "3*" Or series Like "35*" Then Exit Sub

            Dim op = New DaEo.Option

            op.PricingId = 999990
            op.Code = "PP"
            op.Description = "Pump package (must select to determine price)"
            op.Category = "Pump"
            op.Equipment.Series = series
            op.Equipment.Model = model
            op.Per = "unit"
            op.Price = 0
            op.Quantity = 1
            op.Voltage = 0

            ops.Add(op)
        End Sub

        Shared Function GetCompressorCost(ByVal compressor As String) As Double

            Dim connstr As String = Da1.Common.GetConnectionString(Da1.Common.CompressorDbPath)
            Dim warcost As Double = 999998

            Dim myconn As idbconnection = Common.CreateConnection(Common.CompressorDbPath) 'New System.Data.OleDb.OleDbConnection
            Dim mycommand As IDbCommand = myconn.CreateCommand 'New System.Data.OleDb.OleDbCommand
            Dim rs As IDataReader

            Try
                myconn.Open()
                mycommand.CommandText = "SELECT [WarrantyPrice] " & _
                                        "FROM [Warranty] " & _
                                        "WHERE [MasterID] = '" & compressor & "'"
                rs = mycommand.ExecuteReader()
                If rs.Read() Then
                    If Not IsDBNull(rs("WarrantyPrice")) Then
                        warcost = Val(rs("WarrantyPrice"))
                    Else
                        warcost = 999998
                    End If
                End If
            Catch ex As DataException
                warcost = 999998
            Finally
                If Not IsNothing(rs) Then rs.Close()
                If myconn.State <> System.Data.ConnectionState.Closed Then myconn.Close()
            End Try

            Return warcost

        End Function


        Shared Function GetCompOilDel(ByVal compressor As String) As String
            GetCompOilDel = ""

            If String.IsNullOrEmpty(compressor) Then Return ""

            Dim myconn As IDbConnection = Common.CreateConnection(Common.CompressorDbPath) 'New System.Data.OleDb.OleDbConnection
            Dim mycommand As IDbCommand = myconn.CreateCommand 'New System.Data.OleDb.OleDbCommand
            Dim rs As IDataReader

            Try
                myconn.Open()
                mycommand.CommandText = "SELECT [TemperatureRange], OilDistSystem " & "FROM [Master] " & "WHERE [MasterID] = '" & compressor & "'"
                rs = mycommand.ExecuteReader()
                If rs.Read() Then
                    GetCompOilDel = rs("OilDistSystem").ToString.PadLeft(1).Substring(0, 1).Trim & rs("TemperatureRange").ToString.PadLeft(1).Substring(0, 1).Trim
                End If
            Catch ex As DataException
                Throw ex
            Finally
                If Not IsNothing(rs) Then rs.Close()
                If myconn.State <> System.Data.ConnectionState.Closed Then myconn.Close()
            End Try



        End Function


        Public Shared Function GetCompressorWarrantyCost(ByVal series As String, ByVal model As String) As Double


            ' Return -999

            Dim connstr As String
            Dim warcost As Double = 0
            Dim compcost As Double = 0

            Dim tbl As String = String.Empty
            Dim model_column As String = "Model"

            If series Like "D*" Or series Like "2*" Or series Like "LU*" Or series = "RS" Or series Like "N*" Or series Like "BLU*" Then
                connstr = Da1.Common.GetConnectionString(Da1.Common.CondensingUnitDbPath)
                tbl = Da1.Common.CommonTableName(Da1.Common.CondensingUnitDbPath, "Table5")
            ElseIf series Like "35*" Then
                connstr = Da1.Common.GetConnectionString(Da1.Common.ChillerDbPath)
                tbl = rae.solutions.evaporative_condenser_chillers.table.table_name
                model_column = "TSI Model"
            ElseIf series Like "3*" Then
                connstr = Da1.Common.GetConnectionString(Da1.Common.ChillerDbPath)
                tbl = Da1.Common.CommonTableName(Da1.Common.ChillerDbPath, "Table5")
            End If

            Dim myconn As IDbConnection = Common.CreateConnection
            myconn.ConnectionString = connstr
            Dim mycommand As IDbCommand = myconn.CreateCommand
            Dim rs As IDataReader

            Try

                myconn.ConnectionString = (connstr)
                myconn.Open()
                mycommand.CommandText = "SELECT * " & _
                                        "FROM [" & tbl & "] " & _
                                        "WHERE [" & model_column & "] = '" & series & model & "'"
                rs = mycommand.ExecuteReader()
                If rs.Read() Then
                    For i As Integer = 1 To 2
                        If Not IsDBNull(rs("Compr_Qty_" & i)) AndAlso Val(rs("Compr_Qty_" & i)) > 0 Then
                            If Not IsDBNull(rs("CompressorMasterID" & i)) Then
                                If Trim(rs("CompressorMasterID" & i).ToString) > " " Then
                                    compcost = GetCompressorCost(Trim(rs("CompressorMasterID" & i).ToString))
                                    If compcost = 999998 Then
                                        warcost = 999998
                                        Exit Try
                                    Else
                                        warcost += compcost * Val(rs("Compr_Qty_" & i))
                                    End If
                                End If
                            End If
                        End If
                    Next
                End If
            Catch ex As DataException
                Throw ex
            End Try

            If Not IsNothing(rs) Then rs.Close()
            If myconn.State <> System.Data.ConnectionState.Closed Then myconn.Close()

            ' take 40% of our total cost
            'If warcost <> 999998 Then warcost() *= 0.4 (This multiplier is now in the CompressorWarranty VB6 project.)

            Return warcost

        End Function


        Shared Function GetCompressorModelDefault(ByVal series As String, ByVal model As String) As String

            Dim connstr As String

            GetCompressorModelDefault = ""

            Dim tbl As String = String.Empty
            Dim model_column As String = "Model"

            If series Like "D*" Or series Like "2*" Or series Like "LU*" Or series = "RS" Or series Like "N*" Then
                connstr = Da1.Common.GetConnectionString(Da1.Common.CondensingUnitDbPath)
                tbl = Da1.Common.CommonTableName(Da1.Common.CondensingUnitDbPath, "Table5")
            ElseIf series Like "35*" Then
                connstr = Da1.Common.GetConnectionString(Da1.Common.ChillerDbPath)
                tbl = rae.solutions.evaporative_condenser_chillers.table.table_name
                model_column = "TSI Model"
            ElseIf series Like "3*" Then
                connstr = Da1.Common.GetConnectionString(Da1.Common.ChillerDbPath)
                tbl = Da1.Common.CommonTableName(Da1.Common.ChillerDbPath, "Table5")
            Else
                Return ""
            End If

            Dim myconn As IDbConnection = Common.CreateConnection
            myconn.ConnectionString = connstr
            Dim mycommand As IDbCommand = myconn.CreateCommand
            Dim rs As IDataReader

            Try

                myconn.ConnectionString = (connstr)
                myconn.Open()
                mycommand.CommandText = "SELECT * " & _
                                        "FROM [" & tbl & "] " & _
                                        "WHERE [" & model_column & "] = '" & series & model & "'"
                rs = mycommand.ExecuteReader()
                If rs.Read() Then
                    For i As Integer = 1 To 2
                        If Not IsDBNull(rs("CompressorMasterID" & i)) AndAlso Not IsDBNull(rs("Compr_Qty_" & i)) AndAlso Val(rs("Compr_Qty_" & i)) > 0 Then
                            If Not IsDBNull(rs("CompressorMasterID" & i)) Then
                                If Trim(rs("CompressorMasterID" & i).ToString) > " " Then
                                    GetCompressorModelDefault = Trim(rs("CompressorMasterID" & i).ToString)



                                End If
                            End If
                        End If
                    Next
                End If
            Catch ex As DataException
                Throw ex
            End Try

            If Not IsNothing(rs) Then rs.Close()
            If myconn.State <> System.Data.ConnectionState.Closed Then myconn.Close()

            ' take 40% of our total cost
            'If warcost <> 999998 Then warcost() *= 0.4 (This multiplier is now in the CompressorWarranty VB6 project.)



        End Function





        Public Shared Function GetObligatoryOptionsBySeries(ByVal series As String) As List(Of String)

            Dim connstr As String

            GetObligatoryOptionsBySeries = New List(Of String)

            Dim tbl As String = String.Empty

            connstr = Da1.Common.GetConnectionString(Da1.Common.EquipmentPricingDbPath)
            tbl = "ObligatoryOptionCategoriesBySeries"



            Dim myconn As IDbConnection = Common.CreateConnection
            myconn.ConnectionString = connstr
            Dim mycommand As IDbCommand = myconn.CreateCommand
            Dim rs As IDataReader

            Try

                myconn.ConnectionString = (connstr)
                myconn.Open()
                mycommand.CommandText = "SELECT Category " & _
                                        "FROM [" & tbl & "] inner join Series on Series.ID = " & tbl & ".SeriesID " & _
                                        "WHERE [Series].Series = '" & series & "'"
                rs = mycommand.ExecuteReader()
                While rs.Read()
                    GetObligatoryOptionsBySeries.Add(rs("Category").ToString.ToLower)
                End While

            Catch ex As DataException
                Throw ex
            End Try

            If Not IsNothing(rs) Then rs.Close()
            If myconn.State <> System.Data.ConnectionState.Closed Then myconn.Close()



        End Function





        ''' <summary>Retrieves standard options for the specified equipment</summary>
        ''' <param name="series">Equipment series</param>
        ''' <param name="model">Equipment model</param>
        ''' <param name="voltage">Unit voltage</param>
        ''' <returns>Standard options</returns>
        Shared Function RetrieveStandardOptions(
        ByVal series As String, ByVal model As String, ByVal voltage As Integer, ByVal numFans As Integer, ByVal fanMotorPhase As Integer) As Da1.OptionsDS.EquipmentOptionDataTable
            ' gets standard options as list of objects
            Dim ops = DaEo.OptionsDataAccess.RetrieveStandardOptions(series, model, voltage, numFans, fanMotorPhase)
            ' converts to typed table
            Dim table = OptionToTable(ops, model, fanMotorPhase, series, voltage)

            Return table
        End Function

        ''' <summary>Retrieves equipment's base list price</summary>
        ''' <param name="series">Equipment series</param>
        ''' <param name="model">Equipment model</param>
        ''' <returns>Base list price</returns>
        Shared Function RetrieveBaseListPrice(ByVal series As String, ByVal model As String) As Double
            Dim price = DaEo.OptionsDataAccess.RetrieveBaseListPrice(series, model)

            Return price
        End Function

        ''' <summary>Retrieves option based on its code and voltage</summary>
        ''' <param name="code">Option code</param>
        ''' <param name="voltage">Voltage</param>
        ''' <param name="series">Series</param>
        ''' <param name="model">Model</param>
        ''' <returns>Option</returns>
        Shared Function RetrieveOption(
        ByVal series As String, ByVal model As String, ByVal code As String, ByVal voltage As Integer, ByVal numFans As Integer, ByVal fanMotorPhase As Integer) As Da1.OptionsDS.EquipmentOptionDataTable
            Dim table As New Da1.OptionsDS.EquipmentOptionDataTable
            Dim ops As New List(Of DaEo.Option)

            ' retrieves option and adds to list
            Dim tempOption As DaEo.Option = DaEo.OptionsDataAccess.RetrieveOption(series, model, code, voltage, numFans, fanMotorPhase)
            If Not tempOption Is Nothing Then

                ops.Add(tempOption)

            End If
            ' converts list to table
            table = OptionToTable(ops, model, fanMotorPhase, series, voltage)

            Return table
        End Function

        ''' <summary>Retrieves the option with the pricing ID.</summary>
        ''' <param name="pricingId">
        ''' Identifies equipment/option combination. Id can be used to get info about the combination.
        ''' </param>
        Shared Function RetrieveOption(ByVal pricingId As Integer) As EquipmentOption
            Dim op = DaEo.OptionsDataAccess.RetrieveOption(pricingId)

            Dim equipOp As EquipmentOption
            If op IsNot Nothing Then
                equipOp = New EquipmentOption
                equipOp.Import(op)
            End If

            Return equipOp
        End Function

        Shared Function GetObsoleteOption(ByVal pricingId As Integer) As EquipmentOption
            Dim op = DaEo.OptionsDataAccess.RetrieveObsoleteOption(pricingId)

            Dim equipOp As EquipmentOption
            If op IsNot Nothing Then
                equipOp = New EquipmentOption
                equipOp.Import(op)
            End If

            Return equipOp
        End Function

        Shared Function IsObsolete(ByVal pricingId As Integer) As Boolean
            Return DaEo.OptionsDataAccess.IsObsolete(pricingId)
        End Function


        ''' <summary>Converts option list to typed table</summary>
        ''' <remarks>Table allows more functionality with grids</remarks>
        Shared Function OptionToTable(ByVal ops As List(Of DaEo.Option), ByVal model As String, ByVal fanMotorPhase As Integer, ByVal series As String, ByVal unitVoltage As Integer) As Da1.OptionsDS.EquipmentOptionDataTable
            Dim ds As New RAE.RAESolutions.DataAccess.OptionsDS
            Dim row As RAE.RAESolutions.DataAccess.OptionsDS.EquipmentOptionRow

            For Each op As DaEo.Option In ops
                row = ds.EquipmentOption.NewEquipmentOptionRow
                row.MasterId = op.MasterId
                row.PricingId = op.PricingId
                row.Code = op.Code
                row.Description = op.Description
                row.Details = op.Details
                row.Category = op.Category
                row.Price = op.Price
                row.Quantity = op.Quantity
                row.IsQuantityReadOnly = op.IsQuantityReadOnly
                row.Voltage = op.Voltage
                row.IsVoltageDependent = op.IsVoltageDependent
                row.IsDependent = op.IsDependentCommonOption
                row.ContactFactory = op.ContactFactory
                If op.IsStandard Then
                    row.Selected = True
                    row.IsSelectedReadOnly = True
                ElseIf op.Code = "EM09" AndAlso series.ToUpper.StartsWith("AWSM") AndAlso fanMotorPhase = 1 Then
                    row.Selected = True
                    row.IsSelectedReadOnly = False
                ElseIf op.Code = "EM09" AndAlso series.ToUpper = "WIBR" AndAlso fanMotorPhase = 1 Then
                    row.Selected = True
                    row.IsSelectedReadOnly = False
                ElseIf op.Code = "EM09" AndAlso series.ToUpper = "BALV" AndAlso fanMotorPhase = 1 Then
                    row.Selected = True
                    row.IsSelectedReadOnly = False
                ElseIf op.Code = "EV01" AndAlso unitVoltage = 575 Then
                    row.Selected = True
                    row.IsSelectedReadOnly = False
                ElseIf op.Code = "EV01" AndAlso Not unitVoltage = 575 Then
                    row.Selected = False
                    row.IsSelectedReadOnly = False
                Else
                    row.Selected = False
                    row.IsSelectedReadOnly = False
                End If




                row.Per = op.Per
                ds.EquipmentOption.AddEquipmentOptionRow(row)

            Next

            Return ds.EquipmentOption
        End Function

#End Region

    End Class

End Namespace
