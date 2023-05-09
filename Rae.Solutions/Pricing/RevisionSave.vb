Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.DataAccess.Projects

Public Class RevisionSave

   Public Enum Save_Type
      Save
      Revision
      NewItem
   End Enum

   Private m_LastSavedProcess As ProcessItem
   ''' <summary>
   ''' LastSavedProcess
   ''' </summary>
   Public Property LastSavedProcess() As ProcessItem
      Get
         Return Me.m_LastSavedProcess
      End Get
      Set(ByVal value As ProcessItem)
         Me.m_LastSavedProcess = value
      End Set
   End Property

   Private m_CurrentProcess As ProcessItem
   ''' <summary>
   ''' CurrentProcess
   ''' </summary>
   Public ReadOnly Property CurrentProcess() As ProcessItem
      Get
         Return Me.m_CurrentProcess
      End Get
   End Property

   Private m_LastSavedEquipment As EquipmentItem
   ''' <summary>
   ''' LastSavedEquipment
   ''' </summary>
   Public Property LastSavedEquipment() As EquipmentItem
      Get
         Return Me.m_LastSavedEquipment
      End Get
      Set(ByVal value As EquipmentItem)
         Me.m_LastSavedEquipment = value
      End Set
   End Property

   Private m_CurrentEquipment As EquipmentItem
   ''' <summary>
   ''' CurrentEquipment
   ''' </summary>
   Public ReadOnly Property CurrentEquipment() As EquipmentItem
      Get
         Return Me.m_CurrentEquipment
      End Get
   End Property

   Private m_CallingForm As Object
   ''' <summary>
   ''' CallingForm
   ''' </summary>
   Public ReadOnly Property CallingForm() As Object
      Get
         Return Me.m_CallingForm
      End Get
   End Property


   Private revisionProject_ As Boolean
   Public Property RevisionProject() As Boolean
      Get
         Return revisionProject_
      End Get
      Set(ByVal value As Boolean)
         revisionProject_ = value
      End Set
   End Property


   Private m_SaveType As Save_Type
   ''' <summary>
   ''' SaveType
   ''' </summary>
   Public ReadOnly Property SaveType() As Save_Type
      Get
         Return Me.m_SaveType
      End Get
   End Property

   Private m_FormClosing As Boolean
   ''' <summary>
   ''' FormClosing
   ''' </summary>
   Public ReadOnly Property FormClosing() As Boolean
      Get
         Return Me.m_FormClosing
      End Get
   End Property

   Private m_ProcessType As Rae.RaeSolutions.Business.ProcessType
   ''' <summary>
   ''' ProcessType
   ''' </summary>
   Public ReadOnly Property ProcessType() As Rae.RaeSolutions.Business.ProcessType
      Get
         Return Me.m_ProcessType
      End Get
   End Property

   Private m_GenerateEquipment As Boolean
   ''' <summary>
   ''' GenerateEquipment
   ''' </summary>
   Public ReadOnly Property GenerateEquipment() As Boolean
      Get
         Return Me.m_GenerateEquipment
      End Get
   End Property

   Private m_RevChange As Boolean
   ''' <summary>
   ''' RevChange (fired from revision changed event)
   ''' </summary>
   Public ReadOnly Property RevChange() As Boolean
      Get
         Return Me.m_RevChange
      End Get
   End Property

   Private m_CancelSave As Boolean = False
   ''' <summary>
   ''' CancelSave
   ''' </summary>
   Public ReadOnly Property CancelSave() As Boolean
      Get
         Return Me.m_CancelSave
      End Get
   End Property

   Private m_DoNotSave As Boolean = False
   ''' <summary>
   ''' DoNotSave
   ''' </summary>
   Public ReadOnly Property DoNotSave() As Boolean
      Get
         Return Me.m_DoNotSave
      End Get
   End Property

   'Public Function SetSaveEquipment(ByVal FormSaved As Object, ByVal ProcessType As Rae.RaeSolutions.Business.ProcessType, ByVal CurrentStateEquipment As EquipmentItem, ByVal LastSavedEquipment As EquipmentItem, ByVal SaveAsNew As Boolean, ByVal SaveRevision As Boolean, ByVal FormClosing As Boolean, Optional ByVal GenerateEquipment As Boolean = False, Optional ByVal RevChangeEvent As Boolean = False)
   '   '   Dim CSC As New CoolStuff.CoolStuffCommon

   '   ' Set properties...
   '   Me.m_CallingForm = FormSaved

   '   ' If user wants to save this Equipment as a new
   '   ' Equipment then we need to clone the current
   '   ' Equipment so we can get a new ID, etc...
   '   If SaveAsNew = True Then
   '      If CurrentStateEquipment IsNot Nothing Then
   '         Me.m_CurrentEquipment = CurrentStateEquipment.Clone(True)

   '         ' If SaveAsNew = true user is cloning this
   '         ' object as a new object for use later so we
   '         ' need to create a new ID & set revision to
   '         ' ZERO...
   '         Me.m_CurrentEquipment.Revision = 0
   '         Me.m_CurrentEquipment.Id = New ItemId(AppInfo.User.Username, AppInfo.User.Password)

   '      Else
   '         ' If there is no current Equipment to clone
   '         ' we need to cancel & exit...
   '         m_CancelSave = True
   '         Return m_CurrentEquipment
   '      End If
   '   Else
   '      ' Use current Equipment instead of clone since we
   '      ' are just saving the Equipment (not save as new)
   '      Me.m_CurrentEquipment = CurrentStateEquipment


   '   End If

   '   Me.m_LastSavedEquipment = LastSavedEquipment
   '   If SaveAsNew = True Then
   '      Me.m_SaveType = Save_Type.NewItem
   '   ElseIf SaveRevision = True Then
   '      Me.m_SaveType = Save_Type.Revision
   '   Else
   '      Me.m_SaveType = Save_Type.Save
   '   End If
   '   Me.m_FormClosing = FormClosing
   '   Me.m_ProcessType = ProcessType
   '   Me.m_GenerateEquipment = GenerateEquipment
   '   Me.m_RevChange = RevChangeEvent

   '   ' If user wants to save this Equipment as a new
   '   ' Equipment then reset the LastSavedEquipment and
   '   ' m_CurrentRevision, m_LatestRevision variables...
   '   If Me.m_SaveType = Save_Type.NewItem Then
   '      m_CallingForm.CurrentRevision = 0
   '      m_CallingForm.LatestRevision = 0
   '      m_CallingForm.tag = ""
   '      m_CallingForm.LastSavedEquipment = Nothing
   '      m_LastSavedEquipment = Nothing
   '   End If

   '   If m_LastSavedEquipment IsNot Nothing Then

   '      ' This Equipment has already been saved - we'll
   '      ' clone the current state to the last saved state
   '      ' and update with the current values and compare
   '      ' to determine wheter or not we need to prompt for 
   '      ' revision and save...
   '      If m_CurrentEquipment Is Nothing Then
   '         m_CurrentEquipment = m_LastSavedEquipment.Clone()
   '      End If

   '   Else

   '      ' This Equipment has not yet been saved - we'll
   '      ' need to make sure there is an opened project
   '      ' & tie this Equipment to it...

   '      ' If the form is closing we need to find out if user
   '      ' wants to save or just exit the form...
   '      If m_FormClosing = True Then
   '         If MessageBox.Show("Would you like to save your work?", "Save?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
   '            ' User wants to save...
   '         Else
   '            ' User does not want to save...
   '            m_CancelSave = True
   '            Return m_CurrentEquipment
   '         End If
   '      End If

   '      'Make sure there is an opened project
   '      '& tie this Equipment to it...
   '      If Not OpenedProject.IsOpened Then
   '         ' No project is open - if user wants to
   '         ' save rating they should associate it 
   '         ' with a project for future reference...
   '         ' ProjectInfo.Creator.CreateProject()
   '         If Me.m_GenerateEquipment = True Then
   '            If m_CurrentEquipment Is Nothing Then
   '               m_CurrentEquipment = ProjectInfo.Creator.CreateEquipmentEquipmentAndProject(Me.m_EquipmentType)
   '            Else
   '               m_CurrentEquipment = ProjectInfo.Creator.CreateEquipmentEquipmentAndProject(Me.m_EquipmentType, m_CurrentEquipment)
   '            End If
   '         Else
   '            If m_CurrentEquipment Is Nothing Then
   '               m_CurrentEquipment = ProjectInfo.Creator.CreateEquipmentAndProject(Me.m_EquipmentType)
   '            Else
   '               m_CurrentEquipment = ProjectInfo.Creator.CreateEquipmentAndProject(Me.EquipmentType, Me.m_CurrentEquipment)
   '            End If
   '         End If
   '         If OpenedProject.IsOpened = False Then
   '            Ui.MessageBox.Show("Project must be created.  Equipment not saved.", MessageBoxIcon.Information)
   '            m_CancelSave = True
   '            Return m_CurrentEquipment
   '         End If
   '         If CurrentEquipment Is Nothing Then
   '            ' Equipment item was not created
   '            ' unable to save...
   '            Ui.MessageBox.Show("Unable to save condenser Equipment.", MessageBoxIcon.Information)
   '            m_CancelSave = True
   '            Return m_CurrentEquipment
   '         End If
   '      Else
   '         ' Create a new Equipment - give it a name...
   '         If m_GenerateEquipment = True Then
   '            If m_CurrentEquipment Is Nothing Then
   '               m_CurrentEquipment = ProjectInfo.Creator.CreateEquipmentAndEquipment(Me.m_EquipmentType)
   '            Else
   '               m_CurrentEquipment = ProjectInfo.Creator.CreateEquipmentAndEquipment(Me.m_EquipmentType, m_CurrentEquipment)
   '            End If
   '         Else
   '            If m_CurrentEquipment Is Nothing Then
   '               m_CurrentEquipment = ProjectInfo.Creator.CreateEquipment(Me.m_EquipmentType)
   '            Else
   '               'NEW CONDENSINGUNIT HERE

   '               m_CurrentEquipment = ProjectInfo.Creator.CreateEquipment(Me.m_EquipmentType, m_CurrentEquipment)
   '            End If
   '         End If

   '         If m_CurrentEquipment Is Nothing Then
   '            ' Equipment item was not created
   '            ' unable to save...
   '            Ui.MessageBox.Show("Unable to save condenser Equipment.", MessageBoxIcon.Information)
   '            m_CancelSave = True
   '         End If
   '      End If

   '   End If

   '   If m_CurrentEquipment IsNot Nothing Then
   '      m_CallingForm.tag = m_CurrentEquipment.Id.Id
   '   End If
   '   Return m_CurrentEquipment

   'End Function

   Function SetSaveProcess( _
      FormSaved As Object, _
      ProcessType As Rae.RaeSolutions.Business.ProcessType, _
      CurrentStateProcess As ProcessItem, _
      LastSavedProcess As ProcessItem, _
      SaveAsNew As Boolean, _
      SaveRevision As Boolean, _
      FormClosing As Boolean, _
      Optional GenerateEquipment As Boolean = False, _
      Optional RevChangeEvent As Boolean = False _
   )
      ' Set properties...
      Me.m_CallingForm = FormSaved

      ' NOTE: Commented out because it was telling user that there project was not there's.
      ' If this is NOT the project owner (first person to 
      ' save the project) then we will force a revision save
      ' if this item already exists and collect a reason for
      ' the save
      'If OpenedProject.IsOpened Then
      '   If Rae.RaeSolutions.AppInfo.User.Username <> ProjectInfo.GetProjectOwner(OpenedProject.Manager.Project.Id) Then
      '      Me.RevisionProject = True
      '   Else
      '      Me.RevisionProject = False
      '   End If
      'End If

      ' If user wants to save this process as a new
      ' process then we need to clone the current
      ' process so we can get a new ID, etc...
      If SaveAsNew = True Then
         If CurrentStateProcess IsNot Nothing Then
            Me.m_CurrentProcess = CurrentStateProcess.Clone(True)

            ' If SaveAsNew = true user is cloning this
            ' object as a new object for use later so we
            ' need to create a new ID & set revision to
            ' ZERO...
            Me.m_CurrentProcess.Revision = 0
            Me.m_CurrentProcess.id = New item_id(AppInfo.User.username, AppInfo.User.password)

         Else
            ' If there is no current process to clone
            ' we need to cancel & exit...
            m_CancelSave = True
            Return m_CurrentProcess
         End If
      Else
         ' Use current process instead of clone since we
         ' are just saving the process (not save as new)
         Me.m_CurrentProcess = CurrentStateProcess
      End If

      Me.m_LastSavedProcess = LastSavedProcess
      If SaveAsNew = True Then
         Me.m_SaveType = Save_Type.NewItem
      ElseIf SaveRevision = True Then
         Me.m_SaveType = Save_Type.Revision
      Else
         Me.m_SaveType = Save_Type.Save
      End If
      Me.m_FormClosing = FormClosing
      Me.m_ProcessType = ProcessType
      Me.m_GenerateEquipment = GenerateEquipment
      Me.m_RevChange = RevChangeEvent

      ' If user wants to save this process as a new
      ' process then reset the LastSavedProcess and
      ' m_CurrentRevision, m_LatestRevision variables...
      If Me.m_SaveType = Save_Type.NewItem Then
         m_CallingForm.CurrentRevision = 0
         m_CallingForm.LatestRevision = 0
         m_CallingForm.tag = ""
         m_CallingForm.LastSavedProcess = Nothing
         m_LastSavedProcess = Nothing
      End If

      If m_LastSavedProcess IsNot Nothing Then

         ' This process has already been saved - we'll
         ' clone the current state to the last saved state
         ' and update with the current values and compare
         ' to determine wheter or not we need to prompt for 
         ' revision and save...
         If m_CurrentProcess Is Nothing Then
            m_CurrentProcess = m_LastSavedProcess.Clone()
         End If

      Else

         ' This process has not yet been saved - we'll
         ' need to make sure there is an opened project
         ' & tie this process to it...

         ' If the form is closing we need to find out if user
         ' wants to save or just exit the form...
         If m_FormClosing = True Then
            Select Case MessageBox.Show("Would you like to save your work?", "Save?", MessageBoxButtons.YesNoCancel)
               Case DialogResult.Yes
                  'user wants to save...
               Case DialogResult.No
                  'user does not want to save...
                  m_CancelSave = True
                  Return m_CurrentProcess
               Case DialogResult.Cancel
                  'user wants to cancel action...
                  m_CancelSave = True
                  Return Nothing
            End Select
         End If

         ' Make sure there is an opened project
         ' & tie this process to it...
         If Not OpenedProject.IsOpened Then
            ' No project is open - if user wants to
            ' save rating they should associate it 
            ' with a project for future reference...
            ' ProjectInfo.Creator.CreateProject()

            If Me.m_CurrentProcess IsNot Nothing Then
               Me.m_CurrentProcess.Revision = 0.001
            End If

            If Me.m_GenerateEquipment = True Then
               If m_CurrentProcess Is Nothing Then
                  m_CurrentProcess = ProjectInfo.Creator.CreateProcessEquipmentAndProject(Me.m_ProcessType)
               Else
                  m_CurrentProcess = ProjectInfo.Creator.CreateProcessEquipmentAndProject(Me.m_ProcessType, m_CurrentProcess)
               End If
            Else
               If m_CurrentProcess Is Nothing Then
                  m_CurrentProcess = ProjectInfo.Creator.CreateProcessAndProject(Me.m_ProcessType)
               Else
                  m_CurrentProcess = ProjectInfo.Creator.CreateProcessAndProject(Me.ProcessType, Me.m_CurrentProcess)
               End If
            End If
            If OpenedProject.IsOpened = False Then
               rae.ui.inform("Project must be created. Process not saved.")
               m_CancelSave = True
               Return m_CurrentProcess
            End If
            If CurrentProcess Is Nothing Then
               ' Process item was not created, unable to save...
               rae.ui.inform("Unable to save process.")
               m_CancelSave = True
               Return m_CurrentProcess
            End If
         Else

            If m_CurrentProcess IsNot Nothing Then
               m_CurrentProcess.Revision = Rae.RaeSolutions.DataAccess.Projects.ProjectsDataAccess.RetrieveLatestRevision(OpenedProject.Manager.Project.id.Id) + 0.001
            End If

            ' Create a new process - give it a name...
            If m_GenerateEquipment = True Then
               If m_CurrentProcess Is Nothing Then
                  m_CurrentProcess = ProjectInfo.Creator.CreateProcessAndEquipment(Me.m_ProcessType)
               Else
                  m_CurrentProcess = ProjectInfo.Creator.CreateProcessAndEquipment(Me.m_ProcessType, m_CurrentProcess)
               End If
            Else
               If m_CurrentProcess Is Nothing Then
                  m_CurrentProcess = ProjectInfo.Creator.CreateProcess(Me.m_ProcessType)
               Else
                  'NEW CONDENSINGUNIT HERE

                  m_CurrentProcess = ProjectInfo.Creator.CreateProcess(Me.m_ProcessType, m_CurrentProcess)
               End If
            End If

            If m_CurrentProcess Is Nothing Then
               ' Process item was not created
               ' unable to save...
               Ui.MessageBox.Show("Unable to save condenser process.", MessageBoxIcon.Information)
               m_CancelSave = True
            End If
         End If

      End If

      If m_CurrentProcess IsNot Nothing Then
         m_CallingForm.tag = m_CurrentProcess.id.Id
      End If
      Return m_CurrentProcess
   End Function

   Public Function RevisionSaved(ByVal CurrentProcessState As ProcessItem) As ProcessItem

      m_CurrentProcess = CurrentProcessState

      ' If there is a saved process then we'll
      ' need to compare it to the current state
      ' to determine if we need to prompt the
      ' user to save as a revision...
      If m_LastSavedProcess IsNot Nothing Then

         ' If the form is closing and changes have been made 
         ' we need to find out if user wants to save or just 
         ' exit the form...
         If FormClosing = True Then

            If m_LastSavedProcess.Equals(m_CurrentProcess) Then

               Return m_LastSavedProcess
            End If


            Dim result As DialogResult
            Dim saveForm As New SaveOnCloseForm()

            ' gets user's save selection
            saveForm.ShowDialog()

            Select Case saveForm.SaveSelection
               Case SaveOnCloseForm.UserSelection.Save
                  ' User wants to save over current revision...
                  Me.m_SaveType = Save_Type.Save
               Case SaveOnCloseForm.UserSelection.SaveAsRevision
                  ' User wants to save as a new revision.
                  Me.m_SaveType = Save_Type.Revision
               Case SaveOnCloseForm.UserSelection.DoNotSave
                  ' User does not want to save...
                  Me.m_DoNotSave = True
                  saveForm.Close()
                  Return m_LastSavedProcess
               Case SaveOnCloseForm.UserSelection.Cancel
                  ' User cancelled out of form closing...
                  Me.m_CancelSave = True
                  saveForm.Close()
                  Return m_LastSavedProcess
               Case Else
                  Throw New ApplicationException("Invalid save option.")
            End Select
            saveForm.Close()

         End If

         ' If this is not the current revision we need
         ' to make sure to force this save as a revision...
         If m_CallingForm.CurrentRevision < m_CallingForm.LatestRevision Then
            Me.m_SaveType = Save_Type.Revision
         End If

         ' Only continue save routine if the process has
         ' changed since it was last saved and this is
         ' not set to a revision save and this is NOT
         ' equipment generation...
         If Me.m_RevChange = True Then
            If m_CurrentProcess.Equals(m_LastSavedProcess) Then
               Return m_LastSavedProcess
            End If
         ElseIf m_CurrentProcess.Equals(m_LastSavedProcess) _
         And Me.m_SaveType <> Save_Type.Revision _
         And Me.m_GenerateEquipment = False Then
            coolstuffUpdateBoxLoad()
            Return m_LastSavedProcess
         End If

         ' If this was fired from revision changed event
         ' we need to ask user if they want to save changes
         ' before navigating the to the next change...
         If Me.m_RevChange = True Then
            Dim saveForm As Form
            If Me.m_SaveType = Save_Type.Revision Then
               saveForm = New SaveOldRevisionBeforeNavigatingRevisionsForm()
            Else
               saveForm = New SaveBeforeNavigatingRevisionsForm()
            End If
            Dim result As DialogResult = saveForm.ShowDialog()
            If result <> Windows.Forms.DialogResult.OK Then
               ' user chose not to save
               saveForm.Close()
               Return m_LastSavedProcess
            End If
            saveForm.Close()
         End If

         ' Process reference needs to be same as reference in OpenedProject
         For Each process As ProcessItem In OpenedProject.Manager.Processes
            If process.id.ToString = m_CurrentProcess.id.ToString Then

               ' If this is a save as revision we need to increment
               ' the revision level to the latest saved revision + 1...
               If Me.m_SaveType = Save_Type.Revision Then
                  'm_CurrentProcess.Revision = Rae.RaeSolutions.DataAccess.Projects.ProcessItemDA.LastestRevision(m_CallingForm.Tag) + 1
                  m_CurrentProcess.Revision = Rae.RaeSolutions.DataAccess.Projects.ProcessItemDA.IncrementItemRevision(m_CallingForm.tag)
                  ' set revision description now if this is not
                  ' equipment generation...
                  If m_GenerateEquipment = False Then
                     Dim frmNewProcess As New NewItemForm2
                     frmNewProcess.GetRevDesc = True
                     frmNewProcess.txtRevDesc.Text = Trim(m_CurrentProcess.ProcessRevisionDescription)
                     frmNewProcess.NewItem(NewItemForm2.NewItemType.SelectionOnly)
                     frmNewProcess.ShowDialog()
                     If frmNewProcess.DialogResult = DialogResult.Cancel Then
                        ' User cancelled out of save...
                        Me.m_CancelSave = True
                        frmNewProcess.Close()
                        frmNewProcess = Nothing
                        Return m_LastSavedProcess
                     Else
                        m_CurrentProcess.ProcessRevisionDescription = frmNewProcess.RevisionDescription
                     End If

                     ' Close form, release object...
                     frmNewProcess.Close()
                     frmNewProcess = Nothing
                  End If

               End If

               ' Copy current state to process (hooked into same
               ' process in OpenedProject), save process and update 
               ' m_CurrentRevision variable...
               process.Copy(m_CurrentProcess)
               m_LastSavedProcess = m_CurrentProcess.Clone
               m_CallingForm.CurrentRevision = m_LastSavedProcess.Revision
               ' If the new revision number is > latest revision
               ' then set the latest revision...
               If m_CallingForm.CurrentRevision > m_CallingForm.LatestRevision Then
                  m_CallingForm.LatestRevision = m_CallingForm.CurrentRevision
               End If
               'save as a revision
               process.Save()
               coolstuffUpdateBoxLoad()
               ' Create a new equipment item - give it a name...
               If m_GenerateEquipment = True Then
                  Dim TmpEquipment = ProjectInfo.Creator.CreateEquipmentFromExistingProcess(Me.m_CurrentProcess, Me.m_ProcessType)
                  If TmpEquipment Is Nothing Then
                     rae.ui.alert("Unable to create equipment item.")
                  End If
               End If

               Exit For
            End If
         Next

      Else

         ' Save current state and set the last
         ' saved state to the current sate. Update
         ' form tag with new process ID and increment
         ' m_CurrentRevision variable...
         m_CurrentProcess.Save()
         'NewCoolStuffEntry()

         m_LastSavedProcess = m_CurrentProcess.Clone
         m_CallingForm.CurrentRevision = m_LastSavedProcess.Revision
         ' If the new revision number is > latest revision
         ' then set the latest revision...
         If m_CallingForm.CurrentRevision > m_CallingForm.LatestRevision Then
            m_CallingForm.LatestRevision = m_CallingForm.CurrentRevision
         End If
         m_CallingForm.Tag = m_LastSavedProcess.id.Id
         coolstuffUpdateBoxLoad()

      End If

      If Me.RevisionProject Then
         ProjectInfo.RevisionProject(m_LastSavedProcess.ProjectManager.Project.id.Id, "NOTE: You are not the project owner.  (Owner: " & ProjectInfo.GetProjectOwner(m_LastSavedProcess.ProjectManager.Project.id) & ")")
         m_LastSavedProcess.Revision = m_LastSavedProcess.GetLastRevisionNumber(m_LastSavedProcess.id.Id)
         m_CallingForm.CurrentRevision = m_LastSavedProcess.Revision
         ' If the new revision number is > latest revision
         ' then set the latest revision...
         If m_CallingForm.CurrentRevision > m_CallingForm.LatestRevision Then
            m_CallingForm.LatestRevision = m_CallingForm.CurrentRevision
         End If
      End If

      ' Update RevisionView control...
      AppInfo.Main.RevisionView1.UpdateRevisionView(m_CallingForm, Nothing)

      Return m_LastSavedProcess

   End Function

   Private Function coolstuffUpdateBoxLoad() As Boolean
      If Me.m_ProcessType = Rae.RaeSolutions.Business.ProcessType.CondensingUnit _
      Or Me.m_ProcessType = Rae.RaeSolutions.Business.ProcessType.UnitCoolerBalance Then
         Dim CSC As New CoolStuff.CoolStuffCommon
         CSC.NewCoolStuffEntry(Me)
      End If
   End Function
   
   Public Function CompareRevisions(ByVal FormSaved As Object, ByVal ProcessType As Rae.RaeSolutions.Business.ProcessType, ByVal CurrentStateProcess As ProcessItem, ByVal LastSavedProcess As ProcessItem, ByVal SaveAsNew As Boolean, ByVal SaveRevision As Boolean, ByVal FormClosing As Boolean, Optional ByVal GenerateEquipment As Boolean = False)

      ' Set properties...
      Me.m_CallingForm = FormSaved

      ' If user wants to save this process as a new
      ' process then we need to clone the current
      ' process so we can get a new ID, etc...
      If SaveAsNew = True Then
         If CurrentStateProcess IsNot Nothing Then
            Me.m_CurrentProcess = CurrentStateProcess.Clone(True)

            ' If SaveAsNew = true user is cloning this
            ' object as a new object for use later so we
            ' need to create a new ID & set revision to
            ' ZERO...
            Me.m_CurrentProcess.Revision = 0
            Me.m_CurrentProcess.id = New item_id(AppInfo.User.username, AppInfo.User.password)

         Else
            ' If there is no current process to clone
            ' we need to cancel & exit...
            m_CancelSave = True
            Return m_CurrentProcess
         End If
      Else
         ' Use current process instead of clone since we
         ' are just saving the process (not save as new)
         Me.m_CurrentProcess = CurrentStateProcess
      End If

      Me.m_LastSavedProcess = LastSavedProcess
      If SaveAsNew = True Then
         Me.m_SaveType = Save_Type.NewItem
      ElseIf SaveRevision = True Then
         Me.m_SaveType = Save_Type.Revision
      Else
         Me.m_SaveType = Save_Type.Save
      End If
      Me.m_FormClosing = FormClosing
      Me.m_ProcessType = ProcessType
      Me.m_GenerateEquipment = GenerateEquipment

      ' If user wants to save this process as a new
      ' process then reset the LastSavedProcess and
      ' m_CurrentRevision, m_LatestRevision variables...
      If Me.m_SaveType = Save_Type.NewItem Then
         m_CallingForm.CurrentRevision = 0
         m_CallingForm.LatestRevision = 0
         m_CallingForm.tag = ""
         m_CallingForm.LastSavedProcess = Nothing
         m_LastSavedProcess = Nothing
      End If

      If m_LastSavedProcess IsNot Nothing Then

         ' This process has already been saved - we'll
         ' clone the current state to the last saved state
         ' and update with the current values and compare
         ' to determine wheter or not we need to prompt for 
         ' revision and save...
         If m_CurrentProcess Is Nothing Then
            m_CurrentProcess = m_LastSavedProcess.Clone()
         End If

      Else

         ' This process has not yet been saved - we'll
         ' need to make sure there is an opened project
         ' & tie this process to it...

         ' If the form is closing we need to find out if user
         ' wants to save or just exit the form...
         If m_FormClosing = True Then
            If MessageBox.Show("Would you like to save your work?", "Save?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
               ' User wants to save...
            Else
               ' User does not want to save...
               m_CancelSave = True
               Return m_CurrentProcess
            End If
         End If

         ' Make sure there is an opened project
         ' & tie this process to it...
         If Not OpenedProject.IsOpened Then
            ' No project is open - if user wants to
            ' save rating they should associate it 
            ' with a project for future reference...
            'ProjectInfo.Creator.CreateProject()
            If Me.m_GenerateEquipment = True Then
               If m_CurrentProcess Is Nothing Then
                  m_CurrentProcess = ProjectInfo.Creator.CreateProcessEquipmentAndProject(Me.m_ProcessType)
               Else
                  m_CurrentProcess = ProjectInfo.Creator.CreateProcessEquipmentAndProject(Me.m_ProcessType, m_CurrentProcess)
               End If
            Else
               If m_CurrentProcess Is Nothing Then
                  m_CurrentProcess = ProjectInfo.Creator.CreateProcessAndProject(Me.m_ProcessType)
               Else
                  m_CurrentProcess = ProjectInfo.Creator.CreateProcessAndProject(Me.ProcessType, Me.m_CurrentProcess)
               End If
            End If
            If OpenedProject.IsOpened = False Then
               Ui.MessageBox.Show("Project must be created.  Process not saved.", MessageBoxIcon.Information)
               m_CancelSave = True
               Return m_CurrentProcess
            End If
            If CurrentProcess Is Nothing Then
               ' Process item was not created
               ' unable to save...
               Ui.MessageBox.Show("Unable to save condenser process.", MessageBoxIcon.Information)
               m_CancelSave = True
               Return m_CurrentProcess
            End If
         Else
            ' Create a new process - give it a name...
            If m_GenerateEquipment = True Then
               If m_CurrentProcess Is Nothing Then
                  m_CurrentProcess = ProjectInfo.Creator.CreateProcessAndEquipment(Me.m_ProcessType)
               Else
                  m_CurrentProcess = ProjectInfo.Creator.CreateProcessAndEquipment(Me.m_ProcessType, m_CurrentProcess)
               End If
            Else
               If m_CurrentProcess Is Nothing Then
                  m_CurrentProcess = ProjectInfo.Creator.CreateProcess(Me.m_ProcessType)
               Else
                  m_CurrentProcess = ProjectInfo.Creator.CreateProcess(Me.m_ProcessType, m_CurrentProcess)
               End If
            End If

            If m_CurrentProcess Is Nothing Then
               ' Process item was not created
               ' unable to save...
               Ui.MessageBox.Show("Unable to save condenser process.", MessageBoxIcon.Information)
               m_CancelSave = True
            End If
         End If

      End If

      m_CallingForm.tag = m_CurrentProcess.id.Id
      Return m_CurrentProcess

   End Function




End Class
