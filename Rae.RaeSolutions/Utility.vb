Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Reflection
Imports System.Xml
Imports System.IO

Namespace Rae.RaeSolutions


   Public Class Utility



#Region "DB Syncing"
      Public Shared Function SyncToLive() As Boolean
         'logic to coordinate saving projects/items from local back to server
         Return False
      End Function

      Public Shared Function TableInfo() As DataSet
         Dim dsTables As New DataSet
         Dim conn As New System.Data.SqlClient.SqlConnection(GetAppSetting("live"))
         Dim cmd As New System.Data.SqlClient.SqlCommand("select * from information_schema.tables order by TABLE_NAME asc;select c.* , columnproperty(object_id(c.TABLE_NAME),c.COLUMN_NAME,'IsIdentity') as IsIdentity from information_schema.columns c", conn)
         Dim da As New System.Data.SqlClient.SqlDataAdapter(cmd)
         da.Fill(dsTables)
         dsTables.Tables(0).TableName = "TABLES"
         dsTables.Tables(1).TableName = "COLUMNS"
         dsTables.Relations.Add(New DataRelation("TableColumns", dsTables.Tables(0).Columns("TABLE_NAME"), dsTables.Tables(1).Columns("TABLE_NAME")))
         Return dsTables
      End Function

      Public Shared Function DumpToLocal() As Boolean
         'logic to dump all tables and selected projects/items to local db
         Dim success As Boolean = True
         Dim dsTableInfo As DataSet = TableInfo()
         ClearLocal(dsTableInfo)
         Dim cnLive As New SqlClient.SqlConnection(GetAppSetting("live"))
         Dim cnLocal As New SqlClient.SqlConnection(GetAppSetting("local"))
         cnLive.Open()
         cnLocal.Open()
         For Each dr As DataRow In dsTableInfo.Tables("TABLES").Rows
            If Not BulkCopy(dr, cnLive, cnLocal) Then
               success = False
               Exit For
            End If
         Next
         If cnLive.State <> ConnectionState.Closed Then
            cnLive.Close()
         End If
         If cnLocal.State <> ConnectionState.Closed Then
            cnLocal.Close()
         End If
         Return success
      End Function

      Public Shared Function SettingsReader() As System.Configuration.AppSettingsReader
         Return New System.Configuration.AppSettingsReader()
      End Function

      Public Shared Function GetAppSetting(ByVal key As String) As String
         Return SettingsReader.GetValue(key, Type.GetType("System.String")).ToString()
      End Function

      Public Shared Function SetAppSetting(ByVal key As String, ByVal value As Object) As Boolean
         Try
            Dim dir As New System.IO.DirectoryInfo(My.Application.Info.DirectoryPath)
            Dim targetdir As System.IO.DirectoryInfo
            If Not dir.Exists Then
               Exit Function
            End If
            Dim fName As String = "app.config"
            If dir.FullName.ToLower.IndexOf("bin") = -1 Then
               fName = "RAESolutions.exe.config"
               targetdir = dir
            Else
               targetdir = dir.Parent
            End If
            'If DataAccess.Common.AppFolderPath.IndexOf("debug") = -1 Then
            '   fName = "RAESolutions.exe.config"
            'End If

            Dim strFile As String = targetdir.FullName & "\" & fName 'GetAppSetting("dir") & "\" & fName ' "C:\Program Files\Rae Corp\RAE2Setup\RAE2.UI.exe.config" 'My.Application.CommandLineArgs.Item(0) & "\RAE2.UI.exe.config"
            Dim xml As New System.Xml.XmlDocument
            xml.Load(strFile)
            Dim nodeList As Xml.XmlNodeList = xml.GetElementsByTagName("appSettings")
            Dim appSettings As Xml.XmlElement = CType(nodeList(0), Xml.XmlElement)
            For Each node As Xml.XmlNode In appSettings.ChildNodes
               If node.Name = "add" Then
                  Dim isElement As Boolean = False
                  For Each a As Xml.XmlAttribute In node.Attributes
                     If a.Name = "key" And a.Value = key Then
                        isElement = True
                        Exit For
                     End If
                  Next
                  If isElement Then
                     For Each a As Xml.XmlAttribute In node.Attributes
                        If a.Name = "value" Then
                           a.Value = value.ToString()
                           Exit For
                        End If
                     Next
                     Exit For
                  End If
               End If
            Next
            xml.Save(strFile)
         Catch
            Return False
         End Try
         Return True
      End Function

      Public Shared Sub ClearLocal(ByVal ds As DataSet)
         Dim conn As New SqlClient.SqlConnection(GetAppSetting("local"))
         Dim sql As String = String.Empty
         For Each dr As DataRow In ds.Tables("TABLES").Rows
            sql += "Delete from [" & dr("TABLE_NAME").ToString() & "];"
         Next
         Dim cmd As New SqlClient.SqlCommand(sql, conn)
         conn.Open()
         cmd.ExecuteNonQuery()
         If conn.State <> ConnectionState.Closed Then
            conn.Close()
         End If
      End Sub

      Public Shared Function BulkCopy(ByRef drTable As DataRow, ByRef cnLive As SqlClient.SqlConnection, ByRef cnLocal As SqlClient.SqlConnection) As Boolean
         Dim tbl As String = drTable("TABLE_NAME").ToString()
         Dim hasIdentity As Boolean = False
         Dim drsColumns As DataRow() = drTable.GetChildRows("TableColumns")
         For Each dr As DataRow In drsColumns
            If CInt(dr("IsIdentity").ToString) = 1 Then
               hasIdentity = True
            End If
         Next
         Try
            Dim cmd As New SqlClient.SqlCommand("select * from [" & tbl & "]", cnLive)
            Dim ds As New DataSet
            Dim da As New SqlClient.SqlDataAdapter(cmd)
            da.Fill(ds)

            Dim cmdlocal As New SqlClient.SqlCommand("set IDENTITY_INSERT " & tbl & " ON", cnLocal)
            If hasIdentity Then
               cmdlocal.ExecuteNonQuery()
            End If

            For Each dr As DataRow In ds.Tables(0).Rows
               Dim cols As String = String.Empty
               Dim vals As String = String.Empty
               Dim i As Integer = 0
               For Each col As DataColumn In ds.Tables(0).Columns
                  If i > 0 Then
                     cols += ", "
                     vals += ", "
                  End If
                  cols += col.ColumnName
                  If dr(col.ColumnName) Is System.DBNull.Value Then
                     vals += "null"
                  Else
                     vals += FormatDataType(col, dr(col.ColumnName))
                  End If
                  i += 1
               Next
               Dim sql As String = "insert into [" & tbl & "] (" & cols & ") values (" & vals & ")"
               Dim cmdInsert As New SqlClient.SqlCommand(sql, cnLocal)
               If cnLocal.State <> ConnectionState.Open Then
                  cnLocal.Open()
               End If
               cmdInsert.ExecuteNonQuery()
            Next

            If hasIdentity Then
               cmdlocal = New SqlClient.SqlCommand("set IDENTITY_INSERT " & tbl & " OFF", cnLocal)
               If cnLocal.State <> ConnectionState.Open Then
                  cnLocal.Open()
               End If
               cmdlocal.ExecuteNonQuery()
            End If
            Return True
         Catch ex As Exception
            Return False
         End Try
      End Function

