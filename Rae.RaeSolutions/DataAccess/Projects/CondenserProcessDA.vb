Imports System
Imports System.Data
Imports System.Text
Imports Rae.Io.Text
Imports Rae.RaeSolutions.Business.Entities
Imports System.Collections.Generic
Imports Rae.RaeSolutions.DataAccess.Projects

Imports ECP = Rae.RaeSolutions.DataAccess.Projects.Tables.CondenserProcessesTable
Imports ET4 = RAE.RAESolutions.DataAccess.Projects.Tables.EquipmentTable
Imports COT = Rae.RaeSolutions.DataAccess.Projects.Tables.CondensingUnitTable
Imports CNull = Rae.ConvertNull
Imports OtherCostsDA = Rae.RaeSolutions.DataAccess.Projects.OtherEquipmentCostsDA
Imports CO4 = RAE.RAESolutions.DataAccess.Projects.Tables.CondensingUnitTable


Namespace Rae.RaeSolutions.DataAccess.Projects



   Public Class CondenserProcessDA

#Region "Public Methods"
      Public Shared Function Retrieve(ByVal id As item_id) As CondenserProcessItem
         Dim condenser As CondenserProcessItem

         ' retrieves fluidCooler
         condenser = RetrieveCondenser(id)

         Return condenser
      End Function

      Public Shared Function Retrieve(ByVal id As item_id, ByVal RevNumber As Single) As CondenserProcessItem
         Dim condenser As CondenserProcessItem

         ' retrieves fluidCooler
         condenser = RetrieveCondenser(id, RevNumber)

         Return condenser
      End Function

      'Public Overloads Shared Function Create(ByVal processID As ItemId, ByVal projectID As ItemId, ByVal name As String) As Integer
      '    Dim numRowsAffected As Integer
      '    Dim condensingUnit As New CondenserProcessItem()

      '    ' creates condensing unit
      '    Create(condensingUnit)

      '    Return numRowsAffected
      'End Function

#End Region

