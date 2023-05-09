Imports Rae.RaeSolutions.DataAccess.Chillers
Imports System.Data

Namespace rae.solutions

Class Propylene : Inherits Glycol
   Sub New(percentage As Double)
      MyBase.New(percentage)
   End Sub
   
   Protected Overrides Function getGlycolData() As DataTable
      Return ChillerDataAccess.RetrievePropylene()
   End Function
End Class

End Namespace