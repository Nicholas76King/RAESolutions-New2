Namespace Rae.RaeSolutions.Business.Entities

''' <summary>Checks if runtime is too short (could damage compressor)</summary>
Public Class RuntimeWarning
   Sub New(flow As Double, tankSize As Integer)
      min_runtime = 3
   
      Runtime = tankSize / flow
      Applies = Runtime < min_runtime
            
      Message = _
      "Tank selected does not meet minimum " & min_runtime & "-minute runtime. " & _
      "The remaining system volume must be covered by external piping. Contact factory."
   End Sub
   
   Public ReadOnly Runtime As Double
   Public ReadOnly Applies As Boolean
   Public ReadOnly Message As String
   
   Private min_runtime As Double
End Class

End Namespace