using System.Web;
using System.Web.Optimization;

namespace M32COM
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                         "~/Scripts/bootstrap.js",
                      "~/Scripts/bootbox.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/dataTables/jquery.dataTables.js",
                      "~/Scripts/dataTables/dataTables.bootstrap.js",
                      "~/scripts/typeahead.bundle.js",
                      "~/scripts/toastr.js"
                        

                        ));


//            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
//                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

//            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
//                        "~/Scripts/datatables/datatables.bootstrap.js",
//                        "~/Scripts/datatables/jquery.datatables.js"
//                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

//            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
//                      "~/Scripts/bootstrap.js",
//                      "~/Scripts/bootbox.js",
//                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-lumen.css",
                      "~/Content/dataTables/css/dataTables.bootstrap.css",
                      "~/Content/TypeAhead.css",
                      "~/Content/toastr.css",
                      "~/Content/site.css"
                      ));
        }
    }
}
