Option Strict On
Option Explicit On

Namespace Rae.RaeSolutions.Business.Entities

   ''' <summary>
   ''' Calculates coil price.
   ''' </summary>
   Public Class CoilPricingWrapper

      Public Enum CoilType
         Water
         DirectExpansion
         Steam
         SteamDistribution
         'Condenser not an option in catalog
      End Enum

      Public Enum FinMaterial
         Aluminum
         Copper
      End Enum


      Private price_ As Double
      ''' <summary>
      ''' Coil cost.
      ''' </summary>
      Public ReadOnly Property Price() As Double
         Get
            Return Me.price_
         End Get
      End Property

      Public Sub New(ByVal coil As Coil, Optional ByVal numcoils As Integer = 1)
         Dim coilprice As New RAEDLL_Coil_Pricing.Cls_Pricing()
         coilprice.RAE_Pricing_Version = 20090211
         ' activates dll and parses dates of price changes
         coilprice.RAE_Activation = "qdc4cTUdmdynl6YQ1583"
         'coil.AddToDatabasefillCBO()
         'Dim dates As String = coil.RAE_Out_CBO
         'dates = dates.Replace(" ", "")
         'Dim datesArray() As String = dates.Split(",".ToCharArray)

         coilprice.RAE_CoilType = coil.CoilUseType.ToString

         'If isCasingStainlessSteel Then
         'coil.RAE_CASING_SS = "Y"
         ' Else
         coilprice.RAE_CASING_SS = "N"
         'End If

         coilprice.RAE_TUBE_SIZE = CDbl(Utility.GetFromHash(coil.Diameter, coil.Diameters(coil.CoilMode, coil.CoilUseType)))
         coilprice.RAE_FL = coil.FinLength
         coilprice.RAE_FH = coil.FinHeight
         coilprice.RAE_RD = coil.NumRows
         coilprice.RAE_Tube_Thickness = coil.TubeThickness
         coilprice.RAE_FPI = coil.FPI
         coilprice.RAE_fin_Thickness = coil.FinThickness

         coilprice.RAE_fin_Material = coil.FinMaterial.ToString()

         coilprice.RAE_How_Many_Coils = numcoils



         ' sets defaults
         '
         'coil.RAE_Pricing_Version = datesArray(datesArray.Length - 1)
         coilprice.RAE_Extra_Distributors = "N"
         coilprice.RAE_connections_steel = "N"
         coilprice.RAE_connections_brass = "N"
         coilprice.RAE_acrycoat_3 = "N"
         coilprice.RAE_Electrofin = "N"
         coilprice.RAE_Baffled_headers = "N"
         coilprice.RAE_intermediate_drain_header = "N"
         coilprice.RAE_Print_from_DLL = "N"

         coilprice.RAE_STEEL_CONN_QTY = 0
         coilprice.RAE_intermediate_drain_header_qty = 0
         coilprice.RAE_expedited_delivery = 15
         coilprice.RAE_Extra_Distributors_Qty = 0
         ' length of brass connection
         coilprice.RAE_S1 = 6   ' per Danny G

         coilprice.RAE_CIRCUIT_TYPE = "F"
         coilprice.RAE_Rep_Multiplier = 0.43 ' per Danny Groom
         coilprice.AddToDatabase()

         ' TODO: seperate into sell price and
         Me.price_ = (coilprice.RAE_Out_total_Pricing / 0.43) ' * 0.290648 ' per Danny Groom
      End Sub



      Public Sub New( _
      ByVal type As CoilType, _
      ByVal isCasingStainlessSteel As Boolean, _
      ByVal finLength As Double, _
      ByVal finHeight As Double, _
      ByVal numRows As Integer, _
      ByVal tubeThickness As Double, _
      ByVal finsPerInch As Integer, _
      ByVal finThickness As Double, _
      ByVal finMaterial As FinMaterial, _
      ByVal numCoils As Integer)
         Dim coil As New RAEDLL_Coil_Pricing.Cls_Pricing()
         coil.RAE_Pricing_Version = 20061004
         ' activates dll and parses dates of price changes
         coil.RAE_Activation = "qdc4cTUdmdynl6YQ1583"
         'coil.AddToDatabasefillCBO()
         'Dim dates As String = coil.RAE_Out_CBO
         'dates = dates.Replace(" ", "")
         'Dim datesArray() As String = dates.Split(",".ToCharArray)

         coil.RAE_CoilType = Me.formatCoilType(type)

         If isCasingStainlessSteel Then
            coil.RAE_CASING_SS = "Y"
         Else
            coil.RAE_CASING_SS = "N"
         End If

         coil.RAE_TUBE_SIZE = Me.getTubeSize(type)
         coil.RAE_FL = finLength
         coil.RAE_FH = finHeight
         coil.RAE_RD = numRows
         coil.RAE_Tube_Thickness = tubeThickness
         coil.RAE_FPI = finsPerInch
         coil.RAE_fin_Thickness = finThickness

         If finMaterial = CoilPricingWrapper.FinMaterial.Aluminum Then
            coil.RAE_fin_Material = "AL"
         ElseIf finMaterial = CoilPricingWrapper.FinMaterial.Copper Then
            coil.RAE_fin_Material = "CU"
         Else
            Throw New System.ApplicationException()
         End If

         coil.RAE_How_Many_Coils = numCoils



         ' sets defaults
         '
         'coil.RAE_Pricing_Version = datesArray(datesArray.Length - 1)
         coil.RAE_Extra_Distributors = "N"
         coil.RAE_connections_steel = "N"
         coil.RAE_connections_brass = "N"
         coil.RAE_acrycoat_3 = "N"
         coil.RAE_Electrofin = "N"
         coil.RAE_Baffled_headers = "N"
         coil.RAE_intermediate_drain_header = "N"
         coil.RAE_Print_from_DLL = "N"

         coil.RAE_STEEL_CONN_QTY = 0
         coil.RAE_intermediate_drain_header_qty = 0
         coil.RAE_expedited_delivery = 15
         coil.RAE_Extra_Distributors_Qty = 0
         ' length of brass connection
         coil.RAE_S1 = 6   ' per Danny G

         coil.RAE_CIRCUIT_TYPE = "F"
         coil.RAE_Rep_Multiplier = 0.43 ' per Danny Groom
         coil.AddToDatabase()

         ' TODO: seperate into sell price and
         Me.price_ = (coil.RAE_Out_total_Pricing / 0.43) * 0.290648 ' per Danny Groom
      End Sub


#Region " Private methods"

      Private Function getTubeSize(ByVal type As CoilType) As Double
         Dim tubeSize As Double
         Select Case type
            Case CoilType.DirectExpansion, CoilType.Steam, CoilType.Water
               tubeSize = 58
            Case CoilType.SteamDistribution
               tubeSize = 11
            Case Else
               Throw New ApplicationException("Tube size cannot be determined based on coil type: " & type.ToString() & ".")
         End Select
         Return tubeSize
      End Function


      Private Function formatCoilType(ByVal type As CoilType) As String
         Dim sType As String
         Select Case type
            Case CoilType.DirectExpansion
               sType = "D"
            Case CoilType.Water
               sType = "W"
            Case CoilType.Steam
               sType = "S"
            Case CoilType.SteamDistribution
               sType = "SD"
            Case Else
               Throw New ApplicationException("Coil type cannot be formatted: " & type.ToString() & ".")
         End Select
         Return sType
      End Function

#End Region

   End Class

End Namespace