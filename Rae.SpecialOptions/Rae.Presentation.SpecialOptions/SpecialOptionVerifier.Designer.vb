Namespace Rae.Presentation.SpecialOptions

   <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
   Partial Class SpecialOptionVerifier
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
         Me.components = New System.ComponentModel.Container
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SpecialOptionVerifier))
         Me.lblTitle = New System.Windows.Forms.Label
         Me.txtCode = New System.Windows.Forms.TextBox
         Me.lblCode = New System.Windows.Forms.Label
         Me.txtPrice = New System.Windows.Forms.TextBox
         Me.Label1 = New System.Windows.Forms.Label
         Me.btnOk = New System.Windows.Forms.Button
         Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
         Me.lblMessage = New System.Windows.Forms.Label
         Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
         CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         '
         'lblTitle
         '
         Me.lblTitle.BackColor = System.Drawing.Color.LightSteelBlue
         Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
         Me.lblTitle.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.lblTitle.ForeColor = System.Drawing.Color.White
         Me.lblTitle.Location = New System.Drawing.Point(6, 6)
         Me.lblTitle.Name = "lblTitle"
         Me.lblTitle.Size = New System.Drawing.Size(327, 28)
         Me.lblTitle.TabIndex = 1
         Me.lblTitle.Text = "Verify a special option"
         Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         'txtCode
         '
         Me.txtCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                     Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.txtCode.Location = New System.Drawing.Point(108, 43)
         Me.txtCode.Name = "txtCode"
         Me.txtCode.Size = New System.Drawing.Size(214, 21)
         Me.txtCode.TabIndex = 1
         Me.txtCode.Tag = "Description"
         '
         'lblCode
         '
         Me.lblCode.Location = New System.Drawing.Point(12, 43)
         Me.lblCode.Margin = New System.Windows.Forms.Padding(3)
         Me.lblCode.Name = "lblCode"
         Me.lblCode.Size = New System.Drawing.Size(90, 21)
         Me.lblCode.TabIndex = 7
         Me.lblCode.Text = "Code"
         Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         'txtPrice
         '
         Me.txtPrice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                     Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.txtPrice.Location = New System.Drawing.Point(108, 70)
         Me.txtPrice.Name = "txtPrice"
         Me.txtPrice.Size = New System.Drawing.Size(214, 21)
         Me.txtPrice.TabIndex = 5
         Me.txtPrice.Tag = "Description"
         '
         'Label1
         '
         Me.Label1.Location = New System.Drawing.Point(12, 70)
         Me.Label1.Margin = New System.Windows.Forms.Padding(3)
         Me.Label1.Name = "Label1"
         Me.Label1.Size = New System.Drawing.Size(90, 21)
         Me.Label1.TabIndex = 9
         Me.Label1.Text = "Price"
         Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         'btnOk
         '
         Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
         Me.btnOk.Location = New System.Drawing.Point(247, 97)
         Me.btnOk.Name = "btnOk"
         Me.btnOk.Size = New System.Drawing.Size(75, 26)
         Me.btnOk.TabIndex = 10
         Me.btnOk.Text = "Verify"
         Me.btnOk.UseVisualStyleBackColor = True
         '
         'ImageList1
         '
         Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
         Me.ImageList1.TransparentColor = System.Drawing.Color.Fuchsia
         Me.ImageList1.Images.SetKeyName(0, "OK.bmp")
         Me.ImageList1.Images.SetKeyName(1, "Warning.bmp")
         '
         'lblMessage
         '
         Me.lblMessage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                     Or System.Windows.Forms.AnchorStyles.Left) _
                     Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.lblMessage.BackColor = System.Drawing.SystemColors.Control
         Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me.lblMessage.ImageAlign = System.Drawing.ContentAlignment.TopRight
         Me.lblMessage.Location = New System.Drawing.Point(15, 129)
         Me.lblMessage.Margin = New System.Windows.Forms.Padding(3)
         Me.lblMessage.Name = "lblMessage"
         Me.lblMessage.Size = New System.Drawing.Size(307, 64)
         Me.lblMessage.TabIndex = 13
         Me.lblMessage.Text = "Click 'Verify'"
         '
         'ErrorProvider1
         '
         Me.ErrorProvider1.ContainerControl = Me
         Me.ErrorProvider1.Icon = CType(resources.GetObject("ErrorProvider1.Icon"), System.Drawing.Icon)
         '
         'SpecialOptionVerifier
         '
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.BackColor = System.Drawing.Color.White
         Me.Controls.Add(Me.lblMessage)
         Me.Controls.Add(Me.btnOk)
         Me.Controls.Add(Me.txtPrice)
         Me.Controls.Add(Me.Label1)
         Me.Controls.Add(Me.txtCode)
         Me.Controls.Add(Me.lblCode)
         Me.Controls.Add(Me.lblTitle)
         Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.Name = "SpecialOptionVerifier"
         Me.Padding = New System.Windows.Forms.Padding(6)
         Me.Size = New System.Drawing.Size(339, 204)
         CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub
      Friend WithEvents lblTitle As System.Windows.Forms.Label
      Friend WithEvents txtCode As System.Windows.Forms.TextBox
      Friend WithEvents lblCode As System.Windows.Forms.Label
      Friend WithEvents txtPrice As System.Windows.Forms.TextBox
      Friend WithEvents Label1 As System.Windows.Forms.Label
      Friend WithEvents btnOk As System.Windows.Forms.Button
      Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
      Friend WithEvents lblMessage As System.Windows.Forms.Label
      Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider

   End Class

End Namespace