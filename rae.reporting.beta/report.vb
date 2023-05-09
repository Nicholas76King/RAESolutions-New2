Option Strict Off

Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Validation
Imports DocumentFormat.OpenXml.Wordprocessing
Imports System.IO
Imports System.Linq
Imports ClosedXML.Excel
Imports rae.reporting.beta

Public Class report
    Private document As WordProcessingDocument
    Private body As body
    Private table_factory As i_table_factory

    Sub New(ByVal template_file_path As String)
        document = create_report_from_template(template_file_path)
        table_factory = New default_table_factory
        body = document.MainDocumentPart.Document.Body
    End Sub

    Sub New(ByVal template_file_path As String, ByVal fileNameBase As String)
        document = create_report_from_template(template_file_path, fileNameBase)
        table_factory = New default_table_factory
        body = document.MainDocumentPart.Document.Body
    End Sub



    Sub clear()
        body.removeAllChildren()
    End Sub

    Sub append_page_break()
        body.append(New Break With {.Type = BreakValues.Page})
    End Sub

    Sub append_document(ByVal file_path As String)
        Dim document = create_document(file_path)
        body.Append(document)
    End Sub

    Sub insert_document(ByVal tag As String, ByVal file_path As String)
        Dim document = create_document(file_path)

        Dim control = find_control_by_tag(tag)
        Dim parent = control.parent
        parent.InsertBeforeSelf(document)
    End Sub

    Sub append_elements(ByVal elements As list(Of OpenXmlElement))
        body.append(elements)
    End Sub

    Sub insert_elements(ByVal tag As String, ByVal elements As list(Of OpenXmlElement))
        Dim control = find_control_by_tag(tag)
        control.append(elements)
    End Sub

    Sub remove(ByVal tag As String)
        Dim control = find_control_by_tag(tag)
        control.remove()
    End Sub

    Sub remove_parent(ByVal tag As String, ByVal parent_type As type)
        Dim control = find_control_by_tag(tag)
        Dim parents = control.ancestors.where(Function(x) x.GetType.Equals(parent_type))
        If parents.count > 0 Then parents.first.remove()
    End Sub

    Sub set_list(ByVal tag As String, ByVal list As List(Of String))
        If tag.ToLower = "options" Then list.Sort()

        Dim all_controls = get_all_controls()
        For Each control In all_controls
            If tag = control.tag Then
                'control.set_text("")
                For Each item In list
                    Dim indent = item.StartsWith(" ")
                    If indent Then _
                       control.SdtContentRun.Append(generate_run(7))
                    control.SdtContentRun.Append(generate_run(item))
                Next
            End If
        Next
    End Sub



    Sub set_list(ByVal list As List(Of String))
        'control.set_text("")

        Dim para As New Paragraph()

        For Each item In List
            para.Append(generate_run(item))
        Next

        body.Append(para)

    End Sub

    Sub set_text(ByVal text As IDictionary(Of String, String))
        Dim all_controls = get_all_controls()

        For Each t In text

            Dim tValue As String
            If String.IsNullOrEmpty(t.Value) Then
                tValue = ""
            Else
                tValue = t.Value
            End If

            For Each content_control As SdtRun In all_controls
                If t.Key.ToLower = content_control.tag.ToLower Then


                    If Not tValue.Contains(System.Environment.NewLine) Then
                        content_control.set_text(tValue)
                    Else
                        Dim rows() As String = tValue.Split(System.Environment.NewLine)
                        content_control.set_text("")
                        For Each row As String In rows
                            content_control.InsertBeforeSelf(generate_run(row))
                        Next
                    End If
                End If
            Next
        Next
    End Sub

    'EMU_PER_PIXEL = 9525

    ' image in future could be in media folder inside docx file
    ' right now it's getting external image though
    Sub set_image(ByVal tag As String, ByVal image_file_path As String)
        Dim image_parts = find_image_parts(tag)

        Using stream = New FileStream(image_file_path, FileMode.Open)
            For Each image_part In image_parts
                image_part.FeedData(stream)
            Next
        End Using

        Dim image = New system.drawing.bitmap(image_file_path)

        Dim controls = get_all_controls
        For Each control As SdtRun In controls
            If tag = control.tag Then
                Dim extents = control.descendants(Of DocumentFormat.OpenXml.Drawing.Extents)()(0)
                extents.Cx = try_to_get_size_right(image.width)
                extents.Cy = try_to_get_size_right(image.height)
            End If
        Next

    End Sub





    Sub set_table(ByVal tag As String, ByVal table_data As Object, ByVal table_factory As i_table_factory)

        Me.table_factory = table_factory
        'If Not String.IsNullOrEmpty(table_data.ToString) Then
        '    Dim d As New Dictionary(Of String, String)
        '    d.Add("EquipmentOptions", "SSSS")
        '    set_text(d)
        'End If
        set_table(tag, table_data)

    End Sub

    Sub set_table(ByVal tag As String, ByVal table_data As Object, ByVal table_factory As i_table_factory, ByVal suctionTemp As Double, ByVal ambientTemp As Double)


        Me.table_factory = table_factory
        Dim table = table_factory.create(table_data, suctionTemp, ambientTemp)

        Dim control = find_control_by_tag(tag)
        control.Append(table)


    End Sub


    Sub set_table(ByVal tag As String, ByVal table_data As Object)

        Dim table
        If Not String.IsNullOrEmpty(table_data.ToString) Then
            table = table_factory.create(table_data, table_data.ToString)
        Else
            table = table_factory.create(table_data)
        End If


        Dim control = find_control_by_tag(tag)
        control.Append(table)
    End Sub


    Sub set_table(ByVal table_data As Object, ByVal table_factory As i_table_factory)

        Me.table_factory = table_factory
        set_table(table_data)

    End Sub

    Sub set_table(ByVal table_data As Object)
        Dim table = table_factory.create(table_data)

        body.Append(table)
    End Sub


    Sub mark_as_final()
        Dim settings = document.MainDocumentPart.DocumentSettingsPart.Settings

        Dim protection = New DocumentProtection
        protection.Edit = DocumentProtectionValues.ReadOnly
        protection.Enforcement = True

        settings.append(protection)
    End Sub

    Sub show(Optional ByVal currentLogo As String = "")
        validate()

        document.Close() 'initiates save

        If currentLogo <> "" Then
            Dim p As Process = New Process()
            Dim psi As ProcessStartInfo = New ProcessStartInfo()
            psi.CreateNoWindow = True
            psi.Verb = "print"
            psi.FileName = report_file_path
            p.StartInfo = psi
            p.Start()
        Else
            Process.Start(report_file_path)
        End If

    End Sub


    Sub close()
        validate()

        document.Close()
    End Sub

    Function generate() As String
        validate()

        document.close() 'initiates save
        Return report_file_path
    End Function

    Private Function find_control_by_tag(ByVal tag As String) As SdtElement
        Dim all_controls = get_all_controls

        Dim control As SdtElement
        For Each content_control As SdtRun In all_controls
            If tag = content_control.tag Then
                control = content_control
                Exit For
            End If
        Next

        If control Is Nothing Then
            Dim blocks = get_controls(Of SdtBlock)()
            For Each block As SdtBlock In blocks
                Dim block_tag = block.SdtProperties.ChildElements.OfType(Of Tag).First
                If Not block_tag Is Nothing AndAlso tag = block_tag.val Then
                    control = block
                    Exit For
                End If
            Next
        End If

        Return control
    End Function

    Private Function create_document(ByVal file_path As String) As AltChunk
        Static count As Integer = 0
        count += 1 ' blarg
        Dim id = "AltChunkId" & count
        Dim chunk = document.MainDocumentPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, id)
        chunk.FeedData(file.open(file_path, FileMode.Open))

        Dim alt_chunk = New AltChunk
        alt_chunk.id = id
        Return alt_chunk
    End Function

    ' based on online post i saw, haven't tested with different resolutions
    Private Function try_to_get_size_right(ByVal pixels As Integer) As Integer
        Return pixels * 8000 '9525
    End Function

    Private Function generate_run(ByVal number_of_spaces As Integer) As run
        Dim run = New run
        Dim properties = New RunProperties
        Dim fonts = New RunFonts With {.ComplexScriptTheme = ThemeFontValues.MinorHighAnsi}

        fonts.HighAnsi = "Arial"
        fonts.Ascii = "Arial"
        fonts.ComplexScript = "Arial"

        properties.append(fonts)


        Dim fontSize1 As New FontSize
        fontSize1.Val = 18

        properties.Append(fontSize1)

        run.append(properties)
        Dim spaces = ""
        For i = 0 To number_of_spaces - 1
            spaces &= " "
        Next
        run.append(New text() With {.Space = SpaceProcessingModeValues.Preserve,
                                    .Text = spaces})
        Return run
    End Function




    Private Function generate_run(ByVal text As String) As run
        Dim run = New run

        Dim properties = New RunProperties()
        Dim fonts = New RunFonts() With {.ComplexScriptTheme = ThemeFontValues.MinorHighAnsi}

        fonts.HighAnsi = "Arial"
        fonts.Ascii = "Arial"
        fonts.ComplexScript = "Arial"

        properties.append(fonts)

        Dim fontSize1 As New FontSize
        fontSize1.Val = 18

        properties.Append(fontSize1)

        run.append(properties)
        run.append(New text(text))
        run.append(New break)
        Return run
    End Function

    Private Function get_controls(Of t As SdtElement)() As list(Of t)
        Dim body_controls = body.descendants(Of t)()

        Dim footer_controls = New list(Of t)
        Dim footers = document.MainDocumentPart.FooterParts
        For Each footer In footers
            footer_controls.addRange(footer.RootElement.Descendants(Of t).ToList)
        Next

        Dim header_controls = New list(Of t)
        Dim headers = document.MainDocumentPart.HeaderParts
        For Each header In headers
            header_controls.AddRange(header.RootElement.Descendants(Of t).ToList)
        Next

        Dim all_controls = body_controls.ToList()
        all_controls.AddRange(footer_controls)
        all_controls.AddRange(header_controls)

        Return all_controls
    End Function

    Private Function get_all_controls() As list(Of sdtrun)
        Dim body_controls = body.descendants(Of SdtRun)()

        Dim footer_controls = New list(Of SdtRun)
        Dim footers = document.MainDocumentPart.FooterParts
        For Each footer In footers
            footer_controls.AddRange(footer.RootElement.Descendants(Of SdtRun).ToList)
        Next

        Dim header_controls = New list(Of SdtRun)
        Dim headers = document.MainDocumentPart.HeaderParts
        For Each header In headers
            header_controls.AddRange(header.RootElement.Descendants(Of SdtRun).ToList)
        Next

        Dim all_controls = body_controls.ToList()
        all_controls.AddRange(footer_controls)
        all_controls.AddRange(header_controls)

        Return all_controls
    End Function





    Shared Function generateRunWithFont(ByVal text As String, ByVal runFontSize As Integer, ByVal fontBold As Boolean, ByVal fontUnderline As Boolean) As Run
        Dim run = New Run

        Dim properties = New RunProperties()
        Dim fonts = New RunFonts() With {.ComplexScriptTheme = ThemeFontValues.MinorHighAnsi}

        Dim underline1 As New Underline

        If fontUnderline Then
            underline1.Val = UnderlineValues.Single
        Else
            underline1.Val = UnderlineValues.None
        End If


        If fontBold Then
            fonts.HighAnsi = "Arial Bold"
            fonts.Ascii = "Arial Bold"
            fonts.ComplexScript = "Arial Bold"
        Else
            fonts.HighAnsi = "Arial"
            fonts.Ascii = "Arial"
            fonts.ComplexScript = "Arial"
        End If



        properties.Append(fonts)

        properties.Append(underline1)

        Dim fontSize1 As New FontSize
        fontSize1.Val = runFontSize * 2

        properties.Append(fontSize1)


        run.Append(properties)
        run.Append(New Text(text))
        ' run.Append(New Break)
        Return run
    End Function



    ' match tag ' get sdt with drawing where sdt.tag = tag
    ' extent
    Private Function find_image_parts(ByVal tag As String) As IEnumerable(Of ImagePart)
        Return document.MainDocumentPart.HeaderParts(0).ImageParts
        'dim id_parts = document.MainDocumentPart.Parts.Where(function(x) TypeOf x.OpenXmlPart Is ImagePart)
        'dim image_parts = from part in id_parts
        '                  select part.OpenXmlPart
        'dim parts = image_parts.OfType(Of ImagePart)
        'return parts
    End Function

    Public Shared report_file_path As String



    Private Function create_report_from_template(ByVal template_file_path As String, Optional ByVal fileNameBase As String = "") As WordprocessingDocument
        Dim report_folder_path = My.Computer.FileSystem.SpecialDirectories.Temp ' my.computer.FileSystem.SpecialDirectories.Desktop

        Dim report_file_name As String

        If String.IsNullOrEmpty(fileNameBase) Then
            report_file_name = New FileInfo(template_file_path).Name
        Else
            report_file_name = fileNameBase
        End If

        report_file_name = report_file_name.delete("_template").delete(".docx")
        report_file_name &= "_" & date_as_string() & ".docx"
        report.report_file_path = Path.Combine(report_folder_path, report_file_name)

        File.Copy(template_file_path, report_file_path)

        Return WordprocessingDocument.Open(report_file_path, True)
    End Function

    Public Shared Function date_as_string() As String
        Threading.Thread.Sleep(2)
        Dim time = DateTime.Now
        date_as_string = time.Year.ToString("00") &
               time.Month.ToString("00") &
               time.Day.ToString("00") & "_" &
               time.Hour.ToString("00") &
               time.Minute.ToString("00") &
               time.Second.ToString("00") &
               time.Millisecond.ToString("0000")

    End Function

    Private Function validate() As String

        Dim nl = System.Environment.NewLine
        Try
            Dim validator = New OpenXmlValidator
            Dim count = 0
            For Each [error] As ValidationErrorInfo In validator.validate(document)
                count += 1
                Dim message As String = ""
                message &= "Error " & count & nl
                message &= "Description: " & [error].Description & nl
                message &= "ErrorType: " & [error].ErrorType & nl
                message &= "Node: " & [error].Node.ToString & nl
                message &= "Path: " & [error].Path.XPath & nl
                message &= "Part: " & [error].Part.ToString & nl
                message &= "-------------------------------------------" & nl
                debug.write(message)
            Next
        Catch ex As exception
            debug.WriteLine(ex.message)
        End Try

        Return Nothing
    End Function

