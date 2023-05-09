Imports System.Data
Imports System.Collections
Imports Rae.RaeSolutions.Business.Entities

Namespace Rae.RaeSolutions.DataAccess
   Public Class FluidCoolerDataAccess

      Public Shared Function RetrieveFluidCoolerSeries() As DataTable
         Dim sql As String = "Select * from fluidcoolerseries"
         Dim conn As IDbConnection = Common.CreateConnection(Common.FluidCoolerDbPath) 'New OleDb.OleDbConnection(Common.GetConnectionString(Common.FluidCoolerDbPath))
         Dim cmd As IDbCommand = conn.CreateCommand 'New OleDb.OleDbCommand(Sql, conn)
         cmd.CommandText = sql
         Dim da As IDbDataAdapter = Common.CreateAdapter(cmd) 'New OleDb.OleDbDataAdapter(cmd)
         Dim ds As New DataSet
         da.Fill(ds)
         Return ds.Tables(0)
      End Function

      Public Shared Function RetrieveFluidCooler() As DataTable
         Dim sql As String = "Select * from [fluidcooler] "
         Dim conn As IDbConnection = Common.CreateConnection(Common.FluidCoolerDbPath) 'New OleDb.OleDbConnection(Common.GetConnectionString(Common.FluidCoolerDbPath))
         Dim cmd As IDbCommand = conn.CreateCommand 'New OleDb.OleDbCommand(Sql, conn)
         cmd.CommandText = sql
         Dim da As IDbDataAdapter = Common.CreateAdapter(cmd) 'New OleDb.OleDbDataAdapter(cmd)
         Dim ds As New DataSet
         da.Fill(ds)
         Return ds.Tables(0)
      End Function

      'Public Shared Function RetrieveFluidCooler(ByRef obj As Object, ByVal strProp As String) As DataTable
      '    Dim sql As String = "Select * from fluidcooler where strProp"
      '    Dim conn As New OleDb.OleDbConnection(Common.GetConnectionString(Common.FluidCoolerDbPath))
      '    Dim cmd As New OleDb.OleDbCommand(sql, conn)
      '    Dim da As New OleDb.OleDbDataAdapter(cmd)
      '    Dim dtb As New DataTable
      '    da.Fill(dtb)
      '    Return dtb
      'End Function


      Public Shared Function RetrieveFluidCoolerCoils() As DataTable
         Dim sql As String = "Select * from fluidcoolercoil"
         Dim conn As IDbConnection = Common.CreateConnection(Common.FluidCoolerDbPath) 'New OleDb.OleDbConnection(Common.GetConnectionString(Common.FluidCoolerDbPath))
         Dim cmd As IDbCommand = conn.CreateCommand 'New OleDb.OleDbCommand(Sql, conn)
         cmd.CommandText = sql
         Dim da As IDbDataAdapter = Common.CreateAdapter(cmd) 'New OleDb.OleDbDataAdapter(cmd)
         Dim ds As New DataSet
         da.Fill(ds)
         Return ds.Tables(0)
      End Function

      Public Shared Function RetrieveFluidCoolerFans() As DataTable
         Dim sql As String = "Select * from fluidcoolerfan"
         Dim conn As IDbConnection = Common.CreateConnection(Common.FluidCoolerDbPath) 'New OleDb.OleDbConnection(Common.GetConnectionString(Common.FluidCoolerDbPath))
         Dim cmd As IDbCommand = conn.CreateCommand 'New OleDb.OleDbCommand(Sql, conn)
         cmd.CommandText = sql
         Dim da As IDbDataAdapter = Common.CreateAdapter(cmd) 'New OleDb.OleDbDataAdapter(cmd)
         Dim ds As New DataSet
         da.Fill(ds)
         Return ds.Tables(0)
      End Function

      Public Shared Function RetrieveFluidCoolerCircuiting() As DataTable
         Dim sql As String = "Select * from fluidcoolercircuiting"
         Dim conn As IDbConnection = Common.CreateConnection(Common.FluidCoolerDbPath) 'New OleDb.OleDbConnection(Common.GetConnectionString(Common.FluidCoolerDbPath))
         Dim cmd As IDbCommand = conn.CreateCommand 'New OleDb.OleDbCommand(Sql, conn)
         cmd.CommandText = sql
         Dim da As IDbDataAdapter = Common.CreateAdapter(cmd) 'New OleDb.OleDbDataAdapter(cmd)
         Dim ds As New DataSet
         da.Fill(ds)
         Return ds.Tables(0)
      End Function
   End Class
End Namespace