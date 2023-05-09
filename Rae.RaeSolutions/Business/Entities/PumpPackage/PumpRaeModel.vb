Imports System.Math

Namespace Rae.RaeSolutions.Business.Entities

Public Class PumpRaeModel

   Sub New(flow As Double, system As PumpSystem)
      _value = "18 PP"
      
      Select Case system
         Case PumpSystem.Single : _value &= "S"
         Case PumpSystem.Dual : _value &= "D"
         Case Else : Throw New Exception("RAE model cannot be determined. The pump system is invalid.")
      End Select
      
      _value &= Round(flow)
   End Sub
   
   ReadOnly Property Value As String
   	Get
   		Return _value
   	End Get
   End Property : Private _value As String
   
End Class

End Namespace