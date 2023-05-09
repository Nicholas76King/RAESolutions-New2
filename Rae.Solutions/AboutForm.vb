Option Strict On
Option Explicit On

Imports System
Imports System.Windows.Forms
Imports System.Diagnostics

''' <summary>
''' Displays information about application.
''' </summary>
''' <remarks>
''' Using ShowDialog to display this form will cause the OK button to close the form.
''' </remarks>
Public Class AboutForm
   Inherits Form

#Region " Windows Form Designer generated code "

   Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call

   End Sub

   'Form overrides dispose to clean up the component list.
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If Not (components Is Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
   Friend WithEvents lblCompany As System.Windows.Forms.Label
   Friend WithEvents lblVersion As System.Windows.Forms.Label
   Friend WithEvents lblDescription As System.Windows.Forms.Label
   Friend WithEvents lblProduct As System.Windows.Forms.Label
   Friend WithEvents lblShowCompany As System.Windows.Forms.Label
   Friend WithEvents btnOK As System.Windows.Forms.Button
   Friend WithEvents lblShowVersion As System.Windows.Forms.Label
   Friend WithEvents lblShowDescription As System.Windows.Forms.Label
   Friend WithEvents lblShowCopyright As System.Windows.Forms.Label
   Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
   Friend WithEvents lblShowProduct As System.Windows.Forms.Label
    Friend WithEvents tipAbout As System.Windows.Forms.ToolTip
    Friend WithEvents lblUserType As System.Windows.Forms.Label
    Friend WithEvents lblExpirationDate As System.Windows.Forms.Label
    Friend WithEvents lblShowExpirationDate As System.Windows.Forms.Label
    Friend WithEvents gboInfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutForm))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblCompany = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblProduct = New System.Windows.Forms.Label()
        Me.lblShowCompany = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lblShowVersion = New System.Windows.Forms.Label()
        Me.lblShowDescription = New System.Windows.Forms.Label()
        Me.lblShowCopyright = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lblShowProduct = New System.Windows.Forms.Label()
        Me.tipAbout = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblUserType = New System.Windows.Forms.Label()
        Me.lblExpirationDate = New System.Windows.Forms.Label()
        Me.lblShowExpirationDate = New System.Windows.Forms.Label()
        Me.gboInfo = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(345, 99)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'lblCompany
        '
        Me.lblCompany.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompany.ForeColor = System.Drawing.Color.Maroon
        Me.lblCompany.Location = New System.Drawing.Point(2, 63)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(95, 23)
        Me.lblCompany.TabIndex = 1
        Me.lblCompany.Text = "company:"
        Me.lblCompany.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblVersion
        '
        Me.lblVersion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.Maroon
        Me.lblVersion.Location = New System.Drawing.Point(2, 40)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(95, 23)
        Me.lblVersion.TabIndex = 2
        Me.lblVersion.Text = "version:"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblDescription
        '
        Me.lblDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.ForeColor = System.Drawing.Color.Maroon
        Me.lblDescription.Location = New System.Drawing.Point(2, 95)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(95, 34)
        Me.lblDescription.TabIndex = 3
        Me.lblDescription.Text = "description:"
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblProduct
        '
        Me.lblProduct.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProduct.ForeColor = System.Drawing.Color.Maroon
        Me.lblProduct.Location = New System.Drawing.Point(2, 17)
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Size = New System.Drawing.Size(95, 23)
        Me.lblProduct.TabIndex = 4
        Me.lblProduct.Text = "product:"
        Me.lblProduct.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblShowCompany
        '
        Me.lblShowCompany.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblShowCompany.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShowCompany.ForeColor = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.lblShowCompany.Location = New System.Drawing.Point(99, 63)
        Me.lblShowCompany.Name = "lblShowCompany"
        Me.lblShowCompany.Size = New System.Drawing.Size(204, 23)
        Me.lblShowCompany.TabIndex = 5
        Me.lblShowCompany.Text = "RAE Corporation"
        Me.lblShowCompany.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnOK.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOK.Location = New System.Drawing.Point(259, 305)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(70, 22)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'lblShowVersion
        '
        Me.lblShowVersion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShowVersion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.lblShowVersion.Location = New System.Drawing.Point(100, 40)
        Me.lblShowVersion.Name = "lblShowVersion"
        Me.lblShowVersion.Size = New System.Drawing.Size(122, 23)
        Me.lblShowVersion.TabIndex = 8
        Me.lblShowVersion.Text = "0.0.0.0"
        Me.lblShowVersion.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblShowDescription
        '
        Me.lblShowDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblShowDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShowDescription.ForeColor = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.lblShowDescription.Location = New System.Drawing.Point(99, 95)
        Me.lblShowDescription.Name = "lblShowDescription"
        Me.lblShowDescription.Size = New System.Drawing.Size(204, 34)
        Me.lblShowDescription.TabIndex = 9
        Me.lblShowDescription.Text = "description blah blah"
        '
        'lblShowCopyright
        '
        Me.lblShowCopyright.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblShowCopyright.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShowCopyright.Location = New System.Drawing.Point(6, 342)
        Me.lblShowCopyright.Name = "lblShowCopyright"
        Me.lblShowCopyright.Size = New System.Drawing.Size(332, 22)
        Me.lblShowCopyright.TabIndex = 11
        Me.lblShowCopyright.Text = "copyright"
        Me.lblShowCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.BackColor = System.Drawing.Color.Maroon
        Me.PictureBox2.Location = New System.Drawing.Point(0, 338)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(345, 2)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 12
        Me.PictureBox2.TabStop = False
        '
        'lblShowProduct
        '
        Me.lblShowProduct.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblShowProduct.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShowProduct.ForeColor = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.lblShowProduct.Location = New System.Drawing.Point(100, 17)
        Me.lblShowProduct.Name = "lblShowProduct"
        Me.lblShowProduct.Size = New System.Drawing.Size(204, 23)
        Me.lblShowProduct.TabIndex = 13
        Me.lblShowProduct.Text = "RAE Corporation"
        Me.lblShowProduct.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblUserType
        '
        Me.lblUserType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUserType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.lblUserType.Location = New System.Drawing.Point(221, 40)
        Me.lblUserType.Name = "lblUserType"
        Me.lblUserType.Size = New System.Drawing.Size(82, 23)
        Me.lblUserType.TabIndex = 15
        Me.lblUserType.Text = "Rep"
        Me.lblUserType.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblExpirationDate
        '
        Me.lblExpirationDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExpirationDate.ForeColor = System.Drawing.Color.Maroon
        Me.lblExpirationDate.Location = New System.Drawing.Point(2, 129)
        Me.lblExpirationDate.Name = "lblExpirationDate"
        Me.lblExpirationDate.Size = New System.Drawing.Size(95, 23)
        Me.lblExpirationDate.TabIndex = 16
        Me.lblExpirationDate.Text = "expiration date:"
        Me.lblExpirationDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblShowExpirationDate
        '
        Me.lblShowExpirationDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShowExpirationDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.lblShowExpirationDate.Location = New System.Drawing.Point(99, 129)
        Me.lblShowExpirationDate.Name = "lblShowExpirationDate"
        Me.lblShowExpirationDate.Size = New System.Drawing.Size(100, 23)
        Me.lblShowExpirationDate.TabIndex = 17
        Me.lblShowExpirationDate.Text = "01/01/2006"
        Me.lblShowExpirationDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gboInfo
        '
        Me.gboInfo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gboInfo.Controls.Add(Me.lblShowProduct)
        Me.gboInfo.Controls.Add(Me.lblExpirationDate)
        Me.gboInfo.Controls.Add(Me.lblShowExpirationDate)
        Me.gboInfo.Controls.Add(Me.lblUserType)
        Me.gboInfo.Controls.Add(Me.lblVersion)
        Me.gboInfo.Controls.Add(Me.lblDescription)
        Me.gboInfo.Controls.Add(Me.lblProduct)
        Me.gboInfo.Controls.Add(Me.lblShowCompany)
        Me.gboInfo.Controls.Add(Me.lblShowVersion)
        Me.gboInfo.Controls.Add(Me.lblShowDescription)
        Me.gboInfo.Controls.Add(Me.lblCompany)
        Me.gboInfo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.gboInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboInfo.ForeColor = System.Drawing.Color.Black
        Me.gboInfo.Location = New System.Drawing.Point(15, 130)
        Me.gboInfo.Name = "gboInfo"
        Me.gboInfo.Size = New System.Drawing.Size(315, 163)
        Me.gboInfo.TabIndex = 18
        Me.gboInfo.TabStop = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(17, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(216, 23)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "RAESolutions Information"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'AboutForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(345, 363)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gboInfo)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.lblShowCopyright)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AboutForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "About RAESolutions"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboInfo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private usageLogger As Diagnostics.UsageLog.FormUsageLogger


    ''' <summary>Logs start of form.
    ''' </summary>
    ''' <history>[CASEYJ]	3/17/2005	Created
    ''' </history>
    Private Sub LogFormStart()
        Try
            'logs form usage statistics
            usageLogger = New Diagnostics.UsageLog.FormUsageLogger( _
               Diagnostics.UsageLog.ApplicationUsageLogger.ApplicationID, _
               Diagnostics.UsageLog.ApplicationUsageLogger.LogFile.FullName)
            usageLogger.LogFormStart(Me.Text)
        Catch ex As Exception

        End Try
    End Sub


    ''' <summary>Logs usage statistics available while form is closing.
    ''' </summary>
    ''' <history>[CASEYJ]	3/17/2005	Created
    ''' </history>
    Private Sub LogFormEnd()
        Dim model, refrigerant As String
        Dim ambientTemperature, suctionTemperature As Single

        Try
            ambientTemperature = 999
            suctionTemperature = 999
            model = "NA"
            refrigerant = "NA"
            'logs form usage statistics
            usageLogger.LogFormEnd(model, refrigerant, suctionTemperature, ambientTemperature)
        Catch ex As Exception

        End Try
    End Sub


    ''' <summary>
    ''' Displays application information in controls.
    ''' </summary>
    ''' <remarks>
    ''' Uses assembly info to set controls.
    ''' </remarks>
    Private Sub DisplayAppInfo()
        Try
            ' sets the labels describing the application (e.g. Title, Version, Description)
            Me.Text = "About " & My.Application.Info.Title
            Me.lblShowCompany.ForeColor = Color.FromArgb(255, 173, 122, 57)
            Me.lblShowCompany.Text = My.Application.Info.CompanyName
            Me.lblShowVersion.Text = String.Format("{0}", My.Application.Info.Version.ToString)
            Me.lblShowDescription.Text = My.Application.Info.Description
            Me.lblShowCopyright.Text = My.Application.Info.Copyright '"Copyright © 2004 RAE Corporation. All rights reserved."
            Me.lblUserType.Text = Constants.TARGET_USER_GROUP.ToString.ToUpper
            Me.lblShowProduct.Text = My.Application.Info.Title
            Me.lblShowExpirationDate.Text = Constants.EXPIRATION_DATE.ToString("M/d/yyyy")
        Catch ex As System.Exception
            Ui.MessageBox.Show("Exception occurred while showing application info. " & ex.Message, MessageBoxIcon.Error)
        End Try
    End Sub


#Region " Event handlers"

    ''' <summary>
    ''' Form load event handler
    ''' </summary>
    Private Sub frmAbout_Load(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.Load
        ' logs form usage statistics
        Me.LogFormStart()
        ' displays application info in controls
        Me.DisplayAppInfo()
    End Sub


    ''' <summary>
    ''' Form closing event handler
    ''' </summary>
    Private Sub frmAbout_Closing(ByVal sender As Object, ByVal e As FormClosingEventArgs) _
    Handles MyBase.FormClosing
        ' logs by whom and when form closes
        Me.LogFormEnd()
    End Sub



#End Region

End Class
