Namespace Rae.RaeSolutions.Business.Entities

   Public Class ProjectPricing


      ' calculated

      Private m_NetPrice As Double
      ''' <summary>
      ''' NetPrice
      ''' </summary>
      Public ReadOnly Property NetPrice() As Double
         Get
            Return Me.m_NetPrice
         End Get
      End Property

      Private m_NetIncome As Double
      ''' <summary>
      ''' NetIncome
      ''' </summary>
      Public ReadOnly Property NetIncome() As Double
         Get
            Return Me.m_NetIncome
         End Get
      End Property

      Private m_TotalFreight As Double
      ''' <summary>
      ''' TotalFreight
      ''' </summary>
      Public ReadOnly Property TotalFreight() As Double
         Get
            Return Me.m_TotalFreight
         End Get
      End Property

      Private m_TotalStartUp As Double
      ''' <summary>
      ''' TotalStartUp
      ''' </summary>
      Public ReadOnly Property TotalStartUp() As Double
         Get
            Return Me.m_TotalStartUp
         End Get
      End Property

      Private m_TotalWarranty As Double
      ''' <summary>
      ''' TotalWarranty
      ''' </summary>
      Public ReadOnly Property TotalWarranty() As Double
         Get
            Return Me.m_TotalWarranty
         End Get
      End Property

      Private m_TotalInvoice As Double
      ''' <summary>
      ''' TotalInvoice
      ''' </summary>
      Public ReadOnly Property TotalInvoice() As Double
         Get
            Return Me.m_TotalInvoice
         End Get
      End Property

      Private m_TotalCommission As Double
      ''' <summary>
      ''' TotalCommission
      ''' </summary>
      Public ReadOnly Property TotalCommission() As Double
         Get
            Return Me.m_TotalCommission
         End Get
      End Property




      ' TODO: Determine tax options
      Private m_TaxStatus As String
      ''' <summary>
      ''' TaxStatus
      ''' </summary>
      Public ReadOnly Property TaxStatus() As String
         Get
            Return Me.m_TaxStatus
         End Get
      End Property
      Private m_TaxEmemptNum As String
      ''' <summary>
      ''' TaxEmemptNum
      ''' </summary>
      Public ReadOnly Property TaxEmemptNum() As String
         Get
            Return Me.m_TaxEmemptNum
         End Get
      End Property

   End Class

End Namespace