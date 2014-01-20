using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CateringApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // ----------------------- CUSTOM ROUTES ----------------------------------------
            routes.MapRoute(
                "Town",
                "Towns/{action}/{id}",
                new { controller = "Town", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Restaurant",
                "{townName}/Restaurants/{action}/{id}",
                new { controller = "Restaurant", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Food",
                "{restaurantName}/Food/{action}/{id}",
                new { controller = "Food", action = "Index", id = UrlParameter.Optional }
            );
            // -------------------------------------------------------------------------------

            // Default route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}