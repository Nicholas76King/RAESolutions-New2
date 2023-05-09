Option Strict On
Option Explicit On

Imports System
Imports B33 = RAE.RAESolutions.Business
Imports BE1 = RAE.RAESolutions.Business.Entities


Namespace Rae.RaeSolutions.Business.Entities

   ''' <summary>
   ''' Address
   ''' </summary>
   Public Class Address
      Implements ICloneable(Of Address)
      Implements IEquatable(Of Address)



#Region " Declarations"

      Private _addressee As String
      Private _line1 As String
      Private _line2 As String
      Private _city As String
      Private _state As String
      Private _zip5 As nullable_value(Of Integer)
      Private _zip4 As nullable_value(Of Integer)
      Private _country As String

#End Region


#Region " Properties"


      Public Property Addressee() As String
         Get
            Return Me._addressee
         End Get
         Set(ByVal Value As String)
            Me._addressee = Value
         End Set
      End Property

      Public Property Line1() As String
         Get
            Return Me._line1
         End Get
         Set(ByVal Value As String)
            Me._line1 = Value
         End Set
      End Property

      Public Property Line2() As String
         Get
            Return Me._line2
         End Get
         Set(ByVal Value As String)
            Me._line2 = Value
         End Set
      End Property

      Public Property City() As String
         Get
            Return Me._city
         End Get
         Set(ByVal Value As String)
            Me._city = Value
         End Set
      End Property

      Public Property State() As String
         Get
            Return Me._state
         End Get
         Set(ByVal Value As String)
            Me._state = Value
         End Set
      End Property

      Public Property Zip5() As nullable_value(Of Integer)
         Get
            Return Me._zip5
         End Get
         Set(ByVal Value As nullable_value(Of Integer))
            Me._zip5 = Value
         End Set
      End Property

      Public Property Zip4() As nullable_value(Of Integer)
         Get
            Return Me._zip4
         End Get
         Set(ByVal Value As nullable_value(Of Integer))
            Me._zip4 = Value
         End Set
      End Property

      Public Property Country() As String
         Get
            Return Me._country
         End Get
         Set(ByVal Value As String)
            Me._country = Value
         End Set
      End Property


      Public ReadOnly Property AddresseeExists() As Boolean
         Get
            If Not Me._addressee Is Nothing AndAlso Me._addressee.Length > 0 Then
               Return True
            Else
               Return False
            End If
         End Get
      End Property

      Public ReadOnly Property Line1Exists() As Boolean
         Get
            If Not Me._line1 Is Nothing AndAlso Me._line1.Length > 0 Then
               Return True
            Else
               Return False
            End If
         End Get
      End Property

      Public ReadOnly Property Line2Exists() As Boolean
         Get
            If Not Me._line2 Is Nothing AndAlso Me._line2.Length > 0 Then
               Return True
            Else
               Return False
            End If
         End Get
      End Property

      Public ReadOnly Property CityExists() As Boolean
         Get
            If Not Me._city Is Nothing AndAlso Me._city.Length > 0 Then
               Return True
            Else
               Return False
            End If
         End Get
      End Property

      Public ReadOnly Property StateExists() As Boolean
         Get
            If Not Me._state Is Nothing AndAlso Me._state.Length > 0 Then
               Return True
            Else
               Return False
            End If
         End Get
      End Property


      Public ReadOnly Property CountryExists() As Boolean
         Get
            Return (Not Me._state Is Nothing AndAlso Me._state.Length > 0)
         End Get
      End Property


      Public ReadOnly Property IsZip5Valid() As Boolean
         Get
            If Me.Zip5.has_value Then
               Return (Me._zip5.value > 9999 And Me._zip5.value < 100000)
            Else
               Return False
            End If
         End Get
      End Property

      Public ReadOnly Property IsZip4Valid() As Boolean
         Get
            If Me.Zip4.has_value Then
               Return (Me._zip4.value > 999 And Me._zip4.value < 10000)
            Else
               Return False
            End If
         End Get
      End Property

#End Region

      Public Sub New()
         Me._zip4 = New nullable_value(Of Integer)
         Me._zip5 = New nullable_value(Of Integer)
      End Sub



      ''' <summary>Formats address as it would be printed on an envelope.</summary>
      Public Overrides Function ToString() As String
         Dim address, newline As String

         newline = System.Environment.NewLine
         address = ""

         If Me.AddresseeExists Then
            ' adds addressee
            address = Me.Addressee & newline : End If

         If Me.Line1Exists Then
            ' adds line 1
            address &= Me.Line1 & newline : End If

         If Me.Line2Exists Then
            ' adds line 2
            address &= Me.Line2 & newline : End If

         If Me.CityExists Then
            ' adds city
            address &= Me.City : End If

         If Me.StateExists Then
            If Me.CityExists Then
               ' adds comma and space after city
               address &= ", "
            End If
            ' adds state
            address &= Me.State
         End If

         If Me.Zip5.has_value Then
            ' adds zip 5
            address &= " " & Me.Zip5.ToString : End If

            If Me.Zip4.has_value AndAlso Me.Zip4.ToString <> "0" Then
                ' adds zip 4
                address &= "-" & Me.Zip4.ToString : End If

         If Me.CountryExists Then
            ' adds country
            address &= newline & Me.Country : End If

         Return address
      End Function


      Public Overloads Function Equals(ByVal other As Address) As Boolean _
      Implements System.IEquatable(Of Address).Equals
         If other Is Nothing Then
            Return False
         End If

         ' determines whether addresses are equal
         If Me.Addressee = other.Addressee _
         AndAlso Me.Line1 = other.Line1 _
         AndAlso Me.Line2 = other.Line2 _
         AndAlso Me.City = other.City _
         AndAlso Me.State = other.State _
         AndAlso Me.Zip5.equals(other.Zip5) _
         AndAlso Me.Zip4.equals(other.Zip4) _
         AndAlso Me.Country = other.Country Then
            Return True
         Else
            Return False
         End If
      End Function


      ''' <summary>
      ''' Clones address.
      ''' </summary>
      ''' <returns>
      ''' Clone of address.
      ''' </returns>
      Public Function Clone() As Address _
      Implements ICloneable(Of Address).Clone
            Dim addressClone As New BE1.Address()

            With addressClone
            .Addressee = Me.Addressee
            .Line1 = Me.Line1
            .Line2 = Me.Line2
            .City = Me.City
            .State = Me.State
            .Zip5 = Me.Zip5.clone()
            .Zip4 = Me.Zip4.clone()
            .Country = Me.Country
         End With

         Return addressClone
      End Function

   End Class


End Namespace
