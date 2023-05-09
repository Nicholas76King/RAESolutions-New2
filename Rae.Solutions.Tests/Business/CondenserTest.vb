Imports System
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Math


<TestClass()> _
Public Class CondenserTest

#Region "Additional test attributes"
   '
   ' You can use the following additional attributes as you write your tests:
   '
   ' Use ClassInitialize to run code before running the first test in the class
   ' <ClassInitialize()> Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
   ' End Sub
   '
   ' Use ClassCleanup to run code after all tests in a class have run
   ' <ClassCleanup()> Public Shared Sub MyClassCleanup()
   ' End Sub
   '
   ' Use TestInitialize to run code before running each test
   ' <TestInitialize()> Public Sub MyTestInitialize()
   ' End Sub
   '
   ' Use TestCleanup to run code after each test has run
   ' <TestCleanup()> Public Sub MyTestCleanup()
   ' End Sub
   '
#End Region

   Private altitude As Double = 0
   Private ambient As Double = 95
   Private temperatureDifference As Double = 20
   Private fans As Double = 1
   Private coilWidth As Double = 25
   Private coilLength As Double = 28.75
   Private fanFile As String = "LAU2429"
   Private coilFile As String = "2RCOND"
   Private externalStaticPressure As Double = 0

   Private fpi As Integer = 8
   Private capacity As Double = 26873
   Private faceVelocity As Double = 1002
   Private staticPressure As Double = 0.44
   Private horsepower As Double = 0.71
   Private cfmActual As Double = 5002
   Private cfmStandard As Double = 4777
   Private capacityPerSquareFoot As Double = 5384


   '<TestMethod()> _
   'Public Sub CheckComCapacity()
   '   Dim wrapper As New Rae.RaeSolutions.Business.Intelligence.CondenserWrapper( _
   '      altitude, temperatureDifference, fans, coilWidth, coilLength, coilFile, fanFile)
   '   Assert.IsTrue(wrapper.CapacityAt8Fpi = 26873)
   'End Sub


   '<TestMethod()> _
   'Public Sub CheckComResults()
   '   Dim com As New RAEDLL_COFAN.RRAEDLL_COFAN()
   '   com.RAE_Input_Altitude_in_feet = altitude
   '   com.RAE_Input_Ambient_Temp_Degrees_F = ambient
   '   com.RAE_Input_Condenser_Fin_Length = coilLength
   '   com.RAE_Input_Condenser_Fin_Width = coilWidth
   '   com.RAE_Input_Condenser_Fins_Per_Inch = fpi
   '   com.RAE_Input_Number_of_Fans = fans
   '   com.RAE_Input_Temperature_Difference_Degrees_F = temperatureDifference
   '   com.RAE_COIL_FILE_NAME = coilFile
   '   com.RAE_FAN_FILE_NAME = fanFile
   '   com.RAE_COFAN_EXT = externalStaticPressure

   '   com.AddToDatabase()

   '   Assert.IsTrue(com.RAE_Out_COFAN_BTUHSF_Output1 = capacityPerSquareFoot)
   '   Assert.IsTrue(com.RAE_Out_COFAN_CAPACITY_Output1 = capacity)
   '   Assert.IsTrue(com.RAE_Out_COFAN_CFMACTUAL_Output1 = cfmActual)
   '   Assert.IsTrue(com.RAE_Out_COFAN_CFMSTD_Output1 = cfmStandard)
   '   Assert.IsTrue(com.RAE_Out_COFAN_FACEVELOCITY_Output1 = faceVelocity)
   '   Assert.IsTrue(com.RAE_Out_COFAN_HORSEPOWER_Output1 = horsepower)
   '   Assert.IsTrue(com.RAE_Out_COFAN_STATICPRESSURE_Output1 = staticPressure)
   'End Sub


   '<TestMethod()> _
   'Public Sub CheckManagedResults()
   '   Dim condenser As New Rae.RaeSolutions.Business.Intelligence.Cofan(externalStaticPressure, altitude, _
   '      ambient, temperatureDifference, fans, coilWidth, coilLength, fpi, fanFile, coilFile, 1)

   '   Dim outputs As List(Of Rae.RaeSolutions.Business.Intelligence.CofanOutput) = condenser.Outputs

   '   Assert.IsTrue(outputs(0).FPI = fpi)
   '   Assert.IsTrue(Round(outputs(0).CAPACITY) = capacity)
   '   Assert.IsTrue(Round(outputs(0).FACEVELOCITY) = faceVelocity)
   '   Assert.IsTrue(Round(outputs(0).STATICPRESSURE, 2) = staticPressure)
   '   Assert.IsTrue(Round(outputs(0).HORSEPOWER, 2) = horsepower)
   '   Assert.IsTrue(Round(outputs(0).CFMACTUAL) = cfmActual)
   '   Assert.IsTrue(Round(outputs(0).CFMSTD) = cfmStandard)
   '   Assert.IsTrue(Round(outputs(0).BTUHSF) = capacityPerSquareFoot)
   'End Sub


   <TestMethod()> _
   Sub CheckCondenserOutputs()
      Dim condenser As New Rae.RaeSolutions.Business.Entities.Condenser(ambient, temperatureDifference, _
         coilWidth, coilLength, coilFile, CInt(fans), fanFile)

      Dim outputs As List(Of Rae.RaeSolutions.Business.Entities.Condenser.Outputs)
      outputs = condenser.Calculate()

      With condenser.Output(0)
         Assert.IsTrue(.FinsPerInch = fpi)
         Assert.IsTrue(.Capacity = capacity)
         Assert.IsTrue(.FaceVelocity = faceVelocity)
         Assert.IsTrue(.StaticPressure = staticPressure)
         Assert.IsTrue(.Horsepower = horsepower)
         Assert.IsTrue(.AirFlowActual = cfmActual)
         Assert.IsTrue(.AirFlowStandard = cfmStandard)
         Assert.IsTrue(.CoilCapacity = capacityPerSquareFoot)
      End With
   End Sub

End Class
