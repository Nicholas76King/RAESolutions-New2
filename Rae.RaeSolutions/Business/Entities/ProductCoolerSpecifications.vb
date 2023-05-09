Imports System

Namespace Rae.RaeSolutions.Business.Entities

    ''' <summary>
    ''' Product cooler specifications.
    ''' </summary>
    ''' <history by="Casey" finish="2006/05/14">
    ''' Created
    ''' </history>
    Public Class ProductCoolerSpecifications
        Implements ICopyable(Of ProductCoolerSpecifications)
        Implements ICloneable(Of ProductCoolerSpecifications)
        Implements IEquatable(Of ProductCoolerSpecifications)


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


        Private m_EvaporatorTemp As nullable_value(Of Double)
        ''' <summary>
        ''' EvaporatorTemp
        ''' </summary>
        Public Property EvaporatorTemp() As nullable_value(Of Double)
            Get
                Return Me.m_EvaporatorTemp
            End Get
            Set(ByVal value As nullable_value(Of Double))
                Me.m_EvaporatorTemp = value
            End Set
        End Property


        Private m_BoxTemp As nullable_value(Of Double)
        ''' <summary>
        ''' BoxTemp
        ''' </summary>
        Public Property BoxTemp() As nullable_value(Of Double)
            Get
                Return Me.m_BoxTemp
            End Get
            Set(ByVal value As nullable_value(Of Double))
                Me.m_BoxTemp = value
            End Set
        End Property


        Private m_TempDifference As nullable_value(Of Double)
        ''' <summary>
        ''' TD
        ''' </summary>
        Public Property TempDifference() As nullable_value(Of Double)
            Get
                Return Me.m_TempDifference
            End Get
            Set(ByVal value As nullable_value(Of Double))
                Me.m_TempDifference = value
            End Set
        End Property


        Private m_CondensingTemp As nullable_value(Of Double)
        ''' <summary>
        ''' CondensingTemp
        ''' </summary>
        Public Property CondensingTemp() As nullable_value(Of Double)
            Get
                Return Me.m_CondensingTemp
            End Get
            Set(ByVal value As nullable_value(Of Double))
                Me.m_CondensingTemp = value
            End Set
        End Property


        Private m_LiquidTemp As nullable_value(Of Double)
        ''' <summary>
        ''' LiquidTemp
        ''' </summary>
        Public Property LiquidTemp() As nullable_value(Of Double)
            Get
                Return Me.m_LiquidTemp
            End Get
            Set(ByVal value As nullable_value(Of Double))
                Me.m_LiquidTemp = value
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


        Private m_CFM As nullable_value(Of Double)
        Public Property CFM() As nullable_value(Of Double)
            Get
                Return Me.m_CFM
            End Get
            Set(ByVal value As nullable_value(Of Double))
                Me.m_CFM = value
            End Set
        End Property


        Private m_ExternalSP As nullable_value(Of Double)
        Public Property ExternalSP() As nullable_value(Of Double)
            Get
                Return Me.m_ExternalSP
            End Get
            Set(ByVal value As nullable_value(Of Double))
                Me.m_ExternalSP = value
            End Set
        End Property


        Private m_FanMotorHP As String
        Public Property FanMotorHP() As String
            Get
                Return Me.m_FanMotorHP
            End Get
            Set(ByVal value As String)
                Me.m_FanMotorHP = value
            End Set
        End Property

        Private m_MotorLocation As String
        Public Property MotorLocation() As String
            Get
                Return Me.m_MotorLocation
            End Get
            Set(ByVal value As String)
                Me.m_MotorLocation = value
            End Set
        End Property

        Private m_Hand As String
        Public Property Hand() As String
            Get
                Return Me.m_Hand
            End Get
            Set(ByVal value As String)
                Me.m_Hand = value
            End Set
        End Property

        Private m_FanMotorType As String
        Public Property FanMotorType() As String
            Get
                Return Me.m_FanMotorType
            End Get
            Set(ByVal value As String)
                Me.m_FanMotorType = value
            End Set
        End Property

        Private m_BlowerDCPosition As String
        Public Property BlowerDCPosition() As String
            Get
                Return Me.m_BlowerDCPosition
            End Get
            Set(ByVal value As String)
                Me.m_BlowerDCPosition = value
            End Set
        End Property


#End Region


#Region " Public methods"

        ''' <summary>
        ''' Constructs
        ''' </summary>
        Public Sub New()
            Me.m_BoxTemp = New nullable_value(Of Double)
            Me.m_Capacity = New nullable_value(Of Double)
            Me.m_CondensingTemp = New nullable_value(Of Double)
            Me.m_EvaporatorTemp = New nullable_value(Of Double)
            Me.m_LiquidTemp = New nullable_value(Of Double)
            Me.m_TempDifference = New nullable_value(Of Double)

            Me.m_CFM = New nullable_value(Of Double)
            Me.m_ExternalSP = New nullable_value(Of Double)

        End Sub


        ''' <summary>
        ''' Copies another product cooler.
        ''' </summary>
        ''' <param name="other"></param>
        ''' <remarks></remarks>
        Public Sub Copy(ByVal other As ProductCoolerSpecifications) _
        Implements ICopyable(Of ProductCoolerSpecifications).Copy
            Me.BoxTemp = other.BoxTemp.clone
            Me.Capacity = other.Capacity.clone
            Me.CondensingTemp = other.CondensingTemp.clone()
            Me.EvaporatorTemp = other.EvaporatorTemp.clone()
            Me.LiquidTemp = other.LiquidTemp.clone()
            Me.Refrigerant = other.Refrigerant
            Me.TempDifference = other.TempDifference.clone()

            Me.CFM = other.CFM.clone
            Me.ExternalSP = other.ExternalSP.clone
            Me.FanMotorHP = other.FanMotorHP
            Me.FanMotorType = other.FanMotorType
            Me.Hand = other.Hand
            Me.MotorLocation = other.MotorLocation
            Me.BlowerDCPosition = other.BlowerDCPosition


        End Sub


        ''' <summary>
        ''' Clones this product cooler.
        ''' </summary>
        ''' <returns>
        ''' Clone of product cooler.
        ''' </returns>
        Public Function Clone() As ProductCoolerSpecifications _
        Implements ICloneable(Of ProductCoolerSpecifications).Clone
            Dim other As New ProductCoolerSpecifications

            other.BoxTemp = Me.BoxTemp.clone()
            other.Capacity = Me.Capacity.clone
            other.CondensingTemp = Me.CondensingTemp.clone()
            other.EvaporatorTemp = Me.EvaporatorTemp.clone()
            other.LiquidTemp = Me.LiquidTemp.clone()
            other.Refrigerant = Me.Refrigerant
            other.TempDifference = Me.TempDifference.clone()


            other.CFM = Me.CFM.clone
            other.ExternalSP = Me.ExternalSP.clone
            other.FanMotorHP = Me.FanMotorHP
            other.FanMotorType = Me.FanMotorType
            other.Hand = Me.Hand
            other.MotorLocation = Me.MotorLocation
            other.BlowerDCPosition = Me.BlowerDCPosition




            Return other
        End Function


        ''' <summary>
        ''' Compares product coolers.
        ''' </summary>
        ''' <param name="other"></param>
        ''' <returns></returns>
        Public Shadows Function Equals(ByVal other As ProductCoolerSpecifications) As Boolean _
        Implements IEquatable(Of ProductCoolerSpecifications).Equals
            If Me.BoxTemp.equals(other.BoxTemp) _
            AndAlso Me.Capacity.equals(other.Capacity) _
            AndAlso Me.CondensingTemp.equals(other.CondensingTemp) _
            AndAlso Me.EvaporatorTemp.equals(other.EvaporatorTemp) _
            AndAlso Me.LiquidTemp.equals(other.LiquidTemp) _
            AndAlso Me.Refrigerant = other.Refrigerant _
            AndAlso Me.TempDifference.equals(other.TempDifference) _
            AndAlso Me.CFM.equals(other.CFM) _
            AndAlso Me.ExternalSP.equals(other.ExternalSP) _
            AndAlso Me.FanMotorHP = other.FanMotorHP _
            AndAlso Me.FanMotorType = other.FanMotorType _
            AndAlso Me.Hand = other.Hand _
            AndAlso Me.MotorLocation = other.MotorLocation _
            AndAlso Me.BlowerDCPosition = other.BlowerDCPosition Then


                Return True
            Else
                Return False
            End If
        End Function

#End Region

    End Class

End Namespace