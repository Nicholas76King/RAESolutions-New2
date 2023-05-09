Imports Rae.Persistence
Imports Rae.RaeSolutions.Persistence
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.Data.Access

Public Partial Class frmboxloadcalc2
   
   ''' <summary>
   ''' Box load that represents controls in form
   ''' </summary>
   Property BoxLoad() As BoxLoad
      Get
         If boxLoad_ Is Nothing Then
            boxLoad_ = New BoxLoad(IdGen.Gen(), OpenedProject.Manager)
            persistence = New PersistenceController(boxLoad_)
            Tag = boxLoad_.id.ToString()
            boxLoad_.Refresh = New RefreshSignature(AddressOf updateBoxLoadObject)
         End If
         Return boxLoad_
      End Get
      Set(value As BoxLoad)
         boxLoad_ = value
         persistence = New PersistenceController(boxLoad_)
         Tag = boxLoad_.id.ToString()
         boxLoad_.Refresh = New RefreshSignature(AddressOf updateBoxLoadObject)
         
         updateForm(boxLoad_)
         CalcSubTotal()
      End Set
   End Property : Protected boxLoad_ As BoxLoad   
   
   
   Private da As BoxLoadProjects
   Private WithEvents navigation As NavigationController
   Private persistence As PersistenceController
   Private isClosed, closingHandled As Boolean


   Private Sub form_Activated(sender As Object, e As EventArgs) _
   Handles Me.Activated
      navigation.Item = Me.BoxLoad
      
      ' initializes new navigator (only being used by box load for now)
      With AppInfo.Main.RevisionNavigator1
         .Visible = True
         AddHandler .Navigated, AddressOf navigator_Navigated
      End With
      
      ' hides old navigator
      AppInfo.Main.RevisionView1.Visible = False
   End Sub
   
   Private Sub form_Closing(sender As Object, e As FormClosingEventArgs) _
   Handles Me.FormClosing
      If closingHandled Then Exit Sub
      
      e.Cancel = persistence.OnClose()
   End Sub
   
   Private Sub form_Closed(sender As Object, e As FormClosedEventArgs) _
   Handles Me.FormClosed
      isClosed = True
   End Sub
   
   Private Sub form_Deactivate(sender As Object, e As EventArgs) _
   Handles Me.Deactivate
      navigation.Item = Nothing
      
      ' removes event handlers otherwise handlers get called multiple times
      If isClosed Then _
         Me.navigation.Dispose()
      
      ' hides new revision navigator (NOT used by other items)
      With AppInfo.Main.RevisionNavigator1
         .Visible = False
         RemoveHandler .Navigated, AddressOf navigator_Navigated
      End With
      
      ' re-shows old revision navigator used by other items
      AppInfo.Main.RevisionView1.Visible = True
   End Sub
   
   
   Private Sub close_Click(sender As Object, e As EventArgs) _
   Handles closeMenuItem.Click
      Close()
   End Sub

   Private Sub saveAndExitMenu_Click(sender As Object, e As EventArgs) _
   Handles saveAndCloseTool.Click
      Dim canceled = save()
      If canceled Then
         Exit Sub
      Else
         closingHandled = True
         Close()
      End If
   End Sub
   
   Private Sub save_Click(sender As Object, e As EventArgs) _
   Handles saveMenuItem.Click, saveTool.Click
      save()
   End Sub

   Private Sub saveAsRevision_Click(sender As Object, e As EventArgs) _
   Handles saveAsRevisionMenuItem.Click
      persistence.OnSaveAsRevision()
   End Sub
   
   Private Sub report_Click(sender As Object, e As EventArgs) _
   Handles mnuPrint.Click, reportTool.Click
      show_report()
   End Sub
   
   Private Sub navigator_Navigated(sender As ICanNavigate, e As NavigatedEventArgs)
      updateForm(BoxLoad)
   End Sub
   
   
   
   
   
   Private Function save() As Boolean
      Dim canceled = persistence.OnSave()
      updateUserProductIds(BoxLoad.DbId)
      Return canceled
   End Function
   
   Private Sub updateUserProductIds(projectId As Integer)
      da.ExecuteNonQuery("UPDATE CoolStuffProductSelections " & _
                         "SET ProjectId=" & projectId & " WHERE ProjectId=0")
   End Sub

   Private Sub updateBoxLoadObject()
      With Me.BoxLoad
         .ProjectManager = OpenedProject.Manager
         .Description = txtDescription.Text
         
         .Ambient = TxtAmbient.Text
         .ExternalWb = TxtExtWB.Text
         .RoomTemperature = TxtRmTemp.Text
         '.RmWb = TxtRMWB.Text
         .RoomWetBulb = TxtRMWB.Text
         .ExternalWallTemperature1 = txtExternalTemperatureA.Text
         .ExternalWallTemperature2 = txtExternalTemperatureB.Text
         .ExternalWallTemperature3 = txtExternalTemperatureC.Text
         .ExternalWallTemperature4 = txtExternalTemperatureD.Text
         .ExternalWallTemperature5 = txtExternalTemperatureE.Text
         .ExternalWallTemperature6 = txtExternalTemperatureF.Text
         .InsulW1 = cboInsulA.Text
         .InsulW2 = cboInsulB.Text
         .InsulW3 = cboInsulC.Text
         .InsulW4 = cboInsulD.Text
         .InsulW5 = cboInsulE.Text
         .InsulW6 = cboInsulF.Text
         
         .ThickW1 = txtThickA.Text
         .ThickW2 = txtThickB.Text
         .ThickW3 = txtThickC.Text
         .ThickW4 = txtThickD.Text
         .ThickW5 = txtThickE.Text
         .ThickW6 = txtThickF.Text
         
         .KFactor1 = txtKFactorWA.Text
         .KFactor2 = txtKFACTORwB.Text
         .KFactor3 = txtKFACTORwC.Text
         .KFactor4 = txtKFACTORwD.Text
         .KFactor5 = txtKFACTORwE.Text
         .KFactor6 = txtKFACTORwF.Text
         
         .WallTotal = txtWallTot.Text
         .FExtTemp = txtFExtTemp.Text
         .InsulF = CboINSULFloor.Text
         .ThickF = txtThickFloor.Text
         .KFactorF = TxtKFactorF.Text
         .FloorTotal = TxtFloorTot.Text
         .CExtTemp = TxtCExtTemp.Text
         .InsulC = cboinsulCeiling.Text
         .ThickC = txtThickCeiling.Text
         .KFactorC = TxtKFactorC.Text
         .CeilingTotal = TxtCeilingTot.Text
         .TransTotal = TxtTotTrans.Text
         .IVolume = TxtIVolume.Text
         .InfWb = TxtInfWB.Text
         .InfDb = TxtInfDB.Text
         .IFactor = cbo_ashrae_usage_factor.Text
         .IAirChg = txtIAirChange.Text
         .TotalInfil = txtTotInfil.Text
         
         .RoomArea = txtFloorCeilingArea.Text
         .RoomVolume = txtVolume.Text
         .Wall1 = txtWallA.Text
         .Wall2 = txtWallB.Text
         .Wall3 = txtWallC.Text
         .Wall4 = txtWallD.Text
         .Wall5 = txtWallE.Text
         .Wall6 = txtWallF.Text
         
         .Height1 = txtHeightA.Text
         .Height2 = txtHeightB.Text
         .Height3 = txtHeightC.Text
         .Height4 = txtHeightD.Text
         .Height5 = txtHeightE.Text
         .Height6 = txtHeightF.Text
         
         .txtImageCounter = TxtImageCounter.Text
         .rdoRectangle = RdoRectangle.Checked
         
         .WattL = cboLightingWatts.Text
         .TotalOl = txtTotOl.Text
         .MotorHp = TxtMotorHP.Text
         .TotalOm = txtTotOM.Text
         .People = txtPeople.Text
         
         .TotalOP = TxtTotOP.Text
         .OtherType = TxtOtherType.Text
         .OtherBtu = TxtOtherBTU.Text
         .TotalOo = TxtTotOO.Text
         .OtherTotal = txtTotOther.Text
         .ForkLift = txtForkLift.Text
         .ForkLiftTotal = txtTotForkLift.Text
         .DockDoors = txtDockDoors.Text
         .DockDoorsTotal = txttotdockdoors.Text
         
         .SumTran = txtSumTrans.Text
         .SumInf = TxtSumInf.Text
         .SumProd = TxtSumProd.Text
         .SumOther = TxtSumOther.Text
         .SumTotal = TxtSumTot.Text
         .Safety = cboSafety.Text
         .SafetyTotal = TxtSafetyTot.Text
         .RunVar = cboRunVar.Text
         .RunVarTotal = txtRunVarTot.Text
         .LoadTotal = txtLoadTot.Text
         .btnAllWallSy = BtnAllWallsY.Checked
         '   IIf(Rae.RaeSolutions.DataAccess.Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL, Rae.RaeSolutions.Utility.ConvertDB(BtnAllWallsY.Checked.GetType(), BtnAllWallsY.Checked.ToString).ToString, BtnAllWallsY.Checked)
         .btnAllWallSn = BtnAllWallsN.Checked
         '   IIf(Rae.RaeSolutions.DataAccess.Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL, Rae.RaeSolutions.Utility.ConvertDB(BtnAllWallsN.Checked.GetType(), BtnAllWallsN.Checked.ToString).ToString, BtnAllWallsN.Checked)
         .MyState = cboState.Text
         .MyCity = cboCity.Text
         
         .KFactors = rdoKFactor.Checked
         'sql = sql & ", kfactors = " & IIf(Rae.RaeSolutions.DataAccess.Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL, Rae.RaeSolutions.Utility.ConvertDB(rdoKFactor.Checked.GetType(), rdoKFactor.Checked.ToString).ToString, rdoKFactor.Checked) 'rdoKFactor.Checked
         .Rw1 = txtRwA.Text
         .Rw2 = txtRwB.Text
         .Rw3 = txtRwC.Text
         .Rw4 = txtRwD.Text
         .Rw5 = txtRwE.Text
         .Rw6 = txtRwF.Text
         
         .RwFloor = txtRFloor.Text
         .RwCeiling = txtRCeiling.Text
         .RoomNumber = "0"
      End With
   End Sub

   Private Sub updateForm(boxLoad As BoxLoad)
      With boxLoad
         txtDescription.Text = .Description
         
         TxtAmbient.Text = .Ambient
         TxtExtWB.Text = .ExternalWb
         TxtRmTemp.Text = .RoomTemperature
         'TxtRMWB.Text = .RmWb
         TxtRMWB.Text = .RoomWetBulb
         
         cboInsulA.Text = .InsulW1
         cboInsulB.Text = .InsulW2
         cboInsulC.Text = .InsulW3
         cboInsulD.Text = .InsulW4
         cboInsulE.Text = .InsulW5
         cboInsulF.Text = .InsulW6
         
         txtThickA.Text = .ThickW1
         txtThickB.Text = .ThickW2
         txtThickC.Text = .ThickW3
         txtThickD.Text = .ThickW4
         txtThickE.Text = .ThickW5
         txtThickF.Text = .ThickW6
         
         txtKFactorWA.Text = .KFactor1
         txtKFACTORwB.Text = .KFactor2
         txtKFACTORwC.Text = .KFactor3
         txtKFACTORwD.Text = .KFactor4
         txtKFACTORwE.Text = .KFactor5
         txtKFACTORwF.Text = .KFactor6
         
         txtWallTot.Text = .WallTotal
         txtFExtTemp.Text = .FExtTemp
         CboINSULFloor.Text = .InsulF
         txtThickFloor.Text = .ThickF
         TxtKFactorF.Text = .KFactorF
         TxtFloorTot.Text = .FloorTotal
         TxtCExtTemp.Text = .CExtTemp
         cboinsulCeiling.Text = .InsulC
         txtThickCeiling.Text = .ThickC
         TxtKFactorC.Text = .KFactorC
         TxtCeilingTot.Text = .CeilingTotal
         TxtTotTrans.Text = .TransTotal
         TxtIVolume.Text = .IVolume
         TxtInfWB.Text = .InfWb
         TxtInfDB.Text = .InfDb
         cbo_ashrae_usage_factor.Text = .IFactor
         txtIAirChange.Text = .IAirChg
         txtTotInfil.Text = .TotalInfil

         ' due to current calculations, height should be set before area
         txtHeightA.Text = .Height1
         txtHeightB.Text = .Height2
         txtHeightC.Text = .Height3
         txtHeightD.Text = .Height4
         txtHeightE.Text = .Height5
         txtHeightF.Text = .Height6
         
         txtFloorCeilingArea.Text = .RoomArea
         txtVolume.Text = .RoomVolume
         txtWallA.Text = .Wall1
         txtWallB.Text = .Wall2
         txtWallC.Text = .Wall3
         txtWallD.Text = .Wall4
         txtWallE.Text = .Wall5
         txtWallF.Text = .Wall6
         
         TxtImageCounter.Text = .txtImageCounter
         RdoRectangle.Checked = .rdoRectangle
         rdoL.Checked = Not .rdoRectangle
         cboLightingWatts.Text = .WattL
         txtTotOl.Text = .TotalOl
         TxtMotorHP.Text = .MotorHp
         txtTotOM.Text = .TotalOm
         txtPeople.Text = .People
         
         TxtTotOP.Text = .TotalOP
         TxtOtherType.Text = .OtherType
         TxtOtherBTU.Text = .OtherBtu
         TxtTotOO.Text = .TotalOo
         txtTotOther.Text = .OtherTotal
         txtForkLift.Text = .ForkLift
         txtTotForkLift.Text = .ForkLiftTotal
         txtDockDoors.Text = .DockDoors
         txttotdockdoors.Text = .DockDoorsTotal
         
         txtSumTrans.Text = .SumTran
         TxtSumInf.Text = .SumInf
         TxtSumProd.Text = .SumProd
         TxtSumOther.Text = .SumOther
         TxtSumTot.Text = .SumTotal
         cboSafety.Text = .Safety
         TxtSafetyTot.Text = .SafetyTotal
         cboRunVar.Text = .RunVar
         txtRunVarTot.Text = .RunVarTotal
         txtLoadTot.Text = .LoadTotal
         BtnAllWallsY.Checked = .btnAllWallSy
         '   IIf(Rae.RaeSolutions.DataAccess.Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL, Rae.RaeSolutions.Utility.ConvertDB(BtnAllWallsY.Checked.GetType(), BtnAllWallsY.Checked.ToString).ToString, BtnAllWallsY.Checked)
         BtnAllWallsN.Checked = .btnAllWallSn
         '   IIf(Rae.RaeSolutions.DataAccess.Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL, Rae.RaeSolutions.Utility.ConvertDB(BtnAllWallsN.Checked.GetType(), BtnAllWallsN.Checked.ToString).ToString, BtnAllWallsN.Checked)
         cboState.Text = .MyState
         cboCity.Text = .MyCity
         
         TxtAmbient.Text = .Ambient
         TxtExtWB.Text = .ExternalWb
         TxtRmTemp.Text = .RoomTemperature
         TxtRMWB.Text = .RoomWetBulb
         
         ' don't set ext temp until ambient is set otherwise leave handler writes over ext temp
         txtExternalTemperatureA.Text = .ExternalWallTemperature1
         txtExternalTemperatureB.Text = .ExternalWallTemperature2
         txtExternalTemperatureC.Text = .ExternalWallTemperature3
         txtExternalTemperatureD.Text = .ExternalWallTemperature4
         txtExternalTemperatureE.Text = .ExternalWallTemperature5
         txtExternalTemperatureF.Text = .ExternalWallTemperature6
         
         rdoKFactor.Checked = .KFactors
         rdoRFactor.Checked = Not .KFactors
         'sql = sql & ", kfactors = " & IIf(Rae.RaeSolutions.DataAccess.Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL, Rae.RaeSolutions.Utility.ConvertDB(rdoKFactor.Checked.GetType(), rdoKFactor.Checked.ToString).ToString, rdoKFactor.Checked) 'rdoKFactor.Checked
         txtRwA.Text = .Rw1
         txtRwB.Text = .Rw2
         txtRwC.Text = .Rw3
         txtRwD.Text = .Rw4
         txtRwE.Text = .Rw5
         txtRwF.Text = .Rw6
         
         txtRFloor.Text = .RwFloor
         txtRCeiling.Text = .RwCeiling
         
         showUserProducts()
      End With
   End Sub
   
End Class