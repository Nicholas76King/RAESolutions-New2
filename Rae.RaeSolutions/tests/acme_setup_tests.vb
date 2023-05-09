option strict off

<TestClass> _
public class when_acme_setup_is_not_installed : inherits given_installing_setup
   <TestInitialize> _
   sub init
      acme = create_acme_setup()
      if not acme.is_installed then
         acme.install()
      end if
   end sub

   <TestMethod> _
   sub then_acme_setup_installed_status_is_correct
      assert( acme.is_installed = true )
   end sub
end class



public class given_installing_setup : inherits context
   Protected acme as acme_setup
   
   protected function create_acme_setup() as acme_setup
      dim app_folder_path = "c:\code\rae\solutions\main\standardrefrigeration\dependencies\acmexhx\"
      return new acme_setup(app_folder_path)
   end function
end class

public class context
   protected function log(msg) As boolean
      system.diagnostics.debug.writeline(msg)
   end function
   
   protected sub assert(assertion)
      microsoft.visualstudio.testtools.unittesting.assert.istrue(assertion)
   end sub
end class