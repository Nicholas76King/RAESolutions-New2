Imports System


Namespace Rae.RaeSolutions.Business.Entities

  Public Class CondenserSpecifications
    Implements ICloneable(Of CondenserSpecifications)
    Implements IEquatable(Of CondenserSpecifications)


#Region " Properties"

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


    Private m_Refrigerant As String
    ''' <summary>
    ''' Refrigerant
    ''' </summary>
    Public Property Refrigerant() As String
      Get
        Return Me.m_Refrigerant
      End Get
      Set(ByVal value As String)
        Me.m_Refrigerant = value
      End Set
    End Property


    Private m_TotalHeatRejection1 As nullable_value(Of Double)
    ''' <summary>
    ''' Total Heat Rejection in circuit 1
    ''' </summary>
    Public Property TotalHeatRejection1() As nullable_value(Of Double)
      Get
        Return Me.m_TotalHeatRejection1
      End Get
      Set(ByVal value As nullable_value(Of Double))
        Me.m_TotalHeatRejection1 = value
      End Set
    End Property


    Private m_TotalHeatRejection2 As nullable_value(Of Double)
    ''' <summary>
    ''' Total heat rejection in circuit 2
    ''' </summary>
    Public Property TotalHeatRejection2() As nullable_value(Of Double)
      Get
        Return Me.m_TotalHeatRejection2
      End Get
      Set(ByVal value As nullable_value(Of Double))
        Me.m_TotalHeatRejection2 = value
      End Set
    End Property


    Private m_TotalHeatRejection3 As nullable_value(Of Double)
    ''' <summary>
    ''' Total heat rejection in circuit 3
    ''' </summary>
    Public Property TotalHeatRejection3() As nullable_value(Of Double)
      Get
        Return Me.m_TotalHeatRejection3
      End Get
      Set(ByVal value As nullable_value(Of Double))
        Me.m_TotalHeatRejection3 = value
      End Set
    End Property


    Private m_TotalHeatRejection4 As nullable_value(Of Double)
    ''' <summary>
    ''' Total heat rejection in circuit 4
    ''' </summary>
    Public Property TotalHeatRejection4() As nullable_value(Of Double)
      Get
        Return Me.m_TotalHeatRejection4
      End Get
      Set(ByVal value As nullable_value(Of Double))
        Me.m_TotalHeatRejection4 = value
      End Set
    End Property


    Private m_TempDifference As nullable_value(Of Double)
    ''' <summary>
    ''' TempDifference
    ''' </summary>
    Public Property TempDifference() As nullable_value(Of Double)
      Get
        Return Me.m_TempDifference
      End Get
      Set(ByVal value As nullable_value(Of Double))
        Me.m_TempDifference = value
      End Set
    End Property


    Private m_Fpi As nullable_value(Of Integer)
    ''' <summary>
    ''' Fpi
    ''' </summary>
    Public Property Fpi() As nullable_value(Of Integer)
      Get
        Return Me.m_Fpi
      End Get
      Set(ByVal value As nullable_value(Of Integer))
        Me.m_Fpi = value
      End Set
    End Property


    Private m_SubCooling As Boolean
    ''' <summary>
    ''' SubCooling
    ''' </summary>
    Public Property SubCooling() As Boolean
      Get
        Return Me.m_SubCooling
      End Get
      Set(ByVal value As Boolean)
        Me.m_SubCooling = value
      End Set
    End Property

#End Region


    Public Sub New()
      Me.m_AmbientTemp = New nullable_value(Of Double)
      Me.m_Fpi = New nullable_value(Of Integer)
      Me.m_TotalHeatRejection1 = New nullable_value(Of Double)
      Me.m_TotalHeatRejection2 = New nullable_value(Of Double)
      Me.m_TotalHeatRejection3 = New nullable_value(Of Double)
      Me.m_TotalHeatRejection4 = New nullable_value(Of Double)
      Me.m_TempDifference = New nullable_value(Of Double)
    End Sub


    Public Shadows Function Clone() As CondenserSpecifications _
    Implements ICloneable(Of CondenserSpecifications).Clone
      Dim other As New CondenserSpecifications

      other.AmbientTemp = Me.AmbientTemp.clone()
      other.Fpi = Me.Fpi.clone()
      other.Refrigerant = Me.Refrigerant
      other.SubCooling = Me.SubCooling
      other.TempDifference = Me.TempDifference.clone()
      other.TotalHeatRejection1 = Me.TotalHeatRejection1.clone()
      other.TotalHeatRejection2 = Me.TotalHeatRejection2.clone()
      other.TotalHeatRejection3 = Me.TotalHeatRejection3.clone()
      other.TotalHeatRejection4 = Me.TotalHeatRejection4.clone()

      Return other
    End Function


    Public Shadows Function Equals(ByVal other As CondenserSpecifications) As Boolean _
    Implements System.IEquatable(Of CondenserSpecifications).Equals
      If other Is Nothing Then Return False

      If other.AmbientTemp.equals(Me.AmbientTemp) _
      AndAlso other.Fpi.equals(Me.Fpi) _
      AndAlso other.Refrigerant = Me.Refrigerant _
      AndAlso other.SubCooling = Me.SubCooling _
      AndAlso other.TempDifference.equals(Me.TempDifference) _
      AndAlso other.TotalHeatRejection1.equals(Me.TotalHeatRejection1) _
      AndAlso other.TotalHeatRejection2.equals(Me.TotalHeatRejection2) _
      AndAlso other.TotalHeatRejection3.equals(Me.TotalHeatRejection3) _
      AndAlso other.TotalHeatRejection4.equals(Me.TotalHeatRejection4) Then
        Return True
      Else
        Return False
      End If
    End Function

  End Class

End Namespace