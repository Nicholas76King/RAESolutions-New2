Imports System.Text


Namespace IntegratedSecurity

   ''' <summary>
   ''' Provides connection string information.
   ''' </summary>
   ''' <remarks>
   ''' Call Initialize(dbFolderPath) before using any of the other data access methods in this assembly.
   ''' Uses default database location when public method Initialize hasn't been called which is useful for testing and debugging.
   ''' Uses specified database folder path when Initialize is called which is useful for release version.
   ''' </remarks>
   Public Class ConnectionString

      ''' <summary>
      ''' Database file name.
      ''' </summary>
      Public Const dbName As String = "UserNamePassword_Encrypted.mdb"
      Private Const m_provider As String = "Microsoft.Jet.OleDb.4.0"

      ' for testing

      ''' <summary>
      ''' Relative path beginning in testDllPath's folder.
      ''' </summary>
      Private Shared testDbPath As String = ".\Databases\" & dbName
      ''' <summary>
      ''' Default path of this assembly, used during testing.
      ''' </summary>
      Private Const testDllPath As String = "C:\Documents and Settings\CaseyJ\My Documents\Visual Studio 2005\Projects\RAESolutions"

      Private Shared isInitialized As Boolean
      Private Shared m_text As String
      Private Shared m_dataSource As String

#Region " Properties"

      ''' <summary>
      ''' Login database connection string
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

#End Region


      ''' <summary>
      ''' Initializes assembly by setting connection string. 
      ''' Must call this before using any of the assemblies data access methods.
      ''' </summary>
      ''' <param name="dbFolderPath">
      ''' Database path of login.
      ''' </param>
      ''' <remarks>
      ''' This should be used during release version.
      ''' </remarks>
      Public Overloads Shared Sub Initialize(ByVal dbFolderPath As String)
         m_dataSource = System.IO.Path.Combine(dbFolderPath, dbName)

         SetConnectionString(m_dataSource)

         isInitialized = True
      End Sub




      ''' <summary>
      ''' Initializes assembly by setting connection string. Default.
      ''' </summary>
      ''' <remarks>
      ''' This will be used by default if the Public Initialize(dbPath) has not be called.
      ''' </remarks>
      Private Overloads Shared Sub Initialize()
         ' sets data source (database path), database should be in database folder inside dll's folder
         m_dataSource = testDllPath & testDbPath.Remove(0, 1)

         SetConnectionString(m_dataSource)

         isInitialized = True
      End Sub


      ''' <summary>
      ''' Sets connection string for the specified data source.
      ''' </summary>
      ''' <param name="dataSource">
      ''' Database file path.
      ''' </param>
      Private Shared Sub SetConnectionString(ByVal dataSource As String)
         Dim connectionString As New StringBuilder

         ' sets connection string for EquipmentOptions database
         connectionString.AppendFormat("provider={0}; data source={1};", _
            m_provider, dataSource)
         ' sets Text property to connection string
         m_text = connectionString.ToString
      End Sub

   End Class

End Namespace