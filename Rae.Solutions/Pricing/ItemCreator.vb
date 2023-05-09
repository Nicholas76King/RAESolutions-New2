Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.Business
Imports Rae.RaeSolutions.Updating.ContactDataStructure
Imports System.Data
Imports Col = Rae.RaeSolutions.DataAccess.Projects.Tables.EquipmentTable
Imports ProjectsDataAccess = Rae.RaeSolutions.DataAccess.Projects.ProjectsDataAccess
Imports EquipmentDa = Rae.RaeSolutions.DataAccess.Projects.EquipmentDa
Imports Rae.Persistence
Imports Rae.Data.Access
Imports System.Collections.Generic
Imports Rae.DataAccess.EquipmentOptions
Imports Rae.RaeSolutions.DataAccess
Imports Rae.RaeSolutions.DataAccess.EquipmentOptionsAgent
Imports System.Data.OleDb

Public Class ItemCreator

    Dim frmNewItem As New NewItemForm2

    Private m_GetProcessType As Boolean
    ''' <summary>
    ''' GetProcessType
    ''' </summary>
    Public WriteOnly Property GetProcessType() As Boolean
        Set(ByVal value As Boolean)
            Me.m_GetProcessType = value
        End Set
    End Property

    Sub New()
    End Sub

    Sub CreateProject()
        Me.createNewProject()
    End Sub

    Sub CreateProject(projectName As String)
        OpenedProject.Manager = New project_manager(projectName, AppInfo.User.username, AppInfo.User.password)
        OpenedProject.Manager.Project.Save()
    End Sub

    ' only used for box load write now, api could be simplified if other items used this
    Sub Create(item As Object)
        'If BoxLoad
        item.ProjectManager = OpenedProject.Manager
        item.Save()
        OpenedProject.Manager.BoxLoads.Add(item)
    End Sub


    Public Function CreateProcessAndProject(ByVal Process_Type As ProcessType, Optional ByVal process As ProcessItem = Nothing) As ProcessItem
        Dim frmNewProcess As New NewItemForm2
        frmNewProcess.getProcessType = Me.m_GetProcessType
        frmNewProcess.NewItem(NewItemForm2.NewItemType.SelectionAndProject)
        frmNewProcess.ShowDialog()

        If frmNewProcess.IsValid Then
            ' Create new project...
            OpenedProject.Manager = New project_manager(frmNewProcess.ProjectName, AppInfo.User.username, AppInfo.User.password)

            ' avoid duplicate ids
            System.Threading.Thread.CurrentThread.Sleep(1000)

            If OpenedProject.IsOpened Then
                If process Is Nothing Then
                    process = constructProcess(frmNewProcess.SelectionName, _
                                               Process_Type)
                Else
                    process.ProjectManager = OpenedProject.Manager
                    process.name = frmNewProcess.SelectionName
                    process.Division = AppInfo.Division
                    process.Revision = Rae.RaeSolutions.DataAccess.Projects.ProjectsDataAccess.RetrieveLatestRevision(OpenedProject.Manager.Project.id.Id) + 0.001
                End If
                OpenedProject.Manager.Project.Save()
                OpenedProject.Manager.Processes.Add(process)
                OpenedProject.Manager.Processes.Items(process.id).Save()

                frmNewProcess.Close()
                Return process
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If

    End Function

    Public Function CreateProcessAndEquipment(ByVal Process_Type As ProcessType, Optional ByVal process As ProcessItem = Nothing) As ProcessItem

        Dim frmNewProcess As New NewItemForm2
        frmNewProcess.getProcessType = Me.m_GetProcessType
        frmNewProcess.NewItem(NewItemForm2.NewItemType.SelectionAndEquipment, Process_Type, convertToEquipmentType(Process_Type))
        frmNewProcess.ShowDialog()

        If frmNewProcess.IsValid Then

            If OpenedProject.IsOpened Then

                ' Create process if necessary...
                If process Is Nothing Then
                    process = constructProcess(frmNewProcess.SelectionName, _
                                               Process_Type)
                Else
                    process.ProjectManager = OpenedProject.Manager
                    process.name = frmNewProcess.SelectionName
                    process.Division = AppInfo.Division
                    process.Revision = Rae.RaeSolutions.DataAccess.Projects.ProjectsDataAccess.RetrieveLatestRevision(OpenedProject.Manager.Project.id.Id) + 0.001
                End If
                OpenedProject.Manager.Processes.Add(process)
                OpenedProject.Manager.Processes.Items(process.id).Save()

                ' We're creating multiple items in one go - we
                ' need to force a 1 second wait to avoid duplicate
                ' item IDs...
                System.Threading.Thread.CurrentThread.Sleep(1000)

                ' Create equipment from process...
                create_pricing_from_rating(process, frmNewProcess.EquipmentName)

                ' Close form, return process...
                frmNewProcess.Close()
                Return process

            Else

                Return Nothing

            End If

        Else

            Return Nothing

        End If

    End Function

    Public Function CreateProcessEquipmentAndProject(ByVal Process_Type As ProcessType, Optional ByVal process As ProcessItem = Nothing) As ProcessItem

        Dim frmNewProcess As New NewItemForm2
        frmNewProcess.getProcessType = Me.m_GetProcessType
        frmNewProcess.NewItem(NewItemForm2.NewItemType.SelectionEquipmentAndProject, Process_Type, convertToEquipmentType(Process_Type))
        frmNewProcess.ShowDialog()

        If frmNewProcess.IsValid Then

            ' Create new project...
            OpenedProject.Manager = New project_manager(frmNewProcess.ProjectName, AppInfo.User.username, AppInfo.User.password)

            ' We're creating multiple items in one go - we
            ' need to force a 1 second wait to avoid duplicate
            ' item IDs...
            System.Threading.Thread.CurrentThread.Sleep(1000)

            OpenedProject.Manager.Project.Save()

            If OpenedProject.IsOpened Then

                ' Create process if necessary...
                If process Is Nothing Then
                    process = constructProcess(frmNewProcess.SelectionName, _
                                               Process_Type)
                Else
                    process.ProjectManager = OpenedProject.Manager
                    process.name = frmNewProcess.SelectionName
                    process.Division = AppInfo.Division
                    process.Revision = Rae.RaeSolutions.DataAccess.Projects.ProjectsDataAccess.RetrieveLatestRevision(OpenedProject.Manager.Project.id.Id) + 0.001
                End If
                OpenedProject.Manager.Processes.Add(process)
                OpenedProject.Manager.Processes.Items(process.id).Save()

                ' We're creating multiple items in one go - we
                ' need to force a 1 second wait to avoid duplicate
                ' item IDs...
                System.Threading.Thread.CurrentThread.Sleep(1000)

                ' Create equipment from process...
                create_pricing_from_rating(process, frmNewProcess.EquipmentName)

                ' Close form, return process...
                frmNewProcess.Close()
                Return process

            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If

    End Function

    Function CreateEquipmentFromExistingProcess(process As ProcessItem, process_type As ProcessType) As EquipmentItemList
        Dim screen As New NewItemForm2
        screen.NewItem(NewItemForm2.NewItemType.EquipmentOnlyFromSelection, process_type, convertToEquipmentType(process_type))
        screen.ShowDialog()

        If screen.IsValid AndAlso OpenedProject.IsOpened Then _
           Return create_pricing_from_rating(process, screen.EquipmentName)
    End Function

    ''' <summary>
    ''' Creates equipment, adds to project manager and saves.
    ''' </summary>
    Public Sub CreateEquipment(equipment As EquipmentItem)
        ' checks if project is open
        If OpenedProject.IsOpened Then
            'Me.CreateNewEquipment()
            OpenedProject.Manager.Equipment.Add(equipment)
            OpenedProject.Manager.Equipment.Items(equipment.id).Save()
        Else
            Ui.MessageBox.Show(Strings.ProjectNotOpen, MessageBoxIcon.Information)
        End If
    End Sub

    ''' <summary>
    ''' Creates equipment, adds to project manager and saves.
    ''' </summary>
    Public Sub CreateEquipment()
        Me.createNewEquipment()
    End Sub

    ''' <summary>
    ''' Creates process, adds to project manager and saves.
    ''' </summary>
    Public Function CreateProcess(ByVal Process_Type As ProcessType, Optional ByVal process As ProcessItem = Nothing) As ProcessItem
        If Process_Type = ProcessType.NA Then Me.m_GetProcessType = True
        ' checks if project is open
        If OpenedProject.IsOpened Then
            Return Me.createNewProcess(Process_Type, process)
        Else
            Return Nothing
            Ui.MessageBox.Show(Strings.ProjectNotOpen, MessageBoxIcon.Information)
        End If
    End Function

    ''' <summary>
    ''' Prompts user to select existing project and sets open project.
    ''' </summary>
    Public Sub CreateExistingProject(Optional ByVal ProjectIDStr As String = "")

        Dim mainForm As MainForm = CType(My.Application.ApplicationContext.MainForm, MainForm)

        ' checks if project is open
        If OpenedProject.IsOpened Then

            If mainForm IsNot Nothing Then
                If Ui.YesNoBox.Show("If you would like to open an existing project you must close the current project." & Chr(10) & Chr(10) & "Would you like to close the current project?", MessageBoxIcon.Question) = DialogResult.Yes Then
                    ' does user want to close existing project?
                    For Each frm As Form In mainForm.MdiChildren
                        frm.Close()
                    Next
                    OpenedProject.Manager = Nothing
                    Me.existingProject()
                End If
            Else
                Ui.MessageBox.Show(Strings.ProjectAlreadyOpen, MessageBoxIcon.Information)
            End If

        Else
            If ProjectIDStr = "" Then
                Me.existingProject()
            Else
                Me.setProjectManager(ProjectIDStr)
            End If
        End If

        If mainForm IsNot Nothing Then
            If OpenedProject.IsOpened Then
                'mainForm.CheckInToolStripButton.Text = "Check In (" & OpenedProject.Manager.Project.Name & ")"
                'mainForm.CheckOutToolStripButton.Text = "Check Out (" & OpenedProject.Manager.Project.Name & ")"
            Else
                'mainForm.CheckInToolStripButton.Text = "Check In"
                'mainForm.CheckOutToolStripButton.Text = "Check Out"
            End If
            mainForm = Nothing
        End If

    End Sub

    Public Sub OpenExistingProject(ByVal projectID As String)

        If Trim(projectID) > " " Then
            ' sets project manager based on ID
            Me.setProjectManager(projectID)
        End If

    End Sub

    ''' <summary>Creates an existing box load</summary>
    Sub CreateBoxLoad(boxLoad As BoxLoad)
        If OpenedProject.IsOpened Then
            OpenedProject.Manager.BoxLoads.Add(boxLoad)
        Else
            Ui.MessageBox.Show("Box load cannot be created. There is no project opened.")
        End If
    End Sub


    Function GetProject(projectId As String) As project_manager
        Dim project As ProjectItem = ProjectsDataAccess.Retrieve(projectId)
        Dim projectMgr As project_manager = New project_manager(project)

        ' retrieves project's equipment
        Dim equipmentTable As DataTable = EquipmentDa.RetrieveByProject(projectId)
        For i As Integer = 0 To equipmentTable.Rows.Count - 1
            Dim id = equipmentTable.Rows(i)(Col.EquipmentId).ToString
            Dim equip = EquipmentDa.Retrieve(id)
            projectMgr.Equipment.Add(equip)

            ' blargg - dakotal
            Console.Write(equip.pricing.warranty)

            'Dim oda As OptionsDataAccess
            'Dim op = oda.RetrieveOption(equip.series, equip.model, "FYCW", CInt(equip.common_specs.ControlVoltage.ToString()), 0, 0)
            'Console.Write(op.Price)


            If equip.type = EquipmentType.CondensingUnit Then
                If equip.pricing.warranty <> 0 Then
                    Dim warrantyDB = OptionsDA.GetCompressorWarrantyCost(equip.series, equip.model_without_series) * equip.pricing.quantity
                    If (equip.pricing.warranty <> warrantyDB) Then updateWarrantyPrice(equip.id.ToString(), warrantyDB)
                End If
            End If

        Next

        ' retrieves project's selections and ratings and balances
        Dim processTable As DataTable = DataAccess.Projects.ProcessItemDA.RetrieveByProject(projectId)
        For j As Integer = 0 To processTable.Rows.Count - 1
            Dim p1 = DataAccess.Projects.ProcessItemDA.Retrieve(processTable.Rows(j)("ProcessId").ToString, processTable.Rows(j)("DataTableName").ToString)
            If p1 Is Nothing Then
                Return Nothing
            Else
                projectMgr.Processes.Add(p1)

            End If
        Next

        Dim da As New BoxLoadProjects()
        Dim itemIds As List(Of String) = da.ItemIds(projectId)
        For Each itemId As String In itemIds
            Dim b As New BoxLoad()
            b.id = New item_id(itemId)
            b.Load()
            projectMgr.BoxLoads.Add(b)
        Next

        Return projectMgr
    End Function



