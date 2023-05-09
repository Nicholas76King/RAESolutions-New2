Imports System.Collections
Imports System.Data
Imports Rae.RaeSolutions.DataAccess

Namespace Rae.RaeSolutions.Business.Entities
   Public Class TipOfTheDay

      Private dr As DataRow

      Public Sub New()
         Me.dr = Utility.BuildDataRow(Me)
      End Sub

      Public Sub New(ByVal _dr As System.Data.DataRow)
         Me.dr = _dr
      End Sub

      Public Property TipID() As Integer
         Get
            Return CInt(Utility.NullSafe(dr("TipID"), Type.GetType("System.Int32")))
         End Get
         Set(ByVal value As Integer)
            dr("TipID") = value
         End Set
      End Property

      Public Property DateShown() As DateTime
         Get
            Return CDate(Utility.NullSafe(dr("DateShown"), Type.GetType("System.DateTime")))
         End Get
         Set(ByVal value As DateTime)
            dr("DateShown") = value
         End Set
      End Property

      Public Property Subject() As String
         Get
            Return CStr(Utility.NullSafe(dr("Subject"), Type.GetType("System.String")))
         End Get
         Set(ByVal value As String)
            dr("Subject") = value
         End Set
      End Property

      Public Property Detail() As String
         Get
            Return CStr(Utility.NullSafe(dr("Detail"), Type.GetType("System.String")))
         End Get
         Set(ByVal value As String)
            dr("Detail") = value
         End Set
      End Property

      Public Shared Function Populate() As Generic.List(Of TipOfTheDay)
         Dim coll As New Generic.List(Of TipOfTheDay)
         Dim dtb As DataTable = TipOfTheDayDataAccess.RetrieveTipOfTheDay
         For Each row As DataRow In dtb.Rows
            Dim tip As New TipOfTheDay(row)
            coll.Add(tip)
         Next
         Return coll
      End Function

      Public Shared Function PopulateNext() As TipOfTheDay
         Dim dtb As DataTable = TipOfTheDayDataAccess.RetrieveTipOfTheDay
         Dim row As DataRow = dtb.Rows(0)
         Dim tip As New TipOfTheDay(row)
         Return tip
      End Function

      Public Shared Function PopulatePrevious() As TipOfTheDay
         Dim dtb As DataTable = TipOfTheDayDataAccess.RetrieveTipOfTheDay
         Dim row As DataRow = dtb.Rows(dtb.Rows.Count - 1)
         Dim tip As New TipOfTheDay(row)
         Return tip
      End Function

      Public Sub UpdateDateShown()
         TipOfTheDayDataAccess.UpdateDateShown(Me.TipID)
      End Sub
   End Class
End Namespace