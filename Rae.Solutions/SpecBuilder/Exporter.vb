Imports Rae.Math

Namespace SpecBuilder

   Public Class Exporter


#Region " Declarations"

      Dim _specOutliner As Outliner.Outliner
      Dim _specData As SpecBuilder.SpecBuilderData

#End Region


#Region " Properties"

      Public Property SpecOutliner() As Outliner.Outliner
         Get
            Return Me._specOutliner
         End Get
         Set(ByVal Value As Outliner.Outliner)
            Me._specOutliner = Value
         End Set
      End Property


      Public Property SpecData() As SpecBuilderData
         Get
            Return Me._specData
         End Get
         Set(ByVal Value As SpecBuilderData)
            Me._specData = Value
            If Me.optManager Is Nothing Then
               Me.optManager = New OptionManager(Value)
            Else
               Me.optManager.SpecData = Value
            End If
         End Set
      End Property

#End Region


      Dim optManager As New OptionManager(SpecData)
      Dim part As New Math.Incrementer
      Dim numDotNum As New Math.Incrementer


#Region " Public Methods"

      Public Sub New()
         Me._specOutliner = New Outliner.Outliner
      End Sub


      Public Sub New(ByVal specData As SpecBuilderData)
         Me._specOutliner = New Outliner.Outliner
         Me.SpecData = specData
      End Sub

      Public Function BuildHtmlSpec() As String
         Dim html As String

         'adds levels (which contain numbering formats)
         Me.AddSpecOutlinerLevels()
         'builds outline
         SpecOutliner.DataSource = Me.GetOutline(Me.SpecData)
         'numbers outline according to format and converts to string
         html = SpecOutliner.ToNumberedString
         'adds HTML header and footer
         html = Me.CompleteHtml(html)

         Return html
      End Function

#End Region


      Friend Function GetOutline( _
      ByVal specData As SpecBuilder.SpecBuilderData) As Outliner.Outline
         Dim products, manufacturer, _
            manufacturedUnits, housing, compressor, lubrication, performance, _
            controls, installation As Outliner.Outline.EntriesRow
         Dim units, solution, solenoid As String

         With Me.SpecOutliner.DataSource.Entries
            .AddEntriesRow(0, "Section 15681A<br>" & specData.Unit.ToUpper, _
               0, "section")
            'Part 1 general requirements
            .AddEntriesRow(1, "General Requirements", part.Num, "")

            Me.AddSectionIncludes()
            Me.AddReferences()
            Me.AddSubmittal()
            Me.AddOperation()
            Me.AddQualityAssurance()

            'Part 2 Products
            products = .NewEntriesRow
            With products
               .ParentID = 1
               .EntryText = "Products"
               .Order = Me.part.Increment
            End With
            Me.SpecOutliner.DataSource.Entries.AddEntriesRow(products)

            Me.AddEquipmentManufacturer(products.ID)
            Me.AddManufacturedUnits(products.ID)
            Me.AddHousingAndPiping(products.ID)
            Me.AddCompressor(products.ID)
            Me.AddEvaporator(products.ID)
            Me.AddCondenser(products.ID)
            Me.AddRefrigerantCircuit(products.ID)
            Me.AddHazard(products.ID)
            Me.AddAcoustic(products.ID)
            Me.AddPump(products.ID)
            Me.AddTripleDutyValve(products.ID)
            Me.AddAirSeparator(products.ID)
            Me.AddAirVent(products.ID)
            Me.AddExpansionTank(products.ID)
            Me.AddControls(products.ID)
            Me.AddWatersideEconomizer(products.ID)
            Me.AddFieldServices(products.ID)

         End With

         Return SpecOutliner.DataSource
      End Function


      Friend Shared Sub WriteHtml(ByVal html As String, ByVal filePath As String)
         Dim writer As System.IO.StreamWriter

         'TODO: handle exception when file is in use
         'initializations
         writer = New System.IO.StreamWriter(filePath)

         'writes html to file
         writer.Write(html)
         'finishes writing anything waiting to be written
         writer.Flush()
         'closes file, so that it can be used by other processes
         writer.Close()
      End Sub


      Friend Shared Sub OpenWordDoc(ByVal filePath As String, _
      ByVal MSWordPath As String)
         Dim quotes As String = Microsoft.VisualBasic.Chr(34)

         '>> opens html page in MS Word
         '>> for arguements on a command line a space or tab represents a new parameter,
         '   so that's why you use " " for arguements with spaces
         System.Diagnostics.Process.Start(MSWordPath, _
            quotes & filePath & quotes)
      End Sub


