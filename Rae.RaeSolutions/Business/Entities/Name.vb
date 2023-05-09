Option Strict On
Option Explicit On

Imports System.Collections.Generic

Namespace Rae.RaeSolutions.Business.Entities


   ''' <summary>The class represents a name which may include title, first, middle and last names.
   ''' </summary>
   ''' <remarks>The represented name is available in different formats (i.e. full name, last then first name, etc.).
   ''' </remarks>
   ''' <history>[CASEYJ]	10/18/2005	Created
   ''' </history>
   Public Class Name
      Implements ICloneable(Of Name)


#Region " Declarations"

      Private firstName_ As String
      Private middleName_ As String
      Private lastName_ As String
      Private title_ As CourtesyTitle

#End Region


#Region " Properties"

      ''' <summary>
      ''' First name
      ''' </summary>
      Public Property FirstName() As String
         Get
            Return Me.firstName_
         End Get
         Set(ByVal Value As String)
            Me.firstName_ = Value
         End Set
      End Property

      ''' <summary>
      ''' Middle name
      ''' </summary>
      Public Property MiddleName() As String
         Get
            Return Me.middleName_
         End Get
         Set(ByVal Value As String)
            Me.middleName_ = Value
         End Set
      End Property

      ''' <summary>
      ''' Last name
      ''' </summary>
      Public Property LastName() As String
         Get
            Return Me.lastName_
         End Get
         Set(ByVal Value As String)
            Me.lastName_ = Value
         End Set
      End Property

      ''' <summary>
      ''' Person's courtesy title that distinguishes their sex and possibly marriage status.
      ''' </summary>
      Public Property Title() As CourtesyTitle
         Get
            Return Me.title_
         End Get
         Set(ByVal Value As CourtesyTitle)
            Me.title_ = Value
         End Set
      End Property


      ''' <summary>Gets string with title then first then middle then last name; each seperated by a space.
      ''' Or sets title, first name, middle name and last name (expected format: Title First Middle Last)</summary>
      Public Property FullName() As String
         Get
            Return Me.getFullName()
         End Get
         Set(ByVal value As String)
            parseFullName(value)
         End Set
      End Property


      ''' <summary>Gets string with first name then last name seperated by a space.</summary>
      ''' <remarks>Middle name is not included, even if it exists.</remarks>
      Public ReadOnly Property FirstThenLastName() As String
         Get
            Return Me.getFirstThenLastName()
         End Get
      End Property

      ''' <summary>Gets string with last name then first name seperated by a comma and a space.</summary>
      ''' <remarks>Middle name is not included, even if it exists.</remarks>
      Public ReadOnly Property LastThenFirstName() As String
         Get
            Return Me.getLastThenFirstName()
         End Get
      End Property

#End Region


#Region " Public methods"

      ''' <summary>
      ''' Initializes a new instance of name.
      ''' </summary>
      Public Sub New()
         Me.initialize()
      End Sub


      ''' <summary>
      ''' Deeply clones name; cloned name owns its own reference
      ''' </summary>
      Public Function Clone() As Name _
      Implements ICloneable(Of Name).Clone
         Dim nameClone As New Name()

         nameClone.FirstName = Me.FirstName
         nameClone.MiddleName = Me.MiddleName
         nameClone.LastName = Me.LastName
         nameClone.Title = Me.Title

         Return nameClone
      End Function


#Region " ToString()"

      ''' <summary>
      ''' Delegate (method signature) for ToString() method.
      ''' </summary>
      Public Delegate Function ToStringSignature() As String

      ''' <summary>
      ''' This delegate determines what is returned by the ToString() method.
      ''' </summary>
      Public ToStringPointer As ToStringSignature

      Protected Overridable Sub initializeToStringDelegate()
         Me.ToStringPointer = AddressOf getLastThenFirstName
      End Sub

      ''' <summary>
      ''' Gets string representation of name which by default is last then first name.
      ''' </summary>
      Public Overrides Function ToString() As String
         Return Me.ToStringPointer.Invoke()
      End Function

#End Region
      

      ''' <summary>Compares names</summary>
      Public Overloads Overrides Function Equals(ByVal nameToCompare As Object) As Boolean
         Dim name As Name

         ' determines whether nameToCompare is type Name
         If Not TypeOf nameToCompare Is Name Then Return False

         ' converts to type Name
         name = DirectCast(nameToCompare, Name)

         ' compares names
         If Me.FirstName = name.FirstName _
         AndAlso Me.LastName = name.LastName _
         AndAlso Me.Title = name.Title Then
            Return True
         Else
            Return False
         End If
      End Function

#End Region


