Public Class CheckInChangesForm

   Public serverChanges As System.Data.DataTable
   Public projectName As String
   Public userServer As Boolean = False

   Private Sub CheckInChangesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

      Me.lblProject.Text = projectName
      Me.serverChanges.DefaultView.Sort = "Revision Date DESC"
        ''Me.ServerDataChanges.DataSource = Me.serverChanges

        ' handlers
        AddHandler lblUserServerVersion.MouseEnter, AddressOf MouseIn
      AddHandler lblUseMyVersion.MouseEnter, AddressOf MouseIn
      AddHandler lblCancel.MouseEnter, AddressOf MouseIn
      AddHandler lblUserServerVersion.MouseLeave, AddressOf MouseOut
      AddHandler lblUseMyVersion.MouseLeave, AddressOf MouseOut
      AddHandler lblCancel.MouseLeave, AddressOf MouseOut
      AddHandler btnUserServerVersion.MouseEnter, AddressOf MouseIn
      AddHandler btnUseMyVersion.MouseEnter, AddressOf MouseIn
      AddHandler btnCancel.MouseEnter, AddressOf MouseIn
      AddHandler btnUserServerVersion.MouseLeave, AddressOf MouseOut
      AddHandler btnUseMyVersion.MouseLeave, AddressOf MouseOut
      AddHandler btnCancel.MouseLeave, AddressOf MouseOut

        ' sets row selection style
        ''Me.ServerDataChanges.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
        ''Me.ServerDataChanges.RowHeight = Me.ServerDataChanges.RowHeight * 3
        ''Me.ServerDataChanges.Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        ''Me.ServerDataChanges.Splits(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        ''Me.ServerDataChanges.Splits(0).Style.WrapText = True
        ''Me.setColumnWidths()

    End Sub

    ''Private Sub setColumnWidths()

    ''   ' checks if the datasource has been set yet
    ''   If ServerDataChanges.DataSource Is Nothing Then Exit Sub

    ''   Const DATE_CREATED_COLUMN_WIDTH As Integer = 100

    ''   ' gets total width available for columns in datagrid
    ''   Dim totalWidth As Integer = ServerDataChanges.Width
    ''   totalWidth -= 6   ' borders
    ''   totalWidth -= ServerDataChanges.VScrollBar.Width

    ''   ' adjusts columns width according to datagrid's width
    ''   Me.ServerDataChanges.Splits(0).DisplayColumns("Project Name").Width = -1
    ''   Me.ServerDataChanges.Splits(0).DisplayColumns("Revision").Width = totalWidth * 0.15
    ''   Me.ServerDataChanges.Splits(0).DisplayColumns("Revision By").Width = totalWidth * 0.15
    ''   Me.ServerDataChanges.Splits(0).DisplayColumns("Revision Date").Width = DATE_CREATED_COLUMN_WIDTH
    ''   Me.ServerDataChanges.Splits(0).DisplayColumns("Revision Description").Width = totalWidth * 0.7 - DATE_CREATED_COLUMN_WIDTH

    ''   Me.ServerDataChanges.Splits(0).DisplayColumns("Revision By").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    ''   Me.ServerDataChanges.Splits(0).DisplayColumns("Revision Date").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    ''   Me.ServerDataChanges.Splits(0).DisplayColumns("Revision Description").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    ''   Me.ServerDataChanges.Splits(0).DisplayColumns("Revision").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

    ''   Me.ServerDataChanges.Splits(0).DisplayColumns("Revision By").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    ''   Me.ServerDataChanges.Splits(0).DisplayColumns("Revision Date").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    ''   Me.ServerDataChanges.Splits(0).DisplayColumns("Revision Description").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    ''   Me.ServerDataChanges.Splits(0).DisplayColumns("Revision").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

    ''End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click, lblCancel.Click
      Me.DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Hide()
   End Sub

   Private Sub btnUseMyVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUseMyVersion.Click, lblUseMyVersion.Click
      Me.DialogResult = Windows.Forms.DialogResult.OK
      Me.userServer = False
      Me.Hide()
   End Sub

   Private Sub btnUserServerVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUserServerVersion.Click, lblUserServerVersion.Click
      Me.DialogResult = Windows.Forms.DialogResult.OK
      Me.userServer = True
      Me.Hide()
   End Sub

   Private Sub MouseIn(ByVal sender As Object, ByVal e As System.EventArgs)
      For Each ctl As Control In Me.Controls
         If ctl.Name = sender.name.ToString.Replace("btn", "lbl") Then
            ctl.BackColor = Color.LemonChiffon
            Exit For
         End If
      Next
   End Sub

   Private Sub MouseOut(ByVal sender As Object, ByVal e As System.EventArgs)
      For Each ctl As Control In Me.Controls
         If ctl.Name = sender.name.ToString.Replace("btn", "lbl") Then
            ctl.BackColor = Color.White
            Exit For
         End If
      Next
   End Sub

End Class