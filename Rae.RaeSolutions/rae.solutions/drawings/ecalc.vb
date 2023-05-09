Option Strict Off

Imports Rae.Math.comparisons
Imports Rae.Math.Calculate
Imports Rae.RaeSolutions.Business
Imports Rae.RaeSolutions.Business.Division

Namespace rae.solutions.drawings

class ecalc

   ''' <summary>minimum circuit amps</summary>
   ''' <param name="lg">largest rla</param>
   overridable function mca(lg, rla) as double
      mca = lg*.25 + rla
            If mca > 1 Then _
               mca = rnd(mca, 1)
   end function
   
   ''' <summary>max overcurrent protection</summary>
   ''' <param name="lg">largest rla</param>
   ''' <param name="rla">total rla</param>
   function mop(lg, rla) as double
      mop = lg*1.25 + rla
   end function

   ''' <summary>selects largest nominal fuse size that is less than the mop.</summary>
   ''' <param name="mop">max overcurrent protection</param>
   ''' ''' <remarks>Standard fuse sizes   
   ''' 15, 20, 25, 30, 35, 40, 45, 50, 60, 70, 80, 90, 100, 110, 125, 150, 200, 225, 250, and 300.
   ''' </remarks>
   function fuse(mop) as integer
      dim size As double

      If is_in_range(mop, 0, 20)
         size = 15
      ElseIf is_in_range(mop, 20, 50)
         size = Rae.Math.Calculate.Floor(mop, 5)
      ElseIf is_in_range(mop, 50, 120)
         size = Floor(mop, 10)
      ElseIf is_in_range(mop, 120, 125)
         size = 110
      ElseIf is_in_range(mop, 125, 250)
         size = Floor(mop, 25)
      ElseIf is_in_range(mop, 250, 500)
         size = Floor(mop, 50)
      ElseIf is_in_range(mop, 500, 600)
         size = 500
      ElseIf mop >= 600
         size = 600
      Else
         Throw New ArgumentException("Nominal fuse size cannot be determined. Fuse size: " & mop & ", is out of range.")
      End If

      return cint(size)
   end function
   
   ''' <summary>transformer amps</summary>
   protected function t(division as Division) as double
      if division = CRI
         t = 10
      else if division = TSI
         t = 15
      else
         throw new ArgumentException("The transformer amps cannot be determined. The company division, " & division.ToString() & ", is not handled.")
      end if
      'used to be: t = cq * 3
   end function
   
   ' used with either of these options. the options are really the same.
   'et10 - kva transformer w/ 15 amp gfi outlet
   'et02 - control circuit transformer w/ convenience outlet
   ''' <summary>Convenience Outlet</summary>
   ''' <param name="v">voltage (460, 230, 208)</param>
   protected overridable function outlet(v) as double
      if v=230 Or v=208
         outlet = 10
      else if v=460
         outlet = 5
      else
         throw new exception("Convenience outlet amps cannot be calculated. The voltage is invalid.")
      end if
   end function
   
   protected function rnd(value as double, Optional digits As Integer = 0) as double
      return System.Math.Round(value, digits)
   end function   
   
end class

'30A2
class chiller_ecalc : inherits ecalc
   
   function rla(c1,cq1,f1,fq1,c2,cq2,f2,fq2,p,v, et02,division) as double
            rla = c1 * cq1 + f1 * fq1 + _
                  c2 * cq2 + f2 * fq2 + p + t(division)
      if et02 then rla += outlet(v)
            rla = rnd(rla)
   end function
   
   function rla1(c1,cq1,f1,fq1,c2,cq2,f2,fq2, p,v, et02,division) as double
      rla1 = (c1*cq1+c2*cq2)/2 + (f1*fq1+f2*fq2)/2 + p + t(division)
      if et02 then rla1 += outlet(v)
            rla1 = rnd(rla1)
   end function
   
   function rla2(c1,cq1,f1,fq1,c2,cq2,f2,fq2) as double
      rla2 = (c1*cq1+c2*cq2)/2 + (f1*fq1+f2*fq2)/2
            rla2 = rnd(rla2)
   end function
   
end class

class cond_ecalc : inherits ecalc
   overrides function mca(f, rla) as double
      mca = f*.25 + rla
            If mca > 1 Then _
               mca = rnd(mca)
      if mca = rla andalso rla > 0 then _
         mca += 1
   end function
   
   function rla(f,fq,v) As double
      rla = f*fq + outlet(v)
            If rla > 1 Then _
               rla = rnd(rla)
   end function
end class

''' <summary>stand-alone pump package electrical calculator</summary>
class pp_ecalc : inherits ecalc
   
   function rla(p, pq) as double
      rla = p*pq
            If rla > 1 Then _
               rla = rnd(rla)
   end function
   
end class

class cu_ecalc : inherits ecalc

   ''' <summary>rated load amps</summary>
   ''' <param name="c">compressor amps</param>
   ''' <param name="cq">compressor quantity</param>
   ''' <param name="f">fan amps</param>
   ''' <param name="fq">fan quantity</param>
   ''' <param name="et10">option et10 - kva transformer w/ 15 amp gfi outlet (convenience outlet)</param>
   ''' <param name="v">voltage (460, 230, 208)</param>
   function rla(c, cq, f, fq, et10, v, division) as double
      rla = c*cq + f*fq + controls(v, cq)
      if et10 then rla += outlet(v)
            If rla > 1 Then rla = rnd(rla, 3)
   end function
   
   function rla(c1, c1q, f1, f1q, _
                c2, c2q, f2, f2q, et10, v, division) as double
      rla = c1*c1q + c2*c2q + f1*f1q + f2*f2q + controls(v, c1q+c2q)
      if et10 then rla += outlet(v)
            If rla > 1 Then rla = rnd(rla, 3)
   end function

   protected overloads function controls(v, cq) as double
            If v = 575 Then
                controls = 0.4 * cq
            ElseIf v = 460 Then
                controls = 0.5 * cq
            ElseIf v = 230 Or v = 208 Then
                controls = 1 * cq
            End If
            If controls = 0 Then Throw New Exception("The amps for controls cannot be determined. v=" & v & ", compressor quantity=" & cq)
        End Function

end class
end namespace