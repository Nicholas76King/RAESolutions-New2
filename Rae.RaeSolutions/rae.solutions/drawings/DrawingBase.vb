Option Strict Off

Imports System.Data
Imports System.Xml
Imports System.Xml.XmlReader
Imports System.Text
Imports System.Collections
Imports System.Reflection
Imports CNull = rae.ConvertNull
Imports System.Drawing
Imports System.Threading
Imports System.Collections.Generic
Imports rae.math.comparisons
Imports rae.math.Calculate
Imports rae.solutions.drawings.CompressorType
Imports rae.RaeSolutions.DataAccess
Imports rae.validation
Imports Path = System.IO.Path
Imports rae.solutions
Imports rae.utilities
Imports rae.RaeSolutions
Imports rae.RaeSolutions.Business
Imports rae.RaeSolutions.Business.Entities
Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms




Imports rae.DataAccess.EquipmentOptions
Imports System.Net.Mail
Imports rae.solutions.group

'Imports rae.RaeSolutions.Utility



Namespace rae.solutions.drawings

    Public Class DrawingBase

        Private service As i_drawing_service

#Region " External"

        'todo: is this ever used
        Sub New(ByVal type As DrawingType, ByVal targetUserGroup As user_group)
            validators = New validator_list()
            'Me.tool = DrawingToolFactory.Create()
            _type = type
            path = New DrawingPath(type, targetUserGroup)
            drawingConnection = New SharedConnectionFactory(drawingDbPath)
            equipConnection = New SharedConnectionFactory(Common.EquipmentPricingDbPath)
            rulesRepo = New DrawingRepo(drawingConnection)
            repo = New drawing_repository()
            service = New drawing_service()
        End Sub

        Sub New(ByVal type As DrawingType, ByVal unit As EquipmentItem, ByVal targetUserGroup As user_group)
            Me.New(type, targetUserGroup)

            initialize(unit)
        End Sub

#Region " Fields"

        Public XMLArr As Object
        Public OptionFieldString As String

#End Region

        Private _projectName, _drawnBy, _model, _divisionName, _prNumber, _fileNumber, _drawingNumber, _revisedBy, _revisionDate, stdCharge As String

#Region " Properties"

        Property validators As validator_list

        ReadOnly Property MasterDrawingPath As String
            Get
                Return path.ToMasterDrawing(DrawingName)
            End Get
        End Property

        Property ProjectName As String
            Get
                Return _projectName
            End Get
            Set(ByVal value As String)
                _projectName = value
            End Set
        End Property

        Property DrawnBy As String
            Get
                Return _drawnBy
            End Get
            Set(ByVal value As String)
                _drawnBy = value
            End Set
        End Property

        Property Model As String
            Get
                Return _model
            End Get
            Set(ByVal value As String)
                _model = value
            End Set
        End Property

        Property DivisionName As String
            Get
                Return _divisionName
            End Get
            Set(ByVal value As String)
                _divisionName = value
            End Set
        End Property

        Private _printDate As Date
        Property PrintDate As Date
            Get
                Return _printDate
            End Get
            Set(ByVal value As Date)
                _printDate = value
            End Set
        End Property

        Property PRNumber As String
            Get
                Return _prNumber
            End Get
            Set(ByVal value As String)
                _prNumber = value
            End Set
        End Property

        Property FileNumber As String
            Get
                Return _fileNumber
            End Get
            Set(ByVal value As String)
                _fileNumber = value
            End Set
        End Property

        Property DrawingNumber As String
            Get
                Return _drawingNumber
            End Get
            Set(ByVal value As String)
                _drawingNumber = value
            End Set
        End Property

        Property RevisedBy As String
            Get
                Return _revisedBy
            End Get
            Set(ByVal value As String)
                _revisedBy = value
            End Set
        End Property

        Property RevisionDate As String
            Get
                Return _revisionDate
            End Get
            Set(ByVal value As String)
                _revisionDate = value
            End Set
        End Property

        Property RevisionNumber As String
            Get
                Return _revisionNumber
            End Get
            Set(ByVal value As String)
                _revisionNumber = value
            End Set
        End Property

        Property RAESolutionsVersion As String
            Get
                Return _raesolutionsVersion
            End Get
            Set(ByVal value As String)
                _raesolutionsVersion = value
            End Set
        End Property

        Property EquipmentName As String
            Get
                Return _equipmentName
            End Get
            Set(ByVal value As String)
                _equipmentName = value
            End Set
        End Property

        Property EquipmentRevision As Integer
            Get
                Return _equipmentRevision
            End Get
            Set(ByVal value As Integer)
                _equipmentRevision = value
            End Set
        End Property

        Property Options As rae.RaeSolutions.Business.Entities.EquipmentOptionList
            Get
                Return _options
            End Get
            Set(ByVal value As rae.RaeSolutions.Business.Entities.EquipmentOptionList)
                _options = value
            End Set
        End Property

        ''' <summary>Drawing type (ex unit, piping, etc)</summary>
        Property Type As DrawingType
            Get
                Return _type
            End Get
            Set(ByVal value As DrawingType)
                _type = value
            End Set
        End Property

        ''' <summary>Master drawing name</summary>
        Property DrawingName As String
            Get
                Return _drawingName
            End Get
            Set(ByVal value As String)
                _drawingName = value
            End Set
        End Property

        ReadOnly Property BuildSucceeded As Boolean
            Get
                Return _buildSucceeded
            End Get
        End Property

        Property CompressorType As String
            Get
                Return _compressorType
            End Get
            Set(ByVal value As String)
                _compressorType = value
            End Set
        End Property


        Property CompModel As String
            Get
                Return _compModel
            End Get
            Set(ByVal value As String)
                _compModel = value
            End Set
        End Property


        Property CompOilDel As String
            Get
                Return _CompOilDel
            End Get
            Set(ByVal value As String)
                _CompOilDel = value
            End Set
        End Property

        Property NumRefrigerationCircuits As Single
            Get
                Return _numRefrigerationCircuits
            End Get
            Set(ByVal value As Single)
                _numRefrigerationCircuits = value
            End Set
        End Property

        Property NumElectricalCircuits As Single
            Get
                Return _numElectricalCircuits
            End Get
            Set(ByVal value As Single)
                _numElectricalCircuits = value
            End Set
        End Property

        Property NumCompressors As Single
            Get
                Return _numCompressors
            End Get
            Set(ByVal value As Single)
                _numCompressors = value
            End Set
        End Property

        Property MainPower As String
            Get
                Return _mainPower
            End Get
            Set(ByVal value As String)
                _mainPower = value
            End Set
        End Property

        Property DefrostType As String
            Get
                Return _defrostType
            End Get
            Set(ByVal value As String)
                _defrostType = value
            End Set
        End Property

        Property Voltage As String
            Get
                Return _voltage
            End Get
            Set(ByVal value As String)
                _voltage = value
            End Set
        End Property


#Region " Connection Size Properties"

        Property SuctionSizeCircuit1 As String
            Get
                Return _suctionSizeCircuit1
            End Get
            Set(ByVal value As String)
                _suctionSizeCircuit1 = value
            End Set
        End Property

        Property SuctionSizeCircuit2 As String
            Get
                Return _suctionSizeCircuit2
            End Get
            Set(ByVal value As String)
                _suctionSizeCircuit2 = value
            End Set
        End Property

        Property SuctionSizeCircuit3 As String
            Get
                Return _suctionSizeCircuit3
            End Get
            Set(ByVal value As String)
                _suctionSizeCircuit3 = value
            End Set
        End Property

        Property SuctionSizeCircuit4 As String
            Get
                Return _suctionSizeCircuit4
            End Get
            Set(ByVal value As String)
                _suctionSizeCircuit4 = value
            End Set
        End Property


        Property LiquidSizeCircuit1 As String
            Get
                Return _liquidSizeCircuit1
            End Get
            Set(ByVal value As String)
                _liquidSizeCircuit1 = value
            End Set
        End Property

        Property LiquidSizeCircuit2 As String
            Get
                Return _liquidSizeCircuit2
            End Get
            Set(ByVal value As String)
                _liquidSizeCircuit2 = value
            End Set
        End Property

        Property LiquidSizeCircuit3 As String
            Get
                Return _liquidSizeCircuit3
            End Get
            Set(ByVal value As String)
                _liquidSizeCircuit3 = value
            End Set
        End Property

        Property LiquidSizeCircuit4 As String
            Get
                Return _liquidSizeCircuit4
            End Get
            Set(ByVal value As String)
                _liquidSizeCircuit4 = value
            End Set
        End Property


        Property InletLineSize As String
            Get
                Return _inletLineSize
            End Get
            Set(ByVal value As String)
                _inletLineSize = value
            End Set
        End Property

        Property InletLineSize2 As String
            Get
                Return _inletLineSize2
            End Get
            Set(ByVal value As String)
                _inletLineSize2 = value
            End Set
        End Property


        Property OutletLineSize As String
            Get
                Return _outletLineSize
            End Get
            Set(ByVal value As String)
                _outletLineSize = value
            End Set
        End Property

        Property OutletLineSize2 As String
            Get
                Return _outletLineSize2
            End Get
            Set(ByVal value As String)
                _outletLineSize2 = value
            End Set
        End Property


        Property HotGasSizeCircuit1 As String
            Get
                Return _hotGasSizeCircuit1
            End Get
            Set(ByVal value As String)
                _hotGasSizeCircuit1 = value
            End Set
        End Property

        Property HotGasSizeCircuit2 As String
            Get
                Return _hotGasSizeCircuit2
            End Get
            Set(ByVal value As String)
                _hotGasSizeCircuit2 = value
            End Set
        End Property

        Property HotGasSizeCircuit3 As String
            Get
                Return _hotGasSizeCircuit3
            End Get
            Set(ByVal value As String)
                _hotGasSizeCircuit3 = value
            End Set
        End Property

        Property HotGasSizeCircuit4 As String
            Get
                Return _hotGasSizeCircuit4
            End Get
            Set(ByVal value As String)
                _hotGasSizeCircuit4 = value
            End Set
        End Property

