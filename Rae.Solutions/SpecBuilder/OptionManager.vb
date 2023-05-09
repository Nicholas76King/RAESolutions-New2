Namespace SpecBuilder

   Public Class OptionManager

      Private _specData As SpecBuilderData


      Public Property SpecData() As SpecBuilderData
         Get
            Return Me._specData
         End Get
         Set(ByVal Value As SpecBuilderData)
            Me._specData = Value
         End Set
      End Property


      Public Sub New()

      End Sub


      Public Sub New(ByRef specData As SpecBuilderData)
         Me._specData = specData
      End Sub


      Public Function NotOption(ByVal messageEnd As String) As String
         Dim message As String

         message = "Not an option with " & messageEnd

         Return message
      End Function


      Public Function OnlyOption(ByVal messageEnd As String) As String
         Dim message As String

         message = "Only an option with " & messageEnd

         Return message
      End Function


#Region " Unit"

      'cooling solution
      Public Function GetCoolingSolution() As SpecBuilderOption
         Dim coolingSolution As New SpecBuilderOption

         coolingSolution.IsOption = (Me.SpecData.Unit = "Water chiller")
         coolingSolution.Explanation = Me.NotOption("condensing unit")

         Return coolingSolution
      End Function


      'cooling solution percentage
      Public Function GetCoolingSolutionPercentage() As SpecBuilderOption
         Dim coolingSolutionPercentage As New SpecBuilderOption
         'sets IsOption
         coolingSolutionPercentage.IsOption = _
            (Me.SpecData.Unit = "Water chiller" And _
            Me.SpecData.CoolingSolution <> "Water")

         'sets explanation
         If Me.SpecData.Unit <> "Water chiller" Then
            coolingSolutionPercentage.Explanation = Me.NotOption( _
               "condensing unit")
         ElseIf Me.SpecData.CoolingSolution = "Water" Then
            coolingSolutionPercentage.Explanation = Me.NotOption( _
               "water")
         End If

         Return coolingSolutionPercentage
      End Function

#End Region


#Region " Housing and Piping"

      Public Function GetPiping() As SpecBuilderOption
         Dim piping As New SpecBuilderOption

         'interconnecting piping is not an option with condensing unit
         piping.IsOption = (Me.SpecData.Unit = "Water chiller")
         piping.Explanation = Me.NotOption("condensing unit")

         Return piping
      End Function

      'base frame is not dependant on any other controls

      'epoxy coating is an option with galvanized steel not SS
      Public Function GetEpoxyCoated() As SpecBuilderOption
         Dim epoxy As New SpecBuilderOption

         epoxy.IsOption = _
            (Me.SpecData.HousingAndPiping.Housing = _
               "heavy gauge G-90 galvanized steel")

         epoxy.Explanation = Me.NotOption("stainless steel")

         Return epoxy
      End Function

#End Region


#Region " Compressor"

      Public Function GetCylinderLoading() As SpecBuilderOption
         Dim cylinder As New SpecBuilderOption

         'only an option with reciprocating compressor
         cylinder.IsOption = _
            (Me.SpecData.Compressor.Compressor = "reciprocating (semi-hermetic)")
         cylinder.Explanation = _
            Me.NotOption("scroll or rotary screw compressors")

         Return cylinder
      End Function


      Public Function GetCylinderLoadingOption() As SpecBuilderOption
         Dim cylinder As New SpecBuilderOption

         'only an option with reciprocating compressor and cylinder loading
         If Me.SpecData.Compressor.Compressor <> "reciprocating (semi-hermetic)" Then
            cylinder.IsOption = False
            cylinder.Explanation = _
               Me.NotOption("scroll or rotary screw compressors")
         ElseIf SpecData.Compressor.Compressor = "reciprocating (semi-hermetic)" _
         And Me.SpecData.Compressor.CylinderLoading = True Then
            cylinder.IsOption = True
         Else
            cylinder.IsOption = False
            cylinder.Explanation = Me.OnlyOption("cylinder loading")
         End If

         Return cylinder
      End Function


      Public Function GetCapacitySlideValveModulation() As SpecBuilderOption
         Dim modulation As New SpecBuilderOption

         'capacity modulation not an option for reciprocating and scroll
         modulation.IsOption = _
            (Me.SpecData.Compressor.Compressor = "rotary screw (semi-hermetic)")
         modulation.Explanation = _
            Me.NotOption("reciprocating and scroll compressors")

         Return modulation
      End Function


