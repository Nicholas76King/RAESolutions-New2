Namespace rae.solutions

Public Interface IFluid
   ''' <summary>Max glycol percentage</summary>
   ReadOnly Property Max As Double
   ''' <summary>Min glycol percentage</summary>
   ReadOnly Property Min As Double
   ''' <summary>Point at which fluid freezes in degrees Fahrenheit</summary>
   ReadOnly Property FreezePoint As Double
   ''' <summary>Min recommended suction temperature in degrees Fahrenheit</summary>
   ReadOnly Property MinSuctionTemp As Double
   ''' <summary>True if fluid percentage is in range. Recommend to pass percentage into constructor</summary>
   Function PercentageInRange() As Boolean
End Interface

End Namespace