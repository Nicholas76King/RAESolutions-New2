Imports System.Collections.Generic

Namespace Rae.RaeSolutions.Business.Entities.Cofans

Class coil
   Sub new()
      For i=0 To 3
         at_fpi(i) = New at_fpi()
      Next
   End Sub

   Public id As Integer
        Public tubeDiameter As Double
   Public row_qty As Integer
   Public file_name As String
   Public coil_type As String
   Public fin_type As String
   Public p(4) As Double

   Public at_fpi(3) As at_fpi
End Class

Class at_fpi
   Public fpi, f(4) As Double
   ''' <summary>coil pressure coefficient</summary>
   Public p As Double
End Class

End Namespace