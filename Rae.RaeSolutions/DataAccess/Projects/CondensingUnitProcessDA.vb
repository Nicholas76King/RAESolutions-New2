Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

Imports Rae.Data.Sql
Imports Rae.Io.Text
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.DataAccess.Projects
Imports CT1 = RAE.RAESolutions.DataAccess.Projects.Tables.CondensingUnitProcessTable
Imports ET1 = RAE.RAESolutions.DataAccess.Projects.Tables.EquipmentTable
Imports RAE.RAESolutions.DataAccess.Projects.Tables.CondensingUnitProcessTable
Imports COT = Rae.RaeSolutions.DataAccess.Projects.Tables.CondensingUnitTable
Imports CNull = Rae.ConvertNull
Imports OtherCostsDA = Rae.RaeSolutions.DataAccess.Projects.OtherEquipmentCostsDA
Imports CO7 = RAE.RAESolutions.DataAccess.Projects.Tables.CondensingUnitTable
Imports Rae.solutions



Namespace Rae.RaeSolutions.DataAccess.Projects


    Public Class CondensingUnitProcessDA

        Public Shared Function Retrieve(ByVal id As item_id) As CondensingUnitProcessItem
            Dim condensingunit As CondensingUnitProcessItem

            ' retrieves fluidCooler
            condensingunit = RetrieveCondensingUnit(id)

            Return condensingunit
        End Function

        Public Shared Function Retrieve(ByVal id As item_id, ByVal RevNumber As Single) As CondensingUnitProcessItem
            Dim condensingunit As CondensingUnitProcessItem

            ' retrieves fluidCooler
            condensingunit = RetrieveCondensingUnit(id, RevNumber)

            Return condensingunit
        End Function

        Private Shared Function RetrieveCondensingUnit(ByVal id As item_id, Optional ByVal RevNumber As Single = -1, Optional ByVal ProjRevision As Single = -1) As CondensingUnitProcessItem
            Dim connection As IDbConnection
            Dim command As IDbCommand
            Dim reader As IDataReader
            Dim connectionString As String
            'Dim sql As New StringBuilder
            Dim sql As String
            'Dim equipmentId, projectId As ItemId
            'Dim name As String
            'Dim division As Business.Division 

            Dim condensingunit As CondensingUnitProcessItem

            connectionString = Common.GetConnectionString(Common.ProjectsDbPath)

            If RevNumber > -1 Then
                ' Get specified revision number...
                sql = "SELECT * FROM CondensingUnitProcesses " & _
                      "WHERE ProcessID='" & id.Id & "' " & _
                      "AND [Revision] = " & RevNumber '& _
                '" AND [ProjectRevision] = " & ProjRevision
            Else
                ' Get latest revision number
                sql = "SELECT * FROM CondensingUnitProcesses " & _
                      "WHERE ProcessID='" & id.Id & "' " & _
                      "ORDER BY [Revision] DESC"
            End If

            connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)

            command = connection.CreateCommand 'New OleDbCommand(sql, connection)
            command.CommandText = sql

            Try
                connection.Open()
                reader = command.ExecuteReader()
                If reader.Read Then
                    ' retrieves values required to construct a fluid cooler equipment item
                    'equipmentId = New ItemId(reader(ET.TableName & "." & ET.EquipmentId).ToString)
                    'projectId = New ItemId(reader(ET.ProjectId).ToString)
                    'name = reader(ET.Name).ToString
                    'GetEnumValue(reader(ET.Division).ToString, division)

                    ' constructs
                    'condensingunit = New condensingunitProcessItem(name, division, equipmentId, New ProjectManager(projectId))
                    condensingunit = New CondensingUnitProcessItem(id)

                    ' retrieves the rest of the properties
                    With condensingunit
                        ' DBNull.Value.ToString = "", no exception is raised
                        ' TEST: DateGenerated is set by ID?
                        '.MetaData.Author = reader(ET.Author).ToString


                        .Altitude = CDbl(reader("Altitude").ToString)
                        .AmbientTemperature = CDbl(reader("AmbientTemperature"))
                        .Capacity = CDbl(reader("Capacity"))
                        .CircuitsPerUnit = CDbl(reader("CircuitsPerUnit"))
                        .CoilFinWidth1 = CDbl(reader("CoilFinWidth1"))
                        .CoilFinWidth2 = CDbl(reader("CoilFinWidth2"))
                        .CoilFinWidth3 = CDbl(reader("CoilFinWidth3"))
                        .CoilFinWidth4 = CDbl(reader("CoilFinWidth4"))
                        .CoilRows1 = CDbl(reader("CoilRows1"))
                        .CoilRows2 = CDbl(reader("CoilRows2"))
                        .CoilRows3 = CDbl(reader("CoilRows3"))
                        .CoilRows4 = CDbl(reader("CoilRows4"))
                        .CoilSubCoolingPercentage1 = CDbl(reader("CoilSubCoolingPercentage1"))
                        .CoilSubCoolingPercentage2 = CDbl(reader("CoilSubCoolingPercentage2"))
                        .CoilSubCoolingPercentage3 = CDbl(reader("CoilSubCoolingPercentage3"))
                        .CoilSubCoolingPercentage4 = CDbl(reader("CoilSubCoolingPercentage4"))
                        .Compressor = reader("Compressor").ToString
                        .Compressor1 = reader("Compressor1").ToString
                        .Compressor2 = reader("Compressor2").ToString
                        .Compressor3 = reader("Compressor3").ToString
                        .Compressor4 = reader("Compressor4").ToString
                        .CompressorPerUnit = CDbl(reader("CompressorPerUnit"))
                        .CompressorQuantity1 = CDbl(reader("CompressorQuantity1"))
                        .CompressorQuantity2 = CDbl(reader("CompressorQuantity2"))
                        .CompressorQuantity3 = CDbl(reader("CompressorQuantity3"))
                        .CompressorQuantity4 = CDbl(reader("CompressorQuantity4"))
                        .CondensingUnitModel = reader("CondensingUnitModel").ToString
                        .CondensingUnitsRequired = CDbl(reader("CondensingUnitsRequired"))
                        .CondensingUnitSeries = reader("CondensingUnitSeries").ToString
                        .CreatedBy = reader("CreatedBy").ToString
                        .CustomCondensingUnitModel = reader("CustomCondensingUnitModel").ToString
                        .FanDia1 = reader("FanDia1").ToString
                        .FanDia2 = reader("FanDia2").ToString
                        .FanDia3 = reader("FanDia3").ToString
                        .FanDia4 = reader("FanDia4").ToString
                        .FanQuantity1 = CDbl(reader("FanQuantity1"))
                        .FanQuantity2 = CDbl(reader("FanQuantity2"))
                        .FanQuantity3 = CDbl(reader("FanQuantity3"))
                        .FanQuantity4 = CDbl(reader("FanQuantity4"))
                        .FinHeight1 = CDbl(reader("FinHeight1"))
                        .FinHeight2 = CDbl(reader("FinHeight2"))
                        .FinHeight3 = CDbl(reader("FinHeight3"))
                        .FinHeight4 = CDbl(reader("FinHeight4"))
                        .FinsPerInch1 = CDbl(reader("FinsPerInch1"))
                        .FinsPerInch2 = CDbl(reader("FinsPerInch2"))
                        .FinsPerInch3 = CDbl(reader("FinsPerInch3"))
                        .FinsPerInch4 = CDbl(reader("FinsPerInch4"))
                        .id = id
                        '.MetaData
                        .Model = reader("CondensingUnitModel").ToString
                        .name = reader("Name").ToString
                        .NoCondensingUnits = CBool(reader("NoCondensingUnits"))
                        .Notes = reader("Notes").ToString

                        ' Try to set project manager...
                        If ProcessItemDA.GetProjectID(id.Id) IsNot Nothing Then
                            .ProjectManager = New project_manager(ProcessItemDA.GetProjectID(id.Id))
                        End If

                        .ProcessRevisionDescription = reader("ProcessRevisionDescription").ToString
                        .ProjectRevision = CInt(reader("ProjectRevision"))
                        .RatingAltitude = CDbl(reader("RatingAltitude"))
                        .RatingAmbient = CDbl(reader("RatingAmbient"))
                        .RatingAmbientInterval = CDbl(reader("RatingAmbientInterval"))
                        .RatingAmbientStep = CDbl(reader("RatingAmbientStep"))
                        .RatingCatalog = CBool(reader("RatingCatalog"))
                        .RatingHertz = CDbl(reader("RatingHertz"))
                        .RatingRefrigerant = reader("RatingRefrigerant").ToString
                        .RatingSafety = CBool(reader("RatingSafety"))
                        .RatingSubCooling = CDbl(reader("RatingSubCooling"))
                        .RatingSuction = CDbl(reader("RatingSuction"))
                        .RatingSuctionInterval = CDbl(reader("RatingSuctionInterval"))
                        .RatingSuctionStep = CDbl(reader("RatingSuctionStep"))
                        .Refrigerant = reader("Refrigerant").ToString
                        .Revision = CSng(reader("Revision"))
                        .RevisionDate = CDate(reader("RevisionDate"))
                        .Runtime = CDbl(reader("RunTime"))
                        .RuntimeAdjust = CBool(reader("RunTimeAdjust"))
                        GetEnumValue(reader("RunType").ToString, .RunType)
                        .Series = reader("CondensingUnitSeries").ToString
                        .SuctionTemperature = CDbl(reader("SuctionTemperature"))
                        .Version = reader("Version").ToString
                        GetEnumValue(reader("Division").ToString, .Division)
                        .Voltage = CNull.ToInteger(reader("Voltage"), 460)
                        .Use10Coefficients = CNull.ToBoolean(reader("Use10Coefficients"))


                        If Not Double.TryParse(reader("TubeDiameter1").ToString, .TubeDiameter1) Then .TubeDiameter1 = 0.5
                        If Not Double.TryParse(reader("TubeDiameter2").ToString, .TubeDiameter2) Then .TubeDiameter2 = 0.5


                        .FinType1 = reader("FinType1").ToString
                        .TubeSurface1 = reader("TubeSurface1").ToString
                        .FinType2 = reader("FinType2").ToString
                        .TubeSurface2 = reader("TubeSurface2").ToString
                        '.TubeDiameter3 = CDbl(reader("TubeDiameter3"))
                        '.FinType3 = reader("FinType3").ToString
                        '.TubeSurface3 = reader("TubeSurface3").ToString
                        '.TubeDiameter4 = CDbl(reader("TubeDiameter4"))
                        '.FinType4 = reader("FinType4").ToString
                        '.TubeSurface4 = reader("TubeSurface4").ToString

                        .FanRPM1 = CDec(CNull.ToDouble(reader("FanRPM1")))
                        .FanRPM2 = CDec(CNull.ToDouble(reader("FanRPM2")))
                        .FanRPM3 = CDec(CNull.ToDouble(reader("FanRPM3")))
                        .FanRPM4 = CDec(CNull.ToDouble(reader("FanRPM4")))

                        .DOEModel = CNull.ToString(reader("DOEModel"))


                        If String.IsNullOrEmpty(.DOEModel) Then
                            Dim doeFlag As Boolean = New condensing_units.Repository().CheckDOE(reader("CondensingUnitModel").ToString)
                            If doeFlag Then
                                .DOEModel = "Yes"
                            Else
                                .DOEModel = "No"
                            End If
                        End If


                    End With
                End If
                'Catch ex As dataException
            Catch ex As Exception
                Throw ex
            Finally
                If reader IsNot Nothing Then reader.Close()
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try

            Return condensingunit
        End Function

        Public Shared Function Exists(ByVal id As String, Optional ByVal RevNum As Integer = -1, Optional ByVal ProjRevision As Single = -1) As Boolean
            Dim connection As IDbConnection
            Dim command As IDbCommand
            Dim reader As IDataReader
            Dim connectionString As String, sql As String
            Dim found As Boolean = False

            connectionString = Common.GetConnectionString(Common.ProjectsDbPath)
            connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)



            'sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}] = '{2}'", _
            '   PT.TableName, PT.ProjectId, id.ToString)
            sql = "SELECT * FROM Processes WHERE ID = '" + id + "'"
            'sql += " AND ProjectRevision = " & ProjRevision

            If RevNum > -1 Then
                sql += " AND Revision = " & RevNum
            End If

            'sql += " ORDER BY Revision DESC"

            command = connection.CreateCommand 'New OleDbCommand(sql, connection)
            command.CommandText = sql

            Try
                connection.Open()
                reader = command.ExecuteReader()
                ' checks if project exists
                Dim i As Integer = 0
                While reader.Read
                    i += 1
                End While
                If i > 0 Then
                    found = True
                End If
                'found = reader.HasRows()
            Catch ex As DataException
                Throw ex
            Finally
                If reader IsNot Nothing Then reader.Close()
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try

            Return found
        End Function

        Public Overloads Shared Function Create(ByVal condensingunit As CondensingUnitProcessItem) As Integer
            Dim connectionString As String
            Dim transaction As IDbTransaction
            Dim connection As IDbConnection
            Dim numRowsAffected As Integer

            Dim found As Boolean
            found = Exists(condensingunit.id.ToString)

            connectionString = Common.GetConnectionString(Common.ProjectsDbPath)
            connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)


            Try
                connection.Open()

                ' begins transaction (everything can be rolled back from the beginning of the transaction until it is committed)
                transaction = connection.BeginTransaction()

                If found = False Then
                    ' inserts only general process data into Processes Table
                    ProcessItemDA.Create(connection, transaction, condensingunit, CT1.TableName)
                End If

                ' inserts values into condensingunitProcessesTable
                CreateItem(connection, transaction, condensingunit)
                '    commits transaction
                transaction.Commit()
            Catch ex As Exception
                ' rolls back transaction
                If Not transaction Is Nothing Then transaction.Rollback()
                Throw New ApplicationException("Attempt to create condensing unit equipment item failed. Transaction was rolled back.", ex)
            Finally
                If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
            End Try

            Return numRowsAffected
        End Function

        Public Shared Sub CreateItem(ByVal connection As IDbConnection, ByVal transaction As IDbTransaction, ByVal process As CondensingUnitProcessItem)
            Dim sqlCommand As String
            'Dim connection As iDbConnection
            Dim command As IDbCommand

            sqlCommand = SqlFactory.GetInsertCondensingUnitSql(process)

            command = connection.CreateCommand 'New OleDbCommand(sql, connection)
            command.CommandText = sqlCommand
            command.Transaction = transaction

            Dim numRowsAffected As Integer = command.ExecuteNonQuery()
        End Sub

        Public Shared Sub Update(ByVal process As CondensingUnitProcessItem)
            Dim connection As IDbConnection
            Dim command As IDbCommand
            Dim numRowsAffected As Integer
            Dim connectionString, sqlCommand As String

            connectionString = Common.GetConnectionString(Common.ProjectsDbPath)
            sqlCommand = SqlFactory.GetUpdateCondensingUnitSql(process)

            connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)

            command = connection.CreateCommand 'New OleDbCommand(sql, connection)
            command.CommandText = sqlCommand

            Try
                connection.Open()
                numRowsAffected = command.ExecuteNonQuery()
            Catch ex As DataException
                Throw
            Finally
                If Not connection.State.Equals(System.Data.ConnectionState.Closed) Then connection.Close()
            End Try

        End Sub

        ''' <summary>
        ''' 
        ''' SQL Factory
        ''' </summary>
        ''' <remarks></remarks>
        ''' <history></history>
        Private Class SqlFactory

            ''' <summary>
            ''' Gets SQL to insert chiller equipment item.
            ''' </summary>
            Public Shared Function GetInsertCondensingUnitSql(ByVal condensingUnit As CondensingUnitProcessItem) As String
                Dim affectedColumns As List(Of SqlColumn) = CondensingUnitColumns(condensingUnit)
                Dim builder As New SqlBuilder(affectedColumns, CT1.TableName)

                Return builder.GenerateInsertCommand()
            End Function


            ''' <summary>
            ''' Gets SQL to update chiller equipment item.
            ''' </summary>
            ''' <param name="condensingUnit">
            ''' Condensing unit equipment to update.
            ''' </param>
            ''' <returns>
            ''' SQL command to update condensing unit equipment.
            ''' </returns>
            Public Shared Function GetUpdateCondensingUnitSql(ByVal condensingUnit As CondensingUnitProcessItem) As String
                Dim affectedCols As List(Of SqlColumn) = CondensingUnitColumns(condensingUnit)
                Dim criteriaCols As New List(Of SqlColumn)
                criteriaCols.Add(New SqlColumn(CT1.ProcessID, SqlDataType.String, condensingUnit.id.Id))
                criteriaCols.Add(New SqlColumn(CT1.Revision, SqlDataType.Number, condensingUnit.Revision.ToString))
                Dim builder As New SqlBuilder(affectedCols, CT1.TableName, criteriaCols)

                Return builder.GenerateUpdateCommand()
            End Function


            ''' <summary>
            ''' Chiller equipment item columns
            ''' </summary>
            ''' <param name="chiller">
            ''' Chiller equipment item
            ''' </param>
            ''' <returns>
            ''' List of columns in table
            ''' </returns>
            Private Shared Function CondensingUnitColumns(ByVal condensingUnit As CondensingUnitProcessItem) As List(Of SqlColumn)
                Dim columns As New List(Of SqlColumn)

                With columns
                    .Add(New SqlColumn(CT1.CondensingUnitModel, SqlDataType.String, condensingUnit.Model))
                    .Add(New SqlColumn(CT1.Altitude, SqlDataType.Number, condensingUnit.Altitude.ToString))
                    .Add(New SqlColumn(CT1.AmbientTemperature, SqlDataType.Number, condensingUnit.AmbientTemperature.ToString))
                    .Add(New SqlColumn(CT1.Capacity, SqlDataType.Number, condensingUnit.Capacity.ToString))
                    .Add(New SqlColumn(CT1.CircuitsPerUnit, SqlDataType.Number, condensingUnit.CircuitsPerUnit.ToString))
                    .Add(New SqlColumn(CT1.CoilFinWidth1, SqlDataType.Number, condensingUnit.CoilFinWidth1.ToString))
                    .Add(New SqlColumn(CT1.CoilFinWidth2, SqlDataType.Number, condensingUnit.CoilFinWidth2.ToString))
                    .Add(New SqlColumn(CT1.CoilFinWidth3, SqlDataType.Number, condensingUnit.CoilFinWidth3.ToString))
                    .Add(New SqlColumn(CT1.CoilFinWidth4, SqlDataType.Number, condensingUnit.CoilFinWidth4.ToString))
                    .Add(New SqlColumn(CT1.CoilRows1, SqlDataType.Number, condensingUnit.CoilRows1.ToString))
                    .Add(New SqlColumn(CT1.CoilRows2, SqlDataType.Number, condensingUnit.CoilRows2.ToString))
                    .Add(New SqlColumn(CT1.CoilRows3, SqlDataType.Number, condensingUnit.CoilRows3.ToString))
                    .Add(New SqlColumn(CT1.CoilRows4, SqlDataType.Number, condensingUnit.CoilRows4.ToString))
                    .Add(New SqlColumn(CT1.CoilSubCoolingPercentage1, SqlDataType.Number, condensingUnit.CoilSubCoolingPercentage1.ToString))
                    .Add(New SqlColumn(CT1.CoilSubCoolingPercentage2, SqlDataType.Number, condensingUnit.CoilSubCoolingPercentage2.ToString))
                    .Add(New SqlColumn(CT1.CoilSubCoolingPercentage3, SqlDataType.Number, condensingUnit.CoilSubCoolingPercentage3.ToString))
                    .Add(New SqlColumn(CT1.CoilSubCoolingPercentage4, SqlDataType.Number, condensingUnit.CoilSubCoolingPercentage4.ToString))
                    .Add(New SqlColumn(CT1.Compressor, SqlDataType.String, condensingUnit.Compressor))
                    .Add(New SqlColumn(CT1.Compressor1, SqlDataType.String, condensingUnit.Compressor1))
                    .Add(New SqlColumn(CT1.Compressor2, SqlDataType.String, condensingUnit.Compressor2))
                    .Add(New SqlColumn(CT1.Compressor3, SqlDataType.String, condensingUnit.Compressor3))
                    .Add(New SqlColumn(CT1.Compressor4, SqlDataType.String, condensingUnit.Compressor4))
                    .Add(New SqlColumn(CT1.CompressorPerUnit, SqlDataType.Number, condensingUnit.CompressorPerUnit.ToString))
                    .Add(New SqlColumn(CT1.CompressorQuantity1, SqlDataType.Number, condensingUnit.CompressorQuantity1.ToString))
                    .Add(New SqlColumn(CT1.CompressorQuantity2, SqlDataType.Number, condensingUnit.CompressorQuantity2.ToString))
                    .Add(New SqlColumn(CT1.CompressorQuantity3, SqlDataType.Number, condensingUnit.CompressorQuantity3.ToString))
                    .Add(New SqlColumn(CT1.CompressorQuantity4, SqlDataType.Number, condensingUnit.CompressorQuantity4.ToString))
                    .Add(New SqlColumn(CT1.CondensingUnitSeries, SqlDataType.String, condensingUnit.CondensingUnitSeries))
                    .Add(New SqlColumn(CT1.CondensingUnitsRequired, SqlDataType.Number, condensingUnit.CondensingUnitsRequired.ToString))
                    .Add(New SqlColumn(CT1.CreatedBy, SqlDataType.String, condensingUnit.CreatedBy))
                    .Add(New SqlColumn(CT1.CustomCondensingUnitModel, SqlDataType.String, condensingUnit.CustomCondensingUnitModel))
                    .Add(New SqlColumn(CT1.FanDia1, SqlDataType.String, condensingUnit.FanDia1))
                    .Add(New SqlColumn(CT1.FanDia2, SqlDataType.String, condensingUnit.FanDia2))
                    .Add(New SqlColumn(CT1.FanDia3, SqlDataType.String, condensingUnit.FanDia3))
                    .Add(New SqlColumn(CT1.FanDia4, SqlDataType.String, condensingUnit.FanDia4))
                    .Add(New SqlColumn(CT1.FanQuantity1, SqlDataType.Number, condensingUnit.FanQuantity1.ToString))
                    .Add(New SqlColumn(CT1.FanQuantity2, SqlDataType.Number, condensingUnit.FanQuantity2.ToString))
                    .Add(New SqlColumn(CT1.FanQuantity3, SqlDataType.Number, condensingUnit.FanQuantity3.ToString))
                    .Add(New SqlColumn(CT1.FanQuantity4, SqlDataType.Number, condensingUnit.FanQuantity4.ToString))
                    .Add(New SqlColumn(CT1.FinHeight1, SqlDataType.Number, condensingUnit.FinHeight1.ToString))
                    .Add(New SqlColumn(CT1.FinHeight2, SqlDataType.Number, condensingUnit.FinHeight2.ToString))
                    .Add(New SqlColumn(CT1.FinHeight3, SqlDataType.Number, condensingUnit.FinHeight3.ToString))
                    .Add(New SqlColumn(CT1.FinHeight4, SqlDataType.Number, condensingUnit.FinHeight4.ToString))
                    .Add(New SqlColumn(CT1.FinsPerInch1, SqlDataType.Number, condensingUnit.FinsPerInch1.ToString))
                    .Add(New SqlColumn(CT1.FinsPerInch2, SqlDataType.Number, condensingUnit.FinsPerInch2.ToString))
                    .Add(New SqlColumn(CT1.FinsPerInch3, SqlDataType.Number, condensingUnit.FinsPerInch3.ToString))
                    .Add(New SqlColumn(CT1.FinsPerInch4, SqlDataType.Number, condensingUnit.FinsPerInch4.ToString))
                    .Add(New SqlColumn(CT1.Name, SqlDataType.String, condensingUnit.name))
                    .Add(New SqlColumn(CT1.NoCondensingUnits, SqlDataType.Boolean, System.Math.Abs(CInt(condensingUnit.NoCondensingUnits)).ToString)) 'bool
                    .Add(New SqlColumn(CT1.Notes, SqlDataType.String, condensingUnit.Notes))
                    .Add(New SqlColumn(CT1.ProcessID, SqlDataType.String, condensingUnit.id.ToString))
                    .Add(New SqlColumn(CT1.ProcessRevisionDescription, SqlDataType.String, condensingUnit.ProcessRevisionDescription))
                    .Add(New SqlColumn(CT1.ProjectRevision, SqlDataType.String, condensingUnit.ProjectRevision.ToString))
                    .Add(New SqlColumn(CT1.RatingAltitude, SqlDataType.Number, condensingUnit.RatingAltitude.ToString))
                    .Add(New SqlColumn(CT1.RatingAmbient, SqlDataType.Number, condensingUnit.RatingAmbient.ToString))
                    .Add(New SqlColumn(CT1.RatingAmbientInterval, SqlDataType.Number, condensingUnit.RatingAmbientInterval.ToString))
                    .Add(New SqlColumn(CT1.RatingAmbientStep, SqlDataType.Number, condensingUnit.RatingAmbientStep.ToString))
                    .Add(New SqlColumn(CT1.RatingCatalog, SqlDataType.Boolean, System.Math.Abs(CInt(condensingUnit.RatingCatalog)).ToString)) 'bool
                    .Add(New SqlColumn(CT1.RatingHertz, SqlDataType.Number, condensingUnit.RatingHertz.ToString))
                    .Add(New SqlColumn(CT1.RatingRefrigerant, SqlDataType.String, condensingUnit.RatingRefrigerant))
                    .Add(New SqlColumn(CT1.RatingSafety, SqlDataType.Boolean, System.Math.Abs(CInt(condensingUnit.RatingSafety)).ToString)) 'bool
                    .Add(New SqlColumn(CT1.RatingSubCooling, SqlDataType.Number, condensingUnit.RatingSubCooling.ToString))
                    .Add(New SqlColumn(CT1.RatingSuction, SqlDataType.Number, condensingUnit.RatingSuction.ToString))
                    .Add(New SqlColumn(CT1.RatingSuctionInterval, SqlDataType.Number, condensingUnit.RatingSuctionInterval.ToString))
                    .Add(New SqlColumn(CT1.RatingSuctionStep, SqlDataType.Number, condensingUnit.RatingSuctionStep.ToString))
                    .Add(New SqlColumn(CT1.Refrigerant, SqlDataType.String, condensingUnit.Refrigerant))
                    .Add(New SqlColumn(CT1.Revision, SqlDataType.Number, condensingUnit.Revision.ToString))
                    .Add(New SqlColumn(CT1.RevisionDate, SqlDataType.Date, CStr(CNull.ToDate(condensingUnit.RevisionDate))))
                    .Add(New SqlColumn(CT1.RunTime, SqlDataType.Number, condensingUnit.Runtime.ToString))
                    .Add(New SqlColumn(CT1.RunTimeAdjust, SqlDataType.Boolean, System.Math.Abs(CInt(condensingUnit.RuntimeAdjust)).ToString)) 'boolean
                    .Add(New SqlColumn(CT1.RunType, SqlDataType.String, condensingUnit.RunType.ToString))
                    .Add(New SqlColumn(CT1.SuctionTemperature, SqlDataType.Number, condensingUnit.SuctionTemperature.ToString))
                    '.Add(New SqlColumn(CT1.UnitSelection, SqlDataType.Number, condensingUnit.RatingAmbien.ToString))
                    .Add(New SqlColumn(CT1.Version, SqlDataType.String, condensingUnit.Version))
                    .Add(New SqlColumn(CT1.Division, SqlDataType.String, condensingUnit.Division.ToString))
                    .Add(New SqlColumn(CT1.Use10Coefficients, SqlDataType.Boolean, System.Math.Abs(CInt(condensingUnit.Use10Coefficients)).ToString))
                    .Add(New SqlColumn(CT1.Voltage, SqlDataType.Number, condensingUnit.Voltage.ToString))


                    .Add(New SqlColumn(CT1.TubeDiameter1, SqlDataType.Number, condensingUnit.TubeDiameter1.ToString))
                    .Add(New SqlColumn(CT1.TubeSurface1, SqlDataType.String, condensingUnit.TubeSurface1.ToString))
                    .Add(New SqlColumn(CT1.FinType1, SqlDataType.String, condensingUnit.FinType1.ToString))
                    .Add(New SqlColumn(CT1.TubeDiameter2, SqlDataType.Number, condensingUnit.TubeDiameter2.ToString))
                    .Add(New SqlColumn(CT1.TubeSurface2, SqlDataType.String, condensingUnit.TubeSurface2 & ""))
                    .Add(New SqlColumn(CT1.FinType2, SqlDataType.String, condensingUnit.FinType2 & ""))
                    '.Add(New SqlColumn(CT1.TubeDiameter3, SqlDataType.Number, condensingUnit.TubeDiameter3.ToString))
                    '.Add(New SqlColumn(CT1.TubeSurface3, SqlDataType.String, condensingUnit.TubeSurface3 & ""))
                    '.Add(New SqlColumn(CT1.FinType3, SqlDataType.String, condensingUnit.FinType3 & ""))
                    '.Add(New SqlColumn(CT1.TubeDiameter4, SqlDataType.Number, condensingUnit.TubeDiameter4.ToString))
                    '.Add(New SqlColumn(CT1.TubeSurface4, SqlDataType.String, condensingUnit.TubeSurface4 & ""))
                    '.Add(New SqlColumn(CT1.FinType4, SqlDataType.String, condensingUnit.FinType4 & ""))

                    .Add(New SqlColumn(CT1.FanRPM1, SqlDataType.Number, condensingUnit.FanRPM1.ToString))
                    .Add(New SqlColumn(CT1.FanRPM2, SqlDataType.Number, condensingUnit.FanRPM2.ToString))
                    .Add(New SqlColumn(CT1.FanRPM3, SqlDataType.Number, condensingUnit.FanRPM3.ToString))
                    .Add(New SqlColumn(CT1.FanRPM4, SqlDataType.Number, condensingUnit.FanRPM4.ToString))

                    .Add(New SqlColumn(CT1.DOEModel, SqlDataType.String, condensingUnit.DOEModel.ToString))


                End With

                Return columns
            End Function

        End Class


    End Class
End Namespace

