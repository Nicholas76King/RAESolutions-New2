Class Mocks

   Function GetRaeRatingSpec() As Rating.Spec
      Dim spec As Rating.Spec
      
      spec.Fluid             = Fluid.Water
      spec.GlycolPercentage  = 40
      spec.NumCircuits       = 4
      spec.Refrigerant       = Refrigerant.R22
      spec.EnteringFluidF    = 54
      spec.LeavingFluidF     = 44
      spec.EvaporatingF      = 35
      
      Return spec
   End Function
   
   Function GetFailingSpec() As Rating.Spec
      Return GetRaeRatingSpec()
   End Function
   
   Function GetTxRatingSpec() As Rating.Spec
      Dim spec As Rating.Spec
      
      spec.Fluid             = Fluid.Water
      spec.GlycolPercentage  = 40
      spec.NumCircuits       = 1
      spec.Refrigerant       = Refrigerant.R22
      spec.EnteringFluidF    = 54
      spec.LeavingFluidF     = 44
      spec.EvaporatingF      = 35
      
      Return spec
   End Function

End Class
