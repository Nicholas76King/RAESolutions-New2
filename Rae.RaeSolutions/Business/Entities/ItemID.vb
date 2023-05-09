Imports System
Imports System.String
Imports System.ComponentModel

Namespace Rae.RaeSolutions.Business.Entities

''' <summary>Id that uniquely identifies item.</summary>
''' <remarks>
''' <para>Format: [username]+[password]+[dateGenerated]</para>
''' <para>Example: "MyUsername+MyPassword+20060407092732"</para>
''' <para>
''' Pass constructor username and password to generate a new ID.
''' This is useful for generating a unique ID for new items.
''' </para>
''' <para>
''' Pass constructor an existing ID to parse username, password and date generated.
''' This is useful if loading an existing item.
''' </para>
''' <para>
''' Use <see cref="ItemId.Id"/> to get the full ID. It will contain the user's password as plain text.
''' In situations where exposing the user's password is inappropriate use <see cref="ItemId.SafeId"/>
''' </para>
''' </remarks>
Public Class item_id
   Implements IEquatable(Of item_id)

#Region " Declarations"
   Private ReadOnly seperator As String = "+"
   Private Shared ReadOnly date_format As String = "yyyyMMddHHmmss"

   Private _username, _password As String
   Private _dateGenerated As Date
#End Region


#Region " Properties"

   ''' <summary>Item ID. Format: [username]+[password]+[dateGenerated]</summary>
   ReadOnly Property Id As String
      Get
         Return String.Join(seperator, New String() {_username, _password, Me.dateGeneratedAsString})
      End Get
   End Property

   ReadOnly Property Username As String
      Get
         Return _username
      End Get
   End Property

   ReadOnly Property Password As String
      Get
         Return _password
      End Get
   End Property

   ''' <summary>Date ID was generated</summary>
   ReadOnly Property DateGenerated As Date
      Get
         Return _dateGenerated
      End Get
   End Property

   ''' <summary>
   ''' View of ID that does not expose password/customer number. 
   ''' Format: [username]+[dateGenerated].
   ''' </summary>
   ReadOnly Property SafeId As String
      Get
         Return String.Join(seperator, New String() {_username, Me.dateGeneratedAsString})
      End Get
   End Property

   ''' <summary>
   ''' Date ID was generated formatted as a string. 
   ''' Format: [year][month][day][hour][minutes][seconds] ("yyyyMMddhhmmss").
   ''' </summary>
   Private ReadOnly Property dateGeneratedAsString() As String
      Get
         Return Me._dateGenerated.ToString(date_format)
      End Get
   End Property

#End Region


#Region " Public methods"

   ''' <summary>Parameterless constructor for serialization purposes only... DO NOT USE</summary>
   <EditorBrowsable(EditorBrowsableState.Never)> _
   Sub New()
   End Sub

   ''' <summary>Generates new item ID</summary>
        Sub New(ByVal username As String, ByVal password As String)

            ' method still recieves password, but now a unintelligible string of letters is used instead
            '            _password = password


            _password = username
            _password = _password.ToUpper
            _password = _password.Replace("A", "P").Replace("E", "1").Replace("I", "5").Replace("O", "T").Replace("U", "N").Replace(" ", "X")
            _password = "WE" & _password & "R7Y" & "ABCDEFGH"
            _password = _password.Substring(0, 10)


            _username = username
            _dateGenerated = Date.Now()
        End Sub

   ''' <summary>Copies an existing ID. Constructs item ID by parsing the existing ID.</summary>
   ''' <param name="id">Item ID as string</param>
   ''' <exception cref="System.ArgumentNullException">
   ''' Thrown when id parameter is null.
   ''' </exception>
   Sub New(id As String)
      If IsNullOrEmpty(id) Then
         Throw New ArgumentNullException("Item ID cannot be parsed. It is null or empty.")
      End If

      ' parses properties from item ID
      Me.parse(id)
   End Sub


   ''' <summary>Item ID</summary>
   Overrides Function ToString() As String
      Return Me.Id
   End Function


   ''' <summary>Indicates whether item IDs are equal</summary>
   ''' <param name="other">The other item id to compare equality with</param>
   Overloads Function Equals(other As item_id) As Boolean _
   Implements System.IEquatable(Of item_id).Equals
      If other Is Nothing Then Return False

      Return ( ToString = other.ToString )
   End Function


   ''' <summary>
   ''' Compares dates using <see cref="dateFormat"/>. 
   ''' Ignores milliseconds. (There is no formatting support for milliseconds).
   ''' </summary>
   Shared Function DatesAreEqual(date1 As Date, date2 As Date) As Boolean
      Return ( date1.ToString(date_format) = date2.ToString(date_format) )
   End Function

#End Region


   ''' <summary>Parses item ID</summary>
   ''' <param name="id">Item ID with this format: [username]+[password]+[dateGenerated]</param>
   ''' <exception cref="System.ArgumentException">
   ''' Thrown when id parameter's format is invalid.
   ''' </exception>
   Private Sub parse(id As String)
      Dim idValues() As String

      ' delimits values from ID
      idValues = id.Split(Me.seperator.ToCharArray(), System.StringSplitOptions.None)

      ' checks id's format
      If idValues.Length <> 3 Then
                'Throw New ArgumentException("Item ID cannot be parsed. Its format is invalid.")
            End If

      ' sets properties to parsed values
      _username = idValues(0)
      _password = idValues(1)
      _dateGenerated = Date.ParseExact(idValues(2), date_format, Nothing)
   End Sub

End Class

End Namespace