End Class

Public Interface i_table_factory
    Overloads Function create(ByVal table_data As Object) As Table
    Overloads Function create(ByVal table_data As Object, ByVal title As String) As Table
    Overloads Function create(ByVal table_data As Object, ByVal suctionTemp As Double, ByVal AmbientTemp As Double) As Table
End Interface

Public Class box_load_table_factory : Implements i_table_factory

    Function create(ByVal table_data As Object, ByVal suctionTemp As Double, ByVal ambientTemp As Double) As Table Implements i_table_factory.create
        Throw New Exception("Overloaded function 'CREATE' not implemented.")
    End Function


    Function create(ByVal table_data As Object, ByVal title As String) As Table Implements i_table_factory.create
        Dim table = New Table
        Dim table_properties = New TableProperties

        Dim table_style = New TableStyle
        table_style.Val = "LightShading"
        table_properties.Append(table_style)

        Dim table_width = New TableWidth
        table_width.Width = "5000" '=100% measured in 1/50 of %
        table_width.Type = TableWidthUnitValues.Pct
        table_properties.Append(table_width)

        table.Append(table_properties)
        table.Append(New TableGrid)

        Dim titleRow As New TableRow
        Dim cellTitle = New TableCell(New Paragraph(New Run(New Text(title))))
        titleRow.Append(cellTitle)
        table.Append(titleRow)


        Dim header_row = New TableRow
        For Each data_column In table_data.columns
            Dim cell = New TableCell(New Paragraph(New Run(New Text(data_column.ColumnName))))
            header_row.Append(cell)
        Next
        table.Append(header_row)

        For Each data_row In table_data.rows
            Dim row = New TableRow
            For Each data_column In table_data.columns

                Dim value = data_row(CType(data_column, DataColumn).ColumnName).ToString
                Dim cell = New TableCell(New Paragraph(New Run(New Text(value))))
                row.Append(cell)


            Next
            table.Append(row)
        Next

        Return table
    End Function

    Function create(ByVal table_data As Object) As Table Implements i_table_factory.create
        Dim table = New Table
        Dim table_properties = New TableProperties

        Dim table_style = New TableStyle
        table_style.Val = "LightShading"
        table_properties.Append(table_style)

        Dim table_width = New TableWidth
        table_width.Width = "5000" '=100% measured in 1/50 of %
        table_width.Type = TableWidthUnitValues.Pct
        table_properties.Append(table_width)

        table.Append(table_properties)
        table.Append(New TableGrid)

        Dim header_row = New TableRow
        For Each data_column In table_data.columns
            Dim cell = New TableCell(New Paragraph(New Run(New Text(data_column.ColumnName))))
            header_row.Append(cell)
        Next
        table.Append(header_row)

        For Each data_row In table_data.rows
            Dim row = New TableRow
            For Each data_column In table_data.columns

                Dim value = data_row(CType(data_column, DataColumn).ColumnName).ToString
                Dim cell = New TableCell(New Paragraph(New Run(New Text(value))))
                row.Append(cell)


            Next
            table.Append(row)
        Next

        Return table
    End Function
