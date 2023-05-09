Imports System
Imports Rae.RaeSolutions.DataAccess.Projects
Imports CNull = Rae.ConvertNull

Namespace Rae.RaeSolutions.Business.Entities

''' <summary>Condenser equipment.</summary>
Public Class CondenserEquipmentItem
   Inherits EquipmentItem
   Implements ICopyable(Of CondenserEquipmentItem)
   Implements ICloneable(Of CondenserEquipmentItem)
   Implements IEquatable(Of CondenserEquipmentItem)


   Property Specs() As CondenserSpecifications
      Get
         Return _specs
      End Get
      Set(ByVal value As CondenserSpecifications)
         Me._specs = value
      End Set
   End Property


   ''' <summary>Constructs equipment with new ID.</summary>
   Sub New(name As String, division As Division, _
   author As String, password As String, parent As project_manager)
      MyBase.New(name, division, EquipmentType.Condenser, author, password, parent)
   End Sub

   ''' <summary>Constructs equipment with existing ID.</summary>
   Sub New(name As String, division As Division, _
   id As item_id, parent As project_manager)
      MyBase.New(name, division, EquipmentType.Condenser, id, parent)
   End Sub

   ''' <summary>Creates condenser equipment from condenser process.</summary>
   ''' <param name="condenserProcess">Condenser process to create equipment from.</param>
   Sub New(condenserProcess As CondenserProcessItem, equipmentName As String)
      MyBase.New(equipmentName, _
         condenserProcess.Division, _
         EquipmentType.Condenser, _
         New item_id(condenserProcess.id.Username, condenserProcess.id.Password), _
         condenserProcess.ProjectManager)

      ' sets common properties
      series = condenserProcess.Series
      model_without_series = condenserProcess.Model.Substring(condenserProcess.Series.Length)
      If Me.model_without_series.StartsWith("-") Then
         Me.model_without_series = Me.model_without_series.Substring(1)
      End If
      custom_model = condenserProcess.Model

      Specs.AmbientTemp.value = condenserProcess.AmbientTemp
      Specs.Refrigerant = condenserProcess.Refrigerant.Replace("-", "")
      Specs.SubCooling = condenserProcess.SubCooling
      Specs.TempDifference.value = condenserProcess.TD
      common_specs.Altitude.value = condenserProcess.Altitude

      ' associate equipment w/ process
      Me.processes.Add(condenserProcess)

      ProcessEquipDA.Create(condenserProcess.id.ToString, Me.id.ToString)
   End Sub


   ''' <summary>Loads this equipment from data source based on ID.
   ''' ID must be set before calling this method.</summary>
   Overrides Sub Load()
      Dim condenser = CondenserEquipmentItemDa.Retrieve(Me.id.Id, Me.revision)
      Me.Copy(condenser)
   End Sub

   ''' <summary>Saves equipment to data source.</summary>
   Overrides Sub Save()
      If EquipmentDa.Exists(Me.id.Id, Me.revision) = ExistenceStatus.Existent Then
         CondenserEquipmentItemDa.Update(Me)
      Else
         CondenserEquipmentItemDa.Create(Me)
      End If
      MyBase.onSaved()
   End Sub


   ''' <summary>True if equipment is equal; else false.</summary>
   ''' <param name="other">Other equipment to compare.</param>
   Shadows Function Equals(other As CondenserEquipmentItem) As Boolean _
   Implements IEquatable(Of CondenserEquipmentItem).Equals
      If Not is_equal_to(other) Then Return False
      
      If Specs.Equals(other.Specs) Then
         Return True
      Else
         Return False
      End If
   End Function

   ''' <summary>Returns a clone of this equipment.</summary>
   Shadows Function Clone() As CondenserEquipmentItem _
   Implements ICloneable(Of CondenserEquipmentItem).Clone
      Dim condenser As New CondenserEquipmentItem(Me.name, division, New item_id(Me.id.ToString), _
         Me.ProjectManager)

      condenser.copy_base(Me)
      condenser.Specs = Me.Specs.Clone()

      Return condenser
   End Function

   ''' <summary>Copies another equipment item's data into this equipment.</summary>
   ''' <param name="other">Equipment to copy.</param>
   Sub Copy(other As CondenserEquipmentItem) _
   Implements ICopyable(Of CondenserEquipmentItem).Copy
      copy_base(other)
      Specs = other.Specs.Clone
   End Sub
   
   
   Private _specs As CondenserSpecifications

   Private processes As New ProcessItemList
   
   ''' <summary>This overriding method is called by its parent class.</summary>
   Protected Overrides Sub initialize()
      MyBase.initialize()
      Me._specs = New CondenserSpecifications
   End Sub


End Class

End Namespace
