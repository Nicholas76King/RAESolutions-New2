Imports System
Imports System.Data
Imports Rae.RaeSolutions.DataAccess
Imports Rae.RaeSolutions.DataAccess.Projects

Namespace Rae.RaeSolutions.Business.Entities

Public MustInherit Class RevisionBase
   Inherits ItemBase

   ''' <summary>gets the last revision made to the project or item specified</summary>
   ''' <param name="id">id can be projectid or any equipment item or process item id</param>
   Function GetLastRevisionNumber(id As String) As Single
      Dim con As IDbConnection
      Dim cmd As IDbCommand
      Dim r As Single

      con = Common.CreateConnection(Common.ProjectsDbPath)
      cmd = con.CreateCommand
      cmd.CommandText = "SELECT Revision FROM [" & ProcessItemDA.GetTableName(id) & "] " & _
                        "WHERE ProcessID = '" & id & "' " & _
                        "ORDER BY Revision DESC"
      Try
         con.Open()
         r = CSng(cmd.ExecuteScalar)
      Finally
         If con.State <> ConnectionState.Closed Then _
            con.Close()
      End Try

      Return r
   End Function

End Class

End Namespace