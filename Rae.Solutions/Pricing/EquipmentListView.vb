Imports Cols = Rae.RaeSolutions.EquipmentGridColumns
Imports Rae.RaeSolutions.Business.Entities
Imports EquipmentDa = Rae.RaeSolutions.DataAccess.Projects.EquipmentDa
Imports Rae.Collections
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Rae.RaeSolutions.DataAccess
Imports System.Data.OleDb
Imports System.Data


''' <summary>Equipment list view is a quick view of equipment in project.</summary>
<System.Serializable()> _
Public Class EquipmentListView

    ''' <summary>Constructs equipment list view.</summary>
    Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me._equipment = New EquipmentItemList
    End Sub


    ''' <summary>Equipment to display.</summary>
    Property Equipment As EquipmentItemList
        Get
            Return _equipment
        End Get
        Set(ByVal value As EquipmentItemList)
            Me._equipment = value
            Me.grdEquipment.Rows.Clear()
            If value IsNot Nothing Then
                Me.addToGrid(value)
            End If
        End Set
    End Property


    ''' <summary>Gets the selected equipment in the list. 
    ''' Gets null if there is not selected equipment.</summary>
    ReadOnly Property SelectedEquipment As EquipmentItem
        Get
            Dim id As String
            Dim equipment As EquipmentItem

            ' checks if a row is selected
            If Me.grdEquipment.SelectedRows.Count > 0 Then
                ' gets ID in selected row
                id = Me.grdEquipment.SelectedRows(0).Cells(Cols.Id).Value.ToString
                ' returns equipment associated with row
                equipment = Me.Equipment.Items(id)
                m_SelectedEquipment = Me.Equipment.Items(id)
            End If

            Return equipment
        End Get
    End Property


    Private WithEvents m_SelectedEquipment As EquipmentItem
    Private WithEvents _equipment As EquipmentItemList


#Region " Event handlers"

    ''' <summary>Event handler for equipment list view load event.</summary>
    Private Sub EquipmentListView_Load(ByVal sender As Object, ByVal e As EventArgs) _
    Handles Me.Load
        ' sets open menu's image
        Me.mnuOpen.Image = Me.ImageList1.Images(1)
    End Sub


    ''' <summary>Event handler for context menu opened event.
    ''' Displays selected equipment name so that the user will no which equipment the options apply to.
    ''' </summary>
    Private Sub mnuItemOptions_Opened(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mnuItemOptions.Opened
        Dim rowIsSelected As Boolean = Not (Me.grdEquipment.SelectedRows.Count = 0)

        Me.mnuDelete.Visible = rowIsSelected
        Me.mnuRename.Visible = rowIsSelected
        Me.mnuOpen.Visible = rowIsSelected
        Me.mnuName.Visible = rowIsSelected
        Me.mnuNew.Visible = True

        If rowIsSelected Then
            mnuName.Text = "Name: " & Me.grdEquipment.SelectedRows(0).Cells(Cols.Name).Value.ToString()
        End If
    End Sub


    Private Sub mnuRename_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mnuRename.Click
        ' allows user to rename selected equipment
        popupRename()
    End Sub

    Private Sub mnuOpen_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mnuOpen.Click
        Dim junk As String = ""

        ProjectInfo.Viewer.ViewEquipment(SelectedEquipment, True, False, junk)
    End Sub


    ''' <summary>Handles context menu new clicked event. 
    ''' Begins process for user to create equipment.</summary>
    Private Sub mnuNew_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mnuNew.Click
        ProjectInfo.Creator.CreateEquipment()
    End Sub


    Private Sub mnuDelete_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mnuDelete.Click
        ' make sure user really wants to delete equipment
        Dim shoulddel As New DoYouWantToDeleteForm
        shoulddel.DeleteWhat = DoYouWantToDeleteForm.deletetype.EquipmentItem
        shoulddel.ShowDialog()
        If Not shoulddel.DeleteConfirmed Then Exit Sub
        shoulddel = Nothing

        If SelectedEquipment IsNot Nothing Then _
           SelectedEquipment.remove()
    End Sub


    Private Sub mnuCopyExistingItem_Click(ByVal s As Object, ByVal e As EventArgs) _
    Handles mnuCopyExistingItem.Click
        Dim wf As New CopyExistingItemWorkFlow(OpenedProject.IsOpened)
        wf.Start()
    End Sub


    ''' <summary>Handles grid double click event. Views selected equipment.</summary>
    Private Sub grdEquipment_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) _
    Handles grdEquipment.DoubleClick
        If Me.SelectedEquipment IsNot Nothing Then
            Dim junk As String = ""
            ProjectInfo.Viewer.ViewEquipment(SelectedEquipment, True, False, junk)

        End If
    End Sub


    Private Sub Equipment_ItemAdded(ByVal sender As EventfulList(Of EquipmentItem), ByVal e As ListItemAddedEventArgs) _
    Handles _equipment.ItemAdded
        Dim equip = sender(e.Index)
        Me.addToGrid(equip)
    End Sub


    Private Sub selectedEquipment_Removed(ByVal equip As EquipmentItem, ByVal e As EventArgs) _
    Handles m_SelectedEquipment.Removed
        removeFromGrid(equip.id.Id)
    End Sub


    Private Sub equipment_ItemNameChanged(ByVal equip As EquipmentItem, ByVal e As EventArgs) _
    Handles _equipment.ItemNameChanged
        ' renames equipment name in grid cell
        Dim rowIndex As Integer

        rowIndex = Me.getRowIndex(equip.id.Id)

        If rowIndex = -1 Then
            ' row does not exist
            ' TEST:
            MessageBox.Show("Name changed failed. Row does not exist.")
        Else
            Me.grdEquipment.Rows(rowIndex).Cells(Cols.Name).Value = equip.name
        End If
    End Sub


    ''' <summary>Handles equipment saved event. 
    ''' Updates values in the row corresponding to the saved equipment.</summary>
    Private Sub equipment_Saved(ByVal equip As EquipmentItem, ByVal e As EventArgs)
        ' gets row corresponding to equipment ID
        Dim rowIndex = Me.getRowIndex(equip.id.Id)
        ' updates model for the saved equipment
        Dim modelCell = Me.grdEquipment.Rows(rowIndex).Cells(Cols.Model)
        modelCell.Value = equip.ToString
        ' updates validation status after equipment is saved in case changes have been made
        Dim validationCell = CType(Me.grdEquipment.Rows(rowIndex).Cells(Cols.IsValidated), DataGridViewValidationCell)
        validationCell.Value = equip.validation_status
    End Sub


    ''' <summary>
    ''' Handles grid's cell value changed event.
    ''' Updates data source with new 'IsIncluded' value.
    ''' </summary>
    ''' <remarks>
    ''' The DataGridView.CellValueChanged event occurs when the user-specified value is committed, 
    ''' which typically occurs when focus leaves the cell.
    ''' In the case of check box cells, however, you will typically want to handle the change immediately. 
    ''' To commit the change when the cell is clicked, you must handle the DataGridView.CurrentCellDirtyStateChanged event. 
    ''' In the handler, if the current cell is a check box cell, call the DataGridView.CommitEdit method and pass in the Commit value.
    ''' - MSDN Documentation
    ''' </remarks>
    Private Sub grdEquipment_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) _
    Handles grdEquipment.CellValueChanged
        Dim grid = CType(sender, DataGridView)

        ' exits if IsIncluded is not the column changing
        If Not grid.Columns(e.ColumnIndex).Name = Cols.IsIncluded Then Exit Sub

        ' gets values from grid
        Dim isIncluded As Boolean = CType(grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, Boolean)
        Dim id As String = grid.Rows(e.RowIndex).Cells(Cols.Id).Value.ToString

        ' updates whether equipment is included in project in data source
        EquipmentDa.UpdateIsIncluded(id, isIncluded)
        'TAB(TabIndex + 1)
    End Sub

    ''' <summary>
    ''' Handles grid's current cell dirty state changed event.
    ''' Commits check box column changes immediately.
    ''' </summary>
    Private Sub grdEquipment_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) _
   Handles grdEquipment.CurrentCellDirtyStateChanged
        Dim grid = CType(sender, DataGridView)

        If TypeOf grid.CurrentCell Is DataGridViewCheckBoxCell Then
            grid.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub


