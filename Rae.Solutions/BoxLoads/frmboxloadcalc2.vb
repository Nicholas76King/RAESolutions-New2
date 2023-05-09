Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data
Imports System.Math
Imports Rae.CoolStuff
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.CoolStuff
Imports Rae.Reporting.CrystalReports

Public Class frmboxloadcalc2

   Private loaded As Boolean = True

#Region " Declarations"

   Public ExitWithSave As Boolean = False
   Public CanNavigate As Boolean = True

   Public TxtWTot As String
   Public TxtFlTot As String
   Public TxtCeTot As String
   Public TxtITot As String

   Public TxtCT As String
   Public TxtFT As String
   Public TxtCFPT As String
   Public TxtRT As String
   Public TxtTProd As String

   Public TxtL As String
   Public TxtM As String
   Public TxtP As String
   Public TxtO As String
   Public TxtTM As String
   Public TxtTP As String
   Public TxtTO As String
   Public TxtTTrans As String
   Public Svar As String
   Public Rvar As String
   Dim Conn As New cl_connection

   Dim ashraeProducts As DataTable
   Dim distinctTrue As Boolean = True
   Dim tblPreferences As DataTable
   Dim tblProjects As DataTable
   Dim infiltrationValues As DataTable
   Dim weather As DataTable
   Dim dvstate As DataView
   Dim dvcity As DataView
   Dim dvdetail As DataView
   Dim SelectedProducts As DataTable
   Dim BoxLoadsInOpenProject As DataTable

#End Region

#Region " Event handlers"

   Private Sub BoxLoadForm_Load(sender As Object, e As EventArgs) _
   Handles Me.Load
      da = New Rae.Data.Access.BoxLoadProjects()
      navigation = New Persistence.NavigationController(AppInfo.Main.RevisionNavigator1)
            
      fillContacts(Me.projectId)
      
      weather = cl_connection.CreateGeneralTable("select * from weather order by state", "BL")
      infiltrationValues = cl_connection.CreateGeneralTable("select * from air_change", "BL")

      da.ExecuteNonQuery("DELETE * FROM CoolStuffProductSelections WHERE ProjectId=0")

      showAshraeProducts()
      'REVIEW: should default selection be in fill method
      cboProduct.SelectedIndex = -1
      cboProduct.SelectedIndex = 0

      fillInsulationCombobox()

      initializeForNewProject()

      SSTab1.SelectedIndex() = 0
      Dim i As Integer

      Dim columnName As String = "ConstantValues"
      Dim hoursTable As DataTable = retrieveHours(columnName)
      fillComboBoxWithTable(cboLTHours, hoursTable, columnName)
      fillComboBoxWithTable(cboRunVar, hoursTable, columnName)
      fillComboBoxWithTable(cboPDHours, hoursTable, columnName)

      cboLTHours.SelectedIndex = Conn.setcomboIndex("8", cboLTHours)
      cboPDHours.SelectedIndex = Conn.setcomboIndex("24", cboPDHours)

      setruntime()

      dvstate = New DataView(weather, "", "state ASC", DataViewRowState.CurrentRows)
      cboState.DataSource = dvstate.ToTable(distinctTrue, "state")
      cboState.DisplayMember = "state"

      'initializeForNewProject()

      setStateAndCity()

      loaded = False
   End Sub


   Private Sub btnContacts_Click(sender As Object, e As EventArgs) _
   Handles btnContacts.Click
      fillContacts("0")
      btnContacts.Visible = False
   End Sub

   Private Sub CBOState_SelectedIndexChanged(sender As Object, e As EventArgs) _
   Handles cboState.SelectedIndexChanged
      Try
         dvcity = Nothing

         dvcity = New DataView(weather, "state = '" & cboState.Text & "'", "city ASC", DataViewRowState.CurrentRows)
         With cbocity
            .DataSource = dvcity.ToTable(distinctTrue, "city")
            .DisplayMember = "city"
            .ValueMember = "city"
         End With
      Catch ex As Exception
      End Try
   End Sub


   Private Sub cboCity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbocity.SelectedIndexChanged
      Dim rowview As DataRowView
      dvdetail = New DataView(weather, "state = '" & cboState.Text & "' and city = '" & cbocity.Text & "'", "city ASC", DataViewRowState.CurrentRows)
      Try
         For Each rowview In dvdetail
            TxtAmbient.Text = rowview("SummerDB")
            TxtExtWB.Text = rowview("SummerWB")
            'force calculation updates by triggering the changes in txtambient and txtinfwb (infiltration page)
            TxtAmbient_Leave(sender, e)
            TxtInfWB_Leave(sender, e)
         Next
      Catch ex As Exception
      End Try
   End Sub


   Private Sub SSTab1_SelectedIndexChanged(sender As Object, e As EventArgs) _
   Handles SSTab1.SelectedIndexChanged
      If CanNavigate = False Then
         SSTab1.SelectedIndex() = 0
         Exit Sub
      End If

      Static PreviousTab As Short = SSTab1.SelectedIndex()
      If PreviousTab = 1 Then
         updateLightingWatts() 'because room dimensions may have changed
      End If
      
      If SSTab1.SelectedTab.Text = "Project Data" Then
         forceProductupdate()
      Else
         If SSTab1.SelectedTab.Text = "Box Construction And Transmission Load" Then
            forceProductupdate()
            TxtAmbient.Focus()

         Else
            If SSTab1.SelectedTab.Text = "Product Load" Then
               cboProduct.Focus()
            Else
               If SSTab1.SelectedTab.Text = "Infiltration And Misc Load" Then
                  forceProductupdate()
                  TxtInfDB.Focus()

               Else
                  If SSTab1.SelectedTab.Text = "Box Load Summary" Then
                     forceProductupdate()
                     cboRunVar.Focus()
                  Else
                  End If
               End If
            End If
         End If
      End If
      PreviousTab = SSTab1.SelectedIndex()
   End Sub


   Private Sub TxtAmbient_Leave(sender As Object, e As EventArgs) _
   Handles TxtAmbient.Leave, TxtAmbient.TextChanged

      txtExternalTemperatureA.Text = TxtAmbient.Text
      txtExternalTemperatureB.Text = TxtAmbient.Text
      txtExternalTemperatureC.Text = TxtAmbient.Text
      txtExternalTemperatureD.Text = TxtAmbient.Text
      txtExternalTemperatureE.Text = TxtAmbient.Text
      txtExternalTemperatureF.Text = TxtAmbient.Text

      TxtCExtTemp.Text = CStr(Val(TxtAmbient.Text) + 20)

      TxtInfDB.Text = TxtAmbient.Text
      CalcWallLoad()
      CalcFloorLoad()
      CalcCeilingLoad()
   End Sub


   Private Sub TxtExtWB_TextChanged(sender As Object, e As EventArgs) _
   Handles TxtExtWB.TextChanged
      TxtInfWB.Text = TxtExtWB.Text
   End Sub


   Private Sub TxtRmTemp_TextChanged(sender As Object, e As EventArgs) _
   Handles TxtRmTemp.TextChanged

      If [TxtRmTemp].Text <= "32" Then
         CboINSULFloor.SelectedIndex = Conn.setcomboIndex("Styrofoam", CboINSULFloor)
         txtThickFloor.Text = "2"
         TxtKFactorF.Text = CboINSULFloor.SelectedValue
      Else
         CboINSULFloor.SelectedIndex = Conn.setcomboIndex("Concrete", CboINSULFloor)
         txtThickFloor.Text = "5"
         TxtKFactorF.Text = CboINSULFloor.SelectedValue
      End If
      setruntime()

      CalcWallLoad()
      CalcFloorLoad()
      CalcCeilingLoad()
      Try
         calculateInfiltration()
      Catch ex As Exception

      End Try


   End Sub


   Private Sub Command1_Click(sender As Object, e As EventArgs) _
   Handles Command1.Click
      If Len(Trim(cboProduct.Text)) = 0 Then
         MsgBox("No Commodity Value is selected" & Chr(10) & Chr(10) & "Please select a Commodity from the List Available, then try 'Save this Product' again.", MsgBoxStyle.Exclamation, "Error - No Commodity")
         Exit Sub
      End If
      If Len(Trim(CboType.Text)) = 0 Then
         MsgBox("No Product Type is selected" & Chr(10) & Chr(10) & "Please select a Product Type from the List Available, then try 'Save this Product' again.", MsgBoxStyle.Exclamation, "Error - No Product Type")
         Exit Sub
      End If
      forceProductupdate()
      CalcDoWhat()
   End Sub


   '**********************************************************
   '***** Infiltration Load Section *****
   '**********************************************************
   Private Sub TxtInfWB_Leave(sender As Object, e As EventArgs) Handles TxtInfWB.Leave
      If TxtInfWB.Text = "" Then
         MsgBox("Value Must Be Entered")
         TxtInfWB.Focus()
      Else
         calculateInfiltration()
      End If
   End Sub


   Private Sub CboIFactor_SelectedIndexChanged() Handles cbo_ashrae_usage_factor.SelectedIndexChanged
      try
         If Val(cbo_ashrae_usage_factor.Text) > 0 Then
            calculateInfiltration()
         end if
      catch ex as exception
      end try
   end sub


   Private Sub TxtIAirChg_Leave(sender As Object, e As EventArgs) Handles txtIAirChange.Leave
      If TxtIVolume.Text > "0" Then
         calculateInfiltration()
      Else
      End If
   End Sub


   Private Sub TxtCEnter_TextChanged(sender As Object, e As EventArgs) _
   Handles TxtCEnter.TextChanged, TxtCEnter.Leave
      checkFreezePoint()
   End Sub


   Private Sub TxtCFHeat_Leave(sender As Object, e As EventArgs) _
   Handles TxtCFHeat.Leave, TxtFLatent.Leave, TxtCIbs.Leave
      CalcDoWhat()
   End Sub


   Private Sub TxtCFinal_TextChanged(sender As Object, e As EventArgs) Handles TxtCFinal.TextChanged
      checkFrozenToCore()
   End Sub


   Private Sub TxtCFinal_Leave(sender As Object, e As EventArgs) Handles TxtCFinal.Leave
      If Val(TxtFreezePt.Text) < Val(TxtCFinal.Text) Then
         TxtCTot.Text = CStr(0)
         TxtFTot.Text = CStr(0)
         TxtCFPTot.Text = CStr(0)
         TxtFT = CStr(0)
         TxtCFPT = CStr(0)
      Else
      End If

      If Val(TxtCFinal.Text) < CDbl([TxtRmTemp].Text) Then
         MsgBox("Final Product Temperature Can Not Be Less Than Room Temperature" & Chr(13) & Chr(10) & Chr(13) & Chr(10) & "Final Product Temperature Will Be Adjusted To Room Temperature", MsgBoxStyle.Exclamation)
         TxtCFinal.Text = [TxtRmTemp].Text
      End If
      If Val(TxtCFinal.Text) = Val(TxtFreezePt.Text) Then
         chkFreezetoCore.Checked = False
         chkFreezetoCore.Visible = True

      Else
         chkFreezetoCore.Checked = False
         chkFreezetoCore.Visible = False
      End If
      CalcDoWhat()
   End Sub


   Private Sub TxtRIbs_Leave(sender As Object, e As EventArgs) Handles TxtRIbs.Leave
      TxtRT = CStr(Val(TxtRIbs.Text) * Val(TxtRHeat.Text))
      TxtRTot.Text = VB6.Format(TxtRT, "##,###,##0")
      txttotProdUpdate()
   End Sub


   Private Sub TxtRHeat_Leave(sender As Object, e As EventArgs) Handles TxtRHeat.Leave
      If Val(TxtRHeat.Text) = 0 Then
         TxtRTot.Text = CStr(0)
         Exit Sub
      Else
         TxtRT = CStr(CDbl(TxtRIbs.Text) * CDbl(TxtRHeat.Text))
         TxtRTot.Text = VB6.Format(TxtRT, "##,###,##0")
      End If
      txttotProdUpdate()
   End Sub


   Private Sub chkFreezetoCore_CheckedChanged(sender As Object, e As EventArgs) Handles chkFreezetoCore.CheckedChanged
      Try
         CalcDoWhat()
      Catch ex As Exception
      End Try
   End Sub


   Private Sub chkfreezept_CheckedChanged(sender As Object, e As EventArgs) Handles chkfreezept.CheckedChanged
      Try
         CalcDoWhat()
      Catch ex As Exception
      End Try
   End Sub


   Private Sub TxtTotOther_TextChanged(sender As Object, e As EventArgs) Handles TxtTotOther.TextChanged
      TxtSumOther.Text = TxtTotOther.Text
      CalcSubTotal()
   End Sub


   Private Sub txtLightingWatts_SelectedIndexChanged() Handles cboLightingWatts.SelectedIndexChanged
      updateLightingWatts()
   End Sub

   Private Sub updateLightingWatts()
      calculateLightingWatts()
      calculateTotalInfiltration()
   End Sub

   Private Sub TxtMotorHP_Leave(sender As Object, e As EventArgs) Handles TxtMotorHP.Leave
      TxtM = CStr(CDbl(TxtMotorHP.Text) * 72000)
      TxtTotOM.Text = VB6.Format(TxtM, "##,###,##0")
      calculateTotalInfiltration()
   End Sub


   Private Sub TxtPeople_Leave(sender As Object, e As EventArgs) Handles TxtPeople.Leave
      TxtP = CStr(((99 - CDbl([TxtRmTemp].Text)) * 350) * CDbl(TxtPeople.Text))
      TxtTotOP.Text = VB6.Format(TxtP, "##,###,##0")
      calculateTotalInfiltration()
   End Sub


   Private Sub TxtOtherBTU_Leave(sender As Object, e As EventArgs) Handles TxtOtherBTU.Leave
      TxtO = TxtOtherBTU.Text
      TxtTotOO.Text = VB6.Format(TxtO, "##,###,##0")
      calculateTotalInfiltration()
   End Sub


   Private Sub TxtOtherType_Enter(sender As Object, e As EventArgs) Handles TxtOtherType.Enter
      TxtOtherType.SelectionStart = 0
      TxtOtherType.SelectionLength = Len(TxtOtherType.Text)
   End Sub


   Private Sub TxtRunVar_Changed(sender As Object, e As EventArgs) _
   Handles cboRunVar.SelectedIndexChanged, cboRunVar.Leave
      CalcLoad()
   End Sub


   Private Sub TxtSafety_Changed(sender As Object, e As EventArgs) _
   Handles cboSafety.SelectedIndexChanged, cboSafety.Leave
      CalcLoad()
   End Sub


