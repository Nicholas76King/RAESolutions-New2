Imports System
Imports Forms = System.Windows.Forms
Imports Rae.RaeSolutions.Business
Imports Rae.RaeSolutions.Business.Entities
imports rae.solutions

''' <summary>Contains information about application (e.g. user, connectivity, file paths).</summary>
Public Class AppInfo

   ' TODO: move data access
   ' database provider
   Private Const dbProvider As String = "Microsoft.Jet.OleDb.4.0"

   ' file checked to see if RAE network is available
    '    Private Shared connectivityFilePath As String = "\\" & Constants.FILESERVER1_INTERNAL_IP & "\FileSer1_E\Program Files\RAESolutions\logs\usageLog.xml"
    Private Shared connectivityFilePath As String = "\\FILESERVER1A\FileSer1_E\UpdateControl\RAESolutions\RaeSolutions.exe"


    '\\FILESERVER1A\FileSer1_E\UpdateControl\RAESolutions\RaeSolutions.exe


#Region " Declarations"
   Private Shared _appFolderPath As String       'application path (startup path)
   Private Shared m_division As Division = Division.NotSet   'division name for login
   Private Shared m_product As String = My.Application.Info.ProductName
   Private Shared m_appDataPath As String = ""
   Private Shared m_user As user
   Private Shared m_serverDbFolderPath As String
   Private Shared m_dbFolderPath As String
    Private Shared m_buzzFolderPath As String
    Private Shared m_isLoggedIn As Boolean
   Private Shared m_main As MainForm
#End Region


#Region " Properties"

   ''' <summary>Reference to main form.</summary>
   Shared Property Main As MainForm
      Get
         Return m_main
      End Get
      Set(value As MainForm)
         m_main = value
      End Set
   End Property


   ''' <summary>Logged in user's profile</summary>
   Shared Property User As user
      Get
         Return m_user
      End Get
      Set(value As user)
         m_user = value
      End Set
   End Property


   ''' <summary>True if a user has logged in to the application.</summary>
   Shared Property IsLoggedIn As Boolean
      Get
         Return m_isLoggedIn
      End Get
      Set(value As Boolean)
         m_isLoggedIn = value
      End Set
   End Property


   ''' <summary>Application data path without the version folder</summary>
   ''' <value>Application data path without the version folder</value>
   ''' <remarks>Does not include the version folder and ends with a forward slash</remarks>
   Shared ReadOnly Property AppDataPath As String
      Get
         Return AppInfo.m_appDataPath
      End Get
   End Property

   ''' <summary>Application's folder. Ends with a back slash (\).</summary>
   Shared Property AppFolderPath As String
      Get
         Return _appFolderPath
      End Get
      Set(value As String)
         _appFolderPath = value
      End Set
   End Property

   ''' <summary>Database folder in application folder. Contains majority of local databases.</summary>
   Shared ReadOnly Property DbFolderPath As String
      Get
         Return m_dbFolderPath
      End Get
   End Property

    ''' <summary>Database folder in application folder. Contains majority of local databases.</summary>
    Shared ReadOnly Property BuzzFolderPath As String
        Get
            Return m_buzzFolderPath
        End Get
    End Property




   private shared _image_folder_path as string
   shared readonly property image_folder_path as string
      get
         return _image_folder_path
      end get
   end property

    ' ''' <summary>Path to the database folder on the server.</summary>
    'Shared ReadOnly Property ServerDbFolderPath As String
    '   Get
    '      If m_serverDbFolderPath Is Nothing Then
    '         ' initializes
    '         m_serverDbFolderPath = "\\" & Constants.FILESERVER1_INTERNAL_IP & "\FileSer1_e\RAE Data\Database\"
    '      End If

    '      Return m_serverDbFolderPath
    '   End Get
    'End Property
   
    ' ''' <summary>FTP address on Fileserver1a.</summary>
    'Shared ReadOnly Property FileserverFTPAddress As String
    '   Get
    '      If AppInfo.NetworkConnectivity = Connectivity.Connected Then
    '         Return Constants.FILESERVER1A_INTERNAL_IP
    '      ElseIf AppInfo.NetworkConnectivity = Connectivity.Disconnected Then
    '         Return Constants.FILESERVER1A_EXTERNAL_IP
    '      End If
    '   End Get
    'End Property



   ''' <summary>Product name specified in assembly info</summary>
   ''' <value>Product name</value>
   ''' <remarks>This value is cached; only a single instance of AssemblyInfo is constructed.</remarks>
   Shared ReadOnly Property Product As String
      Get
         Return m_product
      End Get
   End Property


    ''' <summary>Determines if RAE's network is available.</summary>
    Shared ReadOnly Property network_is_available As Boolean
        Get
            Return New System.IO.FileInfo(connectivityFilePath).Exists
        End Get
    End Property


    ''' <summary>Indicates whether RAE's network is available.</summary>
    Shared ReadOnly Property NetworkConnectivity As Connectivity
        Get
            If AppInfo.network_is_available Then
                Return Connectivity.Connected
            Else
                Return Connectivity.Disconnected
            End If
        End Get
    End Property


   ''' <summary>Division (company) of RAE Corporation.</summary>
    Shared Property Division() As Division
        Get
            Return m_division
        End Get
        Set(ByVal value As Division)
            m_division = value
        End Set
    End Property

