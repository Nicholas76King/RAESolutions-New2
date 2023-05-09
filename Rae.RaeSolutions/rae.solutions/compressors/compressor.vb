Imports rae.validation

Namespace rae.solutions.compressors

    Public Class compressor
        Friend user As user
        Public model, refrigerant, manufacturer, part_number, MasterID As String
        Public limitID As String
        Public type As compressor_type
        Public hp As Double
        Public suctionMin, suctionMax As Double
        'Public dischargeMin, dischargeMax As Double
        Public num_coef As Integer
        Public coef As coef

        Public mcc, rla As Single

        Public Unloading, HeadCoolingFan As String
        '    Dim DemandC As String
        Dim LiquidInjection, OilCool As String
        Public HeadCoolingFanSuctionMin, HeadCoolingFanSuctionMax As Double
        ' Public DemandCSuctionMin, DemandCSuctionMax As Double
        Public LiquidInjectionSuctionMin, LiquidInjectionSuctionMax As Double
        Public OilCoolSuctionMin, OilCoolSuctionMax As Double

        Public TempApplication As String, OilDistSystem As String

        Public DemandCoolingLimit As String

        ' Public CurveVoltage As Integer

        Function is_within_safety_limits(ByVal suction_temp As Double, ByVal discharge_temp As Double) As Boolean
            'Dim temp_limits = New compressor_limits_factory().create(Me, suction_temp, discharge_temp)
            'Return Not temp_limits.exceeded




            ' If discharge_temp > 130 AndAlso isRep Then Return False
            Dim SuccessFlag As Boolean = False

            Dim cLSI As New CompressorLimits(limitID, False, successFlag)
            Return cLSI.Valid(CSng(suction_temp), CSng(discharge_temp))



        End Function


        Function RequiresDemandCooling(ByVal suction_temp As Double, ByVal discharge_temp As Double) As Boolean

            If String.IsNullOrEmpty(DemandCoolingLimit) Then Return False
            Dim SuccessFlag As Boolean = False

            Dim cLSI As New CompressorLimits(DemandCoolingLimit, False, successFlag)
            Return Not cLSI.Valid(CSng(suction_temp), CSng(discharge_temp))



        End Function


        Function validate(ByVal suction_temp As Double, ByVal discharge_temp As Double) As i_validate
            ' todo: move compressor validator to rae.solutions ns
            Dim validator = New compressor_is_within_limits(Me, suction_temp, discharge_temp)
            validator.validate()
            Return validator
        End Function

        Overrides Function ToString() As String
            Return model.PadRight(12) & "HP:" & hp
        End Function
    End Class

End Namespace