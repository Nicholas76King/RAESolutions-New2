Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess
Imports System.Collections.Generic

Public Class ChangeRevisionFieldTypeToSingle

   Inherits RefactoringBase

   Public Sub New(ByVal connectionString As String)
      connectionString_ = connectionString
   End Sub


   Public Overrides ReadOnly Property Description() As String
      Get
         Return "Change Revision field type to SINGLE in various tables in Projects database."
      End Get
   End Property

   Protected Overrides Sub Refactor()

      Dim tables As New List(Of String)
      tables.Add("ACChillerProcesses")
      tables.Add("Chiller")
      tables.Add("Condenser")
      tables.Add("CondenserProcesses")
      tables.Add("CondensingUnit")
      tables.Add("CondensingUnitProcesses")
      tables.Add("CoolStuffProjects")
      tables.Add("Equipment")
      tables.Add("EquipmentOptions")
      tables.Add("EvapChillerProcesses")
      tables.Add("FluidCooler")
      tables.Add("FluidCoolerProcesses")
      tables.Add("OtherEquipmentCosts")
      tables.Add("ProductCooler")
      tables.Add("RatingEquipment")
      tables.Add("SpecialOptions")
      tables.Add("UnitCooler")
      tables.Add("UnitCoolerProcesses")
      tables.Add("WCChillerProcesses")

      editRevision(tables)

   End Sub

   Public Overrides ReadOnly Property ReleaseDate() As Date
      Get
         Return #12/13/2007#
      End Get
   End Property

   Public Overrides ReadOnly Property Version() As Deployment.Version
      Get
         Return New Deployment.Version(1, 13, 0, 0)
      End Get
   End Property

   Private Sub editRevision(ByVal Tables As List(Of String))
      Dim commands As New Commands(connectionString_)
      Dim cmd As System.Data.OleDb.OleDbCommand
      Dim con As New System.Data.OleDb.OleDbConnection(Me.ConnectionString)
      Dim str As String
      Try
         con.Open()
         For i As Integer = 0 To Tables.Count - 1
            ' update revision column type
            commands.EditColumn(Tables(i), New Column("Revision", New DataTypes.Single()))
            ' change revision to 1/1000
            str = "UPDATE [" & Tables(i) & "] SET [Revision] = [Revision] / 1000 WHERE [Revision] >= 1"
            cmd = New System.Data.OleDb.OleDbCommand(str, con)
            cmd.ExecuteNonQuery()
         Next
      Catch ex As System.Data.OleDb.OleDbException
         Throw ex
      Finally
         If con IsNot Nothing And con.State <> System.Data.ConnectionState.Closed Then con.Close()
      End Try
   End Sub

End Class