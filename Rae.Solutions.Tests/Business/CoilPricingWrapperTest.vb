Imports Rae.RaeSolutions.Business.Entities
Imports System
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class CoilPricingWrapperTest

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
   Public Sub ShouldReturnPrice()
      Dim coil As New CoilPricingWrapper(CoilPricingWrapper.CoilType.Water, _
      True, 12, 12, 1, 0.02, 12, 0.006, CoilPricingWrapper.FinMaterial.Aluminum, 1)

      Assert.IsTrue(coil.Price > 0)
   End Sub

End Class
