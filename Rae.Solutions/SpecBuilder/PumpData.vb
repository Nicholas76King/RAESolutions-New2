Public Class PumpData

   '17 properties
#Region " Declarations"
   Private _pumpPackage As Boolean
   Private _designCriteria As String
   Private _designCriteriaDualOption As String
   Private _packageDesign As String
   Private _speed As String
   Private _pumpType As String
   Private _airSeperator As Boolean
   Private _airSeperatorDesign As String
   Private _expansionTank As Boolean
   Private _expansionTankType As String
   Private _suctionStrainer As String
   Private _suctionTrim As String
   Private _storageTank As Boolean
   Private _storageTankType As String
   Private _storageTankVolume As Single
   Private _storageTankRatingASM As String
   Private _storageTankRatingPsi As String

#End Region


#Region " Properties"

   Public Property PumpPackage() As Boolean
      Get
         Return Me._pumpPackage
      End Get
      Set(ByVal Value As Boolean)
         Me._pumpPackage = Value
      End Set
   End Property

   Public Property DesignCriteria() As String
      Get
         Return Me._designCriteria
      End Get
      Set(ByVal Value As String)
         Me._designCriteria = Value
      End Set
   End Property

   Public Property DesignCriteriaDualOption() As String
      Get
         Return Me._designCriteriaDualOption
      End Get
      Set(ByVal Value As String)
         Me._designCriteriaDualOption = Value
      End Set
   End Property

   Public Property PackageDesign() As String
      Get
         Return Me._packageDesign
      End Get
      Set(ByVal Value As String)
         Me._packageDesign = Value
      End Set
   End Property

   Public Property Speed() As String
      Get
         Return Me._speed
      End Get
      Set(ByVal Value As String)
         Me._speed = Value
      End Set
   End Property

   Public Property PumpType() As String
      Get
         Return Me._pumpType
      End Get
      Set(ByVal Value As String)
         Me._pumpType = Value
      End Set
   End Property

   Public Property AirSeperator() As Boolean
      Get
         Return Me._airSeperator
      End Get
      Set(ByVal Value As Boolean)
         Me._airSeperator = Value
      End Set
   End Property

   Public Property AirSeperatorDesign() As String
      Get
         Return Me._airSeperatorDesign
      End Get
      Set(ByVal Value As String)
         Me._airSeperatorDesign = Value
      End Set
   End Property

   Public Property ExpansionTank() As Boolean
      Get
         Return Me._expansionTank
      End Get
      Set(ByVal Value As Boolean)
         Me._expansionTank = Value
      End Set
   End Property

   Public Property ExpansionTankType() As String
      Get
         Return Me._expansionTankType
      End Get
      Set(ByVal Value As String)
         Me._expansionTankType = Value
      End Set
   End Property

   Public Property SuctionStrainer() As String
      Get
         Return Me._suctionStrainer
      End Get
      Set(ByVal Value As String)
         Me._suctionStrainer = Value
      End Set
   End Property

   Public Property SuctionTrim() As String
      Get
         Return Me._suctionTrim
      End Get
      Set(ByVal Value As String)
         Me._suctionTrim = Value
      End Set
   End Property

   Public Property StorageTank() As Boolean
      Get
         Return Me._storageTank
      End Get
      Set(ByVal Value As Boolean)
         Me._storageTank = Value
      End Set
   End Property

   Public Property StorageTankType() As String
      Get
         Return Me._storageTankType
      End Get
      Set(ByVal Value As String)
         Me._storageTankType = Value
      End Set
   End Property

   Public Property StorageTankVolume() As Single
      Get
         Return Me._storageTankVolume
      End Get
      Set(ByVal Value As Single)
         Me._storageTankVolume = Value
      End Set
   End Property

   Public Property StorageTankRatingAsm() As String
      Get
         Return Me._storageTankRatingASM
      End Get
      Set(ByVal Value As String)
         Me._storageTankRatingASM = Value
      End Set
   End Property

   Public Property StorageTankRatingPsi() As String
      Get
         Return Me._storageTankRatingPsi
      End Get
      Set(ByVal Value As String)
         Me._storageTankRatingPsi = Value
      End Set
   End Property

#End Region


   Public Sub New()

   End Sub

End Class
