Imports C1.Win.C1TrueDBGrid
Imports Rae.Collections
Imports Cols = Rae.RaeSolutions.DataAccess.Projects.Tables.OptionsObjectTable
Imports System.Collections.Generic
Imports System.Data

''' <summary>Specialized grid for showing equipment options.</summary>
''' <remarks>
''' Grid handles display row and data row access more conveniently when grid is grouped.
''' Idioms:
''' display index - refers to the row index that allows you to access presentation/UI properties (ex. CellStyle)
''' data index - refers to the row index that allows you to access data properties (ex. CellValue)
'''
''' The C1 grid has a quirk in how it forces you to access the display properties diffently than the data properties.
''' The data index and display index are different when the grid is grouped.
''' The display index (e.Row) counts group headers and only visible data rows; 
''' it is the Row in FetchCellStyleEventArgs and FetchCellTipsEventArgs.
''' The data index only counts data rows (both hidden and shown); it does not count group headers.
''' To determine the index for data this equation can be used.
''' dataIndex = displayIndex - groupHeadersAbove + hiddenRowsAbove
''' </remarks>
Public Class OptionGrid
    Inherits DataGridView
    'Inherits C1.Win.C1TrueDBGrid.Grid

    Sub New()
        MyBase.New()
    End Sub

    ''' <summary>Gets the data row index based on the display row index.</summary>
    Function GetDataRow(ByVal displayRow As Integer) As Integer
        Dim dataRow As Integer

        ''If IsGrouped Then
        dataRow = convertToDataRow(displayRow)
            ''Else
            ''    dataRow = displayRow
            ''End If

            Return dataRow
    End Function

    Overridable Sub ApplyStyle()
        ''Rae.Ui.C1GridStyles.BasicGridStyle(Me)
    End Sub

    ''' <summary>Returns data source as DataTable since this grid only works with the options data table.</summary>
    Protected ReadOnly Property table As DataTable
        Get
            Return CType(DataSource, DataTable)
        End Get
    End Property


#Region " Workaround"

    Private Function convertToDataRow(ByVal displayRow As Integer) As Integer
        Dim out_numHiddenRowsAbove, out_numGroupsAbove As Integer
        getVariablesToCalculateDataIndex(displayRow,
                                         out_numHiddenRowsAbove, out_numGroupsAbove)

        Dim dataIndex = displayRow - out_numGroupsAbove + out_numHiddenRowsAbove

        Return dataIndex
    End Function

    Private Sub getVariablesToCalculateDataIndex(ByVal displayRow As Integer,
       ByRef out_hiddenRowsAboveDisplayRow As Integer, ByRef out_groupHeadingsAboveDisplayRow As Integer)

        Dim groups = getEachCategoryAndItsContainedOptions()

        getNumHiddenRowsAboveAndNumGroupsAbove(displayRow, groups,
           out_hiddenRowsAboveDisplayRow, out_groupHeadingsAboveDisplayRow)
    End Sub

    Private Function getEachCategoryAndItsContainedOptions() As SortedDictionary(Of String, Integer)
        Dim groups = New SortedDictionary(Of String, Integer)

        Dim table = CType(DataSource, DataTable)

        Dim row As DataRow
        For Each row In table.Rows
            Dim category As String
            category = row(Cols.Category).ToString()

            If Not groups.ContainsKey(category) Then
                ' adds new categories
                groups.Add(category, 1)
            Else
                ' sums number of options in a category
                groups(category) += 1
            End If
        Next

        Return groups
    End Function

    Private Sub getNumHiddenRowsAboveAndNumGroupsAbove(
    ByVal displayRow As Integer, ByVal sortGroups As IDictionary(Of String, Integer),
    ByRef out_hiddenRowsAbove As Integer, ByRef out_groupsAbove As Integer)

        Dim categoryIndex As Integer : Dim reversedIndicesOfCollapsedGroupsAbove As List(Of Integer)
        getCategoryAndCollapsedGroups(displayRow,
           categoryIndex, reversedIndicesOfCollapsedGroupsAbove)

        Dim indicesOfCollapsedGroupsAbove As List(Of Integer)
        indicesOfCollapsedGroupsAbove = forwardifyIndices(reversedIndicesOfCollapsedGroupsAbove, categoryIndex)

        Dim sortedCategories As New IndexedDictionary(Of String, Integer)(sortGroups)

        out_hiddenRowsAbove = calculateNumHiddenRowsAbove(indicesOfCollapsedGroupsAbove, sortedCategories)
        out_groupsAbove = categoryIndex + 1
    End Sub

    Private Function forwardifyIndices(ByVal reversedIndicesOfCollapsedGroups As List(Of Integer),
                                       ByVal lastIndex As Integer) As List(Of Integer)
        Dim forwardIndices As New List(Of Integer)()

        Dim reversedIndex, forwardIndex As Integer
        For Each reversedIndex In reversedIndicesOfCollapsedGroups
            forwardIndex = lastIndex - reversedIndex
            forwardIndices.Add(forwardIndex)
        Next

        Return forwardIndices
    End Function

    Private Function calculateNumHiddenRowsAbove(
    ByVal indicesOfCollapsedGroupsAbove As List(Of Integer),
    ByVal groups As IndexedDictionary(Of String, Integer)) As Integer
        Dim numHiddenRowsAbove As Integer

        Dim index, numRowsInCollapsedGroup As Integer
        For Each index In indicesOfCollapsedGroupsAbove
            numRowsInCollapsedGroup = groups.ItemWith(index).Value
            numHiddenRowsAbove += numRowsInCollapsedGroup
        Next

        Return numHiddenRowsAbove
    End Function

    Private Function getCategoryAndCollapsedGroups(
    ByVal displayRow As Integer,
    ByRef out_categoryIndex As Integer, ByRef out_reversedIndicesOfCollapsedGroupsAbove As List(Of Integer)) As List(Of Integer)

        out_reversedIndicesOfCollapsedGroupsAbove = New List(Of Integer)()
        out_categoryIndex = -1

        Dim row As Integer  ''Dim rowType As RowTypeEnum

        ' loops through rows starting with the display row going up to the first row
        For row = displayRow To 0 Step -1
            ''rowType = Rows(row).RowType

            ''If rowType = RowTypeEnum.CollapsedGroupRow Then
            ''    out_categoryIndex += 1
            ''    out_reversedIndicesOfCollapsedGroupsAbove.Add(out_categoryIndex)
            ''ElseIf rowType = RowTypeEnum.ExpandedGroupRow Then
            ''    out_categoryIndex += 1
            ''End If
        Next
    End Function

#End Region


    Protected Function containsData() As Boolean
        Return Not (DataSource Is Nothing _
                    OrElse CType(DataSource, DataTable).Columns.Count = 0)
    End Function

    ''Protected Sub showDetailsInCellTip(ByVal e As FetchCellTipsEventArgs)
    ''    Dim dataRow = GetDataRow(e.Row)
    ''    e.TipStyle.WrapText = True
    ''    e.CellTip = Columns(Cols.Details).CellText(dataRow)
    ''End Sub

    ''Protected Sub formatPrice(ByVal e As FetchCellStyleEventArgs)
    ''    Dim dataRow = GetDataRow(e.Row)

    ''    If userMustContactFactoryForPrice(dataRow) Then _
    ''       formatForContactFactory(e)
    ''End Sub

    ''Protected Sub formatQuantityForEditing(ByVal e As FetchCellStyleEventArgs)
    ''    Dim dataRow = GetDataRow(e.Row)

    ''    ' checks if user can change Quantity cell
    ''    If CBool(Columns(Cols.IsQuantityReadOnly).CellValue(dataRow)) = True Then
    ''        ' sets foreground image to a lock to indicate cell is readonly
    ''        e.CellStyle.ForegroundImage = My.Resources.Lock
    ''        e.CellStyle.Locked = True
    ''        If AppInfo.Division = Business.Division.CRI Then
    ''            e.CellStyle.ForeGroundPicturePosition = ForeGroundPicturePositionEnum.PictureOnly
    ''        End If
    ''    Else
    ''        ' sets foreground image to a pencil to indicate cell is edittable
    ''        e.CellStyle.ForegroundImage = My.Resources.Pencil
    ''        e.CellStyle.Locked = False
    ''        ' sets background image to look like textbox to indicate cell is edittable
    ''        e.CellStyle.BackgroundImage = My.Resources.OptionTextbox
    ''        e.CellStyle.BackgroundPictureDrawMode = BackgroundPictureDrawModeEnum.Center
    ''    End If
    ''End Sub


    ''Protected Sub formatForContactFactory(ByVal e As FetchCellStyleEventArgs)
    ''    e.CellStyle.ForegroundImage = My.Resources.Phone
    ''    e.CellStyle.ForeGroundPicturePosition = ForeGroundPicturePositionEnum.PictureOnly
    ''    e.CellStyle.HorizontalAlignment = AlignHorzEnum.Center
    ''End Sub


    ''Protected Function userMustContactFactoryForPrice(ByVal dataRow As Integer) As Boolean
    ''    Dim contactFactory = Columns(Cols.ContactFactory).CellValue(dataRow)

    ''    Return contactFactory
    ''End Function

End Class