#Region "Transmission Load Section"

#Region "Room Temp"
   Private Sub TxtRmTemp_Leave(sender As Object, e As EventArgs) _
   Handles TxtRmTemp.Leave
      setruntime()
      CalcWallLoad()
      CalcFloorLoad()
      CalcCeilingLoad()
   End Sub


   Private Sub TxtRmTemp_Enter(sender As Object, e As EventArgs) _
   Handles TxtRmTemp.Enter
      [TxtRmTemp].SelectionStart = 0
      [TxtRmTemp].SelectionLength = Len([TxtRmTemp].Text)
   End Sub


   Private Sub TxtRmTemp_KeyPress(sender As Object, e As KeyPressEventArgs) _
   Handles TxtRmTemp.KeyPress
      Dim KeyAscii As Short = Asc(e.KeyChar)
      If KeyAscii = 13 Then
         System.Windows.Forms.SendKeys.Send("{Tab}")
         KeyAscii = 0
      End If
      e.KeyChar = Chr(KeyAscii)
      If KeyAscii = 0 Then
         e.Handled = True
      End If
   End Sub

#End Region


   Private Sub TxtHeight_Leave(sender As Object, e As EventArgs) _
   Handles txtHeightA.Leave
      If CDbl(txtHeightA.Text) <= 0 Then
         MsgBox("Zero And Negative Values Are Not Allowed, Defaulting To 1")
         txtHeightA.Text = "1"
      Else
      End If

      txtHeightB.Text = txtHeightA.Text
      txtHeightC.Text = txtHeightA.Text
      txtHeightD.Text = txtHeightA.Text
      txtHeightE.Text = txtHeightA.Text
      txtHeightF.Text = txtHeightA.Text
      CalcWallLoad()
      CalcFloorLoad()
      CalcCeilingLoad()
      CalcVolume()
      calculateInfiltration()
   End Sub


   Private Sub BtnAllWallsY_CheckedChanged(sender As Object, e As EventArgs) _
   Handles BtnAllWallsY.CheckedChanged
      If sender.Checked Then
         If rdoKFactor.Checked = True Then
            kfactorview(False, 0)
            CboINSULB.SelectedIndex = Conn.setcomboIndex(CboINSULA.Text, CboINSULB)
            CboInsulC.SelectedIndex = Conn.setcomboIndex(CboINSULA.Text, CboInsulC)
            CboINSULD.SelectedIndex = Conn.setcomboIndex(CboINSULA.Text, CboINSULD)
            CboINSULE.SelectedIndex = Conn.setcomboIndex(CboINSULA.Text, CboINSULE)
            cboinsulf.SelectedIndex = Conn.setcomboIndex(CboINSULA.Text, cboinsulf)

            txtKFACTORwB.Text = txtKFACTORwA.Text
            txtKFACTORwC.Text = txtKFACTORwA.Text
            txtKFACTORwD.Text = txtKFACTORwA.Text
            txtKFACTORwE.Text = txtKFACTORwA.Text
            txtKFACTORwF.Text = txtKFACTORwA.Text


            txtExternalTemperatureA.Focus()
            K2Rfactors()
            CalcWallLoad()
         Else
            rfactorview(False, 0)
            txtRwB.Text = txtRwA.Text
            txtRwC.Text = txtRwA.Text
            txtRwD.Text = txtRwA.Text
            txtRwE.Text = txtRwA.Text
            txtRwF.Text = txtRwA.Text
         End If

      End If
   End Sub


   Private Sub BtnAllWallsN_CheckedChanged(sender As Object, e As EventArgs) _
   Handles BtnAllWallsN.CheckedChanged

      If sender.Checked Then
         Select Case rdoRFactor.Checked

            Case Is = False
               kfactorview(True, 0)

               txtExternalTemperatureA.Focus()
            Case Else
               rfactorview(True, 0)

         End Select
      End If
   End Sub


   Private Sub CboINSULA_changed(sender As Object, e As EventArgs) _
   Handles CboINSULA.SelectedIndexChanged
      Try
         txtKFACTORwA.Text = CboINSULA.SelectedValue

         If BtnAllWallsY.Checked = True Then
            CboINSULB.SelectedIndex = Conn.setcomboIndex(CboINSULA.Text, CboINSULB)
            CboInsulC.SelectedIndex = Conn.setcomboIndex(CboINSULA.Text, CboInsulC)
            CboINSULD.SelectedIndex = Conn.setcomboIndex(CboINSULA.Text, CboINSULD)
            txtThickB.Text = txtThickA.Text
            TxtThickC.Text = txtThickA.Text
            txtThickD.Text = txtThickA.Text
            txtKFACTORwB.Text = txtKFACTORwA.Text
            txtKFACTORwC.Text = txtKFACTORwA.Text
            txtKFACTORwD.Text = txtKFACTORwA.Text

         End If
         K2Rfactors()
         CalcWallLoad()
      Catch
      End Try
   End Sub


   Private Sub CboINSULD_changed(sender As Object, e As EventArgs) _
   Handles CboINSULD.SelectedIndexChanged
      Try
         txtKFACTORwD.Text = CboINSULD.SelectedValue
         If BtnAllWallsN.Checked = True Then
            K2Rfactors()
            CalcWallLoad()
         End If
      Catch
      End Try
   End Sub


   Private Sub CboINSULE_changed(sender As Object, e As EventArgs) _
   Handles CboINSULE.SelectedIndexChanged
      Try
         txtKFACTORwE.Text = CboINSULE.SelectedValue
         If BtnAllWallsN.Checked Then
            K2Rfactors()
            CalcWallLoad()
         End If
      Catch
      End Try
   End Sub


   Private Sub CboINSULF_changed(sender As Object, e As EventArgs) _
   Handles cboinsulf.SelectedIndexChanged
      Try
         txtKFACTORwF.Text = cboinsulf.SelectedValue
         If BtnAllWallsN.Checked = True Then
            K2Rfactors()
            CalcWallLoad()
         End If
      Catch
      End Try
   End Sub


   Private Sub CboINSULB_changed(sender As Object, e As EventArgs) _
   Handles CboINSULB.SelectedIndexChanged
      Try
         txtKFACTORwB.Text = CboINSULB.SelectedValue
         If BtnAllWallsN.Checked = True Then
            K2Rfactors()
            CalcWallLoad()
         End If
      Catch
      End Try
   End Sub


   Private Sub CboINSULC_changed(sender As Object, e As EventArgs) _
   Handles CboInsulC.SelectedIndexChanged
      Try
         txtKFACTORwC.Text = CboInsulC.SelectedValue
         If BtnAllWallsN.Checked = True Then
            K2Rfactors()
            CalcWallLoad()
         End If
      Catch
      End Try
   End Sub


   Private Sub txtThickA_Leave(sender As Object, e As EventArgs) _
   Handles txtThickA.Leave
      If CDbl(txtThickA.Text) <= 0 Then
         MsgBox("Zero And Negative Values Are Not Allowed, Defaulting To 4")
         txtThickA.Text = "4"
      Else
      End If
      If BtnAllWallsY.Checked = True Then
         txtThickB.Text = txtThickA.Text
         TxtThickC.Text = txtThickA.Text
         txtThickD.Text = txtThickA.Text
      Else
      End If
      K2Rfactors()

      CalcWallLoad()
   End Sub


   Private Sub txtKFACTORwA_Leave(sender As Object, e As EventArgs) _
   Handles txtKFACTORwA.Leave
      If CDbl(txtKFACTORwA.Text) <= 0 Then
         MsgBox("Zero And Negative Values Are Not Allowed, Defaulting To 0.24")
         txtKFACTORwA.Text = "0.24"
      Else
      End If

      If BtnAllWallsY.Checked = True Then
         txtKFACTORwB.Text = txtKFACTORwA.Text

         txtKFACTORwC.Text = txtKFACTORwA.Text

         txtKFACTORwD.Text = txtKFACTORwA.Text
      Else
      End If

      K2Rfactors()
      CalcWallLoad()
   End Sub


   Private Function K2Rfactors() As Integer
      Try
         txtRwA.Text = Round(CDbl(txtThickA.Text) / CDbl(txtKFACTORwA.Text), 4)
         txtRwB.Text = Round(CDbl(txtThickB.Text) / CDbl(txtKFACTORwB.Text), 4)
         txtRwC.Text = Round(CDbl(TxtThickC.Text) / CDbl(txtKFACTORwC.Text), 4)
         txtRwD.Text = Round(CDbl(txtThickD.Text) / CDbl(txtKFACTORwD.Text), 4)
         txtRwE.Text = Round(CDbl(txtThickE.Text) / CDbl(txtKFACTORwE.Text), 4)
         txtRwF.Text = Round(CDbl(txtThickF.Text) / CDbl(txtKFACTORwF.Text), 4)
         txtRCeiling.Text = Round(CDbl(txtThickCeiling.Text) / CDbl(TxtKFactorC.Text), 4)
         txtRFloor.Text = Round(CDbl(txtThickFloor.Text) / CDbl(TxtKFactorF.Text), 4)
      Catch ex As Exception
      End Try
   End Function


   Private Function R2Kfactors() As Integer
      Try
         txtKFACTORwA.Text = Round(CDbl(txtThickA.Text) / CDbl(txtRwA.Text), 4)
         txtKFACTORwB.Text = Round(CDbl(txtThickB.Text) / CDbl(txtRwB.Text), 4)
         txtKFACTORwC.Text = Round(CDbl(TxtThickC.Text) / CDbl(txtRwC.Text), 4)
         txtKFACTORwD.Text = Round(CDbl(txtThickD.Text) / CDbl(txtRwD.Text), 4)
         txtKFACTORwE.Text = Round(CDbl(txtThickE.Text) / CDbl(txtRwE.Text), 4)
         txtKFACTORwF.Text = Round(CDbl(txtThickF.Text) / CDbl(txtRwF.Text), 4)
         TxtKFactorC.Text = Round(CDbl(txtThickCeiling.Text) / CDbl(txtRCeiling.Text), 4)
         TxtKFactorF.Text = Round(CDbl(txtThickFloor.Text) / CDbl(txtRFloor.Text), 4)
      Catch ex As Exception
      End Try
   End Function


   Private Sub txtThickB_Leave(sender As Object, e As EventArgs) _
   Handles txtThickB.Leave
      If CDbl(txtThickB.Text) <= 0 Then
         MsgBox("Zero And Negative Values Are Not Allowed, Defaulting To 4")
         txtThickB.Text = "4"
      Else
      End If
      K2Rfactors()
      CalcWallLoad()
   End Sub


   Private Sub txtKFACTORwB_Leave(sender As Object, e As EventArgs) _
   Handles txtKFACTORwB.Leave
      If CDbl(txtKFACTORwB.Text) <= 0 Then
         MsgBox("Zero And Negative Values Are Not Allowed, Defaulting To 0.24")
         txtKFACTORwB.Text = "0.24"
      Else
      End If
      K2Rfactors()
      CalcWallLoad()
   End Sub


   Private Sub txtKFACTORwC_Leave(sender As Object, e As EventArgs) _
   Handles txtKFACTORwC.Leave
      If CDbl(txtKFACTORwC.Text) <= 0 Then
         MsgBox("Zero And Negative Values Are Not Allowed, Defaulting To 0.24")
         txtKFACTORwC.Text = "0.24"
      Else
      End If
      K2Rfactors()
      CalcWallLoad()
   End Sub


   Private Sub txtExternalTemperatureD_Leave(sender As Object, e As EventArgs) _
   Handles txtExternalTemperatureA.Leave, txtExternalTemperatureB.Leave, txtExternalTemperatureC.Leave, txtExternalTemperatureD.Leave, txtExternalTemperatureE.Leave, txtExternalTemperatureF.Leave
      CalcWallLoad()
   End Sub


   Private Sub txtThickD_Leave(sender As Object, e As EventArgs) _
   Handles txtThickD.Leave
      If CDbl(txtThickD.Text) <= 0 Then
         MsgBox("Zero And Negative Values Are Not Allowed, Defaulting To 4")
         txtThickD.Text = "4"
      Else
      End If
      K2Rfactors()
      CalcWallLoad()
   End Sub


   Private Sub txtKFACTORwD_Leave(sender As Object, e As EventArgs) _
   Handles txtKFACTORwD.Leave
      If CDbl(txtKFACTORwD.Text) <= 0 Then
         MsgBox("Zero And Negative Values Are Not Allowed, Defaulting To 0.24")
         txtKFACTORwD.Text = "0.24"
      Else
      End If
      K2Rfactors()
      CalcWallLoad()
   End Sub


   Private Sub TxtFExtTemp_Leave(sender As Object, e As EventArgs) _
   Handles TxtFExtTemp.Leave
      CalcFloorLoad()
   End Sub


   Private Sub TxtThickFloor_Leave(sender As Object, e As EventArgs) _
   Handles txtThickFloor.Leave
      If CDbl(txtThickFloor.Text) <= 0 Then
         MsgBox("Zero And Negative Values Are Not Allowed, Defaulting To 5")
         txtThickFloor.Text = "5"
      Else
      End If
      K2Rfactors()
      CalcFloorLoad()
   End Sub


   Private Sub TxtKFactorF_Leave(sender As Object, e As EventArgs) _
   Handles TxtKFactorF.Leave
      If CDbl(TxtKFactorF.Text) <= 0 Then
         MsgBox("Zero And Negative Values Are Not Allowed, Defaulting To 0.24")
         TxtKFactorF.Text = "0.24"
      Else
      End If
      K2Rfactors()
      CalcFloorLoad()
   End Sub


   Private Sub TxtCExtTemp_Leave(sender As Object, e As EventArgs) _
   Handles TxtCExtTemp.Leave
      CalcCeilingLoad()
   End Sub


   Private Sub TxtThickceiling_Leave(sender As Object, e As EventArgs) _
   Handles txtThickCeiling.Leave
      If CDbl(txtThickCeiling.Text) <= 0 Then
         MsgBox("Zero And Negative Values Are Not Allowed, Defaulting To 4")
         txtThickCeiling.Text = "4"
      Else
      End If
      K2Rfactors()

      CalcCeilingLoad()
   End Sub


   Private Sub TxtKFactorC_Leave(sender As Object, e As EventArgs) _
   Handles TxtKFactorC.Leave
      If CDbl(TxtKFactorC.Text) <= 0 Then
         MsgBox("Zero And Negative Values Are Not Allowed, Defaulting To 0.24")
         TxtKFactorC.Text = "0.24"
      Else
      End If
      K2Rfactors()
      CalcCeilingLoad()
   End Sub


   Private Sub TxtTotInfil_TextChanged(sender As Object, e As EventArgs) Handles TxtTotInfil.TextChanged
      TxtSumInf.Text = TxtTotInfil.Text

      CalcSubTotal()
      calculateTotalInfiltration()

   End Sub

