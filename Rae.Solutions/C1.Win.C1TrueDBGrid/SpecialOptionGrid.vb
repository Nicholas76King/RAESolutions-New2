'Imports C1.Win.C1TrueDBGrid
Imports Cols = Rae.RaeSolutions.DataAccess.Projects.Tables.SpecialOptionsTable

''' <summary>
''' Specialized grid for displaying special options
''' </summary>
Public Class SpecialOptionGrid
   Inherits OptionGrid

   Sub New()
      MyBase.New
   End Sub

   ''' <summary>Sets column widths</summary>
   Sub SetColumnWidths()
        ''If DataSource Is Nothing Then _
        Exit Sub
      
      Dim vScrollBarWidth, totalBorderWidth As Integer

        'If Splits(0).VScrollBar.Visible Then
        '   vScrollBarWidth = Splits(0).VScrollBar.Width
        'Else
        '   vScrollBarWidth = 0
        'End If
        totalBorderWidth = 7

        'If Me.isLoaded Then
        ''With Splits(0).DisplayColumns
        ''   ' sets description column width
        ''   .Item(Cols.Description).Width = _
        ''        Width _
        ''      - .Item(Cols.Quantity).Width _
        ''      - .Item(Cols.Code).Width _
        ''      - .Item(Cols.AuthorizedBy).Width _
        ''      - .Item(Cols.Price).Width _
        ''      - vScrollBarWidth _
        ''      - totalBorderWidth
        ''End With
    End Sub

   ''' <summary>Applies visual style</summary>
   Overrides Sub ApplyStyle()
        ''If DataSource Is Nothing Then _
        Exit Sub

      MyBase.ApplyStyle

        ''With Splits(0)
        ''   ' sets cells to readonly
        ''   .Locked = True

        ' hides columns
        ''Columns(Cols.Id).Visible = False
        ''Columns(Cols.EquipmentId).Visible = False
        ''Columns(Cols.AuthorizedFor).Visible = False
        ''Columns(Cols.Revision).Visible = False

        ''''   ' sets header height
        ''''   .ColumnCaptionHeight = 22

        ''' sets column widths
        ''Columns(Cols.Quantity).Width = 55
        ''Columns(Cols.Code).Width = 45
        ''Columns(Cols.Description).Width = 244
        ''Columns(Cols.AuthorizedBy).Width = 88
        ''Columns(Cols.Price).Width = 65

        ''' moves columns
        ''MoveColumn(.DisplayColumns(Cols.Quantity), 0)
        ''MoveColumn(.DisplayColumns(Cols.Code), 1)
        ''MoveColumn(.DisplayColumns(Cols.Description), 2)
        ''MoveColumn(.DisplayColumns(Cols.AuthorizedBy), 3)
        ''MoveColumn(.DisplayColumns(Cols.Price), 4)

        ''' formats code
        ''.DisplayColumns(Cols.Code).DataColumn.NumberFormat = "SP00"

        ''' adds new price column; data type of price column is nullablevalue which can't be formatted to currency
        ''Columns.Add(New C1DataColumn("Price Each", GetType(String)))
        ''.DisplayColumns("Price Each").Visible = True
        ''.DisplayColumns("Price Each").Width = 65
        ''.DisplayColumns(Cols.Price).Visible = False
        ''End With
    End Sub



    ''Private Sub me_UnboundColumnFetch(s As Object, e As UnboundColumnFetchEventArgs) _
    ''Handles Me.UnboundColumnFetch
    ''   If e.Column.Caption = "Price Each" Then
    ''      ' formats price
    ''      e.Value = CType(Columns(Cols.Price).CellValue(e.Row), nullable_value(Of Double)).value.ToString("$#,##0")
    ''   End If
    ''End Sub

    '' Private Sub me_Resize(s As Object, e As EventArgs) _
    ''Handles Me.Resize
    ''   SetColumnWidths
    ''End Sub

End Class
