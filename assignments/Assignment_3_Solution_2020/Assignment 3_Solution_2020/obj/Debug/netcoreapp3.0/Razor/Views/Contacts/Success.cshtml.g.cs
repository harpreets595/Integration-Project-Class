#pragma checksum "C:\Users\Harpreet Singh\Desktop\Assignment_3_Solution_2020\Assignment 3_Solution_2020\Views\Contacts\Success.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c5b87be42da80fb6913ce72a4a3834bc2a84fab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contacts_Success), @"mvc.1.0.view", @"/Views/Contacts/Success.cshtml")]
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
#line 1 "C:\Users\Harpreet Singh\Desktop\Assignment_3_Solution_2020\Assignment 3_Solution_2020\Views\_ViewImports.cshtml"
using Milestone_4A;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Harpreet Singh\Desktop\Assignment_3_Solution_2020\Assignment 3_Solution_2020\Views\_ViewImports.cshtml"
using Milestone_4A.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c5b87be42da80fb6913ce72a4a3834bc2a84fab", @"/Views/Contacts/Success.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e74773ee7a6742a490ecadf05520cc52d710ac7", @"/Views/_ViewImports.cshtml")]
    public class Views_Contacts_Success : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Contact>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Harpreet Singh\Desktop\Assignment_3_Solution_2020\Assignment 3_Solution_2020\Views\Contacts\Success.cshtml"
  
    ViewData["Title"] = "Success";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Success</h1>\r\n\r\n<h3>Thank you ");
#nullable restore
#line 8 "C:\Users\Harpreet Singh\Desktop\Assignment_3_Solution_2020\Assignment 3_Solution_2020\Views\Contacts\Success.cshtml"
         Write(Model.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 8 "C:\Users\Harpreet Singh\Desktop\Assignment_3_Solution_2020\Assignment 3_Solution_2020\Views\Contacts\Success.cshtml"
                          Write(Model.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n<p>A copy has been sent to ");
#nullable restore
#line 9 "C:\Users\Harpreet Singh\Desktop\Assignment_3_Solution_2020\Assignment 3_Solution_2020\Views\Contacts\Success.cshtml"
                      Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Contact> Html { get; private set; }
    }
}
#pragma warning restore 1591
