Imports Rae.RaeSolutions.Business.Entities
Imports Rae.Reporting.CrystalReports
Imports Rae.Ui.quickies

''' <summary>Control containing controls for common specifications.</summary>
''' <remarks>Can be inherited from to create equipment spec controls.</remarks>
Public Class CommonSpecsControl

   ' can't make methods mustoverride otherwise; you can't view user control in designer



   ''' <summary>Passes parameters to submittal accessories report.</summary>
   Overridable Sub PassSubmittalParams(reportViewer As base_report_viewer)
   End Sub

   ''' <summary>Passes parameters to order write up report.</summary>




    Overridable Sub PassOrderWriteUpParams(ByVal reportViewer As base_report_viewer)
    End Sub

   ''' <summary>Sets control values.</summary>
   Overridable Sub SetControlValues(equipment As EquipmentItem)
   End Sub

   ''' <summary>Gets control values and sets equipment properties with them.</summary>
   Overridable Sub GetControlValues(ByRef equipment As EquipmentItem)
   End Sub

   Private Sub CommonSpecsControl_Load(sender As Object, e As EventArgs) _
   Handles Me.Load
      If AppInfo.Division = Business.Division.TSI Then
         Me.cboControlVoltage.Items.Add("24")
      End If


        If AppInfo.Division = Business.Division.CRI Then
            Dim l = cboControlVoltage.FindString("115/24")
            If l >= 0 Then
                cboControlVoltage.Items.RemoveAt(l)
            End If
        End If

    End Sub


   Private Sub numberTextBoxes_KeyDown(sender As Object, e As KeyEventArgs) _
   Handles txtLength.KeyDown, txtWidth.KeyDown, txtHeight.KeyDown, _
   txtEstShippingWeight.KeyDown, txtEstOperatingWeight.KeyDown, txtMca.KeyDown, txtRla.KeyDown
      e.SuppressKeyPress = Not key_code.is_number(e.KeyCode)
   End Sub
   
   private max_lines as integer = 4
   private new_line as string = system.environment.newLine
   
   Private Sub txtSpecialNotes_KeyDown(sender As Object, e As KeyEventArgs) _
   Handles txtSpecialInstructions.KeyDown  
      if txtSpecialInstructions.Text.Length >= 255 then
         'todo: e.keycode <> navigation_key
         if e.keycode <> keys.back and not key_code.navigation(e.keycode) and e.keycode <> keys.shiftkey then
            warn("Special Instructions: max number of characters is 255.")
         end if
      else if txtSpecialInstructions.Lines.Length > = max_lines then
         if e.keycode = keys.return then
            'e.SuppressKeyPress = True ' suppress doesn't work when messagebox is used
            user_exceeded_max_number_of_lines = true
            warn("Special Instructions: max number of lines is 4." & new_line & new_line & _
                  "This helps prevent text from being truncated on the reports.")
         end if
      end if
   end sub
   
   private user_exceeded_max_number_of_lines as boolean
   
   Private Sub txtSpecialInstructions_KeyPress(sender As Object, e As KeyPressEventArgs) _
   Handles txtSpecialInstructions.KeyPress
      if user_exceeded_max_number_of_lines then 
         e.handled = true
         user_exceeded_max_number_of_lines = false
      end if
   end sub
   
   private sub txtSpecialInstructions_TextChanged(textbox as TextBox, e as eventArgs) _
   handles txtSpecialInstructions.textChanged
      if textbox.lines.length > max_lines
         textbox.undo()
         textbox.ClearUndo()
         warn("Special Instructions: max number of lines is 4." & new_line & new_line & _
              "This helps prevent text from being truncated on the reports.")
      end if
   end sub

   Private Sub pic_special_instruction_help_Click(sender as object, e as EventArgs) _
   Handles PictureBox1.Click
      commonTips.show(commonTips.GetToolTip(pictureBox1), pictureBox1)
   End Sub
End Class
