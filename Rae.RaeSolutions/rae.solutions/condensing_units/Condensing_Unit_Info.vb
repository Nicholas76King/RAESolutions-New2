namespace rae.solutions.condensing_units

public class Condensing_Unit_Info

   sub new(model as string)
      me.model = model
   end sub

   public length, width, height as double
   public shipping_weight, operating_weight as double
   public refrigerant as string

   property model as string
      get
         return _model
      end get
      set(value as string)
         _model = value
         get_info()
      end set
   end property

   private _model as string
   
   private sub get_info()
      if string.IsNullOrEmpty(Me._model) then
         _reset_properties_to_defaults()
         dim message = "The information for the condensing unit model cannot be found. "
         message &= "The condensing unit model is null or empty."
         throw new ArgumentException(message)
      end if

      dim condensing_unit = new Repository().get_unit(me._model)

      if condensing_unit is nothing then
         _reset_properties_to_defaults()
         dim message = "The specifications for the condensing unit model, " & _model & ", cannot be found. "
         message &= "The condensing unit model is not listed."
         throw new ApplicationException(message)
      end if

      _set_dimensions(condensing_unit)

      refrigerant      = condensing_unit.refrigerant.value
      shipping_weight   = condensing_unit.shipping_weight
      operating_weight  = condensing_unit.operating_weight
   end sub
   
   private sub _set_dimensions(condensing_unit as Condensing_Unit)
      ' some dimensions in database are null
      if string.isNullOrEmpty(condensing_unit.dimensions)
         _set_dimensions_to_zero()
         log("Dimensions are not available for this condensing unit model.")
      else
         dim dimensions = condensing_unit.dimensions
         ' removes double quotes
         dimensions = dimensions.Replace("""", "")
         ' parses length, width and height from dimensions text
         try
            dim dimensions_parser = new rae.math.Dimensions(dimensions)
            length = dimensions_parser.Length
            width  = dimensions_parser.Width
            height = dimensions_parser.Height
         catch ex as ArgumentNullException
            _set_dimensions_to_zero() : Console.WriteLine(ex.Message) : Console.WriteLine("Reset dimensions")
         catch ex as FormatException
            _set_dimensions_to_zero() : Console.WriteLine(ex.Message) : Console.WriteLine("Reset dimensions")
         end try
      end if
   end sub

   private sub _set_dimensions_to_zero()
      length = 0 : width = 0 : height = 0
   end sub

   private sub _reset_properties_to_defaults()
      _set_dimensions_to_zero()
      refrigerant = ""
   end sub
   
   private sub log(message as string)
      system.diagnostics.debug.writeLine(message)
   end sub

end class

end namespace