Imports rae.Io.Text
Imports rae.solutions.unit_coolers.selections
Imports System.Data

Namespace rae.solutions.unit_coolers

    Partial Public Class service
        Sub New()
            repository = New repository()
        End Sub

        Function find_unit_coolers(ByVal criteria As criteria) As unit_cooler_list
            Dim unit_coolers As unit_cooler_list
            'If criteria.user_is_employee And Not criteria.filter_by_capacity Then
            '    unit_coolers = repository.get_unit_coolers(criteria.suction_temp, criteria.refrigerant, criteria.series)
            'Else
            unit_coolers = repository.get_unit_coolers(criteria.suction_temp, criteria.refrigerant, criteria.series, criteria.DOEModels)

            'don't want unit coolers greater than 15% of balance capacity
            Dim matches = New unit_cooler_list()
            For Each unit_cooler In unit_coolers
                If (unit_cooler.capacity_at(criteria.suction_temp, criteria.td, 0) < 1.15 * criteria.capacity_balance) OrElse (criteria.user_is_employee And Not criteria.filter_by_capacity) Then

                    Dim faceVelocityFlag As Boolean = False

                    If FaceVelocityInRange(unit_cooler.face_velocity, unit_cooler.series, unit_cooler.model, criteria.suction_temp, "X", criteria.user_is_employee, faceVelocityFlag) Then  ' do not know and do not care the defrost type, send "X"
                        matches.Add(unit_cooler)
                    End If

                End If
            Next
            unit_coolers = matches
            'End If
            unit_coolers.sort()
            'unit_coolers.remove_ibrs_until_multiplier_equation_is_available_from_jim_wilson()

            Return unit_coolers
        End Function

        Function find_unit_cooler_results_for_selection(ByVal input As unit_coolers.selections.unit_cooler_input, ByVal isEmployee As Boolean, sp As Decimal) As unit_cooler_table
            Dim unit_coolers = repository.get_unit_coolers(input)

            Dim td = input.td
            Dim suction = input.suction
            Dim matches = New unit_cooler_list()

            For Each unit_cooler In unit_coolers
                'note: filtering in memory to prevent duplicating multiplier equations in sql statement
                'is in between min and max capacity
                'and is within 2 degrees td
                If unit_cooler.series <> "NIBR" Then



                    If input.capacity_per_unit >= (unit_cooler.min_capacity(td, sp) * 0.9) _
                    And input.capacity_per_unit <= (unit_cooler.max_capacity(td, sp) * 1.1) _
                    And input.capacity_per_unit >= unit_cooler.capacity_at(suction + 2, td - 2, sp) _
                    And input.capacity_per_unit <= unit_cooler.capacity_at(suction - 2, td + 2, sp) Then

                        Dim faceVelocityFlag As Boolean = False
                        If FaceVelocityInRange(unit_cooler.face_velocity, unit_cooler.series, unit_cooler.model, input.suction, input.defrost_type, isEmployee, faceVelocityFlag) Then
                            If faceVelocityFlag Then
                                unit_cooler.WarningMessage = "Face Velocity Outside of Range for Air Defrost"
                            End If
                            matches.Add(unit_cooler)
                        End If


                    End If


                End If

            Next
            unit_coolers = matches
            unit_coolers.sort()

            'dim results = to_results_presentation_object(input, unit_coolers)
            Dim table = to_table(input, unit_coolers)
            Return table
        End Function


        Public Function FaceVelocityInRange(ByVal faceVelocity As Double, ByVal series As String, ByVal model As String, ByVal evaporatorTempValue As Double, ByVal selectedDefrostType As String, ByVal isEmployee As Boolean, ByRef faceVelocityFlag As Boolean) As Boolean
            ' Return True

            'ERICC2021
            If (selectedDefrostType.ToUpper = "A" AndAlso faceVelocity > 625) OrElse (evaporatorTempValue >= 25 AndAlso faceVelocity > 625) Then
                If isEmployee Then
                    faceVelocityFlag = True  ' Employees can select
                Else
                    ' reps can select certain unit coolers up to 700 as long as suction >= 25
                    If (series.ToUpper.StartsWith("AWSM") OrElse series.ToUpper.StartsWith("E") OrElse series.ToUpper.StartsWith("A") OrElse series.ToUpper = "BOC") AndAlso (faceVelocity <= 700) Then
                        faceVelocityFlag = True
                    Else
                        Return False
                    End If
                End If
            End If


            Return True
        End Function


        Private Function to_table(ByVal input As unit_cooler_input, ByVal unit_coolers As unit_cooler_list) As unit_cooler_table
            Dim table = New unit_cooler_table()

            For Each unit_cooler In unit_coolers
                Dim row = table.newRow()
                row("model") = unit_cooler.model
                Dim hasPrice As Boolean = False


                row("capacity") = unit_cooler.capacity_at(input.suction, input.td, CDbl(input.static_pressure))
                If IsNumeric(row("capacity")) Then
                    row("capacity") = System.Math.Round(CDbl(row("capacity")))
                End If



                row("length") = unit_cooler.unit_length
                row("width") = unit_cooler.unit_width
                row("height") = unit_cooler.unit_height
                row("cfm") = unit_cooler.at(CDbl(input.static_pressure)).cfm

                row("face_velocity") = unit_cooler.at(CDbl(input.static_pressure)).face_velocity
                If IsNumeric(row("face_velocity")) Then
                    row("face_velocity") = System.Math.Round(CDbl(row("face_velocity")))
                End If


                '      row("can_be_air_defrost") = Not (input.defrost_type = "A" And Not unit_cooler.face_velocity_is_suitable_for_air_defrost)
                row("actual_td") = unit_cooler.actual_td(input.capacity_per_unit, input.room_temperature, input.suction, 0)
                row("shipping_weight") = unit_cooler.shipping_weight
                row("operating_weight") = unit_cooler.operating_weight

                'calculate price
                ' Dim portions = unit_cooler.model.Split(New Char() {" "c})
                Dim model_portion = unit_cooler.model.Substring(unit_cooler.series.Length)

                Dim lp, rp As String
                lp = model_portion.Substring(0, model_portion.IndexOf("-"))

                If IsNumeric(lp.Substring(lp.Length - 1)) Then
                    lp = lp.Substring(0, lp.Length - 1) & "0"

                Else
                    lp = lp.Substring(0, lp.Length - 2) & "0"

                End If

                rp = model_portion.Substring(model_portion.IndexOf("-"))

                model_portion = lp & rp

                '                model_portion = model_portion.Remove(2, 1).Insert(2, "0") 'replace refrigerant indicator with 0
                model_portion = model_portion.Replace("-A", "") 'remove air defrost indicator (only on some a series)
                model_portion &= "-" & input.defrost_type 'append air defrost indicator




                Try
                    row("price") = rae.DataAccess.EquipmentOptions.OptionsDataAccess.RetrieveBaseListPrice(unit_cooler.series, model_portion)
                    hasPrice = True
                Catch ex As Exception

                    row("price") = -1
                    hasPrice = True

                    '                    System.Diagnostics.Debug.WriteLine("Price could not be retrieved for " & unit_cooler.series & " " & model_portion)
                    '                   hasPrice = False
                End Try

                row("Warning") = unit_cooler.WarningMessage


                row("DOECompliant") = (unit_cooler.DOECompliant = True).ToString

                If hasPrice Then table.Rows.Add(row)
            Next

            Return table
        End Function

        Class unit_cooler_table : Inherits system.data.datatable
            Sub New()
                Columns.Add("Model", GetType(String))
                Columns.Add("Capacity", GetType(Double))
                Columns.Add("Length", GetType(Double))
                Columns.Add("Width", GetType(Double))
                Columns.Add("Height", GetType(Double))
                Columns.Add("CFM", GetType(Double))
                Columns.Add("Face_Velocity", GetType(Double))
                'columns.add("can_be_air_defrost", getType(boolean))
                Columns.Add("Actual_TD", GetType(Double))
                Columns.Add("Price", GetType(Double))
                Columns.Add("Shipping_Weight", GetType(Double))
                Columns.Add("Operating_Weight", GetType(Double))
                Columns.Add("DOECompliant", GetType(String))
                Columns.Add("Warning", GetType(String))
            End Sub

            'function create_row() as row
            '   return new row(newRow())
            'end function

            'sub add(row as row)
            '   mybase.rows.add(row.inner_row)
            'end sub

            'class row
            '   friend inner_row as system.data.datarow

            '   sub new(row as system.data.datarow)
            '      inner_row = row   
            '   end sub

            '   property model as string
            '      get
            '         return inner_row("Model").toString
            '      end get
            '      set(value as string)
            '         inner_row("Model") = value
            '      end set
            '   end property
            'end class

        End Class


        'private function to_results_presentation_object(input as selections.unit_cooler_input, unit_coolers as unit_cooler_list) as list(of unit_cooler_result)
        '   dim results = new list(of unit_cooler_result)
        '   for each uc in unit_coolers
        '      dim result = new unit_cooler_result()
        '      result.model = uc.model

        '      dim input_suction = input.room_temperature - input.td
        '      result.capacity = uc.capacity_at(input_suction, input.td).tostring("###,###")
        '      result.capacity_at_plus_2_td = uc.capacity_at(input_suction - 2, input.td + 2).tostring("###,###")
        '      result.capacity_at_minus_2_td = uc.capacity_at(input_suction + 2, input.td - 2).tostring("###,###")

        '      result.dimensions = str("{0} x {1} x {2} in.", uc.unit_length, uc.unit_width, uc.unit_height)
        '      result.air_flow = uc.cfm.tostring("###,###")
        '      result.actual_td = uc.actual_td(input.total_capacity, input.room_temperature, input_suction).tostring("#0.#")

        '      dim portions = uc.model.split(new char() {" "c})
        '      dim model_portion = portions(1)
        '      model_portion = model_portion.remove(2, 1).insert(2, "0") 'replace refrigerant indicator with 0
        '      model_portion = model_portion.replace("-a", "") 'remove air defrost indicator (only on some a series)
        '      model_portion &= input.defrost_type 'append air defrost indicator
        '      try
        '         result.price = rae.dataaccess.equipmentoptions.optionsdataaccess.retrievebaselistprice(uc.series, model_portion).tostring("$###,###")
        '      catch ex as exception
        '         result.price = "NA"
        '      end try
        '      results.add(result)
        '   next

        '   return results
        'end function




        Function get_unit_cooler(ByVal model As String) As unit_cooler
            Return repository.get_unit_cooler(model)
        End Function

        Private repository As repository
    End Class

End Namespace