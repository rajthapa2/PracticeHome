using System.Web.Mvc;
using System.Web.Routing;

namespace RiskCapture.Client
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("default", "", new { controller = "pages", action = "home" });
            routes.MapRoute("questions", "questions", new {controller = "pages", action = "questions"});
        }
    }
}