#pragma checksum "C:\Users\harp\Documents\GitHub\Integration-Project-Class\assignments\Assignment3_integration\Views\ContactUS\Success.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b4a60fa1f64fc65862701c927f792a26519c6607"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ContactUS_Success), @"mvc.1.0.view", @"/Views/ContactUS/Success.cshtml")]
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
#line 1 "C:\Users\harp\Documents\GitHub\Integration-Project-Class\assignments\Assignment3_integration\Views\_ViewImports.cshtml"
using Assignment3_integration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\harp\Documents\GitHub\Integration-Project-Class\assignments\Assignment3_integration\Views\_ViewImports.cshtml"
using Assignment3_integration.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4a60fa1f64fc65862701c927f792a26519c6607", @"/Views/ContactUS/Success.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66776a01f41c8a6042b62d0905fe491603ec0949", @"/Views/_ViewImports.cshtml")]
    public class Views_ContactUS_Success : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Assignment3_integration.Models.Contact>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\harp\Documents\GitHub\Integration-Project-Class\assignments\Assignment3_integration\Views\ContactUS\Success.cshtml"
  
    ViewData["Title"] = " Email Confirmation ";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>Email Confirmation</h1>\r\n<h2>Thank you for contacting us ");
#nullable restore
#line 7 "C:\Users\harp\Documents\GitHub\Integration-Project-Class\assignments\Assignment3_integration\Views\ContactUS\Success.cshtml"
                           Write(Model.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 7 "C:\Users\harp\Documents\GitHub\Integration-Project-Class\assignments\Assignment3_integration\Views\ContactUS\Success.cshtml"
                                            Write(Model.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h2>\r\n<p>A copy has been sent to ");
#nullable restore
#line 8 "C:\Users\harp\Documents\GitHub\Integration-Project-Class\assignments\Assignment3_integration\Views\ContactUS\Success.cshtml"
                      Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Assignment3_integration.Models.Contact> Html { get; private set; }
    }
}
#pragma warning restore 1591
