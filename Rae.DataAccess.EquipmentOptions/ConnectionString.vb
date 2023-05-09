Imports System.Text
Imports System.Data

Namespace Rae.DataAccess.EquipmentOptions

   ''' <summary>
   ''' Provides connection string information.
   ''' </summary>
   ''' <remarks>
   ''' Call Initialize(dbFolderPath) before using any of the other data access methods in this assembly.
   ''' Uses default database location when public method Initialize hasn't been called which is useful for testing and debugging.
   ''' Uses specified database folder path when Initialize is called which is useful for release version.
   ''' </remarks>
   Public Class ConnectionString

      Public Shared dbName As String = "EquipmentOptions.mdb"
      Private Shared dbPath As String = ".\Databases\" & dbName
      Private Shared dllPath As String = "C:\Code\Rae\Solutions\Main\Rae.Solutions"
      Private Shared isInitialized As Boolean = False

      Private Shared m_provider As String = "Microsoft.Jet.OleDb.4.0"
      Private Shared m_text As String
      Private Shared m_dataSource As String

      Private Shared m_dataaccesstype As Rae.Data.DataObjects.DataAccessTypes = Rae.Data.DataObjects.DataAccessTypes.OleDb

#Region " Properties"

      ''' <summary>EquipmentOptions database connection string
      ''' </summary>
      Public Shared ReadOnly Property Text() As String
         Get
            ' initializes properties if they are not already
            If isInitialized = False Then
               Initialize()
            End If
            Return m_text
         End Get
      End Property


      ''' <summary>Data source (database path)
      ''' </summary>
      Public Shared ReadOnly Property DataSource() As String
         Get
            ' initializes properties if they are not already
            If isInitialized = False Then
               Initialize()
            End If
            Return m_dataSource
         End Get
      End Property


      ''' <summary>Database provider
      ''' </summary>
      Public Shared ReadOnly Property Provider() As String
         Get
            Return m_provider
         End Get
      End Property

      Public Shared ReadOnly Property DataAccessType() As Rae.Data.DataObjects.DataAccessTypes
         Get
            Return m_dataaccesstype
         End Get
      End Property

#End Region


      ''' <summary>
      ''' Initializes assembly by setting connection string. 
      ''' Must call this before using any of the assemblies data access methods.
      ''' </summary>
      ''' <param name="dbFolderPath">
      ''' Database path of EquipmentOptions.mdb.
      ''' </param>
      ''' <remarks>
      ''' This should be used during release version.
      ''' </remarks>
      ''' <history by="Casey Joyce" finish="2006/05/05">
      ''' Added
      ''' </history>
      Overloads Shared Sub Initialize(dbFolderPath As String)
         SetDataAccessType(Data.DataObjects.DataAccessTypes.OleDb)
         m_dataSource = System.IO.Path.Combine(dbFolderPath, dbName)

         setConnectionString(m_dataSource)

         isInitialized = True
      End Sub

      Overloads Shared Sub InitializeTest(dbFilePath As String)
         setConnectionString(dbFilePath)
         
         isInitialized = True
      End Sub

      ''' <summary>
      ''' Initializes assembly by setting DataAccessType which then points to use SQL connection string
      ''' </summary>
      Public Overloads Shared Sub Initialize(dbFolderPath As String, datype As Rae.Data.DataObjects.DataAccessTypes)
         If datype = Data.DataObjects.DataAccessTypes.OleDb Then
            Initialize(dbFolderPath)
            Exit Sub
         End If
         m_dataSource = dllPath & dbPath.Remove(0, 1)
         SetDataAccessType(datype)
         If DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
            Dim rdr As New System.Configuration.AppSettingsReader
            Dim conn As String = rdr.GetValue("local", System.Type.GetType("System.String")).ToString()
            m_text = conn
         Else
            setConnectionString(m_dataSource)
         End If
         isInitialized = True
      End Sub

      
      ''' <summary>Initializes assembly by setting connection string. Default.</summary>
      ''' <remarks>This will be used by default if the Public Initialize(dbPath) has not be called.</remarks>
      Private Overloads Shared Sub initialize()
         ' sets data source (database path), database should be in database folder inside dll's folder
         m_dataSource = dllPath & dbPath.Remove(0, 1)
         SetDataAccessType(Data.DataObjects.DataAccessTypes.OleDb)
         setConnectionString(m_dataSource)

         isInitialized = True
      End Sub

      ''' <summary>Sets connection string for the specified data source.</summary>
      ''' <param name="dataSource">Path to database.</param>
      Private Shared Sub setConnectionString(dataSource As String)
         Dim connectionString As New StringBuilder

         ' sets connection string for EquipmentOptions database
         connectionString.AppendFormat("provider={0}; data source={1};", _
            m_provider, dataSource)
         ' sets Text property to connection string
         m_text = connectionString.ToString
         m_dataSource = dataSource
      End Sub

      Private Shared Sub SetDataAccessType(ByVal datype As Rae.Data.DataObjects.DataAccessTypes)
         ' sets DataAccessType for EquipmentOptions database
         m_dataaccesstype = datype
      End Sub

   End Class

End Namespace


      '''' <summary>
      '''' Initializes assembly by setting DataAccessType which then points to use SQL connection string
      '''' </summary>
      'Public Overloads Shared Sub Initialize(ByVal datype As Rae.Data.DataObjects.DataAccessTypes)
      '   m_dataSource = dllPath & dbPath.Remove(0, 1)
      '   SetDataAccessType(datype)
      '   If DataAccessType = Data.DataObjects.DataAccessTypes.SQL Then
      '      Dim rdr As New System.Configuration.AppSettingsReader
      '      Dim conn As String = rdr.GetValue("local", System.Type.GetType("System.String")).ToString()
      '      m_text = conn
      '   Else
      '      SetConnectionString(m_dataSource)
      '   End If
      '   isInitialized = True
      'End Sub
