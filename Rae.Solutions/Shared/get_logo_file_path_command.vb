imports rae.solutions

class get_logo_file_path_command
   private user as user
   private division as string
   
   sub new(user as user, division as string)
      me.user = user
      me.division = division
   end sub

   function execute as string
      if user.can(rae.solutions.group.choose_report_logo) then
         division = new which_division().ask({"TSI", "CRI", "RSI", "RAE"})
      end if
      dim logo_file_name = division & "_report_logo.gif"
      dim logo_file_path = system.io.path.combine(AppInfo.image_folder_path, logo_file_name)
      return logo_file_path
    End Function

    Function executeWithLogo(ByVal division As String) As String
        Dim logo_file_name = division & "_report_logo.gif"
        Dim logo_file_path = System.IO.Path.Combine(AppInfo.image_folder_path, logo_file_name)
        Return logo_file_path
    End Function
end class