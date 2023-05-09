Imports System.IO
Imports System.Threading
Imports Rae.RaeSolutions.DataAccess
Imports Rae.DataAccess.EquipmentOptions
Imports System.Data
Imports System.Net.Mail
Imports Rae.solutions.group


Public Class OrderEntry



    Private Sub btnCloudSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloudSave.Click
        Try
            Dim result As DialogResult = MessageBox.Show("Do you want to save your current changes?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
            If result.Equals(DialogResult.Yes) Then
                ' save project
                OpenedProject.Manager.Project.Save()
            ElseIf result.Equals(DialogResult.No) Then
                ' do nothing
            ElseIf result.Equals(DialogResult.Cancel) Then
                Exit Sub
            End If


            Dim projectID As String = OpenedProject.ProjectId.ToString

            Dim sql = "select ProjectRevision, Name, ReleaseNum, PoNum, RequestedShipDate, RepId, RepCompanyId from Projects where ProjectID = '" & projectID & "'"
            Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
            Dim command = connection.CreateCommand
            command.CommandText = sql
            Dim rdr As IDataReader

            Dim releaseNum As String = ""
            Dim name As String = ""
            Dim repID As String = ""
            Dim repCompanyID As String = ""
            Dim poNumber As String = ""
            Dim requestedShipDate As String = ""
            Dim projectRevision As String = ""
            Dim user As String = AppInfo.User.username.ToString()

            Try
                connection.Open()
                rdr = command.ExecuteReader()
                While rdr.Read
                    releaseNum = rdr("ReleaseNum").ToString()
                    name = rdr("Name").ToString()
                    repID = rdr("RepID").ToString()
                    repCompanyID = rdr("RepCompanyId").ToString()
                    poNumber = rdr("PoNum").ToString()
                    requestedShipDate = rdr("RequestedShipDate").ToString()
                    projectRevision = rdr("ProjectRevision").ToString()
                End While
            Finally
                If rdr IsNot Nothing Then _
                   rdr.Close()
                If connection.State <> ConnectionState.Closed Then _
                   connection.Close()
            End Try

            If releaseNum = "" Or String.IsNullOrEmpty(releaseNum) Then
                releaseNum = "N/A"
            End If

            If projectRevision = "" Or String.IsNullOrEmpty(projectRevision) Then
                projectRevision = "N/A"
            End If

            If name = "" Or String.IsNullOrEmpty(name) Then
                name = "N/A"
            End If

            If repID = "" Or String.IsNullOrEmpty(repID) Then
                repID = "N/A"
            End If

            If repCompanyID = "" Or String.IsNullOrEmpty(repCompanyID) Then
                repCompanyID = "N/A"
            End If

            If poNumber = "" Or String.IsNullOrEmpty(poNumber) Then
                poNumber = "N/A"
            End If

            If requestedShipDate = "" Or String.IsNullOrEmpty(requestedShipDate) Then
                requestedShipDate = "N/A"
            End If

            If Not AppInfo.User.is_in(sales) Then
                Dim cloudEmail As New CloudEmailService.WebService1
                If cloudEmail.savedToCloudEmail(name, releaseNum, repID, repCompanyID, requestedShipDate, projectRevision, user) = False Then
                    MessageBox.Show("Error Sending Saved to Cloud Email")
                End If
            End If

            Dim CloudSaveWS As New CloudSaveService.CloudSave

            Dim CSResults As CloudSaveService.CloudProjectInfo

            CSResults = CloudSaveWS.CreateCloudProject(AppInfo.User.username, "RAE")

            CopyProjectsRecord(CSResults.CloudID)
            CopyProcessesRecord(CSResults.CloudID)
            CopyEquipmentRecord(CSResults.CloudID)
            CopyACChillerProcessesRecord(CSResults.CloudID)
            CopyChillerRecord(CSResults.CloudID)
            CopyFluidCoolerRecord(CSResults.CloudID)
            CopyFluidCoolerProcessesRecord(CSResults.CloudID)
            CopyCondenserRecord(CSResults.CloudID)
            CopyCondenserProcessesRecord(CSResults.CloudID)
            CopyCondensingUnitRecord(CSResults.CloudID)
            CopyCondensingUnitProcessesRecord(CSResults.CloudID)
            CopyUnitCoolerProcessesRecord(CSResults.CloudID)
            CopyUnitCoolerRecord(CSResults.CloudID)
            CopyPumpPackageRecord(CSResults.CloudID)
            CopyProductCoolerRecord(CSResults.CloudID)
            CopyEvapChillerProcessesRecord(CSResults.CloudID)
            CopyOrderEntryContacts(CSResults.CloudID)

            CopyProjectContactsRecord(CSResults.CloudID)
            CopyCompaniesRecord(CSResults.CloudID)
            CopyContactsRecord(CSResults.CloudID)

            CopySpecialOptionsRecord(CSResults.CloudID)
            CopyEquipmentOptionsRecord(CSResults.CloudID)
            CopyProcessEquipRecord(CSResults.CloudID)


            'CopyCoolStuffUserAshraeRecord(CSResults.CloudID)  
            'CopyCoolStuffReportProjectRecord(CSResults.CloudID)
            'CopyCoolStuffProjectsRecord(CSResults.CloudID)
            'CopyCoolStuffProductSelectionsReportRecord(CSResults.CloudID)
            'CopyCoolStuffProductSelectionsRecord(CSResults.CloudID)


            'CopyAddressesRecord(CSResults.CloudID)   ' not used?
            'CopyProcessSpecificRecord(CSResults.CloudID)  ' not used?
            'CopyOtherEquipmentCostsRecord(CSResults.CloudID)   ' not used?

            'CopyRatingEquipmentRecord(CSResults.CloudID)  ' Used for fluid coolers only?


            txtUniqueKey.Text = CSResults.ShareGUID


            MsgBox("Project successfully saved to cloud!")
        Catch ex As Exception
            MsgBox("Error saving to the cloud.")
        End Try

    End Sub


    Private Sub CopyProcessEquipRecord(ByVal cloudID As Integer)

        Dim projectID As String = OpenedProject.ProjectId.ToString
        Dim CloudSaveWS As New CloudSaveService.CloudSave

        Dim sql = "SELECT distinct ProcessEquip.ID, ProcessEquip.ProcessID, ProcessEquip.EquipmentID FROM ProcessEquip INNER JOIN Equipment ON Equipment.EquipmentId = ProcessEquip.EquipmentID WHERE Equipment.ProjectId='" & projectID & "'"
        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                CloudSaveWS.CopyProcessEquipRecord(cloudID, rdr("ID").ToString, rdr("ProcessID").ToString, rdr("EquipmentID").ToString)
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try
    End Sub

    Private Sub CopyEquipmentOptionsRecord(ByVal cloudID As Integer)

        Dim projectID As String = OpenedProject.ProjectId.ToString
        Dim CloudSaveWS As New CloudSaveService.CloudSave

        Dim sql = "select DISTINCT Id, EquipmentOptions.Revision, PricingId, EquipmentOptions.EquipmentId, EquipmentOptions.Quantity         from EquipmentOptions  inner join Equipment on Equipment.EquipmentID = EquipmentOptions.EquipmentID where Equipment.ProjectID =  '" & projectID & "'"
        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                CloudSaveWS.CopyEquipmentOptionsRecord(cloudID, IIf(IsDBNull(rdr("Id")), 0, rdr("Id")), IIf(IsDBNull(rdr("Revision")), 0, rdr("Revision")), IIf(IsDBNull(rdr("PricingId")), 0, rdr("PricingId")), rdr("EquipmentId").ToString, IIf(IsDBNull(rdr("Quantity")), 0, rdr("Quantity")))
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try
    End Sub


    Private Sub CopySpecialOptionsRecord(ByVal cloudID As Integer)

        Dim projectID As String = OpenedProject.ProjectId.ToString
        Dim CloudSaveWS As New CloudSaveService.CloudSave

        Dim sql = "select DISTINCT Id, SpecialOptions.Revision, SpecialOptions.EquipmentId, Code, Description, SpecialOptions.Quantity, Price, AuthorizedFor, AuthorizedBy         from SpecialOptions inner join Equipment on Equipment.EquipmentID = SpecialOptions.EquipmentID where Equipment.ProjectID =  '" & projectID & "'"
        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                CloudSaveWS.CopySpecialOptionsRecord(cloudID, IIf(IsDBNull(rdr("Id")), 0, rdr("Id")), IIf(IsDBNull(rdr("Revision")), 0, rdr("Revision")), rdr("EquipmentId").ToString, rdr("Code").ToString, rdr("Description").ToString, IIf(IsDBNull(rdr("Quantity")), 0, rdr("Quantity")), IIf(IsDBNull(rdr("Price")), 0, rdr("Price")), rdr("AuthorizedFor").ToString, rdr("AuthorizedBy").ToString)
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try
    End Sub


    Private Sub CopyProductCoolerRecord(ByVal cloudID As Integer)

        Dim projectID As String = OpenedProject.ProjectId.ToString
        Dim CloudSaveWS As New CloudSaveService.CloudSave

        'Dim sql = "select ProductCooler.EquipmentId, ProductCooler.Revision, Capacity, EvaporatorTemp, BoxTemp, TempDifference, CondensingTemp, LiquidTemp, Refrigerant from ProductCooler inner join Equipment on Equipment.EquipmentID = ProductCooler.EquipmentID where Equipment.ProjectID = '" & projectID & "' and TypeTableName = 'ProductCooler'"
        Dim sql = "select ProductCooler.EquipmentId, ProductCooler.Revision, Capacity, EvaporatorTemp, BoxTemp, TempDifference, CondensingTemp, LiquidTemp, Refrigerant from ProductCooler inner join Equipment on Equipment.EquipmentID = ProductCooler.EquipmentID WHERE ProductCooler.EquipmentID IN (SELECT EQUIPMENT.EquipmentID FROM Equipment where Equipment.ProjectID='" & projectID & "' AND Equipment.[TypeTableName]='ProductCooler')"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                CloudSaveWS.CopyProductCoolerRecord(cloudID, rdr("EquipmentId").ToString, IIf(IsDBNull(rdr("Revision")), 0, rdr("Revision")), IIf(IsDBNull(rdr("Capacity")), 0, rdr("Capacity")), IIf(IsDBNull(rdr("EvaporatorTemp")), 0, rdr("EvaporatorTemp")), IIf(IsDBNull(rdr("BoxTemp")), 0, rdr("BoxTemp")), IIf(IsDBNull(rdr("TempDifference")), 0, rdr("TempDifference")), IIf(IsDBNull(rdr("CondensingTemp")), 0, rdr("CondensingTemp")), IIf(IsDBNull(rdr("LiquidTemp")), 0, rdr("LiquidTemp")), rdr("Refrigerant").ToString)
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try
    End Sub




    Private Sub CopyPumpPackageRecord(ByVal cloudID As Integer)

        Dim projectID As String = OpenedProject.ProjectId.ToString
        Dim CloudSaveWS As New CloudSaveService.CloudSave

        'Dim sql = "select PumpPackage.EquipmentId, PumpPackage.Revision, Manufacturer, Flow, Head, System, ChillerId from PumpPackage inner join Equipment on Equipment.EquipmentID = PumpPackage.EquipmentID where Equipment.ProjectID = '" & projectID & "' and TypeTableName = 'PumpPackage'"
        Dim sql = "select PumpPackage.EquipmentId, PumpPackage.Revision, Manufacturer, Flow, Head, System, ChillerId from PumpPackage inner join Equipment on Equipment.EquipmentID = PumpPackage.EquipmentID WHERE PumpPackage.EquipmentID IN (SELECT EQUIPMENT.EquipmentID FROM Equipment where Equipment.ProjectID='" & projectID & "' AND Equipment.[TypeTableName]='PumpPackage')"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                CloudSaveWS.CopyPumpPackageRecord(cloudID, rdr("EquipmentId").ToString, IIf(IsDBNull(rdr("Revision")), 0, rdr("Revision")), rdr("Manufacturer").ToString, IIf(IsDBNull(rdr("Flow")), 0, rdr("Flow")), IIf(IsDBNull(rdr("Head")), 0, rdr("Head")), rdr("System").ToString, rdr("ChillerId").ToString)
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try
    End Sub



    Private Sub CopyUnitCoolerRecord(ByVal cloudID As Integer)

        Dim projectID As String = OpenedProject.ProjectId.ToString
        Dim CloudSaveWS As New CloudSaveService.CloudSave


        '

        '        Dim sql = "select UnitCooler.EquipmentId, EvaporatorTemp, BoxTemp, CondensingTemp, TempDifference, LiquidTemp, Capacity, Refrigerant, UnitCooler.Revision, DefrostVoltage, FanVoltage, UnitCoolerType from UnitCooler inner join Equipment on Equipment.EquipmentID = UnitCooler.EquipmentID where Equipment.ProjectID = '" & projectID & "' and TypeTableName = 'UnitCooler'"
        Dim sql = "SELECT UnitCooler.EquipmentId, UnitCooler.EvaporatorTemp, UnitCooler.BoxTemp, UnitCooler.CondensingTemp, UnitCooler.TempDifference, UnitCooler.LiquidTemp, UnitCooler.Capacity, UnitCooler.Refrigerant, UnitCooler.Revision, UnitCooler.DefrostVoltage, UnitCooler.FanVoltage, UnitCooler.UnitCoolerType FROM UnitCooler WHERE UnitCooler.EquipmentID IN (SELECT EQUIPMENT.EquipmentID FROM Equipment where  Equipment.ProjectID='" & projectID & "' AND Equipment.[TypeTableName]='UnitCooler')"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                Dim eqID As String = rdr("EquipmentID").ToString()
                CloudSaveWS.CopyUnitCoolerRecord(cloudID, eqID, IIf(IsDBNull(rdr("EvaporatorTemp")), 0, rdr("EvaporatorTemp")), IIf(IsDBNull(rdr("BoxTemp")), 0, rdr("BoxTemp")), IIf(IsDBNull(rdr("CondensingTemp")), 0, rdr("CondensingTemp")), IIf(IsDBNull(rdr("TempDifference")), 0, rdr("TempDifference")), IIf(IsDBNull(rdr("LiquidTemp")), 0, rdr("LiquidTemp")), IIf(IsDBNull(rdr("Capacity")), 0, rdr("Capacity")), rdr("Refrigerant").ToString, IIf(IsDBNull(rdr("Revision")), 0, rdr("Revision")), rdr("DefrostVoltage").ToString, rdr("FanVoltage").ToString, rdr("UnitCoolerType").ToString)
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try
    End Sub


    Private Sub CopyCondensingUnitRecord(ByVal cloudID As Integer)

        Dim projectID As String = OpenedProject.ProjectId.ToString
        Dim CloudSaveWS As New CloudSaveService.CloudSave

        'Dim sql = "select CondensingUnit.EquipmentId, CondensingUnit.Revision, AmbientTemp, SuctionTemp, Refrigerant, Circuit1Capacity, Circuit2Capacity, Circuit3Capacity, Circuit4Capacity, EvapTemp, Efficiency from CondensingUnit inner join Equipment on Equipment.EquipmentID = CondensingUnit.EquipmentID and CondensingUnit.Revision = Equipment.Revision where Equipment.ProjectID = '" & projectID & "' and TypeTableName = 'CondensingUnit'"
        Dim sql = "select CondensingUnit.EquipmentId, CondensingUnit.Revision, AmbientTemp, SuctionTemp, Refrigerant, Circuit1Capacity, Circuit2Capacity, Circuit3Capacity, Circuit4Capacity, EvapTemp, Efficiency from CondensingUnit inner join Equipment on Equipment.EquipmentID = CondensingUnit.EquipmentID and CondensingUnit.Revision = Equipment.Revision WHERE CondensingUnit.EquipmentID IN (SELECT EQUIPMENT.EquipmentID FROM Equipment where Equipment.ProjectID='" & projectID & "' AND Equipment.[TypeTableName]='CondensingUnit')"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                CloudSaveWS.CopyCondensingUnitRecord(cloudID, rdr("EquipmentId").ToString, IIf(IsDBNull(rdr("Revision")), 0, rdr("Revision")), IIf(IsDBNull(rdr("AmbientTemp")), 0, rdr("AmbientTemp")), IIf(IsDBNull(rdr("SuctionTemp")), 0, rdr("SuctionTemp")), rdr("Refrigerant").ToString, IIf(IsDBNull(rdr("Circuit1Capacity")), 0, rdr("Circuit1Capacity")), IIf(IsDBNull(rdr("Circuit2Capacity")), 0, rdr("Circuit2Capacity")), IIf(IsDBNull(rdr("Circuit3Capacity")), 0, rdr("Circuit3Capacity")), IIf(IsDBNull(rdr("Circuit4Capacity")), 0, rdr("Circuit4Capacity")), IIf(IsDBNull(rdr("EvapTemp")), 0, rdr("EvapTemp")), IIf(IsDBNull(rdr("Efficiency")), 0, rdr("Efficiency")))
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try
    End Sub

    Private Sub CopyCondenserRecord(ByVal cloudID As Integer)

        Dim projectID As String = OpenedProject.ProjectId.ToString
        Dim CloudSaveWS As New CloudSaveService.CloudSave

        'Dim sql = "select Condenser.EquipmentId, Condenser.Revision, AmbientTemp, Refrigerant, ThrCircuit1, ThrCircuit2, ThrCircuit3, ThrCircuit4, TempDifference, Fpi, SubCooling from Condenser inner join Equipment on Equipment.EquipmentID = Condenser.EquipmentID and (Condenser.Revision = Equipment.Revision) where Equipment.ProjectID = '" & projectID & "' and TypeTableName = 'Condenser'"
        Dim sql = "select Condenser.EquipmentId, Condenser.Revision, AmbientTemp, Refrigerant, ThrCircuit1, ThrCircuit2, ThrCircuit3, ThrCircuit4, TempDifference, Fpi, SubCooling from Condenser inner join Equipment on Equipment.EquipmentID = Condenser.EquipmentID and (Condenser.Revision = Equipment.Revision) WHERE Condenser.EquipmentID IN (SELECT EQUIPMENT.EquipmentID FROM Equipment where Equipment.ProjectID='" & projectID & "' AND Equipment.[TypeTableName]='Condenser')"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                CloudSaveWS.CopyCondenserRecord(cloudID, rdr("EquipmentId").ToString, IIf(IsDBNull(rdr("Revision")), 0, rdr("Revision")), IIf(IsDBNull(rdr("AmbientTemp")), 0, rdr("AmbientTemp")), rdr("Refrigerant").ToString, IIf(IsDBNull(rdr("ThrCircuit1")), 0, rdr("ThrCircuit1")), IIf(IsDBNull(rdr("ThrCircuit2")), 0, rdr("ThrCircuit2")), IIf(IsDBNull(rdr("ThrCircuit3")), 0, rdr("ThrCircuit3")), IIf(IsDBNull(rdr("ThrCircuit4")), 0, rdr("ThrCircuit4")), IIf(IsDBNull(rdr("TempDifference")), 0, rdr("TempDifference")), IIf(IsDBNull(rdr("Fpi")), 0, rdr("Fpi")), IIf(IsDBNull(rdr("SubCooling")), False, rdr("SubCooling")))
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try
    End Sub



    Private Sub CopyFluidCoolerRecord(ByVal cloudID As Integer)

        Dim projectID As String = OpenedProject.ProjectId.ToString
        Dim CloudSaveWS As New CloudSaveService.CloudSave

        'Dim sql = "select FluidCooler.EquipmentId, FluidCooler.Revision, Capacity, AmbientTemp, EnteringFluidTemp, LeavingFluidTemp, GlycolPercent, Fluid, Flow, Refrigerant from FluidCooler inner join Equipment on Equipment.EquipmentID = FluidCooler.EquipmentID where Equipment.ProjectID = '" & projectID & "' and TypeTableName = 'FluidCooler'"
        Dim sql = "select FluidCooler.EquipmentId, FluidCooler.Revision, Capacity, AmbientTemp, EnteringFluidTemp, LeavingFluidTemp, GlycolPercent, Fluid, Flow, Refrigerant from FluidCooler inner join Equipment on Equipment.EquipmentID = FluidCooler.EquipmentID WHERE FluidCooler.EquipmentID IN (SELECT EQUIPMENT.EquipmentID FROM Equipment where Equipment.ProjectID='" & projectID & "' AND Equipment.[TypeTableName]='FluidCooler')"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                CloudSaveWS.CopyFluidCoolerRecord(cloudID, rdr("EquipmentId").ToString, IIf(IsDBNull(rdr("Revision")), 0, rdr("Revision")), IIf(IsDBNull(rdr("Capacity")), 0, rdr("Capacity")), IIf(IsDBNull(rdr("AmbientTemp")), 0, rdr("AmbientTemp")), IIf(IsDBNull(rdr("EnteringFluidTemp")), 0, rdr("EnteringFluidTemp")), IIf(IsDBNull(rdr("LeavingFluidTemp")), 0, rdr("LeavingFluidTemp")), IIf(IsDBNull(rdr("GlycolPercent")), 0, rdr("GlycolPercent")), rdr("Fluid").ToString, IIf(IsDBNull(rdr("Flow")), 0, rdr("Flow")), rdr("Refrigerant").ToString)
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try
    End Sub


    Private Sub CopyChillerRecord(ByVal cloudID As Integer)

        Dim projectID As String = OpenedProject.ProjectId.ToString
        Dim CloudSaveWS As New CloudSaveService.CloudSave

        'Dim sql = "select Chiller.EquipmentId,  Chiller.Revision, Capacity, AmbientTemp, EnteringFluidTemp, LeavingFluidTemp, GlycolPercent, Fluid, Flow, Refrigerant, EvaporatorPressureDrop, UnitKwPerTon, CompressorAmps1, CompressorAmps2, CompressorQuantity1, CompressorQuantity2, CondenserQuantity, SprayPumpAmps, BlowerAmps, HasBalance from Chiller inner join Equipment on Equipment.EquipmentID = Chiller.EquipmentID where Equipment.ProjectID = '" & projectID & "' and TypeTableName = 'Chiller'"
        Dim sql = "select Chiller.EquipmentId,  Chiller.Revision, Capacity, AmbientTemp, EnteringFluidTemp, LeavingFluidTemp, GlycolPercent, Fluid, Flow, Refrigerant, EvaporatorPressureDrop, UnitKwPerTon, CompressorAmps1, CompressorAmps2, CompressorQuantity1, CompressorQuantity2, CondenserQuantity, SprayPumpAmps, BlowerAmps, HasBalance from Chiller inner join Equipment on Equipment.EquipmentID = Chiller.EquipmentID WHERE Chiller.EquipmentID IN (SELECT EQUIPMENT.EquipmentID FROM Equipment where Equipment.ProjectID='" & projectID & "' AND Equipment.[TypeTableName]='Chiller')"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                CloudSaveWS.CopyChillerRecord(cloudID, rdr("EquipmentId").ToString, IIf(IsDBNull(rdr("Revision")), 0, rdr("Revision")), IIf(IsDBNull(rdr("Capacity")), 0, rdr("Capacity")), IIf(IsDBNull(rdr("AmbientTemp")), 0, rdr("AmbientTemp")), IIf(IsDBNull(rdr("EnteringFluidTemp")), 0, rdr("EnteringFluidTemp")), IIf(IsDBNull(rdr("LeavingFluidTemp")), 0, rdr("LeavingFluidTemp")), IIf(IsDBNull(rdr("GlycolPercent")), 0, rdr("GlycolPercent")), rdr("Fluid").ToString, IIf(IsDBNull(rdr("Flow")), 0, rdr("Flow")), rdr("Refrigerant").ToString, IIf(IsDBNull(rdr("EvaporatorPressureDrop")), 0, rdr("EvaporatorPressureDrop")), rdr("UnitKwPerTon").ToString, IIf(IsDBNull(rdr("CompressorAmps1")), 0, rdr("CompressorAmps1")), IIf(IsDBNull(rdr("CompressorAmps2")), 0, rdr("CompressorAmps2")), IIf(IsDBNull(rdr("CompressorQuantity1")), 0, rdr("CompressorQuantity1")), IIf(IsDBNull(rdr("CompressorQuantity2")), 0, rdr("CompressorQuantity2")), IIf(IsDBNull(rdr("CondenserQuantity")), 0, rdr("CondenserQuantity")), IIf(IsDBNull(rdr("SprayPumpAmps")), 0, rdr("SprayPumpAmps")), IIf(IsDBNull(rdr("BlowerAmps")), 0, rdr("BlowerAmps")), IIf(IsDBNull(rdr("HasBalance")), False, rdr("HasBalance")))
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try
    End Sub









    Private Sub CopyProjectsRecord(ByVal cloudID As Integer)

        Dim projectID As String = OpenedProject.ProjectId.ToString
        Dim CloudSaveWS As New CloudSaveService.CloudSave

        Dim sql = "select ProjectId, ProjectRevision, Name, Notes, Tag, ReleaseStatus, ReleaseNum, HoursBeforeDeliveryToCall, PoNum, PoDate, RequestedShipDate, SalesClass, RepId, ArchitectName, ContractorName, EngineerName, RepCompanyId, ArchitectCompanyName, ContractorCompanyName, EngineerCompanyName, Description, ContactDataStructure, ProjectOwner, OpenedBy, CheckedOutBy, RevisionDate from Projects where ProjectID = '" & projectID & "'"
        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                CloudSaveWS.CopyProjectsRecord(cloudID, projectID, rdr("ProjectRevision").ToString, rdr("Name").ToString, rdr("Notes").ToString, rdr("Tag").ToString, rdr("ReleaseStatus").ToString, IIf(IsDBNull(rdr("ReleaseNum")), 0, rdr("ReleaseNum")), IIf(IsDBNull(rdr("HoursBeforeDeliveryToCall")), 0, rdr("HoursBeforeDeliveryToCall")), IIf(IsDBNull(rdr("PONum")), 0, rdr("PONum")), IIf(IsDBNull(rdr("PODate")), "1/1/1900", rdr("PODate")), IIf(IsDBNull(rdr("RequestedShipDate")), "1/1/1900", rdr("RequestedShipDate")), rdr("SalesClass").ToString, IIf(IsDBNull(rdr("RepID")), 0, rdr("RepID")), rdr("ArchitectName").ToString, rdr("ContractorName").ToString, rdr("EngineerName").ToString, IIf(IsDBNull(rdr("RepCompanyID")), 0, rdr("RepCompanyID")), rdr("ArchitectCompanyName").ToString, rdr("ContractorCompanyName").ToString, rdr("EngineerCompanyName").ToString, rdr("Description").ToString, rdr("ContactDataStructure").ToString, rdr("ProjectOwner").ToString, rdr("OpenedBy").ToString, rdr("CheckedOutBy").ToString, IIf(IsDBNull(rdr("RevisionDate")), "1/1/1900", rdr("RevisionDate")))
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try
    End Sub



    Private Sub CopyProcessesRecord(ByVal cloudID As Integer)

        Dim projectID As String = OpenedProject.ProjectId.ToString

        Dim CloudSaveWS As New CloudSaveService.CloudSave


        Dim sql = "select ID, ProjectId, ProcessTableName from Processes where ProjectID = '" & projectID & "'"
        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                CloudSaveWS.CopyProcessesRecord(cloudID, rdr("ID"), rdr("projectID"), rdr("ProcessTableName").ToString)
            End While


        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try


    End Sub


    Private Sub CopyEquipmentRecord(ByVal cloudID As Integer)

        Dim projectID As String = OpenedProject.ProjectId.ToString

        Dim CloudSaveWS As New CloudSaveService.CloudSave


        Dim sql = "select ProjectId, ProjectRevision, EquipmentId, Revision, Name, TypeTableName, Division, Author, Series, Model, Quantity, ParMultiplier, WarrantyPrice, FreightPrice, StartUpPrice, CommissionRate, UnitVoltage, ControlVoltage, Length, Width, Height, Mca, Rla, Altitude, Notes, Tag, ShippingWeight, OperatingWeight, Included, OtherPrice, OtherDescription, CustomModel, OverriddenBaseListPrice, ShouldOverrideBaseListPrice, MultiplierCode, MultiplierType, ListPosition from Equipment where ProjectID = '" & projectID & "'"
        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                CloudSaveWS.CopyEquipmentRecord3(cloudID, projectID, IIf(IsDBNull(rdr("ProjectRevision")), 0, rdr("ProjectRevision")), rdr("EquipmentID").ToString, IIf(IsDBNull(rdr("Revision")), 0, rdr("Revision")), rdr("Name").ToString, rdr("TypeTableName").ToString, rdr("Division").ToString, rdr("Author").ToString, rdr("Series").ToString, rdr("Model").ToString, IIf(IsDBNull(rdr("Quantity")), 0, rdr("Quantity")), IIf(IsDBNull(rdr("ParMultiplier")), 0, rdr("ParMultiplier")), IIf(IsDBNull(rdr("WarrantyPrice")), 0, rdr("WarrantyPrice")), IIf(IsDBNull(rdr("FreightPrice")), 0, rdr("FreightPrice")), IIf(IsDBNull(rdr("StartUpPrice")), 0, rdr("StartUpPrice")), IIf(IsDBNull(rdr("CommissionRate")), 0, rdr("CommissionRate")), rdr("UnitVoltage").ToString, rdr("ControlVoltage").ToString, IIf(IsDBNull(rdr("Length")), 0, rdr("Length")), IIf(IsDBNull(rdr("Width")), 0, rdr("Width")), IIf(IsDBNull(rdr("Height")), 0, rdr("Height")), IIf(IsDBNull(rdr("Mca")), 0, rdr("Mca")), IIf(IsDBNull(rdr("Rla")), 0, rdr("Rla")), IIf(IsDBNull(rdr("Altitude")), 0, rdr("Altitude")), rdr("Notes").ToString, rdr("Tag").ToString, IIf(IsDBNull(rdr("ShippingWeight")), 0, rdr("ShippingWeight")), IIf(IsDBNull(rdr("OperatingWeight")), 0, rdr("OperatingWeight")), IIf(IsDBNull(rdr("Included")), False, rdr("Included")), IIf(IsDBNull(rdr("OtherPrice")), 0, rdr("OtherPrice")), rdr("OtherDescription").ToString, rdr("CustomModel").ToString, IIf(IsDBNull(rdr("OverriddenBaseListPrice")), 0, rdr("OverriddenBaseListPrice")), IIf(IsDBNull(rdr("ShouldOverrideBaseListPrice")), False, rdr("ShouldOverrideBaseListPrice")), rdr("MultiplierCode").ToString, rdr("MultiplierType").ToString, IIf(IsDBNull(rdr("ListPosition")), 0, rdr("ListPosition")))
            End While
        Catch ex As Exception
            Dim one As Integer = 1
            CloudSaveWS.sendErrorEmail("Error Copying Records to Cloud", ex.Message)
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try


    End Sub


    Private Sub CopyACChillerProcessesRecord(ByVal cloudID As Integer)

        Dim projectID As String = OpenedProject.ProjectId.ToString
        Dim CloudSaveWS As New CloudSaveService.CloudSave

        'Dim sql = "select ProcessID, Revision, RevisionDate, ProjectRevision, ProcessRevisionDescription, CreatedBy, Version, Notes, Name, Series, NewCoefficients, Model, ModelDesc, Fluid, GlycolPercentage, CoolingMedia, SpecificHeat, SpecificGravity, SubCooling, Refrigerant, TempRange, AmbientTemp, LeavingFluidTemp, System, Hertz, Volts, Approach, SafetyOverride, Circuit1, Circuit2, NumCompressors1, NumCompressors2, Compressors1, Compressors2, NumCoils1, NumCoils2, Condenser1, Condenser2, FinsPerInch1, FinsPerInch2, SubCooling1, SubCooling2, SubCoolingPercent1, SubCoolingPercent2, CondenserTD1, CondenserTD2, FinHeight1, FinHeight2, FinLength1, FinLength2, DischargeLineLoss, SuctionLineLoss, Altitude, Fan, CfmOverride, NumFans1, NumFans2, CondenserCapacity1, CondenserCapacity2, EvaporatorModel, EvaporatorModelDesc, NumEvap, FoulingFactor, CapacityType, EvaporatorCapacity, CatalogRating, ApproachRange, Evap8Degr1, Evap8Degr2, Evap10Degr1, Evap10Degr2, Division, FanWatts         from ACChillerProcesses inner join Processes on Processes.ID = ACChillerProcesses.ProcessID  where ProjectID = '" & projectID & "' and ProcessTableName = 'ACChillerProcesses'"
        Dim sql = "select ProcessID, Revision, RevisionDate, ProjectRevision, ProcessRevisionDescription, CreatedBy, Version, Notes, Name, Series, NewCoefficients, Model, ModelDesc, Fluid, GlycolPercentage, CoolingMedia, SpecificHeat, SpecificGravity, SubCooling, Refrigerant, TempRange, AmbientTemp, LeavingFluidTemp, System, Hertz, Volts, Approach, SafetyOverride, Circuit1, Circuit2, NumCompressors1, NumCompressors2, Compressors1, Compressors2, NumCoils1, NumCoils2, Condenser1, Condenser2, FinsPerInch1, FinsPerInch2, SubCooling1, SubCooling2, SubCoolingPercent1, SubCoolingPercent2, CondenserTD1, CondenserTD2, FinHeight1, FinHeight2, FinLength1, FinLength2, DischargeLineLoss, SuctionLineLoss, Altitude, Fan, CfmOverride, NumFans1, NumFans2, CondenserCapacity1, CondenserCapacity2, EvaporatorModel, EvaporatorModelDesc, NumEvap, FoulingFactor, CapacityType, EvaporatorCapacity, CatalogRating, ApproachRange, Evap8Degr1, Evap8Degr2, Evap10Degr1, Evap10Degr2, Division, FanWatts         from ACChillerProcesses inner join Processes on Processes.ID = ACChillerProcesses.ProcessID WHERE ACChillerProcesses.ProcessID IN (SELECT PROCESSES.ID FROM pROCESSES where PROCESSES.PROJECTID='" & projectID & "' AND PROCESSES.[PROCESSTableName]='ACChillerProcesses')"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                CloudSaveWS.CopyACChillerProcessesRecord(cloudID, rdr("ProcessID").ToString, IIf(IsDBNull(rdr("Revision")), 0, rdr("Revision")), IIf(IsDBNull(rdr("RevisionDate")), "1/1/1990", rdr("RevisionDate")), IIf(IsDBNull(rdr("ProjectRevision")), 0, rdr("ProjectRevision")), rdr("ProcessRevisionDescription").ToString, rdr("CreatedBy").ToString, rdr("Version").ToString, rdr("Notes").ToString, rdr("Name").ToString, rdr("Series").ToString, IIf(IsDBNull(rdr("NewCoefficients")), False, rdr("NewCoefficients")), rdr("Model").ToString, rdr("ModelDesc").ToString, rdr("Fluid").ToString, IIf(IsDBNull(rdr("GlycolPercentage")), 0, rdr("GlycolPercentage")), rdr("CoolingMedia").ToString, IIf(IsDBNull(rdr("SpecificHeat")), 0, rdr("SpecificHeat")), IIf(IsDBNull(rdr("SpecificGravity")), 0, rdr("SpecificGravity")), IIf(IsDBNull(rdr("SubCooling")), False, rdr("SubCooling")), rdr("Refrigerant").ToString, IIf(IsDBNull(rdr("TempRange")), 0, rdr("TempRange")), IIf(IsDBNull(rdr("AmbientTemp")), 0, rdr("AmbientTemp")), IIf(IsDBNull(rdr("LeavingFluidTemp")), 0, rdr("LeavingFluidTemp")), rdr("System").ToString, IIf(IsDBNull(rdr("Hertz")), 0, rdr("Hertz")), IIf(IsDBNull(rdr("Volts")), 0, rdr("Volts")), rdr("Approach").ToString, IIf(IsDBNull(rdr("SafetyOverride")), False, rdr("SafetyOverride")), IIf(IsDBNull(rdr("Circuit1")), False, rdr("Circuit1")), IIf(IsDBNull(rdr("Circuit2")), False, rdr("Circuit2")), IIf(IsDBNull(rdr("NumCompressors1")), 0, rdr("NumCompressors1")), IIf(IsDBNull(rdr("NumCompressors2")), 0, rdr("NumCompressors2")), rdr("Compressors1").ToString, rdr("Compressors2").ToString, IIf(IsDBNull(rdr("NumCoils1")), 0, rdr("NumCoils1")), IIf(IsDBNull(rdr("NumCoils2")), 0, rdr("NumCoils2")), rdr("Condenser1").ToString, rdr("Condenser2").ToString, IIf(IsDBNull(rdr("FinsPerInch1")), 0, rdr("FinsPerInch1")), IIf(IsDBNull(rdr("FinsPerInch2")), 0, rdr("FinsPerInch2")), IIf(IsDBNull(rdr("SubCooling1")), False, rdr("SubCooling1")), IIf(IsDBNull(rdr("SubCooling2")), False, rdr("SubCooling2")), IIf(IsDBNull(rdr("SubCoolingPercent1")), 0, rdr("SubCoolingPercent1")), IIf(IsDBNull(rdr("SubCoolingPercent2")), 0, rdr("SubCoolingPercent2")), IIf(IsDBNull(rdr("CondenserTD1")), 0, rdr("CondenserTD1")), IIf(IsDBNull(rdr("CondenserTD2")), 0, rdr("CondenserTD2")), IIf(IsDBNull(rdr("FinHeight1")), 0, rdr("FinHeight1")), IIf(IsDBNull(rdr("FinHeight2")), 0, rdr("FinHeight2")), IIf(IsDBNull(rdr("FinLength1")), 0, rdr("FinLength1")), IIf(IsDBNull(rdr("FinLength2")), 0, rdr("FinLength2")), IIf(IsDBNull(rdr("DischargeLineLoss")), 0, rdr("DischargeLineLoss")), IIf(IsDBNull(rdr("SuctionLineLoss")), 0, rdr("SuctionLineLoss")), IIf(IsDBNull(rdr("Altitude")), 0, rdr("Altitude")), rdr("Fan").ToString, IIf(IsDBNull(rdr("CfmOverride")), 0, rdr("CfmOverride")), IIf(IsDBNull(rdr("NumFans1")), 0, rdr("NumFans1")), IIf(IsDBNull(rdr("NumFans2")), 0, rdr("NumFans2")), IIf(IsDBNull(rdr("CondenserCapacity1")), 0, rdr("CondenserCapacity1")), IIf(IsDBNull(rdr("CondenserCapacity2")), 0, rdr("CondenserCapacity2")), rdr("EvaporatorModel").ToString, rdr("EvaporatorModelDesc").ToString, IIf(IsDBNull(rdr("NumEvap")), 0, rdr("NumEvap")), IIf(IsDBNull(rdr("FoulingFactor")), 0, rdr("FoulingFactor")), rdr("CapacityType").ToString, IIf(IsDBNull(rdr("EvaporatorCapacity")), 0, rdr("EvaporatorCapacity")), IIf(IsDBNull(rdr("CatalogRating")), False, rdr("CatalogRating")), rdr("ApproachRange").ToString, IIf(IsDBNull(rdr("Evap8Degr1")), 0, rdr("Evap8Degr1")), IIf(IsDBNull(rdr("Evap8Degr2")), 0, rdr("Evap8Degr2")), IIf(IsDBNull(rdr("Evap10Degr1")), 0, rdr("Evap10Degr1")), IIf(IsDBNull(rdr("Evap10Degr2")), 0, rdr("Evap10Degr2")), rdr("Division").ToString, IIf(IsDBNull(rdr("FanWatts")), 0, rdr("FanWatts")))
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try
    End Sub


    Private Sub CopyCondensingUnitProcessesRecord(ByVal cloudID As Integer)

        Dim projectID As String = OpenedProject.ProjectId.ToString
        Dim CloudSaveWS As New CloudSaveService.CloudSave

        'Dim sql = "select ProcessID, Revision, RevisionDate, ProjectRevision, ProcessRevisionDescription, CreatedBy, Version, Notes, Name, CondensingUnitSeries, Capacity, RunTimeAdjust, CondensingUnitsRequired, RunTime, AmbientTemperature, SuctionTemperature, Refrigerant, Compressor, CompressorPerUnit, CircuitsPerUnit, Altitude, RunType, NoCondensingUnits, CondensingUnitModel, CustomCondensingUnitModel, RatingAmbient, RatingAmbientInterval, RatingAmbientStep, RatingSuction, RatingSuctionInterval, RatingSuctionStep, RatingRefrigerant, RatingAltitude, RatingSubCooling, RatingCatalog, RatingHertz, RatingSafety, Compressor1, Compressor2, Compressor3, Compressor4, CompressorQuantity1, CompressorQuantity2, CompressorQuantity3, CompressorQuantity4, FinHeight1, FinHeight2, FinHeight3, FinHeight4, CoilFinWidth1, CoilFinWidth2, CoilFinWidth3, CoilFinWidth4, CoilRows1, CoilRows2, CoilRows3, CoilRows4, CoilSubCoolingPercentage1, CoilSubCoolingPercentage2, CoilSubCoolingPercentage3, CoilSubCoolingPercentage4, FinsPerInch1, FinsPerInch2, FinsPerInch3, FinsPerInch4, FanDia1, FanDia2, FanDia3, FanDia4, FanQuantity1, FanQuantity2, FanQuantity3, FanQuantity4, Division, Voltage, Use10Coefficients, TubeDiameter1, TubeDiameter2, TubeDiameter3, TubeDiameter4, TubeSurface1, TubeSurface2, TubeSurface3, TubeSurface4, FinType1, FinType2, FinType3, FinType4         from CondensingUnitProcesses  inner join Processes on Processes.ID = CondensingUnitProcesses.ProcessID  where ProjectID = '" & projectID & "' and ProcessTableName = 'CondensingUnitProcesses'"
        Dim sql = "select ProcessID, Revision, RevisionDate, ProjectRevision, ProcessRevisionDescription, CreatedBy, Version, Notes, Name, CondensingUnitSeries, Capacity, RunTimeAdjust, CondensingUnitsRequired, RunTime, AmbientTemperature, SuctionTemperature, Refrigerant, Compressor, CompressorPerUnit, CircuitsPerUnit, Altitude, RunType, NoCondensingUnits, CondensingUnitModel, CustomCondensingUnitModel, RatingAmbient, RatingAmbientInterval, RatingAmbientStep, RatingSuction, RatingSuctionInterval, RatingSuctionStep, RatingRefrigerant, RatingAltitude, RatingSubCooling, RatingCatalog, RatingHertz, RatingSafety, Compressor1, Compressor2, Compressor3, Compressor4, CompressorQuantity1, CompressorQuantity2, CompressorQuantity3, CompressorQuantity4, FinHeight1, FinHeight2, FinHeight3, FinHeight4, CoilFinWidth1, CoilFinWidth2, CoilFinWidth3, CoilFinWidth4, CoilRows1, CoilRows2, CoilRows3, CoilRows4, CoilSubCoolingPercentage1, CoilSubCoolingPercentage2, CoilSubCoolingPercentage3, CoilSubCoolingPercentage4, FinsPerInch1, FinsPerInch2, FinsPerInch3, FinsPerInch4, FanDia1, FanDia2, FanDia3, FanDia4, FanQuantity1, FanQuantity2, FanQuantity3, FanQuantity4, Division, Voltage, Use10Coefficients, TubeDiameter1, TubeDiameter2, TubeDiameter3, TubeDiameter4, TubeSurface1, TubeSurface2, TubeSurface3, TubeSurface4, FinType1, FinType2, FinType3, FinType4, FanRPM1, FanRPM2, FanRPM3, FanRPM4, DOEModel         from CondensingUnitProcesses  inner join Processes on Processes.ID = CondensingUnitProcesses.ProcessID  WHERE CondensingUnitProcesses.ProcessID IN (SELECT PROCESSES.ID FROM pROCESSES where PROCESSES.PROJECTID='" & projectID & "' AND PROCESSES.[PROCESSTableName]='CondensingUnitProcesses')"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                CloudSaveWS.CopyCondensingUnitProcessesRecord(cloudID, rdr("ProcessID").ToString, IIf(IsDBNull(rdr("Revision")), 0, rdr("Revision")), IIf(IsDBNull(rdr("RevisionDate")), "1/1/1990", rdr("RevisionDate")), IIf(IsDBNull(rdr("ProjectRevision")), 0, rdr("ProjectRevision")), rdr("ProcessRevisionDescription").ToString, rdr("CreatedBy").ToString, rdr("Version").ToString, rdr("Notes").ToString, rdr("Name").ToString, rdr("CondensingUnitSeries").ToString, IIf(IsDBNull(rdr("Capacity")), 0, rdr("Capacity")), IIf(IsDBNull(rdr("RunTimeAdjust")), False, rdr("RunTimeAdjust")), IIf(IsDBNull(rdr("CondensingUnitsRequired")), 0, rdr("CondensingUnitsRequired")), IIf(IsDBNull(rdr("RunTime")), 0, rdr("RunTime")), IIf(IsDBNull(rdr("AmbientTemperature")), 0, rdr("AmbientTemperature")), IIf(IsDBNull(rdr("SuctionTemperature")), 0, rdr("SuctionTemperature")), rdr("Refrigerant").ToString, rdr("Compressor").ToString, IIf(IsDBNull(rdr("CompressorPerUnit")), 0, rdr("CompressorPerUnit")), IIf(IsDBNull(rdr("CircuitsPerUnit")), 0, rdr("CircuitsPerUnit")), IIf(IsDBNull(rdr("Altitude")), 0, rdr("Altitude")), rdr("RunType").ToString, IIf(IsDBNull(rdr("NoCondensingUnits")), False, rdr("NoCondensingUnits")), rdr("CondensingUnitModel").ToString, rdr("CustomCondensingUnitModel").ToString, IIf(IsDBNull(rdr("RatingAmbient")), 0, rdr("RatingAmbient")), IIf(IsDBNull(rdr("RatingAmbientInterval")), 0, rdr("RatingAmbientInterval")), IIf(IsDBNull(rdr("RatingAmbientStep")), 0, rdr("RatingAmbientStep")), IIf(IsDBNull(rdr("RatingSuction")), 0, rdr("RatingSuction")), IIf(IsDBNull(rdr("RatingSuctionInterval")), 0, rdr("RatingSuctionInterval")), IIf(IsDBNull(rdr("RatingSuctionStep")), 0, rdr("RatingSuctionStep")), rdr("RatingRefrigerant").ToString, IIf(IsDBNull(rdr("RatingAltitude")), 0, rdr("RatingAltitude")), IIf(IsDBNull(rdr("RatingSubCooling")), 0, rdr("RatingSubCooling")), IIf(IsDBNull(rdr("RatingCatalog")), False, rdr("RatingCatalog")), IIf(IsDBNull(rdr("RatingHertz")), 0, rdr("RatingHertz")), IIf(IsDBNull(rdr("RatingSafety")), False, rdr("RatingSafety")), rdr("Compressor1").ToString, rdr("Compressor2").ToString, rdr("Compressor3").ToString, rdr("Compressor4").ToString, IIf(IsDBNull(rdr("CompressorQuantity1")), 0, rdr("CompressorQuantity1")), IIf(IsDBNull(rdr("CompressorQuantity2")), 0, rdr("CompressorQuantity2")), IIf(IsDBNull(rdr("CompressorQuantity3")), 0, rdr("CompressorQuantity3")), IIf(IsDBNull(rdr("CompressorQuantity4")), 0, rdr("CompressorQuantity4")), IIf(IsDBNull(rdr("FinHeight1")), 0, rdr("FinHeight1")), IIf(IsDBNull(rdr("FinHeight2")), 0, rdr("FinHeight2")), IIf(IsDBNull(rdr("FinHeight3")), 0, rdr("FinHeight3")), IIf(IsDBNull(rdr("FinHeight4")), 0, rdr("FinHeight4")), IIf(IsDBNull(rdr("CoilFinWidth1")), 0, rdr("CoilFinWidth1")), IIf(IsDBNull(rdr("CoilFinWidth2")), 0, rdr("CoilFinWidth2")), IIf(IsDBNull(rdr("CoilFinWidth3")), 0, rdr("CoilFinWidth3")), IIf(IsDBNull(rdr("CoilFinWidth4")), 0, rdr("CoilFinWidth4")), IIf(IsDBNull(rdr("CoilRows1")), 0, rdr("CoilRows1")), IIf(IsDBNull(rdr("CoilRows2")), 0, rdr("CoilRows2")), IIf(IsDBNull(rdr("CoilRows3")), 0, rdr("CoilRows3")), IIf(IsDBNull(rdr("CoilRows4")), 0, rdr("CoilRows4")), IIf(IsDBNull(rdr("CoilSubCoolingPercentage1")), 0, rdr("CoilSubCoolingPercentage1")), IIf(IsDBNull(rdr("CoilSubCoolingPercentage2")), 0, rdr("CoilSubCoolingPercentage2")), IIf(IsDBNull(rdr("CoilSubCoolingPercentage3")), 0, rdr("CoilSubCoolingPercentage3")), IIf(IsDBNull(rdr("CoilSubCoolingPercentage4")), 0, rdr("CoilSubCoolingPercentage4")), IIf(IsDBNull(rdr("FinsPerInch1")), 0, rdr("FinsPerInch1")), IIf(IsDBNull(rdr("FinsPerInch2")), 0, rdr("FinsPerInch2")), IIf(IsDBNull(rdr("FinsPerInch3")), 0, rdr("FinsPerInch3")), IIf(IsDBNull(rdr("FinsPerInch4")), 0, rdr("FinsPerInch4")), rdr("FanDia1").ToString, rdr("FanDia2").ToString, rdr("FanDia3").ToString, rdr("FanDia4").ToString, IIf(IsDBNull(rdr("FanQuantity1")), 0, rdr("FanQuantity1")), IIf(IsDBNull(rdr("FanQuantity2")), 0, rdr("FanQuantity2")), IIf(IsDBNull(rdr("FanQuantity3")), 0, rdr("FanQuantity3")), IIf(IsDBNull(rdr("FanQuantity4")), 0, rdr("FanQuantity4")), rdr("Division").ToString, IIf(IsDBNull(rdr("Voltage")), 0, rdr("Voltage")), IIf(IsDBNull(rdr("Use10Coefficients")), False, rdr("Use10Coefficients")), IIf(IsDBNull(rdr("TubeDiameter1")), 0, rdr("TubeDiameter1")), IIf(IsDBNull(rdr("TubeDiameter2")), 0, rdr("TubeDiameter2")), IIf(IsDBNull(rdr("TubeDiameter3")), 0, rdr("TubeDiameter3")), IIf(IsDBNull(rdr("TubeDiameter4")), 0, rdr("TubeDiameter4")), rdr("TubeSurface1").ToString, rdr("TubeSurface2").ToString, rdr("TubeSurface3").ToString, rdr("TubeSurface4").ToString, rdr("FinType1").ToString, rdr("FinType2").ToString, rdr("FinType3").ToString, rdr("FinType4").ToString, IIf(IsDBNull(rdr("FanRPM1")), 0, rdr("FanRPM1")), IIf(IsDBNull(rdr("FanRPM2")), 0, rdr("FanRPM2")), IIf(IsDBNull(rdr("FanRPM3")), 0, rdr("FanRPM3")), IIf(IsDBNull(rdr("FanRPM4")), 0, rdr("FanRPM4")), IIf(IsDBNull(rdr("DOEModel")), "", rdr("DOEModel")))
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try
    End Sub

    Private Sub CopyOrderEntryContacts(ByVal cloudID As Integer)

        Dim projectID As String = OpenedProject.ProjectId.ToString
        Dim CloudSaveWS As New CloudSaveService.CloudSave

        'Dim sql = "select ProcessID, Revision, RevisionDate, ProjectRevision, ProcessRevisionDescription, CreatedBy, Version, Notes, Name, Series, NewCoefficients, Model, ModelDesc, Fluid, GlycolPercentage, CoolingMedia, SpecificHeat, SpecificGravity, SubCooling, Refrigerant, TempRange, AmbientTemp, LeavingFluidTemp, System, Hertz, Volts, Approach, SafetyOverride, Circuit1, Circuit2, NumCompressors1, NumCompressors2, Compressors1, Compressors2, NumCoils1, NumCoils2, Condenser1, Condenser2, FinsPerInch1, FinsPerInch2, SubCooling1, SubCooling2, SubCoolingPercent1, SubCoolingPercent2, CondenserTD1, CondenserTD2, FinHeight1, FinHeight2, FinLength1, FinLength2, DischargeLineLoss, SuctionLineLoss, Altitude, Fan, CfmOverride, NumFans1, NumFans2, CondenserCapacity1, CondenserCapacity2, EvaporatorModel, EvaporatorModelDesc, NumEvap, FoulingFactor, CapacityType, EvaporatorCapacity, CatalogRating, ApproachRange, Evap8Degr1, Evap8Degr2, Evap10Degr1, Evap10Degr2, Division, FanWatts         from ACChillerProcesses inner join Processes on Processes.ID = ACChillerProcesses.ProcessID  where ProjectID = '" & projectID & "' and ProcessTableName = 'ACChillerProcesses'"
        Dim sql = "select Name, Address1, Address2, State, City, Zip, Phone, ImportedFromCloud, ContactType from OrderEntryContacts WHERE ProjectId = '" & projectID & "'"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                'CopyOrderEntryContacts(ProjectId As String, Name As String, Address1 As String, Address2 As String, Phone As String, State As String, Zip As String, City As String, ContactType As String, ImportedFromCloud As String, cloudID As String)
                CloudSaveWS.CopyOrderEntryContacts(projectID, rdr("Name").ToString().Trim(), rdr("Address1").ToString().Trim(), rdr("Address2").ToString().Trim(), rdr("Phone").ToString().Trim(), rdr("State").ToString().Trim(), rdr("Zip").ToString().Trim(), rdr("City").ToString().Trim(), rdr("ContactType").ToString().Trim(), rdr("ImportedFromCloud").ToString().Trim(), cloudID)
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try
    End Sub

    Private Sub CopyUnitCoolerProcessesRecord(ByVal cloudID As Integer)

        Dim projectID As String = OpenedProject.ProjectId.ToString
        Dim CloudSaveWS As New CloudSaveService.CloudSave

        'Dim sql = "select ProcessId, Revision, RevisionDate, ProjectRevision, RevisionDescription, CreatedBy, Version, Notes, Name, CondensingUnitSeries, ShouldAdjustCapacityForRunTime, NumRunTimeHours, CompressorType, Refrigerant, NumCompressorsPerUnit, NumCircuitsPerUnit, CapacityRequired, Altitude, NumCondensingUnitsRequired, SuctionTemperature, NumRooms, AmbientTemperature, AmbientMinTemperature, AmbientMaxTemperature, AmbientTemperatureIncrement, RoomTemperature, RoomMinTemperature, RoomMaxTemperature, RoomTemperatureIncrement, CondenserCapacityPerDegree, CondensingUnitModel, Series, SuctionLineLoss, ShouldOverrideUnitCoolerCapacityCriteria, SelectedUnitCoolerIndex, UnitCooler1Model, UnitCooler2Model, UnitCooler3Model, UnitCooler1Capacity, UnitCooler2Capacity, UnitCooler3Capacity, UnitCooler1Quantity, UnitCooler2Quantity, UnitCooler3Quantity, Evaporator1CapacityPerDegree, Evaporator2CapacityPerDegree, Evaporator3CapacityPerDegree, IsThereAUnitCooler1, IsThereAUnitCooler2, IsThereAUnitCooler3, IsThereACustomUnitCooler, CustomUnitCoolerModel, CustomUnitCoolerCapacity, CustomUnitCoolerQuantity, CustomUnitCoolerCapacityPerDegree, Balance, EvaporatorTemperature, AirTemperature, CondenserTemperature, Capacity, RunTime, UnitKw, CondenserCapacity, UnitAmps230, UnitAmps460, UnitEer, TemperatureDifference, UnitMca230, UnitMca460, Dimensions, BaseListPrice, CustomCondensingUnit, Division, ObjectLinkXML, ObjectLinkType, static_pressure_1, static_pressure_2, static_pressure_3         from UnitCoolerProcesses inner join Processes on Processes.ID = UnitCoolerProcesses.ProcessID  where ProjectID = '" & projectID & "
        Dim sql = "select ProcessId, Revision, RevisionDate, ProjectRevision, RevisionDescription, CreatedBy, Version, Notes, Name, CondensingUnitSeries, ShouldAdjustCapacityForRunTime, NumRunTimeHours, CompressorType, Refrigerant, NumCompressorsPerUnit, NumCircuitsPerUnit, CapacityRequired, Altitude, NumCondensingUnitsRequired, SuctionTemperature, NumRooms, AmbientTemperature, AmbientMinTemperature, AmbientMaxTemperature, AmbientTemperatureIncrement, RoomTemperature, RoomMinTemperature, RoomMaxTemperature, RoomTemperatureIncrement, CondenserCapacityPerDegree, CondensingUnitModel, Series, SuctionLineLoss, ShouldOverrideUnitCoolerCapacityCriteria, SelectedUnitCoolerIndex, UnitCooler1Model, UnitCooler2Model, UnitCooler3Model, UnitCooler1Capacity, UnitCooler2Capacity, UnitCooler3Capacity, UnitCooler1Quantity, UnitCooler2Quantity, UnitCooler3Quantity, Evaporator1CapacityPerDegree, Evaporator2CapacityPerDegree, Evaporator3CapacityPerDegree, IsThereAUnitCooler1, IsThereAUnitCooler2, IsThereAUnitCooler3, IsThereACustomUnitCooler, CustomUnitCoolerModel, CustomUnitCoolerCapacity, CustomUnitCoolerQuantity, CustomUnitCoolerCapacityPerDegree, Balance, EvaporatorTemperature, AirTemperature, CondenserTemperature, Capacity, RunTime, UnitKw, CondenserCapacity, UnitAmps230, UnitAmps460, UnitEer, TemperatureDifference, UnitMca230, UnitMca460, Dimensions, BaseListPrice, CustomCondensingUnit, Division, ObjectLinkXML, ObjectLinkType, static_pressure_1, static_pressure_2, static_pressure_3 , DOEModel        from UnitCoolerProcesses inner join Processes on Processes.ID = UnitCoolerProcesses.ProcessID WHERE UnitCoolerProcesses.ProcessID IN (SELECT PROCESSES.ID FROM pROCESSES where PROCESSES.PROJECTID='" & projectID & "' AND PROCESSES.[PROCESSTableName]='UnitCoolerProcesses')"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                CloudSaveWS.CopyUnitCoolerProcessesRecord(cloudID, rdr("ProcessId").ToString, IIf(IsDBNull(rdr("Revision")), 0, rdr("Revision")), IIf(IsDBNull(rdr("RevisionDate")), "1/1/1990", rdr("RevisionDate")), IIf(IsDBNull(rdr("ProjectRevision")), 0, rdr("ProjectRevision")), rdr("RevisionDescription").ToString, rdr("CreatedBy").ToString, rdr("Version").ToString, rdr("Notes").ToString, rdr("Name").ToString, rdr("CondensingUnitSeries").ToString, IIf(IsDBNull(rdr("ShouldAdjustCapacityForRunTime")), False, rdr("ShouldAdjustCapacityForRunTime")), IIf(IsDBNull(rdr("NumRunTimeHours")), 0, rdr("NumRunTimeHours")), rdr("CompressorType").ToString, rdr("Refrigerant").ToString, IIf(IsDBNull(rdr("NumCompressorsPerUnit")), 0, rdr("NumCompressorsPerUnit")), IIf(IsDBNull(rdr("NumCircuitsPerUnit")), 0, rdr("NumCircuitsPerUnit")), IIf(IsDBNull(rdr("CapacityRequired")), 0, rdr("CapacityRequired")), IIf(IsDBNull(rdr("Altitude")), 0, rdr("Altitude")), IIf(IsDBNull(rdr("NumCondensingUnitsRequired")), 0, rdr("NumCondensingUnitsRequired")), IIf(IsDBNull(rdr("SuctionTemperature")), 0, rdr("SuctionTemperature")), IIf(IsDBNull(rdr("NumRooms")), 0, rdr("NumRooms")), IIf(IsDBNull(rdr("AmbientTemperature")), 0, rdr("AmbientTemperature")), IIf(IsDBNull(rdr("AmbientMinTemperature")), 0, rdr("AmbientMinTemperature")), IIf(IsDBNull(rdr("AmbientMaxTemperature")), 0, rdr("AmbientMaxTemperature")), IIf(IsDBNull(rdr("AmbientTemperatureIncrement")), 0, rdr("AmbientTemperatureIncrement")), IIf(IsDBNull(rdr("RoomTemperature")), 0, rdr("RoomTemperature")), IIf(IsDBNull(rdr("RoomMinTemperature")), 0, rdr("RoomMinTemperature")), IIf(IsDBNull(rdr("RoomMaxTemperature")), 0, rdr("RoomMaxTemperature")), IIf(IsDBNull(rdr("RoomTemperatureIncrement")), 0, rdr("RoomTemperatureIncrement")), IIf(IsDBNull(rdr("CondenserCapacityPerDegree")), 0, rdr("CondenserCapacityPerDegree")), rdr("CondensingUnitModel").ToString, rdr("Series").ToString, IIf(IsDBNull(rdr("SuctionLineLoss")), 0, rdr("SuctionLineLoss")), IIf(IsDBNull(rdr("ShouldOverrideUnitCoolerCapacityCriteria")), False, rdr("ShouldOverrideUnitCoolerCapacityCriteria")), IIf(IsDBNull(rdr("SelectedUnitCoolerIndex")), 0, rdr("SelectedUnitCoolerIndex")), rdr("UnitCooler1Model").ToString, rdr("UnitCooler2Model").ToString, rdr("UnitCooler3Model").ToString, IIf(IsDBNull(rdr("UnitCooler1Capacity")), 0, rdr("UnitCooler1Capacity")), IIf(IsDBNull(rdr("UnitCooler2Capacity")), 0, rdr("UnitCooler2Capacity")), IIf(IsDBNull(rdr("UnitCooler3Capacity")), 0, rdr("UnitCooler3Capacity")), IIf(IsDBNull(rdr("UnitCooler1Quantity")), 0, rdr("UnitCooler1Quantity")), IIf(IsDBNull(rdr("UnitCooler2Quantity")), 0, rdr("UnitCooler2Quantity")), IIf(IsDBNull(rdr("UnitCooler3Quantity")), 0, rdr("UnitCooler3Quantity")), IIf(IsDBNull(rdr("Evaporator1CapacityPerDegree")), 0, rdr("Evaporator1CapacityPerDegree")), IIf(IsDBNull(rdr("Evaporator2CapacityPerDegree")), 0, rdr("Evaporator2CapacityPerDegree")), IIf(IsDBNull(rdr("Evaporator3CapacityPerDegree")), 0, rdr("Evaporator3CapacityPerDegree")), IIf(IsDBNull(rdr("IsThereAUnitCooler1")), False, rdr("IsThereAUnitCooler1")), IIf(IsDBNull(rdr("IsThereAUnitCooler2")), False, rdr("IsThereAUnitCooler2")), IIf(IsDBNull(rdr("IsThereAUnitCooler3")), False, rdr("IsThereAUnitCooler3")), IIf(IsDBNull(rdr("IsThereACustomUnitCooler")), False, rdr("IsThereACustomUnitCooler")), rdr("CustomUnitCoolerModel").ToString, IIf(IsDBNull(rdr("CustomUnitCoolerCapacity")), 0, rdr("CustomUnitCoolerCapacity")), IIf(IsDBNull(rdr("CustomUnitCoolerQuantity")), 0, rdr("CustomUnitCoolerQuantity")), IIf(IsDBNull(rdr("CustomUnitCoolerCapacityPerDegree")), 0, rdr("CustomUnitCoolerCapacityPerDegree")), IIf(IsDBNull(rdr("Balance")), 0, rdr("Balance")), IIf(IsDBNull(rdr("EvaporatorTemperature")), 0, rdr("EvaporatorTemperature")), IIf(IsDBNull(rdr("AirTemperature")), 0, rdr("AirTemperature")), IIf(IsDBNull(rdr("CondenserTemperature")), 0, rdr("CondenserTemperature")), IIf(IsDBNull(rdr("Capacity")), 0, rdr("Capacity")), IIf(IsDBNull(rdr("RunTime")), 0, rdr("RunTime")), IIf(IsDBNull(rdr("UnitKw")), 0, rdr("UnitKw")), IIf(IsDBNull(rdr("CondenserCapacity")), 0, rdr("CondenserCapacity")), IIf(IsDBNull(rdr("UnitAmps230")), 0, rdr("UnitAmps230")), IIf(IsDBNull(rdr("UnitAmps460")), 0, rdr("UnitAmps460")), IIf(IsDBNull(rdr("UnitEer")), 0, rdr("UnitEer")), IIf(IsDBNull(rdr("TemperatureDifference")), 0, rdr("TemperatureDifference")), IIf(IsDBNull(rdr("UnitMca230")), 0, rdr("UnitMca230")), IIf(IsDBNull(rdr("UnitMca460")), 0, rdr("UnitMca460")), rdr("Dimensions").ToString, IIf(IsDBNull(rdr("BaseListPrice")), 0, rdr("BaseListPrice")), rdr("CustomCondensingUnit").ToString, rdr("Division").ToString, rdr("ObjectLinkXML").ToString, rdr("ObjectLinkType").ToString, IIf(IsDBNull(rdr("static_pressure_1")), 0, rdr("static_pressure_1")), IIf(IsDBNull(rdr("static_pressure_2")), 0, rdr("static_pressure_2")), IIf(IsDBNull(rdr("static_pressure_3")), 0, rdr("static_pressure_3")), IIf(IsDBNull(rdr("DOEModel")), "", rdr("DOEModel")))
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try
    End Sub

    Private Sub CopyFluidCoolerProcessesRecord(ByVal cloudID As Integer)

        Dim projectID As String = OpenedProject.ProjectId.ToString
        Dim CloudSaveWS As New CloudSaveService.CloudSave

        'Dim sql = "select ProcessID, Revision, RevisionDate, ProjectRevision, ProcessRevisionDescription, CreatedBy, Name, Altitude, Capacity, AmbientTemp, EnteringFluidTemp, LeavingFluidTemp, GlycolPercent, Fluid, Flow, FluidCoolerXML         from FluidCoolerProcesses  inner join Processes on Processes.ID = FluidCoolerProcesses.ProcessID  where ProjectID = '" & projectID & "' and ProcessTableName = 'FluidCoolerProcesses'"
        Dim sql = "select ProcessID, Revision, RevisionDate, ProjectRevision, ProcessRevisionDescription, CreatedBy, Name, Altitude, Capacity, AmbientTemp, EnteringFluidTemp, LeavingFluidTemp, GlycolPercent, Fluid, Flow, FluidCoolerXML         from FluidCoolerProcesses  inner join Processes on Processes.ID = FluidCoolerProcesses.ProcessID WHERE FluidCoolerProcesses.ProcessID IN (SELECT PROCESSES.ID FROM pROCESSES where PROCESSES.PROJECTID='" & projectID & "' AND PROCESSES.[PROCESSTableName]='FluidCoolerProcesses')"
        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                CloudSaveWS.CopyFluidCoolerProcessesRecord(cloudID, rdr("ProcessID").ToString, IIf(IsDBNull(rdr("Revision")), 0, rdr("Revision")), IIf(IsDBNull(rdr("RevisionDate")), "1/1/1990", rdr("RevisionDate")), IIf(IsDBNull(rdr("ProjectRevision")), 0, rdr("ProjectRevision")), rdr("ProcessRevisionDescription").ToString, rdr("CreatedBy").ToString, rdr("Name").ToString, IIf(IsDBNull(rdr("Altitude")), 0, rdr("Altitude")), IIf(IsDBNull(rdr("Capacity")), 0, rdr("Capacity")), IIf(IsDBNull(rdr("AmbientTemp")), 0, rdr("AmbientTemp")), IIf(IsDBNull(rdr("EnteringFluidTemp")), 0, rdr("EnteringFluidTemp")), IIf(IsDBNull(rdr("LeavingFluidTemp")), 0, rdr("LeavingFluidTemp")), IIf(IsDBNull(rdr("GlycolPercent")), 0, rdr("GlycolPercent")), rdr("Fluid").ToString, IIf(IsDBNull(rdr("Flow")), 0, rdr("Flow")), rdr("FluidCoolerXML").ToString)
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try
    End Sub


    Private Sub CopyEvapChillerProcessesRecord(ByVal cloudID As Integer)

        Dim projectID As String = OpenedProject.ProjectId.ToString
        Dim CloudSaveWS As New CloudSaveService.CloudSave

        'Dim sql = "select ProcessID, Revision, RevisionDate, ProjectRevision, ProcessRevisionDescription, CreatedBy, Version, Notes, Name, Series, NewCoefficients, Model, ModelDesc, Fluid, GlycolPercentage, CoolingMedia, SpecificHeat, SpecificGravity, SubCooling, Refrigerant, TempRange, AmbientTemp, LeavingFluidTemp, System, Hertz, Volts, Approach, TEMin, TEMax, TEIncrement, ATMin, ATMax, ATIncrement, SafetyOverride, Circuit1, Circuit2, NumCompressors1, NumCompressors2, Compressors1, Compressors2, NumCoils1, NumCoils2, Condenser1, Condenser2, DischargeLineLoss, SuctionLineLoss, Altitude, PumpWatts, FanWatts, CondenserCapacity1, CondenserCapacity2, EvaporatorModel, EvaporatorModelDesc, NumEvap, FoulingFactor, CapacityType, EvaporatorCapacity, CatalogRating, ApproachRange, Evap8Degr1, Evap8Degr2, Evap10Degr1, Evap10Degr2, Division, SubcoolingCoilOption, SoundAttenuationOption, CustomCondenserModel, FanMotorHp, PumpMotorHp         from EvapChillerProcesses  inner join Processes on Processes.ID = EvapChillerProcesses.ProcessID  where ProjectID = '" & projectID & "' and ProcessTableName = 'EvapChillerProcesses'"
        Dim sql = "select ProcessID, Revision, RevisionDate, ProjectRevision, ProcessRevisionDescription, CreatedBy, Version, Notes, Name, Series, NewCoefficients, Model, ModelDesc, Fluid, GlycolPercentage, CoolingMedia, SpecificHeat, SpecificGravity, SubCooling, Refrigerant, TempRange, AmbientTemp, LeavingFluidTemp, System, Hertz, Volts, Approach, TEMin, TEMax, TEIncrement, ATMin, ATMax, ATIncrement, SafetyOverride, Circuit1, Circuit2, NumCompressors1, NumCompressors2, Compressors1, Compressors2, NumCoils1, NumCoils2, Condenser1, Condenser2, DischargeLineLoss, SuctionLineLoss, Altitude, PumpWatts, FanWatts, CondenserCapacity1, CondenserCapacity2, EvaporatorModel, EvaporatorModelDesc, NumEvap, FoulingFactor, CapacityType, EvaporatorCapacity, CatalogRating, ApproachRange, Evap8Degr1, Evap8Degr2, Evap10Degr1, Evap10Degr2, Division, SubcoolingCoilOption, SoundAttenuationOption, CustomCondenserModel, FanMotorHp, PumpMotorHp         from EvapChillerProcesses  inner join Processes on Processes.ID = EvapChillerProcesses.ProcessID WHERE EvapChillerProcesses.ProcessID IN (SELECT PROCESSES.ID FROM pROCESSES where PROCESSES.PROJECTID='" & projectID & "' AND PROCESSES.[PROCESSTableName]='EvapChillerProcesses')"
        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                CloudSaveWS.CopyEvapChillerProcessesRecord(cloudID, rdr("ProcessID").ToString, IIf(IsDBNull(rdr("Revision")), 0, rdr("Revision")), IIf(IsDBNull(rdr("RevisionDate")), "1/1/1990", rdr("RevisionDate")), IIf(IsDBNull(rdr("ProjectRevision")), 0, rdr("ProjectRevision")), rdr("ProcessRevisionDescription").ToString, rdr("CreatedBy").ToString, rdr("Version").ToString, rdr("Notes").ToString, rdr("Name").ToString, rdr("Series").ToString, IIf(IsDBNull(rdr("NewCoefficients")), False, rdr("NewCoefficients")), rdr("Model").ToString, rdr("ModelDesc").ToString, rdr("Fluid").ToString, IIf(IsDBNull(rdr("GlycolPercentage")), 0, rdr("GlycolPercentage")), rdr("CoolingMedia").ToString, IIf(IsDBNull(rdr("SpecificHeat")), 0, rdr("SpecificHeat")), IIf(IsDBNull(rdr("SpecificGravity")), 0, rdr("SpecificGravity")), IIf(IsDBNull(rdr("SubCooling")), 0, rdr("SubCooling")), rdr("Refrigerant").ToString, IIf(IsDBNull(rdr("TempRange")), 0, rdr("TempRange")), IIf(IsDBNull(rdr("AmbientTemp")), 0, rdr("AmbientTemp")), IIf(IsDBNull(rdr("LeavingFluidTemp")), 0, rdr("LeavingFluidTemp")), rdr("System").ToString, IIf(IsDBNull(rdr("Hertz")), 0, rdr("Hertz")), IIf(IsDBNull(rdr("Volts")), 0, rdr("Volts")), rdr("Approach").ToString, IIf(IsDBNull(rdr("TEMin")), 0, rdr("TEMin")), IIf(IsDBNull(rdr("TEMax")), 0, rdr("TEMax")), IIf(IsDBNull(rdr("TEIncrement")), 0, rdr("TEIncrement")), IIf(IsDBNull(rdr("ATMin")), 0, rdr("ATMin")), IIf(IsDBNull(rdr("ATMax")), 0, rdr("ATMax")), IIf(IsDBNull(rdr("ATIncrement")), 0, rdr("ATIncrement")), IIf(IsDBNull(rdr("SafetyOverride")), False, rdr("SafetyOverride")), IIf(IsDBNull(rdr("Circuit1")), False, rdr("Circuit1")), IIf(IsDBNull(rdr("Circuit2")), False, rdr("Circuit2")), IIf(IsDBNull(rdr("NumCompressors1")), 0, rdr("NumCompressors1")), IIf(IsDBNull(rdr("NumCompressors2")), 0, rdr("NumCompressors2")), rdr("Compressors1").ToString, rdr("Compressors2").ToString, IIf(IsDBNull(rdr("NumCoils1")), 0, rdr("NumCoils1")), IIf(IsDBNull(rdr("NumCoils2")), 0, rdr("NumCoils2")), rdr("Condenser1").ToString, rdr("Condenser2").ToString, IIf(IsDBNull(rdr("DischargeLineLoss")), 0, rdr("DischargeLineLoss")), IIf(IsDBNull(rdr("SuctionLineLoss")), 0, rdr("SuctionLineLoss")), IIf(IsDBNull(rdr("Altitude")), 0, rdr("Altitude")), IIf(IsDBNull(rdr("PumpWatts")), 0, rdr("PumpWatts")), IIf(IsDBNull(rdr("FanWatts")), 0, rdr("FanWatts")), IIf(IsDBNull(rdr("CondenserCapacity1")), 0, rdr("CondenserCapacity1")), IIf(IsDBNull(rdr("CondenserCapacity2")), 0, rdr("CondenserCapacity2")), rdr("EvaporatorModel").ToString, rdr("EvaporatorModelDesc").ToString, IIf(IsDBNull(rdr("NumEvap")), 0, rdr("NumEvap")), IIf(IsDBNull(rdr("FoulingFactor")), 0, rdr("FoulingFactor")), rdr("CapacityType").ToString, IIf(IsDBNull(rdr("EvaporatorCapacity")), 0, rdr("EvaporatorCapacity")), IIf(IsDBNull(rdr("CatalogRating")), False, rdr("CatalogRating")), rdr("ApproachRange").ToString, IIf(IsDBNull(rdr("Evap8Degr1")), 0, rdr("Evap8Degr1")), IIf(IsDBNull(rdr("Evap8Degr2")), 0, rdr("Evap8Degr2")), IIf(IsDBNull(rdr("Evap10Degr1")), 0, rdr("Evap10Degr1")), IIf(IsDBNull(rdr("Evap10Degr2")), 0, rdr("Evap10Degr2")), rdr("Division").ToString, IIf(IsDBNull(rdr("SubcoolingCoilOption")), False, rdr("SubcoolingCoilOption")), IIf(IsDBNull(rdr("SoundAttenuationOption")), False, rdr("SoundAttenuationOption")), rdr("CustomCondenserModel").ToString, IIf(IsDBNull(rdr("FanMotorHp")), 0, rdr("FanMotorHp")), IIf(IsDBNull(rdr("PumpMotorHp")), 0, rdr("PumpMotorHp")))
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try
    End Sub


    Private Sub CopyCondenserProcessesRecord(ByVal cloudID As Integer)

        Dim projectID As String = OpenedProject.ProjectId.ToString
        Dim CloudSaveWS As New CloudSaveService.CloudSave

        'Dim sql = "select ProcessID, Revision, RevisionDate, ProjectRevision, ProcessRevisionDescription, CreatedBy, Version, Notes, Altitude, AmbientTemp, CatalogRating, CFM, CoilDesc, CoilLength, CoilWidth, ExtStaticPressure, Fan, Model, Name, NumFans, Refrigerant, Series, SubCooling, SubCoolingPercentage, TD, Division         from CondenserProcesses  inner join Processes on Processes.ID = CondenserProcesses.ProcessID  where ProjectID = '" & projectID & "' and ProcessTableName = 'CondenserProcesses'"
        Dim sql = "select ProcessID, Revision, RevisionDate, ProjectRevision, ProcessRevisionDescription, CreatedBy, Version, Notes, Altitude, AmbientTemp, CatalogRating, CFM, CoilDesc, CoilLength, CoilWidth, ExtStaticPressure, Fan, Model, Name, NumFans, Refrigerant, Series, SubCooling, SubCoolingPercentage, TD, Division         from CondenserProcesses  inner join Processes on Processes.ID = CondenserProcesses.ProcessID WHERE CondenserProcesses.ProcessID IN (SELECT PROCESSES.ID FROM pROCESSES where PROCESSES.PROJECTID='" & projectID & "' AND PROCESSES.[PROCESSTableName]='CondenserProcesses')"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                CloudSaveWS.CopyCondenserProcessesRecord(cloudID, rdr("ProcessID").ToString, IIf(IsDBNull(rdr("Revision")), 0, rdr("Revision")), IIf(IsDBNull(rdr("RevisionDate")), "1/1/1990", rdr("RevisionDate")), IIf(IsDBNull(rdr("ProjectRevision")), 0, rdr("ProjectRevision")), rdr("ProcessRevisionDescription").ToString, rdr("CreatedBy").ToString, rdr("Version").ToString, rdr("Notes").ToString, IIf(IsDBNull(rdr("Altitude")), 0, rdr("Altitude")), IIf(IsDBNull(rdr("AmbientTemp")), 0, rdr("AmbientTemp")), IIf(IsDBNull(rdr("CatalogRating")), False, rdr("CatalogRating")), IIf(IsDBNull(rdr("CFM")), 0, rdr("CFM")), rdr("CoilDesc").ToString, IIf(IsDBNull(rdr("CoilLength")), 0, rdr("CoilLength")), IIf(IsDBNull(rdr("CoilWidth")), 0, rdr("CoilWidth")), IIf(IsDBNull(rdr("ExtStaticPressure")), 0, rdr("ExtStaticPressure")), rdr("Fan").ToString, rdr("Model").ToString, rdr("Name").ToString, IIf(IsDBNull(rdr("NumFans")), 0, rdr("NumFans")), rdr("Refrigerant").ToString, rdr("Series").ToString, IIf(IsDBNull(rdr("SubCooling")), False, rdr("SubCooling")), IIf(IsDBNull(rdr("SubCoolingPercentage")), 0, rdr("SubCoolingPercentage")), IIf(IsDBNull(rdr("TD")), 0, rdr("TD")), rdr("Division").ToString)
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try
    End Sub



    Private Sub CopyContactsRecord(ByVal cloudID As Integer)

        Dim projectID As String = OpenedProject.ProjectId.ToString
        Dim CloudSaveWS As New CloudSaveService.CloudSave

        Dim sql = "SELECT [Id],[CustomerNum] ,[RepNum] ,[FirstName] ,[LastName] ,[CompanyId] ,[Email] ,Contacts.[Description] ,[Line1] ,[Line2] ,[City] ,[State] ,[ZipCode5] ,[ZipCode4] ,[PhoneNumAreaCode] ,[PhoneNum] ,[PhoneNumExtension] ,[FaxNum] ,[FaxNumAreaCode]  FROM [Contacts]  INNER JOIN ProjectContacts  on ProjectContacts.ContactID = Contacts.ID where ProjectContacts.ProjectID = '" & projectID & "'"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                CloudSaveWS.CopyContactsRecord1(cloudID, IIf(IsDBNull(rdr("Id")), 0, rdr("Id")), IIf(IsDBNull(rdr("CustomerNum")), 0, rdr("CustomerNum")), IIf(IsDBNull(rdr("RepNum")), 0, rdr("RepNum")), rdr("FirstName").ToString, rdr("LastName").ToString, IIf(IsDBNull(rdr("CompanyId")), 0, rdr("CompanyId")), rdr("Email").ToString, rdr("Description").ToString, rdr("Line1").ToString, rdr("Line2").ToString, rdr("City").ToString, rdr("State").ToString, IIf(IsDBNull(rdr("ZipCode5")), 0, rdr("ZipCode5")), IIf(IsDBNull(rdr("ZipCode4")), 0, rdr("ZipCode4")), IIf(IsDBNull(rdr("PhoneNumAreaCode")), 0, rdr("PhoneNumAreaCode")), IIf(IsDBNull(rdr("PhoneNum")), 0, rdr("PhoneNum")), IIf(IsDBNull(rdr("PhoneNumExtension")), 0, rdr("PhoneNumExtension")), IIf(IsDBNull(rdr("FaxNum")), 0, rdr("FaxNum")), IIf(IsDBNull(rdr("FaxNumAreaCode")), 0, rdr("FaxNumAreaCode")), projectID)
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try
    End Sub



    Private Sub CopyCompaniesRecord(ByVal cloudID As Integer)

        Dim projectID As String = OpenedProject.ProjectId.ToString
        Dim CloudSaveWS As New CloudSaveService.CloudSave

        Dim sql = "SELECT DISTINCT Companies.Id, Companies.CustomerNum, Companies.RepNum, Companies.Name, Companies.Website, Companies.Email, Companies.Description, Companies.Line1, Companies.Line2, Companies.City, Companies.State, Companies.ZipCode5, Companies.ZipCode4, Companies.PhoneNumAreaCode, Companies.PhoneNum, Companies.PhoneNumExtension, Companies.FaxNum, Companies.FaxNumAreaCode FROM (Companies INNER JOIN Contacts ON Companies.Id = Contacts.CompanyId) INNER JOIN ProjectContacts ON Contacts.Id = ProjectContacts.ContactId WHERE ProjectContacts.ProjectID = '" & projectID & "'"
        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                CloudSaveWS.CopyCompaniesRecord(cloudID, IIf(IsDBNull(rdr("Id")), 0, rdr("Id")), IIf(IsDBNull(rdr("CustomerNum")), 0, rdr("CustomerNum")), IIf(IsDBNull(rdr("RepNum")), 0, rdr("RepNum")), rdr("Name").ToString, rdr("Website").ToString, rdr("Email").ToString, rdr("Description").ToString, rdr("Line1").ToString, rdr("Line2").ToString, rdr("City").ToString, rdr("State").ToString, IIf(IsDBNull(rdr("ZipCode5")), 0, rdr("ZipCode5")), IIf(IsDBNull(rdr("ZipCode4")), 0, rdr("ZipCode4")), IIf(IsDBNull(rdr("PhoneNumAreaCode")), 0, rdr("PhoneNumAreaCode")), IIf(IsDBNull(rdr("PhoneNum")), 0, rdr("PhoneNum")), IIf(IsDBNull(rdr("PhoneNumExtension")), 0, rdr("PhoneNumExtension")), IIf(IsDBNull(rdr("FaxNum")), 0, rdr("FaxNum")), IIf(IsDBNull(rdr("FaxNumAreaCode")), 0, rdr("FaxNumAreaCode")))
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try
    End Sub



    Private Sub CopyProjectContactsRecord(ByVal cloudID As Integer)

        Dim projectID As String = OpenedProject.ProjectId.ToString
        Dim CloudSaveWS As New CloudSaveService.CloudSave

        Dim sql = "select ProjectId, ContactId         from ProjectContacts where ProjectID = '" & projectID & "'"
        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql
        Dim rdr As IDataReader

        Try
            connection.Open()
            rdr = command.ExecuteReader()
            While rdr.Read
                CloudSaveWS.CopyProjectContactsRecord(cloudID, rdr("ProjectId").ToString, IIf(IsDBNull(rdr("ContactId")), 0, rdr("ContactId")))
            End While
        Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try
    End Sub




    Private Sub txtUniqueKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUniqueKey.Click
        txtUniqueKey.SelectAll()
    End Sub


    Private Sub btnCopyToClipboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyToClipboard.Click
        My.Computer.Clipboard.SetText(txtUniqueKey.Text)
    End Sub

    Private Sub CopyRatingEquipmentRecord(ByVal p1 As Integer)
        Throw New NotImplementedException
    End Sub

End Class