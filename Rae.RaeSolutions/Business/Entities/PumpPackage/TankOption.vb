Imports System.Text.RegularExpressions
Imports Rae.Validation

Namespace Rae.RaeSolutions.Business.Entities

Public Class TankOption
   Sub New(code As String, description As String)
      IsTank = tank(code)
      If IsTank Then _
         TankSize = parseSizeFrom(description)
   End Sub

   Public ReadOnly IsTank As Boolean
   Public ReadOnly TankSize As Integer

   Private Function tank(code As String) As Boolean
      Select Case code
         Case "HT05", "HT06", "HT07", "HT11", "HT12" : Return True
         Case Else : Return False
      End Select
   End Function

   Private Function parseSizeFrom(description As String) As Integer
      Dim isNumber As Boolean
      Dim nums = ""

      For j = (description.Length - 1) To 0 Step -1
         isNumber = Regex.IsMatch(description(j), regular_expressions.Integer)
         If isNumber Then
            nums = nums.Insert(0, description(j).ToString)
         Else
            Exit For
         End If
      Next

      Return CInt(nums)
   End Function

End Class
End Namespace
