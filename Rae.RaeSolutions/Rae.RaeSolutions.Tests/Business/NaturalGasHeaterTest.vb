Imports System
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports RAE.RAESolutions.Business.Entities

<TestClass()> Public Class NaturalGasHeaterTest

#Region "Additional test attributes"
    '
    ' You can use the following additional attributes as you write your tests:
    '
    ' Use ClassInitialize to run code before running the first test in the class
    ' <ClassInitialize()> Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    ' End Sub
    '
    ' Use ClassCleanup to run code after all tests in a class have run
    ' <ClassCleanup()> Public Shared Sub MyClassCleanup()
    ' End Sub
    '
    ' Use TestInitialize to run code before running each test
    ' <TestInitialize()> Public Sub MyTestInitialize()
    ' End Sub
    '
    ' Use TestCleanup to run code after each test has run
    ' <TestCleanup()> Public Sub MyTestCleanup()
    ' End Sub
    '
#End Region

   <TestMethod()> _
   Public Sub SmallerUnitsShouldHaveLowerMaxPower()
      Dim heater As New NaturalGasHeater("TPAH-22")
      Assert.IsTrue(heater.MaxPower = 400)
   End Sub

   <TestMethod()> _
   Public Sub LargerUnitsShouldHaveHigherMaxPower()
      Dim heater As New NaturalGasHeater("TPAH-24")
      Assert.IsTrue(heater.MaxPower = 1600)
   End Sub


   <TestMethod()> _
   Public Sub LowerPowerHeatersShouldNotRequireBoard()
      Dim heater As New NaturalGasHeater("TPAH-22")
      heater.Power = 200
      Assert.IsTrue(Not heater.IsBoardRequired)
   End Sub


   <TestMethod()> _
   Public Sub HigherPowerHeatersShouldRequireBoard()
      Dim heater As New NaturalGasHeater("TPAH-22")
      heater.Power = 500
      Assert.IsTrue(heater.IsBoardRequired)
   End Sub


   <TestMethod()> _
   Public Sub ModulatingHeatersShouldRequireBoard()
      Dim heater As New NaturalGasHeater("TPAH-22")
      heater.Type = NaturalGasHeater.HeaterType.Modulating
      Assert.IsTrue(heater.IsBoardRequired)
   End Sub

End Class
