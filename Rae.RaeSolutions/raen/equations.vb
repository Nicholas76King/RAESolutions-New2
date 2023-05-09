option strict off

namespace raen.math

module equations
   function floor(num as double) as double
      return System.Math.Floor(num)
   end function
   
   function floor(num as double, multiple as integer) as double
      return Rae.Math.Calculate.Floor(num, multiple)
   end function
   
   function avg(num1, num2) as double
      return (num1 + num2) / 2
   end function
   
   function round(value, optional digits = 0) as double
      return system.math.round(value, digits)
   end function
   
end module

end namespace