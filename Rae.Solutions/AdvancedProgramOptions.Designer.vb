<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdvancedProgramOptions
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtProjectsPath = New System.Windows.Forms.TextBox()
        Me.btnSaveProjectsPath = New System.Windows.Forms.Button()
        Me.btnProposalInfoFix = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(584, 40)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Changes to these settings can break the RAE Solutions program.  " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please contact " & _
    "the RAE Corporation I.T. department before proceeding."
        Me.Label1.UseWaitCursor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(172, 32)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Projects.mdb path:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(leave blank for default)"
        '
        'txtProjectsPath
        '
        Me.txtProjectsPath.Location = New System.Drawing.Point(183, 70)
        Me.txtProjectsPath.Name = "txtProjectsPath"
        Me.txtProjectsPath.Size = New System.Drawing.Size(365, 20)
        Me.txtProjectsPath.TabIndex = 2
        '
        'btnSaveProjectsPath
        '
        Me.btnSaveProjectsPath.Location = New System.Drawing.Point(570, 67)
        Me.btnSaveProjectsPath.Name = "btnSaveProjectsPath"
        Me.btnSaveProjectsPath.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveProjectsPath.TabIndex = 3
        Me.btnSaveProjectsPath.Text = "Save"
        Me.btnSaveProjectsPath.UseVisualStyleBackColor = True
        '
        'btnProposalInfoFix
        '
        Me.btnProposalInfoFix.Location = New System.Drawing.Point(16, 115)
        Me.btnProposalInfoFix.Name = "btnProposalInfoFix"
        Me.btnProposalInfoFix.Size = New System.Drawing.Size(116, 23)
        Me.btnProposalInfoFix.TabIndex = 4
        Me.btnProposalInfoFix.Text = "Proposal Info Fix"
        Me.btnProposalInfoFix.UseVisualStyleBackColor = True
        '
        'AdvancedProgramOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 262)
        Me.Controls.Add(Me.btnProposalInfoFix)
        Me.Controls.Add(Me.btnSaveProjectsPath)
        Me.Controls.Add(Me.txtProjectsPath)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "AdvancedProgramOptions"
        Me.Text = "AdvancedProgramOptions"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtProjectsPath As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveProjectsPath As System.Windows.Forms.Button
    Friend WithEvents btnProposalInfoFix As System.Windows.Forms.Button
End Class