End Class

Public Class price_sheet_table_factory : Implements i_table_factory

    Function create(ByVal table_data As Object, ByVal suctionTemp As Double, ByVal ambientTemp As Double) As Table Implements i_table_factory.create
        Throw New Exception("Overloaded function 'CREATE' not implemented.")
    End Function

    Function create(ByVal table_data As Object, ByVal title As String) As Table Implements i_table_factory.create
        '  Throw New Exception("Overloaded function 'CREATE' not implemented.")
        create(table_data)
    End Function

    Function create(ByVal table_data As Object) As table Implements i_table_factory.create
        Dim table = New Table
        Dim table_properties = New TableProperties

        Dim table_style = New TableStyle
        table_style.Val = "LightShading"
        table_properties.append(table_style)

        Dim table_width = New TableWidth
        table_width.width = "5000" '=100% measured in 1/50 of %
        table_width.type = TableWidthUnitValues.Pct
        table_properties.append(table_width)

        table.append(table_properties)
        table.append(New TableGrid)

        Dim header_row = New TableRow
        For Each data_column In table_data.columns
            Dim cell = New TableCell(New Paragraph(New Run(New Text(data_column.ColumnName))))
            header_row.append(cell)
        Next
        table.append(header_row)

        For Each data_row In table_data.rows
            Dim row = New TableRow
            For Each data_column In table_data.columns
                Dim value = data_row(CType(data_column, DataColumn).ColumnName).ToString
                Dim run_properties = New RunProperties(New FontSize With {.Val = "16"}, New FontSizeComplexScript With {.Val = "16"})
                Dim cell = New TableCell(New Paragraph(New Run(run_properties, New Text(value))))
                row.append(cell)
            Next
            table.append(row)
        Next

        Return table
    End Function
End Class



