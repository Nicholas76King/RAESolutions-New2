Imports CondensingUnitProcessDa = rae.RaeSolutions.DataAccess.Projects.CondensingUnitProcessDA
Imports System.Collections.Generic

Namespace Rae.RaeSolutions.Business.Entities

    ''' <summary>Condensing unit process.</summary>
    <Serializable()> _
    Public Class CondensingUnitProcessItem
        Inherits ProcessItem

        Private equipment As EquipmentItemList

#Region " Properties"

        Public Enum eRunType
            UnitRating
            UnitSelection
        End Enum

        Enum CondensingUnitRatingReturnType
            condTotalBTUH
            condPerDegreeBTUH
            evapCapacity
            RatingOutputs
        End Enum

        Enum FanStringParseOutput
            Diameter
            HP
            RPM
        End Enum

        Private m_CondensingUnitSeries As String
        ''' <summary>Condensing unit series</summary>
        Property CondensingUnitSeries() As String
            Get
                Return Me.m_CondensingUnitSeries
            End Get
            Set(ByVal value As String)
                Me.m_CondensingUnitSeries = value
            End Set
        End Property

        Private m_Capacity As Double
        ''' <summary>Capacity</summary>
        Property Capacity() As Double
            Get
                Return Me.m_Capacity
            End Get
            Set(ByVal value As Double)
                Me.m_Capacity = value
            End Set
        End Property

        Private m_RuntimeAdjust As Boolean
        ''' <summary>
        ''' RuntimeAdjust
        ''' </summary>
        Property RuntimeAdjust() As Boolean
            Get
                Return Me.m_RuntimeAdjust
            End Get
            Set(ByVal value As Boolean)
                Me.m_RuntimeAdjust = value
            End Set
        End Property

        Private m_CondensingUnitsRequired As Double
        ''' <summary>
        ''' CondensingUnitsRequired
        ''' </summary>
        Property CondensingUnitsRequired() As Double
            Get
                Return Me.m_CondensingUnitsRequired
            End Get
            Set(ByVal value As Double)
                Me.m_CondensingUnitsRequired = value
            End Set
        End Property

        Private m_Runtime As Double
        ''' <summary>
        ''' Runtime
        ''' </summary>
        Property Runtime() As Double
            Get
                Return Me.m_Runtime
            End Get
            Set(ByVal value As Double)
                Me.m_Runtime = value
            End Set
        End Property

        Private m_AmbientTemperature As Double
        ''' <summary>
        ''' AmbientTemperature
        ''' </summary>
        Property AmbientTemperature() As Double
            Get
                Return Me.m_AmbientTemperature
            End Get
            Set(ByVal value As Double)
                Me.m_AmbientTemperature = value
            End Set
        End Property

        Private m_SuctionTemperature As Double
        ''' <summary>
        ''' SuctionTemperature
        ''' </summary>
        Property SuctionTemperature() As Double
            Get
                Return Me.m_SuctionTemperature
            End Get
            Set(ByVal value As Double)
                Me.m_SuctionTemperature = value
            End Set
        End Property

        Private m_Refrigerant As String
        ''' <summary>
        ''' Refrigrant
        ''' </summary>
        Property Refrigerant() As String
            Get
                Return Me.m_Refrigerant
            End Get
            Set(ByVal value As String)
                Me.m_Refrigerant = value
            End Set
        End Property

        Private m_Compressor As String
        ''' <summary>
        ''' Compressor
        ''' </summary>
        Property Compressor() As String
            Get
                Return Me.m_Compressor
            End Get
            Set(ByVal value As String)
                Me.m_Compressor = value
            End Set
        End Property

        Private m_CompressorPerUnit As Double
        ''' <summary>
        ''' CompressorPerUnit
        ''' </summary>
        Property CompressorPerUnit() As Double
            Get
                Return Me.m_CompressorPerUnit
            End Get
            Set(ByVal value As Double)
                Me.m_CompressorPerUnit = value
            End Set
        End Property

        Private m_CircuitsPerUnit As Double
        ''' <summary>
        ''' CircuitsPerUnit
        ''' </summary>
        Property CircuitsPerUnit() As Double
            Get
                Return Me.m_CircuitsPerUnit
            End Get
            Set(ByVal value As Double)
                Me.m_CircuitsPerUnit = value
            End Set
        End Property

        Private m_Altitude As Double
        ''' <summary>
        ''' Altitude
        ''' </summary>
        Property Altitude() As Double
            Get
                Return Me.m_Altitude
            End Get
            Set(ByVal value As Double)
                Me.m_Altitude = value
            End Set
        End Property

        Private m_RunType As CondensingUnitProcessItem.eRunType
        ''' <summary>
        ''' RunType
        ''' </summary>
        Property RunType() As CondensingUnitProcessItem.eRunType
            Get
                Return Me.m_RunType
            End Get
            Set(ByVal value As CondensingUnitProcessItem.eRunType)
                Me.m_RunType = value
            End Set
        End Property

        Private m_NoCondensingUnits As Boolean
        ''' <summary>
        ''' NoCondensingUnits
        ''' </summary>
        Property NoCondensingUnits() As Boolean
            Get
                Return Me.m_NoCondensingUnits
            End Get
            Set(ByVal value As Boolean)
                Me.m_NoCondensingUnits = value
            End Set
        End Property

        Private m_CondensingUnitModel As String
        ''' <summary>
        ''' CondensingUnitModel
        ''' </summary>
        Property CondensingUnitModel() As String
            Get
                Return Me.m_CondensingUnitModel
            End Get
            Set(ByVal value As String)
                Me.m_CondensingUnitModel = value
            End Set
        End Property

        Private m_CustomCondensingUnitModel As String
        ''' <summary>
        ''' CustomCondensingUnitModel
        ''' </summary>
        Property CustomCondensingUnitModel() As String
            Get
                Return Me.m_CustomCondensingUnitModel
            End Get
            Set(ByVal value As String)
                Me.m_CustomCondensingUnitModel = value
            End Set
        End Property

        Private m_RatingAmbient As Double
        ''' <summary>
        ''' RatingAmbient
        ''' </summary>
        Property RatingAmbient() As Double
            Get
                Return Me.m_RatingAmbient
            End Get
            Set(ByVal value As Double)
                Me.m_RatingAmbient = value
            End Set
        End Property

        Private m_RatingAmbientInterval As Double
        ''' <summary>
        ''' RatingAmbientInterval
        ''' </summary>
        Property RatingAmbientInterval() As Double
            Get
                Return Me.m_RatingAmbientInterval
            End Get
            Set(ByVal value As Double)
                Me.m_RatingAmbientInterval = value
            End Set
        End Property

        Private m_RatingAmbientStep As Double
        ''' <summary>
        ''' RatingAmbientStep
        ''' </summary>
        Property RatingAmbientStep() As Double
            Get
                Return Me.m_RatingAmbientStep
            End Get
            Set(ByVal value As Double)
                Me.m_RatingAmbientStep = value
            End Set
        End Property

        Private m_RatingSuction As Double
        ''' <summary>
        ''' RatingSuction
        ''' </summary>
        Property RatingSuction() As Double
            Get
                Return Me.m_RatingSuction
            End Get
            Set(ByVal value As Double)
                Me.m_RatingSuction = value
            End Set
        End Property

        Private m_RatingSuctionInterval As Double
        ''' <summary>
        ''' RatingSuctionInterval
        ''' </summary>
        Property RatingSuctionInterval() As Double
            Get
                Return Me.m_RatingSuctionInterval
            End Get
            Set(ByVal value As Double)
                Me.m_RatingSuctionInterval = value
            End Set
        End Property

        Private m_RatingSuctionStep As Double
        ''' <summary>
        ''' RatingSuctionStep
        ''' </summary>
        Property RatingSuctionStep() As Double
            Get
                Return Me.m_RatingSuctionStep
            End Get
            Set(ByVal value As Double)
                Me.m_RatingSuctionStep = value
            End Set
        End Property

        Private m_RatingRefrigerant As String
        ''' <summary>
        ''' RatingRefrigerant
        ''' </summary>
        Property RatingRefrigerant() As String
            Get
                Return Me.m_RatingRefrigerant
            End Get
            Set(ByVal value As String)
                Me.m_RatingRefrigerant = value
            End Set
        End Property

        Private m_RatingAltitude As Double
        ''' <summary>
        ''' RatingAltitude
        ''' </summary>
        Property RatingAltitude() As Double
            Get
                Return Me.m_RatingAltitude
            End Get
            Set(ByVal value As Double)
                Me.m_RatingAltitude = value
            End Set
        End Property

        Private m_RatingSubCooling As Double
        ''' <summary>
        ''' RatingSubCooling
        ''' </summary>
        Property RatingSubCooling() As Double
            Get
                Return Me.m_RatingSubCooling
            End Get
            Set(ByVal value As Double)
                Me.m_RatingSubCooling = value
            End Set
        End Property

        Private m_RatingCatalog As Boolean
        ''' <summary>
        ''' RatingCatalog
        ''' </summary>
        Property RatingCatalog() As Boolean
            Get
                Return Me.m_RatingCatalog
            End Get
            Set(ByVal value As Boolean)
                Me.m_RatingCatalog = value
            End Set
        End Property

        Private m_RatingHertz As Double
        ''' <summary>
        ''' RatingHertz
        ''' </summary>
        Property RatingHertz() As Double
            Get
                Return Me.m_RatingHertz
            End Get
            Set(ByVal value As Double)
                Me.m_RatingHertz = value
            End Set
        End Property

        Private m_RatingSafety As Boolean
        ''' <summary>
        ''' RatingSafety
        ''' </summary>
        Property RatingSafety() As Boolean
            Get
                Return Me.m_RatingSafety
            End Get
            Set(ByVal value As Boolean)
                Me.m_RatingSafety = value
            End Set
        End Property

        Private m_Compressor1 As String
        ''' <summary>
        ''' Compressor1
        ''' </summary>
        Property Compressor1() As String
            Get
                Return Me.m_Compressor1
            End Get
            Set(ByVal value As String)
                Me.m_Compressor1 = value
            End Set
        End Property

        Private m_CompressorQuantity1 As Double
        ''' <summary>
        ''' CompressorQuantity1
        ''' </summary>
        Property CompressorQuantity1() As Double
            Get
                Return Me.m_CompressorQuantity1
            End Get
            Set(ByVal value As Double)
                Me.m_CompressorQuantity1 = value
            End Set
        End Property

        Private m_Compressor2 As String
        ''' <summary>
        ''' Compressor2
        ''' </summary>
        Property Compressor2() As String
            Get
                Return Me.m_Compressor2
            End Get
            Set(ByVal value As String)
                Me.m_Compressor2 = value
            End Set
        End Property

        Private m_CompressorQuantity2 As Double
        ''' <summary>
        ''' CompressorQuantity2
        ''' </summary>
        Property CompressorQuantity2() As Double
            Get
                Return Me.m_CompressorQuantity2
            End Get
            Set(ByVal value As Double)
                Me.m_CompressorQuantity2 = value
            End Set
        End Property

        Private m_Compressor3 As String
        ''' <summary>
        ''' Compressor3
        ''' </summary>
        Property Compressor3() As String
            Get
                Return Me.m_Compressor3
            End Get
            Set(ByVal value As String)
                Me.m_Compressor3 = value
            End Set
        End Property

        Private m_CompressorQuantity3 As Double
        ''' <summary>
        ''' CompressorQuantity3
        ''' </summary>
        Property CompressorQuantity3() As Double
            Get
                Return Me.m_CompressorQuantity3
            End Get
            Set(ByVal value As Double)
                Me.m_CompressorQuantity3 = value
            End Set
        End Property

        Private m_Compressor4 As String
        ''' <summary>
        ''' Compressor4
        ''' </summary>
        Property Compressor4() As String
            Get
                Return Me.m_Compressor4
            End Get
            Set(ByVal value As String)
                Me.m_Compressor4 = value
            End Set
        End Property

        Private m_CompressorQuantity4 As Double
        ''' <summary>
        ''' CompressorQuantity4
        ''' </summary>
        Property CompressorQuantity4() As Double
            Get
                Return Me.m_CompressorQuantity4
            End Get
            Set(ByVal value As Double)
                Me.m_CompressorQuantity4 = value
            End Set
        End Property

        Private m_FinHeight1 As Double
        ''' <summary>
        ''' FinHeight1
        ''' </summary>
        Property FinHeight1() As Double
            Get
                Return Me.m_FinHeight1
            End Get
            Set(ByVal value As Double)
                Me.m_FinHeight1 = value
            End Set
        End Property

        Private m_CoilFinWidth1 As Double
        ''' <summary>
        ''' CoilFinWidth1
        ''' </summary>
        Property CoilFinWidth1() As Double
            Get
                Return Me.m_CoilFinWidth1
            End Get
            Set(ByVal value As Double)
                Me.m_CoilFinWidth1 = value
            End Set
        End Property

        Private m_FinHeight2 As Double
        ''' <summary>
        ''' FinHeight2
        ''' </summary>
        Property FinHeight2() As Double
            Get
                Return Me.m_FinHeight2
            End Get
            Set(ByVal value As Double)
                Me.m_FinHeight2 = value
            End Set
        End Property

        Private m_CoilFinWidth2 As Double
        ''' <summary>
        ''' CoilFinWidth2
        ''' </summary>
        Property CoilFinWidth2() As Double
            Get
                Return Me.m_CoilFinWidth2
            End Get
            Set(ByVal value As Double)
                Me.m_CoilFinWidth2 = value
            End Set
        End Property

        Private m_FinHeight3 As Double
        ''' <summary>
        ''' FinHeight3
        ''' </summary>
        Property FinHeight3() As Double
            Get
                Return Me.m_FinHeight3
            End Get
            Set(ByVal value As Double)
                Me.m_FinHeight3 = value
            End Set
        End Property

        Private m_CoilFinWidth3 As Double
        ''' <summary>
        ''' CoilFinWidth3
        ''' </summary>
        Property CoilFinWidth3() As Double
            Get
                Return Me.m_CoilFinWidth3
            End Get
            Set(ByVal value As Double)
                Me.m_CoilFinWidth3 = value
            End Set
        End Property

        Private m_FinHeight4 As Double
        ''' <summary>
        ''' FinHeight4
        ''' </summary>
        Property FinHeight4() As Double
            Get
                Return Me.m_FinHeight4
            End Get
            Set(ByVal value As Double)
                Me.m_FinHeight4 = value
            End Set
        End Property

        Private m_CoilFinWidth4 As Double
        ''' <summary>
        ''' CoilFinWidth4
        ''' </summary>
        Property CoilFinWidth4() As Double
            Get
                Return Me.m_CoilFinWidth4
            End Get
            Set(ByVal value As Double)
                Me.m_CoilFinWidth4 = value
            End Set
        End Property

        Private m_CoilRows1 As Double
        ''' <summary>
        ''' CoilRows1
        ''' </summary>
        Property CoilRows1() As Double
            Get
                Return Me.m_CoilRows1
            End Get
            Set(ByVal value As Double)
                Me.m_CoilRows1 = value
            End Set
        End Property

        Private m_CoilRows2 As Double
        ''' <summary>
        ''' CoilRows2
        ''' </summary>
        Property CoilRows2() As Double
            Get
                Return Me.m_CoilRows2
            End Get
            Set(ByVal value As Double)
                Me.m_CoilRows2 = value
            End Set
        End Property

        Private m_CoilRows3 As Double
        ''' <summary>
        ''' CoilRows3
        ''' </summary>
        Property CoilRows3() As Double
            Get
                Return Me.m_CoilRows3
            End Get
            Set(ByVal value As Double)
                Me.m_CoilRows3 = value
            End Set
        End Property

        Private m_CoilRows4 As Double
        ''' <summary>
        ''' CoilRows4
        ''' </summary>
        Property CoilRows4() As Double
            Get
                Return Me.m_CoilRows4
            End Get
            Set(ByVal value As Double)
                Me.m_CoilRows4 = value
            End Set
        End Property







        Private m_CoilSubCoolingPercentage1 As Double
        ''' <summary>
        ''' CoilSubCoolingPercentage1
        ''' </summary>
        Property CoilSubCoolingPercentage1() As Double
            Get
                Return Me.m_CoilSubCoolingPercentage1
            End Get
            Set(ByVal value As Double)
                Me.m_CoilSubCoolingPercentage1 = value
            End Set
        End Property

        Private m_CoilSubCoolingPercentage2 As Double
        ''' <summary>
        ''' CoilSubCoolingPercentage2
        ''' </summary>
        Property CoilSubCoolingPercentage2() As Double
            Get
                Return Me.m_CoilSubCoolingPercentage2
            End Get
            Set(ByVal value As Double)
                Me.m_CoilSubCoolingPercentage2 = value
            End Set
        End Property

        Private m_CoilSubCoolingPercentage3 As Double
        ''' <summary>
        ''' CoilSubCoolingPercentage3
        ''' </summary>
        Property CoilSubCoolingPercentage3() As Double
            Get
                Return Me.m_CoilSubCoolingPercentage3
            End Get
            Set(ByVal value As Double)
                Me.m_CoilSubCoolingPercentage3 = value
            End Set
        End Property

        Private m_CoilSubCoolingPercentage4 As Double
        ''' <summary>
        ''' CoilSubCoolingPercentage4
        ''' </summary>
        Property CoilSubCoolingPercentage4() As Double
            Get
                Return Me.m_CoilSubCoolingPercentage4
            End Get
            Set(ByVal value As Double)
                Me.m_CoilSubCoolingPercentage4 = value
            End Set
        End Property

        Private m_FinsPerInch1 As Double
        ''' <summary>
        ''' FinsPerInch1
        ''' </summary>
        Property FinsPerInch1() As Double
            Get
                Return Me.m_FinsPerInch1
            End Get
            Set(ByVal value As Double)
                Me.m_FinsPerInch1 = value
            End Set
        End Property

        Private m_FinsPerInch2 As Double
        ''' <summary>
        ''' FinsPerInch2
        ''' </summary>
        Property FinsPerInch2() As Double
            Get
                Return Me.m_FinsPerInch2
            End Get
            Set(ByVal value As Double)
                Me.m_FinsPerInch2 = value
            End Set
        End Property

        Private m_FinsPerInch3 As Double
        ''' <summary>
        ''' FinsPerInch3
        ''' </summary>
        Property FinsPerInch3() As Double
            Get
                Return Me.m_FinsPerInch3
            End Get
            Set(ByVal value As Double)
                Me.m_FinsPerInch3 = value
            End Set
        End Property

        Private m_FinsPerInch4 As Double
        ''' <summary>
        ''' FinsPerInch4
        ''' </summary>
        Property FinsPerInch4() As Double
            Get
                Return Me.m_FinsPerInch4
            End Get
            Set(ByVal value As Double)
                Me.m_FinsPerInch4 = value
            End Set
        End Property

        Private m_FanDia1 As String
        ''' <summary>
        ''' FanDia1
        ''' </summary>
        Property FanDia1() As String
            Get
                Return Me.m_FanDia1
            End Get
            Set(ByVal value As String)
                Me.m_FanDia1 = value
            End Set
        End Property

        Private m_FanDia2 As String
        ''' <summary>
        ''' FanDia2
        ''' </summary>
        Property FanDia2() As String
            Get
                Return Me.m_FanDia2
            End Get
            Set(ByVal value As String)
                Me.m_FanDia2 = value
            End Set
        End Property

        Private m_FanDia3 As String
        ''' <summary>
        ''' FanDia3
        ''' </summary>
        Property FanDia3() As String
            Get
                Return Me.m_FanDia3
            End Get
            Set(ByVal value As String)
                Me.m_FanDia3 = value
            End Set
        End Property

        Private m_FanDia4 As String
        ''' <summary>
        ''' FanDia4
        ''' </summary>
        Property FanDia4() As String
            Get
                Return Me.m_FanDia4
            End Get
            Set(ByVal value As String)
                Me.m_FanDia4 = value
            End Set
        End Property

        Private m_FanQuantity1 As Double
        ''' <summary>
        ''' FanQuantity1
        ''' </summary>
        Property FanQuantity1() As Double
            Get
                Return Me.m_FanQuantity1
            End Get
            Set(ByVal value As Double)
                Me.m_FanQuantity1 = value
            End Set
        End Property

        Private m_FanQuantity2 As Double
        ''' <summary>
        ''' FanQuantity2
        ''' </summary>
        Property FanQuantity2() As Double
            Get
                Return Me.m_FanQuantity2
            End Get
            Set(ByVal value As Double)
                Me.m_FanQuantity2 = value
            End Set
        End Property

        Private m_FanQuantity3 As Double
        ''' <summary>
        ''' FanQuantity3
        ''' </summary>
        Property FanQuantity3() As Double
            Get
                Return Me.m_FanQuantity3
            End Get
            Set(ByVal value As Double)
                Me.m_FanQuantity3 = value
            End Set
        End Property

        Private m_FanQuantity4 As Double
        ''' <summary>
        ''' FanQuantity4
        ''' </summary>
        Property FanQuantity4() As Double
            Get
                Return Me.m_FanQuantity4
            End Get
            Set(ByVal value As Double)
                Me.m_FanQuantity4 = value
            End Set
        End Property


        Private m_Use10Coefficients As Boolean
        Property Use10Coefficients() As Boolean
            Get
                Return m_Use10Coefficients
            End Get
            Set(ByVal value As Boolean)
                m_Use10Coefficients = value
            End Set
        End Property


        Private m_Voltage As Integer
        Property Voltage() As Integer
            Get
                Return m_Voltage
            End Get
            Set(ByVal value As Integer)
                m_Voltage = value
            End Set
        End Property



        Private m_TubeDiameter1 As Double
        ''' <summary>
        ''' TubeDiameter1
        ''' </summary>
        Property TubeDiameter1() As Double
            Get
                Return Me.m_TubeDiameter1
            End Get
            Set(ByVal value As Double)
                Me.m_TubeDiameter1 = value
            End Set
        End Property

        Private m_TubeSurface1 As String
        ''' <summary>
        ''' TubeSurface1
        ''' </summary>
        Property TubeSurface1() As String
            Get
                Return Me.m_TubeSurface1
            End Get
            Set(ByVal value As String)
                Me.m_TubeSurface1 = value
            End Set
        End Property

        Private m_FinType1 As String
        ''' <summary>
        ''' FinType1
        ''' </summary>
        Property FinType1() As String
            Get
                Return Me.m_FinType1
            End Get
            Set(ByVal value As String)
                Me.m_FinType1 = value
            End Set
        End Property


        Private m_TubeDiameter2 As Double
        ''' <summary>
        ''' TubeDiameter2
        ''' </summary>
        Property TubeDiameter2() As Double
            Get
                Return Me.m_TubeDiameter2
            End Get
            Set(ByVal value As Double)
                Me.m_TubeDiameter2 = value
            End Set
        End Property

        Private m_TubeSurface2 As String
        ''' <summary>
        ''' TubeSurface2
        ''' </summary>
        Property TubeSurface2() As String
            Get
                Return Me.m_TubeSurface2
            End Get
            Set(ByVal value As String)
                Me.m_TubeSurface2 = value
            End Set
        End Property

        Private m_FinType2 As String
        ''' <summary>
        ''' FinType2
        ''' </summary>
        Property FinType2() As String
            Get
                Return Me.m_FinType2
            End Get
            Set(ByVal value As String)
                Me.m_FinType2 = value
            End Set
        End Property


        Private m_TubeDiameter3 As Double
        ''' <summary>
        ''' TubeDiameter3
        ''' </summary>
        Property TubeDiameter3() As Double
            Get
                Return Me.m_TubeDiameter3
            End Get
            Set(ByVal value As Double)
                Me.m_TubeDiameter3 = value
            End Set
        End Property

        Private m_TubeSurface3 As String
        ''' <summary>
        ''' TubeSurface3
        ''' </summary>
        Property TubeSurface3() As String
            Get
                Return Me.m_TubeSurface3
            End Get
            Set(ByVal value As String)
                Me.m_TubeSurface3 = value
            End Set
        End Property

        Private m_FinType3 As String
        ''' <summary>
        ''' FinType3
        ''' </summary>
        Property FinType3() As String
            Get
                Return Me.m_FinType3
            End Get
            Set(ByVal value As String)
                Me.m_FinType3 = value
            End Set
        End Property


        Private m_TubeDiameter4 As Double
        ''' <summary>
        ''' TubeDiameter4
        ''' </summary>
        Property TubeDiameter4() As Double
            Get
                Return Me.m_TubeDiameter4
            End Get
            Set(ByVal value As Double)
                Me.m_TubeDiameter4 = value
            End Set
        End Property

        Private m_TubeSurface4 As String
        ''' <summary>
        ''' TubeSurface4
        ''' </summary>
        Property TubeSurface4() As String
            Get
                Return Me.m_TubeSurface4
            End Get
            Set(ByVal value As String)
                Me.m_TubeSurface4 = value
            End Set
        End Property

        Private m_FinType4 As String
        ''' <summary>
        ''' FinType4
        ''' </summary>
        Property FinType4() As String
            Get
                Return Me.m_FinType4
            End Get
            Set(ByVal value As String)
                Me.m_FinType4 = value
            End Set
        End Property

        Private m_FanRPM1 As Decimal
        ''' <summary>
        ''' FanRPM1
        ''' </summary>
        Property FanRPM1() As Decimal
            Get
                Return Me.m_FanRPM1
            End Get
            Set(ByVal value As Decimal)
                Me.m_FanRPM1 = value
            End Set
        End Property

        Private m_FanRPM2 As Decimal
        ''' <summary>
        ''' FanRPM2
        ''' </summary>
        Property FanRPM2() As Decimal
            Get
                Return Me.m_FanRPM2
            End Get
            Set(ByVal value As Decimal)
                Me.m_FanRPM2 = value
            End Set
        End Property

        Private m_FanRPM3 As Decimal
        ''' <summary>
        ''' FanRPM3
        ''' </summary>
        Property FanRPM3() As Decimal
            Get
                Return Me.m_FanRPM3
            End Get
            Set(ByVal value As Decimal)
                Me.m_FanRPM3 = value
            End Set
        End Property


        Private m_FanRPM4 As Decimal
        ''' <summary>
        ''' FanRPM1
        ''' </summary>
        Property FanRPM4() As Decimal
            Get
                Return Me.m_FanRPM4
            End Get
            Set(ByVal value As Decimal)
                Me.m_FanRPM4 = value
            End Set
        End Property


        Private m_DOEModel As String
        Property DOEModel() As String
            Get
                Return Me.m_DOEModel
            End Get
            Set(ByVal value As String)
                Me.m_DOEModel = value
            End Set
        End Property




#End Region


#Region " Methods"

        ''' <summary>Parameterless constructor for serialization purposes only... DO NOT USE</summary>
        Sub New()
        End Sub

        ''' <summary>
        ''' Constructs a condensing unit process that already exists in the data source based on the ID.
        ''' Automatically loads the process from the data source.
        ''' </summary>
        ''' <param name="id">ID of the condensing unit process to load.</param>
        Sub New(ByVal id As item_id)
            Me.initialize()
            Me.id = id
        End Sub

        ''' <summary>
        ''' Constructs a new condensing unit process with the specified name.
        ''' Generates a new ID.
        ''' </summary>
        ''' <param name="name">Name of the process.</param>
        ''' <param name="createdBy">Username of the person who created the process.</param>
        ''' <param name="password">Password of the person who created the process.</param>
        ''' <param name="parent">Parent project manager that process should be included in.</param>
        Sub New(ByVal name As String, ByVal createdBy As String, ByVal password As String, ByVal parent As project_manager)
            Me.initialize()
            Me.name = name
            Me.id = New item_id(createdBy, password)
            Me.ProjectManager = parent
        End Sub


        Sub New(ByVal cuEquip As CondensingUnitEquipmentItem)

            Me.New(cuEquip.name, cuEquip.id.Username, cuEquip.id.Password, cuEquip.ProjectManager)
            Me.initialize()

            Static equipFlag As Boolean = False


            ' sets common properties
            '
            Me.Series = cuEquip.series
            Me.Model = cuEquip.model
            Me.CustomCondensingUnitModel = cuEquip.custom_model

            If cuEquip.specs.ambient.has_value Then
                Me.AmbientTemperature = cuEquip.specs.ambient.value
                Me.RatingAmbient = cuEquip.specs.ambient.value
            End If

            If cuEquip.specs.suction.has_value Then
                Me.SuctionTemperature = cuEquip.specs.suction.value
                Me.RatingSuction = cuEquip.specs.suction.value
            End If

            If Not String.IsNullOrEmpty(cuEquip.specs.refrigerant) Then
                If cuEquip.division = Business.Division.CRI Then
                    ' inserts dash after R (ex. R22 > R-22)
                    Me.Refrigerant = cuEquip.specs.refrigerant '+ Me.Model.Substring(Me.Model.Length - 1)





                ElseIf cuEquip.division = Business.Division.TSI Then
                    Me.Refrigerant = cuEquip.specs.refrigerant & "H"
                    Me.RatingRefrigerant = cuEquip.specs.refrigerant & "H"
                End If
            End If

            If cuEquip.specs.capacity_1.has_value Then
                Me.Capacity = cuEquip.specs.capacity_1.value
            End If
            If cuEquip.specs.capacity_2.has_value Then
                Me.Capacity += cuEquip.specs.capacity_2.value
            End If
            If cuEquip.specs.capacity_3.has_value Then
                Me.Capacity += cuEquip.specs.capacity_3.value
            End If
            If cuEquip.specs.capacity_4.has_value Then
                Me.Capacity += cuEquip.specs.capacity_4.value
            End If

            If cuEquip.common_specs.Altitude.has_value Then
                Me.Altitude = cuEquip.common_specs.Altitude.value
                Me.RatingAltitude = cuEquip.common_specs.Altitude.value
            End If

            'prevent null ref
            If equipFlag = False Then
                Me.equipment = New EquipmentItemList
                equipFlag = True
            End If

            RatingCatalog = True
            RatingSubCooling = 10


            Me.CoilRows1 = 2
            Me.CoilRows2 = 2
            Me.FinType1 = "Waffle"
            Me.FinType2 = "Waffle"
            Me.TubeSurface1 = "Smooth"
            Me.TubeSurface2 = "Smooth"

            Me.DOEModel = "No"

            ' associate equipment w/ process
            Me.equipment.Add(cuEquip)

            'link process and equipment in a database table
            Rae.RaeSolutions.DataAccess.Projects.ProcessEquipDA.Create(Me.id.ToString, cuEquip.id.ToString)

        End Sub


        ''' <summary>
        ''' Loads condensing unit process based on ID. 
        ''' ID must be set before calling this method.
        ''' (Optionally revision can be set to pull specific revision.)
        ''' </summary>
        Overrides Sub Load()
            Dim process As CondensingUnitProcessItem
            If Me.Revision > -1 Then
                process = CondensingUnitProcessDa.Retrieve(Me.id, Me.Revision)
            Else
                process = CondensingUnitProcessDa.Retrieve(Me.id)
            End If
            Me.Copy(process)
        End Sub

#End Region

        ''' <summary>Initializes objects. Prevents NullReference.</summary>
        Protected Overrides Sub initialize()
            MyBase.initialize()
        End Sub

    End Class
End Namespace