#Region " Private methods"

      Private Sub initialize()
         Me.Title = CourtesyTitle.NotSet
         initializeToStringDelegate()
      End Sub


      Private Sub parseFullName(ByVal fullName As String)
         If String.IsNullOrEmpty(fullName) Then
            title_ = CourtesyTitle.NotSet
            firstName_ = ""
            middleName_ = ""
            lastName_ = ""
            Exit Sub
         End If
         '        Spaces
         'title   >     Mr (Joe Bob ...) Larry Joyce
         'title   3     Mr Casey Loran Joyce
         'title   2     Mr Casey Joyce
         'title   1     Mr Joyce
         'title   0     Mr

         'no      >     
         'no      2     Casey Loran Joyce
         'no      1     Casey Joyce
         'no      0     Casey                   unsure
         Dim names As String() = fullName.Split(New Char() {" "c})

         ' sets title
         Dim foundTitle As Boolean
         Dim titleRepresentations As New Dictionary(Of String, CourtesyTitle)()
         With titleRepresentations
            .Add("Mrs.", CourtesyTitle.Mrs)
            .Add("Mrs", CourtesyTitle.Mrs)

            .Add("Mr.", CourtesyTitle.Mr)
            .Add("Mr", CourtesyTitle.Mr)

            .Add("Ms.", CourtesyTitle.Ms)
            .Add("Ms", CourtesyTitle.Ms)
            .Add("Miss", CourtesyTitle.Ms)
         End With
         For Each pair As KeyValuePair(Of String, CourtesyTitle) In titleRepresentations
            If fullName.StartsWith(pair.Key) Then
               Me.Title = pair.Value
               foundTitle = True
               Exit For
            End If
         Next


         If foundTitle Then
            Select Case names.Length
               Case Is > 3    ' Mr (Casey ...) Loran Joyce
                  firstName_ = ""
                  ' assumes all names that are not middle or last are apart of first name
                  For i As Integer = 1 To names.Length - 3
                     firstName_ &= " " & names(i)
                  Next
                  ' removes first space on first name
                  firstName_ = firstName_.Remove(0, 1)

                  middleName_ = names(names.Length - 2)
                  lastName_ = names(names.Length - 1)
               Case 3         ' Mr Casey Joyce
                  firstName_ = names(1)
                  middleName_ = ""
                  lastName_ = names(2)
               Case 2
                  firstName_ = ""
                  middleName_ = ""
                  lastName_ = names(1)
               Case 1
                  ' only title
            End Select
         Else
            Select Case names.Length
               Case Is > 2
                  title_ = CourtesyTitle.NotSet
                  ' assumes if there are more than 3 names that they are apart of the first name
                  For i As Integer = 0 To names.Length - 3
                     firstName_ &= " " & names(i)
                  Next
                  ' removes beginning space in first name
                  firstName_ = firstName_.Remove(0, 1)
                  middleName_ = names(names.Length - 2)
                  lastName_ = names(names.Length - 1)
               Case 2
                  title_ = CourtesyTitle.NotSet
                  firstName_ = names(0)
                  middleName_ = ""
                  lastName_ = names(1)
               Case 1
                  title_ = CourtesyTitle.NotSet
                  firstName_ = names(0)
                  middleName_ = ""
                  lastName_ = ""
            End Select
         End If

      End Sub


      ''' <summary>Gets string with title then first then middle then last name;
      ''' each seperated by a space.</summary>
      Private Function getFullName() As String
         Dim fullName As String

         fullName = ""

         ' determines whether a title is set (the default is not set)
         If Me.titleExists Then
            ' adds title
            fullName = Me.Title.ToString & "."
         End If

         ' determines whether there is a first name
         If Me.firstNameExists Then
            If Me.titleExists Then
               ' adds a space between title and first name
               ' waits until here to add space in case there is no first name (or other names)
               fullName &= " "
            End If
            ' adds first name
            fullName &= Me.FirstName
         End If

         ' determines whether there is a middle name
         If Me.middleNameExists Then
            ' determines whether there is a title or first name
            If Me.titleExists OrElse Me.firstNameExists Then
               ' adds space
               fullName &= " "
            End If
            ' adds middle name
            fullName &= Me.MiddleName
         End If

         ' determines whether there is a last name
         If Me.lastNameExists Then
            ' determines whether there is a title, first name, or middle name
            If Me.titleExists OrElse Me.firstNameExists OrElse Me.middleNameExists Then
               ' adds space
               fullName &= " "
            End If
            fullName &= Me.LastName
         End If

         Return fullName
      End Function


      ''' <summary>Gets string with first name then last name seperated by a space.</summary>
      ''' <remarks>Middle name is not included, even if it exists.</remarks>
      Private Function getFirstThenLastName() As String
         Dim fullName As String

         fullName = ""

         ' determines whether first name exists
         If Me.firstNameExists Then
            ' adds first name
            fullName = Me.FirstName
         End If

         ' determines whether last name exists
         If Me.lastNameExists Then
            ' determines whether first name exists
            If Me.firstNameExists Then
               ' adds space between first and last name
               fullName &= " "
            End If
            ' adds last name
            fullName &= Me.LastName
         End If

         Return fullName
      End Function


      ''' <summary>Gets string with last name then first name seperated by a comma and a space.
      ''' </summary>
      ''' <remarks>Middle name is not included, even if it exists.</remarks>
      Private Function getLastThenFirstName() As String
         Dim fullName As String

         fullName = ""

         ' determines whether last name exists
         If Me.lastNameExists Then
            ' adds last name
            fullName &= Me.LastName
         End If

         ' determines whether first name exists
         If Me.firstNameExists Then
            ' determines whether last name exist in order to know whether to add comma and space
            If Me.lastNameExists Then
               ' adds comma and space
               fullName &= ", "
            End If
            ' adds last name
            fullName &= Me.FirstName
         End If

         Return fullName
      End Function


      Private ReadOnly Property firstNameExists() As Boolean
         Get
            If Not Me.FirstName Is Nothing AndAlso Me.FirstName.Length > 0 Then
               Return True
            Else
               Return False
            End If
         End Get
      End Property

      Private ReadOnly Property middleNameExists() As Boolean
         Get
            If Not Me.MiddleName Is Nothing AndAlso Me.MiddleName.Length > 0 Then
               Return True
            Else
               Return False
            End If
         End Get
      End Property

      Private ReadOnly Property lastNameExists() As Boolean
         Get
            If Not Me.LastName Is Nothing AndAlso Me.LastName.Length > 0 Then
               Return True
            Else
               Return False
            End If
         End Get
      End Property

      Private ReadOnly Property titleExists() As Boolean
         Get
            If Me.Title = CourtesyTitle.NotSet Then
               Return False
            Else
               Return True
            End If
         End Get
      End Property

#End Region

   End Class


End Namespace