Public Class Generic_table_factory : Implements i_table_factory


    Function create(ByVal table_data As Object, ByVal suctionTemp As Double, ByVal ambientTemp As Double) As Table Implements i_table_factory.create
        Throw New Exception("Overloaded function 'CREATE' not implemented.")
    End Function


    Function create(ByVal table_data As Object, ByVal title As String) As Table Implements i_table_factory.create
        Throw New Exception("Overloaded function 'CREATE' not implemented.")
        '  create(table_data)
    End Function



    Function create(ByVal table_data As Object) As Table Implements i_table_factory.create
        'Dim table = New Table
        'Dim table_properties = New TableProperties

        'Dim table_style = New TableStyle
        'table_style.Val = "TableGrid"
        'table_properties.Append(table_style)

        'table.Append(table_properties)
        'table.Append(New TableGrid)


        Dim table = New Table
        Dim table_properties = New TableProperties
        Dim table_style = New TableStyle
        table_style.Val = "LightList-Accent1"
        table_properties.Append(table_style)
        Dim table_width = New TableWidth
        table_width.Width = "4850"
        table_width.Type = TableWidthUnitValues.Pct
        table_properties.Append(table_width)
        table.Append(table_properties)
        table.Append(New TableGrid)


        'Dim HRrow = New TableRow

        'For Each data_column In table_data.columns

        '    Dim paragraph1 As New Paragraph(report.generateRunWithFont(".", 1, False, False))

        '    Dim HRcell = New TableCell(paragraph1)


        '    Dim cellProperties As New TableCellProperties

        '    Dim shading1 As New Shading
        '    shading1.Val = ShadingPatternValues.Clear
        '    shading1.Color = "auto"
        '    shading1.Fill = "000000"


        '    cellProperties.Append(shading1)

        '    HRcell.Append(cellProperties)
        '    HRrow.Append(HRcell)

        'Next

        'table.Append(HRrow)


        Dim cr As Integer = 0

        Dim header_row = New TableRow
        For Each data_column In table_data.columns
            ' Dim cell = New TableCell(New Paragraph(New Run(New Text(data_column.ColumnName))))


            Dim cell = New TableCell(New Paragraph(report.generateRunWithFont(data_column.ColumnName, 9, True, False)))

            '    If cr Mod 2 = 1 Then
            Dim cellProperties As New TableCellProperties

            Dim shading1 As New Shading
            shading1.Val = ShadingPatternValues.Clear
            shading1.Color = "auto"
            shading1.Fill = "EFEFEF"

            cellProperties.Append(shading1)

            cell.Append(cellProperties)
            'End If

            cr += 1

            header_row.Append(cell)
        Next



        table.Append(header_row)


        Dim HRrow2 = New TableRow

        For Each data_column In table_data.columns

            Dim paragraph1 As New Paragraph(report.generateRunWithFont(".", 1, False, False))

            Dim HRcell = New TableCell(paragraph1)


            Dim cellProperties As New TableCellProperties

            Dim shading1 As New Shading
            shading1.Val = ShadingPatternValues.Clear
            shading1.Color = "auto"
            shading1.Fill = "000000"


            cellProperties.Append(shading1)

            HRcell.Append(cellProperties)
            HRrow2.Append(HRcell)

        Next

        table.Append(HRrow2)


        For Each data_row In table_data.rows
            Dim row = New TableRow

            cr = 0

            For Each data_column In table_data.columns

                Dim value = data_row(CType(data_column, DataColumn).ColumnName).ToString
                Dim cell = New TableCell(New Paragraph(report.generateRunWithFont(value, 9, False, False)))


                'If cr Mod 2 = 1 Then
                '    Dim cellProperties As New TableCellProperties

                '    Dim shading1 As New Shading
                '    shading1.Val = ShadingPatternValues.Clear
                '    shading1.Color = "auto"
                '    shading1.Fill = "F0EAC6"

                '    cellProperties.Append(shading1)

                '    cell.Append(cellProperties)
                'End If


                row.Append(cell)
                cr += 1


            Next
            table.Append(row)
        Next


        Return table
    End Function



End Class



Public Class default_table_factory : Implements i_table_factory


    Function create(ByVal table_data As Object, ByVal title As String) As Table Implements i_table_factory.create
        Dim table = New Table
        Dim table_properties = New TableProperties

        Dim table_style = New TableStyle
        table_style.Val = "LightShading"
        table_properties.Append(table_style)

        Dim table_width = New TableWidth
        table_width.Width = "5000" '=100% measured in 1/50 of %
        table_width.Type = TableWidthUnitValues.Pct
        table_properties.Append(table_width)

        table.Append(table_properties)
        table.Append(New TableGrid)

        Dim titleRow As New TableRow
        Dim cellH1 = New TableCell(New Paragraph(New Run(New Text(" "))))
        titleRow.Append(cellH1)
        Dim cellH2 = New TableCell(New Paragraph(New Run(New Text(" "))))
        titleRow.Append(cellH2)

        Dim cellTitle = New TableCell(New Paragraph(New Run(New Text(title))))
        titleRow.Append(cellTitle)
        table.Append(titleRow)


        Dim header_row = New TableRow
        For Each data_column In table_data.columns
            If Not data_column.Caption.ToLower = "longdescription" Then
                Dim cell = New TableCell(New Paragraph(New Run(New Text(data_column.ColumnName))))
                header_row.Append(cell)
            End If
        Next
        table.Append(header_row)


        Dim i As Integer = 0

        For Each data_row In table_data.rows
            Dim row1 = New TableRow
            Dim row2 = New TableRow
            For Each data_column As DataColumn In table_data.columns
                If Not data_column.Caption.ToLower = "longdescription" Then
                    Dim value = data_row(CType(data_column, DataColumn).ColumnName).ToString
                    Dim cell = New TableCell(New Paragraph(New Run(New Text(value))))

                    If i Mod 2 = 0 Then
                        Dim cellProperties As New TableCellProperties
                        Dim shading1 As New Shading
                        shading1.Val = ShadingPatternValues.Clear
                        shading1.Color = "auto"
                        shading1.Fill = "DEE7FF"
                        cellProperties.Append(shading1)
                        cell.Append(cellProperties)
                    End If

                    row1.Append(cell)
                Else

                    Dim cellS1 = New TableCell(New Paragraph(New Run(New Text(" "))))

                    If i Mod 2 = 0 Then
                        Dim cellProperties As New TableCellProperties
                        Dim shading1 As New Shading
                        shading1.Val = ShadingPatternValues.Clear
                        shading1.Color = "auto"
                        shading1.Fill = "DEE7FF"
                        cellProperties.Append(shading1)
                        cellS1.Append(cellProperties)
                    End If

                    row2.Append(cellS1)
                    Dim cellS2 = New TableCell(New Paragraph(New Run(New Text(" "))))


                    If i Mod 2 = 0 Then
                        Dim cellProperties As New TableCellProperties
                        Dim shading1 As New Shading
                        shading1.Val = ShadingPatternValues.Clear
                        shading1.Color = "auto"
                        shading1.Fill = "DEE7FF"
                        cellProperties.Append(shading1)
                        cellS2.Append(cellProperties)
                    End If


                    row2.Append(cellS2)


                    Dim value = data_row(CType(data_column, DataColumn).ColumnName).ToString
                    Dim cell = New TableCell(New Paragraph(New Run(New Text(value))))

                    If i Mod 2 = 0 Then
                        Dim cellProperties As New TableCellProperties
                        Dim shading1 As New Shading
                        shading1.Val = ShadingPatternValues.Clear
                        shading1.Color = "auto"
                        shading1.Fill = "DEE7FF"
                        cellProperties.Append(shading1)
                        cell.Append(cellProperties)
                    End If




                    row2.Append(cell)





                End If

            Next
            If row1.HasChildren Then table.Append(row1)
            If row2.HasChildren Then table.Append(row2)

            i += 1
        Next



        'For Each data_row In table_data.rows
        '    Dim row = New TableRow
        '    For Each data_column In table_data.columns

        '        Dim value = data_row(CType(data_column, DataColumn).ColumnName).ToString
        '        Dim cell = New TableCell(New Paragraph(New Run(New Text(value))))
        '        row.Append(cell)

        '    Next
        '    table.Append(row)
        'Next



        Return table
    End Function


    Function create(ByVal table_data As Object, ByVal suctionTemp As Double, ByVal ambientTemp As Double) As Table Implements i_table_factory.create
        Throw New Exception("Overloaded function 'CREATE' not implemented.")
    End Function


    Function create(ByVal table_data As Object) As Table Implements i_table_factory.create
        Dim table = New Table
        Dim table_properties = New TableProperties

        Dim table_style = New TableStyle
        table_style.Val = "TableGrid"
        table_properties.Append(table_style)

        table.Append(table_properties)
        table.Append(New TableGrid)

        Dim cr As Integer = 0

        Dim header_row = New TableRow
        For Each data_column In table_data.columns
            '            Dim cell = New TableCell(New Paragraph(New Run(New Text(data_column.ColumnName))))
            Dim cell = New TableCell(New Paragraph(report.generateRunWithFont(data_column.ColumnName, 9, True, False)))

            If cr Mod 2 = 1 Then
                Dim cellProperties As New TableCellProperties

                Dim shading1 As New Shading
                shading1.Val = ShadingPatternValues.Clear
                shading1.Color = "auto"
                shading1.Fill = "F0EAC6"

                cellProperties.Append(shading1)

                cell.Append(cellProperties)
            End If

            cr += 1

            header_row.Append(cell)
        Next



        table.Append(header_row)


        Dim HRrow = New TableRow

        For Each data_column In table_data.columns

            Dim paragraph1 As New Paragraph(report.generateRunWithFont(".", 2, False, False))

            Dim HRcell = New TableCell(paragraph1)


            Dim cellProperties As New TableCellProperties

            Dim shading1 As New Shading
            shading1.Val = ShadingPatternValues.Clear
            shading1.Color = "auto"
            shading1.Fill = "943634"


            cellProperties.Append(shading1)

            HRcell.Append(cellProperties)
            HRrow.Append(HRcell)

        Next

        table.Append(HRrow)


        For Each data_row In table_data.rows
            Dim row = New TableRow

            cr = 0

            For Each data_column In table_data.columns

                Dim value = data_row(CType(data_column, DataColumn).ColumnName).ToString
                Dim cell = New TableCell(New Paragraph(report.generateRunWithFont(value, 9, False, False)))


                If cr Mod 2 = 1 Then
                    Dim cellProperties As New TableCellProperties

                    Dim shading1 As New Shading
                    shading1.Val = ShadingPatternValues.Clear
                    shading1.Color = "auto"
                    shading1.Fill = "F0EAC6"

                    cellProperties.Append(shading1)

                    cell.Append(cellProperties)
                End If


                row.Append(cell)
                cr += 1


            Next
            table.Append(row)
        Next


        Return table
    End Function



