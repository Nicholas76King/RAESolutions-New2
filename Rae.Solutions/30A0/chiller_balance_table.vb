Imports rae.solutions.evaporative_condenser_chillers
Imports rae.solutions.evaporative_condenser_chillers.balance
Imports rae.validation.validation_status


class evaporative_condenser_chiller_table
   public width, height as integer

   sub new(leaving_fluid_temp as double, ambient as double)
      table = new flowLayoutPanel()
      header_container = new flowLayoutPanel()
      cell_container = new flowLayoutPanel()
      
      me.leaving_fluid_temp = leaving_fluid_temp
      me.ambient = ambient
   end sub
   
   function create(points as point_list, using_custom_evaporator as boolean) as panel
      add_table()
        add_headers("Leaving Fluid Temp.", "Ambient", "Evaporating Temp.", "Condensing Temp.", "Est. Capacity", _
                  "Compressor Power", "Unit Power", "Compressor Efficiency", "Unit Efficiency", "Flow", "Evaporator Pressure Drop")
      add_toolbar()
      add_cell_container()
      if using_custom_evaporator then _
         add_foot_note()
      
      dim ambient_changed  = false
      dim alternate        = false
      dim previous_ambient = points(0).ambient
      for each point In points
         ambient_changed = not (point.ambient = previous_ambient)
         if ambient_changed then
            alternate = not alternate
         end if
         previous_ambient = point.ambient
         
         point.validators.validate()
         if point.validators.is_valid then
            add_row_valid(point, alternate)
         else
            add_row_invalid(point)
         end if

         for each message in point.validators.messages
            add_row(message)
         next
      next

      hide_invalid_rows()
      
      Return table
   End Function

   Sub show_invalid_rows()
      set_invalid_row_visibility(True)
   End Sub

   Sub hide_invalid_rows()
      set_invalid_row_visibility(False)
   End Sub



   Private table As Panel
   Private header_container, cell_container As FlowLayoutPanel
   private leaving_fluid_temp, ambient as double
   Const F As String = "°F"
   private alternate_color as color = mycolors.LighterBlue
   private highlight_color as color = mycolors.LightBlue
   
   

   private sub add_table()
      table = new panel()
         table.BorderStyle = BorderStyle.FixedSingle
         table.width = 904
         table.height = 376
         table.location = new drawing.point(10, 24)
         table.margin = new padding(0)
         table.padding = new padding(0)
   end sub
   
   private sub add_foot_note()
      dim foot_note_section = new panel()
      table.controls.add(foot_note_section)
         foot_note_section.width = 800
         foot_note_section.height = 22
         foot_note_section.margin = new padding(0)
         foot_note_section.padding = new padding(0)
         foot_note_section.dock = dockStyle.bottom
         foot_note_section.backcolor = color.AntiqueWhite
         foot_note_section.BorderStyle = BorderStyle.FixedSingle
         
      dim note = new label()
         note.dock = dockStyle.fill
         note.text = "* fluid pressure drop cannot be calculated when a custom evaporator is selected"
      
      foot_note_section.controls.add(note)
   end sub
   
   private sub add_toolbar()
      dim toolbar = new panel()
      table.controls.add(toolbar)
         toolbar.width = 800
         toolbar.height = 24
         toolbar.margin = new padding(0)
         toolbar.padding = new padding(0)
         toolbar.dock = dockStyle.top
         
      dim toggle_button = new rae.ui.Controls.toggleLink()
      toolbar.controls.add(toggle_button)
         toggle_button.width = 160
         toggle_button.height = 24
         toggle_button.margin = new padding(0)
         toggle_button.padding = new padding(0)
         toggle_button.text = "Show invalid results"
         toggle_button.TextToggled = "Hide invalid results"
         addHandler toggle_button.toggled, addressOf toggled
   end sub
   
   private sub toggled(link as rae.ui.controls.toggleLink, e as rae.ui.controls.ToggledEventArgs)
      if e.IsToggled
         show_invalid_rows()
      else
         hide_invalid_rows()
      end if
   end sub

   private sub set_invalid_row_visibility(visible as boolean)
      cell_container.suspendLayout()
      for each cell as control in cell_container.controls
         if typeOf cell is panel orelse typeOf cell is label
            if cell.backcolor <> color.white and cell.backColor <> highlight_color and cell.backColor <> alternate_color then
               cell.visible = visible
            end if
         end if
      next
      cell_container.resumeLayout(true)
   end sub

   private sub add_headers(paramarray header_names() as string)
      header_container = new flowlayoutpanel()
         table.controls.add(header_container)
         header_container.dock = dockstyle.top
         header_container.location = new drawing.point(0, 0)
         header_container.width = 100
         header_container.height = 37
         header_container.margin = new padding(0)
         header_container.padding = new padding(0)

      for each name as string in header_names
         header_container.controls.add(create_header(name))
      next
   end sub

   Private Sub add_cell_container()
      table.controls.add(cell_container)
         cell_container.margin = New padding(0)
         cell_container.padding = New padding(0)
         cell_container.autoScroll = True
         cell_container.dock = DockStyle.Fill
         cell_container.bringToFront()
   End Sub
   
   private function create_header(name as string) as label
      dim label = new label
         label.height = 37
         label.width = 80
         label.text = name
         label.textAlign = contentAlignment.middleCenter
         label.borderStyle = borderStyle.fixedSingle
         label.margin = new padding(0)
         label.padding = new padding(0)
      return label
   end function
   
   private sub add_row_valid(point as point, alternate as boolean)
      if me.leaving_fluid_temp = point.leaving_fluid_temp _
      and me.ambient = point.ambient then
         cell = addressOf highlighted_valid_cell
      elseIf alternate then
         cell = addressOf alternate_valid_cell
      else
         cell = addressOf valid_cell
      end if
      add(point)
   end sub
   
   private sub add_row_invalid(point as point)
      cell = addressOf invalid_cell
      add(point)
   end sub
   
   private sub add_row(message as rae.validation.message)
      dim label = new label()
      label.text = message.status.toString & " - " & message.description
      label.margin = new padding(0)
      label.padding = new padding(0)
      label.backColor = color.whiteSmoke
      label.width = 880
      label.height = 18
      if message.status = failure
         label.foreColor = color.fromargb(238, 0, 0)
      elseIf message.status = warning
         label.foreColor = color.fromargb(238, 118, 0)
      elseIf message.status = info
         label.foreColor = color.blue
      end if
      cell_container.controls.add(label)
   end sub
   
   private sub add(point as point)
      with cell_container.controls
         .add( cell.invoke(point.leaving_fluid_temp, F).cell )
         .add( cell.invoke(point.ambient, F).cell )
         .add( cell.invoke(point.evaporating_temp, F).cell )
         .add( cell.invoke(point.condensing_temp, F).cell )
         
         .add( cell.invoke(point.capacity, "tons").cell )
         .add( cell.invoke(point.compressor_kw, "kw").cell )
         .add( cell.invoke(point.unit_kw, "kw").cell )
         .add( cell.invoke(point.compressor_kw_per_ton.toString("#0.00"), "kw/ ton").cell )
         .add( cell.invoke(point.unit_kw_per_ton.toString("#0.00"), "kw/ ton").cell )
         .add( cell.invoke(point.gpm.toString("#0"), "gpm").cell )
         dim fluid_pd_to_display as string
         if point.fluid_pressure_drop >= 999 then
            fluid_pd_to_display = "*"
         else
            fluid_pd_to_display = point.fluid_pressure_drop.toString("#0.##")
         end if
         .add( cell.invoke(fluid_pd_to_display, "psi").cell )
      end with
   end sub
   
   private cell as cell_signature
   private delegate function cell_signature(value, unit) as value_unit_cell
   
   private function valid_cell(value, unit) as value_unit_cell
      return new value_unit_cell(value, unit)
   end function
   
   private function alternate_valid_cell(value, unit) as value_unit_cell
      dim c = new value_unit_cell(value, unit)
      c.cell.BackColor = alternate_color
      return c
   end function
   
   private function highlighted_valid_cell(value, unit) as value_unit_cell
      dim c = new value_unit_cell(value, unit)
      c.cell.backColor = highlight_color
      c.value_label.font = new font("tahoma", 10, fontStyle.bold)
      
      return c
   end function
   
   private function invalid_cell(value, unit) as value_unit_cell
      dim c = new value_unit_cell(value, unit)
      c.value_label.font = new font("tahoma", 8)
      c.cell.backColor = color.lightGray
      c.value_label.foreColor = color.dimGray
      return c
   end function
   
end class

class value_unit_cell
   sub new(value, unit)
      myBase.new()
      
      dim height = 28
      
      cell = new panel()
         cell.height = 28
         cell.width = 80
         cell.margin = new padding(0)
         cell.padding = new padding(0)
         cell.backColor = color.white
      
      value_label = new label()
         value_label.width = 50
         value_label.height = height
         value_label.margin = new padding(0)
         value_label.textAlign = contentAlignment.middleRight
         value_label.Font = new font("tahoma", 8, FontStyle.Regular)
         value_label.dock = dockStyle.right
         
      unit_label = new label()
         unit_label.width = 30
         unit_label.height = height
         unit_label.margin = new padding(0)
         unit_label.textAlign = ContentAlignment.MiddleLeft
         unit_label.dock = DockStyle.Right
         unit_label.font = new font("tahoma", 7, FontStyle.Regular)
         unit_label.foreColor = color.gray
         
      if typeOf value is double then
         value_label.text = cdbl(value).toString("#0.#")
      else
         value_label.text = value
      end if
      unit_label.text = unit
      
      cell.controls.add(value_label)
      cell.controls.add(unit_label)
   end sub
   
   public value_label, unit_label as label
   public cell as panel
end class


