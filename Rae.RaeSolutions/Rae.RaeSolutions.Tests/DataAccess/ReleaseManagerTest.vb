Imports System
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class ReleaseManagerTest

#Region "Additional test attributes"
    '
    ' You can use the following additional attributes as you write your tests:
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

   ' Use ClassInitialize to run code before running the first test in the class
   <ClassInitialize()> _
   Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)

      Dim appFolderPath As String = Rae.RaeSolutions.DataAccess.Common.AppFolderPath '.DbFolderPath '"C:\Documents and Settings\CaseyJ\My Documents\Visual Studio 2005\Projects\RAESolutions\"
      Dim dbFolderPath As String = Rae.RaeSolutions.DataAccess.Common.DbFolderPath ' appFolderPath & "Databases\"
      Rae.RaeSolutions.DataAccess.Common.Initialize(appFolderPath, dbFolderPath)
   End Sub

   <TestMethod()> _
   Public Sub ShouldConnectToSql()
      Dim releaseMgr As New Rae.RaeSolutions.DataAccess.ReleaseManager()
      Dim nextReleaseNum As Integer = releaseMgr.RetrieveNextUnassignedReleaseNum()

      Assert.IsTrue(nextReleaseNum > 0)
   End Sub

End Class