End Class


Public Class condensing_unit_report_table_factory : Implements i_table_factory

    Function create(ByVal table_data As Object, ByVal suctionTemp As Double, ByVal ambientTemp As Double) As Table Implements i_table_factory.create
        Dim table = New Table
        Dim table_properties = New TableProperties

        Dim table_style = New TableStyle
        table_style.Val = "TableGrid"
        table_properties.Append(table_style)

        table.Append(table_properties)
        table.Append(New TableGrid)

        Dim cr As Integer = 0

        Dim header_row = New TableRow
        For Each data_column In table_data.columns
            '            Dim cell = New TableCell(New Paragraph(New Run(New Text(data_column.ColumnName))))
            Dim cell = New TableCell(New Paragraph(report.generateRunWithFont(data_column.ColumnName, 10, False, False)))

            If cr Mod 2 = 1 Then
                Dim cellProperties As New TableCellProperties

                Dim shading1 As New Shading
                shading1.Val = ShadingPatternValues.Clear
                shading1.Color = "auto"
                shading1.Fill = "F0EAC6"

                cellProperties.Append(shading1)

                cell.Append(cellProperties)
            End If

            cr += 1

            header_row.Append(cell)
        Next



        table.Append(header_row)


        Dim HRrow = New TableRow

        For Each data_column In table_data.columns

            Dim paragraph1 As New Paragraph(report.generateRunWithFont(".", 2, False, False))

            Dim HRcell = New TableCell(paragraph1)


            Dim cellProperties As New TableCellProperties

            Dim shading1 As New Shading
            shading1.Val = ShadingPatternValues.Clear
            shading1.Color = "auto"
            shading1.Fill = "943634"

            cellProperties.Append(shading1)

            HRcell.Append(cellProperties)
            HRrow.Append(HRcell)

        Next

        table.Append(HRrow)


        For Each data_row In table_data.rows
            Dim row = New TableRow

            cr = 0

            Dim isDesignPoint As Boolean = False

            If data_row(0).ToString.StartsWith((suctionTemp.ToString)) AndAlso data_row(1).ToString.StartsWith((ambientTemp.ToString)) Then
                isDesignPoint = True
            End If

            For Each data_column In table_data.columns

                Dim value = data_row(CType(data_column, DataColumn).ColumnName).ToString
                Dim cell = New TableCell(New Paragraph(report.generateRunWithFont(value, 9, isDesignPoint, isDesignPoint)))


                If cr Mod 2 = 1 Then
                    Dim cellProperties As New TableCellProperties

                    Dim shading1 As New Shading
                    shading1.Val = ShadingPatternValues.Clear
                    shading1.Color = "auto"
                    shading1.Fill = "F0EAC6"

                    cellProperties.Append(shading1)

                    cell.Append(cellProperties)
                End If


                row.Append(cell)
                cr += 1


            Next
            table.Append(row)
        Next


        Return table
    End Function


    Function create(ByVal table_data As Object) As Table Implements i_table_factory.create
        Throw New Exception("Overloaded function 'CREATE' not implemented.")
    End Function

    Function create(ByVal table_data As Object, ByVal title As String) As Table Implements i_table_factory.create
        Throw New Exception("Overloaded function 'CREATE' not implemented.")
    End Function


End Class



