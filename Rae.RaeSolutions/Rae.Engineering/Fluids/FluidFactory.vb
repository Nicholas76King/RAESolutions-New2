Namespace rae.solutions

Public Class FluidFactory
   Function Create(fluid As CoolingMedia, percentage As Double) As IFluid
      Select Case fluid
         Case CoolingMedia.Water     : Return New Water()
         Case CoolingMedia.Ethylene  : Return New Ethylene(percentage)
         Case CoolingMedia.Propylene : Return New Propylene(percentage)
         Case Else
            Throw New Exception("The fluid is not valid.")
      End Select
   End Function
End Class
End Namespace