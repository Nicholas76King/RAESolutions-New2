Imports System.Collections.Generic

Namespace Rae.RaeSolutions.Business.Entities

''' <summary>Formats chiller model.</summary>
''' <remarks>Adds info to model used for mainframe searching and by shop.</remarks>
Public Class ChillerModel

   Sub New(chiller As chiller_equipment)
      Me.chiller = chiller
   End Sub

   Function Dash() As String
      Return chiller.model & extension(codesIn(chiller.options))
   End Function

   Private chiller As chiller_equipment

   Private Function extension(ops As List(Of String)) As String
      Dim ext = ""

      If pumpPackageIsIn(ops) Then ext &= "P"
      If tankIsIn(ops) Then ext &= "T"
      If ext <> "" Then
         If chiller.has_pump_package
            If chiller.pump_package.System=PumpSystem.Single
               ext = ext.Insert(0, "-S")
            ElseIf chiller.pump_package.System=PumpSystem.Dual
               ext = ext.Insert(0, "-D")
            End If
         End If
      End If

      Return ext
   End Function

   Private Function codesIn(ops As EquipmentOptionList) As List(Of String)
      Dim codes = New List(Of String)
      For Each op In ops
         codes.Add(op.Code)
      Next
      Return codes
   End Function

   Private Function tankIsIn(ops As List(Of String)) As Boolean
      Return ops.Exists(Function(c) TankCode.Matches(c))
   End Function

   Private Function pumpPackageIsIn(ops As List(Of String)) As Boolean
      Return ops.Exists(Function(c) pump_package_code.matches(c))
   End Function
End Class
End Namespace