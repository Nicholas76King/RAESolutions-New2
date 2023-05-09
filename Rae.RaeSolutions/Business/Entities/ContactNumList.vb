Imports System
Imports System.Collections.Generic
Imports Rae.Core
Imports Rae.RaeSolutions.Business.Entities

Namespace Rae.RaeSolutions.Business.Entities

   ''' <summary>
   ''' Contact number list
   ''' </summary>
   ''' <history by="Casey Joyce" finish="2006/05/07" hours="1">
   ''' Created
   ''' </history>
   Public Class ContactNumList
      Inherits List(Of ContactNum)
      Implements IEquatable(Of ContactNumList)
      Implements ICloneable(Of ContactNumList)


      ''' <summary>
      ''' Checks equality of contact number lists
      ''' </summary>
      ''' <param name="other">
      ''' Other contact number list to compare
      ''' </param>
      ''' <returns>
      ''' True if contact number lists are equal; else false.
      ''' </returns>
      Public Overloads Function Equals(ByVal other As ContactNumList) As Boolean _
      Implements System.IEquatable(Of ContactNumList).Equals
         If Me.Count = other.Count Then
            For i As Integer = 0 To Me.Count - 1
               If Not Me(i).Equals(other(i)) Then
                  Return False
               End If
            Next
         Else
            Return False
         End If

         Return True
      End Function


      ''' <summary>
      ''' Clones contact number list
      ''' </summary>
      ''' <returns>
      ''' Clone of contact number list
      ''' </returns>
      Public Function Clone() As ContactNumList _
      Implements ICloneable(Of ContactNumList).Clone
         Dim listClone As New ContactNumList

         For Each num As ContactNum In Me
            listClone.Add(num.Clone())
         Next

         Return listClone
      End Function

   End Class

End Namespace