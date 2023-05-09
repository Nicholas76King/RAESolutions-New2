Imports System
Imports System.Data
Imports System.Data.OleDb
Imports Rae.Data.Sql.SqlParameterComplianceEnforcer
Imports Rae.Io.Text
Imports System.Text
Imports System.Data.SqlClient


Imports System.IO
Imports Rae.RaeSolutions.DataAccess

Namespace IntegratedSecurity

    Public Class WebAuthenticate

        Private _userName As String
        Private _passWord As String

        Public Property UserName As String
            Set(ByVal value As String)
                _userName = value
            End Set
            Get
                Return _userName
            End Get
        End Property

        Public WriteOnly Property Password As String
            Set(ByVal value As String)
                _passWord = value
            End Set
        End Property

        Public Sub New(ByVal iUserName As String, ByVal iPassWord As String)
            _userName = iUserName
            _passWord = iPassWord

        End Sub


        Private Sub UpdateUser(ByVal userName As String, ByVal unencryptedPassword As String, ByVal userFullName As String, ByVal accessLevel As Rae.Security.IntegratedSecurity.AccessLevel, ByVal authorityGroup As Rae.Security.IntegratedSecurity.UserGroup)

            'blarg
            Dim contractor As String = "Yes"

            ' if resco
            If unencryptedPassword = "18078900" Then
                contractor = "No"
            Else
                Try
                    Dim checkContractor As New IsContractor.Authenticate
                    If checkContractor.IsContractor(userName) = True Then
                        contractor = "Yes"
                    Else
                        contractor = "No"
                    End If
                Catch ex As Exception
                    contractor = "Yes"
                End Try
            End If

            Dim pseudoEncryptedPassword1 As New PseudoEncryptedPassword(userName, unencryptedPassword, accessLevel, authorityGroup)
            Dim pseudoEncryptedPasswordString As String = pseudoEncryptedPassword1.PseudoEncryptedPasswordString

            Dim sbSQL As New StringBuilder()

            sbSQL.Append("update Table1 ")
            sbSQL.Append("set [Password] = '" & pseudoEncryptedPasswordString & "'")
            sbSQL.Append(", Sp2 ='" & EnforceCompliance(userFullName) & "'")
            sbSQL.Append(", LastWebAuthentication =#" & DateTime.Now.ToShortDateString & "#, Contractor = " & contractor)
            'sbSQL.Append(", LastWebAuthentication =#3/1/2010#")
            sbSQL.Append(" where User_Name = '" & EnforceCompliance(userName) & "'")

            Dim connection As OleDbConnection
            Dim command As OleDbCommand

            connection = New OleDbConnection(ConnectionString.Text)
            command = New OleDbCommand(sbSQL.ToString, connection)

            Try
                connection.Open()
                command.ExecuteNonQuery()
            Catch ex As OleDbException
                Throw ex
            Finally
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try


        End Sub

        Private Sub AddUser(ByVal userName As String, ByVal unencryptedPassword As String, ByVal userFullName As String, ByVal accessLevel As Rae.Security.IntegratedSecurity.AccessLevel, ByVal authorityGroup As Rae.Security.IntegratedSecurity.UserGroup)

            'blarg
            Dim contractor As String = "Yes"

            ' if resco
            If unencryptedPassword = "18078900" Then
                contractor = "No"
            Else
                Try
                    Dim checkContractor As New IsContractor.Authenticate
                    If checkContractor.IsContractor(userName) = True Then
                        contractor = "Yes"
                    Else
                        contractor = "No"
                    End If
                Catch ex As Exception
                    contractor = "Yes"
                End Try
            End If


            Dim pseudoEncryptedPassword1 As New PseudoEncryptedPassword(userName, unencryptedPassword, accessLevel, authorityGroup)
            Dim pseudoEncryptedPasswordString As String = pseudoEncryptedPassword1.PseudoEncryptedPasswordString

            Dim sbSQL As New StringBuilder()

            sbSQL.Append("insert into [Table1]  (User_Name, [Password], Sp2, LastWebAuthentication, Contractor) ")
            sbSQL.Append(" values (")
            sbSQL.Append("'" & EnforceCompliance(userName) & "', '" & pseudoEncryptedPasswordString & "', '" & EnforceCompliance(userFullName) & "', " & "#" & DateTime.Now.ToShortDateString & "#")
            sbSQL.Append(", " & contractor & ") ")

            Dim connection As OleDbConnection
            Dim command As OleDbCommand

            connection = New OleDbConnection(ConnectionString.Text)
            command = New OleDbCommand(sbSQL.ToString, connection)

            Try
                connection.Open()
                command.ExecuteNonQuery()
            Catch ex As OleDbException
                Throw ex
            Finally
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try

        End Sub


        Private Sub DisableUser(ByVal userName As String)
            Dim strSQL As String = "delete from table1 where User_Name = '" & EnforceCompliance(userName) & "'"

            Dim connection As OleDbConnection
            Dim command As OleDbCommand

            connection = New OleDbConnection(ConnectionString.Text)
            command = New OleDbCommand(strSQL, connection)

            Try
                connection.Open()
                command.ExecuteNonQuery()
            Catch ex As OleDbException
                Throw ex
            Finally
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try

        End Sub


        Private Function UserExists() As Boolean

            Dim connection As OleDbConnection
            Dim command As OleDbCommand
            Dim reader As OleDbDataReader = Nothing

            Dim strSQL1 As String = "select User_Name from Table1 where User_Name = '" & EnforceCompliance(_userName) & "'"

            UserExists = False

            connection = New OleDbConnection(ConnectionString.Text)
            command = New OleDbCommand(strSQL1, connection)

            Try
                connection.Open()
                reader = command.ExecuteReader

                If reader.HasRows Then
                    UserExists = True
                    Exit Function
                End If

            Catch ex As OleDbException
                Throw ex
            Finally
                If reader IsNot Nothing Then reader.Close()
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try

        End Function

        Const file_that_is_always_on_network As String = "\\199.5.85.159\FileSer1_E\Program Files\RAESolutions\logs\usageLog.xml"

        Public Function WebAuthenticate() As Boolean
            Try
                If String.IsNullOrEmpty(_userName) OrElse String.IsNullOrEmpty(_passWord) Then Return False

                Dim applicationVersion As String = My.Application.Info.Version.ToString
                Dim operatingSystemVersion As String = System.Environment.OSVersion.Version.ToString
                Dim operatingSystem As String = System.Environment.OSVersion.VersionString

                ' Call web service with username and password

                Dim sDGAuthenticationResult As SDGAuthenticate.AuthenticationResult






                Dim sDGAuthenticate1 As New SDGAuthenticate.Authenticate
                sDGAuthenticate1.Timeout = 5000

                '                              if system.io.file.exists(file_that_is_always_on_network)
                '                                sDGAuthenticate1.Url = "http://apps.util.rae-corp.net/TTPHELP/RAESolutionsOnline/WebServices/Authenticate.asmx?op=Authenticate"
                '                            else



                sDGAuthenticate1.Url = "http://service.raecloud.com/raesolutionsonline/WebServices/Authenticate.asmx?op=Authenticate"



                '                           end if



                sDGAuthenticationResult = sDGAuthenticate1.CallAuthenticate(_userName, _passWord, applicationVersion, operatingSystem, operatingSystemVersion)





                Select Case sDGAuthenticationResult.disableAccount
                    Case True
                        ' disable account in local access database
                        DisableUser(_userName)

                    Case False
                        Select Case sDGAuthenticationResult.isAuthenticated
                            Case False                  ' authentication failed.  
                                'Do nothing for now.  Rely on built-in MS Access security to kick out user.
                            Case True                         ' authentication succedded.
                                ' update access database with username, password, and access level.
                                ' reset "kill switch" datetime field.

                                Dim accessLevel As Rae.Security.IntegratedSecurity.AccessLevel, authorityGroup As Rae.Security.IntegratedSecurity.UserGroup

                                Dim isAccessParsed As Boolean = GetEnumValue(Of AccessLevel)(sDGAuthenticationResult.accessLevel, accessLevel)
                                Dim isAuthenticationParsed As Boolean = GetEnumValue(Of UserGroup)(sDGAuthenticationResult.authorityGroup, authorityGroup)



                                ' Update local access database 
                                If UserExists() Then
                                    UpdateUser(_userName, _passWord, sDGAuthenticationResult.userFullName, accessLevel, authorityGroup)
                                Else
                                    AddUser(_userName, _passWord, sDGAuthenticationResult.userFullName, accessLevel, authorityGroup)
                                End If


                        End Select


                End Select




                Return True

            Catch ex As Exception
                Return False
            End Try



        End Function

    End Class

End Namespace