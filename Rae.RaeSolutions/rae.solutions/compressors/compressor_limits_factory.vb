namespace rae.solutions.compressors

    'public class compressor_limits_factory
    '        Function create(ByVal compressor As compressor, ByVal suction_temp As Double, ByVal discharge_temp As Double) As i_compressor_limits
    '            Dim limits As i_compressor_limits
    '            'NEwCompressor
    '            If compressor.model Like "ZR*" Or compressor.model Like "ZP*" Then
    '                limits = New zr_and_zp_compressor_limits(compressor, suction_temp, discharge_temp)
    '            ElseIf compressor.model Like "GSD*" Then
    '                limits = New bitzer_scroll_compressor_limits(compressor, suction_temp, discharge_temp)

    '            ElseIf compressor.model Like "*L" AndAlso compressor.manufacturer.ToLower = "bitzer" Then
    '                limits = New bitzer_octagons_low_temp_recip_compressor_limits(compressor, suction_temp, discharge_temp)
    '            ElseIf compressor.model Like "*H" AndAlso compressor.manufacturer.ToLower = "bitzer" Then
    '                limits = New bitzer_octagons_high_temp_recip_compressor_limits(compressor, suction_temp, discharge_temp)
    '            ElseIf compressor.TempApplication = "L" AndAlso compressor.manufacturer.ToLower = "bitzer" Then
    '                limits = New bitzer_octagons_low_temp_recip_compressor_limits(compressor, suction_temp, discharge_temp)
    '            ElseIf compressor.TempApplication = "H" AndAlso compressor.manufacturer.ToLower = "bitzer" Then
    '                limits = New bitzer_octagons_high_temp_recip_compressor_limits(compressor, suction_temp, discharge_temp)
    '            Else
    '                limits = New db_compressor_limits(compressor, suction_temp, discharge_temp)
    '            End If

    '            Return limits
    '        End Function
    'end class

end namespace