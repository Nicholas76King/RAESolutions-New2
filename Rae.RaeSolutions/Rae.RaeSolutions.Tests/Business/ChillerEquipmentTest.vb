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
         With .CommonSpecs
            .Altitude.Value = 10
            .ControlVoltage = New VoltageRating(460, 3, 60)
            .Height.Value = 20
            .Length.Value = 30
            .Mca.Value = 40
            .OperatingWeight.Value = 50
            .Rla.Value = 60
            .ShippingWeight.Value = 70
            .UnitVoltage = New VoltageRating(230, 1, 1)
            .Width.Value = 80
         End With

         .Series = "30A0"
         .model_without_series = "Standard"
         .Division = RaeSolutions.Business.Division.TSI
         .CustomModel = "Custom"
         .Type = RaeSolutions.Business.EquipmentType.Chiller

         '.IsIncluded = True

         With .MetaData
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

         .Options.Add(op)

         With .Pricing
            .OtherDescription = "Other"
            .OtherPrice = 1
            .ParMultiplier = 1.1
            .StartUp = 200
            .Warranty = 400
            .CommissionRate = 12
            .Freight = 100
            .ListPrice = 13000
            .Quantity = 2
         End With

         Dim specialOp As New SpecialOption("SP01", "Special option", 111, 2, "CaseyJ", "JayK", Date.Now, chiller.Id, 0)
         .SpecialOptions.Add(specialOp)

         .SpecialInstructions = "Do this"

         With .Specs
            .AmbientTemp.Value = 95
            .Capacity.Value = 12000
            .EnteringFluidTemp.Value = 35
            .EvaporatorPressureDrop.Value = 2.2
            .Flow.Value = 12
            .Fluid = "Water"
            .GlycolPercent.Value = 4
            .LeavingFluidTemp.Value = 45
            .Refrigerant = "R134a"
         End With

         .Tag = "Put here"
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