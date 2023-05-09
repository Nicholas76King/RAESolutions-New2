<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WelcomeForm
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SpaceHolderLabel3 = New System.Windows.Forms.LinkLabel()
        Me.linkRAECorpHome = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.flpRecentProjects = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SpaceHolderLabel2 = New System.Windows.Forms.LinkLabel()
        Me.pnlClose = New System.Windows.Forms.Panel()
        Me.lblClose = New System.Windows.Forms.Label()
        Me.lblX = New System.Windows.Forms.Label()
        Me.TimerRecentProjects = New System.Windows.Forms.Timer(Me.components)
        Me.SpaceHolderLabel1 = New System.Windows.Forms.LinkLabel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblStartNewProject = New System.Windows.Forms.Label()
        Me.lblOpenProject = New System.Windows.Forms.Label()
        Me.lblSelectionsAndRatings = New System.Windows.Forms.Label()
        Me.lblPricingAndDrawings = New System.Windows.Forms.Label()
        Me.lblBoxLoad = New System.Windows.Forms.Label()
        Me.welcome_menu = New System.Windows.Forms.MenuStrip()
        Me.file_menu_item = New System.Windows.Forms.ToolStripMenuItem()
        Me.open_menu_item = New System.Windows.Forms.ToolStripMenuItem()
        Me.select_menu_item = New System.Windows.Forms.ToolStripMenuItem()
        Me.price_menu_item = New System.Windows.Forms.ToolStripMenuItem()
        Me.close_menu_item = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.flpRecentProjects.SuspendLayout()
        Me.pnlClose.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.welcome_menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.FlowLayoutPanel3)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 429)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(656, 167)
        Me.Panel2.TabIndex = 19
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.FlowLayoutPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel3.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel3.Controls.Add(Me.SpaceHolderLabel3)
        Me.FlowLayoutPanel3.Controls.Add(Me.linkRAECorpHome)
        Me.FlowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(395, 0)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(261, 167)
        Me.FlowLayoutPanel3.TabIndex = 26
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(257, 45)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Helpful Links..."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SpaceHolderLabel3
        '
        Me.SpaceHolderLabel3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpaceHolderLabel3.Location = New System.Drawing.Point(3, 45)
        Me.SpaceHolderLabel3.Name = "SpaceHolderLabel3"
        Me.SpaceHolderLabel3.Size = New System.Drawing.Size(247, 45)
        Me.SpaceHolderLabel3.TabIndex = 0
        '
        'linkRAECorpHome
        '
        Me.linkRAECorpHome.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.linkRAECorpHome.ForeColor = System.Drawing.Color.SlateGray
        Me.linkRAECorpHome.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.linkRAECorpHome.Location = New System.Drawing.Point(3, 90)
        Me.linkRAECorpHome.Name = "linkRAECorpHome"
        Me.linkRAECorpHome.Size = New System.Drawing.Size(281, 23)
        Me.linkRAECorpHome.TabIndex = 1
        Me.linkRAECorpHome.Text = " RAE Corporation Home Page"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.flpRecentProjects)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(395, 167)
        Me.Panel1.TabIndex = 24
        '
        'flpRecentProjects
        '
        Me.flpRecentProjects.BackColor = System.Drawing.Color.WhiteSmoke
        Me.flpRecentProjects.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.flpRecentProjects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.flpRecentProjects.Controls.Add(Me.Label2)
        Me.flpRecentProjects.Controls.Add(Me.SpaceHolderLabel2)
        Me.flpRecentProjects.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpRecentProjects.Location = New System.Drawing.Point(0, 0)
        Me.flpRecentProjects.Name = "flpRecentProjects"
        Me.flpRecentProjects.Size = New System.Drawing.Size(395, 167)
        Me.flpRecentProjects.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(391, 45)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Recent Projects..."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SpaceHolderLabel2
        '
        Me.SpaceHolderLabel2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpaceHolderLabel2.Location = New System.Drawing.Point(3, 45)
        Me.SpaceHolderLabel2.Name = "SpaceHolderLabel2"
        Me.SpaceHolderLabel2.Size = New System.Drawing.Size(247, 5)
        Me.SpaceHolderLabel2.TabIndex = 2
        '
        'pnlClose
        '
        Me.pnlClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlClose.BackColor = System.Drawing.Color.Transparent
        Me.pnlClose.Controls.Add(Me.lblClose)
        Me.pnlClose.Controls.Add(Me.lblX)
        Me.pnlClose.Location = New System.Drawing.Point(562, 11)
        Me.pnlClose.Name = "pnlClose"
        Me.pnlClose.Size = New System.Drawing.Size(83, 65)
        Me.pnlClose.TabIndex = 2
        '
        'lblClose
        '
        Me.lblClose.BackColor = System.Drawing.Color.Transparent
        Me.lblClose.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblClose.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClose.Location = New System.Drawing.Point(0, 39)
        Me.lblClose.Name = "lblClose"
        Me.lblClose.Size = New System.Drawing.Size(83, 19)
        Me.lblClose.TabIndex = 2
        Me.lblClose.Text = "Close"
        Me.lblClose.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblX
        '
        Me.lblX.BackColor = System.Drawing.Color.Transparent
        Me.lblX.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblX.ForeColor = System.Drawing.Color.White
        Me.lblX.Location = New System.Drawing.Point(0, 0)
        Me.lblX.Name = "lblX"
        Me.lblX.Size = New System.Drawing.Size(83, 39)
        Me.lblX.TabIndex = 0
        Me.lblX.Text = "X"
        Me.lblX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimerRecentProjects
        '
        Me.TimerRecentProjects.Interval = 250
        '
        'SpaceHolderLabel1
        '
        Me.SpaceHolderLabel1.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpaceHolderLabel1.LinkColor = System.Drawing.Color.Black
        Me.SpaceHolderLabel1.Location = New System.Drawing.Point(3, 0)
        Me.SpaceHolderLabel1.Name = "SpaceHolderLabel1"
        Me.SpaceHolderLabel1.Size = New System.Drawing.Size(603, 54)
        Me.SpaceHolderLabel1.TabIndex = 2
        Me.SpaceHolderLabel1.TabStop = True
        Me.SpaceHolderLabel1.Text = "Welcome to RAE Solutions"
        Me.SpaceHolderLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel1.Controls.Add(Me.SpaceHolderLabel1)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button1)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel3)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(656, 429)
        Me.FlowLayoutPanel1.TabIndex = 16
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblStartNewProject)
        Me.Panel3.Controls.Add(Me.lblOpenProject)
        Me.Panel3.Controls.Add(Me.lblSelectionsAndRatings)
        Me.Panel3.Controls.Add(Me.lblPricingAndDrawings)
        Me.Panel3.Controls.Add(Me.lblBoxLoad)
        Me.Panel3.Location = New System.Drawing.Point(3, 57)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(642, 366)
        Me.Panel3.TabIndex = 12
        '
        'lblStartNewProject
        '
        Me.lblStartNewProject.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStartNewProject.ForeColor = System.Drawing.Color.SlateGray
        Me.lblStartNewProject.Image = Global.Rae.RaeSolutions.My.Resources.Resources.NewProjectSmoke
        Me.lblStartNewProject.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblStartNewProject.Location = New System.Drawing.Point(-1, -3)
        Me.lblStartNewProject.Name = "lblStartNewProject"
        Me.lblStartNewProject.Padding = New System.Windows.Forms.Padding(0, 0, 0, 20)
        Me.lblStartNewProject.Size = New System.Drawing.Size(214, 170)
        Me.lblStartNewProject.TabIndex = 13
        Me.lblStartNewProject.Tag = "1"
        Me.lblStartNewProject.Text = "Start a New Project"
        Me.lblStartNewProject.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblOpenProject
        '
        Me.lblOpenProject.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOpenProject.ForeColor = System.Drawing.Color.SlateGray
        Me.lblOpenProject.Image = Global.Rae.RaeSolutions.My.Resources.Resources.OpenProjectSmoke
        Me.lblOpenProject.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblOpenProject.Location = New System.Drawing.Point(428, 0)
        Me.lblOpenProject.Name = "lblOpenProject"
        Me.lblOpenProject.Padding = New System.Windows.Forms.Padding(0, 0, 0, 20)
        Me.lblOpenProject.Size = New System.Drawing.Size(214, 170)
        Me.lblOpenProject.TabIndex = 12
        Me.lblOpenProject.Tag = "2"
        Me.lblOpenProject.Text = "Open a Project"
        Me.lblOpenProject.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblSelectionsAndRatings
        '
        Me.lblSelectionsAndRatings.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectionsAndRatings.ForeColor = System.Drawing.Color.SlateGray
        Me.lblSelectionsAndRatings.Image = Global.Rae.RaeSolutions.My.Resources.Resources.SelectionRatingSmoke
        Me.lblSelectionsAndRatings.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblSelectionsAndRatings.Location = New System.Drawing.Point(-1, 206)
        Me.lblSelectionsAndRatings.Name = "lblSelectionsAndRatings"
        Me.lblSelectionsAndRatings.Padding = New System.Windows.Forms.Padding(0, 0, 0, 20)
        Me.lblSelectionsAndRatings.Size = New System.Drawing.Size(214, 170)
        Me.lblSelectionsAndRatings.TabIndex = 14
        Me.lblSelectionsAndRatings.Tag = "3"
        Me.lblSelectionsAndRatings.Text = "Selections and Ratings"
        Me.lblSelectionsAndRatings.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblPricingAndDrawings
        '
        Me.lblPricingAndDrawings.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPricingAndDrawings.ForeColor = System.Drawing.Color.SlateGray
        Me.lblPricingAndDrawings.Image = Global.Rae.RaeSolutions.My.Resources.Resources.PricingSmoke
        Me.lblPricingAndDrawings.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblPricingAndDrawings.Location = New System.Drawing.Point(427, 206)
        Me.lblPricingAndDrawings.Name = "lblPricingAndDrawings"
        Me.lblPricingAndDrawings.Padding = New System.Windows.Forms.Padding(0, 0, 0, 20)
        Me.lblPricingAndDrawings.Size = New System.Drawing.Size(214, 170)
        Me.lblPricingAndDrawings.TabIndex = 15
        Me.lblPricingAndDrawings.Tag = "3"
        Me.lblPricingAndDrawings.Text = "Pricing and Drawings"
        Me.lblPricingAndDrawings.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblBoxLoad
        '
        Me.lblBoxLoad.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBoxLoad.ForeColor = System.Drawing.Color.SlateGray
        Me.lblBoxLoad.Image = Global.Rae.RaeSolutions.My.Resources.Resources.BoxloadSmoke
        Me.lblBoxLoad.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblBoxLoad.Location = New System.Drawing.Point(207, 102)
        Me.lblBoxLoad.Name = "lblBoxLoad"
        Me.lblBoxLoad.Padding = New System.Windows.Forms.Padding(0, 0, 0, 20)
        Me.lblBoxLoad.Size = New System.Drawing.Size(214, 170)
        Me.lblBoxLoad.TabIndex = 16
        Me.lblBoxLoad.Tag = "2"
        Me.lblBoxLoad.Text = "Box Load"
        Me.lblBoxLoad.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'welcome_menu
        '
        Me.welcome_menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.file_menu_item})
        Me.welcome_menu.Location = New System.Drawing.Point(0, 0)
        Me.welcome_menu.Name = "welcome_menu"
        Me.welcome_menu.Size = New System.Drawing.Size(656, 24)
        Me.welcome_menu.TabIndex = 13
        Me.welcome_menu.Text = "MenuStrip1"
        Me.welcome_menu.Visible = False
        '
        'file_menu_item
        '
        Me.file_menu_item.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.open_menu_item, Me.select_menu_item, Me.price_menu_item, Me.close_menu_item})
        Me.file_menu_item.Name = "file_menu_item"
        Me.file_menu_item.Size = New System.Drawing.Size(37, 20)
        Me.file_menu_item.Text = "&File"
        '
        'open_menu_item
        '
        Me.open_menu_item.Name = "open_menu_item"
        Me.open_menu_item.Size = New System.Drawing.Size(105, 22)
        Me.open_menu_item.Text = "&Open"
        '
        'select_menu_item
        '
        Me.select_menu_item.Name = "select_menu_item"
        Me.select_menu_item.Size = New System.Drawing.Size(105, 22)
        Me.select_menu_item.Text = "&Select"
        '
        'price_menu_item
        '
        Me.price_menu_item.Name = "price_menu_item"
        Me.price_menu_item.Size = New System.Drawing.Size(105, 22)
        Me.price_menu_item.Text = "&Price"
        '
        'close_menu_item
        '
        Me.close_menu_item.Name = "close_menu_item"
        Me.close_menu_item.Size = New System.Drawing.Size(105, 22)
        Me.close_menu_item.Text = "&Close"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Red
        Me.Button1.Location = New System.Drawing.Point(612, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button1.Size = New System.Drawing.Size(34, 32)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "X"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'WelcomeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(656, 596)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.welcome_menu)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MainMenuStrip = Me.welcome_menu
        Me.Name = "WelcomeForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Welcome to RAE Solutions"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.Panel2.ResumeLayout(False)
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.flpRecentProjects.ResumeLayout(False)
        Me.pnlClose.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.welcome_menu.ResumeLayout(False)
        Me.welcome_menu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    ''Friend WithEvents Header4 As RAE.UI.Controls.Header
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    ''Friend WithEvents Header1 As RAE.UI.Controls.Header
    Friend WithEvents pnlClose As System.Windows.Forms.Panel
   Friend WithEvents lblX As System.Windows.Forms.Label
   Friend WithEvents lblClose As System.Windows.Forms.Label
   Friend WithEvents FlowLayoutPanel3 As System.Windows.Forms.FlowLayoutPanel
   Friend WithEvents SpaceHolderLabel3 As System.Windows.Forms.LinkLabel
    ''Friend WithEvents Header2 As RAE.UI.Controls.Header
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents flpRecentProjects As System.Windows.Forms.FlowLayoutPanel
   Friend WithEvents SpaceHolderLabel2 As System.Windows.Forms.LinkLabel
    ''Friend WithEvents Header3 As RAE.UI.Controls.Header
    Friend WithEvents linkRAECorpHome As System.Windows.Forms.Label
   Friend WithEvents TimerRecentProjects As System.Windows.Forms.Timer
   Friend WithEvents SpaceHolderLabel1 As System.Windows.Forms.LinkLabel
   Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
   Friend WithEvents Panel3 As System.Windows.Forms.Panel
   Friend WithEvents lblStartNewProject As System.Windows.Forms.Label
   Friend WithEvents lblOpenProject As System.Windows.Forms.Label
   Friend WithEvents lblSelectionsAndRatings As System.Windows.Forms.Label
   Friend WithEvents lblPricingAndDrawings As System.Windows.Forms.Label
   Friend WithEvents lblBoxLoad As System.Windows.Forms.Label
   Friend WithEvents welcome_menu As System.Windows.Forms.MenuStrip
   Friend WithEvents file_menu_item As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents close_menu_item As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents price_menu_item As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents select_menu_item As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents open_menu_item As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
End Class
