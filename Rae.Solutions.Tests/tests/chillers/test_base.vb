public class test_base
   protected sub assert(condition as boolean, optional message as string = "")
      Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(condition, message)
   end sub
   
   protected function round(number as double, optional decimal_places as integer = 0) as double
      return system.math.round(number, decimal_places)
   end function
   
   protected sub log(message as object)
      System.Diagnostics.Debug.WriteLine(message.toString())
   end sub

end class