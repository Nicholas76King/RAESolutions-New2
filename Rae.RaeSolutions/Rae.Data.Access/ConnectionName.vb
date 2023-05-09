Imports Rae.Collections

Namespace Rae.Data.Access

Public Class ConnectionName
   ''' <summary>Contains user's project data.</summary>
   Public Shared ReadOnly Projects As New ConnectionName("Projects")
End Class


Partial Public Class ConnectionName
   Inherits listing(Of String)

   Private Sub New(value As String)
      MyBase.New(value)
   End Sub

End Class

End Namespace