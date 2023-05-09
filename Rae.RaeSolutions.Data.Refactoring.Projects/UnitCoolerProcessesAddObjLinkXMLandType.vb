Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess

Public Class UnitCoolerProcessesAddObjLinkXMLandType

   Inherits RefactoringBase

   Public Sub New(ByVal connectionString As String)
      connectionString_ = connectionString
   End Sub


   Public Overrides ReadOnly Property Description() As String
      Get
         Return "Adds ObjectLinkXML and ObjectLinkType columns to UnitCoolerProcesses table in Projects database."
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
         Return New Deployment.Version(1, 11, 0, 0)
      End Get
   End Property

   Private Sub addColumns()
      Dim commands As New Commands(connectionString_)
      commands.AddColumn("UnitCoolerProcesses", New Column("ObjectLinkXML", New DataTypes.Memo()))
      commands.AddColumn("UnitCoolerProcesses", New Column("ObjectLinkType", New DataTypes.Text()))
   End Sub

End Class
