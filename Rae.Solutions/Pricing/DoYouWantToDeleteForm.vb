Public Class DoYouWantToDeleteForm

   Public Enum deletetype
      EquipmentItem
      ProcessItem
        ProjectItem
        BoxLoadItem
   End Enum

   Private m_DeleteConfirmed As Boolean
   ''' <summary>
   ''' DeleteConfirmed
   ''' </summary>
   Public ReadOnly Property DeleteConfirmed() As Boolean
      Get
         Return Me.m_DeleteConfirmed
      End Get
   End Property

   Private m_DeleteWhat As deletetype
   Private m_DeleteWhatStr As String
   ''' <summary>
   ''' DeleteWhat
   ''' </summary>
   Public Property DeleteWhat() As deletetype
      Get
         Return Me.m_DeleteWhat
      End Get
      Set(ByVal value As deletetype)
         Me.m_DeleteWhat = value
         Select Case Me.m_DeleteWhat
            Case deletetype.EquipmentItem
               Me.m_DeleteWhatStr = "equipment item"
            Case deletetype.ProcessItem
               Me.m_DeleteWhatStr = "selection"
            Case deletetype.ProjectItem
                    Me.m_DeleteWhatStr = "entire project"
                Case deletetype.BoxLoadItem
                    Me.m_DeleteWhatStr = "Box Load"
            End Select
         Me.captionLabel.Text = "Are you sure you want to delete this " & Me.m_DeleteWhatStr & "?"
      End Set
   End Property

   Private Sub deleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deleteButton.Click
      Me.m_DeleteConfirmed = True
      Me.Close()
   End Sub

   Private Sub cancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelButton.Click
      Me.m_DeleteConfirmed = False
      Me.Close()
   End Sub

End Class