Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert

<TestClass()> _
Public Class OptionTests

   Private code As String = "AB01"
   Private description As String = "Test option"
   
   <TestMethod()> _
   Sub ToString_WhenCodeAndDescriptionAreNotNull()
   	Dim op = New [Option] With {.Code=code, .Description=description}
   	
   	IsTrue(op.ToString = "AB01 - Test option")
   End Sub
   
   <TestMethod()> _
   Sub ToString_WhenCodeIsNull()
   	Dim op = New [Option]() With {.Code=Nothing, .Description=description}
   	
   	IsTrue(op.ToString = "Test option")
   End Sub
   
   <TestMethod()> _
   Sub ToString_WhenDescriptionIsNull()
   	Dim op = New [Option]() With {.Code=code, .Description=Nothing}
   	
   	IsTrue(op.ToString = "AB01")
   End Sub

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

' <ClassInitialize()> Shared Sub InitializeClass(context As TestContext)
' End Sub
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
