Imports C1.Win.C1TrueDBGrid
Imports Rae.Ui.quickies
Imports Rae.RaeSolutions.Business.Entities
Imports System.Collections.Generic
Imports System.Data
Imports System.Environment
Imports Cols = Rae.RaeSolutions.DataAccess.Projects.Tables.OptionsObjectTable
Imports Rae.RaeSolutions.DataAccess.EquipmentOptionsAgent.OptionsDA

''' <summary>
''' Specialized grid for displaying available options and allowing user to select options.
''' </summary>
Public Class AvailableOptionGrid
    Inherits OptionGrid

#Region " External"

    ''' <summary>Initializes a new available options grid</summary>
    Sub New()
        MyBase.New()
    End Sub

    Event GroupedByCategory As EventHandler

    Protected Overridable Sub onGroupedByCategory()
        If Me.GroupedByCategoryEvent IsNot Nothing Then _
           RaiseEvent GroupedByCategory(Me, EventArgs.Empty)
    End Sub

    Event Ungrouped As EventHandler

    Protected Overridable Sub onUngrouped()
        If Me.UngroupedEvent IsNot Nothing Then _
           RaiseEvent Ungrouped(Me, EventArgs.Empty)
    End Sub

    ''' <summary>Shows option prices if true</summary>
    Property IsPriceVisible As Boolean
        Get
            Return _isPriceVisible
        End Get
        Set(ByVal value As Boolean)
            _isPriceVisible = value
        End Set
    End Property

    ''' <summary>Groups options by category</summary>
    ''Sub GroupByCategory()
    ''    GroupByAreaVisible = False
    ''    ' note: setting dataview to groupby changes/resets vertical grid lines and other stuff
    ''    DataView = DataViewEnum.GroupBy
    ''    GroupedColumns.Clear()
    ''    If containsData() Then _
    ''       GroupedColumns.Add(Columns(Cols.Category))
    ''    ApplyStyle()
    ''    onGroupedByCategory()
    ''End Sub

    ''' <summary>Ungroups columns; lists options in a flat view</summary>
    Sub Ungroup()
        ''DataView = DataViewEnum.Normal
        ApplyStyle()
        onUngrouped()
    End Sub

    ''' <summary>Applies visual style</summary>
    Overrides Sub ApplyStyle()
        MyBase.ApplyStyle()
        ''customizeStyle()
        SetColumnWidths()
    End Sub

    ''' <summary>Sets column widths in grid</summary>
    ''' <remarks>Columns are fixed length except for description which fills in the rest</remarks>
    Sub SetColumnWidths()
        If Not containsData() Then _
           Exit Sub

        Dim vScrollBarWidth As Integer
        ''If Splits(0).VScrollBar.Visible Then
        ''    vScrollBarWidth = Splits(0).VScrollBar.Width
        ''Else
        ''    vScrollBarWidth = 0
        ''End If

        Dim totalBorderWidth = 9

        'TODO: If isLoaded Then
        Dim groupedColumnsWidth As Integer
        ''For Each column As C1DataColumn In GroupedColumns
        ''    groupedColumnsWidth += Splits(0).DisplayColumns(column.ToString()).Width - 12
        ''Next

        ' sets description column width to whatever width is left over
        ''With Splits(0).DisplayColumns
        ''    .Item(Cols.Description).Width = _
        ''         Width _
        ''       - .Item(Cols.Selected).Width _
        ''       - .Item(Cols.Category).Width _
        ''       - .Item(Cols.Price).Width _
        ''       - .Item(Cols.Code).Width _
        ''       - .Item(Cols.Per).Width _
        ''       - .Item(Cols.Quantity).Width _
        ''       + groupedColumnsWidth _
        ''       - vScrollBarWidth _
        ''       - totalBorderWidth
        ''End With
    End Sub

    ''' <summary>Unselects all selected options.</summary>
    Sub UnselectAll()
        If table Is Nothing Then _
           Exit Sub

        For Each row As DataRow In table.Rows
            If CBool(row(Cols.Selected)) Then _
               row(Cols.Selected) = False
        Next
    End Sub

    ''' <summary>Removes all options. Grid will not contain any options.</summary>
    Sub RemoveAll()
        If table Is Nothing Then _
           Exit Sub

        UnselectAll()
        table.Clear()
    End Sub

    ''' <summary>Gets available option row based on option code; returns null if option is not found</summary>
    Function GetRow(ByVal code As String) As DataRow
        For Each row As DataRow In table.Rows
            If row(Cols.Code).ToString = code Then _
               Return row
        Next

        Return Nothing
    End Function

    ''' <summary>Gets first selected option from the available options grid.</summary>
    ''' <remarks>Assumes all options in parameter are in grid</remarks>
    Function GetFirstSelectedFrom(ByVal options As List(Of EquipmentOption)) As DataRow
        Dim row As DataRow

        For i As Integer = 0 To options.Count - 1
            row = GetRow(options.Item(i).Code)

            If row Is Nothing Then
                Return row
            End If

            If CBool(row(Cols.Selected)) Then
                ' a parent is selected
                Exit For
            ElseIf i = options.Count - 1 Then
                ' a parent is NOT selected
                row = Nothing
            End If
        Next

        Return row
    End Function

    ''' <summary>Selects options from table</summary>
    Overloads Sub [Select](ByVal optionsToSelect As DataTable)
        Dim message As String

        ' iterates through options to add
        For i As Integer = 0 To optionsToSelect.Rows.Count - 1
            ' iterates through the available options to select from
            For j As Integer = 0 To table.Rows.Count - 1
                ' checks if ids match
                If CInt(optionsToSelect.Rows(i)(Cols.MasterId)) = CInt(table.Rows(j)(Cols.MasterId)) Then
                    ' selects option
                    table.Rows(j)(Cols.Selected) = True
                    ' sets quantity
                    If CBool(table.Rows(j)(Cols.IsQuantityReadOnly)) Then
                        ' quantity is database mandated value, mandated values could potentially be different for different models
                        'Me.selectedOptionsTable.Rows(Me.selectedOptionsTable.Rows.Count - 1)(Cols.Quantity) = CInt(Me.availableOptionsTable.Rows(j)(Cols.Quantity))
                    Else
                        ' resets quantity to user's set quantity
                        table.Rows(table.Rows.Count - 1)(Cols.Quantity) = CInt(optionsToSelect.Rows(i)(Cols.Quantity))
                    End If
                    Exit For
                    ' determines whether option exists
                ElseIf j = table.Rows.Count - 1 Then
                    If optionsToSelect.Rows(i)(Cols.Code).ToString <> "EV01" Then
                        message &= System.Environment.NewLine & "  ID: " & optionsToSelect.Rows(i)(Cols.ID).ToString & ", Code: " & optionsToSelect.Rows(i)(Cols.Code).ToString & ", Description: " & optionsToSelect.Rows(i)(Cols.Description).ToString
                    End If
                End If
            Next
        Next

        ' TEST: can message be nothing
        ' alerts user that an option does not exist
        If Not message = "" Then
            message = "The attempt to select the following options failed. The options are not available for the selected model." & message
            warn(message)
        End If
    End Sub

    ''' <summary>Selects matching options in available options</summary>
    ''' <param name="options">Option list to add to selected options</param>
    Overloads Sub [Select](ByVal options As EquipmentOptionList)
        ' iterates through retrieved options
        For i As Integer = 0 To options.Count - 1
            ' iterates through grid
            For Each r As DataRow In table.Rows
                ' checks if ids match
                If options.Item(i).PricingId = CInt(r(Cols.ID)) Then
                    ' checks selected options in available options grid
                    ' RowChanged event adds option to selected options grid and if readonly
                    r(Cols.Selected) = True
                    r(Cols.Quantity) = options(i).Quantity
                    Exit For
                End If
                'r(Cols.Quantity) = ""
            Next
        Next
    End Sub

