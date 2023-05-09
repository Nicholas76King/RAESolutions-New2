imports rae.io.text

namespace rae.solutions.air_cooled_chillers_beta

public class coil
   public number_of_rows as double
   public subcooling as boolean
   public fin_height, fin_length, fpi as double

   readonly property description as string
      get
         dim subcooling_indicator = if(subcooling, "-S/C", "")
         dim d = str("{0}C{1}X{2}-{3}-{4}-1C{5}",
                     "12", fin_height, fin_length, fpi, number_of_rows, subcooling_indicator)
         return d
      end get
   end property
end class

end namespace