Public Class exavorative_condensor_chiller_balance_report_table_factory : Implements i_table_factory

    Function create(ByVal table_data As Object, ByVal leavingFluid As Double, ByVal ambientWetTemp As Double) As Table Implements i_table_factory.create
        Dim table = New Table
        Dim table_properties = New TableProperties

        Dim table_style = New TableStyle
        table_style.Val = "TableGrid"
        table_properties.Append(table_style)

        table.Append(table_properties)
        table.Append(New TableGrid)

        Dim cr As Integer = 0

        Dim header_row = New TableRow
        For Each data_column In table_data.columns
            '            Dim cell = New TableCell(New Paragraph(New Run(New Text(data_column.ColumnName))))
            Dim cell = New TableCell(New Paragraph(report.generateRunWithFont(data_column.ColumnName, 10, False, False)))

            If cr Mod 2 = 1 Then
                Dim cellProperties As New TableCellProperties

                Dim shading1 As New Shading
                shading1.Val = ShadingPatternValues.Clear
                shading1.Color = "auto"
                shading1.Fill = "F0EAC6"

                cellProperties.Append(shading1)

                cell.Append(cellProperties)
            End If

            cr += 1

            header_row.Append(cell)
        Next



        table.Append(header_row)


        Dim HRrow = New TableRow

        For Each data_column In table_data.columns

            Dim paragraph1 As New Paragraph(report.generateRunWithFont(".", 2, False, False))

            Dim HRcell = New TableCell(paragraph1)


            Dim cellProperties As New TableCellProperties

            Dim shading1 As New Shading
            shading1.Val = ShadingPatternValues.Clear
            shading1.Color = "auto"
            shading1.Fill = "943634"

            cellProperties.Append(shading1)

            HRcell.Append(cellProperties)
            HRrow.Append(HRcell)

        Next

        table.Append(HRrow)


        For Each data_row In table_data.rows
            Dim row = New TableRow

            cr = 0

            Dim isDesignPoint As Boolean = False

            If data_row(0).ToString.StartsWith((leavingFluid.ToString)) AndAlso data_row(1).ToString.StartsWith((ambientWetTemp.ToString)) Then
                isDesignPoint = True
            End If

            For Each data_column In table_data.columns

                Dim value = data_row(CType(data_column, DataColumn).ColumnName).ToString
                Dim cell = New TableCell(New Paragraph(report.generateRunWithFont(value, 9, isDesignPoint, isDesignPoint)))


                If cr Mod 2 = 1 Then
                    Dim cellProperties As New TableCellProperties

                    Dim shading1 As New Shading
                    shading1.Val = ShadingPatternValues.Clear
                    shading1.Color = "auto"
                    shading1.Fill = "F0EAC6"

                    cellProperties.Append(shading1)

                    cell.Append(cellProperties)
                End If


                row.Append(cell)
                cr += 1


            Next
            table.Append(row)
        Next


        Return table
    End Function


    Function create(ByVal table_data As Object) As Table Implements i_table_factory.create
        Throw New Exception("Overloaded function 'CREATE' not implemented.")
    End Function

    Function create(ByVal table_data As Object, ByVal title As String) As Table Implements i_table_factory.create
        Throw New Exception("Overloaded function 'CREATE' not implemented.")
    End Function


End Class


Public Class AIR_COOLED_CHILLER_report_table_factory : Implements i_table_factory

    Function create(ByVal table_data As Object, ByVal suctionTemp As Double, ByVal ambientTemp As Double) As Table Implements i_table_factory.create
        Dim table = New Table
        Dim table_properties = New TableProperties

        Dim table_style = New TableStyle
        table_style.Val = "TableGrid"
        table_properties.Append(table_style)

        table.Append(table_properties)
        table.Append(New TableGrid)

        Dim cr As Integer = 0

        Dim header_row = New TableRow
        For Each data_column In table_data.columns
            '            Dim cell = New TableCell(New Paragraph(New Run(New Text(data_column.ColumnName))))
            Dim cell = New TableCell(New Paragraph(report.generateRunWithFont(data_column.ColumnName, 10, False, False)))

            If cr Mod 2 = 1 Then
                Dim cellProperties As New TableCellProperties

                Dim shading1 As New Shading
                shading1.Val = ShadingPatternValues.Clear
                shading1.Color = "auto"
                shading1.Fill = "F0EAC6"

                cellProperties.Append(shading1)

                cell.Append(cellProperties)
            End If

            cr += 1

            header_row.Append(cell)
        Next



        table.Append(header_row)


        Dim HRrow = New TableRow

        For Each data_column In table_data.columns

            Dim paragraph1 As New Paragraph(report.generateRunWithFont(".", 2, False, False))

            Dim HRcell = New TableCell(paragraph1)


            Dim cellProperties As New TableCellProperties

            Dim shading1 As New Shading
            shading1.Val = ShadingPatternValues.Clear
            shading1.Color = "auto"
            shading1.Fill = "943634"

            cellProperties.Append(shading1)

            HRcell.Append(cellProperties)
            HRrow.Append(HRcell)

        Next

        table.Append(HRrow)


        For Each data_row In table_data.rows
            Dim row = New TableRow

            cr = 0

            Dim isDesignPoint As Boolean = False

            If data_row(0).ToString.StartsWith((suctionTemp.ToString)) AndAlso data_row(1).ToString.StartsWith((ambientTemp.ToString)) Then
                isDesignPoint = True
            End If

            For Each data_column In table_data.columns

                Dim value = data_row(CType(data_column, DataColumn).ColumnName).ToString
                Dim cell = New TableCell(New Paragraph(report.generateRunWithFont(value, 9, isDesignPoint, isDesignPoint)))


                If cr Mod 2 = 1 Then
                    Dim cellProperties As New TableCellProperties

                    Dim shading1 As New Shading
                    shading1.Val = ShadingPatternValues.Clear
                    shading1.Color = "auto"
                    shading1.Fill = "F0EAC6"

                    cellProperties.Append(shading1)

                    cell.Append(cellProperties)
                End If


                row.Append(cell)
                cr += 1


            Next
            table.Append(row)
        Next


        Return table
    End Function


    Function create(ByVal table_data As Object) As Table Implements i_table_factory.create
        Throw New Exception("Overloaded function 'CREATE' not implemented.")
    End Function

    Function create(ByVal table_data As Object, ByVal title As String) As Table Implements i_table_factory.create
        Throw New Exception("Overloaded function 'CREATE' not implemented.")
    End Function


End Class


Public Class order_write_up_table_factory : Implements i_table_factory

    Function create(ByVal table_data As Object, ByVal suctionTemp As Double, ByVal ambientTemp As Double) As Table Implements i_table_factory.create
        Throw New Exception("Overloaded function 'CREATE' not implemented.")
    End Function


    Function create(ByVal table_data As Object, ByVal title As String) As Table Implements i_table_factory.create
        Throw New Exception("Overloaded function 'CREATE' not implemented.")
        '    create(table_data)
    End Function


    Function create(ByVal table_data As Object) As table Implements i_table_factory.create
        Dim table = New Table
        Dim table_properties = New TableProperties
        Dim table_style = New TableStyle
        table_style.Val = "LightList-Accent1"
        table_properties.append(table_style)
        Dim table_width = New TableWidth
        table_width.width = "4850"
        table_width.Type = TableWidthUnitValues.Pct
        table_properties.append(table_width)
        table.append(table_properties)
        table.append(New TableGrid)

        Dim descriptionCol As Integer = -1
        Dim k As Integer = 0

        Dim header_row = New TableRow
        For Each data_column In table_data.columns
            Dim cell = New TableCell(New Paragraph(New Run(New Text(data_column.ColumnName))))
            header_row.Append(cell)
            If data_column.ColumnName.ToString.ToLower = "code" Then
                descriptionCol = k
            End If
            k += 1
        Next
        table.Append(header_row)


        Dim sortedTable As DataTable = table_data.clone

        If descriptionCol >= 0 Then
            Dim sList As New List(Of String)
            For Each data_row In table_data.Rows
                sList.Add(data_row(descriptionCol).ToString)
            Next

            sList.Sort()

            For Each s1 As String In sList
                For Each data_row In table_data.rows
                    If data_row(descriptionCol).ToString = s1 Then
                        sortedTable.ImportRow(data_row)
                    End If
                Next
            Next




        Else
            For Each data_row In table_data.rows
                sortedTable.ImportRow(data_row)
            Next
        End If



        For Each data_row In sortedTable.rows
            Dim row = New TableRow
            For Each data_column In table_data.columns
                Dim value = data_row(CType(data_column, DataColumn).ColumnName).ToString
                Dim cell = New TableCell(New Paragraph(New Run(New Text(value))))
                row.Append(cell)
            Next
            table.Append(row)
        Next

        Return table
    End Function
