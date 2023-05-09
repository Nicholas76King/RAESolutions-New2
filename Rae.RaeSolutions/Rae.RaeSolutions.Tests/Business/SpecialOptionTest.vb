Imports System
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports RAE.RAESolutions.Business.Entities

<TestClass()> Public Class SpecialOptionTest

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

   Private Function GetOption() As SpecialOption
      Dim op As New SpecialOption
      op.AuthorizedBy = "CaseyJ"
      op.AuthorizedFor = "Rep 1"
      op.Code = "SP06"
      op.Description = "Option description 1"
      op.Price.Value = 789
      op.Quantity.Value = 1
      op.EquipmentId = New item_id("Test", "pass")
      Return op
   End Function


   <TestMethod()> _
   Public Sub TestClone()
      Dim op As SpecialOption = GetOption()
      Dim op2 As SpecialOption = op.Clone()
      Assert.IsTrue(op.Equals(op2))
   End Sub

   <TestMethod()> _
   Public Sub TestCreate()
      Dim op As SpecialOption = GetOption()

      op.Save()

      Dim opSaved As SpecialOption = op.Clone()

      Dim op2 As New SpecialOption(op.Id, op.Revision)
      op.Load()

      Assert.IsTrue(op.Equals(opSaved))
   End Sub

End Class
