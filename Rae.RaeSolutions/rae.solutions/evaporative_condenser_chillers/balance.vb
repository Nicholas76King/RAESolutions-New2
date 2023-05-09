option strict off

Imports Rae.Math.comparisons
Imports Rae.RaeSolutions.Business.Entities
Imports rae.solutions.chiller_evaporators
Imports Rae.Validation
Imports raen.math.equations
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert

namespace rae.solutions.evaporative_condenser_chillers

public structure spec
   public fluid as coolingmedia
   public hertz as integer ' voltage
   public catalog_rating as boolean ' safety_override
   public specific_gravity, specific_heat as double ' glycol_percentage
   public discharge_line_loss, suction_line_loss as double
   public range, subcooling_temp as double ' min_suction_temp
   public ambient, ambient_lower_range, ambient_upper_range, ambient_step as double
   public leaving_fluid_temp, leaving_fluid_temp_lower_range, leaving_fluid_temp_upper_range, leaving_fluid_temp_step as double
   public compressor_capacity_factor, compressor_amp_factor, condenser_capacity_factor as double
   public lower_approach, upper_approach as double
   public user as user
   public capacity_at_lower_approach_for_circuit_1_if_custom_evaporator, capacity_at_upper_approach_for_circuit_1_if_custom_evaporator as double
   public capacity_at_lower_approach_for_circuit_2_if_custom_evaporator, capacity_at_upper_approach_for_circuit_2_if_custom_evaporator as double

   function entering_fluid_temp() as double
      return leaving_fluid_temp + range
   end function
end structure