#End Region


#Region "Product Load"

   Private Sub cboProduct_SelectedIndexChanged(sender As Object, e As EventArgs) _
   Handles cboProduct.SelectedIndexChanged
      Dim commodities As DataView
      commodities = New DataView(ashraeProducts, "commodity = '" & cboProduct.Text & "'", "type ASC", DataViewRowState.CurrentRows)
      With CboType
         .DataSource = commodities
         .DisplayMember = "type"
      End With

      If Not loaded AndAlso CboType.Items.Count > 0 Then CboType.SelectedIndex = 0
      txtProductId.Text = 0
      showRemoveProductControls(False)
      lblNonAshrae.Visible = False

      TxtCTot.Text = "0"
      TxtFTot.Text = "0"
      TxtCFPTot.Text = "0"
   End Sub


   Private Sub CboType_Leave(sender As Object, e As EventArgs) Handles CboType.Leave
      CalcDoWhat()
   End Sub


   Private Sub CboType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboType.SelectedIndexChanged
      Dim myview As New DataView
      Dim subtable As New DataTable
      txtProductId.Text = 0
      showRemoveProductControls(False)
      
      Dim product As String
      
      Try
         myview = New DataView(ashraeProducts, "commodity = '" & cboProduct.Text & "' and [type] = '" & CboType.Text & "'", "", DataViewRowState.CurrentRows)

         Dim rowView As DataRowView
         rowView = myview(0)

         TxtFreezePt.Text = rowView("highfreeze")
         TxtCHeat.Text = rowView("HeatAboveBTU")
         TxtCFHeat.Text = rowView("HeatBelowBTU")
         TxtFLatent.Text = rowView("LatentHeatBTU")
         TxtRHeat.Text = rowView("HeatRespire")
         lblNonAshrae.Visible = rowView("fromrep")
         chkfromRep.Checked = rowView("fromrep")

         product = cboProduct.Text
         CalcDoWhat()
      Catch ex As Exception
         TxtFreezePt.Text = 0
         TxtCHeat.Text = 0
         TxtCFHeat.Text = 0
         TxtFLatent.Text = 0
         TxtRHeat.Text = 0

         product = "Choose Commodity Item"
      End Try
   End Sub


   Private Sub CboType_KeyPress(sender As Object, e As KeyPressEventArgs) _
   Handles CboType.KeyPress
      Dim KeyAscii As Short = Asc(e.KeyChar)
      If KeyAscii = 13 Then
         System.Windows.Forms.SendKeys.Send("{Tab}")
         KeyAscii = 0
      End If
      e.KeyChar = Chr(KeyAscii)
      If KeyAscii = 0 Then
         e.Handled = True
      End If
   End Sub


   Private Sub TxtFreezePt_Leave(sender As Object, e As EventArgs) _
   Handles TxtFreezePt.Leave, TxtFreezePt.TextChanged
      CalcDoWhat()
      checkFreezePoint()
      checkFrozenToCore()
   End Sub


   Private Sub TxtFreezePt_Enter(sender As Object, e As EventArgs) _
   Handles TxtFreezePt.Enter
      TxtFreezePt.SelectionStart = 0
      TxtFreezePt.SelectionLength = Len(TxtFreezePt.Text)
   End Sub


   Private Sub TxtFreezePt_KeyPress(sender As Object, e As KeyPressEventArgs) _
   Handles TxtFreezePt.KeyPress
      Dim KeyAscii As Short = Asc(e.KeyChar)
      If KeyAscii = 13 Then
         System.Windows.Forms.SendKeys.Send("{Tab}")
         KeyAscii = 0
      End If
      e.KeyChar = Chr(KeyAscii)
      If KeyAscii = 0 Then
         e.Handled = True
      End If
   End Sub

#End Region


#End Region


#Region " Private methods"

   Private Sub showRemoveProductControls(showButton As Boolean)
      btnRemove.Visible = showButton
      lblRemove.Visible = showButton
   End Sub


   ''' <summary>
   ''' Gets project ID as string if project is opened.
   ''' If project is not opened then returns empty string.      
   ''' </summary>
   Private Function projectId() As String
      Dim id As String

      If OpenedProject.IsOpened Then
         id = OpenedProject.Manager.Project.id.ToString
      Else
         id = ""
      End If

      Return id
   End Function

   Private Function roomL(orientation As Integer) As Image
      Return My.Resources.ResourceManager.GetObject("RoomL" & orientation.ToString)
   End Function

   Private Function showAshraeProducts() As Boolean
      ashraeProducts = Conn.CreateAshraeGeneralTable()
      Dim commodities As New DataView(ashraeProducts, "", "commodity ASC", DataViewRowState.CurrentRows)
      With cboProduct
         .DataSource = commodities.ToTable(distinctTrue, "commodity")
         .DisplayMember = "commodity"
         .SelectedIndex = 0
      End With
   End Function


   Private Sub fillInsulationCombobox()
      Dim dropdowntable As DataTable
      dropdowntable = cl_connection.CreateGeneralTable("select * from Insulation order by Insulation", "BL")
      With CboINSULA
         .DataSource = dropdowntable.Copy
         .ValueMember = "KFACTOR"
         .DisplayMember = "INSULATION"
      End With
      With CboINSULB
         .DataSource = dropdowntable.Copy
         .ValueMember = "KFACTOR"
         .DisplayMember = "INSULATION"
      End With
      With CboInsulC
         .DataSource = dropdowntable.Copy
         .ValueMember = "KFACTOR"
         .DisplayMember = "INSULATION"
      End With
      With CboINSULD
         .DataSource = dropdowntable.Copy
         .ValueMember = "KFACTOR"
         .DisplayMember = "INSULATION"
      End With
      With CboINSULE
         .DataSource = dropdowntable.Copy
         .ValueMember = "KFACTOR"
         .DisplayMember = "INSULATION"
      End With
      With cboinsulf
         .DataSource = dropdowntable.Copy
         .ValueMember = "KFACTOR"
         .DisplayMember = "INSULATION"
      End With
      With CboINSULFloor
         .DataSource = dropdowntable.Copy
         .ValueMember = "KFACTOR"
         .DisplayMember = "INSULATION"
      End With
      With cboinsulCeiling
         .DataSource = dropdowntable.Copy
         .ValueMember = "KFACTOR"
         .DisplayMember = "INSULATION"
      End With
   End Sub


   Private Function setruntime() As Integer
      cboRunVar.SelectedIndex = Conn.setcomboIndex("18", cboRunVar)
      Try

         Select Case Val(TxtRmTemp.Text)
            Case Is < 35
            Case Is > 45
               cboRunVar.SelectedIndex = Conn.setcomboIndex("20", cboRunVar)
            Case Else
               cboRunVar.SelectedIndex = Conn.setcomboIndex("16", cboRunVar)
         End Select
      Catch ex As Exception

      End Try
   End Function


   Private Sub fillComboBoxWithTable(comboBox As ComboBox, table As DataTable, displayColumnName As String)
      With comboBox
         .DataSource = table.Copy()
         .DisplayMember = displayColumnName
      End With
   End Sub


   Private Function retrieveHours(columnName As String) As DataTable
      Dim dt As New DataTable()
      dt.Columns.Add(columnName)

      Dim i As Integer
      For i = 1 To 24
         dt.Rows.Add(i)
      Next

      Return dt
   End Function


   Private Sub setStateAndCity()
      Dim preferences As DataTable
      preferences = cl_connection.CreateGeneralTable( _
         "SELECT * FROM CoolStuffPreferences", "UI")

      Try
         cboState.SelectedIndex = Conn.setcomboIndex(preferences.Rows(0)("mydefaultstate"), cboState)
      Catch ex As Exception
         cboState.SelectedIndex = Conn.setcomboIndex("Oklahoma", cboState)
      End Try
      cbocity.SelectedIndex = -1
      Try
         cbocity.SelectedIndex = Conn.setcomboIndex(preferences.Rows(0)("mydefaultcity"), cbocity)
      Catch ex As Exception
         cbocity.SelectedIndex = Conn.setcomboIndex("Tulsa", cbocity)
      End Try
   End Sub

