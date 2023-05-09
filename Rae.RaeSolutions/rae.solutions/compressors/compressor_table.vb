Namespace rae.solutions.compressors

    Class compressor_table
        Public Const table_name As String = "Master"


        Public Const MasterID = "MasterID"
        Public Const Manufacturer = "Manufacturer"
        Public Const ManufacturerModelNumber = "ManufacturerModelNumber"
        Public Const CompressorType = "CompressorType"
        Public Const Optimization = "Optimization"
        Public Const TemperatureRange = "TemperatureRange"
        Public Const Horsepower = "Horsepower"
        Public Const Refrigerant = "Refrigerant"
        Public Const RepAccess = "RepAccess"
        Public Const SalesAccess = "SalesAccess"
        Public Const TSIAccess = "TSIAccess"
        Public Const RSIAccess = "RSIAccess"
        Public Const CRIAccess = "CRIAccess"
        Public Const LimitID = "LimitID"
        Public Const DemandCoolingLimit = "DemandCoolingLimit"

        'Public Const id As String = "MasterID"
        'Public Const model As String = "ManufacturerModelNumber"
        'Public Const manufacturer As String = "Manufacturer"
        'Public Const type As String = "Compre4ssorType"
        'Public Const hp As String = "Horsepower"


        ''        Public Const old_model As String = "OldModel"
        ''Public Const rae_part_number As String = "RAEPartNumber"
        'Public Const refrigerant As String = "refr"

        'Public Const SuctionMin As String = "minst"
        'Public Const SuctionMax As String = "maxst"
        'Public Const DischargeMin As String = "minct"
        'Public Const DischargeMax As String = "maxct"
        'Public Const Unloading As String = "unloading"
        'Public Const HeadCoolingFan As String = "hcfan"
        'Public Const HeadCoolingFanSuctionMin As String = "HcFan minst"
        'Public Const HeadCoolingFanSuctionMax As String = "HcFan maxst"
        'Public Const DemandC As String = "demandc"
        'Public Const DemandCSuctionMin As String = "Demandc minst"
        'Public Const DemandCSuctionMax As String = "Demandc maxst"
        'Public Const LiquidInjection As String = "liqinj"
        'Public Const LiquidInjectionSuctionMin As String = "liqinj minst"
        'Public Const LiquidInjectionSuctionMax As String = "liqinj maxst"
        'Public Const OilCool As String = "OilCool"
        'Public Const OilCoolSuctionMin As String = "OilCool minst"
        'Public Const OilCoolSuctionMax As String = "OilCool maxst"

        'Public Const TempApplication As String = "TempApplication"
        'Public Const OilDistSystem As String = "OilDistSystem"
        'Public Const CompressorFileName As String = "compfile"

    End Class


    Class ElectricalTable
        Public Const table_name As String = "Electrical"
        Public Const MasterID As String = "MasterID"
        Public Const Type1 As String = "Type"
        '  Public Const VoltageCOde As String = "VoltageCode"
        Public Const Voltage As String = "Voltage"
        Public Const Frequency As String = "Frequency"
        Public Const Phase As String = "Phase"
        Public Const MCC As String = "MCC"
        Public Const RLA As String = "RLA"
        Public Const LRA As String = "LRA"

    End Class

    Class coefficients_table
        Public Const table_name As String = "Coefficients"
        Public Const MasterID As String = "MasterID"
        Public Const CoefficientType As String = "CoefficientType"
        Public Const Frequency As String = "Frequency"
        Public Const CurveVoltage As String = "Voltage"
        Public Const SubCooling As String = "SubCooling"
        Public Const ConstantReturnGasTemp As String = "ConstantReturnGasTemp"
        Public Const ConstantSuperHeat As String = "ConstantSuperHeat"
        Public Const c0 As String = "C0"
        Public Const c1 As String = "C1"
        Public Const c2 As String = "C2"
        Public Const c3 As String = "C3"
        Public Const c4 As String = "C4"
        Public Const c5 As String = "C5"
        Public Const c6 As String = "C6"
        Public Const c7 As String = "C7"
        Public Const c8 As String = "C8"
        Public Const c9 As String = "C9"

    End Class


    'Class coefficients_10_table
    '    Public Const table_name As String = "Compr_Curves_10Cof"
    '    Public Const id As String = "Field1"
    '    Public Const model As String = "CompModel"
    '    Public Const file As String = "CompFile"
    '    Public Const type As String = "CompType"
    '    Public Const voltage As String = "Voltage"
    '    Public Const hp As String = "HP"
    '    Public Const refrigerant As String = "refr"
    '    Public Const c0 As String = "C0"
    '    Public Const c1 As String = "C1"
    '    Public Const c2 As String = "C2"
    '    Public Const c3 As String = "C3"
    '    Public Const c4 As String = "C4"
    '    Public Const c5 As String = "C5"
    '    Public Const c6 As String = "C6"
    '    Public Const c7 As String = "C7"
    '    Public Const c8 As String = "C8"
    '    Public Const c9 As String = "C9"
    '    Public Const A0 As String = "A0"
    '    Public Const A1 As String = "A1"
    '    Public Const A2 As String = "A2"
    '    Public Const A3 As String = "A3"
    '    Public Const A4 As String = "A4"
    '    Public Const A5 As String = "A5"
    '    Public Const A6 As String = "A6"
    '    Public Const A7 As String = "A7"
    '    Public Const A8 As String = "A8"
    '    Public Const A9 As String = "A9"
    '    Public Const W0 As String = "W0"
    '    Public Const W1 As String = "W1"
    '    Public Const W2 As String = "W2"
    '    Public Const W3 As String = "W3"
    '    Public Const W4 As String = "W4"
    '    Public Const W5 As String = "W5"
    '    Public Const W6 As String = "W6"
    '    Public Const W7 As String = "W7"
    '    Public Const W8 As String = "W8"
    '    Public Const W9 As String = "W9"
    'End Class

    'Class coefficients_5_table
    '    Public Const table_name As String = "Compr_Curves"
    '    Public Const file_name As String = "FileName"
    '    Public Const c0 As String = "C0"
    '    Public Const c1 As String = "C1"
    '    Public Const c2 As String = "C2"
    '    Public Const c3 As String = "C3"
    '    Public Const c4 As String = "C4"
    '    Public Const a0 As String = "A0"
    '    Public Const a1 As String = "A1"
    '    Public Const a2 As String = "A2"
    '    Public Const a3 As String = "A3"
    '    Public Const a4 As String = "A4"
    '    Public Const w0 As String = "W0"
    '    Public Const w1 As String = "W1"
    '    Public Const w2 As String = "W2"
    '    Public Const w3 As String = "W3"
    '    Public Const w4 As String = "W4"
    'End Class

    'Class compressor_amps_table
    '    Public Const table_name As String = "Compressor_Amps"
    '    Public Const file_name As String = "Compressor_File_Name"
    '    Public Const unit_type As String = "Model_Type"
    '    Public Const phase As String = "Phase"
    '    Public Const voltage As String = "Voltage"
    '    Public Const hertz As String = "Hertz"
    '    Public Const amps As String = "Amps"
    '    Public Const CompressorFileName = "Compressor_file_name"
    'End Class

End Namespace