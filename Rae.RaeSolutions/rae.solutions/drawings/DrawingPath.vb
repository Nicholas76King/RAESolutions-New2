Imports Path = System.IO.Path
Imports rae.solutions

Namespace rae.solutions.drawings

    ''' <summary>Helps build path to drawing files.</summary>
    ''' <remarks>Code Example
    ''' <code>
    ''' Dim path = New DrawingPath(type)
    ''' path.To("10-A.dwg").In(path.MasterFolder)
    ''' </code>
    ''' Path Example:
    ''' </remarks>
    Public Class DrawingPath

        ''' <summary>Initializes a new drawing path</summary>
        ''' <param name="type">Type of drawing to build path for</param>
        Sub New(ByVal type As DrawingType, ByVal targetUserGroup As user_group)
            Dim appPath = Rae.RaeSolutions.DataAccess.Common.AppFolderPath
            Me.targetUserGroup = targetUserGroup
            ' ex. C:\Program Files\RAESolutions\Drawings"
            drawingFolder = Path.Combine(appPath, "Drawings")
            setMasterFolder(type)
            setEditFolder(type)
        End Sub

        ''' <summary>Path to drawing edit folder</summary>
        ReadOnly Property EditFolder() As String
            Get
                Return _editFolder
            End Get
        End Property

        ''' <summary>Path to master drawing folder</summary>
        ReadOnly Property MasterFolder() As String
            Get
                Return _masterFolder
            End Get
        End Property

        ''' <summary>Specifies file name building path for</summary>
        ''' <param name="fileName">File name building path for</param>
        Function [To](ByVal fileName As String) As PathBuilder
            Return New PathBuilder(fileName)
        End Function

        ''' <summary>Builds path to master drawing</summary>
        ''' <param name="fileName">File name of master drawing</param>
        Function ToMasterDrawing(ByVal fileName As String) As String
            Return Me.To(fileName).In(MasterFolder)
        End Function


        Private Sub setMasterFolder(ByVal type As DrawingType)
            ' Cliff's RAESolutions opens drawings from his user library
            ' so that software updates don't copy over his changes to the drawings
            Dim cliffsComputerName As String = "CLIFFM"
            Dim isCliff = (My.Computer.Name = cliffsComputerName)
            Dim cliffsUserLibrary = "\\fileserver1a\user library\cliffm\new drawings"

            If isCliff Then
                _masterFolder = cliffsUserLibrary
            Else
                ' ex. .\Drawings\Drawings\
                _masterFolder = Path.Combine(drawingFolder, "Drawings")

                ' ex. .\Drawings\Drawings\Unit\ or .\Drawings\Drawings\Piping\
                _masterFolder = Path.Combine(MasterFolder, getFolderName(type))

                ' installer didn't create master drawings folder for piping drawings
                ' unit drawings go in .\Drawings\Drawings\Unit\MasterDrawings\
                ' employee piping drawings go in .\Drawings\Drawings\Piping
                If type = DrawingType.Unit Then
                    ' ex. .\Drawings\Drawings\Unit\MasterDrawings
                    _masterFolder = Path.Combine(_masterFolder, "MasterDrawings")
                End If
            End If
        End Sub

        Private Function getFolderName(ByVal type As DrawingType) As String
            Dim name As String
            If type = DrawingType.Unit Then
                name = "Unit"
            ElseIf type = DrawingType.FluidPiping Or type = DrawingType.RefrigerantPiping Then
                name = "Piping"
            End If
            Return name
        End Function

        Private Sub setEditFolder(ByVal type As DrawingType)
            '_editFolder = Path.Combine(drawingFolder, "Edit Drawings")

            'If targetUserGroup = user_group.rep And (type = DrawingType.RefrigerantPiping Or type = DrawingType.FluidPiping) Then
            'Else
            '    _editFolder = Path.Combine(_editFolder, getFolderName(type))
            'End If


            Dim tempPath = My.Computer.FileSystem.SpecialDirectories.Temp


            _editFolder = tempPath

        End Sub

        Private _editFolder, _masterFolder, drawingFolder As String
        Private targetUserGroup As user_group

        Public Class PathBuilder
            Sub New(ByVal fileName As String)
                Me.fileName = fileName
            End Sub

            Function [In](ByVal folderPath As String) As String
                Return System.IO.Path.Combine(folderPath, fileName)
            End Function

            Private fileName As String
        End Class

    End Class

End Namespace
