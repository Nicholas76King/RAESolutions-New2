Imports System
Imports System.Data
Imports System.Text
Imports Rae.RaeSolutions.Business.Entities
Imports System.Collections.Generic
Imports Rae.Data.Sql
Imports Rae.RaeSolutions.DataAccess.Projects

Imports ECP = Rae.RaeSolutions.DataAccess.Projects.Tables.WCChillerProcessTable
Imports ET1 = RAE.RAESolutions.DataAccess.Projects.Tables.EquipmentTable
Imports COT = RAE.RAESolutions.DataAccess.Projects.Tables.CondensingUnitTable
Imports CNull = Rae.ConvertNull
Imports OtherCostsDA = Rae.RaeSolutions.DataAccess.Projects.OtherEquipmentCostsDA
Imports CO1 = RAE.RAESolutions.DataAccess.Projects.Tables.CondensingUnitTable
Imports CT1 = RAE.RAESolutions.DataAccess.Projects.Tables.WCChillerProcessTable

Namespace Rae.RaeSolutions.DataAccess.Projects

   Public Class WCChillerProcessDA

#Region "Public METhods"
        Public Shared Function Retrieve(ByVal id As item_id) As WCChillerProcessItem
         Dim condenser As WCChillerProcessItem

         ' retrieves fluidCooler
         condenser = RetrieveEvap(id)

         Return condenser
      End Function

      Public Shared Function Retrieve(ByVal id As item_id, ByVal RevNumber As Single) As WCChillerProcessItem
         Dim condenser As WCChillerProcessItem

         ' retrieves fluidCooler
         condenser = RetrieveEvap(id, RevNumber)

         Return condenser
      End Function

      Public Shared Sub Update(ByVal process As WCChillerProcessItem)
         Dim connection As iDbConnection
         Dim command As iDbCommand
         Dim numRowsAffected As Integer
         Dim connectionString, sqlCommand As String

         connectionString = Common.GetConnectionString(Common.ProjectsDbPath)
         sqlCommand = SqlFactory.GetUpdateChillerSql(process)

         connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)

         command = connection.CreateCommand 'New OleDbCommand(sql, connection)
         command.CommandText = sqlCommand

         Try
            connection.Open()
            numRowsAffected = command.ExecuteNonQuery()
         Catch ex As dataException
            Throw
         Finally
            If Not connection.State.Equals(System.Data.ConnectionState.Closed) Then connection.Close()
         End Try


      End Sub



#End Region

