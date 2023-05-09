Namespace Rae.Presentation.SpecialOptions

   <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
   Partial Class SpecialOptionsForm
      Inherits System.Windows.Forms.Form

      'Form overrides dispose to clean up the component list.
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
         Me.TabControl1 = New System.Windows.Forms.TabControl
         Me.tabCreate = New System.Windows.Forms.TabPage
         Me.SpecialOptionCreator1 = New RAE.Presentation.SpecialOptions.SpecialOptionCreator
         Me.tabVerify = New System.Windows.Forms.TabPage
         Me.tabView = New System.Windows.Forms.TabPage
         Me.SpecialOptionsView1 = New RAE.Presentation.SpecialOptions.SpecialOptionsView
         Me.btnOk = New System.Windows.Forms.Button
         Me.SpecialOptionVerifier1 = New RAE.Presentation.SpecialOptions.SpecialOptionVerifier
         Me.TabControl1.SuspendLayout()
         Me.tabCreate.SuspendLayout()
         Me.tabVerify.SuspendLayout()
         Me.tabView.SuspendLayout()
         Me.SuspendLayout()
         '
         'TabControl1
         '
         Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                     Or System.Windows.Forms.AnchorStyles.Left) _
                     Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.TabControl1.Controls.Add(Me.tabCreate)
         Me.TabControl1.Controls.Add(Me.tabVerify)
         Me.TabControl1.Controls.Add(Me.tabView)
         Me.TabControl1.Location = New System.Drawing.Point(13, 13)
         Me.TabControl1.Name = "TabControl1"
         Me.TabControl1.SelectedIndex = 0
         Me.TabControl1.Size = New System.Drawing.Size(360, 285)
         Me.TabControl1.TabIndex = 2
         '
         'tabCreate
         '
         Me.tabCreate.Controls.Add(Me.SpecialOptionCreator1)
         Me.tabCreate.Location = New System.Drawing.Point(4, 22)
         Me.tabCreate.Name = "tabCreate"
         Me.tabCreate.Padding = New System.Windows.Forms.Padding(3)
         Me.tabCreate.Size = New System.Drawing.Size(352, 259)
         Me.tabCreate.TabIndex = 0
         Me.tabCreate.Text = "Create"
         Me.tabCreate.UseVisualStyleBackColor = True
         '
         'SpecialOptionCreator1
         '
         Me.SpecialOptionCreator1.BackColor = System.Drawing.Color.White
         Me.SpecialOptionCreator1.Dock = System.Windows.Forms.DockStyle.Fill
         Me.SpecialOptionCreator1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.SpecialOptionCreator1.Location = New System.Drawing.Point(3, 3)
         Me.SpecialOptionCreator1.Name = "SpecialOptionCreator1"
         Me.SpecialOptionCreator1.Padding = New System.Windows.Forms.Padding(6)
         Me.SpecialOptionCreator1.Size = New System.Drawing.Size(346, 253)
         Me.SpecialOptionCreator1.TabIndex = 0
         '
         'tabVerify
         '
         Me.tabVerify.Controls.Add(Me.SpecialOptionVerifier1)
         Me.tabVerify.Location = New System.Drawing.Point(4, 22)
         Me.tabVerify.Name = "tabVerify"
         Me.tabVerify.Padding = New System.Windows.Forms.Padding(3)
         Me.tabVerify.Size = New System.Drawing.Size(352, 259)
         Me.tabVerify.TabIndex = 1
         Me.tabVerify.Text = "Verify"
         Me.tabVerify.UseVisualStyleBackColor = True
         '
         'tabView
         '
         Me.tabView.Controls.Add(Me.SpecialOptionsView1)
         Me.tabView.Location = New System.Drawing.Point(4, 22)
         Me.tabView.Name = "tabView"
         Me.tabView.Size = New System.Drawing.Size(352, 259)
         Me.tabView.TabIndex = 2
         Me.tabView.Text = "View"
         Me.tabView.UseVisualStyleBackColor = True
         '
         'SpecialOptionsView1
         '
         Me.SpecialOptionsView1.BackColor = System.Drawing.Color.White
         Me.SpecialOptionsView1.Dock = System.Windows.Forms.DockStyle.Fill
         Me.SpecialOptionsView1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.SpecialOptionsView1.Location = New System.Drawing.Point(0, 0)
         Me.SpecialOptionsView1.Name = "SpecialOptionsView1"
         Me.SpecialOptionsView1.Padding = New System.Windows.Forms.Padding(6)
         Me.SpecialOptionsView1.Size = New System.Drawing.Size(352, 259)
         Me.SpecialOptionsView1.TabIndex = 0
         '
         'btnOk
         '
         Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.btnOk.Location = New System.Drawing.Point(297, 303)
         Me.btnOk.Name = "btnOk"
         Me.btnOk.Size = New System.Drawing.Size(75, 25)
         Me.btnOk.TabIndex = 3
         Me.btnOk.Text = "OK"
         Me.btnOk.UseVisualStyleBackColor = True
         '
         'SpecialOptionVerifier1
         '
         Me.SpecialOptionVerifier1.BackColor = System.Drawing.Color.White
         Me.SpecialOptionVerifier1.Dock = System.Windows.Forms.DockStyle.Fill
         Me.SpecialOptionVerifier1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.SpecialOptionVerifier1.Location = New System.Drawing.Point(3, 3)
         Me.SpecialOptionVerifier1.Name = "SpecialOptionVerifier1"
         Me.SpecialOptionVerifier1.Padding = New System.Windows.Forms.Padding(6)
         Me.SpecialOptionVerifier1.Size = New System.Drawing.Size(346, 253)
         Me.SpecialOptionVerifier1.TabIndex = 0
         '
         'SpecialOptionsForm
         '
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.BackColor = System.Drawing.Color.White
         Me.ClientSize = New System.Drawing.Size(386, 337)
         Me.Controls.Add(Me.btnOk)
         Me.Controls.Add(Me.TabControl1)
         Me.Name = "SpecialOptionsForm"
         Me.Text = "Special Options"
         Me.TabControl1.ResumeLayout(False)
         Me.tabCreate.ResumeLayout(False)
         Me.tabVerify.ResumeLayout(False)
         Me.tabView.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub
      Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
      Friend WithEvents tabCreate As System.Windows.Forms.TabPage
      Friend WithEvents tabVerify As System.Windows.Forms.TabPage
      Friend WithEvents tabView As System.Windows.Forms.TabPage
      Friend WithEvents btnOk As System.Windows.Forms.Button
      Friend WithEvents SpecialOptionsView1 As RAE.Presentation.SpecialOptions.SpecialOptionsView
      Friend WithEvents SpecialOptionCreator1 As RAE.Presentation.SpecialOptions.SpecialOptionCreator
      Friend WithEvents SpecialOptionVerifier1 As RAE.Presentation.SpecialOptions.SpecialOptionVerifier
   End Class

End Namespace