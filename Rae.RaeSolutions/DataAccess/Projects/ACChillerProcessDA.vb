Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Text
Imports Rae.Io.Text
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.Data.Sql
Imports Rae.RaeSolutions.DataAccess.Projects

Imports ECP = Rae.RaeSolutions.DataAccess.Projects.Tables.ACChillerProcessTable
Imports ET6 = RAE.RAESolutions.DataAccess.Projects.Tables.EquipmentTable
Imports COT = Rae.RaeSolutions.DataAccess.Projects.Tables.CondensingUnitTable
Imports CNull = Rae.ConvertNull
Imports OtherCostsDA = Rae.RaeSolutions.DataAccess.Projects.OtherEquipmentCostsDA
Imports CO6 = RAE.RAESolutions.DataAccess.Projects.Tables.CondensingUnitTable
Imports CT6 = RAE.RAESolutions.DataAccess.Projects.Tables.ACChillerProcessTable


Namespace Rae.RaeSolutions.DataAccess.Projects

Public Class ACChillerProcessDA

   Shared Function Retrieve(id As item_id) As ACChillerProcessItem
      Return retrieveChiller(id)
   End Function

   Shared Function Retrieve(id As item_id, RevNumber As Single) As ACChillerProcessItem
      Return retrieveChiller(id, RevNumber)
   End Function
   
   
   Overloads Shared Function Create(chiller As ACChillerProcessItem) As Integer
      Dim transaction As IDbTransaction
      Dim numRowsAffected As Integer

      Dim found = Exists(chiller.id.ToString)
      Dim connection = Common.CreateConnection(Common.ProjectsDbPath)

      Try
         connection.Open()

         ' begins transaction (everything can be rolled back from the beginning of the transaction until it is committed)
         transaction = connection.BeginTransaction()

         If found = False Then
            ' inserts only general process data into Processes Table
            ProcessItemDA.Create(connection, transaction, chiller, ECP.TableName)
         End If

         ' inserts values into CondenserProcessesTable
         createItem(connection, transaction, chiller)
         '    commits transaction
         transaction.Commit()
      Catch ex As Exception
         ' rolls back transaction
         If Not transaction Is Nothing Then transaction.Rollback()
         Throw New ApplicationException("Attempt to create air cooled chiller selection item failed. Transaction was rolled back.", ex)
      Finally
         If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
      End Try

      Return numRowsAffected
   End Function

   Shared Sub Update(process As ACChillerProcessItem)
      Dim numRowsAffected As Integer

      Dim sql = SqlFactory.GetUpdateSqlFor(process)
      Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
      Dim command = connection.CreateCommand
      command.CommandText = sql

      Try
         connection.Open()
         numRowsAffected = command.ExecuteNonQuery()
      Finally
         If Not connection.State.Equals(System.Data.ConnectionState.Closed) Then connection.Close()
      End Try
   End Sub

   Shared Function Exists(id As String, Optional ProjRevision As Single = -1) As Boolean
      Dim reader As IDataReader
      Dim found As Boolean = False

      Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
      Dim command = connection.CreateCommand
      Dim sql = "SELECT6 * FROM Processes WHERE ID = '" + id + "'"
      command.CommandText = sql

      Try
         connection.Open()
         reader = command.ExecuteReader()
         ' checks if project exists
         'found = reader.HasRows()
         Dim i As Integer = 0
         While reader.Read
            i += 1
         End While
         If i > 0 Then
            found = True
         End If
      Finally
         If reader IsNot Nothing Then _
            reader.Close()
         If connection.State <> ConnectionState.Closed Then _
            connection.Close()
      End Try

      Return found
   End Function



   Private Shared Function retrieveChiller(id As item_id, Optional RevNumber As Single = -1, Optional ProjRevision As Single = -1) As ACChillerProcessItem
      Dim chiller As ACChillerProcessItem
      
      Dim sql As String
      If RevNumber > -1 Then
         ' Get the specified revision...
         sql = "SELECT * FROM ACChillerProcesses " & _
               "WHERE ProcessID='" & id.Id & "' " & _
               "AND [Revision] = " & RevNumber
      Else
         ' Get the most current revision...
         sql = "SELECT * FROM ACChillerProcesses " & _
               "WHERE ProcessID='" & id.Id & "' " & _
               "ORDER BY [Revision] DESC"
      End If

      Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
      Dim command = connection.CreateCommand()
      command.CommandText = sql
      Dim reader As IDataReader
      Try
         connection.Open()
         reader = command.ExecuteReader()
         If reader.Read Then
            chiller = New ACChillerProcessItem(id)

            With chiller
               .Altitude = CDbl(reader("Altitude").ToString)
               .AmbientTemp = CDbl(reader("AmbientTemp").ToString)
               .Approach = reader(ECP.Approach).ToString
               GetEnumValue(reader(ECP.ApproachRange).ToString, .ApproachRange)
               '.ATIncrement = CDbl(reader(ECP.ATIncrement).ToString)
               '.ATMax = CDbl(reader(ECP.ATMax).ToString)
               '.ATMin = CDbl(reader(ECP.ATMin).ToString)
               GetEnumValue(reader(ECP.CapacityType).ToString, .CapacityType)
               .CatalogRating = CBool(reader("CatalogRating").ToString)
               .CfmOverride = CDbl(reader(ECP.CfmOverride))
               .Circuit1 = CBool(reader(ECP.Circuit1))
               .Circuit2 = CBool(reader(ECP.Circuit2))
               .Compressors1 = reader(ECP.Compressors1).ToString
               .Compressors2 = reader(ECP.Compressors2).ToString
               .Condenser1 = reader(ECP.Condenser1).ToString
               .Condenser2 = reader(ECP.Condenser2).ToString
               .CondenserCapacity1 = CDbl(reader(ECP.CondenserCapacity1))
               .CondenserCapacity2 = CDbl(reader(ECP.CondenserCapacity1))
               .CondenserTD1 = CDbl(reader(ECP.CondenserTD1))
               .CondenserTD2 = CDbl(reader(ECP.CondenserTD2))
               .CoolingMedia = reader(ECP.CoolingMedia).ToString
               .CreatedBy = reader(ECP.CreatedBy).ToString
               .DischargeLineLoss = CDbl(reader(ECP.DischargeLineLoss))
               GetEnumValue(reader(ECP.Division).ToString, .Division)
               .Evap10Degr1 = CDbl(reader(ECP.Evap10Degr1))
               .Evap10Degr2 = CDbl(reader(ECP.Evap10Degr2))
               .Evap8Degr1 = CDbl(reader(ECP.Evap8Degr1))
               .Evap8Degr2 = CDbl(reader(ECP.Evap8Degr2))
               .EvaporatorCapacity = CDbl(reader(ECP.EvaporatorCapacity))
               .EvaporatorModel = reader(ECP.EvaporatorModel).ToString
               .EvaporatorModelDesc = reader(ECP.EvaporatorModelDesc).ToString
               .Fan = reader(ECP.Fan).ToString
               .FanWatts = CNull.ToDouble(reader(ECP.FanWatts), 1100)
               .FinHeight1 = CDbl(reader(ECP.FinHeight1))
               .FinHeight2 = CDbl(reader(ECP.FinHeight2))
               .FinLength1 = CDbl(reader(ECP.FinLength1))
               .FinLength2 = CDbl(reader(ECP.FinLength2))
               .FinsPerInch1 = CDbl(reader(ECP.FinsPerInch1))
               .FinsPerInch2 = CDbl(reader(ECP.FinsPerInch2))
               '.FanWatts = CDbl(reader(ECP.FanWatts))
               .Fluid = reader(ECP.Fluid).ToString
               .FoulingFactor = CDbl(reader(ECP.FoulingFactor))
               .GlycolPercentage = CDbl(reader(ECP.GlycolPercentage))
               .Hertz = CDbl(reader(ECP.Hertz))
               .id = id
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
               .NumFans1 = CDbl(reader(ECP.NumFans1))
               .NumFans2 = CDbl(reader(ECP.NumFans2))
               .ProcessRevisionDescription = reader(ECP.ProcessRevisionDescription).ToString

               If ProcessItemDA.GetProjectID(id.Id) IsNot Nothing Then
                  .ProjectManager = New project_manager(ProcessItemDA.GetProjectID(id.Id))
               End If

               .ProjectRevision = CInt(reader(ECP.ProjectRevision))

               '.PumpWatts = CDbl(reader(ECP.PumpWatts))
               .Refrigerant = reader(ECP.Refrigerant).ToString
               .Revision = CSng(reader(ECP.Revision))
               .RevisionDate = CDate(reader(ECP.RevisionDate))
               .SafetyOverride = CBool(reader(ECP.SafetyOverride))
               .Series = reader(ECP.Series).ToString
               .SpecificGravity = CDbl(reader(ECP.SpecificGravity))
               .SpecificHeat = CDbl(reader(ECP.SpecificHeat))
               .SubCooling = CDbl(reader(ECP.SubCooling))
               .SubCooling1 = CBool(reader(ECP.SubCooling1))
               .SubCooling2 = CBool(reader(ECP.SubCooling2))
               .SubCoolingPercent1 = CDbl(reader(ECP.SubCoolingPercent1))
               .SubCoolingPercent2 = CDbl(reader(ECP.SubCoolingPercent2))
               .SuctionLineLoss = CDbl(reader(ECP.SuctionLineLoss))
               .System = reader(ECP.System).ToString
               .TempRange = CDbl(reader(ECP.TempRange))
               '.TEIncrement = CDbl(reader(ECP.TEIncrement))
               '.TEMax = CDbl(reader(ECP.TEMax))
               '.TEMin = CDbl(reader(ECP.TEMin))
               .Version = reader(ECP.Version).ToString
               .Volts = CDbl(reader(ECP.Volts))
            End With
         End If
      Catch ex As Exception
         Throw ex
      Finally
         If reader IsNot Nothing Then reader.Close()
         If connection.State <> ConnectionState.Closed Then connection.Close()
      End Try

      Return chiller
   End Function
   
   Private Shared Sub createItem(connection As IDbConnection, transaction As IDbTransaction, chiller As ACChillerProcessItem)
      Dim sql = SqlFactory.GetInsertSqlFor(chiller)

      Dim command = connection.CreateCommand
      command.CommandText = sql
      command.Transaction = transaction
      Try
         ' creates project
         command.ExecuteNonQuery()
      Finally
         'If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
      End Try
   End Sub


   Private Class SqlFactory

      Shared Function GetInsertSqlFor(chiller As ACChillerProcessItem) As String
         Dim affectedColumns As List(Of SqlColumn) = chillerColumns(chiller)
                Dim builder As New SqlBuilder(affectedColumns, CT6.TableName)

                Return builder.GenerateInsertCommand()
      End Function

      Shared Function GetUpdateSqlFor(chiller As ACChillerProcessItem) As String
         Dim affectedCols As List(Of SqlColumn) = chillerColumns(chiller)
         Dim criteriaCols As New List(Of SqlColumn)
                criteriaCols.Add(New SqlColumn(CT6.ProcessId, SqlDataType.String, chiller.id.Id))
                criteriaCols.Add(New SqlColumn(CT6.Revision, SqlDataType.Number, chiller.Revision.ToString))
                Dim builder As New SqlBuilder(affectedCols, CT6.TableName, criteriaCols)

                Return builder.GenerateUpdateCommand()
      End Function


      Private Shared Function chillerColumns(chiller As ACChillerProcessItem) As List(Of SqlColumn)
         Dim columns As New List(Of SqlColumn)

         With columns
                    .Add(New SqlColumn(CT6.Altitude, SqlDataType.Number, chiller.Altitude.ToString))
                    .Add(New SqlColumn(CT6.AmbientTemp, SqlDataType.Number, chiller.AmbientTemp.ToString))
                    .Add(New SqlColumn(CT6.Approach, SqlDataType.String, chiller.Approach))
                    .Add(New SqlColumn(CT6.ApproachRange, SqlDataType.String, chiller.ApproachRange.ToString))
                    .Add(New SqlColumn(CT6.CapacityType, SqlDataType.String, chiller.CapacityType.ToString))
                    .Add(New SqlColumn(CT6.CatalogRating, SqlDataType.Boolean, System.Math.Abs(CInt(chiller.CatalogRating)).ToString))
                    .Add(New SqlColumn(CT6.Circuit1, SqlDataType.Boolean, System.Math.Abs(CInt(chiller.Circuit1)).ToString))
                    .Add(New SqlColumn(CT6.Circuit2, SqlDataType.Boolean, System.Math.Abs(CInt(chiller.Circuit2)).ToString))
                    .Add(New SqlColumn(CT6.Compressors1, SqlDataType.String, chiller.Compressors1))
                    .Add(New SqlColumn(CT6.Compressors2, SqlDataType.String, chiller.Compressors2))
                    .Add(New SqlColumn(CT6.Condenser1, SqlDataType.String, chiller.Condenser1))
                    .Add(New SqlColumn(CT6.Condenser2, SqlDataType.String, chiller.Condenser2))
                    .Add(New SqlColumn(CT6.CondenserCapacity1, SqlDataType.Number, chiller.CondenserCapacity1.ToString))
                    .Add(New SqlColumn(CT6.CondenserCapacity2, SqlDataType.Number, chiller.CondenserCapacity2.ToString))
                    .Add(New SqlColumn(CT6.CoolingMedia, SqlDataType.String, chiller.CoolingMedia))
                    .Add(New SqlColumn(CT6.CreatedBy, SqlDataType.String, chiller.CreatedBy))
                    .Add(New SqlColumn(CT6.DischargeLineLoss, SqlDataType.Number, chiller.DischargeLineLoss.ToString))
                    .Add(New SqlColumn(CT6.Evap10Degr1, SqlDataType.Number, chiller.Evap10Degr1.ToString))
                    .Add(New SqlColumn(CT6.Evap10Degr2, SqlDataType.Number, chiller.Evap10Degr2.ToString))
                    .Add(New SqlColumn(CT6.Evap8Degr1, SqlDataType.Number, chiller.Evap8Degr1.ToString))
                    .Add(New SqlColumn(CT6.Evap8Degr2, SqlDataType.Number, chiller.Evap8Degr2.ToString))
                    .Add(New SqlColumn(CT6.EvaporatorCapacity, SqlDataType.Number, chiller.EvaporatorCapacity.ToString))
                    .Add(New SqlColumn(CT6.EvaporatorModel, SqlDataType.String, chiller.EvaporatorModel))
                    .Add(New SqlColumn(CT6.EvaporatorModelDesc, SqlDataType.String, chiller.EvaporatorModelDesc))
                    .Add(New SqlColumn(CT6.FanWatts, SqlDataType.Number, chiller.FanWatts.ToString))
                    .Add(New SqlColumn(CT6.Fluid, SqlDataType.String, chiller.Fluid))
                    .Add(New SqlColumn(CT6.FoulingFactor, SqlDataType.Number, chiller.FoulingFactor.ToString))
                    .Add(New SqlColumn(CT6.GlycolPercentage, SqlDataType.Number, chiller.GlycolPercentage.ToString))
                    .Add(New SqlColumn(CT6.Hertz, SqlDataType.Number, chiller.Hertz.ToString))
                    '.Add(New SqlColumn(CT6.ID, SqlDataType.String, chiller.Id.ToString))
                    .Add(New SqlColumn(CT6.LeavingFluidTemp, SqlDataType.Number, chiller.LeavingFluidTemp.ToString))
                    .Add(New SqlColumn(CT6.Model, SqlDataType.String, chiller.Model))
                    .Add(New SqlColumn(CT6.ModelDesc, SqlDataType.String, chiller.ModelDesc))
                    .Add(New SqlColumn(CT6.Name, SqlDataType.String, chiller.name))
                    .Add(New SqlColumn(CT6.NewCoefficients, SqlDataType.Boolean, System.Math.Abs(CInt(chiller.NewCoefficients)).ToString))
                    .Add(New SqlColumn(CT6.Notes, SqlDataType.String, chiller.Notes))
                    .Add(New SqlColumn(CT6.NumCoils1, SqlDataType.Number, chiller.NumCoils1.ToString))
                    .Add(New SqlColumn(CT6.NumCoils2, SqlDataType.Number, chiller.NumCoils2.ToString))
                    .Add(New SqlColumn(CT6.NumCompressors1, SqlDataType.Number, chiller.NumCompressors1.ToString))
                    .Add(New SqlColumn(CT6.NumCompressors2, SqlDataType.Number, chiller.NumCompressors2.ToString))
                    .Add(New SqlColumn(CT6.NumEvap, SqlDataType.Number, chiller.NumEvap.ToString))
                    .Add(New SqlColumn(CT6.ProcessId, SqlDataType.String, chiller.id.ToString))
                    '.Add(New SqlColumn(CT6.PumpWatts, SqlDataType.Number, chiller.PumpWatts.ToString))
                    .Add(New SqlColumn(CT6.Refrigerant, SqlDataType.String, chiller.Refrigerant))
                    .Add(New SqlColumn(CT6.Revision, SqlDataType.Number, chiller.Revision.ToString))
                    .Add(New SqlColumn(CT6.RevisionDate, SqlDataType.Date, CStr(CNull.ToDate(chiller.RevisionDate))))
                    .Add(New SqlColumn(CT6.SafetyOverride, SqlDataType.Boolean, System.Math.Abs(CInt(chiller.SafetyOverride)).ToString))
                    .Add(New SqlColumn(CT6.Series, SqlDataType.String, chiller.Series))
                    .Add(New SqlColumn(CT6.SpecificGravity, SqlDataType.Number, chiller.SpecificGravity.ToString))
                    .Add(New SqlColumn(CT6.SpecificHeat, SqlDataType.Number, chiller.SpecificHeat.ToString))
                    .Add(New SqlColumn(CT6.SubCooling, SqlDataType.Boolean, System.Math.Abs(CInt(chiller.SubCooling)).ToString)) 'bool
                    .Add(New SqlColumn(CT6.SuctionLineLoss, SqlDataType.Number, chiller.SuctionLineLoss.ToString))
                    .Add(New SqlColumn(CT6.System, SqlDataType.String, chiller.System))
                    .Add(New SqlColumn(CT6.TempRange, SqlDataType.Number, chiller.TempRange.ToString))
                    .Add(New SqlColumn(CT6.Version, SqlDataType.String, chiller.Version))
                    .Add(New SqlColumn(CT6.Volts, SqlDataType.Number, chiller.Volts.ToString))

                    '.Add(New SqlColumn(CT6.ATIncrement, SqlDataType.Number, chiller.ATIncrement.ToString))
                    '.Add(New SqlColumn(CT6.ATMax, SqlDataType.Number, chiller.ATMax.ToString))
                    '.Add(New SqlColumn(CT6.ATMin, SqlDataType.Number, chiller.ATMin.ToString))
                    '.Add(New SqlColumn(CT6.TEIncrement, SqlDataType.Number, chiller.TEIncrement.ToString))
                    '.Add(New SqlColumn(CT6.TEMax, SqlDataType.Number, chiller.TEMax.ToString))
                    '.Add(New SqlColumn(CT6.TEMin, SqlDataType.Number, chiller.TEMin.ToString))
                    .Add(New SqlColumn(CT6.Fan, SqlDataType.String, chiller.Fan))
                    .Add(New SqlColumn(CT6.NumFans1, SqlDataType.Number, chiller.NumFans1.ToString))
                    .Add(New SqlColumn(CT6.NumFans2, SqlDataType.Number, chiller.NumFans2.ToString))
                    .Add(New SqlColumn(CT6.FinsPerInch1, SqlDataType.Number, chiller.FinsPerInch1.ToString))
                    .Add(New SqlColumn(CT6.FinsPerInch2, SqlDataType.Number, chiller.FinsPerInch2.ToString))
                    .Add(New SqlColumn(CT6.ProcessRevisionDescription, SqlDataType.String, chiller.ProcessRevisionDescription))
                    .Add(New SqlColumn(CT6.ProjectRevision, SqlDataType.Number, chiller.ProjectRevision.ToString))
                    .Add(New SqlColumn(CT6.SubCooling1, SqlDataType.Boolean, System.Math.Abs(CInt(chiller.SubCooling1)).ToString))
                    .Add(New SqlColumn(CT6.SubCooling2, SqlDataType.Boolean, System.Math.Abs(CInt(chiller.SubCooling2)).ToString))
                    .Add(New SqlColumn(CT6.SubCoolingPercent1, SqlDataType.Number, chiller.SubCoolingPercent1.ToString))
                    .Add(New SqlColumn(CT6.SubCoolingPercent2, SqlDataType.Number, chiller.SubCoolingPercent2.ToString))
                    .Add(New SqlColumn(CT6.CondenserTD1, SqlDataType.Number, chiller.CondenserTD1.ToString))
                    .Add(New SqlColumn(CT6.CondenserTD2, SqlDataType.Number, chiller.CondenserTD2.ToString))
                    .Add(New SqlColumn(CT6.FinHeight1, SqlDataType.Number, chiller.FinHeight1.ToString))
                    .Add(New SqlColumn(CT6.FinHeight2, SqlDataType.Number, chiller.FinHeight2.ToString))
                    .Add(New SqlColumn(CT6.FinLength1, SqlDataType.Number, chiller.FinLength1.ToString))
                    .Add(New SqlColumn(CT6.FinLength2, SqlDataType.Number, chiller.FinLength2.ToString))
                    '.Add(New SqlColumn(CT6.Division, SqlDataType.String, chiller.Division.ToString))
                    .Add(New SqlColumn(CT6.CfmOverride, SqlDataType.Number, chiller.CfmOverride.ToString))

                End With

         Return columns
      End Function

   End Class

End Class

End Namespace
