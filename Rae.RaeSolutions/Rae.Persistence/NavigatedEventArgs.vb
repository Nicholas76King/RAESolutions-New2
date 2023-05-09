Namespace Rae.Persistence

Public Class NavigatedEventArgs
   Inherits ValueChangedEventArgs(Of Revision)

   Sub New(revisionBeforeNavigation As Revision, revisionAfterNavigation As Revision)
      MyBase.New(revisionBeforeNavigation, revisionAfterNavigation)
   End Sub

End Class

End Namespace