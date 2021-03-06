#pragma checksum "C:\Users\Bhuva Sahil\source\repos\JobPortal\JobPortal\Views\Provider\ListApplicant.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e43fbbe98bee26a9ed0bf3292ee3dc0cc32409dd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Provider_ListApplicant), @"mvc.1.0.view", @"/Views/Provider/ListApplicant.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Bhuva Sahil\source\repos\JobPortal\JobPortal\Views\_ViewImports.cshtml"
using JobPortal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Bhuva Sahil\source\repos\JobPortal\JobPortal\Views\_ViewImports.cshtml"
using JobPortal.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Bhuva Sahil\source\repos\JobPortal\JobPortal\Views\Provider\ListApplicant.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e43fbbe98bee26a9ed0bf3292ee3dc0cc32409dd", @"/Views/Provider/ListApplicant.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59cfc42c50406b4c1ee6dd5dd16f07c975b1d8f0", @"/Views/_ViewImports.cshtml")]
    public class Views_Provider_ListApplicant : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<JobPortal.ViewModel.ListApplicantViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "C:\Users\Bhuva Sahil\source\repos\JobPortal\JobPortal\Views\Provider\ListApplicant.cshtml"
  
    ViewData["title"] = "List";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">
    <div class=""row"">
        <div class=""col-lg-10 mx-auto mb-4"">
            <div class=""section-title text-center "">
                <h3 class=""top-c-sep"">People interested in job.</h3>
            </div>
        </div>
    </div>

    <div class=""row"">
        <div class=""col-lg-10 mx-auto"">
            <div class=""career-search mb-60"">
                <div class=""filter-result"">
");
#nullable restore
#line 22 "C:\Users\Bhuva Sahil\source\repos\JobPortal\JobPortal\Views\Provider\ListApplicant.cshtml"
                     if (Model.Count() == 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h6 class=\"text-center alert-info\">No users yet</h6>\r\n");
#nullable restore
#line 25 "C:\Users\Bhuva Sahil\source\repos\JobPortal\JobPortal\Views\Provider\ListApplicant.cshtml"
                    }
                    else
                    {
                        foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""job-box d-md-flex align-items-center justify-content-between mb-30"">
                                <div class=""job-left my-4 d-md-flex align-items-center flex-wrap"">
                                    <div class=""job-content"">
                                        <h5 class=""text-center text-md-left"">");
#nullable restore
#line 33 "C:\Users\Bhuva Sahil\source\repos\JobPortal\JobPortal\Views\Provider\ListApplicant.cshtml"
                                                                        Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                    </div>\r\n                                </div>\r\n                                <div class=\"job-right my-4 flex-shrink-0\">\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 1531, "\"", 1554, 1);
#nullable restore
#line 37 "C:\Users\Bhuva Sahil\source\repos\JobPortal\JobPortal\Views\Provider\ListApplicant.cshtml"
WriteAttributeValue("", 1538, item.ResumeLink, 1538, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn d-block w-100 d-sm-inline-block btn-light\">Open Resume</a>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 40 "C:\Users\Bhuva Sahil\source\repos\JobPortal\JobPortal\Views\Provider\ListApplicant.cshtml"
                        }   
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<IdentityUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<IdentityUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<JobPortal.ViewModel.ListApplicantViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
