Namespace Rae.Persistence

Public Interface ICanNavigate
   Event Navigating(sender As ICanNavigate, e As NavigatingEventArgs)
   Event Navigated(sender As ICanNavigate, e As NavigatedEventArgs)
   
   Sub NavigateTo(revision As Revision)
   
   Property Item As ICanBeRevisioned
End Interface

End Namespace