#End Region


#Region " Internal"

    Private _isPriceVisible As Boolean



    ''Private Sub me_FetchCellTips(ByVal s As Object, ByVal e As FetchCellTipsEventArgs) _
    ''Handles Me.FetchCellTips
    ''    If e.Column Is Nothing _
    ''    OrElse e.Column.Name = Cols.Quantity _
    ''    OrElse e.Column.DataColumn.DataField = Cols.Selected Then
    ''        e.CellTip = ""
    ''    ElseIf e.Column.Name = Cols.Description Then
    ''        showDetailsInCellTip(e)
    ''    ElseIf e.Column.Name = Cols.Price Then
    ''        Dim dataRow = GetDataRow(e.Row)

    ''        ' cell tip cuts off ending letters so I added useless text that can be cut off
    ''        ' TODO: look into using e.TipStyle.Render(graphics...)
    ''        Dim CONTACT_FACTORY_CELL_TIP As String = "Contact factory for pricing     !"
    ''        If userMustContactFactoryForPrice(dataRow) Then
    ''            e.TipStyle.ForeGroundPicturePosition = ForeGroundPicturePositionEnum.Near
    ''            e.CellTip = CONTACT_FACTORY_CELL_TIP
    ''        End If
    ''    Else
    ''        Dim dataRow = GetDataRow(e.Row)
    ''        Dim hoveredCode = Columns(Cols.Code).CellValue(dataRow).ToString
    ''        Dim warrantyCode = "FYCW"
    ''        Dim warrantyInfo = "Warranties extending an additional 4 years to the standard compressor warranty are available." & NewLine &
    ''           "The warranty simply extends the warranty period an additional 4 years and is valid for that " & NewLine &
    ''           "compressor, utilized in the original equipment for the 5-year period. Extended warranties may" & NewLine &
    ''           "be purchased prior to the start up date, but not after the unit is initially started. The " & NewLine &
    ''           "warranty is not transferable to customers other than the initial purchaser."

    ''        If hoveredCode = warrantyCode Then _
    ''           e.CellTip = warrantyInfo
    ''    End If
    ''End Sub

    ''Private Sub me_FetchCellStyle(ByVal s As Object, ByVal e As FetchCellStyleEventArgs) _
    ''Handles Me.FetchCellStyle
    ''    If e.Column.Name = Cols.Quantity Then
    ''        formatQuantityForEditing(e)
    ''    ElseIf e.Column.Name = Cols.Price Then
    ''        formatPrice(e)
    ''    End If
    ''End Sub

    ''Private Sub me_Resize(ByVal s As Object, ByVal e As EventArgs) _
    ''Handles Me.Resize
    ''    SetColumnWidths()
    ''End Sub

    ''Private Sub customizeStyle()
    ''    If Not containsData() Then
    ''        Console.WriteLine("Available options grid's column collection is empty.") : Exit Sub : End If

    ''    ' sets grid caption (title)
    ''    Caption = "Available Options"
    ''    CaptionHeight = 44
    ''    CaptionStyle.VerticalAlignment = AlignVertEnum.Top

    ''    ' shows cell tips
    ''    CellTips = CellTipEnum.Floating

    ''    ' hides record selectors
    ''    RecordSelectors = False

    ''    ' must be true for checkboxes to be used
    ''    AllowUpdate = True

    ''    ' prevents text from wrapping to multiple lines in cells
    ''    Style.WrapText = False

    ''    ' formats price
    ''    Columns(Cols.Price).NumberFormat = "$#,##0"

    ''    With Splits(0)
    ''        ' sets captions (not columnname)
    ''        .DisplayColumns(Cols.Selected).DataColumn.Caption = "Select"
    ''        .DisplayColumns(Cols.Code).DataColumn.Caption = "Code"
    ''        .DisplayColumns(Cols.Description).DataColumn.Caption = "Description"
    ''        .DisplayColumns(Cols.Category).DataColumn.Caption = "Category"
    ''        .DisplayColumns(Cols.Price).DataColumn.Caption = "Price"
    ''        .DisplayColumns(Cols.Per).DataColumn.Caption = "Per"
    ''        .DisplayColumns(Cols.Quantity).DataColumn.Caption = "Quantity"

    ''        ' sets column header height
    ''        .ColumnCaptionHeight = 22

    ''        ' sets column widths
    ''        .DisplayColumns(Cols.Selected).Width = 55
    ''        .DisplayColumns(Cols.Code).Width = 45
    ''        .DisplayColumns(Cols.Description).Width = 185
    ''        .DisplayColumns(Cols.Category).Width = 115
    ''        .DisplayColumns(Cols.Price).Width = 65
    ''        .DisplayColumns(Cols.Per).Width = 50
    ''        .DisplayColumns(Cols.Quantity).Width = 55

    ''        ' sets columns to readonly, except selected
    ''        .DisplayColumns(Cols.Code).Locked = True
    ''        .DisplayColumns(Cols.Description).Locked = True
    ''        .DisplayColumns(Cols.Category).Locked = True
    ''        .DisplayColumns(Cols.Price).Locked = True
    ''        .DisplayColumns(Cols.Selected).Locked = False
    ''        .DisplayColumns(Cols.Per).Locked = True

    ''        ' hides columns
    ''        .DisplayColumns(Cols.ID).Visible = False
    ''        .DisplayColumns(Cols.Code).Visible = True
    ''        .DisplayColumns(Cols.Quantity).Visible = True
    ''        .DisplayColumns(Cols.IsSelectedReadOnly).Visible = False
    ''        .DisplayColumns(Cols.IsQuantityReadOnly).Visible = False
    ''        .DisplayColumns(Cols.IsVoltageDependent).Visible = False
    ''        .DisplayColumns(Cols.Voltage).Visible = False
    ''        .DisplayColumns(Cols.ContactFactory).Visible = False
    ''        .DisplayColumns(Cols.IsDependent).Visible = False
    ''        .DisplayColumns(Cols.Price).Visible = IsPriceVisible
    ''        .DisplayColumns(Cols.MasterId).Visible = False
    ''        .DisplayColumns(Cols.Details).Visible = False

    ''        ' aligns columns
    ''        .DisplayColumns(Cols.Description).Style.HorizontalAlignment = AlignHorzEnum.Near
    ''        .DisplayColumns(Cols.Per).Style.HorizontalAlignment = AlignHorzEnum.Center

    ''        ' shows check box in selected column
    ''        .DisplayColumns(Cols.Selected).DataColumn.ValueItems.Presentation = PresentationEnum.CheckBox

    ''        ' moves check box column to first index
    ''        MoveColumn(.DisplayColumns(Cols.Selected), 0)

    ''        ' counts number of options in group (formats as price)
    ''        '.DisplayColumns(Cols.Price).DataColumn.Aggregate = AggregateEnum.Count

    ''        ' fetches style (to handle contact factory)
    ''        .DisplayColumns(Cols.Price).FetchStyle = True
    ''        ' fetches style (to handle read-only lock pic and edit pencil and textbox pics
    ''        .DisplayColumns(Cols.Quantity).FetchStyle = True
    ''        '.DisplayColumns(Cols.Quantity).Style.ForeGroundPicturePosition = ForeGroundPicturePositionEnum.PictureOnly


    ''        .DisplayColumns(Cols.Quantity).Style.ForeGroundPicturePosition = ForeGroundPicturePositionEnum.Near
    ''        .DisplayColumns(Cols.Quantity).Style.HorizontalAlignment = AlignHorzEnum.Center
    ''        .MarqueeStyle = MarqueeEnum.FloatingEditor
    ''    End With

    ''    ' prevents columns stretch according to the width of the datagrid
    ''    SpringMode = False
    ''End Sub

#End Region

End Class

'''' <summary>Gets available option row based on option code and voltage; returns null if not found</summary>
'Function GetRow(code As String, voltage As Integer) As DataRow
'   For Each row As DataRow In table.Rows
'      If      row(Cols.Code).ToString = code _
'      AndAlso CInt(row(Cols.Voltage)) = voltage Then _
'         Return row
'   Next

'   Return Nothing
'End Function


'''' <summary>Gets available option row based on option id</summary>
'Function GetRow(optionId As Integer) As DataRow
'   For Each row As DataRow In table.Rows
'      If CInt(row(Cols.ID)) = optionId Then
'         Return row
'      End If
'   Next

'   Return Nothing
'End Function