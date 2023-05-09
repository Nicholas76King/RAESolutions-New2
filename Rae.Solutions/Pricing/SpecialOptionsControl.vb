Imports C1.Win.C1TrueDBGrid
Imports Rae.Core
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.DataAccess.Projects
Imports System
Imports Ta = Rae.RaeSolutions.DataAccess.Projects.Tables.SpecialOptionsTable



''' <summary>
''' Control to add and delete special options.
''' </summary>
''' <remarks>
''' Call Initialize before adding options.
''' </remarks>
Public Class SpecialOptionsControl

#Region " Events"

   Delegate Sub TotalPriceChangedEventHandler(ByVal sender As SpecialOptionsControl, ByVal totalPrice As Double)

   ''' <summary>
   ''' Occurs after/before ...
   ''' </summary>
   Public Event TotalPriceChanged As TotalPriceChangedEventHandler

   ''' <summary>
   ''' Raises <see cref="TotalPriceChanged" /> event.
   ''' </summary>
   ''' <param name="e">
   ''' Event arguments to pass in event.
   ''' Use System.EventArgs.Empty if no data is being passed.
   ''' </param>
   ''' <remarks>
   ''' Use this method to raise event rather than raising event directly.
   ''' Protected - Prevents other classes from raising event
   ''' Overridable - Allows derived classes to override implementation.
   ''' </remarks>
   Protected Overridable Sub OnTotalPriceChanged(ByVal totalPrice As Double)
      If Me.TotalPriceChangedEvent IsNot Nothing Then
         ' raises event
         RaiseEvent TotalPriceChanged(Me, totalPrice)
      End If
   End Sub




   ''' <summary>
   ''' Occurs after/before ...
   ''' </summary>
   Public Event DataSourceChanged As EventHandler(Of SpecialOptionsControl, EventArgs)

   ''' <summary>
   ''' Raises <see cref="DataSourceChanged" /> event.
   ''' </summary>
   ''' <param name="e">
   ''' Event arguments to pass in event.
   ''' Use System.EventArgs.Empty if no data is being passed.
   ''' </param>
   ''' <remarks>
   ''' Use this method to raise event rather than raising event directly.
   ''' Protected - Prevents other classes from raising event
   ''' Overridable - Allows derived classes to override implementation.
   ''' </remarks>
   Protected Overridable Sub OnDataSourceChanged(ByVal e As EventArgs)
      If Me.DataSourceChangedEvent IsNot Nothing Then
         ' raises event
         RaiseEvent DataSourceChanged(Me, e)
      End If
   End Sub

#End Region


#Region " Fields"

   Private m_Id As item_id
   Private m_AuthorizedFor As String

#End Region


#Region " Properties"

   ''' <summary>
   ''' Equipment ID.
   ''' </summary>
   Public ReadOnly Property Id() As item_id
      Get
         Return Me.m_Id
      End Get
   End Property


   ''' <summary>
   ''' Person special option is authorized for
   ''' </summary>
   Public ReadOnly Property AuthorizedFor() As String
      Get
         Return Me.m_AuthorizedFor
      End Get
   End Property


   ''' <summary>
   ''' TotalPrice
   ''' Total price of options for a single equipment.</summary>
    Public ReadOnly Property TotalPrice() As Double
        Get
            Return Me.CalculateTotalPrice()
        End Get
    End Property


    ''' <summary>
    ''' Special options list grid is bound to.
    ''' </summary>
    Public Property SpecialOptions() As SpecialOptionList
        Get
            If Me.opGrid.DataSource Is Nothing Then
                Return New SpecialOptionList() ' Nothing
            End If
            Return CType(Me.opGrid.DataSource, SpecialOptionList)
        End Get
        Set(ByVal value As SpecialOptionList)
            ''opGrid.DataSource = Nothing
            opGrid.DataSource = value
            ''opGrid.ApplyStyle()
            Me.opGrid.RowHeadersVisible = False
            Me.opGrid.Columns(Ta.Id).Visible = False
            Me.opGrid.Columns(Ta.EquipmentId).Visible = False
            Me.opGrid.Columns(Ta.AuthorizedFor).Visible = False
            Me.opGrid.Columns(Ta.Revision).Visible = False
            Me.opGrid.Columns(Ta.Quantity).Width = 55
            Me.opGrid.Columns(Ta.Code).Width = 45
            Me.opGrid.Columns(Ta.Description).Width = 244
            Me.opGrid.Columns(Ta.AuthorizedBy).Width = 88
            Me.opGrid.Columns(Ta.Price).Width = 65
            Me.opGrid.Columns(Ta.Quantity).DisplayIndex = 0
            Me.opGrid.Columns(Ta.Code).DisplayIndex = 1
            Me.opGrid.Columns(Ta.Description).DisplayIndex = 2
            Me.opGrid.Columns(Ta.AuthorizedBy).DisplayIndex = 3
            Me.opGrid.Columns(Ta.Price).DisplayIndex = 4
            Me.opGrid.Columns(Ta.Price).DefaultCellStyle.Format = "c2"
            Me.opGrid.Columns(Ta.Price).HeaderText = "Price Each"
            Me.opGrid.Columns(Ta.Description).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            ''Me.opGrid.Columns.Add("Price Each")
            Me.RefreshTotalPrice()
            Me.OnDataSourceChanged(System.EventArgs.Empty)
        End Set
    End Property

