Imports System.Math
Imports System.Runtime.InteropServices
Imports CREngine = CrystalDecisions.CrystalReports.Engine
Imports CRShared = CrystalDecisions.Shared
Imports VB = Microsoft.VisualBasic
Imports GlycolNames = Rae.RaeSolutions.DataAccess.Chillers.GlycolColumnNames
Imports Forms = System.Windows.Forms
Imports Rae.Validation
Imports Rae.Solutions.Chillers
Imports Rae.Solutions.Chillers.chiller
Imports BCI = Rae.RaeSolutions.Business.Intelligence.Chillers
Imports BCA = Rae.RaeSolutions.Business.Agents.ChillerAgent
Imports System.Data
Imports System.Collections.Generic
Imports Rae.RaeSolutions.DataAccess
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.Math.Calculate

Public Class WaterCooledCondenser
   Inherits Forms.Form
'   Public ProcessDeleted As Boolean

'   ' Revision Control / Saving Variables...
'   ' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
'   ' Last saved state...
'   Public LastSavedProcess As Rae.RaeSolutions.Business.Entities.WCChillerProcessItem
'   ' Current state before save...
'   Public CurrentStateProcess As Rae.RaeSolutions.Business.Entities.WCChillerProcessItem
'   ' Current displayed state revision 
'   ' number reference...
'   Private m_CurrentRevision As Single = -1

'   Private dtb As DataTable
'   ''' <summary>
'   ''' The current revision # of process 
'   ''' being displayed on this form.
'   ''' </summary>
'   Public Property CurrentRevision() As Single
'      Get
'         Return Me.m_CurrentRevision
'      End Get
'      Set(ByVal value As Single)
'         Me.m_CurrentRevision = value
'      End Set
'   End Property
'   ' Latest revision # of the current 
'   ' process ID (if any)...
'   Private m_LatestRevision As Single = -1
'   ''' <summary>
'   ''' The latest revision # of process 
'   ''' being displayed on this form.
'   ''' </summary>
'   Public Property LatestRevision() As Single
'      Get
'         Return Me.m_LatestRevision
'      End Get
'      Set(ByVal value As Single)
'         Me.m_LatestRevision = value
'      End Set
'   End Property

'#Region "Variables"
'   'Dim LastSavedProcess As WCChillerProcessItem
'   'Dim CurrentStateProcess As WCChillerProcessItem

'   Dim COILQTY_1 As Double
'   Dim ChillyRAEs_pass_no As Single

'   Dim my_Gly_Pro(12, 4) As Double
'   Dim ok_to_print_SPACE As Boolean
'   Dim ok_to_print As Boolean
'   Dim myarrayprint As New ArrayList    'circuit 1
'   Dim myarrayprint2 As New ArrayList   'circuit 2
'   Dim myarrayprint3 As New ArrayList       'circuit 1 holding
'   Dim Running_Circuit_no As Single


'   Dim ok_to_show As Boolean
'   Dim Hold_Set_PD(20) As Double

'   Dim BAD_FLUID_TYPE As Boolean        'TEST FOR BAD FLUID TYPE
'   Dim gRef As String               'Refrigerant type

'   Dim A As Double
'   Dim B As Double
'   Dim Q As Double
'   Dim gTemperatureRange As Double                  'RANGE IN DEG. F.
'   Dim T As Double
'   Dim W As Double



'   Dim gCondenserCapacity As Double                 'COND. CAP. @ 25 DEG TEMP. DIF.
'   Dim EZ As Double
'   Dim ER As Double
'    Dim GP As Double
'    Dim NT As Double 'Integer
'   Dim cond As Rae.RaeSolutions.Business.Entities.WCCondenser
'    Dim CC As Double
'   Dim H1 As Double
'   Dim H2 As Double
'   Dim KW As Double
'   Dim gSubCoolingTemp As Double                 'LIQUID COOLING(GLYCOL)
'   Dim M1 As Double
'   Dim gCompressorQuantity As Double                 'NUMBER OF COMPRESSOR CIRCUITS
'   Dim gNumberOfFans As Double                 'NUMBER OF FANS
'   Dim PC As Double
'   Dim PE As Double
'   Dim Q1 As Double
'   Dim Q8 As Double                 'CHILLER CAP. @ 8 DEG APPROACH
'   Dim Q9 As Double                 'CHILLER CAP. @ 10 DEG APPROACH
'   Dim gAmbientTempStep As Double
'   Dim TC As Double
'   Dim TE As Double
'   Dim TW As Double
'   Dim GPM As Double
'   Dim gTD As Double                'Condenser T. D.
'   Dim subCoolingFactor As Double                'GLYCOL
'   Dim TE1 As Double
'   Dim TE2 As Double
'   Dim TW1 As Double
'   Dim TW2 As Double
'   Dim gMF1 As Double               'MULTIPLY FACTOR FOR COMPRESSORS
'   Dim gMF2 As Double               'MULTIPLY FACTOR FOR COMPRESSORS
'   Dim gMF3 As Double               'MULTIPLY FACTOR FOR COMPRESSORS
'   Dim Temp As Double
'   Dim gCatalogRating As Double               'PRINT OUT CATALOG RATINGS?Y/N
'   Dim gVolts As Double             'VOLTAGE
'   'TODO: reduce scope
'   Dim GPMFACT As Double            'GLYCOL
'   Dim fanWatts, Hertz2, Hertz3, Hertz4, Hertz21 As Double

'   'TODO: make local variable to CalculatePage
'   'it's only used there

'   Dim PD_GPM(13, 2) As Double
'   Dim gOD As Boolean                   'TEST FOR OPEN DRIVE
'   Dim gHP_O As Boolean                 'TEST FOR HORSEPOWER(OTHER)
'   Dim gPrint As Boolean                'TEST FOR PRINT SELECTION
'   Dim gClosed As Boolean               'TEST FOR DATA100.CLOSE
'   Dim Exit_Select As Boolean           'TEST FOR EXITING START SELECTION PROCEDURE
'   Dim Exit_Glycol As Boolean           'TEST FOR EXITING GLYCOL PROCEDURE

'   Dim gMyFileNameMDB As String

'#End Region


'   Dim loaded As Boolean = False
'   Dim gReportFilename As String = "" 'file name for report
'   Dim PASS_FILENAME As String = ""
'   Dim logger As Rae.RaeSolutions.Diagnostics.UsageLog.FormUsageLogger
'   'Dim dt As New DataTable
'   'Dim dc As DataColumn
'   Dim cd As RaeSolutions.CRDAL


'#Region " Properties"

'   Private Property AmbientTemp() As Double
'      Get
'         Return ConvertNull.ToDouble(Me.txtAmbientTemp.Text)
'      End Get
'      Set(ByVal Value As Double)
'         Me.txtAmbientTemp.Text = Value.ToString
'      End Set
'   End Property

'    Private Property EvapTemp() As Double
'        Get
'            Return ConvertNull.ToDouble(Me.txtLeavingFluidTemp.Text)
'        End Get
'        Set(ByVal Value As Double)
'            Me.txtLeavingFluidTemp.Text = Value.ToString
'        End Set
'    End Property



'   Private Property EnteringFluidTemp() As Double
'      Get
'         Return ConvertNull.ToDouble(Me.txtCondTemp.Text)
'      End Get
'      Set(ByVal Value As Double)
'         Me.txtLeavingFluidTemp.Text = Value.ToString
'      End Set
'   End Property

'   Private Property Refrigerant() As Rae.Engineering.Refrigerant
'      Get
'         Return New Rae.Engineering.Refrigerant(System.Enum.Parse(Rae.Engineering.RefrigerantType.R134a.GetType(), cboRefrigerant.SelectedIndex))
'      End Get
'      Set(ByVal value As Rae.Engineering.Refrigerant)
'         cboRefrigerant.SelectedIndex = CInt(value.Type)
'      End Set
'   End Property

'#End Region


'#Region " Event Handlers"

'#Region " Form Event Handlers"

'   ''' <summary>Authorizes user before showing privledge controls and info
'   ''' </summary>
'   ''' <history on="2006/2/26" by="Casey">Extracted/Created
'   ''' </history>
'   Private Sub Authorize()
'      Select Case AppInfo.User.Username.ToUpper
'         Case "CASEYJ", "JAYK", "SCOTTR", "JIMM"
'            Me.chkNewCoefficients.Visible = True
'         Case Else
'            Me.chkNewCoefficients.Visible = False
'      End Select
'      If AppInfo.User.AuthorityGroup > 2 Then Me.SetControlAccess()
'   End Sub

'   Private Sub ChillerWaterCooledForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
'      If Not Me.ProcessDeleted Then
'         If SaveControls(False, False, True) = False Then
'            e.Cancel = True
'         Else
'            RemoveHandler CType(My.Application.ApplicationContext.MainForm, MainForm).RevisionView1.RevisionChanged, AddressOf RevisionView_RevisionChanged
'         End If
'      End If
'   End Sub

'   'on form load
'   Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        Dim alI As ArrayList = Math.Calculate.Multiples(CInt(txtTempRange.Text))
'        cboStep.DataSource = alI
'        If alI.Contains(5) Then
'            cboStep.Text = "5"
'        Else
'            cboStep.Text = "1"
'        End If
'      'cd = New RaeSolutions.CRDAL
'      'cd.CRDAL(True)


'      'dc = New DataColumn
'      'dc.ColumnName = "TW"
'      'dc.DataType = System.Type.GetType("System.Double")
'      'dt.Columns.Add(dc)

'      'dc = New DataColumn
'      'dc.ColumnName = "TA"
'      'dc.DataType = System.Type.GetType("System.Double")
'      'dt.Columns.Add(dc)

'      'dc = New DataColumn
'      'dc.ColumnName = "TE"
'      'dc.DataType = System.Type.GetType("System.Double")
'      'dt.Columns.Add(dc)

'      'dc = New DataColumn
'      'dc.ColumnName = "TC"
'      'dc.DataType = System.Type.GetType("System.Double")
'      'dt.Columns.Add(dc)

'      'dc = New DataColumn
'      'dc.ColumnName = "Q"
'      'dc.DataType = System.Type.GetType("System.Double")
'      'dt.Columns.Add(dc)

'      'dc = New DataColumn
'      'dc.ColumnName = "KW"
'      'dc.DataType = System.Type.GetType("System.Double")
'      'dt.Columns.Add(dc)

'      'dc = New DataColumn
'      'dc.ColumnName = "GP"
'      'dc.DataType = System.Type.GetType("System.Double")
'      'dt.Columns.Add(dc)

'      'dc = New DataColumn
'      'dc.ColumnName = "A"
'      'dc.DataType = System.Type.GetType("System.Double")
'      'dt.Columns.Add(dc)

'      'dc = New DataColumn
'      'dc.ColumnName = "ER"
'      'dc.DataType = System.Type.GetType("System.Double")
'      'dt.Columns.Add(dc)

'      'dc = New DataColumn
'      'dc.ColumnName = "EZ"
'      'dc.DataType = System.Type.GetType("System.Double")
'      'dt.Columns.Add(dc)

'      'logs form usage statistics
'      Me.LogFormStart()
'      'SIZE WINDOW TO THE HEIGHT OF THE MAIN FORM's CLIENT AREA
'      Me.Height = Ui.FormEditor.MaximizeHeight(Me) 'me.MdiParent.ClientSize.Height - me.MdiParent.DockPadding.Top - me.MdiParent.DockPadding.Bottom - 5
'      'align child form to top of mdiparent's client area
'      Me.Location = New Point(Me.Location.X, 0)

'      ' colors controls' forecolors, backcolors, etc. using pre-defined color pallette
'      Me.ColorControls()

'      ' fills comboboxes
'      Me.FillComboboxes()

'      Dim condModels As System.Collections.Generic.List(Of Business.Entities.WCCondenser) = Business.Entities.WCCondenser.RetrieveCondensers '.Collections.Specialized.StringCollection = DataAccess35A0.RetrieveWCCondModels()
'      Me.cboCondenser1.DataSource = condModels
'      Me.cboCondenser2.DataSource = condModels
'      Me.cboCondenser1.DisplayMember = "Model"
'      Me.cboCondenser2.DisplayMember = "Model"

'      ' fills listboxes with compressor descriptions ({model} HP: {horsepower})
'      Me.FillCompressorListBoxes()

'      Me.InitializeControls()

'      Me.Authorize()

'      ' initializes validation utilities (managers, controls, and validators)
'      Me.InitializeValidation()
'      'ChillyRAEs_pass_no = 1 : ChillyRAE() '1 = Parms    2 = Models    3 = 8&10 deg approach

'      loaded = True

'      'add handler to revision view . revision changed event on main form...
'      Dim mainForm As MainForm = CType(My.Application.ApplicationContext.MainForm, MainForm)
'      AddHandler mainForm.RevisionView1.RevisionChanged, AddressOf RevisionView_RevisionChanged

'   End Sub


'   Private Sub Me_Closing(ByVal s As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
'   Handles MyBase.Closing
'      ' logs usage statistics
'      Me.LogFormEnd()
'   End Sub

'#End Region


'#Region " Button Event Handlers"


'   ' Select Alternative Evaporator



'   ' opens chart in popup form that displays
'   ' 1. Leaving Fluid Temp., 2. Recommended Glycol, 3. Freeze Point, 4. Minimum Suction Temp.
'   Private Sub btnGlycolChart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
'   Handles btnGlycolChart.Click
'      Dim form As New Windows.Forms.Form
'      Dim myGrid As New C1.Win.C1TrueDBGrid.C1TrueDBGrid
'      Dim glycolTable As DataTable
'      Dim glycol As String
'      Dim formWidth, formHeight As Integer

'      Me.Cursor = Windows.Forms.Cursors.WaitCursor

'      ' sets selected glycol (ethylene or propylene)
'      glycol = Me.cboCoolingMedia.SelectedItem.ToString

'      ' retrieves glycol table of recommendations
'      If glycol = "Ethylene" Then
'         glycolTable = DataAccess.Chillers.ChillerDataAccess.RetrieveEthylene()
'      ElseIf glycol = "Propylene" Then
'         glycolTable = DataAccess.Chillers.ChillerDataAccess.RetrievePropylene()
'      Else
'         Ui.MessageBox.Show("The selected fluid is water; the fluid must be a glycol in order to chart recommendations.", _
'            MessageBoxIcon.Information)
'         Exit Sub
'      End If

'      ' adds grid to form
'      ' Note: need to add grid to form before setting datasource
'      form.Controls.Add(myGrid)
'      ' sets datagrid's data source
'      myGrid.DataSource = glycolTable

'      ' sets column width and captions
'      With myGrid.Splits(0)
'         ' sets column properties
'         .ColumnCaptionHeight = 36

'         .DisplayColumns(GlycolNames.LeavingFluidTemperature).Width = 100
'         .DisplayColumns(GlycolNames.LeavingFluidTemperature).DataColumn.Caption = "Leaving Fluid Temperature [°F]"
'         .DisplayColumns(GlycolNames.FreezingPoint).Width = 80
'         .DisplayColumns(GlycolNames.FreezingPoint).DataColumn.Caption = "Freezing Point [°F]"
'         .DisplayColumns(GlycolNames.RecommendedGlycolPercentage).Width = 85
'         .DisplayColumns(GlycolNames.RecommendedGlycolPercentage).DataColumn.Caption = "Recommended Glycol [%]"
'         .DisplayColumns(GlycolNames.RecommendedMinSuctionTemperature).Width = 140
'         .DisplayColumns(GlycolNames.RecommendedMinSuctionTemperature).DataColumn.Caption = _
'            "Recommended Minimum Suction Temperature [°F]"
'      End With
'      myGrid.Dock = System.Windows.Forms.DockStyle.Fill
'      myGrid.Caption = glycol & " Table"

'      ' sets grid style to pre-defined style
'      Rae.Ui.C1GridStyles.BasicGridStyle(myGrid)

'      ' initializes form width to outer border width + vertical scroll bar width
'      formWidth = 5 * 2 + myGrid.VScrollBar.Width
'      For i As Integer = 0 To myGrid.Splits(0).DisplayColumns.Count - 1
'         ' calculates form width based on column width and inner borders
'         formWidth += myGrid.Splits(0).DisplayColumns(i).Width + 1
'      Next

'      ' calculates for height (just estimate)
'      formHeight = 34 + myGrid.CaptionHeight + myGrid.Splits(0).ColumnCaptionHeight
'      For i As Integer = 0 To myGrid.Splits(0).Rows.Count - 1
'         formHeight += myGrid.RowHeight + 1
'      Next

'      ' sets form properties
'      form.Width = formWidth
'      form.Height = formHeight
'      form.Text = glycol & " Recommendations"
'      form.MdiParent = Me.MdiParent
'      ' shows form w/ glycol chart
'      form.Show()

'      Me.Cursor = Windows.Forms.Cursors.Default
'   End Sub


'   Private Sub btnCalculatePage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
'   Handles btnCalculatePage.Click
'      ' checks if chiller model is valid
'      If Me.IsChillerModelValid = False Then
'         Ui.MessageBox.Show("Please select a valid chiller model.", MessageBoxIcon.Warning) : Exit Sub : End If

'      ' checks if validation controls are valid
'      If Not Me.chillerVMgr.Validate() Then
'         Ui.MessageBox.Show(Me.chillerVMgr.ErrorMessagesSummary, MessageBoxIcon.Warning) : Exit Sub : End If

'      Me.Cursor = Cursors.WaitCursor

'      Me.StartCalculations()

'      ' deletes temporary database, if there is multiple circuits
'      'Dim dbPath As String = AppInfo.AppFolderPath & "Reports\" & gMyFileNameMDB
'      'Common.IO.DeleteFile(dbPath)

'      Me.Cursor = Cursors.Arrow
'   End Sub


'   Private Sub btnCreateReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreateReport.Click
'      ' checks if chiller model is valid
'      If Me.IsChillerModelValid = False Then _
'         Ui.MessageBox.Show("Please select a valid chiller model.", MessageBoxIcon.Warning) : Exit Sub

'      Me.Cursor = Cursors.WaitCursor

'      Me.StartCalculations() ' calls calculate page
'      If Me.dgrC1Results.Visible = True Then
'         ' copies chiller results from temporary db to permanent db for report
'         'Me.CopyChillerResults()
'         ' builds and shows report
'         Me.ShowReport()
'         ' clears master 30 database (it held temporary info for crystal report)
'         'Try
'         'DataAccess.Chillers.Chiller.DeleteChillerResults()
'         'Catch ex As OleDb.OleDbException
'         'Ui.MessageBox.Show("Attempt to delete chiller results failed. " & ex.Message, MessageBoxButtons.OK)
'         'End Try
'      Else
'         Dim errorMessage As String = "Report could not be created."
'         If lblErro.Text = "" Then
'            lblErro.Text = errorMessage
'         Else
'            lblErro.Text &= Environment.NewLine & errorMessage
'         End If
'      End If

