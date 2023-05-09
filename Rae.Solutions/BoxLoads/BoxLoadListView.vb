Imports Cols = Rae.RaeSolutions.ProcessGridColumns
Imports Rae.RaeSolutions.Business.Entities
Imports ProcessItemDA = Rae.RaeSolutions.DataAccess.Projects.ProcessItemDA
Imports Rae.Collections
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Rae.CoolStuff

Public Class BoxLoadListView


#Region " External"

   Public Class ColumnNames
     Public Const ItemId As String = "ItemIdColumn"
     Public Const Name As String = "NameColumn"
     Public Const Linked As String = "LinkedColumn"
   End Class
   
   
   Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
      
      ' Add any initialization after the InitializeComponent() call.
      boxLoads_ = New BoxLoadList()
   End Sub


   ''' <summary>
   ''' List of box loads to show in control
   ''' </summary>
   Property BoxLoads() As BoxLoadList
      Get
         Return boxLoads_
      End Get
      Set(value As BoxLoadList)
         Me.BoxLoadGrid.Rows.Clear()
         
         If value IsNot Nothing Then
            boxLoads_ = value
            add(boxLoads_)
         Else
            boxLoads_ = New BoxLoadList()
         End If
      End Set
   End Property
   
   
   ''' <summary>
   ''' Sets checkmark to show box load is linked
   ''' </summary>
   ''' <param name="itemId">
   ''' Item ID of box load to check
   ''' </param>
   Sub Link(itemId As String)
      link(itemId, True)
   End Sub
   
   
   ''' <summary>
   ''' Unchecks checkmark to show box load is not linked
   ''' </summary>
   ''' <param name="itemId">
   ''' Item ID of box load to uncheck
   ''' </param>
   Sub Unlink(itemId As String)
      link(itemId, False)
   End Sub
   
#End Region
   
   
#Region " Internal"
   
   Protected WithEvents boxLoads_ As BoxLoadList

   
   Private Sub add(boxLoads As BoxLoadList)
      For Each b As BoxLoad In boxLoads
         Add(b)
      Next
   End Sub
   
   Private Sub add(boxLoad As BoxLoad)
      Dim da As New Rae.Data.Access.BoxLoadProjects()
      add(boxLoad.id.ToString(), boxLoad.name, da.IsLinked(boxLoad.DbId))
   End Sub
   
   Private Sub add(itemId As String, name As String, linked As Boolean)
      BoxLoadGrid.Rows.Add(New Object() {itemId, name, linked})
   End Sub
   
   Private Sub rename(itemId As String, name As String)
      Throw New NotImplementedException()
   End Sub
   
   Private Sub open()
      Dim itemId As String = selectedItemId()
      ProjectInfo.Viewer.ViewBoxLoad(itemId)
   End Sub
   
   Private Sub popUp()
      Dim menuPosition As Point
      menuPosition = BoxLoadGrid.GetLocationNearSelectedRow(optionsMenu.Size)
      optionsMenu.Show(menuPosition)
   End Sub
   
   Private Function userContinuesToDelete() As Boolean
      Dim prompt As New DoYouWantToDeleteForm()
      prompt.DeleteWhat = DoYouWantToDeleteForm.deletetype.BoxLoadItem
      prompt.ShowDialog()
      
      If prompt.DeleteConfirmed Then
         Return True
      Else
         Return False
      End If
   End Function
   
   Private Function selectedItemId() As String
      Dim itemId As String
      
      If BoxLoadGrid.SelectedRows.Count > 0 Then
         itemId = BoxLoadGrid.SelectedRows(0).Cells(ColumnNames.ItemId).Value.ToString()
      End If
      
      Return itemId
   End Function
   
   Private Function selectedBoxLoad() As BoxLoad
      Dim itemId As String = selectedItemId()
      Return OpenedProject.Manager.BoxLoads.Items(itemId)
   End Function
   
   Private Function indexOf(boxLoad As BoxLoad) As Integer
      Dim itemId As String = boxLoad.id.ToString
      Return indexOf(itemId)
   End Function
   
   Private Function indexOf(itemId As String) As Integer
      Dim i, index As Integer
      
      For i = 0 To BoxLoadGrid.Rows.Count - 1
         If Me.itemId(i) = itemId Then
            index = i
            Return index
         End If
      Next
      
      Return -1
   End Function
   
   Private Function itemId(index As Integer) As String
      Return BoxLoadGrid.Rows(index).Cells(ColumnNames.ItemId).Value.ToString
   End Function
   
   
   Private Sub link(itemId As String, isLinked As Boolean)
      Dim index As Integer = indexOf(itemId)
      If index > -1 Then
         BoxLoadGrid.Rows(index).Cells(ColumnNames.Linked).Value = isLinked
      End If
   End Sub
   
   
#Region " Event handlers"


   ''' <summary>
   ''' Event handler for process list view load event.
   ''' </summary>
   Private Sub BoxLoadListView_Load(sender As Object, e As EventArgs) _
   Handles Me.Load
     ' sets open menu's image
     Me.openMenu.Image = Me.ImageList1.Images(1)
   End Sub
   
   
   Private Sub BoxLoads_ItemAdded(sender As EventfulList(Of BoxLoad), e As ListItemAddedEventArgs) _
   Handles boxLoads_.ItemAdded
      add(sender(e.Index))
   End Sub
   
   Private Sub BoxLoads_ItemRemoved(sender As EventfulList(Of BoxLoad), e As ListItemRemovedEventArgs) _
   Handles boxLoads_.ItemRemoved
      'remove(sender(e.Index))
   End Sub
   
   Private Sub BoxLoads_ItemRenamed(sender As BoxLoad, e As EventArgs) _
   Handles boxLoads_.ItemNameChanged
      'rename(sender)
   End Sub
   
   Private Sub BoxLoadGrid_MouseClick(sender As Object, e As MouseEventArgs) _
   Handles BoxLoadGrid.MouseClick
      ' on right-click, show context menu
      If e.Button = Windows.Forms.MouseButtons.Right Then
         If BoxLoadGrid.SelectedRows.Count > 0 Then
            popUp()
         End If
      End If
   End Sub
   
   Private Sub BoxLoadGrid_DoubleClick(sender As Object, e As EventArgs) _
   Handles BoxLoadGrid.DoubleClick
      If BoxLoadGrid.SelectedRows.Count = 0 Then Exit Sub
      open()
   End Sub


   ''' <summary>
   ''' Handles context menu open clicked event. Opens equipment.
   ''' </summary>
   Private Sub mnuOpen_Click(sender As Object, e As EventArgs) _
   Handles openMenu.Click
      open()
   End Sub

   ''' <summary>
   ''' Handles context menu new clicked event. Begins process for user to create process.
   ''' </summary>
   Private Sub mnuNew_Click(sender As Object, e As EventArgs) _
   Handles newMenu.Click
      ProjectInfo.Viewer.ViewBoxLoad()
   End Sub
   
   Private Sub mnuItemOptions_Opened(sender As Object, e As EventArgs) _
   Handles optionsMenu.Opened
      If Me.BoxLoadGrid.SelectedRows.Count = 0 Then
         ' hides item specific menu options if an item is not selected
         Me.nameMenu.Visible = False
         Me.openMenu.Visible = False
         Me.deleteMenu.Visible = False
         Me.duplicateMenu.Visible = False
         'Me.mnuRename.Visible = False
         Me.newMenu.Visible = True
      Else
         Me.nameMenu.Visible = True
         Me.openMenu.Visible = True
         Me.deleteMenu.Visible = True
         'TODO: handle duplicate click before showing Duplicate menu item
         Me.duplicateMenu.Visible = False
         'Me.mnuRename.Visible = True
         Me.newMenu.Visible = True
         ' displays name of selected equipment
         Me.nameMenu.Text = "Name: " & Me.BoxLoadGrid.SelectedRows(0).Cells(Cols.Name).Value.ToString
      End If
   End Sub
   
   Private Sub mnuDelete_Click(sender As Object, e As EventArgs) _
   Handles deleteMenu.Click
      If userContinuesToDelete() Then
         BoxLoads.Remove(selectedBoxLoad())	
      End If
   End Sub
   
   Private Sub BoxLoads_RemovingItem(sender As EventfulList(Of BoxLoad), e As ListItemRemovedEventArgs) _
   Handles boxLoads_.RemovingItem
      Dim b As BoxLoad = CType(sender(e.Index), BoxLoad)
      Dim i As Integer = indexOf(b)
      BoxLoadGrid.Rows.Remove(BoxLoadGrid.Rows(i))
   End Sub
   
