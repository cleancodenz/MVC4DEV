using SessionLess.CustomRoutHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SessionLess
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{handler}.ashx");
            
            // Both ways of registering RouteHandlers are working
            /**
            routes.Add(
               new Route(
                   "Hello.hdp",
                   new MyDeepRouteHandler())
              );
            **/


            routes.MapRoute(
                name: "helloroute",
                url: "Hello.hdp"
            ).RouteHandler = new MyDeepRouteHandler();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
              //  ,namespaces: new string[] { "SessionLess.Controllers" }
               , constraints: new { id = @"\d*" }
            ).RouteHandler = new MyCustomRouteHandler();

          

        }
    }
}
