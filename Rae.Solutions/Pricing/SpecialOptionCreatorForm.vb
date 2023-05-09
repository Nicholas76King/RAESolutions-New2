Imports Rae.RaeSolutions.Business.Entities


Public Class SpecialOptionCreatorForm


   Private m_SpecialOption As SpecialOption
   Private m_existingSpecialOptions As SpecialOptionList


   ''' <summary>
   ''' Special option
   ''' </summary>
   Public ReadOnly Property SpecialOption() As SpecialOption
      Get
         Return Me.SpecialOptionCreatorControl1.SpecialOption
      End Get
   End Property


   ''' <summary>
   ''' Special options that have already been added.
   ''' </summary>
   Public Property ExistingSpecialOptions() As SpecialOptionList
      Get
         Return Me.m_existingSpecialOptions
      End Get
      Set(ByVal value As SpecialOptionList)
         Me.m_existingSpecialOptions = value
      End Set
   End Property



   ''' <summary>
   ''' Shows form as modal form.
   ''' </summary>
   ''' <param name="id">
   ''' Equipment ID.</param>
   ''' <param name="authorizedFor">
   ''' Person special option is authorized for</param>
   ''' <returns>
   ''' Dialog result (OK or Cancel)</returns>
   Public Overloads Function ShowDialog(ByVal id As item_id, ByVal authorizedFor As String, _
   ByVal existingSpecialOptions As SpecialOptionList) As DialogResult
      Me.SpecialOptionCreatorControl1.Create(id, authorizedFor)
      Me.ExistingSpecialOptions = existingSpecialOptions
      Return MyBase.ShowDialog()
   End Function


   ''' <summary>
   ''' Shows form as modal form.
   ''' </summary>
   ''' <param name="id">
   ''' Equipment ID.</param>
   ''' <param name="authorizedFor">
   ''' Person special option is authorized for</param>
   ''' <returns>
   ''' Dialog result (OK or Cancel)</returns>
   Public Overloads Function ShowDialog(ByVal id As item_id, _
   ByVal existingSpecialOptions As SpecialOptionList, ByVal specialOptionToEdit As SpecialOption) As DialogResult
      Me.SpecialOptionCreatorControl1.Create(id, specialOptionToEdit)
      Me.ExistingSpecialOptions = existingSpecialOptions
      Return MyBase.ShowDialog()
   End Function


   ''' <summary>
   ''' Returns true if special option code has already been added; else returns false.
   ''' </summary>
   ''' <param name="codeToAdd">
   ''' Special option code to add.
   ''' </param>
   Private Function IsOptionCodeAlreadyAdded(ByVal codeToAdd As String) As Boolean
      Dim alreadyAdded As Boolean

      If Me.ExistingSpecialOptions IsNot Nothing Then

         For Each op As SpecialOption In Me.ExistingSpecialOptions
            If op.Code = codeToAdd Then
               alreadyAdded = True
               Exit For
            End If
         Next

      End If

      Return alreadyAdded
   End Function


   ''' <summary>
   ''' OK button click event handler.
   ''' </summary>
   Private Sub btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles btnOk.Click

      If Me.SpecialOptionCreatorControl1.validationMgr.Validate Then
         If Not Me.IsOptionCodeAlreadyAdded(Me.SpecialOptionCreatorControl1.SpecialOption.Code) Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
         Else
            Ui.MessageBox.Show("Please enter a different option code. There is already an option with this code.", _
               MessageBoxIcon.Warning)
            Me.SpecialOptionCreatorControl1.txtCode.Focus()
            Me.SpecialOptionCreatorControl1.txtCode.SelectAll()
         End If
      Else
         Ui.MessageBox.Show(Me.SpecialOptionCreatorControl1.validationMgr.ErrorMessagesSummary)
      End If
   End Sub


   ''' <summary>
   ''' Cancel button click event handler.
   ''' </summary>
   Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles btnCancel.Click
      Me.DialogResult = DialogResult.Cancel
      Me.Close()
   End Sub

End Class