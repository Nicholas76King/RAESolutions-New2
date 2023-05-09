Imports System
Imports System.Collections.Generic

Namespace Rae.RaeSolutions.Business.Entities

   ''' <summary>
   ''' List of contacts
   ''' </summary>
   Public Class ContactList
      Inherits List(Of Contact)
      Implements ICloneable(Of ContactList)
      Implements IEquatable(Of ContactList)


#Region " Properties"

      ''' <summary>
      ''' Returns first representative found in contact list.
      ''' </summary>
      Public ReadOnly Property Representative() As Contact
         Get
            For Each person As Contact In Me
               If person.Role = Contact.Roles.Representative Then
                  Return person
               End If
            Next

            Return Nothing
         End Get
      End Property


      ''' <summary>
      ''' First architect in contact list
      ''' </summary>
      Public ReadOnly Property Architect() As Contact
         Get
            For Each person As Contact In Me
               If person.Role = Contact.Roles.Architect Then
                  Return person
               End If
            Next

            Return Nothing
         End Get
      End Property


      ''' <summary>
      ''' First engineer in contact list
      ''' </summary>
      Public ReadOnly Property Engineer() As Contact
         Get
            For Each person As Contact In Me
               If person.Role = Contact.Roles.Engineer Then
                  Return person
               End If
            Next

            Return Nothing
         End Get
      End Property


      ''' <summary>
      ''' First contractor in contact list
      ''' </summary>
      Public ReadOnly Property Contractor() As Contact
         Get
            For Each person As Contact In Me
               If person.Role = Contact.Roles.Contractor Then
                  Return person
               End If
            Next

            Return Nothing
         End Get
      End Property

#End Region


#Region " Public methods"

      ''' <summary>
      ''' Clones contact list
      ''' </summary>
      Public Function Clone() As ContactList _
      Implements ICloneable(Of ContactList).Clone
         Dim contactsClone As New ContactList()

         For Each contact As Contact In Me
            contactsClone.Add(contact.Clone())
         Next

         Return contactsClone
      End Function


      ''' <summary>
      ''' Compares contact list
      ''' </summary>
      ''' <param name="other">
      ''' Other contact list to compare
      ''' </param>
      Public Overloads Function Equals(ByVal other As ContactList) As Boolean _
      Implements IEquatable(Of ContactList).Equals
         If Me.Count <> other.Count Then
            Return False
         End If

         For i As Integer = 0 To Me.Count - 1
            If Not Me(i).Equals(other(i)) Then
               Return False
            End If
         Next

         Return True
      End Function

#End Region

   End Class

End Namespace