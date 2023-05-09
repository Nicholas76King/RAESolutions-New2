''' <summary>
''' Work flow for copying an existing item from one project to another.
''' </summary>
''' <remarks>
''' Depenedent on ProjectInfo
''' </remarks>
Public Class CopyExistingItemWorkFlow

Sub New(projectIsOpened As Boolean)
   Me.projectIsOpened = projectIsOpened
End Sub

Sub Start()
   startWorkFlow(projectIsOpened)
End Sub

Private projectIsOpened As Boolean


Private Function startWorkFlow(projectIsOpened As Boolean) As Boolean
   ' creates project if doesn't exist
   If Not projectIsOpened Then _
      ProjectInfo.Creator.CreateProject()
   If Not OpenedProject.IsOpened Then _
      Return True ' user canceled project creation
   
   ' user selects items to add
   Dim selector As IItemSelection = New ItemSelection() ' = Container.Create(IItemSelector)
   selector.AskUser()
   If selector.Canceled Then _
      Return True ' user canceled item selection
   
   ' adds selected items to project
   Dim adder As IItemAdder = New ItemAdder() ' = Container.Create(IItemAdder)
   For Each item As ItemInfo In selector.Items
      adder.AddItem(item.Id, item.Type)
   Next
   
   Return False
End Function

End Class