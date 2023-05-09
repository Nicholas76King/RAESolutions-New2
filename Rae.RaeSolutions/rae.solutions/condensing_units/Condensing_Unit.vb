Imports rae.solutions

Namespace rae.solutions.condensing_units

    Public Class Circuit
        Sub New()
            coil = New Coil()
            CompressorCapacityMultiplier = 1
        End Sub
        Public compressorMasterID, compressor_type As String
        Public compressor_quantity As Integer

        Public coil As Coil
        Public has_subcooling As Boolean
        Public subcooling As Double
        Public CompressorCapacityMultiplier As Single

        Public num_refrigerant_circuits As Integer
        Public refrigerant As refrigerant
        Public hp, fan_quantity As Double
        Public fanID As String
        Public fanOperatingRPM As Decimal
        '        Public fan_diameter, hp, fan_quantity As Double

    End Class

    Public Class Coil
        Public model As String
        Public TubeDiameter, FinLength, FinHeight, FPI, RowsDeep, capacity, Quantity As Double
        Public TubeSurface As String ', finType As String
        Public UseDLLForPerformance As Boolean


        ' Fields added for the transition to the buzz dll
        Public CondFeeds As Integer
        Public CondPasses As Integer
        Public SubCoolerFeeds As Integer
        Public SubCoolerPasses As Integer
        Public FinSurface As String
        Public FinMaterial As String
        Public FinThickness As Decimal
        'Public TubeSurface As String
        Public TubeMaterial As String
        Public TubeThickness As Decimal


    End Class

    Public Class Condensing_Unit

        Sub New()
            circuits = New List(Of Circuit)

        End Sub

        Public model, series As String
        Public number_of_circuits As Integer
        Public dimensions As String
        Public circuits As list(Of Circuit)
        Public compressor_quantity_description As String
        Public division As String
        Public min_capacity, max_capacity As Double
        'Public minSuctionFromEnvelope, maxSuctionFromEnvelope As Double
        Public minSuctionOfUnit, maxSuctionOfUnit As Double
        Public temperature_range As String
        Public motor_part_number_single_phase, motor_part_number_3_phase230460, motor_part_number_3_phase575 As String
        Public mca_208, mca_460 As Double
        Public operating_weight, shipping_weight As Double

        Public constantReturnGasTemp As String


        ReadOnly Property refrigerant As refrigerant
            Get
                Return circuits(0).refrigerant
            End Get
        End Property

        Function SuctionIsInUnitLimits(ByVal suction As Single) As Boolean
            If suction >= minSuctionOfUnit AndAlso suction <= maxSuctionOfUnit Then Return True
            Return False
        End Function


        Function subcooling_temperature(ByVal td As Double, ByVal division As RaeSolutions.Business.Division) As Double
            ' ERICC


            ' glide correction - Jay Kindle 6/29/2015

            Select Case Me.refrigerant
                Case rae.solutions.refrigerant.R407a
                    td -= 4
                Case rae.solutions.refrigerant.R407c
                    td -= 5
                Case rae.solutions.refrigerant.R407f
                    td -= 4
                Case rae.solutions.refrigerant.R448a
                    td -= 5
                Case rae.solutions.refrigerant.R449a
                    td -= 5
            End Select

            If td < 0 Then td = 0

            '''''' / glide


            If division = RaeSolutions.Business.Division.CRI Then
                If temperature_range = "High" OrElse temperature_range = "Medium" Then
                    subcooling_temperature = If(td / 2 < 10, td / 2, 10)
                Else
                    subcooling_temperature = If(td / 2 < 5, td / 2, 5)
                End If
            Else
                subcooling_temperature = If(td / 2 < 15, td / 2, 15)

            End If


        End Function
    End Class

End Namespace