End Class



Public Class proposal_table_factory : Implements i_table_factory

    Function create(ByVal table_data As Object, ByVal suctionTemp As Double, ByVal ambientTemp As Double) As Table Implements i_table_factory.create
        Throw New Exception("Overloaded function 'CREATE' not implemented.")
    End Function


    Function create(ByVal table_data As Object, ByVal title As String) As Table Implements i_table_factory.create
        Throw New Exception("Overloaded function 'CREATE' not implemented.")
        '    create(table_data)
    End Function


    Function create(ByVal table_data As Object) As table Implements i_table_factory.create
        Dim table = New Table
        Dim table_properties = New TableProperties
        Dim table_style = New TableStyle
        table_style.Val = "LightList-Accent1"
        table_properties.append(table_style)
        Dim table_width = New TableWidth
        table_width.width = "4850"
        table_width.Type = TableWidthUnitValues.Pct
        table_properties.append(table_width)

        'Dim tableBorder As New TableBorders()
        'tableBorder.add()




        Dim tblBorders As New TableBorders()



        Dim topBorder As New TopBorder()
        topBorder.Val = BorderValues.BasicThinLines
        topBorder.Color = "000000"
        tblBorders.AppendChild(topBorder)

        Dim bottomBorder As New BottomBorder()
        bottomBorder.Val = BorderValues.BasicThinLines
        bottomBorder.Color = "000000"
        tblBorders.AppendChild(bottomBorder)

        Dim leftBorder As New LeftBorder()
        leftBorder.Val = BorderValues.BasicThinLines
        leftBorder.Color = "000000"
        tblBorders.AppendChild(leftBorder)

        Dim rightBorder As New RightBorder()
        rightBorder.Val = BorderValues.BasicThinLines
        rightBorder.Color = "000000"
        tblBorders.AppendChild(rightBorder)

        Dim insideHorizBorder As New InsideHorizontalBorder()
        insideHorizBorder.Val = BorderValues.BasicThinLines
        insideHorizBorder.Color = "000000"
        tblBorders.AppendChild(insideHorizBorder)

        Dim insideVertBorder As New InsideVerticalBorder()
        insideVertBorder.Val = BorderValues.BasicThinLines
        insideVertBorder.Color = "000000"
        tblBorders.AppendChild(insideVertBorder)

        table_properties.AppendChild(tblBorders)

        table.Append(table_properties)
        table.append(New TableGrid)

        Dim header_row = New TableRow
        For Each data_column In table_data.columns
            Dim cell = New TableCell(New Paragraph(New Run(New Text(data_column.ColumnName))))

            Dim cellProperties As New TableCellProperties

            Dim shading1 As New Shading
            shading1.Val = ShadingPatternValues.Clear
            shading1.Color = "auto"
            shading1.Fill = "000000"

            cellProperties.Append(shading1)

            cell.Append(cellProperties)

            header_row.Append(cell)
        Next
        table.append(header_row)

        For Each data_row In table_data.rows
            Dim row = New TableRow
            For Each data_column In table_data.columns
                Dim value = data_row(CType(data_column, DataColumn).ColumnName).ToString
                Dim cell = New TableCell(New Paragraph(New Run(New Text(value))))






                row.Append(cell)
            Next
            table.append(row)
        Next

        Return table
    End Function
End Class


'Public Class ExcelReport
'    Public document As SpreadsheetDocument
'    Private report_file_path As String
'    Public Property WorksheetID As String


'    Sub New(ByVal template_file_path As String)
'        document = create_report_from_template(template_file_path)
'        WorksheetID = GetWorksheetID()
'        '   table_factory = New default_table_factory
'        '  body = document.MainDocumentPart.Document.Body
'    End Sub

'    Private Function create_report_from_template(ByVal template_file_path As String, Optional ByVal fileNameBase As String = "") As SpreadsheetDocument
'        Dim report_folder_path = My.Computer.FileSystem.SpecialDirectories.Temp ' my.computer.FileSystem.SpecialDirectories.Desktop

'        Dim report_file_name As String

'        If String.IsNullOrEmpty(fileNameBase) Then
'            report_file_name = New FileInfo(template_file_path).Name
'        Else
'            report_file_name = fileNameBase
'        End If

'        report_file_name = report_file_name.delete("_template").delete(".xlsx")
'        report_file_name &= "_" & report.date_as_string() & ".xlsx"
'        Me.report_file_path = Path.Combine(report_folder_path, report_file_name)

'        File.Copy(template_file_path, report_file_path)

'        Return SpreadsheetDocument.Open(report_file_path, True)
'    End Function

'    Private Sub validate()

'    End Sub




'    Private Function GetWorksheetID() As String
'        Dim sSheetName As String
'        Dim sheetID As String = String.Empty
'        Dim WorkbookSheets As Spreadsheet.Sheets = document.WorkbookPart.Workbook.GetFirstChild(Of Spreadsheet.Sheets)()

'        For Each childSheet As Spreadsheet.Sheet In WorkbookSheets
'            sSheetName = childSheet.Name
'            sSheetName = sSheetName.ToLower.Trim
'            Return childSheet.Id
'            'rename worksheet
'            'If sSheetName = "sheet1" Then
'            '    childSheet.Name = "MySheet"

'            '    sheetID = childSheet.Id
'            'End If
'        Next

'        Return sheetID
'    End Function


'    Public Sub SetStrCellValue(ByVal iRow As Integer, ByVal col As Integer, ByVal newCellValue As String)
'        Dim Location As String = GetColumnLetter(col) & iRow.ToString

'        SetStrCellValue(Location, newCellValue)
'    End Sub


'    Public Sub SetStrCellValue(ByVal location As String, ByVal newCellValue As String)
'        Dim wsPart As WorksheetPart = CType(document.WorkbookPart.GetPartById(WorksheetID), WorksheetPart)
'        Dim Cell As Spreadsheet.Cell = wsPart.Worksheet.Descendants(Of Spreadsheet.Cell).Where(Function(c) c.CellReference = location).FirstOrDefault
'        ' Dim Border As Spreadsheet.Border = wsPart.Worksheet.Descendants(Of Spreadsheet.Border).Where(Function(c) c.CellReference = location).FirstOrDefault


