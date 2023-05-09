Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Text
Imports Rae.Io.Text
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.Data.Sql
Imports Rae.RaeSolutions.DataAccess.Projects

Imports ECP = Rae.RaeSolutions.DataAccess.Projects.Tables.EvapChillerProcessTable
Imports ET3 = RAE.RAESolutions.DataAccess.Projects.Tables.EquipmentTable
Imports COT = Rae.RaeSolutions.DataAccess.Projects.Tables.CondensingUnitTable
Imports CNull = Rae.ConvertNull
Imports OtherCostsDA = Rae.RaeSolutions.DataAccess.Projects.OtherEquipmentCostsDA
Imports CO3 = RAE.RAESolutions.DataAccess.Projects.Tables.CondensingUnitTable
Imports CT3 = RAE.RAESolutions.DataAccess.Projects.Tables.EvapChillerProcessTable

Namespace Rae.RaeSolutions.DataAccess.Projects

Public Class EvaporativeCondenerChillerBalanceDa

#Region "Public Methods"
   Shared Function Retrieve(id As item_id) As EvaporativeCondenserChillerBalance
      Dim chiller = retrieveEvap(id)
      Return chiller
   End Function

   Shared Function Retrieve(id As item_id, RevNumber As Single) As EvaporativeCondenserChillerBalance
      Dim condenser = retrieveEvap(id, RevNumber)
      Return condenser
   End Function
#End Region

#Region "Private Methods"

   Private Shared Function retrieveEvap(id As item_id, Optional RevNumber As Single = -1, Optional ProjRevision As Single = -1) As EvaporativeCondenserChillerBalance
      Dim reader As IDataReader
      Dim sql As String

      Dim chiller As EvaporativeCondenserChillerBalance

      If RevNumber > -1 Then
         ' Get the specified revision...
         sql = "SELECT * FROM EvapChillerProcesses " & _
               "WHERE ProcessID='" & id.Id & "' " & _
               "AND [Revision] = " & RevNumber '& _
      Else
         ' Get the most current revision...
         sql = "SELECT * FROM EvapChillerProcesses " & _
               "WHERE ProcessID='" & id.Id & "' " & _
               "ORDER BY [Revision] DESC"
      End If

      Dim connection = Common.CreateConnection(Common.ProjectsDbPath)


      Dim command = connection.CreateCommand()
      command.CommandText = sql

      Try
         connection.Open()
         reader = command.ExecuteReader()
         If reader.Read Then
            chiller = New EvaporativeCondenserChillerBalance(id)

            ' retrieves the rest of the properties
            With chiller
               .ProjectRevision = CInt(reader(ECP.ProjectRevision))
               .ProcessRevisionDescription = reader(ECP.ProcessRevisionDescription).ToString
               GetEnumValue(reader(ECP.Division).ToString, .Division)
               GetEnumValue(reader(ECP.ApproachRange).ToString, .ApproachRange)
               GetEnumValue(reader(ECP.CapacityType).ToString, .CapacityType)
               
               .sound_attenuation_option_selected = ConvertNull.ToBoolean(reader(ECP.SoundAttenuationOption))
               .subcooling_coil_option_selected = ConvertNull.ToBoolean(reader(ECP.SubcoolingCoilOption))

               .Altitude = CDbl(reader("Altitude").ToString)
               .AmbientTemp = CDbl(reader("AmbientTemp").ToString)
               .Approach = reader(ECP.Approach).ToString
               .ATIncrement = CDbl(reader(ECP.ATIncrement).ToString)
               .ATMax = CDbl(reader(ECP.ATMax).ToString)
               .ATMin = CDbl(reader(ECP.ATMin).ToString)
               .CatalogRating = CBool(reader("CatalogRating").ToString)
               .Circuit1 = CBool(reader(ECP.Circuit1))
               .Circuit2 = CBool(reader(ECP.Circuit2))
               .Compressors1 = reader(ECP.Compressors1).ToString
               .Compressors2 = reader(ECP.Compressors2).ToString
               .Condenser1 = reader(ECP.Condenser1).ToString
               .custom_condenser_model = reader(ECP.custom_condenser_model).toString()
               .fan_motor_hp = cdbl(reader(ECP.fan_motor_hp))
               .pump_motor_hp = cdbl(reader(ECP.pump_motor_hp))
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
               .LeavingFluidTemp = CDbl(reader(ECP.LeavingFluidTemp))
               .Model = reader(ECP.Model).ToString
               .ModelDesc = reader(ECP.ModelDesc).ToString
               .name = reader(ECP.Name).ToString
               .NewCoefficients = CBool(reader(ECP.NewCoefficients))
               .Notes = reader(ECP.Notes).ToString
               .NumCoils1 = CDbl(reader(ECP.NumCoils1))
               .NumCoils2 = CDbl(reader(ECP.NumCoils2))
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
               .TEIncrement = CDbl(reader(ECP.TEIncrement))
               .TEMax = CDbl(reader(ECP.TEMax))
               .TEMin = CDbl(reader(ECP.TEMin))
               .Version = reader(ECP.Version).ToString
               .Volts = CDbl(reader(ECP.Volts))
            End With
         End If
      Finally
         If reader IsNot Nothing Then reader.Close()
         If connection.State <> ConnectionState.Closed Then connection.Close()
      End Try

      Return chiller
   End Function

   Overloads Shared Function Create(chiller As EvaporativeCondenserChillerBalance) As Integer
      Dim transaction As IDbTransaction
      Dim numRowsAffected As Integer

      Dim found = Exists(chiller.id.ToString)
      Dim connection = Common.CreateConnection(Common.ProjectsDbPath)

      Try
         connection.Open()
         transaction = connection.BeginTransaction()

         If found = False Then
            ' inserts only general process data into Processes Table
            ProcessItemDA.Create(connection, transaction, chiller, ECP.TableName)
         End If

         ' inserts values into EvapChillerProcessesTable
         CreateItem(connection, transaction, chiller)
         transaction.Commit()
      Catch ex As Exception
         If Not transaction Is Nothing Then _
            transaction.Rollback()
         Throw New ApplicationException("Attempt to insert evaporative condenser chiller balance into database failed. Transaction was rolled back.", ex)
      Finally
         If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
      End Try

      Return numRowsAffected
   End Function


   Shared Sub CreateItem(connection As IDbConnection, transaction As IDbTransaction, process As EvaporativeCondenserChillerBalance)
      Dim sqlCommand = SqlFactory.GetInsertChillerSql(process)
      Dim command = connection.CreateCommand
      command.CommandText = sqlCommand
      command.Transaction = transaction
      command.ExecuteNonQuery()
   End Sub

   Shared Sub Update(chiller As EvaporativeCondenserChillerBalance)
      Dim numRowsAffected As Integer

      Dim sqlCommand = SqlFactory.GetUpdateChillerSql(chiller)
      Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
      Dim command = connection.CreateCommand()
      command.CommandText = sqlCommand

      Try
         connection.Open()
         numRowsAffected = command.ExecuteNonQuery()
      Finally
         If Not connection.State.Equals(System.Data.ConnectionState.Closed) Then connection.Close()
      End Try
   End Sub


   Shared Function Exists(id As String) As Boolean
      Dim reader As iDataReader
      Dim found As Boolean = False

      Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
      Dim sql = "SELECT * FROM Processes WHERE ID = '" + id + "'"
      Dim command = connection.CreateCommand()
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
      Finally
         If reader IsNot Nothing Then reader.Close()
         If connection.State <> ConnectionState.Closed Then connection.Close()
      End Try

      Return found
   End Function


