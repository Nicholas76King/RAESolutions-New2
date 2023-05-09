''' <summary>
''' Asks user if they want to save.
''' </summary>
Public Class SaveOnCloseForm

   ''' <summary>
   ''' List of selections a user can make.
   ''' </summary>
   Public Enum UserSelection
      Cancel
      DoNotSave
      Save
      SaveAsRevision
   End Enum


   Private m_saveSelection As UserSelection


   ''' <summary>
   ''' Save selection that user chose.
   ''' </summary>
   Public ReadOnly Property SaveSelection() As UserSelection
      Get
         Return Me.m_saveSelection
      End Get
   End Property


    ' ''' <summary>
    ' ''' Handles ok button click event.
    ' ''' Sets user's save selection.
    ' ''' </summary>
    ' Private Sub okButton_Click(ByVal sender As Object, ByVal e As EventArgs)

    '     ' gets user's save selection
    '     If Me.saveRadioButton.Checked Then
    '         Me.m_saveSelection = UserSelection.Save
    '     ElseIf Me.saveAsRevisionRadioButton.Checked Then
    '         Me.m_saveSelection = UserSelection.SaveAsRevision
    '     ElseIf Me.doNotSaveRadioButton.Checked Then
    '         Me.m_saveSelection = UserSelection.DoNotSave
    '     ElseIf Me.cancelRadioButton.Checked Then
    '         Me.m_saveSelection = UserSelection.Cancel
    '     End If

    '     ' hides form, code that showed form should close me after it get user's selection
    '     Me.Hide()
    ' End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Me.m_saveSelection = UserSelection.Save
        Me.Hide()
    End Sub

    Private Sub btnSaveRevsion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveRevsion.Click
        Me.m_saveSelection = UserSelection.SaveAsRevision
        Me.Hide()

    End Sub

    Private Sub btnDoNotSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDoNotSave.Click
        Me.m_saveSelection = UserSelection.DoNotSave
        Me.Hide()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.m_saveSelection = UserSelection.Cancel
        Me.Hide()
    End Sub
End Class