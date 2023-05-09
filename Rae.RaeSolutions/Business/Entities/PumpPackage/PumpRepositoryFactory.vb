Imports Rae.RaeSolutions.Business.Repositories
Imports Rae.Data.Access

Namespace Rae.RaeSolutions.Business.Entities
Public Class PumpRepoFactory
   Shared Function Create() As IPumpRepo
      Return New PumpRepo
   End Function
End Class
End Namespace