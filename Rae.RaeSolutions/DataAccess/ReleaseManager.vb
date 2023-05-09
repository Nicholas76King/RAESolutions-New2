Option Strict On
Option Explicit On 

Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Collections
Imports System.Threading.Thread

Namespace Rae.RaeSolutions.DataAccess


   ''' <summary>
   ''' Allows new HR numbers to be assigned
   ''' </summary>
   ''' <remarks>
   ''' ORPCONTRL  table
   ''' OCLSTQTE   column : Double            'Last Quote Number Used
   ''' OCLSTPR    column : Double            'Last PR Number Used
   ''' OCLSTPCK   column : Double            'Last Pick Number
   ''' 
   ''' PREASGHRN  table                      ' PREviously ASsiGned HR Numbers
   ''' SALESMAN   column : String * 3
   ''' HRNUMBER   column : Double
   ''' JOBDESC1   column : String * 50
   ''' JOBDESC2   column : String * 50
   ''' JOBDESC3   column : String * 50
   ''' DATE       column : String * 8        'Format: MMddyyyy
   ''' </remarks>
   Public Class ReleaseManager

      Private _nextReleaseNum As Integer
      Private _assignedReleaseNum As Integer



      ''' <summary>
      ''' Cached next release number
      ''' </summary>
      Public ReadOnly Property NextReleaseNum() As Integer
         Get
            Return Me._nextReleaseNum
         End Get
      End Property


      ''' <summary>
      ''' Cached assigned release number
      ''' </summary>
      Public ReadOnly Property AssignedReleaseNum() As Integer
         Get
            Return Me._assignedReleaseNum
         End Get
      End Property



#Region " Public methods"

      ''' <summary>Constructor</summary>
      Public Sub New()
      End Sub


      ''' <summary>
      ''' Assigns a new release number, increments stored release number and logs assignment
      ''' </summary>
      ''' <param name="salesman">Salesman assigning the release number</param>
      ''' <param name="repInfo">Information about rep associated with assigned release number</param>
      ''' <param name="projectInfo">Information about project associated with assigned HR number</param>
      Public Function AssignReleaseNum(ByVal salesman As String, ByVal repInfo As String, ByVal projectInfo As String) As String
         Dim assignedReleaseNum As Integer
         Dim assignedReleaseString As String

         ' retrieves hr number and increments hr number in database so that the next assignment will be an unused hr number
         assignedReleaseNum = Me.IncrementAndRetrieveHrNum() : Me._assignedReleaseNum = assignedReleaseNum

         ' logs who and when for this hr assignment
         Me.LogHr(salesman, repInfo, projectInfo)

         ' formats hr number
         assignedReleaseString = Me.ReleaseNumToString(assignedReleaseNum)

         Return assignedReleaseString
      End Function


      ''' <summary>
      ''' Retrieves the next unassigned release number, but does not assign it; just for viewing the release number
      ''' </summary>
      ''' <remarks>The stored release number is not incremented and the retrieval is not logged</remarks>
      Public Function RetrieveNextUnassignedReleaseNum() As Integer
         Dim connectionString, sql As String
         Dim nextReleaseNum As Integer
         Dim connection As SqlConnection
         Dim command As SqlCommand

         connectionString = Common.GetSqlConnectionString("master")
         connection = New SqlConnection(connectionString)

         sql = "SELECT (OCLSTPR+1) FROM AS400.RAE270.MANLIB.ORPCONTRL"
         command = New SqlCommand(sql, connection)

         Try
            connection.Open()
            nextReleaseNum = CInt(command.ExecuteScalar())
         Catch ex As SqlException
            Throw ex
         Finally
            If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try

         ' caches next HR number
         Me._nextReleaseNum = nextReleaseNum

         Return nextReleaseNum
      End Function


      ''' <summary>
      ''' Retrieves info for specified release number
      ''' </summary>
      ''' <param name="releaseNum">Release number to retrieve information for</param>
      Public Function RetrieveInfoByReleaseNum(ByVal releaseNum As Integer) As DataTable
         Dim connectionString As String
         Dim sql As New StringBuilder
         Dim connection As SqlConnection
         Dim adapter As SqlDataAdapter
         Dim hrTable As DataTable

         connectionString = Common.GetSqlConnectionString("master")
         sql.Append("SELECT * FROM AS400.RAE270.MANLIB.PREASGHRN ")
         sql.AppendFormat("WHERE HRNUMBER={0}", releaseNum.ToString)

         connection = New SqlConnection(connectionString)
         adapter = New SqlDataAdapter(sql.ToString, connection)
         hrTable = New DataTable("HrInfo")

         Try
            connection.Open()
            adapter.Fill(hrTable)
         Catch ex As SqlException
            Throw ex
         Finally
            If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try

         Return hrTable
      End Function


      ''' <summary>
      ''' Retrieves info for release numbers assigned on the date that the most recent assignment occurred.
      ''' </summary>
      Public Function RetrieveInfoAssignedOnDateOfMostRecentRelease() As DataTable
         Dim connectionString, sql As String
         Dim connection As SqlConnection
         Dim adapter As SqlDataAdapter
         Dim hrTable As DataTable
         Dim currentYear As String

         connectionString = Common.GetSqlConnectionString("master")
         connection = New SqlConnection(connectionString)

         currentYear = Date.Today.Year.ToString("yyyy")
         sql = "SELECT * FROM AS400.RAE270.MANLIB.PREASGHRN WHERE DATE=(SELECT MAX(DATE) FROM AS400.RAE270.MANLIB.PREASGHRN WHERE SUBSTRING(DATE, 5, 4) = '" & currentYear & "')"
         adapter = New SqlDataAdapter(sql, connection)

         Try
            connection.Open()
            adapter.Fill(hrTable)
         Catch ex As SqlException
            Throw ex
         Finally
            If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try

         Return hrTable
      End Function


      ''' <summary>
      ''' Retrieves info for release numbers that were assigned on the specified date
      ''' </summary>
      ''' <param name="releaseDate">
      ''' Date release number was assigned
      ''' </param>
      Public Function RetrieveInfoAssignedOnDate(ByVal releaseDate As Date) As DataTable
         Dim connectionString, sql As String
         Dim connection As SqlConnection
         Dim adapter As SqlDataAdapter
         Dim releaseTable As New DataTable("HR")

         connectionString = Common.GetSqlConnectionString("master")
         sql = "SELECT * FROM AS400.RAE270.MANLIB.PREASGHRN WHERE [DATE]=" & releaseDate.ToString("MMddyyyy")

         connection = New SqlConnection(connectionString)
         adapter = New SqlDataAdapter(sql, connection)

         Try
            connection.Open()
            adapter.Fill(releaseTable)
         Catch ex As SqlException
            Throw ex
         Finally
            If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try

         Return releaseTable
      End Function


      ''' <summary>
      ''' Retrieves info for release numbers assigned on or after the date specified
      ''' </summary>
      Public Function RetrieveInfoAssignedOnOrAfterDate(ByVal releaseDate As Date) As DataTable
         Dim sql As New StringBuilder
         Dim connectionString As String
         Dim connection As SqlConnection
         Dim adapter As SqlDataAdapter
         Dim hrTable As New DataTable("HR")
         Dim year, month, day As String

         year = releaseDate.Year.ToString
         month = releaseDate.Month.ToString("00")
         day = releaseDate.Day.ToString("00")

         connectionString = Common.GetSqlConnectionString("master")
         connection = New SqlConnection(connectionString)

         sql.Append("SELECT TOP 200 * FROM AS400.RAE270.MANLIB.PREASGHRN ")
         ' greater than this year
         sql.AppendFormat("WHERE (SUBSTRING(DATE, 5, 4) > '{0}') ", year)
         ' equal to year and greater than month
         sql.AppendFormat("OR (SUBSTRING(DATE, 5, 4) = '{0}' AND SUBSTRING(DATE, 1, 2) > '{1}') ", year, month)
         ' equal to year and equal to month and greater than or equal to day
         sql.AppendFormat("OR (SUBSTRING(DATE, 5, 4) = '{0}' AND SUBSTRING(DATE, 1, 2) = '{1}' AND SUBSTRING(DATE, 3, 2) >= '{2}')", year, month, day)
         adapter = New SqlDataAdapter(sql.ToString, connection)

         Try
            connection.Open()
            adapter.Fill(hrTable)
         Catch ex As SqlException
            Throw ex
         Finally
            If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try

         Return hrTable
      End Function


      ''' <summary>
      ''' Retrieves number of release numbers logged
      ''' </summary>
      Public Function RetrieveNumAssignedReleaseNums() As Integer
         Dim connectionString, sql As String
         Dim numRecords As Integer
         Dim connection As SqlConnection
         Dim command As SqlCommand

         connectionString = Common.GetSqlConnectionString("master")
         connection = New SqlConnection(connectionString)

         sql = "SELECT COUNT(*) FROM AS400.RAE270.MANLIB.PREASGHRN"
         command = New SqlCommand(sql, connection)

         Try
            connection.Open()
            numRecords = CInt(command.ExecuteScalar())
         Catch ex As SqlException
            Throw ex
         Finally
            If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try

         Return numRecords
      End Function



      ' IDEA: RetrieveHrsAssignedBySalesman(salesmanInitials As String)

      ' IDEA: RetrieveHrsWithRepCompany(repCompany As String)

      ' IDEA: RetrieveHrByProjectId(projectId As String)



      ''' <summary>
      ''' Converts release number to string and formats
      ''' </summary>
      Public Function ReleaseNumToString(ByVal releaseNum As Integer) As String
         Return releaseNum.ToString("0000000")
      End Function

