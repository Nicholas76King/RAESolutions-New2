''' -----------------------------------------------------------------------------
''' Project	 : RAESolutions
''' Class	 : RAESolutions.LoggerBase
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Base class for loggers.
''' </summary>
''' <remarks>
''' Provides methods to get the log and delete the log.
''' </remarks>
''' <history>
''' 	[CASEYJ]	3/14/2005	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class LoggerBase


#Region " Declarations"

   Private Shared _logFile As System.IO.FileInfo

#End Region


#Region " Properties"

   ''' -----------------------------------------------------------------------------
   ''' <summary>
   ''' File information for the application usage log.
   ''' </summary>
   ''' <value>File information for the application usage log.</value>
   ''' <remarks>
   ''' Provides file information such as:
   ''' <para>* file existance</para>
   ''' <para>* file size</para>
   ''' <para>* file extension, directory, filename, etc.</para>
   ''' </remarks>
   ''' <history>
   ''' 	[CASEYJ]	3/9/2005	Created
   ''' </history>
   ''' -----------------------------------------------------------------------------
   Shared Property LogFile() As System.IO.FileInfo
      Get
         Return _logFile
      End Get
      Set(ByVal Value As System.IO.FileInfo)
         _logFile = Value
      End Set
   End Property

#End Region


#Region " Public Methods"

   ''' -----------------------------------------------------------------------------
   ''' <summary>
   ''' Ensures the log file exists.
   ''' </summary>
   ''' <param name="logFilePath"></param>
   ''' <remarks>
   ''' If log does not exist, a new log is created with the appropriate initial text.
   ''' </remarks>
   ''' <history>
   ''' 	[CASEYJ]	3/9/2005	Created
   ''' </history>
   ''' -----------------------------------------------------------------------------
   Public Sub New(ByVal logFilePath As String)
      'sets log file
      _logFile = New System.IO.FileInfo(logFilePath)
      'creates log if it does not exist
      Me.EnsureLogExist()
   End Sub

   ''' -----------------------------------------------------------------------------
   ''' <summary>
   ''' Basic constructor.
   ''' </summary>
   ''' <remarks>
   ''' Does not contain any code. Helps prevent error during inheritance.
   ''' </remarks>
   ''' <history>
   ''' 	[CASEYJ]	3/14/2005	Created
   ''' </history>
   ''' -----------------------------------------------------------------------------
   Public Sub New()

   End Sub


   ''' -----------------------------------------------------------------------------
   ''' <summary>
   ''' Returns a dataset with the log data.
   ''' </summary>
   ''' <returns>Returns a dataset with the log data</returns>
   ''' <remarks>
   ''' The data includes application and form usage as well as user information.
   ''' </remarks>
   ''' <history>
   ''' 	[CASEYJ]	3/10/2005	Created
   ''' </history>
   ''' -----------------------------------------------------------------------------
   Public Overridable Function GetLog() As dseUsage
      Dim dseUsage1 As dseUsage

      'initializes dataset
      dseUsage1 = New dseUsage

      'reads xml file data into dataset
      dseUsage1.ReadXml(Me.LogFile.FullName)

      'returns dataset with the locallly stored log entries
      Return dseUsage1
   End Function


   ''' <summary>Deletes local log file.
   ''' </summary>
   ''' <remarks>
   ''' Delete the local file after its entries have been copied to a remote 
   ''' database; otherwise, redundant log entries will be stored remotely.
   ''' </remarks>
   ''' <history>[CASEYJ]	3/10/2005	Created
   ''' </history>
   Public Overridable Sub DeleteLog()
      If System.IO.File.Exists(LogFile.FullName) Then
         System.IO.File.Delete(LogFile.FullName)
      End If
   End Sub

#End Region


#Region " Private Methods"

   ''' -----------------------------------------------------------------------------
   ''' <summary>
   ''' Creates log if it does not exist.
   ''' </summary>
   ''' <remarks>
   ''' Used by New method.
   ''' </remarks>
   ''' <history>
   ''' 	[CASEYJ]	3/9/2005	Created
   ''' </history>
   ''' -----------------------------------------------------------------------------
   Protected Sub EnsureLogExist()
      'checks if log exists
      If Not LogFile.Exists Then
         Dim logCreator As System.IO.FileStream
         Dim log As System.IO.FileInfo
         Dim writer As System.IO.StreamWriter

         'creates log
         logCreator = New System.IO.FileStream(LogFile.FullName, System.IO.FileMode.CreateNew)
         'closes log so that it can be accessed later
         logCreator.Close()

         'initializes log file information
         log = New System.IO.FileInfo(LogFile.FullName)
         'tells writer which file to write to
         writer = log.AppendText

         'writes xml
         writer.WriteLine("<?xml version=1.0 standalone=yes ?>")
         writer.WriteLine("<dseUsage xmlns=http://tempuri.org/dseUsage.xsd >")
         writer.WriteLine("</dseUsage>")
         'finishes writing
         writer.Flush()
         'closes writer
         writer.Close()

      End If
   End Sub

#End Region


End Class
