Imports System
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports RAE.RAESolutions.Business.Entities

Namespace Business

   <TestClass()> _
   Public Class ItemIdTest

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

      ''' <summary>
      ''' Check difference between pm and am
      ''' </summary>
      <TestMethod()> _
      Public Sub TestDateGenerated()
         Dim a As New item_id("CASEYJ", "pass")
         Dim id As String = a.ToString()

         Dim b As New item_id(id)

         Assert.IsTrue(a.ToString = b.ToString)
      End Sub

   End Class

End Namespace