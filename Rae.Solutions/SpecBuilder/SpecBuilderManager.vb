Imports Microsoft.VisualBasic

Namespace SpecBuilder

   Public Class SpecBuilderManager

      Friend Shared Function GetDefaultSpecBuilderWizard() As Wizard.Wizard
         Dim wiz As Wizard.Wizard
         Dim specData As SpecBuilder.SpecBuilderData

         'initializes wizard
         wiz = New Wizard.Wizard
         'gets spec with default values
         specData = SpecBuilderManager.GetDefaultSpec

         AddForms(wiz, specData)

         Return wiz
      End Function


      Friend Shared Function GetExistingSpecBuilderWizard( _
      ByVal specData As SpecBuilderData) As Wizard.Wizard
         Dim wiz As Wizard.Wizard

         'initializes wizard
         wiz = New Wizard.Wizard

         AddForms(wiz, specData)

         Return wiz
      End Function


      Friend Shared Function GetDefaultSpec() As SpecBuilder.SpecBuilderData
         Dim specData As SpecBuilder.SpecBuilderData

         specData = New SpecBuilder.SpecBuilderData

         With specData
            .Name = "Untitled"
            'unit
            .Unit = "Condensing unit"
            .CoolingSolution = "Water"
            .SolutionPercentage = 0
            'piping and housing
            .HousingAndPiping.BaseFrame = "G-90 galvanized sheet metal 12 Ga. minimum"
            .HousingAndPiping.Housing = "heavy gauge G-90 galvanized steel"
            .HousingAndPiping.EpoxyCoated = False
            .HousingAndPiping.Piping = _
               "Type L hard copper [through 4" & Chr(34) & " pipe size]"
            'compressor
            .Compressor.Compressor = "reciprocating (semi-hermetic)"
            .Compressor.Refrigerant = "R-22"
            .Compressor.CylinderLoading = False
            .Compressor.CylinderLoadingOption = _
               "an electronic signal based on return water temperature"
            .Compressor.CapacitySlideValveModulation = "Infinite control"
            'evaporator
            .Evaporator.Evaporator = "Shell and tube"
            .Evaporator.Pressure = "250 psig [up to 30 ton loads]"

            'condenser
            With .Condenser
               .Condenser = "Air-cooled"
               'air-cooled
               .CondenserDesign = "Packaged system"
               .FinMaterial = "aluminum"
               .CasingsAndTubeSheets = "galvanized steel"
               .TubeThickness = "0.017" & Chr(34)
               .FinMaterial = "0.006" & Chr(34)
               .CondenserType = "Prop fans"
               .Discharge = "horizontal"
               .RainHood = False
               .SubCoolingCircuit = False
               .Motor = "Open drip proof"
               .LowAmbient = "fan cycling"
               .Ambient = "20 F"
               .FloodedCondenserControl = False
               .HeatedAndInsulatedReceivers = False
               'water-cooled
               .WaterValves = False
               .HeatExchanger = "shell and tube"
               'evaporative-cooled
               .Material = "G-235 galvanize sump"
               .HeadPressure = "2 speed fan motors"
               .Coil = "Steel tube"
               .AcousticAttenuatorsIntake = False
               .AcousticAttenuatorsDischarge = False
            End With

            'refrigerant circuit
            With .Refrigerant
               .Solenoid = False
               .FilterDrier = False
               .FilterDrierType = "sealed type"
               .ExpansionValve = "thermostatic"
               .PressureReliefHigh = False
               .PressureReliefLow = False
               .SuctionAccumulators = "no suction accumulator"
               .HotGasDischargeMuffler = False
               .OilSeperator = False
               .SuctionFilter = False
               .SuctionFilterType = "sealed type"
               .Vibratorbers = "Discharge only"
               .HotGasBypass = False
               .HotGasBypassDesign = "standard design"
               .HotGasBypassTons = "4.1 Tons"
               .LiquidReceiver = "5 in. x 14 in."
               .LiquidReceiverHandValves = False
            End With

            With .Controls
               .ControlsType = "Electronic"
               .PowerConnection = "Single Point"
               .DisconnectOption = False
               .DisconnectOptionType = "Non-fused"
               .CompressorStatusLight = False
               .FailureStatusLight = False
               .PumpStatusLight = False
               .MoldedCaseDisconnectSwitch = False
               .CompressorLeadLagSwitch = "Manual"
               .UnitPhaseMonitor = False
               .UnitPhaseMonitorScope = "For Entire Unit"
               .RefrigerantAndOilGauges = False
               .Lcd = False
               .LcdDemandLimitingSetPoint = False
               .LcdChilledWaterSetPoint = False
               .LcdCompressorAmps = False
               .LcdCompressorStatus = False
               .LcdFailureAndAlarmHistory = False
               .LcdRefrigerantDischargePressureAndTemperature = False
               .LcdRefrigerantSuctionPressureAndTemperature = False
               .LcdWaterTemperatures = False
            End With

            With .Pump
               .PumpPackage = False
               .DesignCriteria = "Single"
               .DesignCriteriaDualOption = "Primary/Standby Design (100% Redundancy)"
               .PackageDesign = "Integral with Chiller"
               .Speed = "1750 RPM"
               .PumpType = "End-Suction Centrifugal"
               .AirSeperator = False
               .AirSeperatorDesign = "In-Line"
               .ExpansionTank = False
               .ExpansionTankType = "Diaphragm Type"
               .SuctionStrainer = "Basket Type"
               .SuctionTrim = "Ball Balve, through 2 1/2" & Chr(34) & " Pipe Size"
               .StorageTank = False
               .StorageTankType = "Open, Vented Tank"
               .StorageTankVolume = 0
               .StorageTankRatingAsm = "Non-ASM"
               .StorageTankRatingPsi = "75 psi"
            End With

            With .Hazard
               .Hazard = False
               .StructuralBase = "304 Stainless"
               .CondenserCasings = "304 Stainless"
               .CondenserFins = "Aluminum"
               .ControlEnclosure = "NEMA 7"
               .HazardousDutyClassification = False
            End With

            With .Acoustic
               .Acoustic = False
               .Compressors = False
               .CompressorCovering = "None"
               .CompressorSpringIsolator = False
               .CondenserFans = False
               .CondenserFanType = "850 RPM"
               .CondenserShroud = False
            End With

            With .Other
               .WatersideEconomizer = False
               .AdditionalWarranty = False
               .SupervisedStartup = False
            End With
            'MAINTAIN: Add new default spec values here

         End With

         Return specData
      End Function


      'System.IO.FileNotFoundException
      Friend Shared Function GetExistingSpec(ByVal filePath As String) As SpecBuilderData
         Dim specData As SpecBuilderData
         Dim specXmlSerializer As Xml.Serialization.XmlSerializer
         Dim stream As System.IO.FileStream

         specData = New SpecBuilderData
         specXmlSerializer = New Xml.Serialization.XmlSerializer(GetType(SpecBuilderData))

         ' sets file path to read from
         ' TODO: check to see if file is in use
         stream = New System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None)
         ' reads saved SpecBuilder data from file
         specData = DirectCast(specXmlSerializer.Deserialize(stream), SpecBuilderData)
         ' closes stream
         stream.Close()

         Return specData
      End Function


      Friend Shared Sub SaveSpec(ByVal specData As SpecBuilderData, ByVal filePath As String)
         Dim specXmlSerializer As Xml.Serialization.XmlSerializer
         Dim specStream As System.IO.FileStream

         specXmlSerializer = New Xml.Serialization.XmlSerializer(GetType(SpecBuilderData))
         specStream = New System.IO.FileStream(filePath, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None)

         'writes SpecBuilder data to file
         specXmlSerializer.Serialize(specStream, specData)
         'closes stream
         specStream.Close()
      End Sub


      Friend Shared Function IsValidSpecBuilderFile(ByVal filePath As String)
         'TODO: checks exists

         'TODO: checks extension

         'TODO: checks version

         'TODO: checks format

         Return True
      End Function


      Friend Shared Sub EnableControls(ByRef description As Label, _
      ByRef inputControl As Control, ByRef tip As ToolTip)
         'enables myControl
         inputControl.Enabled = True
         'sets myControl's tip
         tip.SetToolTip(inputControl, String.Empty)
         'sets label's font
         description.Font = New Font("Tahoma", 8, FontStyle.Regular)
         'sets label's tip
         tip.SetToolTip(description, String.Empty)
      End Sub


      Friend Shared Sub DisableControls(ByRef description As Label, _
      ByRef inputControl As Control, ByRef tip As ToolTip, ByVal message As String)
         'enables myControl
         inputControl.Enabled = False
         'sets myControl's tip
         tip.SetToolTip(inputControl, message)
         'sets label's font
         description.Font = New Font("Tahoma", 8, FontStyle.Strikeout)
         'sets label's tip
         tip.SetToolTip(description, message)
      End Sub


