Imports System.IO
Imports Rae.RaeSolutions.DataAccess.Common
Imports Rae.solutions

Namespace Rae.RaeSolutions.Business.Entities

    ''' <summary>
    ''' Protects user data. Prevents user data from being overwritten during updates.
    ''' </summary>
    ''' <history by="Casey Joyce" finish="2006/06/09">
    ''' Created, design pattern (master folder) per Danny Groom.
    ''' </history>
    Public Class UserDataProtector

        ''' <summary>
        ''' Ensures file exists. 
        ''' If file does not exists, an empty file with the correct structure is copied from the master folder.
        ''' </summary>
        ''' <param name="expectedFilePath">
        ''' Path of the file to ensure exists. Path where the file is or will be copied (from master folder).
        ''' </param>
        ''' <remarks>
        ''' A master file must be in the master folder and have the same name as the expected file for this method to work.
        ''' </remarks>
        Public Shared Sub EnsureFileExists(ByVal expectedFilePath As String, ByVal userGroup As Rae.solutions.user_group)
            Dim expectedFile As New FileInfo(expectedFilePath)

            ' checks if file exists in expected location
            If Not expectedFile.Exists AndAlso Rae.RaeSolutions.DataAccess.Common.DataAccessType = Data.DataObjects.DataAccessTypes.OleDb Then
                ' copies master file from master folder to the expected location

                Dim oldProjectsPath As String = AppFolderPath & "Databases\" & expectedFile.Name

                If File.Exists(oldProjectsPath) AndAlso userGroup = user_group.rep Then
                    File.Copy(oldProjectsPath, expectedFilePath, False)
                Else
                    File.Copy(Path.Combine(MasterFolderPath, expectedFile.Name), expectedFilePath, False)
                End If



            End If
        End Sub


        ''' <summary>
        ''' Ensures folder exists.
        ''' </summary>
        ''' <param name="expectedFolderPath">
        ''' Path of the expected folder.
        ''' </param>
        Public Shared Sub EnsureFolderExists(ByVal expectedFolderPath As String)
            Dim folder As New DirectoryInfo(expectedFolderPath)

            If Not folder.Exists Then
                folder.Create()
            End If
        End Sub

    End Class

End Namespace