#End Region


#Region " Public methods"

    ''' <summary>
    ''' Initializes special options control.
    ''' </summary>
    ''' <param name="id">
    ''' Equipment ID.</param>
    ''' <param name="authorizedFor">
    ''' Person special option is authorized for</param>
    Public Sub Initialize(ByVal id As item_id, ByVal authorizedFor As String)
        Me.m_Id = id
        Me.m_AuthorizedFor = authorizedFor
    End Sub

#End Region


#Region " Private methods"

    ''Private Sub Grid_UnboundColumnFetch(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs) _
    ''Handles opGrid.UnboundColumnFetch
    ''    If e.Column.Caption = "Price Each" Then
    ''        e.Value = CType(Me.opGrid.Cells(Ta.Price).CellValue(e.Row), nullable_value(Of Double)).value.ToString("$#,##0")
    ''    End If
    ''End Sub


    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles btnAdd.Click
        Me.AddSpecialOption()
    End Sub


    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles btnEdit.Click
        Me.EditSpecialOption()
    End Sub


    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles btnDelete.Click
        Me.DeleteSelectedSpecialOption()
    End Sub


    Private Sub editSpecialOption()
        If Not Me.opGrid.Rows.Count > 0 Then
            Ui.MessageBox.Show("Please select a special option to edit.", MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim specialOptionToEdit As SpecialOption = Me.SpecialOptions(opGrid.CurrentRow.Index)
        Dim editForm As New SpecialOptionCreatorForm()
        editForm.ShowDialog(Id, New SpecialOptionList(), specialOptionToEdit)

        If editForm.DialogResult = DialogResult.OK Then
            ' refreshes view
            Me.SpecialOptions = Me.SpecialOptions.Clone()
        End If
    End Sub


    ''' <summary>
    ''' Opens creation form for user to add special option and adds option to grid.
    ''' </summary>
    Private Sub AddSpecialOption()
        Dim creatorForm As New SpecialOptionCreatorForm
        ' shows form for user to create a special option
        creatorForm.ShowDialog(Id, AuthorizedFor, Me.SpecialOptions)

        ' checks if a option was created
        If creatorForm.DialogResult = DialogResult.OK Then
            ' adds option
            Me.SpecialOptions.Add(creatorForm.SpecialOption)
            ' refreshes view
            Me.SpecialOptions = Me.SpecialOptions.Clone()
        End If
    End Sub


    ''' <summary>
    ''' Deletes selected special option in grid.
    ''' </summary>
    Private Sub DeleteSelectedSpecialOption()
        Dim i As Integer

        If Me.opGrid.Rows.Count > 0 AndAlso Me.opGrid.RowCount > -1 Then
            ' deletes from database
            Dim id As Integer = Me.opGrid.Rows(Me.opGrid.CurrentRow.Index).Cells(Ta.Id).Value.ToString
            '   SpecialOptionsDa.Delete(id)
            ' removes from object
            Me.SpecialOptions.RemoveAt(Me.opGrid.CurrentRow.Index)
            ' updates grid
            Me.SpecialOptions = Me.SpecialOptions.Clone()
        End If

    End Sub


    ''' <summary>
    ''' Calculates total price. Sets <see cref="TotalPrice" /> property.
    ''' </summary>
    Private Function CalculateTotalPrice() As Double
        Dim total As Double
        If Not Me.opGrid.RowCount > 0 Then
            ' there are no special options so total is 0
            total = 0
        Else
            ' calculates total price of all options
            For Each op As SpecialOption In Me.SpecialOptions
                ' quantity x price
                total += op.Quantity.value * op.Price.value
            Next
        End If
        Return total
    End Function


    ''' <summary>
    ''' Calculates total price, refreshes and formats label, and raises price changed event.
    ''' </summary>
    Private Sub RefreshTotalPrice()
        ' calculates total price
        Dim total As Double = Me.TotalPrice
        ' refreshes and formats label
        Me.lblTotalPrice.Text = total.ToString("c")
        ' raises total price changed event
        Me.OnTotalPriceChanged(total)
    End Sub

    Private Sub opGrid_MouseDown(sender As Object, e As MouseEventArgs) Handles opGrid.MouseDown

    End Sub

#End Region


End Class
