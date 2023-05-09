Imports Rae.Data.Access
Imports rae.solutions
Imports rae.solutions.compressors

<TestClass> _
Public Class given_compressor_ZR34K3E_with_refrigerant_407c : Inherits that_is_initialized
   Private model As String
   Private refrigerant As refrigerant
   Private voltage As Integer
   Private compressor As compressor
   
   Private Shared done As Boolean
   
   <TestInitialize> _
   Sub init
      model = "ZR34K3E"
      refrigerant = Refrigerant.parse("R407c")
      voltage = 230
      initializeConnection()
      
      dim repo = new compressor_repository()
      compressor = repo.get_compressor(model, refrigerant, voltage)
   End Sub
   
   <TestMethod> _
   Sub the_model_should_be_ZR34K3E
      IsTrue(compressor.model = model)
   End Sub
   
   <TestMethod> _
   Sub the_refrigerant_should_be_407c
      IsTrue(compressor.refrigerant Like "*407*")
   End Sub
   
   <TestMethod> _
   Sub the_compressor_file_should_be_ZR34K3Ep407
      IsTrue(compressor.file_name.toUpper = "ZR34K3E.407")
   End Sub
   
   <TestMethod> _
   Sub the_suction_temperature_minimum_should_be_negative_10
      IsTrue(compressor.suction_min = -10)
   End Sub
   
   <TestMethod> _
   Sub the_type_should_be_scroll
      IsTrue(compressor.type = compressor_type.Scroll)
   End Sub
   
   <TestMethod> _
   Sub unloading_should_be_no
      IsTrue(compressor.Unloading = "NO1")
   End Sub
   
   <TestMethod> _
   Sub liquid_injection_should_be_no
      IsTrue(compressor.LiquidInjection = "YES7")
   End Sub
   
End Class


Public Class that_is_initialized
   Protected Sub initializeConnection
      Dim appFolderPath = "C:\Code\Rae\Solutions\Main\Rae.Solutions\"
      Dim dbFolderPath  = "C:\Code\Rae\Solutions\Main\Rae.Solutions\Databases\"
      Rae.RaeSolutions.DataAccess.Common.Initialize(appFolderPath, dbFolderPath)
      
      Dim path = appFolderPath & "bin\RAESolutions.exe.config"
      Dim appNamespace = "Rae.RaeSolutions"
      Configuration.ConfigFactory.Initialize(path, appNamespace)
   End Sub
End Class

