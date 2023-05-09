Option Strict On
Option Explicit On 

Imports System


Namespace Rae.RaeSolutions.Business.Entities


   ''' <summary>
   ''' Email address
   ''' </summary>
   Public Class Email
      Implements ICloneable(Of Email)
      Implements IEquatable(Of Email)



      Dim _address As String


#Region " Properties"

      ''' <summary>Full email address (i.e. username@domain.ext)</summary>
      ''' <remarks>Example: casey@rae.com</remarks>
      Public Property Address() As String
         Get
            Return Me._address
         End Get
         Set(ByVal Value As String)
            Me._address = Value
         End Set
      End Property

      ''' <summary>Email's username</summary>
      ''' <remarks>Example: casey</remarks>
      Public ReadOnly Property Username() As String
         Get
            ' returns everything before the "@" character
            Return Me._address.Substring(0, Me.IndexOfAt + 1)
         End Get
      End Property

      ''' <summary>Email's domain</summary>
      ''' <remarks>Example: rae</remarks>
      Public ReadOnly Property Domain() As String
         Get
            ' returns domain (i.e. everthing between "@" and last ".")
            Return Me._address.Substring(Me.IndexOfAt + 1, Me.IndexOfLastDot - Me.IndexOfAt - 1)
         End Get
      End Property

      ''' <summary>Email's domain extension</summary>
      ''' <remarks>Example: com</remarks>
      Public ReadOnly Property Extension() As String
         Get
            Return Me._address.Substring(Me.IndexOfLastDot + 1, Me._address.Length - Me.IndexOfLastDot - 1)
         End Get
      End Property

      ''' <summary>Determines whether email address is valid.</summary>
      Public ReadOnly Property IsValid() As Boolean
         Get
            Return Email.IsEmailValid(Me.Address)
         End Get
      End Property


      ''' <summary>Determines whether email address exists (is set).</summary>
      Public ReadOnly Property AddressExists() As Boolean
         Get
            Return (Not Me._address Is Nothing AndAlso Me._address.Length > 0)
         End Get
      End Property


      ''' <summary>Index of first "@" character.</summary>
      Private ReadOnly Property IndexOfAt() As Integer
         Get
            Return Me._address.IndexOf("@")
         End Get
      End Property

      ''' <summary>Index of last "." character.</summary>
      Private ReadOnly Property IndexOfLastDot() As Integer
         Get
            Return Me._address.LastIndexOf(".")
         End Get
      End Property

#End Region


#Region " Public methods"

      ''' <summary>Constructs email.</summary>
      Public Sub New()
      End Sub

      ''' <summary>Constructs email with address</summary>
      Public Sub New(ByVal emailAddress As String)
         Me._address = emailAddress
      End Sub


      ''' <summary>Deeply clones email; both instances have their own references
      ''' </summary>
      ''' <history>Created on 11/18/2005 by Casey Joyce
      ''' </history>
      Public Function Clone() As Email _
      Implements ICloneable(Of Email).Clone
         Dim emailDeepClone As Entities.Email

         ' clones email
         emailDeepClone = New Entities.Email(Me.Address)

         Return emailDeepClone
      End Function


      ''' <summary>Returns email address</summary>
      Public Overrides Function ToString() As String
         Return Me._address
      End Function


      ''' <summary>Verifies email's syntax is valid</summary>
      ''' <remarks>From CodeProject.com (link: http://www.codeproject.com/aspnet/Valid_Email_Addresses.asp)</remarks>
      Public Shared Function IsEmailValid(ByVal emailAddress As String) As Boolean
         Dim emailRegExValue As String
         Dim emailRegEx As System.Text.RegularExpressions.Regex

         ' regular expression that will validate email address
         emailRegExValue = "^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" & _
            "\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" & _
            ".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
         emailRegEx = New System.Text.RegularExpressions.Regex(emailRegExValue)

         ' determines whether email address is valid
         If (emailRegEx.IsMatch(emailAddress)) Then
            Return True
         Else
            Return False
         End If

      End Function

#End Region

      ''' <summary>Determines whether the emails are equal.</summary>
      Public Overloads Function Equals(ByVal other As Email) As Boolean _
      Implements System.IEquatable(Of Email).Equals
         If other Is Nothing Then Return False

         If Me.Address = other.Address Then
            Return True
         Else
            Return False
         End If
      End Function

   End Class

End Namespace