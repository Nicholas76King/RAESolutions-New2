Imports C1.Win.C1TrueDBGrid
Imports System.Data
Imports Cols = Rae.RaeSolutions.DataAccess.Projects.Tables.OptionsObjectTable

''' <summary>Specialized grid for displaying standard options</summary>
Public Class StandardOptionGrid
   Inherits OptionGrid

   Sub New()
      MyBase.New()
   End Sub

   Overrides Sub ApplyStyle()
      MyBase.ApplyStyle
        ''customizeStyle
        SetColumnWidths()
   End Sub
   
   Sub Add(op As DataRow)
      table.ImportRow(op)
   End Sub
   
   Sub Remove(id As Integer)
      For Each row As DataRow In table.Rows
         If CInt(row(Cols.ID)) = id Then
            table.Rows.Remove(row) : Exit Sub
         End If
      Next
   End Sub

   Sub SetColumnWidths
      If Not containsData Then _
         Exit Sub

      Dim verticalScrollBarWidth, totalBorderWidth As Integer

        ''If Splits(0).VScrollBar.Visible Then
        ''   verticalScrollBarWidth = Splits(0).VScrollBar.Width
        ''Else
        ''   verticalScrollBarWidth = 0
        ''End If
        totalBorderWidth = 6

        'If Me.isLoaded Then
        ''With Splits(0).DisplayColumns
        ''   ' sets description column width
        ''   .Item(Cols.Description).Width = _
        ''        Width _
        ''      - .Item(Cols.Quantity).Width _
        ''      - .Item(Cols.Code).Width _
        ''      - .Item(Cols.Category).Width _
        ''      - verticalScrollBarWidth _
        ''      - totalBorderWidth
        ''End With
    End Sub


    ''Private Sub me_Resize(s As Object, e As EventArgs) _
    ''Handles Me.Resize
    ''   SetColumnWidths
    ''End Sub

    '' Private Sub me_FetchCellTips(s As Object, e As FetchCellTipsEventArgs) _
    ''Handles Me.FetchCellTips
    ''   If e.Column IsNot Nothing AndAlso e.Column.Name = Cols.Description Then
    ''      showDetailsInCellTip(e)
    ''   End If
    ''End Sub

    '' Private Sub customizeStyle()
    ''   If Columns.Count = 0 Then
    ''      Console.WriteLine("Standard options grid's column collection is empty.") : Exit Sub : End If

    ''   ' shows cell tips
    ''   CellTips = CellTipEnum.Floating

    ''   ' hides record selectors
    ''   RecordSelectors = False

    ''   ' sets grid caption
    ''   Caption = "Standard Options"

    ''   ' prevents text from wrapping to multiple lines in a cell
    ''   Style.WrapText = False

    ''   ' moves quantity column to first index
    ''   Dim quantityColumn = Splits(0).DisplayColumns(Cols.Quantity)
    ''   MoveColumn(quantityColumn, 0)

    ''   ' prevents columns stretch according to the width of the grid
    ''   SpringMode = False






    ''   ' sets columns to readonly
    ''   Splits(0).Locked = True

    ''   With Splits(0)
    ''      ' sets column header height
    ''      .ColumnCaptionHeight = 22

    ''      ' hides unnecessary columns
    ''      .DisplayColumns(Cols.ID).Visible = False
    ''      .DisplayColumns(Cols.IsQuantityReadOnly).Visible = False
    ''      .DisplayColumns(Cols.Per).Visible = False
    ''      .DisplayColumns(Cols.IsSelectedReadOnly).Visible = False
    ''      .DisplayColumns(Cols.Selected).Visible = False
    ''      .DisplayColumns(Cols.Price).Visible = False
    ''      .DisplayColumns(Cols.IsVoltageDependent).Visible = False
    ''      .DisplayColumns(Cols.Voltage).Visible = False
    ''      .DisplayColumns(Cols.ContactFactory).Visible = False
    ''      .DisplayColumns(Cols.IsDependent).Visible = False
    ''      .DisplayColumns(Cols.MasterId).Visible = False
    ''      .DisplayColumns(Cols.Details).Visible = False

    ''      ' sets column captions
    ''      .DisplayColumns(Cols.Quantity).DataColumn.Caption = "Quantity"
    ''      .DisplayColumns(Cols.Code).DataColumn.Caption = "Code"
    ''      .DisplayColumns(Cols.Description).DataColumn.Caption = "Description"
    ''      .DisplayColumns(Cols.Category).DataColumn.Caption = "Category"
    ''      .DisplayColumns(Cols.Price).DataColumn.Caption = "Price"

    ''      ' sets column widths
    ''      .DisplayColumns(Cols.Quantity).Width = 55
    ''      .DisplayColumns(Cols.Code).Width = 45
    ''      .DisplayColumns(Cols.Description).Width = 250
    ''      .DisplayColumns(Cols.Category).Width = 115
    ''      .DisplayColumns(Cols.Price).Width = 65

    ''      ' aligns columns
    ''      .DisplayColumns(Cols.Description).Style.HorizontalAlignment = AlignHorzEnum.Near

    ''      ' centers quantity
    ''      .DisplayColumns(Cols.Quantity).Style.HorizontalAlignment = AlignHorzEnum.Center
    ''      ' sets foreground image to readonly image
    ''      .DisplayColumns(Cols.Quantity).Style.ForegroundImage = My.Resources.Lock
    ''      ' aligns foreground image
    ''      .DisplayColumns(Cols.Quantity).Style.ForeGroundPicturePosition = ForeGroundPicturePositionEnum.Near
    ''   End With
    ''End Sub

End Class
