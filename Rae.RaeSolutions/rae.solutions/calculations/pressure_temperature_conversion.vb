imports rae.solutions.refrigerant
Imports System.Math

namespace rae.solutions

public class pressure_temperature_conversion
        'function pe(te as double, refg as refrigerant) as double
        '   dim t = Convert.FahrenheitToRankine(te)

        '   dim p = 29.35754453 + -3845.193152/t + -7.86103122*(log(t)/log(10)) + 0.002190939*t + (0.445746703*(686.1-t)/t)*(log(686.1-t) / log(10))
        '   pe = 10^p

        '   if refg = R407c
        '      p = 78.3549 + -8101.06/t + -9.51789*log(t) + 0.0000053558*(t^2)
        '      pe = e^p
        '   elseif refg = R507
        '      p = 29.24862663 + -6980.5944/t + -0.03143806111*t + 0.00002034543662*t^2
        '      pe = e^p
        '   elseif refg = R134a
        '      p = 22.98993635 + -7243.876722/t + -0.013362956*t + 0.00000692966*t^2 + ((0.1995548*(674.72514-t))/t) * log(674.72514-t)
        '      pe = e^p
        '   elseif refg = R404a
        '      p = 72.1209 + -7315.14/t + (-8.717729*log(t) + 0.0000051875*t^2)
        '      pe = e^p
        '   end if
        'end function
   
        'function pc(tc as double, refg as refrigerant) as double
        '   dim t = Convert.FahrenheitToRankine(tc)

        '   dim p = 29.35754453 + -3845.193152/t + -7.86103122*(log(t)/log(10)) + 0.002190939*t + 0.445746703*(686.1-t)/t*log(686.1-t)/log(10)
        '   pc = 10^p

        '   if refg = R407c
        '      p = 43.3622 + -6020.28/t + -4.3987*log(t) + 0.00000212036*t^2
        '      pc = e^p
        '   ElseIf refg = R507
        '      p = 29.24862663 + -6980.5944/t + -0.03143806111*t + 0.00002034543662*t^2
        '      pc = e^p
        '   elseif refg = R134a
        '      p = 22.98993635 + -7243.876722/t + -0.013362956*t + 0.00000692966*t^2 + ((0.1995548*(674.72514-t))/t) * log(674.72514-t)
        '      pc = e^p
        '   elseif refg = R404a
        '      p = 57.5895 + -6526.55/t + -6.58061*log(t) + 0.00000393732*t^2
        '      pc = e^p
        '   end if
        'end function
   
end class

end namespace