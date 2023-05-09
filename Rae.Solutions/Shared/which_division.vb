imports Rae.RaeSolutions.Persistence

class which_division
   function ask(divisions as string()) as string
      dim message = "Which logo do you want on the report?"

      dim commands = new StringDictionary()
      for each division in divisions
         commands.add(division, "Show " & division & " Logo")
      next

      dim prompt as Persistence.IAskUserToSave
      prompt = new Persistence.AskUserToSave(message, 
         new string() {}, _
         commands)
            
      return prompt.ask().SelectedCommand
   end function
end class