Public Class key_code

   ''' <summary>True if a number or a minus sign key is pressed</summary>
   Shared Function is_number(keyCode As Keys) As Boolean
      Dim number = True

      Select Case keyCode
         Case Keys.A, Keys.B, Keys.C, Keys.D, Keys.E, Keys.F, Keys.G, Keys.H, Keys.I, Keys.J, Keys.K, Keys.L, Keys.M, _
         Keys.N, Keys.O, Keys.P, Keys.Q, Keys.R, Keys.S, Keys.T, Keys.U, Keys.V, Keys.W, Keys.X, Keys.Y, Keys.Z, _
         Keys.Add, Keys.Space, Keys.Subtract, Keys.Divide, Keys.Multiply, Keys.Separator, Keys.Oemcomma, Keys.OemBackslash, _
         Keys.OemPipe, Keys.Oemplus, Keys.OemQuestion, Keys.OemQuotes, Keys.OemSemicolon, Keys.Oemtilde
            number = False
      End Select

      Return number
   End Function
   
   shared function navigation(key as keys) as boolean
      select case key
         case keys.right, keys.left, keys.down, keys.up
            return true
      end select
   end function

End Class
