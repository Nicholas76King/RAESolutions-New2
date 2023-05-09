Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess
Public Class AddFluidCoolerProcessesTable
   Inherits RefactoringBase

   Public Sub New(ByVal connectionstring As String)
      Me.connectionString_ = connectionstring
   End Sub


   Public Overrides ReadOnly Property Description() As String
      Get
         Return "Adds an additional table to store Fluid Cooler Process Items."
      End Get
   End Property

   Protected Overrides Sub Refactor()
      AddFluidCoolerProcessesTable()
   End Sub

   Public Overrides ReadOnly Property ReleaseDate() As Date
      Get
         Return #11/29/2007 7:45:00 AM#
      End Get
   End Property

   Public Overrides ReadOnly Property Version() As Deployment.Version
      Get
         Return New Deployment.Version(1, 11, 0, 0)
      End Get
   End Property

   Private Sub AddFluidCoolerProcessesTable()
      Dim cmds As New Commands(Me.ConnectionString)
      If cmds.CheckTableExistence("FluidCoolerProcesses") = ExistenceStatus.Nonexistent Then
         cmds.AddTable("FluidCoolerProcesses")
         cmds.AddColumn("FluidCoolerProcesses", New Column("ProcessID", New DataTypes.Text))
         cmds.AddColumn("FluidCoolerProcesses", New Column("Revision", New DataTypes.Single))
         cmds.AddColumn("FluidCoolerProcesses", New Column("RevisionDate", New DataTypes.DateTime))
         cmds.AddColumn("FluidCoolerProcesses", New Column("ProjectRevision", New DataTypes.LongInteger))
         cmds.AddColumn("FluidCoolerProcesses", New Column("ProcessRevisionDescription", New DataTypes.Text))
         cmds.AddColumn("FluidCoolerProcesses", New Column("CreatedBy", New DataTypes.Text))
         cmds.AddColumn("FluidCoolerProcesses", New Column("Name", New DataTypes.Text))
         cmds.AddColumn("FluidCoolerProcesses", New Column("Altitude", New DataTypes.Double))
         cmds.AddColumn("FluidCoolerProcesses", New Column("Capacity", New DataTypes.Double))
         cmds.AddColumn("FluidCoolerProcesses", New Column("AmbientTemp", New DataTypes.Double))
         cmds.AddColumn("FluidCoolerProcesses", New Column("EnteringFluidTemp", New DataTypes.Double))
         cmds.AddColumn("FluidCoolerProcesses", New Column("LeavingFluidTemp", New DataTypes.Double))
         cmds.AddColumn("FluidCoolerProcesses", New Column("GlycolPercent", New DataTypes.Double))
         cmds.AddColumn("FluidCoolerProcesses", New Column("Fluid", New DataTypes.Text))
         cmds.AddColumn("FluidCoolerProcesses", New Column("Flow", New DataTypes.Double))
         cmds.AddColumn("FluidCoolerProcesses", New Column("FluidCoolerXML", New DataTypes.Memo))


      End If
   End Sub
End Class