#End Region


#Region " Other private methods"

    ''' <summary>Pops up form to rename selected equipment, and renames equipment.</summary>
    Private Sub popupRename()
        Dim frmRename As New RenameForm
        frmRename.Text = "Rename Equipment"

        ' references selected row
        Dim selectedRow = Me.grdEquipment.SelectedRows(0)

        ' sets rename form's location
        frmRename.StartPosition = FormStartPosition.Manual
        frmRename.Location = Me.grdEquipment.GetLocationNearRow(selectedRow, frmRename.Size)

        ' sets name to current name initially
        Dim previousName = selectedRow.Cells(Cols.Name).Value.ToString
        frmRename.txtNewName.Text = previousName

        ' shows rename pop-up
        frmRename.ShowDialog()

        ' applies rename change
        If frmRename.DialogResult = DialogResult.OK Then
            ' gets selected equipment's ID
            Dim equipId As String = selectedRow.Cells(Cols.Id).Value.ToString
            ' gets the user's renamed equipment name
            Dim nameEntered As String = frmRename.txtNewName.Text.Trim
            ' checks if name actually changed
            If Not nameEntered = Me.Equipment.Items(equipId).name Then
                ' sets equipment object's name based on user's rename; object's event will update grid
                Me.Equipment.Items(equipId).name = nameEntered
                ' updates data source with new name
                EquipmentDa.Rename(equipId, nameEntered)
            End If
        End If
    End Sub


    ''' <summary>Adds equipment item to grid.</summary>
    ''' <param name="equip">Equipment item to add to grid.</param>
    Private Overloads Sub addToGrid(ByVal equip As EquipmentItem)
        Dim rowIndex = Me.grdEquipment.Rows.Add()

        ' sets column values
        With grdEquipment.Rows(rowIndex)
            .Cells(Cols.Id).Value = equip.id.ToString
            .Cells(Cols.IsIncluded).Value = equip.is_included
            CType(.Cells(Cols.IsValidated), DataGridViewValidationCell).Value = equip.validation_status
            .Cells(Cols.Model).Value = equip.ToString
            .Cells(Cols.Name).Value = equip.name
        End With

        ' set the equipment saved event handler for all added equipment
        AddHandler equip.Saved, AddressOf equipment_Saved
    End Sub


    ''' <summary>Adds equipment items in list to grid.</summary>
    ''' <param name="list">Equipment item list to add to grid.</param>
    Private Overloads Sub addToGrid(ByVal list As EquipmentItemList)

        Dim sql As String = "SELECT EquipmentID, ListPosition FROM Equipment WHERE ProjectID = @id ORDER BY ListPosition"

        'Dim projectID As String = OpenedProject.ProjectId.ToString()

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command As New OleDbCommand
        command = connection.CreateCommand()
        command.CommandText = sql

        Dim rdr As IDataReader

        connection = Common.CreateConnection(Common.ProjectsDbPath)
        command = connection.CreateCommand
        command.CommandText = sql
        command.CommandType = CommandType.Text
        command.Parameters.Add("@id", OleDbType.VarChar)
        command.Parameters("@id").Value = OpenedProject.ProjectId.ToString()

        Dim orderedList As New List(Of String)
        Dim listPosition As String = ""

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read()
                listPosition = rdr("ListPosition").ToString().Trim()
                orderedList.Add(rdr("EquipmentID").ToString().Trim())
            End While

            connection.Dispose()
        Catch ex As Exception
            Beep()
        Finally
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
            command.Parameters.Clear()
            rdr.Close()
        End Try

        Dim orderedEquip As New List(Of EquipmentItem)

        For Each item In orderedList
            For Each equipItem In list
                If item = equipItem.id.ToString().Trim() Then
                    orderedEquip.Add(equipItem)
                End If
            Next
        Next

        'list = orderedEquip
        If listPosition = "" Then
            For Each item As EquipmentItem In list
                Me.addToGrid(item)
            Next
        Else
            For Each item As EquipmentItem In orderedEquip
                Me.addToGrid(item)
            Next
        End If


        btnDown.PerformClick()
        btnUp.PerformClick()
    End Sub


    Private Sub removeFromGrid(ByVal id As String)
        ' close form if it is up
        ProjectInfo.Viewer.CloseForm(id)

        ' remove equipment from grid
        Me.grdEquipment.Rows.Remove(Me.grdEquipment.Rows(getRowIndex(id)))
    End Sub


    ''' <summary>Gets index of row containing the ID. Returns -1 if row does not exist.</summary>
    ''' <param name="id">Equipment ID to look for.</param>
    Private Function getRowIndex(ByVal id As String) As Integer
        For Each row As DataGridViewRow In Me.grdEquipment.Rows
            If row.Cells(Cols.Id).Value.ToString = id Then
                Return row.Index
            End If
        Next
        Return -1
    End Function


#End Region

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        If grdEquipment.RowCount > 0 Then
            If grdEquipment.SelectedRows.Count > 0 Then
                Dim rowCount As Integer = grdEquipment.Rows.Count
                Dim index = grdEquipment.SelectedCells(0).OwningRow.Index

                If index = 0 Then
                    Return
                End If

                Dim rows As DataGridViewRowCollection = grdEquipment.Rows

                Dim prevRow As DataGridViewRow = grdEquipment.Rows(index - 1)
                rows.Remove(prevRow)
                prevRow.Frozen = False
                rows.Insert(index, prevRow)
                grdEquipment.ClearSelection()
                grdEquipment.Rows(index - 1).Selected = True

                Dim i As Integer = 0
                For Each row In grdEquipment.Rows
                    Dim sql As String = "UPDATE Equipment SET ListPosition = " & i & " WHERE EquipmentID = @id"

                    'Dim projectID As String = OpenedProject.ProjectId.ToString()

                    Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
                    Dim command As New OleDbCommand
                    command = connection.CreateCommand()
                    command.CommandText = sql

                    Dim rdr As IDataReader

                    connection = Common.CreateConnection(Common.ProjectsDbPath)
                    command = connection.CreateCommand
                    command.CommandText = sql
                    command.CommandType = CommandType.Text
                    command.Parameters.Add("@id", OleDbType.VarChar)
                    command.Parameters("@id").Value = grdEquipment.Rows(i).Cells(Cols.Id).Value.ToString

                    Try
                        connection.Open()
                        command.ExecuteNonQuery()
                        connection.Dispose()
                    Catch ex As Exception
                        Beep()
                    Finally
                        If connection.State <> ConnectionState.Closed Then _
                           connection.Close()
                        command.Parameters.Clear()
                        command.Dispose()
                    End Try

                    i += 1
                Next
            End If
        End If
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        If grdEquipment.RowCount > 0 Then
            If grdEquipment.SelectedRows.Count > 0 Then
                Dim rowCount As Integer = grdEquipment.Rows.Count
                Dim index = grdEquipment.SelectedCells(0).OwningRow.Index

                If index = (rowCount - 1) Then
                    Return
                End If

                Dim rows As DataGridViewRowCollection = grdEquipment.Rows

                Dim nextRow As DataGridViewRow = grdEquipment.Rows(index + 1)
                rows.Remove(nextRow)
                nextRow.Frozen = False
                rows.Insert(index, nextRow)
                grdEquipment.ClearSelection()
                grdEquipment.Rows(index + 1).Selected = True

                Dim i As Integer = 0
                For Each row In grdEquipment.Rows
                    Dim sql As String = "UPDATE Equipment SET ListPosition = " & i & " WHERE EquipmentID = @id"

                    'Dim projectID As String = OpenedProject.ProjectId.ToString()

                    Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
                    Dim command As New OleDbCommand
                    command = connection.CreateCommand()
                    command.CommandText = sql

                    Dim rdr As IDataReader

                    connection = Common.CreateConnection(Common.ProjectsDbPath)
                    command = connection.CreateCommand
                    command.CommandText = sql
                    command.CommandType = CommandType.Text
                    command.Parameters.Add("@id", OleDbType.VarChar)
                    command.Parameters("@id").Value = grdEquipment.Rows(i).Cells(Cols.Id).Value.ToString

                    Try
                        connection.Open()
                        command.ExecuteNonQuery()
                        connection.Dispose()
                    Catch ex As Exception
                        Beep()
                    Finally
                        If connection.State <> ConnectionState.Closed Then _
                           connection.Close()
                        command.Parameters.Clear()
                        command.Dispose()
                    End Try

                    i += 1
                Next
            End If
        End If
    End Sub
End Class