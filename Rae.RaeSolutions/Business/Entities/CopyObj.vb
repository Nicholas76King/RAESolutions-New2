Option Strict Off
Imports System.Reflection
Imports Rae.Reflection
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Data

Namespace Rae.RaeSolutions.Business.Entities
   Public Class CopyObj


      Public Enum SerializeType
         ToXMLFile
         ToDataTable
         ToString
      End Enum

      Public Shared Sub CopyObj(ByVal objType As System.Type, _
                                ByVal CurrentObj As Object, _
                                ByRef NewObj As Object)

         Dim Props() As PropertyInfo = _
         objType.GetProperties(BindingFlags.Public Or _
         BindingFlags.Instance)
         For Each PropItem As PropertyInfo In Props
            If PropItem.CanWrite Then
               PropItem.SetValue(NewObj, _
                                 PropItem.GetValue(CurrentObj, Nothing), _
                                 Nothing)
            End If
         Next

      End Sub

      Public Shared Function CloneObj(ByVal objType As System.Type, _
                                ByVal CurrentObj As Object) As Object
         Dim types(0) As System.Type
         types(0) = GetType(item_id)

         Dim NewObj As Object = ConstructorInvoker.InvokeConstructor(CurrentObj, types, New Object() {CType(CurrentObj, ProcessItem).id})
         Dim Props() As PropertyInfo = _
         objType.GetProperties(BindingFlags.Public Or _
         BindingFlags.Instance)
         For Each PropItem As PropertyInfo In Props
            If PropItem.CanWrite Then
               Console.WriteLine()
               Console.Write(PropItem.Name)
               PropItem.SetValue(NewObj, _
                                 PropItem.GetValue(CurrentObj, Nothing), _
                                 BindingFlags.CreateInstance, _
                                 Nothing, _
                                 Nothing, _
                                 Nothing)
            End If
         Next

         Return NewObj

      End Function

      Public Shared Function SerializeObj(ByVal CurrentObj As Object) As String

         Rae.RaeSolutions.Utility.Serialize(CurrentObj)

         'Dim types(0) As System.Type
         'types(0) = GetType(ItemId)

         'Dim r As DataRow
         'Dim objTable As DataTable
         'objTable = New DataTable("ObjectTable")

         'Dim propName As DataColumn = New DataColumn("propName")
         'propName.DataType = System.Type.GetType("System.String")
         'objTable.Columns.Add(propName)

         'Dim propValue As DataColumn = New DataColumn("propValue")
         'propValue.DataType = System.Type.GetType("System.Object")
         'objTable.Columns.Add(propValue)

         'Dim Props() As PropertyInfo = _
         'objType.GetProperties(BindingFlags.Public Or _
         'BindingFlags.Instance)
         'For Each PropItem As PropertyInfo In Props
         '    If PropItem.CanWrite Then
         '        Try
         '            r = objTable.NewRow()
         '            r.Item("propName") = PropItem.Name
         '            r.Item("propValue") = PropItem.GetValue(CurrentObj, Nothing)
         '            objTable.Rows.Add(r)
         '        Catch
         '        End Try
         '    End If
         'Next

         'Select Case SerializeTo
         '    Case SerializeType.ToDataTable
         '        Return objTable
         '    Case SerializeType.ToXMLFile
         '        If Trim(XMLPath) < " " Then
         '            XMLPath = My.Application.Info.DirectoryPath & "\objxml.xml"
         '        End If
         '        Try
         '            objTable.WriteXml(My.Application.Info.DirectoryPath & "\objxml.xml")
         '            Return XMLPath
         '        Catch ex As Exception
         '            Return ""
         '        End Try
         '    Case Else
         '        Return ""
         'End Select

         Return Nothing

      End Function

      Public Shared Function CompareObj(ByVal objType As System.Type, _
                                ByVal Obj1 As Object, _
                                ByVal Obj2 As Object) As Boolean

         ' initialize to true
         CompareObj = True

         Dim PropObj1 As Object
         Dim PropObj2 As Object
         Dim Props() As PropertyInfo = _
         objType.GetProperties(BindingFlags.Public Or _
         BindingFlags.Instance)
         For Each PropItem As PropertyInfo In Props
            If PropItem.CanRead Then
               PropObj1 = PropItem.GetValue(Obj1, Nothing)
               PropObj2 = PropItem.GetValue(Obj2, Nothing)
               If PropObj1 IsNot Nothing Then

                  ' PropObj1 is something

                  ' If PropObj2 is also something then
                  ' we need to compare values to see if
                  ' they match.  If PropObj2 is nothing
                  ' then we need to return false because
                  ' it does not match PropObj1
                  If PropObj2 IsNot Nothing Then
                     If Not PropObj1.Equals(PropObj2) Then
                        Return False
                     End If

                  Else
                     Return False
                  End If

               Else

                  ' PropObj1 is nothing

                  ' If PropObj2 is not nothing then
                  ' we must return false because it
                  ' does not match PFrom	Subject	Received	Size	
                  If PropObj2 IsNot Nothing Then
                     Return False
                  End If

               End If

            End If
         Next

         Return CompareObj

      End Function

   End Class
End Namespace
