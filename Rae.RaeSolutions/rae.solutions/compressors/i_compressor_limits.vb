namespace rae.solutions.compressors

public interface i_compressor_limits
   function suction_is_below_min() as boolean
   function suction_is_above_max() as boolean
   function discharge_is_below_min() as boolean
   function discharge_is_above_max() as boolean
   function exceeded() as boolean
end interface

end namespace