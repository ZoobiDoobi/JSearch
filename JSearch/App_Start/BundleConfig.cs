﻿using System.Web.Optimization;

namespace JSearch
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/DataTables/jquery.dataTables.min.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js", 
                      //"~/Scripts/datatables/datatables.bootstrap.js",
                      "~/Scripts/typeahead.bundle.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      //"~/Content/datatables/css/datatables.bootstrap.css",
                      "~/Content/DataTables/css/jquery.dataTables.min.css",
                      "~/Content/typeahead.css",
                      "~/Content/site.css"));
        }
    }
}
