Imports rae.solutions

Public Class QuickStart
   
   Private protoFont As System.Drawing.Font
   
   Private Sub QuickStart_Load(sender As Object, e As EventArgs) _
   Handles Me.Load
      If Not Me.DesignMode Then
         If AppInfo.User.authority_group = user_group.rep Then
             newBoxLoadLabel.Visible = False
         End If
      End If
   End Sub

   Private Sub newProjectLabel_Click(sender As Object, e As EventArgs) _
   Handles newProjectLabel.Click
      ProjectInfo.Creator.CreateProject()
   End Sub

   Private Sub newEquipmentLabel_Click(sender As Object, e As EventArgs) _
   Handles newEquipmentLabel.Click
      ProjectInfo.Creator.CreateEquipment()
   End Sub

   Private Sub openProjectLabel_Click(sender As Object, e As EventArgs) _
   Handles openProjectLabel.Click
      ProjectInfo.Creator.CreateExistingProject()
   End Sub

   Private Sub newSelectionLabel_Click(sender As Object, e As EventArgs) _
   Handles newSelectionLabel.Click
      AppInfo.Main.StartNewProcess()
   End Sub
   
   Private Sub newBoxLoadLabel_Click(sender As Object, e As EventArgs) _
   Handles newBoxLoadLabel.Click
      ProjectInfo.Viewer.ViewBoxLoad()
   End Sub

   private sub lbl_select_unit_cooler_click() handles lbl_select_unit_cooler.click
      ProjectInfo.Viewer.view(of unit_cooler_selection_screen)()
      'application_controller.show(of unit_cooler_selection_screen)()
   end sub

   Private Sub MouseEnterForeColor(sender As Object, e As EventArgs) _
   Handles newEquipmentLabel.MouseEnter, newProjectLabel.MouseEnter, newSelectionLabel.MouseEnter, openProjectLabel.MouseEnter, newBoxLoadLabel.MouseEnter, lbl_select_unit_cooler.MouseEnter
      sender.Forecolor = Color.DarkBlue
      protoFont = sender.font
      sender.Font = New System.Drawing.Font(protoFont, FontStyle.Bold)
   End Sub

   Private Sub MouseLeaveForeColor(sender As Object, e As EventArgs) _
   Handles newEquipmentLabel.MouseLeave, newProjectLabel.MouseLeave, newSelectionLabel.MouseLeave, openProjectLabel.MouseLeave, newBoxLoadLabel.MouseLeave, lbl_select_unit_cooler.MouseLeave
      sender.forecolor = Color.RoyalBlue
      protoFont = sender.font
      sender.Font = New System.Drawing.Font(protoFont, FontStyle.Regular)
   End Sub
   
End Class
