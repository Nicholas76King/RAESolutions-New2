Imports Rae.RaeSolutions.DataAccess.Projects
Imports Rae.Math.comparisons

Namespace Rae.RaeSolutions.Business.Entities

Public Class PumpEquipment
   Inherits EquipmentItem
   Implements ICloneable(Of PumpEquipment)
   Implements ICopyable(Of PumpEquipment)
   Implements IEquatable(Of PumpEquipment)
   
   Sub New(name As String, division As Division, _
           username As String, password As String, parent As project_manager)
      MyBase.New(name, division, EquipmentType.PumpPackage, username, password, parent)
   End Sub
   
   Sub New(name As String, division As Division, id As item_id, parent As project_manager)
      MyBase.New(name, division, EquipmentType.PumpPackage, id, parent)
   End Sub
   
   
   Property Manufacturer As String
   	Get
   		Return _manufacturer
   	End Get
   	Set(value As String)
   		_manufacturer = value
   		updateModel
   	End Set
   End Property
   
   Property System As PumpSystem
   	Get
   		Return _system
   	End Get
   	Set(value As PumpSystem)
   		_system = value
   		updateModel
   	End Set
   End Property
   
   Property Flow As nullable_double
      Get
         Return _flow
      End Get
      Set(value As nullable_double)
         _flow = value
      End Set
   End Property

   Property Head As nullable_double
      Get
         Return _head
      End Get
      Set(value As nullable_double)
         _head = value
      End Set
   End Property
   
   Property ChillerId As item_id
      Get
         Return _chillerId
      End Get
      Set(value As item_id)
         _chillerId = value
      End Set
   End Property
   
      
   Overrides Sub Load()
      Dim persistedPump = PumpEquipmentDa.Retrieve(id.Id, revision)
      Copy(persistedPump)
   End Sub
   
   Overrides Sub Save()
      If Me.exists_in_data_source = ExistenceStatus.Nonexistent Then
         PumpEquipmentDa.Create(Me)
      Else
         PumpEquipmentDa.Update(Me)
      End If
      onSaved
   End Sub
   
   Sub SaveIntegrated()
      If exists_in_data_source = ExistenceStatus.Nonexistent Then
         PumpEquipmentDa.Create(Me)
      Else
         PumpEquipmentDa.Update(Me)
      End If
   End Sub
   
   
   ''' <summary>Shadows keyword is required for reflection access</summary>
   Shadows Function Equals(other As PumpEquipment) As Boolean _
   Implements IEquatable(Of PumpEquipment).Equals
      If Not is_equal_to(other) Then Return False
      
      If Manufacturer = other.Manufacturer _
      AndAlso Flow.equals(other.Flow) _
      AndAlso Head.equals(other.Head) _
      AndAlso System = other.System Then
         If ChillerId Is Nothing Then
            Return other.ChillerId Is Nothing
         Else
            Return ChillerId.Equals(other.ChillerId)
         End If
      Else
         Return False
      End If
   End Function
   
   ''' <summary>Shadows keyword is required for reflection access</summary>
   Shadows Function Clone() As PumpEquipment _
   Implements ICloneable(Of PumpEquipment).Clone
      Dim theClone = New PumpEquipment(name, division, New item_id(Me.id.ToString), _
         ProjectManager)

      theClone.copy_base(Me)
      
      With theClone
         .Flow = Flow.Clone
         .Head = Head.Clone
         .Manufacturer = Manufacturer
         .System = System
         If ChillerId Is Nothing Then
            .ChillerId = Nothing
         Else
            .ChillerId = New item_id(ChillerId.Id)
         End If
      End With
      
      Return theClone
   End Function
   
   Sub Copy(other As PumpEquipment) _
   Implements ICopyable(Of PumpEquipment).Copy
      copy_base(other)
      
      Manufacturer = other.Manufacturer
      Flow = other.Flow.Clone
      Head = other.Head.Clone
      System = other.System
      If other.ChillerId Is Nothing Then
         ChillerId = Nothing
      Else
         ChillerId = New item_id(other.ChillerId.Id)
      End If
   End Sub
   
   
   
   Private _flow, _head As nullable_double
   Private _system As PumpSystem
   Private _manufacturer As String
   Private _chillerId As item_id

   Protected Overrides Sub initialize()
      MyBase.initialize()
      _flow = New nullable_double
      _head = New nullable_double
      
      ' set defaults
      Head = New nullable_double(50)
      Flow = New nullable_double(10)
      System = PumpSystem.Single
   End Sub
   
   Private Sub updateModel()
      Dim m = New PumpDbModel(Manufacturer, Flow.value_or_default, Head.value_or_default, System)
      series = m.Series
      model_without_series = m.Model
   End Sub
   
End Class

End Namespace