Namespace Rae.RaeSolutions.Business.Entities

''' <summary>Equipment option</summary>
''' <remarks>Inherit from data access object to prevent having to copy business logic (value interpretations).</remarks>
Public Class EquipmentOption
   Inherits Rae.DataAccess.EquipmentOptions.Option
   Implements ICloneable(Of EquipmentOption)
   Implements System.IEquatable(Of EquipmentOption)

#Region " Properties"

   ''' <summary>Identifier that is unique to a selected option in project. 
   ''' ID for Options table.</summary>
   Property Id As Integer
      Get
         Return _id
      End Get
      Set(value As Integer)
         _id = value
      End Set
   End Property

   ''' <summary>True if option is selected to be an option with for equipment.</summary>
   Property Selected As Boolean
      Get
         Return _selected
      End Get
      Set(value As Boolean)
         _selected = value
      End Set
   End Property

   ''' <summary>True if state of selected is not editable.</summary>
   Property IsSelectedReadOnly As Boolean
      Get
         Return _isSelectedReadOnly
      End Get
      Set(value As Boolean)
         _isSelectedReadOnly = False
      End Set
   End Property

   ''' <summary>Equipment item</summary>
   Shadows Property Equipment As EquipmentItem
      Get
         Return _equipment
      End Get
      Set(value As EquipmentItem)
         _equipment = value
      End Set
   End Property

   ''' <summary>Revision number</summary>
   Property Revision As Single
      Get
         Return _revision
      End Get
      Set(value As Single)
         _revision = value
      End Set
   End Property

#End Region


   ''' <summary>Clones equipment option.</summary>
   Function Clone() As EquipmentOption _
   Implements ICloneable(Of EquipmentOption).Clone
      Dim op As New EquipmentOption

      ' other properties should be set automatically while these are being set
      op.Id = Me.Id
      op.Category = Me.Category
      op.Code = Me.Code
      op.Description = Me.Description
      op.Equipment = Me.Equipment
      op.MasterId = Me.MasterId
      op.Price = Me.Price
      op.PricingId = Me.PricingId
      op.Quantity = Me.Quantity
      op.Selected = Me.Selected
      op.Voltage = Me.Voltage
      op.Revision = Me.Revision
      op.Per = Per

      Return op
   End Function


   ''' <summary>Compares options' equality.</summary>
   ''' <param name="optionToCompare">Option to compare this option with.</param>
   ''' <returns>True if options are equal; else false</returns>
   Overloads Function Equals(other As EquipmentOption) As Boolean _
   Implements System.IEquatable(Of EquipmentOption).Equals
      If PricingId = other.PricingId _
      AndAlso MasterId = other.MasterId _
      AndAlso Code = other.Code _
      AndAlso Price = other.Price _
      AndAlso Description = other.Description _
      AndAlso IsVoltageDependent = other.IsVoltageDependent _
      AndAlso Voltage = other.Voltage _
      AndAlso Quantity = other.Quantity _
      AndAlso Revision = other.Revision _
      AndAlso Per = other.Per Then
         'AndAlso Me.Equipment.Equipment.Series = optionToCompare.Equipment.Equipment.Series _
         'AndAlso Me.Equipment.Equipment.Model = optionToCompare.Equipment.Equipment.Model Then
         Return True
      Else
         Return False
      End If
   End Function


   ''' <summary>Loads and interprets equipment option</summary>
   ''' <param name="dbOption">Option to load</param>
   Overloads Sub Import(dbOption As Rae.DataAccess.EquipmentOptions.Option)
      ' Id hasn't been set yet. Id is not created until option is saved.
      PricingId = dbOption.PricingId
      MasterId = dbOption.MasterId
      Code = dbOption.Code
      Description = dbOption.Description
      Voltage = dbOption.Voltage
      Price = dbOption.Price
      Quantity = dbOption.Quantity
      Category = dbOption.Category
      Per = dbOption.Per

      ' set when added to list
      'Me.Equipment.Equipment.Series = dbOption.Equipment.Series
      'Me.Equipment.Equipment.Model = dbOption.Equipment.Model

      If dbOption.IsStandard Then
         Me.Selected = True
         Me.IsSelectedReadOnly = True
      Else
         Me.Selected = False
         Me.IsSelectedReadOnly = False
      End If
   End Sub
   
   
   Private _id As Integer
   Private _selected, _isSelectedReadOnly As Boolean
   Private _equipment As EquipmentItem
   Private _revision As Single


End Class

End Namespace
