Option Strict On
Option Explicit On 

Imports System

Namespace Rae.RaeSolutions.Business.Entities

  Public Class DeficientContact
    Implements ICloneable(Of DeficientContact)
    Implements IEquatable(Of DeficientContact)


    Private _contactName As String
    Private _companyName As String


    Public Property ContactName() As String
      Get
        Return Me._contactName
      End Get
      Set(ByVal Value As String)
        Me._contactName = Value
      End Set
    End Property

    Public Property CompanyName() As String
      Get
        Return Me._companyName
      End Get
      Set(ByVal Value As String)
        Me._companyName = Value
      End Set
    End Property


    ''' <summary>
    ''' Clones contact.
    ''' </summary>
    Public Function Clone() As DeficientContact _
    Implements ICloneable(Of DeficientContact).Clone
      Dim contact As New DeficientContact
      contact.ContactName = Me.ContactName
      contact.CompanyName = Me.CompanyName
      Return contact
    End Function


    ''' <summary>
    ''' Compares equality of contacts.
    ''' </summary>
    Public Overloads Function Equals(ByVal other As DeficientContact) As Boolean _
    Implements IEquatable(Of DeficientContact).Equals
      If Me.ContactName = other.ContactName _
      AndAlso Me.CompanyName = other.CompanyName Then
        Return True
      Else
        Return False
      End If
    End Function
  End Class
End Namespace