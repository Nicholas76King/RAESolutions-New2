Namespace Rae.RaeSolutions.Business.Entities

Public Class TankCode
   Shared Function Matches(code As String) As Boolean
      Return New TankOption(code, "1").IsTank
   End Function
End Class

End Namespace