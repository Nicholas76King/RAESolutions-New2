Imports Rae.RaeSolutions.Business.Entities
Imports PricingDa = Rae.RaeSolutions.DataAccess.Projects.EquipmentDa

Public Class ItemAdder
   Implements IItemAdder

   Sub AddItem(itemId As String, type As ItemType) _
   Implements IItemAdder.AddItem
      Select Case type
         Case ItemType.Pricing
            Dim e As EquipmentItem = PricingDa.Retrieve(itemId)
            updateEquipmentAssociations(e)
            ProjectInfo.Creator.CreateEquipment(e)
         Case ItemType.BoxLoad
            Dim b As New BoxLoad(New item_id(itemId), OpenedProject.Manager)
            b.Load()
            'TODO: check if ID should be regenerated
            ProjectInfo.Creator.Create(b)
         Case ItemType.Engineering
            ' load engineering
      End Select
   End Sub

   Private Sub updateEquipmentAssociations(e As EquipmentItem)
      ' assigns a new equipment ID to copy
      e.id = IdGen.Gen()
      For Each op In e.special_options
         op.EquipmentId = e.id
      Next
      ' changes copied equipments project
      e.ProjectManager = OpenedProject.Manager
   End Sub

End Class
