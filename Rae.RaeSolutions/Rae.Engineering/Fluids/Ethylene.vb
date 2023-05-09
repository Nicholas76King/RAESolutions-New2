Imports Rae.RaeSolutions.DataAccess.Chillers
Imports System.Data

Namespace rae.solutions

Class Ethylene : Inherits Glycol
   Sub New(percentage As Double)
      MyBase.New(percentage)
   End Sub
   
   Protected Overrides Function getGlycolData() As DataTable
      Return ChillerDataAccess.RetrieveEthylene()
   End Function
End Class

End Namespace