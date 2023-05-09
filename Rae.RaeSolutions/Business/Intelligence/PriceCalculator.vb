Option Strict On
Option Explicit On 


Namespace Rae.RaeSolutions.Business.Intelligence

   ' base list price
   ' num units          total base list price
   ' options price      total list price
   ' par multiplier     PAR price
   ' commission rate    commission

   ' warranty
   ' freight
   ' startup
   ' other              NFSP
   ''' <summary>Contains methods to calculate prices</summary>
   Public Class PriceCalculator


      ''' <summary>Calculates the total list price. Price includes all units (if multiple units) and options
      ''' </summary>
      ''' <remarks>Total options price per unit must be multiplied by number of units to get the total options price
      ''' equation: (base list price + options price) x number of units
      ''' </remarks>
      Public Shared Function CalculateTotalListPrice( _
      ByVal baseListPrice As Double, ByVal optionsPrice As Double, ByVal numUnits As Integer) As Double
         Return (baseListPrice + optionsPrice) * numUnits
      End Function


      ''' <summary>Calculates total base list price. Price includes units but not options.</summary>
      ''' <param name="baseListPrice">Base list price for a single unit.</param>
      ''' <param name="numUnits">Number of units</param>
      Public Shared Function CalculateTotalBaseListPrice( _
      ByVal baseListPrice As Double, ByVal numUnits As Integer) As Double
         Return baseListPrice * numUnits
      End Function


      ''' <summary>Calculates PAR price. equ. total list price * PAR multiplier</summary>
      ''' <param name="totalListPrice">Total list price. Includes all units (if multiple units) and options</param>
      ''' <param name="parMultiplier">PAR multiplier</param>
      Public Shared Function CalculateParPrice(ByVal totalListPrice As Double, ByVal parMultiplier As Double) As Double
         Return (totalListPrice * parMultiplier)
      End Function


      ''' <summary>Calculates commission. Equ. commission rate * PAR price</summary>
      ''' <param name="commissionRate">Rate of commission</param>
      ''' <param name="parPrice">PAR price</param>
      Public Shared Function CalculateCommissionPrice(ByVal commissionRate As Double, ByVal parPrice As Double) As Double
         Return (commissionRate * parPrice)
      End Function


      ''' <summary>Calculates NFSP. Equ. Other + PAR</summary>
      ''' <param name="parPrice">PAR price</param>
      ''' <param name="otherTotalPrice">Price of warranty, freight, start up, and other costs</param>
      Public Shared Function CalculateNfspPrice( _
      ByVal parPrice As Double, ByVal otherTotalPrice As Double) As Double
         Return otherTotalPrice + parPrice
      End Function


      ''' <summary>
      ''' Calculates total price of other costs such as warranty, freight, and startup
      ''' </summary>
      Public Shared Function CalculateTotalOtherPrice(ByVal warranty As Double, ByVal freight As Double, _
      ByVal startUp As Double, ByVal other As Double) As Double
         Return warranty + freight + startUp + other
      End Function


   End Class


End Namespace