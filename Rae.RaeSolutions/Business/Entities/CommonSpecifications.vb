Option Strict On
Option Explicit On

Imports System

Namespace Rae.RaeSolutions.Business.Entities

    ''' <summary>
    ''' Contains specification fields that are common to all equipment
    ''' </summary>
    ''' <history by="Casey Joyce" finish="2006/05/02">
    ''' Modify: Change Double types to NullableValue(Of Double) to retrieve nulls from db
    ''' </history>
    <Serializable()> _
    Public Class CommonSpecifications
        Implements IEquatable(Of CommonSpecifications)
        Implements ICloneable(Of CommonSpecifications)


#Region " Properties"

        Private m_length As nullable_value(Of Double)
        ''' <summary>
        ''' Length of equipment in inches
        ''' </summary>
        Public Property Length() As nullable_value(Of Double)
            Get
                Return Me.m_length
            End Get
            Set(ByVal value As nullable_value(Of Double))
                Me.m_length = value
            End Set
        End Property

        Private m_width As nullable_value(Of Double)
        ''' <summary>
        ''' Width of equipment in inches
        ''' </summary>
        Public Property Width() As nullable_value(Of Double)
            Get
                Return Me.m_width
            End Get
            Set(ByVal value As nullable_value(Of Double))
                Me.m_width = value
            End Set
        End Property

        Private m_height As nullable_value(Of Double)
        ''' <summary>
        ''' Height of equipment in inches
        ''' </summary>
        Public Property Height() As nullable_value(Of Double)
            Get
                Return Me.m_height
            End Get
            Set(ByVal value As nullable_value(Of Double))
                Me.m_height = value
            End Set
        End Property

        Private m_shippingWeight As nullable_value(Of Double)
        ''' <summary>
        ''' Total weight of equipment and everything that is shipped with it
        ''' </summary>
        Public Property ShippingWeight() As nullable_value(Of Double)
            Get
                Return Me.m_shippingWeight
            End Get
            Set(ByVal value As nullable_value(Of Double))
                Me.m_shippingWeight = value
            End Set
        End Property

        Private m_operatingWeight As nullable_value(Of Double)
        ''' <summary>
        ''' Weight of equipment when it is operating
        ''' </summary>
        Public Property OperatingWeight() As nullable_value(Of Double)
            Get
                Return Me.m_operatingWeight
            End Get
            Set(ByVal value As nullable_value(Of Double))
                Me.m_operatingWeight = value
            End Set
        End Property

        Private m_unitVoltage As VoltageRating
        ''' <summary>
        ''' Unit voltage rating
        ''' </summary>
        Public Property UnitVoltage() As VoltageRating
            Get
                Return Me.m_unitVoltage
            End Get
            Set(ByVal value As VoltageRating)
                Me.m_unitVoltage = value
            End Set
        End Property

        Private m_controlVoltage As VoltageRating
        ''' <summary>
        ''' Control voltage rating
        ''' </summary>
        Public Property ControlVoltage() As VoltageRating
            Get
                Return Me.m_controlVoltage
            End Get
            Set(ByVal value As VoltageRating)
                Me.m_controlVoltage = value
            End Set
        End Property

        Private m_mca As nullable_value(Of Double)
        ''' <summary>
        ''' MCA (Minimum Circuit Ampacity)
        ''' </summary>
        Public Property Mca() As nullable_value(Of Double)
            Get
                Return Me.m_mca
            End Get
            Set(ByVal value As nullable_value(Of Double))
                Me.m_mca = value
            End Set
        End Property

        Private m_rla As nullable_value(Of Double)
        ''' <summary>
        ''' RLA (Run Load Amperes)
        ''' </summary>
        Public Property Rla() As nullable_value(Of Double)
            Get
                Return Me.m_rla
            End Get
            Set(ByVal value As nullable_value(Of Double))
                Me.m_rla = value
            End Set
        End Property



        Private m_mop As nullable_value(Of Double)
        ''' <summary>
        ''' MOP (Max Fuze Size)
        ''' </summary>
        Public Property MOP() As nullable_value(Of Double)
            Get
                Return Me.m_mop
            End Get
            Set(ByVal value As nullable_value(Of Double))
                Me.m_mop = value
            End Set
        End Property


        Private m_powerFeeds As nullable_value(Of Double)
        ''' <summary>
        ''' circuitFeeds
        ''' </summary>
        Public Property powerFeeds() As nullable_value(Of Double)
            Get
                Return Me.m_powerFeeds
            End Get
            Set(ByVal value As nullable_value(Of Double))
                Me.m_powerFeeds = value
            End Set
        End Property

        Private m_Altitude As nullable_value(Of Double)
        ''' <summary>
        ''' Altitude in feet
        ''' </summary>
        Public Property Altitude() As nullable_value(Of Double)
            Get
                Return Me.m_Altitude
            End Get
            Set(ByVal value As nullable_value(Of Double))
                Me.m_Altitude = value
            End Set
        End Property