#End Region



#Region " Private methods"

      ''' <summary>Retrieves a new HR number and then increments the stored HR for the next assignment
      ''' </summary>
      Private Function IncrementAndRetrieveHrNum() As Integer
         Dim connectionString, sql As String
         Dim assignedHrNum As Integer
         Dim connection As SqlConnection
         Dim command As SqlCommand

         connectionString = Common.GetSqlConnectionString("master")
         connection = New SqlConnection(connectionString)

         Try
            connection.Open()

            ' increments hr number
            ' TODO: before release change column OCLSTQTE (Last Quote #) to OCLSTPR (Last PR #)
            sql = "UPDATE AS400.RAE270.MANLIB.ORPCONTRL SET OCLSTQTE=(OCLSTQTE+1)"
            'sql = "UPDATE AS400.RAE270.MANLIB.ORPCONTRL SET OCLSTQTE=" & (assignedHrNum + 1).ToString
            command = New SqlCommand(sql, connection)
            command.ExecuteNonQuery()

            ' retrieves hr number
            sql = "SELECT OCLSTPR FROM AS400.RAE270.MANLIB.ORPCONTRL"
            command = New SqlCommand(sql, connection)
            assignedHrNum = CInt(command.ExecuteScalar())

         Catch ex As SqlException
            Throw ex
         Finally
            If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try

         Return assignedHrNum
      End Function


      ''' <summary>Logs HR number assignment information
      ''' </summary>
      Private Overloads Sub LogHr(ByVal salesman As String, ByVal repInfo As String, ByVal projectInfo As String)
         Dim description As String = "HR/PR assigned using RAESolutions"

         ' logs hr num assignment details
         Me.LogHr(Me.AssignedReleaseNum, salesman, description, repInfo, projectInfo)
      End Sub


      ''' <summary>Logs HR number assignment information
      ''' </summary>
      ''' <remarks>The Assign HR Number database has a salesman, HR number, date assigned and three description columns
      ''' </remarks>
      Private Overloads Sub LogHr(ByVal hrNum As Integer, ByVal salesman As String, _
      ByVal description1 As String, ByVal description2 As String, ByVal description3 As String)
         Dim connectionString As String
         Dim sql As New StringBuilder
         Dim numRowsAffected As Integer
         Dim connection As SqlConnection
         Dim command As SqlCommand

         ' logs hr number, user's name (salesman), rep and rep company, RAESolutions project, date hr number was assigned

         ' database only accepts descriptions with max lengths of 50
         If description1.Length > 50 Then description1 = description1.Substring(0, 50)
         If description2.Length > 50 Then description2 = description2.Substring(0, 50)
         If description3.Length > 50 Then description3 = description3.Substring(0, 50)

         connectionString = Common.GetSqlConnectionString("master")
         connection = New SqlConnection(connectionString)

         sql.Append("INSERT INTO AS400.RAE270.MANLIB.PREASGHRN SALESMAN, HRNUMBER, JOBDESC1, JOBDESC2, JOBDESC3, DATE ")
         sql.AppendFormat("VALUES '{0}', {1}, '{2}', '{3}', '{4}', '{5}'", _
            salesman, Me.AssignedReleaseNum.ToString, description1, description2, description3, Date.Today.ToString("MMddyyyy"))
         command = New SqlCommand(sql.ToString, connection)

         Try
            connection.Open()
            numRowsAffected = command.ExecuteNonQuery()
         Catch ex As SqlException
            Throw ex
         Finally
            If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
         End Try
      End Sub

