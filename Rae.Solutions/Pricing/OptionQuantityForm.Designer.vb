<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionQuantityForm
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
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
      Me.okButton_ = New System.Windows.Forms.Button
      Me.instructionsLabel = New System.Windows.Forms.Label
      Me.Panel1 = New System.Windows.Forms.Panel
      Me.quantityText = New Infragistics.Win.UltraWinEditors.UltraTextEditor
      Me.descriptionLabel = New System.Windows.Forms.Label
      Me.quantityLabel = New System.Windows.Forms.Label
      Me.Panel1.SuspendLayout()
      CType(Me.quantityText, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'okButton_
      '
      Me.okButton_.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.okButton_.Location = New System.Drawing.Point(0, 133)
      Me.okButton_.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
      Me.okButton_.Name = "okButton_"
      Me.okButton_.Size = New System.Drawing.Size(451, 41)
      Me.okButton_.TabIndex = 2
      Me.okButton_.Text = "OK"
      Me.okButton_.UseVisualStyleBackColor = True
      '
      'instructionsLabel
      '
      Me.instructionsLabel.AutoSize = True
      Me.instructionsLabel.ForeColor = System.Drawing.Color.Black
      Me.instructionsLabel.Location = New System.Drawing.Point(9, 9)
      Me.instructionsLabel.Name = "instructionsLabel"
      Me.instructionsLabel.Size = New System.Drawing.Size(216, 19)
      Me.instructionsLabel.TabIndex = 1
      Me.instructionsLabel.Text = "Please enter an option quantity."
      '
      'Panel1
      '
      Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Panel1.BackColor = System.Drawing.Color.White
      Me.Panel1.Controls.Add(Me.quantityLabel)
      Me.Panel1.Controls.Add(Me.descriptionLabel)
      Me.Panel1.Controls.Add(Me.quantityText)
      Me.Panel1.Controls.Add(Me.instructionsLabel)
      Me.Panel1.Controls.Add(Me.okButton_)
      Me.Panel1.Location = New System.Drawing.Point(4, 4)
      Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(451, 174)
      Me.Panel1.TabIndex = 3
      '
      'quantityText
      '
      Appearance3.BorderColor = System.Drawing.Color.Orange
      Me.quantityText.Appearance = Appearance3
      Me.quantityText.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.quantityText.Location = New System.Drawing.Point(229, 81)
      Me.quantityText.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
      Me.quantityText.Name = "quantityText"
      Me.quantityText.Size = New System.Drawing.Size(50, 27)
      Me.quantityText.TabIndex = 1
      Me.quantityText.Text = "0"
      Me.quantityText.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI
      Me.quantityText.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
      '
      'descriptionLabel
      '
      Me.descriptionLabel.AutoSize = True
      Me.descriptionLabel.ForeColor = System.Drawing.Color.DimGray
      Me.descriptionLabel.Location = New System.Drawing.Point(9, 34)
      Me.descriptionLabel.Name = "descriptionLabel"
      Me.descriptionLabel.Size = New System.Drawing.Size(116, 19)
      Me.descriptionLabel.TabIndex = 3
      Me.descriptionLabel.Text = "MV01 Oil Gauge"
      '
      'quantityLabel
      '
      Me.quantityLabel.AutoSize = True
      Me.quantityLabel.Location = New System.Drawing.Point(158, 85)
      Me.quantityLabel.Name = "quantityLabel"
      Me.quantityLabel.Size = New System.Drawing.Size(65, 19)
      Me.quantityLabel.TabIndex = 4
      Me.quantityLabel.Text = "Quantity"
      '
      'OptionQuantityForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.LightSteelBlue
      Me.ClientSize = New System.Drawing.Size(460, 183)
      Me.Controls.Add(Me.Panel1)
      Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
      Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
      Me.Name = "OptionQuantityForm"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      CType(Me.quantityText, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
    Friend WithEvents okButton_ As System.Windows.Forms.Button
    Friend WithEvents instructionsLabel As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents quantityText As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents quantityLabel As System.Windows.Forms.Label
    Friend WithEvents descriptionLabel As System.Windows.Forms.Label
End Class
