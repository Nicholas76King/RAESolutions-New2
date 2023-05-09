imports rae.solutions.catalogs
imports rae.solutions.compressors
imports rae.solutions.condensing_units
imports rae.ui.quickies
imports system.environment
imports system.io
imports system.componentModel

public class catalog_form

    Private watch As Stopwatch


    Public Property letter As String
    Public Property division As String

#region " load window"

    'Public Sub New(ByVal iLetter As String)
    '    letter = iLetter
    'End Sub

    Private Sub form_load() Handles Me.Load
        disable_screen("loading data for grid...")
        load_screen_background_worker.RunWorkerAsync()
    End Sub

   dim table as system.data.DataTable

   private sub load_screen_background_worker_do_work(sender as object, e as doWorkEventArgs) _
   handles load_screen_background_worker.DoWork
      try

            Dim catalog = New d_series_data()
            table = catalog.get_data(letter, division)
      catch ex as exception
         alert("Attempt to load grid failed. " & ex.message)
      end try
   end sub

   private sub load_screen_background_run_worker_completed(sender as object, e as RunWorkerCompletedEventArgs) _
   handles load_screen_background_worker.RunWorkerCompleted
        ''grid.datasource = table
        enable_screen("finished loading data for grid")
   end sub

#End Region   

#Region " generate catalog"

   Private Sub btn_generate_click() Handles btn_generate.Click
      Dim desktop = GetFolderPath(SpecialFolder.Desktop)
      Dim file_name = "catalog.csv"

      Dim save_dialog = New System.Windows.Forms.SaveFileDialog()
      save_dialog.Filter = ".csv|*.csv"
        save_dialog.InitialDirectory = "P:\"
      save_dialog.FileName = file_name
      Dim result = save_dialog.ShowDialog()

      If result = DialogResult.Cancel Then Exit Sub

      Dim catalog_path = save_dialog.FileName
      
      Dim stream_writer = File.CreateText(catalog_path)
      stream_writer.WriteLine(Path.GetFileName(catalog_path) & ", "  & Date.Now.ToString("M/d/yyyy hh:mm:ss"))
      stream_writer.Close()

      watch = Stopwatch.StartNew()
        'grid.ExportToDelimitedFile(catalog_path,C1.Win.C1TrueDBGrid.RowSelectorEnum.AllRows, ",", "", "", True)
        log("export to csv time: " & watch.Elapsed.ToString())
      watch.Reset()
      
      Dim condensing_unit_repository = create_condensing_unit_repository()
      Dim compressor_repository = create_compressor_repository()
         
      Dim balance_data = New d_series_balance_for_catalog(condensing_unit_repository, compressor_repository)
      AddHandler balance_data.progress_changed, AddressOf progress_changed
      directory_path = Path.GetDirectoryName(catalog_path)

      disable_screen("generating catalog file...")
      generate_catalog_background_worker.RunWorkerAsync(balance_data)
   End Sub

   Private sub progress_changed(percentage as double)
      generate_catalog_background_worker.ReportProgress(percentage)
   end sub

   private directory_path as string

   private sub generate_catalog_background_worker_do_work(sender as object, e as DoWorkEventArgs) handles generate_catalog_background_worker.DoWork
      watch.start()
         dim balance_data = ctype(e.Argument, d_series_balance_for_catalog)
        balance_data.save(directory_path, letter)
      log("run balances time: " & watch.elapsed.toString())
      watch.stop()
   end sub

   private sub generate_catalog_background_worker_progress_changed(sender as object, e as ProgressChangedEventArgs) handles generate_catalog_background_worker.ProgressChanged
      progress_bar.value = e.ProgressPercentage
   end sub

   private sub background_worker_run_worker_completed(sender as object, e as RunWorkerCompletedEventArgs) Handles generate_catalog_background_worker.RunWorkerCompleted
      progress_bar.value = 100
      dim message = "Catalog is complete"
      rae.ui.quickies.inform(message)
      enable_screen(message)
   end sub
   
#end region

   private sub disable_screen(message as string)
      cursor = cursors.waitCursor
      lbl_status.text = message
      btn_generate.enabled = false
   end sub

   private sub enable_screen(message as string)
      cursor = cursors.default
      btn_generate.enabled = true
      lbl_status.text = message
   end sub

   private sub log(message as object)
      Debug.WriteLine(message)
   end sub
   
   private function create_condensing_unit_repository() as I_Repository
      return new Repository()
   end function
   
   private function create_compressor_repository() as i_compressor_repository
      return new compressor_repository()
   end function
   
end class