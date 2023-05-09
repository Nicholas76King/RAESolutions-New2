Option Strict On
Option Explicit On 

Imports Rae.RaeSolutions.Business.Intelligence.AirHandlerConstants.Multipliers
Imports Rae.RaeSolutions.Business.Intelligence.AirHandlerConstants.Costs
Imports Rae.RaeSolutions.Business.Intelligence.AirHandlerConstants.Weights
Imports Rae.RaeSolutions.Business.Intelligence.AirHandlerConstants


Namespace Rae.RaeSolutions.Business.Entities


   ''' <summary>Supplies information about painting such as cost, weight and hours of labor
   ''' </summary>
   ''' <remarks>
   ''' One gallon of paint covers 200ft^2. 
   ''' Each gallon takes one hour to apply; this was specified by Jay Kindle.
   ''' </remarks>
   Public Class Painter


#Region " Constants"

      Private AREA_PAINTED_PER_GALLON As Double = 200
      Private NUM_HOURS_TO_PAINT_GALLON As Double = 1
      Private COST_OF_PAINT_PER_GALLON As Double = PAINT_COST_PER_GALLON
      Private WEIGHT_OF_PAINT_PER_GALLON As Double = PAINT_WEIGHT_PER_GALLON
      Private HOURLY_WAGES As Double = HOURLY_WAGE

#End Region


#Region " Declarations"

      Private _area As Double
      Private _hoursToPaint As Double
      Private _weight As Double
      Private _totalCost As Double
      Private _gallons As Double
      Private _costOfPaint As Double
      Private _costOfLabor As Double
      Private _scrapPercentage As Double
      Private _includeScrap As Boolean

#End Region


#Region " Properties"


      ''' <summary>Area to paint in square feet</summary>
      Public Property Area() As Double
         Get
            Return Me._area
         End Get
         Set(ByVal Value As Double)
            Me._area = Value
         End Set
      End Property

      ''' <summary>Percentage of area to paint to increase area by in order to account for scrap</summary>
      Public Property ScrapPercentage() As Double
         Get
            Return Me._scrapPercentage
         End Get
         Set(ByVal Value As Double)
            Me._scrapPercentage = Value
         End Set
      End Property

      ''' <summary>Determines whether scrap percentage is factored into total cost</summary>
      Public Property IncludeScrap() As Boolean
         Get
            Return Me._includeScrap
         End Get
         Set(ByVal Value As Boolean)
            Me._includeScrap = Value
         End Set
      End Property

      ''' <summary>Number of hours required to paint the area</summary>
      Public ReadOnly Property HoursToPaint() As Double
         Get
            Return Me._hoursToPaint
         End Get
      End Property

      ''' <summary>The weight of the paint required to paint the area</summary>
      Public ReadOnly Property Weight() As Double
         Get
            Return Me._weight
         End Get
      End Property

      ''' <summary>The total cost to paint the area</summary>
      Public ReadOnly Property TotalCost() As Double
         Get
            Return Me._totalCost
         End Get
      End Property

      ''' <summary>Number of gallons required to paint area</summary>
      Public ReadOnly Property Gallons() As Double
         Get
            Return Me._gallons
         End Get
      End Property

      ''' <summary>Cost of the paint required to paint the area</summary>
      Public ReadOnly Property CostOfPaint() As Double
         Get
            Return Me._costOfPaint
         End Get
      End Property

      ''' <summary>Cost of the labor required to paint the area</summary>
      Public ReadOnly Property CostOfLabor() As Double
         Get
            Return Me._costOfLabor
         End Get
      End Property


#End Region


#Region " Public methods"


      ''' <summary>Constructs painter object and calculates and sets properties.
      ''' </summary>
      Public Sub New(ByVal areaToPaint As Double)
         ' initializes painter
         Me.Initialize()

         Me._area = areaToPaint
         ' calculates cost and sets properties
         Me.CalculateCost()
      End Sub


      ''' <summary>Calculates cost to paint area and sets properties
      ''' </summary>
      ''' <returns>Cost to paint area including materials and labor
      ''' </returns>
      Public Overloads Function CalculateCost() As Double
         Dim totalArea As Double

         ' determines whether to add scrap to area to paint
         If Me._includeScrap Then
            ' includes scrap costs in area to paint
            totalArea = Me._area * (1 + Me._scrapPercentage)
         Else
            totalArea = Me._area
         End If

         ' calculates how many gallons of paint are necessary to paint the area
         Me._gallons = Me.CalculateGallons(totalArea)

         ' rounds up number of gallons of paint required
         Me._gallons = System.Math.Ceiling(Me._gallons)

         ' calculates total cost of paint
         Me._costOfPaint = Me._gallons * Me.COST_OF_PAINT_PER_GALLON
         ' calculates total weight of paint
         Me._weight = Me._gallons * Me.WEIGHT_OF_PAINT_PER_GALLON

         ' calculates number of hours required to paint area ( 1 hr / 1 gallon )
         Me._hoursToPaint = CalculateHoursToPaint(Me._gallons) 'paintHrs = paintGallons * 1
         ' calculates cost of labor to paint area
         Me._costOfLabor = Me._hoursToPaint * Me.HOURLY_WAGES

         ' total cost to paint area
         Me._totalCost = Me._costOfLabor + Me._costOfPaint

         Return Me._totalCost
      End Function


      ''' <summary>Calculates cost to paint area specified; also sets properties</summary>
      Public Overloads Function CalculateCost(ByVal areaToPaint As Double) As Double
         Me._area = areaToPaint
         Me.CalculateCost()
      End Function

#End Region


#Region " Private methods"

      Private Sub Initialize()
         ' sets scrap percentage default
         Me._scrapPercentage = SCRAP
         ' sets include scrap default
         Me._includeScrap = True
      End Sub

      ''' <summary>Calculates number of hours required to use number of gallons specified
      ''' </summary>
      Private Function CalculateHoursToPaint(ByVal gallons As Double) As Double
         Dim paintHours As Double

         ' calculates number of hours required to paint area ( 1 hr / 1 gallon )
         paintHours = gallons * Me.NUM_HOURS_TO_PAINT_GALLON

         Return paintHours
      End Function


      ''' <summary>Calculates number of gallons required to paint area
      ''' </summary>
      ''' <param name="area">Area to paint in feet squared
      ''' </param>
      ''' <returns>Number of gallons required to paint area
      ''' </returns>
      Private Function CalculateGallons(ByVal area As Double) As Double
         ' calculates how many gallons of paint are necessary to paint the area
         Return area / Me.AREA_PAINTED_PER_GALLON
      End Function

#End Region

   End Class

End Namespace
