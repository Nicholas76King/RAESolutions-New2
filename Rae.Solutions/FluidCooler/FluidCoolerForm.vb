'Imports RAE_SelectionRating
Imports RAECoilWeightDLL
Imports System.Data
Imports System.Collections.Generic
Imports Rae.Io.Text
Imports Rae.RaeSolutions.Business.Entities
imports rae.solutions
Imports Rae.RaeSolutions.DataAccess
Imports CREngine = CrystalDecisions.CrystalReports.Engine
Imports CRShared = CrystalDecisions.Shared

Public Class FluidCoolerForm

   Public ProcessDeleted As Boolean
   Private WithEvents RAESelRatingCore As RAE_SelectionRating.RAESelectionRating

    Private WithEvents RAECoilWeightDLL As Cls_RAECoilWeightDLL
   'this is added to test e-mailing of ckecked in files
   Private strError As String = String.Empty
   Private defaultError As String = String.Empty
   Private bNeedsReCalc As Boolean = True
    Public fc As FluidCooler
   Public fcCoil As New FluidCoolerCoil
    Private _fpi As Double = 0
    Private dtb As DataTable
    Private IsLoaded As Boolean = False
    Private coils As List(Of Coil)
    Private circuits As List(Of FluidCoolerCircuiting)
   ' Private COut As Rae.RaeSolutions.Business.Intelligence.CofanOutput
   'Private COFAN As Rae.RaeSolutions.Business.Intelligence.Cofan
   Private Condenser As Rae.RaeSolutions.Business.Entities.Condenser
   Private CondenserOutput As Rae.RaeSolutions.Business.Entities.Condenser.Outputs
   Private RaeSelRating As RAE_SelectionRating.RAESelectionRating

   Private ResultsTable As DataTable

   Private hshDiameters As Hashtable

    Private Property Refrigerant() As Rae.Engineering.Refrigerant
        Get
            Return New Rae.Engineering.Refrigerant(System.Enum.Parse(Rae.Engineering.RefrigerantType.R134a.GetType(), CBO_Refg.SelectedIndex))
        End Get
        Set(ByVal value As Rae.Engineering.Refrigerant)
            CBO_Refg.SelectedIndex = CInt(value.Type)
        End Set
    End Property

    Dim CIRCUIT_TYPE As String
    Dim CHAR_Renamed As Object
    Dim TEMP_HOLDING As Object
    Dim DATE_PP1, msg, DATE_PP2 As Object
    Dim MyCheck As Object
    Dim STYLE, RESPONSE As String
    Dim TITLE, defval As Object
    Dim print_msg As String
    Dim HOLDING_COILSIZE As Single
    Dim FPM_TEMP As Double

    Private Declare Function WinHelp Lib "user32" Alias "WinHelpA" (ByVal hwnd As Integer, ByVal lpHelpFile As String, ByVal wCommand As Integer, ByVal dwData As Integer) As Integer

    Private Const HELP_CONTENTS As Short = 3
    Private Const HELP_FINDER As Short = 11

    'Mod_Global_Var
    Public coiltype_overide As Single
    Public REF_OVERIDE As Single
    Public my_ip_test As String
    Public RAE_Out_Surf_Area As Double
    Public RAE_Out_Opp_End_Conn As String
    Public RAE_Out_LDB1 As Double
    Public RAE_Out_LDB2 As Double
    Public RAE_Out_LDB3 As Double
    Public RAE_Out_LWB1 As Double
    Public RAE_Out_LWB2 As Double
    Public RAE_Out_LWB3 As Double
    Public RAE_Out_Total_HT1 As Double
    Public RAE_Out_Total_HT2 As Double
    Public RAE_Out_Total_HT3 As Double
    Public RAE_Out_Sens_HT1 As Double
    Public RAE_Out_Sens_HT2 As Double
    Public RAE_Out_Sens_HT3 As Double
    Public RAE_Out_LWT1 As Double
    Public RAE_Out_LWT2 As Double
    Public RAE_Out_LWT3 As Double
    Public RAE_Out_GPM1 As Double
    Public RAE_Out_GPM2 As Double
    Public RAE_Out_GPM3 As Double
    Public RAE_Out_Water_Vel1 As Double
    Public RAE_Out_Water_Vel2 As Double
    Public RAE_Out_Water_Vel3 As Double
    Public RAE_Out_ERROR_MSG1 As Single
    Public RAE_Out_ERROR_MSG2 As Single
    Public RAE_Out_ERROR_MSG3 As Single
    Public RAE_Out_Fluid_PD1 As Double
    Public RAE_Out_Fluid_PD2 As Double
    Public RAE_Out_Fluid_PD3 As Double
    Public RAE_Out_No_of_Circuits1 As Double
    Public RAE_Out_No_of_Circuits2 As Double
    Public RAE_Out_No_of_Circuits3 As Double
    Public RAE_Out_Air_Press_Drop1 As Double
    Public RAE_Out_Air_Press_Drop2 As Double
    Public RAE_Out_Air_Press_Drop3 As Double
    Public RAE_Out_Connections1 As Double
    Public RAE_Out_Connections2 As Double
    Public RAE_Out_Connections3 As Double
    Public RAE_Out_FPI1 As Double
    Public RAE_Out_FPI2 As Double
    Public RAE_Out_FPI3 As Double
    Public RAE_Out_ROWS1 As Double
    Public RAE_Out_ROWS2 As Double
    Public RAE_Out_ROWS3 As Double
    Public RAE_Out_CIRCUITING1 As String
    Public RAE_Out_CIRCUITING2 As String
    Public RAE_Out_CIRCUITING3 As String
    Public RAE_Out_SELECTION1 As String
    Public RAE_Out_SELECTION2 As String
    Public RAE_Out_SELECTION3 As String
    Public RAE_Out_ARI_MSG1 As String
    Public RAE_Out_ARI_MSG2 As String
    Public RAE_Out_ARI_MSG3 As String
    Public RAE_Out_Steam_Temp As Double
    Public RAE_Steam_Pressure As Double
    Public RAE_Suction As Double
    Public RAE_liquid As Double
    Public RAE_Out_DLL_loop_Error As Double
    Public RAE_Out_Refg_pres_drop1 As Double
    Public RAE_Out_Refg_pres_drop2 As Double
    Public RAE_Out_Refg_pres_drop3 As Double
    Public RAE_Out_Circuit_load1 As Double
    Public RAE_Out_Circuit_load2 As Double
    Public RAE_Out_Circuit_load3 As Double
    Public RAE_Out_Connections_Steam1 As String
    Public RAE_Out_Connections_Steam2 As String
    Public RAE_Out_Connections_Steam3 As String
    Public RAE_Out_Input_error1 As Single
    Public RAE_Out_Input_error2 As Single
    Public RAE_Out_Input_error3 As Single
    Public RAE_Out_Input_error4 As Single
    Public RAE_Out_Input_error5 As Single
    Public RAE_Out_Input_error6 As Single
    Public RAE_Out_Input_error7 As Single
    Public RAE_Out_Input_error8 As Single
    Public RAE_Out_Input_error9 As Single
    Public RAE_Choice As String
    Public RAE_Out_Input_error_text(300) As String
    Public RAE_EDB As Double


    '********add var for weightdll***********
    Public STANDARD_CD As Double
    Public COIL_WEIGHT1 As Double
    Public COIL_WEIGHT2 As Double
    Public COIL_WEIGHT3 As Double
    Public WEIGHT_PASS As Single

    '********add var for Steam couls 4/7/2006 DGroom**********
    Public RAE_Out_Pounds_Condensate1 As Double
    Public RAE_Out_Pounds_Condensate2 As Double
    Public RAE_Out_Pounds_Condensate3 As Double
    Public RAE_Out_Condensate_Loading1 As Double
    Public RAE_Out_Condensate_Loading2 As Double
    Public RAE_Out_Condensate_Loading3 As Double

    '*************King Addes 4/25/2006****************
    Public C_GAS As String 'Description of Gas
    Public C_FLUID As String 'Description of Fluid
    '**Gas Varibles************************************
    Public a_UVA As Single 'Viscisity=UVA(Single)-Lbm/Ft Sec
    Public a_CPA As Single 'Sp. Heat of Gas=CPA(Single)-BTU/Lb Deg F
    Public a_DPA As Single 'Density- DPA(Single)- Lbs/C. Ft.
    Public a_KTA As Single 'Thermal Conductivity=TKA(Single)-BTU/Hr-Ft^2F per Ft.
    '**Fluid Varibles************************************
    Public a_UVG As Single 'Viscisity in (Centipoise)
    Public a_CPG As Single 'Sp. Heat of Liq in (BTU/Lb Deg F)
    Public a_DPG As Single 'Density- DPG(Single)- Lbs/C. Ft.
    Public a_TKG As Single 'Thermal Conductivity=TKG(Single)-BTU/Hr-Ft^2F per Ft.
    '****************************************************
   Public Check_screen_input_error As Boolean

   ' Last saved state...
   Public LastSavedProcess As Rae.RaeSolutions.Business.Entities.FluidCoolerProcessItem
   ' Current state before save...
   Public CurrentStateProcess As Rae.RaeSolutions.Business.Entities.FluidCoolerProcessItem
   Private m_CurrentRevision As Single = -1
   ''' <summary>
   ''' The current revision # of process being displayed on this form.
   ''' </summary>
   Public Property CurrentRevision() As Single
      Get
         Return Me.m_Currentrevision
      End Get
      Set(ByVal value As Single)
         Me.m_Currentrevision = value
      End Set
   End Property
   ' Latest revision # of the current 
   ' process ID (if any)...
   Private m_Latestrevision As Single = -1
   ''' <summary>
   ''' The latest revision # of process being displayed on this form.
   ''' </summary>
   Public Property LatestRevision() As Single
      Get
         Return Me.m_Latestrevision
      End Get
      Set(ByVal value As Single)
         Me.m_Latestrevision = value
      End Set
   End Property

    Public Sub SET_STANDARD_CD_FOR_COIL_WEIGHT()
        Dim cd12(12) As Double
        Dim cd58(12) As Double
        cd12(1) = 4
        cd12(2) = 4
        cd12(3) = 5.5
        cd12(4) = 7
        cd12(5) = 8
        cd12(6) = 9
        cd12(7) = 11
        cd12(8) = 11
        cd12(9) = 13
        cd12(10) = 13
        cd12(11) = 15
        cd12(12) = 15

        cd58(1) = 5
        cd58(2) = 5
        cd58(3) = 6
        cd58(4) = 7.5
        cd58(5) = 9
        cd58(6) = 10
        cd58(7) = 12.5
        cd58(8) = 12.5
        cd58(9) = 15.5
        cd58(10) = 15.5
        cd58(11) = 17.5
        cd58(12) = 18

        If Val(Cbo_rows.Text) > 12 Then
            STANDARD_CD = 3.75 + (Val(Cbo_rows.Text) * 1.299)
        Else
            STANDARD_CD = cd58(Val(Cbo_rows.Text))
        End If
        Dim TEMP_DOUBLE1 As Double
        TEMP_DOUBLE1 = STANDARD_CD
        STANDARD_CD = Round(TEMP_DOUBLE1, 4)
