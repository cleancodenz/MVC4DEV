using System.Web.Services.Protocols;
using SessionLess.API;
using SessionLess.CustomRoutHandler;
using System.Web.Mvc;
using System.Web.Routing;
using System.ServiceModel.Activation;

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

            /**
            routes.MapRoute(
                name: "helloroute",
                url: "Hello.hdp"
            ).RouteHandler = new MyDeepRouteHandler();
            **/

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
              //  ,namespaces: new string[] { "SessionLess.Controllers" }
               , constraints: new { id = @"\d*", controller = @"^(?!api)\w+$" }
            ).RouteHandler = new MyCustomRouteHandler();

            //Not using WebServiceHostFactory here which is creating WebHttpBinding
            //We want to use wshttpbinding here 
            RouteTable.Routes.Add(
                new ServiceRoute(
                    @"api/Math1Service",
                    new WebServiceHostFactory(),
                    typeof(IISMathService)));

        }
    }
}
