Option Strict On
Option Explicit On 


Namespace Rae.Solutions.Chillers


''' <summary>Chiller evaporator</summary>
''' <remarks>Has same fields as in table, ChillerData, in chiller database</remarks>
Public Class Evaporator1
   Public StandardModelNum As String
   Public RaePartNum As String
   Public EvaporatorPartNum As String
   Public NominalTons As Double
   Public Height As Double
   Public Width As Double
   Public Length As Double
   Public ConnectionSize As String


   Shared Function IsEvaporatorModelValid(evaporatorModel As String) As Boolean
      Dim isValid As Boolean

      If evaporatorModel <= "   " Or evaporatorModel = "fsx150" _
      Or evaporatorModel = "fsx200" Or evaporatorModel = "fsx250" _
      Or evaporatorModel = "fsx300" Or evaporatorModel = "fsx350" Then
         isValid = False
      Else
         isValid = True
      End If

      Return isValid
   End Function


   Overrides Function ToString() As String
      Dim newLine As String = System.Environment.NewLine
      Dim caption As String

      With Me
         caption = "Part #: " & .RaePartNum & newLine & _
            "Nominal tons: " & .NominalTons & newLine & _
            "Connection size: " & .ConnectionSize & newLine & _
            "LxWxH: " & .Length.ToString & "x" & .Width.ToString & "x" & .Height.ToString
      End With

      Return caption
   End Function

End Class

End Namespace