#Region " Private"

    Private Sub updateWarrantyPrice(ByVal equipmentID As String, ByVal warranty As Double)
        Dim sql = "UPDATE Equipment SET WarrantyPrice = @warranty WHERE EquipmentID = @id"
        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand

        Dim warrantyP = New OleDbParameter("@warranty", OleDbType.VarChar)
        warrantyP.Value = warranty
        command.Parameters.Add(warrantyP)
        Dim id = New OleDbParameter("@id", OleDbType.VarChar)
        id.Value = equipmentID
        command.Parameters.Add(id)

        command.CommandText = sql

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Catch ex As Exception
            Console.Write(ex.Message)
        Finally
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try
    End Sub

    Private Function create_pricing_from_rating(process As ProcessItem, name As String) As EquipmentItemList
        Dim unit As Object = Nothing

        If TypeOf process Is EvaporativeCondenserChillerBalance _
        Or TypeOf process Is WCChillerProcessItem _
        Or TypeOf process Is ACChillerProcessItem Then
            unit = New chiller_equipment(process, name)
        ElseIf TypeOf process Is CondenserProcessItem Then
            unit = New CondenserEquipmentItem(process, name)
        ElseIf TypeOf process Is CondensingUnitProcessItem Then
            unit = New CondensingUnitEquipmentItem(process, name)
        End If

        If unit IsNot Nothing Then
            OpenedProject.Manager.Equipment.Add(unit)
            OpenedProject.Manager.Equipment.Items(unit.Id).Save()
            Dim units = New EquipmentItemList()
            units.Add(unit)
            Return units
        ElseIf TypeOf process Is cu_uc_balance_screen_model Then
            Dim balance = CType(process, cu_uc_balance_screen_model)

            Dim units = New EquipmentItemList()

            Dim condensing_unit = New CondensingUnitEquipmentItem(process)
            units.Add(condensing_unit)
            OpenedProject.Manager.Equipment.Add(condensing_unit)
            OpenedProject.Manager.Equipment.Items(condensing_unit.id).Save()

            Dim defrost_types = New which_defrost_type().ask(balance.selected_unit_coolers)

            If balance.selected_unit_coolers.Count > 0 Then
                Dim unit_cooler = balance.selected_unit_coolers(0)

                ' unit_cooler.capacity *= balance.condensing_unit_quantity

                unit_cooler.model = balance.selected_unit_coolers(0).model & "-" & defrost_types(0)

                unit = New unit_cooler(balance, unit_cooler, name)
                units.Add(unit)
                OpenedProject.Manager.Equipment.Add(unit)
                OpenedProject.Manager.Equipment.Items(unit.id).save()
            Else
                Throw New Exception("There must be at lease one unit cooler selected.")
            End If
            If balance.selected_unit_coolers.Count > 1 Then
                Dim unit_cooler = balance.selected_unit_coolers(1)


                '   unit_cooler.capacity *= balance.condensing_unit_quantity
                unit_cooler.model = balance.selected_unit_coolers(1).model & defrost_types(1)

                Dim uc2 = New unit_cooler(balance, unit_cooler, "Unit Cooler 2")
                units.Add(uc2)
                OpenedProject.Manager.Equipment.Add(uc2)
                OpenedProject.Manager.Equipment.Items(uc2.id).Save()
            End If
            If balance.selected_unit_coolers.Count > 2 Then
                Dim unit_cooler = balance.selected_unit_coolers(2)

                '  unit_cooler.capacity *= balance.condensing_unit_quantity
                unit_cooler.model = balance.selected_unit_coolers(2).model & defrost_types(2)

                Dim uc3 = New unit_cooler(balance, unit_cooler, "Unit Cooler 3")
                units.Add(uc3)
                OpenedProject.Manager.Equipment.Add(uc3)
                OpenedProject.Manager.Equipment.Items(uc3.id).Save()
            End If

            Return units
        Else
            Rae.Ui.alert("Unable to create equipment item.")
        End If
    End Function


    Private Function convertToEquipmentType(ByVal Process_Type As ProcessType) As EquipmentType

        Select Case Process_Type

            Case ProcessType.AirCooledChiller, ProcessType.EvaporativeCondenserChiller ', ProcessType.WCChiller
                Return EquipmentType.Chiller

            Case ProcessType.Condenser
                Return EquipmentType.Condenser

            Case ProcessType.CondensingUnit
                Return EquipmentType.CondensingUnit

            Case ProcessType.UnitCoolerBalance
                Return EquipmentType.UnitCooler

            Case Else
                Return Nothing

        End Select

    End Function


    Private Function convertToEquipmentType(Process_Item As ProcessItem) As EquipmentType

        If TypeOf Process_Item Is ACChillerProcessItem Then
            Return EquipmentType.Chiller

        ElseIf TypeOf Process_Item Is WCChillerProcessItem Then
            Return EquipmentType.Chiller

        ElseIf TypeOf Process_Item Is EvaporativeCondenserChillerBalance Then
            Return EquipmentType.Chiller

        ElseIf TypeOf Process_Item Is CondenserProcessItem Then
            Return EquipmentType.Condenser

        ElseIf TypeOf Process_Item Is CondensingUnitProcessItem Then
            Return EquipmentType.CondensingUnit

        ElseIf TypeOf Process_Item Is cu_uc_balance_screen_model Then
            Return EquipmentType.UnitCooler

        Else
            Return Nothing

        End If

    End Function


    Private Sub existingProject()
        Dim frmOpenProject As New OpenProjectForm()
        Dim result As DialogResult

        ' prompts user to select project to open from a list
        result = frmOpenProject.ShowDialog()

        If result = DialogResult.OK Then
            ' gets id of selected project
            Dim projectId As String = frmOpenProject.projectName.Tag.ToString()

            ' sets project manager based on ID
            Me.setProjectManager(projectId)
        End If
    End Sub


    ''' <summary>Sets project manager based on project ID.</summary>
    ''' <param name="projectId">ID of project to create a new project manager for.</param>
    Private Sub setProjectManager(projectId As String)
        Dim controller As New ContactUpdateController(New item_id(projectId))
        If controller.Check() = ContactDataStructureDescription.NamesOnly Then
            If controller.StartConversionWizard() = Outcome.Failed Then
                Exit Sub
            End If
        End If

        ' checks if a project is already opened
        If OpenedProject.IsOpened Then
            Me.messageProjectIsOpen() : Exit Sub
        End If

        Dim projectMgr As project_manager = GetProject(projectId)
        If projectMgr Is Nothing Then Exit Sub

        ' sets project manager
        OpenedProject.Manager = projectMgr
    End Sub


    Private Sub messageProjectIsOpen()
        Ui.MessageBox.Show(Strings.ProjectAlreadyOpen, MessageBoxIcon.Information)
    End Sub


    Private Function getProjectNameFromUser() As String
        Dim newProjectForm As New NewItemForm2
        newProjectForm.NewItem(NewItemForm2.NewItemType.ProjectOnly)
        newProjectForm.ShowDialog()
        If newProjectForm.IsValid Then
            Return newProjectForm.ProjectName.Trim()
        Else
            Return Nothing
        End If
    End Function


    Private Sub createNewProject()
        If OpenedProject.IsOpened Then

            Dim mainForm As MainForm = CType(My.Application.ApplicationContext.MainForm, MainForm)

            If mainForm IsNot Nothing Then
                If Ui.YesNoBox.Show("If you would like to create a new project you must close the current project." & Chr(10) & Chr(10) & " Do you want to close the current project?", MessageBoxIcon.Question) = DialogResult.Yes Then
                    ' does user want to close existing project?
                    For Each frm As Form In mainForm.MdiChildren
                        frm.Close()
                    Next
                    OpenedProject.Manager = Nothing

                    Dim projectName As String
                    projectName = Me.getProjectNameFromUser()
                    If projectName IsNot Nothing Then
                        OpenedProject.Manager = New project_manager(projectName, AppInfo.User.username, AppInfo.User.password)
                        OpenedProject.Manager.Project.Save()
                    End If

                End If
            Else
                Me.messageProjectIsOpen()
            End If

            mainForm = Nothing

        Else
            Dim projectName As String
            projectName = Me.getProjectNameFromUser()
            If projectName IsNot Nothing Then
                OpenedProject.Manager = New project_manager(projectName, AppInfo.User.username, AppInfo.User.password)
                OpenedProject.Manager.Project.Save()
            End If
        End If
    End Sub


    Private Sub createNewEquipment()
        Dim unknownTypeForm As New NewUnknownTypePricingForm()

        ' asks user what the equipment type should be
        unknownTypeForm.ShowDialog()

        ' did user click view
        If unknownTypeForm.DialogResult = DialogResult.OK Then
            ' opens equipment form
            ProjectInfo.Viewer.ViewEquipment(unknownTypeForm.EquipmentType)
        Else
            ' user cancelled new equipment
        End If
        ' closes form
        unknownTypeForm.Close()
    End Sub


    Private Function createNewProcess(ByVal Process_Type As ProcessType, Optional ByVal process As ProcessItem = Nothing) As ProcessItem

        Dim frmNewProcess As New NewItemForm2
        frmNewProcess.getProcessType = Me.m_GetProcessType
        frmNewProcess.NewItem(NewItemForm2.NewItemType.SelectionOnly, Process_Type)
        frmNewProcess.ShowDialog()
        If Process_Type = ProcessType.NA Then
            Process_Type = frmNewProcess.ProcessType
        End If

        If frmNewProcess.IsValid Then
            ' Create process if necessary...
            If process Is Nothing Then
                process = constructProcess(frmNewProcess.SelectionName, _
                                           Process_Type)
            Else
                process.ProjectManager = OpenedProject.Manager
                process.name = frmNewProcess.SelectionName
                process.Division = AppInfo.Division
                process.Revision = Rae.RaeSolutions.DataAccess.Projects.ProjectsDataAccess.RetrieveLatestRevision(OpenedProject.Manager.Project.id.Id) + 0.001
            End If
            OpenedProject.Manager.Processes.Add(process)
            OpenedProject.Manager.Processes.Items(process.id).Save()
            frmNewProcess.Close()
            Return process

        Else
            Return Nothing
        End If

    End Function


    ''' <summary>
    ''' Constructs process item.
    ''' </summary>
    ''' <param name="name">Process name.</param>
    ''' <param name="id">Process ID.</param>
    ''' <param name="type">Process type.</param>
    ''' <returns>Constructed process.</returns>
    Private Function constructProcess(ByVal name As String, ByVal [type] As ProcessType) As ProcessItem
        Dim process As ProcessItem

        Select Case [type]
            Case ProcessType.AirCooledChiller
                process = New ACChillerProcessItem(name, AppInfo.User.username, AppInfo.User.password, OpenedProject.Manager)
            Case ProcessType.Condenser
                process = New CondenserProcessItem(name, AppInfo.User.username, AppInfo.User.password, OpenedProject.Manager)
            Case ProcessType.CondensingUnit
                process = New CondensingUnitProcessItem(name, AppInfo.User.username, AppInfo.User.password, OpenedProject.Manager)
            Case ProcessType.EvaporativeCondenserChiller
                process = New EvaporativeCondenserChillerBalance(name, AppInfo.User.username, AppInfo.User.password, OpenedProject.Manager)
            Case ProcessType.UnitCoolerBalance
                process = New cu_uc_balance_screen_model(name, AppInfo.User.username, AppInfo.User.password, OpenedProject.Manager)
                'Case ProcessType.WCChiller
                '   process = New WCChillerProcessItem(name, AppInfo.User.Username, AppInfo.User.Password, OpenedProject.Manager)
            Case Else
                Throw New ArgumentException("Attempt to construct process failed. The process type, '" & [type].ToString & "', is not valid.")
        End Select

        If Not IsNothing(process) Then
            process.Division = Rae.RaeSolutions.AppInfo.Division
            process.Revision = Rae.RaeSolutions.DataAccess.Projects.ProjectsDataAccess.RetrieveLatestRevision(OpenedProject.Manager.Project.id.Id) + 0.001
        End If

        Return process
    End Function

#End Region

End Class
'545 on 9/7/2006

'Public Function CreateEquipmentAndProject() As String

'   Dim frmNewItem As New NewItemForm2
'   frmNewItem.NewItem(NewItemForm.NewItemType.EquipmentAndProject)

'   frmNewItem.ShowDialog()

'   If frmNewItem.IsValid Then

'      ' Create new project...
'      OpenedProject.Manager = New ProjectManager(frmNewItem.ProjectName, AppInfo.User.Username, AppInfo.User.Password)

'      ' We're creating multiple items in one go - we
'      ' need to force a 1 second wait to avoid duplicate
'      ' item IDs...
'      System.Threading.Thread.CurrentThread.Sleep(1000)

'      If OpenedProject.IsOpened Then

'         Dim equipment As EquipmentItem
'         equipment = ConstructEquipment( _
'            frmNewItem.EquipmentName, _
'            New ItemId(AppInfo.User.Username, AppInfo.User.Password).Id, _
'            frmNewItem.EquipmentType, _
'            frmNewItem.Division)

'         OpenedProject.Manager.Equipment.Add(equipment)
'         OpenedProject.Manager.Equipment.Items(equipment.Id).Save()

'         frmNewItem.Close()

'         Return frmNewItem.EquipmentName

'      Else

'         Return ""

'      End If

'   Else

'      Return ""

'   End If

'End Function
