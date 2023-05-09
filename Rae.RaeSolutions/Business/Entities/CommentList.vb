Imports System
Imports System.Collections.Generic


Namespace Rae.RaeSolutions.Business.Entities

  ''' <summary>
  ''' List of comments
  ''' </summary>
  ''' <remarks>
  ''' Adds cloning and equality functionality
  ''' </remarks>
  ''' <history by="Casey Joyce" finish="2006/05/05">
  ''' Created. Methods: Clone(), Equals(other).
  ''' </history>
  Public Class CommentList
    Inherits List(Of Comment)
    Implements ICloneable(Of CommentList)
    Implements IEquatable(Of CommentList)

    ''' <summary>
    ''' Clones comments
    ''' </summary>
    Public Function Clone() As CommentList _
    Implements ICloneable(Of CommentList).Clone
      Dim myClone As New CommentList()

      ' adds a clone of each comment in this list
      For Each comment As Comment In Me
        myClone.Add(comment.Clone())
      Next

      Return myClone
    End Function

    ''' <summary>
    ''' Determines whether comment lists are equal.
    ''' </summary>
    ''' <param name="other">The other comment list to compare.</param>
    ''' <returns>
    ''' True if each comment in both lists are equal; false if all comments are not equal
    ''' </returns>
    Public Overloads Function Equals(ByVal other As CommentList) As Boolean _
    Implements System.IEquatable(Of CommentList).Equals
      ' checks if comment lists contain the same number of comments
      If Me.Count = other.Count Then
        ' checks if comments in list are equals
        '
        For i As Integer = 0 To Me.Count - 1
          If Not Me.Item(i).Equals(other.Item(i)) Then
            ' comment lists are NOT equal (all comments are not the same)
            Return False
          End If
        Next

        ' comment lists are equal
        Return True
      Else
        ' comment list are NOT equal (different number of comments)
        Return False
      End If
    End Function

  End Class

End Namespace