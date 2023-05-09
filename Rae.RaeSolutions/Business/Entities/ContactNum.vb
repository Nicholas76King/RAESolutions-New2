Option Strict On
Option Explicit On 

Imports System


Namespace Rae.RaeSolutions.Business.Entities


   ''' <history>Implement IDeepCloneable on 11/18/2005</history>
   ''' <history by="Casey Joyce" finish="2006/05/07">
   ''' Modify:
   ''' Replace IDeepCloneable w/ ICloneable(Of ContactNum)
   ''' Replace override Equals w/ IEquatable(Of ContactNum)
   ''' </history>
   Public Class ContactNum
      Implements ICloneable(Of ContactNum)
      Implements IEquatable(Of ContactNum)


#Region " Properties"

      Private _areaCode As nullable_value(Of Integer)
      Public Property AreaCode() As nullable_value(Of Integer)
         Get
            Return Me._areaCode
         End Get
         Set(ByVal value As nullable_value(Of Integer))
            Me._areaCode = value
         End Set
      End Property


      Private _number As nullable_value(Of Integer)
      Public Property Number() As nullable_value(Of Integer)
         Get
            Return Me._number
         End Get
         Set(ByVal value As nullable_value(Of Integer))
            Me._number = value
         End Set
      End Property


      Private _extension As nullable_value(Of Integer)
      Public Property Extension() As nullable_value(Of Integer)
         Get
            Return Me._extension
         End Get
         Set(ByVal Value As nullable_value(Of Integer))
            Me._extension = Value
         End Set
      End Property


      Private m_Description As String
      ''' <summary>
      ''' Description
      ''' </summary>
      Public Property Description() As String
         Get
            Return Me.m_Description
         End Get
         Set(ByVal value As String)
            Me.m_Description = value
         End Set
      End Property




      Public Overridable ReadOnly Property IsPhoneNumValid() As Boolean
         Get
            If Me.Number.has_value Then
               ' determines whether phone number is 7 digits
               Return (Me.Number.value > 999999 And Me.Number.value < 10000000)
            Else
               Return False
            End If

         End Get
      End Property


      Public Overridable ReadOnly Property IsAreaCodeValid() As Boolean
         Get
            If Me.AreaCode.has_value Then
               ' determines whether area code is 3 digits
               Return (Me.AreaCode.value > 99 And Me.AreaCode.value < 1000)
            Else
               Return False
            End If
         End Get
      End Property

#End Region

      Public Sub New()
         Me._areaCode = New nullable_value(Of Integer)
         Me._number = New nullable_value(Of Integer)
         Me._extension = New nullable_value(Of Integer)
      End Sub

      Public Sub New(ByVal areaCode As Integer, ByVal number As Integer)
         Me.New()
         Me.AreaCode.value = areaCode
         Me.Number.value = number
      End Sub


      ''' <summary>
      ''' Clones contact number.
      ''' </summary>
      ''' <returns>Contact number</returns>
      Public Function Clone() As ContactNum _
      Implements ICloneable(Of ContactNum).Clone
         Dim phoneNumClone As New ContactNum

         With phoneNumClone
            .Description = Me.Description
            .AreaCode = Me.AreaCode.clone()
            .Number = Me.Number.clone()
            .Extension = Me.Extension.clone()
         End With

         Return phoneNumClone
      End Function


      ''' <summary>Determines whether phone numbers are equal</summary>
      Public Overloads Function Equals(ByVal other As ContactNum) As Boolean _
      Implements IEquatable(Of ContactNum).Equals
         ' checks for null
         If other Is Nothing Then
            Return False
         End If

         ' determines whether phone numbers are equal
         If Me.Number.equals(other.Number) _
         AndAlso Me.AreaCode.equals(other.AreaCode) _
         AndAlso Me.Extension.equals(other.Extension) Then
            Return True
         Else
            Return False
         End If
      End Function


      ''' <summary>Formats phone number, example: (918) 555-5555 ext 1234).</summary>
      Public Overrides Function ToString() As String
         ' (918) 555-5555 ext 1234
         Dim phone As String

         phone = ""

         ' determines whether area code exists
         If Me.AreaCode.has_value Then
            ' adds area code
            phone = "(" & Me.AreaCode.ToString & ")" : End If


         ' determines whether phone number exists
         If Me.Number.has_value Then
            ' determines whether area code exists
            If Me.AreaCode.has_value Then
               ' adds space
               phone &= " " : End If

            ' determines whether phone number is 7 digits long (so can be formatted correctly)
            If Me.Number.ToString.Length >= 7 Then
               ' formats like ###-####
               phone &= Me.Number.ToString.Substring(0, 3) & "-" & Me.Number.ToString.Substring(3, 4)
            Else
               phone &= Me.Number.ToString : End If
         End If


         ' determines whether extension exists
         If Me.Extension.has_value Then
            ' determines whether phone number or area code exists
            If Me.Number.has_value OrElse Me.AreaCode.has_value Then
               ' adds space
               phone &= " " : End If
            ' adds extension
            phone &= "ext " & Me.Extension.ToString
         End If

         Return phone
      End Function

   End Class


End Namespace