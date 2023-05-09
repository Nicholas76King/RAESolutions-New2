Namespace Rae.DataAccess.EquipmentOptions.Tables

Public Class OptionPricingTable
   Public Const TableName As String = "OptionPricing"
   Public Const Id As String = "Id"
   Public Const OptionId As String = "OptionId"
   Public Const Price As String = "Price"
   Public Const Quantity As String = "Quantity"
   Public Const PerId As String = "PerId"
   Public Const Obsolete As String = "Obsolete"
End Class

Public Class EquipmentPricingTable
   Public Const TableName As String = "EquipmentPricing"
   Public Const Id As String = "Id"
   Public Const Price As String = "Price"
   Public Const SeriesId As String = "SeriesId"
   Public Const Model As String = "Model"
End Class

Public Class PricingBySeriesTable
   Public Const TableName As String = "PricingBySeries"
   Public Const Id As String = "Id"
   Public Const PricingId As String = "PricingId"
   Public Const SeriesId As String = "SeriesId"
End Class

Public Class PricingByModelTable
   Public Const TableName As String = "PricingByModel"
   Public Const Id As String = "Id"
   Public Const PricingId As String = "PricingId"
   Public Const SeriesId As String = "SeriesId"
   Public Const Model As String = "Model"
End Class

Public Class PricingByNumFansTable
   Public Const TableName As String = "PricingByNumFans"
   Public Const Id As String = "Id"
   Public Const PricingId As String = "PricingId"
   Public Const SeriesId As String = "SeriesId"
   Public Const Low As String = "Low"
   Public Const High As String = "High"
End Class

End Namespace