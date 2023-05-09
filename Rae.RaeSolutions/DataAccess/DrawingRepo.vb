Option Strict Off

Imports System.Collections.Generic
Imports System.Data.ConnectionState
Imports Rae.solutions.drawings
Imports RT = Rae.RaeSolutions.DataAccess.Tables.RulesTable
Imports LT = Rae.RaeSolutions.DataAccess.Tables.LayersTable
Imports PT = Rae.RaeSolutions.DataAccess.Tables.PropertiesTable
Imports TT = Rae.RaeSolutions.DataAccess.Tables.TextInputs

Namespace Rae.RaeSolutions.DataAccess

   Namespace Tables

      Public Class PropertiesTable
         Public Const TableName As String = "GlobalInputNames"
         Public Const DrawingType As String = "DrawingType"
         Public Const DrawingProperty As String = "InfoRequired"
      End Class

      Public Class TextInputs
         Public Const TableName As String = "TextInputs"
         Public Const TextInput As String = "TextInput"
         Public Const TextHandle As String = "TextHandle"
      End Class

      Public Class LayersTable
         Public Const TableName As String = "UnitDrawings_LayerNames"
         Public Const LayerName As String = "LayerName"
         Public Const Description As String = "Description"
         Public Const AlwaysOn As String = "AlwaysOn"
      End Class

      Public Class RulesTable
         Public Const TableName As String = "UnitDrawings_LayerRules"
         Public Const LayerName As String = "LayerName"
         Public Const LayerState As String = "LayerState"
         Public Const Qualifier As String = "Qualifier"
         Public Const [Operator] As String = "Operator"
         Public Const Value As String = "Value"
         Public Const Position As String = "Position"
         Public Const Conjunction As String = "Conjunction"
      End Class

   End Namespace

   Public Class DrawingRepo

      Sub New(ByVal connection As SharedConnectionFactory)
         Me.connection = connection
      End Sub

        Function GetRulesFor(ByVal layer As String) As List(Of Rule)
            '   If layer.ToUpper.StartsWith("XG") Then




            Dim con = connection.Create()
            Dim com = con.CreateCommand()
            Dim sql = str("SELECT * FROM {0} WHERE [{1}]='{2}' ORDER BY [{3}]", _
                          RT.TableName, RT.LayerName, layer, RT.Position)
            com.CommandText = sql
            Dim rdr As System.Data.IDataReader
            Dim rules = New List(Of Rule)
            Dim rule As Rule

            Try
                If con.State <> Open Then con.Open()
                rdr = com.ExecuteReader()
                While rdr.Read
                    rule = New Rule()
                    With rule
                        .Layer = rdr(RT.LayerName).ToString
                        .State = rdr(RT.LayerState)
                        .Qualifier = rdr(RT.Qualifier)
                        .Operator = rdr(RT.Operator)
                        .Value = rdr(RT.Value)
                        .Position = rdr(RT.Position)
                        .Conjunction = rdr(RT.Conjunction)
                    End With
                    rules.Add(rule)
                End While
            Finally
                If rdr IsNot Nothing Then _
                   rdr.Close()
            End Try

            Return rules
        End Function

      Function GetLayers(ByVal layersInDrawing() As String) As List(Of String)
         Dim layers = New List(Of String)
         Dim con = connection.Create()
         Dim sql = str("SELECT [{0}] FROM {1}", _
                       LT.LayerName, LT.TableName)


         sql &= " where " & LT.LayerName & " in ("

         For Each l As String In layersInDrawing
            sql &= "'" & l.Replace("'", "''") & "',"
         Next

         sql = sql.Substring(0, sql.Length - 1)

            sql &= ")"

         Dim com = con.CreateCommand()
         com.CommandText = sql
         Dim rdr As System.Data.IDataReader
         Try
            If con.State <> Open Then con.Open()
            rdr = com.ExecuteReader()
            While rdr.Read()
               layers.Add(rdr(LT.LayerName))
            End While
         Finally
            If rdr IsNot Nothing Then _
               rdr.Close()
         End Try

         Return layers
      End Function

      Function GetProps(ByVal type As DrawingType) As List(Of DrawingProperty)
         Dim con = connection.Create()
         Dim sql = str("SELECT * FROM {0} WHERE [{1}]='{2}' OR [{1}]='{3}'", _
                       PT.TableName, PT.DrawingType, "_ALL", type)
         Dim com = con.CreateCommand()
         com.CommandText = sql
         Dim rdr As System.Data.IDataReader
         Dim prop As DrawingProperty
         Dim props = New List(Of DrawingProperty)
         Try
            If con.State <> Open Then con.Open()
            rdr = com.ExecuteReader()
            While rdr.Read()
               prop.Name = rdr(PT.DrawingProperty)
               prop.DrawingType = rdr(PT.DrawingType)
               props.Add(prop)
            End While
         Finally
            If rdr IsNot Nothing Then rdr.Close()
         End Try

         Return props
      End Function

      Sub DeleteText()
         Dim con = connection.Create()
         Dim com = con.CreateCommand()

         If con.State <> Open Then con.Open()

         com.CommandText = "DELETE FROM TextInputs"
         com.ExecuteNonQuery()
      End Sub

      Sub InsertText(ByVal text() As LayerManipulator.HandleList)
         Dim con = connection.Create()
         Dim com = con.CreateCommand()

         Dim sql, label, handle As String



         For Each text1 As LayerManipulator.HandleList In text
            label = text1.text
            handle = text1.handle

            sql = str("INSERT INTO {0} VALUES ('{1}', '{2}')", TT.TableName, label, handle)

            com.CommandText = sql
            com.ExecuteNonQuery()

         Next



         '   For i = 0 To text.GetUpperBound(0)
         '      If text(i, 0) Is Nothing Then Exit For
         '      If text(i, 0).ToString Like "i_*" Then
         '         label = text(i, 0).ToString.Replace("i_", "")
         '         handle = text(i, 1).ToString
         '         sql = str("INSERT INTO {0} VALUES ('{1}', '{2}')", _
         '               TT.TableName, label, handle)

         '         com.CommandText = sql
         '         com.ExecuteNonQuery()
         '      End If
         '   Next
      End Sub


      Private connection As SharedConnectionFactory

      Private Function str(ByVal format As String, ByVal ParamArray values() As String) As String
         Return New System.Text.StringBuilder().AppendFormat(format, values).ToString
      End Function

      'Function GetTextHandle(prop As DrawingProperty, drawing As String) As Boolean
      '   Dim con = connection.Create()
      '   Dim com = con.CreateCommand()
      '   com.CommandText = str("SELECT {0} FROM {1} WHERE {2}='{3}'", _
      '                         TT.TextHandle, TT.TableName, TT.TextInput, prop.Name)
      '   Dim rdr As System.Data.IDataReader
      '   Try
      '      If con.State <> Open Then con.Open()
      '      rdr = com.ExecuteReader()
      '      If rdr.Read
      '         'If UpdateDrawingText(drawing, rdr(TT.TextHandle), prop.Name) = False Then
      '         '   GetTextHandle = False
      '         'End If
      '      End If
      '   Finally
      '      If rdr IsNot Nothing Then rdr.Close()
      '   End Try
      'End Function

      'Function setDrawingText(model As String, drawingFilePath As String, type As DrawingType) As Boolean
      '   setTextHandles(drawingFilePath)

      '   setDrawingText = True

      '   Dim props = GetProps(type)

      '   For Each prop In props
      '      SetText(prop)
      '   Next

      'End Function

      ''' <summary>Check text qualification criteria</summary>
      'Protected Function UpdateDrawingText( _
      'pDrawingName As String, pHandle As String, pLinkField As String) As Boolean
      '   UpdateDrawingText = False

      '   Dim udtMyConn = drawingConnection.Create
      '   Dim udtMyCommand = udtMyConn.CreateCommand()
      '   Dim udtMyReader As IDataReader
      '   If udtMyConn.State <> ConnectionState.Open Then udtMyConn.Open()

      '   Dim TmpConjuncture As String = "OR"
      '   Dim TmpValue As String = " "

      '   ' Text value is linked directly to a field value...
      '   If pLinkField <> "_NA" And Trim(pLinkField) > "" Then
      '      UpdateText(GetInputValue(pLinkField), pHandle)
      '   Else
      '      ' See if any qualification criteria exist - if
      '      ' so let's see if the criteria is satisfied by
      '      ' the current parameters...
      '      Dim cmdQualifiers As IDbCommand = udtMyConn.CreateCommand 'New OleDbCommand
      '      Dim rdQualifiers As IDataReader
      '      'cmdQualifiers.Connection = udtMyConn
      '      cmdQualifiers.CommandText = "SELECT * FROM [TextRules] " & _
      '                                   "WHERE [DrawingName] = '" & pDrawingName & "' " & _
      '                                     "AND [Handle] = '" & pHandle & "' " & _
      '                                "ORDER BY [Position]"
      '      rdQualifiers = cmdQualifiers.ExecuteReader
      '      Dim CriteriaSatisfied As Boolean = True
      '      While rdQualifiers.Read

      '         If CriteriaSatisfied = False Then

      '            ' If criteria is NOT satisfied then we will
      '            ' look until we find an OR oconjuncture for
      '            ' Conjunction - if Conjunction is AND then
      '            ' we can skip because we have already determined
      '            ' this series of criteriais not satisfied.
      '            ' If Conjunction is END the we can exit 
      '            ' reader...
      '            If TmpConjuncture = "OR" Then

      '               ' Set TmpValue variable...
      '               TmpValue = rdQualifiers("InputValue")

      '               ' This is a new set of criteria so we can
      '               ' continue and reset CriteriaSatisfied...
      '               CriteriaSatisfied = True

      '               If rdQualifiers("Qualifier") <> "_ALL" Then

      '                  Try
      '                     udtMyCommand.CommandText = "SELECT [" & Replace(rdQualifiers("Qualifier"), "'", "") & "] from InputData "
      '                     udtMyReader = udtMyCommand.ExecuteReader
      '                     If udtMyReader.Read() Then
      '                        CriteriaSatisfied = isQualified(GetInputValue(rdQualifiers("Qualifier")), rdQualifiers("Value"), rdQualifiers("Operator"))
      '                     End If
      '                     udtMyReader.Close()

      '                  Catch tmpexception As DataException
      '                     ' Reference field does not exist (set
      '                     ' criteria satisfied as follows)...
      '                     If rdQualifiers("Value") = "False" And rdQualifiers("Operator") = "=" Then
      '                        CriteriaSatisfied = True
      '                     ElseIf rdQualifiers("Value") = "True" And rdQualifiers("Operator") = "<>" Then
      '                        CriteriaSatisfied = True
      '                     Else
      '                        CriteriaSatisfied = False
      '                     End If

      '                  End Try

      '               End If

      '            ElseIf TmpConjuncture = "END" Then
      '               ' This is the last criteria so we can exit....
      '               Exit While
      '            End If

      '            ' Set Conjucture...
      '            TmpConjuncture = rdQualifiers("Conjunction")

      '         Else

      '            ' Criteria is currently satisfied.  If this
      '            ' is Position #1 then we need to see if it
      '            ' meets the qualification criteria. If so,
      '            ' we need to check the conjucture in the
      '            ' Conjunction field - if it is AND then
      '            ' we'll need to check the next Position rule
      '            ' as well and continue until we find an
      '            ' OR or END Conjunction or until the criteria
      '            ' is not met in which case we'll search for
      '            ' an OR criteria above...
      '            If Val(rdQualifiers("Position")) = 1 Or TmpConjuncture = "AND" Then

      '               ' Set TmpValue variable...
      '               TmpValue = rdQualifiers("InputValue")

      '               If rdQualifiers("Qualifier") = "_ALL" Then
      '                  CriteriaSatisfied = True
      '               Else

      '                  Try
      '                     udtMyCommand.CommandText = "SELECT [" & Replace(rdQualifiers("Qualifier"), "'", "") & "] from InputData "
      '                     udtMyReader = udtMyCommand.ExecuteReader
      '                     If udtMyReader.Read() Then
      '                        CriteriaSatisfied = isQualified(GetInputValue(rdQualifiers("Qualifier")), rdQualifiers("Value"), rdQualifiers("Operator"))
      '                     End If
      '                     udtMyReader.Close()

      '                  Catch tmpexception As DataException
      '                     ' Reference field does not exist (set
      '                     ' criteria satisfied as follows)...
      '                     If rdQualifiers("Value") = "False" And rdQualifiers("Operator") = "=" Then
      '                        CriteriaSatisfied = True
      '                     ElseIf rdQualifiers("Value") = "True" And rdQualifiers("Operator") = "<>" Then
      '                        CriteriaSatisfied = True
      '                     Else
      '                        CriteriaSatisfied = False
      '                     End If

      '                  End Try

      '               End If

      '            ElseIf TmpConjuncture = "END" Or TmpConjuncture = "OR" Then
      '               ' Qualification criteria is met so there is no
      '               ' need to continue to the next set of criteria.
      '               ' Or this is the end criteria and we can exit.
      '               Exit While
      '            End If

      '            ' Set conjucture...
      '            TmpConjuncture = rdQualifiers("Conjunction")

      '         End If

      '      End While

      '      If CriteriaSatisfied = True Then
      '         ' Value meets criteria - go ahead & set...
      '         UpdateText(TmpValue, pHandle)
      '      End If

      '      rdQualifiers.Close()
      '      udtMyConn.Close()

      '   End If

      'End Function

   End Class

End Namespace

Namespace rae.solutions.drawings

   Public Class Rule
      Public Position As Integer
      Public Layer As String
      Public State As String
      Public Qualifier As String
      Public [Operator] As String
      Public Value As String
      Public Conjunction As String
   End Class

   Public Structure DrawingProperty
      Public Name As String
      Public DrawingType As String
   End Structure

End Namespace