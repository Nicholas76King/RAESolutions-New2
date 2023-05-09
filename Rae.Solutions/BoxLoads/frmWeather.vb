Option Strict Off
Option Explicit On

Imports Rae.RaeSolutions.CoolStuff
Imports System.Data

Public Class frmWeather : Inherits System.Windows.Forms.Form
   Dim Conn As New cl_connection
   Dim tblWEATHER As DataTable
   Dim lDistinctTrue As Boolean = True
   Dim dvcity As DataView
   Dim dvstate As DataView
   Dim dvdetail As DataView
	
   Private Sub frmWeather_Load() Handles MyBase.Load
      tblWEATHER = cl_connection.CreateGeneralTable("select * from weather order by state", "BL")
      dvState = New DataView(tblWEATHER, "", "state ASC", DataViewRowState.CurrentRows)
      CBOState.DataSource = dvstate.ToTable(lDistinctTrue, "state")
      CBOState.DisplayMember = "state"
      CBOState.ValueMember = "state"
	End Sub
	
	Private Sub CmdClose_Click() Handles CmdClose.Click
		Me.Close()
	End Sub

   Private Sub cboState_SelectedIndexChanged() Handles cboState.SelectedIndexChanged
      Try
         dvcity = New DataView(tblWEATHER, "state = '" & CBOState.Text & "'", "city ASC", DataViewRowState.CurrentRows)
         With cboCity
             .DataSource = dvcity
             .DisplayMember = "city"
         End With

         cboCity.SelectedIndex = -1
         cboCity.SelectedIndex = 0
      Catch ex As Exception

      End Try
   End Sub

   Private Sub cboCity_SelectedIndexChanged() Handles cboCity.SelectedIndexChanged
      Dim rowview As DataRowView
      dvdetail = New DataView(tblWEATHER, "state = '" & CBOState.Text & "' and city = '" & cboCity.Text & "'", "city ASC", DataViewRowState.CurrentRows)
      Try
         For Each rowview In dvdetail
            TxtWDB.Text = rowview("WinterDB")
            TxtWWB.Text = rowview("WinterWB")
            TxtSDB.Text = rowview("SummerDB")
            TxtSWB.Text = rowview("SummerWB")
            TxtRH.Text = rowview("RH")
         Next
      Catch ex As Exception

      End Try
   End Sub
End Class