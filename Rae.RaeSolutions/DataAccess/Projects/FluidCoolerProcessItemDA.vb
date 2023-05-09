Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic
Imports Rae.RaeSolutions.Business
Imports Rae.RaeSolutions.Business.Entities

Namespace Rae.RaeSolutions.DataAccess.Projects
   Public Class FluidCoolerProcessItemDA

      'Public Shared Sub Save(ByVal fcpi As FluidCoolerProcessItem)
      '   If processitemda.RevisionExists(fcpi.Id.Id, fcpi.Revision.ToString, "FluidCoolerProcesses") Then
      '      Update(fcpi)
      '   Else
      '      Create(fcpi)
      '   End If
      'End Sub

      Public Shared Function Populate(ByVal ItemID As String, Optional ByVal Revision As Single = -1) As DataTable
         Dim ds As New DataSet
         Dim conn As IDbConnection = Common.CreateConnection(Common.ProjectsDbPath)
         Dim cmd As IDbCommand = conn.CreateCommand
         Dim sql As String = "Select * from FluidCoolerProcesses where ProcessID = '" & ItemID & "'"
         If Revision > -1 Then
            sql += " and Revision = " & Revision
         End If
         cmd.CommandText = sql
         Dim da As IDbDataAdapter = Common.CreateAdapter(cmd)
         da.Fill(ds)
         Return ds.Tables(0)
      End Function

      Public Shared Function Populate(ByVal ItemID As String, ByVal latestRev As Boolean) As DataTable
         Dim ds As New DataSet
         Dim conn As IDbConnection = Common.CreateConnection(Common.ProjectsDbPath)
         Dim cmd As IDbCommand = conn.CreateCommand
         Dim sql As String = "Select TOP 1 * from FluidCoolerProcesses where ProcessID = '" & ItemID & "' order by [Revision] DESC"
         cmd.CommandText = sql
         Dim da As IDbDataAdapter = Common.CreateAdapter(cmd)
         da.Fill(ds)
         Return ds.Tables(0)
      End Function

      Public Shared Sub Update(ByVal fcpi As FluidCoolerProcessItem)
         Dim sql As String = "Update FluidCoolerProcesses set "
         sql += "Name = '" & fcpi.name & "',Altitude = " & fcpi.Altitude.ToString & ",Capacity = " & fcpi.Capacity.ToString & ", AmbientTemp = " & fcpi.AmbientTemp.ToString & ", EnteringFluidTemp = " & fcpi.EnteringFluidTemp.ToString & ", LeavingFluidTemp = " & fcpi.LeavingFluidTemp.ToString & ", "
         sql += "GlycolPercent = " & fcpi.GlycolPercent.ToString & ", Fluid = '" & fcpi.Fluid & "', Flow = " & fcpi.Flow.ToString & ", FluidCoolerXML = '" & Utility.Serialize(fcpi.FluidCooler) & "' "
         sql += "where ProcessID = '" & fcpi.id.Id & "' and Revision = " & fcpi.Revision.ToString
         Dim connection As IDbConnection
         Dim command As IDbCommand
         Dim numRowsAffected As Integer

         connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)

         command = connection.CreateCommand 'New OleDbCommand(sql, connection)
         command.CommandText = sql

         Try
            connection.Open()
            numRowsAffected = command.ExecuteNonQuery()
         Catch ex As DataException
            Throw
         Finally
            If Not connection.State.Equals(System.Data.ConnectionState.Closed) Then connection.Close()
         End Try
      End Sub

      Public Shared Function Create(ByVal fcpi As FluidCoolerProcessItem) As Integer

         Dim connectionString As String
         Dim transaction As IDbTransaction
         Dim connection As IDbConnection
         Dim numRowsAffected As Integer

         Dim found As Boolean
         found = ProcessItemDA.Exists(fcpi.id.ToString)

         connectionString = Common.GetConnectionString(Common.ProjectsDbPath)
         connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)


         Try
            connection.Open()

            ' begins transaction (everything can be rolled back from the beginning of the transaction until it is committed)
            transaction = connection.BeginTransaction()

            If found = False Then
               ' inserts only general process data into Processes Table
               ProcessItemDA.Create(connection, transaction, fcpi, "FluidCoolerProcesses")
            End If

            ' inserts values into CondenserProcessesTable
            Dim cmd As IDbCommand = connection.CreateCommand
            cmd.Transaction = transaction
            Dim sql As String = "Insert into FluidCoolerProcesses (ProcessID, Revision, RevisionDate, ProjectRevision, ProcessRevisionDescription, CreatedBy, Name, Altitude, Capacity, AmbientTemp, EnteringFluidTemp, LeavingFluidTemp, GlycolPercent, Fluid, Flow, FluidCoolerXML) values "
            sql += "('" & fcpi.id.Id & "'," & fcpi.Revision.ToString & ",'" & fcpi.RevisionDate.ToShortDateString & " " & fcpi.RevisionDate.ToShortTimeString & "'," & fcpi.ProjectRevision.ToString & ",'" & fcpi.ProcessRevisionDescription & "','" & fcpi.CreatedBy & "','" & fcpi.name & "'," & fcpi.Altitude.ToString & "," & fcpi.Capacity.ToString & "," & fcpi.AmbientTemp.ToString & "," & fcpi.EnteringFluidTemp.ToString & "," & fcpi.LeavingFluidTemp.ToString & "," & fcpi.GlycolPercent.ToString & ",'" & fcpi.Fluid & "'," & fcpi.Flow.ToString & ",'" & Utility.Serialize(fcpi.FluidCooler) & "')"

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            '    commits transaction
            transaction.Commit()
         Catch ex As Exception
            ' rolls back transaction
            If Not transaction Is Nothing Then transaction.Rollback()
            Throw New ApplicationException("Attempt to create Fluid cooler process item failed. Transaction was rolled back.", ex)
         Finally
            If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try

         Return numRowsAffected
      End Function
   End Class
End Namespace