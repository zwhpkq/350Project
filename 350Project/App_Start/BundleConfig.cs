using System.Web.Optimization;

namespace _350Project
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));


            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css1").Include(
                        "~/Content/custom2.css",
                        "~/Content/demo.css",
                        "~/Content/pfold.css"));

            bundles.Add(new ScriptBundle("~/Content/gallary").Include(
                        "~/Scripts/jquery.min.js",
                        "~/Scripts/jquery.pflod.js",
                        "~/Scripts/fold.js",
                        "~/Scripts/modernizr.custom.79639.js"));

            bundles.Add(new ScriptBundle("~/bundles/d3").Include(
                "~/Scripts/d3.*"));
        }
    }
}
