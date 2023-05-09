Imports Rae.RaeSolutions.Business.Entities
Imports System.Collections.Generic
Imports System.Data

Public Class ItemSelectionForm

   Sub ShowItemsWith(projectId As String)
      Dim p As project_manager = ProjectInfo.Creator.GetProject(projectId)
      
      display(p.Equipment)
      display(p.Processes)
      display(p.BoxLoads)
      
      ShowDialog()
   End Sub
   
   ReadOnly Property SelectedItems As List(Of ItemInfo)
      Get
         Dim items As New List(Of ItemInfo)
         
         For Each r As DataGridViewRow In equipmentGrid.Rows
            If CBool(r.Cells(1).Value) Then
               Dim item As ItemInfo
               item.Id = r.Cells(0).Value.ToString() : item.Type = ItemType.Pricing
               items.Add(item)
            End If
         Next
         
         For Each r As DataGridViewRow In processesGrid.Rows
            If r.Cells(1).Value Then
            	Dim item As ItemInfo
            	item.Id = r.Cells(0).Value.ToString() : item.Type = ItemType.Engineering
            	items.Add(item)
            End If
         Next
         
         For Each r As DataGridViewRow In boxLoadsGrid.Rows
            If r.Cells(1).Value Then
               Dim item As ItemInfo
               item.Id = r.Cells(0).Value.ToString() : item.Type = ItemType.BoxLoad
               items.Add(item)
            End If
         Next
         
         Return items
      End Get
   End Property
   
   
   Private Overloads Sub display(equipment As EquipmentItemList)
      For Each e As EquipmentItem In equipment
         equipmentGrid.Rows.Add(New Object() {e.id.ToString(), False, e.ToString(), e.name})
      Next
   End Sub
   
   Private Overloads Sub display(processes As ProcessItemList)
      For Each p As ProcessItem In processes
         processesGrid.Rows.Add(New Object() {p.id.ToString(), False, p.Model, p.name})
      Next
   End Sub
   
   Private Overloads Sub display(boxLoads As BoxLoadList)
      For Each b As BoxLoad In boxLoads
         boxLoadsGrid.Rows.Add(New Object() {b.id.ToString(), False, b.name, b.Description})
      Next
   End Sub

   Private Sub copyButton_Click(s As Object, e As EventArgs) _
   Handles copyButton.Click
      Me.DialogResult = Windows.Forms.DialogResult.OK
      Me.Close()
   End Sub
   
   Private Sub cancelButton2_Click(s As Object, e As EventArgs) _
   Handles cancelButton2.Click
      Me.DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub
   
End Class