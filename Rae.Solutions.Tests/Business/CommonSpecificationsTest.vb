Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Rae.RaeSolutions.Business.Entities

Namespace Business

<TestClass()> _
Public Class CommonSpecificationsTest

   <TestMethod()> _
   Sub AltitudeTest()
      Dim val = New nullable_value(Of Double)(1000)
      
      Dim target = New CommonSpecifications()
      target.Altitude = val

      Assert.AreEqual(val, target.Altitude)
      Assert.IsTrue(target.Altitude.has_value)
      Assert.IsTrue(target.Altitude.value = 1000)
   End Sub

   <TestMethod()> _
   Sub ControlVoltageTest()
      Dim val = New VoltageRating(460, 3, 60)
      
      Dim target = New CommonSpecifications()
      target.ControlVoltage = val

      Assert.AreEqual(val, target.ControlVoltage)
   End Sub

   <TestMethod()> _
   Sub EqualsTest()
      Dim target = New CommonSpecifications
      With target
         .Altitude.value = 1000
         .ControlVoltage = New VoltageRating(230, 1, 60)
         .Height.value = 30
         .Length.value = 40
         .Mca.value = 7.8
         .OperatingWeight.value = 1500
         .Rla.value = 8.2
         .ShippingWeight.value = 1600
         .UnitVoltage = New VoltageRating(460, 3, 60)
         .Width.value = 20
      End With

      Dim other = New CommonSpecifications
      With other
         .Altitude.value = 1000
         .ControlVoltage = New VoltageRating(230, 1, 60)
         .Height.value = 30
         .Length.value = 40
         .Mca.value = 7.8
         .OperatingWeight.value = 1500
         .Rla.value = 8.2
         .ShippingWeight.value = 1600
         .UnitVoltage = New VoltageRating(460, 3, 60)
         .Width.value = 20
      End With

      Assert.IsTrue( target.Equals(other) )
   End Sub



   <TestMethod()> _
   Sub Constructor_prevents_nulls()
      Dim target = New CommonSpecifications

      Dim actual As Boolean
      actual = ( target.Altitude       IsNot Nothing _
         AndAlso target.ControlVoltage IsNot Nothing _
         AndAlso target.Height         IsNot Nothing _
         AndAlso target.Length         IsNot Nothing _
         AndAlso target.Mca            IsNot Nothing _
         AndAlso target.OperatingWeight IsNot Nothing _
         AndAlso target.Rla            IsNot Nothing _
         AndAlso target.ShippingWeight IsNot Nothing _
         AndAlso target.UnitVoltage    IsNot Nothing _
         AndAlso target.Width          IsNot Nothing)

      Assert.IsTrue(actual)
   End Sub

End Class

End Namespace