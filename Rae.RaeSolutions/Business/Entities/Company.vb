Option Strict On
Option Explicit On 

Imports System
Imports Rae.RaeSolutions.DataAccess.Projects

Namespace Rae.RaeSolutions.Business.Entities


  Public Class Company
    Implements ICloneable(Of Company)
    Implements IEquatable(Of Company)
    Implements ICopyable(Of Company)
    Implements IPersistable
    Implements IChangeAware(Of Company)



#Region " Declarations"
    Protected m_name As String
    Protected m_address As Address
    Protected m_phoneNum As ContactNum
    Protected m_faxNum As ContactNum
    Protected m_email As Email
    Protected m_website As String
#End Region


#Region " Properties"


    Private m_Id As nullable_value(Of Integer)
    ''' <summary>
    ''' Id
    ''' </summary>
    Public Property Id() As nullable_value(Of Integer)
      Get
        Return Me.m_Id
      End Get
      Set(ByVal value As nullable_value(Of Integer))
        Me.m_Id = value
      End Set
    End Property


    Private m_CustomerNum As nullable_value(Of Integer)
    ''' <summary>
    ''' Customer number.
    ''' </summary>
    Public Property CustomerNum() As nullable_value(Of Integer)
      Get
        Return Me.m_CustomerNum
      End Get
      Set(ByVal value As nullable_value(Of Integer))
        Me.m_CustomerNum = value
      End Set
    End Property


    Private m_RepNum As nullable_value(Of Integer)
    ''' <summary>
    ''' RepNum
    ''' </summary>
    Public Property RepNum() As nullable_value(Of Integer)
      Get
        Return Me.m_RepNum
      End Get
      Set(ByVal value As nullable_value(Of Integer))
        Me.m_RepNum = value
      End Set
    End Property


    Private m_Description As String
    ''' <summary>
    ''' Description
    ''' </summary>
    Public Property Role() As String
      Get
        Return Me.m_Description
      End Get
      Set(ByVal value As String)
        Me.m_Description = value
      End Set
    End Property


    Public Property Name() As String
      Get
        Return Me.m_name
      End Get
      Set(ByVal Value As String)
        Me.m_name = Value
      End Set
    End Property

    Public Property Address() As Entities.Address
      Get
        Return Me.m_address
      End Get
      Set(ByVal Value As Entities.Address)
        Me.m_address = Value
      End Set
    End Property

    Public Property PhoneNum() As Entities.ContactNum
      Get
        Return Me.m_phoneNum
      End Get
      Set(ByVal Value As Entities.ContactNum)
        Me.m_phoneNum = Value
      End Set
    End Property

    Public Property FaxNum() As Entities.ContactNum
      Get
        Return Me.m_faxNum
      End Get
      Set(ByVal Value As Entities.ContactNum)
        Me.m_faxNum = Value
      End Set
    End Property

    Public Property Email() As Entities.Email
      Get
        Return Me.m_email
      End Get
      Set(ByVal Value As Entities.Email)
        Me.m_email = Value
      End Set
    End Property

    Public Property Website() As String
      Get
        Return Me.m_website
      End Get
      Set(ByVal Value As String)
        Me.m_website = Value
      End Set
    End Property


    ''' <summary>
    ''' Company profile as text description.
    ''' </summary>
    Public ReadOnly Property Profile() As String
      Get
        Return Me.GetProfile()
      End Get
    End Property


    Private m_originalState As Company
    ''' <summary>
    ''' Original state of company after last load or save.
    ''' </summary>
    Public Property OriginalState() As Company Implements IChangeAware(Of Company).OriginalState
      Get
        Return Me.m_originalState
      End Get
      Set(ByVal value As Company)
        Me.m_originalState = value
      End Set
    End Property


    ''' <summary>
    ''' Determines whether state has changed since original state.
    ''' </summary>
    Public ReadOnly Property StateChanged() As Boolean Implements IChangeAware(Of Company).StateChanged
      Get
        If Me.Equals(Me.OriginalState) Then
          Return False
        Else
          Return True
        End If
      End Get
    End Property


    Private m_Contacts As ContactList
    ''' <summary>
    ''' Gets list of contacts with company ID.
    ''' </summary>
    Public Function GetContactsByCompanyId(ByVal refresh As Boolean) As ContactList
      If refresh AndAlso Me.Id.has_value Then
            m_Contacts = ContactsDataAccess.RetrieveByCompanyId(Me.Id.value)
         Else
            ' if hasn't been loaded then will load even is refresh is false
            If m_Contacts Is Nothing AndAlso Me.Id.has_value Then
               m_Contacts = ContactsDataAccess.RetrieveByCompanyId(Me.Id.value)
            End If
         End If

         Return Me.m_Contacts
      End Function


      ''' <summary>
      ''' Gets list of contacts with customer number.
      ''' </summary>
      ''' <param name="refresh">
      ''' When true refreshes list of contacts; when false uses existing list.
      ''' </param>
      Public Function GetContactsByCustomerNum(ByVal refresh As Boolean) As ContactList
         If refresh AndAlso Me.CustomerNum.has_value Then
            Me.m_Contacts = ContactsDataAccess.RetrieveByCompanyId(Me.Id.value)
         Else
            If Me.m_Contacts Is Nothing AndAlso Me.Id.has_value Then
               Me.m_Contacts = ContactsDataAccess.RetrieveByCompanyId(Me.Id.value)
            End If
         End If

         Return Me.m_Contacts
      End Function

