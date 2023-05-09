'Imports C1.Win.C1TrueDBGrid
Imports System.Data
Imports Cols = Rae.RaeSolutions.DataAccess.Projects.Tables.OptionsObjectTable

''' <summary>
''' Specialized grid for options that the user selected
''' </summary>
Public Class SelectedOptionGrid
   Inherits OptionGrid


   Sub New()
      MyBase.New()
   End Sub


   ''' <summary>
   ''' Shows option prices if true
   ''' </summary>
   Property IsPriceVisible As Boolean
      Get
         Return _isPriceVisible
      End Get
      Set(value As Boolean)
         _isPriceVisible = value
      End Set
   End Property


   ''' <summary>Sets column widths</summary>
   Sub SetColumnWidths()
      If Not containsData Then _
         Exit Sub

      Dim vScrollBarWidth, totalBorderWidth As Integer

        ''If Splits(0).VScrollBar.Visible Then
        ''    vScrollBarWidth = Splits(0).VScrollBar.Width
        ''Else
        ''    vScrollBarWidth = 0
        ''End If
        totalBorderWidth = 8

        'If Me.isLoaded Then
        ''With Splits(0).DisplayColumns
        ''    ' sets description column width
        ''    .Item(Cols.Description).Width =
        ''         Width _
        ''       - .Item(Cols.Quantity).Width _
        ''       - .Item(Cols.Code).Width _
        ''       - .Item(Cols.Category).Width _
        ''       - .Item(Cols.Price).Width _
        ''       - .Item(Cols.Per).Width _
        ''       - vScrollBarWidth _
        ''       - totalBorderWidth
        ''End With
    End Sub

   Overrides Sub ApplyStyle()
      MyBase.ApplyStyle
        ''customizeStyle
        SetColumnWidths()
   End Sub


   ''' <summary>Adds row to selected options grid</summary>
   ''' <param name="op">Row containing option to add</param>
   ''' <returns>Boolean that is true if option was added to selected options grid</returns>
   Function Add(op As DataRow) As Boolean
      Dim added As Boolean

        ' checks if option is already added (shouldn't but has happened b4)
        If Not DataSource Is Nothing Then
            ' checks if option already exists in selected options table
            For Each row As DataRow In table.Rows
                ' if option already exists
                If CInt(row(Cols.ID)) = CInt(op(Cols.ID)) Then
                    Console.WriteLine("Option already exists in selected options grid. Option was not added again.")
                    ' don't add again (something is wrong!)
                    ' TODO: Throw New OptionAlreadyExistsException
                    added = False : Return added
                End If
            Next
        End If

        ' if option does not yet exist then add
        table.ImportRow(op)
      added = True : Return added
   End Function


   ''' <summary>Removes option from selected options list</summary>
   Sub Remove(op As DataRow)
      deleteSelectedOption(CInt(op(Cols.ID)))
   End Sub
   
   Sub Remove(opCode As String)
        If Not DataSource Is Nothing Then
            For Each row As DataRow In table.Rows
                If row(Cols.Code) = opCode Then
                    table.Rows.Remove(row) : Exit Sub
                End If
            Next
        End If
    End Sub

   Private _isPriceVisible As Boolean


    ''Private Sub me_FetchCellStyle(s As Object, e As FetchCellStyleEventArgs) _
    ''Handles Me.FetchCellStyle
    ''   If e.Column.Name = Cols.Quantity Then
    ''      formatQuantityForEditing(e)
    ''   ElseIf e.Column.Name = Cols.Price & " Each" Then
    ''      formatPrice(e)
    ''   End If
    ''End Sub

    '' Private Sub me_FetchCellTips(s As Object, e As FetchCellTipsEventArgs) _
    ''Handles Me.FetchCellTips
    ''   If e.Column IsNot Nothing AndAlso e.Column.Name = Cols.Description Then
    ''      showDetailsInCellTip(e)
    ''   End If
    ''End Sub


    '' Private Sub me_Resize(s As Object, e As EventArgs) _
    ''Handles Me.Resize
    ''   SetColumnWidths
    ''End Sub


    '' Private Sub customizeStyle()
    ''   If Not containsData Then
    ''      Console.WriteLine("Selected options grid column collection is empty.") : Exit Sub : End If

    ''   ' shows cell tips
    ''   CellTips = CellTipEnum.Floating

    ''   ' hides record selectors
    ''   RecordSelectors = False

    ''   ' sets datagrid caption
    ''   Caption = "Selected Available Options Summary"

    ''   ' prevents text from wrapping to multiple lines in a cell
    ''   Style.WrapText = False

    ''   ' allows quantity column cells to be editted
    ''   AllowUpdate = True

    ''   ' FloatingEditor enum - cell text highlights on first click rather than having to double click
    ''   MarqueeStyle = MarqueeEnum.FloatingEditor
    ''   ' note: editorstyle only works if marquestyle is not FloatingEditor
    ''   ' when entering text into cell editorstyle is not visible
    ''   '.EditorStyle.BackgroundPictureDrawMode = BackgroundPictureDrawModeEnum.Center
    ''   '.EditorStyle.BackgroundImage = textbox
    ''   '.EditorStyle.ForegroundImage = pencil
    ''   '.EditorStyle.ForeGroundPicturePosition = ForeGroundPicturePositionEnum.Near

    ''   ' moves quantity column to first index
    ''   Dim quantityColumn = Splits(0).DisplayColumns(Cols.Quantity)
    ''   MoveColumn(quantityColumn, 0)

    ''   ' prevents columns stretch according to the width of the datagrid
    ''   SpringMode = False

    ''   ' formats price
    ''   Columns(Cols.Price).NumberFormat = "$#,##0"

    ''   ' sets columns to readonly
    ''   '.Splits(0).Locked = True

    ''   With Splits(0)
    ''      ' sets column header height
    ''      .ColumnCaptionHeight = 22

    ''      ' hides unnecessary columns
    ''      .DisplayColumns(Cols.ID).Visible = False
    ''      .DisplayColumns(Cols.IsQuantityReadOnly).Visible = False
    ''      .DisplayColumns(Cols.IsSelectedReadOnly).Visible = False
    ''      .DisplayColumns(Cols.Selected).Visible = False
    ''      .DisplayColumns(Cols.IsVoltageDependent).Visible = False
    ''      .DisplayColumns(Cols.Voltage).Visible = False
    ''      .DisplayColumns(Cols.ContactFactory).Visible = False
    ''      .DisplayColumns(Cols.Price).Visible = IsPriceVisible
    ''      .DisplayColumns(Cols.IsDependent).Visible = False
    ''      .DisplayColumns(Cols.MasterId).Visible = False
    ''      .DisplayColumns(Cols.Details).Visible = False

    ''      ' sets column captions
    ''      .DisplayColumns(Cols.Quantity).DataColumn.Caption = "Quantity"
    ''      .DisplayColumns(Cols.Code).DataColumn.Caption = "Code"
    ''      .DisplayColumns(Cols.Description).DataColumn.Caption = "Description"
    ''      .DisplayColumns(Cols.Category).DataColumn.Caption = "Category"
    ''      .DisplayColumns(Cols.Price).DataColumn.Caption = "Price Each"
    ''      .DisplayColumns(Cols.Per).DataColumn.Caption = "Per"

    ''      ' sets column widths
    ''      .DisplayColumns(Cols.Quantity).Width = 55
    ''      .DisplayColumns(Cols.Code).Width = 45
    ''      .DisplayColumns(Cols.Description).Width = 185
    ''      .DisplayColumns(Cols.Category).Width = 115
    ''      .DisplayColumns(Cols.Price).Width = 65
    ''      .DisplayColumns(Cols.Per).Width = 50

    ''      ' sets columns to readonly (except quantity column)
    ''      .DisplayColumns(Cols.Code).Locked = True
    ''      .DisplayColumns(Cols.Description).Locked = True
    ''      .DisplayColumns(Cols.Category).Locked = True
    ''      .DisplayColumns(Cols.Price).Locked = True
    ''      .DisplayColumns(Cols.Per).Locked = True

    ''      ' aligns columns
    ''      .DisplayColumns(Cols.Description).Style.HorizontalAlignment = AlignHorzEnum.Near

    ''      ' quantity column fetch style
    ''      .DisplayColumns(Cols.Quantity).FetchStyle = True
    ''      .DisplayColumns(Cols.Price).FetchStyle = True

    ''      ' centers quantity
    ''      .DisplayColumns(Cols.Quantity).Style.HorizontalAlignment = AlignHorzEnum.Center
    ''      .DisplayColumns(Cols.Per).Style.HorizontalAlignment = AlignHorzEnum.Center

    ''      ' aligns foreground image
    ''      .DisplayColumns(Cols.Quantity).Style.ForeGroundPicturePosition = ForeGroundPicturePositionEnum.Near
    ''   End With
    ''End Sub


    Private Sub deleteSelectedOption(optionId As Integer)
        If Not DataSource Is Nothing Then
            For Each row As DataRow In table.Rows
                ' searches for row to delete in selected options table based on id
                If CInt(row(Cols.ID)) = optionId Then
                    ' deletes row
                    table.Rows.Remove(row) : Exit Sub
                End If
            Next
        End If

        ' the option was not deleted b/c it is not in selected options table
        Console.WriteLine("Selected option row to delete not found.")
   End Sub

End Class

   '''' <summary>Gets selected option row based on option code</summary>
   '''' <remarks>Selected options grid may contain quantities that the user entered 
   '''' that are not in the available options grid.</remarks>
   'Private Function GetSelectedOptionRow(code As String) As DataRow
   '   For Each row As DataRow In table.Rows
   '      If row(Cols.Code).ToString = code Then
   '         Return row
   '      End If
   '   Next

   '   Return Nothing
   'End Function
