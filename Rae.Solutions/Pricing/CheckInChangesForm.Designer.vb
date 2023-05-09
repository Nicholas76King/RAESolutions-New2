<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckInChangesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CheckInChangesForm))
        Me.btnUserServerVersion = New System.Windows.Forms.Button()
        Me.btnUseMyVersion = New System.Windows.Forms.Button()
        Me.lblUserServerVersion = New System.Windows.Forms.Label()
        Me.lblUseMyVersion = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblCancel = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblProject = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnUserServerVersion
        '
        Me.btnUserServerVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUserServerVersion.BackColor = System.Drawing.Color.Transparent
        Me.btnUserServerVersion.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnUserServerVersion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUserServerVersion.Location = New System.Drawing.Point(21, 342)
        Me.btnUserServerVersion.Name = "btnUserServerVersion"
        Me.btnUserServerVersion.Size = New System.Drawing.Size(296, 33)
        Me.btnUserServerVersion.TabIndex = 6
        Me.btnUserServerVersion.Text = "Make Server Version Most Recent"
        Me.btnUserServerVersion.UseVisualStyleBackColor = False
        '
        'btnUseMyVersion
        '
        Me.btnUseMyVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUseMyVersion.BackColor = System.Drawing.Color.Transparent
        Me.btnUseMyVersion.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnUseMyVersion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUseMyVersion.Location = New System.Drawing.Point(352, 342)
        Me.btnUseMyVersion.Name = "btnUseMyVersion"
        Me.btnUseMyVersion.Size = New System.Drawing.Size(296, 33)
        Me.btnUseMyVersion.TabIndex = 7
        Me.btnUseMyVersion.Text = "Make My Version Most Recent"
        Me.btnUseMyVersion.UseVisualStyleBackColor = False
        '
        'lblUserServerVersion
        '
        Me.lblUserServerVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUserServerVersion.BackColor = System.Drawing.Color.White
        Me.lblUserServerVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUserServerVersion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserServerVersion.Location = New System.Drawing.Point(12, 333)
        Me.lblUserServerVersion.Name = "lblUserServerVersion"
        Me.lblUserServerVersion.Size = New System.Drawing.Size(314, 145)
        Me.lblUserServerVersion.TabIndex = 8
        Me.lblUserServerVersion.Text = resources.GetString("lblUserServerVersion.Text")
        '
        'lblUseMyVersion
        '
        Me.lblUseMyVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUseMyVersion.BackColor = System.Drawing.Color.White
        Me.lblUseMyVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUseMyVersion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUseMyVersion.Location = New System.Drawing.Point(343, 333)
        Me.lblUseMyVersion.Name = "lblUseMyVersion"
        Me.lblUseMyVersion.Size = New System.Drawing.Size(314, 145)
        Me.lblUseMyVersion.TabIndex = 9
        Me.lblUseMyVersion.Text = resources.GetString("lblUseMyVersion.Text")
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(685, 342)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 33)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'lblCancel
        '
        Me.lblCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCancel.BackColor = System.Drawing.Color.White
        Me.lblCancel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCancel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCancel.Location = New System.Drawing.Point(674, 333)
        Me.lblCancel.Name = "lblCancel"
        Me.lblCancel.Size = New System.Drawing.Size(108, 145)
        Me.lblCancel.TabIndex = 11
        Me.lblCancel.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "NOTE:  If you choose cancel the project will not be check in."
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 299)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(769, 31)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Please choose the version you would like to make most recent:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblProject
        '
        Me.lblProject.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProject.Location = New System.Drawing.Point(13, 0)
        Me.lblProject.Name = "lblProject"
        Me.lblProject.Size = New System.Drawing.Size(769, 31)
        Me.lblProject.TabIndex = 13
        Me.lblProject.Text = "Project: "
        Me.lblProject.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'CheckInChangesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(786, 586)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblProject)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnUserServerVersion)
        Me.Controls.Add(Me.btnUseMyVersion)
        Me.Controls.Add(Me.lblUseMyVersion)
        Me.Controls.Add(Me.lblUserServerVersion)
        Me.Controls.Add(Me.lblCancel)
        Me.MaximumSize = New System.Drawing.Size(802, 625)
        Me.MinimumSize = New System.Drawing.Size(802, 625)
        Me.Name = "CheckInChangesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Changes Made To Server Data"
        Me.ResumeLayout(False)

    End Sub
    ''Friend WithEvents ServerDataChanges As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnUserServerVersion As System.Windows.Forms.Button
   Friend WithEvents btnUseMyVersion As System.Windows.Forms.Button
   Friend WithEvents lblUserServerVersion As System.Windows.Forms.Label
   Friend WithEvents lblUseMyVersion As System.Windows.Forms.Label
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents lblCancel As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents lblProject As System.Windows.Forms.Label
End Class
