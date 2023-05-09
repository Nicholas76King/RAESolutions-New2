option strict off

Imports System
Imports rae
Imports Rae.RaeSolutions.DataAccess.Projects
Imports CNull = Rae.ConvertNull

Namespace Rae.RaeSolutions.Business.Entities

''' <summary>Condensing unit equipment item.</summary>
Public Class CondensingUnitEquipmentItem
   Inherits EquipmentItem
   Implements ICopyable(Of CondensingUnitEquipmentItem)
   Implements IEquatable(Of CondensingUnitEquipmentItem)
   Implements ICloneable(Of CondensingUnitEquipmentItem)


   ''' <summary>Constructs condensing unit equipment item with a new ID.</summary>
   Sub New(name As String, division As Division, _
   author As String, password As String, parent As project_manager)
      MyBase.New(name, division, EquipmentType.CondensingUnit, author, password, parent)
   End Sub

   ''' <summary>Constructs condensing unit for an existing ID that hasn't been saved to a data source.</summary>
   Sub New(name As String, division As Division, _
   id As item_id, parent As project_manager)
      MyBase.New(name, division, EquipmentType.CondensingUnit, id, parent)
   End Sub

   ''' <summary>Creates condensing unit from selection/rating.</summary>
   ''' <param name="process">Condensing unit process to create condensing unit equipment from</param>
   ''' <param name="equipmentName">Name of the new equipment</param>
   Sub New(process As CondensingUnitProcessItem, name As String)
      MyBase.New(name, _
         process.Division, _
         EquipmentType.CondensingUnit, _
         New item_id(process.id.Username, process.id.Password), _
         process.ProjectManager)

      set_model(process.series, process.model, process.division)
      
      Me.custom_model = process.CustomCondensingUnitModel
      Me.specs.suction.value = process.SuctionTemperature
      Me.specs.ambient.value = process.AmbientTemperature
            Me.specs.refrigerant = process.RatingRefrigerant.Trim(New Char() {"H"c, "L"c, "M"c})
      Me.common_specs.Altitude.value = process.Altitude

      ' associate equipment w/ process
      Me.processes.Add(process)


            If process.Series.ToUpper.StartsWith("20") Then
                ' changes made for tso cond units may want to apply come to cri
                Me.specs.capacity_1.set_to(process.Capacity)
            End If




      ProcessEquipDA.Create(process.id.ToString, id.ToString)
   End Sub

        Private Sub set_model(ByVal series As String, ByVal model As String, ByVal div As Division)

            Me.series = series

            If model.is_set Then
                Me.model_without_series = model.Substring(series.Length)


                If div = division.TSI Then
                    ' 20a0cd20 > 20a0cd
                    Me.series = model.Substring(0, 6)
                    ' 20a0cd20 > 20
                    Me.model_without_series = model.Substring(6)
                End If



            End If
        End Sub

   sub new(balance as cu_uc_balance_screen_model)
      mybase.new("Condensing Unit", balance.division, EquipmentType.CondensingUnit, 
                 new item_id(balance.id.username, balance.id.password),
                 balance.ProjectManager)

            Me.pricing.quantity = balance.condensing_unit_quantity   ' ericc


            set_model(balance.condensing_unit_series, balance.condensing_unit_model, balance.Division)
      'specs.suctionTemp.setValue(balance.suctionTemperature)
      'specs.Circuit1Capacity.SetValue(balance.condensing_unit_capacity)
      specs.refrigerant = balance.refrigerant
      common_specs.altitude.set_to(balance.altitude)
      specs.ambient.set_to(balance.ambient)

      specs.suction.set_to(balance.results.suction)
      specs.evaporating_temperature.set_to(balance.results.evaporating_temperature)
      specs.capacity_1.set_to(balance.results.capacity)
   end sub
   
   
   ''' <summary>Specifications specific to a condensing unit</summary>
   property specs as condensing_unit_specifications

   ''' <summary>Loads condensing unit from data source.</summary>
   Overrides Sub Load()
      Me.Copy(CondensingUnitEquipmentItemDA.Retrieve(id.Id, Me.revision))
   End Sub

   ''' <summary>Saves condensing unit to data source.</summary>
   Overrides Sub Save()
      If EquipmentDa.Exists(id.Id, revision) = ExistenceStatus.Existent Then
         CondensingUnitEquipmentItemDA.Update(Me)
      Else
         CondensingUnitEquipmentItemDA.Create(Me)
      End If
      MyBase.onSaved()
   End Sub

   ''' <summary>Compares equality of condensing units.</summary>
   Shadows Function Equals(other As CondensingUnitEquipmentItem) As Boolean _
   Implements IEquatable(Of CondensingUnitEquipmentItem).Equals
      If Not is_equal_to(other) Then Return False
      
      return specs.equals(other.specs)
   end function

   ''' <summary>Clones this condensing unit.</summary>
   Shadows Function Clone() As CondensingUnitEquipmentItem _
   Implements ICloneable(Of CondensingUnitEquipmentItem).Clone
      Dim theClone As New CondensingUnitEquipmentItem(name, division, _
         New item_id(id.ToString), ProjectManager)
         
      theClone.copy_base(Me)
      theClone.specs = Me.specs.Clone

      Return theClone
   End Function
   
   ''' <summary>Copies another condensing unit.</summary>
   ''' <param name="other">Condensing unit to copy.</param>
   Sub Copy(other As CondensingUnitEquipmentItem) _
   Implements ICopyable(Of CondensingUnitEquipmentItem).Copy
      copy_base(other)
      specs = other.specs.Clone
   End Sub

   Private processes As New ProcessItemList

   ''' <summary>Initializes objects that this class depends on</summary>
   ''' <remarks>This overriding method is called by its parent class.</remarks>
   Protected Overrides Sub initialize()
      MyBase.initialize()
      specs = new condensing_unit_specifications
   End Sub

End Class

End Namespace
