Imports Rae.Persistence
Imports System.Collections.Generic

Namespace Persistence

Public Class PersistenceController

#Region " External"

Sub New(item As ICanBePersisted)
   item_ = item
End Sub

ReadOnly Property Item As ICanBePersisted
   Get
      Return item_
   End Get
End Property

Function OnSave() As Boolean
   Dim canceled As Boolean
   
   Item.Refresh.Invoke()
   If OpenedProject.IsOpened Then
      If Item.IsPersisted Then
         If Item.HasChanged Then
            If Item.Revisions.IsLatest Then
               Item.Save()
            Else
               askToSaveAsLatestRevision()
            End If
         Else
            ' has no changes to save
         End If
      Else  ' not persisted
         askItemNameBeforeSave()
      End If
   Else  ' project not opened
      canceled = askProjectAndItemNameBeforeSave()
   End If
   
   Return canceled
End Function

Function OnClose() As Boolean
   Dim canceled As Boolean
   
   Item.Refresh.Invoke()
   If OpenedProject.IsOpened Then
      If Item.IsPersisted Then
         If Item.HasChanged Then
            If Item.Revisions.IsLatest Then
               canceled = askToSavePersistedItemBeforeClosing()
            Else
               canceled = askToSavePreviousRevisionBeforeClosing()
            End If
         Else  ' item has not changed
            ' let close, nothing changed
         End If
      Else ' item not persisted
         canceled = askToSaveUnpersistedItemBeforeClosing()
      End If
   Else ' no opened project
      canceled = askToSaveUnpersistedProjectAndItemBeforeClosing()
   End If
   
   Return canceled
End Function

Sub OnSaveAsRevision()
   Item.Refresh.Invoke()
   Item.SaveAsRevision()
End Sub

#End Region


#Region " Internal"

Protected item_ As ICanBePersisted

#Region " Save"

Private Function askProjectAndItemNameBeforeSave() As Boolean
   Dim prompt As IAskUserToSave = AskUserToSaveFactory.Create( _
      "Please enter names for the project and item before saving.", _
      New String() {"Project Name", "Item Name"}, _
      New StringDictionary() _
         .Add("Save", "Create project and save item") _
         .Add("Cancel", "Do not save item"))
   
   Dim response As SaveResponse = prompt.Ask()

   Select Case response.SelectedCommand
      Case "Save"
         ProjectInfo.Creator.CreateProject(response.Inputs("Project Name"))

         Item.Name = response.Inputs("Item Name")
         ProjectInfo.Creator.Create(Item)
   End Select
   
   Return (response.SelectedCommand = "Cancel")
End Function

Private Sub askItemNameBeforeSave()
   Dim prompt As IAskUserToSave = AskUserToSaveFactory.Create( _
      "Please name the item before saving.", _
      New String() {"Item Name"}, _
      New StringDictionary() _
         .Add("Save", "") _
         .Add("Cancel", "Don't save and return to item"))
         
   Dim response As SaveResponse = prompt.Ask()
   
   Select Case response.SelectedCommand
      Case "Cancel"
         ' save canceled
      Case "Save"
         Item.Name = response.Inputs("Item Name")
         ProjectInfo.Creator.Create(Item)
      Case Else
         Throw New Exception()
   End Select
End Sub

Private Sub askToSaveAsLatestRevision()
   Dim prompt As IAskUserToSave = AskUserToSaveFactory.Create( _
      "Do you want to save changes as the latest revision?", _
      New String() {}, _
      New StringDictionary() _
         .Add("Save as Latest", "Save changes as the latest revision.") _
         .Add("Don't Save", ""))
   Dim response As SaveResponse = prompt.Ask()
   
   Select Case response.SelectedCommand
      Case "Save as Latest"
         Item.SaveAsRevision()
      Case "Don't Save"
         ' don't need to do anything
      Case Else
         Throw New Exception()
   End Select
