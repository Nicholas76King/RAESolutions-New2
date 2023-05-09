Option Strict On

Imports Rae.RaeSolutions.Business
Imports rae.solutions


Public Class Constants


#Region " Configuration likely to change"

    Public Const DATAACCESS_CONFIG As Rae.Data.DataObjects.DataAccessTypes = Rae.Data.DataObjects.DataAccessTypes.OleDb




    ' ERICC
    ' blarg

    ''' <summary>
    ''' Determines the target user group that the application is built for.
    ''' This is set at design time and doesn't change depending on who's logged in.
    ''' </summary>
    ''' <remarks>
    ''' Example: Determines whether downloaded password database will contain employee info.
    ''' </remarks>
    Public Const TARGET_USER_GROUP As user_group = user_group.rep
    'Public Const COMPILE_AS_CONTRACTOR_VERSION As Boolean = False
    Public Const COMPILE_CONFIG As compiled_configuration = compiled_configuration.release

    ''' <summary>Date software expires. Software will not run after expiration date.</summary>
    Public Const EXPIRATION_DATE As Date = #3/3/2025#
    ' Be sure day matches month.  This "fixes" our Quebec friends.  Kind of.

    ''' <summary>Indicates whether build will allow access to air handler pricing.</summary>
    Public Const AIR_HANDLER_PRICING_AUTHORIZED As Boolean = False

#End Region


#Region " Configuration less likely to change"


    Public Enum compiled_configuration As Integer
        debug
        release
    End Enum

   ''' <summary>
   ''' Path to file containing expiration status. Path is undocumented to prevent deletion.
   ''' </summary>
    'Public Const EXPIRATION_FILE_PATH As String = "C:\RSES.dat"


   ''' <summary>
   ''' Name of file containing list of application files to update. Applies to the updater used inhouse.
   ''' </summary>
    'Public Const INHOUSE_UPDATER_FILE_NAME As String = "RAE_Solutions.txt"

   ''' <summary>
   ''' Name of file containing list of files to update. Applies to the updater used inhouse.
   ''' </summary>
    ' Public Const INHOUSE_UPDATER_UPDATE_FILES_FILE_NAME As String = "RAE_Solutions.FO"

   ''' <summary>
   ''' Indicates whether program is in test mode.
   ''' </summary>
   ''' <remarks>
   ''' Affects whether the reports have a test watermark.
   ''' </remarks>
    'Public Const TESTING As Boolean = False


   ''' <summary>
   ''' IP address for Fileserver1a when accessing server while connected to RAE's network.
   ''' </summary>
    'Public Const FILESERVER1A_INTERNAL_IP As String = "199.5.85.253"


   ''' <summary>
   ''' IP address of Fileserver1a when accessing server while disconnected from RAE's network
   ''' </summary>
    'Public Const FILESERVER1A_EXTERNAL_IP As String = "12.5.173.75"   '"68.88.115.111"


   ''' <summary>
   ''' IP Address of Fileserver1 when accessing server while connected to RAE's network.
   ''' </summary>
   ''' <remarks>
   ''' frmLogin - used for ftp access (maps to fileserver1a\fileser1_E\ftp) to download password database
   ''' frmAvailability - to get latest version
   ''' frmMain - checks if update is available
   ''' </remarks>
    Public Const FILESERVER1_INTERNAL_IP As String = "199.5.85.159"


   ''' <summary>
   ''' Link to version history document.
   ''' </summary>
    'Public Const VERSION_HISTORY_LINK As String = "http://www.rae-corp.net/raesolutions-version-history.mht"

#End Region

End Class

