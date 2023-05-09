Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess

Public Class CondensingUnitProcessesAddVoltage10Coef
   Inherits RefactoringBase

   Public Sub New(ByVal connectionString As String)
      connectionString_ = connectionString
   End Sub


   Public Overrides ReadOnly Property Description() As String
      Get
         Return "Adds Use10Coefficients and Voltage columns to CondensingUnitProcesses table in Projects database."
      End Get
   End Property

   Protected Overrides Sub Refactor()
      addColumns()
   End Sub

   Public Overrides ReadOnly Property ReleaseDate() As Date
      Get
         Return #11/29/2007#
      End Get
   End Property

   Public Overrides ReadOnly Property Version() As Deployment.Version
      Get
         Return New Deployment.Version(1, 12, 0, 0)
      End Get
   End Property

   Private Sub addColumns()
      Dim commands As New Commands(connectionString_)
      commands.AddColumn("CondensingUnitProcesses", New Column("Voltage", New DataTypes.LongInteger()))
      commands.AddColumn("CondensingUnitProcesses", New Column("Use10Coefficients", New DataTypes.YesNo()))
   End Sub

End Class
