Imports Rae.Data.Access
Imports Rae.Data.Access.Tools
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.Security.IntegratedSecurity
Imports System.Collections.Generic
Imports System.Text
Imports System.Environment

Public Class CustomMultiplierForm

   Private code As MultiplierCode

#Region " Event Handlers"

   Private Sub form_Load(s As Object, e As EventArgs) _
   Handles MyBase.Load
      initializeControls()
   End Sub

   Private Sub generateCodeButton_Click(s As Object, e As EventArgs) _
   Handles generateButton.Click
      'TODO: validate inputs
      
      Dim commission As Double = ConvertNull.ToDouble(commissionTextBox.Text.Replace("%", ""))
      If commission > 0 And commission < 1 Then
         ' valid
      ElseIf commission > 0 And commission < 100 Then
         commission /= 100
      Else
         Ui.MessageBox.Show("Please enter a valid commission (1-99%)", _
            MessageBoxIcon.Warning) : Exit Sub
      End If
      
      code = New MultiplierCode( _
         assignedByCombobox.Text, _
         assignedToCombobox.Text, _
         assignedOnDatePicker.Value, _
         multiplierTextBox.Text, _
         commission)

      generatedCodeTextBox.Text = code.Code

      Try
         Dim da = DataAccessFactory(Of CustomMultipliers).Create()
         da.Insert(assignedByCombobox.Text, assignedToCombobox.Text, Date.Now, _
            generatedCodeTextBox.Text, multiplierTextBox.Text, commissionTextBox.Text)
      Catch ex As Exception
         Ui.MessageBox.Show( _
            "Attempt to log custom multiplier assignment failed. Server may not be available." & _
            NewLine & NewLine & ex.Message, MessageBoxIcon.Warning)
      End Try
   End Sub
   
   Private Sub emailButton_Click(s As Object, e As EventArgs) _
   Handles emailButton.Click
      Dim toEmail As String = emailTextBox.Text
      Dim subject As String = "Custom%20Multiplier"
      Dim toName As String = New IdentityData(assignedToCombobox.Text).Name

      Dim body As String = buildEmailBody(toName, AppInfo.User.full_name, _
         generatedCodeTextBox.Text, code.Multiplier, code.Commission)

      openEmailTemplate(toEmail, subject, body)
   End Sub
   
   Private Sub codeInfoPicture_Click(s As Object, e As EventArgs) _
   Handles codeInfoPicture.Click
      ToolTip1.Show(ToolTip1.GetToolTip(s), s, 5000)
   End Sub
   
   Private Sub copyButton_Click(s As Object, e As EventArgs) _
   Handles copyButton.Click
      With generatedCodeTextBox
         .SelectAll()
         .Copy()
      End With
   End Sub

#End Region
 
  
   Private Sub initializeControls()
      Dim identities As Identities = DataAccessFactory(Of Identities).Create()
      Dim employees As List(Of String) = identities.RetrieveEmployeeUsernames()
      Dim reps As List(Of String) = identities.RetrieveRepUsernames()
      
      assignedByComboBox.DataSource = employees
      assignedToComboBox.DataSource = reps
      
      assignedByCombobox.Text = AppInfo.User.username
   End Sub
  
   Private Function buildEmailBody(toName As String, from As String, _
   code As String, multiplier As String, commission As String) As String
      Dim body As New StringBuilder()
      
      body.AppendFormat( _
         "{0}," & _
         "{1}{1}Copy the custom multiplier code and paste it into RAESolutions in order to apply the custom multiplier and commission." & _
         "{1}{1}Custom Multiplier Code: {2}" & _
         "{1}Custom Multiplier: {3}" & _
         "{1}Custom Commission: {4}" & _
         "{1}{1}This code must be applied today." & _
         "{1}{1}{5}", _
         toName, "%0A", code, multiplier, (commission * 100) & "%25", from)
         
      Return body.ToString
   End Function
   
   Private Sub openEmailTemplate([to] As String, subject As String, body As String)
      Dim command As New StringBuilder()
      With command
         .AppendFormat("mailto:{0}", [to])
         .AppendFormat("&subject={0}", subject)
         .AppendFormat("&body={0}", body)
         '.AppendFormat("&cc={0}", "testcc@testcc.com,testcc1@testcc.com")
         '.Append("&bcc={0}", "testcc@testbcc.com,testcc1@testbcc.com")
         '.Append("&Attach="c:\mailattach.txt")
      End With
      
      Dim proc As System.Diagnostics.Process
      proc = System.Diagnostics.Process.Start(command.ToString)
   End Sub
   
End Class