#Region " Private Methods"

      Private Shared Function AddForms(ByRef wizard As Wizard.Wizard, _
      ByRef specData As SpecBuilderData) As Wizard.Forms
         Dim unit As SpecBuilder.UnitSpecBuilderWizard
         Dim housing As SpecBuilder.HousingAndPipingSpecBuilderWizard
         Dim compressor As SpecBuilder.CompressorSpecBuilderWizard
         Dim evaporator As SpecBuilder.EvaporatorSpecBuilderWizard
         Dim condenser As SpecBuilder.CondenserSpecBuilderWizard
         Dim refrigerant As SpecBuilder.RefrigerantSpecBuilderWizard
         Dim controls As SpecBuilder.ControlsSpecBuilderWizard
         Dim pump As SpecBuilder.PumpSpecBuilderWizard
         Dim hazard As SpecBuilder.HazardSpecBuilderWizard
         Dim acoustic As SpecBuilder.AcousticSpecBuilderWizard
         Dim other As SpecBuilder.OtherSpecBuilderWizard

         'initializes forms to be added to wizard
         unit = New SpecBuilder.UnitSpecBuilderWizard(wizard, specData)
         housing = New HousingAndPipingSpecBuilderWizard(wizard, specData)
         compressor = New CompressorSpecBuilderWizard(wizard, specData)
         evaporator = New EvaporatorSpecBuilderWizard(wizard, specData)
         condenser = New CondenserSpecBuilderWizard(wizard, specData)
         refrigerant = New RefrigerantSpecBuilderWizard(wizard, specData)
         controls = New ControlsSpecBuilderWizard(wizard, specData)
         pump = New PumpSpecBuilderWizard(wizard, specData)
         hazard = New HazardSpecBuilderWizard(wizard, specData)
         acoustic = New AcousticSpecBuilderWizard(wizard, specData)
         other = New OtherSpecBuilderWizard(wizard, specData)

         'MAINTAIN: Add new SpecBuilder wizard forms here
         With wizard.Forms
            .Add(unit)
            .Add(housing)
            .Add(compressor)
            .Add(evaporator)
            .Add(condenser)
            .Add(refrigerant)
            .Add(controls)
            .Add(pump)
            .Add(hazard)
            .Add(acoustic)
            .Add(other)
            '...
         End With

         Return wizard.Forms
      End Function

#End Region


   End Class

End Namespace