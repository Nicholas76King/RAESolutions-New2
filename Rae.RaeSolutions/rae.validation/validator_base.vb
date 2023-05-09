namespace rae.validation

public class validator_base : implements i_validate

   sub new()
      _messages = new message_list()
   end sub

   readonly property is_valid as boolean _
   implements i_validate.is_valid
      get
         return valid
      end get
   end property
   
   readonly property is_invalid as boolean _
   implements i_validate.is_invalid
   	get
   		return not valid
   	end get
   end property
   
   readonly property messages as message_list _
   implements i_validate.messages
   	get
   		return _messages
   	end get
   end property

   overridable function validate() as i_validate implements i_validate.validate
      return me
   end function
   
   protected valid as boolean
   protected _messages as message_list
end class

end namespace