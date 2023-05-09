Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert

<TestClass()> _
Public Class When_retrieving_available_options
   Inherits OptionTestBase
   
'<TestMethod> _
'sub get_deduct_options
'   dim ops = OptionsDataAccess.RetrieveAvailableOptions(series, model:="dosent matter", voltage:=0, numFans:=0)
'   IsTrue( ops.Exists( Function(op) op.Code=codeBySeries ))
'end sub

'<TestMethod()> _
'Sub get_options_by_series()
'	Dim ops = OptionsDataAccess.RetrieveAvailableOptions(series, model, voltage:=0, numFans:=0)

'	IsTrue( ops.Exists( Function(x) x.Code=codeBySeries ))
'End Sub

'<TestMethod()> _
'Sub get_options_by_model()
'	Dim ops = OptionsDataAccess.RetrieveAvailableOptions(series, model, voltage:=0, numFans:=0)

'	IsTrue( ops.Exists( Function(x) x.Code=codeByModel ))
'End Sub

'<TestMethod()> _
'Sub get_options_by_low_number_of_fans()
'	Dim ops = OptionsDataAccess.RetrieveAvailableOptions(seriesForFan, modelForFan, voltage:=0, numFans:=3)

'	IsTrue( ops.Exists( Function(x) x.Code=codeByFan ))
'End Sub

'<TestMethod()> _
'Sub get_options_by_high_number_of_fans()
'	Dim ops = OptionsDataAccess.RetrieveAvailableOptions(seriesForFan, modelForFan, voltage:=0, numFans:=4)

'	IsTrue( ops.Exists( Function(x) x.Code=codeByFan ))
'End Sub

<TestMethod()> _
Sub filter_options_below_fan_range()
        Dim ops = OptionsDataAccess.RetrieveAvailableOptions(seriesForFan, modelForFan, voltage:=0, numFans:=2, fanMotorPhase:=0)
	
	IsFalse( ops.Exists( Function(x) x.Code=codeByFan ))
End Sub

<TestMethod()> _
Sub filter_options_above_fan_range()
        Dim ops = OptionsDataAccess.RetrieveAvailableOptions(series, model, voltage:=0, numFans:=5, fanMotorPhase:=0)
	
	IsFalse( ops.Exists( Function(x) x.Code=codeByFan ))
End Sub

'<TestMethod()> _
'Sub filter_voltages_for_230()
'	Dim ops = OptionsDataAccess.RetrieveAvailableOptions(series, model, voltage:=230, numFans:=0)

'	IsTrue( ops.Exists( Function(x) x.Code=code230))
'	IsFalse( ops.Exists( Function(x) x.Code=code460))
'End Sub

'<TestMethod()> _
'Sub filter_voltages_for_460()
'	Dim ops = OptionsDataAccess.RetrieveAvailableOptions(series, model, voltage:=460, numFans:=0)

'	IsTrue( ops.Exists( Function(x) x.Code=code460))
'	IsFalse( ops.Exists( Function(x) x.Code=code230))
'End Sub

<TestMethod()> _
Sub filter_standard_options()
        Dim ops = OptionsDataAccess.RetrieveAvailableOptions(series, model, voltage:=0, numFans:=0, fanMotorPhase:=0)
	
	IsFalse( ops.Exists( Function(x) x.Code=codeStandard))
End Sub

<TestMethod> _
Sub omit_options_marked_obsolete
        Dim ops = OptionsDataAccess.RetrieveAvailableOptions(series, model, voltage:=0, numFans:=0, fanMotorPhase:=0)
   IsFalse( ops.Exists( Function(op) op.Code=codeObsolete ))
End Sub

<ClassInitialize()> Shared Sub InitializeClass(context As TestContext)
   ConnectionString.InitializeTest(dbFilePathForTesting)
End Sub

End Class
