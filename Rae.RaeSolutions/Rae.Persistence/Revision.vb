Imports System

Namespace Rae.Persistence

Public Class Revision
   Implements IEquatable(Of Revision)
   Implements IComparable(Of Revision)


#Region " External"
   
   Sub New()
   End Sub

   ''' <summary>
   ''' Initializes a new revision with a major and minor revision.
   ''' </summary>
   Sub New(major As Integer, minor As Integer)
      major_ = major
      minor_ = minor
   End Sub


   ''' <summary>
   ''' Major revision supersedes the minor revision.
   ''' </summary>
   ''' <remarks>
   ''' If a revision's major is greater, then it is always comparitively larger,
   ''' even if it's minor revision is smaller.
   ''' </remarks>
   Overridable Property Major() As Integer
      Get
         Return major_
      End Get
      Set(value As Integer)
         major_ = value
      End Set
   End Property

   ''' <summary>
   ''' Minor revision is superceded by the major revision.
   ''' </summary>
   Overridable Property Minor() As Integer
      Get
         Return minor_
      End Get
      Set(value As Integer)
         minor_ = value
      End Set
   End Property


   ''' <summary>
   ''' True if revisions are equal
   ''' </summary>
   Shared Operator =(left As Revision, right As Revision) As Boolean
      Return left.Equals(right)
   End Operator

   ''' <summary>
   ''' True if revision are NOT equal
   ''' </summary>
   Shared Operator <>(left As Revision, right As Revision) As Boolean
      Return Not left.Equals(right)
   End Operator


   ''' <summary>
   ''' Returns a new incremented revision
   ''' </summary>
   Function Increment() As Revision
      Dim incremented As New Revision(Me.Major, Me.Minor + 1)
      Return incremented
   End Function


   ''' <summary>
   ''' True if this revision is equal to the other
   ''' </summary>
   ''' <param name="other">
   ''' The other revision to compare equality with
   ''' </param>
   Overloads Function Equals(other As Revision) As Boolean _
   Implements System.IEquatable(Of Revision).Equals
      Dim areEqual As Boolean
      
      If other Is Nothing Then
        areEqual = False
      ElseIf Major = other.Major AndAlso Minor = other.Minor Then
         areEqual = True
      Else
         areEqual = False
      End If

      Return areEqual
   End Function
   
   ''' <summary>
   ''' True if this revision is equal to the other
   ''' </summary>
   ''' <param name="obj">
   ''' Other revision
   ''' </param>
   Overrides Function Equals(obj As Object) As Boolean
      Dim areEqual As Boolean
      
      If TypeOf obj Is Revision Then
         areEqual = Me.Equals(CType(obj, Revision))
      Else
         areEqual = False
      End If
      
      Return areEqual
   End Function

   ''' <summary>
   ''' Compares this revision with another revision to see which is greater.
   ''' </summary>
   ''' <param name="other">
   ''' Other revision to compare against
   ''' </param>
   ''' <remarks>
   ''' If me less other return less 0
   ''' If me = other return 0
   ''' If me greater other return greater 0
   ''' A null is less than a non null
   ''' </remarks>
   Function CompareTo(other As Revision) As Integer _
   Implements IComparable(Of Revision).CompareTo
      Return compare(me, other)
   End Function
   
   
   ''' <summary>
   ''' String representation of revision (Format: [Major].[Minor]) (Ex: 1.2)
   ''' </summary>
   Overrides Function ToString() As String
      Return Major & "." & Minor
   End Function

#End Region


#Region " Internal"

   Protected major_ As Integer
   Protected minor_ As Integer


   ''' <summary>
   ''' Compares two values to determine which is greater
   ''' </summary>
   ''' <remarks>
   ''' If x less y return less 0
   ''' If x = y return 0
   ''' If x greater y return greater 0
   ''' A null is less than a non null
   ''' </remarks>
   Private Function compare(x As Revision, y As Revision) As Integer
      Dim result As Integer

      'if x is null and y is not then y is greater
      If x Is Nothing AndAlso y IsNot Nothing Then
         result = -3
      'if x is not null and y is then x is greater
      ElseIf x IsNot Nothing AndAlso y Is Nothing Then
         result = 3
      'if x and y are null then return they're equal
      ElseIf x Is Nothing AndAlso y Is Nothing Then
         result = 0
      ElseIf x.Major = y.Major AndAlso x.Minor = y.Minor Then
         result =  0
      ElseIf x.Major = y.Major Then
         If x.Minor > y.Minor Then
            result = 1
         Else
            result = -1
         End If
      ElseIf x.Major > y.Major Then
         result = 2
      Else
         result = -2
      End If

      Return result
   End Function

#End Region

End Class

End Namespace