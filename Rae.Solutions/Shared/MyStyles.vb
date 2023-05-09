Option Strict On
Option Explicit On 


Imports C1.Win.C1TrueDBGrid
Imports System.Windows.Forms


Public Class MyStyles


    ''' <summary>Sets grid's style to a common style used by a number of grids</summary>
    ''Public Shared Sub VistaGridStyle(ByRef grid As C1TrueDBGrid)
    ''   Dim captionStyle As Style
    ''   Dim headingStyle As Style
    ''   Dim gridStyle As Style
    ''   Dim fontName, captionFont As String

    ''   fontName = "Tw Cen MT"
    ''   captionFont = "Verdana"

    ''   gridStyle = grid.Style
    ''   captionStyle = grid.CaptionStyle
    ''   headingStyle = grid.HeadingStyle

    ''   With gridStyle
    ''      .Font = New Font(fontName, 10, FontStyle.Regular)
    ''      .VerticalAlignment = AlignVertEnum.Center
    ''      .WrapText = True
    ''      .BackColor = Color.White
    ''      .ForeColor = Color.DimGray
    ''      .Borders.BorderType = BorderTypeEnum.None
    ''   End With

    ''   With captionStyle
    ''      ' setting font resets caption height as side effect
    ''      .Font = New Font(captionFont, 9, FontStyle.Regular)
    ''      .HorizontalAlignment = AlignHorzEnum.Center
    ''      .BackColor = MyColors.LightestBlue
    ''      .ForeColor = MyColors.Blue
    ''      .Borders.BorderType = BorderTypeEnum.Flat
    ''      .Borders.Color = MyColors.LightestBlue
    ''      .Borders.Top = 1
    ''      .Borders.Left = 1
    ''      .Borders.Right = 1
    ''      .Borders.Bottom = 1
    ''   End With

    ''   With headingStyle
    ''      .Font = New Font(fontName, 10, FontStyle.Regular)
    ''      .BackColor = Color.White 'Color.FromArgb(196, 219, 249) ' light blue
    ''      .ForeColor = MyColors.Blue
    ''      .Borders.BorderType = BorderTypeEnum.Flat
    ''      .Borders.Color = MyColors.LightestBlue
    ''      .Borders.Top = 0
    ''      .Borders.Left = 0
    ''      .Borders.Right = 1
    ''      .Borders.Bottom = 0
    ''      '.HorizontalAlignment = AlignHorzEnum.Center ' doesn't work
    ''      ' as as side effect changes CaptionStyle.Borders.Color
    ''      '.Borders.Color = Color.FromArgb(127, 157, 185) ' grey blue
    ''   End With


    ''   With grid
    ''      .BorderStyle = BorderStyle.None
    ''      .BackColor = MyColors.LightestBlue
    ''      .AllowUpdate = False
    ''      .AllowDelete = False
    ''      .AllowSort = True
    ''      ' causes columns to keep proportions as grid size is adjusted (don't squish smaller than starting width)
    ''      .SpringMode = True
    ''      ' formats rows
    ''      .AlternatingRows = True
    ''      .OddRowStyle.BackColor = Color.White 'MyColors.LightestBlue
    ''      .EvenRowStyle.BackColor = Color.White
    ''      .RecordSelectors = False
    ''      .RowHeight = 22
    ''      .RowDivider.Style = LineStyleEnum.None
    ''      .ExtendRightColumn = True

    ''      ' formats main grid title
    ''      .Caption = "Testing Styles"
    ''      .CaptionHeight = 26

    ''      .Splits(0).ColumnCaptionHeight = 26

    ''      ' weird: must set border to none first, otherwise, all header borders change if you change one header border
    ''      .Splits(0).DisplayColumns(0).HeadingStyle.Borders.BorderType = BorderTypeEnum.None
    ''      .Splits(0).DisplayColumns(0).HeadingStyle.Borders.BorderType = BorderTypeEnum.Flat
    ''      .Splits(0).DisplayColumns(0).HeadingStyle.Borders.Color = MyColors.LightestBlue
    ''      .Splits(0).DisplayColumns(0).HeadingStyle.Borders.Left = 1
    ''      .Splits(0).DisplayColumns(0).HeadingStyle.Borders.Right = 1
    ''      '.Splits(0).DisplayColumns(0).HeadingStyle.Borders.Bottom = 1

    ''      For i As Integer = 0 To .Splits(0).DisplayColumns.Count - 1
    ''         ' horizontally aligns header
    ''         .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
    ''         ' shows column borders on right (column dividers)
    ''         .Splits(0).DisplayColumns(i).ColumnDivider.Style = LineStyleEnum.Single
    ''         ' colors column dividers
    ''         .Splits(0).DisplayColumns(i).ColumnDivider.Color = MyColors.LightestBlue
    ''         ' pads left side of cells
    ''         .Splits(0).DisplayColumns(i).Style.Padding.Left = 4
    ''         ' pads right side of cells
    ''         .Splits(0).DisplayColumns(i).Style.Padding.Right = 4
    ''      Next
    ''      ' shows left column border in first column. all right borders (dividers) are shown
    ''      .Splits(0).DisplayColumns(0).Style.Borders.BorderType = BorderTypeEnum.Flat
    ''      .Splits(0).DisplayColumns(0).Style.Borders.Color = MyColors.LightestBlue
    ''      .Splits(0).DisplayColumns(0).Style.Borders.Left = 1
    ''   End With
    ''End Sub


End Class
