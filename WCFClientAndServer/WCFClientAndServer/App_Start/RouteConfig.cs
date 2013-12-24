using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WCFClientAndServer.Services;

namespace WCFClientAndServer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                ,constraints: new { controller = @"^(?!api)\w+$" }
            );

            // Add wcf service
            //WebServiceHostFactory, WebHttpBehavior,  WebHttpBinding 
            RouteTable.Routes.Add(new ServiceRoute(
                @"api/RestService", new WebServiceHostFactory(), typeof(RestService)));

            //ServiceHostFactory, basicHttpBinding 
            RouteTable.Routes.Add(new ServiceRoute(
                @"api/MyService", new ServiceHostFactory(), typeof(MyService)));
         
        }
    }
}
