Imports System
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Rae.RaeSolutions.Business.Entities

Namespace Business

   <TestClass()> Public Class VoltageRatingTest

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
      Public Sub TestConstructorParse()
         Dim a As New VoltageRating("220/3/60")
         Assert.IsTrue(a.Voltage.value = 220)
         Assert.IsTrue(a.Phase.value = 3)
         Assert.IsTrue(a.Hertz.value = 60)
      End Sub

      <TestMethod()> _
      Public Sub TestConstructor3Params()
         Dim a As New VoltageRating(460, 1, 180)
         Assert.IsTrue(a.Voltage.value = 460)
         Assert.IsTrue(a.Phase.value = 1)
         Assert.IsTrue(a.Hertz.value = 180)
      End Sub

      <TestMethod()> _
      Public Sub TestParseVoltagePhaseHertz()
         Dim a As New VoltageRating()
         a.Parse("220/3/60")
         Assert.IsTrue(a.Voltage.value = 220)
         Assert.IsTrue(a.Phase.value = 3)
         Assert.IsTrue(a.Hertz.value = 60)
      End Sub

      <TestMethod()> _
      Public Sub TestParseVoltage()
         Dim a As New VoltageRating(460, 1, 180)
         Assert.IsTrue(a.Voltage.value = 460)
         Assert.IsTrue(a.Phase.value = 1)
         Assert.IsTrue(a.Hertz.value = 180)
         a.Parse("220")
         Assert.IsTrue(a.Voltage.value = 220)
         Assert.IsFalse(a.Phase.has_value)
         Assert.IsFalse(a.Hertz.has_value)
      End Sub

      <TestMethod()> _
      Public Sub TestParseFormatException1()
         Dim a As New VoltageRating("220/3")
      End Sub

      <TestMethod(), ExpectedException(GetType(System.FormatException))> _
      Public Sub TestParseFormatException2()
         Dim a As New VoltageRating("/3/60")
      End Sub

      <TestMethod(), ExpectedException(GetType(FormatException))> _
      Public Sub TestParseFormatException3()
         Dim a As New VoltageRating("220/3/")
      End Sub

      <TestMethod(), ExpectedException(GetType(FormatException))> _
      Public Sub TestParseFormatException4()
         Dim a As New VoltageRating("220//60")
      End Sub

      <TestMethod()> _
      Public Sub TestParseEmpty()
         Dim a As New VoltageRating(" ")
         Assert.IsFalse(a.Voltage.has_value)
         Assert.IsFalse(a.Phase.has_value)
         Assert.IsFalse(a.Hertz.has_value)
      End Sub

      <TestMethod()> _
      Public Sub TestParseNull()
         Dim a As New VoltageRating(Nothing)
         Assert.IsFalse(a.Voltage.has_value)
         Assert.IsFalse(a.Phase.has_value)
         Assert.IsFalse(a.Hertz.has_value)
      End Sub

      <TestMethod(), ExpectedException(GetType(FormatException))> _
      Public Sub TestFailedCInt()
         Dim a As New VoltageRating("2a")
      End Sub

      <TestMethod()> _
      Public Sub TestToStringVoltagePhaseHertz()
         Dim a As New VoltageRating(230, 3, 60)
         Assert.IsTrue(a.ToString = "230/3/60")
      End Sub

      <TestMethod()> _
      Public Sub TestToStringVoltage()
         Dim a As New VoltageRating
         a.Voltage.value = 460
         Assert.IsTrue(a.ToString = "460")
      End Sub

      ''' <summary>
      ''' Null param defaults to 0
      ''' </summary>
      <TestMethod()> _
      Public Sub TestConstructorNullParam()
         Dim a As New VoltageRating(Nothing, 3, 60)
         Assert.IsTrue(a.ToString = "0/3/60")
      End Sub

      <TestMethod()> _
      Public Sub TestToStringOther()
         Dim a As New VoltageRating(230, 3, 60)
         a.Voltage.set_to_null()
         Assert.IsTrue(a.ToString = "")
      End Sub

   End Class

End Namespace