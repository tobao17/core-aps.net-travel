#pragma checksum "C:\Users\ww\Desktop\WebDuLich\Areas\Admin\Views\quanlyKhuyenMai\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a8e1ac1add964c923285ae9750a1ac4cb878f718"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_quanlyKhuyenMai_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/quanlyKhuyenMai/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/quanlyKhuyenMai/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_quanlyKhuyenMai_Index))]
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
#line 1 "C:\Users\ww\Desktop\WebDuLich\Areas\Admin\Views\quanlyKhuyenMai\Index.cshtml"
using WebDuLich.Models.DataModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8e1ac1add964c923285ae9750a1ac4cb878f718", @"/Areas/Admin/Views/quanlyKhuyenMai/Index.cshtml")]
    public class Areas_Admin_Views_quanlyKhuyenMai_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Sale>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\ww\Desktop\WebDuLich\Areas\Admin\Views\quanlyKhuyenMai\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/Sharelayout.cshtml";
    //WebGrid grid = new WebGrid(source: Model, rowsPerPage: 2);

#line default
#line hidden
            BeginContext(232, 103, true);
            WriteLiteral("<h4 class=\"mt-3\">\r\n    <span>SALE</span>\r\n    <a class=\"btn btn-primary text-light\" style=\"padding:2px\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 335, "\"", 381, 1);
#line 10 "C:\Users\ww\Desktop\WebDuLich\Areas\Admin\Views\quanlyKhuyenMai\Index.cshtml"
WriteAttributeValue("", 342, Url.Action("Create","quanlyKhuyenMai"), 342, 39, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(382, 259, true);
            WriteLiteral(@">New</a>
</h4>


<div class=""d-flex align-items-center"">
    <form class=""ml-auto d-flex"" action=""/Admin/quanlyKhuyenMai/search"" method=""post"">
        <input type=""text"" placeholder=""Search"" class=""form-control"" style=""border-radius:5px;"" name=""search""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 641, "\"", 664, 1);
#line 16 "C:\Users\ww\Desktop\WebDuLich\Areas\Admin\Views\quanlyKhuyenMai\Index.cshtml"
WriteAttributeValue("", 649, ViewBag.search, 649, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(665, 365, true);
            WriteLiteral(@" />
        <button class=""btn btn-primary ml-2"" style=""border-radius:5px"" ; type=""submit"">Search</button>
    </form>
</div>





<table class=""table table-striped border"">
    <caption>List of Sale</caption>
    <thead>
        <tr>
            <th>Mô tả</th>
            <th>Nội dung</th>
            

        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 36 "C:\Users\ww\Desktop\WebDuLich\Areas\Admin\Views\quanlyKhuyenMai\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(1079, 40, true);
            WriteLiteral("            <tr>\r\n\r\n                <td>");
            EndContext();
            BeginContext(1120, 9, false);
#line 40 "C:\Users\ww\Desktop\WebDuLich\Areas\Admin\Views\quanlyKhuyenMai\Index.cshtml"
               Write(item.Mota);

#line default
#line hidden
            EndContext();
            BeginContext(1129, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1157, 12, false);
#line 41 "C:\Users\ww\Desktop\WebDuLich\Areas\Admin\Views\quanlyKhuyenMai\Index.cshtml"
               Write(item.NoiDung);

#line default
#line hidden
            EndContext();
            BeginContext(1169, 383, true);
            WriteLiteral(@"</td>               
                <td>
                    <a href=""#"" class=""table-link"">
                        <span class=""fa-stack"">
                            <i class=""fa fa-square fa-stack-2x""></i>
                            <i class=""fa fa-search-plus fa-stack-1x fa-inverse""></i>
                        </span>
                    </a>
                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1552, "\"", 1619, 1);
#line 49 "C:\Users\ww\Desktop\WebDuLich\Areas\Admin\Views\quanlyKhuyenMai\Index.cshtml"
WriteAttributeValue("", 1559, Url.Action("Edit","quanlyKhuyenMai",new {@MaKM=item.MaKM }), 1559, 60, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1620, 303, true);
            WriteLiteral(@" class=""table-link"">
                        <span class=""fa-stack"">
                            <i class=""fa fa-square fa-stack-2x""></i>
                            <i class=""fa fa-pencil fa-stack-1x fa-inverse""></i>
                        </span>
                    </a>
                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1923, "\"", 1991, 1);
#line 55 "C:\Users\ww\Desktop\WebDuLich\Areas\Admin\Views\quanlyKhuyenMai\Index.cshtml"
WriteAttributeValue("", 1930, Url.Action("Delete","quanlyKhuyenMai",new {MaKM=item.MaKM }), 1930, 61, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1992, 331, true);
            WriteLiteral(@" class=""table-link danger"">
                        <span class=""fa-stack"">
                            <i class=""fa fa-square fa-stack-2x""></i>
                            <i class=""fa fa-trash-o fa-stack-1x fa-inverse""></i>
                        </span>
                    </a>
                </td>
            </tr>
");
            EndContext();
#line 63 "C:\Users\ww\Desktop\WebDuLich\Areas\Admin\Views\quanlyKhuyenMai\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(2334, 32, true);
            WriteLiteral("\r\n\r\n    </tbody>\r\n</table>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Sale>> Html { get; private set; }
    }
}
#pragma warning restore 1591
