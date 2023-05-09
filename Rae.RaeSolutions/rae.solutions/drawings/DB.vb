Option Strict Off

Namespace rae.solutions.drawings
'todo: move to rae.data.access
Class DB
   Private reader
   
   Sub New(reader)
      Me.reader = reader
   End Sub
   
   Function dbl(column) As Double
      If Not IsDBNull(reader(column)) Then _
         dbl = reader(column)
   End Function
   
   Function str(column) As String
      If Not IsDBNull(reader(column)) Then _
         str = reader(column)
   End Function
   
   Function int(column) As Integer
      If Not IsDBNull(reader(column)) Then _
         int = reader(column)
   End Function
End Class

End Namespace