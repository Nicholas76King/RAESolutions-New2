Imports System
Imports Rae.Core


Namespace Rae.RaeSolutions.Business.Entities

   ''' <summary>
   ''' Specifications for fluid cooler.
   ''' </summary>
   ''' <history by="Casey" finish="2006/05/14">
   ''' Created
   ''' </history>
   Public Class FluidCoolerSpecifications
      Implements ICloneable(Of FluidCoolerSpecifications)
      Implements IEquatable(Of FluidCoolerSpecifications)


#Region " Properties"

      Private m_Capacity As nullable_value(Of Double)
      ''' <summary>
      ''' Capacity
      ''' </summary>
      Public Property Capacity() As nullable_value(Of Double)
         Get
            Return Me.m_Capacity
         End Get
         Set(ByVal value As nullable_value(Of Double))
            Me.m_Capacity = value
         End Set
      End Property


      Private m_AmbientTemp As nullable_value(Of Double)
      ''' <summary>
      ''' AmbientTemp
      ''' </summary>
      Public Property AmbientTemp() As nullable_value(Of Double)
         Get
            Return Me.m_AmbientTemp
         End Get
         Set(ByVal value As nullable_value(Of Double))
            Me.m_AmbientTemp = value
         End Set
      End Property


      Private m_EnteringFluidTemp As nullable_value(Of Double)
      ''' <summary>
      ''' EnteringFluidTemp
      ''' </summary>
      Public Property EnteringFluidTemp() As nullable_value(Of Double)
         Get
            Return Me.m_EnteringFluidTemp
         End Get
         Set(ByVal value As nullable_value(Of Double))
            Me.m_EnteringFluidTemp = value
         End Set
      End Property


      Private m_LeavingFluidTemp As nullable_value(Of Double)
      ''' <summary>
      ''' LeavingFluidTemp
      ''' </summary>
      Public Property LeavingFluidTemp() As nullable_value(Of Double)
         Get
            Return Me.m_LeavingFluidTemp
         End Get
         Set(ByVal value As nullable_value(Of Double))
            Me.m_LeavingFluidTemp = value
         End Set
      End Property


      Private m_Fluid As String
      ''' <summary>
      ''' Fluid
      ''' </summary>
      Public Property Fluid() As String
         Get
            Return Me.m_Fluid
         End Get
         Set(ByVal value As String)
            Me.m_Fluid = value
         End Set
      End Property


      Private m_GlycolPercent As nullable_value(Of Double)
      ''' <summary>
      ''' GlycolPercent
      ''' </summary>
      Public Property GlycolPercent() As nullable_value(Of Double)
         Get
            Return Me.m_GlycolPercent
         End Get
         Set(ByVal value As nullable_value(Of Double))
            Me.m_GlycolPercent = value
         End Set
      End Property


      Private m_Flow As nullable_value(Of Double)
      ''' <summary>
      ''' Flow
      ''' </summary>
      Public Property Flow() As nullable_value(Of Double)
         Get
            Return Me.m_Flow
         End Get
         Set(ByVal value As nullable_value(Of Double))
            Me.m_Flow = value
         End Set
      End Property

#End Region

      ''' <summary>
      ''' Constructs
      ''' </summary>
      Public Sub New()
         Me.m_AmbientTemp = New nullable_value(Of Double)
         Me.m_Capacity = New nullable_value(Of Double)
         Me.m_EnteringFluidTemp = New nullable_value(Of Double)
         Me.m_Flow = New nullable_value(Of Double)
         Me.m_GlycolPercent = New nullable_value(Of Double)
         Me.m_LeavingFluidTemp = New nullable_value(Of Double)
      End Sub


      ''' <summary>
      ''' Clones fluid cooler specifications.
      ''' </summary>
      Public Shadows Function Clone() As FluidCoolerSpecifications _
      Implements ICloneable(Of FluidCoolerSpecifications).Clone
         Dim specs As New FluidCoolerSpecifications

         With specs
            .AmbientTemp = Me.AmbientTemp.clone()
            .Capacity = Me.Capacity.clone()
            .EnteringFluidTemp = Me.EnteringFluidTemp.clone()
            .Flow = Me.Flow.clone()
            .Fluid = Me.Fluid
            .GlycolPercent = Me.GlycolPercent.clone()
            .LeavingFluidTemp = Me.LeavingFluidTemp.clone()
         End With

         Return specs
      End Function


      ''' <summary>
      ''' Compares fluid coolers.
      ''' </summary>
      Public Shadows Function Equals(ByVal other As FluidCoolerSpecifications) As Boolean _
      Implements IEquatable(Of FluidCoolerSpecifications).Equals
         If other Is Nothing Then Return False

         If Me.AmbientTemp.equals(other.AmbientTemp) _
         AndAlso Me.Capacity.equals(other.Capacity) _
         AndAlso Me.EnteringFluidTemp.equals(other.EnteringFluidTemp) _
         AndAlso Me.Flow.equals(other.Flow) _
         AndAlso Me.Fluid = other.Fluid _
         AndAlso Me.GlycolPercent.equals(other.GlycolPercent) _
         AndAlso Me.LeavingFluidTemp.equals(other.LeavingFluidTemp) Then
            Return True
         Else
            Return False
         End If
      End Function

   End Class


End Namespace