Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert

<TestClass()> _
Public Class When_retrieving_standard_options
   Inherits OptionTestBase

'<TestMethod()> _
'Sub get_by_series()
'	Dim ops = OptionsDataAccess.RetrieveStandardOptions(series, model, voltage:=0, numFans:=0)
'	IsTrue( ops.Exists( Function(x) x.Code=codeStandard AndAlso x.Quantity=1))
'End Sub

'<TestMethod()> _
'Sub get_by_model()
'	Dim ops = OptionsDataAccess.RetrieveStandardOptions(series, model, voltage:=0, numFans:=0)
'	IsTrue( ops.Exists( Function(x) x.Code=codeStandard AndAlso x.Quantity=2))
'End Sub

'<TestMethod()> _
'Sub get_by_number_of_fans()
'	Dim ops = OptionsDataAccess.RetrieveStandardOptions(series, model, voltage:=0, numFans:=2)
'	IsTrue( ops.Exists( Function(x) x.Code=codeStandard AndAlso x.Quantity=3))
'End Sub

'<TestMethod()> _
'Sub filter_by_voltage_230()
'	Dim ops = OptionsDataAccess.RetrieveStandardOptions(series, "230", voltage:=230, numFans:=0)
'	IsTrue( ops.Exists( Function(op) op.Code=code230))
'	IsFalse( ops.Exists( Function(op) op.Code=code460))
'End Sub

'<TestMethod()> _
'Sub filter_by_voltage_460()
'	Dim ops = OptionsDataAccess.RetrieveStandardOptions(series, "460", voltage:=460, numFans:=0)
'	IsTrue( ops.Exists( Function(op) op.Code=code460))
'	IsFalse( ops.Exists( Function(op) op.Code=code230))
'End Sub

'<TestMethod()> _
'Sub filters_available_options()
'	Dim ops = OptionsDataAccess.RetrieveStandardOptions(series, model, voltage:=0, numFans:=0)
'	IsFalse( ops.Exists( Function(x) x.Code=codeByModel))
'End Sub

'<TestMethod()> _
'Sub get_all_data()
'	Dim ops = OptionsDataAccess.RetrieveAvailableOptions(series, model, voltage:=230, numFans:=0)
'	Dim op = ops.Where( Function(x) x.Code=codeByModel )(0)
'	IsTrue(op.Code=codeByModel)
'	IsTrue(op.Description="For testing option pricing by model")
'	IsTrue(op.Category="Labels")
'	IsTrue(op.Price=45678)
'	IsTrue(op.Quantity=1)
'	IsTrue(op.Per="unit")
'	IsTrue(op.Voltage=0)
'End Sub

<ClassInitialize()> Shared Sub InitializeClass(context As TestContext)
   ConnectionString.InitializeTest(dbFilePathForTesting)
End Sub

End Class