#End Region


   Private Function checkFreezePoint() As Integer
      If Val(TxtCEnter.Text) = Val(TxtFreezePt.Text) Then
         chkfreezept.Checked = False
         chkfreezept.Visible = True
      Else
         chkfreezept.Checked = False
         chkfreezept.Visible = False
      End If

      Try
         CalcDoWhat()
      Catch ex As Exception
      End Try
   End Function


   Private Function checkFrozenToCore() As Integer
      If Val(TxtCFinal.Text) = Val(TxtFreezePt.Text) Then
         chkFreezetoCore.Checked = False
         chkFreezetoCore.Visible = True
      Else
         chkFreezetoCore.Checked = False
         chkFreezetoCore.Visible = False
      End If
      Try
         CalcDoWhat()
      Catch ex As Exception
      End Try
   End Function



#Region "CalculationArea"


   Sub CalcFloorLoad()
      Dim UFactor As Double
      TxtFloorTot.Text = CStr(0)

      Select Case rdoRFactor.Checked
         Case True
            If Val(txtRFloor.Text) = 0 Then
               Exit Sub
            End If
            UFactor = 1 / CDbl(txtRFloor.Text)

         Case Else
            If Val(txtThickFloor.Text) = 0 Or Val(TxtKFactorF.Text) = 0 Then
               Exit Sub
            End If
            UFactor = (1 / ((Val(txtThickFloor.Text) / Val(TxtKFactorF.Text))))
      End Select

      'TxtFlTot = CStr((((CDbl(txtFloorLength.Text) * CDbl(txtFloorWidth.Text)) * UFactor) * (Val(TxtFExtTemp.Text) - Val([TxtRmTemp].Text))) * 24)
      TxtFlTot = CStr((((CDbl(txtFloorCeilingArea.Text)) * UFactor) * (Val(TxtFExtTemp.Text) - Val([TxtRmTemp].Text))) * 24)

      If CDbl(TxtFlTot) <= 0 Then
         TxtFlTot = CStr(0)
      Else
      End If

      TxtFloorTot.Text = VB6.Format(TxtFlTot, "##,###,##0")

   End Sub

   Sub CalcCeilingLoad()
      Dim UFactor As Double

      TxtCeilingTot.Text = CStr(0)
      Select Case rdoRFactor.Checked
         Case True
            If Val(txtRCeiling.Text) = 0 Then
               Exit Sub
            End If
            UFactor = 1 / CDbl(txtRCeiling.Text)
         Case Else
            If Val(txtThickCeiling.Text) = 0 Or Val(TxtKFactorC.Text) = 0 Then
               Exit Sub
            End If
            UFactor = (1 / (Val(txtThickCeiling.Text) / Val(TxtKFactorC.Text)))
      End Select
      TxtCeTot = CStr((((CDbl(txtFloorCeilingArea.Text)) * UFactor) * (Val(TxtCExtTemp.Text) - Val([TxtRmTemp].Text))) * 24)
      If CDbl(TxtCeTot) <= 0 Then
         TxtCeTot = CStr(0)
      Else
      End If
      TxtCeilingTot.Text = VB6.Format(TxtCeTot, "##,###,##0")
   End Sub


   Sub CalcVolume()
      Dim TxtIV As Double

      TxtIV = Val(txtFloorCeilingArea.Text) * Val(txtHeightA.Text)

      TxtIVolume.Text = VB6.Format(TxtIV, "##,###,##0")
   End Sub


   Sub CalcDoWhat()
      TxtCTot.Text = "0"
      TxtFTot.Text = "0"
      TxtCFPTot.Text = "0"


      If Val(TxtCEnter.Text) >= Val(TxtFreezePt.Text) And Val(TxtCFinal.Text) <= CDbl(TxtFreezePt.Text) Then
         CalcCool()
         CalcFreeze()
         CalcCoolFrozen()
      Else
         If Val(TxtCEnter.Text) <= Val(TxtFreezePt.Text) And Val(TxtCFinal.Text) <= CDbl(TxtFreezePt.Text) Then
            TxtCT = CStr(0)
            TxtFT = CStr(0)

            CalcCoolFrozen()
         Else
            If Val(TxtCFinal.Text) < Val(TxtFreezePt.Text) Then
               CalcCool()
               CalcFreeze()
               CalcCoolFrozen()
            Else
               If Val(TxtCFinal.Text) = Val(TxtFreezePt.Text) Then
                  CalcCool()
                  CalcFreeze()
               Else
                  If Val(TxtCFinal.Text) > Val(TxtFreezePt.Text) Then
                     CalcCool()
                  Else
                  End If
               End If
            End If
         End If
      End If
      TxtCFTot.Text = VB6.Format(CDbl(TxtCTot.Text) + CDbl(TxtFTot.Text) + CDbl(TxtCFPTot.Text), "##,###,##0")
      txttotProdUpdate()
   End Sub


   Sub CalcWallLoad()
      Dim UFactorW1 As Double
      Dim UFactorW2 As Double
      Dim UFactorW3 As Double
      Dim UFactorW4 As Double
      Dim UFactorW5 As Double
      Dim UFactorW6 As Double

      Dim Wall1 As Double
      Dim Wall2 As Double
      Dim Wall3 As Double
      Dim Wall4 As Double
      Dim Wall5 As Double
      Dim Wall6 As Double


      TxtWallTot.Text = 0

      Select Case rdoRFactor.Checked
         Case True
            If Val(txtRwA.Text) = 0 Or Val(txtRwB.Text) = 0 Or Val(txtRwC.Text) = 0 Or Val(txtRwD.Text) = 0 Then
               Exit Sub
            End If
            UFactorW1 = 1 / CDbl(txtRwA.Text)
            UFactorW2 = 1 / CDbl(txtRwB.Text)
            UFactorW3 = 1 / CDbl(txtRwC.Text)
            UFactorW4 = 1 / CDbl(txtRwD.Text)
            UFactorW5 = 1 / CDbl(txtRwE.Text)
            UFactorW6 = 1 / CDbl(txtRwF.Text)

         Case Else
            If Val(txtKFACTORwA.Text) = 0 Or Val(txtKFACTORwB.Text) = 0 Or Val(txtKFACTORwC.Text) = 0 Or Val(txtKFACTORwD.Text) = 0 Then
               Exit Sub
            End If
            UFactorW1 = (1 / (Val(txtThickA.Text) / Val(txtKFACTORwA.Text)))
            UFactorW2 = (1 / (Val(txtThickB.Text) / Val(txtKFACTORwB.Text)))
            UFactorW3 = (1 / (Val(TxtThickC.Text) / Val(txtKFACTORwC.Text)))
            UFactorW4 = (1 / (Val(txtThickD.Text) / Val(txtKFACTORwD.Text)))
            UFactorW5 = (1 / (Val(txtThickE.Text) / Val(txtKFACTORwE.Text)))
            UFactorW6 = (1 / (Val(txtThickF.Text) / Val(txtKFACTORwF.Text)))
      End Select


      If Val(txtExternalTemperatureA.Text) <= 0 Then
         Wall1 = 0
      Else
         Wall1 = ((((CDbl(txtWallA.Text) * CDbl(txtHeightA.Text)) * UFactorW1) * (Val(txtExternalTemperatureA.Text) - Val([TxtRmTemp].Text))) * 24)
      End If

      'Wall #2

      If Val(txtExternalTemperatureB.Text) <= 0 Then
         Wall2 = 0
      Else
         Wall2 = ((((CDbl(txtWallB.Text) * CDbl(txtHeightB.Text)) * UFactorW2) * (Val(txtExternalTemperatureB.Text) - Val([TxtRmTemp].Text))) * 24)
      End If

      'Wall #3

      If Val(txtExternalTemperatureC.Text) <= 0 Then
         Wall3 = 0
      Else
         Wall3 = ((((CDbl(txtWallC.Text) * CDbl(txtHeightC.Text)) * UFactorW3) * (Val(txtExternalTemperatureC.Text) - Val([TxtRmTemp].Text))) * 24)
      End If

      'Wall #4

      If Val(txtExternalTemperatureD.Text) <= 0 Then
         Wall4 = 0
      Else
         Wall4 = ((((CDbl(txtWallD.Text) * CDbl(txtHeightD.Text)) * UFactorW4) * (Val(txtExternalTemperatureD.Text) - Val([TxtRmTemp].Text))) * 24)
      End If

      If Val(txtExternalTemperatureE.Text) <= 0 Then
         Wall5 = 0
      Else
         Wall5 = ((((CDbl(txtWallE.Text) * CDbl(txtHeightE.Text)) * UFactorW5) * (Val(txtExternalTemperatureE.Text) - Val([TxtRmTemp].Text))) * 24)
      End If

      If Val(txtExternalTemperatureF.Text) <= 0 Then
         Wall6 = 0
      Else
         Wall6 = ((((ConvertNull.ToDouble(txtWallF.Text) * CDbl(txtHeightF.Text)) * UFactorW6) * (Val(txtExternalTemperatureF.Text) - Val([TxtRmTemp].Text))) * 24)
      End If
      TxtWTot = CStr(Val(CStr(Wall1)) + Val(CStr(Wall2)) + Val(CStr(Wall3)) + Val(CStr(Wall4)) + Val(CStr(Wall5)) + Val(CStr(Wall6)))

      If CDbl(TxtWTot) <= 0 Then
         TxtWTot = CStr(0)
      Else
      End If

      TxtWallTot.Text = VB6.Format(TxtWTot, "##,###,##0")
   End Sub


   Sub calculateInfiltration()
      Dim BoxType As String

      If CDbl(TxtRmTemp.Text) > 32 Then
         BoxType = "Y"
      Else
         BoxType = "N"
      End If

      Dim dv As DataView
      dv = New DataView(infiltrationValues, "[above_below] = '" & BoxType & "' and [volume] <= " & CInt(TxtIVolume.Text), "volume desc", DataViewRowState.CurrentRows)
      'Dim dr As DataRow

      txtIAirChange.Text = 1

      Try
         txtIAirChange.Text = dv(0)("air_chgs")
      Catch ex As Exception
      End Try


      Dim EQe As Double
      Dim EQr As Double

      If Val(cbo_ashrae_usage_factor.Text) = 0 Then
         TxtTotInfil.Text = CStr(0)
         Exit Sub
      Else
         EQe = 0.9241009 + (0.000000181097 * Val(TxtInfWB.Text) ^ 4) - (0.00001240106 * Val(TxtInfWB.Text) ^ 3) + (0.0008445829 * Val(TxtInfWB.Text) ^ 2) + (0.2917974 * Val(TxtInfWB.Text))
         EQr = 0.9241009 + (0.000000181097 * Val(TxtRMWB.Text) ^ 4) - (0.00001240106 * Val(TxtRMWB.Text) ^ 3) + (0.0008445829 * Val(TxtRMWB.Text) ^ 2) + (0.2917974 * Val(TxtRMWB.Text))

         TxtITot = CStr(CDbl(CStr(TxtIVolume.Text)) * CDbl(CStr(cbo_ashrae_usage_factor.Text)) * CDbl(CStr(txtIAirChange.Text)) * (0.075) * (EQe - EQr))

         If CDbl(TxtITot) <= 0 Then
            TxtITot = CStr(0)
         Else
         End If

         TxtTotInfil.Text = VB6.Format(TxtITot, "##,###,##0")
      End If

   End Sub


   Sub CalcCool()
      Dim CPLN As Double
      Dim Diff As Double

      If Val(cboLTHours.Text) < Val(cboPDHours.Text) Then
         CPLN = CDbl(cboLTHours.Text)
      Else
         CPLN = Val(cboPDHours.Text)
      End If

      If Val(TxtCFinal.Text) > Val(TxtFreezePt.Text) Then
         Diff = Val(TxtCEnter.Text) - Val(TxtCFinal.Text)
      Else
         Diff = Val(TxtCEnter.Text) - Val(TxtFreezePt.Text)
      End If

      TxtCT = CStr(((Val(TxtCIbs.Text) / Val(cboLTHours.Text)) / Val(cboPDHours.Text)) * Val(CStr(CPLN)) * (Val(CStr(Diff)) * Val(TxtCHeat.Text)) * 24)

      If CDbl(TxtCT) <= 0 Then
         TxtCT = "0"
         TxtCTot.Text = "0"
         TxtCFTot.Text = "0"
         'TxtRIbs.Text = "0"
         'TxtRHeat.Text = "0"
         'TxtRTot.Text = "0"
         TxtTotProd.Text = "0"
      Else
         TxtCTot.Text = VB6.Format(TxtCT, "##,###,##0")
      End If

      'End If
   End Sub


   Sub CalcFreeze()

      Dim CPLN As Double

      If Val(cboLTHours.Text) < Val(cboPDHours.Text) Then
         CPLN = CDbl(cboLTHours.Text)
      Else
         CPLN = Val(cboPDHours.Text)
      End If
      If Val(TxtCIbs.Text) = 0 Then
         Exit Sub

      End If
      TxtFT = CStr(((Val(TxtCIbs.Text) / Val(cboLTHours.Text)) / Val(cboPDHours.Text)) * Val(CStr(CPLN)) * Val(TxtFLatent.Text) * 24)


      If chkfreezept.Visible = True And chkfreezept.Checked = True Then
         TxtFT = CStr(0)
      End If


      If chkFreezetoCore.Visible = True And chkFreezetoCore.Checked = False Then
         TxtFT = CStr(0)
      End If


