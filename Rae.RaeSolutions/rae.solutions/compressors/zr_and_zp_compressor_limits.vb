namespace rae.solutions.compressors

    'class zr_and_zp_compressor_limits : inherits compressor_limits_base

    '   sub new(compressor as compressor, suction_temp as double, discharge_temp as double)
    '      dim s = suction_temp
    '      dim d = discharge_temp
    '      dim smin = -10
    '      dim smax = 55
    '      dim dmin = 80
    '      dim dmax = 150

    '      _exceeded = true
    '      if s < smin
    '         _suction_is_below_min = true
    '      elseIf s > smax
    '         _suction_is_above_max = true
    '      elseIf d < dmin
    '         _discharge_is_below_min = true
    '      elseIf d > dmax or d > 1*s + 110
    '         _discharge_is_above_max = true
    '      else
    '         _exceeded = false
    '      end if
    '   end sub

    'end class

end namespace