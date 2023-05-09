Option Strict Off

Imports System
Imports System.Linq
Imports System.Math
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Data
Imports Path = System.IO.Path
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Rae.RaeSolutions.DataAccess
Imports Microsoft.VisualBasic
Imports Rae.Io.Text
Imports Rae.RaeSolutions.Business
Imports Rae.RaeSolutions.Business.Entities
Imports CNull = Rae.ConvertNull
Imports TerminalDecision = Rae.Ui.TerminalDecision
Imports Rae.Ui.TerminalDecision
Imports Rae.solutions
Imports Rae.solutions.group

Public Class condenser_rating_screen
    Inherits System.Windows.Forms.Form
    Public ProcessDeleted As Boolean

    Private NewLine As String = System.Environment.NewLine

#Region " Saving"

    ' Revision Control / Saving Variables...
    ' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    ' Last saved state...
    Public LastSavedProcess As CondenserProcessItem
    ' Current state before save...
    Public CurrentStateProcess As CondenserProcessItem

    ' Current displayed state revision 
    ' number reference...
    Private m_CurrentRevision As Single = -1

    ' Latest revision # of the current 
    ' process ID (if any)...
    Private m_LatestRevision As Single = -1

    ''' <summary>
    ''' The current revision # of process 
    ''' being displayed on this form.
    ''' </summary>
    Public Property CurrentRevision() As Single
        Get
            Return Me.m_CurrentRevision
        End Get
        Set(ByVal value As Single)
            Me.m_CurrentRevision = value
        End Set
    End Property


    ''' <summary>
    ''' The latest revision # of process 
    ''' being displayed on this form.
    ''' </summary>
    Public Property LatestRevision() As Integer
        Get
            Return Me.m_LatestRevision
        End Get
        Set(ByVal value As Integer)
            Me.m_LatestRevision = value
        End Set
    End Property


    ''' <summary>
    ''' The last saved state of CondenserProcessItem
    ''' </summary>
    ''' <remarks>
    ''' Save and open automatically set the current CondenserProcessItem to the last saved state
    ''' </remarks>
    Public Property LastSavedState() As CondenserProcessItem
        Get
            Return Me._SavedState
        End Get
        Set(ByVal Value As CondenserProcessItem)
            Me._SavedState = Value
        End Set
    End Property

