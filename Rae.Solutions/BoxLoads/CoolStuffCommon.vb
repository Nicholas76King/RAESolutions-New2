Imports System.Data
Imports System.Windows.Forms

Namespace CoolStuff

Public Class CoolStuffCommon

#Region "COOL STUFF STUFF"
   Public Id As Integer
   'Public CoolStuffReadMe As Boolean
   Public ShowBoxLoadGrid As Boolean
   Public Division As Integer


#Region " Properties"

   Private m_CoolStuffForm As Object
   ''' <summary>
   ''' 
   ''' </summary>
   Property CoolStuffForm() As Object
      Set(ByVal value As Object)
         Me.m_CoolStuffForm = value
      End Set
      Get
         Return Me.m_CoolStuffForm
      End Get
   End Property

   Private m_CoolStuffCallingForm As Object
   ''' <summary>
   ''' CallingForm
   ''' </summary>
   Property CallingForm() As Object
      Set(ByVal value As Object)
         Me.m_CoolStuffCallingForm = value
      End Set
      Get
         Return Me.m_CoolStuffCallingForm
      End Get
   End Property

   Private m_CoolStuffBlName As String
   ''' <summary>
   ''' CallingForm
   ''' </summary>
   Property CoolStuffBlName() As String
      Set(ByVal value As String)
         Me.m_CoolStuffBlName = value
      End Set
      Get
         Return Me.m_CoolStuffBlName
      End Get
   End Property

   Private m_CoolStuffOpenProjectID As String
   ''' <summary>
   ''' CallingForm
   ''' </summary>
   Property OpenProjectID() As String
      Set(ByVal value As String)
         Me.m_CoolStuffOpenProjectID = value
      End Set
      Get
         Return Me.m_CoolStuffOpenProjectID
      End Get
   End Property

   Private m_CoolStuffUserCapacity As Single
   Property CoolStuffUserCapacity() As Single
      Get
         Return Me.m_CoolStuffUserCapacity
      End Get
      Set(ByVal value As Single)
         Me.m_CoolStuffUserCapacity = value
      End Set
   End Property

   Private m_CoolStuffUserCapacityChecked As Boolean
   Property UserCapacityChecked() As Boolean
      Get
         Return Me.m_CoolStuffUserCapacityChecked
      End Get
      Set(ByVal value As Boolean)
         Me.m_CoolStuffUserCapacityChecked = value
      End Set
   End Property

   Private m_CoolStuffCapacity As String
   Property Capacity() As String
      Set(value As String)
         Me.m_CoolStuffCapacity = value
      End Set
      Get
         Return Me.m_CoolStuffCapacity
      End Get
   End Property

   Private m_CoolStuffUserSuppliedCapacity As String
   Property UserSuppliedCapacity() As String
      Set(ByVal value As String)
         Me.m_CoolStuffUserSuppliedCapacity = value
      End Set
      Get
         Return Me.m_CoolStuffUserSuppliedCapacity
      End Get
   End Property

   Private m_CoolStuffUserSuppliedCapacityText As String
   Property CapacityUnits() As String
      Set(ByVal value As String)
         Me.m_CoolStuffUserSuppliedCapacityText = value
      End Set
      Get
         Return Me.m_CoolStuffUserSuppliedCapacityText
      End Get
   End Property

   Private m_CoolStuffRuntime As String
   Property RunTime() As String
      Set(value As String)
         Me.m_CoolStuffRuntime = value
      End Set
      Get
         Return Me.m_CoolStuffRuntime
      End Get
   End Property

   Private m_CoolStuffambient As String
   Property Ambient() As String
      Set(value As String)
         Me.m_CoolStuffambient = value
      End Set
      Get
         Return Me.m_CoolStuffambient
      End Get
   End Property
   
   Private m_CoolStuffRoomTemp As String
   Property CoolStuffRoomTemp() As String
      Set(value As String)
         Me.m_CoolStuffRoomTemp = value
      End Set
      Get
         Return Me.m_CoolStuffRoomTemp
      End Get
   End Property

