namespace rae.validation
   
public interface i_validate
   function validate() as i_validate
   readonly property is_valid as boolean
   readonly property is_invalid as boolean
   readonly property messages as message_list
end interface

end namespace