#End Region


#Region " Public Methods"

   ''' <summary>Initializes application info. Should Initialize() before using.</summary>
   Shared Sub Initialize()
      'sets application path
      '- during debug files are in bin\debug folder
      '- during deploy files are in raesolutions folder
        If Constants.COMPILE_CONFIG = Constants.compiled_configuration.debug Then 'debug
            Dim appFolder As New Location(Application.StartupPath)
            _appFolderPath = appFolder.Up.Up.Path
        ElseIf Constants.COMPILE_CONFIG = Constants.compiled_configuration.release Then 'release
            _appFolderPath = Application.StartupPath & "\"
        End If





        If Constants.TARGET_USER_GROUP = user_group.rep Then
            m_dbFolderPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            If Not (m_dbFolderPath).EndsWith("\") Then m_dbFolderPath &= "\"
            m_dbFolderPath &= "RAESolutions\Databases\"
        Else
            m_dbFolderPath = _appFolderPath & "Databases\"
        End If


        If Constants.TARGET_USER_GROUP = user_group.rep Then
            m_buzzFolderPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            If Not (m_buzzFolderPath).EndsWith("\") Then m_buzzFolderPath &= "\"
            m_buzzFolderPath &= "RAESolutions\BuzzData\"
        Else
            m_buzzFolderPath = _appFolderPath & "BuzzData\"
        End If



        'Else

        'm_dbFolderPath = My.Settings.CustomDataFilePath
        'If Not (m_dbFolderPath).EndsWith("\") Then m_dbFolderPath &= "\"
        'm_dbFolderPath &= "Databases\"

        'End If



        _image_folder_path = AppFolderPath & "images\"

        AppInfo.m_appDataPath = AppInfo.getAppDataPath()

        ' ACME setup is now part of installer.

        'Dim acme = New acme_setup(AppFolderPath)
        'If acme.is_not_installed Then
        '   acme.install()
        'End If

        Ui.MessageBox.Caption = My.Application.Info.ProductName

        User = New user()
        ' sets authority group to rep initially so that rep won't attempt to login as an employee
        User.authority_group = user_group.rep
    End Sub

#End Region


#Region " Private Methods"

   ''' <summary>Prevents the class from being constructed. All members are shared.</summary>
   Private Sub New()
   End Sub


   ''' <summary>Gets path to the the user's application data folder, 
   ''' C:\Documents and Settings\Username\Application Data\Company\Application\Version.
   ''' </summary>
   ''' <returns>Path to user's application data folder</returns>
   ''' <remarks>
   ''' <para>Application data path as returned by Application.UserAppDataPath:
   '''  C:\Documents and Settings\Username\Application Data\[Company]\[Application]\[Version]
   ''' </para>
   ''' <para>Application data path as returned by this function:
   '''  C:\Documents and Settings\[Username]\Application Data\[Company]\[Application]\
   ''' </para>
   ''' <para>Notice the version folder is not included and the path ends with a slash
   ''' </para>
   ''' </remarks>
   Private Shared Function getAppDataPath() As String
      ' user application data path
      'C:\Documents and Settings\<Username>\Application Data\<Company>\<Application>\<Version>

      'sets last index of slash
      Dim slash = Application.UserAppDataPath.LastIndexOf("\")
      'number of characters in path
      Dim pathLength = Application.UserAppDataPath.Length
      'removes <Version> from path
      Dim applicationDataCompanyPath = Application.UserAppDataPath.Remove(slash + 1, pathLength - (slash + 1))

      Return applicationDataCompanyPath
   End Function

#End Region


End Class
