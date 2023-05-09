Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections
Imports Rae.RaeSolutions.Business.Entities

Namespace Rae.RaeSolutions.DataAccess

   Public Class WaterCooledDA

      Public Shared Function RetrieveCondenser(ByVal model As String) As DataRow
         Dim dr As DataRow
         Dim ds As New DataSet
         Dim conn As IDbConnection = Common.CreateConnection(Common.WCCondenserDbPath) 'New SqlConnection(Common.ConnectionString)
         Dim sql As String = "select c.model,c.b0,c.b1,c.b2,c.b3,c.b4,c.b5,c.b6,c.b7,c.b8,c.b9,t.gp from [" & Common.CommonTableName(Common.WCCondenserDbPath, "Table1") & "] t, [" & Common.CommonTableName(Common.WCCondenserDbPath, "Condensers") & "] c where t.model = '" & model & "' and c.model = '" & model & "'"
         Dim cmd As IDbCommand = conn.CreateCommand 'New SqlCommand("select c.model,c.b0,c.b1,c.b2,c.b3,c.b4,t.gp from [" & Common.CommonTableName(Common.WCCondenserDbPath, "Table1") & "] t, [" & Common.CommonTableName(Common.WCCondenserDbPath, "Condensers") & "] c where t.model = '" & model & "' and c.model = '" & model & "'", conn)
         cmd.CommandText = sql
         Dim da As IDbDataAdapter = Common.CreateAdapter(cmd)
         da.Fill(ds)
         If ds.Tables(0).Rows.Count = 0 Then
            dr = ds.Tables(0).NewRow
            ds.Tables(0).Rows.Add(dr)
         End If

         Return ds.Tables(0).Rows(0)
      End Function

      Public Shared Function RetrieveCondensers() As DataTable
         Dim ds As New DataSet
         Dim conn As IDbConnection = Common.CreateConnection(Common.WCCondenserDbPath)
         Dim sql As String = "select c.model,c.b0,c.b1,c.b2,c.b3,c.b4,c.b5,c.b6,c.b7,c.b8,c.b9,t.gp from [" & Common.CommonTableName(Common.WCCondenserDbPath, "Table1") & "] t, [" & Common.CommonTableName(Common.WCCondenserDbPath, "Condensers") & "] c where t.model = c.model"
         Dim cmd As IDbCommand = conn.CreateCommand
         cmd.CommandText = sql
         Dim da As IDbDataAdapter = Common.CreateAdapter(cmd)
         da.Fill(ds)
         Return ds.Tables(0)
      End Function

      Public Shared Function RetrieveCondenserByChiller(ByVal chiller As String, Optional ByVal coilNum As Integer = 1) As DataRow
         Dim dr As DataRow
         Dim ds As New DataSet
         Dim conn As IDbConnection = Common.CreateConnection(Common.WCCondenserDbPath)
         Dim sql As String = "select c.model,c.b0,c.b1,c.b2,c.b3,c.b4,c.b5,c.b6,c.b7,c.b8,c.b9,t.gp from [" & Common.CommonTableName(Common.WCCondenserDbPath, "Table1") & "] t inner join [" & Common.CommonTableName(Common.WCCondenserDbPath, "Condensers") & "] c on c.model = t.model where t.model = (SELECT [Coil_" & coilNum.ToString() & "] FROM [WCC_Master] where "
         If chiller.IndexOf("34") = 0 Then
            sql += "[34W0Model]"
         ElseIf chiller.IndexOf("24") = 0 Then
            sql += "[24W0Model]"
         End If
         sql += " = @chiller)"
         Dim cmd As IDbCommand = conn.CreateCommand
         cmd.CommandText = sql
         Dim param As IDbDataParameter = cmd.CreateParameter
         param.ParameterName = "@chiller"
         param.Value = chiller
         cmd.Parameters.Add(param)
         Dim da As IDbDataAdapter = Common.CreateAdapter(cmd)
         da.Fill(ds)
         If ds.Tables(0).Rows.Count = 0 Then
            dr = ds.Tables(0).NewRow
            ds.Tables(0).Rows.Add(dr)
         End If

         Return ds.Tables(0).Rows(0)
      End Function
   End Class
End Namespace