Option Strict Off
Option Explicit On

Imports System.Data
Imports System.Convert
Imports Rae.Io.Text
Imports Console = System.Console
Imports CNull = Rae.ConvertNull
Imports DA1 = RAE.RAESolutions.DataAccess
Imports BE1 = RAE.RAESolutions.Business.Entities

Namespace Rae.RaeSolutions.Business.Entities

Public Class ChillerInfo

   Sub New(model as string)
      Me.model = model
      getChillerInfo()
   End Sub

   Public Length, Width, Height, ShippingWeight, OperatingWeight As Double
   Public Refrigerant As String
   Public NumCircuits As Integer
   private model as string

   Private Sub getChillerInfo()
      Dim message As String
      Dim chTable As DataTable

      ' checks if model is null or empty
      If IsNullOrEmpty(model) Then
         resetProperties()
         message = "The information for the chiller model cannot be found. "
         message &= "The chiller model is null or empty."
         Throw New ArgumentException(message)
      End If

            ' retrieves table with a row of information about the model
            chTable = DA1.Chillers.ChillerDataAccess.RetrieveChiller(model)

            ' checks if model is available
            If chTable.Rows.Count = 0 Then
         resetProperties()
         message = "The specifications for the chiller unit model, " & model & ", cannot be found. "
         Throw New ApplicationException(message)
      End If

      Dim dimensions As Object = chTable.Rows(0)("Dimensions")
      parse(dimensions)
      
      Refrigerant     = CNull.ToString( chTable.Rows(0)("Refg_1") )
      NumCircuits     = CNull.ToInteger( chTable.Rows(0)("Circuits_Per_Unit") )
      Shippingweight  = CNull.ToDouble( chTable.Rows(0)("Shipping_Weight") )
      Operatingweight = CNull.ToDouble( chTable.Rows(0)("Operating_Weight") )
   End Sub
   
   Private Sub parse(dimensions)
      If IsDBNull(dimensions) Then
         resetDimensions()
         Console.WriteLine("Dimensions are not available for this chiller model.")
      Else
         dimensions = dimensions.Replace("""", "") ' removes double quotes
         Try
            Dim dimensionsParser As New Rae.Math.Dimensions(dimensions)
            Length = dimensionsParser.Length
            Width  = dimensionsParser.Width
            Height = dimensionsParser.Height
         Catch ex As ArgumentNullException
            resetDimensions() : Console.WriteLine(ex.Message) : Console.WriteLine("Reset dimensions")
         Catch ex As FormatException
            resetDimensions() : Console.WriteLine(ex.Message) : Console.WriteLine("Reset dimensions")
         End Try
      End If
   End Sub

   Private Sub resetDimensions()
      Length = 0 : Width = 0 : Height = 0
   End Sub

   Private Sub resetProperties()
      resetDimensions()
      Refrigerant = ""
   End Sub

End Class

End Namespace
