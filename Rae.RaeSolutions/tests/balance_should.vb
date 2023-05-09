Option Strict Off

Imports Rae.Math.Comparisons
Imports Rae.RaeSolutions.Business.Entities.Cofans
Imports Rae.RaeSolutions.Business.Intelligence
imports rae.solutions
imports rae.solutions.compressors
imports rae.solutions.condensing_units
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert
Imports System.Diagnostics

<TestClass> _
Public Class balance_should
   Private compressors As i_compressor_repository
   Private condensingUnits As I_Repository
   
   <TestInitialize> _
   Sub init
      config.db()
      settings.set_defaults()
      compressors     = new compressor_repository()
      condensingUnits = new condensing_units.Repository()
   End Sub
   
   <TestMethod()> _
   Sub match_original_DS10H2
      Dim criteria As Criteria
      criteria.compressor_qty_description = "S"
      criteria.compressor_type = "Semi-Hermetic Discus"
      criteria.division = Rae.RaeSolutions.Business.Division.CRI
      criteria.refrigerant = refrigerant.parse("R22")
      criteria.series = "DS"
      criteria.suction_temp = 35

      Dim condensingUnit = condensingUnits.get_units(criteria)
      IsTrue(condensingUnit.Count > 0)
      
      Dim cu = condensingUnit(0)

      Dim conditions As Balance.Conditions 
      conditions.altitude = 0
      conditions.ambient = 95
      conditions.catalog_rating = True
      conditions.hertz = 60
      conditions.suction = 35
      conditions.voltage = 230
      conditions.fan_file_name_1 = FanIntel.SelectStandardFile(cu.circuits(0).fan_diameter, conditions.altitude)
      conditions.hp_1 = cu.circuits(0).hp
      
      Dim balance = New Balance(compressors)
      'For i=0 To 4
         'Dim timer = Stopwatch.StartNew()
            Dim result = balance.This(cu, at:=conditions)
            Dim p = result.point
         'log(timer.ElapsedMilliseconds)
      'Next
      IsTrue(System.Math.Round(p.condensing_temp, 1) = 121.4)
      IsTrue(System.Math.Round(p.td, 1) = 26.4)
      IsTrue(System.Math.Round(p.unit_kw, 2) = 12.27)
      IsTrue(System.Math.Round(p.unit_amps, 1) = 39.1)

      Dim expected = 10.95
      IsTrue(IsAccurate(p.unit_eer, 0.1, expected), "eer is off by: %" & (p.unit_eer - expected) / expected * 100)

      expected = 156557.2
      IsTrue(IsAccurate(p.condenser_capacity, 0.1, expected), "condenser capacity off by: %" & (p.condenser_capacity - expected) / expected * 100)

      expected = 134334.7
      IsTrue(IsAccurate(p.capacity, 0.1, expected), "capacity off by: %" & (p.capacity - expected) / expected * 100)
   End Sub
   
   <TestMethod> _
   Sub match_original_20A0CD10_balance
      Dim criteria As Criteria
      criteria.compressor_qty_description = "D"
      criteria.compressor_type = "Semi-Hermetic Discus"
      criteria.division = Rae.RaeSolutions.Business.Division.TSI
      criteria.Refrigerant = refrigerant.parse("R22")
      criteria.series = "20A0"
      criteria.suction_temp = 35
      
      Dim cus = condensingUnits.get_units(criteria)
      Dim cu = cus.Find( Function(x) x.model="20A0CD10" )
      
      Dim conditions As Balance.Conditions
      conditions.altitude     = 0
      conditions.ambient      = 95
      conditions.catalog_rating= True
      conditions.hertz        = 60
      conditions.suction      = 35
      conditions.voltage      = 230
      conditions.hp_1         = cu.circuits(0).hp
      conditions.hp_2         = cu.circuits(1).hp
      conditions.fan_file_name_1 = FanIntel.SelectStandardFile(cu.circuits(0).fan_diameter, conditions.altitude)
      conditions.fan_file_name_2 = FanIntel.SelectStandardFile(cu.circuits(1).fan_diameter, conditions.altitude)
          
      Dim balance = New Balance(compressors)
      Dim result = balance.This(cu, at:=conditions)
      
      IsTrue( result.points.Count = 2 )
      
      Dim pt = result.point
      IsTrue( rnd(pt.condensing_temp, 1) = 124.4 )
      IsTrue( rnd(pt.capacity, 1) = 10.7 )
      IsTrue( rnd(pt.unit_kw, 2) = 12.19 )
      IsTrue( rnd(pt.unit_amps, 1) = 39.1 )
      IsTrue( rnd(pt.td, 1) = 29.4 )
      
      Dim expected = 12.5
      IsTrue( IsAccurate(pt.condenser_capacity, 0.1, expected) )
      
      expected = 10.52
      IsTrue( IsAccurate(pt.unit_eer, 0.1, expected) )
   End Sub
   
   <TestMethod> _
   Sub match_original_DS10H2_over_range
      config.db
   
      Dim conditions As Balance.Conditions
      conditions.altitude = 0
      conditions.ambient = 95
      conditions.catalog_rating = True
      conditions.hertz = 60
      conditions.suction = 35
      conditions.voltage = 230
      conditions.fan_file_name_1 = "LAU2429"
      conditions.hp_1 = 0.5
      
      Dim compressorRepo = new compressor_repository()
      Dim balance = New Balance(compressorRepo)
      
      dim repo = new condensing_units.Repository()
      dim cu = repo.get_unit("DS10H2")
      
      dim results = balance.This(cu, at:=conditions, ambient_step:=5, ambient_num_steps:=3, suction_step:=3)
      
      IsTrue(results.Count = 12)
   End Sub
   
   Private Function avg(val1, val2) As Double
      Return (val1 + val2) / 2
   End Function
   
   Private Function rnd(val, optional digits = 0) As Double
      Return System.Math.Round(val, digits)
   End Function
   
   Private Sub log(msg)
      Debug.WriteLine(msg)
      Debug.Flush()
   End Sub
   
End Class
