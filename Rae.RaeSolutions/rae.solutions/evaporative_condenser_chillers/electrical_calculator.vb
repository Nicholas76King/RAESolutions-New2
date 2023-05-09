option strict off

namespace rae.solutions.evaporative_condenser_chillers

class electrical_calculator : inherits rae.solutions.drawings.ecalc
   
   function rla(compressor_1,compressor_quantity_1,compressor_2,compressor_quantity_2, _
                blower,spray_pump,condenser_quantity, voltage, et02, division) as double
      rla = compressor_1 * compressor_quantity_1 _
          + compressor_2 * compressor_quantity_2 _
          + blower * condenser_quantity + spray_pump * condenser_quantity _
          + t(division)
          
      if et02 then rla += outlet(voltage)
      
      rla = rnd(rla)
   end function
   
   ' if there are 2 circuits this is rla for one of the circuits
   function rla_1(compressor_1,compressor_quantity_1,compressor_2,compressor_quantity_2, _
                  blower,spray_pump,condenser_quantity, voltage, et02, division) as double
      if condenser_quantity = 1
         rla_1 = compressor_1*compressor_quantity_1 + blower + spray_pump + t(division)
      else
         rla_1 = compressor_1*compressor_quantity_1 _
               + blower*condenser_quantity/2 + spray_pump*condenser_quantity/2 + t(division)
      end if
      if et02 then rla_1 += outlet(voltage)
      rla_1 = rnd(rla_1)
   end function
   
   ' if there are 2 circuits this is rla for the other circuit
   function rla_2(compressor_1,compressor_quantity_1,compressor_2,compressor_quantity_2, _
                  blower,spray_pump,condenser_quantity) as double
      if condenser_quantity = 1
         rla_2 = compressor_2*compressor_quantity_2
      else
         rla_2 = compressor_2*compressor_quantity_2 _
               + blower*condenser_quantity/2 + spray_pump*condenser_quantity/2
      end if
      rla_2 = rnd(rla_2)
   end function

end class
end namespace