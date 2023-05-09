''' <summary>
''' Form to get project and equipment name from user.
''' </summary>
Public Class SaveOldRevisionBeforeNavigatingRevisionsForm


#Region " Private event handlers"

   ''' <summary>
   ''' Handles save and revision button's click event. 
   ''' Hides form (if is valid) or alerts user (if is not valid).
   ''' </summary>
   Private Sub saveAndRevisionButton_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles saveButton.Click

      Me.DialogResult = Windows.Forms.DialogResult.OK
      ' hides dialog so that code will continue
      Me.Hide()

   End Sub


   ''' <summary>
   ''' Handles cancel button's click event. Cancels and hides form.
   ''' </summary>
   Private Sub cancelButton_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles cancel2Button.Click

      Me.DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Hide()
   End Sub

#End Region

End Class