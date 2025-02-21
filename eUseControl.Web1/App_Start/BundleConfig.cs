using System;
using System.Web.Optimization;

namespace eUseControl.Web1.App_Start
{
	public class BundleConfig
	{
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery/js")
                .Include(
                    "~/Scripts/jquery-{version}.js"));

            bundles.Add(new StyleBundle("~/bundles/bootstrap/css")
                        .Include(
                        "~/Content/bootstrap.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/animate/css")
                .Include(
                    "~/Content/lib/animate/animate.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/owlcarouselmin/css")
                .Include(
                    "~/Content/lib/owlcarousel/assets/owl.carousel.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/tempusdominus-bootstrap-4-min/css")
                .Include(
                    "~/Content/lib/tempusdominus/css/tempusdominus-bootstrap-4.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/style/css")
                .Include(
                    "~/Content/css/style.css", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/bundles/wow/js")
                    .Include(
                        "~/Content/lib/wow/wow.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/easing/js")
                    .Include(
                        "~/Content/lib/easing/easing.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/waypoints/js")
                    .Include(
                        "~/Content/lib/waypoints/waypoints.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/counterup/js")
                    .Include(
                        "~/Content/lib/counterup/counterup.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/owl-carousel-min/js")
                .Include(
                    "~/Content/lib/owlcarousel/owl.carousel.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/tempusdominus/js")
                        .Include(
                            "~/Content/lib/tempusdominus/js/moment.min.js",
                            "~/Content/lib/tempusdominus/js/moment-timezone.min.js",
                            "~/Content/lib/tempusdominus/js/tempusdominus-bootstrap-4.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/main/js")
                .Include(
                    "~/Scripts/js/main.js"));

            BundleTable.EnableOptimizations = true;
        }
	}
}