Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert

<TestClass()> _
Public Class OptionTestBase

#Region " Initialize and cleanup"

Property Context As TestContext
   Get
      Return _context
   End Get
   Set(value As TestContext)
      _context = value
   End Set
End Property

Private _context As TestContext

'<ClassInitialize()> Shared Sub InitializeClass(context As TestContext)
'   ConnectionString.InitializeTest(dbFilePathForTesting)
'End Sub
'
' <ClassCleanup()> Shared Sub CleanupClass()
' End Sub
'
' <TestInitialize()> Sub InitializeTest()
' End Sub
'
' <TestCleanup()> Sub CleanupTest()
' End Sub

#End Region

End Class
