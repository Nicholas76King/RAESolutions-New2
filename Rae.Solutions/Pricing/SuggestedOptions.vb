Public Class SuggestedOptionsForm

   Private msgstr As String = ""
   Private msgcaption As String = ""

   Private addOption_ As Boolean
   ''' <summary>
   ''' AddOption
   ''' </summary>
   Public ReadOnly Property AddOption() As Boolean
      Get
         Return Me.addOption_
      End Get
   End Property

   Public Sub New(ByVal mainText As String, ByVal subtext As String)

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      Me.lblCaption.Text = mainText
      Me.lblSubText.Text = subtext

      If Trim(subtext) = "" Then
         Me.Height -= 5
         pnlSubText.Visible = False
      End If

   End Sub

   Public Sub New(ByVal mainText As String, ByVal subtext As String, ByVal formCaption As String)
      Me.New(mainText, subtext)
      If formCaption <> "" Then
         Me.Text = formCaption
      End If
   End Sub

   Public Sub New(ByVal maintext As String, ByVal subtext As String, ByVal formCaption As String, ByVal infoMessage As String, ByVal infoCaption As String)
      Me.New(maintext, subtext, formCaption)
      Me.msgstr = infoMessage
      Me.msgcaption = infoCaption
   End Sub

   Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click
      Me.addOption_ = True
      Me.Hide()
   End Sub

   Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click
      Me.addOption_ = False
      Me.Hide()
   End Sub

   Private Sub btnInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfo.Click
      MessageBox.Show(Me.msgstr, Me.msgcaption, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
   End Sub

   Private Sub btnInfo_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInfo.MouseEnter
      btnInfo.Image = My.Resources.Message
   End Sub

   Private Sub btnInfo_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInfo.MouseLeave
      btnInfo.Image = My.Resources.Info
   End Sub

End Class