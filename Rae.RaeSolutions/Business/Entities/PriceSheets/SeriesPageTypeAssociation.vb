Namespace Rae.RaeSolutions.Business.Entities.PriceSheets

''' <summary>Associates series and page type.</summary>
Class Series_PageType_Assoc

   Sub New(series As String, pageType As PageType)
      _series = series
      _pageType = pageType
   End Sub
   
   Property Series As String
      Get
         Return _series
      End Get
      Set(ByVal value As String)
         _series = value
      End Set
   End Property
   
   Property PageType As PageType
      Get
         Return _pageType
      End Get
      Set(value As PageType)
         _pageType = value
      End Set
   End Property
   
   
   Private _series As String
   Private _pageType As PageType

End Class

End Namespace