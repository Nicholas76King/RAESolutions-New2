Imports PriceSheetDataSet
Imports System.Collections.Generic

Namespace Rae.RaeSolutions.Business.Entities.PriceSheets

Interface IPriceSheetRepository
   Function GetOptionsBySeries(series As String) As PriceSheetDataTable
   Function GetSeriesIn(division As String) As List(Of String)
   Function GetOptionsByModel(series As String, model As String) As PriceSheetDataTable
   Function GetCommonOptions(series As String) As PriceSheetDataTable
End Interface

End Namespace