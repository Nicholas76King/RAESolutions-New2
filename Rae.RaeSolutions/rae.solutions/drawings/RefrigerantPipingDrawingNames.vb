Imports System.Collections.Generic
Imports rae.solutions.drawings.CompressorType
Imports Rae.RaeSolutions.Business.Entities

Namespace rae.solutions.drawings

''' <summary>Determines piping drawing file names</summary>
Public Class RefrigerantPipingDrawingNames
   Inherits List(Of String)

   ''' <summary>Initializes new piping drawing name</summary>
   Sub New(model As String, options As EquipmentOptionList)
      MyBase.New()
      if model like "35E2S*" then
                Add("35SWP1A.dxf")
            ElseIf model Like "20A*" Then
                Add("SLP1A.dxf")
                '    Add("SLP1B.dxf")
                'ElseIf model Like "20A4LM*" Then
                '    Add("SLP1A.dxf")
            ElseIf model Like "BLU*" Then
                Add("RP1A.dxf")
            Else
                determineCompresssorAndCircuit(model, options)
                addNames(compressor, numCircuits)
      end if
   End Sub



   Private compressor As CompressorType
   Private numCircuits As Integer
   
   Private Sub determineCompresssorAndCircuit(model As String, options As EquipmentOptionList)
      ' models with C like 20A0CS or 30A0CD have recip compressors
      ' models with L like 20A0LS or 30A0LD have scroll compressors
      ' models with S like 30A2SS or 30A2SD have screw compressors

      ' single circuit recips ' , "30A0CS*"
            If isModelLike(model, "DS*", "DM*", "20A0CS*", "NSB*", "NSC*", "NMB*", "NMC*") _
      OrElse (model Like "DD*" AndAlso options.Contains("MC20")) _
      OrElse (model Like "NDB*" AndAlso options.Contains("MC20")) _
      OrElse (model Like "NDC*" AndAlso options.Contains("MC20")) Then
                compressor = Recip
                numCircuits = 1

                ' single circuit scrolls
            ElseIf isModelLike(model, "20A0LS*") Then ', "30A0LS*") Then
                compressor = Scroll
                numCircuits = 1

                ' single circuit screws
            ElseIf isModelLike(model, "30A2SS*") Then
                compressor = Screw
                numCircuits = 1

                ' dual circuit recips
            ElseIf isModelLike(model, "DD*", "20A0CD*", "NDB*", "NDC*") Then ', "30A0CD*") Then
                compressor = Recip
                numCircuits = 2

                ' dual circuit scrolls
            ElseIf isModelLike(model, "20A0LD*") Then ', "30A0LD*") Then
                compressor = Scroll
                numCircuits = 2

                ' dual circuit screws
            ElseIf isModelLike(model, "30A2SD*") Then
                compressor = Screw
                numCircuits = 2

                ' multiple circuit recip
            ElseIf isModelLike(model, "20A0CM*") Then '"30A0CM*"
                compressor = Recip
                numCircuits = 2

                ' multiple circuit scroll
            ElseIf isModelLike(model, "30A2SM*") Then
                compressor = Screw
                numCircuits = 4
            ElseIf isModelLike(model, "BLU-L*") Then
                compressor = Scroll
                numCircuits = 1
            ElseIf isModelLike(model, "BLU-B*") Then
                compressor = Recip
                numCircuits = 1
            End If
   End Sub

   Private Function getName(compressor As CompressorType, circuit As Integer) As String
      Dim beginning As String
      Select Case compressor
         Case Scroll : beginning = "SLP1"
         Case Screw : beginning = "SWP1"
         Case Recip : beginning = "RP1"
         Case Else : Throw New Exception("Compressor type is invalid for drawing.")
      End Select

      Dim ending As String
      Select Case circuit
        Case 0 : ending = "A"
        Case 1 : ending = "B"
        Case 2 : ending = "C"
        Case 3 : ending = "D"
        Case Else : Throw New Exception("The drawing count is invalid.")
      End Select

         Dim drawingName = beginning & ending & ".dxf"

      Return drawingName
   End Function

   Private Sub addNames(compressor As CompressorType, numCircuits As Integer)
      For circuit = 0 To numCircuits - 1
         Dim name = getName(compressor, circuit)
         Add(name)
      Next
   End Sub

   Private Function isModelLike(model As String, ParamArray expressions() As String) As Boolean
      Dim isLike = False

      For Each expression In expressions
         If model Like expression Then
            isLike = True
            Exit For
         End If
      Next

      Return isLike
   End Function

End Class

End Namespace
