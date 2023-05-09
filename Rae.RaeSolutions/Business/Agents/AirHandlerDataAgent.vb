Option Strict On
Option Explicit On 


Imports System.Data
Imports ReferenceData = Rae.RaeSolutions.Business.Entities.AirHandlerReferenceData
Imports AirHandlersInterface = Rae.RaeSolutions.DataAccess.AirHandlers
Imports Multipliers = Rae.RaeSolutions.Business.Intelligence.AirHandlerConstants.DatabaseMultipliers


Namespace Rae.RaeSolutions.Business.Agents


   ''' <summary>
   ''' Provides data access to air handler database.
   ''' </summary>
   Public Class AirHandlerDataAgent

      ''' <summary>Retrieves and adjusts man hours required for air handler model.
      ''' </summary>
      Public Shared Function RetrieveHours(ByVal model As String) As ReferenceData.HoursDataTable
         Dim hoursTable As DataTable

         Dim hoursTypedTable As ReferenceData.HoursDataTable

         hoursTypedTable = New ReferenceData.HoursDataTable

         ' retrieves hours table
         hoursTable = AirHandlersInterface.RetrieveHours(model)

         ' copies hours to typed dataset
         hoursTypedTable.ImportRow(hoursTable.Rows(0))

         ' adjusts hours for multiplier to get back to actual hours
         '
         hoursTypedTable(0).FAHoursPerWallPanel /= Multipliers.HOURS
         hoursTypedTable(0).FAHoursPerRoofPanel /= Multipliers.HOURS
         hoursTypedTable(0).FAHoursPerFloorPanel /= Multipliers.HOURS
         hoursTypedTable(0).FAHoursPerDoor /= Multipliers.HOURS
         hoursTypedTable(0).FAHoursPerAirSeal /= Multipliers.HOURS
         hoursTypedTable(0).OtherHoursPerWallPanel /= Multipliers.HOURS
         hoursTypedTable(0).OtherHoursPerRoofPanel /= Multipliers.HOURS
         hoursTypedTable(0).OtherHoursPerFloorPanel /= Multipliers.HOURS
         hoursTypedTable(0).OtherHoursPerDoor /= Multipliers.HOURS
         hoursTypedTable(0).OtherHoursPerAirSeal /= Multipliers.HOURS
         hoursTypedTable(0).OtherHoodHours /= Multipliers.HOURS
         hoursTypedTable(0).FAHoodHours /= Multipliers.HOURS

         Return hoursTypedTable
      End Function


      ''' <summary>Retrieves motor table
      ''' </summary>
      ''' <exception cref="System.IndexOutOfRangeException">Thrown when a motor match is not found
      ''' </exception>
      Public Shared Function RetrieveMotor(ByVal efficiency As String, ByVal enclosure As String, _
      ByVal horsepower As String, ByVal RPM As Integer) As ReferenceData.MotorsDataTable
         Dim motorsTypedTable As ReferenceData.MotorsDataTable
         Dim motorsTable As DataTable

         motorsTypedTable = New ReferenceData.MotorsDataTable

         ' retrieves motor
         motorsTable = AirHandlersInterface.RetrieveMotor(efficiency, enclosure, horsepower, RPM)
         ' imports row into typed table
         motorsTypedTable.ImportRow(motorsTable.Rows(0))

         ' adjusts motor price
         motorsTypedTable(0).ListCost = motorsTypedTable(0).ListCost * Multipliers.BALDOR_MOTOR / Multipliers.MOTOR

         Return motorsTypedTable
      End Function


      ''' <summary>Retrieves motors
      ''' </summary>
      Public Shared Function RetrieveMotors(ByVal efficiency As String, ByVal enclosure As String, _
      ByVal horsepower As String) As ReferenceData.MotorsDataTable
         Dim motorsTypedTable As ReferenceData.MotorsDataTable
         Dim motorsTable As DataTable

         motorsTypedTable = New ReferenceData.MotorsDataTable

         ' retrieves motor
         motorsTable = AirHandlersInterface.RetrieveMotors(efficiency, enclosure, horsepower)

         For i As Integer = 0 To motorsTable.Rows.Count - 1
            ' imports row into typed table
            motorsTypedTable.ImportRow(motorsTable.Rows(i))
            ' adjusts motor price
            motorsTypedTable(i).ListCost = motorsTypedTable(i).ListCost * Multipliers.BALDOR_MOTOR / Multipliers.MOTOR
         Next

         Return motorsTypedTable
      End Function


      ''' <summary>Retrieves housed BIDI fan based on size parameter</summary>
      Public Shared Function RetrieveBidiFan(ByVal size As Double) As ReferenceData.BidiFansDataTable
         Dim fanTable As DataTable
         Dim fanTypedTable As ReferenceData.BidiFansDataTable

         fanTypedTable = New ReferenceData.BidiFansDataTable

         ' retrieves housed BIDI fan
         fanTable = AirHandlersInterface.RetrieveBidiFan(size)
         ' imports row into typed table
         fanTypedTable.ImportRow(fanTable.Rows(0))

         ' adjusts cost based on the database multiplier
         fanTypedTable(0).Cost /= Multipliers.BIDI_FAN

         Return fanTypedTable
      End Function


      ''' <summary>Retrieves housed forward curved fan based on parameter size
      ''' </summary>
      Public Shared Function RetrieveForwardCurvedFan(ByVal size As String) As ReferenceData.ForwardCurvedFansDataTable
         Dim fanTable As DataTable
         Dim fanTypedTable As ReferenceData.ForwardCurvedFansDataTable

         fanTypedTable = New ReferenceData.ForwardCurvedFansDataTable

         ' retrieves housed BIDI fan
         fanTable = AirHandlersInterface.RetrieveForwardCurvedFans(size)

         For i As Integer = 0 To fanTable.Rows.Count - 1
            ' imports row into typed table
            fanTypedTable.ImportRow(fanTable.Rows(i))
            ' adjusts cost based on the database multiplier
            fanTypedTable(i).Cost /= Multipliers.FC_FAN
         Next

         Return fanTypedTable
      End Function


      ''' <summary>Retrieves plenum fan price; includes labor costs.</summary>
      Public Shared Sub RetrievePlenumFanPrice(ByVal fanClass As String, ByVal fanSize As Double, _
      ByRef cost As Double, ByRef laborHours As Integer)

         ' retrieves plenum fan price
         AirHandlersInterface.RetrievePlenumFanPrice(fanClass, fanSize, cost, laborHours)

         ' price in database has a multiplier applied to it adjusts price
         cost /= Multipliers.PLENUM_FAN
      End Sub


      ''' <summary>Retrieves duct heaters</summary>
      Public Shared Function RetrieveDuctHeaters( _
      ByVal volts As Integer, ByVal kw As Double) As ReferenceData.DuctHeatersDataTable
         Dim heaterTable As DataTable
         Dim heaterTypedTable As ReferenceData.DuctHeatersDataTable

         heaterTypedTable = New ReferenceData.DuctHeatersDataTable

         ' retrieves duct heater table
         heaterTable = AirHandlersInterface.RetrieveDuctHeaters(volts, kw)

         If heaterTable.Rows.Count > 0 Then
            ' imports row into typed table
            heaterTypedTable.ImportRow(heaterTable.Rows(0))

            ' adjusts prices by database multiplier
            '
            heaterTypedTable(0).BaseCost /= Multipliers.DUCT_HEATER
            heaterTypedTable(0).DisconnectSwitchCost /= Multipliers.DUCT_HEATER
            heaterTypedTable(0).ExtraStageCost /= Multipliers.DUCT_HEATER
            heaterTypedTable(0).FusingCostMin /= Multipliers.DUCT_HEATER
            heaterTypedTable(0).ScrCost /= Multipliers.DUCT_HEATER
         End If

         Return heaterTypedTable
      End Function


      ''' <summary>Retrieves coil prices</summary>
      Public Shared Function RetrieveCoilPrices(ByVal model As String, ByVal numRows As Integer) As ReferenceData.CoilPricesDataTable
         Dim coilsTable As DataTable
         Dim coilTypedTable As ReferenceData.CoilPricesDataTable

         coilTypedTable = New ReferenceData.CoilPricesDataTable

         ' retrieves coils table
         coilsTable = AirHandlersInterface.RetrieveCoilPrices(model, numRows)
         If coilsTable.Rows.Count > 0 Then
            ' imports row into typed table
            coilTypedTable.ImportRow(coilsTable.Rows(0))
            ' adjusts coil cost; values in database had a multiplier applied to them
            coilTypedTable(0).Cost /= Multipliers.COIL
         End If

         Return coilTypedTable
      End Function


      Public Shared Function RetrieveCoil(ByVal model As String) As ReferenceData.CoilsRow
         Dim coilsTable As DataTable
         Dim coilTypedTable As ReferenceData.CoilsDataTable

         coilTypedTable = New ReferenceData.CoilsDataTable

         ' retrieves coils table
         coilsTable = AirHandlersInterface.RetrieveCoil(model)
         If coilsTable.Rows.Count > 0 Then
            ' imports row into typed table
            coilTypedTable.ImportRow(coilsTable.Rows(0))
         End If

         Return coilTypedTable(0)
      End Function


      ''' <summary>Retrieves filters table</summary>
      Public Shared Function RetrieveFilters() As ReferenceData.FiltersDataTable
         Dim filtersTable As DataTable
         Dim filtersTypedTable As ReferenceData.FiltersDataTable

         filtersTypedTable = New ReferenceData.FiltersDataTable

         ' retrieves filters table
         filtersTable = AirHandlersInterface.RetrieveFilters()

         For i As Integer = 0 To filtersTable.Rows.Count - 1
            ' populates typed table
            filtersTypedTable.ImportRow(filtersTable.Rows(i))
            ' adjusts price for multiplier applied to database table
            filtersTypedTable(i).ListPrice /= Multipliers.FILTER
         Next

         Return filtersTypedTable
      End Function


      ''' <summary>Retrieves damper info</summary>
      Public Shared Function RetrieveDamper(ByVal model As String, _
      ByVal type As String, ByVal metal As String) As ReferenceData.DampersDataTable
         Dim damperTable As DataTable
         Dim damperTypedTable As ReferenceData.DampersDataTable

         damperTypedTable = New ReferenceData.DampersDataTable

         ' retrieves damper
         damperTable = AirHandlersInterface.RetrieveDamper(model, type, metal)

         If damperTable.Rows.Count > 0 Then
            ' imports row into type table
            damperTypedTable.ImportRow(damperTable.Rows(0))
            ' adjusts cost for database multiplier
            damperTypedTable(0).Cost /= Multipliers.DAMPER
         End If

         Return damperTypedTable
      End Function


      ''' <summary>Retrieves all section dimensions</summary>
      Public Shared Function RetrieveDimensions(ByVal airHandlerModel As String) As ReferenceData.SectionDimensionsDataTable
         Dim dimensionsTypedTable As ReferenceData.SectionDimensionsDataTable
         Dim dimensionsTable As DataTable

         dimensionsTypedTable = New ReferenceData.SectionDimensionsDataTable

         ' retrieves section dimensions
         dimensionsTable = AirHandlersInterface.RetrieveSectionDimensions(airHandlerModel)

         ' copies dimensions into typed table
         For i As Integer = 0 To dimensionsTable.Rows.Count - 1
            dimensionsTypedTable.ImportRow(dimensionsTable.Rows(i))
         Next

         Return dimensionsTypedTable
      End Function


      ''' <summary>Retrieves air handlers</summary>
      Public Shared Function RetrieveAirHandlers(ByVal airFlow As Double) As ReferenceData.CoilsDataTable
         Dim airHandlersTable As DataTable
         Dim airHandlersTypedTable As ReferenceData.CoilsDataTable

         airHandlersTypedTable = New ReferenceData.CoilsDataTable

         ' retrieves air handlers
         airHandlersTable = Rae.RaeSolutions.DataAccess.AirHandlers.RetrieveAirHandlers(airFlow)

         For i As Integer = 0 To airHandlersTable.Rows.Count - 1
            ' imports row
            airHandlersTypedTable.ImportRow(airHandlersTable.Rows(i))
         Next

         Return airHandlersTypedTable
      End Function

   End Class

End Namespace
