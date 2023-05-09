Imports C1.Win.C1TrueDBGrid
Imports Rae.RaeSolutions.Business
imports rae.solutions
Imports rae.solutions.condensing_units
Imports System.Data
Imports System.Math

Public Class BestSelectionsGrid
   Structure Input
      Public User As user
      Public CondensingUnitQuantity As Integer
      Public RunTime As Double
      Public Division As Division
   End Structure
   
   Sub SetSource(units As Best_Matches, input As Input)
      If      units.closest Is Nothing _
      AndAlso units.above   Is Nothing _
      AndAlso units.below   Is Nothing Then
         note.Visible = True
            dataGridView.DataSource = Nothing
        Else
         note.Visible = False
            dataGridView.DataSource = createTable(units, input)
            dataGridView.RowHeadersVisible = False
            dataGridView.Columns(0).Width = 175
            dataGridView.Columns(1).Width = 200
            dataGridView.Columns(2).Width = 200
            ''dataGridView.Columns(3).Width = 200
            dataGridView.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray

            dataGridView.EnableHeadersVisualStyles = False
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue
            format(input.User, input.Division)
        End If
      
   End Sub
   
   Private Function createTable(units As Best_Matches, input As Input) As DataTable
      
      
      Dim table = New DataTable("Best Selections")
      Dim column = New DataColumn("-")
      table.Columns.Add(column)
      
      table.Rows.Add("Model")
      table.Rows.Add("Evaporator Temp.")
      table.Rows.Add("Ambient Temp.")
      table.Rows.Add("Condenser Temp.")
        table.Rows.Add("Est. Capacity")
      table.Rows.Add("Run Time")
      table.Rows.Add("Unit [kW]")
        table.Rows.Add("Est. Condenser Capacity")
        table.Rows.Add("Unit Amps")
        table.Rows.Add("Unit EER")
      table.Rows.Add("Condenser TD")
      table.Rows.Add("Unit MCA @ 230")
      table.Rows.Add("Unit MCA @ 460")
      table.Rows.Add("Dimensions")
      
      addColumn(units.closest, input, table, "Closest")
      addColumn(units.above, input, table, "Above")
        addColumn(units.below, input, table, "Below")


        Return table
   End Function
   
   Private Sub addColumn(selection As Best_Matches.Selection, input As Input, table As DataTable, name As String)
      If selection IsNot Nothing Then
         Dim capacityPerUnit = selection.spec.Capacity / input.CondensingUnitQuantity
         Dim runTime = capacityPerUnit / selection.balance_point.capacity * input.RunTime
      
         Dim capacityDigits = If (AppInfo.Division=Division.CRI, 0, 1)
         Dim closestColumn = New DataColumn(name)
         table.Columns.Add(closestColumn)
         Dim c = table.Columns.Count - 1
         table.Rows(0)(c) = selection.unit.Model
         table.Rows(1)(c) = Round(selection.conditions.Suction, 1)
         table.Rows(2)(c) = Round(selection.conditions.Ambient, 1)
         table.Rows(3)(c) = Round(selection.balance_point.condensing_temp, 1)
         table.Rows(4)(c) = Round(selection.balance_point.capacity, capacityDigits)
         table.Rows(5)(c) = Round(runTime, 1)
         table.Rows(6)(c) = Round(selection.balance_point.unit_kw, 1)
         table.Rows(7)(c) = Round(selection.balance_point.condenser_capacity, capacityDigits)
         table.Rows(8)(c) = Round(selection.balance_point.unit_amps, 1)
         ' todo: remove duplicate
            'table.Rows(9)(c) = Round(selection.balance_point.unit_amps, 1)
            table.Rows(9)(c) = Round(selection.balance_point.unit_eer, 1)
            table.Rows(10)(c) = Round(selection.balance_point.td, 1)
            table.Rows(11)(c) = Round(selection.unit.mca_208, 1)
            table.Rows(12)(c) = Round(selection.unit.mca_460, 1)
            table.Rows(13)(c) = selection.unit.dimensions
      End If
   End Sub


    Private Sub format(user As user, div As Division)
        ''mVisualStyles.FormatC1Datagrid(Grid)

        ''Grid.Style.WrapText = True
        ''Grid.RowHeight = 21
        ''Grid.Splits(0).ColumnCaptionHeight = 30
        ''Grid.AllowRowSizing = RowSizingEnum.IndividualRows

        ''For Each col As C1.Win.C1TrueDBGrid.C1DisplayColumn In Grid.Splits(0).DisplayColumns
        ''    col.Width = (Grid.Width - 25) / Grid.Columns.Count
        ''Next

        ''If div = Division.TSI Then
        ''    Grid.Splits(0).Rows(5).Visible = False
        ''Else
        ''    Grid.Splits(0).Rows(5).Visible = True
        ''End If

        ''If user.authority_group = user_group.rep Then
        ''    'Condenser Temperature [F]
        ''    Grid.Splits(0).Rows(3).Visible = False
        ''    'Condenser Capacity [BTUH]
        ''    Grid.Splits(0).Rows(7).Visible = False
        ''    'Condenser T.D. [F]
        ''    Grid.Splits(0).Rows(11).Visible = False
        ''End If

        ''Grid.Splits(0).RecordSelectors = False

        ''Grid.RowDivider.Style = LineStyleEnum.None
        ''Grid.Styles("OddRow").BackColor = Color.LightBlue
        ''Grid.Style.VerticalAlignment = AlignVertEnum.Center
        ''Grid.Style.Padding.Left = 6

        footer.Text = "*  Ø voltage, 60 Hz at design conditions." _
           & Environment.NewLine & "**  Ø voltage, 60 Hz for condensing unit only. " &
           "Does not include any evaporator loads."
    End Sub

End Class