#End Region


#Region " Evaporator"

      Public Function GetEvaporator() As SpecBuilderOption
         Dim evaporator As New SpecBuilderOption

         evaporator.IsOption = (Me.SpecData.Unit <> "Condensing unit")
         evaporator.Explanation = Me.NotOption("condensing unit")

         Return evaporator
      End Function

      Public Function GetPressure() As SpecBuilderOption
         Dim pressure As New SpecBuilderOption

         If Me.SpecData.Unit = "Condensing unit" Then
            pressure.IsOption = False
            pressure.Explanation = Me.NotOption("condensing unit")
         Else
            pressure.IsOption = (Me.SpecData.Evaporator.Evaporator = "Shell and tube")
            pressure.Explanation = _
               Me.NotOption("brazed plate heat exchanger")
         End If

         Return pressure
      End Function

#End Region


#Region " Condenser"

      Public Function GetAirCooled() As SpecBuilderOption
         Dim airCooled As New SpecBuilderOption

         airCooled.IsOption = (Me.SpecData.Condenser.Condenser = "Air-cooled")
         airCooled.Explanation = Me.OnlyOption("air-cooled condenser")

         Return airCooled
      End Function

      Public Function GetWaterCooled() As SpecBuilderOption
         Dim waterCooled As New SpecBuilderOption

         waterCooled.IsOption = (Me.SpecData.Condenser.Condenser = "Water-cooled")
         waterCooled.Explanation = Me.OnlyOption("water-cooled condenser")

         Return waterCooled
      End Function


      Public Function GetEvaporativeCooled() As SpecBuilderOption
         Dim evaporativeCooled As New SpecBuilderOption

         evaporativeCooled.IsOption = _
            (Me.SpecData.Condenser.Condenser = "Evaporative-cooled")
         evaporativeCooled.Explanation = Me.OnlyOption("evaporative-cooled condenser")

         Return evaporativeCooled
      End Function


      Public Function GetDischarge() As SpecBuilderOption
         Dim discharge As New SpecBuilderOption

         discharge.IsOption = (Me.SpecData.Condenser.CondenserType = _
            "Centrifugal blowers")
         discharge.Explanation = Me.NotOption("prop fans")

         Return discharge
      End Function


      Public Function GetRainHood() As SpecBuilderOption
         Dim rainHood As New SpecBuilderOption

         rainHood.IsOption = (Me.SpecData.Condenser.CondenserType = _
            "Centrifugal blowers")
         rainHood.Explanation = Me.NotOption("prop fans")

         Return rainHood
      End Function


      Public Function GetHeatedAndInsulatedReceivers() As SpecBuilderOption
         Dim receiver As New SpecBuilderOption

         receiver.IsOption = (Me.SpecData.Condenser.FloodedCondenserControl)
         receiver.Explanation = Me.OnlyOption("flooded condenser control")

         Return receiver
      End Function

#End Region


#Region " Refrigerant Circuit"

      Public Function GetFilterDrierType() As SpecBuilderOption
         Dim filterDrier As New SpecBuilderOption

         filterDrier.IsOption = (Me.SpecData.Refrigerant.FilterDrier)
         filterDrier.Explanation = Me.OnlyOption("filter drier")

         Return filterDrier
      End Function

      Public Function GetSuctionFilterType() As SpecBuilderOption
         Dim suctionFilter As New SpecBuilderOption

         suctionFilter.IsOption = (Me.SpecData.Refrigerant.SuctionFilter)
         suctionFilter.Explanation = Me.OnlyOption("suction filter")

         Return suctionFilter
      End Function

      Public Function GetHotGasBypassDesign() As SpecBuilderOption
         Dim design As New SpecBuilderOption

         design.IsOption = (Me.SpecData.Refrigerant.HotGasBypass)
         design.Explanation = Me.OnlyOption("hot gas bypass")

         Return design
      End Function

      Public Function GetHotGasBypassTons() As SpecBuilderOption
         Dim tons As New SpecBuilderOption

         tons.IsOption = (Me.SpecData.Refrigerant.HotGasBypass)
         tons.Explanation = Me.OnlyOption("hot gas bypass")

         Return tons
      End Function

      Public Function GetSolenoid() As SpecBuilderOption
         Dim solenoid As New SpecBuilderOption

         solenoid.IsOption = (Me.SpecData.Unit <> "Water chiller")
         solenoid.Explanation = "Liquid line solenoid is required with water chiller"
         'solenoid is standard with water chiller
         solenoid.StandardValue = True

         Return solenoid
      End Function

      Public Function GetFilterDrier() As SpecBuilderOption
         Dim drier As New SpecBuilderOption

         drier.IsOption = (Me.SpecData.Unit <> "Water chiller")
         drier.Explanation = "Liquid line filter drier is required with water chiller."
         drier.StandardValue = True

         Return drier
      End Function

      Friend Function GetExpansionValve() As SpecBuilderOption
         Dim valve As New SpecBuilderOption

         valve.IsOption = (Me.SpecData.Unit = "Water chiller")
         valve.Explanation = Me.OnlyOption("water chiller")

         Return valve
      End Function

