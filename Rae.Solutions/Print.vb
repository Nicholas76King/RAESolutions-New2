Imports Rae.RaeSolutions.Business.Entities
Imports Rae.Wizard
Public Class Print

    Public Property main As MainForm


    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPrint.Click
        'If MainForm.currentLogo = "" Then
        '    MainForm.currentLogo = New which_division().ask({"TSI", "CRI", "RSI", "RAE"})
        'End If

        Dim writeUp As Boolean = False
        Dim submittal As Boolean = False
        Dim drawing As Boolean = False
        Dim unitRating As Boolean = False
        Dim boxLoad As Boolean = False

        If chkOrderWriteUp.Checked = True Then writeUp = True
        If chkOrderSubmittal.Checked = True Then submittal = True
        If chkDrawing.Checked = True Then drawing = True
        If chkUnitRating.Checked = True Then unitRating = True
        'If chkBoxLoad.Checked = True Then boxLoad = True


        Me.Close()
        main.printSelected(writeUp, submittal, drawing, unitRating) 'boxload

    End Sub

    Private Sub Print_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        MainForm.currentLogo = ""
    End Sub

End Class