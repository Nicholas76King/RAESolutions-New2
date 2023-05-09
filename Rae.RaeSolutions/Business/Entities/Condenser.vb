Imports Rae.RaeSolutions.Business.Intelligence
Imports System.Collections.Generic
Imports Rae.solutions.condensers.condenser_repository
Imports CondenserDataAccess = Rae.RaeSolutions.DataAccess.CondenserDataAccess
Imports System.Math
Imports Rae.Math.Calculate
Imports Rae.Convert

Namespace Rae.RaeSolutions.Business.Entities

    ''' <summary>Calculates condenser data for different fins per inch.</summary>
    ''' <remarks>
    ''' If inputs are changed then the outputs need to be re-calculated
    ''' Optional Inputs
    ''' * Refrigerant - is only used to determine refrigerant multiplier for capacity; if not set capacity is not adjusted.
    ''' * Catalog Rating - is only used to adjust capacity based on catalog rating multiplier; if not set is assumed to be false.
    ''' * Altitude - affects standard air flow which affects capacity; if not set is assumed to be zero.
    ''' * Additional External Static Pressure - affects actual air flow and capacity; if not set is assumed to be zero.
    ''' * Sub Cooling Percentage - reduces the capacity by its percentage; if not set is assumed to be zero.
    ''' * Air Flow Override - if air flow is overriden then this override affects air flow and capacity; if not set then fan file is used to calculate air flow.
    ''' </remarks>
    Public Class Condenser

#Region " Public"

        ''' <summary>Use when you want the air flow and horsepower calculated based on fan curves.</summary>
        ''' <param name="ambient">Ambient temperature in degrees Farenheit</param>
        ''' <param name="difference">Temperature difference between condensing and ambient temperatures</param>
        Sub New(ByVal ambient As Double, ByVal difference As Double, _
        ByVal coilWidth As Double, ByVal coilLength As Double, _
        ByVal coilFile As String, ByVal numFans As Double, ByVal fanFile As String, ByVal tubeSurface As String)

            initialize()

            With input_
                .AmbientTemperature = ambient
                .TemperatureDifference = difference
                .CoilWidth = coilWidth
                .CoilLength = coilLength
                .CoilFile = coilFile
                .NumFans = numFans

                .FanFile = fanFile
                .tubeSurface = tubeSurface

            End With

        End Sub

        ''' <summary>Use when overriding air flow.</summary>
        Sub New(ByVal ambient As Double, ByVal difference As Double, _
        ByVal coilWidth As Double, ByVal coilLength As Double, _
        ByVal coilFile As String, ByVal numFans As Double, ByVal airFlowOverride As Double, ByVal tubeSurface As String)

            initialize()

            With input_
                .AmbientTemperature = ambient
                .TemperatureDifference = difference
                .CoilWidth = coilWidth
                .CoilLength = coilLength
                .CoilFile = coilFile
                .NumFans = numFans

                .AirFlowIsOverriden = True
                .AirFlowOverride = airFlowOverride
                .tubeSurface = tubeSurface

            End With

        End Sub

        ''' <summary>Use when overriding altitude.</summary>
        Sub New(ByVal altitude As Double, ByVal ambient As Double, ByVal difference As Double, _
        ByVal coilWidth As Double, ByVal coilLength As Double, _
        ByVal coilFile As String, ByVal numFans As Double, ByVal fanFile As String, ByVal tubeSurface As String)

            initialize()

            With input_
                .AmbientTemperature = ambient
                .TemperatureDifference = difference
                .CoilWidth = coilWidth
                .CoilLength = coilLength
                .CoilFile = coilFile
                .NumFans = numFans
                .FanFile = fanFile
                .Altitude = altitude
                .tubeSurface = tubeSurface

            End With
            Calculate()
        End Sub

        ''' <summary>Use when overriding altitude and airflow.</summary>
        Sub New(ByVal altitude As Double, ByVal ambient As Double, ByVal difference As Double, _
        ByVal coilWidth As Double, ByVal coilLength As Double, _
        ByVal coilFile As String, ByVal numFans As Double, ByVal airFlowOverride As Double, ByVal tubeSurface As String)

            initialize()

            With input_
                .AmbientTemperature = ambient
                .TemperatureDifference = difference
                .CoilWidth = coilWidth
                .CoilLength = coilLength
                .CoilFile = coilFile
                .NumFans = numFans
                .Altitude = altitude
                .AirFlowIsOverriden = True
                .AirFlowOverride = airFlowOverride
                .tubeSurface = tubeSurface
            End With
            Calculate()
        End Sub

        ' ''' <summary>Use when optionally override altitude and pass in Coil and Fan.</summary>
        'Sub New(ByVal ambient As Double, ByVal difference As Double, _
        'ByVal coil As Coil, ByVal numFans As Double, ByVal fan As Fan, Optional ByVal altitude As Double = 0)

        '    initialize()

        '    With input_
        '        .AmbientTemperature = ambient
        '        .TemperatureDifference = difference
        '        .CoilWidth = coil.FinHeight
        '        .CoilLength = coil.FinLength
        '        .CoilFile = coil.FileName
        '        .NumFans = numFans
        '        .FanFile = fan.FileName
        '        .Altitude = altitude
        '    End With
        '    Calculate()
        'End Sub


