Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ExpirationManager = Rae.Deployment.ExpirationManager


<TestClass()> Public Class ExpirationManagerTest

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
   Public Sub TestStatus()
      ' tests current
      Dim expirationMgr As New ExpirationManager("C:\a.test", #5/1/2011#)
      Assert.IsTrue(expirationMgr.Status = ExpirationManager.ExpirationStatus.Current)

      ' tests expired
      expirationMgr = New ExpirationManager("C:\a.test", #1/1/2005#)
      Assert.IsTrue(expirationMgr.Status = ExpirationManager.ExpirationStatus.Expired)
   End Sub

   <TestMethod()> _
   Public Sub TestConstructorParameterProperties()
      Dim expirationMgr As New ExpirationManager("C:\a.test", #1/1/2008#)
      Assert.IsTrue(expirationMgr.FilePath = "C:\a.test")
      Assert.IsTrue(expirationMgr.ExpirationDate = #1/1/2008#)
   End Sub

   <TestMethod()> _
   Public Sub TestDaysUntilExpiration()
      Dim expirationMgr As New ExpirationManager("C:\a.test", Date.Today)
      Assert.IsTrue(expirationMgr.GetDaysUntilExpiration = 0)

      expirationMgr = New ExpirationManager("C:\a.test", Date.Today.Add(New System.TimeSpan(1, 0, 0, 0)))
      Assert.IsTrue(expirationMgr.GetDaysUntilExpiration = 1)
   End Sub

End Class
