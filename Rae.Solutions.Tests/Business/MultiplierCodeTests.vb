Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert
Imports Rae.RaeSolutions.Business.Entities

<TestClass()> _
Public Class MultiplierCodeTests

   <TestMethod()> _
   Sub MultiplierCode_CanEncryptAndDecrypt()
      ' encrypt
      Dim c1 As New MultiplierCode( _
         "CaseyJ", "Jim Carabello", Date.Now(), 0.375, 0.19)
      Dim encryptedCode As String = c1.Code
      My.Application.Log.WriteEntry(encryptedCode)
      ' decrypt
      Dim c2 As New MultiplierCode(encryptedCode)
      
      IsTrue(c1.AssignedBy = c2.AssignedBy)
      IsTrue(c1.AssignedTo = c2.AssignedTo)
      IsTrue(c1.Multiplier = c2.Multiplier)
      IsTrue(c1.Commission = c2.Commission)
      ' dates are not equal because milliseconds are different
      IsFalse(c1.AssignedOn = c2.AssignedOn)
      ' milliseconds are not included in ToString format
      IsFalse(c1.AssignedOn.Millisecond = c2.AssignedOn.Millisecond)
      ' the year, month, day, hour, minute and seconds are equal
      IsTrue(c1.AssignedOn.Date = c2.AssignedOn.Date)
      ' not including hour, minute or second
      ' they lengthen the generated code for the rep too much
      'IsTrue(c1.AssignedOn.Hour = c2.AssignedOn.Hour)
      'IsTrue(c1.AssignedOn.Minute = c2.AssignedOn.Minute)
      'IsTrue(c1.AssignedOn.Second = c2.AssignedOn.Second)
   End Sub
   
   <TestMethod()> _
   Sub MultiplierCode_ChecksIfExpired()
      Dim code As New MultiplierCode("Me", "You", Date.Now, 1, 2)
      IsFalse(code.IsExpired(Date.Now))
   End Sub

End Class
