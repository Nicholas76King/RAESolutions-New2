<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Print
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
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.chkOrderWriteUp = New System.Windows.Forms.CheckBox()
        Me.chkSubmittal = New System.Windows.Forms.CheckBox()
        Me.chkDrawing = New System.Windows.Forms.CheckBox()
        Me.chkUnitRating = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkOrderSubmittal = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(16, 196)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(609, 59)
        Me.btnPrint.TabIndex = 1
        Me.btnPrint.Text = "Print Selected"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'chkOrderWriteUp
        '
        Me.chkOrderWriteUp.AutoSize = True
        Me.chkOrderWriteUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOrderWriteUp.Location = New System.Drawing.Point(16, 48)
        Me.chkOrderWriteUp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkOrderWriteUp.Name = "chkOrderWriteUp"
        Me.chkOrderWriteUp.Size = New System.Drawing.Size(167, 29)
        Me.chkOrderWriteUp.TabIndex = 2
        Me.chkOrderWriteUp.Text = "Order Write-Up"
        Me.chkOrderWriteUp.UseVisualStyleBackColor = True
        '
        'chkSubmittal
        '
        Me.chkSubmittal.AutoSize = True
        Me.chkSubmittal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSubmittal.Location = New System.Drawing.Point(20, 90)
        Me.chkSubmittal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkSubmittal.Name = "chkSubmittal"
        Me.chkSubmittal.Size = New System.Drawing.Size(115, 29)
        Me.chkSubmittal.TabIndex = 3
        Me.chkSubmittal.Text = "Submittal"
        Me.chkSubmittal.UseVisualStyleBackColor = True
        '
        'chkDrawing
        '
        Me.chkDrawing.AutoSize = True
        Me.chkDrawing.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDrawing.Location = New System.Drawing.Point(16, 122)
        Me.chkDrawing.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkDrawing.Name = "chkDrawing"
        Me.chkDrawing.Size = New System.Drawing.Size(105, 29)
        Me.chkDrawing.TabIndex = 4
        Me.chkDrawing.Text = "Drawing"
        Me.chkDrawing.UseVisualStyleBackColor = True
        '
        'chkUnitRating
        '
        Me.chkUnitRating.AutoSize = True
        Me.chkUnitRating.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkUnitRating.Location = New System.Drawing.Point(16, 159)
        Me.chkUnitRating.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkUnitRating.Name = "chkUnitRating"
        Me.chkUnitRating.Size = New System.Drawing.Size(176, 29)
        Me.chkUnitRating.TabIndex = 5
        Me.chkUnitRating.Text = "Rating / Balance"
        Me.chkUnitRating.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(574, 36)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Choose the reports you would like to print."
        '
        'chkOrderSubmittal
        '
        Me.chkOrderSubmittal.AutoSize = True
        Me.chkOrderSubmittal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOrderSubmittal.Location = New System.Drawing.Point(16, 85)
        Me.chkOrderSubmittal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkOrderSubmittal.Name = "chkOrderSubmittal"
        Me.chkOrderSubmittal.Size = New System.Drawing.Size(115, 29)
        Me.chkOrderSubmittal.TabIndex = 3
        Me.chkOrderSubmittal.Text = "Submittal"
        Me.chkOrderSubmittal.UseVisualStyleBackColor = True
        '
        'Print
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(641, 272)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkUnitRating)
        Me.Controls.Add(Me.chkDrawing)
        Me.Controls.Add(Me.chkOrderSubmittal)
        Me.Controls.Add(Me.chkSubmittal)
        Me.Controls.Add(Me.chkOrderWriteUp)
        Me.Controls.Add(Me.btnPrint)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Print"
        Me.Text = "Print"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents chkOrderWriteUp As System.Windows.Forms.CheckBox
    Friend WithEvents chkSubmittal As System.Windows.Forms.CheckBox
    Friend WithEvents chkDrawing As System.Windows.Forms.CheckBox
    Friend WithEvents chkUnitRating As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkOrderSubmittal As System.Windows.Forms.CheckBox
End Class
