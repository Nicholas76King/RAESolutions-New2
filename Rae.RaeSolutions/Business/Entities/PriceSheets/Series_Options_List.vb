Imports PriceSheetDataSet
Imports System.Collections.Generic

Namespace Rae.RaeSolutions.Business.Entities.PriceSheets

Class Series_Options_List
   Inherits List(Of Series_Options_Assoc)

   Overloads Sub Add(series As String, options As PriceSheetDataTable, commonOptions As PriceSheetDataTable)
      Add(New Series_Options_Assoc(series, options, commonOptions))
   End Sub

   Function OptionsFor(series As String) As Series_Options_Assoc
      For Each assoc In Me
         If assoc.Series = series Then
            Return assoc
         End If
      Next
      Throw New System.ApplicationException("There are no options for the series")
   End Function

End Class

End Namespace