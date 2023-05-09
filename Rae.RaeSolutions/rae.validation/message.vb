imports system.environment

namespace rae.validation

public class message
   sub new(status as validation_status, description as string)
      me.description = description
      me.status = status
   end sub
   public description as string
   public status as validation_status
end class

public enum validation_status
   bug
   failure
   warning
   info
end enum

public class message_list : inherits list(of message)
   overloads sub add(status as validation_status, description as string)
      mybase.add(new message(status, description))
   end sub

   overrides function toString() as string
      dim list = ""
      
      for each message in me
         list &= message.description & newline
      next
      
      if list <> "" then _
         list = list.remove(list.lastindexof(newline), 2)
      return list
   end function
end class

end namespace