'      ' deletes database that the report was created from
'      'Dim dbPath As String = AppInfo.AppFolderPath & "Reports\" & gMyFileNameMDB
'      'Common.IO.DeleteFile(dbPath)
'      Me.Cursor = Cursors.Arrow
'   End Sub


'#End Region


'#Region " Combobox Event Handlers"


'   Private Sub cboSeries_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
'   Handles cboSeries.SelectedIndexChanged
'      ' sets series
'      Dim series As String = Me.cboSeries.SelectedItem.ToString
'      Dim seriesEnum = BCI.ChillerIntel.ConvertStringToSeries(series)

'      ' retrieves chiller models in the selected series
'      Dim chillerModels As DataTable = Rae.RaeSolutions.DataAccess.Chillers.ChillerDataAccess.RetrieveChillerModels(CInt(seriesEnum))


'      ' fills models combobox
'      Me.cboModels.DataSource = chillerModels
'      cboModels.DisplayMember = "Model"
'      loaded = True
'   End Sub

'   Private Function FindSelectedIndex(ByRef cbo As ComboBox, ByVal val As String) As Integer
'      For i As Integer = 0 To cbo.Items.Count - 1
'         If val = cbo.Items(i).ToString Then
'            Return i
'         End If
'      Next
'      Return 0
'   End Function

'   'Model Number combobox selected index changed
'   Private Sub cboModelNumbers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboModels.SelectedIndexChanged
'      Me.Cursor = Cursors.WaitCursor
'      Dim chill As String = Me.GrabChillerModel()
'      'If loaded = True And Me.GrabChillerModel() <> "Choose" Then

'      'Dim condModels As System.Collections.Generic.List(Of Business.Entities.WCCondenser) = Business.Entities.WCCondenser.RetrieveCondensers
'      'Me.cboCondenser1.DataSource = condModels
'      'Me.cboCondenser2.DataSource = condModels

'      'HL_printout.NavigateUrl() = ""
'      dgrC1Results.Visible = False 'hide datagrid
'      lblErro.Text() = "" 'Clear error label text
'      Running_Circuit_no = 1 : CALL_Circuit1()

'      If Val(Txt_circuit_per_unit.Text()) > 1 Then
'         Running_Circuit_no = 2 : CALL_Circuit2()
'      End If

'      ' shows/hides evaporator capacity textboxes
'      Me.SetOtherEvaporatorVisibility()

'      If Val(Txt_circuit_per_unit.Text()) > 1 Then
'         'txtNumFans2.Visible = True
'         txtNumCompressors2.Visible = True
'         txtCompressor2.Visible = True
'      Else
'         txtNumFans2.Visible = False
'         txtNumCompressors2.Visible = False
'         txtCompressor2.Visible = False
'      End If

'      Dim cond1 As New Business.Entities.WCCondenser(DataAccess.WaterCooledDA.RetrieveCondenserByChiller(chill, 1))
'      Me.cboCondenser1.SelectedIndex = FindSelectedIndex(cboCondenser1, cond1.Model)
'      If Val(Txt_circuit_per_unit.Text()) = 4 Then
'         Dim cond4 As New Business.Entities.WCCondenser(DataAccess.WaterCooledDA.RetrieveCondenserByChiller(chill, 4))
'         Me.cboCondenser2.SelectedIndex = FindSelectedIndex(cboCondenser2, cond4.Model)
'         radCircuit1.Text = "Circuit 1 and 3"
'         radCircuit2.Text = "Circuit 2 and 4"
'         lblCircuit1.Text = "Circuit 1 and 3"
'         lblCircuit2.Text = "Circuit 2 and 4"
'         txtCondenserTD2.Enabled = True
'      Else
'         If Val(Txt_circuit_per_unit.Text()) = 2 Then
'            Dim cond2 As New Business.Entities.WCCondenser(DataAccess.WaterCooledDA.RetrieveCondenserByChiller(chill, 2))
'            Me.cboCondenser2.SelectedIndex = FindSelectedIndex(cboCondenser2, cond2.Model)
'         End If
'         radCircuit1.Text = "Circuit 1"
'         radCircuit2.Text = "Circuit 2"
'         lblCircuit1.Text = "Circuit 1"
'         lblCircuit2.Text = "Circuit 2"
'         txtCondenserTD2.Enabled = True
'      End If



'      SetFanWatts()

'      Me.txtModel.Text = Me.GrabChillerModel()
'      'End If


'      ChillyRAEs_pass_no = 2  ' 1 = Parms    2 = Models    3 = 8&10 deg approach
'      ChillyRAE()

'      'If loaded = True Then
'      Dim line As String = Environment.NewLine



'      Me.dgrC1Results.Visible = False
'      Me.lblErro.Text = ""

'      ChillyRAEs_pass_no = 3  '1 = Parms    2 = Models    3 = 8&10 deg approach
'      ChillyRAE()
'      FillCompressorListBoxes()
'      SetCompressors()
'      'End If

'      Me.Cursor = Cursors.Arrow
'   End Sub

'   'hertz
'   Private Sub cboHertz_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHertz.SelectedIndexChanged
'      If loaded = True Then

'         'HL_printout.NavigateUrl() = ""
'         dgrC1Results.Visible = False 'C1WebGrid2.Visible = False
'         lblErro.Text() = ""

'         Dim switchedFan As String
'         Dim fanFileName As String = Me.GrabFan.FileName

'         If cboHertz.SelectedItem = "60" Then
'            lblRatiVolt.Visible = False
'            lblRatiVolt1.Visible = False
'            Select Case fanFileName
'               Case "LAU2429.950" : switchedFan = "LAU2429"
'               Case "BR28IN.950" : switchedFan = "BR28IN"
'               Case "BR28INHA.950" : switchedFan = "BR28IN.HA"
'               Case "BR28IN.708" : switchedFan = "LAU2840.850"
'               Case "S42832.950" : switchedFan = "S42832"
'            End Select
'         Else
'            Select Case fanFileName
'               Case "LAU2429" : switchedFan = "LAU2429.950"
'               Case "BR28IN" : switchedFan = "BR28IN.950"
'               Case "BR28IN.HA" : switchedFan = "BR28INHA.950"
'               Case "LAU2840.850" : switchedFan = "BR28IN.708" 'REP    (BR28IN.708 HOUSE VERSION)
'               Case "S42832" : switchedFan = "S42832.950"
'            End Select

'            Me.lblRatiVolt.Visible = True
'            Me.lblRatiVolt1.Visible = True
'         End If

'         Dim xxx, xxxx As Single
'         xxxx = cboFan.Items.Count()
'         For xxx = 0 To (xxxx - 1) Step 1
'            cboFan.SelectedIndex = xxx
'            If Me.GrabFan.FileName = switchedFan Then
'               Exit For
'            End If
'            If cboFan.SelectedIndex = (xxxx - 1) Then
'               cboFan.SelectedIndex = 0
'               Exit For
'            End If
'         Next xxx

'         Me.SetFanWatts()
'      End If
'   End Sub

'   Private Sub SetCompressors()
'      Dim compressor As String
'      Dim chillerTable As DataTable = DataAccess.Chillers.ChillerDataAccess.RetrieveChiller(Me.GrabChillerModel(), Rae.RaeSolutions.DataAccess.Common.WCCondenserDbPath)

'      ' checks if there is a matching chiller, if model is set to 'Choose', there won't be a match
'      If chillerTable.Rows.Count > 0 Then
'         ' sets compressor for circuit 1
'         compressor = chillerTable.Rows(0)("Compressor_1").ToString
'         ' selects compressor
'         Me.lboCompressors1.SelectedIndex = ControlAssistant.GetIndexOfValueInListBox(Me.lboCompressors1, compressor)
'         If (compressor <> "" And compressor <> "0") AndAlso Me.lboCompressors1.SelectedIndex = 0 Then
'            Dim compfile As String = chillerTable.Rows(0)("Comprfile_1").ToString
'            For ix As Integer = 0 To Me.lboCompressors1.Items.Count - 1
'               If compfile.ToUpper = Me.lboCompressors1.Items(ix).Row("compfile").ToString().ToUpper Then
'                  Me.lboCompressors1.SelectedIndex = ix
'               End If
'            Next
'         End If
'         ' sets compressor for circuit 2
'         compressor = chillerTable.Rows(0)("Compressor_2").ToString
'         ' selects compressor
'         Me.lboCompressors2.SelectedIndex = ControlAssistant.GetIndexOfValueInListBox(Me.lboCompressors2, compressor)
'         If (compressor <> "" And compressor <> "0") AndAlso Me.lboCompressors2.SelectedIndex = 0 Then
'            Dim compfile As String = chillerTable.Rows(0)("Comprfile_2").ToString
'            For ix As Integer = 0 To Me.lboCompressors1.Items.Count - 1
'               If compfile.ToUpper = Me.lboCompressors2.Items(ix).Row("compfile").ToString().ToUpper Then
'                  Me.lboCompressors2.SelectedIndex = ix
'               End If
'            Next
'         End If

'      End If
'   End Sub


'   'refrigerant	
'   Private Sub cboRatiCritRefr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRefrigerant.SelectedIndexChanged
'      Dim compressor As String

'      If loaded = True Then
'         Me.FillCompressorListBoxes()
'         ' retrieves chiller compressor
'         SetCompressors()
'         ChillyRAEs_pass_no = 1 : ChillyRAE()
'         'fills approach and evaporator capacity
'         ChillyRAEs_pass_no = 3 : ChillyRAE()
'      End If
'   End Sub


'   Private Sub cboRatiCritSyst_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSystem.SelectedIndexChanged
'      dgrC1Results.Visible = False
'      lblErro.Text() = ""
'   End Sub

'   Private Sub cboCondCond2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCondenser2.SelectedIndexChanged
'      If loaded = True Then
'         SetCondenserCapacity()
'         ChangeCoilDescription()
'      End If
'   End Sub

'   Private Sub cboCondCond1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCondenser1.SelectedIndexChanged
'      If loaded = True Then
'         SetCondenserCapacity()
'         ChangeCoilDescription()
'      End If
'   End Sub

'   Private Sub cboCondFan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFan.SelectedIndexChanged
'      If loaded = True Then
'         dgrC1Results.Visible = False
'         lblErro.Text() = ""

'         If Me.GrabFan.FileName = "CFM Per Fan >>>" Then
'            Me.txtCfmOverride.Visible = True
'            Me.lblCFM.Visible = True
'            Me.txtFanWatts.ReadOnly = False
'         Else
'            Me.txtCfmOverride.Visible = False
'            Me.lblCFM.Visible = False
'            Me.txtFanWatts.ReadOnly = True
'         End If

'         SetFanWatts()
'      End If
'   End Sub

'   Private Sub cboRatiCritMedi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoolingMedia.SelectedIndexChanged
'      If loaded = True Then
'         'HL_printout.NavigateUrl() = ""
'         dgrC1Results.Visible = False
'         lblErro.Text() = ""

'         ChillyRAEs_pass_no = 1  '1 = Parms    2 = Models    3 = 8&10 deg approach
'         ChillyRAE()
'      End If
'   End Sub

'   Private Sub cboRatiCritFlui_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFluid.SelectedIndexChanged
'      Me.Cursor = Windows.Forms.Cursors.WaitCursor

'      dgrC1Results.Visible = False
'      lblErro.Text() = ""

'      If cboFluid.SelectedItem = "Water" Then
'         cboCoolingMedia.Visible = False
'         txtGlycolPercentage.Enabled = False
'         'glycol percentage
'         txtGlycolPercentage.Text() = "0"
'         Me.btnGlycolChart.Visible = False
'         'glycol selected
'      Else
'         Me.cboCoolingMedia.Visible = True
'         Me.txtGlycolPercentage.Enabled = True
'         'glycol percentage
'         Me.txtGlycolPercentage.Text = "20"
'         Me.btnGlycolChart.Visible = True
'      End If
'      If loaded Then
'         'sets specific heat and gravity
'         ChillyRAEs_pass_no = 1  '1 = Parms    2 = Models    3 = 8&10 deg approach
'         ChillyRAE()
'         CalculateFreezePoint()
'      End If

'      Me.Cursor = Windows.Forms.Cursors.Default
'   End Sub

'#End Region


'#Region " Radiobox Event Handlers"

'   Private Sub radCompCirc1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radCircuit1.CheckedChanged
'      If radCircuit1.Checked = True Then
'         lboCompressors1.Enabled = True
'         lboCompressors2.Enabled = False
'         Running_Circuit_no = 1
'         'CALL_Circuit1()
'      End If
'   End Sub


'   Private Sub radCompCirc2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radCircuit2.CheckedChanged
'      If radCircuit2.Checked = True Then
'         lboCompressors2.Enabled = True
'         lboCompressors1.Enabled = False
'         Running_Circuit_no = 2
'         'CALL_Circuit2()
'      End If
'   End Sub


'   Private Sub radEvapOtheEvap_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
'      Me.SetOtherEvaporatorVisibility()
'   End Sub


'#End Region


'#Region " Textbox Event Handlers"

'   Private Sub txtGlycolPercentage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
'   Handles txtGlycolPercentage.TextChanged
'      If Me.loaded = True Then
'         ChillyRAEs_pass_no = 1  '1 = Parms    2 = Models    3 = 8&10 deg approach
'         ChillyRAE()
'      End If
'   End Sub


'   Private Sub txtLeavingFluidTemp_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
'   Handles txtLeavingFluidTemp.Leave
'      ' validates leaving fluid temperature textbox value
'      Me.leavingFluidTempVCtrl.Validate()
'   End Sub

'   '1. hide error pic if no errors occurred
'   '2. set error text's tooltip
'   Private Sub lblErro_TextChanged(ByVal s As Object, ByVal e As EventArgs) _
'   Handles lblErro.TextChanged
'      ToolTip1.SetToolTip(lblErro, lblErro.Text)
'      If lblErro.Text = "" Then
'         picError.Visible = False
'      Else
'         picError.Visible = True
'      End If
'   End Sub

'#End Region


'#Region " Listbox Event Handlers"

'   Private Sub lbxComp1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lboCompressors1.MouseDown
'      If loaded = True Then
'         If Me.radCircuit1.Checked Then
'            Running_Circuit_no = 1
'            Me.txtCompressor1.Text = Me.lboCompressors1.SelectedValue.ToString
'         End If
'      End If
'   End Sub


'   Private Sub lbxComp2_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lboCompressors2.MouseDown
'      If loaded = True Then
'         If radCircuit2.Checked = True Then
'            Running_Circuit_no = 2
'            Me.txtCompressor2.Text = Me.lboCompressors2.SelectedValue.ToString
'         End If
'      End If
'   End Sub


'   Private Sub lbxComp1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lboCompressors1.SelectedIndexChanged
'      Me.txtCompressor1.Text = Me.lboCompressors1.SelectedValue.ToString
'   End Sub


'   Private Sub lbxComp2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lboCompressors2.SelectedIndexChanged
'      Me.txtCompressor2.Text = Me.lboCompressors2.SelectedValue.ToString
'   End Sub


'#End Region


'#Region " Menu Event Handlers"

'#End Region


'#Region " Panel Event Handlers"
'   '****************************************************************
'   '** Button events that hide/show the panels containing the different
'   '** sections (Compressor, Condenser, etc) of the form
'   '****************************************************************

'   'Rating Criteria Hide Button
'   Private Sub butRatiCritPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCriteriaPlus.Click
'      If Me.btnCriteriaPlus.Text = "+" Then
'         Me.panRatiCritHide.Show()
'         Me.btnCriteriaPlus.Text = "-"
'      Else
'         Me.panRatiCritHide.Hide()
'         Me.btnCriteriaPlus.Text = "+"
'      End If
'   End Sub
'   'Compressor data Hide Button
'   Private Sub butCompDataPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompressorPlus.Click
'      If Me.btnCompressorPlus.Text = "+" Then
'         Me.panCompDataHide.Show()
'         Me.btnCompressorPlus.Text = "-"
'      Else
'         Me.panCompDataHide.Hide()
'         Me.btnCompressorPlus.Text = "+"
'      End If
'   End Sub
'   'Condenser Data Hide Button
'   Private Sub butCondPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCondenserPlus.Click
'      If Me.btnCondenserPlus.Text = "+" Then
'         Me.panCondHide.Show()
'         Me.btnCondenserPlus.Text = "-"
'      Else
'         Me.panCondHide.Hide()
'         Me.btnCondenserPlus.Text = "+"
'      End If
'   End Sub


'#End Region


'#End Region


'#Region " Helper Methods"

'   ''' <summary>Logs usage statistics available while form is closing.
'   ''' </summary>
'   ''' <history>[CASEYJ]	3/15/2005	Created
'   ''' </history>
'   Private Sub LogFormEnd()
'      Dim model, refrigerant As String
'      Dim suctionTemperature As Single

'      Try
'         suctionTemperature = Me.txtSuctionTemp.Text
'         model = Me.GrabChillerModel()
'         refrigerant = Me.cboRefrigerant.SelectedItem.DisplayName
'         'logs form usage statistics
'         logger.LogFormEnd(model, refrigerant, suctionTemperature, Me.AmbientTemp)
'      Catch ex As Exception

'      End Try
'   End Sub


'   ''' <summary>Logs start of form.
'   ''' </summary>
'   ''' <history>[CASEYJ]	3/15/2005	Created
'   ''' </history>
'   Private Sub LogFormStart()
'      Try
'         'logs form usage statistics
'         logger = New Diagnostics.UsageLog.FormUsageLogger( _
'            Diagnostics.UsageLog.ApplicationUsageLogger.ApplicationID, _
'            Diagnostics.UsageLog.ApplicationUsageLogger.LogFile.FullName)
'         logger.LogFormStart(Me.Text)
'      Catch ex As Exception

'      End Try
'   End Sub


'   ''' <summary>Fills comboboxes with display and hidden values
'   ''' </summary>
'   Private Sub FillComboboxes()

'      ' fills refrigerant combobox
'      Dim dtbRef As DataTable = Utility.Enum2DataTable(Rae.Engineering.RefrigerantType.R134a)
'      With Me.cboRefrigerant
'         .DataSource = dtbRef 'Me.GetRefrigerants()
'         .DisplayMember = "Key"
'         .ValueMember = "Value"
'         For i As Integer = 0 To .Items.Count - 1
'            Dim drv As DataRowView = .Items(i)
'            If drv.Row("Key") = "R22" Then
'               .SelectedIndex = i
'            End If
'         Next
'      End With

'      '' fills condenser comboboxes
'      'Me.cboCondenser1.DataSource = DataAccess.Chillers.ChillerDataAccess.GetCondensers()
'      'Me.cboCondenser2.DataSource = DataAccess.Chillers.ChillerDataAccess.GetCondensers()

'      ' fills fan comboboxes
'      Me.cboFan.DataSource = CondenserDataAccess.GetChillerFans()

'      ' fills fins per inch comboboxes
'      'Me.cboFinsPerInch1.DataSource = Me.GetFinsPerInchOptions()
'      'Me.cboFinsPerInch2.DataSource = Me.GetFinsPerInchOptions()

'   End Sub

