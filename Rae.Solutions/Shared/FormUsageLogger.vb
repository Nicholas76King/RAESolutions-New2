Namespace Diagnostics.UsageLog


   ''' -----------------------------------------------------------------------------
   ''' Project	 : RAESolutions
   ''' Class	 : RAESolutions.Diagnostics.UsageLog.FormUsageLogger
   ''' 
   ''' -----------------------------------------------------------------------------
   ''' <summary>
   ''' Logs form usage statistics.
   ''' </summary>
   ''' <remarks>
   ''' </remarks>
   ''' <history>
   ''' 	[CASEYJ]	3/11/2005	Created
   ''' </history>
   ''' -----------------------------------------------------------------------------
   Public Class FormUsageLogger
      Inherits LoggerBase

#Region " Declarations"
      Dim _formID As Integer = -1
      Dim _applicationID As Integer = -1
#End Region


#Region " Properties"

      ''' -----------------------------------------------------------------------------
      ''' <summary>
      ''' Unique identifier to track application sessions.
      ''' </summary>
      ''' <value>Integer representing a unique identifier for the application session.
      ''' </value>
      ''' <remarks>
      ''' </remarks>
      ''' <history>
      ''' 	[CASEYJ]	3/15/2005	Created
      ''' </history>
      ''' -----------------------------------------------------------------------------
      Public Property ApplicationID() As Integer
         Get
            Return Me._applicationID
         End Get
         Set(ByVal Value As Integer)
            Me._applicationID = Value
         End Set
      End Property


      ''' -----------------------------------------------------------------------------
      ''' <summary>
      ''' Unique identifier to track form sessions.
      ''' </summary>
      ''' <value>Integer representing a unique identifier for a form session.</value>
      ''' <remarks>
      ''' </remarks>
      ''' <history>
      ''' 	[CASEYJ]	3/15/2005	Created
      ''' </history>
      ''' -----------------------------------------------------------------------------
      Public Property FormID() As Integer
         Get
            Return Me._formID
         End Get
         Set(ByVal Value As Integer)
            Me._formID = Value
         End Set
      End Property

#End Region


#Region " Public Methods"

      ''' -----------------------------------------------------------------------------
      ''' <summary>
      ''' Constructor for Form Usage Logger.
      ''' </summary>
      ''' <param name="applicationID">Unique identifier for application session.</param>
      ''' <param name="logFilePath">Path to the log file.</param>
      ''' <remarks>
      ''' Constructor creates FileInfo object for log file using the path for the log
      ''' file and sets the application ID.
      ''' </remarks>
      ''' <history>
      ''' 	[CASEYJ]	3/15/2005	Created
      ''' </history>
      ''' -----------------------------------------------------------------------------
      Public Sub New(ByVal applicationID As Integer, ByVal logFilePath As String)
         'calls the base class's constructor
         MyBase.New(logFilePath)
         'sets application ID
         Me._applicationID = applicationID
      End Sub


      ''' -----------------------------------------------------------------------------
      ''' <summary>
      ''' Locally logs the start time of the form specified in formName, and sets the
      ''' application usage logger property.
      ''' </summary>
      ''' <param name="startTime">Date and time that the form started.</param>
      ''' <remarks>
      ''' The application usage logger contains the application id and the log's file
      ''' path.
      ''' </remarks>
      ''' <history>
      ''' 	[CASEYJ]	3/11/2005	Created
      ''' </history>
      ''' -----------------------------------------------------------------------------
      Public Sub LogFormStart(ByVal formName As String)
         Dim dseUsage1 As dseUsage
         Dim row As dseUsage.FormUsageRow

         dseUsage1 = New dseUsage

         'reads existing log data; same log application usage logger is writing to
         dseUsage1.ReadXml(Me.LogFile.FullName)
         'adds new entry
         row = dseUsage1.FormUsage.NewFormUsageRow
         'sets form's start time
         row.StartTime = Date.Now
         'sets form's end time
         row.EndTime = Date.Now
         'sets application id
         row.ApplicationID = Me.ApplicationID
         'sets form name
         row.FormName = formName
         'sets company division
         row.Division = AppInfo.Division.ToString
         'adds row to dataset
         dseUsage1.FormUsage.Rows.Add(row)
         'writes dataset to local log (xml file)
         dseUsage1.WriteXml(Me.LogFile.FullName)
         'sets form id
         Me.FormID = row.FormID
      End Sub


      ''' -----------------------------------------------------------------------------
      ''' <summary>
      ''' Locally logs the rest of the form usage data.
      ''' </summary>
      ''' <param name="model">
      ''' The model selected when the form ends.
      ''' </param>
      ''' <param name="refrigerant">
      ''' The refrigerant selected when the form ends.
      ''' </param>
      ''' <param name="suctionTemperature">
      ''' The suction temperature entered when the form ends.
      ''' </param>
      ''' <param name="ambientTemperature">
      ''' The ambient temperature entered when the form ends.
      ''' </param>
      ''' <remarks>
      ''' Some of the usage data was logged during the LogFormStart method.
      ''' <para>This data can be used to analyze which forms are being used most, and
      ''' what specifications (such as temperature ranges) are commonly used.</para>
      ''' </remarks>
      ''' <history>
      ''' 	[CASEYJ]	3/11/2005	Created
      ''' </history>
      ''' -----------------------------------------------------------------------------
      Public Sub LogFormEnd( _
      ByVal model As String, _
      ByVal refrigerant As String, _
      ByVal suctionTemperature As Single, _
      ByVal ambientTemperature As Single)
         Dim dseUsage1 As dseUsage
         Dim row As dseUsage.FormUsageRow

         dseUsage1 = New dseUsage

         'reads existing usage log data
         dseUsage1.ReadXml(Me.LogFile.FullName)
         'gets the row associated with this form instance
         row = dseUsage1.FormUsage.Select("FormID = " & Me.FormID)(0)
         'adds the missing data to the row
         'sets end time
         row.EndTime = Date.Now
         'sets model
         row.Model = model
         'sets refrigerant
         row.Refrigerant = refrigerant
         'sets suction temperature
         row.SuctionTemperature = suctionTemperature
         'sets ambient temperature
         row.AmbientTemperature = ambientTemperature
         'writes dataset to local usage log (xml file)
         dseUsage1.WriteXml(Me.LogFile.FullName)
      End Sub

#End Region

   End Class


End Namespace
