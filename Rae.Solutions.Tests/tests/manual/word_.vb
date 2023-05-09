imports rae.reporting.beta

<TestClass>
public class word_
   private test_template as string = "c:\code\rae\solutions\main\rae.solutions.tests\tests\manual\test.docx"

   <TestMethod, Ignore>
   sub create_document_and_set_image
      dim report = new report(test_template)
      report.set_image("logo", "c:\code\rae\solutions\main\rae.solutions\images\century_ref.gif")
      report.show
   end sub

end class