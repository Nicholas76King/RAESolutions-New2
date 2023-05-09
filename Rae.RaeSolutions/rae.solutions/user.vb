Imports System.Environment
Imports System.Collections.Generic
Imports rae.solutions.credentials.users

Namespace rae.solutions

    ''' <summary>User contains information about a user of the application.</summary>
    Public Class user

        Sub New()
        End Sub

        Sub New( _
        ByVal username As String, ByVal password As String, _
        ByVal first_name As String, ByVal last_name As String, _
        ByVal authorization As user_group, ByVal pricing_privledge As access_level)
            Me.username = username
            Me.first_name = first_name
            Me.last_name = last_name
            Me.authority_group = authorization
            access_level = pricing_privledge
        End Sub

        Public username, password As String
        Public first_name, last_name As String
        ''' <summary>Group that defines its members' authorization level.</summary>
        Public authority_group As user_group

        ''' <summary>Access level. Indicates the information that the user is allowed to access.</summary>
        ''' <remarks>Determines access to certain divisions and may restrict pricing information.</remarks>
        Property access_level As access_level
            Get
                Return _access_level
            End Get
            Set(ByVal value As access_level)
                _access_level = value
                set_can_view_pricing(value)
            End Set
        End Property

        ReadOnly Property can_view_pricing As Boolean
            Get
                Return _can_view_pricing
            End Get
        End Property

        ''' <summary>First name space last name</summary>
        ReadOnly Property full_name As String
            Get
                Return first_name & " " & last_name
            End Get
        End Property

        Function works_at_resco() As Boolean
            Return (password = "18078900")
        End Function


        Function HasCloudAccess() As Boolean
            ' If is_employee() OrElse password = "30058915" OrElse password = "38347961" Then
            Return True
            'End If
            'Return False
        End Function

        Function Company_Code() As String
            If is_employee() Then Return "RAE"
            Return password
        End Function


        Function is_in(ByVal group As group) As Boolean
            Return group.contains(username)
        End Function

        Function can(ByVal activity As group) As Boolean
            Return activity.contains(username)
        End Function

        Function cannot(ByVal activity As group) As Boolean
            Return Not can(activity)
        End Function

        Function is_rep() As Boolean
            Return (authority_group = user_group.rep)
        End Function

        Function is_employee() As Boolean
            Return (authority_group = user_group.employee)
        End Function

        ''' <summary>True if this user's username matches the username parameter</summary>
        ''' <param name="username">Username to compare to this user</param>
        Overloads Function [is](ByVal username As String) As Boolean
            Dim user_is_a_match As Boolean

            If Me.username.equals(username, StringComparison.CurrentCultureIgnoreCase) Then
                user_is_a_match = True
            End If

            Return user_is_a_match
        End Function

        Overloads Function [is](ByVal ParamArray usernames() As String) As Boolean
            Dim username As String

            For Each username In usernames
                If [is](username) Then _
                   Return True
            Next

            Return False
        End Function

        ''' <summary>User's full name (first then last)</summary>
        Overrides Function ToString() As String
            Return full_name
        End Function

        ''' <summary>Sets user's first and last name based upon the provided full name.</summary>
        Sub parse_full_name(ByVal full_name As String)
            Dim index_of_space As Integer = full_name.indexof(" ")

            ' checks if name is in the format: first name, space, last name
            If index_of_space > -1 Then
                Me.first_name = full_name.Substring(0, index_of_space)
                Me.last_name = full_name.Substring(index_of_space + 1, full_name.Length - (index_of_space + 1))
            Else
                ' unknown format
                first_name = full_name
                last_name = ""
            End If
        End Sub



        Private _access_level As access_level
        Protected _can_view_pricing As Boolean

        Private Sub set_can_view_pricing(ByVal access As access_level)
            If access = access_level.ALL_P _
            OrElse (access = access_level.CRI_P) _
            OrElse (access = access_level.TSI_P) Then
                _can_view_pricing = True
            Else
                _can_view_pricing = False
            End If
        End Sub

    End Class
End Namespace