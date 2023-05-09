Imports System
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Rae.RaeSolutions.Business.Entities

<TestClass()> Public Class ChillerEquipmentTest

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

   Private chiller As chiller_equipment
   Private manager As project_manager


   ' Use TestInitialize to run code before running each test
   <TestInitialize()> _
   Public Sub InitializeChiller()
      manager = New project_manager("Test Project", "CaseyJ", "password")
      chiller = New chiller_equipment("Large Chiller", RAESolutions.Business.Division.TSI, "CaseyJ", "LS3H4H6654", manager)
      With chiller
         With .common_specs
            .Altitude.value = 10
            .ControlVoltage = New VoltageRating(460, 3, 60)
            .Height.value = 20
            .Length.value = 30
            .Mca.value = 40
            .OperatingWeight.value = 50
            .Rla.value = 60
            .ShippingWeight.value = 70
            .UnitVoltage = New VoltageRating(230, 1, 1)
            .Width.value = 80
         End With

         .Series = "30A0"
         .model_without_series = "Standard"
         .division = RaeSolutions.Business.Division.TSI
         .custom_model = "Custom"
         .type = RaeSolutions.Business.EquipmentType.Chiller

         '.IsIncluded = True

         With .metadata
            .Comments.Add(New Comment("CaseyJ", "Test", "This is a test"))
            .Description = "Chiller for testing"
         End With

         Dim op As New EquipmentOption()
         op.Category = "Piping"
         op.Code = "EA32"
         op.Description = "Option description"
         op.Equipment = chiller
         op.Id = 3
         op.IsSelectedReadOnly = True
         op.MasterId = 4
         op.Price = 321
         op.PricingId = 5
         op.Selected = True
         op.Voltage = 460

         .options.Add(op)

         With .pricing
            .other_description = "Other"
            .other_price = 1
            .par_multiplier = 1.1
            .start_up = 200
            .warranty = 400
            .commission_rate = 12
            .freight = 100
            .list_price = 13000
            .quantity = 2
         End With

         Dim specialOp As New SpecialOption("SP01", "Special option", 111, 2, "CaseyJ", "JayK", Date.Now, chiller.id, 0)
         .special_options.Add(specialOp)

         .special_instructions = "Do this"

         With .Specs
            .AmbientTemp.value = 95
            .Capacity.value = 12000
            .EnteringFluidTemp.value = 35
            .EvaporatorPressureDrop.value = 2.2
            .Flow.value = 12
            .Fluid = "Water"
            .GlycolPercent.value = 4
            .LeavingFluidTemp.value = 45
            .Refrigerant = "R134a"
         End With

         .tag = "Put here"
      End With
   End Sub

   ' Use TestCleanup to run code after each test has run
   <TestCleanup()> _
   Public Sub CleanupChiller()
      manager = Nothing
      chiller = Nothing
   End Sub



   ''' <summary>
   ''' Tests that a clone is equal to the original.
   ''' </summary>
   <TestMethod()> _
   Public Sub TestCloneAndEquals()
      Dim chillerClone = chiller.Clone()
      Dim areEqual = (chillerClone.Equals(chiller))

      Assert.IsTrue(areEqual)
   End Sub


   ''' <summary>Tests that a copy is equal to the original.</summary>
   <TestMethod()> _
   Public Sub TestCopyAndEquals()
      Dim chillerCopy = New chiller_equipment("Copy", RaeSolutions.Business.Division.CRI, "Frank", "pass", manager)
      chillerCopy.Copy(Me.chiller)

      Dim areEqual = chillerCopy.Equals(Me.chiller)

      Assert.IsTrue(areEqual)
   End Sub


End Class