#End Region


#Region " Public methods"

    ''' <summary>
    ''' Constructs
    ''' </summary>
    Public Sub New()
      Me.m_Id = New nullable_value(Of Integer)
      Me.m_address = New Address
      Me.m_phoneNum = New ContactNum
      Me.m_faxNum = New ContactNum
      Me.m_email = New Email
      Me.m_CustomerNum = New nullable_value(Of Integer)
      Me.m_RepNum = New nullable_value(Of Integer)
    End Sub


    ''' <summary>
    ''' Loads company from data source. Requires Id.
    ''' </summary>
    Public Sub Load() Implements IPersistable.Load
      Dim co As Company

      If Me.Id Is Nothing OrElse Not Me.Id.has_value Then
        Throw New ArgumentNullException("Attempt to load company failed. Company ID is null.")
      End If

      If Me.Id.value < 1 Then
        Throw New ArgumentException("Attempt to load company failed. Id is less than valid range.")
      End If

      ' loads company from data source
      co = CompaniesDa.Retrieve(Me.Id.value)
      ' copies loaded companies values to Me
      Me.Copy(co)
      ' sets original state
      Me.OriginalState = Me.Clone()
    End Sub


    ''' <summary>
    ''' Saves company.
    ''' </summary>
    Public Sub Save() Implements IPersistable.Save
      ' saves company info
      If Not Me.Id.has_value OrElse Not CompaniesDa.Exists(Me.Id.value) Then
        CompaniesDa.Create(Me)
      Else
        CompaniesDa.Update(Me)
      End If
      ' remembers current state of company
      Me.OriginalState = Me.Clone()
    End Sub


    ''' <summary>Clones company</summary>
    ''' <returns>Company clone as Object</returns>
    Public Function Clone() As Company _
    Implements ICloneable(Of Company).Clone
      Dim companyClone As New Company

      With companyClone
        .Id = Me.Id.clone()
        .CustomerNum = Me.CustomerNum.clone()
        .RepNum = Me.RepNum.clone()
        .Name = Me.Name
        .Address = Me.Address.Clone()
        .PhoneNum = Me.PhoneNum.Clone()
        .FaxNum = Me.FaxNum.Clone()
        .Email = Me.Email.Clone()
        .Website = Me.Website
        .Role = Me.Role
      End With

      Return companyClone
    End Function


    ''' <summary>
    ''' Copies another company
    ''' </summary>
    ''' <param name="other">
    ''' Other company to copy
    ''' </param>
    Public Sub Copy(ByVal other As Company) _
    Implements ICopyable(Of Company).Copy
      If other Is Nothing Then
        Throw New System.ArgumentNullException("Company copy failed. The company to copy is null.")
      End If

      Me.CustomerNum = other.CustomerNum.clone()
      Me.RepNum = other.RepNum.clone()
      Me.Address = other.Address.Clone()
      Me.Email = other.Email.Clone()
      Me.FaxNum = other.FaxNum.Clone()
      Me.Id = other.Id
      Me.Name = other.Name
      Me.PhoneNum = other.PhoneNum.Clone()
      Me.Website = other.Website
      Me.Role = other.Role

    End Sub


    ''' <summary>Company name</summary>
    ''' <returns>Company name</returns>
    Public Overrides Function ToString() As String
      Return Me.Name
    End Function


    ''' <summary>
    ''' Indicates whether companies are equal.
    ''' </summary>
    ''' <param name="other">
    ''' Other company to compare equality with.
    ''' </param>
    ''' <returns>
    ''' True if companies are equal; else false.
    ''' </returns>
    Public Overloads Function Equals(ByVal other As Company) As Boolean _
    Implements IEquatable(Of Company).Equals
      If other Is Nothing Then Return False

      If Me.Address.Equals(other.Address) _
      AndAlso Me.Email.Equals(other.Email) _
      AndAlso Me.FaxNum.Equals(other.FaxNum) _
      AndAlso Me.Id.equals(other.Id) _
      AndAlso Me.Name = other.Name _
      AndAlso Me.PhoneNum.Equals(other.PhoneNum) _
      AndAlso Me.Website = other.Website _
      AndAlso Me.CustomerNum.equals(other.CustomerNum) _
      AndAlso Me.RepNum.equals(other.RepNum) _
      AndAlso Me.Role = other.Role Then
        Return True
      Else
        Return False
      End If
    End Function

#End Region


    Private Function GetProfile() As String
      Dim _profile As String
      Dim newLine As String

      newLine = System.Environment.NewLine

      '_profile = "Account #: " & Me.m_accountNum.ToString & newLine
      _profile = Me.m_name.ToString & newLine
      _profile &= Me.m_address.ToString
      _profile &= "Phone: " & Me.m_phoneNum.ToString & newLine
      _profile &= "Fax: " & Me.m_faxNum.ToString & newLine
      _profile &= Me.m_email.ToString & newLine
      _profile &= Me.m_website

      Return _profile
    End Function


  End Class

End Namespace