#End Region


#Region " Controls"

      Public Function GetPumpStatusLight() As SpecBuilderOption
         Dim pump As New SpecBuilderOption

         'pump status light is only available with water chiller, so is pump package
         pump.IsOption = (Me.SpecData.Unit = "Water chiller")
         pump.Explanation = Me.OnlyOption("water chiller")

         Return pump
      End Function

      Public Function GetDisconnectOptionType() As SpecBuilderOption
         Dim disconnect As New SpecBuilderOption

         disconnect.IsOption = (Me.SpecData.Controls.DisconnectOption)
         disconnect.Explanation = Me.OnlyOption("disconnect option")

         Return disconnect
      End Function

      Public Function GetCompressorLeadLagSwitch() As SpecBuilderOption
         Dim switch As New SpecBuilderOption

         switch.IsOption = (Me.SpecData.Controls.ControlsType = "Electronic")
         switch.Explanation = Me.OnlyOption("electronic controls")

         Return switch
      End Function

      Public Function GetUnitPhaseMonitorScope() As SpecBuilderOption
         Dim scope As New SpecBuilderOption

         scope.IsOption = (Me.SpecData.Controls.UnitPhaseMonitor)
         scope.Explanation = Me.OnlyOption("unit phase monitor")

         Return scope
      End Function

      Public Function GetLcd() As SpecBuilderOption
         Dim Lcd As New SpecBuilderOption

         Lcd.IsOption = (Me.SpecData.Controls.ControlsType = "DDC Controls")
         Lcd.Explanation = Me.OnlyOption("DDC controls")

         Return Lcd
      End Function

      Public Function GetLcdOptions() As SpecBuilderOption
         Dim Lcd As New SpecBuilderOption

         Lcd.IsOption = (Me.SpecData.Controls.Lcd And _
            Me.SpecData.Controls.ControlsType = "DDC Controls")

         If (Me.SpecData.Controls.ControlsType <> "DDC Controls") Then
            Lcd.Explanation = Me.OnlyOption("DDC controls")
         ElseIf Not Me.SpecData.Controls.Lcd Then
            Lcd.Explanation = Me.OnlyOption("LCD")
         End If

         Return Lcd
      End Function

#End Region


