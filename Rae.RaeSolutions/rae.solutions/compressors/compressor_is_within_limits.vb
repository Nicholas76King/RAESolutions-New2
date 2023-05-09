option strict off

imports rae.validation
imports rae.validation.validation_status

namespace rae.solutions.compressors

public class compressor_is_within_limits : inherits validator_base
   sub new(compressor as compressor, suction_temp as double, discharge_temp as double)
      me.compressor = compressor
      me.suction_temp = suction_temp
      me.discharge_temp = discharge_temp
   end sub
   
   overrides function validate() as i_validate
      _messages.clear()

            Dim SuccessFlag As Boolean = False

            Dim cLSI As New CompressorLimits(Me.compressor.limitID, False, successFlag)
            Dim isValid As Boolean = cLSI.Valid(CSng(suction_temp), CSng(discharge_temp))

            If Not isValid Then
                _messages.add(failure, "Suction or Discharge Temperature is outide of the operating range!")
            End If

            valid = isValid


            '      Dim limits = New compressor_limits_factory().create(compressor, suction_temp, discharge_temp)

            'valid = false
            'if limits.discharge_is_above_max then
            '   _messages.add( new message(failure, "the discharge temperature, " & discharge_temp & ", is above the max") )
            'elseIf limits.discharge_is_below_min then
            '   _messages.add( new message(failure, "the discharge temperature, " & discharge_temp & ", is below the minimum") )
            'elseIf limits.suction_is_above_max then
            '   _messages.add( new message(failure, "the suction temperature, " & suction_temp & ", is above the max") )
            'elseIf limits.suction_is_below_min then
            '   _messages.add( new message(failure, "the suction temperature, " & suction_temp & ", is below the minimum") )
            'else
            '   valid = true
            'end if
      
      return me
   end function
   
   private compressor as compressor
   private suction_temp, discharge_temp as double
end class

end namespace