END_STANDARD_CD:
   End Sub

   Public Function SaveControls(Optional ByVal SaveAsRevision As Boolean = False, Optional ByVal SaveAsNew As Boolean = False, Optional ByVal FormClosing As Boolean = False, Optional ByVal GenerateEquipment As Boolean = False, Optional ByVal RevChanged As Boolean = False) As Boolean
      CalculatePage()

      If CurrentStateProcess Is Nothing Then
         If LastSavedProcess Is Nothing Then
            CurrentStateProcess = New FluidCoolerProcessItem(New item_id(AppInfo.User.username, AppInfo.User.password))
         Else
            CurrentStateProcess = LastSavedProcess.Clone
         End If
      Else
         If LastSavedProcess IsNot Nothing Then CurrentStateProcess = LastSavedProcess.Clone
      End If

      ''If CurrentStateProcess Is Nothing Then
      ''   Dim procname As String
      ''   Dim projmgr As ProjectManager
      ''   If LastSavedProcess Is Nothing Then
      ''      Dim niForm As New NewItemForm2
      ''      If OpenedProject.IsOpened Then
      ''         projmgr = OpenedProject.Manager
      ''         niForm.NewItem(NewItemForm2.NewItemType.SelectionOnly, Business.ProcessType.FluidCooler)
      ''         'niForm.NewItem(NewItemForm2, Business.ProcessType.FluidCooler)
      ''         niForm.ShowDialog()
      ''         If niForm.IsValid Then
      ''            procname = niForm.SelectionName
      ''         End If
      ''      Else
      ''         niForm.NewItem(NewItemForm2.NewItemType.SelectionAndProject, Business.ProcessType.FluidCooler)
      ''         niForm.ShowDialog()
      ''         If niForm.IsValid Then
      ''            projmgr = New ProjectManager(niForm.ProjectName, AppInfo.User.Username, AppInfo.User.Password)
      ''            projmgr.Project.Save()
      ''            procname = niForm.SelectionName
      ''            OpenedProject.Manager = projmgr
      ''         End If
      ''      End If
      ''      CurrentStateProcess = New FluidCoolerProcessItem() 'New ItemId(AppInfo.User.Username, AppInfo.User.Password))
      ''      CurrentStateProcess.MetaData = New MetaData(procname, AppInfo.User.Username, String.Empty)
      ''      CurrentStateProcess.ID = New ItemId(ProjectInfo.NewItemID(projmgr.Project.Id.Id))
      ''      CurrentStateProcess.ProjectManager = projmgr
      ''      'CurrentStateProcess.MetaData = New MetaData
      ''      CurrentStateProcess.Name = procname
      ''      projmgr.Processes.Add(CurrentStateProcess)
      ''   Else
      ''      CurrentStateProcess = LastSavedProcess.Clone
      ''   End If
      ''Else
      ''   If LastSavedProcess IsNot Nothing Then CurrentStateProcess = LastSavedProcess.Clone
      ''End If

      'Dim fcpi As FluidCoolerProcessItem = FluidCoolerProcessItem.PopulateLatest(CurrentStateProcess.ID.Id)

      With CurrentStateProcess
         .Altitude = Val(Me.TXT_ALDT.Text)
         .AmbientTemp = Val(Me.TXT_EDB.Text)
         .Capacity = CondenserOutput.Capacity
         .EnteringFluidTemp = Val(Me.TXT_EWT.Text)
         .LeavingFluidTemp = RaeSelRating.RAE_Out_LWT1
         .Flow = RaeSelRating.RAE_GPM
         .Fluid = RaeSelRating.RAE_FluidType
         .GlycolPercent = Val(Me.TXT_PERCONC.Text)
         .FluidCooler = fc
      End With
      
      ' Set save process...
      Dim RevSave As New RevisionSave
      CurrentStateProcess = RevSave.SetSaveProcess(Me, Business.ProcessType.FluidCooler, CurrentStateProcess, LastSavedProcess, SaveAsNew, SaveAsRevision, FormClosing, GenerateEquipment, RevChanged)
      If RevSave.CancelSave = True Then
         If CurrentStateProcess Is Nothing Then
            ' canceled
            RevSave = Nothing
            Return False
         Else
            ' do not save and continue to close
            RevSave = Nothing
            Return True
         End If
      End If

      ' Set last saved process...
      LastSavedProcess = RevSave.RevisionSaved(CurrentStateProcess)
      If RevSave.CancelSave = False Then
         ' only save if user chooses...
         CurrentStateProcess = LastSavedProcess.Clone
         RevSave = Nothing
         Return True
      Else
         ' User cancelled form close...
         RevSave = Nothing
         Return False
      End If


      ''With CurrentStateProcess
      ''   .Altitude = Val(Me.TXT_ALDT.Text)
      ''   .AmbientTemp = Val(Me.TXT_EDB.Text)
      ''   .Capacity = CondenserOutput.Capacity
      ''   .EnteringFluidTemp = Val(Me.TXT_EWT.Text)
      ''   .LeavingFluidTemp = RaeSelRating.RAE_Out_LWT1
      ''   .Flow = RaeSelRating.RAE_GPM
      ''   .Fluid = RaeSelRating.RAE_FluidType
      ''   .GlycolPercent = Val(Me.TXT_PERCONC.Text)
      ''   .FluidCooler = fc

      ''   If OpenedProject.IsOpened Then
      ''      If SaveAsRevision And .Revision >= Rae.RaeSolutions.DataAccess.Projects.ProjectsDataAccess.RetrieveLatestRevision(OpenedProject.Manager.Project.Id.Id) Then
      ''         .Revision = Me.LatestRevision + CSng(0.001)
      ''      ElseIf SaveAsRevision Then
      ''         .Revision = Rae.RaeSolutions.DataAccess.Projects.ProjectsDataAccess.RetrieveLatestRevision(OpenedProject.Manager.Project.Id.Id) + CSng(0.001)
      ''      Else
      ''         If .Revision < Me.LatestRevision Then
      ''            .Revision = Me.LatestRevision + CSng(0.001)
      ''         End If
      ''      End If
      ''   Else
      ''      .Revision = CSng(0.001)
      ''   End If

      ''   .Save()
      ''End With

      '' Set save process...
      'Dim RevSave As New RevisionSave
      'CurrentStateProcess = RevSave.SetSaveProcess(Me, Business.ProcessType.FluidCooler, CurrentStateProcess, LastSavedProcess, False, SaveAsRevision, FormClosing, GenerateEquipment, RevChanged)
      'If CurrentStateProcess Is Nothing Or RevSave.CancelSave = True Then
      '   RevSave = Nothing
      '   Return True
      'End If

      '' Set last saved process...
      'LastSavedProcess = RevSave.RevisionSaved(CurrentStateProcess)
      'If RevSave.CancelSave = False Then
      '   ' only save if user chooses...
      '   CurrentStateProcess = LastSavedProcess.Clone
      '   RevSave = Nothing
      '   Return True
      'Else
      '   ' User cancelled form close...
      '   RevSave = Nothing
      '   Return False
      'End If

      ''Dim xml As String = Utility.Serialize(fc)
      ''Dim flclr As FluidCooler = Utility.Deserialize(xml, fc.GetType())
      'Dim procname As String
      'Dim projmgr As ProjectManager
      'Dim niForm As New NewItemForm
      'If OpenedProject.IsOpened Then
      '   projmgr = OpenedProject.Manager
      '   niForm.NewItem(NewItemForm.NewItemType.ProcessAndProject, Business.ProcessType.FluidCooler)
      '   niForm.ShowDialog()
      '   If niForm.IsValid Then
      '      procname = niForm.ProcessName
      '   End If
      'Else
      '   niForm.NewItem(NewItemForm.NewItemType.ProcessAndProject, Business.ProcessType.FluidCooler)
      '   niForm.ShowDialog()
      '   If niForm.IsValid Then
      '      projmgr = New ProjectManager(niForm.txtProjectName.Text, AppInfo.User.Username, AppInfo.User.Password)
      '      projmgr.Project.Save()
      '      procname = niForm.ProcessName
      '   End If
      'End If


      'If CurrentStateProcess Is Nothing Then
      '   If LastSavedProcess Is Nothing Then
      '      CurrentStateProcess = New FluidCoolerEquipmentItem(procname, Business.Division.TSI, New ItemId(AppInfo.User.Username, AppInfo.User.Password), projmgr)
      '   Else
      '      CurrentStateProcess = LastSavedProcess.Clone
      '   End If
      'Else
      '   If LastSavedProcess IsNot Nothing Then CurrentStateProcess = LastSavedProcess.Clone
      'End If

      'With CurrentStateProcess
      '   If SaveAsRevision Then
      '      .Revision = .LatestRevision + 1
      '   ElseIf SaveAsNew Then
      '      .Revision = 0
      '   End If
      '   .Equipment = New Equipment(Business.Division.TSI, Business.EquipmentType.FluidCooler, fc.FluidCoolerSeries.ModelSeries, fc.ModelNumber.ToString())
      '   .Equipment.RatingEquipment = fc
      '   Dim cs As New CommonSpecifications
      '   Dim alt As New Rae.NullableValue(Of Double)
      '   alt.SetValue(Val(Me.TXT_ALDT.Text))
      '   cs.Altitude = alt
      '   Dim ow As New Rae.NullableValue(Of Double)
      '   ow.SetValue(fc.Operating_Weight)
      '   cs.OperatingWeight = ow
      '   Dim sw As New Rae.NullableValue(Of Double)
      '   sw.SetValue(fc.Shipping_Weight)
      '   cs.ShippingWeight = sw
      '   .CommonSpecs = cs
      '   If Not RaeSelRating Is Nothing Then
      '      Dim spec As New FluidCoolerSpecifications
      '      spec.AmbientTemp.SetValue(Val(Me.TXT_EDB.Text))
      '      spec.Capacity.SetValue(CondenserOutput.Capacity)
      '      spec.EnteringFluidTemp = New Rae.NullableValue(Of Double)
      '      spec.EnteringFluidTemp.SetValue(Val(Me.TXT_EWT.Text))
      '      spec.Flow.SetValue(RaeSelRating.RAE_GPM)
      '      spec.Fluid = RaeSelRating.RAE_FluidType
      '      'spec.GlycolPercent.SetValue(val(me.txt_gl
      '      .Specs = spec
      '   End If
      '   .Save()
      'End With
   End Function


   Public Sub CALL_COIL_WEIGHT_DLL()
      SET_STANDARD_CD_FOR_COIL_WEIGHT()

      RAECoilWeightDLL = New Cls_RAECoilWeightDLL 'Setting the link with DLL

      With RAECoilWeightDLL 'Starting the link with DLL
         .RAE_COILTYPE = fcCoil.CoilUseType
         .RAE_FIN_TYPE = CBO_FINMATL.Text 'Valid fin materials AL OR CU
         .RAE_FIN_THICKNESS = Val(CBO_FINTHICKNESS.Text) 'Valid fin thickness .006, .008, .010
         .RAE_TUBE_DIA = fcCoil.Diameter ' 0.625
         .RAE_TUBE_WALL = Val(CBO_TUBETHICKNESS.Text)
         .RAE_CONN_SIZE = RAE_Out_Connections1 'CONNECTION_SIZE
         .RAE_SM_MATL = "GALV" 'ASSUME
         .RAE_SM_GAGE_SP = 16 'ASSUME
         .RAE_SM_GAGE_TS = 16 'ASSUME
         .RAE_FH = fcCoil.FinHeight 'Val(Cbo_fh.Text)
         .RAE_FL = fcCoil.FinLength 'Val(lbl_fl.Text) 'fin length > 0
         .RAE_CD = STANDARD_CD ' Calculated by SET_STANDARD_CD_FOR_COIL_WEIGHT

         If WEIGHT_PASS = 1 Then
            .RAE_RD = fcCoil.NumRows 'RAE_Out_ROWS1 'Val(Cbo_rows)     'Rows deep > 0
            .RAE_FPI = fcCoil.FPI 'RAE_Out_FPI1 'Val(Cbo_fpi)     'Fin per inch range 4 thur 14, check constrution rules for different fin materials.
         End If

         .RAE_WC_SER_MOD = fcCoil.Circuiting.FluidCoolerCircuitingValue 'Val(TXT_SERP.Text) 'Circuit fraction see below
         .RAE_CIRCUITING = fcCoil.Circuiting.FluidCoolerCircuitingType 'CIRCUIT_TYPE 'circuiting letter see above

         .AddToDatabase() 'This sets the DLL in action doing calculations

         If WEIGHT_PASS = 1 Then
            If RAE_Out_Connections1 = 0 Then 'CONNECTION_SIZE = 0   ??????
               COIL_WEIGHT1 = 0
               COIL_WEIGHT_LABEL.Text = "Est. Coil Weight ~ lbs."
            Else
               COIL_WEIGHT1 = Round(.RAE_Out_COIL_WEIGHT, 0)
               COIL_WEIGHT_LABEL.Text = "Est. Coil Weight ~ " & COIL_WEIGHT1 & " lbs."
            End If
         End If

      End With 'End DLL Variable passing

      RAECoilWeightDLL = Nothing 'Clearing DLL Variables
   End Sub

   Private Sub CBO_FEED_LOCATION_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CBO_FEED_LOCATION.TextChanged
      'SET_MODEL_NUMBER()
   End Sub

   Private Sub CBO_FIN_TYPE_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CBO_FIN_TYPE.SelectedIndexChanged
      CoilChanged()
      'SET_MODEL_NUMBER()
   End Sub

   Private Sub CBO_FINMATL_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CBO_FINMATL.SelectedIndexChanged
      'If IsLoaded Then
      Dim drv As DataRowView = Me.CBO_FINMATL.SelectedItem
      fcCoil.FinMaterial = System.Enum.Parse(Coil.FinMaterials.AL.GetType(), drv("Key").ToString())
      'End If
      CoilChanged()
   End Sub

   Private Sub CBO_FINTHICKNESS_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CBO_FINTHICKNESS.SelectedIndexChanged
      'CLEAR_COIL_WEIGHT_LABEL()
      'If IsLoaded Then
      Dim drv As DataRowView = Me.CBO_FINTHICKNESS.SelectedItem
      fcCoil.FinThickness = CDbl(drv("Value"))
      'End If
      CoilChanged()
   End Sub

   Private Sub CBO_FLUIDTYPE_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CBO_FLUIDTYPE.SelectedIndexChanged
      SET_CBO_FLUIDTYPE2()
      CoilChanged()
   End Sub

   Private Sub Cbo_fpi_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cbo_fpi.SelectedIndexChanged
      fcCoil.FPI = Val(Cbo_fpi.Text)
      CoilChanged()
   End Sub

   Private Sub Cbo_GAS_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cbo_GAS.SelectedIndexChanged
      SET_CBO_GAS2()
   End Sub

   Private Sub CBO_HAND_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CBO_HAND.SelectedIndexChanged
      CoilChanged()
   End Sub

   Private Sub Cbo_rows_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cbo_rows.SelectedIndexChanged
      fcCoil.NumRows = Val(Cbo_rows.Text)
      CoilChanged()
   End Sub

   Private Sub CBO_SERP_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CBO_SERP.SelectedIndexChanged
      fcCoil.Circuiting = CBO_SERP.SelectedItem
      CoilChanged()
   End Sub

   Private Sub CBO_TUBEMATL_KING_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CBO_TUBEMATL_KING.SelectedIndexChanged
      'If IsLoaded Then
      Dim drv As DataRowView = Me.CBO_TUBEMATL_KING.SelectedItem
      fcCoil.TubeMaterial = System.Enum.Parse(Coil.TubeMaterials.AL.GetType(), drv("Key").ToString())
      'End If
      CoilChanged()
   End Sub

   Private Sub CBO_TUBETHICKNESS_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CBO_TUBETHICKNESS.SelectedIndexChanged
      'If IsLoaded Then
      Dim drv As DataRowView = Me.CBO_TUBETHICKNESS.SelectedItem
      fcCoil.TubeThickness = CDbl(drv("Value"))
      'End If
      CoilChanged()
   End Sub

   Public Sub SET_FPM()
      If TXT_CFM.Text <= "    " Then
      Else
         SSPanel1.Text = "FPM  =    " & Round(Val(TXT_CFM.Text) / (fcCoil.FinLength * fcCoil.FinHeight / 144), 3)
      End If
   End Sub

   Public Sub SET_TOOL_TIP_TEXT()
      If CBO_FLUIDTYPE.Text = "WTR" Then
         ToolTip1.SetToolTip(TXT_CFM, "CFM - AIR FLOW RATE PER COIL (Cu. Ft./Min), ARI GUIDELINES = 200 to 1500 FPM") 'Updated 12/8/1999 D.Groom added FPM
         ToolTip1.SetToolTip(TXT_EDB, "EDB - ENTERING  AIR DRY BULB (F), ARI GUIDELINES = 0 to 100")
         ToolTip1.SetToolTip(TXT_EWB, "EWB - ENTERING  AIR WET BULB (F)")
         ToolTip1.SetToolTip(TXT_EWT, "EWT - ENTERING FLUID TEMPERATURE (F), ARI GUIDELINES = 120 TO 250 DEG. F")
         ToolTip1.SetToolTip(TXT_SUCTION_TEMP, "")
      End If
      If CBO_FLUIDTYPE.Text = "EG" Or CBO_FLUIDTYPE.Text = "PG" Then
         ToolTip1.SetToolTip(TXT_CFM, "CFM - AIR FLOW RATE PER COIL (Cu. Ft./Min), ARI GUIDELINES = 200 to 1500 FPM") 'Updated 12/8/1999 D.Groom added FPM
         ToolTip1.SetToolTip(TXT_EDB, "EDB - ENTERING  AIR DRY BULB (F), ARI GUIDELINES = -20 to 100")
         ToolTip1.SetToolTip(TXT_EWB, "EWB - ENTERING  AIR WET BULB (F)")
         ToolTip1.SetToolTip(TXT_EWT, "EWT - ENTERING FLUID TEMPERATURE (F), ARI GUIDELINES = 0 TO 200 DEG. F")
         ToolTip1.SetToolTip(TXT_SUCTION_TEMP, "")
      End If
   End Sub

   Function Round(ByRef nValue As Double, ByRef nDigits As Short) As Double
      Round = Int(nValue * (10 ^ nDigits) + 0.5) / (10 ^ nDigits)
   End Function

   Private Function getFans(ByVal fanGroup As String) As List(Of Fan)
      Dim fansData As List(Of condensers.condenser_repository.FanTransferData)
      If AppInfo.User.authority_group = user_group.employee Then
         fansData = condensers.condenser_repository.RetrieveCondenserEmployeeFans()
      ElseIf AppInfo.User.authority_group > 2 Then
         fansData = condensers.condenser_repository.RetrieveCondenserRepFans(fanGroup)
      End If

      Dim fan As Fan : Dim fans As New System.Collections.Generic.List(Of Rae.RaeSolutions.Business.Entities.Fan)()
      For Each fanData As condensers.condenser_repository.FanTransferData In fansData
            fan = New Fan(fanData.FileName, fanData.Horsepower, fanData.Diameter, fanData.Rpm, fanData.IsHighAltitude, fanData.Hertz, fanData.IsVariableSpeed)
         fans.Add(fan)
      Next
      Return fans
   End Function

   Private Function getCoils() As List(Of Coil)
      Dim coilsData = condensers.condenser_repository.RetrieveEmployeeCoils()
      Dim coil As Coil
      Dim coils As New List(Of Coil)()
      For Each coilData As condensers.condenser_repository.CoilTransferData In coilsData
         If coilData.Diameter = 0.625 Then
            Dim application As Coil.CoilType : GetEnumValue(Of Coil.CoilType)(coilData.CoilType, application)
            Dim finDesign As Coil.FinType : GetEnumValue(Of Coil.FinType)(coilData.FinType, finDesign)
                coil = New Coil(coilData.Diameter, coilData.NumRows, coilData.FileName, application, finDesign, "Smooth")
            coils.Add(coil)
         End If
      Next
      Return coils
   End Function

   Private Sub Authorize()
      If AppInfo.User.authority_group = user_group.rep Then
         Me.Cbo_fpi.Enabled = False
         Me.Cbo_rows.Enabled = False
         Me.CBO_FIN_TYPE.Enabled = False
         Me.CBO_HAND.Enabled = False
         Me.cboDiameter.Enabled = False
         Me.cboHeight.Enabled = False
         Me.cboLength.Enabled = False
         Me.cboFanDescription.Enabled = False
         Me.CBO_CFMT.SelectedIndex = 1
         Me.CBO_CFMT.Enabled = False
         CBO_CFMT.Text = "S"
         'Me.cboTempInterval.Enabled = False
         Me.lblDimensions.ReadOnly = True
         'Me.chkCustomModel.Visible = False
         'Me.txtCustomModel.Visible = False
         chkOverride.Enabled = False
      End If
   End Sub

   Private Sub FluidCoolerForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
      initializeSaveToolStripPanel()
      Me.SaveToolStripPanel1.Merge()
   End Sub

   Private Sub initializeSaveToolStripPanel()
      Me.SaveToolStripPanel1.SetUp(CType(Me.ParentForm, MainForm).mainToolStrip, _
         AddressOf SaveMenuItem_Click, AddressOf SaveAsRevisionMenuItem_Click)
   End Sub

   Private Sub SaveMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
Handles saveAsMenuItem.Click
      If CurrentStateProcess Is Nothing AndAlso LastSavedProcess Is Nothing Then
         SaveControls(False, True)
      Else
         SaveControls()
      End If

   End Sub

   Private Sub SaveAsRevisionMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
Handles saveAsRevisionMenuItem.Click
      SaveControls(True)
   End Sub

   Private Sub RevisionView_RevisionChanged(ByVal sender As RevisionView, ByVal e As ValueChangedEventArgs(Of Single))
      If sender.ActiveProcessForm Is Me Then
         SaveControls(False, False, False, False, True)
      End If
   End Sub

   Public Sub Open(ByVal Process_Item As ProcessItem)
      Me.LoadControls(Process_Item)
   End Sub

   Public Sub LoadControls(ByVal fcpi As FluidCoolerProcessItem)

      ' If latest revision has not been set then
      ' we need to set it now  based on the ID...
      If Me.m_Latestrevision = -1 Then
         Me.m_Latestrevision = Rae.RaeSolutions.DataAccess.Projects.ProcessItemDA.LastestRevision(Me.Tag)
      End If

      ' Increment the current process revision
      ' displayed on this form...
      Me.m_CurrentRevision = fcpi.Revision

      Me.LastSavedProcess = fcpi.Clone
      Me.CurrentStateProcess = Me.LastSavedProcess

      SetCombobox(Me.cboSeries, fcpi.FluidCooler.FluidCoolerSeries.ModelSeries, "ModelSeries")
      SetCombobox(Me.cboModels, fcpi.FluidCooler.ModelNumber, "ModelNumber")
      Me.fc = fcpi.FluidCooler
      Me.TXT_ALDT.Text = fcpi.Altitude
      Me.TXT_EDB.Text = fcpi.AmbientTemp
      Me.TXT_PERCONC.Text = fcpi.GlycolPercent
      Me.TXT_EWT.Text = fcpi.EnteringFluidTemp
      ReCalc()
   End Sub

   Private Sub FluidCoolerForm_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
      Me.SaveToolStripPanel1.Unmerge()
   End Sub

   Private Sub FluidCoolerForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
      'If CurrentStateProcess Is Nothing Or LastSavedProcess Is Nothing Or (CurrentStateProcess IsNot Nothing AndAlso LastSavedProcess IsNot Nothing AndAlso Not CurrentStateProcess.Equals(LastSavedProcess)) Then
      '   Dim saveForm As New SaveOnCloseForm
      '   ' gets user's save selection
      '   saveForm.ShowDialog()

      '   Select Case saveForm.SaveSelection
      '      Case SaveOnCloseForm.UserSelection.Save
      '         Me.SaveControls(False, True)
      '      Case SaveOnCloseForm.UserSelection.SaveAsRevision
      '         Me.SaveControls(True)
      '      Case SaveOnCloseForm.UserSelection.DoNotSave
      '         ' closes without saving
      '      Case SaveOnCloseForm.UserSelection.Cancel
      '         ' cancels close and exits method
      '         e.Cancel = True : Exit Sub
      '      Case Else
      '         Throw New ApplicationException("Invalid save option.")
      '   End Select
      '   RemoveHandler CType(My.Application.ApplicationContext.MainForm, MainForm).RevisionView1.RevisionChanged, AddressOf RevisionView_RevisionChanged
      '   saveForm.Close()
      'End If
      'Me.SaveToolStripPanel1.Unmerge()

      If Not Me.ProcessDeleted Then
         If SaveControls(False, False, True) = False Then
            e.Cancel = True
         Else
            RemoveHandler CType(My.Application.ApplicationContext.MainForm, MainForm).RevisionView1.RevisionChanged, AddressOf RevisionView_RevisionChanged
         End If
      End If
   End Sub

   Private Sub frm_RAESelRatingCore_input_screen_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
      'initializeSaveToolStripPanel()
      'Me.SaveToolStripPanel1.Merge()
      'add handler for error cell hover
      AddHandler dgvReport.MouseMove, AddressOf ToolTipHandler

      Dim fans As List(Of Fan) = getFans(String.Empty)
      cboFanDescription.DataSource = fans
      cboFanDescription.DisplayMember = "Description"

      coils = getCoils()

      ERROR_ARRAYS() 'load error codes into menory

      cbo_ovf.Items.Add("0")
      cbo_ovf.Items.Add("1")
      cbo_ovf.Items.Add("2")
      cbo_ovf.Items.Add("3")
      cbo_ovf.Text = "0"

      Cbo_SubCooler.Items.Add("Yes")
      Cbo_SubCooler.Items.Add("No")
      Cbo_SubCooler.Text = "No"

      Cbo_OddRow.Items.Add("YES")
      Cbo_OddRow.Items.Add("NO")
      Cbo_OddRow.Text = "YES"

      CBO_FEED_LOCATION.Items.Add("T")
      CBO_FEED_LOCATION.Items.Add("C")
      CBO_FEED_LOCATION.Items.Add("B")
      CBO_FEED_LOCATION.Text = "B"

      CBO_CFMT.Items.Add("A")
      CBO_CFMT.Items.Add("S")
      CBO_CFMT.Text = "A"

      circuits = FluidCoolerCircuiting.Populate()
      'CBO_SERP.DataSource = FluidCoolerCircuiting.Populate()
      'CBO_SERP.DisplayMember = "FluidCoolerCircuitingText"

      Cbo_GAS.Items.Add("AIR")
      Cbo_GAS.Items.Add("OTHER")
      Cbo_GAS.Text = "AIR"

      CBO_FIN_TYPE.DataSource = Utility.Enum2DataTable(Coil.FinType.Flat)
      CBO_FIN_TYPE.DisplayMember = "Key"
      CBO_FIN_TYPE.ValueMember = "Value"

      Dim dtbTubeThick As DataTable = Utility.Hash2DataTable(Coil.TubeThicknesses())
      Dim dvTubeThick As DataView = dtbTubeThick.DefaultView
      dvTubeThick.Sort = "Value asc"
      CBO_TUBETHICKNESS.DataSource = dvTubeThick 'Utility.Hash2DataTable(Coil.TubeThicknesses())
      CBO_TUBETHICKNESS.DisplayMember = "Key"
      CBO_TUBETHICKNESS.ValueMember = "Value"
      'CBO_TUBETHICKNESS.Items.Add(".020")
      'CBO_TUBETHICKNESS.Items.Add(".025")
      'CBO_TUBETHICKNESS.Items.Add(".035")
      'CBO_TUBETHICKNESS.Items.Add(".049")
      'CBO_TUBETHICKNESS.Text = ".020"

      CBO_FINMATL.DataSource = Utility.Enum2DataTable(Coil.FinMaterials.AL)
      CBO_FINMATL.DisplayMember = "Key"
      CBO_FINMATL.ValueMember = "Value"
      'CBO_FINMATL.Items.Add("AL")
      'CBO_FINMATL.Items.Add("CU")
      'CBO_FINMATL.Text = "AL"

      CBO_TUBEMATL_KING.DataSource = Utility.Enum2DataTable(Coil.TubeMaterials.CU)
      CBO_TUBEMATL_KING.DisplayMember = "Key"
      CBO_TUBEMATL_KING.ValueMember = "Value"

      'CBO_TUBEMATL_KING.Items.Add("CU")
      'CBO_TUBEMATL_KING.Items.Add("SS")
      'CBO_TUBEMATL_KING.Items.Add("ST")
      'CBO_TUBEMATL_KING.Items.Add("AL")
      'CBO_TUBEMATL_KING.Text = "CU"

      Dim dtbFinThick As DataTable = Utility.Hash2DataTable(Coil.FinThicknesses())
      Dim dvFinThick As DataView = dtbFinThick.DefaultView
      dvFinThick.Sort = "Value asc"
      CBO_FINTHICKNESS.DataSource = dvFinThick 'Utility.Hash2DataTable(Coil.FinThicknesses())
      CBO_FINTHICKNESS.DisplayMember = "Key"
      CBO_FINTHICKNESS.ValueMember = "Value"

      'CBO_FINTHICKNESS.Items.Add(".006")
      'CBO_FINTHICKNESS.Items.Add(".008")
      'CBO_FINTHICKNESS.Items.Add(".010")
      'CBO_FINTHICKNESS.Text = ".006"

      CBO_FLUIDTYPE.Items.Add("WTR")
      CBO_FLUIDTYPE.Items.Add("PG")
      CBO_FLUIDTYPE.Items.Add("EG")
      'CBO_FLUIDTYPE.Items.Add("OTHER")
      CBO_FLUIDTYPE.Text = "WTR"

      CBO_HAND.DataSource = Utility.Enum2DataTable(Coil.Orientations.R)
      CBO_HAND.DisplayMember = "Key"
      CBO_HAND.ValueMember = "Value"

      With Me.CBO_Refg
         .DataSource = Utility.Enum2DataTable(Rae.Engineering.RefrigerantType.R134a)
         .DisplayMember = "Key"
         .ValueMember = "Value"
      End With
      Me.CBO_Refg.SelectedIndex = 1

      Dim rows As New ArrayList
      For Each c As Coil In coils
         Dim isIn As Boolean = False
         For Each r As Integer In rows
            If r = c.NumRows Then
               isIn = True
            End If
         Next
         If Not isIn Then
            rows.Add(c.NumRows)
         End If
      Next
      Me.Cbo_rows.DataSource = rows
      SetDiameters()
      cboDiameter.SelectedIndex = 1
      'Me.Text = "RAE Corporation         Selection and Rating DLL Interface Screen" & "  Version " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision & "  Rep Mode"
      cboHeight.DataSource = Heights()
      cboLength.DataSource = Lengths()
      cboSeries.DataSource = Rae.RaeSolutions.Business.Entities.FluidCoolerSeries.Populate()
      cboSeries.DisplayMember = "ModelSeries"
      fcCoil.Diameter = 0.625

      IsLoaded = True
      ' LoadFPI()
      Authorize()

      AddHandler MainForm.RevisionView1.RevisionChanged, AddressOf RevisionView_RevisionChanged

   End Sub

   Private Function Heights() As ArrayList
      Dim al As New ArrayList
      For i As Double = 6 To 96 Step 1.5
         al.Add(i)
      Next
      Return al
   End Function

   Private Function Lengths() As ArrayList
      Dim al As New ArrayList
      For i As Integer = 6 To 300
         al.Add(i)
      Next
      Return al
   End Function

   Public Sub SET_CBO_GAS2()
      If Cbo_GAS.Text = "AIR" Then
         C_FLUID = UCase(Cbo_GAS.Text)
      End If

      If Cbo_GAS.Text = "OTHER" Then
         TITLE = "Gas Type"
         defval = C_GAS
         msg = "Enter gas type: "
         C_GAS = InputBox(msg, TITLE, defval)
         ToolTip1.SetToolTip(Cbo_GAS, C_GAS)
         VB6.ShowForm(frm_Gas, VB6.FormShowConstants.Modal, Me)
      End If
   End Sub


   Private Sub SET_MODEL_NUMBER()
      'CLEAR_COIL_WEIGHT_LABEL()
      'Dim temp_thickness As String
      'List1.Items.Clear()
      'List2.Items.Clear()

      'temp_thickness = Trim(CBO_FINTHICKNESS.Text)
      'CBO_FINTHICKNESS.Items.Clear()
      'CBO_FINTHICKNESS.Items.Add(".006")
      'CBO_FINTHICKNESS.Items.Add(".008")
      'CBO_FINTHICKNESS.Items.Add(".010")
      'If temp_thickness = ".006" Or temp_thickness = ".008" Or temp_thickness = ".010" Then
      '   CBO_FINTHICKNESS.Text = temp_thickness
      'Else
      '   CBO_FINTHICKNESS.Text = ".006"
      'End If
   End Sub

   Private Sub CALL_DX_PRINTING()
      print_msg = "   DX      (RAESelRatingCore.dll)   Output"
      print_msg = print_msg & Chr(10) & ""
      '*************************
      If RAE_Choice = "R" Then
         print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_LDB1, 2) & "  LEAVING DRY BULB"
      Else
         print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_LDB1, 2) & "    Selection2 = " & Round(RAE_Out_LDB2, 2) & "  LEAVING DRY BULB"
      End If
      '*************************
      If RAE_Choice = "R" Then
         print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_LWB1, 2) & "  LEAVING WET BULB"
      Else
         print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_LWB1, 2) & "    Selection2 = " & Round(RAE_Out_LWB2, 2) & "  LEAVING WET BULB"
      End If
      '*************************
      If RAE_Choice = "R" Then
         print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_Total_HT1, 2) & "  TOTAL HT"
      Else
         print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_Total_HT1, 2) & "    Selection2 = " & Round(RAE_Out_Total_HT2, 2) & "  TOTAL HT"
      End If
      '*************************
      If RAE_Choice = "R" Then
         print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_Sens_HT1, 2) & "  SENS HT"
      Else
         print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_Sens_HT1, 2) & "    Selection2 = " & Round(RAE_Out_Sens_HT2, 2) & "  SENS HT"
      End If
      '*************************
      If RAE_Choice = "R" Then
         print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_Refg_pres_drop1, 3) & "  REFG PD, FT"
      Else
         print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_Refg_pres_drop1, 3) & "    Selection2 = " & Round(RAE_Out_Refg_pres_drop2, 3) & "  REFG. PD, FT"
      End If
      '*************************
      If RAE_Choice = "R" Then
         print_msg = print_msg & Chr(10) & "Selection1 = " & RAE_Out_No_of_Circuits1 & "  NUMBER OF CIRCUITS"
      Else
         print_msg = print_msg & Chr(10) & "Selection1 = " & RAE_Out_No_of_Circuits1 & "    Selection2 = " & RAE_Out_No_of_Circuits2 & "  NUMBER OF CIRCUITS"
      End If
      '*************************
      If RAE_Choice = "R" Then
         print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_Air_Press_Drop1, 3) & "  AIR PRESSURE DROP"
      Else
         print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_Air_Press_Drop1, 3) & "    Selection2 = " & Round(RAE_Out_Air_Press_Drop2, 3) & "  AIR PRESSURE DROP"
      End If
      '*************************
      If RAE_Choice = "R" Then
         print_msg = print_msg & Chr(10) & "Selection1 = " & RAE_Out_Connections1 & "  CONNECTIONS"
      Else
         print_msg = print_msg & Chr(10) & "Selection1 = " & RAE_Out_Connections1 & "    Selection2 = " & RAE_Out_Connections2 & "  CONNECTIONS"
      End If
      '*************************
      If RAE_Choice = "R" Then
         print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_Circuit_load1, 3) & "  CIRCUIT LOAD"
      Else
         print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_Circuit_load1, 3) & "    Selection2 = " & Round(RAE_Out_Circuit_load2, 3) & "  CIRCUIT LOAD"
      End If
      '************************* THESE ARE USED IN .RAE_Out_SELECTION1 AND .RAE_Out_SELECTION2
      '? = RAE_Out_FPI1
      '? = RAE_Out_ROWS1
      '? = RAE_Out_CIRCUITING1
      If RAE_Choice = "S" Then
         '? = RAE_Out_FPI2
         '? = RAE_Out_ROWS2
         '? = RAE_Out_CIRCUITING2
      End If
      '*************************
      print_msg = print_msg & Chr(10) & "(SELECTION 1)    " & RAE_Out_SELECTION1
      If RAE_Choice = "S" Then
         print_msg = print_msg & Chr(10) & "(SELECTION 2)    " & RAE_Out_SELECTION2
      End If
      '************add weight output************Danny Groom 12/11/2000
      print_msg = print_msg & Chr(10) & "(COIL WEIGHT 1) = " & COIL_WEIGHT1 & " lbs."
      If RAE_Choice = "S" Then
         print_msg = print_msg & Chr(10) & "(COIL WEIGHT 2) = " & COIL_WEIGHT2 & " lbs."
      End If
      '*************************
      print_msg = print_msg & Chr(10) & RAE_Out_Opp_End_Conn
      print_msg = print_msg & Chr(10) & RAE_Out_ARI_MSG1
      print_msg = print_msg & Chr(10) & RAE_Out_ARI_MSG2
      print_msg = print_msg & Chr(10) & RAE_Out_ARI_MSG3
      '*************************
      '**********************************************************
      '*************************
      'UPGRADE_WARNING: Couldn't resolve default property of object msg. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
      msg = print_msg
      STYLE = CStr(MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) ' Define buttons.
      'UPGRADE_WARNING: Couldn't resolve default property of object TITLE. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
      TITLE = "PRINT SCREEN ?"

      'UPGRADE_WARNING: Couldn't resolve default property of object TITLE. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
      RESPONSE = CStr(MsgBox(msg, CDbl(STYLE), TITLE))

      If RESPONSE = CStr(MsgBoxResult.Yes) Then ' User chose Yes.
         CommonDialog1Print.ShowDialog()
         GoTo cmd_print222

