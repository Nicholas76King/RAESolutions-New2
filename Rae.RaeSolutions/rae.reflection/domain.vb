imports system.reflection

namespace rae.reflection

<System.CLSCompliant(false)> _
class domain

   ''' <summary>clones structure or object with parameterless constructor by copying public fields</summary>
   shared function clone(of t)(original as t) as t
      if getType(t).isValueType then return original
      
      if original is nothing then return nothing
      dim cloned = reflector.construct(of t)()
      
      dim public_fields = original.getType.getFields(bindingFlags.public or bindingFlags.instance)
      
      for each field in public_fields
         dim original_value = field.getValue(original)
         field.SetValue(cloned, original_value)
      next
      
      return cloned
   end function
   
   shared function are_equal(of t)(x as t, y as t) as boolean
      dim fields = x.getType.getFields(bindingFlags.public or bindingFlags.instance)
      
      for each field in fields
         dim x_value = field.getValue(x)
         dim y_value = field.getValue(y)
         ' if value is nothing then can't call equals method otherwise get exception
         if x_value is nothing and y_value isNot nothing then return false
         if y_value is nothing and x_value isNot nothing then return false
         if not (x_value is nothing and y_value is nothing) then
            if not field.getValue(x).equals(field.getValue(y)) then return false
         end if
      next
      return true
   end function

end class

end namespace