SKIP_TXTCFINAL:
      If CDbl(TxtFT) <= 0 Then
         TxtFT = "0"
         TxtFTot.Text = "0"

      Else
         TxtFTot.Text = VB6.Format(TxtFT, "##,###,##0")
      End If

   End Sub


   Sub CalcCoolFrozen()
      Dim CPLN As Double
      Dim Var As Double
      Try

         If Val(cboLTHours.Text) < Val(cboPDHours.Text) Then
            CPLN = CDbl(cboLTHours.Text)
         Else
            CPLN = Val(cboPDHours.Text)
         End If

         If Val(TxtCEnter.Text) >= Val(TxtFreezePt.Text) Then
            Var = Val(TxtFreezePt.Text) - Val(TxtCFinal.Text) 'CHANGED 2/13/2001 DANNYG
         Else
            Var = Val(TxtCEnter.Text) - Val(TxtCFinal.Text)
         End If

         TxtCFPT = CStr(((Val(TxtCIbs.Text) / Val(cboLTHours.Text)) / Val(cboPDHours.Text)) * Val(CStr(CPLN)) * (Val(CStr(Var)) * Val(TxtCFHeat.Text)) * 24)

         If CDbl(TxtCFPT) <= 0 Then
            TxtCFPT = "0"
            TxtCFPTot.Text = "0"

         Else
            TxtCFPTot.Text = VB6.Format(TxtCFPT, "##,###,##0")
         End If
      Catch ex As Exception

      End Try
   End Sub


   Sub calculateLightingWatts()
      Try
         If RdoRectangle.Checked = True Then
            TxtL = CStr(((CDbl(txtWallA.Text) * CDbl(txtWallB.Text)) * CDbl(cboLightingWatts.Text)) * 82)
         Else
            TxtL = (Val(txtWallA.Text) * Val(txtWallB.Text) + Val(txtWallD.Text) * Val(txtWallE.Text)) * CDbl(cboLightingWatts.Text) * 82

         End If

         TxtTotOL.Text = VB6.Format(TxtL, "##,###,##0")
      Catch ex As Exception

      End Try

   End Sub


   Private Sub txttotProdUpdate()
      Dim x As Double
      Try
         x = CDbl(TxtCFTot.Text) + CDbl(TxtRTot.Text)
         TxtTotProd.Text = VB6.Format(x, "##,###,##0")
      Catch ex As Exception
         TxtTotProd.Text = VB6.Format(0, "##,###,##0")
      End Try
      TxtSumProd.Text = txtTotAllProducts.Text

      CalcSubTotal()
   End Sub


   Sub CalcSubTotal()
      Try
         TxtSumTot.Text = VB6.Format(CDbl(TxtSumTrans.Text) + CDbl(TxtSumProd.Text) + CDbl(TxtSumInf.Text) + CDbl(TxtSumOther.Text), "##,###,##0")
         lblOLpc.Text = "0%"
         lblILpc.Text = "0%"
         lblplpc.Text = "0%"
         lblTLpc.Text = "0%"

         If CDbl(TxtSumTot.Text) > 0 Then
            lblOLpc.Text = VB6.Format(CDbl(TxtSumOther.Text) / CDbl(TxtSumTot.Text), "#0.0%")
            lblILpc.Text = VB6.Format(CDbl(TxtSumInf.Text) / CDbl(TxtSumTot.Text), "#0.0%")
            lblplpc.Text = VB6.Format(CDbl(TxtSumProd.Text) / CDbl(TxtSumTot.Text), "#0.0%")
            lblTLpc.Text = VB6.Format(CDbl(TxtSumTrans.Text) / CDbl(TxtSumTot.Text), "#0.0%")

         End If
      Catch ex As Exception

      End Try
   End Sub


   Sub CalcLoad()
      Dim TxtLT As Object
        If Val(cboRunVar.Text) = CDbl("0") Then
        Else
            Try
                Rvar = CStr(CDbl(CStr(TxtSumTot.Text)) / CDbl(CStr(cboRunVar.Text)))
                TxtRunVarTot.Text = VB6.Format(Rvar, "##,###,##0")
            Catch ex As Exception
                TxtRunVarTot.Text = 0
                TxtSumTot.Text = 0
            End Try

        End If

      If Val(cboSafety.Text) > 0 Then
         Svar = CStr((CDbl(CStr(TxtRunVarTot.Text)) * Val(cboSafety.Text)) / 100)
         TxtSafetyTot.Text = VB6.Format(Svar, "##,###,##0")
      Else
      End If
      Try
         TxtLT = CInt(TxtRunVarTot.Text) + CInt(Svar)
         TxtLoadTot.Text = VB6.Format(TxtLT, "##,###,##0")
      Catch ex As Exception

      End Try


   End Sub


   Private Sub initializeCalculatedVariables()
      TxtWTot = CStr(0)
      TxtFlTot = CStr(0)
      TxtCeTot = CStr(0)
      TxtITot = CStr(0)

      TxtCT = CStr(0)
      TxtFT = CStr(0)
      TxtCFPT = CStr(0)
      TxtTProd = CStr(0)

      TxtL = CStr(0)
      TxtM = CStr(0)
      TxtP = CStr(0)
      TxtO = CStr(0)
      TxtTM = CStr(0)
      TxtTP = CStr(0)
      TxtTO = CStr(0)
      TxtTTrans = CStr(0)
      Svar = CStr(0)
      Rvar = CStr(0)

   End Sub

#End Region