#Region "Private Methods"

      Private Shared Function RetrieveEvap(ByVal id As item_id, Optional ByVal RevNumber As Single = -1, Optional ByVal ProjRevision As Single = -1) As WCChillerProcessItem
         Dim connection As IDbConnection
         Dim command As IDbCommand
         Dim reader As IDataReader
         Dim connectionString As String
         'Dim sql As New StringBuilder
         Dim sql As String
         'Dim equipmentId, projectId As ItemId
         'Dim name As String
         'Dim division As Business.Division

         Dim condenser As WCChillerProcessItem

         connectionString = Common.GetConnectionString(Common.ProjectsDbPath)

         ' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
         ' Added by JOSHH on 8/7/2006
         ' Determin which revision to get..
         ' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
         If RevNumber > -1 Then
            ' Get the specified revision...
            sql = "SELECT * FROM WCChillerProcesses " & _
                      "WHERE ProcessID='" & id.Id & "' " & _
                      "AND [Revision] = " & RevNumber '& _
            '" AND [ProjectRevision] = " & ProjRevision
         Else
            ' Get the most current revision...
            sql = "SELECT * FROM WCChillerProcesses " & _
                      "WHERE ProcessID='" & id.Id & "' " & _
                      "ORDER BY [Revision] DESC"
         End If
         ' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

         connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)

         command = connection.CreateCommand 'New OleDbCommand(sql, connection)
         command.CommandText = sql

         Try
            connection.Open()
            reader = command.ExecuteReader()
            If reader.Read Then
                    ' retrieves values required to construct a fluid cooler equipment item
                    'equipmentId = New ItemId(reader(ET1.TableName & "." & ET1.EquipmentId).ToString)
                    'projectId = New ItemId(reader(ET1.ProjectId).ToString)
                    'name = reader(ET1.Name).ToString
                    'GetEnumValue(reader(ET1.Division).ToString, division)

                    ' constructs
                    'condenser = New CondenserProcessItem(name, division, equipmentId, New ProjectManager(projectId))
                    condenser = New WCChillerProcessItem(id)

               ' retrieves the rest of the properties
               With condenser
                        ' DBNull.Value.ToString = "", no exception is raised
                        ' TEST: DateGenerated is set by ID?
                        '.MetaData.Author = reader(ET1.Author).ToString

                        'revision
                        'revision date
                        'createdby
                        'version
                        'notes

                        '.ProjectRevision = cint(reader(ECP.ProjectRevision))
                        '.ProcessRevisionDescription = reader(ECP.ProcessRevisionDescription).ToString

                        .Altitude = CDbl(reader("Altitude").ToString)
                  .AmbientTemp = CDbl(reader("AmbientTemp").ToString)
                  .Approach = reader(ECP.Approach).ToString
                  '.ApproachRange = CInt(reader(ECP.ApproachRange).ToString)
                  '.CapacityType = CInt(reader(ECP.CapacityType).ToString)
                  '.ATIncrement = CDbl(reader(ECP.ATIncrement).ToString)
                  '.ATMax = CDbl(reader(ECP.ATMax).ToString)
                  '.ATMin = CDbl(reader(ECP.ATMin).ToString)
                  .CatalogRating = CBool(reader("CatalogRating").ToString)
                  .Circuit1 = CBool(reader(ECP.Circuit1))
                  .Circuit2 = CBool(reader(ECP.Circuit2))
                  .Compressors1 = reader(ECP.Compressors1).ToString
                  .Compressors2 = reader(ECP.Compressors2).ToString
                  .Condenser1 = reader(ECP.Condenser1).ToString
                  .Condenser2 = reader(ECP.Condenser2).ToString
                  .CondenserCapacity1 = CDbl(reader(ECP.CondenserCapacity1))
                  .CondenserCapacity2 = CDbl(reader(ECP.CondenserCapacity1))
                  .CoolingMedia = reader(ECP.CoolingMedia).ToString
                  .CreatedBy = reader(ECP.CreatedBy).ToString
                  .DischargeLineLoss = CDbl(reader(ECP.DischargeLineLoss))
                  .Evap10Degr1 = CDbl(reader(ECP.Evap10Degr1))
                  .Evap10Degr2 = CDbl(reader(ECP.Evap10Degr2))
                  .Evap8Degr1 = CDbl(reader(ECP.Evap8Degr1))
                  .Evap8Degr2 = CDbl(reader(ECP.Evap8Degr2))
                  .EvaporatorCapacity = CDbl(reader(ECP.EvaporatorCapacity))
                  .EvaporatorModel = reader(ECP.EvaporatorModel).ToString
                  .EvaporatorModelDesc = reader(ECP.EvaporatorModelDesc).ToString
                  .FanWatts = CDbl(reader(ECP.FanWatts))
                  .Fluid = reader(ECP.Fluid).ToString
                  .FoulingFactor = CDbl(reader(ECP.FoulingFactor))
                  .GlycolPercentage = CDbl(reader(ECP.GlycolPercentage))
                  .Hertz = CDbl(reader(ECP.Hertz))
                  '.Id = reader(ECP.ID)
                  .LeavingFluidTemp = CDbl(reader(ECP.LeavingFluidTemp))
                  .Model = reader(ECP.Model).ToString
                  .ModelDesc = reader(ECP.ModelDesc).ToString
                  .name = reader(ECP.Name).ToString
                  .NewCoefficients = CBool(reader(ECP.NewCoefficients))
                  .Notes = reader(ECP.Notes).ToString
                  .NumCoils1 = CInt(reader(ECP.NumCoils1))
                  .NumCoils2 = CInt(reader(ECP.NumCoils2))
                  .NumCompressors1 = CInt(reader(ECP.NumCompressors1))
                  .NumCompressors2 = CInt(reader(ECP.NumCompressors2))
                  .NumEvap = CInt(reader(ECP.NumEvap))

                  ' Try to set project manager...
                  If ProcessItemDA.GetProjectID(id.Id) IsNot Nothing Then
                     .ProjectManager = New project_manager(ProcessItemDA.GetProjectID(id.Id))
                  End If

                  .PumpWatts = CDbl(reader(ECP.PumpWatts))
                  .Refrigerant = reader(ECP.Refrigerant).ToString
                  .Revision = CSng(reader(ECP.Revision))
                  .RevisionDate = CDate(reader(ECP.RevisionDate))
                  .SafetyOverride = CBool(reader(ECP.SafetyOverride))
                  .Series = reader(ECP.Series).ToString
                  .SpecificGravity = CDbl(reader(ECP.SpecificGravity))
                  .SpecificHeat = CDbl(reader(ECP.SpecificHeat))
                  .SubCooling = CDbl(reader(ECP.SubCooling))
                  .SuctionLineLoss = CDbl(reader(ECP.SuctionLineLoss))
                  .System = reader(ECP.System).ToString
                  .TempRange = CDbl(reader(ECP.TempRange))
                  '.TEIncrement = CDbl(reader(ECP.TEIncrement))
                  '.TEMax = CDbl(reader(ECP.TEMax))
                  '.TEMin = CDbl(reader(ECP.TEMin))
                  .Version = reader(ECP.Version).ToString
                  .Volts = CDbl(reader(ECP.Volts))

                  '.Parent
                  '.Project

               End With
            End If
            'Catch ex As dataException
         Catch ex As Exception
            Throw ex
         Finally
            If reader IsNot Nothing Then reader.Close()
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try

         Return condenser
      End Function

      Public Overloads Shared Function Create(ByVal wcChiller As WCChillerProcessItem) As Integer
         Dim connectionString As String
         Dim transaction As IDbTransaction
         Dim connection As iDbConnection
         Dim numRowsAffected As Integer

         Dim found As Boolean
         found = Exists(wcChiller.id.ToString)

         connectionString = Common.GetConnectionString(Common.ProjectsDbPath)
         connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)


         Try
            connection.Open()

            ' begins transaction (everything can be rolled back from the beginning of the transaction until it is committed)
            transaction = connection.BeginTransaction()

            If found = False Then
               ' inserts only general process data into Processes Table
               ProcessItemDA.Create(connection, transaction, wcChiller, ECP.TableName)
            End If

            ' inserts values into CondenserProcessesTable
            CreateItem(connection, transaction, wcChiller)
            '    commits transaction
            transaction.Commit()
         Catch ex As Exception
            ' rolls back transaction
            If Not transaction Is Nothing Then transaction.Rollback()
            Throw New ApplicationException("Attempt to create WC Chiller process item failed. Transaction was rolled back.", ex)
         Finally
            If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try

         Return numRowsAffected
      End Function


      Public Shared Sub CreateItem(ByVal connection As IDbConnection, ByVal transaction As IDbTransaction, ByVal process As WCChillerProcessItem)
         Dim connectionString, sqlCommand As String
         'Dim connection As iDbConnection
         Dim command As IDbCommand

         connectionString = Common.GetConnectionString(Common.ProjectsDbPath)
         sqlCommand = SqlFactory.GetInsertChillerSql(process)
         command = connection.CreateCommand 'New OleDbCommand(sql, connection)
         command.CommandText = sqlCommand
         command.Transaction = transaction

         Try
            'connection.Open()

            ' creates project
            command.ExecuteNonQuery()

         Catch dbEx As DataException
            Throw
         Finally
            'If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try
      End Sub


      Public Shared Function Exists(ByVal id As String) As Boolean
         Dim connection As iDbConnection
         Dim command As iDbCommand
         Dim reader As iDataReader
         Dim connectionString As String, sql As String
         Dim found As Boolean = False

         connectionString = Common.GetConnectionString(Common.ProjectsDbPath)
         connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)

         'sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}] = '{2}'", _
         '   PT.TableName, PT.ProjectId, id.ToString)
         sql = "SELECT * FROM Processes WHERE ID = '" + id + "'"
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
         Catch ex As dataException
            Throw ex
         Finally
            If reader IsNot Nothing Then reader.Close()
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try

         Return found
      End Function



