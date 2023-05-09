Imports Rae.RaeSolutions

<TestClass()> _
Public Class Given_dollar_label_is_set

   Private Shared lbl As DollarLabel

   <ClassInitialize()> _
   Shared Sub when_set(ctx As TestContext)
      lbl = New DollarLabel()
   End Sub
   
   <TestMethod()> _
   Sub then_0_should_be_formatted
      lbl.Text = "0"
      IsTrue( lbl.Text = "$0" )
   End Sub
   
   <TestMethod()> _
   Sub then_null_should_be_formatted_to_0
   	lbl.Text = Nothing
   	IsTrue( lbl.Text = "$0" )
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

#End Region

End Class
