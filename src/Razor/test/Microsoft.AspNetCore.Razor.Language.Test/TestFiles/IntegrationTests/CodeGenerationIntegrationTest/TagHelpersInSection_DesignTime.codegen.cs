// <auto-generated/>
#pragma warning disable 1591
namespace Microsoft.AspNetCore.Razor.Language.IntegrationTests.TestFiles
{
    #line hidden
    public class TestFiles_IntegrationTests_CodeGenerationIntegrationTest_TagHelpersInSection_DesignTime
    {
        private global::TestNamespace.MyTagHelper __TestNamespace_MyTagHelper;
        private global::TestNamespace.NestedTagHelper __TestNamespace_NestedTagHelper;
        #pragma warning disable 219
        private void __RazorDirectiveTokenHelpers__() {
        ((System.Action)(() => {
#line 1 "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/TagHelpersInSection.cshtml"
global::System.Object __typeHelper = "*, TestAssembly";

#line default
#line hidden
        }
        ))();
        ((System.Action)(() => {
#line 7 "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/TagHelpersInSection.cshtml"
global::System.Object MySection = null;

#line default
#line hidden
        }
        ))();
        ((System.Action)(() => {
#line 15 "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/TagHelpersInSection.cshtml"
global::System.Object nestedsection = null;

#line default
#line hidden
        }
        ))();
        }
        #pragma warning restore 219
        #pragma warning disable 0414
        private static System.Object __o = null;
        #pragma warning restore 0414
        #pragma warning disable 1998
        public async System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/TagHelpersInSection.cshtml"
  
    var code = "some code";

#line default
#line hidden
            DefineSection("MySection", async(__razor_section_writer) => {
#line 11 "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/TagHelpersInSection.cshtml"
                                                  __o = code;

#line default
#line hidden
                __TestNamespace_NestedTagHelper = CreateTagHelper<global::TestNamespace.NestedTagHelper>();
                __TestNamespace_MyTagHelper = CreateTagHelper<global::TestNamespace.MyTagHelper>();
#line 9 "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/TagHelpersInSection.cshtml"
                                             __o = DateTime.Now;

#line default
#line hidden
                __TestNamespace_MyTagHelper.BoundProperty = string.Empty;
#line 9 "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/TagHelpersInSection.cshtml"
                                                                                           __o = DateTime.Now;

#line default
#line hidden
                __TestNamespace_NestedTagHelper = CreateTagHelper<global::TestNamespace.NestedTagHelper>();
            }
            );
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
