Namespace Updating.ContactDataStructure

   <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
   Partial Class WizardFormBase
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
         Me.headerPanel = New System.Windows.Forms.Panel
            ''Me.GradientPanel1 = New Rae.Ui.Controls.GradientPanel
            ''Me.GradientPanel2 = New Rae.Ui.Controls.GradientPanel
            Me.headerLabel = New System.Windows.Forms.Label
         Me.footerPanel = New System.Windows.Forms.Panel
         Me.continueButton = New System.Windows.Forms.Button
         Me.cancelButton2 = New System.Windows.Forms.Button
            ''Me.GradientPanel3 = New Rae.Ui.Controls.GradientPanel
            ''Me.GradientPanel4 = New Rae.Ui.Controls.GradientPanel
            Me.headerPanel.SuspendLayout()
         Me.footerPanel.SuspendLayout()
         Me.SuspendLayout()
         '
         'headerPanel
         '
         Me.headerPanel.BackColor = System.Drawing.Color.Transparent
            ''Me.headerPanel.Controls.Add(Me.GradientPanel1)
            ''Me.headerPanel.Controls.Add(Me.GradientPanel2)
            Me.headerPanel.Controls.Add(Me.headerLabel)
         Me.headerPanel.Dock = System.Windows.Forms.DockStyle.Top
         Me.headerPanel.Location = New System.Drawing.Point(0, 0)
         Me.headerPanel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
         Me.headerPanel.Name = "headerPanel"
         Me.headerPanel.Size = New System.Drawing.Size(666, 72)
         Me.headerPanel.TabIndex = 2
            '''
            '''GradientPanel1
            '''
            ''Me.GradientPanel1.BorderColor = System.Drawing.Color.Empty
            ''Me.GradientPanel1.BorderWidth = 0
            ''Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
            ''Me.GradientPanel1.Flip = False
            ''Me.GradientPanel1.GradientAngle = 90
            ''Me.GradientPanel1.GradientEndColor = System.Drawing.Color.White
            ''Me.GradientPanel1.GradientStartColor = System.Drawing.Color.Lavender
            ''Me.GradientPanel1.HorizontalFillPercent = 100.0!
            ''Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
            ''Me.GradientPanel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            ''Me.GradientPanel1.Name = "GradientPanel1"
            ''Me.GradientPanel1.Size = New System.Drawing.Size(666, 21)
            ''Me.GradientPanel1.TabIndex = 0
            ''Me.GradientPanel1.VerticalFillPercent = 100.0!
            '''
            '''GradientPanel2
            '''
            ''Me.GradientPanel2.BorderColor = System.Drawing.Color.Empty
            ''Me.GradientPanel2.BorderWidth = 0
            ''Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
            ''Me.GradientPanel2.Flip = False
            ''Me.GradientPanel2.GradientAngle = 90
            ''Me.GradientPanel2.GradientEndColor = System.Drawing.Color.Lavender
            ''Me.GradientPanel2.GradientStartColor = System.Drawing.Color.White
            ''Me.GradientPanel2.HorizontalFillPercent = 100.0!
            ''Me.GradientPanel2.Location = New System.Drawing.Point(0, 51)
            ''Me.GradientPanel2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            ''Me.GradientPanel2.Name = "GradientPanel2"
            ''Me.GradientPanel2.Size = New System.Drawing.Size(666, 21)
            ''Me.GradientPanel2.TabIndex = 1
            ''Me.GradientPanel2.VerticalFillPercent = 100.0!
            '
            'headerLabel
            '
            Me.headerLabel.AutoSize = True
         Me.headerLabel.Font = New System.Drawing.Font("Trebuchet MS", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.headerLabel.ForeColor = System.Drawing.Color.CornflowerBlue
         Me.headerLabel.Location = New System.Drawing.Point(14, 20)
         Me.headerLabel.Name = "headerLabel"
         Me.headerLabel.Size = New System.Drawing.Size(263, 29)
         Me.headerLabel.TabIndex = 2
         Me.headerLabel.Text = "Contact Update Wizard"
         '
         'footerPanel
         '
         Me.footerPanel.BackColor = System.Drawing.Color.Transparent
         Me.footerPanel.Controls.Add(Me.continueButton)
         Me.footerPanel.Controls.Add(Me.cancelButton2)
            ''Me.footerPanel.Controls.Add(Me.GradientPanel3)
            ''Me.footerPanel.Controls.Add(Me.GradientPanel4)
            Me.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom
         Me.footerPanel.Location = New System.Drawing.Point(0, 347)
         Me.footerPanel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
         Me.footerPanel.Name = "footerPanel"
         Me.footerPanel.Size = New System.Drawing.Size(666, 66)
         Me.footerPanel.TabIndex = 3
         '
         'continueButton
         '
         Me.continueButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.continueButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.continueButton.ForeColor = System.Drawing.Color.Black
         Me.continueButton.Location = New System.Drawing.Point(478, 17)
         Me.continueButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
         Me.continueButton.Name = "continueButton"
         Me.continueButton.Size = New System.Drawing.Size(86, 30)
         Me.continueButton.TabIndex = 1
         Me.continueButton.Text = "Continue"
         Me.continueButton.UseVisualStyleBackColor = True
         '
         'cancelButton2
         '
         Me.cancelButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.cancelButton2.ForeColor = System.Drawing.Color.SteelBlue
         Me.cancelButton2.Location = New System.Drawing.Point(570, 17)
         Me.cancelButton2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
         Me.cancelButton2.Name = "cancelButton2"
         Me.cancelButton2.Size = New System.Drawing.Size(81, 30)
         Me.cancelButton2.TabIndex = 2
         Me.cancelButton2.Text = "Cancel"
         Me.cancelButton2.UseVisualStyleBackColor = True
            '''
            '''GradientPanel3
            '''
            ''Me.GradientPanel3.BorderColor = System.Drawing.Color.Empty
            ''Me.GradientPanel3.BorderWidth = 0
            ''Me.GradientPanel3.Dock = System.Windows.Forms.DockStyle.Top
            ''Me.GradientPanel3.Flip = False
            ''Me.GradientPanel3.GradientAngle = 90
            ''Me.GradientPanel3.GradientEndColor = System.Drawing.Color.White
            ''Me.GradientPanel3.GradientStartColor = System.Drawing.Color.Lavender
            ''Me.GradientPanel3.HorizontalFillPercent = 100.0!
            ''Me.GradientPanel3.Location = New System.Drawing.Point(0, 0)
            ''Me.GradientPanel3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            ''Me.GradientPanel3.Name = "GradientPanel3"
            ''Me.GradientPanel3.Size = New System.Drawing.Size(666, 21)
            ''Me.GradientPanel3.TabIndex = 0
            ''Me.GradientPanel3.VerticalFillPercent = 100.0!
            '''
            '''GradientPanel4
            '''
            ''Me.GradientPanel4.BorderColor = System.Drawing.Color.Empty
            ''Me.GradientPanel4.BorderWidth = 0
            ''Me.GradientPanel4.Dock = System.Windows.Forms.DockStyle.Bottom
            ''Me.GradientPanel4.Flip = False
            ''Me.GradientPanel4.GradientAngle = 90
            ''Me.GradientPanel4.GradientEndColor = System.Drawing.Color.Lavender
            ''Me.GradientPanel4.GradientStartColor = System.Drawing.Color.White
            ''Me.GradientPanel4.HorizontalFillPercent = 100.0!
            ''Me.GradientPanel4.Location = New System.Drawing.Point(0, 45)
            ''Me.GradientPanel4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            ''Me.GradientPanel4.Name = "GradientPanel4"
            ''Me.GradientPanel4.Size = New System.Drawing.Size(666, 21)
            ''Me.GradientPanel4.TabIndex = 1
            ''Me.GradientPanel4.VerticalFillPercent = 100.0!
            '
            'WizardFormBase
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.BackColor = System.Drawing.Color.White
         Me.ClientSize = New System.Drawing.Size(666, 413)
         Me.Controls.Add(Me.footerPanel)
         Me.Controls.Add(Me.headerPanel)
         Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
         Me.Name = "WizardFormBase"
         Me.Text = "RAESolutions - Contact Update Wizard"
         Me.headerPanel.ResumeLayout(False)
         Me.headerPanel.PerformLayout()
         Me.footerPanel.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub
        ''Friend WithEvents GradientPanel1 As Rae.Ui.Controls.GradientPanel
        ''Friend WithEvents GradientPanel2 As Rae.Ui.Controls.GradientPanel
        Friend WithEvents headerPanel As System.Windows.Forms.Panel
      Friend WithEvents headerLabel As System.Windows.Forms.Label
      Friend WithEvents footerPanel As System.Windows.Forms.Panel
        ''Friend WithEvents GradientPanel3 As Rae.Ui.Controls.GradientPanel
        ''Friend WithEvents GradientPanel4 As Rae.Ui.Controls.GradientPanel
        Public WithEvents cancelButton2 As System.Windows.Forms.Button
      Public WithEvents continueButton As System.Windows.Forms.Button
   End Class

End Namespace