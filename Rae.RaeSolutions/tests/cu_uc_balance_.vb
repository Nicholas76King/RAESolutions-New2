imports rae.solutions.cu_uc_balance
imports Microsoft.VisualStudio.TestTools.UnitTesting

namespace rae.solutions.tests

<TestClass> _
public class cu_uc_balance_
   <TestMethod> _
   sub balance_capacity
      dim unit_coolers = new units()
      unit_coolers.add(new unit(capacity:=25, quantity:=3))
      unit_coolers.add(new unit(capacity:=30, quantity:=4))
      dim condensing_unit = new unit(capacity:=100, quantity:=2)
      dim service = new service()
      
      dim balance = service.calculate_balance(condensing_unit, unit_coolers)
      is_true(balance = 5)
   end sub
   
   '<TestMethod> _
   'sub balance_units
   '   dim service = new service()
   '   dim criteria as fill_unit_coolers.criteria
   '   criteria.series = "A"
   '   dim unit_coolers = service.find_unit_coolers(criteria)
   '   'presenter.find_unit_coolers()

   '   'dim criteria = grab_criteria()
   '   'uc = service.get_unit_coolers(criteria)
   '   '
   '   'cu =
   '   ' grab(cu, uc, spec)
   '   'dim results = service.balance(cu, uc, spec)
   '   'set_controls(results)

   '   'dim factory = new factory()
   '   'dim unit_cooler = factory.create(model)
   '   'unit_cooler_repository, condensing_unit_repository
   '   'i_multiplier_algorithm, i_capacity_algorithm

   '   'dim condensing_unit  = form.grab_condensing_unit()
   '   'dim unit_coolers     = form.grab_unit_cooler()
   '   'dim spec             = form.grab_spec()
   '   'dim results = cu_uc.balance(condensing_unit, unit_coolers, spec)
   '   'dim results = service.balance(condensing_unit, unit_coolers, spec)

   'end sub
   
   private sub is_true(test as boolean)
      assert.isTrue(test)
   end sub
end class

end namespace