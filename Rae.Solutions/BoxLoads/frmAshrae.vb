Option Strict Off
Option Explicit On

Imports System.Data
Imports Rae.RaeSolutions.CoolStuff

Public Class frmAshrae
    Inherits System.Windows.Forms.Form
    Dim Conn As New cl_connection
    Dim tblashraetable As DataTable
    Dim lDistinctTrue As Boolean = True
    Dim dvtype As DataView
    Dim dvCommodity As DataView
    Dim dvCategory As DataView




    Private Sub frmAshrae_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub
    Private Sub LoadData()
        tblashraetable = Conn.CreateAshraeGeneralTable()
        dvCategory = New DataView(tblashraetable, "", "category ASC", DataViewRowState.CurrentRows)
        With cboCategory
            .DataSource = dvCategory.ToTable(lDistinctTrue, "category")
            .DisplayMember = "category"
            '.SelectedIndex = -1
            .SelectedIndex = 0
        End With
        cboproduct.SelectedIndex = -1
        cboproduct.SelectedIndex = 0
    End Sub
    Private Sub CmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdClose.Click
        Me.Close()
    End Sub




    Private Sub cboProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboproduct.SelectedIndexChanged
        Try
            dvtype = New DataView(tblashraetable, "commodity = '" & cboproduct.Text & "'", "type ASC", DataViewRowState.CurrentRows)
            With Cbotype
                .DataSource = dvtype
                .DisplayMember = "type"
            End With
            btnEdit.Visible = True
        Catch ex As Exception
            btnEdit.Visible = False

        End Try


    End Sub

    Private Sub Cbotype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbotype.SelectedIndexChanged
        Dim myview As New DataView
        Dim subtable As New DataTable
        Try
            myview = New DataView(tblashraetable, "commodity = '" & cboproduct.Text & "' and [type] = '" & Cbotype.Text & "'", "", DataViewRowState.CurrentRows)

            Dim rowView As DataRowView
            'Dim i As Integer
            Dim x As DataRow = tblashraetable.Rows(0)

            For Each rowView In myview
                TxtHFreeze.Text = rowView("highfreeze")
                TxtHeatA.Text = rowView("HeatAboveBTU")
                TxtHeatB.Text = rowView("HeatBelowBTU")
                TxtLatent.Text = rowView("LatentHeatBTU")
                TxtRespire.Text = rowView("HeatRespire")
                TxtSTemp.Text = rowView("StorageTemp")
                TxtSLife.Text = rowView("storagelife")
                TxtWater.Text = rowView("WaterContentPCent")
                TxtRH.Text = rowView("rh")
                chkFromRep.Checked = rowView("fromrep")
                txtMyCounter.Text = rowView("mycounter")

            Next


        Catch ex As Exception

        End Try
        If chkFromRep.Checked = True Then
            btnEdit.Text = "Edit"
        Else
            btnEdit.Text = "Clone"
        End If
    End Sub
    Private Function NewAshrae() As Integer
        Dim itisnow, sql As String

        itisnow = Now.ToString
        sql = "insert into CoolStuffUserAshrae (category) values ('" & itisnow & "')"
        cl_connection.ExecuteSql(sql, "UI")
        NewAshrae = Conn.GetAshraeRecordNumber(itisnow, "UI")

    End Function
    Private Sub INSERTaSHRAE()

        Dim sql As String

        If chkFromRep.Checked = False Then
            txtMyCounter.Text = NewAshrae()
        End If
        With Conn
            sql = "update CoolStuffUserAshrae set category = '" & .unQuoteString(cboCategory.Text) & "'"
            sql = sql & ", commodity = '" & .unQuoteString(cboproduct.Text) & "'"


            sql = sql & ", [type] = '" & .unQuoteString(Cbotype.Text)
            If chkFromRep.Checked = False Then
                sql = sql & " - *User Defined*'"
            Else
                sql = sql & "'"
            End If
            sql = sql & ", StorageTemp = '" & TxtSTemp.Text & "'"
            sql = sql & ", rh = '" & TxtRH.Text & "'"
            sql = sql & ", storagelife = '" & TxtSLife.Text & "'"
            sql = sql & ", [WaterContentPCent] = '" & TxtWater.Text & "'"
            sql = sql & ", highfreeze = '" & TxtHFreeze.Text & "'"
            sql = sql & ", heatabovebtu = '" & TxtHeatA.Text & "'"
            sql = sql & ", heatbelowbtu = '" & TxtHeatB.Text & "'"
            sql = sql & ", latentheatbtu = '" & TxtLatent.Text & "'"
         sql = sql & ", heatrespire = '" & TxtRespire.Text & "'"
         Dim b As Boolean = True
         sql = sql & ", fromrep = " & Rae.RAESolutions.Utility.ConvertDB(b.GetType(), b.ToString())
            sql = sql & " where mycounter = " & txtMyCounter.Text
        End With

        cl_connection.ExecuteSql(sql, "UI")
        LoadData()
    End Sub
    Private Sub cbocategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCategory.SelectedIndexChanged

        Try
            dvCommodity = New DataView(tblashraetable, "category = '" & cboCategory.Text & "'", "Commodity", DataViewRowState.CurrentRows)
            With cboproduct
                .DataSource = dvCommodity.ToTable(lDistinctTrue, "commodity")
                .DisplayMember = "commodity"
                .SelectedIndex = -1
                .SelectedIndex = 0
            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        INSERTaSHRAE()

    End Sub
End Class