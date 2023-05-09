option strict off

imports system.diagnostics

namespace rae.solutions

'new balance(polynomial, h1_equation, multiplier)
'point = balance.at(te,ta)
'point.q,w,a,tc,h2
public class balance_compressor_and_condenser
   sub new(polynomial, h1_calc, multiplier)
      me.polynomial  = polynomial
      me.calc        = h1_calc
      me.multiplier  = multiplier
   end sub
   
   function at(te,ta) as point
      dim h1,h2,q,w,a
      dim tc = ta + 10
      do
         tc += .2
         debug.assert(tc < 190, "The compressor and condenser balance is not converging. Condensing Temperature: " & system.math.round(tc))
         if tc > 190 then throw new exception("The compressor and condenser balance is not converging. Condensing Temperature: " & system.math.round(tc))
         h1 = calc.h1(tc,ta)
         dim result = polynomial.calculate(te,tc)
         q = result.q * multiplier.q
         w = result.w * multiplier.w
         a = result.a * multiplier.a
         h2 = q + (3.415 * w)
      loop while (h1<h2)
      
      return new point(q,w,a,tc,h2)
   end function
   
   private polynomial, calc, multiplier
   
   class point
      sub new(q,w,a,tc,h2)
         me.q=q : me.w=w : me.a=a : me.tc=tc : me.h2=h2
      end sub
      public q,w,a,tc,h2
   end class

end class

end namespace