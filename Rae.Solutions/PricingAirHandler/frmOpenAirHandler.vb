Imports System.Data
Imports Microsoft.VisualBasic

Public Class frmOpenAirHandler
   Inherits System.Windows.Forms.Form

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
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
   Friend WithEvents txtQuoteNumber As System.Windows.Forms.TextBox
   Friend WithEvents btnOK As System.Windows.Forms.Button
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents errNew As System.Windows.Forms.ErrorProvider
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.Label1 = New System.Windows.Forms.Label
      Me.Label3 = New System.Windows.Forms.Label
      Me.GroupBox1 = New System.Windows.Forms.GroupBox
      Me.txtProjectName = New System.Windows.Forms.TextBox
      Me.Label4 = New System.Windows.Forms.Label
      Me.txtQuoteNumber = New System.Windows.Forms.TextBox
      Me.btnOK = New System.Windows.Forms.Button
      Me.btnCancel = New System.Windows.Forms.Button
      Me.GroupBox2 = New System.Windows.Forms.GroupBox
      Me.errNew = New System.Windows.Forms.ErrorProvider
      Me.SuspendLayout()
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.Location = New System.Drawing.Point(8, 8)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(136, 23)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Create new project"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label3
      '
      Me.Label3.Location = New System.Drawing.Point(24, 40)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(96, 23)
      Me.Label3.TabIndex = 2
      Me.Label3.Text = "Project Name"
      Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'GroupBox1
      '
      Me.GroupBox1.Location = New System.Drawing.Point(120, 14)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(168, 8)
      Me.GroupBox1.TabIndex = 3
      Me.GroupBox1.TabStop = False
      '
      'txtProjectName
      '
      Me.txtProjectName.Location = New System.Drawing.Point(128, 40)
      Me.txtProjectName.Name = "txtProjectName"
      Me.txtProjectName.Size = New System.Drawing.Size(144, 21)
      Me.txtProjectName.TabIndex = 1
      Me.txtProjectName.Tag = "Project Name"
      Me.txtProjectName.Text = ""
      '
      'Label4
      '
      Me.Label4.Location = New System.Drawing.Point(24, 64)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(96, 23)
      Me.Label4.TabIndex = 5
      Me.Label4.Text = "Quote Number"
      Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtQuoteNumber
      '
      Me.txtQuoteNumber.Location = New System.Drawing.Point(128, 64)
      Me.txtQuoteNumber.Name = "txtQuoteNumber"
      Me.txtQuoteNumber.ReadOnly = True
      Me.txtQuoteNumber.Size = New System.Drawing.Size(144, 21)
      Me.txtQuoteNumber.TabIndex = 6
      Me.txtQuoteNumber.TabStop = False
      Me.txtQuoteNumber.Tag = "Quote Number"
      Me.txtQuoteNumber.Text = ""
      '
      'btnOK
      '
      Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnOK.Location = New System.Drawing.Point(120, 112)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.TabIndex = 2
      Me.btnOK.Text = "OK"
      '
      'btnCancel
      '
      Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCancel.Location = New System.Drawing.Point(200, 112)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.TabIndex = 3
      Me.btnCancel.Text = "Cancel"
      '
      'GroupBox2
      '
      Me.GroupBox2.Location = New System.Drawing.Point(8, 96)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(280, 8)
      Me.GroupBox2.TabIndex = 9
      Me.GroupBox2.TabStop = False
      '
      'errNew
      '
      Me.errNew.ContainerControl = Me
      '
      'frmOpenAirHandler
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
      Me.ClientSize = New System.Drawing.Size(292, 142)
      Me.Controls.Add(Me.GroupBox2)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.txtQuoteNumber)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.txtProjectName)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.Label1)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Name = "frmOpenAirHandler"
      Me.Opacity = 0.92
      Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
      Me.Text = "New Project"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _projectName As String
   Private _quoteNumber As String
   Public canceled As Boolean = False

   ReadOnly Property ProjectName() As String
      Get
         Return _projectName
      End Get
   End Property

   ReadOnly Property QuoteNumber() As String
      Get
         Return _quoteNumber
      End Get
   End Property


   Private Sub frmOpenAirHandler_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Dim i As Integer = 1
      Dim quoteNumberIsUnique As Boolean = False
      Dim sql As String
      Dim reader As IDataReader
      Dim connection As IDbConnection = Rae.RaeSolutions.DataAccess.Common.CreateConnection(Rae.RaeSolutions.DataAccess.Common.AirHandlerProjectsDbPath) 'New OleDb.OleDbConnection(DataAccess.Common.GetConnectionString(DataAccess.Common.AirHandlerProjectsDbPath))
      Dim command As IDbCommand 'OleDb.OleDbCommand

      While (Not quoteNumberIsUnique)
         Me.txtQuoteNumber.Text = Format(System.DateTime.Now, "MMddyy") & "." & AppInfo.User.username & "." & Format(i, "000")
         sql = "SELECT QuoteNumber FROM SavedProject WHERE QuoteNumber = '" & Me.txtQuoteNumber.Text & "'"
         command = New OleDb.OleDbCommand(sql, connection)
         Try
            connection.Open()
            reader = command.ExecuteReader()
            'determines if quote number is unique
            quoteNumberIsUnique = Not reader.Read 'reader.HasRows()
         Catch Ex As Exception
            MessageBox.Show("Attempt to create unique quote number failed. " & Ex.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
         Finally
            If reader IsNot Nothing Then reader.Close()
            If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try
         i += 1
      End While

   End Sub


   Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
      Me.canceled = True
      Me.Close()
   End Sub


   Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
      'validate
      _projectName = Me.txtProjectName.Text
      _quoteNumber = Me.txtQuoteNumber.Text

      'if not blank
      If Not mValidator.ValidateBlankControl(Me.txtProjectName, Me.errNew) Then
         If Not mValidator.ValidateBlankControl(Me.txtQuoteNumber, Me.errNew) Then
            Me.Visible = False
         End If
      End If
   End Sub

End Class
