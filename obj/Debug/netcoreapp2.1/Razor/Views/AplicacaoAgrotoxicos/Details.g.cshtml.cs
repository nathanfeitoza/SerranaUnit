#pragma checksum "C:\Users\1171139648\Desktop\Serrana\Views\AplicacaoAgrotoxicos\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7f867e4c62fcafb950c8e90e4fa0f201cc655760"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AplicacaoAgrotoxicos_Details), @"mvc.1.0.view", @"/Views/AplicacaoAgrotoxicos/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/AplicacaoAgrotoxicos/Details.cshtml", typeof(AspNetCore.Views_AplicacaoAgrotoxicos_Details))]
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
#line 1 "C:\Users\1171139648\Desktop\Serrana\Views\_ViewImports.cshtml"
using Serrana;

#line default
#line hidden
#line 2 "C:\Users\1171139648\Desktop\Serrana\Views\_ViewImports.cshtml"
using Serrana.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f867e4c62fcafb950c8e90e4fa0f201cc655760", @"/Views/AplicacaoAgrotoxicos/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc05da7fc282fd1f7d2dfbbebe6c84df064681bf", @"/Views/_ViewImports.cshtml")]
    public class Views_AplicacaoAgrotoxicos_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Serrana.Models.AplicacaoAgrotoxico>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(43, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\1171139648\Desktop\Serrana\Views\AplicacaoAgrotoxicos\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(88, 133, true);
            WriteLiteral("\r\n<h2>Details</h2>\r\n\r\n<div>\r\n    <h4>AplicacaoAgrotoxico</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(222, 48, false);
#line 14 "C:\Users\1171139648\Desktop\Serrana\Views\AplicacaoAgrotoxicos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Qtd_Aplicada));

#line default
#line hidden
            EndContext();
            BeginContext(270, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(314, 44, false);
#line 17 "C:\Users\1171139648\Desktop\Serrana\Views\AplicacaoAgrotoxicos\Details.cshtml"
       Write(Html.DisplayFor(model => model.Qtd_Aplicada));

#line default
#line hidden
            EndContext();
            BeginContext(358, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(402, 40, false);
#line 20 "C:\Users\1171139648\Desktop\Serrana\Views\AplicacaoAgrotoxicos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Tipo));

#line default
#line hidden
            EndContext();
            BeginContext(442, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(486, 36, false);
#line 23 "C:\Users\1171139648\Desktop\Serrana\Views\AplicacaoAgrotoxicos\Details.cshtml"
       Write(Html.DisplayFor(model => model.Tipo));

#line default
#line hidden
            EndContext();
            BeginContext(522, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(566, 40, false);
#line 26 "C:\Users\1171139648\Desktop\Serrana\Views\AplicacaoAgrotoxicos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Area));

#line default
#line hidden
            EndContext();
            BeginContext(606, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(650, 44, false);
#line 29 "C:\Users\1171139648\Desktop\Serrana\Views\AplicacaoAgrotoxicos\Details.cshtml"
       Write(Html.DisplayFor(model => model.Area.Area_Id));

#line default
#line hidden
            EndContext();
            BeginContext(694, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(738, 46, false);
#line 32 "C:\Users\1171139648\Desktop\Serrana\Views\AplicacaoAgrotoxicos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Agrotoxico));

#line default
#line hidden
            EndContext();
            BeginContext(784, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(828, 47, false);
#line 35 "C:\Users\1171139648\Desktop\Serrana\Views\AplicacaoAgrotoxicos\Details.cshtml"
       Write(Html.DisplayFor(model => model.Agrotoxico.Nome));

#line default
#line hidden
            EndContext();
            BeginContext(875, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(923, 68, false);
#line 40 "C:\Users\1171139648\Desktop\Serrana\Views\AplicacaoAgrotoxicos\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { /* id = Model.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(991, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(999, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e33771b2a9dd439bbb993655a3c49338", async() => {
                BeginContext(1021, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1037, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Serrana.Models.AplicacaoAgrotoxico> Html { get; private set; }
    }
}
#pragma warning restore 1591
