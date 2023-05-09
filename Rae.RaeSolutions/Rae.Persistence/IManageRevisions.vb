Namespace Rae.Persistence

Public Interface IManageRevisions

   Function Increment(revision As Revision) As Revision
   ReadOnly Property Start As Revision

End Interface

Public Class RevisionManager
   Implements IManageRevisions
   
   Function Increment(revision As Revision) As Revision _
   Implements IManageRevisions.Increment
      Dim incremented As New Revision(revision.Major, revision.Minor + 1)
      Return incremented
   End Function

   ReadOnly Property Start As Revision _
   Implements IManageRevisions.Start
      Get
         Return New Revision(0, 0)
      End Get
   End Property
   
End Class

End Namespace