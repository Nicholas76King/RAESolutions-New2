Imports System.Data
Imports Rae.RaeSolutions.DataAccess

Public Class WelcomeForm

   Private ProtoFont As System.Drawing.Font

   Private Sub WelcomeForm_Load(sender As Object, e As EventArgs) _
   Handles Me.Load

        'AddHandler linkApplicationBulletins.MouseEnter, AddressOf MouseEnterForeColor
        'AddHandler linkApplicationBulletins.MouseLeave, AddressOf MouseLeaveForeColor

        'AddHandler linkOnlineCatalogs.MouseEnter, AddressOf MouseEnterForeColor
        'AddHandler linkOnlineCatalogs.MouseLeave, AddressOf MouseLeaveForeColor

      AddHandler linkRAECorpHome.MouseEnter, AddressOf MouseEnterForeColor
      AddHandler linkRAECorpHome.MouseLeave, AddressOf MouseLeaveForeColor

        'AddHandler linkSupportChat.MouseEnter, AddressOf MouseEnterForeColor
        'AddHandler linkSupportChat.MouseLeave, AddressOf MouseLeaveForeColor

        'AddHandler linkSupportForum.MouseEnter, AddressOf MouseEnterForeColor
        'AddHandler linkSupportForum.MouseLeave, AddressOf MouseLeaveForeColor

      ' Position main function controls in FlowLayoutPanel1...
      'Dim lblWidth As Integer = Me.FlowLayoutPanel1.Width - 10
      'Dim NumCtls As Integer = 0
      'For Each ctl As Control In Me.FlowLayoutPanel1.Controls
      '   If ctl.Name <> "SpaceHolderLabel1" And ctl.Visible = True Then NumCtls = NumCtls + 1
      'Next
      'lblWidth = (lblWidth / NumCtls) - ((NumCtls - 1) * 6)
      'For Each ctl As Control In Me.FlowLayoutPanel1.Controls
      '   If ctl.Name <> "SpaceHolderLabel1" And ctl.Visible = True Then ctl.Width = lblWidth
      'Next

      If AppInfo.Division <> Business.Division.CRI Then
         lblBoxLoad.Visible = False
      End If

      TimerRecentProjects.Enabled = True
   End Sub

   Private Sub GetRecentProjects(Optional username As String = "")
      'Dim timer As New Rae.Diagnostics.Timer()
      'timer.QueryPerformanceCounter(timer.StartTime)
      'Dim serverDatabaseConnectionIsAvailable As Boolean = DataAccess.Common.IsConnected
      'Dim numCheckedOutProjects As Integer = Projects.ProjectsDataAccess.RetrieveNumCheckedOutProjects()
      'Dim areAnyProjectsCheckedOut As Boolean = (numCheckedOutProjects > 0)
      
      Dim projectsTable As New DataTable
      'If Not serverDatabaseConnectionIsAvailable AndAlso Not areAnyProjectsCheckedOut Then
      'Else
         Dim RecProjNum As Single = 0
         Dim TempLabel As Label

         projectsTable = Projects.ProjectsDataAccess.RetrieveAll(True, username)
         projectsTable.DefaultView.Sort = "DateCreated DESC"

         ' Get the first 4 projects...
         Dim ProjectCount As Integer = 0
         For Each Row As DataRow In projectsTable.DefaultView.ToTable().Rows
            ProjectCount = ProjectCount + 1
            If ProjectCount = 6 Then Exit For
            TempLabel = New Label
            TempLabel.ForeColor = Color.SlateGray
            TempLabel.Name = "linkRecentProject" & ProjectCount
            TempLabel.AutoSize = False
            TempLabel.Width = 281
            TempLabel.Height = 23
            TempLabel.Tag = Row("ProjectId")
            TempLabel.Text = Row("Name") & "  " & Row("DateCreated").ToString
            AddHandler TempLabel.MouseEnter, AddressOf MouseEnterForeColor
            AddHandler TempLabel.MouseLeave, AddressOf MouseLeaveForeColor
            AddHandler TempLabel.Click, AddressOf RecProjLabel_Click
            Me.flpRecentProjects.Controls.Add(TempLabel)
            Row = Nothing
         Next
      'End If

      'projectsTable = Nothing
      'timer.QueryPerformanceCounter(timer.EndTime)
      'timer.ElapsedTime
   End Sub

   Private Sub RecProjLabel_Click(sender As System.Object, e As System.EventArgs)

      Me.Cursor = Cursors.WaitCursor

      ' sets project manager based on ProjectID (.Tag property)
      ProjectInfo.Creator.CreateExistingProject(sender.tag)

      Me.Cursor = Cursors.Arrow

      If OpenedProject.IsOpened Then Me.Close()

   End Sub

   Private Sub MouseEnterForeColor(sender As Object, e As System.EventArgs)
      Me.Cursor = Cursors.Hand
      sender.forecolor = Color.DarkBlue
      ProtoFont = sender.font
      sender.Font = New System.Drawing.Font(ProtoFont, FontStyle.Bold)
   End Sub

   Private Sub MouseLeaveForeColor(sender As Object, e As System.EventArgs)
      Me.Cursor = Cursors.Arrow
      sender.forecolor = Color.SlateGray
      ProtoFont = sender.font
      sender.Font = New System.Drawing.Font(ProtoFont, FontStyle.Regular)
   End Sub

   Private Sub lblStartNewProject_MouseEnter(sender As Object, e As System.EventArgs) Handles lblStartNewProject.MouseEnter
      lblStartNewProject.Image = Rae.RaeSolutions.My.Resources.Resources.NewProject
      MouseEnterForeColor(sender, e)
   End Sub

   Private Sub lblStartNewProject_MouseLeave(sender As Object, e As System.EventArgs) Handles lblStartNewProject.MouseLeave
      lblStartNewProject.Image = Rae.RaeSolutions.My.Resources.Resources.NewProjectSmoke
      MouseLeaveForeColor(sender, e)
   End Sub

   Private Sub lblOpenProject_MouseEnter(sender As Object, e As System.EventArgs) Handles lblOpenProject.MouseEnter
      lblOpenProject.Image = Rae.RaeSolutions.My.Resources.Resources.OpenProject
      MouseEnterForeColor(sender, e)
   End Sub

   Private Sub lblOpenProject_MouseLeave(sender As Object, e As System.EventArgs) Handles lblOpenProject.MouseLeave
      lblOpenProject.Image = Rae.RaeSolutions.My.Resources.Resources.OpenProjectSmoke
      MouseLeaveForeColor(sender, e)
   End Sub

   Private Sub lblSelectionsAndRatings_MouseEnter(sender As Object, e As EventArgs) Handles lblSelectionsAndRatings.MouseEnter
      lblSelectionsAndRatings.Image = My.Resources.SelectionRating
      MouseEnterForeColor(sender, e)
   End Sub

   Private Sub lblSelectionsAndRatings_MouseLeave(sender As Object, e As EventArgs) Handles lblSelectionsAndRatings.MouseLeave
      lblSelectionsAndRatings.Image = My.Resources.SelectionRatingSmoke
      MouseLeaveForeColor(sender, e)
   End Sub

   Private Sub lblPricingAndDrawings_MouseEnter(sender As Object, e As EventArgs) Handles lblPricingAndDrawings.MouseEnter
      Me.lblPricingAndDrawings.Image = My.Resources.Pricing
      MouseEnterForeColor(sender, e)
   End Sub

   Private Sub lblPricingAndDrawings_MouseLeave(sender As Object, e As EventArgs) Handles lblPricingAndDrawings.MouseLeave
      Me.lblPricingAndDrawings.Image = My.Resources.PricingSmoke
      MouseLeaveForeColor(sender, e)
   End Sub

   Private Sub lblBoxLoad_MouseEnter(sender As Object, e As EventArgs) _
   Handles lblBoxLoad.MouseEnter
      Me.lblBoxLoad.Image = My.Resources.Boxload
      MouseEnterForeColor(sender, e)
   End Sub

   Private Sub lblBoxLoad_MouseLeave(sender As Object, e As EventArgs) _
   Handles lblBoxLoad.MouseLeave
      Me.lblBoxLoad.Image = My.Resources.BoxloadSmoke
      MouseLeaveForeColor(sender, e)
   End Sub

   Private Sub lblClose_Click() Handles lblClose.Click, close_menu_item.click
      Me.Close()
   End Sub

   Private Sub lblClose_MouseEnter(sender As Object, e As System.EventArgs) Handles lblClose.MouseEnter
      Me.Cursor = Cursors.Hand
      lblX.ForeColor = Color.MidnightBlue
      lblClose.ForeColor = Color.MidnightBlue
   End Sub

   Private Sub lblClose_MouseLeave(sender As Object, e As System.EventArgs) Handles lblClose.MouseLeave
      Me.Cursor = Cursors.Arrow
      lblX.ForeColor = Color.White
      lblClose.ForeColor = Color.White
   End Sub

   Private Sub lblX_Click(sender As System.Object, e As System.EventArgs) Handles lblX.Click
      Me.Close()
   End Sub

   Private Sub lblX_MouseEnter(sender As Object, e As System.EventArgs) Handles lblX.MouseEnter
      Me.Cursor = Cursors.Hand
      lblX.ForeColor = Color.MidnightBlue
      lblClose.ForeColor = Color.MidnightBlue
   End Sub

   Private Sub lblX_MouseLeave(sender As Object, e As System.EventArgs) Handles lblX.MouseLeave
      Me.Cursor = Cursors.Arrow
      lblX.ForeColor = Color.White
      lblClose.ForeColor = Color.White
   End Sub

   Private Function OpenLink(link As String) As Boolean
      Cursor = Cursors.WaitCursor
         OpenLink = Rae.Networking.Connection.IsInternetConnectionAvailable
      Cursor = Cursors.Arrow

      If Not OpenLink Then
         rae.ui.inform("RAESolutions could not find an available internet connection.")
      Else
         Process.Start(link)
      End If
   End Function

   Private Sub linkRAECorpHome_Click(sender As System.Object, e As System.EventArgs) Handles linkRAECorpHome.Click
      OpenLink("http://www.rae-corp.com")
   End Sub

    Private Sub linkOnlineCatalogs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If AppInfo.Division = Business.Division.CRI Then
            OpenLink("http://www.rae-corp.com/index.php?Itemid=233&option=com_rokdownloads&view=folder")
        Else
            OpenLink("http://www.rae-corp.com/index.php?Itemid=235&option=com_rokdownloads&view=folder")
        End If
    End Sub

   Private Sub lblOpenProject_Click() Handles lblOpenProject.Click, open_menu_item.click
      Me.Cursor = Cursors.WaitCursor
      ProjectInfo.Creator.CreateExistingProject()
      Me.Cursor = Cursors.Arrow
      If OpenedProject.IsOpened Then
         Me.Close()
      End If
   End Sub

   Private Sub lblStartNewProject_Click(sender As System.Object, e As System.EventArgs) Handles lblStartNewProject.Click
      Me.Cursor = Cursors.WaitCursor
      ProjectInfo.Creator.CreateProject()
      Me.Cursor = Cursors.Arrow
      If OpenedProject.IsOpened Then
         Me.Close()
      End If
   End Sub

   Private Sub lblSelectionsAndRatings_Click() Handles lblSelectionsAndRatings.Click, select_menu_item.click
      Me.Cursor = Cursors.WaitCursor
      CType(My.Application.ApplicationContext.MainForm, MainForm).StartNewProcess()
      Me.Close()
   End Sub

   Private Sub lblPricingAndDrawings_Click() Handles lblPricingAndDrawings.Click, price_menu_item.click
      Me.Cursor = Cursors.WaitCursor
      ProjectInfo.Creator.CreateEquipment()
      Me.Close()
   End Sub

   Private Sub TimerRecentProjects_Tick(sender As System.Object, e As System.EventArgs) Handles TimerRecentProjects.Tick
      TimerRecentProjects.Enabled = False
      GetRecentProjects(AppInfo.User.username)
   End Sub

   Private Sub lblBoxLoad_Click(sender As System.Object, e As System.EventArgs) Handles lblBoxLoad.Click
      Me.Cursor = Cursors.WaitCursor
      ProjectInfo.Viewer.ViewBoxLoad()
      Me.Close()
   End Sub

   Private Sub welcome_menu_MenuActivate() Handles welcome_menu.MenuActivate
      'when alt key is pressed then show menu
      welcome_menu.visible = true
   End Sub

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click, close_menu_item.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class
