Option Strict Off

Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.Business.Repositories
Imports Rae.RaeSolutions.DataAccess.Common
Imports System.Collections.Generic
Imports System.Data
Imports System.Text

Namespace Rae.Data.Access

Public Class PumpRepo
   Implements IPumpRepo
   
   Function GetPump( _
      manufacturer As String, _
      flow As Double, _
      head As Double, _
      system As PumpSystem) _
   As PumpData _
   Implements IPumpRepo.GetPump
      Return retrievePump(manufacturer, flow, head, system)
   End Function

   Private Function retrievePump( _
      manufacturer As String, _
      gpm As Double, _
      head As Double, _
      system As PumpSystem) _
   As PumpData

      Dim con = CreateConnection(PumpPackagesDbPath)
      Dim com = con.CreateCommand
      Dim sql = "SELECT * FROM {0} WHERE {1}='{2}' AND {3}<{4} AND {5}>={4} AND {6}={7} AND {8}='{9}'"
      Dim qry = New StringBuilder().AppendFormat(sql, _
         "Pumps", "Manufacturer", manufacturer, "LowGPM", gpm, "HighGPM", _
         "Head", head, "System", system.ToString).ToString
      com.CommandText = qry
      Dim rdr As IDataReader

      Dim pump As PumpData

      Try
         con.Open()
         rdr = com.ExecuteReader
         While rdr.Read
            pump.Model = rdr("Model")
            pump.HP = rdr("HP")
            pump.RPM = rdr("RPM")
            pump.Efficiency = rdr("Efficiency")
            pump.BaseListPrice = rdr("Price")
            pump.PipeSize = rdr("PipeSize")
            pump.ConnectionSize = rdr("ConnectionSize")
         End While
      Finally
         If rdr IsNot Nothing Then _
            rdr.Close()
         If con.State <> ConnectionState.Closed Then _
            con.Close()
      End Try

      Return pump
   End Function

End Class

End Namespace