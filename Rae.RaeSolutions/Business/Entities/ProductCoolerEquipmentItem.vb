Imports System
Imports Rae.RaeSolutions.DataAccess.Projects

Namespace Rae.RaeSolutions.Business.Entities

''' <summary>Product cooler equipment item.</summary>
Public Class ProductCoolerEquipmentItem
   Inherits EquipmentItem
   Implements ICloneable(Of ProductCoolerEquipmentItem)
   Implements ICopyable(Of ProductCoolerEquipmentItem)
   Implements IEquatable(Of ProductCoolerEquipmentItem)


   ''' <summary>Constructs product cooler equipment item with a new ID.</summary>
   Sub New(name As String, division As Division, _
   author As String, password As String, parent As project_manager)
      MyBase.New(name, division, EquipmentType.ProductCooler, author, password, parent)
   End Sub

   ''' <summary>Constructs condensing unit equipment item for an existing ID that hasn't been saved to a data source.</summary>
   Sub New(name As String, division As Division, _
   id As item_id, parent As project_manager)
      MyBase.New(name, division, EquipmentType.ProductCooler, id, parent)
   End Sub
   
   
   ''' <summary>Specifications for product coolers.</summary>
   Property Specs As ProductCoolerSpecifications
      Get
         Return _specs
      End Get
      Set(value As ProductCoolerSpecifications)
         _specs = value
      End Set
   End Property


   ''' <summary>Saves product cooler to data source.</summary>
   Overrides Sub Save()
      If EquipmentDa.Exists(Me.id.Id, Me.revision) = ExistenceStatus.Existent Then
         ProductCoolerEquipmentItemDa.Update(Me)
      Else
         ProductCoolerEquipmentItemDa.Create(Me)
      End If
      MyBase.onSaved()
   End Sub

   ''' <summary>Loads product cooler from data source.</summary>
   Overrides Sub Load()
      Copy(ProductCoolerEquipmentItemDa.Retrieve(id.Id, revision))
   End Sub


   ''' <summary>Compares product coolers.</summary>
   Shadows Function Equals(other As ProductCoolerEquipmentItem) As Boolean _
   Implements IEquatable(Of ProductCoolerEquipmentItem).Equals
      If Not is_equal_to(other) Then Return False
      
      If Specs.Equals(other.Specs) Then
         Return True
      Else
         Return False
      End If
   End Function
   
   Shadows Function Clone() As ProductCoolerEquipmentItem _
   Implements ICloneable(Of ProductCoolerEquipmentItem).Clone
      Dim theClone As New ProductCoolerEquipmentItem(name, division, New item_id(id.ToString), _
         ProjectManager)

      theClone.copy_base(Me)
      theClone.Specs = Me.Specs.Clone

      Return theClone
   End Function
   
   ''' <summary>Copies another product cooler's values into this product cooler.</summary>
   Sub Copy(other As ProductCoolerEquipmentItem) _
   Implements ICopyable(Of ProductCoolerEquipmentItem).Copy
      copy_base(other)
      Specs = other.Specs.Clone
   End Sub
   

   Private _specs As ProductCoolerSpecifications

   ''' <summary>Initializes objects.</summary>
   ''' <remarks>This overriding method is called by its base class.</remarks>
   Protected Overrides Sub initialize()
      MyBase.initialize()
      _specs = New ProductCoolerSpecifications
   End Sub

End Class

End Namespace