public class balance
   
   private service as chillers.balance_service

   sub new()
      service = new chillers.balance_service()
   end sub

   function run(chiller as chiller, evaporators as evaporator_list, spec as spec) as point_list
      if not is_among(spec.leaving_fluid_temp, -40, 75) then _
         throw new exception("Leaving fluid temperature is out of range (-40 < t < 75): t=" & spec.leaving_fluid_temp)
      
      'todo: no need to select lwt range if only running at conditions
      dim te_lower, te_upper as double
      service.select_evaporating_temp_range(spec.leaving_fluid_temp, te_lower, te_upper)
      
      dim gpm_factor as double
      if spec.fluid <> CoolingMedia.Water then
         gpm_factor = 500 * spec.specific_heat * spec.specific_gravity * spec.range
      end if


      dim polynomial = new compressor_polynomial()
      
      dim compressor_factor as polynomial_set
      compressor_factor.q = spec.compressor_capacity_factor
      compressor_factor.w = 0.7821 * compressor_factor.q + 0.2104
      compressor_factor.a = spec.compressor_amp_factor
      
      dim hz_factor = service.get_hertz_multipliers(spec.hertz)


            '            Dim sub_cooling_factor = 1 + (0.005 * spec.subcooling_temp)
            'If 410
            '   dim sub_cooling_factor = 1 + (0.0075 * (spec.subcooling_temp- compressorsubcooling))
            '            else
            '   dim sub_cooling_factor = 1 + (0.005 * (spec.subcooling_temp- compressorsubcooling))


            Dim points = New point_list
            Dim circuit_index = -1

            If chiller.circuits.Count > 1 AndAlso chiller.circuits(1).compressor_qty = 0 Then
                chiller.circuits.RemoveAt(1)
                chiller.num_circuits /= 2
            End If

            For Each circuit In chiller.circuits


                Dim sub_cooling_factor As Double

                If chiller.refg.toString = "410A" Then
                    sub_cooling_factor = 1 + (0.0075 * (spec.subcooling_temp - circuit.compressor.coef.SubCooling))
                Else
                    sub_cooling_factor = 1 + (0.005 * (spec.subcooling_temp - circuit.compressor.coef.SubCooling))
                End If


                '                ()

                Dim logger = New logger()
                'logger.log(chiller)
                'logger.log(spec)
                circuit_index += 1

                Dim multiplier As polynomial_set
                multiplier.q = circuit.compressor_qty * compressor_factor.q * hz_factor.q
                multiplier.w = circuit.compressor_qty * compressor_factor.w * hz_factor.w
                multiplier.a = circuit.compressor_qty * compressor_factor.a * hz_factor.a

                Dim condenser_capacity = calculate_condenser_capacity_per_circuit( _
                   chiller.condenser.capacity, chiller.num_circuits, circuit_index, chiller.condenser_quantity)
                condenser_capacity *= spec.condenser_capacity_factor

                polynomial.set(chiller.refg, circuit.compressor.coef)
                Dim h1_calc = New h1_calculator(condenser_capacity, spec.discharge_line_loss)
                Dim balance = New balance_compressor_and_condenser(polynomial, h1_calc, multiplier)

                Dim m = (25 + spec.discharge_line_loss) / condenser_capacity

                'get_capacity_at_upper_and_lower_approach(spec, i, evaporators)
                Dim capacity_at_upper_approach, capacity_at_lower_approach As Double
                Dim using_custom_evaporator As Boolean
                If spec.capacity_at_lower_approach_for_circuit_1_if_custom_evaporator > 0 Then
                    using_custom_evaporator = True
                    If circuit_index > 0 Then
                        capacity_at_upper_approach = spec.capacity_at_upper_approach_for_circuit_2_if_custom_evaporator
                        capacity_at_lower_approach = spec.capacity_at_lower_approach_for_circuit_2_if_custom_evaporator
                    Else
                        capacity_at_upper_approach = spec.capacity_at_upper_approach_for_circuit_1_if_custom_evaporator
                        capacity_at_lower_approach = spec.capacity_at_lower_approach_for_circuit_1_if_custom_evaporator
                    End If
                Else
                    using_custom_evaporator = False
                    Dim lower_approach = evaporators.at(spec.lower_approach)
                    Dim upper_approach = evaporators.at(spec.upper_approach)
                    capacity_at_upper_approach = upper_approach.capacity
                    capacity_at_lower_approach = lower_approach.capacity
                End If

                Dim q, compressor_w, compressor_a As Double

                For ta = (spec.ambient - spec.ambient_lower_range) To (spec.ambient + spec.ambient_upper_range) Step spec.ambient_step
                    If ta > spec.ambient + 15 Then _
                       Exit For

                    Dim q_at_lower_te = balance.at(te_lower, ta).q
                    Dim q_at_upper_te = balance.at(te_upper, ta).q

                    Dim q_per_degree = (q_at_upper_te - q_at_lower_te) / 15
                    Dim b = te_upper - (q_at_upper_te / q_per_degree)
                    Dim m1 = (te_upper - b) / q_at_upper_te

                    Dim tc, te As Double

                    For tw = (spec.leaving_fluid_temp - spec.leaving_fluid_temp_lower_range) To (spec.leaving_fluid_temp + spec.leaving_fluid_temp_upper_range) Step spec.leaving_fluid_temp_step
                        te = tw - (spec.upper_approach + spec.suction_line_loss)

                        'calc_te(lower_approach_capacity, upper_approach_capacity, m1, b)
                        Dim ee = (capacity_at_upper_approach - capacity_at_lower_approach) / 2 ' half of difference
                        Dim f = te + (capacity_at_upper_approach / ee)
                        Dim g = (te - f) / capacity_at_upper_approach ' -1/half of difference
                        te = ((b * g) - (f * m1)) / (g - m1)

                        Dim pt = balance.at(te, ta)
                        q = pt.q : compressor_w = pt.w : compressor_a = pt.a : tc = pt.tc

                        If spec.catalog_rating Then _
                           q *= 1.04
                        q = Convert.BtuhToTons(q)
                        q *= sub_cooling_factor

                        Dim gpm As Double
                        If spec.fluid <> CoolingMedia.Water Then
                            gpm = 12000 * q / gpm_factor
                        Else
                            gpm = 12000 * q / (500 * spec.range)
                        End If

                        Dim compressor_kw = compressor_w / 1000

                        Dim condenser_w As Double

                        Dim x = spec.condenser_capacity_factor * 100
                        Dim condenser_fan_watt_factor = 0.000199 * x ^ 3 - 0.012576 * x ^ 2 + 0.265307 * x - 0.86014
                        chiller.calculate_fan_watts()
                        chiller.total_fan_watts *= condenser_fan_watt_factor * 0.01

                        If chiller.num_circuits = 1 Then
                            condenser_w = chiller.total_condenser_watts
                        Else
                            condenser_w = chiller.total_condenser_watts / 2
                        End If

                        Dim condenser_kw = condenser_w / 1000
                        Dim unit_w = compressor_w + condenser_w
                        Dim unit_kw = compressor_kw + condenser_kw
                        Dim compressor_kw_per_ton = compressor_kw / q
                        Dim compressor_eer = q * 12000 / compressor_w
                        Dim unit_kw_per_ton = unit_kw / q
                        Dim unit_eer = q * 12000 / unit_w
                        'dim cop                   = q*12000/(w*3.413)

                        te += spec.suction_line_loss

                        Dim approach = tw - round(te, 1) 'round te b/c it's rounded in view, don't want approach to look wrong

                        Dim point = New point()
                        point.ambient = ta
                        point.leaving_fluid_temp = tw
                        point.evaporating_temp = te
                        point.condensing_temp = tc
                        point.capacity = q
                        point.compressor_kw = compressor_kw
                        point.compressor_kw_per_ton = compressor_kw_per_ton
                        point.compressor_eer = compressor_eer
                        point.compressor_amps = compressor_a
                        point.unit_kw = unit_kw
                        point.unit_kw_per_ton = unit_kw_per_ton
                        point.gpm = gpm
                        point.approach = approach
                        point.eer = unit_eer

                        Dim approach_validator = New approach_is_in_range(point, spec.user).validate()
                        point.validators.add(approach_validator)

                        If approach_validator.is_invalid Then
                            point.fluid_pressure_drop = 999
                        Else
                            Dim at_approach = evaporators.at(approach)

                            If using_custom_evaporator Then
                                point.fluid_pressure_drop = 999
                            Else
                                Dim approach_returned_validator = New approach_should_be_returned_by_acme_dll(at_approach, approach).validate()
                                point.validators.add(approach_returned_validator)
                                If approach_returned_validator.is_invalid Then
                                    point.fluid_pressure_drop = 999
                                Else
                                    point.fluid_pressure_drop = (point.gpm / at_approach.fluid_flow) ^ 2 * at_approach.fluid_pressure_drop
                                End If
                            End If
                        End If

                        points.add(point)
                    Next
                Next
            Next

            Return points
        End Function
   
   private function calculate_condenser_capacity_per_circuit( _
   condenser_capacity_per_condenser, number_of_circuits, circuit_index, condenser_quantity) as double
      dim condenser_capacity as double
      
      if number_of_circuits = 1 or number_of_circuits = 4 then
         condenser_capacity = condenser_capacity_per_condenser
      else if number_of_circuits = 3 then 'SM at 75% load still uses both condensers
         condenser_capacity = condenser_capacity_per_condenser
      else if number_of_circuits = 2 then
         if condenser_quantity = 2 then '(SM) if this was originally a 4 circuit unit but 2 compressors were dropped during IPLV
            condenser_capacity = condenser_capacity_per_condenser
         else
            condenser_capacity = condenser_capacity_per_condenser / 2 '(SD) for 2 circuits with one condenser
         end if
      end if
      
      return condenser_capacity
   end function
   
   
   public class point
      sub new()
         validators = new validator_list()         
      end sub
      public leaving_fluid_temp, ambient, evaporating_temp, condensing_temp as double
      public unit_kw, unit_kw_per_ton, eer as double
      public capacity, gpm, approach, fluid_pressure_drop as double
      public compressor_kw, compressor_kw_per_ton, compressor_eer, compressor_amps as double
      public validators as validator_list
   end class
   
   public class point_list : inherits list(of point)
   
      function at(leaving_fluid_temp, ambient) as point
         for each pt in me
            if pt.ambient = ambient and pt.leaving_fluid_temp = leaving_fluid_temp then
               return pt
            end if
         next
      end function
      
      sub add(point as point)
         for each pt in me
            if pt.ambient = point.ambient and pt.leaving_fluid_temp = point.leaving_fluid_temp then
               dim aggregate = new point()
               aggregate.approach               = floor(avg(pt.approach, point.approach))
               aggregate.ambient                = avg(pt.ambient, point.ambient)
               aggregate.leaving_fluid_temp     = avg(pt.leaving_fluid_temp, point.leaving_fluid_temp)
               aggregate.condensing_temp        = avg(pt.condensing_temp, point.condensing_temp)
               aggregate.evaporating_temp       = avg(pt.evaporating_temp, point.evaporating_temp)
               aggregate.compressor_kw_per_ton  = avg(pt.compressor_kw_per_ton, point.compressor_kw_per_ton)
               aggregate.unit_kw_per_ton        = avg(pt.unit_kw_per_ton, point.unit_kw_per_ton)
               aggregate.eer                    = avg(pt.eer, point.eer)
               aggregate.compressor_eer         = avg(pt.compressor_eer, point.compressor_eer)

               aggregate.capacity            = pt.capacity + point.capacity
               aggregate.compressor_amps     = pt.compressor_amps + point.compressor_amps
               aggregate.compressor_kw       = pt.compressor_kw + point.compressor_kw
               aggregate.fluid_pressure_drop = 2*(pt.fluid_pressure_drop + point.fluid_pressure_drop)
               aggregate.gpm                 = pt.gpm + point.gpm
               aggregate.unit_kw             = pt.unit_kw + point.unit_kw
               
               aggregate.validators.add(point.validators)
               ' can't update value type; attempt will create new value type
               remove(pt)
               add(aggregate)
               exit sub
            end if
         next
         
         mybase.add(point)
      end sub
      
      function contain_invalid_point as boolean
         return not are_all_valid
      end function
      
      function contain_invalid_fluid_pd as boolean
         for each point in me
            if point.fluid_pressure_drop >= 999
               return true
            end if
         next
         return false
      end function
      
      private function are_all_valid as boolean
         for each point in me
            if point.validators.is_invalid
               return false
            end if
         next
         return true
      end function
      
   end class
end class

end namespace