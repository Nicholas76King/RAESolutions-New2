<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AirHandlerSection
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Me.Panel1 = New System.Windows.Forms.Panel
      Me.Label1 = New System.Windows.Forms.Label
      Me.Panel2 = New System.Windows.Forms.Panel
      Me.Panel3 = New System.Windows.Forms.Panel
      Me.Button2 = New System.Windows.Forms.Button
      Me.Button1 = New System.Windows.Forms.Button
      Me.Label3 = New System.Windows.Forms.Label
      Me.Label2 = New System.Windows.Forms.Label
      Me.Label4 = New System.Windows.Forms.Label
      Me.Label5 = New System.Windows.Forms.Label
      Me.Label6 = New System.Windows.Forms.Label
      Me.Label7 = New System.Windows.Forms.Label
      Me.commonPanel = New System.Windows.Forms.Panel
      Me.Panel1.SuspendLayout()
      Me.Panel2.SuspendLayout()
      Me.Panel3.SuspendLayout()
      Me.commonPanel.SuspendLayout()
      Me.SuspendLayout()
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.Label1)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 0)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(274, 32)
      Me.Panel1.TabIndex = 0
      '
      'Label1
      '
      Me.Label1.AutoEllipsis = True
      Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
      Me.Label1.Location = New System.Drawing.Point(0, 0)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(274, 32)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Air Handler Section Header"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'Panel2
      '
      Me.Panel2.BackColor = System.Drawing.Color.White
      Me.Panel2.Controls.Add(Me.commonPanel)
      Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Panel2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Panel2.ForeColor = System.Drawing.Color.DimGray
      Me.Panel2.Location = New System.Drawing.Point(0, 32)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(274, 100)
      Me.Panel2.TabIndex = 1
      '
      'Panel3
      '
      Me.Panel3.Controls.Add(Me.Button2)
      Me.Panel3.Controls.Add(Me.Button1)
      Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.Panel3.Location = New System.Drawing.Point(0, 132)
      Me.Panel3.Name = "Panel3"
      Me.Panel3.Size = New System.Drawing.Size(274, 40)
      Me.Panel3.TabIndex = 2
      '
      'Button2
      '
      Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Button2.Location = New System.Drawing.Point(109, 7)
      Me.Button2.Name = "Button2"
      Me.Button2.Size = New System.Drawing.Size(75, 26)
      Me.Button2.TabIndex = 1
      Me.Button2.Text = "Save"
      Me.Button2.UseVisualStyleBackColor = True
      '
      'Button1
      '
      Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Button1.Location = New System.Drawing.Point(190, 7)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(75, 26)
      Me.Button1.TabIndex = 0
      Me.Button1.Text = "Cancel"
      Me.Button1.UseVisualStyleBackColor = True
      '
      'Label3
      '
      Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label3.ForeColor = System.Drawing.Color.Blue
      Me.Label3.Location = New System.Drawing.Point(105, 49)
      Me.Label3.Margin = New System.Windows.Forms.Padding(3, 1, 3, 1)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(167, 21)
      Me.Label3.TabIndex = 9
      Me.Label3.Text = "$0000.00"
      Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label2
      '
      Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label2.ForeColor = System.Drawing.Color.Blue
      Me.Label2.Location = New System.Drawing.Point(15, 49)
      Me.Label2.Margin = New System.Windows.Forms.Padding(3, 1, 3, 1)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(84, 21)
      Me.Label2.TabIndex = 8
      Me.Label2.Text = "Cost"
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label4
      '
      Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label4.ForeColor = System.Drawing.Color.DimGray
      Me.Label4.Location = New System.Drawing.Point(15, 26)
      Me.Label4.Margin = New System.Windows.Forms.Padding(3, 1, 3, 1)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(84, 21)
      Me.Label4.TabIndex = 10
      Me.Label4.Text = "Completion"
      Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label5
      '
      Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label5.ForeColor = System.Drawing.Color.Red
      Me.Label5.Location = New System.Drawing.Point(105, 26)
      Me.Label5.Margin = New System.Windows.Forms.Padding(3, 1, 3, 1)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(167, 21)
      Me.Label5.TabIndex = 11
      Me.Label5.Text = "Incomplete"
      Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label6
      '
      Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label6.ForeColor = System.Drawing.Color.Red
      Me.Label6.Location = New System.Drawing.Point(105, 3)
      Me.Label6.Margin = New System.Windows.Forms.Padding(3, 1, 3, 1)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(167, 21)
      Me.Label6.TabIndex = 13
      Me.Label6.Text = "Invalid"
      Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label7
      '
      Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label7.ForeColor = System.Drawing.Color.DimGray
      Me.Label7.Location = New System.Drawing.Point(15, 3)
      Me.Label7.Margin = New System.Windows.Forms.Padding(3, 1, 3, 1)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(84, 21)
      Me.Label7.TabIndex = 12
      Me.Label7.Text = "Validity"
      Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'commonPanel
      '
      Me.commonPanel.BackColor = System.Drawing.Color.AliceBlue
      Me.commonPanel.Controls.Add(Me.Label2)
      Me.commonPanel.Controls.Add(Me.Label6)
      Me.commonPanel.Controls.Add(Me.Label3)
      Me.commonPanel.Controls.Add(Me.Label7)
      Me.commonPanel.Controls.Add(Me.Label4)
      Me.commonPanel.Controls.Add(Me.Label5)
      Me.commonPanel.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.commonPanel.Location = New System.Drawing.Point(0, 21)
      Me.commonPanel.Name = "commonPanel"
      Me.commonPanel.Size = New System.Drawing.Size(274, 79)
      Me.commonPanel.TabIndex = 14
      '
      'AirHandlerSection
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.White
      Me.Controls.Add(Me.Panel2)
      Me.Controls.Add(Me.Panel3)
      Me.Controls.Add(Me.Panel1)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Name = "AirHandlerSection"
      Me.Size = New System.Drawing.Size(274, 172)
      Me.Panel1.ResumeLayout(False)
      Me.Panel2.ResumeLayout(False)
      Me.Panel3.ResumeLayout(False)
      Me.commonPanel.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents Panel3 As System.Windows.Forms.Panel
   Friend WithEvents Button2 As System.Windows.Forms.Button
   Friend WithEvents Button1 As System.Windows.Forms.Button
   Protected Friend WithEvents Label1 As System.Windows.Forms.Label
   Protected Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents commonPanel As System.Windows.Forms.Panel

End Class