cmd_print222:

      Else ' User chose No.

      End If
      '*************************
      '**********************************************************
cmd_print2:
   End Sub


   Private Sub CALL_WATER_HOT_OR_COLD()
      clear_output_var()
      ERROR_ARRAYS() 'Updated 12/1/1999 D.Groom new line

      RAESelRatingCore = New RAE_SelectionRating.RAESelectionRating ' RRAESelRatingCore
      With RAESelRatingCore 'Starting the link with DLL
         .RAE_CFMT = Trim(CBO_CFMT.Text) 'A = Actual CFM OR S = Standard CFM  New 10/22/2004 DGroom
         .RAE_Choice = "R" 'CBO_CHOICE.Text 'S or R
         .RAE_CoilSize = Coil.Diameters(Coil.CoilModes.Rae, Coil.CoilTypes.W).Item(fcCoil.Diameter) 'Cbo_coilsize.Text '12 or 58
         .RAE_CoilType = Coil.CoilTypes.W.ToString() 'Cbo_coiltype.Text 'W (FLUID)
         .RAE_Hot_Cold = "H" 'CBO_HOT_COLD.Text 'H or C
         .RAE_FinHeight = fcCoil.FinHeight ' Cbo_fh.Text 'FOR 1/2 COILS USE (1.25 * TUBES HEIGHT), FOR 5/8 COILS USE (1.5 * TUBES HEIGHT)
         .RAE_FinLength = fcCoil.FinLength ' lbl_fl.Text '1 TO 300 INCHES
         .RAE_FPI = fcCoil.FPI ' Cbo_fpi.Text '4 TO 14
         .RAE_rows = fcCoil.NumRows ' Cbo_rows.Text '1 TO 24

         .RAE_CFM = TXT_CFM.Text 'PER APPLICATION (NUMBER)
         .RAE_EDB = TXT_EDB.Text 'PER APPLICATION (NUMBER)
         .RAE_EWB = TXT_EWB.Text 'PER APPLICATION (NUMBER)
         .RAE_EWT = TXT_EWT.Text 'PER APPLICATION (NUMBER)
         .RAE_GPM = TXT_GPM.Text 'PER APPLICATION (NUMBER)
         .RAE_WTD = TXT_WTD.Text 'PER APPLICATION (NUMBER)
         .RAE_SERP = fcCoil.Circuiting.FluidCoolerCircuitingValue '.TXT_SERP.Text 'Circuiting 0 TO 2  EX: OPTIMIZE = 0, FULL = 1, HALF = .5, QUARTER = .25, THREE QUARTE = .75, ONE AND ONE HALF = 1.5, DOUBLE = 2 AND E, J, Z ARE CALCULATED
         .RAE_LDB = 0 'RATING (NUMBER)
         .RAE_LWB = 0 'RATING (NUMBER)
         .RAE_SH = 0 'RATING (NUMBER)
         .RAE_TH = 0 'RATING (NUMBER)
         .RAE_FPD = TXT_FPD.Text 'PER APPLICATION (NUMBER)
         .RAE_ALDT = TXT_ALDT.Text 'PER APPLICATION (NUMBER)
         .RAE_FluidType = CBO_FLUIDTYPE.Text 'WTR, EG, PG
         .RAE_PerConc = TXT_PERCONC.Text '10 TO 60
         .RAE_FinMatl = CBO_FINMATL.Text 'AL OR CU
         .RAE_FinThickness = CBO_FINTHICKNESS.Text '.006, .008, .010
         .RAE_TubeMatl = TXT_TUBEMATL.Text 'CU
         .RAE_TubeThickness = CBO_TUBETHICKNESS.Text 'FOR 1/2 COILS USE .017, .025, .032 AND ON 5/8 COILS USE .020, .025, .035, .049
         .RAE_Hand = fcCoil.Orientation.ToString() '.Text 'L OR R
         .RAE_Fin_Type = fcCoil.FinDesign.ToString().Substring(0, 1) 'CBO_FIN_TYPE.Text 'W or F
         .RAE_FFI = TXT_FFI.Text 'PER APPLICATION (NUMBER)
         .RAE_FFO = TXT_FFO.Text 'PER APPLICATION (NUMBER)
         .RAE_CIRCUIT_TYPE = fcCoil.Circuiting.FluidCoolerCircuitingValue 'CIRCUIT_TYPE 'Added 4/3/2006 (OPTIMIZE = 0, FULL = F, HALF = H, QUARTER = Q, THREE QUARTER = T, ONE AND ONE HALF = N, DOUBLE = D AND Single = E, Double = J, Non-Standard = Z ARE CALCULATED)
         .AddToDatabase() 'This sets the DLL in action doing caluations

         RAE_Out_DLL_loop_Error = .RAE_Out_DLL_loop_Error
         RAE_Out_ERROR_MSG1 = .RAE_Out_ERROR_MSG1
         RAE_Out_ERROR_MSG2 = .RAE_Out_ERROR_MSG2
         RAE_Out_ERROR_MSG3 = .RAE_Out_ERROR_MSG3
         RAE_Out_Input_error1 = .RAE_Out_Input_error1
         RAE_Out_Input_error2 = .RAE_Out_Input_error2
         RAE_Out_Input_error3 = .RAE_Out_Input_error3
         RAE_Out_Input_error4 = .RAE_Out_Input_error4
         RAE_Out_Input_error5 = .RAE_Out_Input_error5
         RAE_Out_Input_error6 = .RAE_Out_Input_error6
         RAE_Out_Input_error7 = .RAE_Out_Input_error7
         RAE_Out_Input_error8 = .RAE_Out_Input_error8
         RAE_Out_Input_error9 = .RAE_Out_Input_error9

         If RAE_Out_Input_error1 > 0 Then
            MsgBox("Input Error #" & RAE_Out_Input_error1 & "  " & RAE_Out_Input_error_text(RAE_Out_Input_error1) & Chr(10) & "An Input error has occured, please check your input and try again.")
            GoTo SKIPPING_PRINTING_ACTION_DUE_TO_ERRORS_WATER
         End If
         If RAE_Out_Input_error2 > 0 Then
            MsgBox("Input Error #" & RAE_Out_Input_error2 & "  " & RAE_Out_Input_error_text(RAE_Out_Input_error2) & Chr(10) & "An Input error has occured, please check your input and try again.")
            GoTo SKIPPING_PRINTING_ACTION_DUE_TO_ERRORS_WATER
         End If
         If RAE_Out_Input_error3 > 0 Then
            MsgBox("Input Error #" & RAE_Out_Input_error3 & "  " & RAE_Out_Input_error_text(RAE_Out_Input_error3) & Chr(10) & "An Input error has occured, please check your input and try again.")
            GoTo SKIPPING_PRINTING_ACTION_DUE_TO_ERRORS_WATER
         End If

         If RAE_Out_DLL_loop_Error = 1 Then
            MsgBox("An Error has occured with the calulation, please check your input and try again.")
            GoTo SKIPPING_PRINTING_ACTION_DUE_TO_ERRORS_WATER
         End If

         RAE_Choice = .RAE_Choice
         RAE_Out_LDB1 = .RAE_Out_LDB1
         RAE_Out_LDB2 = .RAE_Out_LDB2
         RAE_Out_LWB1 = .RAE_Out_LWB1
         RAE_Out_LWB2 = .RAE_Out_LWB2
         RAE_Out_Total_HT1 = .RAE_Out_Total_HT1
         RAE_Out_Total_HT2 = .RAE_Out_Total_HT2
         RAE_Out_Sens_HT1 = .RAE_Out_Sens_HT1
         RAE_Out_Sens_HT2 = .RAE_Out_Sens_HT2
         RAE_Out_LWT1 = .RAE_Out_LWT1
         RAE_Out_LWT2 = .RAE_Out_LWT2
         RAE_Out_GPM1 = .RAE_Out_GPM1
         RAE_Out_GPM2 = .RAE_Out_GPM2
         RAE_Out_Water_Vel1 = .RAE_Out_Water_Vel1
         RAE_Out_Water_Vel2 = .RAE_Out_Water_Vel2
         RAE_Out_CIRCUITING1 = .RAE_Out_CIRCUITING1
         RAE_Out_CIRCUITING2 = .RAE_Out_CIRCUITING2

         If RAE_Out_ERROR_MSG1 = 1004 Then 'WATER COILS

            If RAE_Choice = "R" Then
               'UPGRADE_WARNING: Couldn't resolve default property of object msg. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
               msg = "(WARNING 1004) WATER COIL FLUID TUBE VELOCITY LESS THAN 1 FPS PER CIRCUIT, CHANGE CIRCUITING TO INCRESS TUBE VELOCITY." & Chr(10) & Chr(10) & "SELECTION 1 TUBE VELOCITY = (" & Round(RAE_Out_Water_Vel1, 3) & " FPS)   - " & RAE_Out_CIRCUITING1 & " - CIRCUIT SELECTION" & Chr(10) & Chr(10) & "RECOMMENDED TUBE VELOCITY 1 TO 6 FPS PER CIRCUIT." & Chr(10) & Chr(10) & "COULD CREATE A LAMINAR FLOW SITUATION (NOT RECOMMENDED) ON WATER/GLYCOL COIL'S."
            Else
               'UPGRADE_WARNING: Couldn't resolve default property of object msg. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
               msg = "(WARNING 1004) WATER COIL FLUID TUBE VELOCITY LESS THAN 1 FPS PER CIRCUIT, CHANGE CIRCUITING TO INCRESS TUBE VELOCITY." & Chr(10) & Chr(10) & "SELECTION 1 TUBE VELOCITY = (" & Round(RAE_Out_Water_Vel1, 3) & " FPS)   - " & RAE_Out_CIRCUITING1 & " - CIRCUIT SELECTION" & Chr(10) & "SELECTION 2 TUBE VELOCITY = (" & Round(RAE_Out_Water_Vel2, 3) & " FPS)   - " & RAE_Out_CIRCUITING2 & " - CIRCUIT SELECTION" & Chr(10) & Chr(10) & "RECOMMENDED TUBE VELOCITY 1 TO 6 FPS PER CIRCUIT." & Chr(10) & Chr(10) & "COULD CREATE A LAMINAR FLOW SITUATION (NOT RECOMMENDED) ON WATER/GLYCOL COIL'S."
            End If
            '*************************
            STYLE = CStr(MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) ' Define buttons.
            'UPGRADE_WARNING: Couldn't resolve default property of object TITLE. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            TITLE = "CANCEL JOB?" ' Define title.
            'UPGRADE_WARNING: Couldn't resolve default property of object TITLE. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            RESPONSE = CStr(MsgBox(msg, CDbl(STYLE), TITLE))
            If RESPONSE = CStr(MsgBoxResult.Yes) Then ' User chose Yes.
               GoTo SKIPPING_PRINTING_ACTION_DUE_TO_ERRORS_WATER
            Else ' User chose No.
            End If
            '*************************
         End If

         If RAE_Out_ERROR_MSG2 = 1005 Then 'WATER COILS

            msg = "(WARNING 1005) WATER COIL FLUID TUBE VELOCITY GREATER THAN 6 FPS PER CIRCUIT NOT RECOMMENDED, CHANGE CIRCUITING TO DECRESS TUBE VELOCITY." & Chr(10) & Chr(10) & "SELECTION 1 TUBE VELOCITY = (" & Round(RAE_Out_Water_Vel1, 3) & " FPS)   - " & RAE_Out_CIRCUITING1 & " - CIRCUIT SELECTION" & Chr(10) & Chr(10) & "RECOMMENDED TUBE VELOCITY 1 TO 6 FPS PER CIRCUIT."

            '*************************
            STYLE = CStr(MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) ' Define buttons.
            'UPGRADE_WARNING: Couldn't resolve default property of object TITLE. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            TITLE = "CANCEL JOB?" ' Define title.
            'UPGRADE_WARNING: Couldn't resolve default property of object TITLE. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            RESPONSE = CStr(MsgBox(msg, CDbl(STYLE), TITLE))
            If RESPONSE = CStr(MsgBoxResult.Yes) Then ' User chose Yes.
               GoTo SKIPPING_PRINTING_ACTION_DUE_TO_ERRORS_WATER
            Else ' User chose No.
            End If
            '*************************
         End If

         If RAE_Out_ERROR_MSG1 = 1006 Then
            MsgBox("(WARNING 1006) NO CONNECTIONS WERE SELECTED FOR THIS JOB.  PLEASE CONTACT FACTORY FOR SELECTION.")
         End If
         '***********************************************************************
         '***********************************************************************
         '*************************
         'UPGRADE_WARNING: Couldn't resolve default property of object RAESelRatingCore.RAE_Out_Fluid_PD1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
         RAE_Out_Fluid_PD1 = .RAE_Out_Fluid_PD1
         'UPGRADE_WARNING: Couldn't resolve default property of object RAESelRatingCore.RAE_Out_Fluid_PD2. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
         RAE_Out_Fluid_PD2 = .RAE_Out_Fluid_PD2
         'UPGRADE_WARNING: Couldn't resolve default property of object RAESelRatingCore.RAE_Out_No_of_Circuits1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
         RAE_Out_No_of_Circuits1 = .RAE_Out_No_of_Circuits1
         'UPGRADE_WARNING: Couldn't resolve default property of object RAESelRatingCore.RAE_Out_No_of_Circuits2. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
         RAE_Out_No_of_Circuits2 = .RAE_Out_No_of_Circuits2
         'UPGRADE_WARNING: Couldn't resolve default property of object RAESelRatingCore.RAE_Out_Air_Press_Drop1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
         RAE_Out_Air_Press_Drop1 = .RAE_Out_Air_Press_Drop1
         'UPGRADE_WARNING: Couldn't resolve default property of object RAESelRatingCore.RAE_Out_Air_Press_Drop2. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
         RAE_Out_Air_Press_Drop2 = .RAE_Out_Air_Press_Drop2
         'UPGRADE_WARNING: Couldn't resolve default property of object RAESelRatingCore.RAE_Out_Connections1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
         RAE_Out_Connections1 = .RAE_Out_Connections1
         'UPGRADE_WARNING: Couldn't resolve default property of object RAESelRatingCore.RAE_Out_Connections2. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
         RAE_Out_Connections2 = .RAE_Out_Connections2
         'UPGRADE_WARNING: Couldn't resolve default property of object RAESelRatingCore.RAE_Out_FPI1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
         RAE_Out_FPI1 = .RAE_Out_FPI1
         'UPGRADE_WARNING: Couldn't resolve default property of object RAESelRatingCore.RAE_Out_ROWS1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
         RAE_Out_ROWS1 = .RAE_Out_ROWS1
         'UPGRADE_WARNING: Couldn't resolve default property of object RAESelRatingCore.RAE_Out_FPI2. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
         RAE_Out_FPI2 = .RAE_Out_FPI2
         'UPGRADE_WARNING: Couldn't resolve default property of object RAESelRatingCore.RAE_Out_ROWS2. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
         RAE_Out_ROWS2 = .RAE_Out_ROWS2
         'UPGRADE_WARNING: Couldn't resolve default property of object RAESelRatingCore.RAE_Out_SELECTION1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
         RAE_Out_SELECTION1 = .RAE_Out_SELECTION1
         'UPGRADE_WARNING: Couldn't resolve default property of object RAESelRatingCore.RAE_Out_SELECTION2. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
         RAE_Out_SELECTION2 = .RAE_Out_SELECTION2
         'UPGRADE_WARNING: Couldn't resolve default property of object RAESelRatingCore.RAE_Out_Opp_End_Conn. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
         RAE_Out_Opp_End_Conn = .RAE_Out_Opp_End_Conn
         'UPGRADE_WARNING: Couldn't resolve default property of object RAESelRatingCore.RAE_Out_ARI_MSG1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
         RAE_Out_ARI_MSG1 = .RAE_Out_ARI_MSG1
         'UPGRADE_WARNING: Couldn't resolve default property of object RAESelRatingCore.RAE_Out_ARI_MSG2. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
         RAE_Out_ARI_MSG2 = .RAE_Out_ARI_MSG2
         'UPGRADE_WARNING: Couldn't resolve default property of object RAESelRatingCore.RAE_Out_ARI_MSG3. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
         RAE_Out_ARI_MSG3 = .RAE_Out_ARI_MSG3


