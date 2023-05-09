Option Strict Off

Imports Rae.RaeSolutions.Business.Entities
Imports System.Data
Imports System.Text

Namespace Rae.Data.Access

''' <summary>Legacy pricing data access</summary>
Public Class LegacyPricing
   
   Sub New(legacyConnectionFactory As IConnectionFactory)
      legacyConnFactory = legacyConnectionFactory
   End Sub
   
   
        Function Find(ByVal op As EquipmentOption) As EquipmentOption

            If op Is Nothing Then Return Nothing

            Dim legacyOp = selectOpFromLegacyDb(op)
            Return legacyOp
        End Function
   
   
   ' selects option from legacy pricing database
   Private Function selectOpFromLegacyDb(legacyOp As EquipmentOption) As EquipmentOption
      Dim con = legacyConnFactory.Create
      Dim com = con.CreateCommand
      Dim sql = New StringBuilder().AppendFormat( _
         "SELECT * FROM {0} INNER JOIN {1} ON {0}.{2}={1}.{3} WHERE {0}.{4}={5}", _
         "EquipmentOptions", "MasterOptions", "MasterId", "Id", "Id", legacyOp.PricingId).ToString
      com.CommandText = sql
      Dim rdr As IDataReader
      
      Dim op As EquipmentOption
      
      Try
         con.Open
         rdr = com.ExecuteReader
         While rdr.Read
            op = New EquipmentOption
            op.Category = rdr("Category")
            op.Code = rdr("Code")
            op.Description = rdr("Description")
            op.Per = rdr("Per")
            op.Price = rdr("Price")
            op.Quantity = rdr("Quantity")
            op.Voltage = rdr("Voltage")
            
            op.Quantity = legacyOp.Quantity
            op.Id = legacyOp.Id
            op.PricingId = legacyOp.PricingId
         End While
      Finally
         If rdr IsNot Nothing Then _
            rdr.Close
         If con.State <> ConnectionState.Closed Then _
            con.Close
      End Try
      
      Return op
   End Function
   
   
   Private legacyConnFactory As IConnectionFactory
   
End Class

End Namespace