#End Region


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
         Public Shared Function GetInsertChillerSql(ByVal chiller As WCChillerProcessItem) As String
            Dim affectedColumns As List(Of SqlColumn) = ChillerColumns(chiller)
                Dim builder As New SqlBuilder(affectedColumns, CT1.TableName)

                Return builder.GenerateInsertCommand()
         End Function


         ''' <summary>
         ''' Gets SQL to update chiller equipment item.
         ''' </summary>
         ''' <param name="chiller">
         ''' Chiller equipment to update.
         ''' </param>
         ''' <returns>
         ''' SQL command to update chiller equipment.
         ''' </returns>
         Public Shared Function GetUpdateChillerSql(ByVal chiller As WCChillerProcessItem) As String
            Dim affectedCols As List(Of SqlColumn) = ChillerColumns(chiller)
            Dim criteriaCols As New List(Of SqlColumn)
                criteriaCols.Add(New SqlColumn(CT1.ProcessId, SqlDataType.String, chiller.id.Id))
                criteriaCols.Add(New SqlColumn(CT1.Revision, SqlDataType.Number, chiller.Revision.ToString))
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
         Private Shared Function ChillerColumns(ByVal chiller As WCChillerProcessItem) As List(Of SqlColumn)
            Dim columns As New List(Of SqlColumn)

            With columns
                    .Add(New SqlColumn(CT1.Altitude, SqlDataType.Number, chiller.Altitude.ToString))
                    .Add(New SqlColumn(CT1.AmbientTemp, SqlDataType.Number, chiller.AmbientTemp.ToString))
                    .Add(New SqlColumn(CT1.Approach, SqlDataType.String, chiller.Approach))
                    .Add(New SqlColumn(CT1.ApproachRange, SqlDataType.String, chiller.ApproachRange.ToString))
                    .Add(New SqlColumn(CT1.CapacityType, SqlDataType.String, chiller.CapacityType.ToString))
                    .Add(New SqlColumn(CT1.CatalogRating, SqlDataType.Boolean, System.Math.Abs(CInt(chiller.CatalogRating)).ToString))
                    .Add(New SqlColumn(CT1.Circuit1, SqlDataType.Boolean, System.Math.Abs(CInt(chiller.Circuit1)).ToString))
                    .Add(New SqlColumn(CT1.Circuit2, SqlDataType.Boolean, System.Math.Abs(CInt(chiller.Circuit2)).ToString))
                    .Add(New SqlColumn(CT1.Compressors1, SqlDataType.String, chiller.Compressors1))
                    .Add(New SqlColumn(CT1.Compressors2, SqlDataType.String, chiller.Compressors2))
                    .Add(New SqlColumn(CT1.Condenser1, SqlDataType.String, chiller.Condenser1))
                    .Add(New SqlColumn(CT1.Condenser2, SqlDataType.String, chiller.Condenser2))
                    .Add(New SqlColumn(CT1.CondenserCapacity1, SqlDataType.String, chiller.CondenserCapacity1.ToString))
                    .Add(New SqlColumn(CT1.CondenserCapacity2, SqlDataType.String, chiller.CondenserCapacity2.ToString))
                    .Add(New SqlColumn(CT1.CoolingMedia, SqlDataType.String, chiller.CoolingMedia))
                    .Add(New SqlColumn(CT1.CreatedBy, SqlDataType.String, chiller.CreatedBy))
                    .Add(New SqlColumn(CT1.DischargeLineLoss, SqlDataType.Number, chiller.DischargeLineLoss.ToString))
                    .Add(New SqlColumn(CT1.Evap10Degr1, SqlDataType.Number, chiller.Evap10Degr1.ToString))
                    .Add(New SqlColumn(CT1.Evap10Degr2, SqlDataType.Number, chiller.Evap10Degr2.ToString))
                    .Add(New SqlColumn(CT1.Evap8Degr1, SqlDataType.Number, chiller.Evap8Degr1.ToString))
                    .Add(New SqlColumn(CT1.Evap8Degr2, SqlDataType.Number, chiller.Evap8Degr2.ToString))
                    .Add(New SqlColumn(CT1.EvaporatorCapacity, SqlDataType.Number, chiller.EvaporatorCapacity.ToString))
                    .Add(New SqlColumn(CT1.EvaporatorModel, SqlDataType.String, chiller.EvaporatorModel))
                    .Add(New SqlColumn(CT1.EvaporatorModelDesc, SqlDataType.String, chiller.EvaporatorModelDesc))
                    '.Add(New SqlColumn(CT1.FanWatts, SqlDataType.Number, chiller.FanWatts.ToString))
                    .Add(New SqlColumn(CT1.Fluid, SqlDataType.String, chiller.Fluid))
                    .Add(New SqlColumn(CT1.FoulingFactor, SqlDataType.Number, chiller.FoulingFactor.ToString))
                    .Add(New SqlColumn(CT1.GlycolPercentage, SqlDataType.Number, chiller.GlycolPercentage.ToString))
                    .Add(New SqlColumn(CT1.Hertz, SqlDataType.Number, chiller.Hertz.ToString))
                    '.Add(New SqlColumn(CT1.ID, SqlDataType.String, chiller.Id.ToString))
                    .Add(New SqlColumn(CT1.LeavingFluidTemp, SqlDataType.Number, chiller.LeavingFluidTemp.ToString))
                    .Add(New SqlColumn(CT1.Model, SqlDataType.String, chiller.Model))
                    .Add(New SqlColumn(CT1.ModelDesc, SqlDataType.String, chiller.ModelDesc))
                    .Add(New SqlColumn(CT1.Name, SqlDataType.String, chiller.name))
                    .Add(New SqlColumn(CT1.NewCoefficients, SqlDataType.Boolean, System.Math.Abs(CInt(chiller.NewCoefficients)).ToString))
                    .Add(New SqlColumn(CT1.Notes, SqlDataType.String, chiller.Notes))
                    .Add(New SqlColumn(CT1.NumCoils1, SqlDataType.Number, chiller.NumCoils1.ToString))
                    .Add(New SqlColumn(CT1.NumCoils2, SqlDataType.Number, chiller.NumCoils2.ToString))
                    .Add(New SqlColumn(CT1.NumCompressors1, SqlDataType.Number, chiller.NumCompressors1.ToString))
                    .Add(New SqlColumn(CT1.NumCompressors2, SqlDataType.Number, chiller.NumCompressors2.ToString))
                    .Add(New SqlColumn(CT1.NumEvap, SqlDataType.Number, chiller.NumEvap.ToString))
                    .Add(New SqlColumn(CT1.ProcessId, SqlDataType.String, chiller.id.ToString))
                    '.Add(New SqlColumn(CT1.PumpWatts, SqlDataType.Number, chiller.PumpWatts.ToString))
                    .Add(New SqlColumn(CT1.Refrigerant, SqlDataType.String, chiller.Refrigerant))
                    .Add(New SqlColumn(CT1.Revision, SqlDataType.Number, chiller.Revision.ToString))
                    .Add(New SqlColumn(CT1.RevisionDate, SqlDataType.Date, CStr(CNull.ToDate(chiller.RevisionDate))))
                    .Add(New SqlColumn(CT1.SafetyOverride, SqlDataType.Boolean, System.Math.Abs(CInt(chiller.SafetyOverride)).ToString))
                    .Add(New SqlColumn(CT1.Series, SqlDataType.String, chiller.Series))
                    .Add(New SqlColumn(CT1.SpecificGravity, SqlDataType.Number, chiller.SpecificGravity.ToString))
                    .Add(New SqlColumn(CT1.SpecificHeat, SqlDataType.Number, chiller.SpecificHeat.ToString))
                    .Add(New SqlColumn(CT1.SubCooling, SqlDataType.Boolean, System.Math.Abs(CInt(chiller.SubCooling)).ToString))
                    .Add(New SqlColumn(CT1.SuctionLineLoss, SqlDataType.Number, chiller.SuctionLineLoss.ToString))
                    .Add(New SqlColumn(CT1.System, SqlDataType.String, chiller.System))
                    .Add(New SqlColumn(CT1.TempRange, SqlDataType.Number, chiller.TempRange.ToString))
                    .Add(New SqlColumn(CT1.Version, SqlDataType.String, chiller.Version))
                    .Add(New SqlColumn(CT1.Volts, SqlDataType.Number, chiller.Volts.ToString))
                    '.Add(New SqlColumn(CT1.ATIncrement, SqlDataType.Number, chiller.ATIncrement.ToString))
                    '.Add(New SqlColumn(CT1.ATMax, SqlDataType.Number, chiller.ATMax.ToString))
                    '.Add(New SqlColumn(CT1.ATMin, SqlDataType.Number, chiller.ATMin.ToString))
                    '.Add(New SqlColumn(CT1.TEIncrement, SqlDataType.Number, chiller.TEIncrement.ToString))
                    '.Add(New SqlColumn(CT1.TEMax, SqlDataType.Number, chiller.TEMax.ToString))
                    '.Add(New SqlColumn(CT1.TEMin, SqlDataType.Number, chiller.TEMin.ToString))
                End With

            Return columns
         End Function

      End Class

   End Class
End Namespace
