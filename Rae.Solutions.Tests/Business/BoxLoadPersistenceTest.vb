Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert
Imports Rae.RaeSolutions
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.Persistence

<TestClass()> _
Public Class BoxLoadPersistenceTest

Shared b As BoxLoad

<TestMethod(), Ignore> _
Sub BoxLoad_Save()
   Dim username As String = "CASEYJ"
   Dim password As String = "pass"
   Dim projectName As String = "Foopie"
   Dim item_id As New item_id(username, password)
   
   Dim project_manager As New project_manager(projectName, username, password)
   b = New BoxLoad(item_id, project_manager)
   b.Save()
   
   IsTrue(b.DbId > 0)
   Dim expected As New Revision(0, 0)
   IsTrue(b.Revisions.Current = expected)
   IsTrue(b.Revisions.Last = expected)
   IsTrue(b.Revisions.First = expected)
End Sub

<TestMethod(), Ignore> _
Sub BoxLoad_SaveAsRevision()
   b.SaveAsRevision()
   
   Dim current As New Revision(0, 1)
   Dim first As New Revision(0, 0)
   IsTrue(b.Revisions.Current = current)
   IsTrue(b.Revisions.Last = current)
   IsTrue(b.Revisions.First = first)
End Sub

End Class
