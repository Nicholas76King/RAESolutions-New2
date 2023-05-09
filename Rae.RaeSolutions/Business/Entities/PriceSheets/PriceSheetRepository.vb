Imports PriceSheetDataSet
Imports System.Collections.Generic
Imports Rae.DataAccess.EquipmentOptions

Namespace Rae.RaeSolutions.Business.Entities.PriceSheets

Class PriceSheetRepository
   Implements IPriceSheetRepository

   Function GetOptionsBySeries(series As String) As PriceSheetDataTable _
   Implements IPriceSheetRepository.GetOptionsBySeries
      Return PriceSheetDataAccess.RetrieveSeriesOptionsWithoutCommonOptions(series)
   End Function
   
   Function GetOptionsBy(series As String, model As String) As PriceSheetDataTable _
   Implements IPriceSheetRepository.GetOptionsByModel
      Return PriceSheetDataAccess.RetrieveModelOptionsWithoutCommonOptions(series, model)
   End Function

   Function GetSeriesIn(division As String) As List(Of String) _
   Implements IPriceSheetRepository.GetSeriesIn
      Return EquipmentDataAccess.RetrieveSeries(division)
   End Function

   Function GetCommonOptions(series As String) As PriceSheetDataTable _
   Implements IPriceSheetRepository.GetCommonOptions
      Return PriceSheetDataAccess.RetrieveCommonOptions(series)
   End Function
   
End Class

End Namespace