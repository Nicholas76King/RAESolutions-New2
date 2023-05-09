class grabber
   function price(control as control) as double
      price = 0
        If control.Text.Length > 0 AndAlso IsNumeric(control.Text) Then _
         price = Double.Parse(control.Text, Globalization.NumberStyles.Currency)
   end function
end class