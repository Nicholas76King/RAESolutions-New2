namespace rae.solutions.compressors

    'class compressor_limits_base : implements i_compressor_limits

    '   function suction_is_below_min() as boolean implements i_compressor_limits.suction_is_below_min
    '      return _suction_is_below_min
    '   end function

    '   function suction_is_above_max() as boolean implements i_compressor_limits.suction_is_above_max
    '      return _suction_is_above_max
    '   end function

    '   function discharge_is_below_min() as boolean implements i_compressor_limits.discharge_is_below_min
    '      return _discharge_is_below_min
    '   end function

    '   function discharge_is_above_max() as boolean implements i_compressor_limits.discharge_is_above_max
    '      return _discharge_is_above_max
    '   end function

    '   function exceeded() as boolean implements i_compressor_limits.exceeded
    '      return _exceeded
    '   end function

    '   protected _exceeded, _suction_is_below_min, _suction_is_above_max, _discharge_is_below_min, _discharge_is_above_max as boolean

    'end class

end namespace