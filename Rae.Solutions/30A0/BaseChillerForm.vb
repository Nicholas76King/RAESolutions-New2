Option Strict Off
Option Explicit On

Imports System.Collections.Generic
Imports Rae.solutions
Imports Rae.solutions.Chillers

Public Class BaseChillerForm

#Region " Internal classes"

    ''' <summary>Items in refrigerant list</summary>
    Public Class RefrigerantItem

        Private refrigerant_ As String
        Public Property Refrigerant() As String
            Get
                Return refrigerant_
            End Get
            Set(ByVal value As String)
                refrigerant_ = value
            End Set
        End Property

        Private abbreviation_ As String
        Public Property Abbreviation() As String
            Get
                Return abbreviation_
            End Get
            Set(ByVal Value As String)
                abbreviation_ = Value
            End Set
        End Property


        Public Sub New(ByVal refrigerant As String, ByVal abbreviation As String)
            refrigerant_ = refrigerant
            abbreviation_ = abbreviation
        End Sub


        Public Overrides Function ToString() As String
            Return refrigerant_
        End Function

    End Class

#End Region


    Friend user As user
    Protected results As New ChillerDataSet.ResultsDataTable()

    Private Sub me_load() Handles Me.Load
        user = AppInfo.User
    End Sub

    Protected Sub insertBlankRowInResults()
        Dim filler As String = "-----"
        Me.results.AddResultsRow(filler, filler, filler, filler, filler, filler, filler, filler, filler, filler)
    End Sub

    Protected Sub insertResults( _
       ByVal leavingFluidTemperature As Double, _
       ByVal ambientTemperature As Double, _
       ByVal evaporatingTemperature As Double, _
       ByVal condensingTemperature As Double, _
       ByVal capacityInTons As Double, _
       ByVal unitPowerInKw As Double, _
       ByVal flowRateInGpm As Double, _
       ByVal evaporatorPressureDrop As Double, _
       ByVal compressorEfficiency As Double, _
       ByVal unitEfficiency As Double _
    )
        Dim pd As String
        If evaporatorPressureDrop >= 999 Then
            pd = "*"
        Else
            pd = evaporatorPressureDrop.ToString("#.0")
        End If

        Me.results.AddResultsRow(leavingFluidTemperature.ToString("#.0"), _
                                   ambientTemperature.ToString("#.0"), _
                                   evaporatingTemperature.ToString("#.0"), _
                                   condensingTemperature.ToString("#.0"), _
                                   capacityInTons.ToString("#.0"), _
                                   unitPowerInKw.ToString("#.0"), _
                                   flowRateInGpm.ToString("#.0"), _
                                   pd, _
                                   compressorEfficiency.ToString("#.0"), _
                                   unitEfficiency.ToString("#.0"))
    End Sub

    ''Protected Sub formatResultsGrid(ByVal gridControl As C1.Win.C1TrueDBGrid.C1TrueDBGrid)

    ''    Rae.Ui.C1GridStyles.BasicGridStyle(gridControl)

    ''    With gridControl.Splits(0)
    ''        ' sets column properties
    ''        .ColumnCaptionHeight = 36
    ''        .HeadingStyle.BackColor = ColorManager.LightBlue

    ''        .OddRowStyle.BackColor = ColorManager.LighterBlue
    ''        .Style.Borders.Color = ColorManager.GreyBlue
    ''        For i As Integer = 0 To .DisplayColumns.Count - 1
    ''            .DisplayColumns(i).ColumnDivider.Color = ColorManager.GreyBlue
    ''        Next

    ''        .DisplayColumns("LeavingTemperature").Width = 75
    ''        .DisplayColumns("LeavingTemperature").DataColumn.Caption = "Leaving Fluid Temp. [°F]"
    ''        .DisplayColumns("AmbientTemperature").Width = 65
    ''        .DisplayColumns("AmbientTemperature").DataColumn.Caption = "Ambient Temp. [°F]"
    ''        .DisplayColumns("EvaporatorTemperature").Width = 70
    ''        .DisplayColumns("EvaporatorTemperature").DataColumn.Caption = "Evaporator Temp. [°F]"
    ''        .DisplayColumns("CondenserTemperature").Width = 70
    ''        .DisplayColumns("CondenserTemperature").DataColumn.Caption = "Condenser Temp. [°F]"
    ''        .DisplayColumns("Capacity").Width = 55
    ''        .DisplayColumns("Capacity").DataColumn.Caption = "Est. Capacity [Tons]"
    ''        .DisplayColumns("UnitPower").Width = 45
    ''        .DisplayColumns("UnitPower").DataColumn.Caption = "Unit [KW]"
    ''        .DisplayColumns("FlowRate").Width = 45
    ''        .DisplayColumns("FlowRate").DataColumn.Caption = "GPM"
    ''        .DisplayColumns("EvaporatorPressureDrop").Width = 70
    ''        .DisplayColumns("EvaporatorPressureDrop").DataColumn.Caption = "Evaporator PD [psi]"
    ''        .DisplayColumns("CompressorEfficiency").Width = 75
    ''        .DisplayColumns("CompressorEfficiency").DataColumn.Caption = "Compressor EER"
    ''        .DisplayColumns("UnitEfficiency").Width = 45
    ''        .DisplayColumns("UnitEfficiency").DataColumn.Caption = "Unit EER"
    ''    End With
    ''End Sub


    ''' <summary>
    ''' Returns the index of the item with a matching condenser file name
    ''' </summary>
    Protected Function indexOfCondenser(ByVal combobox As ComboBox, ByVal condenserFileName As String, _
    Optional ByVal condenserNotFoundIndex As Integer = 0) As Integer
        Dim index As Integer

        ' selects condenser with matching file name (number of rows)
        For i As Integer = 0 To combobox.Items.Count - 1
            combobox.SelectedIndex = i
            If DirectCast(combobox.SelectedItem, Condenser1).FileName = condenserFileName Then
                index = i : Exit For
            ElseIf combobox.SelectedIndex = combobox.Items.Count - 1 Then
                index = condenserNotFoundIndex
            End If
        Next

        Return index
    End Function


    ''' <summary>Returns the index of the item with a matching fan file name</summary>
    Protected Function indexOfFanFileName( _
    ByVal combobox As ComboBox, ByVal fanFileName As String, Optional ByVal fanNotFoundIndex As Integer = 0) As Integer
        Dim index As Integer

        For i As Integer = 0 To combobox.Items.Count - 1
            ' iteratively selects fan
            combobox.SelectedIndex = i
            ' checks if selected fan is a match
            If DirectCast(combobox.SelectedItem, Business.Entities.Fan).FileName = fanFileName Then
                ' match is found exit
                index = i : Exit For
                ' checks if this is the last item in list
            ElseIf i = combobox.Items.Count - 1 Then
                ' the fan file name is not in the list; selects fan not found index
                index = fanNotFoundIndex
            End If
        Next

        Return index
    End Function


    Protected Function indexOfRefrigerant(ByVal combobox As ComboBox, ByVal refrigerant As String) As Integer
        Dim index As Integer
        For i As Integer = 0 To combobox.Items.Count - 1
            If CType(combobox.Items(i), cFillCombobox).DisplayName = refrigerant Then
                index = i
                Exit For
            ElseIf i = combobox.Items.Count - 1 Then
                index = -1
            End If
        Next
        Return index
    End Function


    Protected Function getFinsPerInchOptions() As Integer()
        Dim fpis(6) As Integer

        fpis(0) = 8
        fpis(1) = 9
        fpis(2) = 10
        fpis(3) = 11
        fpis(4) = 12
        fpis(5) = 13
        fpis(6) = 14

        Return fpis
    End Function


    Protected Function msg(ByVal min, ByVal max) As String
        Return "Glycol percentage must be in the range " & min & "% to " & max & "%. " & _
               "Glycol percentage is being reset to 20%."
    End Function

    Protected Function getRowAtDesignConditions( _
       ByVal results As ChillerDataSet.ResultsDataTable, _
       ByVal ambient As Double, _
       ByVal leavingFluidTemperature As Double _
    ) As ChillerDataSet.ResultsRow
        For Each result As ChillerDataSet.ResultsRow In results.Rows
            If ConvertNull.ToDouble(result.AmbientTemperature) = ambient AndAlso result.LeavingTemperature = leavingFluidTemperature Then
                Return result
            End If
        Next
        Return Nothing
    End Function

End Class