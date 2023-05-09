Imports System

Namespace Rae.RaeSolutions.Business.Entities

Public Class chiller_specifications
   Implements ICloneable(Of chiller_specifications)
   Implements IEquatable(Of chiller_specifications)

   Private _capacity, _ambientTemp, _enteringFluidTemp, _leavingFluidTemp, _glycolPercent, _flow, _evaporatorPressureDrop As nullable_double
   Private _fluid, _refrigerant As String
   
#Region " Properties"

   Property AmbientTemp As nullable_double
      Get
         Return _ambientTemp
      End Get
      Set(value As nullable_double)
         _ambientTemp = value
      End Set
   End Property

   Property EnteringFluidTemp As nullable_double
      Get
         Return _enteringFluidTemp
      End Get
      Set(value As nullable_double)
         _enteringFluidTemp = value
      End Set
   End Property

   Property LeavingFluidTemp As nullable_double
      Get
         Return _leavingFluidTemp
      End Get
      Set(value As nullable_double)
         _leavingFluidTemp = value
      End Set
   End Property

   Property Fluid As String
      Get
         Return _fluid
      End Get
      Set(value As String)
         _fluid = value
      End Set
   End Property

   Property GlycolPercent As nullable_double
      Get
         Return _glycolPercent
      End Get
      Set(value As nullable_double)
         _glycolPercent = value
      End Set
   End Property

   Property Refrigerant As String
      Get
         Return _refrigerant
      End Get
      Set(value As String)
         _refrigerant = value
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

   Property EvaporatorPressureDrop As nullable_double
      Get
         Return _evaporatorPressureDrop
      End Get
      Set(value As nullable_double)
         _evaporatorPressureDrop = value
      End Set
   End Property
   
   ''' <summary>Total capacity from all circuits</summary>
   Property Capacity As nullable_double
      Get
         Return _capacity
      End Get
      Set(value As nullable_double)
         _capacity = value
      End Set
   End Property
   
   ReadOnly Property CapacityPerUnit As Double
      Get
         If NumCircuits = 0 Then
            Return 0
         Else
            Return Capacity.value_or_default / NumCircuits
         End If
      End Get
   End Property
   
   Public NumCircuits As Integer
   public unit_kw_per_ton as string 'from balance

#End Region

   Sub New()
      _ambientTemp            = New nullable_double()
      _capacity               = New nullable_double()
      _enteringFluidTemp      = New nullable_double()
      _evaporatorPressureDrop = New nullable_double()
      _flow                   = New nullable_double()
      _glycolPercent          = New nullable_double()
      _leavingFluidTemp       = New nullable_double()
   End Sub

   Shadows Function Clone() As chiller_specifications _
   Implements ICloneable(Of chiller_specifications).Clone
      Dim specs As New chiller_specifications

      With specs
         .AmbientTemp            = AmbientTemp.Clone()
         .Capacity               = Capacity.Clone()
         .EnteringFluidTemp      = EnteringFluidTemp.Clone()
         .EvaporatorPressureDrop = EvaporatorPressureDrop.Clone()
         .Flow                   = Flow.Clone()
         .Fluid                  = Fluid
         .GlycolPercent          = GlycolPercent.Clone()
         .LeavingFluidTemp       = LeavingFluidTemp.Clone()
         .Refrigerant            = Refrigerant
         .unit_kw_per_ton        = unit_kw_per_ton
      End With

      Return specs
   End Function

   Shadows Function Equals(other As chiller_specifications) As Boolean _
   Implements IEquatable(Of chiller_specifications).Equals
      If other Is Nothing Then Return False

      If AmbientTemp.equals(other.AmbientTemp) _
      AndAlso Capacity.equals(other.Capacity) _
      AndAlso EnteringFluidTemp.equals(other.EnteringFluidTemp) _
      AndAlso EvaporatorPressureDrop.equals(other.EvaporatorPressureDrop) _
      AndAlso Flow.equals(other.Flow) _
      AndAlso Fluid = other.Fluid _
      AndAlso GlycolPercent.equals(other.GlycolPercent) _
      AndAlso LeavingFluidTemp.equals(other.LeavingFluidTemp) _
      AndAlso Refrigerant = other.Refrigerant _
      AndAlso unit_kw_per_ton = other.unit_kw_per_ton Then
         Return True
      Else
         Return False
      End If
   End Function

End Class

End Namespace