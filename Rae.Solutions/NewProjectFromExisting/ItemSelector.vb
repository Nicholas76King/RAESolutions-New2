Imports System.Collections.Generic

Public Class ItemSelector
   Implements IItemSelector

   Sub AskUser(projectId As String) _
   Implements IItemSelector.AskUser
      Dim f As New ItemSelectionForm()
      f.ShowItemsWith(projectId)

      If f.DialogResult = DialogResult.Cancel Then
         _canceled = True
      Else
         _items = f.SelectedItems
      End If
   End Sub

   ReadOnly Property Canceled() As Boolean _
   Implements IItemSelector.Canceled
      Get
         Return _canceled
      End Get
   End Property

   ReadOnly Property Items() As List(Of ItemInfo) _
   Implements IItemSelector.Items
      Get
         Return _items
      End Get
   End Property


   Protected _items As List(Of ItemInfo)
   Protected _canceled As Boolean
End Class