#End Region

   Private Class SqlFactory

      Shared Function GetInsertChillerSql(chiller As EvaporativeCondenserChillerBalance) As String
         Dim affectedColumns As List(Of SqlColumn) = ChillerColumns(chiller)
                Dim builder As New SqlBuilder(affectedColumns, CT3.TableName)

                Return builder.GenerateInsertCommand()
      End Function


      ''' <summary>Gets SQL to update chiller equipment item.</summary>
      Shared Function GetUpdateChillerSql(chiller As EvaporativeCondenserChillerBalance) As String
         Dim affectedCols As List(Of SqlColumn) = ChillerColumns(chiller)
         Dim criteriaCols As New List(Of SqlColumn)
                criteriaCols.Add(New SqlColumn(CT3.ProcessId, SqlDataType.String, chiller.id.Id))
                criteriaCols.Add(New SqlColumn(CT3.Revision, SqlDataType.Number, chiller.Revision.ToString))
                Dim builder As New SqlBuilder(affectedCols, CT3.TableName, criteriaCols)
                Return builder.GenerateUpdateCommand()
      End Function


      ''' <summary>Chiller equipment item columns</summary>
      Private Shared Function ChillerColumns(chiller As EvaporativeCondenserChillerBalance) As List(Of SqlColumn)
         Dim columns As New List(Of SqlColumn)

         With columns
                    .Add(New SqlColumn(CT3.Altitude, SqlDataType.Number, chiller.Altitude.ToString))
                    .Add(New SqlColumn(CT3.AmbientTemp, SqlDataType.Number, chiller.AmbientTemp.ToString))
                    .Add(New SqlColumn(CT3.Approach, SqlDataType.String, CNull.ToString(chiller.Approach)))
                    .Add(New SqlColumn(CT3.ApproachRange, SqlDataType.String, CNull.ToString(chiller.ApproachRange.ToString)))
                    .Add(New SqlColumn(CT3.CapacityType, SqlDataType.String, CStr(CInt(chiller.CapacityType))))
                    .Add(New SqlColumn(CT3.CatalogRating, SqlDataType.Boolean, System.Math.Abs(CInt(chiller.CatalogRating)).ToString))
                    .Add(New SqlColumn(CT3.Circuit1, SqlDataType.Boolean, System.Math.Abs(CInt(chiller.Circuit1)).ToString))
                    .Add(New SqlColumn(CT3.Circuit2, SqlDataType.Boolean, System.Math.Abs(CInt(chiller.Circuit2)).ToString))
                    .Add(New SqlColumn(CT3.Compressors1, SqlDataType.String, CNull.ToString(chiller.Compressors1)))
                    .Add(New SqlColumn(CT3.Compressors2, SqlDataType.String, CNull.ToString(chiller.Compressors2)))
                    .Add(New SqlColumn(CT3.Condenser1, SqlDataType.String, CNull.ToString(chiller.Condenser1)))
                    .Add(New SqlColumn(CT3.custom_condenser_model, SqlDataType.String, CNull.ToString(chiller.custom_condenser_model)))
                    .Add(New SqlColumn(CT3.fan_motor_hp, SqlDataType.Number, chiller.fan_motor_hp.ToString()))
                    .Add(New SqlColumn(CT3.pump_motor_hp, SqlDataType.Number, chiller.pump_motor_hp.ToString()))
                    .Add(New SqlColumn(CT3.Condenser2, SqlDataType.String, CNull.ToString(chiller.Condenser2)))
                    .Add(New SqlColumn(CT3.CondenserCapacity1, SqlDataType.Number, chiller.CondenserCapacity1.ToString))
                    .Add(New SqlColumn(CT3.CondenserCapacity2, SqlDataType.Number, chiller.CondenserCapacity2.ToString))
                    .Add(New SqlColumn(CT3.CoolingMedia, SqlDataType.String, CNull.ToString(chiller.CoolingMedia)))
                    .Add(New SqlColumn(CT3.CreatedBy, SqlDataType.String, CNull.ToString(chiller.CreatedBy)))
                    .Add(New SqlColumn(CT3.DischargeLineLoss, SqlDataType.Number, chiller.DischargeLineLoss.ToString))
                    .Add(New SqlColumn(CT3.Evap10Degr1, SqlDataType.Number, chiller.Evap10Degr1.ToString))
                    .Add(New SqlColumn(CT3.Evap10Degr2, SqlDataType.Number, chiller.Evap10Degr2.ToString))
                    .Add(New SqlColumn(CT3.Evap8Degr1, SqlDataType.Number, chiller.Evap8Degr1.ToString))
                    .Add(New SqlColumn(CT3.Evap8Degr2, SqlDataType.Number, chiller.Evap8Degr2.ToString))
                    .Add(New SqlColumn(CT3.EvaporatorCapacity, SqlDataType.Number, chiller.EvaporatorCapacity.ToString))
                    .Add(New SqlColumn(CT3.EvaporatorModel, SqlDataType.String, CNull.ToString(chiller.EvaporatorModel)))
                    .Add(New SqlColumn(CT3.EvaporatorModelDesc, SqlDataType.String, CNull.ToString(chiller.EvaporatorModelDesc)))
                    .Add(New SqlColumn(CT3.FanWatts, SqlDataType.Number, chiller.FanWatts.ToString))
                    .Add(New SqlColumn(CT3.Fluid, SqlDataType.String, CNull.ToString(chiller.Fluid)))
                    .Add(New SqlColumn(CT3.FoulingFactor, SqlDataType.Number, chiller.FoulingFactor.ToString))
                    .Add(New SqlColumn(CT3.GlycolPercentage, SqlDataType.Number, chiller.GlycolPercentage.ToString))
                    .Add(New SqlColumn(CT3.Hertz, SqlDataType.Number, chiller.Hertz.ToString))
                    .Add(New SqlColumn(CT3.LeavingFluidTemp, SqlDataType.Number, chiller.LeavingFluidTemp.ToString))
                    .Add(New SqlColumn(CT3.Model, SqlDataType.String, CNull.ToString(chiller.Model)))
                    .Add(New SqlColumn(CT3.ModelDesc, SqlDataType.String, CNull.ToString(chiller.ModelDesc)))
                    .Add(New SqlColumn(CT3.Name, SqlDataType.String, CNull.ToString(chiller.name)))
                    .Add(New SqlColumn(CT3.NewCoefficients, SqlDataType.Boolean, System.Math.Abs(CInt(chiller.NewCoefficients)).ToString))
                    .Add(New SqlColumn(CT3.Notes, SqlDataType.String, CNull.ToString(chiller.Notes)))
                    .Add(New SqlColumn(CT3.NumCoils1, SqlDataType.Number, chiller.NumCoils1.ToString))
                    .Add(New SqlColumn(CT3.NumCoils2, SqlDataType.Number, chiller.NumCoils2.ToString))
                    .Add(New SqlColumn(CT3.NumCompressors1, SqlDataType.Number, chiller.NumCompressors1.ToString))
                    .Add(New SqlColumn(CT3.NumCompressors2, SqlDataType.Number, chiller.NumCompressors2.ToString))
                    .Add(New SqlColumn(CT3.NumEvap, SqlDataType.Number, chiller.NumEvap.ToString))
                    .Add(New SqlColumn(CT3.ProcessId, SqlDataType.String, CNull.ToString(chiller.id.ToString)))
                    .Add(New SqlColumn(CT3.PumpWatts, SqlDataType.Number, chiller.PumpWatts.ToString))
                    .Add(New SqlColumn(CT3.Refrigerant, SqlDataType.String, CNull.ToString(chiller.Refrigerant)))
                    .Add(New SqlColumn(CT3.Revision, SqlDataType.Number, chiller.Revision.ToString))
                    .Add(New SqlColumn(CT3.RevisionDate, SqlDataType.Date, CStr(CNull.ToDate(chiller.RevisionDate))))
                    .Add(New SqlColumn(CT3.SafetyOverride, SqlDataType.Boolean, System.Math.Abs(CInt(chiller.SafetyOverride)).ToString))
                    .Add(New SqlColumn(CT3.Series, SqlDataType.String, CNull.ToString(chiller.Series)))
                    .Add(New SqlColumn(CT3.SpecificGravity, SqlDataType.Number, chiller.SpecificGravity.ToString))
                    .Add(New SqlColumn(CT3.SpecificHeat, SqlDataType.Number, chiller.SpecificHeat.ToString))
                    .Add(New SqlColumn(CT3.SubCooling, SqlDataType.Number, chiller.SubCooling.ToString))
                    .Add(New SqlColumn(CT3.SuctionLineLoss, SqlDataType.Number, chiller.SuctionLineLoss.ToString))
                    .Add(New SqlColumn(CT3.System, SqlDataType.String, CNull.ToString(chiller.System)))
                    .Add(New SqlColumn(CT3.TempRange, SqlDataType.Number, chiller.TempRange.ToString))
                    .Add(New SqlColumn(CT3.Version, SqlDataType.String, CNull.ToString(chiller.Version)))
                    .Add(New SqlColumn(CT3.Volts, SqlDataType.Number, chiller.Volts.ToString))
                    .Add(New SqlColumn(CT3.ATIncrement, SqlDataType.Number, chiller.ATIncrement.ToString))
                    .Add(New SqlColumn(CT3.ATMax, SqlDataType.Number, chiller.ATMax.ToString))
                    .Add(New SqlColumn(CT3.ATMin, SqlDataType.Number, chiller.ATMin.ToString))
                    .Add(New SqlColumn(CT3.TEIncrement, SqlDataType.Number, chiller.TEIncrement.ToString))
                    .Add(New SqlColumn(CT3.TEMax, SqlDataType.Number, chiller.TEMax.ToString))
                    .Add(New SqlColumn(CT3.TEMin, SqlDataType.Number, chiller.TEMin.ToString))

                    .Add(New SqlColumn(CT3.Division, SqlDataType.String, chiller.Division.ToString))
                    .Add(New SqlColumn(CT3.SubcoolingCoilOption, SqlDataType.Boolean, chiller.subcooling_coil_option_selected.ToString()))
                    .Add(New SqlColumn(CT3.SoundAttenuationOption, SqlDataType.Boolean, chiller.sound_attenuation_option_selected.ToString()))
                End With

         Return columns
      End Function

   End Class

End Class
End Namespace