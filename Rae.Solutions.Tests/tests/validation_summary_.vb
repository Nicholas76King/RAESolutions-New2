Imports Rae.Validation
Imports rae.validation.validation_status
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert

<TestClass> _
Public Class validation_tests

   <TestMethod> _
   Sub validation_summary_with_1_valid_validator_is_valid
      Dim summary = New validator_list()
      summary.Add( New foo_validator(isValid:=True) )
      summary.Validate()
      IsTrue(summary.is_valid)
   End Sub
   
   <TestMethod> _
   Sub validation_summary_with_1_valid_and_1_invalid_validator_is_invalid
      Dim summary = New validator_list()
      summary.Add( New foo_validator(isValid:=False) )
      summary.Add( New foo_validator(isValid:=True) )
      summary.Validate()
      IsTrue(summary.is_invalid)
   End Sub
   
   <TestMethod> _
   sub validation_summary_contains_its_validators_messages
      dim summary = new validator_list()
      summary.add( new message_validator("message 1") )
      summary.add( new message_validator("message 2") )
      summary.add( new foo_validator(isvalid:=true) )
      summary.validate()
      istrue(summary.messages.count = 2)
      istrue(summary.messages(0).description = "message 1")
      istrue(summary.messages(1).description = "message 2")
   end sub
   
End Class


class foo_validator : inherits validator_base
   sub new(isvalid as boolean)
      valid = isvalid
   end sub
end class

class message_validator : inherits validator_base
   sub new(message as string)
      _messages.add( new message(validation_status.failure, message) )
   end sub
end class
