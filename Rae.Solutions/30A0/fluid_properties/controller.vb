imports rae.solutions
imports rae.ui.quickies

namespace fluid_properties

interface i_view_part
   readonly property fluid as coolingMedia
   property glycol_percentage as double
   writeonly property freeze_point as string
   writeonly property min_suction_temperature as string
end interface

class controller
   private view_part as i_view_part

   sub new(view_part as i_view_part)
      me.view_part = view_part
   end sub

   sub handle_fluid_changed()
      dim fluid = new FluidFactory().Create(view_part.fluid, view_part.glycol_percentage)

      if fluid.PercentageInRange then
         view_part.freeze_point = fluid.FreezePoint
         view_part.min_suction_temperature = fluid.MinSuctionTemp
      else
         warn( msg(fluid.min, fluid.max) )
         view_part.glycol_percentage = 20
      end if
   end sub

   private function msg(min, max) as string
      return "Glycol percentage must be in the range " & min & "% to " & max & "%. " & _
             "Glycol percentage is being reset to 20%."
   end function

end class

end namespace