#End Region
 
   
   
   
   Private Sub mnuduplicate_Click(sender As Object, e As EventArgs) _
   Handles duplicateMenu.Click
      'Dim frmNewProcess As New NewItemForm2
      'Dim csc As New CoolStuff.CoolStuffCommon

      'frmNewProcess.NewItem(frmNewProcess.NewItemType.SelectionOnly)
      'frmNewProcess.ShowDialog()
      'Dim sql As String
      'If Len(frmNewProcess.selectionNameTextBox.Text) > 0 Then

      '   sql = csc.GetDuplicateSql("", Me.SelectedBoxLoad, 0)
      '   CoolStuff.cl_connection.ExecuteSql(sql, "UI")

      '   sql = "update coolstuffprojects set processid = createdwhen, blname = '" & frmNewProcess.selectionNameTextBox.Text & "', revision=0 where id = " & Me.SelectedBoxLoad
      '   CoolStuff.cl_connection.ExecuteSql(sql, "UI")

      'End If
   End Sub

#End Region
   
End Class

'    Private Sub RemoveFromGrid(ByVal id As String)

'        ' close form if it is up
'        ProjectInfo.Viewer.CloseForm(id)

'        ' remove process from grid
'        Me.BoxLoadGrid.Rows.Remove(Me.BoxLoadGrid.Rows(GetRowIndex(id)))

