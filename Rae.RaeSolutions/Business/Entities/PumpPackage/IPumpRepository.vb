Imports Rae.RaeSolutions.Business.Entities
Imports System.Collections.Generic

Namespace Rae.RaeSolutions.Business.Repositories

Public Interface IPumpRepo

   Function GetPump( _
      manufacturer As String, _
      gpm As Double, _
      head As Double, _
      system As PumpSystem) _
   As PumpData
   
End Interface

End Namespace