imports rae.solutions.chillers
imports rae.solutions.evaporative_condenser_chillers
imports system.diagnostics

<TestClass> _
public class iplv_for_35E2s_ : inherits test_chiller_base

   <TestMethod> _
   sub calculate_iplv_for_all_35E2s_and_write_to_desktop_file_35E2_IPLVs
      dim spec = evaporative_condenser_chiller_mocks.default_spec

      config.db
      dim path = "C:\Users\CaseyJ\Desktop\35E2 IPLVs.txt"
      dim file = IO.File.AppendText(path)
      dim chiller_models() as string = {"35E2SS50", "35E2SS60", "35E2SS70", "35E2SS80", "35E2SS90", "35E2SS110", "35E2SS120", "35E2SS140", _
                                        "35E2SD100", "35E2SD120", "35E2SD140", "35E2SD160", "35E2SD180", "35E2SD220", "35E2SD240", "35E2SD280", _
                                        "35E2SM200", "35E2SM240", "35E2SM280", "35E2SM320", "35E2SM360", "35E2SM440"}
      for each chiller_model in chiller_models
         dim chiller = get_chiller(chiller_model, 460)
         dim evaporators = get_evaporators(chiller, spec)

         dim watch = stopwatch.StartNew()
            dim iplv_commands = new iplv_commands(spec, chiller, evaporators)
            dim iplv = new plv_algorithm(iplv_commands)
            dim value = iplv.calculate()
         log(watch.elapsed)
         
         dim message = rae.io.text.str("{0} iplv: {1}", chiller_model, round(value, 2))
         
         file.WriteLine(message)
         
         assert(value > 0)
      next
      
      file.Flush()
      file.Close()
   end sub
   
   <TestMethod> _
   sub calculate_iplv_for_35E2SS60
      dim spec = evaporative_condenser_chiller_mocks.default_spec
      config.db
      dim chiller = get_chiller("35E2SS60", 460)
      dim evaporators = get_evaporators(chiller, spec)
      dim iplv_commands = new iplv_commands(spec, chiller, evaporators)
      dim iplv = new plv_algorithm(iplv_commands).calculate()
      assert(rae.math.comparisons.IsAccurate(iplv, percentage:=1, expected:=13.3))
   end sub
   
   <TestMethod> _
   sub calculate_iplv_for_35E2SD280
      dim spec = evaporative_condenser_chiller_mocks.default_spec
      config.db
      dim chiller = get_chiller("35E2SD280", 460)
      dim evaporators = get_evaporators(chiller, spec)
      dim iplv_commands = new iplv_commands(spec, chiller, evaporators)
      dim iplv = new plv_algorithm(iplv_commands).calculate()
      assert(rae.math.comparisons.IsAccurate(iplv, percentage:=1, expected:=15.1))
   end sub
   
   <TestMethod> _
   sub calculate_iplv_for_35E2SM200
      dim watch = System.Diagnostics.Stopwatch.StartNew()
      dim spec = evaporative_condenser_chiller_mocks.default_spec
      config.db
      dim chiller = get_chiller("35E2SM200", 460)
      dim evaporators = get_evaporators(chiller, spec)
      dim iplv_commands = new iplv_commands(spec, chiller, evaporators)
      dim iplv = new plv_algorithm(iplv_commands).calculate()
      System.Diagnostics.Trace.WriteLine("Elapsed: " & watch.Elapsed.ToString())
      System.Diagnostics.Trace.WriteLine("IPLV: " & iplv)
      
      assert(rae.math.comparisons.IsAccurate(iplv, percentage:=1, expected:=10.8))
   end sub

   private overloads sub log(low as iplv_output, high as iplv_output)
      log("gpm/ton difference: " & round(low.gpm_per_ton - high.gpm_per_ton, 1) & " gpm/ton")
      log("capacity difference: " & round(low.capacity - high.capacity * 0.75, 1) & " tons")
   end sub
   
end class