#Region "ProjectStuff"
   

   Sub show_report
      ' create products table
      copyToSelectedProductsReport(BoxLoad.DbId)
      Dim products_table = cl_connection.CreateGeneralTable( _
         "select * from CoolStuffProductSelectionsreport", "UI")
      products_table.TableName = "productSelectionsReport"

      ' create box load table
      updateBoxLoadObject()
      Dim box_load_table = Me.BoxLoad.ToTable()
      
      ' create user table
      Dim preferences_table = cl_connection.CreateGeneralTable( _
         "select * from CoolStuffPreferences", "UI")
      If preferences_table.Rows.Count = 0 Then
         'FIRST TIME THRU?  CREATE THE DEFAULTS
         Dim X As String = "INSERT INTO COOLSTUFFPREFERENCES (MYDEFAULTSTATE,MYDEFAULTCITY) VALUES "
         X = X & "('" & cboState.Text & "', '" & cbocity.Text & "')"
         cl_connection.ExecuteSql(X, "UI")
         preferences_table = cl_connection.CreateGeneralTable("select * from CoolStuffPreferences", "UI")
      End If

      Conn.AddRaeStuffToReportProject(box_load_table, preferences_table, txtDescription.Text, _
         BoxLoad.DbId, Me.projectId, txt_representative_id.Text, txt_customer_id.Text)
      box_load_table.TableName = "Project"
      preferences_table.TableName = "Preferences"

      Dim ds As New DataSet
      ds.Tables.Add(box_load_table)
      ds.Tables.Add(preferences_table)
      ds.Tables.Add(products_table)

      dim report_file_path = reports.file_paths.box_load_template_file_path
      dim report = new box_load_report(report_file_path, me, products_table)
      report.show
      
      'Dim report As New ReportDocument()

      'Dim fileName = If (rdoKFactor.Checked, "Project.rpt", "ProjectR.rpt")
      'Dim folderPath = System.IO.Path.Combine(AppInfo.AppFolderPath, "Reports")
      'Dim filePath = System.IO.Path.Combine(folderPath, fileName)

      'report.Load(filePath)
      'report.SetDataSource(ds)

      'Dim reportForm As New ReportViewerForm(report)
      'reportForm.Show()
   End Sub


   Private Function copyToSelectedProductsReport(id As Integer) As Boolean
      cl_connection.ExecuteSql("delete from CoolStuffproductSelectionsReport", "UI")

      Dim sql As String = "INSERT INTO CoolStuffproductSelectionsReport (Projectid,product,[type],freezept,cheat,cfheat,flatent,cibs,cload,cpull,center,cfinal,ctot,ftot,cfptot,cftot,ribs,rheat,rtot,prodtot,chkfreezept,chkfreezetocore,fromrep)"
      sql = sql & " select Projectid,product,[type],freezept,cheat,cfheat,flatent,cibs,cload,cpull,center,cfinal,ctot,ftot,cfptot,cftot,ribs,rheat,rtot,prodtot,chkfreezept,chkfreezetocore,fromrep from CoolStuffProductSelections where projectid = " & id
      cl_connection.ExecuteSql(sql, "UI")
   End Function


   Private Function addproducttoproject() As Integer
      Dim itisnow As String
      Dim sql As String

      itisnow = Now.ToString
      sql = "insert into CoolStuffProductSelections (product) values ('" & itisnow & "')"
      cl_connection.ExecuteSql(sql, "UI")
      addproducttoproject = Conn.GetProjectProductRecordNumber(itisnow, "UI")
   End Function


   Private Sub EDITProductinPRoject(id As Integer)
      Dim sql As String

      sql = "Update CoolStuffProductSelections set "
      With Conn
         sql = sql & "projectid = " & BoxLoad.DbId & ""
         sql = sql & ", Product = '" & cboProduct.Text & "'"
         sql = sql & ", Type = '" & CboType.Text & "'"
         sql = sql & ", FreezePt = '" & .unQuoteString(TxtFreezePt.Text) & "'"
         sql = sql & ", CHeat = '" & .unQuoteString(TxtCHeat.Text) & "'"
         sql = sql & ", CFHeat = '" & .unQuoteString(TxtCFHeat.Text) & "'"
         sql = sql & ", FLatent = '" & .unQuoteString(TxtFLatent.Text) & "'"
         sql = sql & ", CIbs = '" & .unQuoteString(TxtCIbs.Text) & "'"
         sql = sql & ", CLoad = '" & .unQuoteString(cboLTHours.Text) & "'"
         sql = sql & ", CPull = '" & .unQuoteString(cboPDHours.Text) & "'"
         sql = sql & ", CEnter = '" & .unQuoteString(TxtCEnter.Text) & "'"
         sql = sql & ", CFinal = '" & .unQuoteString(TxtCFinal.Text) & "'"
         sql = sql & ", CTot = '" & .unQuoteString(TxtCTot.Text) & "'"
         sql = sql & ", FTot = '" & .unQuoteString(TxtFTot.Text) & "'"
         sql = sql & ", CFPTot = '" & .unQuoteString(TxtCFPTot.Text) & "'"
         sql = sql & ", CFTot = '" & .unQuoteString(TxtCFTot.Text) & "'"
         sql = sql & ", RIbs = '" & .unQuoteString(TxtRIbs.Text) & "'"
         sql = sql & ", RHeat = '" & .unQuoteString(TxtRHeat.Text) & "'"
         sql = sql & ", RTot = '" & .unQuoteString(TxtRTot.Text) & "'"
         sql = sql & ", ProdTot = '" & .unQuoteString(TxtTotProd.Text) & "'"

         sql = sql & ", chkfreezept = " & IIf(Rae.RaeSolutions.DataAccess.Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL, Rae.RaeSolutions.Utility.ConvertDB(chkfreezept.Checked.GetType(), chkfreezept.Checked.ToString).ToString, chkfreezept.Checked)
         sql = sql & ", chkfreezetocore = " & IIf(Rae.RaeSolutions.DataAccess.Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL, Rae.RaeSolutions.Utility.ConvertDB(chkFreezetoCore.Checked.GetType(), chkFreezetoCore.Checked.ToString).ToString, chkFreezetoCore.Checked)
         sql = sql & ", fromrep = " & IIf(Rae.RaeSolutions.DataAccess.Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL, Rae.RaeSolutions.Utility.ConvertDB(chkfromRep.Checked.GetType(), chkfromRep.Checked.ToString).ToString, chkfromRep.Checked)


         sql = sql & " where id = " & id

         cl_connection.ExecuteSql(sql, "UI")
      End With
   End Sub
   '**********************************************************
   '***** New Project Routine *****
   '**********************************************************

   Private Sub CmdNewProj_Click(sender As Object, e As EventArgs) _
   Handles CmdNewProj.Click
      initializeForNewProject()
   End Sub


   Private Sub initializeForNewProject()

      initializeControls()

      initializeCalculatedVariables()

   End Sub


   Private Sub initializeControls()
      Dim TxtIHeatRem As Object


      TxtAmbient.Text = "1"
      TxtExtWB.Text = "1"
      [TxtRmTemp].Text = "1"
      TxtRMWB.Text = "1"


      txtWallA.Text = "1"
      txtHeightA.Text = "1"
      txtWallB.Text = "1"
      txtHeightB.Text = "1"
      txtWallC.Text = "1"
      txtWallE.Text = "1"
      txtHeightC.Text = "1"
      txtWallD.Text = "1"
      txtWallF.Text = "1"
      txtHeightD.Text = "1"
      txtHeightE.Text = "1"
      txtHeightF.Text = "1"
      txtFloorCeilingArea.Text = "0"


      txtExternalTemperatureA.Text = "1"
      txtExternalTemperatureB.Text = "1"
      txtExternalTemperatureC.Text = "1"
      txtExternalTemperatureD.Text = "1"
      txtExternalTemperatureE.Text = "1"
      txtExternalTemperatureF.Text = "1"

      CboINSULA.SelectedIndex = Conn.setcomboIndex("Styrofoam", CboINSULA)
      CboINSULB.SelectedIndex = Conn.setcomboIndex("Styrofoam", CboINSULB)
      CboInsulC.SelectedIndex = Conn.setcomboIndex("Styrofoam", CboInsulC)
      CboINSULD.SelectedIndex = Conn.setcomboIndex("Styrofoam", CboINSULD)
      CboINSULE.SelectedIndex = Conn.setcomboIndex("Styrofoam", CboINSULE)
      cboinsulf.SelectedIndex = Conn.setcomboIndex("Styrofoam", cboinsulf)

      txtThickA.Text = "4"
      txtThickB.Text = "4"
      TxtThickC.Text = "4"
      txtThickD.Text = "4"
      txtThickE.Text = "4"
      txtThickF.Text = "4"

      TxtWallTot.Text = "0"
      TxtFExtTemp.Text = "55"
      CboINSULFloor.SelectedIndex = Conn.setcomboIndex("Concrete", CboINSULFloor)
      txtThickFloor.Text = "5"
      TxtKFactorF.Text = "1.25"
      TxtFloorTot.Text = "0"
      TxtCExtTemp.Text = "1"
      ' CboInsulC.defText = "Fiberglass"
      cboinsulCeiling.SelectedIndex = Conn.setcomboIndex("Fiberglass", cboinsulCeiling)
      txtThickCeiling.Text = "4"
      TxtKFactorC.Text = "0.24"
      TxtCeilingTot.Text = "0"
      TxtTotTrans.Text = "0"

      TxtIVolume.Text = "0"
      'TxtInfWB.Text = "0"
      'TxtInfDB.Text = "0"
      cbo_ashrae_usage_factor.Text = "1.5"
      txtIAirChange.Text = "0"
      'UPGRADE_WARNING: Couldn't resolve default property of object TxtIHeatRem. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
      TxtIHeatRem = "0"
      TxtTotInfil.Text = "0"

      ' commented out because they're initialized elsewhere
      'cboProduct.Text = " "
      'CboType.Text = " "
      'TxtFreezePt.Text = "0"
      'TxtCHeat.Text = "0"
      'TxtCFHeat.Text = "0"
      'TxtFLatent.Text = "0"
      TxtCIbs.Text = "0"


      TxtCEnter.Text = "0"
      TxtCFinal.Text = "0"
      TxtCTot.Text = "0"
      TxtFTot.Text = "0"
      TxtCFPTot.Text = "0"
      TxtCFTot.Text = "0"
      TxtRIbs.Text = "0"
      TxtRHeat.Text = "0"
      TxtRTot.Text = "0"
      TxtTotProd.Text = "0"

      cboLightingWatts.SelectedIndex = 1
      TxtTotOL.Text = "0"
      TxtMotorHP.Text = "0"
      TxtTotOM.Text = "0"
      TxtPeople.Text = "0"
      TxtTotOP.Text = "0"
      TxtOtherType.Text = " "
      TxtOtherBTU.Text = "0"
      TxtTotOO.Text = "0"
      TxtTotOther.Text = "0"
      txtForkLift.Text = "0"
      txtTotForkLift.Text = "0"
      txtDockDoors.Text = "0"
      txttotdockdoors.Text = "0"

      TxtSumTrans.Text = "0"
      TxtSumInf.Text = "0"
      TxtSumProd.Text = "0"
      TxtSumOther.Text = "0"
      TxtSumTot.Text = "0"
      cboSafety.Text = "10"
      TxtSafetyTot.Text = "0"
      cboRunVar.Text = "18"
      TxtRunVarTot.Text = "0"
      TxtLoadTot.Text = "0"


      txtRwA.Text = "16.667"
      txtRwB.Text = "16.667"
      txtRwC.Text = "16.667"
      txtRwD.Text = "16.667"
      txtRwE.Text = "16.667"
      txtRwF.Text = "16.667"
      txtRCeiling.Text = "16.667"
      txtRFloor.Text = "4"
   End Sub


   Private Function showProductDetail(id As Integer) As Boolean
      Dim ProjectRow As DataRow
      Dim MYPRODUCT As DataTable

      MYPRODUCT = cl_connection.CreateGeneralTable("select * from CoolStuffProductSelections where id = " & id, "UI")
      ProjectRow = MYPRODUCT.Rows(0)

      cboProduct.SelectedIndex = Conn.setcomboIndex(ProjectRow("Product"), cboProduct)
      CboType.Text = ProjectRow("Type")
      TxtFreezePt.Text = ProjectRow("FreezePt")
      TxtCHeat.Text = ProjectRow("CHeat")
      TxtCFHeat.Text = ProjectRow("CFHeat")
      TxtFLatent.Text = ProjectRow("FLatent")
      TxtCIbs.Text = ProjectRow("CIbs")
      cboLTHours.SelectedIndex = Conn.setcomboIndex(ProjectRow("CLoad"), cboLTHours)
      cboPDHours.SelectedIndex = Conn.setcomboIndex(ProjectRow("CPull"), cboPDHours)
      TxtCEnter.Text = ProjectRow("CEnter")
      TxtCFinal.Text = ProjectRow("CFinal")
      TxtCTot.Text = ProjectRow("CTot")
      TxtFTot.Text = ProjectRow("FTot")
      TxtCFPTot.Text = ProjectRow("CFPTot")
      TxtCFTot.Text = ProjectRow("CFTot")
      TxtRIbs.Text = ProjectRow("RIbs")
      TxtRHeat.Text = ProjectRow("RHeat")
      TxtRTot.Text = ProjectRow("RTot")
      TxtTotProd.Text = ProjectRow("ProdTot")


      txtProductId.Text = id
      showRemoveProductControls(True)
      checkFreezePoint()
      checkFrozenToCore()
      chkfreezept.Checked = ProjectRow("chkfreezept")
      chkFreezetoCore.Checked = ProjectRow("chkfreezetocore")

   End Function


   Public Function calculateTotalInfiltration() As Double
        Try
            TxtTotOther.Text = VB6.Format(CDbl(TxtTotOL.Text) + CDbl(TxtTotOM.Text) + CDbl(txttotdockdoors.Text) + CDbl(txtTotForkLift.Text) + CDbl(TxtTotOP.Text) + CDbl(TxtTotOO.Text), "#,###,###,###,##0")
            CalcLoad()
        Catch ex As Exception
        End Try
   End Function


   Private Sub cmb_insul1_clicked(sender As Object, e As EventArgs) Handles CboINSULA.TextChanged
      Try
         txtKFACTORwA.Text = CboINSULA.SelectedValue
      Catch ex As Exception
      End Try
   End Sub


   Private Sub TxtWallTot_TextChanged(sender As Object, e As EventArgs) Handles TxtWallTot.TextChanged
      TxtTTrans = CStr(Val(TxtWTot) + Val(TxtFlTot) + Val(TxtCeTot))
      TxtTotTrans.Text = VB6.Format(TxtTTrans, "##,###,##0")
   End Sub


   Private Sub TxtFloorTot_TextChanged(sender As Object, e As EventArgs) Handles TxtFloorTot.TextChanged
      TxtTTrans = CStr(Val(TxtWTot) + Val(TxtFlTot) + Val(TxtCeTot))
      TxtTotTrans.Text = VB6.Format(TxtTTrans, "##,###,##0")
   End Sub


   Private Sub TxtCeilingTot_TextChanged(sender As Object, e As EventArgs) Handles TxtCeilingTot.TextChanged
      TxtTTrans = CStr(Val(TxtWTot) + Val(TxtFlTot) + Val(TxtCeTot))
      TxtTotTrans.Text = VB6.Format(TxtTTrans, "##,###,##0")
   End Sub

   Private Sub TxtTotTrans_TextChanged(sender As Object, e As EventArgs) Handles TxtTotTrans.TextChanged
      TxtSumTrans.Text = TxtTotTrans.Text
      CalcSubTotal()
   End Sub


   Private Sub cboInsulF_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboINSULFloor.SelectedIndexChanged
      Try
         TxtKFactorF.Text = CboINSULFloor.SelectedValue
         txtRFloor.Text = Round(CDbl(txtThickFloor.Text) / CDbl(TxtKFactorF.Text), 4)
      Catch ex As Exception
      End Try
      
      'K2Rfactors()
      CalcFloorLoad()
   End Sub


   Private Sub cboInsulceiling_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboinsulCeiling.SelectedIndexChanged
      Try
         TxtKFactorC.Text = cboinsulCeiling.SelectedValue
         txtRCeiling.Text = Round(CDbl(txtThickCeiling.Text) / CDbl(TxtKFactorC.Text), 4)
      Catch ex As Exception
      End Try
      'K2Rfactors()
      CalcCeilingLoad()
   End Sub

