#pragma checksum "D:\Gradution Project\Symptom-Checker\WebApplication5\Views\Appoinment\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "566622442fbd906186e301f7aa928b34029594e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Appoinment_Index), @"mvc.1.0.view", @"/Views/Appoinment/Index.cshtml")]
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
#line 1 "D:\Gradution Project\Symptom-Checker\WebApplication5\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Gradution Project\Symptom-Checker\WebApplication5\Views\_ViewImports.cshtml"
using WebApplication5;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Gradution Project\Symptom-Checker\WebApplication5\Views\_ViewImports.cshtml"
using WebApplication5.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Gradution Project\Symptom-Checker\WebApplication5\Views\_ViewImports.cshtml"
using WebApplication5.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"566622442fbd906186e301f7aa928b34029594e1", @"/Views/Appoinment/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8779e836ae1632223bf3d18b22a703167d588089", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Appoinment_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DAL.Entities.Appoinment>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Gradution Project\Symptom-Checker\WebApplication5\Views\Appoinment\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Appointments</h1>\r\n\r\n<table class=\"table table-striped\">\r\n    <thead>\r\n        <tr>\r\n\r\n\r\n\r\n\r\n\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n\r\n");
#nullable restore
#line 20 "D:\Gradution Project\Symptom-Checker\WebApplication5\Views\Appoinment\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td> ");
#nullable restore
#line 23 "D:\Gradution Project\Symptom-Checker\WebApplication5\Views\Appoinment\Index.cshtml"
                Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 24 "D:\Gradution Project\Symptom-Checker\WebApplication5\Views\Appoinment\Index.cshtml"
               Write(item.AppointmentTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 25 "D:\Gradution Project\Symptom-Checker\WebApplication5\Views\Appoinment\Index.cshtml"
               Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 26 "D:\Gradution Project\Symptom-Checker\WebApplication5\Views\Appoinment\Index.cshtml"
               Write(item.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 27 "D:\Gradution Project\Symptom-Checker\WebApplication5\Views\Appoinment\Index.cshtml"
               Write(item.Doctor.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n            </tr>\r\n");
#nullable restore
#line 30 "D:\Gradution Project\Symptom-Checker\WebApplication5\Views\Appoinment\Index.cshtml"



        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DAL.Entities.Appoinment>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
