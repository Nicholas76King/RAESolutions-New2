Imports PriceSheetDataSet

Namespace Rae.RaeSolutions.Business.Entities.PriceSheets

''' <summary>Associates a series with its options.</summary>
Class Series_Options_Assoc

   Sub New(series As String, options As PriceSheetDataTable, commonOptions As PriceSheetDataTable)
      _series = series
      _options = options
      _commonOptions = commonOptions
   End Sub

   Property Series As String
      Get
         Return _series
      End Get
      Set(value As String)
         _series = value
      End Set
   End Property

   Property Options As PriceSheetDataTable
      Get
         Return _options
      End Get
      Set(value As PriceSheetDataTable)
         _options = value
      End Set
   End Property
   
   Property CommonOptions As PriceSheetDataTable
   	Get
   		Return _commonOptions
   	End Get
   	Set(value As PriceSheetDataTable)
   		_commonOptions = value
   	End Set
   End Property
   
   Private _series As String
   Private _options, _commonOptions As PriceSheetDataTable
   
End Class

End Namespace