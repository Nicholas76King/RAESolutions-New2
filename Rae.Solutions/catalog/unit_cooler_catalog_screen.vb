imports rae.solutions.unit_coolers
imports system.environment
imports system.io

public class unit_cooler_catalog_screen
   private sub btn_generate_click() handles btn_generate.click
      dim series = cbo_series.text

      dim catalog = new boc_catalog.catalog(new repository(), series)
        ''grid.dataSource = catalog.table

        Dim file_name = series & "-catalog.csv"
      dim desktop = GetFolderPath(SpecialFolder.Desktop)
      dim save_dialog = new System.Windows.Forms.SaveFileDialog()
      save_dialog.Filter = ".csv|*.csv"
        save_dialog.InitialDirectory = "p:\" 'desktop
      save_dialog.FileName = file_name
      dim result = save_dialog.ShowDialog()
      if result = DialogResult.Cancel then exit sub

      dim catalog_path = save_dialog.FileName

        'grid.ExportToDelimitedFile(catalog_path, _C1.Win.C1TrueDBGrid.RowSelectorEnum.AllRows, ",", "", "", true)
    End sub

   
    Private Sub btn_generate_click(sender As System.Object, e As System.EventArgs) Handles btn_generate.Click

    End Sub
End Class