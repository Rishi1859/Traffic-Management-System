#pragma checksum "E:\DotNetBatchJan2021\BusReservationSystem\BusReservationSystem\Views\Travel\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4c7ffba69982318c1a8d3ca900b56d349b83ec5e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Travel_Details), @"mvc.1.0.view", @"/Views/Travel/Details.cshtml")]
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
#line 1 "E:\DotNetBatchJan2021\BusReservationSystem\BusReservationSystem\Views\_ViewImports.cshtml"
using BusReservationSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\DotNetBatchJan2021\BusReservationSystem\BusReservationSystem\Views\_ViewImports.cshtml"
using BusReservationSystem.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c7ffba69982318c1a8d3ca900b56d349b83ec5e", @"/Views/Travel/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2923367cda10cd6b7a4f6ff87767cdb3d65446ae", @"/Views/_ViewImports.cshtml")]
    public class Views_Travel_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Bus.DomainModels.BusDetails>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("\r\nbackground-image:url(\'/images/pattern.jpg\');\r\nbackground-size:cover;\r\nbackground-repeat:no-repeat;\r\nbackground-position:center center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Travel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-left: 12px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\DotNetBatchJan2021\BusReservationSystem\BusReservationSystem\Views\Travel\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 style=\" margin-left: 10px;\">Details</h1>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4c7ffba69982318c1a8d3ca900b56d349b83ec5e5360", async() => {
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 15 "E:\DotNetBatchJan2021\BusReservationSystem\BusReservationSystem\Views\Travel\Details.cshtml"
 if (Model != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table\">\r\n\r\n        <tr>\r\n            <td>Bus Id</td>\r\n            <td>B ");
#nullable restore
#line 21 "E:\DotNetBatchJan2021\BusReservationSystem\BusReservationSystem\Views\Travel\Details.cshtml"
             Write(Model.BusId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n\r\n        <tr>\r\n            <td>Bus Name</td>\r\n            <td>");
#nullable restore
#line 26 "E:\DotNetBatchJan2021\BusReservationSystem\BusReservationSystem\Views\Travel\Details.cshtml"
           Write(Model.BusName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n\r\n        <tr>\r\n            <td>Category</td>\r\n            <td>");
#nullable restore
#line 31 "E:\DotNetBatchJan2021\BusReservationSystem\BusReservationSystem\Views\Travel\Details.cshtml"
           Write(Model.BusCategory);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n\r\n        <tr>\r\n            <td>Capacity</td>\r\n            <td>");
#nullable restore
#line 36 "E:\DotNetBatchJan2021\BusReservationSystem\BusReservationSystem\Views\Travel\Details.cshtml"
           Write(Model.Capacity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n\r\n    </table>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4c7ffba69982318c1a8d3ca900b56d349b83ec5e8033", async() => {
                WriteLiteral("Back to the list");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 41 "E:\DotNetBatchJan2021\BusReservationSystem\BusReservationSystem\Views\Travel\Details.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h5>");
#nullable restore
#line 44 "E:\DotNetBatchJan2021\BusReservationSystem\BusReservationSystem\Views\Travel\Details.cshtml"
   Write(ViewBag.StatusCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n");
#nullable restore
#line 45 "E:\DotNetBatchJan2021\BusReservationSystem\BusReservationSystem\Views\Travel\Details.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Bus.DomainModels.BusDetails> Html { get; private set; }
    }
}
#pragma warning restore 1591