#End Region

#Region " Calculated Electrical Data Properties"

        Property MaxFuseSizeCircuit1 As String
            Get
                Return _maxFuseSizeCircuit1
            End Get
            Set(ByVal value As String)
                _maxFuseSizeCircuit1 = value
            End Set
        End Property

        Property MCACircuit1 As String
            Get
                Return _mcaCircuit1
            End Get
            Set(ByVal value As String)
                _mcaCircuit1 = value
            End Set
        End Property

        Property RLACircuit1 As String
            Get
                Return _rlaCircuit1
            End Get
            Set(ByVal value As String)
                _rlaCircuit1 = value
            End Set
        End Property

        Property SCCRCircuit1 As String
            Get
                Return _sccrCircuit1
            End Get
            Set(ByVal value As String)
                _sccrCircuit1 = value
            End Set
        End Property

        Property MaxFuseSizeCircuit2 As String
            Get
                Return _maxFuseSizeCircuit2
            End Get
            Set(ByVal value As String)
                _maxFuseSizeCircuit2 = value
            End Set
        End Property

        Property MCACircuit2 As String
            Get
                Return _mcaCircuit2
            End Get
            Set(ByVal value As String)
                _mcaCircuit2 = value
            End Set
        End Property

        Property RLACircuit2 As String
            Get
                Return _rlaCircuit2
            End Get
            Set(ByVal value As String)
                _rlaCircuit2 = value
            End Set
        End Property

        Property SCCRCircuit2 As String
            Get
                Return _sccrCircuit2
            End Get
            Set(ByVal value As String)
                _sccrCircuit2 = value
            End Set
        End Property

        Property MaxFuseSizeCircuit3 As String
            Get
                Return _maxFuseSizeCircuit3
            End Get
            Set(ByVal value As String)
                _maxFuseSizeCircuit3 = value
            End Set
        End Property

        Property MCACircuit3 As String
            Get
                Return _mcaCircuit3
            End Get
            Set(ByVal value As String)
                _mcaCircuit3 = value
            End Set
        End Property

        Property RLACircuit3 As String
            Get
                Return _rlaCircuit3
            End Get
            Set(ByVal value As String)
                _rlaCircuit3 = value
            End Set
        End Property

        Property SCCRCircuit3 As String
            Get
                Return _sccrCircuit3
            End Get
            Set(ByVal value As String)
                _sccrCircuit3 = value
            End Set
        End Property

#End Region

#Region " Unit Cooler Electrical Info Properties"

        Property FanVoltage As String
            Get
                Return _fanVoltage
            End Get
            Set(ByVal value As String)
                _fanVoltage = value
            End Set
        End Property

        Property FanQuantity As String
            Get
                Return _fanQuantity
            End Get
            Set(ByVal value As String)
                _fanQuantity = value
            End Set
        End Property

        Property FanAmpEach As String
            Get
                Return _fanAmpEach
            End Get
            Set(ByVal value As String)
                _fanAmpEach = value
            End Set
        End Property

        ' todo: remove if unnecessary
        Property FanBlocks As String
            Get
                Return _fanBlocks
            End Get
            Set(ByVal value As String)
                _fanBlocks = value
            End Set
        End Property

        Property DefrostVoltage As String
            Get
                Return _defrostVoltage
            End Get
            Set(ByVal value As String)
                _defrostVoltage = value
            End Set
        End Property

        Property DefrostWatts As String
            Get
                Return _defrostWatts
            End Get
            Set(ByVal value As String)
                _defrostWatts = value
            End Set
        End Property

        Property DefrostAmps As String
            Get
                Return _defrostAmps
            End Get
            Set(ByVal value As String)
                _defrostAmps = value
            End Set
        End Property

        Property DefrostBlocks As String
            Get
                Return _defrostBlocks
            End Get
            Set(ByVal value As String)
                _defrostBlocks = value
            End Set
        End Property

#End Region

#End Region

