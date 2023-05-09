Imports System.Collections.Generic
Imports Rae.RaeSolutions.Business.Entities

Public Class ItemSelection
   Implements IItemSelection

   Sub AskUser() _
   Implements IItemSelection.AskUser
      Dim p As IProjectSelector = New ProjectSelector() ' = Container(Of IProjectSelection).Create()
      p.AskUser()
      If Not p.Canceled Then
         Dim i As IItemSelector = New ItemSelector() ' = Container(Of IItemSelection).Create(p.ProjectId)
         i.AskUser(p.ProjectId)
         If i.Canceled Then _canceled = i.Canceled _
         Else _items = i.Items
      Else
         _canceled = p.Canceled
      End If
   End Sub

   ReadOnly Property Canceled() As Boolean _
   Implements IItemSelection.Canceled
      Get
         Return _canceled
      End Get
   End Property

   ReadOnly Property Items() As List(Of ItemInfo) _
   Implements IItemSelection.Items
      Get
         Return _items
      End Get
   End Property


   Protected _canceled As Boolean
   Protected _items As List(Of ItemInfo)

End Class
