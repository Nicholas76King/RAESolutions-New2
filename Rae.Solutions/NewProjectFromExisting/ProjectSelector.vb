Public Class ProjectSelector
   Implements IProjectSelector

   Sub AskUser() _
   Implements IProjectSelector.AskUser
      Dim f As New ProjectSelectionForm()
      f.ShowDialog()

      If f.DialogResult <> DialogResult.OK Then _
         _canceled = True : Exit Sub

      _projectId = f.ProjectId
   End Sub

   ReadOnly Property Canceled() As Boolean _
   Implements IProjectSelector.Canceled
      Get
         Return _canceled
      End Get
   End Property

   ReadOnly Property ProjectId() As String _
   Implements IProjectSelector.ProjectId
      Get
         Return _projectId
      End Get
   End Property


   Protected _projectId As String
   Protected _canceled As Boolean

End Class