#Region " Classes"

        ''' <summary>List of outputs at different fins per inch.</summary>
        Public Class OutputsList : Inherits List(Of Outputs)

            ''' <summary>Gets outputs at a specified fins per inch</summary>
            Function At(ByVal finsPerInch As Integer) As Outputs
                For Each output As Outputs In Me
                    If output.FinsPerInch = finsPerInch Then
                        Return output
                    End If
                Next
                Throw New ApplicationException("There are no results at the specified fins per inch.")
            End Function

        End Class


        ''' <summary>Condenser inputs needed to calculate outputs</summary>
        Public Class Inputs

#Region " Required inputs"

            Property AmbientTemperature As Double
            ''' <summary>Temperature difference between condensing and ambient temperatures in degrees Fahrenheit.</summary>
            Property TemperatureDifference As Double
            ''' <summary>Coil width in inches</summary>
            Property CoilWidth As Double
            ''' <summary>Coil length in inches</summary>
            Property CoilLength As Double
            Property CoilFile As String
            ''' <summary>Number of fans in condenser</summary>
            Property NumFans As Double
            ''' <summary>Fan file name</summary>
            Property FanFile As String

            Property tubeSurface As String

#End Region

            ''' <summary>Altitude in feet. If not set equals zero.</summary>
            Property Altitude As Double
            ''' <summary>External static pressure [inches of water]. If not set equals zero.</summary>
            Property AdditionalExternalStaticPressure As Double
            ''' <summary>
            ''' True if air flow is overriden; else false. 
            ''' If air flow is overriden then the air flow override property should be set.
            ''' Equals false by default.
            ''' </summary>
            Property AirFlowIsOverriden As Boolean
            ''' <summary>The air flow value to use for overriding in CFM</summary>
            Property AirFlowOverride As Double
            ''' <summary>Sub cooling percentage reduces the capacity by its percentage (ex. 15% would be 15 not 0.15)</summary>
            Property SubCoolingPercentage As Double
            ''' <summary>True if calculations should use catalog rating; else false.</summary>
            Property CapacityIsUsingCatalogRating As Boolean
            ' TODO: make identifying refrigerant options easy (ex. Enum or Refrigerant class)
            ' TODO: then probably make refrigerant required in constructors
            Property Refrigerant As String

        End Class


        ''' <summary>Condenser outputs from the calculations</summary>
        Public Class Outputs
            Property FinsPerInch As Double
            ''' <summary>Capacity in BTUH</summary>
            Property Capacity As Double
            ''' <summary>Face velocity in FPM</summary>
            Property FaceVelocity As Double
            ''' <summary>Static pressure in inches of water</summary>
            Property StaticPressure As Double
            Property Horsepower As Double
            ''' <summary>Actual air flow in CFM</summary>
            Property AirFlowActual As Double
            ''' <summary>Standard air flow in CFM</summary>
            Property AirFlowStandard As Double
            ''' <summary>Coil capacity; capacity over coil face in BTUH per square foot</summary>
            Property CoilCapacity As Double
        End Class

#End Region


#Region " Properties"

        Protected input_ As Inputs
        ''' <summary>Condenser inputs required to calculate condenser results</summary>
        Property Input As Inputs
            Get
                Return input_
            End Get
            Set(ByVal Value As Inputs)
                input_ = Value
            End Set
        End Property


        Protected output_ As OutputsList
        ''' <summary>Calculated outputs based on inputs</summary>
        ReadOnly Property Output() As OutputsList
            Get
                Return output_
            End Get
        End Property

#End Region


        ''' <summary>Calculates outputs based on inputs and interpolates intermediate values.</summary>
        ''' <exception cref="ApplicationException">
        ''' Thrown when coil file name does not exist in database.
        ''' </exception>
        Function Calculate() As OutputsList
            Dim output As OutputsList

            output = calculateAtConditionsInDatabase()
            output = interpolate(output, Input.CoilFile)

            output_ = output

            Return output
        End Function

#End Region


#Region " Private"

        ''' <summary>
        ''' Room temperature in Fahrenheit
        ''' </summary>
        Const ASSUMED_ROOM_TEMPERATURE As Double = 70
        Const CAPACITY_MULTIPLIER As Double = 1.08


        Private Sub initialize()
            input_ = New Inputs()
            setDefaults()
        End Sub


        Private Sub setDefaults()
            With input_
                .Altitude = 0
                .AdditionalExternalStaticPressure = 0
                .AirFlowIsOverriden = False
                .CapacityIsUsingCatalogRating = False
            End With
        End Sub


        Private Function calculateAtConditionsInDatabase() As OutputsList
            Dim i As Inputs = input_

            Dim fanCurve As New FanCurve(i.FanFile)
            Dim coilCurve As CoilData = RetrieveCoilData(i.CoilFile, i.tubesurface)
            If coilCurve Is Nothing Then
                Throw New ApplicationException("The coil data cannot be retrieved. The coil file does not exist in database.")
            End If

            Dim faceArea = AreaOfRectangle(InchesToFeet(i.CoilWidth), InchesToFeet(i.CoilLength))

            Dim condensingTemperature = i.AmbientTemperature + i.TemperatureDifference

            Dim temperatureCorrection = calculateTemperatureCorrection(i.AmbientTemperature)

            Dim altitudeCorrection = calculateAltitudeCorrection(i.Altitude)

            Dim outputs As New OutputsList()
            Dim o As Outputs
            Dim airFlowActual As Double

            Dim fpiIndex As Integer
            For fpiIndex = 0 To 3
                Dim fpiData As FpiData = coilCurve.FpiData(fpiIndex)
                o = New Outputs()

                Dim faceVelocityActual As Double

                Dim fanStaticPressure, totalStaticPressure As Double
                For fanStaticPressure = 0.01 To 1.5 Step 0.01
                    totalStaticPressure = fanStaticPressure + i.AdditionalExternalStaticPressure
                    airFlowActual = i.NumFans * calculateAirFlow(fanCurve, totalStaticPressure, i.AirFlowIsOverriden, i.AirFlowOverride)
                    faceVelocityActual = airFlowActual / faceArea

                    Dim coilStaticPressure = calculateCoilStaticPressure(coilCurve.PressureCoefficients, faceVelocityActual, fpiData.PressureCoefficient)

                    If fanStaticPressure > coilStaticPressure Then Exit For
                Next

                Dim airFlowStandard = airFlowActual * temperatureCorrection * altitudeCorrection

                Dim capacity As Double
                capacity = calculateCapacity(airFlowStandard, faceArea, i.TemperatureDifference, i.SubCoolingPercentage, fpiData.FanCoefficients)
                capacity = adjustCapacity(capacity, i.Refrigerant, i.CapacityIsUsingCatalogRating, i.TemperatureDifference)

                If i.tubeSurface.ToLower = "rifled" Then
                    capacity = capacity * (0.00003101 * faceVelocityActual + 1.06075146)
                End If



                Dim horsepower As Double
                If Not i.AirFlowIsOverriden Then
                    horsepower = calculateHorsepower(fanCurve, totalStaticPressure)
                End If

                Dim coilCapacity = capacity / faceArea



                o.FinsPerInch = fpiData.Fpi
                o.Capacity = capacity
                o.FaceVelocity = faceVelocityActual
                o.StaticPressure = fanStaticPressure
                o.Horsepower = horsepower
                o.AirFlowActual = airFlowActual
                o.AirFlowStandard = airFlowStandard
                o.CoilCapacity = coilCapacity

                roundOutputs(o)

                outputs.Add(o)
            Next

            output_ = outputs

            Return outputs
        End Function


        Private Function interpolate(ByVal outputs As OutputsList, ByVal coilFile As String) As OutputsList
            Dim interpolations As New OutputsList()
            If coilIsAnEvaporator(coilFile) Then
                ' don't interpolate evaporators
            Else
                interpolations = calculateInterpolations(outputs, coilFile)
            End If

            ' steps through indices to insert interpolated values (1, 3, 5, ...)
            Dim complete = insertInterpolations(interpolations, outputs)

            Return complete
        End Function


        ''' <summary>
        ''' Calculates the temperature correction
        ''' </summary>
        ''' <param name="ambientTemperature">
        ''' Ambient temperature in Fahrenheit
        ''' </param>
        Private Function calculateTemperatureCorrection(ByVal ambientTemperature As Double) As Double
            Dim ambientRankine As Double
            ambientRankine = Convert.FahrenheitToRankine(ambientTemperature)

            Dim roomRankine As Double
            roomRankine = Convert.FahrenheitToRankine(ASSUMED_ROOM_TEMPERATURE)

            Dim temperatureCorrection As Double
            temperatureCorrection = roomRankine / ambientRankine

            Return temperatureCorrection
        End Function


        Private Function calculateAltitudeCorrection(ByVal altitude As Double) As Double
            Dim a As Double = shorten(altitude)
            Dim c0, c1, c2, c3 As Double
            c0 = 2.60087E-18
            c1 = 0.0000000000000312094
            c2 = 0.000000000385576
            c3 = 0.0000358752

            Dim altitudeCorrection As Double
            altitudeCorrection = 1 - c0 * a ^ 4 + c1 * a ^ 3 + c2 * a ^ 2 - c3 * a

            Return altitudeCorrection
        End Function


        ''' <summary>Calculates capacity in BTUH</summary>
        ''' <param name="airFlow">Air flow in CFM</param>
        ''' <param name="faceArea">Face area in square feet</param>
        Private Function calculateCapacity(ByVal airFlow As Double, ByVal faceArea As Double, _
        ByVal temperatureDifference As Double, ByVal subCoolingPercentage As Double, _
        ByVal fanCoefficients As List(Of Double)) As Double
            Dim faceVelocity = airFlow / faceArea

            Dim fv = shorten(faceVelocity)
            Dim f = shorten(fanCoefficients)

            Dim capacity As Double
            capacity = f(0) + f(1) * fv ^ 4 + f(2) * fv ^ 3 + f(3) * fv ^ 2 + f(4) * fv ^ 1

            capacity = capacity * CAPACITY_MULTIPLIER * fv * faceArea * temperatureDifference

            capacity = capacity * (1 - (subCoolingPercentage / 100))

            Return capacity
        End Function


        Private Function shorten(Of T)(ByVal value As T) As T
            Return value
        End Function


        Private Function adjustCapacity(ByVal capacity As Double, ByVal refrigerant As String, ByVal isUsingCatalogRating As Boolean, ByVal td As Double) As Double
            Dim adjustedCapacity As Double

            Dim refrigerantMultiplier As Double = determineRefrigerantMultiplier(refrigerant, td)
            adjustedCapacity = capacity * refrigerantMultiplier

            If isUsingCatalogRating Then
                Dim catalogRatingMultiplier As Double = CondenserCache.Create().CatalogRatingMultiplier
                adjustedCapacity = adjustedCapacity * catalogRatingMultiplier
            End If

            Return adjustedCapacity
        End Function


        Private Function calculateCoilStaticPressure( _
        ByVal pressureCoefficients As List(Of Double), ByVal faceVelocity As Double, ByVal fpiPressureCoefficient As Double) As Double

            Dim fv = shorten(faceVelocity)
            Dim p = shorten(pressureCoefficients)
            Dim pc = shorten(fpiPressureCoefficient)

            Dim coilStaticPressure = (p(0) + p(1) * fv ^ 4 + p(2) * fv ^ 3 + p(3) * fv ^ 2 + p(4) * fv) * pc

            Return coilStaticPressure
        End Function


        Private Function calculateHorsepower(ByVal fanCurve As FanCurve, ByVal staticPressure As Double) As Double
            Dim f As FanCurve = shorten(fanCurve)
            Dim sp = shorten(staticPressure)

            Dim horsepower = f.C5 + f.C6 * sp ^ 4 + f.C7 * sp ^ 3 + f.C8 * sp ^ 2 + f.C9 * sp

            Return horsepower
        End Function


        Private Function calculateAirFlow(ByVal fanCurve As FanCurve, ByVal staticPressure As Double, _
        ByVal shouldOverrideAirFlow As Boolean, ByVal airFlowOverride As Double) As Double
            Dim f As FanCurve = shorten(fanCurve)
            Dim sp = shorten(staticPressure)

            Dim airFlow As Double
            If shouldOverrideAirFlow Then
                airFlow = airFlowOverride
            Else
                airFlow = f.C0 + f.C1 * sp ^ 4 + f.C2 * sp ^ 3 + f.C3 * sp ^ 2 + f.C4 * sp
            End If

            Return airFlow
        End Function


        Private Sub roundOutputs(ByVal output As Outputs)
            output.FinsPerInch = Round(output.FinsPerInch)
            output.Capacity = Round(output.Capacity)
            output.FaceVelocity = Round(output.FaceVelocity)
            output.StaticPressure = Round(output.StaticPressure, 2)
            output.Horsepower = Round(output.Horsepower, 2)
            output.AirFlowActual = Round(output.AirFlowActual)
            output.AirFlowStandard = Round(output.AirFlowStandard)
            output.CoilCapacity = Round(output.CoilCapacity)
        End Sub


        Private Function calculateInterpolation(ByVal output1 As Outputs, ByVal output2 As Outputs) As Outputs
            Dim fpi = Average(output1.FinsPerInch, output2.FinsPerInch)

            Dim capacity = Average(output1.Capacity, output2.Capacity)
            capacity = Round(capacity)

            Dim faceVelocity = Average(output1.FaceVelocity, output2.FaceVelocity)
            faceVelocity = Round(faceVelocity)

            Dim staticPressure = Average(output1.StaticPressure, output2.StaticPressure)
            staticPressure = Round(staticPressure, 2)

            Dim horsepower = Average(output1.Horsepower, output2.Horsepower)
            horsepower = Round(horsepower, 2)

            Dim airFlowActual = Average(output1.AirFlowActual, output2.AirFlowActual)
            airFlowActual = Round(airFlowActual)

            Dim airFlowStandard = Average(output1.AirFlowStandard, output2.AirFlowStandard)
            airFlowStandard = Round(airFlowStandard)

            Dim coilCapacity = Average(output1.CoilCapacity, output2.CoilCapacity)
            coilCapacity = Round(coilCapacity)

            Dim interpolation As New Outputs()
            With interpolation
                .FinsPerInch = fpi
                .Capacity = capacity
                .FaceVelocity = faceVelocity
                .StaticPressure = staticPressure
                .Horsepower = horsepower
                .AirFlowActual = airFlowActual
                .AirFlowStandard = airFlowStandard
                .CoilCapacity = coilCapacity
            End With

            Return interpolation
        End Function


        Private Function calculateInterpolations(ByVal outputs As OutputsList, ByVal coilFile As String) As OutputsList
            Dim interpolations As New OutputsList()
            Dim interpolation As Outputs

            Dim i As Integer
            For i = 0 To outputs.Count - 2
                interpolation = calculateInterpolation(outputs(i), outputs(i + 1))
                interpolations.Add(interpolation)
            Next

            Return interpolations
        End Function


        Private Function insertInterpolations(ByVal interpolations As OutputsList, ByVal outputs As OutputsList) As OutputsList
            Dim complete As New OutputsList()
            Dim i As Integer

            For i = 0 To outputs.Count - 1
                complete.Add(outputs(i))
            Next

            For i = 0 To interpolations.Count - 1
                complete.Insert(i * 2 + 1, interpolations(i))
            Next

            Return complete
        End Function


        Private Function coilIsAnEvaporator(ByVal coilFile As String) As Boolean
            Dim isEvaporator As Boolean

            If coilFile Like "*EVAP*" Then
                isEvaporator = True
            Else
                isEvaporator = False
            End If

            Return isEvaporator
        End Function


        Private Function determineRefrigerantMultiplier(ByVal refrigerant As String, ByVal td As Double) As Double
            Dim refrigerantMultiplier As Double
            Dim cache As CondenserCache = CondenserCache.Create()

            If String.IsNullOrEmpty(refrigerant) Then
                refrigerantMultiplier = 1
            ElseIf refrigerant = CondenserRefrigerants.R22 Then
                refrigerantMultiplier = cache.R22Multiplier
            ElseIf refrigerant = CondenserRefrigerants.R404a Then
                refrigerantMultiplier = cache.R404aMultiplier
            ElseIf refrigerant = CondenserRefrigerants.R134a Then
                refrigerantMultiplier = cache.R134aMultiplier
            ElseIf refrigerant = CondenserRefrigerants.R410a Then
                refrigerantMultiplier = cache.R410aMultiplier
            ElseIf refrigerant = CondenserRefrigerants.R507 Then
                refrigerantMultiplier = cache.R507Multiplier
            ElseIf refrigerant = CondenserRefrigerants.R407a Then
                refrigerantMultiplier = cache.R407aMultiplier
            ElseIf refrigerant = CondenserRefrigerants.R407c Then
                refrigerantMultiplier = cache.R407cMultiplier
            ElseIf refrigerant = CondenserRefrigerants.R407f Then
                refrigerantMultiplier = cache.R407fMultiplier
            ElseIf refrigerant = CondenserRefrigerants.R448a Then
                refrigerantMultiplier = cache.R448aMultiplier
            ElseIf refrigerant = CondenserRefrigerants.R449a Then
                refrigerantMultiplier = cache.R449aMultiplier
            Else
                refrigerantMultiplier = 1
            End If

            ' NEW CODE 2/29/16 ERIC C

            Select Case refrigerant
                Case CondenserRefrigerants.R410a, CondenserRefrigerants.R22, CondenserRefrigerants.R134a, CondenserRefrigerants.R507, CondenserRefrigerants.R404a
                    ' do nothing
                Case Else
                    refrigerantMultiplier = refrigerantMultiplier + (0.024083759556601834 - (1.9228 * (System.Math.E ^ (-0.146 * td))))

                    If refrigerantMultiplier < 0.01 Then refrigerantMultiplier = 0.01

            End Select



            '0.024083759556601834




            Return refrigerantMultiplier
        End Function

#End Region

    End Class

End Namespace