#End Region

   End Class


   'Private Function GetEmptyHrTable() As DataTable
   '   Dim hrTable As New DataTable("HrAssignments")
   '   Dim row As DataRow

   '   With hrTable.Columns
   '      .Add("HrNumber", GetType(Integer))
   '      .Add("Salesman", GetType(String))
   '      .Add("Description1", GetType(String))
   '      .Add("Description2", GetType(String))
   '      .Add("Description3", GetType(String))
   '      .Add("DateAssigned", GetType(Date))
   '   End With

   '   Return hrTable
   'End Function





   ''' <summary>Contains information about an HR assignment</summary>
   '   Public Class HrInfo

   '#Region " Declarations"

   '      Private _hrNum As Integer
   '      Private _salesman As String
   '      Private _repInfo As String
   '      Private _projectInfo As String
   '      Private _assignmentDate As Date

   '#End Region


   '#Region " Properties"

   '      Public Property HrNum() As Integer
   '         Get
   '            Return Me._hrNum
   '         End Get
   '         Set(ByVal Value As Integer)
   '            Me._hrNum = Value
   '         End Set
   '      End Property

   '      Public Property Salesman() As String
   '         Get
   '            Return Me._salesman
   '         End Get
   '         Set(ByVal Value As String)
   '            Me._salesman = Value
   '         End Set
   '      End Property

   '      Public Property RepInfo() As String
   '         Get
   '            Return Me._repInfo
   '         End Get
   '         Set(ByVal Value As String)
   '            Me._repInfo = Value
   '         End Set
   '      End Property

   '      Public Property ProjectInfo() As String
   '         Get
   '            Return Me._projectInfo
   '         End Get
   '         Set(ByVal Value As String)
   '            Me._projectInfo = Value
   '         End Set
   '      End Property

   '      Public Property AssignmentDate() As Date
   '         Get
   '            Return Me._assignmentDate
   '         End Get
   '         Set(ByVal Value As Date)
   '            Me._assignmentDate = Value
   '         End Set
   '      End Property

   '#End Region


   '#Region " Public methods"

   '      ''' <summary>Simple constructor</summary>
   '      Public Sub New()
   '         Me.AssignmentDate = Date.Today
   '      End Sub


   '      ''' <summary>Constructor that sets properties</summary>
   '      Public Sub New(ByVal hrNum As Integer, ByVal salesman As String, ByVal repInfo As String, ByVal projectInfo As String)
   '         Me.New()

   '         Me.HrNum = hrNum
   '         Me.Salesman = salesman
   '         Me.RepInfo = repInfo
   '         Me.ProjectInfo = ProjectInfo
   '      End Sub


   '      ''' <summary>Constructor that sets all properties</summary>
   '      Public Sub New(ByVal hrNum As Integer, ByVal salesman As String, ByVal repInfo As String, _
   '      ByVal projectInfo As String, ByVal assignmentDate As Date)
   '         Me.New(hrNum, salesman, repInfo, projectInfo)
   '         Me.AssignmentDate = assignmentDate
   '      End Sub


   '      ''' <summary>Formatted HR number</summary>
   '      Public Overrides Function ToString() As String
   '         Return Me.HrNum.ToString("0000000")
   '      End Function

   '#End Region

   '   End Class











   ' NOTE: Doesn't return most recent (table may need timestamp for this to work?)
   ''' <summary>Retrieves recent HR information</summary>
   'Public Function RetrieveTopNHrs(ByVal numHrs As Integer) As DataTable
   '   Dim connectionString, sql As String
   '   Dim connection As SqlConnection
   '   Dim adapter As SqlDataAdapter
   '   Dim hrTable As New DataTable("HR")

   '   connectionString = Common.GetSqlConnectionString("master")
   '   sql = "SELECT TOP " & numHrs.ToString & " * FROM AS400.RAE270.MANLIB.PREASGHRN"
   '   sql = "SELECT * FROM AS400.RAE270.MANLIB.PREASGHRN WHERE SUBSTRING(DATE, 3, 3)"

   '   connection = New SqlConnection(connectionString)
   '   adapter = New SqlDataAdapter(sql, connection)

   '   Try
   '      connection.Open()
   '      adapter.Fill(hrTable)
   '   Catch ex As SqlException
   '      Throw ex
   '   Finally
   '      If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
   '   End Try

   '   Return hrTable
   'End Function


   '''' <summary>Retrieves HR information; use when reading HR's logged by RAESolutions</summary>
   'Public Function RetrieveHrInfo(ByVal hrNum As Integer) As HrInfo
   '   Dim connectionString As String
   '   Dim sql As New StringBuilder
   '   Dim connection As SqlConnection
   '   Dim command As SqlCommand
   '   Dim reader As SqlDataReader
   '   Dim hr As HrInfo

   '   connectionString = Common.GetSqlConnectionString("master")
   '   sql.Append("SELECT * FROM AS400.RAE270.MANLIB.PREASGHRN ")
   '   sql.AppendFormat("WHERE HRNUMBER={0}", hrNum.ToString)

   '   connection = New SqlConnection(connectionString)
   '   command = New SqlCommand(sql.ToString, connection)

   '   Try
   '      connection.Open()
   '      reader = command.ExecuteReader()
   '      ' checks if hr number is found
   '      If Not reader.HasRows Then Return Nothing

   '      hr = New HrInfo
   '      While reader.Read
   '         hr.HrNum = CInt(reader("HRNUMBER"))
   '         hr.Salesman = CNull.ToString(reader("Salesman"))
   '         hr.RepInfo = CNull.ToString(reader("JOBDESC2"))
   '         hr.ProjectInfo = CNull.ToString(reader("JOBDESC3"))
   '         Try : hr.AssignmentDate = Date.ParseExact(reader("DATE").ToString, "MMddyyyy", CurrentThread.CurrentCulture)
   '         Catch ex As System.Exception : End Try
   '      End While
   '   Catch ex As SqlException
   '      Throw ex
   '   Finally
   '      If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
   '      If Not reader Is Nothing Then reader.Close()
   '   End Try

   '   Return hr
   'End Function




   '''' <summary>Retrieves recent hr assignments</summary>
   'Public Function RetrieveRecentHrAssignments(ByVal numAssignments As Integer) As ArrayList
   '   Dim connectionString As String
   '   Dim i As Integer = 0
   '   Dim sql As New StringBuilder
   '   Dim connection As SqlConnection
   '   Dim command As SqlCommand
   '   Dim reader As SqlDataReader
   '   Dim hr As HrInfo
   '   Dim hrList As New ArrayList

   '   connectionString = Common.GetSqlConnectionString("master")
   '   connection = New SqlConnection(connectionString)
   '   sql.AppendFormat("SELECT TOP {0} HRNUMBER, SALESMAN, JOBDESC1, JOBDESC2, JOBDESC3, DATE FROM AS400.RAE270.MANLIB.PREASGHRN", _
   '      numAssignments.ToString)
   '   command = New SqlCommand(sql.ToString, connection)

   '   Try
   '      connection.Open()
   '      reader = command.ExecuteReader()
   '      While reader.Read()
   '         hr = New HrInfo
   '         hr.HrNum = CInt(reader("HRNUMBER"))
   '         hr.Salesman = CNull.ToString(reader("SALESMAN"))
   '         hr.RepInfo = CNull.ToString(reader("JOBDESC2"))
   '         hr.ProjectInfo = CNull.ToString(reader("JOBDESC3"))
   '         ' date is an integer formatted as "MMddyyyy"
   '         hr.AssignmentDate = Date.ParseExact(reader("DATE").ToString, "MMddyyyy", CurrentThread.CurrentCulture)
   '         hrList.Add(hr)

   '         ' using SELECT TOP n sometimes rounds to the nearest hundredths 
   '         '  (TOP 1..100 would return TOP 100) don't know why
   '         ' exits loop after TOP n have been retrieved
   '         i += 1
   '         If i = numAssignments Then Exit While
   '      End While
   '   Catch ex As SqlException
   '      Throw ex
   '   Finally
   '      If Not reader Is Nothing Then reader.Close()
   '      If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
   '   End Try

   '   Return hrList
   'End Function


End Namespace