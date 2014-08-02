using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ArborDesign
{
    public static class BundleConfig
    {
        public static void Register(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/Script/fooditems").Include("~/Scripts/Angular/Application.js").Include("~/Scripts/Angular/Controllers/foodCtr.js"));

            bundles.Add(new StyleBundle("~/Content/css").IncludeBasicCss());

            bundles.Add(new ScriptBundle("~/Scripts/js").IncludeBasicJs());

            bundles.Add(new ScriptBundle("~/Scripts/auth")
                .IncludeBasicJs()
                .IncludeAngular()
                .Include("~/Scripts/Angular/Application.js")
                .Include("~/Scripts/Angular/RouthProviders/AuthRouts.js")
                .Include("~/Scripts/Angular/Controllers/AuthCtr.js"));

            bundles.Add(new ScriptBundle("~/Scripts/food")
                .IncludeAngular()
                .Include("~/Scripts/Angular/Application.js")
                .Include("~/Scripts/Angular/Services/FoodListSrv.js")
                .Include("~/Scripts/Angular/Controllers/FoodListCtr.js"));

            bundles.Add(new ScriptBundle("~/Scripts/hierarchy")
                .IncludeBasicJs()
                .IncludeAngular()
                .Include("~/Scripts/Angular/Application.js")
                .Include("~/Scripts/Angular/RouthProviders/HierarchyRouts.js")
                .Include("~/Scripts/Angular/Services/HierarchySrv.js")
                .Include("~/Scripts/Angular/Controllers/HierarchyCtr.js"));
        }

        private static StyleBundle IncludeBasicCss(this StyleBundle source)
        {
            source
                .Include("~/Content/site.css")
                .Include("~/Content/bootstrap.css");
            return source;
        }

        private static ScriptBundle IncludeBasicJs(this ScriptBundle source)
        {
            source
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/bootstrap.js");
            return source;
        }

        private static ScriptBundle IncludeAngular(this ScriptBundle source)
        {
            source.Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/angular.js",
                "~/Scripts/angular-animate.js",
                "~/Scripts/angular-loader.js",
                "~/Scripts/angular-resource.js",
                "~/Scripts/angular-route.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/bootstrap.validate.js",
               // "~/Scripts/angular-ui/ui-bootstrap.js",
                "~/Scripts/angular-ui/ui-bootstrap-tpls.js",
                "~/Scripts/site.js"
                );
            return source;
        }
    }
}