'    End Sub


    '''' <summary>
    '''' Pops up form to rename selected equipment, and renames equipment.
    '''' </summary>
    'Private Sub PopupRename()
    '    Dim frmRename As New RenameForm
    '    frmRename.Text = "Rename Selection"
    '    Dim selectedRow As DataGridViewRow

    '    ' references selected row
    '    selectedRow = Me.BoxLoadGrid.SelectedRows(0)

    '    ' sets rename form's location
    '    frmRename.StartPosition = FormStartPosition.Manual
    '    frmRename.Location = Me.GetLocationNearRow(selectedRow, frmRename.Size)

    '    ' sets name to current name initially
    '    Dim previousName As String = selectedRow.Cells(Cols.Name).Value.ToString
    '    frmRename.txtNewName.Text = previousName

    '    ' shows rename pop-up
    '    frmRename.ShowDialog()

    '    ' applies rename change
    '    If frmRename.DialogResult = DialogResult.OK Then
    '        ' gets selected equipment's ID
    '        Dim id As String = selectedRow.Cells(Cols.Id).Value.ToString
    '        ' gets the user's renamed equipment name
    '        Dim nameEntered As String = frmRename.txtNewName.Text.Trim
    '        ' checks if name actually changed
    '        'If Not nameEntered = Me.Processes.Items(id).Name Then
    '        '    ' sets equipment object's name based on user's rename; object's event will update grid
    '        '    Me.BoxLoadGrid.Items(id).Name = nameEntered
    '        '    ' updates data source with new name
    '        '    ProcessItemDA.Rename(id, nameEntered)
    '        'End If
    '    End If
    'End Sub

      '''' <summary>
   '''' Gets index of row containing the ID. Returns -1 if row does not exist.
   '''' </summary>
   '''' <param name="id">
   '''' ID to look for.
   '''' </param>
   'Private Function GetRowIndex(ByVal id As String) As Integer
   '   For Each row As DataGridViewRow In Me.BoxLoadGrid.Rows
   '      If row.Cells(ColumnNames.Id).Value = id Then
   '         Return row.Index
   '      End If
   '   Next
   '   Return -1
   'End Function