#End Region


   ''' <summary>
   ''' Inserts new incomplete record
   ''' </summary>
   Function CreateNewRecord() As Integer
      Dim sql As String, i As Integer

      Dim itisnow As String = Now
      'If Rae.RAESolutions.DataAccess.Common.DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
      sql = "insert into CoolStuffProjects (processid,revision,createdwhen) values ('" & itisnow & "',-1,'" & Now & "')"
      'ElseIf Rae.RaeSolutions.DataAccess.Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
      'sql = "insert into CoolStuffProjects (processid,revision,createdwhen) values ('" & itisnow & "',-1,#" & Now & "#)"
      'End If
      'sql = "insert into CoolStuffProjects (processid,revision,createdwhen) values ('" & itisnow & "',-1,#" & Now & "#)"
      cl_connection.ExecuteSql(sql, "UI")
      i = CoolStuff.cl_connection.GetProjectRecordNumber(itisnow, -1, "UI")
      cl_connection.CleanTrashRecords()

      'CoolStuffRecordNumber = i

      Return i
   End Function


   ''' <summary>
   ''' Initializes control values, shows form, then gets updated values after form closes.
   ''' </summary>
   Sub PreInvoke(callingForm As Object, coolStuffForm As Form, _
   division As Integer, openProjectid As String, _
   ByRef units As String, ByRef capacity As Single, ByRef runtime As String, _
   ByRef ambient As String, ByRef blname As String, ByRef roomtemp As String, _
   ByRef readme As Boolean, ByRef coolStuffId As Integer, showProjectgrid As Boolean)
      ' TODO: remove readme?
      Me.CallingForm = callingForm
      Me.CoolStuffForm = coolStuffForm
      Me.OpenProjectID = openProjectid
      Me.Id = coolStuffId
      Me.Division = division
      Me.CapacityUnits = units
      'Me.CoolStuffReadMe = readme
      Me.ShowBoxLoadGrid = showProjectgrid

      Invoke()
      If units = "Tons" Then
         Me.Capacity = Rae.Convert.BtuhToTons(Me.Capacity)
      End If

      If Me.UserCapacityChecked Then
         capacity = Me.UserSuppliedCapacity
      Else
         capacity = Me.Capacity
      End If
      blname = Me.CoolStuffForm.txtblname.text
      coolStuffId = Me.Id

      runtime = Me.CoolStuffForm.cboRunVar.Text
      ambient = Me.CoolStuffForm.TxtAmbient.Text
      roomtemp = Me.CoolStuffForm.TxtRmTemp.Text
   End Sub


   Sub Invoke()
      '
      ' sets control values
      '
      Try
         CoolStuffForm.companyid = Division
         CoolStuffForm.openprojectid = m_CoolStuffOpenProjectID
         CoolStuffForm.projecttag = m_CoolStuffCallingForm.Tag
         CoolStuffForm.lblunits.text = Me.CapacityUnits
         'CoolStuffForm.txtRecNum.Text = Id
         'CoolStuffForm.chkreadme.checked = CoolStuffReadMe
         CoolStuffForm.txtblname.text = CoolStuffBlName
      ' uh...i guess trying a different sequence?
      Catch ex As Exception
         CoolStuffForm.companyid = Division
         'CoolStuffForm.chkReadMe.Checked = CoolStuffReadMe
         CoolStuffForm.openprojectid = m_CoolStuffOpenProjectID
         CoolStuffForm.projecttag = m_CoolStuffCallingForm.Tag
         CoolStuffForm.lblunits.text = Me.CapacityUnits
         'CoolStuffForm.txtRecNum.Text = Id
         CoolStuffForm.txtblname.text = CoolStuffBlName
      End Try
      CoolStuffForm.dgblinopenproject.visible = ShowBoxLoadGrid
      CoolStuffForm.lbllinktoboxload.visible = ShowBoxLoadGrid

      CoolStuffForm.Initialize()
      CoolStuffForm.ShowDialog()


      '
      ' gets control values
      '
      Me.Capacity = CInt(CoolStuffForm.TxtLoadTot.Text)
      'Id = CoolStuffForm.BoxLoad.DbId
      Try
         Me.UserSuppliedCapacity = CInt(CoolStuffForm.TxtTotalLoadOverRide.Text)
      Catch ex As Exception
         Me.UserSuppliedCapacity = 0
      End Try
      CoolStuffBlName = CoolStuffForm.txtblname.text
      RunTime = CoolStuffForm.cboRunVar.Text
      Ambient = CoolStuffForm.TxtAmbient.Text
      CoolStuffRoomTemp = CoolStuffForm.TxtRmTemp.Text
      Me.UserCapacityChecked = CoolStuffForm.chkusercapacity.checked
   End Sub


   ''' <summary>
   ''' Builds SQL statement to duplicates box load
   ''' </summary>
   ''' <param name="projectId">Project ID</param>
   ''' <param name="revision">Item Revision</param>
   ''' <param name="itemId">Item database ID</param>
   Function GetDuplicateSql(projectId As String, itemId As Integer, revision As String) As String
      Dim sql As String

      sql = "insert into CoolStuffProjects(PROJECTID, REVISION, Ambient, ExtWB, RmTemp, RMWB, roomVolume, roomArea, Height, ExtTempW1, ExtTempW2, ExtTempW3, ExtTempW4, ExtTempW5, ExtTempW6, InsulW1, InsulW2, InsulW3, InsulW4, InsulW5, InsulW6, ThickW1, ThickW2, ThickW3, ThickW4, ThickW5, ThickW6, KFactorW1, KFactorW2, KFactorW3, KFactorW4, KFactorW5, KFactorW6, Walltot, FExtTemp, InsulF, ThickF, KFactorF, FloorTot, CExtTemp, InsulC, ThickC, KFactorC, CeilingTot, TransTot, IVolume, InfWB, InfDB, IFactor, IAirChg, IHeatRem, TotInfil, Product, Type, FreezePt, CHeat, CFHeat, FLatent, CIbs, CLoad, CPull, CEnter, CFinal, CTot, FTot, CFPTot, CFTot, RIbs, RHeat, RTot, ProdTot, WattL, TotOL, MotorHP, TotOM, People, TotOP, OtherType, OtherBTU, TotOO, OtherTot, SumTran, SumINf, SumProd, SumOther, SumTot, Safety, SafetyTot, RunVar, RunVarTot, LoadTot, btnAllWallsy, btnallwallsN, chkFreezept, chkfreezetoCore, mystate, mycity, rw1, rw2, rw3, rw4, rw5, rw6, rwfloor, rwceiling, kfactors, forklift, totforklift, dockdoors, totdockdoors, wall1, wall2, wall3, wall4, wall5, wall6, height1, height2, height3, height4, height5, height6, rdorectangle, txtimagecounter,description,usercapacity,usercapacitychecked,createdWhen,RoomNumber,blname,processid) "
      sql = sql & "select "
      If Len(projectId) > 0 Then
         sql = sql & "'" & projectId & "'"
      Else
         sql = sql & " Projectid"
      End If
      sql = sql & ", "
      If Len(revision) > 0 Then
         sql = sql & "'" & revision & "'"
      Else
         sql = sql & " revision"
      End If
      sql = sql & ", Ambient, ExtWB, RmTemp, RMWB, roomVolume, roomArea, Height, ExtTempW1, ExtTempW2, ExtTempW3, ExtTempW4, ExtTempW5, ExtTempW6, InsulW1, InsulW2, InsulW3, InsulW4, InsulW5, InsulW6, ThickW1, ThickW2, ThickW3, ThickW4, ThickW5, ThickW6, KFactorW1, KFactorW2, KFactorW3, KFactorW4, KFactorW5, KFactorW6, Walltot, FExtTemp, InsulF, ThickF, KFactorF, FloorTot, CExtTemp, InsulC, ThickC, KFactorC, CeilingTot, TransTot, IVolume, InfWB, InfDB, IFactor, IAirChg, IHeatRem, TotInfil, Product, Type, FreezePt, CHeat, CFHeat, FLatent, CIbs, CLoad, CPull, CEnter, CFinal, CTot, FTot, CFPTot, CFTot, RIbs, RHeat, RTot, ProdTot, WattL, TotOL, MotorHP, TotOM, People, TotOP, OtherType, OtherBTU, TotOO, OtherTot, SumTran, SumINf, SumProd, SumOther, SumTot, Safety, SafetyTot, RunVar, RunVarTot, LoadTot, btnAllWallsy, btnallwallsN, chkFreezept, chkfreezetoCore, mystate, mycity, rw1, rw2, rw3, rw4, rw5, rw6, rwfloor, rwceiling, kfactors, forklift, totforklift, dockdoors, totdockdoors, wall1, wall2, wall3, wall4, wall5, wall6, height1, height2, height3, height4, height5, height6, rdorectangle, txtimagecounter,description,usercapacity,usercapacitychecked,createdWhen,RoomNumber,blname,processid"
      sql = sql & " from CoolStuffProjects where id = " & itemId.ToString

      Return sql
   End Function


   Function CoolStuffClone(oldId As Integer, projectId As String, revision As Single) As Boolean
      ' QUESTION: appears to always return false
      If oldId = 0 Then Return False

      Dim sql As String
      sql = GetDuplicateSql(projectId, oldId, revision)

      CoolStuff.cl_connection.ExecuteSql(sql, "UI")
   End Function

   
   Function CoolStuffCopyProjectBoxLoad(oldProjectId As String, newProjectId As String) As Boolean
      ' QUESTION: Doesn't set return value
      Dim dt As DataTable
      dt = cl_connection.CreateGeneralTable("select * from coolstuffprojects where projectid = '" & oldProjectId & "'", "UI")

      Dim dr As DataRow, sql As String
      For Each dr In dt.Rows
         sql = GetDuplicateSql(newProjectId, dr("id"), "0")
         CoolStuff.cl_connection.ExecuteSql(sql, "UI")
      Next

      dt = Nothing
   End Function


   ''' <summary>
   ''' Populates properties with values from database
   ''' </summary>
   Sub GetOverridesFromDb()
      m_CoolStuffCallingForm.btnCoolStuffInvoke.Tag = CoolStuff.cl_connection.GetProjectRecordNumber(m_CoolStuffCallingForm.Tag, 0, "UI")
      Dim cap As Integer, rt As String, am As String, rm As String, usercap As String, ucchecked As Boolean
      Dim blname As String
      CoolStuff.cl_connection.GetOverrides(m_CoolStuffCallingForm.btnCoolStuffInvoke.Tag, cap, rt, am, rm, usercap, ucchecked, blname)
      Me.Capacity = cap
      RunTime = rt
      Ambient = am
      CoolStuffRoomTemp = rm
      CoolStuffUserCapacity = usercap
      Me.UserCapacityChecked = ucchecked
      CoolStuffBlName = blname
   End Sub


#End Region

   ''' <summary>
   ''' Used in RevisionSave class
   ''' </summary>
   Function NewCoolStuffEntry(MYrevchange As Object) As Boolean
      'true is a revsion 
      Dim oldtag As String = MYrevchange.callingform.txtcoolstuffid.text


      If MYrevchange.revchange = True Then
         If MYrevchange.SaveType = MYrevchange.save_type.save Then 'RevisionSave.Save_Type.Save
            CoolStuff.cl_connection.ExecuteSql("update CoolStuffProjects set processid = '" & m_CoolStuffCallingForm.Tag & "', revision = " & 0 & " where id = " & m_CoolStuffCallingForm.btnCoolStuffInvoke.Tag, "UI")
         ElseIf MYrevchange.SaveType = MYrevchange.Save_Type.Revision Then
            CoolStuffClone(m_CoolStuffCallingForm.btnCoolStuffInvoke.Tag, m_CoolStuffCallingForm.tag, -2)
            'find that record
            m_CoolStuffCallingForm.btnCoolStuffInvoke.Tag = CoolStuff.cl_connection.GetProjectRecordNumber(m_CoolStuffCallingForm.Tag, -2, "UI")
            ' update with new revision number
            CoolStuff.cl_connection.ExecuteSql("update CoolStuffProjects set processid = '" & m_CoolStuffCallingForm.Tag & "', revision = " & 0 & " where id = " & m_CoolStuffCallingForm.btnCoolStuffInvoke.Tag, "UI")
         End If
      Else
         'it is a SAVE  
         If MYrevchange.SaveType = 0 Then
            'is is a SAVE of the Entry, if there is already a record, don't do anything
            'If m_CallingForm.btnCoolStuffInvoke.tag = 0 Or m_CallingForm.btnCoolStuffInvoke.tag Is Nothing Then
            CoolStuff.cl_connection.ExecuteSql("update CoolStuffProjects set processid = '" & MYrevchange.callingform.Tag & "', revision = " & 0 & " where id = " & MYrevchange.callingform.btnCoolStuffInvoke.Tag, "UI")


         ElseIf MYrevchange.SaveType = 1 Then
            'is is a  Revision
            '9/18/07 this is saving a revision, boxload doesn't change

            'Dim sql As String
            ''This copies the old project data into a new record, creating a new id, and revision is -2 so we can find the new id
            'sql = CoolStuffInsertSql("", "-2") & MYrevchange.callingform.btnCoolStuffInvoke.Tag
            'CoolStuff.cl_connection.ExecuteSql(sql, "UI")
            ''find that record
            'MYrevchange.callingform.btnCoolStuffInvoke.Tag = CoolStuff.cl_connection.GetProjectRecordNumber(MYrevchange.callingform.Tag, -2, "UI")
            '' update with new revision number
            'CoolStuff.cl_connection.ExecuteSql("update CoolStuffProjects set processid = '" & MYrevchange.callingform.Tag & "', revision = " & 0 & " where id = " & MYrevchange.callingform.btnCoolStuffInvoke.Tag, "UI")

            ''CoolStuff.cl_connection.ExecuteSql("Update CoolStuffProjects set projectid = '" & MYrevchange.callingform.tag & "' where projectid = 'clone" & oldtag & "'", "UI")
            ''CoolStuff.cl_connection.ExecuteSql("delete from CoolStuffProjects where id = " & oldtag, "UI")

         End If
      End If

   End Function
End Class

End Namespace

'Function CoolStuffDeleteBoxLoad(projectId As String) As Boolean
'   cl_connection.ExecuteSql("delete from CoolStuffProjects where projectid = '" & projectId & "'", "UI")
'End Function

''find that record
'            m_CoolStuffCallingForm.btnCoolStuffInvoke.Tag = CoolStuff.cl_connection.GetProjectRecordNumber(m_CoolStuffCallingForm.Tag, -2, "UI")
'' update with new revision number
'            CoolStuff.cl_connection.ExecuteSql("update CoolStuffProjects set processid = '" & m_CoolStuffCallingForm.Tag & "', revision = " & 0 & " where id = " & m_CoolStuffCallingForm.btnCoolStuffInvoke.Tag, "UI")
