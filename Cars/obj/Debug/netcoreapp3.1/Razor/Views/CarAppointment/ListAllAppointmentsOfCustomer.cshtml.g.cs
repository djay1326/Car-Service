#pragma checksum "F:\Cars\Cars\Cars\Views\CarAppointment\ListAllAppointmentsOfCustomer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f6a6b273e80556bf6f2dd7c004a9fd6dc075d436"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CarAppointment_ListAllAppointmentsOfCustomer), @"mvc.1.0.view", @"/Views/CarAppointment/ListAllAppointmentsOfCustomer.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/CarAppointment/ListAllAppointmentsOfCustomer.cshtml", typeof(AspNetCore.Views_CarAppointment_ListAllAppointmentsOfCustomer))]
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
#line 1 "F:\Cars\Cars\Cars\Views\_ViewImports.cshtml"
using Cars;

#line default
#line hidden
#line 2 "F:\Cars\Cars\Cars\Views\_ViewImports.cshtml"
using Cars.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6a6b273e80556bf6f2dd7c004a9fd6dc075d436", @"/Views/CarAppointment/ListAllAppointmentsOfCustomer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e81401665ddb2321f0f7045eb187670fb10a21d3", @"/Views/_ViewImports.cshtml")]
    public class Views_CarAppointment_ListAllAppointmentsOfCustomer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Dal.Models.CarAppointment>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/edit-icon.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("updateDetails"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Edit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("22"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("22"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "CarAppointment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetAppointmentDetailsForUpdating", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/delete-icon.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Delete"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("xyz"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("overflow-hidden"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_14 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_15 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(177, 308, true);
            WriteLiteral(@"

<div class=""row"">
    <div class=""col-md-12 col-lg-12 col-xl-12"">
        <div class=""card"">
            <div class=""card-header"">
                <h4>My Appointments</h4>
            </div>
            <div class=""card-body"">
                <div class=""table-responsive"">

                    ");
            EndContext();
            BeginContext(485, 8363, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f6a6b273e80556bf6f2dd7c004a9fd6dc075d4369615", async() => {
                BeginContext(538, 630, true);
                WriteLiteral(@"

                        <table class=""table table-hover mb-0 overflow-hidden"" id=""tab1"">
                            <thead>
                                <tr class=""vw-100"">
                                    <th>#</th>
                                    <th>Car Details</th>
                                    <th>Approx Cost</th>
                                    <th>Garage Details</th>
                                    <th>Status</th>
                                    <th>Actions</th>
                                </tr>
                            </thead>
                            <tbody>
");
                EndContext();
#line 32 "F:\Cars\Cars\Cars\Views\CarAppointment\ListAllAppointmentsOfCustomer.cshtml"
                                 foreach (var item in Model)
                                {

#line default
#line hidden
                BeginContext(1265, 122, true);
                WriteLiteral("                                    <tr>\r\n                                        <td scope=\"row\" class=\"font-weight-600\">");
                EndContext();
                BeginContext(1388, 7, false);
#line 35 "F:\Cars\Cars\Cars\Views\CarAppointment\ListAllAppointmentsOfCustomer.cshtml"
                                                                           Write(item.Id);

#line default
#line hidden
                EndContext();
                BeginContext(1395, 207, true);
                WriteLiteral("</td>\r\n\r\n                                        <td>\r\n                                            <a href=\"#\" class=\"text-decoration-none\">\r\n                                                <p class=\"m-0\">\r\n");
                EndContext();
                BeginContext(1719, 131, true);
                WriteLiteral("                                                    <span>\r\n                                                        Manufacturer : ");
                EndContext();
                BeginContext(1851, 13, false);
#line 42 "F:\Cars\Cars\Cars\Views\CarAppointment\ListAllAppointmentsOfCustomer.cshtml"
                                                                  Write(item.CarModel);

#line default
#line hidden
                EndContext();
                BeginContext(1864, 74, true);
                WriteLiteral("  <br />\r\n                                                        Model : ");
                EndContext();
                BeginContext(1939, 12, false);
#line 43 "F:\Cars\Cars\Cars\Views\CarAppointment\ListAllAppointmentsOfCustomer.cshtml"
                                                           Write(item.CarName);

#line default
#line hidden
                EndContext();
                BeginContext(1951, 75, true);
                WriteLiteral("  <br />\r\n                                                        Number : ");
                EndContext();
                BeginContext(2027, 14, false);
#line 44 "F:\Cars\Cars\Cars\Views\CarAppointment\ListAllAppointmentsOfCustomer.cshtml"
                                                            Write(item.CarNumber);

#line default
#line hidden
                EndContext();
                BeginContext(2041, 294, true);
                WriteLiteral(@"
                                                    </span>
                                                </p>
                                            </a>
                                        </td>
                                        <td scope=""row"" class=""font-weight-600"">");
                EndContext();
                BeginContext(2336, 15, false);
#line 49 "F:\Cars\Cars\Cars\Views\CarAppointment\ListAllAppointmentsOfCustomer.cshtml"
                                                                           Write(item.ApproxCost);

#line default
#line hidden
                EndContext();
                BeginContext(2351, 205, true);
                WriteLiteral("</td>\r\n                                        <td>\r\n                                            <a href=\"#\" class=\"text-decoration-none\">\r\n                                                <p class=\"m-0\">\r\n");
                EndContext();
                BeginContext(2673, 146, true);
                WriteLiteral("                                                    <span>\r\n                                                        <span class=\"font-weight-600\">");
                EndContext();
                BeginContext(2820, 15, false);
#line 55 "F:\Cars\Cars\Cars\Views\CarAppointment\ListAllAppointmentsOfCustomer.cshtml"
                                                                                 Write(item.GarageName);

#line default
#line hidden
                EndContext();
                BeginContext(2835, 72, true);
                WriteLiteral("</span> <br />\r\n                                                        ");
                EndContext();
                BeginContext(2908, 17, false);
#line 56 "F:\Cars\Cars\Cars\Views\CarAppointment\ListAllAppointmentsOfCustomer.cshtml"
                                                   Write(item.AddressLine1);

#line default
#line hidden
                EndContext();
                BeginContext(2925, 2, true);
                WriteLiteral(" ,");
                EndContext();
                BeginContext(2928, 17, false);
#line 56 "F:\Cars\Cars\Cars\Views\CarAppointment\ListAllAppointmentsOfCustomer.cshtml"
                                                                       Write(item.AddressLine2);

#line default
#line hidden
                EndContext();
                BeginContext(2945, 65, true);
                WriteLiteral(" <br />\r\n                                                        ");
                EndContext();
                BeginContext(3011, 9, false);
#line 57 "F:\Cars\Cars\Cars\Views\CarAppointment\ListAllAppointmentsOfCustomer.cshtml"
                                                   Write(item.City);

#line default
#line hidden
                EndContext();
                BeginContext(3020, 4, true);
                WriteLiteral(" -  ");
                EndContext();
                BeginContext(3025, 15, false);
#line 57 "F:\Cars\Cars\Cars\Views\CarAppointment\ListAllAppointmentsOfCustomer.cshtml"
                                                                 Write(item.PostalCode);

#line default
#line hidden
                EndContext();
                BeginContext(3040, 72, true);
                WriteLiteral("        <br />\r\n                                                        ");
                EndContext();
                BeginContext(3113, 10, false);
#line 58 "F:\Cars\Cars\Cars\Views\CarAppointment\ListAllAppointmentsOfCustomer.cshtml"
                                                   Write(item.State);

#line default
#line hidden
                EndContext();
                BeginContext(3123, 272, true);
                WriteLiteral(@"
                                                    </span>
                                                </p>
                                            </a>
                                        </td>
                                        <td scope=""row"">
");
                EndContext();
#line 64 "F:\Cars\Cars\Cars\Views\CarAppointment\ListAllAppointmentsOfCustomer.cshtml"
                                             if (item.ServiceStatus == 1)
                                            {

#line default
#line hidden
                BeginContext(3517, 86, true);
                WriteLiteral("                                                <span class=\"pending\">Pending</span>\r\n");
                EndContext();
#line 67 "F:\Cars\Cars\Cars\Views\CarAppointment\ListAllAppointmentsOfCustomer.cshtml"
                                            }

#line default
#line hidden
#line 68 "F:\Cars\Cars\Cars\Views\CarAppointment\ListAllAppointmentsOfCustomer.cshtml"
                                             if (item.ServiceStatus == 2 || item.ServiceStatus == 4 || item.ServiceStatus == 5 || item.ServiceStatus == 6)
                                            {

#line default
#line hidden
                BeginContext(3853, 88, true);
                WriteLiteral("                                                <span class=\"completed\">Approve</span>\r\n");
                EndContext();
#line 71 "F:\Cars\Cars\Cars\Views\CarAppointment\ListAllAppointmentsOfCustomer.cshtml"
                                            }

#line default
#line hidden
#line 72 "F:\Cars\Cars\Cars\Views\CarAppointment\ListAllAppointmentsOfCustomer.cshtml"
                                             if (item.ServiceStatus == 3)
                                            {

#line default
#line hidden
                BeginContext(4110, 90, true);
                WriteLiteral("                                                <span class=\"cancelled\">Cancelled</span>\r\n");
                EndContext();
#line 75 "F:\Cars\Cars\Cars\Views\CarAppointment\ListAllAppointmentsOfCustomer.cshtml"
                                            }

#line default
#line hidden
                BeginContext(4247, 122, true);
                WriteLiteral("                                        </td>\r\n                                        <td class=\"text-center main-btn\">\r\n");
                EndContext();
#line 78 "F:\Cars\Cars\Cars\Views\CarAppointment\ListAllAppointmentsOfCustomer.cshtml"
                                             if (item.ServiceStatus == 1)
                                            {

#line default
#line hidden
                BeginContext(4491, 48, true);
                WriteLiteral("                                                ");
                EndContext();
                BeginContext(4539, 351, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f6a6b273e80556bf6f2dd7c004a9fd6dc075d43619933", async() => {
                    BeginContext(4658, 54, true);
                    WriteLiteral("\r\n                                                    ");
                    EndContext();
                    BeginContext(4712, 124, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f6a6b273e80556bf6f2dd7c004a9fd6dc075d43620388", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                    BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "routeId", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 81 "F:\Cars\Cars\Cars\Views\CarAppointment\ListAllAppointmentsOfCustomer.cshtml"
AddHtmlAttributeValue("", 4759, item.Id, 4759, 8, false);

#line default
#line hidden
                    EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(4836, 50, true);
                    WriteLiteral("\r\n                                                ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 80 "F:\Cars\Cars\Cars\Views\CarAppointment\ListAllAppointmentsOfCustomer.cshtml"
                                                                                                                                                 WriteLiteral(item.Id);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4890, 110, true);
                WriteLiteral("\r\n                                                <a href=\"#exampleModal\" data-bs-toggle=\"modal\" role=\"button\"");
                EndContext();
                BeginWriteAttribute("routeId", " routeId=\"", 5000, "\"", 5018, 1);
#line 83 "F:\Cars\Cars\Cars\Views\CarAppointment\ListAllAppointmentsOfCustomer.cshtml"
WriteAttributeValue("", 5010, item.Id, 5010, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5019, 74, true);
                WriteLiteral(" class=\"deleteMenu\">\r\n                                                    ");
                EndContext();
                BeginContext(5093, 85, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f6a6b273e80556bf6f2dd7c004a9fd6dc075d43625694", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5178, 56, true);
                WriteLiteral("\r\n                                                </a>\r\n");
                EndContext();
#line 86 "F:\Cars\Cars\Cars\Views\CarAppointment\ListAllAppointmentsOfCustomer.cshtml"
                                            }

#line default
#line hidden
                BeginContext(5281, 92, true);
                WriteLiteral("\r\n                                        </td>\r\n                                    </tr>\r\n");
                EndContext();
#line 90 "F:\Cars\Cars\Cars\Views\CarAppointment\ListAllAppointmentsOfCustomer.cshtml"
                                }

#line default
#line hidden
                BeginContext(5408, 573, true);
                WriteLiteral(@"                            </tbody>
                            <tfoot class=""d-none"">
                                <tr>
                                    <th>#</th>
                                    <th>Car Details</th>
                                    <th>Approx Cost</th>
                                    <th>Garage Details</th>
                                    <th>Status</th>
                                    <th>Actions</th>
                                </tr>
                            </tfoot>
                        </table>

");
                EndContext();
                BeginContext(6775, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                DefineSection("Scripts", async() => {
                    BeginContext(6818, 837, true);
                    WriteLiteral(@"
                            <script>
                                                $('#exampleModal').appendTo(""body""); // I ADDED THIS SO THAT NO MORE MODAL BACKDROP OCCURS.
                                                var i;
                                                $(document).on('click', '.deleteMenu', function () {
                                                    i = parseInt($(this).attr(""routeId""));
                                                    console.log(i);
                                                });
                                                $(document).on('click', '#del1', function() {
                                                    console.log(i);
                                                    $.ajax({
                                                    url: '");
                    EndContext();
                    BeginContext(7656, 49, false);
#line 133 "F:\Cars\Cars\Cars\Views\CarAppointment\ListAllAppointmentsOfCustomer.cshtml"
                                                     Write(Url.Action("DeleteAppointment", "CarAppointment"));

#line default
#line hidden
                    EndContext();
                    BeginContext(7705, 1113, true);
                    WriteLiteral(@"',
                                                    type: 'post',
                                                    data: { id: i},

                                                    success: function(resp) {
                                                        $('body').removeClass('modal-open'); //remove modal-open from body in case you see faded background
                                                        $('.modal-backdrop').remove();       // remove modal-backdrop at the end of page in case you see faded background
                                                        location.reload();
                                                    },
                                                    error: function(err) {
                                                        alert(""Error while inserting data"");
                                                    }

                                                    });

                                                });
    ");
                    WriteLiteral("                        </script>\r\n                            \r\n                        ");
                    EndContext();
                }
                );
                BeginContext(8821, 20, true);
                WriteLiteral("                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(8848, 673, true);
            WriteLiteral(@"
                </div>
            </div>
        </div>
    </div>
</div>

<!-- Modal -->
<div class=""modal fade"" id=""exampleModal"" tabindex=""-1"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Delete Image</h5>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close"" style=""background-color:white;border:1px solid white;"">&#10006;</button>
            </div>
            <div class=""modal-body"">
                ");
            EndContext();
            BeginContext(9521, 470, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f6a6b273e80556bf6f2dd7c004a9fd6dc075d43633621", async() => {
                BeginContext(9549, 435, true);
                WriteLiteral(@"
                    <p class=""mb-3 clrr"">Are You sure you want to delete this Appointment?</p>
                    <button type=""button"" id=""del1"" class=""mt-2 reschedule-btn rounded-pill bll text-light px-3 pdd"">
                        Yes
                    </button>
                    <button type=""button"" class=""btn btn-secondary rounded-pill bll text-light px-3 pdd"" data-bs-dismiss=""modal"">No</button>
                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_14);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_15);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(9991, 240, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<script src=\"https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js\"></script>\r\n<script>\r\n    \r\n        $(\"#AllAppointmentsOfMine\").addClass(\'active\');\r\n        \r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Dal.Models.CarAppointment>> Html { get; private set; }
    }
}
#pragma warning restore 1591