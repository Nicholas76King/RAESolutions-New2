''' <summary>
''' Strings used in application.
''' </summary>
''' <history by="Casey Joyce" start="2006/08/08">
''' Created
''' </history>
Public Class Strings


    Public Const ApplicationExpired As String = "Software is expired. " & _
         "You may request the latest version from your sales contact at RAE Corporation."

    Public Const ProjectAlreadyOpen As String = _
       "A project is already open. Please close the open project before opening a new project."

    Public Const ProjectNotOpen As String = _
       "A project must be open before creating equipment."

    Public Const Equipment As String = "Equipment"



    Public Shared Function ApplicationExpirationApproaching(ByVal numDaysUntilExpiration As Integer) As String
        Dim returnString As String = ""
        'if tsi
        If AppInfo.Division = 1 Then
            returnString = "This version of RAE Solutions will expire in " & numDaysUntilExpiration.ToString & " days. " & _
                "Please contact your TSI Salesperson or visit http://raecloud.com/RAESolutionsTSI to update."
        End If

        'if century
        If AppInfo.Division = 2 Then
            returnString = "This version of RAE Solutions will expire in " & numDaysUntilExpiration.ToString & " days. " & _
                "Please contact your Century Salesperson or visit http://raecloud.com/RAESolutions to update."
        End If

        Return returnString
        '"This version of " & AppInfo.Product & " will expire in " & numDaysUntilExpiration.ToString & " days. " & _
        '"You may check for updates under the Help menu or request the latest version from your sales contact at RAE Corporation."
    End Function


End Class
