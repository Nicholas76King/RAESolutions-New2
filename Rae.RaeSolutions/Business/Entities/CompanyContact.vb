Option Strict On
Option Explicit On 


Imports Entities = Rae.RaeSolutions.Business.Entities


Namespace Rae.RaeSolutions.Business.Entities


   ''' <summary>Contact associated with a company.</summary>
   Public Class CompanyContact : Inherits Entities.Contact

      Private _company As Entities.Company


      ''' <summary>Contact's company.</summary>
      Public Property Company() As Entities.Company
         Get
            Return Me._company
         End Get
         Set(ByVal Value As Entities.Company)
            Me._company = Value
         End Set
      End Property


      Public Sub New()
         MyBase.New()
         Me._company = New Company
      End Sub

   End Class

End Namespace