#End Region


    ' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    Friend WithEvents condenserMenuStrip As MenuStrip
    Private WithEvents fileMenuItem As ToolStripMenuItem
    Private WithEvents printMenuItem As ToolStripMenuItem
    Private WithEvents saveMenuItem As ToolStripMenuItem
    Private WithEvents saveAsMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Private WithEvents saveAsRevisionMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Private WithEvents convertToEquipmentMenuItem As ToolStripMenuItem
    Private WithEvents subCoolingPercentLabel As Label
    Friend WithEvents SaveToolStripPanel1 As Rae.RaeSolutions.SaveToolStripPanel
    Private WithEvents goToPricingButton As System.Windows.Forms.Button
    Private _SavedState As CondenserProcessItem


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
    Friend WithEvents panCont As System.Windows.Forms.Panel
    Private WithEvents coilFaceLengthUnitLabel As System.Windows.Forms.Label
    Private WithEvents altitudeUnitLabel As System.Windows.Forms.Label
    Private WithEvents ambientTempUnitLabel As System.Windows.Forms.Label
    Private WithEvents temperatureDifferenceUnitLabel As System.Windows.Forms.Label
    Private WithEvents generalInfoLabel_ As System.Windows.Forms.Label
    Friend WithEvents panNote As System.Windows.Forms.Panel
    Friend WithEvents resultsDataGrid As System.Windows.Forms.DataGrid
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Private WithEvents rbo_10A0 As System.Windows.Forms.RadioButton
    Private WithEvents rbo_pfc As System.Windows.Forms.RadioButton
    Private WithEvents rbo_rac As System.Windows.Forms.RadioButton
    Private WithEvents txt_model As System.Windows.Forms.TextBox
    Private WithEvents cbo_model As System.Windows.Forms.ComboBox
    Friend WithEvents seriesPanel As System.Windows.Forms.Panel
    Private WithEvents coilFaceLengthTextBox As System.Windows.Forms.TextBox
    Private WithEvents coilFaceWidthTextBox As System.Windows.Forms.TextBox
    Private WithEvents cbo_refrigerant As System.Windows.Forms.ComboBox
    Private WithEvents subCoolingPercentTextBox As System.Windows.Forms.TextBox
    Private WithEvents subCoolingComboBox As System.Windows.Forms.ComboBox
    Private WithEvents numFansComboBox As System.Windows.Forms.ComboBox
    Private WithEvents subCoolingLabel As System.Windows.Forms.Label
    Private WithEvents altitudeLabel As System.Windows.Forms.Label
    Private WithEvents txt_altitude As System.Windows.Forms.TextBox
    Private WithEvents lblNumberOfFans As System.Windows.Forms.Label
    Private WithEvents coilFaceLengthLabel As System.Windows.Forms.Label
    Private WithEvents coilFaceWidthLabel As System.Windows.Forms.Label
    Private WithEvents refrigerantLabel As System.Windows.Forms.Label
    Private WithEvents modelNumberLabel As System.Windows.Forms.Label
    Private WithEvents temperatureDifferenceLabel As System.Windows.Forms.Label
    Private WithEvents txt_td As System.Windows.Forms.TextBox
    Private WithEvents txt_ambient As System.Windows.Forms.TextBox
    Private WithEvents ambientTempLabel As System.Windows.Forms.Label
    Private WithEvents fanComboBox As System.Windows.Forms.ComboBox
    Private WithEvents fanLabel As System.Windows.Forms.Label
    Private WithEvents cfmLabel As System.Windows.Forms.Label
    Private WithEvents cfmTextBox As System.Windows.Forms.TextBox
    Private WithEvents coilComboBox As System.Windows.Forms.ComboBox
    Private WithEvents coilLabel As System.Windows.Forms.Label
    Private WithEvents txt_esp As System.Windows.Forms.TextBox
    Private WithEvents espLabel As System.Windows.Forms.Label
    Private WithEvents catalogRatingCheckBox As System.Windows.Forms.CheckBox
    Private WithEvents lbl_info As System.Windows.Forms.Label
    Private WithEvents notesLabel As System.Windows.Forms.Label
    Private WithEvents txt_notes As System.Windows.Forms.TextBox
    Private WithEvents calculateButton As System.Windows.Forms.Button

    ' changed from private to friend for testing - dakotal
    Friend WithEvents viewReportButton As System.Windows.Forms.Button
    Private WithEvents seriesLabel As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(condenser_rating_screen))
        Me.panCont = New System.Windows.Forms.Panel()
        Me.goToPricingButton = New System.Windows.Forms.Button()
        Me.seriesLabel = New System.Windows.Forms.Label()
        Me.lbl_info = New System.Windows.Forms.Label()
        Me.txt_notes = New System.Windows.Forms.TextBox()
        Me.catalogRatingCheckBox = New System.Windows.Forms.CheckBox()
        Me.txt_esp = New System.Windows.Forms.TextBox()
        Me.coilComboBox = New System.Windows.Forms.ComboBox()
        Me.coilLabel = New System.Windows.Forms.Label()
        Me.cfmLabel = New System.Windows.Forms.Label()
        Me.cfmTextBox = New System.Windows.Forms.TextBox()
        Me.fanComboBox = New System.Windows.Forms.ComboBox()
        Me.fanLabel = New System.Windows.Forms.Label()
        Me.temperatureDifferenceLabel = New System.Windows.Forms.Label()
        Me.txt_td = New System.Windows.Forms.TextBox()
        Me.txt_ambient = New System.Windows.Forms.TextBox()
        Me.altitudeLabel = New System.Windows.Forms.Label()
        Me.txt_altitude = New System.Windows.Forms.TextBox()
        Me.subCoolingPercentTextBox = New System.Windows.Forms.TextBox()
        Me.subCoolingComboBox = New System.Windows.Forms.ComboBox()
        Me.subCoolingLabel = New System.Windows.Forms.Label()
        Me.lblNumberOfFans = New System.Windows.Forms.Label()
        Me.numFansComboBox = New System.Windows.Forms.ComboBox()
        Me.cbo_refrigerant = New System.Windows.Forms.ComboBox()
        Me.refrigerantLabel = New System.Windows.Forms.Label()
        Me.txt_model = New System.Windows.Forms.TextBox()
        Me.cbo_model = New System.Windows.Forms.ComboBox()
        Me.modelNumberLabel = New System.Windows.Forms.Label()
        Me.espLabel = New System.Windows.Forms.Label()
        Me.ambientTempUnitLabel = New System.Windows.Forms.Label()
        Me.temperatureDifferenceUnitLabel = New System.Windows.Forms.Label()
        Me.altitudeUnitLabel = New System.Windows.Forms.Label()
        Me.ambientTempLabel = New System.Windows.Forms.Label()
        Me.notesLabel = New System.Windows.Forms.Label()
        Me.generalInfoLabel_ = New System.Windows.Forms.Label()
        Me.coilFaceWidthLabel = New System.Windows.Forms.Label()
        Me.coilFaceLengthUnitLabel = New System.Windows.Forms.Label()
        Me.coilFaceLengthLabel = New System.Windows.Forms.Label()
        Me.coilFaceLengthTextBox = New System.Windows.Forms.TextBox()
        Me.coilFaceWidthTextBox = New System.Windows.Forms.TextBox()
        Me.calculateButton = New System.Windows.Forms.Button()
        Me.viewReportButton = New System.Windows.Forms.Button()
        Me.seriesPanel = New System.Windows.Forms.Panel()
        Me.rbo_rac = New System.Windows.Forms.RadioButton()
        Me.rbo_10A0 = New System.Windows.Forms.RadioButton()
        Me.rbo_pfc = New System.Windows.Forms.RadioButton()
        Me.condenserMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.fileMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.saveMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.saveAsRevisionMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.saveAsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.convertToEquipmentMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.printMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.subCoolingPercentLabel = New System.Windows.Forms.Label()
        Me.panNote = New System.Windows.Forms.Panel()
        Me.resultsDataGrid = New System.Windows.Forms.DataGrid()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SaveToolStripPanel1 = New Rae.RaeSolutions.SaveToolStripPanel()
        Me.panCont.SuspendLayout()
        Me.seriesPanel.SuspendLayout()
        Me.condenserMenuStrip.SuspendLayout()
        Me.panNote.SuspendLayout()
        CType(Me.resultsDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panCont
        '
        Me.panCont.Controls.Add(Me.goToPricingButton)
        Me.panCont.Controls.Add(Me.seriesLabel)
        Me.panCont.Controls.Add(Me.lbl_info)
        Me.panCont.Controls.Add(Me.txt_notes)
        Me.panCont.Controls.Add(Me.catalogRatingCheckBox)
        Me.panCont.Controls.Add(Me.txt_esp)
        Me.panCont.Controls.Add(Me.coilComboBox)
        Me.panCont.Controls.Add(Me.coilLabel)
        Me.panCont.Controls.Add(Me.cfmLabel)
        Me.panCont.Controls.Add(Me.cfmTextBox)
        Me.panCont.Controls.Add(Me.fanComboBox)
        Me.panCont.Controls.Add(Me.fanLabel)
        Me.panCont.Controls.Add(Me.temperatureDifferenceLabel)
        Me.panCont.Controls.Add(Me.txt_td)
        Me.panCont.Controls.Add(Me.txt_ambient)
        Me.panCont.Controls.Add(Me.altitudeLabel)
        Me.panCont.Controls.Add(Me.txt_altitude)
        Me.panCont.Controls.Add(Me.subCoolingPercentTextBox)
        Me.panCont.Controls.Add(Me.subCoolingComboBox)
        Me.panCont.Controls.Add(Me.subCoolingLabel)
        Me.panCont.Controls.Add(Me.lblNumberOfFans)
        Me.panCont.Controls.Add(Me.numFansComboBox)
        Me.panCont.Controls.Add(Me.cbo_refrigerant)
        Me.panCont.Controls.Add(Me.refrigerantLabel)
        Me.panCont.Controls.Add(Me.txt_model)
        Me.panCont.Controls.Add(Me.cbo_model)
        Me.panCont.Controls.Add(Me.modelNumberLabel)
        Me.panCont.Controls.Add(Me.espLabel)
        Me.panCont.Controls.Add(Me.ambientTempUnitLabel)
        Me.panCont.Controls.Add(Me.temperatureDifferenceUnitLabel)
        Me.panCont.Controls.Add(Me.altitudeUnitLabel)
        Me.panCont.Controls.Add(Me.ambientTempLabel)
        Me.panCont.Controls.Add(Me.notesLabel)
        Me.panCont.Controls.Add(Me.generalInfoLabel_)
        Me.panCont.Controls.Add(Me.coilFaceWidthLabel)
        Me.panCont.Controls.Add(Me.coilFaceLengthUnitLabel)
        Me.panCont.Controls.Add(Me.coilFaceLengthLabel)
        Me.panCont.Controls.Add(Me.coilFaceLengthTextBox)
        Me.panCont.Controls.Add(Me.coilFaceWidthTextBox)
        Me.panCont.Controls.Add(Me.calculateButton)
        Me.panCont.Controls.Add(Me.viewReportButton)
        Me.panCont.Controls.Add(Me.seriesPanel)
        Me.panCont.Controls.Add(Me.condenserMenuStrip)
        Me.panCont.Controls.Add(Me.subCoolingPercentLabel)
        Me.panCont.Dock = System.Windows.Forms.DockStyle.Top
        Me.panCont.Location = New System.Drawing.Point(0, 0)
        Me.panCont.Name = "panCont"
        Me.panCont.Size = New System.Drawing.Size(657, 562)
        Me.panCont.TabIndex = 1
        '
        'goToPricingButton
        '
        Me.goToPricingButton.BackColor = System.Drawing.Color.White
        Me.goToPricingButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.goToPricingButton.ForeColor = System.Drawing.Color.Navy
        Me.goToPricingButton.Image = Global.Rae.RaeSolutions.My.Resources.Resources.GoToArrow
        Me.goToPricingButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.goToPricingButton.Location = New System.Drawing.Point(312, 524)
        Me.goToPricingButton.Name = "goToPricingButton"
        Me.goToPricingButton.Size = New System.Drawing.Size(137, 32)
        Me.goToPricingButton.TabIndex = 115
        Me.goToPricingButton.Text = "Go To Pricing"
        Me.goToPricingButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.goToPricingButton.UseVisualStyleBackColor = False
        '
        'seriesLabel
        '
        Me.seriesLabel.Location = New System.Drawing.Point(27, 19)
        Me.seriesLabel.Margin = New System.Windows.Forms.Padding(3)
        Me.seriesLabel.Name = "seriesLabel"
        Me.seriesLabel.Size = New System.Drawing.Size(114, 23)
        Me.seriesLabel.TabIndex = 44
        Me.seriesLabel.Text = "Series"
        Me.seriesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_info
        '
        Me.lbl_info.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_info.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_info.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_info.Location = New System.Drawing.Point(26, 390)
        Me.lbl_info.Name = "lbl_info"
        Me.lbl_info.Size = New System.Drawing.Size(229, 125)
        Me.lbl_info.TabIndex = 30
        '
        'txt_notes
        '
        Me.txt_notes.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_notes.Location = New System.Drawing.Point(266, 390)
        Me.txt_notes.Multiline = True
        Me.txt_notes.Name = "txt_notes"
        Me.txt_notes.Size = New System.Drawing.Size(215, 125)
        Me.txt_notes.TabIndex = 32
        '
        'catalogRatingCheckBox
        '
        Me.catalogRatingCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.catalogRatingCheckBox.Location = New System.Drawing.Point(146, 344)
        Me.catalogRatingCheckBox.Name = "catalogRatingCheckBox"
        Me.catalogRatingCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.catalogRatingCheckBox.TabIndex = 28
        Me.catalogRatingCheckBox.Text = "Catalog rating"
        '
        'txt_esp
        '
        Me.txt_esp.Location = New System.Drawing.Point(146, 316)
        Me.txt_esp.Name = "txt_esp"
        Me.txt_esp.Size = New System.Drawing.Size(80, 23)
        Me.txt_esp.TabIndex = 26
        Me.txt_esp.Text = "0"
        '
        'coilComboBox
        '
        Me.coilComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.coilComboBox.Location = New System.Drawing.Point(146, 289)
        Me.coilComboBox.MaxDropDownItems = 12
        Me.coilComboBox.Name = "coilComboBox"
        Me.coilComboBox.Size = New System.Drawing.Size(335, 24)
        Me.coilComboBox.TabIndex = 24
        '
        'coilLabel
        '
        Me.coilLabel.Location = New System.Drawing.Point(27, 287)
        Me.coilLabel.Margin = New System.Windows.Forms.Padding(3)
        Me.coilLabel.Name = "coilLabel"
        Me.coilLabel.Size = New System.Drawing.Size(114, 23)
        Me.coilLabel.TabIndex = 33
        Me.coilLabel.Text = "Coil description"
        Me.coilLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cfmLabel
        '
        Me.cfmLabel.Location = New System.Drawing.Point(250, 262)
        Me.cfmLabel.Name = "cfmLabel"
        Me.cfmLabel.Size = New System.Drawing.Size(62, 23)
        Me.cfmLabel.TabIndex = 32
        Me.cfmLabel.Text = "CFM"
        Me.cfmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cfmLabel.Visible = False
        '
        'cfmTextBox
        '
        Me.cfmTextBox.BackColor = System.Drawing.SystemColors.Info
        Me.cfmTextBox.Location = New System.Drawing.Point(316, 262)
        Me.cfmTextBox.Name = "cfmTextBox"
        Me.cfmTextBox.Size = New System.Drawing.Size(71, 23)
        Me.cfmTextBox.TabIndex = 22
        Me.cfmTextBox.Text = "0"
        Me.cfmTextBox.Visible = False
        '
        'fanComboBox
        '
        Me.fanComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.fanComboBox.Location = New System.Drawing.Point(146, 235)
        Me.fanComboBox.MaxDropDownItems = 12
        Me.fanComboBox.Name = "fanComboBox"
        Me.fanComboBox.Size = New System.Drawing.Size(241, 24)
        Me.fanComboBox.TabIndex = 18
        '
        'fanLabel
        '
        Me.fanLabel.Location = New System.Drawing.Point(27, 234)
        Me.fanLabel.Margin = New System.Windows.Forms.Padding(3)
        Me.fanLabel.Name = "fanLabel"
        Me.fanLabel.Size = New System.Drawing.Size(114, 23)
        Me.fanLabel.TabIndex = 29
        Me.fanLabel.Text = "Fan description"
        Me.fanLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'temperatureDifferenceLabel
        '
        Me.temperatureDifferenceLabel.Location = New System.Drawing.Point(27, 207)
        Me.temperatureDifferenceLabel.Margin = New System.Windows.Forms.Padding(3)
        Me.temperatureDifferenceLabel.Name = "temperatureDifferenceLabel"
        Me.temperatureDifferenceLabel.Size = New System.Drawing.Size(114, 23)
        Me.temperatureDifferenceLabel.TabIndex = 26
        Me.temperatureDifferenceLabel.Text = "Temp. difference"
        Me.temperatureDifferenceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_td
        '
        Me.txt_td.Location = New System.Drawing.Point(146, 208)
        Me.txt_td.Name = "txt_td"
        Me.txt_td.Size = New System.Drawing.Size(80, 23)
        Me.txt_td.TabIndex = 16
        Me.txt_td.Text = "20"
        '
        'txt_ambient
        '
        Me.txt_ambient.Location = New System.Drawing.Point(146, 181)
        Me.txt_ambient.Name = "txt_ambient"
        Me.txt_ambient.Size = New System.Drawing.Size(80, 23)
        Me.txt_ambient.TabIndex = 14
        Me.txt_ambient.Text = "95"
        '
        'altitudeLabel
        '
        Me.altitudeLabel.Location = New System.Drawing.Point(26, 153)
        Me.altitudeLabel.Margin = New System.Windows.Forms.Padding(3)
        Me.altitudeLabel.Name = "altitudeLabel"
        Me.altitudeLabel.Size = New System.Drawing.Size(114, 23)
        Me.altitudeLabel.TabIndex = 21
        Me.altitudeLabel.Text = "Altitude"
        Me.altitudeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_altitude
        '
        Me.txt_altitude.Location = New System.Drawing.Point(146, 153)
        Me.txt_altitude.Name = "txt_altitude"
        Me.txt_altitude.Size = New System.Drawing.Size(80, 23)
        Me.txt_altitude.TabIndex = 12
        Me.txt_altitude.Text = "0"
        '
        'subCoolingPercentTextBox
        '
        Me.subCoolingPercentTextBox.Location = New System.Drawing.Point(326, 126)
        Me.subCoolingPercentTextBox.Name = "subCoolingPercentTextBox"
        Me.subCoolingPercentTextBox.Size = New System.Drawing.Size(71, 23)
        Me.subCoolingPercentTextBox.TabIndex = 10
        Me.subCoolingPercentTextBox.Text = "15"
        '
        'subCoolingComboBox
        '
        Me.subCoolingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.subCoolingComboBox.Items.AddRange(New Object() {"No", "Yes"})
        Me.subCoolingComboBox.Location = New System.Drawing.Point(146, 126)
        Me.subCoolingComboBox.Name = "subCoolingComboBox"
        Me.subCoolingComboBox.Size = New System.Drawing.Size(80, 24)
        Me.subCoolingComboBox.TabIndex = 9
        '
        'subCoolingLabel
        '
        Me.subCoolingLabel.Location = New System.Drawing.Point(27, 127)
        Me.subCoolingLabel.Margin = New System.Windows.Forms.Padding(3)
        Me.subCoolingLabel.Name = "subCoolingLabel"
        Me.subCoolingLabel.Size = New System.Drawing.Size(114, 23)
        Me.subCoolingLabel.TabIndex = 16
        Me.subCoolingLabel.Text = "Sub cooling"
        Me.subCoolingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNumberOfFans
        '
        Me.lblNumberOfFans.Location = New System.Drawing.Point(27, 262)
        Me.lblNumberOfFans.Margin = New System.Windows.Forms.Padding(3)
        Me.lblNumberOfFans.Name = "lblNumberOfFans"
        Me.lblNumberOfFans.Size = New System.Drawing.Size(114, 23)
        Me.lblNumberOfFans.TabIndex = 15
        Me.lblNumberOfFans.Text = "Number of fans"
        Me.lblNumberOfFans.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numFansComboBox
        '
        Me.numFansComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.numFansComboBox.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36"})
        Me.numFansComboBox.Location = New System.Drawing.Point(146, 262)
        Me.numFansComboBox.Name = "numFansComboBox"
        Me.numFansComboBox.Size = New System.Drawing.Size(80, 24)
        Me.numFansComboBox.TabIndex = 20
        '
        'cbo_refrigerant
        '
        Me.cbo_refrigerant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_refrigerant.Items.AddRange(New Object() {"R22", "R134a", "R404a", "R407c", "R507"})
        Me.cbo_refrigerant.Location = New System.Drawing.Point(147, 72)
        Me.cbo_refrigerant.Name = "cbo_refrigerant"
        Me.cbo_refrigerant.Size = New System.Drawing.Size(80, 24)
        Me.cbo_refrigerant.TabIndex = 6
        '
        'refrigerantLabel
        '
        Me.refrigerantLabel.Location = New System.Drawing.Point(27, 72)
        Me.refrigerantLabel.Margin = New System.Windows.Forms.Padding(3)
        Me.refrigerantLabel.Name = "refrigerantLabel"
        Me.refrigerantLabel.Size = New System.Drawing.Size(114, 24)
        Me.refrigerantLabel.TabIndex = 6
        Me.refrigerantLabel.Text = "Refrigerant"
        Me.refrigerantLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_model
        '
        Me.txt_model.Location = New System.Drawing.Point(292, 45)
        Me.txt_model.Name = "txt_model"
        Me.txt_model.Size = New System.Drawing.Size(131, 23)
        Me.txt_model.TabIndex = 5
        '
        'cbo_model
        '
        Me.cbo_model.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_model.Location = New System.Drawing.Point(147, 45)
        Me.cbo_model.MaxDropDownItems = 12
        Me.cbo_model.Name = "cbo_model"
        Me.cbo_model.Size = New System.Drawing.Size(139, 24)
        Me.cbo_model.TabIndex = 4
        '
        'modelNumberLabel
        '
        Me.modelNumberLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.modelNumberLabel.Location = New System.Drawing.Point(27, 45)
        Me.modelNumberLabel.Margin = New System.Windows.Forms.Padding(3)
        Me.modelNumberLabel.Name = "modelNumberLabel"
        Me.modelNumberLabel.Size = New System.Drawing.Size(114, 24)
        Me.modelNumberLabel.TabIndex = 3
        Me.modelNumberLabel.Text = "Model number"
        Me.modelNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'espLabel
        '
        Me.espLabel.Location = New System.Drawing.Point(27, 316)
        Me.espLabel.Margin = New System.Windows.Forms.Padding(3)
        Me.espLabel.Name = "espLabel"
        Me.espLabel.Size = New System.Drawing.Size(114, 23)
        Me.espLabel.TabIndex = 36
        Me.espLabel.Text = "Add ESP"
        Me.espLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.espLabel, "Additional external static pressure")
        '
        'ambientTempUnitLabel
        '
        Me.ambientTempUnitLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ambientTempUnitLabel.Location = New System.Drawing.Point(232, 181)
        Me.ambientTempUnitLabel.Name = "ambientTempUnitLabel"
        Me.ambientTempUnitLabel.Size = New System.Drawing.Size(31, 22)
        Me.ambientTempUnitLabel.TabIndex = 27
        Me.ambientTempUnitLabel.Text = "°F"
        Me.ambientTempUnitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'temperatureDifferenceUnitLabel
        '
        Me.temperatureDifferenceUnitLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.temperatureDifferenceUnitLabel.Location = New System.Drawing.Point(232, 208)
        Me.temperatureDifferenceUnitLabel.Name = "temperatureDifferenceUnitLabel"
        Me.temperatureDifferenceUnitLabel.Size = New System.Drawing.Size(31, 22)
        Me.temperatureDifferenceUnitLabel.TabIndex = 28
        Me.temperatureDifferenceUnitLabel.Text = "°F"
        Me.temperatureDifferenceUnitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'altitudeUnitLabel
        '
        Me.altitudeUnitLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.altitudeUnitLabel.Location = New System.Drawing.Point(233, 153)
        Me.altitudeUnitLabel.Name = "altitudeUnitLabel"
        Me.altitudeUnitLabel.Size = New System.Drawing.Size(145, 23)
        Me.altitudeUnitLabel.TabIndex = 22
        Me.altitudeUnitLabel.Text = "Feet above sea level"
        Me.altitudeUnitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ambientTempLabel
        '
        Me.ambientTempLabel.Location = New System.Drawing.Point(27, 180)
        Me.ambientTempLabel.Margin = New System.Windows.Forms.Padding(3)
        Me.ambientTempLabel.Name = "ambientTempLabel"
        Me.ambientTempLabel.Size = New System.Drawing.Size(114, 23)
        Me.ambientTempLabel.TabIndex = 24
        Me.ambientTempLabel.Text = "Ambient temp."
        Me.ambientTempLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'notesLabel
        '
        Me.notesLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.notesLabel.ForeColor = System.Drawing.Color.DimGray
        Me.notesLabel.Location = New System.Drawing.Point(268, 369)
        Me.notesLabel.Name = "notesLabel"
        Me.notesLabel.Size = New System.Drawing.Size(78, 21)
        Me.notesLabel.TabIndex = 41
        Me.notesLabel.Text = "Notes"
        Me.notesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'generalInfoLabel_
        '
        Me.generalInfoLabel_.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.generalInfoLabel_.ForeColor = System.Drawing.Color.DimGray
        Me.generalInfoLabel_.Location = New System.Drawing.Point(27, 369)
        Me.generalInfoLabel_.Name = "generalInfoLabel_"
        Me.generalInfoLabel_.Size = New System.Drawing.Size(106, 21)
        Me.generalInfoLabel_.TabIndex = 39
        Me.generalInfoLabel_.Text = "General Info"
        Me.generalInfoLabel_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'coilFaceWidthLabel
        '
        Me.coilFaceWidthLabel.Location = New System.Drawing.Point(26, 99)
        Me.coilFaceWidthLabel.Margin = New System.Windows.Forms.Padding(3)
        Me.coilFaceWidthLabel.Name = "coilFaceWidthLabel"
        Me.coilFaceWidthLabel.Size = New System.Drawing.Size(114, 23)
        Me.coilFaceWidthLabel.TabIndex = 9
        Me.coilFaceWidthLabel.Text = "Coil face:   Width"
        Me.coilFaceWidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'coilFaceLengthUnitLabel
        '
        Me.coilFaceLengthUnitLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.coilFaceLengthUnitLabel.Location = New System.Drawing.Point(400, 98)
        Me.coilFaceLengthUnitLabel.Name = "coilFaceLengthUnitLabel"
        Me.coilFaceLengthUnitLabel.Size = New System.Drawing.Size(54, 23)
        Me.coilFaceLengthUnitLabel.TabIndex = 13
        Me.coilFaceLengthUnitLabel.Text = "Inches"
        Me.coilFaceLengthUnitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'coilFaceLengthLabel
        '
        Me.coilFaceLengthLabel.Location = New System.Drawing.Point(264, 100)
        Me.coilFaceLengthLabel.Name = "coilFaceLengthLabel"
        Me.coilFaceLengthLabel.Size = New System.Drawing.Size(59, 21)
        Me.coilFaceLengthLabel.TabIndex = 11
        Me.coilFaceLengthLabel.Text = "Length"
        Me.coilFaceLengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'coilFaceLengthTextBox
        '
        Me.coilFaceLengthTextBox.Location = New System.Drawing.Point(326, 98)
        Me.coilFaceLengthTextBox.Name = "coilFaceLengthTextBox"
        Me.coilFaceLengthTextBox.Size = New System.Drawing.Size(71, 23)
        Me.coilFaceLengthTextBox.TabIndex = 8
        Me.coilFaceLengthTextBox.Text = "36"
        '
        'coilFaceWidthTextBox
        '
        Me.coilFaceWidthTextBox.Location = New System.Drawing.Point(147, 99)
        Me.coilFaceWidthTextBox.Name = "coilFaceWidthTextBox"
        Me.coilFaceWidthTextBox.Size = New System.Drawing.Size(80, 23)
        Me.coilFaceWidthTextBox.TabIndex = 7
        Me.coilFaceWidthTextBox.Text = "12"
        '
        'calculateButton
        '
        Me.calculateButton.BackColor = System.Drawing.Color.White
        Me.calculateButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.calculateButton.ForeColor = System.Drawing.Color.Navy
        Me.calculateButton.Image = CType(resources.GetObject("calculateButton.Image"), System.Drawing.Image)
        Me.calculateButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.calculateButton.Location = New System.Drawing.Point(26, 524)
        Me.calculateButton.Name = "calculateButton"
        Me.calculateButton.Size = New System.Drawing.Size(137, 32)
        Me.calculateButton.TabIndex = 34
        Me.calculateButton.Text = "Calculate Page "
        Me.calculateButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.calculateButton.UseVisualStyleBackColor = False
        '
        'viewReportButton
        '
        Me.viewReportButton.BackColor = System.Drawing.Color.White
        Me.viewReportButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.viewReportButton.ForeColor = System.Drawing.Color.Navy
        Me.viewReportButton.Image = CType(resources.GetObject("viewReportButton.Image"), System.Drawing.Image)
        Me.viewReportButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.viewReportButton.Location = New System.Drawing.Point(169, 524)
        Me.viewReportButton.Name = "viewReportButton"
        Me.viewReportButton.Size = New System.Drawing.Size(137, 32)
        Me.viewReportButton.TabIndex = 36
        Me.viewReportButton.Text = "View Report "
        Me.viewReportButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.viewReportButton.UseVisualStyleBackColor = False
        '
        'seriesPanel
        '
        Me.seriesPanel.Controls.Add(Me.rbo_rac)
        Me.seriesPanel.Controls.Add(Me.rbo_10A0)
        Me.seriesPanel.Controls.Add(Me.rbo_pfc)
        Me.seriesPanel.Location = New System.Drawing.Point(146, 16)
        Me.seriesPanel.Name = "seriesPanel"
        Me.seriesPanel.Size = New System.Drawing.Size(218, 28)
        Me.seriesPanel.TabIndex = 2
        '
        'rbo_rac
        '
        Me.rbo_rac.Dock = System.Windows.Forms.DockStyle.Left
        Me.rbo_rac.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbo_rac.Location = New System.Drawing.Point(140, 0)
        Me.rbo_rac.Name = "rbo_rac"
        Me.rbo_rac.Size = New System.Drawing.Size(70, 28)
        Me.rbo_rac.TabIndex = 3
        Me.rbo_rac.Tag = "RAC"
        Me.rbo_rac.Text = "RAC"
        '
        'rbo_10A0
        '
        Me.rbo_10A0.Dock = System.Windows.Forms.DockStyle.Left
        Me.rbo_10A0.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbo_10A0.Location = New System.Drawing.Point(70, 0)
        Me.rbo_10A0.Name = "rbo_10A0"
        Me.rbo_10A0.Size = New System.Drawing.Size(70, 28)
        Me.rbo_10A0.TabIndex = 2
        Me.rbo_10A0.Tag = "10A0"
        Me.rbo_10A0.Text = "10A0"
        '
        'rbo_pfc
        '
        Me.rbo_pfc.Checked = True
        Me.rbo_pfc.Dock = System.Windows.Forms.DockStyle.Left
        Me.rbo_pfc.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbo_pfc.Location = New System.Drawing.Point(0, 0)
        Me.rbo_pfc.Name = "rbo_pfc"
        Me.rbo_pfc.Size = New System.Drawing.Size(70, 28)
        Me.rbo_pfc.TabIndex = 1
        Me.rbo_pfc.TabStop = True
        Me.rbo_pfc.Tag = "PFC"
        Me.rbo_pfc.Text = "PFC"
        '
        'condenserMenuStrip
        '
        Me.condenserMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileMenuItem})
        Me.condenserMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.condenserMenuStrip.Name = "condenserMenuStrip"
        Me.condenserMenuStrip.Size = New System.Drawing.Size(589, 24)
        Me.condenserMenuStrip.TabIndex = 46
        Me.condenserMenuStrip.Text = "MenuStrip1"
        Me.condenserMenuStrip.Visible = False
        '
        'fileMenuItem
        '
        Me.fileMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.saveMenuItem, Me.saveAsRevisionMenuItem, Me.saveAsMenuItem, Me.ToolStripSeparator5, Me.convertToEquipmentMenuItem, Me.ToolStripSeparator1, Me.printMenuItem})
        Me.fileMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly
        Me.fileMenuItem.Name = "fileMenuItem"
        Me.fileMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.fileMenuItem.Text = "&File"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(197, 6)
        '
        'saveMenuItem
        '
        Me.saveMenuItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Save
        Me.saveMenuItem.Name = "saveMenuItem"
        Me.saveMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.saveMenuItem.Text = "Save"
        '
        'saveAsRevisionMenuItem
        '
        Me.saveAsRevisionMenuItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.SaveAsRevision
        Me.saveAsRevisionMenuItem.Name = "saveAsRevisionMenuItem"
        Me.saveAsRevisionMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.saveAsRevisionMenuItem.Text = "Save as Revision"
        '
        'saveAsMenuItem
        '
        Me.saveAsMenuItem.Name = "saveAsMenuItem"
        Me.saveAsMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.saveAsMenuItem.Text = "Save as..."
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(197, 6)
        '
        'convertToEquipmentMenuItem
        '
        Me.convertToEquipmentMenuItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.ConvertToEquipment
        Me.convertToEquipmentMenuItem.Name = "convertToEquipmentMenuItem"
        Me.convertToEquipmentMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.convertToEquipmentMenuItem.Text = "Convert to Equipment..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(197, 6)
        Me.ToolStripSeparator1.Visible = False
        '
        'printMenuItem
        '
        Me.printMenuItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Print
        Me.printMenuItem.Name = "printMenuItem"
        Me.printMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.printMenuItem.Text = "Print Condenser..."
        '
        'subCoolingPercentLabel
        '
        Me.subCoolingPercentLabel.Location = New System.Drawing.Point(226, 127)
        Me.subCoolingPercentLabel.Name = "subCoolingPercentLabel"
        Me.subCoolingPercentLabel.Size = New System.Drawing.Size(97, 21)
        Me.subCoolingPercentLabel.TabIndex = 47
        Me.subCoolingPercentLabel.Text = "Sub cooling %"
        Me.subCoolingPercentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panNote
        '
        Me.panNote.Controls.Add(Me.resultsDataGrid)
        Me.panNote.Dock = System.Windows.Forms.DockStyle.Top
        Me.panNote.Location = New System.Drawing.Point(0, 562)
        Me.panNote.Name = "panNote"
        Me.panNote.Size = New System.Drawing.Size(657, 176)
        Me.panNote.TabIndex = 2
        '
        'resultsDataGrid
        '
        Me.resultsDataGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.resultsDataGrid.BackgroundColor = System.Drawing.Color.Silver
        Me.resultsDataGrid.CaptionBackColor = System.Drawing.Color.LightSteelBlue
        Me.resultsDataGrid.CaptionForeColor = System.Drawing.Color.Black
        Me.resultsDataGrid.CaptionText = "Air Cooled Condenser Rating"
        Me.resultsDataGrid.DataMember = ""
        Me.resultsDataGrid.FlatMode = True
        Me.resultsDataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.resultsDataGrid.Location = New System.Drawing.Point(9, 6)
        Me.resultsDataGrid.Name = "resultsDataGrid"
        Me.resultsDataGrid.PreferredColumnWidth = 53
        Me.resultsDataGrid.ReadOnly = True
        Me.resultsDataGrid.RowHeaderWidth = 19
        Me.resultsDataGrid.Size = New System.Drawing.Size(639, 165)
        Me.resultsDataGrid.TabIndex = 0
        '
        'SaveToolStripPanel1
        '
        Me.SaveToolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SaveToolStripPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SaveToolStripPanel1.Name = "SaveToolStripPanel1"
        Me.SaveToolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.SaveToolStripPanel1.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.SaveToolStripPanel1.Size = New System.Drawing.Size(657, 0)
        '
        'condenser_rating_screen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(674, 631)
        Me.Controls.Add(Me.panNote)
        Me.Controls.Add(Me.panCont)
        Me.Controls.Add(Me.SaveToolStripPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuStrip = Me.condenserMenuStrip
        Me.Name = "condenser_rating_screen"
        Me.Text = "Air Cooled Condenser Rating"
        Me.panCont.ResumeLayout(False)
        Me.panCont.PerformLayout()
        Me.seriesPanel.ResumeLayout(False)
        Me.condenserMenuStrip.ResumeLayout(False)
        Me.condenserMenuStrip.PerformLayout()
        Me.panNote.ResumeLayout(False)
        CType(Me.resultsDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Const custom As String = "Custom"

    Private isLoaded As Boolean


#Region " Public methods"

    Public Function SaveControls(Optional ByVal SaveAsRevision As Boolean = False, Optional ByVal SaveAsNew As Boolean = False, Optional ByVal FormClosing As Boolean = False, Optional ByVal GenerateEquipment As Boolean = False, Optional ByVal RevChanged As Boolean = False) As Boolean

        If CurrentStateProcess Is Nothing Then
            If LastSavedProcess Is Nothing Then
                CurrentStateProcess = New CondenserProcessItem(New item_id(AppInfo.User.username, AppInfo.User.password))
            Else
                CurrentStateProcess = LastSavedProcess.Clone
            End If
        Else
            If LastSavedProcess IsNot Nothing Then CurrentStateProcess = LastSavedProcess.Clone
        End If

        ' Save series
        If Me.rbo_10A0.Checked = True Then
            CurrentStateProcess.Series = "10A0"
        ElseIf Me.rbo_pfc.Checked = True Then
            CurrentStateProcess.Series = "PFC"
        ElseIf Me.rbo_rac.Checked = True Then
            CurrentStateProcess.Series = "RAC"
        End If

        ' Save model
        CurrentStateProcess.Model = Me.cbo_model.Text

        ' Save refrigerant
        CurrentStateProcess.Refrigerant = Me.cbo_refrigerant.Text

        ' Save coil face dimensions
        CurrentStateProcess.CoilWidth = Me.coilFaceWidthTextBox.Text
        CurrentStateProcess.CoilLength = Me.coilFaceLengthTextBox.Text

        ' Save subcooling info
        If Me.subCoolingComboBox.Text = "Yes" Then
            CurrentStateProcess.SubCooling = True
        Else
            CurrentStateProcess.SubCooling = False
        End If
        If CurrentStateProcess.SubCooling = False Then
            CurrentStateProcess.SubCoolingPercentage = 0
        Else
            CurrentStateProcess.SubCoolingPercentage = Me.subCoolingPercentTextBox.Text
        End If

        ' Save altitude
        CurrentStateProcess.Altitude = Me.txt_altitude.Text

        ' Save ambient temp
        CurrentStateProcess.AmbientTemp = Me.txt_ambient.Text

        ' Save temperature difference
        CurrentStateProcess.TD = Me.txt_td.Text

        ' Save fan info
        CurrentStateProcess.Fan = Me.grabFan.Description ' Me.fanComboBox.Text
        CurrentStateProcess.NumFans = Me.numFansComboBox.Text

        ' Save CFM
        CurrentStateProcess.CFM = Me.cfmTextBox.Text

        ' Save coil description
        CurrentStateProcess.CoilDesc = Me.coilComboBox.Text

        ' Save external static pressure
        CurrentStateProcess.ExtStaticPressure = Me.txt_esp.Text

        ' Catalog rating?
        CurrentStateProcess.CatalogRating = Me.catalogRatingCheckBox.Checked

        CurrentStateProcess.Notes = Me.txt_notes.Text

        ' Set save process...
        Dim RevSave As New RevisionSave
        CurrentStateProcess = RevSave.SetSaveProcess(Me, Business.ProcessType.Condenser, CurrentStateProcess, LastSavedProcess, SaveAsNew, SaveAsRevision, FormClosing, GenerateEquipment, RevChanged)
        If RevSave.CancelSave = True Then
            If CurrentStateProcess Is Nothing Then
                ' canceled
                RevSave = Nothing
                Return False
            Else
                ' do not save and continue to close
                RevSave = Nothing
                Return True
            End If

        End If

        ' Set last saved process...
        LastSavedProcess = RevSave.RevisionSaved(CurrentStateProcess)
        If RevSave.CancelSave = False Then
            ' only save if user chooses...
            CurrentStateProcess = LastSavedProcess.Clone
            RevSave = Nothing
            Return True
        Else
            ' User cancelled form close...
            RevSave = Nothing
            Return False
        End If

    End Function


    Public Sub Open(ByVal process_item As ProcessItem)
        Me.LoadControls(process_item)
    End Sub

#End Region

#Region " Private methods"

#Region " Private event handlers"

    Private Sub form_Activated(ByVal sender As Object, ByVal e As EventArgs) _
    Handles Me.Activated
        Me.initializeSaveToolStripPanel()
        Me.SaveToolStripPanel1.Merge()
    End Sub

    Private Sub form_Deactivate(ByVal sender As Object, ByVal e As EventArgs) _
    Handles Me.Deactivate
        Me.SaveToolStripPanel1.Unmerge()
    End Sub

    Private repository As condensers.condenser_repository
    Private user As user

    Private Sub form_Load() Handles MyBase.Load
        user = AppInfo.User
        initializeSaveToolStripPanel()

        'fits height of window to it's parent windows space
        Me.Size = New Size(Me.Size.Width, Ui.FormEditor.MaximizeHeight(Me))

        'sets y position of form
        Me.Location = New Point(Me.Location.X, 0)

        'sets default items for comboboxes
        Me.subCoolingComboBox.SelectedIndex = 0
        Me.numFansComboBox.SelectedIndex = 0

        FillRefrigerantCombobox()
        fillCoilCombobox()
        If user.authority_group = user_group.employee Then
            fillFanComboBox("")
        End If

        If user.authority_group > 2 Then
            subCoolingPercentTextBox.Visible = False
            subCoolingPercentLabel.Visible = False
            subCoolingPercentTextBox.ReadOnly = True
        Else
            subCoolingPercentTextBox.ReadOnly = False
        End If

        'TODO: is this necessary or is it always go to begin w/ same image
        If AppInfo.Division.ToString.ToUpper = "TSI" Then
            Me.rbo_10A0.Checked = True
            rbo_pfc.Checked = False
            rbo_rac.Checked = False
        Else
            rbo_pfc.Checked = True
            Me.rbo_10A0.Checked = False
            rbo_rac.Checked = False
        End If
        Me.isLoaded = True
        Me.FillCondenserModelsCombobox()
        Me.setAccessToControls() 'depends on if rep

        'add handler to revision view . revision changed event on main form...
        Dim mainForm As MainForm = CType(My.Application.ApplicationContext.MainForm, MainForm)
        AddHandler mainForm.RevisionView1.RevisionChanged, AddressOf RevisionView_RevisionChanged

    End Sub


    ''' <summary>Asks user to save changes, if there are unsaved changes.</summary>
    Private Sub form_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) _
    Handles Me.FormClosing
        If Not Me.ProcessDeleted Then
            If SaveControls(False, False, True) = False Then
                e.Cancel = True
            Else
                RemoveHandler AppInfo.Main.RevisionView1.RevisionChanged, AddressOf RevisionView_RevisionChanged
            End If
        End If
    End Sub

    Private Sub saveMenuItem_Click() _
    Handles saveMenuItem.Click
        Me.SaveControls()
    End Sub

    Private Sub saveAsMenuItem_Click() _
    Handles saveAsMenuItem.Click
        Me.SaveControls(False, True)
    End Sub

    Private Sub saveAsRevisionMenuItem_Click() _
    Handles saveAsRevisionMenuItem.Click
        Me.SaveControls(True)
    End Sub

    Private Sub convertToEquipmentMenuItem_Click() _
    Handles convertToEquipmentMenuItem.Click
        Me.SaveControls(False, False, False, True)
    End Sub

    Private Sub printMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles printMenuItem.Click
        ''Me.printUi()
    End Sub

    ''' <summary>Calculates values and populates controls.</summary>
    Private Sub calculateButton_Click() _
    Handles calculateButton.Click
        Cursor = Cursors.WaitCursor

        Try
            calculate_page()
        Catch ex As Exception
            Ui.MessageBox.Show("The page cannot be calculated. " & ex.Message)
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub viewReportButton_Click() _
    Handles viewReportButton.Click
        Cursor.Current = Cursors.WaitCursor

        Try
            show_report()
        Catch ex As Exception
            rae.ui.alert("Report cannot be generated. " & ex.Message)
        End Try

        Cursor.Current = Cursors.Default
    End Sub


    ''' <summary>
    ''' Handles revision view control's revision changed event.
    ''' If user has unsaved changes, asks user to save before navigating revisions.
    ''' </summary>
    Private Sub RevisionView_RevisionChanged(ByVal sender As RevisionView, ByVal e As ValueChangedEventArgs(Of Single))
        If sender.ActiveProcessForm Is Me Then
            SaveControls(False, False, False, False, True)
        End If
    End Sub


    ''' <summary>
    ''' Handles comboboxes' selected index changed events.
    ''' Hides results grid if changes are made that void displayed results.
    ''' </summary>
    Private Sub refrigerantComboBox_SelectedIndexChanged() _
    Handles cbo_refrigerant.SelectedIndexChanged, numFansComboBox.SelectedIndexChanged, coilComboBox.SelectedIndexChanged
        HideResultsGrid()
    End Sub


    ''' <summary>
    ''' Handles series radio buttons' check changed events.
    ''' Fills condensers and hides results.
    ''' </summary>
    Private Sub seriesRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles rbo_10A0.CheckedChanged, rbo_pfc.CheckedChanged, rbo_rac.CheckedChanged
        handleSeriesChanged(CType(sender, RadioButton))
    End Sub


    ''' <summary>
    ''' Handles model number combobox selected index changed event.
    ''' Sets control values based on selected model number.
    ''' </summary>
    Private Sub modelNumberComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles cbo_model.SelectedIndexChanged
        lbl_info.Text = ""

        Try
            setControlValuesBasedOnCondenserModel()
        Catch ex As Exception
            Ui.MessageBox.Show(ex.Message, MessageBoxIcon.Warning)
        End Try

        ' sets custom model number text box value to the selected model number by default
        If modelIsSelected() Then
            Me.txt_model.Text = Me.cbo_model.SelectedItem.ToString
        End If
        ' clears custom model number textbox when custom is selected
        If Me.cbo_model.SelectedItem IsNot Nothing _
        AndAlso Me.cbo_model.SelectedItem.ToString = Me.custom Then
            Me.txt_model.Text = ""
        End If

        HideResultsGrid()
    End Sub


    ''' <summary>
    ''' Handles fan combobox selected index changed event.
    ''' </summary>
    Private Sub fanComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles fanComboBox.SelectedIndexChanged
        If Me.grabFan.FileName = "CFM Per Fan >>>" Then
            cfmTextBox.Visible = True
            cfmLabel.Visible = True
        Else
            cfmTextBox.Visible = False
            cfmLabel.Visible = False
        End If
        If resultsDataGrid.Visible = True Then
            resultsDataGrid.Visible = False
        End If
    End Sub

#End Region


#Region " Private helper methods"


    ''' <summary>
    ''' Initializes save tool strip panel. Sets event handlers and tool strip.
    ''' </summary>
    Private Sub initializeSaveToolStripPanel()
        Me.SaveToolStripPanel1.SetUp(CType(Me.ParentForm, MainForm).mainToolStrip, _
           AddressOf saveMenuItem_Click, AddressOf saveAsRevisionMenuItem_Click)
    End Sub


    ''' <summary>
    ''' Loads controls with process item
    ''' </summary>
    ''' <param name="process_item">
    ''' Process item to load controls with
    ''' </param>
    Private Sub LoadControls(ByVal process As CondenserProcessItem)

        ' If latest revision has not been set then
        ' we need to set it now  based on the ID...
        If Me.m_LatestRevision = -1 Then
            Me.m_LatestRevision = Rae.RaeSolutions.DataAccess.Projects.ProcessItemDA.LastestRevision(Me.Tag)
        End If

        ' Increment the current process revision
        ' displayed on this form...
        Me.m_CurrentRevision = process.Revision

        ' Clone last saved process to passing process item
        LastSavedProcess = process.Clone()

        ' Load series
        Select Case UCase(LastSavedProcess.Series)
            Case "10A0"
                Me.rbo_10A0.Checked = True
            Case "PFC"
                Me.rbo_pfc.Checked = True
            Case "RAC"
                Me.rbo_rac.Checked = True
            Case Else
                Me.rbo_10A0.Checked = True
        End Select

        ' Load model
        Me.cbo_model.Text = LastSavedProcess.Model

        ' loads custom model number
        Me.txt_model.Text = LastSavedProcess.ModelDescription

        ' Load refrigerant
        If LastSavedProcess.Refrigerant IsNot Nothing Then
            Me.cbo_refrigerant.Text = LastSavedProcess.Refrigerant
        End If

        ' Load coil face dimensions
        If Me.LastSavedProcess.CoilWidth > 0 Then
            Me.coilFaceWidthTextBox.Text = LastSavedProcess.CoilWidth
        End If
        If Me.LastSavedProcess.CoilLength > 0 Then
            Me.coilFaceLengthTextBox.Text = LastSavedProcess.CoilLength
        End If

        ' Load subcooling info
        If LastSavedProcess.SubCooling.ToString = "True" Then
            Me.subCoolingComboBox.Text = "Yes"
        Else
            Me.subCoolingComboBox.Text = "No"
        End If
        Me.subCoolingPercentTextBox.Text = LastSavedProcess.SubCoolingPercentage

        ' Load altitude
        Me.txt_altitude.Text = LastSavedProcess.Altitude

        ' Load ambient temp
        If Me.LastSavedProcess.AmbientTemp <> 0 Then
            Me.txt_ambient.Text = LastSavedProcess.AmbientTemp
        End If

        ' Load temperature difference
        If Me.LastSavedProcess.TD > 0 Then
            Me.txt_td.Text = LastSavedProcess.TD
        End If

        ' Load fan info
        If LastSavedProcess.Fan IsNot Nothing Then
            Me.fanComboBox.Text = LastSavedProcess.Fan
        End If
        If LastSavedProcess.NumFans > 0 Then
            Me.numFansComboBox.Text = LastSavedProcess.NumFans
        End If

        ' Load CFM
        If Me.LastSavedProcess.CFM > 0 Then
            Me.cfmTextBox.Text = LastSavedProcess.CFM
        End If

        ' Load coil description
        If LastSavedProcess.CoilDesc IsNot Nothing Then
            Me.coilComboBox.Text = LastSavedProcess.CoilDesc
        End If

        ' Load external static pressure
        Me.txt_esp.Text = LastSavedProcess.ExtStaticPressure

        ' Catalog rating?
        Me.catalogRatingCheckBox.Checked = LastSavedProcess.CatalogRating

        Me.txt_notes.Text = LastSavedProcess.Notes




        ' Calculate page
        'CalculatePage()

    End Sub


    ''Private Sub printUi()
    ''    Dim doc As New C1.C1PrintDocument.C1PrintDocument()
    ''    'controls font and other styles on printed page
    ''    Dim printStyle As New C1.C1PrintDocument.C1DocStyle(doc)  'used in rendering spacer image
    ''    printStyle.Font = New Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Millimeter)
    ''    'the page settings from frmC1PrintPreview.vb are not applied
    ''    'page settings must be set in code in order to be applied
    ''    doc.PageSettings.Margins.Top = 50 'in hundredths of an inch
    ''    doc.PageSettings.Margins.Bottom = 50
    ''    doc.DefaultUnit = C1.C1PrintDocument.UnitTypeEnum.Mm

    ''    'header
    ''    doc.PageHeader.Height = 8
    ''    doc.PageHeader.RenderText.Style = printStyle
    ''    doc.PageHeader.RenderText.Style.TextAlignHorz = C1.C1PrintDocument.AlignHorzEnum.Center
    ''    doc.PageHeader.RenderText.Style.TextAlignVert = C1.C1PrintDocument.AlignVertEnum.Top
    ''    doc.PageHeader.RenderText.Text = Me.Text

    ''    'footer
    ''    doc.PageFooter.Height = 8
    ''    doc.PageFooter.RenderText.Style = printStyle
    ''    doc.PageFooter.RenderText.Style.TextAlignHorz = C1.C1PrintDocument.AlignHorzEnum.Right
    ''    doc.PageFooter.RenderText.Style.TextAlignVert = C1.C1PrintDocument.AlignVertEnum.Bottom
    ''    doc.PageFooter.RenderText.Text = "Page [@@PageNo@@] of [@@PageCount@@]"


    ''    doc.StartDoc() 'start rendering
    ''    doc.RenderBlockControlImage(panCont)
    ''    doc.RenderBlockControlImage(panNote)
    ''    doc.EndDoc() 'stop rendering

    ''    Dim formPreview As New C1PrintPreviewForm() 'create instance form to preview before printing
    ''    formPreview.C1PrintPreview1.Document = doc 'set the form's document to the document just created
    ''    formPreview.ShowDialog() 'can't have mdiparent otherwise error occurs
    ''    formPreview.Dispose()
    ''End Sub

#End Region

#End Region


    'fill refrigerant combobox
    Private Sub FillRefrigerantCombobox()
        Dim refs As New ArrayList()



        ' If Not Constants.COMPILE_AS_CONTRACTOR_VERSION Then Stop

        refs.Add(New cFillCombobox(CondenserRefrigerants.R22, "R22"))
        refs.Add(New cFillCombobox(CondenserRefrigerants.R134a, "R134a"))
        refs.Add(New cFillCombobox(CondenserRefrigerants.R404a, "R404a"))
        refs.Add(New cFillCombobox(CondenserRefrigerants.R407a, "R407a"))
        refs.Add(New cFillCombobox(CondenserRefrigerants.R407c, "R407c"))
        refs.Add(New cFillCombobox(CondenserRefrigerants.R407f, "R407f"))
        refs.Add(New cFillCombobox(CondenserRefrigerants.R507, "R507"))
        refs.Add(New cFillCombobox(CondenserRefrigerants.R448a, "R448a"))
        refs.Add(New cFillCombobox(CondenserRefrigerants.R449a, "R449a"))
        refs.Add(New cFillCombobox(CondenserRefrigerants.R410a, "R410a"))
        'Else
        'refs.Add(New cFillCombobox(CondenserRefrigerants.R22, "R22"))
        'refs.Add(New cFillCombobox(CondenserRefrigerants.R134a, "R134a"))
        'refs.Add(New cFillCombobox(CondenserRefrigerants.R404a, "R404a"))
        'refs.Add(New cFillCombobox(CondenserRefrigerants.R407c, "R407c"))
        'refs.Add(New cFillCombobox(CondenserRefrigerants.R507, "R507"))
        'refs.Add(New cFillCombobox(CondenserRefrigerants.R410a, "R410a"))
        'End If


        '{"R22", "R134a", "R404a", "R407a", "R407c", "R407f", "R448a", "R449a", "R507"})

        cbo_refrigerant.DataSource = refs
        cbo_refrigerant.SelectedIndex = 7
        cbo_refrigerant.DisplayMember = "DisplayName"
        cbo_refrigerant.ValueMember = "ValueName"
    End Sub


    'fill condenser model number combobox
    Private Sub FillCondenserModelsCombobox()
        Dim models As List(Of String)
        Dim series As String

        ' skips this method, form is not loaded yet
        If Not Me.isLoaded Then Exit Sub

        ' gets selected series
        If Me.rbo_pfc.Checked Then
            series = Me.rbo_pfc.Tag.ToString
        ElseIf Me.rbo_rac.Checked Then
            series = Me.rbo_rac.Tag.ToString
        ElseIf Me.rbo_10A0.Checked Then
            series = Me.rbo_10A0.Tag.ToString
        Else
            Ui.MessageBox.Show("A condenser series must be selected before models can be retrieved.")
            Exit Sub
        End If

        ' gets models from data source
        models = condensers.condenser_repository.RetrieveModels(series)
        If AppInfo.User.authority_group = user_group.employee Then
            models.Insert(0, Me.custom)
        End If

        ' fills combobox
        Me.cbo_model.DataSource = models
    End Sub


#Region " Data access"


    Private Sub setControlValuesBasedOnCondenserModel()

        Dim condenserModel As String
        ' checks if condenser model is selected
        If modelIsSelected() Then
            ' grabs condenser model from control
            condenserModel = Me.cbo_model.SelectedItem.ToString
        Else
            ' TODO: review
            Exit Sub 'Throw New ApplicationException("The control values cannot be set. There is no model selected.")
        End If

        ' retrieves condenser data
        Dim condenser = condensers.condenser_repository.RetrieveCondenser(condenserModel)

        ' sets control values
        Me.cbo_refrigerant.SelectedIndex = 0
        For i As Integer = 0 To Me.cbo_refrigerant.Items.Count - 1
            If Me.cbo_refrigerant.Items(i).ValueName = condenser.refrigerant Then
                Me.cbo_refrigerant.SelectedIndex = i
                Exit For
            End If
        Next
        Me.coilFaceWidthTextBox.Text = condenser.fin_height.ToString
        Me.coilFaceLengthTextBox.Text = condenser.fin_length.ToString
        Me.subCoolingPercentTextBox.Text = condenser.subcooling_percentage.ToString

        ' sets general info
        lbl_info.Text = "Unit Dimensions:  " & _
           condenser.length.ToString & "(L)x" & condenser.width.ToString & "(W)x" & condenser.height.ToString & "(H)" & _
           NewLine & "Shipping Weight:  " & condenser.shipping_weight.ToString & " (lbs.)" & _
           NewLine & "Connections:  " & condenser.connection_type
        If condenser.number_of_circuits = 1 Then
            lbl_info.Text &= NewLine & "Single Circuit" & _
               NewLine & "Inlet =  " & condenser.single_circuit_inlet_diameter & _
               NewLine & "Outlet = " & condenser.single_circuit_outlet_diameter
        Else
            lbl_info.Text &= NewLine & "Dual Circuit" & _
               NewLine & "Inlet =  " & condenser.dual_circuit_inlet_diameter & _
               NewLine & "Outlet = " & condenser.dual_circuit_outlet_diameter & _
               NewLine & "Optional Single Circuit" & _
               NewLine & "Inlet =  " & condenser.single_circuit_inlet_diameter & _
               NewLine & "Outlet = " & condenser.single_circuit_outlet_diameter
        End If

        Me.numFansComboBox.Text = condenser.fan_quantity.ToString

        Me.fillFanComboBox(condenser.fan_file_name)
        ' selects fan
        Me.fanComboBox.SelectedIndex = 0
        For i As Integer = 0 To Me.fanComboBox.Items.Count - 1
            If CType(Me.fanComboBox.Items(i), Fan).FileName = condenser.fan_file_name Then
                Me.fanComboBox.SelectedIndex = i
                Exit For
            End If
        Next

        Me.fillCoilCombobox()
        ' selects coil
        Me.coilComboBox.SelectedIndex = 0
        For i As Integer = 0 To Me.coilComboBox.Items.Count - 1
            If CType(Me.coilComboBox.Items(i), Coil).FileName = condenser.coil_file_name Then
                Me.coilComboBox.SelectedIndex = i
                Exit For
            End If
        Next

    End Sub


    Private Function calculateResults() As Condenser.OutputsList
        Dim condenser As Condenser
        condenser = createCondenserFromUserInputs()

        Dim output As Condenser.OutputsList
        output = condenser.Calculate()

        Return output
    End Function


    Private Function createCondenserFromUserInputs() As Condenser
        Dim altitude As Double
        altitude = txt_altitude.Text

        Dim ambientTemperature As Double
        ambientTemperature = txt_ambient.Text

        Dim temperatureDifference As Double
        temperatureDifference = txt_td.Text

        Dim numFans As Integer
        numFans = numFansComboBox.SelectedItem

        Dim coilWidth As Double
        coilWidth = coilFaceWidthTextBox.Text

        Dim coilLength As Double
        coilLength = coilFaceLengthTextBox.Text

        Dim fanFile As String
        fanFile = grabFan().FileName

        Dim airFlowIsOverriden As Boolean
        If fanFile = "CFM Per Fan >>>" Then
            airFlowIsOverriden = True
        End If

        Dim airFlowOverride As Double
        airFlowOverride = cfmTextBox.Text

        Dim coilFile As String
        coilFile = grabCoil().FileName

        Dim tubeSurface As String
        tubeSurface = grabCoil().TubeSurface


        Dim externalStaticPressure As Double
        externalStaticPressure = txt_esp.Text

        Dim capacityIsUsingCatalogRating As Double
        capacityIsUsingCatalogRating = catalogRatingCheckBox.Checked

        Dim isSubCooled As Boolean
        isSubCooled = CNull.ToString(subCoolingComboBox.SelectedItem) = "Yes"
        Dim subCoolingPercentage As Double
        If isSubCooled Then
            subCoolingPercentage = subCoolingPercentTextBox.Text
        End If

        'TODO: Change refrigerant listing from using late binding
        Dim refrigerant As String
        refrigerant = cbo_refrigerant.SelectedItem.DisplayName

        Dim condenser As New Business.Entities.Condenser( _
           ambientTemperature, _
           temperatureDifference, _
           coilWidth, _
           coilLength, _
           coilFile, _
           numFans, _
           fanFile, tubeSurface)
        With condenser.Input
            .Altitude = altitude
            .AdditionalExternalStaticPressure = externalStaticPressure
            .SubCoolingPercentage = subCoolingPercentage
            .CapacityIsUsingCatalogRating = capacityIsUsingCatalogRating
            .Refrigerant = refrigerant
            .AirFlowIsOverriden = airFlowIsOverriden
            If airFlowIsOverriden Then
                .AirFlowOverride = airFlowOverride
            End If
        End With

        Return condenser
    End Function


#End Region


    Private Sub fillFanComboBox(ByVal fanFileName As String)
        Dim fans As List(Of Fan) = Me.getFans(fanFileName)

        Me.fanComboBox.DataSource = fans
    End Sub


    ''' <summary>
    ''' Fills coil description combobox w/ basic coils.
    ''' </summary>
    Private Sub fillCoilCombobox()
        Dim coils As List(Of Coil) = getCoils()

        Me.coilComboBox.DataSource = coils
    End Sub


    Private Function grabFan() As Fan
        If Me.fanComboBox.SelectedItem Is Nothing Then
            Return Nothing
        Else
            Return CType(Me.fanComboBox.SelectedItem, Fan)
        End If
    End Function


    Private Function grabCoil() As Coil
        If Me.coilComboBox.SelectedItem Is Nothing Then
            Return Nothing
        Else
            Return CType(Me.coilComboBox.SelectedItem, Coil)
        End If
    End Function


    Private Sub setAccessToControls()
        'gives user authorization to use certain controls
        'depending on rep and company access status

        'shows 10A0 and RAC options for TSI
        If AppInfo.Division = Division.TSI Then
            Me.rbo_10A0.Checked = True
            Me.rbo_10A0.Visible = True
            Me.rbo_pfc.Visible = False
            'shows PFC and RAC options for Century
        ElseIf AppInfo.Division = Division.CRI Then
            Me.rbo_pfc.Checked = True
            Me.rbo_pfc.Visible = True
            Me.rbo_10A0.Visible = False
        End If
        'hides RAE model numbers from reps
        Me.rbo_rac.Visible = Not (AppInfo.User.authority_group = user_group.rep)


        If AppInfo.User.authority_group > 2 Then
            subCoolingPercentTextBox.ReadOnly = True
        Else
            subCoolingPercentTextBox.ReadOnly = False
        End If
        Try
            setControlValuesBasedOnCondenserModel()
        Catch ex As Exception
            Ui.MessageBox.Show(ex.Message, MessageBoxIcon.Warning)
        End Try
        txt_model.Text = cbo_model.SelectedItem

        resultsDataGrid.Visible = False

        If AppInfo.User.authority_group = user_group.rep Then
            coilFaceWidthTextBox.ReadOnly = True
            coilFaceLengthTextBox.ReadOnly = True
            numFansComboBox.Enabled = False
            cfmTextBox.Visible = False
            cfmLabel.Visible = False
            coilComboBox.Enabled = False
            txt_esp.Visible = False
            espLabel.Visible = False
            subCoolingPercentTextBox.Visible = False
            subCoolingPercentLabel.Visible = False
            catalogRatingCheckBox.Checked = True
            catalogRatingCheckBox.Visible = False
            goToPricingButton.Visible = False
        ElseIf AppInfo.User.authority_group = user_group.employee Then                           'IN ENGINEERING MODE
            Me.coilFaceWidthTextBox.ReadOnly = False
            coilFaceLengthTextBox.ReadOnly = False
            numFansComboBox.Enabled = True
            coilComboBox.Enabled = True
            txt_esp.Visible = True
            espLabel.Visible = True
            subCoolingPercentTextBox.Visible = True
            subCoolingPercentLabel.Visible = True
            Me.catalogRatingCheckBox.Visible = True
        End If
    End Sub


    Private Sub show_report()
        Dim report_file_path = reports.file_paths.condenser_rating_report_file_path
        show_report(report_file_path)
    End Sub


    Private Sub show_report(ByVal report_file_path As String)
        calculate_page()

        Dim text = New dictionary(Of String, String)
        Dim coil = get_coil_descripton
        Dim fan = get_fan_description

        text.add("model", If(txt_model.text.is_not_set, cbo_model.SelectedItem, txt_model.text))
        text.add("coil", coil)
        text.add("fan", fan)
        text.add("refrigerant", cbo_refrigerant.SelectedItem.DisplayName)
        text.add("altitude", txt_altitude.text)
        text.add("ambient", txt_ambient.text)
        text.add("td", txt_td.text)
        text.add("esp", txt_esp.text)
        text.add("notes", txt_notes.text)
        text.add("user", user.username)
        text.add("application_version", my.application.info.version.toString)
        text.add("date_created", DateTime.Now.ToString("M/d/yyyy"))
        Dim list_of_info = lbl_info.text.Split(rae.io.text.new_line)

        Dim command = New get_logo_file_path_command(user, get_selected_division)
        Dim logo_file_path = command.execute

        Dim table = create_table(Me.resultsDataGrid.DataSource)

        Dim report = New rae.reporting.beta.report(report_file_path)
        report.set_list("information", list_of_info.toList)
        report.set_text(text)
        report.set_image("logo", logo_file_path)
        report.set_table("table", table)
        report.mark_as_final()
        report.show()
    End Sub

    Private Function create_table(ByVal list As Condenser.OutputsList) As DataTable
        Dim table = New DataTable

        table.columns.add("FPI")
        table.Columns.Add("Est. Capacity [BTUH]")
        table.columns.add("Face Velocity [FPM]")
        table.columns.add("Static Pressure [In. of water]")
        table.columns.add("Total Air Flow Actual [CFM]")
        If user.is_employee Then
            table.columns.add("Total Air Flow Standard [CFM]")
            table.columns.add("HP")
            table.columns.add("BTUH/Ft2")

            For Each output In list
                table.rows.add(
                   output.FinsPerInch,
                   output.Capacity.ToString("#,#"),
                   output.FaceVelocity.ToString("#,#"),
                   output.StaticPressure,
                   output.AirFlowActual.ToString("#,#"),
                   output.AirFlowStandard.ToString("#,#"),
                   output.Horsepower,
                   output.CoilCapacity.ToString("#,#"))
            Next
        Else
            For Each output In list
                table.rows.add(
                   output.FinsPerInch,
                   output.Capacity.ToString("#,#"),
                   output.FaceVelocity.ToString("#,#"),
                   output.StaticPressure,
                   output.AirFlowActual.ToString("#,#"))
            Next
        End If

        Return table
    End Function

    Private Function get_selected_division() As String
        Dim division As String
        If rbo_10a0.checked Then
            division = "TSI"
        ElseIf rbo_pfc.checked Then
            division = "CRI"
        ElseIf rbo_rac.checked Then
            division = "RAE"
        End If
        Return division
    End Function

    Private Function get_logo() As String
        Dim logo = get_selected_division

        If user.can(choose_report_logo) Then
            logo = New which_division().ask({"TSI", "CRI", "RSI", "RAE"})
        End If
        Return logo
    End Function


    Private Function get_fan_description() As String
        Dim fan As Fan = grabFan()
        Dim numFans As String = numFansComboBox.SelectedItem.ToString()

        Dim description As String
        description = "(" & numFans & ") " & fan.Description

        If fan.FileName = "CFM Per Fan >>>" Then
            description &= "  CFM = " & cfmTextBox.Text
        End If

        Return description
    End Function


    Private Function get_coil_descripton() As String
        Dim coilDescription As String
        coilDescription = grabCoil.Description & " (" & coilFaceWidthTextBox.Text & "x" & coilFaceLengthTextBox.Text & ")"
        If subCoolingComboBox.SelectedItem = "Yes" Then
            coilDescription &= " with sub-cooling"
        End If
        Return coilDescription
    End Function


    Private Sub handleSeriesChanged(ByVal seriesRadioButton As RadioButton)
        If seriesRadioButton.Checked Then
            FillCondenserModelsCombobox()
            HideResultsGrid()
        End If
    End Sub


    ''' <summary>
    ''' Hides results grid.
    ''' </summary>
    Private Sub HideResultsGrid()
        If resultsDataGrid.Visible Then
            resultsDataGrid.Visible = False
        End If
    End Sub


    Private Sub subCoolingComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles subCoolingComboBox.SelectedIndexChanged
        HideResultsGrid()

        If AppInfo.User.authority_group > 2 Then
            subCoolingPercentTextBox.ReadOnly = True
        Else
            subCoolingPercentTextBox.ReadOnly = False
        End If

        If Not modelIsSelected() Then
            subCoolingPercentTextBox.Text = "15"
        End If

    End Sub


    ''' <summary>
    ''' Indicates whether a model number has been selected by the user.
    ''' </summary>
    Private Function modelIsSelected() As Boolean
        Dim modelIsSelected_ As Boolean

        If cbo_model.SelectedItem IsNot Nothing _
        AndAlso cbo_model.SelectedItem <> Me.custom Then
            modelIsSelected_ = True
        End If

        Return modelIsSelected_
    End Function


    Private Sub calculate_page()
        validateUserInput()

        Dim results As Condenser.OutputsList
        results = calculateResults()
        results = filter(results)

        resultsDataGrid.DataSource = results
        formatDatagrid()
    End Sub


    Private Function filter(ByVal results As Condenser.OutputsList) As Condenser.OutputsList
        Dim unfilteredResult As Condenser.Outputs
        Dim filteredResults As New Condenser.OutputsList()
        Const MAX_FACE_FELOCITY As Integer = 900

        For Each unfilteredResult In results
            If unfilteredResult.FaceVelocity > MAX_FACE_FELOCITY Then
                Console.WriteLine("Result is filtered. The face velocity, " & unfilteredResult.FaceVelocity.ToString() & ", is greater than " & MAX_FACE_FELOCITY)
            Else
                filteredResults.Add(unfilteredResult)
            End If
        Next

        Return filteredResults
    End Function


    Private Sub validateUserInput()
        ToolTip1.SetToolTip(Me.calculateButton, "")
        If AppInfo.User.authority_group > 2 Then
            If Not modelIsSelected() Then
                ToolTip1.SetToolTip(Me.calculateButton, "Please select a model number.")
                Throw New ApplicationException("A model must be selected.")
            End If
        End If
    End Sub


    ''' <summary>
    ''' Formats datagrid: sets header, column widths, colors, etc.
    ''' </summary>
    Private Sub formatDatagrid()
        ' creates new table style
        Dim fanTableStyle As New DataGridTableStyle(False)
        fanTableStyle.MappingName = GetType(Condenser.OutputsList).Name
        fanTableStyle.DataGrid = Me.resultsDataGrid

        ' names and maps columns
        '
        Dim colFinsPerInch As New DataGridTextBoxColumn
        colFinsPerInch.MappingName = "FinsPerInch"
        colFinsPerInch.HeaderText = "FPI"
        Dim colCapacity As New DataGridTextBoxColumn
        colCapacity.MappingName = "Capacity"
        colCapacity.HeaderText = "Est. Capacity"
        Dim colFaceVelocity As New DataGridTextBoxColumn
        colFaceVelocity.MappingName = "FaceVelocity"
        colFaceVelocity.HeaderText = "Face Velocity"
        Dim colStaticPressure As New DataGridTextBoxColumn
        colStaticPressure.MappingName = "StaticPressure"
        colStaticPressure.HeaderText = "Static Pressure"
        Dim colHorsepower As New DataGridTextBoxColumn
        colHorsepower.MappingName = "Horesepower"
        colHorsepower.HeaderText = "HP"
        Dim colCFMActual As New DataGridTextBoxColumn
        colCFMActual.MappingName = "AirFlowActual"
        colCFMActual.HeaderText = "CFM Actual"
        Dim colCFMStandard As New DataGridTextBoxColumn
        colCFMStandard.MappingName = "AirFlowStandard"
        colCFMStandard.HeaderText = "CFM Standard"
        Dim colBTUH As New DataGridTextBoxColumn
        colBTUH.MappingName = "CoilCapacity"
        colBTUH.HeaderText = "Est. BTUH/FT" & Chr(178)

        colFinsPerInch.Width = 30
        colCapacity.Width = 65
        colFaceVelocity.Width = 85
        colStaticPressure.Width = 95
        colCFMActual.Width = 80
        If AppInfo.User.authority_group > 2 Then 'Or chkRepMode.Checked = True Then
            colHorsepower.Width = 0
            colCFMStandard.Width = 0
            colBTUH.Width = 0
        Else
            colHorsepower.Width = 35
            colCFMStandard.Width = 90
            colBTUH.Width = 68
        End If

        fanTableStyle.GridColumnStyles.Add(colFinsPerInch)
        fanTableStyle.GridColumnStyles.Add(colCapacity)
        fanTableStyle.GridColumnStyles.Add(colFaceVelocity)
        fanTableStyle.GridColumnStyles.Add(colStaticPressure)
        fanTableStyle.GridColumnStyles.Add(colHorsepower)
        fanTableStyle.GridColumnStyles.Add(colCFMActual)
        fanTableStyle.GridColumnStyles.Add(colCFMStandard)
        fanTableStyle.GridColumnStyles.Add(colBTUH)

        fanTableStyle.HeaderBackColor = Color.Blue
        fanTableStyle.HeaderForeColor = Color.White
        'cofanDgrTableStyle.RowHeaderWidth = 15
        fanTableStyle.RowHeadersVisible = False
        fanTableStyle.AlternatingBackColor = Color.LightSkyBlue
        fanTableStyle.GridLineStyle = DataGridLineStyle.None
        resultsDataGrid.TableStyles.Clear() 'can't add style again if it's already added
        resultsDataGrid.TableStyles.Add(fanTableStyle)
        resultsDataGrid.CaptionVisible = False
        resultsDataGrid.Visible = True
    End Sub


#Region " Business logic"


    Private Function getCoils() As List(Of Coil)
        ' retrieves coil data

        Dim coilsData As List(Of condensers.condenser_repository.CoilTransferData)
        If AppInfo.User.authority_group = user_group.rep Then
            coilsData = repository.RetrieveRepCoils()
        ElseIf AppInfo.User.authority_group = user_group.employee Then
            coilsData = repository.RetrieveEmployeeCoils()
        Else
            Throw New ApplicationException("Condenser coil authorization is not valid.")
        End If

        ' populates coil object
        '
        Dim coil As Coil
        Dim coils As New List(Of Coil)()
        For Each coilData As condensers.condenser_repository.CoilTransferData In coilsData
            Dim application As Coil.CoilType : GetEnumValue(Of Coil.CoilType)(coilData.CoilType, application)
            Dim finDesign As Coil.FinType : GetEnumValue(Of Coil.FinType)(coilData.FinType, finDesign)
            coil = New Coil(coilData.Diameter, coilData.NumRows, coilData.FileName, application, finDesign, coilData.tubeSurface)
            coils.Add(coil)
        Next

        Return coils
    End Function


    Private Function getFans(ByVal fanGroup As String) As List(Of Fan)
        Dim fansData As List(Of condensers.condenser_repository.FanTransferData)
        If user.is_employee Then
            fansData = repository.RetrieveCondenserEmployeeFans()
        ElseIf AppInfo.User.authority_group > 2 Then
            fansData = repository.RetrieveCondenserRepFans(fanGroup)
        End If

        Dim fan As Fan : Dim fans As New List(Of Fan)()
        For Each fanData In fansData
            fan = New Fan(fanData.FileName, fanData.Horsepower, fanData.Diameter, fanData.Rpm, fanData.IsHighAltitude, fanData.Hertz, fanData.IsVariableSpeed)
            fans.Add(fan)
        Next

        If AppInfo.User.is_employee Then
            fan = New Fan("CFM Per Fan >>>", 0, 0, 0, False, 0, False)
            fan.Description = "CFM Per Fan >>>"
            fans.Add(fan)
        End If

        Return fans
    End Function

#End Region


    Private Sub btnNewEquipmentPricing_Click() Handles goToPricingButton.Click
        Me.SaveControls(False, False, False, True)
    End Sub



#Region " Removed"

    'Private Function getCoilCapacityMultiplier(ByVal refrigerant As String, ByVal isCatalogRating As Boolean) As Double
    '   Dim capacityMultiplier As Double
    '   Dim cache As CondenserCache = CondenserCache.Create()

    '   ' adjusts coil capacity based on catalog rating and refrigerant
    '   Dim refrigerantMultiplier As Double
    '   If refrigerant = CondenserRefrigerants.R22 Then
    '      refrigerantMultiplier = cache.R22Multiplier
    '   ElseIf refrigerant = CondenserRefrigerants.R407c Then
    '      refrigerantMultiplier = cache.R407cMultiplier
    '   ElseIf refrigerant = CondenserRefrigerants.R134a Then
    '      refrigerantMultiplier = cache.R134aMultiplier
    '   ElseIf refrigerant = CondenserRefrigerants.R404a Then
    '      refrigerantMultiplier = cache.R404aMultiplier
    '   ElseIf refrigerant = CondenserRefrigerants.R507a Then
    '      refrigerantMultiplier = cache.R507aMultiplier
    '   End If

    '   capacityMultiplier = refrigerantMultiplier

    '   If isCatalogRating Then
    '      capacityMultiplier *= cache.CatalogRatingMultiplier
    '   End If

    '   Return capacityMultiplier
    'End Function


    'creates data view for main datagrid
    'Function createDataSource() As ICollection
    '   Dim coilCapacityMultiplier As Double = _
    '      Me.getCoilCapacityMultiplier(Me.refrigerantComboBox.SelectedItem.DisplayName, Me.catalogRatingCheckBox.Checked)

    '   Dim cofan As New RAEDLL_COFAN.RRAEDLL_COFAN()
    '   'SET COFAN DLL INPUTS
    '   cofan.RAE_Input_Altitude_in_feet = Val(altitudeTextBox.Text)
    '   cofan.RAE_Input_Ambient_Temp_Degrees_F = Val(ambientTempTextBox.Text)
    '   cofan.RAE_Input_Temperature_Difference_Degrees_F = Val(temperatureDifferenceTextBox.Text)
    '   cofan.RAE_Input_Number_of_Fans = numFansComboBox.SelectedItem
    '   cofan.RAE_Input_Condenser_Fin_Width = Val(coilFaceWidthTextBox.Text)
    '   cofan.RAE_Input_Condenser_Fin_Length = Val(coilFaceLengthTextBox.Text)
    '   If Me.grabFan.FileName = "CFM Per Fan >>>" Then
    '      cofan.RAE_FAN_FILE_NAME = "OVERRIDE" & Val(cfmTextBox.Text)
    '   Else
    '      cofan.RAE_FAN_FILE_NAME = Me.grabFan.FileName
    '   End If
    '   cofan.RAE_COIL_FILE_NAME = Me.grabCoil.FileName
    '   cofan.RAE_COFAN_EXT = Val(espTextBox.Text)

    '   cofan.AddToDatabase()

    '   'GET COFAN DLL OUTPUT
    '   Dim temp_fpi As Double
    '   Dim temp_CAPACITY As Double
    '   Dim temp_FACEVELOCITY As Double
    '   Dim temp_STATICPRESSURE As Double
    '   Dim temp_HORSEPOWER As Double
    '   Dim temp_CFMACTUAL As Double
    '   Dim temp_CFMSTD As Double
    '   Dim temp_BTUHSF As Double

    '   '8 fin per inch
    '   temp_fpi = cofan.RAE_Out_COFAN_FPI_Output1()
    '   temp_CAPACITY = Round((cofan.RAE_Out_COFAN_CAPACITY_Output1 * coilCapacityMultiplier), 0)
    '   If subCoolingComboBox.SelectedItem = "Yes" Then
    '      temp_CAPACITY = temp_CAPACITY * (1 - (Val(subCoolingPercentTextBox.Text()) / 100)) 'Sub Cooling deduct
    '   End If
    '   temp_FACEVELOCITY = cofan.RAE_Out_COFAN_FACEVELOCITY_Output1()
    '   temp_STATICPRESSURE = cofan.RAE_Out_COFAN_STATICPRESSURE_Output1()
    '   temp_HORSEPOWER = cofan.RAE_Out_COFAN_HORSEPOWER_Output1()
    '   temp_CFMACTUAL = cofan.RAE_Out_COFAN_CFMACTUAL_Output1()
    '   temp_CFMSTD = cofan.RAE_Out_COFAN_CFMSTD_Output1()
    '   temp_BTUHSF = Round((cofan.RAE_Out_COFAN_BTUHSF_Output1 * coilCapacityMultiplier), 0)

    '   'add columns
    '   Dim table As New DataTable
    '   Dim row As DataRow
    '   table.TableName = "CofanTable"
    '   table.Columns.Add(New DataColumn("FPI", GetType(String)))
    '   table.Columns.Add(New DataColumn("Capacity", GetType(String)))
    '   table.Columns.Add(New DataColumn("FV", GetType(String)))
    '   table.Columns.Add(New DataColumn("SP", GetType(String)))
    '   table.Columns.Add(New DataColumn("HP", GetType(String)))
    '   table.Columns.Add(New DataColumn("CFMACT", GetType(String)))
    '   table.Columns.Add(New DataColumn("CFMSTD", GetType(String)))
    '   table.Columns.Add(New DataColumn("BTUH", GetType(String)))

    '   row = table.NewRow()
    '   row(0) = temp_fpi
    '   row(1) = Format(temp_CAPACITY, "###,###,###")
    '   row(2) = Format(temp_FACEVELOCITY, "###,###,###")
    '   row(3) = Format(temp_STATICPRESSURE, "#.##")
    '   row(4) = Format(temp_HORSEPOWER, "#.##")
    '   row(5) = Format(temp_CFMACTUAL, "###,###,###")
    '   row(6) = Format(temp_CFMSTD, "###,###,###")
    '   row(7) = Format(temp_BTUHSF, "###,###,###")

    '   cofan_cal(8, 1) = temp_fpi
    '   cofan_cal(8, 2) = Format(temp_CAPACITY, "###,###,###")
    '   cofan_cal(8, 3) = Format(temp_FACEVELOCITY, "###,###,###")
    '   cofan_cal(8, 4) = Format(temp_STATICPRESSURE, "#.##")
    '   cofan_cal(8, 5) = Format(temp_HORSEPOWER, "#.##")
    '   cofan_cal(8, 6) = Format(temp_CFMACTUAL, "###,###,###")
    '   cofan_cal(8, 7) = Format(temp_CFMSTD, "###,###,###")
    '   cofan_cal(8, 8) = Format(temp_BTUHSF, "###,###,###")

    '   table.Rows.Add(row)

    '   Dim myCheck As Boolean
    '   myCheck = Me.grabCoil.FileName Like "*EVAP*"   'Match Returns True.
    '   If myCheck = False Then
    '      '9 fin per inch 
    '      temp_fpi = cofan.RAE_Out_COFAN_FPI_Output1 + 1
    '      temp_CAPACITY = Int(((((cofan.RAE_Out_COFAN_CAPACITY_Output2 * coilCapacityMultiplier) - (cofan.RAE_Out_COFAN_CAPACITY_Output1 * coilCapacityMultiplier)) / 2) + (cofan.RAE_Out_COFAN_CAPACITY_Output1 * coilCapacityMultiplier)) * (10 ^ 0) + 0.5) / (10 ^ 0)
    '      If subCoolingComboBox.SelectedItem = "Yes" Then
    '         temp_CAPACITY = temp_CAPACITY * (1 - (Val(subCoolingPercentTextBox.Text()) / 100)) 'Sub Cooling deduct
    '      End If
    '      temp_FACEVELOCITY = Round((((cofan.RAE_Out_COFAN_FACEVELOCITY_Output2 - cofan.RAE_Out_COFAN_FACEVELOCITY_Output1) / 2) + cofan.RAE_Out_COFAN_FACEVELOCITY_Output1), 0)
    '      temp_STATICPRESSURE = Round((((cofan.RAE_Out_COFAN_STATICPRESSURE_Output2 - cofan.RAE_Out_COFAN_STATICPRESSURE_Output1) / 2) + cofan.RAE_Out_COFAN_STATICPRESSURE_Output1), 2)
    '      temp_HORSEPOWER = Round((((cofan.RAE_Out_COFAN_HORSEPOWER_Output2 - cofan.RAE_Out_COFAN_HORSEPOWER_Output1) / 2) + cofan.RAE_Out_COFAN_HORSEPOWER_Output1), 2)
    '      temp_CFMACTUAL = Round((((cofan.RAE_Out_COFAN_CFMACTUAL_Output2 - cofan.RAE_Out_COFAN_CFMACTUAL_Output1) / 2) + cofan.RAE_Out_COFAN_CFMACTUAL_Output1), 0)
    '      temp_CFMSTD = Round((((cofan.RAE_Out_COFAN_CFMSTD_Output2 - cofan.RAE_Out_COFAN_CFMSTD_Output1) / 2) + cofan.RAE_Out_COFAN_CFMSTD_Output1), 0)
    '      temp_BTUHSF = Round(((((cofan.RAE_Out_COFAN_BTUHSF_Output2 * coilCapacityMultiplier) - (cofan.RAE_Out_COFAN_BTUHSF_Output1 * coilCapacityMultiplier)) / 2) + (cofan.RAE_Out_COFAN_BTUHSF_Output1 * coilCapacityMultiplier)), 0)

    '      row = table.NewRow()
    '      row(0) = temp_fpi
    '      row(1) = Format(temp_CAPACITY, "###,###,###")
    '      row(2) = Format(temp_FACEVELOCITY, "###,###,###")
    '      row(3) = Format(temp_STATICPRESSURE, "#.##")
    '      row(4) = Format(temp_HORSEPOWER, "#.##")
    '      row(5) = Format(temp_CFMACTUAL, "###,###,###")
    '      row(6) = Format(temp_CFMSTD, "###,###,###")
    '      row(7) = Format(temp_BTUHSF, "###,###,###")
    '      cofan_cal(9, 1) = temp_fpi
    '      cofan_cal(9, 2) = Format(temp_CAPACITY, "###,###,###")
    '      cofan_cal(9, 3) = Format(temp_FACEVELOCITY, "###,###,###")
    '      cofan_cal(9, 4) = Format(temp_STATICPRESSURE, "#.##")
    '      cofan_cal(9, 5) = Format(temp_HORSEPOWER, "#.##")
    '      cofan_cal(9, 6) = Format(temp_CFMACTUAL, "###,###,###")
    '      cofan_cal(9, 7) = Format(temp_CFMSTD, "###,###,###")
    '      cofan_cal(9, 8) = Format(temp_BTUHSF, "###,###,###")
    '      table.Rows.Add(row)
    '   End If


    '   '10 fin per inch
    '   temp_fpi = cofan.RAE_Out_COFAN_FPI_Output2()
    '   temp_CAPACITY = Int((cofan.RAE_Out_COFAN_CAPACITY_Output2 * coilCapacityMultiplier) * (10 ^ 0) + 0.5) / (10 ^ 0)
    '   If subCoolingComboBox.SelectedItem = "Yes" Then
    '      temp_CAPACITY = temp_CAPACITY * (1 - (Val(subCoolingPercentTextBox.Text()) / 100)) 'Sub Cooling deduct
    '   End If
    '   temp_FACEVELOCITY = cofan.RAE_Out_COFAN_FACEVELOCITY_Output2()
    '   temp_STATICPRESSURE = cofan.RAE_Out_COFAN_STATICPRESSURE_Output2()
    '   temp_HORSEPOWER = cofan.RAE_Out_COFAN_HORSEPOWER_Output2()
    '   temp_CFMACTUAL = cofan.RAE_Out_COFAN_CFMACTUAL_Output2()
    '   temp_CFMSTD = cofan.RAE_Out_COFAN_CFMSTD_Output2()
    '   temp_BTUHSF = Int((cofan.RAE_Out_COFAN_BTUHSF_Output2 * coilCapacityMultiplier) * (10 ^ 0) + 0.5) / (10 ^ 0)

    '   row = table.NewRow()
    '   row(0) = temp_fpi
    '   row(1) = Format(temp_CAPACITY, "###,###,###")
    '   row(2) = Format(temp_FACEVELOCITY, "###,###,###")
    '   row(3) = Format(temp_STATICPRESSURE, "#.##")
    '   row(4) = Format(temp_HORSEPOWER, "#.##")
    '   row(5) = Format(temp_CFMACTUAL, "###,###,###")
    '   row(6) = Format(temp_CFMSTD, "###,###,###")
    '   row(7) = Format(temp_BTUHSF, "###,###,###")
    '   cofan_cal(10, 1) = temp_fpi
    '   cofan_cal(10, 2) = Format(temp_CAPACITY, "###,###,###")
    '   cofan_cal(10, 3) = Format(temp_FACEVELOCITY, "###,###,###")
    '   cofan_cal(10, 4) = Format(temp_STATICPRESSURE, "#.##")
    '   cofan_cal(10, 5) = Format(temp_HORSEPOWER, "#.##")
    '   cofan_cal(10, 6) = Format(temp_CFMACTUAL, "###,###,###")
    '   cofan_cal(10, 7) = Format(temp_CFMSTD, "###,###,###")
    '   cofan_cal(10, 8) = Format(temp_BTUHSF, "###,###,###")
    '   table.Rows.Add(row)

    '   If myCheck = False Then
    '      '11 fin per inch 
    '      temp_fpi = cofan.RAE_Out_COFAN_FPI_Output2 + 1
    '      temp_CAPACITY = Int(((((cofan.RAE_Out_COFAN_CAPACITY_Output3 * coilCapacityMultiplier) - (cofan.RAE_Out_COFAN_CAPACITY_Output2 * coilCapacityMultiplier)) / 2) + (cofan.RAE_Out_COFAN_CAPACITY_Output2 * coilCapacityMultiplier)) * (10 ^ 0) + 0.5) / (10 ^ 0)
    '      If subCoolingComboBox.SelectedItem = "Yes" Then
    '         temp_CAPACITY = temp_CAPACITY * (1 - (Val(subCoolingPercentTextBox.Text()) / 100)) 'Sub Cooling deduct
    '      End If
    '      temp_FACEVELOCITY = Int((((cofan.RAE_Out_COFAN_FACEVELOCITY_Output3 - cofan.RAE_Out_COFAN_FACEVELOCITY_Output2) / 2) + cofan.RAE_Out_COFAN_FACEVELOCITY_Output2) * (10 ^ 0) + 0.5) / (10 ^ 0)
    '      temp_STATICPRESSURE = Int((((cofan.RAE_Out_COFAN_STATICPRESSURE_Output3 - cofan.RAE_Out_COFAN_STATICPRESSURE_Output2) / 2) + cofan.RAE_Out_COFAN_STATICPRESSURE_Output2) * (10 ^ 2) + 0.5) / (10 ^ 2)
    '      temp_HORSEPOWER = Int((((cofan.RAE_Out_COFAN_HORSEPOWER_Output3 - cofan.RAE_Out_COFAN_HORSEPOWER_Output2) / 2) + cofan.RAE_Out_COFAN_HORSEPOWER_Output2) * (10 ^ 2) + 0.5) / (10 ^ 2)
    '      temp_CFMACTUAL = Int((((cofan.RAE_Out_COFAN_CFMACTUAL_Output3 - cofan.RAE_Out_COFAN_CFMACTUAL_Output2) / 2) + cofan.RAE_Out_COFAN_CFMACTUAL_Output2) * (10 ^ 0) + 0.5) / (10 ^ 0)
    '      temp_CFMSTD = Int((((cofan.RAE_Out_COFAN_CFMSTD_Output3 - cofan.RAE_Out_COFAN_CFMSTD_Output2) / 2) + cofan.RAE_Out_COFAN_CFMSTD_Output2) * (10 ^ 0) + 0.5) / (10 ^ 0)
    '      temp_BTUHSF = Int(((((cofan.RAE_Out_COFAN_BTUHSF_Output3 * coilCapacityMultiplier) - (cofan.RAE_Out_COFAN_BTUHSF_Output2 * coilCapacityMultiplier)) / 2) + (cofan.RAE_Out_COFAN_BTUHSF_Output2 * coilCapacityMultiplier)) * (10 ^ 0) + 0.5) / (10 ^ 0)

    '      row = table.NewRow()
    '      row(0) = temp_fpi
    '      row(1) = Format(temp_CAPACITY, "###,###,###")
    '      row(2) = Format(temp_FACEVELOCITY, "###,###,###")
    '      row(3) = Format(temp_STATICPRESSURE, "#.##")
    '      row(4) = Format(temp_HORSEPOWER, "#.##")
    '      row(5) = Format(temp_CFMACTUAL, "###,###,###")
    '      row(6) = Format(temp_CFMSTD, "###,###,###")
    '      row(7) = Format(temp_BTUHSF, "###,###,###")
    '      cofan_cal(11, 1) = temp_fpi
    '      cofan_cal(11, 2) = Format(temp_CAPACITY, "###,###,###")
    '      cofan_cal(11, 3) = Format(temp_FACEVELOCITY, "###,###,###")
    '      cofan_cal(11, 4) = Format(temp_STATICPRESSURE, "#.##")
    '      cofan_cal(11, 5) = Format(temp_HORSEPOWER, "#.##")
    '      cofan_cal(11, 6) = Format(temp_CFMACTUAL, "###,###,###")
    '      cofan_cal(11, 7) = Format(temp_CFMSTD, "###,###,###")
    '      cofan_cal(11, 8) = Format(temp_BTUHSF, "###,###,###")
    '      table.Rows.Add(row)
    '   End If

    '   '12 fin per inch
    '   temp_fpi = cofan.RAE_Out_COFAN_FPI_Output3()
    '   temp_CAPACITY = Int((cofan.RAE_Out_COFAN_CAPACITY_Output3 * coilCapacityMultiplier) * (10 ^ 0) + 0.5) / (10 ^ 0)
    '   If subCoolingComboBox.SelectedItem = "Yes" Then
    '      temp_CAPACITY = temp_CAPACITY * (1 - (Val(subCoolingPercentTextBox.Text()) / 100)) 'Sub Cooling deduct
    '   End If
    '   temp_FACEVELOCITY = cofan.RAE_Out_COFAN_FACEVELOCITY_Output3()
    '   temp_STATICPRESSURE = cofan.RAE_Out_COFAN_STATICPRESSURE_Output3()
    '   temp_HORSEPOWER = cofan.RAE_Out_COFAN_HORSEPOWER_Output3()
    '   temp_CFMACTUAL = cofan.RAE_Out_COFAN_CFMACTUAL_Output3()
    '   temp_CFMSTD = cofan.RAE_Out_COFAN_CFMSTD_Output3()
    '   temp_BTUHSF = Int((cofan.RAE_Out_COFAN_BTUHSF_Output3 * coilCapacityMultiplier) * (10 ^ 0) + 0.5) / (10 ^ 0)

    '   row = table.NewRow()
    '   row(0) = temp_fpi
    '   row(1) = Format(temp_CAPACITY, "###,###,###")
    '   row(2) = Format(temp_FACEVELOCITY, "###,###,###")
    '   row(3) = Format(temp_STATICPRESSURE, "#.##")
    '   row(4) = Format(temp_HORSEPOWER, "#.##")
    '   row(5) = Format(temp_CFMACTUAL, "###,###,###")
    '   row(6) = Format(temp_CFMSTD, "###,###,###")
    '   row(7) = Format(temp_BTUHSF, "###,###,###")
    '   cofan_cal(12, 1) = temp_fpi
    '   cofan_cal(12, 2) = Format(temp_CAPACITY, "###,###,###")
    '   cofan_cal(12, 3) = Format(temp_FACEVELOCITY, "###,###,###")
    '   cofan_cal(12, 4) = Format(temp_STATICPRESSURE, "#.##")
    '   cofan_cal(12, 5) = Format(temp_HORSEPOWER, "#.##")
    '   cofan_cal(12, 6) = Format(temp_CFMACTUAL, "###,###,###")
    '   cofan_cal(12, 7) = Format(temp_CFMSTD, "###,###,###")
    '   cofan_cal(12, 8) = Format(temp_BTUHSF, "###,###,###")
    '   table.Rows.Add(row)

    '   If myCheck = False Then
    '      '13 fin per inch 
    '      temp_fpi = cofan.RAE_Out_COFAN_FPI_Output3 + 1
    '      temp_CAPACITY = Int(((((cofan.RAE_Out_COFAN_CAPACITY_Output4 * coilCapacityMultiplier) - (cofan.RAE_Out_COFAN_CAPACITY_Output3 * coilCapacityMultiplier)) / 2) + (cofan.RAE_Out_COFAN_CAPACITY_Output3 * coilCapacityMultiplier)) * (10 ^ 0) + 0.5) / (10 ^ 0)
    '      If subCoolingComboBox.SelectedItem = "Yes" Then
    '         temp_CAPACITY = temp_CAPACITY * (1 - (Val(subCoolingPercentTextBox.Text()) / 100)) 'Sub Cooling deduct
    '      End If
    '      temp_FACEVELOCITY = Int((((cofan.RAE_Out_COFAN_FACEVELOCITY_Output4 - cofan.RAE_Out_COFAN_FACEVELOCITY_Output3) / 2) + cofan.RAE_Out_COFAN_FACEVELOCITY_Output3) * (10 ^ 0) + 0.5) / (10 ^ 0)
    '      temp_STATICPRESSURE = Int((((cofan.RAE_Out_COFAN_STATICPRESSURE_Output4 - cofan.RAE_Out_COFAN_STATICPRESSURE_Output3) / 2) + cofan.RAE_Out_COFAN_STATICPRESSURE_Output3) * (10 ^ 2) + 0.5) / (10 ^ 2)
    '      temp_HORSEPOWER = Int((((cofan.RAE_Out_COFAN_HORSEPOWER_Output4 - cofan.RAE_Out_COFAN_HORSEPOWER_Output3) / 2) + cofan.RAE_Out_COFAN_HORSEPOWER_Output3) * (10 ^ 2) + 0.5) / (10 ^ 2)
    '      temp_CFMACTUAL = Int((((cofan.RAE_Out_COFAN_CFMACTUAL_Output4 - cofan.RAE_Out_COFAN_CFMACTUAL_Output3) / 2) + cofan.RAE_Out_COFAN_CFMACTUAL_Output3) * (10 ^ 0) + 0.5) / (10 ^ 0)
    '      temp_CFMSTD = Int((((cofan.RAE_Out_COFAN_CFMSTD_Output4 - cofan.RAE_Out_COFAN_CFMSTD_Output3) / 2) + cofan.RAE_Out_COFAN_CFMSTD_Output3) * (10 ^ 0) + 0.5) / (10 ^ 0)
    '      temp_BTUHSF = Int(((((cofan.RAE_Out_COFAN_BTUHSF_Output4 * coilCapacityMultiplier) - (cofan.RAE_Out_COFAN_BTUHSF_Output3 * coilCapacityMultiplier)) / 2) + (cofan.RAE_Out_COFAN_BTUHSF_Output3 * coilCapacityMultiplier)) * (10 ^ 0) + 0.5) / (10 ^ 0)

    '      row = table.NewRow()
    '      row(0) = temp_fpi
    '      row(1) = Format(temp_CAPACITY, "###,###,###")
    '      row(2) = Format(temp_FACEVELOCITY, "###,###,###")
    '      row(3) = Format(temp_STATICPRESSURE, "#.##")
    '      row(4) = Format(temp_HORSEPOWER, "#.##")
    '      row(5) = Format(temp_CFMACTUAL, "###,###,###")
    '      row(6) = Format(temp_CFMSTD, "###,###,###")
    '      row(7) = Format(temp_BTUHSF, "###,###,###")
    '      cofan_cal(13, 1) = temp_fpi
    '      cofan_cal(13, 2) = Format(temp_CAPACITY, "###,###,###")
    '      cofan_cal(13, 3) = Format(temp_FACEVELOCITY, "###,###,###")
    '      cofan_cal(13, 4) = Format(temp_STATICPRESSURE, "#.##")
    '      cofan_cal(13, 5) = Format(temp_HORSEPOWER, "#.##")
    '      cofan_cal(13, 6) = Format(temp_CFMACTUAL, "###,###,###")
    '      cofan_cal(13, 7) = Format(temp_CFMSTD, "###,###,###")
    '      cofan_cal(13, 8) = Format(temp_BTUHSF, "###,###,###")
    '      table.Rows.Add(row)
    '   End If

    '   '14 fin per inch
    '   temp_fpi = cofan.RAE_Out_COFAN_FPI_Output4()
    '   temp_CAPACITY = Int((cofan.RAE_Out_COFAN_CAPACITY_Output4 * coilCapacityMultiplier) * (10 ^ 0) + 0.5) / (10 ^ 0)
    '   If subCoolingComboBox.SelectedItem = "Yes" Then
    '      temp_CAPACITY = temp_CAPACITY * (1 - (Val(subCoolingPercentTextBox.Text()) / 100)) 'Sub Cooling deduct
    '   End If
    '   temp_FACEVELOCITY = cofan.RAE_Out_COFAN_FACEVELOCITY_Output4()
    '   temp_STATICPRESSURE = cofan.RAE_Out_COFAN_STATICPRESSURE_Output4()
    '   temp_HORSEPOWER = cofan.RAE_Out_COFAN_HORSEPOWER_Output4()
    '   temp_CFMACTUAL = cofan.RAE_Out_COFAN_CFMACTUAL_Output4()
    '   temp_CFMSTD = cofan.RAE_Out_COFAN_CFMSTD_Output4()
    '   temp_BTUHSF = Int((cofan.RAE_Out_COFAN_BTUHSF_Output4 * coilCapacityMultiplier) * (10 ^ 0) + 0.5) / (10 ^ 0)

    '   row = table.NewRow()
    '   row(0) = temp_fpi
    '   row(1) = Format(temp_CAPACITY, "###,###,###")
    '   row(2) = Format(temp_FACEVELOCITY, "###,###,###")
    '   row(3) = Format(temp_STATICPRESSURE, "#.##")
    '   row(4) = Format(temp_HORSEPOWER, "#.##")
    '   row(5) = Format(temp_CFMACTUAL, "###,###,###")
    '   row(6) = Format(temp_CFMSTD, "###,###,###")
    '   row(7) = Format(temp_BTUHSF, "###,###,###")
    '   table.Rows.Add(row)
    '   cofan_cal(14, 1) = temp_fpi
    '   cofan_cal(14, 2) = Format(temp_CAPACITY, "###,###,###")
    '   cofan_cal(14, 3) = Format(temp_FACEVELOCITY, "###,###,###")
    '   cofan_cal(14, 4) = Format(temp_STATICPRESSURE, "#.##")
    '   cofan_cal(14, 5) = Format(temp_HORSEPOWER, "#.##")
    '   cofan_cal(14, 6) = Format(temp_CFMACTUAL, "###,###,###")
    '   cofan_cal(14, 7) = Format(temp_CFMSTD, "###,###,###")
    '   cofan_cal(14, 8) = Format(temp_BTUHSF, "###,###,###")

    '   Dim dv As New DataView(table)
    '   Return dv
    'End Function

#End Region

End Class
