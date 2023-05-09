Imports Rae.Core
Imports System
Imports System.Collections.Generic

Namespace Rae.RaeSolutions.Business.Entities

   Public Class SpecialOptionList
      Inherits List(Of SpecialOption)
      Implements ICloneable(Of SpecialOptionList)
      Implements IEquatable(Of SpecialOptionList)


      Private m_revision As Single


      ''' <summary>
      ''' Gets revision and sets all the special option revisions.
      ''' </summary>
      Public Property Revision() As Single
         Get
            Return Me.m_revision
         End Get
         Set(ByVal value As Single)
            Me.m_revision = value
            For Each op As SpecialOption In Me
               op.Revision = value
            Next
         End Set
      End Property


      Sub New()
      End Sub


      ''' <summary>
      ''' Clones SpecialOptionList; creates a copy of this object.
      ''' </summary>
      ''' <returns>
      ''' Clone of this object.
      ''' </returns>
      Public Function Clone() As SpecialOptionList _
      Implements ICloneable(Of SpecialOptionList).Clone
         Dim otherList As New SpecialOptionList

         For Each other As SpecialOption In Me
            otherList.Add(other.Clone())
         Next

         otherList.Revision = Me.Revision

         Return otherList
      End Function


      ''' <summary>
      ''' Determines whether lists are equal. Order of items in list matters.
      ''' </summary>
      ''' <param name="other">
      ''' Other list to compare.
      ''' </param>
      ''' <returns>
      ''' True if equal; else false.
      ''' </returns>
      Public Shadows Function Equals(ByVal other As SpecialOptionList) As Boolean _
      Implements IEquatable(Of SpecialOptionList).Equals
         If Me.Count = other.Count _
         AndAlso Me.Revision = other.Revision Then
            For i As Integer = 0 To Me.Count - 1
               If Not Me.Item(i).Equals(other.Item(i)) Then
                  Return False
               End If
            Next
            Return True
         Else
            ' not equal, count is different
            Return False
         End If
      End Function


      ''' <summary>
      ''' Removes special options by code.
      ''' </summary>
      ''' <param name="id">
      ''' ID of special option to remove.
      ''' </param>
      Public Sub RemoveById(ByVal id As Integer)
         Dim indicies As New List(Of Integer)

         ' gets indicies matching code
         For i As Integer = 0 To Me.Count - 1
            If Me.Item(i).Id = id Then
               indicies.Add(i)
            End If
         Next

         ' removes items at indicies
         For Each i As Integer In indicies
            Me.RemoveAt(i)
         Next

      End Sub


   End Class

End Namespace