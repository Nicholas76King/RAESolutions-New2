Namespace rae.solutions.compressors

    'Class bitzer_scroll_compressor_limits : Inherits compressor_limits_base

    '    Sub New(ByVal compressor As compressor, ByVal suction_temp As Double, ByVal discharge_temp As Double)
    '        Dim d, s, smin, smax, dmin, dmax As Double
    '        s = suction_temp
    '        d = discharge_temp
    '        smin = 5
    '        smax = 60
    '        dmin = 70
    '        dmax = 150

    '        _exceeded = True
    '        If s < smin Then
    '            _suction_is_below_min = True
    '        ElseIf s > smax Then
    '            _suction_is_above_max = True
    '        ElseIf d < dmin Or d < (20 / 19) * s + 26.84 Then
    '            _discharge_is_below_min = True
    '        ElseIf d > dmax Or d > (55 / 35) * s + 87.143 Then
    '            _discharge_is_above_max = True
    '        Else
    '            _exceeded = False
    '        End If
    '    End Sub

    'End Class



    'Class bitzer_octagons_high_temp_recip_compressor_limits : Inherits compressor_limits_base

    '    Sub New(ByVal compressor As compressor, ByVal suction_temp As Double, ByVal discharge_temp As Double)
    '        Dim d, s, smin, smax, dmin, dmax As Double
    '        s = suction_temp
    '        d = discharge_temp
    '        smin = -49
    '        smax = 45
    '        dmin = 50
    '        dmax = 131

    '        _exceeded = True
    '        If s < smin Then
    '            _suction_is_below_min = True
    '        ElseIf s > smax Then
    '            _suction_is_above_max = True
    '        ElseIf d < dmin Or d < (80 / 67) * s + 31.20866 Then
    '            _discharge_is_below_min = True
    '        ElseIf d > dmax Or d > (22 / 11) * s + 207 Then
    '            _discharge_is_above_max = True
    '        Else
    '            _exceeded = False
    '        End If
    '    End Sub

    'End Class


    'Class bitzer_octagons_low_temp_recip_compressor_limits : Inherits compressor_limits_base

    '    Sub New(ByVal compressor As compressor, ByVal suction_temp As Double, ByVal discharge_temp As Double)
    '        Dim d, s, smin, smax, dmin, dmax As Double
    '        s = suction_temp
    '        d = discharge_temp
    '        smin = -49
    '        smax = 15
    '        dmin = 50
    '        dmax = 131

    '        'NEwCompressor

    '        _exceeded = True
    '        If s < smin Then
    '            _suction_is_below_min = True
    '        ElseIf s > smax Then
    '            _suction_is_above_max = True
    '        ElseIf d < dmin OrElse d < (80 / 67) * s + 31.20866 Then
    '            _discharge_is_below_min = True
    '        ElseIf d > dmax OrElse d > (22 / 11) * s + 207 Then
    '            _discharge_is_above_max = True
    '        Else
    '            _exceeded = False
    '        End If
    '    End Sub

    'End Class



End Namespace