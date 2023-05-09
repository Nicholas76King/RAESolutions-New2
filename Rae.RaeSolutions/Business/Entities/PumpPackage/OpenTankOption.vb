Namespace Rae.RaeSolutions.Business.Entities

Public Class OpenTankOption
   Sub New(code As String)
      IsMatch = ( code="HT05" )
   End Sub
   Public ReadOnly IsMatch As Boolean
   Public ReadOnly Warning As String = _
      "Open tank must be located above connected loads or overflow may occur."
End Class

End Namespace