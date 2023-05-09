Option Strict Off

Namespace Rae.RaeSolutions.Business.Entities.PriceSheets

Public Class PriceSheetReport
   Inherits CrystalDecisions.CrystalReports.Engine.ReportDocument
   Implements IPriceSheetReport
   
   Sub New(path As String, options As Object, _
           app As String, user As String, version As String)
      Load(path)
      
      SetOptions(options)
      
      SetParameterValue(versionParam, version)
      SetParameterValue(appParam, app)
      SetParameterValue(userParam, user)
   End Sub
   
   
   Overridable Sub SetOptions(options As Object) _
   Implements IPriceSheetReport.SetOptions
      SetDataSource(options(0))
      Subreports(0).SetDataSource(options(1))
   End Sub
   
   ReadOnly Property App As String _
   Implements IPriceSheetReport.App
      Get
         Return param(appParam)
      End Get
   End Property

   ReadOnly Property User As String _
   Implements IPriceSheetReport.User
      Get
         Return param(userParam)
      End Get
   End Property

   ReadOnly Property Version As String _
   Implements IPriceSheetReport.Version
      Get
         Return param(versionParam)
      End Get
   End Property
   
   Private versionParam As String = "VersionOfApplicationCreatedBy"
   Private appParam As String = "NameOfApplicationCreatedBy"
   Private userParam As String = "UserCreatedBy"
   
   Private Function param(name As String) As String
      Return ParameterFields(appParam).CurrentValues(0).ToString
   End Function
   
End Class

End Namespace