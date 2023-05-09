Imports System.Data.OleDb

Public Class RenameRepresentativeRoleRefactoring
   Inherits Rae.Data.Refactoring.RefactoringBase


   Public Sub New(ByVal connectionString As String)
      Me.connectionString_ = connectionString
   End Sub


   Public Overrides ReadOnly Property Description() As String
      Get
         Return "Renames data in Companies table column Description from Rep to Representative."
      End Get
   End Property

   Protected Overrides Sub Refactor()
      renameRepresentativeRole()
   End Sub

   Public Overrides ReadOnly Property ReleaseDate() As Date
      Get
         Return New Date(2007, 7, 12)
      End Get
   End Property

   Public Overrides ReadOnly Property Version() As Deployment.Version
      Get
         Return New Rae.Deployment.Version(1, 2, 0, 0)
      End Get
   End Property


   Private Sub renameRepresentativeRole()
      Dim connection As New OleDbConnection(ConnectionString)
      Dim sql As New System.Text.StringBuilder()
      sql.AppendFormat("UPDATE {0} SET {1}='{2}' WHERE {1}='{3}'", _
         "Companies", "Description", "Representative", "Rep")
      Dim command As New OleDbCommand(sql.ToString(), connection)
      Try
         connection.Open()
         Dim numRowsAffected As Integer = command.ExecuteNonQuery()
      Finally
         If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()
      End Try
   End Sub

End Class