#Region " Private Methods"

      Private Sub AddSpecOutlinerLevels()
         Dim highestFormat As Outliner.Format
         Dim highFormat As Outliner.Format
         Dim midFormat As Outliner.Format
         Dim lowFormat As New Outliner.Format
         Dim lowestFormat As Outliner.Format
         'lowFormat.NumberingText = "Section {parentNumber}-{number}"

         'no numbering
         highestFormat = New Outliner.Format( _
            "<TR VALIGN='top'><TD WIDTH=700 COLSPAN=4><FONT SIZE=4><B>", _
            "</B></FONT></TD></TR>", Outliner.Numbering.LowerCaseLetter)
         'Part #
         highFormat = New Outliner.Format( _
            "<TR VALIGN='top'><TD WIDTH=700 COLSPAN=4><STRONG><br>{numbering} ", _
            "</STRONG></TD></TR>", Outliner.Numbering.PartNumber)
         '#.##
         midFormat = New Outliner.Format( _
            "<TR VALIGN='top'><TD WIDTH=68 COLSPAN=1><STRONG>{numbering}</STRONG></TD><TD WIDTH=632 COLSPAN=3><STRONG>", _
            "</STRONG></TD></TR>", Outliner.Numbering.NumberPointNumber)
         '@.
         lowFormat = New Outliner.Format( _
            "<TR VALIGN='top'><TD WIDTH=68 COLSPAN=1></TD><TD WIDTH=28 COLSPAN=1>{numbering}</TD><TD WIDTH=504 COLSPAN=2>", _
            "</TD></TR>", Outliner.Numbering.UpperCaseLetter)
         '#.
         lowestFormat = New Outliner.Format( _
            "<TR VALIGN='top'><TD WIDTH=68 COLSPAN=1></TD>" & _
               "<TD WIDTH=28 COLSPAN=1></TD><TD WIDTH=28 COLSPAN=1>{numbering}</TD>" & _
               "<TD WIDTH=476 COLSPAN=1>", _
            "</TD></TR>", _
            Outliner.Numbering.Number)

         'adds levels and sets their format
         With Me.SpecOutliner.Levels
            .Add(New Outliner.Level(highestFormat))
            .Add(New Outliner.Level(highFormat))
            .Add(New Outliner.Level(midFormat))
            .Add(New Outliner.Level(lowFormat))
            .Add(New Outliner.Level(lowestFormat))
         End With

      End Sub

      Private Function CompleteHtml(ByVal HTMLRows As String) As String
         Dim HTML, header, footer As String

         'sets header
         header = "<HTML><BODY><TABLE>" & Environment.NewLine
         '"<TR><TD COLSPAN=4><FONT Size=4><B>Section 15681A<BR></B></FONT></TD></TR>"
         'sets footer
         footer = "</TABLE></BODY></HTML>"

         'adds rows
         HTML = HTMLRows
         'adds header
         HTML = HTML.Insert(0, header)
         'adds footer
         HTML = HTML & Environment.NewLine & footer

         Return HTML
      End Function


      Private Sub AddSectionIncludes()
         Dim letter As New Incrementer

         With Me.SpecOutliner.DataSource.Entries
            'Section Includes
            .AddEntriesRow(2, "Section Includes", Me.numDotNum.Num, "")
            .AddEntriesRow(3, SpecData.Condenser.Condenser & " " & _
               SpecData.Compressor.Compressor.ToLower & " " & _
               SpecData.Unit.ToLower, letter.Num, "")
            .AddEntriesRow(3, "Accessories and trim", letter.Increment, "")
            .AddEntriesRow(3, "Charge of refrigerant and oil", letter.Increment, "")
            .AddEntriesRow(3, "Controls and control connections", letter.Increment, "")
            .AddEntriesRow(3, "Chilled glycol connections", letter.Increment, "")
            .AddEntriesRow(3, "Starters", letter.Increment, "")
            .AddEntriesRow(3, "Electrical power connections", letter.Increment, "")
            If optManager.GetPumpControls.IsOption Then
               .AddEntriesRow(3, "Chilled water pump", letter.Increment, "")
            End If
         End With
      End Sub

      Private Sub AddReferences()
         Dim references As Outliner.Outline.EntriesRow
         Dim letter As New Incrementer

         With Me.SpecOutliner.DataSource.Entries
            references = .NewEntriesRow
            references.ParentID = 2
            references.EntryText = "References"
            references.Order = Me.numDotNum.Increment
            Me.SpecOutliner.DataSource.Entries.AddEntriesRow(references)

            .AddEntriesRow(references.ID, _
               "SI/ARI 590 - Standard for Reciprocating and Screw Compressorized" & _
               " Water Chilling Packages", letter.Num, "")
            .AddEntriesRow(references.ID, _
               "ANSI/ASME SEC 8 - Boiler and Pressure Vessel Code", _
               letter.Increment, "")
            .AddEntriesRow(references.ID, _
               "ANSI/ASHRAE 15 - Safety Code for Mechanical Refrigeration", _
               letter.Increment, "")
            .AddEntriesRow(references.ID, _
               "ANSI/UL 465 - Central Cooling Air Conditioners", letter.Increment _
               , "")
            .AddEntriesRow(references.ID, _
               "ANSI/UL 779 - Motor-Operated Water Pumps", letter.Increment, "")
         End With
      End Sub

      Private Sub AddSubmittal()
         Dim submittal As Outliner.Outline.EntriesRow
         Dim letter As New Math.Incrementer

         With SpecOutliner.DataSource.Entries
            submittal = .NewEntriesRow
            submittal.ParentID = 2
            submittal.EntryText = "Submittal"
            submittal.Order = Me.numDotNum.Increment
            Me.SpecOutliner.DataSource.Entries.AddEntriesRow(submittal)

            .AddEntriesRow(submittal.ID, _
               "Submit shop drawings indicating components, assembly, dimensions," & _
               " weights, and loadings, required clearances, and location and " & _
               "size of field connections.  Indicate valves, strainers, and " & _
               "thermostatic valves required for complete system.", letter.Num, "")
            .AddEntriesRow(submittal.ID, _
               "Submit product data indicating rated capacities, weights, and " & _
               "all accessories. Also, submit complete wiring diagrams " & _
               "specifically for the unit being submitted. The wiring diagrams" & _
               " shall include all rated loads and recommended component sizes." & _
               " No item that is not being submitted with the equipment shall " & _
               "appear on the diagram. Also, submit refrigerant piping diagram" & _
               " showing all components and connection sizes.", letter.Increment, "")
            .AddEntriesRow(submittal.ID, _
               "Submit manufacturer's installation instructions.", _
               letter.Increment, "")
            If Me.optManager.GetPumpControls.IsOption Then
               .AddEntriesRow(submittal.ID, "Submit a complete hydronic piping schematic showing all components and connection sizes. Also include a pump curve showing performance.", letter.Increment, "")
            End If
         End With
      End Sub

      Private Sub AddOperation()
         Dim operation As Outliner.Outline.EntriesRow
         Dim letter As New Incrementer

         With Me.SpecOutliner.DataSource.Entries
            operation = .NewEntriesRow
            With operation
               .ParentID = 2
               .EntryText = "Operation and Maintenance Data"
               .Order = Me.numDotNum.Increment
            End With
            Me.SpecOutliner.DataSource.Entries.AddEntriesRow(operation)

            .AddEntriesRow(operation.ID, _
               "Include start-up instructions, maintenance data, parts lists, " & _
               "controls, and accessories. Include trouble-shooting guide.", _
               letter.Num, "")
            .AddEntriesRow(operation.ID, "Submit maintenance data.", _
               letter.Increment, "")
         End With
      End Sub

      Private Sub AddQualityAssurance()
         Dim quality As Outliner.Outline.EntriesRow
         Dim warranty As String
         Dim letter As New Incrementer

         With Me.SpecOutliner.DataSource.Entries
            quality = .NewEntriesRow
            With quality
               .ParentID = 2
               .EntryText = "Quality Assurance"
               .Order = 4
            End With
            Me.SpecOutliner.DataSource.Entries.AddEntriesRow(quality)

            warranty = "Warranty: Includes coverage for complete assembly " & _
               "including materials and workmanship for a period of 12 months " & _
               "from start-up or 18 months from shipping."
            If SpecData.Other.AdditionalWarranty Then
               warranty &= " And an additional four years warranty for parts" & _
                  " on the compressor only."
            End If
            .AddEntriesRow(quality.ID, warranty, 0, "")
            If optManager.GetPumpControls.IsOption Then
               .AddEntriesRow(quality.ID, "Select pumps to operate at or near " & _
                  "their point of peak efficiency. Maximum impeller size " & _
                  "shall not exceed 85% of the differences between the maximum " & _
                  "and minimum impeller diameter.", 1, "")
            End If
         End With
      End Sub

      Private Sub AddEquipmentManufacturer(ByVal partID As Integer)
         Dim manufacturer As Outliner.Outline.EntriesRow
         Dim letter As New Incrementer

         With Me.SpecOutliner.DataSource.Entries
            manufacturer = .NewEntriesRow
            With manufacturer
               .ParentID = partID
               .EntryText = "Equipment Manufacturer"
               Me.numDotNum.Num = 0
               .Order = Me.numDotNum.Num
            End With
            Me.SpecOutliner.DataSource.Entries.AddEntriesRow(manufacturer)

            .AddEntriesRow(manufacturer.ID, _
               "Technical Systems, Division of RAE Corporation", letter.Num, "")
            .AddEntriesRow(manufacturer.ID, "Edwards Engineering", _
               letter.Increment, "")
            .AddEntriesRow(manufacturer.ID, "Arcti-Chill", letter.Increment, "")
            .AddEntriesRow(manufacturer.ID, "Owner-approved equal", _
               letter.Increment, "")
         End With
      End Sub

      Private Sub AddManufacturedUnits(ByVal partID As Integer)
         Dim manufacturedUnits As Outliner.Outline.EntriesRow
         Dim solution, units, expansionTank, airSeparator, storageTank As String

         expansionTank = String.Empty
         airSeparator = String.Empty
         storageTank = String.Empty

         With Me.SpecOutliner.DataSource.Entries
            manufacturedUnits = .NewEntriesRow
            With manufacturedUnits
               .ParentID = partID
               .EntryText = "Manufactured Units"
               .Order = Me.numDotNum.Increment
            End With
            Me.SpecOutliner.DataSource.Entries.AddEntriesRow(manufacturedUnits)

            If optManager.GetCoolingSolutionPercentage.IsOption Then
               solution = SpecData.SolutionPercentage & "% " & _
                  SpecData.CoolingSolution
            Else
               solution = SpecData.CoolingSolution
            End If
            units = "Provide factory assembled and tested " & _
               SpecData.Condenser.Condenser.ToLower & _
               " liquid " & _
               SpecData.Unit.ToLower & _
               "s consisting of " & _
               SpecData.Compressor.Compressor.ToLower & _
               " compressors, evaporator, thermal expansion valve, " & _
               "refrigeration accessories, and control panel housing all power " & _
               "and control components. Construction and rating shall be in " & _
               "accordance with ANSI/ARI 590. Chiller package shall have " & _
               "minimum capacity as scheduled here in for a " & _
               solution.ToLower & _
               " solution, including all features described in the " & _
               "specification and/or noted on drawings."
            .AddEntriesRow(manufacturedUnits.ID, units, 0, "")
            If Me.optManager.GetPumpControls.IsOption Then
               Dim list As New ArrayList
               Dim pump, conjoinedList As String

               If Me.SpecData.Pump.ExpansionTank Then
                  list.Add("expansion tank")
               End If
               If Me.SpecData.Pump.AirSeperator Then
                  list.Add("air separator")
               End If
               If Me.SpecData.Pump.StorageTank Then
                  list.Add("mass storage tank")
               End If
               'conjoins list
               conjoinedList = Io.Text.Conjoin(list.ToArray, Io.Conjunction.And)
               pump = "Provide a(n) " & Me.SpecData.Condenser.Condenser.ToLower & " " & Me.SpecData.Unit.ToLower & " package with an integral chilled water pump, interconnecting piping and valves as required."
               If conjoinedList <> String.Empty Then
                  pump &= " Pump package shall also have " & conjoinedList & "."
               End If
               .AddEntriesRow(manufacturedUnits.ID, pump, 1, "")
            End If
         End With
      End Sub

      Private Sub AddHousingAndPiping(ByVal partID As Integer)
         Dim housing As Outliner.Outline.EntriesRow
         Dim letter As New Incrementer

         With Me.SpecOutliner.DataSource.Entries
            housing = .NewEntriesRow
            With housing
               .ParentID = partID
               .EntryText = "Housing and Interconnecting Piping"
               .Order = Me.numDotNum.Increment
            End With
            Me.SpecOutliner.DataSource.Entries.AddEntriesRow(housing)

            .AddEntriesRow(housing.ID, "The base frame shall be heavy duty " & _
               SpecData.HousingAndPiping.BaseFrame.ToLower & _
               ". The housing shall be fabricated from " & _
               SpecData.HousingAndPiping.Housing.ToLower & _
               " removable panels.", letter.Num, "")
            .AddEntriesRow(housing.ID, "The interconnecting piping shall be " & _
               SpecData.HousingAndPiping.Piping & ".", letter.Increment, "")
         End With
      End Sub

      Private Sub AddCompressor(ByVal partID As Integer)
         Dim compressor, lubrication, performance, controls, installation _
         As Outliner.Outline.EntriesRow
         Dim letter As New Incrementer
         Dim solenoid, valve As String

         With Me.SpecOutliner.DataSource.Entries
            compressor = .NewEntriesRow
            With compressor
               .ParentID = partID
               .EntryText = "Compressors " & SpecData.Compressor.Compressor
               .Order = Me.numDotNum.Increment
            End With
            Me.SpecOutliner.DataSource.Entries.AddEntriesRow(compressor)

            Select Case SpecData.Compressor.Compressor
               'recip compressor
               Case "reciprocating (semi-hermetic)"
                  .AddEntriesRow(compressor.ID, "Construct semi-hermetic " & _
                     "reciprocating compressors with heat-treated forged steel or " & _
                     "ductile iron shafts, aluminum alloy connecting rods, automotive" & _
                     " type pistons, rings to prevent gas leakage, suction and " & _
                     "discharge valves, and sealing surface immersed in oil. " & _
                     "Compressors shall be designed for use with " & _
                     SpecData.Compressor.Refrigerant & ".", letter.Num, "")
                  .AddEntriesRow(compressor.ID, "Provide reversible, positive " & _
                     "displacement, oil pump lubrication system with oil charging " & _
                     "valve, oil level sight glass, oil filter and magnetic plug on " & _
                     "strainer, arranged to ensure adequate lubrication during " & _
                     "starting, stopping and normal operation.  When compressors are " & _
                     "multiplexed on the same circuit, provide an oil equalization " & _
                     "system composed of an oil strainer, oil separator and an oil " & _
                     "reservoir. Capillary tube systems will not be accepted.", letter.Increment, "")
                  If optManager.GetCylinderLoadingOption.IsOption Then
                     solenoid = SpecData.Compressor.CylinderLoadingOption
                  Else
                     solenoid = "refrigerant suction pressure"
                  End If
                  .AddEntriesRow(compressor.ID, "Provide compressor with automatic " & _
                     "capacity reduction with electronic unloading solenoid valves " & _
                     "operated by " & solenoid & ". Provide for unloaded compressor " & _
                     "start.", letter.Increment, "")
                  .AddEntriesRow(compressor.ID, "Provide constant speed 1800 RPM " & _
                     "compressor motor, suction gas cooled with solid state sensor " & _
                     "and electronic winding overheating protection, designed for " & _
                     "across the line starting.  Furnish with starter.", _
                     letter.Increment, "")
                  .AddEntriesRow(compressor.ID, "Provide crankcase heater to " & _
                     "evaporate refrigerant returning to crankcase during shutdown. " & _
                     "Energize heater during off time, once compressor is energized, " & _
                     "disengage heater.", letter.Increment, "")
                  'scroll compressor
               Case "scroll (full hermetic)"
                  .AddEntriesRow(compressor.ID, "Compressors shall be direct " & _
                     "driven full hermetic, fixed compression scroll compressors" & _
                     " with cast iron frame and cast iron scrolls; one fixed and" & _
                     " one orbiting.", letter.Num, "")
                  .AddEntriesRow(compressor.ID, "Compressors shall have all " & _
                     "Teflon impregnated bronze drive bearings, crankcase heaters" & _
                     ", rotary dirt trap, rotolock fittings for discharge and " & _
                     "suction connections.  Each fitting shall have a Schrader " & _
                     "pressure tap.  The suction inlet shall be equipped with a " & _
                     "suction screen.", letter.Increment, "")
                  .AddEntriesRow(compressor.ID, "Compressor shall have large " & _
                     "internal volume capable of handling a minimum 22 lbs of " & _
                     "refrigerant. Compressor shall also have inherent dynamic" & _
                     " discharge valve to prevent backflow, and solenoid valve " & _
                     "to prevent shutdown noise.", letter.Increment, "")

                  lubrication = .NewEntriesRow
                  With lubrication
                     .ParentID = compressor.ID
                     .EntryText = "Lubrication System"
                     .Order = letter.Increment
                  End With
                  Me.SpecOutliner.DataSource.Entries.AddEntriesRow(lubrication)

                  .AddEntriesRow(lubrication.ID, "Compressor shall have inherent" & _
                     " centrifugal oil pump, oil filter, oil level sight glass," & _
                     " oil level adjustment Schraeder fitting.", 0, "")
                  .AddEntriesRow(lubrication.ID, "Oil shall have an initial " & _
                     "charge of 140 oz. Of mineral oil Sontex 200-LT or Witco " & _
                     "LP-200 only.", 1, "")

                  performance = .NewEntriesRow
                  With performance
                     .ParentID = compressor.ID
                     .EntryText = "Performance"
                     .Order = letter.Increment
                  End With
                  Me.SpecOutliner.DataSource.Entries.AddEntriesRow(performance)

                  .AddEntriesRow(performance.ID, "Compressor shall be designed " & _
                     "to operate at suction temperatures of 10&deg;F to " & _
                     "55&deg;F for 65&deg;F return gas, 0&deg;F subcooling and" & _
                     " 95&deg;F ambient.", 0, "")
                  .AddEntriesRow(performance.ID, "Compressor shall have minimum" & _
                     " EER of 11.1 at standard conditions, and also operate at " & _
                     "maximum sound power levels of 80 db(A) without discharge " & _
                     "mufflers.", 1, "")
                  .AddEntriesRow(performance.ID, "Compressor vibration of " & _
                     "maximum 1.3 mills peak to peak at 60 Hz discharge pulse " & _
                     "3.0 psi peak to peak is required.", 2, "")
                  .AddEntriesRow(performance.ID, "Compressor scroll members " & _
                     "shall separate in the event of liquid or debris " & _
                     "contamination. Tip seals are not allowed.", 3, "")

                  controls = .NewEntriesRow
                  With controls
                     .ParentID = compressor.ID
                     .EntryText = "Controls"
                     .Order = letter.Increment
                  End With
                  Me.SpecOutliner.DataSource.Entries.AddEntriesRow(controls)

                  .AddEntriesRow(controls.ID, "Compressor to have four (4) " & _
                     "individual motor winding sensors wired to a solid-state " & _
                     "module connected to 4 pin fusite.  In addition, an " & _
                     "inherent discharge temperature sensor shall be wired " & _
                     "in series with the motor sensors for compressor " & _
                     "self-protection.", 0, "")

                  installation = .NewEntriesRow
                  With installation
                     .ParentID = compressor.ID
                     .EntryText = "Installation"
                     .Order = letter.Increment
                  End With
                  Me.SpecOutliner.DataSource.Entries.AddEntriesRow(installation)

                  .AddEntriesRow(installation.ID, "Factory install an external " & _
                     "check valve in discharge to guarantee protection against " & _
                     "back flow in case of inherent valve failure. Install " & _
                     "factory mounted high and low pressure cut-outs. " & _
                     "Compressors to be mounted on neoprene rubber mounts.", 0, "")

               Case "rotary screw (semi-hermetic)"
                  .AddEntriesRow(compressor.ID, "Construct semi-hermetic rotary screw " & _
                     "compressor with double structure cast iron casing. " & _
                     "Compressor shall have two asymmetrical profile screw rotors " & _
                     "composed of ductile cast iron, or spheroidal graphite cast " & _
                     "iron. Compressors shall be designed for use with " & _
                     Me.SpecData.Compressor.Refrigerant & ".", letter.Num, "")
                  .AddEntriesRow(compressor.ID, "Provide compressor with radial roller" & _
                     " bearings to support radial loads from rotors. At the " & _
                     "discharge end of the compressor, the male rotor shall have " & _
                     "a triple angular contact ball bearings, and the female " & _
                     "screw rotor shall have double ball bearings. Each bearing" & _
                     " shall be lubricated by the oil from the oil separator. " & _
                     "Liquid refrigerant may not be used as a lubricant for the" & _
                     " rotors.", letter.Increment, "")
                  .AddEntriesRow(compressor.ID, "Provide compressor with an inherent " & _
                     "oil separator and oil reservoir. Oil shall be fed through " & _
                     "the oil strainer into the bearings and the capacity control " & _
                     "system by differential pressure between the discharge and " & _
                     "suction sides of the compressor. Oil passages from the " & _
                     "reservoir shall be cast into the compressor body to prevent " & _
                     "choking and oil leakage.  Capillary tubes shall not be " & _
                     "allowed.  An oil strainer shall be installed with a 150 " & _
                     "mesh reinforced steel filter with a side screen area. " & _
                     "Oil strainer shall be installed with a replaceable " & _
                     "flange for service.", letter.Increment, "")
                  If Me.SpecData.Compressor.CapacitySlideValveModulation = "Infinite control" Then   'infinite control
                     valve = "Capacity modulates infinitely as slide valve is relocated across rotor."
                  Else   'step control
                     valve = "Capacity modulates in steps as slide valve is relocated across rotor."
                  End If
                  .AddEntriesRow(compressor.ID, "Provide compressor with automatic proportional control slide valve. Capacity shall be able to be modulated down to 25&#37; of full load capacity. The slide valve shall be located on the topside of the rotors and allows refrigerant gas to bypass from the suction side to the discharge side. The slide valve shall be controlled by a series of oil solenoid valves that allow oil to flow to and from the rotor side of the piston. The solenoid valves shall be controlled by a proportional integral controller that stages compressors based on return water temperature, and modulates the slide valve based on supply water temperature. " & valve, letter.Increment, "")
                  .AddEntriesRow(compressor.ID, "Provide constant speed 1800 RPM compressor motor, suction gas cooled with solid state sensor and electronic winding overheating protection, designed for across the line starting. Furnish with starter.", letter.Increment, "")
                  .AddEntriesRow(compressor.ID, "Provide crankcase heater to evaporate refrigerant returning to crankcase during shutdown. Energize heater during off time, once compressor is energized, disengage heater.", letter.Increment, "")
                  .AddEntriesRow(compressor.ID, "Install check valve on the discharge port of the compressor to protect against liquid migration back to the compressor during off cycles.", letter.Increment, "")
            End Select
         End With
      End Sub

      Private Sub AddEvaporator(ByVal partID As Integer)
         Dim letter As New Incrementer
         Dim evaporator As Outliner.Outline.EntriesRow
         Dim evaporatorType As String

         'only and option with water chiller (not condensing unit)
         If Me.SpecData.Unit <> "Water chiller" Then
            Exit Sub
         End If

         With Me.SpecOutliner.DataSource.Entries
            evaporator = .NewEntriesRow
            With evaporator
               .ParentID = partID
               .Order = Me.numDotNum.Increment
            End With
            .AddEntriesRow(evaporator)

            If Me.SpecData.Evaporator.Evaporator = "Shell and tube" Then
               evaporator.EntryText = "Evaporator [Shell and Tube]"
               .AddEntriesRow(evaporator.ID, "Provide evaporator of shell and tube type seamless or welded steel construction with cast iron or fabricated steel heads, seamless 5/8&quot; copper tubes or red brass tubes with integral aluminum fins, rolled or silver brazed into tube sheets. Provide multiple refrigerant circuits.", letter.Num, "")
               .AddEntriesRow(evaporator.ID, "Design, test and stamp cooler verifying that the refrigerant side has be rated for 225 PSIG working pressure and water side for " & Me.SpecData.Evaporator.Pressure & " working pressure in accordance with ANSI/ASME SEC 8.", letter.Increment, "")
               .AddEntriesRow(evaporator.ID, "Provide cooler heater cable wired to provide low ambient freeze protection during off cycle.", letter.Increment, "")
               .AddEntriesRow(evaporator.ID, "Insulate with 0.75 inch minimum thick flexible expanded polyvinyl chloride insulation with maximum K value of 0.26.", letter.Increment, "")
               .AddEntriesRow(evaporator.ID, "Provide water drain connection and thermometer wells for temperature controller and low temperature cutout.", letter.Increment, "")
            Else
               evaporator.EntryText = "Evaporator [Brazed plate heat exchanger]"
               .AddEntriesRow(evaporator.ID, "Provide as shown on attached drawings, a brazed plate heat exchanger as manufactured by Alfa Laval.  Heat exchangers shall be both UL and ETL listed.", letter.Num, "")
               .AddEntriesRow(evaporator.ID, "Heat exchanger shall consist of pressed Type 316L stainless steel plates as necessary to provide the required heat transfer area to meet the specified operating conditions.", letter.Increment, "")
               .AddEntriesRow(evaporator.ID, "Heat exchangers shall be constructed to prevent any external moisture from being trapped between plate surfaces and possibly freezing.", letter.Increment, "")
               .AddEntriesRow(evaporator.ID, "Copper brazing material shall be 99.9% pure copper.", letter.Increment, "")
               .AddEntriesRow(evaporator.ID, "Construction of the brazed plate heat exchanger shall allow the two heat transfer mediums to flow in a counter current direction.", letter.Increment, "")
               .AddEntriesRow(evaporator.ID, "Heat exchangers shall have a minimum design pressure of vacuum and a maximum design pressure of 435 psi.  They shall also be rated for a minimum design temperature of -256 F and a maximum design temperature of 435 F.", letter.Increment, "")
            End If
         End With
      End Sub

      Private Sub AddCondenser(ByVal partID As Integer)
         Dim condenser As Outliner.Outline.EntriesRow
         Dim letter As New Incrementer

         With Me.SpecOutliner.DataSource.Entries
            condenser = .NewEntriesRow
            condenser.ParentID = partID
            condenser.Order = Me.numDotNum.Increment
            .AddEntriesRow(condenser)

            'AIR-COOLED
            If Me.SpecData.Condenser.Condenser = "Air-cooled" Then
               condenser.EntryText = "Condenser (Air-Cooled)"
               .AddEntriesRow(condenser.ID, "Provide condenser of 1/2&quot; copper tubes with " & Me.SpecData.Condenser.FinMaterial & " plate fins. Fins shall be formed with tube collars and mechanically expanded with fin collars for full contact for optimum heat transfer. Condenser coils shall be tested to 425 psig air pressure.", letter.Num, "")
               .AddEntriesRow(condenser.ID, "Casings and tube sheets shall be heavy gauge " & Me.SpecData.Condenser.CasingsAndTubeSheets & ". Tube sheets shall be die formed and full collared for tube support. Headers to be constructed of heavy wall seamless copper tubing. Copper tubing to be " & Me.SpecData.Condenser.TubeThickness & " wall thickness. Fin thickness to be " & Me.SpecData.Condenser.FinThickness & ".", letter.Increment, "")
               If Me.SpecData.Condenser.LowAmbient = "fan cycling" Then
                  .AddEntriesRow(condenser.ID, "Provide unit with low ambient operation down to " & Me.SpecData.Condenser.Ambient & " by cycling fans based on refrigerant temperature. Cycling fans based on ambient temperature will not be allowed.", letter.Increment, "")
               Else
                  .AddEntriesRow(condenser.ID, "Provide condenser with variable speed control on last stage of fan operation. Controller shall be UL listed, factory mounted and wired and shall modulate fan speed based on refrigerant head pressure.", letter.Increment, "")
               End If
               If Me.SpecData.Condenser.FloodedCondenserControl Then
                  .AddEntriesRow(condenser.ID, "Provide unit with low ambient operation down to -20 F by a flooded condenser control. Provide liquid receivers with pressure relief device with the flood control. Install a flow-restricting valve in the main liquid line between the main condenser to the receiver. This valve shall restrict the flow and back up refrigerant liquid in the condenser based on refrigerant pressure. Install a bypass line between the hot gas line and the main liquid line to the condenser to bypass hot gas into the receiver when the refrigerant pressure continues to decrease.", letter.Increment, "")
               End If
               If Me.SpecData.Condenser.SubCoolingCircuit Then
                  .AddEntriesRow(condenser.ID, "Condenser shall be provided with a separate sub-cooling circuit integral with the main circuit for each refrigerant circuit.  Liquid seal shall be maintained by a trap between main header and sub-cooling circuit header.", letter.Increment, "")
               End If
               .AddEntriesRow(condenser.ID, "Fan motor shall be " & Me.SpecData.Condenser.Motor.ToLower & " type design. Motor shall have class F insulation and have service factor for safety.", letter.Increment, "")
               'chooses and adds condenser fan section
               Me.AddCondenserFan(partID)

               'WATER-COOLED
            ElseIf Me.SpecData.Condenser.Condenser = "Water-cooled" Then
               condenser.EntryText = "Condenser (Water-Cooled)"
               If Me.SpecData.Condenser.HeatExchanger.ToLower = "shell and tube" Then
                  .AddEntriesRow(condenser.ID, "Condensers shall be shell & tube type with condensing water running through the tubes and the refrigerant contained in the shell.  Tubing shall be rated to 150 psi. Tubing shall be seamless rolled copper tubes. Condensers shall be rated and stamped in accordance with ANSI/ASME Section VIII.", letter.Num, "")
               End If
               If Me.SpecData.Condenser.WaterValves Then
                  .AddEntriesRow(condenser.ID, "Condensers shall have pressure actuated water regulating valves. These valves will restrict the flow of water as the head pressure decreases in order to maintain a minimum saturated condensing temperature of 95&deg;F.  Valves shall be mounted on the water outlet to maintain turbulent flow through the condenser.", letter.Increment, "")
               End If

               'EVAPORATIVE-COOLED
            ElseIf Me.SpecData.Condenser.Condenser = "Evaporative-cooled" Then
               Dim material, fanCoating, headPressure, coilTubeMaterial, _
               attenuators As String
               Dim waterTreatment As Outliner.Outline.EntriesRow

               'sets section title
               condenser.EntryText = "Condenser (Evaporative-cooled)"

               'condenser material
               Select Case Me.SpecData.Condenser.Material.ToLower
                  'G-235
                  Case "g-235 galvanize sump"
                     material = "Condenser pan and casing shall be constructed of G-235 hot-dip galvanized steel for long life and durability. During fabrication, all panel edges shall be coated with a 95&#37; pure zinc-rich compound."
                     fanCoating = ""
                  Case "304 stainless steel sump"
                     material = "Condenser pan shall be constructed of 304 stainless steel for long life and durability. Interior and exterior surfaces to be G-235 galvanized steel. During fabrication, all panel edges shall be coated with a 95&#37; pure zinc-rich compound."
                     fanCoating = "Fan wheel shall be epoxy coated. Fan shafts to be coated with rust inhibitor. "
                  Case "304 stainless steel water-touch (sump and wet surfaces)"
                     material = "Condenser pan and casing and surface directly in contact with wet air stream, shall be constructed of 304 stainless steel for long life and durability."
                     fanCoating = "Fan wheel shall be epoxy coated. Fan shafts to be coated with rust inhibitor. "
                  Case "all stainless constructions (sump, wet surfaces, cabinet)"
                     material = "Condenser pan and casing and surface directly in contact with wet air stream, shall be constructed of 304 stainless steel for long life and durability. In addition, all panels on exterior, including fan housing and supports shall be constructed of 304 stainless steel."
                     fanCoating = ""
               End Select

               'Head pressure control
               If Me.SpecData.Condenser.HeadPressure = "2 speed fan motors" Then
                  '2-speed
                  headPressure = "The condenser shall be equipped with 2-speed fan motors to control head pressure control in mild and low ambient conditions. The unit DDC controller shall monitor head pressure in each refrigerant circuit and change the fan speed as needed to maintain compressor operation. "
               ElseIf Me.SpecData.Condenser.HeadPressure = "VFD fan control" Then
                  headPressure = "The condenser shall be equipped with a variable frequency drive to control speed of the fan for head pressure control in mild and low ambient conditions. The drive shall be mounted in the compressor compartment and shall be controlled by the unit DDC controller. The controller shall monitor head pressure in each refrigerant circuit and modify the fan speed as needed to maintain compressor operation."
               End If

               'condenser coil tube material
               If Me.SpecData.Condenser.Coil.ToLower = "steel tube" Then
                  coilTubeMaterial = "The condenser coil shall be prime surface " & Me.SpecData.Condenser.Coil.ToLower + ", encased in steel framework with the entire assembly hot-dip galvanized after fabrication. Coil shall have staggered elliptical tubes for more heat transfer surface area and lower static. Coil shall be designed with sloping tubes for free drainage of liquid refrigerant and tested to 350 PSIG air pressure under water. "
               ElseIf Me.SpecData.Condenser.Coil.ToLower = "copper tube" Then
                  coilTubeMaterial = "The condenser coil shall be copper tube surface. Copper tubes to be 5/8&quot; diameter and be Type L hard copper. Coil shall be designed with sloping tubes for free drainage of liquid refrigerant and tested to 350 PSIG air presure under water. "
               End If

               'Acoustic Attenuators
               If Me.SpecData.Condenser.AcousticAttenuatorsIntake _
               And Me.SpecData.Condenser.AcousticAttenuatorsDischarge Then
                  attenuators = "Intake and discharge "
               ElseIf Me.SpecData.Condenser.AcousticAttenuatorsDischarge _
               And Not Me.SpecData.Condenser.AcousticAttenuatorsIntake Then
                  attenuators = "Discharge "
               ElseIf Me.SpecData.Condenser.AcousticAttenuatorsIntake _
               And Not Me.SpecData.Condenser.AcousticAttenuatorsDischarge Then
                  attenuators = "Intake "
               End If

               .AddEntriesRow(condenser.ID, "The manufacturer of the evaporative condenser shall have been involved with the production of this equipment of this size for over 5 years. In addition, the manufacturer of the condenser shall have current installations in within 50 miles of jobsite installation.", letter.Num, "")
               'B Condenser pan and casing shall be constructed of G-235 hot-dip galvanized steel for long life and durability.  During fabrication, all panel edges shall be coated with a 95&deg; pure zinc-rich compound.
               .AddEntriesRow(condenser.ID, material & " The heat transfer section shall be removable from the pan to provide easy handling and rigging. Pan/fan section shall include fans, motors, and drives mounted and aligned at the factory.  These items shall be located in the dry entering air stream to provide maximum service life and easy maintenance. Pan accessories shall include circular access doors, stainless steel strainers, wastewater bleed line with adjustable valve and brass makeup valve, with an unsinkable foam filled plastic float.", letter.Increment, "")
               .AddEntriesRow(condenser.ID, "Fans shall be forward curved centrifugal type of hot-dip galvanized construction. " & fanCoating & "The fans shall be factory installed into the pan/fan section, and statically and dynamically balanced for vibration free operation. Fans shall be mounted on either a solid steel shaft or a hollow steel shaft with forged bearing journals. The fan shaft shall be supported by heavy-duty, self-aligning bearings with cast-iron housings and lubrication fittings for maintenance. The fan drive shall be V-belt type with taper lock sheaves designed for 150&#37; of the motor nameplate horsepower. Drives are to be mounted and aligned at the factory.", letter.Increment, "")
               .AddEntriesRow(condenser.ID, headPressure, letter.Increment, "")
               .AddEntriesRow(condenser.ID, "Fan motor shall be totally enclosed fan cooled motor with 1.15 service factor and furnished suitable for outdoor service. Open drip proof motors are not allowed. Motors shall be mounted on an adjustable base.", letter.Increment, "")
               .AddEntriesRow(condenser.ID, coilTubeMaterial, letter.Increment, "")
               .AddEntriesRow(condenser.ID, "The water distribution system shall provide a water flow rate of not less than 6 GPM over each square foot of unit face area to ensure proper flooding of the coil. The spray header shall be constructed of schedule 40 PVC pipe for corrosion resistance. All spray branches shall be removable and include a threaded end plug for cleaning. The water shall be distributed over the entire coil surface by precision molded ABS spray nozzles (1&deg; x ½&deg; orifice) with internal anti-sludge rings to eliminate clogging. Nozzles shall be threaded into spray header to provide easy removal for maintenance.", letter.Increment, "")
               .AddEntriesRow(condenser.ID, "Water recirculation pump shall be a close-coupled, bronze fitted, centrifugal type with mechanical seal, installed vertically at the factory to allow free drainage on shut down.  The pump motor shall be totally enclosed furnished suitable for outdoor service.", letter.Increment, "")
               .AddEntriesRow(condenser.ID, "The mist eliminators shall be constructed entirely of PVC that has been specially treated to resist ultra-violet light.  Assembled in easily handled sections, the eliminator blades shall be spaced on 1-inch centers and shall incorporate three changes in air direction to assure removal of entrained moisture from the discharge air stream. They shall have a hooked leaving edge to direct the discharge air away from the fans to minimize recirculation.", letter.Increment, "")
               If Me.SpecData.Condenser.AcousticAttenuatorsDischarge _
               Or Me.SpecData.Condenser.AcousticAttenuatorsIntake Then
                  .AddEntriesRow(condenser.ID, attenuators & " attenuators shall be included. Attenuators shall be provided by condenser manufacturer, shipped loose and field installed.", letter.Increment, "")
               End If

               waterTreatment = .NewEntriesRow
               With waterTreatment
                  .ParentID = condenser.ID
                  .EntryText = "The following provisions shall be factory installed as part of the water treatment system provided in the field:"
                  .Order = letter.Increment
               End With
               .AddEntriesRow(waterTreatment)

               .AddEntriesRow(waterTreatment.ID, "A 115 volt power receptacle shall be provided for a water treatment controller. The power shall be interlocked with the cooling so that chemicals are not pumped when cooling is off.", 0, "")
               .AddEntriesRow(waterTreatment.ID, "A ¾&quot; stub out line shall be installed so as to provide a means to connect the water system with the chemicals.", 1, "")
               .AddEntriesRow(condenser.ID, "Acceptable manufacturers of the evaporative condenser are Evapco, Baltimore Air Coil, and Spectrum. No other manufacturer’s will be considered.", letter.Increment, "")
               If Me.SpecData.Condenser.CondenserDesign.ToLower = "packaged system" Then
                  .AddEntriesRow(condenser.ID, "Condenser shall be integral with the unit. The unit will be completely piped, evacuated, wired, and tested at the factory.", letter.Increment, "")
               ElseIf Me.SpecData.Condenser.CondenserDesign.ToLower = "remote condenser" Then
                  .AddEntriesRow(condenser.ID, "Condenser shall be remote mounted with field piping by others. Fans shall be wired back to chiller control panel.", letter.Increment, "")
               End If
            End If

         End With
      End Sub

      Private Sub AddCondenserFan(ByVal partID As Integer)
         Dim letter As New Incrementer
         Dim fan As Outliner.Outline.EntriesRow
         Dim rainHood As String

         rainHood = String.Empty
         If Me.SpecData.Condenser.RainHood Then rainHood = " with rain hood"

         With Me.SpecOutliner.DataSource.Entries
            fan = .NewEntriesRow
            fan.ParentID = partID
            fan.Order = Me.numDotNum.Increment
            .AddEntriesRow(fan)

            If Me.SpecData.Condenser.CondenserType = "Prop fans" Then
               fan.EntryText = "Condenser Fans (Air-cooled)"
               .AddEntriesRow(fan.ID, "Provide direct drive propeller type with zinc plated chromate dipped blades.  Air shall discharge vertically to minimize noise generation and air recirculation.", letter.Num, "")
               .AddEntriesRow(fan.ID, "Fans shall be located within a formed venturi and be provided with a polyvinyl covered fan guard.", letter.Increment, "")
               .AddEntriesRow(fan.ID, "Fan motors shall be 3 phase, 1140 RPM, vertical, direct drive motors with permanently lubricated ball bearings and overload protection.", letter.Increment, "")
            Else
               fan.EntryText = "Condenser Fans (Air-cooled - Centrifugal Blowers)"
               .AddEntriesRow(fan.ID, "Fans shall have riveted blade construction with G-90 zinc coated steel sheet. Fan shall be capable of running at AMCA Class II operating conditions. Wheel shall be statically and dynamically balanced in accordance with 1989 ARI Guideline &quot;G&quot; and ANSI S2.19-1986. Fans shall be capable of operating up to a maximum temperature of 200&deg;F.", letter.Num, "")
               .AddEntriesRow(fan.ID, "Blower frame shall be welded steel angle with T-bar supports under bearings.  Frame and bearing supports shall be carbon steel with weather resistant finish.  Blower shall have cast iron pillow block ball bearings.", letter.Increment, "")
               .AddEntriesRow(fan.ID, "Drives shall consist of one fixed pitch sheave keyed to the fan shaft and another fixed pitch sheave keyed to the motor shaft.  Sheaves shall be cast iron, double grooved and statically balanced.", letter.Increment, "")
               .AddEntriesRow(fan.ID, "Motors shall be housed inside the condenser cabinet.  Motors shall be totally enclosed air over type motors.  Motors shall be 1750 rpm and of the highest available efficiency on standard motors available from the manufacturer. All motors to comply with industry standard specifications.", letter.Increment, "")
               .AddEntriesRow(fan.ID, "Condenser cabinet to consist of 16 ga. minimum sheet metal with " & Me.SpecData.Condenser.Discharge.ToLower & " discharge" & rainHood & ". Housing to enclose the condenser coil so there is no finned area exposed to the perimeter of the unit. Discharge outlets to have 1&quot; duct collar for field connection to exhaust ductwork.", letter.Increment, "")
            End If
         End With
      End Sub

      Private Sub AddRefrigerantCircuit(ByVal partID As Integer)
         Dim letter As New Incrementer
         Dim num As New Incrementer
         Dim refrigerant, provisions As Outliner.Outline.EntriesRow

         With Me.SpecOutliner.DataSource.Entries
            refrigerant = .NewEntriesRow
            With refrigerant
               .ParentID = partID
               .EntryText = "Refrigerant Circuit"
               .Order = Me.numDotNum.Increment
            End With
            .AddEntriesRow(refrigerant)

            provisions = .NewEntriesRow
            provisions.ParentID = refrigerant.ID
            .AddEntriesRow(provisions)

            .AddEntriesRow(refrigerant.ID, "Provide complete refrigerant circuits, factory supplied and piped.", letter.Num, "")
            provisions.EntryText = "Provide for each refrigerant circuit:"
            provisions.Order = letter.Increment
            .AddEntriesRow(provisions.ID, "Liquid line sight glass and moisture indicator.", num.Num, "")
            .AddEntriesRow(provisions.ID, "Charging valve.", num.Increment, "")
            .AddEntriesRow(provisions.ID, "Insulated suction line.", num.Increment, "")
            .AddEntriesRow(provisions.ID, "Discharge line check valve.", num.Increment, "")
            .AddEntriesRow(provisions.ID, "Compressor service valves.", num.Increment, "")

            If Me.SpecData.Refrigerant.Solenoid Then
               .AddEntriesRow(provisions.ID, "Liquid line solenoid valve.", num.Increment, "")
            End If
            If Me.SpecData.Refrigerant.FilterDrier Then
               .AddEntriesRow(provisions.ID, "Filter drier " & Me.SpecData.Refrigerant.FilterDrierType, num.Increment, "")
            End If
            If Me.optManager.GetExpansionValve.IsOption Then
               .AddEntriesRow(provisions.ID, "Expansion valve (" & Me.SpecData.Refrigerant.ExpansionValve & ")", num.Increment, "")
            End If
            If Me.SpecData.Refrigerant.PressureReliefHigh _
            Or Me.SpecData.Refrigerant.PressureReliefLow Then
               .AddEntriesRow(provisions.ID, "Pressure relief device.", num.Increment, "")
            End If

            If Me.SpecData.Refrigerant.SuctionAccumulators = "without heat exchanger" Then
               .AddEntriesRow(provisions.ID, "Suction accumulators without heat exchanger [Recommended for all low temp applications]", num.Increment, "")
            ElseIf Me.SpecData.Refrigerant.SuctionAccumulators = "with heat exchanger" Then
               .AddEntriesRow(provisions.ID, "Suction accumulators with heat exchanger [Recommended for all low temp applications]", num.Increment, "")
            End If

         End With
      End Sub

      Private Sub AddHazard(ByVal partID As Integer)
         Dim letter As New Incrementer
         Dim hazard As Outliner.Outline.EntriesRow

         With Me.SpecOutliner.DataSource.Entries
            If Me.SpecData.Hazard.Hazard Then
               Dim fins As String

               hazard = .NewEntriesRow
               With hazard
                  .ParentID = partID
                  .EntryText = "Corrosion Resistant Features"
                  .Order = Me.numDotNum.Increment
               End With
               .AddEntriesRow(hazard)

               If Me.SpecData.Hazard.CondenserFins = "Phenolic Coated" Then
                  fins = "Entire condenser assembly shall be coated with a baked phenolic corrosive resistant coating. Coating shall be applied by immersion process. Air dried spray applied phenolic coating will not be accepted. Coating shall be a minimum of 1.5 mils dry film thickness."
               Else
                  fins = "Construct condenser with " & Me.SpecData.Hazard.CondenserCasings.ToLower & " casings and " & Me.SpecData.Hazard.CondenserFins.ToLower & " fins."
               End If

               .AddEntriesRow(hazard.ID, "All cabinetry and structural base shall be of " & Me.SpecData.Hazard.StructuralBase.ToLower, letter.Num, "")
               .AddEntriesRow(hazard.ID, "Condenser shall be treated for corrosive environment. " & fins, letter.Increment, "")
               .AddEntriesRow(hazard.ID, "All wiring shall be run in liquid tight conduit with liquid tight connections.", letter.Increment, "")
               .AddEntriesRow(hazard.ID, "Control enclosure shall be " & Me.SpecData.Hazard.ControlEnclosure & ".", letter.Increment, "")
               .AddEntriesRow(hazard.ID, "All piping shall be finished with an air-dried phenolic coating after the piping assembly is complete.", letter.Increment, "")
            End If
         End With
      End Sub

      Private Sub AddAcoustic(ByVal partID As Integer)
         If Me.SpecData.Acoustic.Acoustic Then
            Dim letter As New Incrementer
            Dim acoustic As Outliner.Outline.EntriesRow
            Dim wrap, spring As String
            Dim fan, shroud As String

            If Me.SpecData.Acoustic.Compressors Then
               If Me.SpecData.Acoustic.CompressorCovering = "Compressor Wraps" Then
                  wrap = "Provide compressors with heavy duty sound attenuating compressor wraps. Wraps shall be made of industrial vinyl and shall have industrial grade Velcro for easier service access."
               ElseIf Me.SpecData.Acoustic.CompressorCovering = "Acoustically Lined Compressor House" Then
                  wrap = "Compressor house shall have walls and roof internally lined with acoustic insulation."
               Else
                  wrap = ""
               End If
               If Me.SpecData.Acoustic.CompressorSpringIsolator Then
                  'C
                  spring = "To minimize vibration noise, install compressors on spring isolators. Install suction and discharge vibration isolators at the piping connections to the compressors to allow for free movement in the piping."
               Else
                  spring = ""
               End If
            Else
               wrap = ""
               spring = ""
            End If


            If Me.SpecData.Acoustic.CondenserFans Then
               If Me.SpecData.Acoustic.CondenserFanType = "850 RPM" Then     '850 fan text
                  fan = "Provide 850 rpm condenser fans to minimize air discharge noise without reducing condenser capacity. "
               Else
                  fan = ""
               End If
               If Me.SpecData.Acoustic.CondenserShroud Then
                  shroud = "Install 18&quot; acoustic shroud around entire perimeter of unit."
               Else
                  shroud = ""
               End If
            End If

            With Me.SpecOutliner.DataSource.Entries
               acoustic = .NewEntriesRow
               With acoustic
                  .ParentID = partID
                  .EntryText = "Acoustic Treatment"
                  .Order = Me.numDotNum.Increment
               End With
               .AddEntriesRow(acoustic)

               If Me.SpecData.Acoustic.Compressors And _
               Me.SpecData.Acoustic.CompressorCovering <> "None" Then
                  .AddEntriesRow(acoustic.ID, wrap, letter.Num, "")
               End If
               If Me.SpecData.Acoustic.CondenserFans Then
                  .AddEntriesRow(acoustic.ID, fan & shroud, letter.Increment, "")
               End If
               If Me.SpecData.Acoustic.Compressors And _
               Me.SpecData.Acoustic.CompressorSpringIsolator Then
                  .AddEntriesRow(acoustic.ID, spring, letter.Increment, "")
               End If
            End With
         End If
      End Sub

      Private Sub AddPump(ByVal partID As Integer)
         Dim letter As New Incrementer
         Dim pump, requirements As Outliner.Outline.EntriesRow

         If Me.SpecData.Unit = "Water chiller" Then
            With Me.SpecOutliner.DataSource.Entries
               pump = .NewEntriesRow
               With pump
                  .ParentID = partID
                  .EntryText = "End Suction Pump"
                  .Order = Me.numDotNum.Increment
               End With
               .AddEntriesRow(pump)

               'A
               requirements = .NewEntriesRow
               With requirements
                  .ParentID = pump.ID
                  .EntryText = "General Requirements:"
                  .Order = letter.Num
               End With
               .AddEntriesRow(requirements)

               .AddEntriesRow(requirements.ID, "Balance: Rotating parts, statically dynamically.", 0, "")
               .AddEntriesRow(requirements.ID, "Construction: To permit servicing without breaking piping or motor connections.", 1, "")
               .AddEntriesRow(requirements.ID, "Pump Motors: Operate at 3500 RPM unless specified otherwise.", 2, "")
               .AddEntriesRow(requirements.ID, "Pump Connections: Flanged", 3, "")
               'B
               .AddEntriesRow(pump.ID, "Furnish and install pumps with capacities as specified herein.  Pumps shall be end suction type, single-stage, close coupled for installation in horizontal position, and capable of being serviced without distributing piping connections. Pump volute shall be Class 30 cast iron with integrally cast pedestal support. The impeller shall be cast bronze, enclosed type, dynamically balanced, keyed to the shaft and secured by a locking cap screw.", letter.Increment, "")
               .AddEntriesRow(pump.ID, "The liquid cavity shall be sealed off at the motor shaft by an internally-flushed mechanical seal with ceramic seal seat of at least 98 percent alumna oxide content and carbon seal ring, suitable for continuous operation at 225&deg;F. A replaceable bronze shaft sleeve shall completely cover the wetted area under the seal.", letter.Increment, "")
               .AddEntriesRow(pump.ID, "Pumps shall be rated for minimum of 175 PSI working pressure.  Casing shall have gauge ports at nozzles and vent and drain ports at top and bottom of casing.", letter.Increment, "")
               .AddEntriesRow(pump.ID, "Pump bearing housing assembly shall have heavy-duty regreasable ball bearings, replaceable without disturbing piping connections and have foot support at coupling end.", letter.Increment, "")
               .AddEntriesRow(pump.ID, "The motor shall meet NEMA specifications and shall be the size, voltage, and enclosure called for on the plans.  Pump and motor shall be factory aligned.", letter.Increment, "")
               .AddEntriesRow(pump.ID, "Provide access space around pumps for service.  Provide no less than minimum as recommended by pump manufacturer. Ensure pumps operate at specified system fluid temperatures without vapor binding and cavitation, are non-overloading in parallel or individual operation.", letter.Increment, "")
               .AddEntriesRow(pump.ID, "Pumps shall be manufactured by ITT Bell, Gossett, or Scot.", letter.Increment, "")
            End With
         End If

      End Sub

      Private Sub AddTripleDutyValve(ByVal partID As Integer)
         If Me.optManager.GetPumpControls.IsOption Then
            Dim valve, trim As Outliner.Outline.EntriesRow
            Dim letter As New Incrementer
            Dim pumpStrainer As String
            Dim pumpValve As String

            pumpStrainer = Me.SpecData.Pump.SuctionStrainer.ToLower
            pumpValve = Me.SpecData.Pump.SuctionTrim.ToLower

            With Me.SpecOutliner.DataSource.Entries
               valve = .NewEntriesRow
               With valve
                  .ParentID = partID
                  .EntryText = "Triple Duty Valve"
                  .Order = Me.numDotNum.Increment
               End With
               .AddEntriesRow(valve)

               .AddEntriesRow(valve.ID, "Furnish and install as specified, a valve designed to performs the functions of non-slam check valve, throttling valve, shutoff valve, and calibrated balancing valve.", letter.Num, "")
               .AddEntriesRow(valve.ID, "The valve shall be of heavy-duty cast iron construction with NPT connections per ANSI B1.20.1-83 suitable for 1745 psi working pressure for operating temperatures up to 250°F. The valve shall be fitted with a bronze seat, replaceable bronze disc with EPDM seat insert, brass stem, and chatter preventing stainless steel spring. The valve design shall permit re-packing under full system pressure.", letter.Increment, "")
               .AddEntriesRow(valve.ID, "Each valve shall be equipped with brass readout valves (with integral check valve) to facilitate taking differential pressure readings across the orifice for accurate system balance.", letter.Increment, "")
               .AddEntriesRow(valve.ID, "Manufacturer: The manufacturer shall be ITT Bell and Gossett.", letter.Increment, "")

               'Hydraulic Trim
               trim = .NewEntriesRow
               With trim
                  .ParentID = partID
                  .EntryText = "Hydraulic Trim"
                  .Order = Me.numDotNum.Increment
               End With
               .AddEntriesRow(trim)

               .AddEntriesRow(trim.ID, "On the suction side of the pump, install a " & pumpStrainer & " strainer, and a " & pumpValve & " for shut-off.", 0, "")
               .AddEntriesRow(trim.ID, "Manufacturer: The manufacturer shall be ITT Bell Gossett, Armstrong, Watts, Josam, or Owner approved equal.", 1, "")
            End With
         End If
      End Sub

      Private Sub AddAirSeparator(ByVal partID As Integer)
         Dim airSeparator As Outliner.Outline.EntriesRow

         If Me.optManager.GetPumpControls.IsOption _
         And Me.SpecData.Pump.AirSeperator Then
            With Me.SpecOutliner.DataSource.Entries
               airSeparator = .NewEntriesRow
               With airSeparator
                  .ParentID = partID
                  .EntryText = "Air Separator"
                  .Order = Me.numDotNum.Increment
               End With
               .AddEntriesRow(airSeparator)

               .AddEntriesRow(airSeparator.ID, "Horizontal " & Me.SpecData.Pump.AirSeperatorDesign.ToLower & " air separator designed to effectively separate free air in hydronic cooling system. The air separator shall be heavy duty cast iron designed to function satisfactorily at working pressures up to 175 psi and liquid temperatures up to 300&deg;F. The air separator shall have an integral weir designed to decelerate system flow to maximize air separation.", 0, "")
               .AddEntriesRow(airSeparator.ID, "The in-line air separator shall also assist in eliminating free air from the system by directing the air to an ancillary air vent attached to the air separator while reduced oxygenated water is circulated to the system.", 1, "")
               .AddEntriesRow(airSeparator.ID, "Manufacturer: ITT Bell and Gossett.", 2, "")
            End With
         End If
      End Sub

      Private Sub AddAirVent(ByVal partID As Integer)
         Dim vent As Outliner.Outline.EntriesRow

         If Me.optManager.GetPumpControls.IsOption _
         And Me.SpecData.Pump.AirSeperator Then
            With Me.SpecOutliner.DataSource.Entries
               vent = .NewEntriesRow
               With vent
                  .ParentID = partID
                  .EntryText = "Air Vent"
                  .Order = Me.numDotNum.Increment
               End With
               .AddEntriesRow(vent)

               .AddEntriesRow(vent.ID, "Non-modulating, high capacity, automatic type designed to purge free air from the system and provide positive shutoff at pressures up to 150 psig at a maximum temperature of 250&deg;F.", 0, "")
               .AddEntriesRow(vent.ID, "Vent shall be constructed of cast iron body and bonnet with stainless steel, brass, EPDM, and silicon rubber internal components.", 1, "")
            End With
         End If
      End Sub

      Private Sub AddExpansionTank(ByVal partID As Integer)
         Dim tank As Outliner.Outline.EntriesRow
         Dim letter As New Incrementer

         If Me.optManager.GetPumpControls.IsOption _
         And Me.SpecData.Pump.ExpansionTank Then
            With Me.SpecOutliner.DataSource.Entries
               tank = .NewEntriesRow
               With tank
                  .ParentID = partID
                  .EntryText = "Expansion Tank"
                  .Order = Me.numDotNum.Increment
               End With
               .AddEntriesRow(tank)

               .AddEntriesRow(tank.ID, "Size tank to be suitable for the total water volume of the entire system using normal engineering standards and practices. Tank shall be either in-line type where flow rate allows, or tangential design.", letter.Num, "")
               .AddEntriesRow(tank.ID, "Tank shall be constructed of carbon steel shell with a heavy duty butyl rubber diaphragm. The air charging connection shall be to the diaphragm. Tank shall be suitable for outdoor installations.", letter.Increment, "")
               .AddEntriesRow(tank.ID, "Maximum operating pressure of the tank shall be 125 psi and the maximum operating temperature shall be 240&deg;F.", letter.Increment, "")
               .AddEntriesRow(tank.ID, "Acceptable Manufacturer's: ITT Bell & Gosset, Ventrite, or approved equal.", letter.Increment, "")
            End With
         End If
      End Sub

      Private Sub AddControls(ByVal partID As Integer)
         Dim controls, panel, safety, operatingControls _
            As Outliner.Outline.EntriesRow
         Dim letter As New Incrementer
         Dim num As New Incrementer
         Dim disconnectSwitch As String = String.Empty

         If Me.SpecData.Controls.MoldedCaseDisconnectSwitch Then
            disconnectSwitch = "molded case disconnect switch, "
         End If

         With Me.SpecOutliner.DataSource.Entries
            controls = .NewEntriesRow
            With controls
               .ParentID = partID
               .Order = Me.numDotNum.Increment
            End With
            .AddEntriesRow(controls)

            panel = .NewEntriesRow
            panel.ParentID = controls.ID

            safety = .NewEntriesRow
            safety.ParentID = controls.ID

            operatingControls = .NewEntriesRow
            operatingControls.ParentID = controls.ID

            If Me.SpecData.Controls.ControlsType = "Electronic" Then
               controls.EntryText = "Controls"

               .AddEntriesRow(controls.ID, "Provide provisions for local control as specified herein, and provisions for remote start/stop capabilities and run status light as provided by other (Div.16). Locate on chiller, mount steel control panel with hinged access, containing starters, power and control wiring, " & disconnectSwitch & "factory wired with " & Me.SpecData.Controls.PowerConnection.ToLower & " power connection.", letter.Num, "")
               .AddEntriesRow(controls.ID, "For each compressor, provide across-the-line starter, non-recycling compressor overload, starter relay, and control power transformer.  Provide manual reset current overload protection.", letter.Increment, "")

               panel.EntryText = "Provide the following devices on a NEMA 34 control panel face:"
               panel.Order = letter.Increment
               .AddEntriesRow(panel)

               .AddEntriesRow(panel.ID, "Compressor run lights.", num.Num, "")
               .AddEntriesRow(panel.ID, "Off/Run/Pumpdown switch for each compressor.", num.Increment, "")
               .AddEntriesRow(panel.ID, "Control power fuse of circuit breaker.", num.Increment, "")
               .AddEntriesRow(panel.ID, Me.SpecData.Controls.CompressorLeadLagSwitch & " compressor lead-lag switch.", num.Increment, "")
               .AddEntriesRow(panel.ID, "Anti-short cycle timer per compressor.", num.Increment, "")
               .AddEntriesRow(panel.ID, "Phase monitor to monitor over/under voltage and phasing.", num.Increment, "")

               'D
               safety.EntryText = "Provide the following safety controls with indicating lights arranged so that operating any one will shut down machine and require manual reset:"
               safety.Order = letter.Increment
               .AddEntriesRow(safety)

               .AddEntriesRow(safety.ID, "Low chilled water temperature switch.", num.Zero, "")
               .AddEntriesRow(safety.ID, "High discharge pressure switch for each compressor.", num.Zero, "")
               .AddEntriesRow(safety.ID, "Low suction pressure switch for each compressor.", num.Increment, "")
               .AddEntriesRow(safety.ID, "Oil pressure switch.", num.Increment, "")
               .AddEntriesRow(safety.ID, "Flow switch in chilled water line.", num.Increment, "")

               'E
               operatingControls.Order = letter.Increment
               operatingControls.EntryText = "Provide the following operating controls:"
               .AddEntriesRow(operatingControls)

               .AddEntriesRow(operatingControls.ID, "Multi-step chilled water temperature controller, which cycles compressor and activated cylinder unloaders.", num.Zero, "")
               .AddEntriesRow(operatingControls.ID, "Five minute off timer prevents compressor from short cycling.", num.Increment, "")
               .AddEntriesRow(operatingControls.ID, "Periodic pumpout timer to pump down on chilled water flow and high evaporator refrigerant pressure.", num.Increment, "")
               .AddEntriesRow(operatingControls.ID, "Hot gas bypass sized for minimum compressor loading on each circuit.", num.Increment, "")
               .AddEntriesRow(operatingControls.ID, "Automatic start/stop controls for chilled water pump.", num.Increment, "")

               'F
               .AddEntriesRow(controls.ID, "Provide pre-piped gauge board with pressure gauges for suction and discharge refrigerant pressures and oil pressures.", letter.Increment, "")
               .AddEntriesRow(controls.ID, "Provide alarm package with test button and indicating lights for each circuit which indicate control circuit is energized and compressor is running and will sound an audible alarm and light an indicating light upon detection of compressor malfunction, low chilled water temperature, or evaporator water flow failure.", letter.Increment, "")
            Else
               Dim display As Outliner.Outline.EntriesRow

               controls.EntryText = "Controls (micro-controller)"

               .AddEntriesRow(controls.ID, "Provide provisions for local control as specified herein, and provisions for remote start/stop capabilities and run status light as provided by other (Div.16). Locate on chiller, mount steel control panel with hinged access, containing starters, power and control wiring, " & disconnectSwitch & "factory wired with " & Me.SpecData.Controls.PowerConnection.ToLower & " power connection.", letter.Num, "")
               .AddEntriesRow(controls.ID, "For each compressor, provide across-the-line starter, non-recycling compressor overload, starter relay, and control power transformer. Provide manual reset current overload protection.", letter.Increment, "")

               'C
               panel.EntryText = "Provide the following devices on a NEMA 3R control panel face:"
               panel.Order = letter.Increment
               .AddEntriesRow(panel)

               .AddEntriesRow(panel.ID, "Compressor run lights.", num.Zero, "")
               .AddEntriesRow(panel.ID, "Off/Run/Pumpdown switch for each compressor.", num.Increment, "")
               .AddEntriesRow(panel.ID, "Control power fuse fo circuit breaker.", num.Increment, "")
               .AddEntriesRow(panel.ID, "Unit Phase monitor to monitor over/under voltage and phasing.", num.Increment, "")

               'D
               safety.EntryText = "Provide the following safety controls with indicating lights arranged so that operating any one will shut down machine and require manual reset:"
               safety.Order = letter.Increment
               .AddEntriesRow(safety)

               .AddEntriesRow(safety.ID, "Low chilled water temperature switch.", num.Zero, "")
               .AddEntriesRow(safety.ID, "High discharge pressure switch for each compressor.", num.Increment, "")
               .AddEntriesRow(safety.ID, "Low suction pressure switch for each compressor.", num.Increment, "")
               .AddEntriesRow(safety.ID, "Oil pressure switch.", num.Increment, "")
               .AddEntriesRow(safety.ID, "Flow switch in chilled water line.", num.Increment, "")

               'E
               operatingControls.EntryText = "Provide the following operating controls:"
               operatingControls.Order = letter.Increment
               .AddEntriesRow(operatingControls)

               .AddEntriesRow(operatingControls.ID, "Periodic pumpout timer to pump down on chilled water flow and high evaporator refrigerant pressure.", num.Zero, "")
               .AddEntriesRow(operatingControls.ID, "Hot gas bypass sized for minimum compressor loading on each circuit.", num.Increment, "")
               .AddEntriesRow(operatingControls.ID, "Automatic start/stop controls for chilled water pump.", num.Increment, "")

               'F
               .AddEntriesRow(controls.ID, "The controller shall have all internal programming time sequences. Off-time sequences after compressors cycle off and time delays between compressor starts to limit in rush current.", letter.Increment, "")
               .AddEntriesRow(controls.ID, "Provide a microprocessor based DDC controller with a programmable face. The controller shall be capable of adjusting the setpoint at the face of the controller. Any other programming changes shall require the use of a security key and must utilize manufacturer certified software to access the program and make revisions.", letter.Increment, "")
               .AddEntriesRow(controls.ID, "The controller shall also control lead/lag capabilities by equal run time.  With the equal run time, on a call for cooling, the controller shall assess which compressor has had the least amount of run time and energize that machine.  For each additional call for cooling, the controller will do the same analysis for the remaining compressors. As the cooling cycles off, the controller will assess which compressor has the most run time and cycle that one off first.", letter.Increment, "")

               'I
               display = .NewEntriesRow
               With display
                  .ParentID = controls.ID
                  .EntryText = "The controller shall display the following information on the face of the controller:"
                  .Order = letter.Increment
               End With
               .AddEntriesRow(display)

               .AddEntriesRow(display.ID, "Supply and return water temperatures.", num.Zero, "")
               .AddEntriesRow(display.ID, "Current setpoints of the water temperatures.", num.Increment, "")

               'J
               .AddEntriesRow(controls.ID, "Provide pre-piped gauge board with pressure gauges for suction and discharge refrigerant pressures and oil pressures.", letter.Increment, "")
               .AddEntriesRow(controls.ID, "Provide alarm package with test button and indicating lights for each circuit which indicate control circuit is energized and compressor is running and will sound an audible alarm and light an indicating light upon detection of compressor malfunction, low chilled water temperature, or evaporator water flow failure.", letter.Increment, "")
            End If
         End With
      End Sub

      Private Sub AddWatersideEconomizer(ByVal partID As Integer)
         Dim economizer As Outliner.Outline.EntriesRow
         Dim letter As New Incrementer

         With Me.SpecOutliner.DataSource.Entries
            If Me.SpecData.Other.WatersideEconomizer _
            And Me.optManager.GetWatersideEconomizer.IsOption Then
               economizer = .NewEntriesRow
               With economizer
                  .ParentID = partID
                  .EntryText = "Waterside Economizer"
                  .Order = Me.numDotNum.Increment
               End With
               .AddEntriesRow(economizer)

               .AddEntriesRow(economizer.ID, "Unit shall be equipped with an integral waterside economizer. Unit shall be constructed and controlled in order to take advantage of ambient air to perform free cooling of the glycol solution. The condenser coil on the unit shall be built with an integral economizer coil circuited for water flow with 0.5&quot; tubes, 0.017&quot; tube thickness minimum with 0.025&quot; return bend thickness, and 0.006&quot; fin thickness.", letter.Zero, "")
               .AddEntriesRow(economizer.ID, "Unit shall be equipped with a 3-way modulating valve and ambient stat that will redirect the glycol solution flow when the ambient falls to a point that it can be used for free cooling. Ambients beginning at 7&deg;F below the leaving solution temp, the modulating valve shall redirect the flow through the economizer coil. At this point, the economizer coils shall serve as a pre-cooler coil to the chiller. The chiller will still be capable of mechanical cooling, but the heat removed in the economizer coil will allow the compressors to unload and stage off until the ambient falls to a point where the entire load is satisfied with the economizer coil.", letter.Increment, "")
               .AddEntriesRow(economizer.ID, "Fan cycle control shall be utilized to maintain the glycol temperature. Fans shall be cycled by an electronic controller monitoring the leaving solution temperature of the economizer coil.", letter.Increment, "")
            End If
         End With
      End Sub

      Private Sub AddFieldServices(ByVal partID As Integer)
         Dim letter As New Incrementer
         Dim services As Outliner.Outline.EntriesRow

         With Me.SpecOutliner.DataSource.Entries
            services = .NewEntriesRow
            With services
               .ParentID = partID
               .EntryText = "Manufacturer's Field Service"
               .Order = Me.numDotNum.Increment
            End With
            .AddEntriesRow(services)

            .AddEntriesRow(services.ID, "Prepare and start systems.", letter.Zero, "")
            .AddEntriesRow(services.ID, "Supply service of factory-trained representative for a period of one day to supervise testing, dehydration and charging of machine, start-up, and instruction on operation and maintenance to Owner.", letter.Increment, "")
            .AddEntriesRow(services.ID, "Supply initial charge of refrigerant and oil.", letter.Increment, "")
         End With
      End Sub

#End Region

   End Class

End Namespace