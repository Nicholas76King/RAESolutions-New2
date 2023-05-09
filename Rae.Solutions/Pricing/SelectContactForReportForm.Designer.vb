<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectContactForReportForm
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
        Me.fromLabel = New System.Windows.Forms.Label()
        Me.toLabel = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.toInstructionsLabel = New System.Windows.Forms.Label()
        Me.toContactControl = New Rae.RaeSolutions.ContactManagerControl()
        Me.fromInstructionsLabel = New System.Windows.Forms.Label()
        Me.fromContactControl = New Rae.RaeSolutions.ContactManagerControl()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cancelButton2 = New System.Windows.Forms.Button()
        Me.okButton = New System.Windows.Forms.Button()
        Me.txtSalesperson = New System.Windows.Forms.TextBox()
        Me.txtEngineer = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'fromLabel
        '
        Me.fromLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fromLabel.ForeColor = System.Drawing.Color.DimGray
        Me.fromLabel.Location = New System.Drawing.Point(12, 10)
        Me.fromLabel.Name = "fromLabel"
        Me.fromLabel.Size = New System.Drawing.Size(47, 24)
        Me.fromLabel.TabIndex = 5
        Me.fromLabel.Text = "From"
        Me.fromLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'toLabel
        '
        Me.toLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toLabel.ForeColor = System.Drawing.Color.DimGray
        Me.toLabel.Location = New System.Drawing.Point(9, 9)
        Me.toLabel.Name = "toLabel"
        Me.toLabel.Size = New System.Drawing.Size(50, 24)
        Me.toLabel.TabIndex = 4
        Me.toLabel.Text = "To"
        Me.toLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.toInstructionsLabel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.toLabel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.toContactControl)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.fromInstructionsLabel)
        Me.SplitContainer1.Panel2.Controls.Add(Me.fromLabel)
        Me.SplitContainer1.Panel2.Controls.Add(Me.fromContactControl)
        Me.SplitContainer1.Size = New System.Drawing.Size(713, 572)
        Me.SplitContainer1.SplitterDistance = 282
        Me.SplitContainer1.SplitterWidth = 6
        Me.SplitContainer1.TabIndex = 8
        '
        'toInstructionsLabel
        '
        Me.toInstructionsLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.toInstructionsLabel.ForeColor = System.Drawing.Color.DimGray
        Me.toInstructionsLabel.Location = New System.Drawing.Point(74, 9)
        Me.toInstructionsLabel.Name = "toInstructionsLabel"
        Me.toInstructionsLabel.Size = New System.Drawing.Size(629, 24)
        Me.toInstructionsLabel.TabIndex = 7
        Me.toInstructionsLabel.Text = "Click the contact the report is addressed to."
        Me.toInstructionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'toContactControl
        '
        Me.toContactControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.toContactControl.BackColor = System.Drawing.Color.White
        Me.toContactControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.toContactControl.CanEdit = True
        Me.toContactControl.ContactLimit = 999
        Me.toContactControl.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toContactControl.Location = New System.Drawing.Point(12, 37)
        Me.toContactControl.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.toContactControl.Name = "toContactControl"
        Me.toContactControl.SelectedContactControl = Nothing
        Me.toContactControl.Size = New System.Drawing.Size(689, 233)
        Me.toContactControl.TabIndex = 6
        '
        'fromInstructionsLabel
        '
        Me.fromInstructionsLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fromInstructionsLabel.ForeColor = System.Drawing.Color.DimGray
        Me.fromInstructionsLabel.Location = New System.Drawing.Point(74, 10)
        Me.fromInstructionsLabel.Name = "fromInstructionsLabel"
        Me.fromInstructionsLabel.Size = New System.Drawing.Size(629, 24)
        Me.fromInstructionsLabel.TabIndex = 8
        Me.fromInstructionsLabel.Text = "Click the contact the report is from."
        Me.fromInstructionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fromContactControl
        '
        Me.fromContactControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fromContactControl.BackColor = System.Drawing.Color.White
        Me.fromContactControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fromContactControl.CanEdit = True
        Me.fromContactControl.ContactLimit = 999
        Me.fromContactControl.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fromContactControl.Location = New System.Drawing.Point(12, 38)
        Me.fromContactControl.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.fromContactControl.Name = "fromContactControl"
        Me.fromContactControl.SelectedContactControl = Nothing
        Me.fromContactControl.Size = New System.Drawing.Size(689, 233)
        Me.fromContactControl.TabIndex = 7
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtEngineer)
        Me.Panel1.Controls.Add(Me.txtSalesperson)
        Me.Panel1.Controls.Add(Me.cancelButton2)
        Me.Panel1.Controls.Add(Me.okButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 572)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(713, 54)
        Me.Panel1.TabIndex = 9
        '
        'cancelButton2
        '
        Me.cancelButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cancelButton2.ForeColor = System.Drawing.Color.Gray
        Me.cancelButton2.Location = New System.Drawing.Point(603, 13)
        Me.cancelButton2.Name = "cancelButton2"
        Me.cancelButton2.Size = New System.Drawing.Size(100, 28)
        Me.cancelButton2.TabIndex = 1
        Me.cancelButton2.Text = "Cancel"
        Me.cancelButton2.UseVisualStyleBackColor = True
        '
        'okButton
        '
        Me.okButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.okButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.okButton.Location = New System.Drawing.Point(497, 13)
        Me.okButton.Name = "okButton"
        Me.okButton.Size = New System.Drawing.Size(100, 28)
        Me.okButton.TabIndex = 0
        Me.okButton.Text = "View Report"
        Me.okButton.UseVisualStyleBackColor = True
        '
        'txtSalesperson
        '
        Me.txtSalesperson.Location = New System.Drawing.Point(99, 16)
        Me.txtSalesperson.Name = "txtSalesperson"
        Me.txtSalesperson.Size = New System.Drawing.Size(129, 23)
        Me.txtSalesperson.TabIndex = 2
        '
        'txtEngineer
        '
        Me.txtEngineer.Location = New System.Drawing.Point(317, 16)
        Me.txtEngineer.Name = "txtEngineer"
        Me.txtEngineer.Size = New System.Drawing.Size(129, 23)
        Me.txtEngineer.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Salesperson"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(253, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Engineer"
        '
        'SelectContactForReportForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(713, 626)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "SelectContactForReportForm"
        Me.Text = "Select Contact for Report"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
   Friend WithEvents fromContactControl As Rae.RaeSolutions.ContactManagerControl
   Friend WithEvents toContactControl As Rae.RaeSolutions.ContactManagerControl
   Friend WithEvents fromLabel As System.Windows.Forms.Label
   Friend WithEvents toLabel As System.Windows.Forms.Label
   Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
   Friend WithEvents toInstructionsLabel As System.Windows.Forms.Label
   Friend WithEvents fromInstructionsLabel As System.Windows.Forms.Label
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents cancelButton2 As System.Windows.Forms.Button
    Friend WithEvents okButton As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEngineer As System.Windows.Forms.TextBox
    Friend WithEvents txtSalesperson As System.Windows.Forms.TextBox
End Class
