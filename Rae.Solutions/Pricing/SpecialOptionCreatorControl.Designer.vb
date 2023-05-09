<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SpecialOptionCreatorControl
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
      Me.lblCode = New System.Windows.Forms.Label
      Me.txtCode = New System.Windows.Forms.TextBox
      Me.txtDescription = New System.Windows.Forms.TextBox
      Me.lblDescription = New System.Windows.Forms.Label
      Me.txtPrice = New System.Windows.Forms.TextBox
      Me.lblPrice = New System.Windows.Forms.Label
      Me.txtAuthorizedBy = New System.Windows.Forms.TextBox
      Me.lblAuthorizedBy = New System.Windows.Forms.Label
      Me.txtQuantity = New System.Windows.Forms.TextBox
      Me.lblQuantity = New System.Windows.Forms.Label
      Me.err = New System.Windows.Forms.ErrorProvider(Me.components)
      CType(Me.err, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'lblCode
      '
      Me.lblCode.Location = New System.Drawing.Point(3, 0)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(80, 21)
      Me.lblCode.TabIndex = 1
      Me.lblCode.Text = "Code"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtCode
      '
      Me.txtCode.Location = New System.Drawing.Point(88, 0)
      Me.txtCode.Name = "txtCode"
      Me.txtCode.Size = New System.Drawing.Size(100, 21)
      Me.txtCode.TabIndex = 2
      '
      'txtDescription
      '
      Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtDescription.Location = New System.Drawing.Point(88, 54)
      Me.txtDescription.Multiline = True
      Me.txtDescription.Name = "txtDescription"
      Me.txtDescription.Size = New System.Drawing.Size(277, 21)
      Me.txtDescription.TabIndex = 14
      '
      'lblDescription
      '
      Me.lblDescription.Location = New System.Drawing.Point(3, 54)
      Me.lblDescription.Name = "lblDescription"
      Me.lblDescription.Size = New System.Drawing.Size(80, 21)
      Me.lblDescription.TabIndex = 3
      Me.lblDescription.Text = "Description"
      Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtPrice
      '
      Me.txtPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtPrice.Location = New System.Drawing.Point(265, 0)
      Me.txtPrice.Name = "txtPrice"
      Me.txtPrice.Size = New System.Drawing.Size(100, 21)
      Me.txtPrice.TabIndex = 6
      '
      'lblPrice
      '
      Me.lblPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblPrice.Location = New System.Drawing.Point(209, 0)
      Me.lblPrice.Name = "lblPrice"
      Me.lblPrice.Size = New System.Drawing.Size(51, 21)
      Me.lblPrice.TabIndex = 5
      Me.lblPrice.Text = "Price"
      Me.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtAuthorizedBy
      '
      Me.txtAuthorizedBy.Location = New System.Drawing.Point(88, 27)
      Me.txtAuthorizedBy.Name = "txtAuthorizedBy"
      Me.txtAuthorizedBy.Size = New System.Drawing.Size(100, 21)
      Me.txtAuthorizedBy.TabIndex = 8
      '
      'lblAuthorizedBy
      '
      Me.lblAuthorizedBy.Location = New System.Drawing.Point(3, 27)
      Me.lblAuthorizedBy.Name = "lblAuthorizedBy"
      Me.lblAuthorizedBy.Size = New System.Drawing.Size(80, 21)
      Me.lblAuthorizedBy.TabIndex = 7
      Me.lblAuthorizedBy.Text = "Authorized by"
      Me.lblAuthorizedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtQuantity
      '
      Me.txtQuantity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtQuantity.Location = New System.Drawing.Point(265, 27)
      Me.txtQuantity.Name = "txtQuantity"
      Me.txtQuantity.Size = New System.Drawing.Size(100, 21)
      Me.txtQuantity.TabIndex = 11
      '
      'lblQuantity
      '
      Me.lblQuantity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblQuantity.Location = New System.Drawing.Point(209, 27)
      Me.lblQuantity.Name = "lblQuantity"
      Me.lblQuantity.Size = New System.Drawing.Size(51, 21)
      Me.lblQuantity.TabIndex = 10
      Me.lblQuantity.Text = "Quantity"
      Me.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'err
      '
      Me.err.ContainerControl = Me
      '
      'SpecialOptionCreatorControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.White
      Me.Controls.Add(Me.txtQuantity)
      Me.Controls.Add(Me.lblQuantity)
      Me.Controls.Add(Me.txtAuthorizedBy)
      Me.Controls.Add(Me.lblAuthorizedBy)
      Me.Controls.Add(Me.txtPrice)
      Me.Controls.Add(Me.lblPrice)
      Me.Controls.Add(Me.txtDescription)
      Me.Controls.Add(Me.lblDescription)
      Me.Controls.Add(Me.txtCode)
      Me.Controls.Add(Me.lblCode)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Name = "SpecialOptionCreatorControl"
      Me.Size = New System.Drawing.Size(390, 78)
      CType(Me.err, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblCode As System.Windows.Forms.Label
   Friend WithEvents txtCode As System.Windows.Forms.TextBox
   Friend WithEvents txtDescription As System.Windows.Forms.TextBox
   Friend WithEvents lblDescription As System.Windows.Forms.Label
   Friend WithEvents txtPrice As System.Windows.Forms.TextBox
   Friend WithEvents lblPrice As System.Windows.Forms.Label
   Friend WithEvents txtAuthorizedBy As System.Windows.Forms.TextBox
   Friend WithEvents lblAuthorizedBy As System.Windows.Forms.Label
   Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
   Friend WithEvents lblQuantity As System.Windows.Forms.Label
   Friend WithEvents err As System.Windows.Forms.ErrorProvider

End Class
