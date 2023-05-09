Namespace rae.solutions

Class Water : Implements IFluid

   ReadOnly Property FreezePoint As Double _
   Implements IFluid.FreezePoint
      Get
         Return 32
      End Get
   End Property

   ReadOnly Property MinSuctionTemp As Double _
   Implements IFluid.MinSuctionTemp
      Get
         Return 33
      End Get
   End Property

   ReadOnly Property Min As Double _
   Implements IFluid.Min
      Get
         Return 0
      End Get
   End Property

   ReadOnly Property Max As Double _
   Implements IFluid.Max
      Get
         Return 100
      End Get
   End Property
   
   ''' <summary>Water doesn't contain glycol percentage so it's always in range</summary>
   Function IsInRange() As Boolean _
   Implements IFluid.PercentageInRange
      Return True
   End Function
   
End Class

End Namespace