Public Class NewProjectForm
   Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

   Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call

   End Sub

   'Form overrides dispose to clean up the component list.
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If Not (components Is Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents btnOK As System.Windows.Forms.Button
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.Label1 = New System.Windows.Forms.Label
      Me.txtProjectName = New System.Windows.Forms.TextBox
      Me.btnOK = New System.Windows.Forms.Button
      Me.btnCancel = New System.Windows.Forms.Button
      Me.SuspendLayout()
      '
      'Label1
      '
      Me.Label1.Location = New System.Drawing.Point(4, 16)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(84, 23)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Project name"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtProjectName
      '
      Me.txtProjectName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtProjectName.Location = New System.Drawing.Point(100, 16)
      Me.txtProjectName.Name = "txtProjectName"
      Me.txtProjectName.Size = New System.Drawing.Size(196, 21)
      Me.txtProjectName.TabIndex = 2
      '
      'btnOK
      '
      Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnOK.Location = New System.Drawing.Point(140, 52)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(75, 24)
      Me.btnOK.TabIndex = 4
      Me.btnOK.Text = "OK"
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCancel.Location = New System.Drawing.Point(220, 52)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 24)
      Me.btnCancel.TabIndex = 5
      Me.btnCancel.Text = "Cancel"
      '
      'NewProjectForm
      '
      Me.AcceptButton = Me.btnOK
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
      Me.BackColor = System.Drawing.Color.White
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(310, 88)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.txtProjectName)
      Me.Controls.Add(Me.Label1)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Name = "NewProjectForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "New Project"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region


#Region " Public"

   Public IsValid As Boolean = False

#End Region


#Region " Event Handlers"

   Private Sub btnCancel_Click( _
   ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles btnCancel.Click
      Me.IsValid = False
      Me.Hide()
   End Sub


   Private Sub btnOK_Click( _
   ByVal sender As System.Object, ByVal e As System.EventArgs) _
   Handles btnOK.Click
      ' checks if submittal project name is valid
      If Me.IsProjectNameValid(Me.txtProjectName.Text.Trim) Then
         ' indicates project name is valid
         Me.IsValid = True
         ' hides form
         Me.Visible = False
      Else
         ' informs user of problem
         MessageBox.Show("Project name is empty. Please enter project name.", _
            "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      End If

   End Sub

#End Region


#Region " Private methods"

   Private Function IsProjectNameValid(ByVal projectName As String) As Boolean
      Dim _isValid As Boolean

      If projectName.Length > 0 Then
         _isValid = True
      Else
         _isValid = False
      End If

      Return _isValid
   End Function

#End Region


End Class