'        If String.IsNullOrEmpty(newCellValue) Then newCellValue = ""

'        'If Cell Is Nothing Then
'        '    Cell = New Spreadsheet.Cell
'        '    Cell.CellReference = location
'        '    Cell.StyleIndex = 1
'        '    Cell.CellValue = New Spreadsheet.CellValue(newCellValue.ToString)
'        '    Cell.DataType = Spreadsheet.CellValues.String
'        '    wsPart.Worksheet.AppendChild(Cell)
'        'Else
'        Cell.CellValue = New Spreadsheet.CellValue(newCellValue.ToString)
'        Cell.DataType = Spreadsheet.CellValues.String

'        'If doBorder Then
'        '    Dim wbPart As WorkbookPart = CType(document.WorkbookPart.GetPartById(WorksheetID), WorkbookPart)
'        '    Dim wbPart2 As WorksheetPart = document.WorkbookPart.GetPartById(WorksheetID)

'        '    Dim b As Spreadsheet.Border = wbPart.WorkbookStylesPart.Stylesheet.Elements(Of Spreadsheet.Border).FirstOrDefault
'        '    b = GenerateBorder()
'        'End If

'        '        End If





'    End Sub

















'    Private Function GetColumnLetter(ByVal colNumber As Integer) As String
'        Dim columnLetter As String = String.Empty
'        Dim abc As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

'        If colNumber > 26 Then
'            columnLetter = abc.Substring(CInt(colNumber / 26) - 1, 1)
'        End If

'        columnLetter += abc.Substring(((colNumber - 1) Mod 26), 1)

'        Return columnLetter
'    End Function

'    Sub show()
'        validate()
'        document.WorkbookPart.Workbook.Save()


'        document.Close() 'initiates save
'        Process.Start(report_file_path)
'    End Sub


'    Function generate() As String
'        validate()

'        document.Close() 'initiates save
'        Return report_file_path
'    End Function

'End Class


Public Class ExcelReportClosed
    Public document As XLWorkbook
    Private report_file_path As String
    ' Public Property WorksheetID As String


    Sub New(ByVal template_file_path As String)
        document = create_report_from_template(template_file_path)
        '  WorksheetID = GetWorksheetID()
        '   table_factory = New default_table_factory
        '  body = document.MainDocumentPart.Document.Body
    End Sub

    Private Function create_report_from_template(ByVal template_file_path As String, Optional ByVal fileNameBase As String = "") As XLWorkbook
        Dim report_folder_path = My.Computer.FileSystem.SpecialDirectories.Temp ' my.computer.FileSystem.SpecialDirectories.Desktop

        Dim report_file_name As String

        If String.IsNullOrEmpty(fileNameBase) Then
            report_file_name = New FileInfo(template_file_path).Name
        Else
            report_file_name = fileNameBase
        End If

        report_file_name = report_file_name.delete("_template").delete(".xlsx")
        report_file_name &= "_" & report.date_as_string() & ".xlsx"
        Me.report_file_path = Path.Combine(report_folder_path, report_file_name)

        File.Copy(template_file_path, report_file_path)

        Return New XLWorkbook(report_file_path, False)
    End Function

    Private Sub validate()

    End Sub




    'Private Function GetWorksheetID() As String
    '    Dim sSheetName As String
    '    Dim sheetID As String = String.Empty
    '    Dim WorkbookSheets As Spreadsheet.Sheets = document.WorkbookPart.Workbook.GetFirstChild(Of Spreadsheet.Sheets)()

    '    For Each childSheet As Spreadsheet.Sheet In WorkbookSheets
    '        sSheetName = childSheet.Name
    '        sSheetName = sSheetName.ToLower.Trim
    '        Return childSheet.Id
    '        'rename worksheet
    '        'If sSheetName = "sheet1" Then
    '        '    childSheet.Name = "MySheet"

    '        '    sheetID = childSheet.Id
    '        'End If
    '    Next

    '    Return sheetID
    'End Function


    'Public Sub SetStrCellValue(ByVal iRow As Integer, ByVal col As Integer, ByVal newCellValue As String)
    '    Dim Location As String = GetColumnLetter(col) & iRow.ToString

    '    SetStrCellValue(Location, newCellValue)
    'End Sub


    'Public Sub SetStrCellValue(ByVal location As String, ByVal newCellValue As String)
    '    Dim wsPart As WorksheetPart = CType(document.WorkbookPart.GetPartById(WorksheetID), WorksheetPart)
    '    Dim Cell As Spreadsheet.Cell = wsPart.Worksheet.Descendants(Of Spreadsheet.Cell).Where(Function(c) c.CellReference = location).FirstOrDefault
    '    ' Dim Border As Spreadsheet.Border = wsPart.Worksheet.Descendants(Of Spreadsheet.Border).Where(Function(c) c.CellReference = location).FirstOrDefault


    '    If String.IsNullOrEmpty(newCellValue) Then newCellValue = ""

    '    'If Cell Is Nothing Then
    '    '    Cell = New Spreadsheet.Cell
    '    '    Cell.CellReference = location
    '    '    Cell.StyleIndex = 1
    '    '    Cell.CellValue = New Spreadsheet.CellValue(newCellValue.ToString)
    '    '    Cell.DataType = Spreadsheet.CellValues.String
    '    '    wsPart.Worksheet.AppendChild(Cell)
    '    'Else
    '    Cell.CellValue = New Spreadsheet.CellValue(newCellValue.ToString)
    '    Cell.DataType = Spreadsheet.CellValues.String

    '    'If doBorder Then
    '    '    Dim wbPart As WorkbookPart = CType(document.WorkbookPart.GetPartById(WorksheetID), WorkbookPart)
    '    '    Dim wbPart2 As WorksheetPart = document.WorkbookPart.GetPartById(WorksheetID)

    '    '    Dim b As Spreadsheet.Border = wbPart.WorkbookStylesPart.Stylesheet.Elements(Of Spreadsheet.Border).FirstOrDefault
    '    '    b = GenerateBorder()
    '    'End If

    '    '        End If





    'End Sub

















    Private Function GetColumnLetter(ByVal colNumber As Integer) As String
        Dim columnLetter As String = String.Empty
        Dim abc As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

        If colNumber > 26 Then
            columnLetter = abc.Substring(CInt(colNumber / 26) - 1, 1)
        End If

        columnLetter += abc.Substring(((colNumber - 1) Mod 26), 1)

        Return columnLetter
    End Function

    Sub show()
        validate()
        document.Save()
        '        document.WorkbookPart.Workbook.Save()


        '  document.Close() 'initiates save
        Process.Start(report_file_path)
    End Sub


    Function generate() As String
        validate()

        document.Save() 'initiates save
        Return report_file_path
    End Function

End Class
