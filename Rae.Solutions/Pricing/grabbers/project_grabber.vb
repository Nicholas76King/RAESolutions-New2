imports cnull = Rae.ConvertNull

class project_grabber
   private equipment_view as EquipmentForm
   
   sub new(equipment_view as EquipmentForm)
      me.equipment_view = equipment_view
   end sub
   
   public show_authorized_by as boolean
   
   protected sub prepare()
      ' refreshes values in controls
      equipment_view.showAllTabs()
   end sub
   
   function grab() as bag
      prepare()

      dim release_status, release_number as string
      dim project_name, project_id as string
      dim rep_company, rep as string
      dim contractor_company, contractor as string
      dim architect_company, architect as string
      dim engineer_company, engineer as string
      
      If OpenedProject.IsOpened Then
         Dim projectForm = DirectCast(ProjectInfo.Viewer.GetView(OpenedProject.Manager.Project.id.Id), ProjectForm)
         Dim project = OpenedProject.Manager.Project
         project_name = project.name
         ' determines whether submittal request form is open
         If projectForm Is Nothing Then
            ' retrieves values from datasource, submittal request form is not open
            If project.Contacts.Representative IsNot Nothing Then
               rep_company = project.Contacts.Representative.Company.Name
               rep = project.Contacts.Representative.Name.FirstThenLastName
            End If
            If project.Contacts.Architect IsNot Nothing Then
               architect_company = project.Contacts.Architect.Company.Name
               architect = project.Contacts.Architect.Name.FirstThenLastName
            End If
            If project.Contacts.Contractor IsNot Nothing Then
               contractor_company = project.Contacts.Contractor.Company.Name
               contractor = project.Contacts.Contractor.Name.FirstThenLastName
            End If
            If project.Contacts.Engineer IsNot Nothing Then
               engineer_company = project.Contacts.Engineer.Company.Name
               engineer = project.Contacts.Engineer.Name.FirstThenLastName
            End If

            If project.ReleaseStatus = Business.ReleaseStatus.Project Then
               'releaseNum = .Project.Id.SafeId
            Else
               release_status = project.ReleaseStatus.ToString() & ": "
               release_number = project.ReleaseNum.ToString()
            End If
         Else
            ' retrieves values from open submittal request form
            If Not projectForm.RepCompany Is Nothing Then _
               rep_company = projectForm.RepCompany.Name
            If Not projectform.RepContact Is Nothing Then _
               rep = projectForm.RepContact.Name.FirstThenLastName
            
            With projectForm.ContactManagerControl1.Contacts
               If .Architect IsNot Nothing Then
                  architect = .Architect.Name.FirstThenLastName
                  architect_company = .Architect.Company.Name
               End If
               If .Contractor IsNot Nothing Then
                  contractor = .Contractor.Name.FirstThenLastName
                  contractor_company = .Contractor.Company.Name
               End If
               If .Engineer IsNot Nothing Then
                  engineer = .Engineer.Name.FirstThenLastName
                  engineer_company = .Engineer.Company.Name
               End If
            End With
            
            release_status = cnull.ToString(projectForm.releaseStatusComboBox.SelectedItem)
            If release_status = Business.ReleaseStatus.Project.ToString Then
               'releaseNum = projectForm.projectIdTextBox.Text
               release_status = ""
            Else
               release_status &= ": "
               release_number = projectForm.releaseNumTextBox.Text
            End If
            
            project_id = project.id.SafeId()
         End If
      Else
         project_name = "A project has not been created."
      End If
      
   
      ' prevents null values from causing exceptions
      rep_company = cnull.ToString(rep_company)
      
      dim bag as bag
      
      bag.release_status    = release_status
      bag.release_number    = release_number
      bag.project_name      = project_name
      bag.project_id        = project_id
      
      bag.rep               = rep
      bag.rep_company       = rep_company
      bag.contractor        = contractor
      bag.contractor_company= contractor_company
      bag.engineer          = engineer
      bag.engineer_company  = engineer_company
      bag.architect         = architect
      bag.architect_company = architect_company
      
      return bag
   end function
   
   structure bag
      public release_status, release_number as string
      public project_name, project_id as string
      public rep, rep_company as string
      public contractor, contractor_company as string
      public engineer, engineer_company as string
      public architect, architect_company as string
   end structure
end class