Imports Rae.RaeSolutions.DataAccess
Imports System.Collections.Generic
Imports System.Data
Imports System.Text
Imports ST = Rae.DataAccess.EquipmentOptions.Tables.SeriesTable

Namespace Rae.DataAccess.EquipmentOptions

Public Class SeriesDataAccess

   Shared Function RetrieveUnitCoolerSeries() As List(Of String)
      
      Dim con = Common.CreateConnection(ConnectionString.DataSource)
      Dim com = con.CreateCommand
      Dim sql = New StringBuilder().AppendFormat("SELECT {0} FROM {1} WHERE {2}='{3}'", _
         ST.Series, ST.TableName, ST.EquipmentType, "UnitCooler").ToString
      com.CommandText = sql
      Dim rdr As IDataReader
      Dim seriesList = New List(Of String)
      
      Try
         con.Open
         rdr = com.ExecuteReader
         While rdr.Read
            Dim series As String = rdr(ST.Series).ToString
            seriesList.Add( series )
         End While
      Finally
         If rdr IsNot Nothing Then _
            rdr.Close
         If con.State <> ConnectionState.Closed Then _
            con.Close
      End Try
      
      Return seriesList
   End Function

End Class

End Namespace