'   Public Function writexmldata(ByVal formname As Form) As Boolean
'      Dim ctl As Control, ctl2 As Control, ctl3 As Control
'      For Each ctl In formname.Controls
'         If ctl.Name Like "i_*" Then

'         End If
'         If ctl.HasChildren = True Then
'            For Each ctl2 In ctl.Controls
'               If ctl2.Name Like "i_*" Then

'               End If
'            Next
'         End If
'      Next
'   End Function



'   Private Sub ShowReport()
'      Dim report As CREngine.ReportDocument
'      Dim dbPath As String
'      Dim fields As CREngine.ParameterFieldDefinitions
'      Dim field As Rae.Reporting.CrystalReports.SingleParameterFieldDefinition
'      Dim evaporator8, evaporator10, condenserCapacity, fan As String
'      Dim reportForm As Rae.Reporting.CrystalReports.ReportViewerForm
'      Dim chillerModel, condenser, system, fluid, circuitNote, operatingLimits, catalogRating As String
'      Dim numCompressors1, numCompressors2, compressorFileName1, compressorFileName2, compressor As String
'      Dim circuitsPerUnit, lowerApproach, upperApproach As Integer

'      report = New CREngine.ReportDocument()
'      report.Load(Reports.FilePaths.WaterCooledCondenserRatingReportFilePath)
'      reportForm = New Rae.Reporting.CrystalReports.ReportViewerForm()