End Sub

#End Region


#Region " Close"

Private Function askToSavePersistedItemBeforeClosing() As Boolean
   Dim asker As IAskUserToSave = AskUserToSaveFactory.Create( _
      "Do you want to save changes to this existing item before closing?", _
      New String() {}, _
      New StringDictionary() _
         .Add("Save", "Save and close") _
         .Add("Save as Revision", "Save as a new revision and close") _
         .Add("Don't Save", "Do not save and close") _
         .Add("Cancel", "Do not save and do not close"))
   
   Dim response As SaveResponse = asker.Ask()
   Dim canceled As Boolean
   
   Select Case response.SelectedCommand
      Case "Save"
         Item.Save()
      Case "Don't Save"
         ' just let it close
      Case "Save as Revision"
         Item.SaveAsRevision()
      Case "Cancel"
         canceled = True
      Case Else
         Throw New Exception()
   End Select
   
   Return canceled
End Function

Private Function askToSaveUnpersistedItemBeforeClosing() As Boolean
   Dim asker As IAskUserToSave = AskUserToSaveFactory.Create( _
      "Do you want to save this new item before closing?", _
      New String() {"Item Name"}, _
      New StringDictionary() _
         .Add("Save", "Save and close") _
         .Add("Don't Save", "Do not save and close") _
         .Add("Cancel", "Do not save and do not close)"))
   
   Dim response As SaveResponse = asker.Ask()
   
   Dim canceled As Boolean
   Select Case response.SelectedCommand
      Case "Save"
         Item.Name = response.Inputs("Item Name")
         Item.Save()
         ProjectInfo.Creator.Create(Item)
      Case "Don't Save"
         ' let close
      Case "Cancel"
         canceled = True
      Case Else
         Throw New Exception()
   End Select
   
   Return canceled
End Function

Private Function askToSaveUnpersistedProjectAndItemBeforeClosing() As Boolean
   Dim asker As IAskUserToSave = AskUserToSaveFactory.Create( _
      "Do you want to create a project and save before closing?", _
      New String() {"Project Name", "Item Name"}, _
      New StringDictionary() _
         .Add("Save", "Create a project, save item and close item") _
         .Add("Don't Save", "Don't save and close") _
         .Add("Cancel", "Don't save and return to item"))
   
   Dim response As SaveResponse = asker.Ask()
   Dim canceled As Boolean
   
   Select Case response.SelectedCommand
      Case "Save"
         ProjectInfo.Creator.CreateProject(response.Inputs("Project Name"))
         Me.Item.Name = response.Inputs("Item Name")         
         ProjectInfo.Creator.Create(Me.Item)
      Case "Don't Save"
         ' let close without saving
      Case "Cancel"
         canceled = True
      Case Else
         Throw New Exception()
   End Select
   
   Return canceled
End Function

Private Function askToSavePreviousRevisionBeforeClosing() As Boolean
   Dim prompt As IAskUserToSave = AskUserToSaveFactory.Create( _
      "Do you want to save as latest before closing?", _
      New String() {}, _
      New StringDictionary() _
         .Add("Save as Latest", "Save this previous revision as the latest revision and close.") _
         .Add("Don't Save", "Do not save but do close") _
         .Add("Cancel", "Do not save and do not close"))
   
   Dim response As SaveResponse
   response = prompt.Ask()
   
   Dim canceled As Boolean
   Select Case response.SelectedCommand
      Case "Save as Latest"
         Item.SaveAsRevision()
      Case "Don't Save"
         ' don't need to do anything, just let it close
      Case "Cancel"
         canceled = True
   End Select
   
   Return canceled
End Function

#End Region

#End Region

End Class

Public Class StringDictionary
   Inherits Dictionary(Of String, String)
   
   Function Add(key As String, value As String) As StringDictionary
      MyBase.Add(key, value)
      Return Me
   End Function
End Class

End Namespace