#Region " Methods"
        Private Function addRefrigerantIndicator(ByVal model As String, ByVal refrigerant As String) As String
            Dim refrigerantIndicator As String
            Select Case refrigerant
                Case "R22" : refrigerantIndicator = "2"
                Case "R404a" : refrigerantIndicator = "4"
                Case "R507" : refrigerantIndicator = "7"
                Case Else : refrigerantIndicator = "0"
            End Select

            Dim baseIndex = model.IndexOf("Base")
            If baseIndex = -1 Then _
               baseIndex = 0
            Dim refrigerantIndicatorIndex = model.IndexOf("0", startIndex:=baseIndex)
            model = model.Remove(refrigerantIndicatorIndex, 1)
            model = model.Insert(refrigerantIndicatorIndex, refrigerantIndicator)

            Return model
        End Function


        'Sub CloseDrawing()
        '   tool.CloseDrawing()
        '   If tool.dtxErrorMessage <> "1000:Ok" Then
        '      Throw New Exception("Unable to close drawing: " & tool.dtxErrorMessage)
        '   End If
        'End Sub

        '      Function OpenDrawing(ByVal masterDrawingName As String) As String
        '         On Error GoTo Err_Open_Drawing

        '         'DTx.UnlockProduct("L3T4S0DB2004") '2004
        '         tool.UnlockProduct("L3T4SG7Y6D0") '2007

        '         Dim handle As Integer
        '         tool.LoadDrawing(handle, path.ToMasterDrawing(masterDrawingName), "")

        '         If tool.dtxErrorMessage = "1000:Ok" Then
        '            OpenDrawing = "OK"
        '         Else
        '            CloseDrawing()
        '            OpenDrawing = "_FAILED"
        '         End If

        '         Exit Function

        'Err_Open_Drawing:
        '         CloseDrawing()
        '         Dim sMsg_Open_Drawing As String
        '         sMsg_Open_Drawing = "Module:  mod_Functions.vb" & vbCrLf & _
        '                             "Procedure:  Open_Drawing" & vbCrLf

        '         Select Case Err.Number
        '            Case 0
        '               sMsg_Open_Drawing = sMsg_Open_Drawing & "Description: Unable to open drawing. ( " & path.ToMasterDrawing(masterDrawingName) & " )" & vbCrLf
        '            Case Else
        '               sMsg_Open_Drawing = sMsg_Open_Drawing & "Description: " & Err.Description & vbCrLf
        '         End Select

        '         sMsg_Open_Drawing = sMsg_Open_Drawing & "NOTE: sDrawingName = " & masterDrawingName & ", csDrawingPath = " & path.MasterFolder

        '         log(sMsg_Open_Drawing)
        '         OpenDrawing = "_FAILED"
        '      End Function

        'Sub save(ByVal file_path As String)
        '   pipingNames = New RefrigerantPipingDrawingNames(Model, Options)
        '   Do
        '      _buildSucceeded = setDrawing()
        '      If BuildSucceeded Then
        '         If count = 1 Then
        '            saveDrawing(file_path)
        '         End If
        '      End If
        '   Loop While hasAnotherDrawing

        '   CloseDrawing()
        '   drawingConnection.Close()
        '   equipConnection.Close()
        'End Sub

        ''' <summary>Show the drawing</summary>
        Function Show(ByRef returnDrawingNames As List(Of String), ByVal openDrawing As Boolean, Optional ByVal printDrawing As Boolean = False, Optional ByVal pdf As Boolean = False) As Boolean
            Dim succeeded = False

            returnDrawingNames = New List(Of String)


            pipingNames = New RefrigerantPipingDrawingNames(Model, Options)
            Do
                Dim tempDrawingName As String = ""

                Dim rightHanded As Boolean = Options.Contains("RH02")

                If pdf Then
                    openDrawing = False
                    Me._buildSucceeded = setDrawing(openDrawing:=openDrawing, returnDrawingName:=tempDrawingName, isRightHanded:=rightHanded, pdf:=True)
                    If BuildSucceeded Then
                        succeeded = True
                        returnDrawingNames.Add(tempDrawingName)
                    Else
                        succeeded = False
                    End If
                    Dim dxfToPDf As New DrawingService.WebService2
                    Dim pdf64 As String = dxfToPDf.dxfToPDF(System.Convert.ToBase64String(File.ReadAllBytes(tempDrawingName)))
                    If String.IsNullOrEmpty(pdf64) Then
                        MessageBox.Show("Error Generating PDF Drawing")
                    Else
                        Dim pdfBytes As Byte() = System.Convert.FromBase64String(pdf64)
                        Dim pdfFileName As String = tempDrawingName.Replace(".dxf", ".pdf")
                        File.WriteAllBytes(pdfFileName, pdfBytes)
                        'Thread.Sleep(5000)
                        Dim p As Process = New Process()
                        Dim psi As ProcessStartInfo = New ProcessStartInfo()
                        'psi.CreateNoWindow = True
                        psi.WindowStyle = ProcessWindowStyle.Hidden
                        psi.Verb = "print"
                        'psi.Verb = "open"
                        psi.FileName = pdfFileName
                        p.StartInfo = psi
                        p.Start()
                    End If
                Else
                    Me._buildSucceeded = setDrawing(openDrawing:=openDrawing, returnDrawingName:=tempDrawingName, isRightHanded:=rightHanded)
                    If BuildSucceeded Then
                        succeeded = True
                        returnDrawingNames.Add(tempDrawingName)
                    Else
                        succeeded = False
                    End If
                End If
            Loop While hasAnotherDrawing

            'CloseDrawing()
            drawingConnection.Close()
            equipConnection.Close()

            Return succeeded
        End Function

        ''' <summary>Adds an option field column to InputData table in DrawingData.mdb</summary>
        Sub AddOptionField(ByVal FieldName As String, Optional ByVal DefaultValue As String = "   ")
            Dim con = drawingConnection.Create
            Dim cmd = con.CreateCommand

            If con.State <> ConnectionState.Open Then con.Open()

            ' Add option field to InputData table...
            cmd.CommandText = "ALTER TABLE InputData " & _
                              "ADD COLUMN [" & FieldName & "] varchar(255)"
            cmd.ExecuteNonQuery()
            ' Update new field with default value...
            cmd.CommandText = "UPDATE InputData SET [" & FieldName & "] = '" & DefaultValue & "'"
            cmd.ExecuteNonQuery()

            If Trim(OptionFieldString) > "" Then
                OptionFieldString = OptionFieldString & ", "
            End If
            OptionFieldString = OptionFieldString & FieldName
        End Sub

        ' ''' <summary>Create XML file from drawing</summary>
        ' ''' <param name="drawingFilePath">Full path to drawing file</param>
        'Sub CreateXMLFromDrawing(ByVal drawingFilePath As String)
        '   tool.XMLReport(drawingFilePath & ".xml", _
        '      DTXDWG.ExportXML.DO_NOT_EXPORT, DTXDWG.ExportXML.DO_NOT_EXPORT, _
        '      DTXDWG.ExportXML.DO_NOT_EXPORT, DTXDWG.ExportXML.EXPORT, _
        '      DTXDWG.ExportXML.DO_NOT_EXPORT, DTXDWG.ExportXML.DO_NOT_EXPORT, _
        '      DTXDWG.ExportXML.DO_NOT_EXPORT, DTXDWG.ExportXML.EXPORT)
        'End Sub

        ''' <summary>Read xml file</summary>
        ''' <param name="XML_File_Path"></param>
        ''' <param name="OutputType"></param>
        Function ReadXML(ByVal filePath As String, Optional ByVal OutputType As DTXDWG.XMLDataToGet = DTXDWG.XMLDataToGet.CONSOLE_OUTPUT_ONLY) As Array
            Dim strRdr As New System.IO.StringReader(filePath & ".xml")
            Dim rd As XmlReader = XmlReader.Create(filePath & ".xml")

            Dim HandleText As String = ""
            Dim LayerList(999) As String
            Dim InputTxtArray(9999, 1) As String
            Dim ArrayInput As Integer = 0
            Dim LayerInput As Integer = 0

            ReadXML = Nothing

            If OutputType = DTXDWG.XMLDataToGet.CONSOLE_OUTPUT_ONLY Then

                Console.WriteLine("Layers")

                While rd.Read

                    Select Case rd.NodeType

                        Case XmlNodeType.Element

                            If rd.HasAttributes And Trim(rd.Name) = "LayerName" Then
                                LayerList(LayerInput) = rd.Item(0)
                                Console.WriteLine("Layer: " & rd.Item(0))
                                LayerInput = LayerInput + 1
                            ElseIf HandleText = "GetHandle" And rd.Name = "Handle" Then
                                HandleText = "Handle"
                            End If

                            'If Not rd.HasAttributes Then
                            '   Console.WriteLine(Space(rd.Depth * 4) & String.Format("<{0}>", rd.Name) & ControlChars.NewLine)
                            'Else
                            '   Console.WriteLine(Space(rd.Depth * 4) & String.Format("<{0}>", rd.Name & " name=" & rd.Item(0)) & ControlChars.NewLine)
                            'End If

                        Case XmlNodeType.Text

                            If rd.Value Like "i_*" Then
                                InputTxtArray(ArrayInput, 0) = rd.Value
                                HandleText = "GetHandle"
                            End If

                            If HandleText = "Handle" Then
                                InputTxtArray(ArrayInput, 1) = rd.Value
                                HandleText = ""
                                Console.WriteLine("InputText: " & InputTxtArray(ArrayInput, 0) & "  handle=" & InputTxtArray(ArrayInput, 1))
                                ArrayInput = ArrayInput + 1
                            End If

                            'Console.WriteLine(Space(rd.Depth * 4) & (rd.Value) & ControlChars.NewLine)

                            'Case XmlNodeType.CDATA

                            '   Console.WriteLine(Space(rd.Depth * 4) & String.Format("<![CDATA[{0}]]>", rd.Value) & ControlChars.NewLine)

                            'Case XmlNodeType.ProcessingInstruction

                            '   Console.WriteLine(Space(rd.Depth * 4) & String.Format("<?{0} {1}?>", rd.Name, rd.Value) & ControlChars.NewLine)

                            'Case XmlNodeType.Comment

                            '   Console.WriteLine(Space(rd.Depth * 4) & String.Format("<!--{0}-->", rd.Value) & ControlChars.NewLine)

                            'Case XmlNodeType.XmlDeclaration

                            '   Console.WriteLine(Space(rd.Depth * 4) & String.Format("<?xml version='1.0'?>") & ControlChars.NewLine)

                            'Case XmlNodeType.Document

                            'Case XmlNodeType.DocumentType

                            '   Console.WriteLine(Space(rd.Depth * 4) & String.Format("<!DOCTYPE {0} [{1}]", rd.Name, rd.Value) & ControlChars.NewLine)

                            'Case XmlNodeType.EntityReference

                            '   Console.WriteLine(Space(rd.Depth * 4) & String.Format(rd.Name) & ControlChars.NewLine)

                            'Case XmlNodeType.EndElement

                            '   Console.WriteLine(Space(rd.Depth * 4) & String.Format("</{0}>", rd.Name) & ControlChars.NewLine)

                    End Select

                End While

            ElseIf OutputType = DTXDWG.XMLDataToGet.LAYER_NAMES Then

                While rd.Read

                    If rd.NodeType = XmlNodeType.Element Then

                        If rd.HasAttributes And Trim(rd.Name) = "LayerName" Then
                            LayerList(LayerInput) = rd.Item(0)
                            Console.WriteLine("Layer: " & rd.Item(0))
                            LayerInput = LayerInput + 1
                        ElseIf HandleText = "GetHandle" And rd.Name = "Handle" Then
                            HandleText = "Handle"
                        End If

                    End If

                End While

                ReadXML = LayerList

            ElseIf OutputType = DTXDWG.XMLDataToGet.INPUT_TEXT_2DARRAY Then

                While rd.Read

                    Select Case rd.NodeType

                        Case XmlNodeType.Element
                            If HandleText = "GetHandle" And rd.Name = "Handle" Then
                                HandleText = "Handle"
                            End If

                        Case XmlNodeType.Text
                            If rd.Value Like "i_*" Then
                                InputTxtArray(ArrayInput, 0) = rd.Value
                                HandleText = "GetHandle"
                            End If

                            If HandleText = "Handle" Then
                                InputTxtArray(ArrayInput, 1) = rd.Value
                                HandleText = ""
                                Console.WriteLine("InputText: " & InputTxtArray(ArrayInput, 0) & "  handle=" & InputTxtArray(ArrayInput, 1))
                                ArrayInput = ArrayInput + 1
                            End If
                    End Select
                End While
                ReadXML = InputTxtArray
            End If

            rd.Close()
        End Function

#End Region

#End Region

#Region "Internal"

#Region " Fields"
        Friend repo As i_drawing_repository
        Private rulesRepo As DrawingRepo
        Protected unit As EquipmentItem
        'Protected tool As DToolsXDWG.CdtxDrawing
        Private drawingDbPath As String = Common.DrawingDataDbPath
        Private path As DrawingPath
        Private savedToFilePath As String
        Private pipingNames As RefrigerantPipingDrawingNames
        Private count As Integer
        ' True if there is another drawing to show
        Protected hasAnotherDrawing As Boolean
        Private drawingConnection As SharedConnectionFactory
        Private equipConnection As SharedConnectionFactory

        Private _suctionSizeCircuit1, _liquidSizeCircuit1, _inletLineSize, _outletLineSize, _hotGasSizeCircuit1 As String
        Private _suctionSizeCircuit2, _liquidSizeCircuit2, _inletLineSize2, _outletLineSize2, _hotGasSizeCircuit2 As String
        Private _suctionSizeCircuit3, _liquidSizeCircuit3, _hotGasSizeCircuit3 As String
        Private _suctionSizeCircuit4, _liquidSizeCircuit4, _hotGasSizeCircuit4 As String
        Private _voltage, _defrostType, _mainPower As String
        Private _numCompressors, _numElectricalCircuits, _numRefrigerationCircuits As Single

        Protected _buildSucceeded As Boolean
        Private _type As DrawingType
        Private _options As rae.RaeSolutions.Business.Entities.EquipmentOptionList
        Private _equipmentRevision As Single
        Private _compressorType, _drawingName, _equipmentName, _raesolutionsVersion, _revisionNumber, _compModel, _CompOilDel As String
        Private _maxFuseSizeCircuit1, _mcaCircuit1, _rlaCircuit1, _sccrCircuit1 As String
        Private _maxFuseSizeCircuit2, _rlaCircuit2, _mcaCircuit2, _sccrCircuit2 As String
        Private _maxFuseSizeCircuit3, _rlaCircuit3, _mcaCircuit3, _sccrCircuit3 As String
        Private _fanBlocks, _fanAmpEach, _fanQuantity, _fanVoltage As String
        Private _defrostBlocks, _defrostAmps, _defrostWatts, _defrostVoltage As String

#End Region

#Region " Methods"

        Private Sub initialize(ByVal unit As EquipmentItem)
            Me.unit = unit
            '    MsgBox(drawingDbPath)
            ' format model
            If unit.series Like "PFC*" OrElse unit.series Like "RAC*" Then
                Model = unit.series & "-" & unit.model_without_series
            ElseIf is_unit_cooler(unit.model) Then
                Model = unit.series & unit.model_without_series
            Else
                Model = unit.model
                If unit.series Like "3*" Then
                    Dim chiller = CType(unit, chiller_equipment)
                    Model = New ChillerModel(chiller).Dash
                ElseIf unit.series Like "PP*" Then
                    Model = New PumpPackageModel(Model, unit.options).Dash
                End If
            End If

            Me.DivisionName = unit.division.ToString
            If Me.DivisionName = "CRI" Then Me.DivisionName = "Century"
            Me.PRNumber = unit.ProjectManager.Project.ReleaseNum.ToString
            If Me.PRNumber = "" Then Me.PRNumber = "NA"
            Me.Options = unit.options
            Me.DrawnBy = unit.metadata.Author
            Me.EquipmentName = unit.name
            Me.EquipmentRevision = unit.revision
            Me.MainPower = unit.common_specs.UnitVoltage.ToString
            Me.Voltage = unit.common_specs.UnitVoltage.ToString
            Me.ProjectName = unit.ProjectManager.Project.name

            Me.PrintDate = Today.ToShortDateString
            Me.RAESolutionsVersion = My.Application.Info.Version.ToString

            Me.MaxFuseSizeCircuit1 = "0"
            Me.MaxFuseSizeCircuit2 = "0"
            Me.MaxFuseSizeCircuit3 = "0"
            Me.MCACircuit1 = "0"
            Me.MCACircuit2 = "0"
            Me.MCACircuit3 = "0"

            Me.FileNumber = "NA"
            Me.DrawingNumber = "NA"
            Me.RevisedBy = "NA"
            Me.RevisionDate = "NA"
            Me.RevisionNumber = "NA"
            Me.RLACircuit1 = "NA"
            Me.RLACircuit2 = "NA"
            Me.RLACircuit3 = "NA"
            Me.SCCRCircuit1 = "NA"
            Me.SCCRCircuit2 = "NA"
            Me.SCCRCircuit3 = "NA"


            Me.CompModel = EquipmentOptionsAgent.OptionsDA.GetCompressorModelDefault(unit.series, unit.model_without_series)

            Me.CompOilDel = EquipmentOptionsAgent.OptionsDA.GetCompOilDel(Me.CompModel)


        End Sub


        Protected Function generateUniqueDrawingName() As String
            Dim name = Type.ToString()
            Dim nameIsNotUnique = True
            Dim i = 0

            Dim fileName, filePath As String
            Do
                i += 1
                'Piping1.dwg
                fileName = name & i.ToString & ".dxf"
                'C:\Program Files\RAESolutions\Drawings\Edit Drawings\Piping\Piping1.dxf
                filePath = path.To(fileName).In(path.EditFolder)
                nameIsNotUnique = System.IO.File.Exists(filePath)
            Loop While (nameIsNotUnique)

            Return fileName
        End Function


        ''' <summary>
        ''' Set drawing parameters (layers, text handles, name)
        ''' </summary>
        ''' <param name="progressBar"></param>
        ''' <param name="updateLabel"></param>
        ''' <returns>True if succeeds; else false</returns>
        Protected Function setDrawing(Optional ByVal progressBar As Object = Nothing, _
                                      Optional ByVal updateLabel As Object = Nothing, Optional ByVal openDrawing As Boolean = False, _
                                      Optional ByRef returnDrawingName As String = "", Optional ByVal isRightHanded As Boolean = False, Optional ByVal pdf As Boolean = False) As Boolean
            If Type = DrawingType.RefrigerantPiping _
            AndAlso pipingNames.Count = 0 Then _
               Return False
            setDrawing = False


            Dim tTime As DateTime = Now

            UpdateForm(progressBar, 5, updateLabel, "Opening drawing...")

            'DrawingName = setDrawingName(Model, Type)

            If Model.ToUpper.StartsWith("NS") AndAlso Type = DrawingType.Unit Then
                If isRightHanded Then
                    ' Special exception for left handed N series units.
                    DrawingName = setDrawingName(Model & "-RH", Type)
                Else
                    DrawingName = setDrawingName(Model, Type)
                End If
            Else
                DrawingName = setDrawingName(Model, Type)
            End If

            UpdateForm(progressBar, 5, updateLabel, "Searching for drawing options...")


            ' wait until model has been used by anything that needs it before modifying it
            If unit.type = EquipmentType.UnitCooler Then
                Model = CType(unit, unit_cooler).model_with_refrigerant
            End If


            Dim onLayers As ArrayList
            Dim offLayers As ArrayList



            Dim drawing = New rae.Io.FileLocation(path.ToMasterDrawing(DrawingName))

            Dim layersInDrawing() As String = LayerManipulator.ExtractDXFLayerList(drawing.FilePath)




            getOnAndOffDrawingLayers(onLayers, offLayers, layersInDrawing)

            Dim fSec = DateDiff(DateInterval.Second, Now, tTime)

            Dim dims As New Hashtable(StringComparer.OrdinalIgnoreCase)
            dims = getDrawingText(Model, drawing.FilePath)


            UpdateForm(progressBar, 5, updateLabel, "Generating drawing...")

            savedToFilePath = path.To(generateUniqueDrawingName()).In(path.EditFolder)

            UpdateForm(progressBar, 5, updateLabel, "Saving drawing...")




            '  Beep()

            LayerManipulator.ManipulateDXF(drawing.FilePath, savedToFilePath, onLayers.ToArray(GetType(String)), offLayers.ToArray(GetType(String)), dims)

            UpdateForm(progressBar, 5, updateLabel, "Opening new drawing...")

            returnDrawingName = savedToFilePath

            If pdf Then
                '''''''''''' moved to setDrawing()
                'Dim p1 As Process = New Process()
                'Dim psi1 As ProcessStartInfo = New ProcessStartInfo()
                'psi1.CreateNoWindow = True
                'psi1.Verb = "print"
                'psi1.FileName = returnDrawingName
                'p1.StartInfo = psi1
                'p1.Start()
            Else
                Dim p As Process = New Process()
                Dim psi As ProcessStartInfo = New ProcessStartInfo()
                psi.CreateNoWindow = True
                psi.Verb = "Open"
                psi.FileName = returnDrawingName
                p.StartInfo = psi
                p.Start()
            End If

            'If openDrawing Then
            '    '''''''' works in libreoffice
            '    Dim p1 As Process = New Process()
            '    Dim psi1 As ProcessStartInfo = New ProcessStartInfo()
            '    psi1.CreateNoWindow = True
            '    psi1.Verb = "print"
            '    psi1.FileName = returnDrawingName
            '    p1.StartInfo = psi1
            '    p1.Start()
            'End If



            Return True


        End Function

        ''' <summary>Insert text labels and handles into repository</summary>
        Private Sub deleteAllTextThenInsert(ByVal fileName As String)
            ' Dim text = shorten(labelsAndHandlesXml)
            Dim text() As LayerManipulator.HandleList

            text = LayerManipulator.ExtractDXFTextHandles(fileName)


            rulesRepo.DeleteText()
            rulesRepo.InsertText(text)
        End Sub





        Private Sub setTextHandles(ByVal drawingFilePath As String)
            'XMLArr = ReadXML(drawingFilePath, DTXDWG.XMLDataToGet.INPUT_TEXT_2DARRAY)

            'If IsArray(XMLArr) = False Then
            'MsgBox("Information not found.")
            'Exit Sub
            'Else
            deleteAllTextThenInsert(drawingFilePath)
            'End If
        End Sub




        Protected Function getDrawingText(ByVal model As String, ByVal drawingFilePath As String) As Hashtable


            setTextHandles(drawingFilePath)


            Dim returnHT As New Hashtable(StringComparer.OrdinalIgnoreCase)

            Dim con = drawingConnection.Create()

            Dim sql = "SELECT * from [GlobalInputNames] " & _
                      "WHERE DrawingType = '_ALL' " & _
                      "OR DrawingType = '" & getGeneralDrawing(Type) & "'"
            Dim com = con.CreateCommand() : com.CommandText = sql

            Dim rdr, rdr2 As IDataReader
            Try
                If con.State <> ConnectionState.Open Then con.Open()
                rdr = com.ExecuteReader()
                While rdr.Read()
                    If Not IsDBNull(rdr("InfoRequired")) Then
                        Dim com2 = con.CreateCommand()
                        com2.CommandText = "SELECT TextHandle FROM TextInputs " & _
                                           "WHERE TextInput = '" & Trim(rdr("InfoRequired")) & "'"
                        rdr2 = com2.ExecuteReader
                        If rdr2.Read Then

                            Dim dText As UpdateTextType = QualifyDrawingText(Me.DrawingName, rdr2("TextHandle"), rdr("InfoRequired"))
                            returnHT(dText.textToReplace) = dText.inputValue

                        End If
                    End If
                End While

                getDrawingText = returnHT

            Finally
                If rdr IsNot Nothing Then rdr.Close()
                If rdr2 IsNot Nothing Then rdr2.Close()



            End Try
        End Function





        Private Structure UpdateTextType
            Public handle As String
            Public textToReplace As String
            Public inputValue As String
        End Structure



        Private Function QualifyDrawingText(ByVal drawingName As String, ByVal handle As String, ByVal field As String) As UpdateTextType

            QualifyDrawingText = New UpdateTextType

            Dim connection = drawingConnection.Create()
            Dim command = connection.CreateCommand()
            Dim reader As IDataReader
            If connection.State <> ConnectionState.Open Then connection.Open()

            Dim conjunction = "OR"
            Dim text As String = " "

            ' Text value is linked directly to a field value...
            If field <> "_NA" And Trim(field) > "" Then
                ' todo: update text really only takes in properties, not all the checks that getInputValue makes (layers, options, etc)
                QualifyDrawingText.inputValue = GetInputValue(field, True)
                QualifyDrawingText.handle = handle
                QualifyDrawingText.textToReplace = "I_" & field
            Else
                ' See if any qualification criteria exist
                ' if so see if the criteria is satisfied by the current parameters
                Dim cmdQualifiers As IDbCommand = connection.CreateCommand
                Dim rdQualifiers As IDataReader
                'cmdQualifiers.Connection = udtMyConn
                cmdQualifiers.CommandText = "SELECT * FROM [TextRules] " & _
                                             "WHERE [DrawingName] = '" & drawingName & "' " & _
                                               "AND [Handle] = '" & handle & "' " & _
                                          "ORDER BY [Position]"
                rdQualifiers = cmdQualifiers.ExecuteReader
                Dim CriteriaSatisfied As Boolean = True
                While rdQualifiers.Read


                    If CriteriaSatisfied = False Then

                        ' If criteria is NOT satisfied then we will
                        ' look until we find an OR oconjuncture for
                        ' Conjunction - if Conjunction is AND then
                        ' we can skip because we have already determined
                        ' this series of criteriais not satisfied.
                        ' If Conjunction is END the we can exit 
                        ' reader...
                        If conjunction = "OR" Then

                            ' Set TmpValue variable...
                            text = rdQualifiers("InputValue")

                            ' This is a new set of criteria so we can
                            ' continue and reset CriteriaSatisfied...
                            CriteriaSatisfied = True

                            If rdQualifiers("Qualifier") <> "_ALL" Then

                                Try
                                    command.CommandText = "SELECT [" & Replace(rdQualifiers("Qualifier"), "'", "") & "] from InputData "
                                    reader = command.ExecuteReader
                                    If reader.Read() Then
                                        CriteriaSatisfied = isQualified(GetInputValue(rdQualifiers("Qualifier"), True), rdQualifiers("Value"), rdQualifiers("Operator"))
                                    End If
                                    reader.Close()

                                Catch tmpexception As DataException
                                    ' Reference field does not exist (set
                                    ' criteria satisfied as follows)...
                                    If rdQualifiers("Value") = "False" And rdQualifiers("Operator") = "=" Then
                                        CriteriaSatisfied = True
                                    ElseIf rdQualifiers("Value") = "True" And rdQualifiers("Operator") = "<>" Then
                                        CriteriaSatisfied = True
                                    Else
                                        CriteriaSatisfied = False
                                    End If

                                End Try

                            End If

                        ElseIf conjunction = "END" Then
                            ' This is the last criteria so we can exit....
                            Exit While
                        End If

                        ' Set Conjucture...
                        conjunction = rdQualifiers("Conjunction")

                    Else

                        ' Criteria is currently satisfied.  If this
                        ' is Position #1 then we need to see if it
                        ' meets the qualification criteria. If so,
                        ' we need to check the conjucture in the
                        ' Conjunction field - if it is AND then
                        ' we'll need to check the next Position rule
                        ' as well and continue until we find an
                        ' OR or END Conjunction or until the criteria
                        ' is not met in which case we'll search for
                        ' an OR criteria above...
                        If Val(rdQualifiers("Position")) = 1 Or conjunction = "AND" Then

                            ' Set TmpValue variable...
                            text = rdQualifiers("InputValue")

                            If rdQualifiers("Qualifier") = "_ALL" Then
                                CriteriaSatisfied = True
                            Else

                                Try
                                    command.CommandText = "SELECT [" & Replace(rdQualifiers("Qualifier"), "'", "") & "] from InputData "
                                    reader = command.ExecuteReader
                                    If reader.Read() Then
                                        CriteriaSatisfied = isQualified(GetInputValue(rdQualifiers("Qualifier"), True), rdQualifiers("Value"), rdQualifiers("Operator"))
                                    End If
                                    reader.Close()

                                Catch tmpexception As DataException
                                    ' Reference field does not exist (set
                                    ' criteria satisfied as follows)...
                                    If rdQualifiers("Value") = "False" And rdQualifiers("Operator") = "=" Then
                                        CriteriaSatisfied = True
                                    ElseIf rdQualifiers("Value") = "True" And rdQualifiers("Operator") = "<>" Then
                                        CriteriaSatisfied = True
                                    Else
                                        CriteriaSatisfied = False
                                    End If

                                End Try

                            End If

                        ElseIf conjunction = "END" Or conjunction = "OR" Then
                            ' Qualification criteria is met so there is no
                            ' need to continue to the next set of criteria.
                            ' Or this is the end criteria and we can exit.
                            Exit While
                        End If

                        ' Set conjucture...
                        conjunction = rdQualifiers("Conjunction")

                    End If

                End While

                If CriteriaSatisfied = True Then
                    ' Value meets criteria - go ahead & set...
                    QualifyDrawingText.inputValue = text
                    QualifyDrawingText.handle = handle
                    QualifyDrawingText.textToReplace = "I_" & field
                End If

                rdQualifiers.Close()
                connection.Close()

            End If

        End Function


        ''' <summary>
        ''' Update label and progress bar on form calling SetDwg() routine
        ''' </summary>
        ''' <param name="progressBar"></param>
        ''' <param name="pProgress_Increment_Divisor"></param>
        ''' <param name="updateLabel"></param>
        ''' <param name="updateText"></param>
        ''' <remarks></remarks>
        Protected Sub UpdateForm(Optional ByVal progressBar As Object = Nothing, _
                                 Optional ByVal pProgress_Increment_Divisor As Integer = 0, _
                                 Optional ByVal updateLabel As Object = Nothing, _
                                 Optional ByVal updateText As String = "")

            Dim progress As Single = 0
            Try
                If pProgress_Increment_Divisor <= 1 Then
                    progress = progressBar.Maximum - progressBar.Value
                Else
                    progress = progressBar.Maximum / pProgress_Increment_Divisor
                    If progressBar.Value + progress > progressBar.Maximum Then
                        progress = progressBar.Maximum - progressBar.Value
                    End If
                End If
            Catch ex As Exception
            End Try

            Try
                progressBar.Value = progressBar.Value + progress
            Catch ex As Exception
            End Try

            Try
                updateLabel.text = updateText
                updateLabel.refresh()
            Catch ex As Exception
            End Try
        End Sub

        Private Function RemoveRefrigerantCodeFromBLUModel(ByVal model As String) As String
            Dim f As String, l As String

            f = model.Substring(0, model.LastIndexOf("-") + 1)
            'l = model.Substring(model.LastIndexOf("-"))

            Return f & "0" '& l
        End Function



        ''' <summary>Determines which drawings to show for each pass.</summary>
        Protected Function setDrawingName(ByVal model As String, ByVal type As DrawingType) As String
            Dim drawing As String

            ' Special Exception for BLU Models.  Remove refrigerant code.
            If model.ToUpper.StartsWith("BLU") Then
                model = RemoveRefrigerantCodeFromBLUModel(model)
            End If


            If type = DrawingType.Unit Then
                ' adding each model to db could be 1400 additional entries
                If model.StartsWith("XBOC") Then
                    drawing = determineUnitDrawingNameForXboc(model)
                Else
                    drawing = retrieveUnitDrawingName(model)
                End If

                count += 1
            ElseIf type = DrawingType.RefrigerantPiping Then
                drawing = pipingNames(count)
                count += 1
                hasAnotherDrawing = (count < pipingNames.Count)
            ElseIf type = DrawingType.FluidPiping Then
                If unit.type = EquipmentType.PumpPackage Then
                    drawing = "W1.dxf"
                    count += 1
                ElseIf unit.type = EquipmentType.Chiller Then
                    Dim chiller = CType(unit, chiller_equipment)
                    If model.StartsWith("30A2") AndAlso chiller.has_pump_package Then
                        drawing = "W1.dxf"
                        count += 1
                    Else
                        Throw New Exception("A pump package must be selected to view fluid drawing.")
                    End If
                End If
            End If

            Return drawing
        End Function

        ' hard-coding xboc model and drawing name associations to prevent over 1000 db entries
        Private Function determineUnitDrawingNameForXboc(ByVal model As String) As String
            Dim drawing As String
            Select Case numFansInXboc(model)
                Case 1 : drawing = "XBOC-A.dxf"
                Case 2 : drawing = "XBOC-B.dxf"
                Case 3 : drawing = "XBOC-C.dxf"
                Case Else : Throw New Exception("There is not an available XBOC unit drawing with this number of fans.")
            End Select
            Return drawing
        End Function

        Private Function numFansInXboc(ByVal model As String) As Integer
            '0123456789
            'XBOC 410-111
            Dim numFans = CInt(model.Chars(5).ToString)
            Return numFans
        End Function

        Private Function retrieveUnitDrawingName(ByVal model As String) As String
            Dim drawingName = ""

            Dim con = drawingConnection.Create
            Dim com = con.CreateCommand()
            Dim rdr As IDataReader

            Try

                ' model = model & "-LH"




                If con.State <> ConnectionState.Open Then con.Open()
                com.CommandText = "SELECT Drawings.DrawingName FROM DrawingOpenModels " & _
                                  "INNER JOIN Drawings ON DrawingOpenModels.DrawingName = Drawings.DrawingName " & _
                                  "WHERE ((DrawingOpenModels.ModelsToOpen) = '" & model & "' " & _
                                  "AND ((Drawings.DrawingType)='" & getGeneralDrawing(Type) & "'))"
                rdr = com.ExecuteReader()
                If rdr.Read() Then
                    drawingName = rdr("DrawingName").ToString
                End If
            Finally
                If rdr IsNot Nothing Then _
                   rdr.Close()
            End Try


            If String.IsNullOrEmpty(drawingName) Then Throw New Exception("Drawings are not available for selected unit.")

            Return drawingName
        End Function

        ' todo: duplicated from drawingpath
        Private Function getGeneralDrawing(ByVal type As DrawingType) As String
            Dim name As String
            If type = DrawingType.Unit Then
                name = "Unit"
            ElseIf type = DrawingType.FluidPiping Or type = DrawingType.RefrigerantPiping Then
                name = "Piping"
            End If
            Return name
        End Function


        ''' <summary>
        ''' Sets the layers in a drawing based on rules defined in UnitDrawings_LayerRules table.
        ''' </summary>
        Protected Sub setDrawingLayers(ByVal layersInDrawing() As String)
            ' height layers need to be turned on first because other rules depend on their state
            ' NOTE: this may not be necessary any more, would need to test
            If Type = DrawingType.Unit Then _
               setHeightLayers()

            Dim layers = rulesRepo.GetLayers(layersInDrawing)
            'For Each layer In layers
            '   setLayerState(layer, stateOf(layer))

            'Next
        End Sub



        Protected Sub getOnAndOffDrawingLayers(ByRef onLayers As ArrayList, ByRef offLayers As ArrayList, ByVal layersInDrawing() As String)

            Dim specialOffLayers As New List(Of String)


            '            specialOffLayers.Add("XXXXXX1")


            'specialOffLayers.Add("C1E")
            'specialOffLayers.Add("C1RC")
            'specialOffLayers.Add("C2E")
            'specialOffLayers.Add("C2HGC")
            'specialOffLayers.Add("C1HGC")
            'specialOffLayers.Add("C2RC")

            onLayers = New ArrayList
            offLayers = New ArrayList

            'If Type = DrawingType.Unit Then _
            '   setHeightLayers()





            Dim layers = rulesRepo.GetLayers(layersInDrawing)
            For Each layer In layers

                If Model.StartsWith("20") AndAlso specialOffLayers.Contains(layer.ToUpper) Then
                    offLayers.Add(layer)
                ElseIf Model.ToUpper.StartsWith("BOC") AndAlso layer.ToUpper = "C2RC" AndAlso CType(unit, unit_cooler).liquid_line_connection_quantity.value = 2 Then

                    onLayers.Add(layer)

                Else
                    If stateOf(layer) = 1 Then
                        onLayers.Add(layer)
                    Else
                        offLayers.Add(layer)
                    End If
                End If

            Next
        End Sub




        ''' <summary>
        ''' Sets the layers in a drawing based on rules defined in UnitDrawings_LayerRules table.
        ''' </summary>
        Private Sub setHeightLayers()
            Dim sql As String
            Dim con = drawingConnection.Create 'DataAccess.Common.CreateConnection(drawingDbPath)
            Dim com As IDbCommand

            Try
                If con.State <> ConnectionState.Open Then con.Open()
            Catch ex As Exception
                Exit Sub
            End Try

            For int As Integer = 1 To 5
                If stateOf("H" & int) = 1 Then
                    'setLayerState("H" & int, 1)
                    sql = "UPDATE [LayerHeights] SET [H" & int & "] = True"
                Else
                    'setLayerState("H" & int, 2)
                    sql = "UPDATE [LayerHeights] SET [H" & int & "] = False"
                End If

                com = con.CreateCommand()
                com.CommandText = sql
                Try
                    com.ExecuteNonQuery()
                Catch ex As Exception

                End Try
            Next
        End Sub


        Private Function getHeightLayers(ByVal heightLayer As String) As Boolean
            Dim con = drawingConnection.Create
            Dim sql = "SELECT [" & heightLayer & "] FROM LayerHeights"
            Dim com = con.CreateCommand()
            com.CommandText = sql
            Try
                If con.State <> ConnectionState.Open Then con.Open()
                getHeightLayers = com.ExecuteScalar
            Catch ex As Exception

            Finally
                'If con.State = ConnectionState.Open Then con.Close()
            End Try
        End Function


        ''' <summary>
        ''' Returns true if layer name has a rule in unit drawing rules
        ''' </summary>
        Protected Function isQualifierALayerName(ByVal LayerName As String) As Boolean
            isQualifierALayerName = False

            Dim con = drawingConnection.Create 'DataAccess.Common.CreateConnection(drawingDbPath)
            Dim sql = "SELECT [LayerName] from [UnitDrawings_LayerNames]" & _
                      " WHERE [LayerName] = '" & LayerName & "'"
            Dim com = con.CreateCommand()
            com.CommandText = sql
            Dim rdr As IDataReader
            Try
                If con.State <> ConnectionState.Open Then con.Open()
                rdr = com.ExecuteReader()
                If rdr.Read() Then
                    isQualifierALayerName = True
                End If
            Catch ex As Exception

            Finally
                If Not IsNothing(rdr) Then rdr.Close()
                'If con.State = ConnectionState.Open Then con.Close()
            End Try
        End Function


        ' ''' <summary>Turns layer on or off</summary>
        'Protected Sub setLayerState(ByVal layerName As String, ByVal layerState As DTXDWG.LayerState)
        '   Try
        '      tool.SetLayerState(layerName, layerState, DTXDWG.LayerMode.ON_OFF)
        '      ' TODO: should this catch be here
        '   Catch ex As Exception
        '      log(layerName & " layer state could not be set. " & ex.Message)
        '   End Try
        'End Sub

        Private Function run(ByVal rules As List(Of Rule)) As Integer
            ' sets default to layer off
            Dim turnLayerOn = 2

            Dim criteriaSatisfied = True
            Dim conjunction = "END"
            Dim layerState = "OFF"

            For Each rule In rules
                If rule.Qualifier = "ALWAYS_ON" OrElse rule.Qualifier = "ALWAYSON" Then
                    criteriaSatisfied = True
                    layerState = "ON"
                    Exit For
                End If



                If criteriaSatisfied = False Then

                    ' If criteria is NOT satisfied then 
                    ' - if OR conjunction then check condition
                    ' - if AND conjunction; skip because this series of criteria is not satisfied.
                    ' - if END conjunction; exit 
                    If conjunction = "OR" Then
                        layerState = rule.State
                        criteriaSatisfied = True

                        Try
                            Dim s1 = GetInputValue(rule.Qualifier, False)
                            ' TODO: Can qualification be moved to SQL statement to eliminate this loop
                            criteriaSatisfied = isQualified(s1, rule.Value, rule.Operator)

                        Catch tmpexception As DataException
                            ' Reference field does not exist (set criteria satisfied as follows)...
                            If rule.Value = "False" And rule.Operator = "=" _
                            Or rule.Value = "False" And rule.Operator = "EQ" Then
                                criteriaSatisfied = True
                            ElseIf rule.Value = "True" And rule.Operator = "<>" _
                                Or rule.Value = "True" And rule.Operator = "NE" Then
                                criteriaSatisfied = True
                            Else
                                criteriaSatisfied = False
                            End If
                        End Try

                    ElseIf conjunction = "END" Then
                        Exit For
                    End If

                    conjunction = rule.Conjunction

                Else
                    If Val(rule.Position) = 1 OrElse conjunction.ToUpper = "AND" Then
                        layerState = rule.State

                        Try
                            criteriaSatisfied = isQualified(GetInputValue(rule.Qualifier, False), rule.Value, rule.Operator)
                        Catch tmpexception As DataException
                            ' Reference field does not exist (set
                            ' criteria satisfied as follows)...
                            If rule.Value = "False" AndAlso rule.Operator = "=" _
                            OrElse rule.Value = "False" AndAlso rule.Operator = "EQ" Then
                                criteriaSatisfied = True
                            ElseIf rule.Value = "True" AndAlso rule.Operator = "<>" _
                                Or rule.Value = "True" AndAlso rule.Operator = "NE" Then
                                criteriaSatisfied = True
                            Else
                                criteriaSatisfied = False
                            End If
                        End Try

                    ElseIf conjunction = "END" OrElse conjunction = "OR" Then
                        Exit For
                    End If

                    conjunction = rule.Conjunction
                End If
            Next

            If criteriaSatisfied Then
                If UCase(layerState) = "ON" Then
                    turnLayerOn = 1
                ElseIf UCase(layerState) = "OFF" Then
                    turnLayerOn = 2
                End If
            End If

            Return turnLayerOn
        End Function

        ''' <summary>Determines if layer should be turned on or off (0=off, 1=on)</summary>
        Protected Function stateOf(ByVal layer As String) As Integer
            Dim rules = rulesRepo.GetRulesFor(layer)
            stateOf = run(rules)
        End Function


        ''' <summary>
        ''' Determine if two strings are qualified based on the strings and qualifying operator.
        ''' </summary>
        Protected Function isQualified(ByVal string1 As String, ByVal string2 As String, ByVal theOperator As String) As Boolean
            isQualified = False

            string1 = string1.Replace("30AO", "30A0")
            string2 = string2.Replace("30AO", "30A0")

            string1 = UCase(string1)
            string2 = UCase(string2)

            Select Case theOperator

                Case "=", "EQ"
                    If IsNumeric(string1) And IsNumeric(string2) Then
                        If Val(string1) = Val(string2) Then
                            isQualified = True
                        Else
                            isQualified = False
                        End If
                    Else
                        If string1 = string2 Then isQualified = True
                    End If

                Case ">", "G"
                    If IsNumeric(string2) And IsNumeric(string2) Then
                        If Val(string1) > Val(string2) Then
                            isQualified = True
                        Else
                            isQualified = False
                        End If
                    Else
                        If string1 > string2 Then isQualified = True
                    End If

                Case ">=", "GE"
                    If IsNumeric(string2) And IsNumeric(string2) Then
                        If Val(string1) >= Val(string2) Then
                            isQualified = True
                        Else
                            isQualified = False
                        End If
                    Else
                        If string1 >= string2 Then isQualified = True
                    End If

                Case "<", "L"
                    If IsNumeric(string2) And IsNumeric(string2) Then
                        If Val(string1) < Val(string2) Then
                            isQualified = True
                        Else
                            isQualified = False
                        End If
                    Else
                        If string1 < string2 Then isQualified = True
                    End If

                Case "<=", "LE"
                    If IsNumeric(string1) And IsNumeric(string2) Then
                        If Val(string1) <= Val(string2) Then
                            isQualified = True
                        Else
                            isQualified = False
                        End If
                    Else
                        If string1 <= string2 Then isQualified = True
                    End If

                Case "<>", "NE"
                    If IsNumeric(string2) And IsNumeric(string2) Then
                        If Val(string1) <> Val(string2) Then
                            isQualified = True
                        Else
                            isQualified = False
                        End If
                    Else
                        If string1 <> string2 Then isQualified = True
                    End If

                Case "LK"
                    If string1 Like Replace(string2, "%", "*") Or string1 Like Replace(string2, "*", "") & "*" Then isQualified = True

                Case "SW"
                    If string1.StartsWith(Replace(string2, "*", "")) Then isQualified = True

                Case "EW"
                    If string1.EndsWith(Replace(string2, "*", "")) Then isQualified = True

            End Select

        End Function


        ''' <summary>Get database or option value of field passed.</summary>
        ''' <param name="fieldName"></param>
        Protected Function GetInputValue(ByVal fieldName As String, ByVal isText As Boolean) As String
            GetInputValue = ""
            If fieldName = "" Then Exit Function

            ' Added this code when we switched from righ-hand default to left-hand defaunt on NSD units

            Dim tempOptions As EquipmentOptionList
            tempOptions = Me.Options.Clone

            If Not String.IsNullOrEmpty(Me.unit.series.ToUpper) AndAlso (Me.unit.series.ToUpper = "NSB" OrElse Me.unit.series.ToUpper = "NSC" OrElse Me.unit.series.ToUpper = "NSF") Then

                If Not tempOptions.Contains("RH02") Then
                    Dim LH01Option As New EquipmentOption
                    LH01Option.Code = "LH02"
                    tempOptions.Add(LH01Option)

                End If
            End If

            ' select previously inserted height from db
            If Me.Type = DrawingType.Unit Then
                Select Case UCase(fieldName)
                    Case "H1", "H2", "H3", "H4", "H5"
                        Return getHeightLayers(UCase(fieldName))
                End Select
            End If

            'Dim infoReq = RetrieveInfoRequired(fieldName, drawingType, drawingName)
            Dim con = drawingConnection.Create
            Dim sql = "SELECT [InfoRequired] FROM [GlobalInputNames] " & _
                       "WHERE [InfoRequired] = '" & fieldName & "' " & _
                           "AND [DrawingType] = '_ALL' " & _
                       "OR [InfoRequired] = '" & fieldName & "' " & _
                           "AND [DrawingType] = '" & getGeneralDrawing(Type) & "' " & _
                       "OR [InfoRequired] = '" & fieldName & "' " & _
                           "AND [DrawingType] = '" & DrawingName & "' "
            Dim com = con.CreateCommand
            com.CommandText = sql
            Dim rdr As IDataReader

            Try
                If con.State <> ConnectionState.Open Then con.Open()
                rdr = com.ExecuteReader()
                If rdr.Read() Then
                    If Not IsDBNull(rdr("InfoRequired")) Then _
                       GetInputValue = getPropValue(Me.GetType, Me, rdr("InfoRequired"), isText)
                Else
                    If isQualifierALayerName(fieldName) Then
                        GetInputValue = IIf(stateOf(fieldName) = 1, True, False)
                    ElseIf isQualifierAnOptionCode(fieldName) Then




                        For Each op In tempOptions
                            If op.Code = "MG04" Then
                                Me.HotGasSizeCircuit1 = "5/8"
                                Me.HotGasSizeCircuit2 = "5/8"
                            ElseIf op.Code = "MG05" Then
                                Me.HotGasSizeCircuit1 = "7/8"
                                Me.HotGasSizeCircuit2 = "7/8"
                            ElseIf op.Code = "MG06" Then
                                Me.HotGasSizeCircuit1 = "1 1/8"
                                Me.HotGasSizeCircuit2 = "1 1/8"
                            End If
                            If op.Code = fieldName Then
                                GetInputValue = "True"
                                Exit For
                            End If
                        Next
                        If GetInputValue <> "True" Then _
                           GetInputValue = "False"
                    ElseIf isQualifierADrawingName(fieldName) Then
                        GetInputValue = DrawingName.Replace(".dxf", "")
                    ElseIf fieldName.ToUpper = "COMPMOD" AndAlso Not String.IsNullOrEmpty(Me.CompModel) Then
                        GetInputValue = Me.CompModel
                    ElseIf fieldName.ToUpper = "COMPOILDEL" AndAlso Not String.IsNullOrEmpty(Me.CompOilDel) Then
                        GetInputValue = Me.CompOilDel
                    End If
                End If
            Catch ex As DataException
                ' Field does not exist...
                GetInputValue = "   "
            Finally
                If rdr IsNot Nothing Then rdr.Close()
            End Try

        End Function

