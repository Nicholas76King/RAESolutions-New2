<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProjectRevisionForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.captionLabel = New System.Windows.Forms.Label()
        Me.projectNamePanel = New System.Windows.Forms.Panel()
        Me.lblReason = New System.Windows.Forms.Label()
        Me.txtReason = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(312, 174)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'captionLabel
        '
        Me.captionLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.captionLabel.BackColor = System.Drawing.Color.Transparent
        Me.captionLabel.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.captionLabel.ForeColor = System.Drawing.Color.White
        Me.captionLabel.Location = New System.Drawing.Point(5, 17)
        Me.captionLabel.Margin = New System.Windows.Forms.Padding(4)
        Me.captionLabel.Name = "captionLabel"
        Me.captionLabel.Size = New System.Drawing.Size(395, 33)
        Me.captionLabel.TabIndex = 8
        Me.captionLabel.Text = "Please input reason for project revision:"
        '
        'projectNamePanel
        '
        Me.projectNamePanel.AutoSize = True
        Me.projectNamePanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.projectNamePanel.Location = New System.Drawing.Point(0, 0)
        Me.projectNamePanel.Name = "projectNamePanel"
        Me.projectNamePanel.Size = New System.Drawing.Size(405, 0)
        Me.projectNamePanel.TabIndex = 20
        Me.projectNamePanel.Visible = False
        '
        'lblReason
        '
        Me.lblReason.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblReason.BackColor = System.Drawing.Color.Transparent
        Me.lblReason.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReason.ForeColor = System.Drawing.Color.Yellow
        Me.lblReason.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Message
        Me.lblReason.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblReason.Location = New System.Drawing.Point(-3, 159)
        Me.lblReason.Margin = New System.Windows.Forms.Padding(4)
        Me.lblReason.Name = "lblReason"
        Me.lblReason.Size = New System.Drawing.Size(395, 18)
        Me.lblReason.TabIndex = 9
        Me.lblReason.Text = "YOU ARE NOT THE PROJECT OWNER (OWNER: JOSHH)"
        Me.lblReason.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.lblReason, "If you are not the project owner, any changes you make to any part of the project" &
        " will force a project revision and the reason for the change must be documented." &
        "")
        '
        'txtReason
        '
        Me.txtReason.BackColor = System.Drawing.Color.White
        Me.txtReason.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReason.Location = New System.Drawing.Point(7, 57)
        Me.txtReason.Multiline = True
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(392, 95)
        Me.txtReason.TabIndex = 0
        '
        'ProjectRevisionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(405, 209)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtReason)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.captionLabel)
        Me.Controls.Add(Me.lblReason)
        Me.Controls.Add(Me.projectNamePanel)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ProjectRevisionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Project Revision"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
   Friend WithEvents captionLabel As System.Windows.Forms.Label
   Friend WithEvents projectNamePanel As System.Windows.Forms.Panel
    ''Friend WithEvents GradientPanel3 As Rae.Ui.Controls.GradientPanel
    ''Friend WithEvents GradientPanel1 As Rae.Ui.Controls.GradientPanel
    Friend WithEvents txtReason As System.Windows.Forms.TextBox
   Friend WithEvents lblReason As System.Windows.Forms.Label
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
