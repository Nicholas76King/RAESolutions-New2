Imports Rae.RaeSolutions.Business
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.DataAccess.Projects
Imports rae.solutions

''' <summary>Item viewer views items in project.</summary>
Class ItemViewer

   ''' <summary>Constructs viewer to view items in project such as equipment and project info.</summary>
   ''' <param name="mdiParent">MDI parent form.</param>
   Sub New(mdiParent As Form)
      Me.m_mdiParent = mdiParent
   End Sub

   Private m_mdiParent As Form

   ''' <summary>MDI (Multiple Document Interface) parent form.</summary>
   ReadOnly Property mdi_parent As Form
      Get
         Return Me.m_mdiParent
      End Get
   End Property


   ''' <summary>True if item is opened; else false.</summary>
   ''' <param name="id">ID of the item being tested.</param>
   Function IsViewed(id As String) As Boolean
      For Each cform As Form In m_mdiParent.MdiChildren
         If cform.Tag = id Then
            Return True
         End If
      Next
      Return False
   End Function


   ''' <summary>Focuses on item with the ID. Returns item's form that was focused on. If item is not open, null is returned.</summary>
   ''' <param name="id">ID of the item to focus on.</param>
   Function Focus(id As String) As Form
      For Each form As Form In m_mdiParent.MdiChildren
         If form.Tag = id Then
            form.Focus() : Return form
         End If
      Next
      Return Nothing
   End Function


   ''' <summary>
   ''' Closes form with the ID.  Returns 1 if a form was closed
   ''' </summary>
   ''' <param name="id">
   ''' ID of the item to focus on.
   ''' </param>
   Function CloseForm(id As String) As Integer
      For Each form As Form In m_mdiParent.MdiChildren
         If form.Tag = id Then
            Dim tmpobj As Object = form
            Try
               tmpobj.ProcessDeleted = True
               tmpobj = Nothing
            Catch ex As Exception

            End Try
            form.Close() : Return 1
         End If
      Next
      Return Nothing
   End Function


   ''' <summary>
   ''' closes all CHILD forms in project
   ''' </summary>
   ''' <remarks></remarks>
   Sub CloseAllForms()
      For Each form As Form In m_mdiParent.MdiChildren
         form.Close()
      Next
   End Sub


   ''' <summary>
   ''' Gets the form related to the item with the ID. If the item is not open then null is returned.
   ''' </summary>
   ''' <param name="id">
   ''' ID of the item being searched for.
   ''' </param>   
   Function GetView(id As String) As Form
      For Each form As Form In m_mdiParent.MdiChildren
         If form.Tag = id Then
            Return form
         End If
      Next
      Return Nothing
   End Function


   ''' <summary>
   ''' Opens the project for viewing, or if it is already open, focuses on project. Returns form that was opened.
   ''' </summary>
   ''' <param name="project">
   ''' Project to view.
   ''' </param>
   Function ViewProject(project As ProjectItem) As ProjectForm
      If IsViewed(project.id.Id) Then
         Return Focus(project.id.Id)
      Else
         Dim frmProject As New ProjectForm

         frmProject.Tag = project.id.Id
         frmProject.Text = project.name
         frmProject.MdiParent = Me.m_mdiParent
         frmProject.ProjectOwner = project.ProjectOwner

         frmProject.Show()

         frmProject.Open(OpenedProject.Manager.Project.Clone())

         Return frmProject
      End If
   End Function


   ''' <summary>Opens the equipment for viewing or focuses equipment, if it is already open. Returns form viewed.</summary>
   ''' <param name="equipment">Equipment to view.</param>
    Function ViewEquipment(ByVal equipment As EquipmentItem, ByVal latestRev As Boolean, ByVal generateReportOnly As Boolean, ByRef ReportFileName As String, Optional ByVal showReport As Boolean = False, Optional ByVal logo As String = "") As Form
        Dim equipForm As EquipmentForm

        ' make sure to retrieve latest revision...
        If latestRev Then equipment.revision = DataAccess.Projects.EquipmentDa.RetrieveLatestRevision(equipment.id.Id)

        ' is the form already being viewed
        If IsViewed(equipment.id.Id) Then
            ' focuses on form (brings to front)
            equipForm = Focus(equipment.id.Id)

            ' has revision changed since last viewed
            If equipment.revision <> equipForm.Equipment.revision Then
                Dim equipClone As EquipmentItem = Rae.reflection.MethodInvoker.InvokeMethod(Of EquipmentItem)(equipment, "Clone")
                ' initializes form
                Me.InitializeEquipmentForm(equipClone, equipForm)
                ' sets control values to equipment values
                equipForm.Open(equipClone)
            End If
        Else
            Select Case equipment.type
                Case EquipmentType.PumpPackage
                    equipForm = New pump_package_pricing_screen()
                Case EquipmentType.Chiller
                    equipForm = New chiller_pricing_screen()
                Case EquipmentType.FluidCooler
                    equipForm = New fluid_cooler_pricing_screen()
                Case EquipmentType.UnitCooler
                    equipForm = New unit_cooler_pricing_screen()
                Case EquipmentType.Condenser
                    equipForm = New condenser_pricing_screen()
                Case EquipmentType.CondensingUnit
                    equipForm = New condensing_unit_pricing_screen
                Case EquipmentType.ProductCooler
                    equipForm = New product_cooler_pricing_screen
                Case Else
                    equipForm = New EquipmentForm
            End Select

            Dim equipClone = Rae.reflection.MethodInvoker.InvokeMethod(Of EquipmentItem)(equipment, "Clone")

            Me.InitializeEquipmentForm(equipClone, equipForm)



            equipForm.Show()

            If generateReportOnly Then equipForm.WindowState = FormWindowState.Minimized

            ' sets control values to equipment values
            equipForm.Open(equipClone)


        End If


        If generateReportOnly And showReport = False Then

            equipForm.onViewOrderWriteUp(True, ReportFileName)

        End If

        If showReport Then

            equipForm.onViewOrderWriteUp(True, ReportFileName, True, logo)

        End If


        Return equipForm
    End Function

   ''' <summary>Views new equipment with specified equipment type.</summary>
   ''' <param name="type">Type of equipment to view.</param>
   ''' <returns>The equipment form that is viewed.</returns>
   Function ViewEquipment(type As Business.EquipmentType) As Form
      ' creates new equipment with a new project manager
      Dim equipment = EquipmentFactory.CreateEquipment( _
         "Untitled", AppInfo.User.username, AppInfo.User.password, type, AppInfo.Division)

        ' views equipment w/out an opened project
        Dim junk As String = ""

        Dim equipmentForm = Me.ViewEquipment(equipment, False, False, junk)

      Return equipmentForm
   End Function


   ''' <summary>Views the equipment at a specified revision.</summary>
   ''' <param name="equipment">Equipment to view at a different revision.</param>
   ''' <param name="revisionToView">Revision to view.</param>
   ''' <returns>Equipment at the specified revision</returns>
   Function ViewEquipmentRevision(equipment As EquipmentItem, revisionToView As Single) As EquipmentForm
      Dim equipmentToView As EquipmentItem
      Dim equipmentForm As EquipmentForm

      ' gets equipment at revision to display
      equipmentToView = EquipmentDa.Retrieve(equipment.id, revisionToView)

      ' if revision to display does not exist
      If equipmentToView Is Nothing Then
         Ui.MessageBox.Show("Equipment does not exist at revision " & revisionToView.ToString & ".")
      Else
            ' views equipment at specified revision
            Dim junk As String = ""

            equipmentForm = ProjectInfo.Viewer.ViewEquipment(equipmentToView, False, False, junk)
      End If

      Return equipmentForm
   End Function


   ''' <summary>
   ''' True if active form is a valid equipment or process form; else false.
   ''' </summary>
   Function ActiveItemIsValid() As Boolean
      Dim isValid As Boolean

      If TypeOf Me.GetActiveForm() Is EquipmentForm Then
         ' assumes is not nothing
         isValid = True
      Else
         Try
            If Me.GetActiveProcess IsNot Nothing Then
               isValid = True
            End If
         Catch ex As Exception
            isValid = False
         End Try
      End If

      Return isValid
   End Function


   Function GetActiveForm() As Form
      Return m_mdiParent.ActiveMdiChild
   End Function


   ''' <summary>Get specified revision of ProcessItem</summary>
   ''' <param name="Revision_To_Display">Optional (Blank returns current revision)</param>
   ''' <returns>ProcessItem</returns>
   Function DisplayRevision(process As ProcessItem, Optional ByVal Revision_To_Display As Single = -1) As ProcessItem

      Dim ProcessRetrieved As ProcessItem
      Dim ActiveForm As Object

      If TypeOf process Is EvaporativeCondenserChillerBalance Then
         Dim ECChillDA As EvaporativeCondenerChillerBalanceDa
         ProcessRetrieved = EvaporativeCondenerChillerBalanceDa.Retrieve(process.id, Revision_To_Display)

      ElseIf TypeOf process Is WCChillerProcessItem Then
         Dim WCChillDA As WCChillerProcessDA
         ProcessRetrieved = WCChillerProcessDA.Retrieve(process.id, Revision_To_Display)

      ElseIf TypeOf process Is ACChillerProcessItem Then
         Dim ACChillDA As ACChillerProcessDA
         ProcessRetrieved = ACChillerProcessDA.Retrieve(process.id, Revision_To_Display)

      ElseIf TypeOf process Is CondenserProcessItem Then
         Dim CondenserDA As CondenserProcessDA
         ProcessRetrieved = CondenserDA.Retrieve(process.id, Revision_To_Display)

      ElseIf TypeOf process Is CondensingUnitProcessItem Then
         ' RELEASE: should this be CondensingUnitProcessDa
         Dim CondensingUnitDA As CondensingUnitProcessDA
         ProcessRetrieved = CondensingUnitDA.Retrieve(process.id, Revision_To_Display)

      ElseIf TypeOf process Is cu_uc_balance_screen_model Then
         Dim UnitCoolerDA As UnitCoolerProcessDA
         ProcessRetrieved = UnitCoolerDA.Retrieve(process.id, Revision_To_Display)

      ElseIf TypeOf process Is FluidCoolerProcessItem Then
         ProcessRetrieved = FluidCoolerProcessItem.PopulateRevision(process.id.Id, Revision_To_Display)

      End If

      ' If nothing was returned then try to get the
      ' latest revision (if one exists)...
      If IsNothing(ProcessRetrieved) And Revision_To_Display > -1 Then

         ' Get latest revision...
         DisplayRevision(process)

         ' If we successfully retrieved current revision
         ' notify user that we are defaulting to the
         ' latest revision.
         If ProcessRetrieved IsNot Nothing Then
            Ui.MessageBox.Show("Revision not found.  Defaulting to latest revision.", _
                                    MessageBoxIcon.Information)
            ' Load form controls.
            ActiveForm = GetActiveForm()
            ActiveForm.loadcontrols(ProcessRetrieved)
         End If

      Else

         ' Load form controls.
         ActiveForm = GetActiveForm()
         ActiveForm.OPEN(ProcessRetrieved)

      End If

      Return ProcessRetrieved

   End Function


   ''' <summary>Opens the process for viewing or focuses process, if it is already open. Returns form viewed.</summary>
   ''' <param name="process">Process to view.</param>
   Function ViewProcess(process As ProcessItem) As Form
      Dim ProcessForm As Object

        If TypeOf process Is cu_uc_balance_screen_model Then

            '       RepairUCProcess(process)

            ProcessForm = cu_uc_balance_window
            If Not IsViewed(process.id.Id) Then
                ProcessForm = New cu_uc_balance_window
            End If

        ElseIf TypeOf process Is CondenserProcessItem Then
            ProcessForm = condenser_rating_screen
            If Not IsViewed(process.id.Id) Then
                ProcessForm = New condenser_rating_screen
            End If

        ElseIf TypeOf process Is CondensingUnitProcessItem Then
            ProcessForm = condensing_unit_rating_screen
            If Not IsViewed(process.id.Id) Then
                ProcessForm = New condensing_unit_rating_screen
            End If

        ElseIf TypeOf process Is EvaporativeCondenserChillerBalance Then
            'frmEvapCooledRep not used
            '
            If AppInfo.User.authority_group = user_group.rep Then
                ProcessForm = evaporative_condenser_chiller_balance_window
                If Not IsViewed(process.id.Id) Then
                    ProcessForm = New evaporative_condenser_chiller_balance_window
                End If
            ElseIf AppInfo.User.authority_group = user_group.employee Then
                ProcessForm = evaporative_condenser_chiller_balance_window
                If Not IsViewed(process.id.Id) Then
                    ProcessForm = New evaporative_condenser_chiller_balance_window
                End If
            End If

        ElseIf TypeOf process Is ACChillerProcessItem Then
            If AppInfo.User.authority_group = user_group.rep Then
                ProcessForm = RepAirCooledChillerForm
                If Not IsViewed(process.id.Id) Then
                    ProcessForm = New RepAirCooledChillerForm
                End If
            ElseIf AppInfo.User.authority_group = user_group.employee Then
                ProcessForm = air_cooled_chiller_balance_window
                If Not IsViewed(process.id.Id) Then
                    ProcessForm = New air_cooled_chiller_balance_window
                End If
            End If

            'ElseIf TypeOf process Is WCChillerProcessItem Then
            '   ProcessForm = ChillerWaterCooledForm
            '   If Not IsViewed(process.Id.Id) Then
            '      ProcessForm = New ChillerWaterCooledForm
            '   End If

        ElseIf TypeOf process Is FluidCoolerProcessItem AndAlso user_group.employee Then
            ProcessForm = FluidCoolerForm
            If Not IsViewed(process.id.Id) Then
                ProcessForm = New FluidCoolerForm
            End If
        End If

      ' Show the form...
      If IsViewed(process.id.Id) Then
         ' Form is already up - put focus on it...
         ProcessForm = Focus(process.id.Id)
      Else
         ' Create new form with process item data...
         ProcessForm.Tag = process.id.Id
         ProcessForm.Text = process.name
         ProcessForm.MdiParent = Me.m_mdiParent
         ProcessForm.Show()
         ProcessForm.Open(process)
         Return ProcessForm
      End If


   End Function


   ''' <summary>Opens the process for viewing or focuses process, if it is already open. Returns form viewed.</summary>
   ''' <param name="type">Process type to view.</param>
   Function ViewProcess(type As Rae.RaeSolutions.Business.ProcessType) As Form

      Dim frm As Form

      Select Case type

         Case Business.ProcessType.AirCooledChiller
            frm = New air_cooled_chiller_balance_window
            If AppInfo.User.authority_group = user_group.rep Then frm = New RepAirCooledChillerForm

         Case Business.ProcessType.Condenser
            frm = New condenser_rating_screen

         Case Business.ProcessType.CondensingUnit
            frm = New condensing_unit_rating_screen

         Case Business.ProcessType.EvaporativeCondenserChiller
            frm = New evaporative_condenser_chiller_balance_window
            'If AppInfo.User.AuthorityGroup = UserGroup.Rep Then frm = New frmEvapCooledRep

         Case Business.ProcessType.UnitCoolerBalance
            frm = New cu_uc_balance_window

         'Case Business.ProcessType.WCChiller
            'frm = New ChillerWaterCooledForm

         Case Else
            frm = Nothing

      End Select

      If Not IsNothing(frm) Then frm.Show()

      Return frm

   End Function


   ''' <summary>
   ''' Gets the child form that has focus.  We'll use 
   ''' form.tag (has ID if set) to cross reference ID 
   ''' to a process.
   ''' </summary>
   ''' <param name="id">
   ''' ID of the item being searched for.
   ''' </param>   
   Function GetActiveProcess() As ProcessItem
      Dim ActiveProcessDA As ProcessItemDA
      Dim ActiveForm As Form = GetActiveForm()
      If Not IsNothing(ActiveForm) Then
         If Trim(ActiveForm.Tag) > "" Then
            Dim activeProcess = ActiveProcessDA.Retrieve(ActiveForm.Tag)
            Return activeProcess
         End If
      End If
      Return Nothing
   End Function





   ''' <summary>Initializes equipment form before viewing.</summary>
   ''' <param name="equipment">Equipment to initialize with.</param>
   ''' <param name="frmEquipment">Equipment form to initialize</param>
   Private Sub InitializeEquipmentForm(equipment As EquipmentItem, frmEquipment As EquipmentForm)
      frmEquipment.Tag = equipment.id.Id
      frmEquipment.Text = equipment.name
      frmEquipment.Equipment = equipment
      frmEquipment.MdiParent = Me.m_mdiParent
   End Sub
   
   Function ViewBoxLoad() As Form
      Dim form As New frmboxloadcalc2()
      form.MdiParent = Me.mdi_parent
      form.Name = "Untitled"
      form.Show()
      
      Return form
   End Function

   sub view(of t as form)()
      dim screen = rae.reflection.reflector.construct(of t)()
      screen.mdiParent = mdi_parent
      screen.name = "Untitled"
      
      dim controller as object
      if typeOf(screen) is unit_cooler_selection_screen then
         controller = new unit_cooler_selection.controller(screen)
      end if
      screen.show()
   end sub

   
   Function ViewBoxLoad(itemId As String) As Form
      Dim form As frmboxloadcalc2
      
      If Me.IsViewed(itemId) Then
         form = Focus(itemId)
      Else
         Dim item As New BoxLoad(New item_id(itemId), OpenedProject.Manager)
         item.Load()
         
         form = New frmboxloadcalc2()
         initialize(form, item)
         'TODO: is this necessary
         form.BoxLoad = item
         form.Show()
         form.BoxLoad = item
      End If
      
      Return form
   End Function
   
   Private Sub initialize(form As Form, item As ItemBase)
      form.Tag = item.id.ToString()
      form.Text = item.name
      form.MdiParent = Me.mdi_parent
   End Sub

End Class