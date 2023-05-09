Imports System
Imports System.Environment
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Net.NetworkInformation
Imports Process = System.Diagnostics.Process
Imports Path = System.IO.Path
Imports File = System.IO.File
Imports Rae.RaeSolutions.Business
Imports Rae.solutions.group
Imports Rae.Presentation.SpecialOptions
Imports Rae.solutions
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.Networking
Imports Rae.Collections
Imports Rae.Deployment
Imports Connection = Rae.Networking.Connection
Imports TerminalDecision = Rae.Ui.TerminalDecision
Imports ContactDataStructure = Rae.RaeSolutions.Updating.ContactDataStructure
Imports Rae.Ui.quickies
Imports Rae.RaeSolutions.DataAccess.Projects
Imports Rae.RaeSolutions.DataAccess
Imports System.Data
Imports ClosedXML.Excel
Imports ClosedXML
Imports Microsoft.VisualBasic


''' <summary>Main MDI form.</summary>
Public Class MainForm
    Public Shared currentLogo As String = ""
    Private user As user
    Public Shared openReport As Boolean
    Public Shared project As ProjectForm






#Region " Private Methods"


#Region " Event Handlers"

    Private Sub MainForm_Load() _
    Handles MyBase.Load
        Me.Text = My.Application.Info.Title

        ' adds event handler for ProjectSet event
        AddHandler OpenedProject.ProjectSet, AddressOf OnProjectSet

        ' initializes this and referenced assemblies
        Me.initializeAssemblies()



        ' updates application if employee and has network connectivity
        If Me.updateEmployee() = TerminalDecision.Exit Then
            Application.Exit() : Exit Sub
        End If

        ' checks if application is expired and warns user if expiration date is approaching
        If Me.checkExpirationDate() = TerminalDecision.Exit Then
            Application.Exit() : Exit Sub
        End If

        HideOrShowCloud()



        registerComComponents()
        refactorDatabase()

        Me.initializeControls()

        If AppInfo.User.is_in(century_sales) Then
            PrintToolStripMenuItem1.Visible = True
            'OrderEntryToolStripMenuItem.Visible = False
        End If

        ' shows welcome form...
        Me.TimerWelcome.Enabled = True

    End Sub

    Private Sub HideOrShowCloud()

        '30058915

        If user.HasCloudAccess Then
            tsmiCloudUtilities.Visible = True
        Else
            tsmiCloudUtilities.Visible = False
        End If

    End Sub

#Region " Menu event handlers"

    Private Sub mnuCloseProject_Click() _
    Handles mnuCloseProject.Click
        closeProject()
    End Sub

    Private Sub mnuLogin_Click() _
    Handles mnuLogin.Click, loginToolStripButton.Click
        Dim frmLogin As New LoginForm()
        frmLogin.ShowDialog()
    End Sub

    Private Sub mnuNewProject_Click() _
    Handles mnuNewProject.Click, projectToolStripMenuItem.Click
        ProjectInfo.Creator.CreateProject()
    End Sub

    Private Sub mnuNewEquipment_Click() _
    Handles mnuNewEquipment.Click, equipmentToolStripMenuItem.Click
        ProjectInfo.Creator.CreateEquipment() ' ' guides user to create new equipment
    End Sub

    Private Sub mnuOpen_Click() _
    Handles mnuOpen.Click
        ProjectInfo.Creator.CreateExistingProject() ' guides user to open existing project.
    End Sub

    Private Sub mnuCondensingUnitProcess_Click() _
    Handles mnuCondensingUnitProcess.Click
        Me.show_inside_main_screen(New condensing_unit_rating_screen)
    End Sub

    Sub BoxLoadMenu_Click() _
    Handles BoxLoadToolStripMenuItem.Click, BoxLoadMenuItem.Click
        ProjectInfo.Viewer.ViewBoxLoad()
    End Sub

    Private Sub mnuCondenserProcess_Click() _
    Handles mnuCondenserProcess.Click
        Me.show_inside_main_screen(New condenser_rating_screen)
    End Sub

    Private Sub mnuCondensingUnitUnitCoolerBalance_Click() _
    Handles mnuCondensingUnitUnitCoolerBalance.Click
        Me.show_inside_main_screen(New cu_uc_balance_window)
    End Sub

    Private Sub mnuAirHandlerProcess_Click() _
    Handles mnuAirHandlerProcess.Click
        Me.show_inside_main_screen(form_project_info.GetInstance())
    End Sub

    Private Sub mnuAirCooledChillerProcess_Click() _
    Handles mnuAirCooledChillerProcess.Click
        If user.is_employee Then
            Me.show_inside_main_screen(New air_cooled_chiller_balance_window())
        Else
            Me.show_inside_main_screen(New RepAirCooledChillerForm())
        End If
    End Sub

    Private Sub mnuEvaporativeCondenserChillerProcess_Click() _
    Handles mnuEvaporativeCondenserChillerProcess.Click
        Me.show_inside_main_screen(New evaporative_condenser_chiller_balance_window)
    End Sub

    Private Sub mnuWaterCooledCondensingUnitRating_Click() _
    Handles mnuWaterCooledCondensingUnitRating.Click
        show_inside_main_screen(New WaterCooledCondenser())
    End Sub

    Private Sub mnuFluidCoolerRating_Click() Handles mnuFluidCoolerRating.Click
        show_inside_main_screen(New FluidCoolerForm())
    End Sub

    Private Sub mnuSpecBuilderProcess_Click() _
    Handles mnuSpecBuilderProcess.Click
        Dim specBuilderWizard As Rae.Wizard.Wizard
        Dim i As Integer

        Me.Cursor = Cursors.WaitCursor
        Try
            'gets a default SpecBuilder Wizard
            specBuilderWizard = SpecBuilder.SpecBuilderManager.GetDefaultSpecBuilderWizard()
            For i = 0 To specBuilderWizard.Forms.Count - 1
                'sets each forms mdi parent
                specBuilderWizard.Forms.Item(i).MdiParent = Me
            Next
            'starts default SpecBuilder
            specBuilderWizard.Start()
        Catch ex As Exception
            Ui.MessageBox.Show("An error occurred in SpecBuilder. " & ex.Message, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub condenserEquipmentMenuItem_Click() _
    Handles condenserEquipmentMenuItem.Click
        ProjectInfo.Viewer.ViewEquipment(Business.EquipmentType.Condenser)
    End Sub

    Private Sub chillerEquipmentMenuItem_Click() _
    Handles chillerEquipmentMenuItem.Click
        ProjectInfo.Viewer.ViewEquipment(Business.EquipmentType.Chiller)
    End Sub

    Private Sub condensingUnitEquipmentMenuItem_Click() _
    Handles condensingUnitEquipmentMenuItem.Click
        ProjectInfo.Viewer.ViewEquipment(Business.EquipmentType.CondensingUnit)
    End Sub

    Private Sub fluidCoolerEquipmentMenuItem_Click() _
    Handles fluidCoolerEquipmentMenuItem.Click
        ProjectInfo.Viewer.ViewEquipment(Business.EquipmentType.FluidCooler)
    End Sub

    Private Sub productCoolerEquipmentMenuItem_Click() _
    Handles productCoolerEquipmentMenuItem.Click
        ProjectInfo.Viewer.ViewEquipment(Business.EquipmentType.ProductCooler)
    End Sub

    Private Sub unitCoolerEquipmentMenuItem_Click() _
    Handles unitCoolerEquipmentMenuItem.Click
        ProjectInfo.Viewer.ViewEquipment(Business.EquipmentType.UnitCooler)
    End Sub

    Private Sub mnuDrawings_Click() _
    Handles mnuManageDrawings.Click

        'Dim tmpform As New Rae.Drawings.frmDrawingParameters
        'Me.ShowForm(tmpform)
        Exit Sub

        Dim relativePath As String = "EDrawings\ACAD_EDRAWINGS_TEST.exe"
        Dim filePath As String

        Try
            filePath = System.IO.Path.Combine(AppInfo.AppFolderPath, relativePath)
            System.Diagnostics.Process.Start(filePath)
        Catch ex As Exception
            Ui.MessageBox.Show("The drawing program could not be opened." & NewLine & "Path: " & filePath, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub mnuExit_Click() _
    Handles mnuExit.Click
        Application.Exit()
    End Sub

    Private Sub mnuManageSpecialOptions_Click() _
    Handles mnuManageSpecialOptions.Click
        Me.show_inside_main_screen(New SpecialOptions.SpecialOptionsForm)
    End Sub

    Private Sub priceSheetMenuItem_Click() _
    Handles priceSheetMenuItem.Click
        ' creates list of authorized divisions
        Dim authorizedDivisions As New List(Of String)()
        Select Case user.access_level
            Case access_level.ALL, access_level.ALL_P
                authorizedDivisions.Add("CRI")
                authorizedDivisions.Add("TSI")
            Case access_level.CRI, access_level.CRI_P
                authorizedDivisions.Add("CRI")
            Case access_level.TSI, access_level.TSI_P
                authorizedDivisions.Add("TSI")
        End Select

        Try
            Dim priceSheetForm As New PriceSheetForm(authorizedDivisions, user.username, _
               My.Application.Info.ProductName, My.Application.Info.Version.ToString())
            priceSheetForm.MdiParent = Me
            priceSheetForm.Show()
        Catch ex As Exception
            MessageBox.Show("An error occurred while opening price sheet. " & ex.Message)
        End Try
    End Sub

    Private Sub mnuTileHorizontally_Click() _
    Handles mnuTileHorizontally.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub mnuTileVertically_Click() _
    Handles mnuTileVertically.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub mnuCascade_Click() _
    Handles mnuCascade.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub aboutMenuItem_Click() _
    Handles aboutMenuItem.Click
        Dim about As New AboutForm
        about.ShowDialog(Me)
    End Sub

    'Private Sub versionHistoryMenuItem_Click() _
    'Handles versionHistoryMenuItem.Click
    'Process.Start(Constants.VERSION_HISTORY_LINK)
    'End Sub

    Private Sub mnuViewHelpFile_Click() _
    Handles mnuViewHelpFile.Click
        Try
            Process.Start(Rae.RaeSolutions.DataAccess.Common.RepHelpPath)
        Catch ex As Exception
            MessageBox.Show("Could not open help file.")
        End Try
    End Sub

#End Region


    ''' <summary>
    ''' Handles main status strip click event.
    ''' Shows tool tip
    ''' </summary>
    Private Sub MainStatus_Click() _
    Handles MainStatus.Click
        Dim tip As String = Me.mainToolTip.GetToolTip(Me.MainStatus)

        If Not String.IsNullOrEmpty(tip) Then
            Me.mainToolTip.Show(tip, Me.MainStatus, 40, 0, 8000)
        End If
    End Sub

#End Region


#Region " Internal Helper Methods"

    Private Sub registerComComponents()
        Dim fileName As String = "RAE_SelectionfRating.dll"
        Dim filePath As String = Path.Combine(AppInfo.AppFolderPath, fileName)
        If File.Exists(filePath) Then
            Dim registrar As New ComRegistrar(filePath)
            registrar.Register(ComRegistrar.OutcomeMode.Silent)
        End If

        fileName = "RAEDLL_CONDENSING_UNIT.dll"
        filePath = Path.Combine(AppInfo.AppFolderPath, fileName)
        If File.Exists(filePath) Then
            Dim registrar As New ComRegistrar(filePath)
            registrar.Register(ComRegistrar.OutcomeMode.Silent)
        End If
    End Sub


    Private Sub refactorDatabase()
        Dim connectionString As String = DataAccess.Common.GetMicrosoftAccessConnectionString(DataAccess.Common.ProjectsDbPath)
        Dim refactoringFilePath As String = System.IO.Path.Combine(AppInfo.AppFolderPath, "Rae.RaeSolutions.Data.Refactoring.Projects.dll")

        Dim refactorer As New Rae.Data.Refactoring.Refactorer(connectionString, refactoringFilePath)
        refactorer.Refactor()
    End Sub


    Private Sub closeProject()
        For Each frm As Form In Me.MdiChildren
            frm.Close()
        Next
        OpenedProject.Manager = Nothing
    End Sub


    ''' <summary>
    ''' Initializes assemblies that RaeSolutions is dependent on.
    ''' </summary>
    Private Sub initializeAssemblies()

        ' initializes project info
        ProjectInfo.Initialize(Me)

        ' initializes database folder locations, now that the executable file path is known (overloaded w/ DataAccess Type 10-29-07 Scott)
        'DataAccess.Common.Initialize(AppInfo.AppFolderPath, AppInfo.DbFolderPath)
        DataAccess.Common.Initialize(AppInfo.AppFolderPath, AppInfo.DbFolderPath, My.Settings.CustomDataFilePath)

        ' initializes equipment options data access
        Rae.DataAccess.EquipmentOptions.ConnectionString.Initialize(DataAccess.Common.DbFolderPath, Constants.DATAACCESS_CONFIG)

        ' initializes special options data access
        ' Rae.DataAccess.SpecialOptions.ConnectionString.Initialize(AppInfo.ServerDbFolderPath)

        Dim condenserDbPath = System.IO.Path.Combine(DataAccess.Common.DbFolderPath, DataAccess.Common.CondenserDbPath)
        Rae.RaeSolutions.Business.Entities.Cofans.settings.db_file_path = condenserDbPath



        Rae.RaeSolutions.Business.Entities.Cofans.settings.buzz_file_path = AppInfo.BuzzFolderPath

        ' ensures a project database exists and that existing user data isn't overwritten
        UserDataProtector.EnsureFileExists(DataAccess.Common.ProjectsDbPath, Constants.TARGET_USER_GROUP)

        Dim appConfigFileName = My.Application.Info.AssemblyName & ".exe.config"
        Dim appConfigFilePath = Path.Combine(My.Application.Info.DirectoryPath, appConfigFileName)
        Rae.Configuration.ConfigFactory.Initialize(appConfigFilePath, "Rae.RaeSolutions")


        Dim x As Boolean = Rae.DataAccess.EquipmentOptions.OptionsDataAccess.CheckDBVersion("20151020")
        If x = False Then
            MsgBox("Your copy of RAE Solutions did not update properly. Please contact the RAE Corporation IT Department for assistance.")
            Application.Exit()
        End If


    End Sub


    ''' <summary>
    ''' Initializes control values.
    ''' </summary>
    Private Sub initializeControls()
        ' sets version in status bar
        Me.versionStatusLabel.Text = My.Application.Info.Version.ToString()
    End Sub


    ''' <summary>
    ''' Updates application for employees and returns decision on whether to continue or exit application.
    ''' </summary>
    Private Function updateEmployee() As TerminalDecision


        If Constants.TARGET_USER_GROUP = user_group.employee _
        AndAlso AppInfo.NetworkConnectivity = Connectivity.Connected Then

            Dim exitDecision As Boolean
            exitDecision = Updater.CheckForUpdate()
            If exitDecision Then Return TerminalDecision.Exit

            Return TerminalDecision.Continue

        End If


        '' checks if user is a rae employee and on the rae network (onsite or vpn)
        'If Constants.TARGET_USER_GROUP = user_group.employee _
        'AndAlso AppInfo.NetworkConnectivity = Connectivity.Connected AndAlso Not user.username.ToUpper.StartsWith("CASEY") Then
        '    Dim serverFilePath As String = "\\fileserver1\FileSer1_E\UpDate Control\Rae_Auto_Update_Setup\Rae_Auto_Update.exe"
        '    Dim localFilePath As String = "C:\Program Files\Rae_Auto_Update\Rae_Auto_Update.exe"
        '    Dim overwrite As Boolean = True
        '    If Not System.IO.File.Exists(serverFilePath) Then
        '        Return TerminalDecision.Continue
        '    End If

        '    System.IO.File.Copy(serverFilePath, localFilePath, overwrite)
        '    ' checks if update is available
        '    If Updater.CheckForNewVersion(Constants.INHOUSE_UPDATER_FILE_NAME, True) Then
        '        Return TerminalDecision.Exit
        '        'ElseIf Updater.CheckForNewFiles(Constants.INHOUSE_UPDATER_UPDATE_FILES_FILE_NAME, True) Then
        '        '    Return TerminalDecision.Exit
        '    End If
        'End If
        'Return TerminalDecision.Continue
    End Function


    ''' <summary>
    ''' Determines if application is expired and returns terminal decision. 
    ''' Warns user if expiration date is approaching soon.
    ''' </summary>
    Private Function checkExpirationDate() As TerminalDecision

        Return TerminalDecision.Continue

        Dim expirationMgr As New ExpirationManager(Application.StartupPath & "\" & "rses.dat", Constants.EXPIRATION_DATE) 'Constants.EXPIRATION_FILE_PATH, Constants.EXPIRATION_DATE)
        Dim numDaysUntilExpiration As Integer

        ' checks if software is expired
        If expirationMgr.Status = ExpirationManager.ExpirationStatus.Expired Then
            ' notifies user that software is expired
            Ui.MessageBox.Show(Strings.ApplicationExpired, MessageBoxIcon.Information)
            Return TerminalDecision.Exit

        Else
            ' gets number of days until expiration occurs
            numDaysUntilExpiration = expirationMgr.GetDaysUntilExpiration()

            ' shows warning if expiration date is near
            If numDaysUntilExpiration <= 25 Then
                ' warns user expiration date is approaching soon
                Ui.MessageBox.Show(Strings.ApplicationExpirationApproaching(numDaysUntilExpiration), MessageBoxIcon.Warning)
            End If

            Return TerminalDecision.Continue
        End If
    End Function

#End Region

#End Region


#Region " Public methods"

    ' TODO: think of better way
    Sub SetLoginDependentControls()
        Me.loginToolStripButton.ToolTipText = "Login - " & user.username

        Dim employee = (user.authority_group = user_group.employee)
        Dim technicalSystems = (AppInfo.Division = Business.Division.TSI)
        Dim century = (AppInfo.Division = Business.Division.CRI)

        'sets control visibility based on company selected and employee/rep status
        '
        mnuAirCooledChillerProcess.Visible = technicalSystems AndAlso employee
        mnuSpecBuilderProcess.Visible = technicalSystems AndAlso employee
        mnuPumpEquipment.Visible = technicalSystems AndAlso employee
        mnuEvaporativeCondenserChillerProcess.Visible = technicalSystems
        mnuAirHandlerProcess.Visible = technicalSystems AndAlso employee
        mnuFluidCoolerRating.Visible = technicalSystems AndAlso employee
        priceSheetMenuItem.Visible = Not (technicalSystems AndAlso user.is_rep)

        mnu_unit_cooler_selection.Visible = century OrElse (technicalSystems AndAlso employee)

        chillerEquipmentMenuItem.Visible = technicalSystems
        'fluidCoolerEquipmentMenuItem.Visible= technicalSystems


        condenserEquipmentMenuItem.Visible = century OrElse (technicalSystems AndAlso employee)
        fluidCoolerEquipmentMenuItem.Visible = technicalSystems AndAlso employee



        mnuCondensingUnitUnitCoolerBalance.Visible = century
        productCoolerEquipmentMenuItem.Visible = century
        unitCoolerEquipmentMenuItem.Visible = century
        ''boxloadHeader.Visible = century
        BoxLoadListView1.Visible = century
        BoxLoadMenuItem.Visible = century
        QuickStart1.newBoxLoadLabel.Visible = century
        QuickStart1.lbl_select_unit_cooler.Visible = century
        BoxLoadToolStripMenuItem.Visible = century

        ' condensingUnitEquipmentMenuItem.Visible = century Or (employee And technicalSystems)
        mnuCondensingUnitProcess.Visible = True ' century Or (employee And technicalSystems)

        ' sets authority group (rep or employee) in status bar
        Me.authorityGroupStatusLabel.Text = user.authority_group.ToString()

        mnu_tools.Visible = employee

        ' hides rep's update menu item from employees
        If Constants.TARGET_USER_GROUP = user_group.rep Then
            Me.mnuManageDrawings.Visible = False
            Me.mnu_tools.Visible = False
        End If

        mnuWaterCooledCondensingUnitRating.Visible = user.can(rate_water_cooled_condensing_unit)

        Me.AssignMultiplierCodeMenu.Visible = user.is_in(sales)

        mnu_d_catalog.Visible = user.can(generate_catalogs)
        mnu_n_catalog.Visible = user.can(generate_catalogs)
        Mnu20ACatalog.Visible = user.can(generate_catalogs)


        mnu_unit_cooler_catalog.Visible = user.can(generate_catalogs)

        QuickStart1.Height = IIf(century, 184, 140)
    End Sub


    ''' <summary>Shows form in MDI container.</summary>
    Friend Sub show_inside_main_screen(ByVal window As Form)
        window.MdiParent = Me
        window.Show()
    End Sub

#End Region


#Region " Unorganized"

    ''' <summary>
    ''' Handles project manager's project set event. Initializes project dependent controls.
    ''' </summary>
    Private Sub OnProjectSet(ByVal projectMgr As project_manager, ByVal e As EventArgs)
        If projectMgr Is Nothing Then
            ' TEST: is removehandle needed
            'RemoveHandler OpenedProject.Manager.Equipment.ItemAdded, AddressOf Equipment_Added
            Me.EquipmentListView1.Equipment = Nothing
            Me.ProjectListView1.Manager = Nothing
            Me.ProcessListView1.Processes = Nothing
            Me.BoxLoadListView1.BoxLoads = Nothing
        Else

            AddHandler OpenedProject.Manager.BoxLoads.ItemAdded, AddressOf BoxLoad_ItemAdded
            AddHandler OpenedProject.Manager.BoxLoads.RemovingItem, AddressOf BoxLoads_RemovingItem
            Me.BoxLoadListView1.BoxLoads = OpenedProject.Manager.BoxLoads

            AddHandler OpenedProject.Manager.Equipment.ItemAdded, AddressOf Equipment_Added
            Me.EquipmentListView1.Equipment = OpenedProject.Manager.Equipment

            Me.ProjectListView1.Manager = OpenedProject.Manager
            Me.ProcessListView1.Processes = OpenedProject.Manager.Processes

            ProjectInfo.Viewer.ViewProject(projectMgr.Project)
        End If
    End Sub



    Private Sub BoxLoad_ItemAdded( _
    ByVal sender As EventfulList(Of BoxLoad), ByVal e As ListItemAddedEventArgs)
        Dim itemId As String = sender.Item(e.Index).id.ToString()
        ProjectInfo.Viewer.ViewBoxLoad(itemId)
    End Sub

    Private Sub BoxLoads_RemovingItem( _
    ByVal sender As EventfulList(Of BoxLoad), ByVal e As ListItemRemovedEventArgs)
        Dim b As BoxLoad = CType(sender(e.Index), BoxLoad)

        ProjectInfo.Viewer.CloseForm(b.id.ToString)
        b.Delete()
    End Sub


    ''' <summary>
    ''' Handles equipment added event. Views equipment.
    ''' </summary>
    Private Sub Equipment_Added( _
    ByVal sender As EventfulList(Of EquipmentItem), ByVal e As ListItemAddedEventArgs)
        Dim junk As String = ""
        ProjectInfo.Viewer.ViewEquipment(sender.Item(e.Index), False, False, junk)
    End Sub


    Private Sub TimerWelcome_Tick() _
    Handles TimerWelcome.Tick
        TimerWelcome.Enabled = False

        Dim frmWelcome As New WelcomeForm()
        frmWelcome.ShowDialog()
    End Sub

    ' REVIEW: This should probably be in ItemCreator
    Public Sub StartNewProcess()
        Dim frmNewProcess As New NewItemForm2
        frmNewProcess.getProcessType = True
        frmNewProcess.NewItem(NewItemForm2.NewItemType.SelectionTypeOnly, Business.ProcessType.NA)
        frmNewProcess.ShowDialog()
        Try
            Select Case frmNewProcess.ProcessType
                Case Business.ProcessType.AirCooledChiller
                    If user.is_employee Then
                        show_inside_main_screen(New air_cooled_chiller_balance_window)
                    Else
                        show_inside_main_screen(New RepAirCooledChillerForm)
                    End If
                Case Business.ProcessType.Condenser
                    show_inside_main_screen(New condenser_rating_screen)
                Case Business.ProcessType.CondensingUnit
                    show_inside_main_screen(New condensing_unit_rating_screen)
                Case Business.ProcessType.EvaporativeCondenserChiller
                    show_inside_main_screen(New evaporative_condenser_chiller_balance_window)
                Case Business.ProcessType.UnitCoolerBalance
                    show_inside_main_screen(New cu_uc_balance_window)
                    'Case Business.ProcessType.WCChiller
                    'ShowForm(New ChillerWaterCooledForm)
                    'Case Business.ProcessType.WCCondensingUnit
                    '   ShowForm(New WaterCooledCondenser)
                Case Business.ProcessType.AirHandler
                    show_inside_main_screen(form_project_info.GetInstance())
                Case Business.ProcessType.FluidCooler
                    show_inside_main_screen(New FluidCoolerForm())

                Case Business.ProcessType.SpecBuilder
                    Dim specBuilderWizard As Rae.Wizard.Wizard
                    Dim i As Integer

                    Me.Cursor = Cursors.WaitCursor
                    Try
                        'gets a default SpecBuilder Wizard
                        specBuilderWizard = SpecBuilder.SpecBuilderManager.GetDefaultSpecBuilderWizard()
                        For i = 0 To specBuilderWizard.Forms.Count - 1
                            'sets each forms mdi parent
                            specBuilderWizard.Forms.Item(i).MdiParent = Me
                        Next
                        'starts default SpecBuilder
                        specBuilderWizard.Start()
                    Catch ex As Exception
                        Ui.MessageBox.Show("An error occurred in SpecBuilder. " & ex.Message, MessageBoxIcon.Error)
                    Finally
                        Me.Cursor = Cursors.Default
                    End Try
            End Select
        Catch ex As Exception
            Ui.MessageBox.Show("An error occurred when starting new process. " & ex.Message)
        End Try
        frmNewProcess.Close()
        frmNewProcess = Nothing
    End Sub

    Private Sub SelectionRatingToolStripMenuItem_Click() Handles SelectionRatingToolStripMenuItem.Click
        Me.StartNewProcess()
    End Sub

    Private Sub mnuNewProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.StartNewProcess()
    End Sub

    Private Sub SaveProjectAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If OpenedProject.IsOpened Then
            Dim newProjectID As String = ProjectInfo.CopyProject(OpenedProject.Manager.Project.id.Id)
            ' see if we can successfully copy current project to new project
            If Trim(newProjectID) > " " Then
                ' close current project
                For Each frm As Form In Me.MdiChildren
                    frm.Close()
                Next
                OpenedProject.Manager = Nothing
                ' open project (saved as) based on new ID...
                Dim tmpIC As ItemCreator
                tmpIC = New ItemCreator()
                tmpIC.OpenExistingProject(newProjectID)
                tmpIC = Nothing
            End If
        End If
    End Sub

    Private Sub RevisionProjectToolStripMenuItem_Click() _
    Handles RevisionProjectToolStripMenuItem.Click

        If OpenedProject.IsOpened Then

            If ProjectInfo.wasTableCheckedOut(OpenedProject.Manager.Project.id.Id, "Projects") Then
                MessageBox.Show("You cannot revision a project while you have it checked out.", "Cannot Revision During Checkout", MessageBoxButtons.OK)
                Exit Sub
            End If

            ' hold current project id
            Dim projID As String = OpenedProject.Manager.Project.id.Id

            ' close forms
            For Each frm As Form In Me.MdiChildren
                frm.Close()
            Next

            ' revision project
            ProjectInfo.RevisionProject(projID)

            ' release opened project manager
            OpenedProject.Manager = Nothing

            ' re-open project...
            Dim tmpIC As ItemCreator
            tmpIC = New ItemCreator()
            tmpIC.OpenExistingProject(projID)
            tmpIC = Nothing
        End If

    End Sub

    'Private Function FindStandardCompressorsWithoutRaePartReference() As List(Of String)

    '    Dim compressorlist As New List(Of String)
    '    Dim raepartref As String
    '    Dim connstr As String
    '    Dim myconn As New System.Data.OleDb.OleDbConnection
    '    Dim mycommand As New System.Data.OleDb.OleDbCommand
    '    Dim rs As System.Data.OleDb.OleDbDataReader

    '    ' check condensing units
    '    For a As Integer = 1 To 2
    '        If a = 1 Then
    '            connstr = Rae.RaeSolutions.DataAccess.Common.GetConnectionString(Rae.RaeSolutions.DataAccess.Common.CondensingUnitDbPath)
    '        Else
    '            connstr = Rae.RaeSolutions.DataAccess.Common.GetConnectionString(Rae.RaeSolutions.DataAccess.Common.ChillerDbPath)
    '        End If

    '        Try

    '            myconn.ConnectionString = (connstr)
    '            myconn.Open()
    '            mycommand.Connection = myconn
    '            mycommand.CommandText = "SELECT * " & _
    '                                    "FROM [Table5] order by [Compressor_1]"
    '            rs = mycommand.ExecuteReader()
    '            While rs.Read
    '                For i As Integer = 1 To 4
    '                    If Not IsDBNull(rs("Compressor_" & i)) Then
    '                        If Trim(rs("Compressor_" & i).ToString) > " " Then
    '                            raepartref = GetRaePartReference(Trim(rs("Compressor_" & i).ToString))
    '                            If raepartref = "Contact Factory" Or raepartref = "" Or raepartref = "?" Or Trim(raepartref).Length < 9 Then
    '                                'If compressorlist.IndexOf(Trim(rs("Compressor_" & i)) & " used on " & Trim(rs("Model"))) > 0 Then
    '                                '   ' do not add!
    '                                'Else
    '                                '   compressorlist.Add(Trim(rs("Compressor_" & i)) & " used on " & Trim(rs("Model")))
    '                                'End If
    '                                If compressorlist.IndexOf(Trim(rs("Compressor_" & i))) > 0 Then
    '                                    ' do not add!
    '                                Else
    '                                    compressorlist.Add(Trim(rs("Compressor_" & i)))
    '                                End If
    '                            End If
    '                        End If
    '                    End If
    '                Next
    '            End While
    '        Catch ex As System.Data.OleDb.OleDbException
    '            Throw ex
    '        End Try

    '        If Not IsNothing(rs) Then rs.Close()
    '        If myconn.State <> System.Data.ConnectionState.Closed Then myconn.Close()

    '    Next
    '    Return compressorlist

    'End Function

    'Private Function GetRaePartReference(ByVal compressor As String) As String

    '    Dim connstr As String = Rae.RaeSolutions.DataAccess.Common.GetConnectionString(Rae.RaeSolutions.DataAccess.Common.CompressorDbPath)
    '    Dim raepartref As String = ""

    '    Dim myconn As New System.Data.OleDb.OleDbConnection
    '    Dim mycommand As New System.Data.OleDb.OleDbCommand
    '    Dim rs As System.Data.OleDb.OleDbDataReader

    '    Try
    '        myconn.ConnectionString = (connstr)
    '        myconn.Open()
    '        mycommand.Connection = myconn
    '        mycommand.CommandText = "SELECT * " & _
    '                                "FROM [CompressorWarrantyInfo] " & _
    '                                "WHERE [CompressorModel] = '" & compressor & "'"
    '        rs = mycommand.ExecuteReader()
    '        If rs.Read() Then
    '            If Not IsDBNull(rs("PartNumber")) Then
    '                raepartref = rs("PartNumber")
    '            End If
    '        End If
    '    Catch ex As System.Data.OleDb.OleDbException
    '        Throw ex
    '    Finally
    '        If Not IsNothing(rs) Then rs.Close()
    '        If myconn.State <> System.Data.ConnectionState.Closed Then myconn.Close()
    '    End Try

    '    Return raepartref

    'End Function

    'Private Sub GetStdCompressorsWithoutRAEPartReferenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim msgstr As String = ""
    '    For Each str As String In FindStandardCompressorsWithoutRaePartReference()
    '        msgstr += str & vbCrLf
    '    Next
    '    MessageBox.Show(msgstr)
    'End Sub

    'Private Sub mnuBackupProjects_Click() Handles mnuBackupProjects.Click '(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim ierror As Integer = 0
    '    Dim msg As String = String.Empty
    '    Dim buform As New BackupForm
    '    If buform.ShowDialog = Windows.Forms.DialogResult.OK Then
    '        If My.Settings.BackupLocation.Length > 0 And My.Settings.BackupDate > CDate("1/1/2000") Then
    '            Dim file As New System.IO.FileInfo(My.Settings.BackupLocation)
    '            If file.Exists Then
    '                msg = "Backup Successful!"
    '                ierror = 64
    '            Else
    '                msg = "Error backing up projects!"
    '                ierror = 16c
    '            End If
    '        Else
    '            msg = "Error backing up projects!"
    '            ierror = 16
    '        End If
    '    Else
    '        msg = "Backup Cancelled!"
    '        ierror = 48
    '    End If
    '    MessageBox.Show(Me, msg, String.Empty, MessageBoxButtons.OK, ierror)
    'End Sub

    '  Private Sub mnuRestoreProjects_Click() Handles mnuRestoreProjects.Click '(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '      Dim bu As String = My.MySettings.Default.BackupLocation
    '      Dim strMSGEmpty As String = "A previous backup file cannot be determined!" & vbCrLf & vbCrLf & "To locate your backup file click 'OK', otherwise click 'CANCEL'."
    '      Dim strMSGFound As String = "A previous backup file has been found at " & bu & ", created " & My.Settings.BackupDate.ToShortDateString() & " " & My.Settings.BackupDate.ToShortTimeString() & "." & _
    'vbCrLf & vbCrLf & "Would you like to use this file?" & vbCrLf & "To use this backup file click 'YES', to locate an alternate backup file click 'NO', otherwise click 'CANCEL'."
    '      If bu.Length = 0 AndAlso My.Settings.BackupDate < CDate("1/1/2000") Then
    '          If MessageBox.Show(strMSGEmpty, String.Empty, MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
    '              openRestoreBackup.Filter = "Access|*.mdb"
    '              openRestoreBackup.FileName = "Projects.mdb"
    '              If openRestoreBackup.ShowDialog = Windows.Forms.DialogResult.OK Then
    '                  RestorefromBackup(openRestoreBackup.FileName)
    '              End If
    '          End If
    '      Else
    '          Dim results As DialogResult = MessageBox.Show(strMSGFound, String.Empty, MessageBoxButtons.YesNoCancel)
    '          If results = Windows.Forms.DialogResult.Yes Then
    '              RestorefromBackup(bu)
    '          ElseIf results = Windows.Forms.DialogResult.No Then
    '              openRestoreBackup.Filter = "Access|*.mdb"
    '              openRestoreBackup.FileName = "Projects.mdb"
    '              If openRestoreBackup.ShowDialog = Windows.Forms.DialogResult.OK Then
    '                  RestorefromBackup(openRestoreBackup.FileName)
    '              End If
    '          End If
    '      End If
    '  End Sub

    Private Sub RestorefromBackup(ByVal filename As String)
        Dim file As New System.IO.FileInfo(filename)
        Dim dt As DateTime
        If file.Exists Then
            If filename = My.Settings.BackupLocation Then 'My.Settings.BackupDate > CDate("1/1/2000") Then
                dt = My.Settings.BackupDate
            Else
                dt = file.LastWriteTime
            End If
            Dim msg As String = "Your are attempting to replace your projects with the backup " & filename & " made on" & dt.ToShortDateString() & " " & dt.ToShortTimeString() & "." & vbCrLf & "Doing so will replace any additions/modifications made since then." & vbCrLf & vbCrLf & "Do you wish to continue?"
            If MessageBox.Show(msg, "Backup Restoration", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim f As New System.IO.FileInfo(Rae.RaeSolutions.DataAccess.Common.ProjectsDbPath)
                If f.Exists Then
                    f.IsReadOnly = False
                    Try
                        file.CopyTo(f.FullName, True)
                        MessageBox.Show("Restoration of backup sucessful!")
                    Catch ex As Exception
                        MessageBox.Show("Restoration of backup failed!")
                    End Try
                End If
            End If
        Else
            MessageBox.Show("Backup file (" & filename & ") cannot be found.")
        End If
    End Sub


    Private Sub CompressorWarrantyMaintenanceToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.show_inside_main_screen(New Rae.DatabaseMaintenance.CompressorWarrantyMaintenance)
    End Sub

    Private Sub CompressorWarrantyMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.show_inside_main_screen(New Rae.DatabaseMaintenance.CompressorWarrantyMaintenance)
    End Sub

#End Region


#Region " Check-in/out"

    Private Sub CheckOutToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If OpenedProject.IsOpened Then
            If MessageBox.Show("You cannot checkout projects while you have a project open.  Do you want to close this project and continue?", "Close Project And Continue?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                'If AppInfo.User.Username.ToLower = ProjectInfo.GetProjectOwner(OpenedProject.Manager.Project.Id).ToLower Then
                '   Dim pid As String = OpenedProject.Manager.Project.Id.Id
                '   CloseProject()
                '   ProjectInfo.CheckoutProject(pid)
                'Else
                '   MessageBox.Show("Only the project owner may check a project out.  (Owner: " & ProjectInfo.GetProjectOwner(OpenedProject.Manager.Project.Id) & ")", "Cannot Checkout Project", MessageBoxButtons.OK)
                'End If
                If Rae.RaeSolutions.DataAccess.Common.IsConnected Then
                    Me.closeProject()
                    ProjectInfo.CheckoutProjects()
                Else
                    MessageBox.Show("You are not connected to the server.  Please connect and retry.", "NOT CONNECTED", MessageBoxButtons.OK)
                End If
            End If
        Else
            If Rae.RaeSolutions.DataAccess.Common.IsConnected Then
                ProjectInfo.CheckoutProjects()
            Else
                MessageBox.Show("You are not connected to the server.  Please connect and retry.", "NOT CONNECTED", MessageBoxButtons.OK)
            End If
        End If
    End Sub

    Private Sub CheckInToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If OpenedProject.IsOpened Then
            If MessageBox.Show("You cannot check in projects while you have a project open.  Do you want to close this project and continue?", "Close Project And Continue?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                'Dim pid As String = OpenedProject.Manager.Project.Id.Id
                'CloseProject()
                'ProjectInfo.CheckinProjects(pid)
                If Rae.RaeSolutions.DataAccess.Common.IsConnected Then
                    Me.closeProject()
                    ProjectInfo.CheckinProjects()
                Else
                    MessageBox.Show("You are not connected to the server.  Please connect and retry.", "NOT CONNECTED", MessageBoxButtons.OK)
                End If
            End If
        Else
            If Rae.RaeSolutions.DataAccess.Common.IsConnected Then
                ProjectInfo.CheckinProjects()
            Else
                MessageBox.Show("You are not connected to the server.  Please connect and retry.", "NOT CONNECTED", MessageBoxButtons.OK)
            End If
        End If
    End Sub

    Private Sub SequelProjectImportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If OpenedProject.IsOpened Then
            MessageBox.Show("You cannot import projects while you have a project open.  Please close your project and try again.", "Cannot Import While Project Open", MessageBoxButtons.OK)
        Else
            If Rae.RaeSolutions.DataAccess.Common.IsConnected Then
                If MessageBox.Show("Importing your projects may take several minutes.  Do you want to continue?", "Import Projects", MessageBoxButtons.YesNo) = vbYes Then
                    Me.Cursor = Cursors.WaitCursor
                    ProjectInfo.ImportAllProjects()
                    Me.Cursor = Cursors.Default
                End If
            Else
                MessageBox.Show("You are not connected to the server.  Please connect and retry.", "NOT CONNECTED", MessageBoxButtons.OK)
            End If
        End If
    End Sub

#End Region


    Private Sub AssignCustomMultiplierMenu_Click() _
    Handles AssignMultiplierCodeMenu.Click
        Dim form As New CustomMultiplierForm()
        show_inside_main_screen(form)
    End Sub

    Private Sub CopyExistingItemMenu_Click() _
    Handles CopyExistingItemToolStripMenu.Click, CopyExistingItemMenu.Click
        Dim wf As New CopyExistingItemWorkFlow(OpenedProject.IsOpened)
        wf.Start()
    End Sub

    Private Sub mnuPumpPackage_Click() _
    Handles mnuPumpEquipment.Click
        ProjectInfo.Viewer.ViewEquipment(EquipmentType.PumpPackage)
    End Sub

    Private Sub mnu_d_catalog_click() Handles mnu_d_catalog.Click
        Dim form = New catalog_form()
        form.letter = "D"
        form.division = "CRI"
        show_inside_main_screen(form)
    End Sub



    Private Sub mnu_n_catalog_click() Handles mnu_n_catalog.Click
        Dim form = New catalog_form()

        form.letter = InputBox("Letter (% okay)", , "N")

        '  form.letter = "ND%30"
        form.division = InputBox("division", , "CRI")
        show_inside_main_screen(form)
    End Sub



    Private Sub mnu_unit_cooler_catalog_click() Handles mnu_unit_cooler_catalog.Click
        Dim screen = New unit_cooler_catalog_screen()
        show_inside_main_screen(screen)
    End Sub

    Private Sub mnu_unit_cooler_selection_click() Handles mnu_unit_cooler_selection.Click
        Dim viewer = ProjectInfo.Viewer
        viewer.view(Of unit_cooler_selection_screen)()
    End Sub


    Private Sub QuickStart1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuickStart1.Load

    End Sub

    Private Sub RevisionView1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RevisionView1.Load

    End Sub

    Private Sub MainMenu_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MainMenu.ItemClicked

    End Sub

    Private Sub Mnu20ACatalog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnu20ACatalog.Click
        Dim form = New catalog_form()
        form.letter = "20"
        form.division = "TSI"
        show_inside_main_screen(form)
    End Sub

    Private Sub AdvancedProgramOptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvancedProgramOptionsToolStripMenuItem.Click

        AdvancedProgramOptions.ShowDialog()



    End Sub



    Private Sub SaveProjectToCloudToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveProjectToCloudToolStripMenuItem.Click


        Dim orderEntryForm As New OrderEntry
        orderEntryForm.MdiParent = Me.MdiParent
        orderEntryForm.Show()


    End Sub



    Private Sub ImportProjectFromCloudToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportProjectFromCloudToolStripMenuItem.Click

        closeProject()

        Dim loadCloudProjectForm As New LoadCloudProject
        loadCloudProjectForm.MdiParent = Me.MdiParent
        loadCloudProjectForm.Show()




        'Dim orderEntryForm As New OrderEntry
        'orderEntryForm.MdiParent = Me.MdiParent
        'orderEntryForm.Show()



    End Sub

    Private Sub ManageUsersToolStripItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManageUsersToolStripItem.Click
        Dim ShareMyProjectsForm As New ShareMyProjects
        ShareMyProjectsForm.MdiParent = Me.MdiParent
        ShareMyProjectsForm.Show()

    End Sub

    Private Sub SaveProjectAsToolStripMenuItem_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles SaveProjectAsToolStripMenuItem.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub CheckAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CheckAllToolStripMenuItem.Click

        For Each row As DataGridViewRow In EquipmentListView1.grdEquipment.Rows
            Dim chk As DataGridViewCheckBoxCell = CType(row.Cells(1), DataGridViewCheckBoxCell)
            chk.Value = True
        Next row

    End Sub

    Private Sub PrintCheckedToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PrintCheckedToolStripMenuItem.Click


        'currentLogo = New which_division().ask({"TSI", "CRI", "RSI", "RAE"})

        '  printSelected()


        Dim print1 As New Print
        print1.main = Me

        print1.ShowDialog()

    End Sub

    Public Sub selectRow()
        Me.Refresh()
        'MainForm.EquipmentListView1.grdEquipment.Rows().Selected = True

        'printSelected()
    End Sub

    Public Sub printSelected(ByVal writeUp As Boolean, ByVal submittal As Boolean, ByVal drawing As Boolean, ByVal unitRating As Boolean) 'boxLoad As Boolean


        'Me.Cursor = Cursors.WaitCursor

        If currentLogo = "" Then
            currentLogo = New which_division().ask({"TSI", "CRI", "RSI", "RAE"})
        End If

        UseWaitCursor = True

        For Each row As DataGridViewRow In Me.EquipmentListView1.grdEquipment.Rows
            Dim chk As DataGridViewCheckBoxCell = CType(row.Cells(1), DataGridViewCheckBoxCell)
            If chk.Value = True Then
                Dim equipment As EquipmentItem
                'Beep()
                chk.Selected = True
                Dim tempName As String = ""
                If writeUp = True Then
                    If Me.EquipmentListView1.SelectedEquipment IsNot Nothing Then
                        tempName = Me.EquipmentListView1.SelectedEquipment.name
                        ProjectInfo.Viewer.ViewEquipment(Me.EquipmentListView1.SelectedEquipment, True, True, "", True, currentLogo)
                    End If
                End If

                If submittal = True Then
                    printSubmittal()
                End If

                For Each row1 As DataGridViewRow In Me.ProcessListView1.processGrid.Rows
                    Dim id As String = row1.Cells(0).Value.ToString()
                    row1.Selected = True
                    If unitRating = True AndAlso tempName = Me.ProcessListView1.SelectedProcess.name Then
                        printRating(Me.ProcessListView1.SelectedProcess)
                        Exit For
                    End If
                Next

                If drawing = True Then
                    printDrawing()
                End If
            End If
        Next

        If writeUp = False And unitRating = True Then
            For Each row1 As DataGridViewRow In Me.ProcessListView1.processGrid.Rows
                Dim id As String = row1.Cells(0).Value.ToString()
                row1.Selected = True
                printRating(Me.ProcessListView1.SelectedProcess)
            Next
        End If

        'For Each row As DataGridViewRow In Me.ProcessListView1.processGrid.Rows
        '    Dim id As String = row.Cells(0).Value.ToString()
        '    row.Selected = True
        '    If unitRating = True Then
        '        printRating(Me.ProcessListView1.SelectedProcess)
        '    End If
        'Next

        'For Each row As DataGridViewRow In Me.BoxLoadListView1.BoxLoadGrid.Rows
        '    Dim id As String = row.Cells(0).Value.ToString()
        '    row.Selected = True
        '    If boxLoad = True Then
        '        printBoxLoad(id)
        '    End If
        'Next

        UseWaitCursor = False
        currentLogo = ""
        'Me.Cursor = Cursors.Default
    End Sub

    Public Sub printSubmittal()
        Dim equipmentForm As New EquipmentForm

        openReport = False

        equipmentForm = ProjectInfo.Viewer.ViewEquipment(Me.EquipmentListView1.SelectedEquipment, True, False, "")

        If equipmentForm.EquipmentSelector1.Series = "AWSM" AndAlso Not equipmentForm.FaceVelocityInRange() Then
            equipmentForm.tabEquipment.SelectedIndex = 0
            Exit Sub
        End If

        Dim returnTab As Integer
        If Not equipmentForm.CheckObligatoryOptionsAndSpecs(returnTab) Then
            equipmentForm.tabEquipment.SelectedIndex = returnTab
            Exit Sub
        End If

        equipmentForm.onViewSubmittal(True, "", True, currentLogo)

        openReport = True
    End Sub

    Public Sub printDrawing()
        Dim equipmentForm As New EquipmentForm

        openReport = False

        equipmentForm = ProjectInfo.Viewer.ViewEquipment(Me.EquipmentListView1.SelectedEquipment, True, False, "")

        equipmentForm.barUnitDrawingsOpen.PerformClick()

        openReport = True


        'Dim dxfToPDf As New DXFtoPDF.WebService2
        'If dxfToPDf.dxfToPDF(dxf) = False Then
        '    MessageBox.Show("Error Generating Drawing")
        'End If
    End Sub

    Public Sub printRating(ByVal process As ProcessItem)
        'Dim rating As New condenser_rating_screen
        'Dim process As New ProcessListView
        Dim form As New Form
        Dim processItem As New ProcessType

        openReport = False

        ' figure out how to open rating sheets
        'rating = ProjectInfo.Viewer.ViewProcess(id)
        form = ProjectInfo.Viewer.ViewProcess(Me.ProcessListView1.SelectedProcess)

        'rating.viewReportButton.PerformClick()
        'process.mnuOpen.PerformClick()

        Dim ProcessForm As Object

        If TypeOf process Is cu_uc_balance_screen_model Then
            Dim temp As New cu_uc_balance_window
            temp = form
            temp.btn_show_report.PerformClick()
            'temp.btn_print.PerformClick()
        ElseIf TypeOf process Is CondenserProcessItem Then
            Dim temp As New condenser_rating_screen
            temp = form
            temp.viewReportButton.PerformClick()
        ElseIf TypeOf process Is CondensingUnitProcessItem Then
            Dim temp As New condensing_unit_rating_screen
            temp = form
            temp.btnCreateReport.PerformClick()
        ElseIf TypeOf process Is EvaporativeCondenserChillerBalance Then
            If AppInfo.User.authority_group = user_group.rep Then
                Dim temp As New evaporative_condenser_chiller_balance_window
                temp = form
                temp.btn_create_report.PerformClick()
            ElseIf AppInfo.User.authority_group = user_group.employee Then
                Dim temp As New evaporative_condenser_chiller_balance_window
                temp = form
                temp.btn_create_report.PerformClick()
            End If

        ElseIf TypeOf process Is ACChillerProcessItem Then
            If AppInfo.User.authority_group = user_group.rep Then
                Dim temp As New RepAirCooledChillerForm
                temp = form
                temp.btn_create_report.PerformClick()
            ElseIf AppInfo.User.authority_group = user_group.employee Then
                Dim temp As New air_cooled_chiller_balance_window
                temp = form
                temp.btn_create_report.PerformClick()
            End If

        ElseIf TypeOf process Is FluidCoolerProcessItem AndAlso user_group.employee Then
            Dim temp As New FluidCoolerForm
            temp = form
            temp.btnCreateReport.PerformClick()
        End If

        openReport = True
    End Sub

    'Public Sub printBoxLoad(ByVal id As String)
    '    Dim boxLoad As New frmboxloadcalc2

    '    openReport = False

    '    ' figure out how to open boxload
    '    boxLoad = ProjectInfo.Viewer.ViewBoxLoad(id)

    '    boxLoad.reportTool.PerformClick()

    '    openReport = True
    'End Sub

    Private Sub OrderEntryToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OrderEntryToolStripMenuItem.Click
        'OrderEntryForm.Show()

        project.btnOrderEntry.PerformClick()
    End Sub


    Private Sub SalesOrderEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesOrderEntryToolStripMenuItem.Click
        project.btnSalesOrderEntryClick()
    End Sub
End Class