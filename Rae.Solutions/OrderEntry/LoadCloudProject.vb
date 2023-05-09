Imports Rae.RaeSolutions.DataAccess
Imports Rae.DataAccess.EquipmentOptions
Imports System.Data
Imports System.Data.OleDb


Public Class LoadCloudProject

    Private formLoaded As Boolean = False
    Dim minDate As DateTime = DateTime.Parse("1900-01-01 00:00:00")

    'Private Sub btmCloudLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim CloudSaveWS As New CloudSaveService.CloudSave
    '    Dim projectGUID As String = txtUniqueKey.Text

    '    Dim cloudID As Integer = CloudSaveWS.GetCloudIDFromGUID(projectGUID)

    '    DoImport(cloudID, CloudSaveWS)

    'End Sub


    Private Sub DoImport(ByVal CloudID As Integer)
        Dim CloudSaveWS As New CloudSaveService.CloudSave
        DoImport(CloudID, CloudSaveWS)
    End Sub

    Private Sub DoImport(ByVal CloudID As Integer, ByRef cloudSaveWS As CloudSaveService.CloudSave)
        Dim uniqueCode As String = GetUniqueCode()


        LoadACChillerProcesses(CloudID, uniqueCode, cloudSaveWS)
        LoadChillers(CloudID, uniqueCode, cloudSaveWS)
        LoadCondenser(CloudID, uniqueCode, cloudSaveWS)
        LoadCondenserProcesses(CloudID, uniqueCode, cloudSaveWS)
        LoadCondensingUnit(CloudID, uniqueCode, cloudSaveWS)
        LoadCondensingUnitProcesses(CloudID, uniqueCode, cloudSaveWS)
        LoadEquipment(CloudID, uniqueCode, cloudSaveWS)
        LoadEquipmentOptions(CloudID, uniqueCode, cloudSaveWS)
        LoadEvapChillerProcesses(CloudID, uniqueCode, cloudSaveWS)
        LoadFluidCooler(CloudID, uniqueCode, cloudSaveWS)
        LoadFluidCoolerProcesses(CloudID, uniqueCode, cloudSaveWS)
        LoadProcessEquip(CloudID, uniqueCode, cloudSaveWS)
        LoadProcesses(CloudID, uniqueCode, cloudSaveWS)
        LoadProcessSpecific(CloudID, uniqueCode, cloudSaveWS)
        LoadProductCooler(CloudID, uniqueCode, cloudSaveWS)
        LoadProjects(CloudID, uniqueCode, cloudSaveWS)
        LoadPumpPackage(CloudID, uniqueCode, cloudSaveWS)
        LoadRatingEquipment(CloudID, uniqueCode, cloudSaveWS)
        LoadSpecialOptions(CloudID, uniqueCode, cloudSaveWS)
        LoadUnitCooler(CloudID, uniqueCode, cloudSaveWS)
        LoadUnitCoolerProcesses(CloudID, uniqueCode, cloudSaveWS)
        LoadWCChillerProcesses(CloudID, uniqueCode, cloudSaveWS)
        LoadOrderEntryContacts(CloudID, uniqueCode, cloudSaveWS)

        'LoadCompanies(CloudID, uniqueCode, cloudSaveWS)

        'LoadContacts(CloudID, uniqueCode, cloudSaveWS)

        'LoadProjectContacts(CloudID, uniqueCode, cloudSaveWS)

        MsgBox("Complete!")

    End Sub


    Private Sub LoadChillers(ByVal cloidID As Integer, ByVal uniqueCode As String, ByRef cloudSaveWS As CloudSaveService.CloudSave)
        Dim chillers() As CloudSaveService.Chiller
        chillers = cloudSaveWS.LoadChillers(cloidID, uniqueCode)

        For Each c As CloudSaveService.Chiller In chillers
            InsertChiller(c)
        Next

    End Sub

    Private Function InsertChiller(ByVal c As CloudSaveService.Chiller)

        Dim sql = "insert into [Chiller] ([EquipmentID],[Revision],[Capacity],[AmbientTemp],[EnteringFluidTemp],[LeavingFluidTemp],[GlycolPercent],[Fluid],[Flow],[Refrigerant],[EvaporatorPressureDrop],[UnitKwPerTon],[CompressorAmps1],[CompressorAmps2],[CompressorQuantity1],[CompressorQuantity2],[CondenserQuantity],[SprayPumpAmps],[BlowerAmps],[HasBalance] ) values "
        sql &= "("

        sql &= "'" & c.EquipmentId & "', "
        sql &= c.Revision & ", "
        sql &= c.Capacity & ", "
        sql &= c.AmbientTemp & ", "
        sql &= c.EnteringFluidTemp & ", "
        sql &= c.LeavingFluidTemp & ", "
        sql &= c.GlycolPercent & ", "
        sql &= "'" & c.Fluid & "', "
        sql &= c.Flow & ", "
        sql &= "'" & c.Refrigerant & "', "
        sql &= c.EvaporatorPressureDrop & ", "
        sql &= "'" & c.UnitKwPerTon & "', "
        sql &= c.CompressorAmps1 & ", "
        sql &= c.CompressorAmps2 & ", "
        sql &= c.CompressorQuantity1 & ", "
        sql &= c.CompressorQuantity2 & ", "
        sql &= c.CondenserQuantity & ", "
        sql &= c.SprayPumpAmps & ", "
        sql &= c.BlowerAmps & ", "
        sql &= c.HasBalance & " "


        sql &= ")"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
        End Try

    End Function






    Private Sub LoadWCChillerProcesses(ByVal cloidID As Integer, ByVal uniqueCode As String, ByRef cloudSaveWS As CloudSaveService.CloudSave)
        Dim WCChillerProcesses() As CloudSaveService.WCChillerProcesses
        WCChillerProcesses = cloudSaveWS.LoadWCChillerProcesses(cloidID, uniqueCode)

        For Each c As CloudSaveService.WCChillerProcesses In WCChillerProcesses
            InsertWCChillerProcesses(c)
        Next
    End Sub

    Private Function InsertWCChillerProcesses(ByVal c As CloudSaveService.WCChillerProcesses)
        If c.RevisionDate < minDate Then
            c.RevisionDate = minDate
        End If

        Dim sql = "insert into [WCChillerProcesses] ( "
        sql &= "[ProcessID], "
        sql &= "[Revision], "
        sql &= "[RevisionDate], "
        sql &= "[ProjectRevision], "
        sql &= "[ProcessRevisionDescription], "
        sql &= "[CreatedBy], "
        sql &= "[Version], "
        sql &= "[Notes], "
        sql &= "[Name], "
        sql &= "[Series], "
        sql &= "[NewCoefficients], "
        sql &= "[Model], "
        sql &= "[ModelDesc], "
        sql &= "[Fluid], "
        sql &= "[GlycolPercentage], "
        sql &= "[CoolingMedia], "
        sql &= "[SpecificHeat], "
        sql &= "[SpecificGravity], "
        sql &= "[SubCooling], "
        sql &= "[Refrigerant], "
        sql &= "[TempRange], "
        sql &= "[AmbientTemp], "
        sql &= "[LeavingFluidTemp], "
        sql &= "[System], "
        sql &= "[Hertz], "
        sql &= "[Volts], "
        sql &= "[Approach], "
        sql &= "[SafetyOverride], "
        sql &= "[Circuit1], "
        sql &= "[Circuit2], "
        sql &= "[NumCompressors1], "
        sql &= "[NumCompressors2], "
        sql &= "[Compressors1], "
        sql &= "[Compressors2], "
        sql &= "[NumCoils1], "
        sql &= "[NumCoils2], "
        sql &= "[Condenser1], "
        sql &= "[Condenser2], "
        sql &= "[CondenserTD1], "
        sql &= "[CondenserTD2], "
        sql &= "[DischargeLineLoss], "
        sql &= "[SuctionLineLoss], "
        sql &= "[Altitude], "
        sql &= "[CfmOverride], "
        sql &= "[CondenserCapacity1], "
        sql &= "[CondenserCapacity2], "
        sql &= "[EvaporatorModel], "
        sql &= "[EvaporatorModelDesc], "
        sql &= "[NumEvap], "
        sql &= "[FoulingFactor], "
        sql &= "[CapacityType], "
        sql &= "[EvaporatorCapacity], "
        sql &= "[CatalogRating], "
        sql &= "[ApproachRange], "
        sql &= "[Evap8Degr1], "
        sql &= "[Evap8Degr2], "
        sql &= "[Evap10Degr1], "
        sql &= "[Evap10Degr2], "
        sql &= "[Division] "
        sql &= ") values ("
        sql &= "'" & c.ProcessID & "', "
        sql &= "" & c.Revision & ", "
        sql &= "" & c.RevisionDate & ", "
        sql &= "" & c.ProjectRevision & ", "
        sql &= "'" & c.ProcessRevisionDescription.Replace("'", "") & "', "
        sql &= "'" & c.CreatedBy & "', "
        sql &= "'" & c.Version & "', "
        sql &= "'" & c.Notes.Replace("'", "") & "', "
        sql &= "'" & c.Name.Replace("'", "") & "', "
        sql &= "'" & c.Series & "', "
        sql &= "" & c.NewCoefficients & ", "
        sql &= "'" & c.Model & "', "
        sql &= "'" & c.ModelDesc & "', "
        sql &= "'" & c.Fluid & "', "
        sql &= "" & c.GlycolPercentage & ", "
        sql &= "'" & c.CoolingMedia & "', "
        sql &= "" & c.SpecificHeat & ", "
        sql &= "" & c.SpecificGravity & ", "
        sql &= "" & c.SubCooling & ", "
        sql &= "'" & c.Refrigerant & "', "
        sql &= "" & c.TempRange & ", "
        sql &= "" & c.AmbientTemp & ", "
        sql &= "" & c.LeavingFluidTemp & ", "
        sql &= "'" & c.System & "', "
        sql &= "" & c.Hertz & ", "
        sql &= "" & c.Volts & ", "
        sql &= "'" & c.Approach & "', "
        sql &= "" & c.SafetyOverride & ", "
        sql &= "" & c.Circuit1 & ", "
        sql &= "" & c.Circuit2 & ", "
        sql &= "" & c.NumCompressors1 & ", "
        sql &= "" & c.NumCompressors2 & ", "
        sql &= "'" & c.Compressors1 & "', "
        sql &= "'" & c.Compressors2 & "', "
        sql &= "" & c.NumCoils1 & ", "
        sql &= "" & c.NumCoils2 & ", "
        sql &= "'" & c.Condenser1 & "', "
        sql &= "'" & c.Condenser2 & "', "
        sql &= "" & c.CondenserTD1 & ", "
        sql &= "" & c.CondenserTD2 & ", "
        sql &= "" & c.DischargeLineLoss & ", "
        sql &= "" & c.SuctionLineLoss & ", "
        sql &= "" & c.Altitude & ", "
        sql &= "" & c.CfmOverride & ", "
        sql &= "" & c.CondenserCapacity1 & ", "
        sql &= "" & c.CondenserCapacity2 & ", "
        sql &= "'" & c.EvaporatorModel & "', "
        sql &= "'" & c.EvaporatorModelDesc & "', "
        sql &= "" & c.NumEvap & ", "
        sql &= "" & c.FoulingFactor & ", "
        sql &= "'" & c.CapacityType & "', "
        sql &= "" & c.EvaporatorCapacity & ", "
        sql &= "" & c.CatalogRating & ", "
        sql &= "'" & c.ApproachRange & "', "
        sql &= "" & c.Evap8Degr1 & ", "
        sql &= "" & c.Evap8Degr2 & ", "
        sql &= "" & c.Evap10Degr1 & ", "
        sql &= "" & c.Evap10Degr2 & ", "
        sql &= "'" & c.Division & "' "
        sql &= ")"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
        End Try

    End Function




    Private Sub LoadUnitCoolerProcesses(ByVal cloidID As Integer, ByVal uniqueCode As String, ByRef cloudSaveWS As CloudSaveService.CloudSave)
        Dim UnitCoolerProcesses() As CloudSaveService.UnitCoolerProcesses
        UnitCoolerProcesses = cloudSaveWS.LoadUnitCoolerProcesses(cloidID, uniqueCode)

        For Each c As CloudSaveService.UnitCoolerProcesses In UnitCoolerProcesses
            InsertUnitCoolerProcesses(c)
        Next
    End Sub

    Private Function InsertUnitCoolerProcesses(ByVal c As CloudSaveService.UnitCoolerProcesses)
        If c.RevisionDate < minDate Then
            c.RevisionDate = minDate
        End If

        Dim sql = "insert into [UnitCoolerProcesses] ( "
        sql &= "[ProcessId], "
        sql &= "[Revision], "
        sql &= "[RevisionDate], "
        sql &= "[ProjectRevision], "
        sql &= "[RevisionDescription], "
        sql &= "[CreatedBy], "
        sql &= "[Version], "
        sql &= "[Notes], "
        sql &= "[Name], "
        sql &= "[CondensingUnitSeries], "
        sql &= "[ShouldAdjustCapacityForRunTime], "
        sql &= "[NumRunTimeHours], "
        sql &= "[CompressorType], "
        sql &= "[Refrigerant], "
        sql &= "[NumCompressorsPerUnit], "
        sql &= "[NumCircuitsPerUnit], "
        sql &= "[CapacityRequired], "
        sql &= "[Altitude], "
        sql &= "[NumCondensingUnitsRequired], "
        sql &= "[SuctionTemperature], "
        sql &= "[NumRooms], "
        sql &= "[AmbientTemperature], "
        sql &= "[AmbientMinTemperature], "
        sql &= "[AmbientMaxTemperature], "
        sql &= "[AmbientTemperatureIncrement], "
        sql &= "[RoomTemperature], "
        sql &= "[RoomMinTemperature], "
        sql &= "[RoomMaxTemperature], "
        sql &= "[RoomTemperatureIncrement], "
        sql &= "[CondenserCapacityPerDegree], "
        sql &= "[CondensingUnitModel], "
        sql &= "[Series], "
        sql &= "[SuctionLineLoss], "
        sql &= "[ShouldOverrideUnitCoolerCapacityCriteria], "
        sql &= "[SelectedUnitCoolerIndex], "
        sql &= "[UnitCooler1Model], "
        sql &= "[UnitCooler2Model], "
        sql &= "[UnitCooler3Model], "
        sql &= "[UnitCooler1Capacity], "
        sql &= "[UnitCooler2Capacity], "
        sql &= "[UnitCooler3Capacity], "
        sql &= "[UnitCooler1Quantity], "
        sql &= "[UnitCooler2Quantity], "
        sql &= "[UnitCooler3Quantity], "
        sql &= "[Evaporator1CapacityPerDegree], "
        sql &= "[Evaporator2CapacityPerDegree], "
        sql &= "[Evaporator3CapacityPerDegree], "
        sql &= "[IsThereAUnitCooler1], "
        sql &= "[IsThereAUnitCooler2], "
        sql &= "[IsThereAUnitCooler3], "
        sql &= "[IsThereACustomUnitCooler], "
        sql &= "[CustomUnitCoolerModel], "
        sql &= "[CustomUnitCoolerCapacity], "
        sql &= "[CustomUnitCoolerQuantity], "
        sql &= "[CustomUnitCoolerCapacityPerDegree], "
        sql &= "[Balance], "
        sql &= "[EvaporatorTemperature], "
        sql &= "[AirTemperature], "
        sql &= "[CondenserTemperature], "
        sql &= "[Capacity], "
        sql &= "[RunTime], "
        sql &= "[UnitKw], "
        sql &= "[CondenserCapacity], "
        sql &= "[UnitAmps230], "
        sql &= "[UnitAmps460], "
        sql &= "[UnitEer], "
        sql &= "[TemperatureDifference], "
        sql &= "[UnitMca230], "
        sql &= "[UnitMca460], "
        sql &= "[Dimensions], "
        sql &= "[BaseListPrice], "
        sql &= "[CustomCondensingUnit], "
        sql &= "[Division], "
        sql &= "[ObjectLinkXML], "
        sql &= "[ObjectLinkType], "
        sql &= "[static_pressure_1], "
        sql &= "[static_pressure_2], "
        sql &= "[static_pressure_3], "
        sql &= "[DOEModel] "
        sql &= ") values ("
        sql &= "'" & c.ProcessId & "', "
        sql &= "" & c.Revision & ", "
        sql &= "" & c.RevisionDate & ", "
        sql &= "" & c.ProjectRevision & ", "
        sql &= "'" & c.RevisionDescription.Replace("'", "") & "', "
        sql &= "'" & c.CreatedBy & "', "
        sql &= "'" & c.Version & "', "
        sql &= "'" & c.Notes.Replace("'", "") & "', "
        sql &= "'" & c.Name.Replace("'", "") & "', "
        sql &= "'" & c.CondensingUnitSeries & "', "
        sql &= "" & c.ShouldAdjustCapacityForRunTime & ", "
        sql &= "" & c.NumRunTimeHours & ", "
        sql &= "'" & c.CompressorType & "', "
        sql &= "'" & c.Refrigerant & "', "
        sql &= "" & c.NumCompressorsPerUnit & ", "
        sql &= "" & c.NumCircuitsPerUnit & ", "
        sql &= "" & c.CapacityRequired & ", "
        sql &= "" & c.Altitude & ", "
        sql &= "" & c.NumCondensingUnitsRequired & ", "
        sql &= "" & c.SuctionTemperature & ", "
        sql &= "" & c.NumRooms & ", "
        sql &= "" & c.AmbientTemperature & ", "
        sql &= "" & c.AmbientMinTemperature & ", "
        sql &= "" & c.AmbientMaxTemperature & ", "
        sql &= "" & c.AmbientTemperatureIncrement & ", "
        sql &= "" & c.RoomTemperature & ", "
        sql &= "" & c.RoomMinTemperature & ", "
        sql &= "" & c.RoomMaxTemperature & ", "
        sql &= "" & c.RoomTemperatureIncrement & ", "
        sql &= "" & c.CondenserCapacityPerDegree & ", "
        sql &= "'" & c.CondensingUnitModel & "', "
        sql &= "'" & c.Series & "', "
        sql &= "" & c.SuctionLineLoss & ", "
        sql &= "" & c.ShouldOverrideUnitCoolerCapacityCriteria & ", "
        sql &= "" & c.SelectedUnitCoolerIndex & ", "
        sql &= "'" & c.UnitCooler1Model & "', "
        sql &= "'" & c.UnitCooler2Model & "', "
        sql &= "'" & c.UnitCooler3Model & "', "
        sql &= "" & c.UnitCooler1Capacity & ", "
        sql &= "" & c.UnitCooler2Capacity & ", "
        sql &= "" & c.UnitCooler3Capacity & ", "
        sql &= "" & c.UnitCooler1Quantity & ", "
        sql &= "" & c.UnitCooler2Quantity & ", "
        sql &= "" & c.UnitCooler3Quantity & ", "
        sql &= "" & c.Evaporator1CapacityPerDegree & ", "
        sql &= "" & c.Evaporator2CapacityPerDegree & ", "
        sql &= "" & c.Evaporator3CapacityPerDegree & ", "
        sql &= "" & c.IsThereAUnitCooler1 & ", "
        sql &= "" & c.IsThereAUnitCooler2 & ", "
        sql &= "" & c.IsThereAUnitCooler3 & ", "
        sql &= "" & c.IsThereACustomUnitCooler & ", "
        sql &= "'" & c.CustomUnitCoolerModel & "', "
        sql &= "" & c.CustomUnitCoolerCapacity & ", "
        sql &= "" & c.CustomUnitCoolerQuantity & ", "
        sql &= "" & c.CustomUnitCoolerCapacityPerDegree & ", "
        sql &= "" & c.Balance & ", "
        sql &= "" & c.EvaporatorTemperature & ", "
        sql &= "" & c.AirTemperature & ", "
        sql &= "" & c.CondenserTemperature & ", "
        sql &= "" & c.Capacity & ", "
        sql &= "" & c.RunTime & ", "
        sql &= "" & c.UnitKw & ", "
        sql &= "" & c.CondenserCapacity & ", "
        sql &= "" & c.UnitAmps230 & ", "
        sql &= "" & c.UnitAmps460 & ", "
        sql &= "" & c.UnitEer & ", "
        sql &= "" & c.TemperatureDifference & ", "
        sql &= "" & c.UnitMca230 & ", "
        sql &= "" & c.UnitMca460 & ", "
        sql &= "'" & c.Dimensions & "', "
        sql &= "" & c.BaseListPrice & ", "
        sql &= "'" & c.CustomCondensingUnit & "', "
        sql &= "'" & c.Division & "', "
        sql &= "'" & c.ObjectLinkXML & "', "
        sql &= "'" & c.ObjectLinkType & "', "
        sql &= "" & c.static_pressure_1 & ", "
        sql &= "" & c.static_pressure_2 & ", "
        sql &= "" & c.static_pressure_3 & ", "
        sql &= "'" & c.DOEModel & "' "
        sql &= ")"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
        End Try

    End Function

    Private Sub LoadProjectContacts(ByVal cloidID As Integer, ByVal uniqueCode As String, ByRef cloudSaveWS As CloudSaveService.CloudSave)
        Dim ProjectContacts() As CloudSaveService.ProjectContacts
        ProjectContacts = cloudSaveWS.LoadProjectContactsRecords(cloidID, uniqueCode)

        For Each c As CloudSaveService.ProjectContacts In ProjectContacts
            InsertProjectContacts(c)
        Next
    End Sub

    Private Function InsertProjectContacts(ByVal c As CloudSaveService.ProjectContacts)
        Dim sql = "insert into [ProjectContacts] ( "
        sql &= "[ProjectId], "
        sql &= "[ContactId] "
        sql &= ") values ("
        sql &= "'" & c.ProjectId & "', "
        sql &= "'" & c.ContactId & "' "
        sql &= ")"


        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
        End Try

    End Function

    Private Sub LoadOrderEntryContacts(ByVal cloidID As Integer, ByVal uniqueCode As String, ByRef cloudSaveWS As CloudSaveService.CloudSave)
        Dim ProjectContacts() As CloudSaveService.OrderEntryContacts
        ProjectContacts = cloudSaveWS.LoadOrderEntryContacts(cloidID, uniqueCode)

        For Each c As CloudSaveService.OrderEntryContacts In ProjectContacts
            InsertOrderEntryContacts(c)
        Next
    End Sub

    Private Function InsertOrderEntryContacts(ByVal c As CloudSaveService.OrderEntryContacts)
        Dim sql = "insert into [OrderEntryContacts] ( "
        sql &= "[ProjectId], "
        sql &= "[Name], "
        sql &= "[Address1], "
        sql &= "[Address2], "
        sql &= "[State], "
        sql &= "[City], "
        sql &= "[Zip], "
        sql &= "[Phone], "
        sql &= "[ContactType], "
        sql &= "[ImportedFromCloud]"
        sql &= ") values ("
        sql &= "@projectID, "
        sql &= "@name, "
        sql &= "@address1, "
        sql &= "@address2, "
        sql &= "@state, "
        sql &= "@city, "
        sql &= "@zip, "
        sql &= "@phone, "
        sql &= "@contactType, "
        sql &= "@importedFromCloud"
        sql &= ")"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command As New OleDbCommand
        command.Connection = connection
        command.CommandType = CommandType.Text
        command.CommandText = sql

        command.Parameters.Add("@projectID", OleDbType.VarChar)
        command.Parameters("@projectID").Value = c.ProjectId
        command.Parameters.Add("@name", OleDbType.VarChar)
        command.Parameters("@name").Value = c.Name
        command.Parameters.Add("@address1", OleDbType.VarChar)
        command.Parameters("@address1").Value = c.address1
        command.Parameters.Add("@address2", OleDbType.VarChar)
        command.Parameters("@address2").Value = c.address2
        command.Parameters.Add("@state", OleDbType.VarChar)
        command.Parameters("@state").Value = c.State
        command.Parameters.Add("@city", OleDbType.VarChar)
        command.Parameters("@city").Value = c.City
        command.Parameters.Add("@zip", OleDbType.VarChar)
        command.Parameters("@zip").Value = c.Zip
        command.Parameters.Add("@phone", OleDbType.VarChar)
        command.Parameters("@phone").Value = c.Phone
        command.Parameters.Add("@contactType", OleDbType.VarChar)
        command.Parameters("@contactType").Value = c.ContactType
        command.Parameters.Add("@importedFromCloud", OleDbType.VarChar)
        command.Parameters("@importedFromCloud").Value = "True"

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
        End Try

    End Function

    Private Sub LoadContacts(ByVal cloidID As Integer, ByVal uniqueCode As String, ByRef cloudSaveWS As CloudSaveService.CloudSave)
        Dim Contacts() As CloudSaveService.Contacts1
        Contacts = cloudSaveWS.LoadContactsRecords1(cloidID, uniqueCode)

        For Each c As CloudSaveService.Contacts1 In Contacts
            InsertContacts(c)
        Next
    End Sub

    Private Function InsertContacts(ByVal c As CloudSaveService.Contacts1)
        Dim sql = "insert into [Contacts] ( "
        sql &= "[CustomerNum], "
        sql &= "[RepNum], "
        sql &= "[FirstName], "
        sql &= "[LastName], "
        sql &= "[CompanyId], "
        sql &= "[Email], "
        sql &= "[Description], "
        sql &= "[Line1], "
        sql &= "[Line2], "
        sql &= "[City], "
        sql &= "[State], "
        sql &= "[ZipCode5], "
        sql &= "[ZipCode4], "
        sql &= "[PhoneNumAreaCode], "
        sql &= "[PhoneNum], "
        sql &= "[PhoneNumExtension], "
        sql &= "[FaxNum], "
        sql &= "[FaxNumAreaCode], "
        sql &= "[ProjectID] "
        sql &= ") values ("
        sql &= "'" & c.CustomerNum & "', "
        sql &= "'" & c.RepNum & "', "
        sql &= "'" & c.FirstName.Replace("'", "") & "', "
        sql &= "'" & c.LastName.Replace("'", "") & "', "
        sql &= "'" & c.CompanyId & "', "
        sql &= "'" & c.Email.Replace("'", "") & "', "
        sql &= "'" & c.Description & "', "
        sql &= "'" & c.Line1.Replace("'", "") & "', "
        sql &= "'" & c.Line2.Replace("'", "") & "', "
        sql &= "'" & c.City.Replace("'", "") & "', "
        sql &= "'" & c.State & "', "
        sql &= "'" & c.ZipCode5 & "', "
        sql &= "'" & c.ZipCode4 & "', "
        sql &= "'" & c.PhoneNumAreaCode & "', "
        sql &= "'" & c.PhoneNum & "', "
        sql &= "'" & c.PhoneNumExtension & "', "
        sql &= "'" & c.FaxNum & "', "
        sql &= "'" & c.FaxNumAreaCode & "', "
        sql &= "'" & c.ProjectID & "' "
        sql &= ")"


        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
        End Try

    End Function


    Private Sub LoadCompanies(ByVal cloidID As Integer, ByVal uniqueCode As String, ByRef cloudSaveWS As CloudSaveService.CloudSave)
        Dim Companies() As CloudSaveService.Companies
        Companies = cloudSaveWS.LoadCompaniesRecords(cloidID, uniqueCode)

        For Each c As CloudSaveService.Companies In Companies
            InsertCompanies(c)
        Next
    End Sub

    Private Function InsertCompanies(ByVal c As CloudSaveService.Companies)
        Dim sql = "insert into [Companies] ( "
        sql &= "[CustomerNum], "
        sql &= "[RepNum], "
        sql &= "[Name], "
        sql &= "[Website], "
        sql &= "[Email], "
        sql &= "[Description], "
        sql &= "[Line1], "
        sql &= "[Line2], "
        sql &= "[City], "
        sql &= "[State], "
        sql &= "[ZipCode5], "
        sql &= "[ZipCode4], "
        sql &= "[PhoneNumAreaCode], "
        sql &= "[PhoneNum], "
        sql &= "[PhoneNumExtension], "
        sql &= "[FaxNum], "
        sql &= "[FaxNumAreaCode] "
        sql &= ") values ("
        sql &= "'" & c.CustomerNum & "', "
        sql &= "'" & c.RepNum & "', "
        sql &= "'" & c.Name.Replace("'", "") & "', "
        sql &= "'" & c.Website.Replace("'", "") & "', "
        sql &= "'" & c.Email.Replace("'", "") & "', "
        sql &= "'" & c.Description.Replace("'", "") & "', "
        sql &= "'" & c.Line1.Replace("'", "") & "', "
        sql &= "'" & c.Line2.Replace("'", "") & "', "
        sql &= "'" & c.City.Replace("'", "") & "', "
        sql &= "'" & c.State & "', "
        sql &= "'" & c.ZipCode5 & "', "
        sql &= "'" & c.ZipCode4 & "', "
        sql &= "'" & c.PhoneNumAreaCode & "', "
        sql &= "'" & c.PhoneNum & "', "
        sql &= "'" & c.PhoneNumExtension & "', "
        sql &= "'" & c.FaxNum & "', "
        sql &= "'" & c.FaxNumAreaCode & "' "
        sql &= ")"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
        End Try

    End Function

    Private Sub LoadUnitCooler(ByVal cloidID As Integer, ByVal uniqueCode As String, ByRef cloudSaveWS As CloudSaveService.CloudSave)
        Dim UnitCooler() As CloudSaveService.UnitCooler
        UnitCooler = cloudSaveWS.LoadUnitCooler(cloidID, uniqueCode)

        For Each c As CloudSaveService.UnitCooler In UnitCooler
            InsertUnitCooler(c)
        Next
    End Sub

    Private Function InsertUnitCooler(ByVal c As CloudSaveService.UnitCooler)
        Dim sql = "insert into [UnitCooler] ( "
        sql &= "[EquipmentId], "
        sql &= "[EvaporatorTemp], "
        sql &= "[BoxTemp], "
        sql &= "[CondensingTemp], "
        sql &= "[TempDifference], "
        sql &= "[LiquidTemp], "
        sql &= "[Capacity], "
        sql &= "[Refrigerant], "
        sql &= "[Revision], "
        sql &= "[DefrostVoltage], "
        sql &= "[FanVoltage], "
        sql &= "[UnitCoolerType] "
        sql &= ") values ("
        sql &= "'" & c.EquipmentId & "', "
        sql &= "" & c.EvaporatorTemp & ", "
        sql &= "" & c.BoxTemp & ", "
        sql &= "" & c.CondensingTemp & ", "
        sql &= "" & c.TempDifference & ", "
        sql &= "" & c.LiquidTemp & ", "
        sql &= "" & c.Capacity & ", "
        sql &= "'" & c.Refrigerant & "', "
        sql &= "" & c.Revision & ", "
        sql &= "'" & c.DefrostVoltage & "', "
        sql &= "'" & c.FanVoltage & "', "
        sql &= "'" & c.UnitCoolerType & "' "
        sql &= ")"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
        End Try

    End Function




    Private Sub LoadSpecialOptions(ByVal cloidID As Integer, ByVal uniqueCode As String, ByRef cloudSaveWS As CloudSaveService.CloudSave)
        Dim SpecialOptions() As CloudSaveService.SpecialOptions
        SpecialOptions = cloudSaveWS.LoadSpecialOptions(cloidID, uniqueCode)

        For Each c As CloudSaveService.SpecialOptions In SpecialOptions
            InsertSpecialOptions(c)
        Next
    End Sub

    Private Function InsertSpecialOptions(ByVal c As CloudSaveService.SpecialOptions)
        Dim sql = "insert into [SpecialOptions] ( "
        '    sql &= "[Id], "
        sql &= "[Revision], "
        sql &= "[EquipmentId], "
        sql &= "[Code], "
        sql &= "[Description], "
        sql &= "[Quantity], "
        sql &= "[Price], "
        sql &= "[AuthorizedFor], "
        sql &= "[AuthorizedBy] "
        sql &= ") values ("
        ' sql &= "" & c.Id & ", "
        sql &= "" & c.Revision & ", "
        sql &= "'" & c.EquipmentId & "', "
        sql &= "'" & c.Code & "', "
        sql &= "'" & c.Description.Replace("'", "") & "', "
        sql &= "" & c.Quantity & ", "
        sql &= "" & c.Price & ", "
        sql &= "'" & c.AuthorizedFor & "', "
        sql &= "'" & c.AuthorizedBy & "' "
        sql &= ")"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
        End Try

    End Function




    Private Sub LoadRatingEquipment(ByVal cloidID As Integer, ByVal uniqueCode As String, ByRef cloudSaveWS As CloudSaveService.CloudSave)
        Dim RatingEquipment() As CloudSaveService.RatingEquipment
        RatingEquipment = cloudSaveWS.LoadRatingEquipment(cloidID, uniqueCode)

        For Each c As CloudSaveService.RatingEquipment In RatingEquipment
            InsertRatingEquipment(c)
        Next
    End Sub

    Private Function InsertRatingEquipment(ByVal c As CloudSaveService.RatingEquipment)
        Dim sql = "insert into [RatingEquipment] ( "
        sql &= "[ProjectID], "
        sql &= "[ProjectRevision], "
        sql &= "[EquipmentID], "
        sql &= "[Revision], "
        sql &= "[RatingEquipmentXML] "
        sql &= ") values ("
        sql &= "'" & c.ProjectID & "', "
        sql &= "" & c.ProjectRevision & ", "
        sql &= "'" & c.EquipmentID & "', "
        sql &= "" & c.Revision & ", "
        sql &= "'" & c.RatingEquipmentXML & "' "
        sql &= ")"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
        End Try

    End Function



    Private Sub LoadPumpPackage(ByVal cloidID As Integer, ByVal uniqueCode As String, ByRef cloudSaveWS As CloudSaveService.CloudSave)
        Dim PumpPackage() As CloudSaveService.PumpPackage
        PumpPackage = cloudSaveWS.LoadPumpPackage(cloidID, uniqueCode)

        For Each c As CloudSaveService.PumpPackage In PumpPackage
            InsertPumpPackage(c)
        Next
    End Sub

    Private Function InsertPumpPackage(ByVal c As CloudSaveService.PumpPackage)
        Dim sql = "insert into [PumpPackage] ( "
        sql &= "[EquipmentId], "
        sql &= "[Revision], "
        sql &= "[Manufacturer], "
        sql &= "[Flow], "
        sql &= "[Head], "
        sql &= "[System], "
        sql &= "[ChillerId] "
        sql &= ") values ("
        sql &= "'" & c.EquipmentId & "', "
        sql &= "" & c.Revision & ", "
        sql &= "'" & c.Manufacturer & "', "
        sql &= "" & c.Flow & ", "
        sql &= "" & c.Head & ", "
        sql &= "'" & c.System & "', "
        sql &= "'" & c.ChillerId & "' "
        sql &= ")"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
        End Try

    End Function




    Private Sub LoadProjects(ByVal cloidID As Integer, ByVal uniqueCode As String, ByRef cloudSaveWS As CloudSaveService.CloudSave)
        Dim Projects() As CloudSaveService.Projects
        Projects = cloudSaveWS.LoadProjects(cloidID, uniqueCode)

        For Each c As CloudSaveService.Projects In Projects
            InsertProjects(c)
        Next
    End Sub

    'Private Function InsertProjects(ByVal c As CloudSaveService.Projects)


    '    Dim pID As String
    '    pID = c.ProjectId


    '    'If pID.Contains("+") Then
    '    '    pID = AppInfo.User.username & pID.Substring(pID.IndexOf("+"))
    '    'End If

    '    'If Not String.IsNullOrEmpty(c.ProjectOwner) Then
    '    '    pID = pID.ToUpper.Replace(c.ProjectOwner, AppInfo.User.username)
    '    'End If


    '    Dim sql = "insert into [Projects] ( "
    '    sql &= "[ProjectId], "
    '    sql &= "[ProjectRevision], "
    '    sql &= "[Name], "
    '    sql &= "[Notes], "
    '    sql &= "[Tag], "
    '    sql &= "[ReleaseStatus], "
    '    sql &= "[ReleaseNum], "
    '    sql &= "[HoursBeforeDeliveryToCall], "
    '    sql &= "[PoNum], "
    '    sql &= "[PoDate], "
    '    sql &= "[RequestedShipDate], "
    '    sql &= "[SalesClass], "
    '    sql &= "[RepId], "
    '    sql &= "[ArchitectName], "
    '    sql &= "[ContractorName], "
    '    sql &= "[EngineerName], "
    '    sql &= "[RepCompanyId], "
    '    sql &= "[ArchitectCompanyName], "
    '    sql &= "[ContractorCompanyName], "
    '    sql &= "[EngineerCompanyName], "
    '    sql &= "[Description], "
    '    sql &= "[ContactDataStructure], "
    '    sql &= "[ProjectOwner], "
    '    sql &= "[OpenedBy], "
    '    sql &= "[CheckedOutBy], "
    '    sql &= "[RevisionDate] "
    '    sql &= ") values ("
    '    sql &= "'" & pID & "', "
    '    sql &= "" & c.ProjectRevision & ", "
    '    sql &= "'" & c.Name & "', "
    '    sql &= "'" & c.Notes & "', "
    '    sql &= "'" & c.Tag & "', "
    '    sql &= "'" & c.ReleaseStatus & "', "
    '    sql &= "" & c.ReleaseNum & ", "
    '    sql &= "" & c.HoursBeforeDeliveryToCall & ", "
    '    sql &= "" & c.PoNum & ", "
    '    sql &= "" & c.PoDate & ", "
    '    sql &= "" & c.RequestedShipDate & ", "
    '    sql &= "'" & c.SalesClass & "', "
    '    sql &= "" & c.RepId & ", "
    '    sql &= "'" & c.ArchitectName & "', "
    '    sql &= "'" & c.ContractorName & "', "
    '    sql &= "'" & c.EngineerName & "', "
    '    sql &= "" & c.RepCompanyId & ", "
    '    sql &= "'" & c.ArchitectCompanyName & "', "
    '    sql &= "'" & c.ContractorCompanyName & "', "
    '    sql &= "'" & c.EngineerCompanyName & "', "
    '    sql &= "'" & c.Description & "', "
    '    sql &= "'" & c.ContactDataStructure & "', "
    '    sql &= "'" & c.ProjectOwner & "', "
    '    sql &= "'" & c.OpenedBy & "', "
    '    sql &= "'" & c.CheckedOutBy & "', "
    '    sql &= "" & c.RevisionDate & " "
    '    sql &= ")"

    '    Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
    '    Dim command = connection.CreateCommand
    '    command.CommandText = sql

    '    Try
    '        connection.Open()
    '        command.ExecuteNonQuery()
    '    Finally
    '        If connection.State <> ConnectionState.Closed Then connection.Close()
    '    End Try

    'End Function

    Private Function InsertProjects(ByVal c As CloudSaveService.Projects)


        Dim pID As String
        pID = c.ProjectId


        'If pID.Contains("+") Then
        '    pID = AppInfo.User.username & pID.Substring(pID.IndexOf("+"))
        'End If

        'If Not String.IsNullOrEmpty(c.ProjectOwner) Then
        '    pID = pID.ToUpper.Replace(c.ProjectOwner, AppInfo.User.username)
        'End If

        'Dim minDate As DateTime = DateTime.Parse("1900-01-01 00:00:00")

        If c.PoDate < minDate Then
            c.PoDate = minDate
        End If

        If c.RevisionDate < minDate Then
            c.RevisionDate = minDate
        End If

        If c.RequestedShipDate < minDate Then
            c.RequestedShipDate = minDate
        End If

        Dim sql = "insert into [Projects] ( "
        sql &= "[ProjectId], "
        sql &= "[ProjectRevision], "
        sql &= "[Name], "
        sql &= "[Notes], "
        sql &= "[Tag], "
        sql &= "[ReleaseStatus], "
        sql &= "[ReleaseNum], "
        sql &= "[HoursBeforeDeliveryToCall], "
        sql &= "[PoNum], "
        sql &= "[PoDate], "
        sql &= "[RequestedShipDate], "
        sql &= "[SalesClass], "
        sql &= "[RepId], "
        sql &= "[ArchitectName], "
        sql &= "[ContractorName], "
        sql &= "[EngineerName], "
        sql &= "[RepCompanyId], "
        sql &= "[ArchitectCompanyName], "
        sql &= "[ContractorCompanyName], "
        sql &= "[EngineerCompanyName], "
        sql &= "[Description], "
        sql &= "[ContactDataStructure], "
        sql &= "[ProjectOwner], "
        sql &= "[OpenedBy], "
        sql &= "[CheckedOutBy], "
        sql &= "[RevisionDate] "
        sql &= ") values ("
        sql &= "@pID, "
        sql &= "@projectRevision, "
        sql &= "@name, "
        sql &= "@notes, "
        sql &= "@tag, "
        sql &= "@releaseStatus, "
        sql &= "@releaseNum, "
        sql &= "@hoursToCall, "
        sql &= "@poNum, "
        sql &= "@poDate, "
        sql &= "@requestedShipDate, "
        sql &= "@salesClass, "
        sql &= "@repID, "
        sql &= "@architectName, "
        sql &= "@contractorName, "
        sql &= "@engineerName, "
        sql &= "@repCompanyID, "
        sql &= "@architectCompanyName, "
        sql &= "@contractorCompanyName, "
        sql &= "@engineerCompanyName, "
        sql &= "@description, "
        sql &= "@contactDataStructure, "
        sql &= "@projectOwner, "
        sql &= "@openedBy, "
        sql &= "@checkedOutBy, "
        sql &= "@revisionDate"
        sql &= ")"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command As New OleDbCommand
        command.Connection = connection
        command.CommandType = CommandType.Text

        command.Parameters.Add("@pID", OleDbType.VarChar)
        command.Parameters("@pID").Value = pID
        command.Parameters.Add("@projectRevision", OleDbType.VarChar)
        command.Parameters("@projectRevision").Value = c.ProjectRevision
        command.Parameters.Add("@name", OleDbType.VarChar)
        command.Parameters("@name").Value = c.Name
        command.Parameters.Add("@notes", OleDbType.VarChar)
        command.Parameters("@notes").Value = c.Notes
        command.Parameters.Add("@tag", OleDbType.VarChar)
        command.Parameters("@tag").Value = c.Tag
        command.Parameters.Add("@releaseStatus", OleDbType.VarChar)
        command.Parameters("@releaseStatus").Value = c.ReleaseStatus
        command.Parameters.Add("@releaseNum", OleDbType.Integer)
        command.Parameters("@releaseNum").Value = c.ReleaseNum
        command.Parameters.Add("@hoursToCall", OleDbType.Single)
        command.Parameters("@hoursToCall").Value = c.HoursBeforeDeliveryToCall
        command.Parameters.Add("@poNum", OleDbType.Integer)
        command.Parameters("@poNum").Value = c.PoNum
        command.Parameters.Add("@poDate", OleDbType.DBDate)
        command.Parameters("@poDate").Value = c.PoDate
        command.Parameters.Add("@requestedShipDate", OleDbType.DBDate)
        command.Parameters("@requestedShipDate").Value = c.RequestedShipDate
        command.Parameters.Add("@salesClass", OleDbType.VarChar)
        command.Parameters("@salesClass").Value = c.SalesClass
        command.Parameters.Add("@repID", OleDbType.Integer)
        command.Parameters("@repID").Value = c.RepId
        command.Parameters.Add("@architectName", OleDbType.VarChar)
        command.Parameters("@architectName").Value = c.ArchitectName
        command.Parameters.Add("@contractorName", OleDbType.VarChar)
        command.Parameters("@contractorName").Value = c.ContractorName
        command.Parameters.Add("@engineerName", OleDbType.VarChar)
        command.Parameters("@engineerName").Value = c.EngineerName
        command.Parameters.Add("@repCompanyID", OleDbType.VarChar)
        command.Parameters("@repCompanyID").Value = c.RepCompanyId
        command.Parameters.Add("@architectCompanyName", OleDbType.VarChar)
        command.Parameters("@architectCompanyName").Value = c.ArchitectCompanyName
        command.Parameters.Add("@contractorCompanyName", OleDbType.VarChar)
        command.Parameters("@contractorCompanyName").Value = c.ContractorCompanyName
        command.Parameters.Add("@engineerCompanyName", OleDbType.VarChar)
        command.Parameters("@engineerCompanyName").Value = c.EngineerCompanyName
        command.Parameters.Add("@description", OleDbType.VarChar)
        command.Parameters("@description").Value = c.Description
        command.Parameters.Add("@contactDataStructure", OleDbType.VarChar)
        command.Parameters("@contactDataStructure").Value = c.ContactDataStructure
        command.Parameters.Add("@projectOwner", OleDbType.VarChar)
        command.Parameters("@projectOwner").Value = c.ProjectOwner
        command.Parameters.Add("@openedBy", OleDbType.VarChar)
        command.Parameters("@openedBy").Value = c.OpenedBy
        command.Parameters.Add("@checkedOutBy", OleDbType.VarChar)
        command.Parameters("@checkedOutBy").Value = c.CheckedOutBy
        command.Parameters.Add("@revisionDate", OleDbType.DBDate)
        command.Parameters("@revisionDate").Value = c.RevisionDate


        command.CommandText = sql

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
        End Try

    End Function



    Private Sub LoadProductCooler(ByVal cloidID As Integer, ByVal uniqueCode As String, ByRef cloudSaveWS As CloudSaveService.CloudSave)
        Dim ProductCooler() As CloudSaveService.ProductCooler
        ProductCooler = cloudSaveWS.LoadProductCooler(cloidID, uniqueCode)

        For Each c As CloudSaveService.ProductCooler In ProductCooler
            InsertProductCooler(c)
        Next
    End Sub

    Private Function InsertProductCooler(ByVal c As CloudSaveService.ProductCooler)
        Dim sql = "insert into [ProductCooler] ( "
        sql &= "[EquipmentId], "
        sql &= "[Revision], "
        sql &= "[Capacity], "
        sql &= "[EvaporatorTemp], "
        sql &= "[BoxTemp], "
        sql &= "[TempDifference], "
        sql &= "[CondensingTemp], "
        sql &= "[LiquidTemp], "
        sql &= "[Refrigerant] "
        sql &= ") values ("
        sql &= "'" & c.EquipmentId & "', "
        sql &= "" & c.Revision & ", "
        sql &= "" & c.Capacity & ", "
        sql &= "" & c.EvaporatorTemp & ", "
        sql &= "" & c.BoxTemp & ", "
        sql &= "" & c.TempDifference & ", "
        sql &= "" & c.CondensingTemp & ", "
        sql &= "" & c.LiquidTemp & ", "
        sql &= "'" & c.Refrigerant & "' "
        sql &= ")"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
        End Try

    End Function





    Private Sub LoadProcessSpecific(ByVal cloidID As Integer, ByVal uniqueCode As String, ByRef cloudSaveWS As CloudSaveService.CloudSave)
        Dim ProcessSpecific() As CloudSaveService.ProcessSpecific
        ProcessSpecific = cloudSaveWS.LoadProcessSpecific(cloidID, uniqueCode)

        For Each c As CloudSaveService.ProcessSpecific In ProcessSpecific
            InsertProcessSpecific(c)
        Next
    End Sub

    Private Function InsertProcessSpecific(ByVal c As CloudSaveService.ProcessSpecific)
        Dim sql = "insert into [ProcessSpecific] ( "
        sql &= "[ProcessID], "
        sql &= "[ControlName], "
        sql &= "[ControlValue], "
        sql &= "[LoadOrder], "
        sql &= "[FireProcedure] "
        sql &= ") values ("
        sql &= "'" & c.ProcessID & "', "
        sql &= "'" & c.ControlName.Replace("'", "") & "', "
        sql &= "'" & c.ControlValue & "', "
        sql &= "'" & c.LoadOrder & "', "
        sql &= "'" & c.FireProcedure & "' "
        sql &= ")"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
        End Try

    End Function



    Private Sub LoadProcesses(ByVal cloidID As Integer, ByVal uniqueCode As String, ByRef cloudSaveWS As CloudSaveService.CloudSave)
        Dim Processes() As CloudSaveService.Processes
        Processes = cloudSaveWS.LoadProcesses(cloidID, uniqueCode)

        For Each c As CloudSaveService.Processes In Processes
            InsertProcesses(c)
        Next
    End Sub

    Private Function InsertProcesses(ByVal c As CloudSaveService.Processes)
        Dim sql = "insert into [Processes] ( "
        sql &= "[ID], "
        sql &= "[ProjectID], "
        sql &= "[ProcessTableName] "
        sql &= ") values ("
        sql &= "'" & c.ID & "', "
        sql &= "'" & c.ProjectID & "', "
        sql &= "'" & c.ProcessTableName & "' "
        sql &= ")"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
        End Try

    End Function







    Private Sub LoadProcessEquip(ByVal cloidID As Integer, ByVal uniqueCode As String, ByRef cloudSaveWS As CloudSaveService.CloudSave)
        Dim ProcessEquip() As CloudSaveService.ProcessEquip
        ProcessEquip = cloudSaveWS.LoadProcessEquip(cloidID, uniqueCode)

        For Each c As CloudSaveService.ProcessEquip In ProcessEquip
            InsertProcessEquip(c)
        Next
    End Sub

    Private Function InsertProcessEquip(ByVal c As CloudSaveService.ProcessEquip)
        Dim sql = "insert into [ProcessEquip] ( "
        sql &= "[ID], "
        sql &= "[ProcessID], "
        sql &= "[EquipmentID] "
        sql &= ") values ("
        sql &= "'" & c.ID & "', "
        sql &= "'" & c.ProcessID & "', "
        sql &= "'" & c.EquipmentID & "' "
        sql &= ")"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
        End Try

    End Function




    Private Sub LoadFluidCoolerProcesses(ByVal cloidID As Integer, ByVal uniqueCode As String, ByRef cloudSaveWS As CloudSaveService.CloudSave)
        Dim FluidCoolerProcesses() As CloudSaveService.FluidCoolerProcesses
        FluidCoolerProcesses = cloudSaveWS.LoadFluidCoolerProcesses(cloidID, uniqueCode)

        For Each c As CloudSaveService.FluidCoolerProcesses In FluidCoolerProcesses
            InsertFluidCoolerProcesses(c)
        Next
    End Sub

    Private Function InsertFluidCoolerProcesses(ByVal c As CloudSaveService.FluidCoolerProcesses)
        If c.RevisionDate < minDate Then
            c.RevisionDate = minDate
        End If

        Dim sql = "insert into [FluidCoolerProcesses] ( "
        sql &= "[ProcessID], "
        sql &= "[Revision], "
        sql &= "[RevisionDate], "
        sql &= "[ProjectRevision], "
        sql &= "[ProcessRevisionDescription], "
        sql &= "[CreatedBy], "
        sql &= "[Name], "
        sql &= "[Altitude], "
        sql &= "[Capacity], "
        sql &= "[AmbientTemp], "
        sql &= "[EnteringFluidTemp], "
        sql &= "[LeavingFluidTemp], "
        sql &= "[GlycolPercent], "
        sql &= "[Fluid], "
        sql &= "[Flow], "
        sql &= "[FluidCoolerXML] "
        sql &= ") values ("
        sql &= "'" & c.ProcessID & "', "
        sql &= "" & c.Revision & ", "
        sql &= "" & c.RevisionDate & ", "
        sql &= "" & c.ProjectRevision & ", "
        sql &= "'" & c.ProcessRevisionDescription.Replace("'", "") & "', "
        sql &= "'" & c.CreatedBy & "', "
        sql &= "'" & c.Name.Replace("'", "") & "', "
        sql &= "" & c.Altitude & ", "
        sql &= "" & c.Capacity & ", "
        sql &= "" & c.AmbientTemp & ", "
        sql &= "" & c.EnteringFluidTemp & ", "
        sql &= "" & c.LeavingFluidTemp & ", "
        sql &= "" & c.GlycolPercent & ", "
        sql &= "'" & c.Fluid & "', "
        sql &= "" & c.Flow & ", "
        sql &= "'" & c.FluidCoolerXML & "' "
        sql &= ")"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
        End Try

    End Function



    Private Sub LoadFluidCooler(ByVal cloidID As Integer, ByVal uniqueCode As String, ByRef cloudSaveWS As CloudSaveService.CloudSave)
        Dim FluidCooler() As CloudSaveService.FluidCooler
        FluidCooler = cloudSaveWS.LoadFluidCooler(cloidID, uniqueCode)

        For Each c As CloudSaveService.FluidCooler In FluidCooler
            InsertFluidCooler(c)
        Next
    End Sub

    Private Function InsertFluidCooler(ByVal c As CloudSaveService.FluidCooler)
        Dim sql = "insert into [FluidCooler] ( "
        sql &= "[EquipmentId], "
        sql &= "[Revision], "
        sql &= "[Capacity], "
        sql &= "[AmbientTemp], "
        sql &= "[EnteringFluidTemp], "
        sql &= "[LeavingFluidTemp], "
        sql &= "[GlycolPercent], "
        sql &= "[Fluid], "
        sql &= "[Flow], "
        sql &= "[Refrigerant] "
        sql &= ") values ("
        sql &= "'" & c.EquipmentId & "', "
        sql &= "" & c.Revision & ", "
        sql &= "" & c.Capacity & ", "
        sql &= "" & c.AmbientTemp & ", "
        sql &= "" & c.EnteringFluidTemp & ", "
        sql &= "" & c.LeavingFluidTemp & ", "
        sql &= "" & c.GlycolPercent & ", "
        sql &= "'" & c.Fluid & "', "
        sql &= "" & c.Flow & ", "
        sql &= "'" & c.Refrigerant & "' "
        sql &= ")"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
        End Try

    End Function





    Private Sub LoadEvapChillerProcesses(ByVal cloidID As Integer, ByVal uniqueCode As String, ByRef cloudSaveWS As CloudSaveService.CloudSave)
        Dim EvapChillerProcesses() As CloudSaveService.EvapChillerProcesses
        EvapChillerProcesses = cloudSaveWS.LoadEvapChillerProcesses(cloidID, uniqueCode)

        For Each c As CloudSaveService.EvapChillerProcesses In EvapChillerProcesses
            InsertEvapChillerProcesses(c)
        Next
    End Sub

    Private Function InsertEvapChillerProcesses(ByVal c As CloudSaveService.EvapChillerProcesses)
        If c.RevisionDate < minDate Then
            c.RevisionDate = minDate
        End If

        Dim sql = "insert into [EvapChillerProcesses] ( "
        sql &= "[ProcessID], "
        sql &= "[Revision], "
        sql &= "[RevisionDate], "
        sql &= "[ProjectRevision], "
        sql &= "[ProcessRevisionDescription], "
        sql &= "[CreatedBy], "
        sql &= "[Version], "
        sql &= "[Notes], "
        sql &= "[Name], "
        sql &= "[Series], "
        sql &= "[NewCoefficients], "
        sql &= "[Model], "
        sql &= "[ModelDesc], "
        sql &= "[Fluid], "
        sql &= "[GlycolPercentage], "
        sql &= "[CoolingMedia], "
        sql &= "[SpecificHeat], "
        sql &= "[SpecificGravity], "
        sql &= "[SubCooling], "
        sql &= "[Refrigerant], "
        sql &= "[TempRange], "
        sql &= "[AmbientTemp], "
        sql &= "[LeavingFluidTemp], "
        sql &= "[System], "
        sql &= "[Hertz], "
        sql &= "[Volts], "
        sql &= "[Approach], "
        sql &= "[TEMin], "
        sql &= "[TEMax], "
        sql &= "[TEIncrement], "
        sql &= "[ATMin], "
        sql &= "[ATMax], "
        sql &= "[ATIncrement], "
        sql &= "[SafetyOverride], "
        sql &= "[Circuit1], "
        sql &= "[Circuit2], "
        sql &= "[NumCompressors1], "
        sql &= "[NumCompressors2], "
        sql &= "[Compressors1], "
        sql &= "[Compressors2], "
        sql &= "[NumCoils1], "
        sql &= "[NumCoils2], "
        sql &= "[Condenser1], "
        sql &= "[Condenser2], "
        sql &= "[DischargeLineLoss], "
        sql &= "[SuctionLineLoss], "
        sql &= "[Altitude], "
        sql &= "[PumpWatts], "
        sql &= "[FanWatts], "
        sql &= "[CondenserCapacity1], "
        sql &= "[CondenserCapacity2], "
        sql &= "[EvaporatorModel], "
        sql &= "[EvaporatorModelDesc], "
        sql &= "[NumEvap], "
        sql &= "[FoulingFactor], "
        sql &= "[CapacityType], "
        sql &= "[EvaporatorCapacity], "
        sql &= "[CatalogRating], "
        sql &= "[ApproachRange], "
        sql &= "[Evap8Degr1], "
        sql &= "[Evap8Degr2], "
        sql &= "[Evap10Degr1], "
        sql &= "[Evap10Degr2], "
        sql &= "[Division], "
        sql &= "[SubcoolingCoilOption], "
        sql &= "[SoundAttenuationOption], "
        sql &= "[CustomCondenserModel], "
        sql &= "[FanMotorHp], "
        sql &= "[PumpMotorHp] "
        sql &= ") values ("
        sql &= "'" & c.ProcessID & "', "
        sql &= "" & c.Revision & ", "
        sql &= "" & c.RevisionDate & ", "
        sql &= "" & c.ProjectRevision & ", "
        sql &= "'" & c.ProcessRevisionDescription.Replace("'", "") & "', "
        sql &= "'" & c.CreatedBy & "', "
        sql &= "'" & c.Version & "', "
        sql &= "'" & c.Notes.Replace("'", "") & "', "
        sql &= "'" & c.Name.Replace("'", "") & "', "
        sql &= "'" & c.Series & "', "
        sql &= "" & c.NewCoefficients & ", "
        sql &= "'" & c.Model & "', "
        sql &= "'" & c.ModelDesc & "', "
        sql &= "'" & c.Fluid & "', "
        sql &= "" & c.GlycolPercentage & ", "
        sql &= "'" & c.CoolingMedia & "', "
        sql &= "" & c.SpecificHeat & ", "
        sql &= "" & c.SpecificGravity & ", "
        sql &= "" & c.SubCooling & ", "
        sql &= "'" & c.Refrigerant & "', "
        sql &= "" & c.TempRange & ", "
        sql &= "" & c.AmbientTemp & ", "
        sql &= "" & c.LeavingFluidTemp & ", "
        sql &= "'" & c.System & "', "
        sql &= "" & c.Hertz & ", "
        sql &= "" & c.Volts & ", "
        sql &= "'" & c.Approach & "', "
        sql &= "" & c.TEMin & ", "
        sql &= "" & c.TEMax & ", "
        sql &= "" & c.TEIncrement & ", "
        sql &= "" & c.ATMin & ", "
        sql &= "" & c.ATMax & ", "
        sql &= "" & c.ATIncrement & ", "
        sql &= "" & c.SafetyOverride & ", "
        sql &= "" & c.Circuit1 & ", "
        sql &= "" & c.Circuit2 & ", "
        sql &= "" & c.NumCompressors1 & ", "
        sql &= "" & c.NumCompressors2 & ", "
        sql &= "'" & c.Compressors1 & "', "
        sql &= "'" & c.Compressors2 & "', "
        sql &= "" & c.NumCoils1 & ", "
        sql &= "" & c.NumCoils2 & ", "
        sql &= "'" & c.Condenser1 & "', "
        sql &= "'" & c.Condenser2 & "', "
        sql &= "" & c.DischargeLineLoss & ", "
        sql &= "" & c.SuctionLineLoss & ", "
        sql &= "" & c.Altitude & ", "
        sql &= "" & c.PumpWatts & ", "
        sql &= "" & c.FanWatts & ", "
        sql &= "" & c.CondenserCapacity1 & ", "
        sql &= "" & c.CondenserCapacity2 & ", "
        sql &= "'" & c.EvaporatorModel & "', "
        sql &= "'" & c.EvaporatorModelDesc & "', "
        sql &= "" & c.NumEvap & ", "
        sql &= "" & c.FoulingFactor & ", "
        sql &= "'" & c.CapacityType & "', "
        sql &= "" & c.EvaporatorCapacity & ", "
        sql &= "" & c.CatalogRating & ", "
        sql &= "'" & c.ApproachRange & "', "
        sql &= "" & c.Evap8Degr1 & ", "
        sql &= "" & c.Evap8Degr2 & ", "
        sql &= "" & c.Evap10Degr1 & ", "
        sql &= "" & c.Evap10Degr2 & ", "
        sql &= "'" & c.Division & "', "
        sql &= "" & c.SubcoolingCoilOption & ", "
        sql &= "" & c.SoundAttenuationOption & ", "
        sql &= "'" & c.CustomCondenserModel & "', "
        sql &= "" & c.FanMotorHp & ", "
        sql &= "" & c.PumpMotorHp & " "
        sql &= ")"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
        End Try

    End Function




    Private Sub LoadEquipmentOptions(ByVal cloidID As Integer, ByVal uniqueCode As String, ByRef cloudSaveWS As CloudSaveService.CloudSave)
        Dim EquipmentOptions() As CloudSaveService.EquipmentOptions
        EquipmentOptions = cloudSaveWS.LoadEquipmentOptions(cloidID, uniqueCode)

        For Each c As CloudSaveService.EquipmentOptions In EquipmentOptions
            InsertEquipmentOptions(c)
        Next
    End Sub

    Private Function InsertEquipmentOptions(ByVal c As CloudSaveService.EquipmentOptions)
        Dim sql = "insert into [EquipmentOptions] ( "
        sql &= " "
        sql &= "[Revision], "
        sql &= "[PricingId], "
        sql &= "[EquipmentId], "
        sql &= "[Quantity] "
        sql &= ") values ("
        ' sql &= "" & c.Id & ", "
        sql &= "" & c.Revision & ", "
        sql &= "" & c.PricingId & ", "
        sql &= "'" & c.EquipmentId & "', "
        sql &= "" & c.Quantity & " "
        sql &= ")"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
        End Try

    End Function




    Private Sub LoadEquipment(ByVal cloidID As Integer, ByVal uniqueCode As String, ByRef cloudSaveWS As CloudSaveService.CloudSave)
        Dim Equipment() As CloudSaveService.Equipment3
        Equipment = cloudSaveWS.LoadEquipment3(cloidID, uniqueCode)

        For Each c As CloudSaveService.Equipment3 In Equipment
            InsertEquipment(c)
        Next
    End Sub

    Private Function InsertEquipment(ByVal c As CloudSaveService.Equipment3)
        Dim sql = "insert into [Equipment] ( "
        sql &= "[ProjectId], "
        sql &= "[ProjectRevision], "
        sql &= "[EquipmentId], "
        sql &= "[Revision], "
        sql &= "[Name], "
        sql &= "[TypeTableName], "
        sql &= "[Division], "
        sql &= "[Author], "
        sql &= "[Series], "
        sql &= "[Model], "
        sql &= "[Quantity], "
        sql &= "[ParMultiplier], "
        sql &= "[WarrantyPrice], "
        sql &= "[FreightPrice], "
        sql &= "[StartUpPrice], "
        sql &= "[CommissionRate], "
        sql &= "[UnitVoltage], "
        sql &= "[ControlVoltage], "
        sql &= "[Length], "
        sql &= "[Width], "
        sql &= "[Height], "
        sql &= "[Mca], "
        sql &= "[Rla], "
        sql &= "[Altitude], "
        sql &= "[Notes], "
        sql &= "[Tag], "
        sql &= "[ShippingWeight], "
        sql &= "[OperatingWeight], "
        sql &= "[Included], "
        sql &= "[OtherPrice], "
        sql &= "[OtherDescription], "
        sql &= "[CustomModel], "
        sql &= "[OverriddenBaseListPrice], "
        sql &= "[ShouldOverrideBaseListPrice], "
        sql &= "[MultiplierCode], "
        sql &= "[MultiplierType], "
        sql &= "[ListPosition]"
        sql &= ") values ("
        sql &= "'" & c.ProjectId & "', "
        sql &= "" & c.ProjectRevision & ", "
        sql &= "'" & c.EquipmentId & "', "
        sql &= "" & c.Revision & ", "
        sql &= "'" & c.Name.Replace("'", "") & "', "
        sql &= "'" & c.TypeTableName & "', "
        sql &= "'" & c.Division & "', "
        sql &= "'" & c.Author & "', "
        sql &= "'" & c.Series & "', "
        sql &= "'" & c.Model & "', "
        sql &= "" & c.Quantity & ", "
        sql &= "" & c.ParMultiplier & ", "
        sql &= "" & c.WarrantyPrice & ", "
        sql &= "" & c.FreightPrice & ", "
        sql &= "" & c.StartUpPrice & ", "
        sql &= "" & c.CommissionRate & ", "
        sql &= "'" & c.UnitVoltage & "', "
        sql &= "'" & c.ControlVoltage & "', "
        sql &= "" & c.Length & ", "
        sql &= "" & c.Width & ", "
        sql &= "" & c.Height & ", "
        sql &= "" & c.Mca & ", "
        sql &= "" & c.Rla & ", "
        sql &= "" & c.Altitude & ", "
        sql &= "'" & c.Notes.Replace("'", "") & "', "
        sql &= "'" & c.Tag & "', "
        sql &= "" & c.ShippingWeight & ", "
        sql &= "" & c.OperatingWeight & ", "
        sql &= "" & c.Included & ", "
        sql &= "" & c.OtherPrice & ", "
        sql &= "'" & c.OtherDescription.Replace("'", "") & "', "
        sql &= "'" & c.CustomModel.Replace("'", "") & "', "
        sql &= "" & c.OverriddenBaseListPrice & ", "
        sql &= "" & c.ShouldOverrideBaseListPrice & ", "
        sql &= "'" & c.MultiplierCode & "', "
        sql &= "'" & c.MultiplierType & "',"
        sql &= "'" & c.ListPosition & "'"
        sql &= ")"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
        End Try

    End Function




    Private Sub LoadCondensingUnitProcesses(ByVal cloidID As Integer, ByVal uniqueCode As String, ByRef cloudSaveWS As CloudSaveService.CloudSave)
        Dim CondensingUnitProcesses() As CloudSaveService.CondensingUnitProcesses
        CondensingUnitProcesses = cloudSaveWS.LoadCondensingUnitProcesses(cloidID, uniqueCode)

        For Each c As CloudSaveService.CondensingUnitProcesses In CondensingUnitProcesses
            InsertCondensingUnitProcesses(c)
        Next
    End Sub

    Private Function InsertCondensingUnitProcesses(ByVal c As CloudSaveService.CondensingUnitProcesses)
        If c.RevisionDate < minDate Then
            c.RevisionDate = minDate
        End If

        Dim sql = "insert into [CondensingUnitProcesses] ( "
        sql &= "[ProcessID], "
        sql &= "[Revision], "
        sql &= "[RevisionDate], "
        sql &= "[ProjectRevision], "
        sql &= "[ProcessRevisionDescription], "
        sql &= "[CreatedBy], "
        sql &= "[Version], "
        sql &= "[Notes], "
        sql &= "[Name], "
        sql &= "[CondensingUnitSeries], "
        sql &= "[Capacity], "
        sql &= "[RunTimeAdjust], "
        sql &= "[CondensingUnitsRequired], "
        sql &= "[RunTime], "
        sql &= "[AmbientTemperature], "
        sql &= "[SuctionTemperature], "
        sql &= "[Refrigerant], "
        sql &= "[Compressor], "
        sql &= "[CompressorPerUnit], "
        sql &= "[CircuitsPerUnit], "
        sql &= "[Altitude], "
        sql &= "[RunType], "
        sql &= "[NoCondensingUnits], "
        sql &= "[CondensingUnitModel], "
        sql &= "[CustomCondensingUnitModel], "
        sql &= "[RatingAmbient], "
        sql &= "[RatingAmbientInterval], "
        sql &= "[RatingAmbientStep], "
        sql &= "[RatingSuction], "
        sql &= "[RatingSuctionInterval], "
        sql &= "[RatingSuctionStep], "
        sql &= "[RatingRefrigerant], "
        sql &= "[RatingAltitude], "
        sql &= "[RatingSubCooling], "
        sql &= "[RatingCatalog], "
        sql &= "[RatingHertz], "
        sql &= "[RatingSafety], "
        sql &= "[Compressor1], "
        sql &= "[Compressor2], "
        sql &= "[Compressor3], "
        sql &= "[Compressor4], "
        sql &= "[CompressorQuantity1], "
        sql &= "[CompressorQuantity2], "
        sql &= "[CompressorQuantity3], "
        sql &= "[CompressorQuantity4], "
        sql &= "[FinHeight1], "
        sql &= "[FinHeight2], "
        sql &= "[FinHeight3], "
        sql &= "[FinHeight4], "
        sql &= "[CoilFinWidth1], "
        sql &= "[CoilFinWidth2], "
        sql &= "[CoilFinWidth3], "
        sql &= "[CoilFinWidth4], "
        sql &= "[CoilRows1], "
        sql &= "[CoilRows2], "
        sql &= "[CoilRows3], "
        sql &= "[CoilRows4], "
        sql &= "[CoilSubCoolingPercentage1], "
        sql &= "[CoilSubCoolingPercentage2], "
        sql &= "[CoilSubCoolingPercentage3], "
        sql &= "[CoilSubCoolingPercentage4], "
        sql &= "[FinsPerInch1], "
        sql &= "[FinsPerInch2], "
        sql &= "[FinsPerInch3], "
        sql &= "[FinsPerInch4], "
        sql &= "[FanDia1], "
        sql &= "[FanDia2], "
        sql &= "[FanDia3], "
        sql &= "[FanDia4], "
        sql &= "[FanQuantity1], "
        sql &= "[FanQuantity2], "
        sql &= "[FanQuantity3], "
        sql &= "[FanQuantity4], "
        sql &= "[Division], "
        sql &= "[Voltage], "
        sql &= "[Use10Coefficients], "
        sql &= "[TubeDiameter1], "
        sql &= "[TubeDiameter2], "
        sql &= "[TubeDiameter3], "
        sql &= "[TubeDiameter4], "
        sql &= "[TubeSurface1], "
        sql &= "[TubeSurface2], "
        sql &= "[TubeSurface3], "
        sql &= "[TubeSurface4], "
        sql &= "[FinType1], "
        sql &= "[FinType2], "
        sql &= "[FinType3], "
        sql &= "[FinType4], "
        sql &= "[FanRPM1], "
        sql &= "[FanRPM2], "
        sql &= "[FanRPM3], "
        sql &= "[FanRPM4], "
        sql &= "[DOEModel] "

        sql &= ") values ("
        sql &= "'" & c.ProcessID & "', "
        sql &= "" & c.Revision & ", "
        sql &= "" & c.RevisionDate & ", "
        sql &= "" & c.ProjectRevision & ", "
        sql &= "'" & c.ProcessRevisionDescription.Replace("'", "") & "', "
        sql &= "'" & c.CreatedBy & "', "
        sql &= "'" & c.Version & "', "
        sql &= "'" & c.Notes.Replace("'", "") & "', "
        sql &= "'" & c.Name.Replace("'", "") & "', "
        sql &= "'" & c.CondensingUnitSeries & "', "
        sql &= "" & c.Capacity & ", "
        sql &= "" & c.RunTimeAdjust & ", "
        sql &= "" & c.CondensingUnitsRequired & ", "
        sql &= "" & c.RunTime & ", "
        sql &= "" & c.AmbientTemperature & ", "
        sql &= "" & c.SuctionTemperature & ", "
        sql &= "'" & c.Refrigerant & "', "
        sql &= "'" & c.Compressor & "', "
        sql &= "" & c.CompressorPerUnit & ", "
        sql &= "" & c.CircuitsPerUnit & ", "
        sql &= "" & c.Altitude & ", "
        sql &= "'" & c.RunType & "', "
        sql &= "" & c.NoCondensingUnits & ", "
        sql &= "'" & c.CondensingUnitModel & "', "
        sql &= "'" & c.CustomCondensingUnitModel & "', "
        sql &= "" & c.RatingAmbient & ", "
        sql &= "" & c.RatingAmbientInterval & ", "
        sql &= "" & c.RatingAmbientStep & ", "
        sql &= "" & c.RatingSuction & ", "
        sql &= "" & c.RatingSuctionInterval & ", "
        sql &= "" & c.RatingSuctionStep & ", "
        sql &= "'" & c.RatingRefrigerant & "', "
        sql &= "" & c.RatingAltitude & ", "
        sql &= "" & c.RatingSubCooling & ", "
        sql &= "" & c.RatingCatalog & ", "
        sql &= "" & c.RatingHertz & ", "
        sql &= "" & c.RatingSafety & ", "
        sql &= "'" & c.Compressor1 & "', "
        sql &= "'" & c.Compressor2 & "', "
        sql &= "'" & c.Compressor3 & "', "
        sql &= "'" & c.Compressor4 & "', "
        sql &= "" & c.CompressorQuantity1 & ", "
        sql &= "" & c.CompressorQuantity2 & ", "
        sql &= "" & c.CompressorQuantity3 & ", "
        sql &= "" & c.CompressorQuantity4 & ", "
        sql &= "" & c.FinHeight1 & ", "
        sql &= "" & c.FinHeight2 & ", "
        sql &= "" & c.FinHeight3 & ", "
        sql &= "" & c.FinHeight4 & ", "
        sql &= "" & c.CoilFinWidth1 & ", "
        sql &= "" & c.CoilFinWidth2 & ", "
        sql &= "" & c.CoilFinWidth3 & ", "
        sql &= "" & c.CoilFinWidth4 & ", "
        sql &= "" & c.CoilRows1 & ", "
        sql &= "" & c.CoilRows2 & ", "
        sql &= "" & c.CoilRows3 & ", "
        sql &= "" & c.CoilRows4 & ", "
        sql &= "" & c.CoilSubCoolingPercentage1 & ", "
        sql &= "" & c.CoilSubCoolingPercentage2 & ", "
        sql &= "" & c.CoilSubCoolingPercentage3 & ", "
        sql &= "" & c.CoilSubCoolingPercentage4 & ", "
        sql &= "" & c.FinsPerInch1 & ", "
        sql &= "" & c.FinsPerInch2 & ", "
        sql &= "" & c.FinsPerInch3 & ", "
        sql &= "" & c.FinsPerInch4 & ", "
        sql &= "'" & c.FanDia1 & "', "
        sql &= "'" & c.FanDia2 & "', "
        sql &= "'" & c.FanDia3 & "', "
        sql &= "'" & c.FanDia4 & "', "
        sql &= "" & c.FanQuantity1 & ", "
        sql &= "" & c.FanQuantity2 & ", "
        sql &= "" & c.FanQuantity3 & ", "
        sql &= "" & c.FanQuantity4 & ", "
        sql &= "'" & c.Division & "', "
        sql &= "" & c.Voltage & ", "
        sql &= "" & c.Use10Coefficients & ", "
        sql &= "" & c.TubeDiameter1 & ", "
        sql &= "" & c.TubeDiameter2 & ", "
        sql &= "" & c.TubeDiameter3 & ", "
        sql &= "" & c.TubeDiameter4 & ", "
        sql &= "'" & c.TubeSurface1 & "', "
        sql &= "'" & c.TubeSurface2 & "', "
        sql &= "'" & c.TubeSurface3 & "', "
        sql &= "'" & c.TubeSurface4 & "', "
        sql &= "'" & c.FinType1 & "', "
        sql &= "'" & c.FinType2 & "', "
        sql &= "'" & c.FinType3 & "', "
        sql &= "'" & c.FinType4 & "', "
        sql &= "" & c.FanRPM1 & ", "
        sql &= "" & c.FanRPM2 & ", "
        sql &= "" & c.FanRPM3 & ", "
        sql &= "" & c.FanRPM4 & ", "
        sql &= "'" & c.DOEModel & "' "
        sql &= ")"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
        End Try

    End Function





    Private Sub LoadCondensingUnit(ByVal cloidID As Integer, ByVal uniqueCode As String, ByRef cloudSaveWS As CloudSaveService.CloudSave)
        Dim CondensingUnit() As CloudSaveService.CondensingUnit
        CondensingUnit = cloudSaveWS.LoadCondensingUnits(cloidID, uniqueCode)

        For Each c As CloudSaveService.CondensingUnit In CondensingUnit
            InsertCondensingUnit(c)
        Next
    End Sub

    Private Function InsertCondensingUnit(ByVal c As CloudSaveService.CondensingUnit)
        Dim sql = "insert into [CondensingUnit] ( "
        sql &= "[EquipmentId], "
        sql &= "[Revision], "
        sql &= "[AmbientTemp], "
        sql &= "[SuctionTemp], "
        sql &= "[Refrigerant], "
        sql &= "[Circuit1Capacity], "
        sql &= "[Circuit2Capacity], "
        sql &= "[Circuit3Capacity], "
        sql &= "[Circuit4Capacity], "
        sql &= "[EvapTemp], "
        sql &= "[Efficiency] "
        sql &= ") values ("
        sql &= "'" & c.EquipmentId & "', "
        sql &= "" & c.Revision & ", "
        sql &= "" & c.AmbientTemp & ", "
        sql &= "" & c.SuctionTemp & ", "
        sql &= "'" & c.Refrigerant & "', "
        sql &= "" & c.Circuit1Capacity & ", "
        sql &= "" & c.Circuit2Capacity & ", "
        sql &= "" & c.Circuit3Capacity & ", "
        sql &= "" & c.Circuit4Capacity & ", "
        sql &= "" & c.EvapTemp & ", "
        sql &= "" & c.Efficiency & " "
        sql &= ")"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
        End Try

    End Function



    Private Sub LoadCondenserProcesses(ByVal cloidID As Integer, ByVal uniqueCode As String, ByRef cloudSaveWS As CloudSaveService.CloudSave)
        Dim CondenserProcesses() As CloudSaveService.CondenserProcesses
        CondenserProcesses = cloudSaveWS.LoadCondenserProcesses(cloidID, uniqueCode)

        For Each c As CloudSaveService.CondenserProcesses In CondenserProcesses
            InsertCondenserProcesses(c)
        Next
    End Sub

    Private Function InsertCondenserProcesses(ByVal c As CloudSaveService.CondenserProcesses)
        If c.RevisionDate < minDate Then
            c.RevisionDate = minDate
        End If

        Dim sql = "insert into [CondenserProcesses] ( "
        sql &= "[ProcessID], "
        sql &= "[Revision], "
        sql &= "[RevisionDate], "
        sql &= "[ProjectRevision], "
        sql &= "[ProcessRevisionDescription], "
        sql &= "[CreatedBy], "
        sql &= "[Version], "
        sql &= "[Notes], "
        sql &= "[Altitude], "
        sql &= "[AmbientTemp], "
        sql &= "[CatalogRating], "
        sql &= "[CFM], "
        sql &= "[CoilDesc], "
        sql &= "[CoilLength], "
        sql &= "[CoilWidth], "
        sql &= "[ExtStaticPressure], "
        sql &= "[Fan], "
        sql &= "[Model], "
        sql &= "[Name], "
        sql &= "[NumFans], "
        sql &= "[Refrigerant], "
        sql &= "[Series], "
        sql &= "[SubCooling], "
        sql &= "[SubCoolingPercentage], "
        sql &= "[TD], "
        sql &= "[Division] "
        sql &= ") values ("
        sql &= "'" & c.ProcessID & "', "
        sql &= "" & c.Revision & ", "
        sql &= "" & c.RevisionDate & ", "
        sql &= "" & c.ProjectRevision & ", "
        sql &= "'" & c.ProcessRevisionDescription.Replace("'", "") & "', "
        sql &= "'" & c.CreatedBy & "', "
        sql &= "'" & c.Version & "', "
        sql &= "'" & c.Notes.Replace("'", "") & "', "
        sql &= "" & c.Altitude & ", "
        sql &= "" & c.AmbientTemp & ", "
        sql &= "" & c.CatalogRating & ", "
        sql &= "" & c.CFM & ", "
        sql &= "'" & c.CoilDesc & "', "
        sql &= "" & c.CoilLength & ", "
        sql &= "" & c.CoilWidth & ", "
        sql &= "" & c.ExtStaticPressure & ", "
        sql &= "'" & c.Fan & "', "
        sql &= "'" & c.Model & "', "
        sql &= "'" & c.Name.Replace("'", "") & "', "
        sql &= "" & c.NumFans & ", "
        sql &= "'" & c.Refrigerant & "', "
        sql &= "'" & c.Series & "', "
        sql &= "" & c.SubCooling & ", "
        sql &= "" & c.SubCoolingPercentage & ", "
        sql &= "" & c.TD & ", "
        sql &= "'" & c.Division & "' "
        sql &= ")"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
        End Try

    End Function



    Private Sub LoadCondenser(ByVal cloidID As Integer, ByVal uniqueCode As String, ByRef cloudSaveWS As CloudSaveService.CloudSave)
        Dim Condenser() As CloudSaveService.Condenser
        Condenser = cloudSaveWS.LoadCondensers(cloidID, uniqueCode)

        For Each c As CloudSaveService.Condenser In Condenser
            InsertCondenser(c)
        Next
    End Sub

    Private Function InsertCondenser(ByVal c As CloudSaveService.Condenser)
        Dim sql = "insert into [Condenser] ( "
        sql &= "[EquipmentId], "
        sql &= "[Revision], "
        sql &= "[AmbientTemp], "
        sql &= "[Refrigerant], "
        sql &= "[ThrCircuit1], "
        sql &= "[ThrCircuit2], "
        sql &= "[ThrCircuit3], "
        sql &= "[ThrCircuit4], "
        sql &= "[TempDifference], "
        sql &= "[Fpi], "
        sql &= "[SubCooling] "
        sql &= ") values ("
        sql &= "'" & c.EquipmentId & "', "
        sql &= "" & c.Revision & ", "
        sql &= "" & c.AmbientTemp & ", "
        sql &= "'" & c.Refrigerant & "', "
        sql &= "" & c.ThrCircuit1 & ", "
        sql &= "" & c.ThrCircuit2 & ", "
        sql &= "" & c.ThrCircuit3 & ", "
        sql &= "" & c.ThrCircuit4 & ", "
        sql &= "" & c.TempDifference & ", "
        sql &= "" & c.Fpi & ", "
        sql &= "" & c.SubCooling & " "
        sql &= ")"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
        End Try

    End Function






    Private Sub LoadACChillerProcesses(ByVal cloidID As Integer, ByVal uniqueCode As String, ByRef cloudSaveWS As CloudSaveService.CloudSave)
        Dim ACChillerProcesses() As CloudSaveService.ACChillerProcesses
        ACChillerProcesses = cloudSaveWS.LoadACChillerProcesses(cloidID, uniqueCode)

        For Each c As CloudSaveService.ACChillerProcesses In ACChillerProcesses
            InsertACChillerProcesses(c)
        Next
    End Sub

    Private Function InsertACChillerProcesses(ByVal c As CloudSaveService.ACChillerProcesses)
        If c.RevisionDate < minDate Then
            c.RevisionDate = minDate
        End If

        Dim sql = "insert into [ACChillerProcesses] ( "
        sql &= "[ProcessID], "
        sql &= "[Revision], "
        sql &= "[RevisionDate], "
        sql &= "[ProjectRevision], "
        sql &= "[ProcessRevisionDescription], "
        sql &= "[CreatedBy], "
        sql &= "[Version], "
        sql &= "[Notes], "
        sql &= "[Name], "
        sql &= "[Series], "
        sql &= "[NewCoefficients], "
        sql &= "[Model], "
        sql &= "[ModelDesc], "
        sql &= "[Fluid], "
        sql &= "[GlycolPercentage], "
        sql &= "[CoolingMedia], "
        sql &= "[SpecificHeat], "
        sql &= "[SpecificGravity], "
        sql &= "[SubCooling], "
        sql &= "[Refrigerant], "
        sql &= "[TempRange], "
        sql &= "[AmbientTemp], "
        sql &= "[LeavingFluidTemp], "
        sql &= "[System], "
        sql &= "[Hertz], "
        sql &= "[Volts], "
        sql &= "[Approach], "
        sql &= "[SafetyOverride], "
        sql &= "[Circuit1], "
        sql &= "[Circuit2], "
        sql &= "[NumCompressors1], "
        sql &= "[NumCompressors2], "
        sql &= "[Compressors1], "
        sql &= "[Compressors2], "
        sql &= "[NumCoils1], "
        sql &= "[NumCoils2], "
        sql &= "[Condenser1], "
        sql &= "[Condenser2], "
        sql &= "[FinsPerInch1], "
        sql &= "[FinsPerInch2], "
        sql &= "[SubCooling1], "
        sql &= "[SubCooling2], "
        sql &= "[SubCoolingPercent1], "
        sql &= "[SubCoolingPercent2], "
        sql &= "[CondenserTD1], "
        sql &= "[CondenserTD2], "
        sql &= "[FinHeight1], "
        sql &= "[FinHeight2], "
        sql &= "[FinLength1], "
        sql &= "[FinLength2], "
        sql &= "[DischargeLineLoss], "
        sql &= "[SuctionLineLoss], "
        sql &= "[Altitude], "
        sql &= "[Fan], "
        sql &= "[CfmOverride], "
        sql &= "[NumFans1], "
        sql &= "[NumFans2], "
        sql &= "[CondenserCapacity1], "
        sql &= "[CondenserCapacity2], "
        sql &= "[EvaporatorModel], "
        sql &= "[EvaporatorModelDesc], "
        sql &= "[NumEvap], "
        sql &= "[FoulingFactor], "
        sql &= "[CapacityType], "
        sql &= "[EvaporatorCapacity], "
        sql &= "[CatalogRating], "
        sql &= "[ApproachRange], "
        sql &= "[Evap8Degr1], "
        sql &= "[Evap8Degr2], "
        sql &= "[Evap10Degr1], "
        sql &= "[Evap10Degr2], "
        sql &= "[Division], "
        sql &= "[FanWatts] "
        sql &= ") values ("
        sql &= "'" & c.ProcessID & "', "
        sql &= "" & c.Revision & ", "
        sql &= "" & c.RevisionDate & ", "
        sql &= "" & c.ProjectRevision & ", "
        sql &= "'" & c.ProcessRevisionDescription.Replace("'", "") & "', "
        sql &= "'" & c.CreatedBy & "', "
        sql &= "'" & c.Version & "', "
        sql &= "'" & c.Notes.Replace("'", "") & "', "
        sql &= "'" & c.Name.Replace("'", "") & "', "
        sql &= "'" & c.Series & "', "
        sql &= "" & c.NewCoefficients & ", "
        sql &= "'" & c.Model & "', "
        sql &= "'" & c.ModelDesc & "', "
        sql &= "'" & c.Fluid & "', "
        sql &= "" & c.GlycolPercentage & ", "
        sql &= "'" & c.CoolingMedia & "', "
        sql &= "" & c.SpecificHeat & ", "
        sql &= "" & c.SpecificGravity & ", "
        sql &= "" & c.SubCooling & ", "
        sql &= "'" & c.Refrigerant & "', "
        sql &= "" & c.TempRange & ", "
        sql &= "" & c.AmbientTemp & ", "
        sql &= "" & c.LeavingFluidTemp & ", "
        sql &= "'" & c.System & "', "
        sql &= "" & c.Hertz & ", "
        sql &= "" & c.Volts & ", "
        sql &= "'" & c.Approach & "', "
        sql &= "" & c.SafetyOverride & ", "
        sql &= "" & c.Circuit1 & ", "
        sql &= "" & c.Circuit2 & ", "
        sql &= "" & c.NumCompressors1 & ", "
        sql &= "" & c.NumCompressors2 & ", "
        sql &= "'" & c.Compressors1 & "', "
        sql &= "'" & c.Compressors2 & "', "
        sql &= "" & c.NumCoils1 & ", "
        sql &= "" & c.NumCoils2 & ", "
        sql &= "'" & c.Condenser1 & "', "
        sql &= "'" & c.Condenser2 & "', "
        sql &= "" & c.FinsPerInch1 & ", "
        sql &= "" & c.FinsPerInch2 & ", "
        sql &= "" & c.SubCooling1 & ", "
        sql &= "" & c.SubCooling2 & ", "
        sql &= "" & c.SubCoolingPercent1 & ", "
        sql &= "" & c.SubCoolingPercent2 & ", "
        sql &= "" & c.CondenserTD1 & ", "
        sql &= "" & c.CondenserTD2 & ", "
        sql &= "" & c.FinHeight1 & ", "
        sql &= "" & c.FinHeight2 & ", "
        sql &= "" & c.FinLength1 & ", "
        sql &= "" & c.FinLength2 & ", "
        sql &= "" & c.DischargeLineLoss & ", "
        sql &= "" & c.SuctionLineLoss & ", "
        sql &= "" & c.Altitude & ", "
        sql &= "'" & c.Fan & "', "
        sql &= "" & c.CfmOverride & ", "
        sql &= "" & c.NumFans1 & ", "
        sql &= "" & c.NumFans2 & ", "
        sql &= "" & c.CondenserCapacity1 & ", "
        sql &= "" & c.CondenserCapacity2 & ", "
        sql &= "'" & c.EvaporatorModel & "', "
        sql &= "'" & c.EvaporatorModelDesc & "', "
        sql &= "" & c.NumEvap & ", "
        sql &= "" & c.FoulingFactor & ", "
        sql &= "'" & c.CapacityType & "', "
        sql &= "" & c.EvaporatorCapacity & ", "
        sql &= "" & c.CatalogRating & ", "
        sql &= "'" & c.ApproachRange & "', "
        sql &= "" & c.Evap8Degr1 & ", "
        sql &= "" & c.Evap8Degr2 & ", "
        sql &= "" & c.Evap10Degr1 & ", "
        sql &= "" & c.Evap10Degr2 & ", "
        sql &= "'" & c.Division & "', "
        sql &= "" & c.FanWatts & " "
        sql &= ")"

        Dim connection = Common.CreateConnection(Common.ProjectsDbPath)
        Dim command = connection.CreateCommand
        command.CommandText = sql

        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
        End Try

    End Function




    '--------------------------------------




    Private Function GetUniqueCode() As String

        GetUniqueCode = Now.Year.ToString.Substring(2, 2) & DAbrev(Now.Month) & DAbrev(Now.Day) & DAbrev(Now.Hour) & Now.Minute.ToString.PadLeft(2, "Q") & Now.Second.ToString.PadLeft(2, "K")


    End Function

    Private Function DAbrev(ByVal i As Integer) As String
        Select Case i
            Case 0 : Return "1"
            Case 1 : Return "2"
            Case 2 : Return "3"
            Case 3 : Return "4"
            Case 4 : Return "5"
            Case 5 : Return "6"
            Case 6 : Return "7"
            Case 7 : Return "8"
            Case 8 : Return "9"
            Case 9 : Return "A"
            Case 10 : Return "B"
            Case 11 : Return "C"
            Case 12 : Return "D"
            Case 13 : Return "E"
            Case 14 : Return "F"
            Case 15 : Return "G"
            Case 16 : Return "H"
            Case 17 : Return "I"
            Case 18 : Return "J"
            Case 19 : Return "K"
            Case 20 : Return "L"
            Case 21 : Return "M"
            Case 22 : Return "N"
            Case 23 : Return "O"
            Case 24 : Return "P"
            Case 25 : Return "Q"
            Case 26 : Return "R"
            Case 27 : Return "S"
            Case 28 : Return "T"
            Case 29 : Return "U"
            Case 30 : Return "V"
            Case 31 : Return "W"

        End Select
    End Function





    Private Sub LoadCloudProject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpStartDate.Value = DateAdd(DateInterval.Year, -1, Now)
        dtpEndDate.Value = Now

        LoadCloudProjectList(StartDate:=dtpStartDate.Value, EndDate:=dtpEndDate.Value)
        LoadUserFilterList()

        formLoaded = True

    End Sub

    Private Sub LoadCloudProjectList(Optional ByVal UserNameFilter As String = "", Optional ByVal StartDate As String = "", Optional ByVal EndDate As String = "")
        Try
            Dim CloudSaveWS As New CloudSaveService.CloudSave

            Dim currentUser As String = AppInfo.User.username
            Dim isRAE As Boolean = AppInfo.User.is_employee

            '        Dim usernameList As New List(Of String)

            Dim l() As CloudSaveService.ProjectList = CloudSaveWS.GetCloudProjectsUserCanAccess(currentUser, isRAE, UserNameFilter, StartDate, EndDate)


            DataGridView1.Rows.Clear()

            For Each l1 As CloudSaveService.ProjectList In l
                Dim i As Integer = DataGridView1.Rows.Add()
                DataGridView1.Rows(i).Cells("CloudID").Value = l1.CloudID
                DataGridView1.Rows(i).Cells("UserName").Value = l1.UserName
                DataGridView1.Rows(i).Cells("CompanyCode").Value = l1.CompanyCode
                DataGridView1.Rows(i).Cells("ProjectName").Value = l1.ProjectName
                DataGridView1.Rows(i).Cells("CreatedDT").Value = l1.CreatedDT
                DataGridView1.Rows(i).Cells("Import").Value = "Import"

                '  If Not usernameList.Contains(l1.UserName) Then usernameList.Add(l1.UserName)

            Next

            If Not isRAE Then DataGridView1.Columns(2).Visible = False




        Catch
            MsgBox("Error connecting to cloud server.")
        End Try

    End Sub


    Private Sub LoadUserFilterList()
        Dim CloudSaveWS As New CloudSaveService.CloudSave

        Dim currentUser As String = AppInfo.User.username
        Dim isRAE As Boolean = AppInfo.User.is_employee

        Dim usernameList As New List(Of String)

        Dim l() As CloudSaveService.ProjectList = CloudSaveWS.GetCloudProjectsUserCanAccess(currentUser, isRAE, "", "", "")


        For Each l1 As CloudSaveService.ProjectList In l

            If Not usernameList.Contains(l1.UserName) Then usernameList.Add(l1.UserName)
        Next



        cboUsername.Items.Clear()
        cboUsername.Items.Add("")
        usernameList.Sort()
        For Each u As String In usernameList
            cboUsername.Items.Add(u)
        Next


    End Sub


    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = 5 AndAlso e.RowIndex > -1 Then

            Dim cloudID As Integer = DataGridView1.Rows(e.RowIndex).Cells(0).Value

            DoImport(cloudID)

        End If
    End Sub





    Private Sub filter_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpStartDate.ValueChanged, dtpEndDate.ValueChanged, cboUsername.TextChanged
        If Not formLoaded Then Exit Sub

        If cboUsername.Text <> "" Then
            LoadCloudProjectList(cboUsername.Text, dtpStartDate.Value, dtpEndDate.Value)
        Else
            LoadCloudProjectList(StartDate:=dtpStartDate.Value, EndDate:=dtpEndDate.Value)
        End If


    End Sub


End Class