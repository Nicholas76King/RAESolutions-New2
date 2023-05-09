imports rae.solutions
imports rae.ui.quickies

partial public class air_cooled_chiller_balance_window
   implements fluid_properties.i_view_part
   
   writeonly property freeze_point as string _
   implements fluid_properties.i_view_part.freeze_point
      set(value as string)
         txtFreezingPoint.text = value
      end set
   end property

   writeonly property min_suction_temperature as string _
   implements fluid_properties.i_view_part.min_suction_temperature
      set(value as string)
         txtSuctionTemp.text = value
      end set
   end property

   property glycol_percentage as double _
   implements fluid_properties.i_view_part.glycol_percentage
      set(value as double)
         txtGlycolPercentage.text = value
      end set
      get
         return val(txtGlycolPercentage.text)
      end get
   end property

   readonly property fluid as CoolingMedia _
   implements fluid_properties.i_view_part.fluid
      get
         return CoolingFluid
      end get
   end property

end class