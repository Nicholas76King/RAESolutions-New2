Namespace Rae.RaeSolutions.Business.Entities.PriceSheets

Friend MustInherit Class PriceViewer
   Implements IPriceViewer

   Sub New(user As String, app As String, version As String, _
           by As FilterBy, criteria As String)
      _user = user
      _app = app
      _version = version
      _by = by
      _criteria = criteria
      '_report = Locations.Create().SearchForFile("PriceSheetReport.rpt", "Reports")
      repository = New PriceSheetRepository()
   End Sub

   ReadOnly Property Report As String _
   Implements IPriceViewer.Report
      Get
         Return _report
      End Get
   End Property

   ReadOnly Property App As String _
   Implements IPriceViewer.App
      Get
         Return _app
      End Get
   End Property

   ReadOnly Property By As FilterBy _
   Implements IPriceViewer.By
      Get
         Return _by
      End Get
   End Property

   ReadOnly Property Criteria As String _
   Implements IPriceViewer.Criteria
      Get
         Return _criteria
      End Get
   End Property

   ReadOnly Property User As String _
   Implements IPriceViewer.User
      Get
         Return _user
      End Get
   End Property

   ReadOnly Property Version As String _
   Implements IPriceViewer.Version
      Get
         Return _version
      End Get
   End Property


   MustOverride Sub Prepare() _
   Implements IPriceViewer.Prepare

   MustOverride Sub View() _
   Implements IPriceViewer.View


   Protected _user, _app, _version, _criteria, _report As String
   Protected _by As FilterBy
   Protected repository As IPriceSheetRepository

End Class

End Namespace