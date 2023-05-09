Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert

<TestClass> _
Public Class CommonOptionsTests
   
   Private Shared series As String = "20A0CS"
   Private Shared model As String = "10"
  
   
   <TestMethod> _
   Sub ChangeVoltage
      Dim code = "EB03" : Dim numFans = 0
        Dim ops = OptionsDataAccess.RetrieveAvailableOptions(series, model, voltage:=230, numFans:=numFans, fanMotorPhase:=0)
   	Dim op230 = ops.Where( Function(x) x.Code=code )
        Dim op460 = OptionsDataAccess.RetrieveOption(series, model, code, voltage:=460, numFans:=numFans, fanMotorPhase:=0)
   	
   	IsTrue( op460.Code = code )
   	IsTrue( op460.Voltage = 460 )
   End Sub
   
End Class