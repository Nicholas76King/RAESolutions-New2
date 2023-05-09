Namespace Rae.Presentation.SpecialOptions

   <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
   Partial Class SpecialOptionsView
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SpecialOptionsView))
         Me.SpecialOptionsGrid1 = New RAE.Presentation.SpecialOptions.SpecialOptionsGrid
         Me.lblTitle = New System.Windows.Forms.Label
         Me.btnRefresh = New System.Windows.Forms.Button
         Me.btnSalesman = New System.Windows.Forms.Button
         Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
         Me.lblSalesman = New System.Windows.Forms.Label
         Me.txtSalesman = New System.Windows.Forms.TextBox
         Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
         Me.btnCode = New System.Windows.Forms.Button
         Me.lblCode = New System.Windows.Forms.Label
         Me.txtCode = New System.Windows.Forms.TextBox
         Me.SuspendLayout()
         '
         'SpecialOptionsGrid1
         '
         Me.SpecialOptionsGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                     Or System.Windows.Forms.AnchorStyles.Left) _
                     Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.SpecialOptionsGrid1.BackColor = System.Drawing.Color.White
         Me.SpecialOptionsGrid1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.SpecialOptionsGrid1.Location = New System.Drawing.Point(15, 69)
         Me.SpecialOptionsGrid1.Name = "SpecialOptionsGrid1"
         Me.SpecialOptionsGrid1.Size = New System.Drawing.Size(346, 154)
         Me.SpecialOptionsGrid1.TabIndex = 25
         '
         'lblTitle
         '
         Me.lblTitle.BackColor = System.Drawing.Color.LightSteelBlue
         Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
         Me.lblTitle.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.lblTitle.ForeColor = System.Drawing.Color.White
         Me.lblTitle.Location = New System.Drawing.Point(6, 6)
         Me.lblTitle.Name = "lblTitle"
         Me.lblTitle.Size = New System.Drawing.Size(366, 28)
         Me.lblTitle.TabIndex = 1
         Me.lblTitle.Text = "View special options"
         Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         'btnRefresh
         '
         Me.btnRefresh.Image = My.Resources.Resources.RefreshDocViewHS
         Me.btnRefresh.Location = New System.Drawing.Point(15, 40)
         Me.btnRefresh.Name = "btnRefresh"
         Me.btnRefresh.Size = New System.Drawing.Size(24, 23)
         Me.btnRefresh.TabIndex = 1
         Me.ToolTip1.SetToolTip(Me.btnRefresh, "Refresh; view all")
         Me.btnRefresh.UseVisualStyleBackColor = True
         '
         'btnSalesman
         '
         Me.btnSalesman.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.btnSalesman.ImageIndex = 0
         Me.btnSalesman.ImageList = Me.ImageList1
         Me.btnSalesman.Location = New System.Drawing.Point(335, 40)
         Me.btnSalesman.Name = "btnSalesman"
         Me.btnSalesman.Size = New System.Drawing.Size(24, 23)
         Me.btnSalesman.TabIndex = 20
         Me.ToolTip1.SetToolTip(Me.btnSalesman, "Filter by name")
         Me.btnSalesman.UseVisualStyleBackColor = True
         '
         'ImageList1
         '
         Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
         Me.ImageList1.TransparentColor = System.Drawing.Color.Fuchsia
         Me.ImageList1.Images.SetKeyName(0, "searchPeople.bmp")
         Me.ImageList1.Images.SetKeyName(1, "search.bmp")
         '
         'lblSalesman
         '
         Me.lblSalesman.Location = New System.Drawing.Point(175, 41)
         Me.lblSalesman.Name = "lblSalesman"
         Me.lblSalesman.Size = New System.Drawing.Size(52, 21)
         Me.lblSalesman.TabIndex = 4
         Me.lblSalesman.Text = "By/For"
         Me.lblSalesman.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         Me.ToolTip1.SetToolTip(Me.lblSalesman, "Name of person who authorized special option, or name of person option was author" & _
                 "ized for.")
         '
         'txtSalesman
         '
         Me.txtSalesman.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                     Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.txtSalesman.Location = New System.Drawing.Point(231, 41)
         Me.txtSalesman.Name = "txtSalesman"
         Me.txtSalesman.Size = New System.Drawing.Size(103, 21)
         Me.txtSalesman.TabIndex = 15
         Me.ToolTip1.SetToolTip(Me.txtSalesman, "Name of person who authorized special option, or name of person option was author" & _
                 "ized for.")
         '
         'btnCode
         '
         Me.btnCode.Image = CType(resources.GetObject("btnCode.Image"), System.Drawing.Image)
         Me.btnCode.Location = New System.Drawing.Point(142, 40)
         Me.btnCode.Name = "btnCode"
         Me.btnCode.Size = New System.Drawing.Size(24, 23)
         Me.btnCode.TabIndex = 10
         Me.ToolTip1.SetToolTip(Me.btnCode, "Filter by option code")
         Me.btnCode.UseVisualStyleBackColor = True
         '
         'lblCode
         '
         Me.lblCode.Location = New System.Drawing.Point(52, 41)
         Me.lblCode.Name = "lblCode"
         Me.lblCode.Size = New System.Drawing.Size(38, 21)
         Me.lblCode.TabIndex = 7
         Me.lblCode.Text = "Code"
         Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'txtCode
         '
         Me.txtCode.Location = New System.Drawing.Point(94, 41)
         Me.txtCode.Name = "txtCode"
         Me.txtCode.Size = New System.Drawing.Size(47, 21)
         Me.txtCode.TabIndex = 4
         Me.txtCode.Text = "SP01"
         '
         'SpecialOptionsView
         '
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.BackColor = System.Drawing.Color.White
         Me.Controls.Add(Me.lblCode)
         Me.Controls.Add(Me.txtCode)
         Me.Controls.Add(Me.btnCode)
         Me.Controls.Add(Me.lblSalesman)
         Me.Controls.Add(Me.btnSalesman)
         Me.Controls.Add(Me.btnRefresh)
         Me.Controls.Add(Me.lblTitle)
         Me.Controls.Add(Me.SpecialOptionsGrid1)
         Me.Controls.Add(Me.txtSalesman)
         Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.Name = "SpecialOptionsView"
         Me.Padding = New System.Windows.Forms.Padding(6)
         Me.Size = New System.Drawing.Size(378, 238)
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub
      Friend WithEvents SpecialOptionsGrid1 As RAE.Presentation.SpecialOptions.SpecialOptionsGrid
      Friend WithEvents lblTitle As System.Windows.Forms.Label
      Friend WithEvents btnRefresh As System.Windows.Forms.Button
      Friend WithEvents btnSalesman As System.Windows.Forms.Button
      Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
      Friend WithEvents lblSalesman As System.Windows.Forms.Label
      Friend WithEvents txtSalesman As System.Windows.Forms.TextBox
      Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
      Friend WithEvents btnCode As System.Windows.Forms.Button
      Friend WithEvents lblCode As System.Windows.Forms.Label
      Friend WithEvents txtCode As System.Windows.Forms.TextBox

   End Class

End Namespace