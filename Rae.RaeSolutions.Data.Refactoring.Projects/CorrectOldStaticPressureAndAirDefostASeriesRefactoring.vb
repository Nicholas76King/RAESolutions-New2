Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess
Imports System.Data

Public Class CorrectOldStaticPressureAndAirDefostASeriesRefactoring : Inherits RefactoringBase
   Sub New(connectionString As String)
      me.connectionString_ = connectionString
   End Sub

   Overrides ReadOnly Property Description As String
      Get
         Return "Change null static pressures to default 0. Remove -A air defrost indicator from A series."
      End Get
   End Property

   Overrides ReadOnly Property ReleaseDate As Date
      Get
         Return New Date(2010, 09, 16)
      End Get
   End Property

   Overrides ReadOnly Property Version As Deployment.Version
      Get
         Return New Deployment.Version(1, 28, 0, 0)
      End Get
   End Property
   
   Protected Overrides Sub Refactor()
      dim commands = new commands(connectionString_)

      'works in access but not in code
      'Replace([UnitCooler1Model],'-A','')

      'LENGTH not keyword
      'LENGTH([UnitCooler1Model])-2)

      ' remove -A (air defrost indicator) from end of A series unit cooler models selected in balance program
      dim sql = "UPDATE UnitCoolerProcesses SET UnitCooler1Model = LEFT([UnitCooler1Model], LEN([UnitCooler1Model])-2)" & _
                "WHERE [UnitCooler1Model] Like 'A%-A'"
      commands.execute(sql)

      sql = "UPDATE UnitCoolerProcesses SET UnitCooler2Model = LEFT([UnitCooler2Model], LEN([UnitCooler2Model])-2)" & _
                "WHERE [UnitCooler2Model] Like 'A%-A'"
      commands.execute(sql)

      sql = "UPDATE UnitCoolerProcesses SET UnitCooler3Model = LEFT([UnitCooler3Model], LEN([UnitCooler3Model])-2)" & _
                "WHERE [UnitCooler3Model] Like 'A%-A'"
      commands.execute(sql)

      ' set new static pressure columns to 0 instead of null
      sql = "UPDATE UnitCoolerProcesses SET static_pressure_1 = 0, static_pressure_2 = 0, static_pressure_3 = 0 " &
            "WHERE [static_pressure_1] Is Null"
      commands.execute(sql)
   End Sub
End Class