#End Region


        Public Sub New()
            Me.m_controlVoltage = New VoltageRating
            Me.m_unitVoltage = New VoltageRating

            Me.m_length = New nullable_value(Of Double)
            Me.m_width = New nullable_value(Of Double)
            Me.m_height = New nullable_value(Of Double)
            Me.m_shippingWeight = New nullable_value(Of Double)
            Me.m_operatingWeight = New nullable_value(Of Double)
            Me.m_mca = New nullable_value(Of Double)
            Me.m_rla = New nullable_value(Of Double)
            Me.m_Altitude = New nullable_value(Of Double)
            Me.m_mop = New nullable_value(Of Double)
            Me.m_powerFeeds = New nullable_value(Of Double)
        End Sub


        ''' <summary>
        ''' Indicates whether common specifications are equal
        ''' </summary>
        ''' <param name="other">Other common specifications to compare equality with</param>
        ''' <returns>
        ''' True if specifications are equal; false if they are NOT equal
        ''' </returns>
        ''' <remarks>
        ''' All properties must be equal for specifications to be equal.
        ''' </remarks>
        ''' <history by="Casey Joyce" finish="2006/05/02">
        ''' Modifiy for nullable types
        ''' </history>
        Public Overloads Function Equals(ByVal other As CommonSpecifications) As Boolean _
        Implements IEquatable(Of CommonSpecifications).Equals
            ' checks for null
            If other Is Nothing Then Return False
            ' checks equality
            If Me.m_length.ToString = other.m_length.ToString _
            AndAlso Me.m_width.ToString = other.m_width.ToString _
            AndAlso Me.m_height.ToString = other.m_height.ToString _
            AndAlso Me.m_shippingWeight.ToString = other.m_shippingWeight.ToString _
            AndAlso Me.m_operatingWeight.ToString = other.m_operatingWeight.ToString _
            AndAlso Me.m_mca.ToString = other.m_mca.ToString _
            AndAlso Me.m_rla.ToString = other.m_rla.ToString _
            AndAlso Me.m_Altitude.ToString = other.Altitude.ToString _
            AndAlso Me.m_unitVoltage.Equals(other.m_unitVoltage) _
            AndAlso Me.m_controlVoltage.Equals(other.m_controlVoltage) _
            AndAlso Me.m_mop.equals(other.m_mop) _
            AndAlso Me.m_powerFeeds.equals(other.m_powerFeeds) Then

                Return True
            Else
                Return False
            End If
        End Function


        ''' <summary>
        ''' Clones common specifications.
        ''' </summary>
        ''' <returns>
        ''' Clone of common specifications.
        ''' </returns>
        Public Function Clone() As CommonSpecifications _
        Implements ICloneable(Of CommonSpecifications).Clone
            Dim specs As New CommonSpecifications

            With specs
                .Altitude = Me.Altitude.clone()
                .ControlVoltage = Me.ControlVoltage.Clone()
                .Height = Me.Height.clone()
                .Length = Me.Length.clone()
                .Mca = Me.Mca.clone()
                .OperatingWeight = Me.OperatingWeight.clone()
                .Rla = Me.Rla.clone()
                .ShippingWeight = Me.ShippingWeight.clone()
                .UnitVoltage = Me.UnitVoltage.Clone()
                .Width = Me.Width.clone()
                .MOP = Me.MOP.clone()
                .powerFeeds = Me.powerFeeds.clone
            End With

            Return specs
        End Function

    End Class
End Namespace