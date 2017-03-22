using System.Web;
using System.Web.Optimization;

namespace RickAndMortyRestoreStore
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //"~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/materialize").Include(
                    "~/Content/js/materialize.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/pagescripts").Include(
                    "~/Scripts/scripts.js"   
                ));
            bundles.Add(new ScriptBundle("~/bundles/confirmation").Include(
                    "~/Scripts/confirmationscripts.js"
                ));

            bundles.Add(new StyleBundle("~/Content/styles").Include(
                      "~/Content/css/materialize.css",
                      "~/Content/site.css"));
        }
    }
}
