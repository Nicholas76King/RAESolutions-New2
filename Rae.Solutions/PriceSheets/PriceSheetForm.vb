Imports CrystalDecisions.CrystalReports.Engine
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Rae.RaeSolutions.DataAccess.Common
Imports Rae.RaeSolutions.Business.Entities.PriceSheets
Imports Rae.Reporting.CrystalReports

Imports CNull = Rae.ConvertNull
Imports EquipmentDataAccess = Rae.DataAccess.EquipmentOptions.EquipmentDataAccess

Public Class PriceSheetForm

   Private authorizedDivisions As List(Of String)
   Private user As String
   Private app As String
   Private version As String


   ''' <summary>Use this constructor because the parameters are necessary.</summary>
   ''' <param name="authorizedDivisions">Divisions that the user is authorized for</param>
   ''' <param name="user">Name that identifies the user creating the price sheets</param>
   ''' <param name="app">Name of the application being used to create price sheets</param>
   ''' <param name="version">Version of the application being used to create price sheets</param>
   Sub New(authorizedDivisions As List(Of String), _
           user As String, app As String, version As String)
      MyBase.New()

      Me.authorizedDivisions = authorizedDivisions
      Me.user = user
      Me.app = app
      Me.version = version

      Me.InitializeComponent()
   End Sub


#Region " Private methods"

#Region " Event handlers"

   Private Sub form_Load(sender As Object, e As EventArgs) _
   Handles MyBase.Load
      Me.populateDivisions()
      Me.updateUi()
   End Sub


   Private Sub divisionRadioButton_CheckedChanged(sender As Object, e As EventArgs) _
   Handles divisionRadioButton.CheckedChanged
      Me.updateUi()
   End Sub


   Private Sub seriesRadioButton_CheckedChanged(sender As Object, e As EventArgs) _
   Handles seriesRadioButton.CheckedChanged
      Me.updateUi()
   End Sub


   Private Sub viewReportButton_Click(sender As Object, e As EventArgs) _
   Handles viewReportButton.Click
      Me.viewProgress()
      Me.viewReportButton.Enabled = False
      Me.viewPriceSheet()
   End Sub


   Private Sub divisionComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) _
   Handles divisionComboBox.SelectedIndexChanged
      Me.populateSeries()
   End Sub


   Private Sub seriesComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) _
   Handles seriesComboBox.SelectedIndexChanged
      Me.populateModels()
   End Sub


   Private Sub viewPriceSheetBackgroundWorker_DoWork(sender As Object, e As DoWorkEventArgs) _
   Handles viewPriceSheetBackgroundWorker.DoWork
      Me.viewer.Prepare()
   End Sub


   Private Sub viewPriceSheetBackgroundWorker_RunWorkerCompleted(s As Object, e As RunWorkerCompletedEventArgs) _
   Handles viewPriceSheetBackgroundWorker.RunWorkerCompleted
      Try
         Me.viewer.View()
      Catch ex As Win32Exception
         Dim message = "There is no pdf viewer (such as Adobe Acrobat Reader) installed."
         MessageBox.Show(message, "Price Sheets", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      End Try
      Me.progressForm.Close()
      Me.viewReportButton.Enabled = True
   End Sub

#End Region


   Private Sub updateUi(authorizedDivisions As List(Of String), filterByThis As FilterBy)
      Dim hasMultipleDivisionAuthority = (authorizedDivisions.Count > 1)
      If hasMultipleDivisionAuthority Then
         If filterByThis = FilterBy.Division Then
            divisionComboBox.Visible = True
            seriesComboBox.Visible = False
            Me.modelComboBox.Visible = False
         ElseIf filterByThis = FilterBy.Series Then
            divisionComboBox.Visible = True
            seriesComboBox.Visible = True
            Me.modelComboBox.Visible = False
         ElseIf filterByThis = FilterBy.Model Then
            divisionComboBox.Visible = True
            seriesComboBox.Visible = True
            modelComboBox.Visible = True
         Else
            Throw New ApplicationException("The price sheet controls cannot be updated. The filter by selection, " & CNull.ToString(filterByThis) & ", is not valid.")
         End If
      Else
         If filterByThis = FilterBy.Division Then
            divisionComboBox.Visible = False
            seriesComboBox.Visible = False
            Me.modelComboBox.Visible = False
         ElseIf filterByThis = FilterBy.Series Then
            divisionComboBox.Visible = False
            seriesComboBox.Visible = True
            Me.modelComboBox.Visible = False
         ElseIf filterByThis = FilterBy.Model Then
            Me.divisionComboBox.Visible = False
            Me.seriesComboBox.Visible = False
            Me.modelComboBox.Visible = False
         Else
            Throw New ApplicationException("The price sheet controls cannot be updated. The filter by selection, " & CNull.ToString(filterByThis) & ", is not valid.")
         End If
      End If
   End Sub


   Private Sub updateUi()
      If Me.divisionRadioButton.Checked Then
         Me.updateUi(authorizedDivisions, FilterBy.Division)
      ElseIf Me.seriesRadioButton.Checked Then
            Me.updateUi(authorizedDivisions, FilterBy.Series)
     ElseIf Me.compressorRadioButton.Checked Then
         Me.divisionComboBox.Visible = False
         Me.seriesComboBox.Visible = False
         Me.modelComboBox.Visible = False
     Else
         Me.updateUi(authorizedDivisions, FilterBy.Model)
      End If
   End Sub


   Private Sub populateDivisions()
      Me.divisionComboBox.Items.Clear()
      Dim splitDivisions = Me.convertAbbreviatedDivisions(Me.authorizedDivisions)
      For Each splitAuthorizedDivision As SplitValue In splitDivisions
         Me.divisionComboBox.Items.Add(splitAuthorizedDivision)
      Next

      Me.divisionComboBox.SelectedIndex = 0
   End Sub


   Private Sub populateSeries(division As String)
      Dim series As List(Of String) = EquipmentDataAccess.RetrieveSeries(division)
      Me.seriesComboBox.Items.Clear()
      Me.seriesComboBox.Items.AddRange(series.ToArray())
      Me.seriesComboBox.SelectedIndex = 0
   End Sub


   Private Sub populateSeries()
      Dim selectedDivision = CType(Me.divisionComboBox.SelectedItem, SplitValue).HiddenValue
      Me.populateSeries(selectedDivision)
   End Sub


   Private Sub populateModels()
      Dim selectedSeries As String = Me.seriesComboBox.SelectedItem.ToString()
      Me.populateModels(selectedSeries)
   End Sub


   Private Sub populateModels(series As String)
      Dim models As List(Of String) = EquipmentDataAccess.RetrieveModels(series)
      Me.modelComboBox.Items.Clear()
      Me.modelComboBox.Items.AddRange(models.ToArray())
      If models.Count > 0 Then _
         Me.modelComboBox.SelectedIndex = 0
   End Sub


   Private viewer As IPriceViewer
   Private Sub viewPriceSheet()
      If compressorRadioButton.Checked
         'Dim rpt = New ReportDocument()
         
         'Dim reportFilePath = Reports.file_paths.CompressorWarrantyReportFilePath
         'rpt.Load(reportFilePath)
         
         Dim pricing = getCompressorPricing()
         'rpt.SetDataSource(pricing)
         
            'Dim reportForm As New ReportViewerForm(rpt)
         'reportForm.Show()

         dim report = new rae.reporting.beta.report(reports.file_paths.compressor_warranty_file_path)
         dim table = new DataTable
         table.columns.add("Model")
         table.columns.add("Net Price")
         for each row in pricing.tables(0).rows
            dim price = row("Total Price").ToString
            if price = "999998" then 
               price = "Contact Factory"
            else
               price = price.format_number("$#,0")
            end if

            table.rows.add(row("UnitModel"), price)
         next
         report.set_table("table", table)
         report.show
         Exit Sub
      End If
      
      Dim by As FilterBy
      Dim filter As String
      If divisionRadioButton.Checked
         by = FilterBy.Division
         filter = CType(divisionComboBox.SelectedItem, SplitValue).HiddenValue
      ElseIf seriesRadioButton.Checked
         by = FilterBy.Series
         filter = seriesComboBox.SelectedItem.ToString()
      ElseIf modelRadioButton.Checked
         by = FilterBy.Model
         Dim model = Me.modelComboBox.SelectedItem.ToString()
         Dim series = Me.seriesComboBox.SelectedItem.ToString()
         filter = series & "," & model
      End If
      Dim factory = New ViewerFactory()
      viewer = factory.Create(user, app, version, by, filter)
      viewPriceSheetBackgroundWorker.RunWorkerAsync()
   End Sub


   Private Function getCompressorPricing() As System.Data.DataSet
        Dim ds As New System.Data.DataSet




        '
        '
        '
        ''               This method does not work.  The DB it points to is incorrect and has not been updated since around 2010!
        '
        '
        '









      Dim sql As String = "select [id], UnitModel, (CompressorQty + CompressorQty2) as Quantity, TotalCharge as [Total Price] from WarrantyInfo order by id asc"
      Dim con = CreateConnection(GetConnectionString(CompressorDbPath))
      Dim cmd = con.CreateCommand
      cmd.CommandText = sql
      
      Dim da = CreateAdapter(cmd)
      da.Fill(ds)
      
      Return ds
   End Function


   Dim progressForm As ProgressForm
   Private Sub viewProgress()
      Me.progressForm = New ProgressForm()
      If Me.divisionRadioButton.Checked Then
         Dim division = CType(Me.divisionComboBox.SelectedItem, SplitValue).DisplayValue
         Me.progressForm.Label2.Text = "Generating " & division & " price sheets may take a few minutes."
      ElseIf Me.seriesRadioButton.Checked Then
         Dim series As String = Me.seriesComboBox.SelectedItem.ToString()
            Me.progressForm.Label2.Text = "Generating " & series & " price sheets may take a minute."
     ElseIf Me.compressorRadioButton.Checked Then
         'Me.progressForm.Label2.Text = "Generating Warranty Price Sheets."
         Exit Sub
     Else
         Dim model As String = Me.modelComboBox.SelectedItem.ToString()
         Dim series As String = Me.seriesComboBox.SelectedItem.ToString()
         Me.progressForm.Label2.Text = "Generating " & series & model & " price sheets."
      End If
      Me.progressForm.Show()
   End Sub


   Private Function convertAbbreviatedDivisions(divisions As List(Of String)) As List(Of SplitValue)
      Dim values As New List(Of SplitValue)()

      For Each division As String In divisions
         If division = "CRI" Then
            Dim value As New SplitValue("Century Refrigeration", "CRI")
            values.Add(value)
         ElseIf division = "TSI" Then
            Dim value As New SplitValue("Technical Systems", "TSI")
            values.Add(value)
         End If
      Next

      Return values
   End Function

#End Region


   ''' <summary>
   ''' Division of RAE Corporation (eg Century Refrigeration and Technical Systems).
   ''' </summary>
   Public Class SplitValue

      Sub New(displayValue As String, hiddenValue As String)
         Me.HiddenValue = hiddenValue
         Me.DisplayValue = displayValue
      End Sub

      ''' <summary>Abbreviation of division.</summary>
      Public HiddenValue As String

      ''' <summary>Name of division.</summary>
      Public DisplayValue As String

      ''' <summary>Displayed value</summary>
      Public Overrides Function ToString() As String
         Return Me.DisplayValue
      End Function

   End Class

End Class