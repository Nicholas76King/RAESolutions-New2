option strict off

imports system.data
imports DocumentFormat.OpenXml
imports DocumentFormat.OpenXml.Wordprocessing
Imports PriceSheetDataSet

Namespace Rae.RaeSolutions.Business.Entities.PriceSheets

public class price_sheet_table : inherits System.Data.DataTable
   property model as string
   property series as string
end class

public class options_elements

   function create(options_table as PriceSheetDataTable, common_options_table as PriceSheetDataTable) as list(of OpenXmlElement)
      dim groups = group_options_into_tables_by_model(options_table)
      dim tables = convert_data_tables_to_view_tables(groups)

      dim elements = new list(of OpenXmlElement)
      for each table in tables
         dim header = create_header_paragraph(table.model)
         dim word_table = create_table(table)

         elements.add(header)
         elements.add(word_table)
      next
      elements.add( create_header_paragraph("Common options - apply to every model in " & tables(0).series & " series") )
      dim common_options_view_table = convert_common_options_data_table_to_view_table(common_options_table)
      dim common_options_word_table = new rae.reporting.beta.price_sheet_table_factory().create(common_options_view_table)
      elements.add(common_options_word_table)

      return elements
   end function
   
   private function create_header_paragraph(text as string) as Paragraph
      dim paragraph = new _
         Paragraph(
            new ParagraphProperties(
               new SpacingBetweenLines() with {.Before="200", .After="0"}
            ),
            new Run(
               new RunProperties(
                  new Bold
               ),
               new Text(text)
            )
         )
      return paragraph
   end function

   private function convert_common_options_data_table_to_view_table(options as PriceSheetDataTable) as System.Data.DataTable
      dim common_table = new System.Data.DataTable
      common_table.columns.add("Code")
      common_table.columns.add("Category")
      common_table.columns.add("Description")
      ' don't show parent column for century because it's not used currently 9/15/2010
      if options.rows.count > 0 then
         dim parent_column_name = if(options.rows(0)("Division")="CRI", " ", "Parent")
         common_table.columns.add(parent_column_name)
      else
         common_table.columns.add("Parent")
      end if
      
      common_table.columns.add("Price")
      common_table.columns.add("Quantity")
      for each op as PriceSheetRow in options.rows
         dim price as string
         if op.Price = 999999 then
            price = "Standard"
         else if op.price = 999998 then
            price = "Contact Factory"
         else if op.price = 999997 then
            price = op.DependentPrice.ToString("$#,0")
         else
            price = op.price.toString("$#,0")
         end if
         dim quantity_text = if(op.Quantity = 0, "Per Each", "")
         ' don't include base list price. it's already in other table
         if not op.code = "BaseList" then
            common_table.rows.add(op.Code, op.Category, op.Description, op.ParentCode, price, quantity_text)
         end if
      next
      common_table.DefaultView.Sort = "Category ASC"

      return common_table.DefaultView.ToTable
   end function

   private function group_options_into_tables_by_model(options_table as PriceSheetDataTable) as list(of PriceSheetDataTable)
      'get distinct models
      dim unique_models = new list(of string)
      for each row as PriceSheetRow in options_table.rows
         if not unique_models.contains(row.model) then unique_models.add(row.model)
      next

      'puts matching models in same table
      dim groups = new list(of PriceSheetDataTable)
      for each model in unique_models
         dim group = new PriceSheetDataTable
         for each row as PriceSheetRow in options_table.rows
            if row.model = model then
               group.ImportRow(row)
            end if
         next
         groups.add(group)
      next

      'groups.sort()

      return groups
   end function

   private function convert_data_tables_to_view_tables(options_data_grouped_by_model as list(of PriceSheetDataTable)) as list(of price_sheet_table)
      dim tables = new list(of price_sheet_table)
      for each group in options_data_grouped_by_model
         ' view table - data formatted for viewing on screen
         dim table = new price_sheet_table
         table.columns.add("Code")
         table.columns.add("Category")
         table.columns.add("Description")
         ' don't show parent column for century because it's not used currently 9/15/2010
         if group.rows.count > 0 then
            dim parent_column_name = if(group.rows(0)("Division")="CRI", " ", "Parent")
            table.columns.add(parent_column_name)
         else
            table.columns.add("Parent")
         end if
         table.columns.add("Price")
         table.columns.add("Quantity")
            
         table.model = group.rows(0)("Series").ToString &  group.rows(0)("Model").ToString
         table.series = group.rows(0)("Series").ToString
         for each op as PriceSheetRow in group.rows
            dim price as string
            if op.Price = 999999 then
               price = "Standard"
            else if op.price = 999998 then
               price = "Contact Factory"
            else if op.price = 999997 then
               price = op.DependentPrice.ToString("$#,0")
            else
               price = op.price.toString("$#,0")
            end if
            dim quantity_text = if(op.Quantity = 0, "Per Each", "")
            table.rows.add(op.Code, op.Category, op.Description, op.ParentCode, price, quantity_text)
         next
         table.DefaultView.Sort = "Category ASC"

         dim table_view = table.DefaultView.ToTable
         for each row as System.Data.DataRow in table_view.rows
            if row("Category").ToString = "aaaBase List" then
               row("Category") = "Base List"
               exit for
            end if
         next
               
         table.rows.clear
         table.merge(table_view)

         tables.add(table)
      next
      return tables
   end function

   private function create_table(table_data as DataTable) as table
      dim table = new Table
      dim table_properties = new TableProperties

      dim table_style = new TableStyle
         table_style.Val = "LightShading"
      table_properties.append(table_style)

      dim table_width = new TableWidth
         table_width.width = "5000" '=100% measured in 1/50 of %
         table_width.type = TableWidthUnitValues.Pct
      table_properties.append(table_width)
      
      table.append(table_properties)
      table.append(new TableGrid)

      dim header_row = new TableRow
      for each data_column in table_data.columns
         dim cell = new TableCell(new Paragraph(new Run(new Text(data_column.ColumnName))))
         header_row.append(cell)
      next
      table.append(header_row)

      for each data_row in table_data.rows
         dim row = new TableRow
         for each data_column in table_data.columns
            dim value = data_row(ctype(data_column, DataColumn).ColumnName).ToString
            dim run_properties = new RunProperties(new FontSize with {.Val="16"}, new FontSizeComplexScript with {.Val="16"})
            dim cell = new TableCell(new Paragraph(new Run(run_properties, new Text(value))))
            row.append(cell)
         next
         table.append(row)
      next

      return table
   end function
end class

end namespace