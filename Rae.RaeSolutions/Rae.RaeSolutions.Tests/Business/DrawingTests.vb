Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert
Imports Drawings = rae.solutions.drawings
Imports Rae.RaeSolutions.Business.Entities

<TestClass()> _
Public Class DrawingTests

   <TestMethod()> _
   Sub Scroll_piping_drawing_names_are_generated_for_models_that_have_scroll_compressors
   	Dim names = New Drawings.RefrigerantPipingDrawingNames("20A0LSXX", emptyOptions)
   	IsTrue(names(0) = "SLP1A.dwg")
   End Sub

   <TestMethod()> _
   Sub Recip_piping_drawing_names_are_generated_for_models_that_have_recip_compressors
   	Dim names = New Drawings.RefrigerantPipingDrawingNames("20A0CSXX", emptyOptions)
   	IsTrue(names(0) = "RP1A.dwg")
   End Sub
   
   <TestMethod()> _
   Sub Screw_piping_drawing_names_are_generated_for_models_that_have_screw_compressors
   	Dim names = New Drawings.RefrigerantPipingDrawingNames("30A2SSXXX", emptyOptions)
   	IsTrue(names(0) = "SWP1A.dwg")
   End Sub

   <TestMethod()> _
   Sub One_piping_drawing_name_with_suffix_A_is_generated_for_models_with_a_single_circuit
      Dim names = New Drawings.RefrigerantPipingDrawingNames("30A2SS140", emptyOptions)
      IsTrue(names(0) = "SWP1A.dwg")
      IsTrue(names.Count = 1)
   End Sub
   
   <TestMethod()> _
   Sub Two_piping_drawing_names_are_generated_for_dual_circuits
   	Dim names = New Drawings.RefrigerantPipingDrawingNames("30A2SD220", emptyOptions)
   	
   	IsTrue(names(0) = "SWP1A.dwg")
   	IsTrue(names(1) = "SWP1B.dwg")
   End Sub
   
   <TestMethod()> _
   Sub Four_piping_drawing_names_are_generated_for_multiple_circuits
   	Dim names = New Drawings.RefrigerantPipingDrawingNames("30A2SM360", emptyOptions)
   	
   	IsTrue(names(0) = "SWP1A.dwg")
   	IsTrue(names(1) = "SWP1B.dwg")
   	IsTrue(names(2) = "SWP1C.dwg")
   	IsTrue(names(3) = "SWP1D.dwg")
   End Sub

   <TestMethod()> _
   Sub Drawing_LoadDrawing()
      Dim drawingFilePath = "C:\Code\Rae\Solutions\Main\Rae.Solutions\Drawings\Drawings\Unit\MasterDrawings\10-A.dwg"
   	Dim d = New Drawing(drawingFilePath)
      d.Load()

      d.Close()
   End Sub
   
   'passes when ran by itself, but fails when ran with other tests
   <TestMethod, Ignore> _
   Sub DTools_does_not_freeze()
   	Dim drawingFolderPath = "C:\Code\Rae\Solutions\Main\Rae.Solutions\Drawings\Drawings\Piping\MasterDrawings\"
   	Dim drawingNames() As String = {"RP1A", "RP1B", "RP1C", "RP1D"}
   	
   	For i = 0 To 50
   	   For Each drawingName In drawingNames
   	      Dim drawingFilePath = drawingFolderPath & drawingName & ".dwg"
            Dim drawing = New Drawing(drawingFilePath)
            drawing.Load()
            drawing.Close()
         Next
      Next
   End Sub



   Private Function emptyOptions As EquipmentOptionList
      Return New EquipmentOptionList( _
               New CondensingUnitEquipmentItem("", RaeSolutions.Business.Division.TSI, "", "", _
               New project_manager("", "", "")))
   End Function

#Region " Initialize and cleanup"

Property Context As TestContext
   Get
      Return _context
   End Get
   Set(value As TestContext)
      _context = value
   End Set
End Property

Private _context As TestContext

' <ClassInitialize()> Shared Sub InitializeClass(context As TestContext)
' End Sub
'
' <ClassCleanup()> Shared Sub CleanupClass()
' End Sub
'
' <TestInitialize()> Sub InitializeTest()
' End Sub
'
' <TestCleanup()> Sub CleanupTest()
' End Sub

#End Region

End Class

Public Class Drawing

   Sub New(drawingFilePath As String)
      Me.drawingFilePath = drawingFilePath
   End Sub


   Sub Load()
   	drawingTool = Drawings.DrawingToolFactory.Create()

      With drawingTool
         .UnlockProduct(unlock_Code)

         Dim returnedHandle As Integer
         Dim password = "" ' there is no password
         .LoadDrawing(returnedHandle, drawingFilePath, password)

         Dim loadStat As LoadStatus
         Rae.Io.Text.GetEnumValue(Of LoadStatus)(returnedHandle, loadStat)
         
         If Not .dtxErrorMessage = "1000:Ok" Then _
            log("Drawing failed to load.")
         
         If loadStat = LoadStatus.Failed Then _
            log("Drawing failed to load. " & .dtxErrorMessage)
      End With
   End Sub

   Sub Close()
      ' implement IDisposable
      drawingTool.CloseDrawing()
   End Sub


   Const unlock_Code As String = "L3T4SG7Y6D0"
   Private drawingFilePath As String
   Private drawingTool As DToolsXDWG.CdtxDrawing

   Private Enum LoadStatus
      Failed = 0
      Succeeded = 1
   End Enum

   Private Sub log(message As String)
   	My.Application.Log.WriteEntry(message)
   End Sub

End Class

Public Class DrawingViewer

   Sub New(drawing As Drawing)
      Me.drawing = drawing
   End Sub


   Sub Show()
      
   End Sub


   Private drawing As Drawing

End Class
