Namespace rae.solutions.compressors

    Public Interface i_compressor_repository
        Function get_compressor(ByVal masterID As String, ByVal refrigerant As refrigerant, ByVal voltage As Integer, ByVal model_type As String, ByVal constantReturnGasTemp As String) As compressor
        Function get_compressors(ByVal refrigerant As refrigerant, ByVal voltage As Integer, ByVal model_type As String, ByVal constantReturnGasTemp As String) As List(Of compressor)
        Function get_compressors(ByVal refrigerant As refrigerant, ByVal voltage As Integer, ByVal suction As Double, ByVal model_type As String, ByVal overrideSafetyLimit As Boolean, ByVal constantReturnGasTemp As String) As List(Of compressor)
        '    Function get_rep_air_cooled_chiller_compressors(ByVal refrigerant As refrigerant, ByVal voltage As Integer, ByVal standard_hp As Double) As list(Of compressor)
        Function get_compressor_amps(ByVal file_name As String, ByVal unit_type As String, ByVal voltage As Integer, ByVal phase As Integer, ByVal hertz As Integer, ByVal division As String) As Double
    End Interface

End Namespace