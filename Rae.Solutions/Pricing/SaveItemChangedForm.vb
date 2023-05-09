Public Class SaveItemChangedForm

   Public Enum eSaveType
      DoNotSave
      Save
      SaveAsNew
      SaveAsRevision
   End Enum

   Private m_SaveType As eSaveType
   ''' <summary>
   ''' SaveType
   ''' </summary>
   Public ReadOnly Property SaveType() As eSaveType
      Get
         Return Me.m_SaveType
      End Get
   End Property

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      If Me.radSave.Checked = True Then
         Me.m_SaveType = eSaveType.Save
      ElseIf Me.radSaveRev.Checked = True Then
         Me.m_SaveType = eSaveType.SaveAsRevision
      ElseIf Me.radDoNotSave.Checked = True Then
         Me.m_SaveType = eSaveType.DoNotSave
      End If
      Me.Visible = False
   End Sub

   Private Sub SaveItemChangedForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      Me.CenterToParent()
   End Sub
End Class