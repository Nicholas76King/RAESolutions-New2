Imports Rae.Data.Access
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert

<TestClass()> Public Class IdentitiesDataAccessTests

   <TestMethod()> _
   Sub Identities_CanRetrieveEmployeeUsernames()
      Dim identities As Identities = DataAccessFactory(Of Identities).Create()
      Dim employees As List(Of String) = identities.RetrieveEmployeeUsernames()
      
      IsTrue(employees.Count > 0)
      IsTrue(employees.Contains("CASEYJ"))
      IsFalse(employees.Contains("Jim Carabello"))
   End Sub

End Class
