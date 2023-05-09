namespace evaporative_condenser_chillers

class option_control : implements i_option_control

   property checked as boolean _
   implements i_option_control.checked
      get
         return chk_option.checked
      end get
      set(value as boolean)
         chk_option.checked = value
      end set
   end property
   
   property notify_user as boolean _
   implements i_option_control.notify_user
      get
         return _notify_user
      end get
      set(value as boolean)
         _notify_user = value
      end set
   end property
   private _notify_user as boolean = true

   property [option] as [option] _
   implements i_option_control.option
      get
         return _option
      end get
      set(value as [option])
         _option = value
         chk_option.text = _option.description
         lbl_long_description.text = "" '_option.code & " - " & _option.long_description
      end set
   end property
   
   public event check_changed(control as i_option_control) _
   implements i_option_control.check_changed
   
   protected sub on_check_changed()
      if check_changedevent isnot nothing then
         raiseevent check_changed(me)
      end if
   end sub
   
   private sub chk_option_check_changed() _
   handles chk_option.checkedChanged
      on_check_changed()
   end sub
   
   private _option as [option]

   private sub lbl_long_description_sizechanged() _
   handles lbl_long_description.sizeChanged
      dim preferred_size = lbl_long_description.PreferredSize
      dim number_of_lines = system.math.ceiling(preferred_size.width / lbl_long_description.size.width)
      
      if preferred_size.width > lbl_long_description.size.width then _
         lbl_long_description.height = 21 * number_of_lines
   end sub
   
   private sub me_docked() _
   handles me.ParentChanged
      dock = dockstyle.top
   end sub
end class

end namespace