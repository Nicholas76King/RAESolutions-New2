Imports rae.solutions.chiller_evaporators

Public Class EvaporatorGrid

   Private evaporators As List(Of evaporator)
   
   Sub Show(evaporators As List(Of evaporator))
      setSource(evaporators)
        If evaporators IsNot Nothing Then
            style()
        End If

    End Sub
   
   Sub SetNumCircuits(numCircuits As Integer)
      Me.numCircuits = numCircuits
      setVisibility(numCircuits)
   End Sub
   
   Private numCircuits As Integer
   
   Function GetEvaporatorAt(approach As Integer) As evaporator
      Return getEvaporatorAtApproach(approach, Me.evaporators)
   End Function
   
   Function CustomSelected As Boolean
      Return rboCustom.Checked
   End Function
   
   Function CustomCapacityCircuit1Approach8 As Double
      Return txtCustomCapacity1At8.Text
   End Function
   
   Function CustomCapacityCircuit1Approach10 As Double
      Return txtCustomCapacity1At10.Text
   End Function
   
   Function CustomCapacityCircuit2Approach8 As Double
      Return txtCustomCapacity2At8.Text
   End Function
   
   Function CustomCapacityCircuit2Approach10 As Double
      Return txtCustomCapacity2At10.Text
   End Function

   Function SelectedApproachIsInvalid As Boolean
      Dim lowerApproach = SelectedLowerApproach
      Dim upperApproach = SelectedUpperApproach
      Return (lowerApproach Is Nothing OrElse lowerApproach.capacity = 0) _
      OrElse (upperApproach Is Nothing OrElse upperApproach.capacity = 0)
   End Function
   
   Function CustomCapacityIsZero() As Boolean
      If CustomCapacityCircuit1Approach8 = 0 Or CustomCapacityCircuit1Approach10 = 0 Then
         Return True
      End If
      If numCircuits > 1 Then
         If CustomCapacityCircuit2Approach8 = 0 Or CustomCapacityCircuit2Approach10 = 0 Then
            Return True
         End If
      End If
      Return False
   End Function
   
   Function SelectedLowerApproach As evaporator
      Dim evaporator As evaporator
      
      If rbo6To8.Checked
         evaporator = getEvaporatorAtApproach(6, evaporators)
      ElseIf rbo7To9.Checked
         evaporator = getEvaporatorAtApproach(7, evaporators)
      ElseIf rbo8To10.Checked
         evaporator = getEvaporatorAtApproach(8, evaporators)
      ElseIf rbo9To11.Checked
         evaporator = getEvaporatorAtApproach(9, evaporators)
      ElseIf rbo10To12.Checked
         evaporator = getEvaporatorAtApproach(10, evaporators)
      End If
      
      Return evaporator
   End Function
   
   Function SelectedUpperApproach As evaporator
      Dim evaporator As evaporator
      
      If rbo6To8.Checked
         evaporator = getEvaporatorAtApproach(8, evaporators)
      ElseIf rbo7To9.Checked
         evaporator = getEvaporatorAtApproach(9, evaporators)
      ElseIf rbo8To10.Checked
         evaporator = getEvaporatorAtApproach(10, evaporators)
      ElseIf rbo9To11.Checked
         evaporator = getEvaporatorAtApproach(11, evaporators)
      ElseIf rbo10To12.Checked
         evaporator = getEvaporatorAtApproach(12, evaporators)
      End If
      
      Return evaporator
   End Function
   
   Sub ShowApproachSelection()
      setApproachSelectionVisibility(visible:=True)
   End Sub
   
   Sub HideApproachSelection()
      setApproachSelectionVisibility(visible:=False)
   End Sub


    Private Sub style()
        ''Dim warningColumnName = "warnings_message"
        ''Dim warningColumn = DataGridView1.Columns(warningColumnName)
        ''Dim toEnd = DataGridView1.Columns.Count - 1

        ''DataGridView1.Columns(warningColumnName).DisplayIndex = toEnd
        ''''Rae.Ui.C1GridStyles.BasicGridStyle(Grid)

        ''Dim approachColumnName = "approach"
        ''Dim approachColumn = Grid.Splits(0).DisplayColumns(approachColumnName)
        ''approachColumn.Width = 70
        ''''approachColumn.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        ''Grid.Columns(approachColumnName).NumberFormat = "#"

        ''Dim capacityColumnName = "capacity"
        ''Dim capacityColumn = DataGridView1.Columns(capacityColumnName)
        ''capacityColumn.Width = 65
        ''capacityColumn.Columns(capacityColumnName).NumberFormat = "###,###,###"

        ''Dim fluidPdColumnName = "fluid_pressure_drop"
        ''Dim fluidPdColumn = Grid.Splits(0).DisplayColumns(fluidPdColumnName)
        ''fluidPdColumn.Width = 40
        ''fluidPdColumn.DataColumn.Caption = "Fluid PD"
        ''fluidPdColumn.DataColumn.NumberFormat = "#.00"

        ''Dim fluidFlowColumnName = "fluid_flow"
        ''Dim fluidFlowColumn = Grid.Splits(0).DisplayColumns(fluidFlowColumnName)
        ''fluidFlowColumn.Width = 50
        ''fluidFlowColumn.DataColumn.Caption = "Fluid Flow"
        ''fluidFlowColumn.DataColumn.NumberFormat = "###,###"

        ''Dim refrigerantPdColumnName = "refrigerant_pressure_drop"
        ''Dim refrigerantPdColumn = Grid.Splits(0).DisplayColumns(refrigerantPdColumnName)
        ''refrigerantPdColumn.Width = 70
        ''refrigerantPdColumn.DataColumn.Caption = "Refrigerant PD"
        ''refrigerantPdColumn.DataColumn.NumberFormat = "#.00"

        ''Dim refrigerantFlowColumnName = "refrigerant_flow"
        ''Dim refrigerantFlowColumn = Grid.Splits(0).DisplayColumns(refrigerantFlowColumnName)
        ''refrigerantFlowColumn.Width = 80
        ''refrigerantFlowColumn.DataColumn.Caption = "Refrigerant Flow"
        ''refrigerantFlowColumn.DataColumn.NumberFormat = "###,###"

        ''Dim nozzleColumnName = "fluid_nozzle"
        ''Dim nozzleColumn = Grid.Splits(0).DisplayColumns(nozzleColumnName)
        ''nozzleColumn.Width = 60
        ''nozzleColumn.DataColumn.Caption = "Fluid Nozzle"
        ''nozzleColumn.DataColumn.NumberFormat = "###,####"

        ''Grid.Splits(0).ColumnCaptionHeight = 32
        ''Grid.RowHeight = 24
        ''Grid.Splits(0).DisplayColumns(warningColumnName).Style.WrapText = True
        ''Grid.Splits(0).ExtendRightColumn = True
    End Sub

    Private Sub setSource(evaporators As List(Of evaporator))
        DataGridView1.DataSource = evaporators
        Me.evaporators = evaporators
        DataGridView1.Columns(2).HeaderText = "Fluid PD"
        DataGridView1.Columns(3).HeaderText = "Fluid Flow"
        DataGridView1.Columns(4).HeaderText = "Refrigerant PD"
        DataGridView1.Columns(5).HeaderText = "Refrigerant Flow"
        DataGridView1.Columns(6).HeaderText = "Fluid Nozzle"
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray
        DataGridView1.EnableHeadersVisualStyles = False
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue
    End Sub
   
   Private Sub setApproachSelectionVisibility(visible As Boolean)
      rbo6To8.Visible = visible
      rbo7To9.Visible = visible
      rbo8To10.Visible = visible
      rbo9To11.Visible = visible
      rbo10To12.Visible = visible
   End Sub
   
   Private Sub setApproachSelectionEnabled(enabled As Boolean)
      rbo6To8.Enabled = enabled
      rbo7To9.Enabled = enabled
      rbo8To10.Enabled = enabled
      rbo9To11.Enabled = enabled
      rbo10To12.Enabled = enabled
   End Sub
   
   Private Function getEvaporatorAtApproach(approach As Integer, evaporators As List(Of evaporator)) As evaporator
      For Each evaporator In evaporators
         If evaporator.approach = approach Then _
            Return evaporator
      Next
   End Function

   Private Sub rboCustom_CheckedChanged() Handles rboCustom.CheckedChanged
      setVisibility(numCircuits)
      setHeight()
   End Sub
   
   Private Sub setVisibility(numCircuits As Integer)
      If CustomSelected Then
         panCustom.Visible = True
         Dim multipleCircuits = (numCircuits > 1)
         txtCustomCapacity2At8.Visible  = multipleCircuits
         txtCustomCapacity2At10.Visible = multipleCircuits
      Else
         panCustom.Visible = False
         txtCustomCapacity2At8.Visible  = False
         txtCustomCapacity2At10.Visible = False
      End If
   End Sub
   
   Private Sub setHeight()
      If CustomSelected Then
         Height += panCustom.Height
         Me.Parent.Height = Me.Parent.Height + panCustom.Height
      Else
         Height -= panCustom.Height
         Me.Parent.Height = Me.Parent.Height - panCustom.Height
      End If
   End Sub
   
End Class
