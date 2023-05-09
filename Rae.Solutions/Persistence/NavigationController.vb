Imports Rae.Persistence

Namespace Persistence

Public Class NavigationController
   Implements IDisposable

   Sub New(navigator As ICanNavigate)
      If navigator Is Nothing Then throwNavigatorNull

      Me.navigator = navigator
      
   End Sub
   

   ''' <summary>
   ''' Item whose revisions can be navigated. Also sets the navigator's Item property.
   ''' </summary>
   Property Item As ICanBeRevisioned
      Get
         Return item_
      End Get
      Set(value As ICanBeRevisioned)
         item_ = value
         navigator.Item = value
      End Set
   End Property
   
   
   Sub Dispose() _
   Implements IDisposable.Dispose
      If navigator IsNot Nothing Then
         RemoveHandler navigator.Navigated, AddressOf navigator_Navigated
         RemoveHandler navigator.Navigating, AddressOf navigator_Navigating
      End If
   End Sub
   
   
#Region " Internal"
   
   Protected WithEvents navigator As ICanNavigate 'Revisions
   Protected item_ As ICanBeRevisioned
   
   Private Sub navigator_Navigating(sender As ICanNavigate, e As NavigatingEventArgs) _
   Handles navigator.Navigating
      If OpenedProject.IsOpened Then
         If item_.IsPersisted Then
            If Not item_.Revisions.Contains(e.AfterValue) Then
               e.Cancel("Cannot navigate to revision. The revision does not exists")
            ElseIf e.BeforeValue = e.AfterValue Then
               e.Cancel("Already on this revision.")
            Else
               askToSaveBeforeNavigating(item_, e)
            End If
         Else
            'e.Cancel("Cannot navigate to revision. The item does not exist in data source; there are no revisions.")
         End If
      Else
         e.Cancel("Cannot navigate to revision. There is no project opened.")
      End If
   End Sub
   
   Private Sub navigator_Navigated(sender As ICanNavigate, e As NavigatedEventArgs) _
   Handles navigator.Navigated
      item_.Load(e.AfterValue)
   End Sub
   
   Private Sub askToSaveBeforeNavigating(item As ICanBeRevisioned, e As NavigatingEventArgs)
      If item.HasChanged Then
         If item.Revisions.IsLatest Then
            saveLatest(e)
         Else
            savePrevious(e)
         End If
      Else
         ' continue navigating, there were no changes
      End If
   End Sub
   
   Private Sub saveLatest(ByRef e As NavigatingEventArgs)
      Dim prompt As IAskUserToSave = AskUserToSaveFactory.Create( _
         "Do you want to save before navigating?", _
         New String() {}, _
         New StringDictionary() _
            .Add("Save", "Save and continue to navigate") _
            .Add("Save as Revision", "Save as revision and continue to navigate") _
            .Add("Don't Save", "Do not save but continue to navigate") _
            .Add("Cancel", "Do not save and do not navigate"))
            
      Dim response As SaveResponse = prompt.Ask()

      Select Case response.SelectedCommand
         Case "Save"
            item.Save()
         Case "Save as Revision"
            item.SaveAsRevision()
            item.Load(e.AfterValue)
         Case "Don't Save"
            ' don't save, but do continue to navigate
         Case "Cancel"
            e.Cancel("User canceled revision navigation")
         Case Else
            e.Cancel("Navigation was canceled. An unexpected command was selected.")
      End Select
   End Sub
   
   Private Sub savePrevious(ByRef e As NavigatingEventArgs)
      Dim prompt As IAskUserToSave = AskUserToSaveFactory.Create( _
         "Do you want to save previous revision as the latest revision?", _
         New String() {}, _
         New StringDictionary() _
            .Add("Save as Latest", "Save previous revision as the latest revision and continue navigation") _
            .Add("Don't Save", "Do not save and continue navigation") _
            .Add("Cancel", "Do not save and cancel navigation"))
      
      Dim response As SaveResponse = prompt.Ask()
      
      Select Case response.SelectedCommand
         Case "Save as Latest"
            item.SaveAsRevision()
            item.Load(e.AfterValue)
         Case "Don't Save"
            ' don't save, but continue navigation
         Case "Cancel"
            e.Cancel("User canceled navigation")
         Case Else
            e.Cancel("Navigation was canceled. An unexpected command was selected.")
      End Select
   End Sub
   
   Private Sub throwNavigatorNull
      Throw New System.ArgumentNullException("The revisioning controller cannot be constructed." & _
         "The navigator parameter is null.")
   End Sub

#End Region

End Class

End Namespace