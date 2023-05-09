Imports System.Text

Namespace IntegratedSecurity


   Public Class PseudoEncryptedPassword

      Private _UserName As String
      Private _Password As String
      Private _AccessLevel As Rae.Security.IntegratedSecurity.AccessLevel
      Private _AuthorityGroup As Rae.Security.IntegratedSecurity.UserGroup


      Public ReadOnly Property PseudoEncryptedPasswordString As String
         Get
                Dim tempPasswordString As String = _Password & "-" & _UserName & "-" & CInt(_AuthorityGroup).ToString & "-" & CInt(_AccessLevel).ToString & "-200-300"
            Return PseudoEncryptData(tempPasswordString)
         End Get
      End Property

      Public Sub New(ByVal iUserName As String, ByVal iPassword As String, ByVal iAccessLevel As Rae.Security.IntegratedSecurity.AccessLevel, ByVal iAuthorityGroup As Rae.Security.IntegratedSecurity.UserGroup)
         _UserName = iUserName
         _Password = iPassword
         _AccessLevel = iAccessLevel
         _AuthorityGroup = iAuthorityGroup
      End Sub



      Public Shared Function PseudoEncryptData(ByVal Data As String) As String
         Dim eNC_data() As Byte = ASCIIEncoding.ASCII.GetBytes(Data)
         Dim eNC_str As String = System.Convert.ToBase64String(eNC_data)
         Return eNC_str
      End Function

   End Class


End Namespace
