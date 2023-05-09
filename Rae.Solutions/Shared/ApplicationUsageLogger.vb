Namespace Diagnostics.UsageLog

   ''' Project	 : RAESolutions
   ''' Class	 : ApplicationUsageLogger
   ''' 
   ''' -----------------------------------------------------------------------------
   ''' <summary>
   ''' Logs application usage statistics.
   ''' </summary>
   ''' <remarks>
   ''' </remarks>
   ''' <history>
   ''' 	[CASEYJ]	3/9/2005	Created
   ''' </history>
   Public Class ApplicationUsageLogger
      Inherits LoggerBase

#Region " Declarations"

      'Private Shared _logFile As IO.FileInfo
      Private Shared _applicationID As Integer = -1

#End Region


#Region " Properties"

      ''' <summary>
      ''' Unique identifier that can be used to access the row associated with an instance of the class.
      ''' </summary>
      ''' <value>Integer that uniquely identifies application instance.</value>
      ''' <remarks>
      ''' Use ApplicationUsage.FindByApplicationID to get associated row.
      ''' </remarks>
      ''' <history>
      ''' 	[CASEYJ]	3/9/2005	Created
      ''' </history>
      Public Shared ReadOnly Property ApplicationID() As Integer
         Get
            Return _applicationID
         End Get
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
         MyBase.New(logFilePath)
      End Sub


      ''' -----------------------------------------------------------------------------
      ''' <summary>
      ''' Locally logs the time the that the application starts.
      ''' </summary>
      ''' <param name="username">Current username logged into application.</param>
      ''' <remarks>
      ''' </remarks>
      ''' <history>
      ''' 	[CASEYJ]	3/9/2005	Created
      ''' </history>
      ''' -----------------------------------------------------------------------------
      Public Sub LogApplicationStart(ByVal username As String)
         Dim dseUsage1 As dseUsage
         Dim row As dseUsage.ApplicationUsageRow

         dseUsage1 = New dseUsage

         'reads any existing local log entries (waiting to be logged remotely)
         Try
            dseUsage1.ReadXml(Me.LogFile.FullName)
         Catch xmlEx As Xml.XmlException
            '>> will write over file if there is an exception
            '>> any previous data will be lost
         End Try

         'creates a new log entry
         With dseUsage1.ApplicationUsage
            'creates new row
            row = .NewApplicationUsageRow
            'sets application start time
            row(.StartTimeColumn) = Date.Now
            'sets application end time
            row(.EndTimeColumn) = Date.Now
            'sets username
            row(.UsernameColumn) = username
            'adds row
            .Rows.Add(row)
         End With

         'logs application's start time to local file
         dseUsage1.WriteXml(Me.LogFile.FullName)

         '>> gets application id; stored so editions can be made to row later
         '>> a new application id will be assigned when stored remotely; this
         '   is just kept in order to retrieve row while stored locally
         Me._applicationID = row.ApplicationID
      End Sub


      ''' -----------------------------------------------------------------------------
      ''' <summary>
      ''' Locally logs the time the application ends.
      ''' </summary>
      ''' <remarks>
      ''' If application closes without Closing event occuring, then the logged start 
      ''' and end times will be the same.
      ''' </remarks>
      ''' <history>
      ''' 	[CASEYJ]	3/9/2005	Created
      ''' </history>
      ''' -----------------------------------------------------------------------------
      Public Sub LogApplicationEnd()
         Dim dseUsage1 As dseUsage
         Dim row As dseUsage.ApplicationUsageRow

         dseUsage1 = New dseUsage

         With dseUsage1
            'reads any existing local log entries (waiting to be logged remotely)
            .ReadXml(Me.LogFile.FullName)
            'gets row the row associated with this instance
            row = .ApplicationUsage.FindByApplicationID(Me.ApplicationID)
            'sets the time the application ended
            row(.ApplicationUsage.EndTimeColumn) = Date.Now
            'writes log
            .WriteXml(Me.LogFile.FullName)
         End With
      End Sub


#End Region

   End Class
End Namespace