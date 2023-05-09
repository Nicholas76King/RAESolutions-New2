Namespace Rae.RaeSolutions.Business.Entities

   Public Class Modification
      Private m_id As Integer
      Private m_by As String
      Private m_date As Date
      Private m_technicalDescription As String
      Private m_userComment As String
      Private m_from As Integer
      Private m_to As Integer

      ' ChangeNotice (see change notice program
      'ChangeNum           #CN - Change Number
      'ChangedBy           Enum (Mfg Eng, Sales Eng, Customer, Sales, QC, Production
      'ChangedFrom         change from description
      'ChangedTo           change to description
      'PriceChanged        boolean
      'Acknowledgement     boolean
      'ChangeType          Enum (Equipment, ShipTo, Coil)
      'ChargedTo           Enum (ReworkAccount, PRNumber)
      'RequiresApprovalBy()

      ' ChangeNoticeManager
      'ChangeNum
      'ApprovedBy
      'Status
      'Comments


      ' Activity: Modification, View, Removal


   End Class
End Namespace