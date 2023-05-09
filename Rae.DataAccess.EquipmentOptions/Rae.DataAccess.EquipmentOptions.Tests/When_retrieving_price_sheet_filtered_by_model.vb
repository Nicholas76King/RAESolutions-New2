Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert

<TestClass()> _
Public Class When_retrieving_price_sheet_filtered_by_model
   Inherits OptionTestBase

'<TestMethod()> _
'Sub get_options_by_model()
'	Dim ops = PriceSheetDataAccess.RetrieveModelOptions(series, model)
'	IsTrue( ops.Exists( Function(x) x.Code = codeByModel ))
'End Sub

'<TestMethod()> _
'Sub only_get_base_list_when_no_other_options_are_available()
'	Dim ops = PriceSheetDataAccess.RetrieveModelOptions("NIBR", "420-229")
'	IsTrue( ops.Count = 1 ) ' the one option is really the base list price
'End Sub

'<TestMethod()> _
'Sub get_options_by_series()
'	Dim ops = PriceSheetDataAccess.RetrieveModelOptions(series, model)
'	IsTrue( ops.Exists( Function(x) x.Code = codeBySeries ))
'End Sub

'<TestMethod()> _
'Sub get_options_by_number_of_fans()
'	Dim ops = PriceSheetDataAccess.RetrieveModelOptions(seriesForFan, modelForFan)
'	IsTrue( ops.Exists( Function(x) x.Code = codeByFan ))
'End Sub

'<TestMethod()> _
'Sub get_dependent_common_options()
'	Dim ops = PriceSheetDataAccess.RetrieveModelOptions(series, model)
'	IsTrue( ops.Exists( Function(x) x.Code = "DEPE" _ 
'	                        AndAlso Not x.IsDependentPriceNull _
'	                        AndAlso x.DependentPrice = 123 _
'	                        AndAlso x.ParentCode = "MR01" _
'	                        AndAlso x.Price = 999997))
'	IsTrue( ops.Exists( Function(x) x.Code = "DEPE" _
'	                        AndAlso Not x.IsDependentPriceNull _
'	                        AndAlso x.DependentPrice = 234 _
'	                        AndAlso x.ParentCode = "MR02" _
'	                        AndAlso x.Price = 999997))
'End Sub

<ClassInitialize()> Shared Sub InitializeClass(context As TestContext)
   ConnectionString.InitializeTest(dbFilePathForTesting)
End Sub

End Class


Module PriceSheetDataTableExt
   <Runtime.CompilerServices.Extension()> _
   Function Exists(table     As PriceSheetDataSet.PriceSheetDataTable, _
                   predicate As Predicate(Of PriceSheetDataSet.PriceSheetRow)) As Boolean
      For Each row As PriceSheetDataSet.PriceSheetRow In table.Rows
         If predicate.Invoke(row) Then _
            Return True
      Next
      Return False
   End Function
End Module