Imports Rae.Data.MicrosoftAccess
Imports Rae.RaeSolutions.DataAccess
Imports System.Data

Namespace CoolStuff

Public Class cl_connection

   Private Shared Function myConnection(myDSN As String) As IDbConnection
      'Dim thisconnection As New OleDb.OleDbConnection
      Dim connStr As String
      Select Case UCase(myDSN)
         Case "BL"
            connStr = Common.CoolStuffDbPath
         Case "UI"
            connStr = Common.ProjectsDbPath
      End Select
      Return Common.CreateConnection(connStr)
   End Function

   Public Shared Function CleanTrashRecords() As Boolean
     Dim sql As String
     sql = " delete from coolstuffprojects WHERE CreatedWhen < date() -7 AND (isnull(projectid))"
     cl_connection.ExecuteSql(sql, "UI")
     Return 0

   End Function

   Private Shared Function THISREADER(ByVal mysql As String, ByVal Mydsn As String) As IDataReader
   Dim aconn As IDbConnection = myConnection(Mydsn) 'Common.CreateConnection 'New OleDb.OleDbConnection
   'aconn = Myconnection(Mydsn)
   Dim myCommand As IDbCommand = aconn.CreateCommand() 'New OleDb.OleDbCommand(mysql, aconn)
   myCommand.CommandText = mysql
   aconn.Open()
   THISREADER = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
   End Function

   Public Shared Function CreateGeneralTable(ByVal mysql As String, ByVal mycode As String) As DataTable
     Dim mydt As New DataTable
   Dim MYREADER As System.Data.IDataReader = THISREADER(mysql, mycode) 'OleDb.OleDbDataReader
   'MYREADER = THISREADER(mysql, mycode)
     mydt.Load(MYREADER)
     MYREADER.Close()
     Return mydt
   End Function

   Function CreateAshraeGeneralTable() As DataTable
     Dim i As Integer
     Dim testtable1 As DataTable

     testtable1 = CreateGeneralTable("select * from ASHrae order by Category,Commodity", "BL")

     Dim dr As DataRow
     ' dr = New DataRow

   Dim MYREADER As System.Data.IDataReader = THISREADER("select * from CoolStuffUserAshrae order by Category,Commodity", "UI") 'OleDb.OleDbDataReader
   'MYREADER = THISREADER("select * from CoolStuffUserAshrae order by Category,Commodity", "UI")
     While MYREADER.Read

         dr = testtable1.NewRow
         For i = 0 To testtable1.Columns.Count - 1
             dr(i) = MYREADER(i)
         Next

         dr("fromrep") = True

         testtable1.Rows.Add(dr)
     End While
     MYREADER.Close()
     Return testtable1
   End Function

   'TODO: move to Rae.RaeSolutions.DataAccess
   Private Function retrieveProjectName(projectId As String) As String
      Dim projectName As String
      projectName = " "
      
      Dim sql As String
      sql = "SELECT Projects.Name FROM Projects where ProjectId='" & projectId & "'"
      Dim reader As IDataReader
      reader = THISREADER(sql, "UI")
      reader.Read()
      Try
         projectName = reader(0)
      Catch ex As Exception
      End Try
      
      Return projectName
   End Function

   'REVIEW: Should this be moved
   Function AddRaeStuffToReportProject(ByRef dtbProj As DataTable, ByRef dtbPref As DataTable, _
   mydesc As String, myrecnum As Integer, projectId As String, repid As Integer, contactid As Integer) As Boolean

      ' these columns were removed from the CoolStuff Projects Table, but are still in the crystal report
      dtbProj.Columns.Add("Contact")
      dtbProj.Columns.Add("Company")
      dtbProj.Columns.Add("Addr1")
      dtbProj.Columns.Add("Addr2")
      dtbProj.Columns.Add("City")
      dtbProj.Columns.Add("State")
      dtbProj.Columns.Add("zip")
      dtbProj.Columns.Add("Phone")
      dtbProj.Columns.Add("Fax")
      dtbProj.Columns.Add("Email")
      dtbProj.Columns.Add("Desc")
      dtbProj.Columns.Add("Date")
      dtbProj.Columns.Add("ProjNo")
      
      
      Dim projectName As String = retrieveProjectName(projectId)
      
      dim dr = dtbProj.Rows(0)
      
      dim sql = "SELECT Companies.Name, Companies.Line1, Companies.Line2, Companies.City, Companies.State, Companies.ZipCode5, Companies.ZipCode4, Companies.PhoneNumAreaCode, Companies.PhoneNum, Companies.FaxNumAreaCode, Companies.FaxNum, Companies.Email, Contacts.Id,contacts.firstname,contacts.lastname"
      sql = sql & " FROM Companies INNER JOIN Contacts ON Companies.Id = Contacts.CompanyId"
      sql = sql & " WHERE contacts.id = " & contactid

      dim MYREADER = THISREADER(sql, "UI")
      If Not MYREADER.Read() Then
         log("The box load contact does not exist. id: " & contactid)
      End If

      dr.BeginEdit()
      dr("desc") = mydesc
      dr("date") = Format(Now, "MM/dd/yyyy")
      dr("Contact") = " "
      dr("company") = " "
      dr("Addr1") = " "
      dr("Addr2") = " "
      dr("City") = " "

      Try
         'REVIEW: What's this if statement for? ANSWER: if line 2 is null then shifts values down
         If (MYREADER("line2").Equals(System.DBNull.Value)) Then
             dr("Contact") = ""
             dr("Company") = MYREADER("Firstname") & " " & MYREADER("lastname")
             dr("Addr1") = MYREADER("Name")
             dr("Addr2") = MYREADER("Line1")
         Else
             dr("Contact") = MYREADER("Firstname") & " " & MYREADER("lastname")
             dr("Company") = MYREADER("Name")
             dr("Addr1") = MYREADER("Line1")
             dr("Addr2") = MYREADER("Line2")
         End If

         dr("City") = MYREADER("City")
         dr("State") = MYREADER("State")
         dr("Zip") = MYREADER("ZipCode5")
         Try
             If Len(Trim(MYREADER("phonenum"))) = 7 Then
                 dr("Phone") = MYREADER("PhonenumAreaCode") & "-" & Left(MYREADER("phonenum"), 3) & "-" & Right(MYREADER("phonenum"), 4)
             End If
         Catch ex As Exception

         End Try
         Try
             If Len(Trim(MYREADER("Faxnum"))) = 7 Then
                 dr("Fax") = "FAX:  " & MYREADER("FaxnumAreaCode") & "-" & Left(MYREADER("Faxnum"), 3) & "-" & Right(MYREADER("Faxnum"), 4)
             End If
         Catch ex As Exception

         End Try

         dr("email") = MYREADER("Email")
      Catch ex As Exception
         ' a valid contact wasn't selected
      End Try
      dr("projno") = projectName
      dr.EndEdit()



      'the necessary columns are still in the preferences table, only the default city and state for selection are used.
      'I need to pad the rest here on the fly, don't know how rep information will appear in the future.
      sql = "SELECT Companies.Name, Companies.Line1, Companies.Line2, Companies.City, Companies.State, Companies.ZipCode5, Companies.ZipCode4, Companies.PhoneNumAreaCode, Companies.PhoneNum, Companies.FaxNumAreaCode, Companies.FaxNum, Companies.Email, Contacts.Id,contacts.firstname,contacts.lastname"
      sql = sql & " FROM Companies INNER JOIN Contacts ON Companies.Id = Contacts.CompanyId"
      sql = sql & " WHERE contacts.id = " & repid
      Try
         dr = dtbPref.Rows(0)
      Catch ex As Exception

      End Try

      MYREADER = THISREADER(sql, "UI")
      If Not MYREADER.Read() Then
         log("Box load report: rep selection was not made or is invalid.")
      End If
      dr.BeginEdit()
      dr("Contact") = " "
      dr("ADDR1") = " "
      dr("Addr2") = " "
      dr("City") = " "


      Try
         If (MYREADER("line2").Equals(System.DBNull.Value)) Then
             dr("Contact") = " "
             dr("Addr1") = MYREADER("Firstname") & " " & MYREADER("lastname")
             dr("Addr2") = MYREADER("Line1")
         Else
             dr("Contact") = MYREADER("Firstname") & " " & MYREADER("lastname")
             dr("Addr1") = MYREADER("Line1")
             dr("Addr2") = MYREADER("Line2")
         End If
        
         dr("City") = MYREADER("City")
         dr("State") = MYREADER("State")
         dr("Zip") = MYREADER("ZipCode5")
         Try
             If Len(Trim(MYREADER("phonenum"))) = 7 Then
                 dr("Phone") = MYREADER("PhonenumAreaCode") & "-" & Left(MYREADER("phonenum"), 3) & "-" & Right(MYREADER("phonenum"), 4)
             End If
         Catch ex As Exception

         End Try
         Try
             If Len(Trim(MYREADER("Faxnum"))) = 7 Then
                 dr("Fax") = "Fax " & MYREADER("FaxnumAreaCode") & "-" & Left(MYREADER("Faxnum"), 3) & "-" & Right(MYREADER("Faxnum"), 4)
             End If
         Catch ex As Exception

         End Try
         dr("email") = MYREADER("Email")
         
      Catch ex As Exception
         ' rep was not selected or is invalid
      End Try
      dr.EndEdit()
      MYREADER.Close()
      Return True
   End Function
   
   Private Sub log(msg As String)
      Debug.Print(msg)
   End Sub

   Public Function setcomboIndex(ByVal Compare2String As String, ByVal whichList As ComboBox) As Integer
     Dim i As Integer
     If Len(Compare2String) <> 0 Then
         For i = 0 To whichList.Items.Count - 1
             '                Debug.Print(whichList.Items(i).row(0))
             If whichList.Items(i).row(0) IsNot DbNull.Value _
             AndAlso whichList.Items(i).row(0) = Compare2String Then
                 Return i
             End If
         Next
     End If
     Return -1
   End Function

   Public Shared Function ExecuteSql(ByVal sql As String, ByVal mycode As String) As Integer
     Try
         Dim thisconnection As IDbConnection '= Common.CreateConnection 'OleDb.OleDbConnection
         thisconnection = cl_connection.myConnection(mycode)
         thisconnection.Open()
      Dim mycommand As IDbCommand = thisconnection.CreateCommand 'OleDb.OleDbCommand = New OleDb.OleDbCommand(sql, thisconnection)
         mycommand.CommandText = sql 'CommandType.Text
         mycommand.ExecuteNonQuery()   'Execute the query
         thisconnection.Close()
         Return 0
     Catch ex As Exception
         Return -1
     End Try
   End Function

   Shared Function GetProjectRecordNumber(ByVal ProjectKey As String, ByVal revision As Single, ByVal mycode As String) As Integer
      GetProjectRecordNumber = 0
      Try
         Dim MYREADER As System.Data.IDataReader = THISREADER("select id from CoolStuffProjects where processid = '" & ProjectKey & "' and revision = " & revision, mycode) 'OleDb.OleDbDataReader
         'MYREADER = THISREADER("select id from CoolStuffProjects where processid = '" & ProjectKey & "' and revision = " & revision, mycode)
         MYREADER.Read()
         GetProjectRecordNumber = MYREADER("id")
         MYREADER.Close()
      Catch ex As Exception
      End Try
   End Function

   Shared Function GetOverrides(id As Integer, _
   ByRef capacity As Integer, ByRef runtime As String, ByRef ambient As String, _
   ByRef roomtemp As String, ByRef usercapacity As String, ByRef usercapacitychecked As Boolean, ByRef blname As String) As Integer

     Try
      Dim MYREADER As System.Data.IDataReader 'OleDb.OleDbDataReader
         MYREADER = THISREADER("select * from CoolStuffProjects where Id = " & id, "UI")
         MYREADER.Read()
         capacity = MYREADER("loadtot")
         usercapacity = MYREADER("UserCapacity")
         usercapacitychecked = MYREADER("usercapacitychecked")
         runtime = MYREADER("runvar")
         ambient = MYREADER("ambient")
         roomtemp = MYREADER("rmtemp")
         blname = MYREADER("blname")

         MYREADER.Close()
     Catch ex As Exception
     End Try
   End Function

   Public Function GetAshraeRecordNumber(ByVal category As String, ByVal mycode As String) As Integer
     GetAshraeRecordNumber = 0
     Try
      Dim MYREADER As System.Data.IDataReader 'OleDb.OleDbDataReader
         MYREADER = THISREADER("select mycounter from CoolStuffUserAshrae where category = '" & category & "'", mycode)
         MYREADER.Read()
         GetAshraeRecordNumber = MYREADER("mycounter")
         MYREADER.Close()
     Catch ex As Exception
     End Try
   End Function

   Public Function GetProjectProductRecordNumber(ByVal productkey As String, ByVal mycode As String) As Integer
     GetProjectProductRecordNumber = 0
     Try
      Dim MYREADER As System.Data.IDataReader = THISREADER("select id from CoolStuffProductSelections where  product = '" & productkey & "'", mycode) 'OleDb.OleDbDataReader
      'MYREADER = THISREADER("select id from CoolStuffProductSelections where  product = '" & productkey & "'", mycode)
         MYREADER.Read()
         GetProjectProductRecordNumber = MYREADER("id")
         MYREADER.Close()
     Catch ex As Exception
     End Try
   End Function

   Public Function unQuoteString(ByVal mystring As String) As String
     Dim junk As String
     junk = Replace(mystring, "'", "''")
     unQuoteString = Trim(junk)
   End Function

End Class

End Namespace