#Region "Private Methods"

      Private Shared Function RetrieveCondenser(ByVal id As item_id, Optional ByVal RevNumber As Single = -1) As CondenserProcessItem
         Dim connection As IDbConnection
         Dim command As IDbCommand
         Dim reader As IDataReader
         Dim connectionString As String
         'Dim sql As New StringBuilder
         Dim sql As String
         'Dim equipmentId, projectId As ItemId
         'Dim name As String
         'Dim division As Business.Division 

         Dim condenser As CondenserProcessItem

         connectionString = Common.GetConnectionString(Common.ProjectsDbPath)

         ' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
         ' Added by JOSHH on 8/7/2006
         ' Determin which revision to get..
         ' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
         If RevNumber > -1 Then
            ' Get the specified revision number
            sql = "SELECT * FROM CondenserProcesses " & _
                  "WHERE ProcessID='" & id.Id & "' " & _
                  "AND [Revision] = " & RevNumber
         Else
            ' Get the most current revision
            sql = "SELECT * FROM CondenserProcesses " & _
                  "WHERE ProcessID='" & id.Id & "' " & _
                  "ORDER BY [Revision] DESC"
         End If
         ' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

         connection = Common.CreateConnection(Common.ProjectsDbPath)
         command = connection.CreateCommand
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
               'condenser = New CondenserProcessItem(name, division, equipmentId, New ProjectManager(projectId))
               condenser = New CondenserProcessItem(id)

               ' retrieves the rest of the properties
               With condenser
                  ' DBNull.Value.ToString = "", no exception is raised
                  ' TEST: DateGenerated is set by ID?
                  '.MetaData.Author = reader(ET.Author).ToString

                  'revision
                  'revision date
                  'createdby
                  'version
                  'notes

                  '.ProjectRevision = cint(reader("ProjectRevision"))
                  '.ProcessRevisionDescription = reader("ProcessRevisionDescription").ToString

                  .CreatedBy = reader("CreatedBy").ToString
                  GetEnumValue(reader("Division").ToString, .Division)
                  .Notes = reader("Notes").ToString
                  .ProjectRevision = CInt(reader("ProjectRevision").ToString)
                  .ProcessRevisionDescription = reader("ProcessRevisionDescription").ToString
                  .Version = reader("Version").ToString

                  .Altitude = CDbl(reader("Altitude").ToString)
                  .AmbientTemp = CDbl(reader("AmbientTemp").ToString)
                  .CatalogRating = CBool(reader("CatalogRating").ToString)
                  .CFM = CDbl(reader("CFM").ToString)
                  .CoilDesc = reader("CoilDesc").ToString
                  .CoilLength = CDbl(reader("CoilLength").ToString)
                  .CoilWidth = CDbl(reader("CoilWidth").ToString)
                  .ExtStaticPressure = CDbl(reader("ExtStaticPressure").ToString)
                  .Fan = reader("Fan").ToString
                  .id = id
                  .Model = reader("Model").ToString
                  .name = reader("Name").ToString
                  .NumFans = CInt(reader("NumFans").ToString)

                  ' Try to set project manager...
                  If ProcessItemDA.GetProjectID(id.Id) IsNot Nothing Then
                     .ProjectManager = New project_manager(ProcessItemDA.GetProjectID(id.Id))
                  End If

                  '.MetaData
                  .Revision = CSng(reader("Revision"))
                  .RevisionDate = CDate(reader("RevisionDate"))
                  .Refrigerant = reader("Refrigerant").ToString
                  .Series = reader("Series").ToString
                  .SubCooling = CBool(reader("SubCooling").ToString)
                  .SubCoolingPercentage = CDbl(reader("SubCoolingPercentage").ToString)
                  .TD = CDbl(reader("TD").ToString)

                  'With .Equipment
                  '    .Model = reader(ET.Model).ToString
                  '    .Series = reader(ET.Series).ToString
                  '    .CustomModel = reader(ET.CustomModel).ToString
                  'End With

                  ' specs
                  'With .Specs
                  '    .AmbientTemp.SetValue(reader(CT.AmbientTemp))
                  '    .Fpi.SetValue(reader(CT.Fpi))
                  '    .Refrigerant = reader(CT.Refrigerant).ToString
                  '    .SubCooling = CBool(reader(CT.SubCooling).ToString)
                  '    .TempDifference.SetValue(reader(CT.TempDifference))
                  '    .TotalHeatRejection1.SetValue(reader(CT.ThrCircuit1))
                  '    .TotalHeatRejection2.SetValue(reader(CT.ThrCircuit2))
                  '    .TotalHeatRejection3.SetValue(reader(CT.ThrCircuit3))
                  '    .TotalHeatRejection4.SetValue(reader(CT.ThrCircuit4))
                  'End With

                  ' common specs
                  'With .CommonSpecs
                  '    .Altitude.SetValue(reader(ET.Altitude))
                  '    .ControlVoltage.Parse(CNull.ToString(reader(ET.ControlVoltage)))
                  '    .Height.SetValue(reader(ET.Height))
                  '    .Length.SetValue(reader(ET.Length))
                  '    .Mca.SetValue(reader(ET.Mca))
                  '    .OperatingWeight.SetValue(reader(ET.OperatingWeight))
                  '    .Rla.SetValue(reader(ET.Rla))
                  '    .ShippingWeight.SetValue(reader(ET.ShippingWeight))
                  '    .UnitVoltage.Parse(CNull.ToString(reader(ET.UnitVoltage)))
                  '    .Width.SetValue(reader(ET.Width))
                  'End With

                  ' pricing
                  'With .Pricing
                  '    ' there is no list price db field
                  '    ' others list is handled in seperate method
                  '    .OtherPrice = CNull.ToDouble(reader(ET.OtherPrice))
                  '    .OtherDescription = reader(ET.OtherDescription).ToString
                  '    .Quantity = CNull.ToInteger(reader(ET.Quantity))
                  '    .CommissionRate = CNull.ToDouble(reader(ET.CommissionRate))
                  '    .ParMultiplier = CNull.ToDouble(reader(ET.ParMultiplier))
                  '    .Freight = CNull.ToDouble(reader(ET.FreightPrice))
                  '    .StartUp = CNull.ToDouble(reader(ET.StartUpPrice))
                  '    .Warranty = CNull.ToDouble(reader(ET.WarrantyPrice))
                  'End With

                  '.Tag = CNull.ToString(reader(ET.Tag))
                  '.SpecialInstructions = CNull.ToString(reader(ET.Notes))
                  '.Included = CNull.ToBoolean(reader(ET.Included))

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

      Public Shared Function Exists(ByVal id As String) As Boolean
         Dim connection As IDbConnection
         Dim command As IDbCommand
         Dim reader As IDataReader
         Dim connectionString As String, sql As String
         Dim found As Boolean = False

         'sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}] = '{2}'", _
         '   PT.TableName, PT.ProjectId, id.ToString)
         sql = "SELECT * FROM Processes WHERE ID = '" + id + "'"
         connection = Common.CreateConnection(Common.ProjectsDbPath)
         command = connection.CreateCommand
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

      Public Shared Function Exists(ByVal connection As IDbConnection, ByVal transaction As IDbTransaction, ByVal id As String) As Boolean
         'Dim connection As iDbConnection
         Dim command As IDbCommand
         Dim reader As IDataReader
         'Dim connectionString As String
         Dim sql As String
         Dim found As Boolean = False

         'connectionString = Common.GetConnectionString(Common.ProjectsDbPath)
         'connection = New OleDbConnection(connectionString)

         'sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}] = '{2}'", _
         '   PT.TableName, PT.ProjectId, id.ToString)
         sql = "SELECT * FROM Processes WHERE ProcessId = '" + id + "'"
         command = connection.CreateCommand
         command.CommandText = sql
         command.Transaction = transaction

         Try
            'connection.Open()
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
            'If reader IsNot Nothing Then reader.Close()
            'If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try

         Return found
      End Function

      Public Overloads Shared Function Create(ByVal condenser As CondenserProcessItem) As Integer
         Dim connectionString As String
         Dim transaction As IDbTransaction
         Dim connection As IDbConnection
         Dim numRowsAffected As Integer

         Dim found As Boolean
         found = Exists(condenser.id.ToString)

         connection = Common.CreateConnection(Common.ProjectsDbPath)

         Try
            connection.Open()

            ' begins transaction (everything can be rolled back from the beginning of the transaction until it is committed)
            transaction = connection.BeginTransaction()

            If found = False Then
               ' inserts only general process data into Processes Table
               ProcessItemDA.Create(connection, transaction, condenser, ECP.TableName)
            End If
            ' inserts values into CondenserProcessesTable
            CreateItem(connection, transaction, condenser)
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

      Friend Shared Function CreateItem(ByVal connection As IDbConnection, ByVal transaction As IDbTransaction, _
      ByVal process As CondenserProcessItem) As Integer
         Dim sql As String
         Dim topID As Integer = 0
         Dim numRowsAffected As Integer = 0

         Try

            sql = "INSERT INTO CondenserProcesses (ProcessID, Division, CreatedBy, Version, Notes, ProcessRevisionDescription, Revision, RevisionDate, ProjectRevision, Altitude, AmbientTemp, CatalogRating, CFM, CoilDesc, CoilLength, CoilWidth, ExtStaticPressure, Fan, Model, Name, NumFans, Refrigerant, Series, SubCooling, SubCoolingPercentage, TD) VALUES("

            sql = sql + "'" + process.id.ToString + "', "

            sql = sql + "'" + process.Division.ToString & "', "

            sql = sql + "'" + process.CreatedBy + "', "

            sql = sql + "'" + process.Version + "', "

            sql = sql + "'" + process.Notes + "', "

            sql = sql + "'" + process.ProcessRevisionDescription + "', "

            sql &= process.Revision.ToString & ", "

            sql &= "'" & CNull.ToDate(process.RevisionDate).ToString & "', "

            sql = sql + process.ProjectRevision.ToString + ", "

            'altitude
            sql = sql + process.Altitude.ToString + ", "
            'ambient temp
            sql = sql + process.AmbientTemp.ToString + ", "
            'catalograting
            sql = sql + System.Math.Abs(CInt(process.CatalogRating)).ToString + ", "
            'cfm
            sql = sql + process.CFM.ToString + ", "
            'coil descr 
            sql = sql + "'" + process.CoilDesc + "', "
            'coil length
            sql = sql + process.CoilLength.ToString + ", "
            'coil width
            sql = sql + process.CoilWidth.ToString + ", "
            'ext static pressure
            sql = sql + process.ExtStaticPressure.ToString + ", "
            'fan
            sql = sql + "'" + process.Fan + "', "
            'model
            sql = sql + "'" + process.Model + "', "
            'name
            sql = sql + "'" + process.name + "', "
            'num fans
            sql = sql + process.NumFans.ToString + ", "
            'refrigerant
            sql = sql + "'" + process.Refrigerant + "', "
            'series
            sql = sql + "'" + process.Series + "', "
            'subcooling
            sql = sql + System.Math.Abs(CInt(process.SubCooling)).ToString + ", "
            'subcooling %
            sql = sql + process.SubCoolingPercentage.ToString + ", "
            'TD
            sql = sql + process.TD.ToString
            sql = sql + ")"

            Dim command As IDbCommand = connection.CreateCommand
            command.CommandText = sql
            command.Transaction = transaction
            numRowsAffected = command.ExecuteNonQuery()
         Catch ex As DataException
            Throw
         End Try

         Return numRowsAffected
      End Function

      Public Shared Sub Update(ByVal connection As IDbConnection, ByVal transaction As IDbTransaction, _
    ByVal process As CondenserProcessItem)
         'Dim connection As iDbConnection
         'Dim transaction As iDbTransaction
         Dim command As IDbCommand
         Dim connectionString, sql As String
         Dim topID As Integer = 0
         'Dim reader As iDataReader

         'connectionString = Common.GetConnectionString(Common.ProjectsDbPath)
         'connection = New OleDbConnection(connectionString)

         Try
            'connection.Open()
            'transaction = connection.BeginTransaction()

            ' updates equipment table
            'EquipmentItemDA.Update(connection, transaction, condenser)

            ' updates fluidCooler table
            'sql = SqlFactory.GetUpdateCondenserSql(condenser)
            'UPDATE Reps SET Reps.RepNum = "fds", Reps.FirstName = "rt", Reps.LastName = "oui";

            'sql = "SELECT TOP 1 ID FROM CondenserProcesses"
            'Dim commandSel As New OleDbCommand(sql, connection, transaction)
            ''commandSel.ExecuteNonQuery()
            ''connection.Open()
            'reader = commandSel.ExecuteReader()
            'While reader.Read
            '    topID = CInt(reader("ID").ToString)
            'End While

            sql = "UPDATE CondenserProcesses SET "

            'id
            'autoincrement?
            'If topID > 0 Then
            '    topID = topID + 1
            'End If
            'sql = sql + " ID = " + topID.ToString + ", "
            'End If
            'processid
            'sql = sql + "ProcessId = '" + process.Id.ToString + "', "
            ' revision
            sql &= "Revision=" & process.Revision.ToString & ", "
            sql &= "RevisionDate=" & process.RevisionDate.ToString & ", "
            'altitude
            sql = sql + "Altitude = " + process.Altitude.ToString + ", "
            'ambient temp
            sql = sql + "AmbientTemp = " + process.AmbientTemp.ToString + ", "
            'catalograting
            sql = sql + "CatalogRating = " + System.Math.Abs(CInt(process.CatalogRating)).ToString + ", "
            'cfm
            sql = sql + "CFM = " + process.CFM.ToString + ", "
            'coil descr 
            sql = sql + "CoilDesc = '" + process.CoilDesc.ToString + "', "
            'coil length
            sql = sql + "CoilLength = " + process.CoilLength.ToString + ", "
            'coil width
            sql = sql + "CoilWidth = " + process.CoilWidth.ToString + ", "
            'ext static pressure
            sql = sql + "ExtStaticPressure = " + process.ExtStaticPressure.ToString + ", "
            'fan
            sql = sql + "Fan = '" + process.Fan.ToString + "', "
            'model
            sql = sql + "Model = '" + process.Model.ToString + "', "
            'name
            sql = sql + "Name = '" + ConvertNull.ToString(process.name) + "', "
            'num fans
            sql = sql + "NumFans = " + process.NumFans.ToString + ", "
            'refrigerant
            sql = sql + "Refrigerant = '" + process.Refrigerant.ToString + "', "
            'series
            sql = sql + "Series = '" + process.Series.ToString + "', "
            'subcooling
            sql = sql + "SubCooling = " + System.Math.Abs(CInt(process.SubCooling)).ToString + ", "
            'subcooling %
            sql = sql + "SubCoolingPercentage = " + process.SubCoolingPercentage.ToString + ", "



            sql = sql + "TD = " + process.TD.ToString

            sql = sql + "CreatedBy = '" + process.CreatedBy.ToString + "', "
            sql = sql + "Division = '" + process.Division.ToString + "', "
            sql = sql + "Notes = '" + process.Notes.ToString + "', "
            sql = sql + "ProjectRevision = " + process.ProjectRevision.ToString + ", "
            sql = sql + "ProcessRevisionDescription = '" + process.ProcessRevisionDescription.ToString + "', "
            sql = sql + "Version = '" + process.Version + "'"

            sql = sql + " WHERE ProcessId = " + process.id.ToString


            command = connection.CreateCommand
            command.CommandText = sql
            command.Transaction = transaction
            Dim numRows As Integer = command.ExecuteNonQuery()

            '' updates options
            'EquipmentOptionsDA.Save(condenser.Options, connection, transaction)

            '' saves special options
            'SpecialOptionsDa.Save(condenser.SpecialOptions, connection, transaction)

            transaction.Commit()
         Catch ex As DataException
            'If transaction IsNot Nothing Then transaction.Rollback()
            Throw ex
         Finally
            'If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try
      End Sub

      Public Shared Sub Update(ByVal process As CondenserProcessItem)
         Dim connection As IDbConnection
         'Dim transaction As iDbTransaction
         Dim command As IDbCommand
         Dim connectionString, sql As String
         Dim topID As Integer = 0
         'Dim reader As iDataReader

         connection = Common.CreateConnection(Common.ProjectsDbPath)
         Try
            connection.Open()
            'transaction = connection.BeginTransaction()

            ' updates equipment table
            'EquipmentItemDA.Update(connection, transaction, condenser)

            ' updates fluidCooler table
            'sql = SqlFactory.GetUpdateCondenserSql(condenser)
            'UPDATE Reps SET Reps.RepNum = "fds", Reps.FirstName = "rt", Reps.LastName = "oui";

            'sql = "SELECT TOP 1 ID FROM CondenserProcesses"
            'Dim commandSel As New OleDbCommand(sql, connection, transaction)
            ''commandSel.ExecuteNonQuery()
            ''connection.Open()
            'reader = commandSel.ExecuteReader()
            'While reader.Read
            '    topID = CInt(reader("ID").ToString)
            'End While

            sql = "UPDATE CondenserProcesses SET "

            'id
            'autoincrement?
            'If topID > 0 Then
            '    topID = topID + 1
            'End If
            'sql = sql + " ID = " + topID.ToString + ", "
            'End If
            'processid
            'sql = sql + "ProcessId = '" + process.Id.ToString + "', "
            'altitude
            sql &= "Revision=" & process.Revision.ToString & ", "
            sql &= "RevisionDate='" & process.RevisionDate.ToString & "', "
            sql = sql + "Altitude = " + process.Altitude.ToString + ", "
            'ambient temp
            sql = sql + "AmbientTemp = " + process.AmbientTemp.ToString + ", "
            'catalograting
            sql = sql + "CatalogRating = " + System.Math.Abs(CInt(process.CatalogRating)).ToString + ", "
            'cfm
            sql = sql + "CFM = " + process.CFM.ToString + ", "
            'coil descr 
            sql = sql + "CoilDesc = '" + ConvertNull.ToString(process.CoilDesc) + "', "
            'coil length
            sql = sql + "CoilLength = " + process.CoilLength.ToString + ", "
            'coil width
            sql = sql + "CoilWidth = " + process.CoilWidth.ToString + ", "
            'ext static pressure
            sql = sql + "ExtStaticPressure = " + process.ExtStaticPressure.ToString + ", "
            'fan
            sql = sql + "Fan = '" + process.Fan + "', "
            'model
            sql = sql + "Model = '" + process.Model + "', "
            'name
            sql = sql + "Name = '" + process.name + "', "
            'num fans
            sql = sql + "NumFans = " + process.NumFans.ToString + ", "
            'refrigerant
            sql = sql + "Refrigerant = '" + process.Refrigerant + "', "
            'series
            sql = sql + "Series = '" + process.Series + "', "
            'subcooling
            sql = sql + "SubCooling = " + System.Math.Abs(CInt(process.SubCooling)).ToString + ", "
            'subcooling %
            sql = sql + "SubCoolingPercentage = " + process.SubCoolingPercentage.ToString + ", "
            'TD
            sql = sql + "TD = " + process.TD.ToString + ", "

            sql = sql + "CreatedBy = '" + process.CreatedBy + "', "
            sql = sql + "Division = '" + process.Division.ToString + "', "
            sql = sql + "Notes = '" + process.Notes + "', "
            sql = sql + "ProjectRevision = " + process.ProjectRevision.ToString + ", "
            sql = sql + "ProcessRevisionDescription = '" + process.ProcessRevisionDescription + "', "
            sql = sql + "Version = '" + process.Version + "'"


            sql = sql + " WHERE ProcessId = '" + process.id.ToString & "'"
            sql = sql + " AND Revision = " & process.Revision.ToString


            command = connection.CreateCommand
            command.CommandText = sql
            Dim numRows As Integer = command.ExecuteNonQuery()

            '' updates options
            'EquipmentOptionsDA.Save(condenser.Options, connection, transaction)

            '' saves special options
            'SpecialOptionsDa.Save(condenser.SpecialOptions, connection, transaction)

            'transaction.Commit()
         Catch ex As DataException
            'If transaction IsNot Nothing Then transaction.Rollback()
            Throw ex
         Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try
      End Sub


#End Region

   End Class

End Namespace
