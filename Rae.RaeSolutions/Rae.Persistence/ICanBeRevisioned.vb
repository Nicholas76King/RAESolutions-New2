Namespace Rae.Persistence

Public Interface ICanBeRevisioned
   Inherits ICanBeSaved, ICanBeSavedAsRevision, IAmAwareOfChange, IAmAwareOfPersistence
   
   ReadOnly Property Revisions() As RevisionList

   Sub Load(revision As Revision)

   Property Refresh As RefreshSignature
   
   Event SavedAsRevision As EventHandler(Of ICanBeRevisioned, System.EventArgs)
   
End Interface

Public Delegate Sub RefreshSignature()

End Namespace