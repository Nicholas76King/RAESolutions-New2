Namespace Rae.RaeSolutions.Business.Entities.PriceSheets

Public Interface IPriceViewer
   ReadOnly Property Report() As String
   ReadOnly Property App() As String
   ReadOnly Property User() As String
   ReadOnly Property Version() As String
   ReadOnly Property By() As FilterBy
   ReadOnly Property Criteria() As String

   Sub Prepare()
   Sub View()
End Interface

End Namespace