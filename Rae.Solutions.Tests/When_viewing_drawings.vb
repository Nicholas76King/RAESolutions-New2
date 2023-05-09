Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert
Imports Rae.RaeSolutions
Imports Rae.RaeSolutions.Business.Entities
Imports rae.solutions.drawings
Imports System.Collections.Generic
imports rae.solutions

<TestClass()> _
Public Class When_viewing_drawings

<TestMethod(), Ignore> _
Sub can_view_many
   Dim projectMgr = New project_manager("Casey", "pass")
   Dim unit = New CondensingUnitEquipmentItem("Test Many", Rae.RaeSolutions.Business.Division.CRI, "Casey", "pass", projectMgr)
   Dim models = New List(Of String)(New String() {"10", "16", "18", "20", "24"}) ', "30", "40", "50", "60", "70", "80"})

   For Each model In models
      unit.Series = "DD"
      unit.model_without_series = model & "H7"
	   Dim drawing = New RefrigerantPipingDrawing(unit, user_group.employee)

            Dim openDrawing As Boolean = True
            Dim returnDrawingNames As New List(Of String)


            drawing.Show(returnDrawingNames, openDrawing)
	Next
End Sub

Private drawingFolderPath As String
   Private drawingFilePath As String = "C:\Code\Rae\Solutions\Main\Rae.Solutions\Drawings\Drawings\Piping\MasterDrawings\PipingTest.dxf"

<TestMethod(), Ignore> _
Sub test_log()
   ' logs to output during debug (not when running)
	My.Application.Log.WriteEntry("Hello from logger")
	' console writer does not log
	Console.WriteLine("Hello from console")
	' logs to output during debug (not when running)
	System.Diagnostics.Debug.Print("Hello from debug")
End Sub

   '<TestMethod, Ignore> _
   'Sub can_view_many_drawings_in_new_viewer()
   '   Dim fs = New List(Of DrawingForm)
   '   For i = 0 To 4
   '      Dim f = New DrawingForm
   '      f.SetDrawing(drawingFilePath)
   '      fs.Add(f)
   '      f.Show
   '      f.Refresh
   '      'f.Update
   '      f.Close
   '   Next

   'End Sub

   '<TestMethod, Ignore> _
   'Sub can_view_many_drawings_in_new_viewer_using_dialog_window()
   '	For i = 0 To 2
   '      Dim f = New DrawingForm
   '      f.SetDrawing(drawingFilePath)
   '      f.ShowDialog
   '      f.Close
   '   Next
   'End Sub

'<TestMethod, Ignore> _
'Sub can_view_drawing_many_times_in_old_viewer()
'   For i = 0 To 20
'         Dim drawingPath = "C:\Code\Rae\Solutions\Main\Rae.Solutions\Drawings\Drawings\Piping\MasterDrawings\RP1A.dxf"
'	   Dim f = New PreviewDrawingForm()
'	   f.DrawingPath = drawingPath
'	   f.Show
'	   'f.Refresh
'	   f.Close
'	Next
'End Sub

'<TestMethod, Ignore> _
'Sub can_view_many_drawings_in_old_viewer()
'      Dim names() As String = {"RP1A.dxf", "RP1B.dxf", "RP1C.dxf", "RP1D.dxf"}
	
'	For i = 0 To 0
'	   Dim fs = New List(Of PreviewDrawingForm)
'	   For Each name In names
'         Dim drawingPath = "C:\Code\Rae\Solutions\Main\Rae.Solutions\Drawings\Drawings\Piping\MasterDrawings\" & name
'         Dim f = New PreviewDrawingForm
'         f.DrawingPath = drawingPath
'         f.Show
'         fs.Add(f)
'         'f.Close
'      Next
      
'      For Each f In fs
'         f.Close
'      Next
'   Next 
'End Sub

End Class
