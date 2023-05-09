Imports Rae.Collections

Namespace rae.solutions

Public Class CoolingMedia

   Public Shared ReadOnly Water As New CoolingMedia("Water")
   ''' <summary>Ethylene glycol</summary>
   Public Shared ReadOnly Ethylene As New CoolingMedia("Ethylene glycol")
   ''' <summary>Propylene glycol</summary>
   Public Shared ReadOnly Propylene As New CoolingMedia("Propylene glycol")

End Class


Partial Public Class CoolingMedia
   Inherits listing(Of String)

   Protected Sub New(description As String)
      MyBase.New(description)
   End Sub

End Class

End Namespace