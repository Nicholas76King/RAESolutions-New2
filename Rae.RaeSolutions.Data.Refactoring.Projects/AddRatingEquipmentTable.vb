Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess

Public Class AddRatingEquipmentTable
   Inherits RefactoringBase

   Public Sub New(ByVal connectionstring As String)
      Me.connectionString_ = connectionstring
   End Sub


   Public Overrides ReadOnly Property Description() As String
      Get
         Return "Adds an additional table to store serialized version of rating equipment tied to a piece of pricing equipment."
      End Get
   End Property

   Protected Overrides Sub Refactor()
      AddRatingEquipmentTable()
   End Sub

   Public Overrides ReadOnly Property ReleaseDate() As Date
      Get
         Return #11/16/2007 9:45:00 AM#
      End Get
   End Property

   Public Overrides ReadOnly Property Version() As Deployment.Version
      Get
         Return New Deployment.Version(1, 10, 0, 0)
      End Get
   End Property

   Private Sub AddRatingEquipmentTable()
      Dim cmds As New Commands(Me.ConnectionString)
      If cmds.CheckTableExistence("RatingEquipment") = ExistenceStatus.Nonexistent Then
         cmds.AddTable("RatingEquipment")
         cmds.AddColumn("RatingEquipment", New Column("ProjectID", New DataTypes.Text))
         cmds.AddColumn("RatingEquipment", New Column("ProjectRevision", New DataTypes.LongInteger))
         cmds.AddColumn("RatingEquipment", New Column("EquipmentID", New DataTypes.Text))
         cmds.AddColumn("RatingEquipment", New Column("Revision", New DataTypes.Single))
         cmds.AddColumn("RatingEquipment", New Column("RatingEquipmentXML", New DataTypes.Memo))


      End If
   End Sub
End Class
