#pragma checksum "C:\Users\MarWan\source\repos\WebApplication7\WebApplication7\Pages\Tasks\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3a82c6bfda8496f8157e240305e7e7df7f127c14"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebApplication7.Pages.Tasks.Pages_Tasks_Delete), @"mvc.1.0.razor-page", @"/Pages/Tasks/Delete.cshtml")]
namespace WebApplication7.Pages.Tasks
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
#line 1 "C:\Users\MarWan\source\repos\WebApplication7\WebApplication7\Pages\_ViewImports.cshtml"
using WebApplication7;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\MarWan\source\repos\WebApplication7\WebApplication7\Pages\Tasks\Delete.cshtml"
using System.Data.SqlClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\MarWan\source\repos\WebApplication7\WebApplication7\Pages\Tasks\Delete.cshtml"
using System.Configuration;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a82c6bfda8496f8157e240305e7e7df7f127c14", @"/Pages/Tasks/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9f341167a37b36ba46f8151346e5a45a3ea320a", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Tasks_Delete : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 8 "C:\Users\MarWan\source\repos\WebApplication7\WebApplication7\Pages\Tasks\Delete.cshtml"
  
    try
    {
        //task id from parameter
        string taskId = Request.Query["id"];
        //get connection from configuration file
        string connectionString = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        //connecting ...
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            //delete query
            String sql =string.Format( "delete from tasks where id={0}", taskId);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    catch (Exception ex)
    {
    }
    //redirect when finnish
    Response.Redirect("/Tasks/Index");

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pages_Tasks_Delete> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_Tasks_Delete> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_Tasks_Delete>)PageContext?.ViewData;
        public Pages_Tasks_Delete Model => ViewData.Model;
    }
}
#pragma warning restore 1591