#Region " Pump Package"

      Friend Function GetPump() As SpecBuilderOption
         Dim pump As New SpecBuilderOption

         pump.IsOption = (Me.SpecData.Unit = "Water chiller")
         pump.Explanation = Me.OnlyOption("water chiller")

         Return pump
      End Function

      Friend Function GetPumpControls() As SpecBuilderOption
         Dim controls As New SpecBuilderOption

         controls.IsOption = (Me.SpecData.Pump.PumpPackage)
         controls.Explanation = Me.OnlyOption("water chiller")

         Return controls
      End Function

      Friend Function GetDualPumpOption() As SpecBuilderOption
         Dim dual As New SpecBuilderOption

         dual.IsOption = (Me.SpecData.Pump.DesignCriteria = "Dual")
         dual.Explanation = Me.OnlyOption("dual pumps")

         Return dual
      End Function

      Friend Function GetAirSeperatorType() As SpecBuilderOption
         Dim air As New SpecBuilderOption

         air.IsOption = (Me.SpecData.Pump.AirSeperator)
         air.Explanation = Me.OnlyOption("air seperator")

         Return air
      End Function

      Friend Function GetExpansionTankType() As SpecBuilderOption
         Dim tank As New SpecBuilderOption

         tank.IsOption = (Me.SpecData.Pump.ExpansionTank)
         tank.Explanation = Me.OnlyOption("expansion tank")

         Return tank
      End Function

      Friend Function GetStorageTankVolume() As SpecBuilderOption
         Dim volume As New SpecBuilderOption

         volume.IsOption = (Me.SpecData.Pump.StorageTank)
         volume.Explanation = Me.OnlyOption("mass storage tank")

         Return volume
      End Function

      Friend Function GetStorageTankRatingAsm() As SpecBuilderOption
         Dim Asm As New SpecBuilderOption

         If Me.SpecData.Pump.StorageTank Then
            If Me.SpecData.Pump.StorageTankType = "Closed, Pressurized Tank" Then
               Asm.IsOption = True
               Asm.Explanation = String.Empty
            Else
               Asm.IsOption = False
               Asm.Explanation = Me.OnlyOption("pressurized tank")
            End If
         Else
            Asm.IsOption = False
            Asm.Explanation = Me.OnlyOption("mass storage tank")
         End If

         Return Asm
      End Function

      Friend Function GetStorageTankRatingPsi() As SpecBuilderOption
         Dim Psi As New SpecBuilderOption

         If Me.SpecData.Pump.StorageTank Then
            If Me.SpecData.Pump.StorageTankType = "Closed, Pressurized Tank" Then
               Psi.IsOption = True
               Psi.Explanation = String.Empty
            Else
               Psi.IsOption = False
               Psi.Explanation = Me.OnlyOption("pressurized tank")
            End If
         Else
            Psi.IsOption = False
            Psi.Explanation = Me.OnlyOption("mass storage tank")
         End If

         Return Psi
      End Function

      Friend Function GetStorageTankType() As SpecBuilderOption
         Dim tank As New SpecBuilderOption

         tank.IsOption = (Me.SpecData.Pump.StorageTank)
         tank.Explanation = Me.OnlyOption("mass storage tank")

         Return tank
      End Function

#End Region


#Region " Hazardous Duty Options"

      Friend Function GetHazard() As SpecBuilderOption
         Dim hazard As New SpecBuilderOption

         hazard.IsOption = (Me.SpecData.Hazard.Hazard)
         hazard.Explanation = _
            Me.OnlyOption("corrosion resistance/hazardous duty options")

         Return hazard
      End Function

#End Region


#Region " Acoustic Treatment"

      Friend Function GetAcousticControls() As SpecBuilderOption
         Dim acoustic As New SpecBuilderOption

         acoustic.IsOption = (Me.SpecData.Acoustic.Acoustic)
         acoustic.Explanation = Me.OnlyOption("acoustic treatement")

         Return acoustic
      End Function

      Friend Function GetCompressorCovering() As SpecBuilderOption
         Dim covering As New SpecBuilderOption

         covering.IsOption = (Me.SpecData.Acoustic.Compressors)
         covering.Explanation = Me.OnlyOption("compressors")

         Return covering
      End Function

      Friend Function GetCompressorSpringIsolators() As SpecBuilderOption
         Dim isolators As New SpecBuilderOption

         isolators.IsOption = (Me.SpecData.Acoustic.Compressors And _
            Me.SpecData.Compressor.Compressor = "reciprocating (semi-hermetic)")
         isolators.Explanation = Me.OnlyOption("recip compressors")

         Return isolators
      End Function

      Friend Function GetCondenserFanType() As SpecBuilderOption
         Dim fan As New SpecBuilderOption

         fan.IsOption = Me.SpecData.Acoustic.CondenserFans
         fan.Explanation = Me.OnlyOption("condenser fans")

         Return fan
      End Function

      Friend Function GetCondenserShroud() As SpecBuilderOption
         Dim shroud As New SpecBuilderOption

         shroud.IsOption = Me.SpecData.Acoustic.CondenserFans
         shroud.Explanation = Me.OnlyOption("condenser fans")

         Return shroud
      End Function

#End Region


#Region " Other"
      Friend Function GetWatersideEconomizer() As SpecBuilderOption
         Dim economizer As New SpecBuilder.SpecBuilderOption

         economizer.IsOption = (Me.SpecData.Unit = "Water chiller")
         economizer.Explanation = Me.OnlyOption("water chiller")

         Return economizer
      End Function
#End Region
   End Class

End Namespace
