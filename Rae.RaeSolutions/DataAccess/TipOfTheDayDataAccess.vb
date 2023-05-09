Imports System.Data
Imports System.Collections
Imports Rae.RaeSolutions.Business.Entities

Namespace Rae.RaeSolutions.DataAccess
   Public Class TipOfTheDayDataAccess

      Public Shared Function RetrieveTipOfTheDay() As DataTable
         Dim sql As String = "Select * from tips order by dateshown, tipid"
         Dim conn As IDbConnection = Common.CreateConnection(Common.TipOfTheDayDbPath)
         Dim cmd As IDbCommand = conn.CreateCommand
         cmd.CommandText = sql
         Dim da As IDbDataAdapter = Common.CreateAdapter(cmd)
         Dim ds As New DataSet
         da.Fill(ds)
         Return ds.Tables(0)
      End Function

      Public Shared Sub UpdateDateShown(ByVal id As Integer)
         Dim sql As String = "Update tips set DateShown = '" & Now & "' where tipid = " & id.ToString()
         Dim conn As IDbConnection = Common.CreateConnection(Common.TipOfTheDayDbPath)
         Dim cmd As IDbCommand = conn.CreateCommand
         cmd.CommandText = sql
         conn.Open()
         cmd.ExecuteNonQuery()
         If Not conn.State = ConnectionState.Closed Then
            conn.Close()
         End If
      End Sub
   End Class
End Namespace