#End Region

      Public Shared Function FormatDataType(ByVal col As DataColumn, ByVal value As Object) As String
         Dim str As String = String.Empty
         If IsDBNull(value) Then
            str = "NULL"
         Else
            Select Case col.DataType.Name
               Case "Int32", "Int64", "Int16", "Integer", "Decimal", "Double"
                  str = value.ToString
               Case "String"
                  str = "'" & value.ToString & "'"
               Case "DateTime"
                  str = "'" & CDate(value).ToShortDateString() & " " & CDate(value).ToShortTimeString() & "'"
               Case "Boolean"
                  If CBool(value) Then
                     str = "1"
                  Else
                     str = "0"
                  End If
            End Select
         End If
         Return str
      End Function

      Public Shared Function ConvertDB(ByVal t As Type, ByVal s As String) As Object
         Select Case t.Name
            Case "Int16", "Int32", "Integer"
               Return CInt(s)
            Case "Int64"
               Return CLng(s)
            Case "Double"
               Return CDbl(s)
            Case "Single"
               Return CSng(s)
            Case "DateTime", "Date"
               Return CDate(s)
            Case "Boolean"
               Dim b As Boolean = CBool(s)
               If b Then
                  Return 1
               Else
                  Return 0
               End If
            Case Else
               Return s
         End Select
      End Function

      Public Shared Function Serialize(ByVal obj As Object) As String
         Dim xs As New Xml.Serialization.XmlSerializer(obj.GetType())
         Dim ms As New MemoryStream(8096)
         xs.Serialize(ms, obj)
         Dim xml As New XmlDocument()
         ms.Seek(0, System.IO.SeekOrigin.Begin)
         xml.Load(ms)
         Return xml.OuterXml '.DocumentElement.InnerXml '.OuterXml 'xml.OuterXml
      End Function

      Public Shared Function Deserialize(ByVal str As String, ByVal t As Type) As Object
         Try
            Dim xs As New Xml.Serialization.XmlSerializer(t)
            Dim doc As New XmlDocument
            doc.LoadXml(str)
            Dim ms As New MemoryStream(8096)
            doc.Save(ms)
            ms.Seek(0, System.IO.SeekOrigin.Begin)
            Return xs.Deserialize(ms)
         Catch ex As Exception
            Return Nothing
         End Try
      End Function

      Public Shared Function BuildDataRow(ByVal obj As Object) As DataRow
         Dim dtb As New DataTable
         For Each prop As PropertyInfo In obj.GetType().GetProperties()
            If prop.PropertyType.Namespace = "System" AndAlso prop.CanWrite Then
               dtb.Columns.Add(New DataColumn(prop.Name, prop.PropertyType))
            End If
         Next
         Return dtb.NewRow
      End Function

      Public Shared Function SelectFrom(ByVal props As PropertyInfo(), ByVal params As List(Of PropertyInfo), ByVal obj As Object, ByVal dtl As Object, ByVal path As String) As DataTable
         Dim conn As IDbConnection = DataAccess.Common.CreateConnection(path)
         Dim cmd As IDbCommand = conn.CreateCommand
         Dim strSelect As String = String.Empty
         Dim f As FieldInfo
         For Each p As PropertyInfo In props
            If strSelect.Length > 0 Then
               strSelect += ", "
            End If
            f = dtl.GetType().GetField(p.Name)
            strSelect += "[" & f.GetValue(dtl).ToString() & "] as " & f.Name
         Next
         strSelect = "Select " & strSelect
         f = dtl.GetType().GetField("TableName")
         Dim strFrom As String = "from [" & DataAccess.Common.CommonTableName(path, f.GetValue(dtl).ToString()) & "]"
         Dim strWhere As String = String.Empty
         For Each p As PropertyInfo In params
            If strWhere.Length > 0 Then
               strWhere += " and "
            End If
            f = dtl.GetType().GetField(p.Name)
            Dim paramname As String = "@" & f.Name
            Dim param As IDbDataParameter = cmd.CreateParameter() 'DataAccess.Common.CreateParameter(paramname, p.GetValue(obj, Nothing))
            param.ParameterName = paramname
            param.Value = p.GetValue(obj, Nothing)
            strWhere += "[" & f.GetValue(dtl).ToString() & "] = " & paramname
            cmd.Parameters.Add(param)
         Next
         If strWhere.Length > 0 Then
            strWhere = "where " & strWhere
         End If
         Dim sql As String = strSelect & " " & strFrom & " " & strWhere
         cmd.CommandText = sql
         Dim da As IDbDataAdapter = DataAccess.Common.CreateAdapter(cmd)
         Dim ds As New DataSet
         da.Fill(ds)
         Return ds.Tables(0)
      End Function

      Public Shared Function NullSafe(ByVal arg As Object, ByVal t As Type) As Object
         '//returns a usuable value for a piimitive object if the value in the db was null
         If Not arg Is DBNull.Value Then
            Return arg
         End If
         If t.Name = "Int32" Then
            Return -1
         ElseIf t.Name = "String" Then
            Return String.Empty
         ElseIf t.Name = "DateTime" Then
            Return New DateTime()
         ElseIf t.Name = "Date" Then
            Return New Date()
         ElseIf t.Name = "Boolean" Then
            Return False
         ElseIf t.Name = "Double" Then
            Return -1
         End If
         Return Nothing
      End Function

      Public Shared Function Enum2DataTable(ByVal e As [Enum]) As DataTable
         Dim dtb As New DataTable
         dtb.Columns.Add("Key")
         dtb.Columns.Add("Value")
         For Each str As String In System.Enum.GetNames(e.GetType)
            Dim r As DataRow = dtb.NewRow
            r("Key") = str
            r("Value") = CInt(System.Enum.Parse(e.GetType, str))
            dtb.Rows.Add(r)
         Next
         Return dtb
      End Function

      Public Shared Function Hash2DataTable(ByVal h As Hashtable) As DataTable
         Dim dtb As New DataTable
         dtb.Columns.Add("Key")
         dtb.Columns.Add("Value")
         For Each k As Object In h.Keys
            Dim r As DataRow = dtb.NewRow
            r("Key") = k.ToString()
            r("Value") = h.Item(k)
            dtb.Rows.Add(r)
         Next
         Return dtb
      End Function

      Public Shared Function GetFromHash(ByVal obj As Object, ByVal hash As Hashtable, Optional ByVal GetKey As Boolean = False) As Object
         Dim o As Object = Nothing
         If GetKey Then 'gets key for item (obj) provided
            For Each k As Object In hash.Keys
               If hash.Item(k).Equals(obj) Then
                  o = k
                  Exit For
               End If
            Next
         Else 'gets item for key (obj) provided
            o = hash.Item(obj)
         End If
         Return o
      End Function
   End Class
End Namespace
