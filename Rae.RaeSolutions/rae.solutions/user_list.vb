imports rae.collections

namespace rae.solutions.credentials

class user_list : inherits StringList

   shadows function add(group as group) as user_list
      for each user in group.value
         if not contains(user) then
            mybase.add(user)
         end if
      next
      
      return me
   end function
   
   shadows function add(paramarray items() as string) as user_list
      for each user in items
         if not contains(user) then
            mybase.add(user)
         end if
      next
      return me
   end function
   
end class

end namespace