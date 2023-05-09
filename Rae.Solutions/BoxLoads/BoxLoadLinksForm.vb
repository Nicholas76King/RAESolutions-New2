Public Class BoxLoadLinksForm
   Implements ISelectBoxLoad
   
   Private response As SelectBoxLoadResponse

   ''' <summary>
   ''' Asks user to select a box load from the project
   ''' </summary>
   ''' <param name="fromProject">
   ''' ID of project containing box loads
   ''' </param>
   Function AskUserToSelect(fromProject As String) As ISelectBoxLoadResponse _
   Implements ISelectBoxLoad.AskUserToSelectBoxLoad
      response = New SelectBoxLoadResponse()
      response.result_ = SelectBoxLoadResult.Canceled
      If populate(fromProject) = False Then
         response.result_ = SelectBoxLoadResult.Canceled
         Return response
      End If
      
      ShowDialog()
      Return response
   End Function


   Private Function populate(fromProject As String) As Boolean
      Dim da As New Rae.Data.Access.BoxLoadProjects()
      Dim b As System.Data.DataTable = da.RetrieveBoxLoadInfo(fromProject)
      If b.Rows.Count = 0 Then
         MessageBox.Show("There are no available box loads to link to.")
         Return False
      Else
         linksGrid.DataSource = b
         linksGrid.Columns("Id").Visible = False
         linksGrid.Columns("ProjectId").Visible = False
      End If
      
      Return True 'succeeded
   End Function


   Private Sub linksGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) _
   Handles linksGrid.CellClick
      linksGrid.Rows(linksGrid.CurrentRow.Index).Selected = True
      response.result_ = SelectBoxLoadResult.Selected
      Dim dbId As Integer = linksGrid.Rows(linksGrid.CurrentRow.Index).Cells("Id").Value
      response.selectedBoxLoadDbId_ = dbId
      Close()
   End Sub
   

   'Private Sub linksGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) _
   'Handles linksGrid.CellContentClick
      
   'End Sub
   
   Private Sub cancelButton1_Click(sender As Object, e As EventArgs) _
   Handles cancelButton1.Click
      Close()
   End Sub
   
End Class

Public Interface ISelectBoxLoad
   Function AskUserToSelectBoxLoad(fromProject As String) As ISelectBoxLoadResponse
End Interface

Public Interface ISelectBoxLoadResponse
   ReadOnly Property Result As SelectBoxLoadResult
   ReadOnly Property SelectedBoxLoadDbId As Integer
End Interface

Public Class SelectBoxLoadResponse
   Implements ISelectBoxLoadResponse
   
   ReadOnly Property Result As SelectBoxLoadResult _
   Implements ISelectBoxLoadResponse.Result
      Get
         Return result_
      End Get
   End Property
   Friend result_ As SelectBoxLoadResult

   ReadOnly Property SelectedBoxLoadDbId As Integer _
   Implements ISelectBoxLoadResponse.SelectedBoxLoadDbId
      Get
         Return selectedBoxLoadDbId_
      End Get
   End Property
   Friend selectedBoxLoadDbId_ As Integer
End Class

Public Enum SelectBoxLoadResult
   Selected
   Canceled
End Enum