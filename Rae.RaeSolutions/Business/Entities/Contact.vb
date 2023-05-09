Option Strict On
Option Explicit On

Imports System
Imports Rae.RaeSolutions.DataAccess.Projects

Namespace Rae.RaeSolutions.Business.Entities


    ''' <summary>
    ''' Contact info
    ''' </summary>
    Public Class Contact
        Implements ICloneable(Of Contact)
        Implements ICopyable(Of Contact)
        Implements IEquatable(Of Contact)
        Implements IPersistable
        Implements IChangeAware(Of Contact)


        ''' <summary>
        ''' List of the contact roles
        ''' </summary>
        Public Class Roles
            Public Shared Representative As String = "Representative"
            Public Shared Employee As String = "Employee"
            Public Shared Contractor As String = "Contractor"
            Public Shared GeneralContractor As String = "General Contractor"
            Public Shared Architect As String = "Architect"
            Public Shared Engineer As String = "Engineer"
            'Public Shared InvoiceTo As String = "Invoice To"
            'Public Shared ShipTo As String = "Ship To"
        End Class


#Region " Properties"

        Private id_ As nullable_value(Of Integer)
        ''' <summary>
        ''' Id
        ''' </summary>
        Public Property Id() As nullable_value(Of Integer)
            Get
                Return Me.id_
            End Get
            Set(ByVal value As nullable_value(Of Integer))
                Me.id_ = value
            End Set
        End Property


        Private customerNum_ As nullable_value(Of Integer)
        ''' <summary>
        ''' Customer number
        ''' </summary>
        Public Property CustomerNum() As nullable_value(Of Integer)
            Get
                Return Me.customerNum_
            End Get
            Set(ByVal value As nullable_value(Of Integer))
                Me.customerNum_ = value
            End Set
        End Property


        Private repNum_ As nullable_value(Of Integer)
        ''' <summary>
        ''' Representative number
        ''' </summary>
        Public Property RepNum() As nullable_value(Of Integer)
            Get
                Return Me.repNum_
            End Get
            Set(ByVal value As nullable_value(Of Integer))
                Me.repNum_ = value
            End Set
        End Property


        Protected name_ As Name
        ''' <summary>
        ''' Contact's name can contain first, middle and last name and courtesy title.
        ''' </summary>
        Public Property Name() As Name
            Get
                Return Me.name_
            End Get
            Set(ByVal Value As Name)
                Me.name_ = Value
            End Set
        End Property


        Protected role_ As String
        ''' <summary>
        ''' Contact's role indicates their responsibilities in the process (ex. Employee, Rep, etc.).
        ''' </summary>
        Public Property Role() As String
            Get
                Return Me.role_
            End Get
            Set(ByVal value As String)
                Me.role_ = value
            End Set
        End Property


        Protected address_ As Address
        ''' <summary>
        ''' Mailing address associated with the contact.
        ''' </summary>
        Public Property Address() As Address
            Get
                Return Me.address_
            End Get
            Set(ByVal Value As Address)
                Me.address_ = Value
            End Set
        End Property


        Protected email_ As Email
        ''' <summary>
        ''' Email address
        ''' </summary>
        Public Property Email() As Email
            Get
                Return Me.email_
            End Get
            Set(ByVal Value As Email)
                Me.email_ = Value
            End Set
        End Property


        Private phoneNum_ As ContactNum
        ''' <summary>
        ''' Phone number
        ''' </summary>
        Public Property PhoneNum() As ContactNum
            Get
                Return Me.phoneNum_
            End Get
            Set(ByVal value As ContactNum)
                Me.phoneNum_ = value
            End Set
        End Property


        Private faxNum_ As ContactNum
        ''' <summary>
        ''' Fax number
        ''' </summary>
        Public Property FaxNum() As ContactNum
            Get
                Return Me.faxNum_
            End Get
            Set(ByVal value As ContactNum)
                Me.faxNum_ = value
            End Set
        End Property


        Private company_ As Company
        ''' <summary>
        ''' Company
        ''' </summary>
        Public Property Company() As Company
            Get
                Return Me.company_
            End Get
            Set(ByVal value As Company)
                Me.company_ = value
            End Set
        End Property


        ''' <summary>
        ''' Profile of contact. Text description of contact.
        ''' </summary>
        Public ReadOnly Property Profile() As String
            Get
                Return Me.getTextProfile()
            End Get
        End Property


        Private m_originalState As Contact
        ''' <summary>
        ''' Original state of contact after last load or save.
        ''' </summary>
        Public Property OriginalState() As Contact _
        Implements IChangeAware(Of Contact).OriginalState
            Get
                Return Me.m_originalState
            End Get
            Set(ByVal value As Contact)
                Me.m_originalState = value
            End Set
        End Property


        ''' <summary>
        ''' Determines whether contact info has changed.
        ''' </summary>
        Public ReadOnly Property StateChanged() As Boolean _
        Implements IChangeAware(Of Contact).StateChanged
            Get
                ' checks if any changes have occurred
                If Me.Equals(Me.OriginalState) Then
                    Return False
                Else
                    Return True
                End If
            End Get
        End Property

#End Region


#Region " Public methods"

        ''' <summary>
        ''' Initializes new instance of contact
        ''' </summary>
        Public Sub New()
            ' constructs objects
            Me.id_ = New nullable_value(Of Integer)
            Me.name_ = New Name
            Me.address_ = New Address
            Me.phoneNum_ = New ContactNum
            Me.faxNum_ = New ContactNum
            Me.email_ = New Email
            Me.company_ = New Company
            Me.repNum_ = New nullable_value(Of Integer)
            Me.customerNum_ = New nullable_value(Of Integer)
        End Sub

        Public Sub New(ByVal role As String)
            ' constructs objects
            Me.role_ = role
            Me.id_ = New nullable_value(Of Integer)
            Me.name_ = New Name
            Me.address_ = New Address
            Me.phoneNum_ = New ContactNum
            Me.faxNum_ = New ContactNum
            Me.email_ = New Email
            Me.company_ = New Company
            Me.repNum_ = New nullable_value(Of Integer)
            Me.customerNum_ = New nullable_value(Of Integer)
        End Sub



        ''' <summary>
        ''' Loads contact from data source. Requires contact ID.
        ''' </summary>
        Public Sub Load() _
        Implements IPersistable.Load
            If Not Me.Id.has_value Then Throw New ArgumentNullException("Attempt to load contact failed. Contact ID is null.")

            Me.Copy(ContactsDataAccess.Retrieve(Me.Id.value))
            Me.OriginalState = Me.Clone()
        End Sub


        ''' <summary>
        ''' Saves contact to data source.
        ''' </summary>
        Public Sub Save() _
        Implements IPersistable.Save

            If Not Me.Id.has_value OrElse Not ContactsDataAccess.Exists(Me.Id.value) Then
                ContactsDataAccess.Create(Me)
            Else
                ContactsDataAccess.Update(Me)
            End If
            Me.OriginalState = Me.Clone()
        End Sub


        ''' <summary>
        ''' Clones contact
        ''' </summary>
        ''' <returns>
        ''' Clone of contact.
        ''' </returns>
        Public Function Clone() As Contact _
        Implements ICloneable(Of Contact).Clone
            Dim contact As New Contact

            contact.Address = Me.Address.Clone()
            contact.Company = Me.Company.Clone()
            contact.Role = Me.Role
            contact.Email = Me.Email.Clone()
            contact.FaxNum = Me.FaxNum.Clone()
            contact.Id = Me.Id
            contact.Name = Me.Name.Clone()
            contact.PhoneNum = Me.PhoneNum.Clone()
            contact.RepNum = Me.RepNum.clone()
            contact.CustomerNum = Me.CustomerNum.clone()

            Return contact
        End Function


        ''' <summary>
        ''' Copies another contact.
        ''' </summary>
        ''' <param name="other">
        ''' Other contact to copy.
        ''' </param>
        Public Sub Copy(ByVal other As Contact) _
        Implements ICopyable(Of Contact).Copy
            Me.Address = other.Address.Clone()
            Me.Company = other.Company.Clone()
            Me.Role = other.Role
            Me.Email = other.Email.Clone()
            Me.FaxNum = other.FaxNum.Clone()
            Me.Id = other.Id
            Me.Name = other.Name.Clone()
            Me.PhoneNum = other.PhoneNum.Clone()
            Me.RepNum = other.RepNum.clone()
            Me.CustomerNum = other.CustomerNum.clone()
        End Sub


        ''' <summary>
        ''' Compares equality of contacts.
        ''' </summary>
        ''' <param name="other">
        ''' Other contact to compare equality with.
        ''' </param>
        ''' <returns>
        ''' True if contacts are equal; else false.
        ''' </returns>
        ''' <remarks></remarks>
        Public Overloads Function Equals(ByVal other As Contact) As Boolean _
        Implements IEquatable(Of Contact).Equals
            If other Is Nothing Then Return False

            If Me.Address.Equals(other.Address) _
            AndAlso Me.Company.Id.equals(other.Company.Id) _
            AndAlso Me.Role = other.Role _
            AndAlso Me.Email.Equals(other.Email) _
            AndAlso Me.FaxNum.Equals(other.FaxNum) _
            AndAlso Me.Id.equals(other.Id) _
            AndAlso Me.Name.Equals(other.Name) _
            AndAlso Me.PhoneNum.Equals(other.PhoneNum) _
            AndAlso Me.CustomerNum.equals(other.CustomerNum) _
            AndAlso Me.RepNum.equals(other.RepNum) Then
                Return True
            Else
                Return False
            End If
        End Function


        ''' <summary>
        ''' Contact's last name, comma and then first name.
        ''' </summary>
        ''' <returns>
        ''' Contact's last name, comma and then first name.
        ''' </returns>
        Public Overrides Function ToString() As String
            Return Me.Name.LastThenFirstName()
        End Function

#End Region


        ''' <summary>
        ''' Gets contact's profile as text
        ''' </summary>
        Private Function getTextProfile() As String
            Dim textProfile As String
            Dim newLine As String

            ' Company
            ' FirstName LastName
            ' Line1
            ' Line2
            ' City, State Zip5-Zip4
            ' Phone: (AreaCode) PhoneNum ext. Ext
            ' Fax:
            ' email

            newLine = System.Environment.NewLine

            textProfile = Me.company_.Name & newLine
            textProfile &= Me.name_.FirstThenLastName & newLine
            textProfile &= Me.address_.ToString & newLine
            textProfile &= "Phone: " & Me.phoneNum_.ToString & newLine
            textProfile &= "Fax: " & Me.faxNum_.ToString & newLine
            textProfile &= Me.email_.Address

            Return textProfile
        End Function


    End Class

End Namespace
