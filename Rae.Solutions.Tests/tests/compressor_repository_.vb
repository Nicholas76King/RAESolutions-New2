Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert
Imports rae.solutions.compressors
Imports rae.solutions
Imports Rae.Data.Access

<TestClass> _
Public Class compressor_repository_

   Private repo As i_compressor_repository

   <TestInitialize> _
   Sub init
      config.db
      repo = new compressor_repository()
   End Sub
   
   <TestMethod> _
   Sub should_get_10_coef_for_
      Dim refg = refrigerant.parse("407c")
      Dim c = repo.get_compressor("ZRT320KCE", refg, 230)
      
      IsTrue( c.num_coef = 10 )
   End Sub
   
   <TestMethod> _
   Sub should_get_5_coef_for_
      Dim refg = refrigerant.parse("R22H")
      Dim c = repo.get_compressor("06DA328", refg, 230)
      
      IsTrue( c.num_coef = 5 )
   End Sub
   
End Class
