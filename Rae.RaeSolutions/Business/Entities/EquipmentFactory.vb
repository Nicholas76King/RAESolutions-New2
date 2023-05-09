Imports System

Namespace Rae.RaeSolutions.Business.Entities

''' <summary>Equipment factory builds equipment items.</summary>
Public Class EquipmentFactory

   ''' <summary>Hides constructor.</summary>
   Private Sub New()
   End Sub


   ''' <summary>Creates equipment with an existing ID and existing project manager.</summary>
   ''' <remarks>
   ''' Equipment is not added to project manager; 
   ''' it is assumed that the equipment is already in the existing project.
   ''' </remarks>
   ''' <param name="name">Equipment name.</param>
   ''' <param name="id">Equipment ID.</param>
   ''' <param name="type">Equipment type.</param>
   ''' <param name="division">Division of RAE Corporation.</param>
   ''' <returns>Constructed equipment.</returns>
   Shared Function CreateEquipment( name    As String,            id       As String,  _
                                    [type]  As EquipmentType,     division As Division, _
                                    manager As project_manager) As EquipmentItem
      Dim equip As EquipmentItem

      Select Case [type]
         Case EquipmentType.CondensingUnit
            equip = New CondensingUnitEquipmentItem(name, division, New item_id(id), manager)
         Case Business.EquipmentType.Chiller
            equip = New chiller_equipment(name, division, New item_id(id), manager)
         Case EquipmentType.UnitCooler
            equip = New unit_cooler(name, division, New item_id(id), manager)
         Case EquipmentType.FluidCooler
            equip = New FluidCoolerEquipmentItem(name, division, New item_id(id), manager)
         Case EquipmentType.Condenser
            equip = New CondenserEquipmentItem(name, division, New item_id(id), manager)
         Case EquipmentType.ProductCooler
            equip = New ProductCoolerEquipmentItem(name, division, New item_id(id), manager)
         Case EquipmentType.PumpPackage
            equip = New PumpEquipment(name, division, New item_id(id), manager)
         Case Else
            Throw New ArgumentException("Attempt to construct equipment failed. The equipment type, '" & [type].ToString & "', is not valid.")
      End Select

      Return equip
   End Function


   ''' <summary>Creates new equipment with a new project manager. Adds equipment to project.</summary>
   ''' <param name="name">Equipment name.</param>
   ''' <param name="username">Equipment ID.</param>
   ''' <param name="password">User's password.</param>
   ''' <param name="type">Equipment type.</param>
   ''' <param name="division">Division of RAE Corporation.</param>
   ''' <returns>Constructed equipment.</returns>
   Shared Function CreateEquipment(name As String, username As String, _
   password As String, [type] As EquipmentType, division As Division) As EquipmentItem
      Dim equipment As EquipmentItem
      Dim manager As project_manager

      ' constructs a temporary pro

      manager = New project_manager("Untitled", username, password)

      ' waits a second so that project and equipment will have unique IDs
            Threading.Thread.Sleep(1000)

      Select Case [type]
         Case EquipmentType.CondensingUnit
            equipment = New CondensingUnitEquipmentItem(name, division, username, password, manager)
         Case Business.EquipmentType.Chiller
            equipment = New chiller_equipment(name, division, username, password, manager)
         Case EquipmentType.UnitCooler
            equipment = New unit_cooler(name, division, username, password, manager)
         Case EquipmentType.FluidCooler
            equipment = New FluidCoolerEquipmentItem(name, division, username, password, manager)
         Case EquipmentType.Condenser
            equipment = New CondenserEquipmentItem(name, division, username, password, manager)
         Case EquipmentType.ProductCooler
            equipment = New ProductCoolerEquipmentItem(name, division, username, password, manager)
         Case EquipmentType.PumpPackage
            equipment = New PumpEquipment(name, division, username, password, manager)
         Case Else
            Throw New ArgumentException("Attempt to construct equipment failed. The equipment type, '" & [type].ToString & "', is not valid.")
      End Select
      
      Return equipment
   End Function

End Class

End Namespace