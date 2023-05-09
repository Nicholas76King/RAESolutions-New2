Namespace SpecialOptions

   <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
   Partial Class SpecialOptionCreator
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SpecialOptionCreator))
         Me.lblTitle = New System.Windows.Forms.Label
         Me.lblDescription = New System.Windows.Forms.Label
         Me.lblPrice = New System.Windows.Forms.Label
         Me.lblAssignedBy = New System.Windows.Forms.Label
         Me.lblAssignedTo = New System.Windows.Forms.Label
         Me.lblExpirationDate = New System.Windows.Forms.Label
         Me.txtDescription = New System.Windows.Forms.TextBox
         Me.txtPrice = New System.Windows.Forms.TextBox
         Me.txtAssignedBy = New System.Windows.Forms.TextBox
         Me.txtAssignedTo = New System.Windows.Forms.TextBox
         Me.dtpExpirationDate = New System.Windows.Forms.DateTimePicker
         Me.validator = New System.Windows.Forms.ErrorProvider(Me.components)
         Me.lblCode = New System.Windows.Forms.Label
         Me.txtCode = New System.Windows.Forms.TextBox
         Me.btnOk = New System.Windows.Forms.Button
         CType(Me.validator, System.ComponentModel.ISupportInitialize).BeginInit()
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
         Me.lblTitle.Size = New System.Drawing.Size(325, 28)
         Me.lblTitle.TabIndex = 0
         Me.lblTitle.Text = "Create a special option"
         Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         'lblDescription
         '
         Me.lblDescription.Location = New System.Drawing.Point(9, 43)
         Me.lblDescription.Margin = New System.Windows.Forms.Padding(3)
         Me.lblDescription.Name = "lblDescription"
         Me.lblDescription.Size = New System.Drawing.Size(90, 21)
         Me.lblDescription.TabIndex = 1
         Me.lblDescription.Text = "Description"
         Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         'lblPrice
         '
         Me.lblPrice.Location = New System.Drawing.Point(9, 70)
         Me.lblPrice.Margin = New System.Windows.Forms.Padding(3)
         Me.lblPrice.Name = "lblPrice"
         Me.lblPrice.Size = New System.Drawing.Size(90, 21)
         Me.lblPrice.TabIndex = 2
         Me.lblPrice.Text = "Price"
         Me.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         'lblAssignedBy
         '
         Me.lblAssignedBy.Location = New System.Drawing.Point(9, 97)
         Me.lblAssignedBy.Margin = New System.Windows.Forms.Padding(3)
         Me.lblAssignedBy.Name = "lblAssignedBy"
         Me.lblAssignedBy.Size = New System.Drawing.Size(90, 21)
         Me.lblAssignedBy.TabIndex = 3
         Me.lblAssignedBy.Text = "Assigned By"
         Me.lblAssignedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         'lblAssignedTo
         '
         Me.lblAssignedTo.Location = New System.Drawing.Point(9, 124)
         Me.lblAssignedTo.Margin = New System.Windows.Forms.Padding(3)
         Me.lblAssignedTo.Name = "lblAssignedTo"
         Me.lblAssignedTo.Size = New System.Drawing.Size(90, 21)
         Me.lblAssignedTo.TabIndex = 4
         Me.lblAssignedTo.Text = "Assigned To"
         Me.lblAssignedTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         'lblExpirationDate
         '
         Me.lblExpirationDate.Location = New System.Drawing.Point(9, 151)
         Me.lblExpirationDate.Margin = New System.Windows.Forms.Padding(3)
         Me.lblExpirationDate.Name = "lblExpirationDate"
         Me.lblExpirationDate.Size = New System.Drawing.Size(90, 21)
         Me.lblExpirationDate.TabIndex = 5
         Me.lblExpirationDate.Text = "Expiration Date"
         Me.lblExpirationDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         'txtDescription
         '
         Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                     Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.txtDescription.Location = New System.Drawing.Point(105, 44)
         Me.txtDescription.Name = "txtDescription"
         Me.txtDescription.Size = New System.Drawing.Size(207, 21)
         Me.txtDescription.TabIndex = 1
         Me.txtDescription.Tag = "Description"
         '
         'txtPrice
         '
         Me.txtPrice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                     Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.txtPrice.Location = New System.Drawing.Point(105, 71)
         Me.txtPrice.Name = "txtPrice"
         Me.txtPrice.Size = New System.Drawing.Size(207, 21)
         Me.txtPrice.TabIndex = 5
         Me.txtPrice.Tag = "Price"
         '
         'txtAssignedBy
         '
         Me.txtAssignedBy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                     Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.txtAssignedBy.Location = New System.Drawing.Point(105, 98)
         Me.txtAssignedBy.Name = "txtAssignedBy"
         Me.txtAssignedBy.Size = New System.Drawing.Size(207, 21)
         Me.txtAssignedBy.TabIndex = 10
         Me.txtAssignedBy.Tag = "Assigned by"
         '
         'txtAssignedTo
         '
         Me.txtAssignedTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                     Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.txtAssignedTo.Location = New System.Drawing.Point(105, 125)
         Me.txtAssignedTo.Name = "txtAssignedTo"
         Me.txtAssignedTo.Size = New System.Drawing.Size(207, 21)
         Me.txtAssignedTo.TabIndex = 15
         Me.txtAssignedTo.Tag = "Assigned to"
         '
         'dtpExpirationDate
         '
         Me.dtpExpirationDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                     Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.dtpExpirationDate.Location = New System.Drawing.Point(105, 152)
         Me.dtpExpirationDate.Name = "dtpExpirationDate"
         Me.dtpExpirationDate.Size = New System.Drawing.Size(207, 21)
         Me.dtpExpirationDate.TabIndex = 20
         '
         'validator
         '
         Me.validator.ContainerControl = Me
         Me.validator.Icon = CType(resources.GetObject("validator.Icon"), System.Drawing.Icon)
         '
         'lblCode
         '
         Me.lblCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.lblCode.Location = New System.Drawing.Point(114, 216)
         Me.lblCode.Margin = New System.Windows.Forms.Padding(3)
         Me.lblCode.Name = "lblCode"
         Me.lblCode.Size = New System.Drawing.Size(117, 21)
         Me.lblCode.TabIndex = 12
         Me.lblCode.Text = "Special Option Code"
         Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         'txtCode
         '
         Me.txtCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.txtCode.Location = New System.Drawing.Point(237, 216)
         Me.txtCode.Name = "txtCode"
         Me.txtCode.ReadOnly = True
         Me.txtCode.Size = New System.Drawing.Size(75, 21)
         Me.txtCode.TabIndex = 30
         '
         'btnOk
         '
         Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
         Me.btnOk.Location = New System.Drawing.Point(237, 184)
         Me.btnOk.Name = "btnOk"
         Me.btnOk.Size = New System.Drawing.Size(75, 26)
         Me.btnOk.TabIndex = 25
         Me.btnOk.Text = "Create"
         Me.btnOk.UseVisualStyleBackColor = True
         '
         'SpecialOptionCreator
         '
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.BackColor = System.Drawing.Color.White
         Me.Controls.Add(Me.txtCode)
         Me.Controls.Add(Me.lblCode)
         Me.Controls.Add(Me.btnOk)
         Me.Controls.Add(Me.dtpExpirationDate)
         Me.Controls.Add(Me.txtAssignedTo)
         Me.Controls.Add(Me.txtAssignedBy)
         Me.Controls.Add(Me.txtPrice)
         Me.Controls.Add(Me.txtDescription)
         Me.Controls.Add(Me.lblExpirationDate)
         Me.Controls.Add(Me.lblAssignedTo)
         Me.Controls.Add(Me.lblAssignedBy)
         Me.Controls.Add(Me.lblPrice)
         Me.Controls.Add(Me.lblDescription)
         Me.Controls.Add(Me.lblTitle)
         Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.Name = "SpecialOptionCreator"
         Me.Padding = New System.Windows.Forms.Padding(6)
         Me.Size = New System.Drawing.Size(337, 246)
         CType(Me.validator, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub
      Friend WithEvents lblTitle As System.Windows.Forms.Label
      Friend WithEvents lblDescription As System.Windows.Forms.Label
      Friend WithEvents lblPrice As System.Windows.Forms.Label
      Friend WithEvents lblAssignedBy As System.Windows.Forms.Label
      Friend WithEvents lblAssignedTo As System.Windows.Forms.Label
      Friend WithEvents lblExpirationDate As System.Windows.Forms.Label
      Friend WithEvents txtDescription As System.Windows.Forms.TextBox
      Friend WithEvents txtPrice As System.Windows.Forms.TextBox
      Friend WithEvents txtAssignedBy As System.Windows.Forms.TextBox
      Friend WithEvents txtAssignedTo As System.Windows.Forms.TextBox
      Friend WithEvents dtpExpirationDate As System.Windows.Forms.DateTimePicker
      Friend WithEvents btnOk As System.Windows.Forms.Button
      Friend WithEvents validator As System.Windows.Forms.ErrorProvider
      Friend WithEvents txtCode As System.Windows.Forms.TextBox
      Friend WithEvents lblCode As System.Windows.Forms.Label

   End Class

End Namespace