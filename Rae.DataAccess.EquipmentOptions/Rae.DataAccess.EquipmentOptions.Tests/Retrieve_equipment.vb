Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert

<TestClass()> _
Public Class Retrieve_equipment
   Inherits OptionTestBase

'<TestMethod()> _
'Sub price()
'	Dim price = OptionsDataAccess.RetrieveBaseListPrice(series, model)
'	IsTrue( price = 80085 )
'End Sub

<TestMethod()> _
Sub series_by_division_for_Century()
	Dim series = EquipmentDataAccess.RetrieveSeries(division:="CRI")
	IsTrue( series.Contains("DS") )
	IsFalse( series.Contains("20A0CS") )
End Sub

<TestMethod()> _
Sub series_by_division_for_Technical_Systems()
	Dim series = EquipmentDataAccess.RetrieveSeries(division:="TSI")
	IsTrue( series.Contains("20A0CS") )
	IsFalse( series.Contains("DS") )
End Sub

<TestMethod()> _
Sub series_by_division_and_equipment_type()
	Dim series = EquipmentDataAccess.retrieve_series(division:="CRI", equipment_type:="CondensingUnit", is_rep:=false)
	IsTrue( series.Contains("DS") And series.Contains("DD") )
	IsFalse( series.Contains("A") )
End Sub

<TestMethod()> _
Sub models_by_series()
	Dim models = EquipmentDataAccess.RetrieveModels(series:="DS")
	IsTrue( models.Contains("10H2") )
	IsFalse( models.Contains("10") )
End Sub

<TestMethod()> _
Sub types()
	Dim types = EquipmentDataAccess.RetrieveTypes("CRI")
	IsTrue( types.Contains("UnitCooler") )
	IsFalse( types.Contains("Chiller") )
End Sub

'<TestMethod()> _
'Sub option_by_pricing_id_when_priced_by_model()
'	Dim op = OptionsDataAccess.RetrieveOption(pricingId:=46589)
'	IsTrue( op.Code = codeByModel )
'	IsTrue( op.Category="Labels" )
'	IsTrue( op.Description="For testing option pricing by model" )
'	IsTrue( op.Per="unit" )
'	IsTrue( op.Price=45678 )
'	IsTrue( op.Quantity=1 )
'	IsTrue( op.Voltage=0 )
'End Sub

'<TestMethod()> _
'Sub option_by_pricing_id_when_priced_by_series()
'	Dim op = OptionsDataAccess.RetrieveOption(pricingId:=46588)
'	IsTrue( op.Code = codeBySeries )
'	IsTrue( op.Description = "For testing option pricing by series" )
'	IsTrue( op.Category="Labels")
'	IsTrue( op.Per="unit" )
'	IsTrue( op.Price=34567 )
'	IsTrue( op.Quantity=1 )
'	IsTrue( op.Voltage=0 )
'End Sub

'<TestMethod()> _
'Sub option_by_pricing_id_when_priced_by_number_of_fans()
'	Dim op = OptionsDataAccess.RetrieveOption(pricingId:=46590)
'	IsTrue( op.Code = codeByFan )
'	IsTrue( op.Description = "For testing option pricing by number of fans" )
'	IsTrue( op.Category="Labels" )
'	IsTrue( op.Per="unit" )
'	IsTrue( op.Price=56789 )
'	IsTrue( op.Quantity=1 )
'	IsTrue( op.Voltage=0 )
'End Sub

<ClassInitialize()> Shared Sub InitializeClass(context As TestContext)
   ConnectionString.InitializeTest(dbFilePathForTesting)
End Sub

End Class
