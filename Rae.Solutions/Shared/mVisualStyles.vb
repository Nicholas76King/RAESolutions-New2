Module mVisualStyles

    'formats ComponentOne datagrids, so that they'll all look the same
    'Public Sub FormatC1Datagrid(ByRef sender As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
    '   Dim dark As New Drawing.Color
    '   dark = Color.Navy

    '   'GENERAL PROPERTIES
    '   'readonly
    '   sender.AllowAddNew = False
    '   sender.AllowUpdate = False
    '   sender.AllowDelete = False
    '   sender.AllowRowSelect = True
    '   sender.FlatStyle        = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat
    '   sender.BorderStyle      = BorderStyle.FixedSingle
    '   sender.RowHeight        = 16
    '   sender.AlternatingRows  = True
    '   sender.BackColor        = Color.White

    '   'cell borders
    '   sender.Splits(0).Style.Borders.BorderType = C1.Win.C1TrueDBGrid.BorderTypeEnum.Flat
    '   sender.Splits(0).Style.Borders.Color = dark
    '   sender.Splits(0).Style.Borders.Bottom = 1
    '   sender.Splits(0).Style.Borders.Right = 1
    '   sender.Splits(0).Style.Borders.Top = 0
    '   sender.Splits(0).Style.Borders.Left = 0

    '   'NORMAL STYLE	cell backcolor
    '   sender.Styles("Normal").BackColor = Color.White

    '   'HIGHLIGHT STYLE
    '   sender.Styles("HighlightRow").BackColor = dark
    '   sender.Styles("HighlightRow").ForeColor = Color.White

    '   'HEADING STYLE (column headers, record selector, caption)
    '   'column header background image
    '   Dim columnHeaderBackgroundImage As Image
    '     ''columnHeaderBackgroundImage = Image.FromFile(AppInfo.AppFolderPath & "images\lightBlueGradient2.bmp")
    '     sender.Styles("Heading").BackgroundImage = columnHeaderBackgroundImage
    '   'column header background image sizing
    '   sender.Styles("Heading").BackgroundPictureDrawMode = C1.Win.C1TrueDBGrid.BackgroundPictureDrawModeEnum.Stretch
    '   'column header wrap text
    '   sender.Styles("Heading").WrapText = True
    '   'column header back color
    '   sender.Styles("Heading").BackColor = Drawing.SystemColors.InactiveCaption
    '   'column header vertical alignment
    '   sender.Styles("Heading").VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
    '   'column header font
    '   Dim myFont As Font
    '   myFont = New Font("Arial", 8, FontStyle.Regular)
    '   sender.Styles("Heading").Font = myFont
    '   sender.Styles("Heading").ForeColor = dark
    '   sender.Styles("Heading").Borders.Color = dark
    '   sender.Styles("Heading").Borders.Bottom = 1
    '   sender.Styles("Heading").Borders.Right = 1
    '   sender.Styles("Heading").Borders.BorderType = C1.Win.C1TrueDBGrid.BorderTypeEnum.Flat
    '   'column header alignment
    '   Dim i As Integer
    '   For i = 0 To sender.Splits(0).DisplayColumns.Count - 1
    '      sender.Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    '   Next

    '   'CAPTION STYLE
    '   'caption font
    '   myFont = New Font("Arial", 10, FontStyle.Bold)
    '   sender.Styles("Caption").Font = myFont
    '   sender.Styles("Caption").ForeColor = Color.White
    '   'caption background color
    '   sender.Styles("Caption").BackColor = dark
    '   'caption background image
    '   Dim captionBackgroundImage As Image
    '     ''captionBackgroundImage = Image.FromFile(AppInfo.AppFolderPath & "images\blueGradient.bmp")
    '     sender.Styles("Caption").BackgroundImage = captionBackgroundImage
    '   'caption background image sizing
    '   sender.Styles("Caption").BackgroundPictureDrawMode = C1.Win.C1TrueDBGrid.BackgroundPictureDrawModeEnum.Stretch
    '   'caption height
    '   sender.CaptionHeight = 20

    '   'EVEN ROW STYLE back color
    '   sender.Styles("EvenRow").BackColor = Color.White

    '   'RECORD SELECTOR STYLE back color
    '   sender.Styles("RecordSelector").BackColor = dark

    '   'horizontal alignment (doesn't work)
    '   sender.Styles("Normal").HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    '   'column header horizontal alignment (doesn't work)
    '   sender.Styles("Heading").HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    '   'caption horizontal alignment (doesn't work)
    '   sender.Styles("Caption").HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    'End Sub

End Module
