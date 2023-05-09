imports rae.validation
imports System.Text.RegularExpressions

class text_number : inherits textbox

   private validators as validator_list

   sub new()
      validators = new validator_list()
      validators.add(new number(me))
   end sub

   function only as text_number
      validators.clear
      return me
   end function

   function required as text_number
      validators.add(new required(me))
      return me
   end function

   function positive_number
      validators.add(new positive_number(me))
      return me
   end function

   property message_margin as integer = 5

   readonly property valid as boolean
      get
         return _valid
      end get
   end property
   private _valid as boolean

   function validate as boolean
      _valid = validators.validate.is_valid
      if valid then 
         format_valid
         remove_inline_message
      else 
         format_invalid
         add_inline_message(validators.messages.toString)
      end if
      return valid
   end function
   
   private inline_message_label as label

   private sub add_inline_message(message as string)
      if not inline_message_label is nothing then
         me.parent.controls.remove(inline_message_label)
         inline_message_label.dispose()
         inline_message_label = nothing
      end if
      inline_message_label = new label() with {
         .autosize = true,
         .text = message,
         .top = top + 4,
         .left = left + width + message_margin,
         .forecolor = color.red }
      me.parent.controls.add(inline_message_label)
      inline_message_label.BringToFront
   end sub

   private sub remove_inline_message()
      if not inline_message_label is nothing then 
         me.parent.controls.remove(inline_message_label)
         inline_message_label.dispose
         inline_message_label = nothing
      end if
   end sub

   private sub format_valid
      backcolor = color.white
   end sub

   private sub format_invalid
      backcolor = color.pink
   end sub

   private sub text_changed(sender as object, e as EventArgs) handles me.TextChanged
      validate
   end sub

   private sub key_down(sender as object, e as KeyEventArgs) handles me.KeyDown
      e.SuppressKeyPress = not key_code.is_number(e.KeyCode)
   end sub

end class

class required : inherits validator_base
   private control as control

   sub new(control as control)
      me.control = control
   end sub
      
   overrides function validate as i_validate
      messages.clear
      valid = not String.IsNullOrEmpty(control.text)
      if is_invalid then messages.add(validation_status.warning, "Required")
      return me
   end function
end class

class number : inherits validator_base
   private control as control

   sub new(control as control)
      me.control = control
   end sub

   overrides function validate as i_validate
      messages.clear
      valid = RegEx.IsMatch(control.text, regular_expressions.number)
      if is_invalid then messages.add(validation_status.warning, "Must be number")
      return me
   end function
end class

class positive_number : inherits validator_base
   private control as control

   sub new(control as control)
      me.control = control
   end sub

   overrides function validate as i_validate
      messages.clear
      valid = RegEx.IsMatch(control.text, regular_expressions.positive_number)
      if is_invalid then messages.add(validation_status.warning, "Positive number")
   end function
end class