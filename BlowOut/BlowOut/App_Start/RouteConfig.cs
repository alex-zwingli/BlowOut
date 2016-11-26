using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BlowOut
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Instrument",
                url: "Rent/Instrument/{description}",
                defaults: new { controller = "Rent", action = "Instrument", description = "Trumpet" }
            );

            routes.MapRoute(
                name: "Rent",
                url: "Rent/{action}/{description}/{type}",
                defaults: new { controller = "Rent", action = "Rent" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