SKIPPING_PRINTING_ACTION_DUE_TO_ERRORS_WATER:

      End With 'End DLL Variable passing

      'CALL_WATER_HOT_OR_COLD_PRINTING()

      RAESelRatingCore = Nothing 'Clearing DLL Variables

   End Sub

   Private Sub SET_SCREEN_WATER()
      CBO_FEED_LOCATION.Visible = False
      Label48.Visible = False
      CBO_Refg.Visible = False
      Label40.Visible = False
      cbo_ovf.Visible = False
      Label46.Visible = False
      Label43.Visible = False
      Label44.Visible = False
      Label45.Visible = False
      Cbo_SubCooler.Visible = False
      Cbo_SubCooler.Text = "No"
      txt_SCIR.Visible = False
      txt_ft.Visible = False


      TXT_MBH.Visible = False 'NOT USED FOR WATER
      Label39.Visible = False


      'If Cbo_coiltype.Text = "W" And CBO_CHOICE.Text = "R" And CBO_HOT_COLD.Text = "H" Then

      TXT_STMP.Visible = False 'TRUE
      Label35.Visible = False 'TRUE

      TXT_CFM.Visible = True 'FALSE
      Label19.Visible = True 'FALSE


      TXT_EDB.Visible = True 'FALSE
      Label18.Visible = True 'FALSE


      TXT_EWB.Visible = False
      Label17.Visible = False


      TXT_LDB.Visible = False
      Label12.Visible = False


      TXT_LWB.Visible = False
      Label11.Visible = False


      TXT_EWT.Visible = True 'FALSE
      Label16.Visible = True 'FALSE


      TXT_GPM.Visible = True 'FALSE
      Label15.Visible = True 'FALSE

      TXT_WTD.Visible = True 'FALSE
      Label14.Visible = True 'FALSE


      CBO_SERP.Visible = True 'FALSE
      Label13.Visible = True 'FALSE


      TXT_SUCTION_TEMP.Visible = False 'TRUE
      Label33.Visible = False 'TRUE


      TXT_LIQUID_TEMP.Visible = False 'TRUE
      Label34.Visible = False 'TRUE


      TXT_SH.Visible = False
      Label10.Visible = False

      TXT_TH.Visible = False
      Label26.Visible = False


      TXT_FPD.Visible = True 'FALSE
      Label25.Visible = True 'FALSE


      TXT_ALDT.Visible = True 'FALSE
      Label24.Visible = True 'FALSE


      CBO_FLUIDTYPE.Visible = True 'FALSE
      Label23.Visible = True 'FALSE


      TXT_PERCONC.Visible = True 'FALSE
      Label22.Visible = True 'FALSE


      ' CBO_HOT_COLD.Visible = True 'FALSE
      ' Label28.Visible = True 'FALSE


      TXT_FFO.Visible = True 'FALSE
      Label1.Visible = True 'FALSE


      TXT_FFI.Visible = True 'FALSE
      Label37.Visible = True 'FALSE

      ' End If

      '**************************


      If CBO_FLUIDTYPE.Text = "PG" Or CBO_FLUIDTYPE.Text = "EG" Then
         TXT_PERCONC.Visible = True
         Label22.Visible = True
      Else
         TXT_PERCONC.Visible = False
         Label22.Visible = False
      End If

      CBO_SERP.Enabled = True


   End Sub

   Private Sub SET_SCREEN_CONDENSER()
      CBO_FEED_LOCATION.Visible = True
      Label48.Visible = True
      CBO_Refg.Visible = True
      Label40.Visible = True
      Label43.Visible = True
      Label44.Visible = True
      Label45.Visible = True


      Cbo_SubCooler.Visible = True
      txt_SCIR.Visible = True
      txt_ft.Visible = True
      TXT_MBH.Visible = False



      Label39.Visible = True


      TXT_STMP.Visible = False
      Label35.Visible = False

      TXT_CFM.Visible = True
      Label19.Visible = True


      TXT_EDB.Visible = True
      Label18.Visible = True


      TXT_EWB.Visible = False
      Label17.Visible = False


      TXT_LDB.Visible = False
      Label12.Visible = False


      TXT_LWB.Visible = False
      Label11.Visible = False


      TXT_EWT.Visible = False
      Label16.Visible = False


      TXT_GPM.Visible = False
      Label15.Visible = False

      TXT_WTD.Visible = False
      Label14.Visible = False


      CBO_SERP.Visible = True 'FALSE
      Label13.Visible = True 'FALSE


      TXT_SUCTION_TEMP.Visible = True
      Label33.Visible = True


      TXT_LIQUID_TEMP.Visible = True 'CONDENSER TEMP.
      Label34.Visible = True


      TXT_SH.Visible = False
      Label10.Visible = False

      TXT_TH.Visible = False
      Label26.Visible = False


      TXT_FPD.Visible = False
      Label25.Visible = False


      TXT_ALDT.Visible = True 'FALSE
      Label24.Visible = True 'FALSE


      CBO_FLUIDTYPE.Visible = False
      Label23.Visible = False


      TXT_PERCONC.Visible = False
      Label22.Visible = False


      'CBO_HOT_COLD.Visible = False
      'Label28.Visible = False


      TXT_FFO.Visible = True 'FALSE
      Label1.Visible = True 'FALSE


      TXT_FFI.Visible = False
      Label37.Visible = False




      CBO_SERP.Enabled = True

   End Sub

   Private Sub SET_CBO_SERP_SPECIAL()
      Dim msg, TITLE, defval, TEMP_HOLDING As Object

      Dim MyCheck As Object
      If CBO_SERP.Text = "OTHER-SPECIAL CIRCUITING" Or CBO_SERP.Text = "TWO TUBE FEED NO HEADERS" Or CBO_SERP.Text = "ONE TUBE FEED NO HEADERS" Then

         TITLE = "INPUT DATA"
         defval = TXT_SERP.Text
         msg = "ENTER CIRCUITING PERCENT: " & Chr(10) & Chr(10) & "EX: (TUBES FED / TUBES TALL)" & Chr(10) & "    2 / 12 = .166"
         TEMP_HOLDING = InputBox(msg, TITLE, defval)


         MyCheck = IsNumeric(TEMP_HOLDING) ' Returns True.
         If MyCheck = True Then

            If TEMP_HOLDING <= 0 Then
               MsgBox("BAD INPUT RESETTING CIRCUIT TYPE TO OPTIMIZE, PLEASE CHOOSE AGAIN.")
               TXT_SERP.Text = CStr(0)
               CBO_SERP.Text = "OPTIMIZE"
            Else
               TXT_SERP.Text = TEMP_HOLDING
            End If
         Else
            TXT_SERP.Text = CStr(0)
            CBO_SERP.Text = "OPTIMIZE"
            MsgBox("BAD INPUT RESETTING CIRCUIT TYPE TO OPTIMIZE")
         End If
      End If
   End Sub


   Private Sub SSPanel1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SSPanel1.Click
      '        Dim MyCheck As Object



      '        On Error GoTo ERROR_RESTART_SSPanel1

      'ERROR_RESTARTING_SSPanel1:
      '        'UPGRADE_WARNING: Couldn't resolve default property of object TITLE. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
      '        TITLE = "INPUT DATA - FPM -"
      '        'UPGRADE_WARNING: Couldn't resolve default property of object defval. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
      '        defval = FPM_TEMP

      '        'UPGRADE_WARNING: Couldn't resolve default property of object msg. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
      '        msg = "ENTER FEET PER MINUTE: "

      '        'UPGRADE_WARNING: Couldn't resolve default property of object defval. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
      '        'UPGRADE_WARNING: Couldn't resolve default property of object TITLE. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
      '        'UPGRADE_WARNING: Couldn't resolve default property of object msg. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
      '        'UPGRADE_WARNING: Couldn't resolve default property of object TEMP_HOLDING. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
      '        TEMP_HOLDING = InputBox(msg, TITLE, defval)

      '        'UPGRADE_WARNING: Couldn't resolve default property of object TEMP_HOLDING. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
      '        If Trim(TEMP_HOLDING) <= " " Then
      '            GoTo END_RESTARTING_SSPanel1
      '        End If

      '        'UPGRADE_WARNING: Couldn't resolve default property of object MyCheck. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
      '        MyCheck = IsNumeric(TEMP_HOLDING) ' Returns True.
      '        'UPGRADE_WARNING: Couldn't resolve default property of object MyCheck. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
      '        If MyCheck = True Then

      '            'UPGRADE_WARNING: Couldn't resolve default property of object TEMP_HOLDING. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
      '            If TEMP_HOLDING < 0 Then
      '                MsgBox("NO NEG. NUMBERS PLEASE.")
      '                GoTo ERROR_RESTARTING_SSPanel1
      '            End If

      '            'UPGRADE_WARNING: Couldn't resolve default property of object TEMP_HOLDING. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
      '            FPM_TEMP = TEMP_HOLDING
      '            TXT_CFM.Text = CStr(Round(((fcCoil.FinLength * fcCoil.FinHeight) / 144) * FPM_TEMP, 0))
      '        Else
      '            MsgBox("FPM IS A NUMBER NOT A LETTER, PLEASE TRY AGAIN.")
      '            GoTo ERROR_RESTARTING_SSPanel1
      '        End If

      '        GoTo END_RESTARTING_SSPanel1
      'ERROR_RESTART_SSPanel1:
      '        MsgBox("BAD INPUT TRY AGAIN." & Chr(10) & Chr(10) & "TTP Error(18)")
      '        Resume ERROR_RESTARTING_SSPanel1


      'END_RESTARTING_SSPanel1:

   End Sub


   'UPGRADE_WARNING: Event TXT_ALDT.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
   Private Sub TXT_ALDT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TXT_ALDT.TextChanged
      CLEAR_COIL_WEIGHT_LABEL()
      NeedReCalc()
   End Sub


   'UPGRADE_WARNING: Event TXT_CFM.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
   Private Sub TXT_CFM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TXT_CFM.TextChanged
      'CLEAR_COIL_WEIGHT_LABEL()
      ''UPGRADE_WARNING: Couldn't resolve default property of object TEMP_HOLDING. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
      'TEMP_HOLDING = Trim(TXT_CFM.Text)
      ''UPGRADE_WARNING: Couldn't resolve default property of object MyCheck. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
      'MyCheck = IsNumeric(TEMP_HOLDING) ' Returns True.
      ''UPGRADE_WARNING: Couldn't resolve default property of object MyCheck. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
      'If MyCheck = True Then
      '    'SET_FPM()

      'Else
      '    'CFM IS A NUMBER NOT A LETTER, PLEASE TRY AGAIN.
      '    TXT_CFM.Text = CStr(0)
      '    TXT_CFM.Focus()
      '    TXT_CFM.SelectionStart = 0
      '    TXT_CFM.SelectionLength = Len(TXT_CFM.Text)
      'End If

   End Sub


   'UPGRADE_WARNING: Event TXT_EDB.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
   Private Sub TXT_EDB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TXT_EDB.TextChanged
      CLEAR_COIL_WEIGHT_LABEL()
      txt_dummy_box.Text = TXT_EDB.Text
      txt_dummy_box.SelectionStart = 0
      txt_dummy_box.SelectionLength = 1
      DATE_PP1 = txt_dummy_box.SelectedText
      txt_dummy_box.SelectionStart = 1
      txt_dummy_box.SelectionLength = 6
      DATE_PP2 = txt_dummy_box.SelectedText

      If DATE_PP1 = "-" Then
         TEMP_HOLDING = Trim(DATE_PP2)
         MyCheck = IsNumeric(TEMP_HOLDING) ' Returns True.
      Else
         TEMP_HOLDING = Trim(TXT_EDB.Text)
         MyCheck = IsNumeric(TEMP_HOLDING) ' Returns True.
      End If

      If MyCheck = True Then
         lbl_SenCoilOnly.Visible = False
      Else
         If DATE_PP1 = "-" Then
         Else
            TXT_EDB.Text = CStr(0)
            TXT_EDB.Focus()
            TXT_EDB.SelectionStart = 0
            TXT_EDB.SelectionLength = Len(TXT_EDB.Text)
         End If

      End If
      NeedReCalc()
   End Sub

   Private Sub TXT_EWB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TXT_EWB.TextChanged
      If Val(TXT_EWB.Text) > Val(TXT_EDB.Text) Then
         MsgBox("The EDB must be greater than the EWB, Please reenter the EWB")
         TXT_EWB.Text = "0"
      End If

      If Val(TXT_EWB.Text) > 0 Then
         lbl_SenCoilOnly.Visible = False
      End If
      CLEAR_COIL_WEIGHT_LABEL()

      txt_dummy_box.Text = TXT_EWB.Text
      txt_dummy_box.SelectionStart = 0
      txt_dummy_box.SelectionLength = 1
      DATE_PP1 = txt_dummy_box.SelectedText
      txt_dummy_box.SelectionStart = 1
      txt_dummy_box.SelectionLength = 6
      DATE_PP2 = txt_dummy_box.SelectedText

      If DATE_PP1 = "-" Then
         TEMP_HOLDING = Trim(DATE_PP2)
         MyCheck = IsNumeric(TEMP_HOLDING) ' Returns True.
      Else
         TEMP_HOLDING = Trim(TXT_EWB.Text)
         MyCheck = IsNumeric(TEMP_HOLDING) ' Returns True.
      End If

      If MyCheck = True Then
      Else
         If DATE_PP1 = "-" Then
         Else
            TXT_EWB.Text = CStr(0)
            TXT_EWB.Focus()
            TXT_EWB.SelectionStart = 0
            TXT_EWB.SelectionLength = Len(TXT_EWB.Text)
         End If

      End If
   End Sub

   Private Sub TXT_EWT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TXT_EWT.TextChanged
      CLEAR_COIL_WEIGHT_LABEL()
      txt_dummy_box.Text = TXT_EWT.Text
      txt_dummy_box.SelectionStart = 0
      txt_dummy_box.SelectionLength = 1
      DATE_PP1 = txt_dummy_box.SelectedText
      txt_dummy_box.SelectionStart = 1
      txt_dummy_box.SelectionLength = 6
      DATE_PP2 = txt_dummy_box.SelectedText

      If DATE_PP1 = "-" Then
         TEMP_HOLDING = Trim(DATE_PP2)
         MyCheck = IsNumeric(TEMP_HOLDING) ' Returns True.
      Else
         TEMP_HOLDING = Trim(TXT_EWT.Text)
         MyCheck = IsNumeric(TEMP_HOLDING) ' Returns True.
      End If

      If MyCheck = True Then
      Else
         If DATE_PP1 = "-" Then
         Else
            TXT_EWT.Text = CStr(0)
            TXT_EWT.Focus()
            TXT_EWT.SelectionStart = 0
            TXT_EWT.SelectionLength = Len(TXT_EWT.Text)
         End If
      End If
      NeedReCalc()
   End Sub

   Private Sub TXT_FFI_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TXT_FFI.TextChanged
      TEMP_HOLDING = Trim(TXT_FFI.Text)
      MyCheck = IsNumeric(TEMP_HOLDING) ' Returns True.
      If MyCheck = True Then
      Else
         TXT_FFI.Text = CStr(0)
         TXT_FFI.Focus()
         TXT_FFI.SelectionStart = 0
         TXT_FFI.SelectionLength = Len(TXT_FFI.Text)
      End If
      CLEAR_COIL_WEIGHT_LABEL()
   End Sub

   Private Sub TXT_FFO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TXT_FFO.TextChanged
      TEMP_HOLDING = Trim(TXT_FFO.Text)
      MyCheck = IsNumeric(TEMP_HOLDING) ' Returns True.
      If MyCheck = True Then
      Else
         TXT_FFO.Text = CStr(0)
         TXT_FFO.Focus()
         TXT_FFO.SelectionStart = 0
         TXT_FFO.SelectionLength = Len(TXT_FFO.Text)
      End If
      CLEAR_COIL_WEIGHT_LABEL()
   End Sub

   Private Sub TXT_FPD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TXT_FPD.TextChanged
      CLEAR_COIL_WEIGHT_LABEL()
   End Sub

   'Private Sub GPMChanged()
   '   CLEAR_COIL_WEIGHT_LABEL()
   '   If TXT_GPM.Text <= "       " Then
   '      TXT_GPM.Text = "0"
   '   End If

   '   If CDbl(TXT_GPM.Text) > 0 Then
   '      TXT_WTD.Enabled = False
   '      TXT_WTD.Text = CStr(0)
   '      TXT_GPM.Enabled = True
   '      rbGPM.Checked = True
   '      rbWTD.Checked = False
   '   Else
   '      TXT_WTD.Enabled = True
   '      txt_()
   '      rbGPM.Checked = False
   '      rbWTD.Checked = True
   '   End If
   '   NeedReCalc()
   'End Sub

   Private Sub TXT_GPM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TXT_GPM.TextChanged
      If Not IsNumeric(TXT_GPM.Text) Then
         TXT_GPM.Text = "0"
      End If

   End Sub

   Private Sub TXT_LDB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TXT_LDB.TextChanged
      CLEAR_COIL_WEIGHT_LABEL()
      txt_dummy_box.Text = TXT_LDB.Text
      txt_dummy_box.SelectionStart = 0
      txt_dummy_box.SelectionLength = 1
      DATE_PP1 = txt_dummy_box.SelectedText
      txt_dummy_box.SelectionStart = 1
      txt_dummy_box.SelectionLength = 6
      DATE_PP2 = txt_dummy_box.SelectedText

      If DATE_PP1 = "-" Then
         TEMP_HOLDING = Trim(DATE_PP2)
         MyCheck = IsNumeric(TEMP_HOLDING) ' Returns True.
      Else
         TEMP_HOLDING = Trim(TXT_LDB.Text)
         MyCheck = IsNumeric(TEMP_HOLDING) ' Returns True.
      End If

      If MyCheck = True Then
      Else
         If DATE_PP1 = "-" Then
         Else
            TXT_LDB.Text = CStr(0)
            TXT_LDB.Focus()
            TXT_LDB.SelectionStart = 0
            TXT_LDB.SelectionLength = Len(TXT_LDB.Text)
         End If
      End If

      If TXT_LDB.Text <= "       " Then
         TXT_LDB.Text = "0"
      End If

      If CDbl(TXT_LDB.Text) > 0 Then
         TXT_TH.Visible = False
         TXT_TH.Text = CStr(0)

         TXT_SH.Visible = False
         TXT_SH.Text = CStr(0)
      Else
         TXT_TH.Visible = True
         TXT_SH.Visible = True
      End If
      NeedReCalc()
   End Sub

   Private Sub TXT_LIQUID_TEMP_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TXT_LIQUID_TEMP.TextChanged
      CLEAR_COIL_WEIGHT_LABEL()
      txt_dummy_box.Text = TXT_LIQUID_TEMP.Text
      txt_dummy_box.SelectionStart = 0
      txt_dummy_box.SelectionLength = 1
      DATE_PP1 = txt_dummy_box.SelectedText
      txt_dummy_box.SelectionStart = 1
      txt_dummy_box.SelectionLength = 6
      DATE_PP2 = txt_dummy_box.SelectedText

      If DATE_PP1 = "-" Then
         TEMP_HOLDING = Trim(DATE_PP2)
         MyCheck = IsNumeric(TEMP_HOLDING) ' Returns True.
      Else
         TEMP_HOLDING = Trim(TXT_LIQUID_TEMP.Text)
         MyCheck = IsNumeric(TEMP_HOLDING) ' Returns True.
      End If

      If MyCheck = True Then
      Else
         If DATE_PP1 = "-" Then
         Else
            TXT_LIQUID_TEMP.Text = CStr(0)
            TXT_LIQUID_TEMP.Focus()
            TXT_LIQUID_TEMP.SelectionStart = 0
            TXT_LIQUID_TEMP.SelectionLength = Len(TXT_LIQUID_TEMP.Text)
         End If
      End If
   End Sub

   Private Sub TXT_LWB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TXT_LWB.TextChanged
      CLEAR_COIL_WEIGHT_LABEL()
      txt_dummy_box.Text = TXT_LWB.Text
      txt_dummy_box.SelectionStart = 0
      txt_dummy_box.SelectionLength = 1
      DATE_PP1 = txt_dummy_box.SelectedText
      txt_dummy_box.SelectionStart = 1
      txt_dummy_box.SelectionLength = 6
      DATE_PP2 = txt_dummy_box.SelectedText

      If DATE_PP1 = "-" Then
         TEMP_HOLDING = Trim(DATE_PP2)
         MyCheck = IsNumeric(TEMP_HOLDING) ' Returns True.
      Else
         TEMP_HOLDING = Trim(TXT_LWB.Text)
         MyCheck = IsNumeric(TEMP_HOLDING) ' Returns True.
      End If

      If MyCheck = True Then
      Else
         If DATE_PP1 = "-" Then
         Else
            TXT_LWB.Text = CStr(0)
            TXT_LWB.Focus()
            TXT_LWB.SelectionStart = 0
            TXT_LWB.SelectionLength = Len(TXT_LWB.Text)
         End If
      End If

      If TXT_LWB.Text <= "       " Then
         TXT_LWB.Text = "0"
      End If

      If CDbl(TXT_LWB.Text) > 0 Then
         TXT_TH.Visible = False
         TXT_TH.Text = CStr(0)
         TXT_SH.Visible = False
         TXT_SH.Text = CStr(0)
      Else
         TXT_TH.Visible = True
         TXT_SH.Visible = True
      End If
   End Sub

   Private Sub TXT_MBH_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TXT_MBH.TextChanged
      CLEAR_COIL_WEIGHT_LABEL()
      txt_dummy_box.Text = TXT_MBH.Text
      txt_dummy_box.SelectionStart = 0
      txt_dummy_box.SelectionLength = 1
      DATE_PP1 = txt_dummy_box.SelectedText
      txt_dummy_box.SelectionStart = 1
      txt_dummy_box.SelectionLength = 6
      DATE_PP2 = txt_dummy_box.SelectedText

      If DATE_PP1 = "-" Then
         TEMP_HOLDING = Trim(DATE_PP2)
         MyCheck = IsNumeric(TEMP_HOLDING) ' Returns True.
      Else
         TEMP_HOLDING = Trim(TXT_MBH.Text)
         MyCheck = IsNumeric(TEMP_HOLDING) ' Returns True.
      End If

      If MyCheck = True Then
      Else
         If DATE_PP1 = "-" Then
         Else
            TXT_MBH.Text = CStr(0)
            TXT_MBH.Focus()
            TXT_MBH.SelectionStart = 0
            TXT_MBH.SelectionLength = Len(TXT_MBH.Text)
         End If
      End If
   End Sub

   Private Sub TXT_SH_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TXT_SH.TextChanged
      CLEAR_COIL_WEIGHT_LABEL()
      TEMP_HOLDING = Trim(TXT_SH.Text)
      MyCheck = IsNumeric(TEMP_HOLDING) ' Returns True.
      If MyCheck = True Then
      Else
         TXT_SH.Text = CStr(0)
         TXT_SH.Focus()
         TXT_SH.SelectionStart = 0
         TXT_SH.SelectionLength = Len(TXT_SH.Text)
      End If

      If CDbl(TXT_SH.Text) > 0 Then
         TXT_LDB.Visible = False
         TXT_LDB.Text = CStr(0)
         TXT_LWB.Visible = False
         TXT_LWB.Text = CStr(0)
      Else
         TXT_LDB.Visible = True
         TXT_LWB.Visible = True
      End If
   End Sub

   Private Sub TXT_STMP_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TXT_STMP.TextChanged
      CLEAR_COIL_WEIGHT_LABEL()
   End Sub

   Private Sub TXT_SUCTION_TEMP_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TXT_SUCTION_TEMP.TextChanged
      CLEAR_COIL_WEIGHT_LABEL()
      txt_dummy_box.Text = TXT_SUCTION_TEMP.Text
      txt_dummy_box.SelectionStart = 0
      txt_dummy_box.SelectionLength = 1
      DATE_PP1 = txt_dummy_box.SelectedText
      txt_dummy_box.SelectionStart = 1
      txt_dummy_box.SelectionLength = 6
      DATE_PP2 = txt_dummy_box.SelectedText

      If DATE_PP1 = "-" Then
         TEMP_HOLDING = Trim(DATE_PP2)
         MyCheck = IsNumeric(TEMP_HOLDING) ' Returns True.
      Else
         TEMP_HOLDING = Trim(TXT_SUCTION_TEMP.Text)
         MyCheck = IsNumeric(TEMP_HOLDING) ' Returns True.
      End If

      If MyCheck = True Then
      Else
         If DATE_PP1 = "-" Then
         Else
            TXT_SUCTION_TEMP.Text = CStr(0)
            TXT_SUCTION_TEMP.Focus()
            TXT_SUCTION_TEMP.SelectionStart = 0
            TXT_SUCTION_TEMP.SelectionLength = Len(TXT_SUCTION_TEMP.Text)
         End If
      End If
   End Sub

   Private Sub TXT_TH_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TXT_TH.TextChanged
      CLEAR_COIL_WEIGHT_LABEL()
      TEMP_HOLDING = Trim(TXT_TH.Text)
      MyCheck = IsNumeric(TEMP_HOLDING) ' Returns True.
      If MyCheck = True Then
      Else
         TXT_TH.Text = CStr(0)
         TXT_TH.Focus()
         TXT_TH.SelectionStart = 0
         TXT_TH.SelectionLength = Len(TXT_TH.Text)
      End If

      If CDbl(TXT_TH.Text) > 0 Then
         TXT_LDB.Visible = False
         TXT_LDB.Text = CStr(0)
         TXT_LWB.Visible = False
         TXT_LWB.Text = CStr(0)
      Else
         TXT_LDB.Visible = True
         TXT_LWB.Visible = True
      End If

   End Sub

   Private Sub TXT_TUBEMATL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TXT_TUBEMATL.Click
      CLEAR_COIL_WEIGHT_LABEL()
   End Sub

   Private Sub TXT_WTD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TXT_WTD.TextChanged
      If Not IsNumeric(TXT_WTD.Text) Then
         TXT_WTD.Text = "0"
      End If
   End Sub

   'Private Sub WTDChanged()
   '   CLEAR_COIL_WEIGHT_LABEL()
   '   If TXT_WTD.Text <= "       " Then
   '      TXT_WTD.Text = "0"
   '   End If

   '   If CDbl(TXT_WTD.Text) > 0 Then
   '      TXT_GPM.Enabled = False
   '      TXT_GPM.Text = CStr(0)
   '      rbGPM.Checked = False
   '      rbWTD.Checked = True
   '   Else
   '      TXT_GPM.Enabled = True
   '      rbGPM.Checked = True
   '      rbWTD.Checked = False
   '   End If
   '   NeedReCalc()
   'End Sub

   Private Sub SET_CBO_SERP2()
      If CBO_SERP.Text = "OTHER-SPECIAL CIRCUITING" Or CBO_SERP.Text = "TWO TUBE FEED NO HEADERS" Or CBO_SERP.Text = "ONE TUBE FEED NO HEADERS" Then
         SET_CBO_SERP_SPECIAL()
      End If
   End Sub

   Private Sub SET_CBO_FLUIDTYPE2()

      If CBO_FLUIDTYPE.Text = "PG" Or CBO_FLUIDTYPE.Text = "EG" Or CBO_FLUIDTYPE.Text = "WTR" Then
         C_FLUID = UCase(CBO_FLUIDTYPE.Text)
      End If

      CLEAR_COIL_WEIGHT_LABEL()

      If CBO_FLUIDTYPE.Text = "PG" Or CBO_FLUIDTYPE.Text = "EG" Then
         TXT_PERCONC.Visible = True
         Label22.Visible = True
      Else
         TXT_PERCONC.Visible = False
         Label22.Visible = False
      End If

      If CBO_FLUIDTYPE.Text = "OTHER" Then
         TITLE = "Fluid Type"
         defval = C_FLUID
         msg = "Enter fluid type: "
         C_FLUID = InputBox(msg, TITLE, defval)
         ToolTip1.SetToolTip(CBO_FLUIDTYPE, C_FLUID)
         VB6.ShowForm(New frm_Gas, VB6.FormShowConstants.Modal, Me)
      End If
   End Sub

   Private Sub CALL_HELP()
      Dim lResult As Integer
      Dim sHelpFile As String
      Dim lCommand, lOption As Integer
      sHelpFile = My.Application.Info.DirectoryPath & "\Coils.hlp"
      lCommand = HELP_CONTENTS
      lOption = 0
      lResult = WinHelp(Me.Handle.ToInt32, sHelpFile, lCommand, lOption)
   End Sub

   Private Sub ERROR_ARRAYS()
      RAE_Out_Input_error_text(100) = "FINS PER INCH OUT OF RANGE (4 FPI THRU 14 FPI)."
      RAE_Out_Input_error_text(101) = "Rating or Selection not selected."
      RAE_Out_Input_error_text(102) = "Steam pressure is missing must be > 0" 'Updated 12/6/1999 D.Groom changed
      RAE_Out_Input_error_text(103) = "Circuiting out of range (0 to 2). "
      RAE_Out_Input_error_text(104) = "Rows deep out of range (1 to 24)"
      RAE_Out_Input_error_text(106) = "Rows deep for selection should be zero."
      RAE_Out_Input_error_text(105) = "Coil Size missing 12, 58 or 11"
      RAE_Out_Input_error_text(107) = "Fluid Hot or Cold is missing" 'Updated 12/3/1999 D.Groom new line
      RAE_Out_Input_error_text(108) = "Water Coil Sizes 12, 58 Allowed" 'Updated 12/3/1999 D.Groom new line
      RAE_Out_Input_error_text(109) = "Steam Coil Size 58 Allowed" 'Updated 12/3/1999 D.Groom new line
      RAE_Out_Input_error_text(110) = "Steam Distribution Coil Sizes 58, 11 Allowed" 'Updated 12/3/1999 D.Groom new line
      RAE_Out_Input_error_text(111) = "DX Coil Sizes 12, 58 Allowed" 'Updated 12/3/1999 D.Groom new line
      RAE_Out_Input_error_text(112) = "% GLYCOL Range 10 to 60" 'Updated 12/3/1999 D.Groom new line
      RAE_Out_Input_error_text(113) = "Coil Types W, D, S or SD Allowed" 'Updated 12/3/1999 D.Groom new line
      RAE_Out_Input_error_text(114) = "Incorrect Coil Fin Height 6""" & " thru " & "96""" & " allowed"

      RAE_Out_Input_error_text(115) = "Alum fin = AL and Copper fin = CU" 'Updated 12/4/1999 D.Groom new line
      RAE_Out_Input_error_text(116) = "Fin Thickness = .006 / .008 / .010" 'Updated 12/4/1999 D.Groom new line
      RAE_Out_Input_error_text(117) = "Tube Material = CU" 'Updated 12/4/1999 D.Groom new line
      RAE_Out_Input_error_text(118) = "1/2""" & " Tube Thickness = .017 / .025 / .032" 'Updated 12/4/1999 D.Groom new line
      RAE_Out_Input_error_text(119) = "5/8""" & " Tube Thickness = .020 / .025 / .035 / .049" 'Updated 12/6/1999 D.Groom new line
      RAE_Out_Input_error_text(120) = "1""" & "Tube Thickness = .035 / .049" 'Updated 12/6/1999 D.Groom new line
      RAE_Out_Input_error_text(121) = "Left Hand Coil = L / Right Hand Coil = R" 'Updated 12/6/1999 D.Groom new line
      RAE_Out_Input_error_text(122) = "Fin Type = W" 'Updated 12/6/1999 D.Groom new line
      RAE_Out_Input_error_text(123) = "RAE Fin Length = 6 to 300 inches" 'Updated 12/6/1999 D.Groom new line
      RAE_Out_Input_error_text(124) = "CFM can not be <= 0" 'Updated 12/7/1999 D.Groom new line
      RAE_Out_Input_error_text(125) = "Both (GPM) and (Fluid Temp. Diff.) can not = 0" 'Updated 12/7/1999 D.Groom new line
      RAE_Out_Input_error_text(126) = "Fluid type missing WTR, EG and PG" 'Updated 12/7/1999 D.Groom new line
      RAE_Out_Input_error_text(127) = "1""" & " Steam Dist. only one Row coils allowed" 'Updated 12/7/1999 D.Groom new line
      RAE_Out_Input_error_text(128) = "5/8""" & " Steam Dist. one and two Row coils allowed" 'Updated 12/7/1999 D.Groom new line
      RAE_Out_Input_error_text(129) = "5/8""" & " Std. Steam one, two or three Row coils allowed" 'Updated 12/7/1999 D.Groom new line
      RAE_Out_Input_error_text(130) = "1/2""" & " Std. Steam coils not allowed" 'Updated 12/7/1999 D.Groom new line
      RAE_Out_Input_error_text(131) = "1""" & " Std. Steam coils not allowed" 'Updated 12/7/1999 D.Groom new line

   End Sub

   Private Sub clear_output_var()
      RAE_Out_Surf_Area = 0
      RAE_Out_Opp_End_Conn = ""
      RAE_Out_LDB1 = 0
      RAE_Out_LDB2 = 0
      RAE_Out_LDB3 = 0
      RAE_Out_LWB1 = 0
      RAE_Out_LWB2 = 0
      RAE_Out_LWB3 = 0
      RAE_Out_Total_HT1 = 0
      RAE_Out_Total_HT2 = 0
      RAE_Out_Total_HT3 = 0
      RAE_Out_Sens_HT1 = 0
      RAE_Out_Sens_HT2 = 0
      RAE_Out_Sens_HT3 = 0
      RAE_Out_LWT1 = 0
      RAE_Out_LWT2 = 0
      RAE_Out_LWT3 = 0
      RAE_Out_GPM1 = 0
      RAE_Out_GPM2 = 0
      RAE_Out_GPM3 = 0
      RAE_Out_Water_Vel1 = 0
      RAE_Out_Water_Vel2 = 0
      RAE_Out_Water_Vel3 = 0
      RAE_Out_ERROR_MSG1 = 0
      RAE_Out_ERROR_MSG2 = 0
      RAE_Out_ERROR_MSG3 = 0
      RAE_Out_Fluid_PD1 = 0
      RAE_Out_Fluid_PD2 = 0
      RAE_Out_Fluid_PD3 = 0
      RAE_Out_No_of_Circuits1 = 0
      RAE_Out_No_of_Circuits2 = 0
      RAE_Out_No_of_Circuits3 = 0
      RAE_Out_Air_Press_Drop1 = 0
      RAE_Out_Air_Press_Drop2 = 0
      RAE_Out_Air_Press_Drop3 = 0
      RAE_Out_Connections1 = 0
      RAE_Out_Connections2 = 0
      RAE_Out_Connections3 = 0
      RAE_Out_FPI1 = 0
      RAE_Out_FPI2 = 0
      RAE_Out_FPI3 = 0
      RAE_Out_ROWS1 = 0
      RAE_Out_ROWS2 = 0
      RAE_Out_ROWS3 = 0
      RAE_Out_CIRCUITING1 = ""
      RAE_Out_CIRCUITING2 = ""
      RAE_Out_CIRCUITING3 = ""
      RAE_Out_SELECTION1 = ""
      RAE_Out_SELECTION2 = ""
      RAE_Out_SELECTION3 = ""
      RAE_Out_ARI_MSG1 = ""
      RAE_Out_ARI_MSG2 = ""
      RAE_Out_ARI_MSG3 = ""
      RAE_Out_Steam_Temp = 0
      RAE_Steam_Pressure = 0
      RAE_Suction = 0
      RAE_liquid = 0
      RAE_Out_DLL_loop_Error = 0
      RAE_Out_Refg_pres_drop1 = 0
      RAE_Out_Refg_pres_drop2 = 0
      RAE_Out_Refg_pres_drop3 = 0
      RAE_Out_Circuit_load1 = 0
      RAE_Out_Circuit_load2 = 0
      RAE_Out_Circuit_load3 = 0
      RAE_Out_Connections_Steam1 = ""
      RAE_Out_Connections_Steam2 = ""
      RAE_Out_Connections_Steam3 = ""
      RAE_Out_Input_error1 = 0
      RAE_Out_Input_error2 = 0
      RAE_Out_Input_error3 = 0
      RAE_Out_Input_error4 = 0
      RAE_Out_Input_error5 = 0
      RAE_Out_Input_error6 = 0
      RAE_Out_Input_error7 = 0
      RAE_Out_Input_error8 = 0
      RAE_Out_Input_error9 = 0
   End Sub

   Private Sub CALL_WATER_HOT_OR_COLD_PRINTING()
      Dim strFL As String = String.Empty
      If Me.CBO_FLUIDTYPE.Text = "WTR" Then
         strFL = "Water"
      Else
         strFL = "Glycol"
      End If

      Dim strCM As String = "Ethylene"
      If Me.CBO_FLUIDTYPE.Text = "PG" Then
         strCM = "Propylene"
      End If
      
      Dim glycolPercentage As Double = Val(Me.TXT_PERCONC.Text)
      
      'Dim ChillyRAE_Parms As New RAEDLL_CONDENSING_UNIT.Selection_Mod
      Dim sg As Double = 0
      Dim sh As Double = 0

      

      Dim fp As Double = 0
      Dim SuctionTemp As Double = 0
      ' sets freezing point and suction temperature textboxes
      If strFL = "Water" Then
         ' sets freeze point textbox to water's freezing point
         fp = Rae.RaeSolutions.Business.Intelligence.Chillers.FreezingPoint.FreezingPointForWater
         ' sets recommended minimum suction temperature textbox to water's recommended minimum suction temperature
         SuctionTemp = Rae.RaeSolutions.Business.Intelligence.Chillers.FreezingPoint.RecommendedMinSuctionTemperatureForWater

      Else
         ' parses selected combobox item to glycol
         Dim glycol = DirectCast(System.Enum.Parse(GetType(Rae.Solutions.Chillers.Glycol), strCM), Rae.Solutions.Chillers.Glycol)

         ' constructs new freezing point using selected glycol and glycol percentage
         fp = New Rae.RaeSolutions.Business.Intelligence.Chillers.FreezingPoint(glycol, glycolPercentage).FreezingPoint
      End If
      Dim fluid As StandardRefrigeration.Fluid
      Rae.Io.Text.GetEnumValue(strCM, fluid)

      Dim specific = New StandardRefrigeration.Specific(fluid, glycolPercentage, TXT_EWT.Text, RAE_Out_LWT1)
      sh = specific.Heat
      sg = specific.Gravity
      
      'With ChillyRAE_Parms
      '   ' pass data
      '   .RAE_ChillyRAEs_pass = 1        '1 = Parms    2 = Models    3 = 8&10 deg approach
      '   .RAE_Fouling_Factor = Val(Me.TXT_FFI.Text)
      '   .RAE_Cbo_Fluid = strFL
      '   .RAE_tempin = Val(Me.TXT_EWT.Text)
      '   .RAE_tempot = Round(RAE_Out_LWT1, 2)
      '   .RAE_txtCondCap = 0 'Me.GrabSystemCapacityBtuh()
      '   .RAE_cboRef_Text = Refrigerant.Name
      '   .RAE_cboCCM_Text = strCM
      '   .RAE_txtPctGly_Text = glycolPercentage
      '   .RAE_conduc = 0
      '   .RAE_visc = 0
      '   .RAE_spht = 0 'VB.Val(Me.txtSpecificHeat.Text)
      '   .RAE_allmod = "all"
      '   .RAE_units = "U.S. UNIT"     'METRIC
      '   .RAE_cbo_chillers_Text = "" 'standardModel 'Trim(TxtChiller.Text())
      '   .RAE_txtSpGr = 0        'Val(Txtspgr.Text())
      '   .AddToDatabase5()

      '   'get data
      '   sh = Val(.RAE_Out_txtSpHt_Text) 'get specific heat         
      '   sg = Val(.RAE_Out_txtSpGr_Text) 'get specific gravity
      'End With

      Dim q As Double = (500 * sg * sh * Round(RAE_Out_GPM1, 2) * (Val(Me.TXT_EWT.Text) - Round(RAE_Out_LWT1, 2))) / 1000

      Dim tbl As New DataTable
      tbl.Columns.Add("EDB")
      tbl.Columns.Add("EFT")
      tbl.Columns.Add("LFT")
      tbl.Columns.Add("MBH")
      tbl.Columns.Add("GPM")
      tbl.Columns.Add("PD")
      tbl.Columns.Add("Circ.")

      Dim dr As DataRow = tbl.NewRow
      dr("EDB") = Val(Me.TXT_EDB.Text)
      dr("EFT") = Val(Me.TXT_EWT.Text)
      dr("LFT") = Round(RAE_Out_LWT1, 2)
      dr("MBH") = Round(q, 2)
      dr("GPM") = Round(RAE_Out_GPM1, 2)
      dr("PD") = Round(RAE_Out_Fluid_PD1, 3)
      dr("Circ.") = fcCoil.Circuiting.FluidCoolerCircuitingValue
      tbl.Rows.Add(dr)

      'tbl.Columns.Add("Name")
      'tbl.Columns.Add("Value")

      'Dim dr As DataRow = tbl.NewRow
      'dr("Name") = "LEAVING DRY BULB"
      'dr("Value") = Round(RAE_Out_LDB1, 2)
      'tbl.Rows.Add(dr)

      'dr = tbl.NewRow
      'dr("Name") = "LEAVING WET BULB"
      'dr("Value") = Round(RAE_Out_LWB1, 2)
      'tbl.Rows.Add(dr)

      'dr = tbl.NewRow
      'dr("Name") = "TOTAL HT"
      'dr("Value") = Round(RAE_Out_Total_HT1, 2)
      'tbl.Rows.Add(dr)

      'dr = tbl.NewRow
      'dr("Name") = "SENS HT"
      'dr("Value") = Round(RAE_Out_Sens_HT1, 2)
      'tbl.Rows.Add(dr)

      'dr = tbl.NewRow
      'dr("Name") = "LEAVING WT"
      'dr("Value") = Round(RAE_Out_Total_HT1, 2)
      'tbl.Rows.Add(dr)

      'dgReport.DataSource = tbl
      'FormatResultsGrid()

      'dr = tbl.NewRow
      'dr("Name") = "TOTAL HT"
      'dr("Value") = Round(RAE_Out_LWT1, 2)
      'tbl.Rows.Add(dr)

      'dr = tbl.NewRow
      'dr("Name") = "TOTAL HT"
      'dr("Value") = Round(RAE_Out_Total_HT1, 2)
      'tbl.Rows.Add(dr)

      'dr = tbl.NewRow
      'dr("Name") = "TOTAL HT"
      'dr("Value") = Round(RAE_Out_Total_HT1, 2)
      'tbl.Rows.Add(dr)

      'dr = tbl.NewRow
      'dr("Name") = "TOTAL HT"
      'dr("Value") = Round(RAE_Out_Total_HT1, 2)
      'tbl.Rows.Add(dr)

      'dr = tbl.NewRow
      'dr("Name") = "TOTAL HT"
      'dr("Value") = Round(RAE_Out_Total_HT1, 2)
      'tbl.Rows.Add(dr)

      'dr = tbl.NewRow
      'dr("Name") = "TOTAL HT"
      'dr("Value") = Round(RAE_Out_Total_HT1, 2)
      'tbl.Rows.Add(dr)

      'dr = tbl.NewRow
      'dr("Name") = "TOTAL HT"
      'dr("Value") = Round(RAE_Out_Total_HT1, 2)
      'tbl.Rows.Add(dr)

      'If CBO_FLUIDTYPE.Text = "WTR" Then 'Added 4/28/2006
      '    If Round(RAE_Out_LDB1, 1) < 33 Then
      '        MsgBox("PLEASE CONTACT FACTORY FOR THIS SELECTION.")
      '        Exit Sub
      '    End If

      '    If RAE_Choice = "S" Then
      '        If Round(RAE_Out_LDB2, 1) < 33 Then
      '            MsgBox("PLEASE CONTACT FACTORY FOR THIS SELECTION.")
      '            Exit Sub
      '        End If
      '    End If
      'End If

      'If CBO_FLUIDTYPE.Text = "WTR" Then 'WTR, EG, PG
      '    print_msg = "   WATER   (RAESelRatingCore.dll)   Output"
      'End If
      'If CBO_FLUIDTYPE.Text = "EG" Then 'WTR, EG, PG
      '    print_msg = "   ETHYLENE GLYCOL   (RAESelRatingCore.dll)   Output"
      'End If
      'If CBO_FLUIDTYPE.Text = "PG" Then 'WTR, EG, PG
      '    print_msg = "   PROPYLENE GLYCOL   (RAESelRatingCore.dll)   Output"
      'End If
      'print_msg = print_msg & Chr(10) & ""

      'If RAE_Choice = "R" Then
      '    print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_LDB1, 2) & "  LEAVING DRY BULB"
      'Else
      '    print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_LDB1, 2) & "    Selection2 = " & Round(RAE_Out_LDB2, 2) & "  LEAVING DRY BULB"
      'End If

      'If RAE_Choice = "R" Then
      '    print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_LWB1, 2) & "  LEAVING WET BULB"
      'Else
      '    print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_LWB1, 2) & "    Selection2 = " & Round(RAE_Out_LWB2, 2) & "  LEAVING WET BULB"
      'End If

      'If RAE_Choice = "R" Then
      '    print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_Total_HT1, 2) & "  TOTAL HT"
      'Else
      '    print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_Total_HT1, 2) & "    Selection2 = " & Round(RAE_Out_Total_HT2, 2) & "  TOTAL HT"
      'End If

      'If RAE_Choice = "R" Then
      '    print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_Sens_HT1, 2) & "  SENS HT"
      'Else
      '    print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_Sens_HT1, 2) & "    Selection2 = " & Round(RAE_Out_Sens_HT2, 2) & "  SENS HT"
      'End If

      'If RAE_Choice = "R" Then
      '    print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_LWT1, 2) & "  LEAVING WT"
      'Else
      '    print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_LWT1, 2) & "    Selection2 = " & Round(RAE_Out_LWT2, 2) & "  LEAVING WT"
      'End If

      'If RAE_Choice = "R" Then
      '    print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_GPM1, 2) & "  GPM"
      'Else
      '    print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_GPM1, 2) & "    Selection2 = " & Round(RAE_Out_GPM2, 2) & "  GPM"
      'End If

      'If RAE_Choice = "R" Then
      '    print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_Water_Vel1, 3) & "  FLUID VEL"
      'Else
      '    print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_Water_Vel1, 3) & "    Selection2 = " & Round(RAE_Out_Water_Vel2, 3) & "  FLUID VEL"
      'End If

      'If RAE_Choice = "R" Then
      '    print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_Fluid_PD1, 3) & "  FLUID PD, FT"
      'Else
      '    print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_Fluid_PD1, 3) & "    Selection2 = " & Round(RAE_Out_Fluid_PD2, 3) & "  FLUID PD, FT"
      'End If

      'If RAE_Choice = "R" Then
      '    print_msg = print_msg & Chr(10) & "Selection1 = " & RAE_Out_No_of_Circuits1 & "  NUMBER OF CIRCUITS"
      'Else
      '    print_msg = print_msg & Chr(10) & "Selection1 = " & RAE_Out_No_of_Circuits1 & "    Selection2 = " & RAE_Out_No_of_Circuits2 & "  NUMBER OF CIRCUITS"
      'End If

      'If RAE_Choice = "R" Then
      '    print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_Air_Press_Drop1, 3) & "  AIR PRESSURE DROP"
      'Else
      '    print_msg = print_msg & Chr(10) & "Selection1 = " & Round(RAE_Out_Air_Press_Drop1, 3) & "    Selection2 = " & Round(RAE_Out_Air_Press_Drop2, 3) & "  AIR PRESSURE DROP"
      'End If

      'If RAE_Choice = "R" Then
      '    print_msg = print_msg & Chr(10) & "Selection1 = " & RAE_Out_Connections1 & "  CONNECTIONS"
      'Else
      '    print_msg = print_msg & Chr(10) & "Selection1 = " & RAE_Out_Connections1 & "    Selection2 = " & RAE_Out_Connections2 & "  CONNECTIONS"
      'End If

      'print_msg = print_msg & Chr(10) & "(SELECTION 1)    " & RAE_Out_SELECTION1
      'If RAE_Choice = "S" Then
      '    print_msg = print_msg & Chr(10) & "(SELECTION 2)    " & RAE_Out_SELECTION2
      'End If

      ''************add weight output************Danny Groom 12/11/2000
      'print_msg = print_msg & Chr(10) & "(COIL WEIGHT 1) = " & COIL_WEIGHT1 & " lbs."
      'If RAE_Choice = "S" Then
      '    print_msg = print_msg & Chr(10) & "(COIL WEIGHT 2) = " & COIL_WEIGHT2 & " lbs."
      'End If
      ''*************************

      'print_msg = print_msg & Chr(10) & RAE_Out_Opp_End_Conn


      'print_msg = print_msg & Chr(10) & RAE_Out_ARI_MSG1
      'print_msg = print_msg & Chr(10) & RAE_Out_ARI_MSG2
      'print_msg = print_msg & Chr(10) & RAE_Out_ARI_MSG3

      'msg = print_msg
      'STYLE = CStr(MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) ' Define buttons.
      'TITLE = "PRINT SCREEN ?"
      'RESPONSE = CStr(MsgBox(msg, CDbl(STYLE), TITLE))
   End Sub

   Private Sub FormatResultsGrid()

      Dim W As Integer = Me.Width
      Dim wx As Integer = 630
      For c As Integer = 0 To dgvReport.ColumnCount - 1
         Dim col As DataGridViewColumn = dgvReport.Columns(c)
         col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter
         col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
         col.ValueType = System.Type.GetType("System.String")
         Select Case c
            Case 0
               col.Width = CInt((85 / wx) * W)
               col.HeaderText = "Entering" & vbCrLf & "Dry Bulb" & vbCrLf & "(" & Chr(176) & "F)"
            Case 1
               col.Width = CInt((85 / wx) * W)
               col.HeaderText = "Entering" & vbCrLf & "Fluid Temp" & vbCrLf & "(" & Chr(176) & "F)"
            Case 2
               col.Width = CInt((85 / wx) * W)
               col.HeaderText = "Leaving" & vbCrLf & "Fluid Temp" & vbCrLf & "(" & Chr(176) & "F)"
            Case 3
               col.Width = CInt((60 / wx) * W)
               col.HeaderText = "FPI"
            Case 4
               col.Width = CInt((75 / wx) * W)
                    col.HeaderText = "Est. Capacity" & vbCrLf & "(MBH)"
            Case 5
               col.Width = CInt((65 / wx) * W)
               col.HeaderText = "Flow" & vbCrLf & "(GPM)"
            Case 6
               col.Width = CInt((65 / wx) * W)
               col.HeaderText = "Fluid PD"
            Case 7
               col.Width = CInt((75 / wx) * W)
               col.HeaderText = "Circuiting"
            Case 8
               col.HeaderText = String.Empty
               col.Width = CInt((15 / wx) * W)
         End Select
      Next

      dgvReport.Visible = True
      dgvReport.Height = dgvReport.Columns(0).HeaderCell.Size.Height + (dgvReport.Rows(0).Cells(0).Size.Height * ResultsTable.Rows.Count) + 20
      'dgvReport.Height = 30 * (ResultsTable.Rows.Count + 1) + 5
      'pnlBottom.Height = dgvReport.Height + Panel1.Height + 5


      'Rae.Ui.C1GridStyles.BasicGridStyle(Me.dgReport)

      'dgReport.BorderStyle = BorderStyle.None
      'With Me.dgReport.Splits(0)
      '   ' sets column properties
      '   .ColumnCaptionHeight = 0 '36
      '   .HeadingStyle.BackColor = ColorManager.LightBlue

      '   .OddRowStyle.BackColor = ColorManager.LighterBlue
      '   .Style.Borders.Color = ColorManager.GreyBlue
      '   For i As Integer = 0 To .DisplayColumns.Count - 1
      '      .DisplayColumns(i).ColumnDivider.Color = ColorManager.GreyBlue
      '      .DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
      '      Select Case i
      '         Case 0
      '            '.DisplayColumns(i).
      '         Case 1

      '         Case 2

      '         Case 3

      '         Case 4

      '         Case 5

      '         Case 6

      '         Case 7

      '      End Select
      '      .DisplayColumns(i).Width = 65
      '   Next
      'End With
      'dgReport.ClientSize = New Size(620, (dgReport.RowCount + 1) * dgReport.RowHeight + 5)
      'dgReport.Location = New Point(20, 0)
   End Sub

   Public Sub CLEAR_COIL_WEIGHT_LABEL()
      COIL_WEIGHT_LABEL.Text = "Est. Coil Weight ~ lbs."
   End Sub

   Public Sub coiltype_sub()
      SET_SCREEN_WATER()
      SET_TOOL_TIP_TEXT()
   End Sub

   Private Sub cboSeries_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSeries.SelectedIndexChanged
      Dim fan As FluidCoolerFan
      Dim fcs As FluidCoolerSeries
      If cboSeries.SelectedValue.GetType().Name = "FluidCoolerSeries" Then
         fcs = CType(cboSeries.SelectedItem, FluidCoolerSeries)
      Else
         Try
            Dim fcsID As Integer = CInt(Val(cboSeries.SelectedValue))
            fcs = FluidCoolerSeries.Populate(fcsID)
         Catch ex As Exception
            Exit Sub
         End Try
      End If
      fan = FluidCoolerFan.Populate(fcs.FluidCoolerSeriesID, True)
      Me.lblFanQuantity.Text = fcs.FanQuantity.ToString()
      SetCombobox(cboFanDescription, fan, "Description")
      cboModels.DataSource = FluidCooler.Populate(fcs)
      cboModels.DisplayMember = "ModelNumber" '"ModelName"
      'SetDiameters()
      'cbodiam
   End Sub

   Private Sub SetDiameters()
      cboDiameter.DataSource = Utility.Hash2DataTable(Coil.Diameters(Coil.CoilModes.Rae, fcCoil.CoilApplication))
      cboDiameter.DisplayMember = "Key"
      cboDiameter.ValueMember = "Value"
   End Sub

   Private Sub cboModels_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboModels.SelectedIndexChanged
      fc = CType(cboModels.SelectedItem, FluidCooler)
      fc.FluidCoolerSeries = CType(cboSeries.SelectedItem, FluidCoolerSeries)
      'fc.SetFluidCoolerSeries(CType(cboSeries.SelectedItem, FluidCoolerSeries))
      lblDimensions.Text = fc.Dimensions
      Me.lblCoilQuantity.Text = fc.CoilQuantity.ToString()
      fcCoil = fc.Coils(0)
      fcCoil.Diameter = 0.625
      'fcCoil.NumRows = fc.Coils(0).Rows
      'fcCoil.FPI = fc.Coils(0).FPI
      _fpi = fcCoil.FPI
      Dim l As New List(Of FluidCoolerCircuiting)
      l.Add(fc.Coils(0).CircuitA)
      l.Add(fc.Coils(0).CircuitB)
      CBO_SERP.DataSource = l
      CBO_SERP.DisplayMember = "FluidCoolerCircuitingText"
      'fcCoil.Circuiting = fc.Coils(0).CircuitA
      'fcCoil.FinHeight = fc.Coils(0).Height
      'fcCoil.FinLength = fc.Coils(0).Width
      CoilSet()
      'SetCombobox(cboFanDescription, fc.Fans(0), "Description")
   End Sub

   Private Sub CoilSet()
      If fcCoil.FPI > 0 Then
         LoadFPI()
         'SetCombobox(Me.Cbo_fpi, fcCoil.FPI)
      End If
      If fcCoil.NumRows > 0 Then
         SetCombobox(Me.Cbo_rows, fcCoil.NumRows)
      End If
      If fcCoil.Circuiting.FluidCoolerCircuitingID > 0 Then
         SetCombobox(CBO_SERP, fcCoil.Circuiting, "FluidCoolerCircuitingText")
      End If
      lblCoilUseType.Text = fcCoil.CoilUseType.ToString()
      lblCoilApplication.Text = fcCoil.CoilApplication
      'SetCombobox(Me.CBO_FINMATL, fcCoil.FinMaterial)
      'SetCombobox(Me.CBO_FINTHICKNESS, fcCoil.FinThickness)
      'SetCombobox(Me.CBO_TUBEMATL_KING, fcCoil.TubeMaterial)
      'SetCombobox(Me.CBO_TUBETHICKNESS, fcCoil.TubeThickness)
      SetCombobox(cboDiameter, fcCoil.Diameter)
      SetCombobox(cboHeight, fcCoil.FinHeight)
      SetCombobox(cboLength, fcCoil.FinLength)
      CoilChanged()
   End Sub

   Private Sub SetFileName()
      Dim str As String = String.Empty
      If fcCoil.CoilApplication = Coil.CoilType.Condenser Then
         If fcCoil.Diameter = 0.625 Then
            str = fcCoil.NumRows.ToString() & "RCOND.58"
         ElseIf fcCoil.Diameter = 0.5 Then
            str = fcCoil.NumRows.ToString() & "RCOND"
         End If
      Else
         If fcCoil.Diameter = 0.625 Then
            If fcCoil.FinDesign = Coil.FinType.Waffle Then
               str = fcCoil.NumRows.ToString() & "REVAP.58W"
            Else
               str = fcCoil.NumRows.ToString() & "REVAP.58"
            End If
         ElseIf fcCoil.Diameter = 0.5 Then
            If fcCoil.FinDesign = Coil.FinType.Waffle Then
               str = fcCoil.NumRows.ToString() & "REVAP.12W"
            Else
               str = fcCoil.NumRows.ToString() & "REVAP.12"
            End If
         End If
      End If
      fcCoil.FileName = str
   End Sub

   Private Sub SetCombobox(ByRef cbo As ComboBox, ByVal value As Object, Optional ByVal strProp As String = "")
      For i As Integer = 0 To cbo.Items.Count - 1
         If strProp.Length > 0 AndAlso (value.GetType().Namespace = "System" AndAlso cbo.Items(i).GetType().GetProperty(strProp).GetValue(cbo.Items(i), Nothing) = value) Then
            cbo.SelectedIndex = i
         ElseIf strProp.Length > 0 AndAlso (value.GetType().Namespace <> "System" AndAlso cbo.Items(i).GetType().GetProperty(strProp).GetValue(cbo.Items(i), Nothing) = value.GetType().GetProperty(strProp).GetValue(value, Nothing)) Then
            cbo.SelectedIndex = i
         ElseIf strProp.Length = 0 Then
            If cbo.Items(i).GetType().Name = "DataRowView" Then
               Dim dr As DataRow = cbo.Items(i).Row
               For Each col As DataColumn In dr.Table.Columns
                  If value.GetType().IsEnum Then
                     If dr(col.ColumnName).ToString() = value.ToString() Then
                        cbo.SelectedIndex = i
                     End If
                  ElseIf IsNumeric(value) Then
                     If Val(dr(col.ColumnName)) = Val(value) Then
                        cbo.SelectedIndex = i
                     End If
                  Else
                     dr(col.ColumnName) = value
                  End If
               Next
            ElseIf IsNumeric(cbo.Items(i)) AndAlso IsNumeric(value) And Val(cbo.Items(i)) = Val(value) Then
               cbo.SelectedIndex = i
            ElseIf cbo.Items(i).GetType().Equals(value.GetType()) AndAlso cbo.Items(i).GetType().Namespace = "System" AndAlso cbo.Items(i) = value Then '.Value = val Or cbo.Items(i).text = val Then
               cbo.SelectedIndex = i
            End If
         End If
      Next
   End Sub

   Private Sub cboFanDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFanDescription.SelectedIndexChanged
      If IsLoaded Then
         CoilFan()
      End If

   End Sub
   Private Sub LoadFPI()
      If Condenser Is Nothing Then
         SetFileName()
         If Me.chkOverride.Checked Then
                Condenser = New Condenser(Val(TXT_ALDT.Text), Val(Me.TXT_EDB.Text), Val(TXT_WTD.Text), fcCoil.FinHeight, fcCoil.FinLength, fcCoil.FileName, Val(lblFanQuantity.Text / fc.CoilQuantity), Val(txtCFM.Text), "Smooth")
         Else
                '     Condenser = New Condenser(Val(Me.TXT_EDB.Text), Val(TXT_WTD.Text), fcCoil.Convert, Val(lblFanQuantity.Text / fc.CoilQuantity), cboFanDescription.SelectedItem, Val(TXT_ALDT.Text), "Smooth")
            'Condenser = New Condenser(Val(TXT_ALDT.Text), Val(Me.TXT_EDB.Text), Val(TXT_WTD.Text), fcCoil.FinHeight, fcCoil.FinLength, fcCoil.FileName, Val(lblFanQuantity.Text / fc.CoilQuantity), cboFanDescription.SelectedItem.Filename.ToString)
         End If
      End If
      If Not Condenser Is Nothing Then 'COFAN Is Nothing Then
         Dim alFPI As New ArrayList
         For Each co As Rae.RaeSolutions.Business.Entities.Condenser.Outputs In Condenser.Output
            alFPI.Add(co.FinsPerInch)
         Next
         Dim alCBO As New ArrayList
         For Each s As String In Cbo_fpi.Items
            alCBO.Add(Val(s))
         Next
         For Each d As Double In alFPI
            If Not alCBO.Contains(d) Then
               Cbo_fpi.Items.Add(d)
            End If
         Next
         For i As Integer = 0 To alCBO.Count - 1
            Dim d As Double = alCBO(i)
            If Not alFPI.Contains(d) Then
               If Val(Cbo_fpi.Text) = d Then
                  fcCoil.FPI = _fpi
                  Cbo_fpi.Items.RemoveAt(i)
               Else
                  Cbo_fpi.Items.RemoveAt(i)
               End If
            End If
         Next
         SetCombobox(Cbo_fpi, fcCoil.FPI)
      End If
   End Sub

   Private Sub CoilFan()
      Dim str As String = fcCoil.FPI 'Me.Cbo_fpi.Text
      If IsLoaded Then
         'If Not lblCoil Is Nothing AndAlso Not lblCoil.Tag Is Nothing AndAlso Not cboFanDescription Is Nothing AndAlso Not cboFanDescription.SelectedItem Is Nothing Then
         SetFileName()
         'dtb.Rows.Clear()
         'dtb = CalculateCFM()
         'COFAN = CalculateCFM()
         If Me.chkOverride.Checked Then
                Condenser = New Condenser(Val(TXT_ALDT.Text), Val(Me.TXT_EDB.Text), Val(TXT_WTD.Text), fcCoil.FinHeight, fcCoil.FinLength, fcCoil.FileName, Val(lblFanQuantity.Text / fc.CoilQuantity), Val(txtCFM.Text), "Smooth")
         Else
                '      Condenser = New Condenser(Val(Me.TXT_EDB.Text), Val(TXT_WTD.Text), fcCoil, Val(lblFanQuantity.Text / fc.CoilQuantity), cboFanDescription.SelectedItem, Val(TXT_ALDT.Text), "Smooth")
            'Condenser = New Condenser(Val(TXT_ALDT.Text), Val(Me.TXT_EDB.Text), Val(TXT_WTD.Text), fcCoil.FinHeight, fcCoil.FinLength, fcCoil.FileName, Val(lblFanQuantity.Text / fc.CoilQuantity), cboFanDescription.SelectedItem.Filename.ToString)
         End If

         '   For Each co As Rae.RaeSolutions.Business.Intelligence.CofanOutput In COFAN.Outputs
         '       If CInt(co.FPI) = fcCoil.FPI Then
         '           COut = co
         '       End If
         'Next
         For Each co As Rae.RaeSolutions.Business.Entities.Condenser.Outputs In Condenser.Output
            If CInt(co.FinsPerInch) = fcCoil.FPI Then
               CondenserOutput = co
            End If
         Next
         'Dim dv As DataView = dtb.DefaultView
         'dv.RowFilter = "FPI = " & str 'Me.Cbo_fpi.Text ' Me.Cbo_fpi.SelectedItem.ToString()
         If Not CondenserOutput Is Nothing Then 'COut Is Nothing Then 'dv.Count > 0 Then
            'Dim drv As DataRowView = dv.Item(0)
            If Me.CBO_CFMT.SelectedItem.ToString() = "A" Then
               'Me.TXT_CFM.Text = drv.Row("CFMACT").ToString()
               Me.TXT_CFM.Text = Round(CondenserOutput.AirFlowActual, 0) 'Round(COut.CFMACTUAL, 0)
            ElseIf Me.CBO_CFMT.SelectedItem.ToString() = "S" Then
               'Me.TXT_CFM.Text = drv.Row("CFMSTD").ToString()
               Me.TXT_CFM.Text = Round(CondenserOutput.AirFlowStandard, 0) 'Round(COut.CFMSTD, 0)
            End If
            Me.SSPanel1.Text = "FPM = " & Round(CondenserOutput.FaceVelocity, 0) 'Round(COut.FACEVELOCITY, 0) '"FPM = " & drv.Row("FV").ToString()
            'Me.TXT_FPD.Text = COut.BTUHSF 'drv.Row("BTUH").ToString()
         End If
         LoadFPI()
      End If
   End Sub

   Private Sub FanChanged()
      NeedReCalc()
   End Sub

   Private Sub NeedReCalc()
      bNeedsReCalc = True
      lblOK.Visible = False
      lblError.Visible = True
      cmdReCalc.Enabled = True
      'btnCalculatePage.Enabled = False
      'btnCreateReport.Enabled = False
      strError = String.Empty
      'lblErro.Text = defaultError
      'picError.Visible = False
      'dgReport.Visible = False
      dgvReport.Visible = False
   End Sub

   Private Sub CoilChanged()
      If IsLoaded Then
         SetFileName()
         LoadFPI()
         Me.LBL_MODEL_NUMBER.Text = fcCoil.ModelNumber
         lblCoil.Tag = fcCoil
         lblCoil.Text = fcCoil.Description.Replace("Condenser", "").Replace("Evaporator", "")
         NeedReCalc()
         'GetPrice()

      End If
   End Sub

   Private Sub GetPrice()
      Dim a As New RAEDLL_Coil_Pricing.Cls_Pricing

      a.RAE_CoilType = fcCoil.CoilUseType.ToString() 'Trim(cbo_coiltype.Text)  'W(water), D(direct expiation), S(steam), SD(steam distribution), C(condenser)
      a.RAE_Extra_Distributors = "N" 'Trim(cbo_Extra_Distributors)             'Y Or N
      a.RAE_Extra_Distributors_Qty = 1 'Val(cbo_Extra_Distributors_Qty.Text) '1 Or more
      a.RAE_connections_steel = "N"
      'If opt_Steel_Conn.Value = True And Val(cbo_SB_Connections.Text) > 0 Then
      '    a.RAE_connections_steel = "Y"               'Y Or N
      'Else
      '    a.RAE_connections_steel = "N"               'Y Or N
      'End If
      a.RAE_connections_brass = "N"
      'If opt_Brass_conn.Value = True And Val(cbo_SB_Connections.Text) > 0 Then
      '    a.RAE_connections_brass = "Y"               'Y Or N
      'Else
      '    a.RAE_connections_brass = "N"               'Y Or N
      'End If
      a.RAE_STEEL_CONN_QTY = 0 'Val(cbo_SB_Connections.Text) '2 Or more
      a.RAE_S1 = 0 '7 'S1                                       'Length of Brass connection Added 11/7/2006 Danny Groom
      a.RAE_CASING_SS = "N" 'Trim(cbo_CASING_SS.Text)          'Y Or N
      a.RAE_acrycoat_3 = "N"
      'If opt_Acrycoat_3.Value = True Then
      '	a.RAE_acrycoat_3 = "Y"                              'Y Or N
      'Else
      '	a.RAE_acrycoat_3 = "N"                              'Y Or N
      'End If
      a.RAE_Electrofin = "N"
      'If opt_Electrofin.Value = True Then
      '	a.RAE_Electrofin = "Y"                              'Y Or N
      'Else
      '	a.RAE_Electrofin = "N"                              'Y Or N
      'End If
      a.RAE_Baffled_headers = "N" 'Trim(cbo_Baffled_headers)   'Y Or N
      a.RAE_intermediate_drain_header = "N" 'Trim(cbo_Intermediate_Drain_Header)     'Y Or N
      a.RAE_Print_from_DLL = "N"                  'Y Or N     'Testing only
      a.RAE_CIRCUIT_TYPE = fcCoil.Circuiting.FluidCoolerCircuitingType 'Trim(CIRCUIT_TYPE)           'FULL:F 'HALF:H 'QUARTER:Q 'THREE QUARTER:T 'ONE AND ONE HALF:N 'DOUBLE:D 'ONE TUBE FEED NO HEADERS:E 'TWO TUBE FEED NO HEADERS:J 'OTHER-SPECIAL CIRCUITING:Z
      a.RAE_FL = fcCoil.FinLength 'Val(cbo_FL.Text)                             'Max length for 1/2 coils 240"  (W, DX, C) 'Max length for 5/8 coils 288"  (W, DX, C) 'Max length for 1/2 and 5/8 coils 120"  (S, SD)
      a.RAE_FH = fcCoil.FinHeight 'Val(cbo_FH.Text)                             'Fin Height for (½" coils 10" to 40"), (5/8" coils 12" to 60"), (1" coils 12" to 48")
      a.RAE_RD = fcCoil.NumRows 'Val(cbo_RD.Text)                             'W, D, C (1 to 6, 8, 10, 12 Rows Deep) S (1/2" and 5/8" coils 1 to 2 Rows Deep) 'SD (5/8" coils 1 to 2 Rows Deep) 'SD (1" coils 1 Row only)
      a.RAE_TUBE_SIZE = Utility.GetFromHash(fcCoil.Diameter, Coil.Diameters(fcCoil.CoilMode, fcCoil.CoilUseType)) 'fcCoil.Diameter 'Val(cbo_coilsize.Text)                '12, 58, 11
      a.RAE_Tube_Thickness = fcCoil.TubeThickness 'Val(CBO_TUBETHICKNESS.Text)      '½" Coils (.017, .025, .032) '5/8" Coils (.020, .025, .035, .049) '1" Coils (.035, .049)
      a.RAE_FPI = fcCoil.FPI 'Val(Cbo_fpi.Text)                           '4 to 14
      a.RAE_fin_Thickness = fcCoil.FinThickness 'Val(Cbo_fin_Thickness.Text)       '.006, .008 or .010
      a.RAE_fin_Material = fcCoil.FinMaterial.ToString() 'Trim(Cbo_Fin_Matl.Text)            'AL Or CU
      a.RAE_How_Many_Coils = fc.CoilQuantity 'Val(Cbo_HMC.Text)                'Greater than or equal to 1
      a.RAE_Rep_Multiplier = 0.75 'Val(txt_Rep_Multiplier.Text)     'Furnish by RAE
      a.RAE_intermediate_drain_header_qty = 0 'Val(cbo_Intermediate_Drain_Header_Qty.Text)    'How many
      a.RAE_expedited_delivery = 15 'Val(cbo_expedited_delivery.Text)     '15/10/5  Standard delivery 15 working days or Premium 5 or 10 day delivery
      'a.RAE_Pricing_Version = 2006 'Trim(Cbo_Pricing_Choice.Text)   'A pricing year and month passed to the program by the DLL Added 11/7/2006 Danny Groom
      a.RAE_Activation = "qdc4cTUdmdynl6YQ1583" 'RAEActivation                        'A password provide by RAE Corporation Added 11/7/2006 Danny Groom
      a.AddToDatabase() 'Function call executes              'Was(a.AddToDatabase) Changed 11/7/2006 Danny Groom
      'lblPrice.Text = a.RAE_Out_total_Pricing
   End Sub

   Private Function getCoilCapacityMultiplier() As Double
      Dim capacityMultiplier As Double
      Dim cache As CondenserCache = CondenserCache.Create()

      ' adjusts coil capacity based on catalog rating and refrigerant
      Dim refrigerantMultiplier As Double

      If Me.Refrigerant.Type = Engineering.RefrigerantType.R22 Then
         refrigerantMultiplier = cache.R22Multiplier
      ElseIf Refrigerant.Type = Engineering.RefrigerantType.R407c Then
         refrigerantMultiplier = cache.R407cMultiplier
      ElseIf Refrigerant.Type = Engineering.RefrigerantType.R134a Then
         refrigerantMultiplier = cache.R134aMultiplier
      ElseIf Refrigerant.Type = Engineering.RefrigerantType.R404a Then
         refrigerantMultiplier = cache.R404aMultiplier
      ElseIf Refrigerant.Type = Engineering.RefrigerantType.R507 Then
         refrigerantMultiplier = cache.R507Multiplier
      End If

      capacityMultiplier = refrigerantMultiplier

      If Me.chkCatalog.Checked Then
         capacityMultiplier *= cache.CatalogRatingMultiplier
         capacityMultiplier = capacityMultiplier * 1.04
      End If

      Return capacityMultiplier
   End Function

   Protected Overrides Sub Finalize()
      MyBase.Finalize()
   End Sub

   Public Sub New()
      InitializeComponent()
   End Sub

   Private Sub CBO_CFMT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBO_CFMT.SelectedIndexChanged
      If Not Condenser Is Nothing Then
         For Each co As Rae.RaeSolutions.Business.Entities.Condenser.Outputs In Condenser.Output
            If CInt(co.FinsPerInch) = fcCoil.FPI Then
               CondenserOutput = co
            End If
         Next
         If Not CondenserOutput Is Nothing Then
            If Me.CBO_CFMT.SelectedItem.ToString() = "A" Then
               Me.TXT_CFM.Text = Round(CondenserOutput.AirFlowActual, 0)
            ElseIf Me.CBO_CFMT.SelectedItem.ToString() = "S" Then
               Me.TXT_CFM.Text = Round(CondenserOutput.AirFlowStandard, 0)
            End If
            Me.SSPanel1.Text = "FPM = " & Round(CondenserOutput.FaceVelocity, 0)
         End If
      End If
   End Sub

   Private Function CalculatePage() As DataTable
      ReCalc()
      Dim isError As Boolean = False
      ErrorList.Clear()
      ResultsTable = New DataTable
      ResultsTable.Columns.Add("EDB")
      ResultsTable.Columns.Add("EFT")
      ResultsTable.Columns.Add("LFT")
      ResultsTable.Columns.Add("FPI")
      ResultsTable.Columns.Add("MBH")
      ResultsTable.Columns.Add("GPM")
      ResultsTable.Columns.Add("Fluid PD")
      ResultsTable.Columns.Add("Circ.")
      ResultsTable.Columns.Add("Error")

      '-----------------------
      Dim tx As Integer = CInt(Me.TXT_EDB.Text)
      Dim ti As Integer = CInt(Me.cboTempInterval.SelectedItem.ToString)
      Dim t0 As Integer = tx - (4 * ti)
      Dim t1 As Integer = tx + ti
      For t As Integer = t0 To t1 Step ti
         '------------------------
         RAESelRatingCore = New RAE_SelectionRating.RAESelectionRating
         Dim b As Boolean = CALC(RAESelRatingCore, t) ', r)
         Dim dr As DataRow = ResultsTable.NewRow
         If b Then
            dr("Error") = strError
            isError = True
         End If
         If t = tx Then
            RaeSelRating = RAESelRatingCore
         End If
         dr("EDB") = t.ToString 'Val(Me.TXT_EDB.Text)
         dr("EFT") = Val(Me.TXT_EWT.Text).ToString
         dr("LFT") = Format(RAE_Out_LWT1, "#") 'Round(RAE_Out_LWT1, 1).ToString
         dr("FPI") = CondenserOutput.FinsPerInch.ToString
         dr("MBH") = Format(Round(Val(RAESelRatingCore.RAE_Out_Sens_HT1) * fc.CoilQuantity, 2), "#.00") '.ToString
         dr("GPM") = Format(Round(RAE_Out_GPM1 * fc.CoilQuantity, 2), "#.00") '.ToString
         dr("Fluid PD") = Format(Round(RAE_Out_Fluid_PD1, 2), "#.00") '.ToString
         dr("Circ.") = fcCoil.Circuiting.FluidCoolerCircuitingValue.ToString
         ResultsTable.Rows.Add(dr)
         RAESelRatingCore = Nothing
         strError = String.Empty
         '-----------------
      Next
      ''----------------------
      ResultsTable.TableName = "FluidCooler"
      'ResultsTable.WriteXml("C:\fc.xml")
      'If Not isError Then
      'dgReport.DataSource = tbl
      dgvReport.DataSource = ResultsTable
      FormatResultsGrid()
      'pnlGrid.Visible = True
      'dgvReport.Visible = True
      'dgvReport.Height = 30 * (ResultsTable.Rows.Count + 1) + 5
      'pnlBottom.Height = dgvReport.Height + Panel1.Height + 5
      'pnlGrid.Height = dgvReport.Height + 5
      ' Me.Height = Me.Height + pnlGrid.Height + 5
      'Else
      If isError > 0 Then
         ToolTip1.SetToolTip(dgvReport, String.Empty)
         'lblErro.Text = "Some calculations have errors." 'strError
         'picError.Visible = True
      End If
      For r As Integer = 0 To ResultsTable.Rows.Count - 1
         Dim c As DataGridViewCell = dgvReport.Rows(r).Cells(8)
         If ResultsTable.Rows(r)("Error").ToString.Length > 0 Then
            Dim str As String = ResultsTable.Rows(r)("Error").ToString
            c.ToolTipText = str
            'AddHandler c., Me.ToolTipHandler
            Dim al As New ArrayList
            al.Add(r)
            al.Add(str)
            ErrorList.Add(al)
            c.Value = "!"
            c.Style.ForeColor = Color.Red
         Else
            c.Value = String.Empty
            c.ToolTipText = String.Empty
            'ToolTip1.Hide(c)
         End If
      Next
      Return ResultsTable
   End Function

   Private Sub ToolTipHandler(ByVal sender As Object, ByVal e As MouseEventArgs)
      Dim hti As DataGridView.HitTestInfo = dgvReport.HitTest(e.X, e.Y)
      For Each al As ArrayList In ErrorList
         Dim hitrow As Integer = CInt(al(0))
         Dim hitcol As Integer = 8
         If hti.Type = DataGridViewHitTestType.Cell AndAlso hti.RowIndex = hitrow AndAlso hti.ColumnIndex = hitcol Then
            Me.ToolTip1.SetToolTip(dgvReport, al(1).ToString)
            Me.ToolTip1.Active = True
         Else
            Me.ToolTip1.RemoveAll()
            Me.ToolTip1.Active = False
         End If
      Next
   End Sub

   Private ErrorList As New ArrayList


   Private Function CALC(ByVal RAESelRatingCore As RAE_SelectionRating.RAESelectionRating, ByVal t As Integer) As Boolean ', ByVal dr As DataRow)
      clear_output_var()
      ERROR_ARRAYS() 'Updated 12/1/1999 D.Groom new line
      Dim isError As Boolean = False
      strError = String.Empty

      With RAESelRatingCore 'Starting the link with DLL
         .RAE_CFMT = Trim(CBO_CFMT.Text) 'A = Actual CFM OR S = Standard CFM  New 10/22/2004 DGroom
         .RAE_Choice = "R" 'CBO_CHOICE.Text 'S or R
         .RAE_CoilSize = Coil.Diameters(Coil.CoilModes.Rae, Coil.CoilTypes.W).Item(fcCoil.Diameter) 'Cbo_coilsize.Text '12 or 58
         .RAE_CoilType = Coil.CoilTypes.W.ToString() 'Cbo_coiltype.Text 'W (FLUID)
         .RAE_Hot_Cold = "H" 'CBO_HOT_COLD.Text 'H or C
         .RAE_FinHeight = fcCoil.FinHeight ' Cbo_fh.Text 'FOR 1/2 COILS USE (1.25 * TUBES HEIGHT), FOR 5/8 COILS USE (1.5 * TUBES HEIGHT)
         .RAE_FinLength = fcCoil.FinLength ' lbl_fl.Text '1 TO 300 INCHES
         .RAE_FPI = CondenserOutput.FinsPerInch 'Val(COut.FPI) ') 'fcCoil.FPI ' Cbo_fpi.Text '4 TO 14
         .RAE_rows = fcCoil.NumRows ' Cbo_rows.Text '1 TO 24


         .RAE_CFM = TXT_CFM.Text 'PER APPLICATION (NUMBER)
         .RAE_EDB = t 'TXT_EDB.Text 'PER APPLICATION (NUMBER)
         .RAE_EWB = TXT_EWB.Text 'PER APPLICATION (NUMBER)
         .RAE_EWT = TXT_EWT.Text 'PER APPLICATION (NUMBER)
         .RAE_GPM = TXT_GPM.Text 'PER APPLICATION (NUMBER)
         .RAE_WTD = TXT_WTD.Text 'PER APPLICATION (NUMBER)
         .RAE_SERP = fcCoil.Circuiting.FluidCoolerCircuitingValue '.TXT_SERP.Text 'Circuiting 0 TO 2  EX: OPTIMIZE = 0, FULL = 1, HALF = .5, QUARTER = .25, THREE QUARTE = .75, ONE AND ONE HALF = 1.5, DOUBLE = 2 AND E, J, Z ARE CALCULATED
         .RAE_LDB = 0 'RATING (NUMBER)
         .RAE_LWB = 0 'RATING (NUMBER)
         .RAE_SH = 0 'RATING (NUMBER)
         .RAE_TH = 0 'RATING (NUMBER)
         .RAE_FPD = 0 'sVal(COut.BTUHSF) 'TXT_FPD.Text 'PER APPLICATION (NUMBER)
         .RAE_ALDT = TXT_ALDT.Text 'PER APPLICATION (NUMBER)
         .RAE_FluidType = CBO_FLUIDTYPE.Text 'WTR, EG, PG
         .RAE_PerConc = TXT_PERCONC.Text '10 TO 60
         .RAE_FinMatl = CBO_FINMATL.Text 'AL OR CU
         .RAE_FinThickness = CBO_FINTHICKNESS.Text '.006, .008, .010
         .RAE_TubeMatl = TXT_TUBEMATL.Text 'CU
         .RAE_TubeThickness = CBO_TUBETHICKNESS.Text 'FOR 1/2 COILS USE .017, .025, .032 AND ON 5/8 COILS USE .020, .025, .035, .049
         .RAE_Hand = fcCoil.Orientation.ToString() '.Text 'L OR R
         .RAE_Fin_Type = fcCoil.FinDesign.ToString().Substring(0, 1) 'CBO_FIN_TYPE.Text 'W or F
         .RAE_FFI = TXT_FFI.Text 'PER APPLICATION (NUMBER)
         .RAE_FFO = TXT_FFO.Text 'PER APPLICATION (NUMBER)
         .RAE_CIRCUIT_TYPE = fcCoil.Circuiting.FluidCoolerCircuitingValue 'CIRCUIT_TYPE 'Added 4/3/2006 (OPTIMIZE = 0, FULL = F, HALF = H, QUARTER = Q, THREE QUARTER = T, ONE AND ONE HALF = N, DOUBLE = D AND Single = E, Double = J, Non-Standard = Z ARE CALCULATED)
         .AddToDatabase() 'This sets the DLL in action doing caluations

         RAE_Out_DLL_loop_Error = .RAE_Out_DLL_loop_Error
         RAE_Out_ERROR_MSG1 = .RAE_Out_ERROR_MSG1
         RAE_Out_ERROR_MSG2 = .RAE_Out_ERROR_MSG2
         RAE_Out_ERROR_MSG3 = .RAE_Out_ERROR_MSG3
         RAE_Out_Input_error1 = .RAE_Out_Input_error1
         RAE_Out_Input_error2 = .RAE_Out_Input_error2
         RAE_Out_Input_error3 = .RAE_Out_Input_error3
         RAE_Out_Input_error4 = .RAE_Out_Input_error4
         RAE_Out_Input_error5 = .RAE_Out_Input_error5
         RAE_Out_Input_error6 = .RAE_Out_Input_error6
         RAE_Out_Input_error7 = .RAE_Out_Input_error7
         RAE_Out_Input_error8 = .RAE_Out_Input_error8
         RAE_Out_Input_error9 = .RAE_Out_Input_error9

         If RAE_Out_Input_error1 > 0 Then
            isError = True
            strError += RAE_Out_Input_error_text(RAE_Out_Input_error1) & vbCrLf
            'MsgBox("Input Error #" & RAE_Out_Input_error1 & "  " & RAE_Out_Input_error_text(RAE_Out_Input_error1) & Chr(10) & "An Input error has occured, please check your input and try again.")
            'GoTo SKIPPING_PRINTING_ACTION_DUE_TO_ERRORS_WATER
         End If
         If RAE_Out_Input_error2 > 0 Then
            isError = True
            strError += RAE_Out_Input_error_text(RAE_Out_Input_error2) & vbCrLf
            'MsgBox("Input Error #" & RAE_Out_Input_error2 & "  " & RAE_Out_Input_error_text(RAE_Out_Input_error2) & Chr(10) & "An Input error has occured, please check your input and try again.")
            'GoTo SKIPPING_PRINTING_ACTION_DUE_TO_ERRORS_WATER
         End If
         If RAE_Out_Input_error3 > 0 Then
            isError = True
            strError += RAE_Out_Input_error_text(RAE_Out_Input_error3) & vbCrLf
            'MsgBox("Input Error #" & RAE_Out_Input_error3 & "  " & RAE_Out_Input_error_text(RAE_Out_Input_error3) & Chr(10) & "An Input error has occured, please check your input and try again.")
            'GoTo SKIPPING_PRINTING_ACTION_DUE_TO_ERRORS_WATER
         End If

         If RAE_Out_DLL_loop_Error = 1 Then
            isError = True
            strError += "An Error has occured with the calulation, please check your input and try again." & vbCrLf
            'MsgBox("An Error has occured with the calulation, please check your input and try again.")
            'GoTo SKIPPING_PRINTING_ACTION_DUE_TO_ERRORS_WATER
         End If

         RAE_Choice = .RAE_Choice
         RAE_Out_LDB1 = .RAE_Out_LDB1
         RAE_Out_LDB2 = .RAE_Out_LDB2
         RAE_Out_LWB1 = .RAE_Out_LWB1
         RAE_Out_LWB2 = .RAE_Out_LWB2
         RAE_Out_Total_HT1 = .RAE_Out_Total_HT1
         RAE_Out_Total_HT2 = .RAE_Out_Total_HT2
         RAE_Out_Sens_HT1 = .RAE_Out_Sens_HT1
         RAE_Out_Sens_HT2 = .RAE_Out_Sens_HT2
         RAE_Out_LWT1 = .RAE_Out_LWT1
         RAE_Out_LWT2 = .RAE_Out_LWT2
         RAE_Out_GPM1 = .RAE_Out_GPM1
         RAE_Out_GPM2 = .RAE_Out_GPM2
         RAE_Out_Water_Vel1 = .RAE_Out_Water_Vel1
         RAE_Out_Water_Vel2 = .RAE_Out_Water_Vel2
         RAE_Out_CIRCUITING1 = .RAE_Out_CIRCUITING1
         RAE_Out_CIRCUITING2 = .RAE_Out_CIRCUITING2

         If RAE_Out_ERROR_MSG1 = 1004 Then 'WATER COILS

            If RAE_Choice = "R" Then
               msg = "(WARNING 1004) WATER COIL FLUID TUBE VELOCITY LESS THAN 1 FPS PER CIRCUIT, CHANGE CIRCUITING TO INCRESS TUBE VELOCITY." & Chr(10) & Chr(10) & "SELECTION 1 TUBE VELOCITY = (" & Round(RAE_Out_Water_Vel1, 3) & " FPS)   - " & RAE_Out_CIRCUITING1 & " - CIRCUIT SELECTION" & Chr(10) & Chr(10) & "RECOMMENDED TUBE VELOCITY 1 TO 6 FPS PER CIRCUIT." & Chr(10) & Chr(10) & "COULD CREATE A LAMINAR FLOW SITUATION (NOT RECOMMENDED) ON WATER/GLYCOL COIL'S."
            Else
               msg = "(WARNING 1004) WATER COIL FLUID TUBE VELOCITY LESS THAN 1 FPS PER CIRCUIT, CHANGE CIRCUITING TO INCRESS TUBE VELOCITY." & Chr(10) & Chr(10) & "SELECTION 1 TUBE VELOCITY = (" & Round(RAE_Out_Water_Vel1, 3) & " FPS)   - " & RAE_Out_CIRCUITING1 & " - CIRCUIT SELECTION" & Chr(10) & "SELECTION 2 TUBE VELOCITY = (" & Round(RAE_Out_Water_Vel2, 3) & " FPS)   - " & RAE_Out_CIRCUITING2 & " - CIRCUIT SELECTION" & Chr(10) & Chr(10) & "RECOMMENDED TUBE VELOCITY 1 TO 6 FPS PER CIRCUIT." & Chr(10) & Chr(10) & "COULD CREATE A LAMINAR FLOW SITUATION (NOT RECOMMENDED) ON WATER/GLYCOL COIL'S."
            End If
            isError = True
            strError += msg & vbCrLf
            '*************************
            'STYLE = CStr(MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) ' Define buttons.
            'TITLE = "CANCEL JOB?" ' Define title.
            'RESPONSE = CStr(MsgBox(msg, CDbl(STYLE), TITLE))
            'If RESPONSE = CStr(MsgBoxResult.Yes) Then ' User chose Yes.
            '   GoTo SKIPPING_PRINTING_ACTION_DUE_TO_ERRORS_WATER
            'Else ' User chose No.
            'End If
            '*************************
         End If

         If RAE_Out_ERROR_MSG2 = 1005 Then 'WATER COILS
            isError = True
            msg = "(WARNING 1005) WATER COIL FLUID TUBE VELOCITY GREATER THAN 6 FPS PER CIRCUIT NOT RECOMMENDED, CHANGE CIRCUITING TO DECRESS TUBE VELOCITY." & Chr(10) & Chr(10) & "SELECTION 1 TUBE VELOCITY = (" & Round(RAE_Out_Water_Vel1, 3) & " FPS)   - " & RAE_Out_CIRCUITING1 & " - CIRCUIT SELECTION" & Chr(10) & Chr(10) & "RECOMMENDED TUBE VELOCITY 1 TO 6 FPS PER CIRCUIT."
            strError += msg & vbCrLf
            'STYLE = CStr(MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) ' Define buttons.
            'TITLE = "CANCEL JOB?" ' Define title.
            'RESPONSE = CStr(MsgBox(msg, CDbl(STYLE), TITLE))
            'If RESPONSE = CStr(MsgBoxResult.Yes) Then ' User chose Yes.
            '   GoTo SKIPPING_PRINTING_ACTION_DUE_TO_ERRORS_WATER
            'Else ' User chose No.
            'End If
            '*************************
         End If

         If RAE_Out_ERROR_MSG1 = 1006 Then
            MsgBox("(WARNING 1006) NO CONNECTIONS WERE SELECTED FOR THIS JOB.  PLEASE CONTACT FACTORY FOR SELECTION.")
         End If
         RAE_Out_Fluid_PD1 = .RAE_Out_Fluid_PD1
         RAE_Out_Fluid_PD2 = .RAE_Out_Fluid_PD2
         RAE_Out_No_of_Circuits1 = .RAE_Out_No_of_Circuits1
         RAE_Out_No_of_Circuits2 = .RAE_Out_No_of_Circuits2
         RAE_Out_Air_Press_Drop1 = .RAE_Out_Air_Press_Drop1
         RAE_Out_Air_Press_Drop2 = .RAE_Out_Air_Press_Drop2
         RAE_Out_Connections1 = .RAE_Out_Connections1
         RAE_Out_Connections2 = .RAE_Out_Connections2
         RAE_Out_FPI1 = .RAE_Out_FPI1
         RAE_Out_ROWS1 = .RAE_Out_ROWS1
         RAE_Out_FPI2 = .RAE_Out_FPI2
         RAE_Out_ROWS2 = .RAE_Out_ROWS2
         RAE_Out_SELECTION1 = .RAE_Out_SELECTION1
         RAE_Out_SELECTION2 = .RAE_Out_SELECTION2
         RAE_Out_Opp_End_Conn = .RAE_Out_Opp_End_Conn
         RAE_Out_ARI_MSG1 = .RAE_Out_ARI_MSG1
         RAE_Out_ARI_MSG2 = .RAE_Out_ARI_MSG2
         RAE_Out_ARI_MSG3 = .RAE_Out_ARI_MSG3


SKIPPING_PRINTING_ACTION_DUE_TO_ERRORS_WATER:

      End With 'End DLL Variable passing
      Return isError

   End Function

   Private Sub btnCalculatePage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculatePage.Click
      'CALL_WATER_HOT_OR_COLD()
      CalculatePage()
   End Sub

    <DebuggerStepThrough()> _
    Private Sub FluidCoolerForm_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        'initializeSaveToolStripPanel()
        'Me.SaveToolStripPanel1.Merge()
    End Sub


   Private Sub FluidCoolerForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
      'LoadFPI()
   End Sub

   Private Sub cboDiameter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDiameter.SelectedIndexChanged
      'If IsLoaded Then
      Dim drv As DataRowView = cboDiameter.SelectedItem
      fcCoil.Diameter = Val(drv("Key").ToString())
      'CoilChanged()
      'End If
      CoilChanged()
   End Sub

   Private Sub cboHeight_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHeight.SelectedIndexChanged
      If IsLoaded Then
         fcCoil.FinHeight = Val(cboHeight.SelectedItem)
         CoilChanged()
      End If

   End Sub

   Private Sub cboLength_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLength.SelectedIndexChanged
      If IsLoaded Then
         fcCoil.FinLength = Val(cboLength.SelectedItem)
         CoilChanged()
      End If

   End Sub

   Private Sub ReCalc()
      bNeedsReCalc = False
      lblError.Visible = False
      lblOK.Visible = True
      cmdReCalc.Enabled = False
      'btnCalculatePage.Enabled = True
      'btnCreateReport.Enabled = True
      CoilFan()
   End Sub

   Private Sub cmdReCalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReCalc.Click
      ReCalc()
   End Sub

   Private Sub cboFanQuantity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

   End Sub

   Private Sub rbWTD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbWTD.CheckedChanged
      If rbWTD.Checked Then
         TXT_GPM.Text = "0"
         TXT_GPM.Enabled = False
         TXT_WTD.Enabled = True
         TXT_WTD.BackColor = Color.White
         TXT_GPM.BackColor = Color.Gray
      Else
         TXT_WTD.Enabled = False
         TXT_WTD.Text = "0"
         TXT_GPM.Enabled = True
         TXT_WTD.BackColor = Color.Gray
         TXT_GPM.BackColor = Color.White
      End If
   End Sub

   Private Sub rbGPM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbGPM.CheckedChanged
      If rbGPM.Checked = True Then
         TXT_WTD.Enabled = False
         TXT_WTD.Text = "0"
         TXT_GPM.Enabled = True
         TXT_WTD.BackColor = Color.Gray
         TXT_GPM.BackColor = Color.White
      Else
         TXT_GPM.Text = "0"
         TXT_GPM.Enabled = False
         TXT_WTD.Enabled = True
         TXT_WTD.BackColor = Color.White
         TXT_GPM.BackColor = Color.Gray
      End If
   End Sub

   Private Sub btnCreateReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateReport.Click
      Me.Cursor = Cursors.WaitCursor
      Dim dtb As DataTable = CalculatePage()
      'For Each al As ArrayList In ErrorList
      '   Dim dr As DataRow = dtb.Rows(CInt(al(0)))
      '   dr("Error") = CStr(al(1))
      'Next
      If Me.dgvReport.Visible = True Then
         Me.ShowReport(dtb)
      Else
         Dim errorMessage As String = "Report could not be created."
         'If lblErro.Text = "" Then
         '   lblErro.Text = errorMessage
         'Else
         '   lblErro.Text &= Environment.NewLine & errorMessage
         'End If
      End If
      Me.Cursor = Cursors.Default
   End Sub

   Private Sub ShowReport(ByVal dtb As DataTable)
      Dim report As CREngine.ReportDocument
      Dim dbPath As String
      Dim fields As CREngine.ParameterFieldDefinitions
      Dim field As Rae.Reporting.CrystalReports.SingleParameterFieldDefinition
      Dim evaporator8, evaporator10, condenserCapacity, fan As String
      Dim reportForm As Rae.Reporting.CrystalReports.ReportViewerForm
      Dim chillerModel, condenser, system, fluid, circuitNote, operatingLimits, catalogRating As String
      Dim numCompressors1, numCompressors2, compressorFileName1, compressorFileName2, compressor As String
      Dim circuitsPerUnit, lowerApproach, upperApproach As Integer

      report = New CREngine.ReportDocument()
      report.Load(Reports.file_paths.FluidCoolerRatingReportFilePath)
      reportForm = New Rae.Reporting.CrystalReports.ReportViewerForm()

      Try
         report.SetDataSource(dtb)
      Catch ex As Exception
         MessageBox.Show( _
            "Attempt to set the database connection for the report failed." & _
            Environment.NewLine & dbPath & Environment.NewLine & ex.ToString, _
            "Crystal Reports", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

      fields = report.DataDefinition.ParameterFields
      field = New Rae.Reporting.CrystalReports.SingleParameterFieldDefinition(fields)


      field.Pass("Engineer", "pfdAuthorization")
      field.Pass(My.Application.Info.Version.ToString, "pfdVersion")
      field.Pass(Me.TXT_ALDT.Text & " ft.", "pfdAltitude")
      field.Pass(Me.lblCoil.Text.Replace("Condenser", "").Replace("Evaporator", "") & " {" & Me.LBL_MODEL_NUMBER.Text & "}", "pfdCoil")
      field.Pass(CInt(Me.lblCoilQuantity.Text).ToString, "pfdNumCoils")
      If Me.chkOverride.Checked Then
         field.Pass(txtCFM.Text & " CFM", "pfdFan")
      Else
         field.Pass(Me.cboFanDescription.SelectedItem.Description, "pfdFan")
      End If

      field.Pass(CInt(Me.lblFanQuantity.Text).ToString, "pfdNumFans")
      field.Pass(Me.lblDimensions.Text, "pfdDimensions")
      field.Pass("TSI", "pfdLogo")
      field.Pass(AppInfo.User.username, "pfdCreator")
      If Me.chkCustomModel.Checked Then
         field.Pass(Me.txtCustomModel.Text, "pfdModelNumber")
      Else
         field.Pass(fc.ModelName, "pfdModelNumber")
      End If
      field.Pass(fluid, "pfdFluid")
      field.Pass(Me.Refrigerant.Name, "pfdRefrigerant")
      field.Pass(CInt(Me.TXT_EDB.Text).ToString, "pfdEDB")
      reportForm.ReportViewer.ReportSource = report
      reportForm.ReportViewer.Zoom(1) '1 = page width, 2 = whole page, else %
      reportForm.Show()
   End Sub

   Private Sub cboTempInterval_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTempInterval.SelectedIndexChanged
      dgvReport.Visible = False
   End Sub

   Private Sub chkOverride_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOverride.CheckedChanged
      If chkOverride.Checked Then
         txtCFM.Visible = True
         lblCFM.Visible = True
         Me.cboFanDescription.Enabled = False
      Else
         txtCFM.Visible = False
         lblCFM.Visible = False
         Me.cboFanDescription.Enabled = True
      End If
      NeedReCalc()
   End Sub

   Private Sub txtCFM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCFM.TextChanged
      NeedReCalc()
   End Sub

   Private Sub btnNewEquipmentPricing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewEquipmentPricing.Click
      CalculatePage()
      SaveControls()
      OpenedProject.Manager = CurrentStateProcess.ProjectManager
      Dim fcei As New FluidCoolerEquipmentItem(CurrentStateProcess.name, Business.Division.TSI, New item_id(ProjectInfo.NewItemID(CurrentStateProcess.id.Id)), OpenedProject.Manager)
      With fcei
         .revision = 0
         .division = Business.Division.TSI
         .type = Business.EquipmentType.FluidCooler
         .series = fc.FluidCoolerSeries.ModelSeries
         .model_without_series = fc.ModelNumber
         .RatingEquipment = fc
         .model_without_series = fc.ModelNumber.ToString
         .series = fc.FluidCoolerSeries.ModelSeries
         Dim cs As New CommonSpecifications
         Dim alt As New Rae.nullable_value(Of Double)
         alt.set_to(Val(Me.TXT_ALDT.Text))
         cs.Altitude = alt
         Dim ow As New Rae.nullable_value(Of Double)
         ow.set_to(fc.Operating_Weight)
         cs.OperatingWeight = ow
         Dim sw As New Rae.nullable_value(Of Double)
         sw.set_to(fc.Shipping_Weight)
         cs.ShippingWeight = sw
         .common_specs = cs
         If Not RaeSelRating Is Nothing Then
            Dim spec As New FluidCoolerSpecifications
            spec.AmbientTemp.set_to(Val(Me.TXT_EDB.Text))
            spec.Capacity.set_to(CondenserOutput.Capacity)
            spec.EnteringFluidTemp = New Rae.nullable_value(Of Double)
            spec.EnteringFluidTemp.set_to(Val(Me.TXT_EWT.Text))
            spec.Flow.set_to(RaeSelRating.RAE_GPM)
            spec.Fluid = RaeSelRating.RAE_FluidType
            'spec.GlycolPercent.SetValue(val(me.txt_gl
            .Specs = spec
         End If
         .Save()
      End With
      fcei.Process = CurrentStateProcess
      OpenedProject.Manager.Equipment.Add(fcei)
      'Dim fcp As New EquipmentForm
      'fcp.Equipment = fcei
      'fcp.MdiParent = Me.MdiParent
      'fcp.Show()
      Me.Close()
   End Sub

    <DebuggerStepThrough()> _
    Private Sub Panel5_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel5.Paint

    End Sub
End Class
