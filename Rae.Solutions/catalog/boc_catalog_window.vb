imports rae.solutions.unit_coolers
imports system.environment
imports system.io

public class boc_catalog_window
   private sub btn_generate_click() handles btn_generate.click
      dim series = cbo_series.text

      dim catalog = new boc_catalog.catalog(new repository(), series)
      grid.dataSource = catalog.table

      dim file_name = "boc-catalog.csv"
      dim desktop = GetFolderPath(SpecialFolder.Desktop)
      dim save_dialog = new System.Windows.Forms.SaveFileDialog()
      save_dialog.Filter = ".csv|*.csv"
      save_dialog.InitialDirectory = desktop
      save_dialog.FileName = file_name
      dim result = save_dialog.ShowDialog()
      if result = DialogResult.Cancel then exit sub

      dim catalog_path = save_dialog.FileName

      grid.ExportToDelimitedFile(catalog_path, _
                                 C1.Win.C1TrueDBGrid.RowSelectorEnum.AllRows, ",", "", "", true)
   end sub

   
end class