#End Region

   Private Sub cboLTHours_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLTHours.SelectedIndexChanged
      Try
         CalcDoWhat()
      Catch ex As Exception
      End Try
   End Sub


   Private Sub cboPDHours_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPDHours.SelectedIndexChanged
      Try
         CalcDoWhat()
      Catch ex As Exception

      End Try
   End Sub


   Private Sub TxtIVolume_TextChanged(sender As Object, e As EventArgs) Handles TxtIVolume.TextChanged
      Try
         calculateInfiltration()
      Catch ex As Exception
      End Try
   End Sub


   Private Sub TxtRMWB_TextChanged(sender As Object, e As EventArgs) Handles TxtRMWB.TextChanged
      Try
         calculateInfiltration()
      Catch ex As Exception
      End Try
   End Sub


   Private Sub WeatherToolStripMenuItem_Click(sender As Object, e As EventArgs) _
   Handles WeatherToolStripMenuItem.Click
      Dim f As New frmWeather()
      f.Show()
   End Sub


   Private Sub AshraeToolStripMenuItem_Click(sender As Object, e As EventArgs) _
   Handles AshraeToolStripMenuItem.Click
      Dim f As New frmAshrae
      f.Show()
      showAshraeProducts()
   End Sub


   Private Sub TxtRHeat_TextChanged(sender As Object, e As EventArgs) Handles TxtRHeat.TextChanged
      TxtRHeat_Leave(sender, e)
   End Sub


   Private Sub rdorectangle_CheckedChanged(sender As Object, e As EventArgs) Handles RdoRectangle.CheckedChanged
      If RdoRectangle.Checked = True Then
         Try
            LBLe.Visible = False
            lBLf.Visible = False
            btnLshape.Visible = False
            showControlsForSixSidedRoom(False)
            walladjust()
            PicLShape.Image = My.Resources.RoomRectangle
            '  PicLShape.Image = Image.FromFile(cl_connection.baseDirectory & "\IMAGES\csbldgrect.bmp")
            txtWallD.Text = txtWallB.Text
            txtWallC.Text = txtWallA.Text
            txtWallE.Text = "0"
            txtWallF.Text = "0"

            txtExternalTemperatureE.Visible = False
            txtExternalTemperatureF.Visible = False

            txtFloorCeilingArea.Text = Val(txtWallA.Text) * Val(txtWallB.Text)
            checkRed()
            CalcFloorLoad()
            CalcCeilingLoad()
            CalcWallLoad()


         Catch ex As Exception

         End Try

      Else
         btnLshape.Visible = True
         If txtImageCounter.Text < "0" Then _
            TxtImageCounter.Text = "1"
         PicLShape.Image = roomL(txtImageCounter.Text.Trim)
         '            PicLShape.Image = Image.FromFile(cl_connection.baseDirectory & "\IMAGES\csbldg1.bmp")
         showControlsForSixSidedRoom(True)
         walladjust()

         txtExternalTemperatureE.Visible = True
         txtExternalTemperatureF.Visible = True
         LBLe.Visible = True
         lBLf.Visible = True
         walladjust()

         checkRed()
         CalcFloorLoad()
         CalcCeilingLoad()
         CalcWallLoad()
      End If

   End Sub
   

   Private Sub rdoKFactor_CheckedChanged(sender As Object, e As EventArgs) Handles rdoKFactor.CheckedChanged
      If rdoKFactor.Checked = True Then
         Try
            kfactorview(True, 1)
            rfactorview(False, 1)
            If BtnAllWallsN.Checked = True Then BtnAllWallsN_CheckedChanged(sender, e)
            If BtnAllWallsY.Checked = True Then BtnAllWallsY_CheckedChanged(sender, e)
            CalcFloorLoad()
            CalcCeilingLoad()
            CalcWallLoad()
         Catch ex As Exception
         End Try
      End If
   End Sub

   Private Sub rboRFactor_CheckedChanged(sender As Object, e As EventArgs) Handles rdoRFactor.CheckedChanged
      If rdoRFactor.Checked = True Then
         Try
            kfactorview(False, 1)
            rfactorview(True, 1)
            If BtnAllWallsN.Checked = True Then BtnAllWallsN_CheckedChanged(sender, e)
            If BtnAllWallsY.Checked = True Then BtnAllWallsY_CheckedChanged(sender, e)
            CalcFloorLoad()
            CalcCeilingLoad()
            CalcWallLoad()

         Catch ex As Exception

         End Try

      End If

   End Sub


   Private Function showControlsForSixSidedRoom(hasSixSides As Boolean) As Boolean
      txtWallE.Visible = hasSixSides
      txtWallF.Visible = hasSixSides
      txtHeightE.Visible = hasSixSides
      txtHeightF.Visible = hasSixSides

      If BtnAllWallsN.Checked = True Then
         txtExternalTemperatureE.Visible = hasSixSides
         txtExternalTemperatureF.Visible = hasSixSides
         CboINSULE.Visible = hasSixSides
         cboinsulf.Visible = hasSixSides

         If rdoRFactor.Checked = True Then
            txtRwE.Visible = hasSixSides
            txtRwF.Visible = hasSixSides

         Else
            txtThickE.Visible = hasSixSides
            txtThickF.Visible = hasSixSides

            txtKFACTORwE.Visible = hasSixSides
            txtKFACTORwF.Visible = hasSixSides

         End If
      End If
   End Function


   Private Function kfactorview(myboolean As Boolean, mygroup As Integer) As Boolean

      ' A, B, C & D are always visible (per Larry Hudson) - JOSH 10/25/2007

      CboINSULB.Visible = myboolean
      CboInsulC.Visible = myboolean
      CboINSULD.Visible = myboolean

      txtThickB.Visible = myboolean
      TxtThickC.Visible = myboolean
      txtThickD.Visible = myboolean


      txtKFACTORwB.Visible = myboolean
      txtKFACTORwC.Visible = myboolean
      txtKFACTORwD.Visible = myboolean
      If RdoRectangle.Checked = False Then
         txtExternalTemperatureE.Visible = myboolean
         txtExternalTemperatureF.Visible = myboolean

         CboINSULE.Visible = myboolean
         cboinsulf.Visible = myboolean

         txtThickE.Visible = myboolean
         txtThickF.Visible = myboolean

         txtKFACTORwE.Visible = myboolean
         txtKFACTORwF.Visible = myboolean
      End If
      If mygroup = 1 Then
         LblThickW1.Visible = myboolean
         LblKFactorW1.Visible = myboolean
         txtThickA.Visible = myboolean
         txtKFACTORwA.Visible = myboolean
         txtThickFloor.Visible = myboolean
         txtThickCeiling.Visible = myboolean
         TxtKFactorF.Visible = myboolean
         TxtKFactorC.Visible = myboolean


      End If


   End Function


   Private Function rfactorview(myboolean As Boolean, mygroup As Integer) As Boolean

      txtRwB.Visible = myboolean
      txtRwC.Visible = myboolean
      txtRwD.Visible = myboolean

      CboINSULB.Visible = myboolean
      CboInsulC.Visible = myboolean
      CboINSULD.Visible = myboolean

      If RdoRectangle.Checked = False Then
         CboINSULE.Visible = myboolean
         cboinsulf.Visible = myboolean
         txtExternalTemperatureE.Visible = myboolean
         txtRwE.Visible = myboolean
         txtExternalTemperatureF.Visible = myboolean
         txtRwF.Visible = myboolean
      End If

      If mygroup = 1 Then
         'txtExternalTemperatureA.Visible = myboolean
         lblrw1.Visible = myboolean
         txtRwA.Visible = myboolean

         txtRFloor.Visible = myboolean

         txtRCeiling.Visible = myboolean
      End If
   End Function


   Private Sub txtRwA_Enter(sender As Object, e As EventArgs) _
   Handles txtRwA.Enter, txtRwB.Enter, txtRwC.Enter, txtRwD.Enter, txtRCeiling.Enter, txtRFloor.Enter, txtExternalTemperatureA.Enter, txtExternalTemperatureB.Enter, txtExternalTemperatureC.Enter, txtExternalTemperatureD.Enter, txtExternalTemperatureE.Enter, txtExternalTemperatureF.Enter, txtThickA.Enter, txtThickB.Enter, TxtThickC.Enter, txtThickCeiling.Enter, txtThickD.Enter, txtKFACTORwA.Enter, txtKFACTORwB.Enter, txtKFACTORwC.Enter, txtKFACTORwD.Enter, TxtFExtTemp.Enter, txtThickF.Enter, txtThickFloor.Enter, TxtKFactorF.Enter, TxtCExtTemp.Enter, TxtKFactorC.Enter, TxtInfWB.Enter, TxtInfDB.Enter, txtIAirChange.Enter, TxtCFHeat.Enter, TxtFLatent.Enter, TxtCIbs.Enter, TxtCEnter.Enter, TxtCFinal.Enter, TxtRIbs.Enter, TxtRHeat.Enter, TxtMotorHP.Enter, TxtPeople.Enter, TxtOtherBTU.Enter, TxtCHeat.Enter, txtForkLift.Enter, txtDockDoors.Enter, txtWallA.Enter, txtWallB.Enter, txtWallC.Enter, txtWallD.Enter, txtWallE.Enter, txtWallF.Enter, txtHeightA.Enter, txtHeightB.Enter, txtHeightC.Enter, txtHeightD.Enter, txtHeightE.Enter, txtHeightF.Enter

      Dim X As TextBox = sender

      X.SelectionStart = 0
      X.SelectionLength = Len(X.Text)
   End Sub


   Private Sub ALL_KeyPress(sender As Object, e As KeyPressEventArgs) _
   Handles txtExternalTemperatureA.KeyPress, txtThickA.KeyPress, txtKFACTORwA.KeyPress, txtExternalTemperatureB.KeyPress, txtThickB.KeyPress, txtKFACTORwB.KeyPress, txtKFACTORwE.KeyPress, txtExternalTemperatureC.KeyPress, TxtThickC.KeyPress, txtThickCeiling.KeyPress, txtKFACTORwC.KeyPress, txtExternalTemperatureD.KeyPress, txtExternalTemperatureE.KeyPress, txtExternalTemperatureF.KeyPress, txtThickD.KeyPress, txtKFACTORwD.KeyPress, TxtFExtTemp.KeyPress, txtThickE.KeyPress, txtThickF.KeyPress, txtThickFloor.KeyPress, TxtKFactorF.KeyPress, TxtCExtTemp.KeyPress, TxtKFactorC.KeyPress, TxtInfWB.KeyPress, TxtInfDB.KeyPress, txtIAirChange.KeyPress, TxtCHeat.KeyPress, TxtCFHeat.KeyPress, TxtFLatent.KeyPress, TxtCIbs.KeyPress, TxtCEnter.KeyPress, TxtCFinal.KeyPress, TxtRIbs.KeyPress, TxtRHeat.KeyPress, TxtMotorHP.KeyPress, cboLightingWatts.KeyPress, TxtPeople.KeyPress, TxtOtherBTU.KeyPress, TxtOtherType.KeyPress, txtRwA.KeyPress, txtRwB.KeyPress, txtRwC.KeyPress, txtRwD.KeyPress, txtRwE.KeyPress, txtRwF.KeyPress, txtRCeiling.KeyPress, txtRFloor.KeyPress, txtForkLift.KeyPress, txtDockDoors.KeyPress, txtWallA.KeyPress, txtWallB.KeyPress, txtWallC.KeyPress, txtWallD.KeyPress, txtWallE.KeyPress, txtWallF.KeyPress, txtHeightA.KeyPress, txtHeightB.KeyPress, txtHeightC.KeyPress, txtHeightD.KeyPress, txtHeightE.KeyPress, txtHeightF.KeyPress, CboINSULA.KeyPress, CboINSULB.KeyPress, CboInsulC.KeyPress, CboINSULD.KeyPress, CboINSULE.KeyPress, cboinsulf.KeyPress, CboINSULFloor.KeyPress, cboinsulCeiling.KeyPress, TxtCExtTemp.KeyPress
      Dim KeyAscii As Short = Asc(e.KeyChar)
      If KeyAscii = 13 Then
         System.Windows.Forms.SendKeys.Send("{Tab}")
         KeyAscii = 0
      End If
      e.KeyChar = Chr(KeyAscii)
      If KeyAscii = 0 Then
         e.Handled = True
      End If
   End Sub


   Private Sub txtRwA_Leave(sender As Object, e As EventArgs) _
   Handles txtRwA.Leave, txtRwB.Leave, txtRwC.Leave, txtRwD.Leave, txtRwE.Leave, txtRwF.Leave
      Try
         If CDbl(sender.Text) <= 0 Then
            MsgBox("Zero And Negative Values for R-Value Are Not Allowed, Defaulting To 16")
            sender.Text = "16"
         End If
      Catch ex As Exception
         MsgBox("Value for R-Value Not Allowed, Defaulting To 16")
         sender.Text = "16"
      End Try

      If BtnAllWallsY.Checked = True Then
         txtRwB.Text = txtRwA.Text
         txtRwC.Text = txtRwA.Text
         txtRwD.Text = txtRwA.Text
         txtRwE.Text = txtRwA.Text
         txtRwF.Text = txtRwA.Text
      End If

      R2Kfactors()
      CalcWallLoad()
   End Sub


   Private Sub txtRCeiling_Leave(sender As Object, e As EventArgs) Handles txtRCeiling.Leave
      Try
         If CDbl(sender.Text) <= 0 Then
            MsgBox("Zero And Negative Values for R-Value Are Not Allowed, Defaulting To 16")
            sender.Text = "16"
         End If
      Catch ex As Exception
         MsgBox("Value for R-Value Not Allowed, Defaulting To 16")
         sender.Text = "16"
      End Try
      R2Kfactors()
      CalcCeilingLoad()
   End Sub

   Private Sub txtRFloor_Leave(sender As Object, e As EventArgs) Handles txtRFloor.Leave
      Try
         If CDbl(sender.Text) <= 0 Then
            MsgBox("Zero And Negative Values for R-Value Are Not Allowed, Defaulting To 16")
            sender.Text = "16"
         End If
      Catch ex As Exception
         MsgBox("Value for R-Value Not Allowed, Defaulting To 16")
         sender.Text = "16"
      End Try
      R2Kfactors()
      CalcFloorLoad()
   End Sub


   Private Sub txtForkLift_Leave(sender As Object, e As EventArgs) Handles txtForkLift.Leave
      Try
         txtTotForkLift.Text = VB6.Format(CDbl(txtForkLift.Text) * 396000, "##,###,##0")
         calculateTotalInfiltration()
      Catch ex As Exception
         txtTotForkLift.Text = "0"
         txtForkLift.Text = "0"
      End Try
   End Sub


   Private Sub txtDockDoors_Leave(sender As Object, e As EventArgs) Handles txtDockDoors.Leave
      Try
         txttotdockdoors.Text = VB6.Format(CDbl(txtDockDoors.Text) * 522000, "#,###,###,##0")
         calculateTotalInfiltration()
      Catch ex As Exception
         txttotdockdoors.Text = "0"
         txtDockDoors.Text = "0"
      End Try
   End Sub


   Function walladjust() As Boolean
      If RdoRectangle.Checked = True Then
         txtWallD.Text = txtWallB.Text
         txtWallC.Text = txtWallA.Text
         Try
            txtFloorCeilingArea.Text = Val(txtWallB.Text) * Val(txtWallA.Text)
         Catch ex As Exception
            txtFloorCeilingArea.Text = 0

         End Try
      Else
         Try
            Dim x As Single

            txtWallE.Text = Val(txtWallA.Text) - Val(txtWallC.Text)

            txtWallF.Text = Val(txtWallB.Text) - Val(txtWallD.Text)

            x = Val(txtWallA.Text) * Val(txtWallB.Text) - Val(txtWallC.Text) * Val(txtWallD.Text)
            txtFloorCeilingArea.Text = x
            txtFloorCeilingArea.BackColor = Color.White


         Catch ex As Exception
            txtFloorCeilingArea.Text = 0

         End Try
      End If
      checkRed()

   End Function


   Private Sub txtWallB_Leave(sender As Object, e As EventArgs) _
   Handles txtWallB.Leave, txtWallA.Leave, txtWallC.Leave, txtWallD.Leave, txtWallE.Leave, txtWallF.Leave
      walladjust()

      CalcFloorLoad()
      CalcCeilingLoad()
      CalcWallLoad()
   End Sub


   Private Sub checkRed()
      txtWallE.BackColor = Color.Cyan

      txtWallF.BackColor = Color.Cyan
      txtFloorCeilingArea.BackColor = Color.Cyan
      If Val(txtWallE.Text) <= 0 Then
         txtWallE.BackColor = Color.Red
      End If
      If Val(txtWallF.Text) <= 0 Then
         txtWallF.BackColor = Color.Red
      End If
      If Val(txtFloorCeilingArea.Text) <= 0 Then
         txtFloorCeilingArea.BackColor = Color.Red
      End If
   End Sub


   Private Sub txtHeightA_TextChanged(sender As System.Object, e As EventArgs) Handles txtHeightA.TextChanged
      txtHeightB.Text = txtHeightA.Text
      txtHeightC.Text = txtHeightA.Text
      txtHeightD.Text = txtHeightA.Text
      txtHeightE.Text = txtHeightA.Text
      txtHeightF.Text = txtHeightA.Text

      txtVolume.Text = roomvolume()
   End Sub


   Private Sub btnLshape_Click(sender As System.Object, e As EventArgs) Handles btnLshape.Click
      TxtImageCounter.Text = Val(TxtImageCounter.Text) + 1

      If Val(TxtImageCounter.Text) > 4 Then
         TxtImageCounter.Text = "1"
      End If

      PicLShape.Image = roomL(Trim(TxtImageCounter.Text))
   End Sub


   Private Sub btnSaveProduct_Click(sender As System.Object, e As EventArgs)
      Dim recnum As Integer = addproducttoproject()
      EDITProductinPRoject(recnum)
      showUserProducts()
   End Sub

   ''' <summary>
   ''' Retrieves data, shows in grid, calculates sum.
   ''' </summary>
   Private Function showUserProducts() As Boolean
      SelectedProducts = cl_connection.CreateGeneralTable( _
         "SELECT Product,[Type],Cibs,ProdTot,id FROM CoolStuffProductSelections " & _
         "WHERE projectid = " & BoxLoad.DbId & " ORDER BY Product,[type]", "UI")
      dgProducts.DataSource = SelectedProducts
      dgProducts.Columns(4).Visible = False

      ' calculates total capacity
      Dim allsum As Single = 0
      Dim dr As DataRow
      For Each dr In SelectedProducts.Rows
         allsum = allsum + CDbl(dr(3))
      Next

      txtTotAllProducts.Text = VB6.Format(allsum, "###,###,###,###,##0")
      TxtSumProd.Text = VB6.Format(allsum, "###,###,###,###,##0")
   End Function


   Private Sub forceProductupdate()
      Select Case txtProductId.Text
         Case "0"

            If Val(TxtCFTot.Text) + Val(TxtRTot.Text) > 0 Then
               Dim i As Integer
               i = addproducttoproject()
               txtProductId.Text = i
               EDITProductinPRoject(i)
               showRemoveProductControls(True)

            Else
               cl_connection.ExecuteSql("delete from CoolStuffProductSelections where id = " & txtProductId.Text, "UI")
               txtProductId.Text = "0"
               showRemoveProductControls(False)

            End If

         Case Else
            If Val(TxtCFTot.Text) + Val(TxtRTot.Text) > 0 Then
               EDITProductinPRoject(Val(txtProductId.Text))
               showRemoveProductControls(True)

            Else
               cl_connection.ExecuteSql("delete from CoolStuffProductSelections where id = " & txtProductId.Text, "UI")
               cboProduct.SelectedIndex = -1
               CboType.Text = ""
               CboType.SelectedIndex = -1
               txtProductId.Text = "0"
               showRemoveProductControls(False)
            End If

      End Select
      showUserProducts()
   End Sub


   Private Sub dgProducts_Click(sender As Object, e As EventArgs) _
   Handles dgProducts.Click
      If dgProducts.Rows.Count <= 0 _
      OrElse dgProducts.SelectedRows.Count = 0 Then Exit Sub

      Dim i As Integer
      dgProducts.Rows(sender.currentrow.index).Selected = True
      i = dgProducts.CurrentRow.Cells(4).Value
      forceProductupdate()

      txtProductId.Text = i
      showProductDetail(i)
      showRemoveProductControls(True)

   End Sub


   Private Sub dgProducts_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) _
   Handles dgProducts.CellContentClick
      Dim i As Integer
      If dgProducts.SelectedRows.Count <= 0 Then Exit Sub
      i = dgProducts.SelectedRows.Item(0).Cells(4).Value
      forceProductupdate()

      txtProductId.Text = i
      showProductDetail(i)
      showRemoveProductControls(True)
   End Sub


   Private Sub txtTotAllProducts_TextChanged(sender As Object, e As EventArgs) Handles txtTotAllProducts.TextChanged
      TxtSumProd.Text = txtTotAllProducts.Text
      CalcSubTotal()
   End Sub


   Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
      If MsgBox("You are about to remove this product from the Load List" & Chr(10) & Chr(10) & "Are you sure", MsgBoxStyle.YesNo, "Remove Product from Load List") = MsgBoxResult.Yes Then
         cl_connection.ExecuteSql("delete from CoolStuffProductSelections where id = " & txtProductId.Text, "UI")
         showUserProducts()
         If SelectedProducts.Rows.Count > 0 Then
            showProductDetail(SelectedProducts.Rows(0).Item(4))
         End If
      End If
   End Sub


   Private Function roomvolume() As Single
      roomvolume = 0
      Try
         roomvolume = txtFloorCeilingArea.Text * txtHeightA.Text
      Catch ex As Exception
      End Try
   End Function


   Private Sub txtFloorCeilingArea_TextChanged(sender As Object, e As EventArgs) Handles txtFloorCeilingArea.TextChanged
      txtVolume.Text = roomvolume()
      CalcVolume()

      txtFloorCeilingArea.BackColor = Color.Red
      If Val(txtFloorCeilingArea.Text) > 0 Then
         txtFloorCeilingArea.BackColor = Color.Cyan
      End If
   End Sub


   Private Sub btndefault_Click(sender As Object, e As EventArgs) Handles btndefault.Click
      TxtCIbs.Text = Int(Val(txtVolume.Text) * 2)
   End Sub


   Private Sub TxtCIbs_TextChanged(sender As Object, e As EventArgs) Handles TxtCIbs.TextChanged
      Try
         CalcDoWhat()
      Catch ex As Exception
      End Try
   End Sub


   Private Sub TxtSumTot_TextChanged(sender As Object, e As EventArgs) Handles TxtSumTot.TextChanged
      CalcLoad()
   End Sub


   Private Sub btnSaveCityState_Click(sender As Object, e As EventArgs) Handles btnSaveCityState.Click
      cl_connection.ExecuteSql("delete from coolstuffpreferences", "UI")
      Dim sql As String
      sql = "insert into CoolStuffpreferences (mydefaultstate,mydefaultcity) values ("
      sql = sql & "'" & cboState.Text & "'"
      sql = sql & ",'" & cbocity.Text & "')"
      cl_connection.ExecuteSql(sql, "UI")
   End Sub


   Private Sub dgRep_Click(sender As Object, e As EventArgs) Handles dgRep.Click
      If sender.currentrow Is Nothing Then Exit Sub

      dgRep.Rows(sender.currentrow.index).Selected = True
      txt_representative_id.Text = dgRep.CurrentRow.Cells(3).Value
   End Sub


   Private Sub dgcontact_Click(sender As Object, e As EventArgs) Handles dgCustomer.Click
      If sender.currentrow Is Nothing Then Exit Sub

      dgCustomer.Rows(sender.currentrow.index).Selected = True
      txt_customer_id.Text = dgCustomer.CurrentRow.Cells(3).Value
   End Sub


   Private Sub fillContacts(projectId As String)
      Dim sql As String, ct1 As DataTable

      If projectId > "0" Then
         btnContacts.Visible = True

         sql = "SELECT Companies.Name as [Company Name], Contacts.LastName as [Contact Last Name], Contacts.FirstName as [Contact First Name], Contacts.Id"
         sql = sql & " FROM ((Projects INNER JOIN ProjectContacts ON Projects.ProjectId = ProjectContacts.ProjectId) INNER JOIN (Companies INNER JOIN Contacts ON Companies.Id = Contacts.CompanyId) ON ProjectContacts.ContactId = Contacts.Id) "
         sql = sql & " WHERE  Projects.ProjectId='" & projectId & "'"
      Else
         sql = "SELECT Companies.Name as [Company Name], Contacts.LastName as [Contact Last Name], Contacts.FirstName as [Contact First Name], Contacts.Id FROM Companies INNER JOIN Contacts ON Companies.Id = Contacts.CompanyId ORDER BY Companies.Name, Contacts.LastName"
      End If
      ''sql = "SELECT Projects.ProjectId, Projects.Name, ProjectContacts.ProjectId, Contacts.CompanyId, Contacts.FirstName, Contacts.LastName, Companies.Name, Companies.Line1, Companies.Line2, Companies.City, Companies.State, Companies.ZipCode5, Companies.ZipCode4, Companies.PhoneNumAreaCode, Companies.PhoneNum, Companies.FaxNumAreaCode, Companies.FaxNum, Companies.Email "
      ''sql = sql & " FROM ((Projects INNER JOIN ProjectContacts ON Projects.ProjectId = ProjectContacts.ProjectId) INNER JOIN (Companies INNER JOIN Contacts ON Companies.Id = Contacts.CompanyId) ON ProjectContacts.ContactId = Contacts.Id) "
      ' ''sql = sql & " WHERE Companies.Description='General Contractor' AND Projects.ProjectId='" & openprojectid & "'"
      ct1 = cl_connection.CreateGeneralTable(sql, "UI")
      Dim dvrep As DataView, dvcontact As DataView

      dvrep = New DataView(ct1, "", "[company name] ASC", DataViewRowState.CurrentRows)
      dgRep.DataSource = dvrep
      dvcontact = New DataView(ct1, "", "[company name] ASC", DataViewRowState.CurrentRows)
      dgCustomer.DataSource = dvcontact
      If dvrep.Count > 0 Then
         txt_representative_id.Text = dvrep(0).Item(3)
         txt_customer_id.Text = dvrep(0).Item(3)

      End If
      dgRep.Columns(3).Visible = False
      dgCustomer.Columns(3).Visible = False
      dgRep.Columns(0).Width = dgRep.Width * 0.4
      dgCustomer.Columns(0).Width = dgCustomer.Width * 0.4

   End Sub
   

    Private Sub reportTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reportTool.Click

    End Sub

    Private Sub saveTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveTool.Click

    End Sub
End Class

'3160