Imports System

Namespace Rae.Persistence


''' <summary>A list of revisions that is sorted and does not allow duplicate revisions.</summary>
Public Class RevisionList
   Inherits List(Of Revision)

   ''' <summary>Adds a revision</summary>
   ''' <param name="revision">Revision to add cannot exist in list</param>
   Overloads Sub Add(revision As Revision)
      throwIfContains(revision)

      MyBase.Add(revision)
      Sort()
   End Sub

   Overloads Sub AddRange(revisions As IEnumerable(Of Revision))
      For Each r As Revision In revisions
         throwIfContains(r)
      Next

      MyBase.AddRange(revisions)
      Sort()
   End Sub



   ''' <summary>Current revision</summary>
   ''' <remarks>
   ''' What about when indexes are sorted or otherwise changed?
   '''     Sorting shouldn't matter since current references revision not index.
   ''' What about removing indexes?
   '''     Revisions should never be removed      
   ''' </remarks>   
   Property Current() As Revision
      Get
         Return current_
      End Get
      Set(value As Revision)
         throwIfDoesNotContain(value)
         current_ = value
      End Set
   End Property
   
   ''' <summary>First revision</summary>
   ReadOnly Property First As Revision
      Get
         If Count > 0 Then
            Return Item(0)
         Else
            Return Nothing
         End If
      End Get
   End Property
   
   ''' <summary>Returns the previous revision before the current revision.</summary>
   ''' <remarks>If the current revision is the first revision made, returns the first revision.</remarks>
   ReadOnly Property Previous As Revision
      Get
         Dim previousRevision As Revision
         
         If IndexOf(Current) = 0 Then
            previousRevision = Current
         Else
            Dim previousIndex = IndexOf(Current) - 1
            previousRevision = Item(previousIndex)
         End If
                  
         Return previousRevision
      End Get
   End Property

   ''' <summary>Returns the next revision after the current revision</summary>
   ReadOnly Property [Next] As Revision
      Get
         Dim nextRevision As Revision
         
         If IndexOf(Current) = IndexOf(Last) Then
           nextRevision = Last
         Else
            Dim nextIndex As Integer = IndexOf(Current) + 1
            nextRevision = Item(nextIndex)
         End If
         
         Return nextRevision
      End Get
   End Property

   ''' <summary>Last revision</summary>
   ReadOnly Property Last As Revision
      Get
         If Count > 0 Then
            Dim lastIndex As Integer = Count - 1
            Return Item(lastIndex)
         Else
            Return Nothing
         End If
      End Get
   End Property
   
   
   ''' <summary>True if current revision is the latest revision</summary>
   ReadOnly Property IsLatest As Boolean
      Get
         If Current Is Nothing Then
            Throw New InvalidOperationException( _
               "The attempt to check if the current revision is the latest revision failed. " & _
               "The current revision is null.")
         End If
         Return (Current = Last)
      End Get
   End Property  
   
   
   ''' <summary>True if current revision the first revision</summary>
   ReadOnly Property IsFirst As Boolean
      Get
         Return (Current = Item(0))
      End Get
   End Property
   
   
   Overrides Function Equals(obj As Object) As Boolean
      Dim areEqual As Boolean = True
      
      If TypeOf obj Is RevisionList Then
         Dim r As RevisionList = CType(obj, RevisionList)
         If Count <> r.Count Then
            areEqual = False
         Else
            For i As Integer = 0 To Me.Count - 1
               If Not Me(i) = r(i) Then
                  areEqual = False
                  Exit For
               End If
            Next
         End If
      Else
         areEqual = False
      End If
      
      Return areEqual
   End Function
   
   
   
   Private Sub throwIfDoesNotContain(revision As Revision)
      If Not Contains(revision) Then
         Throw New ArgumentException( _
         "The attempt to set the current revision failed. The revision does not exist.")
      End If
   End Sub
   
   Private Sub throwIfContains(revision As Revision)
      If Contains(revision) Then
         Throw New ArgumentException( _
         "The attempt to add a revision failed. The revision to add must be unique.")
      End If
   End Sub
   
   Protected current_ As Revision
   
End Class

End Namespace