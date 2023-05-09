Option Strict Off
Option Explicit On


Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.Compatibility
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports DataAgent = Rae.RaeSolutions.Business.Agents.AirHandlerDataAgent
Imports Rae.RaeSolutions.Business
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.solutions
Imports Rae.Deployment


Public Class form_project_info
    Inherits System.Windows.Forms.Form

    Dim IsInitializing As Boolean = True
    Dim _airHandlerForm As form_unit_info


    Public Property AirHandlerForm() As form_unit_info
        Get
            Return Me._airHandlerForm
        End Get
        Set(ByVal Value As form_unit_info)
            Me._airHandlerForm = Value
        End Set
    End Property


    'shared instance to implement singleton pattern
    Private Shared _instance As form_project_info


    'only allows a single instance of this form
    Public Shared Function GetInstance() As form_project_info
        If _instance Is Nothing Then
            _instance = New form_project_info
        End If

        Return _instance
    End Function


    Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
        'cancels close, b/c in singleton pattern form shouldn't be disposed
        e.Cancel = True
        'clears project data, if form is re-opened the form will be blank
        Me.DseProject1.Clear()
        'hides form, so that it appears as though it's closed
        Me.Hide()
    End Sub


#Region "Windows Form Designer generated code "

    Private Sub New()
        MyBase.New()
        If m_vb6FormDefInstance Is Nothing Then
            If m_InitializingDefInstance Then
                m_vb6FormDefInstance = Me
            Else
                Try
                    'For the start-up form, the first instance created is the default instance.
                    If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
                        m_vb6FormDefInstance = Me
                    End If
                Catch
                End Try
            End If
        End If


        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Me.IsInitializing = False
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents lbl_contractor As System.Windows.Forms.Label
    Public WithEvents lbl_engineer As System.Windows.Forms.Label
    Public WithEvents lbl_altitude As System.Windows.Forms.Label
    Public WithEvents lbl_quote_number As System.Windows.Forms.Label
    Public WithEvents lbl_owner As System.Windows.Forms.Label
    Public WithEvents lbl_sales_person As System.Windows.Forms.Label
    Public WithEvents lbl_location As System.Windows.Forms.Label
    Public WithEvents lbl_project_name As System.Windows.Forms.Label
    Public WithEvents lbl_voltage As System.Windows.Forms.Label
    Public WithEvents txt_notes As System.Windows.Forms.TextBox
    Public WithEvents txt_contractor As System.Windows.Forms.TextBox
    Public WithEvents txt_engineer As System.Windows.Forms.TextBox
    Public WithEvents txt_altitude As System.Windows.Forms.TextBox
    Public WithEvents txt_quote_number As System.Windows.Forms.TextBox
    Public WithEvents txt_owner As System.Windows.Forms.TextBox
    Public WithEvents txt_sales_person As System.Windows.Forms.TextBox
    Public WithEvents txt_location As System.Windows.Forms.TextBox
    Public WithEvents txt_project_name As System.Windows.Forms.TextBox
    Public WithEvents cbo_voltage As System.Windows.Forms.ComboBox
    Public WithEvents cmd_email_load As System.Windows.Forms.Button
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents _SSTab1_TabPage0 As System.Windows.Forms.TabPage
    Public WithEvents lbl_TAG As System.Windows.Forms.Label
    Public WithEvents lbl_airflow As System.Windows.Forms.Label
    Public WithEvents _SSTab1_TabPage1 As System.Windows.Forms.TabPage
    Public WithEvents lbl_total_list As System.Windows.Forms.Label
    Public WithEvents lbl_total_list_1 As System.Windows.Forms.Label
    Public WithEvents lbl_multiplier As System.Windows.Forms.Label
    Public WithEvents _lbl_Unit_Net_10 As System.Windows.Forms.Label
    Public WithEvents lbl_Unit_Net_1 As System.Windows.Forms.Label
    Public WithEvents lbl_freight As System.Windows.Forms.Label
    Public WithEvents lbl_start_up As System.Windows.Forms.Label
    Public WithEvents lbl_warranty As System.Windows.Forms.Label
    Public WithEvents Line1 As System.Windows.Forms.Label
    Public WithEvents lbl_total_sell_price_1 As System.Windows.Forms.Label
    Public WithEvents lbl_total_sell_price_2 As System.Windows.Forms.Label
    Public WithEvents cmd_save_file As System.Windows.Forms.Button
    Public WithEvents cmd_close_me As System.Windows.Forms.Button
    Public WithEvents printSummaryButton As System.Windows.Forms.Button
    Public WithEvents txt_multiplier As System.Windows.Forms.TextBox
    Public WithEvents txt_freight As System.Windows.Forms.TextBox
    Public WithEvents txt_start_up As System.Windows.Forms.TextBox
    Public WithEvents txt_warranty As System.Windows.Forms.TextBox
    Public WithEvents txt_misc1 As System.Windows.Forms.TextBox
    Public WithEvents txt_misc1_1 As System.Windows.Forms.TextBox
    Public WithEvents txt_misc2_2 As System.Windows.Forms.TextBox
    Public WithEvents txt_misc3_3 As System.Windows.Forms.TextBox
    Public WithEvents txt_misc2 As System.Windows.Forms.TextBox
    Public WithEvents txt_misc3 As System.Windows.Forms.TextBox
    Public WithEvents _SSTab1_TabPage2 As System.Windows.Forms.TabPage
    Public WithEvents SSTab1 As System.Windows.Forms.TabControl
    Public WithEvents ck_selection_1 As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
    Public WithEvents lbl_Unit_Net As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents errProjectInfo As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents txt_notes2 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents btnOpen As System.Windows.Forms.Button
    ''Friend WithEvents dgrC1Projects As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnCalculateCosts As System.Windows.Forms.Button
    Friend WithEvents conProject As System.Data.OleDb.OleDbConnection
    Friend WithEvents dadProject As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents DseProject1 As RaeSolutions.dseProject
    Friend WithEvents dadAirHandler As System.Data.OleDb.OleDbDataAdapter
    ''Friend WithEvents dgrC1AirHandler As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    ''Friend WithEvents dgrC1Summary As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents OleDbSelectCommand2 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand2 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand2 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand2 As System.Data.OleDb.OleDbCommand
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dadSection As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand3 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand3 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand3 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand3 As System.Data.OleDb.OleDbCommand
    Friend WithEvents DseProjectClone As RaeSolutions.dseProject
    Friend WithEvents dadSectionDetails As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents btnNewProject As System.Windows.Forms.Button
    Friend WithEvents btnAddAirHandler As System.Windows.Forms.Button
    Friend WithEvents btnDeleteProject As System.Windows.Forms.Button
    Friend WithEvents OleDbSelectCommand4 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand4 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand4 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand4 As System.Data.OleDb.OleDbCommand
    Friend WithEvents lblJobNotes As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form_project_info))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnAddAirHandler = New System.Windows.Forms.Button
        Me.btnDeleteProject = New System.Windows.Forms.Button
        Me.btnOpen = New System.Windows.Forms.Button
        Me.SSTab1 = New System.Windows.Forms.TabControl
        Me._SSTab1_TabPage0 = New System.Windows.Forms.TabPage
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbl_contractor = New System.Windows.Forms.Label
        Me.lbl_engineer = New System.Windows.Forms.Label
        Me.lbl_altitude = New System.Windows.Forms.Label
        Me.lbl_quote_number = New System.Windows.Forms.Label
        Me.lbl_owner = New System.Windows.Forms.Label
        Me.lbl_sales_person = New System.Windows.Forms.Label
        Me.lbl_location = New System.Windows.Forms.Label
        Me.lbl_project_name = New System.Windows.Forms.Label
        Me.lbl_voltage = New System.Windows.Forms.Label
        Me.txt_contractor = New System.Windows.Forms.TextBox
        Me.DseProject1 = New Rae.RaeSolutions.dseProject
        Me.txt_engineer = New System.Windows.Forms.TextBox
        Me.txt_altitude = New System.Windows.Forms.TextBox
        Me.txt_quote_number = New System.Windows.Forms.TextBox
        Me.txt_owner = New System.Windows.Forms.TextBox
        Me.txt_sales_person = New System.Windows.Forms.TextBox
        Me.txt_location = New System.Windows.Forms.TextBox
        Me.txt_project_name = New System.Windows.Forms.TextBox
        Me.cbo_voltage = New System.Windows.Forms.ComboBox
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.btnNewProject = New System.Windows.Forms.Button
        ''Me.dgrC1Projects = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.cmd_email_load = New System.Windows.Forms.Button
        Me.txt_notes2 = New System.Windows.Forms.TextBox
        Me.txt_notes = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblJobNotes = New System.Windows.Forms.Label
        Me._SSTab1_TabPage1 = New System.Windows.Forms.TabPage
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        ''Me.dgrC1AirHandler = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.lbl_TAG = New System.Windows.Forms.Label
        Me.lbl_airflow = New System.Windows.Forms.Label
        Me._SSTab1_TabPage2 = New System.Windows.Forms.TabPage
        ''Me.dgrC1Summary = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.btnCalculateCosts = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbl_total_list = New System.Windows.Forms.Label
        Me.lbl_total_list_1 = New System.Windows.Forms.Label
        Me.lbl_multiplier = New System.Windows.Forms.Label
        Me._lbl_Unit_Net_10 = New System.Windows.Forms.Label
        Me.lbl_Unit_Net_1 = New System.Windows.Forms.Label
        Me.lbl_freight = New System.Windows.Forms.Label
        Me.lbl_start_up = New System.Windows.Forms.Label
        Me.lbl_warranty = New System.Windows.Forms.Label
        Me.Line1 = New System.Windows.Forms.Label
        Me.lbl_total_sell_price_1 = New System.Windows.Forms.Label
        Me.lbl_total_sell_price_2 = New System.Windows.Forms.Label
        Me.printSummaryButton = New System.Windows.Forms.Button
        Me.txt_multiplier = New System.Windows.Forms.TextBox
        Me.txt_freight = New System.Windows.Forms.TextBox
        Me.txt_start_up = New System.Windows.Forms.TextBox
        Me.txt_warranty = New System.Windows.Forms.TextBox
        Me.txt_misc1 = New System.Windows.Forms.TextBox
        Me.txt_misc1_1 = New System.Windows.Forms.TextBox
        Me.txt_misc2_2 = New System.Windows.Forms.TextBox
        Me.txt_misc3_3 = New System.Windows.Forms.TextBox
        Me.txt_misc2 = New System.Windows.Forms.TextBox
        Me.txt_misc3 = New System.Windows.Forms.TextBox
        Me.cmd_save_file = New System.Windows.Forms.Button
        Me.cmd_close_me = New System.Windows.Forms.Button
        Me.ck_selection_1 = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(Me.components)
        Me.lbl_Unit_Net = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.errProjectInfo = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.conProject = New System.Data.OleDb.OleDbConnection
        Me.dadProject = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbDeleteCommand1 = New System.Data.OleDb.OleDbCommand
        Me.OleDbInsertCommand1 = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCommand1 = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand1 = New System.Data.OleDb.OleDbCommand
        Me.dadAirHandler = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbDeleteCommand2 = New System.Data.OleDb.OleDbCommand
        Me.OleDbInsertCommand2 = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCommand2 = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand2 = New System.Data.OleDb.OleDbCommand
        Me.Button1 = New System.Windows.Forms.Button
        Me.dadSection = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbDeleteCommand3 = New System.Data.OleDb.OleDbCommand
        Me.OleDbInsertCommand3 = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCommand3 = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand3 = New System.Data.OleDb.OleDbCommand
        Me.DseProjectClone = New Rae.RaeSolutions.dseProject
        Me.dadSectionDetails = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbDeleteCommand4 = New System.Data.OleDb.OleDbCommand
        Me.OleDbInsertCommand4 = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCommand4 = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand4 = New System.Data.OleDb.OleDbCommand
        Me.SSTab1.SuspendLayout()
        Me._SSTab1_TabPage0.SuspendLayout()
        CType(Me.DseProject1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame2.SuspendLayout()
        ''CType(Me.dgrC1Projects, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._SSTab1_TabPage1.SuspendLayout()
        ''CType(Me.dgrC1AirHandler, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._SSTab1_TabPage2.SuspendLayout()
        ''CType(Me.dgrC1Summary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ck_selection_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl_Unit_Net, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errProjectInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DseProjectClone, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAddAirHandler
        '
        Me.btnAddAirHandler.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAddAirHandler.Location = New System.Drawing.Point(20, 280)
        Me.btnAddAirHandler.Name = "btnAddAirHandler"
        Me.btnAddAirHandler.Size = New System.Drawing.Size(98, 23)
        Me.btnAddAirHandler.TabIndex = 246
        Me.btnAddAirHandler.Text = "Add Air Handler"
        Me.ToolTip1.SetToolTip(Me.btnAddAirHandler, "Adds an air handler to the project.")
        '
        'btnDeleteProject
        '
        Me.btnDeleteProject.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnDeleteProject.Location = New System.Drawing.Point(12, 230)
        Me.btnDeleteProject.Name = "btnDeleteProject"
        Me.btnDeleteProject.Size = New System.Drawing.Size(80, 22)
        Me.btnDeleteProject.TabIndex = 259
        Me.btnDeleteProject.Text = "Delete"
        Me.ToolTip1.SetToolTip(Me.btnDeleteProject, "Permanently deletes selected project")
        '
        'btnOpen
        '
        Me.btnOpen.BackColor = System.Drawing.SystemColors.Control
        Me.btnOpen.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOpen.Enabled = False
        Me.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnOpen.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpen.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOpen.Location = New System.Drawing.Point(110, 24)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOpen.Size = New System.Drawing.Size(90, 22)
        Me.btnOpen.TabIndex = 209
        Me.btnOpen.Text = "Open Project"
        Me.ToolTip1.SetToolTip(Me.btnOpen, "Opens selected project")
        Me.btnOpen.UseVisualStyleBackColor = False
        '
        'SSTab1
        '
        Me.SSTab1.Controls.Add(Me._SSTab1_TabPage0)
        Me.SSTab1.Controls.Add(Me._SSTab1_TabPage1)
        Me.SSTab1.Controls.Add(Me._SSTab1_TabPage2)
        Me.SSTab1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSTab1.ItemSize = New System.Drawing.Size(46, 21)
        Me.SSTab1.Location = New System.Drawing.Point(6, 6)
        Me.SSTab1.Name = "SSTab1"
        Me.SSTab1.SelectedIndex = 0
        Me.SSTab1.Size = New System.Drawing.Size(736, 352)
        Me.SSTab1.TabIndex = 0
        '
        '_SSTab1_TabPage0
        '
        Me._SSTab1_TabPage0.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me._SSTab1_TabPage0.Controls.Add(Me.Label2)
        Me._SSTab1_TabPage0.Controls.Add(Me.lbl_contractor)
        Me._SSTab1_TabPage0.Controls.Add(Me.lbl_engineer)
        Me._SSTab1_TabPage0.Controls.Add(Me.lbl_altitude)
        Me._SSTab1_TabPage0.Controls.Add(Me.lbl_quote_number)
        Me._SSTab1_TabPage0.Controls.Add(Me.lbl_owner)
        Me._SSTab1_TabPage0.Controls.Add(Me.lbl_sales_person)
        Me._SSTab1_TabPage0.Controls.Add(Me.lbl_location)
        Me._SSTab1_TabPage0.Controls.Add(Me.lbl_project_name)
        Me._SSTab1_TabPage0.Controls.Add(Me.lbl_voltage)
        Me._SSTab1_TabPage0.Controls.Add(Me.txt_contractor)
        Me._SSTab1_TabPage0.Controls.Add(Me.txt_engineer)
        Me._SSTab1_TabPage0.Controls.Add(Me.txt_altitude)
        Me._SSTab1_TabPage0.Controls.Add(Me.txt_quote_number)
        Me._SSTab1_TabPage0.Controls.Add(Me.txt_owner)
        Me._SSTab1_TabPage0.Controls.Add(Me.txt_sales_person)
        Me._SSTab1_TabPage0.Controls.Add(Me.txt_location)
        Me._SSTab1_TabPage0.Controls.Add(Me.txt_project_name)
        Me._SSTab1_TabPage0.Controls.Add(Me.cbo_voltage)
        Me._SSTab1_TabPage0.Controls.Add(Me.Frame2)
        Me._SSTab1_TabPage0.Controls.Add(Me.txt_notes2)
        Me._SSTab1_TabPage0.Controls.Add(Me.txt_notes)
        Me._SSTab1_TabPage0.Controls.Add(Me.Label1)
        Me._SSTab1_TabPage0.Controls.Add(Me.lblJobNotes)
        Me._SSTab1_TabPage0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._SSTab1_TabPage0.Location = New System.Drawing.Point(4, 25)
        Me._SSTab1_TabPage0.Name = "_SSTab1_TabPage0"
        Me._SSTab1_TabPage0.Size = New System.Drawing.Size(728, 323)
        Me._SSTab1_TabPage0.TabIndex = 0
        Me._SSTab1_TabPage0.Text = "Project"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(18, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(238, 28)
        Me.Label2.TabIndex = 207
        Me.Label2.Text = "Click 'New Project' to add a new project."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_contractor
        '
        Me.lbl_contractor.BackColor = System.Drawing.Color.Transparent
        Me.lbl_contractor.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_contractor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_contractor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_contractor.Location = New System.Drawing.Point(268, 132)
        Me.lbl_contractor.Name = "lbl_contractor"
        Me.lbl_contractor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_contractor.Size = New System.Drawing.Size(80, 17)
        Me.lbl_contractor.TabIndex = 13
        Me.lbl_contractor.Text = "Contractor:"
        Me.lbl_contractor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_engineer
        '
        Me.lbl_engineer.BackColor = System.Drawing.Color.Transparent
        Me.lbl_engineer.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_engineer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_engineer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_engineer.Location = New System.Drawing.Point(504, 78)
        Me.lbl_engineer.Name = "lbl_engineer"
        Me.lbl_engineer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_engineer.Size = New System.Drawing.Size(68, 17)
        Me.lbl_engineer.TabIndex = 14
        Me.lbl_engineer.Text = "Engineer:"
        Me.lbl_engineer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_altitude
        '
        Me.lbl_altitude.BackColor = System.Drawing.Color.Transparent
        Me.lbl_altitude.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_altitude.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_altitude.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_altitude.Location = New System.Drawing.Point(504, 50)
        Me.lbl_altitude.Name = "lbl_altitude"
        Me.lbl_altitude.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_altitude.Size = New System.Drawing.Size(68, 17)
        Me.lbl_altitude.TabIndex = 15
        Me.lbl_altitude.Text = "Altitude (ft):"
        Me.lbl_altitude.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_quote_number
        '
        Me.lbl_quote_number.BackColor = System.Drawing.Color.Transparent
        Me.lbl_quote_number.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_quote_number.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_quote_number.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_quote_number.Location = New System.Drawing.Point(504, 20)
        Me.lbl_quote_number.Name = "lbl_quote_number"
        Me.lbl_quote_number.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_quote_number.Size = New System.Drawing.Size(68, 17)
        Me.lbl_quote_number.TabIndex = 17
        Me.lbl_quote_number.Text = "Quote #:"
        Me.lbl_quote_number.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_owner
        '
        Me.lbl_owner.BackColor = System.Drawing.Color.Transparent
        Me.lbl_owner.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_owner.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_owner.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_owner.Location = New System.Drawing.Point(268, 104)
        Me.lbl_owner.Name = "lbl_owner"
        Me.lbl_owner.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_owner.Size = New System.Drawing.Size(80, 17)
        Me.lbl_owner.TabIndex = 18
        Me.lbl_owner.Text = "Owner:"
        Me.lbl_owner.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_sales_person
        '
        Me.lbl_sales_person.BackColor = System.Drawing.Color.Transparent
        Me.lbl_sales_person.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_sales_person.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_sales_person.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_sales_person.Location = New System.Drawing.Point(268, 76)
        Me.lbl_sales_person.Name = "lbl_sales_person"
        Me.lbl_sales_person.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_sales_person.Size = New System.Drawing.Size(80, 17)
        Me.lbl_sales_person.TabIndex = 19
        Me.lbl_sales_person.Text = "Sales Person:"
        Me.lbl_sales_person.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_location
        '
        Me.lbl_location.BackColor = System.Drawing.Color.Transparent
        Me.lbl_location.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_location.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_location.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_location.Location = New System.Drawing.Point(268, 48)
        Me.lbl_location.Name = "lbl_location"
        Me.lbl_location.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_location.Size = New System.Drawing.Size(80, 17)
        Me.lbl_location.TabIndex = 20
        Me.lbl_location.Text = "Location:"
        Me.lbl_location.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_project_name
        '
        Me.lbl_project_name.BackColor = System.Drawing.Color.Transparent
        Me.lbl_project_name.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_project_name.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_project_name.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_project_name.Location = New System.Drawing.Point(268, 20)
        Me.lbl_project_name.Name = "lbl_project_name"
        Me.lbl_project_name.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_project_name.Size = New System.Drawing.Size(80, 17)
        Me.lbl_project_name.TabIndex = 21
        Me.lbl_project_name.Text = "Project Name:"
        Me.lbl_project_name.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_voltage
        '
        Me.lbl_voltage.BackColor = System.Drawing.Color.Transparent
        Me.lbl_voltage.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_voltage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_voltage.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_voltage.Location = New System.Drawing.Point(504, 106)
        Me.lbl_voltage.Name = "lbl_voltage"
        Me.lbl_voltage.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_voltage.Size = New System.Drawing.Size(68, 17)
        Me.lbl_voltage.TabIndex = 151
        Me.lbl_voltage.Text = "Voltage:"
        Me.lbl_voltage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_contractor
        '
        Me.txt_contractor.AcceptsReturn = True
        Me.txt_contractor.BackColor = System.Drawing.SystemColors.Window
        Me.txt_contractor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_contractor.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DseProject1, "SavedProject.Contractor", True))
        Me.txt_contractor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_contractor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_contractor.Location = New System.Drawing.Point(354, 132)
        Me.txt_contractor.MaxLength = 0
        Me.txt_contractor.Name = "txt_contractor"
        Me.txt_contractor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_contractor.Size = New System.Drawing.Size(132, 21)
        Me.txt_contractor.TabIndex = 5
        '
        'DseProject1
        '
        Me.DseProject1.DataSetName = "dseProject"
        Me.DseProject1.Locale = New System.Globalization.CultureInfo("en-US")
        Me.DseProject1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txt_engineer
        '
        Me.txt_engineer.AcceptsReturn = True
        Me.txt_engineer.BackColor = System.Drawing.SystemColors.Window
        Me.txt_engineer.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_engineer.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DseProject1, "SavedProject.Engineer", True))
        Me.txt_engineer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_engineer.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_engineer.Location = New System.Drawing.Point(578, 76)
        Me.txt_engineer.MaxLength = 0
        Me.txt_engineer.Name = "txt_engineer"
        Me.txt_engineer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_engineer.Size = New System.Drawing.Size(132, 21)
        Me.txt_engineer.TabIndex = 9
        '
        'txt_altitude
        '
        Me.txt_altitude.AcceptsReturn = True
        Me.txt_altitude.BackColor = System.Drawing.SystemColors.Window
        Me.txt_altitude.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_altitude.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DseProject1, "SavedProject.Altitude", True))
        Me.txt_altitude.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_altitude.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_altitude.Location = New System.Drawing.Point(578, 48)
        Me.txt_altitude.MaxLength = 0
        Me.txt_altitude.Name = "txt_altitude"
        Me.txt_altitude.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_altitude.Size = New System.Drawing.Size(132, 21)
        Me.txt_altitude.TabIndex = 8
        Me.txt_altitude.Tag = "altitude"
        Me.txt_altitude.Text = "0"
        '
        'txt_quote_number
        '
        Me.txt_quote_number.AcceptsReturn = True
        Me.txt_quote_number.BackColor = System.Drawing.SystemColors.Window
        Me.txt_quote_number.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_quote_number.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DseProject1, "SavedProject.QuoteNumber", True))
        Me.txt_quote_number.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_quote_number.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_quote_number.Location = New System.Drawing.Point(578, 18)
        Me.txt_quote_number.MaxLength = 0
        Me.txt_quote_number.Name = "txt_quote_number"
        Me.txt_quote_number.ReadOnly = True
        Me.txt_quote_number.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_quote_number.Size = New System.Drawing.Size(132, 21)
        Me.txt_quote_number.TabIndex = 6
        Me.txt_quote_number.Tag = "Quote Number"
        '
        'txt_owner
        '
        Me.txt_owner.AcceptsReturn = True
        Me.txt_owner.BackColor = System.Drawing.SystemColors.Window
        Me.txt_owner.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_owner.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DseProject1, "SavedProject.Owner", True))
        Me.txt_owner.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_owner.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_owner.Location = New System.Drawing.Point(354, 104)
        Me.txt_owner.MaxLength = 0
        Me.txt_owner.Name = "txt_owner"
        Me.txt_owner.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_owner.Size = New System.Drawing.Size(132, 21)
        Me.txt_owner.TabIndex = 4
        '
        'txt_sales_person
        '
        Me.txt_sales_person.AcceptsReturn = True
        Me.txt_sales_person.BackColor = System.Drawing.SystemColors.Window
        Me.txt_sales_person.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_sales_person.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DseProject1, "SavedProject.SalesPerson", True))
        Me.txt_sales_person.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_sales_person.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_sales_person.Location = New System.Drawing.Point(354, 76)
        Me.txt_sales_person.MaxLength = 0
        Me.txt_sales_person.Name = "txt_sales_person"
        Me.txt_sales_person.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_sales_person.Size = New System.Drawing.Size(132, 21)
        Me.txt_sales_person.TabIndex = 3
        '
        'txt_location
        '
        Me.txt_location.AcceptsReturn = True
        Me.txt_location.BackColor = System.Drawing.SystemColors.Window
        Me.txt_location.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_location.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DseProject1, "SavedProject.Location", True))
        Me.txt_location.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_location.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_location.Location = New System.Drawing.Point(354, 48)
        Me.txt_location.MaxLength = 0
        Me.txt_location.Name = "txt_location"
        Me.txt_location.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_location.Size = New System.Drawing.Size(132, 21)
        Me.txt_location.TabIndex = 2
        '
        'txt_project_name
        '
        Me.txt_project_name.AcceptsReturn = True
        Me.txt_project_name.BackColor = System.Drawing.SystemColors.Window
        Me.txt_project_name.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_project_name.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DseProject1, "SavedProject.ProjectName", True))
        Me.txt_project_name.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_project_name.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_project_name.Location = New System.Drawing.Point(354, 18)
        Me.txt_project_name.MaxLength = 0
        Me.txt_project_name.Name = "txt_project_name"
        Me.txt_project_name.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_project_name.Size = New System.Drawing.Size(132, 21)
        Me.txt_project_name.TabIndex = 1
        Me.txt_project_name.Tag = "Project Name"
        '
        'cbo_voltage
        '
        Me.cbo_voltage.BackColor = System.Drawing.SystemColors.Window
        Me.cbo_voltage.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbo_voltage.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DseProject1, "SavedProject.Voltage", True))
        Me.cbo_voltage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_voltage.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbo_voltage.Items.AddRange(New Object() {"460", "230", "208"})
        Me.cbo_voltage.Location = New System.Drawing.Point(578, 104)
        Me.cbo_voltage.Name = "cbo_voltage"
        Me.cbo_voltage.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbo_voltage.Size = New System.Drawing.Size(65, 21)
        Me.cbo_voltage.TabIndex = 10
        Me.cbo_voltage.Text = "460"
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Frame2.Controls.Add(Me.btnDeleteProject)
        Me.Frame2.Controls.Add(Me.btnNewProject)
        ''Me.Frame2.Controls.Add(Me.dgrC1Projects)
        Me.Frame2.Controls.Add(Me.btnOpen)
        Me.Frame2.Controls.Add(Me.cmd_email_load)
        Me.Frame2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(18, 46)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(240, 264)
        Me.Frame2.TabIndex = 206
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Manage Projects"
        '
        'btnNewProject
        '
        Me.btnNewProject.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnNewProject.Location = New System.Drawing.Point(14, 24)
        Me.btnNewProject.Name = "btnNewProject"
        Me.btnNewProject.Size = New System.Drawing.Size(90, 22)
        Me.btnNewProject.TabIndex = 258
        Me.btnNewProject.Text = "New Project..."
        '''
        '''dgrC1Projects
        '''
        ''Me.dgrC1Projects.AllowColMove = False
        ''Me.dgrC1Projects.AllowColSelect = False
        ''Me.dgrC1Projects.AllowUpdate = False
        ''Me.dgrC1Projects.AllowUpdateOnBlur = False
        ''Me.dgrC1Projects.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
        ''            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ''Me.dgrC1Projects.CaptionHeight = 17
        ''Me.dgrC1Projects.CellTips = C1.Win.C1TrueDBGrid.CellTipEnum.Floating
        ''Me.dgrC1Projects.GroupByCaption = "Drag a column header here to group by that column"
        ''Me.dgrC1Projects.Images.Add(CType(resources.GetObject("dgrC1Projects.Images"), System.Drawing.Image))
        ''Me.dgrC1Projects.Location = New System.Drawing.Point(12, 52)
        ''Me.dgrC1Projects.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
        ''Me.dgrC1Projects.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
        ''Me.dgrC1Projects.Name = "dgrC1Projects"
        ''Me.dgrC1Projects.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        ''Me.dgrC1Projects.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        ''Me.dgrC1Projects.PreviewInfo.ZoomFactor = 75
        ''Me.dgrC1Projects.PrintInfo.PageSettings = CType(resources.GetObject("dgrC1Projects.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        ''Me.dgrC1Projects.RecordSelectors = False
        ''Me.dgrC1Projects.RecordSelectorWidth = 1
        ''Me.dgrC1Projects.RowHeight = 22
        ''Me.dgrC1Projects.Size = New System.Drawing.Size(212, 172)
        ''Me.dgrC1Projects.TabIndex = 218
        ''Me.dgrC1Projects.TabStop = False
        ''Me.dgrC1Projects.Text = "Load Project"
        ''Me.dgrC1Projects.PropBag = resources.GetString("dgrC1Projects.PropBag")
        '
        'cmd_email_load
        '
        Me.cmd_email_load.BackColor = System.Drawing.Color.Red
        Me.cmd_email_load.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmd_email_load.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmd_email_load.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_email_load.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_email_load.Location = New System.Drawing.Point(92, 54)
        Me.cmd_email_load.Name = "cmd_email_load"
        Me.cmd_email_load.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmd_email_load.Size = New System.Drawing.Size(116, 23)
        Me.cmd_email_load.TabIndex = 256
        Me.cmd_email_load.Text = "Load Email Projects"
        Me.cmd_email_load.UseVisualStyleBackColor = False
        Me.cmd_email_load.Visible = False
        '
        'txt_notes2
        '
        Me.txt_notes2.AcceptsReturn = True
        Me.txt_notes2.BackColor = System.Drawing.SystemColors.Window
        Me.txt_notes2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_notes2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DseProject1, "SavedProject.JobNotes", True))
        Me.txt_notes2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_notes2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_notes2.Location = New System.Drawing.Point(278, 262)
        Me.txt_notes2.MaxLength = 0
        Me.txt_notes2.Multiline = True
        Me.txt_notes2.Name = "txt_notes2"
        Me.txt_notes2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_notes2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_notes2.Size = New System.Drawing.Size(432, 48)
        Me.txt_notes2.TabIndex = 12
        '
        'txt_notes
        '
        Me.txt_notes.AcceptsReturn = True
        Me.txt_notes.BackColor = System.Drawing.SystemColors.Window
        Me.txt_notes.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_notes.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DseProject1, "SavedProject.CustomerNotes", True))
        Me.txt_notes.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_notes.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_notes.Location = New System.Drawing.Point(278, 186)
        Me.txt_notes.MaxLength = 0
        Me.txt_notes.Multiline = True
        Me.txt_notes.Name = "txt_notes"
        Me.txt_notes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_notes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_notes.Size = New System.Drawing.Size(432, 48)
        Me.txt_notes.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(282, 162)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 23)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Customer Notes:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblJobNotes
        '
        Me.lblJobNotes.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJobNotes.Location = New System.Drawing.Point(282, 238)
        Me.lblJobNotes.Name = "lblJobNotes"
        Me.lblJobNotes.Size = New System.Drawing.Size(100, 23)
        Me.lblJobNotes.TabIndex = 13
        Me.lblJobNotes.Text = "Job Notes:"
        Me.lblJobNotes.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        '_SSTab1_TabPage1
        '
        Me._SSTab1_TabPage1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me._SSTab1_TabPage1.Controls.Add(Me.Label3)
        Me._SSTab1_TabPage1.Controls.Add(Me.btnAddAirHandler)
        Me._SSTab1_TabPage1.Controls.Add(Me.GroupBox2)
        Me._SSTab1_TabPage1.Controls.Add(Me.Label5)
        ''Me._SSTab1_TabPage1.Controls.Add(Me.dgrC1AirHandler)
        Me._SSTab1_TabPage1.Controls.Add(Me.lbl_TAG)
        Me._SSTab1_TabPage1.Controls.Add(Me.lbl_airflow)
        Me._SSTab1_TabPage1.Location = New System.Drawing.Point(4, 25)
        Me._SSTab1_TabPage1.Name = "_SSTab1_TabPage1"
        Me._SSTab1_TabPage1.Size = New System.Drawing.Size(728, 323)
        Me._SSTab1_TabPage1.TabIndex = 1
        Me._SSTab1_TabPage1.Text = "Unit"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(20, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(556, 20)
        Me.Label3.TabIndex = 248
        Me.Label3.Text = "Then enter the data in the table below, and click the 'Select Model' button."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(10, 56)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(708, 2)
        Me.GroupBox2.TabIndex = 245
        Me.GroupBox2.TabStop = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(20, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(678, 20)
        Me.Label5.TabIndex = 244
        Me.Label5.Text = "Click the 'Add Air Handler' button at the bottom, left portion of the tab."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '''
        '''dgrC1AirHandler
        '''
        ''Me.dgrC1AirHandler.AllowDelete = True
        ''Me.dgrC1AirHandler.AllowSort = False
        ''Me.dgrC1AirHandler.CaptionHeight = 17
        ''Me.dgrC1AirHandler.DataSource = Me.DseProject1.SavedAirHandler
        ''Me.dgrC1AirHandler.GroupByCaption = "Drag a column header here to group by that column"
        ''Me.dgrC1AirHandler.Images.Add(CType(resources.GetObject("dgrC1AirHandler.Images"), System.Drawing.Image))
        ''Me.dgrC1AirHandler.Location = New System.Drawing.Point(20, 68)
        ''Me.dgrC1AirHandler.Name = "dgrC1AirHandler"
        ''Me.dgrC1AirHandler.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        ''Me.dgrC1AirHandler.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        ''Me.dgrC1AirHandler.PreviewInfo.ZoomFactor = 75
        ''Me.dgrC1AirHandler.PrintInfo.PageSettings = CType(resources.GetObject("dgrC1AirHandler.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        ''Me.dgrC1AirHandler.RowHeight = 22
        ''Me.dgrC1AirHandler.Size = New System.Drawing.Size(612, 210)
        ''Me.dgrC1AirHandler.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        ''Me.dgrC1AirHandler.TabIndex = 243
        ''Me.dgrC1AirHandler.Text = "Air Handler Selection Criteria"
        ''Me.dgrC1AirHandler.PropBag = resources.GetString("dgrC1AirHandler.PropBag")
        '
        'lbl_TAG
        '
        Me.lbl_TAG.BackColor = System.Drawing.Color.Transparent
        Me.lbl_TAG.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_TAG.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TAG.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_TAG.Location = New System.Drawing.Point(38, 12)
        Me.lbl_TAG.Name = "lbl_TAG"
        Me.lbl_TAG.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_TAG.Size = New System.Drawing.Size(56, 22)
        Me.lbl_TAG.TabIndex = 127
        Me.lbl_TAG.Text = "Tag"
        Me.lbl_TAG.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lbl_TAG.Visible = False
        '
        'lbl_airflow
        '
        Me.lbl_airflow.BackColor = System.Drawing.Color.Transparent
        Me.lbl_airflow.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_airflow.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_airflow.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_airflow.Location = New System.Drawing.Point(122, 12)
        Me.lbl_airflow.Name = "lbl_airflow"
        Me.lbl_airflow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_airflow.Size = New System.Drawing.Size(89, 22)
        Me.lbl_airflow.TabIndex = 126
        Me.lbl_airflow.Text = "Airflow (CFM)"
        Me.lbl_airflow.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lbl_airflow.Visible = False
        '
        '_SSTab1_TabPage2
        '
        Me._SSTab1_TabPage2.BackColor = System.Drawing.SystemColors.ControlLightLight
        ''Me._SSTab1_TabPage2.Controls.Add(Me.dgrC1Summary)
        Me._SSTab1_TabPage2.Controls.Add(Me.btnCalculateCosts)
        Me._SSTab1_TabPage2.Controls.Add(Me.GroupBox1)
        Me._SSTab1_TabPage2.Controls.Add(Me.lbl_total_list)
        Me._SSTab1_TabPage2.Controls.Add(Me.lbl_total_list_1)
        Me._SSTab1_TabPage2.Controls.Add(Me.lbl_multiplier)
        Me._SSTab1_TabPage2.Controls.Add(Me._lbl_Unit_Net_10)
        Me._SSTab1_TabPage2.Controls.Add(Me.lbl_Unit_Net_1)
        Me._SSTab1_TabPage2.Controls.Add(Me.lbl_freight)
        Me._SSTab1_TabPage2.Controls.Add(Me.lbl_start_up)
        Me._SSTab1_TabPage2.Controls.Add(Me.lbl_warranty)
        Me._SSTab1_TabPage2.Controls.Add(Me.Line1)
        Me._SSTab1_TabPage2.Controls.Add(Me.lbl_total_sell_price_1)
        Me._SSTab1_TabPage2.Controls.Add(Me.lbl_total_sell_price_2)
        Me._SSTab1_TabPage2.Controls.Add(Me.printSummaryButton)
        Me._SSTab1_TabPage2.Controls.Add(Me.txt_multiplier)
        Me._SSTab1_TabPage2.Controls.Add(Me.txt_freight)
        Me._SSTab1_TabPage2.Controls.Add(Me.txt_start_up)
        Me._SSTab1_TabPage2.Controls.Add(Me.txt_warranty)
        Me._SSTab1_TabPage2.Controls.Add(Me.txt_misc1)
        Me._SSTab1_TabPage2.Controls.Add(Me.txt_misc1_1)
        Me._SSTab1_TabPage2.Controls.Add(Me.txt_misc2_2)
        Me._SSTab1_TabPage2.Controls.Add(Me.txt_misc3_3)
        Me._SSTab1_TabPage2.Controls.Add(Me.txt_misc2)
        Me._SSTab1_TabPage2.Controls.Add(Me.txt_misc3)
        Me._SSTab1_TabPage2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._SSTab1_TabPage2.Location = New System.Drawing.Point(4, 25)
        Me._SSTab1_TabPage2.Name = "_SSTab1_TabPage2"
        Me._SSTab1_TabPage2.Size = New System.Drawing.Size(728, 323)
        Me._SSTab1_TabPage2.TabIndex = 2
        Me._SSTab1_TabPage2.Text = "Summary"
        '''
        '''dgrC1Summary
        '''
        ''Me.dgrC1Summary.AllowColMove = False
        ''Me.dgrC1Summary.AllowColSelect = False
        ''Me.dgrC1Summary.AllowRowSelect = False
        ''Me.dgrC1Summary.AllowSort = False
        ''Me.dgrC1Summary.AllowUpdate = False
        ''Me.dgrC1Summary.AllowUpdateOnBlur = False
        ''Me.dgrC1Summary.CaptionHeight = 17
        ''Me.dgrC1Summary.DataSource = Me.DseProject1.SavedAirHandler
        ''Me.dgrC1Summary.GroupByCaption = "Drag a column header here to group by that column"
        ''Me.dgrC1Summary.Images.Add(CType(resources.GetObject("dgrC1Summary.Images"), System.Drawing.Image))
        ''Me.dgrC1Summary.Location = New System.Drawing.Point(20, 20)
        ''Me.dgrC1Summary.Name = "dgrC1Summary"
        ''Me.dgrC1Summary.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        ''Me.dgrC1Summary.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        ''Me.dgrC1Summary.PreviewInfo.ZoomFactor = 75
        ''Me.dgrC1Summary.PrintInfo.PageSettings = CType(resources.GetObject("dgrC1Summary.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        ''Me.dgrC1Summary.RowHeight = 22
        ''Me.dgrC1Summary.Size = New System.Drawing.Size(493, 240)
        ''Me.dgrC1Summary.TabIndex = 279
        ''Me.dgrC1Summary.Text = "C1TrueDBGrid2"
        ''Me.dgrC1Summary.PropBag = resources.GetString("dgrC1Summary.PropBag")
        '
        'btnCalculateCosts
        '
        Me.btnCalculateCosts.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCalculateCosts.Location = New System.Drawing.Point(616, 290)
        Me.btnCalculateCosts.Name = "btnCalculateCosts"
        Me.btnCalculateCosts.Size = New System.Drawing.Size(96, 22)
        Me.btnCalculateCosts.TabIndex = 278
        Me.btnCalculateCosts.Text = "Calculate Prices"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(8, 274)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(712, 8)
        Me.GroupBox1.TabIndex = 277
        Me.GroupBox1.TabStop = False
        '
        'lbl_total_list
        '
        Me.lbl_total_list.BackColor = System.Drawing.Color.Transparent
        Me.lbl_total_list.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_total_list.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total_list.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_total_list.Location = New System.Drawing.Point(532, 26)
        Me.lbl_total_list.Name = "lbl_total_list"
        Me.lbl_total_list.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_total_list.Size = New System.Drawing.Size(90, 23)
        Me.lbl_total_list.TabIndex = 250
        Me.lbl_total_list.Text = "Total List Price:"
        Me.lbl_total_list.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_total_list_1
        '
        Me.lbl_total_list_1.BackColor = System.Drawing.Color.Transparent
        Me.lbl_total_list_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_total_list_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total_list_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_total_list_1.Location = New System.Drawing.Point(630, 26)
        Me.lbl_total_list_1.Name = "lbl_total_list_1"
        Me.lbl_total_list_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_total_list_1.Size = New System.Drawing.Size(78, 23)
        Me.lbl_total_list_1.TabIndex = 251
        Me.lbl_total_list_1.Text = "0"
        Me.lbl_total_list_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_multiplier
        '
        Me.lbl_multiplier.BackColor = System.Drawing.Color.Transparent
        Me.lbl_multiplier.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_multiplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_multiplier.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_multiplier.Location = New System.Drawing.Point(532, 48)
        Me.lbl_multiplier.Name = "lbl_multiplier"
        Me.lbl_multiplier.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_multiplier.Size = New System.Drawing.Size(90, 23)
        Me.lbl_multiplier.TabIndex = 252
        Me.lbl_multiplier.Text = "Multiplier:"
        Me.lbl_multiplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_lbl_Unit_Net_10
        '
        Me._lbl_Unit_Net_10.BackColor = System.Drawing.Color.Transparent
        Me._lbl_Unit_Net_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_Unit_Net_10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl_Unit_Net_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Unit_Net.SetIndex(Me._lbl_Unit_Net_10, CType(10, Short))
        Me._lbl_Unit_Net_10.Location = New System.Drawing.Point(532, 72)
        Me._lbl_Unit_Net_10.Name = "_lbl_Unit_Net_10"
        Me._lbl_Unit_Net_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_Unit_Net_10.Size = New System.Drawing.Size(90, 23)
        Me._lbl_Unit_Net_10.TabIndex = 258
        Me._lbl_Unit_Net_10.Text = "Net Price:"
        Me._lbl_Unit_Net_10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Unit_Net_1
        '
        Me.lbl_Unit_Net_1.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Unit_Net_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_Unit_Net_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Unit_Net_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Unit_Net_1.Location = New System.Drawing.Point(630, 72)
        Me.lbl_Unit_Net_1.Name = "lbl_Unit_Net_1"
        Me.lbl_Unit_Net_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_Unit_Net_1.Size = New System.Drawing.Size(78, 23)
        Me.lbl_Unit_Net_1.TabIndex = 259
        Me.lbl_Unit_Net_1.Text = "0"
        Me.lbl_Unit_Net_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_freight
        '
        Me.lbl_freight.BackColor = System.Drawing.Color.Transparent
        Me.lbl_freight.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_freight.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_freight.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_freight.Location = New System.Drawing.Point(532, 94)
        Me.lbl_freight.Name = "lbl_freight"
        Me.lbl_freight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_freight.Size = New System.Drawing.Size(90, 23)
        Me.lbl_freight.TabIndex = 260
        Me.lbl_freight.Text = "Freight:"
        Me.lbl_freight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_start_up
        '
        Me.lbl_start_up.BackColor = System.Drawing.Color.Transparent
        Me.lbl_start_up.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_start_up.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_start_up.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_start_up.Location = New System.Drawing.Point(532, 118)
        Me.lbl_start_up.Name = "lbl_start_up"
        Me.lbl_start_up.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_start_up.Size = New System.Drawing.Size(90, 23)
        Me.lbl_start_up.TabIndex = 261
        Me.lbl_start_up.Text = "Start-up:"
        Me.lbl_start_up.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_warranty
        '
        Me.lbl_warranty.BackColor = System.Drawing.Color.Transparent
        Me.lbl_warranty.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_warranty.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_warranty.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_warranty.Location = New System.Drawing.Point(532, 140)
        Me.lbl_warranty.Name = "lbl_warranty"
        Me.lbl_warranty.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_warranty.Size = New System.Drawing.Size(90, 23)
        Me.lbl_warranty.TabIndex = 262
        Me.lbl_warranty.Text = "Warranty:"
        Me.lbl_warranty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line1.Location = New System.Drawing.Point(-4552, 248)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(262, 1)
        Me.Line1.TabIndex = 263
        '
        'lbl_total_sell_price_1
        '
        Me.lbl_total_sell_price_1.BackColor = System.Drawing.Color.Transparent
        Me.lbl_total_sell_price_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_total_sell_price_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total_sell_price_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_total_sell_price_1.Location = New System.Drawing.Point(532, 238)
        Me.lbl_total_sell_price_1.Name = "lbl_total_sell_price_1"
        Me.lbl_total_sell_price_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_total_sell_price_1.Size = New System.Drawing.Size(90, 23)
        Me.lbl_total_sell_price_1.TabIndex = 272
        Me.lbl_total_sell_price_1.Text = "Total Sell Price:"
        Me.lbl_total_sell_price_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_total_sell_price_2
        '
        Me.lbl_total_sell_price_2.BackColor = System.Drawing.Color.Transparent
        Me.lbl_total_sell_price_2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_total_sell_price_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total_sell_price_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_total_sell_price_2.Location = New System.Drawing.Point(630, 238)
        Me.lbl_total_sell_price_2.Name = "lbl_total_sell_price_2"
        Me.lbl_total_sell_price_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_total_sell_price_2.Size = New System.Drawing.Size(78, 23)
        Me.lbl_total_sell_price_2.TabIndex = 273
        Me.lbl_total_sell_price_2.Text = "0"
        Me.lbl_total_sell_price_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'printSummaryButton
        '
        Me.printSummaryButton.BackColor = System.Drawing.SystemColors.Control
        Me.printSummaryButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.printSummaryButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.printSummaryButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.printSummaryButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.printSummaryButton.Location = New System.Drawing.Point(514, 290)
        Me.printSummaryButton.Name = "printSummaryButton"
        Me.printSummaryButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.printSummaryButton.Size = New System.Drawing.Size(96, 22)
        Me.printSummaryButton.TabIndex = 238
        Me.printSummaryButton.Text = "Summary Report"
        Me.printSummaryButton.UseVisualStyleBackColor = False
        '
        'txt_multiplier
        '
        Me.txt_multiplier.AcceptsReturn = True
        Me.txt_multiplier.BackColor = System.Drawing.SystemColors.Window
        Me.txt_multiplier.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_multiplier.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DseProject1, "SavedProject.Multiplier", True))
        Me.txt_multiplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_multiplier.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_multiplier.Location = New System.Drawing.Point(630, 50)
        Me.txt_multiplier.MaxLength = 0
        Me.txt_multiplier.Name = "txt_multiplier"
        Me.txt_multiplier.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_multiplier.Size = New System.Drawing.Size(78, 21)
        Me.txt_multiplier.TabIndex = 253
        Me.txt_multiplier.Tag = "Multiplier"
        Me.txt_multiplier.Text = "0.495"
        Me.txt_multiplier.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_freight
        '
        Me.txt_freight.AcceptsReturn = True
        Me.txt_freight.BackColor = System.Drawing.SystemColors.Window
        Me.txt_freight.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_freight.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DseProject1, "SavedProject.FreightCost", True))
        Me.txt_freight.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_freight.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_freight.Location = New System.Drawing.Point(630, 96)
        Me.txt_freight.MaxLength = 0
        Me.txt_freight.Name = "txt_freight"
        Me.txt_freight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_freight.Size = New System.Drawing.Size(78, 21)
        Me.txt_freight.TabIndex = 263
        Me.txt_freight.Tag = "Frieght"
        Me.txt_freight.Text = "0"
        Me.txt_freight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_start_up
        '
        Me.txt_start_up.AcceptsReturn = True
        Me.txt_start_up.BackColor = System.Drawing.SystemColors.Window
        Me.txt_start_up.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_start_up.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DseProject1, "SavedProject.StartupCost", True))
        Me.txt_start_up.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_start_up.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_start_up.Location = New System.Drawing.Point(630, 120)
        Me.txt_start_up.MaxLength = 0
        Me.txt_start_up.Name = "txt_start_up"
        Me.txt_start_up.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_start_up.Size = New System.Drawing.Size(78, 21)
        Me.txt_start_up.TabIndex = 264
        Me.txt_start_up.Tag = "Start-up"
        Me.txt_start_up.Text = "0"
        Me.txt_start_up.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_warranty
        '
        Me.txt_warranty.AcceptsReturn = True
        Me.txt_warranty.BackColor = System.Drawing.SystemColors.Window
        Me.txt_warranty.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_warranty.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DseProject1, "SavedProject.WarrantyCost", True))
        Me.txt_warranty.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_warranty.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_warranty.Location = New System.Drawing.Point(630, 144)
        Me.txt_warranty.MaxLength = 0
        Me.txt_warranty.Name = "txt_warranty"
        Me.txt_warranty.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_warranty.Size = New System.Drawing.Size(78, 21)
        Me.txt_warranty.TabIndex = 265
        Me.txt_warranty.Tag = "Warranty"
        Me.txt_warranty.Text = "0"
        Me.txt_warranty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_misc1
        '
        Me.txt_misc1.AcceptsReturn = True
        Me.txt_misc1.BackColor = System.Drawing.SystemColors.Window
        Me.txt_misc1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_misc1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DseProject1, "SavedProject.Misc1Label", True))
        Me.txt_misc1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_misc1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_misc1.Location = New System.Drawing.Point(534, 168)
        Me.txt_misc1.MaxLength = 0
        Me.txt_misc1.Name = "txt_misc1"
        Me.txt_misc1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_misc1.Size = New System.Drawing.Size(89, 21)
        Me.txt_misc1.TabIndex = 266
        Me.txt_misc1.Text = "Misc."
        Me.txt_misc1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_misc1_1
        '
        Me.txt_misc1_1.AcceptsReturn = True
        Me.txt_misc1_1.BackColor = System.Drawing.SystemColors.Window
        Me.txt_misc1_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_misc1_1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DseProject1, "SavedProject.Misc1Cost", True))
        Me.txt_misc1_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_misc1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_misc1_1.Location = New System.Drawing.Point(630, 168)
        Me.txt_misc1_1.MaxLength = 0
        Me.txt_misc1_1.Name = "txt_misc1_1"
        Me.txt_misc1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_misc1_1.Size = New System.Drawing.Size(78, 21)
        Me.txt_misc1_1.TabIndex = 267
        Me.txt_misc1_1.Tag = "Miscellaneous 1"
        Me.txt_misc1_1.Text = "0"
        Me.txt_misc1_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_misc2_2
        '
        Me.txt_misc2_2.AcceptsReturn = True
        Me.txt_misc2_2.BackColor = System.Drawing.SystemColors.Window
        Me.txt_misc2_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_misc2_2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DseProject1, "SavedProject.Misc2Cost", True))
        Me.txt_misc2_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_misc2_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_misc2_2.Location = New System.Drawing.Point(630, 192)
        Me.txt_misc2_2.MaxLength = 0
        Me.txt_misc2_2.Name = "txt_misc2_2"
        Me.txt_misc2_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_misc2_2.Size = New System.Drawing.Size(78, 21)
        Me.txt_misc2_2.TabIndex = 268
        Me.txt_misc2_2.Tag = "Miscellaneous 2"
        Me.txt_misc2_2.Text = "0"
        Me.txt_misc2_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_misc3_3
        '
        Me.txt_misc3_3.AcceptsReturn = True
        Me.txt_misc3_3.BackColor = System.Drawing.SystemColors.Window
        Me.txt_misc3_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_misc3_3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DseProject1, "SavedProject.Misc3Cost", True))
        Me.txt_misc3_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_misc3_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_misc3_3.Location = New System.Drawing.Point(630, 216)
        Me.txt_misc3_3.MaxLength = 0
        Me.txt_misc3_3.Name = "txt_misc3_3"
        Me.txt_misc3_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_misc3_3.Size = New System.Drawing.Size(78, 21)
        Me.txt_misc3_3.TabIndex = 269
        Me.txt_misc3_3.Tag = "Miscellaneous 3"
        Me.txt_misc3_3.Text = "0"
        Me.txt_misc3_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_misc2
        '
        Me.txt_misc2.AcceptsReturn = True
        Me.txt_misc2.BackColor = System.Drawing.SystemColors.Window
        Me.txt_misc2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_misc2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DseProject1, "SavedProject.Misc2Label", True))
        Me.txt_misc2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_misc2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_misc2.Location = New System.Drawing.Point(534, 192)
        Me.txt_misc2.MaxLength = 0
        Me.txt_misc2.Name = "txt_misc2"
        Me.txt_misc2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_misc2.Size = New System.Drawing.Size(89, 21)
        Me.txt_misc2.TabIndex = 270
        Me.txt_misc2.Text = "Misc."
        Me.txt_misc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_misc3
        '
        Me.txt_misc3.AcceptsReturn = True
        Me.txt_misc3.BackColor = System.Drawing.SystemColors.Window
        Me.txt_misc3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_misc3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DseProject1, "SavedProject.Misc3Label", True))
        Me.txt_misc3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_misc3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_misc3.Location = New System.Drawing.Point(534, 216)
        Me.txt_misc3.MaxLength = 0
        Me.txt_misc3.Name = "txt_misc3"
        Me.txt_misc3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_misc3.Size = New System.Drawing.Size(89, 21)
        Me.txt_misc3.TabIndex = 271
        Me.txt_misc3.Text = "Misc."
        Me.txt_misc3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmd_save_file
        '
        Me.cmd_save_file.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_save_file.BackColor = System.Drawing.SystemColors.Control
        Me.cmd_save_file.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmd_save_file.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmd_save_file.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_save_file.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_save_file.Location = New System.Drawing.Point(596, 366)
        Me.cmd_save_file.Name = "cmd_save_file"
        Me.cmd_save_file.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmd_save_file.Size = New System.Drawing.Size(70, 22)
        Me.cmd_save_file.TabIndex = 211
        Me.cmd_save_file.Text = "Save"
        Me.cmd_save_file.UseVisualStyleBackColor = False
        '
        'cmd_close_me
        '
        Me.cmd_close_me.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_close_me.BackColor = System.Drawing.SystemColors.Control
        Me.cmd_close_me.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmd_close_me.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmd_close_me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_close_me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_close_me.Location = New System.Drawing.Point(672, 366)
        Me.cmd_close_me.Name = "cmd_close_me"
        Me.cmd_close_me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmd_close_me.Size = New System.Drawing.Size(70, 22)
        Me.cmd_close_me.TabIndex = 212
        Me.cmd_close_me.Text = "Close"
        Me.cmd_close_me.UseVisualStyleBackColor = False
        '
        'errProjectInfo
        '
        Me.errProjectInfo.BlinkRate = 500
        Me.errProjectInfo.ContainerControl = Me
        '
        'conProject
        '
        Me.conProject.ConnectionString = resources.GetString("conProject.ConnectionString")
        '
        'dadProject
        '
        Me.dadProject.DeleteCommand = Me.OleDbDeleteCommand1
        Me.dadProject.InsertCommand = Me.OleDbInsertCommand1
        Me.dadProject.SelectCommand = Me.OleDbSelectCommand1
        Me.dadProject.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "SavedProject", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Altitude", "Altitude"), New System.Data.Common.DataColumnMapping("Contractor", "Contractor"), New System.Data.Common.DataColumnMapping("CustomerNotes", "CustomerNotes"), New System.Data.Common.DataColumnMapping("Engineer", "Engineer"), New System.Data.Common.DataColumnMapping("FreightCost", "FreightCost"), New System.Data.Common.DataColumnMapping("JobNotes", "JobNotes"), New System.Data.Common.DataColumnMapping("Location", "Location"), New System.Data.Common.DataColumnMapping("Misc1Cost", "Misc1Cost"), New System.Data.Common.DataColumnMapping("Misc1Label", "Misc1Label"), New System.Data.Common.DataColumnMapping("Misc2Cost", "Misc2Cost"), New System.Data.Common.DataColumnMapping("Misc2Label", "Misc2Label"), New System.Data.Common.DataColumnMapping("Misc3Cost", "Misc3Cost"), New System.Data.Common.DataColumnMapping("Misc3Label", "Misc3Label"), New System.Data.Common.DataColumnMapping("Multiplier", "Multiplier"), New System.Data.Common.DataColumnMapping("Owner", "Owner"), New System.Data.Common.DataColumnMapping("ProjectID", "ProjectID"), New System.Data.Common.DataColumnMapping("ProjectName", "ProjectName"), New System.Data.Common.DataColumnMapping("Quantity", "Quantity"), New System.Data.Common.DataColumnMapping("QuoteNumber", "QuoteNumber"), New System.Data.Common.DataColumnMapping("SalesPerson", "SalesPerson"), New System.Data.Common.DataColumnMapping("StartupCost", "StartupCost"), New System.Data.Common.DataColumnMapping("TotalListPrice", "TotalListPrice"), New System.Data.Common.DataColumnMapping("Voltage", "Voltage"), New System.Data.Common.DataColumnMapping("WarrantyCost", "WarrantyCost")})})
        Me.dadProject.UpdateCommand = Me.OleDbUpdateCommand1
        '
        'OleDbDeleteCommand1
        '
        Me.OleDbDeleteCommand1.CommandText = resources.GetString("OleDbDeleteCommand1.CommandText")
        Me.OleDbDeleteCommand1.Connection = Me.conProject
        Me.OleDbDeleteCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ProjectID", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ProjectID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Altitude", System.Data.OleDb.OleDbType.[Double], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Altitude", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Altitude1", System.Data.OleDb.OleDbType.[Double], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Altitude", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Contractor", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Contractor", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Contractor1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Contractor", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Engineer", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Engineer", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Engineer1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Engineer", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FreightCost", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FreightCost", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FreightCost1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FreightCost", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Location", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Location", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Location1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Location", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Misc1Cost", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Misc1Cost", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Misc1Cost1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Misc1Cost", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Misc1Label", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Misc1Label", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Misc1Label1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Misc1Label", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Misc2Cost", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Misc2Cost", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Misc2Cost1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Misc2Cost", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Misc2Label", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Misc2Label", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Misc2Label1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Misc2Label", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Misc3Cost", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Misc3Cost", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Misc3Cost1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Misc3Cost", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Misc3Label", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Misc3Label", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Misc3Label1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Misc3Label", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Multiplier", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Multiplier", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Multiplier1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Multiplier", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Owner", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Owner", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Owner1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Owner", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ProjectName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ProjectName", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ProjectName1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ProjectName", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Quantity", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Quantity", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Quantity1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Quantity", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_QuoteNumber", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "QuoteNumber", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_QuoteNumber1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "QuoteNumber", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_SalesPerson", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SalesPerson", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_SalesPerson1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SalesPerson", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_StartupCost", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "StartupCost", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_StartupCost1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "StartupCost", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_TotalListPrice", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TotalListPrice", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_TotalListPrice1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TotalListPrice", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Voltage", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Voltage", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Voltage1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Voltage", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_WarrantyCost", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "WarrantyCost", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_WarrantyCost1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "WarrantyCost", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand1
        '
        Me.OleDbInsertCommand1.CommandText = resources.GetString("OleDbInsertCommand1.CommandText")
        Me.OleDbInsertCommand1.Connection = Me.conProject
        Me.OleDbInsertCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Altitude", System.Data.OleDb.OleDbType.[Double], 0, "Altitude"), New System.Data.OleDb.OleDbParameter("Contractor", System.Data.OleDb.OleDbType.VarWChar, 50, "Contractor"), New System.Data.OleDb.OleDbParameter("CustomerNotes", System.Data.OleDb.OleDbType.VarWChar, 0, "CustomerNotes"), New System.Data.OleDb.OleDbParameter("Engineer", System.Data.OleDb.OleDbType.VarWChar, 50, "Engineer"), New System.Data.OleDb.OleDbParameter("FreightCost", System.Data.OleDb.OleDbType.VarWChar, 50, "FreightCost"), New System.Data.OleDb.OleDbParameter("JobNotes", System.Data.OleDb.OleDbType.VarWChar, 0, "JobNotes"), New System.Data.OleDb.OleDbParameter("Location", System.Data.OleDb.OleDbType.VarWChar, 50, "Location"), New System.Data.OleDb.OleDbParameter("Misc1Cost", System.Data.OleDb.OleDbType.VarWChar, 50, "Misc1Cost"), New System.Data.OleDb.OleDbParameter("Misc1Label", System.Data.OleDb.OleDbType.VarWChar, 50, "Misc1Label"), New System.Data.OleDb.OleDbParameter("Misc2Cost", System.Data.OleDb.OleDbType.VarWChar, 50, "Misc2Cost"), New System.Data.OleDb.OleDbParameter("Misc2Label", System.Data.OleDb.OleDbType.VarWChar, 50, "Misc2Label"), New System.Data.OleDb.OleDbParameter("Misc3Cost", System.Data.OleDb.OleDbType.VarWChar, 50, "Misc3Cost"), New System.Data.OleDb.OleDbParameter("Misc3Label", System.Data.OleDb.OleDbType.VarWChar, 50, "Misc3Label"), New System.Data.OleDb.OleDbParameter("Multiplier", System.Data.OleDb.OleDbType.VarWChar, 50, "Multiplier"), New System.Data.OleDb.OleDbParameter("Owner", System.Data.OleDb.OleDbType.VarWChar, 50, "Owner"), New System.Data.OleDb.OleDbParameter("ProjectName", System.Data.OleDb.OleDbType.VarWChar, 50, "ProjectName"), New System.Data.OleDb.OleDbParameter("Quantity", System.Data.OleDb.OleDbType.[Integer], 0, "Quantity"), New System.Data.OleDb.OleDbParameter("QuoteNumber", System.Data.OleDb.OleDbType.VarWChar, 50, "QuoteNumber"), New System.Data.OleDb.OleDbParameter("SalesPerson", System.Data.OleDb.OleDbType.VarWChar, 50, "SalesPerson"), New System.Data.OleDb.OleDbParameter("StartupCost", System.Data.OleDb.OleDbType.VarWChar, 50, "StartupCost"), New System.Data.OleDb.OleDbParameter("TotalListPrice", System.Data.OleDb.OleDbType.VarWChar, 50, "TotalListPrice"), New System.Data.OleDb.OleDbParameter("Voltage", System.Data.OleDb.OleDbType.VarWChar, 50, "Voltage"), New System.Data.OleDb.OleDbParameter("WarrantyCost", System.Data.OleDb.OleDbType.VarWChar, 50, "WarrantyCost")})
        '
        'OleDbSelectCommand1
        '
        Me.OleDbSelectCommand1.CommandText = resources.GetString("OleDbSelectCommand1.CommandText")
        Me.OleDbSelectCommand1.Connection = Me.conProject
        Me.OleDbSelectCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("QuoteNumber", System.Data.OleDb.OleDbType.VarWChar, 50, "QuoteNumber")})
        '
        'OleDbUpdateCommand1
        '
        Me.OleDbUpdateCommand1.CommandText = resources.GetString("OleDbUpdateCommand1.CommandText")
        Me.OleDbUpdateCommand1.Connection = Me.conProject
        Me.OleDbUpdateCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Altitude", System.Data.OleDb.OleDbType.[Double], 0, "Altitude"), New System.Data.OleDb.OleDbParameter("Contractor", System.Data.OleDb.OleDbType.VarWChar, 50, "Contractor"), New System.Data.OleDb.OleDbParameter("CustomerNotes", System.Data.OleDb.OleDbType.VarWChar, 0, "CustomerNotes"), New System.Data.OleDb.OleDbParameter("Engineer", System.Data.OleDb.OleDbType.VarWChar, 50, "Engineer"), New System.Data.OleDb.OleDbParameter("FreightCost", System.Data.OleDb.OleDbType.VarWChar, 50, "FreightCost"), New System.Data.OleDb.OleDbParameter("JobNotes", System.Data.OleDb.OleDbType.VarWChar, 0, "JobNotes"), New System.Data.OleDb.OleDbParameter("Location", System.Data.OleDb.OleDbType.VarWChar, 50, "Location"), New System.Data.OleDb.OleDbParameter("Misc1Cost", System.Data.OleDb.OleDbType.VarWChar, 50, "Misc1Cost"), New System.Data.OleDb.OleDbParameter("Misc1Label", System.Data.OleDb.OleDbType.VarWChar, 50, "Misc1Label"), New System.Data.OleDb.OleDbParameter("Misc2Cost", System.Data.OleDb.OleDbType.VarWChar, 50, "Misc2Cost"), New System.Data.OleDb.OleDbParameter("Misc2Label", System.Data.OleDb.OleDbType.VarWChar, 50, "Misc2Label"), New System.Data.OleDb.OleDbParameter("Misc3Cost", System.Data.OleDb.OleDbType.VarWChar, 50, "Misc3Cost"), New System.Data.OleDb.OleDbParameter("Misc3Label", System.Data.OleDb.OleDbType.VarWChar, 50, "Misc3Label"), New System.Data.OleDb.OleDbParameter("Multiplier", System.Data.OleDb.OleDbType.VarWChar, 50, "Multiplier"), New System.Data.OleDb.OleDbParameter("Owner", System.Data.OleDb.OleDbType.VarWChar, 50, "Owner"), New System.Data.OleDb.OleDbParameter("ProjectName", System.Data.OleDb.OleDbType.VarWChar, 50, "ProjectName"), New System.Data.OleDb.OleDbParameter("Quantity", System.Data.OleDb.OleDbType.[Integer], 0, "Quantity"), New System.Data.OleDb.OleDbParameter("QuoteNumber", System.Data.OleDb.OleDbType.VarWChar, 50, "QuoteNumber"), New System.Data.OleDb.OleDbParameter("SalesPerson", System.Data.OleDb.OleDbType.VarWChar, 50, "SalesPerson"), New System.Data.OleDb.OleDbParameter("StartupCost", System.Data.OleDb.OleDbType.VarWChar, 50, "StartupCost"), New System.Data.OleDb.OleDbParameter("TotalListPrice", System.Data.OleDb.OleDbType.VarWChar, 50, "TotalListPrice"), New System.Data.OleDb.OleDbParameter("Voltage", System.Data.OleDb.OleDbType.VarWChar, 50, "Voltage"), New System.Data.OleDb.OleDbParameter("WarrantyCost", System.Data.OleDb.OleDbType.VarWChar, 50, "WarrantyCost"), New System.Data.OleDb.OleDbParameter("Original_ProjectID", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ProjectID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Altitude", System.Data.OleDb.OleDbType.[Double], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Altitude", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Altitude1", System.Data.OleDb.OleDbType.[Double], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Altitude", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Contractor", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Contractor", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Contractor1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Contractor", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Engineer", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Engineer", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Engineer1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Engineer", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FreightCost", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FreightCost", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FreightCost1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FreightCost", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Location", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Location", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Location1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Location", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Misc1Cost", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Misc1Cost", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Misc1Cost1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Misc1Cost", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Misc1Label", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Misc1Label", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Misc1Label1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Misc1Label", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Misc2Cost", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Misc2Cost", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Misc2Cost1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Misc2Cost", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Misc2Label", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Misc2Label", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Misc2Label1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Misc2Label", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Misc3Cost", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Misc3Cost", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Misc3Cost1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Misc3Cost", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Misc3Label", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Misc3Label", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Misc3Label1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Misc3Label", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Multiplier", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Multiplier", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Multiplier1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Multiplier", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Owner", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Owner", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Owner1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Owner", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ProjectName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ProjectName", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ProjectName1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ProjectName", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Quantity", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Quantity", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Quantity1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Quantity", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_QuoteNumber", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "QuoteNumber", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_QuoteNumber1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "QuoteNumber", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_SalesPerson", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SalesPerson", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_SalesPerson1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SalesPerson", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_StartupCost", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "StartupCost", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_StartupCost1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "StartupCost", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_TotalListPrice", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TotalListPrice", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_TotalListPrice1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TotalListPrice", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Voltage", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Voltage", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Voltage1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Voltage", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_WarrantyCost", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "WarrantyCost", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_WarrantyCost1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "WarrantyCost", System.Data.DataRowVersion.Original, Nothing)})
        '
        'dadAirHandler
        '
        Me.dadAirHandler.DeleteCommand = Me.OleDbDeleteCommand2
        Me.dadAirHandler.InsertCommand = Me.OleDbInsertCommand2
        Me.dadAirHandler.SelectCommand = Me.OleDbSelectCommand2
        Me.dadAirHandler.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "SavedAirHandler", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Airflow", "Airflow"), New System.Data.Common.DataColumnMapping("AirHandlerID", "AirHandlerID"), New System.Data.Common.DataColumnMapping("BaseCost", "BaseCost"), New System.Data.Common.DataColumnMapping("BaseMaterial", "BaseMaterial"), New System.Data.Common.DataColumnMapping("CabinetIndex", "CabinetIndex"), New System.Data.Common.DataColumnMapping("CoilFaceVelocity", "CoilFaceVelocity"), New System.Data.Common.DataColumnMapping("CoilIndex", "CoilIndex"), New System.Data.Common.DataColumnMapping("CoilSize", "CoilSize"), New System.Data.Common.DataColumnMapping("ExternalStaticPressure", "ExternalStaticPressure"), New System.Data.Common.DataColumnMapping("FilterFaceVelocity", "FilterFaceVelocity"), New System.Data.Common.DataColumnMapping("FilterSize", "FilterSize"), New System.Data.Common.DataColumnMapping("Height", "Height"), New System.Data.Common.DataColumnMapping("Length", "Length"), New System.Data.Common.DataColumnMapping("ListPrice", "ListPrice"), New System.Data.Common.DataColumnMapping("Location", "Location"), New System.Data.Common.DataColumnMapping("MarginPrice", "MarginPrice"), New System.Data.Common.DataColumnMapping("ModelNumber", "ModelNumber"), New System.Data.Common.DataColumnMapping("NumAirSeals", "NumAirSeals"), New System.Data.Common.DataColumnMapping("NumDoors", "NumDoors"), New System.Data.Common.DataColumnMapping("Paint", "Paint"), New System.Data.Common.DataColumnMapping("PanelThickness", "PanelThickness"), New System.Data.Common.DataColumnMapping("ProjectID", "ProjectID"), New System.Data.Common.DataColumnMapping("ShipWeight", "ShipWeight"), New System.Data.Common.DataColumnMapping("Tag", "Tag"), New System.Data.Common.DataColumnMapping("Width", "Width")})})
        Me.dadAirHandler.UpdateCommand = Me.OleDbUpdateCommand2
        '
        'OleDbDeleteCommand2
        '
        Me.OleDbDeleteCommand2.CommandText = resources.GetString("OleDbDeleteCommand2.CommandText")
        Me.OleDbDeleteCommand2.Connection = Me.conProject
        Me.OleDbDeleteCommand2.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_AirHandlerID", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AirHandlerID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Airflow", System.Data.OleDb.OleDbType.[Double], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Airflow", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Airflow1", System.Data.OleDb.OleDbType.[Double], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Airflow", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_BaseCost", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "BaseCost", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_BaseCost1", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "BaseCost", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_BaseMaterial", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "BaseMaterial", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_BaseMaterial1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "BaseMaterial", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CabinetIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CabinetIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CabinetIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CabinetIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilFaceVelocity", System.Data.OleDb.OleDbType.[Double], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilFaceVelocity", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilFaceVelocity1", System.Data.OleDb.OleDbType.[Double], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilFaceVelocity", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilIndex", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilIndex1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilSize", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilSize", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilSize1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilSize", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ExternalStaticPressure", System.Data.OleDb.OleDbType.[Double], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ExternalStaticPressure", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ExternalStaticPressure1", System.Data.OleDb.OleDbType.[Double], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ExternalStaticPressure", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FilterFaceVelocity", System.Data.OleDb.OleDbType.[Double], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FilterFaceVelocity", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FilterFaceVelocity1", System.Data.OleDb.OleDbType.[Double], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FilterFaceVelocity", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FilterSize", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FilterSize", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FilterSize1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FilterSize", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Height", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Height", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Height1", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Height", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Length", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Length", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Length1", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Length", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ListPrice", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ListPrice", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ListPrice1", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ListPrice", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Location", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Location", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Location1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Location", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MarginPrice", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MarginPrice", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MarginPrice1", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MarginPrice", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ModelNumber", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ModelNumber", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ModelNumber1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ModelNumber", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumAirSeals", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumAirSeals", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumAirSeals1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumAirSeals", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumDoors", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumDoors", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumDoors1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumDoors", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Paint", System.Data.OleDb.OleDbType.[Boolean], 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Paint", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_PanelThickness", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PanelThickness", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_PanelThickness1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PanelThickness", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ProjectID", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ProjectID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ProjectID1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ProjectID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ShipWeight", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipWeight", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ShipWeight1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipWeight", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Tag", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Tag", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Tag1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Tag", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Width", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Width", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Width1", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Width", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand2
        '
        Me.OleDbInsertCommand2.CommandText = resources.GetString("OleDbInsertCommand2.CommandText")
        Me.OleDbInsertCommand2.Connection = Me.conProject
        Me.OleDbInsertCommand2.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Airflow", System.Data.OleDb.OleDbType.[Double], 0, "Airflow"), New System.Data.OleDb.OleDbParameter("BaseCost", System.Data.OleDb.OleDbType.[Single], 0, "BaseCost"), New System.Data.OleDb.OleDbParameter("BaseMaterial", System.Data.OleDb.OleDbType.VarWChar, 50, "BaseMaterial"), New System.Data.OleDb.OleDbParameter("CabinetIndex", System.Data.OleDb.OleDbType.[Integer], 0, "CabinetIndex"), New System.Data.OleDb.OleDbParameter("CoilFaceVelocity", System.Data.OleDb.OleDbType.[Double], 0, "CoilFaceVelocity"), New System.Data.OleDb.OleDbParameter("CoilIndex", System.Data.OleDb.OleDbType.SmallInt, 0, "CoilIndex"), New System.Data.OleDb.OleDbParameter("CoilSize", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilSize"), New System.Data.OleDb.OleDbParameter("ExternalStaticPressure", System.Data.OleDb.OleDbType.[Double], 0, "ExternalStaticPressure"), New System.Data.OleDb.OleDbParameter("FilterFaceVelocity", System.Data.OleDb.OleDbType.[Double], 0, "FilterFaceVelocity"), New System.Data.OleDb.OleDbParameter("FilterSize", System.Data.OleDb.OleDbType.VarWChar, 50, "FilterSize"), New System.Data.OleDb.OleDbParameter("Height", System.Data.OleDb.OleDbType.[Single], 0, "Height"), New System.Data.OleDb.OleDbParameter("Length", System.Data.OleDb.OleDbType.[Single], 0, "Length"), New System.Data.OleDb.OleDbParameter("ListPrice", System.Data.OleDb.OleDbType.[Single], 0, "ListPrice"), New System.Data.OleDb.OleDbParameter("Location", System.Data.OleDb.OleDbType.VarWChar, 50, "Location"), New System.Data.OleDb.OleDbParameter("MarginPrice", System.Data.OleDb.OleDbType.[Single], 0, "MarginPrice"), New System.Data.OleDb.OleDbParameter("ModelNumber", System.Data.OleDb.OleDbType.VarWChar, 50, "ModelNumber"), New System.Data.OleDb.OleDbParameter("NumAirSeals", System.Data.OleDb.OleDbType.[Integer], 0, "NumAirSeals"), New System.Data.OleDb.OleDbParameter("NumDoors", System.Data.OleDb.OleDbType.[Integer], 0, "NumDoors"), New System.Data.OleDb.OleDbParameter("Paint", System.Data.OleDb.OleDbType.[Boolean], 2, "Paint"), New System.Data.OleDb.OleDbParameter("PanelThickness", System.Data.OleDb.OleDbType.SmallInt, 0, "PanelThickness"), New System.Data.OleDb.OleDbParameter("ProjectID", System.Data.OleDb.OleDbType.[Integer], 0, "ProjectID"), New System.Data.OleDb.OleDbParameter("ShipWeight", System.Data.OleDb.OleDbType.VarWChar, 50, "ShipWeight"), New System.Data.OleDb.OleDbParameter("Tag", System.Data.OleDb.OleDbType.VarWChar, 50, "Tag"), New System.Data.OleDb.OleDbParameter("Width", System.Data.OleDb.OleDbType.[Single], 0, "Width")})
        '
        'OleDbSelectCommand2
        '
        Me.OleDbSelectCommand2.CommandText = resources.GetString("OleDbSelectCommand2.CommandText")
        Me.OleDbSelectCommand2.Connection = Me.conProject
        Me.OleDbSelectCommand2.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ProjectID", System.Data.OleDb.OleDbType.[Integer], 0, "ProjectID")})
        '
        'OleDbUpdateCommand2
        '
        Me.OleDbUpdateCommand2.CommandText = resources.GetString("OleDbUpdateCommand2.CommandText")
        Me.OleDbUpdateCommand2.Connection = Me.conProject
        Me.OleDbUpdateCommand2.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Airflow", System.Data.OleDb.OleDbType.[Double], 0, "Airflow"), New System.Data.OleDb.OleDbParameter("BaseCost", System.Data.OleDb.OleDbType.[Single], 0, "BaseCost"), New System.Data.OleDb.OleDbParameter("BaseMaterial", System.Data.OleDb.OleDbType.VarWChar, 50, "BaseMaterial"), New System.Data.OleDb.OleDbParameter("CabinetIndex", System.Data.OleDb.OleDbType.[Integer], 0, "CabinetIndex"), New System.Data.OleDb.OleDbParameter("CoilFaceVelocity", System.Data.OleDb.OleDbType.[Double], 0, "CoilFaceVelocity"), New System.Data.OleDb.OleDbParameter("CoilIndex", System.Data.OleDb.OleDbType.SmallInt, 0, "CoilIndex"), New System.Data.OleDb.OleDbParameter("CoilSize", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilSize"), New System.Data.OleDb.OleDbParameter("ExternalStaticPressure", System.Data.OleDb.OleDbType.[Double], 0, "ExternalStaticPressure"), New System.Data.OleDb.OleDbParameter("FilterFaceVelocity", System.Data.OleDb.OleDbType.[Double], 0, "FilterFaceVelocity"), New System.Data.OleDb.OleDbParameter("FilterSize", System.Data.OleDb.OleDbType.VarWChar, 50, "FilterSize"), New System.Data.OleDb.OleDbParameter("Height", System.Data.OleDb.OleDbType.[Single], 0, "Height"), New System.Data.OleDb.OleDbParameter("Length", System.Data.OleDb.OleDbType.[Single], 0, "Length"), New System.Data.OleDb.OleDbParameter("ListPrice", System.Data.OleDb.OleDbType.[Single], 0, "ListPrice"), New System.Data.OleDb.OleDbParameter("Location", System.Data.OleDb.OleDbType.VarWChar, 50, "Location"), New System.Data.OleDb.OleDbParameter("MarginPrice", System.Data.OleDb.OleDbType.[Single], 0, "MarginPrice"), New System.Data.OleDb.OleDbParameter("ModelNumber", System.Data.OleDb.OleDbType.VarWChar, 50, "ModelNumber"), New System.Data.OleDb.OleDbParameter("NumAirSeals", System.Data.OleDb.OleDbType.[Integer], 0, "NumAirSeals"), New System.Data.OleDb.OleDbParameter("NumDoors", System.Data.OleDb.OleDbType.[Integer], 0, "NumDoors"), New System.Data.OleDb.OleDbParameter("Paint", System.Data.OleDb.OleDbType.[Boolean], 2, "Paint"), New System.Data.OleDb.OleDbParameter("PanelThickness", System.Data.OleDb.OleDbType.SmallInt, 0, "PanelThickness"), New System.Data.OleDb.OleDbParameter("ProjectID", System.Data.OleDb.OleDbType.[Integer], 0, "ProjectID"), New System.Data.OleDb.OleDbParameter("ShipWeight", System.Data.OleDb.OleDbType.VarWChar, 50, "ShipWeight"), New System.Data.OleDb.OleDbParameter("Tag", System.Data.OleDb.OleDbType.VarWChar, 50, "Tag"), New System.Data.OleDb.OleDbParameter("Width", System.Data.OleDb.OleDbType.[Single], 0, "Width"), New System.Data.OleDb.OleDbParameter("Original_AirHandlerID", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AirHandlerID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Airflow", System.Data.OleDb.OleDbType.[Double], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Airflow", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Airflow1", System.Data.OleDb.OleDbType.[Double], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Airflow", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_BaseCost", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "BaseCost", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_BaseCost1", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "BaseCost", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_BaseMaterial", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "BaseMaterial", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_BaseMaterial1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "BaseMaterial", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CabinetIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CabinetIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CabinetIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CabinetIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilFaceVelocity", System.Data.OleDb.OleDbType.[Double], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilFaceVelocity", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilFaceVelocity1", System.Data.OleDb.OleDbType.[Double], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilFaceVelocity", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilIndex", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilIndex1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilSize", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilSize", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilSize1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilSize", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ExternalStaticPressure", System.Data.OleDb.OleDbType.[Double], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ExternalStaticPressure", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ExternalStaticPressure1", System.Data.OleDb.OleDbType.[Double], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ExternalStaticPressure", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FilterFaceVelocity", System.Data.OleDb.OleDbType.[Double], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FilterFaceVelocity", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FilterFaceVelocity1", System.Data.OleDb.OleDbType.[Double], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FilterFaceVelocity", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FilterSize", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FilterSize", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FilterSize1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FilterSize", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Height", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Height", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Height1", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Height", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Length", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Length", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Length1", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Length", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ListPrice", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ListPrice", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ListPrice1", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ListPrice", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Location", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Location", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Location1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Location", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MarginPrice", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MarginPrice", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MarginPrice1", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MarginPrice", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ModelNumber", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ModelNumber", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ModelNumber1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ModelNumber", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumAirSeals", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumAirSeals", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumAirSeals1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumAirSeals", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumDoors", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumDoors", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumDoors1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumDoors", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Paint", System.Data.OleDb.OleDbType.[Boolean], 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Paint", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_PanelThickness", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PanelThickness", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_PanelThickness1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PanelThickness", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ProjectID", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ProjectID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ProjectID1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ProjectID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ShipWeight", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipWeight", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ShipWeight1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipWeight", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Tag", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Tag", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Tag1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Tag", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Width", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Width", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Width1", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Width", System.Data.DataRowVersion.Original, Nothing)})
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Yellow
        Me.Button1.Location = New System.Drawing.Point(484, 366)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 213
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'dadSection
        '
        Me.dadSection.DeleteCommand = Me.OleDbDeleteCommand3
        Me.dadSection.InsertCommand = Me.OleDbInsertCommand3
        Me.dadSection.SelectCommand = Me.OleDbSelectCommand3
        Me.dadSection.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "_Section", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Abbreviation", "Abbreviation"), New System.Data.Common.DataColumnMapping("AirHandlerID", "AirHandlerID"), New System.Data.Common.DataColumnMapping("OrderIndex", "OrderIndex"), New System.Data.Common.DataColumnMapping("SectionID", "SectionID"), New System.Data.Common.DataColumnMapping("SectionLength", "SectionLength")})})
        Me.dadSection.UpdateCommand = Me.OleDbUpdateCommand3
        '
        'OleDbDeleteCommand3
        '
        Me.OleDbDeleteCommand3.CommandText = resources.GetString("OleDbDeleteCommand3.CommandText")
        Me.OleDbDeleteCommand3.Connection = Me.conProject
        Me.OleDbDeleteCommand3.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_SectionID", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SectionID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Abbreviation", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Abbreviation", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Abbreviation1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Abbreviation", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_AirHandlerID", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AirHandlerID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_AirHandlerID1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AirHandlerID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_OrderIndex", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_OrderIndex1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_SectionLength", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SectionLength", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_SectionLength1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SectionLength", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand3
        '
        Me.OleDbInsertCommand3.CommandText = "INSERT INTO _Section(Abbreviation, AirHandlerID, OrderIndex, SectionLength) VALUE" & _
            "S (?, ?, ?, ?)"
        Me.OleDbInsertCommand3.Connection = Me.conProject
        Me.OleDbInsertCommand3.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Abbreviation", System.Data.OleDb.OleDbType.VarWChar, 50, "Abbreviation"), New System.Data.OleDb.OleDbParameter("AirHandlerID", System.Data.OleDb.OleDbType.[Integer], 0, "AirHandlerID"), New System.Data.OleDb.OleDbParameter("OrderIndex", System.Data.OleDb.OleDbType.SmallInt, 0, "OrderIndex"), New System.Data.OleDb.OleDbParameter("SectionLength", System.Data.OleDb.OleDbType.[Integer], 0, "SectionLength")})
        '
        'OleDbSelectCommand3
        '
        Me.OleDbSelectCommand3.CommandText = "SELECT Abbreviation, AirHandlerID, OrderIndex, SectionID, SectionLength FROM _Sec" & _
            "tion WHERE (AirHandlerID = ?)"
        Me.OleDbSelectCommand3.Connection = Me.conProject
        Me.OleDbSelectCommand3.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("AirHandlerID", System.Data.OleDb.OleDbType.[Integer], 0, "AirHandlerID")})
        '
        'OleDbUpdateCommand3
        '
        Me.OleDbUpdateCommand3.CommandText = resources.GetString("OleDbUpdateCommand3.CommandText")
        Me.OleDbUpdateCommand3.Connection = Me.conProject
        Me.OleDbUpdateCommand3.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Abbreviation", System.Data.OleDb.OleDbType.VarWChar, 50, "Abbreviation"), New System.Data.OleDb.OleDbParameter("AirHandlerID", System.Data.OleDb.OleDbType.[Integer], 0, "AirHandlerID"), New System.Data.OleDb.OleDbParameter("OrderIndex", System.Data.OleDb.OleDbType.SmallInt, 0, "OrderIndex"), New System.Data.OleDb.OleDbParameter("SectionLength", System.Data.OleDb.OleDbType.[Integer], 0, "SectionLength"), New System.Data.OleDb.OleDbParameter("Original_SectionID", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SectionID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Abbreviation", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Abbreviation", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Abbreviation1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Abbreviation", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_AirHandlerID", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AirHandlerID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_AirHandlerID1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AirHandlerID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_OrderIndex", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_OrderIndex1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_SectionLength", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SectionLength", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_SectionLength1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SectionLength", System.Data.DataRowVersion.Original, Nothing)})
        '
        'DseProjectClone
        '
        Me.DseProjectClone.DataSetName = "dseProject"
        Me.DseProjectClone.Locale = New System.Globalization.CultureInfo("en-US")
        Me.DseProjectClone.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dadSectionDetails
        '
        Me.dadSectionDetails.DeleteCommand = Me.OleDbDeleteCommand4
        Me.dadSectionDetails.InsertCommand = Me.OleDbInsertCommand4
        Me.dadSectionDetails.SelectCommand = Me.OleDbSelectCommand4
        Me.dadSectionDetails.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "SectionDetails", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("AirHandlerID", "AirHandlerID"), New System.Data.Common.DataColumnMapping("C3Disconnect", "C3Disconnect"), New System.Data.Common.DataColumnMapping("C3KW", "C3KW"), New System.Data.Common.DataColumnMapping("C3MinNumStages", "C3MinNumStages"), New System.Data.Common.DataColumnMapping("C3NumExtraStages", "C3NumExtraStages"), New System.Data.Common.DataColumnMapping("C3OperatingTemperature", "C3OperatingTemperature"), New System.Data.Common.DataColumnMapping("C3OrderIndex", "C3OrderIndex"), New System.Data.Common.DataColumnMapping("C3SiliconControlledRectifier", "C3SiliconControlledRectifier"), New System.Data.Common.DataColumnMapping("Coil0OrderIndex", "Coil0OrderIndex"), New System.Data.Common.DataColumnMapping("Coil1OrderIndex", "Coil1OrderIndex"), New System.Data.Common.DataColumnMapping("Coil2OrderIndex", "Coil2OrderIndex"), New System.Data.Common.DataColumnMapping("CoilCasing0", "CoilCasing0"), New System.Data.Common.DataColumnMapping("CoilCasing1", "CoilCasing1"), New System.Data.Common.DataColumnMapping("CoilCasing2", "CoilCasing2"), New System.Data.Common.DataColumnMapping("CoilRows0", "CoilRows0"), New System.Data.Common.DataColumnMapping("CoilRows1", "CoilRows1"), New System.Data.Common.DataColumnMapping("CoilRows2", "CoilRows2"), New System.Data.Common.DataColumnMapping("CoilType0", "CoilType0"), New System.Data.Common.DataColumnMapping("CoilType1", "CoilType1"), New System.Data.Common.DataColumnMapping("CoilType2", "CoilType2"), New System.Data.Common.DataColumnMapping("DischargeGrating", "DischargeGrating"), New System.Data.Common.DataColumnMapping("DischargeHeight", "DischargeHeight"), New System.Data.Common.DataColumnMapping("DischargeOpeningLocation", "DischargeOpeningLocation"), New System.Data.Common.DataColumnMapping("DischargeOrderIndex", "DischargeOrderIndex"), New System.Data.Common.DataColumnMapping("DischargeWidth", "DischargeWidth"), New System.Data.Common.DataColumnMapping("Fan0OrderIndex", "Fan0OrderIndex"), New System.Data.Common.DataColumnMapping("Fan1OrderIndex", "Fan1OrderIndex"), New System.Data.Common.DataColumnMapping("Fan2OrderIndex", "Fan2OrderIndex"), New System.Data.Common.DataColumnMapping("FanClass0", "FanClass0"), New System.Data.Common.DataColumnMapping("FanClass1", "FanClass1"), New System.Data.Common.DataColumnMapping("FanClass2", "FanClass2"), New System.Data.Common.DataColumnMapping("FanDrive0", "FanDrive0"), New System.Data.Common.DataColumnMapping("FanDrive1", "FanDrive1"), New System.Data.Common.DataColumnMapping("FanDrive2", "FanDrive2"), New System.Data.Common.DataColumnMapping("FanEfficiency0", "FanEfficiency0"), New System.Data.Common.DataColumnMapping("FanEfficiency1", "FanEfficiency1"), New System.Data.Common.DataColumnMapping("FanEfficiency2", "FanEfficiency2"), New System.Data.Common.DataColumnMapping("FanEnclosure0", "FanEnclosure0"), New System.Data.Common.DataColumnMapping("FanEnclosure1", "FanEnclosure1"), New System.Data.Common.DataColumnMapping("FanEnclosure2", "FanEnclosure2"), New System.Data.Common.DataColumnMapping("FanHorsepower1", "FanHorsepower1"), New System.Data.Common.DataColumnMapping("FanHorsepower0", "FanHorsepower0"), New System.Data.Common.DataColumnMapping("FanHorsepower2", "FanHorsepower2"), New System.Data.Common.DataColumnMapping("FanIsolator0", "FanIsolator0"), New System.Data.Common.DataColumnMapping("FanIsolator1", "FanIsolator1"), New System.Data.Common.DataColumnMapping("FanIsolator2", "FanIsolator2"), New System.Data.Common.DataColumnMapping("FanRPM0", "FanRPM0"), New System.Data.Common.DataColumnMapping("FanRPM1", "FanRPM1"), New System.Data.Common.DataColumnMapping("FanRPM2", "FanRPM2"), New System.Data.Common.DataColumnMapping("FanSize0", "FanSize0"), New System.Data.Common.DataColumnMapping("FanSize1", "FanSize1"), New System.Data.Common.DataColumnMapping("FanSize2", "FanSize2"), New System.Data.Common.DataColumnMapping("FanType0", "FanType0"), New System.Data.Common.DataColumnMapping("FanType1", "FanType1"), New System.Data.Common.DataColumnMapping("FanType2", "FanType2"), New System.Data.Common.DataColumnMapping("Filt0", "Filt0"), New System.Data.Common.DataColumnMapping("Filt0OrderIndex", "Filt0OrderIndex"), New System.Data.Common.DataColumnMapping("Filt1", "Filt1"), New System.Data.Common.DataColumnMapping("Filt1OrderIndex", "Filt1OrderIndex"), New System.Data.Common.DataColumnMapping("Filt2", "Filt2"), New System.Data.Common.DataColumnMapping("Filt2OrderIndex", "Filt2OrderIndex"), New System.Data.Common.DataColumnMapping("FinMaterial0", "FinMaterial0"), New System.Data.Common.DataColumnMapping("FinMaterial1", "FinMaterial1"), New System.Data.Common.DataColumnMapping("FinMaterial2", "FinMaterial2"), New System.Data.Common.DataColumnMapping("FinThickness0", "FinThickness0"), New System.Data.Common.DataColumnMapping("FinThickness1", "FinThickness1"), New System.Data.Common.DataColumnMapping("FinThickness2", "FinThickness2"), New System.Data.Common.DataColumnMapping("MB1Casing", "MB1Casing"), New System.Data.Common.DataColumnMapping("MB1IncomingAir", "MB1IncomingAir"), New System.Data.Common.DataColumnMapping("MB1OrderIndex", "MB1OrderIndex"), New System.Data.Common.DataColumnMapping("MB2Casing", "MB2Casing"), New System.Data.Common.DataColumnMapping("MB2IncomingAir", "MB2IncomingAir"), New System.Data.Common.DataColumnMapping("MB2OrderIndex", "MB2OrderIndex"), New System.Data.Common.DataColumnMapping("NumFilts0", "NumFilts0"), New System.Data.Common.DataColumnMapping("NumFilts1", "NumFilts1"), New System.Data.Common.DataColumnMapping("NumFilts2", "NumFilts2"), New System.Data.Common.DataColumnMapping("NumFins0", "NumFins0"), New System.Data.Common.DataColumnMapping("NumFins1", "NumFins1"), New System.Data.Common.DataColumnMapping("NumFins2", "NumFins2"), New System.Data.Common.DataColumnMapping("NumPreFilts0", "NumPreFilts0"), New System.Data.Common.DataColumnMapping("NumPreFilts1", "NumPreFilts1"), New System.Data.Common.DataColumnMapping("NumPreFilts2", "NumPreFilts2"), New System.Data.Common.DataColumnMapping("PreFilt0", "PreFilt0"), New System.Data.Common.DataColumnMapping("PreFilt1", "PreFilt1"), New System.Data.Common.DataColumnMapping("PreFilt2", "PreFilt2"), New System.Data.Common.DataColumnMapping("SectionDetailsID", "SectionDetailsID"), New System.Data.Common.DataColumnMapping("TubeThickness0", "TubeThickness0"), New System.Data.Common.DataColumnMapping("TubeThickness1", "TubeThickness1"), New System.Data.Common.DataColumnMapping("TubeThickness2", "TubeThickness2")})})
        Me.dadSectionDetails.UpdateCommand = Me.OleDbUpdateCommand4
        '
        'OleDbDeleteCommand4
        '
        Me.OleDbDeleteCommand4.CommandText = resources.GetString("OleDbDeleteCommand4.CommandText")
        Me.OleDbDeleteCommand4.Connection = Me.conProject
        Me.OleDbDeleteCommand4.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_SectionDetailsID", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SectionDetailsID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_AirHandlerID", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AirHandlerID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_AirHandlerID1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AirHandlerID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_C3Disconnect", System.Data.OleDb.OleDbType.[Boolean], 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "C3Disconnect", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_C3KW", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "C3KW", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_C3KW1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "C3KW", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_C3MinNumStages", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "C3MinNumStages", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_C3MinNumStages1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "C3MinNumStages", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_C3NumExtraStages", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "C3NumExtraStages", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_C3NumExtraStages1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "C3NumExtraStages", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_C3OperatingTemperature", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "C3OperatingTemperature", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_C3OperatingTemperature1", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "C3OperatingTemperature", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_C3OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "C3OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_C3OrderIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "C3OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_C3SiliconControlledRectifier", System.Data.OleDb.OleDbType.[Boolean], 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "C3SiliconControlledRectifier", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Coil0OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Coil0OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Coil0OrderIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Coil0OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Coil1OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Coil1OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Coil1OrderIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Coil1OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Coil2OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Coil2OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Coil2OrderIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Coil2OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilCasing0", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilCasing0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilCasing01", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilCasing0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilCasing1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilCasing1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilCasing11", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilCasing1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilCasing2", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilCasing2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilCasing21", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilCasing2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilRows0", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilRows0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilRows01", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilRows0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilRows1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilRows1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilRows11", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilRows1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilRows2", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilRows2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilRows21", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilRows2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilType0", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilType0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilType01", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilType0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilType1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilType1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilType11", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilType1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilType2", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilType2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilType21", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilType2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_DischargeGrating", System.Data.OleDb.OleDbType.[Boolean], 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DischargeGrating", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_DischargeHeight", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DischargeHeight", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_DischargeHeight1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DischargeHeight", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_DischargeOpeningLocation", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DischargeOpeningLocation", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_DischargeOpeningLocation1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DischargeOpeningLocation", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_DischargeOrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DischargeOrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_DischargeOrderIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DischargeOrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_DischargeWidth", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DischargeWidth", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_DischargeWidth1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DischargeWidth", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Fan0OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Fan0OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Fan0OrderIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Fan0OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Fan1OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Fan1OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Fan1OrderIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Fan1OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Fan2OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Fan2OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Fan2OrderIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Fan2OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanClass0", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanClass0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanClass01", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanClass0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanClass1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanClass1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanClass11", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanClass1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanClass2", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanClass2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanClass21", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanClass2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanDrive0", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanDrive0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanDrive01", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanDrive0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanDrive1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanDrive1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanDrive11", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanDrive1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanDrive2", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanDrive2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanDrive21", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanDrive2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanEfficiency0", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanEfficiency0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanEfficiency01", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanEfficiency0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanEfficiency1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanEfficiency1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanEfficiency11", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanEfficiency1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanEfficiency2", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanEfficiency2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanEfficiency21", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanEfficiency2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanEnclosure0", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanEnclosure0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanEnclosure01", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanEnclosure0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanEnclosure1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanEnclosure1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanEnclosure11", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanEnclosure1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanEnclosure2", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanEnclosure2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanEnclosure21", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanEnclosure2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanHorsepower0", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanHorsepower0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanHorsepower01", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanHorsepower0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanHorsepower1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanHorsepower1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanHorsepower11", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanHorsepower1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanHorsepower2", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanHorsepower2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanHorsepower21", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanHorsepower2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanIsolator0", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanIsolator0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanIsolator01", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanIsolator0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanIsolator1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanIsolator1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanIsolator11", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanIsolator1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanIsolator2", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanIsolator2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanIsolator21", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanIsolator2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanRPM0", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanRPM0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanRPM01", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanRPM0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanRPM1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanRPM1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanRPM11", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanRPM1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanRPM2", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanRPM2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanRPM21", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanRPM2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanSize0", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanSize0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanSize01", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanSize0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanSize1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanSize1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanSize11", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanSize1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanSize2", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanSize2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanSize21", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanSize2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanType0", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanType0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanType01", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanType0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanType1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanType1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanType11", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanType1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanType2", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanType2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanType21", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanType2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Filt0", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Filt0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Filt01", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Filt0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Filt0OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Filt0OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Filt0OrderIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Filt0OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Filt1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Filt1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Filt11", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Filt1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Filt1OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Filt1OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Filt1OrderIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Filt1OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Filt2", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Filt2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Filt21", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Filt2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Filt2OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Filt2OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Filt2OrderIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Filt2OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FinMaterial0", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FinMaterial0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FinMaterial01", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FinMaterial0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FinMaterial1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FinMaterial1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FinMaterial11", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FinMaterial1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FinMaterial2", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FinMaterial2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FinMaterial21", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FinMaterial2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FinThickness0", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FinThickness0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FinThickness01", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FinThickness0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FinThickness1", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FinThickness1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FinThickness11", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FinThickness1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FinThickness2", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FinThickness2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FinThickness21", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FinThickness2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MB1Casing", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MB1Casing", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MB1Casing1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MB1Casing", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MB1IncomingAir", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MB1IncomingAir", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MB1IncomingAir1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MB1IncomingAir", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MB1OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MB1OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MB1OrderIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MB1OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MB2Casing", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MB2Casing", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MB2Casing1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MB2Casing", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MB2IncomingAir", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MB2IncomingAir", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MB2IncomingAir1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MB2IncomingAir", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MB2OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MB2OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MB2OrderIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MB2OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumFilts0", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumFilts0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumFilts01", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumFilts0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumFilts1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumFilts1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumFilts11", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumFilts1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumFilts2", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumFilts2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumFilts21", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumFilts2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumFins0", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumFins0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumFins01", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumFins0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumFins1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumFins1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumFins11", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumFins1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumFins2", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumFins2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumFins21", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumFins2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumPreFilts0", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumPreFilts0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumPreFilts01", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumPreFilts0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumPreFilts1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumPreFilts1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumPreFilts11", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumPreFilts1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumPreFilts2", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumPreFilts2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumPreFilts21", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumPreFilts2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_PreFilt0", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PreFilt0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_PreFilt01", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PreFilt0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_PreFilt1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PreFilt1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_PreFilt11", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PreFilt1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_PreFilt2", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PreFilt2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_PreFilt21", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PreFilt2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_TubeThickness0", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TubeThickness0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_TubeThickness01", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TubeThickness0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_TubeThickness1", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TubeThickness1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_TubeThickness11", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TubeThickness1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_TubeThickness2", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TubeThickness2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_TubeThickness21", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TubeThickness2", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand4
        '
        Me.OleDbInsertCommand4.CommandText = resources.GetString("OleDbInsertCommand4.CommandText")
        Me.OleDbInsertCommand4.Connection = Me.conProject
        Me.OleDbInsertCommand4.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("AirHandlerID", System.Data.OleDb.OleDbType.[Integer], 0, "AirHandlerID"), New System.Data.OleDb.OleDbParameter("C3Disconnect", System.Data.OleDb.OleDbType.[Boolean], 2, "C3Disconnect"), New System.Data.OleDb.OleDbParameter("C3KW", System.Data.OleDb.OleDbType.VarWChar, 50, "C3KW"), New System.Data.OleDb.OleDbParameter("C3MinNumStages", System.Data.OleDb.OleDbType.[Integer], 0, "C3MinNumStages"), New System.Data.OleDb.OleDbParameter("C3NumExtraStages", System.Data.OleDb.OleDbType.[Integer], 0, "C3NumExtraStages"), New System.Data.OleDb.OleDbParameter("C3OperatingTemperature", System.Data.OleDb.OleDbType.[Single], 0, "C3OperatingTemperature"), New System.Data.OleDb.OleDbParameter("C3OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "C3OrderIndex"), New System.Data.OleDb.OleDbParameter("C3SiliconControlledRectifier", System.Data.OleDb.OleDbType.[Boolean], 2, "C3SiliconControlledRectifier"), New System.Data.OleDb.OleDbParameter("Coil0OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Coil0OrderIndex"), New System.Data.OleDb.OleDbParameter("Coil1OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Coil1OrderIndex"), New System.Data.OleDb.OleDbParameter("Coil2OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Coil2OrderIndex"), New System.Data.OleDb.OleDbParameter("CoilCasing0", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilCasing0"), New System.Data.OleDb.OleDbParameter("CoilCasing1", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilCasing1"), New System.Data.OleDb.OleDbParameter("CoilCasing2", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilCasing2"), New System.Data.OleDb.OleDbParameter("CoilRows0", System.Data.OleDb.OleDbType.[Integer], 0, "CoilRows0"), New System.Data.OleDb.OleDbParameter("CoilRows1", System.Data.OleDb.OleDbType.[Integer], 0, "CoilRows1"), New System.Data.OleDb.OleDbParameter("CoilRows2", System.Data.OleDb.OleDbType.[Integer], 0, "CoilRows2"), New System.Data.OleDb.OleDbParameter("CoilType0", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilType0"), New System.Data.OleDb.OleDbParameter("CoilType1", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilType1"), New System.Data.OleDb.OleDbParameter("CoilType2", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilType2"), New System.Data.OleDb.OleDbParameter("DischargeGrating", System.Data.OleDb.OleDbType.[Boolean], 2, "DischargeGrating"), New System.Data.OleDb.OleDbParameter("DischargeHeight", System.Data.OleDb.OleDbType.[Integer], 0, "DischargeHeight"), New System.Data.OleDb.OleDbParameter("DischargeOpeningLocation", System.Data.OleDb.OleDbType.VarWChar, 50, "DischargeOpeningLocation"), New System.Data.OleDb.OleDbParameter("DischargeOrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "DischargeOrderIndex"), New System.Data.OleDb.OleDbParameter("DischargeWidth", System.Data.OleDb.OleDbType.[Integer], 0, "DischargeWidth"), New System.Data.OleDb.OleDbParameter("Fan0OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Fan0OrderIndex"), New System.Data.OleDb.OleDbParameter("Fan1OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Fan1OrderIndex"), New System.Data.OleDb.OleDbParameter("Fan2OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Fan2OrderIndex"), New System.Data.OleDb.OleDbParameter("FanClass0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanClass0"), New System.Data.OleDb.OleDbParameter("FanClass1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanClass1"), New System.Data.OleDb.OleDbParameter("FanClass2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanClass2"), New System.Data.OleDb.OleDbParameter("FanDrive0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanDrive0"), New System.Data.OleDb.OleDbParameter("FanDrive1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanDrive1"), New System.Data.OleDb.OleDbParameter("FanDrive2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanDrive2"), New System.Data.OleDb.OleDbParameter("FanEfficiency0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanEfficiency0"), New System.Data.OleDb.OleDbParameter("FanEfficiency1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanEfficiency1"), New System.Data.OleDb.OleDbParameter("FanEfficiency2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanEfficiency2"), New System.Data.OleDb.OleDbParameter("FanEnclosure0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanEnclosure0"), New System.Data.OleDb.OleDbParameter("FanEnclosure1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanEnclosure1"), New System.Data.OleDb.OleDbParameter("FanEnclosure2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanEnclosure2"), New System.Data.OleDb.OleDbParameter("FanHorsepower1", System.Data.OleDb.OleDbType.[Integer], 0, "FanHorsepower1"), New System.Data.OleDb.OleDbParameter("FanHorsepower0", System.Data.OleDb.OleDbType.[Integer], 0, "FanHorsepower0"), New System.Data.OleDb.OleDbParameter("FanHorsepower2", System.Data.OleDb.OleDbType.[Integer], 0, "FanHorsepower2"), New System.Data.OleDb.OleDbParameter("FanIsolator0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanIsolator0"), New System.Data.OleDb.OleDbParameter("FanIsolator1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanIsolator1"), New System.Data.OleDb.OleDbParameter("FanIsolator2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanIsolator2"), New System.Data.OleDb.OleDbParameter("FanRPM0", System.Data.OleDb.OleDbType.[Integer], 0, "FanRPM0"), New System.Data.OleDb.OleDbParameter("FanRPM1", System.Data.OleDb.OleDbType.[Integer], 0, "FanRPM1"), New System.Data.OleDb.OleDbParameter("FanRPM2", System.Data.OleDb.OleDbType.[Integer], 0, "FanRPM2"), New System.Data.OleDb.OleDbParameter("FanSize0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanSize0"), New System.Data.OleDb.OleDbParameter("FanSize1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanSize1"), New System.Data.OleDb.OleDbParameter("FanSize2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanSize2"), New System.Data.OleDb.OleDbParameter("FanType0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanType0"), New System.Data.OleDb.OleDbParameter("FanType1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanType1"), New System.Data.OleDb.OleDbParameter("FanType2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanType2"), New System.Data.OleDb.OleDbParameter("Filt0", System.Data.OleDb.OleDbType.VarWChar, 50, "Filt0"), New System.Data.OleDb.OleDbParameter("Filt0OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Filt0OrderIndex"), New System.Data.OleDb.OleDbParameter("Filt1", System.Data.OleDb.OleDbType.VarWChar, 50, "Filt1"), New System.Data.OleDb.OleDbParameter("Filt1OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Filt1OrderIndex"), New System.Data.OleDb.OleDbParameter("Filt2", System.Data.OleDb.OleDbType.VarWChar, 50, "Filt2"), New System.Data.OleDb.OleDbParameter("Filt2OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Filt2OrderIndex"), New System.Data.OleDb.OleDbParameter("FinMaterial0", System.Data.OleDb.OleDbType.VarWChar, 50, "FinMaterial0"), New System.Data.OleDb.OleDbParameter("FinMaterial1", System.Data.OleDb.OleDbType.VarWChar, 50, "FinMaterial1"), New System.Data.OleDb.OleDbParameter("FinMaterial2", System.Data.OleDb.OleDbType.VarWChar, 50, "FinMaterial2"), New System.Data.OleDb.OleDbParameter("FinThickness0", System.Data.OleDb.OleDbType.[Single], 0, "FinThickness0"), New System.Data.OleDb.OleDbParameter("FinThickness1", System.Data.OleDb.OleDbType.[Single], 0, "FinThickness1"), New System.Data.OleDb.OleDbParameter("FinThickness2", System.Data.OleDb.OleDbType.[Single], 0, "FinThickness2"), New System.Data.OleDb.OleDbParameter("MB1Casing", System.Data.OleDb.OleDbType.VarWChar, 50, "MB1Casing"), New System.Data.OleDb.OleDbParameter("MB1IncomingAir", System.Data.OleDb.OleDbType.VarWChar, 50, "MB1IncomingAir"), New System.Data.OleDb.OleDbParameter("MB1OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "MB1OrderIndex"), New System.Data.OleDb.OleDbParameter("MB2Casing", System.Data.OleDb.OleDbType.VarWChar, 50, "MB2Casing"), New System.Data.OleDb.OleDbParameter("MB2IncomingAir", System.Data.OleDb.OleDbType.VarWChar, 50, "MB2IncomingAir"), New System.Data.OleDb.OleDbParameter("MB2OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "MB2OrderIndex"), New System.Data.OleDb.OleDbParameter("NumFilts0", System.Data.OleDb.OleDbType.[Integer], 0, "NumFilts0"), New System.Data.OleDb.OleDbParameter("NumFilts1", System.Data.OleDb.OleDbType.[Integer], 0, "NumFilts1"), New System.Data.OleDb.OleDbParameter("NumFilts2", System.Data.OleDb.OleDbType.[Integer], 0, "NumFilts2"), New System.Data.OleDb.OleDbParameter("NumFins0", System.Data.OleDb.OleDbType.[Integer], 0, "NumFins0"), New System.Data.OleDb.OleDbParameter("NumFins1", System.Data.OleDb.OleDbType.[Integer], 0, "NumFins1"), New System.Data.OleDb.OleDbParameter("NumFins2", System.Data.OleDb.OleDbType.[Integer], 0, "NumFins2"), New System.Data.OleDb.OleDbParameter("NumPreFilts0", System.Data.OleDb.OleDbType.[Integer], 0, "NumPreFilts0"), New System.Data.OleDb.OleDbParameter("NumPreFilts1", System.Data.OleDb.OleDbType.[Integer], 0, "NumPreFilts1"), New System.Data.OleDb.OleDbParameter("NumPreFilts2", System.Data.OleDb.OleDbType.[Integer], 0, "NumPreFilts2"), New System.Data.OleDb.OleDbParameter("PreFilt0", System.Data.OleDb.OleDbType.VarWChar, 50, "PreFilt0"), New System.Data.OleDb.OleDbParameter("PreFilt1", System.Data.OleDb.OleDbType.VarWChar, 50, "PreFilt1"), New System.Data.OleDb.OleDbParameter("PreFilt2", System.Data.OleDb.OleDbType.VarWChar, 50, "PreFilt2"), New System.Data.OleDb.OleDbParameter("TubeThickness0", System.Data.OleDb.OleDbType.[Single], 0, "TubeThickness0"), New System.Data.OleDb.OleDbParameter("TubeThickness1", System.Data.OleDb.OleDbType.[Single], 0, "TubeThickness1"), New System.Data.OleDb.OleDbParameter("TubeThickness2", System.Data.OleDb.OleDbType.[Single], 0, "TubeThickness2")})
        '
        'OleDbSelectCommand4
        '
        Me.OleDbSelectCommand4.CommandText = resources.GetString("OleDbSelectCommand4.CommandText")
        Me.OleDbSelectCommand4.Connection = Me.conProject
        Me.OleDbSelectCommand4.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("AirHandlerID", System.Data.OleDb.OleDbType.[Integer], 0, "AirHandlerID")})
        '
        'OleDbUpdateCommand4
        '
        Me.OleDbUpdateCommand4.CommandText = resources.GetString("OleDbUpdateCommand4.CommandText")
        Me.OleDbUpdateCommand4.Connection = Me.conProject
        Me.OleDbUpdateCommand4.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("AirHandlerID", System.Data.OleDb.OleDbType.[Integer], 0, "AirHandlerID"), New System.Data.OleDb.OleDbParameter("C3Disconnect", System.Data.OleDb.OleDbType.[Boolean], 2, "C3Disconnect"), New System.Data.OleDb.OleDbParameter("C3KW", System.Data.OleDb.OleDbType.VarWChar, 50, "C3KW"), New System.Data.OleDb.OleDbParameter("C3MinNumStages", System.Data.OleDb.OleDbType.[Integer], 0, "C3MinNumStages"), New System.Data.OleDb.OleDbParameter("C3NumExtraStages", System.Data.OleDb.OleDbType.[Integer], 0, "C3NumExtraStages"), New System.Data.OleDb.OleDbParameter("C3OperatingTemperature", System.Data.OleDb.OleDbType.[Single], 0, "C3OperatingTemperature"), New System.Data.OleDb.OleDbParameter("C3OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "C3OrderIndex"), New System.Data.OleDb.OleDbParameter("C3SiliconControlledRectifier", System.Data.OleDb.OleDbType.[Boolean], 2, "C3SiliconControlledRectifier"), New System.Data.OleDb.OleDbParameter("Coil0OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Coil0OrderIndex"), New System.Data.OleDb.OleDbParameter("Coil1OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Coil1OrderIndex"), New System.Data.OleDb.OleDbParameter("Coil2OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Coil2OrderIndex"), New System.Data.OleDb.OleDbParameter("CoilCasing0", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilCasing0"), New System.Data.OleDb.OleDbParameter("CoilCasing1", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilCasing1"), New System.Data.OleDb.OleDbParameter("CoilCasing2", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilCasing2"), New System.Data.OleDb.OleDbParameter("CoilRows0", System.Data.OleDb.OleDbType.[Integer], 0, "CoilRows0"), New System.Data.OleDb.OleDbParameter("CoilRows1", System.Data.OleDb.OleDbType.[Integer], 0, "CoilRows1"), New System.Data.OleDb.OleDbParameter("CoilRows2", System.Data.OleDb.OleDbType.[Integer], 0, "CoilRows2"), New System.Data.OleDb.OleDbParameter("CoilType0", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilType0"), New System.Data.OleDb.OleDbParameter("CoilType1", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilType1"), New System.Data.OleDb.OleDbParameter("CoilType2", System.Data.OleDb.OleDbType.VarWChar, 50, "CoilType2"), New System.Data.OleDb.OleDbParameter("DischargeGrating", System.Data.OleDb.OleDbType.[Boolean], 2, "DischargeGrating"), New System.Data.OleDb.OleDbParameter("DischargeHeight", System.Data.OleDb.OleDbType.[Integer], 0, "DischargeHeight"), New System.Data.OleDb.OleDbParameter("DischargeOpeningLocation", System.Data.OleDb.OleDbType.VarWChar, 50, "DischargeOpeningLocation"), New System.Data.OleDb.OleDbParameter("DischargeOrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "DischargeOrderIndex"), New System.Data.OleDb.OleDbParameter("DischargeWidth", System.Data.OleDb.OleDbType.[Integer], 0, "DischargeWidth"), New System.Data.OleDb.OleDbParameter("Fan0OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Fan0OrderIndex"), New System.Data.OleDb.OleDbParameter("Fan1OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Fan1OrderIndex"), New System.Data.OleDb.OleDbParameter("Fan2OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Fan2OrderIndex"), New System.Data.OleDb.OleDbParameter("FanClass0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanClass0"), New System.Data.OleDb.OleDbParameter("FanClass1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanClass1"), New System.Data.OleDb.OleDbParameter("FanClass2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanClass2"), New System.Data.OleDb.OleDbParameter("FanDrive0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanDrive0"), New System.Data.OleDb.OleDbParameter("FanDrive1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanDrive1"), New System.Data.OleDb.OleDbParameter("FanDrive2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanDrive2"), New System.Data.OleDb.OleDbParameter("FanEfficiency0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanEfficiency0"), New System.Data.OleDb.OleDbParameter("FanEfficiency1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanEfficiency1"), New System.Data.OleDb.OleDbParameter("FanEfficiency2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanEfficiency2"), New System.Data.OleDb.OleDbParameter("FanEnclosure0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanEnclosure0"), New System.Data.OleDb.OleDbParameter("FanEnclosure1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanEnclosure1"), New System.Data.OleDb.OleDbParameter("FanEnclosure2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanEnclosure2"), New System.Data.OleDb.OleDbParameter("FanHorsepower1", System.Data.OleDb.OleDbType.[Integer], 0, "FanHorsepower1"), New System.Data.OleDb.OleDbParameter("FanHorsepower0", System.Data.OleDb.OleDbType.[Integer], 0, "FanHorsepower0"), New System.Data.OleDb.OleDbParameter("FanHorsepower2", System.Data.OleDb.OleDbType.[Integer], 0, "FanHorsepower2"), New System.Data.OleDb.OleDbParameter("FanIsolator0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanIsolator0"), New System.Data.OleDb.OleDbParameter("FanIsolator1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanIsolator1"), New System.Data.OleDb.OleDbParameter("FanIsolator2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanIsolator2"), New System.Data.OleDb.OleDbParameter("FanRPM0", System.Data.OleDb.OleDbType.[Integer], 0, "FanRPM0"), New System.Data.OleDb.OleDbParameter("FanRPM1", System.Data.OleDb.OleDbType.[Integer], 0, "FanRPM1"), New System.Data.OleDb.OleDbParameter("FanRPM2", System.Data.OleDb.OleDbType.[Integer], 0, "FanRPM2"), New System.Data.OleDb.OleDbParameter("FanSize0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanSize0"), New System.Data.OleDb.OleDbParameter("FanSize1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanSize1"), New System.Data.OleDb.OleDbParameter("FanSize2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanSize2"), New System.Data.OleDb.OleDbParameter("FanType0", System.Data.OleDb.OleDbType.VarWChar, 50, "FanType0"), New System.Data.OleDb.OleDbParameter("FanType1", System.Data.OleDb.OleDbType.VarWChar, 50, "FanType1"), New System.Data.OleDb.OleDbParameter("FanType2", System.Data.OleDb.OleDbType.VarWChar, 50, "FanType2"), New System.Data.OleDb.OleDbParameter("Filt0", System.Data.OleDb.OleDbType.VarWChar, 50, "Filt0"), New System.Data.OleDb.OleDbParameter("Filt0OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Filt0OrderIndex"), New System.Data.OleDb.OleDbParameter("Filt1", System.Data.OleDb.OleDbType.VarWChar, 50, "Filt1"), New System.Data.OleDb.OleDbParameter("Filt1OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Filt1OrderIndex"), New System.Data.OleDb.OleDbParameter("Filt2", System.Data.OleDb.OleDbType.VarWChar, 50, "Filt2"), New System.Data.OleDb.OleDbParameter("Filt2OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "Filt2OrderIndex"), New System.Data.OleDb.OleDbParameter("FinMaterial0", System.Data.OleDb.OleDbType.VarWChar, 50, "FinMaterial0"), New System.Data.OleDb.OleDbParameter("FinMaterial1", System.Data.OleDb.OleDbType.VarWChar, 50, "FinMaterial1"), New System.Data.OleDb.OleDbParameter("FinMaterial2", System.Data.OleDb.OleDbType.VarWChar, 50, "FinMaterial2"), New System.Data.OleDb.OleDbParameter("FinThickness0", System.Data.OleDb.OleDbType.[Single], 0, "FinThickness0"), New System.Data.OleDb.OleDbParameter("FinThickness1", System.Data.OleDb.OleDbType.[Single], 0, "FinThickness1"), New System.Data.OleDb.OleDbParameter("FinThickness2", System.Data.OleDb.OleDbType.[Single], 0, "FinThickness2"), New System.Data.OleDb.OleDbParameter("MB1Casing", System.Data.OleDb.OleDbType.VarWChar, 50, "MB1Casing"), New System.Data.OleDb.OleDbParameter("MB1IncomingAir", System.Data.OleDb.OleDbType.VarWChar, 50, "MB1IncomingAir"), New System.Data.OleDb.OleDbParameter("MB1OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "MB1OrderIndex"), New System.Data.OleDb.OleDbParameter("MB2Casing", System.Data.OleDb.OleDbType.VarWChar, 50, "MB2Casing"), New System.Data.OleDb.OleDbParameter("MB2IncomingAir", System.Data.OleDb.OleDbType.VarWChar, 50, "MB2IncomingAir"), New System.Data.OleDb.OleDbParameter("MB2OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, "MB2OrderIndex"), New System.Data.OleDb.OleDbParameter("NumFilts0", System.Data.OleDb.OleDbType.[Integer], 0, "NumFilts0"), New System.Data.OleDb.OleDbParameter("NumFilts1", System.Data.OleDb.OleDbType.[Integer], 0, "NumFilts1"), New System.Data.OleDb.OleDbParameter("NumFilts2", System.Data.OleDb.OleDbType.[Integer], 0, "NumFilts2"), New System.Data.OleDb.OleDbParameter("NumFins0", System.Data.OleDb.OleDbType.[Integer], 0, "NumFins0"), New System.Data.OleDb.OleDbParameter("NumFins1", System.Data.OleDb.OleDbType.[Integer], 0, "NumFins1"), New System.Data.OleDb.OleDbParameter("NumFins2", System.Data.OleDb.OleDbType.[Integer], 0, "NumFins2"), New System.Data.OleDb.OleDbParameter("NumPreFilts0", System.Data.OleDb.OleDbType.[Integer], 0, "NumPreFilts0"), New System.Data.OleDb.OleDbParameter("NumPreFilts1", System.Data.OleDb.OleDbType.[Integer], 0, "NumPreFilts1"), New System.Data.OleDb.OleDbParameter("NumPreFilts2", System.Data.OleDb.OleDbType.[Integer], 0, "NumPreFilts2"), New System.Data.OleDb.OleDbParameter("PreFilt0", System.Data.OleDb.OleDbType.VarWChar, 50, "PreFilt0"), New System.Data.OleDb.OleDbParameter("PreFilt1", System.Data.OleDb.OleDbType.VarWChar, 50, "PreFilt1"), New System.Data.OleDb.OleDbParameter("PreFilt2", System.Data.OleDb.OleDbType.VarWChar, 50, "PreFilt2"), New System.Data.OleDb.OleDbParameter("TubeThickness0", System.Data.OleDb.OleDbType.[Single], 0, "TubeThickness0"), New System.Data.OleDb.OleDbParameter("TubeThickness1", System.Data.OleDb.OleDbType.[Single], 0, "TubeThickness1"), New System.Data.OleDb.OleDbParameter("TubeThickness2", System.Data.OleDb.OleDbType.[Single], 0, "TubeThickness2"), New System.Data.OleDb.OleDbParameter("Original_SectionDetailsID", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SectionDetailsID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_AirHandlerID", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AirHandlerID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_AirHandlerID1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AirHandlerID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_C3Disconnect", System.Data.OleDb.OleDbType.[Boolean], 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "C3Disconnect", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_C3KW", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "C3KW", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_C3KW1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "C3KW", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_C3MinNumStages", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "C3MinNumStages", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_C3MinNumStages1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "C3MinNumStages", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_C3NumExtraStages", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "C3NumExtraStages", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_C3NumExtraStages1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "C3NumExtraStages", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_C3OperatingTemperature", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "C3OperatingTemperature", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_C3OperatingTemperature1", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "C3OperatingTemperature", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_C3OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "C3OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_C3OrderIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "C3OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_C3SiliconControlledRectifier", System.Data.OleDb.OleDbType.[Boolean], 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "C3SiliconControlledRectifier", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Coil0OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Coil0OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Coil0OrderIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Coil0OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Coil1OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Coil1OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Coil1OrderIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Coil1OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Coil2OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Coil2OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Coil2OrderIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Coil2OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilCasing0", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilCasing0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilCasing01", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilCasing0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilCasing1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilCasing1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilCasing11", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilCasing1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilCasing2", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilCasing2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilCasing21", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilCasing2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilRows0", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilRows0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilRows01", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilRows0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilRows1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilRows1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilRows11", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilRows1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilRows2", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilRows2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilRows21", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilRows2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilType0", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilType0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilType01", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilType0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilType1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilType1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilType11", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilType1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilType2", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilType2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_CoilType21", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CoilType2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_DischargeGrating", System.Data.OleDb.OleDbType.[Boolean], 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DischargeGrating", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_DischargeHeight", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DischargeHeight", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_DischargeHeight1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DischargeHeight", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_DischargeOpeningLocation", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DischargeOpeningLocation", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_DischargeOpeningLocation1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DischargeOpeningLocation", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_DischargeOrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DischargeOrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_DischargeOrderIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DischargeOrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_DischargeWidth", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DischargeWidth", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_DischargeWidth1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DischargeWidth", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Fan0OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Fan0OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Fan0OrderIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Fan0OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Fan1OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Fan1OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Fan1OrderIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Fan1OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Fan2OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Fan2OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Fan2OrderIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Fan2OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanClass0", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanClass0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanClass01", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanClass0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanClass1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanClass1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanClass11", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanClass1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanClass2", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanClass2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanClass21", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanClass2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanDrive0", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanDrive0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanDrive01", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanDrive0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanDrive1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanDrive1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanDrive11", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanDrive1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanDrive2", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanDrive2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanDrive21", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanDrive2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanEfficiency0", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanEfficiency0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanEfficiency01", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanEfficiency0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanEfficiency1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanEfficiency1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanEfficiency11", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanEfficiency1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanEfficiency2", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanEfficiency2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanEfficiency21", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanEfficiency2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanEnclosure0", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanEnclosure0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanEnclosure01", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanEnclosure0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanEnclosure1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanEnclosure1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanEnclosure11", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanEnclosure1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanEnclosure2", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanEnclosure2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanEnclosure21", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanEnclosure2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanHorsepower0", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanHorsepower0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanHorsepower01", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanHorsepower0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanHorsepower1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanHorsepower1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanHorsepower11", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanHorsepower1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanHorsepower2", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanHorsepower2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanHorsepower21", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanHorsepower2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanIsolator0", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanIsolator0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanIsolator01", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanIsolator0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanIsolator1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanIsolator1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanIsolator11", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanIsolator1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanIsolator2", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanIsolator2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanIsolator21", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanIsolator2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanRPM0", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanRPM0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanRPM01", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanRPM0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanRPM1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanRPM1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanRPM11", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanRPM1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanRPM2", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanRPM2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanRPM21", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanRPM2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanSize0", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanSize0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanSize01", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanSize0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanSize1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanSize1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanSize11", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanSize1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanSize2", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanSize2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanSize21", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanSize2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanType0", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanType0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanType01", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanType0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanType1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanType1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanType11", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanType1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanType2", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanType2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FanType21", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FanType2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Filt0", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Filt0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Filt01", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Filt0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Filt0OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Filt0OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Filt0OrderIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Filt0OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Filt1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Filt1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Filt11", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Filt1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Filt1OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Filt1OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Filt1OrderIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Filt1OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Filt2", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Filt2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Filt21", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Filt2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Filt2OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Filt2OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Filt2OrderIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Filt2OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FinMaterial0", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FinMaterial0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FinMaterial01", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FinMaterial0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FinMaterial1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FinMaterial1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FinMaterial11", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FinMaterial1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FinMaterial2", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FinMaterial2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FinMaterial21", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FinMaterial2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FinThickness0", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FinThickness0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FinThickness01", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FinThickness0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FinThickness1", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FinThickness1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FinThickness11", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FinThickness1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FinThickness2", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FinThickness2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_FinThickness21", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FinThickness2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MB1Casing", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MB1Casing", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MB1Casing1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MB1Casing", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MB1IncomingAir", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MB1IncomingAir", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MB1IncomingAir1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MB1IncomingAir", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MB1OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MB1OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MB1OrderIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MB1OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MB2Casing", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MB2Casing", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MB2Casing1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MB2Casing", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MB2IncomingAir", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MB2IncomingAir", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MB2IncomingAir1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MB2IncomingAir", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MB2OrderIndex", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MB2OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_MB2OrderIndex1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MB2OrderIndex", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumFilts0", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumFilts0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumFilts01", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumFilts0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumFilts1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumFilts1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumFilts11", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumFilts1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumFilts2", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumFilts2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumFilts21", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumFilts2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumFins0", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumFins0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumFins01", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumFins0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumFins1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumFins1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumFins11", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumFins1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumFins2", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumFins2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumFins21", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumFins2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumPreFilts0", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumPreFilts0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumPreFilts01", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumPreFilts0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumPreFilts1", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumPreFilts1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumPreFilts11", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumPreFilts1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumPreFilts2", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumPreFilts2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_NumPreFilts21", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NumPreFilts2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_PreFilt0", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PreFilt0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_PreFilt01", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PreFilt0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_PreFilt1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PreFilt1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_PreFilt11", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PreFilt1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_PreFilt2", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PreFilt2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_PreFilt21", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PreFilt2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_TubeThickness0", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TubeThickness0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_TubeThickness01", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TubeThickness0", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_TubeThickness1", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TubeThickness1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_TubeThickness11", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TubeThickness1", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_TubeThickness2", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TubeThickness2", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_TubeThickness21", System.Data.OleDb.OleDbType.[Single], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TubeThickness2", System.Data.DataRowVersion.Original, Nothing)})
        '
        'form_project_info
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(750, 396)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.SSTab1)
        Me.Controls.Add(Me.cmd_save_file)
        Me.Controls.Add(Me.cmd_close_me)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "form_project_info"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Air Handler Pricing - Project Information"
        Me.SSTab1.ResumeLayout(False)
        Me._SSTab1_TabPage0.ResumeLayout(False)
        Me._SSTab1_TabPage0.PerformLayout()
        CType(Me.DseProject1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame2.ResumeLayout(False)
        ''CType(Me.dgrC1Projects, System.ComponentModel.ISupportInitialize).EndInit()
        Me._SSTab1_TabPage1.ResumeLayout(False)
        ''CType(Me.dgrC1AirHandler, System.ComponentModel.ISupportInitialize).EndInit()
        Me._SSTab1_TabPage2.ResumeLayout(False)
        Me._SSTab1_TabPage2.PerformLayout()
        ''CType(Me.dgrC1Summary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ck_selection_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl_Unit_Net, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errProjectInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DseProjectClone, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Upgrade Support "
    Private Shared m_vb6FormDefInstance As form_project_info
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As form_project_info
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New form_project_info
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As form_project_info)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region


#Region "Routine descriptions"
    '//                     """"""""""""""""""""""""""
    '//                     ""      Subroutines     ""
    '//                     """"""""""""""""""""""""""
    '//
    '// CreateEmailFile().............. This sub creates a .ahufiles file so the rep can
    '//                                     send a copy of what they entered back to
    '//                                     RAE to be accessable to the sales and
    '//                                     engineering groups...
    '// OpenEmailFile()................ This sub is used to open the emailable .ahufiles
    '//                                     file
    '// TranslateSections()........... This sub takes what sections the user has chosen
    '//                                     and assigns the name of that section to a
    '//                                     variable S# to be put in the database used
    '//                                     to print the unit information and list
    '//                                     the section that were selected
    '// Set_Unit_Info(Unit_To_Set)..... Used to write the information of a certain
    '//                                     unit to a data base where it can be
    '//                                     accessed easliy throughout the program
    '// FillReportDatabases()................. This sub builds the database to hold the information
    '//                                     that is to be printed
    '// cbo_quantity_click()........... Used to make visable the number of unit info
    '//                                     lines chosen
    '// ck_indoor_1_Click(Index as Integer)....... Used to select only indoor or outdoor
    '// ck_no_paint_1_Click(Index as Integer)..... Used to select only no paint
    '// ck_outdoor_1_Click(Index as Integer)...... Used to select only outdoor
    '// ck_paint_1_Click(Index as Integer)........ Used to select only paint
    '// ck_selection_1_Click(Index as Integer).... Used to show the unit has information
    '// cmd_close_me_Click()........... This sub closes the form and unloads it
    '// cmd_email_load_Click()......... Loads the saved email files
    '// btnOpen_Click()........... This sub Loads the saved infomation selected
    '//                                     by the user to be reloaded to the form
    '//                                     to be viewed and or modified
    '// cmd_print_1_Click()............ This sub prints the info for the
    '//                                     selected unit
    '// cmd_RetrieveData_Click()....... This sub populates the List Box with
    '//                                     all the availabe saved data files
    '//                                     to select from
    '// cmd_save_file_Click().......... This sub saves the info for the project
    '//                                     into a database that can be accessed
    '//                                     at a later time
    '// cmd_unit_info_1_Click(Index as Integer)... Used to set the info and open the unit
    '//                                     info form
    '// Form_Load().................... Used to Load the form information
    '// Form_Unload().................. Used to shut the form down
    '// List1_Click().................. This sub makes the data to open features
    '//                                     visible
    '// SSTab1_MoveMouse............... This sub reopens the unit info form if all of
    '//                                     the information wasn't completed by the user
    '// txt_altitude_GotFocus()........ Erase the 1 set in the txt box so the
    '//                                     user can enter their own number
    '// txt_altitude_LostFocus()....... If the altitude is left blank the fill the
    '//                                     box with the value 1
    '// txt_quote_number_GotFocus().... Erase the 1 set in the txt box so the
    '//                                     user can enter their own number
    '// txt_quote_number_LostFocus()... If the quote number is left blank the fill the
    '//                                     box with the value 1
    '_____________________________________________________________________________
#End Region

    'instance of Pricing class
    Dim gPrices As New Pricing
    Dim usageLogger As Diagnostics.UsageLog.FormUsageLogger



    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Logs usage statistics available while form is closing.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[CASEYJ]	3/17/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub LogFormEnd()
        Dim model, refrigerant As String
        Dim ambientTemperature, suctionTemperature As Single

        Try
            ambientTemperature = 999
            suctionTemperature = 999
            ''If Me.dgrC1Summary.Splits(0).Rows.Count > 0 Then
            ''    model = Me.dgrC1Summary.Splits(0).DisplayColumns("Model Number").DataColumn.CellText(0)
            ''Else
            ''    model = "NA"
            ''End If
            refrigerant = "NA"
            'logs form usage statistics
            usageLogger.LogFormEnd(model, refrigerant, suctionTemperature, ambientTemperature)
        Catch ex As Exception

        End Try
    End Sub


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Logs start of form.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[CASEYJ]	3/17/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
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

    ''' <summary>
    ''' Ensures an air handler project database exists, and prevents existing project info from being overwritten.
    ''' </summary>
    ''' <history by="Casey" finish="2006/05/16">
    ''' Created
    ''' </history>
    Private Sub EnsureProjectDbExists()
        ' if file is missing, copies air handler project database from master folder to database folder
        UserDataProtector.EnsureFileExists(DataAccess.Common.AirHandlerProjectsDbPath, Constants.TARGET_USER_GROUP)
    End Sub


    Private Sub registerCoilPricing()
        Dim fileName As String = "RAEDLL_Coil_Pricing.dll"
        Dim filePath As String = System.IO.Path.Combine(AppInfo.AppFolderPath, fileName)

        If System.IO.File.Exists(filePath) Then
            Dim registrar As New ComRegistrar(filePath)
            registrar.Register(ComRegistrar.OutcomeMode.Silent)
        End If
    End Sub


    Private Sub form_project_info_Load(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.Load
        'logs form usage statistics
        Me.LogFormStart()

        registerCoilPricing()

        ' ensures project database exists, creates a new database if it doesn't already exist
        Me.EnsureProjectDbExists()

        Me.conProject.ConnectionString = DataAccess.Common.GetConnectionString(DataAccess.Common.AirHandlerProjectsDbPath)

        Dim b As New Binding("Text", Me.DseProject1, "SavedProject.TotalListPrice")
        AddHandler b.Parse, AddressOf CurrencyStringToDecimal
        AddHandler b.Format, AddressOf DecimalToCurrencyString
        Me.lbl_total_list_1.DataBindings.Add(b)

        ' hides controls from reps
        Dim isEmployee As Boolean = (AppInfo.User.authority_group = user_group.employee)
        ''Me.dgrC1Summary.Splits(0).DisplayColumns("BaseCost").Visible = isEmployee
        Me.txt_notes2.Visible = isEmployee
        Me.lblJobNotes.Visible = isEmployee

        Try
            Me.LoadProjects()
        Catch ex As Exception
            MessageBox.Show("Attempt to load projects caused an error. " & ex.Message, _
               "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub Me_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.VisibleChanged
        Dim isEmployee, pricingAuthorized As Boolean

        isEmployee = (AppInfo.User.authority_group = user_group.employee)
        pricingAuthorized = isEmployee '(AppInfo.User.AccessLevel = AccessLevel.TSI_P) _
        'Or (AppInfo.User.AccessLevel = AccessLevel.ALL_P)

        'hides costs from reps
        ''Me.dgrC1Summary.Splits(0).DisplayColumns("BaseCost").Visible = pricingAuthorized
        ''Me.dgrC1Summary.Splits(0).DisplayColumns("ListPrice").Visible = pricingAuthorized
        Me.lbl_total_list.Visible = pricingAuthorized
        Me.lbl_total_list_1.Visible = pricingAuthorized
        Me.lbl_multiplier.Visible = pricingAuthorized
        Me.txt_multiplier.Visible = pricingAuthorized
        Me._lbl_Unit_Net_10.Visible = pricingAuthorized
        Me.lbl_Unit_Net_1.Visible = pricingAuthorized
        Me.lbl_freight.Visible = pricingAuthorized
        Me.txt_freight.Visible = pricingAuthorized
        Me.lbl_start_up.Visible = pricingAuthorized
        Me.txt_start_up.Visible = pricingAuthorized
        Me.lbl_warranty.Visible = pricingAuthorized
        Me.txt_warranty.Visible = pricingAuthorized
        Me.txt_misc1.Visible = pricingAuthorized
        Me.txt_misc1_1.Visible = pricingAuthorized
        Me.txt_misc2.Visible = pricingAuthorized
        Me.txt_misc2_2.Visible = pricingAuthorized
        Me.txt_misc3.Visible = pricingAuthorized
        Me.txt_misc3_3.Visible = pricingAuthorized
        Me.lbl_total_sell_price_1.Visible = pricingAuthorized
        Me.lbl_total_sell_price_2.Visible = pricingAuthorized
        Me.btnCalculateCosts.Visible = pricingAuthorized

        'hides job notes from reps
        Me.txt_notes2.Visible = isEmployee
        Me.lblJobNotes.Visible = isEmployee
    End Sub

    Private Sub DecimalToCurrencyString(ByVal sender As Object, ByVal cevent As ConvertEventArgs)
        cevent.Value = ConvertNull.ToDouble(cevent.Value).ToString("c")
    End Sub

    Private Sub CurrencyStringToDecimal(ByVal sender As Object, ByVal cevent As ConvertEventArgs)
        cevent.Value = Decimal.Parse(ConvertNull.ToDouble(cevent.Value).ToString, _
           Globalization.NumberStyles.Currency, Nothing)
    End Sub



    Private Sub Set_Unit_Info(ByVal Unit_To_Set As Short)
        Dim airHandlers As Rae.RaeSolutions.Business.Entities.AirHandlerReferenceData.CoilsDataTable
        Dim unitInformation As form_unit_info
        Dim airflow As Double

        airflow = Me.DseProject1.SavedAirHandler(Unit_To_Set).Airflow

        ' retrieves air handlers based on airflow
        airHandlers = DataAgent.RetrieveAirHandlers(airflow)

        ' determines whether an air handler match is available
        If airHandlers.Rows.Count <= 0 Then
            Dim message As String = "No air handlers match the selection criteria."
            Ui.MessageBox.Show(message) : Exit Sub
        End If


        ' opens unit info form
        '
        unitInformation = New form_unit_info
        With unitInformation
            ' creates easy reference to parent form
            .Daddy = Me
            .AirHandlerID = Me.DseProject1.SavedAirHandler(Unit_To_Set).AirHandlerID
            Try
                .ShowDialog()
            Catch ex As Exception
                Ui.MessageBox.Show("Attempt to open unit information form failed. " & ex.Message)
            End Try
        End With
    End Sub



#Region "Project Information tab - control events"


#Region "Opens Project"

    'opens project
    Private Sub btnOpen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) _
    Handles btnOpen.Click
        Me.OpenProject()
    End Sub


    '1. Fills control values
    '2. Copies InfoReturn-SavedUnitInfo to InfoReturn-UnitInfo
    Private Sub OpenProject()
        Dim quoteNum As String

        'retrieves selected quote number
        ''If Not (Me.dgrC1Projects.Tag Is Nothing) Then
        ''    If CInt(Me.dgrC1Projects.Tag) > -1 Then
        ''        'datagrid's tag property stores row index (see datagrid_MouseDown)
        ''        quoteNum = Me.dgrC1Projects.Columns("QuoteNumber").CellText(Me.dgrC1Projects.Tag)
        ''    End If
        ''Else
        ''    Ui.MessageBox.Show("Please select a project.", MessageBoxIcon.Warning)
        ''    Exit Sub
        ''End If

        ' in case another project is loaded, clears the old project
        Me.DseProject1.Clear()

        Try
            'modifies select query to return rows with matching quote number
            Me.dadProject.SelectCommand.Parameters(0).Value = quoteNum
            'fills dataset w/ database project info, which fills bound control properties
            Me.dadProject.Fill(Me.DseProject1, "SavedProject")
        Catch Ex As Exception
            Ui.MessageBox.Show("Attempt to open project failed. " & Ex.Message, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try
            Me.dadAirHandler.SelectCommand.Parameters(0).Value = Me.DseProject1.SavedProject.Rows(0)(Me.DseProject1.SavedProject.ProjectIDColumn)
            'fills dataset w/ database air handler info, which fills bound controls
            Me.dadAirHandler.Fill(Me.DseProject1.SavedAirHandler)
        Catch Ex2 As Exception
            Ui.MessageBox.Show("Attempt to fill bound controls failed. " & Ex2.Message, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Me.CalculatePrices()

        'show each tab b/c bound controls don't get set until they're shown
        Me.SSTab1.TabPages(1).Show()
        Me.SSTab1.TabPages(2).Show()
    End Sub


    'deletes selected project
    Private Sub btnDeleteProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteProject.Click
        Dim projectID As Integer

        Me.Cursor = Cursors.WaitCursor

        'checks if any projects are loaded
        ''If Me.dgrC1Projects.Splits(0).Rows.Count < 1 Then
        ''    Ui.MessageBox.Show("No projects are loaded. Attempt to delete project failed.", MessageBoxIcon.Warning)
        ''    Exit Sub
        ''End If

        'gets project ID
        ''If Not (Me.dgrC1Projects.Tag Is Nothing) Then
        ''    If CInt(Me.dgrC1Projects.Tag) > -1 Then
        ''        'datagrid's tag property stores row index (see datagrid_MouseDown)
        ''        projectID = Me.dgrC1Projects.Columns("ProjectID").CellText(Me.dgrC1Projects.Tag)
        ''    End If
        ''Else
        ''    Ui.MessageBox.Show("Please select the project to be deleted. Then click 'Delete'.", MessageBoxIcon.Warning)
        ''    Exit Sub
        ''End If

        'deletes project
        Me.DeleteProject(projectID)

        'refreshes datagrid, so the same project isn't deleted multiple times which
        'would actually be deleting other projects
        Me.LoadProjects()

        Me.Cursor = Cursors.Arrow
    End Sub


    'deletes project
    Private Sub DeleteProject(ByVal projectID As Integer)
        Dim queDelete, queSelect As String
        Dim comDelete As OleDb.OleDbCommand
        Dim dadSelect As OleDb.OleDbDataAdapter
        Dim dseSelect As New DataSet
        Dim i As Integer
        Dim arrAirHandlerID As New ArrayList

        'gets air handler ids
        queSelect = "SELECT AirHandlerID FROM SavedAirHandler WHERE ProjectID = " & projectID
        dadSelect = New OleDb.OleDbDataAdapter(queSelect, Me.conProject)
        dadSelect.Fill(dseSelect)

        For i = 0 To dseSelect.Tables(0).Rows.Count - 1
            'gets air handler id
            arrAirHandlerID.Add(dseSelect.Tables(0).Rows(i)("AirHandlerID"))
            'deletes air handler
            Me.DeleteAirHandler(arrAirHandlerID(i))
        Next

        'deletes selected project
        queDelete = "DELETE FROM SavedProject WHERE ProjectID = " & projectID
        comDelete = New OleDb.OleDbCommand(queDelete, Me.conProject)
        Try
            conProject.Open()
            comDelete.ExecuteNonQuery()
        Catch Ex As Exception
            MessageBox.Show("Attempt to delete project failed. " & Ex.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not conProject.State.Equals(ConnectionState.Closed) Then conProject.Close()
        End Try

        'clear datasets
        Try
            Me.DseProject1.Clear()
        Catch ex As Exception
            MessageBox.Show("Attempt to clear datasets failed. " & ex.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'deletes air handler's sections
    Private Sub DeleteAirHandlerSections(ByVal airHandlerID As Integer)
        Dim queDelete, queSelect As String
        Dim comDelete As OleDb.OleDbCommand

        'deletes sections with air handler id
        queDelete = "DELETE FROM _Section WHERE AirHandlerID = " & airHandlerID
        comDelete = New OleDb.OleDbCommand(queDelete, Me.conProject)
        Try
            Me.conProject.Open()
            comDelete.ExecuteNonQuery()
        Catch Ex As Exception
            MessageBox.Show("Attempt to delete records from table, _Section, failed. " & Ex.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Me.conProject.State = ConnectionState.Open Then Me.conProject.Close()
        End Try
    End Sub

    'deletes air handler's section details
    Private Sub DeleteAirHandlerSectionDetails(ByVal airHandlerID As Integer)
        Dim queDelete, queSelect As String
        Dim comDelete As OleDb.OleDbCommand

        'deletes section details with air handler id
        queDelete = "DELETE FROM SectionDetails WHERE AirHandlerID = " & airHandlerID
        comDelete = New OleDb.OleDbCommand(queDelete, Me.conProject)
        Try
            Me.conProject.Open()
            comDelete.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Attempt to delete records from table, SectionDetails, failed. " & ex.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Me.conProject.State = ConnectionState.Open Then Me.conProject.Close()
        End Try
    End Sub

    'deletes air handler
    Private Sub DeleteAirHandler(ByVal airHandlerID As Integer)
        Dim queDelete, queSelect As String
        Dim comDelete As OleDb.OleDbCommand

        Me.DeleteAirHandlerSections(airHandlerID)
        Me.DeleteAirHandlerSectionDetails(airHandlerID)

        'deletes air handlers
        queDelete = "DELETE FROM SavedAirHandler WHERE AirHandlerID = " & airHandlerID
        comDelete = New OleDb.OleDbCommand(queDelete, Me.conProject)
        Try
            Me.conProject.Open()
            comDelete.ExecuteNonQuery()
        Catch ex2 As Exception
            MessageBox.Show("Attempt to delete records from table, AirHandlerID, failed. " & ex2.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Me.conProject.State = ConnectionState.Open Then Me.conProject.Close()
        End Try
    End Sub


#End Region


#End Region



    Private Sub LoadProjects()
        Dim queProjects As String = "SELECT DISTINCT [ProjectName], [QuoteNumber], [ProjectID] FROM SavedProject"
        Dim conProjects As New OleDb.OleDbConnection(DataAccess.Common.GetConnectionString(DataAccess.Common.AirHandlerProjectsDbPath))  ' mGlobal.DatabaseProvider & "; data source=" & mGlobal.ApplicationPath & "PricingAirHandler\Databases\inforeturn.mdb")
        Dim dadProjects As New OleDb.OleDbDataAdapter(queProjects, conProjects)
        Dim dseProjects As New DataSet
        Dim table As New DataTable("Project")
        dseProjects.Tables.Add(table)
        dadProjects.Fill(dseProjects, "Project")

        ''Me.dgrC1Projects.DataSource = dseProjects.Tables("Project")

        '8 pixels for scrollbar, 4 pixels for border
        ''Me.dgrC1Projects.Splits(0).DisplayColumns("ProjectName").Width = CInt(Me.dgrC1Projects.Width / 2) - 4 - 8
        ''Me.dgrC1Projects.Splits(0).DisplayColumns("QuoteNumber").Width = CInt(Me.dgrC1Projects.Width / 2) - 4 - 8
        ''Me.dgrC1Projects.Splits(0).DisplayColumns("ProjectID").Visible = False

        Me.btnOpen.Enabled = True

        ' selects project in first row
        ' datagrid's tag property stores the row index to be opened
        ''If Me.dgrC1Projects.Splits(0).Rows.Count > 0 Then
        ''    Me.dgrC1Projects.Tag = 0
        ''End If
    End Sub


    'returns whether function was successful or not
    '1. validates project info
    '2. saves project info and brief unit info for each unit in 
    '   project to InfoReturn-SavedQuoteRef
    '3. copies temporarily saved unit info from InfoReturn-UnitInfo to
    '   InfoReturn(-SavedUnitInfo) to be stored permanently
    '4. saves all info to text file that can be emailed
    Function Save() As Boolean
        Dim queSave As String
        Dim i As Integer

        '1. validates project info
        '>> shows messagebox if there are errors
        If Me.ValidateProjectInfo = False Then
            Return False
            Exit Function
        End If

        '2.
        'this is necessary in order for dataset.HasChanges to update
        Me.BindingContext(Me.DseProject1.SavedProject).EndCurrentEdit()
        'saves if changes occured
        If Me.DseProject1.HasChanges And Me.DseProject1.SavedProject.Rows.Count > 0 Then
            'updates database w/ data bound control properties
            Me.dadProject.Update(Me.DseProject1, "SavedProject")
        End If
        If Me.DseProject1.SavedAirHandler.Rows.Count > 0 Then
            Me.BindingContext(Me.DseProject1.SavedAirHandler).EndCurrentEdit()
            Try
                Me.dadAirHandler.Update(Me.DseProject1.SavedAirHandler)
            Catch ex As Exception
                MessageBox.Show("Air Handler database update failed." & _
                   Environment.NewLine & Environment.NewLine & _
                   ex.ToString, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        '4.
        '// Save and Email File
        'TODO: add back createEmailFile
        'CreateEmailFile()

        Return True
    End Function


    'saves
    Private Sub cmd_save_file_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) _
    Handles cmd_save_file.Click
        'if no project loaded, create project
        If Me.DseProject1.SavedProject.Rows.Count < 1 Then
            MessageBox.Show("A project is not open. Open a project or create a new project before saving.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Me.Save()
    End Sub




    'Private Sub SSTab1_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) _
    'Handles SSTab1.MouseMove

    '   '// If mustselect = 1 then reopen the form and to allow the user to select
    '   '// all the data
    '   If mustselect = 1 Then
    '      Set_Unit_Info((unit))
    '   End If

    '   'lbl_Unit_Net_1.Text = "$" & System.Math.Round _
    '   '   ((UnitList(0) + UnitList(1) + UnitList(2) + UnitList(3) _
    '   '   + UnitList(4) + UnitList(5) + UnitList(6) + UnitList(7) _
    '   '   + UnitList(8) + UnitList(9)) * Val(Me.txt_multiplier.Text), 2)

    '   'lbl_total_sell_price_2.Text = "$" & System.Math.Round _
    '   '   ((UnitList(0) + UnitList(1) + UnitList(2) + UnitList(3) _
    '   '   + UnitList(4) + UnitList(5) + UnitList(6) + UnitList(7) _
    '   '   + UnitList(8) + UnitList(9)) * 0.495, 2) _
    '   '   + Val(txt_freight.Text) + Val(txt_start_up.Text) + Val(txt_warranty.Text) _
    '   '   + Val(txt_misc1_1.Text) + Val(txt_misc2_2.Text) + Val(txt_misc3_3.Text)

    'End Sub



#Region "Validation"

    'Procedure to add new controls to validate
    '1. increment numberOfControlsToValidate
    '   and add control to array
    '2. call control's validating event
    '3. store control's reference name in its Tag
    '4. put validating code in controls validating event
    Private Function ValidateProjectInfo() As Boolean
        Dim IsValid As Boolean = True
        Dim i As Integer

        'cj validation
        'stores controls in an array
        Const numberOfControlsToValidate As Integer = 2
        Dim validationMessage As String = ""
        Dim controlsToValidate(numberOfControlsToValidate - 1) As Control
        controlsToValidate(0) = Me.txt_project_name
        'controlsToValidate(1) = Me.txt_altitude
        controlsToValidate(1) = Me.txt_quote_number
        'controlsToValidate(3) = Me.txt_multiplier

        'controlsToValidate(4) = Me._txt_airflow_1_0
        'controlsToValidate(5) = Me._txt_airflow_1_1
        'controlsToValidate(6) = Me._txt_airflow_1_2
        'controlsToValidate(7) = Me._txt_airflow_1_3
        'controlsToValidate(8) = Me._txt_airflow_1_4
        'controlsToValidate(9) = Me._txt_airflow_1_5
        'controlsToValidate(10) = Me._txt_airflow_1_6
        'controlsToValidate(11) = Me._txt_airflow_1_7
        'controlsToValidate(12) = Me._txt_airflow_1_8
        'controlsToValidate(13) = Me._txt_airflow_1_9

        'controlsToValidate(14) = Me._txt_ESP_1_0
        'controlsToValidate(15) = Me._txt_ESP_1_1
        'controlsToValidate(16) = Me._txt_ESP_1_2
        'controlsToValidate(17) = Me._txt_ESP_1_3
        'controlsToValidate(18) = Me._txt_ESP_1_4
        'controlsToValidate(19) = Me._txt_ESP_1_5
        'controlsToValidate(20) = Me._txt_ESP_1_6
        'controlsToValidate(21) = Me._txt_ESP_1_7
        'controlsToValidate(22) = Me._txt_ESP_1_8
        'controlsToValidate(23) = Me._txt_ESP_1_9


        'calls all validation events
        Me.txt_project_name_Validating(Me.txt_project_name, New System.ComponentModel.CancelEventArgs)
        Me.txt_quote_number_Validating(Me.txt_quote_number, New System.ComponentModel.CancelEventArgs)
        'Me.txt_altitude_Validating(Me.txt_altitude, New System.ComponentModel.CancelEventArgs)
        'Me.txt_multiplier_Validating(Me.txt_multiplier, New System.ComponentModel.CancelEventArgs)
        'For i = 0 To Me.cbo_quantity.SelectedItem - 1
        '   Me.txtAirFlow_Validating(Me.txt_airflow_1(i), New System.ComponentModel.CancelEventArgs)
        '   Me.txtExternalStaticPressure_Validating(Me.txt_ESP_1(i), New System.ComponentModel.CancelEventArgs)
        'Next


        For i = 0 To controlsToValidate.Length - 1
            If ((Not (controlsToValidate(i) Is Nothing)) And (Not DesignMode)) Then
                If Me.errProjectInfo.GetError(controlsToValidate(i)) <> "" Then
                    validationMessage &= Me.errProjectInfo.GetError(controlsToValidate(i)) & Chr(10) & Chr(13)
                End If
            End If
        Next

        If validationMessage <> "" Then
            MessageBox.Show(validationMessage _
               & Chr(10) & Chr(13) _
               & "The invalid controls must be corrected before the project can be saved.", _
               "RAESolutions", _
               MessageBoxButtons.OK, _
               MessageBoxIcon.Warning)
            IsValid = False
        End If

        Return IsValid
    End Function


    Private Sub txt_project_name_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles txt_project_name.Validating
        'shows error icon if project name is blank
        mValidator.ValidateBlankControl(sender, Me.errProjectInfo)
    End Sub


    'validates quote number
    Private Sub txt_quote_number_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles txt_quote_number.Validating
        mValidator.ValidateBlankControl(sender, Me.errProjectInfo)
    End Sub


    Private Sub txt_altitude_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles txt_altitude.Validating
        If Not mValidator.ValidateBlankControl(sender, Me.errProjectInfo) Then
            mValidator.ValidateNumericControl(Me.txt_altitude, Me.errProjectInfo)
        End If
    End Sub


    Private Sub txt_multiplier_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles txt_multiplier.Validating
        'if not blank
        If Not mValidator.ValidateBlankControl(sender, Me.errProjectInfo) Then
            'makes sure field is a number (##)(.)(##)
            mValidator.ValidateNumericControl(sender, Me.errProjectInfo)
        End If
    End Sub


    Private Sub txtAirFlow_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        'Handles _txt_airflow_1_0.Validating, _txt_airflow_1_1.Validating, _txt_airflow_1_2.Validating, _
        '_txt_airflow_1_3.Validating, _txt_airflow_1_4.Validating, _txt_airflow_1_5.Validating, _
        '_txt_airflow_1_6.Validating, _txt_airflow_1_7.Validating, _txt_airflow_1_8.Validating, _
        '_txt_airflow_1_9.Validating
        If Not mValidator.ValidateBlankControl(sender, Me.errProjectInfo) Then
            mValidator.ValidateNumericControl(sender, Me.errProjectInfo)
        End If
    End Sub

    Private Sub txtExternalStaticPressure_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        'Handles _txt_ESP_1_0.Validating, _txt_ESP_1_1.Validating, _txt_ESP_1_2.Validating, _
        '_txt_ESP_1_3.Validating, _txt_ESP_1_4.Validating, _txt_ESP_1_5.Validating, _
        '_txt_ESP_1_6.Validating, _txt_ESP_1_7.Validating, _txt_ESP_1_8.Validating, _
        '_txt_ESP_1_9.Validating
        If Not mValidator.ValidateBlankControl(sender, Me.errProjectInfo) Then
            mValidator.ValidateNumericControl(sender, Me.errProjectInfo)
        End If
    End Sub

#End Region


#Region "Printing"


    Private Sub viewUnitReport(ByVal airHandlerRow As Integer)

        Me.Cursor = Cursors.WaitCursor


        ' show_word_report()



        Dim unitReport As New ReportDocument()
        unitReport.Load(Reports.file_paths.AirHandlerUnitReportFilePath)

        Me.setUnitReportDataset(airHandlerRow)
        unitReport.SetDataSource(Me.DseProjectClone)

        Dim fields As ParameterFieldDefinitions = unitReport.DataDefinition.ParameterFields
        Dim field As New Rae.Reporting.CrystalReports.SingleParameterFieldDefinition(fields)

        field.Pass(AppInfo.User.username, "pfdCreator")
        field.Pass(My.Application.Info.Version.ToString(), "pfdVersion")
        field.Pass(form_unit_info.RetrieveTotalHours(Me.DseProjectClone.SavedAirHandler(0).AirHandlerID), "TotalHours")
        field.Pass(AppInfo.User.authority_group.ToString(), "AuthorityGroup")

        Dim viewerForm As New Rae.Reporting.CrystalReports.ReportViewerForm()
        viewerForm.ReportViewer.ReportSource = unitReport
        viewerForm.ShowDialog()




        Me.Cursor = Cursors.Default
    End Sub





    Private Sub show_word_report()
        'Dim parameters = get_report_parameters
        Dim text = New dictionary(Of String, String)


        Dim report = New Rae.reporting.beta.report(reports.file_paths.AirHandlerUnitReportWordFilePath)
        report.set_text(text)


        '        report.set_table("EquipmentDetails", options, New Rae.reporting.beta.default_table_factory)


        report.show()
    End Sub






    'sets unit report dataset (dseProjectClone) for passed air handler
    Private Function setUnitReportDataset(ByVal airHandlerRow As Integer) As DataSet
        'copies data from original to clone
        Me.BindingContext(Me.DseProject1).EndCurrentEdit()
        Me.DseProjectClone = Me.DseProject1.Copy()

        'don't enforce constraints otherwise SavedAirHandler can't be cleared
        'while _Section has rows due to constraints and error occurs
        Me.DseProjectClone.EnforceConstraints = False

        'clears clone air handlers
        Me.DseProjectClone.SavedAirHandler.Rows.Clear()

        'copies passed air handler row
        Dim rowCopy As dseProject.SavedAirHandlerRow
        rowCopy = Me.DseProjectClone.SavedAirHandler.NewSavedAirHandlerRow()
        For i As Integer = 0 To Me.DseProject1.SavedAirHandler.Columns.Count - 1
            rowCopy(i) = Me.DseProject1.SavedAirHandler.Rows(airHandlerRow).Item(i)
        Next
        'adds report's air handler to clone
        Me.DseProjectClone.SavedAirHandler.Rows.Add(rowCopy)

        'now constraints can be enforced again
        'this caused an error
        'Me.DseProjectClone.EnforceConstraints = True

        'fills clone w/ sections
        Me.DseProjectClone._Section.Clear()
        Me.dadSection.SelectCommand.Parameters(0).Value = Me.DseProject1.SavedAirHandler(airHandlerRow).AirHandlerID
        Me.dadSection.Fill(Me.DseProjectClone._Section)

        'fills clone w/ section details
        Me.DseProjectClone.SectionDetails.Clear()
        Dim retrieve As String = "SELECT AirHandlerID, C3Disconnect, C3KW, C3MinNumStages, C3NumExtraStages, C3OperatingTemperature, C3OrderIndex, C3SiliconControlledRectifier, Coil0OrderIndex, Coil1OrderIndex, Coil2OrderIndex, CoilCasing0, CoilCasing1, CoilCasing2, CoilRows0, CoilRows1, CoilRows2, CoilType0, CoilType1, CoilType2, DischargeGrating, DischargeHeight, DischargeOpeningLocation, DischargeOrderIndex, DischargeWidth, Fan0OrderIndex, Fan1OrderIndex, Fan2OrderIndex, FanClass0, FanClass1, FanClass2, FanDrive0, FanDrive1, FanDrive2, FanEfficiency0, FanEfficiency1, FanEfficiency2, FanEnclosure0, FanEnclosure1, FanEnclosure2, FanHorsepower0, FanHorsepower1, FanHorsepower2, FanIsolator0, FanIsolator1, FanIsolator2, FanRPM0, FanRPM1, FanRPM2, FanSize0, FanSize1, FanSize2, FanType0, FanType1, FanType2, Filt0, Filt0OrderIndex, Filt1, Filt1OrderIndex, Filt2, Filt2OrderIndex, FinMaterial0, FinMaterial1, FinMaterial2, FinThickness0, FinThickness1, FinThickness2, MB1Casing, MB1IncomingAir, MB1OrderIndex, MB2Casing, MB2IncomingAir, MB2OrderIndex, NumFilts0, NumFilts1, NumFilts2, NumFins0, NumFins1, NumFins2, NumPreFilts0, NumPreFilts1, NumPreFilts2, PreFilt0, PreFilt1, PreFilt2, SectionDetailsID, TubeThickness0, TubeThickness1, TubeThickness2, Coil4OrderIndex, CoilType4, FinMaterial4 FROM SectionDetails WHERE (AirHandlerID = ?)"
        Me.dadSectionDetails.SelectCommand.CommandText = retrieve
        Me.dadSectionDetails.SelectCommand.Parameters(0).Value = Me.DseProject1.SavedAirHandler(airHandlerRow).AirHandlerID
        Me.dadSectionDetails.Fill(Me.DseProjectClone.SectionDetails)

    End Function


    Private Sub viewSummaryReport()
        Me.Cursor = Cursors.WaitCursor

        Dim summaryReport As New ReportDocument()
        summaryReport.Load(Reports.file_paths.AirHandlerProjectReportFilePath)
        summaryReport.SetDataSource(Me.DseProject1)

        Dim fields As ParameterFieldDefinitions = summaryReport.DataDefinition.ParameterFields
        Dim field As New Rae.Reporting.CrystalReports.SingleParameterFieldDefinition(fields)

        field.Pass(AppInfo.User.username, "pfdCreator")
        field.Pass(My.Application.Info.Version.ToString, "pfdVersion")
        field.Pass(Me.lbl_total_sell_price_2.Text, "pfdTotalSellPrice")
        field.Pass(AppInfo.User.authority_group.ToString.ToLower, "pfdAuthorization")

        Dim viewerForm As New Rae.Reporting.CrystalReports.ReportViewerForm()
        viewerForm.ReportViewer.ReportSource = summaryReport
        viewerForm.ShowDialog()

        Me.Cursor = Cursors.Default
    End Sub


    'creates summary report
    Private Sub printSummaryButton_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles printSummaryButton.Click
        If Me.DseProject1.SavedProject.Rows.Count = 0 Then
            MessageBox.Show("A project must be opened before creating reports.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Me.viewSummaryReport()
    End Sub


#End Region



    'calculates
    Private Sub txt_multiplier_Leave(ByVal sender As Object, ByVal e As EventArgs) _
    Handles txt_multiplier.Leave
        Dim unitcount As Short

        'validation
        If mValidator.ValidateBlankControl(sender, Me.errProjectInfo) Then
            'if blank calculations will cause errors
            Exit Sub
        ElseIf Not (mValidator.ValidateNumericControl(sender, Me.errProjectInfo)) Then
            Exit Sub
        End If

        'calculates prices and fills controls
        Me.CalculatePrices()

    End Sub


    Private Sub cmd_close_me_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles cmd_close_me.Click
        Me.Close()
    End Sub


    'asks if user wants to save
    Private Sub form_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.Closing
        Dim message As String = "Do you want to save changes?"
        Dim title As String = My.Application.Info.ProductName
        Dim result As DialogResult

        Me.BindingContext(Me.DseProject1.SavedProject).EndCurrentEdit()
        Me.BindingContext(Me.DseProject1.SavedAirHandler).EndCurrentEdit()
        If Me.DseProject1.HasChanges() Then
            result = MessageBox.Show(message, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
            If result = DialogResult.Yes Then
                If Me.Save() = False Then
                    e.Cancel = True
                End If
            ElseIf result = DialogResult.Cancel Then
                e.Cancel = True
            ElseIf result = DialogResult.No Then
                'close don't save
            End If
        End If

        If e.Cancel = False Then
            'logs form usage statistics
            Me.LogFormEnd()
        End If
    End Sub


    'stores row index in tag property when mousedown and mouseup
    'events occur on the same row
    Dim row As Integer = 0
    ''Private Sub dgrC1Projects_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) _
    ''Handles dgrC1Projects.MouseDown
    ''    Me.row = Me.dgrC1Projects.RowContaining(e.Y)
    ''End Sub

    ''Private Sub dgrC1Projects_MouseUp(ByVal sender As System.Object, ByVal e As MouseEventArgs) _
    ''Handles dgrC1Projects.MouseUp
    ''    Dim rowUp As Integer = Me.dgrC1Projects.RowContaining(e.Y)

    ''    If rowUp = Me.row And row > -1 Then
    ''        Me.dgrC1Projects.Tag = row
    ''    End If
    ''End Sub


#Region "Prices"

    'calculates sell price
    Private Sub additions_Leave(ByVal sender As System.Object, ByVal eventArgs As System.EventArgs) _
    Handles txt_freight.Leave, txt_start_up.Leave, txt_warranty.Leave, txt_misc1_1.Leave, txt_misc2_2.Leave, txt_misc3_3.Leave
        If mValidator.ValidateBlankControl(sender, Me.errProjectInfo) Then
            Exit Sub
        End If
        Try
            Me.CalculatePrices()
        Catch ex As ExecutionEngineException
            MessageBox.Show("Pricing calculations failed." _
               & Environment.NewLine & Environment.NewLine _
               & ex.ToString, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCalculatePrices_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles btnCalculateCosts.Click
        If Me.DseProject1.SavedProject.Rows.Count = 0 Then
            MessageBox.Show("A project must be opened before calculations can be performed.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Me.CalculatePrices()
        Catch Ex As ExecutionEngineException
            MessageBox.Show("Pricing calculations failed." _
               & Environment.NewLine & Environment.NewLine _
               & Ex.ToString, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'calculates 1.total list price, 2. net price, 3. total sell price
    Friend Function CalculatePrices() As Boolean
        Dim listPrice(Me.DseProject1.SavedAirHandler.Rows.Count) As Single
        Dim multiplier As Single
        Dim totalListPrice As Single
        Dim netPrice As Single
        Dim freight, startup, warranty As Single
        Dim misc1, misc2, misc3 As Single
        Dim sellPrice As Single
        Dim i As Integer

        'PARAMETERS
        '-------------------
        'gets array of each air handler's list price
        For i = 0 To Me.DseProject1.SavedAirHandler.Rows.Count - 1
            listPrice(i) = ConvertNull.ToSingle(Me.DseProject1.SavedAirHandler.Rows(i)(Me.DseProject1.SavedAirHandler.ListPriceColumn))
        Next
        'set multiplier
        multiplier = ConvertNull.ToSingle(Me.DseProject1.SavedProject.Rows(0)(Me.DseProject1.SavedProject.MultiplierColumn))
        'sell price parameters
        freight = ConvertNull.ToSingle(Me.DseProject1.SavedProject.Rows(0)(Me.DseProject1.SavedProject.FreightCostColumn))
        startup = ConvertNull.ToSingle(Me.DseProject1.SavedProject.Rows(0)(Me.DseProject1.SavedProject.StartupCostColumn))
        warranty = ConvertNull.ToSingle(Me.DseProject1.SavedProject.Rows(0)(Me.DseProject1.SavedProject.WarrantyCostColumn))
        misc1 = ConvertNull.ToSingle(Me.DseProject1.SavedProject.Rows(0)(Me.DseProject1.SavedProject.Misc1CostColumn))
        misc2 = ConvertNull.ToSingle(Me.DseProject1.SavedProject.Rows(0)(Me.DseProject1.SavedProject.Misc2CostColumn))
        misc3 = ConvertNull.ToSingle(Me.DseProject1.SavedProject.Rows(0)(Me.DseProject1.SavedProject.Misc3CostColumn))

        'CALCULATIONS
        '------------------
        'calculates total list price
        totalListPrice = gPrices.CalculateTotalListPrice(listPrice)
        'calculates net price
        netPrice = gPrices.CalculateNetPrice(multiplier, totalListPrice)
        'calculates sell price
        sellPrice = gPrices.CalculateTotalSellPrice(netPrice, freight, startup, warranty, misc1, misc2, misc3)

        'SETS CONTROL VALUES
        '--------------------
        Me.lbl_total_list_1.Text = Format(totalListPrice, "c")
        Me.lbl_Unit_Net_1.Text = Format(netPrice, "c")
        Me.lbl_total_sell_price_2.Text = Format(sellPrice, "c")

    End Function

#End Region


    'don't allow users to enter text into combobox
    Private Sub cbo_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
    Handles cbo_voltage.KeyDown
        e.Handled = True
    End Sub

    Private Sub cbo_KeyPress(ByVal s As Object, ByVal e As KeyPressEventArgs) _
    Handles cbo_voltage.KeyPress
        e.Handled = True
    End Sub


    ''Private Sub dgrAirHandler_OnAddNew(ByVal s As Object, ByVal e As EventArgs) Handles dgrC1AirHandler.OnAddNew
    ''    'Dim r As Integer = Me.dgrC1AirHandler.Row
    ''    'Dim projectID As Integer = Me.DseProject1.SavedProject.Rows(0)("ProjectID")

    ''    ''sets projectID to current project's id
    ''    'Me.dgrC1AirHandler.Splits(0).DisplayColumns("ProjectID").DataColumn.Value = projectID
    ''    'prevents air handler id from being null which was causing an error
    ''    'but doesn't update database value which autoincrements
    ''    'Me.dgrC1AirHandler.Splits(0).Rows(r)
    ''    'set projectID
    ''    'If r > -1 Then
    ''    '   Me.DseProject1.SavedAirHandler.Rows(r)(Me.DseProject1.SavedAirHandler.ProjectIDColumn) _
    ''    '      = Me.DseProject1.SavedProject.Rows(0)(Me.DseProject1.SavedProject.ProjectIDColumn)

    ''    'End If
    ''End Sub


    ''Private Sub dgrAirHandler_UnBound(ByVal s As Object, ByVal e As C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs) _
    ''Handles dgrC1AirHandler.UnboundColumnFetch
    ''    Select Case Me.dgrC1AirHandler.Columns(e.Col).Caption
    ''        Case "Select Model"
    ''            e.Value = "Select Model"
    ''    End Select
    ''End Sub

    ''Private Sub dgrAirHandler_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) _
    ''Handles dgrC1AirHandler.ButtonClick
    ''    Select Case Me.dgrC1AirHandler.Columns(e.Column.Name).Caption
    ''        Case "Select Model"
    ''            Me.SelectModel(Me.dgrC1AirHandler.Row)
    ''    End Select
    ''End Sub

    Private Sub SelectModel(ByVal index As Integer)
        Dim airflow As Single = 0

        Me.BindingContext(Me.DseProject1.SavedAirHandler).EndCurrentEdit()
        Try
            Me.dadAirHandler.Update(Me.DseProject1.SavedAirHandler)
        Catch Ex3 As Exception
            MessageBox.Show("Attempt to save air handlers while opening air handler form failed. " & Ex3.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        'altitude dbnull
        If Me.DseProject1.SavedProject.Rows(0)(Me.DseProject1.SavedProject.AltitudeColumn).GetType.Equals(GetType(System.DBNull)) Then
            MessageBox.Show("Enter altitude before opening this form.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        'airflow dbnull
        If Me.DseProject1.SavedAirHandler.Rows(index)(Me.DseProject1.SavedAirHandler.AirflowColumn).GetType.Equals(GetType(System.DBNull)) Then
            MessageBox.Show("Enter air flow value before opening this form.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        'esp dbnull
        If Me.DseProject1.SavedAirHandler.Rows(index)(Me.DseProject1.SavedAirHandler.ExternalStaticPressureColumn).GetType.Equals(GetType(System.DBNull)) Then
            MessageBox.Show("Enter external static pressure before opening this form.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        'multiplier dbnull
        If Me.DseProject1.SavedProject.Rows(0)(Me.DseProject1.SavedProject.MultiplierColumn).GetType.Equals(GetType(System.DBNull)) Then
            MessageBox.Show("Enter multiplier before opening this form.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        'voltage dnull
        If Me.DseProject1.SavedProject.Rows(0)(Me.DseProject1.SavedProject.VoltageColumn).GetType.Equals(GetType(System.DBNull)) Then
            MessageBox.Show("Enter voltage before opening this form.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        airflow = Me.DseProject1.SavedAirHandler.Rows(index)(Me.DseProject1.SavedAirHandler.AirflowColumn)
        '// Make some check to make sure these values have number in them so the program won't
        '//     run into a problem.
        '// The databases that read these values are expecting numbers
        '// If the user hasn't entered a number then promt them to do so...
        If txt_quote_number.Text = "" Then
            MsgBox("Enter Quote Number" & vbCrLf & "Project Information Tab")
            Exit Sub
        End If

        If Not IsNumeric(txt_altitude.Text) Then
            MsgBox("Enter Altitude in feet" & vbCrLf & "Project Information Tab")
            Exit Sub
        End If

        If cbo_voltage.Text = "" Then
            MsgBox("Select A Unit Voltage" & vbCrLf & "Project Information Tab")
            Exit Sub
        End If

        If airflow = Nothing Then
            MsgBox("Enter an Airflow" & vbCrLf & "Unit Information Tab")
            Exit Sub
        End If

        If airflow < 1450 Then
            MsgBox("Enter an Airflow greater than 1450.")
            Exit Sub
        End If

        If airflow > 32000 Then
            MsgBox("Enter an Airflow less than 32000.")
            Exit Sub
        End If

        If Me.DseProject1.SavedAirHandler(index).ExternalStaticPressure = Nothing Then
            MsgBox("Enter an ESP" & vbCrLf & "Unit Information Tab")
            Exit Sub
        End If

        If ConvertNull.ToSingle(Me.DseProject1.SavedProject(0).Multiplier, -33) = -33 Then
            MessageBox.Show("A multiplier is required before opening this form.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If ConvertNull.ToSingle(Me.DseProject1.SavedProject(0).Multiplier) = 0 Then
            MessageBox.Show("The multiplier cannot be 0. Enter a valid multiplier.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        '// Set unit info
        Set_Unit_Info(index)
    End Sub



    'sets unit report button text
    ''Private Sub dgrC1Summary_UnBound(ByVal s As Object, ByVal e As C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs) _
    ''Handles dgrC1Summary.UnboundColumnFetch
    ''    Select Case Me.dgrC1Summary.Columns(e.Col).Caption
    ''        Case "Unit Report"
    ''            e.Value = "Unit Report"
    ''    End Select
    ''End Sub


    'handles unit report button click
    ''Private Sub dgrC1Summary_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) _
    ''Handles dgrC1Summary.ButtonClick
    ''    Select Case Me.dgrC1Summary.Columns(e.Column.Name).Caption
    ''        Case "Unit Report"
    ''            'opens unit report
    ''            Me.viewUnitReport(Me.dgrC1Summary.Row)
    ''    End Select
    ''End Sub


    Private Sub btnNewProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewProject.Click
        Dim frmNew As New frmOpenAirHandler
        Dim row As dseProject.SavedProjectRow
        Dim projectName, quoteNumber As String

        Me.Cursor = Cursors.WaitCursor
        Try
            frmNew.ShowDialog()
        Catch Ex As Exception
            MessageBox.Show("Attempt to open form 'New Project' failed. " & Ex.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End Try
        Me.Cursor = Cursors.Arrow

        'runs after form is hidden
        If frmNew.canceled = True Then
            frmNew.Close()
            Exit Sub
        End If

        Try
            'get values from new project form
            projectName = frmNew.ProjectName
            quoteNumber = frmNew.QuoteNumber

            'closes new project form; it was just hidden before
            frmNew.Close()

            'clears all datasets
            Me.DseProject1.Clear()

            'sets required values
            row = Me.DseProject1.SavedProject.NewSavedProjectRow
            row.ProjectName = projectName
            row.QuoteNumber = quoteNumber
            'default
            row.Multiplier = 0.495
            row.Altitude = 0
            row.FreightCost = 0
            row.StartupCost = 0
            row.WarrantyCost = 0
            row.Misc1Cost = 0
            row.Misc2Cost = 0
            row.Misc3Cost = 0
            row.Misc1Label = "Misc 1"
            row.Misc2Label = "Misc 2"
            row.Misc3Label = "Misc 3"

            'adds new project
            Me.DseProject1.SavedProject.AddSavedProjectRow(row)

            'saves project
            Me.BindingContext(Me.DseProject1.SavedProject).EndCurrentEdit()
            Me.dadProject.Update(Me.DseProject1.SavedProject)

            'does not retrieve project id automatically, so refresh dataset
            Me.DseProject1.SavedProject.Clear()
            Me.dadProject.SelectCommand.Parameters(0).Value = quoteNumber
            Me.dadProject.Fill(Me.DseProject1.SavedProject)

        Catch Ex2 As Exception
            MessageBox.Show("Attempt to create a new project failed. " & Ex2.Message _
               , "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'loads projects
        Try
            Me.LoadProjects()
        Catch ex As Exception
            MessageBox.Show("Attempt to load projects caused an error. " & _
            ex.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnAddAirHandler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles btnAddAirHandler.Click
        If Me.DseProject1.SavedProject.Rows.Count = 0 Then
            MessageBox.Show("A project must be open before an air handler can be added.", "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim row As dseProject.SavedAirHandlerRow

        row = Me.DseProject1.SavedAirHandler.NewSavedAirHandlerRow

        row.BaseCost = 0
        row.ListPrice = 0
        row.Height = 0
        row.Width = 0
        row.Length = 0
        row.Tag = "AHU-" & Me.DseProject1.SavedAirHandler.Rows.Count + 1
        row.ProjectID = Me.DseProject1.SavedProject.Rows(0)(Me.DseProject1.SavedProject.ProjectIDColumn)

        Me.DseProject1.SavedAirHandler.Rows.Add(row)

        'all this just to update air handler id; otherwise air handler id is bogus and causes errors
        '-------------------------------------------------------------
        Me.BindingContext(Me.DseProject1.SavedAirHandler).EndCurrentEdit()
        Try
            'saves air handler
            Me.dadAirHandler.Update(Me.DseProject1.SavedAirHandler)

            'stops constraints so that air handlers can be cleared even if it contains sections
            Me.DseProject1.EnforceConstraints = False

            'fills air handlers; updates air handler id
            Me.DseProject1.SavedAirHandler.Clear()
            Me.dadAirHandler.SelectCommand.Parameters(0).Value = Me.DseProject1.SavedProject.Rows(0)(Me.DseProject1.SavedProject.ProjectIDColumn)
            Me.dadAirHandler.Fill(Me.DseProject1.SavedAirHandler)
        Catch ex As Exception
            MessageBox.Show("Attempt to refresh air handler id failed. " & ex.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    'deletes air handler, but doesn't delete sub sections
    ''Private Sub dgrC1AirHandler_BeforeDelete(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles dgrC1AirHandler.BeforeDelete
    ''    Dim airHandlerID As Integer
    ''    Dim rowToDelete As Integer

    ''    'sets row to delete
    ''    rowToDelete = Me.dgrC1AirHandler.Row
    ''    'gets air handler id for row to be deleted
    ''    airHandlerID = Me.dgrC1AirHandler.Splits(0).DisplayColumns("AirHandlerID").DataColumn.CellValue(rowToDelete)

    ''    'stores air handler id in tag so that it can be retrieved in AfterDelete event
    ''    Me.dgrC1AirHandler.Tag = airHandlerID

    ''End Sub


    ''Private Sub dgrC1AirHandler_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrC1AirHandler.AfterDelete
    ''    Dim airHandlerID As Integer

    ''    ' gets air handler id
    ''    airHandlerID = Me.dgrC1AirHandler.Tag

    ''    ' deletes sections and section details
    ''    Me.DeleteAirHandlerSections(airHandlerID)
    ''    Me.DeleteAirHandlerSectionDetails(airHandlerID)
    ''End Sub


    Private Sub lbl_Unit_Net_1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles lbl_Unit_Net_1.TextChanged
        If Me.IsInitializing Then
            Exit Sub
        End If

        Try
            Me.CalculatePrices()
        Catch
            'UNSURE: error occurred calculating prices
        End Try
    End Sub



    'Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
    'Handles Button1.Click
    '   'Dim form As New frmTest
    '   'form.dseProject = Me.DseProject1
    '   'form.Show()
    'End Sub

End Class




Public Class Pricing

    'sum of unit list prices
    Friend Function CalculateTotalListPrice(ByVal listPrice() As Single) As Single
        Dim i As Integer
        Dim totalListPrice As Single = 0

        Try
            'sums unit list prices
            For i = 0 To listPrice.GetLength(0) - 1
                totalListPrice += listPrice(i)
            Next
        Catch ex As Exception
            totalListPrice = 0
        End Try

        Return totalListPrice
    End Function


    'total list * multiplier
    Friend Function CalculateNetPrice(ByVal multiplier As Single, _
    ByVal totalListPrice As Single) As Single
        Dim netPrice As Single

        Try
            'calculates net price
            netPrice = totalListPrice * multiplier
        Catch ex As Exception
            'returns zero if error occurs
            netPrice = 0   'failed
        End Try

        Return netPrice
    End Function


    'net price + freight + start-up + warranty + miscellaneous(1-3)
    Friend Function CalculateTotalSellPrice(ByVal netPrice As Single, _
    ByVal freight As Single, ByVal startup As Single, ByVal warranty As Single, _
    ByVal misc1 As Single, ByVal misc2 As Single, ByVal misc3 As Single) As Single
        Dim totalSellPrice As Single = 0

        Try
            totalSellPrice = netPrice + freight + startup + warranty + misc1 + misc2 + misc3
        Catch ex As Exception
            totalSellPrice = 0
        End Try

        Return totalSellPrice
    End Function

End Class
'4527