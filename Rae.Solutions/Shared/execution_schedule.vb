''' <summary>
''' dim schedule = execution_schedule.Execute(method).on(form).after_last_change_to(value).is_unchanged_for(msec:=500)
''' schedule.change(value)
''' </summary>
class execution_schedule
   private method as command
   private previous_value as string
   private withevents timer as timers.timer
   
   private sub new(method as command)
      me.method = method
      timer = new timers.timer()
      timer.autoreset = false ' raise elapsed event only once after delay
      enabled = true
   end sub
   
   shared function Execute(method as command) as execution_schedule
      dim schedule = new execution_schedule(method)
      return schedule
   end function
   
   function [on](form as form) as execution_schedule
      timer.SynchronizingObject = form ' execute elapsed event on ui thread
      return me
   end function
   
   function after_last_change_to(value as string) as execution_schedule
      previous_value = value
      return me
   end function
   
   function is_unchanged_for(msec as integer) as execution_schedule
      timer.interval = msec
      return me
   end function
   
   sub change(value as string)
      if disabled then
         method.invoke()
      elseif previous_value <> value then
         timer.stop()
         timer.start()
      end if
   end sub
   
   sub disable()
      timer.stop()
      enabled = false
   end sub
   
   sub enable()
      enabled = true
   end sub
   
   private enabled as boolean
   
   private function disabled() as boolean
      return not enabled
   end function
   
   private sub timer_elapsed(sender as object, e as timers.ElapsedEventArgs) handles timer.elapsed
      if enabled then
         method.invoke()
      end if
   end sub
   
end class