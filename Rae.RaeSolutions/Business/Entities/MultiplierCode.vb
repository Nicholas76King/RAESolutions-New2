Imports Rae.Security.Cryptography
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Namespace Rae.RaeSolutions.Business.Entities

''' <summary>
''' Multiplier code contains a multiplier and commission along 
''' with assignment details.
''' </summary>
Public Class MultiplierCode
   Implements IEquatable(Of MultiplierCode)

   ''' <summary>
   ''' Initializes a multiplier code from an assigned multiplier code.
   ''' Interprets details from code.
   ''' </summary>
   ''' <param name="code">
   ''' Assigned multiplier code
   ''' </param>
   Sub New(code As String)
      Me._code = code
      decrypt(code)
   End Sub
   
   ''' <summary>
   ''' Initializes a new multiplier code to be assigned.   
   ''' </summary>
   Sub New( _
   assignedBy As String, assignedTo As String, assignedOn As Date, _
   multiplier As Double, commission As Double)
      assign(assignedBy, assignedTo, assignedOn, multiplier, commission)
      generateCode()
   End Sub
   
#Region " Properties"

   ''' <summary>
   ''' Username of person who assigned this multiplier code.
   ''' </summary>
   ReadOnly Property AssignedBy() As String
      Get
         Return _assignedBy
      End Get
   End Property
   

   ''' <summary>
   ''' Username of person who was assigned this multiplier code.
   ''' </summary>
   ReadOnly Property AssignedTo() As String
      Get
         Return _assignedTo
      End Get
   End Property
   

   ''' <summary>
   ''' Date multiplier code was assigned
   ''' </summary>
   ReadOnly Property AssignedOn() As Date
      Get
         Return _assignedOn
      End Get
   End Property
   

   ''' <summary>
   ''' Multiplier
   ''' </summary>
   ReadOnly Property Multiplier() As Double
      Get
         Return _multiplier
      End Get
   End Property
   

   ''' <summary>
   ''' Commission
   ''' </summary>
   ReadOnly Property Commission() As Double
      Get
         Return _commission
      End Get
   End Property
   
   
   ''' <summary>
   ''' Multiplier code
   ''' </summary>
   ReadOnly Property Code As String
   	Get
   		Return _code
   	End Get
   End Property
   
#End Region
   
   ''' <summary>
   ''' Checks if multiplier code is expired.
   ''' Multiplier must be applied on the same date it is assigned.   
   ''' </summary>
   Function IsExpired(appliedOn As Date) As Boolean
      Dim expired As Boolean
      
            If DateDiff(DateInterval.Day, AssignedOn.Date, appliedOn.Date) < 7 Then
                expired = False
            Else
                expired = True
            End If
      
      Return expired
   End Function
   
   
   ''' <summary>
   ''' Gets decrypted code
   ''' </summary>
   Overrides Function ToString() As String
      Return _code
   End Function
   
   
   ''' <summary>
   ''' Compares multiplier codes; true if they're equal
   ''' </summary>
   Function Equals(other As MultiplierCode) As Boolean _
   Implements IEquatable(Of MultiplierCode).Equals
      Dim areEqual As Boolean
      
      If other Is Nothing Then
         areEqual = False
      ElseIf _code = other._code Then
         areEqual = True
      Else
         areEqual = False
      End If
      
      Return areEqual
   End Function
   
   
#Region " Internal"  
   
   Protected _code As String
   Protected _assignedBy As String
   Protected _assignedTo As String
   Protected _assignedOn As Date
   Protected _multiplier As Double
   Protected _commission As Double
   
   Private Sub assign( _
   assignedBy As String, assignedTo As String, assignedOn As Date, _
   multiplier As Double, commission As Double)
      _assignedBy = assignedBy
      _assignedTo = assignedTo
      _assignedOn = assignedOn
      _multiplier = multiplier
      _commission = commission
   End Sub
   
   
   Private Sub decrypt(encryptedValue As String)
      Dim delimitedValues As String = Cryptographer.Decrypt(encryptedValue)
      Dim values() As String = delimitedValues.Split(New Char() {","c})
      
      _assignedBy = values(0)
      _assignedTo = values(1)
      _assignedOn = Date.Parse(values(2))
      _multiplier = CDbl(values(3))
      _commission = CDbl(values(4))
   End Sub
   
   
   ''' <summary>
   ''' Generates a code based on values passed into constructor.
   ''' </summary>
   Protected Function generateCode() As String
      Dim codeValues As New Rae.Collections.StringList()

      With codeValues
         .Add(AssignedBy)
         .Add(AssignedTo)
         ' not including time to reduce code length
         .Add(AssignedOn.ToString("M/d/yyyy"))
         ' remove zero to reduce code length a little
         .Add(Multiplier.ToString.Replace("0.", "."))
         .Add(Commission.ToString.Replace("0.", "."))
      End With
      
      _code = Cryptographer.Encrypt(codeValues.Delimit(","))

      Return _code
   End Function

#End Region

   
End Class

End Namespace