Imports System
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Rae.RaeSolutions.DataAccess.Projects

<TestClass()> _
Public Class ProjectContactsDataAccessTests

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

   Friend Const PROJECT_ID As String = "CaseyJ+LS3H4H6654+20070626161210"
   Friend Const CONTACT_ID As Integer = 79


   <TestMethod()> _
   Public Sub TestProjectContactExists()
      ProjectContactsDataAccess.Exists(PROJECT_ID, CONTACT_ID)
   End Sub


   <TestMethod()> _
   Public Sub TestCreateProjectContact()
      ProjectContactsDataAccess.Delete(PROJECT_ID, CONTACT_ID)
      ProjectContactsDataAccess.Create(PROJECT_ID, CONTACT_ID)
      ProjectContactsDataAccess.Exists(PROJECT_ID, CONTACT_ID)
   End Sub

End Class
