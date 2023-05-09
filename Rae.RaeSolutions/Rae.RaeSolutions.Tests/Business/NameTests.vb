Imports System
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Rae.RaeSolutions.Business.Entities


<TestClass()> _
Public Class NameTests

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

   Private Const LAST_NAME As String = "Joyce"
   Private Const MIDDLE_NAME As String = "Loran"
   Private Const FIRST_NAME As String = "Casey"


   <TestMethod()> _
   Public Sub ShouldSetFullName()
      Dim casey As New Name()

      casey.FullName = "Mr Casey Loran Joyce"
      Assert.IsTrue(casey.FirstName = FIRST_NAME AndAlso casey.MiddleName = MIDDLE_NAME _
         AndAlso casey.LastName = LAST_NAME AndAlso casey.Title = RaeSolutions.Business.CourtesyTitle.Mr)

      casey.FullName = "Casey Joyce"
      Assert.IsTrue(casey.FirstName = FIRST_NAME AndAlso casey.LastName = LAST_NAME _
         AndAlso casey.MiddleName = "" AndAlso casey.Title = RaeSolutions.Business.CourtesyTitle.NotSet)

      casey.FullName = "Mrs. Casey Joe Bob Loran Joyce"
      Assert.IsTrue(casey.FirstName = "Casey Joe Bob" AndAlso casey.LastName = LAST_NAME _
         AndAlso casey.MiddleName = MIDDLE_NAME AndAlso casey.Title = RaeSolutions.Business.CourtesyTitle.Mrs)

      casey.FullName = FIRST_NAME
      Assert.IsTrue(casey.FirstName = FIRST_NAME AndAlso casey.MiddleName = "" AndAlso casey.LastName = "" _
         AndAlso casey.Title = RaeSolutions.Business.CourtesyTitle.NotSet)

      casey.FullName = "Miss Joyce"
      Assert.IsTrue(casey.FirstName = "" AndAlso casey.MiddleName = "" AndAlso casey.LastName = LAST_NAME _
         AndAlso casey.Title = RaeSolutions.Business.CourtesyTitle.Ms)
   End Sub

   <TestMethod()> _
   Public Sub ToStringShouldBeLastThenFirstTest()
      Dim casey As New Name()
      casey.FirstName = FIRST_NAME
      casey.LastName = LAST_NAME
      Assert.IsTrue(casey.ToString() = "Joyce, Casey")
   End Sub



End Class
