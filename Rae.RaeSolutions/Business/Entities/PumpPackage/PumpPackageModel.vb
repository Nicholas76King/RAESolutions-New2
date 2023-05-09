Namespace Rae.RaeSolutions.Business.Entities

Public Class PumpPackageModel

   Sub New(model As String, options As EquipmentOptionList)
      Me.model = model
      Me.options = options
   End Sub
   
   Function Dash() As String
      Return model & extension
   End Function
   
   Private Function extension() As String
      Dim ext = ""
      Dim tank = hasTank
      
      If tank Then ext &= "T"
      ext &= "H"
      ext = ext.Insert(0, "-")

      Return ext
   End Function
   
   Private Function hasTank() As Boolean
      Return options.Exists( Function(op) TankCode.Matches(op.Code) )
   End Function
   
   Private model As String
   Private options As EquipmentOptionList
End Class

End Namespace