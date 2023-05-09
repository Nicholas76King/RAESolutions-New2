Imports System.IO
Imports System.Collections.Generic
Imports System

Namespace Rae.RaeSolutions.Business.Entities.PriceSheets

''' <summary>Provides path locations relative to this assembly.</summary>
Class Locations

#Region " Public properties"

   Private assembly_ As Rae.Io.FileLocation
   ''' <summary>File information about this assembly.</summary>
   ReadOnly Property Assembly As Rae.Io.FileLocation
      Get
         Return Me.assembly_
      End Get
   End Property


   Protected application_ As Rae.Io.FileLocation
   ''' <summary>File information about the calling application.</summary>
   ReadOnly Property Application As Rae.Io.FileLocation
      Get
         Return Me.application_
      End Get
   End Property

#End Region


#Region " Public methods"

   Private Shared instance As Locations
   ''' <summary>Creates an instance of locations relative to this assembly.</summary>
   Shared Function Create() As Locations
      If instance Is Nothing Then
         instance = New Locations()
      End If
      Return instance
   End Function


   ''' <summary>
   ''' Searches for file with the file name specified in the parameter.
   ''' Returns null if file not found.
   ''' </summary>
   ''' <param name="fileName">
   ''' Name of file to search for
   ''' </param>
   Public Overloads Function SearchForFile(ByVal fileName As String) As String
      Return SearchForFile(fileName, New List(Of String))
   End Function

   ''' <summary>
   ''' Searches for file with the file name specified; also searches specified sub directory. Returns null if file not found.
   ''' </summary>
   ''' <param name="fileName">
   ''' Name of file to search for
   ''' </param>
   ''' <param name="locationToSearch">
   ''' Sub directory (eg Datasources\Databases) or complete directory path (eg c:\) to search.
   ''' </param>
   Public Overloads Function SearchForFile(ByVal fileName As String, ByVal locationToSearch As String) As String
      Return SearchForFile(fileName, New List(Of String)(New String() {locationToSearch}))
   End Function

   ''' <summary>
   ''' Searches for file with the file name specified; also searches specified sub directories. Returns null if file not found.
   ''' </summary>
   ''' <param name="fileName">
   ''' Name of file to search for
   ''' </param>
   ''' <param name="locationsToSearch">
   ''' Sub directories (eg Datasources\Databases) or complete directory paths (eg c:\) to search.
   ''' </param>
   Public Overloads Function SearchForFile(ByVal fileName As String, ByVal locationsToSearch As IList(Of String)) As String
      Dim baseDirectories As List(Of String) = Me.getBaseDirectories()

      Dim filePath As String
      For Each baseDirectory As String In baseDirectories
         ' searches base directory
         filePath = Path.Combine(baseDirectory, fileName) : System.Console.WriteLine(filePath)
         If File.Exists(filePath) Then
            Return filePath
         End If

         ' searches user specified locations
         filePath = Me.searchLocationsToSearch(fileName, baseDirectory, locationsToSearch)
         If filePath IsNot Nothing Then
            Return filePath
         End If

         ' searches up a directory
         filePath = Path.Combine(baseDirectory, fileName)
         If filePath.IndexOf("\", filePath.IndexOf("\")) > -1 Then
            Dim upDirectory As String = Directory.GetParent(filePath).Parent.FullName
            filePath = Me.searchLocationsToSearch(fileName, upDirectory, locationsToSearch)
            If filePath IsNot Nothing Then
               Return filePath
            End If
         End If
      Next

      Return Nothing
   End Function

#End Region


#Region " Private methods"

   ''' <summary>
   ''' Hides constructor; this is a singleon class.
   ''' </summary>
   Private Sub New()
      Me.initialize()
   End Sub


   Private Sub initialize()
      Dim assemblyPath As String = System.Reflection.Assembly.GetExecutingAssembly().Location
      Me.assembly_ = New Rae.Io.FileLocation(assemblyPath)

      Dim applicationPath As String = Path.Combine(My.Application.Info.DirectoryPath, My.Application.Info.AssemblyName & ".exe")
      Me.application_ = New Rae.Io.FileLocation(applicationPath)

      'projectsDirectory_ = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) & "\Visual Studio 2005\Projects\"

   End Sub


   Private Function searchLocationsToSearch( _
   ByVal fileName As String, ByVal baseDirectory As String, ByVal subDirectories As IList(Of String)) As String
      Dim filePath As String

      For Each subDirectory As String In subDirectories
         If isCompletePath(subDirectory) Then
            subDirectory = modifyDrivePath(subDirectory)
            filePath = Path.Combine(subDirectory, fileName)
         Else
            filePath = Path.Combine(Path.Combine(baseDirectory, subDirectory), fileName) : System.Console.WriteLine(filePath)
         End If
         If File.Exists(filePath) Then
            Return filePath
         End If
      Next

      Return Nothing
   End Function


   ''' <summary>
   ''' Modifies a drive path entered like C: to C:\ because Path.Combine does not handle this
   ''' </summary>
   Public Function modifyDrivePath(ByVal drivePath As String) As String
      If drivePath.Length = 2 _
      AndAlso drivePath.Chars(1) = ":"c Then
         drivePath = drivePath & "\"
      End If

      Return drivePath
   End Function


   Private Function isCompletePath(ByVal path As String) As Boolean
      Dim isComplete As Boolean

      If path.Length >= 2 Then
         ' checks if is in format of network path -- \\<network path>
         If path.StartsWith("//") Then
            isComplete = True

            ' checks if is in format of local path -- <Hard Drive Letter>:\ eg c:\
         ElseIf path.Chars(1) = ":"c Then ' AndAlso path.Chars(2) = "\"c 
            isComplete = True
         End If
      End If

      Return isComplete
   End Function


   Private Function getBaseDirectories() As List(Of String)
      Dim debugDirectory As String = Me.application_.DirectoryPath.Replace("\Debug", "").Replace("bin\", "").Replace("bin", "")

      Dim baseDirectoriesToSearch As New List(Of String)()
      ' adds application directory
      baseDirectoriesToSearch.Add(Me.application_.DirectoryPath)

      ' adds debug directory if it is different than application directory
      If debugDirectory <> Me.application_.DirectoryPath Then
         baseDirectoriesToSearch.Add(debugDirectory)
      End If

      ' adds assembly directory if it different than application directory
      If Me.assembly_.DirectoryPath <> Me.application_.DirectoryPath Then
         baseDirectoriesToSearch.Add(Me.assembly_.DirectoryPath)
      End If

      Return baseDirectoriesToSearch
   End Function

#End Region

End Class

End Namespace