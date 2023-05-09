Imports System
Imports Rae.RaeSolutions.DataAccess.Projects
Imports CNull = Rae.ConvertNull

Namespace Rae.RaeSolutions.Business.Entities

''' <summary>Fluid cooler equipment item.</summary>
Public Class FluidCoolerEquipmentItem
   Inherits EquipmentItem
   Implements ICopyable(Of FluidCoolerEquipmentItem)
   Implements ICloneable(Of FluidCoolerEquipmentItem)
   Implements IEquatable(Of FluidCoolerEquipmentItem)


   ''' <summary>Constructs equipment with a new ID.</summary>
   Sub New(name As String, division As Division, _
   author As String, password As String, parent As project_manager)
      MyBase.New(name, division, EquipmentType.FluidCooler, author, password, parent)
      FluidCoolerEquipmentItemDa.GetRatingEquipment(Me)
   End Sub

   ''' <summary>Constructs equipment with existing ID.</summary>
   Sub New(name As String, division As Division, _
   id As item_id, parent As project_manager)
      MyBase.New(name, division, EquipmentType.FluidCooler, id, parent)
      FluidCoolerEquipmentItemDa.GetRatingEquipment(Me)
   End Sub
 
 
   Property Process As FluidCoolerProcessItem
      Get
         Return _process
      End Get
      Set(value As FluidCoolerProcessItem)
         _process = value
      End Set
   End Property

   Property Specs As FluidCoolerSpecifications
      Get
        Return _specs
      End Get
      Set(value As FluidCoolerSpecifications)
        _specs = value
      End Set
   End Property


   ''' <summary>Loads equipment from data source based on ID.
   ''' ID property must be set before calling this method.</summary>
   Overrides Sub Load()
      Copy(FluidCoolerEquipmentItemDa.Retrieve(id.Id, revision))
   End Sub

   ''' <summary>Saves equipment to data source.</summary>
   Overrides Sub Save()
      If EquipmentDa.Exists(id.Id, revision) = ExistenceStatus.Existent Then
         FluidCoolerEquipmentItemDa.Update(Me)
      Else
         FluidCoolerEquipmentItemDa.Create(Me)
      End If
      MyBase.onSaved()
   End Sub


   ''' <summary>Compares equality of fluid coolers.</summary>
   Shadows Function Equals(other As FluidCoolerEquipmentItem) As Boolean _
   Implements IEquatable(Of FluidCoolerEquipmentItem).Equals
      If Not is_equal_to(other) Then Return False

      If Specs.Equals(other.Specs) Then
         Return True
      Else
         Return False
      End If
   End Function
   
   ''' <summary>Clones fluid cooler.</summary>
   ''' <remarks>Use shadows so this will get called and not the unimplemented Clone method in the EquipmentItem base class.
   ''' </remarks>
   Shadows Function Clone() As FluidCoolerEquipmentItem _
   Implements ICloneable(Of FluidCoolerEquipmentItem).Clone
      Dim theClone As New FluidCoolerEquipmentItem(name, division, New item_id(id.ToString), _
         ProjectManager)

      theClone.copy_base(Me)
      theClone.Specs = Me.Specs.Clone

      Return theClone
   End Function
   
   ''' <summary>Copies another fluid cooler.</summary>
   Sub Copy(other As FluidCoolerEquipmentItem) _
   Implements ICopyable(Of FluidCoolerEquipmentItem).Copy
      copy_base(other)
      Specs = other.Specs.Clone
   End Sub

   
 
   Private _specs As FluidCoolerSpecifications
   Private _process As FluidCoolerProcessItem
   
   ''' <summary>Initializes objects.</summary>
   ''' <remarks>This overriding method is called by its parent class.</remarks>
   Protected Overrides Sub initialize()
      MyBase.initialize()
      Me._specs = New FluidCoolerSpecifications
   End Sub

End Class

End Namespace