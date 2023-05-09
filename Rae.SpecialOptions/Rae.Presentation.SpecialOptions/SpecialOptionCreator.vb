Imports System
Imports System.Windows.Forms
Imports CNull = Rae.ConvertNull
Imports RAE.DataAccess.SpecialOptions

Namespace Rae.Presentation.SpecialOptions

   Public Class SpecialOptionCreator

      Private Sub txtDescription_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles txtDescription.Leave, txtAssignedBy.Leave, txtAssignedTo.Leave, txtPrice.Leave
         Dim control As Control = CType(sender, Control)

         Me.ValidateEmpty(control, control.Tag.ToString & " is required.")
      End Sub

      Private Sub ValidateEmpty(ByVal control As Control, ByVal message As String)
         If control.Text = "" Then
            Me.validator.SetError(control, message)
         Else
            Me.validator.SetError(control, "")
         End If
      End Sub

      Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
         Dim description, assignedBy, assignedTo As String
         Dim price As Double
         Dim expirationDate As Date
         Dim id As Integer

         ' gets values from controls
         description = Me.txtDescription.Text
         assignedBy = Me.txtAssignedBy.Text
         assignedTo = Me.txtAssignedTo.Text
         price = CNull.ToDouble(Me.txtPrice.Text)
         expirationDate = Me.dtpExpirationDate.Value

         ' creates special option
         id = SpecialOptionsDa.Create(description, price, assignedBy, assignedTo, expirationDate)

         ' sets code label
         Me.txtCode.Text = "SP" & id.ToString("00")
         Me.txtCode.BackColor = Drawing.Color.LightSteelBlue

      End Sub


   End Class

End Namespace