#Region " Data Access"

        Private Function isQualifierAnOptionCode(ByVal value As String) As Boolean
            Dim con = equipConnection.Create
            Dim com = con.CreateCommand()
            Dim sql = "SELECT * FROM [MasterOptions] " & _
                      "WHERE [Code] = '" & value & "'"
            com.CommandText = sql
            Dim rdr As IDataReader
            Dim i = 0

            Try
                If con.State <> ConnectionState.Open Then con.Open()

                rdr = com.ExecuteReader()

                While rdr.Read()
                    i += 1
                End While
            Finally
                If rdr IsNot Nothing Then rdr.Close()
            End Try

            Return i > 0
        End Function

        Private Function isQualifierADrawingName(ByVal qualifier As String) As Boolean
            Return qualifier.ToUpper = "DRAWING"
        End Function

#End Region


        Protected Sub log(ByVal message As String)
            My.Application.Log.WriteEntry(message & " - " & Date.Now.ToString)
        End Sub


        ''' <summary>
        ''' Get value of specified property
        ''' </summary>
        ''' <param name="objType"></param>
        ''' <param name="objectInstance"></param>
        ''' <param name="propName"></param>
        Protected Function getPropValue(ByVal objType As System.Type, _
                                        ByVal objectInstance As Object, _
                                        ByVal propName As String, ByVal isText As Boolean) As String




            'initialize to ""
            getPropValue = ""     'ERICC44

            Dim Props() As PropertyInfo = _
            objType.GetProperties(BindingFlags.Public Or _
            BindingFlags.Instance)
            For Each PropItem As PropertyInfo In Props
                If PropItem.CanWrite Then
                    If PropItem.Name = propName Then
                        getPropValue = CNull.ToString(PropItem.GetValue(objectInstance, Nothing))


                        If propName = "Model" AndAlso isText = False Then
                            If getPropValue.StartsWith("NSC") Then getPropValue = getPropValue.Replace("NSC", "NSB")
                            If getPropValue.StartsWith("NDC") Then getPropValue = getPropValue.Replace("NDC", "NDB")
                            If getPropValue.StartsWith("NSF") Then getPropValue = getPropValue.Replace("NSF", "NSB")
                            If getPropValue.StartsWith("NDF") Then getPropValue = getPropValue.Replace("NDF", "NDB")

                        End If

                        Exit For
                    End If
                End If
            Next

        End Function

        ' sets the inlet, outlet, suction and liquid connection ODS sizes
        Protected Sub setConnectionSizes()
            Dim connString As String
            Dim tableName As String

            InletLineSize = "NA"
            InletLineSize2 = "NA"
            OutletLineSize = "NA"
            OutletLineSize2 = "NA"
            SuctionSizeCircuit1 = "NA"
            SuctionSizeCircuit2 = "NA"
            LiquidSizeCircuit1 = "NA"
            LiquidSizeCircuit2 = "NA"

            Dim mc20 = unit.options.Contains("MC20")

            'If Me._model Like "10A*" Or Me._model Like "PFC*" Or Me._model Like "RAC*" Then
            If TypeOf unit Is CondenserEquipmentItem Then
                Dim condenser = service.get_condenser(_model)

                If condenser.number_of_circuits > 1 And Not mc20 Then 'if condenser is dual circuit
                    SuctionSizeCircuit1 = condenser.dual_circuit_inlet_diameter
                    LiquidSizeCircuit1 = condenser.dual_circuit_outlet_diameter
                    SuctionSizeCircuit2 = condenser.dual_circuit_inlet_diameter
                    LiquidSizeCircuit2 = condenser.dual_circuit_outlet_diameter
                Else
                    SuctionSizeCircuit1 = condenser.single_circuit_inlet_diameter
                    LiquidSizeCircuit1 = condenser.single_circuit_outlet_diameter
                    SuctionSizeCircuit2 = condenser.single_circuit_inlet_diameter
                    LiquidSizeCircuit2 = condenser.single_circuit_outlet_diameter
                End If

            ElseIf is_unit_cooler(_model) Then
                Dim tmpNumConv As Integer = 0

                Dim unit_cooler = CType(unit, unit_cooler)
                Dim unit_cooler_model = New unit_coolers.database_formatter().format_model(Me.Model, unit_cooler.refrigerant)

                Dim connection = Common.CreateConnection(Common.UnitCoolerDbPath)
                Dim command = connection.CreateCommand()
                Dim reader As IDataReader

                Try
                    connection.Open()
                    command.CommandText = "SELECT * " & _
                                          "FROM [UNIT_COOLERS] " & _
                                          "WHERE [Model] = '" & unit_cooler_model & "'"
                    reader = command.ExecuteReader()
                    If reader.Read() Then
                        ' set refrigerant connection sizes
                        Dim liquidLineConnectionSize = reader("LL_CONX")
                        LiquidSizeCircuit1 = liquidLineConnectionSize
                        LiquidSizeCircuit2 = liquidLineConnectionSize
                        LiquidSizeCircuit3 = liquidLineConnectionSize
                        LiquidSizeCircuit4 = liquidLineConnectionSize

                        Dim suctionLineConnectionSize = reader("SL_CONX")
                        SuctionSizeCircuit1 = suctionLineConnectionSize
                        SuctionSizeCircuit2 = suctionLineConnectionSize
                        SuctionSizeCircuit3 = suctionLineConnectionSize
                        SuctionSizeCircuit4 = suctionLineConnectionSize

                        Dim hotGasConnectionSize = reader("HG_CONX")
                        HotGasSizeCircuit1 = hotGasConnectionSize
                        HotGasSizeCircuit2 = hotGasConnectionSize
                        HotGasSizeCircuit3 = hotGasConnectionSize
                        HotGasSizeCircuit4 = hotGasConnectionSize
                    End If
                Catch ex As Exception
                Finally
                    If reader IsNot Nothing Then reader.Close()
                    If connection.State <> ConnectionState.Closed Then connection.Close()
                End Try

            ElseIf Model Like "PP*" Then
                Dim pumpPackage = CType(unit, PumpEquipment)
                Dim flow = pumpPackage.Flow.value
                Dim head = pumpPackage.Head.value
                Dim manufacturer = pumpPackage.Manufacturer
                Dim system = pumpPackage.System
                Dim size = service.GetPumpPackageConnectionSize(manufacturer, flow, head, system)
                InletLineSize = size
                OutletLineSize = size

            ElseIf TypeOf unit Is chiller_equipment Then
                Dim connectionSize = service.GetChillerConnectionSizes(CType(unit, chiller_equipment))
                InletLineSize = connectionSize.Inlet
                OutletLineSize = connectionSize.Outlet

            ElseIf TypeOf unit Is CondensingUnitEquipmentItem Then
                Dim connectionSize = service.GetCondensingUnitConnectionSizes(unit.model, mc20)
                SuctionSizeCircuit1 = connectionSize(0).Inlet
                LiquidSizeCircuit1 = connectionSize(0).Outlet
                If connectionSize.Count > 1 Then
                    SuctionSizeCircuit2 = connectionSize(1).Inlet
                    LiquidSizeCircuit2 = connectionSize(1).Outlet
                End If

                If connectionSize.Count > 2 Then
                    SuctionSizeCircuit3 = connectionSize(2).Inlet
                    LiquidSizeCircuit3 = connectionSize(2).Outlet
                End If

                If connectionSize.Count > 3 Then
                    SuctionSizeCircuit4 = connectionSize(3).Inlet
                    LiquidSizeCircuit4 = connectionSize(3).Outlet
                End If


            End If

        End Sub


        Protected Sub setElectricalInfo()
            ' Disclaimer: Electrical information is for standard catalog equipment.
            ' If electrical options are added, please contact factory for actual electrical data.
            ' unit.common_specs.Mca
            Dim voltage = unit.common_specs.UnitVoltage.Voltage.value
            Dim phase = unit.common_specs.UnitVoltage.Phase.value
            Dim hertz = unit.common_specs.UnitVoltage.Hertz.value
            Dim na = "NA"
            If _model Like "10A*" Or _model Like "PFC*" Or _model Like "RAC*" Then
                Try
                    Dim e = service.GetCondenserElectricalInfo(Model, voltage)
                    RLACircuit1 = e.rla
                    MCACircuit1 = e.mca
                    MaxFuseSizeCircuit1 = e.fuse
                    SCCRCircuit1 = e.sccr
                Catch ex As Exception
                    Throw New Exception("An exception occurred while determining the condenser drawing electrical info. " & ex.Message, ex)
                End Try

            ElseIf Model Like "PP*" Then
                Dim e = service.GetPumpPackageElectricalInfo(CType(unit, PumpEquipment))
                RLACircuit1 = e.rla
                MCACircuit1 = e.mca
                MaxFuseSizeCircuit1 = e.max_fuse_size
                SCCRCircuit1 = e.sccr

            ElseIf is_unit_cooler(_model) Then
                Dim unit_cooler = CType(unit, unit_cooler)
                Dim e = service.get_unit_cooler_electrical_info(unit_cooler)
                validators.add_range(e.validators)
                FanVoltage = e.fan_voltage
                FanQuantity = e.fan_quantity
                FanAmpEach = e.fan_motor_amps
                FanBlocks = e.fan_blocks
                DefrostBlocks = e.defrost_blocks
                DefrostAmps = e.defrost_heater_amps
                DefrostWatts = e.defrost_heater_watts
                DefrostVoltage = e.defrost_voltage
                SCCRCircuit1 = e.sccr_1
                SCCRCircuit2 = e.sccr_2
                SCCRCircuit3 = e.sccr_3
            ElseIf Model Like "35*" Then ' evaporative condenser chiller
                Dim chiller = CType(unit, chiller_equipment)
                Dim electrical = New rae.solutions.evaporative_condenser_chillers.electrical_data(chiller)

                Dim circuit_1 = electrical.circuits(0)
                RLACircuit1 = circuit_1.rla
                MCACircuit1 = circuit_1.mca
                MaxFuseSizeCircuit1 = circuit_1.max_fuse_size
                SCCRCircuit1 = circuit_1.sccr

                If electrical.circuits.Count > 1 Then
                    Dim circuit_2 = electrical.circuits(1)
                    RLACircuit2 = circuit_2.rla
                    MCACircuit2 = circuit_2.mca
                    MaxFuseSizeCircuit2 = circuit_2.max_fuse_size
                    SCCRCircuit2 = circuit_2.sccr
                Else
                    RLACircuit2 = na
                    MCACircuit2 = na
                    MaxFuseSizeCircuit2 = na
                    SCCRCircuit2 = na
                End If

            ElseIf Model Like "3*" Then ' air cooled chiller
                Dim spec As chiller_electrical_spec
                spec.model = unit.model
                spec.unit_type = getUnitType(Model)
                spec.voltage = voltage
                spec.phase = phase
                spec.hertz = hertz
                spec.pump_package = CType(unit, chiller_equipment).pump_package
                spec.division = unit.division


                spec.et02 = unit.options.Contains("ET02")

                Dim e = service.GetChillerElectricalInfo(spec, "AirCooledChiller")

                If e.rla_1 = 0 Then
                    RLACircuit1 = na
                    MCACircuit1 = na
                    MaxFuseSizeCircuit1 = na
                    SCCRCircuit1 = na
                Else
                    RLACircuit1 = e.rla_1
                    MCACircuit1 = e.mca_1
                    MaxFuseSizeCircuit1 = e.max_fuse_size_1
                    SCCRCircuit1 = e.sccr_1
                    If e.number_of_circuits > 1 Then
                        RLACircuit2 = e.rla_2
                        MCACircuit2 = e.mca_2
                        MaxFuseSizeCircuit2 = e.max_fuse_size_2
                        SCCRCircuit2 = e.sccr_2
                    End If
                End If
            ElseIf Model Like "20*" Then

                RLACircuit1 = unit.common_specs.Rla.ToString
                MCACircuit1 = unit.common_specs.Mca.ToString
                MaxFuseSizeCircuit1 = unit.common_specs.MOP.ToString
                SCCRCircuit1 = 5


                If unit.common_specs.powerFeeds.ToString = "2" Then

                    RLACircuit2 = unit.common_specs.Rla.ToString
                    MCACircuit2 = unit.common_specs.Mca.ToString
                    MaxFuseSizeCircuit2 = unit.common_specs.MOP.ToString
                    SCCRCircuit2 = 5

                End If



                'End If


            ElseIf Model Like "FC*" Then
                RLACircuit1 = 0
                MCACircuit1 = 0
                MaxFuseSizeCircuit1 = 0
                SCCRCircuit1 = 0


            Else ' condensing unit
                Dim et10 = Options.Contains("ET10") ' convenience outlet
                Dim mc20 = Options.Contains("MC20") ' single circuit
                Dim e = service.GetCondensingUnitElectricalInfo(Model, voltage, phase, hertz, et10, mc20, Me.unit.division)

                RLACircuit1 = e.rla1
                MCACircuit1 = e.mca1
                MaxFuseSizeCircuit1 = e.fuse1
                SCCRCircuit1 = e.sccr1
                If e.circuits > 1 Then
                    RLACircuit2 = e.rla2
                    MCACircuit2 = e.mca2
                    MaxFuseSizeCircuit2 = e.fuse2
                    SCCRCircuit2 = e.sccr2
                End If
            End If
        End Sub


        Private Function is_unit_cooler(ByVal model As String) As Boolean
            Return model Like "A*" Or model Like "BALV*" Or model Like "BOC*" Or model Like "*IBR*" _
                Or model Like "FH*" Or model Like "FV*" Or model Like "PFE*" Or model Like "XBOC*" Or model Like "E*" Or model Like "UFH*" Or model Like "AWSM*"
        End Function

        Private Overloads Function rnd(ByVal value As Double) As Double
            Return System.Math.Round(value)
        End Function

        Private Overloads Function rnd(ByVal value As Double, ByVal digits As Integer) As Double
            Return System.Math.Round(value, digits)
        End Function

        Private Function getUnitType(ByVal model As String) As String
            Dim unitType As String

            If model Like "30*" Or model Like "32*" Or model Like "33*" Then
                unitType = "AirCooledChiller"
            ElseIf model Like "34*" Then
                unitType = "EvapCooldedChiller"
            ElseIf model Like "35*" Then
                unitType = "EvaporativeCondenserChiller"
            Else
                Throw New ArgumentException("The unit type cannot be determined for chiller: " & model)
            End If

            Return unitType
        End Function

#End Region

#End Region

    End Class

End Namespace
' 3386