'      'sets database location so it's not pointing to database location
'      'on the development computer
'      'dbPath = AppInfo.Database(eDatabase.dbMaster30)
'      Try
'         Dim dt2 As DataTable
'         dt2 = cd.dt.Copy()
'         'dt2.WriteXml("C:\" & dt2.TableName & ".xml")
'         'report.SetDataSource(cd.ds)
'         report.SetDataSource(dt2)
'         'report.DataSourceConnections.Item(0).SetConnection(dbPath, dbPath, "", "")
'         'report.DataSourceConnections.Item(0).SetConnection()

'      Catch ex As Exception
'         MessageBox.Show( _
'            "Attempt to set the database connection for the report failed." & _
'            Environment.NewLine & dbPath & Environment.NewLine & ex.ToString, _
'            "Crystal Reports", MessageBoxButtons.OK, MessageBoxIcon.Error)
'      End Try

'      fields = report.DataDefinition.ParameterFields
'      field = New Rae.Reporting.CrystalReports.SingleParameterFieldDefinition(fields)


'      ' sets parameters
'      '
'      If Me.txtModel.Text = Me.GrabChillerModel() Then
'         chillerModel = Me.GrabChillerModel()
'      Else
'         chillerModel = Me.txtModel.Text & "       Base Model: " & Me.GrabChillerModel()
'      End If

'      ' TODO: remove condenser textbox it's only used for report
'      If cboSystem.SelectedItem = "FULL" And Val(Txt_circuit_per_unit.Text()) = 2 _
'      Or Val(Txt_circuit_per_unit.Text()) = 4 Then
'         condenser = "(" & Me.txtNumCoils1.Text & ")" & Me.txtCondenser_1.Text.Trim _
'          & " --- " & "(" & Me.txtNumCoils2.Text & ")" & Me.txtCondenser_2.Text.Trim
'      ElseIf cboSystem.SelectedItem = "FULL" And Val(Txt_circuit_per_unit.Text()) = 1 Then
'         condenser = "(" & Me.txtNumCoils1.Text & ")" & Me.txtCondenser_1.Text.Trim
'      ElseIf cboSystem.SelectedItem = "HALF" And radCircuit1.Checked = True Then
'         condenser = "(" & Me.txtNumCoils1.Text & ")" & Me.txtCondenser_1.Text.Trim
'      ElseIf cboSystem.SelectedItem = "HALF" And radCircuit2.Checked = True Then
'         condenser = "(" & Me.txtNumCoils2.Text & ")" & Me.txtCondenser_2.Text.Trim
'      End If

'      system = Me.cboSystem.SelectedItem.ToString
'      circuitsPerUnit = CInt(Me.Txt_circuit_per_unit.Text.Trim)
'      numCompressors1 = Me.txtNumCompressors1.Text.Trim
'      numCompressors2 = Me.txtNumCompressors2.Text.Trim
'      compressorFileName1 = DirectCast(Me.lboCompressors1.SelectedItem, DataRowView)("compfile").ToString
'      compressorFileName2 = DirectCast(Me.lboCompressors2.SelectedItem, DataRowView)("compfile").ToString

'      If system = "FULL" And circuitsPerUnit = 1 Then
'         compressor = "(" & numCompressors1 & ") " & compressorFileName1
'      ElseIf system = "FULL" And circuitsPerUnit = 2 _
'      Or circuitsPerUnit = 4 Then
'         compressor = "(" & numCompressors1 & ") " & compressorFileName1 & _
'            " --- " & "(" & numCompressors2 & ") " & compressorFileName2
'      ElseIf system = "HALF" And Me.radCircuit1.Checked Then
'         compressor = "(" & numCompressors1 & ") " & compressorFileName1
'      ElseIf system = "HALF" And Me.radCircuit2.Checked Then
'         compressor = "(" & numCompressors2 & ") " & compressorFileName2
'      End If

'      If cboFluid.SelectedItem = "Water" Then
'         fluid = cboFluid.SelectedItem
'      Else
'         fluid = Me.cboFluid.SelectedItem.ToString & "   " & Me.txtGlycolPercentage.Text.Trim & "% " & Me.cboCoolingMedia.SelectedItem.ToString
'      End If

'      If system = "HALF" Then
'         If radCircuit1.Checked Then
'            If Val(Me.Txt_circuit_per_unit.Text) = 1 Then
'               circuitNote = "Showing Circuit 1 of 1"
'            Else
'               circuitNote = "Showing Circuit 1 of 2"
'            End If
'         Else
'            circuitNote = "Showing Circuit 2 of 2"
'         End If
'      Else
'         circuitNote = " "
'      End If

'      If lblOperLimi.Visible = True Then
'         operatingLimits = Me.lblOperLimi.Text ' Points Omitted
'      Else
'         operatingLimits = ""
'      End If



'      ' 8F Evaporator, 10F Evaporator, Condenser Capacity @ 25F, Fan
'      If cboSystem.SelectedItem = "FULL" And Val(Txt_circuit_per_unit.Text) = 1 Then


'         condenserCapacity = Val(Me.txtCondenserCapacity1.Text)
'         If Me.GrabFan.FileName = "CFM Per Fan >>>" Then
'            fan = "(" & Val(txtNumFans1.Text) * Val(txtNumCoils1.Text) & ") " _
'            & Me.GrabFan.FileName & txtCfmOverride.Text & "   Altitude = " & txtAltitude.Text
'         Else
'            fan = "(" & Val(txtNumFans1.Text) * Val(txtNumCoils1.Text) & ") " _
'            & Me.GrabFan.Description & "   Altitude = " & Me.txtAltitude.Text
'         End If
'      ElseIf cboSystem.SelectedItem = "FULL" And Val(Txt_circuit_per_unit.Text) = 2 _
'      Or Val(Txt_circuit_per_unit.Text) = 4 Then

'         condenserCapacity = Val(txtCondenserCapacity1.Text) + Val(txtCondenserCapacity2.Text)
'         If Me.GrabFan.FileName = "CFM Per Fan >>>" Then
'            fan = "(" & (Val(txtNumFans1.Text) * Val(txtNumCoils1.Text)) + (Val(txtNumFans2.Text) * Val(txtNumCoils2.Text)) & ") " _
'            & Me.GrabFan.FileName & Val(txtCfmOverride.Text) & "   Altitude = " & Val(txtAltitude.Text)
'         Else
'            fan = "(" & (Val(txtNumFans1.Text) * Val(txtNumCoils1.Text)) + (Val(txtNumFans2.Text) * Val(txtNumCoils2.Text)) & ") " _
'            & Me.GrabFan.Description & "   Altitude = " & Me.txtAltitude.Text
'         End If
'      ElseIf cboSystem.SelectedItem = "HALF" And radCircuit1.Checked = True Then

'         condenserCapacity = Val(txtCondenserCapacity1.Text)
'         If Me.GrabFan.FileName = "CFM Per Fan >>>" Then
'            fan = "(" & Val(txtNumFans1.Text()) * Val(txtNumCoils1.Text()) & ") " & Me.GrabFan.FileName & Val(txtCfmOverride.Text()) & "   Altitude = " & Val(txtAltitude.Text())
'         Else
'            fan = "(" & Val(txtNumFans1.Text()) * Val(txtNumCoils1.Text()) & ") " & Me.GrabFan.Description & "   Altitude = " & Val(txtAltitude.Text())
'         End If
'      ElseIf cboSystem.SelectedItem = "HALF" And radCircuit2.Checked = True Then

'         condenserCapacity = txtCondenserCapacity2.Text
'         If Me.GrabFan.FileName = "CFM Per Fan >>>" Then
'            fan = "(" & Val(txtNumFans2.Text()) * Val(txtNumCoils2.Text()) & ") " & Me.GrabFan.Description & Val(txtCfmOverride.Text()) & "   Altitude = " & Val(txtAltitude.Text())
'         Else
'            fan = "(" & Val(txtNumFans2.Text()) * Val(txtNumCoils2.Text()) & ") " & Me.GrabFan.Description & "   Altitude = " & Val(txtAltitude.Text())
'         End If
'      End If

'      If chkCatalogRating.Checked = True Then
'         catalogRating = "Catalog Rating"
'      Else
'         catalogRating = ""
'      End If

'      ' authorization ("Rep" or "Engineer")
'      field.Pass("Engineer", "pfdAuthorization")
'      ' version
'      field.Pass(My.Application.Info.Version.ToString, "pfdVersion")
'      ' ambient Temperature (so row with entered Ambient and Leaving Fluid Temp can be uniquely formatted)
'      field.Pass(Me.AmbientTemp, "pfdAmbient")
'      ' leaving fluid temperature
'        field.Pass(Me.EvapTemp, "pfdLeavingFluid")
'      ' test
'      field.Pass(Constants.TESTING.ToString, "pfdTest")
'      ' logo
'      field.Pass("TSI", "pfdLogo")
'      ' user name for login
'      field.Pass(AppInfo.User.Username, "pfdCreator")
'      ' model number
'      field.Pass(chillerModel, "pfdModelNumber")
'      ' condenser
'      field.Pass(condenser, "pfdCondenser")
'      ' evaporator

'      ' system
'      field.Pass(system, "pfdSystem")
'      ' compressor
'      field.Pass(compressor, "pfdCompressor")
'      ' fan is set below
'      ' fluid
'      field.Pass(fluid, "pfdFluid")
'      ' refrigerant
'      field.Pass(Me.Refrigerant.Name, "pfdRefrigerant")
'      ' hertz
'      field.Pass(Me.cboHertz.SelectedItem, "pfdHertz")
'      ' circuit
'      field.Pass(circuitNote, "pfdCircuit")
'      ' operating limits
'      field.Pass(operatingLimits, "pfdOperatingLimits")
'      ' temperature range
'      field.Pass("Calculations based on " & Me.txtTempRange.Text.Trim & "ºF Range", "pfdRange")

'      'Change:          Report always shows 8 and 10 degree approach regardless of the approach selected on form.

'      '                 Previously, the approach selected was being shown, but the labels always said 8 and 10, 
'      '                 even if the approach was different.

'      'Requested by:    Jim McLarty
'      'Modified by:     Casey Joyce
'      'Date modified:   12/9/2004
'      ' lower approach
'      field.Pass(lowerApproach, "pfdLowerApproach")
'      ' upper approach
'      field.Pass(upperApproach, "pfdUpperApproach")

'      ' 8F Evaporator
'      'field.Pass(evaporator8, "pfd8Evaporator")
'      '' 10F Evaporator
'      'field.Pass(evaporator10, "pfd10Evaporator")
'      ' Condenser Capacity
'      field.Pass(condenserCapacity, "pfdCondenserCapacity")
'      ' fan (set here because, value is based on variables that weren't set before)
'      field.Pass(fan, "pfdfans")
'      ' discharge line loss
'      field.Pass(Me.cboDischargeLineLoss.SelectedItem, "pfdDischarge")
'      ' suction line loss
'      field.Pass(Me.cboSuctionLineLoss.SelectedItem, "pfdSuction")
'      ' catalog rating
'      field.Pass(catalogRating, "pfdCatalog")


'      ' sets CR Viewer report source to appropriate CR Report
'      reportForm.ReportViewer.ReportSource = report
'      ' alternatively can be set with file path as below
'      'ReportForm.CRViewer1.ReportSource = "..\Report1.rpt"
'      reportForm.ReportViewer.Zoom(1) '1 = page width, 2 = whole page, else %
'      reportForm.Show()
'   End Sub


'   'sets hid condenser textboxes w/
'   '1. Changed Coil Type
'   '2. Condenser Fin Height
'   '3. Condenser Fin Length
'   '4. Fins per Inch
'   '5. Changed Rows
'   '6. Sub Cooling (Yes/No)
'   Private Sub ChangeCoilDescription()
'      Dim numRows As String
'      Dim coilType As String = "12"
'      Dim subCooling As String = ""

'      ' condenser 1
'      If cboCondenser1.SelectedIndex = 0 Then
'         numRows = "2"
'      ElseIf cboCondenser1.SelectedIndex = 1 Then
'         numRows = "3"
'      ElseIf cboCondenser1.SelectedIndex = 2 Then
'         numRows = "4"
'      ElseIf cboCondenser1.SelectedIndex = 3 Then
'         numRows = "5"
'      ElseIf cboCondenser1.SelectedIndex = 4 Then
'         numRows = "6"
'      End If
'      ' sub cooling
'      If cboSubCooling1.SelectedItem = "Yes" Then
'         subCooling = "-S/C"
'      End If
'      ' sets hid condenser 1 textbox
'      'Me.txtCondenser_1.Text = coilType & "C" & txtFinHeight1.Text & "X" & Me.txtFinLength1.Text & _
'      '   "-" & Me.cboFinsPerInch1.SelectedItem.ToString & "-" & numRows & "-1C" & subCooling

'      ' condenser 2
'      'If cboCondenser2.SelectedIndex = 0 Then
'      ' numRows = "2"
'      'ElseIf cboCondenser2.SelectedIndex = 1 Then
'      'numRows = "3"
'      'ElseIf cboCondenser2.SelectedIndex = 2 Then
'      'numRows = "4"
'      'ElseIf cboCondenser2.SelectedIndex = 3 Then
'      'numRows = "5"
'      'ElseIf cboCondenser2.SelectedIndex = 4 Then
'      'numRows = "6"
'      'End If

'      ' sub cooling
'      If cboSubCooling2.SelectedItem = "Yes" Then
'         subCooling = "-S/C"
'      Else
'         subCooling = ""
'      End If

'      'Me.txtCondenser_2.Text = coilType & "C" & Val(txtFinHeight2.Text) & "X" & Val(txtFinLength2.Text) & _
'      '   "-" & cboFinsPerInch2.SelectedItem.ToString & "-" & numRows & "-1C" & subCooling

'      ''''SetCondenserCapacity()

'   End Sub

'   '    Private Sub Do_Calc_2()

'   '        T = TE + 459.69

'   '        If gRef = "R-22" Then
'   '            P = 29.35754453 + (-3845.193152 / T) + (-7.86103122 * (Log(T) / Log(10))) + (0.002190939 * T) + ((0.445746703 * (686.1 - T)) / T) * (Log(686.1 - T) / Log(10))
'   '            PE = 10 ^ P
'   '        ElseIf gRef = "404" Then
'   '            P = 72.1209 + (-7315.14 / T) + ((-8.717729) * (Log(T)) + (0.0000051875 * T ^ 2))
'   '            PE = 2.7182818 ^ P
'   '        ElseIf gRef = "507" Then
'   '            P = 29.24862663 + (-6980.5944 / T) + (-0.03143806111 * T) + (0.00002034543662 * T ^ 2)
'   '            PE = 2.7182818 ^ P
'   '        ElseIf gRef = "R-502" Then
'   '            P = 10.644955 + (-3671.153813 / T) + (-0.369835 * (Log(T) / Log(10))) + (-0.001746352 * T) + ((0.8161139 * (654 - T)) / T) * (Log(654 - T) / Log(10))
'   '            PE = 10 ^ P
'   '        ElseIf gRef = "407C" Then
'   '            P = 78.3549 + (-8101.06 / T) + (-9.51789 * Log(T)) + (0.0000053558 * (T ^ 2))
'   '            PE = 2.7182818 ^ P
'   '        ElseIf gRef = "134A" Then
'   '            P = 22.98993635 + (-7243.876722 / T) + (-0.013362956 * T) + (0.00000692966 * T ^ 2) + ((0.1995548 * (674.72514 - T)) / T) * (Log(674.72514 - T))
'   '            PE = 2.7182818 ^ P
'   '        End If

'   '        ''''''''''''''''''''''''''''''11111095 TC = 95: GoTo 11900000 '*********************************************************
'   '11000000: Z = 1 : GoTo 11800000
'   '11100000: TC = TC + 10
'   '11200000: GoTo 11800000
'   '11300000: TC = TC + 5
'   '11400000: GoTo 11800000
'   '11500000: TC = TC + 1
'   '11600000: GoTo 11800000
'   '11700000: TC = TC + 0.2
'   '11800000: H1 = (TC - T1) / M
'   '11900000: T = TC + 459.69

'   '        If gRef = "R-22" Then
'   '            P = Round(29.35754453 + (-3845.193152 / T) + (-7.86103122 * (Log(T) / Log(10))) + (0.002190939 * T) + ((0.445746703 * (686.1 - T)) / T) * (Log(686.1 - T) / Log(10)), 10)
'   '            PC = Round(10 ^ P, 16)
'   '        ElseIf gRef = "404" Then
'   '            P = 57.5895 + (-6526.55 / T) + ((-6.58061) * (Log(T)) + (0.00000393732 * T ^ 2))
'   '            PC = 2.7182818 ^ P
'   '        ElseIf gRef = "507" Then
'   '            P = 29.24862663 + (-6980.5944 / T) + (-0.03143806111 * T) + (0.00002034543662 * T ^ 2)
'   '            PC = 2.7182818 ^ P
'   '        ElseIf gRef = "R-502" Then
'   '            P = 10.644955 + (-3671.153813 / T) + (-0.369835 * (Log(T) / Log(10))) + (-0.001746352 * T) + ((0.8161139 * (654 - T)) / T) * (Log(654 - T) / Log(10))
'   '            PC = 10 ^ P
'   '        ElseIf gRef = "407C" Then
'   '            P = 43.3622 + (-6020.28 / T) + (-4.3987 * Log(T)) + (0.00000212036 * (T ^ 2))
'   '            PC = 2.7182818 ^ P
'   '        ElseIf gRef = "134A" Then
'   '            P = 22.98993635 + (-7243.876722 / T) + (-0.013362956 * T) + (0.00000692966 * T ^ 2) + ((0.1995548 * (674.72514 - T)) / T) * (Log(674.72514 - T))
'   '            PC = 2.7182818 ^ P
'   '        End If

'   '        A = C0 + C1 * TC
'   '        BA = C2 * PC + C3 * PE + C4 * PC * PE
'   '        DA = C5 * PE ^ 0.5 + C6 * PC / PE ^ 0.5
'   '        Y1 = A + BA + DA
'   '        TONS = Y1 * CAPM * NC
'   '        Q = TONS * 12000
'   '        A1 = P0 + P1 * TC
'   '        BB = P2 * PC + P3 * PE + P4 * PC * PE
'   '        DD = P5 * PE ^ 0.5 + P6 * PC / PE ^ 0.5
'   '        W1 = A1 + BB + DD
'   '        BHP = W1 * BHPM * NC
'   '        H2 = Q + (2545 * BHP)
'   '        ER = TONS * 12 / (BHP * 0.746 * 1.1)

'   '        ''''''''''''''''''''''''''''''Exit Sub '*****************************************************************************

'   '        'Q = (C0 + (C1 * TC) + (C2 * PE) + ((C3 * PE) * PC) + (C4 * PC) / Sqr(PE)) * NC
'   '        'BHP = (P0 + (P1 * TC) + (P2 * PE) + ((P3 * PE) * PC) + (P4 * PC) / Sqr(PE)) * NC
'   '        'TONS = Q / 12000
'   '        'H2 = Q + (2545 * BHP)
'   '        'ER = TONS * 12 / (BHP * 0.746 * 1.1)

'   '        If Z = 1 Then GoTo 13900000
'   '        If Z = 2 Then GoTo 14100000
'   '        If Z = 3 Then GoTo 14300000
'   '        If Z = 4 Then GoTo 14500000
'   '13900000: If H1 < H2 Then GoTo 11100000
'   '14000000: TC = TC - 10 : Z = 2 : GoTo 11300000
'   '14100000: If H1 < H2 Then GoTo 11300000
'   '14200000: TC = TC - 5 : Z = 3 : GoTo 11500000
'   '14300000: If H1 < H2 Then GoTo 11500000
'   '14400000: TC = TC - 1 : Z = 4 : GoTo 11700000
'   '14500000: If H1 < H2 Then GoTo 11700000
'   '        '14600000 Return

'   '    End Sub

'   'reset variables	
'   Private Sub ResetVariables()

'      gCatalogRating = 0  'CR_S PRINT OUT CATALOG RATINGS?Y/N
'      gRef = ""               'Refrigerant type


'      A = 0
'      B = 0
'      Q = 0
'      gTemperatureRange = 0                   'RANGE IN DEG. F.
'      T = 0
'      W = 0


'      gCondenserCapacity = 0                  'COND. CAP. @ 25 DEG TEMP. DIF.
'      EZ = 0
'      ER = 0
'      GP = 0
'      H1 = 0
'      H2 = 0
'      KW = 0
'      gSubCoolingTemp = 0                  'LIQUID COOLING(GLYCOL)
'      M1 = 0
'      gCompressorQuantity = 0  'NUMBER OF COMPRESSOR CIRCUITS
'      gNumberOfFans = 0        'NUMBER OF FANS
'      PC = 0
'      'PD = 0
'      PE = 0
'      Q1 = 0
'      Q8 = 0                  'CHILLER CAP. @ 8 DEG APPROACH
'      Q9 = 0                  'CHILLER CAP. @ 10 DEG APPROACH
'      gAmbientTempStep = 0
'      TC = 0
'      TE = 0
'      TW = 0
'      Me.subCoolingFactor = 0                 'GLYCOL
'      TE1 = 0
'      TE2 = 0
'      TW1 = 0
'      TW2 = 0
'      gMF1 = 0                'MULTIPLY FACTOR FOR COMPRESSORS
'      gMF2 = 0                'MULTIPLY FACTOR FOR COMPRESSORS
'      gMF3 = 0                'MULTIPLY FACTOR FOR COMPRESSORS
'      gVolts = 0              'VOLTAGE
'      GPMFACT = 0             'GLYCOL
'      fanWatts = 0
'      Hertz2 = 0
'      Hertz3 = 0
'      Hertz4 = 0
'      Hertz21 = 0

'      gOD = False             'TEST FOR OPEN DRIVE
'      gHP_O = False           'TEST FOR HORSEPOWER(OTHER)
'      gClosed = False         'TEST FOR DATA100.CLOSE
'      Exit_Select = False     'TEST FOR EXITING START SELECTION PROCEDURE
'      Exit_Glycol = False     'TEST FOR EXITING GLYCOL PROCEDURE
'      BAD_FLUID_TYPE = False  'TEST FOR BAD FLUID TYPE
'      '***** END *************************
'   End Sub


'   ' calculates and fills condenser coil capacity for either circuit 1 or 2
'   Private Sub SetCondenserCapacity()
'      Dim cond1 As New Rae.RaeSolutions.Business.Entities.WCCondenser(Rae.RaeSolutions.DataAccess.WaterCooledDA.RetrieveCondenser(Me.cboCondenser1.Text))
'      Dim cond2 As New Rae.RaeSolutions.Business.Entities.WCCondenser(Rae.RaeSolutions.DataAccess.WaterCooledDA.RetrieveCondenser(Me.cboCondenser2.Text))

'      Me.txtCondenserCapacity1.Text = CStr(Round(cond1.Capacity * CDbl(Me.txtNumCoils1.Text), 2))
'      Me.txtCondenserCapacity2.Text = CStr(Round(cond2.Capacity * CDbl(Me.txtNumCoils2.Text), 2))
'   End Sub

'   Private Sub Add10(ByRef v As Double)
'      v += 10
'   End Sub

'   Private Sub Add5(ByRef v As Double)
'      v += 5
'   End Sub

'   Private Sub Add1(ByRef v As Double)
'      v += 1
'   End Sub

'   Private Sub Add2Tenths(ByRef v As Double)
'      v += 0.2
'   End Sub

'   Private Sub PreCalculate()

'      cd = New RaeSolutions.CRDAL
'      cd.CRDAL(False)

'      CalculateFreezePoint()  'set freeze point and suction temp controls
'      'count_passes = 1
'      lblOperLimi.Visible = False
'      lblOperLimi.Text() = "Points outside operating limits omitted, contact factory for selection."

'      'Show/hide other evaporator textboxes


'      lblErro.Text() = ""   'clear errors
'      dgrC1Results.Visible = True 'show datagrid

'      ChangeCoilDescription()  'fills hid condenser textboxes
'      Dim my_Counter_pass As Single = 0
'      Dim nextCuritem As Integer = 0

'      'fill dropdown w/ datagrid values
'      If cboSystem.SelectedItem = "FULL" And Val(Txt_circuit_per_unit.Text()) = 2 _
'      Or Val(Txt_circuit_per_unit.Text()) = 4 Then
'         If ok_to_print = True And nextCuritem = 0 Then
'            Me.DropDownList3.DataSource = Nothing
'            DropDownList3.DataSource = myarrayprint3
'         End If
'      End If

'      ResetVariables()

'      'set specific heat and specific gravity controls 
'      ChillyRAEs_pass_no = 1  '1 = Parms    2 = Models    3 = 8&10 deg approach
'      ChillyRAE()
'      'fills condenser capacity textbox
'      SetCondenserCapacity()
'      'fill approach and evaporative capacity
'      ChillyRAEs_pass_no = 3  '1 = Parms    2 = Models    3 = 8&10 deg approach
'      ChillyRAE()


'   End Sub

'   Private Function GetWTs() As ArrayList
'        Dim gLFT As Integer = EvapTemp
'      Dim al As New ArrayList
'      If gLFT > -40 And gLFT <= -35 Then
'         al.Add(-50)
'         al.Add(-35)
'      ElseIf gLFT > -35 And gLFT <= -30 Then
'         al.Add(-45)
'         al.Add(-30)
'      ElseIf gLFT > -30 And gLFT <= -25 Then
'         al.Add(-40)
'         al.Add(-25)
'      ElseIf gLFT > -25 And gLFT <= -20 Then
'         al.Add(-35)
'         al.Add(-20)
'      ElseIf gLFT > -20 And gLFT <= -15 Then
'         al.Add(-30)
'         al.Add(-15)
'      ElseIf gLFT > -15 And gLFT <= -10 Then
'         al.Add(-25)
'         al.Add(-10)
'      ElseIf gLFT > -10 And gLFT <= -5 Then
'         al.Add(-20)
'         al.Add(-5)
'      ElseIf gLFT > -5 And gLFT <= 0 Then
'         al.Add(-15)
'         al.Add(0)
'      ElseIf gLFT > 0 And gLFT <= 5 Then
'         al.Add(-10)
'         al.Add(5)
'      ElseIf gLFT > 5 And gLFT <= 10 Then
'         al.Add(-5)
'         al.Add(10)
'      ElseIf gLFT > 10 And gLFT <= 15 Then
'         al.Add(0)
'         al.Add(15)
'      ElseIf gLFT > 15 And gLFT <= 20 Then
'         al.Add(5)
'         al.Add(20)
'      ElseIf gLFT > 20 And gLFT <= 25 Then
'         al.Add(10)
'         al.Add(25)
'      ElseIf gLFT > 25 And gLFT <= 30 Then
'         al.Add(15)
'         al.Add(30)
'      ElseIf gLFT > 30 And gLFT <= 35 Then
'         al.Add(20)
'         al.Add(35)
'      ElseIf gLFT > 35 And gLFT <= 40 Then
'         al.Add(25)
'         al.Add(40)
'      ElseIf gLFT > 40 And gLFT <= 45 Then
'         al.Add(30)
'         al.Add(45)
'      ElseIf gLFT > 45 And gLFT <= 50 Then
'         al.Add(35)
'         al.Add(50)
'      ElseIf gLFT > 50 And gLFT <= 55 Then
'         al.Add(40)
'         al.Add(55)
'      ElseIf gLFT > 55 And gLFT <= 60 Then
'         al.Add(45)
'         al.Add(60)
'      ElseIf gLFT > 60 And gLFT <= 65 Then
'         al.Add(50)
'         al.Add(65)
'      End If
'      Return al
'   End Function

'   Private Sub CalculatePage()
'      PreCalculate()
'      Dim Compr_KW1 As Double
'      Dim count_passes As Single
'      Dim glycolPercentage As Single
'      Dim EE, F, g, P, Z As Double
'      'Dim NF_2, TE_2, TC_2, Q_2, KW_2, GP_2, A_2, ER_2, W_2 As Double
'      Dim specificGravity, specificHeat As Single
'      Dim coolingMedia As String
'      Dim isGlycolSelected As Boolean
'      count_passes = 1

'      '********** set variable values ********************
'      If Running_Circuit_no = 1 Then
'         gCompressorQuantity = Val(txtNumCompressors1.Text())
'         gNumberOfFans = Val(txtNumFans1.Text()) * Val(txtNumCoils1.Text())
'         gCondenserCapacity = Val(txtCondenserCapacity1.Text)

'      ElseIf Running_Circuit_no = 2 Then
'         gCompressorQuantity = Val(txtNumCompressors2.Text())
'         gNumberOfFans = Val(txtNumFans2.Text()) * Val(txtNumCoils2.Text())
'         gCondenserCapacity = Val(txtCondenserCapacity2.Text)

'      End If
'      gTemperatureRange = Val(txtTempRange.Text())
'      gVolts = Val(cboVolts.SelectedItem)  'set at 230
'      gRef = Refrigerant.Name 'Trim(cboRefrigerant.SelectedItem.ValueName)
'      'multiplying factors for compressors
'      gMF1 = 1
'      gMF2 = 1
'      gMF3 = 1
'      If chkCatalogRating.Checked = True Then
'         gCatalogRating = vbYes
'      Else
'         gCatalogRating = vbNo
'      End If

'      Hertz2 = 1
'      Hertz21 = 1
'      Hertz3 = 1
'      Hertz4 = 1

'      Dim TE1, TE2 As Double
'      Dim T3 As Integer = EnteringFluidTemp
'      Dim compressorModel, compressorFile
'      Dim C0, C11, C2, C3, C4 As Double
'      Dim W0, W1, W2, W3, W4 As Double
'      Dim A0, A1, A2, A3, A4 As Double              'COMPRESSOR INPUTS
'      Dim coefficients As CompressorCoefficients5
'      Dim c As CompressorCoefficients10
'      Dim T1 As Double
'        'Dim NT As Integer
'        'Dim cond As Rae.RaeSolutions.CondenserCoefficients
'        'Dim CC As Double
'      Dim PD As Double
'      Dim X As Integer
'      Dim T2 As Double
'      Dim NC As Integer = CInt(Txt_circuit_per_unit.Text)
'      Dim gTD As Integer
'      Dim alWT As ArrayList = GetWTs()
'      TE1 = alWT(0)
'      TE2 = alWT(1)
'      'TE1 = Me.EvapTemp - 4 'CInt(txtTempRange.Text)
'      'TE2 = Me.EvapTemp + 4 'CInt(txtTempRange.Text)
'        TW1 = Me.EvapTemp - CInt(txtTempRange.Text) ' LOWEST LVG H20 TEMP(OD COMPRESSORS)
'        TW2 = Me.EvapTemp + CInt(txtTempRange.Text)

'      If Me.txtCompressor1.Text = "" Or Me.txtCompressor1.Text = "Choose" Then
'         Me.lblErro.Text = lblErro.Text & "Make a valid compressor selection, INVALID COMPRESSOR"
'         Exit Sub
'      End If

'      If Trim(Me.cboFluid.SelectedItem) <> "Water" Then
'         If Trim(Me.cboFluid.SelectedItem) = "Glycol" Then
'            isGlycolSelected = True
'            coolingMedia = Trim(cboCoolingMedia.SelectedItem) 'value
'            If coolingMedia = "Ethylene" Then
'               coolingMedia = "ETHYLENE GLYCOL"
'            ElseIf coolingMedia = "Propylene" Then
'               coolingMedia = "PROPYLENE GLYCOL"
'            End If
'            glycolPercentage = Single.Parse(Me.txtGlycolPercentage.Text)
'            If glycolPercentage = 0 Then
'               lblErro.Text() = lblErro.Text() & "ENTER PERCENTAGE OF GLYCOL (IE 20%, 30%. ETC), ENTER PERCENTAGE GLYCOL"
'               Exit_Glycol = True : Exit Sub
'            End If
'            specificHeat = Val(txtSpecificHeat.Text())
'            If specificHeat = 0 Then
'               lblErro.Text() = lblErro.Text() & "ENTER GLYCOL SPECIFIC HEAT ENTER GLYCOL SPECIFIC HEAT"
'               Exit_Glycol = True : Exit Sub
'            End If
'            specificGravity = Val(txtSpecificGravity.Text)
'            If specificGravity = 0 Then
'               lblErro.Text() = lblErro.Text() & "ENTER GLYCOL SPECIFIC GRAVITY ENTER GLYCOL SPECIFIC GRAVITY"
'               Exit_Glycol = True : Exit Sub
'            End If

'            GPMFACT = 500 * specificHeat * specificGravity * gTemperatureRange
'            gSubCoolingTemp = Val(txtSubCooling.Text)
'            Me.subCoolingFactor = (gSubCoolingTemp * 0.005) + 1
'         Else
'            BAD_FLUID_TYPE = True
'            lblErro.Text() = lblErro.Text() & "Enter a valid fluid type"
'            Exit Sub
'         End If
'      Else
'         isGlycolSelected = False
'         gSubCoolingTemp = Val(txtSubCooling.Text)
'         Me.subCoolingFactor = (gSubCoolingTemp * 0.005) + 1
'         coolingMedia = "WATER"
'         specificHeat = 1.0! : specificGravity = 1.0!
'         glycolPercentage = 100
'      End If

'        Dim M As Double = (25 + cboDischargeLineLoss.SelectedItem) / gCondenserCapacity

'      '-------------------------------------------------------






'        If Running_Circuit_no = 1 Then
'            compressorModel = Trim(Me.txtCompressor1.Text)
'            NT = CInt(Me.txtNumCoils1.Text)
'            'CC = CDbl(Me.txtCondenserCapacity1.Text)
'         cond = CType(cboCondenser1.SelectedItem, Business.Entities.WCCondenser)
'         GP = cond.GP
'         CC = cond.Capacity * NT
'            compressorFile = DataAccess.CompressorDataAccess.RetrieveCompressor2(compressorModel, Me.Refrigerant.Name.Replace("R", "")).Rows(0)("CompFile").ToString
'            Me.ToolTip1.SetToolTip(Me.txtCompressor1, compressorFile)
'            gTD = CInt(Me.txtCondenserTD1.Text)
'        ElseIf Running_Circuit_no = 2 Then
'            compressorModel = Trim(Me.txtCompressor2.Text)
'            NT = CInt(Me.txtNumCoils2.Text)
'            'CC = CDbl(Me.txtCondenserCapacity2.Text)
'         cond = CType(cboCondenser2.SelectedItem, Business.Entities.WCCondenser) 'Rae.RaeSolutions.DataAccess35A0.CondParamsForWCCond(Me.cboCondenser2.SelectedItem.ToString)
'         GP = cond.GP
'            compressorFile = DataAccess.CompressorDataAccess.RetrieveCompressor2(compressorModel, Me.Refrigerant.Name.Replace("R", "")).Rows(0)("CompFile").ToString
'         CC = cond.Capacity * NT ' * Val(TXT_CCXF.Text)
'            Me.ToolTip1.SetToolTip(Me.txtCompressor2, compressorFile)
'            gTD = CInt(Me.txtCondenserTD2.Text)
'        End If

'        If Me.chkNewCoefficients.Checked Then
'         c = DataAccess.CompressorDataAccess.RetrieveCompressorCoefficients10(compressorFile)
'         'If c Is Nothing Then Exit Sub
'        Else
'            ' retrieves compressor coefficients
'            coefficients = DataAccess.CompressorDataAccess.RetrieveCompressorCoefficients(compressorFile)
'            With coefficients
'                ' sets compressor coefficients
'                C0 = .capacity0 : C11 = .capacity1 : C2 = .capacity2 : C3 = .capacity3 : C4 = .capacity4
'                W0 = .watt0 : W1 = .watt1 : W2 = .watt2 : W3 = .watt3 : W4 = .watt4
'                A0 = .amp0 : A1 = .amp1 : A2 = .amp2 : A3 = .amp3 : A4 = .amp4
'            End With
'        End If

'      If Refrigerant.Type = Engineering.RefrigerantType.R507a Then
'         gMF1 = 1.03
'         gMF2 = 1.02
'      ElseIf Refrigerant.Type = Engineering.RefrigerantType.R407c Then
'         gMF1 = 0.96
'         gMF2 = 1.03
'      End If

'        For TE = tw1 To tw2 Step CInt(cboStep.SelectedValue)
'            For T1 = Me.EnteringFluidTemp - Val(Me.txtTempRange.Text) To Me.EnteringFluidTemp + Val(Me.txtTempRange.Text) Step 5 'CInt(cboStep.SelectedValue)
'                M = (20 + cboDischargeLineLoss.SelectedItem) / CC '25 / CC
'                Do_Calc(T1, gTD, M, compressorFile)
'                GP = H2 / (500 * gTD * Val(Me.txtSpecificHeat.Text) * Val(Me.txtSpecificGravity.Text))
'                'GP = H2 / 5000
'                GP = GP / NT
'                PD = (cond.B5 + cond.B6 * GP ^ 4 + cond.B7 * GP ^ 3 + cond.B8 * GP ^ 2 + cond.B9 * GP)
'                GP = GP * NT
'                If Me.chkCatalogRating.Checked = True Then Q = Q * 1.04
'                Q = Q / 12000
'                Q = Q * Me.subCoolingFactor
'                W = W / 1000
'                ER = Q * 12 / W
'                T2 = T1 + 10
'                Dim dr As DataRow = dtb.NewRow
'                dr("TW") = TW
'                dr("T1") = T1
'                dr("T2") = T2
'                dr("TE") = TE
'                dr("TC") = TC
'                dr("Q") = Q
'                dr("GPM") = GPM
'                dr("W") = W
'                dr("GP") = GP
'                dr("PD") = PD
'                dr("ER") = ER
'                dtb.Rows.Add(dr)
'            Next
'            'Dim dr2 As DataRow = dtb.NewRow
'            'dr2("TW") = "-"
'            'dr2("T1") = "-"
'            'dr2("T2") = "-"
'            'dr2("TE") = "-"
'            'dr2("TC") = "-"
'            'dr2("Q") = "-"
'            'dr2("GPM") = "-"
'            'dr2("W") = "-"
'            'dr2("GP") = "-"
'            'dr2("PD") = "-"
'            'dr2("ER") = "-"
'            'dtb.Rows.Add(dr2)
'        Next

'      'For T1 = T3 To T3 Step 5
'      '        M = 25 / CC
'      '        For TE = TE1 To TE2 Step 15
'      '            Do_Calc(T1, gTD, M, compressorFile)
'      '            If TE = TE2 Then GoTo A_Call_1
'      '            Q1 = Q
'      '        Next TE
'      'A_Call_1:
'      '        A = (Q - Q1) / 15
'      '        B = TE - (Q / A)
'      '        M1 = (TE - B) / Q

'      '        For TW = TW1 To TW2 Step 2

'      'TW_Call:
'      '            If TW > TW2 Then GoTo End_Print1
'      '            'TE = TW - 10
'      '            'Dim Ex As Double = (Q9 - Q8) / 2
'      '            'F = TE + (Q9 / Ex)
'      '            'g = (TE - F) / Q9
'      '            'TE = Round(((B * g) - (F * M1)) / (g - M1), 1)

'      '            Do_Calc(T1, gTD, M, compressorFile)

'      '            'Catalog rating...
'      '            If Me.chkCatalogRating.Checked = True Then Q = Q * 1.04

'      '            Q = Q / 12000

'      '            'Subcooling...
'      '            Q = Q * Me.subCoolingFactor

'      '            'Recalculate H2...
'      '            H2 = (Q * 12000) + (3.415 * W)

'      '            GP = H2 / (500 * gTD * Val(Me.txtSpecificHeat.Text) * Val(Me.txtSpecificGravity.Text))
'      '            GP = GP / NT
'      '            PD = (cond.B5 + cond.B6 * GP ^ 4 + cond.B7 * GP ^ 3 + cond.B8 * GP ^ 2 + cond.B9 * GP)
'      '            GP = GP * NT



'      '            W = W / 1000
'      '            ER = Q * 12 / W
'      '            T2 = T1 + gTD
'      '            GPM = (Q * 12000) / (Val(Me.txtSpecificHeat.Text) * Val(Me.txtSpecificGravity.Text) * Val(Me.txtTempRange.Text) * 500)

'      '            TC = Int((TC * 10) + 0.05) / 10
'      '            Q = Int((Q * 100) + 0.005) / 100
'      '            W = Int((W * 100) + 0.005) / 100
'      '            GP = Int((GP * 10) + 0.05) / 10
'      '            PD = Int((PD * 100) + 0.005) / 100
'      '            ER = Int((ER * 100) + 0.005) / 100

'      '            cd.InsertResults2(TW, T1, T2, TE, TC, Q, GPM, W, GP, PD, ER)

'      '            If TW = 44 Then
'      '                TW = 45
'      '                GoTo TW_Call
'      '            End If

'      '            If TW = 45 Then
'      '                TW = 44
'      '            End If
'      '        Next TW
'      '        cd.InsertBlankRowInResults2()
'      '        Next T1
'End_Print1:

'      'stores values from first of 2 circuits in myarrayprint3
'      'so that they can be retrieved after 2nd circuit is calculated


'1000: If cboSystem.SelectedItem() = "FULL" And Val(Txt_circuit_per_unit.Text()) = 2 _
'  Or Val(Txt_circuit_per_unit.Text()) = 4 Then
'         If ok_to_print = False Then
'            Me.FillDropDownList3()
'            GoTo Skip_Print_or_Cal
'         End If
'      End If

'      If cboSystem.SelectedItem() = "FULL" And Val(Txt_circuit_per_unit.Text()) = 2 Or Val(Txt_circuit_per_unit.Text()) = 4 Then
'         DropDownList2.DataSource = myarrayprint2
'         '-------------------
'         Dim TW_1, T1_1, T2_1, TE_1, TC_1, Q_1, GPM_1, W_1, GP_1, PD_1, ER_1, TW_2, T1_2, T2_2, TE_2, TC_2, Q_2, GPM_2, W_2, GP_2, PD_2, ER_2 As Double
'         Dim dv As DataView = dtb.DefaultView
'         dv.Sort = "TE, T1 asc"
'            Dim _te As Double = 0
'            Dim _t1 As Double = 0
'         For i As Integer = 0 To dv.Count - 1
'                If Val(dv.Item(i).Row("TE")) = _te AndAlso Val(dv.Item(i).Row("T1")) = _t1 Then 'add record
'                    TW_2 = Val(dv.Item(i).Row("TW"))
'                    T1_2 = Val(dv.Item(i).Row("T1"))
'                    T2_2 = Val(dv.Item(i).Row("T2"))
'                    TE_2 = Val(dv.Item(i).Row("TE"))
'                    TC_2 = Val(dv.Item(i).Row("TC"))
'                    Q_2 = Val(dv.Item(i).Row("Q"))
'                    GPM_2 = Val(dv.Item(i).Row("GPM"))
'                    W_2 = Val(dv.Item(i).Row("W"))
'                    GP_2 = Val(dv.Item(i).Row("GP"))
'                    PD_2 = Val(dv.Item(i).Row("PD"))
'                    ER_2 = Val(dv.Item(i).Row("ER"))
'                    cd.InsertResults2(TW_2, T1_2, T2_2, TE_2, TC_2, Q_1 + Q_2, GPM_1 + GPM_2, W_1 + W_2, GP_1 + GP_2, System.Math.Round((PD_1 + PD_2) / 2, 2), System.Math.Round((ER_1 + ER_2) / 2, 2))
'                    ' cd.InsertBlankRowInResults2()
'                Else 'new record
'                    TW_2 = 0
'                    T1_2 = 0
'                    T2_2 = 0
'                    TE_2 = 0
'                    TC_2 = 0
'                    Q_2 = 0
'                    GPM_2 = 0
'                    W_2 = 0
'                    GP_2 = 0
'                    PD_2 = 0
'                    ER_2 = 0
'                    TW_1 = Val(dv.Item(i).Row("TW"))
'                    T1_1 = Val(dv.Item(i).Row("T1"))
'                    T2_1 = Val(dv.Item(i).Row("T2"))
'                    TE_1 = Val(dv.Item(i).Row("TE"))
'                    TC_1 = Val(dv.Item(i).Row("TC"))
'                    Q_1 = Val(dv.Item(i).Row("Q"))
'                    GPM_1 = Val(dv.Item(i).Row("GPM"))
'                    W_1 = Val(dv.Item(i).Row("W"))
'                    GP_1 = Val(dv.Item(i).Row("GP"))
'                    PD_1 = Val(dv.Item(i).Row("PD"))
'                    ER_1 = Val(dv.Item(i).Row("ER"))
'                    _te = TE_1
'                    _t1 = T1_1
'                End If

'         Next
'         '----------------
'      Else
'            '-------------------
'            Dim _te As Double = TW1
'            For Each dr As DataRow In dtb.Rows
'                If Not Val(dr("TE")) = Val(_te) Then
'                    cd.InsertBlankRowInResults2()
'                    _te = Val(dr("TE"))
'                End If
'                cd.InsertResults2(Val(dr("TW")), Val(dr("T1")), Val(dr("T2")), Val(dr("TE")), Val(dr("TC")), Val(dr("Q")), Val(dr("GPM")), Val(dr("W")), Val(dr("GP")), Val(dr("PD")), Val(dr("ER")))
'            Next
'         '----------------
'      End If

'      If cboSystem.SelectedItem() = "FULL" And Val(Txt_circuit_per_unit.Text()) = 2 _
'      Or Val(Txt_circuit_per_unit.Text()) = 4 Then
'         DropDownList2.DataSource = myarrayprint2
'      End If
'      DropDownList1.DataSource = myarrayprint

'      FillDatagrid(cd.dt) 'fill datagrid

'Skip_Print_or_Cal:
'      If cboSafetyOverride.Checked = True Then
'         If lblOperLimi.Visible = True Then
'            lblOperLimi.Text() = "Compressor Safety Over Ride ON >> points outside operating limits."
'         End If
'      End If

'      'delete Circuit 1 database
'      If cboSystem.SelectedItem() = "FULL" And Val(Txt_circuit_per_unit.Text) = 2 _
'            Or Val(Txt_circuit_per_unit.Text) = 4 Then
'         'if ok_to_print = false and if statement above is true then
'         'this CalculatePage() is calculating circuit 1 of 2
'         If ok_to_print = False Then
'            'Delete Circuit 1 database. If there are multiple circuits,
'            'it is never filled or used; only circuit 2 database is used.
'            'Dim dbPath As String = AppInfo.AppFolderPath & "Reports\" & gMyFileNameMDB
'            'Common.IO.DeleteFile(dbPath)
'            cd.Reset()

'         End If
'      End If
'   End Sub

'   Private Sub Do_Calc(ByVal T1 As Integer, ByVal gtd As Integer, ByVal M As Double, ByVal compressorfile As String)
'      Dim C0, C11, C2, C3, C4 As Double
'      Dim W0, W1, W2, W3, W4 As Double
'      Dim A0, A1, A2, A3, A4 As Double              'COMPRESSOR INPUTS
'      Dim coefficients As CompressorCoefficients5
'      Dim c As CompressorCoefficients10
'      If Me.chkNewCoefficients.Checked Then
'         c = DataAccess.CompressorDataAccess.RetrieveCompressorCoefficients10(compressorfile)
'         'If c Is Nothing Then Exit Sub
'      Else
'         ' retrieves compressor coefficients
'         coefficients = DataAccess.CompressorDataAccess.RetrieveCompressorCoefficients(compressorfile)
'         With coefficients
'            ' sets compressor coefficients
'            C0 = .capacity0 : C11 = .capacity1 : C2 = .capacity2 : C3 = .capacity3 : C4 = .capacity4
'            W0 = .watt0 : W1 = .watt1 : W2 = .watt2 : W3 = .watt3 : W4 = .watt4
'            A0 = .amp0 : A1 = .amp1 : A2 = .amp2 : A3 = .amp3 : A4 = .amp4
'         End With
'      End If

'      PE = Refrigerant.GetEvapPressure(TE)
'      TC = T1 + gtd

'      Dim z As Integer = 1 : GoTo SET_H1

'ADD_TC_10:
'      TC = TC + 10
'      GoTo SET_H1
'ADD_TC_5:
'      TC = TC + 5
'      GoTo SET_H1
'ADD_TC_1:
'      TC = TC + 1
'      GoTo SET_H1
'ADD_TC_p2:
'      TC = TC + 0.2
'      GoTo SET_H1
'SET_H1:
'        H1 = (TC - T1) / (20 / CC) 'M

'      PC = Refrigerant.GetCondenserPressure(TC)

'      If Me.chkNewCoefficients.Checked Then
'         Q = (c.capacity0 + c.capacity1 * (TE) + c.capacity2 * TC + c.capacity3 * (TE ^ 2) + c.capacity4 * (TE * TC) + c.capacity5 * (TC ^ 2) + c.capacity6 * (TE ^ 3) + c.capacity7 * (TC * TE ^ 2) + c.capacity8 * (TE * TC ^ 2) + c.capacity9 * (TC ^ 3)) * gCompressorQuantity * Hertz2 '* gMF1
'         A = (c.amp0 + c.amp1 * (TE) + c.amp2 * TC + c.amp3 * (TE ^ 2) + c.amp4 * (TE * TC) + c.amp5 * (TC ^ 2) + c.amp6 * (TE ^ 3) + c.amp7 * (TC * TE ^ 2) + c.amp8 * (TE * TC ^ 2) + c.amp9 * (TC ^ 3)) * gCompressorQuantity * Hertz21 '* gMF2
'         W = (c.watt0 + c.watt1 * (TE) + c.watt2 * TC + c.watt3 * (TE ^ 2) + c.watt4 * (TE * TC) + c.watt5 * (TC ^ 2) + c.watt6 * (TE ^ 3) + c.watt7 * (TC * TE ^ 2) + c.watt8 * (TE * TC ^ 2) + c.watt9 * (TC ^ 3)) * gCompressorQuantity * Hertz3 '* gMF2
'      Else
'         Q = (C0 + (C11 * TC) + (C2 * PE) + ((C3 * PE) * PC) + (C4 * PC) / Sqrt(PE)) * gCompressorQuantity * Hertz2 * gMF1
'         W = (W0 + (W1 * TC) + (W2 * PE) + ((W3 * PE) * PC) + (W4 * PC) / Sqrt(PE)) * gCompressorQuantity * Hertz21 * gMF2
'         A = (A0 + (A1 * TC) + (A2 * PE) + ((A3 * PE) * PC) + (A4 * PC) / Sqrt(PE)) * gCompressorQuantity * Hertz3 * gMF2
'      End If

'        H2 = Q + (3.415 * W)

'        If Running_Circuit_no = 1 Then
'            NT = CInt(Me.txtNumCoils1.Text)
'        ElseIf Running_Circuit_no = 2 Then
'            NT = CInt(Me.txtNumCoils2.Text)
'        End If
'        GP = H2 / (500 * gtd * Val(Me.txtSpecificHeat.Text) * Val(Me.txtSpecificGravity.Text))
'        CC = (cond.B0 + cond.B1 * GP ^ 4 + cond.B2 * GP ^ 3 + cond.B3 * GP ^ 2 + cond.B4 * GP) * NT

'      If H1 = H2 * 1.01 Then
'         H1 = H2
'      Else
'         If z = 1 Then GoTo SS920
'         If z = 2 Then GoTo SS940
'         If z = 3 Then GoTo SS960
'         If z = 4 Then GoTo SS980
'SS920:   If H1 < H2 Then GoTo ADD_TC_10
'         TC = TC - 10 : z = 2 : GoTo ADD_TC_5
'SS940:   If H1 < H2 Then GoTo ADD_TC_5
'         TC = TC - 5 : z = 3 : GoTo ADD_TC_1
'SS960:   If H1 < H2 Then GoTo ADD_TC_1
'         TC = TC - 1 : z = 4 : GoTo ADD_TC_p2

'SS980:   If H1 < H2 Then GoTo ADD_TC_p2
'      End If
'   End Sub



'   ''' <summary>Inserts results
'   ''' </summary>
'   ''' <param name="leavingFluidTemperature"></param>
'   ''' <param name="ambientTemperature"></param>
'   ''' <param name="evaporatingTemperature"></param>
'   ''' <param name="condensingTemperature"></param>
'   ''' <param name="capacity"></param>
'   ''' <param name="kilowatts"></param>
'   ''' <param name="gpm"></param>
'   ''' <param name="amps"></param>
'   ''' <param name="er"></param>
'   ''' <param name="ez"></param>
'   ''' <remarks>
'   ''' </remarks>
'   ''' <history>[CASEYJ]	6/13/2005	Created
'   ''' </history>
'   'Public Shared Sub InsertResults( _
'   'ByVal dbPath As String, _
'   'ByVal leavingFluidTemperature As Single, _
'   'ByVal ambientTemperature As Single, _
'   'ByVal evaporatingTemperature As Single, _
'   'ByVal condensingTemperature As Single, _
'   'ByVal capacity As Single, _
'   'ByVal kilowatts As Single, _
'   'ByVal gpm As Single, _
'   'ByVal amps As Single, _
'   'ByVal er As Single, _
'   'ByVal ez As Single)
'   '   Dim connectionString As String
'   '   Dim sqlInsert As System.Text.StringBuilder
'   '   Dim conResults As OleDb.OleDbConnection
'   '   Dim comResults As OleDb.OleDbCommand

'   '   sqlInsert = New System.Text.StringBuilder

'   '   'gets connection string for db path
'   '   connectionString = DataAccess.Common.GetConnectionString(dbPath)

'   '   'builds insert sql command
'   '   sqlInsert.Append("INSERT INTO CALULATIONS ")
'   '   sqlInsert.Append("([TW], [TA], [TE], [TC], [Q], [KW], [GP], [A], [ER], [EZ]) Values ")
'   '   sqlInsert.AppendFormat( _
'   '      "('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')", _
'   '      Format(leavingFluidTemperature, "###"), _
'   '      Format(ambientTemperature, "###"), _
'   '      Format(evaporatingTemperature, "##.0"), _
'   '      Format(condensingTemperature, "###.0"), _
'   '      Format(capacity, "###.0"), _
'   '      Format(kilowatts, "####.0"), _
'   '      Format(gpm, "####.0"), _
'   '      Format(amps, "###.#0"), _
'   '      Format(er, "####.0"), _
'   '      Format(ez, "####.0"))

'   '   conResults = New OleDb.OleDbConnection(connectionString)
'   '   Try
'   '      conResults.Open()
'   '      comResults = New OleDb.OleDbCommand(sqlInsert.ToString, conResults)
'   '      comResults.ExecuteNonQuery()
'   '   Catch dbEx As OleDb.OleDbException
'   '      Dim message As String
'   '      message = "An exception occurred while attempting to fill temporary " & _
'   '         "results database." & Environment.NewLine & dbEx.Message
'   '      Ui.MessageBox.Show(message)
'   '   Finally
'   '      If conResults.State <> ConnectionState.Closed Then conResults.Close()
'   '   End Try
'   'End Sub


'   'fills dropdown control with values in an array
'   'so that the values can be used later to help
'   'fill the datagrid
'   'this was causing annoying problems before
'   Private Sub FillDropDownList3()
'      Dim i As Integer
'      'set datasource to nothing so that old items in
'      'dropdown can be editted (removed); dropdown items
'      'can not be removed if dropdown is set to datasource
'      Me.DropDownList3.DataSource = Nothing

'      'remove old items in dropdown control so that
'      'the new items will be added at the beginning
'      If Me.DropDownList3.Items.Count > 0 Then
'         For i = DropDownList3.Items.Count - 1 To 0 Step -1
'            Me.DropDownList3.Items.RemoveAt(i)
'         Next
'      End If
'      'add items in array to dropdown control
'      For i = 0 To myarrayprint3.Count - 1
'         Me.DropDownList3.Items.Add(myarrayprint3.Item(i))
'      Next
'   End Sub


'   'fill datagrid
'   'only called once (in CalculatePage)
'   Private Sub FillDatagrid(ByVal resultsTable As DataTable)
'      'Dim temp_connection_name As String = AppInfo.AppFolderPath & "Reports\" & gMyFileNameMDB          'UNSURE: 2?
'      ' retrieves results
'      'Dim resultsTable As DataTable = DataAccess.Chillers.Chiller.RetrieveChillerResults(temp_connection_name)
'      ' fills grid with results
'      Me.dgrC1Results.DataSource = resultsTable
'      ' formats grid
'      Me.FormatResultsGrid()

'      'why is gMyFileNameMDB being set again
'      'gMyFileNameMDB = PASS_FILENAME
'   End Sub


'   Private Sub FormatResultsGrid()

'      Rae.Ui.C1GridStyles.BasicGridStyle(Me.dgrC1Results)

'      With Me.dgrC1Results.Splits(0)
'         ' sets column properties
'         .ColumnCaptionHeight = 36
'         .HeadingStyle.BackColor = ColorManager.LightBlue

'         .OddRowStyle.BackColor = ColorManager.LighterBlue
'         .Style.Borders.Color = ColorManager.GreyBlue
'         For i As Integer = 0 To .DisplayColumns.Count - 1
'            .DisplayColumns(i).ColumnDivider.Color = ColorManager.GreyBlue
'         Next

'         .DisplayColumns("CE").Width = 65
'         .DisplayColumns("CE").DataColumn.Caption = "Cond. EWT" & vbCrLf & "[°F]"
'         .DisplayColumns("CL").Width = 65
'         .DisplayColumns("CL").DataColumn.Caption = "Cond. LWT" & vbCrLf & "[°F]"
'         .DisplayColumns("TE").Width = 65
'         .DisplayColumns("TE").DataColumn.Caption = "Evap. Temp." & vbCrLf & "[°F]"
'         .DisplayColumns("TC").Width = 65
'         .DisplayColumns("TC").DataColumn.Caption = "Cond. Temp." & vbCrLf & "[°F]"
'         .DisplayColumns("Q").Width = 65
'         .DisplayColumns("Q").DataColumn.Caption = "Capacity" & vbCrLf & "[Tons]"
'         .DisplayColumns("KW").Width = 45
'         .DisplayColumns("KW").DataColumn.Caption = "Comp. [KW]"
'         .DisplayColumns("GP").Width = 45
'         .DisplayColumns("GP").DataColumn.Caption = "COND. GPM"
'         .DisplayColumns("PD").Width = 55
'         .DisplayColumns("PD").DataColumn.Caption = "COND. PD"
'         .DisplayColumns("ER").Width = 55
'         .DisplayColumns("ER").DataColumn.Caption = "EER"
'      End With
'   End Sub


'   Private Sub StartCalculations()
'      ok_to_print_SPACE = False
'      dtb = New DataTable
'      dtb.Columns.Add("TW")
'      dtb.Columns.Add("T1")
'      dtb.Columns.Add("T2")
'      dtb.Columns.Add("TE")
'      dtb.Columns.Add("TC")
'      dtb.Columns.Add("Q")
'      dtb.Columns.Add("GPM")
'      dtb.Columns.Add("W")
'      dtb.Columns.Add("GP")
'      dtb.Columns.Add("PD")
'      dtb.Columns.Add("ER")

'      ChangeCoilDescription()
'      'Page_Cal_Pass = 1
'run_Second_pass:
'      myarrayprint.Clear()
'      myarrayprint2.Clear()
'      ''' <history>Added by Casey Joyce</history>
'      ''' <summary>myarrayprint3 was never cleared; if calculate page is clicked more than once, 
'      ''' the array just gets bigger and only the beginning indices are ever used which is incorrect</summary>
'      myarrayprint3.Clear()

'      'okay to print
'      If cboSystem.SelectedItem = "FULL" And Val(Txt_circuit_per_unit.Text()) = 2 Or Val(Txt_circuit_per_unit.Text()) = 4 Then
'         ok_to_print = False
'         Running_Circuit_no = 1
'         CalculatePage()

'         ok_to_print = True
'         ok_to_print_SPACE = True
'         Running_Circuit_no = 2
'         CalculatePage()
'      ElseIf cboSystem.SelectedItem = "FULL" And Val(Txt_circuit_per_unit.Text()) = 1 Then
'         ok_to_print_SPACE = True
'         Running_Circuit_no = 1
'         CalculatePage()
'      ElseIf cboSystem.SelectedItem = "HALF" Then
'         If radCircuit1.Checked = True Then
'            Running_Circuit_no = 1
'         ElseIf radCircuit2.Checked = True Then
'            ok_to_print_SPACE = True
'            Running_Circuit_no = 2
'         End If
'         CalculatePage()
'      End If
'   End Sub


'   'Set  Freeze Point  &  Suction Temperature
'   Private Sub CalculateFreezePoint()
'      ' grabs glycol percentage
'      Dim glycolPercentage As Double = CDbl(Me.txtGlycolPercentage.Text.Trim)

'      ' checks glycol percentage is in proper range
'      If BCI.FreezingPoint.IsGlycolPercentageOutsideRange(glycolPercentage) Then
'         Ui.MessageBox.Show("Glycol percentage must be in the range 0% to 60%; resetting glycol percentage to 20%.", _
'            MessageBoxIcon.Information)
'         ' resets glycol percentage to 20
'         Me.txtGlycolPercentage.Text = "20"
'         Exit Sub
'      End If

'      ' sets freezing point and suction temperature textboxes
'      If Me.cboFluid.SelectedItem = "Water" Then
'         ' sets freeze point textbox to water's freezing point
'         Me.txtFreezingPoint.Text = BCI.FreezingPoint.FreezingPointForWater.ToString
'         ' sets recommended minimum suction temperature textbox to water's recommended minimum suction temperature
'         Me.txtSuctionTemp.Text = BCI.FreezingPoint.RecommendedMinSuctionTemperatureForWater

'      Else
'         Dim glycol As New Rae.Solutions.Chillers.Glycol
'         Dim freezingPoint As BCI.FreezingPoint

'         ' parses selected combobox item to glycol
'         glycol = DirectCast(glycol.Parse(GetType(Rae.Solutions.Chillers.Glycol), Me.cboCoolingMedia.SelectedItem.ToString), _
'            Rae.Solutions.Chillers.Glycol)

'         ' constructs new freezing point using selected glycol and glycol percentage
'         freezingPoint = New BCI.FreezingPoint(glycol, glycolPercentage)

'         ' sets freezing point textbox
'         Me.txtFreezingPoint.Text = Round(freezingPoint.FreezingPoint, 1).ToString
'         ' sets recommended minimum suction temperature textbox
'         Me.txtSuctionTemp.Text = Round(freezingPoint.RecommendedMinSuctionTemperature, 1).ToString
'      End If
'   End Sub



'   Public Shared Function RetrieveEvaporator(ByVal standardModel As String, ByVal numCircuitsPerUnit As Integer, _
'   ByVal length As Single, ByVal authorizationLevel As Integer) As String
'      Dim evaporatorModel As String

'      ' checks if evaporator model is valid
'      If Evaporator1.IsEvaporatorModelValid(standardModel) Then
'         ' retrieves evaporator model that matches parameters
'         evaporatorModel = DataAccess.Chillers.ChillerDataAccess.RetrieveEvaporator(standardModel, numCircuitsPerUnit, length, authorizationLevel)
'      End If

'      Return evaporatorModel
'   End Function



'   '****************************************************************
'   '** THREE FUNCTIONS DEPENDING ON NUMBER IN GLOBAL ChillyRAEs_pass_no
'   '** 1 - sets specific heat and specific gravity textboxes
'   '** 2 - fills combobox w/ evaporators
'   '** 3 - sets approach and evap capacity textboxes
'   '****************************************************************
'   'OLDERROR: Interfacing w/ RAEDLL_CONDENSING_UNIT.dll when 3 is passed to ChillyRAEs_pass_no
'   '****** ChillyRAE_Parms.RAE_out_#deg_pd always returns 0
'   '****** ChillyRAE_Parms.RAE_out_4FLOW always returns 0
'   'UPDATE:passing 3 now works w/ the same chillyrae.dll that the website is using,
'   '****** but not the new chillyrae.dll,
'   '****** the new dll probably has an error in it 9/2/2004
'   '****************************************************************
'   Sub ChillyRAE()
'      'If Me.cboModels.SelectedItem = "Choose" Then
'      '   Exit Sub
'      'End If
'      Dim standardModel As String
'      Dim ChillyRAE_Parms As New RAEDLL_CONDENSING_UNIT.Selection_Mod

'      Me.CalculateFreezePoint()

'      '1 <<<<<<<<<<<<<<<<<<<<<<<<
'      'get specific heat and gravity
'      If ChillyRAEs_pass_no = 1 Then
'         Try
'            ' gets standard model number based on evaporator part number
'            Dim evaporator = BCA.RetrieveChillerEvaporator(Me.GrabEvaporatorModel())
'            standardModel = evaporator.StandardModelNum
'         Catch ex As System.Exception
'            Dim message As String = "An exception occurred while attempting to retrieve the standard evaporator model. " & ex.Message
'            Ui.MessageBox.Show(message) : Exit Sub
'         End Try
'         With ChillyRAE_Parms
'            ' pass data
'            .RAE_ChillyRAEs_pass = 1        '1 = Parms    2 = Models    3 = 8&10 deg approach
'            .RAE_Fouling_Factor = 0 'CDbl(Me.cboFoulingFactor.SelectedItem)
'            .RAE_Cbo_Fluid = Me.cboFluid.SelectedItem.ToString
'            .RAE_tempin = Me.EvapTemp + VB.Val(txtTempRange.Text)
'            .RAE_tempot = Me.EvapTemp
'            .RAE_txtCondCap = Me.GrabSystemCapacityBtuh()
'            .RAE_cboRef_Text = Refrigerant.Type.ToString() '"R" & Trim(cboRefrigerant.SelectedItem.ValueName)
'            .RAE_cboCCM_Text = cboCoolingMedia.SelectedItem.ToString.Trim
'            .RAE_txtPctGly_Text = VB.Val(Me.txtGlycolPercentage.Text.Trim)
'            .RAE_conduc = 0
'            .RAE_visc = 0
'            .RAE_spht = VB.Val(Me.txtSpecificHeat.Text)
'            .RAE_allmod = "all"
'            .RAE_units = "U.S. UNIT"     'METRIC
'            .RAE_cbo_chillers_Text = standardModel 'Trim(TxtChiller.Text())
'            .RAE_txtSpGr = 0        'Val(Txtspgr.Text())
'            .AddToDatabase5()

'            'get data
'            Me.txtSpecificHeat.Text = .RAE_Out_txtSpHt_Text 'get specific heat         
'            Me.txtSpecificGravity.Text = .RAE_Out_txtSpGr_Text 'get specific gravity
'         End With

'      End If
'   End Sub


'   'sets fan watts control value based on hertz and condenser fan
'   Private Sub SetFanWatts()
'      Dim fanFileName As String = Me.GrabFan.FileName
'      Dim hertz As Integer = CInt(Me.cboHertz.SelectedItem.ToString)

'      Me.fanWatts = Business.Intelligence.FanIntel.SelectFanWatts(fanFileName, hertz, gVolts)

'      Me.txtFanWatts.Text = Me.fanWatts.ToString
'   End Sub




'   'sets control values returned from 30a0database for circuit 1
'   '1. evaporator and length, 2. condenser, 3. compressor and quantity,
'   '4. fan quantity and diameter, 5. coil quantity, 6. circuits per unit,
'   '7. sub cooling, 8. evaporator capacity, 
'   '9. fpi, fin width and height, 10. fan 
'   'fills hidden refrigerant comboboxes based on compressor
'   'sets condenser capacity
'   'sets specific heat and specific gravity
'   'fills approach and evaporator capacity
'   Private Sub CALL_Circuit1()
'      Dim chiller As DataTable

'      ' retrieves chiller object for model
'      chiller = Rae.RaeSolutions.DataAccess.Chillers.ChillerDataAccess.RetrieveChiller(Me.GrabChillerModel())

'      ' sets controls
'      '
'      ' Me.txtEvaporatorModel.Text = ConvertNull.ToString(chiller.Rows(0).Item("Evap_part_no"))
'      'COILQTY_1 = chiller.Circuit1.NumCoils.ToString
'      Me.txtCondenser_1.Text = ConvertNull.ToString(chiller.Rows(0).Item("Coil_1")).ToUpper
'      Me.txtCompressor1.Text = ConvertNull.ToString(chiller.Rows(0).Item("Compressor_1")).ToUpper
'      Me.txtNumCompressors1.Text = ConvertNull.ToString(chiller.Rows(0).Item("Compr_Qty_1")).ToString
'      ''Me.txtNumFans1.Text = chiller.Rows(0).Item("FanQty_1").ToString
'      'Me.txtNumCoils1.Text = chiller.Circuit1.NumCoils.ToString
'      Me.txtSubCooling1.Text = ConvertNull.ToString(chiller.Rows(0).Item("Degrees_Sub_Cooling_Coil_1")).ToString
'      Me.Txt_circuit_per_unit.Text = ConvertNull.ToString(chiller.Rows(0).Item("Circuits_Per_Unit")).ToString()

'      Me.DisplaySystemCapacity(Average(ConvertNull.ToDouble(chiller.Rows(0).Item("Approx_Min_Cap")), ConvertNull.ToDouble(chiller.Rows(0).Item("Approx_Max_Cap"))))

'      If Val(Me.Txt_circuit_per_unit.Text) = 1 Then
'         Me.cboSystem.SelectedIndex = 0
'         Me.cboSystem.Enabled = False
'      Else
'         Me.cboSystem.Enabled = True
'      End If

'      Me.lboCompressors1.SelectedIndex = ControlAssistant.GetIndexOfValueInListBox(Me.lboCompressors1, chiller.Rows(0).Item("Compressor_1"))
'      'Me.cboFinsPerInch1.SelectedIndex = _
'      'ControlAssistant.GetIndexOfComboboxItem(Me.cboFinsPerInch1, chiller.Circuit1.Coil.FinsPerInch)
'      'Me.txtFinHeight1.Text = chiller.Circuit1.Coil.Height.ToString
'      'Me.txtFinLength1.Text = chiller.Circuit1.Coil.Length.ToString

'      'Me.cboCondenser1.SelectedIndex = IndexOfCondenser(Me.cboCondenser1, chiller.Circuit1.Coil.Rows.ToString & "RCOND")
'      'Me.cboFan.SelectedIndex = IndexOfFanFileName(Me.cboFan, Business.Intelligence.Fan.SelectFanFileName(chiller.Circuit1.FanDiameter))

'      If chiller.Rows(0).Item("Circuits_Per_Unit") > 1 Then
'         Me.radCircuit2.Visible = True
'      End If

'      'sets chiller evaporator controls
'      Me.SetChillerEvaporatorControls()

'      SetCondenserCapacity()
'      ' 1 = Parms    2 = Models    3 = 8&10 deg approach
'      ' sets specific heat and specific gravity
'      ChillyRAEs_pass_no = 1 : ChillyRAE()
'      'fills approach and evaporator capacity
'      ChillyRAEs_pass_no = 3 : ChillyRAE()
'   End Sub


'   'sets control values returned from 30a0database for circuit 2
'   '1. evaporator and length, 2. condenser, 3. compressor and quantity,
'   '4. fan quantity and diameter, 5. coil quantity, 6. circuits per unit,
'   '7. sub cooling, 8. evaporator capacity, 
'   '9. fpi, fin width and height, 10. fan 
'   'fills hidden refrigerant comboboxes based on compressor
'   'sets condenser capacity
'   'sets specific heat and specific gravity
'   'fills approach and evaporator capacity
'   Private Sub CALL_Circuit2()
'      'Dim chiller As Business.Entities.Chillers.Chiller
'      Dim chiller As DataTable

'      ' retrieves chiller object for model
'      'chiller = Business.Agents.Chiller.RetrieveChiller(Me.GrabChillerModel())
'      chiller = Rae.RaeSolutions.DataAccess.Chillers.ChillerDataAccess.RetrieveChiller(Me.GrabChillerModel())

'      ' sets evaporator model
'      'Me.txtEvaporatorModel.Text = chiller.EvaporatorPartNum.ToUpper
'      'Me.txtEvaporatorModel.Text = chiller.Rows(0).Item("Evap_part_no")

'      ' fills hid condenser textboxes
'      'Me.txtCondenser_2.Text = chiller.Circuit2.Coil.Name.ToUpper
'      ' sets compressor
'      'Me.txtCompressor2.Text = chiller.Circuit2.Compressor.Name.ToUpper
'      'sets number of compressors
'      'Me.txtNumCompressors2.Text = chiller.Circuit2.NumCompressors.ToString
'      Me.txtCondenser_2.Text = chiller.Rows(0).Item("Coil_2").ToUpper
'      Me.txtCompressor2.Text = chiller.Rows(0).Item("Compressor_2").ToUpper
'      Me.txtNumCompressors2.Text = chiller.Rows(0).Item("Compr_Qty_2").ToString
'      Me.txtNumCoils2.Text = chiller.Rows(0).Item("CoilQty_2").ToString

'      ' sets number of fans
'      'Me.txtNumFans2.Text = chiller.Circuit2.NumFans.ToString
'      ' sets coil quantity
'      'Me.txtNumCoils2.Text = chiller.Circuit2.NumCoils.ToString

'      ' sets number of circuits per unit
'      'Me.Txt_circuit_per_unit.Text = chiller.NumCircuitsPerUnit.ToString
'      Me.Txt_circuit_per_unit.Text = chiller.Rows(0).Item("Circuits_Per_Unit").ToString()

'      ' sets sub cooling
'      'Me.txtSubCooling2.Text = chiller.Circuit2.SubCoolingPercentage.ToString
'      Me.txtSubCooling2.Text = chiller.Rows(0).Item("Degrees_Sub_Cooling_Coil_2").ToString

'      ' set evaporator capacity? in tons or gpm, approx. capacities are in tons
'      'Me.DisplaySystemCapacity(Common.Math.Average(chiller.ApproxMinCapacity, chiller.ApproxMaxCapacity))
'      Me.DisplaySystemCapacity(Average(chiller.Rows(0).Item("Approx_Min_Cap"), chiller.Rows(0).Item("Approx_Max_Cap")))

'      ' disables system control if only 1 circuit per unit
'      'If chiller.NumCircuitsPerUnit = 1 Then
'      If chiller.Rows(0).Item("Circuits_Per_Unit") = 1 Then
'         Me.cboSystem.SelectedIndex = 0
'         Me.cboSystem.Enabled = False
'      Else
'         Me.cboSystem.Enabled = True
'      End If

'      ' selects compressor
'      Me.lboCompressors2.SelectedIndex = ControlAssistant.GetIndexOfValueInListBox(Me.lboCompressors2, Me.txtCompressor2.Text)
'      ' selects fins per inch
'      'Me.cboFinsPerInch2.SelectedIndex = RAE.UI.ListHelper.IndexOfComboBoxItem(Me.cboFinsPerInch2, chiller.Circuit2.Coil.FinsPerInch)
'      ' sets fin width and length
'      'Me.txtFinHeight2.Text = chiller.Circuit2.Coil.Height.ToString
'      'Me.txtFinLength2.Text = chiller.Circuit2.Coil.Length.ToString
'      ' selects condenser
'      'Me.cboCondenser2.SelectedIndex = IndexOfCondenser(Me.cboCondenser2, chiller.Circuit2.Coil.Rows.ToString & "RCOND")
'      ' selects fan diameter
'      'Me.cboFan.SelectedIndex = IndexOfFanFileName(Me.cboFan, Business.Intelligence.Fan.SelectFanFileName(chiller.Circuit2.FanDiameter))

'      'shows circuit 2 radiobutton if circuits is greater than 1
'      'If chiller.NumCircuitsPerUnit > 1 Then
'      If chiller.Rows(0).Item("Circuits_Per_Unit") > 1 Then
'         radCircuit2.Visible = True
'      End If

'      ' sets evaporator description
'      Me.SetChillerEvaporatorControls()
'      ' calls cofan to get condenser capacity
'      Me.SetCondenserCapacity()
'      ' 1 = specific heat and gravity    2 = evaporator models    3 = 8&10 deg approach
'      ChillyRAEs_pass_no = 1 : ChillyRAE()
'      ChillyRAEs_pass_no = 3 : ChillyRAE()
'   End Sub

'#End Region










'#Region " Data"


'   Private Function GetRefrigerants() As ArrayList

'      'Dim dtbRefs As DataTable = EnumToDataTable(typeof(Rae.Engineering.RefrigerantType))
'      Dim refrigerants As New ArrayList


'      With refrigerants
'         ' adds refrigerants to list
'         .Add(New cFillCombobox("R-22H", "22H"))
'         .Add(New cFillCombobox("R-22M", "22M"))
'         .Add(New cFillCombobox("R-22L", "22L"))
'         .Add(New cFillCombobox("R-134a", "134a"))
'         .Add(New cFillCombobox("R-404aL", "404aL"))
'         .Add(New cFillCombobox("R-404aM", "404aM"))
'         .Add(New cFillCombobox("R-404aH", "404aH"))
'         .Add(New cFillCombobox("R-407c", "407c"))
'      End With

'      Return refrigerants
'   End Function

'#End Region


'#Region " UI"


'   Private Function GrabChillerModel() As String
'      Dim drv As DataRowView = Me.cboModels.SelectedItem
'      Return drv("Model")
'      ' Return Me.cboModels.SelectedItem.ToString
'   End Function

'   Private Function GrabSpecificGravity() As Single
'      Return Round(CSng(Me.txtSpecificGravity.Text.Trim), 2)
'   End Function

'   Private Function GrabSpecificHeat() As Single
'      Return CSng(Me.txtSpecificHeat.Text.Trim)
'   End Function

'   Private Function GrabMinSuctionTemp() As Single
'      Return CSng(Me.txtSuctionTemp.Text.Trim)
'   End Function

'   Private Function GrabTemperatureRange() As Single
'      Return CSng(Me.txtTempRange.Text.Trim)
'   End Function

'   Private Function GrabSystemCapacity() As Single
'      Return CSng(Me.txtCondenserCapacity1.Text.Trim)
'   End Function

'   Private Function GrabSystemCapacityBtuh() As Single
'      Dim systemCapacityBtuh As Single
'      'If Me.radTons.Checked Then
'      ' grabs system capacity from textbox
'      systemCapacityBtuh = Convert.TonsToBtuh(GrabSystemCapacity())
'      'ElseIf Me.radGpm.Checked Then
'      ' converts from gpm to btuh
'      systemCapacityBtuh = Convert.GpmToBtuh(Me.GrabSystemCapacity(), Me.GrabTemperatureRange(), _
'         Me.GrabSpecificHeat(), Me.GrabSpecificGravity())
'      ' End If
'      Return systemCapacityBtuh
'   End Function

'   Private Function GrabCondenser1() As Condenser1
'      Return DirectCast(Me.cboCondenser1.SelectedItem, Condenser1)
'   End Function

'   Private Function GrabCondenser2() As Condenser1
'      Return DirectCast(Me.cboCondenser2.SelectedItem, Condenser1)
'   End Function

'   Private Function GrabFan() As Business.Entities.Fan
'      Return DirectCast(Me.cboFan.SelectedItem, Business.Entities.Fan)
'   End Function

'   Private Function GrabEvaporatorModel() As String
'      'Return Me.txtEvaporatorModel.Text.Trim
'   End Function


'   Private Sub DisplaySystemCapacity(ByVal capacityTons As Single)
'      'If Me.radTons.Checked Then  'Tons 
'      Me.txtCondenserCapacity1.Text = Round(capacityTons, 2)
'      'ElseIf radGpm.Checked Then  'GPM 
'      'Me.txtEvaporatorCapacity.Text = _
'      Convert.TonsToGpm(capacityTons, Me.GrabTemperatureRange(), Me.GrabSpecificHeat(), Me.GrabSpecificGravity())
'      'Me.txtEvaporatorCapacity.Text = Convert.TonsToGpm(Common.Math.Average(minCapacity, maxCapacity), _
'      '   temperatureRange, specificHeat, specificGravity)
'      'End If
'   End Sub



'   Private Sub ColorControls()
'      With New ColorManager
'         Me.panModel.BackColor = .LightBlue
'         Me.panButtons.BackColor = .LightBlue
'         Me.lblErro.BackColor = .LightBlue
'         Me.panFooter.BackColor = .LightBlue

'         ' colors headers
'         Me.lblRatingCriteria.ForeColor = .HeaderBlue
'         Me.lblCompressor.ForeColor = .HeaderBlue
'         Me.lblCondenser.ForeColor = .HeaderBlue
'         'Me.lblEvaporator.ForeColor = .HeaderBlue

'         ' colors lines
'         Me.lineRatingCriteria.ForeColor = .HeaderBlue
'         Me.lineCompressor.ForeColor = .HeaderBlue
'         Me.lineCondenser.ForeColor = .HeaderBlue
'         'Me.lineEvaporator.ForeColor = .HeaderBlue

'         ' colors comments
'         Me.lblSubCoolingF.ForeColor = .GreyBlue
'         Me.lblMinSuctionF.ForeColor = .GreyBlue
'         Me.lblAmbientF.ForeColor = .GreyBlue
'         Me.lblFreezePointF.ForeColor = .GreyBlue
'         Me.lblLeavingFluidF.ForeColor = .GreyBlue
'         Me.lblRangeF.ForeColor = .GreyBlue
'         Me.lblCFM.ForeColor = .GreyBlue

'         Me.lblCondenserTD1F.ForeColor = .GreyBlue
'         Me.lblCondenserTD2F.ForeColor = .GreyBlue
'         Me.lblAltitudeFt.ForeColor = .GreyBlue
'         'Me.lblApplies1.ForeColor = .GreyBlue
'         'Me.lblApplies2.ForeColor = .GreyBlue
'         'Me.lblApplies3.ForeColor = .GreyBlue
'         Me.lblApplies4.ForeColor = .GreyBlue
'         Me.lblDischargeLineLossF.ForeColor = .GreyBlue
'         Me.lblSuctionLineLossF.ForeColor = .GreyBlue
'         Me.lblCondenserCapacityBtuh.ForeColor = .GreyBlue
'         'Me.lblCondenserCapacityF.ForeColor = .GreyBlue
'         Me.lblCondSubCoolingPercent1.ForeColor = .GreyBlue
'         Me.lblCondSubCoolingPercent2.ForeColor = .GreyBlue

'         ' colors buttons
'         Me.btnCriteriaPlus.ForeColor = .HeaderBlue
'         Me.btnCriteriaPlus.BackColor = .LighterBlue
'         Me.btnCompressorPlus.ForeColor = .HeaderBlue
'         Me.btnCompressorPlus.BackColor = .LighterBlue
'         Me.btnCondenserPlus.ForeColor = .HeaderBlue
'         Me.btnCondenserPlus.BackColor = .LighterBlue
'         'Me.btnEvaporatorPlus.ForeColor = .HeaderBlue
'         'Me.btnEvaporatorPlus.BackColor = .LighterBlue

'      End With
'   End Sub



'   Private Sub SetOtherEvaporatorVisibility()
'      'If Me.radOtherEvaporator.Checked Then
'      '    Me.tbxEvap8Degr1.Visible = True
'      '    Me.tbxEvap10Degr1.Visible = True
'      '    If Int32.Parse(Me.Txt_circuit_per_unit.Text) > 1 Then
'      '        Me.tbxEvap8Degr2.Visible = True
'      '        Me.tbxEvap10Degr2.Visible = True
'      '    Else
'      '        Me.tbxEvap8Degr2.Visible = False
'      '        Me.tbxEvap10Degr2.Visible = False
'      '    End If
'      'Else
'      '    Me.tbxEvap8Degr1.Visible = False
'      '    Me.tbxEvap10Degr1.Visible = False
'      '    Me.tbxEvap8Degr2.Visible = False
'      '    Me.tbxEvap10Degr2.Visible = False
'      'End If
'   End Sub


'   ''' <summary>Sets the chiller's evaporator controls
'   ''' </summary>
'   ''' <remarks>Sets evaporator length textbox and chiller model textbox and label
'   ''' </remarks>
'   Private Sub SetChillerEvaporatorControls()
'      Dim evaporator As Evaporator1
'      Dim chillerDescription As String
'      Dim newLine As String = System.Environment.NewLine

'      Try
'         'retrieves chiller evaporator information
'         evaporator = BCA.RetrieveChillerEvaporator(Me.GrabEvaporatorModel())
'      Catch ex As OleDb.OleDbException
'         MessageBox.Show("Attempt to retrieve the chiller's evaporator information failed. " & ex.Message, _
'            "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
'      End Try

'   End Sub


'   Private Sub SetControlAccess()
'      'Label3.Visible = False

'      '****** NEWER ********
'      txtApproach.Visible = False
'      txtSubCooling.ReadOnly = True

'      'Label2.Visible = False
'      cboSafetyOverride.Visible = False
'      lboCompressors1.Visible = False
'      lboCompressors2.Visible = False
'      txtNumCompressors1.ReadOnly = True
'      txtNumCompressors2.ReadOnly = True
'      txtNumCoils1.ReadOnly = True
'      txtNumCoils2.ReadOnly = True
'      'cboFinsPerInch1.Enabled = True
'      'cboFinsPerInch2.Enabled = True
'      cboSubCooling1.Enabled = False
'      cboSubCooling2.Enabled = False
'      cboCondenser1.Enabled = False
'      cboCondenser2.Enabled = False
'      txtSubCooling1.Visible = False
'      txtSubCooling2.Visible = False
'      'txtFinHeight1.ReadOnly = True
'      'txtFinHeight2.ReadOnly = True
'      'txtFinLength1.ReadOnly = True
'      'txtFinLength2.ReadOnly = True
'      txtCondenserTD1.Visible = False
'      txtCondenserTD2.Visible = False
'      txtNumFans1.ReadOnly = True
'      txtNumFans2.ReadOnly = True
'      txtCondenserCapacity1.Visible = False
'      txtCondenserCapacity2.Visible = False
'      chkCatalogRating.Checked = True
'      chkCatalogRating.Visible = False
'      'radOtherEvaporator.Visible = False

'      'rad6To8Approach.Visible = False
'      'rad7To9Approach.Visible = False
'      'rad8To10Approach.Visible = False
'      'rad9To11Approach.Visible = False
'      'rad10To12Approach.Visible = False

'      'txtCapacityAt4FApproach.Visible = False
'      'txtCapacityAt5FApproach.Visible = False
'      'txtCapacityAt6FApproach.Visible = False
'      'txtCapacityAt7FApproach.Visible = False
'      'txtCapacityAt8FApproach.Visible = False
'      'txtCapacityAt9FApproach.Visible = False
'      'txtCapacityAt10FApproach.Visible = False
'      'txtCapacityAt11FApproach.Visible = False
'      'txtCapacityAt12FApproach.Visible = False

'      'tbxEvap4.Visible = False
'      'tbxEvap5.Visible = False
'      'tbxEvap6.Visible = False
'      'tbxEvap7.Visible = False
'      'tbxEvap8.Visible = False
'      'tbxEvap9.Visible = False
'      'tbxEvap10.Visible = False
'      'tbxEvap11.Visible = False
'      'tbxEvap12.Visible = False
'      txtSubCooling.Enabled = False
'      cboSystem.Visible = False
'      'cboFoulingFactor.Visible = True
'      cboDischargeLineLoss.Visible = False
'      cboSuctionLineLoss.Visible = False
'   End Sub


'   ''' <summary>Fills listbox with compressor description
'   ''' </summary>
'   ''' <history>[CASEYJ]	5/4/2005	Created
'   ''' </history>
'   Private Sub FillCompressorListBoxes()
'      Dim compressorsTable As DataTable

'      Try
'         ' gets list of compressors for selected refrigerant
'         compressorsTable = Business.Agents.Compressor.RetrieveCompressorDescriptions2(Refrigerant.Name.Replace("R", ""), chkNewCoefficients.Checked)
'         ''compressorsTable = Business.Agents.Compressor.RetrieveCompressorDescriptions2(Refrigerant.Name.Replace("R", ""))
'         'Dim strRef As String = Refrigerant.Name.Replace("R", "")
'         'If strRef = "22" Then
'         '    strRef += "H"
'         'End If
'         'compressorsTable = Rae.RaeSolutions.DataAccess35A0.RetrieveCompressorDescriptions(strRef, chkNewCoefficients.Checked, Me.cboVolts.SelectedItem.ToString)
'      Catch ex As OleDb.OleDbException
'         Ui.MessageBox.Show("Attempt to retrieve compressor descriptions failed." & Environment.NewLine & ex.Message)
'         Exit Sub
'      End Try

'      ' inserts 'Choose' in list
'      Dim row As DataRow
'      row = compressorsTable.NewRow
'      row("Description") = "Choose"
'      row("compmodel") = "Choose"
'      compressorsTable.Rows.InsertAt(row, 0)

'      'fills compressor listboxes, use copy of table so that the listboxes aren't forced to stay in sync
'      Me.lboCompressors1.DataSource = compressorsTable.Copy()
'      Me.lboCompressors1.DisplayMember = "Description"
'      Me.lboCompressors1.ValueMember = "compmodel"

'      Me.lboCompressors2.DataSource = compressorsTable.Copy()
'      Me.lboCompressors2.DisplayMember = "Description"
'      Me.lboCompressors2.ValueMember = "compmodel"
'   End Sub


'#End Region


'   ' TODO: move declarations to top of class
'   Private chillerVMgr As ValidationManager
'   Private leavingFluidTempVCtrl As ValidationControl


'   ''' <summary>Initializes validation utilities (managers, controls, and validators).</summary>
'   Private Sub InitializeValidation()
'      ' VMgr - ValidationManager
'      ' VCtrl - ValidationControl
'      ' RangeV - RangeValidator, ReqV - RequiredValidator, NumV - NumberValidator

'      Dim leavingFluidTempReqV As RequiredValidator
'      Dim leavingFluidTempNumV As RegularExpressionValidator
'      Dim leavingFluidTempRangeV As AmongRangeValidator
'      Dim leavingFluidTempName As String = "Leaving fluid temperature textbox"

'      ' constructs and sets validation managers error provider
'      Me.chillerVMgr = New ValidationManager(Me.err)
'      ' constructs and adds leaving fluid temperature textbox to validation control
'      Me.leavingFluidTempVCtrl = New ValidationControl(Me.txtLeavingFluidTemp)

'      ' constructs required validator
'      leavingFluidTempReqV = New RequiredValidator(ErrorMessages.Required(leavingFluidTempName))
'      ' constructs number (regular expression) validator
'      leavingFluidTempNumV = New RegularExpressionValidator( _
'         ErrorMessages.Number(leavingFluidTempName), RegularExpressions.Number)
'      ' contstructs range validator w/ error message and limits
'      leavingFluidTempRangeV = New AmongRangeValidator(ErrorMessages.Range( _
'         leavingFluidTempName, LEAVING_FLUID_TEMP_LOWER_LIMIT, LEAVING_FLUID_TEMP_UPPER_LIMIT), _
'         LEAVING_FLUID_TEMP_LOWER_LIMIT, LEAVING_FLUID_TEMP_UPPER_LIMIT)

'      ' adds leaving fluid temperature control to validation manager
'      Me.chillerVMgr.ValidationControls.Add(Me.leavingFluidTempVCtrl)

'      ' adds validators to leaving fluid temperature textbox
'      '
'      ' adds range validator
'      Me.leavingFluidTempVCtrl.Validators.Add(leavingFluidTempRangeV)
'      ' adds required validator
'      Me.leavingFluidTempVCtrl.Validators.Add(leavingFluidTempReqV)
'      ' adds number (regular expression) validator
'      Me.leavingFluidTempVCtrl.Validators.Add(leavingFluidTempNumV)


'   End Sub


'   Private Sub InitializeControls()
'      ' changing the index so the textbox will fill w/ Choose
'      Me.lboCompressors1.SelectedIndex = 1
'      Me.lboCompressors1.SelectedIndex = 0
'      Me.lboCompressors2.SelectedIndex = 1
'      Me.lboCompressors2.SelectedIndex = 0

'      ' sets series default
'      Me.cboSeries.SelectedIndex = 0
'      ' sets model default
'      'Me.cboSeries_SelectedIndexChanged(New Object, New EventArgs)


'   End Sub


'   Private Function IsChillerModelValid() As Boolean
'      Dim isValid As Boolean

'      ' checks if model is valid
'      If Me.GrabChillerModel Is Nothing OrElse Me.GrabChillerModel.Length = 0 OrElse Me.GrabChillerModel = "Choose" Then
'         isValid = False
'      Else
'         isValid = True
'      End If

'      Return isValid
'   End Function

'   Sub LoadControls(ByVal process_item As WCChillerProcessItem)

'      ' If latest revision has not been set then
'      ' we need to set it now  based on the ID...
'      If Me.m_LatestRevision = 0 Then
'         Me.m_LatestRevision = Rae.RaeSolutions.DataAccess.Projects.ProcessItemDA.LastestRevision(Me.Tag)
'      End If

'      ' Increment the current process revision
'      ' displayed on this form...
'      Me.m_CurrentRevision = process_item.Revision

'      ' Clone last saved process to passing process item
'      LastSavedProcess = process_item.Clone()

'      cboSeries.Text = LastSavedProcess.Series
'      cboModels.Text = LastSavedProcess.Model
'      txtModel.Text = LastSavedProcess.ModelDesc
'      cboFluid.Text = LastSavedProcess.Fluid
'      txtGlycolPercentage.Text = LastSavedProcess.GlycolPercentage
'      cboCoolingMedia.Text = LastSavedProcess.CoolingMedia
'      txtSpecificHeat.Text = LastSavedProcess.SpecificHeat
'      txtSpecificGravity.Text = LastSavedProcess.SpecificGravity
'      txtSubCooling.Text = LastSavedProcess.SubCooling
'      cboRefrigerant.Text = LastSavedProcess.Refrigerant
'      txtTempRange.Text = LastSavedProcess.TempRange
'      txtAmbientTemp.Text = LastSavedProcess.AmbientTemp
'      txtLeavingFluidTemp.Text = LastSavedProcess.LeavingFluidTemp
'      cboSystem.Text = LastSavedProcess.System
'      cboHertz.Text = LastSavedProcess.Hertz
'      txtApproach.Text = LastSavedProcess.Approach
'      cboVolts.Text = LastSavedProcess.Volts
'      'txtTEMin.Text = LastSavedProcess.TEMin
'      'txtTEMax.Text = LastSavedProcess.TEMax
'      'txtTEIncrement.Text = LastSavedProcess.TEIncrement
'      'txtATMin.Text = LastSavedProcess.ATMin
'      'txtATMax.Text = LastSavedProcess.ATMax
'      'txtATIncrement.Text = LastSavedProcess.ATIncrement
'      cboSafetyOverride.Checked = LastSavedProcess.SafetyOverride
'      radCircuit1.Checked = LastSavedProcess.Circuit1
'      radCircuit2.Checked = LastSavedProcess.Circuit2
'      txtCompressor1.Text = LastSavedProcess.Compressors1
'      txtCompressor2.Text = LastSavedProcess.Compressors2
'      txtNumCompressors1.Text = LastSavedProcess.NumCompressors1
'      txtNumCompressors2.Text = LastSavedProcess.NumCompressors2
'      Try
'         lboCompressors1.SetSelected(lboCompressors1.Items.IndexOf(LastSavedProcess.Compressors1), True)
'      Catch ex As Exception
'      End Try
'      Try
'         lboCompressors2.SetSelected(lboCompressors2.Items.IndexOf(LastSavedProcess.Compressors2), True)
'      Catch ex As Exception
'      End Try
'      txtNumCoils1.Text = LastSavedProcess.NumCoils1
'      txtNumCoils2.Text = LastSavedProcess.NumCoils2
'      cboCondenser1.Text = LastSavedProcess.Condenser1
'      cboCondenser2.Text = LastSavedProcess.Condenser2
'      cboDischargeLineLoss.Text = LastSavedProcess.DischargeLineLoss
'      cboSuctionLineLoss.Text = LastSavedProcess.SuctionLineLoss
'      txtAltitude.Text = LastSavedProcess.Altitude
'      'txtPumpWatts.Text = LastSavedProcess.PumpWatts
'      txtFanWatts.Text = LastSavedProcess.FanWatts
'      txtCondenserCapacity1.Text = LastSavedProcess.CondenserCapacity1
'      txtCondenserCapacity2.Text = LastSavedProcess.CondenserCapacity2
'      'cboEvaporatorModel.Text = LastSavedProcess.EvaporatorModel
'      'txtEvaporatorModel.Text = LastSavedProcess.EvaporatorModelDesc
'      'cboNumEvap.Text = LastSavedProcess.NumEvap
'      'cboFoulingFactor.Text = LastSavedProcess.FoulingFactor
'      'If LastSavedProcess.CapacityType = WCChillerProcessItem.eCapacityType.Tons Then
'      '    radTons.Checked = True
'      'ElseIf LastSavedProcess.CapacityType = WCChillerProcessItem.eCapacityType.GPM Then
'      '    radGpm.Checked = True
'      'Else
'      '    radGpm.Checked = False
'      '    radTons.Checked = False
'      'End If
'      'txtEvaporatorCapacity.Text = LastSavedProcess.EvaporatorCapacity
'      chkCatalogRating.Checked = LastSavedProcess.CatalogRating
'      ' Approach range...
'      'If LastSavedProcess.ApproachRange = WCChillerProcessItem.eApproachRange.SixToEight Then
'      '    rad6To8Approach.Checked = True
'      'ElseIf LastSavedProcess.ApproachRange = WCChillerProcessItem.eApproachRange.SevenToNine Then
'      '    rad7To9Approach.Checked = True
'      'ElseIf LastSavedProcess.ApproachRange = WCChillerProcessItem.eApproachRange.EightToTen Then
'      '    rad8To10Approach.Checked = True
'      'ElseIf LastSavedProcess.ApproachRange = WCChillerProcessItem.eApproachRange.NineToEleven Then
'      '    rad9To11Approach.Checked = True
'      'ElseIf LastSavedProcess.ApproachRange = WCChillerProcessItem.eApproachRange.TenToTwelve Then
'      '    rad10To12Approach.Checked = True
'      'ElseIf LastSavedProcess.ApproachRange = WCChillerProcessItem.eApproachRange.Other Then
'      '    radOtherEvaporator.Checked = True
'      'End If
'      'tbxEvap8Degr1.Text = LastSavedProcess.Evap8Degr1
'      'tbxEvap8Degr2.Text = LastSavedProcess.Evap8Degr2
'      'tbxEvap10Degr1.Text = LastSavedProcess.Evap10Degr1
'      'tbxEvap10Degr2.Text = LastSavedProcess.Evap10Degr2

'      ' Calculate page...
'      'btnCalculatePage_Click(btnCalculatePage, Nothing)

'   End Sub

'   ''' <summary>
'   ''' Handles revision view control's revision changed event.
'   ''' If user has unsaved changes, asks user to save before navigating revisions.
'   ''' </summary>
'   Private Sub RevisionView_RevisionChanged(ByVal sender As RevisionView, ByVal e As ValueChangedEventArgs(Of Single))
'      If sender.ActiveProcessForm Is Me Then
'         SaveControls(False, False, False, False, True)
'      End If
'   End Sub

'   Function SaveControls(Optional ByVal SaveAsRevision As Boolean = False, Optional ByVal SaveAsNew As Boolean = False, Optional ByVal FormClosing As Boolean = False, Optional ByVal GenerateEquipment As Boolean = False, Optional ByVal RevChanged As Boolean = False) As Boolean

'      If CurrentStateProcess Is Nothing Then
'         If LastSavedProcess Is Nothing Then
'            CurrentStateProcess = New WCChillerProcessItem(New ItemId(AppInfo.User.Username, AppInfo.User.Password))
'         Else
'            CurrentStateProcess = LastSavedProcess.Clone
'         End If
'      Else
'         If LastSavedProcess IsNot Nothing Then CurrentStateProcess = LastSavedProcess.Clone
'      End If

'      CurrentStateProcess.Series = cboSeries.Text
'      CurrentStateProcess.Model = cboModels.Text
'      CurrentStateProcess.ModelDesc = txtModel.Text
'      CurrentStateProcess.Fluid = cboFluid.Text
'      CurrentStateProcess.GlycolPercentage = txtGlycolPercentage.Text
'      CurrentStateProcess.CoolingMedia = cboCoolingMedia.Text
'      CurrentStateProcess.SpecificHeat = txtSpecificHeat.Text
'      CurrentStateProcess.SpecificGravity = txtSpecificGravity.Text
'      CurrentStateProcess.SubCooling = txtSubCooling.Text
'      CurrentStateProcess.Refrigerant = cboRefrigerant.Text
'      CurrentStateProcess.TempRange = txtTempRange.Text
'      CurrentStateProcess.AmbientTemp = txtAmbientTemp.Text
'      CurrentStateProcess.LeavingFluidTemp = txtLeavingFluidTemp.Text
'      CurrentStateProcess.System = cboSystem.Text
'      CurrentStateProcess.Hertz = cboHertz.Text
'      CurrentStateProcess.Approach = txtApproach.Text
'      CurrentStateProcess.Volts = cboVolts.Text
'      'CurrentStateProcess.TEMin = txtTEMin.Text
'      'CurrentStateProcess.TEMax = txtTEMax.Text
'      'CurrentStateProcess.TEIncrement = txtTEIncrement.Text
'      'CurrentStateProcess.ATMin = txtATMin.Text
'      'CurrentStateProcess.ATMax = txtATMax.Text
'      'CurrentStateProcess.ATIncrement = txtATIncrement.Text
'      CurrentStateProcess.SafetyOverride = cboSafetyOverride.Checked
'      CurrentStateProcess.Circuit1 = radCircuit1.Checked
'      CurrentStateProcess.Circuit2 = radCircuit2.Checked
'      CurrentStateProcess.Compressors1 = txtCompressor1.Text
'      CurrentStateProcess.Compressors2 = txtCompressor2.Text
'      CurrentStateProcess.NumCompressors1 = txtNumCompressors1.Text
'      CurrentStateProcess.NumCompressors2 = txtNumCompressors2.Text
'      CurrentStateProcess.NumCoils1 = txtNumCoils1.Text
'      CurrentStateProcess.NumCoils2 = txtNumCoils2.Text
'      CurrentStateProcess.Condenser1 = cboCondenser1.Text
'      CurrentStateProcess.Condenser2 = cboCondenser2.Text
'      CurrentStateProcess.DischargeLineLoss = cboDischargeLineLoss.Text
'      CurrentStateProcess.SuctionLineLoss = cboSuctionLineLoss.Text
'      CurrentStateProcess.Altitude = txtAltitude.Text
'      'CurrentStateProcess.PumpWatts = txtPumpWatts.Text
'      CurrentStateProcess.FanWatts = Val(txtFanWatts.Text)
'      CurrentStateProcess.CondenserCapacity1 = CDbl(txtCondenserCapacity1.Text)
'      CurrentStateProcess.CondenserCapacity2 = CDbl(txtCondenserCapacity2.Text)
'      'CurrentStateProcess.EvaporatorModel = cboEvaporatorModel.Text
'      ''CurrentStateProcess.EvaporatorModelDesc = txtEvaporatorModel.Text
'      ''CurrentStateProcess.NumEvap = cboNumEvap.Text
'      'CurrentStateProcess.FoulingFactor = cboFoulingFactor.Text
'      'If radTons.Checked = True Then
'      '    CurrentStateProcess.CapacityType = WCChillerProcessItem.eCapacityType.Tons
'      'ElseIf radGpm.Checked = True Then
'      '    CurrentStateProcess.CapacityType = WCChillerProcessItem.eCapacityType.GPM
'      'End If
'      'CurrentStateProcess.EvaporatorCapacity = txtEvaporatorCapacity.Text
'      CurrentStateProcess.CatalogRating = chkCatalogRating.Checked
'      ' Approach range...
'      'If rad6To8Approach.Checked = True Then
'      '    CurrentStateProcess.ApproachRange = WCChillerProcessItem.eApproachRange.SixToEight
'      'ElseIf rad7To9Approach.Checked = True Then
'      '    CurrentStateProcess.ApproachRange = WCChillerProcessItem.eApproachRange.SevenToNine
'      'ElseIf rad8To10Approach.Checked = True Then
'      '    CurrentStateProcess.ApproachRange = WCChillerProcessItem.eApproachRange.EightToTen
'      'ElseIf rad9To11Approach.Checked = True Then
'      '    CurrentStateProcess.ApproachRange = WCChillerProcessItem.eApproachRange.NineToEleven
'      'ElseIf rad10To12Approach.Checked = True Then
'      '    CurrentStateProcess.ApproachRange = WCChillerProcessItem.eApproachRange.TenToTwelve
'      'ElseIf radOtherEvaporator.Checked = True Then
'      '    CurrentStateProcess.ApproachRange = WCChillerProcessItem.eApproachRange.Other
'      'End If
'      'CurrentStateProcess.Evap8Degr1 = tbxEvap8Degr1.Text
'      'CurrentStateProcess.Evap8Degr2 = tbxEvap8Degr2.Text
'      'CurrentStateProcess.Evap10Degr1 = tbxEvap10Degr1.Text
'      'CurrentStateProcess.Evap10Degr2 = tbxEvap10Degr2.Text

'      ' Set save process...
'      Dim RevSave As New RevisionSave
'      CurrentStateProcess = RevSave.SetSaveProcess(Me, Business.ProcessType.WCChiller, CurrentStateProcess, LastSavedProcess, SaveAsNew, SaveAsRevision, FormClosing, GenerateEquipment, RevChanged)
'      If RevSave.CancelSave = True Then
'         If CurrentStateProcess Is Nothing Then
'            ' canceled
'            RevSave = Nothing
'            Return False
'         Else
'            ' do not save and continue to close
'            RevSave = Nothing
'            Return True
'         End If
'      End If

'      ' Set last saved process...
'      LastSavedProcess = RevSave.RevisionSaved(CurrentStateProcess)
'      If RevSave.CancelSave = False Then
'         ' only save if user chooses...
'         CurrentStateProcess = LastSavedProcess.Clone
'         RevSave = Nothing
'         Return True
'      Else
'         ' User cancelled form close...
'         RevSave = Nothing
'         Return False
'      End If


'   End Function

'#Region " Testing"

'   'Fill hidden listboxes w/ refrigerants based on compressor     
'   'Private Sub FillHidRefrigerantsForSelectedCompressor()
'   '   Dim compressorModel As String = Me.txtCompressor.Text.Trim

'   '   Dim refrigerants As System.Collections.Specialized.StringCollection
'   '   refrigerants = DataAccess.Compressor.RetrieveRefrigerants(compressorModel)

'   '   If Me.Running_Circuit_no = 1 Then
'   '      Me.ListBox2.DataSource = refrigerants
'   '   ElseIf Me.Running_Circuit_no = 2 Then
'   '      Me.ListBox3.DataSource = refrigerants
'   '   End If
'   'End Sub

'#End Region





'#Region " Public methods"

'   Public Sub Open(ByVal Process_Item As ProcessItem)
'      Me.LoadControls(Process_Item)
'   End Sub

'#End Region

'   Private Sub mnuChillerFilePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles printMenuItem.Click
'      Me.Cursor = Windows.Forms.Cursors.WaitCursor

'      Dim doc As New C1.C1PrintDocument.C1PrintDocument
'      'controls font and other styles on printed page
'      Dim printStyle As New C1.C1PrintDocument.C1DocStyle(doc)  'used in rendering spacer image
'      printStyle.Font = New Font("Arial", 10, FontStyle.Regular)
'      'the page settings from frmC1PrintPreview.vb are not applied
'      'page settings must be set in code in order to be applied
'      doc.PageSettings.Margins.Top = 50
'      doc.PageSettings.Margins.Bottom = 50

'      doc.DefaultUnit = C1.C1PrintDocument.UnitTypeEnum.Mm
'      'header
'      doc.PageHeader.Height = 8
'      doc.PageHeader.RenderText.Style = printStyle
'      doc.PageHeader.RenderText.Style.TextAlignHorz = C1.C1PrintDocument.AlignHorzEnum.Center
'      doc.PageHeader.RenderText.Style.TextAlignVert = C1.C1PrintDocument.AlignVertEnum.Top
'      doc.PageHeader.RenderText.Text = Me.Text
'      'footer
'      doc.PageFooter.Height = 8
'      doc.PageFooter.RenderText.Style = printStyle
'      doc.PageFooter.RenderText.Style.TextAlignHorz = C1.C1PrintDocument.AlignHorzEnum.Right
'      doc.PageFooter.RenderText.Style.TextAlignVert = C1.C1PrintDocument.AlignVertEnum.Bottom
'      doc.PageFooter.RenderText.Text = "Page [@@PageNo@@] of [@@PageCount@@]"

'      doc.StartDoc() 'start rendering
'      doc.RenderBlockControlImage(Me.panModel)
'      doc.RenderBlockControlImage(Me.panRatingCriteriaHeader)
'      doc.RenderBlockControlImage(Me.panRatingCriteria)
'      doc.RenderBlockControlImage(Me.panCompressorHeader)
'      doc.RenderBlockControlImage(Me.panCompressor)

'      'page return				
'      Dim whiteImage As Image  'image is used to fill space at the end of a page
'      'implemented to function as a page return
'      whiteImage = Image.FromFile(AppInfo.AppFolderPath & "Images\whitebox.gif")
'      doc.RenderBlockImage(whiteImage, 3, doc.AvailableBlockFlowHeight, printStyle)
'      doc.RenderBlockControlImage(Me.panCondenserHeader)
'      doc.RenderBlockControlImage(Me.panCondenser)

'      'page return		
'      doc.RenderBlockImage(whiteImage, 3, doc.AvailableBlockFlowHeight, printStyle)
'      'doc.RenderBlockControlImage(Me.panEvaporatorHeader)
'      'doc.RenderBlockControlImage(Me.panEvaporator)

'      If Not (Me.dgrC1Results.DataSource Is Nothing) Then
'         'page return
'         doc.RenderBlockImage(whiteImage, 3, doc.AvailableBlockFlowHeight, printStyle)
'         doc.RenderBlockControlSmart(Me.dgrC1Results)
'      End If
'      doc.EndDoc() 'stop rendering

'      Dim formPreview As New C1PrintPreviewForm 'create instance form to preview before printing
'      formPreview.C1PrintPreview1.Document = doc 'set the form's document to the document just created

'      Me.Cursor = Windows.Forms.Cursors.Default

'      formPreview.ShowDialog() 'can't have mdiparent otherwise error occurs
'      formPreview.Close()
'   End Sub

'   Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveMenuItem.Click
'      SaveControls()
'   End Sub

'   Private Sub RevisionWaterCooledChillerRatingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveAsRevisionMenuItem.Click
'      SaveControls(True)
'   End Sub

'   Private Sub SaveAsNewWaterCooledChillerRatingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveAsMenuItem.Click
'      SaveControls(False, True)
'   End Sub

'   Private Sub ConvertWaterCooledChillerRatingToEquipmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles convertToEquipmentMenuItem.Click
'      SaveControls(False, False, False, True)
'   End Sub

'   Private Sub lblCondenserTD1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCondenserTD1.Click

'   End Sub

'   Private Sub txtTempRange_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTempRange.TextChanged
'      Dim alI As ArrayList = Math.Calculate.Multiples(CInt(txtTempRange.Text))
'      cboStep.DataSource = alI
'      If alI.Contains(5) Then
'         cboStep.Text = "5"
'      Else
'         cboStep.Text = "1"
'      End If
'   End Sub
End Class